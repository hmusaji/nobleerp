
namespace Xtreme
{
	partial class frmGLConsignment
	{

		#region "Upgrade Support "
		private static frmGLConsignment m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmGLConsignment DefInstance
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
		public static frmGLConsignment CreateInstance()
		{
			frmGLConsignment theInstance = new frmGLConsignment();
			
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
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "txtConsignmentNo", "lblLNatName", "txtLConsignmentName", "lblANatName", "txtAConsignmentName", "lblNatNo"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public System.Windows.Forms.TextBox txtConsignmentNo;
		public System.Windows.Forms.Label lblLNatName;
		public System.Windows.Forms.TextBox txtLConsignmentName;
		public System.Windows.Forms.Label lblANatName;
		public System.Windows.Forms.TextBox txtAConsignmentName;
		public System.Windows.Forms.Label lblNatNo;
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGLConsignment));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this.txtConsignmentNo = new System.Windows.Forms.TextBox();
			this.lblLNatName = new System.Windows.Forms.Label();
			this.txtLConsignmentName = new System.Windows.Forms.TextBox();
			this.lblANatName = new System.Windows.Forms.Label();
			this.txtAConsignmentName = new System.Windows.Forms.TextBox();
			this.lblNatNo = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// txtConsignmentNo
			// 
			this.txtConsignmentNo.AllowDrop = true;
			this.txtConsignmentNo.BackColor = System.Drawing.Color.White;
			this.txtConsignmentNo.ForeColor = System.Drawing.Color.Black;
			this.txtConsignmentNo.Location = new System.Drawing.Point(146, 10);
			this.txtConsignmentNo.MaxLength = 15;
			// // = System.Windows.Forms.TextBox.DropDownTypes.ddtNextNumber;
			this.txtConsignmentNo.Name = "txtConsignmentNo";
			// this.txtConsignmentNo.ShowButton = true;
			this.txtConsignmentNo.Size = new System.Drawing.Size(101, 19);
			this.txtConsignmentNo.TabIndex = 0;
			this.txtConsignmentNo.Text = "";
			// this.//this.txtConsignmentNo.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(//this.txtConsignmentNo_DropButtonClick);
			// 
			// lblLNatName
			// 
			this.lblLNatName.AllowDrop = true;
			this.lblLNatName.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblLNatName.Text = "Consignment Name (English)";
			this.lblLNatName.Location = new System.Drawing.Point(8, 35);
			// // this.lblLNatName.mLabelId = 2116;
			this.lblLNatName.Name = "lblLNatName";
			this.lblLNatName.Size = new System.Drawing.Size(137, 14);
			this.lblLNatName.TabIndex = 1;
			// 
			// txtLConsignmentName
			// 
			this.txtLConsignmentName.AllowDrop = true;
			this.txtLConsignmentName.BackColor = System.Drawing.Color.White;
			this.txtLConsignmentName.ForeColor = System.Drawing.Color.Black;
			this.txtLConsignmentName.Location = new System.Drawing.Point(146, 33);
			this.txtLConsignmentName.MaxLength = 50;
			this.txtLConsignmentName.Name = "txtLConsignmentName";
			this.txtLConsignmentName.Size = new System.Drawing.Size(201, 19);
			this.txtLConsignmentName.TabIndex = 2;
			this.txtLConsignmentName.Text = "";
			// 
			// lblANatName
			// 
			this.lblANatName.AllowDrop = true;
			this.lblANatName.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblANatName.Text = "Consignment Name (Arabic)";
			this.lblANatName.Location = new System.Drawing.Point(8, 58);
			// // this.lblANatName.mLabelId = 2117;
			this.lblANatName.Name = "lblANatName";
			this.lblANatName.Size = new System.Drawing.Size(135, 14);
			this.lblANatName.TabIndex = 3;
			// 
			// txtAConsignmentName
			// 
			this.txtAConsignmentName.AllowDrop = true;
			this.txtAConsignmentName.BackColor = System.Drawing.Color.White;
			this.txtAConsignmentName.ForeColor = System.Drawing.Color.Black;
			this.txtAConsignmentName.Location = new System.Drawing.Point(146, 56);
			// // = true;
			this.txtAConsignmentName.MaxLength = 50;
			this.txtAConsignmentName.Name = "txtAConsignmentName";
			this.txtAConsignmentName.Size = new System.Drawing.Size(201, 19);
			this.txtAConsignmentName.TabIndex = 4;
			this.txtAConsignmentName.Text = "";
			// 
			// lblNatNo
			// 
			this.lblNatNo.AllowDrop = true;
			this.lblNatNo.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblNatNo.Text = "Consignment Code";
			this.lblNatNo.Location = new System.Drawing.Point(8, 12);
			// // this.lblNatNo.mLabelId = 2115;
			this.lblNatNo.Name = "lblNatNo";
			this.lblNatNo.Size = new System.Drawing.Size(90, 14);
			this.lblNatNo.TabIndex = 5;
			// 
			// frmGLConsignment
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.ClientSize = new System.Drawing.Size(465, 249);
			this.Controls.Add(this.txtConsignmentNo);
			this.Controls.Add(this.lblLNatName);
			this.Controls.Add(this.txtLConsignmentName);
			this.Controls.Add(this.lblANatName);
			this.Controls.Add(this.txtAConsignmentName);
			this.Controls.Add(this.lblNatNo);
			//this.Icon = (System.Drawing.Icon) resources.GetObject("frmGLConsignment.Icon");
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(227, 220);
			this.MaximizeBox = true;
			this.MinimizeBox = true;
			this.Name = "frmGLConsignment";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Consingment";
			// this.Activated += new System.EventHandler(this.frmGLConsignment_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
			// this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
			this.ResumeLayout(false);
		}
		// 
		#endregion
	}
}//ENDSHERE
