using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace Xtreme
{
	internal partial class frmSysDashboard
		: System.Windows.Forms.Form
	{

		public frmSysDashboard()
{
InitializeComponent();
} 
 public  void frmSysDashboard_old()
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


		private void frmSysDashboard_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (UpgradeHelpers.Gui.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Gui.ActivateHelper.myActiveForm = (System.Windows.Forms.Form) eventSender;
			}
		}

		private frmSysReportDesign[] oReportForm = new frmSysReportDesign[10];
		private DataSet rsDashboard = null;

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2080
		private void Form_Load()
		{
			int cnt = 0;
			clsHourGlass myHourGlass = new clsHourGlass();
			XtremeDockingPane.Pane p = null;

			this.WindowState = FormWindowState.Maximized;

			if (DockingPaneManager.PanesCount > 0)
			{
				DockingPaneManager.DestroyAll();
			}

			string mysql = "select R.report_id as Report_Id, R.L_Report_Name as Report_Name";
			mysql = mysql + " from SM_User_Dashboard DB inner join SM_Reports R";
			mysql = mysql + " on DB.Report_Id = R.Report_Id Where DB.User_cd = " + SystemVariables.gLoggedInUserCode.ToString();

			rsDashboard = new DataSet();
			//UPGRADE_ISSUE: (2064) ADODB.CursorLocationEnum property CursorLocationEnum.adUseClient was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsDashboard.CursorLocation was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			rsDashboard.setCursorLocation(UpgradeStubs.ADODB_CursorLocationEnum.getadUseClient());
			SqlDataAdapter adap = new SqlDataAdapter(mysql, SystemVariables.gConn);
			rsDashboard.Tables.Clear();
			adap.Fill(rsDashboard);
			//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsDashboard.ActiveConnection was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			rsDashboard.setActiveConnection(null);

			cnt = 0;
			if (rsDashboard.Tables[0].Rows.Count > 0)
			{
				foreach (DataRow iteration_row in rsDashboard.Tables[0].Rows)
				{
					cnt++;
					p = (XtremeDockingPane.Pane) DockingPaneManager.CreatePane(cnt, 190, 120, XtremeDockingPane.DockingDirection.DockLeftOf, Type.Missing);
					p.Title = Convert.ToString(iteration_row["Report_Name"]);
				}
			}

			//    Set mShortcutPane = DockingPaneManager.CreatePane(1, 190, 120, DockLeftOf)
			//    mShortcutPane.Title = "Shortcut"
			//
			//    Set mShortcutPane1 = DockingPaneManager.CreatePane(3, 190, 120, DockLeftOf)
			//    mShortcutPane1.Title = "Customer"
			//
			//    Set mToolPane = DockingPaneManager.CreatePane(2, 190, 120, DockLeftOf)
			//    mToolPane.Title = "Product"
			//
			//    Set mToolPane1 = DockingPaneManager.CreatePane(4, 190, 120, DockLeftOf)
			//    mToolPane1.Title = "Supplier"
			//
			//    Set mToolPane2 = DockingPaneManager.CreatePane(5, 190, 120, DockLeftOf)
			//    mToolPane2.Title = "Sales"
			//
			//    Set mToolPane3 = DockingPaneManager.CreatePane(5, 190, 120, DockLeftOf)
			//    mToolPane2.Title = "Sales Return"

			DockingPaneManager.Options.ThemedFloatingFrames = true;
			DockingPaneManager.Options.LunaColors = false;
			DockingPaneManager.Options.FloatingFrameCaption = "Panes";
			DockingPaneManager.EnableKeyboardNavigate(XtremeDockingPane.DockingPaneKeyboardNavigate.PaneKeyboardUseAll);
			DockingPaneManager.Options.HideClient = true;

			DockingPaneManager.Options.SideDocking = true;
			DockingPaneManager.Options.SetSideDockingMargin(3, 3, 3, 3);

			DockingPaneManager.Options.AlphaDockingContext = true;
			DockingPaneManager.Options.ShowDockingContextStickers = true;
			DockingPaneManager.Options.StickerStyle = XtremeDockingPane.DockingContextStickerStyle.StickerStyleVisualStudio2005;
			DockingPaneManager.PaintManager.CaptionButtonStyle = XtremeDockingPane.DockingPaneCaptionButtonStyle.PaneCaptionButtonThemedExplorerBar;

			//DockingPaneManager.LoadState "InnovaDashboard", "Innova", "Dashboard"

		}
		private void DockingPaneManager_AttachPaneEvent(Object eventSender, AxXtremeDockingPane._DDockingPaneEvents_AttachPaneEvent eventArgs)
		{

			if (oReportForm[eventArgs.item.Id - 1] == null)
			{
				oReportForm[eventArgs.item.Id - 1] = frmSysReportDesign.CreateInstance();
			}
			//UPGRADE_ISSUE: (2064) ADODB.Recordset method rsDashboard.MoveFirst was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			rsDashboard.MoveFirst();
			//UPGRADE_ISSUE: (2064) ADODB.Recordset method rsDashboard.Move was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			rsDashboard.Move_Renamed(eventArgs.item.Id - 1, null);
			//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
			oReportForm[eventArgs.item.Id - 1].SetReportID(Convert.ToInt32(rsDashboard.Tables[0].Rows[0]["Report_Id"]), 0, true);
			eventArgs.item.Handle = oReportForm[eventArgs.item.Id - 1].Handle.ToInt32();
		}

		private void Form_Closed(Object eventSender, EventArgs eventArgs)
		{
			frmSysReportDesign Pane = null;
			int i = 0;
			int j = 0;

			DockingPaneManager.SaveState("InnovaDashboard", "Innova", "Dashboard");

			foreach (frmSysReportDesign PaneIterator in oReportForm)
			{
				Pane = PaneIterator;
				if (Pane != null)
				{
					Pane.Close();
				}
				Pane = default(frmSysReportDesign);
			}

		}
	}
}