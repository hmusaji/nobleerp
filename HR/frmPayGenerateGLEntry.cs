
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
	internal partial class frmPayGenerateGLEntry
		: System.Windows.Forms.Form
	{


		private clsAccessAllowed _UserAccess = null;
		public frmPayGenerateGLEntry()
{
InitializeComponent();
} 
 public  void frmPayGenerateGLEntry_old()
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

		private object mSearchValue = null;
		private SystemVariables.SystemFormModes mCurrentFormMode = (SystemVariables.SystemFormModes) 0;


		public object SearchValue
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

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBDropDown Event cmbMastersList.DataSourceChanged was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void cmbMastersList_DataSourceChanged()
		{
			int cnt = 0;

			cmbMastersList.Width = 0;

			C1.Win.C1TrueDBGrid.C1DisplayColumn withVar = null;
			C1.Win.C1TrueDBGrid.C1DisplayColumn withVar_2 = null;
			switch(grdVoucherDetails.Col)
			{
				case gccLdgrNo : case gccLdgrName : 
					if (grdVoucherDetails.Col == gccLdgrNo)
					{
						//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbMastersList.ListField was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						cmbMastersList.setListField("ldgr_no");
						//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsLedgerCodeList.Sort was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						rsLedgerCodeList.setSort("ldgr_no");
					}
					else
					{
						//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbMastersList.ListField was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						cmbMastersList.setListField("ldgr_name");
						//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsLedgerCodeList.Sort was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						rsLedgerCodeList.setSort("ldgr_name");
					} 
					 
					int tempForEndVar = cmbMastersList.Columns.Count - 1; 
					for (cnt = 0; cnt <= tempForEndVar; cnt++)
					{
						//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
						withVar = cmbMastersList.Splits[0].DisplayColumns[cnt];
						if (cnt < 2)
						{
							if (cnt == 0)
							{
								//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.Column property withVar.Order was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
								withVar.setOrder((grdVoucherDetails.Col == gccLdgrNo) ? 0 : 1);
								//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
								withVar.Width = grdVoucherDetails.Splits[0].DisplayColumns[gccLdgrNo].Width;
							}
							else
							{
								//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.Column property withVar.Order was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
								withVar.setOrder((grdVoucherDetails.Col == gccLdgrNo) ? 1 : 0);
								//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
								withVar.Width = grdVoucherDetails.Splits[0].DisplayColumns[gccLdgrName].Width;
							}

							if (SystemVariables.gPreferedLanguage == SystemVariables.Language.English)
							{
								withVar.Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Near;
							}
							else
							{
								withVar.Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far;
							}
							withVar.Visible = true;
							cmbMastersList.Width += withVar.Width / 15;
						}
						else
						{
							withVar.Visible = false;
						}
						withVar.AllowSizing = false;
					} 
					break;
				case gccCCNo : case gccCCName : 
					if (grdVoucherDetails.Col == gccCCNo)
					{
						//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbMastersList.ListField was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						cmbMastersList.setListField("cost_no");
						//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsCCCodeList.Sort was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						rsCCCodeList.setSort("cost_no");
					}
					else
					{
						//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbMastersList.ListField was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						cmbMastersList.setListField("cost_name");
						//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsCCCodeList.Sort was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						rsCCCodeList.setSort("cost_name");
					} 
					 
					int tempForEndVar2 = cmbMastersList.Columns.Count - 1; 
					for (cnt = 0; cnt <= tempForEndVar2; cnt++)
					{
						//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
						withVar_2 = cmbMastersList.Splits[0].DisplayColumns[cnt];
						if (cnt < 2)
						{
							if (cnt == 0)
							{
								//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.Column property withVar_2.Order was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
								withVar_2.setOrder((grdVoucherDetails.Col == gccCCNo) ? 0 : 1);
								//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
								withVar_2.Width = grdVoucherDetails.Splits[0].DisplayColumns[gccCCNo].Width;
							}
							else
							{
								//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.Column property withVar_2.Order was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
								withVar_2.setOrder((grdVoucherDetails.Col == gccCCNo) ? 1 : 0);
								//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
								withVar_2.Width = grdVoucherDetails.Splits[0].DisplayColumns[gccCCName].Width;
							}

							if (SystemVariables.gPreferedLanguage == SystemVariables.Language.English)
							{
								withVar_2.Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Near;
							}
							else
							{
								withVar_2.Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far;
							}
							withVar_2.Visible = true;
							cmbMastersList.Width += withVar_2.Width / 15;
						}
						else
						{
							withVar_2.Visible = false;
						}
						withVar_2.AllowSizing = false;
					} 
					break;
			}

			cmbMastersList.Width += 17;
			cmbMastersList.Height = 167;

		}

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBDropDown Event cmbMastersList.DropDownClose was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void cmbMastersList_DropDownClose()
		{
			//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBGrid method grdVoucherDetails.PostMsg was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			grdVoucherDetails.PostMsg(1001);
		}

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBDropDown Event cmbMastersList.RowChange was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void cmbMastersList_RowChange()
		{
			if (grdVoucherDetails.Col == gccLdgrNo || grdVoucherDetails.Col == gccLdgrName)
			{
				if (grdVoucherDetails.Col == gccLdgrNo)
				{
					grdVoucherDetails.Columns[gccLdgrName].Value = cmbMastersList.Columns[1].Value;
				}
				else
				{
					grdVoucherDetails.Columns[gccLdgrNo].Value = cmbMastersList.Columns[0].Value;
				}
			}

			if (grdVoucherDetails.Col == gccCCNo || grdVoucherDetails.Col == gccCCName)
			{
				if (grdVoucherDetails.Col == gccCCNo)
				{
					grdVoucherDetails.Columns[gccCCName].Value = cmbMastersList.Columns[1].Value;
				}
				else
				{
					grdVoucherDetails.Columns[gccCCNo].Value = cmbMastersList.Columns[0].Value;
				}
			}
		}

		private void Command1_Click(Object eventSender, EventArgs eventArgs)
		{

			frmPayGLVoucherView mForm = null;
			string mGenerateDate = "";

			//UPGRADE_WARNING: (1068) txtDPayrollDate.DisplayText of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			string mMonthEndDate = ReflectionHelper.GetPrimitiveValue<string>(txtDPayrollDate.DisplayText);

			SystemVariables.gConn.BeginTransaction();

			if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("enable_payroll_gl_link")))
			{
				if (GetPayrollEntryInfoIntoArray(mMonthEndDate))
				{
					ClubVoucherEntry();
					//        Set mForm = New frmPayGLVoucherView
					//        mForm.AssignArray = mArr
					//        mForm.Show 1
					aVoucherDetails = mArr;
					//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBGrid property grdVoucherDetails.Array was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					grdVoucherDetails.setArray(aVoucherDetails);
					CalculateTotal();
					grdVoucherDetails.Rebind(true);
					grdVoucherDetails.Refresh();
					//''''''''''        If mForm.mPostTransaction = False Then
					//''''''''''            Unload mForm
					//''''''''''            Set mForm = Nothing
					//''''''''''            gConn.RollBackTrans
					//''''''''''            gPayrollGenerateEndDate = ""
					//''''''''''            'mGenerateDate = GetPayrollGenerateDate
					//''''''''''            Exit Sub
					//''''''''''        Else
					//''''''''''            Unload mForm
					//''''''''''            Set mForm = Nothing
					//''''''''''
					//''''''''''            'Call GeneratePayrollGLEntry(Format(mGenerateDate, gSystemDateFormat), mArr)
					//''''''''''            Call GeneratePayrollGLEntry(Format(mMonthEndDate, gSystemDateFormat), mArr)
					//''''''''''
					//''''''''''        End If
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
		//''' To Post GL
		public bool Post()
		{
			//UPGRADE_WARNING: (1068) GetSystemPreferenceSetting() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			int mGLEntryMethod = ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetSystemPreferenceSetting("pay_gl_entry_method"));
			//UPGRADE_WARNING: (1068) txtDPayrollDate.DisplayText of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			string mMonthEndDate = ReflectionHelper.GetPrimitiveValue<string>(txtDPayrollDate.DisplayText);
			if (mGLEntryMethod == 1 || mGLEntryMethod == 2)
			{
				if (ChkGenerateSeprateJv.CheckState == CheckState.Checked)
				{
					GeneratePayrollGLEntry(StringsHelper.Format(mMonthEndDate, SystemVariables.gSystemDateFormat), mArr, 1);
					GeneratePayrollGLEntry(StringsHelper.Format(mMonthEndDate, SystemVariables.gSystemDateFormat), mArr, 2);
				}
				else
				{
					GeneratePayrollGLEntry(StringsHelper.Format(mMonthEndDate, SystemVariables.gSystemDateFormat), mArr);
				}
			}
			else if (mGLEntryMethod == 3)
			{ 
				GenerateTextFile(mGLEntryMethod);
			}
			else if (mGLEntryMethod == 4)
			{ 
				GenerateTextFile(mGLEntryMethod);
			}
			else if (mGLEntryMethod == 5)
			{ 
				GenerateTextFile(mGLEntryMethod);
			}
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

				if (pGLMethod == 3)
				{
					FileSystem.FileClose(1);
					FileSystem.FileOpen(1, mFileName, OpenMode.Output, OpenAccess.Default, OpenShare.Default, -1);
					int tempForEndVar = aVoucherDetails.GetLength(0) - 1;
					for (cnt = 0; cnt <= tempForEndVar; cnt++)
					{
						if (Convert.ToString(aVoucherDetails.GetValue(cnt, grdccPartyCode)) == "000723" || Convert.ToString(aVoucherDetails.GetValue(cnt, grdccPartyCode)) == "00775" || Convert.ToString(aVoucherDetails.GetValue(cnt, grdccPartyCode)) == "000880")
						{
							mCurrencyCd = "USD";
							mExchRate = ReflectionHelper.GetPrimitiveValue<double>(txtNExchangeRate.Value);
						}
						else
						{
							mCurrencyCd = "KWD";
							mExchRate = 1;
						}
						//''          Print #1, InsertDetail3(txtDocType.Text, txtDocNo.Text, txtDocDate.Value, aVoucherDetails(cnt, grdccPartyCode), 0, mCurrencyCd, mExchRate, aVoucherDetails(cnt, grdccServiceCode) _
						//'''          , IIf(aVoucherDetails(cnt, grdccDebit) > 0, aVoucherDetails(cnt, grdccDebit), (aVoucherDetails(cnt, grdccCredit) * -1)) _
						//'''          , IIf(aVoucherDetails(cnt, grdccDebit) > 0, aVoucherDetails(cnt, grdccDebit), (aVoucherDetails(cnt, grdccCredit) * -1)) _
						//'''          , aVoucherDetails(cnt, grdccAccountCode), aVoucherDetails(cnt, grdccDepartmentCode), txtDPayrollDate.DisplayText)
					}
					FileSystem.FileClose(1);
				}
				else if (pGLMethod == 4)
				{ 
					mMonthName = "Salary For the " + DateTimeFormatInfo.CurrentInfo.GetAbbreviatedMonthName(ReflectionHelper.GetPrimitiveValue<System.DateTime>(txtDPayrollDate.Value).Month) + " " + ReflectionHelper.GetPrimitiveValue<System.DateTime>(txtDPayrollDate.Value).Year.ToString();
					FileSystem.FileClose(1);
					FileSystem.FileOpen(1, mFileName, OpenMode.Output, OpenAccess.Default, OpenShare.Default, -1);
					int tempForEndVar2 = aVoucherDetails.GetLength(0) - 1;
					for (cnt = 0; cnt <= tempForEndVar2; cnt++)
					{
						if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("enable_payroll_project")))
						{
							FileSystem.PrintLine(1, SystemHRProcedure.InsertDetail4_1(ReflectionHelper.GetPrimitiveValue<System.DateTime>(txtDPayrollDate.Value).ToString("yyyyMMdd"), cnt + 1, Convert.ToString(aVoucherDetails.GetValue(cnt, grdccAnalysis2)), Convert.ToString(aVoucherDetails.GetValue(cnt, grdccAnalysis3)), Convert.ToString(aVoucherDetails.GetValue(cnt, grdccAnalysis1)), Convert.ToString(aVoucherDetails.GetValue(cnt, grdccAnalysis4)), mMonthName, "JVGEN", (Convert.ToDouble(aVoucherDetails.GetValue(cnt, grdccDebit)) > 0) ? Convert.ToDouble(aVoucherDetails.GetValue(cnt, grdccDebit)) : (Convert.ToDouble(aVoucherDetails.GetValue(cnt, grdccCredit)) * -1)));
						}
						else
						{
							FileSystem.PrintLine(1, SystemHRProcedure.InsertDetail4_2(ReflectionHelper.GetPrimitiveValue<System.DateTime>(txtDPayrollDate.Value).ToString("yyyyMMdd"), Convert.ToString(aVoucherDetails.GetValue(cnt, grdccAnalysis1)), Convert.ToString(aVoucherDetails.GetValue(cnt, grdccAnalysis2)), Convert.ToString(aVoucherDetails.GetValue(cnt, grdccAnalysis3)), Convert.ToString(aVoucherDetails.GetValue(cnt, grdccAnalysis4)), Convert.ToString(aVoucherDetails.GetValue(cnt, grdccAnalysisCd5)), mMonthName, "JV2500", (Convert.ToDouble(aVoucherDetails.GetValue(cnt, grdccDebit)) > 0) ? Convert.ToDouble(aVoucherDetails.GetValue(cnt, grdccDebit)) : (Convert.ToDouble(aVoucherDetails.GetValue(cnt, grdccCredit)) * -1)));
						}
					}
					FileSystem.FileClose(1);
				}
				else if (pGLMethod == 5)
				{ 
					//''''''modified by hakim 27-nov-2012
					mMonthName = "Salary For the " + DateTimeFormatInfo.CurrentInfo.GetAbbreviatedMonthName(ReflectionHelper.GetPrimitiveValue<System.DateTime>(txtDPayrollDate.Value).Month) + " " + ReflectionHelper.GetPrimitiveValue<System.DateTime>(txtDPayrollDate.Value).Year.ToString();
					FileSystem.FileClose(1);
					FileSystem.FileOpen(1, mFileName, OpenMode.Output, OpenAccess.Default, OpenShare.Default, -1);
					int tempForEndVar3 = aVoucherDetails.GetLength(0) - 1;
					for (cnt = 0; cnt <= tempForEndVar3; cnt++)
					{
						if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("enable_payroll_project")))
						{
							//Print #1,
							FileSystem.PrintLine(1, SystemHRProcedure.InsertDetail5(Convert.ToString(aVoucherDetails.GetValue(cnt, grdccAnalysis2)), ReflectionHelper.GetPrimitiveValue<string>(txtDPayrollDate.Value) + "", (Convert.ToDouble(aVoucherDetails.GetValue(cnt, grdccDebit)) > 0) ? Convert.ToDouble(aVoucherDetails.GetValue(cnt, grdccDebit)) : (Convert.ToDouble(aVoucherDetails.GetValue(cnt, grdccCredit)) * -1), Convert.ToString(aVoucherDetails.GetValue(cnt, grdccAnalysis3)), Convert.ToString(aVoucherDetails.GetValue(cnt, grdccAnalysis1)), Convert.ToString(aVoucherDetails.GetValue(cnt, grdccAnalysis4)), mMonthName, "JVGEN", "1", Convert.ToString(aVoucherDetails.GetValue(cnt, grdccAnalysisCd5))));

							//Print #1, InsertDetail5("", "", 0 _
							//                         , 0, aVoucherDetails(cnt, grdccAnalysis1), aVoucherDetails(cnt, grdccAnalysis4), mMonthName, "JVGEN" _
							//                        , "1")
						}
					}
					FileSystem.FileClose(1);
				}
				MessageBox.Show("File Generated Successfully", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			catch (System.Exception excep)
			{
				FileSystem.FileClose(1);
				MessageBox.Show(excep.Message, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			return null;
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
			//If GetSystemPreferenceSetting("pay_gl_entry_method") = 3 Then
			//    mShowAdditionalColumns = True
			//Else
			//    mShowAdditionalColumns = False
			//End If

			int mGLMethod = ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetSystemPreferenceSetting("pay_gl_entry_method"));

			//define voucher grid columns
			SystemGrid.DefineSystemVoucherGrid(grdVoucherDetails, false, false, false, (0xFFFFFF).ToString(), (0x0).ToString(), true, true, C1.Win.C1TrueDBGrid.MarqueeEnum.HighlightRow, 2.4f, 1.4f, "&HB4D9F8", "&HB4D9F8", 280);
			//define voucher grid columns
			//'''If mGLMethod <> 0 Then
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Account No.", 1200, false, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false);
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Account Name", 3000, false);
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Service Code", 1600, false, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, false);
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Account Code", 1600, false, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, false);
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Depart Code", 1600, false, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, false);
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Part Code", 1600, false, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, false);
			//'''ElseIf mGLMethod = 3 Then
			//'''    Call DefineSystemVoucherGridColumn(grdVoucherDetails, "Account No.", 1200, False, , , , False, , , , , , , , False)
			//'''    Call DefineSystemVoucherGridColumn(grdVoucherDetails, "Account Name", 3000, False, , , , , , , , , , , , False)
			//'''    Call DefineSystemVoucherGridColumn(grdVoucherDetails, "Service Code", 1600, False, , , , False)
			//'''    Call DefineSystemVoucherGridColumn(grdVoucherDetails, "Account Code", 1600, False, , , , False)
			//'''    Call DefineSystemVoucherGridColumn(grdVoucherDetails, "Depart Code", 1600, False, , , , False)
			//'''    Call DefineSystemVoucherGridColumn(grdVoucherDetails, "Part Code", 1600, False)
			//'''End If
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Debit", 1500, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Far);
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Credit", 1500, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Far);
			//'''If mGLMethod <> 3 Then
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Cost Code", 1200, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false);
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Cost Name", 1500, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near);
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Analysis1", 1200, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, true, false, false, false, false, 100, "", "", false, "", 0, false, 2202);
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Analysis2", 1200, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, true, false, false, false, false, 100, "", "", false, "", 0, false, 2203);
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Analysis3", 1200, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, true, false, false, false, false, 100, "", "", false, "", 0, false, 2204);
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Analysis4", 1200, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, true, false, false, false, false, 100, "", "", false, "", 0, false, 2205);
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Analysis5", 1200, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, true, false, false, false, false, 100, "", "", false, "", 0, false, 2206);
			//''''ElseIf mGLMethod = 3 Then
			//''''  Call DefineSystemVoucherGridColumn(grdVoucherDetails, "Cost Code", 1200, True, , , dbgRight, False, , , , , , , , False)
			//''''  Call DefineSystemVoucherGridColumn(grdVoucherDetails, "Cost Name", 1500, True, , , dbgLeft, , , , , , , , , False)
			//''''  Call DefineSystemVoucherGridColumn(grdVoucherDetails, "Analysis-1", 1200, True, , , dbgRight, False, , , , , , , , False)
			//''''  Call DefineSystemVoucherGridColumn(grdVoucherDetails, "Analysis-2", 1200, True, , , dbgRight, False, , , , , , , , False)
			//''''  Call DefineSystemVoucherGridColumn(grdVoucherDetails, "Analysis-3", 1200, True, , , dbgRight, False, , , , , , , , False)
			//''''  Call DefineSystemVoucherGridColumn(grdVoucherDetails, "Analysis-4", 1200, True, , , dbgRight, False, , , , , , , , False)
			//''''  Call DefineSystemVoucherGridColumn(grdVoucherDetails, "Analysis-5", 1200, True, , , dbgRight, False, , , , , , , , False)
			//''''End If
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "JVType", 10, false, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, false);
			//Call DefineSystemVoucherGridColumn(grdVoucherDetails, "Comments", 1500, True, , , dbgLeft)

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

			if (mGLMethod != 3)
			{
				lblDocType.Visible = false;
				txtDocType.Visible = false;
				lblDocNo.Visible = false;
				txtDocNo.Visible = false;
				lblDocDate.Visible = false;
				txtDocDate.Visible = false;
				lblExchangeRate.Visible = false;
				txtNExchangeRate.Visible = false;
			}
			else if (mGLMethod == 3)
			{ 
				lblDocType.Visible = true;
				txtDocType.Visible = true;
				lblDocNo.Visible = true;
				txtDocNo.Visible = true;
				lblDocDate.Visible = true;
				txtDocDate.Visible = true;
				lblExchangeRate.Visible = true;
				txtNExchangeRate.Visible = true;
			}

			txtDPayrollDate.Value = StringsHelper.Format(DateTime.Parse(SystemHRProcedure.GetPayrollGenerateStartDate()).AddDays(-1), SystemVariables.gSystemDateFormat);

			aVoucherDetails.RedimXArray(new int[]{-1, -1}, new int[]{-1, -1});
			grdVoucherDetails.Rebind(true);
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

		private void grdVoucherDetails_GotFocus(Object eventSender, EventArgs eventArgs)
		{
			//'''''''Dim mySQL As String
			//'''''''
			//'''''''If mFirstGridFocus = True Then
			//'''''''    'If cmbMastersList.Tag = "" Then
			//'''''''        Call DefineSystemGridCombo(cmbMastersList)
			//'''''''    'End If
			//'''''''
			//'''''''    Call DefineMasterRecordset
			//'''''''    mFirstGridFocus = False
			//'''''''    grdVoucherDetails.PostMsg 1
			//'''''''Else
			//'''''''End If

		}

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBGrid Event grdVoucherDetails.PostEvent was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void grdVoucherDetails_PostEvent(int MsgId)
		{
			//'''''''Dim Col As Integer
			//'''''''
			//'''''''If MsgId = 1 Then
			//'''''''    grdVoucherDetails.Col = gccLdgrNo
			//'''''''    Set cmbMastersList.DataSource = rsLedgerCodeList
			//'''''''ElseIf MsgId = 1001 Then
			//'''''''    grdVoucherDetails.Update
			//'''''''End If


		}

		public void CloseForm()
		{
			this.Close();
		}

		public bool saveRecord()
		{
			string mysql = "";
			object mReturnValue = null;

			int cnt = 0;
			//Dim mApplyCostCenter As Boolean
			string mCCCd = "";
			string mLdgrCd = "";
			int mBillCd = 0;

			grdVoucherDetails.UpdateData();

			if (SystemProcedure2.IsItEmpty(mSearchValue, SystemVariables.DataType.NumberType))
			{
				MessageBox.Show("Select an Employee.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
				return false;
			}

			SystemVariables.gConn.BeginTransaction();

			int tempForEndVar = aVoucherDetails.GetLength(0) - 1;
			for (cnt = 0; cnt <= tempForEndVar; cnt++)
			{
				mBillCd = Convert.ToInt32(aVoucherDetails.GetValue(cnt, gccBillCd));
				if (!SystemProcedure2.IsItEmpty(aVoucherDetails.GetValue(cnt, gccLdgrNo), SystemVariables.DataType.StringType))
				{
					mysql = " select ldgr_cd from gl_ledger ";
					mysql = mysql + " where ldgr_no ='" + Convert.ToString(aVoucherDetails.GetValue(cnt, gccLdgrNo)) + "'";
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (Convert.IsDBNull(mReturnValue))
					{
						//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						SystemVariables.gConn.RollbackTrans();
						MessageBox.Show("Invalid Ledger Code ", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
						goto mError;
					}
					else
					{
						//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mLdgrCd = ReflectionHelper.GetPrimitiveValue<string>(mReturnValue);
						//           mApplyCostCenter = mReturnValue(1)

						if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("cost_center")))
						{
							if (!SystemProcedure2.IsItEmpty(aVoucherDetails.GetValue(cnt, gccCCNo), SystemVariables.DataType.NumberType))
							{
								mysql = "select cost_cd ";
								mysql = mysql + " from gl_cost_centers ";
								mysql = mysql + " where cost_no=" + Convert.ToString(aVoucherDetails.GetValue(cnt, gccCCNo));

								//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
								mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
								//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
								if (!Convert.IsDBNull(mReturnValue))
								{
									//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
									mCCCd = ReflectionHelper.GetPrimitiveValue<string>(mReturnValue);
								}
								else
								{
									//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
									SystemVariables.gConn.RollbackTrans();
									MessageBox.Show("Invalid Cost Center Code", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
									goto mError;
								}
							}
							else
							{
								mCCCd = "";
							}
						}
						else
						{
							mCCCd = "";
						}
					}
				}
				else
				{
					mLdgrCd = "";
					mCCCd = "";
				}

				SystemHRProcedure.UpdateEmployeeGLLinks(mBillCd, ReflectionHelper.GetPrimitiveValue<int>(mSearchValue), mLdgrCd, mCCCd);
			}


			//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.CommitTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			SystemVariables.gConn.CommitTrans();

			MessageBox.Show("Changes Saved Successfully", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);

			return true;

			mError:
			grdVoucherDetails.Bookmark = cnt;
			grdVoucherDetails.Focus();
			//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			SystemVariables.gConn.RollbackTrans();

			return false;
		}


		public bool CheckDataValidity()
		{
			//Check validation during update and add of records

			return true;
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

		private void DefineMasterRecordset()
		{
			//'''''Dim mySQL As String
			//'''''
			//'''''mySQL = "select ldgr_no, "
			//'''''mySQL = mySQL & IIf(gPreferedLanguage = English, "l_ldgr_name as ldgr_name", "a_ldgr_name as ldgr_name")
			//''''''mySql = mySql & " , apply_cost_center "
			//'''''mySQL = mySQL & " from gl_ledger "
			//''''''mySql = mySql & " where gl_ledger.ldgr_type not in ('B-CH', 'B-BA', 'B-SD', 'C-SC') "
			//'''''mySQL = mySQL & " where gl_ledger.type_cd in ("
			//'''''mySQL = mySQL & gGLAssetsLiabilitiesTypeCode
			//'''''mySQL = mySQL & ", " & gGLEmployeeTypeCode
			//'''''mySQL = mySQL & ", " & gGLFixedAssetsTypeCode
			//'''''mySQL = mySQL & ", " & gGLIncomeExpenseTypeCode
			//'''''mySQL = mySQL & ") "
			//'''''mySQL = mySQL & " order by 1 "
			//'''''
			//'''''Set rsLedgerCodeList = New ADODB.Recordset
			//'''''rsLedgerCodeList.CursorLocation = adUseClient
			//'''''rsLedgerCodeList.Open mySQL, gConn, adOpenForwardOnly, adLockReadOnly
			//'''''
			//'''''mySQL = " select cost_no, "
			//'''''mySQL = mySQL & IIf(gPreferedLanguage = English, "l_cost_name as cost_name", "a_cost_name as cost_name")
			//'''''mySQL = mySQL & " from gl_cost_centers "
			//'''''mySQL = mySQL & " order by 1 "
			//'''''
			//'''''Set rsCCCodeList = New ADODB.Recordset
			//'''''rsCCCodeList.CursorLocation = adUseClient
			//'''''rsCCCodeList.Open mySQL, gConn, adOpenForwardOnly, adLockReadOnly

		}

		private void grdVoucherDetails_RowColChange(object eventSender, C1.Win.C1TrueDBGrid.RowColChangeEventArgs eventArgs)
		{
			int LastRow = eventArgs.LastRow;
			int LastCol = eventArgs.LastCol;
			//'''''If grdVoucherDetails.Col > 0 And mFirstGridFocus = False Then
			//'''''    Select Case grdVoucherDetails.Col
			//'''''        Case gccLdgrNo, gccLdgrName
			//'''''            Set cmbMastersList.DataSource = rsLedgerCodeList
			//'''''        Case gccCCNo, gccCCName
			//'''''            Set cmbMastersList.DataSource = rsCCCodeList
			//'''''    End Select
			//'''''End If

			//If grdVoucherDetails.Row <> LastRow Then
			//    If grdVoucherDetails.AddNewMode = dbgNoAddNew Then
			//        If Val(grdVoucherDetails.Columns(gccApplyCostCenter).Value) = True Then
			//            grdVoucherDetails.Columns(gccCCNo).AllowFocus = True
			//        Else
			//            grdVoucherDetails.Columns(gccCCNo).AllowFocus = False
			//        End If
			//    ElseIf grdVoucherDetails.AddNewMode = dbgAddNewCurrent Then
			//    Else                    'if grdVoucherDetails.AddNewMode = dbgAddNewPending
			//        If Val(grdVoucherDetails.Columns(gccApplyCostCenter).Value) = True Then
			//            grdVoucherDetails.Columns(gccCCNo).AllowFocus = True
			//        Else
			//            grdVoucherDetails.Columns(gccCCNo).AllowFocus = False
			//        End If
			//    End If
			//Else
			//    If mFirstGridFocus = True And aVoucherDetails.Count(1) > 0 And IsNull(LastRow) = True Then
			//        If Val(grdVoucherDetails.Columns(gccApplyCostCenter).Value) = True Then
			//            grdVoucherDetails.Columns(gccCCNo).AllowFocus = True
			//        Else
			//            grdVoucherDetails.Columns(gccCCNo).AllowFocus = False
			//        End If
			//    End If
			//End If

		}

		private void GetBillingDetails()
		{
			int cnt = 0;

			string mysql = " select  pbt.bill_cd , pbt.bill_no ";
			mysql = mysql + " , gl_ledger.ldgr_no";
			if (SystemVariables.gPreferedLanguage == SystemVariables.Language.English)
			{
				mysql = mysql + " , gl_ledger.l_ldgr_name ldgr_name , cc.l_cost_name cc_name";
				mysql = mysql + " , pbt.l_bill_name bill_name ";
			}
			else
			{
				mysql = mysql + " , gl_ledger.a_ldgr_name ldgr_name , cc.a_cost_name cc_name ";
				mysql = mysql + " , pbt.a_bill_name bill_name ";
			}
			mysql = mysql + " , case when cc.cost_no=0 then '' else cast(cc.cost_no as varchar) end cost_no ";
			mysql = mysql + " from Pay_Billing_Type pbt ";
			mysql = mysql + " left join pay_employee_GL_Details pegl on pbt.bill_cd = pegl.bill_cd ";
			mysql = mysql + " left join gl_ledger on pegl.ldgr_cd = gl_ledger.ldgr_cd ";
			mysql = mysql + " left join gl_cost_centers cc on pegl.cost_cd = cc.cost_cd ";
			mysql = mysql + " where pegl.emp_cd =" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
			mysql = mysql + " union ";
			mysql = mysql + " select  pbt.bill_cd , pbt.bill_no  , '' , '', '' ";
			if (SystemVariables.gPreferedLanguage == SystemVariables.Language.English)
			{
				mysql = mysql + " , pbt.l_bill_name bill_name ";
			}
			else
			{
				mysql = mysql + " , pbt.a_bill_name bill_name ";
			}
			mysql = mysql + " , '' ";
			mysql = mysql + " from Pay_Billing_Type  pbt ";
			mysql = mysql + " where not exists ( select bill_cd from pay_employee_GL_Details pegl ";
			mysql = mysql + " where pegl.bill_cd = pbt.bill_cd and pegl.emp_cd =" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
			mysql = mysql + " ) ";


			SqlDataReader rsTempRec = null;
			SqlCommand sqlCommand = new SqlCommand(mysql, SystemVariables.gConn);
			rsTempRec = sqlCommand.ExecuteReader();
			rsTempRec.Read();
			do 
			{
				aVoucherDetails.RedimXArray(new int[]{cnt, mMaxArrayCol}, new int[]{0, 0});

				aVoucherDetails.SetValue(rsTempRec["bill_cd"], cnt, gccBillCd);
				aVoucherDetails.SetValue(rsTempRec["bill_no"], cnt, gccBillNo);
				aVoucherDetails.SetValue(rsTempRec["bill_name"], cnt, gccBillName);
				aVoucherDetails.SetValue(Convert.ToString(rsTempRec["ldgr_no"]) + "", cnt, gccLdgrNo);
				aVoucherDetails.SetValue(Convert.ToString(rsTempRec["ldgr_name"]) + "", cnt, gccLdgrName);

				//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				if (grdVoucherDetails.Splits[0].DisplayColumns[gccCCNo].Visible)
				{
					aVoucherDetails.SetValue(Convert.ToString(rsTempRec["cost_no"]) + "", cnt, gccCCNo);
					aVoucherDetails.SetValue(Convert.ToString(rsTempRec["cc_name"]) + "", cnt, gccCCName);
					//aVoucherDetails(cnt, gccApplyCostCenter) = IIf(.Fields("apply_cost_center").Value = 1, True, False)
				}

				cnt++;
			}
			while(rsTempRec.Read());

			grdVoucherDetails.Rebind(true);
			grdVoucherDetails.Refresh();

			try
			{
				grdVoucherDetails.Focus();
			}
			catch
			{
			}

		}

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBGrid Event grdVoucherDetails.FetchCellStyle was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void grdVoucherDetails_FetchCellStyle(int Condition, int Split, object Bookmark, int Col, C1.Win.C1TrueDBGrid.Style CellStyle)
		{
			//If (Col = gccCCNo Or Col = gccCCName) And aVoucherDetails.Count(1) > 1 Then
			//    If aVoucherDetails(Bookmark, gccApplyCostCenter) = True Then
			//        CellStyle.BackColor = grdVoucherDetails.Columns(gccLdgrNo).BackColor
			//        CellStyle.ForeColor = grdVoucherDetails.Columns(gccLdgrNo).ForeColor
			//        grdVoucherDetails.Columns(gccCCNo).AllowFocus = True
			//        grdVoucherDetails.Columns(gccCCName).AllowFocus = True
			//    Else
			//        CellStyle.BackColor = gDisableColumnBackColor
			//        CellStyle.ForeColor = gDisableColumnBackColor
			//        grdVoucherDetails.Columns(gccCCNo).AllowFocus = False
			//        grdVoucherDetails.Columns(gccCCName).AllowFocus = False
			//    End If
			//End If
		}

		public void findRecord()
		{
			//Call the find window

			//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(7050000));
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(mTempSearchValue))
			{
				//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mSearchValue = ReflectionHelper.GetPrimitiveValue(((Array) mTempSearchValue).GetValue(0));
				GetRecord(mSearchValue);
			}
		}

		public void GetRecord(object SearchValue)
		{
			//On Error GoTo eFoundError



			string mysql = " select pe.emp_no ";
			if (SystemVariables.gPreferedLanguage == SystemVariables.Language.English)
			{
				mysql = mysql + " , pe.l_first_name + ' ' + pe.l_second_name + ' ' + pe.l_fourth_name emp_name ";
			}
			else
			{
				mysql = mysql + " , pe.a_first_name + ' ' + pe.a_second_name + ' ' + pe.a_fourth_name emp_name ";
			}
			mysql = mysql + " from Pay_employee pe ";
			mysql = mysql + " where pe.emp_cd = " + ReflectionHelper.GetPrimitiveValue<string>(SearchValue);
			//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(mReturnValue))
			{
				//''' Compile error
				//    txtEmpCode.Text = mReturnValue(0)
				//    txtEmpName.Text = mReturnValue(1)

				GetBillingDetails();
				grdVoucherDetails.Enabled = true;
				grdVoucherDetails.Focus();
			}

			return;

			//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
			SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, Information.Err().Description, this.Name, "GetRecord");
		}



		private bool GetPayrollEntryInfoIntoArray(string pVoucherDate)
		{
			bool result = false;
			StringBuilder mysql = new StringBuilder();
			SqlDataReader rsTempRec = null;
			DataSet rsTempRec1 = null;
			string mPrevPayrollDate = ""; // this variable is declared bcoz the month is closed and pay_payroll_generate_history has been updated for next month
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
			int mLeaveEncashmentBillCd = 0;

			try
			{

				mArr = new XArrayHelper();

				mPrevPayrollDate = DateTimeHelper.ToString(DateTime.Parse(pVoucherDate)); //DateAdd("m", -1, Format(GetPayrollGenerateDate, "mm-yyyy"))
				mSecondLastPayrollDate = DateTimeHelper.ToString(DateTime.Parse(pVoucherDate).AddDays(1).AddMonths(-1).AddDays(-1));
				//UPGRADE_WARNING: (1068) GetSystemPreferenceSetting() of type Variant is being forced to bool. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mEnableProject = ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("enable_payroll_project"));

				if (SystemProcedure2.IsItEmpty(txtCompanyCode.Text, SystemVariables.DataType.NumberType))
				{
					mComCd = 0;
				}

				mJvType = 0;
				//UPGRADE_WARNING: (1068) GetSystemPreferenceSetting() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				pGLMethod = ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetSystemPreferenceSetting("pay_gl_entry_method"));
				if (pGLMethod != 0)
				{
					//ElseIf GetSystemPreferenceSetting("pay_gl_entry_method") = 2 Then
					mysql = new StringBuilder(" select pemp.emp_cd ,pbt.bill_cd , pbt.bill_type_id  ");
					mysql.Append("   , glinfo.ldgr_cd ");
					mysql.Append("   , gl_ledger.ldgr_no , cc.cost_no , l_ldgr_name ldgr_name ");
					mysql.Append("   , l_cost_name cost_name , glinfo.cost_cd ");
					if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("enable_payroll_project")))
					{
						mysql.Append("   ,(sum(case  when pppd.pay_hours is null then round(pp.lc_amount,3)");
						mysql.Append("   else case  when pppd.pay_hours = 0 then round(pp.lc_amount,3)");
						mysql.Append("   else round((pp.lc_amount/ppp.pay_hours)*pppd.pay_hours,3)");
						mysql.Append("    End");
						mysql.Append("   end)) lc_amount , gp.project_no as analysis1_cd ");
						if (pGLMethod == 4)
						{
							mysql.Append(" , case when pemp.hold_salary = 0 then analysis2_cd else analysis5_cd end as analysis2_cd");
						}
						else
						{
							mysql.Append(" , analysis2_cd ");
						}
						mysql.Append(" , analysis3_cd , analysis4_cd , analysis5_cd , dgp.project_no");
					}
					else
					{
						mysql.Append("   , sum(lc_amount) lc_amount ,analysis1_cd  , analysis2_cd , analysis3_cd , analysis4_cd , analysis5_cd ");
					}
					mysql.Append("   from Pay_Payroll pp ");
					mysql.Append("   inner join pay_billing_type pbt on pp.bill_cd = pbt.bill_cd ");
					mysql.Append("   inner join pay_employee pemp on pp.emp_cd = pemp.emp_cd ");
					mysql.Append("   left join pay_employee_gl_details glinfo ");
					mysql.Append("   on pemp.emp_cd = glinfo.emp_cd  and pp.bill_cd = glinfo.bill_cd ");
					mysql.Append("   left join gl_ledger on glinfo.ldgr_cd = gl_ledger.ldgr_cd ");
					mysql.Append("   left join gl_cost_centers cc on glinfo.cost_cd = cc.cost_cd ");
					if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("enable_payroll_project")))
					{
						mysql.Append("   left join pay_project_payroll ppp  on pp.emp_cd  = ppp.emp_cd and pp.bill_cd = ppp.bill_cd and pp.pay_date = ppp.pay_date ");
						mysql.Append("   left join pay_project_payroll_details pppd on ppp.entry_id = pppd.entry_id");
						mysql.Append("   left join gl_projects gp on pppd.project_cd = gp.project_cd ");
						mysql.Append("   left join gl_projects dgp on pemp.default_project = dgp.project_cd ");
					}
					mysql.Append("   where pp.pay_date = '" + pVoucherDate + "' and pp.lc_amount > 0 ");

					//''commented by hakim on 15-dec-2012
					//''this was done for kharafi as terminated employees were not coming while generating the GL entry for previous month
					//mySql = mySql & " and pemp.status_cd Not in (3,4)"
					if (mComCd != 0)
					{
						mysql.Append(" and pemp.comp_cd = " + mComCd.ToString());
					}
					if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("enable_payroll_project")))
					{
						mysql.Append(" and (ppp.pay_date ='" + pVoucherDate + "' or ppp.pay_date is null)");
					}
					mysql.Append("   group by pemp.emp_cd ,pbt.bill_cd , pbt.bill_type_id ");
					mysql.Append("   , glinfo.ldgr_cd  , gl_ledger.ldgr_no , cc.cost_no , l_ldgr_name ");
					mysql.Append("   , l_cost_name , glinfo.cost_cd ");
					mysql.Append("   ,analysis1_cd  , analysis2_cd , analysis3_cd , analysis4_cd , analysis5_cd , hold_salary ");
					if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("enable_payroll_project")))
					{
						mysql.Append(" , gp.project_no , dgp.project_no");
					}
					//ElseIf GetSystemPreferenceSetting("pay_gl_entry_method") = 3 Then
				}
				else
				{
					mysql = new StringBuilder("");
				}

				if (mysql.ToString() != "")
				{
					SqlCommand sqlCommand = new SqlCommand(mysql.ToString(), SystemVariables.gConn);
					rsTempRec = sqlCommand.ExecuteReader();

					if (rsTempRec.Read())
					{
						do 
						{
							if (ChkGenerateSeprateJv.CheckState == CheckState.Checked)
							{
								mJvType = 1;
							}
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
									else if (!SystemProcedure2.IsItEmpty(rsTempRec["project_No"], SystemVariables.DataType.StringType))
									{ 
										mAnalysisCd1 = Convert.ToString(rsTempRec["project_No"]);
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
								mysql = new StringBuilder("select pemp.emp_cd ,pbt.bill_cd , pbt.bill_type_id ");
								mysql.Append("  , gltab.ldgr_cd , gltab.cost_cd ");
								mysql.Append("  , gl_ledger.ldgr_no , cc.cost_no ");
								if (SystemVariables.gPreferedLanguage == SystemVariables.Language.English)
								{
									mysql.Append(", l_ldgr_name ldgr_name, l_cost_name cost_name");
								}
								else
								{
									mysql.Append(", a_ldgr_name ldgr_name, a_cost_name cost_name ");
								}
								mysql.Append("  , analysis2_cd  ,  analysis3_cd ,  analysis4_cd ,  analysis5_cd");
								if (mEnableProject)
								{
									mysql.Append(" , gp.project_no as analysis1_cd");
								}
								else
								{
									mysql.Append(" , analysis1_cd");
								}
								mysql.Append("  from pay_billing_type pbt");
								mysql.Append("  left join pay_employee_gl_details gltab on pbt.bill_cd = gltab.bill_cd ");
								mysql.Append("  left join pay_employee pemp on pemp.emp_cd = gltab.emp_cd ");
								mysql.Append("  left join gl_ledger on gltab.ldgr_cd = gl_ledger.ldgr_cd ");
								mysql.Append("  left join gl_cost_centers cc on gltab.cost_cd = cc.cost_cd   ");
								if (mEnableProject)
								{
									mysql.Append(" left join gl_projects gp on gp.project_cd = pemp.Default_project");
								}
								mysql.Append("  where pbt.bill_cd = 10 and pemp.emp_cd = " + Convert.ToString(rsTempRec["emp_cd"]));
								mysql.Append(" group by pemp.emp_cd, pbt.bill_cd, pbt.bill_type_id , gltab.ldgr_cd , gltab.cost_cd  ");
								mysql.Append(" , gl_ledger.ldgr_no , cc.cost_no , l_ldgr_name, l_cost_name , a_ldgr_name , a_cost_name");
								mysql.Append("  , analysis2_cd  ,  analysis3_cd ,  analysis4_cd ,  analysis5_cd   ");
								if (mEnableProject)
								{
									mysql.Append(" , gp.project_no");
								}
								else
								{
									mysql.Append(" , analysis1_cd");
								}
							}
							else
							{
								mysql = new StringBuilder("");
							}

							if (mysql.ToString() != "")
							{
								rsTempRec1 = new DataSet();
								SqlDataAdapter adap_2 = new SqlDataAdapter(mysql.ToString(), SystemVariables.gConn);
								rsTempRec1.Tables.Clear();
								adap_2.Fill(rsTempRec1);

								if (rsTempRec1.Tables[0].Rows.Count != 0)
								{
									if (ChkGenerateSeprateJv.CheckState == CheckState.Checked)
									{
										mJvType = 1;
									}
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

				//'' Leave Encashment Amount
				//UPGRADE_WARNING: (1068) GetSystemPreferenceSetting() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mLeaveEncashmentBillCd = ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetSystemPreferenceSetting("Leave_Encashment_BillCd"));
				if (mLeaveEncashmentBillCd == 0)
				{
					mLeaveEncashmentBillCd = 10;
				}

				if (pGLMethod != 3)
				{
					mysql = new StringBuilder(" select pemp.emp_cd , pld.Leave_Amount");
					mysql.Append("       , pegd.Ldgr_Cd , gl_ledger.ldgr_no , gl_ledger.L_Ldgr_Name , pegd.Cost_Cd ,cc.Cost_No , cc.L_Cost_Name");
					if (mEnableProject)
					{
						mysql.Append("       ,pemp.default_project , gp.project_no");
					}
					else
					{
						mysql.Append("       ,pegd.Analysis1_Cd as default_project ,pegd.Analysis1_Cd as project_no ");
					}
					mysql.Append("       ,pegd.Analysis2_Cd , pegd.Analysis3_Cd , pegd.Analysis4_Cd , pegd.Analysis5_Cd");
					mysql.Append(" from pay_Employee pemp");
					mysql.Append(" inner join pay_leave_adjustment pld on pemp.emp_cd = pld.emp_cd");
					mysql.Append(" inner join pay_leave pl on pl.leave_cd = pld.leave_cd");
					mysql.Append(" inner join pay_employee_gl_details pegd on pegd.bill_cd = pl.earning_bill_cd and pld.emp_cd = pegd.emp_cd");
					mysql.Append(" left join gl_ledger on pegd.ldgr_cd = gl_ledger.ldgr_cd");
					mysql.Append(" left join gl_cost_centers cc on pegd.cost_cd = cc.cost_cd");
					mysql.Append(" left join gl_projects gp on gp.project_cd = pemp.Default_project");
					mysql.Append(" where Voucher_Date > '" + StringsHelper.Format(mSecondLastPayrollDate, SystemVariables.gSystemDateFormat) + "' and Voucher_Date <= '" + StringsHelper.Format(mPrevPayrollDate, SystemVariables.gSystemDateFormat) + "'");
					if (mComCd != 0)
					{
						mysql.Append(" and pemp.comp_cd = " + mComCd.ToString());
					}
					mysql.Append(" and Trans_Type = 150 ");
					mysql.Append(" Union All");
					mysql.Append(" select pemp.emp_cd , (pld.Leave_Amount * -1) ");
					mysql.Append("       , pegd.Ldgr_Cd , gl_ledger.ldgr_no , gl_ledger.L_Ldgr_Name , pegd.Cost_Cd ,cc.Cost_No , cc.L_Cost_Name");
					if (mEnableProject)
					{
						mysql.Append("       ,pemp.default_project , gp.project_no");
					}
					else
					{
						mysql.Append("       ,pegd.Analysis1_Cd as default_project ,pegd.Analysis1_Cd as project_no ");
					}
					mysql.Append("       ,pegd.Analysis2_Cd , pegd.Analysis3_Cd , pegd.Analysis4_Cd , pegd.Analysis5_Cd");
					mysql.Append(" from pay_Employee pemp");
					mysql.Append(" inner join pay_leave_adjustment pld on pemp.emp_cd = pld.emp_cd");
					mysql.Append(" inner join pay_employee_gl_details pegd on pegd.bill_cd = " + mLeaveEncashmentBillCd.ToString() + " and pld.emp_cd = pegd.emp_cd");
					mysql.Append(" left join gl_ledger on pegd.ldgr_cd = gl_ledger.ldgr_cd");
					mysql.Append(" left join gl_cost_centers cc on pegd.cost_cd = cc.cost_cd");
					mysql.Append(" left join gl_projects gp on gp.project_cd = pemp.Default_project");
					mysql.Append(" where Voucher_Date > '" + StringsHelper.Format(mSecondLastPayrollDate, SystemVariables.gSystemDateFormat) + "' and Voucher_Date <= '" + StringsHelper.Format(mPrevPayrollDate, SystemVariables.gSystemDateFormat) + "'");
					if (mComCd != 0)
					{
						mysql.Append(" and pemp.comp_cd = " + mComCd.ToString());
					}
					mysql.Append(" and Trans_Type = 150 ");
					mysql.Append(" order by pemp.emp_cd");
				}
				else
				{
					mysql = new StringBuilder("");
				}

				if (mysql.ToString() != "")
				{
					SqlCommand sqlCommand_3 = new SqlCommand(mysql.ToString(), SystemVariables.gConn);
					rsTempRec = sqlCommand_3.ExecuteReader();
					bool rsTempRecDidRead2 = rsTempRec.Read();

					if (rsTempRecDidRead)
					{
						do 
						{
							if (Convert.IsDBNull(rsTempRec["ldgr_cd"]))
							{
								DisplayError(Convert.ToInt32(rsTempRec["emp_cd"]));
								throw new Exception();
							}
							else
							{
								mLdgrCd = Convert.ToString(rsTempRec["ldgr_cd"]);
								mLdgrNo = Convert.ToString(rsTempRec["ldgr_no"]);
								mLdgrName = Convert.ToString(rsTempRec["L_Ldgr_Name"]);
								mProjectNo = "";
								if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("cost_center")))
								{
									if (Convert.IsDBNull(rsTempRec["cost_cd"]))
									{
										DisplayError(Convert.ToInt32(rsTempRec["emp_cd"]));
										throw new Exception();
									}
									else
									{
										mCostCd = Convert.ToString(rsTempRec["cost_cd"]);
										mCostNo = Convert.ToString(rsTempRec["cost_no"]);
										mCostName = Convert.ToString(rsTempRec["L_Cost_Name"]);
									}
								}
								else
								{
									mCostCd = "";
									mCostNo = "";
									mCostName = "";
								}
								if (!SystemProcedure2.IsItEmpty(rsTempRec["default_project"], SystemVariables.DataType.StringType))
								{
									mAnalysisCd1 = Convert.ToString(rsTempRec["project_no"]);
									mProjectNo = Convert.ToString(rsTempRec["project_no"]);
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

							if (Convert.ToDouble(rsTempRec["Leave_Amount"]) > 0)
							{
								mDrCr = "D";
							}
							else
							{
								mDrCr = "C";
							}

							mAmount = Convert.ToDouble(rsTempRec["Leave_Amount"]);

							if (mDrCr == "D")
							{
								InsertIntoArray(cnt, mLdgrNo, mLdgrName, (decimal) mAmount, 0, mCostNo, mCostName, mLdgrCd, mCostCd, conLeaveProvisionComments, "", "", "", "", mAnalysisCd1, mAnalysisCd2, 1, mProjectNo, mAnalysisCd3, mAnalysisCd4, mAnalysisCd5);
							}
							else
							{
								InsertIntoArray(cnt, mLdgrNo, mLdgrName, 0, (decimal) Math.Abs(mAmount), mCostNo, mCostName, mLdgrCd, mCostCd, conLeaveProvisionComments, "", "", "", "", mAnalysisCd1, mAnalysisCd2, 1, mProjectNo, mAnalysisCd3, mAnalysisCd4, mAnalysisCd5);
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

				//''Staff Leave expenses a/c   dr
				//''     To Leave provision  a/c

				if (pGLMethod != 3)
				{
					//ElseIf GetSystemPreferenceSetting("pay_gl_entry_method") = 2 Then
					mysql = new StringBuilder(" select sum(case when plas.plas_year = " + DateTime.Parse(mPrevPayrollDate).Year.ToString() + " and plas.plas_month = " + DateTime.Parse(mPrevPayrollDate).Month.ToString() + " then plas_curr_accru_lc_amount ");
					mysql.Append(" when plas.plas_year = " + DateTime.Parse(mSecondLastPayrollDate).Year.ToString() + " and plas.plas_month = " + DateTime.Parse(mSecondLastPayrollDate).Month.ToString());
					mysql.Append(" then (dbo.payLeaveAmount(gltab.emp_cd,pl.leave_Cd,plas.plas_cumm_accrued_days, '" + mSecondLastPayrollDate + "' ) - plas_cumm_accrued_amt) end) * -1 as  lc_amount ");
					mysql.Append(" ,gltab.ldgr_cd, gltab.cost_cd , gltab.emp_cd as emp_dept_cd  , gl_ledger.ldgr_no , cc.cost_no , l_ldgr_name ldgr_name ");
					mysql.Append(" , l_cost_name cost_name, 1 as sorder  ");
					if (mEnableProject)
					{
						mysql.Append(" , '' as default_project , gp.project_no as project_no ");
					}
					else
					{
						mysql.Append(" , '' as default_project , gltab.analysis1_cd as project_no ");
					}
					mysql.Append(" ,   gltab.analysis2_cd ,  gltab.analysis3_cd ,  gltab.analysis4_cd ,  gltab.analysis5_cd , 0 as pay_hours , 0 as payHours"); //, percentage
					mysql.Append(" from PAY_LEAVE_ACCRUAL_SUMMARY plas  ");
					mysql.Append(" inner join pay_employee pemp on plas.plas_emp_cd = pemp.emp_cd  ");
					mysql.Append(" inner join pay_employee_leave_details peld on peld.emp_cd = pemp.emp_Cd ");
					mysql.Append(" inner join pay_leave pl on pl.leave_cd = peld.leave_cd ");
					mysql.Append(" inner join pay_employee_gl_details gltab on pemp.emp_cd = gltab.emp_cd ");
					mysql.Append(" left join gl_ledger on gltab.ldgr_cd = gl_ledger.ldgr_cd  ");
					mysql.Append(" left join gl_cost_centers cc on gltab.cost_cd = cc.cost_cd ");
					if (mEnableProject)
					{
						mysql.Append(" left join gl_projects gp on pemp.default_project = gp.project_cd");
					}
					mysql.Append(" Where   (gltab.bill_cd = 5)  ");
					mysql.Append(" and ((plas.plas_year = " + DateTime.Parse(mPrevPayrollDate).Year.ToString());
					mysql.Append(" and plas.plas_month =  " + DateTime.Parse(mPrevPayrollDate).Month.ToString() + ") ");
					mysql.Append(" or (plas.plas_year = " + DateTime.Parse(mSecondLastPayrollDate).Year.ToString());
					mysql.Append(" and plas.plas_month =  " + DateTime.Parse(mSecondLastPayrollDate).Month.ToString() + "))");
					mysql.Append(" and plas.plas_curr_accru_lc_amount > 0 and pl.leave_type_cd = 6  ");

					//''commented by hakim on 15-dec-2012
					//''this was done for kharafi as terminated employees were not coming while generating the GL entry for previous month
					//    mySql = mySql & " and pemp.status_cd not in (3,4)"

					if (mComCd != 0)
					{
						mysql.Append(" and pemp.comp_cd = " + mComCd.ToString());
					}
					mysql.Append(" group by gltab.ldgr_cd,gltab.cost_cd , gltab.emp_cd, gl_ledger.ldgr_no , cc.cost_no , l_ldgr_name, l_cost_name   ");
					mysql.Append(" ,   gltab.analysis2_cd ,  gltab.analysis3_cd ,  gltab.analysis4_cd ,  gltab.analysis5_cd ");
					if (mEnableProject)
					{
						mysql.Append(" , gp.project_no");
					}
					else
					{
						mysql.Append(" , gltab.analysis1_cd");
					}
					mysql.Append(" union all  ");
					mysql.Append(" select sum(case when plas.plas_year = " + DateTime.Parse(mPrevPayrollDate).Year.ToString() + "  and plas.plas_month = " + DateTime.Parse(mPrevPayrollDate).Month.ToString() + "  then plas_curr_accru_lc_amount");
					mysql.Append(" when plas.plas_year = " + DateTime.Parse(mSecondLastPayrollDate).Year.ToString() + " and plas.plas_month = " + DateTime.Parse(mSecondLastPayrollDate).Month.ToString() + " then (dbo.payLeaveAmount(gltab.emp_cd,pl.leave_Cd,plas.plas_cumm_accrued_days, '" + mSecondLastPayrollDate + "' ) - plas_cumm_accrued_amt) end)  as  lc_amount");
					mysql.Append("   , gltab.ldgr_cd, gltab.cost_cd  , gltab.emp_cd as emp_dept_cd  , gl_ledger.ldgr_no , cc.cost_no , l_ldgr_name ldgr_name ");
					mysql.Append("   , l_cost_name cost_name, 2 as sorder  ");
					if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("enable_payroll_project")))
					{
						mysql.Append(" ,dgp.project_no as default_project , gp.project_no , gltab.analysis2_cd ,  gltab.analysis3_cd ,  gltab.analysis4_cd ,  gltab.analysis5_cd , isnull(pppd.pay_hours,0) as pay_hours , isnull(ppp.pay_hours,0) as payHours");
					}
					else
					{
						mysql.Append(" ,'' as default_project , gltab.analysis1_cd  , gltab.analysis2_cd ,  gltab.analysis3_cd ,  gltab.analysis4_cd ,  gltab.analysis5_cd , '' as pay_hours, '' as payHours");
					}
					mysql.Append(" from PAY_LEAVE_ACCRUAL_SUMMARY plas  ");
					mysql.Append(" inner join pay_employee pemp on plas.plas_emp_cd = pemp.emp_cd  ");
					mysql.Append(" inner join pay_employee_leave_details peld on peld.emp_cd = pemp.emp_Cd ");
					mysql.Append(" inner join pay_leave pl on pl.leave_cd = peld.leave_cd ");
					mysql.Append(" inner join pay_employee_gl_details gltab on pemp.emp_cd = gltab.emp_cd ");
					mysql.Append(" left join gl_ledger on gltab.ldgr_cd = gl_ledger.ldgr_cd  ");
					mysql.Append(" left join gl_cost_centers cc on gltab.cost_cd = cc.cost_cd ");
					if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("enable_payroll_project")))
					{
						mysql.Append(" left join pay_project_payroll ppp  on gltab.emp_cd = ppp.emp_cd and gltab.bill_cd = ppp.bill_cd ");
						mysql.Append(" left join pay_project_payroll_details pppd on ppp.entry_id = pppd.entry_id ");
						mysql.Append(" left join gl_projects gp on pppd.project_cd = gp.project_cd ");
						mysql.Append(" left join gl_projects dgp on pemp.default_project = dgp.project_cd ");
					}
					mysql.Append(" Where   (gltab.bill_cd = 7) ");
					mysql.Append(" and ((plas.plas_year = " + DateTime.Parse(mPrevPayrollDate).Year.ToString());
					mysql.Append(" and plas.plas_month =  " + DateTime.Parse(mPrevPayrollDate).Month.ToString() + ") ");
					mysql.Append(" or (plas.plas_year = " + DateTime.Parse(mSecondLastPayrollDate).Year.ToString());
					mysql.Append(" and plas.plas_month =  " + DateTime.Parse(mSecondLastPayrollDate).Month.ToString() + "))");
					mysql.Append(" and plas.plas_curr_accru_lc_amount > 0 and pl.leave_type_cd = 6  ");
					if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("enable_payroll_project")))
					{
						mysql.Append(" and (ppp.pay_date = '" + pVoucherDate + "' or ppp.pay_date is null)");
					}

					//''commented by hakim on 15-dec-2012
					//''this was done for kharafi as terminated employees were not coming while generating the GL entry for previous month
					//    mySql = mySql & " and pemp.status_cd not in (3,4)"

					if (mComCd != 0)
					{
						mysql.Append(" and pemp.comp_cd = " + mComCd.ToString());
					}
					mysql.Append(" group by gltab.ldgr_cd,gltab.cost_cd , gltab.emp_cd, gl_ledger.ldgr_no , cc.cost_no , l_ldgr_name, l_cost_name ");
					if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("enable_payroll_project")))
					{
						mysql.Append(" ,dgp.project_no ,gp.project_no ,  analysis2_cd ,  analysis3_cd ,  analysis4_cd ,  analysis5_cd , isnull(pppd.pay_hours,0) , isnull(ppp.pay_hours,0)   ");
					}
					else
					{
						mysql.Append(" , analysis1_cd  ,  analysis2_cd ,  analysis3_cd ,  analysis4_cd ,  analysis5_cd ");
					}

					mysql.Append(" order by gltab.emp_cd, sorder ");
				}
				else
				{
					mysql = new StringBuilder("");
				}

				if (mysql.ToString() != "")
				{

					SqlCommand sqlCommand_4 = new SqlCommand(mysql.ToString(), SystemVariables.gConn);
					rsTempRec = sqlCommand_4.ExecuteReader();
					bool rsTempRecDidRead3 = rsTempRec.Read();

					if (rsTempRecDidRead)
					{
						do 
						{
							if (ChkGenerateSeprateJv.CheckState == CheckState.Checked)
							{
								mJvType = 2;
							}
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
				int tempForEndVar3 = mArr.GetLength(0) - 1;
				for (cnt = 0; cnt <= tempForEndVar3; cnt++)
				{
					mDR += Convert.ToDouble(mArr.GetValue(cnt, gccDebit));
					mCr += Convert.ToDouble(mArr.GetValue(cnt, gccCredit));
				}
				//''Staff Indemnity expenses a/c   dr
				//''     To Indemnity provision  a/c

				if (pGLMethod != 3)
				{
					//ElseIf GetSystemPreferenceSetting("pay_gl_entry_method") = 2 Then
					//mySQL = " select pias_curr_accru_lc_amount lc_amount  "
					mysql = new StringBuilder(" select sum(case when pias.pias_year = " + DateTime.Parse(mPrevPayrollDate).Year.ToString() + " and pias.pias_month = " + DateTime.Parse(mPrevPayrollDate).Month.ToString() + " then pias_curr_accru_lc_amount ");
					mysql.Append(" when pias.pias_year = " + DateTime.Parse(mSecondLastPayrollDate).Year.ToString() + " and pias.pias_month = " + DateTime.Parse(mSecondLastPayrollDate).Month.ToString());
					mysql.Append(" then (dbo.payIndemnityAmount(gltab.emp_cd,pias.pias_cumm_accrued_days, '" + mSecondLastPayrollDate + "' ) - pias_cumm_accrued_amt) end) * -1 as  lc_amount ");
					mysql.Append(" ,gltab.ldgr_cd, gltab.cost_cd , gltab.emp_cd as emp_dept_cd");
					mysql.Append("   , gl_ledger.ldgr_no , cc.cost_no , l_ldgr_name ldgr_name, l_cost_name cost_name, 1 as sorder");
					if (mEnableProject)
					{
						mysql.Append(" ,'' as default_project , gp.project_no");
					}
					else
					{
						mysql.Append(" ,''  as default_project  , gltab.analysis1_cd  as project_no ");
					}
					mysql.Append("  , gltab.analysis2_cd , gltab.analysis3_cd , gltab.analysis4_cd , gltab.analysis5_cd  , 0 as pay_hours , 0 as payHours");
					mysql.Append(" from PAY_INDEMNITY_ACCRUAL_SUMMARY pias");
					mysql.Append(" inner join pay_employee pemp on pias.pias_emp_cd = pemp.emp_cd");
					mysql.Append(" inner join pay_nationality pn on pn.nat_cd = pemp.nat_cd ");
					mysql.Append(" inner join pay_employee_gl_details gltab on pemp.emp_cd = gltab.emp_cd");
					mysql.Append(" left join gl_ledger on gltab.ldgr_cd = gl_ledger.ldgr_cd ");
					mysql.Append(" left join gl_cost_centers cc on gltab.cost_cd = cc.cost_cd ");
					if (mEnableProject)
					{
						mysql.Append(" left join gl_projects gp on gp.project_cd = pemp.Default_project");
					}
					mysql.Append(" Where (gltab.bill_cd = 8) ");
					mysql.Append(" and ((pias.pias_year = " + DateTime.Parse(mPrevPayrollDate).Year.ToString());
					mysql.Append(" and pias.pias_month =  " + DateTime.Parse(mPrevPayrollDate).Month.ToString() + ") ");
					mysql.Append(" or (pias.pias_year = " + DateTime.Parse(mSecondLastPayrollDate).Year.ToString());
					mysql.Append(" and pias.pias_month =  " + DateTime.Parse(mSecondLastPayrollDate).Month.ToString() + "))");
					mysql.Append(" and pias.pias_curr_accru_lc_amount> 0 ");

					//''commented by hakim on 15-dec-2012
					//''this was done for kharafi as terminated employees were not coming while generating the GL entry for previous month
					//mySql = mySql & " and pemp.status_cd not in (3,4)"

					mysql.Append(" and pn.Allocate_Provision <> 1 ");
					if (mComCd != 0)
					{
						mysql.Append(" and pemp.comp_cd = " + mComCd.ToString());
					}
					mysql.Append(" group by gltab.ldgr_cd,gltab.cost_cd , gltab.emp_cd, gl_ledger.ldgr_no , cc.cost_no , l_ldgr_name, l_cost_name");
					if (mEnableProject)
					{
						mysql.Append(" ,gp.project_no ,  analysis2_cd ,  analysis3_cd ,  analysis4_cd ,  analysis5_cd ");
					}
					else
					{
						mysql.Append(" , analysis1_cd  ,  analysis2_cd ,  analysis3_cd ,  analysis4_cd ,  analysis5_cd ");
					}
					mysql.Append(" Union All ");
					//mySQL = mySQL & " select (pias_curr_accru_lc_amount * -1) lc_amount  "
					mysql.Append(" select sum(case when pias.pias_year = " + DateTime.Parse(mPrevPayrollDate).Year.ToString() + " and pias.pias_month = " + DateTime.Parse(mPrevPayrollDate).Month.ToString() + " then pias_curr_accru_lc_amount ");
					mysql.Append(" when pias.pias_year = " + DateTime.Parse(mSecondLastPayrollDate).Year.ToString() + " and pias.pias_month = " + DateTime.Parse(mSecondLastPayrollDate).Month.ToString());
					mysql.Append(" then (dbo.payIndemnityAmount(gltab.emp_cd,pias.pias_cumm_accrued_days, '" + mSecondLastPayrollDate + "' ) - pias_cumm_accrued_amt) end)  as  lc_amount ");
					mysql.Append(" , gltab.ldgr_cd, gltab.cost_cd  , gltab.emp_cd as emp_dept_cd ");
					mysql.Append("   , gl_ledger.ldgr_no , cc.cost_no , l_ldgr_name ldgr_name, l_cost_name cost_name, 2 as sorder ");
					if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("enable_payroll_project")))
					{
						mysql.Append(" ,dgp.project_no as Default_Project ,  gp.project_no ,  analysis2_cd ,  analysis3_cd ,  analysis4_cd ,  analysis5_cd  , isnull(pppd.pay_hours,0) as pay_hours, isnull(ppp.pay_hours,0) as payHours   ");
					}
					else
					{
						mysql.Append(" , '' as default_project , analysis1_cd as project_no  ,  analysis2_cd ,  analysis3_cd ,  analysis4_cd ,  analysis5_cd  , '' as pay_hours, '' as payHours");
					}
					mysql.Append(" from PAY_INDEMNITY_ACCRUAL_SUMMARY pias ");
					mysql.Append(" inner join pay_employee pemp on pias.pias_emp_cd = pemp.emp_cd ");
					mysql.Append(" inner join pay_nationality pn on pn.nat_cd = pemp.nat_cd ");
					mysql.Append(" inner join pay_employee_gl_details gltab on pemp.emp_cd = gltab.emp_cd");
					mysql.Append(" left join gl_ledger on gltab.ldgr_cd = gl_ledger.ldgr_cd");
					mysql.Append(" left join gl_cost_centers cc on gltab.cost_cd = cc.cost_cd");
					if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("enable_payroll_project")))
					{
						mysql.Append(" left join pay_project_payroll ppp  on gltab.emp_cd = ppp.emp_cd and gltab.bill_cd = ppp.bill_cd ");
						//and year(ppp.pay_date) = pias.pias_year  and month(ppp.pay_date) = pias.pias_month"
						mysql.Append(" left join pay_project_payroll_details pppd on ppp.entry_id = pppd.entry_id ");
						mysql.Append(" left join gl_projects gp on pppd.project_cd = gp.project_cd ");
						mysql.Append(" left join gl_projects dgp on pemp.default_project = dgp.project_cd ");
					}
					mysql.Append(" Where (gltab.bill_cd = 9) ");
					mysql.Append(" and ((pias.pias_year = " + DateTime.Parse(mPrevPayrollDate).Year.ToString());
					mysql.Append(" and pias.pias_month =  " + DateTime.Parse(mPrevPayrollDate).Month.ToString() + ") ");
					mysql.Append(" or (pias.pias_year = " + DateTime.Parse(mSecondLastPayrollDate).Year.ToString());
					mysql.Append(" and pias.pias_month =  " + DateTime.Parse(mSecondLastPayrollDate).Month.ToString() + "))");
					mysql.Append(" and pias.pias_curr_accru_lc_amount> 0 ");
					mysql.Append(" and pn.Allocate_Provision <> 1 ");
					if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("enable_payroll_project")))
					{
						mysql.Append(" and (ppp.pay_date = '" + pVoucherDate + "' or ppp.pay_date is null)");
					}

					//''commented by hakim on 15-dec-2012
					//''this was done for kharafi as terminated employees were not coming while generating the GL entry for previous month
					//mySql = mySql & " and pemp.status_cd not in (3,4)"

					if (mComCd != 0)
					{
						mysql.Append(" and pemp.comp_cd = " + mComCd.ToString());
					}
					mysql.Append(" group by gltab.ldgr_cd,gltab.cost_cd , gltab.emp_cd, gl_ledger.ldgr_no , cc.cost_no , l_ldgr_name, l_cost_name");
					if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("enable_payroll_project")))
					{
						mysql.Append(" , dgp.project_no ,gp.project_no ,  analysis2_cd ,  analysis3_cd ,  analysis4_cd ,  analysis5_cd , isnull(pppd.pay_hours,0) , isnull(ppp.pay_hours,0)   ");
					}
					else
					{
						mysql.Append(" , analysis1_cd ,  analysis2_cd ,  analysis3_cd ,  analysis4_cd ,  analysis5_cd ");
					}
					mysql.Append(" order by gltab.emp_cd, sorder ");
				}
				else
				{
					mysql = new StringBuilder("");
				}

				if (mysql.ToString() != "")
				{
					SqlCommand sqlCommand_5 = new SqlCommand(mysql.ToString(), SystemVariables.gConn);
					rsTempRec = sqlCommand_5.ExecuteReader();
					bool rsTempRecDidRead4 = rsTempRec.Read();

					if (rsTempRecDidRead)
					{
						do 
						{
							if (ChkGenerateSeprateJv.CheckState == CheckState.Checked)
							{
								mJvType = 2;
							}
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
				int tempForEndVar4 = mArr.GetLength(0) - 1;
				for (cnt = 0; cnt <= tempForEndVar4; cnt++)
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
				else if (pGLInsertMethod != 2)
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

			//''''''    If mProjectMethod = 1 Then
			//''''''        mReturnValue = GetMasterCode("select cost_cd,l_cost_name,cost_no from gl_cost_centers where Cost_No = '" & mArr(i, gccProjectNo) & "'")
			//''''''        If IsNull(mReturnValue) Then
			//''''''          mySql = mySql & " ,'" & mArr(i, gccCCName) & "'"
			//''''''          mySql = mySql & " ,'" & mArr(i, gccCCNo) & "'"
			//''''''        Else
			//''''''          mySql = mySql & " ,'" & mReturnValue(1) & "'"
			//''''''          mySql = mySql & " ,'" & mReturnValue(2) & "'"
			//''''''        End If
			//''''''    Else
			//''''''        mySql = mySql & " ,'" & mArr(i, gccCCName) & "'"
			//''''''        mySql = mySql & " ,'" & mArr(i, gccCCNo) & "'"
			//''''''    End If
			//''''''    If Not IsItEmpty(mArr(i, gccLdgrCd), NumberType) Then
			//''''''      mySql = mySql & " ," & mArr(i, gccLdgrCd)
			//''''''    ElseIf GetSystemPreferenceSetting("pay_gl_entry_method") = 3 Then
			//''''''      mySql = mySql & " ,0"
			//''''''    End If
			//''''''    If mProjectMethod = 1 Then
			//''''''        If IsNull(mReturnValue) Then
			//''''''            mySql = mySql & " ," & IIf(mArr(i, gccCCCd) = "", 0, mArr(i, gccCCCd))
			//''''''        Else
			//''''''            mySql = mySql & " ," & mReturnValue(0)
			//''''''        End If
			//''''''    Else
			//''''''        mySql = mySql & " ," & IIf(mArr(i, gccCCCd) = "", 0, mArr(i, gccCCCd))
			//''''''    End If
			//''''''    mySql = mySql & " ,'" & mArr(i, gccAccountCode) & "'"
			//''''''    mySql = mySql & " ,'" & mArr(i, gccServiceCode) & "'"
			//''''''    mySql = mySql & " ,'" & mArr(i, gccPartyCode) & "'"
			//''''''    mySql = mySql & " ,'" & mArr(i, gccDepartmentCode) & "'"
			//''''''    If mProjectMethod = 2 Then
			//''''''        mySql = mySql & " ,'" & mArr(i, gccProjectNo) & "'"
			//''''''    Else
			//''''''        mySql = mySql & " ,'" & mArr(i, gccAnalysisCd1) & "'"
			//''''''    End If
			//''''''    If mProjectMethod = 3 Then
			//''''''        mySql = mySql & " ,'" & mArr(i, gccProjectNo) & "'"
			//''''''    Else
			//''''''        mySql = mySql & " ,'" & mArr(i, gccAnalysisCd2) & "'"
			//''''''    End If
			//''''''    mySql = mySql & " ," & mArr(i, gccJvType)

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

		private object GeneratePayrollGLEntry(string pVoucherDate, XArrayHelper pArr, int pJvtype = 0)
		{
			try
			{

				string mysql = "";

				string mLdgrCd = "";
				string mCostCd = "";
				decimal mLineAmt = 0;

				string mDrCr = "";
				int mDrLineNo = 0;
				int mCrLineNo = 0;
				string mComments = "";

				int mDefaultGlVoucherType = 0;
				int mVoucherNo = 0;
				int mAccntTransEntryId = 0;
				int cnt = 0;

				string mAnalysisCd1 = "";
				string mAnalysisCd2 = "";

				int mCnt = 0;

				//UPGRADE_WARNING: (1068) GetSystemPreferenceSetting() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mDefaultGlVoucherType = ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetSystemPreferenceSetting("pay_default_gl_voucher_type"));

				//If GetSystemPreferenceSetting("pay_gl_entry_method") = 1 Then
				//    ''''Department Level entry
				mDrLineNo = 1;
				mCrLineNo = 1;

				mysql = " voucher_type = " + Conversion.Str(mDefaultGlVoucherType);
				mVoucherNo = Convert.ToInt32(Double.Parse(SystemProcedure2.GetNewNumber("gl_accnt_trans", "voucher_no", 0, mysql, " tablock(xlock) ")));

				mAccntTransEntryId = SystemFAProcedure.FAInsertGLHeaderEntry(mDefaultGlVoucherType, pVoucherDate, mVoucherNo, "", "Auto Generated Payroll Entry for the month of " + DateTime.Parse(pVoucherDate).ToString("MMM"), 1, SystemVariables.gLoggedInUserCode);


				int tempForEndVar = pArr.GetLength(0) - 1;
				for (cnt = 0; cnt <= tempForEndVar; cnt++)
				{
					if (Convert.ToDouble(pArr.GetValue(cnt, gccJvType)) == pJvtype)
					{
						mLdgrCd = Convert.ToString(pArr.GetValue(cnt, gccLdgrCd));
						mCostCd = Convert.ToString(pArr.GetValue(cnt, gccCCCd));
						mComments = Convert.ToString(pArr.GetValue(cnt, gccComments));
						mAnalysisCd1 = Convert.ToString(pArr.GetValue(cnt, gccAnalysisCd1));
						mAnalysisCd2 = Convert.ToString(pArr.GetValue(cnt, gccAnalysisCd2));

						if (Conversion.Val(StringsHelper.Format(pArr.GetValue(cnt, gccDebit), "#############0.000")) > 0)
						{
							mDrCr = "D";
							mLineAmt = (decimal) Conversion.Val(StringsHelper.Format(pArr.GetValue(cnt, gccDebit), "#############0.000"));
						}
						else
						{
							mDrCr = "C";
							mLineAmt = (decimal) Conversion.Val(StringsHelper.Format(pArr.GetValue(cnt, gccCredit), "#############0.000"));
						}

						if (mDrCr == "D")
						{
							SystemFAProcedure.FAInsertGLDetailsEntry(mAccntTransEntryId, mLdgrCd, mCostCd, 1, mLineAmt, 1 * mLineAmt, mDrCr, pVoucherDate, mDrLineNo, 1, mComments, 0, mAnalysisCd1, mAnalysisCd2);

							mDrLineNo++;
						}
						else
						{
							SystemFAProcedure.FAInsertGLDetailsEntry(mAccntTransEntryId, mLdgrCd, mCostCd, 1, mLineAmt * -1, 1 * (mLineAmt * -1), mDrCr, pVoucherDate, mCrLineNo, 1, mComments, 0, mAnalysisCd1, mAnalysisCd2);

							mCrLineNo++;
						}
					}
				}
				//End If
			}
			catch (System.Exception excep)
			{

				MessageBox.Show("Check Your Gl Link : " + excep.Message, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
			}

			return null;
		}

		private void DisplayError(int pCode)
		{
			//''pType = 1 then Department level error
			//''pType = 2 then Employee level error



			//'''If GetSystemPreferenceSetting("pay_gl_entry_method") = 1 Then
			//'''    ''''Department Level entry
			//'''
			//'''    mySQL = " select "
			//'''    If gPreferedLanguage = english Then
			//'''        mySQL = mySQL & " l_dept_name "
			//'''    Else
			//'''        mySQL = mySQL & " a_dept_name "
			//'''    End If
			//'''    mySQL = mySQL & " from pay_department "
			//'''    mySQL = mySQL & " where dept_cd =" & pCode
			//'''
			//'''    mErrorMessage = " GL links not defined for Department : "
			//'''Else
			//'''    mySQL = " select "
			//'''    If gPreferedLanguage = english Then
			//'''        mySQL = mySQL & " l_first_name "
			//'''    Else
			//'''        mySQL = mySQL & " a_first_name "
			//'''    End If
			//'''    mySQL = mySQL & " from pay_employee "
			//'''    mySQL = mySQL & " where emp_cd =" & pCode
			//'''
			//'''    mErrorMessage = " GL links not defined for Employee : "
			//'''End If

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


		//If GetSystemPreferenceSetting("pay_gl_entry_method") = 1 Then
		//'''''    ''''Department Level entry
		//'''''
		//'''''    '''Staff Salary a/c   dr
		//'''''    '''     To Salary Control A/C
		//'''''    mySql = " select pbt.bill_cd , pbt.bill_type_id "
		//'''''    mySql = mySql & " , pdept.dept_cd as emp_dept_cd , gltab.ldgr_cd "
		//'''''    mySql = mySql & " , gl_ledger.ldgr_no , cc.cost_no "
		//'''''    If gPreferedLanguage = English Then
		//'''''        mySql = mySql & ", l_ldgr_name ldgr_name, l_cost_name cost_name"
		//'''''    Else
		//'''''        mySql = mySql & ", a_ldgr_name ldgr_name, a_cost_name cost_name "
		//'''''    End If
		//'''''    mySql = mySql & " , gltab.cost_cd , round(sum(pp.lc_amount),3) lc_amount "
		//'''''    If GetSystemPreferenceSetting("pay_gl_entry_method") = 3 Then
		//'''''      mySql = mySql & " , gltab.service_cd, gltab.party_cd, gltab.account_cd, gltab.Depart_cd "
		//'''''    End If
		//'''''    mySql = mySql & " from pay_payroll pp "
		//'''''    mySql = mySql & " inner join pay_billing_type pbt on pp.bill_cd = pbt.bill_cd "
		//'''''    mySql = mySql & " inner join pay_department pdept on pp.dept_cd = pdept.dept_cd "
		//'''''    mySql = mySql & " left join pay_department_gl_details gltab on pdept.dept_cd = gltab.dept_cd "
		//'''''    mySql = mySql & " and pp.bill_cd = gltab.bill_cd "
		//'''''    mySql = mySql & " left join gl_ledger on gltab.ldgr_cd = gl_ledger.ldgr_cd "
		//'''''    mySql = mySql & " left join gl_cost_centers cc on gltab.cost_cd = cc.cost_cd "
		//'''''    mySql = mySql & " where pp.pay_date ='" & pVoucherDate & "'"
		//'''''    mySql = mySql & " and pp.lc_amount > 0 "
		//'''''    mySql = mySql & " group by pbt.bill_cd , pbt.bill_type_id "
		//'''''    mySql = mySql & " , pdept.dept_cd , gltab.ldgr_cd , gltab.cost_cd "
		//'''''    mySql = mySql & " , gl_ledger.ldgr_no, gl_ledger.l_ldgr_name, gl_ledger.a_ldgr_name "
		//'''''    mySql = mySql & " , cc.cost_no, cc.l_cost_name, cc.a_cost_name"
		//'''''    If GetSystemPreferenceSetting("pay_gl_entry_method") = 3 Then
		//'''''       mySql = mySql & " , gltab.service_cd, gltab.party_cd, gltab.account_cd, gltab.Depart_cd "
		//'''''    End If
		//ElseIf GetSystemPreferenceSetting("pay_gl_entry_method") = 2 Then
		//'''''    mySql = " select pbt.bill_cd , pbt.bill_type_id "
		//'''''    mySql = mySql & " , pemp.emp_cd as emp_dept_cd "
		//'''''    mySql = mySql & " , glinfo.ldgr_cd "
		//'''''    mySql = mySql & " , gl_ledger.ldgr_no , cc.cost_no , l_ldgr_name ldgr_name "
		//'''''    mySql = mySql & " , l_cost_name cost_name , glinfo.cost_cd "
		//'''''    mySql = mySql & " , round(pp.lc_amount,3) lc_amount "
		//'''''    If GetSystemPreferenceSetting("pay_gl_entry_method") = 3 Then
		//'''''        mySql = mySql & " , glinfo.service_cd, glinfo.party_cd, glinfo.account_cd, glinfo.Depart_cd "
		//'''''    End If
		//'''''    mySql = mySql & " from pay_payroll pp "
		//'''''    mySql = mySql & " inner join pay_billing_type pbt on pp.bill_cd = pbt.bill_cd "
		//'''''    mySql = mySql & " inner join pay_employee pemp on pp.emp_cd = pemp.emp_cd "
		//'''''    mySql = mySql & " left join pay_employee_gl_details glinfo "
		//'''''    mySql = mySql & " on pemp.emp_cd = glinfo.emp_cd  and pp.bill_cd = glinfo.bill_cd "
		//'''''    mySql = mySql & " left join gl_ledger on glinfo.ldgr_cd = gl_ledger.ldgr_cd "
		//'''''    mySql = mySql & " left join gl_cost_centers cc on glinfo.cost_cd = cc.cost_cd "
		//'''''    mySql = mySql & " where pp.pay_date ='" & pVoucherDate & "'"
		//'''''    mySql = mySql & " and pp.lc_amount > 0 "
		//''''''''    mySql = " select pbt.bill_cd , pbt.bill_type_id  "
		//''''''''    mySql = mySql & "   , glinfo.ldgr_cd "
		//''''''''    mySql = mySql & "   , gl_ledger.ldgr_no , cc.cost_no , l_ldgr_name ldgr_name "
		//''''''''    mySql = mySql & "   , l_cost_name cost_name , glinfo.cost_cd "
		//''''''''    mySql = mySql & "   , sum(case  when pped.percentage is null then round(pp.lc_amount,3)"
		//''''''''    mySql = mySql & "   else case  when pped.percentage = 0 then round(pp.lc_amount,3)"
		//''''''''    mySql = mySql & "   else round((pp.lc_amount/100)*pped.percentage,3)"
		//''''''''    mySql = mySql & "    End"
		//''''''''    mySql = mySql & "   end) lc_amount"
		//''''''''    ''''mySql = mySql & "   , sum(lc_amount) lc_amount "
		//''''''''    mySql = mySql & "   , analysis2_cd , analysis3_cd , analysis4_cd , analysis5_cd , gp.project_no as analysis1_cd"
		//''''''''    mySql = mySql & "   from pay_payroll pp "
		//''''''''    mySql = mySql & "   inner join pay_billing_type pbt on pp.bill_cd = pbt.bill_cd "
		//''''''''    mySql = mySql & "   inner join pay_employee pemp on pp.emp_cd = pemp.emp_cd "
		//''''''''    mySql = mySql & "   left join pay_project_emp_details pped on pemp.emp_cd = pped.emp_cd"
		//''''''''    mySql = mySql & "   left join gl_projects gp on pped.project_cd = gp.project_cd"
		//''''''''    mySql = mySql & "   left join pay_employee_gl_details glinfo "
		//''''''''    mySql = mySql & "   on pemp.emp_cd = glinfo.emp_cd  and pp.bill_cd = glinfo.bill_cd "
		//''''''''    mySql = mySql & "   left join gl_ledger on glinfo.ldgr_cd = gl_ledger.ldgr_cd "
		//''''''''    mySql = mySql & "   left join gl_cost_centers cc on glinfo.cost_cd = cc.cost_cd "
		//'''''''''    mySQL = mySQL & "   left join pay_project_payroll ppp  on pp.emp_cd  = ppp.emp_cd and pp.bill_cd = ppp.bill_cd and pp.pay_date = ppp.pay_date "
		//'''''''''    mySQL = mySQL & "   left join pay_project_payroll_details pppd on ppp.entry_id = pppd.entry_id"
		//''''''''    mySql = mySql & "   where pp.pay_date = '" & pVoucherDate & "' and pp.lc_amount > 0 "
		//''''''''    mySql = mySql & "   group by pbt.bill_cd , pbt.bill_type_id "
		//''''''''    mySql = mySql & "   , glinfo.ldgr_cd  , gl_ledger.ldgr_no , cc.cost_no , l_ldgr_name "
		//''''''''    mySql = mySql & "   , l_cost_name , glinfo.cost_cd "
		//''''''''    mySql = mySql & "   , analysis2_cd , analysis3_cd , analysis4_cd , analysis5_cd , gp.project_no , pped.percentage"
		//  3
		//    mySQL = " select pbt.bill_cd , pbt.bill_type_id "
		//    mySQL = mySQL & " , pemp.emp_cd as emp_dept_cd "
		//    mySQL = mySQL & " , glinfo.ldgr_cd "
		//    mySQL = mySQL & " , gl_ledger.ldgr_no , cc.cost_no , l_ldgr_name ldgr_name "
		//    mySQL = mySQL & " , l_cost_name cost_name , glinfo.cost_cd "
		//    mySQL = mySQL & " , round(pp.lc_amount,3) lc_amount , analysis1_cd , analysis2_cd "
		//    mySQL = mySQL & " , glinfo.service_cd, glinfo.party_cd, glinfo.account_cd, glinfo.Depart_cd "
		//    mySQL = mySQL & " from pay_payroll pp "
		//    mySQL = mySQL & " inner join pay_billing_type pbt on pp.bill_cd = pbt.bill_cd "
		//    mySQL = mySQL & " inner join pay_employee pemp on pp.emp_cd = pemp.emp_cd "
		//    mySQL = mySQL & " left join pay_employee_gl_details glinfo "
		//    mySQL = mySQL & " on pemp.emp_cd = glinfo.emp_cd  and pp.bill_cd = glinfo.bill_cd "
		//    mySQL = mySQL & " left join gl_ledger on glinfo.ldgr_cd = gl_ledger.ldgr_cd "
		//    mySQL = mySQL & " left join gl_cost_centers cc on glinfo.cost_cd = cc.cost_cd "
		//    mySQL = mySQL & " where pp.pay_date ='" & pVoucherDate & "'"
		//    mySQL = mySQL & " and pp.lc_amount > 0 "
		//'''''1
		//''''''                    mySql = " select pbt.bill_cd , pbt.bill_type_id "
		//''''''                    mySql = mySql & " , pdept.dept_cd as emp_dept_cd , gltab.ldgr_cd "
		//''''''                    mySql = mySql & " , gltab.cost_cd "
		//''''''                    mySql = mySql & " , gl_ledger.ldgr_no , cc.cost_no "
		//''''''
		//''''''                    If gPreferedLanguage = English Then
		//''''''                        mySql = mySql & ", l_ldgr_name ldgr_name, l_cost_name cost_name"
		//''''''                    Else
		//''''''                        mySql = mySql & ", a_ldgr_name ldgr_name, a_cost_name cost_name "
		//''''''                    End If
		//''''''                    'mysql = mysql & " , gltab.service_cd, gltab.party_cd, gltab.account_cd, gltab.Depart_cd"
		//''''''                    mySql = mySql & " from pay_billing_type pbt"
		//''''''                    mySql = mySql & " left join pay_department_gl_details gltab on pbt.bill_cd = gltab.bill_cd "
		//''''''                    mySql = mySql & " left join pay_department pdept on pdept.dept_cd = gltab.dept_cd "
		//''''''                    mySql = mySql & " left join gl_ledger on gltab.ldgr_cd = gl_ledger.ldgr_cd "
		//''''''                    mySql = mySql & " left join gl_cost_centers cc on gltab.cost_cd = cc.cost_cd   "
		//''''''                    mySql = mySql & " where pbt.bill_cd = 10 "
		//''''''                    mySql = mySql & " and pdept.dept_cd =" & rsTempRec.Fields("emp_dept_cd")
		//''''''                    mySql = mySql & " group by pbt.bill_cd , pbt.bill_type_id "
		//''''''                    mySql = mySql & " , pdept.dept_cd , gltab.ldgr_cd , gltab.cost_cd "
		//''''''                    mySql = mySql & " , gl_ledger.ldgr_no, gl_ledger.l_ldgr_name, gl_ledger.a_ldgr_name "
		//''''''                    mySql = mySql & " , cc.cost_no, cc.l_cost_name, cc.a_cost_name"
		//''''''                    ', gltab.service_cd, gltab.party_cd, gltab.account_cd, gltab.Depart_cd "
		//''''''2
		//''''''                    mySql = " select pbt.bill_cd , pbt.bill_type_id "
		//''''''                    mySql = mySql & " , pemp.emp_cd as emp_dept_cd "
		//''''''                    mySql = mySql & " , gltab.ldgr_cd , gltab.cost_cd "
		//''''''                    mySql = mySql & " , gl_ledger.ldgr_no , cc.cost_no "
		//''''''
		//''''''                    If gPreferedLanguage = English Then
		//''''''                        mySql = mySql & ", l_ldgr_name ldgr_name, l_cost_name cost_name"
		//''''''                    Else
		//''''''                        mySql = mySql & ", a_ldgr_name ldgr_name, a_cost_name cost_name "
		//''''''                    End If
		//''''''                    mySql = mySql & " , gltab.service_cd, gltab.party_cd, gltab.account_cd, gltab.Depart_cd"
		//''''''                    mySql = mySql & " from pay_billing_type pbt"
		//''''''                    mySql = mySql & " left join pay_employee_gl_details gltab on pbt.bill_cd = gltab.bill_cd "
		//''''''                    mySql = mySql & " left join pay_employee pemp on pemp.emp_cd = gltab.emp_cd "
		//''''''                    mySql = mySql & " left join gl_ledger on gltab.ldgr_cd = gl_ledger.ldgr_cd "
		//''''''                    mySql = mySql & " left join gl_cost_centers cc on gltab.cost_cd = cc.cost_cd   "
		//''''''                    mySql = mySql & " where pbt.bill_cd = 10 "
		//''''''                    mySql = mySql & " and pemp.emp_cd =" & rsTempRec.Fields("emp_dept_cd")
		//''''''3
		//                    mySQL = " select pbt.bill_cd , pbt.bill_type_id "
		//                    mySQL = mySQL & " , pemp.emp_cd as emp_dept_cd "
		//                    mySQL = mySQL & " , gltab.ldgr_cd , gltab.cost_cd "
		//                    mySQL = mySQL & " , gl_ledger.ldgr_no , cc.cost_no "
		//
		//                    If gPreferedLanguage = English Then
		//                        mySQL = mySQL & ", l_ldgr_name ldgr_name, l_cost_name cost_name"
		//                    Else
		//                        mySQL = mySQL & ", a_ldgr_name ldgr_name, a_cost_name cost_name "
		//                    End If
		//                    mySQL = mySQL & " , gltab.service_cd, gltab.party_cd, gltab.account_cd, gltab.Depart_cd"
		//                    mySQL = mySQL & " from pay_billing_type pbt"
		//                    mySQL = mySQL & " left join pay_employee_gl_details gltab on pbt.bill_cd = gltab.bill_cd "
		//                    mySQL = mySQL & " left join pay_employee pemp on pemp.emp_cd = gltab.emp_cd "
		//                    mySQL = mySQL & " left join gl_ledger on gltab.ldgr_cd = gl_ledger.ldgr_cd "
		//                    mySQL = mySQL & " left join gl_cost_centers cc on gltab.cost_cd = cc.cost_cd   "
		//                    mySQL = mySQL & " where pbt.bill_cd = 117 "
		//                    mySQL = mySQL & " and pemp.emp_cd =" & rsTempRec.Fields("emp_dept_cd")
		//----------------------------------------

		//Commented by burhan. Date:22-may-2008
		//desc: to get cumulative balance
		//mysql = " select sum(plas_curr_accru_lc_amount) lc_amount "
		//mySql = " select sum(case when plas.plas_year = " & Year(CDate(mPrevPayrollDate)) & " and plas.plas_month = " & Month(CDate(mPrevPayrollDate)) & " then plas_cumm_accrued_amt when plas.plas_year = " & Year(CDate(mSecondLastPayrollDate)) & " and plas.plas_month = " & Month(CDate(mSecondLastPayrollDate)) & "  then plas_cumm_accrued_amt *-1 end)  lc_amount "
		//'
		//''''    mySql = " select sum(case when plas.plas_year = " & Year(CDate(mPrevPayrollDate)) & "  and plas.plas_month = " & Month(CDate(mPrevPayrollDate)) & "  then plas_curr_accru_lc_amount"
		//''''    mySql = mySql & " when plas.plas_year = " & Year(CDate(mSecondLastPayrollDate)) & " and plas.plas_month = " & Month(CDate(mSecondLastPayrollDate)) & " then (dbo.payLeaveAmount(gltab.emp_cd,pl.leave_Cd,plas.plas_cumm_accrued_days, '" & mSecondLastPayrollDate & "' ) - plas_cumm_accrued_amt) end) as  lc_amount"
		//''''    mySql = mySql & " ,gltab.ldgr_cd, gltab.cost_cd"
		//''''    mySql = mySql & " , gltab.emp_cd as emp_dept_cd "
		//''''    mySql = mySql & " , gl_ledger.ldgr_no , cc.cost_no "
		//''''    If gPreferedLanguage = English Then
		//''''        mySql = mySql & ", l_ldgr_name ldgr_name, l_cost_name cost_name"
		//''''    Else
		//''''        mySql = mySql & ", a_ldgr_name ldgr_name, a_cost_name cost_name "
		//''''    End If
		//''''    mySql = mySql & ", 1 as sorder "
		//''''    'mySql = mySql & " from pay_gl_provision pprov "
		//''''    mySql = mySql & " from PAY_LEAVE_ACCRUAL_SUMMARY plas " 'added by burhan for testing
		//''''    mySql = mySql & " inner join pay_employee pemp on plas.plas_emp_cd = pemp.emp_cd " 'added for testing
		//''''    mySql = mySql & " inner join pay_employee_leave_details peld on peld.emp_cd = pemp.emp_Cd"
		//''''    mySql = mySql & " inner join pay_leave pl on pl.leave_cd = peld.leave_cd"
		//''''    mySql = mySql & " inner join pay_employee_gl_details gltab on pemp.emp_cd = gltab.emp_cd"
		//''''    mySql = mySql & " left join gl_ledger on gltab.ldgr_cd = gl_ledger.ldgr_cd "
		//''''    mySql = mySql & " left join gl_cost_centers cc on gltab.cost_cd = cc.cost_cd "
		//''''    mySql = mySql & " Where "
		//''''    mySql = mySql & "  (gltab.bill_cd = 5) "         'Leave expenses biling cd
		//''''
		//''''    'Commented by burhan. Date:22-may-2008
		//''''    'desc: to get cumulative balance
		//'''''    mysql = mysql & " and plas.plas_year = " & Year(mPrevPayrollDate) ' added for testin
		//'''''    mysql = mysql & " and plas.plas_month =  " & Month(mPrevPayrollDate) ' added for testin
		//''''    mySql = mySql & " and ((plas.plas_year = " & Year(mPrevPayrollDate) ' added for testin
		//''''    mySql = mySql & " and plas.plas_month =  " & Month(mPrevPayrollDate) & ") " ' added for testin
		//''''
		//''''    mySql = mySql & " or (plas.plas_year = " & Year(CDate(mSecondLastPayrollDate)) ' added for testin
		//''''    mySql = mySql & " and plas.plas_month =  " & Month(CDate(mSecondLastPayrollDate)) & "))"  ' added for testin
		//''''    '''
		//''''    mySql = mySql & " and plas.plas_curr_accru_lc_amount > 0 and pl.leave_type_cd = 6 " ' added for testin
		//''''    mySql = mySql & " group by gltab.ldgr_cd,gltab.cost_cd , gltab.emp_cd, gl_ledger.ldgr_no , cc.cost_no , l_ldgr_name, l_cost_name "
		//''''
		//'''''    mySql = mySql & "  and plas.provision_type = 2 "   ''Leave provision
		//'''''    mySql = mySql & "  and plas.generate_date ='" & pVoucherDate & "'"
		//'''''    mySql = mySql & "  and plas.provision_amount > 0 "
		//''''    mySql = mySql & " union all "
		//''''    'mySql = mySql & " select sum(case when plas.plas_year = " & Year(CDate(mPrevPayrollDate)) & " and plas.plas_month = " & Month(CDate(mPrevPayrollDate)) & " then plas_cumm_accrued_amt when plas.plas_year = " & Year(CDate(mSecondLastPayrollDate)) & " and plas.plas_month = " & Month(CDate(mSecondLastPayrollDate)) & "  then plas_cumm_accrued_amt *-1 end)  * -1 lc_amount "
		//''''    mySql = mySql & " select sum(case when plas.plas_year = " & Year(CDate(mPrevPayrollDate)) & "  and plas.plas_month = " & Month(CDate(mPrevPayrollDate)) & "  then plas_curr_accru_lc_amount"
		//''''    mySql = mySql & " when plas.plas_year = " & Year(CDate(mSecondLastPayrollDate)) & " and plas.plas_month = " & Month(CDate(mSecondLastPayrollDate)) & " then (dbo.payLeaveAmount(gltab.emp_cd,pl.leave_Cd,plas.plas_cumm_accrued_days, '" & mSecondLastPayrollDate & "' ) - plas_cumm_accrued_amt) end) * -1 as  lc_amount"
		//''''    mySql = mySql & " , gltab.ldgr_cd, gltab.cost_cd "
		//''''    mySql = mySql & " , gltab.emp_cd as emp_dept_cd "
		//''''    mySql = mySql & " , gl_ledger.ldgr_no , cc.cost_no "
		//''''    If gPreferedLanguage = English Then
		//''''        mySql = mySql & ", l_ldgr_name ldgr_name, l_cost_name cost_name"
		//''''    Else
		//''''        mySql = mySql & ", a_ldgr_name ldgr_name, a_cost_name cost_name "
		//''''    End If
		//''''    mySql = mySql & ", 2 as sorder "
		//''''
		//''''    'mySql = mySql & " from pay_gl_provision plas "
		//''''    mySql = mySql & " from PAY_LEAVE_ACCRUAL_SUMMARY plas " 'added by burhan for testing
		//''''    mySql = mySql & " inner join pay_employee pemp on plas.plas_emp_cd = pemp.emp_cd " 'added for testing
		//''''    mySql = mySql & " inner join pay_employee_leave_details peld on peld.emp_cd = pemp.emp_Cd"
		//''''    mySql = mySql & " inner join pay_leave pl on pl.leave_cd = peld.leave_cd"
		//''''    mySql = mySql & " inner join pay_employee_gl_details gltab on pemp.emp_cd = gltab.emp_cd"
		//''''    mySql = mySql & " left join gl_ledger on gltab.ldgr_cd = gl_ledger.ldgr_cd "
		//''''    mySql = mySql & " left join gl_cost_centers cc on gltab.cost_cd = cc.cost_cd "
		//''''    mySql = mySql & " Where "
		//''''    mySql = mySql & "  (gltab.bill_cd = 7) "         'Leave expenses biling cd
		//''''
		//''''    'Commented by burhan. Date:22-may-2008
		//''''    'desc: to get cumulative balance
		//'''''    mysql = mysql & " and plas.plas_year = " & Year(mPrevPayrollDate) ' added for testin
		//'''''    mysql = mysql & " and plas.plas_month =  " & Month(mPrevPayrollDate) ' added for testin
		//''''    mySql = mySql & " and ((plas.plas_year = " & Year(mPrevPayrollDate) ' added for testin
		//''''    mySql = mySql & " and plas.plas_month =  " & Month(mPrevPayrollDate) & ") " ' added for testin
		//''''
		//''''    mySql = mySql & " or (plas.plas_year = " & Year(mSecondLastPayrollDate) ' added for testin
		//''''    mySql = mySql & " and plas.plas_month =  " & Month(mSecondLastPayrollDate) & "))"  ' added for testin
		//''''    '''
		//''''
		//''''    mySql = mySql & " and plas.plas_curr_accru_lc_amount > 0 and pl.leave_type_cd = 6 " ' added for testin
		//''''    mySql = mySql & " group by gltab.ldgr_cd,gltab.cost_cd , gltab.emp_cd, gl_ledger.ldgr_no , cc.cost_no , l_ldgr_name, l_cost_name "
		//''''
		//''''    'mySql = mySql & "  and plas.provision_type = 2 "   ''Leave provision
		//''''    'mySql = mySql & "  and plas.generate_date ='" & pVoucherDate & "'"
		//''''    'mySql = mySql & "  and plas.provision_amount > 0 "
		//''''    mySql = mySql & " order by gltab.emp_cd, sorder "
		//mysql = " select pemp.emp_cd , pdept.dept_cd "
		//mysql = mysql & " from pay_employee pemp "
		//mysql = mysql & " inner join pay_department pdept on pemp.dept_cd = pdept.dept_cd "
		//mysql = mysql & " where status_cd = 1 "
		//
		//Set rsTempRec = New ADODB.Recordset
		//With rsTempRec
		//    .Open mysql, gConn, adOpenForwardOnly, adLockReadOnly
		//    Do While Not .EOF
		//
		//        mysql = " select  dbo.payLeaveBalanceDays( "
		//        mysql = mysql & .Fields("emp_cd")
		//        mysql = mysql & " , 1 "
		//        mysql = mysql & " , '" & pVoucherDate & "'"
		//        mysql = mysql & " , 0 ) "
		//        mReturnValue = GetMasterCode(mysql)
		//        If Not IsNull(mReturnValue) Then
		//            mLeaveBalanceDays = mReturnValue
		//        Else
		//            mLeaveBalanceDays = 0
		//        End If
		//
		//
		//        ''''Get the previous leave provision days
		//        mysql = " select isnull(sum(provision_days),0) "
		//        mysql = mysql & " from pay_gl_provision "
		//        mysql = mysql & " where generate_date <'" & pVoucherDate & "'"
		//        mysql = mysql & " and emp_cd=" & .Fields("emp_cd")
		//        mysql = mysql & " and provision_type = 2 "  '''leave
		//        mReturnValue = GetMasterCode(mysql)
		//        If Not IsNull(mReturnValue) Then
		//            mPreviousLeaveBalanceDaysProvision = mReturnValue
		//        Else
		//            mPreviousLeaveBalanceDaysProvision = 0
		//        End If
		//
		//        mLeaveProvisionDays = mLeaveBalanceDays - mPreviousLeaveBalanceDaysProvision
		//
		//
		//        mysql = " select round( dbo.payLeaveAmount( "
		//        mysql = mysql & .Fields("emp_cd")
		//        mysql = mysql & " , 1 "
		//        mysql = mysql & " , " & mLeaveProvisionDays
		//        mysql = mysql & " , '" & pVoucherDate & "'), 3,1 )"
		//        mReturnValue = GetMasterCode(mysql)
		//        If Not IsNull(mReturnValue) Then
		//            mLeaveProvisionAmt = mReturnValue
		//        Else
		//            mLeaveProvisionAmt = 0
		//        End If
		//
		//        Call InsertIntoPayGLProvision(pVoucherDate, 2, 1, .Fields("emp_cd") _
		//'            , .Fields("dept_cd"), mLeaveProvisionDays, mLeaveProvisionAmt)
		//
		//    .MoveNext
		//    Loop
		//End With


		//-----------------------------------------
		//''    'Commented by burhan. Date:22-may-2008
		//''    'desc: to get cumulative balance of current month minus previous month
		//''    'mysql = " select sum(plas_curr_accru_lc_amount) lc_amount "
		//''    mySql = " select sum(case when plas.plas_year = " & Year(CDate(mPrevPayrollDate)) & " and plas.plas_month = " & Month(CDate(mPrevPayrollDate)) & " then plas_cumm_accrued_amt when plas.plas_year = " & Year(CDate(mSecondLastPayrollDate)) & " and plas.plas_month = " & Month(CDate(mSecondLastPayrollDate)) & "  then plas_cumm_accrued_amt *-1 end )  lc_amount "
		//''    ''
		//''    mySql = mySql & " , gltab.ldgr_cd, gltab.cost_cd, gltab.dept_cd as emp_dept_cd "
		//''    mySql = mySql & " , gl_ledger.ldgr_no , cc.cost_no "
		//''    If gPreferedLanguage = English Then
		//''        mySql = mySql & ", l_ldgr_name ldgr_name, l_cost_name cost_name"
		//''    Else
		//''        mySql = mySql & ", a_ldgr_name ldgr_name, a_cost_name cost_name "
		//''    End If
		//''    mySql = mySql & ", 1 as sorder "
		//''    'mysql = mysql & " from pay_gl_provision pprov " ' commented by burhan for testing
		//''    mySql = mySql & " from PAY_LEAVE_ACCRUAL_SUMMARY plas " ' added by burhan for testing
		//''
		//''    mySql = mySql & " inner join pay_employee pemp on plas.plas_emp_cd = pemp.emp_cd " ' added for testing
		//''
		//''    mySql = mySql & " inner join pay_department_gl_details gltab on pemp.dept_cd = gltab.dept_cd"
		//''    mySql = mySql & " left join gl_ledger on gltab.ldgr_cd = gl_ledger.ldgr_cd "
		//''    mySql = mySql & " left join gl_cost_centers cc on gltab.cost_cd = cc.cost_cd "
		//''    mySql = mySql & " Where "
		//''    mySql = mySql & "  (gltab.bill_cd = 5) "         'Leave expenses biling cd
		//''    mySql = mySql & " and ((plas.plas_year = " & Year(mPrevPayrollDate) ' added for testin
		//''    mySql = mySql & " and plas.plas_month =  " & Month(mPrevPayrollDate) & ")"  ' added for testin
		//''
		//''    '''
		//''    'Commented by burhan. Date:22-may-2008
		//''    'desc: to get cumulative balance
		//''    mySql = mySql & " or (plas.plas_year = " & Year(CDate(mSecondLastPayrollDate)) ' added for testin
		//''    mySql = mySql & " and plas.plas_month =  " & Month(CDate(mSecondLastPayrollDate)) & "))"  ' added for testin
		//''    '''
		//''    mySql = mySql & " and plas.plas_curr_accru_lc_amount > 0 " ' added for testin
		//''    'mysql = mysql & "  and pprov.provision_type = 2 "   ''Leave provision
		//''    'mysql = mysql & "  and pprov.generate_date ='" & pVoucherDate & "'"
		//''    'mysql = mysql & "  and pprov.provision_amount > 0 "
		//''    mySql = mySql & "  group by gltab.ldgr_cd, gltab.cost_cd, gltab.dept_cd "
		//''    mySql = mySql & " , gl_ledger.ldgr_no, gl_ledger.l_ldgr_name, gl_ledger.a_ldgr_name "
		//''    mySql = mySql & " , cc.cost_no, cc.l_cost_name, cc.a_cost_name "
		//''
		//''    mySql = mySql & " union all "
		//''
		//''    'Commented by burhan. Date:22-may-2008
		//''    'desc: to get cumulative balance
		//''    'mysql = mysql & " select sum(plas_curr_accru_lc_amount) * -1 lc_amount "
		//''    mySql = mySql & " select sum(case when plas.plas_year = " & Year(CDate(mPrevPayrollDate)) & " and plas.plas_month = " & Month(CDate(mPrevPayrollDate)) & " then plas_cumm_accrued_amt when plas.plas_year = " & Year(CDate(mSecondLastPayrollDate)) & " and plas.plas_month = " & Month(CDate(mSecondLastPayrollDate)) & "  then plas_cumm_accrued_amt *-1 end)  * -1 lc_amount "
		//''
		//''    mySql = mySql & " , gltab.ldgr_cd, gltab.cost_cd, gltab.dept_cd as emp_dept_cd "
		//''    mySql = mySql & " , gl_ledger.ldgr_no , cc.cost_no "
		//''    If gPreferedLanguage = English Then
		//''        mySql = mySql & ", l_ldgr_name ldgr_name, l_cost_name cost_name"
		//''    Else
		//''        mySql = mySql & ", a_ldgr_name ldgr_name, a_cost_name cost_name "
		//''    End If
		//''    mySql = mySql & ", 2 as sorder "
		//''    'mysql = mysql & " from pay_gl_provision pprov " commented for testing
		//''
		//''    mySql = mySql & " from PAY_LEAVE_ACCRUAL_SUMMARY plas " ' added by burhan for testing
		//''    mySql = mySql & " inner join pay_employee pemp on plas.plas_emp_cd = pemp.emp_cd " 'added for testing
		//''
		//''    mySql = mySql & " inner join pay_department_gl_details gltab on pemp.dept_cd = gltab.dept_cd"
		//''    mySql = mySql & " left join gl_ledger on gltab.ldgr_cd = gl_ledger.ldgr_cd "
		//''    mySql = mySql & " left join gl_cost_centers cc on gltab.cost_cd = cc.cost_cd "
		//''    mySql = mySql & " Where "
		//''    mySql = mySql & "  (gltab.bill_cd = 7) "         'Leave provision biling cd
		//''
		//''    mySql = mySql & " and ((plas.plas_year = " & Year(mPrevPayrollDate) ' added for testin
		//''    mySql = mySql & " and plas.plas_month =  " & Month(mPrevPayrollDate) & ") " ' added for testin
		//''
		//''    'Commented by burhan. Date:22-may-2008
		//''    'desc: to get cumulative balance
		//''    mySql = mySql & " or (plas.plas_year = " & Year(CDate(mSecondLastPayrollDate)) ' added for testin
		//''    mySql = mySql & " and plas.plas_month =  " & Month(CDate(mSecondLastPayrollDate)) & "))"  ' added for testin
		//''    '''
		//''    mySql = mySql & " and plas.plas_curr_accru_lc_amount > 0 " ' added for testin
		//''
		//'''    mysql = mysql & "  and pprov.provision_type = 2 "   ''Leave provision
		//'''    mysql = mysql & "  and pprov.generate_date ='" & pVoucherDate & "'"
		//'''    mysql = mysql & "  and pprov.provision_amount > 0 "
		//''    mySql = mySql & "  group by gltab.ldgr_cd, gltab.cost_cd, gltab.dept_cd "
		//''    mySql = mySql & " , gl_ledger.ldgr_no, gl_ledger.l_ldgr_name, gl_ledger.a_ldgr_name "
		//''    mySql = mySql & " , cc.cost_no, cc.l_cost_name, cc.a_cost_name "
		//''    mySql = mySql & " order by gltab.dept_cd, sorder "
		//-----------------------------------------------------------------------------------
		//Indeminity

		//'-----------------------------------------------------------------
		//mysql = " select pemp.emp_cd , pdept.dept_cd "
		//mysql = mysql & " from pay_employee pemp "
		//mysql = mysql & " inner join pay_department pdept on pemp.dept_cd = pdept.dept_cd "
		//mysql = mysql & " inner join pay_nationality pnat on pemp.nat_cd = pnat.nat_cd "
		//mysql = mysql & " where pemp.status_cd = 1 "
		//mysql = mysql & " and pnat.allocate_provision = 1 "
		//
		//Set rsTempRec = New ADODB.Recordset
		//With rsTempRec
		//    .Open mysql, gConn, adOpenForwardOnly, adLockReadOnly
		//    Do While Not .EOF
		//
		//        mysql = " select  dbo.payIndemnityBalanceDays( "
		//        mysql = mysql & .Fields("emp_cd")
		//        mysql = mysql & " , '" & pVoucherDate & "'"
		//        mysql = mysql & " , 0 ) "
		//        mReturnValue = GetMasterCode(mysql)
		//        If Not IsNull(mReturnValue) Then
		//            mIndemnityBalanceDays = mReturnValue
		//        Else
		//            mIndemnityBalanceDays = 0
		//        End If
		//
		//
		//        ''''Get the previous indemnity provision days
		//        mysql = " select isnull(sum(provision_days),0) "
		//        mysql = mysql & " from pay_gl_provision "
		//        mysql = mysql & " where generate_date <'" & pVoucherDate & "'"
		//        mysql = mysql & " and emp_cd=" & .Fields("emp_cd")
		//        mysql = mysql & " and provision_type = 3 "  '''indemnity
		//        mReturnValue = GetMasterCode(mysql)
		//        If Not IsNull(mReturnValue) Then
		//            mPreviousIndemnityBalanceDaysProvision = mReturnValue
		//        Else
		//            mPreviousIndemnityBalanceDaysProvision = 0
		//        End If
		//
		//        mIndemnityProvisionDays = mIndemnityBalanceDays - mPreviousIndemnityBalanceDaysProvision
		//
		//
		//        mysql = " select  round( dbo.payIndemnityAmount( "
		//        mysql = mysql & .Fields("emp_cd")
		//        mysql = mysql & " , " & mIndemnityProvisionDays
		//        mysql = mysql & " , '" & pVoucherDate & "'), 3, 1 )"
		//        mReturnValue = GetMasterCode(mysql)
		//        If Not IsNull(mReturnValue) Then
		//            mIndemnityProvisionAmount = mReturnValue
		//        Else
		//            mIndemnityProvisionAmount = 0
		//        End If
		//
		//        Call InsertIntoPayGLProvision(pVoucherDate, 3, 1, .Fields("emp_cd") _
		//'            , .Fields("dept_cd"), mIndemnityProvisionDays, mIndemnityProvisionAmount)
		//
		//    .MoveNext
		//    Loop
		//End With
		//'''''1
		//'''    'Commented by Burhan. Date:24-May-2008
		//'''    'Desc:to get cumulative balance
		//'''    'mysql = " select sum(pias_curr_accru_lc_amount) lc_amount "
		//'''    mySql = " select sum(case when pias.pias_year = " & Year(CDate(mPrevPayrollDate)) & " and pias.pias_month = " & Month(CDate(mPrevPayrollDate)) & " then pias_cumm_accrued_amt when pias.pias_year = " & Year(CDate(mSecondLastPayrollDate)) & " and pias.pias_month = " & Month(CDate(mSecondLastPayrollDate)) & "  then pias_cumm_accrued_amt *-1 end )  lc_amount "
		//'''    mySql = mySql & " , gltab.ldgr_cd, gltab.cost_cd, gltab.dept_cd as emp_dept_cd "
		//'''    mySql = mySql & " , gl_ledger.ldgr_no , cc.cost_no "
		//'''    If gPreferedLanguage = English Then
		//'''        mySql = mySql & ", l_ldgr_name ldgr_name, l_cost_name cost_name"
		//'''    Else
		//'''        mySql = mySql & ", a_ldgr_name ldgr_name, a_cost_name cost_name "
		//'''    End If
		//'''    mySql = mySql & ", 1 as sorder "
		//'''    mySql = mySql & " from PAY_INDEMNITY_ACCRUAL_SUMMARY pias "
		//'''    mySql = mySql & " inner join pay_employee pemp on pias.pias_emp_cd = pemp.emp_cd " 'added for testing
		//'''
		//'''    mySql = mySql & " inner join pay_department_gl_details gltab on pemp.dept_cd = gltab.dept_cd"
		//'''    mySql = mySql & " left join gl_ledger on gltab.ldgr_cd = gl_ledger.ldgr_cd "
		//'''    mySql = mySql & " left join gl_cost_centers cc on gltab.cost_cd = cc.cost_cd "
		//'''    mySql = mySql & " Where "
		//'''    mySql = mySql & "  (gltab.bill_cd = 8) "         'Leave expenses biling cd
		//'''
		//'''
		//'''     'Commented by burhan. Date:22-may-2008
		//'''    'desc: to get cumulative balance
		//'''    'mysql = mysql & " and pias.pias_year = " & Year(mPrevPayrollDate) ' added for testin
		//'''    'mysql = mysql & " and pias.pias_month =  " & Month(mPrevPayrollDate) ' added for testin
		//'''
		//'''    mySql = mySql & " and ((pias.pias_year = " & Year(mPrevPayrollDate) ' added for testin
		//'''    mySql = mySql & " and pias.pias_month =  " & Month(mPrevPayrollDate) & ") " ' added for testin
		//'''
		//'''    mySql = mySql & " or (pias.pias_year = " & Year(mSecondLastPayrollDate) ' added for testin
		//'''    mySql = mySql & " and pias.pias_month =  " & Month(mSecondLastPayrollDate) & "))"  ' added for testin
		//'''    '''
		//'''
		//'''    mySql = mySql & " and pias.pias_cumm_accrued_amt> 0 " ' added for testin
		//'''
		//'''
		//''''    mysql = mysql & "  and pprov.provision_type = 3 "   ''Indemnity provision
		//''''    mysql = mysql & "  and pprov.generate_date ='" & pVoucherDate & "'"
		//''''    mysql = mysql & "  and pprov.provision_amount > 0 "
		//'''    mySql = mySql & "  group by gltab.ldgr_cd, gltab.cost_cd, gltab.dept_cd "
		//'''    mySql = mySql & " , gl_ledger.ldgr_no, gl_ledger.l_ldgr_name, gl_ledger.a_ldgr_name "
		//'''    mySql = mySql & " , cc.cost_no, cc.l_cost_name, cc.a_cost_name "
		//'''    mySql = mySql & " union all "
		//'''
		//'''    'Commented by Burhan. Date:24-May-2008
		//'''    'Desc:to get cumulative balance
		//'''    'mysql = mysql & " select sum(pias_curr_accru_lc_amount) * -1 lc_amount "
		//'''    mySql = mySql & " select sum(case when pias.pias_year = " & Year(CDate(mPrevPayrollDate)) & " and pias.pias_month = " & Month(CDate(mPrevPayrollDate)) & " then pias_cumm_accrued_amt when pias.pias_year = " & Year(CDate(mSecondLastPayrollDate)) & " and pias.pias_month = " & Month(CDate(mSecondLastPayrollDate)) & "  then pias_cumm_accrued_amt *-1 end ) * -1  lc_amount "
		//'''
		//'''
		//'''    mySql = mySql & " , gltab.ldgr_cd, gltab.cost_cd, gltab.dept_cd as emp_dept_cd "
		//'''    mySql = mySql & " , gl_ledger.ldgr_no , cc.cost_no "
		//'''    If gPreferedLanguage = English Then
		//'''        mySql = mySql & ", l_ldgr_name ldgr_name, l_cost_name cost_name"
		//'''    Else
		//'''        mySql = mySql & ", a_ldgr_name ldgr_name, a_cost_name cost_name "
		//'''    End If
		//'''    mySql = mySql & ", 2 as sorder "
		//'''    mySql = mySql & " from PAY_INDEMNITY_ACCRUAL_SUMMARY pias "
		//'''    mySql = mySql & " inner join pay_employee pemp on pias.pias_emp_cd = pemp.emp_cd " 'added for testing
		//'''    mySql = mySql & " inner join pay_department_gl_details gltab on pemp.dept_cd = gltab.dept_cd"
		//'''
		//'''    mySql = mySql & " left join gl_ledger on gltab.ldgr_cd = gl_ledger.ldgr_cd "
		//'''    mySql = mySql & " left join gl_cost_centers cc on gltab.cost_cd = cc.cost_cd "
		//'''    mySql = mySql & " Where "
		//'''    mySql = mySql & "  (gltab.bill_cd = 9) "         'indemnity provision biling cd
		//'''
		//'''     'Commented by burhan. Date:22-may-2008
		//'''    'desc: to get cumulative balance
		//'''    'mysql = mysql & " and pias.pias_year = " & Year(mPrevPayrollDate) ' added for testin
		//'''    'mysql = mysql & " and pias.pias_month =  " & Month(mPrevPayrollDate) ' added for testin
		//'''
		//'''    mySql = mySql & " and ((pias.pias_year = " & Year(mPrevPayrollDate) ' added for testin
		//'''    mySql = mySql & " and pias.pias_month =  " & Month(mPrevPayrollDate) & ") " ' added for testin
		//'''
		//'''    mySql = mySql & " or (pias.pias_year = " & Year(mSecondLastPayrollDate) ' added for testin
		//'''    mySql = mySql & " and pias.pias_month =  " & Month(mSecondLastPayrollDate) & "))"  ' added for testin
		//'''    '''
		//'''
		//'''    mySql = mySql & " and pias.pias_cumm_accrued_amt> 0 " ' added for testin
		//'''
		//'''
		//'''
		//''''    mysql = mysql & "  and pprov.provision_type = 3 "   ''indemnity provision
		//''''    mysql = mysql & "  and pprov.generate_date ='" & pVoucherDate & "'"
		//''''    mysql = mysql & "  and pprov.provision_amount > 0 "
		//'''    mySql = mySql & "  group by gltab.ldgr_cd, gltab.cost_cd, gltab.dept_cd "
		//'''    mySql = mySql & " , gl_ledger.ldgr_no, gl_ledger.l_ldgr_name, gl_ledger.a_ldgr_name "
		//'''    mySql = mySql & " , cc.cost_no, cc.l_cost_name, cc.a_cost_name "
		//'''    mySql = mySql & " order by gltab.dept_cd, sorder "
		//''''2
		//'''    mySQL = " select pias_curr_accru_lc_amount lc_amount "
		//'''    mySQL = mySQL & " ,gltab.ldgr_cd, gltab.cost_cd"
		//'''    mySQL = mySQL & " , gltab.emp_cd as emp_dept_cd "
		//'''    mySQL = mySQL & " , gl_ledger.ldgr_no , cc.cost_no "
		//'''    If gPreferedLanguage = English Then
		//'''        mySQL = mySQL & ", l_ldgr_name ldgr_name, l_cost_name cost_name"
		//'''    Else
		//'''        mySQL = mySQL & ", a_ldgr_name ldgr_name, a_cost_name cost_name "
		//'''    End If
		//'''    mySQL = mySQL & ", 1 as sorder "
		//'''    'mySql = mySql & " from pay_gl_provision pprov " '
		//'''    mySQL = mySQL & " from PAY_INDEMNITY_ACCRUAL_SUMMARY pias "
		//'''    mySQL = mySQL & " inner join pay_employee pemp on pias.pias_emp_cd = pemp.emp_cd " 'added for testing
		//'''
		//'''    mySQL = mySQL & " inner join pay_employee_gl_details gltab on pemp.emp_cd = gltab.emp_cd"
		//'''    mySQL = mySQL & " left join gl_ledger on gltab.ldgr_cd = gl_ledger.ldgr_cd "
		//'''    mySQL = mySQL & " left join gl_cost_centers cc on gltab.cost_cd = cc.cost_cd "
		//'''    mySQL = mySQL & " Where "
		//'''    mySQL = mySQL & "  (gltab.bill_cd = 8) "         'indemnity expenses biling cd
		//'''
		//'''    mySQL = mySQL & " and pias.pias_year = " & Year(mPrevPayrollDate) ' added for testin
		//'''    mySQL = mySQL & " and pias.pias_month =  " & Month(mPrevPayrollDate) ' added for testin
		//'''    mySQL = mySQL & " and pias.pias_curr_accru_lc_amount> 0 " ' added for testin
		//'''
		//'''
		//''''    mySql = mySql & "  and pprov.provision_type = 3 "   ''indemnity provision
		//''''    mySql = mySql & "  and pprov.generate_date ='" & pVoucherDate & "'"
		//''''    mySql = mySql & "  and pprov.provision_amount > 0 "
		//'''    mySQL = mySQL & " union all "
		//'''    mySQL = mySQL & " select (pias_curr_accru_lc_amount * -1) lc_amount "
		//'''    mySQL = mySQL & " , gltab.ldgr_cd, gltab.cost_cd "
		//'''    mySQL = mySQL & " , gltab.emp_cd as emp_dept_cd "
		//'''    mySQL = mySQL & " , gl_ledger.ldgr_no , cc.cost_no "
		//'''    If gPreferedLanguage = English Then
		//'''        mySQL = mySQL & ", l_ldgr_name ldgr_name, l_cost_name cost_name"
		//'''    Else
		//'''        mySQL = mySQL & ", a_ldgr_name ldgr_name, a_cost_name cost_name "
		//'''    End If
		//'''    'mySql = mySql & ", gl_ledger.apply_cost_center "
		//'''    mySQL = mySQL & ", 2 as sorder "
		//'''    ' mySql = mySql & " from pay_gl_provision pprov "
		//'''    mySQL = mySQL & " from PAY_INDEMNITY_ACCRUAL_SUMMARY pias "
		//'''    mySQL = mySQL & " inner join pay_employee pemp on pias.pias_emp_cd = pemp.emp_cd " 'added for testing
		//'''
		//'''    mySQL = mySQL & " inner join pay_employee_gl_details gltab on pemp.emp_cd = gltab.emp_cd"
		//'''    mySQL = mySQL & " left join gl_ledger on gltab.ldgr_cd = gl_ledger.ldgr_cd "
		//'''    mySQL = mySQL & " left join gl_cost_centers cc on gltab.cost_cd = cc.cost_cd "
		//'''    mySQL = mySQL & " Where "
		//'''    mySQL = mySQL & "  (gltab.bill_cd = 9) "         'indemnity provision biling cd
		//'''
		//'''    mySQL = mySQL & " and pias.pias_year = " & Year(mPrevPayrollDate) ' added for testin
		//'''    mySQL = mySQL & " and pias.pias_month =  " & Month(mPrevPayrollDate) ' added for testin
		//'''    mySQL = mySQL & " and pias.pias_curr_accru_lc_amount> 0 " ' added for testin
		//'''
		//''''    mySql = mySql & "  and pprov.provision_type = 3 "   ''indeminty provision
		//''''    mySql = mySql & "  and pprov.generate_date ='" & pVoucherDate & "'"
		//''''    mySql = mySql & "  and pprov.provision_amount > 0 "
		//'''    mySQL = mySQL & " order by gltab.emp_cd, sorder "


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
	}
}