
namespace Xtreme
{
	partial class frmSysReportOptions
	{

		#region "Upgrade Support "
		private static frmSysReportOptions m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmSysReportOptions DefInstance
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
		public static frmSysReportOptions CreateInstance()
		{
			frmSysReportOptions theInstance = new frmSysReportOptions();
			
			return theInstance;
		}
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "chkShowFooter", "chkRowsInAlternateColor", "chkShowHorizontalLine", "chkShowVerticleLine", "chkShowDoubleReportHeader", "chkShowDoubleCoumnHeader", "frmHeader", "cmdItalic", "cmdBold", "cmdColor", "cmdUnderline", "rtbFooter", "TabControlPage1", "Column_0_grdReportFormats", "Column_1_grdReportFormats", "grdReportFormats", "Column_0_cmbFormatList", "Column_1_cmbFormatList", "cmbFormatList", "tabFormat", "_txtDateRange_0", "_lblCommon_1", "_lblCommon_2", "_txtDateRange_1", "fraDateRange", "Column_0_grdReportFilters", "Column_1_grdReportFilters", "grdReportFilters", "Column_0_cmbFilterList", "Column_1_cmbFilterList", "cmbFilterList", "tabFilters", "chkShowAll", "chkAdvancedOptions", "Column_0_grdReportFields", "Column_1_grdReportFields", "grdReportFields", "Column_0_cmbFieldList", "Column_1_cmbFieldList", "cmbFieldList", "UpDown", "tabFields", "tabReportOptions", "cdgGetFontWindowFont", "cdgGetFontWindowColor", "cdgGetFontWindow", "txtReportName", "_lblCommon_0", "txtTempDate", "_lblCommon_3", "tcbSystemForm", "lblCommon", "txtDateRange"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public System.Windows.Forms.CheckBox chkShowFooter;
		public System.Windows.Forms.CheckBox chkRowsInAlternateColor;
		public System.Windows.Forms.CheckBox chkShowHorizontalLine;
		public System.Windows.Forms.CheckBox chkShowVerticleLine;
		public System.Windows.Forms.CheckBox chkShowDoubleReportHeader;
		public System.Windows.Forms.CheckBox chkShowDoubleCoumnHeader;
		public System.Windows.Forms.GroupBox frmHeader;
		public System.Windows.Forms.Button cmdItalic;
		public System.Windows.Forms.Button cmdBold;
		public System.Windows.Forms.Button cmdColor;
		public System.Windows.Forms.Button cmdUnderline;
		public System.Windows.Forms.RichTextBox rtbFooter;
		public AxXtremeSuiteControls.AxTabControlPage TabControlPage1;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_0_grdReportFormats;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_1_grdReportFormats;
		public C1.Win.C1TrueDBGrid.C1TrueDBGrid grdReportFormats;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_0_cmbFormatList;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_1_cmbFormatList;
		public C1.Win.C1TrueDBGrid.C1TrueDBDropdown cmbFormatList;
		public AxXtremeSuiteControls.AxTabControlPage tabFormat;
		private Syncfusion.WinForms.Input.SfDateTimeEdit _txtDateRange_0;
		private System.Windows.Forms.Label _lblCommon_1;
		private System.Windows.Forms.Label _lblCommon_2;
		private Syncfusion.WinForms.Input.SfDateTimeEdit _txtDateRange_1;
		public System.Windows.Forms.GroupBox fraDateRange;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_0_grdReportFilters;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_1_grdReportFilters;
		public C1.Win.C1TrueDBGrid.C1TrueDBGrid grdReportFilters;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_0_cmbFilterList;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_1_cmbFilterList;
		public C1.Win.C1TrueDBGrid.C1TrueDBDropdown cmbFilterList;
		public AxXtremeSuiteControls.AxTabControlPage tabFilters;
		public System.Windows.Forms.CheckBox chkShowAll;
		public System.Windows.Forms.CheckBox chkAdvancedOptions;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_0_grdReportFields;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_1_grdReportFields;
		public C1.Win.C1TrueDBGrid.C1TrueDBGrid grdReportFields;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_0_cmbFieldList;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_1_cmbFieldList;
		public C1.Win.C1TrueDBGrid.C1TrueDBDropdown cmbFieldList;
		public AxXtremeSuiteControls.AxUpDown UpDown;
		public AxXtremeSuiteControls.AxTabControlPage tabFields;
		public AxXtremeSuiteControls.AxTabControl tabReportOptions;
		public System.Windows.Forms.FontDialog cdgGetFontWindowFont;
		public System.Windows.Forms.ColorDialog cdgGetFontWindowColor;
		public UpgradeStubs.AxMSComDlg_AxCommonDialog cdgGetFontWindow;
		public System.Windows.Forms.TextBox txtReportName;
		private System.Windows.Forms.Label _lblCommon_0;
		public Syncfusion.WinForms.Input.SfDateTimeEdit txtTempDate;
		private System.Windows.Forms.Label _lblCommon_3;
		public Syncfusion.Windows.Forms.Tools.CommandBarController tcbSystemForm;
		public System.Windows.Forms.Label[] lblCommon = new System.Windows.Forms.Label[4];
		public Syncfusion.WinForms.Input.SfDateTimeEdit[] txtDateRange = new Syncfusion.WinForms.Input.SfDateTimeEdit[2];
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSysReportOptions));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this.frmHeader = new System.Windows.Forms.GroupBox();
			this.chkShowFooter = new System.Windows.Forms.CheckBox();
			this.chkRowsInAlternateColor = new System.Windows.Forms.CheckBox();
			this.chkShowHorizontalLine = new System.Windows.Forms.CheckBox();
			this.chkShowVerticleLine = new System.Windows.Forms.CheckBox();
			this.chkShowDoubleReportHeader = new System.Windows.Forms.CheckBox();
			this.chkShowDoubleCoumnHeader = new System.Windows.Forms.CheckBox();
			this.tabReportOptions = new AxXtremeSuiteControls.AxTabControl();
			this.TabControlPage1 = new AxXtremeSuiteControls.AxTabControlPage();
			this.cmdItalic = new System.Windows.Forms.Button();
			this.cmdBold = new System.Windows.Forms.Button();
			this.cmdColor = new System.Windows.Forms.Button();
			this.cmdUnderline = new System.Windows.Forms.Button();
			this.rtbFooter = new System.Windows.Forms.RichTextBox();
			this.tabFormat = new AxXtremeSuiteControls.AxTabControlPage();
			this.grdReportFormats = new C1.Win.C1TrueDBGrid.C1TrueDBGrid();
			this.Column_0_grdReportFormats = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.Column_1_grdReportFormats = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.cmbFormatList = new C1.Win.C1TrueDBGrid.C1TrueDBDropdown();
			this.Column_0_cmbFormatList = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.Column_1_cmbFormatList = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.tabFilters = new AxXtremeSuiteControls.AxTabControlPage();
			this.fraDateRange = new System.Windows.Forms.GroupBox();
			this._txtDateRange_0 = new Syncfusion.WinForms.Input.SfDateTimeEdit();
			this._lblCommon_1 = new System.Windows.Forms.Label();
			this._lblCommon_2 = new System.Windows.Forms.Label();
			this._txtDateRange_1 = new Syncfusion.WinForms.Input.SfDateTimeEdit();
			this.grdReportFilters = new C1.Win.C1TrueDBGrid.C1TrueDBGrid();
			this.Column_0_grdReportFilters = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.Column_1_grdReportFilters = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.cmbFilterList = new C1.Win.C1TrueDBGrid.C1TrueDBDropdown();
			this.Column_0_cmbFilterList = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.Column_1_cmbFilterList = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.tabFields = new AxXtremeSuiteControls.AxTabControlPage();
			this.chkShowAll = new System.Windows.Forms.CheckBox();
			this.chkAdvancedOptions = new System.Windows.Forms.CheckBox();
			this.grdReportFields = new C1.Win.C1TrueDBGrid.C1TrueDBGrid();
			this.Column_0_grdReportFields = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.Column_1_grdReportFields = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.cmbFieldList = new C1.Win.C1TrueDBGrid.C1TrueDBDropdown();
			this.Column_0_cmbFieldList = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.Column_1_cmbFieldList = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.UpDown = new AxXtremeSuiteControls.AxUpDown();
			this.cdgGetFontWindowFont = new System.Windows.Forms.FontDialog();
			this.cdgGetFontWindowColor = new System.Windows.Forms.ColorDialog();
			this.cdgGetFontWindow = new UpgradeStubs.AxMSComDlg_AxCommonDialog();
			this.txtReportName = new System.Windows.Forms.TextBox();
			this._lblCommon_0 = new System.Windows.Forms.Label();
			this.txtTempDate = new Syncfusion.WinForms.Input.SfDateTimeEdit();
			this._lblCommon_3 = new System.Windows.Forms.Label();
			this.tcbSystemForm = new Syncfusion.Windows.Forms.Tools.CommandBarController();
			// //((System.ComponentModel.ISupportInitialize) this.TabControlPage1).BeginInit();
			// //((System.ComponentModel.ISupportInitialize) this.tabFormat).BeginInit();
			// //((System.ComponentModel.ISupportInitialize) this.tabFilters).BeginInit();
			// //((System.ComponentModel.ISupportInitialize) this.UpDown).BeginInit();
			// //((System.ComponentModel.ISupportInitialize) this.tabFields).BeginInit();
			// //((System.ComponentModel.ISupportInitialize) this.tabReportOptions).BeginInit();
			// //((System.ComponentModel.ISupportInitialize) this.txtTempDate).BeginInit();
			// //((System.ComponentModel.ISupportInitialize) this.tcbSystemForm).BeginInit();
			this.frmHeader.SuspendLayout();
			this.tabReportOptions.SuspendLayout();
			this.TabControlPage1.SuspendLayout();
			this.tabFormat.SuspendLayout();
			this.grdReportFormats.SuspendLayout();
			this.cmbFormatList.SuspendLayout();
			this.tabFilters.SuspendLayout();
			this.fraDateRange.SuspendLayout();
			this.grdReportFilters.SuspendLayout();
			this.cmbFilterList.SuspendLayout();
			this.tabFields.SuspendLayout();
			this.grdReportFields.SuspendLayout();
			this.cmbFieldList.SuspendLayout();
			this.SuspendLayout();
			// 
			// frmHeader
			// 
			this.frmHeader.AllowDrop = true;
			this.frmHeader.BackColor = System.Drawing.Color.FromArgb(216, 231, 252);
			this.frmHeader.Controls.Add(this.chkShowFooter);
			this.frmHeader.Controls.Add(this.chkRowsInAlternateColor);
			this.frmHeader.Controls.Add(this.chkShowHorizontalLine);
			this.frmHeader.Controls.Add(this.chkShowVerticleLine);
			this.frmHeader.Controls.Add(this.chkShowDoubleReportHeader);
			this.frmHeader.Controls.Add(this.chkShowDoubleCoumnHeader);
			this.frmHeader.Enabled = true;
			this.frmHeader.ForeColor = System.Drawing.SystemColors.ControlText;
			this.frmHeader.Location = new System.Drawing.Point(10, 72);
			this.frmHeader.Name = "frmHeader";
			this.frmHeader.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.frmHeader.Size = new System.Drawing.Size(453, 75);
			this.frmHeader.TabIndex = 21;
			this.frmHeader.Visible = true;
			// 
			// chkShowFooter
			// 
			this.chkShowFooter.AllowDrop = true;
			this.chkShowFooter.Appearance = System.Windows.Forms.Appearance.Normal;
			this.chkShowFooter.BackColor = System.Drawing.Color.FromArgb(216, 231, 252);
			this.chkShowFooter.CausesValidation = true;
			this.chkShowFooter.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkShowFooter.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this.chkShowFooter.Enabled = true;
			this.chkShowFooter.ForeColor = System.Drawing.SystemColors.ControlText;
			this.chkShowFooter.Location = new System.Drawing.Point(214, 20);
			this.chkShowFooter.Name = "chkShowFooter";
			this.chkShowFooter.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.chkShowFooter.Size = new System.Drawing.Size(161, 15);
			this.chkShowFooter.TabIndex = 34;
			this.chkShowFooter.TabStop = true;
			this.chkShowFooter.Text = "Show Footer";
			this.chkShowFooter.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkShowFooter.Visible = true;
			// 
			// chkRowsInAlternateColor
			// 
			this.chkRowsInAlternateColor.AllowDrop = true;
			this.chkRowsInAlternateColor.Appearance = System.Windows.Forms.Appearance.Normal;
			this.chkRowsInAlternateColor.BackColor = System.Drawing.Color.FromArgb(216, 231, 252);
			this.chkRowsInAlternateColor.CausesValidation = true;
			this.chkRowsInAlternateColor.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkRowsInAlternateColor.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this.chkRowsInAlternateColor.Enabled = true;
			this.chkRowsInAlternateColor.ForeColor = System.Drawing.SystemColors.ControlText;
			this.chkRowsInAlternateColor.Location = new System.Drawing.Point(26, 20);
			this.chkRowsInAlternateColor.Name = "chkRowsInAlternateColor";
			this.chkRowsInAlternateColor.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.chkRowsInAlternateColor.Size = new System.Drawing.Size(161, 15);
			this.chkRowsInAlternateColor.TabIndex = 26;
			this.chkRowsInAlternateColor.TabStop = true;
			this.chkRowsInAlternateColor.Text = "Show Rows in Alternate Color";
			this.chkRowsInAlternateColor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkRowsInAlternateColor.Visible = true;
			// 
			// chkShowHorizontalLine
			// 
			this.chkShowHorizontalLine.AllowDrop = true;
			this.chkShowHorizontalLine.Appearance = System.Windows.Forms.Appearance.Normal;
			this.chkShowHorizontalLine.BackColor = System.Drawing.Color.FromArgb(216, 231, 252);
			this.chkShowHorizontalLine.CausesValidation = true;
			this.chkShowHorizontalLine.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkShowHorizontalLine.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this.chkShowHorizontalLine.Enabled = true;
			this.chkShowHorizontalLine.ForeColor = System.Drawing.SystemColors.ControlText;
			this.chkShowHorizontalLine.Location = new System.Drawing.Point(214, 56);
			this.chkShowHorizontalLine.Name = "chkShowHorizontalLine";
			this.chkShowHorizontalLine.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.chkShowHorizontalLine.Size = new System.Drawing.Size(123, 15);
			this.chkShowHorizontalLine.TabIndex = 25;
			this.chkShowHorizontalLine.TabStop = true;
			this.chkShowHorizontalLine.Text = "Show Horizontal Line";
			this.chkShowHorizontalLine.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkShowHorizontalLine.Visible = true;
			// 
			// chkShowVerticleLine
			// 
			this.chkShowVerticleLine.AllowDrop = true;
			this.chkShowVerticleLine.Appearance = System.Windows.Forms.Appearance.Normal;
			this.chkShowVerticleLine.BackColor = System.Drawing.Color.FromArgb(216, 231, 252);
			this.chkShowVerticleLine.CausesValidation = true;
			this.chkShowVerticleLine.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkShowVerticleLine.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this.chkShowVerticleLine.Enabled = true;
			this.chkShowVerticleLine.ForeColor = System.Drawing.SystemColors.ControlText;
			this.chkShowVerticleLine.Location = new System.Drawing.Point(214, 38);
			this.chkShowVerticleLine.Name = "chkShowVerticleLine";
			this.chkShowVerticleLine.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.chkShowVerticleLine.Size = new System.Drawing.Size(123, 15);
			this.chkShowVerticleLine.TabIndex = 24;
			this.chkShowVerticleLine.TabStop = true;
			this.chkShowVerticleLine.Text = "Show Verticle Line";
			this.chkShowVerticleLine.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkShowVerticleLine.Visible = true;
			// 
			// chkShowDoubleReportHeader
			// 
			this.chkShowDoubleReportHeader.AllowDrop = true;
			this.chkShowDoubleReportHeader.Appearance = System.Windows.Forms.Appearance.Normal;
			this.chkShowDoubleReportHeader.BackColor = System.Drawing.Color.FromArgb(216, 231, 252);
			this.chkShowDoubleReportHeader.CausesValidation = true;
			this.chkShowDoubleReportHeader.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkShowDoubleReportHeader.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this.chkShowDoubleReportHeader.Enabled = true;
			this.chkShowDoubleReportHeader.ForeColor = System.Drawing.SystemColors.ControlText;
			this.chkShowDoubleReportHeader.Location = new System.Drawing.Point(26, 56);
			this.chkShowDoubleReportHeader.Name = "chkShowDoubleReportHeader";
			this.chkShowDoubleReportHeader.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.chkShowDoubleReportHeader.Size = new System.Drawing.Size(123, 15);
			this.chkShowDoubleReportHeader.TabIndex = 23;
			this.chkShowDoubleReportHeader.TabStop = true;
			this.chkShowDoubleReportHeader.Text = "Show Double Header";
			this.chkShowDoubleReportHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkShowDoubleReportHeader.Visible = true;
			// 
			// chkShowDoubleCoumnHeader
			// 
			this.chkShowDoubleCoumnHeader.AllowDrop = true;
			this.chkShowDoubleCoumnHeader.Appearance = System.Windows.Forms.Appearance.Normal;
			this.chkShowDoubleCoumnHeader.BackColor = System.Drawing.Color.FromArgb(216, 231, 252);
			this.chkShowDoubleCoumnHeader.CausesValidation = true;
			this.chkShowDoubleCoumnHeader.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkShowDoubleCoumnHeader.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this.chkShowDoubleCoumnHeader.Enabled = true;
			this.chkShowDoubleCoumnHeader.ForeColor = System.Drawing.SystemColors.ControlText;
			this.chkShowDoubleCoumnHeader.Location = new System.Drawing.Point(26, 38);
			this.chkShowDoubleCoumnHeader.Name = "chkShowDoubleCoumnHeader";
			this.chkShowDoubleCoumnHeader.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.chkShowDoubleCoumnHeader.Size = new System.Drawing.Size(161, 15);
			this.chkShowDoubleCoumnHeader.TabIndex = 22;
			this.chkShowDoubleCoumnHeader.TabStop = true;
			this.chkShowDoubleCoumnHeader.Text = "Show Double Column Header";
			this.chkShowDoubleCoumnHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkShowDoubleCoumnHeader.Visible = true;
			// 
			// tabReportOptions
			// 
			this.tabReportOptions.AllowDrop = true;
			this.tabReportOptions.Controls.Add(this.TabControlPage1);
			this.tabReportOptions.Controls.Add(this.tabFormat);
			this.tabReportOptions.Controls.Add(this.tabFilters);
			this.tabReportOptions.Controls.Add(this.tabFields);
			this.tabReportOptions.Location = new System.Drawing.Point(8, 150);
			this.tabReportOptions.Name = "tabReportOptions";
			("tabReportOptions.OcxState");
			this.tabReportOptions.Size = new System.Drawing.Size(455, 261);
			this.tabReportOptions.TabIndex = 2;
			this.tabReportOptions.SelectedChanged += new AxXtremeSuiteControls._DTabControlEvents_SelectedChangedEventHandler(this.tabReportOptions_SelectedChanged);
			// 
			// TabControlPage1
			// 
			this.TabControlPage1.AllowDrop = true;
			this.TabControlPage1.Controls.Add(this.cmdItalic);
			this.TabControlPage1.Controls.Add(this.cmdBold);
			this.TabControlPage1.Controls.Add(this.cmdColor);
			this.TabControlPage1.Controls.Add(this.cmdUnderline);
			this.TabControlPage1.Controls.Add(this.rtbFooter);
			this.TabControlPage1.Location = new System.Drawing.Point(-4664, 26);
			this.TabControlPage1.Name = "TabControlPage1";
			("TabControlPage1.OcxState");
			this.TabControlPage1.Size = new System.Drawing.Size(451, 233);
			this.TabControlPage1.TabIndex = 28;
			this.TabControlPage1.Visible = false;
			// 
			// cmdItalic
			// 
			this.cmdItalic.AllowDrop = true;
			this.cmdItalic.BackColor = System.Drawing.SystemColors.Control;
			this.cmdItalic.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Italic | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 178);
			this.cmdItalic.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdItalic.Location = new System.Drawing.Point(38, 4);
			this.cmdItalic.Name = "cmdItalic";
			this.cmdItalic.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdItalic.Size = new System.Drawing.Size(31, 23);
			this.cmdItalic.TabIndex = 33;
			this.cmdItalic.Text = "I";
			this.cmdItalic.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.cmdItalic.UseVisualStyleBackColor = false;
			// this.cmdItalic.Click += new System.EventHandler(this.cmdItalic_Click);
			// 
			// cmdBold
			// 
			this.cmdBold.AllowDrop = true;
			this.cmdBold.BackColor = System.Drawing.SystemColors.Control;
			this.cmdBold.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 178);
			this.cmdBold.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdBold.Location = new System.Drawing.Point(4, 4);
			this.cmdBold.Name = "cmdBold";
			this.cmdBold.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdBold.Size = new System.Drawing.Size(33, 23);
			this.cmdBold.TabIndex = 32;
			this.cmdBold.Text = "B";
			this.cmdBold.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.cmdBold.UseVisualStyleBackColor = false;
			// this.cmdBold.Click += new System.EventHandler(this.cmdBold_Click);
			// 
			// cmdColor
			// 
			this.cmdColor.AllowDrop = true;
			this.cmdColor.BackColor = System.Drawing.SystemColors.Control;
			this.cmdColor.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdColor.Location = new System.Drawing.Point(106, 4);
			this.cmdColor.Name = "cmdColor";
			this.cmdColor.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdColor.Size = new System.Drawing.Size(39, 23);
			this.cmdColor.TabIndex = 31;
			this.cmdColor.Text = "&Color";
			this.cmdColor.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.cmdColor.UseVisualStyleBackColor = false;
			// this.cmdColor.Click += new System.EventHandler(this.cmdColor_Click);
			// 
			// cmdUnderline
			// 
			this.cmdUnderline.AllowDrop = true;
			this.cmdUnderline.BackColor = System.Drawing.SystemColors.Control;
			this.cmdUnderline.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Underline | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 178);
			this.cmdUnderline.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdUnderline.Location = new System.Drawing.Point(72, 4);
			this.cmdUnderline.Name = "cmdUnderline";
			this.cmdUnderline.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdUnderline.Size = new System.Drawing.Size(31, 23);
			this.cmdUnderline.TabIndex = 30;
			this.cmdUnderline.Text = "U";
			this.cmdUnderline.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.cmdUnderline.UseVisualStyleBackColor = false;
			// this.cmdUnderline.Click += new System.EventHandler(this.cmdUnderline_Click);
			// 
			// rtbFooter
			// 
			this.rtbFooter.AllowDrop = true;
			this.rtbFooter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.rtbFooter.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.rtbFooter.Location = new System.Drawing.Point(2, 28);
			this.rtbFooter.Name = "rtbFooter";
			this.rtbFooter.Rtf = resources.GetString("rtbFooter.TextRTF");
			this.rtbFooter.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Both;
			this.rtbFooter.Size = new System.Drawing.Size(447, 203);
			this.rtbFooter.TabIndex = 29;
			// 
			// tabFormat
			// 
			this.tabFormat.AllowDrop = true;
			this.tabFormat.Controls.Add(this.grdReportFormats);
			this.tabFormat.Controls.Add(this.cmbFormatList);
			this.tabFormat.Location = new System.Drawing.Point(-4664, 26);
			this.tabFormat.Name = "tabFormat";
			("tabFormat.OcxState");
			this.tabFormat.Size = new System.Drawing.Size(451, 233);
			this.tabFormat.TabIndex = 5;
			this.tabFormat.Visible = false;
			// 
			// grdReportFormats
			// 
			this.grdReportFormats.AllowDrop = true;
			this.grdReportFormats.BackColor = System.Drawing.Color.FromArgb(236, 233, 216);
			this.grdReportFormats.CellTipsWidth = 0;
			this.grdReportFormats.Location = new System.Drawing.Point(4, 2);
			this.grdReportFormats.Name = "grdReportFormats";
			this.grdReportFormats.RowDivider.Color = System.Drawing.Color.FromArgb(236, 233, 216);
			this.grdReportFormats.Size = new System.Drawing.Size(441, 223);
			this.grdReportFormats.TabIndex = 16;
			this.grdReportFormats.Columns.Add(this.Column_0_grdReportFormats);
			this.grdReportFormats.Columns.Add(this.Column_1_grdReportFormats);
			this.grdReportFormats.BeforeColEdit += new C1.Win.C1TrueDBGrid.BeforeColEditEventHandler(this.grdReportFormats_BeforeColEdit);
			this.grdReportFormats.BeforeRowColChange += new C1.Win.C1TrueDBGrid.CancelEventHandler(this.grdReportFormats_BeforeRowColChange);
			this.grdReportFormats.ButtonClick += new C1.Win.C1TrueDBGrid.ColEventHandler(this.grdReportFormats_ButtonClick);
			// this.this.grdReportFormats.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.grdReportFormats_KeyPress);
			this.grdReportFormats.MouseUp += new System.Windows.Forms.MouseEventHandler(this.grdReportFormats_MouseUp);
			this.grdReportFormats.RowColChange += new C1.Win.C1TrueDBGrid.RowColChangeEventHandler(this.grdReportFormats_RowColChange);
			// 
			// Column_0_grdReportFormats
			// 
			this.Column_0_grdReportFormats.DataField = "";
			this.Column_0_grdReportFormats.ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.Normal;
			// 
			// Column_1_grdReportFormats
			// 
			this.Column_1_grdReportFormats.DataField = "";
			this.Column_1_grdReportFormats.ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.Normal;
			// 
			// cmbFormatList
			// 
			this.cmbFormatList.AllowDrop = true;
			this.cmbFormatList.ColumnHeaders = true;
			this.cmbFormatList.Enabled = true;
			this.cmbFormatList.Location = new System.Drawing.Point(286, 0);
			this.cmbFormatList.Name = "cmbFormatList";
			this.cmbFormatList.Size = new System.Drawing.Size(67, 71);
			this.cmbFormatList.TabIndex = 17;
			this.cmbFormatList.Columns.Add(this.Column_0_cmbFormatList);
			this.cmbFormatList.Columns.Add(this.Column_1_cmbFormatList);
			// 
			// Column_0_cmbFormatList
			// 
			this.Column_0_cmbFormatList.DataField = "";
			this.Column_0_cmbFormatList.ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.Normal;
			// 
			// Column_1_cmbFormatList
			// 
			this.Column_1_cmbFormatList.DataField = "";
			this.Column_1_cmbFormatList.ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.Normal;
			// 
			// tabFilters
			// 
			this.tabFilters.AllowDrop = true;
			this.tabFilters.Controls.Add(this.fraDateRange);
			this.tabFilters.Controls.Add(this.grdReportFilters);
			this.tabFilters.Controls.Add(this.cmbFilterList);
			this.tabFilters.Location = new System.Drawing.Point(-4664, 26);
			this.tabFilters.Name = "tabFilters";
			("tabFilters.OcxState");
			this.tabFilters.Size = new System.Drawing.Size(451, 233);
			this.tabFilters.TabIndex = 4;
			this.tabFilters.Visible = false;
			// 
			// fraDateRange
			// 
			this.fraDateRange.AllowDrop = true;
			this.fraDateRange.BackColor = System.Drawing.Color.FromArgb(216, 231, 252);
			this.fraDateRange.Controls.Add(this._txtDateRange_0);
			this.fraDateRange.Controls.Add(this._lblCommon_1);
			this.fraDateRange.Controls.Add(this._lblCommon_2);
			this.fraDateRange.Controls.Add(this._txtDateRange_1);
			this.fraDateRange.Enabled = true;
			this.fraDateRange.ForeColor = System.Drawing.SystemColors.ControlText;
			this.fraDateRange.Location = new System.Drawing.Point(8, 2);
			this.fraDateRange.Name = "fraDateRange";
			this.fraDateRange.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.fraDateRange.Size = new System.Drawing.Size(427, 49);
			this.fraDateRange.TabIndex = 6;
			this.fraDateRange.Text = " Date Range ";
			this.fraDateRange.Visible = false;
			// 
			// _txtDateRange_0
			// 
			this._txtDateRange_0.AllowDrop = true;
			this._txtDateRange_0.Location = new System.Drawing.Point(76, 20);
			// this._txtDateRange_0.MaxDate = 2958465;
			// this._txtDateRange_0.MinDate = -657434;
			this._txtDateRange_0.Name = "_txtDateRange_0";
			this._txtDateRange_0.Size = new System.Drawing.Size(101, 19);
			this._txtDateRange_0.TabIndex = 7;
			this._txtDateRange_0.Text = "09-Jun-2019";
			// 
			// _lblCommon_1
			// 
			this._lblCommon_1.AllowDrop = true;
			this._lblCommon_1.BackColor = System.Drawing.Color.FromArgb(216, 231, 252);
			this._lblCommon_1.Text = "From Date";
			this._lblCommon_1.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_1.Location = new System.Drawing.Point(18, 23);
			this._lblCommon_1.Name = "_lblCommon_1";
			this._lblCommon_1.Size = new System.Drawing.Size(49, 13);
			this._lblCommon_1.TabIndex = 8;
			// 
			// _lblCommon_2
			// 
			this._lblCommon_2.AllowDrop = true;
			this._lblCommon_2.BackColor = System.Drawing.Color.FromArgb(216, 231, 252);
			this._lblCommon_2.Text = "To Date";
			this._lblCommon_2.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_2.Location = new System.Drawing.Point(260, 23);
			this._lblCommon_2.Name = "_lblCommon_2";
			this._lblCommon_2.Size = new System.Drawing.Size(39, 13);
			this._lblCommon_2.TabIndex = 9;
			// 
			// _txtDateRange_1
			// 
			this._txtDateRange_1.AllowDrop = true;
			this._txtDateRange_1.Location = new System.Drawing.Point(306, 20);
			// this._txtDateRange_1.MaxDate = 2958465;
			// this._txtDateRange_1.MinDate = -657434;
			this._txtDateRange_1.Name = "_txtDateRange_1";
			this._txtDateRange_1.Size = new System.Drawing.Size(101, 19);
			this._txtDateRange_1.TabIndex = 10;
			this._txtDateRange_1.Text = "09-Jun-2019";
			// 
			// grdReportFilters
			// 
			this.grdReportFilters.AllowDrop = true;
			this.grdReportFilters.BackColor = System.Drawing.Color.FromArgb(236, 233, 216);
			this.grdReportFilters.CellTipsWidth = 0;
			this.grdReportFilters.Location = new System.Drawing.Point(8, 58);
			this.grdReportFilters.Name = "grdReportFilters";
			this.grdReportFilters.RowDivider.Color = System.Drawing.Color.FromArgb(236, 233, 216);
			this.grdReportFilters.Size = new System.Drawing.Size(435, 167);
			this.grdReportFilters.TabIndex = 12;
			this.grdReportFilters.Columns.Add(this.Column_0_grdReportFilters);
			this.grdReportFilters.Columns.Add(this.Column_1_grdReportFilters);
			this.grdReportFilters.BeforeRowColChange += new C1.Win.C1TrueDBGrid.CancelEventHandler(this.grdReportFilters_BeforeRowColChange);
			this.grdReportFilters.RowColChange += new C1.Win.C1TrueDBGrid.RowColChangeEventHandler(this.grdReportFilters_RowColChange);
			// 
			// Column_0_grdReportFilters
			// 
			this.Column_0_grdReportFilters.DataField = "";
			this.Column_0_grdReportFilters.ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.Normal;
			// 
			// Column_1_grdReportFilters
			// 
			this.Column_1_grdReportFilters.DataField = "";
			this.Column_1_grdReportFilters.ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.Normal;
			// 
			// cmbFilterList
			// 
			this.cmbFilterList.AllowDrop = true;
			this.cmbFilterList.ColumnHeaders = true;
			this.cmbFilterList.Enabled = true;
			this.cmbFilterList.Location = new System.Drawing.Point(294, 58);
			this.cmbFilterList.Name = "cmbFilterList";
			this.cmbFilterList.Size = new System.Drawing.Size(67, 71);
			this.cmbFilterList.TabIndex = 13;
			this.cmbFilterList.Columns.Add(this.Column_0_cmbFilterList);
			this.cmbFilterList.Columns.Add(this.Column_1_cmbFilterList);
			// 
			// Column_0_cmbFilterList
			// 
			this.Column_0_cmbFilterList.DataField = "";
			this.Column_0_cmbFilterList.ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.Normal;
			// 
			// Column_1_cmbFilterList
			// 
			this.Column_1_cmbFilterList.DataField = "";
			this.Column_1_cmbFilterList.ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.Normal;
			// 
			// tabFields
			// 
			this.tabFields.AllowDrop = true;
			this.tabFields.Controls.Add(this.chkShowAll);
			this.tabFields.Controls.Add(this.chkAdvancedOptions);
			this.tabFields.Controls.Add(this.grdReportFields);
			this.tabFields.Controls.Add(this.cmbFieldList);
			this.tabFields.Controls.Add(this.UpDown);
			this.tabFields.Location = new System.Drawing.Point(2, 26);
			this.tabFields.Name = "tabFields";
			("tabFields.OcxState");
			this.tabFields.Size = new System.Drawing.Size(451, 233);
			this.tabFields.TabIndex = 3;
			// 
			// chkShowAll
			// 
			this.chkShowAll.AllowDrop = true;
			this.chkShowAll.Appearance = System.Windows.Forms.Appearance.Normal;
			this.chkShowAll.BackColor = System.Drawing.Color.FromArgb(216, 231, 252);
			this.chkShowAll.CausesValidation = true;
			this.chkShowAll.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkShowAll.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this.chkShowAll.Enabled = true;
			this.chkShowAll.ForeColor = System.Drawing.SystemColors.ControlText;
			this.chkShowAll.Location = new System.Drawing.Point(192, 6);
			this.chkShowAll.Name = "chkShowAll";
			this.chkShowAll.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.chkShowAll.Size = new System.Drawing.Size(65, 13);
			this.chkShowAll.TabIndex = 27;
			this.chkShowAll.TabStop = true;
			this.chkShowAll.Text = "Show All";
			this.chkShowAll.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkShowAll.Visible = true;
			this.chkShowAll.CheckStateChanged += new System.EventHandler(this.chkShowAll_CheckStateChanged);
			// 
			// chkAdvancedOptions
			// 
			this.chkAdvancedOptions.AllowDrop = true;
			this.chkAdvancedOptions.Appearance = System.Windows.Forms.Appearance.Normal;
			this.chkAdvancedOptions.BackColor = System.Drawing.Color.FromArgb(216, 231, 252);
			this.chkAdvancedOptions.CausesValidation = true;
			this.chkAdvancedOptions.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkAdvancedOptions.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this.chkAdvancedOptions.Enabled = true;
			this.chkAdvancedOptions.ForeColor = System.Drawing.SystemColors.ControlText;
			this.chkAdvancedOptions.Location = new System.Drawing.Point(6, 6);
			this.chkAdvancedOptions.Name = "chkAdvancedOptions";
			this.chkAdvancedOptions.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.chkAdvancedOptions.Size = new System.Drawing.Size(145, 13);
			this.chkAdvancedOptions.TabIndex = 18;
			this.chkAdvancedOptions.TabStop = true;
			this.chkAdvancedOptions.Text = "Enable Advanced O&ptions";
			this.chkAdvancedOptions.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkAdvancedOptions.Visible = true;
			this.chkAdvancedOptions.CheckStateChanged += new System.EventHandler(this.chkAdvancedOptions_CheckStateChanged);
			// 
			// grdReportFields
			// 
			this.grdReportFields.AllowDrop = true;
			this.grdReportFields.BackColor = System.Drawing.Color.FromArgb(236, 233, 216);
			this.grdReportFields.CellTipsWidth = 0;
			this.grdReportFields.Location = new System.Drawing.Point(4, 22);
			this.grdReportFields.Name = "grdReportFields";
			this.grdReportFields.RowDivider.Color = System.Drawing.Color.FromArgb(236, 233, 216);
			this.grdReportFields.Size = new System.Drawing.Size(417, 207);
			this.grdReportFields.TabIndex = 14;
			this.grdReportFields.Columns.Add(this.Column_0_grdReportFields);
			this.grdReportFields.Columns.Add(this.Column_1_grdReportFields);
			this.grdReportFields.BeforeColEdit += new C1.Win.C1TrueDBGrid.BeforeColEditEventHandler(this.grdReportFields_BeforeColEdit);
			this.grdReportFields.BeforeRowColChange += new C1.Win.C1TrueDBGrid.CancelEventHandler(this.grdReportFields_BeforeRowColChange);
			// this.this.grdReportFields.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.grdReportFields_KeyPress);
			this.grdReportFields.MouseUp += new System.Windows.Forms.MouseEventHandler(this.grdReportFields_MouseUp);
			this.grdReportFields.RowColChange += new C1.Win.C1TrueDBGrid.RowColChangeEventHandler(this.grdReportFields_RowColChange);
			// 
			// Column_0_grdReportFields
			// 
			this.Column_0_grdReportFields.DataField = "";
			this.Column_0_grdReportFields.ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.Normal;
			// 
			// Column_1_grdReportFields
			// 
			this.Column_1_grdReportFields.DataField = "";
			this.Column_1_grdReportFields.ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.Normal;
			// 
			// cmbFieldList
			// 
			this.cmbFieldList.AllowDrop = true;
			this.cmbFieldList.ColumnHeaders = true;
			this.cmbFieldList.Enabled = true;
			this.cmbFieldList.Location = new System.Drawing.Point(366, 140);
			this.cmbFieldList.Name = "cmbFieldList";
			this.cmbFieldList.Size = new System.Drawing.Size(67, 71);
			this.cmbFieldList.TabIndex = 15;
			this.cmbFieldList.Columns.Add(this.Column_0_cmbFieldList);
			this.cmbFieldList.Columns.Add(this.Column_1_cmbFieldList);
			// 
			// Column_0_cmbFieldList
			// 
			this.Column_0_cmbFieldList.DataField = "";
			this.Column_0_cmbFieldList.ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.Normal;
			// 
			// Column_1_cmbFieldList
			// 
			this.Column_1_cmbFieldList.DataField = "";
			this.Column_1_cmbFieldList.ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.Normal;
			// 
			// UpDown
			// 
			this.UpDown.AllowDrop = true;
			this.UpDown.Location = new System.Drawing.Point(422, 84);
			this.UpDown.Name = "UpDown";
			("UpDown.OcxState");
			this.UpDown.Size = new System.Drawing.Size(26, 49);
			this.UpDown.TabIndex = 20;
			this.UpDown.TabStop = false;
			this.UpDown.DownClick += new System.EventHandler(this.UpDown_DownClick);
			this.UpDown.UpClick += new System.EventHandler(this.UpDown_UpClick);
			// 
			// txtReportName
			// 
			this.txtReportName.AllowDrop = true;
			this.txtReportName.BackColor = System.Drawing.Color.White;
			this.txtReportName.ForeColor = System.Drawing.Color.Black;
			this.txtReportName.Location = new System.Drawing.Point(82, 48);
			this.txtReportName.Name = "txtReportName";
			this.txtReportName.Size = new System.Drawing.Size(259, 19);
			this.txtReportName.TabIndex = 0;
			this.txtReportName.Text = "";
			// this.this.txtReportName.Watermark = "";
			// 
			// _lblCommon_0
			// 
			this._lblCommon_0.AllowDrop = true;
			this._lblCommon_0.Location = new System.Drawing.Point(234, 44);
			this._lblCommon_0.Name = "_lblCommon_0";
			this._lblCommon_0.Size = new System.Drawing.Size(62, 13);
			this._lblCommon_0.TabIndex = 1;
			this._lblCommon_0.Visible = false;
			// 
			// txtTempDate
			// 
			this.txtTempDate.AllowDrop = true;
			this.txtTempDate.Location = new System.Drawing.Point(360, 76);
			this.txtTempDate.Name = "txtTempDate";
			("txtTempDate.OcxState");
			this.txtTempDate.Size = new System.Drawing.Size(79, 21);
			this.txtTempDate.TabIndex = 11;
			this.txtTempDate.Visible = false;
			// 
			// _lblCommon_3
			// 
			this._lblCommon_3.AllowDrop = true;
			this._lblCommon_3.BackColor = System.Drawing.Color.FromArgb(216, 231, 252);
			this._lblCommon_3.Text = "Report Name:";
			this._lblCommon_3.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_3.Location = new System.Drawing.Point(12, 50);
			this._lblCommon_3.Name = "_lblCommon_3";
			this._lblCommon_3.Size = new System.Drawing.Size(66, 13);
			this._lblCommon_3.TabIndex = 19;
			// 
			// tcbSystemForm
			// 
			this.tcbSystemForm.AllowDrop = true;
			this.tcbSystemForm.Location = new System.Drawing.Point(0, 0);
			this.tcbSystemForm.Name = "tcbSystemForm";
			("tcbSystemForm.OcxState");
			// 
			// frmSysReportOptions
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(216, 231, 252);
			this.ClientSize = new System.Drawing.Size(468, 414);
			this.ControlBox = false;
			this.Controls.Add(this.frmHeader);
			this.Controls.Add(this.tabReportOptions);
			this.Controls.Add(this.txtReportName);
			this.Controls.Add(this._lblCommon_0);
			this.Controls.Add(this.txtTempDate);
			this.Controls.Add(this._lblCommon_3);
			this.Controls.Add(this.tcbSystemForm);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			//this.Icon = (System.Drawing.Icon) resources.GetObject("frmSysReportOptions.Icon");
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(515, 236);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmSysReportOptions";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Tag = "H:5925 W:8805";
			this.Text = "Report Options";
			// this.Activated += new System.EventHandler(this.frmSysReportOptions_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
			// this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
			//((System.ComponentModel.ISupportInitialize) this.TabControlPage1).EndInit();
			//((System.ComponentModel.ISupportInitialize) this.tabFormat).EndInit();
			//((System.ComponentModel.ISupportInitialize) this.tabFilters).EndInit();
			//((System.ComponentModel.ISupportInitialize) this.UpDown).EndInit();
			//((System.ComponentModel.ISupportInitialize) this.tabFields).EndInit();
			//((System.ComponentModel.ISupportInitialize) this.tabReportOptions).EndInit();
			//((System.ComponentModel.ISupportInitialize) this.txtTempDate).EndInit();
			//((System.ComponentModel.ISupportInitialize) this.tcbSystemForm).EndInit();
			this.frmHeader.ResumeLayout(false);
			this.tabReportOptions.ResumeLayout(false);
			this.TabControlPage1.ResumeLayout(false);
			this.tabFormat.ResumeLayout(false);
			this.grdReportFormats.ResumeLayout(false);
			this.cmbFormatList.ResumeLayout(false);
			this.tabFilters.ResumeLayout(false);
			this.fraDateRange.ResumeLayout(false);
			this.grdReportFilters.ResumeLayout(false);
			this.cmbFilterList.ResumeLayout(false);
			this.tabFields.ResumeLayout(false);
			this.grdReportFields.ResumeLayout(false);
			this.cmbFieldList.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		void ReLoadForm(bool addEvents)
		{
			InitializetxtDateRange();
			InitializelblCommon();
		}
		void InitializetxtDateRange()
		{
			this.txtDateRange = new Syncfusion.WinForms.Input.SfDateTimeEdit[2];
			this.txtDateRange[0] = _txtDateRange_0;
			this.txtDateRange[1] = _txtDateRange_1;
		}
		void InitializelblCommon()
		{
			this.lblCommon = new System.Windows.Forms.Label[4];
			this.lblCommon[1] = _lblCommon_1;
			this.lblCommon[2] = _lblCommon_2;
			this.lblCommon[0] = _lblCommon_0;
			this.lblCommon[3] = _lblCommon_3;
		}
		#endregion
	}
}