
namespace Xtreme
{
	partial class frmSysModules
	{

		#region "Upgrade Support "
		private static frmSysModules m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmSysModules DefInstance
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
		public static frmSysModules CreateInstance()
		{
			frmSysModules theInstance = new frmSysModules();
			
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
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "Column_0_grdCommon", "Column_1_grdCommon", "grdCommon"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_0_grdCommon;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_1_grdCommon;
		public C1.Win.C1TrueDBGrid.C1TrueDBGrid grdCommon;
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSysModules));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this.grdCommon = new C1.Win.C1TrueDBGrid.C1TrueDBGrid();
			this.Column_0_grdCommon = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.Column_1_grdCommon = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.grdCommon.SuspendLayout();
			this.SuspendLayout();
			// 
			// grdCommon
			// 
			this.grdCommon.AllowDrop = true;
			this.grdCommon.BackColor = System.Drawing.Color.FromArgb(236, 233, 216);
			this.grdCommon.CellTipsWidth = 0;
			this.grdCommon.Location = new System.Drawing.Point(2, 2);
			this.grdCommon.Name = "grdCommon";
			this.grdCommon.RowDivider.Color = System.Drawing.Color.FromArgb(236, 233, 216);
			this.grdCommon.Size = new System.Drawing.Size(470, 389);
			this.grdCommon.TabIndex = 0;
			this.grdCommon.Columns.Add(this.Column_0_grdCommon);
			this.grdCommon.Columns.Add(this.Column_1_grdCommon);
			this.grdCommon.BeforeColEdit += new C1.Win.C1TrueDBGrid.BeforeColEditEventHandler(this.grdCommon_BeforeColEdit);
			// this.this.grdCommon.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.grdCommon_KeyPress);
			this.grdCommon.MouseUp += new System.Windows.Forms.MouseEventHandler(this.grdCommon_MouseUp);
			// 
			// Column_0_grdCommon
			// 
			this.Column_0_grdCommon.DataField = "";
			this.Column_0_grdCommon.ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.Normal;
			// 
			// Column_1_grdCommon
			// 
			this.Column_1_grdCommon.DataField = "";
			this.Column_1_grdCommon.ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.Normal;
			// 
			// frmSysModules
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.ClientSize = new System.Drawing.Size(831, 579);
			this.Controls.Add(this.grdCommon);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			//this.Icon = (System.Drawing.Icon) resources.GetObject("frmSysModules.Icon");
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(207, 135);
			this.MaximizeBox = true;
			this.MinimizeBox = true;
			this.Name = "frmSysModules";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "System Modules";
			// this.Activated += new System.EventHandler(this.Form_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
			// this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
			this.grdCommon.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		void ReLoadForm(bool addEvents)
		{
			//This form is an MDI child.
			//This code simulates the VB6 
			// functionality of automatically
			// loading and showing an MDI
			// child's parent.
			this.MdiParent = Xtreme.frmSysMain.DefInstance;
			Xtreme.frmSysMain.DefInstance.Show();
		}
		#endregion
	}
}//ENDSHERE
