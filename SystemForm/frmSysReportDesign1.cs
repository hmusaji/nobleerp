using System;
using UpgradeHelpers;

namespace Xtreme
{
	internal partial class frmSysReportDesign1
		: System.Windows.Forms.Form
	{

		public frmSysReportDesign1()
{
InitializeComponent();
} 
 public  void frmSysReportDesign1_old()
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
			
			InitExtendedProperties();
		}
		void InitExtendedProperties()
		{
			this.grdReportDesign.setScrollTips(false);
			this.grdReportHeader.setScrollTips(false);
		}


		private void frmSysReportDesign1_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (UpgradeHelpers.Gui.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Gui.ActivateHelper.myActiveForm = (System.Windows.Forms.Form) eventSender;
			}
		}
		private void CommandBars_Execute(Object eventSender, AxXtremeCommandBars._DCommandBarsEvents_ExecuteEvent eventArgs)
		{
			//wndReportControl.PrintPreview True ', 100, 200, 800, 600

		}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2080
		private void Form_Load()
		{

			XtremeCommandBars.CommandBar StandardToolBar = (XtremeCommandBars.CommandBar) CommandBars.Add("Standard", XtremeCommandBars.XTPBarPosition.xtpBarTop);
			XtremeCommandBars.CommandBarControl ButtonControl = (XtremeCommandBars.CommandBarControl) StandardToolBar.Controls.Add(XtremeCommandBars.XTPControlType.xtpControlButton, 1, "Preview", Type.Missing, Type.Missing);

		}
		private void Form_Closed(Object eventSender, EventArgs eventArgs)
		{
		}
	}
}