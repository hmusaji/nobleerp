
namespace Xtreme
{
	partial class frmPayDocumentType
	{

		#region "Upgrade Support "
		private static frmPayDocumentType m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmPayDocumentType DefInstance
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
		public static frmPayDocumentType CreateInstance()
		{
			frmPayDocumentType theInstance = new frmPayDocumentType();
			
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
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "lblACategoryName", "txtDocType", "lblCategoryNo", "lblLCategoryName", "txtLDocTypeName", "txtADocTypeName", "lblComments", "txtComments"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public System.Windows.Forms.Label lblACategoryName;
		public System.Windows.Forms.TextBox txtDocType;
		public System.Windows.Forms.Label lblCategoryNo;
		public System.Windows.Forms.Label lblLCategoryName;
		public System.Windows.Forms.TextBox txtLDocTypeName;
		public System.Windows.Forms.TextBox txtADocTypeName;
		public System.Windows.Forms.Label lblComments;
		public System.Windows.Forms.TextBox txtComments;
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPayDocumentType));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this.lblACategoryName = new System.Windows.Forms.Label();
			this.txtDocType = new System.Windows.Forms.TextBox();
			this.lblCategoryNo = new System.Windows.Forms.Label();
			this.lblLCategoryName = new System.Windows.Forms.Label();
			this.txtLDocTypeName = new System.Windows.Forms.TextBox();
			this.txtADocTypeName = new System.Windows.Forms.TextBox();
			this.lblComments = new System.Windows.Forms.Label();
			this.txtComments = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// lblACategoryName
			// 
			this.lblACategoryName.AllowDrop = true;
			this.lblACategoryName.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblACategoryName.Text = "DocumentType (Arabic)";
			this.lblACategoryName.ForeColor = System.Drawing.Color.Black;
			this.lblACategoryName.Location = new System.Drawing.Point(7, 101);
			// // this.lblACategoryName.mLabelId = 1815;
			this.lblACategoryName.Name = "lblACategoryName";
			this.lblACategoryName.Size = new System.Drawing.Size(115, 14);
			this.lblACategoryName.TabIndex = 6;
			// 
			// txtDocType
			// 
			this.txtDocType.AllowDrop = true;
			this.txtDocType.BackColor = System.Drawing.Color.White;
			// this.txtDocType.bolNumericOnly = true;
			this.txtDocType.ForeColor = System.Drawing.Color.Black;
			this.txtDocType.Location = new System.Drawing.Point(131, 57);
			this.txtDocType.MaxLength = 15;
			// this.txtDocType.mDropDownType = System.Windows.Forms.TextBox.DropDownTypes.ddtNextNumber;
			this.txtDocType.Name = "txtDocType";
			// this.txtDocType.ShowButton = true;
			this.txtDocType.Size = new System.Drawing.Size(101, 19);
			this.txtDocType.TabIndex = 0;
			this.txtDocType.Text = "";
			// this.this.txtDocType.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtDocType_DropButtonClick);
			// 
			// lblCategoryNo
			// 
			this.lblCategoryNo.AllowDrop = true;
			this.lblCategoryNo.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblCategoryNo.Text = "Document Type Code";
			this.lblCategoryNo.ForeColor = System.Drawing.Color.Black;
			this.lblCategoryNo.Location = new System.Drawing.Point(7, 59);
			// // this.lblCategoryNo.mLabelId = 1791;
			this.lblCategoryNo.Name = "lblCategoryNo";
			this.lblCategoryNo.Size = new System.Drawing.Size(103, 14);
			this.lblCategoryNo.TabIndex = 4;
			// 
			// lblLCategoryName
			// 
			this.lblLCategoryName.AllowDrop = true;
			this.lblLCategoryName.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblLCategoryName.Text = "Document Type (English)";
			this.lblLCategoryName.ForeColor = System.Drawing.Color.Black;
			this.lblLCategoryName.Location = new System.Drawing.Point(7, 80);
			// // this.lblLCategoryName.mLabelId = 1814;
			this.lblLCategoryName.Name = "lblLCategoryName";
			this.lblLCategoryName.Size = new System.Drawing.Size(120, 14);
			this.lblLCategoryName.TabIndex = 5;
			// 
			// txtLDocTypeName
			// 
			this.txtLDocTypeName.AllowDrop = true;
			this.txtLDocTypeName.BackColor = System.Drawing.Color.White;
			this.txtLDocTypeName.ForeColor = System.Drawing.Color.Black;
			this.txtLDocTypeName.Location = new System.Drawing.Point(131, 78);
			this.txtLDocTypeName.MaxLength = 50;
			this.txtLDocTypeName.Name = "txtLDocTypeName";
			this.txtLDocTypeName.Size = new System.Drawing.Size(201, 19);
			this.txtLDocTypeName.TabIndex = 1;
			this.txtLDocTypeName.Text = "";
			// 
			// txtADocTypeName
			// 
			this.txtADocTypeName.AllowDrop = true;
			this.txtADocTypeName.BackColor = System.Drawing.Color.White;
			this.txtADocTypeName.ForeColor = System.Drawing.Color.Black;
			this.txtADocTypeName.Location = new System.Drawing.Point(131, 99);
			// this.txtADocTypeName.mArabicEnabled = true;
			this.txtADocTypeName.MaxLength = 50;
			this.txtADocTypeName.Name = "txtADocTypeName";
			this.txtADocTypeName.Size = new System.Drawing.Size(201, 19);
			this.txtADocTypeName.TabIndex = 2;
			this.txtADocTypeName.Text = "";
			// 
			// lblComments
			// 
			this.lblComments.AllowDrop = true;
			this.lblComments.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblComments.Text = "Comments";
			this.lblComments.ForeColor = System.Drawing.Color.Black;
			this.lblComments.Location = new System.Drawing.Point(7, 120);
			// // this.lblComments.mLabelId = 1851;
			this.lblComments.Name = "lblComments";
			this.lblComments.Size = new System.Drawing.Size(50, 14);
			this.lblComments.TabIndex = 7;
			// 
			// txtComments
			// 
			this.txtComments.AllowDrop = true;
			this.txtComments.BackColor = System.Drawing.Color.White;
			this.txtComments.ForeColor = System.Drawing.Color.Black;
			this.txtComments.Location = new System.Drawing.Point(131, 120);
			this.txtComments.MaxLength = 50;
			this.txtComments.Name = "txtComments";
			this.txtComments.Size = new System.Drawing.Size(293, 49);
			this.txtComments.TabIndex = 3;
			this.txtComments.Text = "";
			// 
			// frmPayDocumentType
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.ClientSize = new System.Drawing.Size(429, 172);
			this.Controls.Add(this.lblACategoryName);
			this.Controls.Add(this.txtDocType);
			this.Controls.Add(this.lblCategoryNo);
			this.Controls.Add(this.lblLCategoryName);
			this.Controls.Add(this.txtLDocTypeName);
			this.Controls.Add(this.txtADocTypeName);
			this.Controls.Add(this.lblComments);
			this.Controls.Add(this.txtComments);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			//this.Icon = (System.Drawing.Icon) resources.GetObject("frmPayDocumentType.Icon");
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(171, 169);
			this.MaximizeBox = true;
			this.MinimizeBox = true;
			this.Name = "frmPayDocumentType";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "DocumentType";
			// this.Activated += new System.EventHandler(this.frmPayDocumentType_Activated);
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
