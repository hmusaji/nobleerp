using System;

namespace Xtreme
{
	internal partial class frmRETenantCharges
		: System.Windows.Forms.Form
	{

		public frmRETenantCharges()
{
InitializeComponent();
} 
 public  void frmRETenantCharges_old()
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


		private void frmRETenantCharges_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (UpgradeHelpers.Gui.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Gui.ActivateHelper.myActiveForm = (System.Windows.Forms.Form) eventSender;
			}
		}
		//Option Explicit
		//Public UserAccess As New clsAccessAllowed
		//Public FirstFocusObject As Control
		//Private mThisFormID As Long
		//
		//Private mFirstGridFocus As Boolean
		//Private aChargesDetails As New XArrayDB
		//
		//Private Const conLineNoColumn As Integer = 0
		//Private Const conItemNoColumn As Integer = 1
		//Private Const conItemNameColumn As Integer = 2
		//Private Const conUnitNoColumn As Integer = 3
		//Private Const conUnitAmountColumn As Integer = 4
		//Private Const conItemCodeColumn As Integer = 5
		//Private Const conUnitCodeColumn As Integer = 6
		//Private Const conRemarksColumn As Integer = 7
		//
		//Private Const mMaxArray As Integer = 7
		//
		//Private Const conTXTTenantNo As Integer = 0
		//Private Const conTXTTenantName As Integer = 0
		//
		//Public Property Get ThisFormId() As Long
		//    ThisFormId = mThisFormID
		//End Property
		//
		//Public Property Let ThisFormId(ByVal NewFormId As Long)
		//    mThisFormID = NewFormId
		//End Property
		//
		//Public Property Get CurrentFormMode() As SystemFormModes
		//    CurrentFormMode = mCurrentFormMode
		//End Property
		//
		//Public Property Let CurrentFormMode(ByVal vNewValue As SystemFormModes)
		//    mCurrentFormMode = vNewValue
		//End Property
		//
		//Private Sub Form_Activate()
		//On Error Resume Next
		//
		//Call CheckPostedStatus(1, "GLStatus", IIf(mOldVoucherStatus = stActive, False, True), CurrentFormMode, 3)
		//End Sub
		//
		//Private Sub Form_Deactivate()
		//Call CheckPostedStatus(0, "GLStatus")
		//End Sub
		//
		//Private Sub Form_Load()
		//Dim colContractDetails As TrueOleDBGrid80.Column
		//
		//On Error GoTo eFoundError
		//
		//Set FirstFocusObject = txtCommon(conTXTTenantNo)
		//Me.CurrentFormMode = frmAddMode
		//mOldVoucherStatus = stActive
		//Me.Top = 0
		//Me.Left = 0
		//mFirstGridFocus = True
		//
		//Call DrawToolbar(Me, picFormToolbar, btnFormToolBar(0))
		//Set btnFormToolBar(0).Picture = frmSysMain.imlMainToolBar.ListImages("imgNew").Picture
		//Set btnFormToolBar(1).Picture = frmSysMain.imlMainToolBar.ListImages("imgSave").Picture
		//Set btnFormToolBar(2).Picture = frmSysMain.imlMainToolBar.ListImages("imgDelete").Picture
		//Set btnFormToolBar(3).Picture = frmSysMain.imlMainToolBar.ListImages("imgPrint").Picture
		//Set btnFormToolBar(4).Picture = frmSysMain.imlMainToolBar.ListImages("imgFind").Picture
		//Set btnFormToolBar(5).Picture = frmSysMain.imlSystemIcons.ListImages("imgPostingTransactions").Picture
		//Set btnFormToolBar(6).Picture = frmSysMain.imlMainToolBar.ListImages("imgInsertLine").Picture
		//Set btnFormToolBar(7).Picture = frmSysMain.imlMainToolBar.ListImages("imgHelp").Picture
		//Set btnFormToolBar(8).Picture = frmSysMain.imlMainToolBar.ListImages("imgExit").Picture
		//Set btnFormToolBar(9).Picture = frmSysMain.imlMainToolBar.ListImages("imgDeleteLine").Picture
		//
		//
		//Call DefineSystemVoucherGrid(grdContractDetails, , , , , , , True, , , , "&HABCED3", "&HABCED3")
		//'**--define voucher grid columns
		//Call DefineSystemVoucherGridColumn(grdContractDetails, "LN", 400, False, gDisableColumnBackColor, , , False)
		//Call DefineSystemVoucherGridColumn(grdContractDetails, "Item Code", 1000, , , , dbgLeft, False, , , True, , , "cmbCommon", True)
		//Call DefineSystemVoucherGridColumn(grdContractDetails, "Item Name", 2500, False, gDisableColumnBackColor, , , False, "Total Contract Amount", dbgCenter)
		//Call DefineSystemVoucherGridColumn(grdContractDetails, "Unit Code", 1000, , , , dbgLeft, True, , , True, , , "cmbCommon", True)
		//Call DefineSystemVoucherGridColumn(grdContractDetails, "Unit Amount", 1200, True, , , dbgRight, True, , dbgRight, , , , , , , , True, , True)
		//Call DefineSystemVoucherGridColumn(grdContractDetails, "Item Code", 500, True, , , , False, , , , , , , , False)
		//Call DefineSystemVoucherGridColumn(grdContractDetails, "Unit Code", 500, True, , , , False, , , , , , , , False)
		//Call DefineSystemVoucherGridColumn(grdContractDetails, "Remarks")
		//
		//'**--setting up default values
		//Call ShowHideMasterDetails
		//
		//'**--make the form visible before all the control gets loaded
		//'**--(this way system pretends to be faster in loading forms)
		//Me.Show
		//DoEvents
		//
		//'**--setting voucher details grid properties
		//Set rsItemList = New ADODB.Recordset
		//Set rsUnitList = New ADODB.Recordset
		//
		//aChargesDetails.ReDim 0, 0, 0, mMaxArray
		//aChargesDetails(0, conLineNoColumn) = 1
		//Call DefineSystemGridCombo(cmbCommon)
		//Set grdContractDetails.Array = aChargesDetails
		//cmbCommon.Height = 1800
		//grdContractDetails.ReBind
		//'**--end of voucher grid property setting
		//
		//DoEvents
		//Call CalculateContractAmount
		//Exit Sub
		//
		//eFoundError:
		//Call ErrorHandlingRoutine(Err.Number, Err.Description, Me.Name, "Form Load")
		//Unload Me
		//End Sub
		//
		//Private Sub Form_KeyDown(KeyCode As Integer, Shift As Integer)
		//If KeyCode = 13 Then
		//    SendKeys "{TAB}"
		//    Exit Sub
		//ElseIf KeyCode = 116 Then
		//    Call RefreshFormObjects
		//    Exit Sub
		//End If
		//
		//If Me.ActiveControl.Name <> "txtCommon" Then
		//    Call SystemFormKeyDown(Me, KeyCode, Shift, Me.ActiveControl.Name)
		//Else
		//    Call SystemFormKeyDown(Me, KeyCode, Shift, "txtCommon#" + Trim(Me.ActiveControl.Index))
		//End If
		//End Sub
		//
		//Private Sub DefineMasterRecordset()
		//Dim mySql As String
		//
		//mySql = "select item_no, "
		//mySql = mySql & IIf(gPreferedLanguage = English, "l_item_name", "a_item_name") & " as item_name "
		//mySql = mySql & ", item_cd from re_property_items "
		//mySql = mySql & " where show = 1 "
		//
		//If rsItemList.State = adStateOpen Then
		//    rsItemList.Close
		//End If
		//rsItemList.CursorLocation = adUseClient
		//rsItemList.Open mySql, gConn, adOpenForwardOnly, adLockReadOnly
		//
		//mySql = "select unit_no, "
		//mySql = mySql & " iud.unit_amt, iud.unit_cd, iud.item_cd ,"
		//mySql = mySql & IIf(gPreferedLanguage = English, "p.l_property_name", "p.a_property_name") & " as property_name"
		//mySql = mySql & " , iud.property_cd "
		//mySql = mySql & " from re_property_item_unit_details iud "
		//mySql = mySql & " inner join re_property p on iud.property_cd = p.property_cd "
		//mySql = mySql & " inner join re_property_status ps on iud.property_status_cd = ps.property_status_cd "
		//If CurrentFormMode = frmEditMode Then
		//    mySql = mySql & " where (ps.is_available = 1 "
		//    mySql = mySql & " or iud.contract_cd = " & mSearchValue & ")"
		//Else
		//    mySql = mySql & " where ps.is_available = 1 "
		//End If
		//
		//If rsUnitList.State = adStateOpen Then
		//    rsUnitList.Close
		//End If
		//rsUnitList.CursorLocation = adUseClient
		//rsUnitList.Open mySql, gConn, adOpenForwardOnly, adLockReadOnly
		//End Sub
		//
		//Private Sub grdContractDetails_AfterColUpdate(ByVal ColIndex As Integer)
		//If ColIndex = conUnitAmountColumn Or ColIndex = conUnitNoColumn Then
		//    Call CalculateContractAmount
		//End If
		//End Sub
		//
		//Private Sub grdContractDetails_FormatText(ByVal ColIndex As Integer, Value As Variant, Bookmark As Variant)
		//On Error Resume Next
		//
		//If ColIndex = conUnitAmountColumn Then
		//    Value = Format(Val(Value), "###,###,###,##0.000")
		//End If
		//End Sub
		//
		//Private Sub grdContractDetails_GotFocus()
		//If mFirstGridFocus = True Then
		//    Call DefineMasterRecordset
		//    mFirstGridFocus = False
		//
		//    grdContractDetails.PostMsg 1
		//Else
		//End If
		//End Sub
		//
		//Private Sub grdContractDetails_OnAddNew()
		//grdContractDetails.Columns(conLineNoColumn).Text = grdContractDetails.ApproxCount + 1
		//End Sub
		//
		//Public Function saveRecord(Optional ByVal pPostGl As Boolean = False) As Boolean
		//Dim mySql As String
		//Dim Cnt As Integer
		//Dim mGeneratedEntryID As Long
		//Dim mTempValue As Variant
		//'Dim mPropertyCode As Variant
		//
		//On Error GoTo eFoundError
		//
		//'**--update grid array with current grid values
		//grdContractDetails.Update
		//
		//''**--save the item unit property information in the master table
		//''**--it is assumed that all the item unit shall belong to the same property
		//''**--hence the first item unit's property code is being saved to the
		//''**--contract master table
		//'mySql = "select property_cd from re_property_item_unit_details "
		//'mySql = mySql & " where unit_cd = " & aChargesDetails(0, conUnitCodeColumn)
		//'mPropertyCode = GetMasterCode(mySql)
		//'If IsItEmpty(mPropertyCode, NumberType) Then
		//'    saveRecord = False
		//'    MsgBox "Error: Invalid Contract Details", vbInformation
		//'    grdContractDetails.SetFocus
		//'    Exit Function
		//'End If
		//
		//gConn.BeginTrans
		//'**--inserting details in contract master table
		//If mCurrentFormMode = frmAddMode Then
		//    txtCommon(conTXTContractNo).Text = GetNewNumber("re_contract", "contract_no", 4)
		//
		//    mySql = " insert into re_contract "
		//    mySql = mySql & " (contract_no, property_cd, tenant_cd, contract_status_cd, payment_method_cd"
		//    mySql = mySql & ", starting_date, ending_date, signed_date, contract_amt"
		//    mySql = mySql & ", reference_no, comments, user_cd) "
		//    mySql = mySql & " values( "
		//    mySql = mySql & txtCommon(conTXTContractNo).Text
		//    mySql = mySql & ", " & txtCommon(conTXTPropertyNo).Tag
		//    mySql = mySql & ", " & txtCommon(conTXTTenantNo).Tag
		//    '**--insert the default status code to 1 = active
		//    mySql = mySql & ", 1"
		//    mySql = mySql & ", " & txtCommon(conTXTPaymentMethodNo).Tag
		//    mySql = mySql & ", '" & txtCommonDate(conTXTStartingDate).DisplayText & "'"
		//    mySql = mySql & ", '" & txtCommonDate(conTXTEndingDate).DisplayText & "'"
		//    mySql = mySql & ", '" & txtCommonDate(conTXTSignedDate).DisplayText & "'"
		//    mySql = mySql & ", " & Format(grdContractDetails.Columns(conUnitAmountColumn).FooterText, "###############.####")
		//    mySql = mySql & ", N'" & txtCommon(conTXTReferenceNo).Text & "'"
		//    mySql = mySql & ", N'" & txtRemarks.Text & "'"
		//    mySql = mySql & ", " & gLoggedInUserCode
		//    mySql = mySql & " )"
		//    gConn.Execute (mySql)
		//
		//    mGeneratedEntryID = GetMasterCode("select scope_identity()")
		//ElseIf mCurrentFormMode = frmEditMode Then
		//    '*--updating main transaction table
		//    '*-- check whether the row is in the same status when it was retreived from the table for updation
		//    Dim rsCheckTimeStamp As Recordset
		//    Dim mCheckTimeStamp As String
		//
		//    Set rsCheckTimeStamp = gConn.Execute("select time_stamp from re_contract where contract_cd = " & Str(mSearchValue))
		//    If Not rsCheckTimeStamp.EOF Then
		//        mCheckTimeStamp = rsCheckTimeStamp(0)
		//    End If
		//    If (rsCheckTimeStamp.EOF) Or (tsFormat(mTimeStamp) <> tsFormat(mCheckTimeStamp)) Then
		//        rsCheckTimeStamp.Close
		//        Set rsCheckTimeStamp = Nothing
		//        gConn.RollbackTrans
		//        saveRecord = False
		//        MsgBox msg10, vbInformation
		//        FirstFocusObject.SetFocus
		//        Exit Function
		//    End If
		//    rsCheckTimeStamp.Close
		//    Set rsCheckTimeStamp = Nothing
		//    '**-------------------------------------------------------------------------------
		//
		//    mySql = "update re_contract "
		//    mySql = mySql & " set property_cd = " & txtCommon(conTXTPropertyNo).Tag
		//    mySql = mySql & " , tenant_cd = " & txtCommon(conTXTTenantNo).Tag
		//    mySql = mySql & " , payment_method_cd = " & txtCommon(conTXTPaymentMethodNo).Tag
		//    mySql = mySql & " , starting_date = '" & txtCommonDate(conTXTStartingDate).DisplayText & "'"
		//    mySql = mySql & " , ending_date = '" & txtCommonDate(conTXTEndingDate).DisplayText & "'"
		//    mySql = mySql & " , signed_date = '" & txtCommonDate(conTXTSignedDate).DisplayText & "'"
		//    mySql = mySql & " , contract_amt = " & Format(grdContractDetails.Columns(conUnitAmountColumn).FooterText, "###############.####")
		//    mySql = mySql & " , reference_no = N'" & txtCommon(conTXTReferenceNo).Text & "'"
		//    mySql = mySql & " , comments = N'" & txtRemarks.Text & "'"
		//    mySql = mySql & " where contract_cd = " & mSearchValue
		//    gConn.Execute (mySql)
		//
		//    mGeneratedEntryID = mSearchValue
		//End If
		//'**-------------------------------------------------------------------------------------------
		//
		//'**--inserting details in contract details table
		//If CurrentFormMode = frmEditMode Then
		//    mySql = "delete from re_contract_details "
		//    mySql = mySql & " where contract_cd = " & mGeneratedEntryID
		//    gConn.Execute (mySql)
		//
		//    mySql = "update re_property_item_unit_details "
		//    mySql = mySql & " set property_status_cd = 1 "
		//    mySql = mySql & " , contract_cd = null "
		//    mySql = mySql & " where contract_cd = " & mGeneratedEntryID
		//    gConn.Execute (mySql)
		//End If
		//
		//For Cnt = 0 To aChargesDetails.Count(1) - 1
		//    mySql = "select count(*) from re_property_item_unit_details iud "
		//    mySql = mySql & " inner join re_property_status ps "
		//    mySql = mySql & " on iud.property_status_cd = ps.property_status_cd "
		//    mySql = mySql & " where unit_cd = " & aChargesDetails(Cnt, conUnitCodeColumn)
		//    mySql = mySql & " and is_available = 1 "
		//    mTempValue = GetMasterCode(mySql)
		//    If mTempValue = 0 Then
		//        gConn.RollbackTrans
		//        MsgBox "Error: Item Unit Unavailable", vbInformation
		//        saveRecord = False
		//        Exit Function
		//    End If
		//
		//    mySql = "insert into re_contract_details "
		//    mySql = mySql & " (contract_cd, item_cd, unit_cd, amount, remarks) "
		//    mySql = mySql & " values ("
		//    mySql = mySql & mGeneratedEntryID
		//    mySql = mySql & "," & aChargesDetails(Cnt, conItemCodeColumn)
		//    mySql = mySql & "," & aChargesDetails(Cnt, conUnitCodeColumn)
		//    mySql = mySql & "," & aChargesDetails(Cnt, conUnitAmountColumn)
		//    mySql = mySql & ", N'" & aChargesDetails(Cnt, conRemarksColumn) & "'"
		//    mySql = mySql & ")"
		//    gConn.Execute (mySql)
		//
		//    mySql = " update re_property_item_unit_details "
		//    mySql = mySql & " set property_status_cd = 2 "
		//    mySql = mySql & ", contract_cd = " & mGeneratedEntryID
		//    mySql = mySql & " where unit_cd = " & aChargesDetails(Cnt, conUnitCodeColumn)
		//    gConn.Execute (mySql)
		//Next
		//'**-------------------------------------------------------------------------------------------
		//'**--check if all the items in the contract belongs to the same property or not
		//mySql = " select count(*) from "
		//mySql = mySql & "(select distinct piud.property_cd "
		//mySql = mySql & " from re_contract_details cd "
		//mySql = mySql & " inner join re_property_item_unit_details piud "
		//mySql = mySql & " on piud.item_cd = cd.item_cd and piud.unit_cd = cd.unit_cd "
		//mySql = mySql & " where cd.contract_cd = " & Str(mGeneratedEntryID)
		//mySql = mySql & ") as rs "
		//If GetMasterCode(mySql) > 1 Then
		//    gConn.RollbackTrans
		//    MsgBox "Error: All Contract Item Units shall belong to one Property only", vbInformation
		//    grdContractDetails.SetFocus
		//    saveRecord = False
		//    Exit Function
		//End If
		//'**-------------------------------------------------------------------------------------------
		//gConn.CommitTrans
		//saveRecord = True
		//If CurrentFormMode = frmAddMode Then
		//    MsgBox "Contract has been saved with no : " & txtCommon(conTXTContractNo).Text, vbInformation, "Press Enter To Continue..."
		//End If
		//Exit Function
		//
		//
		//eFoundError:
		//gConn.RollbackTrans
		//saveRecord = False
		//End Function
		//
		//Public Sub AddRecord()
		//'**--add a record
		//On Error GoTo eFoundError
		//
		//mCurrentFormMode = frmAddMode
		//mFirstGridFocus = True
		//mOldVoucherStatus = stActive
		//Call ClearTextBox(Me)
		//
		//aChargesDetails.Clear
		//aChargesDetails.ReDim 0, 0, 0, mMaxArray
		//aChargesDetails(0, conLineNoColumn) = 1
		//grdContractDetails.ReBind
		//
		//Call RefreshFormObjects
		//Call ShowHideMasterDetails
		//Call CheckPostedStatus(1, "GLStatus", IIf(mOldVoucherStatus = stActive, False, True), CurrentFormMode, 3)
		//FirstFocusObject.SetFocus
		//Exit Sub
		//
		//eFoundError:
		//Call ErrorHandlingRoutine(Err.Number, Err.Description, Me.Name, "AddRecord")
		//End Sub
		//
		//Public Function deleteRecord() As Boolean
		//Dim mySql As String
		//
		//On Error GoTo eFoundError
		//
		//If mOldVoucherStatus <> stActive Then
		//    MsgBox "Error: Contract already posted. Can not delete / modify the posted transaction!", vbCritical
		//    FirstFocusObject.SetFocus
		//    deleteRecord = False
		//    Exit Function
		//End If
		//
		//gConn.BeginTrans
		//
		//mySql = "delete from re_contract_details "
		//mySql = mySql & " from re_contract_details cd "
		//mySql = mySql & " inner join re_contract c on c.contract_cd = cd.contract_cd "
		//mySql = mySql & " where cd.contract_cd = " & mSearchValue
		//mySql = mySql & " and c.status = 1 "
		//gConn.Execute mySql
		//If Err.Number <> 0 Then
		//    GoTo eFoundError
		//End If
		//
		//mySql = "update re_property_item_unit_details "
		//mySql = mySql & " set property_status_cd = 1 "
		//mySql = mySql & " , contract_cd = null "
		//mySql = mySql & " where contract_cd = " & mSearchValue
		//gConn.Execute (mySql)
		//If Err.Number <> 0 Then
		//    GoTo eFoundError
		//End If
		//
		//
		//mySql = "delete from re_contract "
		//mySql = mySql & " where contract_cd = " & mSearchValue
		//mySql = mySql & " and status = 1 "
		//gConn.Execute mySql
		//If Err.Number <> 0 Then
		//    GoTo eFoundError
		//End If
		//
		//gConn.CommitTrans
		//deleteRecord = True
		//Exit Function
		//
		//eFoundError:
		//MsgBox "Item cannot be deleted, contract already posted!", vbCritical
		//gConn.RollbackTrans
		//deleteRecord = False
		//End Function
		//
		//Public Sub GetRecord(pSearchvalue As Variant)
		//'This routine is called after getting the value from Find window or
		//'refreshing the recordset during any error of updating or deleting
		//Dim mySql As String
		//Dim rsLocalRec As ADODB.Recordset
		//
		//On Error GoTo eFoundError
		//
		//If IsItEmpty(pSearchvalue, StringType) Then
		//    Exit Sub
		//End If
		//'**--change the form mode to edit
		//mCurrentFormMode = frmEditMode
		//mFirstGridFocus = True
		//Call ShowHideMasterDetails
		//
		//mySql = "select c.contract_no, c.time_stamp "
		//mySql = mySql & ", t.tenant_cd, t.tenant_no, t.l_tenant_name, t.a_tenant_name "
		//mySql = mySql & ", cs.contract_status_cd, cs.status_no, cs.l_status_name, cs.a_status_name"
		//mySql = mySql & ", p.property_cd, p.property_no, p.l_property_name, p.a_property_name "
		//mySql = mySql & ", pm.payment_method_cd, pm.payment_method_no, pm.l_payment_method_name "
		//mySql = mySql & ", pm.a_payment_method_name, c.status "
		//mySql = mySql & ", c.starting_date, c.ending_date, c.signed_date"
		//mySql = mySql & ", c.contract_amt, c.other_amt, c.total_amt, c.comments, c.reference_no"
		//mySql = mySql & " from re_contract c "
		//mySql = mySql & " inner join re_tenant t on c.tenant_cd = t.tenant_cd"
		//mySql = mySql & " inner join re_contract_status cs on c.contract_status_cd = cs.contract_status_cd"
		//mySql = mySql & " inner join re_payment_method pm on c.payment_method_cd = pm.payment_method_cd"
		//mySql = mySql & " inner join re_property p on c.property_cd = p.property_cd"
		//mySql = mySql & " where contract_cd = " & pSearchvalue
		//
		//Set rsLocalRec = New ADODB.Recordset
		//rsLocalRec.Open mySql, gConn, adOpenForwardOnly, adLockReadOnly
		//With rsLocalRec
		//    If Not .EOF Then
		//        mTimeStamp = .Fields("time_stamp").Value
		//        mOldVoucherStatus = .Fields("status").Value
		//        txtCommon(conTXTContractNo).Text = .Fields("contract_no").Value
		//        txtCommon(conTXTTenantNo).Text = .Fields("tenant_no").Value
		//        txtCommon(conTXTTenantNo).Tag = .Fields("tenant_cd").Value
		//        txtCommon(conTXTStatusNo).Text = .Fields("status_no").Value
		//        txtCommon(conTXTPaymentMethodNo).Text = .Fields("payment_method_no").Value
		//        txtCommon(conTXTPaymentMethodNo).Tag = .Fields("payment_method_cd").Value
		//        txtCommon(conTXTPropertyNo).Text = .Fields("property_no").Value
		//        txtCommon(conTXTPropertyNo).Tag = .Fields("property_cd").Value
		//        txtCommon(conTXTReferenceNo).Text = .Fields("reference_no").Value & ""
		//        txtCommonDate(conTXTStartingDate).Value = .Fields("starting_date").Value
		//        txtCommonDate(conTXTEndingDate).Value = .Fields("ending_date").Value
		//        txtCommonDate(conTXTSignedDate).Value = .Fields("signed_date").Value
		//        txtRemarks.Text = .Fields("comments").Value & ""
		//        If gPreferedLanguage = English Then
		//            txtCommonDisplay(conTXTTenantName).Text = .Fields("l_tenant_name").Value & ""
		//            txtCommonDisplay(conTXTStatusName).Text = .Fields("l_status_name").Value & ""
		//            txtCommonDisplay(conTXTPaymentMethodName).Text = .Fields("l_payment_method_name").Value & ""
		//            txtCommonDisplay(conTXTPropertyName).Text = .Fields("l_property_name").Value & ""
		//        Else
		//            txtCommonDisplay(conTXTTenantName).Text = .Fields("a_tenant_name").Value & ""
		//            txtCommonDisplay(conTXTStatusName).Text = .Fields("a_status_name").Value & ""
		//            txtCommonDisplay(conTXTPaymentMethodName).Text = .Fields("a_payment_method_name").Value & ""
		//            txtCommonDisplay(conTXTPropertyName).Text = .Fields("a_property_name").Value & ""
		//        End If
		//
		//        Call CheckPostedStatus(1, "GLStatus", IIf(mOldVoucherStatus = stActive, False, True), CurrentFormMode, 3)
		//    End If
		//End With
		//rsLocalRec.Close
		//Set rsLocalRec = Nothing
		//
		//Call InsertContractDetails(pSearchvalue)
		//Call CalculateContractAmount
		//Exit Sub
		//
		//eFoundError:
		//Call ErrorHandlingRoutine(Err.Number, Err.Description, Me.Name, "GetRecord")
		//End Sub
		//
		//Public Sub findRecord()
		//'Call the find window
		//Dim mTempSearchValue As Variant
		//
		//mTempSearchValue = FindItem(9015000)
		//If Not IsNull(mTempSearchValue) Then
		//    mSearchValue = mTempSearchValue(0)
		//    DoEvents
		//    Call GetRecord(mSearchValue)
		//End If
		//End Sub
		//
		//Public Sub CloseForm()
		//Unload Me
		//End Sub
		//
		//Public Function CheckDataValidity() As Boolean
		//Dim Cnt As Integer
		//Dim mySql As String
		//Dim mReturnValue As Variant
		//
		//On Error GoTo eFoundError
		//
		//Call txtCommon_LostFocus(conTXTTenantNo)
		//Call txtCommon_LostFocus(conTXTPaymentMethodNo)
		//Call txtCommon_LostFocus(conTXTPropertyNo)
		//
		//If mOldVoucherStatus <> stActive Then
		//    MsgBox "Error: Contract already posted. Can not modify the posted transaction!", vbCritical
		//    FirstFocusObject.SetFocus
		//    CheckDataValidity = False
		//    Exit Function
		//End If
		//
		//If IsItEmpty(txtCommon(conTXTTenantNo).Text, NumberType) Then
		//    MsgBox "Enter Tenant Code", vbInformation
		//    txtCommon(conTXTTenantNo).SetFocus
		//    CheckDataValidity = False
		//    Exit Function
		//End If
		//
		//If IsItEmpty(txtCommon(conTXTPaymentMethodNo).Text, NumberType) Then
		//    MsgBox "Enter Payment Method Code", vbInformation
		//    txtCommon(conTXTPaymentMethodNo).SetFocus
		//    CheckDataValidity = False
		//    Exit Function
		//End If
		//
		//If IsItEmpty(txtCommon(conTXTPropertyNo).Text, NumberType) Then
		//    MsgBox "Enter Property Code", vbInformation
		//    txtCommon(conTXTPropertyNo).SetFocus
		//    CheckDataValidity = False
		//    Exit Function
		//End If
		//
		//If IsItEmpty(txtCommonDate(conTXTStartingDate).Text, DateType) Then
		//    MsgBox "Enter Starting Date", vbInformation
		//    txtCommonDate(conTXTStartingDate).SetFocus
		//    CheckDataValidity = False
		//    Exit Function
		//End If
		//If IsItEmpty(txtCommonDate(conTXTEndingDate).Text, DateType) Then
		//    MsgBox "Enter Ending Date", vbInformation
		//    txtCommonDate(conTXTEndingDate).SetFocus
		//    CheckDataValidity = False
		//    Exit Function
		//End If
		//If IsItEmpty(txtCommonDate(conTXTSignedDate).Text, DateType) Then
		//    MsgBox "Enter Signed Date", vbInformation
		//    txtCommonDate(conTXTSignedDate).SetFocus
		//    CheckDataValidity = False
		//    Exit Function
		//End If
		//
		//'**--check the contract details entries
		//If aChargesDetails.Count(1) = 0 Then
		//    MsgBox "Error: Enter Contract Details", vbInformation
		//    grdContractDetails.SetFocus
		//    CheckDataValidity = False
		//    Exit Function
		//End If
		//
		//For Cnt = 0 To aChargesDetails.Count(1) - 1
		//    If Not IsItEmpty(aChargesDetails(Cnt, conItemNoColumn), NumberType) Then
		//        mySql = " select item_cd "
		//        mySql = mySql & " from re_property_items "
		//        mySql = mySql & " where item_no = " & aChargesDetails(Cnt, conItemNoColumn)
		//        mySql = mySql & " and show = 1 "
		//        mReturnValue = GetMasterCode(mySql)
		//        If IsNull(mReturnValue) Then
		//            MsgBox "Error: Invalid Item Code", vbInformation
		//            grdContractDetails.Row = Cnt
		//            grdContractDetails.SetFocus
		//            CheckDataValidity = False
		//            Exit Function
		//        Else
		//            aChargesDetails(Cnt, conItemCodeColumn) = mReturnValue
		//        End If
		//    Else
		//        MsgBox "Error: Enter Item Code", vbInformation
		//        grdContractDetails.Row = Cnt
		//        grdContractDetails.SetFocus
		//        CheckDataValidity = False
		//        Exit Function
		//    End If
		//
		//    If Not IsItEmpty(aChargesDetails(Cnt, conUnitNoColumn), StringType) Then
		//        mySql = " select unit_cd "
		//        mySql = mySql & " from re_property_item_unit_details "
		//        mySql = mySql & " where unit_no = '" & Trim(aChargesDetails(Cnt, conUnitNoColumn)) & "'"
		//        mySql = mySql & " and item_cd = " & Trim(aChargesDetails(Cnt, conItemCodeColumn))
		//        mySql = mySql & " and property_cd = " & Trim(txtCommon(conTXTPropertyNo).Tag)
		//
		//'        If mCurrentFormMode = frmAddMode Then
		//'            mySql = mySql & " and property_status_cd = 1 "
		//'        Else
		//'            mySql = mySql & " and contract_cd = " & mSearchValue
		//'        End If
		//        mReturnValue = GetMasterCode(mySql)
		//        If IsNull(mReturnValue) Then
		//            MsgBox "Error: Invalid Item Unit Code", vbInformation
		//            grdContractDetails.Row = Cnt
		//            grdContractDetails.SetFocus
		//            CheckDataValidity = False
		//            Exit Function
		//        Else
		//            aChargesDetails(Cnt, conUnitCodeColumn) = mReturnValue
		//        End If
		//    Else
		//        MsgBox "Error: Enter Item Unit Code", vbInformation
		//        grdContractDetails.Row = Cnt
		//        grdContractDetails.SetFocus
		//        CheckDataValidity = False
		//        Exit Function
		//    End If
		//
		//    If IsItEmpty(aChargesDetails(Cnt, conUnitAmountColumn), NumberType) Then
		//        MsgBox "Error: Enter Unit Amount", vbInformation
		//        grdContractDetails.Row = Cnt
		//        grdContractDetails.SetFocus
		//        CheckDataValidity = False
		//        Exit Function
		//    End If
		//Next
		//CheckDataValidity = True
		//Exit Function
		//
		//eFoundError:
		//CheckDataValidity = False
		//End Function
		//
		//Private Sub Form_Unload(Cancel As Integer)
		//On Error Resume Next
		//
		//Call RemoveMeFromWindowList(Str(Me.hWnd))
		//Call CheckPostedStatus(0, "GLStatus")
		//
		//Set rsItemList = Nothing
		//Set rsUnitList = Nothing
		//Set aChargesDetails = Nothing
		//Set UserAccess = Nothing
		//Set frmRETenantCharges = Nothing
		//End Sub
		//
		//Sub FindRoutine(pObjectName As String)
		//Dim mObjectName As String
		//Dim mObjectIndex As Integer
		//Dim mTempSearchValue As Variant
		//Dim mFilterCondition As String
		//
		//If InStr(1, pObjectName, "#", vbTextCompare) = 0 Then
		//    Exit Sub
		//End If
		//
		//mObjectName = Left(pObjectName, InStr(1, pObjectName, "#", vbTextCompare) - 1)
		//mObjectIndex = CInt(Mid(pObjectName, InStr(1, pObjectName, "#", vbTextCompare) + 1))
		//If mObjectName = "txtCommon" Then
		//    txtCommon(mObjectIndex).Text = ""
		//    Select Case mObjectIndex
		//        Case conTXTTenantNo
		//            mTempSearchValue = FindItem(9010000, 1365)
		//        Case conTXTStatusNo
		//            mTempSearchValue = FindItem(9013000, 1383)
		//        Case conTXTPaymentMethodNo
		//            mTempSearchValue = FindItem(9014000, 1387)
		//        Case conTXTPropertyNo
		//            mTempSearchValue = FindItem(9001000, 1323)
		//        Case Else
		//            Exit Sub
		//    End Select
		//
		//    If Not IsNull(mTempSearchValue) Then
		//        txtCommon(mObjectIndex).Text = mTempSearchValue(1)
		//        Call txtCommon_LostFocus(mObjectIndex)
		//    End If
		//End If
		//
		//End Sub
		//
		//Private Sub grdContractDetails_RowColChange(LastRow As Variant, ByVal LastCol As Integer)
		//grdContractDetails.Update
		//rsUnitList.Filter = adFilterNone
		//
		//With cmbCommon
		//    Select Case grdContractDetails.Col
		//        Case conItemNoColumn
		//            .DataSource = rsItemList
		//        Case conUnitNoColumn
		//            If Not IsNull(grdContractDetails.Bookmark) Then
		//                If Not IsItEmpty(aChargesDetails(Val(grdContractDetails.Bookmark), conItemCodeColumn), StringType) Then
		//                    rsUnitList.Filter = " property_cd = " & txtCommon(conTXTPropertyNo).Tag & " and item_cd = " & aChargesDetails(Val(grdContractDetails.Bookmark), conItemCodeColumn)
		//                End If
		//            End If
		//            .DataSource = rsUnitList
		//        Case Else
		//            Exit Sub
		//    End Select
		//End With
		//End Sub
		//
		//Private Sub txtCommon_LostFocus(Index As Integer)
		//Dim mTempValue As Variant
		//Dim mySql As String
		//Dim mLinkedTextBoxIndex As Integer
		//
		//On Error GoTo eFoundError
		//Select Case Index
		//    Case conTXTTenantNo
		//        mySql = "select l_tenant_name, a_tenant_name, tenant_cd from re_tenant where tenant_no = " & txtCommon(Index).Text
		//        mLinkedTextBoxIndex = conTXTTenantName
		//    Case conTXTStatusNo
		//        mySql = "select l_status_name, a_status_name, contract_status_cd from re_contract_status where status_no = " & txtCommon(Index).Text
		//        mLinkedTextBoxIndex = conTXTStatusName
		//    Case conTXTPaymentMethodNo
		//        mySql = "select l_payment_method_name, a_payment_method_name, payment_method_cd from re_payment_method where payment_method_no = " & txtCommon(Index).Text
		//        mLinkedTextBoxIndex = conTXTPaymentMethodName
		//    Case conTXTPropertyNo
		//        mySql = "select l_property_name, a_property_name, property_cd from re_property where property_no = " & txtCommon(Index).Text
		//        mLinkedTextBoxIndex = conTXTPropertyName
		//    Case Else
		//        Exit Sub
		//End Select
		//
		//If Not IsItEmpty(txtCommon(Index).Text, StringType) Then
		//    mTempValue = GetMasterCode(mySql)
		//    If IsNull(mTempValue) Then
		//        txtCommonDisplay(mLinkedTextBoxIndex).Text = ""
		//        txtCommon(Index).Tag = ""
		//        Err.Raise -9990002
		//    Else
		//        txtCommonDisplay(mLinkedTextBoxIndex).Text = IIf(gPreferedLanguage = English, mTempValue(0), mTempValue(1))
		//        txtCommon(Index).Tag = mTempValue(2)
		//    End If
		//Else
		//    txtCommonDisplay(mLinkedTextBoxIndex).Text = ""
		//    txtCommon(Index).Tag = ""
		//End If
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
		//    'if the code is not found
		//    On Error Resume Next
		//    txtCommon(Index).SetFocus
		//Else
		//    '
		//End If
		//End Sub
		//
		//Private Sub grdContractDetails_PostEvent(ByVal MsgId As Integer)
		//Dim Col As Integer
		//
		//If MsgId = 1 Then
		//    grdContractDetails.Col = conItemNoColumn
		//    Set cmbCommon.DataSource = rsItemList
		//ElseIf MsgId = 1001 Then
		//    grdContractDetails.Update
		//End If
		//End Sub
		//
		//Private Sub txtCommon_DropButtonClick(Index As Integer)
		//Call FindRoutine("txtCommon#" & Trim(Index))
		//End Sub
		//
		//Private Sub btnFormToolBar_AccessKeyPress(Index As Integer, KeyAscii As Integer)
		//Call btnFormToolBar_Click(Index)
		//End Sub
		//
		//Private Sub btnFormToolBar_Click(Index As Integer)
		//Call ToolBarButtonClick(Me, btnFormToolBar(Index).Tag)
		//End Sub
		//
		//Private Sub AssignGridLineNumbers()
		//Dim Cnt As Long
		//
		//For Cnt = 0 To aChargesDetails.Count(1) - 1
		//    aChargesDetails(Cnt, conLineNoColumn) = Cnt + 1
		//Next
		//End Sub
		//
		//Private Sub CalculateContractAmount()
		//Dim Cnt As Integer
		//Dim mContractAmount As Double
		//
		//grdContractDetails.Update
		//mContractAmount = 0
		//For Cnt = 0 To aChargesDetails.Count(1) - 1
		//    mContractAmount = mContractAmount + Val(aChargesDetails(Cnt, conUnitAmountColumn))
		//Next
		//grdContractDetails.Columns(conUnitAmountColumn).FooterText = Format(mContractAmount, "###,###,###,##0.000")
		//End Sub
		//
		//Private Sub cmbCommon_DataSourceChanged()
		//Dim Cnt As Long
		//
		//cmbCommon.Width = 0
		//Select Case grdContractDetails.Col
		//    Case conItemNoColumn
		//        cmbCommon.ListField = "item_no"
		//        rsItemList.Sort = "item_no"
		//        For Cnt = 0 To cmbCommon.Columns.Count - 1
		//            With cmbCommon.Columns(Cnt)
		//                If Cnt < 2 Then
		//                    If Cnt = 0 Then
		//                        .Order = IIf(grdContractDetails.Col = conItemNoColumn, 0, 1)
		//                        .Width = grdContractDetails.Columns(conItemNoColumn).Width
		//                    Else
		//                        .Order = IIf(grdContractDetails.Col = conItemNoColumn, 1, 0)
		//                        .Width = grdContractDetails.Columns(conItemNameColumn).Width
		//                    End If
		//
		//                    If gPreferedLanguage = English Then
		//                        .Alignment = dbgLeft
		//                    Else
		//                        .Alignment = dbgRight
		//                    End If
		//                    .Visible = True
		//                    cmbCommon.Width = cmbCommon.Width + .Width
		//                Else
		//                    .Visible = False
		//                End If
		//                .AllowSizing = False
		//            End With
		//        Next
		//    Case conUnitNoColumn
		//            cmbCommon.ListField = "unit_no"
		//            rsUnitList.Sort = "unit_no"
		//        For Cnt = 0 To cmbCommon.Columns.Count - 1
		//            With cmbCommon.Columns(Cnt)
		//                If Cnt < 2 Or Cnt = 4 Then
		//                    If Cnt = 0 Then
		//                        .Order = IIf(grdContractDetails.Col = conUnitNoColumn, 0, 1)
		//                        .Width = grdContractDetails.Columns(conUnitNoColumn).Width
		//                    Else
		//                        .Order = IIf(grdContractDetails.Col = conUnitNoColumn, 1, 0)
		//                        .Width = grdContractDetails.Columns(conUnitAmountColumn).Width + 600
		//                    End If
		//
		//                    If gPreferedLanguage = English Then
		//                        .Alignment = dbgLeft
		//                    Else
		//                        .Alignment = dbgRight
		//                    End If
		//                    .Visible = True
		//                    cmbCommon.Width = cmbCommon.Width + .Width
		//                Else
		//                    .Visible = False
		//                End If
		//                .AllowSizing = False
		//            End With
		//        Next
		//
		//        cmbCommon.Width = cmbCommon.Width + 250
		//        cmbCommon.Height = 2500
		//End Select
		//End Sub
		//
		//Private Sub cmbCommon_DropDownClose()
		//grdContractDetails.Update
		//End Sub
		//
		//Private Sub cmbCommon_RowChange()
		//If grdContractDetails.Col = conItemNoColumn Then
		//    grdContractDetails.Columns(conItemNameColumn).Value = cmbCommon.Columns(1).Value
		//    grdContractDetails.Columns(conItemCodeColumn).Value = cmbCommon.Columns(2).Value
		//    grdContractDetails.Columns(conUnitNoColumn).Value = ""
		//    grdContractDetails.Columns(conUnitAmountColumn).Value = ""
		//ElseIf grdContractDetails.Col = conUnitNoColumn Then
		//    grdContractDetails.Columns(conUnitAmountColumn).Value = cmbCommon.Columns(1).Value
		//    grdContractDetails.Columns(conUnitCodeColumn).Value = cmbCommon.Columns(2).Value
		//End If
		//End Sub
		//
		//Private Sub ShowHideMasterDetails()
		//Dim ShowStatusSetting As Boolean
		//
		//If CurrentFormMode = frmAddMode Then
		//    '**--setup default display dates
		//    txtCommonDate(conTXTStartingDate).Value = Date
		//    txtCommonDate(conTXTEndingDate).Value = DateAdd("yyyy", 1, Date)
		//    txtCommonDate(conTXTSignedDate).Value = Date
		//
		//    '**--hide status in add mode
		//    ShowStatusSetting = False
		//Else
		//    '**--show status in edit mode
		//    ShowStatusSetting = True
		//End If
		//lblCommon(conLBLStatusNo).Visible = ShowStatusSetting
		//txtCommon(conTXTStatusNo).Visible = ShowStatusSetting
		//txtCommonDisplay(conTXTStatusName).Visible = ShowStatusSetting
		//End Sub
		//
		//Private Sub RefreshFormObjects()
		//If rsItemList.State = adStateOpen Then
		//    rsItemList.Requery
		//End If
		//If rsUnitList.State = adStateOpen Then
		//    rsUnitList.Requery
		//End If
		//End Sub
		//
		//Public Sub IRoutine()
		//If grdContractDetails.Enabled = True Then
		//    If ActiveControl.Name <> "grdContractDetails" Then
		//        grdContractDetails.SetFocus
		//    End If
		//    If Not IsNull(grdContractDetails.Bookmark) Then
		//        aChargesDetails.InsertRows (grdContractDetails.Bookmark)
		//        Call AssignGridLineNumbers
		//        grdContractDetails.ReBind
		//        grdContractDetails.SetFocus
		//        grdContractDetails.Refresh
		//    End If
		//End If
		//Call CalculateContractAmount
		//End Sub
		//
		//Public Sub LRoutine()
		//If ActiveControl.Name <> "grdContractDetails" Then
		//    grdContractDetails.SetFocus
		//End If
		//
		//If aChargesDetails.Count(1) > 0 Then
		//    grdContractDetails.Delete
		//    Call AssignGridLineNumbers
		//   ' grdContractDetails.ReBind
		//End If
		//Call CalculateContractAmount
		//End Sub
		//
		//Private Sub InsertContractDetails(SearchValue)
		//Dim Cnt As Integer
		//Dim mySql As String
		//Dim rsLocalRec As ADODB.Recordset
		//Dim mFirstDate As Date
		//
		//
		//aChargesDetails.ReDim 0, 0, 0, mMaxArray
		//Cnt = 0
		//
		//mySql = "select item_no,"
		//mySql = mySql & IIf(gPreferedLanguage = English, "l_item_name", "a_item_name") & " as item_name "
		//mySql = mySql & ", unit_no, cd.amount, cd.item_cd, cd.unit_cd, cd.remarks "
		//mySql = mySql & " from re_contract_details cd "
		//mySql = mySql & " inner join re_property_items pi on cd.item_cd = pi.item_cd "
		//mySql = mySql & " inner join re_property_item_unit_details iud on cd.unit_cd = iud.unit_cd "
		//mySql = mySql & " where cd.contract_Cd = " & SearchValue
		//
		//Set rsLocalRec = New Recordset
		//rsLocalRec.Open mySql, gConn, adOpenForwardOnly, adLockReadOnly
		//While Not rsLocalRec.EOF
		//    aChargesDetails.ReDim 0, Cnt, 0, mMaxArray
		//    aChargesDetails(Cnt, conItemNoColumn) = rsLocalRec("item_no").Value
		//    aChargesDetails(Cnt, conItemNameColumn) = rsLocalRec("item_name").Value & ""
		//    aChargesDetails(Cnt, conUnitNoColumn) = rsLocalRec("unit_no").Value
		//    aChargesDetails(Cnt, conUnitAmountColumn) = rsLocalRec("amount").Value
		//    aChargesDetails(Cnt, conItemCodeColumn) = rsLocalRec("item_cd").Value
		//    aChargesDetails(Cnt, conUnitCodeColumn) = rsLocalRec("unit_cd").Value
		//    aChargesDetails(Cnt, conRemarksColumn) = rsLocalRec("remarks").Value & ""
		//    Cnt = Cnt + 1
		//
		//    rsLocalRec.MoveNext
		//Wend
		//Call AssignGridLineNumbers
		//
		//grdContractDetails.Array = aChargesDetails
		//grdContractDetails.ReBind
		//grdContractDetails.Refresh
		//End Sub
		//
		//Public Function Post() As Boolean
		//Dim mTempValue As Variant
		//
		//Post = False
		//If CurrentFormMode = frmEditMode Then
		//    If mOldVoucherStatus = stActive Then
		//        If MsgBox("Are you sure you want to post this contract?", vbQuestion + vbYesNo) = vbYes Then
		//            mTempValue = GetRELastMonthEndDate()
		//            If IsItEmpty(mTempValue, DateType) Then
		//                MsgBox "Error: No Month End Generate History Found. Contact Your Systems Administrator", vbCritical
		//                Exit Function
		//            End If
		//
		//            Call PostREContractsStatus(CDate(mTempValue), CLng(mSearchValue))
		//            MsgBox "Contract Successfully Posted", vbInformation
		//            Call AddRecord
		//            Exit Function
		//        Else
		//            Exit Function
		//        End If
		//    Else
		//        MsgBox "Contract Already Posted", vbCritical
		//        Exit Function
		//    End If
		//End If
		//Post = True
		//End Function
		//
		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2080
		private void Form_Load()
		{

		}
		private void Form_Closed(Object eventSender, EventArgs eventArgs)
		{
		}
	}
}