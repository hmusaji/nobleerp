
namespace Xtreme
{
	partial class frmPayAppraisalSurveyCategory
	{

		#region "Upgrade Support "
		private static frmPayAppraisalSurveyCategory m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmPayAppraisalSurveyCategory DefInstance
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
		public static frmPayAppraisalSurveyCategory CreateInstance()
		{
			frmPayAppraisalSurveyCategory theInstance = new frmPayAppraisalSurveyCategory();
			
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
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "lblACategoryName", "txtCategoryCode", "lblCategoryNo", "lblLCategoryName", "txtLCategoryName", "txtACategoryName", "lblComments", "txtLCategoryPurpose", "lblPurposeArb", "txtACategoryPurpose"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public System.Windows.Forms.Label lblACategoryName;
		public System.Windows.Forms.TextBox txtCategoryCode;
		public System.Windows.Forms.Label lblCategoryNo;
		public System.Windows.Forms.Label lblLCategoryName;
		public System.Windows.Forms.TextBox txtLCategoryName;
		public System.Windows.Forms.TextBox txtACategoryName;
		public System.Windows.Forms.Label lblComments;
		public System.Windows.Forms.TextBox txtLCategoryPurpose;
		public System.Windows.Forms.Label lblPurposeArb;
		public System.Windows.Forms.TextBox txtACategoryPurpose;
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPayAppraisalSurveyCategory));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this.lblACategoryName = new System.Windows.Forms.Label();
			this.txtCategoryCode = new System.Windows.Forms.TextBox();
			this.lblCategoryNo = new System.Windows.Forms.Label();
			this.lblLCategoryName = new System.Windows.Forms.Label();
			this.txtLCategoryName = new System.Windows.Forms.TextBox();
			this.txtACategoryName = new System.Windows.Forms.TextBox();
			this.lblComments = new System.Windows.Forms.Label();
			this.txtLCategoryPurpose = new System.Windows.Forms.TextBox();
			this.lblPurposeArb = new System.Windows.Forms.Label();
			this.txtACategoryPurpose = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// lblACategoryName
			// 
			this.lblACategoryName.AllowDrop = true;
			this.lblACategoryName.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblACategoryName.Text = "Category  (Arabic)";
			this.lblACategoryName.ForeColor = System.Drawing.Color.Black;
			this.lblACategoryName.Location = new System.Drawing.Point(6, 104);
			this.lblACategoryName.Name = "lblACategoryName";
			this.lblACategoryName.Size = new System.Drawing.Size(90, 14);
			this.lblACategoryName.TabIndex = 0;
			// 
			// txtCategoryCode
			// 
			this.txtCategoryCode.AllowDrop = true;
			this.txtCategoryCode.BackColor = System.Drawing.Color.White;
			// this.txtCategoryCode.bolNumericOnly = true;
			this.txtCategoryCode.ForeColor = System.Drawing.Color.Black;
			this.txtCategoryCode.Location = new System.Drawing.Point(130, 60);
			this.txtCategoryCode.MaxLength = 15;
			// // = System.Windows.Forms.TextBox.DropDownTypes.ddtNextNumber;
			this.txtCategoryCode.Name = "txtCategoryCode";
			// this.txtCategoryCode.ShowButton = true;
			this.txtCategoryCode.Size = new System.Drawing.Size(101, 19);
			this.txtCategoryCode.TabIndex = 1;
			this.txtCategoryCode.Text = "";
			// this.//this.txtCategoryCode.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(//this.txtCategoryCode_DropButtonClick);
			// 
			// lblCategoryNo
			// 
			this.lblCategoryNo.AllowDrop = true;
			this.lblCategoryNo.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblCategoryNo.Text = "Category Code";
			this.lblCategoryNo.ForeColor = System.Drawing.Color.Black;
			this.lblCategoryNo.Location = new System.Drawing.Point(6, 62);
			this.lblCategoryNo.Name = "lblCategoryNo";
			this.lblCategoryNo.Size = new System.Drawing.Size(72, 14);
			this.lblCategoryNo.TabIndex = 2;
			// 
			// lblLCategoryName
			// 
			this.lblLCategoryName.AllowDrop = true;
			this.lblLCategoryName.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblLCategoryName.Text = "Category  (English)";
			this.lblLCategoryName.ForeColor = System.Drawing.Color.Black;
			this.lblLCategoryName.Location = new System.Drawing.Point(6, 83);
			this.lblLCategoryName.Name = "lblLCategoryName";
			this.lblLCategoryName.Size = new System.Drawing.Size(92, 14);
			this.lblLCategoryName.TabIndex = 3;
			// 
			// txtLCategoryName
			// 
			this.txtLCategoryName.AllowDrop = true;
			this.txtLCategoryName.BackColor = System.Drawing.Color.White;
			this.txtLCategoryName.ForeColor = System.Drawing.Color.Black;
			this.txtLCategoryName.Location = new System.Drawing.Point(130, 81);
			this.txtLCategoryName.MaxLength = 50;
			this.txtLCategoryName.Name = "txtLCategoryName";
			this.txtLCategoryName.Size = new System.Drawing.Size(312, 19);
			this.txtLCategoryName.TabIndex = 4;
			this.txtLCategoryName.Text = "";
			// 
			// txtACategoryName
			// 
			this.txtACategoryName.AllowDrop = true;
			this.txtACategoryName.BackColor = System.Drawing.Color.White;
			this.txtACategoryName.ForeColor = System.Drawing.Color.Black;
			this.txtACategoryName.Location = new System.Drawing.Point(130, 102);
			// // = true;
			this.txtACategoryName.MaxLength = 50;
			this.txtACategoryName.Name = "txtACategoryName";
			this.txtACategoryName.Size = new System.Drawing.Size(312, 19);
			this.txtACategoryName.TabIndex = 5;
			this.txtACategoryName.Text = "";
			// 
			// lblComments
			// 
			this.lblComments.AllowDrop = true;
			this.lblComments.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblComments.Text = "Category Purpose (Eng)";
			this.lblComments.ForeColor = System.Drawing.Color.Black;
			this.lblComments.Location = new System.Drawing.Point(6, 140);
			this.lblComments.Name = "lblComments";
			this.lblComments.Size = new System.Drawing.Size(116, 14);
			this.lblComments.TabIndex = 6;
			// 
			// txtLCategoryPurpose
			// 
			this.txtLCategoryPurpose.AllowDrop = true;
			this.txtLCategoryPurpose.BackColor = System.Drawing.Color.White;
			this.txtLCategoryPurpose.ForeColor = System.Drawing.Color.Black;
			this.txtLCategoryPurpose.Location = new System.Drawing.Point(130, 126);
			this.txtLCategoryPurpose.MaxLength = 50;
			this.txtLCategoryPurpose.Name = "txtLCategoryPurpose";
			this.txtLCategoryPurpose.Size = new System.Drawing.Size(314, 49);
			this.txtLCategoryPurpose.TabIndex = 7;
			this.txtLCategoryPurpose.Text = "";
			// 
			// lblPurposeArb
			// 
			this.lblPurposeArb.AllowDrop = true;
			this.lblPurposeArb.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblPurposeArb.Text = "Category Purpose (ARB)";
			this.lblPurposeArb.ForeColor = System.Drawing.Color.Black;
			this.lblPurposeArb.Location = new System.Drawing.Point(6, 197);
			this.lblPurposeArb.Name = "lblPurposeArb";
			this.lblPurposeArb.Size = new System.Drawing.Size(120, 14);
			this.lblPurposeArb.TabIndex = 8;
			// 
			// txtACategoryPurpose
			// 
			this.txtACategoryPurpose.AllowDrop = true;
			this.txtACategoryPurpose.BackColor = System.Drawing.Color.White;
			this.txtACategoryPurpose.ForeColor = System.Drawing.Color.Black;
			this.txtACategoryPurpose.Location = new System.Drawing.Point(130, 180);
			this.txtACategoryPurpose.MaxLength = 50;
			this.txtACategoryPurpose.Name = "txtACategoryPurpose";
			this.txtACategoryPurpose.Size = new System.Drawing.Size(314, 49);
			this.txtACategoryPurpose.TabIndex = 9;
			this.txtACategoryPurpose.Text = "";
			// 
			// frmPayAppraisalSurveyCategory
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.ClientSize = new System.Drawing.Size(459, 239);
			this.Controls.Add(this.lblACategoryName);
			this.Controls.Add(this.txtCategoryCode);
			this.Controls.Add(this.lblCategoryNo);
			this.Controls.Add(this.lblLCategoryName);
			this.Controls.Add(this.txtLCategoryName);
			this.Controls.Add(this.txtACategoryName);
			this.Controls.Add(this.lblComments);
			this.Controls.Add(this.txtLCategoryPurpose);
			this.Controls.Add(this.lblPurposeArb);
			this.Controls.Add(this.txtACategoryPurpose);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			//this.Icon = (System.Drawing.Icon) resources.GetObject("frmPayAppraisalSurveyCategory.Icon");
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(124, 509);
			this.MaximizeBox = true;
			this.MinimizeBox = true;
			this.Name = "frmPayAppraisalSurveyCategory";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Survey Category";
			// this.Activated += new System.EventHandler(this.frmPayAppraisalSurveyCategory_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
			// this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
			this.ResumeLayout(false);
		}
		// 
		#endregion
	}
}//ENDSHERE
