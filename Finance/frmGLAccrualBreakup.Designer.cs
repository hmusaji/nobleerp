
namespace Xtreme
{
	partial class frmGLAccrualBreakup
	{

		#region "Upgrade Support "
		private static frmGLAccrualBreakup m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmGLAccrualBreakup DefInstance
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
		public static frmGLAccrualBreakup CreateInstance()
		{
			frmGLAccrualBreakup theInstance = new frmGLAccrualBreakup();
			
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
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "cmdAllocate", "txtDebitAmount", "Column_0_grdBreakupVoucherDetails", "Column_1_grdBreakupVoucherDetails", "grdBreakupVoucherDetails", "_lblCommonLabel_1", "_txtCommonTextBox_3", "_lblCommonLabel_21", "_lblCommonLabel_5", "_txtCommonTextBox_5", "_lblCommonLabel_2", "Column_0_grdNewAllocationDetails", "grdNewAllocationDetails", "_txtCommonTextBox_2", "_lblCommonLabel_3", "_txtDisplayLabel_2", "_lblCommonLabel_4", "_lblCommonLabel_7", "_txtCommonTextBox_1", "_lblCommonLabel_0", "_txtDisplayLabel_4", "txtComments", "_lblCommonLabel_9", "_txtDisplayLabel_3", "txtTempDate", "_lblCommonLabel_6", "_txtDisplayLabel_5", "Column_0_cmbMastersList", "Column_1_cmbMastersList", "cmbMastersList", "_lblCommonLabel_8", "_txtDisplayLabel_6", "Shape2", "tcbSystemForm", "Shape1", "lblCommonLabel", "txtCommonTextBox", "txtDisplayLabel"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public System.Windows.Forms.Button cmdAllocate;
		public System.Windows.Forms.TextBox txtDebitAmount;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_0_grdBreakupVoucherDetails;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_1_grdBreakupVoucherDetails;
		public C1.Win.C1TrueDBGrid.C1TrueDBGrid grdBreakupVoucherDetails;
		private System.Windows.Forms.Label _lblCommonLabel_1;
		private System.Windows.Forms.TextBox _txtCommonTextBox_3;
		private System.Windows.Forms.Label _lblCommonLabel_21;
		private System.Windows.Forms.Label _lblCommonLabel_5;
		private System.Windows.Forms.TextBox _txtCommonTextBox_5;
		private System.Windows.Forms.Label _lblCommonLabel_2;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_0_grdNewAllocationDetails;
		public C1.Win.C1TrueDBGrid.C1TrueDBGrid grdNewAllocationDetails;
		private System.Windows.Forms.TextBox _txtCommonTextBox_2;
		private System.Windows.Forms.Label _lblCommonLabel_3;
		private System.Windows.Forms.Label _txtDisplayLabel_2;
		private System.Windows.Forms.Label _lblCommonLabel_4;
		private System.Windows.Forms.Label _lblCommonLabel_7;
		private System.Windows.Forms.TextBox _txtCommonTextBox_1;
		private System.Windows.Forms.Label _lblCommonLabel_0;
		private System.Windows.Forms.Label _txtDisplayLabel_4;
		public System.Windows.Forms.TextBox txtComments;
		private System.Windows.Forms.Label _lblCommonLabel_9;
		private System.Windows.Forms.Label _txtDisplayLabel_3;
		public Syncfusion.WinForms.Input.SfDateTimeEdit txtTempDate;
		private System.Windows.Forms.Label _lblCommonLabel_6;
		private System.Windows.Forms.Label _txtDisplayLabel_5;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_0_cmbMastersList;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_1_cmbMastersList;
		public C1.Win.C1TrueDBGrid.C1TrueDBDropdown cmbMastersList;
		private System.Windows.Forms.Label _lblCommonLabel_8;
		private System.Windows.Forms.Label _txtDisplayLabel_6;
		public UpgradeHelpers.Gui.ShapeHelper Shape2;
		public Syncfusion.Windows.Forms.Tools.CommandBarController tcbSystemForm;
		public UpgradeHelpers.Gui.ShapeHelper Shape1;
		public System.Windows.Forms.Label[] lblCommonLabel = new System.Windows.Forms.Label[22];
		public System.Windows.Forms.TextBox[] txtCommonTextBox = new System.Windows.Forms.TextBox[6];
		public System.Windows.Forms.Label[] txtDisplayLabel = new System.Windows.Forms.Label[7];
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGLAccrualBreakup));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this.cmdAllocate = new System.Windows.Forms.Button();
			this.txtDebitAmount = new System.Windows.Forms.TextBox();
			this.grdBreakupVoucherDetails = new C1.Win.C1TrueDBGrid.C1TrueDBGrid();
			this.Column_0_grdBreakupVoucherDetails = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.Column_1_grdBreakupVoucherDetails = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this._lblCommonLabel_1 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_3 = new System.Windows.Forms.TextBox();
			this._lblCommonLabel_21 = new System.Windows.Forms.Label();
			this._lblCommonLabel_5 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_5 = new System.Windows.Forms.TextBox();
			this._lblCommonLabel_2 = new System.Windows.Forms.Label();
			this.grdNewAllocationDetails = new C1.Win.C1TrueDBGrid.C1TrueDBGrid();
			this.Column_0_grdNewAllocationDetails = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this._txtCommonTextBox_2 = new System.Windows.Forms.TextBox();
			this._lblCommonLabel_3 = new System.Windows.Forms.Label();
			this._txtDisplayLabel_2 = new System.Windows.Forms.Label();
			this._lblCommonLabel_4 = new System.Windows.Forms.Label();
			this._lblCommonLabel_7 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_1 = new System.Windows.Forms.TextBox();
			this._lblCommonLabel_0 = new System.Windows.Forms.Label();
			this._txtDisplayLabel_4 = new System.Windows.Forms.Label();
			this.txtComments = new System.Windows.Forms.TextBox();
			this._lblCommonLabel_9 = new System.Windows.Forms.Label();
			this._txtDisplayLabel_3 = new System.Windows.Forms.Label();
			this.txtTempDate = new Syncfusion.WinForms.Input.SfDateTimeEdit();
			this._lblCommonLabel_6 = new System.Windows.Forms.Label();
			this._txtDisplayLabel_5 = new System.Windows.Forms.Label();
			this.cmbMastersList = new C1.Win.C1TrueDBGrid.C1TrueDBDropdown();
			this.Column_0_cmbMastersList = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.Column_1_cmbMastersList = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this._lblCommonLabel_8 = new System.Windows.Forms.Label();
			this._txtDisplayLabel_6 = new System.Windows.Forms.Label();
			this.Shape2 = new UpgradeHelpers.Gui.ShapeHelper();
			this.tcbSystemForm = new Syncfusion.Windows.Forms.Tools.CommandBarController();
			this.Shape1 = new UpgradeHelpers.Gui.ShapeHelper();
			// //((System.ComponentModel.ISupportInitialize) this.txtTempDate).BeginInit();
			// //((System.ComponentModel.ISupportInitialize) this.tcbSystemForm).BeginInit();
			this.grdBreakupVoucherDetails.SuspendLayout();
			this.grdNewAllocationDetails.SuspendLayout();
			this.cmbMastersList.SuspendLayout();
			this.SuspendLayout();
			// 
			// cmdAllocate
			// 
			this.cmdAllocate.AllowDrop = true;
			this.cmdAllocate.BackColor = System.Drawing.SystemColors.Control;
			this.cmdAllocate.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdAllocate.Location = new System.Drawing.Point(656, 307);
			this.cmdAllocate.Name = "cmdAllocate";
			this.cmdAllocate.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdAllocate.Size = new System.Drawing.Size(90, 18);
			this.cmdAllocate.TabIndex = 23;
			this.cmdAllocate.Text = "&Allocate";
			this.cmdAllocate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.cmdAllocate.UseVisualStyleBackColor = false;
			// this.cmdAllocate.Click += new System.EventHandler(this.cmdAllocate_Click);
			// 
			// txtDebitAmount
			// 
			this.txtDebitAmount.AllowDrop = true;
			this.txtDebitAmount.BackColor = System.Drawing.Color.FromArgb(239, 239, 239);
			// this.txtDebitAmount.DisplayFormat = "####0.000###;;0.000;0.000";
			this.txtDebitAmount.Enabled = false;
			// this.txtDebitAmount.Format = "###########0.000";
			this.txtDebitAmount.Location = new System.Drawing.Point(120, 97);
			// this.txtDebitAmount.MaxValue = 999999999;
			// this.txtDebitAmount.MinValue = 0;
			this.txtDebitAmount.Name = "txtDebitAmount";
			this.txtDebitAmount.Size = new System.Drawing.Size(101, 19);
			this.txtDebitAmount.TabIndex = 1;
			this.txtDebitAmount.Text = "0.000";
			// 
			// grdBreakupVoucherDetails
			// 
			this.grdBreakupVoucherDetails.AllowDrop = true;
			this.grdBreakupVoucherDetails.BackColor = System.Drawing.Color.Silver;
			this.grdBreakupVoucherDetails.CellTipsWidth = 0;
			this.grdBreakupVoucherDetails.Location = new System.Drawing.Point(2, 171);
			this.grdBreakupVoucherDetails.Name = "grdBreakupVoucherDetails";
			this.grdBreakupVoucherDetails.RowDivider.Color = System.Drawing.Color.Silver;
			this.grdBreakupVoucherDetails.Size = new System.Drawing.Size(754, 121);
			this.grdBreakupVoucherDetails.TabIndex = 2;
			this.grdBreakupVoucherDetails.TabStop = false;
			this.grdBreakupVoucherDetails.Columns.Add(this.Column_0_grdBreakupVoucherDetails);
			this.grdBreakupVoucherDetails.Columns.Add(this.Column_1_grdBreakupVoucherDetails);
			this.grdBreakupVoucherDetails.GotFocus += new System.EventHandler(this.grdBreakupVoucherDetails_GotFocus);
			this.grdBreakupVoucherDetails.RowColChange += new C1.Win.C1TrueDBGrid.RowColChangeEventHandler(this.grdBreakupVoucherDetails_RowColChange);
			// 
			// Column_0_grdBreakupVoucherDetails
			// 
			this.Column_0_grdBreakupVoucherDetails.DataField = "";
			this.Column_0_grdBreakupVoucherDetails.ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.Normal;
			// 
			// Column_1_grdBreakupVoucherDetails
			// 
			this.Column_1_grdBreakupVoucherDetails.DataField = "";
			this.Column_1_grdBreakupVoucherDetails.ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.Normal;
			// 
			// _lblCommonLabel_1
			// 
			this._lblCommonLabel_1.AllowDrop = true;
			this._lblCommonLabel_1.BackColor = System.Drawing.SystemColors.Window;
			this._lblCommonLabel_1.Text = "Breakup Voucher Details";
			this._lblCommonLabel_1.ForeColor = System.Drawing.Color.Black;
			this._lblCommonLabel_1.Location = new System.Drawing.Point(4, 155);
			this._lblCommonLabel_1.Name = "_lblCommonLabel_1";
			this._lblCommonLabel_1.Size = new System.Drawing.Size(116, 13);
			this._lblCommonLabel_1.TabIndex = 7;
			// 
			// _txtCommonTextBox_3
			// 
			this._txtCommonTextBox_3.AllowDrop = true;
			this._txtCommonTextBox_3.BackColor = System.Drawing.Color.White;
			// this._txtCommonTextBox_3.bolNumericOnly = true;
			this._txtCommonTextBox_3.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_3.Location = new System.Drawing.Point(120, 76);
			this._txtCommonTextBox_3.Name = "_txtCommonTextBox_3";
			// this._txtCommonTextBox_3.ShowButton = true;
			this._txtCommonTextBox_3.Size = new System.Drawing.Size(101, 19);
			this._txtCommonTextBox_3.TabIndex = 0;
			this._txtCommonTextBox_3.Text = "";
			// this.this._txtCommonTextBox_3.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_3.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _lblCommonLabel_21
			// 
			this._lblCommonLabel_21.AllowDrop = true;
			this._lblCommonLabel_21.BackColor = System.Drawing.SystemColors.Window;
			this._lblCommonLabel_21.Text = "Breakup Voucher No.";
			this._lblCommonLabel_21.ForeColor = System.Drawing.Color.Black;
			this._lblCommonLabel_21.Location = new System.Drawing.Point(10, 79);
			this._lblCommonLabel_21.Name = "_lblCommonLabel_21";
			this._lblCommonLabel_21.Size = new System.Drawing.Size(104, 14);
			this._lblCommonLabel_21.TabIndex = 8;
			// 
			// _lblCommonLabel_5
			// 
			this._lblCommonLabel_5.AllowDrop = true;
			this._lblCommonLabel_5.BackColor = System.Drawing.SystemColors.Window;
			this._lblCommonLabel_5.Text = "Transaction No.";
			this._lblCommonLabel_5.ForeColor = System.Drawing.Color.Black;
			this._lblCommonLabel_5.Location = new System.Drawing.Point(559, 48);
			this._lblCommonLabel_5.Name = "_lblCommonLabel_5";
			this._lblCommonLabel_5.Size = new System.Drawing.Size(76, 14);
			this._lblCommonLabel_5.TabIndex = 9;
			// 
			// _txtCommonTextBox_5
			// 
			this._txtCommonTextBox_5.AllowDrop = true;
			this._txtCommonTextBox_5.BackColor = System.Drawing.Color.FromArgb(239, 239, 239);
			// this._txtCommonTextBox_5.bolNumericOnly = true;
			this._txtCommonTextBox_5.Enabled = false;
			this._txtCommonTextBox_5.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_5.Location = new System.Drawing.Point(652, 46);
			this._txtCommonTextBox_5.Name = "_txtCommonTextBox_5";
			this._txtCommonTextBox_5.Size = new System.Drawing.Size(102, 19);
			this._txtCommonTextBox_5.TabIndex = 10;
			this._txtCommonTextBox_5.Text = "";
			// this.this._txtCommonTextBox_5.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_5.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _lblCommonLabel_2
			// 
			this._lblCommonLabel_2.AllowDrop = true;
			this._lblCommonLabel_2.BackColor = System.Drawing.SystemColors.Window;
			this._lblCommonLabel_2.Text = "New Allocation Details";
			this._lblCommonLabel_2.ForeColor = System.Drawing.Color.Black;
			this._lblCommonLabel_2.Location = new System.Drawing.Point(2, 364);
			this._lblCommonLabel_2.Name = "_lblCommonLabel_2";
			this._lblCommonLabel_2.Size = new System.Drawing.Size(105, 13);
			this._lblCommonLabel_2.TabIndex = 11;
			// 
			// grdNewAllocationDetails
			// 
			this.grdNewAllocationDetails.AllowDrop = true;
			this.grdNewAllocationDetails.BackColor = System.Drawing.Color.FromArgb(212, 208, 200);
			this.grdNewAllocationDetails.CellTipsWidth = 0;
			this.grdNewAllocationDetails.Location = new System.Drawing.Point(0, 377);
			this.grdNewAllocationDetails.Name = "grdNewAllocationDetails";
			this.grdNewAllocationDetails.RowDivider.Color = System.Drawing.Color.FromArgb(212, 208, 200);
			this.grdNewAllocationDetails.Size = new System.Drawing.Size(755, 118);
			this.grdNewAllocationDetails.TabIndex = 5;
			this.grdNewAllocationDetails.Columns.Add(this.Column_0_grdNewAllocationDetails);
			// 
			// Column_0_grdNewAllocationDetails
			// 
			this.Column_0_grdNewAllocationDetails.DataField = "";
			this.Column_0_grdNewAllocationDetails.ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.Normal;
			// 
			// _txtCommonTextBox_2
			// 
			this._txtCommonTextBox_2.AllowDrop = true;
			this._txtCommonTextBox_2.BackColor = System.Drawing.Color.FromArgb(239, 239, 239);
			this._txtCommonTextBox_2.Enabled = false;
			this._txtCommonTextBox_2.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_2.Location = new System.Drawing.Point(120, 117);
			this._txtCommonTextBox_2.Name = "_txtCommonTextBox_2";
			// this._txtCommonTextBox_2.ShowButton = true;
			this._txtCommonTextBox_2.Size = new System.Drawing.Size(101, 19);
			this._txtCommonTextBox_2.TabIndex = 6;
			this._txtCommonTextBox_2.Text = "";
			// this.this._txtCommonTextBox_2.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_2.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _lblCommonLabel_3
			// 
			this._lblCommonLabel_3.AllowDrop = true;
			this._lblCommonLabel_3.BackColor = System.Drawing.SystemColors.Window;
			this._lblCommonLabel_3.Text = "Debit Account Code";
			this._lblCommonLabel_3.ForeColor = System.Drawing.Color.Black;
			this._lblCommonLabel_3.Location = new System.Drawing.Point(10, 119);
			this._lblCommonLabel_3.Name = "_lblCommonLabel_3";
			this._lblCommonLabel_3.Size = new System.Drawing.Size(96, 14);
			this._lblCommonLabel_3.TabIndex = 12;
			// 
			// _txtDisplayLabel_2
			// 
			this._txtDisplayLabel_2.AllowDrop = true;
			this._txtDisplayLabel_2.Enabled = false;
			this._txtDisplayLabel_2.Location = new System.Drawing.Point(223, 117);
			this._txtDisplayLabel_2.Name = "_txtDisplayLabel_2";
			this._txtDisplayLabel_2.Size = new System.Drawing.Size(202, 19);
			this._txtDisplayLabel_2.TabIndex = 13;
			// 
			// _lblCommonLabel_4
			// 
			this._lblCommonLabel_4.AllowDrop = true;
			this._lblCommonLabel_4.BackColor = System.Drawing.SystemColors.Window;
			this._lblCommonLabel_4.Text = "Debit Amount";
			this._lblCommonLabel_4.ForeColor = System.Drawing.Color.Black;
			this._lblCommonLabel_4.Location = new System.Drawing.Point(10, 100);
			this._lblCommonLabel_4.Name = "_lblCommonLabel_4";
			this._lblCommonLabel_4.Size = new System.Drawing.Size(64, 14);
			this._lblCommonLabel_4.TabIndex = 14;
			// 
			// _lblCommonLabel_7
			// 
			this._lblCommonLabel_7.AllowDrop = true;
			this._lblCommonLabel_7.BackColor = System.Drawing.SystemColors.Window;
			this._lblCommonLabel_7.Text = "Breakup Voucher Type";
			this._lblCommonLabel_7.ForeColor = System.Drawing.Color.Black;
			this._lblCommonLabel_7.Location = new System.Drawing.Point(528, 78);
			this._lblCommonLabel_7.Name = "_lblCommonLabel_7";
			this._lblCommonLabel_7.Size = new System.Drawing.Size(112, 14);
			this._lblCommonLabel_7.TabIndex = 15;
			// 
			// _txtCommonTextBox_1
			// 
			this._txtCommonTextBox_1.AllowDrop = true;
			this._txtCommonTextBox_1.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_1.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_1.Location = new System.Drawing.Point(116, 307);
			this._txtCommonTextBox_1.Name = "_txtCommonTextBox_1";
			// this._txtCommonTextBox_1.ShowButton = true;
			this._txtCommonTextBox_1.Size = new System.Drawing.Size(101, 19);
			this._txtCommonTextBox_1.TabIndex = 3;
			this._txtCommonTextBox_1.Text = "";
			// this.this._txtCommonTextBox_1.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_1.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _lblCommonLabel_0
			// 
			this._lblCommonLabel_0.AllowDrop = true;
			this._lblCommonLabel_0.BackColor = System.Drawing.SystemColors.Window;
			this._lblCommonLabel_0.Text = "Voucher Type";
			this._lblCommonLabel_0.ForeColor = System.Drawing.Color.Black;
			this._lblCommonLabel_0.Location = new System.Drawing.Point(6, 309);
			this._lblCommonLabel_0.Name = "_lblCommonLabel_0";
			this._lblCommonLabel_0.Size = new System.Drawing.Size(69, 14);
			this._lblCommonLabel_0.TabIndex = 16;
			// 
			// _txtDisplayLabel_4
			// 
			this._txtDisplayLabel_4.AllowDrop = true;
			this._txtDisplayLabel_4.Enabled = false;
			this._txtDisplayLabel_4.Location = new System.Drawing.Point(219, 307);
			this._txtDisplayLabel_4.Name = "_txtDisplayLabel_4";
			this._txtDisplayLabel_4.Size = new System.Drawing.Size(202, 19);
			this._txtDisplayLabel_4.TabIndex = 17;
			// 
			// txtComments
			// 
			this.txtComments.AllowDrop = true;
			this.txtComments.BackColor = System.Drawing.Color.White;
			this.txtComments.ForeColor = System.Drawing.Color.Black;
			this.txtComments.Location = new System.Drawing.Point(116, 328);
			this.txtComments.MaxLength = 200;
			this.txtComments.Name = "txtComments";
			this.txtComments.Size = new System.Drawing.Size(631, 19);
			this.txtComments.TabIndex = 4;
			this.txtComments.Text = "";
			// 
			// _lblCommonLabel_9
			// 
			this._lblCommonLabel_9.AllowDrop = true;
			this._lblCommonLabel_9.BackColor = System.Drawing.SystemColors.Window;
			this._lblCommonLabel_9.Text = "Comments";
			this._lblCommonLabel_9.ForeColor = System.Drawing.Color.Black;
			this._lblCommonLabel_9.Location = new System.Drawing.Point(6, 331);
			this._lblCommonLabel_9.Name = "_lblCommonLabel_9";
			this._lblCommonLabel_9.Size = new System.Drawing.Size(50, 13);
			this._lblCommonLabel_9.TabIndex = 18;
			// 
			// _txtDisplayLabel_3
			// 
			this._txtDisplayLabel_3.AllowDrop = true;
			this._txtDisplayLabel_3.Enabled = false;
			this._txtDisplayLabel_3.Location = new System.Drawing.Point(648, 76);
			this._txtDisplayLabel_3.Name = "_txtDisplayLabel_3";
			this._txtDisplayLabel_3.Size = new System.Drawing.Size(101, 19);
			this._txtDisplayLabel_3.TabIndex = 19;
			// 
			// txtTempDate
			// 
			this.txtTempDate.AllowDrop = true;
			this.txtTempDate.Location = new System.Drawing.Point(574, 5);
			this.txtTempDate.Name = "txtTempDate";
			("txtTempDate.OcxState");
			this.txtTempDate.Size = new System.Drawing.Size(109, 19);
			this.txtTempDate.TabIndex = 20;
			this.txtTempDate.TabStop = false;
			this.txtTempDate.Visible = false;
			// 
			// _lblCommonLabel_6
			// 
			this._lblCommonLabel_6.AllowDrop = true;
			this._lblCommonLabel_6.BackColor = System.Drawing.SystemColors.Window;
			this._lblCommonLabel_6.Text = "Breakup Voucher Date";
			this._lblCommonLabel_6.ForeColor = System.Drawing.Color.Black;
			this._lblCommonLabel_6.Location = new System.Drawing.Point(528, 99);
			this._lblCommonLabel_6.Name = "_lblCommonLabel_6";
			this._lblCommonLabel_6.Size = new System.Drawing.Size(110, 14);
			this._lblCommonLabel_6.TabIndex = 21;
			// 
			// _txtDisplayLabel_5
			// 
			this._txtDisplayLabel_5.AllowDrop = true;
			this._txtDisplayLabel_5.Enabled = false;
			this._txtDisplayLabel_5.Location = new System.Drawing.Point(648, 97);
			this._txtDisplayLabel_5.Name = "_txtDisplayLabel_5";
			this._txtDisplayLabel_5.Size = new System.Drawing.Size(101, 19);
			this._txtDisplayLabel_5.TabIndex = 22;
			// 
			// cmbMastersList
			// 
			this.cmbMastersList.AllowDrop = true;
			this.cmbMastersList.ColumnHeaders = true;
			this.cmbMastersList.Enabled = true;
			this.cmbMastersList.Location = new System.Drawing.Point(258, 157);
			this.cmbMastersList.Name = "cmbMastersList";
			this.cmbMastersList.Size = new System.Drawing.Size(333, 133);
			this.cmbMastersList.TabIndex = 24;
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
			// _lblCommonLabel_8
			// 
			this._lblCommonLabel_8.AllowDrop = true;
			this._lblCommonLabel_8.BackColor = System.Drawing.SystemColors.Window;
			this._lblCommonLabel_8.Text = "Breakup Inv. No.";
			this._lblCommonLabel_8.ForeColor = System.Drawing.Color.Black;
			this._lblCommonLabel_8.Location = new System.Drawing.Point(528, 120);
			this._lblCommonLabel_8.Name = "_lblCommonLabel_8";
			this._lblCommonLabel_8.Size = new System.Drawing.Size(79, 14);
			this._lblCommonLabel_8.TabIndex = 25;
			// 
			// _txtDisplayLabel_6
			// 
			this._txtDisplayLabel_6.AllowDrop = true;
			this._txtDisplayLabel_6.Enabled = false;
			this._txtDisplayLabel_6.Location = new System.Drawing.Point(648, 118);
			this._txtDisplayLabel_6.Name = "_txtDisplayLabel_6";
			this._txtDisplayLabel_6.Size = new System.Drawing.Size(101, 19);
			this._txtDisplayLabel_6.TabIndex = 26;
			// 
			// Shape2
			// 
			this.Shape2.AllowDrop = true;
			this.Shape2.BackColor = System.Drawing.Color.FromArgb(208, 217, 208);
			this.Shape2.BackStyle = 1;
			this.Shape2.BorderStyle = 1;
			this.Shape2.Enabled = false;
			this.Shape2.FillColor = System.Drawing.Color.Black;
			this.Shape2.FillStyle = 1;
			this.Shape2.Location = new System.Drawing.Point(0, 301);
			this.Shape2.Name = "Shape2";
			this.Shape2.Size = new System.Drawing.Size(756, 54);
			this.Shape2.Visible = true;
			// 
			// tcbSystemForm
			// 
			this.tcbSystemForm.AllowDrop = true;
			this.tcbSystemForm.Location = new System.Drawing.Point(0, 0);
			this.tcbSystemForm.Name = "tcbSystemForm";
			("tcbSystemForm.OcxState");
			// 
			// Shape1
			// 
			this.Shape1.AllowDrop = true;
			this.Shape1.BackColor = System.Drawing.Color.FromArgb(208, 217, 208);
			this.Shape1.BackStyle = 1;
			this.Shape1.BorderStyle = 1;
			this.Shape1.Enabled = false;
			this.Shape1.FillColor = System.Drawing.Color.Black;
			this.Shape1.FillStyle = 1;
			this.Shape1.Location = new System.Drawing.Point(0, 70);
			this.Shape1.Name = "Shape1";
			this.Shape1.Size = new System.Drawing.Size(756, 74);
			this.Shape1.Visible = true;
			// 
			// frmGLAccrualBreakup
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.FromArgb(208, 217, 208);
			this.ClientSize = new System.Drawing.Size(759, 505);
			this.Controls.Add(this.cmdAllocate);
			this.Controls.Add(this.txtDebitAmount);
			this.Controls.Add(this.grdBreakupVoucherDetails);
			this.Controls.Add(this._lblCommonLabel_1);
			this.Controls.Add(this._txtCommonTextBox_3);
			this.Controls.Add(this._lblCommonLabel_21);
			this.Controls.Add(this._lblCommonLabel_5);
			this.Controls.Add(this._txtCommonTextBox_5);
			this.Controls.Add(this._lblCommonLabel_2);
			this.Controls.Add(this.grdNewAllocationDetails);
			this.Controls.Add(this._txtCommonTextBox_2);
			this.Controls.Add(this._lblCommonLabel_3);
			this.Controls.Add(this._txtDisplayLabel_2);
			this.Controls.Add(this._lblCommonLabel_4);
			this.Controls.Add(this._lblCommonLabel_7);
			this.Controls.Add(this._txtCommonTextBox_1);
			this.Controls.Add(this._lblCommonLabel_0);
			this.Controls.Add(this._txtDisplayLabel_4);
			this.Controls.Add(this.txtComments);
			this.Controls.Add(this._lblCommonLabel_9);
			this.Controls.Add(this._txtDisplayLabel_3);
			this.Controls.Add(this.txtTempDate);
			this.Controls.Add(this._lblCommonLabel_6);
			this.Controls.Add(this._txtDisplayLabel_5);
			this.Controls.Add(this.cmbMastersList);
			this.Controls.Add(this._lblCommonLabel_8);
			this.Controls.Add(this._txtDisplayLabel_6);
			this.Controls.Add(this.Shape2);
			this.Controls.Add(this.tcbSystemForm);
			this.Controls.Add(this.Shape1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			//this.Icon = (System.Drawing.Icon) resources.GetObject("frmGLAccrualBreakup.Icon");
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(114, 91);
			this.MaximizeBox = false;
			this.MinimizeBox = true;
			this.Name = "frmGLAccrualBreakup";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Tag = "\"H: 6225  W:9570\"";
			this.Text = "GL Accrual Breakup Transaction";
			// this.Activated += new System.EventHandler(this.frmGLAccrualBreakup_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
			// this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
			//((System.ComponentModel.ISupportInitialize) this.txtTempDate).EndInit();
			//((System.ComponentModel.ISupportInitialize) this.tcbSystemForm).EndInit();
			this.grdBreakupVoucherDetails.ResumeLayout(false);
			this.grdNewAllocationDetails.ResumeLayout(false);
			this.cmbMastersList.ResumeLayout(false);
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
			this.txtDisplayLabel = new System.Windows.Forms.Label[7];
			this.txtDisplayLabel[2] = _txtDisplayLabel_2;
			this.txtDisplayLabel[4] = _txtDisplayLabel_4;
			this.txtDisplayLabel[3] = _txtDisplayLabel_3;
			this.txtDisplayLabel[5] = _txtDisplayLabel_5;
			this.txtDisplayLabel[6] = _txtDisplayLabel_6;
		}
		void InitializetxtCommonTextBox()
		{
			this.txtCommonTextBox = new System.Windows.Forms.TextBox[6];
			this.txtCommonTextBox[3] = _txtCommonTextBox_3;
			this.txtCommonTextBox[5] = _txtCommonTextBox_5;
			this.txtCommonTextBox[2] = _txtCommonTextBox_2;
			this.txtCommonTextBox[1] = _txtCommonTextBox_1;
		}
		void InitializelblCommonLabel()
		{
			this.lblCommonLabel = new System.Windows.Forms.Label[22];
			this.lblCommonLabel[1] = _lblCommonLabel_1;
			this.lblCommonLabel[21] = _lblCommonLabel_21;
			this.lblCommonLabel[5] = _lblCommonLabel_5;
			this.lblCommonLabel[2] = _lblCommonLabel_2;
			this.lblCommonLabel[3] = _lblCommonLabel_3;
			this.lblCommonLabel[4] = _lblCommonLabel_4;
			this.lblCommonLabel[7] = _lblCommonLabel_7;
			this.lblCommonLabel[0] = _lblCommonLabel_0;
			this.lblCommonLabel[9] = _lblCommonLabel_9;
			this.lblCommonLabel[6] = _lblCommonLabel_6;
			this.lblCommonLabel[8] = _lblCommonLabel_8;
		}
		#endregion
	}
}