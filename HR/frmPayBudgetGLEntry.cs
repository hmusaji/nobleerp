
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Text;
using System.Windows.Forms;
using UpgradeHelpers.Gui;



namespace Xtreme
{
	internal partial class frmPayBudgetGLEntry
		: System.Windows.Forms.Form
	{


		private clsAccessAllowed _UserAccess = null;
		public frmPayBudgetGLEntry()
{
InitializeComponent();
} 
 public  void frmPayBudgetGLEntry_old()
			//: base()
		{
			if (m_vb6FormDefInstance is null)
			{
				if (m_InitializingDefInstance)
				{
					m_vb6FormDefInstance = this;
				}
				else
				{
					try
					{
						//For the start-up form, the first instance created is the default instance.
						if (!(System.Reflection.Assembly.GetExecutingAssembly().EntryPoint is null) && System.Reflection.Assembly.GetExecutingAssembly().EntryPoint.DeclaringType == this.GetType())
						{
							m_vb6FormDefInstance = this;
						}
					}
					catch
					{
					}
				}
			}
			//This call is required by the Windows Form Designer.
			InitializeComponent();
			
		}


		public clsAccessAllowed UserAccess
		{
			get
			{
				if (_UserAccess is null)
				{
					_UserAccess = new clsAccessAllowed();
				}
				return _UserAccess;
			}
			set
			{
				_UserAccess = value;
			}
		}

		private XArrayHelper mArr = null;

		private XArrayHelper _aVoucherDetails = null;
		private XArrayHelper aVoucherDetails
		{
			get
			{
				if (_aVoucherDetails is null)
				{
					_aVoucherDetails = new XArrayHelper();
				}
				return _aVoucherDetails;
			}
			set
			{
				_aVoucherDetails = value;
			}
		}

		private int mThisFormID = 0;

		private XArrayHelper mJVArr = null;

		private const string conPayrollComments = "Payroll";
		private const string conLeaveProvisionComments = "Leave Provision";
		private const string conIndemnityProvisionComments = "Indemnity Provision";

		private const int grdccAccountNo = 0;
		private const int grdccAccountName = 1;
		private const int grdccServiceCode = 2;
		private const int grdccAccountCode = 3;
		private const int grdccDepartmentCode = 4;
		private const int grdccPartyCode = 5;
		private const int grdccDebit = 6;
		private const int grdccCredit = 7;
		private const int grdccCCCode = 8;
		private const int grdccCCName = 9;
		private const int grdccAnalysis1 = 10;
		private const int grdccAnalysis2 = 11;
		private const int grdccAnalysis3 = 12;
		private const int grdccAnalysis4 = 13;
		private const int grdccAnalysisCd5 = 14;
		private const int grdccJvType = 15;
		private const int grdccLdgrCd = 16;
		private const int grdccCCCd = 17;
		private const int grdccComments = 18;
		private const int grdccProjectNo = 19;
		private const int grdmMaxCols = 19;

		private const int gccAccountNo = 0;
		private const int gccAccountName = 1;
		private const int gccServiceCode = 2;
		private const int gccAccountCode = 3;
		private const int gccDepartmentCode = 4;
		private const int gccPartyCode = 5;
		private const int gccDebit = 6;
		private const int gccCredit = 7;
		private const int gccCCNo = 8;
		private const int gccCCName = 9;
		private const int gccAnalysisCd1 = 10;
		private const int gccAnalysisCd2 = 11;
		private const int gccAnalysisCd3 = 12;
		private const int gccAnalysisCd4 = 13;
		private const int gccAnalysisCd5 = 14;
		private const int gccJvType = 15;
		private const int gccLdgrCd = 16;
		private const int gccCCCd = 17;
		private const int gccComments = 18;
		private const int gccProjectNo = 19;
		private const int mMaxCols = 19;

		private int mComCd = 0;
		private int mBudgetCd = 0;

		private const int gccBillCd = 0;
		private const int gccBillNo = 1;
		private const int gccBillName = 2;
		private const int gccLdgrNo = 3;
		private const int gccLdgrName = 4;
		//Private Const gccCCNo As Integer = 5
		//Private Const gccCCName As Integer = 6
		//Private Const gccApplyCostCenter As Integer = 7

		private const int mMaxArrayCol = 6;

		private DataSet rsLedgerCodeList = null;
		private DataSet rsCCCodeList = null;
		private bool mFirstGridFocus = false;
		private clsToolbar oThisFormToolBar = null;

		private string mSearchValue = "";
		private SystemVariables.SystemFormModes mCurrentFormMode = (SystemVariables.SystemFormModes) 0;

		public string SearchValue
		{
			get
			{
				return mSearchValue;
			}
			set
			{
				mSearchValue = value;
			}
		}



		public int ThisFormId
		{
			get
			{
				return mThisFormID;
			}
			set
			{
				mThisFormID = value;
			}
		}


		private void cmdClose_Click()
		{
			this.Close();
		}

		private void Form_Activated(Object eventSender, EventArgs eventArgs)
		{
			if (ActivateHelper.myActiveForm != eventSender)
			{
				ActivateHelper.myActiveForm = (Form) eventSender;
				SystemMenu.SetMeCurrentInWindowList(Conversion.Str(this.Handle.ToInt32()));
			}
		}

		private void Form_KeyDown(Object eventSender, KeyEventArgs eventArgs)
		{
			int KeyCode = (int) eventArgs.KeyCode;
			int Shift = ((int) eventArgs.KeyData) / 65536;
			try
			{

				if (this.ActiveControl.Name == "grdVoucherDetails")
				{
					if (KeyCode == 13 || KeyCode == 113)
					{
						return;
					}
					else if (KeyCode == 222)
					{  //'for "'"
						KeyCode = 0;
						return;
					}
					if (Shift == 0)
					{
						if (grdVoucherDetails.Col == gccCCNo)
						{
							//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
							if (((TriState) ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetSystemPreferenceSetting("allow_alpha_numeric_ldgr_no"))) == TriState.False)
							{
								if ((KeyCode == 8) || (KeyCode == 46) || (KeyCode == 27))
								{
									//
								}
								else if ((KeyCode >= 48 && KeyCode <= 57) || (KeyCode >= 96 && KeyCode <= 105) || (KeyCode == 190) || (KeyCode == 110))
								{ 
									//
								}
								else
								{
									KeyCode = 0;
								}
							}
						}
					}
				}

				if (KeyCode == 13)
				{
					SendKeys.Send("{TAB}");
					return;
				}
				else if (KeyCode == 27)
				{ 
					this.Close();
					return;
				}

				SystemForms.SystemFormKeyDown(this, ref KeyCode, Shift, this.ActiveControl.Name);
			}
			finally
			{
				eventArgs.Handled = KeyCode == 0;
			}
		}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2080
		private void Form_Load()
		{
			//Set the Grid Format

			this.Top = 0;
			this.Left = 0;

			mFirstGridFocus = true;
			//
			//'**--format & define the new toolbar
			oThisFormToolBar = new clsToolbar();
			oThisFormToolBar.AttachObject(this); //, tcbSystemForm

			oThisFormToolBar.ShowNewButton = false;
			oThisFormToolBar.ShowSaveButton = false;
			oThisFormToolBar.ShowDeleteButton = false;
			oThisFormToolBar.ShowPrintButton = true;
			oThisFormToolBar.ShowFindButton = false;
			oThisFormToolBar.ShowHelpButton = true;
			oThisFormToolBar.ShowPostButton = true;
			oThisFormToolBar.ShowExitButton = true;
			oThisFormToolBar.BeginExitButtonWithGroup = true;
			oThisFormToolBar.DisableHelpButton = true;

			this.WindowState = FormWindowState.Maximized;

			int mGLMethod = ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetSystemPreferenceSetting("pay_gl_entry_method"));

