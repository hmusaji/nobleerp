
namespace Xtreme
{
	partial class frmGLAccntTransDetailRemarks
	{

		#region "Upgrade Support "
		private static frmGLAccntTransDetailRemarks m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmGLAccntTransDetailRemarks DefInstance
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
		public static frmGLAccntTransDetailRemarks CreateInstance()
		{
			frmGLAccntTransDetailRemarks theInstance = new frmGLAccntTransDetailRemarks();
			
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
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "txtRemarkNo", "lblCurrNameA", "txtARemarkName", "txtlRemarkName", "lblCurrNameL", "System.Windows.Forms.Label1"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public System.Windows.Forms.TextBox txtRemarkNo;
		public System.Windows.Forms.Label lblCurrNameA;
		public System.Windows.Forms.TextBox txtARemarkName;
		public System.Windows.Forms.TextBox txtlRemarkName;
		public System.Windows.Forms.Label lblCurrNameL;
		public System.Windows.Forms.Label Label1;
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGLAccntTransDetailRemarks));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this.txtRemarkNo = new System.Windows.Forms.TextBox();
			this.lblCurrNameA = new System.Windows.Forms.Label();
			this.txtARemarkName = new System.Windows.Forms.TextBox();
			this.txtlRemarkName = new System.Windows.Forms.TextBox();
			this.lblCurrNameL = new System.Windows.Forms.Label();
			this.Label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// txtRemarkNo
			// 
			this.txtRemarkNo.AllowDrop = true;
			this.txtRemarkNo.BackColor = System.Drawing.Color.White;
			// // = false;
			this.txtRemarkNo.ForeColor = System.Drawing.Color.Black;
			this.txtRemarkNo.Location = new System.Drawing.Point(114, 16);
			// // = (System.Windows.Forms.TextBox.DropDownTypes) 0;
			this.txtRemarkNo.Name = "txtRemarkNo";
			// this.txtRemarkNo.ShowButton = true;
			this.txtRemarkNo.Size = new System.Drawing.Size(81, 19);
			this.txtRemarkNo.TabIndex = 0;
			this.txtRemarkNo.Text = "";
			// this.//this.txtRemarkNo.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(//this.txtRemarkNo_DropButtonClick);
			// 
			// lblCurrNameA
			// 
			this.lblCurrNameA.AllowDrop = true;
			this.lblCurrNameA.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblCurrNameA.Text = "Remark Name(AR)";
			this.lblCurrNameA.Location = new System.Drawing.Point(9, 60);
			this.lblCurrNameA.Name = "lblCurrNameA";
			this.lblCurrNameA.Size = new System.Drawing.Size(89, 14);
			this.lblCurrNameA.TabIndex = 4;
			// 
			// txtARemarkName
			// 
			this.txtARemarkName.AllowDrop = true;
			this.txtARemarkName.BackColor = System.Drawing.Color.White;
			this.txtARemarkName.ForeColor = System.Drawing.Color.Black;
			this.txtARemarkName.Location = new System.Drawing.Point(114, 58);
			// // = true;
			this.txtARemarkName.MaxLength = 200;
			this.txtARemarkName.Name = "txtARemarkName";
			this.txtARemarkName.Size = new System.Drawing.Size(201, 19);
			this.txtARemarkName.TabIndex = 2;
			this.txtARemarkName.Text = "";
			// 
			// txtlRemarkName
			// 
			this.txtlRemarkName.AllowDrop = true;
			this.txtlRemarkName.BackColor = System.Drawing.Color.White;
			this.txtlRemarkName.ForeColor = System.Drawing.Color.Black;
			this.txtlRemarkName.Location = new System.Drawing.Point(114, 37);
			this.txtlRemarkName.MaxLength = 200;
			this.txtlRemarkName.Name = "txtlRemarkName";
			this.txtlRemarkName.Size = new System.Drawing.Size(201, 19);
			this.txtlRemarkName.TabIndex = 1;
			this.txtlRemarkName.Text = "";
			// 
			// lblCurrNameL
			// 
			this.lblCurrNameL.AllowDrop = true;
			this.lblCurrNameL.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblCurrNameL.Text = "Remark Name";
			this.lblCurrNameL.Location = new System.Drawing.Point(9, 39);
			this.lblCurrNameL.Name = "lblCurrNameL";
			this.lblCurrNameL.Size = new System.Drawing.Size(66, 14);
			this.lblCurrNameL.TabIndex = 3;
			// 
			// System.Windows.Forms.Label1
			// 
			this.Label1.AllowDrop = true;
			this.Label1.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.Label1.Text = "Remark No";
			this.Label1.Location = new System.Drawing.Point(9, 18);
			this.Label1.Name="Label1";
			this.Label1.Size = new System.Drawing.Size(52, 14);
			this.Label1.TabIndex = 5;
			// 
			// frmGLAccntTransDetailRemarks
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.ClientSize = new System.Drawing.Size(323, 115);
			this.Controls.Add(this.txtRemarkNo);
			this.Controls.Add(this.lblCurrNameA);
			this.Controls.Add(this.txtARemarkName);
			this.Controls.Add(this.txtlRemarkName);
			this.Controls.Add(this.lblCurrNameL);
			this.Controls.Add(this.Label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			//this.Icon = (System.Drawing.Icon) resources.GetObject("frmGLAccntTransDetailRemarks.Icon");
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(373, 221);
			this.MaximizeBox = true;
			this.MinimizeBox = true;
			this.Name = "frmGLAccntTransDetailRemarks";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Remarks";
			// this.Activated += new System.EventHandler(this.frmGLAccntTransDetailRemarks_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
			// this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
			this.ResumeLayout(false);
		}
		// 
		#endregion
	}
}//ENDSHERE
