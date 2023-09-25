using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Xtreme
{
	internal partial class frmSysSplash
		: System.Windows.Forms.Form
	{

		public frmSysSplash()
{
InitializeComponent();
} 
 public  void frmSysSplash_old()
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


		private void frmSysSplash_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (UpgradeHelpers.Gui.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Gui.ActivateHelper.myActiveForm = (System.Windows.Forms.Form) eventSender;
			}
		}

		private const int HWND_TOPMOST = -1;
		private const int HWND_NOTOPMOST = -2;
		private const int SWP_NOMOVE = 0x2;
		private const int SWP_NOSIZE = 0x1;
		private const int SWP_NOACTIVATE = 0x10;
		private const int SWP_SHOWWINDOW = 0x40;
		static readonly private int TOPMOST_FLAGS = SWP_NOMOVE | SWP_NOSIZE;

		//UPGRADE_NOTE: (2041) The following line was commented. More Information: https://docs.mobilize.net/vbuc/ewis#2041
		//[DllImport("user32.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
		//extern public static int SetWindowPos(int hWnd, int hWndInsertAfter, int x, int y, int cx, int cy, int wFlags);

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2080
		private void Form_Load()
		{
			shpBorder.Left = 0;
			shpBorder.Top = 0;
			shpBorder.Width = this.ClientRectangle.Width + 1;
			shpBorder.Height = this.ClientRectangle.Height + 1;

			//centre (sort of), set topmost, and force
			//a refresh to assure its graphic is on-screen
			//before the rest of Sub Main executes.
			this.SetBounds(((Screen.PrimaryScreen.Bounds.Width * 15 - Width * 15) / 2) / 15, (((Screen.PrimaryScreen.Bounds.Height * 15 - Height * 15) / 2) - 500) / 15, 0, 0, BoundsSpecified.X | BoundsSpecified.Y);

			InnovaUpdSupport.PInvoke.SafeNative.user32.SetWindowPos(this.Handle.ToInt32(), HWND_TOPMOST, 0, 0, 0, 0, TOPMOST_FLAGS);
			//The SOFTWARE product is protected by copyright laws and international copyright treaties, as well as other intellectual property laws and treaties. The SOFTWARE product is licensed, not sold.
		}

		private void Form_Closed(Object eventSender, EventArgs eventArgs)
		{
			frmSysSplash.DefInstance = null;
		}
		//&H00637259&
	}
}