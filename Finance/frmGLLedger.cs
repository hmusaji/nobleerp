
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;




namespace Xtreme
{
	internal partial class frmGLLedger
		: System.Windows.Forms.Form
	{


		private int mThisFormID = 0;
		private object mSearchValue = null;
		private string mTimeStamp = "";
		private SystemVariables.SystemFormModes mCurrentFormMode = (SystemVariables.SystemFormModes) 0; //Enum for checking the current form mode
		
		public frmGLLedger()
{
InitializeComponent();
}
}
}
