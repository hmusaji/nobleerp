
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;




namespace Xtreme
{
	internal partial class frmICSItems
		: System.Windows.Forms.Form
	{


		private int mThisFormID = 0;
		private object mSearchValue = null;
		private string mTimeStamp = "";
		private SystemVariables.SystemFormModes mCurrentFormMode = (SystemVariables.SystemFormModes) 0;
		private XArrayHelper aProductAssemblyDetails = null;
		private XArrayHelper aProductStockLevels = null;
		private XArrayHelper _aProductSupplierDetails = null;
		public frmICSItems()
{
InitializeComponent();
}
}
}
