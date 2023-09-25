
using System;
using System.Windows.Forms;


namespace Xtreme
{
	internal partial class frmSysSetSystemDate
		: System.Windows.Forms.Form
	{

		public frmSysSetSystemDate()
{
InitializeComponent();
} 
 public  void frmSysSetSystemDate_old()
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


		private void frmSysSetSystemDate_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (UpgradeHelpers.Gui.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Gui.ActivateHelper.myActiveForm = (System.Windows.Forms.Form) eventSender;
			}
		}

		//Assign the Formid for Each Form
		private int mThisFormID = 0;
		private SystemVariables.SystemFormModes mCurrentFormMode = (SystemVariables.SystemFormModes) 0;
		
		public clsAccessAllowed UserAccess
		{
			get
			{
				if (_UserAccess is null)
				{
					_UserAccess = new clsAccessAllowed();
				}
				return _UserAccess;
			}
			set
			{
				_UserAccess = value;
			}
		}



		public int ThisFormId
		{
			get
			{
				return mThisFormID;
			}
			set
			{
				mThisFormID = value;
			}
		}



		public SystemVariables.SystemFormModes CurrentFormMode
		{
			get
			{
				return mCurrentFormMode;
			}
			set
			{
				mCurrentFormMode = value;
			}
		}


		private void datePicker_DateClick(Object eventSender, AxXtremeSuiteControls._DMonthCalendarEvents_DateClickEvent eventArgs)
		{
			if (!Information.IsDate(datePicker.Value))
			{
				MessageBox.Show("Invalid Date", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
			}

			SystemVariables.gCurrentDate = datePicker.Value;

			frmSysMain.DefInstance.mnuSystemMenu.StatusBar.FindPane(SystemConstants.gStatusDate).Text = "System Date : " + DateTimeHelper.ToString(SystemVariables.gCurrentDate);

			this.Close();
		}

		private void cmdOKCancel_CancelClick(Object Sender, EventArgs e)
		{
			this.Close();
		}

		private void cmdOKCancel_OKClick(Object Sender, EventArgs e)
		{
			//MsgBox datePicker.Value
			if (!Information.IsDate(datePicker.Value))
			{
				MessageBox.Show("Invalid Date", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
			}

			SystemVariables.gCurrentDate = datePicker.Value;
			frmSysMain.DefInstance.mnuSystemMenu.StatusBar.FindPane(SystemConstants.gStatusDate).Text = "System Date : " + DateTimeHelper.ToString(SystemVariables.gCurrentDate);


			this.Close();
		}

		private void Form_KeyDown(Object eventSender, KeyEventArgs eventArgs)
		{
			int KeyCode = (int) eventArgs.KeyCode;
			int Shift = ((int) eventArgs.KeyData) / 65536;
			try
			{
				if (KeyCode == ((int) Keys.Return))
				{ //If enter key pressed send a tab key
					SendKeys.Send("{TAB}");
					return;
				}
				else if (KeyCode == ((int) Keys.Escape))
				{  //If enter key pressed send a tab key
					cmdOKCancel_CancelClick(cmdOKCancel, null);
					return;
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
			this.Top = (Convert.ToInt32((frmSysMain.DefInstance.oSystemInformation.WorkAreaHeight / 15 - (frmSysMain.DefInstance.Height - frmSysMain.DefInstance.ClientRectangle.Height) - this.Height) / 2f));
			this.Left = (Convert.ToInt32((frmSysMain.DefInstance.oSystemInformation.WorkAreaWidth / 15 - (frmSysMain.DefInstance.Width - frmSysMain.DefInstance.ClientRectangle.Width) - this.Width) / 2f));

			datePicker.Value = SystemVariables.gCurrentDate;
			this.Show();
		}

		private void Form_Closed(Object eventSender, EventArgs eventArgs)
		{
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{

				SystemMenu.RemoveMeFromWindowList(Conversion.Str(this.Handle.ToInt32()));
				frmSysSetSystemDate.DefInstance = null;
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}
	}
}