
using System;
using System.Windows.Forms;


namespace Xtreme
{
	internal partial class frmSysReportSeekPage
		: System.Windows.Forms.Form
	{

		public frmSysReportSeekPage()
{
InitializeComponent();
} 
 public  void frmSysReportSeekPage_old()
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


		private void frmSysReportSeekPage_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (UpgradeHelpers.Gui.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Gui.ActivateHelper.myActiveForm = (System.Windows.Forms.Form) eventSender;
			}
		}
		public int mSeekPageNo = 0;

		private void Form_KeyDown(Object eventSender, KeyEventArgs eventArgs)
		{
			int KeyCode = (int) eventArgs.KeyCode;
			int Shift = ((int) eventArgs.KeyData) / 65536;
			try
			{
				if (KeyCode == ((int) Keys.Return))
				{
					cmdSeekPage_OKClick(cmdSeekPage, null);
				}
				else if (KeyCode == ((int) Keys.Escape))
				{ 
					cmdSeekPage_CancelClick(cmdSeekPage, null);
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
				frmSysReportSeekPage.DefInstance = null;
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		private void cmdSeekPage_CancelClick(Object Sender, EventArgs e)
		{
			mSeekPageNo = 0;
			this.Hide();
		}

		private void cmdSeekPage_OKClick(Object Sender, EventArgs e)
		{
			if (!SystemProcedure2.IsItEmpty(txtSeekPage.Text, SystemVariables.DataType.NumberType))
			{
				mSeekPageNo = Convert.ToInt32(Conversion.Val(txtSeekPage.Text));
			}
			else
			{
				mSeekPageNo = 0;
			}
			this.Hide();
		}
	}
}