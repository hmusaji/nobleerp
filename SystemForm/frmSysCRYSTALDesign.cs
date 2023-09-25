
using System;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using UpgradeHelpers.Gui;



namespace Xtreme
{
	internal partial class frmSysCRYSTALDesign
		: System.Windows.Forms.Form
	{



		public clsAccessAllowed UserAccess = null;

		public DataSet rsMasterRecordset = null;
		public DataSet rsDetailsRecordset = null;
		public CRAXDDRT.Application craPrimaryApplication = null;
		public CRAXDDRT.Report crrPrimaryReport = null;
		public bool mReportDataSourceIsSet = false;

		private int mReportId = 0;
		private bool mReportSettingsChanged = false;
		private bool mReportInProcess = false;

		//**--give the contants as the Label ID of the option (from SM_LABLES)
		//Private Const tbnReportOptions As Integer = 482
		//Private Const tbnMoveFirstPage As Integer = 1823
		//Private Const tbnMovePreviousPage As Integer = 1824
		//Private Const tbnMoveNextPage As Integer = 1825
		//Private Const tbnMoveLastPage As Integer = 1826
		//Private Const tbnPrintReport As Integer = 541
		//Private Const tbnPageSetup As Integer = 707
		//Private Const tbnExportReport As Integer = 266
		//Private Const tbnZoomPreview As Integer = 1821
		//Private Const tbnFindText As Integer = 276
		//Private Const tbnHelp As Integer = 308
		//Private Const tbnExit As Integer = 261
		//Private Const tbnSaveReport As Integer = 698

		private const string mZoomMenuPrefix = "Zoom";
		private int[] aZoomLevels = new int[9];
		public frmSysCRYSTALDesign()
{
InitializeComponent();
} 
 public  void frmSysCRYSTALDesign_old()
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



		public int ReportID
		{
			get
			{
				return mReportId;
			}
		}


		public clsAccessAllowed SetReportAccess
		{
			set
			{
				UserAccess = value;
			}
		}


		public void SetReportID(int pNewReportID)
		{
			mReportId = pNewReportID;
			CreateReportTablesDefinition();
			SaveReportInformation();
		}

		private void crvReportDesign_DrillOnSubreport(object GroupNameList, string SubreportName, string Title, int PageNumber, int Index, bool UseDefault)
		{
			if (!ReflectionHelper.GetMember<bool>(crvReportDesign, "DisplayTabs"))
			{
				ReflectionHelper.LetMember(crvReportDesign, "DisplayTabs", true);
			}
		}

		private void Form_Activated(Object eventSender, EventArgs eventArgs)
		{
			if (ActivateHelper.myActiveForm != eventSender)
			{
				ActivateHelper.myActiveForm = (Form) eventSender;
				frmSysMain.DefInstance.RibbonBar().FindTab(SystemConstants.gReportTab).Visible = true;
				RefreshRebbonBar();
				frmSysMain.DefInstance.RibbonBar()[frmSysMain.DefInstance.RibbonBar().FindTab(SystemConstants.gReportTab).Index].Selected = true;
			}
		}

		//UPGRADE_WARNING: (2065) Form event Form.Deactivate has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2065
		private void Form_Deactivate(Object eventSender, EventArgs eventArgs)
		{
			frmSysMain.DefInstance.RibbonBar().FindTab(SystemConstants.gReportTab).Visible = false;
			frmSysMain.DefInstance.RibbonBar()[frmSysMain.DefInstance.RibbonBar().FindTab(SystemConstants.gReportTab).Index].Selected = false;
		}

		private void Form_KeyDown(Object eventSender, KeyEventArgs eventArgs)
		{
			int KeyCode = (int) eventArgs.KeyCode;
			int Shift = ((int) eventArgs.KeyData) / 65536;
			try
			{
				try
				{

					//**--if the report is processing data ignore all the inputs
					if (mReportInProcess)
					{
						return;
					}

					if (KeyCode == ((int) Keys.Escape))
					{
						CloseForm();
						//    Case vbKeyF5                    'if report is refreshed
						//        KeyCode = 0
						//        mReportSettingsChanged = True
						//        mCurrentReportMode = rptNormalMode
						//        frmSysMain.mnuSystemMenu.StatusBar.FindPane(gStatusToolTip).Text = "Refreshing Report..."
						//        Call GetReportData
						//    Case vbKeyF3                    'if searching for next record of current search expression
						//        KeyCode = 0
						//        If SeekReportRow(1) = False Then
						//            MsgBox "No Match Found", vbInformation, "Find Record"
						//            oReportGrid.SetFocus
						//        End If
						//    Case vbKeyG
						//        KeyCode = 0
						//        If Shift = vbCtrlMask Then
						//            Call ChangeCurrentPreviewPage
						//        End If
						//        Shift = 0
					}
					else
					{
					}
					//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
					Keys tempRefParam = (Keys) KeyCode;
					SystemReportKeyDown(this, ref tempRefParam, Shift);
					KeyCode = (int) tempRefParam;
					return;
				}
				catch (System.Exception excep)
				{

					MessageBox.Show(excep.Message, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
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

				this.Top = 0;
				this.Left = 0;
				//    .Width = frmSysMain.oSystemInformation.WorkAreaWidth - 100
				//    If frmSysMain.oSystemInformation.OSVersion > 5 Then
				//        .Height = frmSysMain.oSystemInformation.WorkAreaHeight - (frmSysMain.Height - frmSysMain.ScaleHeight)
				//        .Width = frmSysMain.oSystemInformation.WorkAreaWidth - (frmSysMain.Width - frmSysMain.ScaleWidth)
				//    Else
				//        .Height = frmSysMain.oSystemInformation.WorkAreaHeight - (frmSysMain.Height - frmSysMain.ScaleHeight)
				//    End If

				this.Width = Convert.ToInt32(frmSysMain.DefInstance.oSystemInformation.WorkAreaWidth - 400) / 15;
				this.Height = Convert.ToInt32(frmSysMain.DefInstance.oSystemInformation.WorkAreaHeight - 2500) / 15;

				if (SystemVariables.gPreferedLanguage == SystemVariables.Language.Arabic)
				{
					this.RightToLeft = RightToLeft.Yes;
				}

				//**--define report toolbar
				//Call DefineReportToolbar

				DoFormatReportDesign();
				mReportSettingsChanged = true;
				this.WindowState = FormWindowState.Maximized;

				this.Show();
				Application.DoEvents();
				//**-------------------------------------------------------------------------------------------
				if (!mReportDataSourceIsSet)
				{
					SetReportData();
				}
			}
			catch (System.Exception excep)
			{

				MessageBox.Show(excep.Message, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
			}
		}

		private void Form_FormClosing(Object eventSender, FormClosingEventArgs eventArgs)
		{
			int Cancel = (eventArgs.Cancel) ? 1 : 0;
			int UnloadMode = (int) eventArgs.CloseReason;
			try
			{
				frmSysMain.DefInstance.RibbonBar().FindTab(SystemConstants.gReportTab).Visible = false;
				frmSysMain.DefInstance.RibbonBar()[frmSysMain.DefInstance.RibbonBar().FindTab(SystemConstants.gReportTab).Index].Selected = false;
			}
			finally
			{
				eventArgs.Cancel = Cancel != 0;
			}
		}

		private bool isInitializingComponent;
		private void Form_Resize(Object eventSender, EventArgs eventArgs)
		{
			if (isInitializingComponent)
			{
				return;
			}
			crvReportDesign.Width = this.Width - 5;
		}

		private void Form_Closed(Object eventSender, EventArgs eventArgs)
		{
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{

				UserAccess = null;

				SystemMenu.RemoveMeFromWindowList(Conversion.Str(this.Handle.ToInt32()));
				craPrimaryApplication = null;
				crrPrimaryReport = null;
				rsMasterRecordset = null;
				rsDetailsRecordset = null;
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		public void CloseForm()
		{
			this.Close();
		}



		//Private Sub DefineZoomToolMenu(ByRef ParentZoomMenu As XtremeCommandBars.CommandBarPopup)
		//Dim ButtonControl As CommandBarControl
		//Dim mCurrentKey As String
		//Dim cnt As Integer
		//
		//aZoomLevels(0) = 25
		//aZoomLevels(1) = 50
		//aZoomLevels(2) = 75
		//aZoomLevels(3) = 100
		//aZoomLevels(4) = 125
		//aZoomLevels(5) = 150
		//aZoomLevels(6) = 200
		//aZoomLevels(7) = 300
		//aZoomLevels(8) = 400
		//
		//With ParentZoomMenu
		//    For cnt = 0 To UBound(aZoomLevels)
		//        mCurrentKey = "Zoom" & Trim(Str(aZoomLevels(cnt)))
		//        Set ButtonControl = .CommandBar.Controls.Add(xtpControlButton, tbnZoomPreview + aZoomLevels(cnt), mZoomMenuPrefix & Str(aZoomLevels(cnt)) & "%")
		//        ButtonControl.Parameter = aZoomLevels(cnt)
		//        'tcbSystemReport.FindControl(, tbnZoomPreview + aZoomLevels(cnt)).Parameter
		//    Next
		//End With
		//End Sub

		private void DoFormatReportDesign()
		{
			int mToolBarTop = 0;

			//tcbSystemReport.GetClientRect mToolBarLeft, mToolBarTop, mToolBarRight, mToolBarBottom

			ReflectionHelper.LetMember(crvReportDesign, "DisplayBackgroundEdge", false);
			ReflectionHelper.LetMember(crvReportDesign, "DisplayBorder", false);
			ReflectionHelper.LetMember(crvReportDesign, "DisplayGroupTree", false);

			ReflectionHelper.LetMember(crvReportDesign, "DisplayTabs", false);
			ReflectionHelper.LetMember(crvReportDesign, "DisplayToolbar", false);
			ReflectionHelper.LetMember(crvReportDesign, "EnableAnimationCtrl", false);
			ReflectionHelper.LetMember(crvReportDesign, "EnableCloseButton", false);

			//'modified by Moiz Hakimion 07-jan-2006
			ReflectionHelper.LetMember(crvReportDesign, "EnableDrillDown", true);
			//.EnableDrillDown = False

			ReflectionHelper.LetMember(crvReportDesign, "EnableExportButton", false);
			ReflectionHelper.LetMember(crvReportDesign, "EnableGroupTree", false);
			ReflectionHelper.LetMember(crvReportDesign, "EnablePopupMenu", false);
			ReflectionHelper.LetMember(crvReportDesign, "EnableHelpButton", false);
			ReflectionHelper.LetMember(crvReportDesign, "EnableNavigationControls", false);
			ReflectionHelper.LetMember(crvReportDesign, "EnablePrintButton", false);
			ReflectionHelper.LetMember(crvReportDesign, "EnableProgressControl", false);
			ReflectionHelper.LetMember(crvReportDesign, "EnableRefreshButton", false);
			ReflectionHelper.LetMember(crvReportDesign, "EnableStopButton", false);
			ReflectionHelper.LetMember(crvReportDesign, "EnableSelectExpertButton", false);
			ReflectionHelper.LetMember(crvReportDesign, "EnableSearchControl", false);
			ReflectionHelper.LetMember(crvReportDesign, "EnableToolbar", true);
			ReflectionHelper.LetMember(crvReportDesign, "EnableZoomControl", true);

			crvReportDesign.Left = 0;
			crvReportDesign.Top = mToolBarTop / 15;
			crvReportDesign.Width = this.ClientRectangle.Width;
			crvReportDesign.Height = this.ClientRectangle.Height - crvReportDesign.Top;
			crvReportDesign.Visible = true;
			if (SystemVariables.gPreferedLanguage == SystemVariables.Language.English)
			{
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				this.Text = Convert.ToString(rsMasterRecordset.Tables[0].Rows[0]["l_report_name"]) + "";
			}
			else
			{
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				this.Text = Convert.ToString(rsMasterRecordset.Tables[0].Rows[0]["a_report_name"]) + "";
			}
		}

		private void CreateReportTablesDefinition()
		{
			try
			{

				rsMasterRecordset = new DataSet();
				rsDetailsRecordset = new DataSet();

				//**--create master report information table
				//UPGRADE_ISSUE: (2070) Constant adFldUnspecified was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2070
				//UPGRADE_ISSUE: (2064) ADODB.Fields15 method rsMasterRecordset.Fields.Append was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				UpgradeStubs.ADODB_Fields15.Append("report_id", DbType.Decimal, 0, UpgradeStubs.ADODB_FieldAttributeEnum.getadFldUnspecified(), null);
				//UPGRADE_ISSUE: (2070) Constant adFldUnspecified was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2070
				//UPGRADE_ISSUE: (2064) ADODB.Fields15 method rsMasterRecordset.Fields.Append was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				UpgradeStubs.ADODB_Fields15.Append("module_id", DbType.Int32, 0, UpgradeStubs.ADODB_FieldAttributeEnum.getadFldUnspecified(), null);
				//UPGRADE_ISSUE: (2064) ADODB.FieldAttributeEnum property FieldAttributeEnum.adFldIsNullable was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				//UPGRADE_ISSUE: (2064) ADODB.Fields15 method rsMasterRecordset.Fields.Append was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				UpgradeStubs.ADODB_Fields15.Append("l_report_name", DbType.String, 50, UpgradeStubs.ADODB_FieldAttributeEnum.getadFldIsNullable(), null);
				//UPGRADE_ISSUE: (2064) ADODB.FieldAttributeEnum property FieldAttributeEnum.adFldIsNullable was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				//UPGRADE_ISSUE: (2064) ADODB.Fields15 method rsMasterRecordset.Fields.Append was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				UpgradeStubs.ADODB_Fields15.Append("a_report_name", DbType.String, 50, UpgradeStubs.ADODB_FieldAttributeEnum.getadFldIsNullable(), null);
				//UPGRADE_ISSUE: (2064) ADODB.FieldAttributeEnum property FieldAttributeEnum.adFldIsNullable was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				//UPGRADE_ISSUE: (2064) ADODB.Fields15 method rsMasterRecordset.Fields.Append was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				UpgradeStubs.ADODB_Fields15.Append("l_report_title1", DbType.String, 100, UpgradeStubs.ADODB_FieldAttributeEnum.getadFldIsNullable(), null);
				//UPGRADE_ISSUE: (2064) ADODB.FieldAttributeEnum property FieldAttributeEnum.adFldIsNullable was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				//UPGRADE_ISSUE: (2064) ADODB.Fields15 method rsMasterRecordset.Fields.Append was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				UpgradeStubs.ADODB_Fields15.Append("a_report_title1", DbType.String, 100, UpgradeStubs.ADODB_FieldAttributeEnum.getadFldIsNullable(), null);
				//UPGRADE_ISSUE: (2064) ADODB.FieldAttributeEnum property FieldAttributeEnum.adFldIsNullable was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				//UPGRADE_ISSUE: (2064) ADODB.Fields15 method rsMasterRecordset.Fields.Append was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				UpgradeStubs.ADODB_Fields15.Append("l_report_title2", DbType.String, 100, UpgradeStubs.ADODB_FieldAttributeEnum.getadFldIsNullable(), null);
				//UPGRADE_ISSUE: (2064) ADODB.FieldAttributeEnum property FieldAttributeEnum.adFldIsNullable was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				//UPGRADE_ISSUE: (2064) ADODB.Fields15 method rsMasterRecordset.Fields.Append was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				UpgradeStubs.ADODB_Fields15.Append("a_report_title2", DbType.String, 100, UpgradeStubs.ADODB_FieldAttributeEnum.getadFldIsNullable(), null);
				//UPGRADE_ISSUE: (2070) Constant adFldUnspecified was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2070
				//UPGRADE_ISSUE: (2064) ADODB.Fields15 method rsMasterRecordset.Fields.Append was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				UpgradeStubs.ADODB_Fields15.Append("show_company_name", DbType.Boolean, 0, UpgradeStubs.ADODB_FieldAttributeEnum.getadFldUnspecified(), null);
				//UPGRADE_ISSUE: (2070) Constant adFldUnspecified was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2070
				//UPGRADE_ISSUE: (2064) ADODB.Fields15 method rsMasterRecordset.Fields.Append was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				UpgradeStubs.ADODB_Fields15.Append("show_addr1", DbType.Boolean, 0, UpgradeStubs.ADODB_FieldAttributeEnum.getadFldUnspecified(), null);
				//UPGRADE_ISSUE: (2070) Constant adFldUnspecified was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2070
				//UPGRADE_ISSUE: (2064) ADODB.Fields15 method rsMasterRecordset.Fields.Append was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				UpgradeStubs.ADODB_Fields15.Append("show_addr2", DbType.Boolean, 0, UpgradeStubs.ADODB_FieldAttributeEnum.getadFldUnspecified(), null);
				//UPGRADE_ISSUE: (2070) Constant adFldUnspecified was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2070
				//UPGRADE_ISSUE: (2064) ADODB.Fields15 method rsMasterRecordset.Fields.Append was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				UpgradeStubs.ADODB_Fields15.Append("show_report_name", DbType.Boolean, 0, UpgradeStubs.ADODB_FieldAttributeEnum.getadFldUnspecified(), null);
				//UPGRADE_ISSUE: (2070) Constant adFldUnspecified was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2070
				//UPGRADE_ISSUE: (2064) ADODB.Fields15 method rsMasterRecordset.Fields.Append was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				UpgradeStubs.ADODB_Fields15.Append("show_title1", DbType.Boolean, 0, UpgradeStubs.ADODB_FieldAttributeEnum.getadFldUnspecified(), null);
				//UPGRADE_ISSUE: (2070) Constant adFldUnspecified was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2070
				//UPGRADE_ISSUE: (2064) ADODB.Fields15 method rsMasterRecordset.Fields.Append was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				UpgradeStubs.ADODB_Fields15.Append("show_title2", DbType.Boolean, 0, UpgradeStubs.ADODB_FieldAttributeEnum.getadFldUnspecified(), null);
				//UPGRADE_ISSUE: (2070) Constant adFldUnspecified was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2070
				//UPGRADE_ISSUE: (2064) ADODB.Fields15 method rsMasterRecordset.Fields.Append was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				UpgradeStubs.ADODB_Fields15.Append("show_title_filter_condition", DbType.Boolean, 0, UpgradeStubs.ADODB_FieldAttributeEnum.getadFldUnspecified(), null);
				//UPGRADE_ISSUE: (2070) Constant adFldUnspecified was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2070
				//UPGRADE_ISSUE: (2064) ADODB.Fields15 method rsMasterRecordset.Fields.Append was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				UpgradeStubs.ADODB_Fields15.Append("show_filter_condition", DbType.Boolean, 0, UpgradeStubs.ADODB_FieldAttributeEnum.getadFldUnspecified(), null);
				//UPGRADE_ISSUE: (2070) Constant adFldUnspecified was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2070
				//UPGRADE_ISSUE: (2064) ADODB.Fields15 method rsMasterRecordset.Fields.Append was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				UpgradeStubs.ADODB_Fields15.Append("show_date_range", DbType.Boolean, 0, UpgradeStubs.ADODB_FieldAttributeEnum.getadFldUnspecified(), null);
				//UPGRADE_ISSUE: (2070) Constant adFldUnspecified was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2070
				//UPGRADE_ISSUE: (2064) ADODB.Fields15 method rsMasterRecordset.Fields.Append was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				UpgradeStubs.ADODB_Fields15.Append("show_report_options_first", DbType.Boolean, 0, UpgradeStubs.ADODB_FieldAttributeEnum.getadFldUnspecified(), null);
				//UPGRADE_ISSUE: (2064) ADODB.FieldAttributeEnum property FieldAttributeEnum.adFldIsNullable was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				//UPGRADE_ISSUE: (2064) ADODB.Fields15 method rsMasterRecordset.Fields.Append was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				UpgradeStubs.ADODB_Fields15.Append("default_report_export_file_name", DbType.String, 50, UpgradeStubs.ADODB_FieldAttributeEnum.getadFldIsNullable(), null);
				//UPGRADE_ISSUE: (2070) Constant adFldUnspecified was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2070
				//UPGRADE_ISSUE: (2064) ADODB.Fields15 method rsMasterRecordset.Fields.Append was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				UpgradeStubs.ADODB_Fields15.Append("show_page_no_on_print", DbType.Boolean, 0, UpgradeStubs.ADODB_FieldAttributeEnum.getadFldUnspecified(), null);
				//UPGRADE_ISSUE: (2070) Constant adFldUnspecified was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2070
				//UPGRADE_ISSUE: (2064) ADODB.Fields15 method rsMasterRecordset.Fields.Append was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				UpgradeStubs.ADODB_Fields15.Append("show_current_date_on_print", DbType.Boolean, 0, UpgradeStubs.ADODB_FieldAttributeEnum.getadFldUnspecified(), null);
				//UPGRADE_ISSUE: (2070) Constant adFldUnspecified was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2070
				//UPGRADE_ISSUE: (2064) ADODB.Fields15 method rsMasterRecordset.Fields.Append was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				UpgradeStubs.ADODB_Fields15.Append("show_current_time_on_print", DbType.Boolean, 0, UpgradeStubs.ADODB_FieldAttributeEnum.getadFldUnspecified(), null);
				//UPGRADE_ISSUE: (2070) Constant adFldUnspecified was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2070
				//UPGRADE_ISSUE: (2064) ADODB.Fields15 method rsMasterRecordset.Fields.Append was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				UpgradeStubs.ADODB_Fields15.Append("use_distinct_records", DbType.Boolean, 0, UpgradeStubs.ADODB_FieldAttributeEnum.getadFldUnspecified(), null);
				//UPGRADE_ISSUE: (2064) ADODB.FieldAttributeEnum property FieldAttributeEnum.adFldIsNullable was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				//UPGRADE_ISSUE: (2064) ADODB.Fields15 method rsMasterRecordset.Fields.Append was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				UpgradeStubs.ADODB_Fields15.Append("external_report_file_name", DbType.String, 70, UpgradeStubs.ADODB_FieldAttributeEnum.getadFldIsNullable(), null);
				//UPGRADE_ISSUE: (2064) ADODB.FieldAttributeEnum property FieldAttributeEnum.adFldIsNullable was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				//UPGRADE_ISSUE: (2064) ADODB.Fields15 method rsMasterRecordset.Fields.Append was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				UpgradeStubs.ADODB_Fields15.Append("a_external_report_file_name", DbType.String, 70, UpgradeStubs.ADODB_FieldAttributeEnum.getadFldIsNullable(), null);
				//UPGRADE_ISSUE: (2070) Constant adFldUnspecified was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2070
				//UPGRADE_ISSUE: (2064) ADODB.Fields15 method rsMasterRecordset.Fields.Append was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				UpgradeStubs.ADODB_Fields15.Append("show_as_on_date_only", DbType.Boolean, 0, UpgradeStubs.ADODB_FieldAttributeEnum.getadFldUnspecified(), null);
				//UPGRADE_ISSUE: (2064) ADODB.FieldAttributeEnum property FieldAttributeEnum.adFldIsNullable was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				//UPGRADE_ISSUE: (2064) ADODB.Fields15 method rsMasterRecordset.Fields.Append was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				UpgradeStubs.ADODB_Fields15.Append("sub_report_names", DbType.String, 500, UpgradeStubs.ADODB_FieldAttributeEnum.getadFldIsNullable(), null);
				//UPGRADE_ISSUE: (2070) Constant adFldUnspecified was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2070
				//UPGRADE_ISSUE: (2064) ADODB.Fields15 method rsMasterRecordset.Fields.Append was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				UpgradeStubs.ADODB_Fields15.Append("print_immediately_after_display", DbType.Boolean, 0, UpgradeStubs.ADODB_FieldAttributeEnum.getadFldUnspecified(), null);
				//UPGRADE_ISSUE: (2070) Constant adFldUnspecified was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2070
				//UPGRADE_ISSUE: (2064) ADODB.Fields15 method rsMasterRecordset.Fields.Append was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				UpgradeStubs.ADODB_Fields15.Append("enable_report_options", DbType.Boolean, 0, UpgradeStubs.ADODB_FieldAttributeEnum.getadFldUnspecified(), null);
				//UPGRADE_ISSUE: (2070) Constant adFldUnspecified was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2070
				//UPGRADE_ISSUE: (2064) ADODB.Fields15 method rsMasterRecordset.Fields.Append was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				UpgradeStubs.ADODB_Fields15.Append("print_without_preview", DbType.Boolean, 0, UpgradeStubs.ADODB_FieldAttributeEnum.getadFldUnspecified(), null);

				//UPGRADE_ISSUE: (2064) ADODB.FieldAttributeEnum property FieldAttributeEnum.adFldIsNullable was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				//UPGRADE_ISSUE: (2064) ADODB.Fields15 method rsMasterRecordset.Fields.Append was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				UpgradeStubs.ADODB_Fields15.Append("report_from_date_caption", DbType.String, 50, UpgradeStubs.ADODB_FieldAttributeEnum.getadFldIsNullable(), null);
				//UPGRADE_ISSUE: (2064) ADODB.FieldAttributeEnum property FieldAttributeEnum.adFldIsNullable was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				//UPGRADE_ISSUE: (2064) ADODB.Fields15 method rsMasterRecordset.Fields.Append was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				UpgradeStubs.ADODB_Fields15.Append("report_to_date_caption", DbType.String, 50, UpgradeStubs.ADODB_FieldAttributeEnum.getadFldIsNullable(), null);
				//**--non-database columns
				//UPGRADE_ISSUE: (2064) ADODB.FieldAttributeEnum property FieldAttributeEnum.adFldIsNullable was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				//UPGRADE_ISSUE: (2064) ADODB.Fields15 method rsMasterRecordset.Fields.Append was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				UpgradeStubs.ADODB_Fields15.Append("report_title_filter", DbType.String, 500, UpgradeStubs.ADODB_FieldAttributeEnum.getadFldIsNullable(), null);
				//UPGRADE_ISSUE: (2064) ADODB.FieldAttributeEnum property FieldAttributeEnum.adFldIsNullable was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				//UPGRADE_ISSUE: (2064) ADODB.Fields15 method rsMasterRecordset.Fields.Append was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				UpgradeStubs.ADODB_Fields15.Append("report_details_filter", DbType.String, 1000, UpgradeStubs.ADODB_FieldAttributeEnum.getadFldIsNullable(), null);
				//UPGRADE_ISSUE: (2064) ADODB.FieldAttributeEnum property FieldAttributeEnum.adFldIsNullable was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				//UPGRADE_ISSUE: (2064) ADODB.Fields15 method rsMasterRecordset.Fields.Append was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				UpgradeStubs.ADODB_Fields15.Append("report_from_date", DbType.String, 25, UpgradeStubs.ADODB_FieldAttributeEnum.getadFldIsNullable(), null);
				//UPGRADE_ISSUE: (2064) ADODB.FieldAttributeEnum property FieldAttributeEnum.adFldIsNullable was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				//UPGRADE_ISSUE: (2064) ADODB.Fields15 method rsMasterRecordset.Fields.Append was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				UpgradeStubs.ADODB_Fields15.Append("report_to_date", DbType.String, 25, UpgradeStubs.ADODB_FieldAttributeEnum.getadFldIsNullable(), null);

				//**-----Page Setup
				//UPGRADE_ISSUE: (2070) Constant adFldUnspecified was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2070
				//UPGRADE_ISSUE: (2064) ADODB.Fields15 method rsMasterRecordset.Fields.Append was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				UpgradeStubs.ADODB_Fields15.Append("PaperSize", DbType.Decimal, 0, UpgradeStubs.ADODB_FieldAttributeEnum.getadFldUnspecified(), null);
				//UPGRADE_ISSUE: (2064) ADODB.FieldAttributeEnum property FieldAttributeEnum.adFldIsNullable was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				//UPGRADE_ISSUE: (2064) ADODB.Fields15 method rsMasterRecordset.Fields.Append was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				UpgradeStubs.ADODB_Fields15.Append("PrintDevice", DbType.String, 255, UpgradeStubs.ADODB_FieldAttributeEnum.getadFldIsNullable(), null);
				//UPGRADE_ISSUE: (2070) Constant adFldUnspecified was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2070
				//UPGRADE_ISSUE: (2064) ADODB.Fields15 method rsMasterRecordset.Fields.Append was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				UpgradeStubs.ADODB_Fields15.Append("Orientation", DbType.Decimal, 0, UpgradeStubs.ADODB_FieldAttributeEnum.getadFldUnspecified(), null);
				//UPGRADE_ISSUE: (2070) Constant adFldUnspecified was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2070
				//UPGRADE_ISSUE: (2064) ADODB.Fields15 method rsMasterRecordset.Fields.Append was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				UpgradeStubs.ADODB_Fields15.Append("MarginTop", DbType.Decimal, 0, UpgradeStubs.ADODB_FieldAttributeEnum.getadFldUnspecified(), null);
				//UPGRADE_ISSUE: (2070) Constant adFldUnspecified was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2070
				//UPGRADE_ISSUE: (2064) ADODB.Fields15 method rsMasterRecordset.Fields.Append was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				UpgradeStubs.ADODB_Fields15.Append("MarginBottom", DbType.Decimal, 0, UpgradeStubs.ADODB_FieldAttributeEnum.getadFldUnspecified(), null);
				//UPGRADE_ISSUE: (2070) Constant adFldUnspecified was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2070
				//UPGRADE_ISSUE: (2064) ADODB.Fields15 method rsMasterRecordset.Fields.Append was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				UpgradeStubs.ADODB_Fields15.Append("MarginLeft", DbType.Decimal, 0, UpgradeStubs.ADODB_FieldAttributeEnum.getadFldUnspecified(), null);
				//UPGRADE_ISSUE: (2070) Constant adFldUnspecified was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2070
				//UPGRADE_ISSUE: (2064) ADODB.Fields15 method rsMasterRecordset.Fields.Append was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				UpgradeStubs.ADODB_Fields15.Append("MarginRight", DbType.Decimal, 0, UpgradeStubs.ADODB_FieldAttributeEnum.getadFldUnspecified(), null);

				//**--create report column information table
				//UPGRADE_ISSUE: (2070) Constant adFldUnspecified was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2070
				//UPGRADE_ISSUE: (2064) ADODB.Fields15 method rsDetailsRecordset.Fields.Append was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				UpgradeStubs.ADODB_Fields15.Append("column_id", DbType.Decimal, 0, UpgradeStubs.ADODB_FieldAttributeEnum.getadFldUnspecified(), null);
				//UPGRADE_ISSUE: (2070) Constant adFldUnspecified was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2070
				//UPGRADE_ISSUE: (2064) ADODB.Fields15 method rsDetailsRecordset.Fields.Append was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				UpgradeStubs.ADODB_Fields15.Append("report_id", DbType.Decimal, 0, UpgradeStubs.ADODB_FieldAttributeEnum.getadFldUnspecified(), null);
				//UPGRADE_ISSUE: (2070) Constant adFldUnspecified was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2070
				//UPGRADE_ISSUE: (2064) ADODB.Fields15 method rsDetailsRecordset.Fields.Append was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				UpgradeStubs.ADODB_Fields15.Append("column_no", DbType.Int16, 0, UpgradeStubs.ADODB_FieldAttributeEnum.getadFldUnspecified(), null);
				//UPGRADE_ISSUE: (2064) ADODB.FieldAttributeEnum property FieldAttributeEnum.adFldIsNullable was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				//UPGRADE_ISSUE: (2064) ADODB.Fields15 method rsDetailsRecordset.Fields.Append was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				UpgradeStubs.ADODB_Fields15.Append("linked_parameter_name", DbType.String, 50, UpgradeStubs.ADODB_FieldAttributeEnum.getadFldIsNullable(), null);
				//UPGRADE_ISSUE: (2070) Constant adFldUnspecified was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2070
				//UPGRADE_ISSUE: (2064) ADODB.Fields15 method rsDetailsRecordset.Fields.Append was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				UpgradeStubs.ADODB_Fields15.Append("linked_parameter_type", DbType.SByte, 0, UpgradeStubs.ADODB_FieldAttributeEnum.getadFldUnspecified(), null);
				//UPGRADE_ISSUE: (2064) ADODB.FieldAttributeEnum property FieldAttributeEnum.adFldIsNullable was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				//UPGRADE_ISSUE: (2064) ADODB.Fields15 method rsDetailsRecordset.Fields.Append was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				UpgradeStubs.ADODB_Fields15.Append("l_field_caption", DbType.String, 50, UpgradeStubs.ADODB_FieldAttributeEnum.getadFldIsNullable(), null);
				//UPGRADE_ISSUE: (2064) ADODB.FieldAttributeEnum property FieldAttributeEnum.adFldIsNullable was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				//UPGRADE_ISSUE: (2064) ADODB.Fields15 method rsDetailsRecordset.Fields.Append was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				UpgradeStubs.ADODB_Fields15.Append("a_field_caption", DbType.String, 50, UpgradeStubs.ADODB_FieldAttributeEnum.getadFldIsNullable(), null);
				//UPGRADE_ISSUE: (2070) Constant adFldUnspecified was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2070
				//UPGRADE_ISSUE: (2064) ADODB.Fields15 method rsDetailsRecordset.Fields.Append was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				UpgradeStubs.ADODB_Fields15.Append("field_type", DbType.String, 1, UpgradeStubs.ADODB_FieldAttributeEnum.getadFldUnspecified(), null);
				//UPGRADE_ISSUE: (2064) ADODB.FieldAttributeEnum property FieldAttributeEnum.adFldIsNullable was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				//UPGRADE_ISSUE: (2064) ADODB.Fields15 method rsDetailsRecordset.Fields.Append was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				UpgradeStubs.ADODB_Fields15.Append("filter_condition", DbType.String, 1000, UpgradeStubs.ADODB_FieldAttributeEnum.getadFldIsNullable(), null);
				//UPGRADE_ISSUE: (2070) Constant adFldUnspecified was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2070
				//UPGRADE_ISSUE: (2064) ADODB.Fields15 method rsDetailsRecordset.Fields.Append was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				UpgradeStubs.ADODB_Fields15.Append("enable_filter", DbType.Boolean, 0, UpgradeStubs.ADODB_FieldAttributeEnum.getadFldUnspecified(), null);
				//UPGRADE_ISSUE: (2064) ADODB.FieldAttributeEnum property FieldAttributeEnum.adFldIsNullable was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				//UPGRADE_ISSUE: (2064) ADODB.Fields15 method rsDetailsRecordset.Fields.Append was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				UpgradeStubs.ADODB_Fields15.Append("filter_list_types", DbType.String, 200, UpgradeStubs.ADODB_FieldAttributeEnum.getadFldIsNullable(), null);
				//UPGRADE_ISSUE: (2064) ADODB.FieldAttributeEnum property FieldAttributeEnum.adFldIsNullable was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				//UPGRADE_ISSUE: (2064) ADODB.Fields15 method rsDetailsRecordset.Fields.Append was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				UpgradeStubs.ADODB_Fields15.Append("list_sql_type", DbType.SByte, 0, UpgradeStubs.ADODB_FieldAttributeEnum.getadFldIsNullable(), null);
				//UPGRADE_ISSUE: (2064) ADODB.FieldAttributeEnum property FieldAttributeEnum.adFldIsNullable was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				//UPGRADE_ISSUE: (2064) ADODB.Fields15 method rsDetailsRecordset.Fields.Append was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				UpgradeStubs.ADODB_Fields15.Append("standard_filter_list_type_id", DbType.Int16, 0, UpgradeStubs.ADODB_FieldAttributeEnum.getadFldIsNullable(), null);
				//UPGRADE_ISSUE: (2064) ADODB.FieldAttributeEnum property FieldAttributeEnum.adFldIsNullable was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				//UPGRADE_ISSUE: (2064) ADODB.Fields15 method rsDetailsRecordset.Fields.Append was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				UpgradeStubs.ADODB_Fields15.Append("custom_l_list_field_sql", DbType.String, 2000, UpgradeStubs.ADODB_FieldAttributeEnum.getadFldIsNullable(), null);
				//UPGRADE_ISSUE: (2064) ADODB.FieldAttributeEnum property FieldAttributeEnum.adFldIsNullable was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				//UPGRADE_ISSUE: (2064) ADODB.Fields15 method rsDetailsRecordset.Fields.Append was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				UpgradeStubs.ADODB_Fields15.Append("custom_a_list_field_sql", DbType.String, 2000, UpgradeStubs.ADODB_FieldAttributeEnum.getadFldIsNullable(), null);
				//UPGRADE_ISSUE: (2064) ADODB.FieldAttributeEnum property FieldAttributeEnum.adFldIsNullable was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				//UPGRADE_ISSUE: (2064) ADODB.Fields15 method rsDetailsRecordset.Fields.Append was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				UpgradeStubs.ADODB_Fields15.Append("builtin_from_list_types", DbType.String, 200, UpgradeStubs.ADODB_FieldAttributeEnum.getadFldIsNullable(), null);
				//UPGRADE_ISSUE: (2064) ADODB.FieldAttributeEnum property FieldAttributeEnum.adFldIsNullable was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				//UPGRADE_ISSUE: (2064) ADODB.Fields15 method rsDetailsRecordset.Fields.Append was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				UpgradeStubs.ADODB_Fields15.Append("builtin_to_list_types", DbType.String, 200, UpgradeStubs.ADODB_FieldAttributeEnum.getadFldIsNullable(), null);
				//UPGRADE_ISSUE: (2064) ADODB.FieldAttributeEnum property FieldAttributeEnum.adFldIsNullable was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				//UPGRADE_ISSUE: (2064) ADODB.Fields15 method rsDetailsRecordset.Fields.Append was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				UpgradeStubs.ADODB_Fields15.Append("comments", DbType.String, 100, UpgradeStubs.ADODB_FieldAttributeEnum.getadFldIsNullable(), null);
				//UPGRADE_ISSUE: (2064) ADODB.FieldAttributeEnum property FieldAttributeEnum.adFldIsNullable was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				//UPGRADE_ISSUE: (2064) ADODB.Fields15 method rsDetailsRecordset.Fields.Append was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				UpgradeStubs.ADODB_Fields15.Append("default_from_value", DbType.String, 100, UpgradeStubs.ADODB_FieldAttributeEnum.getadFldIsNullable(), null);
				//UPGRADE_ISSUE: (2064) ADODB.FieldAttributeEnum property FieldAttributeEnum.adFldIsNullable was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				//UPGRADE_ISSUE: (2064) ADODB.Fields15 method rsDetailsRecordset.Fields.Append was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				UpgradeStubs.ADODB_Fields15.Append("default_to_value", DbType.String, 100, UpgradeStubs.ADODB_FieldAttributeEnum.getadFldIsNullable(), null);
				//UPGRADE_ISSUE: (2064) ADODB.FieldAttributeEnum property FieldAttributeEnum.adFldIsNullable was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				//UPGRADE_ISSUE: (2064) ADODB.Fields15 method rsDetailsRecordset.Fields.Append was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				UpgradeStubs.ADODB_Fields15.Append("linked_parameter_name2", DbType.String, 50, UpgradeStubs.ADODB_FieldAttributeEnum.getadFldIsNullable(), null);
				//UPGRADE_ISSUE: (2064) ADODB.FieldAttributeEnum property FieldAttributeEnum.adFldIsNullable was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				//UPGRADE_ISSUE: (2064) ADODB.Fields15 method rsDetailsRecordset.Fields.Append was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				UpgradeStubs.ADODB_Fields15.Append("default_from_value_when_null", DbType.String, 100, UpgradeStubs.ADODB_FieldAttributeEnum.getadFldIsNullable(), null);
				//UPGRADE_ISSUE: (2064) ADODB.FieldAttributeEnum property FieldAttributeEnum.adFldIsNullable was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				//UPGRADE_ISSUE: (2064) ADODB.Fields15 method rsDetailsRecordset.Fields.Append was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				UpgradeStubs.ADODB_Fields15.Append("default_to_value_when_null", DbType.String, 100, UpgradeStubs.ADODB_FieldAttributeEnum.getadFldIsNullable(), null);
				//UPGRADE_ISSUE: (2070) Constant adFldUnspecified was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2070
				//UPGRADE_ISSUE: (2064) ADODB.Fields15 method rsDetailsRecordset.Fields.Append was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				UpgradeStubs.ADODB_Fields15.Append("protected", DbType.Boolean, 0, UpgradeStubs.ADODB_FieldAttributeEnum.getadFldUnspecified(), null);
				//UPGRADE_ISSUE: (2070) Constant adFldUnspecified was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2070
				//UPGRADE_ISSUE: (2064) ADODB.Fields15 method rsDetailsRecordset.Fields.Append was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				UpgradeStubs.ADODB_Fields15.Append("show", DbType.Boolean, 0, UpgradeStubs.ADODB_FieldAttributeEnum.getadFldUnspecified(), null);

				//UPGRADE_ISSUE: (2064) ADODB.FieldAttributeEnum property FieldAttributeEnum.adFldIsNullable was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				//UPGRADE_ISSUE: (2064) ADODB.Fields15 method rsDetailsRecordset.Fields.Append was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				UpgradeStubs.ADODB_Fields15.Append("Report_Options_Find_Id", DbType.Decimal, 0, UpgradeStubs.ADODB_FieldAttributeEnum.getadFldIsNullable(), null);
				//UPGRADE_ISSUE: (2064) ADODB.FieldAttributeEnum property FieldAttributeEnum.adFldIsNullable was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				//UPGRADE_ISSUE: (2064) ADODB.Fields15 method rsDetailsRecordset.Fields.Append was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				UpgradeStubs.ADODB_Fields15.Append("Report_Options_Find_Return_Column_Id", DbType.Decimal, 0, UpgradeStubs.ADODB_FieldAttributeEnum.getadFldIsNullable(), null);



				//UPGRADE_ISSUE: (2070) Constant adLockUnspecified was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2070
				//UPGRADE_ISSUE: (2070) Constant adOpenUnspecified was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2070
				//UPGRADE_ISSUE: (2064) ADODB.Recordset method rsMasterRecordset.Open was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				rsMasterRecordset.Open(null, null, UpgradeStubs.ADODB_CursorTypeEnum.getadOpenUnspecified(), UpgradeStubs.ADODB_LockTypeEnum.getadLockUnspecified(), -1);
				//UPGRADE_ISSUE: (2070) Constant adLockUnspecified was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2070
				//UPGRADE_ISSUE: (2070) Constant adOpenUnspecified was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2070
				//UPGRADE_ISSUE: (2064) ADODB.Recordset method rsDetailsRecordset.Open was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				rsDetailsRecordset.Open(null, null, UpgradeStubs.ADODB_CursorTypeEnum.getadOpenUnspecified(), UpgradeStubs.ADODB_LockTypeEnum.getadLockUnspecified(), -1);
			}
			catch (System.Exception excep)
			{

				MessageBox.Show(excep.Message, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
			}
		}

		private void SaveReportDefinition()
		{ //report save routine
			try
			{

				DialogResult ans = (DialogResult) 0;
				string mysql = "";

				ans = MessageBox.Show("Are you sure you want to save the" + new String(' ', 8) + "\r" + "current report settings?", "System Reports", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
				if (ans == System.Windows.Forms.DialogResult.Yes)
				{
					SystemVariables.gConn.BeginTransaction();
					//gConn.CursorLocation = adUseClient
					mysql = " update SM_REPORTS set ";
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					mysql = mysql + " l_report_Name = '" + Convert.ToString(rsMasterRecordset.Tables[0].Rows[0]["l_report_Name"]).Trim() + "'";
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					mysql = mysql + " , a_report_Name = N'" + Convert.ToString(rsMasterRecordset.Tables[0].Rows[0]["a_report_Name"]).Trim() + "'";
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					mysql = mysql + " , l_report_title1 = '" + Convert.ToString(rsMasterRecordset.Tables[0].Rows[0]["l_report_title1"]).Trim() + "'";
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					mysql = mysql + " , a_report_title1 = N'" + Convert.ToString(rsMasterRecordset.Tables[0].Rows[0]["a_report_title1"]).Trim() + "'";
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					mysql = mysql + " , l_report_title2 = '" + Convert.ToString(rsMasterRecordset.Tables[0].Rows[0]["l_report_title2"]).Trim() + "'";
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					mysql = mysql + " , a_report_title2 = N'" + Convert.ToString(rsMasterRecordset.Tables[0].Rows[0]["a_report_title2"]).Trim() + "'";
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
					mysql = mysql + " , show_company_name = " + ((((TriState) Convert.ToInt32(rsMasterRecordset.Tables[0].Rows[0]["show_company_name"])) == TriState.True) ? Conversion.Str(1) : Conversion.Str(0));
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
					mysql = mysql + " , show_addr1 = " + ((((TriState) Convert.ToInt32(rsMasterRecordset.Tables[0].Rows[0]["show_addr1"])) == TriState.True) ? Conversion.Str(1) : Conversion.Str(0));
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
					mysql = mysql + " , show_addr2 = " + ((((TriState) Convert.ToInt32(rsMasterRecordset.Tables[0].Rows[0]["show_addr2"])) == TriState.True) ? Conversion.Str(1) : Conversion.Str(0));
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
					mysql = mysql + " , show_report_name = " + ((((TriState) Convert.ToInt32(rsMasterRecordset.Tables[0].Rows[0]["show_report_name"])) == TriState.True) ? Conversion.Str(1) : Conversion.Str(0));
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
					mysql = mysql + " , show_title1 = " + ((((TriState) Convert.ToInt32(rsMasterRecordset.Tables[0].Rows[0]["show_title1"])) == TriState.True) ? Conversion.Str(1) : Conversion.Str(0));
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
					mysql = mysql + " , show_title2 = " + ((((TriState) Convert.ToInt32(rsMasterRecordset.Tables[0].Rows[0]["show_title2"])) == TriState.True) ? Conversion.Str(1) : Conversion.Str(0));
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
					mysql = mysql + " , show_title_filter_condition = " + ((((TriState) Convert.ToInt32(rsMasterRecordset.Tables[0].Rows[0]["show_title_filter_condition"])) == TriState.True) ? Conversion.Str(1) : Conversion.Str(0));
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
					mysql = mysql + " , show_filter_condition = " + ((((TriState) Convert.ToInt32(rsMasterRecordset.Tables[0].Rows[0]["show_filter_condition"])) == TriState.True) ? Conversion.Str(1) : Conversion.Str(0));
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
					mysql = mysql + " , show_date_range = " + ((((TriState) Convert.ToInt32(rsMasterRecordset.Tables[0].Rows[0]["show_date_range"])) == TriState.True) ? Conversion.Str(1) : Conversion.Str(0));
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
					mysql = mysql + " , show_report_options_first = " + ((((TriState) Convert.ToInt32(rsMasterRecordset.Tables[0].Rows[0]["show_report_options_first"])) == TriState.True) ? Conversion.Str(1) : Conversion.Str(0));
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					mysql = mysql + " , MarginTop = " + Conversion.Str(rsMasterRecordset.Tables[0].Rows[0]["MarginTop"]);
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					mysql = mysql + " , MarginBottom = " + Conversion.Str(rsMasterRecordset.Tables[0].Rows[0]["MarginBottom"]);
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					mysql = mysql + " , MarginLeft = " + Conversion.Str(rsMasterRecordset.Tables[0].Rows[0]["MarginLeft"]);
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					mysql = mysql + " , MarginRight = " + Conversion.Str(rsMasterRecordset.Tables[0].Rows[0]["MarginRight"]);
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					mysql = mysql + " , PrintDevice = '" + Convert.ToString(rsMasterRecordset.Tables[0].Rows[0]["PrintDevice"]) + "'";
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					mysql = mysql + " , PaperSize = " + Conversion.Str(rsMasterRecordset.Tables[0].Rows[0]["PaperSize"]);
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					mysql = mysql + " , Orientation = " + Conversion.Str(rsMasterRecordset.Tables[0].Rows[0]["Orientation"]);

					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					mysql = mysql + " where report_id = " + Conversion.Str(rsMasterRecordset.Tables[0].Rows[0]["report_id"]);
					SqlCommand TempCommand = null;
					TempCommand = SystemVariables.gConn.CreateCommand();
					TempCommand.CommandText = mysql;
					TempCommand.ExecuteNonQuery();

					//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.CommitTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					SystemVariables.gConn.CommitTrans();

				}
			}
			catch (System.Exception excep)
			{
				//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				SystemVariables.gConn.RollbackTrans();
				MessageBox.Show(excep.Message, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
			}

		}

		public void SaveReportInformation()
		{
			try
			{

				string mysql = "";
				DataSet rsLocalRec = new DataSet();

				//**--get system report header information
				mysql = " select * from SM_REPORTS ";
				mysql = mysql + " where report_id = " + Conversion.Str(mReportId);
				SqlDataAdapter adap = new SqlDataAdapter(mysql, SystemVariables.gConn);
				rsLocalRec.Tables.Clear();
				adap.Fill(rsLocalRec);
				if (rsLocalRec.Tables[0].Rows.Count != 0)
				{
					//UPGRADE_ISSUE: (2064) ADODB.Recordset method rsMasterRecordset.AddNew was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					rsMasterRecordset.AddNew(null, null);
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					//UPGRADE_ISSUE: (2064) ADODB.Field20 property rsMasterRecordset.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					rsMasterRecordset.Tables[0].Rows[0]["report_id"].setValue(rsLocalRec.Tables[0].Rows[0]["report_id"]);
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					//UPGRADE_ISSUE: (2064) ADODB.Field20 property rsMasterRecordset.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					rsMasterRecordset.Tables[0].Rows[0]["module_id"].setValue(rsLocalRec.Tables[0].Rows[0]["module_id"]);
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					//UPGRADE_ISSUE: (2064) ADODB.Field20 property rsMasterRecordset.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					rsMasterRecordset.Tables[0].Rows[0]["l_report_name"].setValue(rsLocalRec.Tables[0].Rows[0]["l_report_name"]);
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					//UPGRADE_ISSUE: (2064) ADODB.Field20 property rsMasterRecordset.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					rsMasterRecordset.Tables[0].Rows[0]["a_report_name"].setValue(rsLocalRec.Tables[0].Rows[0]["a_report_name"]);
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					//UPGRADE_ISSUE: (2064) ADODB.Field20 property rsMasterRecordset.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					rsMasterRecordset.Tables[0].Rows[0]["l_report_title1"].setValue(rsLocalRec.Tables[0].Rows[0]["l_report_title1"]);
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					//UPGRADE_ISSUE: (2064) ADODB.Field20 property rsMasterRecordset.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					rsMasterRecordset.Tables[0].Rows[0]["a_report_title1"].setValue(rsLocalRec.Tables[0].Rows[0]["a_report_title1"]);
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					//UPGRADE_ISSUE: (2064) ADODB.Field20 property rsMasterRecordset.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					rsMasterRecordset.Tables[0].Rows[0]["l_report_title2"].setValue(rsLocalRec.Tables[0].Rows[0]["l_report_title2"]);
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					//UPGRADE_ISSUE: (2064) ADODB.Field20 property rsMasterRecordset.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					rsMasterRecordset.Tables[0].Rows[0]["a_report_title2"].setValue(rsLocalRec.Tables[0].Rows[0]["a_report_title2"]);
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					//UPGRADE_ISSUE: (2064) ADODB.Field20 property rsMasterRecordset.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					rsMasterRecordset.Tables[0].Rows[0]["show_company_name"].setValue(rsLocalRec.Tables[0].Rows[0]["show_company_name"]);
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					//UPGRADE_ISSUE: (2064) ADODB.Field20 property rsMasterRecordset.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					rsMasterRecordset.Tables[0].Rows[0]["show_addr1"].setValue(rsLocalRec.Tables[0].Rows[0]["show_addr1"]);
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					//UPGRADE_ISSUE: (2064) ADODB.Field20 property rsMasterRecordset.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					rsMasterRecordset.Tables[0].Rows[0]["show_addr2"].setValue(rsLocalRec.Tables[0].Rows[0]["show_addr2"]);
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					//UPGRADE_ISSUE: (2064) ADODB.Field20 property rsMasterRecordset.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					rsMasterRecordset.Tables[0].Rows[0]["show_report_name"].setValue(rsLocalRec.Tables[0].Rows[0]["show_report_name"]);
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					//UPGRADE_ISSUE: (2064) ADODB.Field20 property rsMasterRecordset.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					rsMasterRecordset.Tables[0].Rows[0]["show_title1"].setValue(rsLocalRec.Tables[0].Rows[0]["show_title1"]);
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					//UPGRADE_ISSUE: (2064) ADODB.Field20 property rsMasterRecordset.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					rsMasterRecordset.Tables[0].Rows[0]["show_title2"].setValue(rsLocalRec.Tables[0].Rows[0]["show_title2"]);
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					//UPGRADE_ISSUE: (2064) ADODB.Field20 property rsMasterRecordset.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					rsMasterRecordset.Tables[0].Rows[0]["show_title_filter_condition"].setValue(rsLocalRec.Tables[0].Rows[0]["show_title_filter_condition"]);
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					//UPGRADE_ISSUE: (2064) ADODB.Field20 property rsMasterRecordset.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					rsMasterRecordset.Tables[0].Rows[0]["show_filter_condition"].setValue(rsLocalRec.Tables[0].Rows[0]["show_filter_condition"]);
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					//UPGRADE_ISSUE: (2064) ADODB.Field20 property rsMasterRecordset.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					rsMasterRecordset.Tables[0].Rows[0]["show_date_range"].setValue(rsLocalRec.Tables[0].Rows[0]["show_date_range"]);
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					//UPGRADE_ISSUE: (2064) ADODB.Field20 property rsMasterRecordset.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					rsMasterRecordset.Tables[0].Rows[0]["show_report_options_first"].setValue(rsLocalRec.Tables[0].Rows[0]["show_report_options_first"]);
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					//UPGRADE_ISSUE: (2064) ADODB.Field20 property rsMasterRecordset.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					rsMasterRecordset.Tables[0].Rows[0]["default_report_export_file_name"].setValue(rsLocalRec.Tables[0].Rows[0]["default_report_export_file_name"]);
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					//UPGRADE_ISSUE: (2064) ADODB.Field20 property rsMasterRecordset.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					rsMasterRecordset.Tables[0].Rows[0]["show_page_no_on_print"].setValue(rsLocalRec.Tables[0].Rows[0]["show_page_no_on_print"]);
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					//UPGRADE_ISSUE: (2064) ADODB.Field20 property rsMasterRecordset.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					rsMasterRecordset.Tables[0].Rows[0]["show_current_date_on_print"].setValue(rsLocalRec.Tables[0].Rows[0]["show_current_date_on_print"]);
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					//UPGRADE_ISSUE: (2064) ADODB.Field20 property rsMasterRecordset.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					rsMasterRecordset.Tables[0].Rows[0]["show_current_time_on_print"].setValue(rsLocalRec.Tables[0].Rows[0]["show_current_time_on_print"]);
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					//UPGRADE_ISSUE: (2064) ADODB.Field20 property rsMasterRecordset.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					rsMasterRecordset.Tables[0].Rows[0]["use_distinct_records"].setValue(rsLocalRec.Tables[0].Rows[0]["use_distinct_records"]);
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					//UPGRADE_ISSUE: (2064) ADODB.Field20 property rsMasterRecordset.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					rsMasterRecordset.Tables[0].Rows[0]["external_report_file_name"].setValue(Convert.ToString(rsLocalRec.Tables[0].Rows[0]["external_report_file_name"]) + "");
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					//UPGRADE_ISSUE: (2064) ADODB.Field20 property rsMasterRecordset.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					rsMasterRecordset.Tables[0].Rows[0]["a_external_report_file_name"].setValue(Convert.ToString(rsLocalRec.Tables[0].Rows[0]["a_external_report_file_name"]) + "");
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					//UPGRADE_ISSUE: (2064) ADODB.Field20 property rsMasterRecordset.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					rsMasterRecordset.Tables[0].Rows[0]["show_as_on_date_only"].setValue(rsLocalRec.Tables[0].Rows[0]["show_as_on_date_only"]);
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					//UPGRADE_ISSUE: (2064) ADODB.Field20 property rsMasterRecordset.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					rsMasterRecordset.Tables[0].Rows[0]["sub_report_names"].setValue(Convert.ToString(rsLocalRec.Tables[0].Rows[0]["sub_report_names"]) + "");
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					//UPGRADE_ISSUE: (2064) ADODB.Field20 property rsMasterRecordset.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					rsMasterRecordset.Tables[0].Rows[0]["print_immediately_after_display"].setValue(rsLocalRec.Tables[0].Rows[0]["print_immediately_after_display"]);
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					//UPGRADE_ISSUE: (2064) ADODB.Field20 property rsMasterRecordset.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					rsMasterRecordset.Tables[0].Rows[0]["enable_report_options"].setValue(rsLocalRec.Tables[0].Rows[0]["enable_report_options"]);
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					//UPGRADE_ISSUE: (2064) ADODB.Field20 property rsMasterRecordset.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					rsMasterRecordset.Tables[0].Rows[0]["print_without_preview"].setValue(rsLocalRec.Tables[0].Rows[0]["print_without_preview"]);
					//'added by Moiz Hakimi ghee
					//'date:10-apr-2008
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					//UPGRADE_ISSUE: (2064) ADODB.Field20 property rsMasterRecordset.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					rsMasterRecordset.Tables[0].Rows[0]["report_from_date_caption"].setValue(rsLocalRec.Tables[0].Rows[0]["report_from_date_caption"]);
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					//UPGRADE_ISSUE: (2064) ADODB.Field20 property rsMasterRecordset.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					rsMasterRecordset.Tables[0].Rows[0]["report_to_date_caption"].setValue(rsLocalRec.Tables[0].Rows[0]["report_to_date_caption"]);
					//'end
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					//UPGRADE_ISSUE: (2064) ADODB.Field20 property rsMasterRecordset.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					rsMasterRecordset.Tables[0].Rows[0]["report_title_filter"].setValue("");
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					//UPGRADE_ISSUE: (2064) ADODB.Field20 property rsMasterRecordset.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					rsMasterRecordset.Tables[0].Rows[0]["report_details_filter"].setValue("");
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					//UPGRADE_ISSUE: (2064) ADODB.Field20 property rsMasterRecordset.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					rsMasterRecordset.Tables[0].Rows[0]["report_from_date"].setValue(DateTime.Parse("01-" + DateTimeFormatInfo.CurrentInfo.GetAbbreviatedMonthName(DateTime.Today.Month) + "-" + Conversion.Str(DateTime.Today.Year)));
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					//UPGRADE_ISSUE: (2064) ADODB.Field20 property rsMasterRecordset.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					rsMasterRecordset.Tables[0].Rows[0]["report_to_date"].setValue(DateTime.Today);

					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					//UPGRADE_ISSUE: (2064) ADODB.Field20 property rsMasterRecordset.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					rsMasterRecordset.Tables[0].Rows[0]["PaperSize"].setValue(rsLocalRec.Tables[0].Rows[0]["PaperSize"]);
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					//UPGRADE_ISSUE: (2064) ADODB.Field20 property rsMasterRecordset.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					rsMasterRecordset.Tables[0].Rows[0]["PrintDevice"].setValue(rsLocalRec.Tables[0].Rows[0]["PrintDevice"]);
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					//UPGRADE_ISSUE: (2064) ADODB.Field20 property rsMasterRecordset.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					rsMasterRecordset.Tables[0].Rows[0]["Orientation"].setValue(rsLocalRec.Tables[0].Rows[0]["Orientation"]);
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					//UPGRADE_ISSUE: (2064) ADODB.Field20 property rsMasterRecordset.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					rsMasterRecordset.Tables[0].Rows[0]["MarginTop"].setValue(rsLocalRec.Tables[0].Rows[0]["MarginTop"]);
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					//UPGRADE_ISSUE: (2064) ADODB.Field20 property rsMasterRecordset.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					rsMasterRecordset.Tables[0].Rows[0]["MarginBottom"].setValue(rsLocalRec.Tables[0].Rows[0]["MarginBottom"]);
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					//UPGRADE_ISSUE: (2064) ADODB.Field20 property rsMasterRecordset.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					rsMasterRecordset.Tables[0].Rows[0]["MarginLeft"].setValue(rsLocalRec.Tables[0].Rows[0]["MarginLeft"]);
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					//UPGRADE_ISSUE: (2064) ADODB.Field20 property rsMasterRecordset.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					rsMasterRecordset.Tables[0].Rows[0]["MarginRight"].setValue(rsLocalRec.Tables[0].Rows[0]["MarginRight"]);

					//UPGRADE_ISSUE: (2064) ADODB.Recordset method rsMasterRecordset.Update was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					rsMasterRecordset.Update_Renamed(null, null);
				}

				//**--get system report details information
				mysql = " select srd.* ";
				mysql = mysql + " from SM_REPORT_FIELDS srd ";
				mysql = mysql + " inner join SM_Preferences sf on srd.feature_id = sf.preference_id ";
				mysql = mysql + " where srd.report_id = " + Conversion.Str(mReportId);
				mysql = mysql + " and sf.preference_value = '1' ";

				SqlDataAdapter adap_2 = new SqlDataAdapter(mysql, SystemVariables.gConn);
				rsLocalRec.Tables.Clear();
				adap_2.Fill(rsLocalRec);
				foreach (DataRow iteration_row in rsLocalRec.Tables[0].Rows)
				{
					//UPGRADE_ISSUE: (2064) ADODB.Recordset method rsDetailsRecordset.AddNew was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					rsDetailsRecordset.AddNew(null, null);
					//UPGRADE_ISSUE: (2064) ADODB.Field20 property rsDetailsRecordset.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					rsDetailsRecordset.Tables[0].Rows[0]["report_id"].setValue(iteration_row["report_id"]);
					//UPGRADE_ISSUE: (2064) ADODB.Field20 property rsDetailsRecordset.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					rsDetailsRecordset.Tables[0].Rows[0]["column_no"].setValue(iteration_row["column_no"]);
					//UPGRADE_ISSUE: (2064) ADODB.Field20 property rsDetailsRecordset.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					rsDetailsRecordset.Tables[0].Rows[0]["column_id"].setValue(iteration_row["column_id"]);
					//UPGRADE_ISSUE: (2064) ADODB.Field20 property rsDetailsRecordset.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					rsDetailsRecordset.Tables[0].Rows[0]["linked_parameter_name"].setValue(iteration_row["linked_parameter_name"]);
					//UPGRADE_ISSUE: (2064) ADODB.Field20 property rsDetailsRecordset.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					rsDetailsRecordset.Tables[0].Rows[0]["linked_parameter_type"].setValue(iteration_row["linked_parameter_type"]);
					//UPGRADE_ISSUE: (2064) ADODB.Field20 property rsDetailsRecordset.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					rsDetailsRecordset.Tables[0].Rows[0]["l_field_caption"].setValue(iteration_row["l_field_caption"]);
					//UPGRADE_ISSUE: (2064) ADODB.Field20 property rsDetailsRecordset.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					rsDetailsRecordset.Tables[0].Rows[0]["a_field_caption"].setValue(iteration_row["a_field_caption"]);
					//UPGRADE_ISSUE: (2064) ADODB.Field20 property rsDetailsRecordset.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					rsDetailsRecordset.Tables[0].Rows[0]["field_type"].setValue(iteration_row["field_type"]);
					//UPGRADE_ISSUE: (2064) ADODB.Field20 property rsDetailsRecordset.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					rsDetailsRecordset.Tables[0].Rows[0]["filter_condition"].setValue(iteration_row["filter_condition"]);
					//UPGRADE_ISSUE: (2064) ADODB.Field20 property rsDetailsRecordset.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					rsDetailsRecordset.Tables[0].Rows[0]["enable_filter"].setValue(iteration_row["enable_filter"]);
					//UPGRADE_ISSUE: (2064) ADODB.Field20 property rsDetailsRecordset.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					rsDetailsRecordset.Tables[0].Rows[0]["filter_list_types"].setValue(iteration_row["filter_list_types"]);
					//UPGRADE_ISSUE: (2064) ADODB.Field20 property rsDetailsRecordset.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					rsDetailsRecordset.Tables[0].Rows[0]["list_sql_type"].setValue(iteration_row["list_sql_type"]);
					//UPGRADE_ISSUE: (2064) ADODB.Field20 property rsDetailsRecordset.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					rsDetailsRecordset.Tables[0].Rows[0]["standard_filter_list_type_id"].setValue(iteration_row["standard_filter_list_type_id"]);
					//UPGRADE_ISSUE: (2064) ADODB.Field20 property rsDetailsRecordset.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					rsDetailsRecordset.Tables[0].Rows[0]["custom_l_list_field_sql"].setValue(iteration_row["custom_l_list_field_sql"]);
					//UPGRADE_ISSUE: (2064) ADODB.Field20 property rsDetailsRecordset.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					rsDetailsRecordset.Tables[0].Rows[0]["custom_a_list_field_sql"].setValue(iteration_row["custom_a_list_field_sql"]);
					//UPGRADE_ISSUE: (2064) ADODB.Field20 property rsDetailsRecordset.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					rsDetailsRecordset.Tables[0].Rows[0]["builtin_from_list_types"].setValue(iteration_row["builtin_from_list_types"]);
					//UPGRADE_ISSUE: (2064) ADODB.Field20 property rsDetailsRecordset.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					rsDetailsRecordset.Tables[0].Rows[0]["builtin_to_list_types"].setValue(iteration_row["builtin_to_list_types"]);
					//UPGRADE_ISSUE: (2064) ADODB.Field20 property rsDetailsRecordset.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					rsDetailsRecordset.Tables[0].Rows[0]["comments"].setValue(iteration_row["comments"]);
					//UPGRADE_ISSUE: (2064) ADODB.Field20 property rsDetailsRecordset.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					rsDetailsRecordset.Tables[0].Rows[0]["default_from_value"].setValue(iteration_row["default_from_value"]);
					//UPGRADE_ISSUE: (2064) ADODB.Field20 property rsDetailsRecordset.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					rsDetailsRecordset.Tables[0].Rows[0]["default_to_value"].setValue(iteration_row["default_to_value"]);
					//UPGRADE_ISSUE: (2064) ADODB.Field20 property rsDetailsRecordset.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					rsDetailsRecordset.Tables[0].Rows[0]["linked_parameter_name2"].setValue(iteration_row["linked_parameter_name2"]);
					//UPGRADE_ISSUE: (2064) ADODB.Field20 property rsDetailsRecordset.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					rsDetailsRecordset.Tables[0].Rows[0]["default_from_value_when_null"].setValue(iteration_row["default_from_value_when_null"]);
					//UPGRADE_ISSUE: (2064) ADODB.Field20 property rsDetailsRecordset.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					rsDetailsRecordset.Tables[0].Rows[0]["default_to_value_when_null"].setValue(iteration_row["default_to_value_when_null"]);
					//UPGRADE_ISSUE: (2064) ADODB.Field20 property rsDetailsRecordset.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					rsDetailsRecordset.Tables[0].Rows[0]["protected"].setValue(iteration_row["protected"]);
					//UPGRADE_ISSUE: (2064) ADODB.Field20 property rsDetailsRecordset.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					rsDetailsRecordset.Tables[0].Rows[0]["show"].setValue(iteration_row["show"]);

					//UPGRADE_ISSUE: (2064) ADODB.Field20 property rsDetailsRecordset.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					rsDetailsRecordset.Tables[0].Rows[0]["Report_Options_Find_Id"].setValue(iteration_row["Report_Options_Find_Id"]);
					//UPGRADE_ISSUE: (2064) ADODB.Field20 property rsDetailsRecordset.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					rsDetailsRecordset.Tables[0].Rows[0]["Report_Options_Find_Return_Column_Id"].setValue(iteration_row["Report_Options_Find_Return_Column_Id"]);

					//UPGRADE_ISSUE: (2064) ADODB.Recordset method rsDetailsRecordset.Update was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					rsDetailsRecordset.Update_Renamed(null, null);
				}
				rsLocalRec = null;
			}
			catch (System.Exception excep)
			{
				MessageBox.Show(excep.Message, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
			}

		}

		public void SetReportData()
		{
			CRAXDDRT.DatabaseTable DBTable = null;
			CRAXDDRT.Section crsSubReportSection = null;
			object rptReportObjects = null;
			CRAXDDRT.SubreportObject sroSubReport = null;

			if (mReportDataSourceIsSet)
			{
				return;
			}

			craPrimaryApplication = new CRAXDDRT.Application();

			try
			{
				if (SystemVariables.gPreferedLanguage == SystemVariables.Language.English)
				{
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					crrPrimaryReport = (CRAXDDRT.Report) craPrimaryApplication.OpenReport(SystemProcedure2.AppPath(Path.GetDirectoryName(Application.ExecutablePath)) + SystemVariables.gReportFilesFolder + "\\" + Convert.ToString(rsMasterRecordset.Tables[0].Rows[0]["external_report_file_name"]), Type.Missing);
				}
				else
				{
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					crrPrimaryReport = (CRAXDDRT.Report) craPrimaryApplication.OpenReport(SystemProcedure2.AppPath(Path.GetDirectoryName(Application.ExecutablePath)) + SystemVariables.gReportFilesFolder + "\\" + Convert.ToString(rsMasterRecordset.Tables[0].Rows[0]["a_external_report_file_name"]), Type.Missing);
				}

				try
				{

					crrPrimaryReport.DiscardSavedData();

					foreach (CRAXDDRT.DatabaseTable DBTableIterator in crrPrimaryReport.Database.Tables)
					{
						DBTable = DBTableIterator;
						ReflectionHelper.LetMember(ReflectionHelper.Invoke(DBTable, "ConnectionProperties", new object[]{"User ID"}), "Value", SystemVariables.gSQLServerUserID);
						ReflectionHelper.LetMember(ReflectionHelper.Invoke(DBTable, "ConnectionProperties", new object[]{"Password"}), "Value", SystemVariables.gSQLServerPassword);
						if (ReflectionHelper.Invoke<string>(DBTable, "ConnectionProperties", new object[]{"Provider"}) != "SQLOLEDB")
						{
							ReflectionHelper.LetMember(DBTable, "ConnectionProperties", "SQLOLEDB", "Provider");
						}
						//UPGRADE_ISSUE: (2064) ADODB.Connection property gConn.Properties was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						//UPGRADE_ISSUE: (2064) ADODB.Properties property gConn.Properties.Item was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						//UPGRADE_ISSUE: (2064) ADODB.Property property gConn.Properties.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						if (ReflectionHelper.GetMember(ReflectionHelper.Invoke(DBTable, "ConnectionProperties", new object[]{"Data Source"}), "Value") != SystemVariables.gConn.getProperties().Item("Data Source").getValue())
						{
							//UPGRADE_ISSUE: (2064) ADODB.Connection property gConn.Properties was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
							//UPGRADE_ISSUE: (2064) ADODB.Properties property gConn.Properties.Item was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
							//UPGRADE_ISSUE: (2064) ADODB.Property property gConn.Properties.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
							ReflectionHelper.LetMember(ReflectionHelper.Invoke(DBTable, "ConnectionProperties", new object[]{"Data Source"}), "Value", SystemVariables.gConn.getProperties().Item("Data Source").getValue());
						}
						if (ReflectionHelper.GetMember<string>(ReflectionHelper.Invoke(DBTable, "ConnectionProperties", new object[]{"Initial Catalog"}), "Value") != SystemVariables.gDatabaseName)
						{
							ReflectionHelper.LetMember(ReflectionHelper.Invoke(DBTable, "ConnectionProperties", new object[]{"Initial Catalog"}), "Value", SystemVariables.gDatabaseName);
						}
						DBTable.Location = SystemVariables.gDatabaseName + ".." + DBTable.Name;
						if (ReflectionHelper.GetMember<string>(ReflectionHelper.Invoke(DBTable, "ConnectionProperties", new object[]{"Integrated Security"}), "Value") != "False")
						{
							ReflectionHelper.LetMember(ReflectionHelper.Invoke(DBTable, "ConnectionProperties", new object[]{"Integrated Security"}), "Value", "False");
						}
						DBTable = default(CRAXDDRT.DatabaseTable);
					}

					foreach (CRAXDDRT.Section crsSubReportSectionIterator in crrPrimaryReport.Sections)
					{
						crsSubReportSection = crsSubReportSectionIterator;
						foreach (object rptReportObjectsIterator in crsSubReportSection.ReportObjects)
						{
							rptReportObjects = rptReportObjectsIterator;
							//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
							if (((CRAXDDRT.CRObjectKind) ReflectionHelper.GetMember<int>(rptReportObjects, "Kind")) == CRAXDDRT.CRObjectKind.crSubreportObject)
							{
								sroSubReport = (CRAXDDRT.SubreportObject) rptReportObjects;
								foreach (CRAXDDRT.DatabaseTable DBTableIterator2 in sroSubReport.OpenSubreport().Database.Tables)
								{
									DBTable = DBTableIterator2;
									ReflectionHelper.LetMember(DBTable, "ConnectionProperties", "SQLOLEDB", "Provider");
									//UPGRADE_ISSUE: (2064) ADODB.Connection property gConn.Properties was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
									//UPGRADE_ISSUE: (2064) ADODB.Properties property gConn.Properties.Item was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
									//UPGRADE_ISSUE: (2064) ADODB.Property property gConn.Properties.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
									ReflectionHelper.LetMember(ReflectionHelper.Invoke(DBTable, "ConnectionProperties", new object[]{"Data Source"}), "Value", SystemVariables.gConn.getProperties().Item("Data Source").getValue());
									ReflectionHelper.LetMember(ReflectionHelper.Invoke(DBTable, "ConnectionProperties", new object[]{"User ID"}), "Value", SystemVariables.gSQLServerUserID);
									ReflectionHelper.LetMember(ReflectionHelper.Invoke(DBTable, "ConnectionProperties", new object[]{"Password"}), "Value", SystemVariables.gSQLServerPassword);
									ReflectionHelper.LetMember(ReflectionHelper.Invoke(DBTable, "ConnectionProperties", new object[]{"Integrated Security"}), "Value", "False");
									ReflectionHelper.LetMember(ReflectionHelper.Invoke(DBTable, "ConnectionProperties", new object[]{"Initial Catalog"}), "Value", SystemVariables.gDatabaseName);
									DBTable.Location = SystemVariables.gDatabaseName + ".." + DBTable.Name;
									DBTable = default(CRAXDDRT.DatabaseTable);
								}
								sroSubReport = null;
							}
							rptReportObjects = default(object);
						}
						crsSubReportSection = default(CRAXDDRT.Section);
					}
					DBTable = null;
					crsSubReportSection = null;
					rptReportObjects = null;
					sroSubReport = null;
					mReportDataSourceIsSet = true;
					return;
				}
				catch (System.Exception excep)
				{

					MessageBox.Show(excep.Message, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
					CloseForm();
					return;
				}
			}
			catch
			{

				DialogResult ans = (DialogResult) 0;
				string mFileName = "";
				string mysql = "";
				ans = MessageBox.Show(" Invalid File Name. File does not exists. Do you want to set the file name? ", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.YesNo, MessageBoxIcon.Information);
				if (ans == System.Windows.Forms.DialogResult.Yes)
				{
					mFileName = InputBoxHelper.InputBox("Enter the file name with extension.", " Report File Name");
					if (mFileName != "")
					{
						mysql = " update SM_REPORTS ";
						mysql = mysql + " set ";
						if (SystemVariables.gPreferedLanguage == SystemVariables.Language.English)
						{
							mysql = mysql + " external_report_file_name='" + mFileName + "'";
						}
						else
						{
							mysql = mysql + " a_external_report_file_name='" + mFileName + "'";
						}
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						mysql = mysql + " where report_id =" + Convert.ToString(rsMasterRecordset.Tables[0].Rows[0]["report_id"]);
						SqlCommand TempCommand = null;
						TempCommand = SystemVariables.gConn.CreateCommand();
						TempCommand.CommandText = mysql;
						TempCommand.ExecuteNonQuery();

						mReportDataSourceIsSet = true;
						MessageBox.Show(" Report File Name Updated. ReRun the Report Again. ", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					}
				}
				return;
			}
		}

		public void GetReportData()
		{
			try
			{

				mReportInProcess = true;

				ReflectionHelper.LetMember(crvReportDesign, "ReportSource", ReflectionHelper.GetPrimitiveValue(crrPrimaryReport));

				ReflectionHelper.Invoke(crvReportDesign, "ViewReport", new object[]{});

				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				if (((TriState) Convert.ToInt32(rsMasterRecordset.Tables[0].Rows[0]["print_immediately_after_display"])) == TriState.True)
				{
					crrPrimaryReport.DisplayProgressDialog = true;
					crrPrimaryReport.PrintOut(Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
				}
				mReportInProcess = false;
			}
			catch (System.Exception excep)
			{

				MessageBox.Show(excep.Message, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
				CloseForm();
			}
		}

		private void GetReportOptions()
		{
			frmSysReportCrystalParameters oReportParameters = null;
			Keys mUserLastClikedButton = (Keys) 0;

			//On Error GoTo eFoundError

			clsHourGlass myHourGlass = new clsHourGlass();
			if (UserAccess.AllowUserUpdate)
			{
				oReportParameters = frmSysReportCrystalParameters.CreateInstance();

				oReportParameters.AttachObjects(this, this.rsMasterRecordset, this.rsDetailsRecordset);
				myHourGlass = null;
				//UPGRADE_WARNING: (7009) Multiple invocations to ShowDialog in Forms with ActiveX Controls might throw runtime exceptions More Information: https://docs.mobilize.net/vbuc/ewis#7009
				oReportParameters.ShowDialog();

				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				mUserLastClikedButton = (Keys) oReportParameters.LastButtonClicked;
				oReportParameters.Close();
				oReportParameters = null;

				//**--if user presses OK BUTTON then show the report
				//**--else close the report preview form
				if (mUserLastClikedButton == Keys.Cancel)
				{
					return;
				}
				SetReportData();
				GetReportData();
			}
		}

		public void SetParameterValues(string pParameterIDList, string pParameterValuesList)
		{
			int Cnt = 0;

			string[] aParameterIDList = pParameterIDList.Split(',');
			object aParameterValuesList = pParameterValuesList.Split(',');

			SetReportData();
			int tempForEndVar = aParameterIDList.GetUpperBound(0);
			for (Cnt = 0; Cnt <= tempForEndVar; Cnt++)
			{
				SetColumnFilterValue(Convert.ToInt32(Conversion.Val(aParameterIDList[Cnt])), ReflectionHelper.GetPrimitiveValue<string>(SystemReports.GetColumnInformation("column_id = " + Conversion.Str(aParameterIDList[Cnt]), "linked_parameter_name", rsDetailsRecordset)), ((Array) aParameterValuesList).GetValue(Cnt), true, true);
			}
		}

		public void SetColumnFilterValue(int pColumnID, string pColumnParameterName, object pFilterCondition, bool IsFromValue = true, bool pFilterAlreadyQuoted = false, bool pExpectInterpretedValue = false, string pUninterpretedFilterCondition = "")
		{
			string mFilterCondition = "";
			string mStringCharacter = "";
			string mFieldType = "";

			try
			{
				mFilterCondition = "";
				//UPGRADE_WARNING: (1068) GetColumnInformation() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mFieldType = ReflectionHelper.GetPrimitiveValue<string>(SystemReports.GetColumnInformation("column_id = " + Conversion.Str(pColumnID), "field_type", rsDetailsRecordset));
				if (mFieldType.ToUpper() == "C" && !pFilterAlreadyQuoted)
				{
					//mStringCharacter = "'"
					mStringCharacter = "";
				}
				else
				{
					mStringCharacter = "";
				}
				mFilterCondition = mStringCharacter + ReflectionHelper.GetPrimitiveValue<string>(pFilterCondition) + mStringCharacter;
				if (pExpectInterpretedValue)
				{
					SetColumnInformation(rsDetailsRecordset, "column_id = " + Conversion.Str(pColumnID), (IsFromValue) ? "default_from_value" : "default_to_value", pUninterpretedFilterCondition, "");
				}
				else
				{
					SetColumnInformation(rsDetailsRecordset, "column_id = " + Conversion.Str(pColumnID), (IsFromValue) ? "default_from_value" : "default_to_value", pFilterCondition, "");
				}

				if (pColumnParameterName != "")
				{
					if (mFilterCondition != "")
					{
						switch(mFieldType)
						{
							case "C" : 
								crrPrimaryReport.ParameterFields.GetItemByName(pColumnParameterName, Type.Missing).AddCurrentValue(mFilterCondition); 
								break;
							case "N" : 
								crrPrimaryReport.ParameterFields.GetItemByName(pColumnParameterName, Type.Missing).AddCurrentValue(Conversion.Val(mFilterCondition)); 
								break;
							case "L" : 
								bool tempBool = false; 
								crrPrimaryReport.ParameterFields.GetItemByName(pColumnParameterName, Type.Missing).AddCurrentValue((Boolean.TryParse(mFilterCondition, out tempBool)) ? tempBool : Convert.ToBoolean(Double.Parse(mFilterCondition))); 
								break;
							case "D" : 
								crrPrimaryReport.ParameterFields.GetItemByName(pColumnParameterName, Type.Missing).AddCurrentValue(DateTime.Parse(mFilterCondition)); 
								break;
							default:
								MessageBox.Show("Error: Invalid column type definition", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error); 
								Environment.Exit(0); 
								break;
						}
					}
					else
					{
						crrPrimaryReport.ParameterFields.GetItemByName(pColumnParameterName, Type.Missing).EnableNullValue = true;
						crrPrimaryReport.ParameterFields.GetItemByName(pColumnParameterName, Type.Missing).AddCurrentValue(null);
					}
				}
			}
			catch (System.Exception excep)
			{

				MessageBox.Show(excep.Message, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
				CloseForm();
			}
		}

		public void SetFilterValue(string pParameterType, string pParameterName, string pParameterValue)
		{
			string mFilterCondition = "";
			string mStringCharacter = "";

			try
			{
				mFilterCondition = "";
				if (pParameterType.ToUpper() == "C")
				{
					//mStringCharacter = "'"
					mStringCharacter = "";
				}
				else
				{
					mStringCharacter = "";
				}
				mFilterCondition = mStringCharacter + pParameterValue + mStringCharacter;

				if (pParameterName != "")
				{
					if (mFilterCondition != "")
					{
						switch(pParameterType)
						{
							case "C" : 
								crrPrimaryReport.ParameterFields.GetItemByName(pParameterName, Type.Missing).AddCurrentValue(mFilterCondition); 
								break;
							case "N" : 
								crrPrimaryReport.ParameterFields.GetItemByName(pParameterName, Type.Missing).AddCurrentValue(Conversion.Val(mFilterCondition)); 
								break;
							case "L" : 
								bool tempBool = false; 
								crrPrimaryReport.ParameterFields.GetItemByName(pParameterName, Type.Missing).AddCurrentValue((Boolean.TryParse(mFilterCondition, out tempBool)) ? tempBool : Convert.ToBoolean(Double.Parse(mFilterCondition))); 
								break;
							case "D" : 
								crrPrimaryReport.ParameterFields.GetItemByName(pParameterName, Type.Missing).AddCurrentValue(DateTime.Parse(StringsHelper.Replace(mFilterCondition, "'", "", 1, -1, CompareMethod.Binary))); 
								break;
							default:
								MessageBox.Show("Error: Invalid column type definition", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error); 
								Environment.Exit(0); 
								break;
						}
					}
					else
					{
						crrPrimaryReport.ParameterFields.GetItemByName(pParameterName, Type.Missing).EnableNullValue = true;
						crrPrimaryReport.ParameterFields.GetItemByName(pParameterName, Type.Missing).AddCurrentValue(null);
					}
				}
			}
			catch (System.Exception excep)
			{

				MessageBox.Show(excep.Message, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
				CloseForm();
			}
		}
		private void SetColumnInformation(DataSet prsDetailsRecordset, string SearchCondition, string ColumnToSet, object ValueToSet, string RecordFilter = "")
		{
			try
			{

				if (RecordFilter != "")
				{
					prsDetailsRecordset.Tables[0].DefaultView.RowFilter = RecordFilter;
				}
				prsDetailsRecordset.Find(SearchCondition);
				if (prsDetailsRecordset.Tables[0].Rows.Count != 0)
				{
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					//UPGRADE_ISSUE: (2064) ADODB.Field20 property Fields.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					prsDetailsRecordset.Tables[0].Rows[0][ColumnToSet].setValue(ReflectionHelper.GetPrimitiveValue(ValueToSet));
				}
				else
				{
					prsDetailsRecordset.Find(SearchCondition);
					//UPGRADE_ISSUE: (2064) ADODB.Recordset property prsDetailsRecordset.BOF was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					if (prsDetailsRecordset.Tables[0].Rows.Count != 0 && !prsDetailsRecordset.getBOF())
					{
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						//UPGRADE_ISSUE: (2064) ADODB.Field20 property Fields.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						prsDetailsRecordset.Tables[0].Rows[0][ColumnToSet].setValue(ReflectionHelper.GetPrimitiveValue(ValueToSet));
					}
				}
				//UPGRADE_ISSUE: (2064) ADODB.FilterGroupEnum property FilterGroupEnum.adFilterNone was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				prsDetailsRecordset.Tables[0].DefaultView.RowFilter = UpgradeStubs.ADODB_FilterGroupEnum.getadFilterNone();
			}
			catch (System.Exception excep)
			{
				MessageBox.Show(excep.Message, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
			}

		}

		//Private Sub DefineReportToolbar()
		//Dim ReportToolBar As CommandBar
		//Dim ButtonControl As CommandBarControl
		//
		//Call FormatReportToolbar
		//
		//Set ReportToolBar = tcbSystemReport.Add("Standard", xtpBarTop)
		//With ReportToolBar.Controls
		//    '**--Show report options
		//    Set ButtonControl = .Add(xtpControlButton, tbnReportOptions, "")
		//    With ButtonControl
		//        .BeginGroup = False
		//        .Caption = GetSystemLabel(.Id)
		//        .Enabled = True
		//        .IconId = 106
		//        .Visible = True
		//    End With
		//    '**--Show the report navigation buttons
		//    Set ButtonControl = .Add(xtpControlButton, tbnMoveFirstPage, "")
		//    With ButtonControl
		//        .BeginGroup = True
		//        .Caption = GetSystemLabel(.Id)
		//        .Enabled = True
		//        .IconId = 134
		//        .Visible = True
		//    End With
		//    Set ButtonControl = .Add(xtpControlButton, tbnMovePreviousPage, "")
		//    With ButtonControl
		//        .BeginGroup = False
		//        .Caption = GetSystemLabel(.Id)
		//        .Enabled = True
		//        .IconId = 135
		//        .Visible = True
		//    End With
		//    Set ButtonControl = .Add(xtpControlButton, tbnMoveNextPage, "")
		//    With ButtonControl
		//        .BeginGroup = False
		//        .Caption = GetSystemLabel(.Id)
		//        .Enabled = True
		//        .IconId = 136
		//        .Visible = True
		//    End With
		//    Set ButtonControl = .Add(xtpControlButton, tbnMoveLastPage, "")
		//    With ButtonControl
		//        .BeginGroup = False
		//        .Caption = GetSystemLabel(.Id)
		//        .Enabled = True
		//        .IconId = 137
		//        .Visible = True
		//    End With
		//    '**------------------------------------------------
		//    '**--Show report print options
		//    Set ButtonControl = .Add(xtpControlButton, tbnPrintReport, "")
		//    With ButtonControl
		//        .BeginGroup = True
		//        .Caption = GetSystemLabel(.Id)
		//        .Enabled = True
		//        .IconId = 131
		//        .Visible = True
		//    End With
		//    '**--Show report print setup dialog
		//    Set ButtonControl = .Add(xtpControlButton, tbnPageSetup, "")
		//    With ButtonControl
		//        .BeginGroup = False
		//        .Caption = GetSystemLabel(.Id)
		//        .Enabled = True
		//        .IconId = 140
		//        .Visible = True
		//    End With
		//    '**--Show report export option
		//    Set ButtonControl = .Add(xtpControlButton, tbnExportReport, "")
		//    With ButtonControl
		//        .BeginGroup = True
		//        .Caption = GetSystemLabel(.Id)
		//        .Enabled = True
		//        .IconId = 148
		//        .Visible = True
		//    End With
		//    '**--Show report zoom setting drop down setting options
		//    Set ButtonControl = .Add(xtpControlSplitButtonPopup, tbnZoomPreview, "")
		//    With ButtonControl
		//        .BeginGroup = False
		//        .Caption = GetSystemLabel(.Id)
		//        .Enabled = True
		//        .IconId = 107
		//        .Visible = True
		//
		//        Call DefineZoomToolMenu(ButtonControl)
		//    End With
		//    '**--Show report find string option
		//    Set ButtonControl = .Add(xtpControlButton, tbnFindText, "")
		//    With ButtonControl
		//        .BeginGroup = False
		//        .Caption = GetSystemLabel(.Id)
		//        .Enabled = True
		//        .IconId = 107
		//        .Visible = True
		//    End With
		//     '**--Show report save setting option
		//    Set ButtonControl = .Add(xtpControlButton, tbnSaveReport, "")
		//    With ButtonControl
		//        .BeginGroup = False
		//        .Caption = GetSystemLabel(.Id)
		//        .Enabled = True
		//        .IconId = 102
		//        .Visible = True
		//    End With
		//    '**--Show report help
		//    Set ButtonControl = .Add(xtpControlButton, tbnHelp, "")
		//    With ButtonControl
		//        .BeginGroup = False
		//        .Caption = GetSystemLabel(.Id)
		//        .Enabled = True
		//        .IconId = 129
		//        .Visible = True
		//    End With
		//    '**--Show report exit option
		//    Set ButtonControl = .Add(xtpControlButton, tbnExit, "")
		//    With ButtonControl
		//        .BeginGroup = True
		//        .Caption = GetSystemLabel(.Id)
		//        .Enabled = True
		//        .IconId = 150
		//        .Visible = True
		//    End With
		//End With
		//With tcbSystemReport
		//    .Item(1).ModifyStyle XTP_CBRS_GRIPPER, XTP_CBRS_GRIPPER
		//    .RecalcLayout
		//End With
		//
		//'tcbSystemReport.KeyBindings.Add MenuCtrlKey, Asc("R"), tbnDrillDown
		//End Sub

		//Private Sub FormatReportToolbar()
		//With tcbSystemReport
		//    .GlobalSettings.App = App
		//    With .StatusBar
		//'        .AddPane (mStatusReportProgress)
		//'        .AddPane (mStatusRecordCount)
		//
		//        .Visible = False
		//    End With
		//    .ActiveMenuBar.Visible = False
		//    .EnableCustomization (False)
		//    .Icons = frmSysMain.imlStandardIcons.Icons
		//    With .Options
		//        .AltDragCustomization = False
		//        .AlwaysShowFullMenus = True
		//        .Animation = xtpAnimateFade
		//        .IconsWithShadow = False
		//        .LargeIcons = False
		//        .LunaColors = True
		//        .ShowExpandButtonAlways = True
		//        .ShowTextBelowIcons = True
		//        .ToolBarAccelTips = True
		//    End With
		//    .VisualTheme = xtpThemeOffice2003
		//
		//    .ActiveMenuBar.ModifyStyle &H400000, 0
		//    '**--Prevent docking
		//    .ActiveMenuBar.EnableDocking xtpFlagStretched
		//    .ActiveMenuBar.Controls.DeleteAll
		//    .ActiveMenuBar.Customizable = False
		//End With
		//End Sub
		//
		//Private Sub tcbSystemReport_Execute(ByVal Control As XtremeCommandBars.ICommandBarControl)
		//Static mSearchText As String
		//Dim myHourGlass As clsHourGlass
		//
		//Set myHourGlass = New clsHourGlass
		//If mReportInProcess = True Then
		//    Exit Sub
		//End If
		//
		//If Val(Control.Parameter) <> 0 Then
		//    crvReportDesign.Zoom Val(Control.Parameter)
		//Else
		//    Select Case Control.Id
		//        Case tbnReportOptions
		//            Call GetReportOptions
		//        Case tbnMoveFirstPage
		//            crvReportDesign.ShowFirstPage
		//        Case tbnMovePreviousPage
		//            crvReportDesign.ShowPreviousPage
		//        Case tbnMoveNextPage
		//            crvReportDesign.ShowNextPage
		//        Case tbnMoveLastPage
		//            crvReportDesign.ShowLastPage
		//        Case tbnPrintReport
		//            crvReportDesign.PrintReport
		//        Case tbnPageSetup
		//            GetPageSetup (1)
		//        Case tbnExportReport
		//            With crrPrimaryReport
		//'                .ExportOptions.DestinationType = crEDTDiskFile
		//'                .ExportOptions.FormatType = crEFTExcel97
		//'                .ExportOptions.DiskFileName = ""
		//                .Export
		//            End With
		//        Case tbnZoomPreview
		//            'Call mnuReportToolbar_ToolDropDown(Tool, Screen.TwipsPerPixelX * mnuReportToolbar.ToolBars(mMainToolBarName).Tools(tbnZoomPreview).Left, (Screen.TwipsPerPixelY * mnuReportToolbar.ToolBars(mMainToolBarName).Tools(tbnZoomPreview).Top) + (Screen.TwipsPerPixelY * mnuReportToolbar.ToolBars(mMainToolBarName).Tools(tbnZoomPreview).Height) + 800)
		//        Case tbnFindText
		//            mSearchText = InputBox("Enter Text to Find", "", mSearchText)
		//            If Not IsItEmpty(mSearchText, StringType) Then
		//                crvReportDesign.SearchForText mSearchText
		//            End If
		//        Case tbnSaveReport
		//            Call SaveReportDefinition
		//
		//        Case tbnHelp
		//            If gMISuperUser = True Then
		//                Call OpenCrystalRPTFile
		//            End If
		//
		//        Case tbnExit
		//            Call CloseForm
		//        Case Else
		//            MsgBox "Error: Menu item not found", vbCritical
		//    End Select
		//End If
		//End Sub

		//Private Sub OpenCrystalRPTFile()
		//'Dim mFileName As String
		//'
		//'If gPreferedLanguage = English Then
		//'    mFileName = AppPath(App.Path) & gReportFilesFolder & "\" & rsMasterRecordset("external_report_file_name").Value
		//'Else
		//'    mFileName = AppPath(App.Path) & gReportFilesFolder & "\" & rsMasterRecordset("external_report_file_name").Value
		//'End If
		//'
		//'Close #1
		//'Open mFileName For Output As #1
		//'
		//
		//
		//End Sub

		private void OpenCrystalRPTFile()
		{

			string mFileName = "";

			if (SystemVariables.gPreferedLanguage == SystemVariables.Language.English)
			{
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				mFileName = SystemProcedure2.AppPath(Path.GetDirectoryName(Application.ExecutablePath)) + SystemVariables.gReportFilesFolder + "\\" + Convert.ToString(rsMasterRecordset.Tables[0].Rows[0]["external_report_file_name"]);
			}
			else
			{
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				mFileName = SystemProcedure2.AppPath(Path.GetDirectoryName(Application.ExecutablePath)) + SystemVariables.gReportFilesFolder + "\\" + Convert.ToString(rsMasterRecordset.Tables[0].Rows[0]["a_external_report_file_name"]);
			}

			int hWnd = InnovaUpdSupport.PInvoke.SafeNative.user32.apiFindWindow("OPUSAPP", "0");

			int StartDoc = InnovaUpdSupport.PInvoke.SafeNative.shell32.ShellExecute(hWnd, "open", mFileName, "", "C:\\", (int) SystemAPI.SW_SHOWNORMAL);
		}


		private int GetPageSetup(int pDialogType = 1)
		{
			int result = 0;
			try
			{

				//**-- return 0 : if cancled by user
				//**-- return 1 : if ok button pressed (with changes)
				//**-- return 2 : if ok button pressed (with changes)

				string mOldDevice = "";
				VSPrinter8Lib.PaperSizeSettings mOldPaperSize = (VSPrinter8Lib.PaperSizeSettings) 0;
				VSPrinter8Lib.OrientationSettings mOldOrientation = VSPrinter8Lib.OrientationSettings.orPortrait;
				int mOldMarginLeft = 0;
				int mOldMarginTop = 0;
				int mOldMarginRight = 0;
				int mOldMarginBottom = 0;

				//-----------------------------------------------------------------------------------------------------------
				//''''----------------------------Page Setup from database-----Added By Moiz Hakimi---------29-july-09--------
				//-----------------------------------------------------------------------------------------------------------
				mOldDevice = crrPrimaryReport.PrinterName;
				//UPGRADE_WARNING: (6021) Casting 'CRAXDDRT.CRPaperSize' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				mOldPaperSize = (VSPrinter8Lib.PaperSizeSettings) crrPrimaryReport.PaperSize;
				//UPGRADE_WARNING: (6021) Casting 'CRAXDDRT.CRPaperOrientation' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				mOldOrientation = (VSPrinter8Lib.OrientationSettings) crrPrimaryReport.PaperOrientation;
				mOldMarginLeft = crrPrimaryReport.LeftMargin;
				mOldMarginTop = crrPrimaryReport.TopMargin;
				mOldMarginRight = crrPrimaryReport.RightMargin;
				mOldMarginBottom = crrPrimaryReport.BottomMargin;


				crrPrimaryReport.PrinterSetup(0);

				//page setup options
				//If pDialogType = 1 Then
				//    If crrPrimaryReport.PrinterSetup(0) = vbTrue Then
				//        GetPageSetup = 2
				//    Else
				//       GetPageSetup = 0
				//    End If
				//ElseIf pDialogType = 2 Then
				//    If crrPrimaryReport.PrinterSetup(1) = vbTrue Then
				//        GetPageSetup = 2
				//    Else
				//        GetPageSetup = 0
				//    End If
				//End If
				//
				//If GetPageSetup = 2 Then
				//**--check if the settings are changed ; otherwise return false
				//-----------------------------------------------------------------------------------------------------------
				//''''----------------------------Page Setup from database-----Added By Moiz Hakimi---------24-Feb-11--------
				//-----------------------------------------------------------------------------------------------------------
				//UPGRADE_ISSUE: (2064) ADODB.Field20 property rsMasterRecordset.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				rsMasterRecordset.Tables[0].Rows[0]["MarginTop"].Value = crrPrimaryReport.TopMargin;
				//UPGRADE_ISSUE: (2064) ADODB.Field20 property rsMasterRecordset.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				rsMasterRecordset.Tables[0].Rows[0]["MarginBottom"].Value = crrPrimaryReport.BottomMargin;
				//UPGRADE_ISSUE: (2064) ADODB.Field20 property rsMasterRecordset.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				rsMasterRecordset.Tables[0].Rows[0]["MarginLeft"].Value = crrPrimaryReport.LeftMargin;
				//UPGRADE_ISSUE: (2064) ADODB.Field20 property rsMasterRecordset.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				rsMasterRecordset.Tables[0].Rows[0]["MarginRight"].Value = crrPrimaryReport.RightMargin;
				//UPGRADE_ISSUE: (2064) ADODB.Field20 property rsMasterRecordset.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				rsMasterRecordset.Tables[0].Rows[0]["PrintDevice"].Value = crrPrimaryReport.PrinterName;
				//UPGRADE_ISSUE: (2064) ADODB.Field20 property rsMasterRecordset.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				rsMasterRecordset.Tables[0].Rows[0]["PaperSize"].Value = (int) crrPrimaryReport.PaperSize;
				//UPGRADE_ISSUE: (2064) ADODB.Field20 property rsMasterRecordset.Value was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				rsMasterRecordset.Tables[0].Rows[0]["Orientation"].Value = (int) crrPrimaryReport.PaperOrientation;
				//-----------------------------------------------------------------------------------------------------------
				//-----------------------------------------------------------------------------------------------------------
				if (mOldDevice == crrPrimaryReport.PrinterName && ((int) mOldPaperSize) == ((int) crrPrimaryReport.PaperSize) && ((int) mOldOrientation) == ((int) crrPrimaryReport.PaperOrientation) && mOldMarginLeft == crrPrimaryReport.LeftMargin && mOldMarginTop == crrPrimaryReport.TopMargin && mOldMarginRight == crrPrimaryReport.RightMargin && mOldMarginBottom == crrPrimaryReport.BottomMargin)
				{
					result = 1;
				}
				//End If
				//DoEvents
				ReflectionHelper.Invoke(this.crvReportDesign, "RefreshEx", new object[]{false});
			}
			catch (System.Exception excep)
			{
				MessageBox.Show(excep.Message, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
			}
			return result;
		}

		private void RefreshRebbonBar()
		{

			XtremeCommandBars.RibbonBar withVar = null;
			withVar = frmSysMain.DefInstance.RibbonBar();
			withVar.FindControl(Type.Missing, SystemConstants.tbnZoomPreview, Type.Missing, Type.Missing).Enabled = true;
			withVar.FindControl(Type.Missing, SystemConstants.tbnDrillDown, Type.Missing, Type.Missing).Visible = false;
			withVar.FindControl(Type.Missing, SystemConstants.tbnDrillUp, Type.Missing, Type.Missing).Visible = false;
			withVar.FindControl(Type.Missing, SystemConstants.tbnNormalMode, Type.Missing, Type.Missing).Visible = false;
			withVar.FindControl(Type.Missing, SystemConstants.tbnPreivewMode, Type.Missing, Type.Missing).Visible = false;
			withVar.FindControl(Type.Missing, SystemConstants.tbnHelp, Type.Missing, Type.Missing).Visible = SystemVariables.gMISuperUser;

		}

		string mSearchText_ToolBarButtonClick = "";
		public void ToolBarButtonClick(int KeyIndex)
		{
			try
			{
				clsHourGlass myHourGlass = null;

				myHourGlass = new clsHourGlass();
				if (mReportInProcess)
				{
					return;
				}
				switch(KeyIndex)
				{
					case SystemConstants.tbnReportOptions : 
						GetReportOptions(); 
						break;
					case SystemConstants.tbnPrintReport : 
						ReflectionHelper.Invoke(crvReportDesign, "PrintReport", new object[]{}); 
						break;
					case SystemConstants.tbnPageSetup : 
						GetPageSetup(1); 
						break;
					case SystemConstants.tbnExportReport : 
						crrPrimaryReport.Export(Type.Missing); 
						break;
					case SystemConstants.tbnFindText : 
						break;
					//UPGRADE_NOTE: (7001) The following case (switch) seems to be dead code More Information: https://docs.mobilize.net/vbuc/ewis#7001
					//case SystemConstants.tbnFindText : 
						//mSearchText_ToolBarButtonClick = InputBoxHelper.InputBox("Enter Text to Find", "", mSearchText_ToolBarButtonClick); 
						//if (!SystemProcedure2.IsItEmpty(mSearchText_ToolBarButtonClick, SystemVariables.DataType.StringType))
						//{
							//ReflectionHelper.Invoke(crvReportDesign, "SearchForText", new object[]{mSearchText_ToolBarButtonClick});
						//} 
						//break;
					case SystemConstants.tbnSaveReport : 
						SaveReportDefinition(); 
						break;
					case SystemConstants.tbnMoveFirstPage : 
						ReflectionHelper.Invoke(crvReportDesign, "ShowFirstPage", new object[]{}); 
						 
						break;
					case SystemConstants.tbnMovePreviousPage : 
						ReflectionHelper.Invoke(crvReportDesign, "ShowPreviousPage", new object[]{}); 
						 
						break;
					case SystemConstants.tbnMoveNextPage : 
						ReflectionHelper.Invoke(crvReportDesign, "ShowNextPage", new object[]{}); 
						 
						break;
					case SystemConstants.tbnMoveLastPage : 
						ReflectionHelper.Invoke(crvReportDesign, "ShowLastPage", new object[]{}); 
						 
						break;
					case SystemConstants.tbnZoomPreview25 : 
						ReflectionHelper.Invoke(crvReportDesign, "Zoom", new object[]{25}); 
						 
						break;
					case SystemConstants.tbnZoomPreview50 : 
						ReflectionHelper.Invoke(crvReportDesign, "Zoom", new object[]{50}); 
						 
						break;
					case SystemConstants.tbnZoomPreview75 : 
						ReflectionHelper.Invoke(crvReportDesign, "Zoom", new object[]{75}); 
						 
						break;
					case SystemConstants.tbnZoomPreview100 : 
						ReflectionHelper.Invoke(crvReportDesign, "Zoom", new object[]{100}); 
						 
						break;
					case SystemConstants.tbnZoomPreview125 : 
						ReflectionHelper.Invoke(crvReportDesign, "Zoom", new object[]{125}); 
						 
						break;
					case SystemConstants.tbnZoomPreview150 : 
						ReflectionHelper.Invoke(crvReportDesign, "Zoom", new object[]{150}); 
						 
						break;
					case SystemConstants.tbnZoomPreview200 : 
						ReflectionHelper.Invoke(crvReportDesign, "Zoom", new object[]{200}); 
						 
						break;
					case SystemConstants.tbnZoomPreview300 : 
						ReflectionHelper.Invoke(crvReportDesign, "Zoom", new object[]{300}); 
						 
						break;
					case SystemConstants.tbnZoomPreview400 : 
						ReflectionHelper.Invoke(crvReportDesign, "Zoom", new object[]{400}); 
						 
						break;
					case SystemConstants.tbnHelp : 
						if (SystemVariables.gMISuperUser)
						{
							OpenCrystalRPTFile();
						} 
						break;
					case SystemConstants.tbnExit : 
						CloseForm(); 
						break;
				}
			}
			catch (System.Exception excep)
			{
				MessageBox.Show(excep.Message, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
			}

		}

		private void SystemReportKeyDown(frmSysCRYSTALDesign pForm, ref Keys pKeyCode, int pShift)
		{
			try
			{

				if (pShift == 2)
				{
					if (pKeyCode == Keys.R)
					{
						//**--Drill-Down Button (Ctrl+R)
						ToolBarButtonClick(SystemConstants.tbnDrillDown);
						//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
						pKeyCode = (Keys) 0;
					}
					else if (pKeyCode == Keys.U)
					{ 
						//**--Drill-Up Button (Ctrl+U)
						ToolBarButtonClick(SystemConstants.tbnDrillUp);
						//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
						pKeyCode = (Keys) 0;
					}
					else if (pKeyCode == Keys.O)
					{ 
						//**--Options Button (Ctrl+O)
						ToolBarButtonClick(SystemConstants.tbnReportOptions);
						//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
						pKeyCode = (Keys) 0;
					}
					else if (pKeyCode == Keys.N)
					{ 
						//**--Normal Mode (Ctrl+N)
						ToolBarButtonClick(SystemConstants.tbnNormalMode);
						//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
						pKeyCode = (Keys) 0;
					}
					else if (pKeyCode == Keys.W)
					{ 
						//**--Preview Mode (Ctrl+W)
						ToolBarButtonClick(SystemConstants.tbnPreivewMode);
						//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
						pKeyCode = (Keys) 0;
					}
					else if (pKeyCode == Keys.P)
					{ 
						//**--Print Report (Ctrl+P)
						ToolBarButtonClick(SystemConstants.tbnPrintReport);
						//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
						pKeyCode = (Keys) 0;
					}
					else if (pKeyCode == Keys.T)
					{ 
						//**--Page Setup (Ctrl+T)
						ToolBarButtonClick(SystemConstants.tbnPageSetup);
						//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
						pKeyCode = (Keys) 0;
					}
					else if (pKeyCode == Keys.X)
					{ 
						//**--Export Routine (Ctrl+X)
						ToolBarButtonClick(SystemConstants.tbnExportReport);
						//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
						pKeyCode = (Keys) 0;
					}
					else if (pKeyCode == Keys.F)
					{ 
						//**--Find Row Routinue (Ctrl+F)
						ToolBarButtonClick(SystemConstants.tbnFindText);
						//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
						pKeyCode = (Keys) 0;
					}
					else if (pKeyCode == Keys.S)
					{ 
						//**--Save Report Templet (Ctrl+S)
						ToolBarButtonClick(SystemConstants.tbnSaveReport);
						//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
						pKeyCode = (Keys) 0;
					}
					else if (pKeyCode == Keys.H)
					{ 
						//**--Help (Ctrl+H)
						ToolBarButtonClick(SystemConstants.tbnHelp);
						//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
						pKeyCode = (Keys) 0;
					}
					else if (pKeyCode == Keys.E)
					{ 
						//**--Exit Report (Ctrl+E)
						ToolBarButtonClick(SystemConstants.tbnExit);
						//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
						pKeyCode = (Keys) 0;
					}
				}
				else if (pShift == 0)
				{ 
					if (pKeyCode == Keys.Escape)
					{ //Escape key
						ToolBarButtonClick(SystemConstants.tbnExit);
						//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
						pKeyCode = (Keys) 0;
					}
					else
					{
					}
				}
			}
			catch (System.Exception excep)
			{
				MessageBox.Show(excep.Message, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
			}

		}
	}
}