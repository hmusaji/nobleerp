
namespace Xtreme
{
	partial class frmPayNationality
	{

		#region "Upgrade Support "
		private static frmPayNationality m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmPayNationality DefInstance
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
		public static frmPayNationality CreateInstance()
		{
			frmPayNationality theInstance = new frmPayNationality();
			
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
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "txtComment", "txtNatNo", "lblLNatName", "txtLNatName", "lblANatName", "txtANatName", "lblComments", "lblNatNo", "cntMainParameter"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public System.Windows.Forms.TextBox txtComment;
		public System.Windows.Forms.TextBox txtNatNo;
		public System.Windows.Forms.Label lblLNatName;
		public System.Windows.Forms.TextBox txtLNatName;
		public System.Windows.Forms.Label lblANatName;
		public System.Windows.Forms.TextBox txtANatName;
		public System.Windows.Forms.Label lblComments;
		public System.Windows.Forms.Label lblNatNo;
		public AxTDBContainer3D6.AxTDBContainer3D cntMainParameter;
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPayNationality));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this.cntMainParameter = new AxTDBContainer3D6.AxTDBContainer3D();
			this.txtComment = new System.Windows.Forms.TextBox();
			this.txtNatNo = new System.Windows.Forms.TextBox();
			this.lblLNatName = new System.Windows.Forms.Label();
			this.txtLNatName = new System.Windows.Forms.TextBox();
			this.lblANatName = new System.Windows.Forms.Label();
			this.txtANatName = new System.Windows.Forms.TextBox();
			this.lblComments = new System.Windows.Forms.Label();
			this.lblNatNo = new System.Windows.Forms.Label();
			// //((System.ComponentModel.ISupportInitialize) this.cntMainParameter).BeginInit();
			this.cntMainParameter.SuspendLayout();
			this.SuspendLayout();
			// 
			// cntMainParameter
			// 
			this.cntMainParameter.AllowDrop = true;
			this.cntMainParameter.Controls.Add(this.txtComment);
			this.cntMainParameter.Controls.Add(this.txtNatNo);
			this.cntMainParameter.Controls.Add(this.lblLNatName);
			this.cntMainParameter.Controls.Add(this.txtLNatName);
			this.cntMainParameter.Controls.Add(this.lblANatName);
			this.cntMainParameter.Controls.Add(this.txtANatName);
			this.cntMainParameter.Controls.Add(this.lblComments);
			this.cntMainParameter.Controls.Add(this.lblNatNo);
			this.cntMainParameter.Location = new System.Drawing.Point(4, 44);
			this.cntMainParameter.Name = "cntMainParameter";
			//
			this.cntMainParameter.Size = new System.Drawing.Size(477, 149);
			this.cntMainParameter.TabIndex = 4;
			// 
			// txtComment
			// 
			this.txtComment.AcceptsReturn = true;
			this.txtComment.AllowDrop = true;
			this.txtComment.BackColor = System.Drawing.SystemColors.Window;
			this.txtComment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtComment.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtComment.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtComment.Location = new System.Drawing.Point(146, 76);
			this.txtComment.MaxLength = 100;
			this.txtComment.Multiline = true;
			this.txtComment.Name = "txtComment";
			this.txtComment.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtComment.Size = new System.Drawing.Size(304, 59);
			this.txtComment.TabIndex = 3;
			// 
			// txtNatNo
			// 
			this.txtNatNo.AllowDrop = true;
			this.txtNatNo.BackColor = System.Drawing.Color.White;
			// this.txtNatNo.bolNumericOnly = true;
			this.txtNatNo.ForeColor = System.Drawing.Color.Black;
			this.txtNatNo.Location = new System.Drawing.Point(146, 12);
			this.txtNatNo.MaxLength = 15;
			// this.txtNatNo.mDropDownType = System.Windows.Forms.TextBox.DropDownTypes.ddtNextNumber;
			this.txtNatNo.Name = "txtNatNo";
			// this.txtNatNo.ShowButton = true;
			this.txtNatNo.Size = new System.Drawing.Size(101, 19);
			this.txtNatNo.TabIndex = 0;
			this.txtNatNo.Text = "";
			// this.this.txtNatNo.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtNatNo_DropButtonClick);
			// 
			// lblLNatName
			// 
			this.lblLNatName.AllowDrop = true;
			this.lblLNatName.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblLNatName.Text = "Nationality Name (English)";
			this.lblLNatName.Location = new System.Drawing.Point(8, 35);
			// // this.lblLNatName.mLabelId = 1143;
			this.lblLNatName.Name = "lblLNatName";
			this.lblLNatName.Size = new System.Drawing.Size(124, 14);
			this.lblLNatName.TabIndex = 5;
			// 
			// txtLNatName
			// 
			this.txtLNatName.AllowDrop = true;
			this.txtLNatName.BackColor = System.Drawing.Color.White;
			this.txtLNatName.ForeColor = System.Drawing.Color.Black;
			this.txtLNatName.Location = new System.Drawing.Point(146, 33);
			this.txtLNatName.MaxLength = 50;
			this.txtLNatName.Name = "txtLNatName";
			this.txtLNatName.Size = new System.Drawing.Size(201, 19);
			this.txtLNatName.TabIndex = 1;
			this.txtLNatName.Text = "";
			// 
			// lblANatName
			// 
			this.lblANatName.AllowDrop = true;
			this.lblANatName.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblANatName.Text = "Nationality Name (Arabic)";
			this.lblANatName.Location = new System.Drawing.Point(8, 56);
			// // this.lblANatName.mLabelId = 1144;
			this.lblANatName.Name = "lblANatName";
			this.lblANatName.Size = new System.Drawing.Size(122, 14);
			this.lblANatName.TabIndex = 6;
			// 
			// txtANatName
			// 
			this.txtANatName.AllowDrop = true;
			this.txtANatName.BackColor = System.Drawing.Color.White;
			this.txtANatName.ForeColor = System.Drawing.Color.Black;
			this.txtANatName.Location = new System.Drawing.Point(146, 54);
			// this.txtANatName.mArabicEnabled = true;
			this.txtANatName.MaxLength = 50;
			this.txtANatName.Name = "txtANatName";
			this.txtANatName.Size = new System.Drawing.Size(201, 19);
			this.txtANatName.TabIndex = 2;
			this.txtANatName.Text = "";
			// 
			// lblComments
			// 
			this.lblComments.AllowDrop = true;
			this.lblComments.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblComments.Text = "Comment";
			this.lblComments.Location = new System.Drawing.Point(8, 76);
			// // this.lblComments.mLabelId = 1851;
			this.lblComments.Name = "lblComments";
			this.lblComments.Size = new System.Drawing.Size(44, 14);
			this.lblComments.TabIndex = 7;
			// 
			// lblNatNo
			// 
			this.lblNatNo.AllowDrop = true;
			this.lblNatNo.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblNatNo.Text = "Nationality Code";
			this.lblNatNo.Location = new System.Drawing.Point(8, 14);
			// // this.lblNatNo.mLabelId = 1058;
			this.lblNatNo.Name = "lblNatNo";
			this.lblNatNo.Size = new System.Drawing.Size(77, 14);
			this.lblNatNo.TabIndex = 8;
			// 
			// frmPayNationality
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.ClientSize = new System.Drawing.Size(486, 197);
			this.Controls.Add(this.cntMainParameter);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			//this.Icon = (System.Drawing.Icon) resources.GetObject("frmPayNationality.Icon");
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(119, 177);
			this.MaximizeBox = true;
			this.MinimizeBox = true;
			this.Name = "frmPayNationality";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Nationality";
			// this.Activated += new System.EventHandler(this.frmPayNationality_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
			// this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
			//((System.ComponentModel.ISupportInitialize) this.cntMainParameter).EndInit();
			this.cntMainParameter.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		// 
		#endregion
	}
}//ENDSHERE
