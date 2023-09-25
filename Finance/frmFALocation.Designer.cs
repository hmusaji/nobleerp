
namespace Xtreme
{
	partial class frmFALocation
	{

		#region "Upgrade Support "
		private static frmFALocation m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmFALocation DefInstance
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
		public static frmFALocation CreateInstance()
		{
			frmFALocation theInstance = new frmFALocation();
			
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
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "txtLocationNo", "lblLocationCode", "lblLLocationName", "lblALocationName", "txtLLocationName", "txtALocationName", "lblCostCenter", "txtCostCenterCd", "txtCostCenterName"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public System.Windows.Forms.TextBox txtLocationNo;
		public System.Windows.Forms.Label lblLocationCode;
		public System.Windows.Forms.Label lblLLocationName;
		public System.Windows.Forms.Label lblALocationName;
		public System.Windows.Forms.TextBox txtLLocationName;
		public System.Windows.Forms.TextBox txtALocationName;
		public System.Windows.Forms.Label lblCostCenter;
		public System.Windows.Forms.TextBox txtCostCenterCd;
		public System.Windows.Forms.TextBox txtCostCenterName;
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFALocation));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this.txtLocationNo = new System.Windows.Forms.TextBox();
			this.lblLocationCode = new System.Windows.Forms.Label();
			this.lblLLocationName = new System.Windows.Forms.Label();
			this.lblALocationName = new System.Windows.Forms.Label();
			this.txtLLocationName = new System.Windows.Forms.TextBox();
			this.txtALocationName = new System.Windows.Forms.TextBox();
			this.lblCostCenter = new System.Windows.Forms.Label();
			this.txtCostCenterCd = new System.Windows.Forms.TextBox();
			this.txtCostCenterName = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// txtLocationNo
			// 
			this.txtLocationNo.AllowDrop = true;
			this.txtLocationNo.BackColor = System.Drawing.Color.White;
			// this.txtLocationNo.bolNumericOnly = true;
			this.txtLocationNo.ForeColor = System.Drawing.Color.Black;
			this.txtLocationNo.Location = new System.Drawing.Point(132, 50);
			this.txtLocationNo.MaxLength = 4;
			// this.txtLocationNo.mDropDownType = System.Windows.Forms.TextBox.DropDownTypes.ddtNextNumber;
			this.txtLocationNo.Name = "txtLocationNo";
			// this.txtLocationNo.ShowButton = true;
			this.txtLocationNo.Size = new System.Drawing.Size(101, 19);
			this.txtLocationNo.TabIndex = 0;
			this.txtLocationNo.Text = "";
			// this.this.txtLocationNo.Watermark = "";
			// this.this.txtLocationNo.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtLocationNo_DropButtonClick);
			// 
			// lblLocationCode
			// 
			this.lblLocationCode.AllowDrop = true;
			this.lblLocationCode.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblLocationCode.Text = "Location Code";
			this.lblLocationCode.ForeColor = System.Drawing.Color.Black;
			this.lblLocationCode.Location = new System.Drawing.Point(8, 53);
			// this.lblLocationCode.mLabelId = 1023;
			this.lblLocationCode.Name = "lblLocationCode";
			this.lblLocationCode.Size = new System.Drawing.Size(69, 14);
			this.lblLocationCode.TabIndex = 4;
			// 
			// lblLLocationName
			// 
			this.lblLLocationName.AllowDrop = true;
			this.lblLLocationName.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblLLocationName.Text = "Location Name (English)";
			this.lblLLocationName.ForeColor = System.Drawing.Color.Black;
			this.lblLLocationName.Location = new System.Drawing.Point(8, 74);
			// this.lblLLocationName.mLabelId = 1024;
			this.lblLLocationName.Name = "lblLLocationName";
			this.lblLLocationName.Size = new System.Drawing.Size(116, 14);
			this.lblLLocationName.TabIndex = 5;
			// 
			// lblALocationName
			// 
			this.lblALocationName.AllowDrop = true;
			this.lblALocationName.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblALocationName.Text = "Location Name (Arabic)";
			this.lblALocationName.ForeColor = System.Drawing.Color.Black;
			this.lblALocationName.Location = new System.Drawing.Point(8, 95);
			// this.lblALocationName.mLabelId = 1026;
			this.lblALocationName.Name = "lblALocationName";
			this.lblALocationName.Size = new System.Drawing.Size(114, 14);
			this.lblALocationName.TabIndex = 6;
			// 
			// txtLLocationName
			// 
			this.txtLLocationName.AllowDrop = true;
			this.txtLLocationName.BackColor = System.Drawing.Color.White;
			this.txtLLocationName.ForeColor = System.Drawing.Color.Black;
			this.txtLLocationName.Location = new System.Drawing.Point(132, 71);
			this.txtLLocationName.MaxLength = 50;
			this.txtLLocationName.Name = "txtLLocationName";
			this.txtLLocationName.Size = new System.Drawing.Size(295, 19);
			this.txtLLocationName.TabIndex = 1;
			this.txtLLocationName.Tag = "Salesman Name in English";
			this.txtLLocationName.Text = "";
			// this.this.txtLLocationName.Watermark = "";
			// 
			// txtALocationName
			// 
			this.txtALocationName.AllowDrop = true;
			this.txtALocationName.BackColor = System.Drawing.Color.White;
			this.txtALocationName.ForeColor = System.Drawing.Color.Black;
			this.txtALocationName.Location = new System.Drawing.Point(132, 92);
			// this.txtALocationName.mArabicEnabled = true;
			this.txtALocationName.MaxLength = 50;
			this.txtALocationName.Name = "txtALocationName";
			this.txtALocationName.Size = new System.Drawing.Size(295, 19);
			this.txtALocationName.TabIndex = 2;
			this.txtALocationName.Text = "";
			// this.this.txtALocationName.Watermark = "";
			// 
			// lblCostCenter
			// 
			this.lblCostCenter.AllowDrop = true;
			this.lblCostCenter.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblCostCenter.Text = "Cost Center Code";
			this.lblCostCenter.ForeColor = System.Drawing.Color.Black;
			this.lblCostCenter.Location = new System.Drawing.Point(8, 123);
			this.lblCostCenter.Name = "lblCostCenter";
			this.lblCostCenter.Size = new System.Drawing.Size(85, 14);
			this.lblCostCenter.TabIndex = 7;
			// 
			// txtCostCenterCd
			// 
			this.txtCostCenterCd.AllowDrop = true;
			this.txtCostCenterCd.BackColor = System.Drawing.Color.White;
			// this.txtCostCenterCd.bolNumericOnly = true;
			this.txtCostCenterCd.ForeColor = System.Drawing.Color.Black;
			this.txtCostCenterCd.Location = new System.Drawing.Point(132, 120);
			this.txtCostCenterCd.MaxLength = 15;
			this.txtCostCenterCd.Name = "txtCostCenterCd";
			// this.txtCostCenterCd.ShowButton = true;
			this.txtCostCenterCd.Size = new System.Drawing.Size(101, 19);
			this.txtCostCenterCd.TabIndex = 3;
			this.txtCostCenterCd.Text = "";
			// this.this.txtCostCenterCd.Watermark = "";
			// this.this.txtCostCenterCd.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCostCenterCd_DropButtonClick);
			// this.txtCostCenterCd.Leave += new System.EventHandler(this.txtCostCenterCd_Leave);
			// 
			// txtCostCenterName
			// 
			this.txtCostCenterName.AllowDrop = true;
			this.txtCostCenterName.BackColor = System.Drawing.Color.FromArgb(239, 239, 239);
			this.txtCostCenterName.Enabled = false;
			this.txtCostCenterName.ForeColor = System.Drawing.Color.Black;
			this.txtCostCenterName.Location = new System.Drawing.Point(234, 120);
			this.txtCostCenterName.Name = "txtCostCenterName";
			this.txtCostCenterName.Size = new System.Drawing.Size(193, 19);
			this.txtCostCenterName.TabIndex = 8;
			this.txtCostCenterName.TabStop = false;
			this.txtCostCenterName.Text = " ";
			// this.this.txtCostCenterName.Watermark = "";
			// 
			// frmFALocation
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.ClientSize = new System.Drawing.Size(437, 173);
			this.Controls.Add(this.txtLocationNo);
			this.Controls.Add(this.lblLocationCode);
			this.Controls.Add(this.lblLLocationName);
			this.Controls.Add(this.lblALocationName);
			this.Controls.Add(this.txtLLocationName);
			this.Controls.Add(this.txtALocationName);
			this.Controls.Add(this.lblCostCenter);
			this.Controls.Add(this.txtCostCenterCd);
			this.Controls.Add(this.txtCostCenterName);
			//this.Icon = (System.Drawing.Icon) resources.GetObject("frmFALocation.Icon");
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(169, 232);
			this.MaximizeBox = true;
			this.MinimizeBox = true;
			this.Name = "frmFALocation";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Fixed Asset Location";
			this.ToolTipMain.SetToolTip(this.txtLLocationName, "Salesman Name in English");
			// this.Activated += new System.EventHandler(this.frmFALocation_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
			// this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
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