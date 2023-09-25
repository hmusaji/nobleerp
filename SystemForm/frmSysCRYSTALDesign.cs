
using System;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Windows.Forms;




namespace Xtreme
{
	internal partial class frmSysCRYSTALDesign
		: System.Windows.Forms.Form
	{



		public clsAccessAllowed UserAccess = null;

		public DataSet rsMasterRecordset = null;
		public DataSet rsDetailsRecordset = null;
		public CRAXDDRT.Application craPrimaryApplication = null;
		public CRAXDDRT.Report crrPrimaryReport = null;
		public bool mReportDataSourceIsSet = false;

		private int mReportId = 0;
		private bool mReportSettingsChanged = false;
		private bool mReportInProcess = false;

		//**--give the contants as the Label ID of the option (from SM_LABLES)
		//Private Const tbnReportOptions As Integer = 482
		//Private Const tbnMoveFirstPage As Integer = 1823
		//Private Const tbnMovePreviousPage As Integer = 1824
		//Private Const tbnMoveNextPage As Integer = 1825
		//Private Const tbnMoveLastPage As Integer = 1826
		//Private Const tbnPrintReport As Integer = 541
		//Private Const tbnPageSetup As Integer = 707
		//Private Const tbnExportReport As Integer = 266
		//Private Const tbnZoomPreview As Integer = 1821
		//Private Const tbnFindText As Integer = 276
		//Private Const tbnHelp As Integer = 308
		//Private Const tbnExit As Integer = 261
		//Private Const tbnSaveReport As Integer = 698

		private const string mZoomMenuPrefix = "Zoom";
		private int[] aZoomLevels = new int[9];
		public frmSysCRYSTALDesign()
{
InitializeComponent();
}
}
}
