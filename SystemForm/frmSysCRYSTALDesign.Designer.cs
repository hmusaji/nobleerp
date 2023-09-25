
namespace Xtreme
{
	partial class frmSysCRYSTALDesign
	{

		#region "Upgrade Support "
		private static frmSysCRYSTALDesign m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmSysCRYSTALDesign DefInstance
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
		public static frmSysCRYSTALDesign CreateInstance()
		{
			frmSysCRYSTALDesign theInstance = new frmSysCRYSTALDesign();
			
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
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "crvReportDesign"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public System.Windows.Forms.PictureBox crvReportDesign;
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSysCRYSTALDesign));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this.crvReportDesign = new System.Windows.Forms.PictureBox();
			this.SuspendLayout();
			// 
			// crvReportDesign
			// 
			this.crvReportDesign.AllowDrop = true;
			this.crvReportDesign.BackColor = System.Drawing.SystemColors.Control;
			this.crvReportDesign.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.crvReportDesign.CausesValidation = true;
			this.crvReportDesign.Dock = System.Windows.Forms.DockStyle.None;
			this.crvReportDesign.Enabled = true;
			this.crvReportDesign.Location = new System.Drawing.Point(60, 108);
			this.crvReportDesign.Name = "crvReportDesign";
			this.crvReportDesign.Size = new System.Drawing.Size(471, 279);
			this.crvReportDesign.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal;
			this.crvReportDesign.TabIndex = 0;
			this.crvReportDesign.TabStop = true;
			this.crvReportDesign.Visible = true;
			// 
			// frmSysCRYSTALDesign
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.ClientSize = new System.Drawing.Size(569, 403);
			this.Controls.Add(this.crvReportDesign);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			//this.Icon = (System.Drawing.Icon) resources.GetObject("frmSysCRYSTALDesign.Icon");
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(375, 212);
			this.MaximizeBox = true;
			this.MinimizeBox = true;
			this.Name = "frmSysCRYSTALDesign";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Tag = "False";
			this.Text = "Report Designer";
			// this.Activated += new System.EventHandler(this.Form_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
			this.Deactivate += new System.EventHandler(this.Form_Deactivate);
			//this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_FormClosing);
			// this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
			//this.Resize += new System.EventHandler(this.Form_Resize);
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