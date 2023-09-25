
namespace Xtreme
{
	partial class frmPayPayrollEntry
	{

		#region "Upgrade Support "
		private static frmPayPayrollEntry m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmPayPayrollEntry DefInstance
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
		public static frmPayPayrollEntry CreateInstance()
		{
			frmPayPayrollEntry theInstance = new frmPayPayrollEntry();
			
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
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "cmdRefresh", "txtDlblDeptName", "txtDlblPayrollEmployee", "txtComments", "_txtCommonTextBox_0", "txtEmployeeCode", "lblSystemComponents", "_lblCommonLabel_2", "_lblCommonLabel_0", "_lblCommonLabel_1", "_lblCommonLabel_3", "_lblCommonLabel_9", "_txtDisplayLabel_4", "_txtDisplayLabel_5", "_txtDisplayLabel_3", "_txtDisplayLabel_2", "_txtDisplayLabel_0", "_txtDisplayLabel_1", "_txtCommonTextBox_1", "lblComments", "cmbMonth", "cmbYear", "_lblCommonLabel_4", "txtDlblStatus", "_lblCommon_0", "_lblCommonLabel_5", "Column_0_grdVoucherDetails", "Column_1_grdVoucherDetails", "grdVoucherDetails", "Column_0_cmbMastersList", "Column_1_cmbMastersList", "cmbMastersList", "lblCommon", "lblCommonLabel", "txtCommonTextBox", "txtDisplayLabel"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public System.Windows.Forms.Button cmdRefresh;
		public System.Windows.Forms.Label txtDlblDeptName;
		public System.Windows.Forms.Label txtDlblPayrollEmployee;
		public System.Windows.Forms.TextBox txtComments;
		private System.Windows.Forms.TextBox _txtCommonTextBox_0;
		public System.Windows.Forms.TextBox txtEmployeeCode;
		public System.Windows.Forms.Label lblSystemComponents;
		private System.Windows.Forms.Label _lblCommonLabel_2;
		private System.Windows.Forms.Label _lblCommonLabel_0;
		private System.Windows.Forms.Label _lblCommonLabel_1;
		private System.Windows.Forms.Label _lblCommonLabel_3;
		private System.Windows.Forms.Label _lblCommonLabel_9;
		private System.Windows.Forms.Label _txtDisplayLabel_4;
		private System.Windows.Forms.Label _txtDisplayLabel_5;
		private System.Windows.Forms.Label _txtDisplayLabel_3;
		private System.Windows.Forms.Label _txtDisplayLabel_2;
		private System.Windows.Forms.Label _txtDisplayLabel_0;
		private System.Windows.Forms.Label _txtDisplayLabel_1;
		private System.Windows.Forms.TextBox _txtCommonTextBox_1;
		public System.Windows.Forms.Label lblComments;
		public System.Windows.Forms.ComboBox cmbMonth;
		public System.Windows.Forms.ComboBox cmbYear;
		private System.Windows.Forms.Label _lblCommonLabel_4;
		public System.Windows.Forms.Label txtDlblStatus;
		private System.Windows.Forms.Label _lblCommon_0;
		private System.Windows.Forms.Label _lblCommonLabel_5;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_0_grdVoucherDetails;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_1_grdVoucherDetails;
		public C1.Win.C1TrueDBGrid.C1TrueDBGrid grdVoucherDetails;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_0_cmbMastersList;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_1_cmbMastersList;
		public C1.Win.C1TrueDBGrid.C1TrueDBDropdown cmbMastersList;
		public System.Windows.Forms.Label[] lblCommon = new System.Windows.Forms.Label[1];
		public System.Windows.Forms.Label[] lblCommonLabel = new System.Windows.Forms.Label[10];
		public System.Windows.Forms.TextBox[] txtCommonTextBox = new System.Windows.Forms.TextBox[2];
		public System.Windows.Forms.Label[] txtDisplayLabel = new System.Windows.Forms.Label[6];
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPayPayrollEntry));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this.cmdRefresh = new System.Windows.Forms.Button();
			this.txtDlblDeptName = new System.Windows.Forms.Label();
			this.txtDlblPayrollEmployee = new System.Windows.Forms.Label();
			this.txtComments = new System.Windows.Forms.TextBox();
			this._txtCommonTextBox_0 = new System.Windows.Forms.TextBox();
			this.txtEmployeeCode = new System.Windows.Forms.TextBox();
			this.lblSystemComponents = new System.Windows.Forms.Label();
			this._lblCommonLabel_2 = new System.Windows.Forms.Label();
			this._lblCommonLabel_0 = new System.Windows.Forms.Label();
			this._lblCommonLabel_1 = new System.Windows.Forms.Label();
			this._lblCommonLabel_3 = new System.Windows.Forms.Label();
			this._lblCommonLabel_9 = new System.Windows.Forms.Label();
			this._txtDisplayLabel_4 = new System.Windows.Forms.Label();
			this._txtDisplayLabel_5 = new System.Windows.Forms.Label();
			this._txtDisplayLabel_3 = new System.Windows.Forms.Label();
			this._txtDisplayLabel_2 = new System.Windows.Forms.Label();
			this._txtDisplayLabel_0 = new System.Windows.Forms.Label();
			this._txtDisplayLabel_1 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_1 = new System.Windows.Forms.TextBox();
			this.lblComments = new System.Windows.Forms.Label();
			this.cmbMonth = new System.Windows.Forms.ComboBox();
			this.cmbYear = new System.Windows.Forms.ComboBox();
			this._lblCommonLabel_4 = new System.Windows.Forms.Label();
			this.txtDlblStatus = new System.Windows.Forms.Label();
			this._lblCommon_0 = new System.Windows.Forms.Label();
			this._lblCommonLabel_5 = new System.Windows.Forms.Label();
			this.grdVoucherDetails = new C1.Win.C1TrueDBGrid.C1TrueDBGrid();
			this.Column_0_grdVoucherDetails = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.Column_1_grdVoucherDetails = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.cmbMastersList = new C1.Win.C1TrueDBGrid.C1TrueDBDropdown();
			this.Column_0_cmbMastersList = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.Column_1_cmbMastersList = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.grdVoucherDetails.SuspendLayout();
			this.cmbMastersList.SuspendLayout();
			this.SuspendLayout();
			// 
			// cmdRefresh
			// 
			this.cmdRefresh.AllowDrop = true;
			this.cmdRefresh.BackColor = System.Drawing.SystemColors.Control;
			this.cmdRefresh.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdRefresh.Location = new System.Drawing.Point(372, 54);
			this.cmdRefresh.Name = "cmdRefresh";
			this.cmdRefresh.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdRefresh.Size = new System.Drawing.Size(131, 38);
			this.cmdRefresh.TabIndex = 25;
			this.cmdRefresh.Text = "Refresh";
			this.cmdRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.cmdRefresh.UseVisualStyleBackColor = false;
			// this.cmdRefresh.Click += new System.EventHandler(this.cmdRefresh_Click);
			// 
			// txtDlblDeptName
			// 
			this.txtDlblDeptName.AllowDrop = true;
			this.txtDlblDeptName.Enabled = false;
			this.txtDlblDeptName.Location = new System.Drawing.Point(100, 31);
			this.txtDlblDeptName.Name = "txtDlblDeptName";
			this.txtDlblDeptName.Size = new System.Drawing.Size(262, 19);
			this.txtDlblDeptName.TabIndex = 23;
			// 
			// txtDlblPayrollEmployee
			// 
			this.txtDlblPayrollEmployee.AllowDrop = true;
			this.txtDlblPayrollEmployee.Enabled = false;
			this.txtDlblPayrollEmployee.Location = new System.Drawing.Point(432, 31);
			this.txtDlblPayrollEmployee.Name = "txtDlblPayrollEmployee";
			this.txtDlblPayrollEmployee.Size = new System.Drawing.Size(71, 19);
			this.txtDlblPayrollEmployee.TabIndex = 20;
			// 
			// txtComments
			// 
			this.txtComments.AllowDrop = true;
			this.txtComments.BackColor = System.Drawing.Color.White;
			// this.txtComments.bolAllowDecimal = false;
			this.txtComments.ForeColor = System.Drawing.Color.Black;
			this.txtComments.Location = new System.Drawing.Point(100, 99);
			// this.txtComments.mDropDownType = (System.Windows.Forms.TextBox.DropDownTypes) 0;
			this.txtComments.Name = "txtComments";
			this.txtComments.Size = new System.Drawing.Size(597, 21);
			this.txtComments.TabIndex = 16;
			this.txtComments.Text = "";
			// this.this.txtComments.Watermark = "";
			// 
			// _txtCommonTextBox_0
			// 
			this._txtCommonTextBox_0.AllowDrop = true;
			this._txtCommonTextBox_0.BackColor = System.Drawing.Color.White;
			// this._txtCommonTextBox_0.bolAllowDecimal = false;
			this._txtCommonTextBox_0.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_0.Location = new System.Drawing.Point(498, 9);
			// this._txtCommonTextBox_0.mDropDownType = (System.Windows.Forms.TextBox.DropDownTypes) 0;
			this._txtCommonTextBox_0.Name = "_txtCommonTextBox_0";
			this._txtCommonTextBox_0.Size = new System.Drawing.Size(53, 19);
			this._txtCommonTextBox_0.TabIndex = 13;
			this._txtCommonTextBox_0.Text = "";
			this._txtCommonTextBox_0.Visible = false;
			// this.this._txtCommonTextBox_0.Watermark = "";
			// 
			// txtEmployeeCode
			// 
			this.txtEmployeeCode.AllowDrop = true;
			this.txtEmployeeCode.BackColor = System.Drawing.Color.White;
			// this.txtEmployeeCode.bolAllowDecimal = false;
			this.txtEmployeeCode.ForeColor = System.Drawing.Color.Black;
			this.txtEmployeeCode.Location = new System.Drawing.Point(616, 14);
			// this.txtEmployeeCode.mDropDownType = (System.Windows.Forms.TextBox.DropDownTypes) 0;
			this.txtEmployeeCode.Name = "txtEmployeeCode";
			// this.txtEmployeeCode.ShowButton = true;
			this.txtEmployeeCode.Size = new System.Drawing.Size(107, 19);
			this.txtEmployeeCode.TabIndex = 12;
			this.txtEmployeeCode.Text = "";
			this.txtEmployeeCode.Visible = false;
			// this.this.txtEmployeeCode.Watermark = "";
			// this.this.txtEmployeeCode.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtEmployeeCode_DropButtonClick);
			// this.txtEmployeeCode.Leave += new System.EventHandler(this.txtEmployeeCode_Leave);
			// 
			// lblSystemComponents
			// 
			this.lblSystemComponents.AllowDrop = true;
			this.lblSystemComponents.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblSystemComponents.Text = " Payroll Information ";
			this.lblSystemComponents.Location = new System.Drawing.Point(14, 126);
			// // this.lblSystemComponents.mLabelId = 1147;
			this.lblSystemComponents.Name = "lblSystemComponents";
			this.lblSystemComponents.Size = new System.Drawing.Size(116, 13);
			this.lblSystemComponents.TabIndex = 0;
			// 
			// _lblCommonLabel_2
			// 
			this._lblCommonLabel_2.AllowDrop = true;
			this._lblCommonLabel_2.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_2.Text = "Employee Code";
			this._lblCommonLabel_2.Location = new System.Drawing.Point(6, 12);
			// // this._lblCommonLabel_2.mLabelId = 236;
			this._lblCommonLabel_2.Name = "_lblCommonLabel_2";
			this._lblCommonLabel_2.Size = new System.Drawing.Size(74, 14);
			this._lblCommonLabel_2.TabIndex = 1;
			// 
			// _lblCommonLabel_0
			// 
			this._lblCommonLabel_0.AllowDrop = true;
			this._lblCommonLabel_0.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_0.Text = "Month";
			this._lblCommonLabel_0.Location = new System.Drawing.Point(7, 56);
			// // this._lblCommonLabel_0.mLabelId = 1145;
			this._lblCommonLabel_0.Name = "_lblCommonLabel_0";
			this._lblCommonLabel_0.Size = new System.Drawing.Size(29, 14);
			this._lblCommonLabel_0.TabIndex = 2;
			// 
			// _lblCommonLabel_1
			// 
			this._lblCommonLabel_1.AllowDrop = true;
			this._lblCommonLabel_1.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_1.Text = "Year";
			this._lblCommonLabel_1.Location = new System.Drawing.Point(7, 80);
			// // this._lblCommonLabel_1.mLabelId = 1146;
			this._lblCommonLabel_1.Name = "_lblCommonLabel_1";
			this._lblCommonLabel_1.Size = new System.Drawing.Size(24, 14);
			this._lblCommonLabel_1.TabIndex = 3;
			// 
			// _lblCommonLabel_3
			// 
			this._lblCommonLabel_3.AllowDrop = true;
			this._lblCommonLabel_3.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_3.Text = "Basic Salary";
			this._lblCommonLabel_3.Location = new System.Drawing.Point(209, 54);
			// // this._lblCommonLabel_3.mLabelId = 1970;
			this._lblCommonLabel_3.Name = "_lblCommonLabel_3";
			this._lblCommonLabel_3.Size = new System.Drawing.Size(61, 14);
			this._lblCommonLabel_3.TabIndex = 4;
			// 
			// _lblCommonLabel_9
			// 
			this._lblCommonLabel_9.AllowDrop = true;
			this._lblCommonLabel_9.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_9.Text = "Total  Salary";
			this._lblCommonLabel_9.Location = new System.Drawing.Point(209, 77);
			// // this._lblCommonLabel_9.mLabelId = 818;
			this._lblCommonLabel_9.Name = "_lblCommonLabel_9";
			this._lblCommonLabel_9.Size = new System.Drawing.Size(60, 14);
			this._lblCommonLabel_9.TabIndex = 5;
			// 
			// _txtDisplayLabel_4
			// 
			// this._txtDisplayLabel_4.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
			this._txtDisplayLabel_4.AllowDrop = true;
			this._txtDisplayLabel_4.Location = new System.Drawing.Point(275, 52);
			this._txtDisplayLabel_4.Name = "_txtDisplayLabel_4";
			this._txtDisplayLabel_4.Size = new System.Drawing.Size(87, 19);
			this._txtDisplayLabel_4.TabIndex = 6;
			// 
			// _txtDisplayLabel_5
			// 
			// this._txtDisplayLabel_5.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
			this._txtDisplayLabel_5.AllowDrop = true;
			this._txtDisplayLabel_5.Location = new System.Drawing.Point(275, 75);
			this._txtDisplayLabel_5.Name = "_txtDisplayLabel_5";
			this._txtDisplayLabel_5.Size = new System.Drawing.Size(87, 19);
			this._txtDisplayLabel_5.TabIndex = 7;
			// 
			// _txtDisplayLabel_3
			// 
			this._txtDisplayLabel_3.AllowDrop = true;
			this._txtDisplayLabel_3.Location = new System.Drawing.Point(732, 12);
			this._txtDisplayLabel_3.Name = "_txtDisplayLabel_3";
			this._txtDisplayLabel_3.Size = new System.Drawing.Size(11, 19);
			this._txtDisplayLabel_3.TabIndex = 8;
			this._txtDisplayLabel_3.Visible = false;
			// 
			// _txtDisplayLabel_2
			// 
			this._txtDisplayLabel_2.AllowDrop = true;
			this._txtDisplayLabel_2.Location = new System.Drawing.Point(597, 3);
			this._txtDisplayLabel_2.Name = "_txtDisplayLabel_2";
			this._txtDisplayLabel_2.Size = new System.Drawing.Size(11, 19);
			this._txtDisplayLabel_2.TabIndex = 9;
			this._txtDisplayLabel_2.Visible = false;
			// 
			// _txtDisplayLabel_0
			// 
			this._txtDisplayLabel_0.AllowDrop = true;
			this._txtDisplayLabel_0.Location = new System.Drawing.Point(100, 10);
			this._txtDisplayLabel_0.Name = "_txtDisplayLabel_0";
			this._txtDisplayLabel_0.Size = new System.Drawing.Size(71, 19);
			this._txtDisplayLabel_0.TabIndex = 10;
			// 
			// _txtDisplayLabel_1
			// 
			this._txtDisplayLabel_1.AllowDrop = true;
			this._txtDisplayLabel_1.Location = new System.Drawing.Point(173, 10);
			this._txtDisplayLabel_1.Name = "_txtDisplayLabel_1";
			this._txtDisplayLabel_1.Size = new System.Drawing.Size(189, 19);
			this._txtDisplayLabel_1.TabIndex = 11;
			// 
			// _txtCommonTextBox_1
			// 
			this._txtCommonTextBox_1.AllowDrop = true;
			this._txtCommonTextBox_1.BackColor = System.Drawing.Color.White;
			// this._txtCommonTextBox_1.bolAllowDecimal = false;
			this._txtCommonTextBox_1.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_1.Location = new System.Drawing.Point(528, 9);
			// this._txtCommonTextBox_1.mDropDownType = (System.Windows.Forms.TextBox.DropDownTypes) 0;
			this._txtCommonTextBox_1.Name = "_txtCommonTextBox_1";
			this._txtCommonTextBox_1.Size = new System.Drawing.Size(59, 19);
			this._txtCommonTextBox_1.TabIndex = 14;
			this._txtCommonTextBox_1.Text = "";
			this._txtCommonTextBox_1.Visible = false;
			// this.this._txtCommonTextBox_1.Watermark = "";
			// 
			// lblComments
			// 
			this.lblComments.AllowDrop = true;
			this.lblComments.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblComments.Text = "Comment";
			this.lblComments.Location = new System.Drawing.Point(6, 102);
			// // this.lblComments.mLabelId = 1851;
			this.lblComments.Name = "lblComments";
			this.lblComments.Size = new System.Drawing.Size(44, 14);
			this.lblComments.TabIndex = 15;
			// 
			// cmbMonth
			// 
			this.cmbMonth.AllowDrop = true;
			this.cmbMonth.Location = new System.Drawing.Point(101, 52);
			this.cmbMonth.Name = "cmbMonth";
			this.cmbMonth.Size = new System.Drawing.Size(101, 21);
			this.cmbMonth.TabIndex = 17;
			// 
			// cmbYear
			// 
			this.cmbYear.AllowDrop = true;
			this.cmbYear.Location = new System.Drawing.Point(101, 76);
			this.cmbYear.Name = "cmbYear";
			this.cmbYear.Size = new System.Drawing.Size(101, 21);
			this.cmbYear.TabIndex = 18;
			// 
			// _lblCommonLabel_4
			// 
			this._lblCommonLabel_4.AllowDrop = true;
			this._lblCommonLabel_4.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_4.Text = "Payroll Emp";
			this._lblCommonLabel_4.Location = new System.Drawing.Point(372, 34);
			this._lblCommonLabel_4.Name = "_lblCommonLabel_4";
			this._lblCommonLabel_4.Size = new System.Drawing.Size(55, 14);
			this._lblCommonLabel_4.TabIndex = 19;
			// 
			// txtDlblStatus
			// 
			this.txtDlblStatus.AllowDrop = true;
			this.txtDlblStatus.Location = new System.Drawing.Point(432, 10);
			this.txtDlblStatus.Name = "txtDlblStatus";
			this.txtDlblStatus.Size = new System.Drawing.Size(71, 19);
			this.txtDlblStatus.TabIndex = 21;
			this.txtDlblStatus.TabStop = false;
			// 
			// _lblCommon_0
			// 
			this._lblCommon_0.AllowDrop = true;
			this._lblCommon_0.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_0.Text = "Department Name";
			this._lblCommon_0.Location = new System.Drawing.Point(6, 33);
			this._lblCommon_0.Name = "_lblCommon_0";
			this._lblCommon_0.Size = new System.Drawing.Size(85, 14);
			this._lblCommon_0.TabIndex = 22;
			// 
			// _lblCommonLabel_5
			// 
			this._lblCommonLabel_5.AllowDrop = true;
			this._lblCommonLabel_5.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_5.Text = "Status";
			this._lblCommonLabel_5.Location = new System.Drawing.Point(372, 12);
			this._lblCommonLabel_5.Name = "_lblCommonLabel_5";
			this._lblCommonLabel_5.Size = new System.Drawing.Size(31, 14);
			this._lblCommonLabel_5.TabIndex = 24;
			// 
			// grdVoucherDetails
			// 
			this.grdVoucherDetails.AllowDrop = true;
			this.grdVoucherDetails.BackColor = System.Drawing.Color.Silver;
			this.grdVoucherDetails.CellTipsWidth = 0;
			this.grdVoucherDetails.Location = new System.Drawing.Point(6, 142);
			this.grdVoucherDetails.Name = "grdVoucherDetails";
			this.grdVoucherDetails.RowDivider.Color = System.Drawing.Color.Silver;
			this.grdVoucherDetails.Size = new System.Drawing.Size(743, 236);
			this.grdVoucherDetails.TabIndex = 26;
			this.grdVoucherDetails.Columns.Add(this.Column_0_grdVoucherDetails);
			this.grdVoucherDetails.Columns.Add(this.Column_1_grdVoucherDetails);
			this.grdVoucherDetails.AfterColUpdate += new C1.Win.C1TrueDBGrid.ColEventHandler(this.grdVoucherDetails_AfterColUpdate);
			this.grdVoucherDetails.ButtonClick += new C1.Win.C1TrueDBGrid.ColEventHandler(this.grdVoucherDetails_ButtonClick);
			this.grdVoucherDetails.GotFocus += new System.EventHandler(this.grdVoucherDetails_GotFocus);
			this.grdVoucherDetails.RowColChange += new C1.Win.C1TrueDBGrid.RowColChangeEventHandler(this.grdVoucherDetails_RowColChange);
			// 
			// Column_0_grdVoucherDetails
			// 
			this.Column_0_grdVoucherDetails.DataField = "";
			this.Column_0_grdVoucherDetails.ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.Normal;
			// 
			// Column_1_grdVoucherDetails
			// 
			this.Column_1_grdVoucherDetails.DataField = "";
			this.Column_1_grdVoucherDetails.ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.Normal;
			// 
			// cmbMastersList
			// 
			this.cmbMastersList.AllowDrop = true;
			this.cmbMastersList.ColumnHeaders = true;
			this.cmbMastersList.Enabled = true;
			this.cmbMastersList.Location = new System.Drawing.Point(4, 160);
			this.cmbMastersList.Name = "cmbMastersList";
			this.cmbMastersList.Size = new System.Drawing.Size(53, 37);
			this.cmbMastersList.TabIndex = 27;
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
			// frmPayPayrollEntry
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.ClientSize = new System.Drawing.Size(925, 480);
			this.Controls.Add(this.cmdRefresh);
			this.Controls.Add(this.txtDlblDeptName);
			this.Controls.Add(this.txtDlblPayrollEmployee);
			this.Controls.Add(this.txtComments);
			this.Controls.Add(this._txtCommonTextBox_0);
			this.Controls.Add(this.txtEmployeeCode);
			this.Controls.Add(this.lblSystemComponents);
			this.Controls.Add(this._lblCommonLabel_2);
			this.Controls.Add(this._lblCommonLabel_0);
			this.Controls.Add(this._lblCommonLabel_1);
			this.Controls.Add(this._lblCommonLabel_3);
			this.Controls.Add(this._lblCommonLabel_9);
			this.Controls.Add(this._txtDisplayLabel_4);
			this.Controls.Add(this._txtDisplayLabel_5);
			this.Controls.Add(this._txtDisplayLabel_3);
			this.Controls.Add(this._txtDisplayLabel_2);
			this.Controls.Add(this._txtDisplayLabel_0);
			this.Controls.Add(this._txtDisplayLabel_1);
			this.Controls.Add(this._txtCommonTextBox_1);
			this.Controls.Add(this.lblComments);
			this.Controls.Add(this.cmbMonth);
			this.Controls.Add(this.cmbYear);
			this.Controls.Add(this._lblCommonLabel_4);
			this.Controls.Add(this.txtDlblStatus);
			this.Controls.Add(this._lblCommon_0);
			this.Controls.Add(this._lblCommonLabel_5);
			this.Controls.Add(this.grdVoucherDetails);
			this.Controls.Add(this.cmbMastersList);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			//this.Icon = (System.Drawing.Icon) resources.GetObject("frmPayPayrollEntry.Icon");
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(129, 136);
			this.MaximizeBox = true;
			this.MinimizeBox = true;
			this.Name = "frmPayPayrollEntry";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Tag = "\"H: 6225  W:9570\"";
			this.Text = "Payroll Entry";
			// this.Activated += new System.EventHandler(this.frmPayPayrollEntry_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
			// this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
			//this.Resize += new System.EventHandler(this.Form_Resize);
			this.grdVoucherDetails.ResumeLayout(false);
			this.cmbMastersList.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		void ReLoadForm(bool addEvents)
		{
			InitializetxtDisplayLabel();
			InitializetxtCommonTextBox();
			InitializelblCommonLabel();
			InitializelblCommon();
			//This form is an MDI child.
			//This code simulates the VB6 
			// functionality of automatically
			// loading and showing an MDI
			// child's parent.
			this.MdiParent = Xtreme.frmSysMain.DefInstance;
			Xtreme.frmSysMain.DefInstance.Show();
		}
		void InitializetxtDisplayLabel()
		{
			this.txtDisplayLabel = new System.Windows.Forms.Label[6];
			this.txtDisplayLabel[4] = _txtDisplayLabel_4;
			this.txtDisplayLabel[5] = _txtDisplayLabel_5;
			this.txtDisplayLabel[3] = _txtDisplayLabel_3;
			this.txtDisplayLabel[2] = _txtDisplayLabel_2;
			this.txtDisplayLabel[0] = _txtDisplayLabel_0;
			this.txtDisplayLabel[1] = _txtDisplayLabel_1;
		}
		void InitializetxtCommonTextBox()
		{
			this.txtCommonTextBox = new System.Windows.Forms.TextBox[2];
			this.txtCommonTextBox[0] = _txtCommonTextBox_0;
			this.txtCommonTextBox[1] = _txtCommonTextBox_1;
		}
		void InitializelblCommonLabel()
		{
			this.lblCommonLabel = new System.Windows.Forms.Label[10];
			this.lblCommonLabel[2] = _lblCommonLabel_2;
			this.lblCommonLabel[0] = _lblCommonLabel_0;
			this.lblCommonLabel[1] = _lblCommonLabel_1;
			this.lblCommonLabel[3] = _lblCommonLabel_3;
			this.lblCommonLabel[9] = _lblCommonLabel_9;
			this.lblCommonLabel[4] = _lblCommonLabel_4;
			this.lblCommonLabel[5] = _lblCommonLabel_5;
		}
		void InitializelblCommon()
		{
			this.lblCommon = new System.Windows.Forms.Label[1];
			this.lblCommon[0] = _lblCommon_0;
		}
		#endregion
	}
}//ENDSHERE
