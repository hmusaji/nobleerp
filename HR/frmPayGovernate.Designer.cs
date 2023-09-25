
namespace Xtreme
{
	partial class frmPayGovernate
	{

		#region "Upgrade Support "
		private static frmPayGovernate m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmPayGovernate DefInstance
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
		public static frmPayGovernate CreateInstance()
		{
			frmPayGovernate theInstance = new frmPayGovernate();
			
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
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "lblACategoryName", "txtGovNo", "lblCategoryNo", "lblLCategoryName", "txtLGovName", "txtAGovName", "lblComments", "txtComment"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public System.Windows.Forms.Label lblACategoryName;
		public System.Windows.Forms.TextBox txtGovNo;
		public System.Windows.Forms.Label lblCategoryNo;
		public System.Windows.Forms.Label lblLCategoryName;
		public System.Windows.Forms.TextBox txtLGovName;
		public System.Windows.Forms.TextBox txtAGovName;
		public System.Windows.Forms.Label lblComments;
		public System.Windows.Forms.TextBox txtComment;
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPayGovernate));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this.lblACategoryName = new System.Windows.Forms.Label();
			this.txtGovNo = new System.Windows.Forms.TextBox();
			this.lblCategoryNo = new System.Windows.Forms.Label();
			this.lblLCategoryName = new System.Windows.Forms.Label();
			this.txtLGovName = new System.Windows.Forms.TextBox();
			this.txtAGovName = new System.Windows.Forms.TextBox();
			this.lblComments = new System.Windows.Forms.Label();
			this.txtComment = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// lblACategoryName
			// 
			this.lblACategoryName.AllowDrop = true;
			this.lblACategoryName.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblACategoryName.Text = "Governate (Arabic)";
			this.lblACategoryName.ForeColor = System.Drawing.Color.Black;
			this.lblACategoryName.Location = new System.Drawing.Point(7, 101);
			// this.lblACategoryName.mLabelId = 1818;
			this.lblACategoryName.Name = "lblACategoryName";
			this.lblACategoryName.Size = new System.Drawing.Size(94, 14);
			this.lblACategoryName.TabIndex = 6;
			// 
			// txtGovNo
			// 
			this.txtGovNo.AllowDrop = true;
			this.txtGovNo.BackColor = System.Drawing.Color.White;
			// this.txtGovNo.bolNumericOnly = true;
			this.txtGovNo.ForeColor = System.Drawing.Color.Black;
			this.txtGovNo.Location = new System.Drawing.Point(131, 56);
			this.txtGovNo.MaxLength = 15;
			// this.txtGovNo.mDropDownType = System.Windows.Forms.TextBox.DropDownTypes.ddtNextNumber;
			this.txtGovNo.Name = "txtGovNo";
			// this.txtGovNo.ShowButton = true;
			this.txtGovNo.Size = new System.Drawing.Size(101, 19);
			this.txtGovNo.TabIndex = 0;
			this.txtGovNo.Text = "";
			// this.this.txtGovNo.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtGovNo_DropButtonClick);
			// 
			// lblCategoryNo
			// 
			this.lblCategoryNo.AllowDrop = true;
			this.lblCategoryNo.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblCategoryNo.Text = "Governate Code";
			this.lblCategoryNo.ForeColor = System.Drawing.Color.Black;
			this.lblCategoryNo.Location = new System.Drawing.Point(7, 59);
			// this.lblCategoryNo.mLabelId = 1816;
			this.lblCategoryNo.Name = "lblCategoryNo";
			this.lblCategoryNo.Size = new System.Drawing.Size(79, 14);
			this.lblCategoryNo.TabIndex = 4;
			// 
			// lblLCategoryName
			// 
			this.lblLCategoryName.AllowDrop = true;
			this.lblLCategoryName.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblLCategoryName.Text = "Governate (English)";
			this.lblLCategoryName.ForeColor = System.Drawing.Color.Black;
			this.lblLCategoryName.Location = new System.Drawing.Point(7, 80);
			// this.lblLCategoryName.mLabelId = 1817;
			this.lblLCategoryName.Name = "lblLCategoryName";
			this.lblLCategoryName.Size = new System.Drawing.Size(96, 14);
			this.lblLCategoryName.TabIndex = 5;
			// 
			// txtLGovName
			// 
			this.txtLGovName.AllowDrop = true;
			this.txtLGovName.BackColor = System.Drawing.Color.White;
			this.txtLGovName.ForeColor = System.Drawing.Color.Black;
			this.txtLGovName.Location = new System.Drawing.Point(131, 78);
			this.txtLGovName.MaxLength = 50;
			this.txtLGovName.Name = "txtLGovName";
			this.txtLGovName.Size = new System.Drawing.Size(201, 19);
			this.txtLGovName.TabIndex = 1;
			this.txtLGovName.Text = "";
			// 
			// txtAGovName
			// 
			this.txtAGovName.AllowDrop = true;
			this.txtAGovName.BackColor = System.Drawing.Color.White;
			this.txtAGovName.ForeColor = System.Drawing.Color.Black;
			this.txtAGovName.Location = new System.Drawing.Point(131, 99);
			// this.txtAGovName.mArabicEnabled = true;
			this.txtAGovName.MaxLength = 50;
			this.txtAGovName.Name = "txtAGovName";
			this.txtAGovName.Size = new System.Drawing.Size(201, 19);
			this.txtAGovName.TabIndex = 2;
			this.txtAGovName.Text = "";
			// 
			// lblComments
			// 
			this.lblComments.AllowDrop = true;
			this.lblComments.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblComments.Text = "Comment";
			this.lblComments.ForeColor = System.Drawing.Color.Black;
			this.lblComments.Location = new System.Drawing.Point(8, 120);
			// this.lblComments.mLabelId = 1851;
			this.lblComments.Name = "lblComments";
			this.lblComments.Size = new System.Drawing.Size(44, 14);
			this.lblComments.TabIndex = 7;
			// 
			// txtComment
			// 
			this.txtComment.AllowDrop = true;
			this.txtComment.BackColor = System.Drawing.Color.White;
			this.txtComment.ForeColor = System.Drawing.Color.Black;
			this.txtComment.Location = new System.Drawing.Point(131, 120);
			this.txtComment.MaxLength = 50;
			this.txtComment.Name = "txtComment";
			this.txtComment.Size = new System.Drawing.Size(291, 45);
			this.txtComment.TabIndex = 3;
			this.txtComment.Text = "";
			// 
			// frmPayGovernate
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.ClientSize = new System.Drawing.Size(429, 172);
			this.Controls.Add(this.lblACategoryName);
			this.Controls.Add(this.txtGovNo);
			this.Controls.Add(this.lblCategoryNo);
			this.Controls.Add(this.lblLCategoryName);
			this.Controls.Add(this.txtLGovName);
			this.Controls.Add(this.txtAGovName);
			this.Controls.Add(this.lblComments);
			this.Controls.Add(this.txtComment);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			//this.Icon = (System.Drawing.Icon) resources.GetObject("frmPayGovernate.Icon");
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(116, 149);
			this.MaximizeBox = true;
			this.MinimizeBox = true;
			this.Name = "frmPayGovernate";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Governate";
			// this.Activated += new System.EventHandler(this.frmPayGovernate_Activated);
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