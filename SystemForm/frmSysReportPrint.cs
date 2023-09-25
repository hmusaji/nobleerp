
using System;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;


namespace Xtreme
{
	internal partial class frmSysReportPrint
		: System.Windows.Forms.Form
	{

		public frmSysReportPrint()
{
InitializeComponent();
} 
 public  void frmSysReportPrint_old()
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


		private void frmSysReportPrint_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (UpgradeHelpers.Gui.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Gui.ActivateHelper.myActiveForm = (System.Windows.Forms.Form) eventSender;
			}
		}
		private string mRecordSource = "";
		private string mReportType = "";
		//**- module type 1 = gl -  2 = ics, purchase, sales
		private int mReportModuleType = 0;

		public string RecordSource
		{
			set
			{
				mRecordSource = value;
			}
		}


		public string ReportType
		{
			set
			{
				mReportType = value;
			}
		}


		public int ReportModuleType
		{
			set
			{
				mReportModuleType = value;
			}
		}


		private void Form_KeyDown(Object eventSender, KeyEventArgs eventArgs)
		{
			int KeyCode = (int) eventArgs.KeyCode;
			int Shift = ((int) eventArgs.KeyData) / 65536;
			try
			{
				if (KeyCode == 27)
				{
					this.Close();
				}
			}
			finally
			{
				eventArgs.Handled = KeyCode == 0;
			}
		}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2080
		private void Form_Load()
		{
			try
			{
				clsHourGlass mHourGlass = null;
				mHourGlass = new clsHourGlass();

				this.Top = 45;
				this.Left = 1;
				this.Height = 507;
				this.Width = 767;

				//**--design the preview window
				vsrReportPreviewer.Top = 0;
				vsrReportPreviewer.Left = 0;
				vsrReportPreviewer.Height = this.ClientRectangle.Height;
				vsrReportPreviewer.Width = this.ClientRectangle.Width;
				vsrReportPreviewer.Clear();
				vsrReportPreviewer.Refresh();

				//**----------------------------------------------------------------------
				//**--load the report file & its format into the report control
				//**--and redirect it to the report previewer object
				object mReturnValue = null;
				string mPrintVoucherName = "";
				string mVoucherCaption = "";
				vsrReportPrinter.DataSource.ConnectionString = SystemVariables.gConn.ConnectionString;
				if (mReportModuleType == 1)
				{
					//'commented by Moiz Hakimion 31-mar-2004
					//'as it was not printing the other gl vouchers
					//Select Case mReportType
					//Case 101 To 107             'For Accounts Voucher
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode("select print_voucher_name , l_voucher_name , a_voucher_name  from gl_accnt_voucher_types where voucher_type =" + mReportType));
					//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mPrintVoucherName = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(0));
					this.Text = ReflectionHelper.GetPrimitiveValue<string>((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? ((Array) mReturnValue).GetValue(1) : ((Array) mReturnValue).GetValue(2));
					vsrReportPrinter.Load(SystemProcedure2.AppPath(Path.GetDirectoryName(Application.ExecutablePath)) + ReflectionHelper.GetPrimitiveValue<string>(SystemProcedure2.GetSystemPreferenceSetting("report_print_file_name")) + ".xml", mPrintVoucherName);
					//End Select
				}
				else if (mReportModuleType == 2)
				{ 
					if (StringsHelper.ToDoubleSafe(mReportType) >= 101 && StringsHelper.ToDoubleSafe(mReportType) <= 207)
					{ //For Purchase Invoice
						//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode("select print_voucher_name , l_voucher_name , a_voucher_name  from ICS_Transaction_Types where voucher_type =" + mReportType));
						//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mPrintVoucherName = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(0));
						this.Text = ReflectionHelper.GetPrimitiveValue<string>((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? ((Array) mReturnValue).GetValue(1) : ((Array) mReturnValue).GetValue(2));
						vsrReportPrinter.Load(SystemProcedure2.AppPath(Path.GetDirectoryName(Application.ExecutablePath)) + ReflectionHelper.GetPrimitiveValue<string>(SystemProcedure2.GetSystemPreferenceSetting("report_print_file_name")) + ".xml", mPrintVoucherName);
					}
					else if (StringsHelper.ToDoubleSafe(mReportType) >= 301 && StringsHelper.ToDoubleSafe(mReportType) <= 413)
					{  //For Inventory Voucher
						//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode("select print_voucher_name , l_voucher_name , a_voucher_name  from ICS_Transaction_Types where voucher_type =" + mReportType));
						//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mPrintVoucherName = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(0));
						this.Text = ReflectionHelper.GetPrimitiveValue<string>((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? ((Array) mReturnValue).GetValue(1) : ((Array) mReturnValue).GetValue(2));
						vsrReportPrinter.Load(SystemProcedure2.AppPath(Path.GetDirectoryName(Application.ExecutablePath)) + ReflectionHelper.GetPrimitiveValue<string>(SystemProcedure2.GetSystemPreferenceSetting("report_print_file_name")) + ".xml", mPrintVoucherName);
					}
					else if (StringsHelper.ToDoubleSafe(mReportType) == 1001)
					{  //For Sales
						//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode("select print_voucher_name , l_voucher_name , a_voucher_name  from ICS_Transaction_Types where voucher_type =" + mReportType));
						//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mPrintVoucherName = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(0));
						this.Text = ReflectionHelper.GetPrimitiveValue<string>((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? ((Array) mReturnValue).GetValue(1) : ((Array) mReturnValue).GetValue(2));
						vsrReportPrinter.Load(SystemProcedure2.AppPath(Path.GetDirectoryName(Application.ExecutablePath)) + ReflectionHelper.GetPrimitiveValue<string>(SystemProcedure2.GetSystemPreferenceSetting("report_print_file_name")) + ".xml", mPrintVoucherName);
					}
				}
				vsrReportPrinter.DataSource.RecordSource = mRecordSource;
				vsrReportPrinter.Render(vsrReportPreviewer);
				//**----------------------------------------------------------------------
			}
			catch (System.Exception excep)
			{
				MessageBox.Show(excep.Message, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
			}
		}

		private void Form_Closed(Object eventSender, EventArgs eventArgs)
		{
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{

				SystemMenu.RemoveMeFromWindowList(Conversion.Str(this.Handle.ToInt32()));
				frmSysReportPrint.DefInstance = null;
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		//Private Sub PrintReport()
		//On Error GoTo eFoundError
		//
		//Dim mReturnValue As Integer
		//
		//mReturnValue = GetPageSetup(2)
		//If mReturnValue <> 0 Then
		//    If mCurrentReportMode = rptNormalMode Then
		//        oReportPrinter.Clear
		//        oReportPrinter.DocName = IIf(gPreferedLanguage = English, rsMasterRecordset("l_report_name").Value, rsMasterRecordset("a_report_name").Value)
		//        Call RenderReportToPreview
		//    End If
		//    If oReportPrinter.PrintDialog(pdGetToFile) = vbFalse Then
		//        oReportPrinter.PrintDoc False, oReportPrinter.PrintDialog(pdGetFromPage), oReportPrinter.PrintDialog(pdGetToPage)
		//    Else
		//        '**-- procedure for print to file option
		//    End If
		//End If
		//
		//Exit Sub
		//eFoundError:
		//MsgBox Err.Description
		//
		//End Sub
		//
		//Private Function GetPageSetup(Optional ByVal pDialogType As Integer = 1) As Integer
		//On Error GoTo eFoundError
		//
		//'**-- return 0 : if cancled by user
		//'**-- return 1 : if ok button pressed (with changes)
		//'**-- return 2 : if ok button pressed (with changes)
		//
		//Dim mOldDevice As String
		//Dim mOldPaperSize As PaperSizeSettings
		//Dim mOldOrientation As OrientationSettings
		//Dim mOldMarginLeft As Variant
		//Dim mOldMarginTop As Variant
		//Dim mOldMarginRight As Variant
		//Dim mOldMarginBottom As Variant
		//
		//With oReportPrinter
		//    mOldDevice = .Device
		//    mOldPaperSize = .PaperSize
		//    mOldOrientation = .Orientation
		//    mOldMarginLeft = .MarginLeft
		//    mOldMarginTop = .MarginTop
		//    mOldMarginRight = .MarginRight
		//    mOldMarginBottom = .MarginBottom
		//End With
		//
		//'page setup options
		//If pDialogType = 1 Then
		//    If oReportPrinter.PrintDialog(pdPageSetup) = vbTrue Then
		//        GetPageSetup = 2
		//    Else
		//        GetPageSetup = 0
		//    End If
		//ElseIf pDialogType = 2 Then
		//    If oReportPrinter.PrintDialog(pdPrint) = vbTrue Then
		//        GetPageSetup = 2
		//    Else
		//        GetPageSetup = 0
		//    End If
		//End If
		//
		//If GetPageSetup = 2 Then
		//    '**--check if the settings are changed ; otherwise return false
		//    With oReportPrinter
		//        If mOldDevice = .Device And mOldPaperSize = .PaperSize And mOldOrientation = .Orientation And mOldMarginLeft = .MarginLeft And mOldMarginTop = .MarginTop And mOldMarginRight = .MarginRight And mOldMarginBottom = .MarginBottom Then
		//            GetPageSetup = 1
		//        End If
		//    End With
		//End If
		//DoEvents
		//
		//Exit Function
		//eFoundError:
		//MsgBox Err.Description
		//
		//End Function
	}
}