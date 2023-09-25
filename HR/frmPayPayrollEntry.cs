
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;



namespace Xtreme
{
	internal partial class frmPayPayrollEntry
		: System.Windows.Forms.Form
	{

		public frmPayPayrollEntry()
{
InitializeComponent();
} 
 public  void frmPayPayrollEntry_old()
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
			isInitializingComponent = true;
			InitializeComponent();
			isInitializingComponent = false;
			
		}


		private void frmPayPayrollEntry_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (UpgradeHelpers.Gui.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Gui.ActivateHelper.myActiveForm = (System.Windows.Forms.Form) eventSender;
			}
		}
		private clsAccessAllowed _UserAccess = null;
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

		public Control FirstFocusObject = null;

		private clsToolbar oThisFormToolBar = null;
		private int mThisFormID = 0; //Assign the Formid for Each Form
		private string mTimeStamp = "";
		private bool mFirstGridFocus = false;
		private DataSet _rsBillingCodeList = null;
		private DataSet rsBillingCodeList
		{
			get
			{
				if (_rsBillingCodeList is null)
				{
					_rsBillingCodeList = new DataSet();
				}
				return _rsBillingCodeList;
			}
			set
			{
				_rsBillingCodeList = value;
			}
		}

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

		private object mSearchValue = null;
		private SystemVariables.SystemFormModes mCurrentFormMode = (SystemVariables.SystemFormModes) 0;

		//Private mLastCol As Integer
		//Private mLastRow As Integer

		private double mDaysPerMonth = 0;
		private double mHoursPerDay = 0;
		private double mBasicSalary = 0;
		private double mNormalOT = 0;
		private double mFridayOT = 0;
		private double mHolidayOT = 0;
		private int mPaymentTypeId = 0;
		private double mOvertimeSalary = 0;
		private double mRatePerDay = 0;

		private const int grdLineNoColumn = 0;
		private const int grdBillingCodeColumn = 1;
		private const int grdBillingNameColumn = 2;
		private const int grdBillingTypeColumn = 3;
		private const int grdBillingModeTextColumn = 4;
		private const int grdBillingModeValueColumn = 5;
		private const int grdBillingLinkedLeaveColumn = 6;
		private const int grdBillingAmtColumn = 7;
		private const int grdBillingDays = 8;
		private const int grdBillingHours = 9;
		private const int grdAmtColumn = 10;
		private const int grdRemarksColumn = 11;
		private const int grdOverTime = 12;
		//'' Added By Burhan Ghee Wala
		//'' Date  18-june-2007
		//'' New Constant for entry_id field
		private const int grdEntryId = 13;
		private const int grdTransType = 14;
		private const int grdBillTypeID = 15;
		//----
		private const int conDlblEmpCode = 0;
		private const int conDlblEmpName = 1;
		//''''Private Const conDlblMonth As Integer = 2
		//''''Private Const conDlblYear As Integer = 3
		private const int conDlblBasicSalary = 4;
		private const int conDlblLeaveSalary = 5;

		private const int conTxtMonth = 0;
		private const int conTxtYear = 1;

		private const string conFixed = "F";
		private const string conTemporary = "T";

		private const int conMaxColumns = 15;

		private string mPayrollDate = "";
		private int mOvertimeFormat = 0;
		private bool mAllowOvertime = false;
		private int mRateCalcMethod = 0;
		private int mOvertimeWorkingDays = 0;


		//The property below are used for storing the Search value returned by the Find window

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



		public SystemVariables.SystemFormModes CurrentFormMode
		{
			get
			{
				return mCurrentFormMode;
			}
			set
			{
				mCurrentFormMode = value;
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



		private void cmdRefresh_Click(Object eventSender, EventArgs eventArgs)
		{
			GetRecord(mSearchValue, true);
		}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2080
		private void Form_Load()
		{
			try
			{
				int mYear = 0;
				int cnt = 0;

				FirstFocusObject = grdVoucherDetails;
				//picFormToolbar.Visible = False
				grdVoucherDetails.Visible = false;

				this.Top = 0;
				this.Left = 0;

				//**--format & define the new toolbar
				oThisFormToolBar = new clsToolbar();
				oThisFormToolBar.AttachObject(this); //, tcbSystemForm

				oThisFormToolBar.ShowNewButton = false;
				oThisFormToolBar.ShowSaveButton = true;
				oThisFormToolBar.ShowDeleteButton = false;
				oThisFormToolBar.ShowPrintButton = false;
				oThisFormToolBar.ShowFindButton = true;
				oThisFormToolBar.ShowHelpButton = true;
				oThisFormToolBar.ShowExitButton = true;
				oThisFormToolBar.ShowInsertLineButton = true;
				oThisFormToolBar.ShowDeleteLineButton = true;
				oThisFormToolBar.BeginExitButtonWithGroup = true;
				oThisFormToolBar.DisableHelpButton = true;

				this.WindowState = FormWindowState.Maximized;
				//
				//'Assign the Image for the toolbar
				//'Imagelist are kept on the main form and refered by their key
				//Set btnFormToolBar(1).Picture = frmSysMain.imlMainToolBar.ListImages("imgSave").Picture
				//Set btnFormToolBar(3).Picture = frmSysMain.imlMainToolBar.ListImages("imgPrint").Picture
				//Set btnFormToolBar(4).Picture = frmSysMain.imlMainToolBar.ListImages("imgFind").Picture
				//Set btnFormToolBar(5).Picture = frmSysMain.imlMainToolBar.ListImages("imgHelp").Picture
				//Set btnFormToolBar(6).Picture = frmSysMain.imlMainToolBar.ListImages("imgInsertLine").Picture
				//Set btnFormToolBar(7).Picture = frmSysMain.imlMainToolBar.ListImages("imgDeleteLine").Picture
				//Set btnFormToolBar(8).Picture = frmSysMain.imlMainToolBar.ListImages("imgExit").Picture
				//'Set btnFormToolBar(9).Picture = frmSysMain.imlSystemIcons.ListImages("imgPostingTransactions").Picture

				SystemProcedure.SetLabelCaption(this);

				//Call DrawToolbar(Me, picFormToolbar, btnFormToolBar(1))
				//picFormToolbar.Visible = True


				this.CurrentFormMode = SystemVariables.SystemFormModes.frmAddMode; //setting form mode to add initially
				mFirstGridFocus = true;

				mYear = DateTime.Today.Year;
				int tempForEndVar = mYear + 1;
				for (cnt = 2000; cnt <= tempForEndVar; cnt++)
				{

					cmbYear.AddItem(cnt.ToString());
					cmbYear.SetItemData(cmbYear.NewIndex, cnt);
				}

				SystemCombo.SearchCombo(cmbYear, DateTime.Today.Year);

				cmbMonth.AddItem("Jan");
				cmbMonth.SetItemData(cmbMonth.NewIndex, 1);

				cmbMonth.AddItem("Feb");
				cmbMonth.SetItemData(cmbMonth.NewIndex, 2);

				cmbMonth.AddItem("Mar");
				cmbMonth.SetItemData(cmbMonth.NewIndex, 3);

				cmbMonth.AddItem("Apr");
				cmbMonth.SetItemData(cmbMonth.NewIndex, 4);

				cmbMonth.AddItem("May");
				cmbMonth.SetItemData(cmbMonth.NewIndex, 5);

				cmbMonth.AddItem("Jun");
				cmbMonth.SetItemData(cmbMonth.NewIndex, 6);

				cmbMonth.AddItem("Jul");
				cmbMonth.SetItemData(cmbMonth.NewIndex, 7);

				cmbMonth.AddItem("Aug");
				cmbMonth.SetItemData(cmbMonth.NewIndex, 8);

				cmbMonth.AddItem("Sep");
				cmbMonth.SetItemData(cmbMonth.NewIndex, 9);

				cmbMonth.AddItem("Oct");
				cmbMonth.SetItemData(cmbMonth.NewIndex, 10);

				cmbMonth.AddItem("Nov");
				cmbMonth.SetItemData(cmbMonth.NewIndex, 11);

				cmbMonth.AddItem("Dec");
				cmbMonth.SetItemData(cmbMonth.NewIndex, 12);

				SystemCombo.SearchCombo(cmbMonth, DateTime.Parse(SystemHRProcedure.GetPayrollGenerateDate()).Month);



				//define voucher grid columns
				SystemGrid.DefineSystemVoucherGrid(grdVoucherDetails, true, true, true, (0xFFFFFF).ToString(), (0x0).ToString(), true, true, C1.Win.C1TrueDBGrid.MarqueeEnum.SolidCellBorder, 1.47f, 1.4f, "&HBBC8CA", "&HBBC8CA");
				//define voucher grid columns
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "LN", 400, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false);
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Billing No.", 800, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, true, true, "cmbMastersList", false, true, false, false, false, false, 100, "", "", false, "", 0, true);
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Billing Name", 2700, true, ColorTranslator.ToOle(Color.White).ToString(), (0xB4261B).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "T o t a l", C1.Win.C1TrueDBGrid.AlignHorzEnum.Center, true, true, true, "cmbMastersList", false, true, false, false, false, false, 100, "", "", false, "", 0, true);
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Billing Type", 1200, false, SystemConstants.gDisableColumnBackColor, (0xB4261B).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false);
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Billing Mode", 1200, false, SystemConstants.gDisableColumnBackColor, (0xB4261B).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false);
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Billing Mode value", 0, false, SystemConstants.gDisableColumnBackColor, (0xB4261B).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, false);
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "LinkedLeaveColumn", 0, false, ColorTranslator.ToOle(Color.White).ToString(), (0xB4261B).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, false);
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "BillingAmt", 0, false, ColorTranslator.ToOle(Color.White).ToString(), (0xB4261B).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, false);
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Days", 700, true, ColorTranslator.ToOle(Color.White).ToString(), (0x1818B4).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false, true, true, "", false, true, false, false, false, true, 100, "", "", false, "", 0, true);
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Hours", 700, true, ColorTranslator.ToOle(Color.White).ToString(), (0x1818B4).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false, true, true, "", false, true, false, false, false, true, 100, "", "", false, "", 0, true);
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Amount", 1000, true, ColorTranslator.ToOle(Color.White).ToString(), (0x1818B4).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false, true, true, "", false, true, false, false, false, true, 100, "", "", false, "", 0, true);
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Remarks", 1100, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, true, false, false, true, false, 50);
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "OverTime", 0, false, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, false);
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Entry ID", 0, false, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, false);
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Trans. Type", 0, false, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, false);
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Bill Type ID", 0, false, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, false);

				//setting voucher details grid properties
				DefineVoucherArray(-1, false);
				AssignGridLineNumbers();
				//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBGrid property grdVoucherDetails.Array was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				grdVoucherDetails.setArray(aVoucherDetails);
				grdVoucherDetails.Rebind(true);
				//-- end of voucher grid property setting

				grdVoucherDetails.Visible = true;
				grdVoucherDetails.Enabled = false;

				mPayrollDate = SystemHRProcedure.GetPayrollGenerateDate();
				System.DateTime TempDate = DateTime.FromOADate(0);
				cmbMonth.Text = (DateTime.TryParse(mPayrollDate, out TempDate)) ? TempDate.ToString("MMM") : mPayrollDate;
				System.DateTime TempDate2 = DateTime.FromOADate(0);
				cmbYear.Text = (DateTime.TryParse(mPayrollDate, out TempDate2)) ? TempDate2.ToString("yyyy") : mPayrollDate;
				//UPGRADE_WARNING: (1068) GetSystemPreferenceSetting() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mOvertimeFormat = ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetSystemPreferenceSetting("Overtime_Format"));
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, excep.Message, this.Name, "Form Load");
				this.Close();
			}
		}

		private void Form_KeyDown(Object eventSender, KeyEventArgs eventArgs)
		{
			int KeyCode = (int) eventArgs.KeyCode;
			int Shift = ((int) eventArgs.KeyData) / 65536;
			try
			{
				if (Shift == 0 && KeyCode == 116 && !mFirstGridFocus)
				{
					DefineMasterRecordset();
				}

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
						if (grdVoucherDetails.Col == grdAmtColumn || grdVoucherDetails.Col == grdBillingHours || grdVoucherDetails.Col == grdBillingDays)
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


				if (KeyCode == 13)
				{
					SendKeys.Send("{TAB}");
					return;
				}
				SystemForms.SystemFormKeyDown(this, ref KeyCode, Shift, this.ActiveControl.Name);
			}
			finally
			{
				eventArgs.Handled = KeyCode == 0;
			}
		}

		private bool isInitializingComponent;
		private void Form_Resize(Object eventSender, EventArgs eventArgs)
		{
			if (isInitializingComponent)
			{
				return;
			}
			if (this.Width * 15 > 200)
			{
				grdVoucherDetails.Width = this.Width - 13;
			}

			if (this.Height * 15 > 2500)
			{
				grdVoucherDetails.Height = this.Height - 167;
			}
		}

		private void Form_Closed(Object eventSender, EventArgs eventArgs)
		{
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{
				SystemMenu.RemoveMeFromWindowList(Conversion.Str(this.Handle.ToInt32()));

				aVoucherDetails = null;
				rsBillingCodeList = null;
				UserAccess = null;
				oThisFormToolBar = null;
				frmPayPayrollEntry.DefInstance = null;
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBDropDown Event cmbMastersList.RowChange was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void cmbMastersList_RowChange()
		{
			if (grdVoucherDetails.Col == grdBillingCodeColumn || grdVoucherDetails.Col == grdBillingNameColumn)
			{
				if (grdVoucherDetails.Col == grdBillingCodeColumn)
				{
					grdVoucherDetails.Columns[grdBillingNameColumn].Value = cmbMastersList.Columns[1].Value;
				}
				else
				{
					grdVoucherDetails.Columns[grdBillingCodeColumn].Value = cmbMastersList.Columns[0].Value;
				}
				grdVoucherDetails.Columns[grdBillingTypeColumn].Value = cmbMastersList.Columns[2].Value;
				grdVoucherDetails.Columns[grdBillingModeTextColumn].Value = cmbMastersList.Columns[3].Value;
				grdVoucherDetails.Columns[grdBillingModeValueColumn].Value = cmbMastersList.Columns[4].Value;
				grdVoucherDetails.Columns[grdBillingLinkedLeaveColumn].Value = cmbMastersList.Columns[5].Value;
				grdVoucherDetails.Columns[grdBillingAmtColumn].Value = cmbMastersList.Columns[6].Value;
				grdVoucherDetails.Columns[grdOverTime].Value = cmbMastersList.Columns[7].Value;
				grdVoucherDetails.Columns[grdBillTypeID].Value = cmbMastersList.Columns[8].Value;
			}
		}

		private void grdVoucherDetails_AfterColUpdate(Object eventSender, C1.Win.C1TrueDBGrid.ColEventArgs eventArgs)
		{
			int ColIndex = eventArgs.ColIndex;
			if (ColIndex == grdAmtColumn || ColIndex == grdBillingDays || ColIndex == grdBillingHours)
			{
				grdVoucherDetails.UpdateData();
				CalculateTotals(ReflectionHelper.GetPrimitiveValue<int>(grdVoucherDetails.Bookmark), ColIndex);
				grdVoucherDetails.Refresh();
			}
		}


		private void grdVoucherDetails_ButtonClick(Object eventSender, C1.Win.C1TrueDBGrid.ColEventArgs eventArgs)
		{
			int ColIndex = eventArgs.ColIndex;
			try
			{
				if (Convert.ToString(aVoucherDetails.GetValue(grdVoucherDetails.Row, grdTransType)) != "")
				{
					//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
					grdVoucherDetails.Splits[0].DisplayColumns[grdBillingCodeColumn].Locked = true;
					//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
					grdVoucherDetails.Splits[0].DisplayColumns[grdBillingNameColumn].Locked = true;
				}
				else
				{
					//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
					grdVoucherDetails.Splits[0].DisplayColumns[grdBillingCodeColumn].Locked = false;
					//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
					grdVoucherDetails.Splits[0].DisplayColumns[grdBillingNameColumn].Locked = false;
				}
			}
			catch
			{
				//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				grdVoucherDetails.Splits[0].DisplayColumns[grdBillingCodeColumn].Locked = false;
				//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				grdVoucherDetails.Splits[0].DisplayColumns[grdBillingNameColumn].Locked = false;
			}

		}



		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBGrid Event grdVoucherDetails.FormatText was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void grdVoucherDetails_FormatText(int ColIndex, ref object Value, object Bookmark)
		{
			if (ColIndex == grdAmtColumn || ColIndex == grdBillingDays || ColIndex == grdBillingHours)
			{
				if (Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(Value)) != 0)
				{
					Value = StringsHelper.Format(ReflectionHelper.GetPrimitiveValue(Value), "###,###,###,###,##0.000");
				}
				else
				{
					Value = "";
				}
			}
		}

		private void grdVoucherDetails_GotFocus(Object eventSender, EventArgs eventArgs)
		{
			string mysql = "";

			if (mFirstGridFocus)
			{
				if (Convert.ToString(cmbMastersList.Tag) == "")
				{
					SystemGrid.DefineSystemGridCombo(cmbMastersList);
					cmbMastersList.Tag = "OK";
				}

				DefineMasterRecordset();
				mFirstGridFocus = false;
				//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBGrid method grdVoucherDetails.PostMsg was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				grdVoucherDetails.PostMsg(1);
			}
		}

		private void CalculateTotals(int mRowNumber, int mColNumber)
		{
			int cnt = 0;
			double mBillingHours = 0;
			double mBillingDays = 0;
			string mysql = "";
			object mReturnValue = null;
			double mRate = 0;
			double Amount = 0;

			double mTotalAmount = 0;

			if (aVoucherDetails.GetLength(0) > 0)
			{

				if (SystemProcedure2.IsItEmpty(aVoucherDetails.GetValue(mRowNumber, grdBillingDays), SystemVariables.DataType.NumberType))
				{
					mBillingDays = 0;
				}
				else
				{
					mBillingDays = Convert.ToDouble(aVoucherDetails.GetValue(mRowNumber, grdBillingDays));
				}

				if (SystemProcedure2.IsItEmpty(aVoucherDetails.GetValue(mRowNumber, grdBillingHours), SystemVariables.DataType.NumberType))
				{
					mBillingHours = 0;
				}
				else
				{
					mBillingHours = Convert.ToDouble(aVoucherDetails.GetValue(mRowNumber, grdBillingHours));
				}
				//For Daily wages Employee
				if (mColNumber == grdBillingDays && mRateCalcMethod == SystemHRProcedure.gDailyWages && mHoursPerDay > 0)
				{
					mRate = mRatePerDay;
					if (Convert.ToDouble(aVoucherDetails.GetValue(mRowNumber, grdOverTime)) == 1)
					{
						mRate = mRatePerDay * mNormalOT;
					}
					else if (Convert.ToDouble(aVoucherDetails.GetValue(mRowNumber, grdOverTime)) == 2)
					{ 
						mRate = mRatePerDay * mFridayOT;
					}
					else if (Convert.ToDouble(aVoucherDetails.GetValue(mRowNumber, grdOverTime)) == 3)
					{ 
						mRate = mRatePerDay * mHolidayOT;
					}
					aVoucherDetails.SetValue(SystemHRProcedure.Rounding(mBillingDays * mRate, Convert.ToInt32(aVoucherDetails.GetValue(mRowNumber, grdBillingCodeColumn))), mRowNumber, grdAmtColumn);
					aVoucherDetails.SetValue(mBillingDays * mHoursPerDay, mRowNumber, grdBillingHours);
				}
				if (mColNumber == grdBillingHours && mRateCalcMethod == SystemHRProcedure.gDailyWages && mHoursPerDay > 0)
				{
					mRate = (mRatePerDay / mHoursPerDay);
					if (Convert.ToDouble(aVoucherDetails.GetValue(mRowNumber, grdOverTime)) == 1)
					{
						mRate = (mRatePerDay / mHoursPerDay) * mNormalOT;
					}
					else if (Convert.ToDouble(aVoucherDetails.GetValue(mRowNumber, grdOverTime)) == 2)
					{ 
						mRate = (mRatePerDay / mHoursPerDay) * mFridayOT;
					}
					else if (Convert.ToDouble(aVoucherDetails.GetValue(mRowNumber, grdOverTime)) == 3)
					{ 
						mRate = (mRatePerDay / mHoursPerDay) * mHolidayOT;
					}
					aVoucherDetails.SetValue(SystemHRProcedure.Rounding(mBillingHours * mRate, Convert.ToInt32(aVoucherDetails.GetValue(mRowNumber, grdBillingCodeColumn))), mRowNumber, grdAmtColumn);
					aVoucherDetails.SetValue(mBillingHours / mHoursPerDay, mRowNumber, grdBillingDays);
				}

				if (mColNumber == grdBillingDays && mDaysPerMonth > 0)
				{
					mysql = " select bill_cd from pay_billing_type where bill_no=" + Convert.ToString(aVoucherDetails.GetValue(mRowNumber, grdBillingCodeColumn));
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));

					Amount = ReflectionHelper.GetPrimitiveValue<double>(SystemProcedure2.GetMasterCode("select isnull(dbo.GetCalculateBillingSalary(" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue) + "," + ReflectionHelper.GetPrimitiveValue<string>(mReturnValue) + "),0)"));
					if (Convert.ToDouble(aVoucherDetails.GetValue(mRowNumber, grdBillingAmtColumn)) > 0)
					{
						mRate = Convert.ToDouble(aVoucherDetails.GetValue(mRowNumber, grdBillingAmtColumn)) / mDaysPerMonth;
					}
					else
					{
						mRate = Amount / mDaysPerMonth;
					}
					if (Convert.ToDouble(aVoucherDetails.GetValue(mRowNumber, grdOverTime)) == 1)
					{ //'Normal OT
						//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to double. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mOvertimeSalary = ReflectionHelper.GetPrimitiveValue<double>(SystemProcedure2.GetMasterCode("select dbo.paygetovertimesalary(" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue) + "," + ReflectionHelper.GetPrimitiveValue<string>(mReturnValue) + ")"));
						if (mNormalOT != 0)
						{
							if (mOvertimeFormat == 1)
							{
								mRate = (mOvertimeSalary / mDaysPerMonth) * mNormalOT;
							}
							else
							{
								mRate = (mOvertimeSalary * 12 / 365d) * mNormalOT;
							}
						}
					}
					else if (Convert.ToDouble(aVoucherDetails.GetValue(mRowNumber, grdOverTime)) == 2)
					{  //'Friday OT
						//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to double. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mOvertimeSalary = ReflectionHelper.GetPrimitiveValue<double>(SystemProcedure2.GetMasterCode("select dbo.paygetovertimesalary(" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue) + "," + ReflectionHelper.GetPrimitiveValue<string>(mReturnValue) + ")"));
						if (mFridayOT != 0)
						{
							if (mOvertimeFormat == 1)
							{
								mRate = (mOvertimeSalary / mDaysPerMonth) * mFridayOT;
							}
							else
							{
								mRate = (mOvertimeSalary * 12 / 365d) * mFridayOT;
							}
						}
					}
					else if (Convert.ToDouble(aVoucherDetails.GetValue(mRowNumber, grdOverTime)) == 3)
					{  //'Holiday OT
						//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to double. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mOvertimeSalary = ReflectionHelper.GetPrimitiveValue<double>(SystemProcedure2.GetMasterCode("select dbo.paygetovertimesalary(" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue) + "," + ReflectionHelper.GetPrimitiveValue<string>(mReturnValue) + ")"));
						if (mHolidayOT != 0)
						{
							if (mOvertimeFormat == 1)
							{
								mRate = (mOvertimeSalary / mDaysPerMonth) * mHolidayOT;
							}
							else
							{
								mRate = (mOvertimeSalary * 12 / 365d) * mHolidayOT;
							}
						}
					}


					aVoucherDetails.SetValue(SystemHRProcedure.Rounding(mBillingDays * mRate, Convert.ToInt32(aVoucherDetails.GetValue(mRowNumber, grdBillingCodeColumn))), mRowNumber, grdAmtColumn);
					aVoucherDetails.SetValue(mBillingDays * mHoursPerDay, mRowNumber, grdBillingHours);
				}

				if (mColNumber == grdBillingHours && (mDaysPerMonth > 0 && mHoursPerDay > 0 && mBillingHours > 0))
				{
					mysql = " select bill_cd from pay_billing_type where bill_no=" + Convert.ToString(aVoucherDetails.GetValue(mRowNumber, grdBillingCodeColumn));
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
					Amount = ReflectionHelper.GetPrimitiveValue<double>(SystemProcedure2.GetMasterCode("select isnull(dbo.GetCalculateBillingSalary(" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue) + "," + ReflectionHelper.GetPrimitiveValue<string>(mReturnValue) + "),0)"));
					if (Convert.ToDouble(aVoucherDetails.GetValue(mRowNumber, grdBillingAmtColumn)) > 0)
					{
						mRate = (Convert.ToDouble(aVoucherDetails.GetValue(mRowNumber, grdBillingAmtColumn)) / mDaysPerMonth) / mHoursPerDay;
					}
					else
					{
						mRate = (Amount / mDaysPerMonth) / mHoursPerDay;
					}

					if (Convert.ToDouble(aVoucherDetails.GetValue(mRowNumber, grdOverTime)) == 1)
					{
						//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to double. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mOvertimeSalary = ReflectionHelper.GetPrimitiveValue<double>(SystemProcedure2.GetMasterCode("select dbo.paygetovertimesalary(" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue) + "," + ReflectionHelper.GetPrimitiveValue<string>(mReturnValue) + ")"));
						//If GetSystemPreferenceSetting("Overtime_Working_Days") <> 0 Then
						if (mOvertimeWorkingDays != 0)
						{
							mDaysPerMonth = mOvertimeWorkingDays; //GetSystemPreferenceSetting("Overtime_Working_Days")
						}
						if (mNormalOT != 0)
						{
							if (mOvertimeFormat == 1)
							{
								mRate = ((mOvertimeSalary / mDaysPerMonth) / mHoursPerDay) * mNormalOT;
							}
							else
							{
								mRate = ((mOvertimeSalary * 12) / (365 * mHoursPerDay)) * mNormalOT;
							}
						}
					}
					else if (Convert.ToDouble(aVoucherDetails.GetValue(mRowNumber, grdOverTime)) == 2)
					{  //'Friday OT
						//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to double. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mOvertimeSalary = ReflectionHelper.GetPrimitiveValue<double>(SystemProcedure2.GetMasterCode("select dbo.paygetovertimesalary(" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue) + "," + ReflectionHelper.GetPrimitiveValue<string>(mReturnValue) + ")"));
						//If GetSystemPreferenceSetting("Overtime_Working_Days") <> 0 Then
						if (mOvertimeWorkingDays != 0)
						{
							mDaysPerMonth = mOvertimeWorkingDays; //GetSystemPreferenceSetting("Overtime_Working_Days")
						}
						if (mFridayOT != 0)
						{
							if (mOvertimeFormat == 1)
							{
								mRate = ((mOvertimeSalary / mDaysPerMonth) / mHoursPerDay) * mFridayOT;
							}
							else
							{
								mRate = ((mOvertimeSalary * 12) / (365 * mHoursPerDay)) * mFridayOT;
							}
						}
					}
					else if (Convert.ToDouble(aVoucherDetails.GetValue(mRowNumber, grdOverTime)) == 3)
					{ 
						//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to double. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mOvertimeSalary = ReflectionHelper.GetPrimitiveValue<double>(SystemProcedure2.GetMasterCode("select dbo.paygetovertimesalary(" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue) + "," + ReflectionHelper.GetPrimitiveValue<string>(mReturnValue) + ")"));
						//If GetSystemPreferenceSetting("Overtime_Working_Days") <> 0 Then
						if (mOvertimeWorkingDays != 0)
						{
							mDaysPerMonth = mOvertimeWorkingDays; //GetSystemPreferenceSetting("Overtime_Working_Days")
						}
						if (mHolidayOT != 0)
						{
							if (mOvertimeFormat == 1)
							{
								mRate = ((mOvertimeSalary / mDaysPerMonth) / mHoursPerDay) * mHolidayOT;
							}
							else
							{
								mRate = ((mOvertimeSalary * 12) / (365 * mHoursPerDay)) * mHolidayOT;
							}
						}
					}

					aVoucherDetails.SetValue(SystemHRProcedure.Rounding(mBillingHours * mRate, Convert.ToInt32(aVoucherDetails.GetValue(mRowNumber, grdBillingCodeColumn))), mRowNumber, grdAmtColumn);
					aVoucherDetails.SetValue(0, mRowNumber, grdBillingDays);
				}
			}

			int tempForEndVar = aVoucherDetails.GetLength(0) - 1;
			for (cnt = 0; cnt <= tempForEndVar; cnt++)
			{
				if (Convert.ToDouble(aVoucherDetails.GetValue(cnt, grdBillTypeID)) == 51)
				{
					mTotalAmount += Conversion.Val(Convert.ToDouble(aVoucherDetails.GetValue(cnt, grdAmtColumn)).ToString());
				}
				else
				{
					mTotalAmount -= Conversion.Val(Convert.ToDouble(aVoucherDetails.GetValue(cnt, grdAmtColumn)).ToString());
				}
			}

			if (mTotalAmount != 0)
			{
				grdVoucherDetails.Columns[grdAmtColumn].FooterText = StringsHelper.Format(mTotalAmount, "###,###,###,###,##0.000");
			}
			else
			{
				grdVoucherDetails.Columns[grdAmtColumn].FooterText = "";
			}
		}

		private void AssignGridLineNumbers()
		{
			int cnt = 0;
			int tempForEndVar = aVoucherDetails.GetLength(0) - 1;
			for (cnt = 0; cnt <= tempForEndVar; cnt++)
			{
				aVoucherDetails.SetValue(cnt + 1, cnt, grdLineNoColumn);
			}
		}

		private void DefineVoucherArray(int pMaximumRows, bool pClearArray = false)
		{
			if (pClearArray)
			{
				//UPGRADE_ISSUE: (2064) XArrayDBObject.XArrayDB method aVoucherDetails.Clear was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				aVoucherDetails.Clear();
			}
			aVoucherDetails.RedimXArray(new int[]{pMaximumRows, conMaxColumns}, new int[]{0, 0});
		}

		public bool saveRecord(bool pApprove = false)
		{
			int mBillingCode = 0;
			int mDeptCd = 0;
			int mCompCd = 0;
			int mDesgCd = 0;
			int mBankCd = 0;
			string mBankAccountNo = "";
			int mProjectcd = 0;
			int mSponsorCd = 0;
			object mReturnValue = null;
			int cnt = 0;
			int mPayrollMasterEntID = 0;

			//On Error GoTo eFoundError

			SystemVariables.gConn.BeginTransaction();

			SqlDataReader rsTempRec = null;
			//'Added by burhan
			// Date: 18-june-2007
			// Des : Added entry_id in mySql
			string mysql = " select entry_id, bill_cd ,billing_mode from pay_payroll ";
			mysql = mysql + " where emp_cd=" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
			//mySql = mySql & " and pay_date='" & gPayrollGenerateDate & "'"
			mysql = mysql + " and pay_date='" + mPayrollDate + "'";

			SqlCommand sqlCommand = new SqlCommand(mysql, SystemVariables.gConn);
			rsTempRec = sqlCommand.ExecuteReader();
			rsTempRec.Read();
			do 
			{
				if (aVoucherDetails.GetLength(0) == 0)
				{
					mysql = " delete from pay_payroll ";
					mysql = mysql + " where emp_cd=" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
					mysql = mysql + " and pay_date='" + mPayrollDate + "'";
					SqlCommand TempCommand = null;
					TempCommand = SystemVariables.gConn.CreateCommand();
					TempCommand.CommandText = mysql;
					TempCommand.ExecuteNonQuery();
					break;
				}
				else
				{
					int tempForEndVar = aVoucherDetails.GetLength(0) - 1;
					for (cnt = 0; cnt <= tempForEndVar; cnt++)
					{
						mysql = " select bill_cd from pay_billing_type where bill_no=" + Convert.ToString(aVoucherDetails.GetValue(cnt, grdBillingCodeColumn));
						//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));

						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
						if (Convert.IsDBNull(mReturnValue))
						{
							//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
							SystemVariables.gConn.RollbackTrans();
							MessageBox.Show("Invalid Billing Code", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
							grdVoucherDetails.Col = grdBillingCodeColumn;
							grdVoucherDetails.Bookmark = cnt;
							grdVoucherDetails.Focus();
							return false;
						}
						else
						{

							//''//Added by burhan ghee
							//Date: 18-jun-2007
							//Desc: If condition for entry_id column

							//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							mBillingCode = ReflectionHelper.GetPrimitiveValue<int>(mReturnValue);
							//If mBillingCode = .Fields("bill_cd") And aVoucherDetails(cnt, grdBillingModeValueColumn) = .Fields("billing_mode") Then

							if (aVoucherDetails.GetValue(cnt, grdEntryId) == rsTempRec["entry_id"])
							{
								break;
							}
							else
							{
								if (cnt == aVoucherDetails.GetLength(0) - 1)
								{
									mysql = " delete from pay_payroll ";
									mysql = mysql + " where entry_id=" + Convert.ToString(rsTempRec["entry_id"]); //aVoucherDetails(cnt, grdEntryId)
									//mySql = mySql & " where emp_cd=" & mSearchValue
									//mySql = mySql & " and bill_cd=" & .Fields("bill_cd")
									//mySql = mySql & " and pay_date='" & mPayrollDate & "'"
									//mySql = mySql & " and billing_mode ='" & .Fields("billing_mode") & "'"
									/////end edit by burhan----------------------

									SqlCommand TempCommand_2 = null;
									TempCommand_2 = SystemVariables.gConn.CreateCommand();
									TempCommand_2.CommandText = mysql;
									TempCommand_2.ExecuteNonQuery();
								}
							}
						}
					}
				}
			}
			while(rsTempRec.Read());

			mysql = "select entry_id from pay_payroll_master where emp_cd = " + SystemHRProcedure.GetEmpCd(txtDisplayLabel[conDlblEmpCode].Text).ToString();
			mysql = mysql + " and pay_date ='" + SystemHRProcedure.GetPayrollGenerateDate() + "'";
			//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (Convert.IsDBNull(mReturnValue))
			{
				return false;
			}
			else
			{
				mPayrollMasterEntID = ReflectionHelper.GetPrimitiveValue<int>(mReturnValue);
			}

			int tempForEndVar2 = aVoucherDetails.GetLength(0) - 1;
			for (cnt = 0; cnt <= tempForEndVar2; cnt++)
			{
				mysql = " select bill_cd from pay_billing_type where bill_no=" + Convert.ToString(aVoucherDetails.GetValue(cnt, grdBillingCodeColumn));
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));

				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (Convert.IsDBNull(mReturnValue))
				{
					//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					SystemVariables.gConn.RollbackTrans();
					MessageBox.Show("Invalid Billing Code", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
					grdVoucherDetails.Col = grdBillingCodeColumn;
					grdVoucherDetails.Bookmark = cnt;
					grdVoucherDetails.Focus();
					return false;
				}
				else
				{
					//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mBillingCode = ReflectionHelper.GetPrimitiveValue<int>(mReturnValue);
				}

				//'Get the employee Informations
				mysql = " select dept_cd, desg_cd, Bank_cd , bank_account_no, sponsor_cd , default_project, Comp_cd from pay_employee ";
				mysql = mysql + " where emp_cd=" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(mReturnValue))
				{
					//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mDeptCd = ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue).GetValue(0));
					//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mDesgCd = ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue).GetValue(1));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					mBankCd = (Convert.IsDBNull(((Array) mReturnValue).GetValue(2))) ? 0 : ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue).GetValue(2));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					mBankAccountNo = (Convert.IsDBNull(((Array) mReturnValue).GetValue(3))) ? "" : ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(3));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					mSponsorCd = (Convert.IsDBNull(((Array) mReturnValue).GetValue(4))) ? 0 : ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue).GetValue(4));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					mProjectcd = (Convert.IsDBNull(((Array) mReturnValue).GetValue(5))) ? 0 : ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue).GetValue(5));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					mCompCd = (Convert.IsDBNull(((Array) mReturnValue).GetValue(6))) ? 0 : ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue).GetValue(6));
				}

				//    mySql = " select bill_cd from pay_payroll "
				//    mySql = mySql & " where bill_cd=" & mBillingCode
				//    mySql = mySql & " and emp_cd=" & mSearchValue
				//    mySql = mySql & " and pay_date='" & mPayrollDate & "'"
				//    mySql = mySql & " and billing_mode ='" & aVoucherDetails(cnt, grdBillingModeValueColumn) & "'"
				//
				//    mReturnValue = GetMasterCode(mySql)
				//If IsNull(mReturnValue) Then
				if (Convert.ToString(aVoucherDetails.GetValue(cnt, grdEntryId)) == "")
				{
					mysql = " insert into pay_payroll ";
					mysql = mysql + " (master_entry_id, pay_date, emp_cd, bill_cd, dept_cd, desg_cd ";
					mysql = mysql + " , billing_mode, pay_days, pay_hours, fc_amount";
					mysql = mysql + " , linked_leave, salary , payment_type_id ";
					mysql = mysql + " , comments, user_cd, project_cd , sponsor_cd , bank_cd , bank_account_no,comp_cd) ";
					mysql = mysql + " select ";
					mysql = mysql + mPayrollMasterEntID.ToString();
					mysql = mysql + " ,'" + mPayrollDate + "'";
					mysql = mysql + " ," + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
					mysql = mysql + " ," + mBillingCode.ToString();
					mysql = mysql + " ," + mDeptCd.ToString();
					mysql = mysql + " ," + mDesgCd.ToString();
					mysql = mysql + " ,'" + Convert.ToString(aVoucherDetails.GetValue(cnt, grdBillingModeValueColumn)) + "'";
					mysql = mysql + " ," + ((SystemProcedure2.IsItEmpty(aVoucherDetails.GetValue(cnt, grdBillingDays), SystemVariables.DataType.NumberType)) ? "0" : Convert.ToString(aVoucherDetails.GetValue(cnt, grdBillingDays)));
					mysql = mysql + " ," + ((SystemProcedure2.IsItEmpty(aVoucherDetails.GetValue(cnt, grdBillingHours), SystemVariables.DataType.NumberType)) ? "0" : Convert.ToString(aVoucherDetails.GetValue(cnt, grdBillingHours)));
					mysql = mysql + " ," + ((SystemProcedure2.IsItEmpty(aVoucherDetails.GetValue(cnt, grdAmtColumn), SystemVariables.DataType.NumberType)) ? 0 : Convert.ToDouble(aVoucherDetails.GetValue(cnt, grdAmtColumn))).ToString();
					mysql = mysql + " ," + ((SystemProcedure2.IsItEmpty(aVoucherDetails.GetValue(cnt, grdBillingLinkedLeaveColumn), SystemVariables.DataType.NumberType)) ? "0" : Convert.ToString(aVoucherDetails.GetValue(cnt, grdBillingLinkedLeaveColumn)));
					mysql = mysql + " ," + ((SystemProcedure2.IsItEmpty(aVoucherDetails.GetValue(cnt, grdBillingAmtColumn), SystemVariables.DataType.NumberType)) ? "0" : Convert.ToString(aVoucherDetails.GetValue(cnt, grdBillingAmtColumn)));
					mysql = mysql + " ," + Conversion.Str(mPaymentTypeId);
					mysql = mysql + " ,N'" + Convert.ToString(aVoucherDetails.GetValue(cnt, grdRemarksColumn)) + "'";
					mysql = mysql + " ," + Conversion.Str(SystemVariables.gLoggedInUserCode);
					mysql = mysql + " ," + ((mProjectcd == 0) ? "Null" : mProjectcd.ToString());
					mysql = mysql + " ," + ((mSponsorCd == 0) ? "Null" : mSponsorCd.ToString());
					mysql = mysql + " ," + ((mBankCd == 0) ? "Null" : mBankCd.ToString());
					mysql = mysql + " ,'" + mBankAccountNo + "'";
					mysql = mysql + " ," + ((mCompCd == 0) ? "Null" : mCompCd.ToString());
					SqlCommand TempCommand_3 = null;
					TempCommand_3 = SystemVariables.gConn.CreateCommand();
					TempCommand_3.CommandText = mysql;
					TempCommand_3.ExecuteNonQuery();
				}
				else
				{
					mysql = " update pay_payroll set ";
					mysql = mysql + " pay_days = " + ((SystemProcedure2.IsItEmpty(aVoucherDetails.GetValue(cnt, grdBillingDays), SystemVariables.DataType.NumberType)) ? "0" : Convert.ToString(aVoucherDetails.GetValue(cnt, grdBillingDays)));
					mysql = mysql + " , pay_hours = " + ((SystemProcedure2.IsItEmpty(aVoucherDetails.GetValue(cnt, grdBillingHours), SystemVariables.DataType.NumberType)) ? "0" : Convert.ToString(aVoucherDetails.GetValue(cnt, grdBillingHours)));
					mysql = mysql + " , fc_amount = " + ((SystemProcedure2.IsItEmpty(aVoucherDetails.GetValue(cnt, grdAmtColumn), SystemVariables.DataType.NumberType)) ? 0 : Convert.ToDouble(aVoucherDetails.GetValue(cnt, grdAmtColumn))).ToString();
					mysql = mysql + " , bill_cd = " + mBillingCode.ToString();
					mysql = mysql + " , dept_cd = " + mDeptCd.ToString();
					mysql = mysql + " , desg_cd = " + mDesgCd.ToString();
					mysql = mysql + " , payment_type_id = " + mPaymentTypeId.ToString();
					mysql = mysql + " , comments = N'" + Convert.ToString(aVoucherDetails.GetValue(cnt, grdRemarksColumn)) + "'";
					mysql = mysql + " , user_cd=" + Conversion.Str(SystemVariables.gLoggedInUserCode);
					mysql = mysql + " , user_date_time = '" + DateTimeHelper.ToString(DateTime.Today) + "'";
					mysql = mysql + " , project_cd = " + ((mProjectcd == 0) ? "Null" : mProjectcd.ToString());
					mysql = mysql + " , sponsor_cd = " + ((mSponsorCd == 0) ? "Null" : mSponsorCd.ToString());
					mysql = mysql + " , bank_cd = " + ((mBankCd == 0) ? "Null" : mBankCd.ToString());
					mysql = mysql + " , Comp_cd = " + ((mCompCd == 0) ? "Null" : mCompCd.ToString());
					mysql = mysql + " , bank_account_no ='" + mBankAccountNo + "'";
					mysql = mysql + " where entry_id =" + Convert.ToInt32(aVoucherDetails.GetValue(cnt, grdEntryId)).ToString();
					SqlCommand TempCommand_4 = null;
					TempCommand_4 = SystemVariables.gConn.CreateCommand();
					TempCommand_4.CommandText = mysql;
					TempCommand_4.ExecuteNonQuery();
				}
			}


			//''Commented by burhan ghee
			//Date: 18-jun-2007
			//Desc: Adding entry_id field in grid
			//Set rsTempRec = New ADODB.Recordset
			//mySql = " select bill_cd ,billing_mode from pay_payroll "
			//mySql = mySql & " where emp_cd=" & mSearchValue
			//'mySql = mySql & " and pay_date='" & gPayrollGenerateDate & "'"
			//mySql = mySql & " and pay_date='" & mPayrollDate & "'"
			//
			//rsTempRec.Open mySql, gConn, adOpenDynamic, adLockReadOnly
			//With rsTempRec
			//    Do While Not .EOF
			//        If aVoucherDetails.Count(1) = 0 Then
			//            mySql = " delete from pay_payroll "
			//            mySql = mySql & " where emp_cd=" & mSearchValue
			//            mySql = mySql & " and pay_date='" & mPayrollDate & "'"
			//            gConn.Execute mySql
			//            Exit Do
			//        Else
			//            For cnt = 0 To aVoucherDetails.Count(1) - 1
			//                mySql = " select bill_cd from pay_billing_type where bill_no=" & aVoucherDetails(cnt, grdBillingCodeColumn)
			//                mReturnValue = GetMasterCode(mySql)
			//
			//                If IsNull(mReturnValue) Then
			//                    gConn.RollbackTrans
			//                    MsgBox "Invalid Billing Code", vbInformation, "Error"
			//                    grdVoucherDetails.Col = grdBillingCodeColumn
			//                    grdVoucherDetails.Bookmark = cnt
			//                    grdVoucherDetails.SetFocus
			//                    saveRecord = False
			//                    Exit Function
			//                Else
			//                    mBillingCode = mReturnValue
			//                    If mBillingCode = .Fields("bill_cd") And aVoucherDetails(cnt, grdBillingModeValueColumn) = .Fields("billing_mode") Then
			//                        Exit For
			//                    Else
			//                        If cnt = aVoucherDetails.Count(1) - 1 Then
			//                            mySql = " delete from pay_payroll "
			//                            mySql = mySql & " where emp_cd=" & mSearchValue
			//                            mySql = mySql & " and bill_cd=" & .Fields("bill_cd")
			//                            mySql = mySql & " and pay_date='" & mPayrollDate & "'"
			//                            mySql = mySql & " and billing_mode ='" & .Fields("billing_mode") & "'"
			//                            gConn.Execute mySql
			//                        End If
			//                    End If
			//                End If
			//            Next cnt
			//        End If
			//        .MoveNext
			//    Loop
			//End With
			//
			//For cnt = 0 To aVoucherDetails.Count(1) - 1
			//    mySql = " select bill_cd from pay_billing_type where bill_no=" & aVoucherDetails(cnt, grdBillingCodeColumn)
			//    mReturnValue = GetMasterCode(mySql)
			//
			//    If IsNull(mReturnValue) Then
			//        gConn.RollbackTrans
			//        MsgBox "Invalid Billing Code", vbInformation, "Error"
			//        grdVoucherDetails.Col = grdBillingCodeColumn
			//        grdVoucherDetails.Bookmark = cnt
			//        grdVoucherDetails.SetFocus
			//        saveRecord = False
			//        Exit Function
			//    Else
			//        mBillingCode = mReturnValue
			//    End If
			//
			//    ''Get the employee Informations
			//    mySql = " select dept_cd, desg_cd from pay_employee "
			//    mySql = mySql & " where emp_cd=" & mSearchValue
			//    mReturnValue = GetMasterCode(mySql)
			//    If Not IsNull(mReturnValue) Then
			//        mDeptCd = mReturnValue(0)
			//        mDesgCd = mReturnValue(1)
			//    End If
			//
			//    mySql = " select bill_cd from pay_payroll "
			//    mySql = mySql & " where bill_cd=" & mBillingCode
			//    mySql = mySql & " and emp_cd=" & mSearchValue
			//    mySql = mySql & " and pay_date='" & mPayrollDate & "'"
			//    mySql = mySql & " and billing_mode ='" & aVoucherDetails(cnt, grdBillingModeValueColumn) & "'"
			//
			//    mReturnValue = GetMasterCode(mySql)
			//    If IsNull(mReturnValue) Then
			//
			//        mySql = " insert into pay_payroll "
			//        mySql = mySql & " (pay_date, emp_cd, bill_cd, dept_cd, desg_cd "
			//        mySql = mySql & " , billing_mode, pay_days, pay_hours, fc_amount"
			//        mySql = mySql & " , linked_leave, salary , payment_type_id "
			//        mySql = mySql & " , comments, user_cd) "
			//        mySql = mySql & " select "
			//        mySql = mySql & " '" & mPayrollDate & "'"
			//        mySql = mySql & " ," & mSearchValue
			//        mySql = mySql & " ," & mBillingCode
			//        mySql = mySql & " ," & mDeptCd
			//        mySql = mySql & " ," & mDesgCd
			//        mySql = mySql & " ,'" & aVoucherDetails(cnt, grdBillingModeValueColumn) & "'"
			//        mySql = mySql & " ," & IIf(IsItEmpty(aVoucherDetails(cnt, grdBillingDays), NumberType), 0, aVoucherDetails(cnt, grdBillingDays))
			//        mySql = mySql & " ," & IIf(IsItEmpty(aVoucherDetails(cnt, grdBillingHours), NumberType), 0, aVoucherDetails(cnt, grdBillingHours))
			//        mySql = mySql & " ," & IIf(IsItEmpty(aVoucherDetails(cnt, grdAmtColumn), NumberType), 0, aVoucherDetails(cnt, grdAmtColumn))
			//        mySql = mySql & " ," & IIf(IsItEmpty(aVoucherDetails(cnt, grdBillingLinkedLeaveColumn), NumberType), 0, aVoucherDetails(cnt, grdBillingLinkedLeaveColumn))
			//        mySql = mySql & " ," & IIf(IsItEmpty(aVoucherDetails(cnt, grdBillingAmtColumn), NumberType), 0, aVoucherDetails(cnt, grdBillingAmtColumn))
			//        mySql = mySql & " ," & Str(mPaymentTypeId)
			//        mySql = mySql & " ,N'" & aVoucherDetails(cnt, grdRemarksColumn) & "'"
			//        mySql = mySql & " ," & Str(gLoggedInUserCode)
			//        gConn.Execute mySql
			//    Else
			//        mySql = " update pay_payroll set "
			//        mySql = mySql & " pay_days = " & IIf(IsItEmpty(aVoucherDetails(cnt, grdBillingDays), NumberType), 0, aVoucherDetails(cnt, grdBillingDays))
			//        mySql = mySql & " , pay_hours = " & IIf(IsItEmpty(aVoucherDetails(cnt, grdBillingHours), NumberType), 0, aVoucherDetails(cnt, grdBillingHours))
			//        mySql = mySql & " , fc_amount = " & IIf(IsItEmpty(aVoucherDetails(cnt, grdAmtColumn), NumberType), 0, aVoucherDetails(cnt, grdAmtColumn))
			//        mySql = mySql & " , dept_cd = " & mDeptCd
			//        mySql = mySql & " , desg_cd = " & mDesgCd
			//        mySql = mySql & " , payment_type_id = " & mPaymentTypeId
			//        mySql = mySql & " , comments = N'" & aVoucherDetails(cnt, grdRemarksColumn) & "'"
			//        mySql = mySql & " , user_cd=" & Str(gLoggedInUserCode)
			//        mySql = mySql & " where emp_cd =" & mSearchValue
			//        mySql = mySql & " and bill_cd=" & mBillingCode
			//        mySql = mySql & " and pay_date='" & mPayrollDate & "'"
			//        mySql = mySql & " and billing_mode ='" & aVoucherDetails(cnt, grdBillingModeValueColumn) & "'"
			//        gConn.Execute mySql
			//    End If
			//Next
			//If Not IsItEmpty(txtComments.Text, StringType) Then
			mysql = "update pay_payroll_master";
			mysql = mysql + " set comments = N'" + txtComments.Text + "'";
			mysql = mysql + " where entry_id = " + mPayrollMasterEntID.ToString();
			SqlCommand TempCommand_5 = null;
			TempCommand_5 = SystemVariables.gConn.CreateCommand();
			TempCommand_5.CommandText = mysql;
			TempCommand_5.ExecuteNonQuery();
			//End If
			//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.CommitTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			SystemVariables.gConn.CommitTrans();
			grdVoucherDetails.Enabled = false;
			Application.DoEvents();
			return true;



			//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
			int mReturnErrorType = SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, Information.Err().Description, this.Name, "GetRecord", SystemConstants.msg10);
			//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			SystemVariables.gConn.RollbackTrans();
			MessageBox.Show(Information.Err().Description, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));

			return false;
		}

		public bool CheckDataValidity()
		{
			int cnt = 0;

			if (SystemProcedure2.IsItEmpty(mSearchValue, SystemVariables.DataType.NumberType))
			{
				MessageBox.Show("Select an employee!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
				return false;
			}

			if (DateTime.Parse(mPayrollDate) != DateTime.Parse(SystemHRProcedure.GetPayrollGenerateDate()))
			{
				MessageBox.Show("Cannot save Transaction not in the current month payroll ", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
				return false;
			}


			//*-- update all the current voucher grid information in grid's internal buffer
			grdVoucherDetails.UpdateData();

			int tempForEndVar = aVoucherDetails.GetLength(0) - 1;
			for (cnt = 0; cnt <= tempForEndVar; cnt++)
			{
				//check for ledger details (e.g. ledger code, debit amount or credit amount)
				if (SystemProcedure2.IsItEmpty(aVoucherDetails.GetValue(cnt, grdBillingCodeColumn), SystemVariables.DataType.NumberType))
				{
					MessageBox.Show("Invalid Billing Code", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
					grdVoucherDetails.Col = grdBillingCodeColumn;
					grdVoucherDetails.Bookmark = cnt;
					grdVoucherDetails.Focus();
					return false;
				}
				//Check if any Amount is less then zero or not
				if (!SystemProcedure2.IsItEmpty(aVoucherDetails.GetValue(cnt, grdAmtColumn), SystemVariables.DataType.NumberType))
				{
					if (Convert.ToDouble(aVoucherDetails.GetValue(cnt, grdAmtColumn)) < 0)
					{
						MessageBox.Show("Amount cannot be less than 0.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
						grdVoucherDetails.Col = grdAmtColumn;
						grdVoucherDetails.Bookmark = cnt;
						grdVoucherDetails.Focus();
						return false;
					}
				}
			}

			//'' Commented By Burhanuddin Ghee Wala
			//'' Date 18-june-2007
			//For cnt = 0 To aVoucherDetails.Count(1) - 1
			//    'check for ledger details (e.g. ledger code, debit amount or credit amount)
			//    mBillingCode = aVoucherDetails(cnt, grdBillingCodeColumn)
			//    For cnt1 = cnt + 1 To aVoucherDetails.Count(1) - 1
			//        If mBillingCode = aVoucherDetails(cnt1, grdBillingCodeColumn) Then
			//            MsgBox "Duplicate Billing Code"
			//            grdVoucherDetails.Col = grdBillingCodeColumn
			//            grdVoucherDetails.Bookmark = cnt1
			//            grdVoucherDetails.SetFocus
			//            CheckDataValidity = False
			//            Exit Function
			//        End If
			//    Next cnt1
			//Next

			//''' // End Comment


			return true;
		}

		public void AddRecord()
		{
			int cnt = 0;

			try
			{

				int tempForEndVar = grdVoucherDetails.Columns.Count - 1;
				for (cnt = 0; cnt <= tempForEndVar; cnt++)
				{
					grdVoucherDetails.Columns[cnt].FooterText = "";
				}

				mCurrentFormMode = SystemVariables.SystemFormModes.frmAddMode; //Change the form mode to addmode

				SystemProcedure2.ClearTextBox(this);
				DefineVoucherArray(-1, true);
				AssignGridLineNumbers();
				grdVoucherDetails.Rebind(true);
				grdVoucherDetails.Enabled = false;

				mPayrollDate = SystemHRProcedure.GetPayrollGenerateDate();
				System.DateTime TempDate = DateTime.FromOADate(0);
				cmbMonth.Text = (DateTime.TryParse(mPayrollDate, out TempDate)) ? TempDate.ToString("MMM") : mPayrollDate;
				System.DateTime TempDate2 = DateTime.FromOADate(0);
				cmbYear.Text = (DateTime.TryParse(mPayrollDate, out TempDate2)) ? TempDate2.ToString("yyyy") : mPayrollDate;

				mSearchValue = ""; //Change the msearchvalue to blank
				mPayrollDate = "";
				mFirstGridFocus = true;
				//FirstFocusObject.SetFocus
			}
			catch (System.Exception excep)
			{
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, excep.Message, this.Name, "AddRecord");
			}


		}

		public int mymonth(string mnthstring)
		{
			int result = 0;
			int i = 0;

			for (i = 1; i <= 12; i++)
			{
				if (DateAndTime.DateSerial(1, i, 1).ToString("MMM").ToUpper() == mnthstring.ToUpper())
				{
					result = i;
				}
			}

			return result;
		}

		public void GetRecord(object pSearchValue, bool pSearchByEmpCd = false)
		{
			string mysql = "";
			int mEmpCd = 0;
			object mReturnValue = null;
			SqlDataReader rsLocalRec = null;
			System.DateTime mTempDate = DateTime.FromOADate(0);
			int cnt = 0;
			int mPayrollMasterEntID = 0;

			//On Error GoTo eFoundError
			//'''
			//'''mPayrollDate = GetPayrollGenerateDate
			//mTempDate = DateSerial(cmbYear.ItemData(cmbYear.ListIndex), cmbMonth.ItemData(cmbMonth.ListIndex) + 1, 1) 'KHChange
			mPayrollDate = StringsHelper.Format(DateAndTime.DateSerial(cmbYear.GetItemData(cmbYear.ListIndex), cmbMonth.GetItemData(cmbMonth.ListIndex), DateAndTime.Day(DateTime.Parse(SystemHRProcedure.GetPayrollGenerateDate()))), SystemVariables.gSystemDateFormat);
			//mPayrollDate = DateAdd("d", -1, mTempDate)
			if (mPayrollDate == "")
			{
				return;
			}

			//''''Get the values by entryId
			//''''this is called from report drill down
			//''''other wise normally by emp code
			if (!pSearchByEmpCd)
			{
				mysql = " select emp_cd , pay_date ";
				mysql = mysql + " from pay_payroll ";
				mysql = mysql + " where entry_id =" + ReflectionHelper.GetPrimitiveValue<string>(pSearchValue);
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(mReturnValue))
				{
					//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mEmpCd = ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue).GetValue(0));
					//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mPayrollDate = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(1));
				}
			}
			else
			{
				//UPGRADE_WARNING: (1068) pSearchValue of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mEmpCd = ReflectionHelper.GetPrimitiveValue<int>(pSearchValue);
			}

			mysql = " select pay_emp.emp_no, pay_emp.emp_cd ";
			if (SystemVariables.gPreferedLanguage == SystemVariables.Language.English)
			{
				mysql = mysql + " , l_first_name + ' ' + l_second_name + ' ' + l_third_name + ' ' + l_fourth_name as emp_name";
			}
			else
			{
				mysql = mysql + " , a_first_name + ' ' + a_second_name + ' ' + a_third_name + ' ' + a_fourth_name as emp_name ";
			}
			mysql = mysql + " , basic_salary ";
			mysql = mysql + " , total_salary ";
			mysql = mysql + " , days_per_month ";
			mysql = mysql + " , hours_per_day ";
			mysql = mysql + " , isnull(normal_ot,0) ";
			mysql = mysql + " , payment_type_id ";
			mysql = mysql + " , isnull(friday_ot,0) ";
			mysql = mysql + " , isnull(holiday_ot,0) ";
			mysql = mysql + " , rate_calc_method_id ";
			mysql = mysql + " , weekend_day1_id ";
			mysql = mysql + " , weekend_day2_id ";
			mysql = mysql + " , allow_overtime ";
			mysql = mysql + " , is_payroll_emp";
			mysql = mysql + " , status_cd";
			mysql = mysql + " , rate_per_day";
			mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_dept_name" : "a_dept_name");
			mysql = mysql + " , pay_emp.Overtime_Working_Days";
			mysql = mysql + " from pay_employee pay_emp ";
			mysql = mysql + " inner join pay_department pdept on pdept.dept_cd = pay_emp.dept_cd";
			mysql = mysql + " where pay_emp.emp_cd = " + Conversion.Str(mEmpCd);
			//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(mReturnValue))
			{
				//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mSearchValue = ReflectionHelper.GetPrimitiveValue(((Array) mReturnValue).GetValue(1));
				DefineVoucherArray(0, true);
				cnt = 0;
				//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				txtDisplayLabel[conDlblEmpCode].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(0));
				//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				txtEmployeeCode.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(0));
				//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				txtDisplayLabel[conDlblEmpName].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(2));
				txtDlblDeptName.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(18)) + "";
				txtDisplayLabel[conDlblBasicSalary].Text = StringsHelper.Format(ReflectionHelper.GetPrimitiveValue(((Array) mReturnValue).GetValue(3)), "###,###,##0.000");
				txtDisplayLabel[conDlblLeaveSalary].Text = StringsHelper.Format(ReflectionHelper.GetPrimitiveValue(((Array) mReturnValue).GetValue(4)), "###,###,##0.000");
				//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mOvertimeWorkingDays = ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue).GetValue(19));
				//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to double. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mBasicSalary = ReflectionHelper.GetPrimitiveValue<double>(((Array) mReturnValue).GetValue(3));
				//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to double. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mHoursPerDay = ReflectionHelper.GetPrimitiveValue<double>(((Array) mReturnValue).GetValue(6));
				//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to double. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mNormalOT = ReflectionHelper.GetPrimitiveValue<double>(((Array) mReturnValue).GetValue(7));
				//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mPaymentTypeId = ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue).GetValue(8));
				//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to double. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mFridayOT = ReflectionHelper.GetPrimitiveValue<double>(((Array) mReturnValue).GetValue(9));
				//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to double. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mHolidayOT = ReflectionHelper.GetPrimitiveValue<double>(((Array) mReturnValue).GetValue(10));
				//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mRateCalcMethod = ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue).GetValue(11));
				if (ReflectionHelper.GetPrimitiveValue<double>(((Array) mReturnValue).GetValue(11)) == SystemHRProcedure.gFixedDays)
				{
					//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to double. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mDaysPerMonth = ReflectionHelper.GetPrimitiveValue<double>(((Array) mReturnValue).GetValue(5));
				}
				else if (ReflectionHelper.GetPrimitiveValue<double>(((Array) mReturnValue).GetValue(11)) == SystemHRProcedure.gActualDays)
				{ 
					mDaysPerMonth = SystemHRProcedure.CalculateDays(DateTime.Parse(SystemHRProcedure.GetPayrollGenerateStartDate()), DateTime.Parse(SystemHRProcedure.GetPayrollGenerateDate()), ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue).GetValue(12)), ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue).GetValue(13)));
				}
				mAllowOvertime = ReflectionHelper.GetPrimitiveValue<bool>(((Array) mReturnValue).GetValue(14));
				mRatePerDay = ReflectionHelper.GetPrimitiveValue<double>(((Array) mReturnValue).GetValue(17));
				//txtDlblPayrollEmployee.Text = IIf(mReturnValue(15), "Yes", "No")
				//txtDlblStatus.Text = IIf(mReturnValue(16) = 1, "Active", "On Leave")
				mCurrentFormMode = SystemVariables.SystemFormModes.frmEditMode;
			}
			else
			{
				mCurrentFormMode = SystemVariables.SystemFormModes.frmAddMode;
				return;
			}
			//'''' year and month Enter by user to get any month payroll
			//'''''txtDisplayLabel(conDlblMonth).Text = Format(mPayrollDate, "mmm")
			//'''''txtDisplayLabel(conDlblYear).Text = Format(mPayrollDate, "yyyy")


			mysql = " select pbt.bill_no ";
			if (SystemVariables.gPreferedLanguage == SystemVariables.Language.English)
			{
				mysql = mysql + " , pbt.l_bill_name as bill_name ";
				mysql = mysql + " , (select l_object_caption from SM_Objects where object_id=pbt.bill_type_id) as bill_type ";
			}
			else
			{
				mysql = mysql + " , pbt.a_bill_name as bill_name";
				mysql = mysql + " , (select a_object_caption from SM_Objects where object_id=pbt.bill_type_id) as bill_type ";
			}
			mysql = mysql + ", case   when billing_mode = 'T' then 'Temporary' when  billing_mode = 'F' then 'Fixed' else 'Manual'  end as bill_mode_text ";
			mysql = mysql + ", Linked_Leave, isnull(salary,0) as salary ";
			mysql = mysql + ", ppe.billing_mode, ppe.pay_days ";
			mysql = mysql + ", ppe.pay_hours, ppe.fc_amount, ppe.comments, pbt.bill_type_id as bill_type_id ";
			//''Added by burhan ghee
			//date: 18-june-2007
			//Desc: Added field entry_id in recordset
			mysql = mysql + ",  ppe.entry_id, ppe.trans_type ";
			//----------
			mysql = mysql + ", pbt.over_time, ppe.master_entry_id ";
			mysql = mysql + " from pay_payroll ppe ";
			mysql = mysql + " inner join pay_billing_type pbt on ppe.bill_cd = pbt.bill_cd ";
			mysql = mysql + " where ppe.emp_cd = " + Conversion.Str(mEmpCd);
			mysql = mysql + " and ppe.pay_date='" + mPayrollDate + "'";

			SqlCommand sqlCommand = new SqlCommand(mysql, SystemVariables.gConn);
			rsLocalRec = sqlCommand.ExecuteReader();
			if (rsLocalRec.Read())
			{
				do 
				{
					DefineVoucherArray(cnt, false);
					aVoucherDetails.SetValue(Conversion.Str(cnt + 1).Trim(), cnt, grdLineNoColumn);

					//''Added by burhan ghee
					//date: 18-june-2007
					//Desc: Added field entry_id in grid
					aVoucherDetails.SetValue(rsLocalRec["entry_id"], cnt, grdEntryId);
					aVoucherDetails.SetValue(Convert.ToString(rsLocalRec["trans_type"]) + "", cnt, grdTransType);
					//-----------------------
					aVoucherDetails.SetValue(rsLocalRec["bill_no"], cnt, grdBillingCodeColumn);
					aVoucherDetails.SetValue(rsLocalRec["bill_name"], cnt, grdBillingNameColumn);
					aVoucherDetails.SetValue(rsLocalRec["bill_type"], cnt, grdBillingTypeColumn);
					aVoucherDetails.SetValue(rsLocalRec["bill_mode_text"], cnt, grdBillingModeTextColumn);
					aVoucherDetails.SetValue(rsLocalRec["billing_mode"], cnt, grdBillingModeValueColumn);
					aVoucherDetails.SetValue(rsLocalRec["linked_leave"], cnt, grdBillingLinkedLeaveColumn);
					aVoucherDetails.SetValue(rsLocalRec["salary"], cnt, grdBillingAmtColumn);
					aVoucherDetails.SetValue(rsLocalRec["pay_days"], cnt, grdBillingDays);
					aVoucherDetails.SetValue(rsLocalRec["pay_hours"], cnt, grdBillingHours);
					aVoucherDetails.SetValue(rsLocalRec["fc_amount"], cnt, grdAmtColumn);
					aVoucherDetails.SetValue(Convert.ToString(rsLocalRec["comments"]) + "", cnt, grdRemarksColumn);
					aVoucherDetails.SetValue(rsLocalRec["over_time"], cnt, grdOverTime);
					aVoucherDetails.SetValue(rsLocalRec["bill_type_id"], cnt, grdBillTypeID);
					mPayrollMasterEntID = Convert.ToInt32(rsLocalRec["master_entry_id"]);
					cnt++;
				}
				while(rsLocalRec.Read());
			}

			mysql = " select comments,is_payroll_emp,status_cd,basic_salary,total_salary from pay_payroll_master where emp_cd = " + mEmpCd.ToString() + " and pay_Date = '" + mPayrollDate + "'";
			//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(mReturnValue))
			{
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				txtComments.Text = (Convert.IsDBNull(((Array) mReturnValue).GetValue(0))) ? "" : ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(0));
				txtDlblPayrollEmployee.Text = (ReflectionHelper.GetPrimitiveValue<bool>(((Array) mReturnValue).GetValue(1))) ? "Yes" : "No";
				txtDlblStatus.Text = (ReflectionHelper.GetPrimitiveValue<double>(((Array) mReturnValue).GetValue(2)) == 1) ? "Active" : "On Leave";
				txtDisplayLabel[conDlblBasicSalary].Text = StringsHelper.Format(ReflectionHelper.GetPrimitiveValue(((Array) mReturnValue).GetValue(3)), "###,###,##0.000");
				txtDisplayLabel[conDlblLeaveSalary].Text = StringsHelper.Format(ReflectionHelper.GetPrimitiveValue(((Array) mReturnValue).GetValue(4)), "###,###,##0.000");
			}

			AssignGridLineNumbers();
			grdVoucherDetails.Rebind(true);
			CalculateTotals(0, 0);
			SystemCombo.SearchCombo(cmbMonth, DateTime.Parse(mPayrollDate).Month);
			SystemCombo.SearchCombo(cmbYear, DateTime.Parse(mPayrollDate).Year);
			grdVoucherDetails.Enabled = true;
			FirstFocusObject.Focus();
			mFirstGridFocus = true;
			if (mFirstGridFocus)
			{
				grdVoucherDetails_GotFocus(grdVoucherDetails, new EventArgs());
			}
			Application.DoEvents();

			rsLocalRec.Close();

			return;

			//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
			SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, Information.Err().Description, this.Name, "GetRecord");
		}


		public void CloseForm()
		{
			this.Close();
		}

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBGrid Event grdVoucherDetails.PostEvent was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void grdVoucherDetails_PostEvent(int MsgId)
		{
			int Col = 0;

			if (MsgId == 1)
			{
				grdVoucherDetails.Col = grdBillingCodeColumn;
				//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbMastersList.DataSource was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				cmbMastersList.setDataSource((msdatasrc.DataSource) rsBillingCodeList);
			}
		}

		public void IRoutine()
		{
			int mCurrentLineNo = 0;

			if (ActiveControl.Name != "grdVoucherDetails" && grdVoucherDetails.Enabled)
			{
				grdVoucherDetails.Focus();
			}
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(grdVoucherDetails.Bookmark))
			{
				//UPGRADE_WARNING: (1068) grdVoucherDetails.Columns().Value of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mCurrentLineNo = ReflectionHelper.GetPrimitiveValue<int>(grdVoucherDetails.Columns[grdLineNoColumn].Value);
				//UPGRADE_ISSUE: (2064) XArrayDBObject.XArrayDB method aVoucherDetails.InsertRows was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				aVoucherDetails.InsertRows(ReflectionHelper.GetPrimitiveValue<int>(grdVoucherDetails.Bookmark), 1);
				AssignGridLineNumbers();
				grdVoucherDetails.Rebind(true);
			}
		}

		public void LRoutine()
		{
			if (ActiveControl.Name != "grdVoucherDetails" && grdVoucherDetails.Enabled)
			{
				grdVoucherDetails.Focus();
			}

			if (aVoucherDetails.GetLength(0) > 0)
			{
				grdVoucherDetails.Delete();
				AssignGridLineNumbers();
				CalculateTotals(0, 1);
				grdVoucherDetails.Rebind(true);
			}
		}

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBDropDown Event cmbMastersList.DataSourceChanged was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void cmbMastersList_DataSourceChanged()
		{
			int cnt = 0;

			cmbMastersList.Width = 0;

			C1.Win.C1TrueDBGrid.C1DisplayColumn withVar = null;
			switch(grdVoucherDetails.Col)
			{
				case grdBillingCodeColumn : case grdBillingNameColumn : 
					if (grdVoucherDetails.Col == grdBillingCodeColumn)
					{
						//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbMastersList.ListField was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						cmbMastersList.setListField("bill_no");
						//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsBillingCodeList.Sort was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						rsBillingCodeList.setSort("bill_no");
					}
					else
					{
						//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbMastersList.ListField was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						cmbMastersList.setListField("bill_name");
						//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsBillingCodeList.Sort was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						rsBillingCodeList.setSort("bill_name");
					} 
					 
					int tempForEndVar = cmbMastersList.Columns.Count - 1; 
					for (cnt = 0; cnt <= tempForEndVar; cnt++)
					{
						//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
						withVar = cmbMastersList.Splits[0].DisplayColumns[cnt];
						if (cnt < 4)
						{
							if (cnt == 0)
							{
								//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.Column property withVar.Order was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
								withVar.setOrder((grdVoucherDetails.Col == grdBillingCodeColumn) ? 0 : 1);
								//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
								withVar.Width = grdVoucherDetails.Splits[0].DisplayColumns[grdBillingCodeColumn].Width;
							}
							else if (cnt == 1)
							{ 
								//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.Column property withVar.Order was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
								withVar.setOrder((grdVoucherDetails.Col == grdBillingCodeColumn) ? 1 : 0);
								//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
								withVar.Width = grdVoucherDetails.Splits[0].DisplayColumns[grdBillingNameColumn].Width;
							}
							else if (cnt == 2)
							{ 
								//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
								withVar.Width = grdVoucherDetails.Splits[0].DisplayColumns[grdBillingTypeColumn].Width;
							}
							else if (cnt == 3)
							{ 
								//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
								withVar.Width = grdVoucherDetails.Splits[0].DisplayColumns[grdBillingModeTextColumn].Width;
							}
							withVar.Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Near;
							withVar.Visible = true;
							cmbMastersList.Width += withVar.Width / 15;
						}
						else
						{
							withVar.Visible = false;
						}
						withVar.AllowSizing = false;
					} 
					cmbMastersList.Width += 17; 
					cmbMastersList.Height = 167; 
					break;
			}
		}

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBDropDown Event cmbMastersList.DropDownClose was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void cmbMastersList_DropDownClose()
		{
			switch(grdVoucherDetails.Col)
			{
				case grdBillingCodeColumn : 
					grdVoucherDetails.Col = grdBillingNameColumn; 
					break;
			}
		}

		private void DefineMasterRecordset()
		{
			string mysql = "";

			if (SystemProcedure2.IsItEmpty(mSearchValue, SystemVariables.DataType.NumberType))
			{
				return;
			}

			if (mFirstGridFocus)
			{
				mysql = " select bill_no ";
				mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_bill_name as bill_name" : "a_bill_name as bill_name");
				if (SystemVariables.gPreferedLanguage == SystemVariables.Language.English)
				{
					mysql = mysql + " , (select l_object_caption from SM_Objects sobj where sobj.object_id = pbt.bill_type_id) ";
				}
				else
				{
					mysql = mysql + " , (select a_object_caption from SM_Objects sobj where sobj.object_id = pbt.bill_type_id) ";
				}
				mysql = mysql + " , case   when pebd.billing_mode = 'T' then 'Temporary'   when  pebd.billing_mode = 'F' then 'Fixed'   else 'Manual'  end as Mode  ";
				mysql = mysql + " , pebd.billing_mode as mode_value ";
				mysql = mysql + " , case when pebd.billing_mode = 'T' then '1' else '0' End as LinkedLeave ";
				mysql = mysql + " , case when pebd.billing_mode = 'T' then " + mBasicSalary.ToString() + " else amount End as amount ";
				mysql = mysql + " , pbt.over_time as over_time ";
				mysql = mysql + " , pbt.bill_type_id as bill_type_id "; //''''''
				mysql = mysql + " from pay_billing_type pbt ";
				mysql = mysql + " inner join Pay_Employee_Billing_Details pebd on pbt.bill_cd = pebd.bill_cd ";
				mysql = mysql + " where pebd.emp_cd = " + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
				mysql = mysql + " and pbt.show = 1";
				mysql = mysql + " Union all ";
				mysql = mysql + " select bill_no  , l_bill_name as bill_name ";
				mysql = mysql + " , (select l_object_caption from SM_Objects sobj ";
				mysql = mysql + " where sobj.object_id = pbt.bill_type_id) ";
				mysql = mysql + " , 'Manual' as Mode ";
				mysql = mysql + " , 'M' as mode_value ";
				mysql = mysql + " , 'B' as LinkedLeave ";
				mysql = mysql + " , case when pbt.over_time = 1 or pbt.over_time = 2 or pbt.over_time = 3 then " + mBasicSalary.ToString() + " else 0 end as amount ";
				mysql = mysql + " , pbt.over_time as over_time ";
				mysql = mysql + " , pbt.bill_type_id as bill_type_id "; //''''''
				mysql = mysql + " from pay_billing_type pbt ";
				//mySql = mySql & " left join Pay_Employee_Billing_Details pebd on pbt.bill_cd = pebd.bill_cd "
				mysql = mysql + " Where Not Exists ";
				mysql = mysql + " ( select bill_cd from Pay_Employee_Billing_Details pebd1 ";
				mysql = mysql + " Where pbt.bill_cd = pebd1.bill_cd ";
				mysql = mysql + " and pebd1.emp_cd = " + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
				mysql = mysql + " )";
				mysql = mysql + " and pbt.show = 1";
				mysql = mysql + " order by 1 ";

				rsBillingCodeList = new DataSet();
				//UPGRADE_ISSUE: (2064) ADODB.CursorLocationEnum property CursorLocationEnum.adUseClient was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsBillingCodeList.CursorLocation was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				rsBillingCodeList.setCursorLocation(UpgradeStubs.ADODB_CursorLocationEnum.getadUseClient());
				SqlDataAdapter adap = new SqlDataAdapter(mysql, SystemVariables.gConn);
				rsBillingCodeList.Tables.Clear();
				adap.Fill(rsBillingCodeList);
			}
			else
			{
				//UPGRADE_ISSUE: (2064) ADODB.Recordset method rsBillingCodeList.Requery was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				rsBillingCodeList.Requery(-1);
			}

		}

		public void findRecord()
		{
			//Call the find window

			string mysql = " pay_emp.status_cd not in (3,4) ";
			//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(7050000, "", mysql));
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(mTempSearchValue))
			{
				//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mSearchValue = ReflectionHelper.GetPrimitiveValue(((Array) mTempSearchValue).GetValue(0));
				GetRecord(mSearchValue, true);
			}
		}

		public void FindRoutine(string pObjectName)
		{
			object mTempSearchValue = null;
			string mysql = "";

			if (pObjectName == "txtEmployeeCode")
			{
				txtEmployeeCode.Text = "";
				mysql = " pay_emp.status_cd not in (3,4)";
				//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(7050000, "831", mysql));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(mTempSearchValue))
				{
					//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mSearchValue = ReflectionHelper.GetPrimitiveValue(((Array) mTempSearchValue).GetValue(0));
					//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					txtEmployeeCode.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(1));
					txtEmployeeCode_Leave(txtEmployeeCode, new EventArgs());
				}
			}

		}

		private void txtEmployeeCode_Leave(Object eventSender, EventArgs eventArgs)
		{

			string mysql = "select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_full_name" : "a_full_name");
			mysql = mysql + " , emp_cd, allow_overtime ";
			mysql = mysql + " from pay_employee ";
			mysql = mysql + " where emp_no ='" + txtEmployeeCode.Text + "'";
			//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));

			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(mReturnValue))
			{
				//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				txtDisplayLabel[conDlblEmpName].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(0));
				mAllowOvertime = ReflectionHelper.GetPrimitiveValue<bool>(((Array) mReturnValue).GetValue(2));
				GetRecord(mSearchValue, true);
			}
			else
			{
				txtEmployeeCode.Text = "";
				txtDisplayLabel[conDlblEmpName].Text = "";
				mAllowOvertime = false;
				AddRecord();
			}
		}

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBGrid Event grdVoucherDetails.OnAddNew was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void grdVoucherDetails_OnAddNew()
		{
			grdVoucherDetails.Columns[grdLineNoColumn].Text = (grdVoucherDetails.RowCount + 1).ToString();
			grdVoucherDetails.Columns[grdAmtColumn].Text = "0";

			//''''This cause the focus to be lost from billing code for the first time when a new row is added
			//grdVoucherDetails.Update
			//grdVoucherDetails.Refresh
		}

		private void grdVoucherDetails_RowColChange(object eventSender, C1.Win.C1TrueDBGrid.RowColChangeEventArgs eventArgs)
		{
			int LastRow = eventArgs.LastRow;
			int LastCol = eventArgs.LastCol;
			if (grdVoucherDetails.Col > 0 && LastCol > 0 && !mFirstGridFocus)
			{
				switch(grdVoucherDetails.Col)
				{
					case grdBillingCodeColumn : case grdBillingNameColumn : 
						//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbMastersList.DataSource was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064 
						cmbMastersList.setDataSource((msdatasrc.DataSource) rsBillingCodeList); 
						break;
				}
			}

			grdVoucherDetails_ButtonClick(grdVoucherDetails, new C1.Win.C1TrueDBGrid.ColEventArgs());
		}

		private void txtEmployeeCode_DropButtonClick(Object Sender, EventArgs e)
		{
			FindRoutine("txtEmployeeCode");
		}


		private void RefreshRecord()
		{
			int cnt = 0;
			int tempForEndVar = grdVoucherDetails.Columns.Count - 1;
			for (cnt = 0; cnt <= tempForEndVar; cnt++)
			{
				grdVoucherDetails.Columns[cnt].FooterText = "";
			}

			mCurrentFormMode = SystemVariables.SystemFormModes.frmAddMode; //Change the form mode to addmode

			DefineVoucherArray(-1, true);
			AssignGridLineNumbers();
			grdVoucherDetails.Rebind(true);
			grdVoucherDetails.Enabled = false;

			mSearchValue = ""; //Change the msearchvalue to blank
			mPayrollDate = "";
			mFirstGridFocus = true;

		}
	}
}