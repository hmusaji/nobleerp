
using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using UpgradeHelpers.Gui;



namespace Xtreme
{
	internal partial class frmPayLeaveTransaction
		: System.Windows.Forms.Form
	{

		public frmPayLeaveTransaction()
{
InitializeComponent();
} 
 public  void frmPayLeaveTransaction_old()
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


		private void frmPayLeaveTransaction_Activated(System.Object eventSender, System.EventArgs eventArgs)
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
		public int mEligibilityDays = 0;
		private bool mIncludeWeekend = false;
		private bool mCheck = false;
		private clsToolbar oThisFormToolBar = null;

		private const int conTabLeaveDetails = 0;
		private const int conTabOtherDetails = 1;
		private const int contabApproval = 2;

		private const int conChkTicketCash = 0;
		private const int conChkTicketBooked = 1;

		private const int conTxtVoucherNo = 0;
		private const int conTxtEmpCode = 1;
		private const int conTXTReferenceNo = 2;
		private const int conTxtLeaveCode = 3;
		private const int conTxtComments = 5;
		private const int conTxtTicketEntitledDest = 4;
		private const int conTxtTicketIssuedDest = 6;

		private const int conDlblDeptCode = 0;
		private const int conDlblDeptName = 1;
		private const int conDlblDesgCode = 2;
		private const int conDlblDesgName = 3;
		private const int conDlblLeaveSalary = 4;
		private const int conDlblEmpName = 5;
		private const int conDlblLeaveName = 6;
		private const int conDlblLeaveBalanceDays = 7;
		private const int conDlblLeaveAmount = 8;
		private const int conDlblTotalSalary = 9;
		private const int conDlblPublicHolidays = 10;
		private const int conDlblTicketBalance = 11;
		private const int conDlblHolidayAmount = 12;
		private const int conDlblTotalCashSalary = 13;
		private const int conDlblLastLeavePaidDays = 14;

		private const int conDTxtVoucheDate = 0;
		private const int conDTxtLeaveFromDate = 1;
		private const int conDTxtLeaveToDate = 2;
		private const int conDTxtLastLeaveStartDate = 3;
		private const int conDTxtLastLeaveEndDate = 4;
		private const int conDTxtTicketIssuedUptoDate = 5;

		private const int conNTxtLeaveDays = 0;
		private const int conNTxtActualLeaveDays = 1;
		private const int conNTxtPaidDays = 2;
		private const int conNTxtUnPaidDays = 3;
		private const int conNTxtPaidHours = 4;
		private const int conNTxtTicketIssued = 5;
		private const int conNTxtTicketAmountCash = 6;
		private const int conNTxtTicketDiffInAmtBooked = 7;

		private const int conCmbPayType = 0;

		private bool mAllowExcessLeaveDays = false;
		private string mTimeStamp = "";
		private int mThisFormID = 0;
		private object mSearchValue = null;
		private SystemVariables.SystemFormModes mCurrentFormMode = (SystemVariables.SystemFormModes) 0;
		private SystemVariables.VoucherStatus mOldVoucherStatus = (SystemVariables.VoucherStatus) 0;
		int mCalendarCd = 0;
		bool mFocusTextbox = false;
		public int mEmpType = 0;
		bool mIsPayClosed = false;
		int mTemplateEntID = 0;
		private frmPayLeaveAmount _frmLeaveAmount = null;
		frmPayLeaveAmount frmLeaveAmount
		{
			get
			{
				if (_frmLeaveAmount is null)
				{
					_frmLeaveAmount = frmPayLeaveAmount.CreateInstance();
				}
				return _frmLeaveAmount;
			}
			set
			{
				_frmLeaveAmount = value;
			}
		}


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



		private void cmdLeaveAmount_Click(Object eventSender, EventArgs eventArgs)
		{
			//UPGRADE_WARNING: (1068) txtCommonDate().Value of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			frmLeaveAmount.mFromDate = ReflectionHelper.GetPrimitiveValue<string>(txtCommonDate[conDTxtLeaveFromDate].Value);
			frmLeaveAmount.mSearchValue = SystemHRProcedure.GetEmpCd(txtCommonTextBox[conTxtEmpCode].Text);
			//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			frmLeaveAmount.mLeaveCd = ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetMasterCode("select leave_cd from pay_leave where leave_no=" + txtCommonTextBox[conTxtLeaveCode].Text));
			//UPGRADE_WARNING: (1068) txtCommonNumber().Value of type Variant is being forced to double. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			frmLeaveAmount.mPaidDays = ReflectionHelper.GetPrimitiveValue<double>(txtCommonNumber[conNTxtPaidDays].Value);
			frmLeaveAmount.mCalltype = 1;
			if (SystemProcedure2.IsItEmpty(mSearchValue, SystemVariables.DataType.NumberType) && ReflectionHelper.GetPrimitiveValue<string>(mSearchValue) != "")
			{
				//UPGRADE_WARNING: (1068) mSearchValue of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				frmLeaveAmount.mLeaveEntID = ReflectionHelper.GetPrimitiveValue<int>(mSearchValue);
			}
			else
			{
				frmLeaveAmount.mLeaveEntID = 0;
			}
			frmLeaveAmount.ShowDialog();
			double mLeaveAmountForLTD = frmLeaveAmount.mTotalLeaveAmount;
			txtDisplayLabel[conDlblLeaveAmount].Text = mLeaveAmountForLTD.ToString();

		}

		private void cmdSubmmitApproval_Click(Object eventSender, EventArgs eventArgs)
		{
			DialogResult ans = (DialogResult) 0;
			if (CurrentFormMode == SystemVariables.SystemFormModes.frmAddMode)
			{
				ans = MessageBox.Show("Do you want to save this record!!!", "Save", MessageBoxButtons.YesNo);
				if (ans == System.Windows.Forms.DialogResult.Yes)
				{
					if (saveRecord())
					{
						SystemHRProcedure.ApprovalSubmmit(ReflectionHelper.GetPrimitiveValue<int>(mSearchValue), 1, mTemplateEntID, "Leave Transaction For Emp No :" + txtCommonTextBox[conTxtEmpCode].Text);
						AddRecord();
						MessageBox.Show("Approval Submitted Successfully::", "Approval", MessageBoxButtons.OK, MessageBoxIcon.Information);
					}
				}
			}
			else
			{
				if (SystemHRProcedure.CheckApprovalIsSubmmited(1, ReflectionHelper.GetPrimitiveValue<int>(mSearchValue)))
				{
					if (saveRecord())
					{
						SystemHRProcedure.ApprovalSubmmit(ReflectionHelper.GetPrimitiveValue<int>(mSearchValue), 1, mTemplateEntID, "Leave Transaction For Emp No :" + txtCommonTextBox[conTxtEmpCode].Text);
						AddRecord();
						MessageBox.Show("Approval Submitted Successfully::", "Approval", MessageBoxButtons.OK, MessageBoxIcon.Information);
					}
				}
				else
				{
					MessageBox.Show("Already Submitted for this record:", "Approval", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
			}
		}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2080
		private void Form_Load()
		{
			mFocusTextbox = true; // to enable txtcommontextbo change event
			FirstFocusObject = txtCommonTextBox[conTXTReferenceNo];

			try
			{

				this.CurrentFormMode = SystemVariables.SystemFormModes.frmAddMode;
				mOldVoucherStatus = SystemVariables.VoucherStatus.stActive;
				this.Top = 0;
				this.Left = 0;


				//**--format & define the new toolbar
				oThisFormToolBar = new clsToolbar();
				oThisFormToolBar.AttachObject(this); //, tcbSystemForm

				oThisFormToolBar.ShowNewButton = true;
				oThisFormToolBar.ShowSaveButton = true;
				oThisFormToolBar.ShowDeleteButton = true;
				oThisFormToolBar.ShowPrintButton = true;
				oThisFormToolBar.ShowFindButton = true;
				oThisFormToolBar.ShowHelpButton = true;
				oThisFormToolBar.ShowPostButton = true;
				oThisFormToolBar.ShowExitButton = true;
				oThisFormToolBar.BeginExitButtonWithGroup = true;
				oThisFormToolBar.ShowUnpostButton = true;
				oThisFormToolBar.DisableHelpButton = true;

				this.WindowState = FormWindowState.Maximized;

				//UPGRADE_WARNING: (1068) GetSystemPreferenceSetting() of type Variant is being forced to bool. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				this.tbleave.Item(conTabOtherDetails).Visible = ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("enable_ticket"));
				this.tbleave.Item(contabApproval).Visible = SystemHRProcedure.IsApprovalEnabled(1);

				//'Assign the Image for the toolbar
				//'Imagelist are kept on the main form and refered by their key
				//Call DrawToolbar(Me, picFormToolbar, btnFormToolBar(0))
				//Set btnFormToolBar(0).Picture = frmSysMain.imlMainToolBar.ListImages("imgNew").Picture
				//Set btnFormToolBar(1).Picture = frmSysMain.imlMainToolBar.ListImages("imgSave").Picture
				//Set btnFormToolBar(2).Picture = frmSysMain.imlMainToolBar.ListImages("imgDelete").Picture
				//Set btnFormToolBar(3).Picture = frmSysMain.imlMainToolBar.ListImages("imgPrint").Picture
				//Set btnFormToolBar(4).Picture = frmSysMain.imlMainToolBar.ListImages("imgFind").Picture
				//Set btnFormToolBar(5).Picture = frmSysMain.imlMainToolBar.ListImages("imgHelp").Picture
				//Set btnFormToolBar(6).Picture = frmSysMain.imlMainToolBar.ListImages("imgExit").Picture
				//Set btnFormToolBar(7).Picture = frmSysMain.imlSystemIcons.ListImages("imgPostingTransactions").Picture

				SystemProcedure.SetLabelCaption(this);

				//assign a next code
				txtCommonTextBox[conTxtVoucherNo].Text = SystemProcedure2.GetNewNumber("pay_leave_transaction", "voucher_no");


				txtCommonDate[conDTxtVoucheDate].Value = DateTime.Today;
				txtCommonDate[conDTxtLeaveFromDate].Value = DateTime.Today;
				txtCommonDate[conDTxtLeaveToDate].Value = DateTime.Today;
				txtCommonDate[conDTxtTicketIssuedUptoDate].Value = DateTime.Today;
				txtCommonDate[conDTxtLastLeaveStartDate].Text = "";
				txtCommonDate[conDTxtLastLeaveEndDate].Text = "";
				txtDisplayLabel[conDlblLastLeavePaidDays].Alignment = HorizontalAlignment.Right;

				object[] mObjectId = new object[1];
				mObjectId[conCmbPayType] = 1011;
				this.tbleave.SelectedItem = conTabLeaveDetails;

				SystemCombo.FillComboWithSystemObjects(CmbCommon, mObjectId);
				CmbCommon[0].ListIndex = 1;
				CmbCommon[0].Enabled = false;
				mIsPayClosed = false;
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
				//On Keydown navigate the form by using enter key
				if (KeyCode == 13)
				{ //If enter key pressed send a tab key
					SendKeys.Send("{TAB}");
					return;
				}
				if (this.ActiveControl.Name == "txtCommonTextBox")
				{
					SystemForms.SystemFormKeyDown(this, ref KeyCode, Shift, "txtCommonTextBox#" + ControlArrayHelper.GetControlIndex(this.ActiveControl).ToString().Trim());
				}
				else
				{
					SystemForms.SystemFormKeyDown(this, ref KeyCode, Shift, this.ActiveControl.Name);
				}
			}
			finally
			{
				eventArgs.Handled = KeyCode == 0;
			}
		}

		public void AddRecord()
		{
			//Add a record
			//mCheck = False
			txtCommonNumber[conNTxtUnPaidDays].Value = 0;
			SystemProcedure2.ClearTextBox(this);
			SystemProcedure2.ClearNumberBox(this);

			txtCommonTextBox[conTxtVoucherNo].Text = SystemProcedure2.GetNewNumber("pay_leave_transaction", "voucher_no");

			txtCommonDate[conDTxtVoucheDate].Value = DateTime.Today;
			txtCommonDate[conDTxtLeaveFromDate].Value = DateTime.Today;
			txtCommonDate[conDTxtLeaveToDate].Value = DateTime.Today;
			txtCommonDate[conDTxtLeaveFromDate].Tag = "";
			txtCommonDate[conDTxtLeaveToDate].Tag = "";
			txtCommonDate[conDTxtLastLeaveStartDate].Text = "";
			txtCommonDate[conDTxtLastLeaveEndDate].Text = "";
			txtCommonNumber[conNTxtActualLeaveDays].Value = 0;
			txtCommonTextBox[conTxtEmpCode].Enabled = true;
			txtCommonTextBox[conTxtLeaveCode].Enabled = true;

			txtCommonDate[conDTxtLeaveFromDate].Enabled = true;
			txtCommonDate[conDTxtLeaveToDate].Enabled = true;
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (Convert.IsDBNull(frmLeaveAmount))
			{
				if (ReflectionHelper.GetMember<double>(Application.OpenForms[frmLeaveAmount.Name], "CurrentView") != 0)
				{
					frmLeaveAmount.Close();
					frmLeaveAmount = null;
					frmLeaveAmount = frmPayLeaveAmount.CreateInstance();
				}
			}
			chkLoanGenrate.CheckState = CheckState.Unchecked;
			frmLeaveAmount = null;
			frmLeaveAmount = frmPayLeaveAmount.CreateInstance();

			this.tbleave.SelectedItem = conTabLeaveDetails;
			mCurrentFormMode = SystemVariables.SystemFormModes.frmAddMode; //Change the form mode to addmode
			mSearchValue = ""; //Change the msearchvalue to blank
			mEmpType = 0;
			FirstFocusObject.Focus();
			mOldVoucherStatus = SystemVariables.VoucherStatus.stActive;
			mAllowExcessLeaveDays = false;
			cmdLeaveAmount.Visible = false;
			mIsPayClosed = false;
			mFocusTextbox = true;
			//mCheck = True
			return;

			//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
			SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, Information.Err().Description, this.Name, "AddRecord");
		}

		public bool saveRecord(bool pApprove = false)
		{
			bool result = false;
			int mEmpCode = 0;
			int mLeaveCode = 0;
			decimal mLeaveSalary = 0;
			decimal mTotalSalary = 0;
			System.DateTime mLeaveStartDate = DateTime.FromOADate(0);

			//On Error GoTo eFoundError

			string mysql = "select pemp.emp_cd , pleave.leave_cd ";
			mysql = mysql + " , dbo.paygetleavesalary(pemp.emp_cd,pleave.leave_cd) ";
			mysql = mysql + " , pemp.total_salary";
			mysql = mysql + " from pay_employee_leave_details peld ";
			mysql = mysql + " inner join pay_employee pemp on pemp.emp_cd = peld.emp_cd ";
			mysql = mysql + " inner join pay_leave pleave on peld.leave_cd = pleave.leave_cd ";
			mysql = mysql + " where ";
			mysql = mysql + " emp_no ='" + txtCommonTextBox[conTxtEmpCode].Text + "'";
			mysql = mysql + " and leave_no = " + txtCommonTextBox[conTxtLeaveCode].Text;

			//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (Convert.IsDBNull(mReturnValue))
			{
				MessageBox.Show("Invalid Employee Code", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
				result = false;
				txtCommonTextBox[conTxtEmpCode].Focus();
				return result;
			}
			else
			{
				//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mEmpCode = ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue).GetValue(0));
				//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mLeaveCode = ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue).GetValue(1));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				mLeaveSalary = (Convert.IsDBNull(((Array) mReturnValue).GetValue(2))) ? 0 : ReflectionHelper.GetPrimitiveValue<decimal>(((Array) mReturnValue).GetValue(2));
				//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to decimal. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mTotalSalary = ReflectionHelper.GetPrimitiveValue<decimal>(((Array) mReturnValue).GetValue(3));
			}

			mysql = " select count(*) from pay_leave_transaction where status = 1 ";
			if (CurrentFormMode == SystemVariables.SystemFormModes.frmEditMode)
			{
				mysql = mysql + " and entry_id <> " + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
			}
			mysql = mysql + " And emp_cd = " + mEmpCode.ToString();

			//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
			if (ReflectionHelper.GetPrimitiveValue<double>(mReturnValue) > 0)
			{ // Check whether an unposted transaction already exists for the employee
				MessageBox.Show("An Unposted transaction for the employee already exists!!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
				return false;
			}
			//'' as on  28-Apr-2010
			mysql = "select voucher_no from pay_leave_transaction";
			mysql = mysql + " where emp_cd = " + mEmpCode.ToString() + " and leave_amount_payment_type_id =  53  and is_pay_closed = 0";
			//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(mReturnValue))
			{
				if (CmbCommon[conCmbPayType].GetItemData(CmbCommon[conCmbPayType].ListIndex) == 53 && ReflectionHelper.GetPrimitiveValue<string>(mReturnValue) != txtCommonTextBox[conTxtVoucherNo].Text)
				{
					MessageBox.Show("One Employee can not have more then one pay now transaction in same month.!!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					return false;
				}
			}

			//'' as on 08-July-2008
			//''Desc: For Enter Leave For Previous date also

			//mySql = " select max(leave_end_date) from pay_leave_transaction "
			//mySql = mySql & " where emp_cd =" & mEmpCode
			//If CurrentFormMode = frmEditMode Then
			//    mySql = mySql & " and entry_id <> " & mSearchValue
			//End If
			//If CurrentFormMode = frmEditMode Then
			//    mySql = mySql & " and entry_id <> " & mSearchValue
			//End If
			//mReturnValue = GetMasterCode(mySql)
			//If Not IsNull(mReturnValue) Then
			//    If CDate(txtCommonDate(conDTxtLeaveFromDate).DisplayText) <= CDate(mReturnValue) Then
			//        MsgBox " From Date should be greater than last Leave Date i.e. " & Format(mReturnValue, gSystemDateFormat)
			//        saveRecord = False
			//        txtCommonDate(conDTxtLeaveFromDate).SetFocus
			//        Exit Function
			//    End If
			//End If

			//''End

			//''commented by hakim on 26-dec-2006
			//'''From date cannot be greater than generate date
			//mySql = " select max(generate_date) from Pay_Payroll_Generate_History "
			//mReturnValue = GetMasterCode(mySql)
			//If Not IsNull(mReturnValue) Then
			//    If CDate(txtCommonDate(conDTxtLeaveFromDate).DisplayText) > CDate(mReturnValue) Then
			//        MsgBox " From Date cannot be greater than Generate Date i.e. " & Format(mReturnValue, gSystemDateFormat)
			//        saveRecord = False
			//        txtCommonDate(conDTxtLeaveFromDate).SetFocus
			//        Exit Function
			//    End If
			//End If

			SystemVariables.gConn.BeginTransaction();
			string mCheckTimeStamp = "";
			if (mCurrentFormMode == SystemVariables.SystemFormModes.frmAddMode)
			{
				txtCommonTextBox[conTxtVoucherNo].Text = SystemProcedure2.GetNewNumber("pay_leave_transaction", "voucher_no");
				mysql = " insert into pay_leave_transaction ";
				mysql = mysql + " (emp_cd, dept_cd, desg_cd, comp_cd, curr_cd, voucher_no ";
				mysql = mysql + " , voucher_date, reference_no ";
				mysql = mysql + " , leave_salary, total_salary, leave_start_date, leave_end_date";
				mysql = mysql + " , leave_days, actual_leave_days, leave_balance_days, paid_days";
				mysql = mysql + " , unpaid_days, leave_salary_amount,holiday_amount, leave_amount_payment_type_id";
				mysql = mysql + " , last_salary_date";
				mysql = mysql + " , bank_cd, bank_branch_cd, bank_account_no, rate_calc_method_id";
				mysql = mysql + " , payment_type_id ";
				mysql = mysql + " , weekend, weekend_day1_id, weekend_day2_id ";
				mysql = mysql + " , days_per_month , hours_per_day ";
				mysql = mysql + " , opening_paid_leave_balance_date";
				mysql = mysql + " , opening_paid_leave_balance_days ";
				mysql = mysql + " , leave_cd, leave_switch_over_period, leave_days_before_sop ";
				mysql = mysql + " , leave_days_after_sop ,working_days_per_month_before_sop";
				mysql = mysql + " , working_days_per_month_after_sop, deduct_paid_days ";
				mysql = mysql + " , deduct_unpaid_days , paid_leave_taken_days ";
				//' Date 04-Nov-2008 For Ticket,Modify 01-Dec-2008  for Save Leave History
				mysql = mysql + " ,last_leave_start_date, last_leave_end_date, last_leave_taken_days";
				mysql = mysql + " , ticket_balance , ticket_issued , ticket_amount, ticket_pay_by_cash ";
				mysql = mysql + " , ticket_issued_upto, ticket_destination_entitled_entry_id, ticket_destination_issued_entry_id, ticket_booked_diff_in_amt ";
				//End
				//added by burhan. Date:12-jun-2008
				mysql = mysql + " , paid_hours ";
				mysql = mysql + " , Public_Holidays, actual_resume_date ";
				//end
				//' added by Burhan Ghee Wala
				//' Date: 27-Nov-2007
				//' Desc: Added payroll_date so that it can be found out in which month the transaction was save
				//'       or posted
				//mySql = mySql & " , comments, user_cd )" ' old
				mysql = mysql + " , comments, payroll_date , processDate , template_entry_id , Regenerate_Loan ,user_cd )"; // replaced
				//' end

				mysql = mysql + " select pemp.emp_cd, pemp.dept_cd, pemp.desg_cd, pemp.comp_cd";
				mysql = mysql + " , pemp.curr_cd";
				mysql = mysql + " , " + txtCommonTextBox[conTxtVoucherNo].Text;
				mysql = mysql + " , '" + ReflectionHelper.GetPrimitiveValue<string>(txtCommonDate[conDTxtVoucheDate].DisplayText) + "'";
				mysql = mysql + " , '" + txtCommonTextBox[conTXTReferenceNo].Text + "'";
				mysql = mysql + " , " + mLeaveSalary.ToString();
				mysql = mysql + " , " + mTotalSalary.ToString();
				mysql = mysql + " , '" + ReflectionHelper.GetPrimitiveValue<string>(txtCommonDate[conDTxtLeaveFromDate].DisplayText) + "'";
				mysql = mysql + " , '" + ReflectionHelper.GetPrimitiveValue<string>(txtCommonDate[conDTxtLeaveToDate].DisplayText) + "'";
				mysql = mysql + " , " + ReflectionHelper.GetPrimitiveValue<string>(txtCommonNumber[conNTxtLeaveDays].Value);
				mysql = mysql + " , " + ReflectionHelper.GetPrimitiveValue<string>(txtCommonNumber[conNTxtActualLeaveDays].Value);
				if (SystemProcedure2.IsItEmpty(txtDisplayLabel[conDlblLeaveBalanceDays].Text, SystemVariables.DataType.StringType))
				{
					mysql = mysql + " , 0";
				}
				else
				{
					mysql = mysql + " , " + StringsHelper.Format(txtDisplayLabel[conDlblLeaveBalanceDays].Text, "########0.000");
				}
				mysql = mysql + " , " + ReflectionHelper.GetPrimitiveValue<string>(txtCommonNumber[conNTxtPaidDays].Value);
				mysql = mysql + " , " + ReflectionHelper.GetPrimitiveValue<string>(txtCommonNumber[conNTxtUnPaidDays].Value);

				if (SystemProcedure2.IsItEmpty(txtDisplayLabel[conDlblLeaveAmount].Text, SystemVariables.DataType.StringType))
				{
					mysql = mysql + " , 0 ";
				}
				else
				{
					mysql = mysql + " , " + StringsHelper.Format(txtDisplayLabel[conDlblLeaveAmount].Text, "########0.000");
				}
				//''  on 16-Jun-2009 for Holiday Amount Save
				if (SystemProcedure2.IsItEmpty(txtDisplayLabel[conDlblHolidayAmount].Text, SystemVariables.DataType.StringType))
				{
					mysql = mysql + " , 0 ";
				}
				else
				{
					mysql = mysql + " , " + StringsHelper.Format(txtDisplayLabel[conDlblHolidayAmount].Text, "########0.000");
				}
				//''End
				mysql = mysql + " , " + CmbCommon[conCmbPayType].GetItemData(CmbCommon[conCmbPayType].ListIndex).ToString();

				mysql = mysql + " , pemp.last_salary_date ";
				mysql = mysql + " , pemp.bank_cd, pemp.bank_branch_cd ";
				mysql = mysql + " , pemp.bank_account_no, pemp.rate_calc_method_id ";
				mysql = mysql + " , pemp.payment_type_id ";
				mysql = mysql + " , pemp.weekend, pemp.weekend_day1_id, pemp.weekend_day2_id ";
				mysql = mysql + " , pemp.days_per_month, pemp.hours_per_day ";
				mysql = mysql + " , peld.opening_paid_leave_balance_date ";
				mysql = mysql + " , peld.opening_paid_leave_balance_days ";
				mysql = mysql + " , peld.leave_cd , peld.leave_switch_over_period ";
				mysql = mysql + " , peld.leave_days_before_sop, peld.leave_days_after_sop ";
				mysql = mysql + " , peld.working_days_per_month_before_sop ";
				mysql = mysql + " , peld.working_days_per_month_after_sop ";
				mysql = mysql + " , peld.deduct_paid_days, peld.deduct_unpaid_days ";
				mysql = mysql + " , peld.paid_leave_taken_days ";
				//' Date 04-Nov-2008 For Ticket
				if (Information.IsDate(txtCommonDate[conDTxtLastLeaveStartDate].Value))
				{
					mysql = mysql + " ,'" + ReflectionHelper.GetPrimitiveValue<string>(txtCommonDate[conDTxtLastLeaveStartDate].Value) + "'";
				}
				else
				{
					mysql = mysql + " ,Null";
				}
				if (Information.IsDate(txtCommonDate[conDTxtLastLeaveEndDate].Value))
				{
					mysql = mysql + " ,'" + ReflectionHelper.GetPrimitiveValue<string>(txtCommonDate[conDTxtLastLeaveEndDate].Value) + "'";
				}
				else
				{
					mysql = mysql + " ,Null";
				}

				if (!SystemProcedure2.IsItEmpty(txtDisplayLabel[conDlblLastLeavePaidDays].Text, SystemVariables.DataType.NumberType))
				{
					mysql = mysql + " ," + txtDisplayLabel[conDlblLastLeavePaidDays].Text;
				}
				else
				{
					mysql = mysql + " ,null";
				}

				if (SystemProcedure2.IsItEmpty(txtDisplayLabel[conDlblTicketBalance].Text, SystemVariables.DataType.StringType))
				{
					mysql = mysql + " , 0 ";
				}
				else
				{
					mysql = mysql + " , " + StringsHelper.Format(txtDisplayLabel[conDlblTicketBalance].Text, "########0.000");
				}
				mysql = mysql + " , " + ReflectionHelper.GetPrimitiveValue<string>(txtCommonNumber[conNTxtTicketIssued].Value);

				mysql = mysql + " , " + ReflectionHelper.GetPrimitiveValue<string>(txtCommonNumber[conNTxtTicketAmountCash].Value);

				if (OptCashOrBooked[conChkTicketCash].Checked)
				{
					//''Cash
					mysql = mysql + " , 1 ";
				}
				else
				{
					//'''Booked
					mysql = mysql + " , 0 ";
				}

				if (Information.IsDate(txtCommonDate[conDTxtTicketIssuedUptoDate].Value))
				{
					mysql = mysql + " , '" + ReflectionHelper.GetPrimitiveValue<string>(txtCommonDate[conDTxtTicketIssuedUptoDate].DisplayText) + "'";
				}
				else
				{
					mysql = mysql + " , '" + ReflectionHelper.GetPrimitiveValue<string>(txtCommonDate[conDTxtLeaveFromDate].DisplayText) + "'";
				}

				if (!SystemProcedure2.IsItEmpty(Convert.ToString(txtCommonTextBox[conTxtTicketEntitledDest].Tag), SystemVariables.DataType.NumberType))
				{
					mysql = mysql + " , " + Convert.ToString(txtCommonTextBox[conTxtTicketEntitledDest].Tag);
				}
				else
				{
					mysql = mysql + " , NULL ";
				}

				if (!SystemProcedure2.IsItEmpty(Convert.ToString(txtCommonTextBox[conTxtTicketIssuedDest].Tag), SystemVariables.DataType.NumberType))
				{
					mysql = mysql + " , " + Convert.ToString(txtCommonTextBox[conTxtTicketIssuedDest].Tag);
				}
				else
				{
					mysql = mysql + " , NULL ";
				}
				mysql = mysql + " , " + ReflectionHelper.GetPrimitiveValue<string>(txtCommonNumber[conNTxtTicketDiffInAmtBooked].Value);
				//'End
				//added by Burhan. Date:12-jun-2008
				mysql = mysql + " , " + ReflectionHelper.GetPrimitiveValue<string>(txtCommonNumber[conNTxtPaidHours].Value);
				mysql = mysql + " , " + Conversion.Val(txtDisplayLabel[conDlblPublicHolidays].Text).ToString();
				mysql = mysql + " , '" + DateTimeHelper.ToString(ReflectionHelper.GetPrimitiveValue<System.DateTime>(txtCommonDate[conDTxtLeaveToDate].Value).AddDays(1)) + "'";
				//end
				mysql = mysql + " , N'" + txtCommonTextBox[conTxtComments].Text + "'";

				//' added by Burhan Ghee Wala
				//' Date: 27-Nov-2007
				//' Desc: Added payroll_date so that it can be found out in which month the transaction was save
				//'       or posted
				mysql = mysql + ",'" + SystemHRProcedure.GetPayrollGenerateDate() + "'"; // new line added
				//' end
				//'  Date:02-Jan-2012
				//' Desc: For Accrual Calculation
				//mySQL = mySQL & ",'" & txtCommonDate(conDTxtLeaveFromDate).Value & "'"
				if (ReflectionHelper.GetPrimitiveValue<System.DateTime>(txtCommonDate[conDTxtLeaveFromDate].Value) < DateTime.Parse(SystemHRProcedure.GetPayrollGenerateStartDate()))
				{
					mysql = mysql + ",'" + StringsHelper.Format(SystemHRProcedure.GetPayrollGenerateStartDate(), SystemVariables.gSystemDateFormat) + "'";
				}
				else if (ReflectionHelper.GetPrimitiveValue<System.DateTime>(txtCommonDate[conDTxtLeaveFromDate].Value) > DateTime.Parse(SystemHRProcedure.GetPayrollGenerateDate()))
				{ 
					mysql = mysql + ",'" + StringsHelper.Format(SystemHRProcedure.GetPayrollGenerateDate(), SystemVariables.gSystemDateFormat) + "'";
				}
				else
				{
					mysql = mysql + ",'" + ReflectionHelper.GetPrimitiveValue<string>(txtCommonDate[conDTxtLeaveFromDate].Value) + "'";
				}
				//'Added For Approval Entry ID  as on 03-dec-2009
				if (mTemplateEntID == 0)
				{
					mysql = mysql + ", NULL";
				}
				else
				{
					mysql = mysql + "," + mTemplateEntID.ToString();
				}
				//'END
				//' Add  On 11-Jul-2011 For Loan ReGenerate
				mysql = mysql + "," + ((int) chkLoanGenrate.CheckState).ToString();
				//' End
				mysql = mysql + " , " + SystemVariables.gLoggedInUserCode.ToString();
				mysql = mysql + " from pay_employee pemp ";
				mysql = mysql + " inner join pay_employee_leave_details peld ";
				mysql = mysql + " on pemp.emp_cd = peld.emp_cd ";
				mysql = mysql + " where pemp.emp_cd = " + mEmpCode.ToString();
				mysql = mysql + " and peld.leave_cd = " + mLeaveCode.ToString();

				SqlCommand TempCommand = null;
				TempCommand = SystemVariables.gConn.CreateCommand();
				TempCommand.CommandText = mysql;
				TempCommand.ExecuteNonQuery();
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode("select scope_identity()"));

			}
			else
			{
				mysql = " select time_stamp from pay_leave_transaction where entry_id =" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(mReturnValue))
				{
					//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mCheckTimeStamp = ReflectionHelper.GetPrimitiveValue<string>(mReturnValue);
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

				mysql = " update pay_leave_transaction set ";
				mysql = mysql + " voucher_no =" + txtCommonTextBox[conTxtVoucherNo].Text;
				mysql = mysql + " , voucher_date = '" + ReflectionHelper.GetPrimitiveValue<string>(txtCommonDate[conDTxtVoucheDate].DisplayText) + "'";
				mysql = mysql + " , reference_no ='" + txtCommonTextBox[conTXTReferenceNo].Text + "'";
				mysql = mysql + " , leave_start_date='" + ReflectionHelper.GetPrimitiveValue<string>(txtCommonDate[conDTxtLeaveFromDate].DisplayText) + "'";
				mysql = mysql + " , leave_end_date='" + ReflectionHelper.GetPrimitiveValue<string>(txtCommonDate[conDTxtLeaveToDate].DisplayText) + "'";
				mysql = mysql + " , leave_days =" + ReflectionHelper.GetPrimitiveValue<string>(txtCommonNumber[conNTxtLeaveDays].Value);
				mysql = mysql + " , actual_leave_days =" + ReflectionHelper.GetPrimitiveValue<string>(txtCommonNumber[conNTxtActualLeaveDays].Value);
				//Added by Burhan. Date:12-Jun-2008
				mysql = mysql + " , paid_hours =" + ReflectionHelper.GetPrimitiveValue<string>(txtCommonNumber[conNTxtPaidHours].Value);
				mysql = mysql + " , Public_Holidays =" + Conversion.Val(txtDisplayLabel[conDlblPublicHolidays].Text).ToString();
				mysql = mysql + " , actual_resume_date = '" + DateTimeHelper.ToString(ReflectionHelper.GetPrimitiveValue<System.DateTime>(txtCommonDate[conDTxtLeaveToDate].Value).AddDays(1)) + "'";
				//end
				if (SystemProcedure2.IsItEmpty(txtDisplayLabel[conDlblLeaveBalanceDays].Text, SystemVariables.DataType.StringType))
				{
					mysql = mysql + " , leave_balance_days = 0 ";
				}
				else
				{
					mysql = mysql + " , leave_balance_days = " + StringsHelper.Format(txtDisplayLabel[conDlblLeaveBalanceDays].Text, "##########0.000");
				}
				mysql = mysql + " , paid_days =" + ReflectionHelper.GetPrimitiveValue<string>(txtCommonNumber[conNTxtPaidDays].Value);
				mysql = mysql + " , unpaid_days =" + ReflectionHelper.GetPrimitiveValue<string>(txtCommonNumber[conNTxtUnPaidDays].Value);

				if (SystemProcedure2.IsItEmpty(txtDisplayLabel[conDlblLeaveAmount].Text, SystemVariables.DataType.StringType))
				{
					mysql = mysql + " , leave_salary_amount = 0 ";
				}
				else
				{
					mysql = mysql + " , leave_salary_amount = " + StringsHelper.Format(txtDisplayLabel[conDlblLeaveAmount].Text, "##########0.000");
				}
				//'' on 16-jun-2009 for holiday amount
				if (SystemProcedure2.IsItEmpty(txtDisplayLabel[conDlblHolidayAmount].Text, SystemVariables.DataType.StringType))
				{
					mysql = mysql + " , holiday_amount = 0 ";
				}
				else
				{
					mysql = mysql + " , holiday_amount = " + StringsHelper.Format(txtDisplayLabel[conDlblHolidayAmount].Text, "##########0.000");
				}
				//''End

				mysql = mysql + " , leave_amount_payment_type_id = " + CmbCommon[conCmbPayType].GetItemData(CmbCommon[conCmbPayType].ListIndex).ToString();

				mysql = mysql + " , comments = N'" + txtCommonTextBox[conTxtComments].Text + "'";
				//' Date 04-Nov-2008 For Ticket
				if (Information.IsDate(txtCommonDate[conDTxtLastLeaveStartDate].Value))
				{
					mysql = mysql + " , last_leave_start_date='" + ReflectionHelper.GetPrimitiveValue<string>(txtCommonDate[conDTxtLastLeaveStartDate].Value) + "'";
				}
				else
				{
					mysql = mysql + " , last_leave_start_date=Null";
				}
				if (Information.IsDate(txtCommonDate[conDTxtLastLeaveEndDate].Value))
				{
					mysql = mysql + " ,last_leave_end_date='" + ReflectionHelper.GetPrimitiveValue<string>(txtCommonDate[conDTxtLastLeaveEndDate].Value) + "'";
				}
				else
				{
					mysql = mysql + " ,last_leave_end_date=Null";
				}

				//    mySQL = mySQL & " ,last_leave_start_date='" & txtCommonDate(conDTxtLastLeaveStartDate).Value & "'"
				//    mySQL = mySQL & " ,last_leave_end_date= '" & txtCommonDate(conDTxtLastLeaveEndDate).Value & "'"
				if (!SystemProcedure2.IsItEmpty(txtDisplayLabel[conDlblLastLeavePaidDays].Text, SystemVariables.DataType.NumberType))
				{
					mysql = mysql + " ,last_leave_taken_days=" + txtDisplayLabel[conDlblLastLeavePaidDays].Text;
				}
				else
				{
					mysql = mysql + " ,last_leave_taken_days=null";
				}

				if (SystemProcedure2.IsItEmpty(txtDisplayLabel[conDlblTicketBalance].Text, SystemVariables.DataType.StringType))
				{
					mysql = mysql + " , ticket_balance = 0 ";
				}
				else
				{
					mysql = mysql + " , ticket_balance = " + StringsHelper.Format(txtDisplayLabel[conDlblTicketBalance].Text, "########0.000");
				}
				mysql = mysql + " , Ticket_Issued = " + ReflectionHelper.GetPrimitiveValue<string>(txtCommonNumber[conNTxtTicketIssued].Value);

				mysql = mysql + " , ticket_amount = " + ReflectionHelper.GetPrimitiveValue<string>(txtCommonNumber[conNTxtTicketAmountCash].Value);

				if (OptCashOrBooked[conChkTicketCash].Checked)
				{
					mysql = mysql + " , ticket_pay_by_cash = 1 ";
				}
				else
				{
					mysql = mysql + " , ticket_pay_by_cash = 0 ";
				}

				if (Information.IsDate(txtCommonDate[conDTxtTicketIssuedUptoDate].Value))
				{
					mysql = mysql + " , ticket_issued_upto ='" + ReflectionHelper.GetPrimitiveValue<string>(txtCommonDate[conDTxtTicketIssuedUptoDate].DisplayText) + "'";
				}
				else
				{
					mysql = mysql + " , ticket_issued_upto ='" + ReflectionHelper.GetPrimitiveValue<string>(txtCommonDate[conDTxtLastLeaveStartDate].DisplayText) + "'";
				}

				if (!SystemProcedure2.IsItEmpty(Convert.ToString(txtCommonTextBox[conTxtTicketEntitledDest].Tag), SystemVariables.DataType.NumberType))
				{
					mysql = mysql + " , ticket_destination_entitled_entry_id=" + Convert.ToString(txtCommonTextBox[conTxtTicketEntitledDest].Tag);
				}
				else
				{
					mysql = mysql + " , ticket_destination_entitled_entry_id = NULL";
				}

				if (!SystemProcedure2.IsItEmpty(Convert.ToString(txtCommonTextBox[conTxtTicketIssuedDest].Tag), SystemVariables.DataType.NumberType))
				{
					mysql = mysql + " , ticket_destination_issued_entry_id=" + Convert.ToString(txtCommonTextBox[conTxtTicketIssuedDest].Tag);
				}
				else
				{
					mysql = mysql + " , ticket_destination_issued_entry_id = NULL";
				}

				mysql = mysql + " , ticket_booked_diff_in_amt =" + ReflectionHelper.GetPrimitiveValue<string>(txtCommonNumber[conNTxtTicketDiffInAmtBooked].Value);

				//'End
				//' added by Burhan Ghee Wala
				//' Date: 27-Nov-2007
				//' Desc: Added payroll_date so that it can be found out in which month the transaction was save
				//'       or posted
				mysql = mysql + " , payroll_date ='" + SystemHRProcedure.GetPayrollGenerateDate() + "'";
				//' end add
				//'  ali date:02-Dec-2012
				//' Desc: For Accrual Calculation
				if (ReflectionHelper.GetPrimitiveValue<System.DateTime>(txtCommonDate[conDTxtLeaveFromDate].Value) < DateTime.Parse(SystemHRProcedure.GetPayrollGenerateStartDate()))
				{
					mysql = mysql + ", processDate = '" + StringsHelper.Format(SystemHRProcedure.GetPayrollGenerateStartDate(), SystemVariables.gSystemDateFormat) + "'";
				}
				else if (ReflectionHelper.GetPrimitiveValue<System.DateTime>(txtCommonDate[conDTxtLeaveFromDate].Value) > DateTime.Parse(SystemHRProcedure.GetPayrollGenerateDate()))
				{ 
					mysql = mysql + ", processDate = '" + StringsHelper.Format(SystemHRProcedure.GetPayrollGenerateDate(), SystemVariables.gSystemDateFormat) + "'";
				}
				else
				{
					mysql = mysql + ", processDate = '" + ReflectionHelper.GetPrimitiveValue<string>(txtCommonDate[conDTxtLeaveFromDate].Value) + "'";
				}

				//'Added For Approval Entry ID  as on 03-dec-2009
				if (mTemplateEntID == 0)
				{
					mysql = mysql + ",template_entry_id =  NULL";
				}
				else
				{
					mysql = mysql + ",template_entry_id = " + mTemplateEntID.ToString();
				}
				//'END
				mysql = mysql + " , Regenerate_Loan = " + ((int) chkLoanGenrate.CheckState).ToString();
				mysql = mysql + " , user_cd =" + Conversion.Str(SystemVariables.gLoggedInUserCode);
				mysql = mysql + " , user_date_time = '" + DateTimeHelper.ToString(DateTime.Today) + "'";
				mysql = mysql + " where entry_id=" + Conversion.Str(mSearchValue);
				SqlCommand TempCommand_2 = null;
				TempCommand_2 = SystemVariables.gConn.CreateCommand();
				TempCommand_2.CommandText = mysql;
				TempCommand_2.ExecuteNonQuery();
			}

			mysql = " delete from pay_leave_employee_contract_details where leave_entry_id =" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
			SqlCommand TempCommand_3 = null;
			TempCommand_3 = SystemVariables.gConn.CreateCommand();
			TempCommand_3.CommandText = mysql;
			TempCommand_3.ExecuteNonQuery();
			int cnt = 0;
			int tempForEndVar = frmLeaveAmount.aVoucherDetails.GetLength(0) - 1;
			for (cnt = 0; cnt <= tempForEndVar; cnt++)
			{
				mysql = mysql + "insert into pay_leave_employee_contract_details(Leave_Entry_Id,emp_Contract_Entry_Id,Leave_Days_Taken,leave_Days_Amount)";
				mysql = mysql + " values(" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
				mysql = mysql + " , " + Convert.ToString(frmLeaveAmount.aVoucherDetails.GetValue(cnt, 0)); //For Entry ID
				mysql = mysql + " ," + Convert.ToString(frmLeaveAmount.aVoucherDetails.GetValue(cnt, 5)); //For Leave Days Taken
				mysql = mysql + " ," + Convert.ToString(frmLeaveAmount.aVoucherDetails.GetValue(cnt, 6)); //For Leave Days Amount
				mysql = mysql + ")";
				SqlCommand TempCommand_4 = null;
				TempCommand_4 = SystemVariables.gConn.CreateCommand();
				TempCommand_4.CommandText = mysql;
				TempCommand_4.ExecuteNonQuery();
			}

			if (pApprove)
			{
				if (!SystemHRProcedure.GetTransactionApprovalStage(1, ReflectionHelper.GetPrimitiveValue<int>(mSearchValue), 2))
				{
					MessageBox.Show("Record cannot be posted", "Approval", MessageBoxButtons.OK, MessageBoxIcon.Information);
					//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.CommitTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					SystemVariables.gConn.CommitTrans();
					return result;
				}
				SystemHRProcedure.PayPostToHR("Pay_leave_transaction", ReflectionHelper.GetPrimitiveValue<int>(mSearchValue));
				SystemHRProcedure.PayApprove("Pay_leave_transaction", ReflectionHelper.GetPrimitiveValue<int>(mSearchValue));
				Post_Leave_Transaction(mSearchValue);
			}


			//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.CommitTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			SystemVariables.gConn.CommitTrans();
			//''modified by hakin on 21-may-2009
			SystemProcedure.InsertAlarmDetails(1, ReflectionHelper.GetPrimitiveValue<int>(mSearchValue), txtCommonTextBox[conTxtComments].Text, ReflectionHelper.GetPrimitiveValue<string>(txtCommonDate[conDTxtLeaveFromDate].Value));
			//Call InsertAlarmDetails(1, CLng(mSearchValue), txtCommonTextBox(conTxtComments).Text, txtCommonDate(conDTxtLeaveToDate).Value)
			result = true;
			FirstFocusObject.Focus();
			return result;


			//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
			int mReturnErrorType = SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, Information.Err().Description, this.Name, "GetRecord", SystemConstants.msg10);
			//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			SystemVariables.gConn.RollbackTrans();
			return false;
		}

		public bool deleteRecord()
		{
			bool result = false;

			if (mOldVoucherStatus != SystemVariables.VoucherStatus.stActive)
			{
				SystemProcedure2.VoucherStatusErrorMessage(mOldVoucherStatus, 1);
				result = false;
				if (ControlHelper.GetEnabled(FirstFocusObject))
				{
					FirstFocusObject.Focus();
				}
				return result;
			}

			if (!SystemHRProcedure.GetTransactionApprovalStage(1, ReflectionHelper.GetPrimitiveValue<int>(mSearchValue), 1))
			{
				MessageBox.Show("Record cannot be deleted.", "Approval", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return result;
			}

			SystemVariables.gConn.BeginTransaction();

			string mysql = " update pay_employee ";
			mysql = mysql + " set status_cd = 1 ";
			mysql = mysql + " from pay_employee pemp inner join pay_leave_transaction plt ";
			mysql = mysql + " on pemp.emp_cd = plt.emp_cd ";
			mysql = mysql + " where plt.entry_id=" + Conversion.Str(mSearchValue);
			SqlCommand TempCommand = null;
			TempCommand = SystemVariables.gConn.CreateCommand();
			TempCommand.CommandText = mysql;
			TempCommand.ExecuteNonQuery();

			mysql = "delete from Pay_Leave_Transacrion_Payroll_Details where leave_entry_id =" + Conversion.Str(mSearchValue);
			SqlCommand TempCommand_2 = null;
			TempCommand_2 = SystemVariables.gConn.CreateCommand();
			TempCommand_2.CommandText = mysql;
			TempCommand_2.ExecuteNonQuery();

			mysql = "delete from pay_leave_transaction  where entry_id=" + Conversion.Str(mSearchValue);
			SqlCommand TempCommand_3 = null;
			TempCommand_3 = SystemVariables.gConn.CreateCommand();
			TempCommand_3.CommandText = mysql;
			TempCommand_3.ExecuteNonQuery();

			//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.CommitTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			SystemVariables.gConn.CommitTrans();
			SystemProcedure.AlarmDelete(1, ReflectionHelper.GetPrimitiveValue<int>(mSearchValue));


			return true;

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
			mFocusTextbox = false; // to disable txtcommontextbo change event
			//This routine is called after getting the value from Find window or
			//refreshing the recordset during any error of updating or deleting

			//On Error GoTo eFoundError

			FirstFocusObject.Focus();
			Application.DoEvents();
			//'Added By Burhan Ghee Wala
			//'Date: 05-Nov-2007
			//'Desc: due to actual leave day textbox have change event so that

			txtCommonNumber[conNTxtPaidDays].Value = 0;
			txtCommonNumber[conNTxtUnPaidDays].Value = 0;
			txtCommonNumber[conNTxtActualLeaveDays].Value = 0;

			string mysql = " select plt.* ";
			mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "isnull(l_first_name,'') + ' ' + isnull(l_second_name,'') + ' ' + isnull(l_third_name,'') + ' ' + isnull(l_fourth_name,'')" : "isnull(a_first_name,'') + ' ' + isnull(a_second_name,'') + ' ' + isnull(a_third_name,'') + ' ' + isnull(a_fourth_name,'')") + " as emp_name ";
			mysql = mysql + " , emp_no , plt.weekend , plt.weekend_day1_id, plt.weekend_day2_id ";
			mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_dept_name" : "a_dept_name") + " as dept_name ";
			mysql = mysql + " , dept_no ";
			mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_desg_name" : "a_desg_name") + " as desg_name ";
			mysql = mysql + " , desg_no ";
			mysql = mysql + " , dbo.paygetleavesalary(plt.emp_cd, plt.leave_cd) as leave_salary, pemp.total_salary ";
			mysql = mysql + " , leave_no ";
			mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_leave_name" : "a_leave_name") + " as leave_name ";
			mysql = mysql + " , pltype.allow_excess_leave_days , pleave.include_weekend,pemp.emp_type_id ";
			mysql = mysql + " , isnull(ptd.l_ticket_destination,'') as ticket_entitled_destination ";
			mysql = mysql + " , isnull(ptd.entry_id,0) as ticket_entitled_destination_id ";
			mysql = mysql + " , isnull(ptd1.l_ticket_destination,'') as ticket_issued_destination ";
			mysql = mysql + " , isnull(ptd1.entry_id,0) as ticket_issued_destination_id ";
			mysql = mysql + " , sat.trans_no, sat.l_approval_name , pemp.date_of_joining, pemp.Calendar_cd ";
			mysql = mysql + " from pay_leave_transaction plt ";
			mysql = mysql + " inner join pay_employee pemp on plt.emp_cd = pemp.emp_cd ";
			mysql = mysql + " inner join pay_leave pleave on plt.leave_cd = pleave.leave_cd ";
			mysql = mysql + " inner join pay_department pdept on  plt.dept_cd = pdept.dept_cd ";
			mysql = mysql + " inner join pay_designation pdesg on  plt.desg_cd = pdesg.desg_cd  ";
			mysql = mysql + " inner join pay_leave_type pltype on pleave.leave_type_cd = pltype.type_cd ";
			mysql = mysql + " left outer join sys_approval_template sat on plt.template_entry_id = sat.entry_id";
			mysql = mysql + " left outer join pay_ticket_destination ptd on plt.ticket_destination_entitled_entry_id = ptd.entry_id ";
			mysql = mysql + " left outer join pay_ticket_destination ptd1 on plt.ticket_destination_issued_entry_id = ptd1.entry_id ";
			mysql = mysql + " where plt.entry_id = " + ReflectionHelper.GetPrimitiveValue<string>(SearchValue);


			DataSet localRec = new DataSet();
			SqlDataAdapter adap = new SqlDataAdapter(mysql, SystemVariables.gConn);
			localRec.Tables.Clear();
			adap.Fill(localRec);
			if (localRec.Tables[0].Rows.Count != 0)
			{
				//UPGRADE_WARNING: (1068) SearchValue of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mSearchValue = ReflectionHelper.GetPrimitiveValue(SearchValue);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				mTimeStamp = Convert.ToString(localRec.Tables[0].Rows[0]["time_stamp"]);

				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				mAllowExcessLeaveDays = Convert.ToBoolean(localRec.Tables[0].Rows[0]["allow_excess_leave_days"]);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtCommonTextBox[conTxtVoucherNo].Text = Convert.ToString(localRec.Tables[0].Rows[0]["voucher_no"]);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtCommonDate[conDTxtVoucheDate].Value = localRec.Tables[0].Rows[0]["voucher_date"];
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtCommonTextBox[conTXTReferenceNo].Text = Convert.ToString(localRec.Tables[0].Rows[0]["reference_no"]) + "";

				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtCommonTextBox[conTxtEmpCode].Text = Convert.ToString(localRec.Tables[0].Rows[0]["emp_no"]);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtDisplayLabel[conDlblEmpName].Text = Convert.ToString(localRec.Tables[0].Rows[0]["emp_name"]);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtDisplayLabel[conDlblDeptCode].Text = Convert.ToString(localRec.Tables[0].Rows[0]["dept_no"]);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtDisplayLabel[conDlblDeptName].Text = Convert.ToString(localRec.Tables[0].Rows[0]["dept_name"]);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtDisplayLabel[conDlblDesgCode].Text = Convert.ToString(localRec.Tables[0].Rows[0]["desg_no"]);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtDisplayLabel[conDlblDesgName].Text = Convert.ToString(localRec.Tables[0].Rows[0]["desg_name"]);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtDisplayLabel[conDlblLeaveSalary].Text = StringsHelper.Format(localRec.Tables[0].Rows[0]["leave_salary"], "###,###,##0.000");
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtDisplayLabel[conDlblTotalSalary].Text = StringsHelper.Format(localRec.Tables[0].Rows[0]["total_salary"], "###,###,##0.000");

				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtCommonTextBox[conTxtLeaveCode].Text = Convert.ToString(localRec.Tables[0].Rows[0]["leave_no"]);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtDisplayLabel[conDlblLeaveName].Text = Convert.ToString(localRec.Tables[0].Rows[0]["leave_name"]);

				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtCommonDate[conDTxtLeaveFromDate].Value = localRec.Tables[0].Rows[0]["leave_start_date"];
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtCommonDate[conDTxtLeaveToDate].Value = localRec.Tables[0].Rows[0]["leave_end_date"];

				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtCommonDate[conDTxtLeaveFromDate].Tag = Convert.ToString(localRec.Tables[0].Rows[0]["weekend_day1_id"]);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtCommonDate[conDTxtLeaveToDate].Tag = Convert.ToString(localRec.Tables[0].Rows[0]["weekend_day2_id"]);

				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtCommonNumber[conNTxtLeaveDays].Value = localRec.Tables[0].Rows[0]["leave_days"];
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtDisplayLabel[conDlblLeaveBalanceDays].Text = StringsHelper.Format(localRec.Tables[0].Rows[0]["leave_balance_days"], "###,###,##0.000");

				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtCommonNumber[conNTxtActualLeaveDays].Value = localRec.Tables[0].Rows[0]["actual_leave_days"];
				//' Date 04-Nov-2008 For Ticket
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				mCalendarCd = Convert.ToInt32(localRec.Tables[0].Rows[0]["Calendar_cd"]);

				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtDisplayLabel[conDlblTicketBalance].Text = (localRec.Tables[0].Rows[0].IsNull("ticket_balance")) ? "0" : Convert.ToString(localRec.Tables[0].Rows[0]["ticket_balance"]);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtCommonNumber[conNTxtTicketIssued].Value = (localRec.Tables[0].Rows[0].IsNull("ticket_issued")) ? ((object) 0) : localRec.Tables[0].Rows[0]["ticket_issued"];
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtCommonNumber[conNTxtTicketAmountCash].Value = (localRec.Tables[0].Rows[0].IsNull("ticket_amount")) ? ((object) 0) : localRec.Tables[0].Rows[0]["ticket_amount"];

				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				//UPGRADE-WARNING: It was not possible to determine if this addition expression should use an addition operator (+) or a concatenation operator (&)
				txtDisplayLabel[conDlblTotalCashSalary].Text = Convert.ToString(Double.Parse(StringsHelper.Format(((localRec.Tables[0].Rows[0].IsNull("additional_salary")) ? 0 : Convert.ToDouble(localRec.Tables[0].Rows[0]["additional_salary"])) - Convert.ToDouble(localRec.Tables[0].Rows[0]["additional_salary_deduction"]) + ((localRec.Tables[0].Rows[0].IsNull("leave_salary_amount")) ? 0 : Convert.ToDouble(localRec.Tables[0].Rows[0]["leave_salary_amount"])), "########0.000")) + Convert.ToDouble(localRec.Tables[0].Rows[0]["holiday_amount"]));

				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				if (((TriState) Convert.ToInt32(localRec.Tables[0].Rows[0]["ticket_pay_by_cash"])) == TriState.True)
				{
					OptCashOrBooked[conChkTicketCash].Checked = true;
					OptCashOrBooked[conChkTicketBooked].Checked = false;
				}
				else
				{
					OptCashOrBooked[conChkTicketCash].Checked = false;
					OptCashOrBooked[conChkTicketBooked].Checked = true;
				}

				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				if (!localRec.Tables[0].Rows[0].IsNull("ticket_issued_upto"))
				{
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					txtCommonDate[conDTxtTicketIssuedUptoDate].Value = localRec.Tables[0].Rows[0]["ticket_issued_upto"];
				}
				else
				{
					txtCommonDate[conDTxtTicketIssuedUptoDate].Text = "";
				}

				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtCommonTextBox[conTxtTicketEntitledDest].Text = Convert.ToString(localRec.Tables[0].Rows[0]["ticket_entitled_destination"]);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtCommonTextBox[conTxtTicketEntitledDest].Tag = Convert.ToString(localRec.Tables[0].Rows[0]["ticket_entitled_destination_id"]);

				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtCommonTextBox[conTxtTicketIssuedDest].Text = Convert.ToString(localRec.Tables[0].Rows[0]["ticket_issued_destination"]);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtCommonTextBox[conTxtTicketIssuedDest].Tag = Convert.ToString(localRec.Tables[0].Rows[0]["ticket_issued_destination_id"]);

				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtCommonNumber[conNTxtTicketDiffInAmtBooked].Value = localRec.Tables[0].Rows[0]["ticket_booked_diff_in_amt"];

				//'End
				//'Added By Burhan. Date:12-jun-2008
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtCommonNumber[conNTxtPaidHours].Value = localRec.Tables[0].Rows[0]["paid_hours"];
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtDisplayLabel[conDlblPublicHolidays].Text = Convert.ToString(localRec.Tables[0].Rows[0]["public_holidays"]);
				//end
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtCommonNumber[conNTxtPaidDays].Value = localRec.Tables[0].Rows[0]["paid_days"];
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtCommonNumber[conNTxtUnPaidDays].Value = localRec.Tables[0].Rows[0]["unpaid_days"];
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtDisplayLabel[conDlblLeaveAmount].Text = StringsHelper.Format(localRec.Tables[0].Rows[0]["leave_salary_amount"], "###,###,##0.000");
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtDisplayLabel[conDlblHolidayAmount].Text = StringsHelper.Format(localRec.Tables[0].Rows[0]["holiday_amount"], "###,###,##0.000");
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				SystemCombo.SearchCombo(CmbCommon[conCmbPayType], Convert.ToInt32(localRec.Tables[0].Rows[0]["leave_amount_payment_type_id"]));
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtCommonTextBox[conTxtComments].Text = Convert.ToString(localRec.Tables[0].Rows[0]["comments"]) + "";
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtJoiningDate.Value = localRec.Tables[0].Rows[0]["date_of_joining"];
				//''  Ason 01-Dec-2008
				//''Last Leave Date and Last Leave Paid Taken Leave
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				if (localRec.Tables[0].Rows[0].IsNull("Last_Leave_Start_Date"))
				{
					txtCommonDate[conDTxtLastLeaveStartDate].Text = "";
				}
				else
				{
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					txtCommonDate[conDTxtLastLeaveStartDate].Value = localRec.Tables[0].Rows[0]["Last_Leave_Start_Date"];
				}
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				if (localRec.Tables[0].Rows[0].IsNull("Last_Leave_End_Date"))
				{
					txtCommonDate[conDTxtLastLeaveEndDate].Text = "";
				}
				else
				{
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					txtCommonDate[conDTxtLastLeaveEndDate].Value = localRec.Tables[0].Rows[0]["Last_Leave_End_Date"];
				}

				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				txtDisplayLabel[conDlblLastLeavePaidDays].Text = StringsHelper.Format((localRec.Tables[0].Rows[0].IsNull("Last_Leave_Taken_Days")) ? ((object) 0) : localRec.Tables[0].Rows[0]["Last_Leave_Taken_Days"], "########0.000");
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				mIncludeWeekend = Convert.ToBoolean(localRec.Tables[0].Rows[0]["include_weekend"]);
				//'End
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				mEmpType = Convert.ToInt32(localRec.Tables[0].Rows[0]["emp_type_id"]);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				mIsPayClosed = Convert.ToBoolean(localRec.Tables[0].Rows[0]["is_pay_closed"]);
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				mTemplateEntID = (localRec.Tables[0].Rows[0].IsNull("Template_Entry_id")) ? 0 : Convert.ToInt32(localRec.Tables[0].Rows[0]["Template_Entry_id"]);
				//Assign Approval Template
				if (mTemplateEntID == 0)
				{
					txtApprovalTemplate.Text = "";
					txtDlblAppTemplateName.Text = "";
				}
				else
				{
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					txtApprovalTemplate.Text = Convert.ToString(localRec.Tables[0].Rows[0]["trans_no"]);
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					txtDlblAppTemplateName.Text = Convert.ToString(localRec.Tables[0].Rows[0]["l_approval_name"]);
				}
				//End
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				chkLoanGenrate.CheckState = (CheckState) ((Convert.ToBoolean(localRec.Tables[0].Rows[0]["Regenerate_loan"])) ? 1 : 0);
				//Change the form mode to edit
				mCurrentFormMode = SystemVariables.SystemFormModes.frmEditMode;
				txtCommonTextBox[conTxtEmpCode].Enabled = false;
				txtCommonTextBox[conTxtLeaveCode].Enabled = false;
				//        txtCommonDate(conDTxtLeaveFromDate).Enabled = False
				//        txtCommonDate(conDTxtLeaveToDate).Enabled = False

				//Set the form caption and Get the Voucher Status
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				SystemICSProcedure.SetFormCaption(ref mOldVoucherStatus, frmPayLeaveTransaction.DefInstance, Convert.ToInt32(localRec.Tables[0].Rows[0]["status"]), CurrentFormMode, (SystemVariables.gPreferedLanguage == SystemVariables.Language.Arabic) ? "Leave Transaction" : "Leave Transaction");

			}
			if (mEmpType == 148)
			{
				// cmdLeaveAmount.Visible = True '
			}
			else
			{
				cmdLeaveAmount.Visible = false;
			}
			//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
			CmbCommon[0].Enabled = Convert.ToDouble(localRec.Tables[0].Rows[0]["status"]) == 1;
			mFocusTextbox = true; // to enable txtcommontextbo change event
			localRec = null;

			return;

			mFocusTextbox = true; // to enable txtcommontextbo change event
			//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
			SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, Information.Err().Description, this.Name, "GetRecord");
		}

		public void PrintReport()
		{
			int mEntryId = 0;

			if (CurrentFormMode == SystemVariables.SystemFormModes.frmEditMode)
			{
				//UPGRADE_WARNING: (1068) SearchValue of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mEntryId = ReflectionHelper.GetPrimitiveValue<int>(SearchValue);
			}
			else
			{
				return;
			}
			SystemReports.GetCrystalReport(110013080, 2, "6409", Conversion.Str(mEntryId), false);
		}

		public void findRecord()
		{
			//Call the find window

			//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(7080000));
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
			System.DateTime pPayrollDate = DateTime.FromOADate(0);
			string mSQL = "";
			object mReturnValue = null;

			if (CurrentFormMode == SystemVariables.SystemFormModes.frmEditMode)
			{
				if (!SystemHRProcedure.GetTransactionApprovalStage(1, ReflectionHelper.GetPrimitiveValue<int>(mSearchValue), 1))
				{
					MessageBox.Show("Record cannot be modified.", "Approval", MessageBoxButtons.OK, MessageBoxIcon.Information);
					goto mend;
				}
			}

			if (mOldVoucherStatus != SystemVariables.VoucherStatus.stActive)
			{
				SystemProcedure2.VoucherStatusErrorMessage(mOldVoucherStatus, 3);
				if (ControlHelper.GetEnabled(FirstFocusObject))
				{
					FirstFocusObject.Focus();
				}
				goto mend;
			}


			//Check validation during update and add of records
			if (!Information.IsNumeric(txtCommonTextBox[conTxtVoucherNo].Text))
			{
				MessageBox.Show("Enter the Voucher No.", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
				txtCommonTextBox[conTxtVoucherNo].Focus();
				goto mend;
			}

			if (!Information.IsDate(txtCommonDate[conDTxtVoucheDate].DisplayText))
			{
				MessageBox.Show("Enter valid date", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
				txtCommonDate[conDTxtVoucheDate].Focus();
				goto mend;
			}

			if (SystemProcedure2.IsItEmpty(txtCommonTextBox[conTxtEmpCode].Text, SystemVariables.DataType.StringType))
			{
				MessageBox.Show("Enter Employee Code", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
				txtCommonTextBox[conTxtEmpCode].Focus();
				goto mend;
			}

			//''Added By Burhan Ghee Wala
			//''Date 28-June-2007
			//'' Check Leave first date is not less than employees joining date
			mSQL = "select date_of_joining from pay_employee where emp_no='" + txtCommonTextBox[conTxtEmpCode].Text + "'";
			//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mSQL));
			pPayrollDate = DateTime.Parse(SystemHRProcedure.GetPayrollGenerateDate());
			string mDtFrom = "";
			mDtFrom = DateTimeHelper.ToString(ReflectionHelper.GetPrimitiveValue<System.DateTime>(txtCommonDate[conDTxtLeaveFromDate].DisplayText));
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(mReturnValue))
			{
				if (DateTime.Parse(mDtFrom) < ReflectionHelper.GetPrimitiveValue<System.DateTime>(mReturnValue))
				{
					MessageBox.Show("Leave start date can not be less than employee joining date!!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					txtCommonDate[conDTxtLeaveFromDate].Focus();
					goto mend;
				}
			}

			int mDateDiff = 0;
			DialogResult ans = (DialogResult) 0;
			mDateDiff = (int) DateAndTime.DateDiff("d", ReflectionHelper.GetPrimitiveValue<System.DateTime>(mReturnValue), DateTime.Parse(mDtFrom), FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1);
			if (mDateDiff <= mEligibilityDays)
			{
				if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("Allow_Leave_Before_EligibilityDays")))
				{
					ans = MessageBox.Show("Employee not eligible for leave. Do you want to continue ?", "Leave Eligibility", MessageBoxButtons.YesNo);
					if (ans == System.Windows.Forms.DialogResult.No)
					{
						goto mend;
					}
				}
				else
				{
					MessageBox.Show("Employee not eligible for leave.", "Leave Eligibility", MessageBoxButtons.OK, MessageBoxIcon.Information);
					goto mend;
				}
			}
			//
			//If Format(DateAdd("m", 1, mDtFrom), "mm-yyyy") <> Format(pPayrollDate, "mm-yyyy") And Format(DateAdd("m", -1, mDtFrom), "mm-yyyy") <> Format(pPayrollDate, "mm-yyyy") And Format(mDtFrom, "mm-yyyy") <> Format(pPayrollDate, "mm-yyyy") Then
			//        MsgBox "Back dated leave more than one month or advance leave more than one month is not allowed!", vbInformation
			//        GoTo mend
			//        txtCommonDate(conDTxtLeaveFromDate).SetFocus
			//End If
			//''End

			if (!Information.IsDate(txtCommonDate[conDTxtLeaveFromDate].DisplayText))
			{
				MessageBox.Show("Enter valid date", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
				txtCommonDate[conDTxtLeaveFromDate].Focus();
				goto mend;
			}

			if (!Information.IsDate(txtCommonDate[conDTxtLeaveToDate].DisplayText))
			{
				MessageBox.Show("Enter valid date", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
				txtCommonDate[conDTxtLeaveToDate].Focus();
				goto mend;
			}

			if (SystemProcedure2.IsItEmpty(txtCommonNumber[conNTxtActualLeaveDays].Value, SystemVariables.DataType.NumberType))
			{
				MessageBox.Show("Actual Leave days cannot be zero", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
				txtCommonNumber[conNTxtActualLeaveDays].Focus();
				goto mend;
			}

			if (ReflectionHelper.GetPrimitiveValue<System.DateTime>(txtCommonDate[conDTxtLeaveFromDate].Value) > ReflectionHelper.GetPrimitiveValue<System.DateTime>(txtCommonDate[conDTxtLeaveToDate].Value))
			{
				MessageBox.Show("From Date cannot be greater than To date", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
				txtCommonDate[conDTxtLeaveToDate].Focus();
				goto mend;
			}

			//Added by Burhan. Date: 12-Jun-2008
			//txtCommonNumber(conNTxtLeaveDays).Value = CalculateDays(txtCommonDate(conDTxtLeaveFromDate).Value, txtCommonDate(conDTxtLeaveToDate).Value, txtCommonDate(conDTxtLeaveFromDate).Tag, txtCommonDate(conDTxtLeaveToDate).Tag)
			if (!mIncludeWeekend)
			{
				txtCommonNumber[conNTxtLeaveDays].Value = SystemHRProcedure.CalculateDays(ReflectionHelper.GetPrimitiveValue<System.DateTime>(txtCommonDate[conDTxtLeaveFromDate].Value), ReflectionHelper.GetPrimitiveValue<System.DateTime>(txtCommonDate[conDTxtLeaveToDate].Value), Convert.ToInt32(Double.Parse(Convert.ToString(txtCommonDate[conDTxtLeaveFromDate].Tag))), Convert.ToInt32(Double.Parse(Convert.ToString(txtCommonDate[conDTxtLeaveToDate].Tag))));
			}
			else
			{
				txtCommonNumber[conNTxtLeaveDays].Value = SystemHRProcedure.CalculateDays(ReflectionHelper.GetPrimitiveValue<System.DateTime>(txtCommonDate[conDTxtLeaveFromDate].Value), ReflectionHelper.GetPrimitiveValue<System.DateTime>(txtCommonDate[conDTxtLeaveToDate].Value), 59, 59);
			}

			Get_Leave_Balance_Days();
			LeaveAmount();

			if (ReflectionHelper.IsGreaterThan(txtCommonNumber[conNTxtActualLeaveDays].Value, txtCommonNumber[conNTxtLeaveDays].Value))
			{
				MessageBox.Show("Actual leave days cannot be greater than leave days", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
				txtCommonNumber[conNTxtActualLeaveDays].Focus();
				txtCommonNumber[conNTxtActualLeaveDays].Value = 0;
				goto mend;
			}

			//UPGRADE-WARNING: It was not possible to determine if this addition expression should use an addition operator (+) or a concatenation operator (&)
			if (Conversion.Val(Convert.ToString(ReflectionHelper.GetPrimitiveValue<double>(txtCommonNumber[conNTxtPaidDays].Value) + ReflectionHelper.GetPrimitiveValue<double>(txtCommonNumber[conNTxtUnPaidDays].Value))) != Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(txtCommonNumber[conNTxtActualLeaveDays].Value)))
			{
				MessageBox.Show("Sum of paid days and unpaid days should be equal to Actual leave days ", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
				txtCommonNumber[conNTxtPaidDays].Focus();
				goto mend;
			}

			double mLeaveBalanceDays = 0;
			if (!mAllowExcessLeaveDays)
			{
				mLeaveBalanceDays = Double.Parse(StringsHelper.Format(txtDisplayLabel[conDlblLeaveBalanceDays].Text, "#########0.000"));
				if (Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(txtCommonNumber[conNTxtPaidDays].Value)) > mLeaveBalanceDays)
				{
					MessageBox.Show("Paid days cannot be greater than Leave balance days ", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					txtCommonNumber[conNTxtPaidDays].Focus();
					goto mend;
				}
			}

			if (mEmpType == 148 && !SystemProcedure2.IsItEmpty(txtCommonNumber[conNTxtPaidDays].Value, SystemVariables.DataType.NumberType) && Conversion.Val(txtDisplayLabel[conDlblLeaveAmount].Text) == 0)
			{
				MessageBox.Show("Please assgin paid days for employee !", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
				cmdLeaveAmount.Focus();
			}
			else
			{


				return true;
			}
			mend:
			return false;
		}

		private void Form_Closed(Object eventSender, EventArgs eventArgs)
		{
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{
				SystemMenu.RemoveMeFromWindowList(Conversion.Str(this.Handle.ToInt32()));
				if (mEmpType == 148)
				{
					if (ReflectionHelper.GetMember<double>(Application.OpenForms[frmLeaveAmount.Name], "CurrentView") != 0)
					{
						frmLeaveAmount.Close();
						frmLeaveAmount = null;
					}
				}
				UserAccess = null;
				oThisFormToolBar = null;
				frmPayLeaveTransaction.DefInstance = null;
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		public void GetNextNumber()
		{
			txtCommonTextBox[conTxtVoucherNo].Text = SystemProcedure2.GetNewNumber("pay_leave_transaction", "voucher_no");
			FirstFocusObject.Focus();
		}

		private bool isInitializingComponent;
		private void OptCashOrBooked_CheckedChanged(Object eventSender, EventArgs eventArgs)
		{
			int Index = Array.IndexOf(this.OptCashOrBooked, eventSender);
			if (((RadioButton) eventSender).Checked)
			{
				if (isInitializingComponent)
				{
					return;
				}
				if (Index == conChkTicketCash)
				{
					txtCommonNumber[conNTxtTicketAmountCash].Enabled = true;
					txtCommonNumber[conNTxtTicketDiffInAmtBooked].Enabled = false;
					txtCommonNumber[conNTxtTicketDiffInAmtBooked].Value = 0;
				}
				else
				{
					txtCommonNumber[conNTxtTicketAmountCash].Enabled = false;
					txtCommonNumber[conNTxtTicketDiffInAmtBooked].Enabled = true;
					txtCommonNumber[conNTxtTicketAmountCash].Value = 0;
				}
			}
		}



		private void txtApprovalTemplate_DropButtonClick(Object Sender, EventArgs e)
		{
			//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(7220586, "2618"));
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(mTempSearchValue))
			{
				mTemplateEntID = ReflectionHelper.GetPrimitiveValue<int>(((Array) mTempSearchValue).GetValue(0));
				//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				txtApprovalTemplate.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(1));
				txtApprovalTemplate_Leave(txtApprovalTemplate, new EventArgs());
			}
		}

		private void txtApprovalTemplate_Leave(Object eventSender, EventArgs eventArgs)
		{

			string mysql = "select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_Approval_Name" : "a_Approval_Name");
			mysql = mysql + " from sys_approval_template where entry_id = " + mTemplateEntID.ToString();
			//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));

			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(mReturnValue))
			{
				//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				txtDlblAppTemplateName.Text = ReflectionHelper.GetPrimitiveValue<string>(mReturnValue);
			}
			else
			{
				txtDlblAppTemplateName.Text = "";
			}

		}

		private void txtCommonDate_Validating(Object eventSender, CancelEventArgs eventArgs)
		{
			int Index = Array.IndexOf(this.txtCommonDate, eventSender);
			bool Cancel = eventArgs.Cancel;
			try
			{
				object mReturnValue = null;
				string mysql = "";
				int mEmpCode = 0;


				if (Index == conDTxtLeaveToDate || Index == conDTxtLeaveFromDate)
				{
					if (!Information.IsDate(txtCommonDate[conDTxtLeaveFromDate].Value))
					{
						MessageBox.Show(" Invalid date ", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
						Cancel = true;
						txtCommonDate[conDTxtLeaveFromDate].Focus();
						return;
					}

					if (!Information.IsDate(txtCommonDate[conDTxtLeaveToDate].Value))
					{
						MessageBox.Show(" Invalid date ", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
						Cancel = true;
						txtCommonDate[conDTxtLeaveToDate].Focus();
						return;
					}

					if (ReflectionHelper.GetPrimitiveValue<System.DateTime>(txtCommonDate[conDTxtLeaveToDate].Value) < ReflectionHelper.GetPrimitiveValue<System.DateTime>(txtCommonDate[conDTxtLeaveFromDate].Value))
					{
						//UPGRADE_WARNING: (1068) txtCommonDate().Value of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtCommonDate[conDTxtLeaveToDate].Value = ReflectionHelper.GetPrimitiveValue(txtCommonDate[conDTxtLeaveFromDate].Value);
					}

					txtCommonNumber[conNTxtUnPaidDays].Value = 0;
					txtCommonNumber[conNTxtPaidDays].Value = 0;
					//txtCommonNumber(conNTxtActualLeaveDays).Value = 0

					if (ReflectionHelper.GetPrimitiveValue<System.DateTime>(txtCommonDate[conDTxtLeaveFromDate].Value) > ReflectionHelper.GetPrimitiveValue<System.DateTime>(txtCommonDate[conDTxtLeaveToDate].Value))
					{
						MessageBox.Show("From Leave Date cannot be greater than To Leave Date", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
						txtCommonDate[Index].Focus();
						Cancel = true;
					}
					Application.DoEvents();
					if (!SystemProcedure2.IsItEmpty(txtCommonTextBox[conTxtEmpCode].Text, SystemVariables.DataType.StringType))
					{
						if (!mIncludeWeekend)
						{
							txtCommonNumber[conNTxtLeaveDays].Value = SystemHRProcedure.CalculateDays(ReflectionHelper.GetPrimitiveValue<System.DateTime>(txtCommonDate[conDTxtLeaveFromDate].Value), ReflectionHelper.GetPrimitiveValue<System.DateTime>(txtCommonDate[conDTxtLeaveToDate].Value), Convert.ToInt32(Double.Parse(Convert.ToString(txtCommonDate[conDTxtLeaveFromDate].Tag))), Convert.ToInt32(Double.Parse(Convert.ToString(txtCommonDate[conDTxtLeaveToDate].Tag))));
						}
						else
						{
							txtCommonNumber[conNTxtLeaveDays].Value = SystemHRProcedure.CalculateDays(ReflectionHelper.GetPrimitiveValue<System.DateTime>(txtCommonDate[conDTxtLeaveFromDate].Value), ReflectionHelper.GetPrimitiveValue<System.DateTime>(txtCommonDate[conDTxtLeaveToDate].Value), 59, 59);
						}
					}
					Get_Leave_Balance_Days();
				}

				if (Index == conDTxtTicketIssuedUptoDate)
				{
					if (!SystemProcedure2.IsItEmpty(txtCommonTextBox[conTxtEmpCode].Text, SystemVariables.DataType.StringType))
					{
						mysql = " select emp_cd from pay_employee where emp_no='" + txtCommonTextBox[conTxtEmpCode].Text + "'";
						//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
						if (!Convert.IsDBNull(mReturnValue))
						{
							//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							mEmpCode = ReflectionHelper.GetPrimitiveValue<int>(mReturnValue);
						}
						else
						{
							mEmpCode = 0;
						}
					}
					else
					{
						mEmpCode = 0;
					}

					if (Information.IsDate(txtCommonDate[conDTxtTicketIssuedUptoDate].DisplayText))
					{
						mReturnValue = SystemHRProcedure.GetTicketBalance(mEmpCode, ReflectionHelper.GetPrimitiveValue<System.DateTime>(txtCommonDate[conDTxtTicketIssuedUptoDate].DisplayText));
						txtDisplayLabel[conDlblTicketBalance].Text = StringsHelper.Format(ReflectionHelper.GetPrimitiveValue(mReturnValue), "###,###,##0.000");
					}
					mysql = " select ptd.l_ticket_destination, ptd.entry_id from pay_employee pemp ";
					mysql = mysql + " inner join pay_ticket_destination ptd on pemp.ticket_destination = ptd.entry_id ";
					mysql = mysql + " where pemp.emp_cd = " + mEmpCode.ToString();
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (!Convert.IsDBNull(mReturnValue))
					{
						//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtCommonTextBox[conTxtTicketEntitledDest].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(0));
						txtCommonTextBox[conTxtTicketEntitledDest].Tag = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(1));

						//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtCommonTextBox[conTxtTicketIssuedDest].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(0));
						txtCommonTextBox[conTxtTicketIssuedDest].Tag = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(1));
					}
					else
					{
						txtCommonTextBox[conTxtTicketEntitledDest].Text = "";
						txtCommonTextBox[conTxtTicketEntitledDest].Tag = "";

						txtCommonTextBox[conTxtTicketIssuedDest].Text = "";
						txtCommonTextBox[conTxtTicketIssuedDest].Tag = "";

					}
				}
			}
			finally
			{
				eventArgs.Cancel = Cancel;
			}
		}

		private void txtCommonNumber_Change(Object Sender, EventArgs e)
		{
			int Index = Array.IndexOf(this.txtCommonNumber, Sender);
			double mLeaveBalanceDays = 0;
			string mSQL = "";
			object mReturnValue = null;
			int mWeekend = 0;
			int mEmpCd = 0;

			if (txtDisplayLabel[conDlblLeaveBalanceDays].Text.Trim() != "")
			{
				mLeaveBalanceDays = Double.Parse(StringsHelper.Format(txtDisplayLabel[conDlblLeaveBalanceDays].Text, "#########0.000"));
			}
			else
			{
				mLeaveBalanceDays = 0;
			}

			if (mFocusTextbox)
			{ // if focus is set to true then only allow to change
				mEmpCd = SystemHRProcedure.GetEmpCd(txtCommonTextBox[conTxtEmpCode].Text);
				if (Index == conNTxtActualLeaveDays)
				{
					mCheck = false;
					txtCommonNumber[conNTxtPaidDays].Value = 0;
					txtCommonNumber[conNTxtUnPaidDays].Value = 0;
					mCheck = !mAllowExcessLeaveDays;

					if (ReflectionHelper.IsGreaterThan(txtCommonNumber[conNTxtActualLeaveDays].Value, txtCommonNumber[conNTxtLeaveDays].Value))
					{
						MessageBox.Show("Actual leave days cannot be greater than leave days", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
						txtCommonNumber[conNTxtActualLeaveDays].Focus();
						txtCommonNumber[conNTxtActualLeaveDays].Value = 0;
					}
					if (mLeaveBalanceDays != 0)
					{
						if (ReflectionHelper.GetPrimitiveValue<double>(txtCommonNumber[Index].Value) < mLeaveBalanceDays)
						{
							mFocusTextbox = false;
							//UPGRADE_WARNING: (1068) txtCommonNumber().Value of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							txtCommonNumber[conNTxtActualLeaveDays].Value = ReflectionHelper.GetPrimitiveValue(txtCommonNumber[conNTxtLeaveDays].Value);
							//''Change  because it will add leave day from, from date so it is giving me one more day
							//mReturnValue = DateAdd("d", Val(txtCommonNumber(Index).Value), txtCommonDate(conDTxtLeaveFromDate).Value)
							double tempRefParam = Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(txtCommonNumber[Index].Value));
							mReturnValue = WeekDays(ReflectionHelper.GetPrimitiveValue<System.DateTime>(txtCommonDate[conDTxtLeaveFromDate].Value), ReflectionHelper.GetPrimitiveValue<System.DateTime>(txtCommonDate[conDTxtLeaveToDate].Value), ref tempRefParam);
							//mReturnValue = DateAdd("d", Val(txtCommonNumber(Index).Value) + mWeekend, txtCommonDate(conDTxtLeaveFromDate).Value) - 1
							txtDisplayLabel[conDlblPublicHolidays].Text = SystemHRProcedure.GetPublicHolidays(ReflectionHelper.GetPrimitiveValue<System.DateTime>(txtCommonDate[conDTxtLeaveFromDate].Value), ReflectionHelper.GetPrimitiveValue<System.DateTime>(mReturnValue), mCalendarCd).ToString();

							txtCommonNumber[conNTxtPaidDays].Value = Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(txtCommonNumber[Index].Value)) - SystemHRProcedure.GetPublicHolidays(ReflectionHelper.GetPrimitiveValue<System.DateTime>(txtCommonDate[conDTxtLeaveFromDate].Value), ReflectionHelper.GetPrimitiveValue<System.DateTime>(mReturnValue), mCalendarCd);
							txtCommonNumber[conNTxtActualLeaveDays].Value = ReflectionHelper.GetPrimitiveValue<double>(txtCommonNumber[conNTxtLeaveDays].Value) - Conversion.Val(txtDisplayLabel[conDlblPublicHolidays].Text);
							txtCommonNumber[conNTxtUnPaidDays].Value = 0;
							SetNoOfHours();
							mFocusTextbox = true;
						}
						else
						{
							mFocusTextbox = false;
							txtCommonNumber[conNTxtPaidDays].Value = mLeaveBalanceDays;
							double tempRefParam2 = Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(txtCommonNumber[conNTxtPaidDays].Value));
							mReturnValue = WeekDays(ReflectionHelper.GetPrimitiveValue<System.DateTime>(txtCommonDate[conDTxtLeaveFromDate].Value), ReflectionHelper.GetPrimitiveValue<System.DateTime>(txtCommonDate[conDTxtLeaveToDate].Value), ref tempRefParam2);
							txtDisplayLabel[conDlblPublicHolidays].Text = SystemHRProcedure.GetPublicHolidays(ReflectionHelper.GetPrimitiveValue<System.DateTime>(txtCommonDate[conDTxtLeaveFromDate].Value), ReflectionHelper.GetPrimitiveValue<System.DateTime>(mReturnValue), mCalendarCd).ToString();
							//txtCommonNumber(conNTxtActualLeaveDays).Value = txtCommonNumber(conNTxtLeaveDays).Value - Val(txtDisplayLabel(conDlblPublicHolidays).Text)
							if ((Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(txtCommonNumber[Index].Value)) - mLeaveBalanceDays) > Conversion.Val(txtDisplayLabel[conDlblPublicHolidays].Text))
							{
								txtCommonNumber[conNTxtPaidDays].Value = mLeaveBalanceDays;
								txtCommonNumber[conNTxtUnPaidDays].Value = (Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(txtCommonNumber[Index].Value)) - mLeaveBalanceDays) - Conversion.Val(txtDisplayLabel[conDlblPublicHolidays].Text);
							}
							else
							{
								txtCommonNumber[conNTxtPaidDays].Value = mLeaveBalanceDays + ((Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(txtCommonNumber[Index].Value)) - mLeaveBalanceDays) - Conversion.Val(txtDisplayLabel[conDlblPublicHolidays].Text));
								txtCommonNumber[conNTxtUnPaidDays].Value = Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(txtCommonNumber[Index].Value)) - mLeaveBalanceDays;
							}
							txtCommonNumber[conNTxtActualLeaveDays].Value = ReflectionHelper.GetPrimitiveValue<double>(txtCommonNumber[conNTxtLeaveDays].Value) - Conversion.Val(txtDisplayLabel[conDlblPublicHolidays].Text);
							//txtCommonNumber(conNTxtActualLeaveDays).Value = txtCommonNumber(conNTxtLeaveDays).Value
							SetNoOfHours();
							mFocusTextbox = true;
						}
					}
					else
					{
						txtCommonNumber[conNTxtUnPaidDays].Value = Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(txtCommonNumber[Index].Value));
					}
				}

				if (Index == conNTxtPaidDays)
				{
					if (!(this.ActiveControl.Name == "txtCommonNumber" && ControlArrayHelper.GetControlIndex(this.ActiveControl) == conNTxtUnPaidDays))
					{
						txtCommonNumber[conNTxtUnPaidDays].Value = Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(txtCommonNumber[conNTxtActualLeaveDays].Value)) - Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(txtCommonNumber[conNTxtPaidDays].Value));
					}
					double tempRefParam3 = Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(txtCommonNumber[conNTxtPaidDays].Value));
					mReturnValue = WeekDays(ReflectionHelper.GetPrimitiveValue<System.DateTime>(txtCommonDate[conDTxtLeaveFromDate].Value), ReflectionHelper.GetPrimitiveValue<System.DateTime>(txtCommonDate[conDTxtLeaveToDate].Value), ref tempRefParam3);
					if (mLeaveBalanceDays != 0)
					{
						txtDisplayLabel[conDlblPublicHolidays].Text = SystemHRProcedure.GetPublicHolidays(ReflectionHelper.GetPrimitiveValue<System.DateTime>(txtCommonDate[conDTxtLeaveFromDate].Value), ReflectionHelper.GetPrimitiveValue<System.DateTime>(mReturnValue), mCalendarCd).ToString();
					}
					else
					{
						txtDisplayLabel[conDlblPublicHolidays].Text = "0";
					}
					//'this check is done in checkdatavalidity function by hakim on 10-may-2009
					//        If (Val(txtCommonNumber(conNTxtPaidDays).Value) + Val(txtCommonNumber(conNTxtUnPaidDays).Value)) > Val(txtCommonNumber(conNTxtActualLeaveDays).Value) Then
					//            MsgBox "Sum of paid days and unpaid days cannot be greater than Actual leave days ", vbInformation
					//            txtCommonNumber(Index).SetFocus
					//            txtCommonNumber(Index).Value = 0
					//        End If
				}
				if (Index == conNTxtUnPaidDays)
				{
					if (!(this.ActiveControl.Name == "txtCommonNumber" && ControlArrayHelper.GetControlIndex(this.ActiveControl) == conNTxtPaidDays))
					{
						txtCommonNumber[conNTxtPaidDays].Value = Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(txtCommonNumber[conNTxtActualLeaveDays].Value)) - Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(txtCommonNumber[conNTxtUnPaidDays].Value));
					}
					//        If (Val(txtCommonNumber(conNTxtPaidDays).Value) + Val(txtCommonNumber(conNTxtUnPaidDays).Value)) > Val(txtCommonNumber(conNTxtActualLeaveDays).Value) Then
					//            MsgBox "Sum of paid days and unpaid days cannot be greater than Actual leave days ", vbInformation
					//            txtCommonNumber(Index).SetFocus
					//            txtCommonNumber(Index).Value = 0
					//        End If
				}
			}

			//''this check is done in checkdatavalidity funtion..modified by hakim on 10-may-2009
			//If Index = conNTxtPaidDays And mCheck = True Then
			//    If Val(txtCommonNumber(conNTxtPaidDays).Value) > mLeaveBalanceDays Then
			//         MsgBox "Paid days cannot be greater than Leave balance days ", vbInformation
			//         txtCommonNumber(Index).SetFocus
			//         txtCommonNumber(Index).Value = 0
			//         Exit Sub
			//     End If
			//End If

			if (Index == conNTxtTicketIssued)
			{
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(txtDisplayLabel[conDlblTicketBalance].Text) && txtDisplayLabel[conDlblTicketBalance].Text != "")
				{
					//''commented by hakim on 06-jun-2009, as IMCO requires negative ticket
					//        If txtCommonNumber(conNTxtTicketIssued).Value > txtDisplayLabel(conDlblTicketBalance).Text Then
					//            If MsgBox("Are you sure to give ticket more then balance?", vbYesNo) = vbNo Then
					//                txtCommonNumber(conNTxtTicketIssued).Value = 0
					//                Exit Sub
					//            End If
					//        End If
					mSQL = "select return_ticket_amount from pay_ticket_destination ptd";
					mSQL = mSQL + " inner join pay_employee pemp on pemp.ticket_destination = ptd.entry_id";
					mSQL = mSQL + " where pemp.emp_no = '" + txtCommonTextBox[conTxtEmpCode].Text + "'";
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mSQL));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (!Convert.IsDBNull(mReturnValue))
					{
						txtCommonNumber[conNTxtTicketAmountCash].Value = ReflectionHelper.GetPrimitiveValue<double>(mReturnValue) * ReflectionHelper.GetPrimitiveValue<double>(txtCommonNumber[conNTxtTicketIssued].Value);
					}
					else
					{
						txtCommonNumber[conNTxtTicketAmountCash].Value = 0;
					}
				}
			}
		}

		private void txtCommonNumber_Enter(Object eventSender, EventArgs eventArgs)
		{
			int Index = Array.IndexOf(this.txtCommonNumber, eventSender);
			if (Index == conNTxtActualLeaveDays)
			{ //And txtCommonNumber(conNTxtActualLeaveDays).Value = 0 Then
				//UPGRADE_WARNING: (1068) txtCommonNumber().Value of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				txtCommonNumber[conNTxtActualLeaveDays].Value = ReflectionHelper.GetPrimitiveValue(txtCommonNumber[conNTxtLeaveDays].Value);
			}
		}

		private void txtCommonNumber_Leave(Object eventSender, EventArgs eventArgs)
		{
			int Index = Array.IndexOf(this.txtCommonNumber, eventSender);
			string mSQL = "";
			object mReturnValue = null;
			if (Index == conNTxtPaidDays)
			{
				LeaveAmount();
			}
			if (Index == conNTxtPaidHours)
			{
				mSQL = " select emp_cd from pay_employee where emp_no = '" + txtCommonTextBox[conTxtEmpCode].Text + "'";
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mSQL));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(mReturnValue))
				{
					txtCommonNumber[conNTxtUnPaidDays].Value = 0;
					txtCommonNumber[conNTxtActualLeaveDays].Value = ReflectionHelper.GetPrimitiveValue<double>(txtCommonNumber[conNTxtPaidHours].Value) / SystemHRProcedure.GetEmpPerDayHours(ReflectionHelper.GetPrimitiveValue<int>(mReturnValue));
					txtCommonNumber[conNTxtPaidDays].Value = ReflectionHelper.GetPrimitiveValue<double>(txtCommonNumber[conNTxtPaidHours].Value) / SystemHRProcedure.GetEmpPerDayHours(ReflectionHelper.GetPrimitiveValue<int>(mReturnValue));
					//txtCommonNumber(conNTxtActualLeaveDays).Value = txtCommonNumber(conNTxtPaidDays).Value
				}
			}
		}

		private void txtCommonTextBox_DropButtonClick(Object Sender, EventArgs e)
		{
			int Index = Array.IndexOf(this.txtCommonTextBox, Sender);
			if (Index == conTxtVoucherNo)
			{
				GetNextNumber();
			}
			else
			{
				FindRoutine("txtCommonTextBox#" + Index.ToString().Trim());
			}
		}

		private void txtCommonTextBox_Leave(Object eventSender, EventArgs eventArgs)
		{
			int Index = Array.IndexOf(this.txtCommonTextBox, eventSender);
			DialogResult ans = (DialogResult) 0;
			try
			{
				object mTempValue = null;
				object mApprovalTempValue = null;
				object mReturnValue = null;
				string mysql = "";
				int cnt = 0;

				int mDateDiff = 0;
				if (Index == conTxtEmpCode)
				{
					if (!SystemProcedure2.IsItEmpty(txtCommonTextBox[conTxtEmpCode].Text, SystemVariables.DataType.StringType))
					{
						mysql = "select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_first_name + ' ' + l_second_name + ' ' + l_third_name + ' ' + l_fourth_name" : "a_first_name + ' ' + a_second_name + ' ' + a_third_name + ' ' + a_fourth_name");
						mysql = mysql + " , dept_no ";
						mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_dept_name" : "a_dept_name");
						mysql = mysql + " , desg_no ";
						mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_desg_name" : "a_desg_name");
						mysql = mysql + " , emp_cd";
						mysql = mysql + " , pemp.weekend, weekend, weekend_day1_id , weekend_day2_id  ";
						mysql = mysql + " , pemp.total_salary, pemp.Emp_Type_Id, pemp.date_of_joining , pemp.calendar_cd ";
						mysql = mysql + " from pay_employee pemp , pay_department pdept, pay_designation pdesg ";
						mysql = mysql + " where ";
						mysql = mysql + " pemp.dept_cd = pdept.dept_cd and pemp.desg_cd = pdesg.desg_cd ";
						mysql = mysql + " and pemp.emp_no ='" + txtCommonTextBox[conTxtEmpCode].Text + "'";
						//''Only Active Employee
						mysql = mysql + " and pemp.status_cd = 1 ";

						//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
						if (Convert.IsDBNull(mTempValue))
						{
							txtCommonTextBox[Index].Text = "";
							txtDisplayLabel[conDlblEmpName].Text = "";
							txtDisplayLabel[conDlblDeptCode].Text = "";
							txtDisplayLabel[conDlblDeptName].Text = "";
							txtDisplayLabel[conDlblDesgCode].Text = "";
							txtDisplayLabel[conDlblDesgName].Text = "";
							//txtDisplayLabel(conDlblLeaveSalary).Text = ""
							txtCommonDate[conDTxtLeaveFromDate].Tag = "";
							txtCommonDate[conDTxtLeaveToDate].Tag = "";
							txtDisplayLabel[conDlblTotalSalary].Text = "";
							mCalendarCd = 1;
							mEmpType = 0;
							throw new System.Exception("-9990002");
						}
						else
						{
							//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							txtDisplayLabel[conDlblEmpName].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(0));
							//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							txtDisplayLabel[conDlblDeptCode].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(1));
							//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							txtDisplayLabel[conDlblDeptName].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(2));
							//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							txtDisplayLabel[conDlblDesgCode].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(3));
							//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							txtDisplayLabel[conDlblDesgName].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(4));
							//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							mEmpType = ReflectionHelper.GetPrimitiveValue<int>(((Array) mTempValue).GetValue(11));
							//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							mCalendarCd = ReflectionHelper.GetPrimitiveValue<int>(((Array) mTempValue).GetValue(13));
							//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							txtJoiningDate.Value = ReflectionHelper.GetPrimitiveValue(((Array) mTempValue).GetValue(12));
							if (mEmpType != 148)
							{
								cmdLeaveAmount.Visible = false;
							}
							else
							{
								//cmdLeaveAmount.Visible = True
							}
							//txtDisplayLabel(conDlblLeaveSalary).Text = Format(mTempValue(6), "###,###,##0.000")
							txtDisplayLabel[conDlblTotalSalary].Text = StringsHelper.Format(ReflectionHelper.GetPrimitiveValue(((Array) mTempValue).GetValue(10)), "###,###,##0.000");

							txtCommonDate[conDTxtLeaveFromDate].Tag = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(8));
							txtCommonDate[conDTxtLeaveToDate].Tag = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(9));

							if (!SystemProcedure2.IsItEmpty(txtCommonTextBox[conTxtLeaveCode].Text, SystemVariables.DataType.NumberType))
							{
								Get_Leave_Balance_Days();
							}
							else
							{
								txtDisplayLabel[conDlblLeaveBalanceDays].Text = "0.000";
							}
							//Default Approval Aasign
							mTemplateEntID = SystemHRProcedure.GetDefaultTemplateEntryID(txtCommonTextBox[conTxtEmpCode].Text);
							if (mTemplateEntID == 0)
							{
								txtApprovalTemplate.Text = "";
								txtDlblAppTemplateName.Text = "";
							}
							else
							{
								//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
								mApprovalTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode("select trans_no,l_approval_name from sys_approval_template where entry_id =" + mTemplateEntID.ToString()));
								//UPGRADE_WARNING: (1068) mApprovalTempValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
								txtApprovalTemplate.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mApprovalTempValue).GetValue(0));
								//UPGRADE_WARNING: (1068) mApprovalTempValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
								txtDlblAppTemplateName.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mApprovalTempValue).GetValue(1));
							}
						}
					}
					else
					{
						txtDisplayLabel[conDlblEmpName].Text = "";
						txtDisplayLabel[conDlblDeptCode].Text = "";
						txtDisplayLabel[conDlblDeptName].Text = "";
						txtDisplayLabel[conDlblDesgCode].Text = "";
						txtDisplayLabel[conDlblDesgName].Text = "";
						txtDisplayLabel[conDlblLeaveSalary].Text = "";
						txtCommonDate[conDTxtLeaveFromDate].Tag = "";
						txtCommonDate[conDTxtLeaveToDate].Tag = "";
						txtDisplayLabel[conDlblTotalSalary].Text = "";
					}
				}
				else if (Index == conTxtLeaveCode)
				{ 
					if (!SystemProcedure2.IsItEmpty(txtCommonTextBox[conTxtLeaveCode].Text, SystemVariables.DataType.NumberType))
					{
						mysql = "select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_leave_name" : "a_leave_name");
						mysql = mysql + " , leave_no, plt.Allow_Excess_Leave_Days, leave_type_cd, pleave.include_weekend, eligibility_days ";
						mysql = mysql + " , dbo.paygetleavesalary(pemp.emp_cd, pleave.leave_cd) , pemp.Date_of_joining";
						mysql = mysql + " from pay_employee_leave_details peld ";
						mysql = mysql + " inner join pay_employee pemp on pemp.emp_cd = peld.emp_cd ";
						mysql = mysql + " inner join pay_leave pleave on peld.leave_cd = pleave.leave_cd ";
						mysql = mysql + " inner join pay_leave_type plt on pleave.leave_type_cd = plt.type_cd ";
						mysql = mysql + " where ";
						mysql = mysql + " emp_no ='" + txtCommonTextBox[conTxtEmpCode].Text + "'";
						mysql = mysql + " and leave_no = " + txtCommonTextBox[conTxtLeaveCode].Text;

						//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
						if (Convert.IsDBNull(mTempValue))
						{
							txtCommonTextBox[Index].Text = "";
							txtDisplayLabel[conDlblLeaveName].Text = "";
							txtCommonDate[conDTxtLastLeaveStartDate].Text = "";
							txtCommonDate[conDTxtLastLeaveEndDate].Text = "";
							txtDisplayLabel[conDlblLeaveSalary].Text = "";
							txtDisplayLabel[conDlblLastLeavePaidDays].Text = StringsHelper.Format(0, "########0.000");
							throw new System.Exception("-9990002");
						}
						else
						{
							//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							txtDisplayLabel[conDlblLeaveName].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(0));
							txtDisplayLabel[conDlblLeaveSalary].Text = StringsHelper.Format(ReflectionHelper.GetPrimitiveValue(((Array) mTempValue).GetValue(6)), "###,###,##0.000");
							//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to bool. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							mAllowExcessLeaveDays = ReflectionHelper.GetPrimitiveValue<bool>(((Array) mTempValue).GetValue(2));
							//added by burhan. Date: 12-jun-2008
							//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to bool. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							mIncludeWeekend = ReflectionHelper.GetPrimitiveValue<bool>(((Array) mTempValue).GetValue(4));
							//added by burhan. 19-Jun- 2008
							//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							mEligibilityDays = ReflectionHelper.GetPrimitiveValue<int>(((Array) mTempValue).GetValue(5));
							Get_Leave_Balance_Days();
							if (ReflectionHelper.GetPrimitiveValue<double>(((Array) mTempValue).GetValue(3)) == 6)
							{
								if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("include_basic_salary_in_paynow")))
								{
									CmbCommon[0].ListIndex = 1;
								}
								else
								{
									CmbCommon[0].ListIndex = 0;
								}
								CmbCommon[0].Enabled = true;
								txtCommonNumber[conNTxtPaidHours].Enabled = false;
							}
							else
							{
								CmbCommon[0].ListIndex = 2;
								CmbCommon[0].Enabled = true;
								txtCommonNumber[conNTxtPaidHours].Enabled = true;
							}
							mysql = " select top 1 leave_start_date, leave_end_date";
							mysql = mysql + " from pay_leave_transaction plt";
							mysql = mysql + " inner join pay_employee pemp on pemp.emp_cd = plt.emp_cd";
							mysql = mysql + " inner join pay_leave pl on pl.leave_cd = plt.leave_cd";
							mysql = mysql + " where pemp.emp_no = '" + txtCommonTextBox[conTxtEmpCode].Text + "'";
							mysql = mysql + " and pl.leave_type_cd =" + ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(3));
							mysql = mysql + " order by plt.voucher_no desc";
							//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
							if (!Convert.IsDBNull(mReturnValue))
							{
								//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
								txtCommonDate[conDTxtLastLeaveStartDate].Value = ReflectionHelper.GetPrimitiveValue(((Array) mReturnValue).GetValue(0));
								//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
								txtCommonDate[conDTxtLastLeaveEndDate].Value = ReflectionHelper.GetPrimitiveValue(((Array) mReturnValue).GetValue(1));
								mysql = "select sum(paid_days) ";
								mysql = mysql + " from pay_leave_transaction plt";
								mysql = mysql + " inner join pay_employee pemp on pemp.emp_cd = plt.emp_cd";
								mysql = mysql + " inner join pay_leave pl on pl.leave_cd = plt.leave_cd";
								mysql = mysql + " where pemp.emp_no = '" + txtCommonTextBox[conTxtEmpCode].Text + "'";
								mysql = mysql + " and pl.leave_type_cd =" + ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(3));
								//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
								mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
								//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
								if (!Convert.IsDBNull(mReturnValue))
								{
									txtDisplayLabel[conDlblLastLeavePaidDays].Text = StringsHelper.Format(ReflectionHelper.GetPrimitiveValue(mReturnValue), "########0.000");
								}
								else
								{
									txtDisplayLabel[conDlblLastLeavePaidDays].Text = StringsHelper.Format(0, "########0.000");
								}
							}
							else
							{
								txtCommonDate[conDTxtLastLeaveStartDate].Text = "";
								txtCommonDate[conDTxtLastLeaveEndDate].Text = "";
							}
							mDateDiff = (int) DateAndTime.DateDiff("d", ReflectionHelper.GetPrimitiveValue<System.DateTime>(((Array) mTempValue).GetValue(7)), ReflectionHelper.GetPrimitiveValue<System.DateTime>(txtCommonDate[conDTxtLeaveFromDate].DisplayText), FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1);
							if (mDateDiff <= mEligibilityDays)
							{
								if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("Allow_Leave_Before_EligibilityDays")))
								{
									ans = MessageBox.Show("Employee not eligible for leave. Do you want to continue ?", "Leave Eligibility", MessageBoxButtons.YesNo);
									if (ans == System.Windows.Forms.DialogResult.No)
									{
										txtCommonTextBox[conTxtLeaveCode].Text = "";
										txtDisplayLabel[conDlblLeaveName].Text = "";
										txtCommonTextBox[conTxtLeaveCode].Focus();
									}
									else
									{
										txtCommonDate[conDTxtLeaveFromDate].Focus();
									}
								}
								else
								{
									MessageBox.Show("Employee not eligible for leave.", "Leave Eligibility", MessageBoxButtons.OK, MessageBoxIcon.Information);
									txtCommonTextBox[conTxtLeaveCode].Text = "";
									txtDisplayLabel[conDlblLeaveName].Text = "";
									txtCommonTextBox[conTxtLeaveCode].Focus();
								}
							}
						}
					}
					else
					{
						txtDisplayLabel[conDlblLeaveName].Text = "";
						txtCommonDate[conDTxtLastLeaveStartDate].Value = DateTime.Today;
						txtCommonDate[conDTxtLastLeaveEndDate].Value = DateTime.Today;
						txtDisplayLabel[conDlblLastLeavePaidDays].Text = StringsHelper.Format(0, "########0.000");
					}
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
					if (txtCommonTextBox[Index].Enabled)
					{
						txtCommonTextBox[Index].Focus();
					}
				}
				else
				{
					//
				}
			}

		}


		public void FindRoutine(string pObjectName)
		{
			string mysql = "";
			object mTempSearchValue = null;

			if ((pObjectName.IndexOf('#') + 1) == 0)
			{
				return;
			}

			string mObjectName = pObjectName.Substring(0, Math.Min(pObjectName.IndexOf('#'), pObjectName.Length));
			int mIndex = Convert.ToInt32(Double.Parse(pObjectName.Substring(pObjectName.IndexOf('#') + 1)));


			if (mObjectName == "txtCommonTextBox")
			{
				txtCommonTextBox[mIndex].Text = "";
				switch(mIndex)
				{
					case conTxtEmpCode : 
						mysql = " pay_emp.status_cd = 1 "; 
						//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
						mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(7050000, "831", mysql)); 
						break;
					case conTxtLeaveCode : 
						if (!SystemProcedure2.IsItEmpty(txtCommonTextBox[conTxtEmpCode].Text, SystemVariables.DataType.StringType))
						{
							mysql = " pay_emp.emp_no ='" + txtCommonTextBox[conTxtEmpCode].Text + "'";
							//''Only Active Employee
							mysql = mysql + " and pay_emp.status_cd = 1 ";
							//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(7070000, "876", mysql));
						}
						else
						{
							MessageBox.Show("Select an Employee ", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
							txtCommonTextBox[conTxtEmpCode].Focus();
						} 
						break;
					case conTxtTicketIssuedDest : 
						//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
						mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(7220340, "2502")); 
						break;
					default:
						return;
				}
			}

			//UPGRADE_WARNING: (2080) IsEmpty was upgraded to a comparison and has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2080
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(mTempSearchValue) && !Object.Equals(mTempSearchValue, null))
			{
				if (mObjectName == "txtCommonTextBox")
				{
					//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					txtCommonTextBox[mIndex].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(1));
					if (mIndex == conTxtTicketIssuedDest)
					{
						txtCommonTextBox[mIndex].Tag = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(0));
					}

					txtCommonTextBox_Leave(txtCommonTextBox[mIndex], new EventArgs());
				}
			}
		}

		private void Get_Leave_Balance_Days()
		{
			int mEmpCode = 0;
			int mLeaveCode = 0;
			object mReturnValue = null;
			string mysql = "";

			if (SystemProcedure2.IsItEmpty(txtCommonTextBox[conTxtEmpCode].Text, SystemVariables.DataType.StringType))
			{
				return;
			}
			else
			{
				mysql = " select emp_cd from pay_employee where emp_no='" + txtCommonTextBox[conTxtEmpCode].Text + "'";
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
					mEmpCode = ReflectionHelper.GetPrimitiveValue<int>(mReturnValue);
				}
			}

			if (SystemProcedure2.IsItEmpty(txtCommonTextBox[conTxtLeaveCode].Text, SystemVariables.DataType.NumberType))
			{
				return;
			}
			else
			{
				mysql = " select leave_cd from pay_leave where leave_no=" + txtCommonTextBox[conTxtLeaveCode].Text;
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
			}

			if (Information.IsDate(txtCommonDate[conDTxtLeaveFromDate].DisplayText))
			{
				mReturnValue = SystemHRProcedure.Leave_Balance_Days(mEmpCode, mLeaveCode, ReflectionHelper.GetPrimitiveValue<System.DateTime>(txtCommonDate[conDTxtLeaveFromDate].Value), 4);
				txtDisplayLabel[conDlblLeaveBalanceDays].Text = StringsHelper.Format(ReflectionHelper.GetPrimitiveValue(mReturnValue), "###,###,##0.000");


				mReturnValue = SystemHRProcedure.GetTicketBalance(mEmpCode, ReflectionHelper.GetPrimitiveValue<System.DateTime>(txtCommonDate[conDTxtLeaveFromDate].DisplayText));
				txtDisplayLabel[conDlblTicketBalance].Text = StringsHelper.Format(ReflectionHelper.GetPrimitiveValue(mReturnValue), "###,###,##0.000");
				//txtCommonDate(conDTxtTicketIssuedUptoDate).Value = txtCommonDate(conDTxtLeaveFromDate).DisplayText
			}

		}

		private void LeaveAmount()
		{
			try
			{
				int mEmpCode = 0;
				int mLeaveCode = 0;
				double mHolidaySalary = 0;
				object mReturnValue = null;
				int mHolidayBillingCd = 0;
				string mysql = "";

				//''commented by hakim on 05-jun-2007
				//''it was done after adding the feature of allowexcessleavedays for KTS

				//If mCheck = False Then
				//    Exit Sub
				//End If

				if (SystemProcedure2.IsItEmpty(txtCommonTextBox[conTxtEmpCode].Text, SystemVariables.DataType.StringType))
				{
					MessageBox.Show("Enter Employee Code", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					txtCommonTextBox[conTxtEmpCode].Focus();
					return;
				}
				else
				{
					mysql = " select emp_cd from pay_employee where emp_no='" + txtCommonTextBox[conTxtEmpCode].Text + "'";
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (Convert.IsDBNull(mReturnValue))
					{
						MessageBox.Show("Invalid Employee Code", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
						txtCommonTextBox[conTxtEmpCode].Focus();
						return;
					}
					else
					{
						//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mEmpCode = ReflectionHelper.GetPrimitiveValue<int>(mReturnValue);
					}
				}

				if (SystemProcedure2.IsItEmpty(txtCommonTextBox[conTxtLeaveCode].Text, SystemVariables.DataType.StringType))
				{
					MessageBox.Show("Enter Leave Code", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					txtCommonTextBox[conTxtLeaveCode].Focus();
					return;
				}
				else
				{
					mysql = " select leave_cd from pay_leave where leave_no='" + txtCommonTextBox[conTxtLeaveCode].Text + "'";
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (Convert.IsDBNull(mReturnValue))
					{
						MessageBox.Show("Invalid Leave Code", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
						txtCommonTextBox[conTxtLeaveCode].Focus();
						return;
					}
					else
					{
						//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mLeaveCode = ReflectionHelper.GetPrimitiveValue<int>(mReturnValue);
					}
				}

				if (Information.IsDate(txtCommonDate[conDTxtLeaveFromDate].DisplayText) && !SystemProcedure2.IsItEmpty(txtCommonNumber[conNTxtPaidDays].Value, SystemVariables.DataType.NumberType))
				{
					//Dim mLeaveamount As Currency
					//mLeaveamount = PayLeaveAmount_1(mEmpCode, mLeaveCode, txtCommonNumber(conNTxtPaidDays).Value, txtCommonDate(conDTxtLeaveFromDate).DisplayText)
					//mLeaveamount = TestLeaveAmount(mEmpCode, mLeaveCode, txtCommonNumber(conNTxtPaidDays).Value, txtCommonDate(conDTxtLeaveFromDate).DisplayText)
					//   If mEmpType <> 148 Then
					mysql = " select dbo.payLeaveAmount(" + mEmpCode.ToString() + "," + mLeaveCode.ToString() + "," + Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(txtCommonNumber[conNTxtPaidDays].Value)).ToString() + ",'" + ReflectionHelper.GetPrimitiveValue<string>(txtCommonDate[conDTxtLeaveFromDate].DisplayText) + "')";
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (!Convert.IsDBNull(mReturnValue))
					{
						txtDisplayLabel[conDlblLeaveAmount].Text = StringsHelper.Format(ReflectionHelper.GetPrimitiveValue(mReturnValue), "###,###,##0.000");
					}
					else
					{
						txtDisplayLabel[conDlblLeaveAmount].Text = "0.000";
					}
					//    Else
					//         'txtDisplayLabel(conDlblLeaveAmount).Text = "0.000"
					//    End If

					// For how calculate data for sick leave
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode("select leave_type_cd from pay_leave where leave_cd=" + mLeaveCode.ToString()));
					if (ReflectionHelper.GetPrimitiveValue<double>(mReturnValue) == 11)
					{
						mysql = " select dbo.payLeavedetails(" + mEmpCode.ToString() + "," + mLeaveCode.ToString() + "," + ReflectionHelper.GetPrimitiveValue<string>(txtCommonNumber[conNTxtPaidDays].Value) + ",'" + ReflectionHelper.GetPrimitiveValue<string>(txtCommonDate[conDTxtLeaveFromDate].DisplayText) + "')";
						//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
						if (!Convert.IsDBNull(mReturnValue))
						{
							if (Conversion.Val(txtDisplayLabel[conDlblPublicHolidays].Text) > 0)
							{
								txtCommonTextBox[conTxtComments].Text = ReflectionHelper.GetPrimitiveValue<string>(mReturnValue) + " and " + txtDisplayLabel[conDlblPublicHolidays].Text + " as Public Holiday";
							}
							else
							{
								txtCommonTextBox[conTxtComments].Text = ReflectionHelper.GetPrimitiveValue<string>(mReturnValue);
							}
						}
						//    Else
						//        txtCommonTextBox(conTxtComments).Text = ""
					}

					//'' on 16-Jun-2009 For Holiday Amount
					if (ReflectionHelper.GetPrimitiveValue<double>(SystemProcedure2.GetSystemPreferenceSetting("Holiday_Bill_No")) != 0)
					{
						mHolidayBillingCd = ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetMasterCode("select bill_cd from pay_billing_type where bill_no = " + ReflectionHelper.GetPrimitiveValue<string>(SystemProcedure2.GetSystemPreferenceSetting("Holiday_Bill_No"))));
						mHolidaySalary = ReflectionHelper.GetPrimitiveValue<double>(SystemProcedure2.GetMasterCode("select isnull(dbo.GetCalculateBillingSalary(" + mEmpCode.ToString() + "," + mHolidayBillingCd.ToString() + "),0)"));
					}
					else
					{
						//mHolidaySalary = GetTotalSalaryForLastMonthEnd(mEmpCode)
						//'' Change  on 27-Dec-2011 For Holiday Salary on Total_Salary
						//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to double. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mHolidaySalary = ReflectionHelper.GetPrimitiveValue<double>(SystemProcedure2.GetMasterCode("select total_salary from pay_employee where emp_no = '" + txtCommonTextBox[conTxtEmpCode].Text + "'"));
					}
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode("select Rate_Calc_Method_Id,Weekend_Day1_Id,Weekend_Day2_Id,Days_Per_Month,rate_per_day from pay_employee where emp_cd =" + mEmpCode.ToString()));

					if (ReflectionHelper.GetPrimitiveValue<double>(((Array) mReturnValue).GetValue(0)) == 60)
					{
						txtDisplayLabel[conDlblHolidayAmount].Text = StringsHelper.Format(Conversion.Val(txtDisplayLabel[conDlblPublicHolidays].Text) * (mHolidaySalary / ((double) ReflectionHelper.GetPrimitiveValue<double>(((Array) mReturnValue).GetValue(3)))), "###,###,##0.00");
					}
					else if (ReflectionHelper.GetPrimitiveValue<double>(((Array) mReturnValue).GetValue(0)) == 61)
					{ 
						txtDisplayLabel[conDlblHolidayAmount].Text = StringsHelper.Format(Conversion.Val(txtDisplayLabel[conDlblPublicHolidays].Text) * (mHolidaySalary / SystemHRProcedure.CalculateDays(DateTime.Parse(SystemHRProcedure.GetPayrollGenerateStartDate()), DateTime.Parse(SystemHRProcedure.GetPayrollGenerateDate()), ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue).GetValue(1)), ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue).GetValue(2)))), "###,###,##0.00");
					}
					else if (ReflectionHelper.GetPrimitiveValue<double>(((Array) mReturnValue).GetValue(0)) == 130)
					{ 
						txtDisplayLabel[conDlblHolidayAmount].Text = StringsHelper.Format(Conversion.Val(txtDisplayLabel[conDlblPublicHolidays].Text) * ReflectionHelper.GetPrimitiveValue<double>(((Array) mReturnValue).GetValue(4)), "###,###,##0.00");
					}

					//''End
				}
				else
				{
					txtDisplayLabel[conDlblLeaveAmount].Text = "";
					txtDisplayLabel[conDlblHolidayAmount].Text = "";
				}
			}
			catch (Exception e)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				if (Information.Err().Number == 11)
				{
					MessageBox.Show("Please Check Employee Master Payroll Details!!!", "Leave Amount", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				else
				{
					//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
					MessageBox.Show(Information.Err().Number.ToString() + " " + e.Message, "Leave Amount", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
			}
		}


		public bool Post()
		{
			bool result = false;
			DialogResult ans = (DialogResult) 0;
			frmSysOnlinePosting frmTemp = frmSysOnlinePosting.CreateInstance();

			if (mOldVoucherStatus != SystemVariables.VoucherStatus.stActive)
			{
				SystemProcedure2.VoucherStatusErrorMessage(mOldVoucherStatus, 2);
				result = false;
				if (ControlHelper.GetEnabled(FirstFocusObject))
				{
					FirstFocusObject.Focus();
				}
				return result;
			}


			string pPayrollDate = SystemHRProcedure.GetPayrollGenerateDate();
			string mDtFrom = DateTimeHelper.ToString(ReflectionHelper.GetPrimitiveValue<System.DateTime>(txtCommonDate[conDTxtLeaveFromDate].DisplayText));
			//'Last Month Leave Transaction Will Not Be Post
			//If Format(DateAdd("m", 1, mDtFrom), "mm-yyyy") <> Format(pPayrollDate, "mm-yyyy") And Format(DateAdd("m", -1, mDtFrom), "mm-yyyy") <> Format(pPayrollDate, "mm-yyyy") And Format(mDtFrom, "mm-yyyy") <> Format(pPayrollDate, "mm-yyyy") Then
			//''' For Post all back dated leave
			//'''Changes on 05-jul-2009
			if (DateTime.Parse(mDtFrom) < DateTime.Parse(SystemHRProcedure.GetPayrollSalaryDate()))
			{
				MessageBox.Show("Back dated leave or advance leave more than one month is not allowed!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
				result = false;
				if (txtCommonDate[conDTxtLeaveFromDate].Enabled)
				{
					txtCommonDate[conDTxtLeaveFromDate].Focus();
				}
				return result;
			}
			//'''END

			//If mOldVoucherStatus = stActive Then
			//    frmTemp.VisiblePostTransactionToICS = False
			//    frmTemp.VisiblePostToGL = False
			//    frmTemp.EnableApprove = True
			//End If

			frmTemp.ShowDialog();

			//if the user clicks on OK button in the frmPost form
			//If frmTemp.mLastButtonClicked = 1 And frmTemp.mApprove = True Then
			if (frmTemp.mApprove)
			{

				if (CurrentFormMode == SystemVariables.SystemFormModes.frmAddMode)
				{
					//Display this message if status is active, which will require to save the record first
					ans = MessageBox.Show(SystemConstants.msg19 + "\r" + "\r" + SystemConstants.msg7, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.YesNo, MessageBoxIcon.Information);
				}
				else
				{
					//Display this message if status is not active, which will not require to save the record first
					ans = MessageBox.Show("                         Do you want to Post the Record ?                          " + "\r" + "\r" + "\r" + " NOTE :            Yes : To post after saving. " + "\r" + "                         No : To post without saving " + "\r" + "                         Cancel : To exit without posting ", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
				}

				if (CurrentFormMode == SystemVariables.SystemFormModes.frmAddMode)
				{
					if (ans == System.Windows.Forms.DialogResult.Yes)
					{
						goto mend;
					}
				}
				else
				{
					if (ans == System.Windows.Forms.DialogResult.Yes)
					{
						goto mend;
					}
					else if (ans == System.Windows.Forms.DialogResult.No)
					{ 
						if (frmTemp.mApprove)
						{
							SystemVariables.gConn.BeginTransaction();

							SystemHRProcedure.PayPostToHR("Pay_leave_transaction", ReflectionHelper.GetPrimitiveValue<int>(SearchValue));
							SystemHRProcedure.PayApprove("Pay_leave_transaction", ReflectionHelper.GetPrimitiveValue<int>(SearchValue));
							Post_Leave_Transaction(SearchValue);

							//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.CommitTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
							SystemVariables.gConn.CommitTrans();
						}
					}

					result = true;
					goto mDestroy;
				}
			}

			goto mDestroy;

			mend:
			//This goto will only come if the voucherstatus is still active
			if (CheckDataValidity())
			{
				if (saveRecord(frmTemp.mApprove))
				{
					result = true;
					goto mDestroy;
				}
			}
			result = false;

			mDestroy:
			frmTemp.Close();
			return result;
		}

		private void Post_Leave_Transaction(object pSearchValue)
		{
			try
			{
				object mReturnValue = null;
				object mReturnValue2 = null;
				object mReturnValue3 = null;
				object mReturnValue4 = null;
				string mysql = "";
				string mEmpNo = "";
				int mEmpCd = 0;
				int mTotalAdvanceDays = 0;
				int mTotalCurrentMonthDays = 0;
				DataSet rsLocalRec = new DataSet();
				object mSalary = null;
				decimal mSalaryDeduction = 0;
				int mSalaryWorkHrs = 0;
				int mSalaryWorkDays = 0;
				string mGenerateDate = "";
				bool mRegenerateLoan = false;
				System.DateTime mNextMonthGenerateDate = DateTime.FromOADate(0);
				int mleaveDays = 0;
				int mTotalDaysInNextMonth = 0;

				mysql = " select plt.paid_days, plt.unpaid_days, pemp.emp_cd ";
				mysql = mysql + " , plt.leave_cd , plt.leave_amount_payment_type_id , plt.leave_end_date";
				mysql = mysql + " , plt.leave_salary_amount , pemp.emp_no, pemp.emp_cd, l.leave_type_cd, plvt.auto_resume ";
				mysql = mysql + " from pay_leave_transaction plt";
				mysql = mysql + " inner join pay_leave l on l.leave_cd = plt.leave_cd";
				mysql = mysql + " inner join pay_leave_type plvt on plvt.type_cd = l.leave_type_cd";
				mysql = mysql + " inner join pay_employee pemp on pemp.emp_cd = plt.emp_cd ";
				mysql = mysql + " where plt.entry_id = " + ReflectionHelper.GetPrimitiveValue<string>(pSearchValue);
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));

				mysql = " update pay_employee_leave_details ";
				mysql = mysql + " set ";
				mysql = mysql + " paid_leave_taken_days = paid_leave_taken_days + " + ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(0));
				mysql = mysql + " , unpaid_leave_taken_days = unpaid_leave_taken_days + " + ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(1));
				mysql = mysql + " where emp_cd =" + ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(2));
				mysql = mysql + " and leave_cd =" + ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(3));
				SqlCommand TempCommand = null;
				TempCommand = SystemVariables.gConn.CreateCommand();
				TempCommand.CommandText = mysql;
				TempCommand.ExecuteNonQuery();

				SystemHRProcedure.enumTAFields mFieldId = (SystemHRProcedure.enumTAFields) 0;
				mGenerateDate = SystemHRProcedure.GetPayrollGenerateDate();
				//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mEmpNo = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(7));
				//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mEmpCd = ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue).GetValue(8));

				if (ReflectionHelper.GetPrimitiveValue<double>(((Array) mReturnValue).GetValue(9)) == 11)
				{
					mFieldId = SystemHRProcedure.enumTAFields.eTASickHours;
					//    mySql = " update pay_leave_transaction "
					//    mySql = mySql & " set resume_processed_status = 2"
					//    mySql = mySql & ", payroll_date = '" & Format(GetPayrollGenerateDate, gSystemDateFormat) & "'"
					//    mySql = mySql & " where entry_id =" & pSearchValue
					//    gConn.Execute mySql
					//For Absent Now no more leave transaction
					//ElseIf mReturnValue(9) = 12 Then
					//    mFieldId = eTAAbsentHours
					//    mySql = " update pay_leave_transaction "
					//    mySql = mySql & " set resume_processed_status = 2"
					//    mySql = mySql & ", payroll_date = '" & Format(GetPayrollGenerateDate, gSystemDateFormat) & "'"
					//    mySql = mySql & " where entry_id =" & pSearchValue
					//    gConn.Execute mySql
				}
				else
				{
					mFieldId = SystemHRProcedure.enumTAFields.eTAVacationHours;
					//    mySql = " update pay_employee "
					//    mySql = mySql & " set status_cd = " & gStatusOnLeave
					//    mySql = mySql & " where emp_no ='" & mEmpNo & "'"
					//    gConn.Execute mySql
				}

				//' For Auto Resume Leave
				//'Date: 17-Aug-2008

				string mActualResumeDate = "";
				if (ReflectionHelper.GetPrimitiveValue<double>(((Array) mReturnValue).GetValue(10)) != 0)
				{
					SystemProcedure.InsertAlarmDetails(2, ReflectionHelper.GetPrimitiveValue<int>(pSearchValue), txtCommonTextBox[conTxtComments].Text, DateTimeHelper.ToString(ReflectionHelper.GetPrimitiveValue<System.DateTime>(txtCommonDate[conDTxtLeaveToDate].Value).AddDays(1)));
					mActualResumeDate = ReflectionHelper.GetPrimitiveValue<System.DateTime>(txtCommonDate[conDTxtLeaveToDate].Value).AddDays(1).ToString("dd-MMM-yyyy");
					mysql = " update pay_leave_transaction ";
					mysql = mysql + " set resume_processed_status = 2";
					mysql = mysql + " , resumed_payroll_date ='" + SystemHRProcedure.GetPayrollGenerateDate() + "'";
					if (DateTime.Parse(mActualResumeDate) < DateTime.Parse(SystemHRProcedure.GetPayrollGenerateStartDate()))
					{
						mysql = mysql + ", Resume_ProcessDate = '" + StringsHelper.Format(SystemHRProcedure.GetPayrollGenerateStartDate(), SystemVariables.gSystemDateFormat) + "'";
					}
					else if (DateTime.Parse(mActualResumeDate) > DateTime.Parse(SystemHRProcedure.GetPayrollGenerateDate()))
					{ 
						mysql = mysql + ", Resume_ProcessDate = '" + StringsHelper.Format(SystemHRProcedure.GetPayrollGenerateDate(), SystemVariables.gSystemDateFormat) + "'";
					}
					else
					{
						mysql = mysql + ", Resume_ProcessDate = '" + mActualResumeDate + "'";
					}
					mysql = mysql + " where entry_id =" + ReflectionHelper.GetPrimitiveValue<string>(pSearchValue);
					SqlCommand TempCommand_2 = null;
					TempCommand_2 = SystemVariables.gConn.CreateCommand();
					TempCommand_2.CommandText = mysql;
					TempCommand_2.ExecuteNonQuery();
				}
				else
				{
					mysql = " update pay_employee ";
					mysql = mysql + " set status_cd = " + SystemHRProcedure.gStatusOnLeave.ToString();
					mysql = mysql + " where emp_no ='" + mEmpNo + "'";
					SqlCommand TempCommand_3 = null;
					TempCommand_3 = SystemVariables.gConn.CreateCommand();
					TempCommand_3.CommandText = mysql;
					TempCommand_3.ExecuteNonQuery();
				}

				//'' Date:02-Jan-2012
				//''For Updating process Date in Leave Transaction
				mysql = " update pay_leave_transaction ";
				mysql = mysql + " set  payroll_date = '" + StringsHelper.Format(SystemHRProcedure.GetPayrollGenerateDate(), SystemVariables.gSystemDateFormat) + "'";
				if (ReflectionHelper.GetPrimitiveValue<System.DateTime>(txtCommonDate[conDTxtLeaveFromDate].Value) < DateTime.Parse(SystemHRProcedure.GetPayrollGenerateStartDate()))
				{
					mysql = mysql + ", processDate = '" + StringsHelper.Format(SystemHRProcedure.GetPayrollGenerateStartDate(), SystemVariables.gSystemDateFormat) + "'";
				}
				else if (ReflectionHelper.GetPrimitiveValue<System.DateTime>(txtCommonDate[conDTxtLeaveFromDate].Value) > DateTime.Parse(SystemHRProcedure.GetPayrollGenerateDate()))
				{ 
					mysql = mysql + ", processDate = '" + StringsHelper.Format(SystemHRProcedure.GetPayrollGenerateDate(), SystemVariables.gSystemDateFormat) + "'";
				}
				else
				{
					mysql = mysql + ", processDate = '" + ReflectionHelper.GetPrimitiveValue<string>(txtCommonDate[conDTxtLeaveFromDate].Value) + "'";
				}
				mysql = mysql + " where entry_id =" + ReflectionHelper.GetPrimitiveValue<string>(pSearchValue);
				SqlCommand TempCommand_4 = null;
				TempCommand_4 = SystemVariables.gConn.CreateCommand();
				TempCommand_4.CommandText = mysql;
				TempCommand_4.ExecuteNonQuery();

				//'End


				UpdateTimeAttendanceOnPost(mEmpCd, txtCommonDate[conDTxtLeaveFromDate].Text, txtCommonDate[conDTxtLeaveToDate].Text, mFieldId, ReflectionHelper.GetPrimitiveValue<bool>(((Array) mReturnValue).GetValue(10)));

				mysql = "select leave_amount_payment_type_id from pay_leave_transaction where entry_id =" + ReflectionHelper.GetPrimitiveValue<string>(pSearchValue);
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
				mRegenerateLoan = chkLoanGenrate.CheckState == CheckState.Checked;

				//If mReturnValue = 53 And GetSystemPreferenceSetting("include_basic_salary_in_paynow") = True Then
				if (ReflectionHelper.GetPrimitiveValue<double>(mReturnValue) == SystemHRProcedure.gPayNow || ReflectionHelper.GetPrimitiveValue<double>(mReturnValue) == SystemHRProcedure.gPayNowWithAdvance)
				{
					if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("generate_loan_during_leave")))
					{
						SystemHRProcedure.ClearPayroll(mGenerateDate, mEmpNo, mEmpNo, true, mRegenerateLoan);
					}
					else
					{
						SystemHRProcedure.ClearPayroll(mGenerateDate, mEmpNo, mEmpNo, false, mRegenerateLoan);
					}

					SystemHRProcedure.GeneratePayrollEntry(mGenerateDate, mEmpNo, mEmpNo);
					SystemHRProcedure.GenerateLeaveEntry(mGenerateDate, mEmpNo, mEmpNo);
					SystemHRProcedure.GenerateLoanEntry(mGenerateDate, mEmpNo, mEmpNo, null, mRegenerateLoan);


					//'''modified by hakim on 28-may-2009
					//'''added new field "additional_salary_deduction", this will be used for deduction amount. "addtional_salary" field will be used for earning.
					//'''Both will have earning and deductino except the entry generated in pay payroll from leave transaction
					//    mySQL = " select isnull((select sum( case when pbt1.bill_type_id = 51 then lc_amount else 0 end) as earnings "
					//    mySQL = mySQL & " , isnull((select sum( case when pbt1.bill_type_id = 52 then lc_amount else 0 end) as deduction  "
					//    mySQL = mySQL & " from pay_payroll pp1 inner join pay_billing_type pbt1 on pp1.bill_cd = pbt1.bill_cd "
					//    mySQL = mySQL & " Where pp1.emp_cd = pemp.emp_cd and pp1.pay_date = pp.pay_date),0) as total_salary "
					//    mySQL = mySQL & " from pay_employee pemp inner join (select distinct pay_date, emp_cd from pay_payroll ) pp "
					//    mySQL = mySQL & " on pemp.emp_cd = pp.emp_cd "
					//    mySQL = mySQL & " where pay_date = '" & mGenerateDate & "' and emp_no='" & mEmpNo & "'"
					//    mySQL = mySQL & " and pp1.trans_type <> 'LeaveTrn' "
					//    mySQL = mySQL & " and pp1.trans_id not in (" & pSearchValue & ")"


					mysql = " select isnull(sum( case when pbt.bill_type_id = 51 then pp.lc_amount else 0 end),0) as earnings ";
					mysql = mysql + " , isnull(sum( case when pbt.bill_type_id = 52 then pp.lc_amount else 0 end),0) as deduction ";
					mysql = mysql + " from pay_employee pemp ";
					mysql = mysql + " inner join pay_payroll pp  on pemp.emp_cd = pp.emp_cd ";
					mysql = mysql + " inner join pay_billing_type pbt on pp.bill_cd = pbt.bill_cd ";
					mysql = mysql + " where pp.pay_date = '" + mGenerateDate + "'";
					mysql = mysql + " and pemp.emp_no='" + mEmpNo + "'";
					//mySQL = mySQL & " and (pp.trans_id <> pSearchValue or pp.trans_type is null ) "
					mysql = mysql + " and (pp.trans_id <> " + ReflectionHelper.GetPrimitiveValue<string>(pSearchValue) + "  or pp.trans_id is null) ";


					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValue2 = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
					//UPGRADE_WARNING: (1068) mReturnValue2() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mSalary = ReflectionHelper.GetPrimitiveValue(((Array) mReturnValue2).GetValue(0));
					//UPGRADE_WARNING: (1068) mReturnValue2() of type Variant is being forced to decimal. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mSalaryDeduction = ReflectionHelper.GetPrimitiveValue<decimal>(((Array) mReturnValue2).GetValue(1));

					mysql = " select isnull(sum(pay_hours),0), isnull(sum(pay_days),0) ";
					mysql = mysql + " from pay_payroll pp";
					mysql = mysql + " inner join pay_employee pemp on pemp.emp_cd = pp.emp_cd";
					mysql = mysql + " where pay_date = '" + mGenerateDate + "' and emp_no='" + mEmpNo + "' and bill_cd = 1 and pp.trans_type <> 'LeaveExtTrn'";
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValue2 = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (!Convert.IsDBNull(mReturnValue2))
					{
						//UPGRADE_WARNING: (1068) mReturnValue2() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mSalaryWorkHrs = ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue2).GetValue(0));
						//UPGRADE_WARNING: (1068) mReturnValue2() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mSalaryWorkDays = ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue2).GetValue(1));
					}
					else
					{
						mSalaryWorkHrs = 0;
						mSalaryWorkDays = 0;
					}
					// Add Leave Extra Days
					if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("Generate_Extra_Day_On_Leave")))
					{
						mysql = " select isnull(sum( case when pbt.bill_type_id = 51 then pp.pay_hours else (pp.pay_hours * -1) end),0)";
						mysql = mysql + " , isnull(sum(case when pbt.bill_type_id = 51 then pp.pay_days else (pp.pay_days * -1) end),0) ";
						mysql = mysql + " , isnull(sum(case when pbt.bill_type_id = 51 then pp.lc_amount else (pp.lc_amount * -1) end),0) ";
						mysql = mysql + " from pay_payroll pp";
						mysql = mysql + " inner join pay_billing_type pbt on pbt.bill_cd = pp.bill_cd";
						mysql = mysql + " inner join pay_employee pemp on pemp.emp_cd = pp.emp_cd";
						mysql = mysql + " where pay_date = '" + mGenerateDate + "' and emp_no='" + mEmpNo + "' and pp.trans_type = 'LeaveExtTrn'";
						//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mReturnValue3 = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
						if (!Convert.IsDBNull(mReturnValue3))
						{
							mSalaryWorkHrs = Convert.ToInt32(mSalaryWorkHrs + ReflectionHelper.GetPrimitiveValue<double>(((Array) mReturnValue3).GetValue(0)));
							mSalaryWorkDays = Convert.ToInt32(mSalaryWorkDays + ReflectionHelper.GetPrimitiveValue<double>(((Array) mReturnValue3).GetValue(1)));
							if (ReflectionHelper.GetPrimitiveValue<double>(((Array) mReturnValue3).GetValue(2)) < 0)
							{
								//UPGRADE-WARNING: It was not possible to determine if this addition expression should use an addition operator (+) or a concatenation operator (&)
								mSalary = ReflectionHelper.GetPrimitiveValue<double>(mSalary) + ReflectionHelper.GetPrimitiveValue<double>(((Array) mReturnValue3).GetValue(2));
								mSalaryDeduction -= ((decimal) Math.Abs(ReflectionHelper.GetPrimitiveValue<double>(((Array) mReturnValue3).GetValue(2))));
							}
						}
					}

					if (ReflectionHelper.GetPrimitiveValue<double>(mReturnValue) == SystemHRProcedure.gPayNowWithAdvance)
					{
						//' 28-Oct-2008 For Advance Salary
						mNextMonthGenerateDate = DateTime.Parse(StringsHelper.Format(DateTime.Parse(SystemHRProcedure.GetPayrollGenerateStartDate()).AddMonths(2).AddDays(-1), SystemVariables.gSystemDateFormat));
						mysql = "select leave_start_date,weekend_day1_id,weekend_day2_id";
						mysql = mysql + " ,total_salary,additional_salary,rate_calc_method_id, days_per_month,leave_days,public_holidays,leave_end_date";
						mysql = mysql + " from pay_leave_transaction";
						mysql = mysql + " where status = 2 "; //'''''''' Check
						mysql = mysql + " and emp_cd = " + mEmpCd.ToString();
						mysql = mysql + " and leave_start_date >'" + StringsHelper.Format(DateTime.Parse(SystemHRProcedure.GetPayrollGenerateDate()).AddDays(1), SystemVariables.gSystemDateFormat) + "'";
						mysql = mysql + " and leave_start_date <='" + DateTimeHelper.ToString(mNextMonthGenerateDate) + "'";
						//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mReturnValue4 = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));

						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
						if (!Convert.IsDBNull(mReturnValue4))
						{ //And .Fields("bill_cd") = 1 Then
							mTotalAdvanceDays = Convert.ToInt32(SystemHRProcedure.CalculateDays(DateTime.Parse(SystemHRProcedure.GetPayrollGenerateDate()).AddDays(1), ReflectionHelper.GetPrimitiveValue<System.DateTime>(((Array) mReturnValue4).GetValue(0)).AddDays(-1), ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue4).GetValue(1)), ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue4).GetValue(2))));
							if (ReflectionHelper.GetPrimitiveValue<System.DateTime>(((Array) mReturnValue4).GetValue(9)) >= mNextMonthGenerateDate)
							{
								mleaveDays = Convert.ToInt32(SystemHRProcedure.CalculateDays(ReflectionHelper.GetPrimitiveValue<System.DateTime>(((Array) mReturnValue4).GetValue(0)), mNextMonthGenerateDate, ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue4).GetValue(1)), ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue4).GetValue(2))) - SystemHRProcedure.GetPublicHolidays(ReflectionHelper.GetPrimitiveValue<System.DateTime>(((Array) mReturnValue4).GetValue(0)), mNextMonthGenerateDate));
							}
							else
							{
								mleaveDays = Convert.ToInt32(SystemHRProcedure.CalculateDays(ReflectionHelper.GetPrimitiveValue<System.DateTime>(((Array) mReturnValue4).GetValue(0)), ReflectionHelper.GetPrimitiveValue<System.DateTime>(((Array) mReturnValue4).GetValue(9)), ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue4).GetValue(1)), ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue4).GetValue(2))) - SystemHRProcedure.GetPublicHolidays(ReflectionHelper.GetPrimitiveValue<System.DateTime>(((Array) mReturnValue4).GetValue(0)), ReflectionHelper.GetPrimitiveValue<System.DateTime>(((Array) mReturnValue4).GetValue(9))));
							}
							if (ReflectionHelper.GetPrimitiveValue<double>(((Array) mReturnValue4).GetValue(5)) == 60)
							{
								if ((mTotalAdvanceDays + mleaveDays) > ReflectionHelper.GetPrimitiveValue<double>(((Array) mReturnValue4).GetValue(6)))
								{
									if (!ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("Generate_Extra_Day_On_Leave")))
									{
										mTotalAdvanceDays = Convert.ToInt32(ReflectionHelper.GetPrimitiveValue<double>(((Array) mReturnValue4).GetValue(6)) - mleaveDays);
									}
									mSalary = (ReflectionHelper.GetPrimitiveValue<double>(mSalary) / ((double) mSalaryWorkDays)) * mTotalAdvanceDays;
								}
								else
								{
									//If Leave End In Next Month Before Next Month Close
									mSalary = (ReflectionHelper.GetPrimitiveValue<double>(mSalary) / ((double) mSalaryWorkDays)) * mTotalAdvanceDays;
								}
							}
							else if (ReflectionHelper.GetPrimitiveValue<double>(((Array) mReturnValue4).GetValue(5)) == 61)
							{ 
								mTotalDaysInNextMonth = Convert.ToInt32(SystemHRProcedure.CalculateDays(DateTime.Parse(SystemHRProcedure.GetPayrollGenerateDate()).AddDays(1), mNextMonthGenerateDate, ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue4).GetValue(1)), ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue4).GetValue(2))));
								if ((mTotalAdvanceDays + mleaveDays) > mTotalDaysInNextMonth)
								{
									mTotalAdvanceDays = mTotalDaysInNextMonth - mleaveDays;
									mSalary = (ReflectionHelper.GetPrimitiveValue<double>(mSalary) / ((double) mTotalDaysInNextMonth)) * mTotalAdvanceDays;
								}
								else
								{
									mSalary = (ReflectionHelper.GetPrimitiveValue<double>(mSalary) / ((double) mTotalDaysInNextMonth)) * mTotalAdvanceDays;
								}
							}
						}

						mSalaryWorkHrs = (Convert.ToInt32((mSalaryWorkHrs / ((double) mSalaryWorkDays)) * mTotalAdvanceDays));

						mysql = "update pay_leave_transaction SET additional_salary=" + ReflectionHelper.GetPrimitiveValue<string>(mSalary);
						mysql = mysql + " , additional_salary_deduction =" + mSalaryDeduction.ToString();
						mysql = mysql + " , pay_now_hours =" + mSalaryWorkHrs.ToString();
						mysql = mysql + " , payroll_worked_days =" + mTotalAdvanceDays.ToString();
						mysql = mysql + " where entry_id = " + ReflectionHelper.GetPrimitiveValue<string>(pSearchValue);
						SqlCommand TempCommand_5 = null;
						TempCommand_5 = SystemVariables.gConn.CreateCommand();
						TempCommand_5.CommandText = mysql;
						TempCommand_5.ExecuteNonQuery();

						mysql = "update pay_payroll_master";
						mysql = mysql + " set pay_now_hours = pay_now_hours + " + mSalaryWorkHrs.ToString();
						mysql = mysql + " where pay_date = '" + mGenerateDate + "' and emp_cd=" + SystemHRProcedure.GetEmpCd(mEmpNo).ToString();
						SqlCommand TempCommand_6 = null;
						TempCommand_6 = SystemVariables.gConn.CreateCommand();
						TempCommand_6.CommandText = mysql;
						TempCommand_6.ExecuteNonQuery();
						//'END Advance Salary
					}
					else
					{
						mysql = "update pay_leave_transaction SET additional_salary=" + ReflectionHelper.GetPrimitiveValue<string>(mSalary);
						mysql = mysql + " , additional_salary_deduction =" + mSalaryDeduction.ToString();
						mysql = mysql + " , pay_now_hours =" + mSalaryWorkHrs.ToString();
						mysql = mysql + " , payroll_worked_days =" + mSalaryWorkDays.ToString();
						mysql = mysql + " where entry_id = " + ReflectionHelper.GetPrimitiveValue<string>(pSearchValue);
						SqlCommand TempCommand_7 = null;
						TempCommand_7 = SystemVariables.gConn.CreateCommand();
						TempCommand_7.CommandText = mysql;
						TempCommand_7.ExecuteNonQuery();

						mysql = "update pay_payroll_master";
						mysql = mysql + " set pay_now_hours = pay_now_hours + " + mSalaryWorkHrs.ToString();
						mysql = mysql + " where pay_date = '" + mGenerateDate + "' and emp_cd=" + SystemHRProcedure.GetEmpCd(mEmpNo).ToString();
						SqlCommand TempCommand_8 = null;
						TempCommand_8 = SystemVariables.gConn.CreateCommand();
						TempCommand_8.CommandText = mysql;
						TempCommand_8.ExecuteNonQuery();
					}



					//ElseIf mReturnValue = 53 And GetSystemPreferenceSetting("include_basic_salary_in_paynow") = False Then
				}
				else if (ReflectionHelper.GetPrimitiveValue<double>(mReturnValue) == SystemHRProcedure.gPayNowExcludingBasic)
				{  //Pay Now Excluding Basic
					mysql = "update pay_leave_transaction SET additional_salary= 0, additional_salary_deduction= 0 ,pay_now_hours = 0, Pay_Now_Days = 0";
					mysql = mysql + " where entry_id = " + ReflectionHelper.GetPrimitiveValue<string>(pSearchValue);
					SqlCommand TempCommand_9 = null;
					TempCommand_9 = SystemVariables.gConn.CreateCommand();
					TempCommand_9.CommandText = mysql;
					TempCommand_9.ExecuteNonQuery();
				}


				//' For Alarm As On 05-Oct-2008
				//Call AlarmStatusUpdate(1, CLng(mSearchValue), 1)
				SystemProcedure.InsertAlarmDetails(2, ReflectionHelper.GetPrimitiveValue<int>(mSearchValue), txtCommonTextBox[conTxtComments].Text, DateTimeHelper.ToString(ReflectionHelper.GetPrimitiveValue<System.DateTime>(txtCommonDate[conDTxtLeaveToDate].Value).AddDays(1)));
				//'End

				if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("generate_loan_during_leave")))
				{
					SystemHRProcedure.ClearPayroll(mGenerateDate, mEmpNo, mEmpNo, true, mRegenerateLoan);
				}
				else
				{
					SystemHRProcedure.ClearPayroll(mGenerateDate, mEmpNo, mEmpNo, false, mRegenerateLoan);
				}

				SystemHRProcedure.GeneratePayrollEntry(mGenerateDate, mEmpNo, mEmpNo);
				SystemHRProcedure.GenerateLeaveEntry(mGenerateDate, mEmpNo, mEmpNo);
				SystemHRProcedure.GenerateLoanEntry(mGenerateDate, mEmpNo, mEmpNo, null, mRegenerateLoan);

				if (ReflectionHelper.GetPrimitiveValue<double>(mReturnValue) == SystemHRProcedure.gPayNow)
				{
					mysql = "insert into Pay_Leave_Transacrion_Payroll_Details";
					mysql = mysql + " (leave_entry_id,payroll_entry_id,pay_date,emp_cd,bill_cd,billing_mode";
					mysql = mysql + " ,pay_hours,pay_days,exchange_rate,fc_amount,comments,user_cd";
					mysql = mysql + " )";
					mysql = mysql + " select " + ReflectionHelper.GetPrimitiveValue<string>(pSearchValue) + " , ppm.entry_id, ppm.pay_date, ppm.emp_cd , pp.bill_cd, pp.billing_mode ";
					mysql = mysql + " , pp.pay_hours, pp.pay_days, pp.exchange_rate, pp.fc_amount, pp.comments, pp.user_cd";
					mysql = mysql + "  from pay_payroll pp";
					mysql = mysql + " inner join pay_payroll_master ppm on ppm.entry_id = pp.master_entry_id";
					mysql = mysql + " where ppm.emp_cd = " + SystemHRProcedure.GetEmpCd(mEmpNo).ToString() + " and ppm.pay_date = '" + SystemHRProcedure.GetPayrollGenerateDate() + "'";
					SqlCommand TempCommand_10 = null;
					TempCommand_10 = SystemVariables.gConn.CreateCommand();
					TempCommand_10.CommandText = mysql;
					TempCommand_10.ExecuteNonQuery();
				}

				//''' End Add
			}
			catch (System.Exception excep)
			{
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				//UPGRADE_ISSUE: (1046) MsgBox Parameter 'context' is not supported, and was removed. More Information: https://docs.mobilize.net/vbuc/ewis#1046
				//UPGRADE_ISSUE: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed. More Information: https://docs.mobilize.net/vbuc/ewis#1046
				Interaction.MsgBox(excep.Message, (MsgBoxStyle) Information.Err().Number, "");
				//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
				try
				{
					//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					SystemVariables.gConn.RollbackTrans();
				}
				catch (Exception exc)
				{
					NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
				}
			}
		}



		public bool UnPost()
		{



			bool result = false;
			if (CurrentFormMode == SystemVariables.SystemFormModes.frmAddMode)
			{
				MessageBox.Show("You are currently in AddMode!!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
				return false;
			}

			if (mOldVoucherStatus == SystemVariables.VoucherStatus.stActive)
			{
				MessageBox.Show("Voucher is not posted!!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
				return false;
			}



			string mGenerateDate = SystemHRProcedure.GetPayrollGenerateDate();

			string mysql = " select plt.leave_start_date, pl.leave_type_cd from pay_leave_transaction plt ";
			mysql = mysql + " inner join pay_leave pl on pl.leave_cd = plt.leave_cd ";
			mysql = mysql + " where plt.entry_id =" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
			//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));

			//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			string mLeaveFromDate = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(0));
			//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			int mLeaveTypeCd = ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue).GetValue(1));

			mysql = "select is_pay_closed from pay_leave_transaction where entry_id =" + ReflectionHelper.GetPrimitiveValue<int>(mSearchValue).ToString();
			//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));

			if (ReflectionHelper.GetPrimitiveValue<bool>(mReturnValue))
			{
				MessageBox.Show("Can not Unpost, Payroll month is closed!!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
				return false;
			}

			if (mLeaveTypeCd == 6)
			{
				mysql = "select resume_processed_status from pay_leave_transaction where entry_id=" + ReflectionHelper.GetPrimitiveValue<int>(mSearchValue).ToString();
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
				if (ReflectionHelper.GetPrimitiveValue<double>(mReturnValue) == 2)
				{
					MessageBox.Show("Cannot Unpost voucher. Employee Resumption transaction already posted for this Transaction!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					return false;
				}
			}

			mysql = "select count(*) from pay_leave_transaction plt  ";
			mysql = mysql + " inner join pay_employee pemp on plt.emp_cd = pemp.emp_cd ";
			mysql = mysql + " where pemp.emp_no ='" + txtCommonTextBox[conTxtEmpCode].Text + "' and leave_start_date > '" + mLeaveFromDate + "'";

			//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
			if (ReflectionHelper.GetPrimitiveValue<double>(mReturnValue) > 0)
			{
				MessageBox.Show("Can not Unpost, Transaction(s) after date " + mLeaveFromDate + " already exits!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
				return false;
			}


			DialogResult ans = MessageBox.Show("Do you want to Unpost the Record ?", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);

			string myString = "";
			if (ans == System.Windows.Forms.DialogResult.Yes)
			{
				SystemVariables.gConn.BeginTransaction();

				//Call PayPostToHR("Pay_leave_transaction", CLng(SearchValue))


				myString = "update Pay_leave_transaction ";
				myString = myString + " set posted_HR = 0 ";
				myString = myString + " where entry_id =" + ReflectionHelper.GetPrimitiveValue<string>(SearchValue);
				SqlCommand TempCommand = null;
				TempCommand = SystemVariables.gConn.CreateCommand();
				TempCommand.CommandText = myString;
				TempCommand.ExecuteNonQuery();

				//Call PayApprove("Pay_leave_transaction", CLng(SearchValue))
				myString = "update Pay_leave_transaction ";
				myString = myString + " set status = 1 ";
				myString = myString + " where entry_id =" + ReflectionHelper.GetPrimitiveValue<string>(SearchValue);
				SqlCommand TempCommand_2 = null;
				TempCommand_2 = SystemVariables.gConn.CreateCommand();
				TempCommand_2.CommandText = myString;
				TempCommand_2.ExecuteNonQuery();

				Unpost_Leave_Transaction(SearchValue);

				//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.CommitTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				SystemVariables.gConn.CommitTrans();
				result = true;
				AddRecord();
			}
			else if (ans == System.Windows.Forms.DialogResult.No)
			{ 
				AddRecord();
				result = false;
			}
			else if (ans == System.Windows.Forms.DialogResult.Cancel)
			{ 
				result = false;
			}


			return result;
		}

		private void Unpost_Leave_Transaction(object pSearchValue)
		{
			DataSet rsLocalRec = new DataSet();

			string mysql = " select plt.paid_days, plt.unpaid_days, pemp.emp_cd ";
			mysql = mysql + " , plt.leave_cd , plt.leave_amount_payment_type_id , plt.leave_end_date";
			mysql = mysql + " , plt.leave_salary_amount ,pemp.emp_no, l.leave_type_cd,plvt.auto_resume ";
			mysql = mysql + " from pay_leave_transaction plt";
			mysql = mysql + " inner join pay_leave l on l.leave_cd = plt.leave_cd ";
			mysql = mysql + " inner join pay_leave_type plvt on l.leave_type_cd = plvt.type_cd ";
			mysql = mysql + " inner join pay_employee pemp on pemp.emp_cd = plt.emp_cd ";
			mysql = mysql + " where plt.entry_id = " + ReflectionHelper.GetPrimitiveValue<string>(pSearchValue);
			//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));

			mysql = " update pay_employee_leave_details ";
			mysql = mysql + " set ";
			mysql = mysql + " paid_leave_taken_days = paid_leave_taken_days - " + ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(0));
			mysql = mysql + " , unpaid_leave_taken_days = unpaid_leave_taken_days - " + ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(1));
			mysql = mysql + " where emp_cd =" + ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(2));
			mysql = mysql + " and leave_cd =" + ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(3));
			SqlCommand TempCommand = null;
			TempCommand = SystemVariables.gConn.CreateCommand();
			TempCommand.CommandText = mysql;
			TempCommand.ExecuteNonQuery();

			mysql = " delete from Pay_Leave_Transacrion_Payroll_Details";
			mysql = mysql + " where leave_entry_id =" + ReflectionHelper.GetPrimitiveValue<string>(pSearchValue);
			SqlCommand TempCommand_2 = null;
			TempCommand_2 = SystemVariables.gConn.CreateCommand();
			TempCommand_2.CommandText = mysql;
			TempCommand_2.ExecuteNonQuery();

			SystemHRProcedure.enumTAFields mFieldId = (SystemHRProcedure.enumTAFields) 0;

			string mGenerateDate = SystemHRProcedure.GetPayrollGenerateDate();
			//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			string mEmpNo = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(7));
			//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			int mEmpCd = ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue).GetValue(2));

			if (ReflectionHelper.GetPrimitiveValue<double>(((Array) mReturnValue).GetValue(8)) == 11)
			{
				mFieldId = SystemHRProcedure.enumTAFields.eTASickHours;
				//ElseIf mReturnValue(8) = 12 Then
				//    mFieldId = eTAAbsentHours
			}
			else
			{
				mFieldId = SystemHRProcedure.enumTAFields.eTAVacationHours;
			}
			//' For Auto Resume
			//'Date:18-Aug-2008
			if (ReflectionHelper.GetPrimitiveValue<double>(((Array) mReturnValue).GetValue(9)) == 0)
			{
				mysql = " update pay_employee ";
				mysql = mysql + " set status_cd = " + SystemHRProcedure.gStatusActive.ToString();
				mysql = mysql + " where emp_no ='" + mEmpNo + "'";
				SqlCommand TempCommand_3 = null;
				TempCommand_3 = SystemVariables.gConn.CreateCommand();
				TempCommand_3.CommandText = mysql;
				TempCommand_3.ExecuteNonQuery();

			}
			else
			{
				mysql = " update pay_leave_transaction ";
				mysql = mysql + " set resume_processed_status = 1";
				mysql = mysql + ", payroll_date = '" + StringsHelper.Format(SystemHRProcedure.GetPayrollGenerateDate(), SystemVariables.gSystemDateFormat) + "'";
				mysql = mysql + " where entry_id =" + ReflectionHelper.GetPrimitiveValue<string>(pSearchValue);
				SqlCommand TempCommand_4 = null;
				TempCommand_4 = SystemVariables.gConn.CreateCommand();
				TempCommand_4.CommandText = mysql;
				TempCommand_4.ExecuteNonQuery();

			}
			//'End

			UpdateTimeAttendanceOnUnpost(mEmpCd, txtCommonDate[conDTxtLeaveFromDate].Text, txtCommonDate[conDTxtLeaveToDate].Text, mFieldId, ReflectionHelper.GetPrimitiveValue<bool>(((Array) mReturnValue).GetValue(9)));
			if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("generate_loan_during_leave")))
			{
				SystemHRProcedure.ClearPayroll(mGenerateDate, mEmpNo, mEmpNo, false);
			}
			else
			{
				SystemHRProcedure.ClearPayroll(mGenerateDate, mEmpNo, mEmpNo, true);
			}

			SystemHRProcedure.GeneratePayrollEntry(mGenerateDate, mEmpNo, mEmpNo);
			SystemHRProcedure.GenerateLeaveEntry(mGenerateDate, mEmpNo, mEmpNo);
			SystemHRProcedure.GenerateLoanEntry(mGenerateDate, mEmpNo, mEmpNo);

			//'''Added By Burhan Ghee Wala
			//'''Date : 7-Jul-2007

			mysql = "select leave_amount_payment_type_id from pay_leave_transaction where entry_id =" + ReflectionHelper.GetPrimitiveValue<string>(pSearchValue);
			//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));

			if (ReflectionHelper.GetPrimitiveValue<double>(mReturnValue) == SystemHRProcedure.gPayNow)
			{ // if pay now option selected from combo box then only
				mysql = "update pay_leave_transaction SET additional_salary=0, additional_salary_deduction=0,  pay_now_hours = 0";
				mysql = mysql + " where entry_id = " + ReflectionHelper.GetPrimitiveValue<string>(pSearchValue);
				SqlCommand TempCommand_5 = null;
				TempCommand_5 = SystemVariables.gConn.CreateCommand();
				TempCommand_5.CommandText = mysql;
				TempCommand_5.ExecuteNonQuery();
			}

			SystemProcedure.AlarmDelete(2, ReflectionHelper.GetPrimitiveValue<int>(mSearchValue));
			//Call AlarmStatusUpdate(1, CLng(mSearchValue), 0)

			if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("generate_loan_during_leave")))
			{
				SystemHRProcedure.ClearPayroll(mGenerateDate, mEmpNo, mEmpNo, false);
			}
			else
			{
				SystemHRProcedure.ClearPayroll(mGenerateDate, mEmpNo, mEmpNo, true);
			}

			SystemHRProcedure.GeneratePayrollEntry(mGenerateDate, mEmpNo, mEmpNo);
			SystemHRProcedure.GenerateLeaveEntry(mGenerateDate, mEmpNo, mEmpNo);
			SystemHRProcedure.GenerateLoanEntry(mGenerateDate, mEmpNo, mEmpNo);

			mysql = " delete from Pay_Leave_Transacrion_Payroll_Details";
			mysql = mysql + " where leave_entry_id = " + ReflectionHelper.GetPrimitiveValue<string>(pSearchValue);
			SqlCommand TempCommand_6 = null;
			TempCommand_6 = SystemVariables.gConn.CreateCommand();
			TempCommand_6.CommandText = mysql;
			TempCommand_6.ExecuteNonQuery();

			if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("enable_approvals")))
			{
				mysql = " update pay_leave_transaction ";
				mysql = mysql + " set  Approval_Stage = 0 ";
				mysql = mysql + " where entry_id =" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
				SqlCommand TempCommand_7 = null;
				TempCommand_7 = SystemVariables.gConn.CreateCommand();
				TempCommand_7.CommandText = mysql;
				TempCommand_7.ExecuteNonQuery();
			}

			//''' End Add
		}

		private bool UpdateTimeAttendanceOnPost(int pEmpCd, string pFromDate, string pToDate, SystemHRProcedure.enumTAFields pFieldType, bool pAutoResume)
		{
			int mEntryId = 0;
			int mWorkHrsEntId = 0;
			int mReserveEntId = 0;

			double mPerDayHrs = SystemHRProcedure.GetEmpPerDayHours(pEmpCd);
			string mStartDate = SystemHRProcedure.GetPayrollGenerateStartDate();
			string mGenerateDate = SystemHRProcedure.GetPayrollGenerateDate();

			//Do not Update Daily Wages employee whoes generate Default hours is
			//If GetSystemPreferenceSetting("Generate_AttHrs_For_DailyWage") = False And mReturnValue(1) = 130 Then
			//    Exit Function
			//End If

			//To Update Deuction Hours in TNA only if cut off is enabled
			SystemHRProcedure.UpdateDeductionHoursForLeave(pEmpCd, pFromDate, pToDate, mPerDayHrs, pFieldType, pAutoResume, mIsPayClosed, 1);

			switch(pFieldType)
			{
				case SystemHRProcedure.enumTAFields.eTAVacationHours : 
					if (DateTime.Parse(mGenerateDate) >= DateTime.Parse(pFromDate))
					{
						//If Leave date is coming in this month then update work hours from start date to payroll generate date
						mWorkHrsEntId = SystemHRProcedure.GetTAEntryID(pEmpCd, SystemHRProcedure.enumTAFields.eTAWorkHours, DateTime.Parse(mGenerateDate).Year, DateTime.Parse(mGenerateDate).Month);
						mEntryId = SystemHRProcedure.GetTAEntryID(pEmpCd, SystemHRProcedure.enumTAFields.eTAVacationHours, DateTime.Parse(mGenerateDate).Year, DateTime.Parse(mGenerateDate).Month);
						SystemHRProcedure.PostLeaveInTimeAttendance(mWorkHrsEntId, mEntryId, mPerDayHrs, pToDate, pFromDate);
					} 
					break;
				case SystemHRProcedure.enumTAFields.eTASickHours : 
					if (DateTime.Parse(mGenerateDate) >= DateTime.Parse(pFromDate))
					{
						//If Leave date is coming in this month then update work hours from start date to payroll generate date
						mWorkHrsEntId = SystemHRProcedure.GetTAEntryID(pEmpCd, SystemHRProcedure.enumTAFields.eTAWorkHours, DateTime.Parse(mGenerateDate).Year, DateTime.Parse(mGenerateDate).Month);
						mEntryId = SystemHRProcedure.GetTAEntryID(pEmpCd, SystemHRProcedure.enumTAFields.eTASickHours, DateTime.Parse(mGenerateDate).Year, DateTime.Parse(mGenerateDate).Month);
						SystemHRProcedure.PostLeaveInTimeAttendance(mWorkHrsEntId, mEntryId, mPerDayHrs, pToDate, pFromDate);
					} 
					break;
				case SystemHRProcedure.enumTAFields.eTAAbsentHours : 
					if (DateTime.Parse(mGenerateDate) >= DateTime.Parse(pFromDate))
					{
						//If Leave date is coming in this month then update work hours from start date to payroll generate date
						mWorkHrsEntId = SystemHRProcedure.GetTAEntryID(pEmpCd, SystemHRProcedure.enumTAFields.eTAWorkHours, DateTime.Parse(mGenerateDate).Year, DateTime.Parse(mGenerateDate).Month);
						mEntryId = SystemHRProcedure.GetTAEntryID(pEmpCd, SystemHRProcedure.enumTAFields.eTAAbsentHours, DateTime.Parse(mGenerateDate).Year, DateTime.Parse(mGenerateDate).Month);
						SystemHRProcedure.PostLeaveInTimeAttendance(mWorkHrsEntId, mEntryId, mPerDayHrs, pToDate, pFromDate);
					} 
					break;
			}
			//' Updated reserve hrs if auto resumed is false
			if (!pAutoResume)
			{
				mReserveEntId = SystemHRProcedure.GetTAEntryID(pEmpCd, SystemHRProcedure.enumTAFields.eTAReserveHours, DateTime.Parse(mGenerateDate).Year, DateTime.Parse(mGenerateDate).Month);
				mWorkHrsEntId = SystemHRProcedure.GetTAEntryID(pEmpCd, SystemHRProcedure.enumTAFields.eTAWorkHours, DateTime.Parse(mGenerateDate).Year, DateTime.Parse(mGenerateDate).Month);
				SystemHRProcedure.PostReserveHrsInTimeAttendance(mReserveEntId, mWorkHrsEntId, pToDate, mPerDayHrs);
			}
			//' End

			SystemHRProcedure.UpdateDailyWagesEmployeeEarnInTA(pEmpCd, pEmpCd);
			return false;
		}

		private bool UpdateTimeAttendanceOnUnpost(int pEmpCd, string pFromDate, string pToDate, SystemHRProcedure.enumTAFields pFieldType, bool pAutoResume)
		{
			int mEntryId = 0;
			int mWorkHrsEntId = 0;
			int mReserveEntId = 0;

			double mPerDayHrs = SystemHRProcedure.GetEmpPerDayHours(pEmpCd);
			string mStartDate = SystemHRProcedure.GetPayrollGenerateStartDate();
			string mGenerateDate = SystemHRProcedure.GetPayrollGenerateDate();

			//To Update Deuction Hours in TNA only if cut off is enabled
			SystemHRProcedure.UpdateDeductionHoursForLeave(pEmpCd, pFromDate, pToDate, 0, pFieldType, pAutoResume, mIsPayClosed, 2);

			switch(pFieldType)
			{
				case SystemHRProcedure.enumTAFields.eTAVacationHours : 
					if (DateTime.Parse(mGenerateDate) >= DateTime.Parse(pFromDate))
					{
						//If Leave date is coming in this month then update work hours from start date to payroll generate date
						mWorkHrsEntId = SystemHRProcedure.GetTAEntryID(pEmpCd, SystemHRProcedure.enumTAFields.eTAWorkHours, DateTime.Parse(mGenerateDate).Year, DateTime.Parse(mGenerateDate).Month);
						mEntryId = SystemHRProcedure.GetTAEntryID(pEmpCd, SystemHRProcedure.enumTAFields.eTAVacationHours, DateTime.Parse(mGenerateDate).Year, DateTime.Parse(mGenerateDate).Month);
						SystemHRProcedure.UnPostLeaveInTimeAttendance(mWorkHrsEntId, mEntryId, mPerDayHrs, pToDate, pFromDate);
					} 
					break;
				case SystemHRProcedure.enumTAFields.eTASickHours : 
					if (DateTime.Parse(mGenerateDate) >= DateTime.Parse(pFromDate))
					{
						//If Leave date is coming in this month then update work hours from start date to payroll generate date
						mWorkHrsEntId = SystemHRProcedure.GetTAEntryID(pEmpCd, SystemHRProcedure.enumTAFields.eTAWorkHours, DateTime.Parse(mGenerateDate).Year, DateTime.Parse(mGenerateDate).Month);
						mEntryId = SystemHRProcedure.GetTAEntryID(pEmpCd, SystemHRProcedure.enumTAFields.eTASickHours, DateTime.Parse(mGenerateDate).Year, DateTime.Parse(mGenerateDate).Month);
						SystemHRProcedure.UnPostLeaveInTimeAttendance(mWorkHrsEntId, mEntryId, mPerDayHrs, pToDate, pFromDate);
					} 
					break;
				case SystemHRProcedure.enumTAFields.eTAAbsentHours : 
					if (DateTime.Parse(mGenerateDate) >= DateTime.Parse(pFromDate))
					{
						//If Leave date is coming in this month then update work hours from start date to payroll generate date
						mWorkHrsEntId = SystemHRProcedure.GetTAEntryID(pEmpCd, SystemHRProcedure.enumTAFields.eTAWorkHours, DateTime.Parse(mGenerateDate).Year, DateTime.Parse(mGenerateDate).Month);
						mEntryId = SystemHRProcedure.GetTAEntryID(pEmpCd, SystemHRProcedure.enumTAFields.eTAAbsentHours, DateTime.Parse(mGenerateDate).Year, DateTime.Parse(mGenerateDate).Month);
						SystemHRProcedure.UnPostLeaveInTimeAttendance(mWorkHrsEntId, mEntryId, mPerDayHrs, pToDate, pFromDate);
					} 
					break;
			}
			//' Updated reserve hrs if auto resumed is false
			if (!pAutoResume)
			{
				mReserveEntId = SystemHRProcedure.GetTAEntryID(pEmpCd, SystemHRProcedure.enumTAFields.eTAReserveHours, DateTime.Parse(mGenerateDate).Year, DateTime.Parse(mGenerateDate).Month);
				mWorkHrsEntId = SystemHRProcedure.GetTAEntryID(pEmpCd, SystemHRProcedure.enumTAFields.eTAWorkHours, DateTime.Parse(mGenerateDate).Year, DateTime.Parse(mGenerateDate).Month);
				SystemHRProcedure.UnPostReserveHrsInTimeAttendance(mReserveEntId, mWorkHrsEntId, pToDate, mPerDayHrs);
			}
			//' End
			SystemHRProcedure.UpdateDailyWagesEmployeeEarnInTA(pEmpCd, pEmpCd);
			return false;
		}


		private void SetNoOfHours()
		{
			string mSQL = " select emp_cd from pay_employee where emp_no = '" + txtCommonTextBox[conTxtEmpCode].Text + "'";
			//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mSQL));
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(mReturnValue))
			{
				txtCommonNumber[conNTxtPaidHours].Value = SystemHRProcedure.GetEmpPerDayHours(ReflectionHelper.GetPrimitiveValue<int>(mReturnValue)) * ReflectionHelper.GetPrimitiveValue<double>(txtCommonNumber[conNTxtPaidDays].Value);
			}
		}


		public System.DateTime WeekDays(System.DateTime FirstDay, System.DateTime LastDay, ref double mLeaveBal)
		{
			int mFirstWeekend = 0;
			int mSecondWeekend = 0;
			double n = 0;
			int mWeekendNo = 0;

			if (SystemProcedure2.IsItEmpty(txtCommonTextBox[conTxtEmpCode].Text, SystemVariables.DataType.StringType))
			{
				return DateTime.FromOADate(0);
			}
			//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode("select weekend_day1_id,weekend_day2_id from pay_employee where emp_cd = " + SystemHRProcedure.GetEmpCd(txtCommonTextBox[conTxtEmpCode].Text).ToString()));
			if (!mIncludeWeekend)
			{
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (Convert.IsDBNull(((Array) mReturnValue).GetValue(0)))
				{
					return DateTime.FromOADate(0);
				}
				else
				{
					mFirstWeekend = SystemHRProcedure.WeekDaysNo(ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue).GetValue(0)));
				}
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (Convert.IsDBNull(((Array) mReturnValue).GetValue(1)))
				{
					return DateTime.FromOADate(0);
				}
				else
				{
					mSecondWeekend = SystemHRProcedure.WeekDaysNo(ReflectionHelper.GetPrimitiveValue<int>(((Array) mReturnValue).GetValue(1)));
				}
				mWeekendNo = 0;
				System.DateTime tempForEndVar = LastDay;
				for (n = FirstDay.ToOADate(); DateTime.FromOADate(n) <= tempForEndVar; n++)
				{
					int switchVar = DateAndTime.Weekday(DateTime.FromOADate(n));
					if (switchVar == mFirstWeekend || switchVar == mSecondWeekend)
					{
						//''Nothin
					}
					else
					{
						mWeekendNo++;
					}
					if (Math.Floor(mLeaveBal) == mWeekendNo)
					{
						return DateTime.FromOADate(n);
					}
				}
				return DateTime.FromOADate(n - 1);
			}
			else
			{
				mLeaveBal--;
				if (LastDay <= FirstDay.AddDays(mLeaveBal))
				{
					return LastDay;
				}
				else
				{
					return FirstDay.AddDays(mLeaveBal);
				}
			}
		}
	}
}