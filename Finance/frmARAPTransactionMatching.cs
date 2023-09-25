
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;




namespace Xtreme
{
	internal partial class frmARAPTransactionMatching
		: System.Windows.Forms.Form
	{

		private DataSet recHeader = null;
		private DataSet recDetail = null;
		private DataSet recCloneDetail = null;

		
		public frmARAPTransactionMatching()
{
InitializeComponent();
}
}
}
