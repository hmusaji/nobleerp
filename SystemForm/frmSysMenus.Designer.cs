
namespace Xtreme
{
	partial class frmSysMenus
	{

		#region "Upgrade Support "
		private static frmSysMenus m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmSysMenus DefInstance
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
		public static frmSysMenus CreateInstance()
		{
			frmSysMenus theInstance = new frmSysMenus();
			
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
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "Column_0_grdCommon", "Column_1_grdCommon", "grdCommon", "fraMain", "tabMaster", "cntOuterFrame"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_0_grdCommon;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_1_grdCommon;
		public C1.Win.C1TrueDBGrid.C1TrueDBGrid grdCommon;
		public System.Windows.Forms.Panel fraMain;
		public AxC1SizerLib.AxC1Tab tabMaster;
		public AxC1SizerLib.AxC1Elastic cntOuterFrame;
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSysMenus));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this.cntOuterFrame = new AxC1SizerLib.AxC1Elastic();
			this.tabMaster = new AxC1SizerLib.AxC1Tab();
			this.fraMain = new System.Windows.Forms.Panel();
			this.grdCommon = new C1.Win.C1TrueDBGrid.C1TrueDBGrid();
			this.Column_0_grdCommon = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.Column_1_grdCommon = new C1.Win.C1TrueDBGrid.C1DataColumn();
			// //((System.ComponentModel.ISupportInitialize) this.tabMaster).BeginInit();
			// //((System.ComponentModel.ISupportInitialize) this.cntOuterFrame).BeginInit();
			this.cntOuterFrame.SuspendLayout();
			this.tabMaster.SuspendLayout();
			this.fraMain.SuspendLayout();
			this.grdCommon.SuspendLayout();
			this.SuspendLayout();
			// 
			// cntOuterFrame
			// 
			this.cntOuterFrame.Align = C1SizerLib.AlignSettings.asNone;
			this.cntOuterFrame.AllowDrop = true;
			this.cntOuterFrame.Controls.Add(this.tabMaster);
			this.cntOuterFrame.Location = new System.Drawing.Point(0, 0);
			this.cntOuterFrame.Name = "cntOuterFrame";
			("cntOuterFrame.OcxState");
			this.cntOuterFrame.Size = new System.Drawing.Size(914, 465);
			this.cntOuterFrame.TabIndex = 1;
			this.cntOuterFrame.TabStop = false;
			// 
			// tabMaster
			// 
			this.tabMaster.Align = C1SizerLib.AlignSettings.asNone;
			this.tabMaster.AllowDrop = true;
			this.tabMaster.Controls.Add(this.fraMain);
			this.tabMaster.Location = new System.Drawing.Point(4, 14);
			this.tabMaster.Name = "tabMaster";
			("tabMaster.OcxState");
			this.tabMaster.Size = new System.Drawing.Size(904, 451);
			this.tabMaster.TabIndex = 2;
			this.tabMaster.TabStop = false;
			//// this.tabMaster.ClickEvent += new System.EventHandler(this.tabMaster_ClickEvent);
			// 
			// fraMain
			// 
			this.fraMain.AllowDrop = true;
			this.fraMain.BackColor = System.Drawing.Color.FromArgb(243, 243, 243);
			this.fraMain.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.fraMain.Controls.Add(this.grdCommon);
			this.fraMain.Enabled = true;
			this.fraMain.ForeColor = System.Drawing.SystemColors.WindowText;
			this.fraMain.Location = new System.Drawing.Point(0, 22);
			this.fraMain.Name = "fraMain";
			this.fraMain.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.fraMain.Size = new System.Drawing.Size(903, 429);
			this.fraMain.TabIndex = 3;
			this.fraMain.Visible = true;
			// 
			// grdCommon
			// 
			this.grdCommon.AllowDrop = true;
			this.grdCommon.BackColor = System.Drawing.Color.FromArgb(236, 233, 216);
			this.grdCommon.CellTipsWidth = 0;
			this.grdCommon.Location = new System.Drawing.Point(-1, 12);
			this.grdCommon.Name = "grdCommon";
			this.grdCommon.RowDivider.Color = System.Drawing.Color.FromArgb(236, 233, 216);
			this.grdCommon.Size = new System.Drawing.Size(902, 418);
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
			// frmSysMenus
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.ClientSize = new System.Drawing.Size(913, 507);
			this.Controls.Add(this.cntOuterFrame);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			//this.Icon = (System.Drawing.Icon) resources.GetObject("frmSysMenus.Icon");
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(182, 191);
			this.MaximizeBox = true;
			this.MinimizeBox = true;
			this.Name = "frmSysMenus";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "System Menus";
			// this.Activated += new System.EventHandler(this.Form_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
			// this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
			//this.Resize += new System.EventHandler(this.Form_Resize);
			//((System.ComponentModel.ISupportInitialize) this.tabMaster).EndInit();
			//((System.ComponentModel.ISupportInitialize) this.cntOuterFrame).EndInit();
			this.cntOuterFrame.ResumeLayout(false);
			this.tabMaster.ResumeLayout(false);
			this.fraMain.ResumeLayout(false);
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
}