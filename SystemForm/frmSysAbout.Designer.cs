
namespace Xtreme
{
	partial class frmSysAbout
	{

		#region "Upgrade Support "
		private static frmSysAbout m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmSysAbout DefInstance
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
		public static frmSysAbout CreateInstance()
		{
			frmSysAbout theInstance = new frmSysAbout();
			
			return theInstance;
		}
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "cmdClose", "lblLicensedToCompnayName", "lblLastUpdateDate", "lblCopyright", "imgBackground"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public System.Windows.Forms.Button cmdClose;
		public System.Windows.Forms.Label lblLicensedToCompnayName;
		public System.Windows.Forms.Label lblLastUpdateDate;
		public System.Windows.Forms.Label lblCopyright;
		public System.Windows.Forms.PictureBox imgBackground;
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSysAbout));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this.cmdClose = new System.Windows.Forms.Button();
			this.lblLicensedToCompnayName = new System.Windows.Forms.Label();
			this.lblLastUpdateDate = new System.Windows.Forms.Label();
			this.lblCopyright = new System.Windows.Forms.Label();
			this.imgBackground = new System.Windows.Forms.PictureBox();
			this.SuspendLayout();
			// 
			// cmdClose
			// 
			this.cmdClose.AllowDrop = true;
			this.cmdClose.BackColor = System.Drawing.SystemColors.Control;
			this.cmdClose.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdClose.Location = new System.Drawing.Point(364, 230);
			this.cmdClose.Name = "cmdClose";
			this.cmdClose.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdClose.Size = new System.Drawing.Size(89, 25);
			this.cmdClose.TabIndex = 0;
			this.cmdClose.Text = "&OK";
			this.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.cmdClose.UseVisualStyleBackColor = false;
			// this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
			// 
			// lblLicensedToCompnayName
			// 
			this.lblLicensedToCompnayName.AllowDrop = true;
			this.lblLicensedToCompnayName.BackColor = System.Drawing.Color.Transparent;
			this.lblLicensedToCompnayName.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lblLicensedToCompnayName.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblLicensedToCompnayName.Location = new System.Drawing.Point(0, 200);
			this.lblLicensedToCompnayName.Name = "lblLicensedToCompnayName";
			this.lblLicensedToCompnayName.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblLicensedToCompnayName.Size = new System.Drawing.Size(193, 17);
			this.lblLicensedToCompnayName.TabIndex = 3;
			this.lblLicensedToCompnayName.Text = "Demo Company";
			// 
			// lblLastUpdateDate
			// 
			this.lblLastUpdateDate.AllowDrop = true;
			this.lblLastUpdateDate.BackColor = System.Drawing.Color.Transparent;
			this.lblLastUpdateDate.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lblLastUpdateDate.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblLastUpdateDate.Location = new System.Drawing.Point(280, 8);
			this.lblLastUpdateDate.Name = "lblLastUpdateDate";
			this.lblLastUpdateDate.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblLastUpdateDate.Size = new System.Drawing.Size(185, 17);
			this.lblLastUpdateDate.TabIndex = 2;
			// this.lblLastUpdateDate.Text = "Last Update Date";
			// 
			// lblCopyright
			// 
			this.lblCopyright.AllowDrop = true;
			this.lblCopyright.BackColor = System.Drawing.Color.Transparent;
			this.lblCopyright.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lblCopyright.Font = new System.Drawing.Font("Tahoma", 6.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 178);
			this.lblCopyright.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblCopyright.Location = new System.Drawing.Point(2, 224);
			this.lblCopyright.Name = "lblCopyright";
			this.lblCopyright.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblCopyright.Size = new System.Drawing.Size(351, 45);
			this.lblCopyright.TabIndex = 1;
			this.lblCopyright.Text = "The software product is protected by copyright laws and international copyright treaties, as well as other intellectual property laws and treaties. The software product is licensed, not sold.";
			// 
			// imgBackground
			// 
			this.imgBackground.AllowDrop = true;
			this.imgBackground.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.imgBackground.Enabled = true;
			//this.imgBackground.Image = (System.Drawing.Image) resources.GetObject("imgBackground.Image");
			this.imgBackground.Location = new System.Drawing.Point(0, 0);
			this.imgBackground.Name = "imgBackground";
			this.imgBackground.Size = new System.Drawing.Size(460, 280);
			this.imgBackground.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal;
			this.imgBackground.Visible = true;
			// 
			// frmSysAbout
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(176, 178, 156);
			this.ClientSize = new System.Drawing.Size(460, 276);
			this.Controls.Add(this.cmdClose);
			this.Controls.Add(this.lblLicensedToCompnayName);
			this.Controls.Add(this.lblLastUpdateDate);
			this.Controls.Add(this.lblCopyright);
			this.Controls.Add(this.imgBackground);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			//this.Icon = (System.Drawing.Icon) resources.GetObject("frmSysAbout.Icon");
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(453, 245);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmSysAbout";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.ShowInTaskbar = false;
			this.Text = "About Xtreme";
			// this.Activated += new System.EventHandler(this.frmSysAbout_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
			this.ResumeLayout(false);
		}
		#endregion
	}
}//ENDSHERE
