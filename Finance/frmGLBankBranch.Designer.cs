
namespace Xtreme
{
	partial class frmGLBankBranch
	{

		#region "Upgrade Support "
		private static frmGLBankBranch m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmGLBankBranch DefInstance
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
		public static frmGLBankBranch CreateInstance()
		{
			frmGLBankBranch theInstance = new frmGLBankBranch();
			
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
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "txtComment", "txtBranchNo", "lblGroupNo", "lblLGroupName", "txtLBranchName", "lblParentGroup", "lblAGroupName", "txtABranchName", "lblComments", "txtParentBankNo", "txtParentBranchName"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public System.Windows.Forms.TextBox txtComment;
		public System.Windows.Forms.TextBox txtBranchNo;
		public System.Windows.Forms.Label lblGroupNo;
		public System.Windows.Forms.Label lblLGroupName;
		public System.Windows.Forms.TextBox txtLBranchName;
		public System.Windows.Forms.Label lblParentGroup;
		public System.Windows.Forms.Label lblAGroupName;
		public System.Windows.Forms.TextBox txtABranchName;
		public System.Windows.Forms.Label lblComments;
		public System.Windows.Forms.TextBox txtParentBankNo;
		public System.Windows.Forms.TextBox txtParentBranchName;
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGLBankBranch));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this.txtComment = new System.Windows.Forms.TextBox();
			this.txtBranchNo = new System.Windows.Forms.TextBox();
			this.lblGroupNo = new System.Windows.Forms.Label();
			this.lblLGroupName = new System.Windows.Forms.Label();
			this.txtLBranchName = new System.Windows.Forms.TextBox();
			this.lblParentGroup = new System.Windows.Forms.Label();
			this.lblAGroupName = new System.Windows.Forms.Label();
			this.txtABranchName = new System.Windows.Forms.TextBox();
			this.lblComments = new System.Windows.Forms.Label();
			this.txtParentBankNo = new System.Windows.Forms.TextBox();
			this.txtParentBranchName = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// txtComment
			// 
			this.txtComment.AcceptsReturn = true;
			//this.txtComment.AllowDrop = true;
			this.txtComment.BackColor = System.Drawing.SystemColors.Window;
			//this.txtComment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtComment.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtComment.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtComment.Location = new System.Drawing.Point(134, 126);
			this.txtComment.MaxLength = 100;
			this.txtComment.Multiline = true;
			this.txtComment.Name = "txtComment";
			this.txtComment.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtComment.Size = new System.Drawing.Size(294, 49);
			this.txtComment.TabIndex = 0;
			// 
			// txtBranchNo
			// 
			//this.txtBranchNo.AllowDrop = true;
			this.txtBranchNo.BackColor = System.Drawing.Color.White;
			// this.txtBranchNo.bolNumericOnly = true;
			this.txtBranchNo.ForeColor = System.Drawing.Color.Black;
			this.txtBranchNo.Location = new System.Drawing.Point(134, 40);
			this.txtBranchNo.MaxLength = 15;
			// // = System.Windows.Forms.TextBox.DropDownTypes.ddtNextNumber;
			this.txtBranchNo.Name = "txtBranchNo";
			// this.txtBranchNo.ShowButton = true;
			this.txtBranchNo.Size = new System.Drawing.Size(101, 19);
			this.txtBranchNo.TabIndex = 1;
			this.txtBranchNo.Text = "";
			// this.//this.txtBranchNo.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(//this.txtBranchNo_DropButtonClick);
			// 
			// lblGroupNo
			// 
			//this.lblGroupNo.AllowDrop = true;
			this.lblGroupNo.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblGroupNo.Text = "Bank Branch Code";
			this.lblGroupNo.Location = new System.Drawing.Point(10, 42);
			// // this.lblGroupNo.mLabelId = 86;
			this.lblGroupNo.Name = "lblGroupNo";
			this.lblGroupNo.Size = new System.Drawing.Size(90, 14);
			this.lblGroupNo.TabIndex = 2;
			// 
			// lblLGroupName
			// 
			//this.lblLGroupName.AllowDrop = true;
			this.lblLGroupName.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblLGroupName.Text = "Branch Name (English)";
			this.lblLGroupName.Location = new System.Drawing.Point(10, 64);
			// // this.lblLGroupName.mLabelId = 1819;
			this.lblLGroupName.Name = "lblLGroupName";
			this.lblLGroupName.Size = new System.Drawing.Size(110, 14);
			this.lblLGroupName.TabIndex = 3;
			// 
			// txtLBranchName
			// 
			//this.txtLBranchName.AllowDrop = true;
			this.txtLBranchName.BackColor = System.Drawing.Color.White;
			this.txtLBranchName.ForeColor = System.Drawing.Color.Black;
			this.txtLBranchName.Location = new System.Drawing.Point(134, 61);
			this.txtLBranchName.MaxLength = 50;
			this.txtLBranchName.Name = "txtLBranchName";
			this.txtLBranchName.Size = new System.Drawing.Size(201, 19);
			this.txtLBranchName.TabIndex = 4;
			this.txtLBranchName.Text = "";
			// 
			// lblParentGroup
			// 
			//this.lblParentGroup.AllowDrop = true;
			this.lblParentGroup.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblParentGroup.Text = "Bank Code";
			this.lblParentGroup.Location = new System.Drawing.Point(10, 106);
			// // this.lblParentGroup.mLabelId = 1151;
			this.lblParentGroup.Name = "lblParentGroup";
			this.lblParentGroup.Size = new System.Drawing.Size(52, 14);
			this.lblParentGroup.TabIndex = 5;
			// 
			// lblAGroupName
			// 
			//this.lblAGroupName.AllowDrop = true;
			this.lblAGroupName.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblAGroupName.Text = "Branch Name (Arabic)";
			this.lblAGroupName.Location = new System.Drawing.Point(10, 85);
			// // this.lblAGroupName.mLabelId = 1820;
			this.lblAGroupName.Name = "lblAGroupName";
			this.lblAGroupName.Size = new System.Drawing.Size(108, 14);
			this.lblAGroupName.TabIndex = 6;
			// 
			// txtABranchName
			// 
			//this.txtABranchName.AllowDrop = true;
			this.txtABranchName.BackColor = System.Drawing.Color.White;
			this.txtABranchName.ForeColor = System.Drawing.Color.Black;
			this.txtABranchName.Location = new System.Drawing.Point(134, 82);
			// // = true;
			this.txtABranchName.MaxLength = 50;
			this.txtABranchName.Name = "txtABranchName";
			this.txtABranchName.Size = new System.Drawing.Size(201, 19);
			this.txtABranchName.TabIndex = 7;
			this.txtABranchName.Text = "";
			// 
			// lblComments
			// 
			//this.lblComments.AllowDrop = true;
			this.lblComments.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblComments.Text = "Comment";
			this.lblComments.Location = new System.Drawing.Point(10, 126);
			// // this.lblComments.mLabelId = 1851;
			this.lblComments.Name = "lblComments";
			this.lblComments.Size = new System.Drawing.Size(44, 14);
			this.lblComments.TabIndex = 8;
			// 
			// txtParentBankNo
			// 
			//this.txtParentBankNo.AllowDrop = true;
			this.txtParentBankNo.BackColor = System.Drawing.Color.White;
			// this.txtParentBankNo.bolNumericOnly = true;
			this.txtParentBankNo.ForeColor = System.Drawing.Color.Black;
			this.txtParentBankNo.Location = new System.Drawing.Point(134, 103);
			this.txtParentBankNo.MaxLength = 15;
			this.txtParentBankNo.Name = "txtParentBankNo";
			// this.txtParentBankNo.ShowButton = true;
			this.txtParentBankNo.Size = new System.Drawing.Size(101, 19);
			this.txtParentBankNo.TabIndex = 9;
			this.txtParentBankNo.Text = "";
			// this.//this.txtParentBankNo.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(//this.txtParentBankNo_DropButtonClick);
			// this.txtParentBankNo.Leave += new System.EventHandler(this.txtParentBankNo_Leave);
			// 
			// txtParentBranchName
			// 
			//this.txtParentBranchName.AllowDrop = true;
			this.txtParentBranchName.BackColor = System.Drawing.Color.FromArgb(239, 239, 239);
			this.txtParentBranchName.Enabled = false;
			this.txtParentBranchName.ForeColor = System.Drawing.Color.Black;
			this.txtParentBranchName.Location = new System.Drawing.Point(237, 103);
			this.txtParentBranchName.Name = "txtParentBranchName";
			this.txtParentBranchName.Size = new System.Drawing.Size(191, 19);
			this.txtParentBranchName.TabIndex = 10;
			this.txtParentBranchName.TabStop = false;
			this.txtParentBranchName.Text = " ";
			// 
			// frmGLBankBranch
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.ClientSize = new System.Drawing.Size(674, 339);
			this.Controls.Add(this.txtComment);
			this.Controls.Add(this.txtBranchNo);
			this.Controls.Add(this.lblGroupNo);
			this.Controls.Add(this.lblLGroupName);
			this.Controls.Add(this.txtLBranchName);
			this.Controls.Add(this.lblParentGroup);
			this.Controls.Add(this.lblAGroupName);
			this.Controls.Add(this.txtABranchName);
			this.Controls.Add(this.lblComments);
			this.Controls.Add(this.txtParentBankNo);
			this.Controls.Add(this.txtParentBranchName);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			//this.Icon = (System.Drawing.Icon) resources.GetObject("frmGLBankBranch.Icon");
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(320, 193);
			this.MaximizeBox = true;
			this.MinimizeBox = true;
			this.Name = "frmGLBankBranch";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Bank Branch";
			// this.Activated += new System.EventHandler(this.frmGLBankBranch_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
			// this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
			this.ResumeLayout(false);
		}
		// 
		#endregion
	}
}//ENDSHERE
