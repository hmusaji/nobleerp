
using System;
using System.Windows.Forms;


namespace Xtreme
{
	internal partial class frmGLLedgerFCAmount
		: System.Windows.Forms.Form
	{

		public frmGLLedgerFCAmount()
{
InitializeComponent();
} 
 public  void frmGLLedgerFCAmount_old()
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


		private void frmGLLedgerFCAmount_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (UpgradeHelpers.Gui.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Gui.ActivateHelper.myActiveForm = (System.Windows.Forms.Form) eventSender;
			}
		}
		private Form mParentForm = null;
		private int mCurrentRow = 0;
		private bool mIsOkClicked = false;


		public bool IsOkClicked
		{
			get
			{
				return mIsOkClicked;
			}
			set
			{
				mIsOkClicked = value;
			}
		}


		public Form ParentForm_Renamed
		{
			set
			{
				mParentForm = value;
			}
		}


		public int CurrentRow
		{
			set
			{
				mCurrentRow = value;
			}
		}


		private void cmdOkCancel_AccessKeyPress(Object eventSender, AxSmartNetButtonProject.__SmartNetButton_AccessKeyPressEvent eventArgs)
		{
			int Index = Array.IndexOf(this.cmdOkCancel, eventSender);
			cmdOkCancel_ClickEvent(cmdOkCancel[Index], new EventArgs());
		}

		private void cmdOkCancel_ClickEvent(Object eventSender, EventArgs eventArgs)
		{
			int Index = Array.IndexOf(this.cmdOkCancel, eventSender);
			if (Index == 0)
			{
				ReflectionHelper.LetMember(mParentForm, "aVoucherDetails", txtExchangeRate.Text, ReflectionHelper.GetMember(ReflectionHelper.GetMember(mParentForm, "grdVoucherDetails"), "Bookmark"), ReflectionHelper.GetMember(mParentForm, "ExchangeRateColumn"));
				ReflectionHelper.LetMember(mParentForm, "aVoucherDetails", txtFCAmount.Text, ReflectionHelper.GetMember(ReflectionHelper.GetMember(mParentForm, "grdVoucherDetails"), "Bookmark"), ReflectionHelper.GetMember(mParentForm, "LineFCAmountColumn"));

				IsOkClicked = true;
				//    If optAmountType(0).Value = True Then
				//        mParentForm.LedgerFCDrCrType = "D"
				//    Else
				//        mParentForm.LedgerFCDrCrType = "C"
				//    End If

				//Unload Me
				this.Hide();
			}
			else
			{
				//Unload Me
				IsOkClicked = false;
				this.Hide();
			}
		}

		private void cmdOkCancel_KeyDownEvent(Object eventSender, AxSmartNetButtonProject.__SmartNetButton_KeyDownEvent eventArgs)
		{
			int Index = Array.IndexOf(this.cmdOkCancel, eventSender);
			if (eventArgs.keyCode == 13)
			{
				cmdOkCancel_ClickEvent(cmdOkCancel[Index], new EventArgs());
			}
		}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2080
		private void Form_Load()
		{
			fraLedgerAmountDetails.Left = 0;
			fraLedgerAmountDetails.Top = 0;
			this.Width = fraLedgerAmountDetails.Width;
			this.Height = fraLedgerAmountDetails.Height;
			IsOkClicked = false;
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
					return;
				}
				else if (KeyCode == 27)
				{ 
					cmdOkCancel_ClickEvent(cmdOkCancel[1], new EventArgs());
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

				frmGLLedgerFCAmount.DefInstance = null;
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}
	}
}