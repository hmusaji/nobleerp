
namespace Xtreme
{
	partial class frmPayDocumentMaster
	{

		#region "Upgrade Support "
		private static frmPayDocumentMaster m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmPayDocumentMaster DefInstance
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
		public static frmPayDocumentMaster CreateInstance()
		{
			frmPayDocumentMaster theInstance = new frmPayDocumentMaster();
			
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
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "txtNotifyPeriod", "lblACategoryName", "txtDocNo", "lblCategoryNo", "lblLCategoryName", "txtLDocName", "txtADocName", "txtDocumentTypeName", "lblParentCategory", "txtDocumentTypeCd", "lblComments", "txtComments", "System.Windows.Forms.Label1"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public System.Windows.Forms.TextBox txtNotifyPeriod;
		public System.Windows.Forms.Label lblACategoryName;
		public System.Windows.Forms.TextBox txtDocNo;
		public System.Windows.Forms.Label lblCategoryNo;
		public System.Windows.Forms.Label lblLCategoryName;
		public System.Windows.Forms.TextBox txtLDocName;
		public System.Windows.Forms.TextBox txtADocName;
		public System.Windows.Forms.TextBox txtDocumentTypeName;
		public System.Windows.Forms.Label lblParentCategory;
		public System.Windows.Forms.TextBox txtDocumentTypeCd;
		public System.Windows.Forms.Label lblComments;
		public System.Windows.Forms.TextBox txtComments;
		public System.Windows.Forms.Label Label1;
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPayDocumentMaster));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this.txtNotifyPeriod = new System.Windows.Forms.TextBox();
			this.lblACategoryName = new System.Windows.Forms.Label();
			this.txtDocNo = new System.Windows.Forms.TextBox();
			this.lblCategoryNo = new System.Windows.Forms.Label();
			this.lblLCategoryName = new System.Windows.Forms.Label();
			this.txtLDocName = new System.Windows.Forms.TextBox();
			this.txtADocName = new System.Windows.Forms.TextBox();
			this.txtDocumentTypeName = new System.Windows.Forms.TextBox();
			this.lblParentCategory = new System.Windows.Forms.Label();
			this.txtDocumentTypeCd = new System.Windows.Forms.TextBox();
			this.lblComments = new System.Windows.Forms.Label();
			this.txtComments = new System.Windows.Forms.TextBox();
			this.Label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// txtNotifyPeriod
			// 
			this.txtNotifyPeriod.AllowDrop = true;
			this.txtNotifyPeriod.Location = new System.Drawing.Point(142, 141);
			// this.txtNotifyPeriod.MinValue = 0;
			this.txtNotifyPeriod.Name = "txtNotifyPeriod";
			this.txtNotifyPeriod.Size = new System.Drawing.Size(101, 19);
			this.txtNotifyPeriod.TabIndex = 4;
			// 
			// lblACategoryName
			// 
			this.lblACategoryName.AllowDrop = true;
			this.lblACategoryName.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblACategoryName.Text = "Document Name (Arabic)";
			this.lblACategoryName.ForeColor = System.Drawing.Color.Black;
			this.lblACategoryName.Location = new System.Drawing.Point(8, 101);
			// // this.lblACategoryName.mLabelId = 1790;
			this.lblACategoryName.Name = "lblACategoryName";
			this.lblACategoryName.Size = new System.Drawing.Size(121, 14);
			this.lblACategoryName.TabIndex = 8;
			// 
			// txtDocNo
			// 
			this.txtDocNo.AllowDrop = true;
			this.txtDocNo.BackColor = System.Drawing.Color.White;
			// this.txtDocNo.bolNumericOnly = true;
			this.txtDocNo.ForeColor = System.Drawing.Color.Black;
			this.txtDocNo.Location = new System.Drawing.Point(142, 57);
			this.txtDocNo.MaxLength = 15;
			// this.txtDocNo.mDropDownType = System.Windows.Forms.TextBox.DropDownTypes.ddtNextNumber;
			this.txtDocNo.Name = "txtDocNo";
			// this.txtDocNo.ShowButton = true;
			this.txtDocNo.Size = new System.Drawing.Size(101, 19);
			this.txtDocNo.TabIndex = 0;
			this.txtDocNo.Text = "";
			// this.this.txtDocNo.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtDocNo_DropButtonClick);
			// 
			// lblCategoryNo
			// 
			this.lblCategoryNo.AllowDrop = true;
			this.lblCategoryNo.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblCategoryNo.Text = "Document Code";
			this.lblCategoryNo.ForeColor = System.Drawing.Color.Black;
			this.lblCategoryNo.Location = new System.Drawing.Point(8, 59);
			// // this.lblCategoryNo.mLabelId = 1788;
			this.lblCategoryNo.Name = "lblCategoryNo";
			this.lblCategoryNo.Size = new System.Drawing.Size(76, 14);
			this.lblCategoryNo.TabIndex = 6;
			// 
			// lblLCategoryName
			// 
			this.lblLCategoryName.AllowDrop = true;
			this.lblLCategoryName.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblLCategoryName.Text = "Document Name (English)";
			this.lblLCategoryName.ForeColor = System.Drawing.Color.Black;
			this.lblLCategoryName.Location = new System.Drawing.Point(8, 80);
			// // this.lblLCategoryName.mLabelId = 1789;
			this.lblLCategoryName.Name = "lblLCategoryName";
			this.lblLCategoryName.Size = new System.Drawing.Size(123, 14);
			this.lblLCategoryName.TabIndex = 7;
			// 
			// txtLDocName
			// 
			this.txtLDocName.AllowDrop = true;
			this.txtLDocName.BackColor = System.Drawing.Color.White;
			this.txtLDocName.ForeColor = System.Drawing.Color.Black;
			this.txtLDocName.Location = new System.Drawing.Point(142, 78);
			this.txtLDocName.MaxLength = 50;
			this.txtLDocName.Name = "txtLDocName";
			this.txtLDocName.Size = new System.Drawing.Size(201, 19);
			this.txtLDocName.TabIndex = 1;
			this.txtLDocName.Text = "";
			// 
			// txtADocName
			// 
			this.txtADocName.AllowDrop = true;
			this.txtADocName.BackColor = System.Drawing.Color.White;
			this.txtADocName.ForeColor = System.Drawing.Color.Black;
			this.txtADocName.Location = new System.Drawing.Point(142, 99);
			// this.txtADocName.mArabicEnabled = true;
			this.txtADocName.MaxLength = 50;
			this.txtADocName.Name = "txtADocName";
			this.txtADocName.Size = new System.Drawing.Size(201, 19);
			this.txtADocName.TabIndex = 2;
			this.txtADocName.Text = "";
			// 
			// txtDocumentTypeName
			// 
			this.txtDocumentTypeName.AllowDrop = true;
			this.txtDocumentTypeName.BackColor = System.Drawing.Color.FromArgb(239, 239, 239);
			this.txtDocumentTypeName.Enabled = false;
			this.txtDocumentTypeName.ForeColor = System.Drawing.Color.Black;
			this.txtDocumentTypeName.Location = new System.Drawing.Point(245, 120);
			this.txtDocumentTypeName.Name = "txtDocumentTypeName";
			this.txtDocumentTypeName.Size = new System.Drawing.Size(187, 19);
			this.txtDocumentTypeName.TabIndex = 9;
			this.txtDocumentTypeName.TabStop = false;
			this.txtDocumentTypeName.Text = " ";
			// 
			// lblParentCategory
			// 
			this.lblParentCategory.AllowDrop = true;
			this.lblParentCategory.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblParentCategory.Text = "Document Type Code";
			this.lblParentCategory.ForeColor = System.Drawing.Color.Black;
			this.lblParentCategory.Location = new System.Drawing.Point(8, 122);
			// // this.lblParentCategory.mLabelId = 1791;
			this.lblParentCategory.Name = "lblParentCategory";
			this.lblParentCategory.Size = new System.Drawing.Size(103, 14);
			this.lblParentCategory.TabIndex = 10;
			// 
			// txtDocumentTypeCd
			// 
			this.txtDocumentTypeCd.AllowDrop = true;
			this.txtDocumentTypeCd.BackColor = System.Drawing.Color.White;
			// this.txtDocumentTypeCd.bolNumericOnly = true;
			this.txtDocumentTypeCd.ForeColor = System.Drawing.Color.Black;
			this.txtDocumentTypeCd.Location = new System.Drawing.Point(142, 120);
			this.txtDocumentTypeCd.MaxLength = 15;
			this.txtDocumentTypeCd.Name = "txtDocumentTypeCd";
			// this.txtDocumentTypeCd.ShowButton = true;
			this.txtDocumentTypeCd.Size = new System.Drawing.Size(101, 19);
			this.txtDocumentTypeCd.TabIndex = 3;
			this.txtDocumentTypeCd.Text = "";
			// this.this.txtDocumentTypeCd.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtDocumentTypeCd_DropButtonClick);
			// this.txtDocumentTypeCd.Leave += new System.EventHandler(this.txtDocumentTypeCd_Leave);
			// 
			// lblComments
			// 
			this.lblComments.AllowDrop = true;
			this.lblComments.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblComments.Text = "Comment";
			this.lblComments.ForeColor = System.Drawing.Color.Black;
			this.lblComments.Location = new System.Drawing.Point(7, 162);
			// // this.lblComments.mLabelId = 1851;
			this.lblComments.Name = "lblComments";
			this.lblComments.Size = new System.Drawing.Size(44, 14);
			this.lblComments.TabIndex = 11;
			// 
			// txtComments
			// 
			this.txtComments.AllowDrop = true;
			this.txtComments.BackColor = System.Drawing.Color.White;
			this.txtComments.ForeColor = System.Drawing.Color.Black;
			this.txtComments.Location = new System.Drawing.Point(142, 162);
			this.txtComments.MaxLength = 50;
			this.txtComments.Name = "txtComments";
			this.txtComments.Size = new System.Drawing.Size(291, 43);
			this.txtComments.TabIndex = 5;
			this.txtComments.Text = "";
			// 
			// System.Windows.Forms.Label1
			// 
			this.Label1.AllowDrop = true;
			this.Label1.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.Label1.Text = "Notification Period (in days)";
			this.Label1.ForeColor = System.Drawing.Color.Black;
			this.Label1.Location = new System.Drawing.Point(6, 144);
			// this.Label1.mLabelId = 2029;
			this.Label1.Name = "System.Windows.Forms.Label1";
			this.Label1.Size = new System.Drawing.Size(132, 14);
			this.Label1.TabIndex = 12;
			// 
			// frmPayDocumentMaster
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.ClientSize = new System.Drawing.Size(434, 207);
			this.Controls.Add(this.txtNotifyPeriod);
			this.Controls.Add(this.lblACategoryName);
			this.Controls.Add(this.txtDocNo);
			this.Controls.Add(this.lblCategoryNo);
			this.Controls.Add(this.lblLCategoryName);
			this.Controls.Add(this.txtLDocName);
			this.Controls.Add(this.txtADocName);
			this.Controls.Add(this.txtDocumentTypeName);
			this.Controls.Add(this.lblParentCategory);
			this.Controls.Add(this.txtDocumentTypeCd);
			this.Controls.Add(this.lblComments);
			this.Controls.Add(this.txtComments);
			this.Controls.Add(this.Label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			//this.Icon = (System.Drawing.Icon) resources.GetObject("frmPayDocumentMaster.Icon");
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(179, 159);
			this.MaximizeBox = true;
			this.MinimizeBox = true;
			this.Name = "frmPayDocumentMaster";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Document Master";
			// this.Activated += new System.EventHandler(this.frmPayDocumentMaster_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
			// this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
			this.ResumeLayout(false);
		}
		// 
		#endregion
	}
}//ENDSHERE
