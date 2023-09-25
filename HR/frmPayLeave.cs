
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using UpgradeHelpers.Gui;



namespace Xtreme
{
	internal partial class frmPayLeave
		: System.Windows.Forms.Form
	{

		public frmPayLeave()
{
InitializeComponent();
} 
 public  void frmPayLeave_old()
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


		private void frmPayLeave_Activated(System.Object eventSender, System.EventArgs eventArgs)
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
		private string mTimeStamp = "";
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

		private bool mFirstGridFocus = false;

		private const int conTxtEarningNo = 0;
		private const int conTxtDeductionNo = 1;

		private const int conDlblEarning = 0;
		private const int conDlblDeduction = 1;

		private const int conTabVailidtyPeriod = 0;
		private const int conTabLeaveEarnings = 1;

		private const int conMaxColumns = 4;
		private const int mconBillNo = 1;
		private const int mconBillName = 2;
		private const int mconAvgOfMonth = 3;
		private const int mconbillCode = 4;


		private int mThisFormID = 0;
		private clsToolbar oThisFormToolBar = null;
		private object mSearchValue = null;
		private SystemVariables.SystemFormModes mCurrentFormMode = (SystemVariables.SystemFormModes) 0;

		//These property set the Form mode to add mode or edit mode

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


		//These property set the Form mode to add mode or edit mode

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


		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBDropDown Event cmbMastersList.RowChange was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void cmbMastersList_RowChange()
		{
			if (grdLeaveEarningDetails.Col == mconBillNo || grdLeaveEarningDetails.Col == mconBillName)
			{
				grdLeaveEarningDetails.Columns[mconBillNo].Value = cmbMastersList.Columns[0].Value;
				grdLeaveEarningDetails.Columns[mconBillName].Value = cmbMastersList.Columns[1].Value;
				grdLeaveEarningDetails.Columns[mconbillCode].Value = cmbMastersList.Columns[4].Value;
				grdLeaveEarningDetails.Columns[mconAvgOfMonth].Value = 0;
			}
		}

		private void cmdUpdateEmployees_Click(Object eventSender, EventArgs eventArgs)
		{
			string mysql = "";


			DialogResult ans = MessageBox.Show("Are you sure, you want to update all the employees having this leave?", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.YesNo, MessageBoxIcon.Information);
			if (ans == System.Windows.Forms.DialogResult.Yes)
			{
				mysql = " Update pay_employee_leave_details ";
				mysql = mysql + " set ";
				mysql = mysql + " leave_switch_over_period = pl.leave_switch_over_period ";
				mysql = mysql + " , leave_days_before_sop = pl.leave_days_before_sop ";
				mysql = mysql + " , leave_days_after_sop = pl.leave_days_after_sop ";
				mysql = mysql + " , working_days_per_month_before_sop = pl.working_days_per_month_before_sop ";
				mysql = mysql + " , working_days_per_month_after_sop = pl.working_days_per_month_after_sop ";
				mysql = mysql + " , deduct_paid_days = pl.deduct_paid_days ";
				mysql = mysql + " , deduct_unpaid_days = pl.deduct_unpaid_days ";
				mysql = mysql + " from pay_leave pl ";
				mysql = mysql + " inner join pay_employee_leave_details peld on peld.leave_cd = pl.leave_cd ";
				mysql = mysql + " where pl.leave_cd =" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
				SqlCommand TempCommand = null;
				TempCommand = SystemVariables.gConn.CreateCommand();
				TempCommand.CommandText = mysql;
				TempCommand.ExecuteNonQuery();
			}
		}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2080
		private void Form_Load()
		{
			string mysql = "";
			FirstFocusObject = txtLeaveNo;

			try
			{

				this.CurrentFormMode = SystemVariables.SystemFormModes.frmAddMode;
				this.Top = 0;
				this.Left = 0;

				//**--format & define the new toolbar
				oThisFormToolBar = new clsToolbar();
				oThisFormToolBar.AttachObject(this); //, tcbSystemForm

				oThisFormToolBar.ShowNewButton = true;
				oThisFormToolBar.ShowSaveButton = true;
				oThisFormToolBar.ShowDeleteButton = true;
				oThisFormToolBar.ShowPrintButton = false;
				oThisFormToolBar.ShowFindButton = true;
				oThisFormToolBar.ShowHelpButton = true;
				oThisFormToolBar.ShowExitButton = true;
				oThisFormToolBar.ShowInsertLineButton = true;
				oThisFormToolBar.ShowDeleteLineButton = true;
				oThisFormToolBar.BeginExitButtonWithGroup = true;
				oThisFormToolBar.DisableHelpButton = true;

				this.WindowState = FormWindowState.Maximized;


				SystemProcedure.SetLabelCaption(this);

				//assign a next code
				txtLeaveNo.Text = SystemProcedure2.GetNewNumber("Pay_Leave", "Leave_No");

				mysql = " select ";
				mysql = mysql + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? " l_type_name" : " a_type_name");
				mysql = mysql + " , type_cd from pay_leave_type ";
				SystemCombo.FillComboWithItemData(cmbLeaveType, mysql);

				if (cmbLeaveType.ListCount > 0)
				{
					cmbLeaveType.ListIndex = 0;
				}

				cmbDeductPaidDays.AddItem("No");
				cmbDeductPaidDays.SetItemData(0, 0);
				cmbDeductPaidDays.AddItem("Yes");
				cmbDeductPaidDays.SetItemData(1, 1);
				cmbDeductPaidDays.ListIndex = 0;

				cmbDeductUnpaidDays.AddItem("No");
				cmbDeductUnpaidDays.SetItemData(0, 0);
				cmbDeductUnpaidDays.AddItem("Yes");
				cmbDeductUnpaidDays.SetItemData(1, 1);
				cmbDeductUnpaidDays.ListIndex = 0;

				cmbDeductAbsentDays.AddItem("No");
				cmbDeductAbsentDays.SetItemData(0, 0);
				cmbDeductAbsentDays.AddItem("Yes");
				cmbDeductAbsentDays.SetItemData(1, 1);
				cmbDeductAbsentDays.ListIndex = 0;

				//''Asssign Earnings Details Grid
				SystemGrid.DefineSystemVoucherGrid(grdLeaveEarningDetails, true, true, true, (0xFFFFFF).ToString(), (0x0).ToString(), true, true, C1.Win.C1TrueDBGrid.MarqueeEnum.SolidCellBorder, 2, 1.4f, "&H00C4B8CD", "&H00C4B8CD");

				SystemGrid.DefineSystemVoucherGridColumn(grdLeaveEarningDetails, "LN", 400, false, "&HC4B8CD", ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false);
				SystemGrid.DefineSystemVoucherGridColumn(grdLeaveEarningDetails, "Billing No.", 2000, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, true, true, "cmbMastersList");
				SystemGrid.DefineSystemVoucherGridColumn(grdLeaveEarningDetails, "Billing Name", 3000, true, ColorTranslator.ToOle(Color.White).ToString(), (0xB4261B).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, true, true, "cmbMastersList");
				SystemGrid.DefineSystemVoucherGridColumn(grdLeaveEarningDetails, "Avg Of Month", 1000, true, ColorTranslator.ToOle(Color.White).ToString(), (0xB4261B).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false);
				SystemGrid.DefineSystemVoucherGridColumn(grdLeaveEarningDetails, "BillCd", 2500, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, false);

				DefineVoucherArray(-1, false);
				AssignGridLineNumbers();

				//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBGrid property grdLeaveEarningDetails.Array was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				grdLeaveEarningDetails.setArray(aVoucherDetails);
				grdLeaveEarningDetails.Rebind(true);

				grdLeaveEarningDetails.Enabled = true;

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

				SystemCombo.SearchCombo(cmbMonth, 1);
				optValidity[2].Checked = true;
				cmdUpdateEmployees.Visible = false;
				this.tabLeaveDetails.CurrTab = Convert.ToInt16(conTabVailidtyPeriod);
				mFirstGridFocus = true;
			}
			catch (System.Exception excep)
			{
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, excep.Message, this.Name, "Form Load");
				this.Close();
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

		private void AssignGridLineNumbers()
		{
			int cnt = 0;
			int tempForEndVar = aVoucherDetails.GetLength(0) - 1;
			for (cnt = 0; cnt <= tempForEndVar; cnt++)
			{
				aVoucherDetails.SetValue(cnt + 1, cnt, SystemICSConstants.grdLineNoColumn);
			}
		}

		private void Form_KeyDown(Object eventSender, KeyEventArgs eventArgs)
		{
			int KeyCode = (int) eventArgs.KeyCode;
			int Shift = ((int) eventArgs.KeyData) / 65536;
			try
			{
				//On Keydown navigate the form by using enter key
				if (KeyCode == 13)
				{ //If enter key pressed send a tab key
					SendKeys.Send("{TAB}");
					return;
				}

				if (this.ActiveControl.Name != "txtCommonTextBox")
				{
					SystemForms.SystemFormKeyDown(this, ref KeyCode, Shift, this.ActiveControl.Name);
				}
				else
				{
					SystemForms.SystemFormKeyDown(this, ref KeyCode, Shift, "txtCommonTextBox#" + ControlArrayHelper.GetControlIndex(this.ActiveControl).ToString().Trim());
				}


				//Call SystemFormKeyDown(Me, KeyCode, Shift, Me.ActiveControl.Name)
			}
			finally
			{
				eventArgs.Handled = KeyCode == 0;
			}
		}
		//Add a record
		public void AddRecord()
		{

			SystemProcedure2.ClearTextBox(this);
			txtLeaveNo.Text = SystemProcedure2.GetNewNumber("Pay_Leave", "Leave_No");

			mCurrentFormMode = SystemVariables.SystemFormModes.frmAddMode; //Change the form mode to addmode
			mSearchValue = ""; //Change the msearchvalue to blank
			this.tabLeaveDetails.CurrTab = Convert.ToInt16(conTabVailidtyPeriod);
			chkIncludeInDefaultLeaveTypes.CheckState = CheckState.Unchecked;
			chkIncludeWeekend.CheckState = CheckState.Unchecked;
			chkCalcOnCalendarDays.CheckState = CheckState.Unchecked;
			SystemCombo.SearchCombo(cmbDeductPaidDays, 0);
			SystemCombo.SearchCombo(cmbDeductUnpaidDays, 0);
			SystemCombo.SearchCombo(cmbDeductAbsentDays, 0);
			cmdUpdateEmployees.Visible = false;
			txtEligibilityDays.Value = 0;
			FirstFocusObject.Focus();
			mFirstGridFocus = true;
			DefineVoucherArray(-1, true);
			AssignGridLineNumbers();
			grdLeaveEarningDetails.Rebind(true);
			grdLeaveEarningDetails.Enabled = true;
			return;

			//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
			SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, Information.Err().Description, this.Name, "AddRecord");
		}

