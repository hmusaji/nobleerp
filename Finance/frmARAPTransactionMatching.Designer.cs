
namespace Xtreme
{
	partial class frmARAPTransactionMatching
	{

		#region "Upgrade Support "
		private static frmARAPTransactionMatching m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmARAPTransactionMatching DefInstance
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
		public static frmARAPTransactionMatching CreateInstance()
		{
			frmARAPTransactionMatching theInstance = new frmARAPTransactionMatching();
			
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
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "cmdFind", "chkShowAll", "comHeaderType", "txtLdgrName", "txtLdgrNo", "lblLedgerNo", "System.Windows.Forms.Label1", "Column_0__grdVoucherDetails_0", "Column_1__grdVoucherDetails_0", "_grdVoucherDetails_0", "Column_0__grdVoucherDetails_1", "Column_1__grdVoucherDetails_1", "_grdVoucherDetails_1", "lblAdjustmentDetails", "Line1", "grdVoucherDetails"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public UCOkCancel cmdFind;
		public System.Windows.Forms.CheckBox chkShowAll;
		public System.Windows.Forms.ComboBox comHeaderType;
		public System.Windows.Forms.TextBox txtLdgrName;
		public System.Windows.Forms.TextBox txtLdgrNo;
		public System.Windows.Forms.Label lblLedgerNo;
		public System.Windows.Forms.Label Label1;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_0__grdVoucherDetails_0;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_1__grdVoucherDetails_0;
		private C1.Win.C1TrueDBGrid.C1TrueDBGrid _grdVoucherDetails_0;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_0__grdVoucherDetails_1;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_1__grdVoucherDetails_1;
		private C1.Win.C1TrueDBGrid.C1TrueDBGrid _grdVoucherDetails_1;
		public System.Windows.Forms.Label lblAdjustmentDetails;
		public System.Windows.Forms.Label Line1;
		public C1.Win.C1TrueDBGrid.C1TrueDBGrid[] grdVoucherDetails = new C1.Win.C1TrueDBGrid.C1TrueDBGrid[2];
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmARAPTransactionMatching));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this.cmdFind = new UCOkCancel();
			this.chkShowAll = new System.Windows.Forms.CheckBox();
			this.comHeaderType = new System.Windows.Forms.ComboBox();
			this.txtLdgrName = new System.Windows.Forms.TextBox();
			this.txtLdgrNo = new System.Windows.Forms.TextBox();
			this.lblLedgerNo = new System.Windows.Forms.Label();
			this.Label1 = new System.Windows.Forms.Label();
			this._grdVoucherDetails_0 = new C1.Win.C1TrueDBGrid.C1TrueDBGrid();
			this.Column_0__grdVoucherDetails_0 = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.Column_1__grdVoucherDetails_0 = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this._grdVoucherDetails_1 = new C1.Win.C1TrueDBGrid.C1TrueDBGrid();
			this.Column_0__grdVoucherDetails_1 = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.Column_1__grdVoucherDetails_1 = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.lblAdjustmentDetails = new System.Windows.Forms.Label();
			this.Line1 = new System.Windows.Forms.Label();
			this._grdVoucherDetails_0.SuspendLayout();
			this._grdVoucherDetails_1.SuspendLayout();
			this.SuspendLayout();
			// 
			// cmdFind
			// 
			this.cmdFind.AllowDrop = true;
			this.cmdFind.DisplayButton = 1;
			this.cmdFind.Location = new System.Drawing.Point(600, 26);
			this.cmdFind.Name = "cmdFind";
			this.cmdFind.OkCaption = "&Find";
			this.cmdFind.Size = new System.Drawing.Size(205, 29);
			this.cmdFind.TabIndex = 2;
			this.cmdFind.OKClick += new UCOkCancel.OKClickHandler(this.cmdFind_OKClick);
			// 
			// chkShowAll
			// 
			this.chkShowAll.AllowDrop = true;
			this.chkShowAll.Appearance = System.Windows.Forms.Appearance.Normal;
			this.chkShowAll.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.chkShowAll.CausesValidation = true;
			this.chkShowAll.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkShowAll.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this.chkShowAll.Enabled = true;
			this.chkShowAll.ForeColor = System.Drawing.Color.Black;
			this.chkShowAll.Location = new System.Drawing.Point(189, 36);
			this.chkShowAll.Name = "chkShowAll";
			this.chkShowAll.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.chkShowAll.Size = new System.Drawing.Size(121, 15);
			this.chkShowAll.TabIndex = 6;
			this.chkShowAll.TabStop = true;
			this.chkShowAll.Text = "&Show All Vouchers";
			this.chkShowAll.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkShowAll.Visible = true;
			this.chkShowAll.CheckStateChanged += new System.EventHandler(this.chkShowAll_CheckStateChanged);
			// 
			// comHeaderType
			// 
			this.comHeaderType.AllowDrop = true;
			this.comHeaderType.Location = new System.Drawing.Point(84, 33);
			this.comHeaderType.Name = "comHeaderType";
			this.comHeaderType.Size = new System.Drawing.Size(54, 21);
			this.comHeaderType.TabIndex = 1;
			// 
			// txtLdgrName
			// 
			this.txtLdgrName.AllowDrop = true;
			this.txtLdgrName.BackColor = System.Drawing.Color.FromArgb(239, 239, 239);
			this.txtLdgrName.Enabled = false;
			this.txtLdgrName.ForeColor = System.Drawing.Color.Black;
			this.txtLdgrName.Location = new System.Drawing.Point(188, 12);
			this.txtLdgrName.Name = "txtLdgrName";
			this.txtLdgrName.Size = new System.Drawing.Size(201, 19);
			this.txtLdgrName.TabIndex = 3;
			this.txtLdgrName.Text = "";
			// 
			// txtLdgrNo
			// 
			this.txtLdgrNo.AllowDrop = true;
			this.txtLdgrNo.BackColor = System.Drawing.Color.White;
			this.txtLdgrNo.ForeColor = System.Drawing.Color.Black;
			this.txtLdgrNo.Location = new System.Drawing.Point(84, 12);
			this.txtLdgrNo.Name = "txtLdgrNo";
			// this.txtLdgrNo.ShowButton = true;
			this.txtLdgrNo.Size = new System.Drawing.Size(101, 19);
			this.txtLdgrNo.TabIndex = 0;
			this.txtLdgrNo.Text = "";
			// this.this.txtLdgrNo.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtLdgrNo_DropButtonClick);
			// this.txtLdgrNo.Leave += new System.EventHandler(this.txtLdgrNo_Leave);
			// 
			// lblLedgerNo
			// 
			this.lblLedgerNo.AllowDrop = true;
			this.lblLedgerNo.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblLedgerNo.Text = "Ledger Code";
			this.lblLedgerNo.ForeColor = System.Drawing.Color.Black;
			this.lblLedgerNo.Location = new System.Drawing.Point(12, 14);
			this.lblLedgerNo.Name = "lblLedgerNo";
			this.lblLedgerNo.Size = new System.Drawing.Size(62, 14);
			this.lblLedgerNo.TabIndex = 4;
			// 
			// System.Windows.Forms.Label1
			// 
			this.Label1.AllowDrop = true;
			this.Label1.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.Label1.Text = "Header Type";
			this.Label1.ForeColor = System.Drawing.Color.Black;
			this.Label1.Location = new System.Drawing.Point(13, 37);
			this.Label1.Name = "System.Windows.Forms.Label1";
			this.Label1.Size = new System.Drawing.Size(62, 14);
			this.Label1.TabIndex = 5;
			// 
			// _grdVoucherDetails_0
			// 
			this._grdVoucherDetails_0.AllowDrop = true;
			this._grdVoucherDetails_0.BackColor = System.Drawing.Color.FromArgb(236, 233, 216);
			this._grdVoucherDetails_0.CellTipsWidth = 0;
			this._grdVoucherDetails_0.Location = new System.Drawing.Point(6, 80);
			this._grdVoucherDetails_0.Name = "_grdVoucherDetails_0";
			this._grdVoucherDetails_0.RowDivider.Color = System.Drawing.Color.FromArgb(236, 233, 216);
			this._grdVoucherDetails_0.Size = new System.Drawing.Size(743, 177);
			this._grdVoucherDetails_0.TabIndex = 7;
			this._grdVoucherDetails_0.Columns.Add(this.Column_0__grdVoucherDetails_0);
			this._grdVoucherDetails_0.Columns.Add(this.Column_1__grdVoucherDetails_0);
			this._grdVoucherDetails_0.AfterColUpdate += new C1.Win.C1TrueDBGrid.ColEventHandler(this.grdVoucherDetails_AfterColUpdate);
			this._grdVoucherDetails_0.BeforeColUpdate += new C1.Win.C1TrueDBGrid.BeforeColUpdateEventHandler(this.grdVoucherDetails_BeforeColUpdate);
			this._grdVoucherDetails_0.GotFocus += new System.EventHandler(this.grdVoucherDetails_GotFocus);
			this._grdVoucherDetails_0.RowColChange += new C1.Win.C1TrueDBGrid.RowColChangeEventHandler(this.grdVoucherDetails_RowColChange);
			this._grdVoucherDetails_0.UnboundColumnFetch += new C1.Win.C1TrueDBGrid.UnboundColumnFetchEventHandler(this.grdVoucherDetails_UnboundColumnFetch);
			// 
			// Column_0__grdVoucherDetails_0
			// 
			this.Column_0__grdVoucherDetails_0.DataField = "";
			this.Column_0__grdVoucherDetails_0.ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.Normal;
			// 
			// Column_1__grdVoucherDetails_0
			// 
			this.Column_1__grdVoucherDetails_0.DataField = "";
			this.Column_1__grdVoucherDetails_0.ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.Normal;
			// 
			// _grdVoucherDetails_1
			// 
			this._grdVoucherDetails_1.AllowDrop = true;
			this._grdVoucherDetails_1.BackColor = System.Drawing.Color.FromArgb(236, 233, 216);
			this._grdVoucherDetails_1.CellTipsWidth = 0;
			this._grdVoucherDetails_1.Location = new System.Drawing.Point(6, 276);
			this._grdVoucherDetails_1.Name = "_grdVoucherDetails_1";
			this._grdVoucherDetails_1.RowDivider.Color = System.Drawing.Color.FromArgb(236, 233, 216);
			this._grdVoucherDetails_1.Size = new System.Drawing.Size(743, 195);
			this._grdVoucherDetails_1.TabIndex = 8;
			this._grdVoucherDetails_1.Columns.Add(this.Column_0__grdVoucherDetails_1);
			this._grdVoucherDetails_1.Columns.Add(this.Column_1__grdVoucherDetails_1);
			this._grdVoucherDetails_1.AfterColUpdate += new C1.Win.C1TrueDBGrid.ColEventHandler(this.grdVoucherDetails_AfterColUpdate);
			this._grdVoucherDetails_1.BeforeColUpdate += new C1.Win.C1TrueDBGrid.BeforeColUpdateEventHandler(this.grdVoucherDetails_BeforeColUpdate);
			this._grdVoucherDetails_1.GotFocus += new System.EventHandler(this.grdVoucherDetails_GotFocus);
			this._grdVoucherDetails_1.RowColChange += new C1.Win.C1TrueDBGrid.RowColChangeEventHandler(this.grdVoucherDetails_RowColChange);
			this._grdVoucherDetails_1.UnboundColumnFetch += new C1.Win.C1TrueDBGrid.UnboundColumnFetchEventHandler(this.grdVoucherDetails_UnboundColumnFetch);
			// 
			// Column_0__grdVoucherDetails_1
			// 
			this.Column_0__grdVoucherDetails_1.DataField = "";
			this.Column_0__grdVoucherDetails_1.ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.Normal;
			// 
			// Column_1__grdVoucherDetails_1
			// 
			this.Column_1__grdVoucherDetails_1.DataField = "";
			this.Column_1__grdVoucherDetails_1.ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.Normal;
			// 
			// lblAdjustmentDetails
			// 
			this.lblAdjustmentDetails.AllowDrop = true;
			this.lblAdjustmentDetails.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblAdjustmentDetails.Text = "Match Voucher With :";
			this.lblAdjustmentDetails.ForeColor = System.Drawing.Color.Black;
			this.lblAdjustmentDetails.Location = new System.Drawing.Point(12, 260);
			this.lblAdjustmentDetails.Name = "lblAdjustmentDetails";
			this.lblAdjustmentDetails.Size = new System.Drawing.Size(103, 13);
			this.lblAdjustmentDetails.TabIndex = 9;
			// 
			// Line1
			// 
			this.Line1.AllowDrop = true;
			this.Line1.BackColor = System.Drawing.Color.Red;
			this.Line1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Line1.Enabled = false;
			this.Line1.ForeColor = System.Drawing.Color.Black;
			this.Line1.Location = new System.Drawing.Point(-1, 66);
			this.Line1.Name = "Line1";
			this.Line1.Size = new System.Drawing.Size(1014, 1);
			this.Line1.Text = "Line1";
			this.Line1.Visible = true;
			// 
			// frmARAPTransactionMatching
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.ClientSize = new System.Drawing.Size(1004, 518);
			this.Controls.Add(this.cmdFind);
			this.Controls.Add(this.chkShowAll);
			this.Controls.Add(this.comHeaderType);
			this.Controls.Add(this.txtLdgrName);
			this.Controls.Add(this.txtLdgrNo);
			this.Controls.Add(this.lblLedgerNo);
			this.Controls.Add(this.Label1);
			this.Controls.Add(this._grdVoucherDetails_0);
			this.Controls.Add(this._grdVoucherDetails_1);
			this.Controls.Add(this.lblAdjustmentDetails);
			this.Controls.Add(this.Line1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			//this.Icon = (System.Drawing.Icon) resources.GetObject("frmARAPTransactionMatching.Icon");
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(209, 181);
			this.MaximizeBox = true;
			this.MinimizeBox = true;
			this.Name = "frmARAPTransactionMatching";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "AR/AP Transaction Match / UnMatch";
			// this.Activated += new System.EventHandler(this.Form_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
			// this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
			//this.Resize += new System.EventHandler(this.Form_Resize);
			this._grdVoucherDetails_0.ResumeLayout(false);
			this._grdVoucherDetails_1.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		// 
		void InitializegrdVoucherDetails()
		{
			this.grdVoucherDetails = new C1.Win.C1TrueDBGrid.C1TrueDBGrid[2];
			this.grdVoucherDetails[0] = _grdVoucherDetails_0;
			this.grdVoucherDetails[1] = _grdVoucherDetails_1;
		}
		#endregion
	}
}//ENDSHERE
