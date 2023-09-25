
namespace Xtreme
{
	partial class frmSysApolloDesign
	{

		#region "Upgrade Support "
		private static frmSysApolloDesign m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmSysApolloDesign DefInstance
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
		public static frmSysApolloDesign CreateInstance()
		{
			frmSysApolloDesign theInstance = new frmSysApolloDesign();
			
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
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "WebBrowser1", "tcbSystemReport"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public System.Windows.Forms.WebBrowser WebBrowser1;
		public Syncfusion.Windows.Forms.Tools.CommandBarController tcbSystemReport;
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSysApolloDesign));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this.WebBrowser1 = new System.Windows.Forms.WebBrowser();
			this.tcbSystemReport = new Syncfusion.Windows.Forms.Tools.CommandBarController();
			// //((System.ComponentModel.ISupportInitialize) this.tcbSystemReport).BeginInit();
			this.SuspendLayout();
			// 
			// WebBrowser1
			// 
			this.WebBrowser1.AllowWebBrowserDrop = true;
			this.WebBrowser1.Location = new System.Drawing.Point(38, 26);
			this.WebBrowser1.Name = "WebBrowser1";
			this.WebBrowser1.Size = new System.Drawing.Size(705, 407);
			this.WebBrowser1.TabIndex = 0;
			// 
			// tcbSystemReport
			// 
			this.tcbSystemReport.AllowDrop = true;
			this.tcbSystemReport.Location = new System.Drawing.Point(16, 56);
			this.tcbSystemReport.Name = "tcbSystemReport";
			("tcbSystemReport.OcxState");
			this.tcbSystemReport.Execute += new AxXtremeCommandBars._DCommandBarsEvents_ExecuteEventHandler(this.tcbSystemReport_Execute);
			// 
			// frmSysApolloDesign
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.SystemColors.Control;
			this.ClientSize = new System.Drawing.Size(761, 455);
			this.Controls.Add(this.WebBrowser1);
			this.Controls.Add(this.tcbSystemReport);
			//this.Icon = (System.Drawing.Icon) resources.GetObject("frmSysApolloDesign.Icon");
			this.Location = new System.Drawing.Point(160, 245);
			this.MaximizeBox = false;
			this.MinimizeBox = true;
			this.Name = "frmSysApolloDesign";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Report Designer";
			// this.Activated += new System.EventHandler(this.frmSysApolloDesign_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
			//((System.ComponentModel.ISupportInitialize) this.tcbSystemReport).EndInit();
			this.ResumeLayout(false);
		}
		// 
		#endregion
	}
}//ENDSHERE
