using System;

namespace Xtreme
{
	internal partial class frmPayPassport
		: System.Windows.Forms.Form
	{

		public frmPayPassport()
{
InitializeComponent();
} 
 public  void frmPayPassport_old()
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


		private void frmPayPassport_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (UpgradeHelpers.Gui.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Gui.ActivateHelper.myActiveForm = (System.Windows.Forms.Form) eventSender;
			}
		}
		//Option Explicit
		//
		//Public UserAccess As New clsAccessAllowed
		//Public FirstFocusObject As Control
		//
		//Private mCheck As Boolean
		//
		//Private Const conTxtVoucherNo As Integer = 0
		//Private Const conTxtEmpCode As Integer = 1
		//Private Const conTxtReferenceNo As Integer = 2
		//Private Const conTxtLeaveCode As Integer = 3
		//Private Const conTxtComments As Integer = 4
		//
		//Private Const conDlblDeptCode As Integer = 0
		//Private Const conDlblDeptName As Integer = 1
		//Private Const conDlblDesgCode As Integer = 2
		//Private Const conDlblDesgName As Integer = 3
		//Private Const conDlblLeaveSalary As Integer = 4
		//Private Const conDlblEmpName As Integer = 5
		//Private Const conDlblLeaveName As Integer = 6
		//Private Const conDlblLeaveBalanceDays As Integer = 7
		//Private Const conDlblLeaveAmount As Integer = 8
		//Private Const conDlblTotalSalary As Integer = 9
		//
		//Private Const conDTxtVoucheDate As Integer = 0
		//Private Const conDTxtLeaveFromDate As Integer = 1
		//Private Const conDTxtLeaveToDate As Integer = 2
		//
		//Private Const conNTxtLeaveDays As Integer = 0
		//Private Const conNTxtActualLeaveDays As Integer = 1
		//Private Const conNTxtPaidDays As Integer = 2
		//Private Const conNTxtUnPaidDays As Integer = 3
		//
		//Private Const conCmbPayType As Integer = 0
		//
		//Private mTimeStamp As String
		//Private mThisFormID As Long
		//Private mSearchValue As Variant
		//Private mCurrentFormMode  As SystemFormModes
		//Private mOldVoucherStatus  As VoucherStatus
		//
		//'These property set the Form mode to add mode or edit mode
		//Public Property Get ThisFormId() As Long
		//    ThisFormId = mThisFormID
		//End Property
		//
		//Public Property Let ThisFormId(ByVal NewFormId As Long)
		//    mThisFormID = NewFormId
		//End Property
		//
		//'The property below are used for storing the Search value returned by the Find window
		//Public Property Get SearchValue() As Variant
		//SearchValue = mSearchValue
		//End Property
		//
		//Public Property Let SearchValue(ByVal vNewValue As Variant)
		//mSearchValue = vNewValue
		//End Property
		//
		//'These property set the Form mode to add mode or edit mode
		//Public Property Get CurrentFormMode() As SystemFormModes
		//    CurrentFormMode = mCurrentFormMode
		//End Property
		//
		//Public Property Let CurrentFormMode(ByVal vNewValue As SystemFormModes)
		//    mCurrentFormMode = vNewValue
		//End Property
		//
		//Private Sub btnFormToolBar_Click(Index As Integer)
		//Call ToolBarButtonClick(Me, btnFormToolBar(Index).Tag)
		//End Sub
		//
		//Private Sub Form_Load()
		//
		//Set FirstFocusObject = txtCommonTextBox(conTxtVoucherNo)
		//
		//On Error GoTo eFoundError
		//
		//Me.CurrentFormMode = frmAddMode
		//mOldVoucherStatus = stActive
		//Me.Top = 0
		//Me.Left = 0
		//
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
		//
		//'assign a next code
		//txtCommonTextBox(conTxtVoucherNo).Text = GetNewNumber("pay_leave_transaction", "voucher_no")
		//txtCommonDate(conDTxtVoucheDate).Value = Date
		//txtCommonDate(conDTxtLeaveFromDate).Value = Date
		//txtCommonDate(conDTxtLeaveToDate).Value = Date
		//
		//Dim mObjectId()
		//ReDim mObjectId(0)
		//mObjectId(conCmbPayType) = 1011
		//
		//Call FillComboWithSystemObjects(cmbCommon, mObjectId)
		//
		//Exit Sub
		//eFoundError:
		//Call ErrorHandlingRoutine(Err.Number, Err.Description, Me.Name, "Form Load")
		//Unload Me
		//End Sub
		//
		//Private Sub Form_KeyDown(KeyCode As Integer, Shift As Integer)
		//'On Keydown navigate the form by using enter key
		//If KeyCode = 13 Then    'If enter key pressed send a tab key
		//    SendKeys "{TAB}"
		//    Exit Sub
		//End If
		//If Me.ActiveControl.Name = "txtCommonTextBox" Then
		//    Call SystemFormKeyDown(Me, KeyCode, Shift, "txtCommonTextBox#" + Trim(Me.ActiveControl.Index))
		//Else
		//    Call SystemFormKeyDown(Me, KeyCode, Shift, Me.ActiveControl.Name)
		//End If
		//End Sub
		//
		//Public Sub AddRecord()
		//'Add a record
		//'mCheck = False
		//Call ClearTextBox(Me)
		//txtCommonTextBox(conTxtVoucherNo).Text = GetNewNumber("pay_leave_transaction", "voucher_no")
		//
		//txtCommonDate(conDTxtVoucheDate).Value = Date
		//txtCommonDate(conDTxtLeaveFromDate).Value = Date
		//txtCommonDate(conDTxtLeaveToDate).Value = Date
		//txtCommonDate(conDTxtLeaveFromDate).Tag = ""
		//txtCommonDate(conDTxtLeaveToDate).Tag = ""
		//
		//txtCommonTextBox(conTxtEmpCode).Enabled = True
		//txtCommonTextBox(conTxtLeaveCode).Enabled = True
		//
		//mCurrentFormMode = frmAddMode                           'Change the form mode to addmode
		//mSearchValue = ""                                       'Change the msearchvalue to blank
		//FirstFocusObject.SetFocus
		//mOldVoucherStatus = stActive
		//
		//'mCheck = True
		//Exit Sub
		//eFoundError:
		//Call ErrorHandlingRoutine(Err.Number, Err.Description, Me.Name, "AddRecord")
		//End Sub
		//
		//Public Function saveRecord(Optional pApprove As Boolean = False) As Boolean
		//Dim mReturnValue As Variant
		//Dim mEmpCode As Integer
		//Dim mDeptCode As Integer
		//Dim mDesgCode As Integer
		//Dim mLeaveCode As Integer
		//Dim mLeaveSalary As Currency
		//Dim mTotalSalary As Currency
		//Dim mysql As String
		//
		//'On Error GoTo eFoundError
		//
		//mysql = "select pemp.emp_cd , pleave.leave_cd "
		//mysql = mysql & " , pemp.leave_salary "
		//mysql = mysql & " , pemp.total_salary"
		//mysql = mysql & " from pay_employee_leave_details peld "
		//mysql = mysql & " inner join pay_employee pemp on pemp.emp_cd = peld.emp_cd "
		//mysql = mysql & " inner join pay_leave pleave on peld.leave_cd = pleave.leave_cd "
		//mysql = mysql & " where "
		//mysql = mysql & " emp_no ='" & txtCommonTextBox(conTxtEmpCode).Text & "'"
		//mysql = mysql & " and leave_no = " & txtCommonTextBox(conTxtLeaveCode).Text
		//
		//mReturnValue = GetMasterCode(mysql)
		//If IsNull(mReturnValue) Then
		//    MsgBox "Invalid Employee Code", vbInformation
		//    saveRecord = False
		//    txtCommonTextBox(conTxtEmpCode).SetFocus
		//    Exit Function
		//Else
		//    mEmpCode = mReturnValue(0)
		//    mLeaveCode = mReturnValue(1)
		//    mLeaveSalary = mReturnValue(2)
		//    mTotalSalary = mReturnValue(3)
		//End If
		//
		//'''From date should be greater than than the last TO date of a leave transaction
		//mysql = " select max(leave_end_date) from pay_leave_transaction "
		//mysql = mysql & " where emp_cd =" & mEmpCode
		//If CurrentFormMode = frmEditMode Then
		//    mysql = mysql & " and entry_id <> " & mSearchValue
		//End If
		//
		//mReturnValue = GetMasterCode(mysql)
		//If Not IsNull(mReturnValue) Then
		//    If CDate(txtCommonDate(conDTxtLeaveFromDate).DisplayText) <= CDate(mReturnValue) Then
		//        MsgBox " From Date should be greater than last Leave Date i.e. " & Format(mReturnValue, gSystemDateFormat)
		//        saveRecord = False
		//        txtCommonDate(conDTxtLeaveFromDate).SetFocus
		//        Exit Function
		//    End If
		//End If
		//
		//'''From date cannot be greater than generate date
		//mysql = " select max(generate_date) from Pay_Payroll_Generate_History "
		//mReturnValue = GetMasterCode(mysql)
		//If Not IsNull(mReturnValue) Then
		//    If CDate(txtCommonDate(conDTxtLeaveFromDate).DisplayText) > CDate(mReturnValue) Then
		//        MsgBox " From Date cannot be greater than Generate Date i.e. " & Format(mReturnValue, gSystemDateFormat)
		//        saveRecord = False
		//        txtCommonDate(conDTxtLeaveFromDate).SetFocus
		//        Exit Function
		//    End If
		//End If
		//
		//gConn.BeginTrans
		//If mCurrentFormMode = frmAddMode Then
		//    mysql = " insert into pay_leave_transaction "
		//    mysql = mysql & " (emp_cd, dept_cd, desg_cd, comp_cd, curr_cd, voucher_no "
		//    mysql = mysql & " , voucher_date, reference_no "
		//    mysql = mysql & " , leave_salary, total_salary, leave_start_date, leave_end_date"
		//    mysql = mysql & " , leave_days, actual_leave_days, leave_balance_days, paid_days"
		//    mysql = mysql & " , unpaid_days, leave_salary_amount, leave_amount_payment_type_id"
		//    mysql = mysql & " , last_salary_date"
		//    mysql = mysql & " , bank_cd, bank_branch_cd, bank_account_no, rate_calc_method_id"
		//    mysql = mysql & " , payment_type_id "
		//    mysql = mysql & " , weekend, weekend_day1_id, weekend_day2_id "
		//    mysql = mysql & " , days_per_month , hours_per_day "
		//    mysql = mysql & " , opening_paid_leave_balance_date"
		//    mysql = mysql & " , opening_paid_leave_balance_days "
		//    mysql = mysql & " , leave_cd, leave_switch_over_period, leave_days_before_sop "
		//    mysql = mysql & " , leave_days_after_sop ,working_days_per_month_before_sop"
		//    mysql = mysql & " , working_days_per_month_after_sop, deduct_paid_days "
		//    mysql = mysql & " , deduct_unpaid_days , paid_leave_taken_days "
		//    mysql = mysql & " , comments, user_cd )"
		//    mysql = mysql & " select pemp.emp_cd, pemp.dept_cd, pemp.desg_cd, pemp.comp_cd"
		//    mysql = mysql & " , pemp.curr_cd"
		//    mysql = mysql & " , " & txtCommonTextBox(conTxtVoucherNo).Text
		//    mysql = mysql & " , '" & txtCommonDate(conDTxtVoucheDate).DisplayText & "'"
		//    mysql = mysql & " , '" & txtCommonTextBox(conTxtReferenceNo).Text & "'"
		//    mysql = mysql & " , " & mLeaveSalary
		//    mysql = mysql & " , " & mTotalSalary
		//    mysql = mysql & " , '" & txtCommonDate(conDTxtLeaveFromDate).DisplayText & "'"
		//    mysql = mysql & " , '" & txtCommonDate(conDTxtLeaveToDate).DisplayText & "'"
		//    mysql = mysql & " , " & txtCommonNumber(conNTxtLeaveDays).Value
		//    mysql = mysql & " , " & txtCommonNumber(conNTxtActualLeaveDays).Value
		//    If IsItEmpty(txtDisplayLabel(conDlblLeaveBalanceDays).Text, StringType) Then
		//        mysql = mysql & " , 0"
		//    Else
		//        mysql = mysql & " , " & Format(txtDisplayLabel(conDlblLeaveBalanceDays).Text, "########0.000")
		//    End If
		//    mysql = mysql & " , " & txtCommonNumber(conNTxtPaidDays).Value
		//    mysql = mysql & " , " & txtCommonNumber(conNTxtUnPaidDays).Value
		//
		//    If IsItEmpty(txtDisplayLabel(conDlblLeaveAmount).Text, StringType) Then
		//        mysql = mysql & " , 0 "
		//    Else
		//        mysql = mysql & " , " & Format(txtDisplayLabel(conDlblLeaveAmount).Text, "########0.000")
		//    End If
		//    mysql = mysql & " , " & cmbCommon(conCmbPayType).ItemData(cmbCommon(conCmbPayType).ListIndex)
		//
		//    mysql = mysql & " , pemp.last_salary_date "
		//    mysql = mysql & " , pemp.bank_cd, pemp.bank_branch_cd "
		//    mysql = mysql & " , pemp.bank_account_no, pemp.rate_calc_method_id "
		//    mysql = mysql & " , pemp.payment_type_id "
		//    mysql = mysql & " , pemp.weekend, pemp.weekend_day1_id, pemp.weekend_day2_id "
		//    mysql = mysql & " , pemp.days_per_month, pemp.hours_per_day "
		//    mysql = mysql & " , peld.opening_paid_leave_balance_date "
		//    mysql = mysql & " , peld.opening_paid_leave_balance_days "
		//    mysql = mysql & " , peld.leave_cd , peld.leave_switch_over_period "
		//    mysql = mysql & " , peld.leave_days_before_sop, peld.leave_days_after_sop "
		//    mysql = mysql & " , peld.working_days_per_month_before_sop "
		//    mysql = mysql & " , peld.working_days_per_month_after_sop "
		//    mysql = mysql & " , peld.deduct_paid_days, peld.deduct_unpaid_days "
		//    mysql = mysql & " , peld.paid_leave_taken_days "
		//    mysql = mysql & " , '" & txtCommonTextBox(conTxtComments).Text & "'"
		//    mysql = mysql & " , " & gLoggedInUserCode
		//    mysql = mysql & " from pay_employee pemp "
		//    mysql = mysql & " inner join pay_employee_leave_details peld "
		//    mysql = mysql & " on pemp.emp_cd = peld.emp_cd "
		//    mysql = mysql & " where pemp.emp_cd = " & mEmpCode
		//    mysql = mysql & " and peld.leave_cd = " & mLeaveCode
		//
		//    gConn.Execute (mysql)
		//    mSearchValue = GetMasterCode("select scope_identity()")
		//
		//Else
		//    Dim mCheckTimeStamp As String
		//    mysql = " select time_stamp from pay_leave_transaction where entry_id =" & mSearchValue
		//    mReturnValue = GetMasterCode(mysql)
		//    If Not IsNull(mReturnValue) Then
		//        mCheckTimeStamp = mReturnValue
		//    Else
		//        MsgBox msg10, vbInformation
		//        gConn.RollbackTrans
		//        saveRecord = False
		//        FirstFocusObject.SetFocus
		//        Exit Function
		//    End If
		//
		//    If (tsFormat(mTimeStamp) <> tsFormat(mCheckTimeStamp)) Then
		//        MsgBox msg10, vbInformation
		//        gConn.RollbackTrans
		//        saveRecord = False
		//        FirstFocusObject.SetFocus
		//        Exit Function
		//    End If
		//
		//    mysql = " update pay_leave_transaction set "
		//    mysql = mysql & " voucher_no =" & txtCommonTextBox(conTxtVoucherNo).Text
		//    mysql = mysql & " , voucher_date = '" & txtCommonDate(conDTxtVoucheDate).DisplayText & "'"
		//    mysql = mysql & " , reference_no ='" & txtCommonTextBox(conTxtReferenceNo).Text & "'"
		//    mysql = mysql & " , leave_start_date='" & txtCommonDate(conDTxtLeaveFromDate).DisplayText & "'"
		//    mysql = mysql & " , leave_end_date='" & txtCommonDate(conDTxtLeaveToDate).DisplayText & "'"
		//    mysql = mysql & " , leave_days =" & txtCommonNumber(conNTxtLeaveDays).Value
		//    mysql = mysql & " , actual_leave_days =" & txtCommonNumber(conNTxtActualLeaveDays).Value
		//
		//    If IsItEmpty(txtDisplayLabel(conDlblLeaveBalanceDays).Text, StringType) Then
		//        mysql = mysql & " , leave_balance_days = 0 "
		//    Else
		//        mysql = mysql & " , leave_balance_days = " & Format(txtDisplayLabel(conDlblLeaveBalanceDays).Text, "##########0.000")
		//    End If
		//    mysql = mysql & " , paid_days =" & txtCommonNumber(conNTxtPaidDays).Value
		//    mysql = mysql & " , unpaid_days =" & txtCommonNumber(conNTxtUnPaidDays).Value
		//
		//    If IsItEmpty(txtDisplayLabel(conDlblLeaveAmount).Text, StringType) Then
		//        mysql = mysql & " , leave_salary_amount = 0 "
		//    Else
		//        mysql = mysql & " , leave_salary_amount = " & Format(txtDisplayLabel(conDlblLeaveAmount).Text, "##########0.000")
		//    End If
		//
		//    mysql = mysql & " , leave_amount_payment_type_id = " & cmbCommon(conCmbPayType).ItemData(cmbCommon(conCmbPayType).ListIndex)
		//
		//    mysql = mysql & " , comments ='" & txtCommonTextBox(conTxtComments).Text & "'"
		//    mysql = mysql & " , user_cd =" & Str(gLoggedInUserCode)
		//    mysql = mysql & " where entry_id=" & Str(mSearchValue)
		//    gConn.Execute (mysql)
		//End If
		//
		//mysql = " update pay_employee "
		//mysql = mysql & " set status_cd = " & gStatusOnLeave
		//mysql = mysql & " where emp_cd =" & mEmpCode
		//gConn.Execute mysql
		//
		//
		//If pApprove = True Then
		//    Call PayPostToHR("Pay_leave_transaction", CLng(mSearchValue))
		//    Call PayApprove("Pay_leave_transaction", CLng(mSearchValue))
		//    Post_Leave_Transaction (mSearchValue)
		//End If
		//
		//
		//gConn.CommitTrans
		//saveRecord = True
		//FirstFocusObject.SetFocus
		//Exit Function
		//
		//eFoundError:
		//Dim mReturnErrorType As Integer
		//mReturnErrorType = ErrorHandlingRoutine(Err.Number, Err.Description, Me.Name, "GetRecord", msg10)
		//gConn.RollbackTrans
		//saveRecord = False
		//End Function
		//
		//Public Function deleteRecord()
		//Dim mysql As String
		//Dim mReturnValue  As Variant
		//
		//If mOldVoucherStatus <> stActive Then
		//    Call VoucherStatusErrorMessage(mOldVoucherStatus, 1)
		//    deleteRecord = False
		//    If FirstFocusObject.Enabled = True Then
		//        FirstFocusObject.SetFocus
		//    End If
		//    Exit Function
		//End If
		//
		//
		//gConn.BeginTrans
		//
		//mysql = " update pay_employee "
		//mysql = mysql & " set status_cd = 1 "
		//mysql = mysql & " from pay_employee pemp inner join pay_leave_transaction plt "
		//mysql = mysql & " on pemp.emp_cd = plt.emp_cd "
		//mysql = mysql & " where plt.entry_id=" & Str(mSearchValue)
		//gConn.Execute mysql
		//
		//mysql = "delete from pay_leave_transaction  where entry_id=" & Str(mSearchValue)
		//gConn.Execute mysql
		//
		//gConn.CommitTrans
		//deleteRecord = True
		//
		//
		//Exit Function
		//eFoundError:
		//Dim mReturnErrorType As Integer
		//mReturnErrorType = ErrorHandlingRoutine(Err.Number, Err.Description, Me.Name, "GetRecord", msg10)
		//If mReturnErrorType = 1 Then
		//    deleteRecord = False
		//ElseIf mReturnErrorType = 2 Then
		//    Call AddRecord
		//    deleteRecord = False
		//Else
		//    deleteRecord = False
		//End If
		//End Function
		//
		//Public Sub GetRecord(SearchValue As Variant)
		//'This routine is called after getting the value from Find window or
		//'refreshing the recordset during any error of updating or deleting
		//
		//'On Error GoTo eFoundError
		//Dim mysql As String
		//Dim mReturnValue As Variant
		//Dim localRec As adodb.Recordset
		//
		//FirstFocusObject.SetFocus
		//DoEvents
		//
		//mysql = " select plt.* "
		//mysql = mysql & " , " & IIf(gPreferedLanguage = english, "isnull(l_first_name,'') + ' ' + isnull(l_second_name,'') + ' ' + isnull(l_third_name,'') + ' ' + isnull(l_fourth_name,'')", "isnull(a_first_name,'') + ' ' + isnull(a_second_name,'') + ' ' + isnull(a_third_name,'') + ' ' + isnull(a_fourth_name,'')") & " as emp_name "
		//mysql = mysql & " , emp_no , plt.weekend , plt.weekend_day1_id, plt.weekend_day2_id "
		//mysql = mysql & " , " & IIf(gPreferedLanguage = english, "l_dept_name", "a_dept_name") & " as dept_name "
		//mysql = mysql & " , dept_no "
		//mysql = mysql & " , " & IIf(gPreferedLanguage = english, "l_desg_name", "a_desg_name") & " as desg_name "
		//mysql = mysql & " , desg_no "
		//mysql = mysql & " , pemp.leave_salary, pemp.total_salary "
		//mysql = mysql & " , leave_no "
		//mysql = mysql & " , " & IIf(gPreferedLanguage = english, "l_leave_name", "a_leave_name") & " as leave_name "
		//mysql = mysql & " from pay_leave_transaction plt "
		//mysql = mysql & " inner join pay_employee pemp on plt.emp_cd = pemp.emp_cd "
		//mysql = mysql & " inner join pay_leave pleave on plt.leave_cd = pleave.leave_cd "
		//mysql = mysql & " inner join pay_department pdept on  plt.dept_cd = pdept.dept_cd "
		//mysql = mysql & " inner join pay_designation pdesg on  plt.desg_cd = pdesg.desg_cd  "
		//mysql = mysql & " where entry_id = " & SearchValue
		//
		//
		//Set localRec = New adodb.Recordset
		//localRec.Open mysql, gConn, adOpenForwardOnly, adLockReadOnly
		//With localRec
		//    If Not .EOF Then
		//        mSearchValue = SearchValue
		//        mTimeStamp = .Fields("time_stamp")
		//
		//        txtCommonTextBox(conTxtVoucherNo).Text = .Fields("voucher_no")
		//        txtCommonDate(conDTxtVoucheDate).Value = .Fields("voucher_date")
		//        txtCommonTextBox(conTxtReferenceNo).Text = .Fields("reference_no") & ""
		//
		//        txtCommonTextBox(conTxtEmpCode).Text = .Fields("emp_no")
		//        txtDisplayLabel(conDlblEmpName).Text = .Fields("emp_name")
		//        txtDisplayLabel(conDlblDeptCode).Text = .Fields("dept_no")
		//        txtDisplayLabel(conDlblDeptName).Text = .Fields("dept_name")
		//        txtDisplayLabel(conDlblDesgCode).Text = .Fields("desg_no")
		//        txtDisplayLabel(conDlblDesgName).Text = .Fields("desg_name")
		//        txtDisplayLabel(conDlblLeaveSalary).Text = Format(.Fields("leave_salary"), "###,###,##0.000")
		//        txtDisplayLabel(conDlblTotalSalary).Text = Format(.Fields("total_salary"), "###,###,##0.000")
		//
		//        txtCommonTextBox(conTxtLeaveCode).Text = .Fields("leave_no")
		//        txtDisplayLabel(conDlblLeaveName).Text = .Fields("leave_name")
		//
		//        txtCommonDate(conDTxtLeaveFromDate).Value = .Fields("leave_start_date")
		//        txtCommonDate(conDTxtLeaveToDate).Value = .Fields("leave_end_date")
		//
		//        txtCommonDate(conDTxtLeaveFromDate).Tag = .Fields("weekend_day1_id")
		//        txtCommonDate(conDTxtLeaveToDate).Tag = .Fields("weekend_day2_id")
		//
		//        txtCommonNumber(conNTxtLeaveDays).Value = .Fields("leave_days")
		//        txtDisplayLabel(conDlblLeaveBalanceDays).Text = Format(.Fields("leave_balance_days"), "###,###,##0.000")
		//
		//        txtCommonNumber(conNTxtActualLeaveDays).Value = .Fields("actual_leave_days")
		//        txtCommonNumber(conNTxtPaidDays).Value = .Fields("paid_days")
		//        txtCommonNumber(conNTxtUnPaidDays).Value = .Fields("unpaid_days")
		//        txtDisplayLabel(conDlblLeaveAmount).Text = Format(.Fields("leave_salary_amount"), "###,###,##0.000")
		//
		//        SearchCombo cmbCommon(conCmbPayType), .Fields("leave_amount_payment_type_id")
		//        txtCommonTextBox(conTxtComments).Text = .Fields("comments") & ""
		//
		//        'Change the form mode to edit
		//        mCurrentFormMode = frmEditMode
		//        txtCommonTextBox(conTxtEmpCode).Enabled = False
		//        txtCommonTextBox(conTxtLeaveCode).Enabled = False
		//
		//        'Set the form caption and Get the Voucher Status
		//        Call SetFormCaption(mOldVoucherStatus, frmPayPassport, .Fields("status"), CurrentFormMode, IIf(gPreferedLanguage = Arabic, "Leave Transaction", "Leave Transaction"))
		//
		//    End If
		//End With
		//localRec.Close
		//Set localRec = Nothing
		//
		//Exit Sub
		//eFoundError:
		//Call ErrorHandlingRoutine(Err.Number, Err.Description, Me.Name, "GetRecord")
		//End Sub
		//
		//Public Sub PrintReport()
		//
		//End Sub
		//
		//Public Sub findRecord()
		//'Call the find window
		//Dim mTempSearchValue As Variant
		//
		//mTempSearchValue = FindItem(7080000)
		//If Not IsNull(mTempSearchValue) Then
		//    mSearchValue = mTempSearchValue(0)
		//    Call GetRecord(mSearchValue)
		//End If
		//End Sub
		//
		//Public Sub CloseForm()
		//Unload Me
		//End Sub
		//
		//Function CheckDataValidity() As Boolean
		//If mOldVoucherStatus <> stActive Then
		//    Call VoucherStatusErrorMessage(mOldVoucherStatus, 3)
		//    If FirstFocusObject.Enabled = True Then
		//        FirstFocusObject.SetFocus
		//    End If
		//    GoTo mend
		//End If
		//
		//
		//'Check validation during update and add of records
		//If Not IsNumeric(txtCommonTextBox(conTxtVoucherNo).Text) Then
		//    MsgBox "Enter the Loan No.", vbInformation, "Required"
		//    txtCommonTextBox(conTxtVoucherNo).SetFocus
		//    GoTo mend
		//End If
		//
		//If Not IsDate(txtCommonDate(conDTxtVoucheDate).DisplayText) Then
		//    MsgBox "Enter valid date", vbInformation, "Required"
		//    txtCommonDate(conDTxtVoucheDate).SetFocus
		//    GoTo mend
		//End If
		//
		//If IsItEmpty(txtCommonTextBox(conTxtEmpCode).Text, StringType) Then
		//    MsgBox "Enter Employee Code", vbInformation, "Required"
		//    txtCommonTextBox(conTxtEmpCode).SetFocus
		//    GoTo mend
		//End If
		//
		//If Not IsDate(txtCommonDate(conDTxtLeaveFromDate).DisplayText) Then
		//    MsgBox "Enter valid date", vbInformation, "Required"
		//    txtCommonDate(conDTxtLeaveFromDate).SetFocus
		//    GoTo mend
		//End If
		//
		//If Not IsDate(txtCommonDate(conDTxtLeaveToDate).DisplayText) Then
		//    MsgBox "Enter valid date", vbInformation, "Required"
		//    txtCommonDate(conDTxtLeaveToDate).SetFocus
		//    GoTo mend
		//End If
		//
		//If IsItEmpty(txtCommonNumber(conNTxtActualLeaveDays).Value, NumberType) Then
		//    MsgBox "Actual Leave days cannot be zero", vbInformation, "Required"
		//    txtCommonNumber(conNTxtActualLeaveDays).SetFocus
		//    GoTo mend
		//End If
		//
		//If txtCommonDate(conDTxtLeaveFromDate).Value > txtCommonDate(conDTxtLeaveToDate).Value Then
		//    MsgBox "From Date cannot be greater than To date", vbInformation, "Required"
		//    txtCommonDate(conDTxtLeaveToDate).SetFocus
		//    GoTo mend
		//End If
		//
		//txtCommonNumber(conNTxtLeaveDays).Value = CalculateDays(txtCommonDate(conDTxtLeaveFromDate).Value, txtCommonDate(conDTxtLeaveToDate).Value, txtCommonDate(conDTxtLeaveFromDate).Tag, txtCommonDate(conDTxtLeaveToDate).Tag)
		//Call Get_Leave_Balance_Days
		//Call LeaveAmount
		//
		//If txtCommonNumber(conNTxtActualLeaveDays).Value > txtCommonNumber(conNTxtLeaveDays).Value Then
		//    MsgBox "Actual leave days cannot be greater than leave days", vbInformation
		//    txtCommonNumber(conNTxtActualLeaveDays).SetFocus
		//    txtCommonNumber(conNTxtActualLeaveDays).Value = 0
		//End If
		//
		//If (txtCommonNumber(conNTxtPaidDays).Value + txtCommonNumber(conNTxtUnPaidDays).Value) <> txtCommonNumber(conNTxtActualLeaveDays).Value Then
		//    MsgBox "Sum of paid days and unpaid days should be equal to Actual leave days ", vbInformation
		//    txtCommonNumber(conNTxtPaidDays).SetFocus
		//    GoTo mend
		//End If
		//
		//CheckDataValidity = True
		//
		//Exit Function
		//mend:
		//CheckDataValidity = False
		//Exit Function
		//End Function
		//
		//Private Sub Form_Unload(Cancel As Integer)
		//On Error Resume Next
		//Call RemoveMeFromWindowList(Str(Me.hWnd))
		//
		//Set UserAccess = Nothing
		//Set frmPayPassport = Nothing
		//End Sub
		//
		//Sub GetNextNumber()
		//txtCommonTextBox(conTxtVoucherNo).Text = GetNewNumber("pay_leave_transaction", "voucher_no")
		//FirstFocusObject.SetFocus
		//End Sub
		//
		//Private Sub txtCommonDate_Validate(Index As Integer, Cancel As Boolean)
		//If Index = conDTxtLeaveToDate Or Index = conDTxtLeaveFromDate Then
		//    If Not IsDate(txtCommonDate(conDTxtLeaveFromDate).Value) Then
		//        MsgBox " Invalid date "
		//        Cancel = True
		//        txtCommonDate(conDTxtLeaveFromDate).SetFocus
		//        Exit Sub
		//    End If
		//
		//    If Not IsDate(txtCommonDate(conDTxtLeaveToDate).Value) Then
		//        MsgBox " Invalid date "
		//        Cancel = True
		//        txtCommonDate(conDTxtLeaveToDate).SetFocus
		//        Exit Sub
		//    End If
		//
		//    If txtCommonDate(conDTxtLeaveToDate).Value < txtCommonDate(conDTxtLeaveFromDate).Value Then
		//        txtCommonDate(conDTxtLeaveToDate).Value = txtCommonDate(conDTxtLeaveFromDate).Value
		//    End If
		//
		//    txtCommonNumber(conNTxtUnPaidDays).Value = 0
		//    txtCommonNumber(conNTxtPaidDays).Value = 0
		//    txtCommonNumber(conNTxtActualLeaveDays).Value = 0
		//
		//    If txtCommonDate(conDTxtLeaveFromDate).Value > txtCommonDate(conDTxtLeaveToDate).Value Then
		//        MsgBox "From Leave Date cannot be greater than To Leave Date", vbInformation
		//        txtCommonDate(Index).SetFocus
		//        Cancel = True
		//    End If
		//
		//    If Not IsItEmpty(txtCommonTextBox(conTxtEmpCode).Text, StringType) Then
		//        txtCommonNumber(conNTxtLeaveDays).Value = CalculateDays(txtCommonDate(conDTxtLeaveFromDate).Value, txtCommonDate(conDTxtLeaveToDate).Value, txtCommonDate(conDTxtLeaveFromDate).Tag, txtCommonDate(conDTxtLeaveToDate).Tag)
		//    End If
		//    Call Get_Leave_Balance_Days
		//
		//End If
		//End Sub
		//
		//Private Sub txtCommonNumber_Change(Index As Integer)
		//Dim mLeaveBalanceDays As Double
		//
		//If Trim(txtDisplayLabel(conDlblLeaveBalanceDays).Text) <> "" Then
		//    mLeaveBalanceDays = Format(txtDisplayLabel(conDlblLeaveBalanceDays).Text, "#########0.000")
		//Else
		//    mLeaveBalanceDays = 0
		//End If
		//
		//If Index = conNTxtActualLeaveDays Then
		//    mCheck = False
		//    txtCommonNumber(conNTxtPaidDays).Value = 0
		//    txtCommonNumber(conNTxtUnPaidDays).Value = 0
		//    mCheck = True
		//
		//    If txtCommonNumber(conNTxtActualLeaveDays).Value > txtCommonNumber(conNTxtLeaveDays).Value Then
		//        MsgBox "Actual leave days cannot be greater than leave days", vbInformation
		//        txtCommonNumber(conNTxtActualLeaveDays).SetFocus
		//        txtCommonNumber(conNTxtActualLeaveDays).Value = 0
		//    End If
		//
		//    If txtCommonNumber(Index).Value < mLeaveBalanceDays Then
		//        txtCommonNumber(conNTxtPaidDays).Value = txtCommonNumber(Index).Value
		//        txtCommonNumber(conNTxtUnPaidDays).Value = 0
		//    Else
		//        txtCommonNumber(conNTxtPaidDays).Value = mLeaveBalanceDays
		//        txtCommonNumber(conNTxtUnPaidDays).Value = txtCommonNumber(Index).Value - mLeaveBalanceDays
		//    End If
		//End If
		//
		//If (Index = conNTxtPaidDays Or Index = conNTxtUnPaidDays) And mCheck = True Then
		//    If (txtCommonNumber(conNTxtPaidDays).Value + txtCommonNumber(conNTxtUnPaidDays).Value) > txtCommonNumber(conNTxtActualLeaveDays).Value Then
		//        MsgBox "Sum of paid days and unpaid days cannot be greater than Actual leave days ", vbInformation
		//        txtCommonNumber(Index).SetFocus
		//        txtCommonNumber(Index).Value = 0
		//    End If
		//End If
		//
		//If Index = conNTxtPaidDays And mCheck = True Then
		//    If txtCommonNumber(conNTxtPaidDays).Value > mLeaveBalanceDays Then
		//        MsgBox "Paid days cannot be greater than Leave balance days ", vbInformation
		//        txtCommonNumber(Index).SetFocus
		//        txtCommonNumber(Index).Value = 0
		//    End If
		//End If
		//
		//End Sub
		//
		//Private Sub txtCommonNumber_GotFocus(Index As Integer)
		//If Index = conNTxtActualLeaveDays And txtCommonNumber(conNTxtActualLeaveDays).Value = 0 Then
		//    txtCommonNumber(conNTxtActualLeaveDays).Value = txtCommonNumber(conNTxtLeaveDays).Value
		//End If
		//End Sub
		//
		//Private Sub txtCommonNumber_LostFocus(Index As Integer)
		//If Index = conNTxtPaidDays Then
		//    Call LeaveAmount
		//End If
		//End Sub
		//
		//Private Sub txtCommonTextBox_DropButtonClick(Index As Integer)
		//If Index = conTxtVoucherNo Then
		//    Call GetNextNumber
		//Else
		//    Call FindRoutine("txtCommonTextBox#" + Trim(Index))
		//End If
		//End Sub
		//
		//Private Sub txtCommonTextBox_LostFocus(Index As Integer)
		//On Error GoTo eFoundError
		//Dim mTempValue As Variant
		//Dim mysql As String
		//Dim cnt As Integer
		//
		//If Index = conTxtEmpCode Then
		//    If Not IsItEmpty(txtCommonTextBox(conTxtEmpCode).Text, NumberType) Then
		//        mysql = "select " & IIf(gPreferedLanguage = english, "l_first_name + ' ' + l_second_name + ' ' + l_third_name + ' ' + l_fourth_name", "a_first_name + ' ' + a_second_name + ' ' + a_third_name + ' ' + a_fourth_name")
		//        mysql = mysql & " , dept_no "
		//        mysql = mysql & " , " & IIf(gPreferedLanguage = english, "l_dept_name", "a_dept_name")
		//        mysql = mysql & " , desg_no "
		//        mysql = mysql & " , " & IIf(gPreferedLanguage = english, "l_desg_name", "a_desg_name")
		//        mysql = mysql & " , emp_cd"
		//        mysql = mysql & " , pemp.leave_salary, weekend, weekend_day1_id , weekend_day2_id  "
		//        mysql = mysql & " , pemp.total_salary "
		//        mysql = mysql & " from pay_employee pemp , pay_department pdept, pay_designation pdesg "
		//        mysql = mysql & " where "
		//        mysql = mysql & " pemp.dept_cd = pdept.dept_cd and pemp.desg_cd = pdesg.desg_cd "
		//        mysql = mysql & " and pemp.emp_no = " & txtCommonTextBox(conTxtEmpCode).Text
		//        '''Only Active Employee
		//        mysql = mysql & " and pemp.status_cd = 1 "
		//
		//        mTempValue = GetMasterCode(mysql)
		//        If IsNull(mTempValue) Then
		//            txtCommonTextBox(Index).Text = ""
		//            txtDisplayLabel(conDlblEmpName).Text = ""
		//            txtDisplayLabel(conDlblDeptCode).Text = ""
		//            txtDisplayLabel(conDlblDeptName).Text = ""
		//            txtDisplayLabel(conDlblDesgCode).Text = ""
		//            txtDisplayLabel(conDlblDesgName).Text = ""
		//            txtDisplayLabel(conDlblLeaveSalary).Text = ""
		//            txtCommonDate(conDTxtLeaveFromDate).Tag = ""
		//            txtCommonDate(conDTxtLeaveToDate).Tag = ""
		//            txtDisplayLabel(conDlblTotalSalary).Text = ""
		//            Err.Raise -9990002
		//        Else
		//            txtDisplayLabel(conDlblEmpName).Text = mTempValue(0)
		//            txtDisplayLabel(conDlblDeptCode).Text = mTempValue(1)
		//            txtDisplayLabel(conDlblDeptName).Text = mTempValue(2)
		//            txtDisplayLabel(conDlblDesgCode).Text = mTempValue(3)
		//            txtDisplayLabel(conDlblDesgName).Text = mTempValue(4)
		//            txtDisplayLabel(conDlblLeaveSalary).Text = Format(mTempValue(6), "###,###,##0.000")
		//            txtDisplayLabel(conDlblTotalSalary).Text = Format(mTempValue(10), "###,###,##0.000")
		//
		//            txtCommonDate(conDTxtLeaveFromDate).Tag = mTempValue(8)
		//            txtCommonDate(conDTxtLeaveToDate).Tag = mTempValue(9)
		//
		//            If Not IsItEmpty(txtCommonTextBox(conTxtLeaveCode).Text, NumberType) Then
		//                Call Get_Leave_Balance_Days
		//            Else
		//                txtDisplayLabel(conDlblLeaveBalanceDays).Text = "0.000"
		//            End If
		//        End If
		//    Else
		//        txtDisplayLabel(conDlblEmpName).Text = ""
		//        txtDisplayLabel(conDlblDeptCode).Text = ""
		//        txtDisplayLabel(conDlblDeptName).Text = ""
		//        txtDisplayLabel(conDlblDesgCode).Text = ""
		//        txtDisplayLabel(conDlblDesgName).Text = ""
		//        txtDisplayLabel(conDlblLeaveSalary).Text = ""
		//        txtCommonDate(conDTxtLeaveFromDate).Tag = ""
		//        txtCommonDate(conDTxtLeaveToDate).Tag = ""
		//        txtDisplayLabel(conDlblTotalSalary).Text = ""
		//    End If
		//ElseIf Index = conTxtLeaveCode Then
		//    If Not IsItEmpty(txtCommonTextBox(conTxtLeaveCode).Text, NumberType) Then
		//        mysql = "select " & IIf(gPreferedLanguage = english, "l_leave_name", "a_leave_name")
		//        mysql = mysql & " , leave_no "
		//        mysql = mysql & " from pay_employee_leave_details peld "
		//        mysql = mysql & " inner join pay_employee pemp on pemp.emp_cd = peld.emp_cd "
		//        mysql = mysql & " inner join pay_leave pleave on peld.leave_cd = pleave.leave_cd "
		//        mysql = mysql & " where "
		//        mysql = mysql & " emp_no ='" & txtCommonTextBox(conTxtEmpCode).Text & "'"
		//        mysql = mysql & " and leave_no = " & txtCommonTextBox(conTxtLeaveCode).Text
		//
		//        mTempValue = GetMasterCode(mysql)
		//        If IsNull(mTempValue) Then
		//            txtCommonTextBox(Index).Text = ""
		//            txtDisplayLabel(conDlblLeaveName).Text = ""
		//            Err.Raise -9990002
		//        Else
		//            txtDisplayLabel(conDlblLeaveName).Text = mTempValue(0)
		//            Call Get_Leave_Balance_Days
		//        End If
		//    Else
		//        txtDisplayLabel(conDlblLeaveName).Text = ""
		//    End If
		//End If
		//
		//Exit Sub
		//
		//eFoundError:
		//Dim mReturnErrorType As Integer
		//mReturnErrorType = ErrorHandlingRoutine(Err.Number, Err.Description, Me.Name, "GetRecord", msg10)
		//If mReturnErrorType = 1 Then
		//'
		//ElseIf mReturnErrorType = 2 Then
		//'
		//ElseIf mReturnErrorType = 3 Then
		//'
		//ElseIf mReturnErrorType = 4 Then
		//    If txtCommonTextBox(Index).Enabled = True Then
		//        txtCommonTextBox(Index).SetFocus
		//    End If
		//Else
		//    '
		//End If
		//End Sub
		//
		//
		//Public Sub FindRoutine(pObjectName As String)
		//Dim mObjectName As String
		//Dim mysql As String
		//Dim mIndex As Integer
		//Dim mTempSearchValue As Variant
		//
		//If InStr(1, pObjectName, "#", vbTextCompare) = 0 Then
		//    Exit Sub
		//End If
		//
		//mObjectName = Left(pObjectName, InStr(1, pObjectName, "#", vbTextCompare) - 1)
		//mIndex = CInt(Mid(pObjectName, InStr(1, pObjectName, "#", vbTextCompare) + 1))
		//
		//
		//If mObjectName = "txtCommonTextBox" Then
		//    txtCommonTextBox(mIndex).Text = ""
		//    Select Case mIndex
		//        Case conTxtEmpCode
		//            mysql = " pay_emp.status_cd = 1 "
		//            mTempSearchValue = FindItem(7050000, "831", mysql)
		//        Case conTxtLeaveCode
		//            If Not IsItEmpty(txtCommonTextBox(conTxtEmpCode).Text, StringType) Then
		//                mysql = " pay_emp.emp_no = " & txtCommonTextBox(conTxtEmpCode).Text
		//                '''Only Active Employee
		//                mysql = mysql & " and pay_emp.status_cd = 1 "
		//                mTempSearchValue = FindItem(7070000, "876", mysql)
		//            Else
		//                MsgBox "Select an Employee ", vbInformation
		//                txtCommonTextBox(conTxtEmpCode).SetFocus
		//            End If
		//        Case Else
		//            Exit Sub
		//    End Select
		//End If
		//
		//If Not IsNull(mTempSearchValue) And Not IsEmpty(mTempSearchValue) Then
		//    If mObjectName = "txtCommonTextBox" Then
		//        txtCommonTextBox(mIndex).Text = mTempSearchValue(1)
		//        Call txtCommonTextBox_LostFocus(mIndex)
		//    End If
		//End If
		//End Sub
		//
		//Private Sub Get_Leave_Balance_Days()
		//Dim mEmpCode As Integer
		//Dim mLeaveCode As Integer
		//Dim mReturnValue As Variant
		//Dim mysql As String
		//
		//If IsItEmpty(txtCommonTextBox(conTxtEmpCode).Text, StringType) Then
		//    Exit Sub
		//Else
		//    mysql = " select emp_cd from pay_employee where emp_no='" & txtCommonTextBox(conTxtEmpCode).Text & "'"
		//    mReturnValue = GetMasterCode(mysql)
		//    If IsNull(mReturnValue) Then
		//        Exit Sub
		//    Else
		//        mEmpCode = mReturnValue
		//    End If
		//End If
		//
		//If IsItEmpty(txtCommonTextBox(conTxtLeaveCode).Text, NumberType) Then
		//    Exit Sub
		//Else
		//    mysql = " select leave_cd from pay_leave where leave_no=" & txtCommonTextBox(conTxtLeaveCode).Text
		//    mReturnValue = GetMasterCode(mysql)
		//    If IsNull(mReturnValue) Then
		//        Exit Sub
		//    Else
		//        mLeaveCode = mReturnValue
		//    End If
		//End If
		//
		//If IsDate(txtCommonDate(conDTxtLeaveFromDate).DisplayText) Then
		//    mReturnValue = Leave_Balance_Days(mEmpCode, mLeaveCode, txtCommonDate(conDTxtLeaveFromDate).DisplayText)
		//    txtDisplayLabel(conDlblLeaveBalanceDays).Text = Format(mReturnValue, "###,###,##0.000")
		//End If
		//
		//End Sub
		//
		//Private Sub LeaveAmount()
		//Dim mEmpCode As Integer
		//Dim mLeaveCode As Integer
		//Dim mReturnValue As Variant
		//Dim mysql As String
		//
		//If mCheck = False Then
		//    Exit Sub
		//End If
		//
		//If IsItEmpty(txtCommonTextBox(conTxtEmpCode).Text, StringType) Then
		//    MsgBox "Enter Employee Code", vbInformation
		//    txtCommonTextBox(conTxtEmpCode).SetFocus
		//    Exit Sub
		//Else
		//    mysql = " select emp_cd from pay_employee where emp_no='" & txtCommonTextBox(conTxtEmpCode).Text & "'"
		//    mReturnValue = GetMasterCode(mysql)
		//    If IsNull(mReturnValue) Then
		//        MsgBox "Invalid Employee Code", vbInformation
		//        txtCommonTextBox(conTxtEmpCode).SetFocus
		//        Exit Sub
		//    Else
		//        mEmpCode = mReturnValue
		//    End If
		//End If
		//
		//If IsItEmpty(txtCommonTextBox(conTxtLeaveCode).Text, StringType) Then
		//    MsgBox "Enter Leave Code", vbInformation
		//    txtCommonTextBox(conTxtLeaveCode).SetFocus
		//    Exit Sub
		//Else
		//    mysql = " select leave_cd from pay_leave where leave_no='" & txtCommonTextBox(conTxtLeaveCode).Text & "'"
		//    mReturnValue = GetMasterCode(mysql)
		//    If IsNull(mReturnValue) Then
		//        MsgBox "Invalid Leave Code", vbInformation
		//        txtCommonTextBox(conTxtLeaveCode).SetFocus
		//        Exit Sub
		//    Else
		//        mLeaveCode = mReturnValue
		//    End If
		//End If
		//
		//If IsDate(txtCommonDate(conDTxtLeaveFromDate).DisplayText) And Not IsItEmpty(txtCommonNumber(conNTxtPaidDays).Value, NumberType) Then
		//    mysql = " select dbo.leaveAmount(" & mEmpCode & "," & mLeaveCode & "," & txtCommonNumber(conNTxtPaidDays).Value & ",'" & txtCommonDate(conDTxtLeaveFromDate).DisplayText & "')"
		//    mReturnValue = GetMasterCode(mysql)
		//    If Not IsNull(mReturnValue) Then
		//        txtDisplayLabel(conDlblLeaveAmount).Text = Format(mReturnValue, "###,###,##0.000")
		//    Else
		//        txtDisplayLabel(conDlblLeaveAmount).Text = "0.000"
		//    End If
		//Else
		//    txtDisplayLabel(conDlblLeaveAmount).Text = "0.000"
		//End If
		//
		//End Sub
		//
		//
		//Public Function Post() As Boolean
		//Dim frmTemp As frmSysOnlinePosting
		//Set frmTemp = New frmSysOnlinePosting
		//
		//If mOldVoucherStatus <> stActive Then
		//    Call VoucherStatusErrorMessage(mOldVoucherStatus, 2)
		//    Post = False
		//    If FirstFocusObject.Enabled = True Then
		//        FirstFocusObject.SetFocus
		//    End If
		//    Exit Function
		//End If
		//
		//'If mOldVoucherStatus = stActive Then
		//'    frmTemp.VisiblePostTransactionToICS = False
		//'    frmTemp.VisiblePostToGL = False
		//'    frmTemp.EnableApprove = True
		//'End If
		//
		//frmTemp.Show 1
		//
		//'if the user clicks on OK button in the frmPost form
		//'If frmTemp.mLastButtonClicked = 1 And frmTemp.mApprove = True Then
		//If frmTemp.mApprove = True Then
		//    Dim ans As Integer
		//
		//    If CurrentFormMode = frmAddMode Then
		//        'Display this message if status is active, which will require to save the record first
		//        ans = MsgBox(msg19 & Chr(13) & Chr(13) & msg7, vbYesNo + vbInformation)
		//    Else
		//        'Display this message if status is not active, which will not require to save the record first
		//        ans = MsgBox("                         Do you want to Post the Record ?                          " & Chr(13) & Chr(13) & Chr(13) & " NOTE :            Yes : To post after saving. " & Chr(13) & "                         No : To post without saving " & Chr(13) & "                         Cancel : To exit without posting ", vbYesNoCancel + vbInformation)
		//    End If
		//
		//    If CurrentFormMode = frmAddMode Then
		//        If ans = vbYes Then
		//            GoTo mend
		//        End If
		//    Else
		//        If ans = vbYes Then
		//            GoTo mend
		//        ElseIf ans = vbNo Then
		//            If frmTemp.mApprove = True Then
		//                gConn.BeginTrans
		//
		//                Call PayPostToHR("Pay_leave_transaction", CLng(SearchValue))
		//                Call PayApprove("Pay_leave_transaction", CLng(SearchValue))
		//                Post_Leave_Transaction (SearchValue)
		//
		//                gConn.CommitTrans
		//            End If
		//        End If
		//
		//        Post = True
		//        GoTo mDestroy
		//    End If
		//End If
		//
		//Post = False
		//GoTo mDestroy
		//
		//mend:
		//'This goto will only come if the voucherstatus is still active
		//If CheckDataValidity = True Then
		//    If saveRecord(frmTemp.mApprove) = True Then
		//        Post = True
		//        GoTo mDestroy
		//    End If
		//End If
		//Post = False
		//
		//mDestroy:
		//Unload frmTemp
		//Set frmTemp = Nothing
		//End Function
		//
		//Private Sub Post_Leave_Transaction(pSearchvalue As Variant)
		//Dim mReturnValue As Variant
		//Dim mysql As String
		//
		//mysql = " select paid_days, unpaid_days,emp_cd"
		//mysql = mysql & " ,leave_cd , leave_amount_payment_type_id , leave_end_date, leave_salary_amount "
		//mysql = mysql & " from pay_leave_transaction "
		//mysql = mysql & " where entry_id = " & pSearchvalue
		//mReturnValue = GetMasterCode(mysql)
		//
		//mysql = " update pay_employee_leave_details "
		//mysql = mysql & " set "
		//mysql = mysql & " paid_leave_taken_days = paid_leave_taken_days + " & mReturnValue(0)
		//mysql = mysql & " , unpaid_leave_taken_days = unpaid_leave_taken_days + " & mReturnValue(1)
		//mysql = mysql & " where emp_cd =" & mReturnValue(2)
		//mysql = mysql & " and leave_cd =" & mReturnValue(3)
		//gConn.Execute mysql
		//
		//''''If Pay with payroll
		//If mReturnValue(4) = gPayWithPayroll And Val(mReturnValue(5)) > 0 Then
		//    mysql = " insert into pay_payroll ( pay_date, emp_cd, bill_cd, dept_cd"
		//    mysql = mysql & " , desg_cd, comp_cd, billing_mode, pay_hours, pay_days"
		//    mysql = mysql & " , fc_amount, trans_type, trans_id, rate_calc_method_id, weekend"
		//    mysql = mysql & " , weekend_day1_id, weekend_day2_id "
		//    mysql = mysql & " , salary "
		//    mysql = mysql & " , days_per_month, hours_per_day, linked_leave "
		//    mysql = mysql & " , payment_type_id, bank_cd, bank_branch_cd "
		//    mysql = mysql & " , bank_account_no "
		//    mysql = mysql & " , leave_switch_over_period "
		//    mysql = mysql & " , leave_days_before_sop, leave_days_after_sop"
		//    mysql = mysql & " , working_days_per_month_before_sop "
		//    mysql = mysql & " , working_days_per_month_after_sop, deduct_paid_days "
		//    mysql = mysql & " , deduct_unpaid_days, opening_paid_leave_balance_date "
		//    mysql = mysql & " , opening_paid_leave_balance_days "
		//    mysql = mysql & " , user_cd ) "
		//
		//    mysql = mysql & " select "
		//    'mysql = mysql & " (select max(generate_date) from Pay_Payroll_Generate_History) "   'PayDate
		//    mysql = mysql & "'" & GetPayrollGenerateDate & "'"
		//    mysql = mysql & " , emp_cd "                                'Emp_cd
		//    mysql = mysql & " , bill_cd "                               'Bill_cd
		//    mysql = mysql & " , dept_cd "                               'Dept_cd
		//    mysql = mysql & " , desg_cd "                               'Desg_cd
		//    mysql = mysql & " , comp_cd "                               'Comp_cd
		//    mysql = mysql & " , 'T'"                                    'Billing_Mode
		//    mysql = mysql & " , 0 "                                     'Pay_Hours
		//    mysql = mysql & " , paid_days"                              'Pay_days
		//    mysql = mysql & " , leave_salary_amount"                    'Fc_amount
		//    mysql = mysql & " , 'LeaveTrn' "                            'Trans_type
		//    mysql = mysql & " , NULL "                                  'Trans_id
		//    mysql = mysql & " , rate_calc_method_id "                   'Rate_Calc_method_id
		//    mysql = mysql & " , weekend"                                'Weekend
		//    mysql = mysql & " , weekend_day1_id"                        'Weekend_day1_id
		//    mysql = mysql & " , weekend_day2_id"                        'Weekend_day2_id
		//    mysql = mysql & " , leave_salary"                           'Leave_Salary
		//    mysql = mysql & " , days_per_month"                         'Days_per_month
		//    mysql = mysql & " , hours_per_day"                          'Hours_per_day
		//    mysql = mysql & " , 1"                                      'Linked_Leave
		//    mysql = mysql & " , payment_type_id"                        'Payment_type_id
		//    mysql = mysql & " , bank_cd "                               'Bank_cd
		//    mysql = mysql & " , bank_branch_cd"                         'Bank_branch_cd
		//    mysql = mysql & " , bank_account_no"                        'Bank_account_no
		//    mysql = mysql & " , leave_switch_over_period"               'Leave_Switch_Over_Period
		//    mysql = mysql & " , leave_days_before_sop"                  'Leave_days_before_sop
		//    mysql = mysql & " , leave_days_after_sop"
		//    mysql = mysql & " , working_days_per_month_before_sop"
		//    mysql = mysql & " , working_days_per_month_after_sop"
		//    mysql = mysql & " , deduct_paid_days "
		//    mysql = mysql & " , deduct_unpaid_days "
		//    mysql = mysql & " , opening_paid_leave_balance_date"
		//    mysql = mysql & " , opening_paid_leave_balance_days"
		//    mysql = mysql & " , plt.user_cd "                           'User_Cd
		//    mysql = mysql & " from pay_billing_type pbt "
		//    mysql = mysql & " inner join pay_leave_transaction plt on pbt.linked_leave_cd = plt.leave_cd "
		//    mysql = mysql & " where entry_id = " & pSearchvalue
		//    'mysql = mysql & " and plt.leave_salary_amount > 0  "
		//    gConn.Execute mysql
		//End If
		//
		//End Sub
		private void Form_Closed(Object eventSender, EventArgs eventArgs)
		{
		}
	}
}