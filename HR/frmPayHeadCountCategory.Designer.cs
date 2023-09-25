
namespace Xtreme
{
	partial class frmPayHeadCountCategory
	{

		#region "Upgrade Support "
		private static frmPayHeadCountCategory m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmPayHeadCountCategory DefInstance
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
		public static frmPayHeadCountCategory CreateInstance()
		{
			frmPayHeadCountCategory theInstance = new frmPayHeadCountCategory();
			
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
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "chkDiscontinue", "txtCategoryCode", "lblCategoryCode", "lblLCategoryName", "txtLCategoryName", "lblACategoryName", "txtACategoryName", "txtDeptCode", "lblDeptCode", "txtDDeptName", "System.Windows.Forms.Label2", "System.Windows.Forms.Label1", "txtEndDate", "txtStartDate", "txtDesgCode", "System.Windows.Forms.Label3", "txtDlblDesgName"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public System.Windows.Forms.CheckBox chkDiscontinue;
		public System.Windows.Forms.TextBox txtCategoryCode;
		public System.Windows.Forms.Label lblCategoryCode;
		public System.Windows.Forms.Label lblLCategoryName;
		public System.Windows.Forms.TextBox txtLCategoryName;
		public System.Windows.Forms.Label lblACategoryName;
		public System.Windows.Forms.TextBox txtACategoryName;
		public System.Windows.Forms.TextBox txtDeptCode;
		public System.Windows.Forms.Label lblDeptCode;
		public System.Windows.Forms.Label txtDDeptName;
		public System.Windows.Forms.Label System.Windows.Forms.Label2;
		public System.Windows.Forms.Label System.Windows.Forms.Label1;
		public Syncfusion.WinForms.Input.SfDateTimeEdit txtEndDate;
		public Syncfusion.WinForms.Input.SfDateTimeEdit txtStartDate;
		public System.Windows.Forms.TextBox txtDesgCode;
		public System.Windows.Forms.Label System.Windows.Forms.Label3;
		public System.Windows.Forms.Label txtDlblDesgName;
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPayHeadCountCategory));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this.chkDiscontinue = new System.Windows.Forms.CheckBox();
			this.txtCategoryCode = new System.Windows.Forms.TextBox();
			this.lblCategoryCode = new System.Windows.Forms.Label();
			this.lblLCategoryName = new System.Windows.Forms.Label();
			this.txtLCategoryName = new System.Windows.Forms.TextBox();
			this.lblACategoryName = new System.Windows.Forms.Label();
			this.txtACategoryName = new System.Windows.Forms.TextBox();
			this.txtDeptCode = new System.Windows.Forms.TextBox();
			this.lblDeptCode = new System.Windows.Forms.Label();
			this.txtDDeptName = new System.Windows.Forms.Label();
			this.System.Windows.Forms.Label2 = new System.Windows.Forms.Label();
			this.System.Windows.Forms.Label1 = new System.Windows.Forms.Label();
			this.txtEndDate = new Syncfusion.WinForms.Input.SfDateTimeEdit();
			this.txtStartDate = new Syncfusion.WinForms.Input.SfDateTimeEdit();
			this.txtDesgCode = new System.Windows.Forms.TextBox();
			this.System.Windows.Forms.Label3 = new System.Windows.Forms.Label();
			this.txtDlblDesgName = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// chkDiscontinue
			// 
			this.chkDiscontinue.AllowDrop = true;
			this.chkDiscontinue.Appearance = System.Windows.Forms.Appearance.Normal;
			this.chkDiscontinue.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.chkDiscontinue.CausesValidation = true;
			this.chkDiscontinue.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkDiscontinue.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this.chkDiscontinue.Enabled = true;
			this.chkDiscontinue.ForeColor = System.Drawing.SystemColors.ControlText;
			this.chkDiscontinue.Location = new System.Drawing.Point(138, 177);
			this.chkDiscontinue.Name = "chkDiscontinue";
			this.chkDiscontinue.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.chkDiscontinue.Size = new System.Drawing.Size(100, 19);
			this.chkDiscontinue.TabIndex = 4;
			this.chkDiscontinue.TabStop = true;
			this.chkDiscontinue.Text = "Discontinue";
			this.chkDiscontinue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkDiscontinue.Visible = true;
			// 
			// txtCategoryCode
			// 
			this.txtCategoryCode.AllowDrop = true;
			this.txtCategoryCode.BackColor = System.Drawing.Color.White;
			// this.txtCategoryCode.bolNumericOnly = true;
			this.txtCategoryCode.ForeColor = System.Drawing.Color.Black;
			this.txtCategoryCode.Location = new System.Drawing.Point(138, 66);
			this.txtCategoryCode.MaxLength = 15;
			// this.txtCategoryCode.mDropDownType = System.Windows.Forms.TextBox.DropDownTypes.ddtNextNumber;
			this.txtCategoryCode.Name = "txtCategoryCode";
			// this.txtCategoryCode.ShowButton = true;
			this.txtCategoryCode.Size = new System.Drawing.Size(101, 19);
			this.txtCategoryCode.TabIndex = 0;
			this.txtCategoryCode.Text = "";
			// 
			// lblCategoryCode
			// 
			this.lblCategoryCode.AllowDrop = true;
			this.lblCategoryCode.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblCategoryCode.Text = "Category Code";
			this.lblCategoryCode.Location = new System.Drawing.Point(10, 68);
			this.lblCategoryCode.Name = "lblCategoryCode";
			this.lblCategoryCode.Size = new System.Drawing.Size(72, 14);
			this.lblCategoryCode.TabIndex = 7;
			// 
			// lblLCategoryName
			// 
			this.lblLCategoryName.AllowDrop = true;
			this.lblLCategoryName.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblLCategoryName.Text = "Category Name (English)";
			this.lblLCategoryName.Location = new System.Drawing.Point(10, 90);
			this.lblLCategoryName.Name = "lblLCategoryName";
			this.lblLCategoryName.Size = new System.Drawing.Size(119, 14);
			this.lblLCategoryName.TabIndex = 8;
			// 
			// txtLCategoryName
			// 
			this.txtLCategoryName.AllowDrop = true;
			this.txtLCategoryName.BackColor = System.Drawing.Color.White;
			this.txtLCategoryName.ForeColor = System.Drawing.Color.Black;
			this.txtLCategoryName.Location = new System.Drawing.Point(138, 87);
			this.txtLCategoryName.MaxLength = 50;
			this.txtLCategoryName.Name = "txtLCategoryName";
			this.txtLCategoryName.Size = new System.Drawing.Size(343, 19);
			this.txtLCategoryName.TabIndex = 1;
			this.txtLCategoryName.Text = "";
			// 
			// lblACategoryName
			// 
			this.lblACategoryName.AllowDrop = true;
			this.lblACategoryName.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblACategoryName.Text = "Category Name (Arabic)";
			this.lblACategoryName.Location = new System.Drawing.Point(10, 111);
			this.lblACategoryName.Name = "lblACategoryName";
			this.lblACategoryName.Size = new System.Drawing.Size(117, 14);
			this.lblACategoryName.TabIndex = 9;
			// 
			// txtACategoryName
			// 
			this.txtACategoryName.AllowDrop = true;
			this.txtACategoryName.BackColor = System.Drawing.Color.White;
			this.txtACategoryName.ForeColor = System.Drawing.Color.Black;
			this.txtACategoryName.Location = new System.Drawing.Point(138, 108);
			// this.txtACategoryName.mArabicEnabled = true;
			this.txtACategoryName.MaxLength = 50;
			this.txtACategoryName.Name = "txtACategoryName";
			this.txtACategoryName.Size = new System.Drawing.Size(343, 19);
			this.txtACategoryName.TabIndex = 2;
			this.txtACategoryName.Text = "";
			// 
			// txtDeptCode
			// 
			this.txtDeptCode.AllowDrop = true;
			this.txtDeptCode.BackColor = System.Drawing.Color.White;
			// this.txtDeptCode.bolNumericOnly = true;
			this.txtDeptCode.ForeColor = System.Drawing.Color.Black;
			this.txtDeptCode.Location = new System.Drawing.Point(138, 130);
			this.txtDeptCode.MaxLength = 8;
			this.txtDeptCode.Name = "txtDeptCode";
			// this.txtDeptCode.ShowButton = true;
			this.txtDeptCode.Size = new System.Drawing.Size(101, 19);
			this.txtDeptCode.TabIndex = 3;
			this.txtDeptCode.Text = "";
			// this.this.txtDeptCode.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtDeptCode_DropButtonClick);
			// this.txtDeptCode.Leave += new System.EventHandler(this.txtDeptCode_Leave);
			// 
			// lblDeptCode
			// 
			this.lblDeptCode.AllowDrop = true;
			this.lblDeptCode.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblDeptCode.Text = "Department Code";
			this.lblDeptCode.Location = new System.Drawing.Point(10, 132);
			// this.lblDeptCode.mLabelId = 1973;
			this.lblDeptCode.Name = "lblDeptCode";
			this.lblDeptCode.Size = new System.Drawing.Size(83, 14);
			this.lblDeptCode.TabIndex = 10;
			// 
			// txtDDeptName
			// 
			this.txtDDeptName.AllowDrop = true;
			this.txtDDeptName.Location = new System.Drawing.Point(241, 130);
			this.txtDDeptName.Name = "txtDDeptName";
			this.txtDDeptName.Size = new System.Drawing.Size(239, 19);
			this.txtDDeptName.TabIndex = 11;
			this.txtDDeptName.TabStop = false;
			// 
			// System.Windows.Forms.Label2
			// 
			this.System.Windows.Forms.Label2.AllowDrop = true;
			this.System.Windows.Forms.Label2.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.System.Windows.Forms.Label2.Caption = "End Date";
			this.System.Windows.Forms.Label2.Location = new System.Drawing.Point(279, 204);
			this.System.Windows.Forms.Label2.Name = "System.Windows.Forms.Label2";
			this.System.Windows.Forms.Label2.Size = new System.Drawing.Size(44, 13);
			this.System.Windows.Forms.Label2.TabIndex = 12;
			// 
			// System.Windows.Forms.Label1
			// 
			this.System.Windows.Forms.Label1.AllowDrop = true;
			this.System.Windows.Forms.Label1.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.System.Windows.Forms.Label1.Caption = "Start Date";
			this.System.Windows.Forms.Label1.Location = new System.Drawing.Point(9, 204);
			this.System.Windows.Forms.Label1.Name = "System.Windows.Forms.Label1";
			this.System.Windows.Forms.Label1.Size = new System.Drawing.Size(50, 13);
			this.System.Windows.Forms.Label1.TabIndex = 13;
			// 
			// txtEndDate
			// 
			this.txtEndDate.AllowDrop = true;
			// this.txtEndDate.CheckDateRange = false;
			this.txtEndDate.Location = new System.Drawing.Point(338, 201);
			// this.txtEndDate.MaxDate = 2958465;
			// this.txtEndDate.MinDate = 2;
			this.txtEndDate.Name = "txtEndDate";
			this.txtEndDate.Size = new System.Drawing.Size(101, 19);
			this.txtEndDate.TabIndex = 6;
			this.txtEndDate.Text = "31/12/2011";
			this.txtEndDate.Value = 40908;
			// 
			// txtStartDate
			// 
			this.txtStartDate.AllowDrop = true;
			// this.txtStartDate.CheckDateRange = false;
			this.txtStartDate.Location = new System.Drawing.Point(135, 201);
			// this.txtStartDate.MaxDate = 2958465;
			// this.txtStartDate.MinDate = 2;
			this.txtStartDate.Name = "txtStartDate";
			this.txtStartDate.Size = new System.Drawing.Size(107, 19);
			this.txtStartDate.TabIndex = 5;
			this.txtStartDate.Text = "01/01/2011";
			this.txtStartDate.Value = 40544;
			// 
			// txtDesgCode
			// 
			this.txtDesgCode.AllowDrop = true;
			this.txtDesgCode.BackColor = System.Drawing.Color.White;
			// this.txtDesgCode.bolNumericOnly = true;
			this.txtDesgCode.ForeColor = System.Drawing.Color.Black;
			this.txtDesgCode.Location = new System.Drawing.Point(138, 153);
			this.txtDesgCode.MaxLength = 8;
			this.txtDesgCode.Name = "txtDesgCode";
			// this.txtDesgCode.ShowButton = true;
			this.txtDesgCode.Size = new System.Drawing.Size(101, 19);
			this.txtDesgCode.TabIndex = 14;
			this.txtDesgCode.Text = "";
			// this.this.txtDesgCode.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtDesgCode_DropButtonClick);
			// this.txtDesgCode.Leave += new System.EventHandler(this.txtDesgCode_Leave);
			// 
			// System.Windows.Forms.Label3
			// 
			this.System.Windows.Forms.Label3.AllowDrop = true;
			this.System.Windows.Forms.Label3.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.System.Windows.Forms.Label3.Caption = "Designation Code";
			this.System.Windows.Forms.Label3.Location = new System.Drawing.Point(8, 155);
			this.System.Windows.Forms.Label3.mLabelId = 1049;
			this.System.Windows.Forms.Label3.Name = "System.Windows.Forms.Label3";
			this.System.Windows.Forms.Label3.Size = new System.Drawing.Size(84, 14);
			this.System.Windows.Forms.Label3.TabIndex = 15;
			// 
			// txtDlblDesgName
			// 
			this.txtDlblDesgName.AllowDrop = true;
			this.txtDlblDesgName.Location = new System.Drawing.Point(241, 153);
			this.txtDlblDesgName.Name = "txtDlblDesgName";
			this.txtDlblDesgName.Size = new System.Drawing.Size(239, 19);
			this.txtDlblDesgName.TabIndex = 16;
			this.txtDlblDesgName.TabStop = false;
			// 
			// frmPayHeadCountCategory
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.ClientSize = new System.Drawing.Size(496, 231);
			this.Controls.Add(this.chkDiscontinue);
			this.Controls.Add(this.txtCategoryCode);
			this.Controls.Add(this.lblCategoryCode);
			this.Controls.Add(this.lblLCategoryName);
			this.Controls.Add(this.txtLCategoryName);
			this.Controls.Add(this.lblACategoryName);
			this.Controls.Add(this.txtACategoryName);
			this.Controls.Add(this.txtDeptCode);
			this.Controls.Add(this.lblDeptCode);
			this.Controls.Add(this.txtDDeptName);
			this.Controls.Add(this.System.Windows.Forms.Label2);
			this.Controls.Add(this.System.Windows.Forms.Label1);
			this.Controls.Add(this.txtEndDate);
			this.Controls.Add(this.txtStartDate);
			this.Controls.Add(this.txtDesgCode);
			this.Controls.Add(this.System.Windows.Forms.Label3);
			this.Controls.Add(this.txtDlblDesgName);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			//this.Icon = (System.Drawing.Icon) resources.GetObject("frmPayHeadCountCategory.Icon");
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(216, 193);
			this.MaximizeBox = true;
			this.MinimizeBox = true;
			this.Name = "frmPayHeadCountCategory";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Headcount Category";
			// this.Activated += new System.EventHandler(this.frmPayHeadCountCategory_Activated);
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