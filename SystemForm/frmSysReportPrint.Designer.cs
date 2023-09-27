
namespace Xtreme
{
	partial class frmSysReportPrint
	{

		#region "Upgrade Support "
		private static frmSysReportPrint m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmSysReportPrint DefInstance
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
		public static frmSysReportPrint CreateInstance()
		{
			frmSysReportPrint theInstance = new frmSysReportPrint();
			
			return theInstance;
		}
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "vsrReportPreviewer", "vsrReportPrinter"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		//public AxVSPrinter8Lib.AxVSPrinter vsrReportPreviewer;
		//public AxVSReport8Lib.AxVSReport vsrReportPrinter;
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSysReportPrint));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			//this.vsrReportPreviewer = new AxVSPrinter8Lib.AxVSPrinter();
			//this.vsrReportPrinter = new AxVSReport8Lib.AxVSReport();
			// //((System.ComponentModel.ISupportInitialize) this.vsrReportPreviewer).BeginInit();
			// //((System.ComponentModel.ISupportInitialize) this.vsrReportPrinter).BeginInit();
			this.SuspendLayout();
			// 
			// vsrReportPreviewer
			// 
			////this.vsrReportPreviewer.AllowDrop = true;
			//this.vsrReportPreviewer.Location = new System.Drawing.Point(12, 6);
			//this.vsrReportPreviewer.Name = "vsrReportPreviewer";
			////
			//this.vsrReportPreviewer.Size = new System.Drawing.Size(305, 95);
			//this.vsrReportPreviewer.TabIndex = 0;
			// 
			// vsrReportPrinter
			// 
			////this.vsrReportPrinter.AllowDrop = true;
			//this.vsrReportPrinter.Location = new System.Drawing.Point(324, 8);
			//this.vsrReportPrinter.Name = "vsrReportPrinter";
			//
			// 
			// frmSysReportPrint
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Control;
			this.ClientSize = new System.Drawing.Size(399, 179);
			//this.Controls.Add(this.vsrReportPreviewer);
			//this.Controls.Add(this.vsrReportPrinter);
			//this.Icon = (System.Drawing.Icon) resources.GetObject("frmSysReportPrint.Icon");
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(126, 232);
			this.MaximizeBox = false;
			this.MinimizeBox = true;
			this.Name = "frmSysReportPrint";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			// this.Activated += new System.EventHandler(this.frmSysReportPrint_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
			// this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
			//((System.ComponentModel.ISupportInitialize) this.vsrReportPreviewer).EndInit();
			//((System.ComponentModel.ISupportInitialize) this.vsrReportPrinter).EndInit();
			this.ResumeLayout(false);
		}
		#endregion
	}
}//ENDSHERE
