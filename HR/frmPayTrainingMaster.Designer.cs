
namespace Xtreme
{
	partial class frmPayTrainingMaster
	{

		#region "Upgrade Support "
		private static frmPayTrainingMaster m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmPayTrainingMaster DefInstance
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
		public static frmPayTrainingMaster CreateInstance()
		{
			frmPayTrainingMaster theInstance = new frmPayTrainingMaster();
			
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
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "txtComment", "txtTrainingNo", "lblLReligionName", "txtLTrainingName", "lblAReligionName", "txtATrainingName", "lblComments", "lblReligionNo"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public System.Windows.Forms.TextBox txtComment;
		public System.Windows.Forms.TextBox txtTrainingNo;
		public System.Windows.Forms.Label lblLReligionName;
		public System.Windows.Forms.TextBox txtLTrainingName;
		public System.Windows.Forms.Label lblAReligionName;
		public System.Windows.Forms.TextBox txtATrainingName;
		public System.Windows.Forms.Label lblComments;
		public System.Windows.Forms.Label lblReligionNo;
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPayTrainingMaster));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this.txtComment = new System.Windows.Forms.TextBox();
			this.txtTrainingNo = new System.Windows.Forms.TextBox();
			this.lblLReligionName = new System.Windows.Forms.Label();
			this.txtLTrainingName = new System.Windows.Forms.TextBox();
			this.lblAReligionName = new System.Windows.Forms.Label();
			this.txtATrainingName = new System.Windows.Forms.TextBox();
			this.lblComments = new System.Windows.Forms.Label();
			this.lblReligionNo = new System.Windows.Forms.Label();
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
			this.txtComment.Location = new System.Drawing.Point(164, 112);
			this.txtComment.MaxLength = 100;
			this.txtComment.Multiline = true;
			this.txtComment.Name = "txtComment";
			this.txtComment.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtComment.Size = new System.Drawing.Size(304, 59);
			this.txtComment.TabIndex = 0;
			// 
			// txtTrainingNo
			// 
			this.txtTrainingNo.AllowDrop = true;
			this.txtTrainingNo.BackColor = System.Drawing.Color.White;
			// this.txtTrainingNo.bolNumericOnly = true;
			this.txtTrainingNo.ForeColor = System.Drawing.Color.Black;
			this.txtTrainingNo.Location = new System.Drawing.Point(164, 48);
			this.txtTrainingNo.MaxLength = 15;
			// this.txtTrainingNo.mDropDownType = System.Windows.Forms.TextBox.DropDownTypes.ddtNextNumber;
			this.txtTrainingNo.Name = "txtTrainingNo";
			// this.txtTrainingNo.ShowButton = true;
			this.txtTrainingNo.Size = new System.Drawing.Size(101, 19);
			this.txtTrainingNo.TabIndex = 1;
			this.txtTrainingNo.Text = "";
			// 
			// lblLReligionName
			// 
			this.lblLReligionName.AllowDrop = true;
			this.lblLReligionName.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblLReligionName.Text = "Training Name (English)";
			this.lblLReligionName.Location = new System.Drawing.Point(26, 71);
			// // this.lblLReligionName.mLabelId = 1999;
			this.lblLReligionName.Name = "lblLReligionName";
			this.lblLReligionName.Size = new System.Drawing.Size(113, 14);
			this.lblLReligionName.TabIndex = 2;
			// 
			// txtLTrainingName
			// 
			this.txtLTrainingName.AllowDrop = true;
			this.txtLTrainingName.BackColor = System.Drawing.Color.White;
			this.txtLTrainingName.ForeColor = System.Drawing.Color.Black;
			this.txtLTrainingName.Location = new System.Drawing.Point(164, 69);
			this.txtLTrainingName.MaxLength = 50;
			this.txtLTrainingName.Name = "txtLTrainingName";
			this.txtLTrainingName.Size = new System.Drawing.Size(201, 19);
			this.txtLTrainingName.TabIndex = 3;
			this.txtLTrainingName.Text = "";
			// 
			// lblAReligionName
			// 
			this.lblAReligionName.AllowDrop = true;
			this.lblAReligionName.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblAReligionName.Text = "Training Name (Arabic)";
			this.lblAReligionName.Location = new System.Drawing.Point(26, 92);
			// // this.lblAReligionName.mLabelId = 2000;
			this.lblAReligionName.Name = "lblAReligionName";
			this.lblAReligionName.Size = new System.Drawing.Size(111, 14);
			this.lblAReligionName.TabIndex = 4;
			// 
			// txtATrainingName
			// 
			this.txtATrainingName.AllowDrop = true;
			this.txtATrainingName.BackColor = System.Drawing.Color.White;
			this.txtATrainingName.ForeColor = System.Drawing.Color.Black;
			this.txtATrainingName.Location = new System.Drawing.Point(164, 90);
			// this.txtATrainingName.mArabicEnabled = true;
			this.txtATrainingName.MaxLength = 50;
			this.txtATrainingName.Name = "txtATrainingName";
			this.txtATrainingName.Size = new System.Drawing.Size(201, 19);
			this.txtATrainingName.TabIndex = 5;
			this.txtATrainingName.Text = "";
			// 
			// lblComments
			// 
			this.lblComments.AllowDrop = true;
			this.lblComments.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblComments.Text = "Comment";
			this.lblComments.Location = new System.Drawing.Point(26, 112);
			// // this.lblComments.mLabelId = 1851;
			this.lblComments.Name = "lblComments";
			this.lblComments.Size = new System.Drawing.Size(44, 14);
			this.lblComments.TabIndex = 6;
			// 
			// lblReligionNo
			// 
			this.lblReligionNo.AllowDrop = true;
			this.lblReligionNo.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblReligionNo.Text = "Training Code";
			this.lblReligionNo.Location = new System.Drawing.Point(26, 50);
			// // this.lblReligionNo.mLabelId = 1998;
			this.lblReligionNo.Name = "lblReligionNo";
			this.lblReligionNo.Size = new System.Drawing.Size(66, 14);
			this.lblReligionNo.TabIndex = 7;
			// 
			// frmPayTrainingMaster
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.ClientSize = new System.Drawing.Size(486, 197);
			this.Controls.Add(this.txtComment);
			this.Controls.Add(this.txtTrainingNo);
			this.Controls.Add(this.lblLReligionName);
			this.Controls.Add(this.txtLTrainingName);
			this.Controls.Add(this.lblAReligionName);
			this.Controls.Add(this.txtATrainingName);
			this.Controls.Add(this.lblComments);
			this.Controls.Add(this.lblReligionNo);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			//this.Icon = (System.Drawing.Icon) resources.GetObject("frmPayTrainingMaster.Icon");
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(119, 177);
			this.MaximizeBox = true;
			this.MinimizeBox = true;
			this.Name = "frmPayTrainingMaster";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Training Master";
			// this.Activated += new System.EventHandler(this.frmPayTrainingMaster_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
			// this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
			this.ResumeLayout(false);
		}
		// 
		#endregion
	}
}//ENDSHERE
