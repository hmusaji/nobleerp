
namespace Xtreme
{
	partial class frmSysSplash
	{

		#region "Upgrade Support "
		private static frmSysSplash m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmSysSplash DefInstance
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
		public static frmSysSplash CreateInstance()
		{
			frmSysSplash theInstance = new frmSysSplash();
			
			return theInstance;
		}
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "shpBorder", "lblLicensedToCompnayName", "lblApplicationStatus", "lblCopyright", "Image1"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public ShapeHelper shpBorder;
		public System.Windows.Forms.Label lblLicensedToCompnayName;
		public System.Windows.Forms.Label lblApplicationStatus;
		public System.Windows.Forms.Label lblCopyright;
		public System.Windows.Forms.PictureBox Image1;
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSysSplash));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this.shpBorder = new ShapeHelper();
			this.lblLicensedToCompnayName = new System.Windows.Forms.Label();
			this.lblApplicationStatus = new System.Windows.Forms.Label();
			this.lblCopyright = new System.Windows.Forms.Label();
			this.Image1 = new System.Windows.Forms.PictureBox();
			this.SuspendLayout();
			// 
			// shpBorder
			// 
			//this.shpBorder.AllowDrop = true;
			this.shpBorder.BackColor = System.Drawing.SystemColors.Window;
			// = 0;
			//this.shpBorder.BorderColor = System.Drawing.Color.Navy;
			//this.shpBorder.BorderStyle = 1;
			//this.shpBorder.BorderWidth = 2;
			this.shpBorder.Enabled = false;
			//this.shpBorder.FillColor = System.Drawing.Color.Black;
			//this.shpBorder.FillStyle = 1;
			this.shpBorder.Location = new System.Drawing.Point(32, 24);
			this.shpBorder.Name = "shpBorder";
			this.shpBorder.Size = new System.Drawing.Size(47, 35);
			this.shpBorder.Visible = true;
			// 
			// lblLicensedToCompnayName
			// 
			//this.lblLicensedToCompnayName.AllowDrop = true;
			this.lblLicensedToCompnayName.BackColor = System.Drawing.Color.Transparent;
			//this.lblLicensedToCompnayName.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lblLicensedToCompnayName.ForeColor = System.Drawing.Color.White;
			this.lblLicensedToCompnayName.Location = new System.Drawing.Point(126, 192);
			this.lblLicensedToCompnayName.Name = "lblLicensedToCompnayName";
			this.lblLicensedToCompnayName.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblLicensedToCompnayName.Size = new System.Drawing.Size(305, 17);
			this.lblLicensedToCompnayName.TabIndex = 2;
			this.lblLicensedToCompnayName.Text = "Demo";
			this.lblLicensedToCompnayName.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// lblApplicationStatus
			// 
			//this.lblApplicationStatus.AllowDrop = true;
			this.lblApplicationStatus.BackColor = System.Drawing.Color.Transparent;
			//this.lblApplicationStatus.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lblApplicationStatus.ForeColor = System.Drawing.Color.White;
			this.lblApplicationStatus.Location = new System.Drawing.Point(10, 227);
			this.lblApplicationStatus.Name = "lblApplicationStatus";
			this.lblApplicationStatus.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblApplicationStatus.Size = new System.Drawing.Size(233, 11);
			this.lblApplicationStatus.TabIndex = 1;
			// 
			// lblCopyright
			// 
			//this.lblCopyright.AllowDrop = true;
			this.lblCopyright.BackColor = System.Drawing.Color.Transparent;
			//this.lblCopyright.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lblCopyright.Font = new System.Drawing.Font("Tahoma", 6.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 178);
			this.lblCopyright.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblCopyright.Location = new System.Drawing.Point(6, 258);
			this.lblCopyright.Name = "lblCopyright";
			this.lblCopyright.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblCopyright.Size = new System.Drawing.Size(407, 29);
			this.lblCopyright.TabIndex = 0;
			this.lblCopyright.Text = "The software product is protected by copyright laws and international copyright treaties, as well as other intellectual property laws and treaties. The software product is licensed, not sold.";
			// 
			// Image1
			// 
			//this.Image1.AllowDrop = true;
			//this.Image1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Image1.Enabled = true;
			//this.Image1.Image = (System.Drawing.Image) resources.GetObject("Image1.Image");
			this.Image1.Location = new System.Drawing.Point(0, 0);
			this.Image1.Name = "Image1";
			this.Image1.Size = new System.Drawing.Size(438, 248);
			this.Image1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal;
			this.Image1.Visible = true;
			// 
			// frmSysSplash
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(437, 247);
			this.ControlBox = false;
			this.Controls.Add(this.shpBorder);
			this.Controls.Add(this.lblLicensedToCompnayName);
			this.Controls.Add(this.lblApplicationStatus);
			this.Controls.Add(this.lblCopyright);
			this.Controls.Add(this.Image1);
			this.ForeColor = System.Drawing.Color.White;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			//this.Icon = (System.Drawing.Icon) resources.GetObject("frmSysSplash.Icon");
			this.Location = new System.Drawing.Point(467, 256);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmSysSplash";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Splash";
			// this.Activated += new System.EventHandler(this.frmSysSplash_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
			this.ResumeLayout(false);
		}
		#endregion
	}
}//ENDSHERE