		public bool saveRecord()
		{
			bool result = false;
			object mReturnValue = null;
			object mEarningCd = null;
			object mDeductionCd = null;
			int i = 0;
			//Dim mParentLeaveCode As Integer
			//Save a record
			//During save check for the mode
			//If in addmode then insert a record
			//else update the record in the recordset

			string mysql = "";
			try
			{

				grdLeaveEarningDetails.UpdateData();

				//'' Added by Burhan Ghee Wala; Date : 25-Jul-2007
				// Check for Earning Bill Code
				mysql = "select bill_cd from pay_billing_type where bill_no ='" + txtCommonTextBox[conTxtEarningNo].Text + "'";
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (Convert.IsDBNull(mReturnValue))
				{
					MessageBox.Show("Invalid Earning Code Selection !!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
					txtCommonTextBox[conTxtEarningNo].Focus();
					return result;
				}
				//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mEarningCd = ReflectionHelper.GetPrimitiveValue(mReturnValue);

				//Check for Deduction Bill Code
				mysql = "select bill_cd from pay_billing_type where bill_no ='" + txtCommonTextBox[conTxtDeductionNo].Text + "'";
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (Convert.IsDBNull(mReturnValue))
				{
					MessageBox.Show("Invalid Deduction Code Selection !!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
					txtCommonTextBox[conTxtDeductionNo].Focus();
					return result;
				}
				//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mDeductionCd = ReflectionHelper.GetPrimitiveValue(mReturnValue);

				//''End

				SystemVariables.gConn.BeginTransaction();
				int mLinkedLeaveCode = 0;
				string mCheckTimeStamp = "";
				if (mCurrentFormMode == SystemVariables.SystemFormModes.frmAddMode)
				{
					mysql = " insert into pay_leave (leave_type_cd, leave_no, l_leave_name";
					mysql = mysql + " , a_leave_name, leave_switch_over_period, leave_days_before_sop";
					mysql = mysql + " , leave_days_after_sop, working_days_per_month_before_sop ";
					mysql = mysql + " , working_days_per_month_after_sop, deduct_paid_days";
					mysql = mysql + " , deduct_unpaid_days ,Deduct_Absent_Days , include_in_default_leave_types ";
					mysql = mysql + " , earning_bill_cd, deduction_bill_cd, validity_period_type, validity_period_month, include_weekend, eligibility_days, user_cd,calculate_on_calendar_days )";
					mysql = mysql + " values(";
					mysql = mysql + cmbLeaveType.GetItemData(cmbLeaveType.ListIndex).ToString();
					mysql = mysql + "," + txtLeaveNo.Text;
					mysql = mysql + ",'" + txtLLeaveName.Text + "'";
					mysql = mysql + ",N'" + txtALeaveName.Text + "'";
					mysql = mysql + "," + ((SystemProcedure2.IsItEmpty(txtLeaveSwitchOverPeriod.Value, SystemVariables.DataType.NumberType)) ? "0" : ReflectionHelper.GetPrimitiveValue<string>(txtLeaveSwitchOverPeriod.Value));
					mysql = mysql + "," + ((SystemProcedure2.IsItEmpty(txtLeaveDaysBeforeSOP.Value, SystemVariables.DataType.NumberType)) ? "0" : ReflectionHelper.GetPrimitiveValue<string>(txtLeaveDaysBeforeSOP.Value));
					mysql = mysql + "," + ((SystemProcedure2.IsItEmpty(txtLeaveDaysAfterSOP.Value, SystemVariables.DataType.NumberType)) ? "0" : ReflectionHelper.GetPrimitiveValue<string>(txtLeaveDaysAfterSOP.Value));
					mysql = mysql + "," + ((SystemProcedure2.IsItEmpty(txtWDPerMonthBeforeSOP.Value, SystemVariables.DataType.NumberType)) ? "0" : ReflectionHelper.GetPrimitiveValue<string>(txtWDPerMonthBeforeSOP.Value));
					mysql = mysql + "," + ((SystemProcedure2.IsItEmpty(txtWDPerMonthAfterSOP.Value, SystemVariables.DataType.NumberType)) ? "0" : ReflectionHelper.GetPrimitiveValue<string>(txtWDPerMonthAfterSOP.Value));
					mysql = mysql + "," + cmbDeductPaidDays.GetItemData(cmbDeductPaidDays.ListIndex).ToString();
					mysql = mysql + "," + cmbDeductUnpaidDays.GetItemData(cmbDeductUnpaidDays.ListIndex).ToString();
					mysql = mysql + "," + cmbDeductAbsentDays.GetItemData(cmbDeductAbsentDays.ListIndex).ToString();
					mysql = mysql + "," + ((int) chkIncludeInDefaultLeaveTypes.CheckState).ToString();
					mysql = mysql + "," + ReflectionHelper.GetPrimitiveValue<string>(mEarningCd);
					mysql = mysql + "," + ReflectionHelper.GetPrimitiveValue<string>(mDeductionCd);
					int tempForEndVar = optValidity.ControlCount() - 1;
					for (i = 0; i <= tempForEndVar; i++)
					{
						if (optValidity[i].Checked)
						{
							mysql = mysql + "," + i.ToString();
						}
					}
					mysql = mysql + "," + cmbMonth.GetItemData(cmbMonth.ListIndex).ToString();
					mysql = mysql + "," + ((int) chkIncludeWeekend.CheckState).ToString();
					//added by burhan. Date: 19-Jun-2008
					mysql = mysql + ", " + ReflectionHelper.GetPrimitiveValue<string>(txtEligibilityDays.Value);
					mysql = mysql + "," + Conversion.Str(SystemVariables.gLoggedInUserCode);
					mysql = mysql + "," + ((int) chkCalcOnCalendarDays.CheckState).ToString();
					mysql = mysql + ")";

					SqlCommand TempCommand = null;
					TempCommand = SystemVariables.gConn.CreateCommand();
					TempCommand.CommandText = mysql;
					TempCommand.ExecuteNonQuery();

					mLinkedLeaveCode = ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetMasterCode("select scope_identity()"));
					mSearchValue = mLinkedLeaveCode;
					//    '''Insert a record in Pay_Billing_Type
					//    mySql = " select isnull(max(bill_no),0)+1 from Pay_Billing_Type"
					//    mySql = mySql & " where bill_no<1000"
					//    mReturnValue = GetMasterCode(mySql)

					//    mySql = " INSERT INTO Pay_Billing_Type(user_cd, Bill_no, l_Bill_name"
					//    mySql = mySql & " , a_Bill_name, bill_type_id, linked_leave_cd, show, protected "
					//    mySql = mySql & " , include_in_default_billing_types, comments)"
					//    mySql = mySql & " VALUES(" & Str(gLoggedInUserCode)
					//    mySql = mySql & " , " & mReturnValue
					//    mySql = mySql & ",'" & txtLLeaveName.Text & "'"
					//    mySql = mySql & ",N'" & txtALeaveName.Text & "'"
					//    mySql = mySql & " , 51"
					//    mySql = mySql & " , " & mLinkedLeaveCode
					//    mySql = mySql & " , 1"
					//    mySql = mySql & " , 1"
					//    mySql = mySql & " , " & chkIncludeInDefaultLeaveTypes.Value
					//    mySql = mySql & ", N'" & txtComment.Text & "')"
					//    gConn.Execute mySql
				}
				else
				{
					mysql = " select time_stamp,protected from Pay_Leave where Leave_cd =" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (!Convert.IsDBNull(mReturnValue))
					{
						//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mCheckTimeStamp = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(0));
					}
					else
					{
						MessageBox.Show(SystemConstants.msg10, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
						//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						SystemVariables.gConn.RollbackTrans();
						result = false;
						FirstFocusObject.Focus();
						return result;
					}
					if (SystemProcedure2.tsFormat(mTimeStamp) != SystemProcedure2.tsFormat(mCheckTimeStamp))
					{
						MessageBox.Show(SystemConstants.msg10, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
						//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						SystemVariables.gConn.RollbackTrans();
						result = false;
						FirstFocusObject.Focus();
						return result;
					}

					mysql = " update Pay_Leave SET ";
					mysql = mysql + " Leave_No =" + txtLeaveNo.Text;
					mysql = mysql + ", L_Leave_Name ='" + txtLLeaveName.Text + "'";
					mysql = mysql + ", A_Leave_Name =N'" + txtALeaveName.Text + "'";
					mysql = mysql + ", earning_bill_cd=" + ReflectionHelper.GetPrimitiveValue<string>(mEarningCd);
					mysql = mysql + ", deduction_bill_cd=" + ReflectionHelper.GetPrimitiveValue<string>(mDeductionCd);
					mysql = mysql + ", Comments =N'" + txtComment.Text + "'";
					mysql = mysql + ", leave_switch_over_period=" + ((SystemProcedure2.IsItEmpty(txtLeaveSwitchOverPeriod.Value, SystemVariables.DataType.NumberType)) ? "0" : ReflectionHelper.GetPrimitiveValue<string>(txtLeaveSwitchOverPeriod.Value));
					mysql = mysql + ", leave_days_before_sop =" + ((SystemProcedure2.IsItEmpty(txtLeaveDaysBeforeSOP.Value, SystemVariables.DataType.NumberType)) ? "0" : ReflectionHelper.GetPrimitiveValue<string>(txtLeaveDaysBeforeSOP.Value));
					mysql = mysql + ", leave_days_after_sop =" + ((SystemProcedure2.IsItEmpty(txtLeaveDaysAfterSOP.Value, SystemVariables.DataType.NumberType)) ? "0" : ReflectionHelper.GetPrimitiveValue<string>(txtLeaveDaysAfterSOP.Value));
					mysql = mysql + ", working_days_per_month_before_sop =" + ((SystemProcedure2.IsItEmpty(txtWDPerMonthBeforeSOP.Value, SystemVariables.DataType.NumberType)) ? "0" : ReflectionHelper.GetPrimitiveValue<string>(txtWDPerMonthBeforeSOP.Value));
					mysql = mysql + ", working_days_per_month_after_sop =" + ((SystemProcedure2.IsItEmpty(txtWDPerMonthAfterSOP.Value, SystemVariables.DataType.NumberType)) ? "0" : ReflectionHelper.GetPrimitiveValue<string>(txtWDPerMonthAfterSOP.Value));
					mysql = mysql + ", leave_type_cd =" + cmbLeaveType.GetItemData(cmbLeaveType.ListIndex).ToString();
					mysql = mysql + ", deduct_paid_days =" + cmbDeductPaidDays.GetItemData(cmbDeductPaidDays.ListIndex).ToString();
					mysql = mysql + ", deduct_Unpaid_days =" + cmbDeductUnpaidDays.GetItemData(cmbDeductUnpaidDays.ListIndex).ToString();
					mysql = mysql + ", Deduct_Absent_Days =" + cmbDeductAbsentDays.GetItemData(cmbDeductAbsentDays.ListIndex).ToString();
					mysql = mysql + ", include_in_default_leave_types=" + ((int) chkIncludeInDefaultLeaveTypes.CheckState).ToString();
					mysql = mysql + ", include_weekend =" + ((int) chkIncludeWeekend.CheckState).ToString();
					mysql = mysql + ", calculate_on_calendar_days =" + ((int) chkCalcOnCalendarDays.CheckState).ToString();
					int tempForEndVar2 = optValidity.ControlCount() - 1;
					for (i = 0; i <= tempForEndVar2; i++)
					{
						if (optValidity[i].Checked)
						{
							mysql = mysql + ", validity_period_type=" + i.ToString();
						}
					}
					mysql = mysql + ", validity_period_month=" + cmbMonth.GetItemData(cmbMonth.ListIndex).ToString();
					//added by burhan. Date: 19-jun-2008
					mysql = mysql + ", eligibility_days = " + ReflectionHelper.GetPrimitiveValue<string>(txtEligibilityDays.Value);
					mysql = mysql + ", User_Cd =" + Conversion.Str(SystemVariables.gLoggedInUserCode);
					mysql = mysql + " where Leave_cd=" + Conversion.Str(mSearchValue);
					SqlCommand TempCommand_2 = null;
					TempCommand_2 = SystemVariables.gConn.CreateCommand();
					TempCommand_2.CommandText = mysql;
					TempCommand_2.ExecuteNonQuery();
				}
				mysql = " delete from pay_leave_earning_details where leave_cd = " + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
				SqlCommand TempCommand_3 = null;
				TempCommand_3 = SystemVariables.gConn.CreateCommand();
				TempCommand_3.CommandText = mysql;
				TempCommand_3.ExecuteNonQuery();

				int mCnt = 0;
				int tempForEndVar3 = aVoucherDetails.GetLength(0) - 1;
				for (mCnt = 0; mCnt <= tempForEndVar3; mCnt++)
				{
					mysql = " insert into pay_leave_earning_details(leave_cd,bill_cd, Average_Of_month)";
					mysql = mysql + " values(" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
					mysql = mysql + " ," + Convert.ToString(aVoucherDetails.GetValue(mCnt, mconbillCode));
					mysql = mysql + " ," + Convert.ToString(aVoucherDetails.GetValue(mCnt, mconAvgOfMonth));
					mysql = mysql + ")";
					SqlCommand TempCommand_4 = null;
					TempCommand_4 = SystemVariables.gConn.CreateCommand();
					TempCommand_4.CommandText = mysql;
					TempCommand_4.ExecuteNonQuery();
				}
				//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.CommitTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				SystemVariables.gConn.CommitTrans();
				result = true;
				FirstFocusObject.Focus();
			}
			catch (System.Exception excep)
			{

				int mReturnErrorType = 0;
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				mReturnErrorType = SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, excep.Message, this.Name, "GetRecord", SystemConstants.msg10);
				//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				SystemVariables.gConn.RollbackTrans();
				result = false;
			}
			return result;
		}

		public bool deleteRecord()
		{

			bool result = false;
			string mysql = " select protected from Pay_Leave where Leave_cd=" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
			//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(mReturnValue))
			{
				if (ReflectionHelper.GetPrimitiveValue<bool>(mReturnValue))
				{
					MessageBox.Show(SystemConstants.msg12, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					return false;
				}

				//If an error occurs, trap the error and dispaly a valid message
				SystemVariables.gConn.BeginTransaction();

				//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
				try
				{
					//    mySql = "delete from Pay_billing_type where linked_Leave_cd=" & Str(mSearchValue)
					//    gConn.Execute mySql

					mysql = "delete from Pay_Leave where Leave_cd=" + Conversion.Str(mSearchValue);
					SqlCommand TempCommand = null;
					TempCommand = SystemVariables.gConn.CreateCommand();
					TempCommand.CommandText = mysql;
					TempCommand.ExecuteNonQuery();

					//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
					if (Information.Err().Number != 0)
					{
						MessageBox.Show("Employee Leave cannot be deleted, transaction already occurs", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
						//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						SystemVariables.gConn.RollbackTrans();
						return false;
					}

					//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.CommitTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					SystemVariables.gConn.CommitTrans();
					result = true;
				}
				catch (Exception exc)
				{
					NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
				}
			}

			return result;

			//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
			int mReturnErrorType = SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, Information.Err().Description, this.Name, "GetRecord", SystemConstants.msg10);
			if (mReturnErrorType == 1)
			{
				return false;
			}
			else if (mReturnErrorType == 2)
			{ 
				AddRecord();
				return false;
			}
			else
			{
				return false;
			}
		}

		public void GetRecord(object SearchValue)
		{
			//This routine is called after getting the value from Find window or
			//refreshing the recordset during any error of updating or deleting

			try
			{
				string mysql = "";
				object mReturnValue = null;
				SqlDataReader localRec = null;
				DataSet rsLeaveEarning = null;

				mysql = " select * from Pay_Leave where Leave_cd= " + ReflectionHelper.GetPrimitiveValue<string>(SearchValue);

				SqlCommand sqlCommand = new SqlCommand(mysql, SystemVariables.gConn);
				localRec = sqlCommand.ExecuteReader();
				int mCntRow = 0;
				if (localRec.Read())
				{
					mSearchValue = localRec["Leave_cd"];
					mTimeStamp = Convert.ToString(localRec["time_stamp"]);
					txtLeaveNo.Text = Convert.ToString(localRec["Leave_No"]);
					txtLLeaveName.Text = Convert.ToString(localRec["l_Leave_Name"]);
					txtALeaveName.Text = Convert.ToString(localRec["a_Leave_Name"]) + "";
					SystemCombo.SearchCombo(cmbMonth, (Convert.IsDBNull(localRec["validity_period_month"])) ? -1 : Convert.ToInt32(localRec["validity_period_month"]));
					optValidity[Convert.ToInt32(localRec["validity_period_type"])].Checked = true;
					txtLeaveSwitchOverPeriod.Value = localRec["Leave_Switch_Over_Period"];
					txtLeaveDaysBeforeSOP.Value = localRec["Leave_Days_Before_SOP"];
					txtLeaveDaysAfterSOP.Value = localRec["Leave_Days_After_SOP"];
					txtWDPerMonthBeforeSOP.Value = localRec["Working_Days_Per_Month_Before_SOP"];
					txtWDPerMonthAfterSOP.Value = localRec["Working_Days_Per_Month_After_SOP"];

					SystemCombo.SearchCombo(cmbLeaveType, Convert.ToInt32(localRec["leave_type_cd"]));
					SystemCombo.SearchCombo(cmbDeductPaidDays, (Convert.ToBoolean(localRec["Deduct_Paid_Days"])) ? 1 : 0);
					SystemCombo.SearchCombo(cmbDeductUnpaidDays, (Convert.ToBoolean(localRec["Deduct_UnPaid_Days"])) ? 1 : 0);
					SystemCombo.SearchCombo(cmbDeductAbsentDays, (Convert.ToBoolean(localRec["Deduct_Absent_Days"])) ? 1 : 0);

					txtComment.Text = Convert.ToString(localRec["Comments"]) + "";
					//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
					chkIncludeInDefaultLeaveTypes.CheckState = (CheckState) ((Convert.ToBoolean(localRec["include_in_default_leave_types"])) ? 1 : 0);
					//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
					chkIncludeWeekend.CheckState = (CheckState) ((Convert.ToBoolean(localRec["include_weekend"])) ? 1 : 0);
					//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
					chkCalcOnCalendarDays.CheckState = (CheckState) ((Convert.ToBoolean(localRec["Calculate_On_Calendar_Days"])) ? 1 : 0);
					//'' Added by Burhan Ghee Wala Date: 25-Jul-2007
					mysql = "select bill_no, l_bill_name, a_bill_name from pay_billing_type ";
					mysql = mysql + " where bill_cd = " + Conversion.Val((Convert.IsDBNull(localRec["earning_bill_cd"])) ? "0" : Convert.ToString(localRec["earning_bill_cd"])).ToString();
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (!Convert.IsDBNull(mReturnValue))
					{
						//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtCommonTextBox[conTxtEarningNo].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(0));
						txtDisplayLabel[conDlblEarning].Text = ReflectionHelper.GetPrimitiveValue<string>((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? ((Array) mReturnValue).GetValue(1) : ((Array) mReturnValue).GetValue(2));
					}

					mysql = "select bill_no, l_bill_name, a_bill_name from pay_billing_type ";
					mysql = mysql + " where bill_cd = " + Conversion.Val((Convert.IsDBNull(localRec["deduction_bill_cd"])) ? "0" : Convert.ToString(localRec["deduction_bill_cd"])).ToString();
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (!Convert.IsDBNull(mReturnValue))
					{
						//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtCommonTextBox[conTxtDeductionNo].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(0));
						txtDisplayLabel[conDlblDeduction].Text = ReflectionHelper.GetPrimitiveValue<string>((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? ((Array) mReturnValue).GetValue(1) : ((Array) mReturnValue).GetValue(2));
					}
					//''End
					//'added by burhan. Date:19-Jun-2008
					txtEligibilityDays.Value = localRec["eligibility_days"];
					//Change the form mode to edit
					mCurrentFormMode = SystemVariables.SystemFormModes.frmEditMode;

					//        cmdUpdateEmployees.Visible = True

					cmdUpdateEmployees.Visible = SystemVariables.gLoggedInUserCode == SystemConstants.gDefaultAdminUserCode;

				}
				mysql = " select pbt.bill_no ,pbt.bill_cd ,  " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? " pbt.l_bill_name" : " pbt.a_bill_name") + " as bill_Name";
				mysql = mysql + " ,pled.Average_Of_month";
				mysql = mysql + " from pay_leave_earning_details pled";
				mysql = mysql + " inner join pay_billing_type pbt on pbt.bill_cd = pled.bill_cd";
				mysql = mysql + " where pled.leave_cd =" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
				rsLeaveEarning = new DataSet();
				SqlDataAdapter adap_2 = new SqlDataAdapter(mysql, SystemVariables.gConn);
				rsLeaveEarning.Tables.Clear();
				adap_2.Fill(rsLeaveEarning);
				aVoucherDetails.RedimXArray(new int[]{rsLeaveEarning.Tables[0].Rows.Count - 1, conMaxColumns}, new int[]{0, 0});
				mCntRow = 0;
				foreach (DataRow iteration_row in rsLeaveEarning.Tables[0].Rows)
				{
					aVoucherDetails.SetValue(iteration_row["bill_no"], mCntRow, mconBillNo);
					aVoucherDetails.SetValue(iteration_row["bill_Name"], mCntRow, mconBillName);
					aVoucherDetails.SetValue(iteration_row["Average_Of_month"], mCntRow, mconAvgOfMonth);
					aVoucherDetails.SetValue(iteration_row["bill_cd"], mCntRow, mconbillCode);
					mCntRow++;
				}
				AssignGridLineNumbers();
				grdLeaveEarningDetails.Rebind(true);
				grdLeaveEarningDetails.Refresh();
				localRec.Close();
				grdLeaveEarningDetails.Enabled = true;
			}
			catch (System.Exception excep)
			{
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, excep.Message, this.Name, "GetRecord");
			}

		}

		public void PrintReport()
		{

		}

		public void findRecord()
		{
			//Call the find window

			//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(7010000));
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(mTempSearchValue))
			{
				//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mSearchValue = ReflectionHelper.GetPrimitiveValue(((Array) mTempSearchValue).GetValue(0));
				GetRecord(mSearchValue);
			}
		}

		public void CloseForm()
		{
			this.Close();
		}

		public bool CheckDataValidity()
		{
			//Check validation during update and add of records
			if (!Information.IsNumeric(txtLeaveNo.Text))
			{
				MessageBox.Show("Enter Leave Code", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
				FirstFocusObject.Focus();
				return false;
			}

			if (SystemProcedure2.IsItEmpty(txtCommonTextBox[conTxtEarningNo].Text, SystemVariables.DataType.StringType))
			{
				MessageBox.Show("Enter Related Earning Code !!", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
				txtCommonTextBox[conTxtEarningNo].Focus();
				return false;
			}

			if (SystemProcedure2.IsItEmpty(txtCommonTextBox[conTxtDeductionNo].Text, SystemVariables.DataType.StringType))
			{
				MessageBox.Show("Enter Related Deduction Code !!", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
				txtCommonTextBox[conTxtDeductionNo].Focus();
				return false;
			}

			return true;
		}

		private void Form_Closed(Object eventSender, EventArgs eventArgs)
		{
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{
				SystemMenu.RemoveMeFromWindowList(Conversion.Str(this.Handle.ToInt32()));

				UserAccess = null;
				oThisFormToolBar = null;
				frmPayLeave.DefInstance = null;
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		private bool isInitializingComponent;
		private void optValidity_CheckedChanged(Object eventSender, EventArgs eventArgs)
		{
			int Index = Array.IndexOf(this.optValidity, eventSender);
			if (((RadioButton) eventSender).Checked)
			{
				if (isInitializingComponent)
				{
					return;
				}
				cmbMonth.Enabled = Index == 0;
			}
		}

		private void txtCommonTextBox_DropButtonClick(Object Sender, EventArgs e)
		{
			int Index = Array.IndexOf(this.txtCommonTextBox, Sender);
			FindRoutine("txtCommonTextBox#" + Index.ToString().Trim());
		}

		private void txtCommonTextBox_Leave(Object eventSender, EventArgs eventArgs)
		{
			int Index = Array.IndexOf(this.txtCommonTextBox, eventSender);
			try
			{
				object mReturnValue = null;
				string mysql = "";
				int mLinkedTextBoxIndex = 0;


				switch(Index)
				{
					case conTxtEarningNo : 
						mysql = "select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "pbt.l_bill_name" : "pbt.a_bill_name"); 
						mysql = mysql + " from pay_billing_type pbt where bill_no ='" + txtCommonTextBox[conTxtEarningNo].Text + "'"; 
						mLinkedTextBoxIndex = conDlblEarning; 
						 
						break;
					case conTxtDeductionNo : 
						mysql = "select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "pbt.l_bill_name" : "pbt.a_bill_name"); 
						mysql = mysql + " from pay_billing_type pbt where bill_no ='" + txtCommonTextBox[conTxtDeductionNo].Text + "'"; 
						mLinkedTextBoxIndex = conDlblDeduction; 
						 
						break;
					default:
						return; 

				}

				if (!SystemProcedure2.IsItEmpty(txtCommonTextBox[Index].Text, SystemVariables.DataType.StringType))
				{
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (Convert.IsDBNull(mReturnValue))
					{
						txtDisplayLabel[mLinkedTextBoxIndex].Text = "";
						throw new System.Exception("-9990002");
					}
					//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					txtDisplayLabel[mLinkedTextBoxIndex].Text = ReflectionHelper.GetPrimitiveValue<string>(mReturnValue);
				}
			}
			catch (System.Exception excep)
			{

				int mReturnErrorType = 0;
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				mReturnErrorType = SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, excep.Message, this.Name, "GetRecord", SystemConstants.msg10);
				if (mReturnErrorType == 1)
				{
					//
				}
				else if (mReturnErrorType == 2)
				{ 
					//
				}
				else if (mReturnErrorType == 3)
				{ 
					//
				}
				else if (mReturnErrorType == 4)
				{ 
					//    Me.txtCommonTextBox(Index).SetFocus
				}
				else
				{
					//
				}
			}

		}

		private void txtLeaveNo_DropButtonClick(Object Sender, EventArgs e)
		{
			//Get the maximum + 1 product_category code
			GetNextNumber();
		}


		private void GetNextNumber()
		{
			txtLeaveNo.Text = SystemProcedure2.GetNewNumber("Pay_Leave", "Leave_No");
			FirstFocusObject.Focus();
		}


		public void FindRoutine(string pObjectName)
		{

			object mTempSearchValue = null;
			string mysql = "";
			if ((pObjectName.IndexOf('#') + 1) == 0)
			{
				return;
			}

			string mObjectName = pObjectName.Substring(0, Math.Min(pObjectName.IndexOf('#'), pObjectName.Length));
			int mObjectIndex = Convert.ToInt32(Double.Parse(pObjectName.Substring(pObjectName.IndexOf('#') + 1)));
			if (mObjectName == "txtCommonTextBox")
			{
				txtCommonTextBox[mObjectIndex].Text = "";
				switch(mObjectIndex)
				{
					//Case conTxtEmpCd
					//mTempSearchValue = FindItem(7050000, "831")
					case conTxtEarningNo : 
						 
						txtCommonTextBox[conTxtEarningNo].Text = ""; 
						mysql = " pbt.show =  1 and pbt.bill_type_id= 51"; 
						//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
						mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(7008000, "775", mysql)); 
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049 
						if (!Convert.IsDBNull(mTempSearchValue))
						{
							//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							txtCommonTextBox[conTxtEarningNo].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(1));
							txtCommonTextBox_Leave(txtCommonTextBox[mObjectIndex], new EventArgs());
						} 
						break;
					case conTxtDeductionNo : 
						txtCommonTextBox[conTxtDeductionNo].Text = ""; 
						mysql = " pbt.show =  1 and pbt.bill_type_id= 52"; 
						//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
						mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(7008000, "775", mysql)); 
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049 
						if (!Convert.IsDBNull(mTempSearchValue))
						{
							//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							txtCommonTextBox[conTxtDeductionNo].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(1));
							txtCommonTextBox_Leave(txtCommonTextBox[mObjectIndex], new EventArgs());
						} 
						 
						break;
					default:
						return; 

				}

				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(mTempSearchValue))
				{
					//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					txtCommonTextBox[mObjectIndex].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(1));
					txtCommonTextBox_Leave(txtCommonTextBox[mObjectIndex], new EventArgs());
				}
			}

		}


		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBDropDown Event cmbMastersList.DataSourceChanged was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void cmbMastersList_DataSourceChanged()
		{
			int cnt = 0;

			cmbMastersList.Width = 0;

			C1.Win.C1TrueDBGrid.C1DisplayColumn withVar = null;
			switch(grdLeaveEarningDetails.Col)
			{
				case mconBillNo : case mconBillName : 
					if (grdLeaveEarningDetails.Col == mconBillNo)
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
								withVar.setOrder((grdLeaveEarningDetails.Col == mconBillNo) ? 0 : 1);
								//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
								withVar.Width = grdLeaveEarningDetails.Splits[0].DisplayColumns[mconBillNo].Width;
							}
							else if (cnt == 1)
							{ 
								//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.Column property withVar.Order was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
								withVar.setOrder((grdLeaveEarningDetails.Col == mconBillNo) ? 1 : 0);
								//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
								withVar.Width = grdLeaveEarningDetails.Splits[0].DisplayColumns[mconBillName].Width;
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
			switch(grdLeaveEarningDetails.Col)
			{
				case mconBillNo : case mconBillName : 
					if (grdLeaveEarningDetails.Col == mconBillNo)
					{
						grdLeaveEarningDetails.Col = mconBillNo;
					}
					else
					{
						grdLeaveEarningDetails.Col = mconBillName;
					} 
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
				mysql = mysql + " , pbt.bill_type_id as bill_type_id, pbt.bill_cd "; //''''''
				mysql = mysql + " from pay_billing_type pbt ";
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

		private void grdLeaveEarningDetails_GotFocus(Object eventSender, EventArgs eventArgs)
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
				//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBGrid method grdLeaveEarningDetails.PostMsg was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				grdLeaveEarningDetails.PostMsg(1);
			}
		}

		private void grdLeaveEarningDetails_RowColChange(object eventSender, C1.Win.C1TrueDBGrid.RowColChangeEventArgs eventArgs)
		{
			int LastRow = eventArgs.LastRow;
			int LastCol = eventArgs.LastCol;
			if (grdLeaveEarningDetails.Col > 0 && LastCol > 0 && !mFirstGridFocus)
			{
				switch(grdLeaveEarningDetails.Col)
				{
					case mconBillNo : case mconBillName : 
						//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbMastersList.DataSource was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064 
						cmbMastersList.setDataSource((msdatasrc.DataSource) rsBillingCodeList); 
						break;
				}
			}
		}

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBGrid Event grdLeaveEarningDetails.PostEvent was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void grdLeaveEarningDetails_PostEvent(int MsgId)
		{
			int Col = 0;

			if (MsgId == 1)
			{
				grdLeaveEarningDetails.Col = mconBillNo;
				//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbMastersList.DataSource was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				cmbMastersList.setDataSource((msdatasrc.DataSource) rsBillingCodeList);
			}
		}

		public void IRoutine()
		{
			int mCurrentLineNo = 0;

			if (ActiveControl.Name != "grdLeaveEarningDetails" && grdLeaveEarningDetails.Enabled)
			{
				grdLeaveEarningDetails.Focus();
			}
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(grdLeaveEarningDetails.Bookmark))
			{
				//UPGRADE_WARNING: (1068) grdLeaveEarningDetails.Columns().Value of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mCurrentLineNo = ReflectionHelper.GetPrimitiveValue<int>(grdLeaveEarningDetails.Columns[SystemICSConstants.grdLineNoColumn].Value);
				//UPGRADE_ISSUE: (2064) XArrayDBObject.XArrayDB method aVoucherDetails.InsertRows was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				aVoucherDetails.InsertRows(ReflectionHelper.GetPrimitiveValue<int>(grdLeaveEarningDetails.Bookmark), 1);
				AssignGridLineNumbers();
				grdLeaveEarningDetails.Rebind(true);
			}
		}

		public void LRoutine()
		{
			if (ActiveControl.Name != "grdLeaveEarningDetails" && grdLeaveEarningDetails.Enabled)
			{
				grdLeaveEarningDetails.Focus();
			}

			if (aVoucherDetails.GetLength(0) > 0)
			{
				grdLeaveEarningDetails.Delete();
				AssignGridLineNumbers();
				grdLeaveEarningDetails.Rebind(true);
			}
		}
	}
}