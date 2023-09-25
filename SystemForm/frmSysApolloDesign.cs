
using System;
using System.Windows.Forms;



namespace Xtreme
{
	internal partial class frmSysApolloDesign
		: System.Windows.Forms.Form
	{

		public frmSysApolloDesign()
{
InitializeComponent();
} 
 public  void frmSysApolloDesign_old()
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


		private void frmSysApolloDesign_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (UpgradeHelpers.Gui.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Gui.ActivateHelper.myActiveForm = (System.Windows.Forms.Form) eventSender;
			}
		}
		public int mReportId = 0;

		private const int tbnNormalMode = 458;
		private const int tbnPreivewMode = 539;
		private const int tbnPrintReport = 541;
		private const int tbnPageSetup = 707;
		private const int tbnExportReport = 266;
		private const int tbnFindText = 276;
		private const int tbnHelp = 308;
		private const int tbnExit = 261;

		private string mUid = "";
		private string mPwd = "";

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2080
		private void Form_Load()
		{
			try
			{
				string mReportUrl = "";

				this.Top = 0;
				this.Left = 0;
				this.Width = Convert.ToInt32(frmSysMain.DefInstance.oSystemInformation.WorkAreaWidth - 100) / 15;

				if (frmSysMain.DefInstance.oSystemInformation.OSVersion > 5)
				{
					this.Height = Convert.ToInt32(frmSysMain.DefInstance.oSystemInformation.WorkAreaHeight / 15 - (frmSysMain.DefInstance.Height - frmSysMain.DefInstance.ClientRectangle.Height));
				}
				else
				{
					this.Height = Convert.ToInt32(frmSysMain.DefInstance.oSystemInformation.WorkAreaHeight / 15 - (frmSysMain.DefInstance.Height - frmSysMain.DefInstance.ClientRectangle.Height));
				}
				if (SystemVariables.gPreferedLanguage == SystemVariables.Language.Arabic)
				{
					this.RightToLeft = RightToLeft.Yes;
				}

				DefineReportToolbar();
				DoFormatReportDesign();

				//If gLoggedInUserGroupCode = gDefaultAdminGroupCode Then
				mUid = "admin";
				mPwd = "123";
				//Else
				//    mUid = gLoggedInUserID
				//    mPwd = GetMasterCode("select Password from user where user_id = '" & gLoggedInUserID & "'")
				//End If

				//UPGRADE_WARNING: (1068) GetSystemPreferenceSetting() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReportUrl = ReflectionHelper.GetPrimitiveValue<string>(SystemProcedure2.GetSystemPreferenceSetting("Apollo_url"));
				WebBrowser1.Navigate(new Uri(mReportUrl + "security/login?Uid=" + mUid + "&pwd=" + mPwd + "&returnurl=/reports/reportviewer.aspx?reportid=" + mReportId.ToString()));
				this.Show();
				Application.DoEvents();
				//**-------------------------------------------------------------------------------------------
			}
			catch (System.Exception excep)
			{

				MessageBox.Show(excep.Message, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
			}

		}


		private void DoFormatReportDesign()
		{
			int mToolBarLeft = 0;
			int mToolBarTop = 0;
			int mToolBarRight = 0;
			int mToolBarBottom = 0;

			tcbSystemReport.GetClientRect(out mToolBarLeft, out mToolBarTop, out mToolBarRight, out mToolBarBottom);

			WebBrowser1.Left = 0;
			WebBrowser1.Top = mToolBarTop / 15;
			WebBrowser1.Width = this.ClientRectangle.Width;
			WebBrowser1.Height = this.ClientRectangle.Height - WebBrowser1.Top;
			WebBrowser1.Visible = true;

			//If gPreferedLanguage = English Then
			//    Me.Caption = rsMasterRecordset("l_report_name").Value & ""
			//Else
			//    Me.Caption = rsMasterRecordset("a_report_name").Value & ""
			//End If
		}

		private void DefineReportToolbar()
		{
			XtremeCommandBars.CommandBarControl ButtonControl = null;

			FormatReportToolbar();

			XtremeCommandBars.CommandBar ReportToolBar = (XtremeCommandBars.CommandBar) tcbSystemReport.Add("Standard", XtremeCommandBars.XTPBarPosition.xtpBarTop);
			XtremeCommandBars.ICommandBarControls withVar = null;
			withVar = ReportToolBar.Controls;

			//**------------------------------------------------
			//**--Show report print Preview
			ButtonControl = (XtremeCommandBars.CommandBarControl) withVar.Add(XtremeCommandBars.XTPControlType.xtpControlButton, tbnNormalMode, "", Type.Missing, Type.Missing);
			ButtonControl.BeginGroup = true;
			ButtonControl.Caption = SystemProcedure2.GetSystemLabel(ButtonControl.Id);
			ButtonControl.Enabled = false;
			ButtonControl.IconId = 149;
			ButtonControl.Visible = true;
			//**------------------------------------------------
			//**--Show report print Preview
			ButtonControl = (XtremeCommandBars.CommandBarControl) withVar.Add(XtremeCommandBars.XTPControlType.xtpControlButton, tbnPreivewMode, "", Type.Missing, Type.Missing);
			ButtonControl.BeginGroup = false;
			ButtonControl.Caption = SystemProcedure2.GetSystemLabel(ButtonControl.Id);
			ButtonControl.Enabled = true;
			ButtonControl.IconId = 147;
			ButtonControl.Visible = true;
			//**------------------------------------------------
			//**--Show report print options
			ButtonControl = (XtremeCommandBars.CommandBarControl) withVar.Add(XtremeCommandBars.XTPControlType.xtpControlButton, tbnPrintReport, "", Type.Missing, Type.Missing);
			ButtonControl.BeginGroup = true;
			ButtonControl.Caption = SystemProcedure2.GetSystemLabel(ButtonControl.Id);
			ButtonControl.Enabled = false;
			ButtonControl.IconId = 131;
			ButtonControl.Visible = true;
			//**--Show report print setup dialog
			ButtonControl = (XtremeCommandBars.CommandBarControl) withVar.Add(XtremeCommandBars.XTPControlType.xtpControlButton, tbnPageSetup, "", Type.Missing, Type.Missing);
			ButtonControl.BeginGroup = false;
			ButtonControl.Caption = SystemProcedure2.GetSystemLabel(ButtonControl.Id);
			ButtonControl.Enabled = false;
			ButtonControl.IconId = 140;
			ButtonControl.Visible = true;
			//**--Show report export option
			//    Set ButtonControl = .Add(xtpControlButton, tbnExportReport, "")
			//    With ButtonControl
			//        .BeginGroup = True
			//        .Caption = GetSystemLabel(.Id)
			//        .Enabled = True
			//        .IconId = 148
			//        .Visible = True
			//    End With

			//**--Show report find string option
			ButtonControl = (XtremeCommandBars.CommandBarControl) withVar.Add(XtremeCommandBars.XTPControlType.xtpControlButton, tbnFindText, "", Type.Missing, Type.Missing);
			ButtonControl.BeginGroup = false;
			ButtonControl.Caption = SystemProcedure2.GetSystemLabel(ButtonControl.Id);
			ButtonControl.Enabled = true;
			ButtonControl.IconId = 107;
			ButtonControl.Visible = true;

			//**--Show report help
			ButtonControl = (XtremeCommandBars.CommandBarControl) withVar.Add(XtremeCommandBars.XTPControlType.xtpControlButton, tbnHelp, "", Type.Missing, Type.Missing);
			ButtonControl.BeginGroup = false;
			ButtonControl.Caption = SystemProcedure2.GetSystemLabel(ButtonControl.Id);
			ButtonControl.Enabled = true;
			ButtonControl.IconId = 129;
			ButtonControl.Visible = true;
			//**--Show report exit option
			ButtonControl = (XtremeCommandBars.CommandBarControl) withVar.Add(XtremeCommandBars.XTPControlType.xtpControlButton, tbnExit, "", Type.Missing, Type.Missing);
			ButtonControl.BeginGroup = true;
			ButtonControl.Caption = SystemProcedure2.GetSystemLabel(ButtonControl.Id);
			ButtonControl.Enabled = true;
			ButtonControl.IconId = 150;
			ButtonControl.Visible = true;
			tcbSystemReport[1].ModifyStyle(XtremeCommandBars.XTPCommandBarStyle.XTP_CBRS_GRIPPER, XtremeCommandBars.XTPCommandBarStyle.XTP_CBRS_GRIPPER);
			tcbSystemReport.RecalcLayout();

			//tcbSystemReport.KeyBindings.Add MenuCtrlKey, Asc("R"), tbnDrillDown
		}


		private void FormatReportToolbar()
		{
			XtremeCommandBars.IStatusBar withVar = null;
			XtremeCommandBars.ICommandBarsOptions withVar_2 = null;
			//UPGRADE_ISSUE: (2064) VB method VB.Global was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			//UPGRADE_ISSUE: (2070) Constant App was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2070
			//UPGRADE_WARNING: (1068) tcbSystemReport.GlobalSettings.App of type object is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			ReflectionHelper.SetPrimitiveValue(tcbSystemReport.GlobalSettings.App, UpgradeStubs.VB.getGlobal().getApp());
			withVar = tcbSystemReport.StatusBar;
			//        .AddPane (mStatusReportProgress)
			//        .AddPane (mStatusRecordCount)

			withVar.Visible = false;
			tcbSystemReport.ActiveMenuBar.Visible = false;
			tcbSystemReport.EnableCustomization(false);
			tcbSystemReport.Icons = frmSysMain.DefInstance.imlStandardIcons.Icons;
			withVar_2 = tcbSystemReport.Options;
			withVar_2.AltDragCustomization = false;
			withVar_2.AlwaysShowFullMenus = true;
			withVar_2.Animation = XtremeCommandBars.XTPAnimationType.xtpAnimateFade;
			withVar_2.IconsWithShadow = false;
			withVar_2.LargeIcons = false;
			withVar_2.LunaColors = true;
			withVar_2.ShowExpandButtonAlways = true;
			withVar_2.ShowTextBelowIcons = true;
			withVar_2.ToolBarAccelTips = true;
			tcbSystemReport.VisualTheme = XtremeCommandBars.XTPVisualTheme.xtpThemeOffice2003;

			//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
			tcbSystemReport.ActiveMenuBar.ModifyStyle((XtremeCommandBars.XTPCommandBarStyle) 0x400000, (XtremeCommandBars.XTPCommandBarStyle) 0);
			//**--Prevent docking
			tcbSystemReport.ActiveMenuBar.EnableDocking(XtremeCommandBars.XTPToolBarFlags.xtpFlagStretched);
			tcbSystemReport.ActiveMenuBar.Controls.DeleteAll();
			tcbSystemReport.ActiveMenuBar.Customizable = false;
		}


		string mSearchText_tcbSystemReport_Execute = "";
		private void tcbSystemReport_Execute(Object eventSender, AxXtremeCommandBars._DCommandBarsEvents_ExecuteEvent eventArgs)
		{
			object crvReportDesign = null;
			bool mReportInProcess = false;

			clsHourGlass myHourGlass = new clsHourGlass();
			if (mReportInProcess)
			{
				return;
			}

			if (Conversion.Val(eventArgs.control.Parameter) != 0)
			{
				ReflectionHelper.Invoke(crvReportDesign, "Zoom", new object[]{Conversion.Val(eventArgs.control.Parameter)});
			}
			else
			{
				switch(eventArgs.control.Id)
				{
					case tbnNormalMode : 
						ShowNormal(); 
						break;
					case tbnPreivewMode : 
						ShowPreview(); 
						break;
					case tbnPrintReport : 
						PrintReport(); 
						break;
					case tbnPageSetup : 
						PageSetup(); 
						break;
					case tbnExportReport : 
						//            With crrPrimaryReport 
						// 
						//                .Export 
						//            End With 
						break;
					case tbnFindText : 
						FindText(); 
						break;
					case tbnHelp : 
						 
						break;
					case tbnExit : 
						CloseForm(); 
						break;
					default:
						MessageBox.Show("Error: Menu item not found", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error); 
						break;
				}
			}
		}

		public void CloseForm()
		{
			this.Close();
		}
		public void ShowNormal()
		{
			object ButtonControl = null;

			WebBrowser1.GoBack();

			tcbSystemReport.FindControl(ButtonControl, tbnPrintReport, Type.Missing, Type.Missing).Enabled = false;
			tcbSystemReport.FindControl(ButtonControl, tbnPageSetup, Type.Missing, Type.Missing).Enabled = false;
			tcbSystemReport.FindControl(ButtonControl, tbnNormalMode, Type.Missing, Type.Missing).Enabled = false;

			tcbSystemReport.FindControl(ButtonControl, tbnPreivewMode, Type.Missing, Type.Missing).Enabled = true;
		}

		public void ShowPreview()
		{
			object ButtonControl = null;
			// click on Print report button
			ReflectionHelper.Invoke(ReflectionHelper.Invoke(ReflectionHelper.GetMember(WebBrowser1.Document.DomDocument, "All"), "Item", new object[]{"printReport"}), "Click", new object[]{});

			tcbSystemReport.FindControl(ButtonControl, tbnPrintReport, Type.Missing, Type.Missing).Enabled = true;
			tcbSystemReport.FindControl(ButtonControl, tbnPageSetup, Type.Missing, Type.Missing).Enabled = true;
			tcbSystemReport.FindControl(ButtonControl, tbnNormalMode, Type.Missing, Type.Missing).Enabled = true;

			tcbSystemReport.FindControl(ButtonControl, tbnPreivewMode, Type.Missing, Type.Missing).Enabled = false;

		}

		public void PrintReport()
		{
			//UPGRADE_ISSUE: (2070) Constant OLECMDEXECOPT_PROMPTUSER was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2070
			//UPGRADE_ISSUE: (2070) Constant OLECMDID_PRINT was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2070
			//UPGRADE_ISSUE: (2064) SHDocVw.WebBrowser method WebBrowser1.ExecWB was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			WebBrowser1.ExecWB(UpgradeStubs.SHDocVw_OLECMDID.getOLECMDID_PRINT(), UpgradeStubs.SHDocVw_OLECMDEXECOPT.getOLECMDEXECOPT_PROMPTUSER(), 0, 0);
		}

		public void PageSetup()
		{
			//UPGRADE_ISSUE: (2070) Constant OLECMDEXECOPT_PROMPTUSER was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2070
			//UPGRADE_ISSUE: (2070) Constant OLECMDID_PAGESETUP was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2070
			//UPGRADE_ISSUE: (2064) SHDocVw.WebBrowser method WebBrowser1.ExecWB was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			WebBrowser1.ExecWB(UpgradeStubs.SHDocVw_OLECMDID.getOLECMDID_PAGESETUP(), UpgradeStubs.SHDocVw_OLECMDEXECOPT.getOLECMDEXECOPT_PROMPTUSER(), 0, 0);
		}

		public void FindText()
		{
			//UPGRADE_ISSUE: (2070) Constant OLECMDEXECOPT_PROMPTUSER was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2070
			//UPGRADE_ISSUE: (2070) Constant OLECMDID_FIND was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2070
			//UPGRADE_ISSUE: (2064) SHDocVw.WebBrowser method WebBrowser1.ExecWB was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			WebBrowser1.ExecWB(UpgradeStubs.SHDocVw_OLECMDID.getOLECMDID_FIND(), UpgradeStubs.SHDocVw_OLECMDEXECOPT.getOLECMDEXECOPT_PROMPTUSER(), 0, 0);
		}
		private void Form_Closed(Object eventSender, EventArgs eventArgs)
		{
		}
	}
}