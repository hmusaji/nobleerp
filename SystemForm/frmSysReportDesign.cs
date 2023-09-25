
using System;
using System.Windows.Forms;



namespace Xtreme
{
	internal partial class frmSysReportDesign
		: System.Windows.Forms.Form
	{

		public clsReportDefinition oReportProperties = null;
		public clsAccessAllowed UserAccess = null;

		private int mReportID = 0;
		private int mRecordCount = 0;
		private int mIsDashboard = 0;

		private const string mColumnPrefix = "Column";
		public frmSysReportDesign()
{
InitializeComponent();
}
}
}
