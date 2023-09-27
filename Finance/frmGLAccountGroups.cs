
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;




namespace Xtreme
{
	internal partial class frmGLAccountGroups
		: System.Windows.Forms.Form
	{

		private int mThisFormID = 0; //Assign the Formid for Each Form
		private object mSearchValue = null; //Variable for storing the searchvalue from the Find window
		//private SystemVariables.SystemFormModes mCurrentFormMode = (SystemVariables.SystemFormModes) 0; //Enum for checking the current form mode
		
		public frmGLAccountGroups()
{
InitializeComponent();
}
}
}
