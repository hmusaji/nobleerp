
namespace Xtreme
{
	partial class frmSysShortcut
	{

		
		#region "Windows Form Designer generated code "
		public static frmSysShortcut CreateInstance()
		{
			frmSysShortcut theInstance = new frmSysShortcut();
			
			return theInstance;
		}
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "wndTaskPanel"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public Syncfusion.Windows.Forms.Tools.XPTaskPane wndTaskPanel;
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSysShortcut));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this.wndTaskPanel = new Syncfusion.Windows.Forms.Tools.XPTaskPane();
			// //((System.ComponentModel.ISupportInitialize) this.wndTaskPanel).BeginInit();
			this.SuspendLayout();
			// 
			// wndTaskPanel
			// 
			this.wndTaskPanel.AllowDrop = true;
			this.wndTaskPanel.Location = new System.Drawing.Point(4, 0);
			this.wndTaskPanel.Name = "wndTaskPanel";
		
			this.wndTaskPanel.Size = new System.Drawing.Size(217, 513);
			this.wndTaskPanel.TabIndex = 0;
			// 
			// frmSysShortcut
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Control;
			this.ClientSize = new System.Drawing.Size(572, 562);
			this.Controls.Add(this.wndTaskPanel);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Location = new System.Drawing.Point(256, 213);
			this.MaximizeBox = true;
			this.MinimizeBox = true;
			this.Name = "frmSysShortcut";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.ShowInTaskbar = false;
			this.Text = "Shortcut";
			// this.Activated += new System.EventHandler(this.frmSysShortcut_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
			//this.Resize += new System.EventHandler(this.Form_Resize);
			//((System.ComponentModel.ISupportInitialize) this.wndTaskPanel).EndInit();
			this.ResumeLayout(false);
		}
		#endregion
	}
}//ENDSHERE
