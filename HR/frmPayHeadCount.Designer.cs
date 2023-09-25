
namespace Xtreme
{
	partial class frmPayHeadCount
	{

		#region "Upgrade Support "
		private static frmPayHeadCount m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmPayHeadCount DefInstance
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
		public static frmPayHeadCount CreateInstance()
		{
			frmPayHeadCount theInstance = new frmPayHeadCount();
			
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
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "txtNTotalSalary", "txtStartDate", "chkBudgeted", "txtComments", "txtHeadcountCode", "lblCategoryCode", "txtHCCategoryNo", "lblDeptCode", "txtHCCategoryName", "_lblCommonLabel_2", "txtEmpName", "txtEmpCode", "_lblCommon_102", "_cmbCommon_0", "lblComments", "_lblCommon_66", "_lblCommon_67", "_lblCommon_69", "_lblCommon_71", "_lblCommon_72", "txtAnly1", "txtAnly2", "txtAnly3", "txtAnly4", "txtAnly5", "_lblCommon_65", "_lblCommon_0", "_lblCommon_1", "Shape3", "cmbCommon", "lblCommon", "lblCommonLabel"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public System.Windows.Forms.TextBox txtNTotalSalary;
		public Syncfusion.WinForms.Input.SfDateTimeEdit txtStartDate;
		public System.Windows.Forms.CheckBox chkBudgeted;
		public System.Windows.Forms.TextBox txtComments;
		public System.Windows.Forms.TextBox txtHeadcountCode;
		public System.Windows.Forms.Label lblCategoryCode;
		public System.Windows.Forms.TextBox txtHCCategoryNo;
		public System.Windows.Forms.Label lblDeptCode;
		public System.Windows.Forms.Label txtHCCategoryName;
		private System.Windows.Forms.Label _lblCommonLabel_2;
		public System.Windows.Forms.Label txtEmpName;
		public System.Windows.Forms.TextBox txtEmpCode;
		private System.Windows.Forms.Label _lblCommon_102;
		private System.Windows.Forms.ComboBox _cmbCommon_0;
		public System.Windows.Forms.Label lblComments;
		private System.Windows.Forms.Label _lblCommon_66;
		private System.Windows.Forms.Label _lblCommon_67;
		private System.Windows.Forms.Label _lblCommon_69;
		private System.Windows.Forms.Label _lblCommon_71;
		private System.Windows.Forms.Label _lblCommon_72;
		public System.Windows.Forms.TextBox txtAnly1;
		public System.Windows.Forms.TextBox txtAnly2;
		public System.Windows.Forms.TextBox txtAnly3;
		public System.Windows.Forms.TextBox txtAnly4;
		public System.Windows.Forms.TextBox txtAnly5;
		private System.Windows.Forms.Label _lblCommon_65;
		private System.Windows.Forms.Label _lblCommon_0;
		private System.Windows.Forms.Label _lblCommon_1;
		public UpgradeHelpers.Gui.ShapeHelper Shape3;
		public System.Windows.Forms.ComboBox[] cmbCommon = new System.Windows.Forms.ComboBox[1];
		public System.Windows.Forms.Label[] lblCommon = new System.Windows.Forms.Label[103];
		public System.Windows.Forms.Label[] lblCommonLabel = new System.Windows.Forms.Label[3];
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPayHeadCount));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this.txtNTotalSalary = new System.Windows.Forms.TextBox();
			this.txtStartDate = new Syncfusion.WinForms.Input.SfDateTimeEdit();
			this.chkBudgeted = new System.Windows.Forms.CheckBox();
			this.txtComments = new System.Windows.Forms.TextBox();
			this.txtHeadcountCode = new System.Windows.Forms.TextBox();
			this.lblCategoryCode = new System.Windows.Forms.Label();
			this.txtHCCategoryNo = new System.Windows.Forms.TextBox();
			this.lblDeptCode = new System.Windows.Forms.Label();
			this.txtHCCategoryName = new System.Windows.Forms.Label();
			this._lblCommonLabel_2 = new System.Windows.Forms.Label();
			this.txtEmpName = new System.Windows.Forms.Label();
			this.txtEmpCode = new System.Windows.Forms.TextBox();
			this._lblCommon_102 = new System.Windows.Forms.Label();
			this._cmbCommon_0 = new System.Windows.Forms.ComboBox();
			this.lblComments = new System.Windows.Forms.Label();
			this._lblCommon_66 = new System.Windows.Forms.Label();
			this._lblCommon_67 = new System.Windows.Forms.Label();
			this._lblCommon_69 = new System.Windows.Forms.Label();
			this._lblCommon_71 = new System.Windows.Forms.Label();
			this._lblCommon_72 = new System.Windows.Forms.Label();
			this.txtAnly1 = new System.Windows.Forms.TextBox();
			this.txtAnly2 = new System.Windows.Forms.TextBox();
			this.txtAnly3 = new System.Windows.Forms.TextBox();
			this.txtAnly4 = new System.Windows.Forms.TextBox();
			this.txtAnly5 = new System.Windows.Forms.TextBox();
			this._lblCommon_65 = new System.Windows.Forms.Label();
			this._lblCommon_0 = new System.Windows.Forms.Label();
			this._lblCommon_1 = new System.Windows.Forms.Label();
			this.Shape3 = new UpgradeHelpers.Gui.ShapeHelper();
			this.SuspendLayout();
			// 
			// txtNTotalSalary
			// 
			this.txtNTotalSalary.AllowDrop = true;
			this.txtNTotalSalary.Enabled = false;
			this.txtNTotalSalary.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtNTotalSalary.Location = new System.Drawing.Point(360, 165);
			this.txtNTotalSalary.Name = "txtNTotalSalary";
			this.txtNTotalSalary.Size = new System.Drawing.Size(115, 19);
			this.txtNTotalSalary.TabIndex = 27;
			// 
			// txtStartDate
			// 
			this.txtStartDate.AllowDrop = true;
			this.txtStartDate.BackColor = System.Drawing.Color.FromArgb(239, 239, 239);
			// this.txtStartDate.CheckDateRange = false;
			this.txtStartDate.Enabled = false;
			this.txtStartDate.Location = new System.Drawing.Point(137, 165);
			// this.txtStartDate.MaxDate = 2958465;
			// this.txtStartDate.MinDate = -657434;
			this.txtStartDate.Name = "txtStartDate";
			this.txtStartDate.PromptChar = "_";
			this.txtStartDate.Size = new System.Drawing.Size(101, 19);
			this.txtStartDate.TabIndex = 26;
			this.txtStartDate.Text = "06/02/2013";
			// 
			// chkBudgeted
			// 
			this.chkBudgeted.AllowDrop = true;
			this.chkBudgeted.Appearance = System.Windows.Forms.Appearance.Normal;
			this.chkBudgeted.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.chkBudgeted.CausesValidation = true;
			this.chkBudgeted.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkBudgeted.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this.chkBudgeted.Enabled = true;
			this.chkBudgeted.ForeColor = System.Drawing.SystemColors.ControlText;
			this.chkBudgeted.Location = new System.Drawing.Point(360, 141);
			this.chkBudgeted.Name = "chkBudgeted";
			this.chkBudgeted.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.chkBudgeted.Size = new System.Drawing.Size(115, 19);
			this.chkBudgeted.TabIndex = 5;
			this.chkBudgeted.TabStop = true;
			this.chkBudgeted.Text = "Is Budgeted";
			this.chkBudgeted.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkBudgeted.Visible = true;
			// 
			// txtComments
			// 
			this.txtComments.AcceptsReturn = true;
			this.txtComments.AllowDrop = true;
			this.txtComments.BackColor = System.Drawing.SystemColors.Window;
			this.txtComments.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.txtComments.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtComments.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtComments.Location = new System.Drawing.Point(137, 189);
			this.txtComments.MaxLength = 0;
			this.txtComments.Multiline = true;
			this.txtComments.Name = "txtComments";
			this.txtComments.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtComments.Size = new System.Drawing.Size(340, 58);
			this.txtComments.TabIndex = 6;
			// 
			// txtHeadcountCode
			// 
			this.txtHeadcountCode.AllowDrop = true;
			this.txtHeadcountCode.BackColor = System.Drawing.Color.White;
			// this.txtHeadcountCode.bolNumericOnly = true;
			this.txtHeadcountCode.ForeColor = System.Drawing.Color.Black;
			this.txtHeadcountCode.Location = new System.Drawing.Point(137, 75);
			this.txtHeadcountCode.MaxLength = 15;
			// this.txtHeadcountCode.mDropDownType = System.Windows.Forms.TextBox.DropDownTypes.ddtNextNumber;
			this.txtHeadcountCode.Name = "txtHeadcountCode";
			// this.txtHeadcountCode.ShowButton = true;
			this.txtHeadcountCode.Size = new System.Drawing.Size(101, 19);
			this.txtHeadcountCode.TabIndex = 1;
			this.txtHeadcountCode.Text = "";
			// 
			// lblCategoryCode
			// 
			this.lblCategoryCode.AllowDrop = true;
			this.lblCategoryCode.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblCategoryCode.Text = "Headcount Code";
			this.lblCategoryCode.Location = new System.Drawing.Point(15, 77);
			this.lblCategoryCode.Name = "lblCategoryCode";
			this.lblCategoryCode.Size = new System.Drawing.Size(80, 14);
			this.lblCategoryCode.TabIndex = 0;
			// 
			// txtHCCategoryNo
			// 
			this.txtHCCategoryNo.AllowDrop = true;
			this.txtHCCategoryNo.BackColor = System.Drawing.Color.White;
			// this.txtHCCategoryNo.bolNumericOnly = true;
			this.txtHCCategoryNo.ForeColor = System.Drawing.Color.Black;
			this.txtHCCategoryNo.Location = new System.Drawing.Point(137, 117);
			this.txtHCCategoryNo.MaxLength = 8;
			this.txtHCCategoryNo.Name = "txtHCCategoryNo";
			// this.txtHCCategoryNo.ShowButton = true;
			this.txtHCCategoryNo.Size = new System.Drawing.Size(101, 19);
			this.txtHCCategoryNo.TabIndex = 3;
			this.txtHCCategoryNo.Text = "";
			// this.this.txtHCCategoryNo.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtHCCategoryNo_DropButtonClick);
			// this.txtHCCategoryNo.Leave += new System.EventHandler(this.txtHCCategoryNo_Leave);
			// 
			// lblDeptCode
			// 
			this.lblDeptCode.AllowDrop = true;
			this.lblDeptCode.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblDeptCode.Text = "Category Code";
			this.lblDeptCode.Location = new System.Drawing.Point(15, 119);
			this.lblDeptCode.Name = "lblDeptCode";
			this.lblDeptCode.Size = new System.Drawing.Size(72, 14);
			this.lblDeptCode.TabIndex = 12;
			// 
			// txtHCCategoryName
			// 
			this.txtHCCategoryName.AllowDrop = true;
			this.txtHCCategoryName.Location = new System.Drawing.Point(240, 117);
			this.txtHCCategoryName.Name = "txtHCCategoryName";
			this.txtHCCategoryName.Size = new System.Drawing.Size(239, 19);
			this.txtHCCategoryName.TabIndex = 13;
			this.txtHCCategoryName.TabStop = false;
			// 
			// _lblCommonLabel_2
			// 
			this._lblCommonLabel_2.AllowDrop = true;
			this._lblCommonLabel_2.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_2.Text = "Employee Code";
			this._lblCommonLabel_2.Location = new System.Drawing.Point(15, 98);
			// this._lblCommonLabel_2.mLabelId = 236;
			this._lblCommonLabel_2.Name = "_lblCommonLabel_2";
			this._lblCommonLabel_2.Size = new System.Drawing.Size(74, 14);
			this._lblCommonLabel_2.TabIndex = 14;
			// 
			// txtEmpName
			// 
			this.txtEmpName.AllowDrop = true;
			this.txtEmpName.Location = new System.Drawing.Point(240, 96);
			this.txtEmpName.Name = "txtEmpName";
			this.txtEmpName.Size = new System.Drawing.Size(239, 19);
			this.txtEmpName.TabIndex = 15;
			this.txtEmpName.TabStop = false;
			// 
			// txtEmpCode
			// 
			this.txtEmpCode.AllowDrop = true;
			this.txtEmpCode.BackColor = System.Drawing.Color.FromArgb(239, 239, 239);
			this.txtEmpCode.Enabled = false;
			this.txtEmpCode.ForeColor = System.Drawing.Color.Black;
			this.txtEmpCode.Location = new System.Drawing.Point(137, 96);
			this.txtEmpCode.MaxLength = 10;
			this.txtEmpCode.Name = "txtEmpCode";
			// this.txtEmpCode.ShowButton = true;
			this.txtEmpCode.Size = new System.Drawing.Size(101, 19);
			this.txtEmpCode.TabIndex = 2;
			this.txtEmpCode.Text = "";
			// 
			// _lblCommon_102
			// 
			this._lblCommon_102.AllowDrop = true;
			this._lblCommon_102.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_102.Text = "Status";
			this._lblCommon_102.Location = new System.Drawing.Point(15, 142);
			// this._lblCommon_102.mLabelId = 1834;
			this._lblCommon_102.Name = "_lblCommon_102";
			this._lblCommon_102.Size = new System.Drawing.Size(31, 14);
			this._lblCommon_102.TabIndex = 16;
			// 
			// _cmbCommon_0
			// 
			this._cmbCommon_0.AllowDrop = true;
			this._cmbCommon_0.Location = new System.Drawing.Point(137, 138);
			this._cmbCommon_0.Name = "_cmbCommon_0";
			this._cmbCommon_0.Size = new System.Drawing.Size(101, 21);
			this._cmbCommon_0.TabIndex = 4;
			// 
			// lblComments
			// 
			this.lblComments.AllowDrop = true;
			this.lblComments.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblComments.Text = "Comment";
			this.lblComments.Location = new System.Drawing.Point(15, 189);
			// this.lblComments.mLabelId = 1851;
			this.lblComments.Name = "lblComments";
			this.lblComments.Size = new System.Drawing.Size(44, 14);
			this.lblComments.TabIndex = 17;
			// 
			// _lblCommon_66
			// 
			this._lblCommon_66.AllowDrop = true;
			this._lblCommon_66.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_66.Text = " Analysis1";
			this._lblCommon_66.Location = new System.Drawing.Point(15, 261);
			// this._lblCommon_66.mLabelId = 2202;
			this._lblCommon_66.Name = "_lblCommon_66";
			this._lblCommon_66.Size = new System.Drawing.Size(48, 13);
			this._lblCommon_66.TabIndex = 18;
			// 
			// _lblCommon_67
			// 
			this._lblCommon_67.AllowDrop = true;
			this._lblCommon_67.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_67.Text = " Analysis2";
			this._lblCommon_67.Location = new System.Drawing.Point(171, 261);
			// this._lblCommon_67.mLabelId = 2203;
			this._lblCommon_67.Name = "_lblCommon_67";
			this._lblCommon_67.Size = new System.Drawing.Size(48, 13);
			this._lblCommon_67.TabIndex = 19;
			// 
			// _lblCommon_69
			// 
			this._lblCommon_69.AllowDrop = true;
			this._lblCommon_69.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_69.Text = " Analysis3";
			this._lblCommon_69.Location = new System.Drawing.Point(330, 261);
			// this._lblCommon_69.mLabelId = 2204;
			this._lblCommon_69.Name = "_lblCommon_69";
			this._lblCommon_69.Size = new System.Drawing.Size(48, 13);
			this._lblCommon_69.TabIndex = 20;
			// 
			// _lblCommon_71
			// 
			this._lblCommon_71.AllowDrop = true;
			this._lblCommon_71.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_71.Text = " Analysis4";
			this._lblCommon_71.Location = new System.Drawing.Point(15, 282);
			// this._lblCommon_71.mLabelId = 2205;
			this._lblCommon_71.Name = "_lblCommon_71";
			this._lblCommon_71.Size = new System.Drawing.Size(48, 13);
			this._lblCommon_71.TabIndex = 21;
			// 
			// _lblCommon_72
			// 
			this._lblCommon_72.AllowDrop = true;
			this._lblCommon_72.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_72.Text = " Analysis5";
			this._lblCommon_72.Location = new System.Drawing.Point(171, 282);
			// this._lblCommon_72.mLabelId = 2206;
			this._lblCommon_72.Name = "_lblCommon_72";
			this._lblCommon_72.Size = new System.Drawing.Size(48, 13);
			this._lblCommon_72.TabIndex = 22;
			// 
			// txtAnly1
			// 
			this.txtAnly1.AllowDrop = true;
			this.txtAnly1.BackColor = System.Drawing.Color.White;
			this.txtAnly1.ForeColor = System.Drawing.Color.Black;
			this.txtAnly1.Location = new System.Drawing.Point(78, 258);
			this.txtAnly1.Name = "txtAnly1";
			this.txtAnly1.Size = new System.Drawing.Size(83, 19);
			this.txtAnly1.TabIndex = 7;
			this.txtAnly1.Text = "";
			// 
			// txtAnly2
			// 
			this.txtAnly2.AllowDrop = true;
			this.txtAnly2.BackColor = System.Drawing.Color.White;
			this.txtAnly2.ForeColor = System.Drawing.Color.Black;
			this.txtAnly2.Location = new System.Drawing.Point(231, 258);
			this.txtAnly2.Name = "txtAnly2";
			this.txtAnly2.Size = new System.Drawing.Size(86, 19);
			this.txtAnly2.TabIndex = 8;
			this.txtAnly2.Text = "";
			// 
			// txtAnly3
			// 
			this.txtAnly3.AllowDrop = true;
			this.txtAnly3.BackColor = System.Drawing.Color.White;
			this.txtAnly3.ForeColor = System.Drawing.Color.Black;
			this.txtAnly3.Location = new System.Drawing.Point(387, 258);
			this.txtAnly3.Name = "txtAnly3";
			this.txtAnly3.Size = new System.Drawing.Size(86, 19);
			this.txtAnly3.TabIndex = 9;
			this.txtAnly3.Text = "";
			// 
			// txtAnly4
			// 
			this.txtAnly4.AllowDrop = true;
			this.txtAnly4.BackColor = System.Drawing.Color.White;
			this.txtAnly4.ForeColor = System.Drawing.Color.Black;
			this.txtAnly4.Location = new System.Drawing.Point(78, 279);
			this.txtAnly4.Name = "txtAnly4";
			this.txtAnly4.Size = new System.Drawing.Size(83, 19);
			this.txtAnly4.TabIndex = 10;
			this.txtAnly4.Text = "";
			// 
			// txtAnly5
			// 
			this.txtAnly5.AllowDrop = true;
			this.txtAnly5.BackColor = System.Drawing.Color.White;
			this.txtAnly5.ForeColor = System.Drawing.Color.Black;
			this.txtAnly5.Location = new System.Drawing.Point(231, 279);
			this.txtAnly5.Name = "txtAnly5";
			this.txtAnly5.Size = new System.Drawing.Size(86, 19);
			this.txtAnly5.TabIndex = 11;
			this.txtAnly5.Text = "";
			// 
			// _lblCommon_65
			// 
			this._lblCommon_65.AllowDrop = true;
			this._lblCommon_65.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_65.Text = "GL Segment";
			this._lblCommon_65.Location = new System.Drawing.Point(15, 243);
			this._lblCommon_65.Name = "_lblCommon_65";
			this._lblCommon_65.Size = new System.Drawing.Size(57, 13);
			this._lblCommon_65.TabIndex = 23;
			// 
			// _lblCommon_0
			// 
			this._lblCommon_0.AllowDrop = true;
			this._lblCommon_0.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_0.Text = "Start Date";
			this._lblCommon_0.Location = new System.Drawing.Point(15, 164);
			this._lblCommon_0.Name = "_lblCommon_0";
			this._lblCommon_0.Size = new System.Drawing.Size(48, 14);
			this._lblCommon_0.TabIndex = 24;
			// 
			// _lblCommon_1
			// 
			this._lblCommon_1.AllowDrop = true;
			this._lblCommon_1.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_1.Text = "Total Salary";
			this._lblCommon_1.Location = new System.Drawing.Point(264, 165);
			this._lblCommon_1.Name = "_lblCommon_1";
			this._lblCommon_1.Size = new System.Drawing.Size(57, 14);
			this._lblCommon_1.TabIndex = 25;
			// 
			// Shape3
			// 
			this.Shape3.AllowDrop = true;
			this.Shape3.BackColor = System.Drawing.SystemColors.Window;
			this.Shape3.BackStyle = 0;
			this.Shape3.BorderStyle = 1;
			this.Shape3.Enabled = false;
			this.Shape3.FillColor = System.Drawing.Color.Black;
			this.Shape3.FillStyle = 1;
			this.Shape3.Location = new System.Drawing.Point(6, 252);
			this.Shape3.Name = "Shape3";
			this.Shape3.Size = new System.Drawing.Size(472, 62);
			this.Shape3.Visible = true;
			// 
			// frmPayHeadCount
			// 
			this.'MaxButton = 0;
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.ClientSize = new System.Drawing.Size(484, 318);
			this.Controls.Add(this.txtNTotalSalary);
			this.Controls.Add(this.txtStartDate);
			this.Controls.Add(this.chkBudgeted);
			this.Controls.Add(this.txtComments);
			this.Controls.Add(this.txtHeadcountCode);
			this.Controls.Add(this.lblCategoryCode);
			this.Controls.Add(this.txtHCCategoryNo);
			this.Controls.Add(this.lblDeptCode);
			this.Controls.Add(this.txtHCCategoryName);
			this.Controls.Add(this._lblCommonLabel_2);
			this.Controls.Add(this.txtEmpName);
			this.Controls.Add(this.txtEmpCode);
			this.Controls.Add(this._lblCommon_102);
			this.Controls.Add(this._cmbCommon_0);
			this.Controls.Add(this.lblComments);
			this.Controls.Add(this._lblCommon_66);
			this.Controls.Add(this._lblCommon_67);
			this.Controls.Add(this._lblCommon_69);
			this.Controls.Add(this._lblCommon_71);
			this.Controls.Add(this._lblCommon_72);
			this.Controls.Add(this.txtAnly1);
			this.Controls.Add(this.txtAnly2);
			this.Controls.Add(this.txtAnly3);
			this.Controls.Add(this.txtAnly4);
			this.Controls.Add(this.txtAnly5);
			this.Controls.Add(this._lblCommon_65);
			this.Controls.Add(this._lblCommon_0);
			this.Controls.Add(this._lblCommon_1);
			this.Controls.Add(this.Shape3);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			//this.Icon = (System.Drawing.Icon) resources.GetObject("frmPayHeadCount.Icon");
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(122, 127);
			this.MaximizeBox = true;
			this.MinimizeBox = true;
			this.Name = "frmPayHeadCount";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Headcount";
			// this.Activated += new System.EventHandler(this.frmPayHeadCount_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
			// this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
			this.ResumeLayout(false);
		}
		void ReLoadForm(bool addEvents)
		{
			InitializelblCommonLabel();
			InitializelblCommon();
			InitializecmbCommon();
			//This form is an MDI child.
			//This code simulates the VB6 
			// functionality of automatically
			// loading and showing an MDI
			// child's parent.
			this.MdiParent = Xtreme.frmSysMain.DefInstance;
			Xtreme.frmSysMain.DefInstance.Show();
		}
		void InitializelblCommonLabel()
		{
			this.lblCommonLabel = new System.Windows.Forms.Label[3];
			this.lblCommonLabel[2] = _lblCommonLabel_2;
		}
		void InitializelblCommon()
		{
			this.lblCommon = new System.Windows.Forms.Label[103];
			this.lblCommon[102] = _lblCommon_102;
			this.lblCommon[66] = _lblCommon_66;
			this.lblCommon[67] = _lblCommon_67;
			this.lblCommon[69] = _lblCommon_69;
			this.lblCommon[71] = _lblCommon_71;
			this.lblCommon[72] = _lblCommon_72;
			this.lblCommon[65] = _lblCommon_65;
			this.lblCommon[0] = _lblCommon_0;
			this.lblCommon[1] = _lblCommon_1;
		}
		void InitializecmbCommon()
		{
			this.cmbCommon = new System.Windows.Forms.ComboBox[1];
			this.cmbCommon[0] = _cmbCommon_0;
		}
		#endregion
	}
}