
namespace Xtreme
{
	partial class frmSysDashboard
	{

		#region "Upgrade Support "
		private static frmSysDashboard m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmSysDashboard DefInstance
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
		public static frmSysDashboard CreateInstance()
		{
			frmSysDashboard theInstance = new frmSysDashboard();
			
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
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "DockingPaneManager"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public Syncfusion.Windows.Forms.Tools.DockingManager DockingPaneManager;
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSysDashboard));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this.DockingPaneManager = new Syncfusion.Windows.Forms.Tools.DockingManager();
			// //((System.ComponentModel.ISupportInitialize) this.DockingPaneManager).BeginInit();
			this.SuspendLayout();
			// 
			// DockingPaneManager
			// 
			this.DockingPaneManager.AllowDrop = true;
			this.DockingPaneManager.Location = new System.Drawing.Point(0, 0);
			this.DockingPaneManager.Name = "DockingPaneManager";
			("DockingPaneManager.OcxState");
			this.DockingPaneManager.AttachPaneEvent += new AxXtremeDockingPane._DDockingPaneEvents_AttachPaneEventHandler(this.DockingPaneManager_AttachPaneEvent);
			// 
			// frmSysDashboard
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.ClientSize = new System.Drawing.Size(439, 539);
			this.Controls.Add(this.DockingPaneManager);
			this.Location = new System.Drawing.Point(176, 127);
			this.MaximizeBox = true;
			this.MinimizeBox = true;
			this.Name = "frmSysDashboard";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Dashboard";
			// this.Activated += new System.EventHandler(this.frmSysDashboard_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
			//((System.ComponentModel.ISupportInitialize) this.DockingPaneManager).EndInit();
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
