
namespace Xtreme
{
	partial class frmPayTrainingTrans
	{

		#region "Upgrade Support "
		private static frmPayTrainingTrans m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmPayTrainingTrans DefInstance
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
		public static frmPayTrainingTrans CreateInstance()
		{
			frmPayTrainingTrans theInstance = new frmPayTrainingTrans();
			
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
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "_cmbTrainingType_0", "_txtCommonTextBox_11", "_lblCommonLabel_9", "_lblCommonLabel_12", "Column_0_cmbMastersList", "Column_1_cmbMastersList", "cmbMastersList", "_lblCommonLabel_4", "_txtCommonTextBox_1", "_lblCommonLabel_2", "_lblCommonLabel_5", "_lblCommonLabel_6", "_txtCommonDate_2", "_txtCommonTextBox_0", "_lblCommonLabel_23", "_lblCommonLabel_21", "System.Windows.Forms.Label12", "_txtCommonTextBox_2", "_lblCommonLabel_0", "_txtCommonTextBox_3", "_txtDisplayLabel_0", "_lblCommonLabel_1", "_txtCommonDate_3", "_lblCommonLabel_3", "_lblCommonLabel_7", "Column_0_grdVoucherDetails", "Column_1_grdVoucherDetails", "grdVoucherDetails", "_txtCommonTextBox_4", "txtcost", "_txtCommonTextBox_7", "_lblCommonLabel_8", "txtDurationMins", "txtDurationHRS", "cmbTrainingType", "lblCommonLabel", "txtCommonDate", "txtCommonTextBox", "txtDisplayLabel"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		private System.Windows.Forms.ComboBox _cmbTrainingType_0;
		private System.Windows.Forms.TextBox _txtCommonTextBox_11;
		private System.Windows.Forms.Label _lblCommonLabel_9;
		private System.Windows.Forms.Label _lblCommonLabel_12;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_0_cmbMastersList;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_1_cmbMastersList;
		public C1.Win.C1TrueDBGrid.C1TrueDBDropdown cmbMastersList;
		private System.Windows.Forms.Label _lblCommonLabel_4;
		private System.Windows.Forms.TextBox _txtCommonTextBox_1;
		private System.Windows.Forms.Label _lblCommonLabel_2;
		private System.Windows.Forms.Label _lblCommonLabel_5;
		private System.Windows.Forms.Label _lblCommonLabel_6;
		private Syncfusion.WinForms.Input.SfDateTimeEdit _txtCommonDate_2;
		private System.Windows.Forms.TextBox _txtCommonTextBox_0;
		private System.Windows.Forms.Label _lblCommonLabel_23;
		private System.Windows.Forms.Label _lblCommonLabel_21;
		public System.Windows.Forms.Label Label12;
		private System.Windows.Forms.TextBox _txtCommonTextBox_2;
		private System.Windows.Forms.Label _lblCommonLabel_0;
		private System.Windows.Forms.TextBox _txtCommonTextBox_3;
		private System.Windows.Forms.Label _txtDisplayLabel_0;
		private System.Windows.Forms.Label _lblCommonLabel_1;
		private Syncfusion.WinForms.Input.SfDateTimeEdit _txtCommonDate_3;
		private System.Windows.Forms.Label _lblCommonLabel_3;
		private System.Windows.Forms.Label _lblCommonLabel_7;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_0_grdVoucherDetails;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_1_grdVoucherDetails;
		public C1.Win.C1TrueDBGrid.C1TrueDBGrid grdVoucherDetails;
		private System.Windows.Forms.TextBox _txtCommonTextBox_4;
		public System.Windows.Forms.TextBox txtcost;
		private System.Windows.Forms.TextBox _txtCommonTextBox_7;
		private System.Windows.Forms.Label _lblCommonLabel_8;
		public System.Windows.Forms.TextBox txtDurationMins;
		public System.Windows.Forms.TextBox txtDurationHRS;
		public System.Windows.Forms.ComboBox[] cmbTrainingType = new System.Windows.Forms.ComboBox[1];
		public System.Windows.Forms.Label[] lblCommonLabel = new System.Windows.Forms.Label[24];
		public Syncfusion.WinForms.Input.SfDateTimeEdit[] txtCommonDate = new Syncfusion.WinForms.Input.SfDateTimeEdit[4];
		public System.Windows.Forms.TextBox[] txtCommonTextBox = new System.Windows.Forms.TextBox[12];
		public System.Windows.Forms.Label[] txtDisplayLabel = new System.Windows.Forms.Label[1];
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPayTrainingTrans));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this._cmbTrainingType_0 = new System.Windows.Forms.ComboBox();
			this._txtCommonTextBox_11 = new System.Windows.Forms.TextBox();
			this._lblCommonLabel_9 = new System.Windows.Forms.Label();
			this._lblCommonLabel_12 = new System.Windows.Forms.Label();
			this.cmbMastersList = new C1.Win.C1TrueDBGrid.C1TrueDBDropdown();
			this.Column_0_cmbMastersList = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.Column_1_cmbMastersList = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this._lblCommonLabel_4 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_1 = new System.Windows.Forms.TextBox();
			this._lblCommonLabel_2 = new System.Windows.Forms.Label();
			this._lblCommonLabel_5 = new System.Windows.Forms.Label();
			this._lblCommonLabel_6 = new System.Windows.Forms.Label();
			this._txtCommonDate_2 = new Syncfusion.WinForms.Input.SfDateTimeEdit();
			this._txtCommonTextBox_0 = new System.Windows.Forms.TextBox();
			this._lblCommonLabel_23 = new System.Windows.Forms.Label();
			this._lblCommonLabel_21 = new System.Windows.Forms.Label();
			this.Label12 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_2 = new System.Windows.Forms.TextBox();
			this._lblCommonLabel_0 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_3 = new System.Windows.Forms.TextBox();
			this._txtDisplayLabel_0 = new System.Windows.Forms.Label();
			this._lblCommonLabel_1 = new System.Windows.Forms.Label();
			this._txtCommonDate_3 = new Syncfusion.WinForms.Input.SfDateTimeEdit();
			this._lblCommonLabel_3 = new System.Windows.Forms.Label();
			this._lblCommonLabel_7 = new System.Windows.Forms.Label();
			this.grdVoucherDetails = new C1.Win.C1TrueDBGrid.C1TrueDBGrid();
			this.Column_0_grdVoucherDetails = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.Column_1_grdVoucherDetails = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this._txtCommonTextBox_4 = new System.Windows.Forms.TextBox();
			this.txtcost = new System.Windows.Forms.TextBox();
			this._txtCommonTextBox_7 = new System.Windows.Forms.TextBox();
			this._lblCommonLabel_8 = new System.Windows.Forms.Label();
			this.txtDurationMins = new System.Windows.Forms.TextBox();
			this.txtDurationHRS = new System.Windows.Forms.TextBox();
			this.cmbMastersList.SuspendLayout();
			this.grdVoucherDetails.SuspendLayout();
			this.SuspendLayout();
			// 
			// _cmbTrainingType_0
			// 
			this._cmbTrainingType_0.AllowDrop = true;
			this._cmbTrainingType_0.Location = new System.Drawing.Point(87, 94);
			this._cmbTrainingType_0.Name = "_cmbTrainingType_0";
			this._cmbTrainingType_0.Size = new System.Drawing.Size(101, 21);
			this._cmbTrainingType_0.TabIndex = 4;
			// 
			// _txtCommonTextBox_11
			// 
			this._txtCommonTextBox_11.AllowDrop = true;
			this._txtCommonTextBox_11.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_11.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_11.Location = new System.Drawing.Point(62, 403);
			this._txtCommonTextBox_11.MaxLength = 200;
			this._txtCommonTextBox_11.Name = "_txtCommonTextBox_11";
			this._txtCommonTextBox_11.Size = new System.Drawing.Size(303, 19);
			this._txtCommonTextBox_11.TabIndex = 13;
			this._txtCommonTextBox_11.Text = "";
			// this.this._txtCommonTextBox_11.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_11.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _lblCommonLabel_9
			// 
			this._lblCommonLabel_9.AllowDrop = true;
			this._lblCommonLabel_9.BackColor = System.Drawing.Color.FromArgb(213, 213, 213);
			this._lblCommonLabel_9.Text = "Narration";
			this._lblCommonLabel_9.Location = new System.Drawing.Point(7, 406);
			this._lblCommonLabel_9.Name = "_lblCommonLabel_9";
			this._lblCommonLabel_9.Size = new System.Drawing.Size(45, 13);
			this._lblCommonLabel_9.TabIndex = 14;
			// 
			// _lblCommonLabel_12
			// 
			this._lblCommonLabel_12.AllowDrop = true;
			this._lblCommonLabel_12.BackColor = System.Drawing.Color.FromArgb(213, 213, 213);
			this._lblCommonLabel_12.Text = "Product Details :";
			this._lblCommonLabel_12.Location = new System.Drawing.Point(2, 442);
			this._lblCommonLabel_12.Name = "_lblCommonLabel_12";
			this._lblCommonLabel_12.Size = new System.Drawing.Size(79, 13);
			this._lblCommonLabel_12.TabIndex = 15;
			// 
			// cmbMastersList
			// 
			this.cmbMastersList.AllowDrop = true;
			this.cmbMastersList.ColumnHeaders = true;
			this.cmbMastersList.Enabled = true;
			this.cmbMastersList.Location = new System.Drawing.Point(6, 260);
			this.cmbMastersList.Name = "cmbMastersList";
			this.cmbMastersList.Size = new System.Drawing.Size(61, 45);
			this.cmbMastersList.TabIndex = 16;
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
			// _lblCommonLabel_4
			// 
			this._lblCommonLabel_4.AllowDrop = true;
			this._lblCommonLabel_4.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_4.Text = "Duration Hours";
			this._lblCommonLabel_4.Location = new System.Drawing.Point(403, 98);
			// // this._lblCommonLabel_4.mLabelId = 2004;
			this._lblCommonLabel_4.Name = "_lblCommonLabel_4";
			this._lblCommonLabel_4.Size = new System.Drawing.Size(72, 13);
			this._lblCommonLabel_4.TabIndex = 17;
			// 
			// _txtCommonTextBox_1
			// 
			this._txtCommonTextBox_1.AllowDrop = true;
			this._txtCommonTextBox_1.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_1.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_1.Location = new System.Drawing.Point(87, 73);
			this._txtCommonTextBox_1.MaxLength = 10;
			this._txtCommonTextBox_1.Name = "_txtCommonTextBox_1";
			// this._txtCommonTextBox_1.ShowButton = true;
			this._txtCommonTextBox_1.Size = new System.Drawing.Size(101, 19);
			this._txtCommonTextBox_1.TabIndex = 3;
			this._txtCommonTextBox_1.Text = "";
			// this.this._txtCommonTextBox_1.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_1.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _lblCommonLabel_2
			// 
			this._lblCommonLabel_2.AllowDrop = true;
			this._lblCommonLabel_2.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_2.Text = "Training Code";
			this._lblCommonLabel_2.Location = new System.Drawing.Point(4, 75);
			// // this._lblCommonLabel_2.mLabelId = 2003;
			this._lblCommonLabel_2.Name = "_lblCommonLabel_2";
			this._lblCommonLabel_2.Size = new System.Drawing.Size(66, 14);
			this._lblCommonLabel_2.TabIndex = 18;
			// 
			// _lblCommonLabel_5
			// 
			this._lblCommonLabel_5.AllowDrop = true;
			this._lblCommonLabel_5.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_5.Text = "Transaction No.";
			this._lblCommonLabel_5.Location = new System.Drawing.Point(4, 54);
			// // this._lblCommonLabel_5.mLabelId = 1744;
			this._lblCommonLabel_5.Name = "_lblCommonLabel_5";
			this._lblCommonLabel_5.Size = new System.Drawing.Size(76, 14);
			this._lblCommonLabel_5.TabIndex = 19;
			// 
			// _lblCommonLabel_6
			// 
			this._lblCommonLabel_6.AllowDrop = true;
			this._lblCommonLabel_6.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_6.Text = "From Date";
			this._lblCommonLabel_6.Location = new System.Drawing.Point(225, 54);
			// // this._lblCommonLabel_6.mLabelId = 2001;
			this._lblCommonLabel_6.Name = "_lblCommonLabel_6";
			this._lblCommonLabel_6.Size = new System.Drawing.Size(49, 14);
			this._lblCommonLabel_6.TabIndex = 20;
			// 
			// _txtCommonDate_2
			// 
			this._txtCommonDate_2.AllowDrop = true;
			// this._txtCommonDate_2.CheckDateRange = false;
			this._txtCommonDate_2.Location = new System.Drawing.Point(289, 52);
			// this._txtCommonDate_2.MaxDate = 2958465;
			// this._txtCommonDate_2.MinDate = 32874;
			this._txtCommonDate_2.Name = "_txtCommonDate_2";
			this._txtCommonDate_2.Size = new System.Drawing.Size(102, 19);
			this._txtCommonDate_2.TabIndex = 1;
			this._txtCommonDate_2.Text = "18/07/2001";
			// this._txtCommonDate_2.Value = 37090;
			// 
			// _txtCommonTextBox_0
			// 
			this._txtCommonTextBox_0.AllowDrop = true;
			this._txtCommonTextBox_0.BackColor = System.Drawing.Color.White;
			// this._txtCommonTextBox_0.bolAllowDecimal = false;
			// this._txtCommonTextBox_0.bolNumericOnly = true;
			this._txtCommonTextBox_0.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_0.Location = new System.Drawing.Point(87, 52);
			// this._txtCommonTextBox_0.mDropDownType = System.Windows.Forms.TextBox.DropDownTypes.ddtNextNumber;
			this._txtCommonTextBox_0.Name = "_txtCommonTextBox_0";
			// this._txtCommonTextBox_0.ShowButton = true;
			this._txtCommonTextBox_0.Size = new System.Drawing.Size(102, 19);
			this._txtCommonTextBox_0.TabIndex = 0;
			this._txtCommonTextBox_0.Text = "";
			// this.this._txtCommonTextBox_0.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_0.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _lblCommonLabel_23
			// 
			this._lblCommonLabel_23.AllowDrop = true;
			this._lblCommonLabel_23.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_23.Text = "Duration Minutes";
			this._lblCommonLabel_23.Location = new System.Drawing.Point(403, 119);
			// // this._lblCommonLabel_23.mLabelId = 2005;
			this._lblCommonLabel_23.Name = "_lblCommonLabel_23";
			this._lblCommonLabel_23.Size = new System.Drawing.Size(80, 14);
			this._lblCommonLabel_23.TabIndex = 21;
			// 
			// _lblCommonLabel_21
			// 
			this._lblCommonLabel_21.AllowDrop = true;
			this._lblCommonLabel_21.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_21.Text = "Venue";
			this._lblCommonLabel_21.Location = new System.Drawing.Point(4, 141);
			// // this._lblCommonLabel_21.mLabelId = 1944;
			this._lblCommonLabel_21.Name = "_lblCommonLabel_21";
			this._lblCommonLabel_21.Size = new System.Drawing.Size(32, 14);
			this._lblCommonLabel_21.TabIndex = 22;
			// 
			// System.Windows.Forms.Label12
			// 
			this.Label12.AllowDrop = true;
			this.Label12.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.Label12.Text = "Comments";
			this.Label12.Location = new System.Drawing.Point(4, 162);
			// this.Label12.mLabelId = 1851;
			this.Label12.Name = "System.Windows.Forms.Label12";
			this.Label12.Size = new System.Drawing.Size(50, 14);
			this.Label12.TabIndex = 23;
			// 
			// _txtCommonTextBox_2
			// 
			this._txtCommonTextBox_2.AllowDrop = true;
			this._txtCommonTextBox_2.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_2.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_2.Location = new System.Drawing.Point(87, 159);
			// this._txtCommonTextBox_2.mArabicEnabled = true;
			this._txtCommonTextBox_2.MaxLength = 100;
			this._txtCommonTextBox_2.Name = "_txtCommonTextBox_2";
			this._txtCommonTextBox_2.Size = new System.Drawing.Size(304, 19);
			this._txtCommonTextBox_2.TabIndex = 7;
			this._txtCommonTextBox_2.Text = "";
			// this.this._txtCommonTextBox_2.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_2.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _lblCommonLabel_0
			// 
			this._lblCommonLabel_0.AllowDrop = true;
			this._lblCommonLabel_0.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_0.Text = "Trainer Name";
			this._lblCommonLabel_0.Location = new System.Drawing.Point(4, 120);
			// // this._lblCommonLabel_0.mLabelId = 2007;
			this._lblCommonLabel_0.Name = "_lblCommonLabel_0";
			this._lblCommonLabel_0.Size = new System.Drawing.Size(64, 14);
			this._lblCommonLabel_0.TabIndex = 24;
			// 
			// _txtCommonTextBox_3
			// 
			this._txtCommonTextBox_3.AllowDrop = true;
			this._txtCommonTextBox_3.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_3.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_3.Location = new System.Drawing.Point(87, 117);
			// this._txtCommonTextBox_3.mArabicEnabled = true;
			this._txtCommonTextBox_3.Name = "_txtCommonTextBox_3";
			this._txtCommonTextBox_3.Size = new System.Drawing.Size(304, 19);
			this._txtCommonTextBox_3.TabIndex = 5;
			this._txtCommonTextBox_3.Text = "";
			// this.this._txtCommonTextBox_3.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_3.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _txtDisplayLabel_0
			// 
			this._txtDisplayLabel_0.AllowDrop = true;
			this._txtDisplayLabel_0.Location = new System.Drawing.Point(190, 73);
			this._txtDisplayLabel_0.Name = "_txtDisplayLabel_0";
			this._txtDisplayLabel_0.Size = new System.Drawing.Size(201, 19);
			this._txtDisplayLabel_0.TabIndex = 25;
			// 
			// _lblCommonLabel_1
			// 
			this._lblCommonLabel_1.AllowDrop = true;
			this._lblCommonLabel_1.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_1.Text = "To Date";
			this._lblCommonLabel_1.Location = new System.Drawing.Point(403, 54);
			// // this._lblCommonLabel_1.mLabelId = 2002;
			this._lblCommonLabel_1.Name = "_lblCommonLabel_1";
			this._lblCommonLabel_1.Size = new System.Drawing.Size(37, 14);
			this._lblCommonLabel_1.TabIndex = 26;
			// 
			// _txtCommonDate_3
			// 
			this._txtCommonDate_3.AllowDrop = true;
			// this._txtCommonDate_3.CheckDateRange = false;
			this._txtCommonDate_3.Location = new System.Drawing.Point(489, 52);
			// this._txtCommonDate_3.MaxDate = 2958465;
			// this._txtCommonDate_3.MinDate = 32874;
			this._txtCommonDate_3.Name = "_txtCommonDate_3";
			this._txtCommonDate_3.Size = new System.Drawing.Size(102, 19);
			this._txtCommonDate_3.TabIndex = 2;
			this._txtCommonDate_3.Text = "18/07/2001";
			// this._txtCommonDate_3.Value = 37090;
			// 
			// _lblCommonLabel_3
			// 
			this._lblCommonLabel_3.AllowDrop = true;
			this._lblCommonLabel_3.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_3.Text = "Training Type";
			this._lblCommonLabel_3.Location = new System.Drawing.Point(4, 98);
			// // this._lblCommonLabel_3.mLabelId = 2006;
			this._lblCommonLabel_3.Name = "_lblCommonLabel_3";
			this._lblCommonLabel_3.Size = new System.Drawing.Size(65, 14);
			this._lblCommonLabel_3.TabIndex = 27;
			// 
			// _lblCommonLabel_7
			// 
			this._lblCommonLabel_7.AllowDrop = true;
			this._lblCommonLabel_7.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_7.Text = "Total Cost";
			this._lblCommonLabel_7.Location = new System.Drawing.Point(403, 138);
			// // this._lblCommonLabel_7.mLabelId = 2008;
			this._lblCommonLabel_7.Name = "_lblCommonLabel_7";
			this._lblCommonLabel_7.Size = new System.Drawing.Size(48, 14);
			this._lblCommonLabel_7.TabIndex = 28;
			// 
			// grdVoucherDetails
			// 
			this.grdVoucherDetails.AllowDrop = true;
			this.grdVoucherDetails.BackColor = System.Drawing.Color.Silver;
			this.grdVoucherDetails.CellTipsWidth = 0;
			this.grdVoucherDetails.Location = new System.Drawing.Point(4, 194);
			this.grdVoucherDetails.Name = "grdVoucherDetails";
			this.grdVoucherDetails.RowDivider.Color = System.Drawing.Color.Silver;
			this.grdVoucherDetails.Size = new System.Drawing.Size(587, 167);
			this.grdVoucherDetails.TabIndex = 12;
			this.grdVoucherDetails.Columns.Add(this.Column_0_grdVoucherDetails);
			this.grdVoucherDetails.Columns.Add(this.Column_1_grdVoucherDetails);
			this.grdVoucherDetails.AfterColUpdate += new C1.Win.C1TrueDBGrid.ColEventHandler(this.grdVoucherDetails_AfterColUpdate);
			this.grdVoucherDetails.BeforeColEdit += new C1.Win.C1TrueDBGrid.BeforeColEditEventHandler(this.grdVoucherDetails_BeforeColEdit);
			this.grdVoucherDetails.GotFocus += new System.EventHandler(this.grdVoucherDetails_GotFocus);
			// this.this.grdVoucherDetails.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.grdVoucherDetails_KeyPress);
			this.grdVoucherDetails.MouseUp += new System.Windows.Forms.MouseEventHandler(this.grdVoucherDetails_MouseUp);
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
			// _txtCommonTextBox_4
			// 
			this._txtCommonTextBox_4.AllowDrop = true;
			this._txtCommonTextBox_4.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_4.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_4.Location = new System.Drawing.Point(87, 138);
			// this._txtCommonTextBox_4.mArabicEnabled = true;
			this._txtCommonTextBox_4.Name = "_txtCommonTextBox_4";
			this._txtCommonTextBox_4.Size = new System.Drawing.Size(304, 19);
			this._txtCommonTextBox_4.TabIndex = 6;
			this._txtCommonTextBox_4.Text = "";
			// this.this._txtCommonTextBox_4.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_4.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// txtcost
			// 
			this.txtcost.AllowDrop = true;
			// this.txtcost.DisplayFormat = "####0.000###;;0.000;0.000";
			// this.txtcost.Format = "###########0.000";
			this.txtcost.Location = new System.Drawing.Point(489, 135);
			// this.txtcost.MaxValue = 2147483647;
			// this.txtcost.MinValue = 0;
			this.txtcost.Name = "txtcost";
			this.txtcost.Size = new System.Drawing.Size(102, 19);
			this.txtcost.TabIndex = 11;
			this.txtcost.Text = "0.000";
			// 
			// _txtCommonTextBox_7
			// 
			this._txtCommonTextBox_7.AllowDrop = true;
			this._txtCommonTextBox_7.BackColor = System.Drawing.Color.White;
			// this._txtCommonTextBox_7.bolNumericOnly = true;
			this._txtCommonTextBox_7.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_7.Location = new System.Drawing.Point(489, 73);
			this._txtCommonTextBox_7.Name = "_txtCommonTextBox_7";
			this._txtCommonTextBox_7.Size = new System.Drawing.Size(102, 19);
			this._txtCommonTextBox_7.TabIndex = 8;
			this._txtCommonTextBox_7.Text = "";
			// this.this._txtCommonTextBox_7.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_7.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _lblCommonLabel_8
			// 
			this._lblCommonLabel_8.AllowDrop = true;
			this._lblCommonLabel_8.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_8.Text = "No. Of Trainers";
			this._lblCommonLabel_8.Location = new System.Drawing.Point(403, 76);
			// // this._lblCommonLabel_8.mLabelId = 2009;
			this._lblCommonLabel_8.Name = "_lblCommonLabel_8";
			this._lblCommonLabel_8.Size = new System.Drawing.Size(74, 13);
			this._lblCommonLabel_8.TabIndex = 29;
			// 
			// txtDurationMins
			// 
			this.txtDurationMins.AllowDrop = true;
			// this.txtDurationMins.DisplayFormat = "####0.000###;;0;0";
			// this.txtDurationMins.Format = "###########0";
			this.txtDurationMins.Location = new System.Drawing.Point(489, 114);
			// this.txtDurationMins.MaxValue = 2147483647;
			// this.txtDurationMins.MinValue = 0;
			this.txtDurationMins.Name = "txtDurationMins";
			this.txtDurationMins.Size = new System.Drawing.Size(102, 19);
			this.txtDurationMins.TabIndex = 10;
			// 
			// txtDurationHRS
			// 
			this.txtDurationHRS.AllowDrop = true;
			// this.txtDurationHRS.DisplayFormat = "####0.000###;;0;0";
			// this.txtDurationHRS.Format = "###########0";
			this.txtDurationHRS.Location = new System.Drawing.Point(489, 94);
			// this.txtDurationHRS.MaxValue = 2147483647;
			// this.txtDurationHRS.MinValue = 0;
			this.txtDurationHRS.Name = "txtDurationHRS";
			this.txtDurationHRS.Size = new System.Drawing.Size(102, 19);
			this.txtDurationHRS.TabIndex = 9;
			// 
			// frmPayTrainingTrans
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.ClientSize = new System.Drawing.Size(593, 363);
			this.Controls.Add(this._cmbTrainingType_0);
			this.Controls.Add(this._txtCommonTextBox_11);
			this.Controls.Add(this._lblCommonLabel_9);
			this.Controls.Add(this._lblCommonLabel_12);
			this.Controls.Add(this.cmbMastersList);
			this.Controls.Add(this._lblCommonLabel_4);
			this.Controls.Add(this._txtCommonTextBox_1);
			this.Controls.Add(this._lblCommonLabel_2);
			this.Controls.Add(this._lblCommonLabel_5);
			this.Controls.Add(this._lblCommonLabel_6);
			this.Controls.Add(this._txtCommonDate_2);
			this.Controls.Add(this._txtCommonTextBox_0);
			this.Controls.Add(this._lblCommonLabel_23);
			this.Controls.Add(this._lblCommonLabel_21);
			this.Controls.Add(this.Label12);
			this.Controls.Add(this._txtCommonTextBox_2);
			this.Controls.Add(this._lblCommonLabel_0);
			this.Controls.Add(this._txtCommonTextBox_3);
			this.Controls.Add(this._txtDisplayLabel_0);
			this.Controls.Add(this._lblCommonLabel_1);
			this.Controls.Add(this._txtCommonDate_3);
			this.Controls.Add(this._lblCommonLabel_3);
			this.Controls.Add(this._lblCommonLabel_7);
			this.Controls.Add(this.grdVoucherDetails);
			this.Controls.Add(this._txtCommonTextBox_4);
			this.Controls.Add(this.txtcost);
			this.Controls.Add(this._txtCommonTextBox_7);
			this.Controls.Add(this._lblCommonLabel_8);
			this.Controls.Add(this.txtDurationMins);
			this.Controls.Add(this.txtDurationHRS);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			//this.Icon = (System.Drawing.Icon) resources.GetObject("frmPayTrainingTrans.Icon");
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(279, 264);
			this.MaximizeBox = true;
			this.MinimizeBox = true;
			this.Name = "frmPayTrainingTrans";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Tag = "\"H: 6225  W:9570\"";
			this.Text = "Training Transaction";
			// this.Activated += new System.EventHandler(this.Form_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
			// this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
			this.cmbMastersList.ResumeLayout(false);
			this.grdVoucherDetails.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		// 
		void InitializetxtDisplayLabel()
		{
			this.txtDisplayLabel = new System.Windows.Forms.Label[1];
			this.txtDisplayLabel[0] = _txtDisplayLabel_0;
		}
		void InitializetxtCommonTextBox()
		{
			this.txtCommonTextBox = new System.Windows.Forms.TextBox[12];
			this.txtCommonTextBox[11] = _txtCommonTextBox_11;
			this.txtCommonTextBox[1] = _txtCommonTextBox_1;
			this.txtCommonTextBox[0] = _txtCommonTextBox_0;
			this.txtCommonTextBox[2] = _txtCommonTextBox_2;
			this.txtCommonTextBox[3] = _txtCommonTextBox_3;
			this.txtCommonTextBox[4] = _txtCommonTextBox_4;
			this.txtCommonTextBox[7] = _txtCommonTextBox_7;
		}
		void InitializetxtCommonDate()
		{
			this.txtCommonDate = new Syncfusion.WinForms.Input.SfDateTimeEdit[4];
			this.txtCommonDate[2] = _txtCommonDate_2;
			this.txtCommonDate[3] = _txtCommonDate_3;
		}
		void InitializelblCommonLabel()
		{
			this.lblCommonLabel = new System.Windows.Forms.Label[24];
			this.lblCommonLabel[9] = _lblCommonLabel_9;
			this.lblCommonLabel[12] = _lblCommonLabel_12;
			this.lblCommonLabel[4] = _lblCommonLabel_4;
			this.lblCommonLabel[2] = _lblCommonLabel_2;
			this.lblCommonLabel[5] = _lblCommonLabel_5;
			this.lblCommonLabel[6] = _lblCommonLabel_6;
			this.lblCommonLabel[23] = _lblCommonLabel_23;
			this.lblCommonLabel[21] = _lblCommonLabel_21;
			this.lblCommonLabel[0] = _lblCommonLabel_0;
			this.lblCommonLabel[1] = _lblCommonLabel_1;
			this.lblCommonLabel[3] = _lblCommonLabel_3;
			this.lblCommonLabel[7] = _lblCommonLabel_7;
			this.lblCommonLabel[8] = _lblCommonLabel_8;
		}
		void InitializecmbTrainingType()
		{
			this.cmbTrainingType = new System.Windows.Forms.ComboBox[1];
			this.cmbTrainingType[0] = _cmbTrainingType_0;
		}
		#endregion
	}
}//ENDSHERE
