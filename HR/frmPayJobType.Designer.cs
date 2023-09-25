
namespace Xtreme
{
	partial class frmPayJobType
	{

		#region "Upgrade Support "
		private static frmPayJobType m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmPayJobType DefInstance
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
		public static frmPayJobType CreateInstance()
		{
			frmPayJobType theInstance = new frmPayJobType();
			
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
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "txtComment", "txtJobTypeNo", "lblDesgNo", "lblLDesgName", "txtLJobTypeName", "lblAGroupName", "txtAJobTypeName", "lblComments"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public System.Windows.Forms.TextBox txtComment;
		public System.Windows.Forms.TextBox txtJobTypeNo;
		public System.Windows.Forms.Label lblDesgNo;
		public System.Windows.Forms.Label lblLDesgName;
		public System.Windows.Forms.TextBox txtLJobTypeName;
		public System.Windows.Forms.Label lblAGroupName;
		public System.Windows.Forms.TextBox txtAJobTypeName;
		public System.Windows.Forms.Label lblComments;
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPayJobType));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this.txtComment = new System.Windows.Forms.TextBox();
			this.txtJobTypeNo = new System.Windows.Forms.TextBox();
			this.lblDesgNo = new System.Windows.Forms.Label();
			this.lblLDesgName = new System.Windows.Forms.Label();
			this.txtLJobTypeName = new System.Windows.Forms.TextBox();
			this.lblAGroupName = new System.Windows.Forms.Label();
			this.txtAJobTypeName = new System.Windows.Forms.TextBox();
			this.lblComments = new System.Windows.Forms.Label();
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
			this.txtComment.Location = new System.Drawing.Point(145, 118);
			this.txtComment.MaxLength = 100;
			this.txtComment.Multiline = true;
			this.txtComment.Name = "txtComment";
			this.txtComment.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtComment.Size = new System.Drawing.Size(294, 49);
			this.txtComment.TabIndex = 0;
			// 
			// txtJobTypeNo
			// 
			this.txtJobTypeNo.AllowDrop = true;
			this.txtJobTypeNo.BackColor = System.Drawing.Color.White;
			// this.txtJobTypeNo.bolNumericOnly = true;
			this.txtJobTypeNo.ForeColor = System.Drawing.Color.Black;
			this.txtJobTypeNo.Location = new System.Drawing.Point(145, 54);
			this.txtJobTypeNo.MaxLength = 15;
			// this.txtJobTypeNo.mDropDownType = System.Windows.Forms.TextBox.DropDownTypes.ddtNextNumber;
			this.txtJobTypeNo.Name = "txtJobTypeNo";
			// this.txtJobTypeNo.ShowButton = true;
			this.txtJobTypeNo.Size = new System.Drawing.Size(101, 19);
			this.txtJobTypeNo.TabIndex = 1;
			this.txtJobTypeNo.Text = "";
			// this.this.txtJobTypeNo.Watermark = "";
			// 
			// lblDesgNo
			// 
			this.lblDesgNo.AllowDrop = true;
			this.lblDesgNo.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblDesgNo.Text = "Job Type No";
			this.lblDesgNo.Location = new System.Drawing.Point(9, 56);
			// // this.lblDesgNo.mLabelId = 2225;
			this.lblDesgNo.Name = "lblDesgNo";
			this.lblDesgNo.Size = new System.Drawing.Size(60, 14);
			this.lblDesgNo.TabIndex = 2;
			// 
			// lblLDesgName
			// 
			this.lblLDesgName.AllowDrop = true;
			this.lblLDesgName.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblLDesgName.Text = "JobType Name(ENG)";
			this.lblLDesgName.Location = new System.Drawing.Point(9, 78);
			// // this.lblLDesgName.mLabelId = 2230;
			this.lblLDesgName.Name = "lblLDesgName";
			this.lblLDesgName.Size = new System.Drawing.Size(100, 14);
			this.lblLDesgName.TabIndex = 3;
			// 
			// txtLJobTypeName
			// 
			this.txtLJobTypeName.AllowDrop = true;
			this.txtLJobTypeName.BackColor = System.Drawing.Color.White;
			this.txtLJobTypeName.ForeColor = System.Drawing.Color.Black;
			this.txtLJobTypeName.Location = new System.Drawing.Point(145, 75);
			this.txtLJobTypeName.MaxLength = 50;
			this.txtLJobTypeName.Name = "txtLJobTypeName";
			this.txtLJobTypeName.Size = new System.Drawing.Size(294, 19);
			this.txtLJobTypeName.TabIndex = 4;
			this.txtLJobTypeName.Text = "";
			// this.this.txtLJobTypeName.Watermark = "";
			// 
			// lblAGroupName
			// 
			this.lblAGroupName.AllowDrop = true;
			this.lblAGroupName.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblAGroupName.Text = "JobType Name(ARB)";
			this.lblAGroupName.Location = new System.Drawing.Point(9, 99);
			// // this.lblAGroupName.mLabelId = 2231;
			this.lblAGroupName.Name = "lblAGroupName";
			this.lblAGroupName.Size = new System.Drawing.Size(101, 14);
			this.lblAGroupName.TabIndex = 5;
			// 
			// txtAJobTypeName
			// 
			this.txtAJobTypeName.AllowDrop = true;
			this.txtAJobTypeName.BackColor = System.Drawing.Color.White;
			this.txtAJobTypeName.ForeColor = System.Drawing.Color.Black;
			this.txtAJobTypeName.Location = new System.Drawing.Point(145, 96);
			// this.txtAJobTypeName.mArabicEnabled = true;
			this.txtAJobTypeName.MaxLength = 50;
			this.txtAJobTypeName.Name = "txtAJobTypeName";
			this.txtAJobTypeName.Size = new System.Drawing.Size(294, 19);
			this.txtAJobTypeName.TabIndex = 6;
			this.txtAJobTypeName.Text = "";
			// this.this.txtAJobTypeName.Watermark = "";
			// 
			// lblComments
			// 
			this.lblComments.AllowDrop = true;
			this.lblComments.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblComments.Text = "Comment";
			this.lblComments.Location = new System.Drawing.Point(9, 118);
			// // this.lblComments.mLabelId = 2232;
			this.lblComments.Name = "lblComments";
			this.lblComments.Size = new System.Drawing.Size(50, 14);
			this.lblComments.TabIndex = 7;
			// 
			// frmPayJobType
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.ClientSize = new System.Drawing.Size(448, 190);
			this.Controls.Add(this.txtComment);
			this.Controls.Add(this.txtJobTypeNo);
			this.Controls.Add(this.lblDesgNo);
			this.Controls.Add(this.lblLDesgName);
			this.Controls.Add(this.txtLJobTypeName);
			this.Controls.Add(this.lblAGroupName);
			this.Controls.Add(this.txtAJobTypeName);
			this.Controls.Add(this.lblComments);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			//this.Icon = (System.Drawing.Icon) resources.GetObject("frmPayJobType.Icon");
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(324, 173);
			this.MaximizeBox = true;
			this.MinimizeBox = true;
			this.Name = "frmPayJobType";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Job Type";
			// this.Activated += new System.EventHandler(this.frmPayJobType_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
			// this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
			this.ResumeLayout(false);
		}
		// 
		#endregion
	}
}//ENDSHERE
