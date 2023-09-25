
namespace Xtreme
{
	partial class frmSysReportSeekPage
	{

		#region "Upgrade Support "
		private static frmSysReportSeekPage m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmSysReportSeekPage DefInstance
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
		public static frmSysReportSeekPage CreateInstance()
		{
			frmSysReportSeekPage theInstance = new frmSysReportSeekPage();
			return theInstance;
		}
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "cmdSeekPage", "lblSeekPage", "txtSeekPage"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public UCOkCancel cmdSeekPage;
		public System.Windows.Forms.Label lblSeekPage;
		public System.Windows.Forms.TextBox txtSeekPage;
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSysReportSeekPage));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this.cmdSeekPage = new UCOkCancel();
			this.lblSeekPage = new System.Windows.Forms.Label();
			this.txtSeekPage = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// cmdSeekPage
			// 
			this.cmdSeekPage.AllowDrop = true;
			this.cmdSeekPage.CancelCaption = "&Close";
			this.cmdSeekPage.DisplayButton = 0;
			this.cmdSeekPage.Location = new System.Drawing.Point(32, 78);
			this.cmdSeekPage.Name = "cmdSeekPage";
			this.cmdSeekPage.OkCaption = "&Seek";
			this.cmdSeekPage.Size = new System.Drawing.Size(206, 31);
			this.cmdSeekPage.TabIndex = 1;
			this.cmdSeekPage.CancelClick += new UCOkCancel.CancelClickHandler(this.cmdSeekPage_CancelClick);
			this.cmdSeekPage.OKClick += new UCOkCancel.OKClickHandler(this.cmdSeekPage_OKClick);
			// 
			// lblSeekPage
			// 
			this.lblSeekPage.AllowDrop = true;
			this.lblSeekPage.BackColor = System.Drawing.Color.FromArgb(215, 225, 238);
			this.lblSeekPage.Text = "Seek Page #";
			this.lblSeekPage.Location = new System.Drawing.Point(40, 34);
			this.lblSeekPage.Name = "lblSeekPage";
			this.lblSeekPage.Size = new System.Drawing.Size(61, 13);
			this.lblSeekPage.TabIndex = 2;
			// 
			// txtSeekPage
			// 
			this.txtSeekPage.AllowDrop = true;
			this.txtSeekPage.BackColor = System.Drawing.Color.White;
			this.txtSeekPage.Location = new System.Drawing.Point(120, 31);
			this.txtSeekPage.Name = "txtSeekPage";
			this.txtSeekPage.Size = new System.Drawing.Size(109, 19);
			this.txtSeekPage.TabIndex = 0;
			this.txtSeekPage.Text = "";
			// 
			// frmSysReportSeekPage
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(215, 225, 238);
			this.ClientSize = new System.Drawing.Size(269, 126);
			this.ControlBox = false;
			this.Controls.Add(this.cmdSeekPage);
			this.Controls.Add(this.lblSeekPage);
			this.Controls.Add(this.txtSeekPage);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(153, 284);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmSysReportSeekPage";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Seek Page in Report...";
			// this.Activated += new System.EventHandler(this.frmSysReportSeekPage_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
			// this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
			this.ResumeLayout(false);
		}
		#endregion
	}
}