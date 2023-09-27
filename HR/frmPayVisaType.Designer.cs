
namespace Xtreme
{
	partial class frmPayVisaType
	{

		#region "Upgrade Support "
		private static frmPayVisaType m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmPayVisaType DefInstance
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
		public static frmPayVisaType CreateInstance()
		{
			frmPayVisaType theInstance = new frmPayVisaType();
			
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
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "txtVisaTypeNo", "lblLNatName", "txtLVisaTypeName", "lblANatName", "txtAVisaTypeName", "lblNatNo"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public System.Windows.Forms.TextBox txtVisaTypeNo;
		public System.Windows.Forms.Label lblLNatName;
		public System.Windows.Forms.TextBox txtLVisaTypeName;
		public System.Windows.Forms.Label lblANatName;
		public System.Windows.Forms.TextBox txtAVisaTypeName;
		public System.Windows.Forms.Label lblNatNo;
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPayVisaType));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this.txtVisaTypeNo = new System.Windows.Forms.TextBox();
			this.lblLNatName = new System.Windows.Forms.Label();
			this.txtLVisaTypeName = new System.Windows.Forms.TextBox();
			this.lblANatName = new System.Windows.Forms.Label();
			this.txtAVisaTypeName = new System.Windows.Forms.TextBox();
			this.lblNatNo = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// txtVisaTypeNo
			// 
			//this.txtVisaTypeNo.AllowDrop = true;
			this.txtVisaTypeNo.BackColor = System.Drawing.Color.White;
			// this.txtVisaTypeNo.bolNumericOnly = true;
			this.txtVisaTypeNo.ForeColor = System.Drawing.Color.Black;
			this.txtVisaTypeNo.Location = new System.Drawing.Point(160, 50);
			this.txtVisaTypeNo.MaxLength = 15;
			// // = System.Windows.Forms.TextBox.DropDownTypes.ddtNextNumber;
			this.txtVisaTypeNo.Name = "txtVisaTypeNo";
			this.txtVisaTypeNo.Size = new System.Drawing.Size(101, 19);
			this.txtVisaTypeNo.TabIndex = 0;
			this.txtVisaTypeNo.Text = "";
			// 
			// lblLNatName
			// 
			//this.lblLNatName.AllowDrop = true;
			this.lblLNatName.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblLNatName.Text = "Visa Type Name (English)";
			this.lblLNatName.Location = new System.Drawing.Point(22, 73);
			// // this.lblLNatName.mLabelId = 1956;
			this.lblLNatName.Name = "lblLNatName";
			this.lblLNatName.Size = new System.Drawing.Size(124, 14);
			this.lblLNatName.TabIndex = 1;
			// 
			// txtLVisaTypeName
			// 
			//this.txtLVisaTypeName.AllowDrop = true;
			this.txtLVisaTypeName.BackColor = System.Drawing.Color.White;
			this.txtLVisaTypeName.ForeColor = System.Drawing.Color.Black;
			this.txtLVisaTypeName.Location = new System.Drawing.Point(160, 71);
			this.txtLVisaTypeName.MaxLength = 100;
			this.txtLVisaTypeName.Name = "txtLVisaTypeName";
			this.txtLVisaTypeName.Size = new System.Drawing.Size(201, 19);
			this.txtLVisaTypeName.TabIndex = 2;
			this.txtLVisaTypeName.Text = "";
			// 
			// lblANatName
			// 
			//this.lblANatName.AllowDrop = true;
			this.lblANatName.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblANatName.Text = "Visa Type Name (Arabic)";
			this.lblANatName.Location = new System.Drawing.Point(22, 94);
			// // this.lblANatName.mLabelId = 1957;
			this.lblANatName.Name = "lblANatName";
			this.lblANatName.Size = new System.Drawing.Size(122, 14);
			this.lblANatName.TabIndex = 3;
			// 
			// txtAVisaTypeName
			// 
			//this.txtAVisaTypeName.AllowDrop = true;
			this.txtAVisaTypeName.BackColor = System.Drawing.Color.White;
			this.txtAVisaTypeName.ForeColor = System.Drawing.Color.Black;
			this.txtAVisaTypeName.Location = new System.Drawing.Point(160, 92);
			// // = true;
			this.txtAVisaTypeName.MaxLength = 100;
			this.txtAVisaTypeName.Name = "txtAVisaTypeName";
			this.txtAVisaTypeName.Size = new System.Drawing.Size(201, 19);
			this.txtAVisaTypeName.TabIndex = 4;
			this.txtAVisaTypeName.Text = "";
			// 
			// lblNatNo
			// 
			//this.lblNatNo.AllowDrop = true;
			this.lblNatNo.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblNatNo.Text = "Visa Type No.";
			this.lblNatNo.Location = new System.Drawing.Point(22, 52);
			// // this.lblNatNo.mLabelId = 1955;
			this.lblNatNo.Name = "lblNatNo";
			this.lblNatNo.Size = new System.Drawing.Size(68, 14);
			this.lblNatNo.TabIndex = 5;
			// 
			// frmPayVisaType
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.ClientSize = new System.Drawing.Size(439, 160);
			this.Controls.Add(this.txtVisaTypeNo);
			this.Controls.Add(this.lblLNatName);
			this.Controls.Add(this.txtLVisaTypeName);
			this.Controls.Add(this.lblANatName);
			this.Controls.Add(this.txtAVisaTypeName);
			this.Controls.Add(this.lblNatNo);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			//this.Icon = (System.Drawing.Icon) resources.GetObject("frmPayVisaType.Icon");
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(132, 207);
			this.MaximizeBox = true;
			this.MinimizeBox = true;
			this.Name = "frmPayVisaType";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Visa Type";
			// this.Activated += new System.EventHandler(this.frmPayVisaType_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
			// this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
			this.ResumeLayout(false);
		}
		// 
		#endregion
	}
}//ENDSHERE
