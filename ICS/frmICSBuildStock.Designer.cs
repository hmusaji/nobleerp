
namespace Xtreme
{
	partial class frmICSBuildStock
	{

		#region "Upgrade Support "
		private static frmICSBuildStock m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmICSBuildStock DefInstance
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
		public static frmICSBuildStock CreateInstance()
		{
			frmICSBuildStock theInstance = new frmICSBuildStock();
			
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
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "cmdBuildSerialNo", "cmdAddtionalDetails", "Column_0_cmbMastersList", "Column_1_cmbMastersList", "cmbMastersList", "Column_0_grdVoucherDetails", "Column_1_grdVoucherDetails", "grdVoucherDetails", "_txtCommonTextBox_8", "_lblCommonLabel_7", "_lblCommonLabel_5", "_lblCommonLabel_6", "txtVoucherDate", "txtBuildQty", "_txtCommonTextBox_1", "_lblCommonLabel_17", "_txtCommonTextBox_20", "_lblCommonLabel_2", "_txtDisplayLabel_9", "_txtDisplayLabel_1", "txtApprovedBy", "_lblCommonLabel_0", "txtNoOfEmployees", "_lblCommonLabel_1", "txtNoOfHours", "_lblCommonLabel_3", "txtAssembledBy", "_lblCommonLabel_4", "txtDesignedBy", "_lblCommonLabel_8", "_lblCommonLabel_10", "txtDAssembledDate", "_txtCommonTextBox_7", "_lblCommonLabel_11", "_txtCommonTextBox_11", "_lblCommonLabel_9", "_txtCommonTextBox_19", "_txtCommonTextBox_18", "_lblCommonLabel_20", "_txtCommonTextBox_17", "_lblCommonLabel_23", "_lblCommonLabel_22", "_lblCommonLabel_21", "_txtCommonTextBox_3", "_lblCommonLabel_12", "_txtDisplayLabel_2", "fraVoucherImport", "CommandBars", "fraTransactionHeader", "lblCommonLabel", "txtCommonTextBox", "txtDisplayLabel"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public System.Windows.Forms.Button cmdBuildSerialNo;
		public System.Windows.Forms.Button cmdAddtionalDetails;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_0_cmbMastersList;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_1_cmbMastersList;
		public C1.Win.C1TrueDBGrid.C1TrueDBDropdown cmbMastersList;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_0_grdVoucherDetails;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_1_grdVoucherDetails;
		public C1.Win.C1TrueDBGrid.C1TrueDBGrid grdVoucherDetails;
		private System.Windows.Forms.TextBox _txtCommonTextBox_8;
		private System.Windows.Forms.Label _lblCommonLabel_7;
		private System.Windows.Forms.Label _lblCommonLabel_5;
		private System.Windows.Forms.Label _lblCommonLabel_6;
		public Syncfusion.WinForms.Input.SfDateTimeEdit txtVoucherDate;
		public System.Windows.Forms.TextBox txtBuildQty;
		private System.Windows.Forms.TextBox _txtCommonTextBox_1;
		private System.Windows.Forms.Label _lblCommonLabel_17;
		private System.Windows.Forms.TextBox _txtCommonTextBox_20;
		private System.Windows.Forms.Label _lblCommonLabel_2;
		private System.Windows.Forms.Label _txtDisplayLabel_9;
		private System.Windows.Forms.Label _txtDisplayLabel_1;
		public System.Windows.Forms.TextBox txtApprovedBy;
		private System.Windows.Forms.Label _lblCommonLabel_0;
		public System.Windows.Forms.TextBox txtNoOfEmployees;
		private System.Windows.Forms.Label _lblCommonLabel_1;
		public System.Windows.Forms.TextBox txtNoOfHours;
		private System.Windows.Forms.Label _lblCommonLabel_3;
		public System.Windows.Forms.TextBox txtAssembledBy;
		private System.Windows.Forms.Label _lblCommonLabel_4;
		public System.Windows.Forms.TextBox txtDesignedBy;
		private System.Windows.Forms.Label _lblCommonLabel_8;
		private System.Windows.Forms.Label _lblCommonLabel_10;
		public Syncfusion.WinForms.Input.SfDateTimeEdit txtDAssembledDate;
		private System.Windows.Forms.TextBox _txtCommonTextBox_7;
		private System.Windows.Forms.Label _lblCommonLabel_11;
		private System.Windows.Forms.TextBox _txtCommonTextBox_11;
		private System.Windows.Forms.Label _lblCommonLabel_9;
		private System.Windows.Forms.TextBox _txtCommonTextBox_19;
		private System.Windows.Forms.TextBox _txtCommonTextBox_18;
		private System.Windows.Forms.Label _lblCommonLabel_20;
		private System.Windows.Forms.TextBox _txtCommonTextBox_17;
		private System.Windows.Forms.Label _lblCommonLabel_23;
		private System.Windows.Forms.Label _lblCommonLabel_22;
		private System.Windows.Forms.Label _lblCommonLabel_21;
		private System.Windows.Forms.TextBox _txtCommonTextBox_3;
		private System.Windows.Forms.Label _lblCommonLabel_12;
		private System.Windows.Forms.Label _txtDisplayLabel_2;
		public UpgradeHelpers.Gui.ShapeHelper fraVoucherImport;
		public Syncfusion.Windows.Forms.Tools.CommandBarController CommandBars;
		public UpgradeHelpers.Gui.ShapeHelper fraTransactionHeader;
		public System.Windows.Forms.Label[] lblCommonLabel = new System.Windows.Forms.Label[24];
		public System.Windows.Forms.TextBox[] txtCommonTextBox = new System.Windows.Forms.TextBox[21];
		public System.Windows.Forms.Label[] txtDisplayLabel = new System.Windows.Forms.Label[10];
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmICSBuildStock));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this.cmdBuildSerialNo = new System.Windows.Forms.Button();
			this.cmdAddtionalDetails = new System.Windows.Forms.Button();
			this.cmbMastersList = new C1.Win.C1TrueDBGrid.C1TrueDBDropdown();
			this.Column_0_cmbMastersList = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.Column_1_cmbMastersList = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.grdVoucherDetails = new C1.Win.C1TrueDBGrid.C1TrueDBGrid();
			this.Column_0_grdVoucherDetails = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.Column_1_grdVoucherDetails = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this._txtCommonTextBox_8 = new System.Windows.Forms.TextBox();
			this._lblCommonLabel_7 = new System.Windows.Forms.Label();
			this._lblCommonLabel_5 = new System.Windows.Forms.Label();
			this._lblCommonLabel_6 = new System.Windows.Forms.Label();
			this.txtVoucherDate = new Syncfusion.WinForms.Input.SfDateTimeEdit();
			this.txtBuildQty = new System.Windows.Forms.TextBox();
			this._txtCommonTextBox_1 = new System.Windows.Forms.TextBox();
			this._lblCommonLabel_17 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_20 = new System.Windows.Forms.TextBox();
			this._lblCommonLabel_2 = new System.Windows.Forms.Label();
			this._txtDisplayLabel_9 = new System.Windows.Forms.Label();
			this._txtDisplayLabel_1 = new System.Windows.Forms.Label();
			this.txtApprovedBy = new System.Windows.Forms.TextBox();
			this._lblCommonLabel_0 = new System.Windows.Forms.Label();
			this.txtNoOfEmployees = new System.Windows.Forms.TextBox();
			this._lblCommonLabel_1 = new System.Windows.Forms.Label();
			this.txtNoOfHours = new System.Windows.Forms.TextBox();
			this._lblCommonLabel_3 = new System.Windows.Forms.Label();
			this.txtAssembledBy = new System.Windows.Forms.TextBox();
			this._lblCommonLabel_4 = new System.Windows.Forms.Label();
			this.txtDesignedBy = new System.Windows.Forms.TextBox();
			this._lblCommonLabel_8 = new System.Windows.Forms.Label();
			this._lblCommonLabel_10 = new System.Windows.Forms.Label();
			this.txtDAssembledDate = new Syncfusion.WinForms.Input.SfDateTimeEdit();
			this._txtCommonTextBox_7 = new System.Windows.Forms.TextBox();
			this._lblCommonLabel_11 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_11 = new System.Windows.Forms.TextBox();
			this._lblCommonLabel_9 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_19 = new System.Windows.Forms.TextBox();
			this._txtCommonTextBox_18 = new System.Windows.Forms.TextBox();
			this._lblCommonLabel_20 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_17 = new System.Windows.Forms.TextBox();
			this._lblCommonLabel_23 = new System.Windows.Forms.Label();
			this._lblCommonLabel_22 = new System.Windows.Forms.Label();
			this._lblCommonLabel_21 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_3 = new System.Windows.Forms.TextBox();
			this._lblCommonLabel_12 = new System.Windows.Forms.Label();
			this._txtDisplayLabel_2 = new System.Windows.Forms.Label();
			this.fraVoucherImport = new UpgradeHelpers.Gui.ShapeHelper();
			this.CommandBars = new Syncfusion.Windows.Forms.Tools.CommandBarController();
			this.fraTransactionHeader = new UpgradeHelpers.Gui.ShapeHelper();
			// //((System.ComponentModel.ISupportInitialize) this.CommandBars).BeginInit();
			this.cmbMastersList.SuspendLayout();
			this.grdVoucherDetails.SuspendLayout();
			this.SuspendLayout();
			// 
			// cmdBuildSerialNo
			// 
			this.cmdBuildSerialNo.AllowDrop = true;
			this.cmdBuildSerialNo.BackColor = System.Drawing.SystemColors.Control;
			this.cmdBuildSerialNo.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdBuildSerialNo.Location = new System.Drawing.Point(369, 106);
			this.cmdBuildSerialNo.Name = "cmdBuildSerialNo";
			this.cmdBuildSerialNo.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdBuildSerialNo.Size = new System.Drawing.Size(26, 20);
			this.cmdBuildSerialNo.TabIndex = 14;
			this.cmdBuildSerialNo.Text = "....";
			this.cmdBuildSerialNo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.cmdBuildSerialNo.UseVisualStyleBackColor = false;
			// this.cmdBuildSerialNo.Click += new System.EventHandler(this.cmdBuildSerialNo_Click);
			// 
			// cmdAddtionalDetails
			// 
			this.cmdAddtionalDetails.AllowDrop = true;
			this.cmdAddtionalDetails.BackColor = System.Drawing.SystemColors.Control;
			this.cmdAddtionalDetails.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdAddtionalDetails.Location = new System.Drawing.Point(193, 129);
			this.cmdAddtionalDetails.Name = "cmdAddtionalDetails";
			this.cmdAddtionalDetails.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdAddtionalDetails.Size = new System.Drawing.Size(24, 19);
			this.cmdAddtionalDetails.TabIndex = 13;
			this.cmdAddtionalDetails.TabStop = false;
			this.cmdAddtionalDetails.Text = "&...";
			this.cmdAddtionalDetails.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.cmdAddtionalDetails.UseVisualStyleBackColor = false;
			this.cmdAddtionalDetails.Visible = false;
			// this.cmdAddtionalDetails.Click += new System.EventHandler(this.cmdAddtionalDetails_Click);
			// 
			// cmbMastersList
			// 
			this.cmbMastersList.AllowDrop = true;
			this.cmbMastersList.ColumnHeaders = true;
			this.cmbMastersList.Enabled = true;
			this.cmbMastersList.Location = new System.Drawing.Point(111, 232);
			this.cmbMastersList.Name = "cmbMastersList";
			this.cmbMastersList.Size = new System.Drawing.Size(227, 97);
			this.cmbMastersList.TabIndex = 12;
			this.cmbMastersList.Columns.Add(this.Column_0_cmbMastersList);
			this.cmbMastersList.Columns.Add(this.Column_1_cmbMastersList);
			// 
			// Column_0_cmbMastersList
			// 
			this.Column_0_cmbMastersList.DataField = "";
			this.Column_0_cmbMastersList.ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.Normal;
			// 
			// Column_1_cmbMastersList
			// 
			this.Column_1_cmbMastersList.DataField = "";
			this.Column_1_cmbMastersList.ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.Normal;
			// 
			// grdVoucherDetails
			// 
			this.grdVoucherDetails.AllowDrop = true;
			this.grdVoucherDetails.BackColor = System.Drawing.Color.Silver;
			this.grdVoucherDetails.CellTipsWidth = 0;
			this.grdVoucherDetails.Location = new System.Drawing.Point(4, 242);
			this.grdVoucherDetails.Name = "grdVoucherDetails";
			this.grdVoucherDetails.RowDivider.Color = System.Drawing.Color.Silver;
			this.grdVoucherDetails.Size = new System.Drawing.Size(567, 163);
			this.grdVoucherDetails.TabIndex = 11;
			this.grdVoucherDetails.Columns.Add(this.Column_0_grdVoucherDetails);
			this.grdVoucherDetails.Columns.Add(this.Column_1_grdVoucherDetails);
			this.grdVoucherDetails.AfterColUpdate += new C1.Win.C1TrueDBGrid.ColEventHandler(this.grdVoucherDetails_AfterColUpdate);
			this.grdVoucherDetails.BeforeColUpdate += new C1.Win.C1TrueDBGrid.BeforeColUpdateEventHandler(this.grdVoucherDetails_BeforeColUpdate);
			this.grdVoucherDetails.ButtonClick += new C1.Win.C1TrueDBGrid.ColEventHandler(this.grdVoucherDetails_ButtonClick);
			this.grdVoucherDetails.GotFocus += new System.EventHandler(this.grdVoucherDetails_GotFocus);
			// this.this.grdVoucherDetails.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grdVoucherDetails_KeyDown);
			this.grdVoucherDetails.RowColChange += new C1.Win.C1TrueDBGrid.RowColChangeEventHandler(this.grdVoucherDetails_RowColChange);
			// 
			// Column_0_grdVoucherDetails
			// 
			this.Column_0_grdVoucherDetails.DataField = "";
			this.Column_0_grdVoucherDetails.ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.Normal;
			// 
			// Column_1_grdVoucherDetails
			// 
			this.Column_1_grdVoucherDetails.DataField = "";
			this.Column_1_grdVoucherDetails.ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.Normal;
			// 
			// _txtCommonTextBox_8
			// 
			this._txtCommonTextBox_8.AllowDrop = true;
			this._txtCommonTextBox_8.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_8.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_8.Location = new System.Drawing.Point(91, 129);
			this._txtCommonTextBox_8.MaxLength = 20;
			this._txtCommonTextBox_8.Name = "_txtCommonTextBox_8";
			this._txtCommonTextBox_8.Size = new System.Drawing.Size(102, 19);
			this._txtCommonTextBox_8.TabIndex = 4;
			this._txtCommonTextBox_8.Text = "";
			// this.this._txtCommonTextBox_8.Watermark = "";
			// this.this._txtCommonTextBox_8.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_8.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _lblCommonLabel_7
			// 
			this._lblCommonLabel_7.AllowDrop = true;
			this._lblCommonLabel_7.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_7.Text = "Reference No.";
			this._lblCommonLabel_7.Location = new System.Drawing.Point(11, 132);
			this._lblCommonLabel_7.Name = "_lblCommonLabel_7";
			this._lblCommonLabel_7.Size = new System.Drawing.Size(70, 13);
			this._lblCommonLabel_7.TabIndex = 15;
			// 
			// _lblCommonLabel_5
			// 
			this._lblCommonLabel_5.AllowDrop = true;
			this._lblCommonLabel_5.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_5.Text = "Build Qty.";
			this._lblCommonLabel_5.Location = new System.Drawing.Point(243, 110);
			this._lblCommonLabel_5.Name = "_lblCommonLabel_5";
			this._lblCommonLabel_5.Size = new System.Drawing.Size(46, 14);
			this._lblCommonLabel_5.TabIndex = 16;
			// 
			// _lblCommonLabel_6
			// 
			this._lblCommonLabel_6.AllowDrop = true;
			this._lblCommonLabel_6.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_6.Text = "Build Date";
			this._lblCommonLabel_6.Location = new System.Drawing.Point(11, 110);
			this._lblCommonLabel_6.Name = "_lblCommonLabel_6";
			this._lblCommonLabel_6.Size = new System.Drawing.Size(48, 14);
			this._lblCommonLabel_6.TabIndex = 17;
			// 
			// txtVoucherDate
			// 
			this.txtVoucherDate.AllowDrop = true;
			// this.txtVoucherDate.CheckDateRange = false;
			this.txtVoucherDate.Location = new System.Drawing.Point(91, 108);
			// this.txtVoucherDate.MaxDate = 2958465;
			// this.txtVoucherDate.MinDate = 32874;
			this.txtVoucherDate.Name = "txtVoucherDate";
			this.txtVoucherDate.Size = new System.Drawing.Size(102, 19);
			this.txtVoucherDate.TabIndex = 2;
			this.txtVoucherDate.Text = "18/07/2001";
			// this.txtVoucherDate.Value = 37090;
			this.txtVoucherDate.Validating += new System.ComponentModel.CancelEventHandler(this.txtVoucherDate_Validating);
			// 
			// txtBuildQty
			// 
			this.txtBuildQty.AllowDrop = true;
			this.txtBuildQty.BackColor = System.Drawing.Color.White;
			// this.txtBuildQty.bolNumericOnly = true;
			this.txtBuildQty.ForeColor = System.Drawing.Color.Black;
			this.txtBuildQty.Location = new System.Drawing.Point(297, 108);
			this.txtBuildQty.Name = "txtBuildQty";
			this.txtBuildQty.Size = new System.Drawing.Size(70, 19);
			this.txtBuildQty.TabIndex = 3;
			this.txtBuildQty.Text = "";
			// this.this.txtBuildQty.Watermark = "";
			// this.txtBuildQty.Leave += new System.EventHandler(this.txtBuildQty_Leave);
			// 
			// _txtCommonTextBox_1
			// 
			this._txtCommonTextBox_1.AllowDrop = true;
			this._txtCommonTextBox_1.BackColor = System.Drawing.Color.White;
			// this._txtCommonTextBox_1.bolNumericOnly = true;
			this._txtCommonTextBox_1.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_1.Location = new System.Drawing.Point(91, 22);
			this._txtCommonTextBox_1.Name = "_txtCommonTextBox_1";
			// this._txtCommonTextBox_1.ShowButton = true;
			this._txtCommonTextBox_1.Size = new System.Drawing.Size(101, 19);
			this._txtCommonTextBox_1.TabIndex = 0;
			this._txtCommonTextBox_1.Text = "";
			// this.this._txtCommonTextBox_1.Watermark = "";
			// this.this._txtCommonTextBox_1.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_1.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _lblCommonLabel_17
			// 
			this._lblCommonLabel_17.AllowDrop = true;
			this._lblCommonLabel_17.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_17.Text = "Location Code";
			this._lblCommonLabel_17.Location = new System.Drawing.Point(11, 24);
			this._lblCommonLabel_17.Name = "_lblCommonLabel_17";
			this._lblCommonLabel_17.Size = new System.Drawing.Size(69, 14);
			this._lblCommonLabel_17.TabIndex = 18;
			// 
			// _txtCommonTextBox_20
			// 
			this._txtCommonTextBox_20.AllowDrop = true;
			this._txtCommonTextBox_20.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_20.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_20.Location = new System.Drawing.Point(91, 42);
			this._txtCommonTextBox_20.Name = "_txtCommonTextBox_20";
			// this._txtCommonTextBox_20.ShowButton = true;
			this._txtCommonTextBox_20.Size = new System.Drawing.Size(101, 19);
			this._txtCommonTextBox_20.TabIndex = 1;
			this._txtCommonTextBox_20.Text = "";
			// this.this._txtCommonTextBox_20.Watermark = "";
			// this.this._txtCommonTextBox_20.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_20.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _lblCommonLabel_2
			// 
			this._lblCommonLabel_2.AllowDrop = true;
			this._lblCommonLabel_2.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_2.Text = "Product Code";
			this._lblCommonLabel_2.Location = new System.Drawing.Point(11, 45);
			this._lblCommonLabel_2.Name = "_lblCommonLabel_2";
			this._lblCommonLabel_2.Size = new System.Drawing.Size(65, 14);
			this._lblCommonLabel_2.TabIndex = 19;
			// 
			// _txtDisplayLabel_9
			// 
			this._txtDisplayLabel_9.AllowDrop = true;
			this._txtDisplayLabel_9.Location = new System.Drawing.Point(194, 42);
			this._txtDisplayLabel_9.Name = "_txtDisplayLabel_9";
			this._txtDisplayLabel_9.Size = new System.Drawing.Size(201, 19);
			this._txtDisplayLabel_9.TabIndex = 20;
			// 
			// _txtDisplayLabel_1
			// 
			this._txtDisplayLabel_1.AllowDrop = true;
			this._txtDisplayLabel_1.Location = new System.Drawing.Point(194, 22);
			this._txtDisplayLabel_1.Name = "_txtDisplayLabel_1";
			this._txtDisplayLabel_1.Size = new System.Drawing.Size(201, 19);
			this._txtDisplayLabel_1.TabIndex = 21;
			// 
			// txtApprovedBy
			// 
			this.txtApprovedBy.AllowDrop = true;
			this.txtApprovedBy.BackColor = System.Drawing.Color.White;
			this.txtApprovedBy.ForeColor = System.Drawing.Color.Black;
			this.txtApprovedBy.Location = new System.Drawing.Point(91, 150);
			this.txtApprovedBy.MaxLength = 50;
			this.txtApprovedBy.Name = "txtApprovedBy";
			this.txtApprovedBy.Size = new System.Drawing.Size(102, 19);
			this.txtApprovedBy.TabIndex = 5;
			this.txtApprovedBy.Text = "";
			// this.this.txtApprovedBy.Watermark = "";
			// 
			// _lblCommonLabel_0
			// 
			this._lblCommonLabel_0.AllowDrop = true;
			this._lblCommonLabel_0.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_0.Text = "Approved By";
			this._lblCommonLabel_0.Location = new System.Drawing.Point(10, 152);
			this._lblCommonLabel_0.Name = "_lblCommonLabel_0";
			this._lblCommonLabel_0.Size = new System.Drawing.Size(64, 14);
			this._lblCommonLabel_0.TabIndex = 22;
			// 
			// txtNoOfEmployees
			// 
			this.txtNoOfEmployees.AllowDrop = true;
			this.txtNoOfEmployees.BackColor = System.Drawing.Color.White;
			this.txtNoOfEmployees.ForeColor = System.Drawing.Color.Black;
			this.txtNoOfEmployees.Location = new System.Drawing.Point(91, 191);
			this.txtNoOfEmployees.MaxLength = 50;
			this.txtNoOfEmployees.Name = "txtNoOfEmployees";
			this.txtNoOfEmployees.Size = new System.Drawing.Size(102, 19);
			this.txtNoOfEmployees.TabIndex = 9;
			this.txtNoOfEmployees.Text = "";
			// this.this.txtNoOfEmployees.Watermark = "";
			// 
			// _lblCommonLabel_1
			// 
			this._lblCommonLabel_1.AllowDrop = true;
			this._lblCommonLabel_1.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_1.Text = "No. Of Employee";
			this._lblCommonLabel_1.Location = new System.Drawing.Point(9, 191);
			// // this._lblCommonLabel_1.mLabelId = 614;
			this._lblCommonLabel_1.Name = "_lblCommonLabel_1";
			this._lblCommonLabel_1.Size = new System.Drawing.Size(80, 14);
			this._lblCommonLabel_1.TabIndex = 23;
			// 
			// txtNoOfHours
			// 
			this.txtNoOfHours.AllowDrop = true;
			this.txtNoOfHours.BackColor = System.Drawing.Color.White;
			this.txtNoOfHours.ForeColor = System.Drawing.Color.Black;
			this.txtNoOfHours.Location = new System.Drawing.Point(297, 191);
			this.txtNoOfHours.MaxLength = 50;
			this.txtNoOfHours.Name = "txtNoOfHours";
			this.txtNoOfHours.Size = new System.Drawing.Size(102, 19);
			this.txtNoOfHours.TabIndex = 10;
			this.txtNoOfHours.Text = "";
			// this.this.txtNoOfHours.Watermark = "";
			// 
			// _lblCommonLabel_3
			// 
			this._lblCommonLabel_3.AllowDrop = true;
			this._lblCommonLabel_3.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_3.Text = "No. Of Hours";
			this._lblCommonLabel_3.Location = new System.Drawing.Point(214, 191);
			// // this._lblCommonLabel_3.mLabelId = 614;
			this._lblCommonLabel_3.Name = "_lblCommonLabel_3";
			this._lblCommonLabel_3.Size = new System.Drawing.Size(63, 14);
			this._lblCommonLabel_3.TabIndex = 24;
			// 
			// txtAssembledBy
			// 
			this.txtAssembledBy.AllowDrop = true;
			this.txtAssembledBy.BackColor = System.Drawing.Color.White;
			this.txtAssembledBy.ForeColor = System.Drawing.Color.Black;
			this.txtAssembledBy.Location = new System.Drawing.Point(91, 170);
			this.txtAssembledBy.MaxLength = 50;
			this.txtAssembledBy.Name = "txtAssembledBy";
			this.txtAssembledBy.Size = new System.Drawing.Size(102, 19);
			this.txtAssembledBy.TabIndex = 7;
			this.txtAssembledBy.Text = "";
			// this.this.txtAssembledBy.Watermark = "";
			// 
			// _lblCommonLabel_4
			// 
			this._lblCommonLabel_4.AllowDrop = true;
			this._lblCommonLabel_4.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_4.Text = "Assembled By";
			this._lblCommonLabel_4.Location = new System.Drawing.Point(9, 172);
			// // this._lblCommonLabel_4.mLabelId = 614;
			this._lblCommonLabel_4.Name = "_lblCommonLabel_4";
			this._lblCommonLabel_4.Size = new System.Drawing.Size(70, 14);
			this._lblCommonLabel_4.TabIndex = 25;
			// 
			// txtDesignedBy
			// 
			this.txtDesignedBy.AllowDrop = true;
			this.txtDesignedBy.BackColor = System.Drawing.Color.White;
			this.txtDesignedBy.ForeColor = System.Drawing.Color.Black;
			this.txtDesignedBy.Location = new System.Drawing.Point(297, 148);
			this.txtDesignedBy.MaxLength = 50;
			this.txtDesignedBy.Name = "txtDesignedBy";
			this.txtDesignedBy.Size = new System.Drawing.Size(102, 19);
			this.txtDesignedBy.TabIndex = 6;
			this.txtDesignedBy.Text = "";
			// this.this.txtDesignedBy.Watermark = "";
			// 
			// _lblCommonLabel_8
			// 
			this._lblCommonLabel_8.AllowDrop = true;
			this._lblCommonLabel_8.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_8.Text = "Designed By";
			this._lblCommonLabel_8.Location = new System.Drawing.Point(214, 150);
			// // this._lblCommonLabel_8.mLabelId = 614;
			this._lblCommonLabel_8.Name = "_lblCommonLabel_8";
			this._lblCommonLabel_8.Size = new System.Drawing.Size(61, 14);
			this._lblCommonLabel_8.TabIndex = 26;
			// 
			// _lblCommonLabel_10
			// 
			this._lblCommonLabel_10.AllowDrop = true;
			this._lblCommonLabel_10.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_10.Text = "Assembled Date";
			this._lblCommonLabel_10.Location = new System.Drawing.Point(214, 171);
			this._lblCommonLabel_10.Name = "_lblCommonLabel_10";
			this._lblCommonLabel_10.Size = new System.Drawing.Size(79, 14);
			this._lblCommonLabel_10.TabIndex = 27;
			// 
			// txtDAssembledDate
			// 
			this.txtDAssembledDate.AllowDrop = true;
			// this.txtDAssembledDate.CheckDateRange = false;
			this.txtDAssembledDate.Location = new System.Drawing.Point(297, 169);
			// this.txtDAssembledDate.MaxDate = 2958465;
			// this.txtDAssembledDate.MinDate = 32874;
			this.txtDAssembledDate.Name = "txtDAssembledDate";
			this.txtDAssembledDate.Size = new System.Drawing.Size(102, 19);
			this.txtDAssembledDate.TabIndex = 8;
			this.txtDAssembledDate.Text = "18/07/2001";
			// this.txtDAssembledDate.Value = 37090;
			// 
			// _txtCommonTextBox_7
			// 
			this._txtCommonTextBox_7.AllowDrop = true;
			this._txtCommonTextBox_7.BackColor = System.Drawing.Color.FromArgb(239, 239, 239);
			this._txtCommonTextBox_7.Enabled = false;
			this._txtCommonTextBox_7.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_7.Location = new System.Drawing.Point(91, 82);
			this._txtCommonTextBox_7.MaxLength = 50;
			this._txtCommonTextBox_7.Name = "_txtCommonTextBox_7";
			this._txtCommonTextBox_7.Size = new System.Drawing.Size(101, 19);
			this._txtCommonTextBox_7.TabIndex = 28;
			this._txtCommonTextBox_7.Text = "";
			// this.this._txtCommonTextBox_7.Watermark = "";
			// this.this._txtCommonTextBox_7.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_7.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _lblCommonLabel_11
			// 
			this._lblCommonLabel_11.AllowDrop = true;
			this._lblCommonLabel_11.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_11.Text = "Voucher No.";
			this._lblCommonLabel_11.Location = new System.Drawing.Point(10, 82);
			this._lblCommonLabel_11.Name = "_lblCommonLabel_11";
			this._lblCommonLabel_11.Size = new System.Drawing.Size(61, 14);
			this._lblCommonLabel_11.TabIndex = 29;
			// 
			// _txtCommonTextBox_11
			// 
			this._txtCommonTextBox_11.AllowDrop = true;
			this._txtCommonTextBox_11.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_11.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_11.Location = new System.Drawing.Point(91, 212);
			this._txtCommonTextBox_11.MaxLength = 200;
			this._txtCommonTextBox_11.Name = "_txtCommonTextBox_11";
			this._txtCommonTextBox_11.Size = new System.Drawing.Size(471, 19);
			this._txtCommonTextBox_11.TabIndex = 30;
			this._txtCommonTextBox_11.Text = "";
			// this.this._txtCommonTextBox_11.Watermark = "";
			// this.this._txtCommonTextBox_11.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_11.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _lblCommonLabel_9
			// 
			this._lblCommonLabel_9.AllowDrop = true;
			this._lblCommonLabel_9.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_9.Text = "Narration";
			this._lblCommonLabel_9.Location = new System.Drawing.Point(10, 213);
			this._lblCommonLabel_9.Name = "_lblCommonLabel_9";
			this._lblCommonLabel_9.Size = new System.Drawing.Size(45, 13);
			this._lblCommonLabel_9.TabIndex = 31;
			// 
			// _txtCommonTextBox_19
			// 
			this._txtCommonTextBox_19.AllowDrop = true;
			this._txtCommonTextBox_19.BackColor = System.Drawing.Color.FromArgb(239, 239, 239);
			// this._txtCommonTextBox_19.bolNumericOnly = true;
			this._txtCommonTextBox_19.Enabled = false;
			this._txtCommonTextBox_19.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_19.Location = new System.Drawing.Point(504, 166);
			this._txtCommonTextBox_19.Name = "_txtCommonTextBox_19";
			// this._txtCommonTextBox_19.ShowButton = true;
			this._txtCommonTextBox_19.Size = new System.Drawing.Size(101, 23);
			this._txtCommonTextBox_19.TabIndex = 32;
			this._txtCommonTextBox_19.Text = "";
			this._txtCommonTextBox_19.Visible = false;
			// this.this._txtCommonTextBox_19.Watermark = "";
			// this.this._txtCommonTextBox_19.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_19.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _txtCommonTextBox_18
			// 
			this._txtCommonTextBox_18.AllowDrop = true;
			this._txtCommonTextBox_18.BackColor = System.Drawing.Color.White;
			// this._txtCommonTextBox_18.bolNumericOnly = true;
			this._txtCommonTextBox_18.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_18.Location = new System.Drawing.Point(504, 141);
			this._txtCommonTextBox_18.Name = "_txtCommonTextBox_18";
			// this._txtCommonTextBox_18.ShowButton = true;
			this._txtCommonTextBox_18.Size = new System.Drawing.Size(101, 23);
			this._txtCommonTextBox_18.TabIndex = 33;
			this._txtCommonTextBox_18.Text = "";
			this._txtCommonTextBox_18.Visible = false;
			// this.this._txtCommonTextBox_18.Watermark = "";
			// this.this._txtCommonTextBox_18.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_18.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _lblCommonLabel_20
			// 
			this._lblCommonLabel_20.AllowDrop = true;
			this._lblCommonLabel_20.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_20.Text = " Import Voucher Information ";
			this._lblCommonLabel_20.ForeColor = System.Drawing.Color.Black;
			this._lblCommonLabel_20.Location = new System.Drawing.Point(412, 96);
			// // this._lblCommonLabel_20.mLabelId = 867;
			this._lblCommonLabel_20.Name = "_lblCommonLabel_20";
			this._lblCommonLabel_20.Size = new System.Drawing.Size(167, 16);
			this._lblCommonLabel_20.TabIndex = 34;
			this._lblCommonLabel_20.Visible = false;
			// 
			// _txtCommonTextBox_17
			// 
			this._txtCommonTextBox_17.AllowDrop = true;
			this._txtCommonTextBox_17.BackColor = System.Drawing.Color.White;
			// this._txtCommonTextBox_17.bolNumericOnly = true;
			this._txtCommonTextBox_17.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_17.Location = new System.Drawing.Point(505, 116);
			this._txtCommonTextBox_17.Name = "_txtCommonTextBox_17";
			// this._txtCommonTextBox_17.ShowButton = true;
			this._txtCommonTextBox_17.Size = new System.Drawing.Size(101, 23);
			this._txtCommonTextBox_17.TabIndex = 35;
			this._txtCommonTextBox_17.Text = "";
			this._txtCommonTextBox_17.Visible = false;
			// this.this._txtCommonTextBox_17.Watermark = "";
			// this.this._txtCommonTextBox_17.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_17.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _lblCommonLabel_23
			// 
			this._lblCommonLabel_23.AllowDrop = true;
			this._lblCommonLabel_23.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_23.Text = "Voucher No.";
			this._lblCommonLabel_23.ForeColor = System.Drawing.Color.Black;
			this._lblCommonLabel_23.Location = new System.Drawing.Point(416, 168);
			// // this._lblCommonLabel_23.mLabelId = 850;
			this._lblCommonLabel_23.Name = "_lblCommonLabel_23";
			this._lblCommonLabel_23.Size = new System.Drawing.Size(72, 16);
			this._lblCommonLabel_23.TabIndex = 36;
			this._lblCommonLabel_23.Visible = false;
			// 
			// _lblCommonLabel_22
			// 
			this._lblCommonLabel_22.AllowDrop = true;
			this._lblCommonLabel_22.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_22.Text = "Location Code";
			this._lblCommonLabel_22.ForeColor = System.Drawing.Color.Black;
			this._lblCommonLabel_22.Location = new System.Drawing.Point(416, 143);
			// // this._lblCommonLabel_22.mLabelId = 416;
			this._lblCommonLabel_22.Name = "_lblCommonLabel_22";
			this._lblCommonLabel_22.Size = new System.Drawing.Size(83, 16);
			this._lblCommonLabel_22.TabIndex = 37;
			this._lblCommonLabel_22.Visible = false;
			// 
			// _lblCommonLabel_21
			// 
			this._lblCommonLabel_21.AllowDrop = true;
			this._lblCommonLabel_21.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_21.Text = "Voucher Type";
			this._lblCommonLabel_21.ForeColor = System.Drawing.Color.Black;
			this._lblCommonLabel_21.Location = new System.Drawing.Point(416, 116);
			// // this._lblCommonLabel_21.mLabelId = 851;
			this._lblCommonLabel_21.Name = "_lblCommonLabel_21";
			this._lblCommonLabel_21.Size = new System.Drawing.Size(80, 16);
			this._lblCommonLabel_21.TabIndex = 38;
			this._lblCommonLabel_21.Visible = false;
			// 
			// _txtCommonTextBox_3
			// 
			this._txtCommonTextBox_3.AllowDrop = true;
			this._txtCommonTextBox_3.BackColor = System.Drawing.Color.White;
			// this.this._txtCommonTextBox_3.bolIsRequired = true;
			this._txtCommonTextBox_3.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_3.Location = new System.Drawing.Point(91, 62);
			this._txtCommonTextBox_3.Name = "_txtCommonTextBox_3";
			// this._txtCommonTextBox_3.ShowButton = true;
			this._txtCommonTextBox_3.Size = new System.Drawing.Size(101, 19);
			this._txtCommonTextBox_3.TabIndex = 39;
			this._txtCommonTextBox_3.Text = "";
			this._txtCommonTextBox_3.Visible = false;
			// this.this._txtCommonTextBox_3.Watermark = "";
			// this.this._txtCommonTextBox_3.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_3.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _lblCommonLabel_12
			// 
			this._lblCommonLabel_12.AllowDrop = true;
			this._lblCommonLabel_12.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_12.Text = "Supplier Code";
			this._lblCommonLabel_12.Location = new System.Drawing.Point(10, 64);
			this._lblCommonLabel_12.Name = "_lblCommonLabel_12";
			this._lblCommonLabel_12.Size = new System.Drawing.Size(67, 14);
			this._lblCommonLabel_12.TabIndex = 40;
			// 
			// _txtDisplayLabel_2
			// 
			this._txtDisplayLabel_2.AllowDrop = true;
			this._txtDisplayLabel_2.Location = new System.Drawing.Point(194, 62);
			this._txtDisplayLabel_2.Name = "_txtDisplayLabel_2";
			this._txtDisplayLabel_2.Size = new System.Drawing.Size(201, 19);
			this._txtDisplayLabel_2.TabIndex = 41;
			// 
			// fraVoucherImport
			// 
			this.fraVoucherImport.AllowDrop = true;
			this.fraVoucherImport.BackColor = System.Drawing.Color.White;
			this.fraVoucherImport.BackStyle = 0;
			this.fraVoucherImport.BorderColor = System.Drawing.Color.Black;
			this.fraVoucherImport.BorderStyle = 1;
			this.fraVoucherImport.Enabled = false;
			this.fraVoucherImport.FillColor = System.Drawing.Color.Black;
			this.fraVoucherImport.FillStyle = 1;
			this.fraVoucherImport.Location = new System.Drawing.Point(406, 106);
			this.fraVoucherImport.Name = "fraVoucherImport";
			this.fraVoucherImport.Size = new System.Drawing.Size(206, 87);
			this.fraVoucherImport.Visible = false;
			// 
			// CommandBars
			// 
			this.CommandBars.AllowDrop = true;
			this.CommandBars.Location = new System.Drawing.Point(600, 0);
			this.CommandBars.Name = "CommandBars";
			("CommandBars.OcxState");
			// 
			// fraTransactionHeader
			// 
			this.fraTransactionHeader.AllowDrop = true;
			this.fraTransactionHeader.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.fraTransactionHeader.BackStyle = 1;
			this.fraTransactionHeader.BorderColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.fraTransactionHeader.BorderStyle = 1;
			this.fraTransactionHeader.Enabled = false;
			this.fraTransactionHeader.FillColor = System.Drawing.Color.Black;
			this.fraTransactionHeader.FillStyle = 1;
			this.fraTransactionHeader.Location = new System.Drawing.Point(1, 15);
			this.fraTransactionHeader.Name = "fraTransactionHeader";
			this.fraTransactionHeader.Size = new System.Drawing.Size(640, 223);
			this.fraTransactionHeader.Visible = true;
			// 
			// frmICSBuildStock
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.ClientSize = new System.Drawing.Size(991, 545);
			this.Controls.Add(this.cmdBuildSerialNo);
			this.Controls.Add(this.cmdAddtionalDetails);
			this.Controls.Add(this.cmbMastersList);
			this.Controls.Add(this.grdVoucherDetails);
			this.Controls.Add(this._txtCommonTextBox_8);
			this.Controls.Add(this._lblCommonLabel_7);
			this.Controls.Add(this._lblCommonLabel_5);
			this.Controls.Add(this._lblCommonLabel_6);
			this.Controls.Add(this.txtVoucherDate);
			this.Controls.Add(this.txtBuildQty);
			this.Controls.Add(this._txtCommonTextBox_1);
			this.Controls.Add(this._lblCommonLabel_17);
			this.Controls.Add(this._txtCommonTextBox_20);
			this.Controls.Add(this._lblCommonLabel_2);
			this.Controls.Add(this._txtDisplayLabel_9);
			this.Controls.Add(this._txtDisplayLabel_1);
			this.Controls.Add(this.txtApprovedBy);
			this.Controls.Add(this._lblCommonLabel_0);
			this.Controls.Add(this.txtNoOfEmployees);
			this.Controls.Add(this._lblCommonLabel_1);
			this.Controls.Add(this.txtNoOfHours);
			this.Controls.Add(this._lblCommonLabel_3);
			this.Controls.Add(this.txtAssembledBy);
			this.Controls.Add(this._lblCommonLabel_4);
			this.Controls.Add(this.txtDesignedBy);
			this.Controls.Add(this._lblCommonLabel_8);
			this.Controls.Add(this._lblCommonLabel_10);
			this.Controls.Add(this.txtDAssembledDate);
			this.Controls.Add(this._txtCommonTextBox_7);
			this.Controls.Add(this._lblCommonLabel_11);
			this.Controls.Add(this._txtCommonTextBox_11);
			this.Controls.Add(this._lblCommonLabel_9);
			this.Controls.Add(this._txtCommonTextBox_19);
			this.Controls.Add(this._txtCommonTextBox_18);
			this.Controls.Add(this._lblCommonLabel_20);
			this.Controls.Add(this._txtCommonTextBox_17);
			this.Controls.Add(this._lblCommonLabel_23);
			this.Controls.Add(this._lblCommonLabel_22);
			this.Controls.Add(this._lblCommonLabel_21);
			this.Controls.Add(this._txtCommonTextBox_3);
			this.Controls.Add(this._lblCommonLabel_12);
			this.Controls.Add(this._txtDisplayLabel_2);
			this.Controls.Add(this.fraVoucherImport);
			this.Controls.Add(this.CommandBars);
			this.Controls.Add(this.fraTransactionHeader);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			//this.Icon = (System.Drawing.Icon) resources.GetObject("frmICSBuildStock.Icon");
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(187, 158);
			this.MaximizeBox = true;
			this.MinimizeBox = true;
			this.Name = "frmICSBuildStock";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Tag = "\"H: 6225  W:9570\"";
			this.Text = "Build Stock";
			// this.Activated += new System.EventHandler(this.Form_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
			this.Deactivate += new System.EventHandler(this.Form_Deactivate);
			// this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
			//this.Resize += new System.EventHandler(this.Form_Resize);
			//((System.ComponentModel.ISupportInitialize) this.CommandBars).EndInit();
			this.cmbMastersList.ResumeLayout(false);
			this.grdVoucherDetails.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		void ReLoadForm(bool addEvents)
		{
			InitializetxtDisplayLabel();
			InitializetxtCommonTextBox();
			InitializelblCommonLabel();
			//This form is an MDI child.
			//This code simulates the VB6 
			// functionality of automatically
			// loading and showing an MDI
			// child's parent.
			this.MdiParent = Xtreme.frmSysMain.DefInstance;
			Xtreme.frmSysMain.DefInstance.Show();
		}
		void InitializetxtDisplayLabel()
		{
			this.txtDisplayLabel = new System.Windows.Forms.Label[10];
			this.txtDisplayLabel[9] = _txtDisplayLabel_9;
			this.txtDisplayLabel[1] = _txtDisplayLabel_1;
			this.txtDisplayLabel[2] = _txtDisplayLabel_2;
		}
		void InitializetxtCommonTextBox()
		{
			this.txtCommonTextBox = new System.Windows.Forms.TextBox[21];
			this.txtCommonTextBox[8] = _txtCommonTextBox_8;
			this.txtCommonTextBox[1] = _txtCommonTextBox_1;
			this.txtCommonTextBox[20] = _txtCommonTextBox_20;
			this.txtCommonTextBox[7] = _txtCommonTextBox_7;
			this.txtCommonTextBox[11] = _txtCommonTextBox_11;
			this.txtCommonTextBox[19] = _txtCommonTextBox_19;
			this.txtCommonTextBox[18] = _txtCommonTextBox_18;
			this.txtCommonTextBox[17] = _txtCommonTextBox_17;
			this.txtCommonTextBox[3] = _txtCommonTextBox_3;
		}
		void InitializelblCommonLabel()
		{
			this.lblCommonLabel = new System.Windows.Forms.Label[24];
			this.lblCommonLabel[7] = _lblCommonLabel_7;
			this.lblCommonLabel[5] = _lblCommonLabel_5;
			this.lblCommonLabel[6] = _lblCommonLabel_6;
			this.lblCommonLabel[17] = _lblCommonLabel_17;
			this.lblCommonLabel[2] = _lblCommonLabel_2;
			this.lblCommonLabel[0] = _lblCommonLabel_0;
			this.lblCommonLabel[1] = _lblCommonLabel_1;
			this.lblCommonLabel[3] = _lblCommonLabel_3;
			this.lblCommonLabel[4] = _lblCommonLabel_4;
			this.lblCommonLabel[8] = _lblCommonLabel_8;
			this.lblCommonLabel[10] = _lblCommonLabel_10;
			this.lblCommonLabel[11] = _lblCommonLabel_11;
			this.lblCommonLabel[9] = _lblCommonLabel_9;
			this.lblCommonLabel[20] = _lblCommonLabel_20;
			this.lblCommonLabel[23] = _lblCommonLabel_23;
			this.lblCommonLabel[22] = _lblCommonLabel_22;
			this.lblCommonLabel[21] = _lblCommonLabel_21;
			this.lblCommonLabel[12] = _lblCommonLabel_12;
		}
		#endregion
	}
}//ENDSHERE
