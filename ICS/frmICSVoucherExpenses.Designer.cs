
namespace Xtreme
{
	partial class frmICSVoucherExpenses
	{

		#region "Upgrade Support "
		private static frmICSVoucherExpenses m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmICSVoucherExpenses DefInstance
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
		public static frmICSVoucherExpenses CreateInstance()
		{
			frmICSVoucherExpenses theInstance = new frmICSVoucherExpenses();
			
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
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "_lblCommonLabel_0", "txtTempDate", "Column_0_cmbMasterList", "Column_1_cmbMasterList", "cmbMasterList", "_optAllocation_0", "_optAllocation_1", "cmdAllocate", "_fraCommon_0", "_txtCommonTextBox_19", "_txtCommonTextBox_18", "_lblCommonLabel_2", "_txtCommonTextBox_17", "_lblCommonLabel_23", "_lblCommonLabel_21", "_txtCommonTextBox_3", "_lblCommonLabel_3", "_lblCommonLabel_24", "txtExchangeRate", "_lblCommonLabel_14", "_txtCommonTextBox_13", "_txtDisplayLabel_0", "_txtDisplayLabel_2", "_fraCommon_1", "txtVoucherDate", "_lblCommonLabel_6", "_txtCommonTextBox_8", "_lblCommonLabel_7", "_lblCommonLabel_5", "_txtCommonTextBox_7", "_txtCommonTextBox_11", "_lblCommonLabel_9", "fraTabPage0", "Column_0_grdVoucherDetails", "grdVoucherDetails", "_lblCommonLabel_4", "_lblCommonLabel_1", "Column_0_grdExpensesDetails", "Column_1_grdExpensesDetails", "grdExpensesDetails", "tcbSystemForm", "Line1", "shpDrCr", "fraCommon", "lblCommonLabel", "optAllocation", "txtCommonTextBox", "txtDisplayLabel"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		private System.Windows.Forms.Label _lblCommonLabel_0;
		public Syncfusion.WinForms.Input.SfDateTimeEdit txtTempDate;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_0_cmbMasterList;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_1_cmbMasterList;
		public C1.Win.C1TrueDBGrid.C1TrueDBDropdown cmbMasterList;
		private System.Windows.Forms.RadioButton _optAllocation_0;
		private System.Windows.Forms.RadioButton _optAllocation_1;
		public System.Windows.Forms.Button cmdAllocate;
		private System.Windows.Forms.GroupBox _fraCommon_0;
		private System.Windows.Forms.TextBox _txtCommonTextBox_19;
		private System.Windows.Forms.TextBox _txtCommonTextBox_18;
		private System.Windows.Forms.Label _lblCommonLabel_2;
		private System.Windows.Forms.TextBox _txtCommonTextBox_17;
		private System.Windows.Forms.Label _lblCommonLabel_23;
		private System.Windows.Forms.Label _lblCommonLabel_21;
		private System.Windows.Forms.TextBox _txtCommonTextBox_3;
		private System.Windows.Forms.Label _lblCommonLabel_3;
		private System.Windows.Forms.Label _lblCommonLabel_24;
		public System.Windows.Forms.TextBox txtExchangeRate;
		private System.Windows.Forms.Label _lblCommonLabel_14;
		private System.Windows.Forms.TextBox _txtCommonTextBox_13;
		private System.Windows.Forms.Label _txtDisplayLabel_0;
		private System.Windows.Forms.Label _txtDisplayLabel_2;
		private System.Windows.Forms.GroupBox _fraCommon_1;
		public Syncfusion.WinForms.Input.SfDateTimeEdit txtVoucherDate;
		private System.Windows.Forms.Label _lblCommonLabel_6;
		private System.Windows.Forms.TextBox _txtCommonTextBox_8;
		private System.Windows.Forms.Label _lblCommonLabel_7;
		private System.Windows.Forms.Label _lblCommonLabel_5;
		private System.Windows.Forms.TextBox _txtCommonTextBox_7;
		private System.Windows.Forms.TextBox _txtCommonTextBox_11;
		private System.Windows.Forms.Label _lblCommonLabel_9;
		public AxTDBContainer3D6.AxTDBContainer3D fraTabPage0;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_0_grdVoucherDetails;
		public C1.Win.C1TrueDBGrid.C1TrueDBGrid grdVoucherDetails;
		private System.Windows.Forms.Label _lblCommonLabel_4;
		private System.Windows.Forms.Label _lblCommonLabel_1;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_0_grdExpensesDetails;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_1_grdExpensesDetails;
		public C1.Win.C1TrueDBGrid.C1TrueDBGrid grdExpensesDetails;
		public Syncfusion.Windows.Forms.Tools.CommandBarController tcbSystemForm;
		public System.Windows.Forms.Label Line1;
		public UpgradeHelpers.Gui.ShapeHelper shpDrCr;
		public System.Windows.Forms.GroupBox[] fraCommon = new System.Windows.Forms.GroupBox[2];
		public System.Windows.Forms.Label[] lblCommonLabel = new System.Windows.Forms.Label[25];
		public System.Windows.Forms.RadioButton[] optAllocation = new System.Windows.Forms.RadioButton[2];
		public System.Windows.Forms.TextBox[] txtCommonTextBox = new System.Windows.Forms.TextBox[20];
		public System.Windows.Forms.Label[] txtDisplayLabel = new System.Windows.Forms.Label[3];
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmICSVoucherExpenses));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this._lblCommonLabel_0 = new System.Windows.Forms.Label();
			this.txtTempDate = new Syncfusion.WinForms.Input.SfDateTimeEdit();
			this.cmbMasterList = new C1.Win.C1TrueDBGrid.C1TrueDBDropdown();
			this.Column_0_cmbMasterList = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.Column_1_cmbMasterList = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this._fraCommon_0 = new System.Windows.Forms.GroupBox();
			this._optAllocation_0 = new System.Windows.Forms.RadioButton();
			this._optAllocation_1 = new System.Windows.Forms.RadioButton();
			this.cmdAllocate = new System.Windows.Forms.Button();
			this.fraTabPage0 = new AxTDBContainer3D6.AxTDBContainer3D();
			this._fraCommon_1 = new System.Windows.Forms.GroupBox();
			this._txtCommonTextBox_19 = new System.Windows.Forms.TextBox();
			this._txtCommonTextBox_18 = new System.Windows.Forms.TextBox();
			this._lblCommonLabel_2 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_17 = new System.Windows.Forms.TextBox();
			this._lblCommonLabel_23 = new System.Windows.Forms.Label();
			this._lblCommonLabel_21 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_3 = new System.Windows.Forms.TextBox();
			this._lblCommonLabel_3 = new System.Windows.Forms.Label();
			this._lblCommonLabel_24 = new System.Windows.Forms.Label();
			this.txtExchangeRate = new System.Windows.Forms.TextBox();
			this._lblCommonLabel_14 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_13 = new System.Windows.Forms.TextBox();
			this._txtDisplayLabel_0 = new System.Windows.Forms.Label();
			this._txtDisplayLabel_2 = new System.Windows.Forms.Label();
			this.txtVoucherDate = new Syncfusion.WinForms.Input.SfDateTimeEdit();
			this._lblCommonLabel_6 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_8 = new System.Windows.Forms.TextBox();
			this._lblCommonLabel_7 = new System.Windows.Forms.Label();
			this._lblCommonLabel_5 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_7 = new System.Windows.Forms.TextBox();
			this._txtCommonTextBox_11 = new System.Windows.Forms.TextBox();
			this._lblCommonLabel_9 = new System.Windows.Forms.Label();
			this.grdVoucherDetails = new C1.Win.C1TrueDBGrid.C1TrueDBGrid();
			this.Column_0_grdVoucherDetails = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this._lblCommonLabel_4 = new System.Windows.Forms.Label();
			this._lblCommonLabel_1 = new System.Windows.Forms.Label();
			this.grdExpensesDetails = new C1.Win.C1TrueDBGrid.C1TrueDBGrid();
			this.Column_0_grdExpensesDetails = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.Column_1_grdExpensesDetails = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.tcbSystemForm = new Syncfusion.Windows.Forms.Tools.CommandBarController();
			this.Line1 = new System.Windows.Forms.Label();
			this.shpDrCr = new UpgradeHelpers.Gui.ShapeHelper();
			// //((System.ComponentModel.ISupportInitialize) this.txtTempDate).BeginInit();
			// //((System.ComponentModel.ISupportInitialize) this.fraTabPage0).BeginInit();
			// //((System.ComponentModel.ISupportInitialize) this.tcbSystemForm).BeginInit();
			this.cmbMasterList.SuspendLayout();
			this._fraCommon_0.SuspendLayout();
			this.fraTabPage0.SuspendLayout();
			this._fraCommon_1.SuspendLayout();
			this.grdVoucherDetails.SuspendLayout();
			this.grdExpensesDetails.SuspendLayout();
			this.SuspendLayout();
			// 
			// _lblCommonLabel_0
			// 
			this._lblCommonLabel_0.AllowDrop = true;
			this._lblCommonLabel_0.BackColor = System.Drawing.SystemColors.Window;
			this._lblCommonLabel_0.Text = " Expenses Allocation On Products : ";
			this._lblCommonLabel_0.ForeColor = System.Drawing.Color.Black;
			this._lblCommonLabel_0.Location = new System.Drawing.Point(2, 350);
			this._lblCommonLabel_0.Name = "_lblCommonLabel_0";
			this._lblCommonLabel_0.Size = new System.Drawing.Size(170, 13);
			this._lblCommonLabel_0.TabIndex = 31;
			// 
			// txtTempDate
			// 
			this.txtTempDate.AllowDrop = true;
			this.txtTempDate.Location = new System.Drawing.Point(36, 272);
			this.txtTempDate.Name = "txtTempDate";
			("txtTempDate.OcxState");
			this.txtTempDate.Size = new System.Drawing.Size(109, 19);
			this.txtTempDate.TabIndex = 29;
			this.txtTempDate.Visible = false;
			// 
			// cmbMasterList
			// 
			this.cmbMasterList.AllowDrop = true;
			this.cmbMasterList.ColumnHeaders = true;
			this.cmbMasterList.Enabled = true;
			this.cmbMasterList.Location = new System.Drawing.Point(160, 224);
			this.cmbMasterList.Name = "cmbMasterList";
			this.cmbMasterList.Size = new System.Drawing.Size(241, 53);
			this.cmbMasterList.TabIndex = 16;
			this.cmbMasterList.TabStop = false;
			this.cmbMasterList.Columns.Add(this.Column_0_cmbMasterList);
			this.cmbMasterList.Columns.Add(this.Column_1_cmbMasterList);
			// 
			// Column_0_cmbMasterList
			// 
			this.Column_0_cmbMasterList.DataField = "";
			this.Column_0_cmbMasterList.ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.Normal;
			// 
			// Column_1_cmbMasterList
			// 
			this.Column_1_cmbMasterList.DataField = "";
			this.Column_1_cmbMasterList.ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.Normal;
			// 
			// _fraCommon_0
			// 
			this._fraCommon_0.AllowDrop = true;
			this._fraCommon_0.BackColor = System.Drawing.Color.FromArgb(208, 217, 208);
			this._fraCommon_0.Controls.Add(this._optAllocation_0);
			this._fraCommon_0.Controls.Add(this._optAllocation_1);
			this._fraCommon_0.Controls.Add(this.cmdAllocate);
			this._fraCommon_0.Enabled = true;
			this._fraCommon_0.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Italic | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 178);
			this._fraCommon_0.ForeColor = System.Drawing.SystemColors.WindowText;
			this._fraCommon_0.Location = new System.Drawing.Point(421, 332);
			this._fraCommon_0.Name = "_fraCommon_0";
			this._fraCommon_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._fraCommon_0.Size = new System.Drawing.Size(335, 34);
			this._fraCommon_0.TabIndex = 28;
			this._fraCommon_0.Text = " Expenses Allocation By  ";
			this._fraCommon_0.Visible = true;
			// 
			// _optAllocation_0
			// 
			this._optAllocation_0.AllowDrop = true;
			this._optAllocation_0.Appearance = System.Windows.Forms.Appearance.Normal;
			this._optAllocation_0.BackColor = System.Drawing.Color.FromArgb(208, 217, 208);
			this._optAllocation_0.CausesValidation = true;
			this._optAllocation_0.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._optAllocation_0.Checked = true;
			this._optAllocation_0.Enabled = true;
			this._optAllocation_0.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Italic | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 178);
			this._optAllocation_0.ForeColor = System.Drawing.SystemColors.ControlText;
			this._optAllocation_0.Location = new System.Drawing.Point(16, 14);
			this._optAllocation_0.Name = "_optAllocation_0";
			this._optAllocation_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._optAllocation_0.Size = new System.Drawing.Size(112, 16);
			this._optAllocation_0.TabIndex = 8;
			this._optAllocation_0.TabStop = true;
			this._optAllocation_0.Text = "Amount Wise";
			this._optAllocation_0.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._optAllocation_0.Visible = true;
			// 
			// _optAllocation_1
			// 
			this._optAllocation_1.AllowDrop = true;
			this._optAllocation_1.Appearance = System.Windows.Forms.Appearance.Normal;
			this._optAllocation_1.BackColor = System.Drawing.Color.FromArgb(208, 217, 208);
			this._optAllocation_1.CausesValidation = true;
			this._optAllocation_1.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._optAllocation_1.Checked = false;
			this._optAllocation_1.Enabled = true;
			this._optAllocation_1.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Italic | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 178);
			this._optAllocation_1.ForeColor = System.Drawing.SystemColors.ControlText;
			this._optAllocation_1.Location = new System.Drawing.Point(138, 14);
			this._optAllocation_1.Name = "_optAllocation_1";
			this._optAllocation_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._optAllocation_1.Size = new System.Drawing.Size(110, 16);
			this._optAllocation_1.TabIndex = 9;
			this._optAllocation_1.TabStop = true;
			this._optAllocation_1.Text = "Quantity Wise";
			this._optAllocation_1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._optAllocation_1.Visible = true;
			// 
			// cmdAllocate
			// 
			this.cmdAllocate.AllowDrop = true;
			this.cmdAllocate.BackColor = System.Drawing.SystemColors.Control;
			this.cmdAllocate.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdAllocate.Location = new System.Drawing.Point(252, 12);
			this.cmdAllocate.Name = "cmdAllocate";
			this.cmdAllocate.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdAllocate.Size = new System.Drawing.Size(77, 19);
			this.cmdAllocate.TabIndex = 10;
			// this.cmdAllocate.Text = "A l l o c a t e";
			// this.cmdAllocate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.cmdAllocate.UseVisualStyleBackColor = false;
			// this.cmdAllocate.Click += new System.EventHandler(this.cmdAllocate_Click);
			// 
			// fraTabPage0
			// 
			this.fraTabPage0.AllowDrop = true;
			this.fraTabPage0.Controls.Add(this._fraCommon_1);
			this.fraTabPage0.Controls.Add(this.txtVoucherDate);
			this.fraTabPage0.Controls.Add(this._lblCommonLabel_6);
			this.fraTabPage0.Controls.Add(this._txtCommonTextBox_8);
			this.fraTabPage0.Controls.Add(this._lblCommonLabel_7);
			this.fraTabPage0.Controls.Add(this._lblCommonLabel_5);
			this.fraTabPage0.Controls.Add(this._txtCommonTextBox_7);
			this.fraTabPage0.Controls.Add(this._txtCommonTextBox_11);
			this.fraTabPage0.Controls.Add(this._lblCommonLabel_9);
			this.fraTabPage0.Location = new System.Drawing.Point(4, 44);
			this.fraTabPage0.Name = "fraTabPage0";
			("fraTabPage0.OcxState");
			this.fraTabPage0.Size = new System.Drawing.Size(751, 121);
			this.fraTabPage0.TabIndex = 12;
			// 
			// _fraCommon_1
			// 
			this._fraCommon_1.AllowDrop = true;
			this._fraCommon_1.BackColor = System.Drawing.Color.FromArgb(244, 245, 231);
			this._fraCommon_1.Controls.Add(this._txtCommonTextBox_19);
			this._fraCommon_1.Controls.Add(this._txtCommonTextBox_18);
			this._fraCommon_1.Controls.Add(this._lblCommonLabel_2);
			this._fraCommon_1.Controls.Add(this._txtCommonTextBox_17);
			this._fraCommon_1.Controls.Add(this._lblCommonLabel_23);
			this._fraCommon_1.Controls.Add(this._lblCommonLabel_21);
			this._fraCommon_1.Controls.Add(this._txtCommonTextBox_3);
			this._fraCommon_1.Controls.Add(this._lblCommonLabel_3);
			this._fraCommon_1.Controls.Add(this._lblCommonLabel_24);
			this._fraCommon_1.Controls.Add(this.txtExchangeRate);
			this._fraCommon_1.Controls.Add(this._lblCommonLabel_14);
			this._fraCommon_1.Controls.Add(this._txtCommonTextBox_13);
			this._fraCommon_1.Controls.Add(this._txtDisplayLabel_0);
			this._fraCommon_1.Controls.Add(this._txtDisplayLabel_2);
			this._fraCommon_1.Enabled = true;
			this._fraCommon_1.ForeColor = System.Drawing.SystemColors.ControlText;
			this._fraCommon_1.Location = new System.Drawing.Point(6, 4);
			this._fraCommon_1.Name = "_fraCommon_1";
			this._fraCommon_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._fraCommon_1.Size = new System.Drawing.Size(409, 109);
			this._fraCommon_1.TabIndex = 17;
			this._fraCommon_1.Text = " Voucher Information ";
			this._fraCommon_1.Visible = true;
			// 
			// _txtCommonTextBox_19
			// 
			this._txtCommonTextBox_19.AllowDrop = true;
			this._txtCommonTextBox_19.BackColor = System.Drawing.Color.FromArgb(239, 239, 239);
			// this._txtCommonTextBox_19.bolNumericOnly = true;
			this._txtCommonTextBox_19.Enabled = false;
			this._txtCommonTextBox_19.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_19.Location = new System.Drawing.Point(298, 41);
			this._txtCommonTextBox_19.Name = "_txtCommonTextBox_19";
			// this._txtCommonTextBox_19.ShowButton = true;
			this._txtCommonTextBox_19.Size = new System.Drawing.Size(101, 19);
			this._txtCommonTextBox_19.TabIndex = 2;
			this._txtCommonTextBox_19.Text = "";
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
			this._txtCommonTextBox_18.Location = new System.Drawing.Point(95, 41);
			this._txtCommonTextBox_18.MaxLength = 4;
			this._txtCommonTextBox_18.Name = "_txtCommonTextBox_18";
			// this._txtCommonTextBox_18.ShowButton = true;
			this._txtCommonTextBox_18.Size = new System.Drawing.Size(101, 19);
			this._txtCommonTextBox_18.TabIndex = 1;
			this._txtCommonTextBox_18.Text = "";
			// this.this._txtCommonTextBox_18.Watermark = "";
			// this.this._txtCommonTextBox_18.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_18.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _lblCommonLabel_2
			// 
			this._lblCommonLabel_2.AllowDrop = true;
			this._lblCommonLabel_2.BackColor = System.Drawing.SystemColors.Window;
			this._lblCommonLabel_2.Text = "Location Code";
			this._lblCommonLabel_2.ForeColor = System.Drawing.Color.Black;
			this._lblCommonLabel_2.Location = new System.Drawing.Point(10, 44);
			// // this._lblCommonLabel_2.mLabelId = 416;
			this._lblCommonLabel_2.Name = "_lblCommonLabel_2";
			this._lblCommonLabel_2.Size = new System.Drawing.Size(69, 14);
			this._lblCommonLabel_2.TabIndex = 18;
			// 
			// _txtCommonTextBox_17
			// 
			this._txtCommonTextBox_17.AllowDrop = true;
			this._txtCommonTextBox_17.BackColor = System.Drawing.Color.FromArgb(239, 239, 239);
			// this._txtCommonTextBox_17.bolNumericOnly = true;
			this._txtCommonTextBox_17.Enabled = false;
			this._txtCommonTextBox_17.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_17.Location = new System.Drawing.Point(95, 20);
			this._txtCommonTextBox_17.Name = "_txtCommonTextBox_17";
			// this._txtCommonTextBox_17.ShowButton = true;
			this._txtCommonTextBox_17.Size = new System.Drawing.Size(101, 19);
			this._txtCommonTextBox_17.TabIndex = 0;
			this._txtCommonTextBox_17.Text = "";
			// this.this._txtCommonTextBox_17.Watermark = "";
			// this.this._txtCommonTextBox_17.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_17.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _lblCommonLabel_23
			// 
			this._lblCommonLabel_23.AllowDrop = true;
			this._lblCommonLabel_23.BackColor = System.Drawing.SystemColors.Window;
			this._lblCommonLabel_23.Text = "Voucher No.";
			this._lblCommonLabel_23.ForeColor = System.Drawing.Color.Black;
			this._lblCommonLabel_23.Location = new System.Drawing.Point(226, 44);
			// // this._lblCommonLabel_23.mLabelId = 850;
			this._lblCommonLabel_23.Name = "_lblCommonLabel_23";
			this._lblCommonLabel_23.Size = new System.Drawing.Size(61, 14);
			this._lblCommonLabel_23.TabIndex = 19;
			// 
			// _lblCommonLabel_21
			// 
			this._lblCommonLabel_21.AllowDrop = true;
			this._lblCommonLabel_21.BackColor = System.Drawing.SystemColors.Window;
			this._lblCommonLabel_21.Text = "Voucher Type";
			this._lblCommonLabel_21.ForeColor = System.Drawing.Color.Black;
			this._lblCommonLabel_21.Location = new System.Drawing.Point(10, 23);
			// // this._lblCommonLabel_21.mLabelId = 851;
			this._lblCommonLabel_21.Name = "_lblCommonLabel_21";
			this._lblCommonLabel_21.Size = new System.Drawing.Size(69, 14);
			this._lblCommonLabel_21.TabIndex = 20;
			// 
			// _txtCommonTextBox_3
			// 
			this._txtCommonTextBox_3.AllowDrop = true;
			this._txtCommonTextBox_3.BackColor = System.Drawing.Color.FromArgb(239, 239, 239);
			// this._txtCommonTextBox_3.bolNumericOnly = true;
			this._txtCommonTextBox_3.Enabled = false;
			this._txtCommonTextBox_3.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_3.Location = new System.Drawing.Point(95, 83);
			this._txtCommonTextBox_3.Name = "_txtCommonTextBox_3";
			this._txtCommonTextBox_3.Size = new System.Drawing.Size(101, 19);
			this._txtCommonTextBox_3.TabIndex = 21;
			this._txtCommonTextBox_3.Text = "";
			// this.this._txtCommonTextBox_3.Watermark = "";
			// this.this._txtCommonTextBox_3.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_3.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _lblCommonLabel_3
			// 
			this._lblCommonLabel_3.AllowDrop = true;
			this._lblCommonLabel_3.BackColor = System.Drawing.SystemColors.Window;
			this._lblCommonLabel_3.Text = "Supplier Code";
			this._lblCommonLabel_3.ForeColor = System.Drawing.Color.Black;
			this._lblCommonLabel_3.Location = new System.Drawing.Point(10, 86);
			this._lblCommonLabel_3.Name = "_lblCommonLabel_3";
			this._lblCommonLabel_3.Size = new System.Drawing.Size(67, 14);
			this._lblCommonLabel_3.TabIndex = 22;
			// 
			// _lblCommonLabel_24
			// 
			this._lblCommonLabel_24.AllowDrop = true;
			this._lblCommonLabel_24.BackColor = System.Drawing.SystemColors.Window;
			this._lblCommonLabel_24.Text = "Currency";
			this._lblCommonLabel_24.ForeColor = System.Drawing.Color.Black;
			this._lblCommonLabel_24.Location = new System.Drawing.Point(226, 65);
			// // this._lblCommonLabel_24.mLabelId = 877;
			this._lblCommonLabel_24.Name = "_lblCommonLabel_24";
			this._lblCommonLabel_24.Size = new System.Drawing.Size(44, 13);
			this._lblCommonLabel_24.TabIndex = 23;
			this._lblCommonLabel_24.Tag = "Currency : ";
			// 
			// txtExchangeRate
			// 
			this.txtExchangeRate.AllowDrop = true;
			this.txtExchangeRate.BackColor = System.Drawing.Color.FromArgb(239, 239, 239);
			// this.txtExchangeRate.DisplayFormat = "####0.000######;; ; ";
			this.txtExchangeRate.Enabled = false;
			// this.txtExchangeRate.Format = "####0.000######";
			this.txtExchangeRate.Location = new System.Drawing.Point(95, 62);
			// this.txtExchangeRate.MaxValue = 2147483647;
			// this.txtExchangeRate.MinValue = 0;
			this.txtExchangeRate.Name = "txtExchangeRate";
			this.txtExchangeRate.Size = new System.Drawing.Size(101, 19);
			this.txtExchangeRate.TabIndex = 24;
			// this.txtExchangeRate.Text = "0.000";
			// 
			// _lblCommonLabel_14
			// 
			this._lblCommonLabel_14.AllowDrop = true;
			this._lblCommonLabel_14.BackColor = System.Drawing.SystemColors.Window;
			this._lblCommonLabel_14.Text = "Exchange Rate";
			this._lblCommonLabel_14.ForeColor = System.Drawing.Color.Black;
			this._lblCommonLabel_14.Location = new System.Drawing.Point(10, 65);
			// // this._lblCommonLabel_14.mLabelId = 260;
			this._lblCommonLabel_14.Name = "_lblCommonLabel_14";
			this._lblCommonLabel_14.Size = new System.Drawing.Size(73, 14);
			this._lblCommonLabel_14.TabIndex = 25;
			// 
			// _txtCommonTextBox_13
			// 
			this._txtCommonTextBox_13.AllowDrop = true;
			this._txtCommonTextBox_13.BackColor = System.Drawing.Color.FromArgb(239, 239, 239);
			// this._txtCommonTextBox_13.bolNumericOnly = true;
			this._txtCommonTextBox_13.Enabled = false;
			this._txtCommonTextBox_13.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_13.Location = new System.Drawing.Point(298, 62);
			this._txtCommonTextBox_13.Name = "_txtCommonTextBox_13";
			this._txtCommonTextBox_13.Size = new System.Drawing.Size(101, 19);
			this._txtCommonTextBox_13.TabIndex = 32;
			this._txtCommonTextBox_13.Text = "";
			// this.this._txtCommonTextBox_13.Watermark = "";
			// this.this._txtCommonTextBox_13.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_13.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _txtDisplayLabel_0
			// 
			this._txtDisplayLabel_0.AllowDrop = true;
			this._txtDisplayLabel_0.Location = new System.Drawing.Point(198, 20);
			this._txtDisplayLabel_0.Name = "_txtDisplayLabel_0";
			this._txtDisplayLabel_0.Size = new System.Drawing.Size(201, 19);
			this._txtDisplayLabel_0.TabIndex = 33;
			// 
			// _txtDisplayLabel_2
			// 
			this._txtDisplayLabel_2.AllowDrop = true;
			this._txtDisplayLabel_2.Location = new System.Drawing.Point(198, 83);
			this._txtDisplayLabel_2.Name = "_txtDisplayLabel_2";
			this._txtDisplayLabel_2.Size = new System.Drawing.Size(201, 19);
			this._txtDisplayLabel_2.TabIndex = 34;
			// 
			// txtVoucherDate
			// 
			this.txtVoucherDate.AllowDrop = true;
			// this.txtVoucherDate.CheckDateRange = false;
			this.txtVoucherDate.Location = new System.Drawing.Point(636, 33);
			// this.txtVoucherDate.MaxDate = 2958465;
			// this.txtVoucherDate.MinDate = 32874;
			this.txtVoucherDate.Name = "txtVoucherDate";
			this.txtVoucherDate.Size = new System.Drawing.Size(102, 19);
			this.txtVoucherDate.TabIndex = 4;
			// this.txtVoucherDate.Text = "07/18/2001";
			// this.txtVoucherDate.Value = 37090;
			this.txtVoucherDate.Validating += new System.ComponentModel.CancelEventHandler(this.txtVoucherDate_Validating);
			// 
			// _lblCommonLabel_6
			// 
			this._lblCommonLabel_6.AllowDrop = true;
			this._lblCommonLabel_6.BackColor = System.Drawing.SystemColors.Window;
			this._lblCommonLabel_6.Text = "Transaction Date";
			this._lblCommonLabel_6.ForeColor = System.Drawing.Color.Black;
			this._lblCommonLabel_6.Location = new System.Drawing.Point(545, 35);
			// // this._lblCommonLabel_6.mLabelId = 848;
			this._lblCommonLabel_6.Name = "_lblCommonLabel_6";
			this._lblCommonLabel_6.Size = new System.Drawing.Size(82, 14);
			this._lblCommonLabel_6.TabIndex = 13;
			// 
			// _txtCommonTextBox_8
			// 
			this._txtCommonTextBox_8.AllowDrop = true;
			this._txtCommonTextBox_8.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_8.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_8.Location = new System.Drawing.Point(636, 54);
			this._txtCommonTextBox_8.MaxLength = 20;
			this._txtCommonTextBox_8.Name = "_txtCommonTextBox_8";
			this._txtCommonTextBox_8.Size = new System.Drawing.Size(102, 19);
			this._txtCommonTextBox_8.TabIndex = 5;
			this._txtCommonTextBox_8.Text = "";
			// this.this._txtCommonTextBox_8.Watermark = "";
			// this.this._txtCommonTextBox_8.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_8.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _lblCommonLabel_7
			// 
			this._lblCommonLabel_7.AllowDrop = true;
			this._lblCommonLabel_7.BackColor = System.Drawing.SystemColors.Window;
			this._lblCommonLabel_7.Text = "Reference No.";
			this._lblCommonLabel_7.ForeColor = System.Drawing.Color.Black;
			this._lblCommonLabel_7.Location = new System.Drawing.Point(545, 56);
			// // this._lblCommonLabel_7.mLabelId = 614;
			this._lblCommonLabel_7.Name = "_lblCommonLabel_7";
			this._lblCommonLabel_7.Size = new System.Drawing.Size(70, 14);
			this._lblCommonLabel_7.TabIndex = 14;
			// 
			// _lblCommonLabel_5
			// 
			this._lblCommonLabel_5.AllowDrop = true;
			this._lblCommonLabel_5.BackColor = System.Drawing.SystemColors.Window;
			this._lblCommonLabel_5.Text = "Transaction No.";
			this._lblCommonLabel_5.ForeColor = System.Drawing.Color.Black;
			this._lblCommonLabel_5.Location = new System.Drawing.Point(545, 14);
			// // this._lblCommonLabel_5.mLabelId = 850;
			this._lblCommonLabel_5.Name = "_lblCommonLabel_5";
			this._lblCommonLabel_5.Size = new System.Drawing.Size(76, 14);
			this._lblCommonLabel_5.TabIndex = 15;
			// 
			// _txtCommonTextBox_7
			// 
			this._txtCommonTextBox_7.AllowDrop = true;
			this._txtCommonTextBox_7.BackColor = System.Drawing.Color.FromArgb(239, 239, 239);
			// this._txtCommonTextBox_7.bolNumericOnly = true;
			this._txtCommonTextBox_7.Enabled = false;
			this._txtCommonTextBox_7.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_7.Location = new System.Drawing.Point(636, 12);
			this._txtCommonTextBox_7.Name = "_txtCommonTextBox_7";
			this._txtCommonTextBox_7.Size = new System.Drawing.Size(102, 19);
			this._txtCommonTextBox_7.TabIndex = 3;
			this._txtCommonTextBox_7.Text = "";
			// this.this._txtCommonTextBox_7.Watermark = "";
			// this.this._txtCommonTextBox_7.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_7.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _txtCommonTextBox_11
			// 
			this._txtCommonTextBox_11.AllowDrop = true;
			this._txtCommonTextBox_11.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_11.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_11.Location = new System.Drawing.Point(489, 92);
			this._txtCommonTextBox_11.MaxLength = 200;
			this._txtCommonTextBox_11.Name = "_txtCommonTextBox_11";
			this._txtCommonTextBox_11.Size = new System.Drawing.Size(249, 19);
			this._txtCommonTextBox_11.TabIndex = 6;
			this._txtCommonTextBox_11.Text = "";
			// this.this._txtCommonTextBox_11.Watermark = "";
			// this.this._txtCommonTextBox_11.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_11.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _lblCommonLabel_9
			// 
			this._lblCommonLabel_9.AllowDrop = true;
			this._lblCommonLabel_9.BackColor = System.Drawing.SystemColors.Window;
			this._lblCommonLabel_9.Text = "Comments";
			this._lblCommonLabel_9.ForeColor = System.Drawing.Color.Black;
			this._lblCommonLabel_9.Location = new System.Drawing.Point(428, 95);
			// // this._lblCommonLabel_9.mLabelId = 869;
			this._lblCommonLabel_9.Name = "_lblCommonLabel_9";
			this._lblCommonLabel_9.Size = new System.Drawing.Size(50, 13);
			this._lblCommonLabel_9.TabIndex = 30;
			// 
			// grdVoucherDetails
			// 
			this.grdVoucherDetails.AllowDrop = true;
			this.grdVoucherDetails.BackColor = System.Drawing.Color.FromArgb(212, 208, 200);
			this.grdVoucherDetails.CellTipsWidth = 0;
			this.grdVoucherDetails.Location = new System.Drawing.Point(0, 368);
			this.grdVoucherDetails.Name = "grdVoucherDetails";
			this.grdVoucherDetails.RowDivider.Color = System.Drawing.Color.FromArgb(212, 208, 200);
			this.grdVoucherDetails.Size = new System.Drawing.Size(758, 113);
			this.grdVoucherDetails.TabIndex = 11;
			this.grdVoucherDetails.Columns.Add(this.Column_0_grdVoucherDetails);
			this.grdVoucherDetails.AfterColUpdate += new C1.Win.C1TrueDBGrid.ColEventHandler(this.grdVoucherDetails_AfterColUpdate);
			// 
			// Column_0_grdVoucherDetails
			// 
			this.Column_0_grdVoucherDetails.DataField = "";
			this.Column_0_grdVoucherDetails.ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.Normal;
			// 
			// _lblCommonLabel_4
			// 
			this._lblCommonLabel_4.AllowDrop = true;
			this._lblCommonLabel_4.BackColor = System.Drawing.SystemColors.Window;
			this._lblCommonLabel_4.Text = "C  r  e  d  i  t";
			this._lblCommonLabel_4.ForeColor = System.Drawing.Color.White;
			this._lblCommonLabel_4.Location = new System.Drawing.Point(537, 172);
			this._lblCommonLabel_4.Name = "_lblCommonLabel_4";
			this._lblCommonLabel_4.Size = new System.Drawing.Size(64, 13);
			this._lblCommonLabel_4.TabIndex = 26;
			// 
			// _lblCommonLabel_1
			// 
			this._lblCommonLabel_1.AllowDrop = true;
			this._lblCommonLabel_1.BackColor = System.Drawing.SystemColors.Window;
			this._lblCommonLabel_1.Text = "D  e  b  i  t";
			this._lblCommonLabel_1.ForeColor = System.Drawing.Color.White;
			this._lblCommonLabel_1.Location = new System.Drawing.Point(157, 172);
			this._lblCommonLabel_1.Name = "_lblCommonLabel_1";
			this._lblCommonLabel_1.Size = new System.Drawing.Size(54, 13);
			this._lblCommonLabel_1.TabIndex = 27;
			// 
			// grdExpensesDetails
			// 
			this.grdExpensesDetails.AllowDrop = true;
			this.grdExpensesDetails.BackColor = System.Drawing.Color.Silver;
			this.grdExpensesDetails.CellTipsWidth = 0;
			this.grdExpensesDetails.Location = new System.Drawing.Point(0, 188);
			this.grdExpensesDetails.Name = "grdExpensesDetails";
			this.grdExpensesDetails.RowDivider.Color = System.Drawing.Color.Silver;
			this.grdExpensesDetails.Size = new System.Drawing.Size(758, 142);
			this.grdExpensesDetails.TabIndex = 7;
			this.grdExpensesDetails.Columns.Add(this.Column_0_grdExpensesDetails);
			this.grdExpensesDetails.Columns.Add(this.Column_1_grdExpensesDetails);
			this.grdExpensesDetails.AfterColUpdate += new C1.Win.C1TrueDBGrid.ColEventHandler(this.grdExpensesDetails_AfterColUpdate);
			this.grdExpensesDetails.BeforeColEdit += new C1.Win.C1TrueDBGrid.BeforeColEditEventHandler(this.grdExpensesDetails_BeforeColEdit);
			this.grdExpensesDetails.GotFocus += new System.EventHandler(this.grdExpensesDetails_GotFocus);
			this.grdExpensesDetails.RowColChange += new C1.Win.C1TrueDBGrid.RowColChangeEventHandler(this.grdExpensesDetails_RowColChange);
			// 
			// Column_0_grdExpensesDetails
			// 
			this.Column_0_grdExpensesDetails.DataField = "";
			this.Column_0_grdExpensesDetails.ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.Normal;
			// 
			// Column_1_grdExpensesDetails
			// 
			this.Column_1_grdExpensesDetails.DataField = "";
			this.Column_1_grdExpensesDetails.ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.Normal;
			// 
			// tcbSystemForm
			// 
			this.tcbSystemForm.AllowDrop = true;
			this.tcbSystemForm.Location = new System.Drawing.Point(274, 6);
			this.tcbSystemForm.Name = "tcbSystemForm";
			("tcbSystemForm.OcxState");
			// 
			// Line1
			// 
			this.Line1.AllowDrop = true;
			this.Line1.BackColor = System.Drawing.SystemColors.WindowText;
			this.Line1.Enabled = false;
			this.Line1.Location = new System.Drawing.Point(382, 168);
			this.Line1.Name = "Line1";
			this.Line1.Size = new System.Drawing.Size(1, 22);
			this.Line1.Visible = true;
			// 
			// shpDrCr
			// 
			this.shpDrCr.AllowDrop = true;
			this.shpDrCr.BackColor = System.Drawing.Color.FromArgb(224, 180, 171);
			this.shpDrCr.BackStyle = 0;
			this.shpDrCr.BorderStyle = 1;
			this.shpDrCr.Enabled = false;
			this.shpDrCr.FillColor = System.Drawing.Color.FromArgb(153, 164, 154);
			this.shpDrCr.FillStyle = 0;
			this.shpDrCr.Location = new System.Drawing.Point(0, 168);
			this.shpDrCr.Name = "shpDrCr";
			this.shpDrCr.Size = new System.Drawing.Size(758, 21);
			this.shpDrCr.Visible = true;
			// 
			// frmICSVoucherExpenses
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.FromArgb(208, 217, 208);
			this.ClientSize = new System.Drawing.Size(758, 480);
			this.Controls.Add(this._lblCommonLabel_0);
			this.Controls.Add(this.txtTempDate);
			this.Controls.Add(this.cmbMasterList);
			this.Controls.Add(this._fraCommon_0);
			this.Controls.Add(this.fraTabPage0);
			this.Controls.Add(this.grdVoucherDetails);
			this.Controls.Add(this._lblCommonLabel_4);
			this.Controls.Add(this._lblCommonLabel_1);
			this.Controls.Add(this.grdExpensesDetails);
			this.Controls.Add(this.tcbSystemForm);
			this.Controls.Add(this.Line1);
			this.Controls.Add(this.shpDrCr);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			//this.Icon = (System.Drawing.Icon) resources.GetObject("frmICSVoucherExpenses.Icon");
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(22, 65);
			this.MaximizeBox = false;
			this.MinimizeBox = true;
			this.Name = "frmICSVoucherExpenses";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Tag = "\"H: 6225  W:9570\"";
			this.Text = "Expenses & Charges";
			// this.Activated += new System.EventHandler(this.frmICSVoucherExpenses_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
			// this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
			//((System.ComponentModel.ISupportInitialize) this.txtTempDate).EndInit();
			//((System.ComponentModel.ISupportInitialize) this.fraTabPage0).EndInit();
			//((System.ComponentModel.ISupportInitialize) this.tcbSystemForm).EndInit();
			this.cmbMasterList.ResumeLayout(false);
			this._fraCommon_0.ResumeLayout(false);
			this.fraTabPage0.ResumeLayout(false);
			this._fraCommon_1.ResumeLayout(false);
			this.grdVoucherDetails.ResumeLayout(false);
			this.grdExpensesDetails.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		// 
		void InitializetxtDisplayLabel()
		{
			this.txtDisplayLabel = new System.Windows.Forms.Label[3];
			this.txtDisplayLabel[0] = _txtDisplayLabel_0;
			this.txtDisplayLabel[2] = _txtDisplayLabel_2;
		}
		void InitializetxtCommonTextBox()
		{
			this.txtCommonTextBox = new System.Windows.Forms.TextBox[20];
			this.txtCommonTextBox[19] = _txtCommonTextBox_19;
			this.txtCommonTextBox[18] = _txtCommonTextBox_18;
			this.txtCommonTextBox[17] = _txtCommonTextBox_17;
			this.txtCommonTextBox[3] = _txtCommonTextBox_3;
			this.txtCommonTextBox[13] = _txtCommonTextBox_13;
			this.txtCommonTextBox[8] = _txtCommonTextBox_8;
			this.txtCommonTextBox[7] = _txtCommonTextBox_7;
			this.txtCommonTextBox[11] = _txtCommonTextBox_11;
		}
		void InitializeoptAllocation()
		{
			this.optAllocation = new System.Windows.Forms.RadioButton[2];
			this.optAllocation[0] = _optAllocation_0;
			this.optAllocation[1] = _optAllocation_1;
		}
		void InitializelblCommonLabel()
		{
			this.lblCommonLabel = new System.Windows.Forms.Label[25];
			this.lblCommonLabel[0] = _lblCommonLabel_0;
			this.lblCommonLabel[2] = _lblCommonLabel_2;
			this.lblCommonLabel[23] = _lblCommonLabel_23;
			this.lblCommonLabel[21] = _lblCommonLabel_21;
			this.lblCommonLabel[3] = _lblCommonLabel_3;
			this.lblCommonLabel[24] = _lblCommonLabel_24;
			this.lblCommonLabel[14] = _lblCommonLabel_14;
			this.lblCommonLabel[6] = _lblCommonLabel_6;
			this.lblCommonLabel[7] = _lblCommonLabel_7;
			this.lblCommonLabel[5] = _lblCommonLabel_5;
			this.lblCommonLabel[9] = _lblCommonLabel_9;
			this.lblCommonLabel[4] = _lblCommonLabel_4;
			this.lblCommonLabel[1] = _lblCommonLabel_1;
		}
		void InitializefraCommon()
		{
			this.fraCommon = new System.Windows.Forms.GroupBox[2];
			this.fraCommon[0] = _fraCommon_0;
			this.fraCommon[1] = _fraCommon_1;
		}
		#endregion
	}
}//ENDSHERE
