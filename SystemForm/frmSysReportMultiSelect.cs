
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;





namespace Xtreme
{
	internal partial class frmSysReportMultiSelect
		: System.Windows.Forms.Form
	{


		private int mFindID = 0;
		private string mReturnColumnIDList = "";
		private string mCustomWhereClause = "";
		private bool mUseDefaultWhereClause = false;
		private bool mApplySpecialFormating = false;
		private string mCustomFromClause = "";
		private bool mEnableColumnCustomize = false;
		private object mReturnColumnValues = null;
		private DataSet rsReportData = null;
		private DataSet rsMasterRecordset = null;
		private DataSet rsDetailsRecordset = null;
		private bool mReportSettingsChanged = false;
		private bool mReportIsFormated = false;
		private bool mStructureIsCreated = false;
		private bool mUseColumnScroll = false;
		private bool mResizeInProgress = false;
		private bool mShowAllRecords = false;
		private string mAdditionalFromClause = "";
		private bool mUseDefaultColorScheme = false;
		private string mFindDataSourceSelectSQL = "";
		private string mFindDataSourceWhereSQL = "";
		private string mFindDataSourceGroupBySQL = "";
		private string mFindDataSourceOrderBySQL = "";

		//$0
		//--whether to allow or disallow user to add / open find master
		public bool mRestrictAccessToMasterFromFind = false;

		private const int mButtonSeek = 0;
		private const int mButtonNew = 1;
		private const int mButtonOpen = 2;
		private const int mButtonCustomize = 3;
		private const int mButtonCancel = 4;
		private const int mButtonHelp = 5;
		private const int mButtonSave = 6;

		private const int cbSubstringSearch = 0;
		private const int cbShowAllRecords = 1;

		private Color mFixedHeaderBackColor = System.Drawing.Color.Black;
		private Color mFixedGridBackColor = System.Drawing.Color.Black;
		private int mFilterBackColor = 0;
		private int mResultGridHighlightColor = 0;

		private int mResultGridHeight = 0;
		private const int mCriteriaGridHeight = 300;

		private const int mFixedRow = 0;
		private const string mColumnPrefix = "Column";

		//public XtremeCommandBars.StatusBar UCStatusBar = null;


		// to handle node dragging
		private const int DRAGTOL = 200; // mouse movement before dragging starts
		[Serializable]
		private struct DRAGINFO
		{
			public bool bDragging; // currently dragging
			public bool bCheckDrag; // currently checking mouse to start dragging
			public int lSrc; // row being dragged
			public int xDown; // mouse down position
			public int yDown; // mouse down position
		}
		private DRAGINFO mFGDragInfo = new DRAGINFO();

		//UPGRADE_NOTE: (2041) The following line was commented. More Information: https://docs.mobilize.net/vbuc/ewis#2041
		//[DllImport("user32.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
		//extern public static int LockWindowUpdate(int hWnd);

		private const bool mDraggingAllowed = true;

		private bool m_booKeyCtrl = false;
		private bool m_booKeyShift = false;
		private bool m_booProcessSelected = false;
		private bool isCheckAll = false;
		public frmSysReportMultiSelect()
{
InitializeComponent();
}
}
}
