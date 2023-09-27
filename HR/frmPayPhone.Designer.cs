
namespace Xtreme
{
	partial class frmPayPhone
	{

		#region "Upgrade Support "
		private static frmPayPhone m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmPayPhone DefInstance
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
		public static frmPayPhone CreateInstance()
		{
			frmPayPhone theInstance = new frmPayPhone();
			
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
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "Column_0_grdPhone", "Column_1_grdPhone", "grdPhone", "txtDeductionCode", "System.Windows.Forms.Label1", "txtEmployeeCode", "lblHolidayCode", "txtDeductionCodeName", "txtEmployeeCodeName"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_0_grdPhone;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_1_grdPhone;
		public C1.Win.C1TrueDBGrid.C1TrueDBGrid grdPhone;
		public System.Windows.Forms.TextBox txtDeductionCode;
		public System.Windows.Forms.Label Label1;
		public System.Windows.Forms.TextBox txtEmployeeCode;
		public System.Windows.Forms.Label lblHolidayCode;
		public System.Windows.Forms.Label txtDeductionCodeName;
		public System.Windows.Forms.Label txtEmployeeCodeName;
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPayPhone));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this.grdPhone = new C1.Win.C1TrueDBGrid.C1TrueDBGrid();
			this.Column_0_grdPhone = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.Column_1_grdPhone = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.txtDeductionCode = new System.Windows.Forms.TextBox();
			this.Label1 = new System.Windows.Forms.Label();
			this.txtEmployeeCode = new System.Windows.Forms.TextBox();
			this.lblHolidayCode = new System.Windows.Forms.Label();
			this.txtDeductionCodeName = new System.Windows.Forms.Label();
			this.txtEmployeeCodeName = new System.Windows.Forms.Label();
			//this.grdPhone.SuspendLayout();
			this.SuspendLayout();
			// 
			// grdPhone
			// 
			//this.grdPhone.AllowDrop = true;
			this.grdPhone.BackColor = System.Drawing.Color.FromArgb(212, 208, 200);
			this.grdPhone.CellTipsWidth = 0;
			this.grdPhone.Location = new System.Drawing.Point(2, 106);
			this.grdPhone.Name = "grdPhone";
			this.grdPhone.RowDivider.Color = System.Drawing.Color.FromArgb(212, 208, 200);
			this.grdPhone.Size = new System.Drawing.Size(471, 347);
			this.grdPhone.TabIndex = 0;
			this.grdPhone.Columns.Add(this.Column_0_grdPhone);
			this.grdPhone.Columns.Add(this.Column_1_grdPhone);
			//this.grdPhone.AfterColUpdate += new C1.Win.C1TrueDBGrid.ColEventHandler(this.grdPhone_AfterColUpdate);
			// 
			// Column_0_grdPhone
			// 
			this.Column_0_grdPhone.DataField = "";
			this.Column_0_grdPhone.ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.Normal;
			// 
			// Column_1_grdPhone
			// 
			this.Column_1_grdPhone.DataField = "";
			this.Column_1_grdPhone.ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.Normal;
			// 
			// txtDeductionCode
			// 
			//this.txtDeductionCode.AllowDrop = true;
			this.txtDeductionCode.BackColor = System.Drawing.Color.FromArgb(239, 239, 239);
			// this.txtDeductionCode.bolNumericOnly = true;
			this.txtDeductionCode.Enabled = false;
			this.txtDeductionCode.ForeColor = System.Drawing.Color.Black;
			this.txtDeductionCode.Location = new System.Drawing.Point(116, 73);
			this.txtDeductionCode.MaxLength = 15;
			// // = System.Windows.Forms.TextBox.DropDownTypes.ddtNextNumber;
			this.txtDeductionCode.Name = "txtDeductionCode";
			// this.txtDeductionCode.ShowButton = true;
			this.txtDeductionCode.Size = new System.Drawing.Size(101, 19);
			this.txtDeductionCode.TabIndex = 1;
			this.txtDeductionCode.Text = "";
			// this.//this.txtDeductionCode.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(//this.txtDeductionCode_DropButtonClick);
			// this.txtDeductionCode.Leave += new System.EventHandler(this.txtDeductionCode_Leave);
			// 
			// System.Windows.Forms.Label1
			// 
			//this.Label1.AllowDrop = true;
			this.Label1.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.Label1.Text = "Deduction Code";
			this.Label1.Location = new System.Drawing.Point(6, 75);
			// this.Label1.mLabelId = 1997;
			this.Label1.Name="Label1";
			this.Label1.Size = new System.Drawing.Size(76, 14);
			this.Label1.TabIndex = 2;
			// 
			// txtEmployeeCode
			// 
			//this.txtEmployeeCode.AllowDrop = true;
			this.txtEmployeeCode.BackColor = System.Drawing.Color.White;
			this.txtEmployeeCode.ForeColor = System.Drawing.Color.Black;
			this.txtEmployeeCode.Location = new System.Drawing.Point(116, 52);
			this.txtEmployeeCode.MaxLength = 15;
			// // = System.Windows.Forms.TextBox.DropDownTypes.ddtNextNumber;
			this.txtEmployeeCode.Name = "txtEmployeeCode";
			// this.txtEmployeeCode.ShowButton = true;
			this.txtEmployeeCode.Size = new System.Drawing.Size(101, 19);
			this.txtEmployeeCode.TabIndex = 3;
			this.txtEmployeeCode.Text = "";
			// this.//this.txtEmployeeCode.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(//this.txtEmployeeCode_DropButtonClick);
			// this.txtEmployeeCode.Leave += new System.EventHandler(this.txtEmployeeCode_Leave);
			// 
			// lblHolidayCode
			// 
			//this.lblHolidayCode.AllowDrop = true;
			this.lblHolidayCode.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblHolidayCode.Text = "Employee Code";
			this.lblHolidayCode.Location = new System.Drawing.Point(6, 54);
			// // this.lblHolidayCode.mLabelId = 236;
			this.lblHolidayCode.Name = "lblHolidayCode";
			this.lblHolidayCode.Size = new System.Drawing.Size(74, 14);
			this.lblHolidayCode.TabIndex = 4;
			// 
			// txtDeductionCodeName
			// 
			//this.txtDeductionCodeName.AllowDrop = true;
			this.txtDeductionCodeName.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			this.txtDeductionCodeName.Enabled = false;
			this.txtDeductionCodeName.Location = new System.Drawing.Point(218, 73);
			this.txtDeductionCodeName.Name = "txtDeductionCodeName";
			this.txtDeductionCodeName.Size = new System.Drawing.Size(191, 19);
			this.txtDeductionCodeName.TabIndex = 5;
			// 
			// txtEmployeeCodeName
			// 
			//this.txtEmployeeCodeName.AllowDrop = true;
			this.txtEmployeeCodeName.BackColor = System.Drawing.SystemColors.Window;
			this.txtEmployeeCodeName.Enabled = false;
			this.txtEmployeeCodeName.Location = new System.Drawing.Point(218, 52);
			this.txtEmployeeCodeName.Name = "txtEmployeeCodeName";
			this.txtEmployeeCodeName.Size = new System.Drawing.Size(191, 19);
			this.txtEmployeeCodeName.TabIndex = 6;
			// 
			// frmPayPhone
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.ClientSize = new System.Drawing.Size(479, 457);
			this.Controls.Add(this.grdPhone);
			this.Controls.Add(this.txtDeductionCode);
			this.Controls.Add(this.Label1);
			this.Controls.Add(this.txtEmployeeCode);
			this.Controls.Add(this.lblHolidayCode);
			this.Controls.Add(this.txtDeductionCodeName);
			this.Controls.Add(this.txtEmployeeCodeName);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			//this.Icon = (System.Drawing.Icon) resources.GetObject("frmPayPhone.Icon");
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(275, 133);
			this.MaximizeBox = true;
			this.MinimizeBox = true;
			this.Name = "frmPayPhone";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Phone";
			// this.Activated += new System.EventHandler(this.frmPayPhone_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
			// this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
			this.grdPhone.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		// 
		#endregion
	}
}//ENDSHERE
