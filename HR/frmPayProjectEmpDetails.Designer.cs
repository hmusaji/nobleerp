
namespace Xtreme
{
	partial class frmPayProjectEmpDetails
	{

		#region "Upgrade Support "
		private static frmPayProjectEmpDetails m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmPayProjectEmpDetails DefInstance
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
		public static frmPayProjectEmpDetails CreateInstance()
		{
			frmPayProjectEmpDetails theInstance = new frmPayProjectEmpDetails();
			
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
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "Column_0_cmbMastersList", "Column_1_cmbMastersList", "cmbMastersList", "Column_0_grdVoucherDetails", "Column_1_grdVoucherDetails", "grdVoucherDetails", "_lblCommonLabel_0", "_txtDisplayLabel_0", "_txtDisplayLabel_1", "Line1", "lblCommonLabel", "txtDisplayLabel"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_0_cmbMastersList;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_1_cmbMastersList;
		public C1.Win.C1TrueDBGrid.C1TrueDBDropdown cmbMastersList;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_0_grdVoucherDetails;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_1_grdVoucherDetails;
		public C1.Win.C1TrueDBGrid.C1TrueDBGrid grdVoucherDetails;
		private System.Windows.Forms.Label _lblCommonLabel_0;
		private System.Windows.Forms.Label _txtDisplayLabel_0;
		private System.Windows.Forms.Label _txtDisplayLabel_1;
		public System.Windows.Forms.Label Line1;
		public System.Windows.Forms.Label[] lblCommonLabel = new System.Windows.Forms.Label[1];
		public System.Windows.Forms.Label[] txtDisplayLabel = new System.Windows.Forms.Label[2];
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPayProjectEmpDetails));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this.cmbMastersList = new C1.Win.C1TrueDBGrid.C1TrueDBDropdown();
			this.Column_0_cmbMastersList = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.Column_1_cmbMastersList = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.grdVoucherDetails = new C1.Win.C1TrueDBGrid.C1TrueDBGrid();
			this.Column_0_grdVoucherDetails = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.Column_1_grdVoucherDetails = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this._lblCommonLabel_0 = new System.Windows.Forms.Label();
			this._txtDisplayLabel_0 = new System.Windows.Forms.Label();
			this._txtDisplayLabel_1 = new System.Windows.Forms.Label();
			this.Line1 = new System.Windows.Forms.Label();
			//this.cmbMastersList.SuspendLayout();
			//this.grdVoucherDetails.SuspendLayout();
			this.SuspendLayout();
			// 
			// cmbMastersList
			// 
			//this.cmbMastersList.AllowDrop = true;
			this.cmbMastersList.ColumnHeaders = true;
			this.cmbMastersList.Enabled = true;
			this.cmbMastersList.Location = new System.Drawing.Point(99, 210);
			this.cmbMastersList.Name = "cmbMastersList";
			this.cmbMastersList.Size = new System.Drawing.Size(53, 37);
			this.cmbMastersList.TabIndex = 4;
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
			// grdVoucherDetails
			// 
			this.grdVoucherDetails.AllowAddNew = true;
			//this.grdVoucherDetails.AllowDrop = true;
			this.grdVoucherDetails.BackColor = System.Drawing.Color.Silver;
			this.grdVoucherDetails.CellTipsWidth = 0;
			this.grdVoucherDetails.Location = new System.Drawing.Point(2, 97);
			this.grdVoucherDetails.Name = "grdVoucherDetails";
			this.grdVoucherDetails.RowDivider.Color = System.Drawing.Color.Silver;
			this.grdVoucherDetails.Size = new System.Drawing.Size(498, 226);
			this.grdVoucherDetails.TabIndex = 0;
			this.grdVoucherDetails.Columns.Add(this.Column_0_grdVoucherDetails);
			this.grdVoucherDetails.Columns.Add(this.Column_1_grdVoucherDetails);
			//this.grdVoucherDetails.AfterColUpdate += new C1.Win.C1TrueDBGrid.ColEventHandler(this.grdVoucherDetails_AfterColUpdate);
			//this.grdVoucherDetails.BeforeColUpdate += new C1.Win.C1TrueDBGrid.BeforeColUpdateEventHandler(this.grdVoucherDetails_BeforeColUpdate);
			//this.grdVoucherDetails.ButtonClick += new C1.Win.C1TrueDBGrid.ColEventHandler(this.grdVoucherDetails_ButtonClick);
			//this.grdVoucherDetails.GotFocus += new System.EventHandler(this.grdVoucherDetails_GotFocus);
			//this.grdVoucherDetails.RowColChange += new C1.Win.C1TrueDBGrid.RowColChangeEventHandler(this.grdVoucherDetails_RowColChange);
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
			// _lblCommonLabel_0
			// 
			//this._lblCommonLabel_0.AllowDrop = true;
			this._lblCommonLabel_0.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_0.Text = "Employee Code";
			this._lblCommonLabel_0.Location = new System.Drawing.Point(0, 64);
			// // this._lblCommonLabel_0.mLabelId = 236;
			this._lblCommonLabel_0.Name = "_lblCommonLabel_0";
			this._lblCommonLabel_0.Size = new System.Drawing.Size(74, 14);
			this._lblCommonLabel_0.TabIndex = 1;
			// 
			// _txtDisplayLabel_0
			// 
			//this._txtDisplayLabel_0.AllowDrop = true;
			this._txtDisplayLabel_0.Location = new System.Drawing.Point(92, 63);
			this._txtDisplayLabel_0.Name = "_txtDisplayLabel_0";
			this._txtDisplayLabel_0.Size = new System.Drawing.Size(101, 19);
			this._txtDisplayLabel_0.TabIndex = 2;
			// 
			// _txtDisplayLabel_1
			// 
			//this._txtDisplayLabel_1.AllowDrop = true;
			this._txtDisplayLabel_1.Location = new System.Drawing.Point(195, 63);
			this._txtDisplayLabel_1.Name = "_txtDisplayLabel_1";
			this._txtDisplayLabel_1.Size = new System.Drawing.Size(288, 19);
			this._txtDisplayLabel_1.TabIndex = 3;
			// 
			// Line1
			// 
			//this.Line1.AllowDrop = true;
			this.Line1.BackColor = System.Drawing.SystemColors.WindowText;
			this.Line1.Enabled = false;
			this.Line1.Location = new System.Drawing.Point(0, 93);
			this.Line1.Name = "Line1";
			this.Line1.Size = new System.Drawing.Size(500, 1);
			this.Line1.Visible = true;
			// 
			// frmPayProjectEmpDetails
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.ClientSize = new System.Drawing.Size(504, 323);
			this.Controls.Add(this.cmbMastersList);
			this.Controls.Add(this.grdVoucherDetails);
			this.Controls.Add(this._lblCommonLabel_0);
			this.Controls.Add(this._txtDisplayLabel_0);
			this.Controls.Add(this._txtDisplayLabel_1);
			this.Controls.Add(this.Line1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			//this.Icon = (System.Drawing.Icon) resources.GetObject("frmPayProjectEmpDetails.Icon");
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(223, 146);
			this.MaximizeBox = true;
			this.MinimizeBox = true;
			this.Name = "frmPayProjectEmpDetails";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Project Employee Details";
			// this.Activated += new System.EventHandler(this.frmPayProjectEmpDetails_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
			// this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
			this.cmbMastersList.ResumeLayout(false);
			this.grdVoucherDetails.ResumeLayout(false);
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
			this.lblCommonLabel = new System.Windows.Forms.Label[1];
			this.lblCommonLabel[0] = _lblCommonLabel_0;
		}
		#endregion
	}
}//ENDSHERE
