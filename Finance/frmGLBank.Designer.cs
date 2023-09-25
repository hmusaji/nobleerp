
namespace Xtreme
{
	partial class frmGLBank
	{

		#region "Upgrade Support "
		private static frmGLBank m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmGLBank DefInstance
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
		public static frmGLBank CreateInstance()
		{
			frmGLBank theInstance = new frmGLBank();
			
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
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "txtComment", "txtBankNo", "lblLNatName", "txtLBankName", "lblANatName", "txtABankName", "lblComments", "lblNatNo", "txtAccountNo", "System.Windows.Forms.Label1"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public System.Windows.Forms.TextBox txtComment;
		public System.Windows.Forms.TextBox txtBankNo;
		public System.Windows.Forms.Label lblLNatName;
		public System.Windows.Forms.TextBox txtLBankName;
		public System.Windows.Forms.Label lblANatName;
		public System.Windows.Forms.TextBox txtABankName;
		public System.Windows.Forms.Label lblComments;
		public System.Windows.Forms.Label lblNatNo;
		public System.Windows.Forms.TextBox txtAccountNo;
		public System.Windows.Forms.Label Label1;
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGLBank));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this.txtComment = new System.Windows.Forms.TextBox();
			this.txtBankNo = new System.Windows.Forms.TextBox();
			this.lblLNatName = new System.Windows.Forms.Label();
			this.txtLBankName = new System.Windows.Forms.TextBox();
			this.lblANatName = new System.Windows.Forms.Label();
			this.txtABankName = new System.Windows.Forms.TextBox();
			this.lblComments = new System.Windows.Forms.Label();
			this.lblNatNo = new System.Windows.Forms.Label();
			this.txtAccountNo = new System.Windows.Forms.TextBox();
			this.Label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// txtComment
			// 
			this.txtComment.AcceptsReturn = true;
			this.txtComment.AllowDrop = true;
			this.txtComment.BackColor = System.Drawing.SystemColors.Window;
			this.txtComment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtComment.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtComment.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtComment.Location = new System.Drawing.Point(158, 122);
			this.txtComment.MaxLength = 100;
			this.txtComment.Multiline = true;
			this.txtComment.Name = "txtComment";
			this.txtComment.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtComment.Size = new System.Drawing.Size(304, 59);
			this.txtComment.TabIndex = 0;
			// 
			// txtBankNo
			// 
			this.txtBankNo.AllowDrop = true;
			this.txtBankNo.BackColor = System.Drawing.Color.White;
			// this.txtBankNo.bolNumericOnly = true;
			this.txtBankNo.ForeColor = System.Drawing.Color.Black;
			this.txtBankNo.Location = new System.Drawing.Point(158, 38);
			this.txtBankNo.MaxLength = 15;
			// this.txtBankNo.mDropDownType = System.Windows.Forms.TextBox.DropDownTypes.ddtNextNumber;
			this.txtBankNo.Name = "txtBankNo";
			// this.txtBankNo.ShowButton = true;
			this.txtBankNo.Size = new System.Drawing.Size(101, 19);
			this.txtBankNo.TabIndex = 1;
			this.txtBankNo.Text = "";
			// this.this.txtBankNo.Watermark = "";
			// this.this.txtBankNo.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtBankNo_DropButtonClick);
			// 
			// lblLNatName
			// 
			this.lblLNatName.AllowDrop = true;
			this.lblLNatName.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblLNatName.Text = "Bank Name (English)";
			this.lblLNatName.Location = new System.Drawing.Point(20, 82);
			// // this.lblLNatName.mLabelId = 1153;
			this.lblLNatName.Name = "lblLNatName";
			this.lblLNatName.Size = new System.Drawing.Size(99, 14);
			this.lblLNatName.TabIndex = 2;
			// 
			// txtLBankName
			// 
			this.txtLBankName.AllowDrop = true;
			this.txtLBankName.BackColor = System.Drawing.Color.White;
			this.txtLBankName.ForeColor = System.Drawing.Color.Black;
			this.txtLBankName.Location = new System.Drawing.Point(158, 80);
			this.txtLBankName.MaxLength = 50;
			this.txtLBankName.Name = "txtLBankName";
			this.txtLBankName.Size = new System.Drawing.Size(201, 19);
			this.txtLBankName.TabIndex = 3;
			this.txtLBankName.Text = "";
			// this.this.txtLBankName.Watermark = "";
			// 
			// lblANatName
			// 
			this.lblANatName.AllowDrop = true;
			this.lblANatName.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblANatName.Text = "Bank Name (Arabic)";
			this.lblANatName.Location = new System.Drawing.Point(20, 103);
			// // this.lblANatName.mLabelId = 1154;
			this.lblANatName.Name = "lblANatName";
			this.lblANatName.Size = new System.Drawing.Size(97, 14);
			this.lblANatName.TabIndex = 4;
			// 
			// txtABankName
			// 
			this.txtABankName.AllowDrop = true;
			this.txtABankName.BackColor = System.Drawing.Color.White;
			this.txtABankName.ForeColor = System.Drawing.Color.Black;
			this.txtABankName.Location = new System.Drawing.Point(158, 101);
			// this.txtABankName.mArabicEnabled = true;
			this.txtABankName.MaxLength = 50;
			this.txtABankName.Name = "txtABankName";
			this.txtABankName.Size = new System.Drawing.Size(201, 19);
			this.txtABankName.TabIndex = 5;
			this.txtABankName.Text = "";
			// this.this.txtABankName.Watermark = "";
			// 
			// lblComments
			// 
			this.lblComments.AllowDrop = true;
			this.lblComments.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblComments.Text = "Comment";
			this.lblComments.Location = new System.Drawing.Point(20, 122);
			// // this.lblComments.mLabelId = 1851;
			this.lblComments.Name = "lblComments";
			this.lblComments.Size = new System.Drawing.Size(44, 14);
			this.lblComments.TabIndex = 6;
			// 
			// lblNatNo
			// 
			this.lblNatNo.AllowDrop = true;
			this.lblNatNo.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblNatNo.Text = "Bank Code";
			this.lblNatNo.Location = new System.Drawing.Point(20, 40);
			// // this.lblNatNo.mLabelId = 1151;
			this.lblNatNo.Name = "lblNatNo";
			this.lblNatNo.Size = new System.Drawing.Size(52, 14);
			this.lblNatNo.TabIndex = 7;
			// 
			// txtAccountNo
			// 
			this.txtAccountNo.AllowDrop = true;
			this.txtAccountNo.BackColor = System.Drawing.Color.White;
			this.txtAccountNo.ForeColor = System.Drawing.Color.Black;
			this.txtAccountNo.Location = new System.Drawing.Point(158, 59);
			this.txtAccountNo.MaxLength = 15;
			// this.txtAccountNo.mDropDownType = System.Windows.Forms.TextBox.DropDownTypes.ddtNextNumber;
			this.txtAccountNo.Name = "txtAccountNo";
			this.txtAccountNo.Size = new System.Drawing.Size(101, 19);
			this.txtAccountNo.TabIndex = 8;
			this.txtAccountNo.Text = "";
			// this.this.txtAccountNo.Watermark = "";
			// 
			// System.Windows.Forms.Label1
			// 
			this.Label1.AllowDrop = true;
			this.Label1.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.Label1.Text = "Account No.";
			this.Label1.Location = new System.Drawing.Point(20, 61);
			// this.Label1.mLabelId = 1978;
			this.Label1.Name = "System.Windows.Forms.Label1";
			this.Label1.Size = new System.Drawing.Size(60, 14);
			this.Label1.TabIndex = 9;
			// 
			// frmGLBank
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.ClientSize = new System.Drawing.Size(585, 295);
			this.Controls.Add(this.txtComment);
			this.Controls.Add(this.txtBankNo);
			this.Controls.Add(this.lblLNatName);
			this.Controls.Add(this.txtLBankName);
			this.Controls.Add(this.lblANatName);
			this.Controls.Add(this.txtABankName);
			this.Controls.Add(this.lblComments);
			this.Controls.Add(this.lblNatNo);
			this.Controls.Add(this.txtAccountNo);
			this.Controls.Add(this.Label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			//this.Icon = (System.Drawing.Icon) resources.GetObject("frmGLBank.Icon");
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(119, 177);
			this.MaximizeBox = true;
			this.MinimizeBox = true;
			this.Name = "frmGLBank";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Bank";
			// this.Activated += new System.EventHandler(this.Form_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
			// this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
			this.ResumeLayout(false);
		}
		// 
		#endregion
	}
}//ENDSHERE
