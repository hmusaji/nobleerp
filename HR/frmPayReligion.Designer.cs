
namespace Xtreme
{
	partial class frmPayReligion
	{

		#region "Upgrade Support "
		private static frmPayReligion m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmPayReligion DefInstance
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
		public static frmPayReligion CreateInstance()
		{
			frmPayReligion theInstance = new frmPayReligion();
			
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
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "txtComment", "txtReligionNo", "lblLReligionName", "txtLReligionName", "lblAReligionName", "txtAReligionName", "lblComments", "lblReligionNo"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public System.Windows.Forms.TextBox txtComment;
		public System.Windows.Forms.TextBox txtReligionNo;
		public System.Windows.Forms.Label lblLReligionName;
		public System.Windows.Forms.TextBox txtLReligionName;
		public System.Windows.Forms.Label lblAReligionName;
		public System.Windows.Forms.TextBox txtAReligionName;
		public System.Windows.Forms.Label lblComments;
		public System.Windows.Forms.Label lblReligionNo;
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPayReligion));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this.txtComment = new System.Windows.Forms.TextBox();
			this.txtReligionNo = new System.Windows.Forms.TextBox();
			this.lblLReligionName = new System.Windows.Forms.Label();
			this.txtLReligionName = new System.Windows.Forms.TextBox();
			this.lblAReligionName = new System.Windows.Forms.Label();
			this.txtAReligionName = new System.Windows.Forms.TextBox();
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
			this.txtComment.Location = new System.Drawing.Point(152, 102);
			this.txtComment.MaxLength = 100;
			this.txtComment.Multiline = true;
			this.txtComment.Name = "txtComment";
			this.txtComment.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtComment.Size = new System.Drawing.Size(304, 59);
			this.txtComment.TabIndex = 0;
			// 
			// txtReligionNo
			// 
			this.txtReligionNo.AllowDrop = true;
			this.txtReligionNo.BackColor = System.Drawing.Color.White;
			// this.txtReligionNo.bolNumericOnly = true;
			this.txtReligionNo.ForeColor = System.Drawing.Color.Black;
			this.txtReligionNo.Location = new System.Drawing.Point(152, 38);
			this.txtReligionNo.MaxLength = 15;
			// this.txtReligionNo.mDropDownType = System.Windows.Forms.TextBox.DropDownTypes.ddtNextNumber;
			this.txtReligionNo.Name = "txtReligionNo";
			// this.txtReligionNo.ShowButton = true;
			this.txtReligionNo.Size = new System.Drawing.Size(101, 19);
			this.txtReligionNo.TabIndex = 1;
			this.txtReligionNo.Text = "";
			// this.this.txtReligionNo.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtReligionNo_DropButtonClick);
			// 
			// lblLReligionName
			// 
			this.lblLReligionName.AllowDrop = true;
			this.lblLReligionName.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblLReligionName.Text = "Religion Name (English)";
			this.lblLReligionName.Location = new System.Drawing.Point(14, 61);
			// this.lblLReligionName.mLabelId = 1230;
			this.lblLReligionName.Name = "lblLReligionName";
			this.lblLReligionName.Size = new System.Drawing.Size(112, 14);
			this.lblLReligionName.TabIndex = 2;
			// 
			// txtLReligionName
			// 
			this.txtLReligionName.AllowDrop = true;
			this.txtLReligionName.BackColor = System.Drawing.Color.White;
			this.txtLReligionName.ForeColor = System.Drawing.Color.Black;
			this.txtLReligionName.Location = new System.Drawing.Point(152, 59);
			this.txtLReligionName.MaxLength = 50;
			this.txtLReligionName.Name = "txtLReligionName";
			this.txtLReligionName.Size = new System.Drawing.Size(201, 19);
			this.txtLReligionName.TabIndex = 3;
			this.txtLReligionName.Text = "";
			// 
			// lblAReligionName
			// 
			this.lblAReligionName.AllowDrop = true;
			this.lblAReligionName.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblAReligionName.Text = "Religion Name (Arabic)";
			this.lblAReligionName.Location = new System.Drawing.Point(14, 82);
			// this.lblAReligionName.mLabelId = 1231;
			this.lblAReligionName.Name = "lblAReligionName";
			this.lblAReligionName.Size = new System.Drawing.Size(110, 14);
			this.lblAReligionName.TabIndex = 4;
			// 
			// txtAReligionName
			// 
			this.txtAReligionName.AllowDrop = true;
			this.txtAReligionName.BackColor = System.Drawing.Color.White;
			this.txtAReligionName.ForeColor = System.Drawing.Color.Black;
			this.txtAReligionName.Location = new System.Drawing.Point(152, 80);
			// this.txtAReligionName.mArabicEnabled = true;
			this.txtAReligionName.MaxLength = 50;
			this.txtAReligionName.Name = "txtAReligionName";
			this.txtAReligionName.Size = new System.Drawing.Size(201, 19);
			this.txtAReligionName.TabIndex = 5;
			this.txtAReligionName.Text = "";
			// 
			// lblComments
			// 
			this.lblComments.AllowDrop = true;
			this.lblComments.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblComments.Text = "Comment";
			this.lblComments.Location = new System.Drawing.Point(14, 102);
			// this.lblComments.mLabelId = 1851;
			this.lblComments.Name = "lblComments";
			this.lblComments.Size = new System.Drawing.Size(44, 14);
			this.lblComments.TabIndex = 6;
			// 
			// lblReligionNo
			// 
			this.lblReligionNo.AllowDrop = true;
			this.lblReligionNo.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblReligionNo.Text = "Religion Code";
			this.lblReligionNo.Location = new System.Drawing.Point(14, 40);
			// this.lblReligionNo.mLabelId = 1059;
			this.lblReligionNo.Name = "lblReligionNo";
			this.lblReligionNo.Size = new System.Drawing.Size(65, 14);
			this.lblReligionNo.TabIndex = 7;
			// 
			// frmPayReligion
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.ClientSize = new System.Drawing.Size(486, 197);
			this.Controls.Add(this.txtComment);
			this.Controls.Add(this.txtReligionNo);
			this.Controls.Add(this.lblLReligionName);
			this.Controls.Add(this.txtLReligionName);
			this.Controls.Add(this.lblAReligionName);
			this.Controls.Add(this.txtAReligionName);
			this.Controls.Add(this.lblComments);
			this.Controls.Add(this.lblReligionNo);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			//this.Icon = (System.Drawing.Icon) resources.GetObject("frmPayReligion.Icon");
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(119, 177);
			this.MaximizeBox = true;
			this.MinimizeBox = true;
			this.Name = "frmPayReligion";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Religion";
			// this.Activated += new System.EventHandler(this.frmPayReligion_Activated);
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