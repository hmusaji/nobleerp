
namespace Xtreme
{
	partial class frmICSExcessShortage
	{

		#region "Upgrade Support "
		private static frmICSExcessShortage m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmICSExcessShortage DefInstance
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
		public static frmICSExcessShortage CreateInstance()
		{
			frmICSExcessShortage theInstance = new frmICSExcessShortage();
			
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
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "txtRemark", "_lblCommonLabel_9", "_lblCommonLabel_8", "txtSalesman", "txtSmanDisplayLabel", "frameBottom", "txtVoucherDate", "txtLocation", "_lblCommonLabel_5", "_lblCommonLabel_6", "txtVoucherNo", "txtLocDisplayLabel", "_lblCommonLabel_0", "txtLdgrCode", "txtLedgerName", "_lblSource_1", "txtSourceVoucherType", "_lblSourceVoucherType_1", "_lblVoucherNo_1", "txtSourceVoucherNo", "_lblCommonLabel_1", "Shape", "fraTransactionHeader", "Column_0_grdProductOut", "Column_1_grdProductOut", "grdProductOut", "Column_0_cmbMastersListOut", "Column_1_cmbMastersListOut", "cmbMastersListOut", "TabControlPage2", "Column_0_grdProductIn", "Column_1_grdProductIn", "grdProductIn", "Column_0_cmbMastersList", "Column_1_cmbMastersList", "cmbMastersList", "TabControlPage1", "tabMaster", "CommandBars", "lblCommonLabel", "lblSource", "lblSourceVoucherType", "lblVoucherNo"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public System.Windows.Forms.TextBox txtRemark;
		private System.Windows.Forms.Label _lblCommonLabel_9;
		private System.Windows.Forms.Label _lblCommonLabel_8;
		public System.Windows.Forms.TextBox txtSalesman;
		public System.Windows.Forms.Label txtSmanDisplayLabel;
		public System.Windows.Forms.Panel frameBottom;
		public Syncfusion.WinForms.Input.SfDateTimeEdit txtVoucherDate;
		public System.Windows.Forms.TextBox txtLocation;
		private System.Windows.Forms.Label _lblCommonLabel_5;
		private System.Windows.Forms.Label _lblCommonLabel_6;
		public System.Windows.Forms.TextBox txtVoucherNo;
		public System.Windows.Forms.Label txtLocDisplayLabel;
		private System.Windows.Forms.Label _lblCommonLabel_0;
		public System.Windows.Forms.TextBox txtLdgrCode;
		public System.Windows.Forms.Label txtLedgerName;
		private System.Windows.Forms.Label _lblSource_1;
		public System.Windows.Forms.TextBox txtSourceVoucherType;
		private System.Windows.Forms.Label _lblSourceVoucherType_1;
		private System.Windows.Forms.Label _lblVoucherNo_1;
		public System.Windows.Forms.TextBox txtSourceVoucherNo;
		private System.Windows.Forms.Label _lblCommonLabel_1;
		public ShapeHelper Shape;
		public System.Windows.Forms.Panel fraTransactionHeader;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_0_grdProductOut;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_1_grdProductOut;
		public C1.Win.C1TrueDBGrid.C1TrueDBGrid grdProductOut;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_0_cmbMastersListOut;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_1_cmbMastersListOut;
		public C1.Win.C1TrueDBGrid.C1TrueDBDropdown cmbMastersListOut;
		public Syncfusion.Windows.Forms.Tools.TabPageAdv TabControlPage2;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_0_grdProductIn;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_1_grdProductIn;
		public C1.Win.C1TrueDBGrid.C1TrueDBGrid grdProductIn;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_0_cmbMastersList;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_1_cmbMastersList;
		public C1.Win.C1TrueDBGrid.C1TrueDBDropdown cmbMastersList;
		public Syncfusion.Windows.Forms.Tools.TabPageAdv TabControlPage1;
		public Syncfusion.Windows.Forms.Tools.TabControlAdv tabMaster;
		public Syncfusion.Windows.Forms.Tools.CommandBarController CommandBars;
		public System.Windows.Forms.Label[] lblCommonLabel = new System.Windows.Forms.Label[10];
		public System.Windows.Forms.Label[] lblSource = new System.Windows.Forms.Label[2];
		public System.Windows.Forms.Label[] lblSourceVoucherType = new System.Windows.Forms.Label[2];
		public System.Windows.Forms.Label[] lblVoucherNo = new System.Windows.Forms.Label[2];
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmICSExcessShortage));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this.frameBottom = new System.Windows.Forms.Panel();
			this.txtRemark = new System.Windows.Forms.TextBox();
			this._lblCommonLabel_9 = new System.Windows.Forms.Label();
			this._lblCommonLabel_8 = new System.Windows.Forms.Label();
			this.txtSalesman = new System.Windows.Forms.TextBox();
			this.txtSmanDisplayLabel = new System.Windows.Forms.Label();
			this.fraTransactionHeader = new System.Windows.Forms.Panel();
			this.txtVoucherDate = new Syncfusion.WinForms.Input.SfDateTimeEdit();
			this.txtLocation = new System.Windows.Forms.TextBox();
			this._lblCommonLabel_5 = new System.Windows.Forms.Label();
			this._lblCommonLabel_6 = new System.Windows.Forms.Label();
			this.txtVoucherNo = new System.Windows.Forms.TextBox();
			this.txtLocDisplayLabel = new System.Windows.Forms.Label();
			this._lblCommonLabel_0 = new System.Windows.Forms.Label();
			this.txtLdgrCode = new System.Windows.Forms.TextBox();
			this.txtLedgerName = new System.Windows.Forms.Label();
			this._lblSource_1 = new System.Windows.Forms.Label();
			this.txtSourceVoucherType = new System.Windows.Forms.TextBox();
			this._lblSourceVoucherType_1 = new System.Windows.Forms.Label();
			this._lblVoucherNo_1 = new System.Windows.Forms.Label();
			this.txtSourceVoucherNo = new System.Windows.Forms.TextBox();
			this._lblCommonLabel_1 = new System.Windows.Forms.Label();
			this.Shape = new ShapeHelper();
			this.tabMaster = new Syncfusion.Windows.Forms.Tools.TabControlAdv();
			this.TabControlPage2 = new Syncfusion.Windows.Forms.Tools.TabPageAdv();
			this.grdProductOut = new C1.Win.C1TrueDBGrid.C1TrueDBGrid();
			this.Column_0_grdProductOut = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.Column_1_grdProductOut = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.cmbMastersListOut = new C1.Win.C1TrueDBGrid.C1TrueDBDropdown();
			this.Column_0_cmbMastersListOut = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.Column_1_cmbMastersListOut = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.TabControlPage1 = new Syncfusion.Windows.Forms.Tools.TabPageAdv();
			this.grdProductIn = new C1.Win.C1TrueDBGrid.C1TrueDBGrid();
			this.Column_0_grdProductIn = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.Column_1_grdProductIn = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.cmbMastersList = new C1.Win.C1TrueDBGrid.C1TrueDBDropdown();
			this.Column_0_cmbMastersList = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.Column_1_cmbMastersList = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.CommandBars = new Syncfusion.Windows.Forms.Tools.CommandBarController();
			// //((System.ComponentModel.ISupportInitialize) this.TabControlPage2).BeginInit();
			// //((System.ComponentModel.ISupportInitialize) this.TabControlPage1).BeginInit();
			// //((System.ComponentModel.ISupportInitialize) this.tabMaster).BeginInit();
			// //((System.ComponentModel.ISupportInitialize) this.CommandBars).BeginInit();
			//this.frameBottom.SuspendLayout();
			//this.fraTransactionHeader.SuspendLayout();
			//this.tabMaster.SuspendLayout();
			//this.TabControlPage2.SuspendLayout();
			//this.grdProductOut.SuspendLayout();
			//this.cmbMastersListOut.SuspendLayout();
			//this.TabControlPage1.SuspendLayout();
			//this.grdProductIn.SuspendLayout();
			//this.cmbMastersList.SuspendLayout();
			this.SuspendLayout();
			// 
			// frameBottom
			// 
			//this.frameBottom.AllowDrop = true;
			this.frameBottom.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			//this.frameBottom.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.frameBottom.Controls.Add(this.txtRemark);
			this.frameBottom.Controls.Add(this._lblCommonLabel_9);
			this.frameBottom.Controls.Add(this._lblCommonLabel_8);
			this.frameBottom.Controls.Add(this.txtSalesman);
			this.frameBottom.Controls.Add(this.txtSmanDisplayLabel);
			this.frameBottom.Enabled = true;
			this.frameBottom.ForeColor = System.Drawing.SystemColors.ControlText;
			this.frameBottom.Location = new System.Drawing.Point(6, 486);
			this.frameBottom.Name = "frameBottom";
			this.frameBottom.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.frameBottom.Size = new System.Drawing.Size(627, 59);
			this.frameBottom.TabIndex = 19;
			this.frameBottom.Visible = true;
			// 
			// txtRemark
			// 
			//this.txtRemark.AllowDrop = true;
			this.txtRemark.BackColor = System.Drawing.Color.White;
			this.txtRemark.ForeColor = System.Drawing.Color.Black;
			this.txtRemark.Location = new System.Drawing.Point(61, 34);
			this.txtRemark.MaxLength = 200;
			this.txtRemark.Name = "txtRemark";
			this.txtRemark.Size = new System.Drawing.Size(401, 19);
			this.txtRemark.TabIndex = 20;
			this.txtRemark.Text = "";
			// this.// = "";
			// 
			// _lblCommonLabel_9
			// 
			//this._lblCommonLabel_9.AllowDrop = true;
			this._lblCommonLabel_9.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_9.Text = "Narration";
			this._lblCommonLabel_9.ForeColor = System.Drawing.Color.Black;
			this._lblCommonLabel_9.Location = new System.Drawing.Point(6, 37);
			this._lblCommonLabel_9.Name = "_lblCommonLabel_9";
			this._lblCommonLabel_9.Size = new System.Drawing.Size(45, 13);
			this._lblCommonLabel_9.TabIndex = 21;
			// 
			// _lblCommonLabel_8
			// 
			//this._lblCommonLabel_8.AllowDrop = true;
			this._lblCommonLabel_8.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_8.Text = "Salesman";
			this._lblCommonLabel_8.ForeColor = System.Drawing.Color.Black;
			this._lblCommonLabel_8.Location = new System.Drawing.Point(8, 12);
			// // this._lblCommonLabel_8.mLabelId = 687;
			this._lblCommonLabel_8.Name = "_lblCommonLabel_8";
			this._lblCommonLabel_8.Size = new System.Drawing.Size(47, 14);
			this._lblCommonLabel_8.TabIndex = 22;
			// 
			// txtSalesman
			// 
			//this.txtSalesman.AllowDrop = true;
			this.txtSalesman.BackColor = System.Drawing.Color.White;
			// this.txtSalesman.bolNumericOnly = true;
			this.txtSalesman.ForeColor = System.Drawing.Color.Black;
			this.txtSalesman.Location = new System.Drawing.Point(61, 10);
			this.txtSalesman.MaxLength = 4;
			this.txtSalesman.Name = "txtSalesman";
			// this.txtSalesman.ShowButton = true;
			this.txtSalesman.Size = new System.Drawing.Size(101, 19);
			this.txtSalesman.TabIndex = 23;
			this.txtSalesman.Text = "";
			// this.// = "";
			// this.//this.txtSalesman.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(//this.txtSalesman_DropButtonClick);
			// this.txtSalesman.Leave += new System.EventHandler(this.txtSalesman_Leave);
			// 
			// txtSmanDisplayLabel
			// 
			//this.txtSmanDisplayLabel.AllowDrop = true;
			this.txtSmanDisplayLabel.Location = new System.Drawing.Point(164, 10);
			this.txtSmanDisplayLabel.Name = "txtSmanDisplayLabel";
			this.txtSmanDisplayLabel.Size = new System.Drawing.Size(199, 19);
			this.txtSmanDisplayLabel.TabIndex = 24;
			// 
			// fraTransactionHeader
			// 
			//this.fraTransactionHeader.AllowDrop = true;
			this.fraTransactionHeader.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			//this.fraTransactionHeader.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.fraTransactionHeader.Controls.Add(this.txtVoucherDate);
			this.fraTransactionHeader.Controls.Add(this.txtLocation);
			this.fraTransactionHeader.Controls.Add(this._lblCommonLabel_5);
			this.fraTransactionHeader.Controls.Add(this._lblCommonLabel_6);
			this.fraTransactionHeader.Controls.Add(this.txtVoucherNo);
			this.fraTransactionHeader.Controls.Add(this.txtLocDisplayLabel);
			this.fraTransactionHeader.Controls.Add(this._lblCommonLabel_0);
			this.fraTransactionHeader.Controls.Add(this.txtLdgrCode);
			this.fraTransactionHeader.Controls.Add(this.txtLedgerName);
			this.fraTransactionHeader.Controls.Add(this._lblSource_1);
			this.fraTransactionHeader.Controls.Add(this.txtSourceVoucherType);
			this.fraTransactionHeader.Controls.Add(this._lblSourceVoucherType_1);
			this.fraTransactionHeader.Controls.Add(this._lblVoucherNo_1);
			this.fraTransactionHeader.Controls.Add(this.txtSourceVoucherNo);
			this.fraTransactionHeader.Controls.Add(this._lblCommonLabel_1);
			this.fraTransactionHeader.Controls.Add(this.Shape);
			this.fraTransactionHeader.Enabled = true;
			this.fraTransactionHeader.ForeColor = System.Drawing.SystemColors.ControlText;
			this.fraTransactionHeader.Location = new System.Drawing.Point(6, 2);
			this.fraTransactionHeader.Name = "fraTransactionHeader";
			this.fraTransactionHeader.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.fraTransactionHeader.Size = new System.Drawing.Size(779, 143);
			this.fraTransactionHeader.TabIndex = 3;
			this.fraTransactionHeader.Visible = true;
			// 
			// txtVoucherDate
			// 
			//this.txtVoucherDate.AllowDrop = true;
			// this.txtVoucherDate.CheckDateRange = false;
			this.txtVoucherDate.Location = new System.Drawing.Point(86, 58);
			// this.txtVoucherDate.MaxDate = 2958465;
			// this.txtVoucherDate.MinDate = 32874;
			this.txtVoucherDate.Name = "txtVoucherDate";
			this.txtVoucherDate.Size = new System.Drawing.Size(102, 19);
			this.txtVoucherDate.TabIndex = 4;
			// this.txtVoucherDate.Text = "07/18/2001";
			// this.txtVoucherDate.Value = 37090;
			// 
			// txtLocation
			// 
			//this.txtLocation.AllowDrop = true;
			this.txtLocation.BackColor = System.Drawing.Color.White;
			// this.txtLocation.bolNumericOnly = true;
			this.txtLocation.ForeColor = System.Drawing.Color.Black;
			this.txtLocation.Location = new System.Drawing.Point(86, 14);
			this.txtLocation.MaxLength = 4;
			this.txtLocation.Name = "txtLocation";
			// this.txtLocation.ShowButton = true;
			this.txtLocation.Size = new System.Drawing.Size(101, 19);
			this.txtLocation.TabIndex = 5;
			this.txtLocation.Text = "";
			// this.// = "";
			// this.//this.txtLocation.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(//this.txtLocation_DropButtonClick);
			// this.txtLocation.Leave += new System.EventHandler(this.txtLocation_Leave);
			// 
			// _lblCommonLabel_5
			// 
			//this._lblCommonLabel_5.AllowDrop = true;
			this._lblCommonLabel_5.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_5.Text = "Voucher No.";
			this._lblCommonLabel_5.ForeColor = System.Drawing.Color.Black;
			this._lblCommonLabel_5.Location = new System.Drawing.Point(6, 38);
			// // this._lblCommonLabel_5.mLabelId = 850;
			this._lblCommonLabel_5.Name = "_lblCommonLabel_5";
			this._lblCommonLabel_5.Size = new System.Drawing.Size(61, 14);
			this._lblCommonLabel_5.TabIndex = 6;
			// 
			// _lblCommonLabel_6
			// 
			//this._lblCommonLabel_6.AllowDrop = true;
			this._lblCommonLabel_6.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_6.Text = "Voucher Date";
			this._lblCommonLabel_6.ForeColor = System.Drawing.Color.Black;
			this._lblCommonLabel_6.Location = new System.Drawing.Point(6, 59);
			// // this._lblCommonLabel_6.mLabelId = 848;
			this._lblCommonLabel_6.Name = "_lblCommonLabel_6";
			this._lblCommonLabel_6.Size = new System.Drawing.Size(67, 14);
			this._lblCommonLabel_6.TabIndex = 7;
			// 
			// txtVoucherNo
			// 
			//this.txtVoucherNo.AllowDrop = true;
			this.txtVoucherNo.BackColor = System.Drawing.Color.FromArgb(239, 239, 239);
			// this.txtVoucherNo.bolNumericOnly = true;
			this.txtVoucherNo.Enabled = false;
			this.txtVoucherNo.ForeColor = System.Drawing.Color.Black;
			this.txtVoucherNo.Location = new System.Drawing.Point(86, 36);
			this.txtVoucherNo.MaxLength = 11;
			this.txtVoucherNo.Name = "txtVoucherNo";
			this.txtVoucherNo.Size = new System.Drawing.Size(102, 19);
			this.txtVoucherNo.TabIndex = 8;
			this.txtVoucherNo.Text = "";
			// this.// = "";
			// 
			// txtLocDisplayLabel
			// 
			//this.txtLocDisplayLabel.AllowDrop = true;
			this.txtLocDisplayLabel.Location = new System.Drawing.Point(192, 14);
			this.txtLocDisplayLabel.Name = "txtLocDisplayLabel";
			this.txtLocDisplayLabel.Size = new System.Drawing.Size(275, 19);
			this.txtLocDisplayLabel.TabIndex = 9;
			// 
			// _lblCommonLabel_0
			// 
			//this._lblCommonLabel_0.AllowDrop = true;
			this._lblCommonLabel_0.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_0.Text = "Customer";
			this._lblCommonLabel_0.ForeColor = System.Drawing.Color.Black;
			this._lblCommonLabel_0.Location = new System.Drawing.Point(6, 82);
			// // this._lblCommonLabel_0.mLabelId = 848;
			this._lblCommonLabel_0.Name = "_lblCommonLabel_0";
			this._lblCommonLabel_0.Size = new System.Drawing.Size(46, 14);
			this._lblCommonLabel_0.TabIndex = 10;
			// 
			// txtLdgrCode
			// 
			//this.txtLdgrCode.AllowDrop = true;
			this.txtLdgrCode.BackColor = System.Drawing.Color.White;
			// this.txtLdgrCode.bolNumericOnly = true;
			this.txtLdgrCode.ForeColor = System.Drawing.Color.Black;
			this.txtLdgrCode.Location = new System.Drawing.Point(86, 80);
			this.txtLdgrCode.MaxLength = 20;
			this.txtLdgrCode.Name = "txtLdgrCode";
			// this.txtLdgrCode.ShowButton = true;
			this.txtLdgrCode.Size = new System.Drawing.Size(101, 19);
			this.txtLdgrCode.TabIndex = 11;
			this.txtLdgrCode.Text = "";
			// this.// = "";
			// this.//this.txtLdgrCode.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(//this.txtLdgrCode_DropButtonClick);
			// this.txtLdgrCode.Leave += new System.EventHandler(this.txtLdgrCode_Leave);
			// 
			// txtLedgerName
			// 
			//this.txtLedgerName.AllowDrop = true;
			this.txtLedgerName.Location = new System.Drawing.Point(190, 80);
			this.txtLedgerName.Name = "txtLedgerName";
			this.txtLedgerName.Size = new System.Drawing.Size(275, 19);
			this.txtLedgerName.TabIndex = 12;
			// 
			// _lblSource_1
			// 
			//this._lblSource_1.AllowDrop = true;
			this._lblSource_1.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblSource_1.Text = "Source";
			this._lblSource_1.ForeColor = System.Drawing.Color.Black;
			this._lblSource_1.Location = new System.Drawing.Point(488, 34);
			// // this._lblSource_1.mLabelId = 850;
			this._lblSource_1.Name = "_lblSource_1";
			this._lblSource_1.Size = new System.Drawing.Size(35, 14);
			this._lblSource_1.TabIndex = 13;
			this._lblSource_1.Visible = false;
			// 
			// txtSourceVoucherType
			// 
			//this.txtSourceVoucherType.AllowDrop = true;
			this.txtSourceVoucherType.BackColor = System.Drawing.Color.White;
			// this.txtSourceVoucherType.bolNumericOnly = true;
			this.txtSourceVoucherType.ForeColor = System.Drawing.Color.Black;
			this.txtSourceVoucherType.Location = new System.Drawing.Point(566, 50);
			this.txtSourceVoucherType.MaxLength = 4;
			this.txtSourceVoucherType.Name = "txtSourceVoucherType";
			// this.txtSourceVoucherType.ShowButton = true;
			this.txtSourceVoucherType.Size = new System.Drawing.Size(101, 19);
			this.txtSourceVoucherType.TabIndex = 14;
			this.txtSourceVoucherType.Text = "";
			this.txtSourceVoucherType.Visible = false;
			// this.// = "";
			// this.//this.txtSourceVoucherType.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(//this.txtSourceVoucherType_DropButtonClick);
			// 
			// _lblSourceVoucherType_1
			// 
			//this._lblSourceVoucherType_1.AllowDrop = true;
			this._lblSourceVoucherType_1.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblSourceVoucherType_1.Text = "Voucher Type";
			this._lblSourceVoucherType_1.ForeColor = System.Drawing.Color.Black;
			this._lblSourceVoucherType_1.Location = new System.Drawing.Point(488, 53);
			// // this._lblSourceVoucherType_1.mLabelId = 416;
			this._lblSourceVoucherType_1.Name = "_lblSourceVoucherType_1";
			this._lblSourceVoucherType_1.Size = new System.Drawing.Size(69, 14);
			this._lblSourceVoucherType_1.TabIndex = 15;
			this._lblSourceVoucherType_1.Visible = false;
			// 
			// _lblVoucherNo_1
			// 
			//this._lblVoucherNo_1.AllowDrop = true;
			this._lblVoucherNo_1.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblVoucherNo_1.Text = "Voucher No.";
			this._lblVoucherNo_1.ForeColor = System.Drawing.Color.Black;
			this._lblVoucherNo_1.Location = new System.Drawing.Point(488, 74);
			// // this._lblVoucherNo_1.mLabelId = 850;
			this._lblVoucherNo_1.Name = "_lblVoucherNo_1";
			this._lblVoucherNo_1.Size = new System.Drawing.Size(61, 14);
			this._lblVoucherNo_1.TabIndex = 16;
			this._lblVoucherNo_1.Visible = false;
			// 
			// txtSourceVoucherNo
			// 
			//this.txtSourceVoucherNo.AllowDrop = true;
			this.txtSourceVoucherNo.BackColor = System.Drawing.Color.White;
			// this.txtSourceVoucherNo.bolNumericOnly = true;
			this.txtSourceVoucherNo.ForeColor = System.Drawing.Color.Black;
			this.txtSourceVoucherNo.Location = new System.Drawing.Point(566, 72);
			this.txtSourceVoucherNo.MaxLength = 11;
			this.txtSourceVoucherNo.Name = "txtSourceVoucherNo";
			this.txtSourceVoucherNo.Size = new System.Drawing.Size(102, 19);
			this.txtSourceVoucherNo.TabIndex = 17;
			this.txtSourceVoucherNo.Text = "";
			this.txtSourceVoucherNo.Visible = false;
			// this.// = "";
			// 
			// _lblCommonLabel_1
			// 
			//this._lblCommonLabel_1.AllowDrop = true;
			this._lblCommonLabel_1.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_1.Text = "Location";
			this._lblCommonLabel_1.ForeColor = System.Drawing.Color.Black;
			this._lblCommonLabel_1.Location = new System.Drawing.Point(8, 14);
			// // this._lblCommonLabel_1.mLabelId = 850;
			this._lblCommonLabel_1.Name = "_lblCommonLabel_1";
			this._lblCommonLabel_1.Size = new System.Drawing.Size(41, 14);
			this._lblCommonLabel_1.TabIndex = 18;
			// 
			// Shape
			// 
			//this.Shape.AllowDrop = true;
			this.Shape.BackColor = System.Drawing.SystemColors.Window;
			// = 0;
			//this.Shape.BorderStyle = 1;
			this.Shape.Enabled = false;
			//this.Shape.FillColor = System.Drawing.Color.Black;
			//this.Shape.FillStyle = 1;
			this.Shape.Location = new System.Drawing.Point(478, 42);
			this.Shape.Name = "Shape";
			this.Shape.Size = new System.Drawing.Size(209, 57);
			this.Shape.Visible = false;
			// 
			// tabMaster
			// 
			//this.tabMaster.AllowDrop = true;
			this.tabMaster.Controls.Add(this.TabControlPage2);
			this.tabMaster.Controls.Add(this.TabControlPage1);
			this.tabMaster.Location = new System.Drawing.Point(6, 148);
			this.tabMaster.Name = "tabMaster";
			//
			this.tabMaster.Size = new System.Drawing.Size(865, 327);
			this.tabMaster.TabIndex = 0;
			// 
			// TabControlPage2
			// 
			//this.TabControlPage2.AllowDrop = true;
			this.TabControlPage2.Controls.Add(this.grdProductOut);
			this.TabControlPage2.Controls.Add(this.cmbMastersListOut);
			this.TabControlPage2.Location = new System.Drawing.Point(-4664, 26);
			this.TabControlPage2.Name = "TabControlPage2";
			//
			this.TabControlPage2.Size = new System.Drawing.Size(861, 299);
			this.TabControlPage2.TabIndex = 2;
			this.TabControlPage2.Visible = false;
			// 
			// grdProductOut
			// 
			this.grdProductOut.AllowAddNew = true;
			this.grdProductOut.AllowDelete = true;
			//this.grdProductOut.AllowDrop = true;
			this.grdProductOut.BackColor = System.Drawing.Color.FromArgb(212, 208, 200);
			this.grdProductOut.CellTipsWidth = 0;
			this.grdProductOut.Location = new System.Drawing.Point(2, 4);
			this.grdProductOut.Name = "grdProductOut";
			this.grdProductOut.RowDivider.Color = System.Drawing.Color.FromArgb(212, 208, 200);
			this.grdProductOut.Size = new System.Drawing.Size(701, 176);
			this.grdProductOut.TabIndex = 27;
			this.grdProductOut.Columns.Add(this.Column_0_grdProductOut);
			this.grdProductOut.Columns.Add(this.Column_1_grdProductOut);
			//this.grdProductOut.AfterColUpdate += new C1.Win.C1TrueDBGrid.ColEventHandler(this.grdProductOut_AfterColUpdate);
			//this.grdProductOut.GotFocus += new System.EventHandler(this.grdProductOut_GotFocus);
			//this.grdProductOut.RowColChange += new C1.Win.C1TrueDBGrid.RowColChangeEventHandler(this.grdProductOut_RowColChange);
			// 
			// Column_0_grdProductOut
			// 
			this.Column_0_grdProductOut.DataField = "";
			this.Column_0_grdProductOut.ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.Normal;
			// 
			// Column_1_grdProductOut
			// 
			this.Column_1_grdProductOut.DataField = "";
			this.Column_1_grdProductOut.ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.Normal;
			// 
			// cmbMastersListOut
			// 
			//this.cmbMastersListOut.AllowDrop = true;
			this.cmbMastersListOut.ColumnHeaders = true;
			this.cmbMastersListOut.Enabled = true;
			this.cmbMastersListOut.Location = new System.Drawing.Point(24, 118);
			this.cmbMastersListOut.Name = "cmbMastersListOut";
			this.cmbMastersListOut.Size = new System.Drawing.Size(227, 97);
			this.cmbMastersListOut.TabIndex = 28;
			this.cmbMastersListOut.Columns.Add(this.Column_0_cmbMastersListOut);
			this.cmbMastersListOut.Columns.Add(this.Column_1_cmbMastersListOut);
			// 
			// Column_0_cmbMastersListOut
			// 
			this.Column_0_cmbMastersListOut.DataField = "";
			this.Column_0_cmbMastersListOut.ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.Normal;
			// 
			// Column_1_cmbMastersListOut
			// 
			this.Column_1_cmbMastersListOut.DataField = "";
			this.Column_1_cmbMastersListOut.ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.Normal;
			// 
			// TabControlPage1
			// 
			//this.TabControlPage1.AllowDrop = true;
			this.TabControlPage1.Controls.Add(this.grdProductIn);
			this.TabControlPage1.Controls.Add(this.cmbMastersList);
			this.TabControlPage1.Location = new System.Drawing.Point(2, 26);
			this.TabControlPage1.Name = "TabControlPage1";
			//
			this.TabControlPage1.Size = new System.Drawing.Size(861, 299);
			this.TabControlPage1.TabIndex = 1;
			// 
			// grdProductIn
			// 
			this.grdProductIn.AllowAddNew = true;
			this.grdProductIn.AllowDelete = true;
			//this.grdProductIn.AllowDrop = true;
			this.grdProductIn.BackColor = System.Drawing.Color.FromArgb(212, 208, 200);
			this.grdProductIn.CellTipsWidth = 0;
			this.grdProductIn.Location = new System.Drawing.Point(2, 4);
			this.grdProductIn.Name = "grdProductIn";
			this.grdProductIn.RowDivider.Color = System.Drawing.Color.FromArgb(212, 208, 200);
			this.grdProductIn.Size = new System.Drawing.Size(703, 176);
			this.grdProductIn.TabIndex = 25;
			this.grdProductIn.Columns.Add(this.Column_0_grdProductIn);
			this.grdProductIn.Columns.Add(this.Column_1_grdProductIn);
			//this.grdProductIn.AfterColUpdate += new C1.Win.C1TrueDBGrid.ColEventHandler(this.grdProductIn_AfterColUpdate);
			//this.grdProductIn.GotFocus += new System.EventHandler(this.grdProductIn_GotFocus);
			//this.grdProductIn.RowColChange += new C1.Win.C1TrueDBGrid.RowColChangeEventHandler(this.grdProductIn_RowColChange);
			// 
			// Column_0_grdProductIn
			// 
			this.Column_0_grdProductIn.DataField = "";
			this.Column_0_grdProductIn.ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.Normal;
			// 
			// Column_1_grdProductIn
			// 
			this.Column_1_grdProductIn.DataField = "";
			this.Column_1_grdProductIn.ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.Normal;
			// 
			// cmbMastersList
			// 
			//this.cmbMastersList.AllowDrop = true;
			this.cmbMastersList.ColumnHeaders = true;
			this.cmbMastersList.Enabled = true;
			this.cmbMastersList.Location = new System.Drawing.Point(34, 124);
			this.cmbMastersList.Name = "cmbMastersList";
			this.cmbMastersList.Size = new System.Drawing.Size(227, 97);
			this.cmbMastersList.TabIndex = 26;
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
			// CommandBars
			// 
			////this.CommandBars.AllowDrop = true;
			//this.CommandBars.Location = new System.Drawing.Point(792, 2);
			//this.CommandBars.Name = "CommandBars";
			//
			// 
			// frmICSExcessShortage
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.ClientSize = new System.Drawing.Size(896, 579);
			this.Controls.Add(this.frameBottom);
			this.Controls.Add(this.fraTransactionHeader);
			this.Controls.Add(this.tabMaster);
			//this.Controls.Add(this.CommandBars);
			//this.Icon = (System.Drawing.Icon) resources.GetObject("frmICSExcessShortage.Icon");
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(109, 180);
			this.MaximizeBox = true;
			this.MinimizeBox = true;
			this.Name = "frmICSExcessShortage";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Product Exchange";
			// this.Activated += new System.EventHandler(this.frmICSExcessShortage_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
			// this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
			//this.Resize += new System.EventHandler(this.Form_Resize);
			//((System.ComponentModel.ISupportInitialize) this.TabControlPage2).EndInit();
			//((System.ComponentModel.ISupportInitialize) this.TabControlPage1).EndInit();
			//((System.ComponentModel.ISupportInitialize) this.tabMaster).EndInit();
			//((System.ComponentModel.ISupportInitialize) this.CommandBars).EndInit();
			this.frameBottom.ResumeLayout(false);
			this.fraTransactionHeader.ResumeLayout(false);
			this.tabMaster.ResumeLayout(false);
			this.TabControlPage2.ResumeLayout(false);
			this.grdProductOut.ResumeLayout(false);
			this.cmbMastersListOut.ResumeLayout(false);
			this.TabControlPage1.ResumeLayout(false);
			this.grdProductIn.ResumeLayout(false);
			this.cmbMastersList.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		// 
		void InitializelblVoucherNo()
		{
			this.lblVoucherNo = new System.Windows.Forms.Label[2];
			this.lblVoucherNo[1] = _lblVoucherNo_1;
		}
		void InitializelblSourceVoucherType()
		{
			this.lblSourceVoucherType = new System.Windows.Forms.Label[2];
			this.lblSourceVoucherType[1] = _lblSourceVoucherType_1;
		}
		void InitializelblSource()
		{
			this.lblSource = new System.Windows.Forms.Label[2];
			this.lblSource[1] = _lblSource_1;
		}
		void InitializelblCommonLabel()
		{
			this.lblCommonLabel = new System.Windows.Forms.Label[10];
			this.lblCommonLabel[9] = _lblCommonLabel_9;
			this.lblCommonLabel[8] = _lblCommonLabel_8;
			this.lblCommonLabel[5] = _lblCommonLabel_5;
			this.lblCommonLabel[6] = _lblCommonLabel_6;
			this.lblCommonLabel[0] = _lblCommonLabel_0;
			this.lblCommonLabel[1] = _lblCommonLabel_1;
		}
		#endregion
	}
}//ENDSHERE
