
namespace Xtreme
{
	partial class frmPayDesignation
	{

		#region "Upgrade Support "
		private static frmPayDesignation m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmPayDesignation DefInstance
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
		public static frmPayDesignation CreateInstance()
		{
			frmPayDesignation theInstance = new frmPayDesignation();
			
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
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "txtComment", "txtDesgNo", "lblDesgNo", "lblLDesgName", "txtLDesgName", "lblAGroupName", "txtADesgName", "lblComments"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public System.Windows.Forms.TextBox txtComment;
		public System.Windows.Forms.TextBox txtDesgNo;
		public System.Windows.Forms.Label lblDesgNo;
		public System.Windows.Forms.Label lblLDesgName;
		public System.Windows.Forms.TextBox txtLDesgName;
		public System.Windows.Forms.Label lblAGroupName;
		public System.Windows.Forms.TextBox txtADesgName;
		public System.Windows.Forms.Label lblComments;
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPayDesignation));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this.txtComment = new System.Windows.Forms.TextBox();
			this.txtDesgNo = new System.Windows.Forms.TextBox();
			this.lblDesgNo = new System.Windows.Forms.Label();
			this.lblLDesgName = new System.Windows.Forms.Label();
			this.txtLDesgName = new System.Windows.Forms.TextBox();
			this.lblAGroupName = new System.Windows.Forms.Label();
			this.txtADesgName = new System.Windows.Forms.TextBox();
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
			this.txtComment.Location = new System.Drawing.Point(145, 121);
			this.txtComment.MaxLength = 100;
			this.txtComment.Multiline = true;
			this.txtComment.Name = "txtComment";
			this.txtComment.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtComment.Size = new System.Drawing.Size(294, 49);
			this.txtComment.TabIndex = 3;
			// 
			// txtDesgNo
			// 
			this.txtDesgNo.AllowDrop = true;
			this.txtDesgNo.BackColor = System.Drawing.Color.White;
			// this.txtDesgNo.bolNumericOnly = true;
			this.txtDesgNo.ForeColor = System.Drawing.Color.Black;
			this.txtDesgNo.Location = new System.Drawing.Point(145, 57);
			this.txtDesgNo.MaxLength = 15;
			// this.txtDesgNo.mDropDownType = System.Windows.Forms.TextBox.DropDownTypes.ddtNextNumber;
			this.txtDesgNo.Name = "txtDesgNo";
			// this.txtDesgNo.ShowButton = true;
			this.txtDesgNo.Size = new System.Drawing.Size(101, 19);
			this.txtDesgNo.TabIndex = 0;
			this.txtDesgNo.Text = "";
			// this.this.txtDesgNo.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtDesgNo_DropButtonClick);
			// 
			// lblDesgNo
			// 
			this.lblDesgNo.AllowDrop = true;
			this.lblDesgNo.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblDesgNo.Text = "Designation Code";
			this.lblDesgNo.Location = new System.Drawing.Point(9, 59);
			// // this.lblDesgNo.mLabelId = 1049;
			this.lblDesgNo.Name = "lblDesgNo";
			this.lblDesgNo.Size = new System.Drawing.Size(84, 14);
			this.lblDesgNo.TabIndex = 4;
			// 
			// lblLDesgName
			// 
			this.lblLDesgName.AllowDrop = true;
			this.lblLDesgName.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblLDesgName.Text = "Designation Name (English)";
			this.lblLDesgName.Location = new System.Drawing.Point(9, 81);
			// // this.lblLDesgName.mLabelId = 1050;
			this.lblLDesgName.Name = "lblLDesgName";
			this.lblLDesgName.Size = new System.Drawing.Size(131, 14);
			this.lblLDesgName.TabIndex = 5;
			// 
			// txtLDesgName
			// 
			this.txtLDesgName.AllowDrop = true;
			this.txtLDesgName.BackColor = System.Drawing.Color.White;
			this.txtLDesgName.ForeColor = System.Drawing.Color.Black;
			this.txtLDesgName.Location = new System.Drawing.Point(145, 78);
			this.txtLDesgName.MaxLength = 50;
			this.txtLDesgName.Name = "txtLDesgName";
			this.txtLDesgName.Size = new System.Drawing.Size(201, 19);
			this.txtLDesgName.TabIndex = 1;
			this.txtLDesgName.Text = "";
			// 
			// lblAGroupName
			// 
			this.lblAGroupName.AllowDrop = true;
			this.lblAGroupName.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblAGroupName.Text = "Designation Name (Arabic)";
			this.lblAGroupName.Location = new System.Drawing.Point(9, 102);
			// // this.lblAGroupName.mLabelId = 1051;
			this.lblAGroupName.Name = "lblAGroupName";
			this.lblAGroupName.Size = new System.Drawing.Size(129, 14);
			this.lblAGroupName.TabIndex = 6;
			// 
			// txtADesgName
			// 
			this.txtADesgName.AllowDrop = true;
			this.txtADesgName.BackColor = System.Drawing.Color.White;
			this.txtADesgName.ForeColor = System.Drawing.Color.Black;
			this.txtADesgName.Location = new System.Drawing.Point(145, 99);
			// this.txtADesgName.mArabicEnabled = true;
			this.txtADesgName.MaxLength = 50;
			this.txtADesgName.Name = "txtADesgName";
			this.txtADesgName.Size = new System.Drawing.Size(201, 19);
			this.txtADesgName.TabIndex = 2;
			this.txtADesgName.Text = "";
			// 
			// lblComments
			// 
			this.lblComments.AllowDrop = true;
			this.lblComments.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblComments.Text = "Comment";
			this.lblComments.Location = new System.Drawing.Point(9, 121);
			// // this.lblComments.mLabelId = 1851;
			this.lblComments.Name = "lblComments";
			this.lblComments.Size = new System.Drawing.Size(44, 14);
			this.lblComments.TabIndex = 7;
			// 
			// frmPayDesignation
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.ClientSize = new System.Drawing.Size(463, 188);
			this.Controls.Add(this.txtComment);
			this.Controls.Add(this.txtDesgNo);
			this.Controls.Add(this.lblDesgNo);
			this.Controls.Add(this.lblLDesgName);
			this.Controls.Add(this.txtLDesgName);
			this.Controls.Add(this.lblAGroupName);
			this.Controls.Add(this.txtADesgName);
			this.Controls.Add(this.lblComments);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			//this.Icon = (System.Drawing.Icon) resources.GetObject("frmPayDesignation.Icon");
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(16, 103);
			this.MaximizeBox = true;
			this.MinimizeBox = true;
			this.Name = "frmPayDesignation";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Designation";
			// this.Activated += new System.EventHandler(this.frmPayDesignation_Activated);
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
}//ENDSHERE
