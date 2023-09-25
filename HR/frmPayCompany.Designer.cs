
namespace Xtreme
{
	partial class frmPayCompany
	{

		#region "Upgrade Support "
		private static frmPayCompany m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmPayCompany DefInstance
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
		public static frmPayCompany CreateInstance()
		{
			frmPayCompany theInstance = new frmPayCompany();
			
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
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "txtComment", "lblCompNo", "lblLGroupName", "txtLCompName", "lblAGroupName", "txtACompName", "lblComments", "txtLThirdName", "txtLFourthName", "txtAFirstName", "txtASecondName", "txtAThirdName", "txtAFourthName", "txtCompNo", "txtLFirstName", "System.Windows.Forms.Label1", "System.Windows.Forms.Label3", "System.Windows.Forms.Label4", "txtLSecondName", "System.Windows.Forms.Label2", "System.Windows.Forms.Label5", "txtLicenseNo"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public System.Windows.Forms.TextBox txtComment;
		public System.Windows.Forms.Label lblCompNo;
		public System.Windows.Forms.Label lblLGroupName;
		public System.Windows.Forms.TextBox txtLCompName;
		public System.Windows.Forms.Label lblAGroupName;
		public System.Windows.Forms.TextBox txtACompName;
		public System.Windows.Forms.Label lblComments;
		public System.Windows.Forms.TextBox txtLThirdName;
		public System.Windows.Forms.TextBox txtLFourthName;
		public System.Windows.Forms.TextBox txtAFirstName;
		public System.Windows.Forms.TextBox txtASecondName;
		public System.Windows.Forms.TextBox txtAThirdName;
		public System.Windows.Forms.TextBox txtAFourthName;
		public System.Windows.Forms.TextBox txtCompNo;
		public System.Windows.Forms.TextBox txtLFirstName;
		public System.Windows.Forms.Label Label1;
		public System.Windows.Forms.Label Label3;
		public System.Windows.Forms.Label Label4;
		public System.Windows.Forms.TextBox txtLSecondName;
		public System.Windows.Forms.Label Label2;
		public System.Windows.Forms.Label Label5;
		public System.Windows.Forms.TextBox txtLicenseNo;
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPayCompany));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this.txtComment = new System.Windows.Forms.TextBox();
			this.lblCompNo = new System.Windows.Forms.Label();
			this.lblLGroupName = new System.Windows.Forms.Label();
			this.txtLCompName = new System.Windows.Forms.TextBox();
			this.lblAGroupName = new System.Windows.Forms.Label();
			this.txtACompName = new System.Windows.Forms.TextBox();
			this.lblComments = new System.Windows.Forms.Label();
			this.txtLThirdName = new System.Windows.Forms.TextBox();
			this.txtLFourthName = new System.Windows.Forms.TextBox();
			this.txtAFirstName = new System.Windows.Forms.TextBox();
			this.txtASecondName = new System.Windows.Forms.TextBox();
			this.txtAThirdName = new System.Windows.Forms.TextBox();
			this.txtAFourthName = new System.Windows.Forms.TextBox();
			this.txtCompNo = new System.Windows.Forms.TextBox();
			this.txtLFirstName = new System.Windows.Forms.TextBox();
			this.Label1 = new System.Windows.Forms.Label();
			this.Label3 = new System.Windows.Forms.Label();
			this.Label4 = new System.Windows.Forms.Label();
			this.txtLSecondName = new System.Windows.Forms.TextBox();
			this.Label2 = new System.Windows.Forms.Label();
			this.Label5 = new System.Windows.Forms.Label();
			this.txtLicenseNo = new System.Windows.Forms.TextBox();
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
			this.txtComment.Location = new System.Drawing.Point(142, 167);
			this.txtComment.MaxLength = 100;
			this.txtComment.Multiline = true;
			this.txtComment.Name = "txtComment";
			this.txtComment.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtComment.Size = new System.Drawing.Size(367, 19);
			this.txtComment.TabIndex = 10;
			// 
			// lblCompNo
			// 
			this.lblCompNo.AllowDrop = true;
			this.lblCompNo.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblCompNo.Text = "Company Code";
			this.lblCompNo.Location = new System.Drawing.Point(10, 49);
			// // this.lblCompNo.mLabelId = 1927;
			this.lblCompNo.Name = "lblCompNo";
			this.lblCompNo.Size = new System.Drawing.Size(73, 14);
			this.lblCompNo.TabIndex = 13;
			// 
			// lblLGroupName
			// 
			this.lblLGroupName.AllowDrop = true;
			this.lblLGroupName.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblLGroupName.Text = "Company Name (English)";
			this.lblLGroupName.Location = new System.Drawing.Point(10, 109);
			// // this.lblLGroupName.mLabelId = 1933;
			this.lblLGroupName.Name = "lblLGroupName";
			this.lblLGroupName.Size = new System.Drawing.Size(120, 14);
			this.lblLGroupName.TabIndex = 14;
			// 
			// txtLCompName
			// 
			this.txtLCompName.AllowDrop = true;
			this.txtLCompName.BackColor = System.Drawing.Color.White;
			this.txtLCompName.ForeColor = System.Drawing.Color.Black;
			this.txtLCompName.Location = new System.Drawing.Point(359, 4);
			this.txtLCompName.MaxLength = 50;
			this.txtLCompName.Name = "txtLCompName";
			this.txtLCompName.Size = new System.Drawing.Size(91, 19);
			this.txtLCompName.TabIndex = 11;
			this.txtLCompName.Text = "";
			this.txtLCompName.Visible = false;
			// 
			// lblAGroupName
			// 
			this.lblAGroupName.AllowDrop = true;
			this.lblAGroupName.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblAGroupName.Text = "Company Name (Arabic)";
			this.lblAGroupName.Location = new System.Drawing.Point(10, 128);
			// // this.lblAGroupName.mLabelId = 1934;
			this.lblAGroupName.Name = "lblAGroupName";
			this.lblAGroupName.Size = new System.Drawing.Size(118, 14);
			this.lblAGroupName.TabIndex = 15;
			// 
			// txtACompName
			// 
			this.txtACompName.AllowDrop = true;
			this.txtACompName.BackColor = System.Drawing.Color.White;
			this.txtACompName.ForeColor = System.Drawing.Color.Black;
			this.txtACompName.Location = new System.Drawing.Point(359, 25);
			// // = true;
			this.txtACompName.MaxLength = 50;
			this.txtACompName.Name = "txtACompName";
			this.txtACompName.Size = new System.Drawing.Size(91, 19);
			this.txtACompName.TabIndex = 12;
			this.txtACompName.Text = "";
			this.txtACompName.Visible = false;
			// 
			// lblComments
			// 
			this.lblComments.AllowDrop = true;
			this.lblComments.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblComments.Text = "Comment";
			this.lblComments.Location = new System.Drawing.Point(9, 170);
			// // this.lblComments.mLabelId = 1851;
			this.lblComments.Name = "lblComments";
			this.lblComments.Size = new System.Drawing.Size(44, 14);
			this.lblComments.TabIndex = 16;
			// 
			// txtLThirdName
			// 
			this.txtLThirdName.AllowDrop = true;
			this.txtLThirdName.BackColor = System.Drawing.Color.White;
			this.txtLThirdName.ForeColor = System.Drawing.Color.Black;
			this.txtLThirdName.Location = new System.Drawing.Point(326, 106);
			this.txtLThirdName.MaxLength = 50;
			this.txtLThirdName.Name = "txtLThirdName";
			this.txtLThirdName.Size = new System.Drawing.Size(91, 19);
			this.txtLThirdName.TabIndex = 3;
			this.txtLThirdName.Text = "";
			// 
			// txtLFourthName
			// 
			this.txtLFourthName.AllowDrop = true;
			this.txtLFourthName.BackColor = System.Drawing.Color.White;
			this.txtLFourthName.ForeColor = System.Drawing.Color.Black;
			this.txtLFourthName.Location = new System.Drawing.Point(419, 106);
			this.txtLFourthName.MaxLength = 50;
			this.txtLFourthName.Name = "txtLFourthName";
			this.txtLFourthName.Size = new System.Drawing.Size(91, 19);
			this.txtLFourthName.TabIndex = 4;
			this.txtLFourthName.Text = "";
			// 
			// txtAFirstName
			// 
			this.txtAFirstName.AllowDrop = true;
			this.txtAFirstName.BackColor = System.Drawing.Color.White;
			this.txtAFirstName.ForeColor = System.Drawing.Color.Black;
			this.txtAFirstName.Location = new System.Drawing.Point(142, 125);
			this.txtAFirstName.MaxLength = 50;
			this.txtAFirstName.Name = "txtAFirstName";
			this.txtAFirstName.Size = new System.Drawing.Size(91, 19);
			this.txtAFirstName.TabIndex = 5;
			this.txtAFirstName.Text = "";
			// 
			// txtASecondName
			// 
			this.txtASecondName.AllowDrop = true;
			this.txtASecondName.BackColor = System.Drawing.Color.White;
			this.txtASecondName.ForeColor = System.Drawing.Color.Black;
			this.txtASecondName.Location = new System.Drawing.Point(235, 125);
			this.txtASecondName.MaxLength = 50;
			this.txtASecondName.Name = "txtASecondName";
			this.txtASecondName.Size = new System.Drawing.Size(91, 19);
			this.txtASecondName.TabIndex = 6;
			this.txtASecondName.Text = "";
			// 
			// txtAThirdName
			// 
			this.txtAThirdName.AllowDrop = true;
			this.txtAThirdName.BackColor = System.Drawing.Color.White;
			this.txtAThirdName.ForeColor = System.Drawing.Color.Black;
			this.txtAThirdName.Location = new System.Drawing.Point(326, 125);
			this.txtAThirdName.MaxLength = 50;
			this.txtAThirdName.Name = "txtAThirdName";
			this.txtAThirdName.Size = new System.Drawing.Size(91, 19);
			this.txtAThirdName.TabIndex = 7;
			this.txtAThirdName.Text = "";
			// 
			// txtAFourthName
			// 
			this.txtAFourthName.AllowDrop = true;
			this.txtAFourthName.BackColor = System.Drawing.Color.White;
			this.txtAFourthName.ForeColor = System.Drawing.Color.Black;
			this.txtAFourthName.Location = new System.Drawing.Point(419, 125);
			this.txtAFourthName.MaxLength = 50;
			this.txtAFourthName.Name = "txtAFourthName";
			this.txtAFourthName.Size = new System.Drawing.Size(91, 19);
			this.txtAFourthName.TabIndex = 8;
			this.txtAFourthName.Text = "";
			// 
			// txtCompNo
			// 
			this.txtCompNo.AllowDrop = true;
			this.txtCompNo.BackColor = System.Drawing.Color.White;
			// this.txtCompNo.bolNumericOnly = true;
			this.txtCompNo.ForeColor = System.Drawing.Color.Black;
			this.txtCompNo.Location = new System.Drawing.Point(142, 47);
			this.txtCompNo.MaxLength = 15;
			// // = System.Windows.Forms.TextBox.DropDownTypes.ddtNextNumber;
			this.txtCompNo.Name = "txtCompNo";
			// this.txtCompNo.ShowButton = true;
			this.txtCompNo.Size = new System.Drawing.Size(91, 19);
			this.txtCompNo.TabIndex = 0;
			this.txtCompNo.Text = "";
			// this.//this.txtCompNo.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(//this.txtCompNo_DropButtonClick);
			// 
			// txtLFirstName
			// 
			this.txtLFirstName.AllowDrop = true;
			this.txtLFirstName.BackColor = System.Drawing.Color.White;
			this.txtLFirstName.ForeColor = System.Drawing.Color.Black;
			this.txtLFirstName.Location = new System.Drawing.Point(142, 106);
			this.txtLFirstName.MaxLength = 50;
			this.txtLFirstName.Name = "txtLFirstName";
			this.txtLFirstName.Size = new System.Drawing.Size(91, 19);
			this.txtLFirstName.TabIndex = 1;
			this.txtLFirstName.Text = "";
			// 
			// System.Windows.Forms.Label1
			// 
			this.Label1.AllowDrop = true;
			this.Label1.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.Label1.Text = "First Name";
			this.Label1.Location = new System.Drawing.Point(158, 84);
			// this.Label1.mLabelId = 1974;
			this.Label1.Name="Label1";
			this.Label1.Size = new System.Drawing.Size(51, 14);
			this.Label1.TabIndex = 17;
			// 
			// System.Windows.Forms.Label3
			// 
			this.Label3.AllowDrop = true;
			this.Label3.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.Label3.Text = "Third Name";
			this.Label3.Location = new System.Drawing.Point(345, 84);
			// this.Label3.mLabelId = 1977;
			this.Label3.Name="Label3";
			this.Label3.Size = new System.Drawing.Size(54, 14);
			this.Label3.TabIndex = 18;
			// 
			// System.Windows.Forms.Label4
			// 
			this.Label4.AllowDrop = true;
			this.Label4.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.Label4.Text = "Fourth Name";
			this.Label4.Location = new System.Drawing.Point(434, 84);
			// this.Label4.mLabelId = 1975;
			this.Label4.Name="Label4";
			this.Label4.Size = new System.Drawing.Size(61, 14);
			this.Label4.TabIndex = 19;
			// 
			// txtLSecondName
			// 
			this.txtLSecondName.AllowDrop = true;
			this.txtLSecondName.BackColor = System.Drawing.Color.White;
			this.txtLSecondName.ForeColor = System.Drawing.Color.Black;
			this.txtLSecondName.Location = new System.Drawing.Point(235, 106);
			this.txtLSecondName.MaxLength = 50;
			this.txtLSecondName.Name = "txtLSecondName";
			this.txtLSecondName.Size = new System.Drawing.Size(91, 19);
			this.txtLSecondName.TabIndex = 2;
			this.txtLSecondName.Text = "";
			// 
			// System.Windows.Forms.Label2
			// 
			this.Label2.AllowDrop = true;
			this.Label2.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.Label2.Text = "Second Name";
			this.Label2.Location = new System.Drawing.Point(247, 84);
			// this.Label2.mLabelId = 1976;
			this.Label2.Name="Label2";
			this.Label2.Size = new System.Drawing.Size(67, 14);
			this.Label2.TabIndex = 20;
			// 
			// System.Windows.Forms.Label5
			// 
			this.Label5.AllowDrop = true;
			this.Label5.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.Label5.Text = "License No.";
			this.Label5.Location = new System.Drawing.Point(10, 149);
			// this.Label5.mLabelId = 1851;
			this.Label5.Name="Label5";
			this.Label5.Size = new System.Drawing.Size(57, 14);
			this.Label5.TabIndex = 21;
			// 
			// txtLicenseNo
			// 
			this.txtLicenseNo.AllowDrop = true;
			this.txtLicenseNo.BackColor = System.Drawing.Color.White;
			this.txtLicenseNo.ForeColor = System.Drawing.Color.Black;
			this.txtLicenseNo.Location = new System.Drawing.Point(142, 146);
			this.txtLicenseNo.MaxLength = 50;
			this.txtLicenseNo.Name = "txtLicenseNo";
			this.txtLicenseNo.Size = new System.Drawing.Size(91, 19);
			this.txtLicenseNo.TabIndex = 9;
			this.txtLicenseNo.Text = "";
			// 
			// frmPayCompany
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.ClientSize = new System.Drawing.Size(524, 196);
			this.Controls.Add(this.txtComment);
			this.Controls.Add(this.lblCompNo);
			this.Controls.Add(this.lblLGroupName);
			this.Controls.Add(this.txtLCompName);
			this.Controls.Add(this.lblAGroupName);
			this.Controls.Add(this.txtACompName);
			this.Controls.Add(this.lblComments);
			this.Controls.Add(this.txtLThirdName);
			this.Controls.Add(this.txtLFourthName);
			this.Controls.Add(this.txtAFirstName);
			this.Controls.Add(this.txtASecondName);
			this.Controls.Add(this.txtAThirdName);
			this.Controls.Add(this.txtAFourthName);
			this.Controls.Add(this.txtCompNo);
			this.Controls.Add(this.txtLFirstName);
			this.Controls.Add(this.Label1);
			this.Controls.Add(this.Label3);
			this.Controls.Add(this.Label4);
			this.Controls.Add(this.txtLSecondName);
			this.Controls.Add(this.Label2);
			this.Controls.Add(this.Label5);
			this.Controls.Add(this.txtLicenseNo);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			//this.Icon = (System.Drawing.Icon) resources.GetObject("frmPayCompany.Icon");
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(237, 193);
			this.MaximizeBox = true;
			this.MinimizeBox = true;
			this.Name = "frmPayCompany";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Company";
			// this.Activated += new System.EventHandler(this.frmPayCompany_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
			// this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
			this.ResumeLayout(false);
		}
		// 
		#endregion
	}
}//ENDSHERE
