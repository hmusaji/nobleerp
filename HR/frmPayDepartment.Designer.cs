
namespace Xtreme
{
	partial class frmPayDepartment
	{

		#region "Upgrade Support "
		private static frmPayDepartment m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmPayDepartment DefInstance
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
		public static frmPayDepartment CreateInstance()
		{
			frmPayDepartment theInstance = new frmPayDepartment();
			
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
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "txtComment", "txtDeptNo", "lblGroupNo", "lblLGroupName", "txtLDeptName", "lblParentGroup", "lblAGroupName", "txtADeptName", "lblComments", "txtParentDeptNo", "txtParentDeptName", "txtDlblAppTemplateName", "txtApprovalTemplate", "_lblApprovalTemplate_28", "lblApprovalTemplate"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public System.Windows.Forms.TextBox txtComment;
		public System.Windows.Forms.TextBox txtDeptNo;
		public System.Windows.Forms.Label lblGroupNo;
		public System.Windows.Forms.Label lblLGroupName;
		public System.Windows.Forms.TextBox txtLDeptName;
		public System.Windows.Forms.Label lblParentGroup;
		public System.Windows.Forms.Label lblAGroupName;
		public System.Windows.Forms.TextBox txtADeptName;
		public System.Windows.Forms.Label lblComments;
		public System.Windows.Forms.TextBox txtParentDeptNo;
		public System.Windows.Forms.TextBox txtParentDeptName;
		public System.Windows.Forms.Label txtDlblAppTemplateName;
		public System.Windows.Forms.TextBox txtApprovalTemplate;
		private System.Windows.Forms.Label _lblApprovalTemplate_28;
		public System.Windows.Forms.Label[] lblApprovalTemplate = new System.Windows.Forms.Label[29];
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPayDepartment));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this.txtComment = new System.Windows.Forms.TextBox();
			this.txtDeptNo = new System.Windows.Forms.TextBox();
			this.lblGroupNo = new System.Windows.Forms.Label();
			this.lblLGroupName = new System.Windows.Forms.Label();
			this.txtLDeptName = new System.Windows.Forms.TextBox();
			this.lblParentGroup = new System.Windows.Forms.Label();
			this.lblAGroupName = new System.Windows.Forms.Label();
			this.txtADeptName = new System.Windows.Forms.TextBox();
			this.lblComments = new System.Windows.Forms.Label();
			this.txtParentDeptNo = new System.Windows.Forms.TextBox();
			this.txtParentDeptName = new System.Windows.Forms.TextBox();
			this.txtDlblAppTemplateName = new System.Windows.Forms.Label();
			this.txtApprovalTemplate = new System.Windows.Forms.TextBox();
			this._lblApprovalTemplate_28 = new System.Windows.Forms.Label();
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
			this.txtComment.Location = new System.Drawing.Point(145, 143);
			this.txtComment.MaxLength = 100;
			this.txtComment.Multiline = true;
			this.txtComment.Name = "txtComment";
			this.txtComment.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtComment.Size = new System.Drawing.Size(294, 49);
			this.txtComment.TabIndex = 5;
			// 
			// txtDeptNo
			// 
			this.txtDeptNo.AllowDrop = true;
			this.txtDeptNo.BackColor = System.Drawing.Color.White;
			// this.txtDeptNo.bolNumericOnly = true;
			this.txtDeptNo.ForeColor = System.Drawing.Color.Black;
			this.txtDeptNo.Location = new System.Drawing.Point(145, 57);
			this.txtDeptNo.MaxLength = 15;
			// this.txtDeptNo.mDropDownType = System.Windows.Forms.TextBox.DropDownTypes.ddtNextNumber;
			this.txtDeptNo.Name = "txtDeptNo";
			// this.txtDeptNo.ShowButton = true;
			this.txtDeptNo.Size = new System.Drawing.Size(101, 19);
			this.txtDeptNo.TabIndex = 0;
			this.txtDeptNo.Text = "";
			// this.this.txtDeptNo.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtDeptNo_DropButtonClick);
			// 
			// lblGroupNo
			// 
			this.lblGroupNo.AllowDrop = true;
			this.lblGroupNo.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblGroupNo.Text = "Department Code";
			this.lblGroupNo.Location = new System.Drawing.Point(9, 59);
			// // this.lblGroupNo.mLabelId = 1973;
			this.lblGroupNo.Name = "lblGroupNo";
			this.lblGroupNo.Size = new System.Drawing.Size(83, 14);
			this.lblGroupNo.TabIndex = 6;
			// 
			// lblLGroupName
			// 
			this.lblLGroupName.AllowDrop = true;
			this.lblLGroupName.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblLGroupName.Text = "Department Name (English)";
			this.lblLGroupName.Location = new System.Drawing.Point(9, 81);
			// // this.lblLGroupName.mLabelId = 1046;
			this.lblLGroupName.Name = "lblLGroupName";
			this.lblLGroupName.Size = new System.Drawing.Size(130, 14);
			this.lblLGroupName.TabIndex = 7;
			// 
			// txtLDeptName
			// 
			this.txtLDeptName.AllowDrop = true;
			this.txtLDeptName.BackColor = System.Drawing.Color.White;
			this.txtLDeptName.ForeColor = System.Drawing.Color.Black;
			this.txtLDeptName.Location = new System.Drawing.Point(145, 78);
			this.txtLDeptName.MaxLength = 50;
			this.txtLDeptName.Name = "txtLDeptName";
			this.txtLDeptName.Size = new System.Drawing.Size(201, 19);
			this.txtLDeptName.TabIndex = 1;
			this.txtLDeptName.Text = "";
			// 
			// lblParentGroup
			// 
			this.lblParentGroup.AllowDrop = true;
			this.lblParentGroup.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblParentGroup.Text = "Under Department";
			this.lblParentGroup.Location = new System.Drawing.Point(9, 123);
			// // this.lblParentGroup.mLabelId = 1048;
			this.lblParentGroup.Name = "lblParentGroup";
			this.lblParentGroup.Size = new System.Drawing.Size(87, 14);
			this.lblParentGroup.TabIndex = 8;
			// 
			// lblAGroupName
			// 
			this.lblAGroupName.AllowDrop = true;
			this.lblAGroupName.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblAGroupName.Text = "Department Name (Arabic)";
			this.lblAGroupName.Location = new System.Drawing.Point(9, 102);
			// // this.lblAGroupName.mLabelId = 1047;
			this.lblAGroupName.Name = "lblAGroupName";
			this.lblAGroupName.Size = new System.Drawing.Size(128, 14);
			this.lblAGroupName.TabIndex = 9;
			// 
			// txtADeptName
			// 
			this.txtADeptName.AllowDrop = true;
			this.txtADeptName.BackColor = System.Drawing.Color.White;
			this.txtADeptName.ForeColor = System.Drawing.Color.Black;
			this.txtADeptName.Location = new System.Drawing.Point(145, 99);
			// this.txtADeptName.mArabicEnabled = true;
			this.txtADeptName.MaxLength = 50;
			this.txtADeptName.Name = "txtADeptName";
			this.txtADeptName.Size = new System.Drawing.Size(201, 19);
			this.txtADeptName.TabIndex = 2;
			this.txtADeptName.Text = "";
			// 
			// lblComments
			// 
			this.lblComments.AllowDrop = true;
			this.lblComments.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblComments.Text = "Comment";
			this.lblComments.Location = new System.Drawing.Point(9, 143);
			// // this.lblComments.mLabelId = 1851;
			this.lblComments.Name = "lblComments";
			this.lblComments.Size = new System.Drawing.Size(44, 14);
			this.lblComments.TabIndex = 10;
			// 
			// txtParentDeptNo
			// 
			this.txtParentDeptNo.AllowDrop = true;
			this.txtParentDeptNo.BackColor = System.Drawing.Color.White;
			// this.txtParentDeptNo.bolNumericOnly = true;
			this.txtParentDeptNo.ForeColor = System.Drawing.Color.Black;
			this.txtParentDeptNo.Location = new System.Drawing.Point(145, 120);
			this.txtParentDeptNo.MaxLength = 15;
			this.txtParentDeptNo.Name = "txtParentDeptNo";
			// this.txtParentDeptNo.ShowButton = true;
			this.txtParentDeptNo.Size = new System.Drawing.Size(101, 19);
			this.txtParentDeptNo.TabIndex = 3;
			this.txtParentDeptNo.Text = "";
			// this.this.txtParentDeptNo.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtParentDeptNo_DropButtonClick);
			// this.txtParentDeptNo.Leave += new System.EventHandler(this.txtParentDeptNo_Leave);
			// 
			// txtParentDeptName
			// 
			this.txtParentDeptName.AllowDrop = true;
			this.txtParentDeptName.BackColor = System.Drawing.Color.FromArgb(239, 239, 239);
			this.txtParentDeptName.Enabled = false;
			this.txtParentDeptName.ForeColor = System.Drawing.Color.Black;
			this.txtParentDeptName.Location = new System.Drawing.Point(248, 120);
			this.txtParentDeptName.Name = "txtParentDeptName";
			this.txtParentDeptName.Size = new System.Drawing.Size(191, 19);
			this.txtParentDeptName.TabIndex = 11;
			this.txtParentDeptName.TabStop = false;
			this.txtParentDeptName.Text = " ";
			// 
			// txtDlblAppTemplateName
			// 
			this.txtDlblAppTemplateName.AllowDrop = true;
			this.txtDlblAppTemplateName.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			this.txtDlblAppTemplateName.Enabled = false;
			this.txtDlblAppTemplateName.Location = new System.Drawing.Point(248, 201);
			this.txtDlblAppTemplateName.Name = "txtDlblAppTemplateName";
			this.txtDlblAppTemplateName.Size = new System.Drawing.Size(191, 19);
			this.txtDlblAppTemplateName.TabIndex = 12;
			// 
			// txtApprovalTemplate
			// 
			this.txtApprovalTemplate.AllowDrop = true;
			this.txtApprovalTemplate.BackColor = System.Drawing.Color.FromArgb(239, 239, 239);
			// this.txtApprovalTemplate.bolAllowDecimal = false;
			this.txtApprovalTemplate.Enabled = false;
			this.txtApprovalTemplate.ForeColor = System.Drawing.Color.Black;
			this.txtApprovalTemplate.Location = new System.Drawing.Point(145, 201);
			// this.txtApprovalTemplate.mDropDownType = (System.Windows.Forms.TextBox.DropDownTypes) 0;
			this.txtApprovalTemplate.Name = "txtApprovalTemplate";
			// this.txtApprovalTemplate.ShowButton = true;
			this.txtApprovalTemplate.Size = new System.Drawing.Size(101, 19);
			this.txtApprovalTemplate.TabIndex = 4;
			// this.txtApprovalTemplate.Text = "";
			// this.this.txtApprovalTemplate.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtApprovalTemplate_DropButtonClick);
			// this.txtApprovalTemplate.Leave += new System.EventHandler(this.txtApprovalTemplate_Leave);
			// 
			// _lblApprovalTemplate_28
			// 
			this._lblApprovalTemplate_28.AllowDrop = true;
			this._lblApprovalTemplate_28.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblApprovalTemplate_28.Text = "Approval Template";
			this._lblApprovalTemplate_28.Location = new System.Drawing.Point(9, 204);
			this._lblApprovalTemplate_28.Name = "_lblApprovalTemplate_28";
			this._lblApprovalTemplate_28.Size = new System.Drawing.Size(90, 14);
			this._lblApprovalTemplate_28.TabIndex = 13;
			// 
			// frmPayDepartment
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.ClientSize = new System.Drawing.Size(450, 233);
			this.Controls.Add(this.txtComment);
			this.Controls.Add(this.txtDeptNo);
			this.Controls.Add(this.lblGroupNo);
			this.Controls.Add(this.lblLGroupName);
			this.Controls.Add(this.txtLDeptName);
			this.Controls.Add(this.lblParentGroup);
			this.Controls.Add(this.lblAGroupName);
			this.Controls.Add(this.txtADeptName);
			this.Controls.Add(this.lblComments);
			this.Controls.Add(this.txtParentDeptNo);
			this.Controls.Add(this.txtParentDeptName);
			this.Controls.Add(this.txtDlblAppTemplateName);
			this.Controls.Add(this.txtApprovalTemplate);
			this.Controls.Add(this._lblApprovalTemplate_28);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			//this.Icon = (System.Drawing.Icon) resources.GetObject("frmPayDepartment.Icon");
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(280, 180);
			this.MaximizeBox = true;
			this.MinimizeBox = true;
			this.Name = "frmPayDepartment";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Department";
			// this.Activated += new System.EventHandler(this.frmPayDepartment_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
			// this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
			this.ResumeLayout(false);
		}
		// 
		void InitializelblApprovalTemplate()
		{
			this.lblApprovalTemplate = new System.Windows.Forms.Label[29];
			this.lblApprovalTemplate[28] = _lblApprovalTemplate_28;
		}
		#endregion
	}
}//ENDSHERE
