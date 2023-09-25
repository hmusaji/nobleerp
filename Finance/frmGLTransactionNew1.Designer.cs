
namespace Xtreme
{
	partial class frmGLTransaction
	{

		#region "Upgrade Support "
		private static frmGLTransaction m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmGLTransaction DefInstance
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
		public static frmGLTransaction CreateInstance()
		{
			frmGLTransaction theInstance = new frmGLTransaction();
			
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
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "lblComments", "txtTotalDR", "txtTotalCR", "lblTotalCr", "lblTotalDr", "txtComments", "frmFooter", "Column_0_cmbMastersList", "Column_1_cmbMastersList", "cmbMastersList", "txtChequeNo", "lblChequeNo", "txtMaturityDate", "lblMaturityDate", "lblCashLedgerCode", "lblCashLedgerDetails", "cmbVoucherTypes", "txtVoucherNo", "lblVoucherNo", "lblVoucherDate", "txtVoucherDate", "txtReferenceNo", "txtCashLedgerCode", "lblReference", "lblVoucherType", "txtCashLedgerName", "lblCostCenterCode", "txtCostCenterCode", "txtCostCenterName", "lblFlex01", "txtFlex01", "lblBranchCode", "txtBranchCode", "txtBranchName", "Column_0_grdVoucherDetails", "Column_1_grdVoucherDetails", "grdVoucherDetails", "System.Windows.Forms.Label1", "CommandBars", "fraCashLedgerDetails"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public System.Windows.Forms.Label lblComments;
		public System.Windows.Forms.Label txtTotalDR;
		public System.Windows.Forms.Label txtTotalCR;
		public System.Windows.Forms.Label lblTotalCr;
		public System.Windows.Forms.Label lblTotalDr;
		public System.Windows.Forms.TextBox txtComments;
		public System.Windows.Forms.Panel frmFooter;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_0_cmbMastersList;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_1_cmbMastersList;
		public C1.Win.C1TrueDBGrid.C1TrueDBDropdown cmbMastersList;
		public System.Windows.Forms.TextBox txtChequeNo;
		public System.Windows.Forms.Label lblChequeNo;
		public Syncfusion.WinForms.Input.SfDateTimeEdit txtMaturityDate;
		public System.Windows.Forms.Label lblMaturityDate;
		public System.Windows.Forms.Label lblCashLedgerCode;
		public System.Windows.Forms.Label lblCashLedgerDetails;
		public System.Windows.Forms.ComboBox cmbVoucherTypes;
		public System.Windows.Forms.TextBox txtVoucherNo;
		public System.Windows.Forms.Label lblVoucherNo;
		public System.Windows.Forms.Label lblVoucherDate;
		public Syncfusion.WinForms.Input.SfDateTimeEdit txtVoucherDate;
		public System.Windows.Forms.TextBox txtReferenceNo;
		public System.Windows.Forms.TextBox txtCashLedgerCode;
		public System.Windows.Forms.Label lblReference;
		public System.Windows.Forms.Label lblVoucherType;
		public System.Windows.Forms.TextBox txtCashLedgerName;
		public System.Windows.Forms.Label lblCostCenterCode;
		public System.Windows.Forms.TextBox txtCostCenterCode;
		public System.Windows.Forms.TextBox txtCostCenterName;
		public System.Windows.Forms.Label lblFlex01;
		public System.Windows.Forms.TextBox txtFlex01;
		public System.Windows.Forms.Label lblBranchCode;
		public System.Windows.Forms.TextBox txtBranchCode;
		public System.Windows.Forms.TextBox txtBranchName;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_0_grdVoucherDetails;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_1_grdVoucherDetails;
		public C1.Win.C1TrueDBGrid.C1TrueDBGrid grdVoucherDetails;
		public System.Windows.Forms.Label Label1;
		public Syncfusion.Windows.Forms.Tools.CommandBarController CommandBars;
		public ShapeHelper fraCashLedgerDetails;
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGLTransaction));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this.frmFooter = new System.Windows.Forms.Panel();
			this.lblComments = new System.Windows.Forms.Label();
			this.txtTotalDR = new System.Windows.Forms.Label();
			this.txtTotalCR = new System.Windows.Forms.Label();
			this.lblTotalCr = new System.Windows.Forms.Label();
			this.lblTotalDr = new System.Windows.Forms.Label();
			this.txtComments = new System.Windows.Forms.TextBox();
			this.cmbMastersList = new C1.Win.C1TrueDBGrid.C1TrueDBDropdown();
			this.Column_0_cmbMastersList = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.Column_1_cmbMastersList = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.txtChequeNo = new System.Windows.Forms.TextBox();
			this.lblChequeNo = new System.Windows.Forms.Label();
			this.txtMaturityDate = new Syncfusion.WinForms.Input.SfDateTimeEdit();
			this.lblMaturityDate = new System.Windows.Forms.Label();
			this.lblCashLedgerCode = new System.Windows.Forms.Label();
			this.lblCashLedgerDetails = new System.Windows.Forms.Label();
			this.cmbVoucherTypes = new System.Windows.Forms.ComboBox();
			this.txtVoucherNo = new System.Windows.Forms.TextBox();
			this.lblVoucherNo = new System.Windows.Forms.Label();
			this.lblVoucherDate = new System.Windows.Forms.Label();
			this.txtVoucherDate = new Syncfusion.WinForms.Input.SfDateTimeEdit();
			this.txtReferenceNo = new System.Windows.Forms.TextBox();
			this.txtCashLedgerCode = new System.Windows.Forms.TextBox();
			this.lblReference = new System.Windows.Forms.Label();
			this.lblVoucherType = new System.Windows.Forms.Label();
			this.txtCashLedgerName = new System.Windows.Forms.TextBox();
			this.lblCostCenterCode = new System.Windows.Forms.Label();
			this.txtCostCenterCode = new System.Windows.Forms.TextBox();
			this.txtCostCenterName = new System.Windows.Forms.TextBox();
			this.lblFlex01 = new System.Windows.Forms.Label();
			this.txtFlex01 = new System.Windows.Forms.TextBox();
			this.lblBranchCode = new System.Windows.Forms.Label();
			this.txtBranchCode = new System.Windows.Forms.TextBox();
			this.txtBranchName = new System.Windows.Forms.TextBox();
			this.grdVoucherDetails = new C1.Win.C1TrueDBGrid.C1TrueDBGrid();
			this.Column_0_grdVoucherDetails = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.Column_1_grdVoucherDetails = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.Label1 = new System.Windows.Forms.Label();
			this.CommandBars = new Syncfusion.Windows.Forms.Tools.CommandBarController();
			this.fraCashLedgerDetails = new ShapeHelper();
			// //((System.ComponentModel.ISupportInitialize) this.frmFooter).BeginInit();
			// //((System.ComponentModel.ISupportInitialize) this.CommandBars).BeginInit();
			//this.frmFooter.SuspendLayout();
			//this.cmbMastersList.SuspendLayout();
			//this.grdVoucherDetails.SuspendLayout();
			this.SuspendLayout();
			// 
			// frmFooter
			// 
			this.frmFooter.AllowDrop = true;
			this.frmFooter.Controls.Add(this.lblComments);
			this.frmFooter.Controls.Add(this.txtTotalDR);
			this.frmFooter.Controls.Add(this.txtTotalCR);
			this.frmFooter.Controls.Add(this.lblTotalCr);
			this.frmFooter.Controls.Add(this.lblTotalDr);
			this.frmFooter.Controls.Add(this.txtComments);
			this.frmFooter.Location = new System.Drawing.Point(2, 448);
			this.frmFooter.Name = "frmFooter";
			//
			this.frmFooter.Size = new System.Drawing.Size(815, 65);
			this.frmFooter.TabIndex = 27;
			// 
			// lblComments
			// 
			this.lblComments.AllowDrop = true;
			this.lblComments.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblComments.Text = "Comments";
			this.lblComments.ForeColor = System.Drawing.Color.Black;
			this.lblComments.Location = new System.Drawing.Point(0, 12);
			// // this.lblComments.mLabelId = 135;
			this.lblComments.Name = "lblComments";
			this.lblComments.Size = new System.Drawing.Size(63, 16);
			this.lblComments.TabIndex = 28;
			// 
			// txtTotalDR
			// 
			this.txtTotalDR.AllowDrop = true;
			this.txtTotalDR.BackColor = System.Drawing.SystemColors.Window;
			this.txtTotalDR.Enabled = false;
			this.txtTotalDR.Location = new System.Drawing.Point(718, 6);
			this.txtTotalDR.Name = "txtTotalDR";
			this.txtTotalDR.Size = new System.Drawing.Size(93, 23);
			this.txtTotalDR.TabIndex = 29;
			// 
			// txtTotalCR
			// 
			this.txtTotalCR.AllowDrop = true;
			this.txtTotalCR.BackColor = System.Drawing.SystemColors.Window;
			this.txtTotalCR.Enabled = false;
			this.txtTotalCR.Location = new System.Drawing.Point(718, 32);
			this.txtTotalCR.Name = "txtTotalCR";
			this.txtTotalCR.Size = new System.Drawing.Size(93, 23);
			this.txtTotalCR.TabIndex = 30;
			// 
			// lblTotalCr
			// 
			this.lblTotalCr.AllowDrop = true;
			this.lblTotalCr.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblTotalCr.Text = "Total Cr.";
			this.lblTotalCr.ForeColor = System.Drawing.SystemColors.WindowText;
			this.lblTotalCr.Location = new System.Drawing.Point(666, 36);
			this.lblTotalCr.Name = "lblTotalCr";
			this.lblTotalCr.Size = new System.Drawing.Size(49, 16);
			this.lblTotalCr.TabIndex = 31;
			// 
			// lblTotalDr
			// 
			this.lblTotalDr.AllowDrop = true;
			this.lblTotalDr.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblTotalDr.Text = "Total Dr.";
			this.lblTotalDr.ForeColor = System.Drawing.Color.Black;
			this.lblTotalDr.Location = new System.Drawing.Point(666, 10);
			this.lblTotalDr.Name = "lblTotalDr";
			this.lblTotalDr.Size = new System.Drawing.Size(49, 16);
			this.lblTotalDr.TabIndex = 32;
			// 
			// txtComments
			// 
			this.txtComments.AllowDrop = true;
			this.txtComments.BackColor = System.Drawing.Color.White;
			// // = false;
			this.txtComments.ForeColor = System.Drawing.Color.Black;
			this.txtComments.Location = new System.Drawing.Point(66, 4);
			// // = (System.Windows.Forms.TextBox.FormatBoxDropDownTypes) 0;
			this.txtComments.Name = "txtComments";
			this.txtComments.Size = new System.Drawing.Size(513, 55);
			this.txtComments.TabIndex = 33;
			this.txtComments.Text = "";
			// 
			// cmbMastersList
			// 
			this.cmbMastersList.AllowDrop = true;
			this.cmbMastersList.ColumnHeaders = true;
			this.cmbMastersList.Enabled = true;
			this.cmbMastersList.Location = new System.Drawing.Point(132, 254);
			this.cmbMastersList.Name = "cmbMastersList";
			this.cmbMastersList.Size = new System.Drawing.Size(333, 133);
			this.cmbMastersList.TabIndex = 11;
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
			// txtChequeNo
			// 
			this.txtChequeNo.AllowDrop = true;
			this.txtChequeNo.BackColor = System.Drawing.Color.White;
			// // = false;
			this.txtChequeNo.ForeColor = System.Drawing.Color.Black;
			this.txtChequeNo.Location = new System.Drawing.Point(695, 116);
			// // = (System.Windows.Forms.TextBox.DropDownTypes) 0;
			this.txtChequeNo.Name = "txtChequeNo";
			this.txtChequeNo.Size = new System.Drawing.Size(101, 23);
			this.txtChequeNo.TabIndex = 9;
			this.txtChequeNo.Text = "";
			this.txtChequeNo.Visible = false;
			// this.// = "";
			// 
			// lblChequeNo
			// 
			this.lblChequeNo.AllowDrop = true;
			this.lblChequeNo.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblChequeNo.Text = "Cheque No";
			this.lblChequeNo.ForeColor = System.Drawing.Color.Black;
			this.lblChequeNo.Location = new System.Drawing.Point(620, 119);
			// // this.lblChequeNo.mLabelId = 1852;
			this.lblChequeNo.Name = "lblChequeNo";
			this.lblChequeNo.Size = new System.Drawing.Size(64, 16);
			this.lblChequeNo.TabIndex = 12;
			this.lblChequeNo.Visible = false;
			// 
			// txtMaturityDate
			// 
			this.txtMaturityDate.AllowDrop = true;
			// this.txtMaturityDate.CheckDateRange = false;
			this.txtMaturityDate.Location = new System.Drawing.Point(494, 116);
			// this.txtMaturityDate.MaxDate = 2958465;
			// this.txtMaturityDate.MinDate = 2;
			this.txtMaturityDate.Name = "txtMaturityDate";
			this.txtMaturityDate.Size = new System.Drawing.Size(101, 23);
			this.txtMaturityDate.TabIndex = 8;
			// this.txtMaturityDate.Text = "05/Jun/2005";
			// this.txtMaturityDate.Value = 38508;
			this.txtMaturityDate.Visible = false;
			// 
			// lblMaturityDate
			// 
			this.lblMaturityDate.AllowDrop = true;
			this.lblMaturityDate.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			// this.lblMaturityDate.Text = "Maturity Date";
			this.lblMaturityDate.ForeColor = System.Drawing.Color.Black;
			this.lblMaturityDate.Location = new System.Drawing.Point(386, 118);
			// // this.lblMaturityDate.mLabelId = 1855;
			this.lblMaturityDate.Name = "lblMaturityDate";
			this.lblMaturityDate.Size = new System.Drawing.Size(78, 16);
			this.lblMaturityDate.TabIndex = 13;
			this.lblMaturityDate.Visible = false;
			// 
			// lblCashLedgerCode
			// 
			this.lblCashLedgerCode.AllowDrop = true;
			this.lblCashLedgerCode.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblCashLedgerCode.Text = "Cash / Bank Code";
			this.lblCashLedgerCode.ForeColor = System.Drawing.Color.Black;
			this.lblCashLedgerCode.Location = new System.Drawing.Point(384, 67);
			// // this.lblCashLedgerCode.mLabelId = 932;
			this.lblCashLedgerCode.Name = "lblCashLedgerCode";
			this.lblCashLedgerCode.Size = new System.Drawing.Size(101, 16);
			this.lblCashLedgerCode.TabIndex = 14;
			// 
			// lblCashLedgerDetails
			// 
			this.lblCashLedgerDetails.AllowDrop = true;
			this.lblCashLedgerDetails.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblCashLedgerDetails.Text = " Cash / Bank Details ";
			this.lblCashLedgerDetails.ForeColor = System.Drawing.Color.Black;
			this.lblCashLedgerDetails.Location = new System.Drawing.Point(394, 42);
			// // this.lblCashLedgerDetails.mLabelId = 931;
			this.lblCashLedgerDetails.Name = "lblCashLedgerDetails";
			this.lblCashLedgerDetails.Size = new System.Drawing.Size(118, 16);
			this.lblCashLedgerDetails.TabIndex = 15;
			// 
			// cmbVoucherTypes
			// 
			this.cmbVoucherTypes.AllowDrop = true;
			this.cmbVoucherTypes.Location = new System.Drawing.Point(97, 16);
			this.cmbVoucherTypes.Name = "cmbVoucherTypes";
			this.cmbVoucherTypes.Size = new System.Drawing.Size(232, 21);
			this.cmbVoucherTypes.TabIndex = 0;
			// this.cmbVoucherTypes.Click += new System.Windows.Forms.ComboBox.ClickHandler(this.cmbVoucherTypes_Click);
			// 
			// txtVoucherNo
			// 
			this.txtVoucherNo.AllowDrop = true;
			this.txtVoucherNo.BackColor = System.Drawing.Color.FromArgb(239, 239, 239);
			// this.txtVoucherNo.bolNumericOnly = true;
			this.txtVoucherNo.Enabled = false;
			this.txtVoucherNo.ForeColor = System.Drawing.Color.Black;
			this.txtVoucherNo.Location = new System.Drawing.Point(97, 61);
			this.txtVoucherNo.MaxLength = 14;
			this.txtVoucherNo.Name = "txtVoucherNo";
			this.txtVoucherNo.Size = new System.Drawing.Size(102, 23);
			this.txtVoucherNo.TabIndex = 2;
			this.txtVoucherNo.Text = "";
			// this.// = "";
			// 
			// lblVoucherNo
			// 
			this.lblVoucherNo.AllowDrop = true;
			this.lblVoucherNo.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblVoucherNo.Text = "Voucher No.";
			this.lblVoucherNo.ForeColor = System.Drawing.Color.Black;
			this.lblVoucherNo.Location = new System.Drawing.Point(8, 65);
			// // this.lblVoucherNo.mLabelId = 850;
			this.lblVoucherNo.Name = "lblVoucherNo";
			this.lblVoucherNo.Size = new System.Drawing.Size(72, 16);
			this.lblVoucherNo.TabIndex = 16;
			// 
			// lblVoucherDate
			// 
			this.lblVoucherDate.AllowDrop = true;
			this.lblVoucherDate.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			// this.lblVoucherDate.Text = "Voucher Date";
			this.lblVoucherDate.ForeColor = System.Drawing.Color.Black;
			this.lblVoucherDate.Location = new System.Drawing.Point(8, 92);
			// // this.lblVoucherDate.mLabelId = 848;
			this.lblVoucherDate.Name = "lblVoucherDate";
			this.lblVoucherDate.Size = new System.Drawing.Size(79, 16);
			this.lblVoucherDate.TabIndex = 17;
			// 
			// txtVoucherDate
			// 
			this.txtVoucherDate.AllowDrop = true;
			// this.txtVoucherDate.CheckDateRange = false;
			this.txtVoucherDate.Location = new System.Drawing.Point(97, 90);
			// this.txtVoucherDate.MaxDate = 2958465;
			// this.txtVoucherDate.MinDate = 32874;
			this.txtVoucherDate.Name = "txtVoucherDate";
			this.txtVoucherDate.Size = new System.Drawing.Size(102, 23);
			this.txtVoucherDate.TabIndex = 3;
			// this.txtVoucherDate.Text = "18/Jul/2001";
			// this.txtVoucherDate.Value = 37090;
			// this.this.txtVoucherDate.Change += new Syncfusion.WinForms.Input.SfDateTimeEdit.ChangeHandler(this.txtVoucherDate_Change);
			this.txtVoucherDate.Validating += new System.ComponentModel.CancelEventHandler(this.txtVoucherDate_Validating);
			// 
			// txtReferenceNo
			// 
			this.txtReferenceNo.AllowDrop = true;
			this.txtReferenceNo.BackColor = System.Drawing.Color.White;
			this.txtReferenceNo.ForeColor = System.Drawing.Color.Black;
			this.txtReferenceNo.Location = new System.Drawing.Point(97, 117);
			this.txtReferenceNo.MaxLength = 20;
			this.txtReferenceNo.Name = "txtReferenceNo";
			this.txtReferenceNo.Size = new System.Drawing.Size(102, 23);
			this.txtReferenceNo.TabIndex = 4;
			this.txtReferenceNo.Text = "";
			// this.// = "";
			// 
			// txtCashLedgerCode
			// 
			this.txtCashLedgerCode.AllowDrop = true;
			this.txtCashLedgerCode.BackColor = System.Drawing.Color.White;
			this.txtCashLedgerCode.ForeColor = System.Drawing.Color.Black;
			this.txtCashLedgerCode.Location = new System.Drawing.Point(494, 62);
			this.txtCashLedgerCode.Name = "txtCashLedgerCode";
			// this.txtCashLedgerCode.ShowButton = true;
			this.txtCashLedgerCode.Size = new System.Drawing.Size(101, 23);
			this.txtCashLedgerCode.TabIndex = 6;
			this.txtCashLedgerCode.Text = "";
			// this.// = "";
			// this.//this.txtCashLedgerCode.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(//this.txtCashLedgerCode_DropButtonClick);
			// this.txtCashLedgerCode.Leave += new System.EventHandler(this.txtCashLedgerCode_Leave);
			// 
			// lblReference
			// 
			this.lblReference.AllowDrop = true;
			this.lblReference.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblReference.Text = "Reference No.";
			this.lblReference.ForeColor = System.Drawing.Color.Black;
			this.lblReference.Location = new System.Drawing.Point(8, 119);
			// // this.lblReference.mLabelId = 614;
			this.lblReference.Name = "lblReference";
			this.lblReference.Size = new System.Drawing.Size(82, 16);
			this.lblReference.TabIndex = 18;
			// 
			// lblVoucherType
			// 
			this.lblVoucherType.AllowDrop = true;
			this.lblVoucherType.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblVoucherType.Text = "Voucher Type";
			this.lblVoucherType.ForeColor = System.Drawing.Color.Black;
			this.lblVoucherType.Location = new System.Drawing.Point(8, 19);
			// // this.lblVoucherType.mLabelId = 851;
			this.lblVoucherType.Name = "lblVoucherType";
			this.lblVoucherType.Size = new System.Drawing.Size(80, 16);
			this.lblVoucherType.TabIndex = 19;
			// 
			// txtCashLedgerName
			// 
			this.txtCashLedgerName.AllowDrop = true;
			this.txtCashLedgerName.BackColor = System.Drawing.Color.FromArgb(239, 239, 239);
			this.txtCashLedgerName.Enabled = false;
			this.txtCashLedgerName.ForeColor = System.Drawing.Color.Black;
			this.txtCashLedgerName.Location = new System.Drawing.Point(597, 62);
			this.txtCashLedgerName.Name = "txtCashLedgerName";
			this.txtCashLedgerName.Size = new System.Drawing.Size(201, 23);
			this.txtCashLedgerName.TabIndex = 20;
			this.txtCashLedgerName.Text = "";
			// this.// = "";
			// 
			// lblCostCenterCode
			// 
			this.lblCostCenterCode.AllowDrop = true;
			this.lblCostCenterCode.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblCostCenterCode.Text = "Cost Center Code";
			this.lblCostCenterCode.ForeColor = System.Drawing.Color.Black;
			this.lblCostCenterCode.Location = new System.Drawing.Point(384, 94);
			// // this.lblCostCenterCode.mLabelId = 968;
			this.lblCostCenterCode.Name = "lblCostCenterCode";
			this.lblCostCenterCode.Size = new System.Drawing.Size(100, 16);
			this.lblCostCenterCode.TabIndex = 21;
			// 
			// txtCostCenterCode
			// 
			this.txtCostCenterCode.AllowDrop = true;
			this.txtCostCenterCode.BackColor = System.Drawing.Color.White;
			// this.txtCostCenterCode.bolNumericOnly = true;
			this.txtCostCenterCode.ForeColor = System.Drawing.Color.Black;
			this.txtCostCenterCode.Location = new System.Drawing.Point(494, 89);
			this.txtCostCenterCode.Name = "txtCostCenterCode";
			// this.txtCostCenterCode.ShowButton = true;
			this.txtCostCenterCode.Size = new System.Drawing.Size(101, 23);
			this.txtCostCenterCode.TabIndex = 7;
			this.txtCostCenterCode.Text = "";
			// this.// = "";
			// this.//this.txtCostCenterCode.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(//this.txtCostCenterCode_DropButtonClick);
			// this.txtCostCenterCode.Leave += new System.EventHandler(this.txtCostCenterCode_Leave);
			// 
			// txtCostCenterName
			// 
			this.txtCostCenterName.AllowDrop = true;
			this.txtCostCenterName.BackColor = System.Drawing.Color.FromArgb(239, 239, 239);
			this.txtCostCenterName.Enabled = false;
			this.txtCostCenterName.ForeColor = System.Drawing.Color.Black;
			this.txtCostCenterName.Location = new System.Drawing.Point(597, 89);
			this.txtCostCenterName.Name = "txtCostCenterName";
			this.txtCostCenterName.Size = new System.Drawing.Size(201, 23);
			this.txtCostCenterName.TabIndex = 22;
			this.txtCostCenterName.Text = "";
			// this.// = "";
			// 
			// lblFlex01
			// 
			this.lblFlex01.AllowDrop = true;
			this.lblFlex01.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblFlex01.Text = "Beneficiary";
			this.lblFlex01.ForeColor = System.Drawing.Color.Black;
			this.lblFlex01.Location = new System.Drawing.Point(8, 154);
			// // this.lblFlex01.mLabelId = 1938;
			this.lblFlex01.Name = "lblFlex01";
			this.lblFlex01.Size = new System.Drawing.Size(64, 16);
			this.lblFlex01.TabIndex = 23;
			// 
			// txtFlex01
			// 
			this.txtFlex01.AllowDrop = true;
			this.txtFlex01.BackColor = System.Drawing.Color.White;
			this.txtFlex01.ForeColor = System.Drawing.Color.Black;
			this.txtFlex01.Location = new System.Drawing.Point(97, 152);
			this.txtFlex01.MaxLength = 240;
			this.txtFlex01.Name = "txtFlex01";
			// this.txtFlex01.ShowButton = true;
			this.txtFlex01.Size = new System.Drawing.Size(559, 23);
			this.txtFlex01.TabIndex = 5;
			this.txtFlex01.Text = "";
			// this.// = "";
			// this.//this.txtFlex01.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(//this.txtFlex01_DropButtonClick);
			// 
			// lblBranchCode
			// 
			this.lblBranchCode.AllowDrop = true;
			this.lblBranchCode.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblBranchCode.Text = "Branch Code";
			this.lblBranchCode.ForeColor = System.Drawing.Color.Black;
			this.lblBranchCode.Location = new System.Drawing.Point(384, 19);
			this.lblBranchCode.Name = "lblBranchCode";
			this.lblBranchCode.Size = new System.Drawing.Size(72, 16);
			this.lblBranchCode.TabIndex = 24;
			// 
			// txtBranchCode
			// 
			this.txtBranchCode.AllowDrop = true;
			this.txtBranchCode.BackColor = System.Drawing.Color.White;
			this.txtBranchCode.ForeColor = System.Drawing.Color.Black;
			this.txtBranchCode.Location = new System.Drawing.Point(495, 16);
			this.txtBranchCode.Name = "txtBranchCode";
			// this.txtBranchCode.ShowButton = true;
			this.txtBranchCode.Size = new System.Drawing.Size(101, 23);
			this.txtBranchCode.TabIndex = 1;
			this.txtBranchCode.Text = "";
			// this.// = "";
			// this.//this.txtBranchCode.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(//this.txtBranchCode_DropButtonClick);
			// this.txtBranchCode.Leave += new System.EventHandler(this.txtBranchCode_Leave);
			// 
			// txtBranchName
			// 
			this.txtBranchName.AllowDrop = true;
			this.txtBranchName.BackColor = System.Drawing.Color.FromArgb(239, 239, 239);
			this.txtBranchName.Enabled = false;
			this.txtBranchName.ForeColor = System.Drawing.Color.Black;
			this.txtBranchName.Location = new System.Drawing.Point(598, 16);
			this.txtBranchName.Name = "txtBranchName";
			this.txtBranchName.Size = new System.Drawing.Size(201, 23);
			this.txtBranchName.TabIndex = 25;
			this.txtBranchName.Text = "";
			// this.// = "";
			// 
			// grdVoucherDetails
			// 
			this.grdVoucherDetails.AllowDrop = true;
			this.grdVoucherDetails.BackColor = System.Drawing.Color.FromArgb(236, 233, 216);
			this.grdVoucherDetails.CellTipsWidth = 0;
			this.grdVoucherDetails.Location = new System.Drawing.Point(0, 184);
			this.grdVoucherDetails.Name = "grdVoucherDetails";
			this.grdVoucherDetails.RowDivider.Color = System.Drawing.Color.FromArgb(212, 208, 200);
			this.grdVoucherDetails.Size = new System.Drawing.Size(818, 247);
			this.grdVoucherDetails.TabIndex = 10;
			this.grdVoucherDetails.Columns.Add(this.Column_0_grdVoucherDetails);
			this.grdVoucherDetails.Columns.Add(this.Column_1_grdVoucherDetails);
			this.grdVoucherDetails.AfterColUpdate += new C1.Win.C1TrueDBGrid.ColEventHandler(this.grdVoucherDetails_AfterColUpdate);
			this.grdVoucherDetails.BeforeColEdit += new C1.Win.C1TrueDBGrid.BeforeColEditEventHandler(this.grdVoucherDetails_BeforeColEdit);
			this.grdVoucherDetails.BeforeColUpdate += new C1.Win.C1TrueDBGrid.BeforeColUpdateEventHandler(this.grdVoucherDetails_BeforeColUpdate);
			this.grdVoucherDetails.ButtonClick += new C1.Win.C1TrueDBGrid.ColEventHandler(this.grdVoucherDetails_ButtonClick);
			this.grdVoucherDetails.GotFocus += new System.EventHandler(this.grdVoucherDetails_GotFocus);
			// this.this.grdVoucherDetails.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.grdVoucherDetails_KeyPress);
			// this.grdVoucherDetails.Leave += new System.EventHandler(this.grdVoucherDetails_Leave);
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
			// System.Windows.Forms.Label1
			// 
			this.Label1.AllowDrop = true;
			this.Label1.BackColor = System.Drawing.SystemColors.Window;
			this.Label1.Text = "T";
			this.Label1.ForeColor = System.Drawing.Color.Black;
			this.Label1.Location = new System.Drawing.Point(602, 416);
			this.Label1.Name="Label1";
			this.Label1.Size = new System.Drawing.Size(6, 13);
			this.Label1.TabIndex = 26;
			// 
			// CommandBars
			// 
			this.CommandBars.AllowDrop = true;
			this.CommandBars.Location = new System.Drawing.Point(838, 16);
			this.CommandBars.Name = "CommandBars";
			//
			// 
			// fraCashLedgerDetails
			// 
			this.fraCashLedgerDetails.AllowDrop = true;
			this.fraCashLedgerDetails.BackColor = System.Drawing.SystemColors.Window;
			// = 0;
			this.fraCashLedgerDetails.BorderColor = System.Drawing.Color.FromArgb(64, 64, 64);
			this.fraCashLedgerDetails.BorderStyle = 1;
			this.fraCashLedgerDetails.Enabled = false;
			this.fraCashLedgerDetails.FillColor = System.Drawing.Color.Black;
			this.fraCashLedgerDetails.FillStyle = 1;
			this.fraCashLedgerDetails.Location = new System.Drawing.Point(370, 49);
			this.fraCashLedgerDetails.Name = "fraCashLedgerDetails";
			this.fraCashLedgerDetails.Size = new System.Drawing.Size(441, 96);
			this.fraCashLedgerDetails.Visible = true;
			// 
			// frmGLTransaction
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.ClientSize = new System.Drawing.Size(1333, 703);
			this.Controls.Add(this.frmFooter);
			this.Controls.Add(this.cmbMastersList);
			this.Controls.Add(this.txtChequeNo);
			this.Controls.Add(this.lblChequeNo);
			this.Controls.Add(this.txtMaturityDate);
			this.Controls.Add(this.lblMaturityDate);
			this.Controls.Add(this.lblCashLedgerCode);
			this.Controls.Add(this.lblCashLedgerDetails);
			this.Controls.Add(this.cmbVoucherTypes);
			this.Controls.Add(this.txtVoucherNo);
			this.Controls.Add(this.lblVoucherNo);
			this.Controls.Add(this.lblVoucherDate);
			this.Controls.Add(this.txtVoucherDate);
			this.Controls.Add(this.txtReferenceNo);
			this.Controls.Add(this.txtCashLedgerCode);
			this.Controls.Add(this.lblReference);
			this.Controls.Add(this.lblVoucherType);
			this.Controls.Add(this.txtCashLedgerName);
			this.Controls.Add(this.lblCostCenterCode);
			this.Controls.Add(this.txtCostCenterCode);
			this.Controls.Add(this.txtCostCenterName);
			this.Controls.Add(this.lblFlex01);
			this.Controls.Add(this.txtFlex01);
			this.Controls.Add(this.lblBranchCode);
			this.Controls.Add(this.txtBranchCode);
			this.Controls.Add(this.txtBranchName);
			this.Controls.Add(this.grdVoucherDetails);
			this.Controls.Add(this.Label1);
			this.Controls.Add(this.CommandBars);
			this.Controls.Add(this.fraCashLedgerDetails);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			//this.Icon = (System.Drawing.Icon) resources.GetObject("frmGLTransaction.Icon");
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(175, 96);
			this.MaximizeBox = true;
			this.MinimizeBox = true;
			this.Name = "frmGLTransaction";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Tag = "\"H: 6135  W:9570\"";
			this.Text = "Voucher Entry";
			// this.Activated += new System.EventHandler(this.Form_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
			// this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
			//this.Resize += new System.EventHandler(this.Form_Resize);
			//((System.ComponentModel.ISupportInitialize) this.frmFooter).EndInit();
			//((System.ComponentModel.ISupportInitialize) this.CommandBars).EndInit();
			this.frmFooter.ResumeLayout(false);
			this.cmbMastersList.ResumeLayout(false);
			this.grdVoucherDetails.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		// 
		#endregion
	}
}//ENDSHERE
