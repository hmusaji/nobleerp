
namespace Xtreme
{
	partial class frmARAPVoucherTracking
	{

		#region "Upgrade Support "
		private static frmARAPVoucherTracking m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmARAPVoucherTracking DefInstance
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
		public static frmARAPVoucherTracking CreateInstance()
		{
			frmARAPVoucherTracking theInstance = new frmARAPVoucherTracking();
			
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
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "lblAdjustmentDetails", "Column_0__grdVoucherDetails_1", "Column_1__grdVoucherDetails_1", "_grdVoucherDetails_1", "Column_0__grdVoucherDetails_0", "Column_1__grdVoucherDetails_0", "_grdVoucherDetails_0", "cmdClose", "picOkCancel", "chkShowAll", "cntMasterDetails", "txtLdgrName", "txtLdgrNo", "lblLedgerNo", "Line1", "grdVoucherDetails"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public System.Windows.Forms.Label lblAdjustmentDetails;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_0__grdVoucherDetails_1;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_1__grdVoucherDetails_1;
		private C1.Win.C1TrueDBGrid.C1TrueDBGrid _grdVoucherDetails_1;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_0__grdVoucherDetails_0;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_1__grdVoucherDetails_0;
		private C1.Win.C1TrueDBGrid.C1TrueDBGrid _grdVoucherDetails_0;
		public AxSmartNetButtonProject.AxSmartNetButton cmdClose;
		public System.Windows.Forms.PictureBox picOkCancel;
		public System.Windows.Forms.CheckBox chkShowAll;
		public System.Windows.Forms.Panel cntMasterDetails;
		public System.Windows.Forms.TextBox txtLdgrName;
		public System.Windows.Forms.TextBox txtLdgrNo;
		public System.Windows.Forms.Label lblLedgerNo;
		public System.Windows.Forms.Label Line1;
		public C1.Win.C1TrueDBGrid.C1TrueDBGrid[] grdVoucherDetails = new C1.Win.C1TrueDBGrid.C1TrueDBGrid[2];
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmARAPVoucherTracking));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this.cntMasterDetails = new System.Windows.Forms.Panel();
			this.lblAdjustmentDetails = new System.Windows.Forms.Label();
			this._grdVoucherDetails_1 = new C1.Win.C1TrueDBGrid.C1TrueDBGrid();
			this.Column_0__grdVoucherDetails_1 = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.Column_1__grdVoucherDetails_1 = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this._grdVoucherDetails_0 = new C1.Win.C1TrueDBGrid.C1TrueDBGrid();
			this.Column_0__grdVoucherDetails_0 = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.Column_1__grdVoucherDetails_0 = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.picOkCancel = new System.Windows.Forms.PictureBox();
			this.cmdClose = new AxSmartNetButtonProject.AxSmartNetButton();
			this.chkShowAll = new System.Windows.Forms.CheckBox();
			this.txtLdgrName = new System.Windows.Forms.TextBox();
			this.txtLdgrNo = new System.Windows.Forms.TextBox();
			this.lblLedgerNo = new System.Windows.Forms.Label();
			this.Line1 = new System.Windows.Forms.Label();
			// //((System.ComponentModel.ISupportInitialize) this.cmdClose).BeginInit();
			// //((System.ComponentModel.ISupportInitialize) this.cntMasterDetails).BeginInit();
			this.cntMasterDetails.SuspendLayout();
			this._grdVoucherDetails_1.SuspendLayout();
			this._grdVoucherDetails_0.SuspendLayout();
			this.picOkCancel.SuspendLayout();
			this.SuspendLayout();
			// 
			// cntMasterDetails
			// 
			this.cntMasterDetails.AllowDrop = true;
			this.cntMasterDetails.Controls.Add(this.lblAdjustmentDetails);
			this.cntMasterDetails.Controls.Add(this._grdVoucherDetails_1);
			this.cntMasterDetails.Controls.Add(this._grdVoucherDetails_0);
			this.cntMasterDetails.Controls.Add(this.picOkCancel);
			this.cntMasterDetails.Controls.Add(this.chkShowAll);
			this.cntMasterDetails.Location = new System.Drawing.Point(2, 47);
			this.cntMasterDetails.Name = "cntMasterDetails";
			//
			this.cntMasterDetails.Size = new System.Drawing.Size(625, 331);
			this.cntMasterDetails.TabIndex = 4;
			// 
			// lblAdjustmentDetails
			// 
			this.lblAdjustmentDetails.AllowDrop = true;
			this.lblAdjustmentDetails.BackColor = System.Drawing.Color.FromArgb(238, 239, 214);
			this.lblAdjustmentDetails.Text = "Adjust Voucher With :";
			this.lblAdjustmentDetails.ForeColor = System.Drawing.Color.Black;
			this.lblAdjustmentDetails.Location = new System.Drawing.Point(7, 140);
			this.lblAdjustmentDetails.Name = "lblAdjustmentDetails";
			this.lblAdjustmentDetails.Size = new System.Drawing.Size(105, 13);
			this.lblAdjustmentDetails.TabIndex = 9;
			// 
			// _grdVoucherDetails_1
			// 
			this._grdVoucherDetails_1.AllowDrop = true;
			this._grdVoucherDetails_1.BackColor = System.Drawing.Color.FromArgb(212, 208, 200);
			this._grdVoucherDetails_1.CellTipsWidth = 0;
			this._grdVoucherDetails_1.Location = new System.Drawing.Point(0, 156);
			this._grdVoucherDetails_1.Name = "_grdVoucherDetails_1";
			this._grdVoucherDetails_1.RowDivider.Color = System.Drawing.Color.FromArgb(212, 208, 200);
			this._grdVoucherDetails_1.Size = new System.Drawing.Size(621, 135);
			this._grdVoucherDetails_1.TabIndex = 2;
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
			// _grdVoucherDetails_0
			// 
			this._grdVoucherDetails_0.AllowDrop = true;
			this._grdVoucherDetails_0.BackColor = System.Drawing.Color.FromArgb(212, 208, 200);
			this._grdVoucherDetails_0.CellTipsWidth = 0;
			this._grdVoucherDetails_0.Location = new System.Drawing.Point(0, 0);
			this._grdVoucherDetails_0.Name = "_grdVoucherDetails_0";
			this._grdVoucherDetails_0.RowDivider.Color = System.Drawing.Color.FromArgb(212, 208, 200);
			this._grdVoucherDetails_0.Size = new System.Drawing.Size(621, 135);
			this._grdVoucherDetails_0.TabIndex = 1;
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
			// picOkCancel
			// 
			this.picOkCancel.AllowDrop = true;
			this.picOkCancel.BackColor = System.Drawing.Color.Navy;
			this.picOkCancel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.picOkCancel.CausesValidation = true;
			this.picOkCancel.Controls.Add(this.cmdClose);
			this.picOkCancel.Dock = System.Windows.Forms.DockStyle.None;
			this.picOkCancel.Enabled = true;
			this.picOkCancel.Location = new System.Drawing.Point(449, 297);
			this.picOkCancel.Name = "picOkCancel";
			this.picOkCancel.Size = new System.Drawing.Size(164, 26);
			this.picOkCancel.TabIndex = 7;
			this.picOkCancel.TabStop = true;
			this.picOkCancel.Visible = true;
			// 
			// cmdClose
			// 
			this.cmdClose.AllowDrop = true;
			this.cmdClose.Location = new System.Drawing.Point(0, 0);
			this.cmdClose.Name = "cmdClose";
			//
			this.cmdClose.Size = new System.Drawing.Size(162, 24);
			this.cmdClose.TabIndex = 8;
			this.cmdClose.TabStop = false;
			//// this.cmdClose.ClickEvent += new System.EventHandler(this.cmdClose_ClickEvent);
			// 
			// chkShowAll
			// 
			this.chkShowAll.AllowDrop = true;
			this.chkShowAll.Appearance = System.Windows.Forms.Appearance.Normal;
			this.chkShowAll.BackColor = System.Drawing.Color.FromArgb(238, 239, 214);
			this.chkShowAll.CausesValidation = true;
			this.chkShowAll.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkShowAll.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this.chkShowAll.Enabled = true;
			this.chkShowAll.ForeColor = System.Drawing.Color.Black;
			this.chkShowAll.Location = new System.Drawing.Point(12, 304);
			this.chkShowAll.Name = "chkShowAll";
			this.chkShowAll.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.chkShowAll.Size = new System.Drawing.Size(121, 15);
			this.chkShowAll.TabIndex = 3;
			this.chkShowAll.TabStop = true;
			this.chkShowAll.Text = "&Show All Vouchers";
			this.chkShowAll.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkShowAll.Visible = true;
			this.chkShowAll.CheckStateChanged += new System.EventHandler(this.chkShowAll_CheckStateChanged);
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
			this.txtLdgrName.TabIndex = 5;
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
			this.lblLedgerNo.BackColor = System.Drawing.Color.FromArgb(238, 239, 214);
			this.lblLedgerNo.Text = "Ledger Code";
			this.lblLedgerNo.ForeColor = System.Drawing.Color.Black;
			this.lblLedgerNo.Location = new System.Drawing.Point(12, 14);
			this.lblLedgerNo.Name = "lblLedgerNo";
			this.lblLedgerNo.Size = new System.Drawing.Size(62, 14);
			this.lblLedgerNo.TabIndex = 6;
			// 
			// Line1
			// 
			this.Line1.AllowDrop = true;
			this.Line1.BackColor = System.Drawing.SystemColors.WindowText;
			this.Line1.Enabled = false;
			this.Line1.Location = new System.Drawing.Point(-1, 36);
			this.Line1.Name = "Line1";
			this.Line1.Size = new System.Drawing.Size(630, 1);
			this.Line1.Visible = true;
			// 
			// frmARAPVoucherTracking
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.FromArgb(238, 239, 214);
			this.ClientSize = new System.Drawing.Size(630, 382);
			this.Controls.Add(this.cntMasterDetails);
			this.Controls.Add(this.txtLdgrName);
			this.Controls.Add(this.txtLdgrNo);
			this.Controls.Add(this.lblLedgerNo);
			this.Controls.Add(this.Line1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			//this.Icon = (System.Drawing.Icon) resources.GetObject("frmARAPVoucherTracking.Icon");
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(194, 145);
			this.MaximizeBox = false;
			this.MinimizeBox = true;
			this.Name = "frmARAPVoucherTracking";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "AR / AP Adjustment";
			// this.Activated += new System.EventHandler(this.Form_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
			// this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
			//((System.ComponentModel.ISupportInitialize) this.cmdClose).EndInit();
			//((System.ComponentModel.ISupportInitialize) this.cntMasterDetails).EndInit();
			this.cntMasterDetails.ResumeLayout(false);
			this._grdVoucherDetails_1.ResumeLayout(false);
			this._grdVoucherDetails_0.ResumeLayout(false);
			this.picOkCancel.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		// 
		void InitializegrdVoucherDetails()
		{
			this.grdVoucherDetails = new C1.Win.C1TrueDBGrid.C1TrueDBGrid[2];
			this.grdVoucherDetails[1] = _grdVoucherDetails_1;
			this.grdVoucherDetails[0] = _grdVoucherDetails_0;
		}
		#endregion
	}
}//ENDSHERE
