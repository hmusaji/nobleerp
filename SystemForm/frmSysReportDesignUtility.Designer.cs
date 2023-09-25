
namespace Xtreme
{
	partial class frmSysReportDesignUtility
	{

		#region "Upgrade Support "
		private static frmSysReportDesignUtility m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmSysReportDesignUtility DefInstance
		{
			get
			{
				if (m_vb6FormDefInstance is null || m_vb6FormDefInstance.IsDisposed)
				{
					m_InitializingDefInstance = true;
					m_vb6FormDefInstance = CreateInstance();
					m_InitializingDefInstance = false;
				}
				return m_vb6FormDefInstance;
			}
			set
			{
				m_vb6FormDefInstance = value;
			}
		}

		#endregion
		#region "Windows Form Designer generated code "
		public static frmSysReportDesignUtility CreateInstance()
		{
			frmSysReportDesignUtility theInstance = new frmSysReportDesignUtility();
			//The MDI form in the VB6 project had its
			//AutoShowChildren property set to True
			//To simulate the VB6 behavior, we need to
			//automatically Show the form whenever it
			//is loaded.  If you do not want this behavior
			//then delete the following line of code
			//UPGRADE_TODO: (2018) Remove the next line of code to stop form from automatically showing. More Information: https://docs.mobilize.net/vbuc/ewis#2018
			theInstance.Show();
			return theInstance;
		}
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "_btnFormToolBar_0", "_btnFormToolBar_1", "_btnFormToolBar_5", "_btnFormToolBar_2", "_btnFormToolBar_3", "_btnFormToolBar_6", "_btnFormToolBar_8", "_btnFormToolBar_4", "_btnFormToolBar_7", "picFormToolbar", "txtVariablesDeclarationSQL", "chkShowDateRange", "chkShowDrillDownReport", "chkShowFilterCondition", "chkShow", "chkProtected", "txtFromClause", "lblVariableDeclaration", "txtOrderByClause", "txtWhereClause", "txtChildFormId", "txtChildReportId2", "txtChildReportId", "lblOrderByClause", "lblWhereClause", "lblFromClause", "lblChildReportId", "lblChildReportId2", "lblChildFormId", "txtLReportName", "lblL_Report_Name", "lblReportId", "txtReportID", "_tabProductDetails_TabPage0", "grdVoucherDetails", "_tabProductDetails_TabPage1", "_tabProductDetails_TabPage2", "tabProductDetails", "btnFormToolBar"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		private AxSmartNetButtonProject.AxSmartNetButton _btnFormToolBar_0;
		private AxSmartNetButtonProject.AxSmartNetButton _btnFormToolBar_1;
		private AxSmartNetButtonProject.AxSmartNetButton _btnFormToolBar_5;
		private AxSmartNetButtonProject.AxSmartNetButton _btnFormToolBar_2;
		private AxSmartNetButtonProject.AxSmartNetButton _btnFormToolBar_3;
		private AxSmartNetButtonProject.AxSmartNetButton _btnFormToolBar_6;
		private AxSmartNetButtonProject.AxSmartNetButton _btnFormToolBar_8;
		private AxSmartNetButtonProject.AxSmartNetButton _btnFormToolBar_4;
		private AxSmartNetButtonProject.AxSmartNetButton _btnFormToolBar_7;
		public System.Windows.Forms.PictureBox picFormToolbar;
		public System.Windows.Forms.TextBox txtVariablesDeclarationSQL;
		public System.Windows.Forms.CheckBox chkShowDateRange;
		public System.Windows.Forms.CheckBox chkShowDrillDownReport;
		public System.Windows.Forms.CheckBox chkShowFilterCondition;
		public System.Windows.Forms.CheckBox chkShow;
		public System.Windows.Forms.CheckBox chkProtected;
		public System.Windows.Forms.TextBox txtFromClause;
		public System.Windows.Forms.Label lblVariableDeclaration;
		public System.Windows.Forms.TextBox txtOrderByClause;
		public System.Windows.Forms.TextBox txtWhereClause;
		public System.Windows.Forms.TextBox txtChildFormId;
		public System.Windows.Forms.TextBox txtChildReportId2;
		public System.Windows.Forms.TextBox txtChildReportId;
		public System.Windows.Forms.Label lblOrderByClause;
		public System.Windows.Forms.Label lblWhereClause;
		public System.Windows.Forms.Label lblFromClause;
		public System.Windows.Forms.Label lblChildReportId;
		public System.Windows.Forms.Label lblChildReportId2;
		public System.Windows.Forms.Label lblChildFormId;
		public System.Windows.Forms.TextBox txtLReportName;
		public System.Windows.Forms.Label lblL_Report_Name;
		public System.Windows.Forms.Label lblReportId;
		public System.Windows.Forms.Label txtReportID;
		private System.Windows.Forms.TabPage _tabProductDetails_TabPage0;
		public C1.Win.C1TrueDBGrid.C1TrueDBGrid grdVoucherDetails;
		private System.Windows.Forms.TabPage _tabProductDetails_TabPage1;
		private System.Windows.Forms.TabPage _tabProductDetails_TabPage2;
		public System.Windows.Forms.TabControl tabProductDetails;
		public AxSmartNetButtonProject.AxSmartNetButton[] btnFormToolBar = new AxSmartNetButtonProject.AxSmartNetButton[9];
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSysReportDesignUtility));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this.picFormToolbar = new System.Windows.Forms.PictureBox();
			this._btnFormToolBar_0 = new AxSmartNetButtonProject.AxSmartNetButton();
			this._btnFormToolBar_1 = new AxSmartNetButtonProject.AxSmartNetButton();
			this._btnFormToolBar_5 = new AxSmartNetButtonProject.AxSmartNetButton();
			this._btnFormToolBar_2 = new AxSmartNetButtonProject.AxSmartNetButton();
			this._btnFormToolBar_3 = new AxSmartNetButtonProject.AxSmartNetButton();
			this._btnFormToolBar_6 = new AxSmartNetButtonProject.AxSmartNetButton();
			this._btnFormToolBar_8 = new AxSmartNetButtonProject.AxSmartNetButton();
			this._btnFormToolBar_4 = new AxSmartNetButtonProject.AxSmartNetButton();
			this._btnFormToolBar_7 = new AxSmartNetButtonProject.AxSmartNetButton();
			this.tabProductDetails = new System.Windows.Forms.TabControl();
			this._tabProductDetails_TabPage0 = new System.Windows.Forms.TabPage();
			this.txtVariablesDeclarationSQL = new System.Windows.Forms.TextBox();
			this.chkShowDateRange = new System.Windows.Forms.CheckBox();
			this.chkShowDrillDownReport = new System.Windows.Forms.CheckBox();
			this.chkShowFilterCondition = new System.Windows.Forms.CheckBox();
			this.chkShow = new System.Windows.Forms.CheckBox();
			this.chkProtected = new System.Windows.Forms.CheckBox();
			this.txtFromClause = new System.Windows.Forms.TextBox();
			this.lblVariableDeclaration = new System.Windows.Forms.Label();
			this.txtOrderByClause = new System.Windows.Forms.TextBox();
			this.txtWhereClause = new System.Windows.Forms.TextBox();
			this.txtChildFormId = new System.Windows.Forms.TextBox();
			this.txtChildReportId2 = new System.Windows.Forms.TextBox();
			this.txtChildReportId = new System.Windows.Forms.TextBox();
			this.lblOrderByClause = new System.Windows.Forms.Label();
			this.lblWhereClause = new System.Windows.Forms.Label();
			this.lblFromClause = new System.Windows.Forms.Label();
			this.lblChildReportId = new System.Windows.Forms.Label();
			this.lblChildReportId2 = new System.Windows.Forms.Label();
			this.lblChildFormId = new System.Windows.Forms.Label();
			this.txtLReportName = new System.Windows.Forms.TextBox();
			this.lblL_Report_Name = new System.Windows.Forms.Label();
			this.lblReportId = new System.Windows.Forms.Label();
			this.txtReportID = new System.Windows.Forms.Label();
			this._tabProductDetails_TabPage1 = new System.Windows.Forms.TabPage();
			this.grdVoucherDetails = new C1.Win.C1TrueDBGrid.C1TrueDBGrid();
			this._tabProductDetails_TabPage2 = new System.Windows.Forms.TabPage();
			// //((System.ComponentModel.ISupportInitialize) this._btnFormToolBar_0).BeginInit();
			// //((System.ComponentModel.ISupportInitialize) this._btnFormToolBar_1).BeginInit();
			// //((System.ComponentModel.ISupportInitialize) this._btnFormToolBar_5).BeginInit();
			// //((System.ComponentModel.ISupportInitialize) this._btnFormToolBar_2).BeginInit();
			// //((System.ComponentModel.ISupportInitialize) this._btnFormToolBar_3).BeginInit();
			// //((System.ComponentModel.ISupportInitialize) this._btnFormToolBar_6).BeginInit();
			// //((System.ComponentModel.ISupportInitialize) this._btnFormToolBar_8).BeginInit();
			// //((System.ComponentModel.ISupportInitialize) this._btnFormToolBar_4).BeginInit();
			// //((System.ComponentModel.ISupportInitialize) this._btnFormToolBar_7).BeginInit();
			this.picFormToolbar.SuspendLayout();
			this.tabProductDetails.SuspendLayout();
			this._tabProductDetails_TabPage0.SuspendLayout();
			this._tabProductDetails_TabPage1.SuspendLayout();
			this.SuspendLayout();
			// 
			// picFormToolbar
			// 
			this.picFormToolbar.AllowDrop = true;
			this.picFormToolbar.BackColor = System.Drawing.SystemColors.Control;
			this.picFormToolbar.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.picFormToolbar.CausesValidation = true;
			this.picFormToolbar.Controls.Add(this._btnFormToolBar_0);
			this.picFormToolbar.Controls.Add(this._btnFormToolBar_1);
			this.picFormToolbar.Controls.Add(this._btnFormToolBar_5);
			this.picFormToolbar.Controls.Add(this._btnFormToolBar_2);
			this.picFormToolbar.Controls.Add(this._btnFormToolBar_3);
			this.picFormToolbar.Controls.Add(this._btnFormToolBar_6);
			this.picFormToolbar.Controls.Add(this._btnFormToolBar_8);
			this.picFormToolbar.Controls.Add(this._btnFormToolBar_4);
			this.picFormToolbar.Controls.Add(this._btnFormToolBar_7);
			this.picFormToolbar.Dock = System.Windows.Forms.DockStyle.Top;
			this.picFormToolbar.Enabled = true;
			this.picFormToolbar.Location = new System.Drawing.Point(0, 0);
			this.picFormToolbar.Name = "picFormToolbar";
			this.picFormToolbar.Size = new System.Drawing.Size(741, 38);
			this.picFormToolbar.TabIndex = 23;
			this.picFormToolbar.TabStop = false;
			this.picFormToolbar.Visible = true;
			// 
			// _btnFormToolBar_0
			// 
			this._btnFormToolBar_0.AllowDrop = true;
			this._btnFormToolBar_0.Location = new System.Drawing.Point(2, 2);
			this._btnFormToolBar_0.Name = "_btnFormToolBar_0";
			//
			this._btnFormToolBar_0.Size = new System.Drawing.Size(51, 34);
			this._btnFormToolBar_0.TabIndex = 24;
			this._btnFormToolBar_0.TabStop = false;
			this._btnFormToolBar_0.Tag = "New";
			// 
			// _btnFormToolBar_1
			// 
			this._btnFormToolBar_1.AllowDrop = true;
			this._btnFormToolBar_1.Location = new System.Drawing.Point(53, 2);
			this._btnFormToolBar_1.Name = "_btnFormToolBar_1";
			//
			this._btnFormToolBar_1.Size = new System.Drawing.Size(51, 34);
			this._btnFormToolBar_1.TabIndex = 25;
			this._btnFormToolBar_1.TabStop = false;
			this._btnFormToolBar_1.Tag = "Save";
			// 
			// _btnFormToolBar_5
			// 
			this._btnFormToolBar_5.AllowDrop = true;
			this._btnFormToolBar_5.Location = new System.Drawing.Point(257, 2);
			this._btnFormToolBar_5.Name = "_btnFormToolBar_5";
			//
			this._btnFormToolBar_5.Size = new System.Drawing.Size(51, 34);
			this._btnFormToolBar_5.TabIndex = 26;
			this._btnFormToolBar_5.TabStop = false;
			this._btnFormToolBar_5.Tag = "Help";
			// 
			// _btnFormToolBar_2
			// 
			this._btnFormToolBar_2.AllowDrop = true;
			this._btnFormToolBar_2.Location = new System.Drawing.Point(104, 2);
			this._btnFormToolBar_2.Name = "_btnFormToolBar_2";
			//
			this._btnFormToolBar_2.Size = new System.Drawing.Size(51, 34);
			this._btnFormToolBar_2.TabIndex = 27;
			this._btnFormToolBar_2.TabStop = false;
			this._btnFormToolBar_2.Tag = "Delete";
			// 
			// _btnFormToolBar_3
			// 
			this._btnFormToolBar_3.AllowDrop = true;
			this._btnFormToolBar_3.Location = new System.Drawing.Point(155, 2);
			this._btnFormToolBar_3.Name = "_btnFormToolBar_3";
			//
			this._btnFormToolBar_3.Size = new System.Drawing.Size(51, 34);
			this._btnFormToolBar_3.TabIndex = 28;
			this._btnFormToolBar_3.TabStop = false;
			this._btnFormToolBar_3.Tag = "Print";
			// 
			// _btnFormToolBar_6
			// 
			this._btnFormToolBar_6.AllowDrop = true;
			this._btnFormToolBar_6.Location = new System.Drawing.Point(308, 2);
			this._btnFormToolBar_6.Name = "_btnFormToolBar_6";
			//
			this._btnFormToolBar_6.Size = new System.Drawing.Size(63, 34);
			this._btnFormToolBar_6.TabIndex = 29;
			this._btnFormToolBar_6.TabStop = false;
			this._btnFormToolBar_6.Tag = "I";
			// 
			// _btnFormToolBar_8
			// 
			this._btnFormToolBar_8.AllowDrop = true;
			this._btnFormToolBar_8.Location = new System.Drawing.Point(444, 2);
			this._btnFormToolBar_8.Name = "_btnFormToolBar_8";
			//
			this._btnFormToolBar_8.Size = new System.Drawing.Size(51, 34);
			this._btnFormToolBar_8.TabIndex = 30;
			this._btnFormToolBar_8.TabStop = false;
			this._btnFormToolBar_8.Tag = "Exit";
			// 
			// _btnFormToolBar_4
			// 
			this._btnFormToolBar_4.AllowDrop = true;
			this._btnFormToolBar_4.Location = new System.Drawing.Point(206, 2);
			this._btnFormToolBar_4.Name = "_btnFormToolBar_4";
			//
			this._btnFormToolBar_4.Size = new System.Drawing.Size(51, 34);
			this._btnFormToolBar_4.TabIndex = 31;
			this._btnFormToolBar_4.TabStop = false;
			this._btnFormToolBar_4.Tag = "Find";
			// 
			// _btnFormToolBar_7
			// 
			this._btnFormToolBar_7.AllowDrop = true;
			this._btnFormToolBar_7.Location = new System.Drawing.Point(371, 2);
			this._btnFormToolBar_7.Name = "_btnFormToolBar_7";
			//
			this._btnFormToolBar_7.Size = new System.Drawing.Size(61, 34);
			this._btnFormToolBar_7.TabIndex = 32;
			this._btnFormToolBar_7.TabStop = false;
			this._btnFormToolBar_7.Tag = "L";
			// 
			// tabProductDetails
			// 
			// this.tabProductDetails.Alignment = System.Windows.Forms.TabAlignment.Top;
			this.tabProductDetails.AllowDrop = true;
			this.tabProductDetails.BackColor = System.Drawing.Color.White;
			this.tabProductDetails.Controls.Add(this._tabProductDetails_TabPage0);
			this.tabProductDetails.Controls.Add(this._tabProductDetails_TabPage1);
			this.tabProductDetails.Controls.Add(this._tabProductDetails_TabPage2);
			this.tabProductDetails.ForeColor = System.Drawing.Color.Maroon;
			this.tabProductDetails.ItemSize = new System.Drawing.Size(243, 18);
			this.tabProductDetails.Location = new System.Drawing.Point(3, 51);
			this.tabProductDetails.Multiline = true;
			this.tabProductDetails.Name = "tabProductDetails";
			this.tabProductDetails.Size = new System.Drawing.Size(736, 390);
			this.tabProductDetails.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
			this.tabProductDetails.TabIndex = 12;
			// 
			// _tabProductDetails_TabPage0
			// 
			this._tabProductDetails_TabPage0.Controls.Add(this.txtVariablesDeclarationSQL);
			this._tabProductDetails_TabPage0.Controls.Add(this.chkShowDateRange);
			this._tabProductDetails_TabPage0.Controls.Add(this.chkShowDrillDownReport);
			this._tabProductDetails_TabPage0.Controls.Add(this.chkShowFilterCondition);
			this._tabProductDetails_TabPage0.Controls.Add(this.chkShow);
			this._tabProductDetails_TabPage0.Controls.Add(this.chkProtected);
			this._tabProductDetails_TabPage0.Controls.Add(this.txtFromClause);
			this._tabProductDetails_TabPage0.Controls.Add(this.lblVariableDeclaration);
			this._tabProductDetails_TabPage0.Controls.Add(this.txtOrderByClause);
			this._tabProductDetails_TabPage0.Controls.Add(this.txtWhereClause);
			this._tabProductDetails_TabPage0.Controls.Add(this.txtChildFormId);
			this._tabProductDetails_TabPage0.Controls.Add(this.txtChildReportId2);
			this._tabProductDetails_TabPage0.Controls.Add(this.txtChildReportId);
			this._tabProductDetails_TabPage0.Controls.Add(this.lblOrderByClause);
			this._tabProductDetails_TabPage0.Controls.Add(this.lblWhereClause);
			this._tabProductDetails_TabPage0.Controls.Add(this.lblFromClause);
			this._tabProductDetails_TabPage0.Controls.Add(this.lblChildReportId);
			this._tabProductDetails_TabPage0.Controls.Add(this.lblChildReportId2);
			this._tabProductDetails_TabPage0.Controls.Add(this.lblChildFormId);
			this._tabProductDetails_TabPage0.Controls.Add(this.txtLReportName);
			this._tabProductDetails_TabPage0.Controls.Add(this.lblL_Report_Name);
			this._tabProductDetails_TabPage0.Controls.Add(this.lblReportId);
			this._tabProductDetails_TabPage0.Controls.Add(this.txtReportID);
			this._tabProductDetails_TabPage0.Text = "System Reports";
			// 
			// txtVariablesDeclarationSQL
			// 
			this.txtVariablesDeclarationSQL.AllowDrop = true;
			this.txtVariablesDeclarationSQL.BackColor = System.Drawing.Color.White;
			this.txtVariablesDeclarationSQL.ForeColor = System.Drawing.Color.Black;
			this.txtVariablesDeclarationSQL.Location = new System.Drawing.Point(90, 289);
			// this.txtVariablesDeclarationSQL.mDropDownType = (System.Windows.Forms.TextBox.DropDownTypes) 0;
			this.txtVariablesDeclarationSQL.Name = "txtVariablesDeclarationSQL";
			this.txtVariablesDeclarationSQL.Size = new System.Drawing.Size(633, 19);
			this.txtVariablesDeclarationSQL.TabIndex = 6;
			this.txtVariablesDeclarationSQL.Text = "";
			// 
			// chkShowDateRange
			// 
			this.chkShowDateRange.AllowDrop = true;
			this.chkShowDateRange.Appearance = System.Windows.Forms.Appearance.Normal;
			this.chkShowDateRange.BackColor = System.Drawing.SystemColors.Control;
			this.chkShowDateRange.CausesValidation = true;
			this.chkShowDateRange.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkShowDateRange.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this.chkShowDateRange.Enabled = true;
			this.chkShowDateRange.ForeColor = System.Drawing.SystemColors.ControlText;
			this.chkShowDateRange.Location = new System.Drawing.Point(570, 313);
			this.chkShowDateRange.Name = "chkShowDateRange";
			this.chkShowDateRange.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.chkShowDateRange.Size = new System.Drawing.Size(112, 13);
			this.chkShowDateRange.TabIndex = 11;
			this.chkShowDateRange.TabStop = true;
			this.chkShowDateRange.Text = "Show Date Range";
			this.chkShowDateRange.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkShowDateRange.Visible = true;
			// 
			// chkShowDrillDownReport
			// 
			this.chkShowDrillDownReport.AllowDrop = true;
			this.chkShowDrillDownReport.Appearance = System.Windows.Forms.Appearance.Normal;
			this.chkShowDrillDownReport.BackColor = System.Drawing.SystemColors.Control;
			this.chkShowDrillDownReport.CausesValidation = true;
			this.chkShowDrillDownReport.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkShowDrillDownReport.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this.chkShowDrillDownReport.Enabled = true;
			this.chkShowDrillDownReport.ForeColor = System.Drawing.SystemColors.ControlText;
			this.chkShowDrillDownReport.Location = new System.Drawing.Point(420, 313);
			this.chkShowDrillDownReport.Name = "chkShowDrillDownReport";
			this.chkShowDrillDownReport.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.chkShowDrillDownReport.Size = new System.Drawing.Size(136, 19);
			this.chkShowDrillDownReport.TabIndex = 10;
			this.chkShowDrillDownReport.TabStop = true;
			this.chkShowDrillDownReport.Text = "Show Drill Down Report";
			this.chkShowDrillDownReport.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkShowDrillDownReport.Visible = true;
			// 
			// chkShowFilterCondition
			// 
			this.chkShowFilterCondition.AllowDrop = true;
			this.chkShowFilterCondition.Appearance = System.Windows.Forms.Appearance.Normal;
			this.chkShowFilterCondition.BackColor = System.Drawing.SystemColors.Control;
			this.chkShowFilterCondition.CausesValidation = true;
			this.chkShowFilterCondition.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkShowFilterCondition.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this.chkShowFilterCondition.Enabled = true;
			this.chkShowFilterCondition.ForeColor = System.Drawing.SystemColors.ControlText;
			this.chkShowFilterCondition.Location = new System.Drawing.Point(264, 316);
			this.chkShowFilterCondition.Name = "chkShowFilterCondition";
			this.chkShowFilterCondition.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.chkShowFilterCondition.Size = new System.Drawing.Size(127, 19);
			this.chkShowFilterCondition.TabIndex = 9;
			this.chkShowFilterCondition.TabStop = true;
			this.chkShowFilterCondition.Text = "Show Filter Condition";
			this.chkShowFilterCondition.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkShowFilterCondition.Visible = true;
			// 
			// chkShow
			// 
			this.chkShow.AllowDrop = true;
			this.chkShow.Appearance = System.Windows.Forms.Appearance.Normal;
			this.chkShow.BackColor = System.Drawing.SystemColors.Control;
			this.chkShow.CausesValidation = true;
			this.chkShow.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkShow.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this.chkShow.Enabled = true;
			this.chkShow.ForeColor = System.Drawing.SystemColors.ControlText;
			this.chkShow.Location = new System.Drawing.Point(93, 316);
			this.chkShow.Name = "chkShow";
			this.chkShow.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.chkShow.Size = new System.Drawing.Size(55, 19);
			this.chkShow.TabIndex = 7;
			this.chkShow.TabStop = true;
			this.chkShow.Text = "Show";
			this.chkShow.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkShow.Visible = true;
			// 
			// chkProtected
			// 
			this.chkProtected.AllowDrop = true;
			this.chkProtected.Appearance = System.Windows.Forms.Appearance.Normal;
			this.chkProtected.BackColor = System.Drawing.SystemColors.Control;
			this.chkProtected.CausesValidation = true;
			this.chkProtected.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkProtected.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this.chkProtected.Enabled = true;
			this.chkProtected.ForeColor = System.Drawing.SystemColors.ControlText;
			this.chkProtected.Location = new System.Drawing.Point(174, 316);
			this.chkProtected.Name = "chkProtected";
			this.chkProtected.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.chkProtected.Size = new System.Drawing.Size(73, 19);
			this.chkProtected.TabIndex = 8;
			this.chkProtected.TabStop = true;
			this.chkProtected.Text = "Protected";
			this.chkProtected.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkProtected.Visible = true;
			// 
			// txtFromClause
			// 
			this.txtFromClause.AcceptsReturn = true;
			this.txtFromClause.AllowDrop = true;
			this.txtFromClause.BackColor = System.Drawing.SystemColors.Window;
			this.txtFromClause.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtFromClause.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtFromClause.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtFromClause.Location = new System.Drawing.Point(90, 103);
			this.txtFromClause.MaxLength = 0;
			this.txtFromClause.Multiline = true;
			this.txtFromClause.Name = "txtFromClause";
			this.txtFromClause.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtFromClause.Size = new System.Drawing.Size(633, 118);
			this.txtFromClause.TabIndex = 3;
			// 
			// lblVariableDeclaration
			// 
			this.lblVariableDeclaration.AllowDrop = true;
			this.lblVariableDeclaration.BackColor = System.Drawing.SystemColors.Window;
			this.lblVariableDeclaration.Text = "Variable Decla.";
			this.lblVariableDeclaration.Location = new System.Drawing.Point(9, 289);
			this.lblVariableDeclaration.Name = "lblVariableDeclaration";
			this.lblVariableDeclaration.Size = new System.Drawing.Size(71, 13);
			this.lblVariableDeclaration.TabIndex = 13;
			// 
			// txtOrderByClause
			// 
			this.txtOrderByClause.AllowDrop = true;
			this.txtOrderByClause.BackColor = System.Drawing.Color.White;
			this.txtOrderByClause.ForeColor = System.Drawing.Color.Black;
			this.txtOrderByClause.Location = new System.Drawing.Point(90, 262);
			// this.txtOrderByClause.mDropDownType = (System.Windows.Forms.TextBox.DropDownTypes) 0;
			this.txtOrderByClause.Name = "txtOrderByClause";
			this.txtOrderByClause.Size = new System.Drawing.Size(633, 19);
			this.txtOrderByClause.TabIndex = 5;
			this.txtOrderByClause.Text = "";
			// 
			// txtWhereClause
			// 
			this.txtWhereClause.AllowDrop = true;
			this.txtWhereClause.BackColor = System.Drawing.Color.White;
			this.txtWhereClause.ForeColor = System.Drawing.Color.Black;
			this.txtWhereClause.Location = new System.Drawing.Point(90, 238);
			// this.txtWhereClause.mDropDownType = (System.Windows.Forms.TextBox.DropDownTypes) 0;
			this.txtWhereClause.Name = "txtWhereClause";
			this.txtWhereClause.Size = new System.Drawing.Size(633, 19);
			this.txtWhereClause.TabIndex = 4;
			this.txtWhereClause.Text = "";
			// 
			// txtChildFormId
			// 
			this.txtChildFormId.AllowDrop = true;
			this.txtChildFormId.BackColor = System.Drawing.Color.White;
			this.txtChildFormId.ForeColor = System.Drawing.Color.Black;
			this.txtChildFormId.Location = new System.Drawing.Point(603, 68);
			// this.txtChildFormId.mDropDownType = (System.Windows.Forms.TextBox.DropDownTypes) 0;
			this.txtChildFormId.Name = "txtChildFormId";
			this.txtChildFormId.Size = new System.Drawing.Size(117, 19);
			this.txtChildFormId.TabIndex = 14;
			this.txtChildFormId.Text = "";
			// 
			// txtChildReportId2
			// 
			this.txtChildReportId2.AllowDrop = true;
			this.txtChildReportId2.BackColor = System.Drawing.Color.White;
			this.txtChildReportId2.ForeColor = System.Drawing.Color.Black;
			this.txtChildReportId2.Location = new System.Drawing.Point(309, 70);
			// this.txtChildReportId2.mDropDownType = (System.Windows.Forms.TextBox.DropDownTypes) 0;
			this.txtChildReportId2.Name = "txtChildReportId2";
			this.txtChildReportId2.Size = new System.Drawing.Size(113, 19);
			this.txtChildReportId2.TabIndex = 2;
			this.txtChildReportId2.Text = "";
			// 
			// txtChildReportId
			// 
			this.txtChildReportId.AllowDrop = true;
			this.txtChildReportId.BackColor = System.Drawing.Color.White;
			this.txtChildReportId.ForeColor = System.Drawing.Color.Black;
			this.txtChildReportId.Location = new System.Drawing.Point(90, 70);
			// this.txtChildReportId.mDropDownType = (System.Windows.Forms.TextBox.DropDownTypes) 0;
			this.txtChildReportId.Name = "txtChildReportId";
			this.txtChildReportId.Size = new System.Drawing.Size(113, 19);
			this.txtChildReportId.TabIndex = 1;
			this.txtChildReportId.Text = "";
			// 
			// lblOrderByClause
			// 
			this.lblOrderByClause.AllowDrop = true;
			this.lblOrderByClause.BackColor = System.Drawing.SystemColors.Window;
			this.lblOrderByClause.Text = "Order By Clause";
			this.lblOrderByClause.Location = new System.Drawing.Point(9, 265);
			this.lblOrderByClause.Name = "lblOrderByClause";
			this.lblOrderByClause.Size = new System.Drawing.Size(78, 13);
			this.lblOrderByClause.TabIndex = 15;
			// 
			// lblWhereClause
			// 
			this.lblWhereClause.AllowDrop = true;
			this.lblWhereClause.BackColor = System.Drawing.SystemColors.Window;
			this.lblWhereClause.Text = "Where Clause";
			this.lblWhereClause.Location = new System.Drawing.Point(9, 241);
			this.lblWhereClause.Name = "lblWhereClause";
			this.lblWhereClause.Size = new System.Drawing.Size(67, 13);
			this.lblWhereClause.TabIndex = 16;
			// 
			// lblFromClause
			// 
			this.lblFromClause.AllowDrop = true;
			this.lblFromClause.BackColor = System.Drawing.SystemColors.Window;
			this.lblFromClause.Text = "From Clause";
			this.lblFromClause.Location = new System.Drawing.Point(9, 103);
			this.lblFromClause.Name = "lblFromClause";
			this.lblFromClause.Size = new System.Drawing.Size(59, 13);
			this.lblFromClause.TabIndex = 17;
			// 
			// lblChildReportId
			// 
			this.lblChildReportId.AllowDrop = true;
			this.lblChildReportId.BackColor = System.Drawing.SystemColors.Window;
			this.lblChildReportId.Text = "Child Report Id";
			this.lblChildReportId.Location = new System.Drawing.Point(9, 71);
			this.lblChildReportId.Name = "lblChildReportId";
			this.lblChildReportId.Size = new System.Drawing.Size(72, 13);
			this.lblChildReportId.TabIndex = 18;
			// 
			// lblChildReportId2
			// 
			this.lblChildReportId2.AllowDrop = true;
			this.lblChildReportId2.BackColor = System.Drawing.SystemColors.Window;
			this.lblChildReportId2.Text = "Child Report Id-2";
			this.lblChildReportId2.Location = new System.Drawing.Point(219, 71);
			this.lblChildReportId2.Name = "lblChildReportId2";
			this.lblChildReportId2.Size = new System.Drawing.Size(82, 13);
			this.lblChildReportId2.TabIndex = 19;
			// 
			// lblChildFormId
			// 
			this.lblChildFormId.AllowDrop = true;
			this.lblChildFormId.BackColor = System.Drawing.SystemColors.Window;
			this.lblChildFormId.Text = "Child Form Id";
			this.lblChildFormId.Location = new System.Drawing.Point(531, 71);
			this.lblChildFormId.Name = "lblChildFormId";
			this.lblChildFormId.Size = new System.Drawing.Size(63, 13);
			this.lblChildFormId.TabIndex = 20;
			// 
			// txtLReportName
			// 
			this.txtLReportName.AllowDrop = true;
			this.txtLReportName.BackColor = System.Drawing.Color.White;
			this.txtLReportName.ForeColor = System.Drawing.Color.Black;
			this.txtLReportName.Location = new System.Drawing.Point(309, 34);
			// this.txtLReportName.mDropDownType = (System.Windows.Forms.TextBox.DropDownTypes) 0;
			this.txtLReportName.Name = "txtLReportName";
			this.txtLReportName.Size = new System.Drawing.Size(411, 19);
			this.txtLReportName.TabIndex = 0;
			this.txtLReportName.Text = "";
			// 
			// lblL_Report_Name
			// 
			this.lblL_Report_Name.AllowDrop = true;
			this.lblL_Report_Name.BackColor = System.Drawing.SystemColors.Window;
			this.lblL_Report_Name.Text = "L_Report_Name";
			this.lblL_Report_Name.Location = new System.Drawing.Point(219, 37);
			this.lblL_Report_Name.Name = "lblL_Report_Name";
			this.lblL_Report_Name.Size = new System.Drawing.Size(77, 13);
			this.lblL_Report_Name.TabIndex = 21;
			// 
			// lblReportId
			// 
			this.lblReportId.AllowDrop = true;
			this.lblReportId.BackColor = System.Drawing.SystemColors.Window;
			this.lblReportId.Text = "Report Id ";
			this.lblReportId.Location = new System.Drawing.Point(9, 37);
			this.lblReportId.Name = "lblReportId";
			this.lblReportId.Size = new System.Drawing.Size(49, 13);
			this.lblReportId.TabIndex = 22;
			// 
			// txtReportID
			// 
			this.txtReportID.AllowDrop = true;
			this.txtReportID.Location = new System.Drawing.Point(90, 34);
			this.txtReportID.Name = "txtReportID";
			this.txtReportID.Size = new System.Drawing.Size(113, 19);
			this.txtReportID.TabIndex = 34;
			// 
			// _tabProductDetails_TabPage1
			// 
			this._tabProductDetails_TabPage1.Controls.Add(this.grdVoucherDetails);
			this._tabProductDetails_TabPage1.Text = "System Reports Details";
			// 
			// grdVoucherDetails
			// 
			this.grdVoucherDetails.AllowAddNew = true;
			this.grdVoucherDetails.AllowDelete = true;
			this.grdVoucherDetails.AllowDrop = true;
			this.grdVoucherDetails.BackColor = System.Drawing.Color.Silver;
			this.grdVoucherDetails.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.grdVoucherDetails.CellTipsWidth = 0;
			this.grdVoucherDetails.Location = new System.Drawing.Point(6, 10);
			this.grdVoucherDetails.Name = "grdVoucherDetails";
			this.grdVoucherDetails.RowDivider.Color = System.Drawing.Color.Silver;
			this.grdVoucherDetails.Size = new System.Drawing.Size(717, 346);
			this.grdVoucherDetails.TabIndex = 33;
			// 
			// _tabProductDetails_TabPage2
			// 
			this._tabProductDetails_TabPage2.Text = "Addtional Details";
			// 
			// frmSysReportDesignUtility
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.SystemColors.Control;
			this.ClientSize = new System.Drawing.Size(741, 442);
			this.Controls.Add(this.picFormToolbar);
			this.Controls.Add(this.tabProductDetails);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			//this.Icon = (System.Drawing.Icon) resources.GetObject("frmSysReportDesignUtility.Icon");
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(20, 112);
			this.MaximizeBox = false;
			this.MinimizeBox = true;
			this.Name = "frmSysReportDesignUtility";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Report Design Utilities";
			UpgradeHelpers.Gui.SSTabHelper.SetSelectedIndex(this.tabProductDetails, 2);
			// this.Activated += new System.EventHandler(this.frmSysReportDesignUtility_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
			//((System.ComponentModel.ISupportInitialize) this._btnFormToolBar_0).EndInit();
			//((System.ComponentModel.ISupportInitialize) this._btnFormToolBar_1).EndInit();
			//((System.ComponentModel.ISupportInitialize) this._btnFormToolBar_5).EndInit();
			//((System.ComponentModel.ISupportInitialize) this._btnFormToolBar_2).EndInit();
			//((System.ComponentModel.ISupportInitialize) this._btnFormToolBar_3).EndInit();
			//((System.ComponentModel.ISupportInitialize) this._btnFormToolBar_6).EndInit();
			//((System.ComponentModel.ISupportInitialize) this._btnFormToolBar_8).EndInit();
			//((System.ComponentModel.ISupportInitialize) this._btnFormToolBar_4).EndInit();
			//((System.ComponentModel.ISupportInitialize) this._btnFormToolBar_7).EndInit();
			this.picFormToolbar.ResumeLayout(false);
			this.tabProductDetails.ResumeLayout(false);
			this._tabProductDetails_TabPage0.ResumeLayout(false);
			this._tabProductDetails_TabPage1.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		// 
		void InitializebtnFormToolBar()
		{
			this.btnFormToolBar = new AxSmartNetButtonProject.AxSmartNetButton[9];
			this.btnFormToolBar[0] = _btnFormToolBar_0;
			this.btnFormToolBar[1] = _btnFormToolBar_1;
			this.btnFormToolBar[5] = _btnFormToolBar_5;
			this.btnFormToolBar[2] = _btnFormToolBar_2;
			this.btnFormToolBar[3] = _btnFormToolBar_3;
			this.btnFormToolBar[6] = _btnFormToolBar_6;
			this.btnFormToolBar[8] = _btnFormToolBar_8;
			this.btnFormToolBar[4] = _btnFormToolBar_4;
			this.btnFormToolBar[7] = _btnFormToolBar_7;
		}
		#endregion
	}
}//ENDSHERE
