
namespace Xtreme
{
	partial class frmPayAppraisal
	{

		#region "Upgrade Support "
		private static frmPayAppraisal m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmPayAppraisal DefInstance
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
		public static frmPayAppraisal CreateInstance()
		{
			frmPayAppraisal theInstance = new frmPayAppraisal();
			
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
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "txtDlblDepartment", "txtDlblRateeName", "txtRateeCode", "System.Windows.Forms.Label3", "System.Windows.Forms.Label4", "System.Windows.Forms.Label5", "txtDlblDesignation", "txtDlblDepartmentName", "txtDlblDesignationName", "System.Windows.Forms.Label6", "txtDlblRequestedByName", "txtRequestedBy", "frmRatee", "txtEndDate", "txtStartDate", "txtAppraisal", "lblCategoryNo", "_lblCommonLabel_6", "txtTransactionDate", "System.Windows.Forms.Label1", "System.Windows.Forms.Label2", "System.Windows.Forms.Label7", "txtSuveyTemplate", "txtDlBLSurveyTemplateName", "Column_0_cmbMastersList", "Column_1_cmbMastersList", "cmbMastersList", "Column_0_grdSurveyDetails", "Column_1_grdSurveyDetails", "grdSurveyDetails", "lblCommonLabel"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public System.Windows.Forms.Label txtDlblDepartment;
		public System.Windows.Forms.Label txtDlblRateeName;
		public System.Windows.Forms.TextBox txtRateeCode;
		public System.Windows.Forms.Label Label3;
		public System.Windows.Forms.Label Label4;
		public System.Windows.Forms.Label Label5;
		public System.Windows.Forms.Label txtDlblDesignation;
		public System.Windows.Forms.Label txtDlblDepartmentName;
		public System.Windows.Forms.Label txtDlblDesignationName;
		public System.Windows.Forms.Label Label6;
		public System.Windows.Forms.Label txtDlblRequestedByName;
		public System.Windows.Forms.TextBox txtRequestedBy;
		public System.Windows.Forms.GroupBox frmRatee;
		public Syncfusion.WinForms.Input.SfDateTimeEdit txtEndDate;
		public Syncfusion.WinForms.Input.SfDateTimeEdit txtStartDate;
		public System.Windows.Forms.TextBox txtAppraisal;
		public System.Windows.Forms.Label lblCategoryNo;
		private System.Windows.Forms.Label _lblCommonLabel_6;
		public Syncfusion.WinForms.Input.SfDateTimeEdit txtTransactionDate;
		public System.Windows.Forms.Label Label1;
		public System.Windows.Forms.Label Label2;
		public System.Windows.Forms.Label Label7;
		public System.Windows.Forms.TextBox txtSuveyTemplate;
		public System.Windows.Forms.Label txtDlBLSurveyTemplateName;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_0_cmbMastersList;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_1_cmbMastersList;
		public C1.Win.C1TrueDBGrid.C1TrueDBDropdown cmbMastersList;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_0_grdSurveyDetails;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_1_grdSurveyDetails;
		public C1.Win.C1TrueDBGrid.C1TrueDBGrid grdSurveyDetails;
		public System.Windows.Forms.Label[] lblCommonLabel = new System.Windows.Forms.Label[7];
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPayAppraisal));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this.frmRatee = new System.Windows.Forms.GroupBox();
			this.txtDlblDepartment = new System.Windows.Forms.Label();
			this.txtDlblRateeName = new System.Windows.Forms.Label();
			this.txtRateeCode = new System.Windows.Forms.TextBox();
			this.Label3 = new System.Windows.Forms.Label();
			this.Label4 = new System.Windows.Forms.Label();
			this.Label5 = new System.Windows.Forms.Label();
			this.txtDlblDesignation = new System.Windows.Forms.Label();
			this.txtDlblDepartmentName = new System.Windows.Forms.Label();
			this.txtDlblDesignationName = new System.Windows.Forms.Label();
			this.Label6 = new System.Windows.Forms.Label();
			this.txtDlblRequestedByName = new System.Windows.Forms.Label();
			this.txtRequestedBy = new System.Windows.Forms.TextBox();
			this.txtEndDate = new Syncfusion.WinForms.Input.SfDateTimeEdit();
			this.txtStartDate = new Syncfusion.WinForms.Input.SfDateTimeEdit();
			this.txtAppraisal = new System.Windows.Forms.TextBox();
			this.lblCategoryNo = new System.Windows.Forms.Label();
			this._lblCommonLabel_6 = new System.Windows.Forms.Label();
			this.txtTransactionDate = new Syncfusion.WinForms.Input.SfDateTimeEdit();
			this.Label1 = new System.Windows.Forms.Label();
			this.Label2 = new System.Windows.Forms.Label();
			this.Label7 = new System.Windows.Forms.Label();
			this.txtSuveyTemplate = new System.Windows.Forms.TextBox();
			this.txtDlBLSurveyTemplateName = new System.Windows.Forms.Label();
			this.cmbMastersList = new C1.Win.C1TrueDBGrid.C1TrueDBDropdown();
			this.Column_0_cmbMastersList = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.Column_1_cmbMastersList = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.grdSurveyDetails = new C1.Win.C1TrueDBGrid.C1TrueDBGrid();
			this.Column_0_grdSurveyDetails = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.Column_1_grdSurveyDetails = new C1.Win.C1TrueDBGrid.C1DataColumn();
			//this.frmRatee.SuspendLayout();
			//this.cmbMastersList.SuspendLayout();
			//this.grdSurveyDetails.SuspendLayout();
			this.SuspendLayout();
			// 
			// frmRatee
			// 
			this.frmRatee.AllowDrop = true;
			this.frmRatee.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			this.frmRatee.Controls.Add(this.txtDlblDepartment);
			this.frmRatee.Controls.Add(this.txtDlblRateeName);
			this.frmRatee.Controls.Add(this.txtRateeCode);
			this.frmRatee.Controls.Add(this.Label3);
			this.frmRatee.Controls.Add(this.Label4);
			this.frmRatee.Controls.Add(this.Label5);
			this.frmRatee.Controls.Add(this.txtDlblDesignation);
			this.frmRatee.Controls.Add(this.txtDlblDepartmentName);
			this.frmRatee.Controls.Add(this.txtDlblDesignationName);
			this.frmRatee.Controls.Add(this.Label6);
			this.frmRatee.Controls.Add(this.txtDlblRequestedByName);
			this.frmRatee.Controls.Add(this.txtRequestedBy);
			this.frmRatee.Enabled = true;
			this.frmRatee.ForeColor = System.Drawing.Color.FromArgb(0, 0, 192);
			this.frmRatee.Location = new System.Drawing.Point(3, 132);
			this.frmRatee.Name = "frmRatee";
			this.frmRatee.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.frmRatee.Size = new System.Drawing.Size(604, 109);
			this.frmRatee.TabIndex = 8;
			this.frmRatee.Text = "Ratee Information";
			this.frmRatee.Visible = true;
			// 
			// txtDlblDepartment
			// 
			this.txtDlblDepartment.AllowDrop = true;
			this.txtDlblDepartment.BackColor = System.Drawing.SystemColors.Window;
			this.txtDlblDepartment.Enabled = false;
			this.txtDlblDepartment.Location = new System.Drawing.Point(105, 42);
			this.txtDlblDepartment.Name = "txtDlblDepartment";
			this.txtDlblDepartment.Size = new System.Drawing.Size(118, 19);
			this.txtDlblDepartment.TabIndex = 14;
			// 
			// txtDlblRateeName
			// 
			this.txtDlblRateeName.AllowDrop = true;
			this.txtDlblRateeName.BackColor = System.Drawing.SystemColors.Window;
			this.txtDlblRateeName.Enabled = false;
			this.txtDlblRateeName.Location = new System.Drawing.Point(225, 21);
			this.txtDlblRateeName.Name = "txtDlblRateeName";
			this.txtDlblRateeName.Size = new System.Drawing.Size(373, 19);
			this.txtDlblRateeName.TabIndex = 13;
			// 
			// txtRateeCode
			// 
			this.txtRateeCode.AllowDrop = true;
			this.txtRateeCode.BackColor = System.Drawing.Color.White;
			// // = false;
			this.txtRateeCode.ForeColor = System.Drawing.Color.Black;
			this.txtRateeCode.Location = new System.Drawing.Point(105, 21);
			// // = (System.Windows.Forms.TextBox.DropDownTypes) 0;
			this.txtRateeCode.Name = "txtRateeCode";
			// this.txtRateeCode.ShowButton = true;
			this.txtRateeCode.Size = new System.Drawing.Size(118, 19);
			this.txtRateeCode.TabIndex = 12;
			this.txtRateeCode.Text = "";
			// this.// = "";
			// this.//this.txtRateeCode.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(//this.txtRateeCode_DropButtonClick);
			// this.txtRateeCode.Leave += new System.EventHandler(this.txtRateeCode_Leave);
			// 
			// System.Windows.Forms.Label3
			// 
			this.Label3.AllowDrop = true;
			this.Label3.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.Label3.Text = "Ratee Code";
			this.Label3.Location = new System.Drawing.Point(9, 21);
			this.Label3.Name="Label3";
			this.Label3.Size = new System.Drawing.Size(56, 14);
			this.Label3.TabIndex = 9;
			// 
			// System.Windows.Forms.Label4
			// 
			this.Label4.AllowDrop = true;
			this.Label4.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.Label4.Text = "Department";
			this.Label4.Location = new System.Drawing.Point(9, 44);
			this.Label4.Name="Label4";
			this.Label4.Size = new System.Drawing.Size(55, 14);
			this.Label4.TabIndex = 10;
			// 
			// System.Windows.Forms.Label5
			// 
			this.Label5.AllowDrop = true;
			this.Label5.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.Label5.Text = "Designation";
			this.Label5.Location = new System.Drawing.Point(9, 65);
			this.Label5.Name="Label5";
			this.Label5.Size = new System.Drawing.Size(56, 14);
			this.Label5.TabIndex = 11;
			// 
			// txtDlblDesignation
			// 
			this.txtDlblDesignation.AllowDrop = true;
			this.txtDlblDesignation.BackColor = System.Drawing.SystemColors.Window;
			this.txtDlblDesignation.Enabled = false;
			this.txtDlblDesignation.Location = new System.Drawing.Point(105, 63);
			this.txtDlblDesignation.Name = "txtDlblDesignation";
			this.txtDlblDesignation.Size = new System.Drawing.Size(118, 19);
			this.txtDlblDesignation.TabIndex = 15;
			// 
			// txtDlblDepartmentName
			// 
			this.txtDlblDepartmentName.AllowDrop = true;
			this.txtDlblDepartmentName.BackColor = System.Drawing.SystemColors.Window;
			this.txtDlblDepartmentName.Enabled = false;
			this.txtDlblDepartmentName.Location = new System.Drawing.Point(225, 42);
			this.txtDlblDepartmentName.Name = "txtDlblDepartmentName";
			this.txtDlblDepartmentName.Size = new System.Drawing.Size(373, 19);
			this.txtDlblDepartmentName.TabIndex = 16;
			// 
			// txtDlblDesignationName
			// 
			this.txtDlblDesignationName.AllowDrop = true;
			this.txtDlblDesignationName.BackColor = System.Drawing.SystemColors.Window;
			this.txtDlblDesignationName.Enabled = false;
			this.txtDlblDesignationName.Location = new System.Drawing.Point(225, 63);
			this.txtDlblDesignationName.Name = "txtDlblDesignationName";
			this.txtDlblDesignationName.Size = new System.Drawing.Size(373, 19);
			this.txtDlblDesignationName.TabIndex = 17;
			// 
			// System.Windows.Forms.Label6
			// 
			this.Label6.AllowDrop = true;
			this.Label6.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.Label6.Text = "Requested By";
			this.Label6.Location = new System.Drawing.Point(9, 87);
			this.Label6.Name="Label6";
			this.Label6.Size = new System.Drawing.Size(68, 14);
			this.Label6.TabIndex = 18;
			// 
			// txtDlblRequestedByName
			// 
			this.txtDlblRequestedByName.AllowDrop = true;
			this.txtDlblRequestedByName.BackColor = System.Drawing.SystemColors.Window;
			this.txtDlblRequestedByName.Enabled = false;
			this.txtDlblRequestedByName.Location = new System.Drawing.Point(225, 84);
			this.txtDlblRequestedByName.Name = "txtDlblRequestedByName";
			this.txtDlblRequestedByName.Size = new System.Drawing.Size(373, 19);
			this.txtDlblRequestedByName.TabIndex = 19;
			// 
			// txtRequestedBy
			// 
			this.txtRequestedBy.AllowDrop = true;
			this.txtRequestedBy.BackColor = System.Drawing.Color.White;
			// // = false;
			this.txtRequestedBy.ForeColor = System.Drawing.Color.Black;
			this.txtRequestedBy.Location = new System.Drawing.Point(105, 84);
			// // = (System.Windows.Forms.TextBox.DropDownTypes) 0;
			this.txtRequestedBy.Name = "txtRequestedBy";
			// this.txtRequestedBy.ShowButton = true;
			this.txtRequestedBy.Size = new System.Drawing.Size(118, 19);
			this.txtRequestedBy.TabIndex = 25;
			this.txtRequestedBy.Text = "";
			// this.// = "";
			// this.//this.txtRequestedBy.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(//this.txtRequestedBy_DropButtonClick);
			// this.txtRequestedBy.Leave += new System.EventHandler(this.txtRequestedBy_Leave);
			// 
			// txtEndDate
			// 
			this.txtEndDate.AllowDrop = true;
			// this.txtEndDate.CheckDateRange = false;
			this.txtEndDate.Location = new System.Drawing.Point(109, 105);
			// this.txtEndDate.MaxDate = 2958465;
			// this.txtEndDate.MinDate = 32874;
			this.txtEndDate.Name = "txtEndDate";
			// = "_";
			this.txtEndDate.Size = new System.Drawing.Size(116, 19);
			this.txtEndDate.TabIndex = 7;
			// this.txtEndDate.Text = "05/08/2010";
			// this.txtEndDate.Value = 40395;
			// 
			// txtStartDate
			// 
			this.txtStartDate.AllowDrop = true;
			// this.txtStartDate.CheckDateRange = false;
			this.txtStartDate.Location = new System.Drawing.Point(109, 81);
			// this.txtStartDate.MaxDate = 2958465;
			// this.txtStartDate.MinDate = 32874;
			this.txtStartDate.Name = "txtStartDate";
			//// = "_";
			this.txtStartDate.Size = new System.Drawing.Size(116, 19);
			this.txtStartDate.TabIndex = 6;
			// this.txtStartDate.Text = "05/08/2010";
			// this.txtStartDate.Value = 40395;
			// 
			// txtAppraisal
			// 
			this.txtAppraisal.AllowDrop = true;
			this.txtAppraisal.BackColor = System.Drawing.Color.White;
			// this.txtAppraisal.bolNumericOnly = true;
			this.txtAppraisal.ForeColor = System.Drawing.Color.Black;
			this.txtAppraisal.Location = new System.Drawing.Point(109, 57);
			this.txtAppraisal.MaxLength = 15;
			// // = System.Windows.Forms.TextBox.DropDownTypes.ddtNextNumber;
			this.txtAppraisal.Name = "txtAppraisal";
			// this.txtAppraisal.ShowButton = true;
			this.txtAppraisal.Size = new System.Drawing.Size(116, 19);
			this.txtAppraisal.TabIndex = 0;
			this.txtAppraisal.Text = "";
			// this.// = "";
			// 
			// lblCategoryNo
			// 
			this.lblCategoryNo.AllowDrop = true;
			this.lblCategoryNo.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblCategoryNo.Text = "Appraisal Code";
			this.lblCategoryNo.Location = new System.Drawing.Point(6, 59);
			this.lblCategoryNo.Name = "lblCategoryNo";
			this.lblCategoryNo.Size = new System.Drawing.Size(74, 14);
			this.lblCategoryNo.TabIndex = 1;
			// 
			// _lblCommonLabel_6
			// 
			this._lblCommonLabel_6.AllowDrop = true;
			this._lblCommonLabel_6.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_6.Text = "Transaction Date";
			this._lblCommonLabel_6.Location = new System.Drawing.Point(369, 59);
			// // this._lblCommonLabel_6.mLabelId = 1233;
			this._lblCommonLabel_6.Name = "_lblCommonLabel_6";
			this._lblCommonLabel_6.Size = new System.Drawing.Size(82, 14);
			this._lblCommonLabel_6.TabIndex = 2;
			// 
			// txtTransactionDate
			// 
			this.txtTransactionDate.AllowDrop = true;
			// this.txtTransactionDate.CheckDateRange = false;
			this.txtTransactionDate.Location = new System.Drawing.Point(478, 57);
			// this.txtTransactionDate.MaxDate = 2958465;
			// this.txtTransactionDate.MinDate = 32874;
			this.txtTransactionDate.Name = "txtTransactionDate";
			this.txtTransactionDate.Size = new System.Drawing.Size(116, 19);
			this.txtTransactionDate.TabIndex = 3;
			// this.txtTransactionDate.Text = "01/09/2010";
			// this.txtTransactionDate.Value = 40422;
			// 
			// System.Windows.Forms.Label1
			// 
			this.Label1.AllowDrop = true;
			this.Label1.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.Label1.Text = "End Date";
			this.Label1.Location = new System.Drawing.Point(6, 107);
			this.Label1.Name="Label1";
			this.Label1.Size = new System.Drawing.Size(43, 14);
			this.Label1.TabIndex = 4;
			// 
			// System.Windows.Forms.Label2
			// 
			this.Label2.AllowDrop = true;
			this.Label2.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.Label2.Text = "Start Date";
			this.Label2.Location = new System.Drawing.Point(6, 83);
			this.Label2.Name="Label2";
			this.Label2.Size = new System.Drawing.Size(48, 14);
			this.Label2.TabIndex = 5;
			// 
			// System.Windows.Forms.Label7
			// 
			this.Label7.AllowDrop = true;
			this.Label7.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.Label7.Text = "Survey Template";
			this.Label7.Location = new System.Drawing.Point(9, 252);
			this.Label7.Name="Label7";
			this.Label7.Size = new System.Drawing.Size(81, 14);
			this.Label7.TabIndex = 20;
			// 
			// txtSuveyTemplate
			// 
			this.txtSuveyTemplate.AllowDrop = true;
			this.txtSuveyTemplate.BackColor = System.Drawing.Color.White;
			// // = false;
			this.txtSuveyTemplate.ForeColor = System.Drawing.Color.Black;
			this.txtSuveyTemplate.Location = new System.Drawing.Point(108, 249);
			// // = (System.Windows.Forms.TextBox.DropDownTypes) 0;
			this.txtSuveyTemplate.Name = "txtSuveyTemplate";
			// this.txtSuveyTemplate.ShowButton = true;
			this.txtSuveyTemplate.Size = new System.Drawing.Size(118, 19);
			this.txtSuveyTemplate.TabIndex = 21;
			// this.txtSuveyTemplate.Text = "";
			// this.// = "";
			// this.//this.txtSuveyTemplate.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(//this.txtSuveyTemplate_DropButtonClick);
			// this.txtSuveyTemplate.Leave += new System.EventHandler(this.txtSuveyTemplate_Leave);
			// 
			// txtDlBLSurveyTemplateName
			// 
			this.txtDlBLSurveyTemplateName.AllowDrop = true;
			this.txtDlBLSurveyTemplateName.BackColor = System.Drawing.SystemColors.Window;
			this.txtDlBLSurveyTemplateName.Enabled = false;
			this.txtDlBLSurveyTemplateName.Location = new System.Drawing.Point(228, 249);
			this.txtDlBLSurveyTemplateName.Name = "txtDlBLSurveyTemplateName";
			this.txtDlBLSurveyTemplateName.Size = new System.Drawing.Size(370, 19);
			this.txtDlBLSurveyTemplateName.TabIndex = 22;
			// 
			// cmbMastersList
			// 
			this.cmbMastersList.AllowDrop = true;
			this.cmbMastersList.ColumnHeaders = true;
			this.cmbMastersList.Enabled = true;
			this.cmbMastersList.Location = new System.Drawing.Point(351, 339);
			this.cmbMastersList.Name = "cmbMastersList";
			this.cmbMastersList.Size = new System.Drawing.Size(53, 43);
			this.cmbMastersList.TabIndex = 24;
			this.cmbMastersList.Columns.Add(this.Column_0_cmbMastersList);
			this.cmbMastersList.Columns.Add(this.Column_1_cmbMastersList);
			// 
			// Column_0_cmbMastersList
			// 
			this.Column_0_cmbMastersList.DataField = "";
			this.Column_0_cmbMastersList.ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.Normal;
			// 
			// Column_1_cmbMastersList
			// 
			this.Column_1_cmbMastersList.DataField = "";
			this.Column_1_cmbMastersList.ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.Normal;
			// 
			// grdSurveyDetails
			// 
			this.grdSurveyDetails.AllowAddNew = true;
			this.grdSurveyDetails.AllowDelete = true;
			this.grdSurveyDetails.AllowDrop = true;
			this.grdSurveyDetails.BackColor = System.Drawing.Color.FromArgb(212, 208, 200);
			this.grdSurveyDetails.CellTipsWidth = 0;
			this.grdSurveyDetails.Location = new System.Drawing.Point(0, 276);
			this.grdSurveyDetails.Name = "grdSurveyDetails";
			this.grdSurveyDetails.RowDivider.Color = System.Drawing.Color.FromArgb(212, 208, 200);
			this.grdSurveyDetails.Size = new System.Drawing.Size(616, 187);
			this.grdSurveyDetails.TabIndex = 23;
			this.grdSurveyDetails.Columns.Add(this.Column_0_grdSurveyDetails);
			this.grdSurveyDetails.Columns.Add(this.Column_1_grdSurveyDetails);
			this.grdSurveyDetails.GotFocus += new System.EventHandler(this.grdSurveyDetails_GotFocus);
			this.grdSurveyDetails.RowColChange += new C1.Win.C1TrueDBGrid.RowColChangeEventHandler(this.grdSurveyDetails_RowColChange);
			// 
			// Column_0_grdSurveyDetails
			// 
			this.Column_0_grdSurveyDetails.DataField = "";
			this.Column_0_grdSurveyDetails.ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.Normal;
			// 
			// Column_1_grdSurveyDetails
			// 
			this.Column_1_grdSurveyDetails.DataField = "";
			this.Column_1_grdSurveyDetails.ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.Normal;
			// 
			// frmPayAppraisal
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.ClientSize = new System.Drawing.Size(620, 466);
			this.Controls.Add(this.frmRatee);
			this.Controls.Add(this.txtEndDate);
			this.Controls.Add(this.txtStartDate);
			this.Controls.Add(this.txtAppraisal);
			this.Controls.Add(this.lblCategoryNo);
			this.Controls.Add(this._lblCommonLabel_6);
			this.Controls.Add(this.txtTransactionDate);
			this.Controls.Add(this.Label1);
			this.Controls.Add(this.Label2);
			this.Controls.Add(this.Label7);
			this.Controls.Add(this.txtSuveyTemplate);
			this.Controls.Add(this.txtDlBLSurveyTemplateName);
			this.Controls.Add(this.cmbMastersList);
			this.Controls.Add(this.grdSurveyDetails);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			//this.Icon = (System.Drawing.Icon) resources.GetObject("frmPayAppraisal.Icon");
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(126, 109);
			this.MaximizeBox = true;
			this.MinimizeBox = true;
			this.Name = "frmPayAppraisal";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Appraisal";
			// this.Activated += new System.EventHandler(this.frmPayAppraisal_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
			// this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
			this.frmRatee.ResumeLayout(false);
			this.cmbMastersList.ResumeLayout(false);
			this.grdSurveyDetails.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		// 
		void InitializelblCommonLabel()
		{
			this.lblCommonLabel = new System.Windows.Forms.Label[7];
			this.lblCommonLabel[6] = _lblCommonLabel_6;
		}
		#endregion
	}
}//ENDSHERE
