
namespace Xtreme
{
	partial class frmICSProductGroups
	{

		#region "Upgrade Support "
		private static frmICSProductGroups m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmICSProductGroups DefInstance
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
		public static frmICSProductGroups CreateInstance()
		{
			frmICSProductGroups theInstance = new frmICSProductGroups();
			
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
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "txtComment", "txtGroupNo", "lblGroupNo", "lblLGroupName", "txtLGroupName", "lblParentGroup", "lblAGroupName", "txtAGroupName", "lblComments", "txtParentGroupNo", "txtParentGroupName"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public System.Windows.Forms.TextBox txtComment;
		public System.Windows.Forms.TextBox txtGroupNo;
		public System.Windows.Forms.Label lblGroupNo;
		public System.Windows.Forms.Label lblLGroupName;
		public System.Windows.Forms.TextBox txtLGroupName;
		public System.Windows.Forms.Label lblParentGroup;
		public System.Windows.Forms.Label lblAGroupName;
		public System.Windows.Forms.TextBox txtAGroupName;
		public System.Windows.Forms.Label lblComments;
		public System.Windows.Forms.TextBox txtParentGroupNo;
		public System.Windows.Forms.TextBox txtParentGroupName;
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmICSProductGroups));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this.txtComment = new System.Windows.Forms.TextBox();
			this.txtGroupNo = new System.Windows.Forms.TextBox();
			this.lblGroupNo = new System.Windows.Forms.Label();
			this.lblLGroupName = new System.Windows.Forms.Label();
			this.txtLGroupName = new System.Windows.Forms.TextBox();
			this.lblParentGroup = new System.Windows.Forms.Label();
			this.lblAGroupName = new System.Windows.Forms.Label();
			this.txtAGroupName = new System.Windows.Forms.TextBox();
			this.lblComments = new System.Windows.Forms.Label();
			this.txtParentGroupNo = new System.Windows.Forms.TextBox();
			this.txtParentGroupName = new System.Windows.Forms.TextBox();
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
			this.txtComment.Location = new System.Drawing.Point(127, 111);
			this.txtComment.MaxLength = 100;
			this.txtComment.Multiline = true;
			this.txtComment.Name = "txtComment";
			this.txtComment.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtComment.Size = new System.Drawing.Size(294, 49);
			this.txtComment.TabIndex = 10;
			// 
			// txtGroupNo
			// 
			//this.txtGroupNo.AllowDrop = true;
			this.txtGroupNo.BackColor = System.Drawing.Color.White;
			// this.txtGroupNo.bolNumericOnly = true;
			this.txtGroupNo.ForeColor = System.Drawing.Color.Black;
			this.txtGroupNo.Location = new System.Drawing.Point(127, 25);
			this.txtGroupNo.MaxLength = 15;
			// // = System.Windows.Forms.TextBox.DropDownTypes.ddtNextNumber;
			this.txtGroupNo.Name = "txtGroupNo";
			// this.txtGroupNo.ShowButton = true;
			this.txtGroupNo.Size = new System.Drawing.Size(101, 19);
			this.txtGroupNo.TabIndex = 1;
			this.txtGroupNo.Text = "";
			// this.// = "";
			// this.//this.txtGroupNo.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(//this.txtGroupNo_DropButtonClick);
			// 
			// lblGroupNo
			// 
			//this.lblGroupNo.AllowDrop = true;
			this.lblGroupNo.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblGroupNo.Text = "Group Code";
			this.lblGroupNo.ForeColor = System.Drawing.Color.Black;
			this.lblGroupNo.Location = new System.Drawing.Point(9, 27);
			// // this.lblGroupNo.mLabelId = 301;
			this.lblGroupNo.Name = "lblGroupNo";
			this.lblGroupNo.Size = new System.Drawing.Size(58, 14);
			this.lblGroupNo.TabIndex = 0;
			// 
			// lblLGroupName
			// 
			//this.lblLGroupName.AllowDrop = true;
			this.lblLGroupName.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblLGroupName.Text = "Group Name (English)";
			this.lblLGroupName.ForeColor = System.Drawing.Color.Black;
			this.lblLGroupName.Location = new System.Drawing.Point(9, 49);
			// // this.lblLGroupName.mLabelId = 302;
			this.lblLGroupName.Name = "lblLGroupName";
			this.lblLGroupName.Size = new System.Drawing.Size(105, 14);
			this.lblLGroupName.TabIndex = 2;
			// 
			// txtLGroupName
			// 
			//this.txtLGroupName.AllowDrop = true;
			this.txtLGroupName.BackColor = System.Drawing.Color.White;
			this.txtLGroupName.ForeColor = System.Drawing.Color.Black;
			this.txtLGroupName.Location = new System.Drawing.Point(127, 46);
			this.txtLGroupName.MaxLength = 50;
			this.txtLGroupName.Name = "txtLGroupName";
			this.txtLGroupName.Size = new System.Drawing.Size(201, 19);
			this.txtLGroupName.TabIndex = 3;
			this.txtLGroupName.Text = "";
			// this.// = "";
			// 
			// lblParentGroup
			// 
			//this.lblParentGroup.AllowDrop = true;
			this.lblParentGroup.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblParentGroup.Text = "Parent Group Code";
			this.lblParentGroup.ForeColor = System.Drawing.Color.Black;
			this.lblParentGroup.Location = new System.Drawing.Point(9, 91);
			// // this.lblParentGroup.mLabelId = 504;
			this.lblParentGroup.Name = "lblParentGroup";
			this.lblParentGroup.Size = new System.Drawing.Size(92, 14);
			this.lblParentGroup.TabIndex = 6;
			// 
			// lblAGroupName
			// 
			//this.lblAGroupName.AllowDrop = true;
			this.lblAGroupName.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblAGroupName.Text = "Group Name (Arabic)";
			this.lblAGroupName.ForeColor = System.Drawing.Color.Black;
			this.lblAGroupName.Location = new System.Drawing.Point(9, 70);
			// // this.lblAGroupName.mLabelId = 303;
			this.lblAGroupName.Name = "lblAGroupName";
			this.lblAGroupName.Size = new System.Drawing.Size(103, 14);
			this.lblAGroupName.TabIndex = 4;
			// 
			// txtAGroupName
			// 
			//this.txtAGroupName.AllowDrop = true;
			this.txtAGroupName.BackColor = System.Drawing.Color.White;
			this.txtAGroupName.ForeColor = System.Drawing.Color.Black;
			this.txtAGroupName.Location = new System.Drawing.Point(127, 67);
			// // = true;
			this.txtAGroupName.MaxLength = 50;
			this.txtAGroupName.Name = "txtAGroupName";
			this.txtAGroupName.Size = new System.Drawing.Size(201, 19);
			this.txtAGroupName.TabIndex = 5;
			this.txtAGroupName.Text = "";
			// this.// = "";
			// 
			// lblComments
			// 
			//this.lblComments.AllowDrop = true;
			this.lblComments.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblComments.Text = "Comment";
			this.lblComments.ForeColor = System.Drawing.Color.Black;
			this.lblComments.Location = new System.Drawing.Point(9, 111);
			// // this.lblComments.mLabelId = 135;
			this.lblComments.Name = "lblComments";
			this.lblComments.Size = new System.Drawing.Size(44, 14);
			this.lblComments.TabIndex = 9;
			// 
			// txtParentGroupNo
			// 
			//this.txtParentGroupNo.AllowDrop = true;
			this.txtParentGroupNo.BackColor = System.Drawing.Color.White;
			// this.txtParentGroupNo.bolNumericOnly = true;
			this.txtParentGroupNo.ForeColor = System.Drawing.Color.Black;
			this.txtParentGroupNo.Location = new System.Drawing.Point(127, 88);
			this.txtParentGroupNo.MaxLength = 15;
			this.txtParentGroupNo.Name = "txtParentGroupNo";
			// this.txtParentGroupNo.ShowButton = true;
			this.txtParentGroupNo.Size = new System.Drawing.Size(101, 19);
			this.txtParentGroupNo.TabIndex = 7;
			this.txtParentGroupNo.Text = "";
			// this.// = "";
			// this.//this.txtParentGroupNo.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(//this.txtParentGroupNo_DropButtonClick);
			// this.txtParentGroupNo.Leave += new System.EventHandler(this.txtParentGroupNo_Leave);
			// 
			// txtParentGroupName
			// 
			//this.txtParentGroupName.AllowDrop = true;
			this.txtParentGroupName.BackColor = System.Drawing.Color.FromArgb(239, 239, 239);
			this.txtParentGroupName.Enabled = false;
			this.txtParentGroupName.ForeColor = System.Drawing.Color.Black;
			this.txtParentGroupName.Location = new System.Drawing.Point(230, 88);
			this.txtParentGroupName.Name = "txtParentGroupName";
			this.txtParentGroupName.Size = new System.Drawing.Size(191, 19);
			this.txtParentGroupName.TabIndex = 8;
			this.txtParentGroupName.TabStop = false;
			this.txtParentGroupName.Text = " ";
			// this.// = "";
			// 
			// frmICSProductGroups
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.ClientSize = new System.Drawing.Size(429, 205);
			this.Controls.Add(this.txtComment);
			this.Controls.Add(this.txtGroupNo);
			this.Controls.Add(this.lblGroupNo);
			this.Controls.Add(this.lblLGroupName);
			this.Controls.Add(this.txtLGroupName);
			this.Controls.Add(this.lblParentGroup);
			this.Controls.Add(this.lblAGroupName);
			this.Controls.Add(this.txtAGroupName);
			this.Controls.Add(this.lblComments);
			this.Controls.Add(this.txtParentGroupNo);
			this.Controls.Add(this.txtParentGroupName);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			//this.Icon = (System.Drawing.Icon) resources.GetObject("frmICSProductGroups.Icon");
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(35, 158);
			this.MaximizeBox = true;
			this.MinimizeBox = true;
			this.Name = "frmICSProductGroups";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Product Groups";
			// this.Activated += new System.EventHandler(this.frmICSProductGroups_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
			// this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
			this.ResumeLayout(false);
		}
		// 
		#endregion
	}
}//ENDSHERE
