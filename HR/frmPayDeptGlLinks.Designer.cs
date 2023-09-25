
namespace Xtreme
{
	partial class frmPayDeptGlLinks
	{

		#region "Upgrade Support "
		private static frmPayDeptGlLinks m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmPayDeptGlLinks DefInstance
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
		public static frmPayDeptGlLinks CreateInstance()
		{
			frmPayDeptGlLinks theInstance = new frmPayDeptGlLinks();
			
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
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "cmdUpdateEmpGLLink", "Column_0_cmbMastersList", "Column_1_cmbMastersList", "cmbMastersList", "txtDeptCode", "_lblCommon_5", "txtDeptName", "Column_0_grdVoucherDetails", "Column_1_grdVoucherDetails", "grdVoucherDetails", "Line1", "lblCommon"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public System.Windows.Forms.Button cmdUpdateEmpGLLink;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_0_cmbMastersList;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_1_cmbMastersList;
		public C1.Win.C1TrueDBGrid.C1TrueDBDropdown cmbMastersList;
		public System.Windows.Forms.TextBox txtDeptCode;
		private System.Windows.Forms.Label _lblCommon_5;
		public System.Windows.Forms.Label txtDeptName;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_0_grdVoucherDetails;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_1_grdVoucherDetails;
		public C1.Win.C1TrueDBGrid.C1TrueDBGrid grdVoucherDetails;
		public System.Windows.Forms.Label Line1;
		public System.Windows.Forms.Label[] lblCommon = new System.Windows.Forms.Label[6];
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPayDeptGlLinks));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this.cmdUpdateEmpGLLink = new System.Windows.Forms.Button();
			this.cmbMastersList = new C1.Win.C1TrueDBGrid.C1TrueDBDropdown();
			this.Column_0_cmbMastersList = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.Column_1_cmbMastersList = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.txtDeptCode = new System.Windows.Forms.TextBox();
			this._lblCommon_5 = new System.Windows.Forms.Label();
			this.txtDeptName = new System.Windows.Forms.Label();
			this.grdVoucherDetails = new C1.Win.C1TrueDBGrid.C1TrueDBGrid();
			this.Column_0_grdVoucherDetails = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.Column_1_grdVoucherDetails = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.Line1 = new System.Windows.Forms.Label();
			this.cmbMastersList.SuspendLayout();
			this.grdVoucherDetails.SuspendLayout();
			this.SuspendLayout();
			// 
			// cmdUpdateEmpGLLink
			// 
			this.cmdUpdateEmpGLLink.AllowDrop = true;
			this.cmdUpdateEmpGLLink.BackColor = System.Drawing.SystemColors.Control;
			this.cmdUpdateEmpGLLink.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdUpdateEmpGLLink.Location = new System.Drawing.Point(760, 44);
			this.cmdUpdateEmpGLLink.Name = "cmdUpdateEmpGLLink";
			this.cmdUpdateEmpGLLink.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdUpdateEmpGLLink.Size = new System.Drawing.Size(123, 27);
			this.cmdUpdateEmpGLLink.TabIndex = 4;
			this.cmdUpdateEmpGLLink.Text = "Update Employee GL Link";
			this.cmdUpdateEmpGLLink.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.cmdUpdateEmpGLLink.UseVisualStyleBackColor = false;
			// this.cmdUpdateEmpGLLink.Click += new System.EventHandler(this.cmdUpdateEmpGLLink_Click);
			// 
			// cmbMastersList
			// 
			this.cmbMastersList.AllowDrop = true;
			this.cmbMastersList.ColumnHeaders = true;
			this.cmbMastersList.Enabled = true;
			this.cmbMastersList.Location = new System.Drawing.Point(27, 141);
			this.cmbMastersList.Name = "cmbMastersList";
			this.cmbMastersList.Size = new System.Drawing.Size(333, 133);
			this.cmbMastersList.TabIndex = 0;
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
			// txtDeptCode
			// 
			this.txtDeptCode.AllowDrop = true;
			this.txtDeptCode.BackColor = System.Drawing.Color.FromArgb(239, 239, 239);
			// this.txtDeptCode.bolNumericOnly = true;
			this.txtDeptCode.Enabled = false;
			this.txtDeptCode.ForeColor = System.Drawing.Color.Black;
			this.txtDeptCode.Location = new System.Drawing.Point(96, 45);
			this.txtDeptCode.MaxLength = 15;
			this.txtDeptCode.Name = "txtDeptCode";
			this.txtDeptCode.Size = new System.Drawing.Size(101, 19);
			this.txtDeptCode.TabIndex = 1;
			this.txtDeptCode.Text = "";
			// 
			// _lblCommon_5
			// 
			this._lblCommon_5.AllowDrop = true;
			this._lblCommon_5.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_5.Text = "Department Code";
			this._lblCommon_5.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_5.Location = new System.Drawing.Point(9, 47);
			// this._lblCommon_5.mLabelId = 211;
			this._lblCommon_5.Name = "_lblCommon_5";
			this._lblCommon_5.Size = new System.Drawing.Size(83, 14);
			this._lblCommon_5.TabIndex = 2;
			// 
			// txtDeptName
			// 
			this.txtDeptName.AllowDrop = true;
			this.txtDeptName.Location = new System.Drawing.Point(199, 45);
			this.txtDeptName.Name = "txtDeptName";
			this.txtDeptName.Size = new System.Drawing.Size(201, 19);
			this.txtDeptName.TabIndex = 3;
			// 
			// grdVoucherDetails
			// 
			this.grdVoucherDetails.AllowDrop = true;
			this.grdVoucherDetails.BackColor = System.Drawing.Color.FromArgb(212, 208, 200);
			this.grdVoucherDetails.CellTipsWidth = 0;
			this.grdVoucherDetails.Enabled = false;
			this.grdVoucherDetails.Location = new System.Drawing.Point(4, 84);
			this.grdVoucherDetails.Name = "grdVoucherDetails";
			this.grdVoucherDetails.RowDivider.Color = System.Drawing.Color.FromArgb(212, 208, 200);
			this.grdVoucherDetails.Size = new System.Drawing.Size(879, 461);
			this.grdVoucherDetails.TabIndex = 5;
			this.grdVoucherDetails.Columns.Add(this.Column_0_grdVoucherDetails);
			this.grdVoucherDetails.Columns.Add(this.Column_1_grdVoucherDetails);
			this.grdVoucherDetails.BeforeColEdit += new C1.Win.C1TrueDBGrid.BeforeColEditEventHandler(this.grdVoucherDetails_BeforeColEdit);
			this.grdVoucherDetails.GotFocus += new System.EventHandler(this.grdVoucherDetails_GotFocus);
			// this.this.grdVoucherDetails.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.grdVoucherDetails_KeyPress);
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
			// Line1
			// 
			this.Line1.AllowDrop = true;
			this.Line1.BackColor = System.Drawing.Color.Red;
			this.Line1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Line1.Enabled = false;
			this.Line1.ForeColor = System.Drawing.Color.Black;
			this.Line1.Location = new System.Drawing.Point(0, 74);
			this.Line1.Name = "Line1";
			this.Line1.Size = new System.Drawing.Size(880, 1);
			this.Line1.Text = "Line1";
			this.Line1.Visible = true;
			// 
			// frmPayDeptGlLinks
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.ClientSize = new System.Drawing.Size(890, 551);
			this.Controls.Add(this.cmdUpdateEmpGLLink);
			this.Controls.Add(this.cmbMastersList);
			this.Controls.Add(this.txtDeptCode);
			this.Controls.Add(this._lblCommon_5);
			this.Controls.Add(this.txtDeptName);
			this.Controls.Add(this.grdVoucherDetails);
			this.Controls.Add(this.Line1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			//this.Icon = (System.Drawing.Icon) resources.GetObject("frmPayDeptGlLinks.Icon");
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(110, 95);
			this.MaximizeBox = true;
			this.MinimizeBox = true;
			this.Name = "frmPayDeptGlLinks";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Department GL Links";
			// this.Activated += new System.EventHandler(this.Form_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
			// this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
			this.cmbMastersList.ResumeLayout(false);
			this.grdVoucherDetails.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		void ReLoadForm(bool addEvents)
		{
			InitializelblCommon();
			//This form is an MDI child.
			//This code simulates the VB6 
			// functionality of automatically
			// loading and showing an MDI
			// child's parent.
			this.MdiParent = Xtreme.frmSysMain.DefInstance;
			Xtreme.frmSysMain.DefInstance.Show();
		}
		void InitializelblCommon()
		{
			this.lblCommon = new System.Windows.Forms.Label[6];
			this.lblCommon[5] = _lblCommon_5;
		}
		#endregion
	}
}