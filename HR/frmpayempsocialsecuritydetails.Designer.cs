
namespace Xtreme
{
	partial class frmPayEmpSocialSecurityDetails
	{

		#region "Upgrade Support "
		private static frmPayEmpSocialSecurityDetails m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmPayEmpSocialSecurityDetails DefInstance
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
		public static frmPayEmpSocialSecurityDetails CreateInstance()
		{
			frmPayEmpSocialSecurityDetails theInstance = new frmPayEmpSocialSecurityDetails();
			
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
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "cmdGenerate", "cmdRefresh", "Column_0_grdSocialSecurityDet", "Column_1_grdSocialSecurityDet", "grdSocialSecurityDet", "Line1"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public System.Windows.Forms.Button cmdGenerate;
		public System.Windows.Forms.Button cmdRefresh;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_0_grdSocialSecurityDet;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_1_grdSocialSecurityDet;
		public C1.Win.C1TrueDBGrid.C1TrueDBGrid grdSocialSecurityDet;
		public System.Windows.Forms.Label Line1;
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPayEmpSocialSecurityDetails));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this.cmdGenerate = new System.Windows.Forms.Button();
			this.cmdRefresh = new System.Windows.Forms.Button();
			this.grdSocialSecurityDet = new C1.Win.C1TrueDBGrid.C1TrueDBGrid();
			this.Column_0_grdSocialSecurityDet = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.Column_1_grdSocialSecurityDet = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.Line1 = new System.Windows.Forms.Label();
			//this.grdSocialSecurityDet.SuspendLayout();
			this.SuspendLayout();
			// 
			// cmdGenerate
			// 
			//this.cmdGenerate.AllowDrop = true;
			this.cmdGenerate.BackColor = System.Drawing.SystemColors.Control;
			this.cmdGenerate.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdGenerate.Location = new System.Drawing.Point(1065, 57);
			this.cmdGenerate.Name = "cmdGenerate";
			this.cmdGenerate.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdGenerate.Size = new System.Drawing.Size(103, 31);
			this.cmdGenerate.TabIndex = 2;
			// this.cmdGenerate.Text = "&Generate Payroll";
			// this.cmdGenerate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.cmdGenerate.UseVisualStyleBackColor = false;
			// this.cmdGenerate.Click += new System.EventHandler(this.cmdGenerate_Click);
			// 
			// cmdRefresh
			// 
			//this.cmdRefresh.AllowDrop = true;
			this.cmdRefresh.BackColor = System.Drawing.SystemColors.Control;
			this.cmdRefresh.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdRefresh.Location = new System.Drawing.Point(957, 57);
			this.cmdRefresh.Name = "cmdRefresh";
			this.cmdRefresh.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdRefresh.Size = new System.Drawing.Size(103, 31);
			this.cmdRefresh.TabIndex = 1;
			this.cmdRefresh.Text = "&Refresh";
			this.cmdRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.cmdRefresh.UseVisualStyleBackColor = false;
			// this.cmdRefresh.Click += new System.EventHandler(this.cmdRefresh_Click);
			// 
			// grdSocialSecurityDet
			// 
			//this.grdSocialSecurityDet.AllowDrop = true;
			this.grdSocialSecurityDet.BackColor = System.Drawing.Color.FromArgb(212, 208, 200);
			this.grdSocialSecurityDet.CellTipsWidth = 0;
			this.grdSocialSecurityDet.Location = new System.Drawing.Point(3, 102);
			this.grdSocialSecurityDet.Name = "grdSocialSecurityDet";
			this.grdSocialSecurityDet.RowDivider.Color = System.Drawing.Color.FromArgb(212, 208, 200);
			this.grdSocialSecurityDet.Size = new System.Drawing.Size(1188, 328);
			this.grdSocialSecurityDet.TabIndex = 0;
			this.grdSocialSecurityDet.Columns.Add(this.Column_0_grdSocialSecurityDet);
			this.grdSocialSecurityDet.Columns.Add(this.Column_1_grdSocialSecurityDet);
			//this.grdSocialSecurityDet.AfterColUpdate += new C1.Win.C1TrueDBGrid.ColEventHandler(this.grdSocialSecurityDet_AfterColUpdate);
			// 
			// Column_0_grdSocialSecurityDet
			// 
			this.Column_0_grdSocialSecurityDet.DataField = "";
			this.Column_0_grdSocialSecurityDet.ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.Normal;
			// 
			// Column_1_grdSocialSecurityDet
			// 
			this.Column_1_grdSocialSecurityDet.DataField = "";
			this.Column_1_grdSocialSecurityDet.ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.Normal;
			// 
			// Line1
			// 
			//this.Line1.AllowDrop = true;
			this.Line1.BackColor = System.Drawing.SystemColors.WindowText;
			this.Line1.Enabled = false;
			this.Line1.Location = new System.Drawing.Point(3, 96);
			this.Line1.Name = "Line1";
			this.Line1.Size = new System.Drawing.Size(1185, 1);
			this.Line1.Visible = true;
			// 
			// frmPayEmpSocialSecurityDetails
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.ClientSize = new System.Drawing.Size(1193, 436);
			this.Controls.Add(this.cmdGenerate);
			this.Controls.Add(this.cmdRefresh);
			this.Controls.Add(this.grdSocialSecurityDet);
			this.Controls.Add(this.Line1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			//this.Icon = (System.Drawing.Icon) resources.GetObject("frmPayEmpSocialSecurityDetails.Icon");
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(36, 131);
			this.MaximizeBox = true;
			this.MinimizeBox = true;
			this.Name = "frmPayEmpSocialSecurityDetails";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Employee Social Security Details";
			// this.Activated += new System.EventHandler(this.frmPayEmpSocialSecurityDetails_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
			// this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
			this.grdSocialSecurityDet.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		// 
		#endregion
	}
}//ENDSHERE
