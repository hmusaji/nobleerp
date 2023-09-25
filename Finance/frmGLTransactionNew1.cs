using Excel = Microsoft.Office.Interop.Excel;

using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;




namespace Xtreme
{
	internal partial class frmGLTransaction
		: System.Windows.Forms.Form
	{

		private int mThisFormID = 0; //Assign the Formid for Each Form
		private string mTimeStamp = "";
		private XArrayHelper _aVoucherDetails = null;
		public frmGLTransaction()
{
InitializeComponent();
}
}
}
