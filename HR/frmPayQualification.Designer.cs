
namespace Xtreme
{
	partial class frmPayQualification
	{

		#region "Upgrade Support "
		private static frmPayQualification m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmPayQualification DefInstance
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
		public static frmPayQualification CreateInstance()
		{
			frmPayQualification theInstance = new frmPayQualification();
			
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
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "txtComment", "txtQalfnNo", "lblLNatName", "txtLQalfnName", "lblANatName", "txtAQalfnName", "lblComments", "lblNatNo"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public System.Windows.Forms.TextBox txtComment;
		public System.Windows.Forms.TextBox txtQalfnNo;
		public System.Windows.Forms.Label lblLNatName;
		public System.Windows.Forms.TextBox txtLQalfnName;
		public System.Windows.Forms.Label lblANatName;
		public System.Windows.Forms.TextBox txtAQalfnName;
		public System.Windows.Forms.Label lblComments;
		public System.Windows.Forms.Label lblNatNo;
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPayQualification));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this.txtComment = new System.Windows.Forms.TextBox();
			this.txtQalfnNo = new System.Windows.Forms.TextBox();
			this.lblLNatName = new System.Windows.Forms.Label();
			this.txtLQalfnName = new System.Windows.Forms.TextBox();
			this.lblANatName = new System.Windows.Forms.Label();
			this.txtAQalfnName = new System.Windows.Forms.TextBox();
			this.lblComments = new System.Windows.Forms.Label();
			this.lblNatNo = new System.Windows.Forms.Label();
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
			this.txtComment.Location = new System.Drawing.Point(150, 100);
			this.txtComment.MaxLength = 100;
			this.txtComment.Multiline = true;
			this.txtComment.Name = "txtComment";
			this.txtComment.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtComment.Size = new System.Drawing.Size(304, 59);
			this.txtComment.TabIndex = 0;
			// 
			// txtQalfnNo
			// 
			this.txtQalfnNo.AllowDrop = true;
			this.txtQalfnNo.BackColor = System.Drawing.Color.White;
			// this.txtQalfnNo.bolNumericOnly = true;
			this.txtQalfnNo.ForeColor = System.Drawing.Color.Black;
			this.txtQalfnNo.Location = new System.Drawing.Point(150, 36);
			this.txtQalfnNo.MaxLength = 15;
			// // = System.Windows.Forms.TextBox.DropDownTypes.ddtNextNumber;
			this.txtQalfnNo.Name = "txtQalfnNo";
			// this.txtQalfnNo.ShowButton = true;
			this.txtQalfnNo.Size = new System.Drawing.Size(101, 19);
			this.txtQalfnNo.TabIndex = 1;
			this.txtQalfnNo.Text = "";
			// this.//this.txtQalfnNo.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(//this.txtQalfnNo_DropButtonClick);
			// 
			// lblLNatName
			// 
			this.lblLNatName.AllowDrop = true;
			this.lblLNatName.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblLNatName.Text = "Qualification Name (English)";
			this.lblLNatName.Location = new System.Drawing.Point(12, 59);
			// // this.lblLNatName.mLabelId = 1228;
			this.lblLNatName.Name = "lblLNatName";
			this.lblLNatName.Size = new System.Drawing.Size(134, 14);
			this.lblLNatName.TabIndex = 2;
			// 
			// txtLQalfnName
			// 
			this.txtLQalfnName.AllowDrop = true;
			this.txtLQalfnName.BackColor = System.Drawing.Color.White;
			this.txtLQalfnName.ForeColor = System.Drawing.Color.Black;
			this.txtLQalfnName.Location = new System.Drawing.Point(150, 57);
			this.txtLQalfnName.MaxLength = 50;
			this.txtLQalfnName.Name = "txtLQalfnName";
			this.txtLQalfnName.Size = new System.Drawing.Size(201, 19);
			this.txtLQalfnName.TabIndex = 3;
			this.txtLQalfnName.Text = "";
			// 
			// lblANatName
			// 
			this.lblANatName.AllowDrop = true;
			this.lblANatName.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblANatName.Text = "Qualification Name (Arabic)";
			this.lblANatName.Location = new System.Drawing.Point(12, 80);
			// // this.lblANatName.mLabelId = 1935;
			this.lblANatName.Name = "lblANatName";
			this.lblANatName.Size = new System.Drawing.Size(132, 14);
			this.lblANatName.TabIndex = 4;
			// 
			// txtAQalfnName
			// 
			this.txtAQalfnName.AllowDrop = true;
			this.txtAQalfnName.BackColor = System.Drawing.Color.White;
			this.txtAQalfnName.ForeColor = System.Drawing.Color.Black;
			this.txtAQalfnName.Location = new System.Drawing.Point(150, 78);
			// // = true;
			this.txtAQalfnName.MaxLength = 50;
			this.txtAQalfnName.Name = "txtAQalfnName";
			this.txtAQalfnName.Size = new System.Drawing.Size(201, 19);
			this.txtAQalfnName.TabIndex = 5;
			this.txtAQalfnName.Text = "";
			// 
			// lblComments
			// 
			this.lblComments.AllowDrop = true;
			this.lblComments.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblComments.Text = "Comment";
			this.lblComments.Location = new System.Drawing.Point(12, 100);
			// // this.lblComments.mLabelId = 1851;
			this.lblComments.Name = "lblComments";
			this.lblComments.Size = new System.Drawing.Size(44, 14);
			this.lblComments.TabIndex = 6;
			// 
			// lblNatNo
			// 
			this.lblNatNo.AllowDrop = true;
			this.lblNatNo.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblNatNo.Text = "Qualification Code";
			this.lblNatNo.Location = new System.Drawing.Point(12, 38);
			// // this.lblNatNo.mLabelId = 1082;
			this.lblNatNo.Name = "lblNatNo";
			this.lblNatNo.Size = new System.Drawing.Size(87, 14);
			this.lblNatNo.TabIndex = 7;
			// 
			// frmPayQualification
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.ClientSize = new System.Drawing.Size(486, 197);
			this.Controls.Add(this.txtComment);
			this.Controls.Add(this.txtQalfnNo);
			this.Controls.Add(this.lblLNatName);
			this.Controls.Add(this.txtLQalfnName);
			this.Controls.Add(this.lblANatName);
			this.Controls.Add(this.txtAQalfnName);
			this.Controls.Add(this.lblComments);
			this.Controls.Add(this.lblNatNo);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			//this.Icon = (System.Drawing.Icon) resources.GetObject("frmPayQualification.Icon");
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(119, 177);
			this.MaximizeBox = true;
			this.MinimizeBox = true;
			this.Name = "frmPayQualification";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Qualification";
			// this.Activated += new System.EventHandler(this.frmPayQualification_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
			// this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
			this.ResumeLayout(false);
		}
		// 
		#endregion
	}
}//ENDSHERE
