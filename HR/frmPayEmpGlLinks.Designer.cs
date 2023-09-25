
namespace Xtreme
{
	partial class frmPayEmpGlLinks
	{

		#region "Upgrade Support "
		private static frmPayEmpGlLinks m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmPayEmpGlLinks DefInstance
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
		public static frmPayEmpGlLinks CreateInstance()
		{
			frmPayEmpGlLinks theInstance = new frmPayEmpGlLinks();
			
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
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "cmdEmpGL", "cmdUpdateEmpGLLink", "Line2", "Label1", "frmGLLink", "Column_0_cmbMastersList", "Column_1_cmbMastersList", "cmbMastersList", "txtEmpCode", "_lblCommon_5", "txtEmpName", "Column_0_grdVoucherDetails", "Column_1_grdVoucherDetails", "grdVoucherDetails", "Line1", "lblCommon"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public System.Windows.Forms.Button cmdEmpGL;
		public System.Windows.Forms.Button cmdUpdateEmpGLLink;
		public System.Windows.Forms.Label Line2;
		public System.Windows.Forms.Label Label1;
		public System.Windows.Forms.GroupBox frmGLLink;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_0_cmbMastersList;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_1_cmbMastersList;
		public C1.Win.C1TrueDBGrid.C1TrueDBDropdown cmbMastersList;
		public System.Windows.Forms.TextBox txtEmpCode;
		private System.Windows.Forms.Label _lblCommon_5;
		public System.Windows.Forms.Label txtEmpName;
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
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPayEmpGlLinks));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this.frmGLLink = new System.Windows.Forms.GroupBox();
			this.cmdEmpGL = new System.Windows.Forms.Button();
			this.cmdUpdateEmpGLLink = new System.Windows.Forms.Button();
			this.Line2 = new System.Windows.Forms.Label();
			this.Label1 = new System.Windows.Forms.Label();
			this.cmbMastersList = new C1.Win.C1TrueDBGrid.C1TrueDBDropdown();
			this.Column_0_cmbMastersList = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.Column_1_cmbMastersList = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.txtEmpCode = new System.Windows.Forms.TextBox();
			this._lblCommon_5 = new System.Windows.Forms.Label();
			this.txtEmpName = new System.Windows.Forms.Label();
			this.grdVoucherDetails = new C1.Win.C1TrueDBGrid.C1TrueDBGrid();
			this.Column_0_grdVoucherDetails = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.Column_1_grdVoucherDetails = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.Line1 = new System.Windows.Forms.Label();
			//this.frmGLLink.SuspendLayout();
			//this.cmbMastersList.SuspendLayout();
			//this.grdVoucherDetails.SuspendLayout();
			this.SuspendLayout();
			// 
			// frmGLLink
			// 
			this.frmGLLink.AllowDrop = true;
			this.frmGLLink.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.frmGLLink.Controls.Add(this.cmdEmpGL);
			this.frmGLLink.Controls.Add(this.cmdUpdateEmpGLLink);
			this.frmGLLink.Controls.Add(this.Line2);
			this.frmGLLink.Controls.Add(this.Label1);
			this.frmGLLink.Enabled = true;
			this.frmGLLink.ForeColor = System.Drawing.SystemColors.WindowText;
			this.frmGLLink.Location = new System.Drawing.Point(522, 39);
			this.frmGLLink.Name = "frmGLLink";
			this.frmGLLink.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.frmGLLink.Size = new System.Drawing.Size(343, 40);
			this.frmGLLink.TabIndex = 5;
			this.frmGLLink.Visible = true;
			// 
			// cmdEmpGL
			// 
			this.cmdEmpGL.AllowDrop = true;
			this.cmdEmpGL.BackColor = System.Drawing.SystemColors.Control;
			this.cmdEmpGL.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdEmpGL.Location = new System.Drawing.Point(249, 9);
			this.cmdEmpGL.Name = "cmdEmpGL";
			this.cmdEmpGL.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdEmpGL.Size = new System.Drawing.Size(89, 27);
			this.cmdEmpGL.TabIndex = 7;
			this.cmdEmpGL.Text = "From Emp GL";
			this.cmdEmpGL.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.cmdEmpGL.UseVisualStyleBackColor = false;
			// this.cmdEmpGL.Click += new System.EventHandler(this.cmdEmpGL_Click);
			// 
			// cmdUpdateEmpGLLink
			// 
			this.cmdUpdateEmpGLLink.AllowDrop = true;
			this.cmdUpdateEmpGLLink.BackColor = System.Drawing.SystemColors.Control;
			this.cmdUpdateEmpGLLink.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdUpdateEmpGLLink.Location = new System.Drawing.Point(150, 9);
			this.cmdUpdateEmpGLLink.Name = "cmdUpdateEmpGLLink";
			this.cmdUpdateEmpGLLink.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdUpdateEmpGLLink.Size = new System.Drawing.Size(98, 27);
			this.cmdUpdateEmpGLLink.TabIndex = 6;
			this.cmdUpdateEmpGLLink.Text = "From Master";
			this.cmdUpdateEmpGLLink.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.cmdUpdateEmpGLLink.UseVisualStyleBackColor = false;
			// this.cmdUpdateEmpGLLink.Click += new System.EventHandler(this.cmdUpdateEmpGLLink_Click);
			// 
			// Line2
			// 
			this.Line2.AllowDrop = true;
			this.Line2.BackColor = System.Drawing.SystemColors.WindowText;
			this.Line2.Enabled = false;
			this.Line2.Location = new System.Drawing.Point(133, 6);
			this.Line2.Name = "Line2";
			this.Line2.Size = new System.Drawing.Size(1, 34);
			this.Line2.Visible = true;
			// 
			// Label1
			// 
			this.Label1.AllowDrop = true;
			this.Label1.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.Label1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Label1.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Label1.Location = new System.Drawing.Point(21, 16);
			this.Label1.Name = "Label1";
			this.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label1.Size = new System.Drawing.Size(100, 16);
			this.Label1.TabIndex = 8;
			this.Label1.Text = " Import GL Link";
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
			// txtEmpCode
			// 
			this.txtEmpCode.AllowDrop = true;
			this.txtEmpCode.BackColor = System.Drawing.Color.FromArgb(239, 239, 239);
			this.txtEmpCode.Enabled = false;
			this.txtEmpCode.ForeColor = System.Drawing.Color.Black;
			this.txtEmpCode.Location = new System.Drawing.Point(93, 54);
			this.txtEmpCode.MaxLength = 15;
			this.txtEmpCode.Name = "txtEmpCode";
			this.txtEmpCode.Size = new System.Drawing.Size(101, 19);
			this.txtEmpCode.TabIndex = 1;
			this.txtEmpCode.Text = "";
			// 
			// _lblCommon_5
			// 
			this._lblCommon_5.AllowDrop = true;
			this._lblCommon_5.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_5.Text = "Billing Code";
			this._lblCommon_5.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_5.Location = new System.Drawing.Point(9, 56);
			// // this._lblCommon_5.mLabelId = 1041;
			this._lblCommon_5.Name = "_lblCommon_5";
			this._lblCommon_5.Size = new System.Drawing.Size(74, 14);
			this._lblCommon_5.TabIndex = 2;
			// 
			// txtEmpName
			// 
			this.txtEmpName.AllowDrop = true;
			this.txtEmpName.Location = new System.Drawing.Point(196, 54);
			this.txtEmpName.Name = "txtEmpName";
			this.txtEmpName.Size = new System.Drawing.Size(312, 19);
			this.txtEmpName.TabIndex = 3;
			// 
			// grdVoucherDetails
			// 
			this.grdVoucherDetails.AllowDrop = true;
			this.grdVoucherDetails.BackColor = System.Drawing.Color.FromArgb(212, 208, 200);
			this.grdVoucherDetails.CellTipsWidth = 0;
			this.grdVoucherDetails.Enabled = false;
			this.grdVoucherDetails.Location = new System.Drawing.Point(2, 91);
			this.grdVoucherDetails.Name = "grdVoucherDetails";
			this.grdVoucherDetails.RowDivider.Color = System.Drawing.Color.FromArgb(212, 208, 200);
			this.grdVoucherDetails.Size = new System.Drawing.Size(879, 455);
			this.grdVoucherDetails.TabIndex = 4;
			this.grdVoucherDetails.Columns.Add(this.Column_0_grdVoucherDetails);
			this.grdVoucherDetails.Columns.Add(this.Column_1_grdVoucherDetails);
			this.grdVoucherDetails.GotFocus += new System.EventHandler(this.grdVoucherDetails_GotFocus);
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
			this.Line1.Location = new System.Drawing.Point(3, 83);
			this.Line1.Name = "Line1";
			this.Line1.Size = new System.Drawing.Size(878, 1);
			this.Line1.Text = "Line1";
			this.Line1.Visible = true;
			// 
			// frmPayEmpGlLinks
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.ClientSize = new System.Drawing.Size(886, 548);
			this.Controls.Add(this.frmGLLink);
			this.Controls.Add(this.cmbMastersList);
			this.Controls.Add(this.txtEmpCode);
			this.Controls.Add(this._lblCommon_5);
			this.Controls.Add(this.txtEmpName);
			this.Controls.Add(this.grdVoucherDetails);
			this.Controls.Add(this.Line1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			//this.Icon = (System.Drawing.Icon) resources.GetObject("frmPayEmpGlLinks.Icon");
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(120, 132);
			this.MaximizeBox = true;
			this.MinimizeBox = true;
			this.Name = "frmPayEmpGlLinks";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Employee GL Links";
			// this.Activated += new System.EventHandler(this.Form_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
			// this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
			this.frmGLLink.ResumeLayout(false);
			this.cmbMastersList.ResumeLayout(false);
			this.grdVoucherDetails.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		// 
		void InitializelblCommon()
		{
			this.lblCommon = new System.Windows.Forms.Label[6];
			this.lblCommon[5] = _lblCommon_5;
		}
		#endregion
	}
}//ENDSHERE
