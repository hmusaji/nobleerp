using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;



namespace Xtreme
{
	internal partial class frmICSItemPictureDisplay
		: System.Windows.Forms.Form
	{


		private int mThisFormID = 0;
		private string mPictureName = "";


		//UPGRADE_NOTE: (2041) The following line was commented. More Information: https://docs.mobilize.net/vbuc/ewis#2041
		//[DllImport("user32.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
		//extern public static int GetForegroundWindow();

		//Private Sub Timer1_Timer()
		//'If the window on top is not this window...
		//If Me.hwnd <> GetForegroundWindow Then
		//'Make this form be on top
		//'Call SetWindowPos(GetForegroundWindow, HWND_NOTOPMOST, 0, 0, 0, 0, SWP_NOMOVE Or SWP_NOSIZE)
		//'Make the window on top below this form
		//'Me.ZOrder 0
		//Call SetWindowPos(Me.hwnd, HWND_TOPMOST, 0, 0, 0, 0, TOPMOST_FLAGS)
		//
		public frmICSItemPictureDisplay()
{
InitializeComponent();
} 
 public  void frmICSItemPictureDisplay_old()
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


		//End If
		//End Sub


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


		public string PictureName
		{
			set
			{
				mPictureName = value;
			}
		}


		private void Form_Activated(Object eventSender, EventArgs eventArgs)
		{
			if (ActivateHelper.myActiveForm != eventSender)
			{
				ActivateHelper.myActiveForm = (Form) eventSender;

				try
				{
					ImgItem.Image = null;
					ImgItem.Image = Image.FromFile(SystemVariables.gProductPicturesPath + mPictureName);

					return;
				}
				catch
				{

					ImgItem.Image = null;
					return;
				}
			}
		}

		private void Form_KeyDown(Object eventSender, KeyEventArgs eventArgs)
		{
			int KeyCode = (int) eventArgs.KeyCode;
			int Shift = ((int) eventArgs.KeyData) / 65536;
			try
			{
				SystemForms.SystemFormKeyDown(this, ref KeyCode, Shift);
			}
			finally
			{
				eventArgs.Handled = KeyCode == 0;
			}
		}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2080
		private void Form_Load()
		{

			this.Top = 0;
			this.Left = Convert.ToInt32((frmSysMain.DefInstance.oSystemInformation.WorkAreaWidth / 15 - this.ClientRectangle.Width) - 10);

		}

		private void Form_Closed(Object eventSender, EventArgs eventArgs)
		{
			frmICSItemPictureDisplay.DefInstance = null;
			ImgItem.Image = null;
		}

		private void ImgItem_DoubleClick(Object eventSender, EventArgs eventArgs)
		{
			//Dim mPicturePath  As String
			//If Not IsItEmpty(mPictureName, StringType) Then
			//    mPicturePath = gProductPicturesPath & grdVoucherDetails.Columns(ConPicture).Text
			//    'Shell "d:\windows\System32\mspaint.exe " & mPicturePath, vbMaximizedFocus
			//End If
		}

		public void CloseForm()
		{
			this.Close();
		}

		private bool isInitializingComponent;
		private void Form_Resize(Object eventSender, EventArgs eventArgs)
		{
			if (isInitializingComponent)
			{
				return;
			}
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{

				ImgItem.Width = this.Width - 3;
				ImgItem.Height = this.Height - 3;
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}

		}
	}
}