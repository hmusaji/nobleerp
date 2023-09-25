
namespace Xtreme
{
	partial class frmGLAccountReconcilation
	{

		#region "Upgrade Support "
		private static frmGLAccountReconcilation m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmGLAccountReconcilation DefInstance
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
		public static frmGLAccountReconcilation CreateInstance()
		{
			frmGLAccountReconcilation theInstance = new frmGLAccountReconcilation();
			
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
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "chkShowReconciled", "txtLdgrName", "txtLdgrNo", "lblLedgerNo", "_lblCommonLabel_6", "txtVoucherDate", "Column_0_grdVoucherDetails", "Column_1_grdVoucherDetails", "grdVoucherDetails", "_lblReconcile_0", "_lblReconcile_7", "_lblReconcile_3", "_lblReconcile_2", "_lblReconcile_11", "_lblReconcile_16", "txtUnreconciledDebitAmount", "_lblReconcile_17", "txtAccountReconcilationDiff", "_lblReconcile_1", "_lblReconcile_4", "_lblReconcile_5", "txtGLSystemBalance", "txtUnreconciledCreditAmount", "_lblReconcile_15", "txtStatementEndingBalance", "_dcReconcile_3", "_dcReconcile_9", "_dcReconcile_8", "_dcReconcile_7", "_dcReconcile_6", "_dcReconcile_2", "_dcReconcile_5", "_dcReconcile_4", "_dcReconcile_1", "lblComments", "txtComments", "Line", "Line1", "dcReconcile", "lblCommonLabel", "lblReconcile"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public System.Windows.Forms.CheckBox chkShowReconciled;
		public System.Windows.Forms.TextBox txtLdgrName;
		public System.Windows.Forms.TextBox txtLdgrNo;
		public System.Windows.Forms.Label lblLedgerNo;
		private System.Windows.Forms.Label _lblCommonLabel_6;
		public Syncfusion.WinForms.Input.SfDateTimeEdit txtVoucherDate;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_0_grdVoucherDetails;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_1_grdVoucherDetails;
		public C1.Win.C1TrueDBGrid.C1TrueDBGrid grdVoucherDetails;
		private System.Windows.Forms.Label _lblReconcile_0;
		private System.Windows.Forms.Label _lblReconcile_7;
		private System.Windows.Forms.Label _lblReconcile_3;
		private System.Windows.Forms.Label _lblReconcile_2;
		private System.Windows.Forms.Label _lblReconcile_11;
		private System.Windows.Forms.Label _lblReconcile_16;
		public System.Windows.Forms.TextBox txtUnreconciledDebitAmount;
		private System.Windows.Forms.Label _lblReconcile_17;
		public System.Windows.Forms.TextBox txtAccountReconcilationDiff;
		private System.Windows.Forms.Label _lblReconcile_1;
		private System.Windows.Forms.Label _lblReconcile_4;
		private System.Windows.Forms.Label _lblReconcile_5;
		public System.Windows.Forms.TextBox txtGLSystemBalance;
		public System.Windows.Forms.TextBox txtUnreconciledCreditAmount;
		private System.Windows.Forms.Label _lblReconcile_15;
		public System.Windows.Forms.TextBox txtStatementEndingBalance;
		private System.Windows.Forms.Label _dcReconcile_3;
		private System.Windows.Forms.Label _dcReconcile_9;
		private System.Windows.Forms.Label _dcReconcile_8;
		private System.Windows.Forms.Label _dcReconcile_7;
		private System.Windows.Forms.Label _dcReconcile_6;
		private System.Windows.Forms.Label _dcReconcile_2;
		private System.Windows.Forms.Label _dcReconcile_5;
		private System.Windows.Forms.Label _dcReconcile_4;
		private System.Windows.Forms.Label _dcReconcile_1;
		public System.Windows.Forms.Label lblComments;
		public System.Windows.Forms.TextBox txtComments;
		public System.Windows.Forms.Label Line;
		public System.Windows.Forms.Label Line1;
		public System.Windows.Forms.Label[] dcReconcile = new System.Windows.Forms.Label[10];
		public System.Windows.Forms.Label[] lblCommonLabel = new System.Windows.Forms.Label[7];
		public System.Windows.Forms.Label[] lblReconcile = new System.Windows.Forms.Label[18];
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGLAccountReconcilation));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this.chkShowReconciled = new System.Windows.Forms.CheckBox();
			this.txtLdgrName = new System.Windows.Forms.TextBox();
			this.txtLdgrNo = new System.Windows.Forms.TextBox();
			this.lblLedgerNo = new System.Windows.Forms.Label();
			this._lblCommonLabel_6 = new System.Windows.Forms.Label();
			this.txtVoucherDate = new Syncfusion.WinForms.Input.SfDateTimeEdit();
			this.grdVoucherDetails = new C1.Win.C1TrueDBGrid.C1TrueDBGrid();
			this.Column_0_grdVoucherDetails = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.Column_1_grdVoucherDetails = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this._lblReconcile_0 = new System.Windows.Forms.Label();
			this._lblReconcile_7 = new System.Windows.Forms.Label();
			this._lblReconcile_3 = new System.Windows.Forms.Label();
			this._lblReconcile_2 = new System.Windows.Forms.Label();
			this._lblReconcile_11 = new System.Windows.Forms.Label();
			this._lblReconcile_16 = new System.Windows.Forms.Label();
			this.txtUnreconciledDebitAmount = new System.Windows.Forms.TextBox();
			this._lblReconcile_17 = new System.Windows.Forms.Label();
			this.txtAccountReconcilationDiff = new System.Windows.Forms.TextBox();
			this._lblReconcile_1 = new System.Windows.Forms.Label();
			this._lblReconcile_4 = new System.Windows.Forms.Label();
			this._lblReconcile_5 = new System.Windows.Forms.Label();
			this.txtGLSystemBalance = new System.Windows.Forms.TextBox();
			this.txtUnreconciledCreditAmount = new System.Windows.Forms.TextBox();
			this._lblReconcile_15 = new System.Windows.Forms.Label();
			this.txtStatementEndingBalance = new System.Windows.Forms.TextBox();
			this._dcReconcile_3 = new System.Windows.Forms.Label();
			this._dcReconcile_9 = new System.Windows.Forms.Label();
			this._dcReconcile_8 = new System.Windows.Forms.Label();
			this._dcReconcile_7 = new System.Windows.Forms.Label();
			this._dcReconcile_6 = new System.Windows.Forms.Label();
			this._dcReconcile_2 = new System.Windows.Forms.Label();
			this._dcReconcile_5 = new System.Windows.Forms.Label();
			this._dcReconcile_4 = new System.Windows.Forms.Label();
			this._dcReconcile_1 = new System.Windows.Forms.Label();
			this.lblComments = new System.Windows.Forms.Label();
			this.txtComments = new System.Windows.Forms.TextBox();
			this.Line = new System.Windows.Forms.Label();
			this.Line1 = new System.Windows.Forms.Label();
			this.grdVoucherDetails.SuspendLayout();
			this.SuspendLayout();
			// 
			// chkShowReconciled
			// 
			this.chkShowReconciled.AllowDrop = true;
			this.chkShowReconciled.Appearance = System.Windows.Forms.Appearance.Normal;
			this.chkShowReconciled.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.chkShowReconciled.CausesValidation = true;
			this.chkShowReconciled.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkShowReconciled.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this.chkShowReconciled.Enabled = true;
			this.chkShowReconciled.ForeColor = System.Drawing.Color.Black;
			this.chkShowReconciled.Location = new System.Drawing.Point(14, 499);
			this.chkShowReconciled.Name = "chkShowReconciled";
			this.chkShowReconciled.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.chkShowReconciled.Size = new System.Drawing.Size(187, 16);
			this.chkShowReconciled.TabIndex = 5;
			this.chkShowReconciled.TabStop = true;
			this.chkShowReconciled.Text = "Show all Transactions";
			this.chkShowReconciled.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkShowReconciled.Visible = true;
			this.chkShowReconciled.CheckStateChanged += new System.EventHandler(this.chkShowReconciled_CheckStateChanged);
			// 
			// txtLdgrName
			// 
			this.txtLdgrName.AllowDrop = true;
			this.txtLdgrName.BackColor = System.Drawing.Color.FromArgb(239, 239, 239);
			this.txtLdgrName.Enabled = false;
			this.txtLdgrName.ForeColor = System.Drawing.Color.Black;
			this.txtLdgrName.Location = new System.Drawing.Point(188, 58);
			this.txtLdgrName.Name = "txtLdgrName";
			this.txtLdgrName.Size = new System.Drawing.Size(201, 19);
			this.txtLdgrName.TabIndex = 2;
			this.txtLdgrName.Text = "";
			// this.this.txtLdgrName.Watermark = "";
			// 
			// txtLdgrNo
			// 
			this.txtLdgrNo.AllowDrop = true;
			this.txtLdgrNo.BackColor = System.Drawing.Color.White;
			this.txtLdgrNo.ForeColor = System.Drawing.Color.Black;
			this.txtLdgrNo.Location = new System.Drawing.Point(84, 58);
			this.txtLdgrNo.Name = "txtLdgrNo";
			// this.txtLdgrNo.ShowButton = true;
			this.txtLdgrNo.Size = new System.Drawing.Size(101, 19);
			this.txtLdgrNo.TabIndex = 0;
			this.txtLdgrNo.Text = "";
			// this.this.txtLdgrNo.Watermark = "";
			// this.this.txtLdgrNo.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtLdgrNo_DropButtonClick);
			// this.txtLdgrNo.Leave += new System.EventHandler(this.txtLdgrNo_Leave);
			// 
			// lblLedgerNo
			// 
			this.lblLedgerNo.AllowDrop = true;
			this.lblLedgerNo.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblLedgerNo.Text = "Ledger Code";
			this.lblLedgerNo.ForeColor = System.Drawing.Color.Black;
			this.lblLedgerNo.Location = new System.Drawing.Point(12, 60);
			// this.lblLedgerNo.mLabelId = 1857;
			this.lblLedgerNo.Name = "lblLedgerNo";
			this.lblLedgerNo.Size = new System.Drawing.Size(62, 14);
			this.lblLedgerNo.TabIndex = 3;
			// 
			// _lblCommonLabel_6
			// 
			this._lblCommonLabel_6.AllowDrop = true;
			this._lblCommonLabel_6.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_6.Text = "Statement Date";
			this._lblCommonLabel_6.ForeColor = System.Drawing.Color.Black;
			this._lblCommonLabel_6.Location = new System.Drawing.Point(536, 60);
			// this._lblCommonLabel_6.mLabelId = 1858;
			this._lblCommonLabel_6.Name = "_lblCommonLabel_6";
			this._lblCommonLabel_6.Size = new System.Drawing.Size(73, 14);
			this._lblCommonLabel_6.TabIndex = 4;
			// 
			// txtVoucherDate
			// 
			this.txtVoucherDate.AllowDrop = true;
			// this.txtVoucherDate.CheckDateRange = false;
			this.txtVoucherDate.Location = new System.Drawing.Point(616, 58);
			// this.txtVoucherDate.MaxDate = 2958465;
			// this.txtVoucherDate.MinDate = 32874;
			this.txtVoucherDate.Name = "txtVoucherDate";
			this.txtVoucherDate.Size = new System.Drawing.Size(102, 19);
			this.txtVoucherDate.TabIndex = 1;
			this.txtVoucherDate.Text = "18-Jul-2001";
			this.txtVoucherDate.Value = 37090;
			// 
			// grdVoucherDetails
			// 
			this.grdVoucherDetails.AllowDrop = true;
			this.grdVoucherDetails.BackColor = System.Drawing.Color.FromArgb(212, 208, 200);
			this.grdVoucherDetails.CellTipsWidth = 0;
			this.grdVoucherDetails.Location = new System.Drawing.Point(8, 216);
			this.grdVoucherDetails.Name = "grdVoucherDetails";
			this.grdVoucherDetails.RowDivider.Color = System.Drawing.Color.FromArgb(212, 208, 200);
			this.grdVoucherDetails.Size = new System.Drawing.Size(1035, 272);
			this.grdVoucherDetails.TabIndex = 6;
			this.grdVoucherDetails.Columns.Add(this.Column_0_grdVoucherDetails);
			this.grdVoucherDetails.Columns.Add(this.Column_1_grdVoucherDetails);
			this.grdVoucherDetails.AfterColUpdate += new C1.Win.C1TrueDBGrid.ColEventHandler(this.grdVoucherDetails_AfterColUpdate);
			this.grdVoucherDetails.BeforeColEdit += new C1.Win.C1TrueDBGrid.BeforeColEditEventHandler(this.grdVoucherDetails_BeforeColEdit);
			this.grdVoucherDetails.BeforeColUpdate += new C1.Win.C1TrueDBGrid.BeforeColUpdateEventHandler(this.grdVoucherDetails_BeforeColUpdate);
			this.grdVoucherDetails.GotFocus += new System.EventHandler(this.grdVoucherDetails_GotFocus);
			// this.this.grdVoucherDetails.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.grdVoucherDetails_KeyPress);
			this.grdVoucherDetails.MouseUp += new System.Windows.Forms.MouseEventHandler(this.grdVoucherDetails_MouseUp);
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
			// _lblReconcile_0
			// 
			this._lblReconcile_0.AllowDrop = true;
			this._lblReconcile_0.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblReconcile_0.Text = "Debit";
			this._lblReconcile_0.ForeColor = System.Drawing.Color.Black;
			this._lblReconcile_0.Location = new System.Drawing.Point(14, 133);
			// this._lblReconcile_0.mLabelId = 1860;
			this._lblReconcile_0.Name = "_lblReconcile_0";
			this._lblReconcile_0.Size = new System.Drawing.Size(24, 14);
			this._lblReconcile_0.TabIndex = 7;
			// 
			// _lblReconcile_7
			// 
			this._lblReconcile_7.AllowDrop = true;
			this._lblReconcile_7.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblReconcile_7.Text = "Credit";
			this._lblReconcile_7.ForeColor = System.Drawing.Color.Black;
			this._lblReconcile_7.Location = new System.Drawing.Point(14, 151);
			// this._lblReconcile_7.mLabelId = 1861;
			this._lblReconcile_7.Name = "_lblReconcile_7";
			this._lblReconcile_7.Size = new System.Drawing.Size(28, 14);
			this._lblReconcile_7.TabIndex = 8;
			// 
			// _lblReconcile_3
			// 
			this._lblReconcile_3.AllowDrop = true;
			this._lblReconcile_3.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblReconcile_3.Text = "Total";
			this._lblReconcile_3.ForeColor = System.Drawing.Color.Black;
			this._lblReconcile_3.Location = new System.Drawing.Point(271, 108);
			// this._lblReconcile_3.mLabelId = 1865;
			this._lblReconcile_3.Name = "_lblReconcile_3";
			this._lblReconcile_3.Size = new System.Drawing.Size(23, 14);
			this._lblReconcile_3.TabIndex = 9;
			// 
			// _lblReconcile_2
			// 
			this._lblReconcile_2.AllowDrop = true;
			this._lblReconcile_2.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblReconcile_2.Text = "Reconciled";
			this._lblReconcile_2.ForeColor = System.Drawing.Color.Black;
			this._lblReconcile_2.Location = new System.Drawing.Point(168, 108);
			// this._lblReconcile_2.mLabelId = 1864;
			this._lblReconcile_2.Name = "_lblReconcile_2";
			this._lblReconcile_2.Size = new System.Drawing.Size(53, 14);
			this._lblReconcile_2.TabIndex = 10;
			// 
			// _lblReconcile_11
			// 
			this._lblReconcile_11.AllowDrop = true;
			this._lblReconcile_11.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblReconcile_11.Text = "Balance";
			this._lblReconcile_11.ForeColor = System.Drawing.Color.Black;
			this._lblReconcile_11.Location = new System.Drawing.Point(14, 169);
			// this._lblReconcile_11.mLabelId = 1862;
			this._lblReconcile_11.Name = "_lblReconcile_11";
			this._lblReconcile_11.Size = new System.Drawing.Size(39, 14);
			this._lblReconcile_11.TabIndex = 11;
			// 
			// _lblReconcile_16
			// 
			this._lblReconcile_16.AllowDrop = true;
			this._lblReconcile_16.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblReconcile_16.Text = "Unreconciled Debit Amount (+)";
			this._lblReconcile_16.ForeColor = System.Drawing.Color.Black;
			this._lblReconcile_16.Location = new System.Drawing.Point(463, 150);
			// this._lblReconcile_16.mLabelId = 1868;
			this._lblReconcile_16.Name = "_lblReconcile_16";
			this._lblReconcile_16.Size = new System.Drawing.Size(147, 14);
			this._lblReconcile_16.TabIndex = 12;
			// 
			// txtUnreconciledDebitAmount
			// 
			this.txtUnreconciledDebitAmount.AllowDrop = true;
			this.txtUnreconciledDebitAmount.BackColor = System.Drawing.Color.FromArgb(239, 239, 239);
			// this.txtUnreconciledDebitAmount.DisplayFormat = "###########0.000;; ; ";
			this.txtUnreconciledDebitAmount.Enabled = false;
			// this.txtUnreconciledDebitAmount.Format = "###########0.000";
			this.txtUnreconciledDebitAmount.Location = new System.Drawing.Point(619, 148);
			// this.txtUnreconciledDebitAmount.MaxValue = 2147483647;
			// this.txtUnreconciledDebitAmount.MinValue = -2147483648;
			this.txtUnreconciledDebitAmount.Name = "txtUnreconciledDebitAmount";
			this.txtUnreconciledDebitAmount.Size = new System.Drawing.Size(102, 19);
			this.txtUnreconciledDebitAmount.TabIndex = 13;
			this.txtUnreconciledDebitAmount.Text = "0.000";
			// 
			// _lblReconcile_17
			// 
			this._lblReconcile_17.AllowDrop = true;
			this._lblReconcile_17.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblReconcile_17.Text = "Diff. in Account Reconcilation";
			this._lblReconcile_17.ForeColor = System.Drawing.Color.Black;
			this._lblReconcile_17.Location = new System.Drawing.Point(463, 195);
			// this._lblReconcile_17.mLabelId = 1870;
			this._lblReconcile_17.Name = "_lblReconcile_17";
			this._lblReconcile_17.Size = new System.Drawing.Size(142, 14);
			this._lblReconcile_17.TabIndex = 14;
			// 
			// txtAccountReconcilationDiff
			// 
			this.txtAccountReconcilationDiff.AllowDrop = true;
			this.txtAccountReconcilationDiff.BackColor = System.Drawing.Color.FromArgb(239, 239, 239);
			// this.txtAccountReconcilationDiff.DisplayFormat = "###########0.000;; ; ";
			this.txtAccountReconcilationDiff.Enabled = false;
			// this.txtAccountReconcilationDiff.Format = "###########0.000";
			this.txtAccountReconcilationDiff.Location = new System.Drawing.Point(619, 193);
			// this.txtAccountReconcilationDiff.MaxValue = 2147483647;
			// this.txtAccountReconcilationDiff.MinValue = -2147483648;
			this.txtAccountReconcilationDiff.Name = "txtAccountReconcilationDiff";
			this.txtAccountReconcilationDiff.Size = new System.Drawing.Size(102, 19);
			this.txtAccountReconcilationDiff.TabIndex = 15;
			this.txtAccountReconcilationDiff.Text = "0.000";
			// 
			// _lblReconcile_1
			// 
			this._lblReconcile_1.AllowDrop = true;
			this._lblReconcile_1.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblReconcile_1.Text = "Unreconciled";
			this._lblReconcile_1.ForeColor = System.Drawing.Color.Black;
			this._lblReconcile_1.Location = new System.Drawing.Point(73, 110);
			// this._lblReconcile_1.mLabelId = 1863;
			this._lblReconcile_1.Name = "_lblReconcile_1";
			this._lblReconcile_1.Size = new System.Drawing.Size(63, 14);
			this._lblReconcile_1.TabIndex = 16;
			// 
			// _lblReconcile_4
			// 
			this._lblReconcile_4.AllowDrop = true;
			this._lblReconcile_4.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblReconcile_4.Text = "Unreconciled Credit Amount (-)";
			this._lblReconcile_4.ForeColor = System.Drawing.Color.Black;
			this._lblReconcile_4.Location = new System.Drawing.Point(463, 132);
			// this._lblReconcile_4.mLabelId = 1867;
			this._lblReconcile_4.Name = "_lblReconcile_4";
			this._lblReconcile_4.Size = new System.Drawing.Size(149, 14);
			this._lblReconcile_4.TabIndex = 17;
			// 
			// _lblReconcile_5
			// 
			this._lblReconcile_5.AllowDrop = true;
			this._lblReconcile_5.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblReconcile_5.Text = "GL (System) Balance (-)";
			this._lblReconcile_5.ForeColor = System.Drawing.Color.Black;
			this._lblReconcile_5.Location = new System.Drawing.Point(463, 168);
			// this._lblReconcile_5.mLabelId = 1869;
			this._lblReconcile_5.Name = "_lblReconcile_5";
			this._lblReconcile_5.Size = new System.Drawing.Size(118, 14);
			this._lblReconcile_5.TabIndex = 18;
			// 
			// txtGLSystemBalance
			// 
			this.txtGLSystemBalance.AllowDrop = true;
			this.txtGLSystemBalance.BackColor = System.Drawing.Color.FromArgb(239, 239, 239);
			// this.txtGLSystemBalance.DisplayFormat = "###########0.000;; ; ";
			this.txtGLSystemBalance.Enabled = false;
			// this.txtGLSystemBalance.Format = "###########0.000";
			this.txtGLSystemBalance.Location = new System.Drawing.Point(619, 166);
			// this.txtGLSystemBalance.MaxValue = 2147483647;
			// this.txtGLSystemBalance.MinValue = -2147483648;
			this.txtGLSystemBalance.Name = "txtGLSystemBalance";
			this.txtGLSystemBalance.Size = new System.Drawing.Size(102, 19);
			this.txtGLSystemBalance.TabIndex = 19;
			this.txtGLSystemBalance.Text = "0.000";
			// 
			// txtUnreconciledCreditAmount
			// 
			this.txtUnreconciledCreditAmount.AllowDrop = true;
			this.txtUnreconciledCreditAmount.BackColor = System.Drawing.Color.FromArgb(239, 239, 239);
			// this.txtUnreconciledCreditAmount.DisplayFormat = "###########0.000;; ; ";
			this.txtUnreconciledCreditAmount.Enabled = false;
			// this.txtUnreconciledCreditAmount.Format = "###########0.000";
			this.txtUnreconciledCreditAmount.Location = new System.Drawing.Point(619, 130);
			// this.txtUnreconciledCreditAmount.MaxValue = 2147483647;
			// this.txtUnreconciledCreditAmount.MinValue = -2147483648;
			this.txtUnreconciledCreditAmount.Name = "txtUnreconciledCreditAmount";
			this.txtUnreconciledCreditAmount.Size = new System.Drawing.Size(102, 19);
			this.txtUnreconciledCreditAmount.TabIndex = 20;
			this.txtUnreconciledCreditAmount.Text = "0.000";
			// 
			// _lblReconcile_15
			// 
			this._lblReconcile_15.AllowDrop = true;
			this._lblReconcile_15.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblReconcile_15.Text = "Statement Ending Balance";
			this._lblReconcile_15.ForeColor = System.Drawing.Color.Black;
			this._lblReconcile_15.Location = new System.Drawing.Point(463, 114);
			// this._lblReconcile_15.mLabelId = 1866;
			this._lblReconcile_15.Name = "_lblReconcile_15";
			this._lblReconcile_15.Size = new System.Drawing.Size(125, 14);
			this._lblReconcile_15.TabIndex = 21;
			// 
			// txtStatementEndingBalance
			// 
			this.txtStatementEndingBalance.AllowDrop = true;
			this.txtStatementEndingBalance.BackColor = System.Drawing.Color.White;
			// this.txtStatementEndingBalance.DisplayFormat = "#######0.000###;; ; ";
			// this.txtStatementEndingBalance.Format = "#######0.000###";
			this.txtStatementEndingBalance.Location = new System.Drawing.Point(619, 112);
			// this.txtStatementEndingBalance.MaxValue = 2147483647;
			// this.txtStatementEndingBalance.MinValue = -2147483648;
			this.txtStatementEndingBalance.Name = "txtStatementEndingBalance";
			this.txtStatementEndingBalance.Size = new System.Drawing.Size(102, 19);
			this.txtStatementEndingBalance.TabIndex = 22;
			this.txtStatementEndingBalance.Text = "0.000";
			// this.this.txtStatementEndingBalance.Change += new System.Windows.Forms.TextBox.ChangeHandler(this.txtStatementEndingBalance_Change);
			// 
			// _dcReconcile_3
			// 
			// this._dcReconcile_3.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
			this._dcReconcile_3.AllowDrop = true;
			this._dcReconcile_3.Location = new System.Drawing.Point(236, 131);
			this._dcReconcile_3.Name = "_dcReconcile_3";
			this._dcReconcile_3.Size = new System.Drawing.Size(88, 19);
			this._dcReconcile_3.TabIndex = 23;
			// 
			// _dcReconcile_9
			// 
			// this._dcReconcile_9.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
			this._dcReconcile_9.AllowDrop = true;
			this._dcReconcile_9.Location = new System.Drawing.Point(236, 167);
			this._dcReconcile_9.Name = "_dcReconcile_9";
			this._dcReconcile_9.Size = new System.Drawing.Size(88, 19);
			this._dcReconcile_9.TabIndex = 24;
			// 
			// _dcReconcile_8
			// 
			// this._dcReconcile_8.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
			this._dcReconcile_8.AllowDrop = true;
			this._dcReconcile_8.Location = new System.Drawing.Point(149, 167);
			this._dcReconcile_8.Name = "_dcReconcile_8";
			this._dcReconcile_8.Size = new System.Drawing.Size(88, 19);
			this._dcReconcile_8.TabIndex = 25;
			// 
			// _dcReconcile_7
			// 
			// this._dcReconcile_7.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
			this._dcReconcile_7.AllowDrop = true;
			this._dcReconcile_7.Location = new System.Drawing.Point(62, 167);
			this._dcReconcile_7.Name = "_dcReconcile_7";
			this._dcReconcile_7.Size = new System.Drawing.Size(88, 19);
			this._dcReconcile_7.TabIndex = 26;
			// 
			// _dcReconcile_6
			// 
			// this._dcReconcile_6.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
			this._dcReconcile_6.AllowDrop = true;
			this._dcReconcile_6.Location = new System.Drawing.Point(236, 149);
			this._dcReconcile_6.Name = "_dcReconcile_6";
			this._dcReconcile_6.Size = new System.Drawing.Size(88, 19);
			this._dcReconcile_6.TabIndex = 27;
			// 
			// _dcReconcile_2
			// 
			// this._dcReconcile_2.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
			this._dcReconcile_2.AllowDrop = true;
			this._dcReconcile_2.Location = new System.Drawing.Point(149, 131);
			this._dcReconcile_2.Name = "_dcReconcile_2";
			this._dcReconcile_2.Size = new System.Drawing.Size(88, 19);
			this._dcReconcile_2.TabIndex = 28;
			// 
			// _dcReconcile_5
			// 
			// this._dcReconcile_5.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
			this._dcReconcile_5.AllowDrop = true;
			this._dcReconcile_5.Location = new System.Drawing.Point(149, 149);
			this._dcReconcile_5.Name = "_dcReconcile_5";
			this._dcReconcile_5.Size = new System.Drawing.Size(88, 19);
			this._dcReconcile_5.TabIndex = 29;
			// 
			// _dcReconcile_4
			// 
			// this._dcReconcile_4.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
			this._dcReconcile_4.AllowDrop = true;
			this._dcReconcile_4.Location = new System.Drawing.Point(62, 149);
			this._dcReconcile_4.Name = "_dcReconcile_4";
			this._dcReconcile_4.Size = new System.Drawing.Size(88, 19);
			this._dcReconcile_4.TabIndex = 30;
			// 
			// _dcReconcile_1
			// 
			// this._dcReconcile_1.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
			this._dcReconcile_1.AllowDrop = true;
			this._dcReconcile_1.Location = new System.Drawing.Point(62, 131);
			this._dcReconcile_1.Name = "_dcReconcile_1";
			this._dcReconcile_1.Size = new System.Drawing.Size(88, 19);
			this._dcReconcile_1.TabIndex = 31;
			// 
			// lblComments
			// 
			this.lblComments.AllowDrop = true;
			this.lblComments.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblComments.Text = "Comments";
			this.lblComments.ForeColor = System.Drawing.Color.Black;
			this.lblComments.Location = new System.Drawing.Point(12, 530);
			// this.lblComments.mLabelId = 135;
			this.lblComments.Name = "lblComments";
			this.lblComments.Size = new System.Drawing.Size(63, 16);
			this.lblComments.TabIndex = 32;
			// 
			// txtComments
			// 
			this.txtComments.AllowDrop = true;
			this.txtComments.BackColor = System.Drawing.Color.White;
			// this.txtComments.bolAllowDecimal = false;
			this.txtComments.ForeColor = System.Drawing.Color.Black;
			this.txtComments.Location = new System.Drawing.Point(78, 522);
			// this.txtComments.mDropDownType = (System.Windows.Forms.TextBox.FormatBoxDropDownTypes) 0;
			this.txtComments.Name = "txtComments";
			this.txtComments.Size = new System.Drawing.Size(645, 55);
			this.txtComments.TabIndex = 33;
			this.txtComments.Text = "";
			// 
			// Line
			// 
			this.Line.AllowDrop = true;
			this.Line.BackColor = System.Drawing.SystemColors.WindowText;
			this.Line.Enabled = false;
			this.Line.Location = new System.Drawing.Point(463, 189);
			this.Line.Name = "Line";
			this.Line.Size = new System.Drawing.Size(258, 1);
			this.Line.Visible = true;
			// 
			// Line1
			// 
			this.Line1.AllowDrop = true;
			this.Line1.BackColor = System.Drawing.SystemColors.WindowText;
			this.Line1.Enabled = false;
			this.Line1.Location = new System.Drawing.Point(-1, 82);
			this.Line1.Name = "Line1";
			this.Line1.Size = new System.Drawing.Size(728, 1);
			this.Line1.Visible = true;
			// 
			// frmGLAccountReconcilation
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.ClientSize = new System.Drawing.Size(1237, 685);
			this.Controls.Add(this.chkShowReconciled);
			this.Controls.Add(this.txtLdgrName);
			this.Controls.Add(this.txtLdgrNo);
			this.Controls.Add(this.lblLedgerNo);
			this.Controls.Add(this._lblCommonLabel_6);
			this.Controls.Add(this.txtVoucherDate);
			this.Controls.Add(this.grdVoucherDetails);
			this.Controls.Add(this._lblReconcile_0);
			this.Controls.Add(this._lblReconcile_7);
			this.Controls.Add(this._lblReconcile_3);
			this.Controls.Add(this._lblReconcile_2);
			this.Controls.Add(this._lblReconcile_11);
			this.Controls.Add(this._lblReconcile_16);
			this.Controls.Add(this.txtUnreconciledDebitAmount);
			this.Controls.Add(this._lblReconcile_17);
			this.Controls.Add(this.txtAccountReconcilationDiff);
			this.Controls.Add(this._lblReconcile_1);
			this.Controls.Add(this._lblReconcile_4);
			this.Controls.Add(this._lblReconcile_5);
			this.Controls.Add(this.txtGLSystemBalance);
			this.Controls.Add(this.txtUnreconciledCreditAmount);
			this.Controls.Add(this._lblReconcile_15);
			this.Controls.Add(this.txtStatementEndingBalance);
			this.Controls.Add(this._dcReconcile_3);
			this.Controls.Add(this._dcReconcile_9);
			this.Controls.Add(this._dcReconcile_8);
			this.Controls.Add(this._dcReconcile_7);
			this.Controls.Add(this._dcReconcile_6);
			this.Controls.Add(this._dcReconcile_2);
			this.Controls.Add(this._dcReconcile_5);
			this.Controls.Add(this._dcReconcile_4);
			this.Controls.Add(this._dcReconcile_1);
			this.Controls.Add(this.lblComments);
			this.Controls.Add(this.txtComments);
			this.Controls.Add(this.Line);
			this.Controls.Add(this.Line1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
			//this.Icon = (System.Drawing.Icon) resources.GetObject("frmGLAccountReconcilation.Icon");
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(94, 106);
			this.MaximizeBox = true;
			this.MinimizeBox = false;
			this.Name = "frmGLAccountReconcilation";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Account Reconcilation";
			// this.Activated += new System.EventHandler(this.Form_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
			// this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
			//this.Resize += new System.EventHandler(this.Form_Resize);
			this.grdVoucherDetails.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		void ReLoadForm(bool addEvents)
		{
			InitializelblReconcile();
			InitializelblCommonLabel();
			InitializedcReconcile();
			//This form is an MDI child.
			//This code simulates the VB6 
			// functionality of automatically
			// loading and showing an MDI
			// child's parent.
			this.MdiParent = Xtreme.frmSysMain.DefInstance;
			Xtreme.frmSysMain.DefInstance.Show();
		}
		void InitializelblReconcile()
		{
			this.lblReconcile = new System.Windows.Forms.Label[18];
			this.lblReconcile[0] = _lblReconcile_0;
			this.lblReconcile[7] = _lblReconcile_7;
			this.lblReconcile[3] = _lblReconcile_3;
			this.lblReconcile[2] = _lblReconcile_2;
			this.lblReconcile[11] = _lblReconcile_11;
			this.lblReconcile[16] = _lblReconcile_16;
			this.lblReconcile[17] = _lblReconcile_17;
			this.lblReconcile[1] = _lblReconcile_1;
			this.lblReconcile[4] = _lblReconcile_4;
			this.lblReconcile[5] = _lblReconcile_5;
			this.lblReconcile[15] = _lblReconcile_15;
		}
		void InitializelblCommonLabel()
		{
			this.lblCommonLabel = new System.Windows.Forms.Label[7];
			this.lblCommonLabel[6] = _lblCommonLabel_6;
		}
		void InitializedcReconcile()
		{
			this.dcReconcile = new System.Windows.Forms.Label[10];
			this.dcReconcile[3] = _dcReconcile_3;
			this.dcReconcile[9] = _dcReconcile_9;
			this.dcReconcile[8] = _dcReconcile_8;
			this.dcReconcile[7] = _dcReconcile_7;
			this.dcReconcile[6] = _dcReconcile_6;
			this.dcReconcile[2] = _dcReconcile_2;
			this.dcReconcile[5] = _dcReconcile_5;
			this.dcReconcile[4] = _dcReconcile_4;
			this.dcReconcile[1] = _dcReconcile_1;
		}
		#endregion
	}
}