
namespace Xtreme
{
	partial class frmICSProductBarcode
	{

		#region "Upgrade Support "
		private static frmICSProductBarcode m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmICSProductBarcode DefInstance
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
		public static frmICSProductBarcode CreateInstance()
		{
			frmICSProductBarcode theInstance = new frmICSProductBarcode();
			
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
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "Column_0_cmbCommon", "Column_1_cmbCommon", "cmbCommon", "txtProductCode", "lblLedgerNo", "grdVoucherDetails", "txtProductName", "Line1", "cntMasterDetails"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_0_cmbCommon;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_1_cmbCommon;
		public C1.Win.C1TrueDBGrid.C1TrueDBDropdown cmbCommon;
		public System.Windows.Forms.TextBox txtProductCode;
		public System.Windows.Forms.Label lblLedgerNo;
		public C1.Win.C1TrueDBGrid.C1TrueDBGrid grdVoucherDetails;
		public System.Windows.Forms.Label txtProductName;
		public System.Windows.Forms.Label Line1;
		public System.Windows.Forms.Panel cntMasterDetails;
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmICSProductBarcode));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this.cntMasterDetails = new System.Windows.Forms.Panel();
			this.cmbCommon = new C1.Win.C1TrueDBGrid.C1TrueDBDropdown();
			this.Column_0_cmbCommon = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.Column_1_cmbCommon = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.txtProductCode = new System.Windows.Forms.TextBox();
			this.lblLedgerNo = new System.Windows.Forms.Label();
			this.grdVoucherDetails = new C1.Win.C1TrueDBGrid.C1TrueDBGrid();
			this.txtProductName = new System.Windows.Forms.Label();
			this.Line1 = new System.Windows.Forms.Label();
			// //((System.ComponentModel.ISupportInitialize) this.cntMasterDetails).BeginInit();
			//this.cntMasterDetails.SuspendLayout();
			//this.cmbCommon.SuspendLayout();
			this.SuspendLayout();
			// 
			// cntMasterDetails
			// 
			//this.cntMasterDetails.AllowDrop = true;
			this.cntMasterDetails.Controls.Add(this.cmbCommon);
			this.cntMasterDetails.Controls.Add(this.txtProductCode);
			this.cntMasterDetails.Controls.Add(this.lblLedgerNo);
			this.cntMasterDetails.Controls.Add(this.grdVoucherDetails);
			this.cntMasterDetails.Controls.Add(this.txtProductName);
			this.cntMasterDetails.Controls.Add(this.Line1);
			this.cntMasterDetails.Location = new System.Drawing.Point(4, 12);
			this.cntMasterDetails.Name = "cntMasterDetails";
			//
			this.cntMasterDetails.Size = new System.Drawing.Size(511, 220);
			this.cntMasterDetails.TabIndex = 1;
			// 
			// cmbCommon
			// 
			//this.cmbCommon.AllowDrop = true;
			this.cmbCommon.ColumnHeaders = true;
			this.cmbCommon.Enabled = true;
			this.cmbCommon.Location = new System.Drawing.Point(280, 64);
			this.cmbCommon.Name = "cmbCommon";
			this.cmbCommon.Size = new System.Drawing.Size(213, 93);
			this.cmbCommon.TabIndex = 4;
			this.cmbCommon.Columns.Add(this.Column_0_cmbCommon);
			this.cmbCommon.Columns.Add(this.Column_1_cmbCommon);
			// 
			// Column_0_cmbCommon
			// 
			this.Column_0_cmbCommon.DataField = "";
			this.Column_0_cmbCommon.ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.Normal;
			// 
			// Column_1_cmbCommon
			// 
			this.Column_1_cmbCommon.DataField = "";
			this.Column_1_cmbCommon.ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.Normal;
			// 
			// txtProductCode
			// 
			//this.txtProductCode.AllowDrop = true;
			this.txtProductCode.BackColor = System.Drawing.Color.White;
			this.txtProductCode.ForeColor = System.Drawing.Color.Black;
			this.txtProductCode.Location = new System.Drawing.Point(82, 13);
			this.txtProductCode.MaxLength = 50;
			this.txtProductCode.Name = "txtProductCode";
			// this.txtProductCode.ShowButton = true;
			this.txtProductCode.Size = new System.Drawing.Size(101, 19);
			this.txtProductCode.TabIndex = 0;
			this.txtProductCode.Text = "";
			// this.txtProductCode.Leave += new System.EventHandler(this.txtProductCode_Leave);
			// 
			// lblLedgerNo
			// 
			//this.lblLedgerNo.AllowDrop = true;
			this.lblLedgerNo.BackColor = System.Drawing.SystemColors.Window;
			this.lblLedgerNo.Text = "Product Code";
			this.lblLedgerNo.Location = new System.Drawing.Point(7, 15);
			this.lblLedgerNo.Name = "lblLedgerNo";
			this.lblLedgerNo.Size = new System.Drawing.Size(65, 14);
			this.lblLedgerNo.TabIndex = 2;
			// 
			// grdVoucherDetails
			// 
			//this.grdVoucherDetails.AllowDrop = true;
			this.grdVoucherDetails.BackColor = System.Drawing.Color.Silver;
			//this.grdVoucherDetails.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.grdVoucherDetails.CellTipsWidth = 0;
			this.grdVoucherDetails.Location = new System.Drawing.Point(0, 56);
			this.grdVoucherDetails.Name = "grdVoucherDetails";
			this.grdVoucherDetails.RowDivider.Color = System.Drawing.Color.Silver;
			this.grdVoucherDetails.Size = new System.Drawing.Size(507, 160);
			this.grdVoucherDetails.TabIndex = 3;
			//this.grdVoucherDetails.GotFocus += new System.EventHandler(this.grdVoucherDetails_GotFocus);
			// 
			// txtProductName
			// 
			//this.txtProductName.AllowDrop = true;
			this.txtProductName.Location = new System.Drawing.Point(190, 13);
			this.txtProductName.Name = "txtProductName";
			this.txtProductName.Size = new System.Drawing.Size(241, 19);
			this.txtProductName.TabIndex = 5;
			// 
			// Line1
			// 
			//this.Line1.AllowDrop = true;
			this.Line1.BackColor = System.Drawing.SystemColors.WindowText;
			this.Line1.Enabled = false;
			this.Line1.Location = new System.Drawing.Point(0, 44);
			this.Line1.Name = "Line1";
			this.Line1.Size = new System.Drawing.Size(506, 1);
			this.Line1.Visible = true;
			// 
			// frmICSProductBarcode
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.ClientSize = new System.Drawing.Size(518, 269);
			this.Controls.Add(this.cntMasterDetails);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			//this.Icon = (System.Drawing.Icon) resources.GetObject("frmICSProductBarcode.Icon");
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(72, 144);
			this.MaximizeBox = true;
			this.MinimizeBox = true;
			this.Name = "frmICSProductBarcode";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Product Barcode Details";
			// this.Activated += new System.EventHandler(this.frmICSProductBarcode_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
			// this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
			//((System.ComponentModel.ISupportInitialize) this.cntMasterDetails).EndInit();
			this.cntMasterDetails.ResumeLayout(false);
			this.cmbCommon.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		// 
		#endregion
	}
}//ENDSHERE
