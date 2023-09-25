
using System;
using System.Windows.Forms;


namespace Xtreme
{
	internal partial class frmSysOnlinePosting
		: System.Windows.Forms.Form
	{

		public frmSysOnlinePosting()
{
InitializeComponent();
} 
 public  void frmSysOnlinePosting_old()
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


		private void frmSysOnlinePosting_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (UpgradeHelpers.Gui.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Gui.ActivateHelper.myActiveForm = (System.Windows.Forms.Form) eventSender;
			}
		}
		public bool mApprove = false;

		private void cmdOKCancel_CancelClick(Object Sender, EventArgs e)
		{
			mApprove = false;
			this.Hide();
		}

		private void cmdOKCancel_OKClick(Object Sender, EventArgs e)
		{
			mApprove = true;
			this.Hide();
		}

		private void Form_Initialize()
		{
			mApprove = true;
		}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2080
		private void Form_Load()
		{
			//fraMain.left = 0
			//fraMain.top = 0
			//Me.Width = fraMain.Width - 35
			//Me.Height = fraMain.Height
		}

		private void Form_KeyDown(Object eventSender, KeyEventArgs eventArgs)
		{
			int KeyCode = (int) eventArgs.KeyCode;
			int Shift = ((int) eventArgs.KeyData) / 65536;
			try
			{
				if (KeyCode == 13)
				{ //If enter key pressed send a tab key
					SendKeys.Send("{TAB}");
				}
				else if (KeyCode == 27)
				{ 
					cmdOKCancel_CancelClick(cmdOKCancel, null);
				}
			}
			finally
			{
				eventArgs.Handled = KeyCode == 0;
			}
		}

		private void Form_Closed(Object eventSender, EventArgs eventArgs)
		{
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{

				SystemMenu.RemoveMeFromWindowList(Conversion.Str(this.Handle.ToInt32()));
				frmSysOnlinePosting.DefInstance = null;
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}
	}
}