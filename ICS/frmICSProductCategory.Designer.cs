
namespace Xtreme
{
	partial class frmICSProductCategory
	{

		#region "Upgrade Support "
		private static frmICSProductCategory m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmICSProductCategory DefInstance
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
		public static frmICSProductCategory CreateInstance()
		{
			frmICSProductCategory theInstance = new frmICSProductCategory();
			
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
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "lblACategoryName", "txtComment", "txtCatNo", "lblCategoryNo", "lblLCategoryName", "txtLCatName", "txtACatName", "txtParentCatName", "lblParentCategory", "txtParentCatNo", "lblComments", "txtShortName", "System.Windows.Forms.Label1"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public System.Windows.Forms.Label lblACategoryName;
		public System.Windows.Forms.TextBox txtComment;
		public System.Windows.Forms.TextBox txtCatNo;
		public System.Windows.Forms.Label lblCategoryNo;
		public System.Windows.Forms.Label lblLCategoryName;
		public System.Windows.Forms.TextBox txtLCatName;
		public System.Windows.Forms.TextBox txtACatName;
		public System.Windows.Forms.TextBox txtParentCatName;
		public System.Windows.Forms.Label lblParentCategory;
		public System.Windows.Forms.TextBox txtParentCatNo;
		public System.Windows.Forms.Label lblComments;
		public System.Windows.Forms.TextBox txtShortName;
		public System.Windows.Forms.LabelLabel1;
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmICSProductCategory));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this.lblACategoryName = new System.Windows.Forms.Label();
			this.txtComment = new System.Windows.Forms.TextBox();
			this.txtCatNo = new System.Windows.Forms.TextBox();
			this.lblCategoryNo = new System.Windows.Forms.Label();
			this.lblLCategoryName = new System.Windows.Forms.Label();
			this.txtLCatName = new System.Windows.Forms.TextBox();
			this.txtACatName = new System.Windows.Forms.TextBox();
			this.txtParentCatName = new System.Windows.Forms.TextBox();
			this.lblParentCategory = new System.Windows.Forms.Label();
			this.txtParentCatNo = new System.Windows.Forms.TextBox();
			this.lblComments = new System.Windows.Forms.Label();
			this.txtShortName = new System.Windows.Forms.TextBox();
			this.Label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// lblACategoryName
			// 
			this.lblACategoryName.AllowDrop = true;
			this.lblACategoryName.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblACategoryName.Text = "Category Name (Arabic)";
			this.lblACategoryName.ForeColor = System.Drawing.Color.Black;
			this.lblACategoryName.Location = new System.Drawing.Point(10, 64);
			// // this.lblACategoryName.mLabelId = 955;
			this.lblACategoryName.Name = "lblACategoryName";
			this.lblACategoryName.Size = new System.Drawing.Size(117, 14);
			this.lblACategoryName.TabIndex = 4;
			// 
			// txtComment
			// 
			this.txtComment.AcceptsReturn = true;
			this.txtComment.AllowDrop = true;
			this.txtComment.BackColor = System.Drawing.SystemColors.Window;
			this.txtComment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtComment.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtComment.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtComment.Location = new System.Drawing.Point(141, 129);
			this.txtComment.MaxLength = 100;
			this.txtComment.Multiline = true;
			this.txtComment.Name = "txtComment";
			this.txtComment.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtComment.Size = new System.Drawing.Size(294, 49);
			this.txtComment.TabIndex = 9;
			// 
			// txtCatNo
			// 
			this.txtCatNo.AllowDrop = true;
			this.txtCatNo.BackColor = System.Drawing.Color.White;
			// this.txtCatNo.bolNumericOnly = true;
			this.txtCatNo.ForeColor = System.Drawing.Color.Black;
			this.txtCatNo.Location = new System.Drawing.Point(141, 21);
			this.txtCatNo.MaxLength = 15;
			// this.txtCatNo.mDropDownType = System.Windows.Forms.TextBox.DropDownTypes.ddtNextNumber;
			this.txtCatNo.Name = "txtCatNo";
			// this.txtCatNo.ShowButton = true;
			this.txtCatNo.Size = new System.Drawing.Size(101, 19);
			this.txtCatNo.TabIndex = 1;
			this.txtCatNo.Text = "";
			// this.this.txtCatNo.Watermark = "";
			// this.this.txtCatNo.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCatNo_DropButtonClick);
			// 
			// lblCategoryNo
			// 
			this.lblCategoryNo.AllowDrop = true;
			this.lblCategoryNo.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblCategoryNo.Text = "Category Code";
			this.lblCategoryNo.ForeColor = System.Drawing.Color.Black;
			this.lblCategoryNo.Location = new System.Drawing.Point(9, 23);
			// // this.lblCategoryNo.mLabelId = 116;
			this.lblCategoryNo.Name = "lblCategoryNo";
			this.lblCategoryNo.Size = new System.Drawing.Size(72, 14);
			this.lblCategoryNo.TabIndex = 0;
			// 
			// lblLCategoryName
			// 
			this.lblLCategoryName.AllowDrop = true;
			this.lblLCategoryName.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblLCategoryName.Text = "Category Name (English)";
			this.lblLCategoryName.ForeColor = System.Drawing.Color.Black;
			this.lblLCategoryName.Location = new System.Drawing.Point(9, 44);
			// // this.lblLCategoryName.mLabelId = 117;
			this.lblLCategoryName.Name = "lblLCategoryName";
			this.lblLCategoryName.Size = new System.Drawing.Size(119, 14);
			this.lblLCategoryName.TabIndex = 2;
			// 
			// txtLCatName
			// 
			this.txtLCatName.AllowDrop = true;
			this.txtLCatName.BackColor = System.Drawing.Color.White;
			this.txtLCatName.ForeColor = System.Drawing.Color.Black;
			this.txtLCatName.Location = new System.Drawing.Point(141, 42);
			this.txtLCatName.MaxLength = 50;
			this.txtLCatName.Name = "txtLCatName";
			this.txtLCatName.Size = new System.Drawing.Size(201, 19);
			this.txtLCatName.TabIndex = 3;
			this.txtLCatName.Text = "";
			// this.this.txtLCatName.Watermark = "";
			// 
			// txtACatName
			// 
			this.txtACatName.AllowDrop = true;
			this.txtACatName.BackColor = System.Drawing.Color.White;
			this.txtACatName.ForeColor = System.Drawing.Color.Black;
			this.txtACatName.Location = new System.Drawing.Point(141, 63);
			// this.txtACatName.mArabicEnabled = true;
			this.txtACatName.MaxLength = 50;
			this.txtACatName.Name = "txtACatName";
			this.txtACatName.Size = new System.Drawing.Size(201, 19);
			this.txtACatName.TabIndex = 5;
			this.txtACatName.Text = "";
			// this.this.txtACatName.Watermark = "";
			// 
			// txtParentCatName
			// 
			this.txtParentCatName.AllowDrop = true;
			this.txtParentCatName.BackColor = System.Drawing.Color.FromArgb(239, 239, 239);
			this.txtParentCatName.Enabled = false;
			this.txtParentCatName.ForeColor = System.Drawing.Color.Black;
			this.txtParentCatName.Location = new System.Drawing.Point(247, 108);
			this.txtParentCatName.Name = "txtParentCatName";
			this.txtParentCatName.Size = new System.Drawing.Size(187, 19);
			this.txtParentCatName.TabIndex = 6;
			this.txtParentCatName.TabStop = false;
			this.txtParentCatName.Text = " ";
			// this.this.txtParentCatName.Watermark = "";
			// 
			// lblParentCategory
			// 
			this.lblParentCategory.AllowDrop = true;
			this.lblParentCategory.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblParentCategory.Text = "Parent Category Code";
			this.lblParentCategory.ForeColor = System.Drawing.Color.Black;
			this.lblParentCategory.Location = new System.Drawing.Point(9, 110);
			// // this.lblParentCategory.mLabelId = 500;
			this.lblParentCategory.Name = "lblParentCategory";
			this.lblParentCategory.Size = new System.Drawing.Size(106, 14);
			this.lblParentCategory.TabIndex = 7;
			// 
			// txtParentCatNo
			// 
			this.txtParentCatNo.AllowDrop = true;
			this.txtParentCatNo.BackColor = System.Drawing.Color.White;
			// this.txtParentCatNo.bolNumericOnly = true;
			this.txtParentCatNo.ForeColor = System.Drawing.Color.Black;
			this.txtParentCatNo.Location = new System.Drawing.Point(141, 108);
			this.txtParentCatNo.MaxLength = 15;
			this.txtParentCatNo.Name = "txtParentCatNo";
			// this.txtParentCatNo.ShowButton = true;
			this.txtParentCatNo.Size = new System.Drawing.Size(101, 19);
			this.txtParentCatNo.TabIndex = 8;
			this.txtParentCatNo.Text = "";
			// this.this.txtParentCatNo.Watermark = "";
			// this.this.txtParentCatNo.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtParentCatNo_DropButtonClick);
			// this.txtParentCatNo.Leave += new System.EventHandler(this.txtParentCatNo_Leave);
			// 
			// lblComments
			// 
			this.lblComments.AllowDrop = true;
			this.lblComments.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblComments.Text = "Comment";
			this.lblComments.ForeColor = System.Drawing.Color.Black;
			this.lblComments.Location = new System.Drawing.Point(9, 129);
			// // this.lblComments.mLabelId = 135;
			this.lblComments.Name = "lblComments";
			this.lblComments.Size = new System.Drawing.Size(44, 14);
			this.lblComments.TabIndex = 10;
			// 
			// txtShortName
			// 
			this.txtShortName.AllowDrop = true;
			this.txtShortName.BackColor = System.Drawing.Color.White;
			this.txtShortName.ForeColor = System.Drawing.Color.Black;
			this.txtShortName.Location = new System.Drawing.Point(141, 85);
			// this.txtShortName.mArabicEnabled = true;
			this.txtShortName.MaxLength = 50;
			this.txtShortName.Name = "txtShortName";
			this.txtShortName.Size = new System.Drawing.Size(201, 19);
			this.txtShortName.TabIndex = 11;
			this.txtShortName.Text = "";
			// this.this.txtShortName.Watermark = "";
			// 
			// System.Windows.Forms.Label1
			// 
			this.Label1.AllowDrop = true;
			this.Label1.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.Label1.Text = "Short Name";
			this.Label1.ForeColor = System.Drawing.Color.Black;
			this.Label1.Location = new System.Drawing.Point(10, 88);
			// this.Label1.mLabelId = 709;
			this.Label1.Name = "System.Windows.Forms.Label1";
			this.Label1.Size = new System.Drawing.Size(56, 14);
			this.Label1.TabIndex = 12;
			// 
			// frmICSProductCategory
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.ClientSize = new System.Drawing.Size(566, 204);
			this.Controls.Add(this.lblACategoryName);
			this.Controls.Add(this.txtComment);
			this.Controls.Add(this.txtCatNo);
			this.Controls.Add(this.lblCategoryNo);
			this.Controls.Add(this.lblLCategoryName);
			this.Controls.Add(this.txtLCatName);
			this.Controls.Add(this.txtACatName);
			this.Controls.Add(this.txtParentCatName);
			this.Controls.Add(this.lblParentCategory);
			this.Controls.Add(this.txtParentCatNo);
			this.Controls.Add(this.lblComments);
			this.Controls.Add(this.txtShortName);
			this.Controls.Add(this.Label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			//this.Icon = (System.Drawing.Icon) resources.GetObject("frmICSProductCategory.Icon");
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(179, 159);
			this.MaximizeBox = true;
			this.MinimizeBox = true;
			this.Name = "frmICSProductCategory";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Product Category";
			// this.Activated += new System.EventHandler(this.frmICSProductCategory_Activated);
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
