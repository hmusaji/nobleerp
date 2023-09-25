
namespace Xtreme
{
	partial class frmSysReportCrystalParameters
	{

		#region "Upgrade Support "
		private static frmSysReportCrystalParameters m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmSysReportCrystalParameters DefInstance
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
		public static frmSysReportCrystalParameters CreateInstance()
		{
			frmSysReportCrystalParameters theInstance = new frmSysReportCrystalParameters();
			
			return theInstance;
		}
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "_optPrintGraph_2", "_optPrintGraph_1", "_optPrintGraph_0", "fraReportPrintType", "Frame1", "Column_0_grdReportOptions", "Column_1_grdReportOptions", "grdReportOptions", "_lblCommon_0", "_txtDateRange_0", "_lblCommon_1", "_lblCommon_2", "_lblCommon_3", "_txtDateRange_1", "Column_0_cmbSearchList", "Column_1_cmbSearchList", "cmbSearchList", "fraDateRange", "fraReportOptions", "tabReportOptions", "_btnReportOptions_0", "_btnReportOptions_2", "_btnReportOptions_1", "_cntButtons_0", "cntOuterFrame", "btnReportOptions", "cntButtons", "lblCommon", "optPrintGraph", "txtDateRange"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		private System.Windows.Forms.RadioButton _optPrintGraph_2;
		private System.Windows.Forms.RadioButton _optPrintGraph_1;
		private System.Windows.Forms.RadioButton _optPrintGraph_0;
		public System.Windows.Forms.GroupBox fraReportPrintType;
		public System.Windows.Forms.Panel Frame1;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_0_grdReportOptions;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_1_grdReportOptions;
		public C1.Win.C1TrueDBGrid.C1TrueDBGrid grdReportOptions;
		private System.Windows.Forms.Label _lblCommon_0;
		private Syncfusion.WinForms.Input.SfDateTimeEdit _txtDateRange_0;
		private System.Windows.Forms.Label _lblCommon_1;
		private System.Windows.Forms.Label _lblCommon_2;
		private System.Windows.Forms.Label _lblCommon_3;
		private Syncfusion.WinForms.Input.SfDateTimeEdit _txtDateRange_1;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_0_cmbSearchList;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_1_cmbSearchList;
		public C1.Win.C1TrueDBGrid.C1TrueDBDropdown cmbSearchList;
		public UpgradeHelpers.Gui.ShapeHelper fraDateRange;
		public System.Windows.Forms.Panel fraReportOptions;
		public AxC1SizerLib.AxC1Tab tabReportOptions;
		private AxSmartNetButtonProject.AxSmartNetButton _btnReportOptions_0;
		private AxSmartNetButtonProject.AxSmartNetButton _btnReportOptions_2;
		private AxSmartNetButtonProject.AxSmartNetButton _btnReportOptions_1;
		private UpgradeHelpers.Gui.ShapeHelper _cntButtons_0;
		public AxC1SizerLib.AxC1Elastic cntOuterFrame;
		public AxSmartNetButtonProject.AxSmartNetButton[] btnReportOptions = new AxSmartNetButtonProject.AxSmartNetButton[3];
		public UpgradeHelpers.Gui.ShapeHelper[] cntButtons = new UpgradeHelpers.Gui.ShapeHelper[1];
		public System.Windows.Forms.Label[] lblCommon = new System.Windows.Forms.Label[4];
		public System.Windows.Forms.RadioButton[] optPrintGraph = new System.Windows.Forms.RadioButton[3];
		public Syncfusion.WinForms.Input.SfDateTimeEdit[] txtDateRange = new Syncfusion.WinForms.Input.SfDateTimeEdit[2];
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSysReportCrystalParameters));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this.cntOuterFrame = new AxC1SizerLib.AxC1Elastic();
			this.tabReportOptions = new AxC1SizerLib.AxC1Tab();
			this.Frame1 = new System.Windows.Forms.Panel();
			this.fraReportPrintType = new System.Windows.Forms.GroupBox();
			this._optPrintGraph_2 = new System.Windows.Forms.RadioButton();
			this._optPrintGraph_1 = new System.Windows.Forms.RadioButton();
			this._optPrintGraph_0 = new System.Windows.Forms.RadioButton();
			this.fraReportOptions = new System.Windows.Forms.Panel();
			this.grdReportOptions = new C1.Win.C1TrueDBGrid.C1TrueDBGrid();
			this.Column_0_grdReportOptions = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.Column_1_grdReportOptions = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this._lblCommon_0 = new System.Windows.Forms.Label();
			this._txtDateRange_0 = new Syncfusion.WinForms.Input.SfDateTimeEdit();
			this._lblCommon_1 = new System.Windows.Forms.Label();
			this._lblCommon_2 = new System.Windows.Forms.Label();
			this._lblCommon_3 = new System.Windows.Forms.Label();
			this._txtDateRange_1 = new Syncfusion.WinForms.Input.SfDateTimeEdit();
			this.cmbSearchList = new C1.Win.C1TrueDBGrid.C1TrueDBDropdown();
			this.Column_0_cmbSearchList = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.Column_1_cmbSearchList = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.fraDateRange = new UpgradeHelpers.Gui.ShapeHelper();
			this._btnReportOptions_0 = new AxSmartNetButtonProject.AxSmartNetButton();
			this._btnReportOptions_2 = new AxSmartNetButtonProject.AxSmartNetButton();
			this._btnReportOptions_1 = new AxSmartNetButtonProject.AxSmartNetButton();
			this._cntButtons_0 = new UpgradeHelpers.Gui.ShapeHelper();
			// //((System.ComponentModel.ISupportInitialize) this.tabReportOptions).BeginInit();
			// //((System.ComponentModel.ISupportInitialize) this._btnReportOptions_0).BeginInit();
			// //((System.ComponentModel.ISupportInitialize) this._btnReportOptions_2).BeginInit();
			// //((System.ComponentModel.ISupportInitialize) this._btnReportOptions_1).BeginInit();
			// //((System.ComponentModel.ISupportInitialize) this.cntOuterFrame).BeginInit();
			this.cntOuterFrame.SuspendLayout();
			this.tabReportOptions.SuspendLayout();
			this.Frame1.SuspendLayout();
			this.fraReportPrintType.SuspendLayout();
			this.fraReportOptions.SuspendLayout();
			this.grdReportOptions.SuspendLayout();
			this.cmbSearchList.SuspendLayout();
			this.SuspendLayout();
			// 
			// cntOuterFrame
			// 
			this.cntOuterFrame.Align = C1SizerLib.AlignSettings.asFill;
			this.cntOuterFrame.AllowDrop = true;
			this.cntOuterFrame.Controls.Add(this.tabReportOptions);
			this.cntOuterFrame.Controls.Add(this._btnReportOptions_0);
			this.cntOuterFrame.Controls.Add(this._btnReportOptions_2);
			this.cntOuterFrame.Controls.Add(this._btnReportOptions_1);
			this.cntOuterFrame.Controls.Add(this._cntButtons_0);
			this.cntOuterFrame.Location = new System.Drawing.Point(0, 0);
			this.cntOuterFrame.Name = "cntOuterFrame";
			//
			this.cntOuterFrame.Size = new System.Drawing.Size(579, 361);
			this.cntOuterFrame.TabIndex = 8;
			this.cntOuterFrame.TabStop = false;
			// 
			// tabReportOptions
			// 
			this.tabReportOptions.Align = C1SizerLib.AlignSettings.asNone;
			this.tabReportOptions.AllowDrop = true;
			this.tabReportOptions.Controls.Add(this.Frame1);
			this.tabReportOptions.Controls.Add(this.fraReportOptions);
			this.tabReportOptions.Location = new System.Drawing.Point(10, 20);
			this.tabReportOptions.Name = "tabReportOptions";
			//
			this.tabReportOptions.Size = new System.Drawing.Size(483, 323);
			this.tabReportOptions.TabIndex = 9;
			// 
			// Frame1
			// 
			this.Frame1.AllowDrop = true;
			this.Frame1.BackColor = System.Drawing.Color.FromArgb(248, 245, 231);
			this.Frame1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Frame1.Controls.Add(this.fraReportPrintType);
			this.Frame1.Enabled = true;
			this.Frame1.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Frame1.Location = new System.Drawing.Point(524, 23);
			this.Frame1.Name = "Frame1";
			this.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Frame1.Size = new System.Drawing.Size(481, 299);
			this.Frame1.TabIndex = 13;
			this.Frame1.Visible = true;
			// 
			// fraReportPrintType
			// 
			this.fraReportPrintType.AllowDrop = true;
			this.fraReportPrintType.BackColor = System.Drawing.Color.FromArgb(248, 245, 231);
			this.fraReportPrintType.Controls.Add(this._optPrintGraph_2);
			this.fraReportPrintType.Controls.Add(this._optPrintGraph_1);
			this.fraReportPrintType.Controls.Add(this._optPrintGraph_0);
			this.fraReportPrintType.Enabled = true;
			this.fraReportPrintType.ForeColor = System.Drawing.SystemColors.ControlText;
			this.fraReportPrintType.Location = new System.Drawing.Point(28, 34);
			this.fraReportPrintType.Name = "fraReportPrintType";
			this.fraReportPrintType.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.fraReportPrintType.Size = new System.Drawing.Size(233, 119);
			this.fraReportPrintType.TabIndex = 14;
			this.fraReportPrintType.Text = " Report Print Format ";
			this.fraReportPrintType.Visible = true;
			// 
			// _optPrintGraph_2
			// 
			this._optPrintGraph_2.AllowDrop = true;
			this._optPrintGraph_2.Appearance = System.Windows.Forms.Appearance.Normal;
			this._optPrintGraph_2.BackColor = System.Drawing.Color.FromArgb(248, 245, 231);
			this._optPrintGraph_2.CausesValidation = true;
			this._optPrintGraph_2.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._optPrintGraph_2.Checked = false;
			this._optPrintGraph_2.Enabled = true;
			this._optPrintGraph_2.ForeColor = System.Drawing.SystemColors.ControlText;
			this._optPrintGraph_2.Location = new System.Drawing.Point(14, 76);
			this._optPrintGraph_2.Name = "_optPrintGraph_2";
			this._optPrintGraph_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._optPrintGraph_2.Size = new System.Drawing.Size(200, 23);
			this._optPrintGraph_2.TabIndex = 17;
			this._optPrintGraph_2.TabStop = true;
			this._optPrintGraph_2.Text = "Data Report with Graph";
			this._optPrintGraph_2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._optPrintGraph_2.Visible = true;
			// 
			// _optPrintGraph_1
			// 
			this._optPrintGraph_1.AllowDrop = true;
			this._optPrintGraph_1.Appearance = System.Windows.Forms.Appearance.Normal;
			this._optPrintGraph_1.BackColor = System.Drawing.Color.FromArgb(248, 245, 231);
			this._optPrintGraph_1.CausesValidation = true;
			this._optPrintGraph_1.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._optPrintGraph_1.Checked = false;
			this._optPrintGraph_1.Enabled = true;
			this._optPrintGraph_1.ForeColor = System.Drawing.SystemColors.ControlText;
			this._optPrintGraph_1.Location = new System.Drawing.Point(14, 53);
			this._optPrintGraph_1.Name = "_optPrintGraph_1";
			this._optPrintGraph_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._optPrintGraph_1.Size = new System.Drawing.Size(200, 23);
			this._optPrintGraph_1.TabIndex = 16;
			this._optPrintGraph_1.TabStop = true;
			this._optPrintGraph_1.Text = "Graphical Report Only";
			this._optPrintGraph_1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._optPrintGraph_1.Visible = true;
			// 
			// _optPrintGraph_0
			// 
			this._optPrintGraph_0.AllowDrop = true;
			this._optPrintGraph_0.Appearance = System.Windows.Forms.Appearance.Normal;
			this._optPrintGraph_0.BackColor = System.Drawing.Color.FromArgb(248, 245, 231);
			this._optPrintGraph_0.CausesValidation = true;
			this._optPrintGraph_0.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._optPrintGraph_0.Checked = true;
			this._optPrintGraph_0.Enabled = true;
			this._optPrintGraph_0.ForeColor = System.Drawing.SystemColors.ControlText;
			this._optPrintGraph_0.Location = new System.Drawing.Point(14, 30);
			this._optPrintGraph_0.Name = "_optPrintGraph_0";
			this._optPrintGraph_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._optPrintGraph_0.Size = new System.Drawing.Size(200, 23);
			this._optPrintGraph_0.TabIndex = 15;
			this._optPrintGraph_0.TabStop = true;
			this._optPrintGraph_0.Text = "Data Report Only";
			this._optPrintGraph_0.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._optPrintGraph_0.Visible = true;
			// 
			// fraReportOptions
			// 
			this.fraReportOptions.AllowDrop = true;
			this.fraReportOptions.BackColor = System.Drawing.Color.FromArgb(248, 245, 231);
			this.fraReportOptions.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.fraReportOptions.Controls.Add(this.grdReportOptions);
			this.fraReportOptions.Controls.Add(this._lblCommon_0);
			this.fraReportOptions.Controls.Add(this._txtDateRange_0);
			this.fraReportOptions.Controls.Add(this._lblCommon_1);
			this.fraReportOptions.Controls.Add(this._lblCommon_2);
			this.fraReportOptions.Controls.Add(this._lblCommon_3);
			this.fraReportOptions.Controls.Add(this._txtDateRange_1);
			this.fraReportOptions.Controls.Add(this.cmbSearchList);
			this.fraReportOptions.Controls.Add(this.fraDateRange);
			this.fraReportOptions.Enabled = true;
			this.fraReportOptions.ForeColor = System.Drawing.SystemColors.ControlText;
			this.fraReportOptions.Location = new System.Drawing.Point(1, 23);
			this.fraReportOptions.Name = "fraReportOptions";
			this.fraReportOptions.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.fraReportOptions.Size = new System.Drawing.Size(481, 299);
			this.fraReportOptions.TabIndex = 10;
			this.fraReportOptions.Visible = true;
			// 
			// grdReportOptions
			// 
			this.grdReportOptions.AllowDrop = true;
			this.grdReportOptions.BackColor = System.Drawing.Color.FromArgb(236, 233, 216);
			this.grdReportOptions.CellTipsWidth = 0;
			this.grdReportOptions.Location = new System.Drawing.Point(112, 106);
			this.grdReportOptions.Name = "grdReportOptions";
			this.grdReportOptions.RowDivider.Color = System.Drawing.Color.FromArgb(236, 233, 216);
			this.grdReportOptions.Size = new System.Drawing.Size(91, 115);
			this.grdReportOptions.TabIndex = 4;
			this.grdReportOptions.Columns.Add(this.Column_0_grdReportOptions);
			this.grdReportOptions.Columns.Add(this.Column_1_grdReportOptions);
			this.grdReportOptions.BeforeRowColChange += new C1.Win.C1TrueDBGrid.CancelEventHandler(this.grdReportOptions_BeforeRowColChange);
			this.grdReportOptions.RowColChange += new C1.Win.C1TrueDBGrid.RowColChangeEventHandler(this.grdReportOptions_RowColChange);
			// 
			// Column_0_grdReportOptions
			// 
			this.Column_0_grdReportOptions.DataField = "";
			this.Column_0_grdReportOptions.ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.Normal;
			// 
			// Column_1_grdReportOptions
			// 
			this.Column_1_grdReportOptions.DataField = "";
			this.Column_1_grdReportOptions.ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.Normal;
			// 
			// _lblCommon_0
			// 
			this._lblCommon_0.AllowDrop = true;
			this._lblCommon_0.BackColor = System.Drawing.SystemColors.Window;
			this._lblCommon_0.Text = " Date Range ";
			this._lblCommon_0.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_0.Location = new System.Drawing.Point(18, 16);
			this._lblCommon_0.Name = "_lblCommon_0";
			this._lblCommon_0.Size = new System.Drawing.Size(63, 13);
			this._lblCommon_0.TabIndex = 11;
			// 
			// _txtDateRange_0
			// 
			this._txtDateRange_0.AllowDrop = true;
			// this._txtDateRange_0.CheckDateRange = false;
			this._txtDateRange_0.Location = new System.Drawing.Point(84, 39);
			// this._txtDateRange_0.MaxDate = 2958465;
			// this._txtDateRange_0.MinDate = 2;
			this._txtDateRange_0.Name = "_txtDateRange_0";
			this._txtDateRange_0.Size = new System.Drawing.Size(101, 19);
			this._txtDateRange_0.TabIndex = 1;
			this._txtDateRange_0.Text = "18/07/2001";
			// this._txtDateRange_0.Value = 37090;
			// 
			// _lblCommon_1
			// 
			this._lblCommon_1.AllowDrop = true;
			this._lblCommon_1.BackColor = System.Drawing.SystemColors.Window;
			this._lblCommon_1.Text = "From Date";
			this._lblCommon_1.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_1.Location = new System.Drawing.Point(26, 42);
			this._lblCommon_1.Name = "_lblCommon_1";
			this._lblCommon_1.Size = new System.Drawing.Size(50, 13);
			this._lblCommon_1.TabIndex = 0;
			// 
			// _lblCommon_2
			// 
			this._lblCommon_2.AllowDrop = true;
			this._lblCommon_2.BackColor = System.Drawing.SystemColors.Window;
			this._lblCommon_2.Text = "To Date";
			this._lblCommon_2.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_2.Location = new System.Drawing.Point(268, 42);
			this._lblCommon_2.Name = "_lblCommon_2";
			this._lblCommon_2.Size = new System.Drawing.Size(38, 13);
			this._lblCommon_2.TabIndex = 2;
			// 
			// _lblCommon_3
			// 
			this._lblCommon_3.AllowDrop = true;
			this._lblCommon_3.BackColor = System.Drawing.SystemColors.Window;
			this._lblCommon_3.Text = "Filter Range:";
			this._lblCommon_3.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_3.Location = new System.Drawing.Point(10, 84);
			this._lblCommon_3.Name = "_lblCommon_3";
			this._lblCommon_3.Size = new System.Drawing.Size(62, 13);
			this._lblCommon_3.TabIndex = 12;
			// 
			// _txtDateRange_1
			// 
			this._txtDateRange_1.AllowDrop = true;
			// this._txtDateRange_1.CheckDateRange = false;
			this._txtDateRange_1.Location = new System.Drawing.Point(314, 39);
			// this._txtDateRange_1.MaxDate = 2958465;
			// this._txtDateRange_1.MinDate = 2;
			this._txtDateRange_1.Name = "_txtDateRange_1";
			this._txtDateRange_1.Size = new System.Drawing.Size(101, 19);
			this._txtDateRange_1.TabIndex = 3;
			this._txtDateRange_1.Text = "18/07/2001";
			// this._txtDateRange_1.Value = 37090;
			// 
			// cmbSearchList
			// 
			this.cmbSearchList.AllowDrop = true;
			this.cmbSearchList.ColumnHeaders = true;
			this.cmbSearchList.Enabled = true;
			this.cmbSearchList.Location = new System.Drawing.Point(18, 106);
			this.cmbSearchList.Name = "cmbSearchList";
			this.cmbSearchList.Size = new System.Drawing.Size(91, 115);
			this.cmbSearchList.TabIndex = 18;
			this.cmbSearchList.Columns.Add(this.Column_0_cmbSearchList);
			this.cmbSearchList.Columns.Add(this.Column_1_cmbSearchList);
			// 
			// Column_0_cmbSearchList
			// 
			this.Column_0_cmbSearchList.DataField = "";
			this.Column_0_cmbSearchList.ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.Normal;
			// 
			// Column_1_cmbSearchList
			// 
			this.Column_1_cmbSearchList.DataField = "";
			this.Column_1_cmbSearchList.ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.Normal;
			// 
			// fraDateRange
			// 
			this.fraDateRange.AllowDrop = true;
			this.fraDateRange.BackColor = System.Drawing.Color.FromArgb(146, 92, 39);
			this.fraDateRange.BackStyle = 0;
			this.fraDateRange.BorderColor = System.Drawing.Color.FromArgb(146, 92, 39);
			this.fraDateRange.BorderStyle = 1;
			this.fraDateRange.Enabled = false;
			this.fraDateRange.FillColor = System.Drawing.Color.Navy;
			this.fraDateRange.FillStyle = 1;
			this.fraDateRange.Location = new System.Drawing.Point(10, 22);
			this.fraDateRange.Name = "fraDateRange";
			this.fraDateRange.Size = new System.Drawing.Size(427, 49);
			this.fraDateRange.Visible = true;
			// 
			// _btnReportOptions_0
			// 
			this._btnReportOptions_0.AllowDrop = true;
			this._btnReportOptions_0.Location = new System.Drawing.Point(505, 219);
			this._btnReportOptions_0.Name = "_btnReportOptions_0";
			//
			this._btnReportOptions_0.Size = new System.Drawing.Size(69, 24);
			this._btnReportOptions_0.TabIndex = 5;
			this._btnReportOptions_0.AccessKeyPress += new AxSmartNetButtonProject.__SmartNetButton_AccessKeyPressEventHandler(this.btnReportOptions_AccessKeyPress);
			//// this._btnReportOptions_0.ClickEvent += new System.EventHandler(this.btnReportOptions_ClickEvent);
			// 
			// _btnReportOptions_2
			// 
			this._btnReportOptions_2.AllowDrop = true;
			this._btnReportOptions_2.Location = new System.Drawing.Point(505, 269);
			this._btnReportOptions_2.Name = "_btnReportOptions_2";
			//
			this._btnReportOptions_2.Size = new System.Drawing.Size(69, 24);
			this._btnReportOptions_2.TabIndex = 7;
			this._btnReportOptions_2.AccessKeyPress += new AxSmartNetButtonProject.__SmartNetButton_AccessKeyPressEventHandler(this.btnReportOptions_AccessKeyPress);
			//// this._btnReportOptions_2.ClickEvent += new System.EventHandler(this.btnReportOptions_ClickEvent);
			// 
			// _btnReportOptions_1
			// 
			this._btnReportOptions_1.AllowDrop = true;
			this._btnReportOptions_1.Location = new System.Drawing.Point(505, 244);
			this._btnReportOptions_1.Name = "_btnReportOptions_1";
			//
			this._btnReportOptions_1.Size = new System.Drawing.Size(69, 24);
			this._btnReportOptions_1.TabIndex = 6;
			this._btnReportOptions_1.AccessKeyPress += new AxSmartNetButtonProject.__SmartNetButton_AccessKeyPressEventHandler(this.btnReportOptions_AccessKeyPress);
			//// this._btnReportOptions_1.ClickEvent += new System.EventHandler(this.btnReportOptions_ClickEvent);
			// 
			// _cntButtons_0
			// 
			this._cntButtons_0.AllowDrop = true;
			this._cntButtons_0.BackColor = System.Drawing.Color.FromArgb(64, 64, 0);
			this._cntButtons_0.BackStyle = 1;
			this._cntButtons_0.BorderStyle = 0;
			this._cntButtons_0.Enabled = false;
			this._cntButtons_0.FillColor = System.Drawing.Color.Black;
			this._cntButtons_0.FillStyle = 1;
			this._cntButtons_0.Location = new System.Drawing.Point(504, 218);
			this._cntButtons_0.Name = "_cntButtons_0";
			this._cntButtons_0.Size = new System.Drawing.Size(72, 78);
			this._cntButtons_0.Visible = true;
			// 
			// frmSysReportCrystalParameters
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(165, 165, 165);
			this.ClientSize = new System.Drawing.Size(579, 361);
			this.ControlBox = false;
			this.Controls.Add(this.cntOuterFrame);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			//this.Icon = (System.Drawing.Icon) resources.GetObject("frmSysReportCrystalParameters.Icon");
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(56, 137);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmSysReportCrystalParameters";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.ShowInTaskbar = false;
			this.Text = "Enter Report Parameters";
			// this.Activated += new System.EventHandler(this.frmSysReportCrystalParameters_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
			// this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
			//((System.ComponentModel.ISupportInitialize) this.tabReportOptions).EndInit();
			//((System.ComponentModel.ISupportInitialize) this._btnReportOptions_0).EndInit();
			//((System.ComponentModel.ISupportInitialize) this._btnReportOptions_2).EndInit();
			//((System.ComponentModel.ISupportInitialize) this._btnReportOptions_1).EndInit();
			//((System.ComponentModel.ISupportInitialize) this.cntOuterFrame).EndInit();
			this.cntOuterFrame.ResumeLayout(false);
			this.tabReportOptions.ResumeLayout(false);
			this.Frame1.ResumeLayout(false);
			this.fraReportPrintType.ResumeLayout(false);
			this.fraReportOptions.ResumeLayout(false);
			this.grdReportOptions.ResumeLayout(false);
			this.cmbSearchList.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		// 
		void InitializetxtDateRange()
		{
			this.txtDateRange = new Syncfusion.WinForms.Input.SfDateTimeEdit[2];
			this.txtDateRange[0] = _txtDateRange_0;
			this.txtDateRange[1] = _txtDateRange_1;
		}
		void InitializeoptPrintGraph()
		{
			this.optPrintGraph = new System.Windows.Forms.RadioButton[3];
			this.optPrintGraph[2] = _optPrintGraph_2;
			this.optPrintGraph[1] = _optPrintGraph_1;
			this.optPrintGraph[0] = _optPrintGraph_0;
		}
		void InitializelblCommon()
		{
			this.lblCommon = new System.Windows.Forms.Label[4];
			this.lblCommon[0] = _lblCommon_0;
			this.lblCommon[1] = _lblCommon_1;
			this.lblCommon[2] = _lblCommon_2;
			this.lblCommon[3] = _lblCommon_3;
		}
		void InitializecntButtons()
		{
			this.cntButtons = new UpgradeHelpers.Gui.ShapeHelper[1];
			this.cntButtons[0] = _cntButtons_0;
		}
		void InitializebtnReportOptions()
		{
			this.btnReportOptions = new AxSmartNetButtonProject.AxSmartNetButton[3];
			this.btnReportOptions[0] = _btnReportOptions_0;
			this.btnReportOptions[2] = _btnReportOptions_2;
			this.btnReportOptions[1] = _btnReportOptions_1;
		}
		#endregion
	}
}//ENDSHERE
