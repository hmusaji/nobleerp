
namespace Xtreme
{
	partial class frmPayDocumentPlaceMaster
	{

		#region "Upgrade Support "
		private static frmPayDocumentPlaceMaster m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmPayDocumentPlaceMaster DefInstance
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
		public static frmPayDocumentPlaceMaster CreateInstance()
		{
			frmPayDocumentPlaceMaster theInstance = new frmPayDocumentPlaceMaster();
			
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
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "lblACategoryName", "txtDocNo", "lblCategoryNo", "lblLCategoryName", "txtLDocName", "txtADocName", "lblComments", "txtComments"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public System.Windows.Forms.Label lblACategoryName;
		public System.Windows.Forms.TextBox txtDocNo;
		public System.Windows.Forms.Label lblCategoryNo;
		public System.Windows.Forms.Label lblLCategoryName;
		public System.Windows.Forms.TextBox txtLDocName;
		public System.Windows.Forms.TextBox txtADocName;
		public System.Windows.Forms.Label lblComments;
		public System.Windows.Forms.TextBox txtComments;
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPayDocumentPlaceMaster));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this.lblACategoryName = new System.Windows.Forms.Label();
			this.txtDocNo = new System.Windows.Forms.TextBox();
			this.lblCategoryNo = new System.Windows.Forms.Label();
			this.lblLCategoryName = new System.Windows.Forms.Label();
			this.txtLDocName = new System.Windows.Forms.TextBox();
			this.txtADocName = new System.Windows.Forms.TextBox();
			this.lblComments = new System.Windows.Forms.Label();
			this.txtComments = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// lblACategoryName
			// 
			this.lblACategoryName.AllowDrop = true;
			this.lblACategoryName.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblACategoryName.Text = "Document Place (Arabic)";
			this.lblACategoryName.ForeColor = System.Drawing.Color.Black;
			this.lblACategoryName.Location = new System.Drawing.Point(7, 101);
			// // this.lblACategoryName.mLabelId = 1813;
			this.lblACategoryName.Name = "lblACategoryName";
			this.lblACategoryName.Size = new System.Drawing.Size(120, 14);
			this.lblACategoryName.TabIndex = 6;
			// 
			// txtDocNo
			// 
			this.txtDocNo.AllowDrop = true;
			this.txtDocNo.BackColor = System.Drawing.Color.White;
			// this.txtDocNo.bolNumericOnly = true;
			this.txtDocNo.ForeColor = System.Drawing.Color.Black;
			this.txtDocNo.Location = new System.Drawing.Point(130, 57);
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
			this.lblCategoryNo.Text = "Document Place Code";
			this.lblCategoryNo.ForeColor = System.Drawing.Color.Black;
			this.lblCategoryNo.Location = new System.Drawing.Point(7, 59);
			// // this.lblCategoryNo.mLabelId = 1811;
			this.lblCategoryNo.Name = "lblCategoryNo";
			this.lblCategoryNo.Size = new System.Drawing.Size(105, 14);
			this.lblCategoryNo.TabIndex = 4;
			// 
			// lblLCategoryName
			// 
			this.lblLCategoryName.AllowDrop = true;
			this.lblLCategoryName.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblLCategoryName.Text = "Document Place (English)";
			this.lblLCategoryName.ForeColor = System.Drawing.Color.Black;
			this.lblLCategoryName.Location = new System.Drawing.Point(7, 80);
			// // this.lblLCategoryName.mLabelId = 1812;
			this.lblLCategoryName.Name = "lblLCategoryName";
			this.lblLCategoryName.Size = new System.Drawing.Size(122, 14);
			this.lblLCategoryName.TabIndex = 5;
			// 
			// txtLDocName
			// 
			this.txtLDocName.AllowDrop = true;
			this.txtLDocName.BackColor = System.Drawing.Color.White;
			this.txtLDocName.ForeColor = System.Drawing.Color.Black;
			this.txtLDocName.Location = new System.Drawing.Point(131, 78);
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
			this.txtADocName.Location = new System.Drawing.Point(130, 99);
			// this.txtADocName.mArabicEnabled = true;
			this.txtADocName.MaxLength = 50;
			this.txtADocName.Name = "txtADocName";
			this.txtADocName.Size = new System.Drawing.Size(201, 19);
			this.txtADocName.TabIndex = 2;
			this.txtADocName.Text = "";
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
			this.txtComments.Location = new System.Drawing.Point(130, 120);
			this.txtComments.MaxLength = 50;
			this.txtComments.Name = "txtComments";
			this.txtComments.Size = new System.Drawing.Size(289, 45);
			this.txtComments.TabIndex = 3;
			this.txtComments.Text = "";
			// 
			// frmPayDocumentPlaceMaster
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.ClientSize = new System.Drawing.Size(429, 172);
			this.Controls.Add(this.lblACategoryName);
			this.Controls.Add(this.txtDocNo);
			this.Controls.Add(this.lblCategoryNo);
			this.Controls.Add(this.lblLCategoryName);
			this.Controls.Add(this.txtLDocName);
			this.Controls.Add(this.txtADocName);
			this.Controls.Add(this.lblComments);
			this.Controls.Add(this.txtComments);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			//this.Icon = (System.Drawing.Icon) resources.GetObject("frmPayDocumentPlaceMaster.Icon");
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(179, 159);
			this.MaximizeBox = true;
			this.MinimizeBox = true;
			this.Name = "frmPayDocumentPlaceMaster";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Document Place Master";
			// this.Activated += new System.EventHandler(this.frmPayDocumentPlaceMaster_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
			// this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
			this.ResumeLayout(false);
		}
		// 
		#endregion
	}
}//ENDSHERE
