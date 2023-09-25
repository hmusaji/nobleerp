
namespace Xtreme
{
	partial class frmPayBillingDetails
	{

		#region "Upgrade Support "
		private static frmPayBillingDetails m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmPayBillingDetails DefInstance
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
		public static frmPayBillingDetails CreateInstance()
		{
			frmPayBillingDetails theInstance = new frmPayBillingDetails();
			
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
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "Column_0_grdVoucherDetails", "Column_1_grdVoucherDetails", "grdVoucherDetails", "Column_0_cmbMastersList", "Column_1_cmbMastersList", "cmbMastersList", "cntMasterDetails", "lblSystemComponents", "_lblCommonLabel_2", "_txtDisplayLabel_0", "_txtDisplayLabel_1", "Line1", "lblCommonLabel", "txtDisplayLabel"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_0_grdVoucherDetails;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_1_grdVoucherDetails;
		public C1.Win.C1TrueDBGrid.C1TrueDBGrid grdVoucherDetails;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_0_cmbMastersList;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_1_cmbMastersList;
		public C1.Win.C1TrueDBGrid.C1TrueDBDropdown cmbMastersList;
		public AxTDBContainer3D6.AxTDBContainer3D cntMasterDetails;
		public System.Windows.Forms.Label lblSystemComponents;
		private System.Windows.Forms.Label _lblCommonLabel_2;
		private System.Windows.Forms.Label _txtDisplayLabel_0;
		private System.Windows.Forms.Label _txtDisplayLabel_1;
		public System.Windows.Forms.Label Line1;
		public System.Windows.Forms.Label[] lblCommonLabel = new System.Windows.Forms.Label[3];
		public System.Windows.Forms.Label[] txtDisplayLabel = new System.Windows.Forms.Label[2];
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPayBillingDetails));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this.cntMasterDetails = new AxTDBContainer3D6.AxTDBContainer3D();
			this.grdVoucherDetails = new C1.Win.C1TrueDBGrid.C1TrueDBGrid();
			this.Column_0_grdVoucherDetails = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.Column_1_grdVoucherDetails = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.cmbMastersList = new C1.Win.C1TrueDBGrid.C1TrueDBDropdown();
			this.Column_0_cmbMastersList = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.Column_1_cmbMastersList = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.lblSystemComponents = new System.Windows.Forms.Label();
			this._lblCommonLabel_2 = new System.Windows.Forms.Label();
			this._txtDisplayLabel_0 = new System.Windows.Forms.Label();
			this._txtDisplayLabel_1 = new System.Windows.Forms.Label();
			this.Line1 = new System.Windows.Forms.Label();
			// //((System.ComponentModel.ISupportInitialize) this.cntMasterDetails).BeginInit();
			this.cntMasterDetails.SuspendLayout();
			this.grdVoucherDetails.SuspendLayout();
			this.cmbMastersList.SuspendLayout();
			this.SuspendLayout();
			// 
			// cntMasterDetails
			// 
			this.cntMasterDetails.AllowDrop = true;
			this.cntMasterDetails.Controls.Add(this.grdVoucherDetails);
			this.cntMasterDetails.Controls.Add(this.cmbMastersList);
			this.cntMasterDetails.Location = new System.Drawing.Point(4, 112);
			this.cntMasterDetails.Name = "cntMasterDetails";
			("cntMasterDetails.OcxState");
			this.cntMasterDetails.Size = new System.Drawing.Size(743, 276);
			this.cntMasterDetails.TabIndex = 0;
			// 
			// grdVoucherDetails
			// 
			this.grdVoucherDetails.AllowDrop = true;
			this.grdVoucherDetails.BackColor = System.Drawing.Color.Silver;
			this.grdVoucherDetails.CellTipsWidth = 0;
			this.grdVoucherDetails.Location = new System.Drawing.Point(0, 0);
			this.grdVoucherDetails.Name = "grdVoucherDetails";
			this.grdVoucherDetails.RowDivider.Color = System.Drawing.Color.Silver;
			this.grdVoucherDetails.Size = new System.Drawing.Size(737, 270);
			this.grdVoucherDetails.TabIndex = 1;
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
			// cmbMastersList
			// 
			this.cmbMastersList.AllowDrop = true;
			this.cmbMastersList.ColumnHeaders = true;
			this.cmbMastersList.Enabled = true;
			this.cmbMastersList.Location = new System.Drawing.Point(30, 200);
			this.cmbMastersList.Name = "cmbMastersList";
			this.cmbMastersList.Size = new System.Drawing.Size(53, 37);
			this.cmbMastersList.TabIndex = 2;
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
			// lblSystemComponents
			// 
			this.lblSystemComponents.AllowDrop = true;
			this.lblSystemComponents.BackColor = System.Drawing.Color.FromArgb(227, 226, 219);
			this.lblSystemComponents.Text = " Earnings && Deductions Information ";
			this.lblSystemComponents.Location = new System.Drawing.Point(14, 86);
			// // this.lblSystemComponents.mLabelId = 1040;
			this.lblSystemComponents.Name = "lblSystemComponents";
			this.lblSystemComponents.Size = new System.Drawing.Size(203, 13);
			this.lblSystemComponents.TabIndex = 3;
			// 
			// _lblCommonLabel_2
			// 
			this._lblCommonLabel_2.AllowDrop = true;
			this._lblCommonLabel_2.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_2.Text = "Employee Code";
			this._lblCommonLabel_2.Location = new System.Drawing.Point(20, 56);
			// // this._lblCommonLabel_2.mLabelId = 236;
			this._lblCommonLabel_2.Name = "_lblCommonLabel_2";
			this._lblCommonLabel_2.Size = new System.Drawing.Size(74, 14);
			this._lblCommonLabel_2.TabIndex = 4;
			// 
			// _txtDisplayLabel_0
			// 
			this._txtDisplayLabel_0.AllowDrop = true;
			this._txtDisplayLabel_0.Location = new System.Drawing.Point(112, 54);
			this._txtDisplayLabel_0.Name = "_txtDisplayLabel_0";
			this._txtDisplayLabel_0.Size = new System.Drawing.Size(101, 19);
			this._txtDisplayLabel_0.TabIndex = 5;
			// 
			// _txtDisplayLabel_1
			// 
			this._txtDisplayLabel_1.AllowDrop = true;
			this._txtDisplayLabel_1.Location = new System.Drawing.Point(215, 54);
			this._txtDisplayLabel_1.Name = "_txtDisplayLabel_1";
			this._txtDisplayLabel_1.Size = new System.Drawing.Size(201, 19);
			this._txtDisplayLabel_1.TabIndex = 6;
			// 
			// Line1
			// 
			this.Line1.AllowDrop = true;
			this.Line1.BackColor = System.Drawing.SystemColors.WindowText;
			this.Line1.Enabled = false;
			this.Line1.Location = new System.Drawing.Point(0, 92);
			this.Line1.Name = "Line1";
			this.Line1.Size = new System.Drawing.Size(748, 1);
			this.Line1.Visible = true;
			// 
			// frmPayBillingDetails
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.ClientSize = new System.Drawing.Size(750, 389);
			this.Controls.Add(this.cntMasterDetails);
			this.Controls.Add(this.lblSystemComponents);
			this.Controls.Add(this._lblCommonLabel_2);
			this.Controls.Add(this._txtDisplayLabel_0);
			this.Controls.Add(this._txtDisplayLabel_1);
			this.Controls.Add(this.Line1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			//this.Icon = (System.Drawing.Icon) resources.GetObject("frmPayBillingDetails.Icon");
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(121, 127);
			this.MaximizeBox = true;
			this.MinimizeBox = true;
			this.Name = "frmPayBillingDetails";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Tag = "\"H: 6225  W:9570\"";
			this.Text = "Fixed Earnings & Deductions";
			// this.Activated += new System.EventHandler(this.Form_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
			// this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
			//((System.ComponentModel.ISupportInitialize) this.cntMasterDetails).EndInit();
			this.cntMasterDetails.ResumeLayout(false);
			this.grdVoucherDetails.ResumeLayout(false);
			this.cmbMastersList.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		// 
		void InitializetxtDisplayLabel()
		{
			this.txtDisplayLabel = new System.Windows.Forms.Label[2];
			this.txtDisplayLabel[0] = _txtDisplayLabel_0;
			this.txtDisplayLabel[1] = _txtDisplayLabel_1;
		}
		void InitializelblCommonLabel()
		{
			this.lblCommonLabel = new System.Windows.Forms.Label[3];
			this.lblCommonLabel[2] = _lblCommonLabel_2;
		}
		#endregion
	}
}//ENDSHERE
