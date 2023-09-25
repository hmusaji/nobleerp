
namespace Xtreme
{
	partial class frmGLCostCenters
	{

		#region "Upgrade Support "
		private static frmGLCostCenters m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmGLCostCenters DefInstance
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
		public static frmGLCostCenters CreateInstance()
		{
			frmGLCostCenters theInstance = new frmGLCostCenters();
			
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
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "txtComment", "txtCostNo", "lblLCostName", "txtLCostName", "lblACostName", "txtACostName", "lblParentCost", "txtParentCostNo", "lblComments", "lblCostNo", "lblCostCategory", "txtCostCategoryNo", "txtCostCategoryName", "txtParentCostName", "cntMainParameter"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public System.Windows.Forms.TextBox txtComment;
		public System.Windows.Forms.TextBox txtCostNo;
		public System.Windows.Forms.Label lblLCostName;
		public System.Windows.Forms.TextBox txtLCostName;
		public System.Windows.Forms.Label lblACostName;
		public System.Windows.Forms.TextBox txtACostName;
		public System.Windows.Forms.Label lblParentCost;
		public System.Windows.Forms.TextBox txtParentCostNo;
		public System.Windows.Forms.Label lblComments;
		public System.Windows.Forms.Label lblCostNo;
		public System.Windows.Forms.Label lblCostCategory;
		public System.Windows.Forms.TextBox txtCostCategoryNo;
		public System.Windows.Forms.Label txtCostCategoryName;
		public System.Windows.Forms.Label txtParentCostName;
		public System.Windows.Forms.Panel cntMainParameter;
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGLCostCenters));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this.cntMainParameter = new System.Windows.Forms.Panel();
			this.txtComment = new System.Windows.Forms.TextBox();
			this.txtCostNo = new System.Windows.Forms.TextBox();
			this.lblLCostName = new System.Windows.Forms.Label();
			this.txtLCostName = new System.Windows.Forms.TextBox();
			this.lblACostName = new System.Windows.Forms.Label();
			this.txtACostName = new System.Windows.Forms.TextBox();
			this.lblParentCost = new System.Windows.Forms.Label();
			this.txtParentCostNo = new System.Windows.Forms.TextBox();
			this.lblComments = new System.Windows.Forms.Label();
			this.lblCostNo = new System.Windows.Forms.Label();
			this.lblCostCategory = new System.Windows.Forms.Label();
			this.txtCostCategoryNo = new System.Windows.Forms.TextBox();
			this.txtCostCategoryName = new System.Windows.Forms.Label();
			this.txtParentCostName = new System.Windows.Forms.Label();
			// //((System.ComponentModel.ISupportInitialize) this.cntMainParameter).BeginInit();
			//this.cntMainParameter.SuspendLayout();
			this.SuspendLayout();
			// 
			// cntMainParameter
			// 
			this.cntMainParameter.AllowDrop = true;
			this.cntMainParameter.Controls.Add(this.txtComment);
			this.cntMainParameter.Controls.Add(this.txtCostNo);
			this.cntMainParameter.Controls.Add(this.lblLCostName);
			this.cntMainParameter.Controls.Add(this.txtLCostName);
			this.cntMainParameter.Controls.Add(this.lblACostName);
			this.cntMainParameter.Controls.Add(this.txtACostName);
			this.cntMainParameter.Controls.Add(this.lblParentCost);
			this.cntMainParameter.Controls.Add(this.txtParentCostNo);
			this.cntMainParameter.Controls.Add(this.lblComments);
			this.cntMainParameter.Controls.Add(this.lblCostNo);
			this.cntMainParameter.Controls.Add(this.lblCostCategory);
			this.cntMainParameter.Controls.Add(this.txtCostCategoryNo);
			this.cntMainParameter.Controls.Add(this.txtCostCategoryName);
			this.cntMainParameter.Controls.Add(this.txtParentCostName);
			this.cntMainParameter.Location = new System.Drawing.Point(4, 8);
			this.cntMainParameter.Name = "cntMainParameter";
			//
			this.cntMainParameter.Size = new System.Drawing.Size(477, 195);
			this.cntMainParameter.TabIndex = 6;
			// 
			// txtComment
			// 
			this.txtComment.AcceptsReturn = true;
			this.txtComment.AllowDrop = true;
			this.txtComment.BackColor = System.Drawing.SystemColors.Window;
			this.txtComment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtComment.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtComment.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtComment.Location = new System.Drawing.Point(146, 118);
			this.txtComment.MaxLength = 100;
			this.txtComment.Multiline = true;
			this.txtComment.Name = "txtComment";
			this.txtComment.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtComment.Size = new System.Drawing.Size(304, 59);
			this.txtComment.TabIndex = 5;
			// 
			// txtCostNo
			// 
			this.txtCostNo.AllowDrop = true;
			this.txtCostNo.BackColor = System.Drawing.Color.White;
			// this.txtCostNo.bolNumericOnly = true;
			this.txtCostNo.ForeColor = System.Drawing.Color.Black;
			this.txtCostNo.Location = new System.Drawing.Point(146, 12);
			this.txtCostNo.MaxLength = 15;
			// // = System.Windows.Forms.TextBox.DropDownTypes.ddtNextNumber;
			this.txtCostNo.Name = "txtCostNo";
			// this.txtCostNo.ShowButton = true;
			this.txtCostNo.Size = new System.Drawing.Size(101, 19);
			this.txtCostNo.TabIndex = 0;
			this.txtCostNo.Text = "";
			// this.//this.txtCostNo.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(//this.txtCostNo_DropButtonClick);
			// 
			// lblLCostName
			// 
			this.lblLCostName.AllowDrop = true;
			this.lblLCostName.BackColor = System.Drawing.Color.FromArgb(237, 231, 235);
			this.lblLCostName.Text = "Cost Center Name (English)";
			this.lblLCostName.ForeColor = System.Drawing.Color.Black;
			this.lblLCostName.Location = new System.Drawing.Point(8, 35);
			// // this.lblLCostName.mLabelId = 964;
			this.lblLCostName.Name = "lblLCostName";
			this.lblLCostName.Size = new System.Drawing.Size(132, 14);
			this.lblLCostName.TabIndex = 7;
			// 
			// txtLCostName
			// 
			this.txtLCostName.AllowDrop = true;
			this.txtLCostName.BackColor = System.Drawing.Color.White;
			this.txtLCostName.ForeColor = System.Drawing.Color.Black;
			this.txtLCostName.Location = new System.Drawing.Point(146, 33);
			this.txtLCostName.MaxLength = 50;
			this.txtLCostName.Name = "txtLCostName";
			this.txtLCostName.Size = new System.Drawing.Size(201, 19);
			this.txtLCostName.TabIndex = 1;
			this.txtLCostName.Text = "";
			// 
			// lblACostName
			// 
			this.lblACostName.AllowDrop = true;
			this.lblACostName.BackColor = System.Drawing.Color.FromArgb(237, 231, 235);
			this.lblACostName.Text = "Cost Center Name (Arabic)";
			this.lblACostName.ForeColor = System.Drawing.Color.Black;
			this.lblACostName.Location = new System.Drawing.Point(8, 56);
			// // this.lblACostName.mLabelId = 965;
			this.lblACostName.Name = "lblACostName";
			this.lblACostName.Size = new System.Drawing.Size(130, 14);
			this.lblACostName.TabIndex = 8;
			// 
			// txtACostName
			// 
			this.txtACostName.AllowDrop = true;
			this.txtACostName.BackColor = System.Drawing.Color.White;
			this.txtACostName.ForeColor = System.Drawing.Color.Black;
			this.txtACostName.Location = new System.Drawing.Point(146, 54);
			// // = true;
			this.txtACostName.MaxLength = 50;
			this.txtACostName.Name = "txtACostName";
			this.txtACostName.Size = new System.Drawing.Size(201, 19);
			this.txtACostName.TabIndex = 2;
			this.txtACostName.Text = "";
			// 
			// lblParentCost
			// 
			this.lblParentCost.AllowDrop = true;
			this.lblParentCost.BackColor = System.Drawing.Color.FromArgb(237, 231, 235);
			this.lblParentCost.Text = "Under Cost Center";
			this.lblParentCost.ForeColor = System.Drawing.Color.Black;
			this.lblParentCost.Location = new System.Drawing.Point(8, 77);
			// // this.lblParentCost.mLabelId = 966;
			this.lblParentCost.Name = "lblParentCost";
			this.lblParentCost.Size = new System.Drawing.Size(89, 14);
			this.lblParentCost.TabIndex = 9;
			// 
			// txtParentCostNo
			// 
			this.txtParentCostNo.AllowDrop = true;
			this.txtParentCostNo.BackColor = System.Drawing.Color.White;
			// this.txtParentCostNo.bolNumericOnly = true;
			this.txtParentCostNo.ForeColor = System.Drawing.Color.Black;
			this.txtParentCostNo.Location = new System.Drawing.Point(146, 75);
			this.txtParentCostNo.MaxLength = 15;
			this.txtParentCostNo.Name = "txtParentCostNo";
			// this.txtParentCostNo.ShowButton = true;
			this.txtParentCostNo.Size = new System.Drawing.Size(101, 19);
			this.txtParentCostNo.TabIndex = 3;
			this.txtParentCostNo.Text = "";
			// this.//this.txtParentCostNo.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(//this.txtParentCostNo_DropButtonClick);
			// this.txtParentCostNo.Leave += new System.EventHandler(this.txtParentCostNo_Leave);
			// 
			// lblComments
			// 
			this.lblComments.AllowDrop = true;
			this.lblComments.BackColor = System.Drawing.Color.FromArgb(237, 231, 235);
			this.lblComments.Text = "Comment";
			this.lblComments.ForeColor = System.Drawing.Color.Black;
			this.lblComments.Location = new System.Drawing.Point(8, 118);
			// // this.lblComments.mLabelId = 135;
			this.lblComments.Name = "lblComments";
			this.lblComments.Size = new System.Drawing.Size(44, 14);
			this.lblComments.TabIndex = 10;
			// 
			// lblCostNo
			// 
			this.lblCostNo.AllowDrop = true;
			this.lblCostNo.BackColor = System.Drawing.Color.FromArgb(237, 231, 235);
			this.lblCostNo.Text = "Cost Center Code";
			this.lblCostNo.ForeColor = System.Drawing.Color.Black;
			this.lblCostNo.Location = new System.Drawing.Point(8, 14);
			// // this.lblCostNo.mLabelId = 149;
			this.lblCostNo.Name = "lblCostNo";
			this.lblCostNo.Size = new System.Drawing.Size(85, 14);
			this.lblCostNo.TabIndex = 11;
			// 
			// lblCostCategory
			// 
			this.lblCostCategory.AllowDrop = true;
			this.lblCostCategory.BackColor = System.Drawing.Color.FromArgb(237, 231, 235);
			this.lblCostCategory.Text = "Under Cost Category";
			this.lblCostCategory.ForeColor = System.Drawing.Color.Black;
			this.lblCostCategory.Location = new System.Drawing.Point(8, 98);
			// // this.lblCostCategory.mLabelId = 967;
			this.lblCostCategory.Name = "lblCostCategory";
			this.lblCostCategory.Size = new System.Drawing.Size(101, 14);
			this.lblCostCategory.TabIndex = 12;
			this.lblCostCategory.Visible = false;
			// 
			// txtCostCategoryNo
			// 
			this.txtCostCategoryNo.AllowDrop = true;
			this.txtCostCategoryNo.BackColor = System.Drawing.Color.White;
			// this.txtCostCategoryNo.bolNumericOnly = true;
			this.txtCostCategoryNo.ForeColor = System.Drawing.Color.Black;
			this.txtCostCategoryNo.Location = new System.Drawing.Point(146, 96);
			this.txtCostCategoryNo.MaxLength = 15;
			this.txtCostCategoryNo.Name = "txtCostCategoryNo";
			// this.txtCostCategoryNo.ShowButton = true;
			this.txtCostCategoryNo.Size = new System.Drawing.Size(101, 19);
			this.txtCostCategoryNo.TabIndex = 4;
			this.txtCostCategoryNo.Text = "";
			this.txtCostCategoryNo.Visible = false;
			// this.//this.txtCostCategoryNo.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(//this.txtCostCategoryNo_DropButtonClick);
			// this.txtCostCategoryNo.Leave += new System.EventHandler(this.txtCostCategoryNo_Leave);
			// 
			// txtCostCategoryName
			// 
			this.txtCostCategoryName.AllowDrop = true;
			this.txtCostCategoryName.Location = new System.Drawing.Point(249, 96);
			this.txtCostCategoryName.Name = "txtCostCategoryName";
			this.txtCostCategoryName.Size = new System.Drawing.Size(201, 19);
			this.txtCostCategoryName.TabIndex = 13;
			this.txtCostCategoryName.Visible = false;
			// 
			// txtParentCostName
			// 
			this.txtParentCostName.AllowDrop = true;
			this.txtParentCostName.Location = new System.Drawing.Point(249, 75);
			this.txtParentCostName.Name = "txtParentCostName";
			this.txtParentCostName.Size = new System.Drawing.Size(201, 19);
			this.txtParentCostName.TabIndex = 14;
			// 
			// frmGLCostCenters
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.ClientSize = new System.Drawing.Size(488, 244);
			this.Controls.Add(this.cntMainParameter);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			//this.Icon = (System.Drawing.Icon) resources.GetObject("frmGLCostCenters.Icon");
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(18, 192);
			this.MaximizeBox = true;
			this.MinimizeBox = true;
			this.Name = "frmGLCostCenters";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Cost Centers";
			// this.Activated += new System.EventHandler(this.frmGLCostCenters_Activated);
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
