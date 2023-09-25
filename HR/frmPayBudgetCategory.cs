using System;

namespace Xtreme
{
	internal partial class frmPayBudgetCategory
		: System.Windows.Forms.Form
	{

		public frmPayBudgetCategory()
{
InitializeComponent();
} 
 public  void frmPayBudgetCategory_old()
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


		private void frmPayBudgetCategory_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (UpgradeHelpers.Gui.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Gui.ActivateHelper.myActiveForm = (System.Windows.Forms.Form) eventSender;
			}
		}
		//''Option Explicit
		//''Public UserAccess As New clsAccessAllowed
		//''Public FirstFocusObject As Control
		//''Private mTimeStamp As String
		//''
		//''Private rsBillingCodeList As New ADODB.Recordset
		//''Private mFirstGridFocus As Boolean
		//''Private aVoucherDetails As New XArrayDB
		//''Private Const conMaxColumns As Integer = 3
		//''
		//''Private mThisFormID As Long
		//''Private mSearchValue As Variant
		//''Private oThisFormToolBar As clsToolbar
		//''Private mCurrentFormMode  As SystemFormModes
		//''Private Const conCmbBillingTypes As Integer = 0
		//''Private Const conCmbBillingMethod As Long = 1
		//''
		//''Private Const conTxtLedgerCode As Integer = 0
		//''Private Const conTxtCostCode As Integer = 1
		//''
		//''Private Const conDlblLedgerName As Integer = 0
		//''Private Const conDlblCostName As Integer = 1
		//''
		//''Private Const mconBillNo As Long = 1
		//''Private Const mconBillName As Long = 2
		//''Private Const mconbillCode As Long = 3
		//''
		//''Private Const tabBillingDetails As Long = 0
		//''Private Const tabBillingsSubDetails As Long = 1
		//''
		//''Public Property Get ThisFormId() As Long
		//''    ThisFormId = mThisFormID
		//''End Property
		//''
		//''Public Property Let ThisFormId(ByVal NewFormId As Long)
		//''    mThisFormID = NewFormId
		//''End Property
		//''
		//''Public Property Get SearchValue() As Variant
		//''SearchValue = mSearchValue
		//''End Property
		//''
		//''Public Property Let SearchValue(ByVal vNewValue As Variant)
		//''mSearchValue = vNewValue
		//''End Property
		//''
		//'''These property set the Form mode to add mode or edit mode
		//''Public Property Get CurrentFormMode() As SystemFormModes
		//''    CurrentFormMode = mCurrentFormMode
		//''End Property
		//''
		//''Public Property Let CurrentFormMode(ByVal vNewValue As SystemFormModes)
		//''    mCurrentFormMode = vNewValue
		//''End Property
		//''
		//''
		//''
		//''Private Sub Form_Load()
		//''
		//''On Error GoTo eFoundError
		//''
		//''Me.CurrentFormMode = frmAddMode
		//''Me.Top = 0
		//''Me.Left = 0
		//''
		//'''**--format & define the new toolbar
		//''Set oThisFormToolBar = New clsToolbar
		//''With oThisFormToolBar
		//''    .AttachObject Me ', tcbSystemForm
		//''
		//''    .ShowNewButton = True
		//''    .ShowSaveButton = True
		//''    .ShowDeleteButton = True
		//''    .ShowPrintButton = False
		//''    .ShowFindButton = True
		//''    .ShowHelpButton = True
		//''    .ShowExitButton = True
		//''    .ShowDeleteLineButton = True
		//''    .ShowInsertLineButton = True
		//''    .BeginExitButtonWithGroup = True
		//''    .DisableHelpButton = True
		//''
		//''    Me.WindowState = FormWindowStateConstants.vbMaximized
		//''End With
		//''
		//''mFirstGridFocus = True
		//''
		//'''''Asssign Earnings Details Grid
		//''Call DefineSystemVoucherGrid(grdLeaveEarningDetails, , , True, , , , , dbgSolidCellBorder, 2, , "&H00C4B8CD", "&H00C4B8CD")
		//''Call DefineSystemVoucherGridColumn(grdLeaveEarningDetails, "LN", 400, False, "&HC4B8CD", , , False)
		//''Call DefineSystemVoucherGridColumn(grdLeaveEarningDetails, "Category", 2000, , , , , False, , , True, , , "cmbMastersList")
		//''Call DefineSystemVoucherGridColumn(grdLeaveEarningDetails, "Category Name", 3250, , , &HB4261B, , False, , , True, , , "cmbMastersList")
		//''Call DefineSystemVoucherGridColumn(grdLeaveEarningDetails, "Transaction Date", 3250, , , &HB4261B, , False, , , True, , , "cmbMastersList")
		//''Call DefineSystemVoucherGridColumn(grdLeaveEarningDetails, "Budgeted Monthly Salary", 3250, , , &HB4261B, , False, , , True, , , "cmbMastersList")
		//''Call DefineSystemVoucherGridColumn(grdLeaveEarningDetails, "Current Monthly Salary", 3250, , , &HB4261B, , False, , , True, , , "cmbMastersList")
		//''Call DefineSystemVoucherGridColumn(grdLeaveEarningDetails, "Opening HC", 3250, , , &HB4261B, , False, , , True, , , "cmbMastersList")
		//''Call DefineSystemVoucherGridColumn(grdLeaveEarningDetails, "Opening replacement HC", 3250, , , &HB4261B, , False, , , True, , , "cmbMastersList")
		//''Call DefineSystemVoucherGridColumn(grdLeaveEarningDetails, "Details", 3250, , , &HB4261B, , False, , , True, , , "cmbMastersList")
		//''Call DefineSystemVoucherGridColumn(grdLeaveEarningDetails, "BillCd", 2500, True, , , , False, , , , , , , , False)
		//''
		//''Call DefineVoucherArray(-1, False)
		//''Call AssignGridLineNumbers
		//''
		//''Set grdLeaveEarningDetails.Array = aVoucherDetails
		//''grdLeaveEarningDetails.ReBind
		//'''grdLeaveEarningDetails.Enabled = True
		//''
		//''Call SetLabelCaption(Me)
		//''
		//''
		//''Exit Sub
		//''eFoundError:
		//''Call ErrorHandlingRoutine(Err.Number, Err.Description, Me.Name, "Form Load")
		//''Unload Me
		//''End Sub
		//''
		//''Private Sub DefineVoucherArray(pMaximumRows As Long, Optional pClearArray As Boolean = False)
		//''If pClearArray = True Then
		//''    aVoucherDetails.Clear
		//''End If
		//''aVoucherDetails.ReDim 0, pMaximumRows, 0, conMaxColumns
		//''End Sub
		//''
		//''Private Sub AssignGridLineNumbers()
		//''Dim cnt As Long
		//''For cnt = 0 To aVoucherDetails.Count(1) - 1
		//''    aVoucherDetails(cnt, grdLineNoColumn) = cnt + 1
		//''Next
		//''End Sub
		//''
		//''Private Sub Form_KeyDown(KeyCode As Integer, Shift As Integer)
		//'''On Keydown navigate the form by using enter key
		//''If KeyCode = 13 Then    'If enter key pressed send a tab key
		//''    SendKeys "{TAB}"
		//''    Exit Sub
		//''End If
		//''Call SystemFormKeyDown(Me, KeyCode, Shift, Me.ActiveControl.Name)
		//''End Sub
		//''
		//''Public Sub AddRecord()
		//'''Add a record
		//''Call ClearTextBox(Me)
		//''Call DefineVoucherArray(-1, True)
		//''Call AssignGridLineNumbers
		//''grdLeaveEarningDetails.ReBind
		//'''grdLeaveEarningDetails.Enabled = True
		//''
		//''txtBillNo.Text = GetNewNumber("Pay_Billing_Type", "Bill_no")
		//''txtNoOfMonths.Enabled = False
		//''txtNoOfMonths.Value = 0
		//''OptNone.Value = True
		//''
		//''mCurrentFormMode = frmAddMode                           'Change the form mode to addmode
		//''mSearchValue = ""                                       'Change the msearchvalue to blank
		//'''chkOverTime.Value = 0
		//''chkIncludeInDefaultBillingTypes.Value = 0
		//'''chkCalculated.Value = 0
		//'''FirstFocusObject.SetFocus
		//''Me.tabBillingType.TabVisible(tabBillingDetails) = True
		//''Me.tabBillingType.CurrTab = tabBillingDetails
		//''txtRoundDigit.Text = "3"
		//''mFirstGridFocus = True
		//''CHKIncludeInBankTransfer.Value = 1
		//''
		//''Exit Sub
		//''eFoundError:
		//''Call ErrorHandlingRoutine(Err.Number, Err.Description, Me.Name, "AddRecord")
		//''End Sub
		//''
		//''Public Function saveRecord() As Boolean
		//''Dim mReturnValue As Variant
		//'''Dim mParentBillCode As Integer
		//'''Save a record
		//'''During save check for the mode
		//'''If in addmode then insert a record
		//'''else update the record in the recordset
		//''
		//''Dim mySQL As String
		//''On Error GoTo eFoundError
		//''
		//''gConn.BeginTrans
		//''If mCurrentFormMode = frmAddMode Then
		//''    mySQL = " INSERT INTO Pay_Billing_Type(user_cd, Bill_no, l_Bill_name"
		//''    mySQL = mySQL & " , a_Bill_name, bill_type_id "
		//''    'mySql = mySql & " , include_in_default_billing_types, over_time, comments)"
		//''    mySQL = mySQL & " , include_in_default_billing_types,is_calculate"
		//''    mySQL = mySQL & " ,rounding_method,bill_type_method, comments,Is_Period,No_Of_Month,Include_In_Bank_Transfer)"
		//''    mySQL = mySQL & " VALUES(" & Str(gLoggedInUserCode)
		//''    mySQL = mySQL & " , " & txtBillNo.Text
		//''    mySQL = mySQL & ",'" & txtLBillName.Text & "'"
		//''    mySQL = mySQL & ",N'" & txtABillName.Text & "'"
		//''    mySQL = mySQL & ", " & cmbCommon(conCmbBillingTypes).ItemData(cmbCommon(conCmbBillingTypes).ListIndex)
		//''    mySQL = mySQL & " , " & chkIncludeInDefaultBillingTypes.Value
		//''    'mySql = mySql & " , " & chkOverTime.Value
		//''    mySQL = mySQL & " , " & IIf(OptChkCalculate.Value, 1, 0)
		//''    mySQL = mySQL & " , " & CInt(txtRoundDigit.Text)
		//''    mySQL = mySQL & " , " & cmbCommon(conCmbBillingMethod).ItemData(cmbCommon(conCmbBillingMethod).ListIndex)
		//''    mySQL = mySQL & ", N'" & txtComment.Text & "'"
		//''    mySQL = mySQL & ", " & IIf(OptPriodWise.Value, 1, 0)
		//''    mySQL = mySQL & ", " & txtNoOfMonths.Value
		//''    mySQL = mySQL & ", " & IIf(CHKIncludeInBankTransfer.Value, 1, 0)
		//''    mySQL = mySQL & ")"
		//''    gConn.Execute (mySQL)
		//''    mSearchValue = GetMasterCode("select scope_identity()")
		//''Else
		//''    Dim mCheckTimeStamp As String
		//''    mySQL = " select time_stamp,protected from Pay_Billing_Type where Bill_cd =" & mSearchValue
		//''    mReturnValue = GetMasterCode(mySQL)
		//''    If Not IsNull(mReturnValue) Then
		//''        mCheckTimeStamp = mReturnValue(0)
		//''    Else
		//''        MsgBox msg10, vbInformation
		//''        gConn.RollBackTrans
		//''        saveRecord = False
		//''        FirstFocusObject.SetFocus
		//''        Exit Function
		//''    End If
		//''    If (tsFormat(mTimeStamp) <> tsFormat(mCheckTimeStamp)) Then
		//''        MsgBox msg10, vbInformation
		//''        gConn.RollBackTrans
		//''        saveRecord = False
		//''        FirstFocusObject.SetFocus
		//''        Exit Function
		//''    End If
		//''
		//''    mySQL = "UPDATE Pay_Billing_Type SET "
		//''    mySQL = mySQL & " Bill_No =" & txtBillNo.Text
		//''    mySQL = mySQL & " , L_Bill_Name ='" & txtLBillName.Text & "'"
		//''    mySQL = mySQL & " , A_Bill_Name =N'" & txtABillName.Text & "'"
		//''    mySQL = mySQL & " , bill_type_id=" & cmbCommon(conCmbBillingTypes).ItemData(cmbCommon(conCmbBillingTypes).ListIndex)
		//''    mySQL = mySQL & " , include_in_default_billing_types=" & chkIncludeInDefaultBillingTypes.Value
		//''    'mySql = mySql & " , over_time =" & chkOverTime.Value
		//''    mySQL = mySQL & " , Comments =N'" & txtComment.Text & "'"
		//''    mySQL = mySQL & " , User_Cd =" & Str(gLoggedInUserCode)
		//''    mySQL = mySQL & " , is_calculate=" & IIf(OptChkCalculate.Value, 1, 0)
		//''    mySQL = mySQL & " , Include_In_Bank_Transfer = " & IIf(CHKIncludeInBankTransfer.Value, 1, 0)
		//''    mySQL = mySQL & " , rounding_method=" & CInt(txtRoundDigit.Text)
		//''    mySQL = mySQL & " , bill_type_method=" & cmbCommon(conCmbBillingMethod).ItemData(cmbCommon(conCmbBillingMethod).ListIndex)
		//''    mySQL = mySQL & " , Is_Period = " & IIf(OptPriodWise.Value, 1, 0)
		//''    mySQL = mySQL & " , No_Of_Month = " & txtNoOfMonths.Value
		//''    mySQL = mySQL & " where Bill_cd=" & Str(mSearchValue)
		//''    gConn.Execute (mySQL)
		//''End If
		//''mySQL = " delete from pay_billing_type_details where bill_cd = " & mSearchValue
		//''gConn.Execute mySQL
		//''grdLeaveEarningDetails.Update
		//''
		//''Dim mCnt As Integer
		//''For mCnt = 0 To aVoucherDetails.Count(1) - 1
		//''    mySQL = " insert into pay_billing_type_details(bill_cd,linked_bill_cd)"
		//''    mySQL = mySQL & " values(" & mSearchValue
		//''    mySQL = mySQL & " ," & aVoucherDetails(mCnt, mconbillCode)
		//''    mySQL = mySQL & ")"
		//''    gConn.Execute mySQL
		//''Next
		//''
		//''gConn.CommitTrans
		//''saveRecord = True
		//''Exit Function
		//''
		//''eFoundError:
		//''Dim mReturnErrorType As Integer
		//''mReturnErrorType = ErrorHandlingRoutine(Err.Number, Err.Description, Me.Name, "GetRecord", msg10)
		//''gConn.RollBackTrans
		//''saveRecord = False
		//''End Function
		//''
		//''Public Function deleteRecord()
		//''Dim mySQL As String
		//''Dim mReturnValue  As Variant
		//''
		//''mySQL = " select protected from Pay_Billing_Type where Bill_cd=" & mSearchValue
		//''mReturnValue = GetMasterCode(mySQL)
		//''If Not IsNull(mReturnValue) Then
		//''    If mReturnValue Then
		//''        MsgBox msg12, vbInformation
		//''        deleteRecord = False
		//''        Exit Function
		//''    End If
		//''
		//''    'If an error occurs, trap the error and dispaly a valid message
		//''    gConn.BeginTrans
		//''
		//''    On Error Resume Next
		//''    mySQL = "delete from Pay_Billing_Type where Bill_cd=" & Str(mSearchValue)
		//''    gConn.Execute mySQL
		//''
		//''    If Err.Number <> 0 Then
		//''        MsgBox "Billing Type cannot be deleted, transaction already occurs", vbInformation
		//''        gConn.RollBackTrans
		//''        deleteRecord = False
		//''        Exit Function
		//''    End If
		//''
		//''    gConn.CommitTrans
		//''    deleteRecord = True
		//''End If
		//''
		//''Exit Function
		//''eFoundError:
		//''Dim mReturnErrorType As Integer
		//''mReturnErrorType = ErrorHandlingRoutine(Err.Number, Err.Description, Me.Name, "GetRecord", msg10)
		//''If mReturnErrorType = 1 Then
		//''    deleteRecord = False
		//''ElseIf mReturnErrorType = 2 Then
		//''    Call AddRecord
		//''    deleteRecord = False
		//''Else
		//''    deleteRecord = False
		//''End If
		//''End Function
		//''
		//''Public Sub GetRecord(SearchValue As Variant)
		//'''This routine is called after getting the value from Find window or
		//'''refreshing the recordset during any error of updating or deleting
		//''
		//''On Error GoTo eFoundError
		//''Dim mySQL As String
		//''Dim mReturnValue As Variant
		//''Dim localRec As ADODB.Recordset
		//''
		//''Call DefineVoucherArray(-1, False)
		//''Call AssignGridLineNumbers
		//''Set grdLeaveEarningDetails.Array = aVoucherDetails
		//''grdLeaveEarningDetails.ReBind
		//''
		//''mySQL = " select * from Pay_Billing_Type where Bill_cd= " & SearchValue
		//''
		//''Set localRec = New ADODB.Recordset
		//''localRec.Open mySQL, gConn, adOpenForwardOnly, adLockReadOnly
		//''With localRec
		//''    If Not .EOF Then
		//''        mSearchValue = .Fields("Bill_cd")
		//''        mTimeStamp = .Fields("time_stamp")
		//''        txtBillNo.Text = .Fields("Bill_no")
		//''        txtLBillName.Text = .Fields("l_Bill_Name")
		//''        txtABillName.Text = .Fields("a_Bill_Name") & ""
		//''
		//''        SearchCombo cmbCommon(conCmbBillingTypes), .Fields("bill_type_id")
		//''        SearchCombo cmbCommon(conCmbBillingMethod), .Fields("bill_type_method")
		//''
		//''        chkIncludeInDefaultBillingTypes.Value = IIf(.Fields("include_in_default_billing_types") = True, 1, 0)
		//''        CHKIncludeInBankTransfer.Value = IIf(.Fields("Include_In_Bank_Transfer") = True, 1, 0)
		//''        'chkOverTime.Value = IIf(.Fields("over_time") = True, 1, 0)
		//''        txtComment.Text = .Fields("Comments") & ""
		//''        OptChkCalculate.Value = IIf(.Fields("is_calculate") = True, 1, 0)
		//''        OptPriodWise.Value = IIf(.Fields("is_period") = True, 1, 0)
		//''        If .Fields("is_period") = False And .Fields("is_period") = False Then
		//''           OptNone.Value = True
		//''        End If
		//''
		//''        txtNoOfMonths.Value = .Fields("No_of_Month")
		//''        txtRoundDigit.Text = .Fields("Rounding_Method")
		//''        'Change the form mode to edit
		//''        mCurrentFormMode = frmEditMode
		//''    End If
		//''End With
		//''localRec.Close
		//''Set localRec = Nothing
		//''
		//''Dim mCntRow As Integer
		//''mySQL = " select pbt.bill_no ,pbt.bill_cd ,  " & IIf(gPreferedLanguage = english, " pbt.l_bill_name", " pbt.a_bill_name") & " as bill_Name"
		//''mySQL = mySQL & " from pay_billing_type_details pbtd"
		//''mySQL = mySQL & " inner join pay_billing_type pbt on pbt.bill_cd = pbtd.linked_bill_cd"
		//''mySQL = mySQL & " where pbtd.bill_cd =" & CStr(mSearchValue)
		//''Set localRec = New ADODB.Recordset
		//''With localRec
		//''    .Open mySQL, gConn, adOpenForwardOnly, adLockReadOnly
		//''    aVoucherDetails.ReDim 0, .RecordCount - 1, 0, conMaxColumns
		//''    mCntRow = 0
		//''    Do While Not .EOF
		//''        aVoucherDetails(mCntRow, mconBillNo) = .Fields("bill_no").Value
		//''        aVoucherDetails(mCntRow, mconBillName) = .Fields("bill_Name").Value
		//''        aVoucherDetails(mCntRow, mconbillCode) = .Fields("bill_cd").Value
		//''        mCntRow = mCntRow + 1
		//''        .MoveNext
		//''    Loop
		//''    Call AssignGridLineNumbers
		//''    grdLeaveEarningDetails.ReBind
		//''    grdLeaveEarningDetails.Refresh
		//''End With
		//''localRec.Close
		//''Set localRec = Nothing
		//''
		//''mFirstGridFocus = True
		//''If mFirstGridFocus = True Then
		//''    Call grdLeaveEarningDetails_GotFocus
		//''End If
		//''
		//''Me.tabBillingType.TabVisible(tabBillingDetails) = True
		//''Me.tabBillingType.CurrTab = tabBillingDetails
		//''DoEvents
		//''
		//''Exit Sub
		//''eFoundError:
		//''Call ErrorHandlingRoutine(Err.Number, Err.Description, Me.Name, "GetRecord")
		//''End Sub
		//''
		//''Public Sub PrintReport()
		//''
		//''End Sub
		//''
		//''Public Sub findRecord()
		//'''Call the find window
		//''Dim mTempSearchValue As Variant
		//''Dim mySQL As String
		//''mySQL = " pbt.show =  1 "
		//''mTempSearchValue = FindItem(7008000, , mySQL)
		//''If Not IsNull(mTempSearchValue) Then
		//''    mSearchValue = mTempSearchValue(0)
		//''    Call GetRecord(mSearchValue)
		//''End If
		//''End Sub
		//''
		//''Public Sub CloseForm()
		//''Unload Me
		//''End Sub
		//''
		//''Function CheckDataValidity() As Boolean
		//'''Check validation during update and add of records
		//''If Not IsNumeric(txtBillNo.Text) Then
		//''    MsgBox "Enter Bill Code", vbInformation, "Required"
		//''    FirstFocusObject.SetFocus
		//''    CheckDataValidity = False
		//''    Exit Function
		//''End If
		//''
		//''If Not IsNumeric(txtRoundDigit.Text) Then
		//''    MsgBox "Enter Digits to Round", vbInformation, "Required"
		//''    txtRoundDigit.SetFocus
		//''    CheckDataValidity = False
		//''    Exit Function
		//''End If
		//''
		//''CheckDataValidity = True
		//''End Function
		//''
		//''Private Sub Form_Unload(Cancel As Integer)
		//''On Error Resume Next
		//''
		//''Call RemoveMeFromWindowList(Str(Me.hwnd))
		//''
		//''Set UserAccess = Nothing
		//''Set oThisFormToolBar = Nothing
		//''Set frmPayBudgetCategory = Nothing
		//''End Sub
		//''
		//''
		//''
		//''Private Sub OptChkCalculate_Click()
		//''txtNoOfMonths.Enabled = False
		//''End Sub
		//''
		//''Private Sub OptNone_Click()
		//''txtNoOfMonths.Enabled = False
		//''End Sub
		//''
		//''Private Sub OptPriodWise_Click()
		//''txtNoOfMonths.Enabled = OptPriodWise.Value
		//''End Sub
		//''
		//''Private Sub txtBillNo_DropButtonClick()
		//'''Get the maximum + 1 product_category code
		//''Call GetNextNumber
		//''End Sub
		//''
		//''Private Sub GetNextNumber()
		//''txtBillNo.Text = GetNewNumber("Pay_Billing_Type", "Bill_no")
		//''FirstFocusObject.SetFocus
		//''End Sub
		//''
		//''''''' For Calculated field
		//''
		//''Private Sub cmbMastersList_DataSourceChanged()
		//''Dim cnt As Long
		//''
		//''cmbMastersList.Width = 0
		//''
		//''Select Case grdLeaveEarningDetails.Col
		//''    Case mconBillNo, mconBillName
		//''        If grdLeaveEarningDetails.Col = mconBillNo Then
		//''            cmbMastersList.ListField = "bill_no"
		//''            rsBillingCodeList.Sort = "bill_no"
		//''        Else
		//''            cmbMastersList.ListField = "bill_name"
		//''            rsBillingCodeList.Sort = "bill_name"
		//''        End If
		//''
		//''        For cnt = 0 To cmbMastersList.Columns.Count - 1
		//''            With cmbMastersList.Columns(cnt)
		//''                If cnt < 4 Then
		//''                    If cnt = 0 Then
		//''                        .Order = IIf(grdLeaveEarningDetails.Col = mconBillNo, 0, 1)
		//''                        .Width = grdLeaveEarningDetails.Columns(mconBillNo).Width
		//''                    ElseIf cnt = 1 Then
		//''                        .Order = IIf(grdLeaveEarningDetails.Col = mconBillNo, 1, 0)
		//''                        .Width = grdLeaveEarningDetails.Columns(mconBillName).Width
		//''                    End If
		//''                    .Alignment = dbgLeft
		//''                    .Visible = True
		//''                    cmbMastersList.Width = cmbMastersList.Width + .Width
		//''                Else
		//''                    .Visible = False
		//''                End If
		//''                .AllowSizing = False
		//''            End With
		//''        Next
		//''        cmbMastersList.Width = cmbMastersList.Width + 250
		//''        cmbMastersList.Height = 2500
		//''End Select
		//''End Sub
		//''
		//''Private Sub cmbMastersList_RowChange()
		//''If grdLeaveEarningDetails.Col = mconBillNo Or grdLeaveEarningDetails.Col = mconBillName Then
		//''    grdLeaveEarningDetails.Columns(mconBillNo).Value = cmbMastersList.Columns(0).Value
		//''    grdLeaveEarningDetails.Columns(mconBillName).Value = cmbMastersList.Columns(1).Value
		//''    grdLeaveEarningDetails.Columns(mconbillCode).Value = cmbMastersList.Columns(4).Value
		//''End If
		//''End Sub
		//''
		//''Private Sub cmbMastersList_DropDownClose()
		//''Select Case grdLeaveEarningDetails.Col
		//''    Case mconBillNo, mconBillName
		//''        If grdLeaveEarningDetails.Col = mconBillNo Then
		//''            grdLeaveEarningDetails.Col = mconBillNo
		//''        Else
		//''            grdLeaveEarningDetails.Col = mconBillName
		//''        End If
		//''End Select
		//''End Sub
		//''
		//''Private Sub DefineMasterRecordset()
		//''Dim mySQL As String
		//''
		//'''If IsItEmpty(mSearchValue, NumberType) = True Then
		//'''    Exit Sub
		//'''End If
		//''
		//''If mFirstGridFocus = True Then
		//''    mySQL = " select bill_no "
		//''    mySQL = mySQL & " , " & IIf(gPreferedLanguage = english, "l_bill_name as bill_name", "a_bill_name as bill_name")
		//''    If gPreferedLanguage = english Then
		//''        mySQL = mySQL & " , (select l_object_caption from SM_Objects sobj where sobj.object_id = pbt.bill_type_id) "
		//''    Else
		//''        mySQL = mySQL & " , (select a_object_caption from SM_Objects sobj where sobj.object_id = pbt.bill_type_id) "
		//''    End If
		//''    mySQL = mySQL & " , pbt.bill_type_id as bill_type_id, pbt.bill_cd " '''''''
		//''    mySQL = mySQL & " from pay_billing_type pbt "
		//''    mySQL = mySQL & " where Is_Calculate = 0"
		//''   ' mysql = mysql & " and protected <> 1 "
		//''    If CurrentFormMode = frmEditMode Then
		//''      mySQL = mySQL & " and bill_cd <> " & mSearchValue
		//''    End If
		//''    mySQL = mySQL & " order by 1 "
		//''
		//''
		//''    Set rsBillingCodeList = New ADODB.Recordset
		//''    rsBillingCodeList.CursorLocation = adUseClient
		//''    rsBillingCodeList.Open mySQL, gConn, adOpenForwardOnly, adLockReadOnly
		//''Else
		//''    rsBillingCodeList.Requery
		//''End If
		//''End Sub
		//''
		//''Private Sub grdLeaveEarningDetails_GotFocus()
		//''Dim mySQL As String
		//''If mFirstGridFocus = True Then
		//''    If cmbMastersList.Tag = "" Then
		//''        Call DefineSystemGridCombo(cmbMastersList)
		//''        cmbMastersList.Tag = "OK"
		//''    End If
		//''
		//''    Call DefineMasterRecordset
		//''    mFirstGridFocus = False
		//''    Call grdLeaveEarningDetails_PostEvent(1)
		//''End If
		//''End Sub
		//''
		//''Private Sub grdLeaveEarningDetails_RowColChange(LastRow As Variant, ByVal LastCol As Integer)
		//''If grdLeaveEarningDetails.Col > 0 And LastCol > 0 And mFirstGridFocus = False Then
		//''    Select Case grdLeaveEarningDetails.Col
		//''        Case mconBillNo, mconBillName
		//''            Set cmbMastersList.DataSource = rsBillingCodeList
		//''    End Select
		//''End If
		//''End Sub
		//''
		//''Private Sub grdLeaveEarningDetails_PostEvent(ByVal MsgId As Integer)
		//''Dim Col As Integer
		//''
		//''If MsgId = 1 Then
		//''    grdLeaveEarningDetails.Col = mconBillNo
		//''    Set cmbMastersList.DataSource = rsBillingCodeList
		//''End If
		//''End Sub
		//''
		//''Public Sub IRoutine()
		//''Dim mCurrentLineNo As Long
		//''
		//''If ActiveControl.Name <> "grdLeaveEarningDetails" And grdLeaveEarningDetails.Enabled = True Then
		//''    grdLeaveEarningDetails.SetFocus
		//''End If
		//''If Not IsNull(grdLeaveEarningDetails.Bookmark) Then
		//''    mCurrentLineNo = grdLeaveEarningDetails.Columns(grdLineNoColumn).Value
		//''    aVoucherDetails.InsertRows (grdLeaveEarningDetails.Bookmark)
		//''    Call AssignGridLineNumbers
		//''    grdLeaveEarningDetails.ReBind
		//''End If
		//''End Sub
		//''
		//''Public Sub LRoutine()
		//''If ActiveControl.Name <> "grdLeaveEarningDetails" And grdLeaveEarningDetails.Enabled = True Then
		//''    grdLeaveEarningDetails.SetFocus
		//''End If
		//''
		//''If aVoucherDetails.Count(1) > 0 Then
		//''    grdLeaveEarningDetails.Delete
		//''    Call AssignGridLineNumbers
		//''    grdLeaveEarningDetails.ReBind
		//''End If
		//''End Sub
		//''
		//'''
		//'''Private Sub txtCommon_DropButtonClick(Index As Integer)
		//'''    Call FindRoutine("txtCommon#" & Trim(Index))
		//'''End Sub
		//'''
		//'''Private Sub txtCommon_LostFocus(Index As Integer)
		//'''Dim mTempValue As Variant
		//'''Dim mysql As String
		//'''Dim mLinkedTextBoxIndex As Integer
		//'''
		//'''On Error GoTo eFoundError
		//'''
		//'''Select Case Index
		//'''    Case conTxtLedgerCode
		//'''        mysql = "select l_ldgr_name, a_ldgr_name, ldgr_cd, curr_cd from ledger where show = 1 and ldgr_no='" & txtCommon(Index).Text & "'"
		//''''        mysql = mysql & " and ( ldgr_type = '" & Left(gGLCustomerVendorTypeCode, 4) & "'"
		//''''        mysql = mysql & " or ldgr_type = '" & Left(gGLCustomerVendorTypeCode, 4) & "'" & ")"
		//'''
		//'''        mLinkedTextBoxIndex = conDlblLedgerName
		//'''    Case conTxtCostCode
		//'''        mysql = "select l_cost_name, a_cost_name, cost_cd from gl_cost_centers where show = 1 and cost_no=" & txtCommon(Index).Text
		//'''        mLinkedTextBoxIndex = conDlblCostName
		//'''    Case Else
		//'''        Exit Sub
		//'''End Select
		//'''
		//'''If Not IsItEmpty(txtCommon(Index).Text, StringType) Then
		//'''    mTempValue = GetMasterCode(mysql)
		//'''    If IsNull(mTempValue) Then
		//'''        txtDisplayLabel(mLinkedTextBoxIndex).Text = ""
		//'''        txtCommon(Index).Tag = ""
		//'''        Err.Raise -9990002
		//'''    Else
		//'''        txtDisplayLabel(mLinkedTextBoxIndex).Text = IIf(gPreferedLanguage = english, mTempValue(0), mTempValue(1))
		//'''        txtCommon(Index).Tag = mTempValue(2)
		//'''    End If
		//'''Else
		//'''    txtCommonDisplay(mLinkedTextBoxIndex).Text = ""
		//'''    txtCommon(Index).Tag = ""
		//'''End If
		//'''Exit Sub
		//'''
		//'''
		//'''eFoundError:
		//'''Dim mReturnErrorType As Integer
		//'''mReturnErrorType = ErrorHandlingRoutine(Err.Number, Err.Description, Me.Name, "GetRecord", msg10)
		//'''If mReturnErrorType = 1 Then
		//''''
		//'''ElseIf mReturnErrorType = 2 Then
		//''''
		//'''ElseIf mReturnErrorType = 3 Then
		//''''
		//'''ElseIf mReturnErrorType = 4 Then
		//'''    'if the code is not found
		//'''    On Error Resume Next
		//'''    txtCommon(Index).SetFocus
		//'''Else
		//'''    '
		//'''End If
		//'''
		//'''End Sub
		//''
		private void Form_Closed(Object eventSender, EventArgs eventArgs)
		{
		}
	}
}