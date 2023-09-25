using System;
using System.Windows.Forms;

namespace Xtreme
{
	internal partial class frmSysReportDesignUtility
		: System.Windows.Forms.Form
	{

		public frmSysReportDesignUtility()
{
InitializeComponent();
} 
 public  void frmSysReportDesignUtility_old()
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


		private void frmSysReportDesignUtility_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (UpgradeHelpers.Gui.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Gui.ActivateHelper.myActiveForm = (System.Windows.Forms.Form) eventSender;
			}
		}
		//Option Explicit
		//'Dim rsProductList As ADODB.Recordset
		//Dim mFirstGridFocus As Boolean
		//'Dim recHeader As ADODB.Recordset
		//Dim recDetail As ADODB.Recordset
		//Public UserAccess As New clsAccessAllowed
		//Dim mThisFormID As Long
		//Dim mHeaderLineNo As Double
		//Dim mDetailLineNo As Double
		//Dim aVoucherDetails As New XArrayDB
		//Dim mSearchValue As Variant
		//Const mLineNoColumn As Integer = 0
		//Public Property Get ThisFormId() As Long
		//    ThisFormId = mThisFormID
		//End Property
		//
		//Public Property Let ThisFormId(ByVal NewFormId As Long)
		//    mThisFormID = NewFormId
		//End Property
		//
		//Private Sub btnFormToolBar_Click(Index As Integer)
		//Call ToolBarButtonClick(Me, btnFormToolBar(Index).Tag)
		//End Sub
		//
		//Private Sub Form_Unload(Cancel As Integer)
		//On Error Resume Next
		//
		//Call RemoveMeFromWindowList(Str(Me.hWnd))
		//
		//Set UserAccess = Nothing
		//End Sub
		//
		//Private Sub Form_Load()
		//
		//Call DefineSystemVoucherGrid(grdVoucherDetails, True, True, True, , , , False, dbgHighlightRow, , , "&H91BCC6", , 260)
		//'define voucher grid columns
		//Call DefineSystemVoucherGridColumn(grdVoucherDetails, "Column Id", 800, True, , , , False, , , , , , , , , True)
		//Call DefineSystemVoucherGridColumn(grdVoucherDetails, "Report Id", 800, , , , , False)
		//Call DefineSystemVoucherGridColumn(grdVoucherDetails, "Column_No", 1000, , , , , False)
		//Call DefineSystemVoucherGridColumn(grdVoucherDetails, "Table_Id", 1500, , , , , False)
		//Call DefineSystemVoucherGridColumn(grdVoucherDetails, "Field_Id", 2000, , , , , False, , , , False, False, "cmbMastersList", , rsVoucherTypes("Show_Product_Name_In_Details"))
		//Call DefineSystemVoucherGridColumn(grdVoucherDetails, "Group_By_Field_Id", 2300, , , , , False, , , , False, False, "cmbMastersList", , rsVoucherTypes("Show_Product_Name_In_Details"))
		//Call DefineSystemVoucherGridColumn(grdVoucherDetails, "Linked_Parameter_Type", 2100, , , , , False, , , , False, False, "cmbMastersList", , rsVoucherTypes("Show_Product_Name_In_Details"))
		//Call DefineSystemVoucherGridColumn(grdVoucherDetails, "Linked_Parameter_Name", 2100, , , , , False, , , , False, False, "cmbMastersList", , rsVoucherTypes("Show_Product_Name_In_Details"))
		//Call DefineSystemVoucherGridColumn(grdVoucherDetails, "L_Field_Caption", 1500, , , , , False, , , , False, False, "cmbMastersList", , rsVoucherTypes("Show_Product_Name_In_Details"))
		//Call DefineSystemVoucherGridColumn(grdVoucherDetails, "Field_Type", 1000, , , , , False, , , , False, False, "cmbMastersList", , rsVoucherTypes("Show_Product_Name_In_Details"))
		//Call DefineSystemVoucherGridColumn(grdVoucherDetails, "Field_Language", 1300, , , , , False, , , , False, False, "cmbMastersList", , rsVoucherTypes("Show_Product_Name_In_Details"))
		//Call DefineSystemVoucherGridColumn(grdVoucherDetails, "Field_Alignment", 1300, , , , , False, , , , False, False, "cmbMastersList", , rsVoucherTypes("Show_Product_Name_In_Details"))
		//Call DefineSystemVoucherGridColumn(grdVoucherDetails, "Show_Title", 800, , , , , False, , , , False, False, "cmbMastersList", , rsVoucherTypes("Show_Product_Name_In_Details"))
		//Call DefineSystemVoucherGridColumn(grdVoucherDetails, "Show_Detail", 800, , , , , False, , , , False, False, "cmbMastersList", , rsVoucherTypes("Show_Product_Name_In_Details"))
		//Call DefineSystemVoucherGridColumn(grdVoucherDetails, "Enable_Sorting", 1400, , , , , False, , , , False, False, "cmbMastersList", , rsVoucherTypes("Show_Product_Name_In_Details"))
		//Call DefineSystemVoucherGridColumn(grdVoucherDetails, "Enable_Grand_Total", 1500, , , , , False, , , , False, False, "cmbMastersList", , rsVoucherTypes("Show_Product_Name_In_Details"))
		//Call DefineSystemVoucherGridColumn(grdVoucherDetails, "Filter_Condition", 1500, , , , , False, , , , False, False, "cmbMastersList", , rsVoucherTypes("Show_Product_Name_In_Details"))
		//Call DefineSystemVoucherGridColumn(grdVoucherDetails, "Apply_Format", 1000, , , , , False, , , , False, False, "cmbMastersList", , rsVoucherTypes("Show_Product_Name_In_Details"))
		//Call DefineSystemVoucherGridColumn(grdVoucherDetails, "Format_Text_Type", 2000, , , , , False, , , , False, False, "cmbMastersList", , rsVoucherTypes("Show_Product_Name_In_Details"))
		//Call DefineSystemVoucherGridColumn(grdVoucherDetails, "Column_Type", 1000, , , , , False, , , , False, False, "cmbMastersList", , rsVoucherTypes("Show_Product_Name_In_Details"))
		//Call DefineSystemVoucherGridColumn(grdVoucherDetails, "Formula_Columns_Definition", 2700, , , , , False, , , , False, False, "cmbMastersList", , rsVoucherTypes("Show_Product_Name_In_Details"))
		//Call DefineSystemVoucherGridColumn(grdVoucherDetails, "Formula_Columns_Calculation", 2700, , , , , False, , , , False, False, "cmbMastersList", , rsVoucherTypes("Show_Product_Name_In_Details"))
		//Call DefineSystemVoucherGridColumn(grdVoucherDetails, "Enable_Filter", 1200, , , , , False, , , , False, False, "cmbMastersList", , rsVoucherTypes("Show_Product_Name_In_Details"))
		//Call DefineSystemVoucherGridColumn(grdVoucherDetails, "Filter_List_Types", 2000, , , , , False, , , , False, False, "cmbMastersList", , rsVoucherTypes("Show_Product_Name_In_Details"))
		//Call DefineSystemVoucherGridColumn(grdVoucherDetails, "List_SQL_Type", 2000, , , , , False, , , , False, False, "cmbMastersList", , rsVoucherTypes("Show_Product_Name_In_Details"))
		//Call DefineSystemVoucherGridColumn(grdVoucherDetails, "Show", 1000, , , , , False, , , , False, False, "cmbMastersList", , rsVoucherTypes("Show_Product_Name_In_Details"))
		//Call DefineSystemVoucherGridColumn(grdVoucherDetails, "Protected", 1000, , , , , False, , , , False, False, "cmbMastersList", , rsVoucherTypes("Show_Product_Name_In_Details"))
		//
		//Me.Top = 0
		//Me.Left = 0
		//
		//mFirstGridFocus = True
		//
		//'Imagelist are kept on the main form and refered by their key
		//Call DrawToolbar(Me, picFormToolbar, btnFormToolBar(0))
		//Set btnFormToolBar(0).Picture = frmSysMain.imlMainToolBar.ListImages("imgNew").Picture
		//Set btnFormToolBar(1).Picture = frmSysMain.imlMainToolBar.ListImages("imgSave").Picture
		//Set btnFormToolBar(2).Picture = frmSysMain.imlMainToolBar.ListImages("imgDelete").Picture
		//Set btnFormToolBar(3).Picture = frmSysMain.imlMainToolBar.ListImages("imgPrint").Picture
		//Set btnFormToolBar(4).Picture = frmSysMain.imlMainToolBar.ListImages("imgFind").Picture
		//Set btnFormToolBar(5).Picture = frmSysMain.imlMainToolBar.ListImages("imgHelp").Picture
		//Set btnFormToolBar(6).Picture = frmSysMain.imlMainToolBar.ListImages("imgInsertLine").Picture
		//Set btnFormToolBar(7).Picture = frmSysMain.imlMainToolBar.ListImages("imgDeleteLine").Picture
		//Set btnFormToolBar(8).Picture = frmSysMain.imlMainToolBar.ListImages("imgExit").Picture
		//
		//mFirstGridFocus = True
		//'setting voucher details grid properties
		//aVoucherDetails.ReDim 0, 0, 0, 6
		//aVoucherDetails(0, 0) = 1
		//Set grdVoucherDetails.Array = aVoucherDetails
		//grdVoucherDetails.ReBind
		//'-- end of voucher grid property setting
		//'cmbCommon.Width = 4900
		//'cmbCommon.Height = 1500
		//
		//Set recDetail = New ADODB.Recordset
		//recDetail.CursorLocation = adUseClient
		//End Sub
		//Public Sub CloseForm()
		//Set aVoucherDetails = Nothing
		//Unload Me
		//End Sub
		//Public Sub GetRecord(SearchTable As String, SearchField As String, SearchValue As Variant, Optional pInputDataType As DataType)
		//'This routine is called after getting the value from Find window or
		//'refreshing the recordset during any error of updating or deleting
		//Dim rsLocalRec As ADODB.Recordset
		//Dim mySql As String
		//Dim mCodes As Variant
		//
		//If IsEmpty(SearchValue) Or IsNull(SearchValue) Then Exit Sub
		//
		//On Error GoTo eFoundError
		//
		//
		//If pInputDataType = NumberType Or pInputDataType = 0 Then
		//    mySql = " select * from " & SearchTable & " where " & SearchField & " = " & SearchValue
		//Else
		//    mySql = " select * from " & SearchTable & " where " & SearchField & " = '" & SearchValue & "'"
		//End If
		//
		//Set rsLocalRec = New ADODB.Recordset
		//rsLocalRec.Open mySql, gConn, adOpenForwardOnly, adLockReadOnly
		//With rsLocalRec
		//    If Not .EOF Then
		//        mSearchValue = .Fields("Report_Id")
		//        txtReportID.Text = .Fields("Report_Id")
		//        txtLReportName.Text = .Fields("L_Report_Name")
		//        txtChildReportId.Text = .Fields("Child_Report_Id")
		//        txtChildReportId2.Text = .Fields("Child_Report_Id2")
		//        txtChildFormId.Text = .Fields("Child_Form_Id")
		//        txtFromClause.Text = .Fields("From_Clause") & ""
		//        txtWhereClause.Text = .Fields("Where_Clause") & ""
		//        txtOrderByClause.Text = .Fields("Order_By_Clause") & ""
		//        txtVariablesDeclarationSQL.Text = .Fields("Variables_Declaration_SQL") & ""
		//        chkShow.Value = IIf(.Fields("Show"), 1, 0)
		//        chkProtected.Value = IIf(.Fields("Protected"), 1, 0)
		//        chkShowFilterCondition.Value = IIf(.Fields("Show_Filter_Condition"), 1, 0)
		//        chkShowDrillDownReport.Value = IIf(.Fields("Show_Drill_Down_Report"), 1, 0)
		//        chkShowDateRange.Value = IIf(.Fields("Show_Date_Range"), 1, 0)
		//
		//        'On Error GoTo eFoundError
		//
		//    End If
		//End With
		//
		//rsLocalRec.Close
		//Set rsLocalRec = Nothing
		//
		//Dim rsLocalRec1 As New ADODB.Recordset
		//
		//Dim mysql1 As String
		//
		//
		//mysql1 = "SELECT  Column_Id, Report_Id, Column_No, Table_Id, Field_Id, Group_By_Field_Id, Linked_Parameter_Type, Linked_Parameter_Name, L_Field_Caption, A_Field_Caption ,"
		//mysql1 = mysql1 & " Field_Type, Field_Language, Field_Alignment, Show_Title, Show_Detail, Enable_Sorting, Enable_Grand_Total, Filter_Condition, Apply_Format, "
		//mysql1 = mysql1 & " Format_Text_Type, Column_Type, Formula_Columns_Definition, Formula_Columns_Calculation, Enable_Filter, Filter_List_Types, List_SQL_Type, "
		//mysql1 = mysql1 & " Show , Protected FROM SM_REPORT_FIELDS "
		//mysql1 = mysql1 & " where Report_Id = " & mSearchValue & " order by Column_no "
		//
		//
		//rsLocalRec1.Open mysql1, gConn, adOpenForwardOnly, adLockReadOnly
		//
		//aVoucherDetails.Clear
		//aVoucherDetails.ReDim 0, 0, 0, 6
		//
		//grdVoucherDetails.Columns(1).Alignment = dbgLeft
		//grdVoucherDetails.Columns(2).Alignment = dbgLeft
		//Dim cnt As Integer
		//With rsLocalRec1
		//    If Not .EOF Then
		//        Do While Not .EOF
		//
		//            aVoucherDetails.ReDim 0, cnt, 0, 27
		//            aVoucherDetails(cnt, 0) = Trim(.Fields("Column_Id"))
		//            aVoucherDetails(cnt, 1) = Trim(.Fields("Report_Id"))
		//            aVoucherDetails(cnt, 2) = Trim(.Fields("Column_No"))
		//            aVoucherDetails(cnt, 3) = Trim(.Fields("Table_Id"))
		//            aVoucherDetails(cnt, 4) = Trim(.Fields("Field_Id"))
		//            aVoucherDetails(cnt, 5) = Trim(.Fields("Group_By_Field_Id"))
		//            aVoucherDetails(cnt, 6) = Trim(.Fields("Linked_Parameter_Type"))
		//            aVoucherDetails(cnt, 7) = Trim(.Fields("Linked_Parameter_Name"))
		//            aVoucherDetails(cnt, 8) = IIf(gPreferedLanguage = English, Trim(.Fields("L_Field_Caption")), Trim(.Fields("A_Field_Caption")))
		//            aVoucherDetails(cnt, 9) = Trim(.Fields("Field_Type"))
		//            aVoucherDetails(cnt, 10) = Trim(.Fields("Field_Language"))
		//            aVoucherDetails(cnt, 11) = Trim(.Fields("Field_Alignment"))
		//            aVoucherDetails(cnt, 12) = Trim(.Fields("Show_Title"))
		//            aVoucherDetails(cnt, 13) = Trim(.Fields("Show_Detail"))
		//            aVoucherDetails(cnt, 14) = Trim(.Fields("Enable_Sorting"))
		//            aVoucherDetails(cnt, 15) = Trim(.Fields("Enable_Grand_Total"))
		//            aVoucherDetails(cnt, 16) = Trim(.Fields("Filter_Condition"))
		//            aVoucherDetails(cnt, 17) = Trim(.Fields("Apply_Format"))
		//            aVoucherDetails(cnt, 18) = Trim(.Fields("Format_Text_Type"))
		//            aVoucherDetails(cnt, 19) = Trim(.Fields("Column_Type"))
		//            aVoucherDetails(cnt, 20) = Trim(.Fields("Formula_Columns_Definition"))
		//            aVoucherDetails(cnt, 21) = Trim(.Fields("Formula_Columns_Calculation"))
		//            aVoucherDetails(cnt, 22) = Trim(.Fields("Enable_Filter"))
		//            aVoucherDetails(cnt, 23) = Trim(.Fields("Filter_List_Types"))
		//            aVoucherDetails(cnt, 24) = Trim(.Fields("List_SQL_Type"))
		//            aVoucherDetails(cnt, 25) = Trim(.Fields("Show"))
		//            aVoucherDetails(cnt, 26) = Trim(.Fields("Protected"))
		//            cnt = cnt + 1
		//            .MoveNext
		//        Loop
		//    End If
		//End With
		//rsLocalRec1.Close
		//Set rsLocalRec = Nothing
		//
		//'Call AssignGridLineNumbers
		//
		//grdVoucherDetails.ReBind
		//grdVoucherDetails.Refresh
		//
		//Exit Sub
		//eFoundError:
		//Call ErrorHandlingRoutine(Err.Number, Err.Description, Me.Name, "GetRecord")
		//End Sub
		//Public Sub findRecord()
		//'Call the find window
		//Dim tempSearch  As New frmSearch
		//Dim mArr(1)
		//mArr(0) = 2500
		//mArr(1) = 3000
		//
		//tempSearch.gridSqlString = "select Report_Id as [Report Id], l_Report_name as [Report Name],Report_Id  from SM_REPORTS"
		//tempSearch.gridColWidth = mArr
		//tempSearch.formName = Me
		//tempSearch.Show 1
		//
		//If Not IsItEmpty(tempSearch.getReturnValue, NumberType) Then
		//    Call GetRecord("SM_REPORTS", "Report_Id", tempSearch.getReturnValue, NumberType)
		//End If
		//
		//Unload tempSearch
		//Set tempSearch = Nothing
		//End Sub
		//
		private void Form_Closed(Object eventSender, EventArgs eventArgs)
		{
		}
	}
}