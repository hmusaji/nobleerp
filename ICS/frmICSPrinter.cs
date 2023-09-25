using System;

namespace Xtreme
{
	internal partial class frmICSPrinter
		: System.Windows.Forms.Form
	{

		public frmICSPrinter()
{
InitializeComponent();
} 
 public  void frmICSPrinter_old()
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


		private void frmICSPrinter_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (UpgradeHelpers.Gui.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Gui.ActivateHelper.myActiveForm = (System.Windows.Forms.Form) eventSender;
			}
		}
		//'Assign the Formid for Each Form
		//Dim mThisFormID As Long
		//
		//'Variable for storing the searchvalue from the Find window
		//Dim mSearchValue As Variant
		//'This class checks for the rights given to the user
		//Public UserAccess As New clsAccessAllowed
		//'Enum for checking the current form mode
		//Private mCurrentFormMode  As SystemFormModes
		//Private oThisFormToolBar As clsToolbar
		//
		//Public FirstFocusObject As Control
		//Dim mTimeStamp As String
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
		//Private Sub Form_Load()
		//Set FirstFocusObject = txtPrinterNo
		//
		//On Error GoTo eFoundError
		//
		//Me.CurrentFormMode = frmAddMode
		//Me.Top = 0
		//Me.Left = 0
		//
		//'**--format & define the new toolbar
		//Set oThisFormToolBar = New clsToolbar
		//With oThisFormToolBar
		//    .AttachObject Me ', tcbSystemForm
		//
		//    .ShowNewButton = True
		//    .ShowSaveButton = True
		//    .ShowDeleteButton = True
		//    .ShowPrintButton = True
		//    .ShowFindButton = True
		//    .ShowHelpButton = True
		//    .ShowExitButton = True
		//    .BeginExitButtonWithGroup = True
		//    .DisableHelpButton = True
		//
		//    Me.WindowState = FormWindowStateConstants.vbMaximized
		//End With
		//
		//
		//txtPrinterNo.Text = GetNewNumber("ICS_Printers", "Printer_no")
		//
		//Dim prt As Printer
		//
		//For Each prt In Printers
		//Me.cmbPrinter.AddItem (prt.DeviceName)
		//Next
		//
		//Call SetLabelCaption(Me)
		//If gPreferedLanguage = Arabic And GetSystemPreferenceSetting("flip_controls_in_arabic") = vbTrue Then
		//    Dim oFlipThisForm As New clsFlip
		//
		//    oFlipThisForm.SwapMe Me
		//End If
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
		//Call SystemFormKeyDown(Me, KeyCode, Shift, Me.ActiveControl.Name)
		//End Sub
		//
		//Public Sub AddRecord()
		//'Add a record
		//Call ClearTextBox(Me)
		//txtCounterNo.Text = GetNewNumber("ICS_Printers", "Printer_no")
		//
		//mCurrentFormMode = frmAddMode                           'Change the form mode to addmode
		//mSearchValue = ""                                       'Change the msearchvalue to blank
		//FirstFocusObject.SetFocus
		//
		//Exit Sub
		//eFoundError:
		//Call ErrorHandlingRoutine(Err.Number, Err.Description, Me.Name, "AddRecord")
		//End Sub
		//
		//Public Function saveRecord() As Boolean
		//Dim mySql As String
		//On Error GoTo eFoundError
		//'Save a record
		//'During save check for the mode
		//'If in addmode then insert a record
		//'else update the record in the recordset
		//
		//If mCurrentFormMode = frmAddMode Then
		//    mySql = "insert into   ICS_Printers(User_Cd, Printer_no, L_Printer_Name, A_Printer_Name, Printer_Path)  "
		//    mySql = mySql & " values (" & Str(gLoggedInUserCode) & ","
		//    mySql = mySql + Str(txtPrinterNo.Text) & ","
		//    mySql = mySql & "'" & txtLPrinterName.Text & "',"
		//    mySql = mySql & "N'" & txtAPrinterName.Text & "',"
		//    mySql = mySql & "'" & cmbPrinter.Text & "'" & ")"
		//    gConn.Execute (mySql)
		//Else
		// Dim mCheckTimeStamp As String
		//    mySql = " select time_stamp,protected from ICS_Printers where Printer_cd =" & mSearchValue
		//    mReturnValue = GetMasterCode(mySql)
		//    If Not IsNull(mReturnValue) Then
		//        mCheckTimeStamp = mReturnValue(0)
		//    Else
		//        MsgBox msg10, vbInformation
		//        gConn.RollbackTrans
		//        saveRecord = False
		//        FirstFocusObject.SetFocus
		//        Exit Function
		//    End If
		//
		//    mySql = "UPDATE ICS_Printers SET "
		//    mySql = mySql & " Printer_no =" & txtPrinterNo.Text & ","
		//    mySql = mySql & " L_Printer_Name ='" & txtLPrinterName.Text & "',"
		//    mySql = mySql & " A_Printer_Name ='" & txtAPrinterName.Text & "',"
		//    mySql = mySql & " Printer_Path = '" & cmbPrinter.Text & "',"
		//    mySql = mySql & " User_Cd =" & Str(gLoggedInUserCode)
		//    mySql = mySql + " where Printer_cd=" & Str(mSearchValue)
		//    gConn.Execute (mySql)
		//End If
		//saveRecord = True
		//Exit Function
		//
		//eFoundError:
		//Dim mReturnErrorType As Integer
		//mReturnErrorType = ErrorHandlingRoutine(Err.Number, Err.Description, Me.Name, "GetRecord", msg10)
		//If mReturnErrorType = 1 Then
		//    mSearchValue = GetMasterCode("select Printer_Cd from  ICS_Printers where Printer_no= " & txtPrinterNo.Text)
		//    Call GetRecord(mSearchValue)
		//    saveRecord = False
		//ElseIf mReturnErrorType = 2 Then
		//    Call AddRecord
		//    saveRecord = False
		//Else
		//    saveRecord = False
		//End If
		//End Function
		//
		//Public Sub GetRecord(SearchValue As Variant)
		//'SearchTable As String, SearchField As String,
		//'This routine is called after getting the value from Find window or
		//'refreshing the recordset during any error of updating or deleting
		//
		//Dim mySql As String
		//Dim rsLocalRec As ADODB.Recordset
		//
		//On Error GoTo eFoundError
		//
		//If IsEmpty(mSearchValue) Or IsNull(mSearchValue) Or mSearchValue = "" Then Exit Sub
		//
		//
		//mySql = " select * from ICS_Printers where Printer_Cd = '" & SearchValue & "'"
		//'mysql = " select * from " & SearchTable & " where " & SearchField & " = " & SearchValue
		//Set rsLocalRec = New ADODB.Recordset
		//rsLocalRec.Open mySql, gConn, adOpenStatic, adLockOptimistic
		//With rsLocalRec
		//    If Not .EOF Then
		//        txtPrinterNo.Text = .Fields("Printer_no")
		//        txtLPrinterName.Text = .Fields("L_Printer_Name")
		//        txtAPrinterName.Text = .Fields("A_Printer_Name")
		//        cmbPrinter.Text = .Fields("Printer_Path") & ""
		//        'Change the form mode to edit
		//        mCurrentFormMode = frmEditMode
		//    End If
		//End With
		//Exit Sub
		//
		//eFoundError:
		//Call ErrorHandlingRoutine(Err.Number, Err.Description, Me.Name, "GetRecord")
		//End Sub
		//
		//Public Function deleteRecord()
		//'Delete the Record
		//On Error GoTo eFoundError
		//If localRec("protected") = 0 Then
		//    localRec.Delete
		//    deleteRecord = True
		//Else
		//    MsgBox msg12, vbCritical, "Error"
		//    deleteRecord = False
		//    Exit Function
		//End If
		//Exit Function
		//
		//eFoundError:
		//Dim mReturnErrorType As Integer
		//mReturnErrorType = ErrorHandlingRoutine(Err.Number, Err.Description, Me.Name, "GetRecord", msg10)
		//If mReturnErrorType = 1 Then
		//    mSearchValue = GetMasterCode("select Printer_Cd from  ICS_Printers where Printer_no= " & txtPrinterNo.Text)
		//    Call GetRecord(mSearchValue)
		//    deleteRecord = False
		//ElseIf mReturnErrorType = 2 Then
		//    Call AddRecord
		//    deleteRecord False
		//Else
		//    deleteRecord = False
		//End If
		//End Function
		//
		//Public Sub findRecord()
		//'Call the find window
		//Dim mTempSearchValue As Variant
		//
		//mTempSearchValue = FindItem(9018130)
		//If Not IsNull(mTempSearchValue) Then
		//    mSearchValue = mTempSearchValue(0)
		//    Call GetRecord(mSearchValue)
		//End If
		//End Sub
		//Public Sub CloseForm()
		//Unload Me
		//End Sub
		private void Form_Closed(Object eventSender, EventArgs eventArgs)
		{
		}
	}
}