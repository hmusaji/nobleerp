
namespace Xtreme
{
	partial class frmICSReplacementProduct
	{

		#region "Upgrade Support "
		private static frmICSReplacementProduct m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmICSReplacementProduct DefInstance
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
		public static frmICSReplacementProduct CreateInstance()
		{
			frmICSReplacementProduct theInstance = new frmICSReplacementProduct();
			
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
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "grdVoucherDetails", "cntMasterDetails", "txtProductCode", "lblLedgerNo", "Column_0_cmbCommon", "Column_1_cmbCommon", "cmbCommon", "txtProductName", "Line1"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public C1.Win.C1TrueDBGrid.C1TrueDBGrid grdVoucherDetails;
		public System.Windows.Forms.Panel cntMasterDetails;
		public System.Windows.Forms.TextBox txtProductCode;
		public System.Windows.Forms.Label lblLedgerNo;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_0_cmbCommon;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_1_cmbCommon;
		public C1.Win.C1TrueDBGrid.C1TrueDBDropdown cmbCommon;
		public System.Windows.Forms.Label txtProductName;
		public System.Windows.Forms.Label Line1;
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmICSReplacementProduct));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this.cntMasterDetails = new System.Windows.Forms.Panel();
			this.grdVoucherDetails = new C1.Win.C1TrueDBGrid.C1TrueDBGrid();
			this.txtProductCode = new System.Windows.Forms.TextBox();
			this.lblLedgerNo = new System.Windows.Forms.Label();
			this.cmbCommon = new C1.Win.C1TrueDBGrid.C1TrueDBDropdown();
			this.Column_0_cmbCommon = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.Column_1_cmbCommon = new C1.Win.C1TrueDBGrid.C1DataColumn();
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
			this.cntMasterDetails.Controls.Add(this.grdVoucherDetails);
			this.cntMasterDetails.Location = new System.Drawing.Point(2, 98);
			this.cntMasterDetails.Name = "cntMasterDetails";
			//
			this.cntMasterDetails.Size = new System.Drawing.Size(525, 178);
			this.cntMasterDetails.TabIndex = 2;
			// 
			// grdVoucherDetails
			// 
			//this.grdVoucherDetails.AllowDrop = true;
			this.grdVoucherDetails.BackColor = System.Drawing.Color.Silver;
			//this.grdVoucherDetails.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.grdVoucherDetails.CellTipsWidth = 0;
			this.grdVoucherDetails.Location = new System.Drawing.Point(0, 0);
			this.grdVoucherDetails.Name = "grdVoucherDetails";
			this.grdVoucherDetails.RowDivider.Color = System.Drawing.Color.Silver;
			this.grdVoucherDetails.Size = new System.Drawing.Size(521, 174);
			this.grdVoucherDetails.TabIndex = 1;
			//this.grdVoucherDetails.GotFocus += new System.EventHandler(this.grdVoucherDetails_GotFocus);
			// 
			// txtProductCode
			// 
			//this.txtProductCode.AllowDrop = true;
			this.txtProductCode.BackColor = System.Drawing.Color.FromArgb(239, 239, 239);
			this.txtProductCode.Enabled = false;
			this.txtProductCode.ForeColor = System.Drawing.Color.Black;
			this.txtProductCode.Location = new System.Drawing.Point(93, 54);
			this.txtProductCode.MaxLength = 50;
			this.txtProductCode.Name = "txtProductCode";
			this.txtProductCode.Size = new System.Drawing.Size(101, 19);
			this.txtProductCode.TabIndex = 0;
			this.txtProductCode.Text = "";
			// this.// = "";
			// this.txtProductCode.Leave += new System.EventHandler(this.txtProductCode_Leave);
			// 
			// lblLedgerNo
			// 
			//this.lblLedgerNo.AllowDrop = true;
			this.lblLedgerNo.BackColor = System.Drawing.SystemColors.Window;
			this.lblLedgerNo.Text = "Product Code";
			this.lblLedgerNo.ForeColor = System.Drawing.Color.Black;
			this.lblLedgerNo.Location = new System.Drawing.Point(8, 56);
			// // this.lblLedgerNo.mLabelId = 545;
			this.lblLedgerNo.Name = "lblLedgerNo";
			this.lblLedgerNo.Size = new System.Drawing.Size(65, 14);
			this.lblLedgerNo.TabIndex = 3;
			// 
			// cmbCommon
			// 
			//this.cmbCommon.AllowDrop = true;
			this.cmbCommon.ColumnHeaders = true;
			this.cmbCommon.Enabled = true;
			this.cmbCommon.Location = new System.Drawing.Point(468, 50);
			this.cmbCommon.Name = "cmbCommon";
			this.cmbCommon.Size = new System.Drawing.Size(33, 25);
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
			// txtProductName
			// 
			//this.txtProductName.AllowDrop = true;
			this.txtProductName.Enabled = false;
			this.txtProductName.Location = new System.Drawing.Point(196, 54);
			this.txtProductName.Name = "txtProductName";
			this.txtProductName.Size = new System.Drawing.Size(201, 19);
			this.txtProductName.TabIndex = 5;
			// 
			// Line1
			// 
			//this.Line1.AllowDrop = true;
			this.Line1.BackColor = System.Drawing.SystemColors.WindowText;
			this.Line1.Enabled = false;
			this.Line1.Location = new System.Drawing.Point(0, 86);
			this.Line1.Name = "Line1";
			this.Line1.Size = new System.Drawing.Size(535, 1);
			this.Line1.Visible = true;
			// 
			// frmICSReplacementProduct
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.ClientSize = new System.Drawing.Size(531, 279);
			this.Controls.Add(this.cntMasterDetails);
			this.Controls.Add(this.txtProductCode);
			this.Controls.Add(this.lblLedgerNo);
			this.Controls.Add(this.cmbCommon);
			this.Controls.Add(this.txtProductName);
			this.Controls.Add(this.Line1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			//this.Icon = (System.Drawing.Icon) resources.GetObject("frmICSReplacementProduct.Icon");
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(115, 200);
			this.MaximizeBox = true;
			this.MinimizeBox = true;
			this.Name = "frmICSReplacementProduct";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Tag = "False";
			this.Text = "Replacement Product ";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			// this.Activated += new System.EventHandler(this.frmICSReplacementProduct_Activated);
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