			//define voucher grid columns
			SystemGrid.DefineSystemVoucherGrid(grdVoucherDetails, false, false, false, (0xFFFFFF).ToString(), (0x0).ToString(), true, true, C1.Win.C1TrueDBGrid.MarqueeEnum.HighlightRow, 2.4f, 1.4f, "&HB4D9F8", "&HB4D9F8", 280);
			//define voucher grid columns
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Account No.", 1200, false, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false);
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Account Name", 3000, false);
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Service Code", 1600, false, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, false);
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Account Code", 1600, false, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, false);
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Depart Code", 1600, false, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, false);
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Part Code", 1600, false, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, false);
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Debit", 1500, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Far);
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Credit", 1500, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Far);
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Cost Code", 1200, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false);
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Cost Name", 1500, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near);
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Analysis1", 1200, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, true, false, false, false, false, 100, "", "", false, "", 0, false, 2202);
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Analysis2", 1200, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, true, false, false, false, false, 100, "", "", false, "", 0, false, 2203);
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Analysis3", 1200, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, true, false, false, false, false, 100, "", "", false, "", 0, false, 2204);
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Analysis4", 1200, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, true, false, false, false, false, 100, "", "", false, "", 0, false, 2205);
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Analysis5", 1200, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, true, false, false, false, false, 100, "", "", false, "", 0, false, 2206);
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "JVType", 10, false, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, false);

			SystemProcedure.SetLabelCaption(this);

			//.HoldFields
			//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBGrid property grdVoucherDetails.Array was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			grdVoucherDetails.setArray(aVoucherDetails);
			//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
			grdVoucherDetails.Splits[0].DisplayColumns[grdccAccountNo].AllowSizing = true;
			//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
			grdVoucherDetails.Splits[0].DisplayColumns[grdccAccountName].AllowSizing = true;
			//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
			grdVoucherDetails.Splits[0].DisplayColumns[grdccPartyCode].AllowSizing = true;
			//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
			grdVoucherDetails.Splits[0].DisplayColumns[grdccServiceCode].AllowSizing = true;
			//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
			grdVoucherDetails.Splits[0].DisplayColumns[grdccAccountCode].AllowSizing = true;
			//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
			grdVoucherDetails.Splits[0].DisplayColumns[grdccDepartmentCode].AllowSizing = true;
			//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
			grdVoucherDetails.Splits[0].DisplayColumns[grdccDebit].AllowSizing = true;
			//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
			grdVoucherDetails.Splits[0].DisplayColumns[grdccCredit].AllowSizing = true;
			//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
			grdVoucherDetails.Splits[0].DisplayColumns[grdccCCCode].AllowSizing = true;
			//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
			grdVoucherDetails.Splits[0].DisplayColumns[grdccCCName].AllowSizing = true;
			//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
			grdVoucherDetails.Splits[0].DisplayColumns[grdccAnalysis1].AllowSizing = true;
			//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
			grdVoucherDetails.Splits[0].DisplayColumns[grdccAnalysis2].AllowSizing = true;
			//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
			grdVoucherDetails.Splits[0].DisplayColumns[grdccAnalysis3].AllowSizing = true;
			//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
			grdVoucherDetails.Splits[0].DisplayColumns[grdccAnalysis4].AllowSizing = true;
			//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
			grdVoucherDetails.Splits[0].DisplayColumns[grdccJvType].AllowSizing = true;
			grdVoucherDetails.Enabled = true;


			aVoucherDetails.RedimXArray(new int[]{-1, -1}, new int[]{-1, -1});
			grdVoucherDetails.Rebind(true);
		}

		//'' For Print
		public void PrintReport(int pEntryId = 0)
		{
			C1.Win.C1TrueDBGrid.PrintInfo withVar = null;
			withVar = grdVoucherDetails.PrintInfo;
			//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.PrintInfo property withVar.PreviewCaption was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			withVar.setPreviewCaption(" Payroll GL Entry ");
			//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.PrintInfo property withVar.PreviewInitZoom was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			withVar.setPreviewInitZoom(100);

			withVar.PageSettings.Margins.Left = Convert.ToInt32(0.1d);
			withVar.PageSettings.Margins.Right = Convert.ToInt32(0.1d);

			withVar.PageFooter = "\\p of page \\P";
			//UPGRADE_WARNING: (2065) TrueOleDBGrid80.PrintInfo method withVar.PrintPreview has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2065
			withVar.PrintPreview();
		}

		public bool Post()
		{
			//UPGRADE_WARNING: (1068) GetSystemPreferenceSetting() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			int mGLEntryMethod = ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetSystemPreferenceSetting("pay_gl_entry_method"));
			//UPGRADE_WARNING: (1068) txtDPayrollDate.DisplayText of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			string mMonthEndDate = ReflectionHelper.GetPrimitiveValue<string>(txtDPayrollDate.DisplayText);
			GenerateTextFile(mGLEntryMethod);
			return false;
		}

		public object GenerateTextFile(int pGLMethod)
		{
			try
			{
				int cnt = 0;
				string mFileName = "";
				string mCurrencyCd = "";
				double mExchRate = 0;
				string mMonthName = "";

				mFileName = SystemVariables.gPayrollGLFilePath + SystemVariables.gDatabaseName + "_" + DateTimeFormatInfo.CurrentInfo.GetMonthName(ReflectionHelper.GetPrimitiveValue<System.DateTime>(txtDPayrollDate.Value).Month) + "_" + ReflectionHelper.GetPrimitiveValue<System.DateTime>(txtDPayrollDate.Value).Year.ToString() + ".txt"; //Test.txt"


				mMonthName = "Salary For the " + DateTimeFormatInfo.CurrentInfo.GetAbbreviatedMonthName(ReflectionHelper.GetPrimitiveValue<System.DateTime>(txtDPayrollDate.Value).Month) + " " + ReflectionHelper.GetPrimitiveValue<System.DateTime>(txtDPayrollDate.Value).Year.ToString();
				FileSystem.FileClose(1);
				FileSystem.FileOpen(1, mFileName, OpenMode.Output, OpenAccess.Default, OpenShare.Default, -1);
				int tempForEndVar = aVoucherDetails.GetLength(0) - 1;
				for (cnt = 0; cnt <= tempForEndVar; cnt++)
				{
					if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("enable_payroll_project")))
					{
						//''          Print #1, InsertDetail1(Format(txtDPayrollDate.Value, "YYYYMMDD"), cnt + 1, aVoucherDetails(cnt, grdccAnalysis2) _
						//'''                    , aVoucherDetails(cnt, grdccAnalysis3), aVoucherDetails(cnt, grdccAnalysis1), aVoucherDetails(cnt, grdccAnalysis4), mMonthName, "JVGEN" _
						//'''                    , IIf(aVoucherDetails(cnt, grdccDebit) > 0, aVoucherDetails(cnt, grdccDebit), (aVoucherDetails(cnt, grdccCredit) * -1)))
					}
					else
					{
						//''           Print #1, InsertDetail2(Format(txtDPayrollDate.Value, "YYYYMMDD"), aVoucherDetails(cnt, grdccAnalysis1) _
						//'''                    , aVoucherDetails(cnt, grdccAnalysis2), aVoucherDetails(cnt, grdccAnalysis3), aVoucherDetails(cnt, grdccAnalysis4) _
						//'''                    , aVoucherDetails(cnt, grdccAnalysisCd5), mMonthName, "JV2500" _
						//'''                    , IIf(aVoucherDetails(cnt, grdccDebit) > 0, aVoucherDetails(cnt, grdccDebit), (aVoucherDetails(cnt, grdccCredit) * -1)))
					}
				}
				FileSystem.FileClose(1);

				MessageBox.Show("File Generated Successfully", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			catch (System.Exception excep)
			{
				FileSystem.FileClose(1);
				MessageBox.Show(excep.Message, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
			}

			return null;
		}


		private void Command1_Click(Object eventSender, EventArgs eventArgs)
		{

			frmPayGLVoucherView mForm = null;
			string mGenerateDate = "";

			//UPGRADE_WARNING: (1068) txtDPayrollDate.DisplayText of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			string mMonthEndDate = ReflectionHelper.GetPrimitiveValue<string>(txtDPayrollDate.DisplayText);

			SystemVariables.gConn.BeginTransaction();

			if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("HR_Budget")))
			{
				if (GetPayrollEntryInfoIntoArray(mMonthEndDate))
				{
					ClubVoucherEntry();
					aVoucherDetails = mArr;
					//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBGrid property grdVoucherDetails.Array was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					grdVoucherDetails.setArray(aVoucherDetails);
					CalculateTotal();
					grdVoucherDetails.Rebind(true);
					grdVoucherDetails.Refresh();
				}
				else
				{
					//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					SystemVariables.gConn.RollbackTrans();
					return;
				}
			}

			//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.CommitTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			SystemVariables.gConn.CommitTrans();

		}

		private void Form_Closed(Object eventSender, EventArgs eventArgs)
		{
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{

				SystemMenu.RemoveMeFromWindowList(Conversion.Str(this.Handle.ToInt32()));

				UserAccess = null;
				rsLedgerCodeList = null;
				rsCCCodeList = null;

				oThisFormToolBar = null;
				frmPayGenerateGLEntry.DefInstance = null;
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		public void AddRecord()
		{
			try
			{

				int cnt = 0;

				mSearchValue = "";
				aVoucherDetails.RedimXArray(new int[]{-1, -1}, new int[]{-1, -1});
				grdVoucherDetails.Rebind(true);
			}
			catch (System.Exception excep)
			{
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, excep.Message, Convert.ToString(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Master_Table_Name"]), "AddRecord");
			}


		}

		private bool GetPayrollEntryInfoIntoArray(string pVoucherDate)
		{
			bool result = false;
			string mysql = "";
			object mReturnValue = null;
			SqlDataReader rsTempRec = null;
			DataSet rsTempRec1 = null;
			string mPayrollDate = ""; // this variable is declared bcoz the month is closed and pay_payroll_generate_history has been updated for next month
			string mSecondLastPayrollDate = "";
			string mLdgrCd = "";
			string mLdgrNo = "";
			string mLdgrName = "";
			string mProjectNo = "";

			string mCostCd = "";
			string mCostNo = "";
			string mCostName = "";

			string mAccountCd = "";
			string mServiceCd = "";
			string mPartyCd = "";
			string mDepartCd = "";

			string mAnalysisCd1 = "";
			string mAnalysisCd2 = "";
			string mAnalysisCd3 = "";
			string mAnalysisCd4 = "";
			string mAnalysisCd5 = "";

			decimal mBalanceAmt = 0;
			decimal mBalanceSAmt = 0;
			string mDrCr = "";




			int mJvType = 0;
			bool mEnableProject = false;
			int cnt = 0;
			double mAmount = 0;
			int pGLMethod = 0;
			int mMonthDays = 0;

			try
			{

				mArr = new XArrayHelper();

				mPayrollDate = DateTimeHelper.ToString(DateTime.Parse(pVoucherDate)); //DateAdd("m", -1, Format(GetPayrollGenerateDate, "mm-yyyy"))
				mSecondLastPayrollDate = DateTimeHelper.ToString(DateTime.Parse(pVoucherDate).AddDays(1).AddMonths(-1));
				//UPGRADE_WARNING: (1068) GetSystemPreferenceSetting() of type Variant is being forced to bool. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mEnableProject = ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("enable_payroll_project"));
				mMonthDays = ((int) DateAndTime.DateDiff("d", DateTime.Parse(mSecondLastPayrollDate), DateTime.Parse(mPayrollDate), FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1)) + 1;

				if (SystemProcedure2.IsItEmpty(txtCompanyCode.Text, SystemVariables.DataType.NumberType))
				{
					mComCd = 0;
				}

				if (!SystemProcedure2.IsItEmpty(txtBudgetCode.Text, SystemVariables.DataType.NumberType))
				{
					mysql = " select Budget_Cd from Pay_Budget where Budget_No = " + txtBudgetCode.Text;
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (!Convert.IsDBNull(mReturnValue))
					{
						mBudgetCd = ReflectionHelper.GetPrimitiveValue<int>(mReturnValue);
					}
					else
					{
						MessageBox.Show("Please select budget code.", "Budget GL", MessageBoxButtons.OK, MessageBoxIcon.Information);
						return result;
					}
				}
				else
				{
					MessageBox.Show("Please select budget code.", "Budget GL", MessageBoxButtons.OK, MessageBoxIcon.Information);
					return result;
				}

				mJvType = 0;
				//UPGRADE_WARNING: (1068) GetSystemPreferenceSetting() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				pGLMethod = ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetSystemPreferenceSetting("pay_gl_entry_method"));

				if (pGLMethod != 0)
				{
					mysql = " select  pemp.emp_cd ,pbt.bill_cd , pbt.bill_type_id     , glinfo.ldgr_cd    , gl_ledger.ldgr_no , cc.cost_no , l_ldgr_name ldgr_name";
					mysql = mysql + "    , l_cost_name cost_name , glinfo.cost_cd    , amount lc_amount";
					mysql = mysql + "  , glinfo.analysis1_cd  , pbpd.analysis2_cd , pbpd.analysis3_cd , pbpd.analysis4_cd , pbpd.analysis5_cd , 0 as PHC";
					mysql = mysql + " from Pay_Budget_Payroll_Details pbpd";
					mysql = mysql + " inner join pay_billing_type pbt on pbpd.bill_cd = pbt.bill_cd";
					mysql = mysql + " inner join Pay_Budget_Category pbc on pbc.line_no = pbpd.Budget_Category_Line_No";
					mysql = mysql + " inner join Pay_Employee pemp on pemp.emp_cd = pbpd.emp_cd ";
					//mySQL = mySQL & " inner join Pay_Department pd on pd.Dept_Cd = pemp.Dept_Cd"
					//mySQL = mySQL & " inner join Pay_Budget_Category pbc on pbc.Head_Count_Category_Cd = phc.Head_Count_Category_Cd"
					mysql = mysql + " left join pay_employee_gl_details glinfo    on pbpd.emp_cd = glinfo.emp_cd  and pbpd.bill_cd = glinfo.bill_cd";
					mysql = mysql + " left join gl_ledger on glinfo.ldgr_cd = gl_ledger.ldgr_cd";
					mysql = mysql + " left join gl_cost_centers cc on glinfo.cost_cd = cc.cost_cd";
					mysql = mysql + " Where  pbc.Budget_cd = " + mBudgetCd.ToString();
					mysql = mysql + " and pemp.comp_cd = " + mComCd.ToString();
					//mySQL = mySQL & " and pemp.emp_no not in (select isnull(phc1.analysis4_cd,0) from Pay_Head_Count phc1 inner join Pay_Budget_Details pbd on pbd.Line_No = phc1.Budget_Details_Line_No"
					//mySQL = mySQL & "                  where pbd.Budget_Period <= '" & mPayrollDate & "' and  pbd.Budget_Head_Count < 0)"
					mysql = mysql + " group by pemp.emp_cd ,pbt.bill_cd , pbt.bill_type_id    , glinfo.ldgr_cd , amount";
					mysql = mysql + " , gl_ledger.ldgr_no , cc.cost_no , l_ldgr_name    , l_cost_name , glinfo.cost_cd    ,glinfo.analysis1_cd  , pbpd.analysis2_cd";
					mysql = mysql + " , pbpd.analysis3_cd , pbpd.analysis4_cd , pbpd.analysis5_cd";

					mysql = mysql + " Union All";
					mysql = mysql + " select 0, 1 , 51  , 391  , 1 , null , '' ldgr_name";
					mysql = mysql + "  , '' cost_name , ''    , sum(phc.Total_Budget_Salary) lc_amount";
					mysql = mysql + "   ,'40110100' as analysis1_cd , analysis2_cd , analysis3_cd , analysis4_cd , analysis5_cd , phc.Head_Count_Cd  as PHC";
					mysql = mysql + " from Pay_Head_Count phc ";
					mysql = mysql + " left outer join Pay_Budget_Details pbd on pbd.Line_No = phc.Budget_Details_Line_No ";
					mysql = mysql + " inner join Pay_Head_Count_Category phcc on phcc.Head_Count_Category_Cd = phc.Head_Count_Category_Cd";
					mysql = mysql + " inner join Pay_Budget_Category pbc on pbc.Head_Count_Category_Cd = phcc.Head_Count_Category_Cd";
					mysql = mysql + " inner join Pay_Department pd on pd.Dept_Cd = phcc.Dept_Cd";
					mysql = mysql + " where (phc.Is_Budgeted = 1 or phc.Head_Count_Status = 3)";
					mysql = mysql + " and pbc.Budget_cd = " + mBudgetCd.ToString();
					mysql = mysql + " and (pbd.Budget_Period <= '" + mPayrollDate + "'  or pbd.Budget_Period is null) and (pbd.Budget_Head_Count > 0 or pbd.Budget_Head_Count is null) and isnull(phc.analysis4_cd,'') <> ''";
					mysql = mysql + " group by head_count_Cd , analysis1_cd  , analysis2_cd";
					mysql = mysql + " , analysis3_cd , analysis4_cd , analysis5_cd , phc.Head_Count_Status  ,pbc.Budget_Cd";
				}
				else
				{
					mysql = "";
				}

				if (mysql != "")
				{
					SqlCommand sqlCommand = new SqlCommand(mysql, SystemVariables.gConn);
					rsTempRec = sqlCommand.ExecuteReader();

					if (rsTempRec.Read())
					{
						do 
						{
							mJvType = 1;
							if (Convert.IsDBNull(rsTempRec["ldgr_cd"]) && pGLMethod != 3)
							{
								DisplayError(Convert.ToInt32(rsTempRec["emp_cd"]));
								throw new Exception();
							}
							else
							{
								if (pGLMethod == 1 || pGLMethod == 2)
								{
									mLdgrCd = Convert.ToString(rsTempRec["ldgr_cd"]);
									mLdgrNo = Convert.ToString(rsTempRec["ldgr_no"]);
									mLdgrName = Convert.ToString(rsTempRec["ldgr_name"]);
									//mProjectNo = .Fields("project_no") & ""
									mAccountCd = "";
									mServiceCd = "";
									mPartyCd = "";
									mDepartCd = "";
								}
								if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("cost_center")))
								{
									if (Convert.IsDBNull(rsTempRec["cost_cd"]))
									{
										DisplayError(Convert.ToInt32(rsTempRec["emp_dept_cd"]));
										throw new Exception();
									}
									else
									{
										mCostCd = Convert.ToString(rsTempRec["cost_cd"]);
										mCostNo = Convert.ToString(rsTempRec["cost_no"]);
										mCostName = Convert.ToString(rsTempRec["cost_name"]);
									}
								}
								else
								{
									mCostCd = "";
									mCostNo = "";
									mCostName = "";
								}
								if (pGLMethod != 3)
								{
									if (!SystemProcedure2.IsItEmpty(rsTempRec["analysis1_Cd"], SystemVariables.DataType.StringType))
									{
										mAnalysisCd1 = Convert.ToString(rsTempRec["analysis1_Cd"]);
									}
									else
									{
										mAnalysisCd1 = "";
									}
									if (!SystemProcedure2.IsItEmpty(rsTempRec["analysis2_Cd"], SystemVariables.DataType.StringType))
									{
										mAnalysisCd2 = Convert.ToString(rsTempRec["analysis2_Cd"]);
									}
									else
									{
										mAnalysisCd2 = "";
									}
									if (!SystemProcedure2.IsItEmpty(rsTempRec["analysis3_Cd"], SystemVariables.DataType.StringType))
									{
										mAnalysisCd3 = Convert.ToString(rsTempRec["analysis3_Cd"]);
									}
									else
									{
										mAnalysisCd3 = "";
									}
									if (!SystemProcedure2.IsItEmpty(rsTempRec["analysis4_Cd"], SystemVariables.DataType.StringType))
									{
										mAnalysisCd4 = Convert.ToString(rsTempRec["analysis4_Cd"]);
									}
									else
									{
										mAnalysisCd4 = "";
									}
									if (!SystemProcedure2.IsItEmpty(rsTempRec["analysis5_Cd"], SystemVariables.DataType.StringType))
									{
										mAnalysisCd5 = Convert.ToString(rsTempRec["analysis5_Cd"]);
									}
									else
									{
										mAnalysisCd5 = "";
									}
								}
							}
							if (pGLMethod == 3)
							{
								mAccountCd = (Convert.IsDBNull(rsTempRec["analysis1_Cd"])) ? "" : Convert.ToString(rsTempRec["analysis1_Cd"]);
								mServiceCd = (Convert.IsDBNull(rsTempRec["analysis3_Cd"])) ? "" : Convert.ToString(rsTempRec["analysis3_Cd"]);
								mPartyCd = (Convert.IsDBNull(rsTempRec["analysis2_Cd"])) ? "" : Convert.ToString(rsTempRec["analysis2_Cd"]);
								mDepartCd = (Convert.IsDBNull(rsTempRec["analysis4_Cd"])) ? "" : Convert.ToString(rsTempRec["analysis4_Cd"]);
								mAnalysisCd1 = mAccountCd;
								mAnalysisCd2 = mPartyCd;
								mAnalysisCd3 = mServiceCd;
								mAnalysisCd4 = mDepartCd;
								mAnalysisCd5 = "";
							}
							if (Convert.ToDouble(rsTempRec["bill_type_id"]) == 51)
							{
								mDrCr = "D";
							}
							else
							{
								mDrCr = "C";
							}

							if (mDrCr == "D")
							{
								InsertIntoArray(cnt, mLdgrNo, mLdgrName, Convert.ToDecimal(rsTempRec["lc_amount"]), 0, mCostNo, mCostName, mLdgrCd, mCostCd, conPayrollComments, mServiceCd, mPartyCd, mAccountCd, mDepartCd, mAnalysisCd1, mAnalysisCd2, mJvType, "", mAnalysisCd3, mAnalysisCd4, mAnalysisCd5);
								mBalanceSAmt = Convert.ToDecimal(rsTempRec["lc_amount"]);
								mBalanceAmt = (decimal) (((double) mBalanceAmt) + Convert.ToDouble(rsTempRec["lc_amount"]));
							}
							else
							{
								InsertIntoArray(cnt, mLdgrNo, mLdgrName, 0, Convert.ToDecimal(rsTempRec["lc_amount"]), mCostNo, mCostName, mLdgrCd, mCostCd, conPayrollComments, mServiceCd, mPartyCd, mAccountCd, mDepartCd, mAnalysisCd1, mAnalysisCd2, mJvType, "", mAnalysisCd3, mAnalysisCd4, mAnalysisCd5);
								mBalanceSAmt = (decimal) (Convert.ToDouble(rsTempRec["lc_amount"]) * -1);
								mBalanceAmt = (decimal) (((double) mBalanceAmt) - Convert.ToDouble(rsTempRec["lc_amount"]));
							}

							cnt++;


							//''''Salary Control
							if (pGLMethod != 0)
							{
								if (Convert.ToDouble(rsTempRec["emp_cd"]) != 0)
								{
									mysql = "select pemp.emp_cd ,pbt.bill_cd , pbt.bill_type_id ";
									mysql = mysql + "  , gltab.ldgr_cd , gltab.cost_cd ";
									mysql = mysql + "  , gl_ledger.ldgr_no , cc.cost_no ";
									if (SystemVariables.gPreferedLanguage == SystemVariables.Language.English)
									{
										mysql = mysql + ", l_ldgr_name ldgr_name, l_cost_name cost_name";
									}
									else
									{
										mysql = mysql + ", a_ldgr_name ldgr_name, a_cost_name cost_name ";
									}
									mysql = mysql + "  , analysis2_cd  ,  analysis3_cd ,  analysis4_cd ,  analysis5_cd";
									if (mEnableProject)
									{
										mysql = mysql + " , gp.project_no as analysis1_cd";
									}
									else
									{
										mysql = mysql + " , analysis1_cd";
									}
									mysql = mysql + "  from pay_billing_type pbt";
									mysql = mysql + "  left join pay_employee_gl_details gltab on pbt.bill_cd = gltab.bill_cd ";
									mysql = mysql + "  left join pay_employee pemp on pemp.emp_cd = gltab.emp_cd ";
									mysql = mysql + "  left join gl_ledger on gltab.ldgr_cd = gl_ledger.ldgr_cd ";
									mysql = mysql + "  left join gl_cost_centers cc on gltab.cost_cd = cc.cost_cd   ";
									if (mEnableProject)
									{
										mysql = mysql + " left join gl_projects gp on gp.project_cd = pemp.Default_project";
									}
									mysql = mysql + "  where pbt.bill_cd = 10 and pemp.emp_cd = " + Convert.ToString(rsTempRec["emp_cd"]);
									mysql = mysql + " group by pemp.emp_cd, pbt.bill_cd, pbt.bill_type_id , gltab.ldgr_cd , gltab.cost_cd  ";
									mysql = mysql + " , gl_ledger.ldgr_no , cc.cost_no , l_ldgr_name, l_cost_name , a_ldgr_name , a_cost_name";
									mysql = mysql + "  , analysis2_cd  ,  analysis3_cd ,  analysis4_cd ,  analysis5_cd   ";
									if (mEnableProject)
									{
										mysql = mysql + " , gp.project_no";
									}
									else
									{
										mysql = mysql + " , analysis1_cd";
									}
								}
								else
								{
									mysql = "  select 0, 10 , 52   , 391 ldgr_cd , NULL cost_cd  ";
									mysql = mysql + " , 1 ldgr_no , NULL cost_no , 'Default' ldgr_name, NULL cost_name  , analysis2_cd  ,  analysis3_cd";
									mysql = mysql + " ,  analysis4_cd ,  analysis5_cd , 10350600 as analysis1_cd";
									mysql = mysql + " from Pay_Head_Count phc";
									mysql = mysql + "  Where phc.Head_Count_Cd = " + Convert.ToString(rsTempRec["PHC"]);
								}
							}
							else
							{
								mysql = "";
							}

							if (mysql != "")
							{
								rsTempRec1 = new DataSet();
								SqlDataAdapter adap_2 = new SqlDataAdapter(mysql, SystemVariables.gConn);
								rsTempRec1.Tables.Clear();
								adap_2.Fill(rsTempRec1);

								if (rsTempRec1.Tables[0].Rows.Count != 0)
								{
									mJvType = 1;
									if (rsTempRec1.Tables[0].Rows[0].IsNull("ldgr_cd") && (pGLMethod == 1 || pGLMethod == 2))
									{
										DisplayError(Convert.ToInt32(rsTempRec1.Tables[0].Rows[0]["emp_cd"]));
										throw new Exception();
									}
									else
									{
										if (pGLMethod != 3)
										{
											mLdgrCd = Convert.ToString(rsTempRec1.Tables[0].Rows[0]["ldgr_cd"]);
											mLdgrNo = Convert.ToString(rsTempRec1.Tables[0].Rows[0]["ldgr_no"]);
											mLdgrName = Convert.ToString(rsTempRec1.Tables[0].Rows[0]["ldgr_name"]);
											mAccountCd = "";
											mServiceCd = "";
											mPartyCd = "";
											mDepartCd = "";
											if (!SystemProcedure2.IsItEmpty(rsTempRec1.Tables[0].Rows[0]["analysis1_Cd"], SystemVariables.DataType.StringType))
											{
												mAnalysisCd1 = Convert.ToString(rsTempRec1.Tables[0].Rows[0]["analysis1_Cd"]);
											}
											else
											{
												mAnalysisCd1 = "";
											}
											if (!SystemProcedure2.IsItEmpty(rsTempRec1.Tables[0].Rows[0]["analysis2_Cd"], SystemVariables.DataType.StringType))
											{
												mAnalysisCd2 = Convert.ToString(rsTempRec1.Tables[0].Rows[0]["analysis2_Cd"]);
											}
											else
											{
												mAnalysisCd2 = "";
											}
											if (!SystemProcedure2.IsItEmpty(rsTempRec1.Tables[0].Rows[0]["analysis3_Cd"], SystemVariables.DataType.StringType))
											{
												mAnalysisCd3 = Convert.ToString(rsTempRec1.Tables[0].Rows[0]["analysis3_Cd"]);
											}
											else
											{
												mAnalysisCd3 = "";
											}
											if (!SystemProcedure2.IsItEmpty(rsTempRec1.Tables[0].Rows[0]["analysis4_Cd"], SystemVariables.DataType.StringType))
											{
												mAnalysisCd4 = Convert.ToString(rsTempRec1.Tables[0].Rows[0]["analysis4_Cd"]);
											}
											else
											{
												mAnalysisCd4 = "";
											}
											if (!SystemProcedure2.IsItEmpty(rsTempRec1.Tables[0].Rows[0]["analysis5_Cd"], SystemVariables.DataType.StringType))
											{
												mAnalysisCd5 = Convert.ToString(rsTempRec1.Tables[0].Rows[0]["analysis5_Cd"]);
											}
											else
											{
												mAnalysisCd5 = "";
											}
										}
										else
										{
											mAccountCd = (rsTempRec1.Tables[0].Rows[0].IsNull("analysis1_Cd")) ? "" : Convert.ToString(rsTempRec1.Tables[0].Rows[0]["analysis1_Cd"]);
											mServiceCd = (rsTempRec1.Tables[0].Rows[0].IsNull("analysis3_Cd")) ? "" : Convert.ToString(rsTempRec1.Tables[0].Rows[0]["analysis3_Cd"]);
											mPartyCd = (rsTempRec1.Tables[0].Rows[0].IsNull("analysis2_Cd")) ? "" : Convert.ToString(rsTempRec1.Tables[0].Rows[0]["analysis2_Cd"]);
											mDepartCd = (rsTempRec1.Tables[0].Rows[0].IsNull("analysis4_Cd")) ? "" : Convert.ToString(rsTempRec1.Tables[0].Rows[0]["analysis4_Cd"]);
											mAnalysisCd1 = mAccountCd;
											mAnalysisCd2 = mPartyCd;
											mAnalysisCd3 = mServiceCd;
											mAnalysisCd4 = mDepartCd;
											mAnalysisCd5 = "";
										}
										if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("cost_center")))
										{
											if (rsTempRec1.Tables[0].Rows[0].IsNull("cost_cd"))
											{
												DisplayError(Convert.ToInt32(rsTempRec1.Tables[0].Rows[0]["emp_dept_cd"]));
											}
											else
											{
												mCostCd = Convert.ToString(rsTempRec1.Tables[0].Rows[0]["cost_cd"]);
												mCostNo = Convert.ToString(rsTempRec1.Tables[0].Rows[0]["cost_no"]);
												mCostName = Convert.ToString(rsTempRec1.Tables[0].Rows[0]["cost_name"]);
											}
										}
										else
										{
											mCostCd = "";
											mCostNo = "";
											mCostName = "";
										}
									}

									if (mBalanceSAmt > 0)
									{
										mDrCr = "C";
									}
									else
									{
										mDrCr = "D";
									}

									if (mDrCr == "D")
									{
										InsertIntoArray(cnt, mLdgrNo, mLdgrName, (decimal) Math.Abs((double) mBalanceSAmt), 0, mCostNo, mCostName, mLdgrCd, mCostCd, conPayrollComments, mServiceCd, mPartyCd, mAccountCd, mDepartCd, mAnalysisCd1, mAnalysisCd2, mJvType, "", mAnalysisCd3, mAnalysisCd4, mAnalysisCd5);
									}
									else
									{
										InsertIntoArray(cnt, mLdgrNo, mLdgrName, 0, (decimal) Math.Abs((double) mBalanceSAmt), mCostNo, mCostName, mLdgrCd, mCostCd, conPayrollComments, mServiceCd, mPartyCd, mAccountCd, mDepartCd, mAnalysisCd1, mAnalysisCd2, mJvType, "", mAnalysisCd3, mAnalysisCd4, mAnalysisCd5);
									}

									cnt++;
								}
								else
								{
									DisplayError(Convert.ToInt32(rsTempRec["bill_cd"]));
									throw new Exception();
								}
							}

							mBalanceAmt = 0;
						}
						while(rsTempRec.Read());

						rsTempRec.Close();
					}
				}
				double mDR = 0;
				double mCr = 0;
				int tempForEndVar = mArr.GetLength(0) - 1;
				for (cnt = 0; cnt <= tempForEndVar; cnt++)
				{
					mDR += Convert.ToDouble(mArr.GetValue(cnt, gccDebit));
					mCr += Convert.ToDouble(mArr.GetValue(cnt, gccCredit));
				}

				mysql = "select ( " + Math.Round((double) (mMonthDays / 365d), 3).ToString() + " *  case when DATEDIFF(D,pemp.Date_Of_Joining,'" + mPayrollDate + "') > (peld.Leave_Switch_Over_Period*365) then (peld.Leave_Days_After_SOP/peld.Working_Days_Per_Month_After_SOP) else (peld.Leave_Days_Before_SOP/peld.Working_Days_Per_Month_Before_SOP) end ) *  (dbo.PayGetBudgetLeaveSalary(peld.emp_cd ,1) + dbo.PayGetBudgetCommission(phc.analysis4_cd ,'" + mPayrollDate + "' )) * -1 as lc_Amount";
				mysql = mysql + " , gltab.ldgr_cd, gltab.cost_cd , gltab.emp_cd as emp_dept_cd   , gl_ledger.ldgr_no , cc.cost_no , l_ldgr_name ldgr_name, l_cost_name cost_name";
				mysql = mysql + " , 1 as sorder ,''  as default_project  , gltab.analysis1_cd  as project_no   , gltab.analysis2_cd , gltab.analysis3_cd , gltab.analysis4_cd";
				mysql = mysql + " , isnull(gltab.analysis5_cd,'') as analysis5_cd , 0 as pay_hours , 0 as payHours";
				mysql = mysql + " from pay_employee pemp";
				mysql = mysql + " inner join Pay_Head_Count phc on phc.Emp_Cd = pemp.Emp_Cd";
				mysql = mysql + " inner join Pay_Head_Count_Category phcc on phcc.Head_Count_Category_Cd = phc.Head_Count_Category_Cd";
				mysql = mysql + " inner join Pay_Budget_Category pbc on pbc.Head_Count_Category_Cd = phcc.Head_Count_Category_Cd";
				mysql = mysql + " inner join Pay_Budget pb on pb.Budget_Cd = pbc.Budget_Cd";
				mysql = mysql + " inner join Pay_Employee_Leave_Details  peld on peld.Emp_Cd = pemp.Emp_Cd";
				mysql = mysql + " inner join pay_employee_gl_details gltab on pemp.emp_cd = gltab.emp_cd";
				mysql = mysql + " left join gl_ledger on gltab.ldgr_cd = gl_ledger.ldgr_cd";
				mysql = mysql + " left join gl_cost_centers cc on gltab.cost_cd = cc.cost_cd";
				mysql = mysql + " inner join Pay_Leave pl on pl.Leave_Cd = peld.Leave_Cd";
				mysql = mysql + " Where pl.Leave_Type_Cd = 6 And (gltab.bill_cd = 5) and phc.Head_Count_Status = 2 and phc.Is_budgeted = 0 and pemp.comp_cd = " + mComCd.ToString();
				mysql = mysql + " and pemp.emp_no not in (select isnull(phc1.analysis4_cd,0) from Pay_Head_Count phc1 inner join Pay_Budget_Details pbd on pbd.Line_No = phc1.Budget_Details_Line_No";
				mysql = mysql + "                  where pbd.Budget_Period <= '" + mPayrollDate + "' and  pbd.Budget_Head_Count < 0)";
				mysql = mysql + " and pbc.Budget_cd = " + mBudgetCd.ToString();
				mysql = mysql + " Union All";
				mysql = mysql + " select    (" + Math.Round((double) (mMonthDays / 365d), 3).ToString() + " *  case when DATEDIFF(D,pemp.Date_Of_Joining,'" + mPayrollDate + "')>(peld.Leave_Switch_Over_Period*365) then (peld.Leave_Days_After_SOP/peld.Working_Days_Per_Month_After_SOP) else (peld.Leave_Days_Before_SOP/peld.Working_Days_Per_Month_Before_SOP) end ) *  (dbo.PayGetBudgetLeaveSalary(peld.emp_cd ,1) + dbo.PayGetBudgetCommission(phc.analysis4_cd ,'" + mPayrollDate + "' ))  as lc_Amount";
				mysql = mysql + " ,gltab.ldgr_cd, gltab.cost_cd , gltab.emp_cd as emp_dept_cd   , gl_ledger.ldgr_no , cc.cost_no , l_ldgr_name ldgr_name, l_cost_name cost_name";
				mysql = mysql + " , 1 as sorder ,''  as default_project  , gltab.analysis1_cd  as project_no   , gltab.analysis2_cd , gltab.analysis3_cd , gltab.analysis4_cd";
				mysql = mysql + " , isnull(gltab.analysis5_cd,'') as analysis5_cd , 0 as pay_hours , 0 as payHours";
				mysql = mysql + " from pay_employee pemp";
				mysql = mysql + " inner join Pay_Head_Count phc on phc.Emp_Cd = pemp.Emp_Cd";
				mysql = mysql + " inner join Pay_Head_Count_Category phcc on phcc.Head_Count_Category_Cd = phc.Head_Count_Category_Cd";
				mysql = mysql + " inner join Pay_Budget_Category pbc on pbc.Head_Count_Category_Cd = phcc.Head_Count_Category_Cd";
				mysql = mysql + " inner join Pay_Budget pb on pb.Budget_Cd = pbc.Budget_Cd";
				mysql = mysql + " inner join Pay_Employee_Leave_Details  peld on peld.Emp_Cd = pemp.Emp_Cd";
				mysql = mysql + " inner join pay_employee_gl_details gltab on pemp.emp_cd = gltab.emp_cd";
				mysql = mysql + " left join gl_ledger on gltab.ldgr_cd = gl_ledger.ldgr_cd";
				mysql = mysql + " left join gl_cost_centers cc on gltab.cost_cd = cc.cost_cd";
				mysql = mysql + " inner join Pay_Leave pl on pl.Leave_Cd = peld.Leave_Cd";
				mysql = mysql + " Where pl.Leave_Type_Cd = 6 And (gltab.bill_cd = 7) and phc.Head_Count_Status = 2 and phc.Is_budgeted = 0 and pemp.comp_cd = " + mComCd.ToString();
				mysql = mysql + " and pemp.emp_no not in (select isnull(phc1.analysis4_cd,0) from Pay_Head_Count phc1 inner join Pay_Budget_Details pbd on pbd.Line_No = phc1.Budget_Details_Line_No";
				mysql = mysql + "                  where pbd.Budget_Period <= '" + mPayrollDate + "' and  pbd.Budget_Head_Count < 0)";
				mysql = mysql + " and pbc.Budget_cd = " + mBudgetCd.ToString();
				mysql = mysql + " Union All";
				mysql = mysql + " select    (((" + Math.Round((double) (mMonthDays / 365d), 3).ToString() + " * 30)/26)* (abs(phc.Total_Budget_Salary) + dbo.PayGetBudgetCommission(phc.analysis4_cd ,'" + mPayrollDate + "' ))) * -1 as lc_Amount";
				mysql = mysql + " , 391 , NULL , phc.Head_Count_Cd as emp_dept_cd   , 1 , NULL , '' ldgr_name, '' cost_name";
				mysql = mysql + " , 1 as sorder ,''  as default_project  , 25120200  as project_no   , phc.analysis2_cd , phc.analysis3_cd , phc.analysis4_cd";
				mysql = mysql + " , phc.analysis5_cd  , 0 as pay_hours , 0 as payHours";
				mysql = mysql + " from Pay_Head_Count phc";
				mysql = mysql + " left outer join Pay_Budget_Details pbd on pbd.Line_No = phc.Budget_Details_Line_No ";
				mysql = mysql + " inner join Pay_Head_Count_Category phcc on phcc.Head_Count_Category_Cd = phc.Head_Count_Category_Cd";
				mysql = mysql + " inner join Pay_Budget_Category pbc on pbc.Head_Count_Category_Cd = phcc.Head_Count_Category_Cd";
				mysql = mysql + " Where (phc.Is_Budgeted = 1 or phc.Head_Count_Status = 3) ";
				mysql = mysql + " and (pbd.Budget_Period <= '" + mPayrollDate + "'  or pbd.Budget_Period is null) and (pbd.Budget_Head_Count > 0   or pbd.Budget_Head_Count is null) and isnull(phc.analysis4_cd,'') <> ''";
				mysql = mysql + " and pbc.Budget_cd = " + mBudgetCd.ToString();
				mysql = mysql + " Union All";
				mysql = mysql + " select    (((" + Math.Round((double) (mMonthDays / 365d), 3).ToString() + " * 30)/26)* (abs(phc.Total_Budget_Salary) + dbo.PayGetBudgetCommission(phc.analysis4_cd ,'" + mPayrollDate + "' ))) as lc_Amount";
				mysql = mysql + " , 391 , NULL , phc.Head_Count_Cd as emp_dept_cd   , 1 , NULL , '' ldgr_name, '' cost_name";
				mysql = mysql + " , 1 as sorder ,''  as default_project  , 25120200  as project_no   , phc.analysis2_cd , phc.analysis3_cd , phc.analysis4_cd";
				mysql = mysql + " , phc.analysis5_cd  , 0 as pay_hours , 0 as payHours";
				mysql = mysql + " from Pay_Head_Count phc";
				mysql = mysql + " left outer join Pay_Budget_Details pbd on pbd.Line_No = phc.Budget_Details_Line_No ";
				mysql = mysql + " inner join Pay_Head_Count_Category phcc on phcc.Head_Count_Category_Cd = phc.Head_Count_Category_Cd";
				mysql = mysql + " inner join Pay_Budget_Category pbc on pbc.Head_Count_Category_Cd = phcc.Head_Count_Category_Cd";
				mysql = mysql + " Where (phc.Is_Budgeted = 1 or phc.Head_Count_Status = 3) ";
				mysql = mysql + " and (pbd.Budget_Period <= '" + mPayrollDate + "'  or pbd.Budget_Period is null) and (pbd.Budget_Head_Count > 0   or pbd.Budget_Head_Count is null) and isnull(phc.analysis4_cd,'') <> ''";
				mysql = mysql + " and pbc.Budget_cd = " + mBudgetCd.ToString();
				mysql = mysql + " order by gltab.Emp_Cd ";

				if (mysql != "")
				{

					SqlCommand sqlCommand_3 = new SqlCommand(mysql, SystemVariables.gConn);
					rsTempRec = sqlCommand_3.ExecuteReader();
					bool rsTempRecDidRead2 = rsTempRec.Read();

					if (rsTempRecDidRead)
					{
						do 
						{
							mJvType = 2;
							if (Convert.IsDBNull(rsTempRec["ldgr_cd"]))
							{
								DisplayError(Convert.ToInt32(rsTempRec["emp_dept_cd"]));
								throw new Exception();
							}
							else
							{
								mLdgrCd = Convert.ToString(rsTempRec["ldgr_cd"]);
								mLdgrNo = Convert.ToString(rsTempRec["ldgr_no"]);
								mLdgrName = Convert.ToString(rsTempRec["ldgr_name"]);
								mProjectNo = "";
								if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("cost_center")))
								{
									if (Convert.IsDBNull(rsTempRec["cost_cd"]))
									{
										DisplayError(Convert.ToInt32(rsTempRec["emp_dept_cd"]));
										throw new Exception();
									}
									else
									{
										mCostCd = Convert.ToString(rsTempRec["cost_cd"]);
										mCostNo = Convert.ToString(rsTempRec["cost_no"]);
										mCostName = Convert.ToString(rsTempRec["cost_name"]);
									}
								}
								else
								{
									mCostCd = "";
									mCostNo = "";
									mCostName = "";
								}
								if (!SystemProcedure2.IsItEmpty(rsTempRec["Project_no"], SystemVariables.DataType.StringType))
								{
									mAnalysisCd1 = Convert.ToString(rsTempRec["Project_no"]);
									mProjectNo = Convert.ToString(rsTempRec["Project_no"]);
								}
								else if (!SystemProcedure2.IsItEmpty(rsTempRec["default_project"], SystemVariables.DataType.StringType))
								{ 
									mAnalysisCd1 = Convert.ToString(rsTempRec["default_project"]);
									mProjectNo = Convert.ToString(rsTempRec["default_project"]);
								}
								else
								{
									mAnalysisCd1 = "";
								}
								if (!SystemProcedure2.IsItEmpty(rsTempRec["analysis2_Cd"], SystemVariables.DataType.StringType))
								{
									mAnalysisCd2 = Convert.ToString(rsTempRec["analysis2_Cd"]);
								}
								else
								{
									mAnalysisCd2 = "";
								}
								if (!SystemProcedure2.IsItEmpty(rsTempRec["analysis3_Cd"], SystemVariables.DataType.StringType))
								{
									mAnalysisCd3 = Convert.ToString(rsTempRec["analysis3_Cd"]);
								}
								else
								{
									mAnalysisCd3 = "";
								}
								if (!SystemProcedure2.IsItEmpty(rsTempRec["analysis4_Cd"], SystemVariables.DataType.StringType))
								{
									mAnalysisCd4 = Convert.ToString(rsTempRec["analysis4_Cd"]);
								}
								else
								{
									mAnalysisCd4 = "";
								}
								if (!SystemProcedure2.IsItEmpty(rsTempRec["analysis5_Cd"], SystemVariables.DataType.StringType))
								{
									mAnalysisCd5 = Convert.ToString(rsTempRec["analysis5_Cd"]);
								}
								else
								{
									mAnalysisCd5 = "";
								}
							}

							if (Convert.ToDouble(rsTempRec["lc_amount"]) > 0)
							{
								mDrCr = "D";
							}
							else
							{
								mDrCr = "C";
							}
							if (SystemProcedure2.IsItEmpty(mProjectNo, SystemVariables.DataType.StringType))
							{
								mAmount = Convert.ToDouble(rsTempRec["lc_amount"]);
							}
							else
							{
								if (Convert.ToDouble(rsTempRec["pay_hours"]) != 0)
								{
									mAmount = (Convert.ToDouble(rsTempRec["lc_amount"]) / ((double) Convert.ToDouble(rsTempRec["payHours"]))) * Convert.ToDouble(rsTempRec["pay_hours"]);
								}
								else
								{
									mAmount = Convert.ToDouble(rsTempRec["lc_amount"]);
								}
							}

							if (mDrCr == "D")
							{
								InsertIntoArray(cnt, mLdgrNo, mLdgrName, (decimal) mAmount, 0, mCostNo, mCostName, mLdgrCd, mCostCd, conLeaveProvisionComments, "", "", "", "", mAnalysisCd1, mAnalysisCd2, mJvType, mProjectNo, mAnalysisCd3, mAnalysisCd4, mAnalysisCd5);
							}
							else
							{
								InsertIntoArray(cnt, mLdgrNo, mLdgrName, 0, (decimal) Math.Abs(mAmount), mCostNo, mCostName, mLdgrCd, mCostCd, conLeaveProvisionComments, "", "", "", "", mAnalysisCd1, mAnalysisCd2, mJvType, mProjectNo, mAnalysisCd3, mAnalysisCd4, mAnalysisCd5);
							}

							cnt++;
						}
						while(rsTempRec.Read());
						rsTempRec.Close();
					}

				}
				mDR = 0;
				mCr = 0;
				int tempForEndVar2 = mArr.GetLength(0) - 1;
				for (cnt = 0; cnt <= tempForEndVar2; cnt++)
				{
					mDR += Convert.ToDouble(mArr.GetValue(cnt, gccDebit));
					mCr += Convert.ToDouble(mArr.GetValue(cnt, gccCredit));
				}
				//''Staff Indemnity expenses a/c   dr
				//''     To Indemnity provision  a/c

				mysql = "select ( " + Math.Round((double) (mMonthDays / 365d), 3).ToString() + " *  case when DATEDIFF(D,pemp.Date_Of_Joining,'" + mPayrollDate + "') > (pemp.Indemnity_Switch_Over_Period * 365) then (pemp.Indemnity_Days_After_SOP/pemp.Indemnity_Working_Days_Per_Month_After_SOP) else (pemp.Indemnity_Days_Before_SOP / pemp.Indemnity_Working_Days_Per_Month_Before_SOP) end ) *  (pemp.Indemnity_Salary + dbo.PayGetBudgetCommission(phc.analysis4_cd ,'" + mPayrollDate + "' )) * -1 as lc_Amount";
				mysql = mysql + " , gltab.ldgr_cd, gltab.cost_cd , gltab.emp_cd as emp_dept_cd   , gl_ledger.ldgr_no , cc.cost_no , l_ldgr_name ldgr_name, l_cost_name cost_name";
				mysql = mysql + " , 1 as sorder ,''  as default_project  , gltab.analysis1_cd  as project_no   , gltab.analysis2_cd , gltab.analysis3_cd , gltab.analysis4_cd";
				mysql = mysql + " , isnull(gltab.analysis5_cd,'') as analysis5_cd  , 0 as pay_hours , 0 as payHours";
				mysql = mysql + " from pay_employee pemp";
				mysql = mysql + " inner join Pay_Head_Count phc on phc.Emp_Cd = pemp.Emp_Cd";
				mysql = mysql + " inner join Pay_Head_Count_Category phcc on phcc.Head_Count_Category_Cd = phc.Head_Count_Category_Cd";
				mysql = mysql + " inner join Pay_Budget_Category pbc on pbc.Head_Count_Category_Cd = phcc.Head_Count_Category_Cd";
				mysql = mysql + " inner join Pay_Budget pb on pb.Budget_Cd = pbc.Budget_Cd";
				mysql = mysql + " inner join pay_employee_gl_details gltab on pemp.emp_cd = gltab.emp_cd";
				mysql = mysql + " left join gl_ledger on gltab.ldgr_cd = gl_ledger.ldgr_cd";
				mysql = mysql + " left join gl_cost_centers cc on gltab.cost_cd = cc.cost_cd";
				mysql = mysql + " Where (gltab.bill_cd = 8) and phc.Head_Count_Status = 2 and phc.Is_budgeted = 0 and pemp.comp_cd = " + mComCd.ToString();
				mysql = mysql + " and pemp.emp_no not in (select isnull(phc1.analysis4_cd,0) from Pay_Head_Count phc1 inner join Pay_Budget_Details pbd on pbd.Line_No = phc1.Budget_Details_Line_No";
				mysql = mysql + "                  where pbd.Budget_Period <= '" + mPayrollDate + "' and  pbd.Budget_Head_Count < 0)";
				mysql = mysql + " and pbc.Budget_cd = " + mBudgetCd.ToString();
				mysql = mysql + " Union All";
				mysql = mysql + " select    (((" + Math.Round((double) (mMonthDays / 365d), 3).ToString() + " * 15)/26)* (abs(phc.Total_Budget_Salary) + dbo.PayGetBudgetCommission(phc.analysis4_cd ,'" + mPayrollDate + "' )))  * -1 as lc_Amount";
				mysql = mysql + " , 391 , NULL , phc.Head_Count_Cd as emp_dept_cd   , 1 , NULL , '' ldgr_name, '' cost_name";
				mysql = mysql + " , 1 as sorder ,''  as default_project  , 25140100  as project_no   , phc.analysis2_cd , phc.analysis3_cd , phc.analysis4_cd";
				mysql = mysql + " , phc.analysis5_cd  , 0 as pay_hours , 0 as payHours";
				mysql = mysql + " from Pay_Head_Count phc";
				mysql = mysql + " left outer join Pay_Budget_Details pbd on pbd.Line_No = phc.Budget_Details_Line_No ";
				mysql = mysql + " inner join Pay_Head_Count_Category phcc on phcc.Head_Count_Category_Cd = phc.Head_Count_Category_Cd";
				mysql = mysql + " inner join Pay_Budget_Category pbc on pbc.Head_Count_Category_Cd = phcc.Head_Count_Category_Cd";
				mysql = mysql + " Where (phc.Is_Budgeted = 1 or phc.Head_Count_Status = 3) ";
				mysql = mysql + " and (pbd.Budget_Period <= '" + mPayrollDate + "'  or pbd.Budget_Period is null) and (pbd.Budget_Head_Count > 0   or pbd.Budget_Head_Count is null) and isnull(phc.analysis4_cd,'') <> ''";
				mysql = mysql + " and pbc.Budget_cd = " + mBudgetCd.ToString();
				mysql = mysql + " Union All";
				mysql = mysql + " select    (" + Math.Round((double) (mMonthDays / 365d), 3).ToString() + " *  case when DATEDIFF(D,pemp.Date_Of_Joining,'" + mPayrollDate + "')>(pemp.Indemnity_Switch_Over_Period * 365) then (pemp.Indemnity_Days_After_SOP/pemp.Indemnity_Working_Days_Per_Month_After_SOP) else (pemp.Indemnity_Days_Before_SOP / pemp.Indemnity_Working_Days_Per_Month_Before_SOP) end ) *  (pemp.Indemnity_Salary + dbo.PayGetBudgetCommission(phc.analysis4_cd ,'" + mPayrollDate + "' ))  as lc_Amount";
				mysql = mysql + " ,gltab.ldgr_cd, gltab.cost_cd , gltab.emp_cd as emp_dept_cd   , gl_ledger.ldgr_no , cc.cost_no , l_ldgr_name ldgr_name, l_cost_name cost_name";
				mysql = mysql + " , 1 as sorder ,''  as default_project  , gltab.analysis1_cd  as project_no   , gltab.analysis2_cd , gltab.analysis3_cd , gltab.analysis4_cd";
				mysql = mysql + " , isnull(gltab.analysis5_cd,'') as analysis5_cd , 0 as pay_hours , 0 as payHours";
				mysql = mysql + " from pay_employee pemp";
				mysql = mysql + " inner join Pay_Head_Count phc on phc.Emp_Cd = pemp.Emp_Cd";
				mysql = mysql + " inner join Pay_Head_Count_Category phcc on phcc.Head_Count_Category_Cd = phc.Head_Count_Category_Cd";
				mysql = mysql + " inner join Pay_Budget_Category pbc on pbc.Head_Count_Category_Cd = phcc.Head_Count_Category_Cd";
				mysql = mysql + " inner join Pay_Budget pb on pb.Budget_Cd = pbc.Budget_Cd";
				mysql = mysql + " inner join pay_employee_gl_details gltab on pemp.emp_cd = gltab.emp_cd";
				mysql = mysql + " left join gl_ledger on gltab.ldgr_cd = gl_ledger.ldgr_cd";
				mysql = mysql + " left join gl_cost_centers cc on gltab.cost_cd = cc.cost_cd";
				mysql = mysql + " Where (gltab.bill_cd = 9) and phc.Head_Count_Status = 2 and phc.Is_budgeted = 0 and pemp.comp_cd = " + mComCd.ToString();
				mysql = mysql + " and pemp.emp_no not in (select isnull(phc1.analysis4_cd,0) from Pay_Head_Count phc1 inner join Pay_Budget_Details pbd on pbd.Line_No = phc1.Budget_Details_Line_No";
				mysql = mysql + "                  where pbd.Budget_Period <= '" + mPayrollDate + "' and  pbd.Budget_Head_Count < 0)";
				mysql = mysql + " and pbc.Budget_cd = " + mBudgetCd.ToString();
				mysql = mysql + " Union All";
				mysql = mysql + " select    (((" + Math.Round((double) (mMonthDays / 365d), 3).ToString() + " * 15)/26)* (abs(phc.Total_Budget_Salary) + dbo.PayGetBudgetCommission(phc.analysis4_cd ,'" + mPayrollDate + "' )))  as lc_Amount";
				mysql = mysql + " ,391 , NULL , phc.Head_Count_Cd as emp_dept_cd   , 1 , NULL , '' ldgr_name, '' cost_name";
				mysql = mysql + " , 1 as sorder ,''  as default_project  , 40120200  as project_no   , phc.analysis2_cd , phc.analysis3_cd , phc.analysis4_cd";
				mysql = mysql + " , phc.analysis5_cd  , 0 as pay_hours , 0 as payHours";
				mysql = mysql + " from Pay_Head_Count phc";
				mysql = mysql + " left outer join Pay_Budget_Details pbd on pbd.Line_No = phc.Budget_Details_Line_No ";
				mysql = mysql + " inner join Pay_Head_Count_Category phcc on phcc.Head_Count_Category_Cd = phc.Head_Count_Category_Cd";
				mysql = mysql + " inner join Pay_Budget_Category pbc on pbc.Head_Count_Category_Cd = phcc.Head_Count_Category_Cd";
				mysql = mysql + " Where (phc.Is_Budgeted = 1 or phc.Head_Count_Status = 3) ";
				mysql = mysql + " and (pbd.Budget_Period <= '" + mPayrollDate + "'  or pbd.Budget_Period is null) and (pbd.Budget_Head_Count > 0   or pbd.Budget_Head_Count is null) and isnull(phc.analysis4_cd,'') <> ''";
				mysql = mysql + " and pbc.Budget_cd = " + mBudgetCd.ToString();
				mysql = mysql + " order by gltab.Emp_Cd";

				if (mysql != "")
				{
					SqlCommand sqlCommand_4 = new SqlCommand(mysql, SystemVariables.gConn);
					rsTempRec = sqlCommand_4.ExecuteReader();
					bool rsTempRecDidRead3 = rsTempRec.Read();

					if (rsTempRecDidRead)
					{
						do 
						{
							mJvType = 2;
							if (Convert.IsDBNull(rsTempRec["ldgr_cd"]))
							{
								DisplayError(Convert.ToInt32(rsTempRec["emp_dept_cd"]));
								throw new Exception();
							}
							else
							{
								mLdgrCd = Convert.ToString(rsTempRec["ldgr_cd"]);
								mLdgrNo = Convert.ToString(rsTempRec["ldgr_no"]);
								mLdgrName = Convert.ToString(rsTempRec["ldgr_name"]);
								mProjectNo = Convert.ToString(rsTempRec["Project_No"]) + "";
								if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("cost_center")))
								{
									if (Convert.IsDBNull(rsTempRec["cost_cd"]))
									{
										DisplayError(Convert.ToInt32(rsTempRec["emp_dept_cd"]));
										throw new Exception();
									}
									else
									{
										mCostCd = Convert.ToString(rsTempRec["cost_cd"]);
										mCostNo = Convert.ToString(rsTempRec["cost_no"]);
										mCostName = Convert.ToString(rsTempRec["cost_name"]);
									}
								}
								else
								{
									mCostCd = "";
									mCostNo = "";
									mCostName = "";
								}
								if (!SystemProcedure2.IsItEmpty(rsTempRec["Project_No"], SystemVariables.DataType.StringType))
								{
									mAnalysisCd1 = Convert.ToString(rsTempRec["Project_No"]);
								}
								else if (!SystemProcedure2.IsItEmpty(rsTempRec["Default_Project"], SystemVariables.DataType.StringType))
								{ 
									mAnalysisCd1 = Convert.ToString(rsTempRec["Default_Project"]);
								}
								else
								{
									mAnalysisCd1 = "";
								}
								if (!SystemProcedure2.IsItEmpty(rsTempRec["analysis2_Cd"], SystemVariables.DataType.StringType))
								{
									mAnalysisCd2 = Convert.ToString(rsTempRec["analysis2_Cd"]);
								}
								else
								{
									mAnalysisCd2 = "";
								}
								if (!SystemProcedure2.IsItEmpty(rsTempRec["analysis3_Cd"], SystemVariables.DataType.StringType))
								{
									mAnalysisCd3 = Convert.ToString(rsTempRec["analysis3_Cd"]);
								}
								else
								{
									mAnalysisCd3 = "";
								}
								if (!SystemProcedure2.IsItEmpty(rsTempRec["analysis4_Cd"], SystemVariables.DataType.StringType))
								{
									mAnalysisCd4 = Convert.ToString(rsTempRec["analysis4_Cd"]);
								}
								else
								{
									mAnalysisCd4 = "";
								}
								if (!SystemProcedure2.IsItEmpty(rsTempRec["analysis5_Cd"], SystemVariables.DataType.StringType))
								{
									mAnalysisCd5 = Convert.ToString(rsTempRec["analysis5_Cd"]);
								}
								else
								{
									mAnalysisCd5 = "";
								}
							}

							if (Convert.ToDouble(rsTempRec["lc_amount"]) > 0)
							{
								mDrCr = "D";
							}
							else
							{
								mDrCr = "C";
							}
							if (SystemProcedure2.IsItEmpty(rsTempRec["pay_Hours"], SystemVariables.DataType.NumberType))
							{
								mAmount = Convert.ToDouble(rsTempRec["lc_amount"]);
							}
							else
							{
								if (Convert.ToDouble(rsTempRec["pay_Hours"]) != 0)
								{
									mAmount = (Convert.ToDouble(rsTempRec["lc_amount"]) / ((double) Convert.ToDouble(rsTempRec["payHours"]))) * Convert.ToDouble(rsTempRec["pay_Hours"]);
								}
								else
								{
									mAmount = Convert.ToDouble(rsTempRec["lc_amount"]);
								}
							}
							if (mDrCr == "D")
							{
								InsertIntoArray(cnt, mLdgrNo, mLdgrName, (decimal) Math.Abs(mAmount), 0, mCostNo, mCostName, mLdgrCd, mCostCd, conIndemnityProvisionComments, "", "", "", "", mAnalysisCd1, mAnalysisCd2, mJvType, mProjectNo, mAnalysisCd3, mAnalysisCd4, mAnalysisCd5);
							}
							else
							{
								InsertIntoArray(cnt, mLdgrNo, mLdgrName, 0, (decimal) Math.Abs(mAmount), mCostNo, mCostName, mLdgrCd, mCostCd, conIndemnityProvisionComments, "", "", "", "", mAnalysisCd1, mAnalysisCd2, mJvType, mProjectNo, mAnalysisCd3, mAnalysisCd4, mAnalysisCd5);
							}

							cnt++;
						}
						while(rsTempRec.Read());
						rsTempRec.Close();
					}
				}
				mDR = 0;
				mCr = 0;
				int tempForEndVar3 = mArr.GetLength(0) - 1;
				for (cnt = 0; cnt <= tempForEndVar3; cnt++)
				{
					mDR += Convert.ToDouble(mArr.GetValue(cnt, gccDebit));
					mCr += Convert.ToDouble(mArr.GetValue(cnt, gccCredit));
				}

				result = true;

				rsTempRec1 = null;
				return result;
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				MessageBox.Show(Information.Err().Number.ToString() + " " + excep.Message, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
				return false;
			}
		}

		private void ClubVoucherEntry()
		{ // added by burhanuddin ghee wala
			DataSet rsTmp = new DataSet();
			int i = 0;

			//creatin a new temporary table
			//UPGRADE_WARNING: (1068) GetSystemPreferenceSetting() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			int mProjectMethod = ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetSystemPreferenceSetting("GL_Project_Insert_Method"));
			//UPGRADE_WARNING: (1068) GetSystemPreferenceSetting() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			int pGLInsertMethod = ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetSystemPreferenceSetting("pay_gl_entry_method"));

			StringBuilder mysql = new StringBuilder();
			mysql.Append("create table #TmpVoucher (account_no varchar(50), account_name varchar(50) ");
			mysql.Append(", dr_amount money, cr_amount money, cost_name varchar(50), cost_no int ");
			mysql.Append(", led_cd int, cost_cd int, account_cd varchar(50), service_cd varchar(50), party_cd varchar(50), Depart_cd varchar(50) ");
			mysql.Append(", Analysis1_cd varchar(20) , Analysis2_cd varchar(20), JVType int, Analysis3_cd varchar(20) , Analysis4_cd varchar(20)");
			mysql.Append(", Analysis5_cd varchar(20) )");
			SqlCommand TempCommand = null;
			TempCommand = SystemVariables.gConn.CreateCommand();
			TempCommand.CommandText = mysql.ToString();
			TempCommand.ExecuteNonQuery();

			int tempForEndVar = mArr.GetLength(0) - 1;
			for (i = 0; i <= tempForEndVar; i++)
			{
				mysql = new StringBuilder("insert into #Tmpvoucher values ('" + Convert.ToString(mArr.GetValue(i, gccAccountNo)) + "'");
				mysql.Append(" ,'" + Convert.ToString(mArr.GetValue(i, gccAccountName)) + "'");
				mysql.Append(" ," + Convert.ToDouble(mArr.GetValue(i, gccDebit)).ToString());
				mysql.Append(" ," + Convert.ToDouble(mArr.GetValue(i, gccCredit)).ToString());
				mysql.Append(" ,'" + Convert.ToString(mArr.GetValue(i, gccCCName)) + "'");
				mysql.Append(" ," + ((Convert.ToString(mArr.GetValue(i, gccCCNo)) == "") ? "0" : Convert.ToString(mArr.GetValue(i, gccCCNo))));
				if (!SystemProcedure2.IsItEmpty(mArr.GetValue(i, gccLdgrCd), SystemVariables.DataType.NumberType))
				{
					mysql.Append(" ," + Convert.ToString(mArr.GetValue(i, gccLdgrCd)));
				}
				else if (pGLInsertMethod == 3 || pGLInsertMethod == 4)
				{ 
					mysql.Append(" ,0");
				}
				mysql.Append(" ," + ((Convert.ToString(mArr.GetValue(i, gccCCCd)) == "") ? "0" : Convert.ToString(mArr.GetValue(i, gccCCCd))));
				mysql.Append(" ,'" + Convert.ToString(mArr.GetValue(i, gccAccountCode)) + "'");
				mysql.Append(" ,'" + Convert.ToString(mArr.GetValue(i, gccServiceCode)) + "'");
				mysql.Append(" ,'" + Convert.ToString(mArr.GetValue(i, gccPartyCode)) + "'");
				mysql.Append(" ,'" + Convert.ToString(mArr.GetValue(i, gccDepartmentCode)) + "'");
				mysql.Append(" ,'" + Convert.ToString(mArr.GetValue(i, gccAnalysisCd1)) + "'");
				mysql.Append(" ,'" + Convert.ToString(mArr.GetValue(i, gccAnalysisCd2)) + "'");
				mysql.Append(" ," + Convert.ToString(mArr.GetValue(i, gccJvType)));
				mysql.Append(" ,'" + Convert.ToString(mArr.GetValue(i, gccAnalysisCd3)) + "'");
				mysql.Append(" ,'" + Convert.ToString(mArr.GetValue(i, gccAnalysisCd4)) + "'");
				mysql.Append(" ,'" + Convert.ToString(mArr.GetValue(i, gccAnalysisCd5)) + "'");
				mysql.Append(")");
				SqlCommand TempCommand_2 = null;
				TempCommand_2 = SystemVariables.gConn.CreateCommand();
				TempCommand_2.CommandText = mysql.ToString();
				TempCommand_2.ExecuteNonQuery();
			}

			mysql = new StringBuilder(" select account_no, account_name, cost_no, cost_name, sum(dr_amount) as dr_amount, sum(cr_amount) as cr_amount");
			mysql.Append(" ,led_cd, cost_cd,account_cd,service_cd,party_cd,Depart_cd,Analysis1_cd,Analysis2_cd , JVType ,Analysis3_cd ");
			mysql.Append(" ,Analysis4_cd ,Analysis5_cd from #TmpVoucher where dr_amount > 0 ");
			mysql.Append("  group by  account_no, account_name, cost_no, cost_name, led_cd, cost_cd,account_cd,service_cd,party_cd,Depart_cd");
			mysql.Append(", Analysis1_cd,Analysis2_cd , JVType ,Analysis3_cd ,Analysis4_cd ,Analysis5_cd");
			//mySQL = mySQL & " order by Depart_cd"
			mysql.Append(" union ");
			mysql.Append(" select account_no, account_name, cost_no, cost_name, sum(dr_amount) as dr_amount, sum(cr_amount) as cr_amount");
			mysql.Append(" ,led_cd, cost_cd,account_cd,service_cd,party_cd,Depart_cd,Analysis1_cd,Analysis2_cd , JVType ");
			mysql.Append(" ,Analysis3_cd ,Analysis4_cd ,Analysis5_cd from #TmpVoucher where cr_amount > 0 ");
			mysql.Append(" group by  account_no, account_name, cost_no, cost_name, led_cd, cost_cd,account_cd,service_cd,party_cd,Depart_cd ");
			mysql.Append(" ,Analysis1_cd,Analysis2_cd , JVType ,Analysis3_cd ,Analysis4_cd ,Analysis5_cd "); // order by sum(cr_amount)"
			mysql.Append(" order by Depart_cd,account_cd,service_cd,party_cd,sum(cr_amount)");
			mArr = new XArrayHelper();
			SqlCommand TempCommand_3 = null;
			TempCommand_3 = SystemVariables.gConn.CreateCommand();
			TempCommand_3.CommandText = mysql.ToString();
			SqlDataAdapter TempAdapter_3 = null;
			TempAdapter_3 = new SqlDataAdapter();
			TempAdapter_3.SelectCommand = TempCommand_3;
			DataSet TempDataset_3 = null;
			TempDataset_3 = new DataSet();
			TempAdapter_3.Fill(TempDataset_3);
			rsTmp = TempDataset_3;
			i = 0;
			foreach (DataRow iteration_row in rsTmp.Tables[0].Rows)
			{
				InsertIntoArray(i, Convert.ToString(iteration_row["account_no"]), Convert.ToString(iteration_row["account_name"]), Convert.ToDecimal(iteration_row["dr_amount"]), Convert.ToDecimal(iteration_row["cr_amount"]), Convert.ToString(iteration_row["cost_no"]), Convert.ToString(iteration_row["cost_name"]), Convert.ToString(iteration_row["led_cd"]), Convert.ToString(iteration_row["cost_cd"]), "", Convert.ToString(iteration_row["service_cd"]), Convert.ToString(iteration_row["party_cd"]), Convert.ToString(iteration_row["account_cd"]), Convert.ToString(iteration_row["Depart_cd"]), Convert.ToString(iteration_row["Analysis1_cd"]), Convert.ToString(iteration_row["Analysis2_cd"]), Convert.ToInt32(iteration_row["JVType"]), "", Convert.ToString(iteration_row["Analysis3_cd"]), Convert.ToString(iteration_row["Analysis4_cd"]), Convert.ToString(iteration_row["Analysis5_cd"]));
				i++;
			}

			SqlCommand TempCommand_4 = null;
			TempCommand_4 = SystemVariables.gConn.CreateCommand();
			TempCommand_4.CommandText = "drop table #TmpVoucher";
			TempCommand_4.ExecuteNonQuery();


		}


		private void InsertIntoArray(int pRow, string pAccountNo, string pAccountName, decimal pDrAmt, decimal pCrAmt, string pCCCode, string pCCName, string pLdgrCd, string pCCCd, string pComments, string pServiceCd = "", string pPartyCd = "", string pAccountCd = "", string pDepartCd = "", string pAnalysisCd1 = "", string pAnalysisCd2 = "", int pJvtype = 1, string pProjectNo = "", string pAnalysisCd3 = "", string pAnalysisCd4 = "", string pAnalysisCd5 = "")
		{

			mArr.RedimXArray(new int[]{pRow, mMaxCols}, new int[]{0, 0});

			mArr.SetValue(pAccountNo, pRow, gccAccountNo);
			mArr.SetValue(pAccountName, pRow, gccAccountName);
			mArr.SetValue(StringsHelper.Format(pDrAmt, "###,###,###,##0.000"), pRow, gccDebit);
			mArr.SetValue(StringsHelper.Format(pCrAmt, "###,###,###,##0.000"), pRow, gccCredit);
			mArr.SetValue(pCCCode, pRow, gccCCNo);
			mArr.SetValue(pCCName, pRow, gccCCName);
			mArr.SetValue(pLdgrCd, pRow, gccLdgrCd);
			mArr.SetValue(pCCCd, pRow, gccCCCd);
			mArr.SetValue(pComments, pRow, gccComments);
			if (ReflectionHelper.GetPrimitiveValue<double>(SystemProcedure2.GetSystemPreferenceSetting("pay_gl_entry_method")) == 3)
			{
				mArr.SetValue(pPartyCd, pRow, gccPartyCode);
				mArr.SetValue(pServiceCd, pRow, gccServiceCode);
				mArr.SetValue(pAccountCd, pRow, gccAccountCode);
				mArr.SetValue(pDepartCd, pRow, gccDepartmentCode);
			}
			mArr.SetValue(pAnalysisCd1, pRow, gccAnalysisCd1);
			mArr.SetValue(pAnalysisCd2, pRow, gccAnalysisCd2);
			mArr.SetValue(pAnalysisCd3, pRow, gccAnalysisCd3);
			mArr.SetValue(pAnalysisCd4, pRow, gccAnalysisCd4);
			mArr.SetValue(pAnalysisCd5, pRow, gccAnalysisCd5);
			mArr.SetValue(pJvtype, pRow, gccJvType);
			mArr.SetValue(pProjectNo, pRow, gccProjectNo);

		}


		private void CalculateTotal()
		{
			int cnt = 0;
			decimal mDrAmt = 0;
			decimal mCrAmt = 0;

			int tempForEndVar = aVoucherDetails.GetLength(0) - 1;
			for (cnt = 0; cnt <= tempForEndVar; cnt++)
			{
				mDrAmt += ((decimal) Conversion.Val(StringsHelper.Format(aVoucherDetails.GetValue(cnt, grdccDebit), "###############0.000")));
				mCrAmt += ((decimal) Conversion.Val(StringsHelper.Format(aVoucherDetails.GetValue(cnt, grdccCredit), "###############0.000")));
			}

			grdVoucherDetails.Columns[gccDebit].FooterText = StringsHelper.Format(mDrAmt, "###,###,###,##0.000");
			grdVoucherDetails.Columns[gccCredit].FooterText = StringsHelper.Format(mCrAmt, "###,###,###,##0.000");
		}


		private void txtBudgetCode_DropButtonClick(Object Sender, EventArgs e)
		{
			FindRoutine("txtBudgetCode");
		}

		private void txtBudgetCode_Leave(Object eventSender, EventArgs eventArgs)
		{
			try
			{
				object mTempValue = null;
				string mysql = "";
				int cnt = 0;

				if (!SystemProcedure2.IsItEmpty(txtBudgetCode.Text, SystemVariables.DataType.StringType))
				{
					mysql = "select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "L_Budget_Name" : "A_Budget_Name");
					mysql = mysql + " , freezed ";
					mysql = mysql + " from Pay_Budget where Budget_No=" + txtBudgetCode.Text;
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (Convert.IsDBNull(mTempValue))
					{
						txtBudgetCode.Text = "";
						throw new System.Exception("-9990002");
					}
					else
					{
						//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtDlblBudgetName.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(0));
					}
				}
				else
				{
					txtDlblBudgetName.Text = "";
				}
			}
			catch (System.Exception excep)
			{
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				MessageBox.Show(Information.Err().Number.ToString() + " " + excep.Message, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
			}
		}

		private void txtCompanyCode_DropButtonClick(Object Sender, EventArgs e)
		{
			txtCompanyCode.Text = "";
			//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(7001100, "1769"));
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(mTempSearchValue))
			{
				//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				txtCompanyCode.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(1));
				txtCompanyCode_Leave(txtCompanyCode, new EventArgs());
			}
		}

		private void txtCompanyCode_Leave(Object eventSender, EventArgs eventArgs)
		{
			try
			{
				object mTempValue = null;
				string mysql = "";

				if (!SystemProcedure2.IsItEmpty(txtCompanyCode.Text, SystemVariables.DataType.NumberType))
				{
					mysql = "select comp_no ";
					mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_comp_name" : "a_comp_name");
					mysql = mysql + " , comp_cd";
					mysql = mysql + " from pay_company ";
					mysql = mysql + " where ";
					mysql = mysql + " comp_no = " + txtCompanyCode.Text;

					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (Convert.IsDBNull(mTempValue))
					{
						txtCompanyName.Text = "";
						mComCd = 0;
						throw new System.Exception("-9990002");
					}
					else
					{
						//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtCompanyName.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(1));
						//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mComCd = ReflectionHelper.GetPrimitiveValue<int>(((Array) mTempValue).GetValue(2));
					}
				}
				else
				{
					txtCompanyName.Text = "";
					mComCd = 0;
				}
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				MessageBox.Show(Information.Err().Number.ToString() + " " + excep.Message, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
			}
		}

		private void DisplayError(int pCode)
		{


			string mysql = " select emp_no , ";
			if (SystemVariables.gPreferedLanguage == SystemVariables.Language.English)
			{
				mysql = mysql + " l_full_name ";
			}
			else
			{
				mysql = mysql + " a_full_name ";
			}
			mysql = mysql + " from pay_employee ";
			mysql = mysql + " where emp_cd =" + pCode.ToString();
			string mErrorMessage = " GL links not defined for Employee : ";

			//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(mReturnValue))
			{
				MessageBox.Show(mErrorMessage + ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(0)) + " " + ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(1)), AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
			}
			else
			{
				MessageBox.Show("Gl Link is not set:!!!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
			}

		}

		public void FindRoutine(string pObjectName)
		{
			object mTempSearchValue = null;

			if (pObjectName == "txtBudgetCode")
			{
				txtBudgetCode.Text = "";
				//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(7220624, "2770"));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(mTempSearchValue))
				{
					//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					txtBudgetCode.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(1));
					txtBudgetCode_Leave(txtBudgetCode, new EventArgs());
				}
			}
			else
			{

			}
		}
	}
}