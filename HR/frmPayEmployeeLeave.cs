
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;




namespace Xtreme
{
	internal partial class frmPayEmployeeLeave
		: System.Windows.Forms.Form
	{

		
		public frmPayEmployeeLeave()
{
InitializeComponent();
} 
 public  void frmPayEmployeeLeave_old()
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

		public Control FirstFocusObject = null;

		private int mThisFormID = 0;
		private clsToolbar oThisFormToolBar = null;
		private object mSearchValue = null;
		private string mTimeStamp = "";
		private SystemVariables.SystemFormModes mCurrentFormMode = (SystemVariables.SystemFormModes) 0;
		private bool mFirstGridFocus = false;
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

		private DataSet rsLeaveCodeList = null;

		private const int conTxtNWDPerMonthBeforeSOP = 0;
		private const int conTxtNOpeningPaidLeaveBalanceDays = 1;
		private const int conTxtNOpeningPaidLeaveTakenDays = 2;
		private const int conTxtNWDPerMonthAfterSOP = 3;
		private const int conTxtNMaximumLeave = 4;
		private const int conTxtNOpeningUnpaidLeaveTakenDays = 5;
		private const int conTxtNLeaveDaysBeforeSOP = 6;
		private const int conTxtNLeaveDaysAfterSOP = 7;

		private const int conTxtSwitchOverPeriod = 7;


		private const int conDlblEmpCode = 0;
		private const int conDlblPaidLeaveTakenDays = 1;
		private const int conDlblTotalPaidLeaveTakenDays = 2;
		private const int conDlblUnPaidLeaveTakenDays = 3;
		private const int conDlblTotalUnPaidLeaveTakenDays = 4;
		private const int conDlblLeaveBalanceAsOf = 5;
		private const int conDlblEmpName = 6;
		private const int conDlblLeaveBalance = 7;

		private const int conLblLeaveBalanceAsOf = 19;

		private const int grdLineNoColumn = 0;
		private const int grdLeaveCodeColumn = 1;
		private const int grdLeaveNameColumn = 2;
		private const int grdPaidLeaveTakenDaysColumn = 3;
		private const int grdTotalPaidLeaveBalanceDaysColumn = 4;
		private const int grdWDPerMonthBeforeSOPColumn = 5;
		private const int grdWDPerMonthAfterSOPColumn = 6;
		private const int grdOpeningPaidLeaveBalDaysColumn = 7;
		private const int grdOpeningPaidLeaveBalDateColumn = 8;
		private const int grdOpeningPaidLeaveTakenDaysColumn = 9;
		private const int grdOpeningUnPaidLeaveTakenDaysColumn = 10;
		private const int grdUnPaidLeaveTakenDaysColumn = 11;
		private const int grdSwitchOverPeriod = 12;
		private const int grdLeaveDaysBeforeSOP = 13;
		private const int grdLeaveDaysAfterSOP = 14;
		private const int grdDeductPaidDays = 15;
		private const int grdDeductUnPaidDays = 16;
		private const int grdLeaveBalanceAsOf = 17;
		private const int grdDefaultValuesDisplayedColumn = 18;
		private const int grdMaximumLeaveDays = 19;
		private const int grdLeaveBalanceDays = 20;


		private const int conCmbDeductPaidDays = 0;
		private const int conCmbDeductUnPaidDays = 1;


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


		private void Form_Activated(Object eventSender, EventArgs eventArgs)
		{
			if (ActivateHelper.myActiveForm != eventSender)
			{
				ActivateHelper.myActiveForm = (Form) eventSender;
				//On Error Resume Next
				//FirstFocusObject.SetFocus
			}
		}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2080
		private void Form_Load()
		{
			try
			{

				FirstFocusObject = grdVoucherDetails;
				//picFormToolbar.Visible = False
				grdVoucherDetails.Visible = false;
				this.Top = 0;
				this.Left = 0;
				this.CurrentFormMode = SystemVariables.SystemFormModes.frmAddMode;
				mFirstGridFocus = true;


				//**--format & define the new toolbar
				oThisFormToolBar = new clsToolbar();
				oThisFormToolBar.AttachObject(this); //, tcbSystemForm

				oThisFormToolBar.ShowNewButton = false;
				oThisFormToolBar.ShowSaveButton = true;
				oThisFormToolBar.ShowDeleteButton = true;
				oThisFormToolBar.ShowPrintButton = false;
				oThisFormToolBar.ShowFindButton = true;
				oThisFormToolBar.ShowHelpButton = true;
				oThisFormToolBar.ShowInsertLineButton = true;
				oThisFormToolBar.ShowDeleteLineButton = true;
				oThisFormToolBar.ShowExitButton = true;
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

				SystemProcedure.SetLabelCaption(this);
				//Call DrawToolbar(Me, picFormToolbar, btnFormToolBar(1))
				//picFormToolbar.Visible = True

				object[] mObjectId = new object[2];
				mObjectId[conCmbDeductPaidDays] = 1009;
				mObjectId[conCmbDeductUnPaidDays] = 1009;

				SystemCombo.FillComboWithSystemObjects(CmbCommon, mObjectId);


				//define voucher grid columns
				SystemGrid.DefineSystemVoucherGrid(grdVoucherDetails, true, true, true, (0xFFFFFF).ToString(), (0x0).ToString(), true, true, C1.Win.C1TrueDBGrid.MarqueeEnum.FloatingEditor, 1.65f, 1.4f, "&HBBC8CA", "&HBBC8CA");
				//define voucher grid columns
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "LN", 400, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false);
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Leave Code", 1200, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, true, true, "cmbMastersList");
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Leave Name", 4000, true, ColorTranslator.ToOle(Color.White).ToString(), (0xB4261B).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, "T o t a l", C1.Win.C1TrueDBGrid.AlignHorzEnum.Center, true, true, true, "cmbMastersList");
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Paid Leave Taken Days", 2000, false, SystemConstants.gDisableColumnBackColor, (0xB4261B).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false, true, true, "", false, true, false, false, false, true);
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Paid Leave Balance Days", 1600, false, SystemConstants.gDisableColumnBackColor, (0xB4261B).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false, true, true, "", false, true, false, false, false, true);
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "WDPerMonthBeforeSOPColumn", 1000, false, SystemConstants.gDisableColumnBackColor, (0xB4261B).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, false);
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "WDPerMonthAfterSOPColumn", 1000, false, SystemConstants.gDisableColumnBackColor, (0xB4261B).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, false);
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "OpeningPaidLeaveBalDaysColumn", 1000, false, SystemConstants.gDisableColumnBackColor, (0xB4261B).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, false);
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "OpeningPaidLeaveBalDateColumn", 1000, false, SystemConstants.gDisableColumnBackColor, (0xB4261B).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, false);
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "OpeningPaidLeaveTakenDaysColumn", 1000, false, SystemConstants.gDisableColumnBackColor, (0xB4261B).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, false);
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "OpeningUnPaidLeaveTakenDaysColumn", 1000, false, SystemConstants.gDisableColumnBackColor, (0xB4261B).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, false);
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "UnPaidLeaveTakenDaysColumn", 1000, false, SystemConstants.gDisableColumnBackColor, (0xB4261B).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, false);
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "SwitchOverPeriod", 1000, false, SystemConstants.gDisableColumnBackColor, (0xB4261B).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, false);
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "LeaveDaysBeforeSOP", 1000, false, SystemConstants.gDisableColumnBackColor, (0xB4261B).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, false);
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "LeaveDaysAfterSOP", 1000, false, SystemConstants.gDisableColumnBackColor, (0xB4261B).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, false);
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "DeductPaidDays", 1000, false, SystemConstants.gDisableColumnBackColor, (0xB4261B).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, false);
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "DeductUnPaidDays", 1000, false, SystemConstants.gDisableColumnBackColor, (0xB4261B).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, false);
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "LeaveBalanceAsOf", 1000, false, SystemConstants.gDisableColumnBackColor, (0xB4261B).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, false);
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "DefaultValuesDisplayedColumn", 1000, false, SystemConstants.gDisableColumnBackColor, (0xB4261B).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, false);
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "MaximumLeaveDays", 1000, false, SystemConstants.gDisableColumnBackColor, (0xB4261B).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, false);
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "LeaveBalance", 1000, false, SystemConstants.gDisableColumnBackColor, (0xB4261B).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, false);


				//setting voucher details grid properties
				DefineVoucherArray(-1, false);
				AssignGridLineNumbers();
				//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBGrid property grdVoucherDetails.Array was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				grdVoucherDetails.setArray(aVoucherDetails);
				grdVoucherDetails.Rebind(true);
				//-- end of voucher grid property setting

				grdVoucherDetails.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.HighlightRow;
				//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBGrid property grdVoucherDetails.InsertMode was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				grdVoucherDetails.setInsertMode(false);

				grdVoucherDetails.Visible = true;
				cntMasterDetails.Enabled = false;
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
				//Refresh the product recordset when F5 is pressed
				if (Shift == 0 && KeyCode == 116 && !mFirstGridFocus)
				{
					DefineMasterRecordset();
				}

				if (cntMasterDetails.Enabled)
				{
					//if the user presses any control key in the voucher grid object
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
					}
				}

				//On Keydown navigate the form by using enter key
				if (KeyCode == 13)
				{ //If enter key pressed send a tab key
					SendKeys.Send("{TAB}");
					return;
				}

				if (cntMasterDetails.Enabled)
				{
					SystemForms.SystemFormKeyDown(this, ref KeyCode, Shift, this.ActiveControl.Name);
				}
				else
				{
					SystemForms.SystemFormKeyDown(this, ref KeyCode, Shift, "");
				}
			}
			finally
			{
				eventArgs.Handled = KeyCode == 0;
			}
		}

		private void Form_Closed(Object eventSender, EventArgs eventArgs)
		{
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{
				SystemMenu.RemoveMeFromWindowList(Conversion.Str(this.Handle.ToInt32()));

				aVoucherDetails = null;
				rsLeaveCodeList = null;
				UserAccess = null;
				oThisFormToolBar = null;
				frmPayEmployeeLeave.DefInstance = null;
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBDropDown Event cmbMastersList.RowChange was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void cmbMastersList_RowChange()
		{
			object mReturnValue = null;
			if (grdVoucherDetails.Col == grdLeaveCodeColumn || grdVoucherDetails.Col == grdLeaveNameColumn)
			{
				if (grdVoucherDetails.Col == grdLeaveCodeColumn)
				{
					grdVoucherDetails.Columns[grdLeaveNameColumn].Value = cmbMastersList.Columns[1].Value;
				}
				else
				{
					grdVoucherDetails.Columns[grdLeaveCodeColumn].Value = cmbMastersList.Columns[0].Value;
				}
			}

			string mysql = "";
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(grdVoucherDetails.Bookmark))
			{
				if (!SystemProcedure2.IsItEmpty(cmbMastersList.Columns[0].Value, SystemVariables.DataType.NumberType))
				{
					//If aVoucherDetails(grdVoucherDetails.Bookmark, grdDefaultValuesDisplayedColumn) <> "Y" Then
					mysql = " select is_fixed_leave, leave_switch_over_period, leave_days_before_sop ";
					mysql = mysql + " , leave_days_after_sop, working_days_per_month_before_sop ";
					mysql = mysql + " , working_days_per_month_after_sop , deduct_paid_days ";
					mysql = mysql + " , deduct_unpaid_days ";
					mysql = mysql + " from pay_leave ";
					mysql = mysql + " where leave_no=" + ReflectionHelper.GetPrimitiveValue<string>(cmbMastersList.Columns[0].Value);

					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (!Convert.IsDBNull(mReturnValue))
					{
						//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtCommon[conTxtSwitchOverPeriod].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(1));
						//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtCommonNumber[conTxtNLeaveDaysBeforeSOP].Value = ReflectionHelper.GetPrimitiveValue(((Array) mReturnValue).GetValue(2));
						//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtCommonNumber[conTxtNLeaveDaysAfterSOP].Value = ReflectionHelper.GetPrimitiveValue(((Array) mReturnValue).GetValue(3));
						SystemCombo.SearchCombo(CmbCommon[conCmbDeductPaidDays], (ReflectionHelper.GetPrimitiveValue<bool>(((Array) mReturnValue).GetValue(6))) ? 1 : 0);
						SystemCombo.SearchCombo(CmbCommon[conCmbDeductUnPaidDays], (ReflectionHelper.GetPrimitiveValue<bool>(((Array) mReturnValue).GetValue(7))) ? 1 : 0);

						//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtCommonNumber[conTxtNWDPerMonthBeforeSOP].Value = ReflectionHelper.GetPrimitiveValue(((Array) mReturnValue).GetValue(4));
						//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtCommonNumber[conTxtNWDPerMonthAfterSOP].Value = ReflectionHelper.GetPrimitiveValue(((Array) mReturnValue).GetValue(5));
					}
					txtOpeningBalanceAsOn.Value = Convert.ToString(txtDisplayLabel[conDlblEmpCode].Tag);
					//aVoucherDetails(grdVoucherDetails.Bookmark, grdDefaultValuesDisplayedColumn) = "Y"
					//End If
				}
			}

		}

		private void grdVoucherDetails_AfterColUpdate(Object eventSender, C1.Win.C1TrueDBGrid.ColEventArgs eventArgs)
		{
			int ColIndex = eventArgs.ColIndex;
			if (ColIndex == grdLeaveCodeColumn || ColIndex == grdLeaveNameColumn)
			{
				grdVoucherDetails.UpdateData();
				CalculateTotals(ReflectionHelper.GetPrimitiveValue<int>(grdVoucherDetails.Bookmark), ColIndex);
				grdVoucherDetails.Refresh();
			}
		}

		private void grdVoxucherDetails_FormatText(int ColIndex, ref string Value, object Bookmark)
		{
			if (ColIndex == grdPaidLeaveTakenDaysColumn || ColIndex == grdTotalPaidLeaveBalanceDaysColumn)
			{
				if (Conversion.Val(Value) != 0)
				{
					Value = StringsHelper.Format(Value, "###,###,###,###,###.000");
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

			double mTotalPaidLeaveTakenDays = 0;
			double mTotalPaidLeaveBalanceDays = 0;

			int tempForEndVar = aVoucherDetails.GetLength(0) - 1;
			for (cnt = 0; cnt <= tempForEndVar; cnt++)
			{
				mTotalPaidLeaveTakenDays += Conversion.Val(Convert.ToString(aVoucherDetails.GetValue(cnt, grdPaidLeaveTakenDaysColumn)));
				mTotalPaidLeaveBalanceDays += Conversion.Val(Convert.ToString(aVoucherDetails.GetValue(cnt, grdTotalPaidLeaveBalanceDaysColumn)));
			}

			if (mTotalPaidLeaveTakenDays != 0)
			{
				grdVoucherDetails.Columns[grdPaidLeaveTakenDaysColumn].FooterText = StringsHelper.Format(mTotalPaidLeaveTakenDays, "###,###,###,###,##0.000");
			}
			else
			{
				grdVoucherDetails.Columns[grdPaidLeaveTakenDaysColumn].FooterText = "";
			}

			if (mTotalPaidLeaveBalanceDays != 0)
			{
				grdVoucherDetails.Columns[grdTotalPaidLeaveBalanceDaysColumn].FooterText = StringsHelper.Format(mTotalPaidLeaveBalanceDays, "###,###,###,###,##0.000");
			}
			else
			{
				grdVoucherDetails.Columns[grdTotalPaidLeaveBalanceDaysColumn].FooterText = "";
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
			aVoucherDetails.RedimXArray(new int[]{pMaximumRows, 20}, new int[]{0, 0});
		}

		public bool saveRecord(bool pApprove = false)
		{
			int mLeaveCode = 0;
			object mReturnValue = null;
			string mysql = "";
			SqlDataReader rsTempRec = null;
			int cnt = 0;

			try
			{


				if (SystemProcedure2.IsItEmpty(mSearchValue, SystemVariables.DataType.NumberType))
				{
					MessageBox.Show("Select an Employee!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					//FirstFocusObject.SetFocus
					return false;
				}

				if (aVoucherDetails.GetLength(0) != 0)
				{
					UpdateGrid(grdVoucherDetails.Bookmark);
				}

				SystemVariables.gConn.BeginTransaction();

				mysql = " select leave_cd  from pay_employee_leave_details ";
				mysql = mysql + " where emp_cd=" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);

				SqlCommand sqlCommand = new SqlCommand(mysql, SystemVariables.gConn);
				rsTempRec = sqlCommand.ExecuteReader();
				rsTempRec.Read();
				do 
				{
					if (aVoucherDetails.GetLength(0) == 0)
					{

						//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
						try
						{
							mysql = " delete from pay_employee_billing_details ";
							mysql = mysql + " from pay_employee_billing_details pebd ";
							mysql = mysql + " inner join pay_billing_type pbt ";
							mysql = mysql + " on pebd.bill_cd = pbt.bill_cd ";
							mysql = mysql + " where pebd.emp_cd=" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
							mysql = mysql + " and linked_leave_cd is not null ";
							SqlCommand TempCommand = null;
							TempCommand = SystemVariables.gConn.CreateCommand();
							TempCommand.CommandText = mysql;
							TempCommand.ExecuteNonQuery();

							mysql = " delete from pay_employee_leave_details ";
							mysql = mysql + " where emp_cd=" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
							SqlCommand TempCommand_2 = null;
							TempCommand_2 = SystemVariables.gConn.CreateCommand();
							TempCommand_2.CommandText = mysql;
							TempCommand_2.ExecuteNonQuery();

							//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
							if (Information.Err().Number != 0)
							{
								MessageBox.Show("Leave cannot be deleted, transaction already occurs", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
								//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
								SystemVariables.gConn.RollbackTrans();
								return false;
							}

							break;
						}
						catch (Exception exc)
						{
							NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
						}
					}
					else
					{
						int tempForEndVar = aVoucherDetails.GetLength(0) - 1;
						for (cnt = 0; cnt <= tempForEndVar; cnt++)
						{
							mysql = " select leave_cd from pay_leave where leave_no=" + Convert.ToString(aVoucherDetails.GetValue(cnt, grdLeaveCodeColumn));
							//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));

							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
							if (Convert.IsDBNull(mReturnValue))
							{
								//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
								SystemVariables.gConn.RollbackTrans();
								MessageBox.Show("Invalid Leave Code", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
								grdVoucherDetails.Col = grdLeaveCodeColumn;
								grdVoucherDetails.Bookmark = cnt;
								grdVoucherDetails.Focus();
								return false;
							}
							else
							{
								//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
								mLeaveCode = ReflectionHelper.GetPrimitiveValue<int>(mReturnValue);
								if (mLeaveCode == Convert.ToDouble(rsTempRec["leave_cd"]))
								{
									break;
								}
								else
								{
									if (cnt == aVoucherDetails.GetLength(0) - 1)
									{
										//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
										try
										{
											mysql = " delete from pay_employee_billing_details ";
											mysql = mysql + " from pay_employee_billing_details pebd ";
											mysql = mysql + " inner join pay_billing_type pbt ";
											mysql = mysql + " on pebd.bill_cd = pbt.bill_cd ";
											mysql = mysql + " where pebd.emp_cd=" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
											mysql = mysql + " and pbt.linked_leave_cd=" + Convert.ToString(rsTempRec["leave_cd"]);
											SqlCommand TempCommand_3 = null;
											TempCommand_3 = SystemVariables.gConn.CreateCommand();
											TempCommand_3.CommandText = mysql;
											TempCommand_3.ExecuteNonQuery();

											mysql = " delete from pay_employee_leave_details ";
											mysql = mysql + " where emp_cd=" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
											mysql = mysql + " and leave_cd=" + Convert.ToString(rsTempRec["leave_cd"]);
											SqlCommand TempCommand_4 = null;
											TempCommand_4 = SystemVariables.gConn.CreateCommand();
											TempCommand_4.CommandText = mysql;
											TempCommand_4.ExecuteNonQuery();

											//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
											if (Information.Err().Number != 0)
											{
												MessageBox.Show("Leave cannot be deleted, transaction already occurs", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
												//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
												SystemVariables.gConn.RollbackTrans();
												return false;
											}
										}
										catch (Exception exc2)
										{
											NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
										}

									}
								}
							}
						}
					}
				}
				while(rsTempRec.Read());

				int tempForEndVar2 = aVoucherDetails.GetLength(0) - 1;
				for (cnt = 0; cnt <= tempForEndVar2; cnt++)
				{
					mysql = " select leave_cd from pay_leave where leave_no=" + Convert.ToString(aVoucherDetails.GetValue(cnt, grdLeaveCodeColumn));
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));

					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (Convert.IsDBNull(mReturnValue))
					{
						//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						SystemVariables.gConn.RollbackTrans();
						MessageBox.Show("Invalid Leave Code", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
						grdVoucherDetails.Col = grdLeaveCodeColumn;
						grdVoucherDetails.Bookmark = cnt;
						grdVoucherDetails.Focus();
						return false;
					}
					else
					{
						//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mLeaveCode = ReflectionHelper.GetPrimitiveValue<int>(mReturnValue);
					}


					mysql = " select leave_cd from pay_employee_leave_details ";
					mysql = mysql + " where leave_cd=" + mLeaveCode.ToString();
					mysql = mysql + " and emp_cd=" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);

					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (Convert.IsDBNull(mReturnValue))
					{

						mysql = " insert into pay_employee_leave_details";
						mysql = mysql + " (emp_cd, leave_cd, leave_switch_over_period, leave_days_before_sop ";
						mysql = mysql + " , leave_days_after_sop, working_days_per_month_before_sop";
						mysql = mysql + " , working_days_per_month_after_sop, deduct_paid_days";
						mysql = mysql + " , deduct_unpaid_days";
						//mySql = mySql & " , opening_paid_leave_balance_date "
						//mySql = mySql & " , opening_paid_leave_balance_days, opening_paid_leave_taken_days"
						//mySql = mySql & " , opening_unpaid_leave_taken_days"
						mysql = mysql + " , Maximum_Leave_Days, user_cd) ";
						mysql = mysql + " values (";
						mysql = mysql + " " + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
						mysql = mysql + " ," + mLeaveCode.ToString();
						mysql = mysql + " ," + ((Convert.ToString(aVoucherDetails.GetValue(cnt, grdSwitchOverPeriod)) == "") ? "0" : Convert.ToString(aVoucherDetails.GetValue(cnt, grdSwitchOverPeriod))); // txtCommon(conTxtSwitchOverPeriod).Text
						mysql = mysql + " ," + Convert.ToString(aVoucherDetails.GetValue(cnt, grdLeaveDaysBeforeSOP));
						mysql = mysql + " ," + Convert.ToString(aVoucherDetails.GetValue(cnt, grdLeaveDaysAfterSOP));
						mysql = mysql + " ," + Convert.ToString(aVoucherDetails.GetValue(cnt, grdWDPerMonthBeforeSOPColumn));
						mysql = mysql + " ," + Convert.ToString(aVoucherDetails.GetValue(cnt, grdWDPerMonthAfterSOPColumn));
						mysql = mysql + " ," + Convert.ToString(aVoucherDetails.GetValue(cnt, grdDeductPaidDays));
						mysql = mysql + " ," + Convert.ToString(aVoucherDetails.GetValue(cnt, grdDeductUnPaidDays));
						//mySql = mySql & " ,'" & aVoucherDetails(cnt, grdOpeningPaidLeaveBalDateColumn) & "'"
						//mySql = mySql & " ," & aVoucherDetails(cnt, grdOpeningPaidLeaveBalDaysColumn)
						//mySql = mySql & " ," & aVoucherDetails(cnt, grdOpeningPaidLeaveTakenDaysColumn)
						//mySql = mySql & " ," & aVoucherDetails(cnt, grdOpeningUnPaidLeaveTakenDaysColumn)
						mysql = mysql + " ," + Convert.ToString(aVoucherDetails.GetValue(cnt, grdMaximumLeaveDays));
						mysql = mysql + " ," + Conversion.Str(SystemVariables.gLoggedInUserCode);
						mysql = mysql + " ) ";
						SqlCommand TempCommand_5 = null;
						TempCommand_5 = SystemVariables.gConn.CreateCommand();
						TempCommand_5.CommandText = mysql;
						TempCommand_5.ExecuteNonQuery();
					}
					else
					{
						mysql = " update pay_employee_leave_details set ";
						mysql = mysql + " leave_switch_over_period = " + ((Convert.ToString(aVoucherDetails.GetValue(cnt, grdSwitchOverPeriod)) == "") ? "0" : Convert.ToString(aVoucherDetails.GetValue(cnt, grdSwitchOverPeriod)));
						mysql = mysql + " , leave_days_before_sop = " + Convert.ToString(aVoucherDetails.GetValue(cnt, grdLeaveDaysBeforeSOP));
						mysql = mysql + " , leave_days_after_sop = " + Convert.ToString(aVoucherDetails.GetValue(cnt, grdLeaveDaysAfterSOP));
						mysql = mysql + " , working_days_per_month_before_sop = " + Convert.ToString(aVoucherDetails.GetValue(cnt, grdWDPerMonthBeforeSOPColumn));
						mysql = mysql + " , working_days_per_month_after_sop = " + Convert.ToString(aVoucherDetails.GetValue(cnt, grdWDPerMonthAfterSOPColumn));
						mysql = mysql + " , deduct_paid_days = " + Convert.ToString(aVoucherDetails.GetValue(cnt, grdDeductPaidDays)); //CmbCommon(conCmbDeductPaidDays).ItemData(CmbCommon(conCmbDeductPaidDays).ListIndex)
						mysql = mysql + " , deduct_unpaid_days = " + Convert.ToString(aVoucherDetails.GetValue(cnt, grdDeductUnPaidDays)); // CmbCommon(conCmbDeductUnPaidDays).ItemData(CmbCommon(conCmbDeductUnPaidDays).ListIndex)
						//mySql = mySql & " , opening_paid_leave_balance_date ='" & aVoucherDetails(cnt, grdOpeningPaidLeaveBalDateColumn) & "'"
						//mySql = mySql & " , opening_paid_leave_balance_days = " & aVoucherDetails(cnt, grdOpeningPaidLeaveBalDaysColumn)
						//mySql = mySql & " , opening_paid_leave_taken_days = " & aVoucherDetails(cnt, grdOpeningPaidLeaveTakenDaysColumn)
						//mySql = mySql & " , opening_unpaid_leave_taken_days = " & aVoucherDetails(cnt, grdOpeningUnPaidLeaveTakenDaysColumn)
						mysql = mysql + " , Maximum_Leave_Days = " + Convert.ToString(aVoucherDetails.GetValue(cnt, grdMaximumLeaveDays)); // txtCommonNumber(conTxtNMaximumLeave).Value
						mysql = mysql + " , user_cd=" + Conversion.Str(SystemVariables.gLoggedInUserCode);
						mysql = mysql + " where emp_cd =" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
						mysql = mysql + " and leave_cd=" + mLeaveCode.ToString();
						SqlCommand TempCommand_6 = null;
						TempCommand_6 = SystemVariables.gConn.CreateCommand();
						TempCommand_6.CommandText = mysql;
						TempCommand_6.ExecuteNonQuery();
					}
				}

				//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.CommitTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				SystemVariables.gConn.CommitTrans();
				//grdVoucherDetails.Enabled = False
				cntMasterDetails.Enabled = false;
				return true;
			}
			catch (System.Exception excep)
			{


				int mReturnErrorType = 0;
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				mReturnErrorType = SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, excep.Message, this.Name, "GetRecord", SystemConstants.msg10);
				//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				SystemVariables.gConn.RollbackTrans();
				//If mReturnErrorType = 1 Then
				//    mSearchValue = GetMasterCode("vaccnt_group", "group_no", txtGroupNo.Text, "group_cd")
				//    Call GetRecord("vaccnt_group", "group_cd", mSearchValue, StringType)
				//    saveRecord = False
				//ElseIf mReturnErrorType = 2 Then
				//    Call AddRecord
				//    saveRecord = False
				//ElseIf mReturnErrorType = 3 Then
				//    Call AddRecord
				//    saveRecord = False
				//Else
				//    saveRecord = False
				//End If
			}
			return false;
		}

		public bool CheckDataValidity()
		{
			int cnt = 0;
			int cnt1 = 0;
			int mLeaveCode = 0;

			if (SystemProcedure2.IsItEmpty(mSearchValue, SystemVariables.DataType.NumberType))
			{
				MessageBox.Show("Select an employee!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
				return false;
			}


			grdVoucherDetails.UpdateData();
			int tempForEndVar = aVoucherDetails.GetLength(0) - 1;
			for (cnt = 0; cnt <= tempForEndVar; cnt++)
			{
				if (SystemProcedure2.IsItEmpty(aVoucherDetails.GetValue(cnt, grdLeaveCodeColumn), SystemVariables.DataType.NumberType))
				{
					MessageBox.Show("Invalid Leave Code", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
					grdVoucherDetails.Col = grdLeaveCodeColumn;
					grdVoucherDetails.Bookmark = cnt;
					grdVoucherDetails.Focus();
					return false;
				}
				else
				{
					mLeaveCode = Convert.ToInt32(aVoucherDetails.GetValue(cnt, grdLeaveCodeColumn));
				}

				int tempForEndVar2 = aVoucherDetails.GetLength(0) - 1;
				for (cnt1 = cnt + 1; cnt1 <= tempForEndVar2; cnt1++)
				{
					if (mLeaveCode == Convert.ToDouble(aVoucherDetails.GetValue(cnt1, grdLeaveCodeColumn)))
					{
						MessageBox.Show("Duplicate Leave Code", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
						grdVoucherDetails.Col = grdLeaveCodeColumn;
						grdVoucherDetails.Bookmark = cnt1;
						grdVoucherDetails.Focus();
						return false;
					}
				}
			}


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

				//grdVoucherDetails.Enabled = False
				cntMasterDetails.Enabled = false;

				mSearchValue = ""; //Change the msearchvalue to blank
				mFirstGridFocus = true;
				//FirstFocusObject.SetFocus
			}
			catch (System.Exception excep)
			{
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, excep.Message, this.Name, "AddRecord");
			}


		}


		public void GetRecord(object pSearchValue)
		{
			System.DateTime mPayrollDate = DateTime.FromOADate(0);
			SqlDataReader rsLocalRec = null;
			int cnt = 0;

			//On Error GoTo eFoundError

			string mysql = " select pay_emp.emp_no, pay_emp.emp_cd ";
			if (SystemVariables.gPreferedLanguage == SystemVariables.Language.English)
			{
				mysql = mysql + " , l_first_name + ' ' + l_second_name + ' ' + l_third_name + ' ' + l_fourth_name as emp_name";
			}
			else
			{
				mysql = mysql + " , a_first_name + ' ' + a_second_name + ' ' + a_third_name + ' ' + a_fourth_name as emp_name ";
			}
			mysql = mysql + " , pay_emp.date_of_joining ";
			mysql = mysql + " from pay_employee pay_emp ";
			mysql = mysql + " where pay_emp.emp_cd = " + Conversion.Str(pSearchValue);
			//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
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
				txtDisplayLabel[conDlblEmpName].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(2));
				txtDisplayLabel[conDlblEmpCode].Tag = StringsHelper.Format(ReflectionHelper.GetPrimitiveValue(((Array) mReturnValue).GetValue(3)), SystemVariables.gSystemDateFormat);
				//mCurrentFormMode = frmEditMode
			}
			else
			{
				mCurrentFormMode = SystemVariables.SystemFormModes.frmAddMode;
				return;
			}

			mysql = " select pl.leave_no ,Leave_Type_Cd ";
			if (SystemVariables.gPreferedLanguage == SystemVariables.Language.English)
			{
				mysql = mysql + " , pl.l_leave_name as leave_name ";
			}
			else
			{
				mysql = mysql + " , pl.a_leave_name as leave_name";
			}
			mysql = mysql + " , peld.* ";
			mysql = mysql + " from pay_employee_leave_details peld ";
			mysql = mysql + " inner join pay_leave pl on peld.leave_cd = pl.leave_cd ";
			mysql = mysql + " where peld.emp_cd = " + Conversion.Str(pSearchValue);

			SqlCommand sqlCommand = new SqlCommand(mysql, SystemVariables.gConn);
			rsLocalRec = sqlCommand.ExecuteReader();
			if (rsLocalRec.Read())
			{
				do 
				{
					DefineVoucherArray(cnt, false);
					aVoucherDetails.SetValue(Conversion.Str(cnt + 1).Trim(), cnt, grdLineNoColumn);
					aVoucherDetails.SetValue(rsLocalRec["leave_no"], cnt, grdLeaveCodeColumn);
					aVoucherDetails.SetValue(rsLocalRec["leave_name"], cnt, grdLeaveNameColumn);

					aVoucherDetails.SetValue(rsLocalRec["working_days_per_month_before_sop"], cnt, grdWDPerMonthBeforeSOPColumn);
					//aVoucherDetails(cnt, grdOpeningPaidLeaveBalDaysColumn) = .Fields("opening_paid_leave_balance_days").Value
					//aVoucherDetails(cnt, grdOpeningPaidLeaveBalDateColumn) = Format(.Fields("opening_paid_leave_balance_date").Value, gSystemDateFormat)
					//aVoucherDetails(cnt, grdOpeningPaidLeaveTakenDaysColumn) = .Fields("opening_paid_leave_taken_days").Value

					mysql = " select dbo.payPaidLeaveAvailedDays( " + Convert.ToString(rsLocalRec["emp_cd"]) + "," + Convert.ToString(rsLocalRec["Leave_Cd"]) + ",'" + StringsHelper.Format(DateTime.Today, SystemVariables.gSystemDateFormat) + "' , 1) ";
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (!Convert.IsDBNull(mReturnValue))
					{
						aVoucherDetails.SetValue(mReturnValue, cnt, grdPaidLeaveTakenDaysColumn); //IIf(mReturnValue = 0, .Fields("Paid_Leave_Taken_Days"), mReturnValue)
					}
					else
					{
						aVoucherDetails.SetValue(0, cnt, grdPaidLeaveTakenDaysColumn); //.Fields("Paid_Leave_Taken_Days")
					}

					aVoucherDetails.SetValue(rsLocalRec["working_days_per_month_after_sop"], cnt, grdWDPerMonthAfterSOPColumn);
					//aVoucherDetails(cnt, grdOpeningUnPaidLeaveTakenDaysColumn) = .Fields("opening_unpaid_leave_taken_days").Value

					mysql = " select dbo.payunPaidLeaveAvailedDays( " + Convert.ToString(rsLocalRec["emp_cd"]) + "," + Convert.ToString(rsLocalRec["Leave_Cd"]) + ",'" + StringsHelper.Format(DateTime.Today, SystemVariables.gSystemDateFormat) + "' , 1) ";
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (!Convert.IsDBNull(mReturnValue))
					{
						aVoucherDetails.SetValue(mReturnValue, cnt, grdUnPaidLeaveTakenDaysColumn);
					}
					else
					{
						aVoucherDetails.SetValue(0, cnt, grdUnPaidLeaveTakenDaysColumn);
					}

					aVoucherDetails.SetValue("Y", cnt, grdDefaultValuesDisplayedColumn);
					aVoucherDetails.SetValue(rsLocalRec["YTD_Paid_Leave_Days"], cnt, grdTotalPaidLeaveBalanceDaysColumn);


					aVoucherDetails.SetValue(rsLocalRec["leave_switch_over_period"], cnt, grdSwitchOverPeriod);
					aVoucherDetails.SetValue(rsLocalRec["leave_days_before_sop"], cnt, grdLeaveDaysBeforeSOP);
					aVoucherDetails.SetValue(rsLocalRec["leave_days_after_sop"], cnt, grdLeaveDaysAfterSOP);
					aVoucherDetails.SetValue(rsLocalRec["maximum_leave_days"], cnt, grdMaximumLeaveDays);

					aVoucherDetails.SetValue((Convert.ToBoolean(rsLocalRec["deduct_paid_days"])) ? 1 : 0, cnt, grdDeductPaidDays);
					aVoucherDetails.SetValue((Convert.ToBoolean(rsLocalRec["deduct_unpaid_days"])) ? 1 : 0, cnt, grdDeductUnPaidDays);

					if (Convert.ToDouble(rsLocalRec["Leave_Type_Cd"]) == 6)
					{
						mysql = " select dbo.payLeaveBalanceDays( " + Convert.ToString(rsLocalRec["emp_cd"]) + "," + Convert.ToString(rsLocalRec["Leave_Cd"]) + ",'" + StringsHelper.Format(DateTime.Today, SystemVariables.gSystemDateFormat) + "' , 1) ";
						//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
						if (!Convert.IsDBNull(mReturnValue))
						{
							aVoucherDetails.SetValue(mReturnValue, cnt, grdLeaveBalanceDays);
						}
						else
						{
							aVoucherDetails.SetValue(0, cnt, grdLeaveBalanceDays);
						}
					}
					else
					{
						aVoucherDetails.SetValue(0, cnt, grdLeaveBalanceDays);
					}


					cnt++;
				}
				while(rsLocalRec.Read());
			}

			AssignGridLineNumbers();
			grdVoucherDetails.Rebind(true);
			CalculateTotals(0, 0);


			cntMasterDetails.Enabled = true;

			FirstFocusObject.Focus();

			if (mFirstGridFocus)
			{
				grdVoucherDetails_GotFocus(grdVoucherDetails, new EventArgs());
			}
			Application.DoEvents();

			UpdateTextBox(grdVoucherDetails.Bookmark);

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
				grdVoucherDetails.Col = grdLeaveCodeColumn;
				//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbMastersList.DataSource was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				cmbMastersList.setDataSource((msdatasrc.DataSource) rsLeaveCodeList);
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
				case grdLeaveCodeColumn : case grdLeaveNameColumn : 
					if (grdVoucherDetails.Col == grdLeaveCodeColumn)
					{
						//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbMastersList.ListField was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						cmbMastersList.setListField("leave_no");
						//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsLeaveCodeList.Sort was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						rsLeaveCodeList.setSort("leave_no");
					}
					else
					{
						//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbMastersList.ListField was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						cmbMastersList.setListField("leave_name");
						//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsLeaveCodeList.Sort was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						rsLeaveCodeList.setSort("leave_name");
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
								withVar.setOrder((grdVoucherDetails.Col == grdLeaveCodeColumn) ? 0 : 1);
								//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
								withVar.Width = grdVoucherDetails.Splits[0].DisplayColumns[grdLeaveCodeColumn].Width;
							}
							else if (cnt == 1)
							{ 
								//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.Column property withVar.Order was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
								withVar.setOrder((grdVoucherDetails.Col == grdLeaveCodeColumn) ? 1 : 0);
								//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
								withVar.Width = grdVoucherDetails.Splits[0].DisplayColumns[grdLeaveNameColumn].Width;
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
					cmbMastersList.Width = cmbMastersList.Width; 
					cmbMastersList.Height = 167; 
					break;
			}
		}

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBDropDown Event cmbMastersList.DropDownClose was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void cmbMastersList_DropDownClose()
		{
			switch(grdVoucherDetails.Col)
			{
				case grdLeaveCodeColumn : 
					grdVoucherDetails.Col = grdLeaveNameColumn; 
					break;
			}
		}

		private void DefineMasterRecordset()
		{
			string mysql = "";

			if (mFirstGridFocus)
			{
				mysql = " select leave_no ";
				mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_leave_name as leave_name" : "a_leave_name as leave_name");
				mysql = mysql + " , is_fixed_leave ";
				//    mysql = mysql & " , leave_days_after_sop, working_days_per_month_before_sop"
				//    mysql = mysql & " , working_days_per_month_after_sop , deduct_paid_days"
				//    mysql = mysql & " , deduct_unpaid_days "
				mysql = mysql + " from pay_leave ";
				mysql = mysql + " order by 1 ";

				rsLeaveCodeList = new DataSet();
				//UPGRADE_ISSUE: (2064) ADODB.CursorLocationEnum property CursorLocationEnum.adUseClient was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsLeaveCodeList.CursorLocation was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				rsLeaveCodeList.setCursorLocation(UpgradeStubs.ADODB_CursorLocationEnum.getadUseClient());
				SqlDataAdapter adap = new SqlDataAdapter(mysql, SystemVariables.gConn);
				rsLeaveCodeList.Tables.Clear();
				adap.Fill(rsLeaveCodeList);
			}
			else
			{
				//UPGRADE_ISSUE: (2064) ADODB.Recordset method rsLeaveCodeList.Requery was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				rsLeaveCodeList.Requery(-1);
			}

		}

		public void findRecord()
		{
			//Call the find window

			//mysql = " pay_emp.status_cd=1 "
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

		public void FindRoutine(string pObjectName)
		{
		}

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBGrid Event grdVoucherDetails.OnAddNew was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void grdVoucherDetails_OnAddNew()
		{
			//Dim mRow As Integer
			//
			//
			//grdVoucherDetails.Columns(grdLineNoColumn).Text = grdVoucherDetails.ApproxCount + 1
			//grdVoucherDetails.Update
		}

		private void grdVoucherDetails_RowColChange(object eventSender, C1.Win.C1TrueDBGrid.RowColChangeEventArgs eventArgs)
		{
			int LastRow = eventArgs.LastRow;
			int LastCol = eventArgs.LastCol;
			//Dim mLastRow As Long

			if (grdVoucherDetails.Col > 0 && LastCol > 0 && !mFirstGridFocus)
			{
				switch(grdVoucherDetails.Col)
				{
					case grdLeaveCodeColumn : case grdLeaveNameColumn : 
						//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbMastersList.DataSource was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064 
						cmbMastersList.setDataSource((msdatasrc.DataSource) rsLeaveCodeList); 
						break;
				}
			}


			if (grdVoucherDetails.AddNewMode == C1.Win.C1TrueDBGrid.AddNewModeEnum.AddNewCurrent)
			{
				grdVoucherDetails.Columns[grdLineNoColumn].Text = (grdVoucherDetails.RowCount + 1).ToString();
				grdVoucherDetails.UpdateData();
			}

			//Debug.Print LastRow & "ok"
			if (Information.IsNumeric(LastRow))
			{
				UpdateGrid(LastRow);
			}
			Application.DoEvents();

			if (Information.IsNumeric(grdVoucherDetails.Bookmark))
			{
				UpdateTextBox(grdVoucherDetails.Bookmark);
			}

			if (grdVoucherDetails.AddNewMode == C1.Win.C1TrueDBGrid.AddNewModeEnum.NoAddNew)
			{
				//    If grdVoucherDetails.Row <> LastRow And LastRow <> "" Then
				//        UpdateGrid LastRow
				//        UpdateTextBox grdVoucherDetails.Bookmark
				//    End If

			}
			else if (grdVoucherDetails.AddNewMode == C1.Win.C1TrueDBGrid.AddNewModeEnum.AddNewCurrent)
			{ 

			}
			else
			{

			}
		}


		private void UpdateTextBox(object pBookmark)
		{
			txtCommon[conTxtSwitchOverPeriod].Text = Convert.ToString(aVoucherDetails.GetValue(ReflectionHelper.GetPrimitiveValue<int>(pBookmark), grdSwitchOverPeriod));
			txtCommonNumber[conTxtNLeaveDaysBeforeSOP].Value = aVoucherDetails.GetValue(ReflectionHelper.GetPrimitiveValue<int>(pBookmark), grdLeaveDaysBeforeSOP);
			txtCommonNumber[conTxtNLeaveDaysAfterSOP].Value = aVoucherDetails.GetValue(ReflectionHelper.GetPrimitiveValue<int>(pBookmark), grdLeaveDaysAfterSOP);

			txtCommonNumber[conTxtNWDPerMonthBeforeSOP].Value = aVoucherDetails.GetValue(ReflectionHelper.GetPrimitiveValue<int>(pBookmark), grdWDPerMonthBeforeSOPColumn);
			txtCommonNumber[conTxtNWDPerMonthAfterSOP].Value = aVoucherDetails.GetValue(ReflectionHelper.GetPrimitiveValue<int>(pBookmark), grdWDPerMonthAfterSOPColumn);

			txtCommonNumber[conTxtNMaximumLeave].Value = aVoucherDetails.GetValue(ReflectionHelper.GetPrimitiveValue<int>(pBookmark), grdMaximumLeaveDays);

			txtCommonNumber[conTxtNOpeningPaidLeaveBalanceDays].Value = aVoucherDetails.GetValue(ReflectionHelper.GetPrimitiveValue<int>(pBookmark), grdOpeningPaidLeaveBalDaysColumn);
			if (Information.IsDate(aVoucherDetails.GetValue(ReflectionHelper.GetPrimitiveValue<int>(pBookmark), grdOpeningPaidLeaveBalDateColumn)))
			{
				txtOpeningBalanceAsOn.Value = aVoucherDetails.GetValue(ReflectionHelper.GetPrimitiveValue<int>(pBookmark), grdOpeningPaidLeaveBalDateColumn);
			}
			else
			{
				txtOpeningBalanceAsOn.Text = "";
			}
			//txtCommonNumber(conTxtNOpeningPaidLeaveTakenDays).Value = aVoucherDetails(pBookmark, grdOpeningPaidLeaveTakenDaysColumn)

			txtDisplayLabel[conDlblPaidLeaveTakenDays].Text = StringsHelper.Format(aVoucherDetails.GetValue(ReflectionHelper.GetPrimitiveValue<int>(pBookmark), grdPaidLeaveTakenDaysColumn), "###,###,##0.000");
			//UPGRADE-WARNING: It was not possible to determine if this addition expression should use an addition operator (+) or a concatenation operator (&)
			txtDisplayLabel[conDlblTotalPaidLeaveTakenDays].Text = StringsHelper.Format(Convert.ToDouble(aVoucherDetails.GetValue(ReflectionHelper.GetPrimitiveValue<int>(pBookmark), grdOpeningPaidLeaveTakenDaysColumn)) + Convert.ToDouble(aVoucherDetails.GetValue(ReflectionHelper.GetPrimitiveValue<int>(pBookmark), grdPaidLeaveTakenDaysColumn)), "###,###,##0.000");


			//txtCommonNumber(conTxtNOpeningUnpaidLeaveTakenDays).Value = aVoucherDetails(pBookmark, grdOpeningUnPaidLeaveTakenDaysColumn)
			txtDisplayLabel[conDlblUnPaidLeaveTakenDays].Text = StringsHelper.Format(aVoucherDetails.GetValue(ReflectionHelper.GetPrimitiveValue<int>(pBookmark), grdUnPaidLeaveTakenDaysColumn), "###,###,##0.000");
			//UPGRADE-WARNING: It was not possible to determine if this addition expression should use an addition operator (+) or a concatenation operator (&)
			txtDisplayLabel[conDlblTotalUnPaidLeaveTakenDays].Text = StringsHelper.Format(Convert.ToDouble(aVoucherDetails.GetValue(ReflectionHelper.GetPrimitiveValue<int>(pBookmark), grdOpeningUnPaidLeaveTakenDaysColumn)) + Convert.ToDouble(aVoucherDetails.GetValue(ReflectionHelper.GetPrimitiveValue<int>(pBookmark), grdUnPaidLeaveTakenDaysColumn)), "###,###,##0.000");

			SystemCombo.SearchCombo(CmbCommon[conCmbDeductPaidDays], Convert.ToInt32(aVoucherDetails.GetValue(ReflectionHelper.GetPrimitiveValue<int>(pBookmark), grdDeductPaidDays)));
			SystemCombo.SearchCombo(CmbCommon[conCmbDeductUnPaidDays], Convert.ToInt32(aVoucherDetails.GetValue(ReflectionHelper.GetPrimitiveValue<int>(pBookmark), grdDeductUnPaidDays)));

			txtDisplayLabel[conDlblLeaveBalanceAsOf].Text = Convert.ToString(aVoucherDetails.GetValue(ReflectionHelper.GetPrimitiveValue<int>(pBookmark), grdLeaveBalanceAsOf));
			txtDisplayLabel[conDlblLeaveBalance].Text = Convert.ToString(aVoucherDetails.GetValue(ReflectionHelper.GetPrimitiveValue<int>(pBookmark), grdLeaveBalanceDays));

			//''''Get the Leave balance days as on today
			string mysql = "";
			object mReturnValue = null;
			int mLeaveCode = 0;

			if (!SystemProcedure2.IsItEmpty(aVoucherDetails.GetValue(ReflectionHelper.GetPrimitiveValue<int>(pBookmark), grdLeaveCodeColumn), SystemVariables.DataType.NumberType) && !SystemProcedure2.IsItEmpty(mSearchValue, SystemVariables.DataType.NumberType))
			{
				mysql = " select leave_cd from pay_leave where leave_no=" + Convert.ToString(aVoucherDetails.GetValue(ReflectionHelper.GetPrimitiveValue<int>(pBookmark), grdLeaveCodeColumn));
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (Convert.IsDBNull(mReturnValue))
				{
					return;
				}
				else
				{
					//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mLeaveCode = ReflectionHelper.GetPrimitiveValue<int>(mReturnValue);
				}

				mReturnValue = SystemHRProcedure.Leave_Balance_Days(ReflectionHelper.GetPrimitiveValue<int>(mSearchValue), mLeaveCode, DateTime.Today);
				lblCommon[conLblLeaveBalanceAsOf].Caption = "Leave Balance As Of " + StringsHelper.Format(DateTime.Today, SystemVariables.gSystemDateFormat);
				txtDisplayLabel[conDlblLeaveBalanceAsOf].Text = StringsHelper.Format(ReflectionHelper.GetPrimitiveValue(mReturnValue), "###,###,##0.000");
			}
			else
			{
				txtDisplayLabel[conDlblLeaveBalanceAsOf].Text = "";
				lblCommon[conLblLeaveBalanceAsOf].Caption = "";
			}

		}


		private void UpdateGrid(object pRow)
		{
			aVoucherDetails.SetValue(txtCommon[conTxtSwitchOverPeriod].Text, ReflectionHelper.GetPrimitiveValue<int>(pRow), grdSwitchOverPeriod);
			aVoucherDetails.SetValue(txtCommonNumber[conTxtNWDPerMonthBeforeSOP].Value, ReflectionHelper.GetPrimitiveValue<int>(pRow), grdWDPerMonthBeforeSOPColumn);
			aVoucherDetails.SetValue(txtCommonNumber[conTxtNWDPerMonthAfterSOP].Value, ReflectionHelper.GetPrimitiveValue<int>(pRow), grdWDPerMonthAfterSOPColumn);
			aVoucherDetails.SetValue(txtCommonNumber[conTxtNOpeningPaidLeaveBalanceDays].Value, ReflectionHelper.GetPrimitiveValue<int>(pRow), grdOpeningPaidLeaveBalDaysColumn);
			//aVoucherDetails(pRow, grdOpeningPaidLeaveBalDateColumn) = txtOpeningBalanceAsOn.DisplayText
			//aVoucherDetails(pRow, grdOpeningPaidLeaveTakenDaysColumn) = txtCommonNumber(conTxtNOpeningPaidLeaveTakenDays).Value
			aVoucherDetails.SetValue(txtCommonNumber[conTxtNOpeningUnpaidLeaveTakenDays].Value, ReflectionHelper.GetPrimitiveValue<int>(pRow), grdOpeningUnPaidLeaveTakenDaysColumn);

			aVoucherDetails.SetValue(txtCommonNumber[conTxtNLeaveDaysBeforeSOP].Value, ReflectionHelper.GetPrimitiveValue<int>(pRow), grdLeaveDaysBeforeSOP);
			aVoucherDetails.SetValue(txtCommonNumber[conTxtNLeaveDaysAfterSOP].Value, ReflectionHelper.GetPrimitiveValue<int>(pRow), grdLeaveDaysAfterSOP);
			aVoucherDetails.SetValue(txtCommonNumber[conTxtNMaximumLeave].Value, ReflectionHelper.GetPrimitiveValue<int>(pRow), grdMaximumLeaveDays);

			aVoucherDetails.SetValue(CmbCommon[conCmbDeductPaidDays].GetItemData(CmbCommon[conCmbDeductPaidDays].ListIndex), ReflectionHelper.GetPrimitiveValue<int>(pRow), grdDeductPaidDays);
			aVoucherDetails.SetValue(CmbCommon[conCmbDeductUnPaidDays].GetItemData(CmbCommon[conCmbDeductUnPaidDays].ListIndex), ReflectionHelper.GetPrimitiveValue<int>(pRow), grdDeductUnPaidDays);
			aVoucherDetails.SetValue(txtDisplayLabel[conDlblLeaveBalanceAsOf].Text, ReflectionHelper.GetPrimitiveValue<int>(pRow), grdLeaveBalanceAsOf);

		}

		private void ShowHideFixedLeaveInfo()
		{

			//If Not IsItEmpty(grdVoucherDetails.Columns(grdLeaveCodeColumn).Value, NumberType) Then
			//    rsLeaveCodeList.Filter = ""
			//    rsLeaveCodeList.MoveFirst
			//    rsLeaveCodeList.Find "leave_no=" & grdVoucherDetails.Columns(grdLeaveCodeColumn).Value
			//    If Not rsLeaveCodeList.EOF Or rsLeaveCodeList.BOF Then
			//        If rsLeaveCodeList.Fields("is_fixed_leave").Value = vbTrue Then
			//            fraFixedLeaveInfo.Visible = True
			//            lblCommon(7).Visible = False
			//            txtCommonNumber(conTxtNMaximumLeave).Visible = False
			//        Else
			//            fraFixedLeaveInfo.Visible = False
			//            lblCommon(7).Visible = True
			//            txtCommonNumber(conTxtNMaximumLeave).Visible = True
			//        End If
			//    End If
			//    rsLeaveCodeList.Filter = ""
			//End If
		}



		private void txtCommonNumber_Change(Object Sender, EventArgs e)
		{
			int Index = Array.IndexOf(this.txtCommonNumber, Sender);
			//If Index = conTxtNOpeningPaidLeaveTakenDays Then
			//    Dim mPaidLeaveTakenDays As Double
			//    If Trim(txtDisplayLabel(conDlblPaidLeaveTakenDays).Text) <> "" Then
			//        mPaidLeaveTakenDays = Format(txtDisplayLabel(conDlblPaidLeaveTakenDays).Text, "#########0.000")
			//    Else
			//        mPaidLeaveTakenDays = 0
			//    End If
			//    txtDisplayLabel(conDlblTotalPaidLeaveTakenDays).Text = Format(txtCommonNumber(Index).Value + mPaidLeaveTakenDays, "###,###,##0.000")
			//End If

			double mUnPaidLeaveTakenDays = 0;
			if (Index == conTxtNOpeningUnpaidLeaveTakenDays)
			{
				if (txtDisplayLabel[conDlblUnPaidLeaveTakenDays].Text.Trim() != "")
				{
					mUnPaidLeaveTakenDays = Double.Parse(StringsHelper.Format(txtDisplayLabel[conDlblUnPaidLeaveTakenDays].Text, "#########0.000"));
				}
				else
				{
					mUnPaidLeaveTakenDays = 0;
				}
				txtDisplayLabel[conDlblTotalUnPaidLeaveTakenDays].Text = StringsHelper.Format(ReflectionHelper.GetPrimitiveValue<double>(txtCommonNumber[Index].Value) + mUnPaidLeaveTakenDays, "###,###,##0.000");
			}

		}

		private void System.Windows.Forms.Label1_GotFocus()
		{

		}
	}
}