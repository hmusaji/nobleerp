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
}
}
