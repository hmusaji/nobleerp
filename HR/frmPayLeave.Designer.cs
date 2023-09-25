
namespace Xtreme
{
	partial class frmPayLeave
	{

		#region "Upgrade Support "
		private static frmPayLeave m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmPayLeave DefInstance
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
		public static frmPayLeave CreateInstance()
		{
			frmPayLeave theInstance = new frmPayLeave();
			
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
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "txtLeaveDaysAfterSOP", "System.Windows.Forms.Label2", "System.Windows.Forms.Label3", "txtWDPerMonthAfterSOP", "Frame2", "txtLeaveDaysBeforeSOP", "System.Windows.Forms.Label8", "System.Windows.Forms.Label9", "txtWDPerMonthBeforeSOP", "Frame1", "txtComment", "chkIncludeInDefaultLeaveTypes", "cmdUpdateEmployees", "_txtCommonTextBox_0", "_txtDisplayLabel_0", "System.Windows.Forms.Label7", "System.Windows.Forms.Label10", "_txtCommonTextBox_1", "_txtDisplayLabel_1", "Frame3", "chkIncludeWeekend", "chkCalcOnCalendarDays", "cmbLeaveType", "txtLeaveNo", "lblLeaveName", "txtLLeaveName", "lblALeaveName", "txtALeaveName", "lblComments", "lblLeaveNo", "System.Windows.Forms.Label6", "System.Windows.Forms.Label1", "System.Windows.Forms.Label4", "cmbDeductUnpaidDays", "System.Windows.Forms.Label5", "txtLeaveSwitchOverPeriod", "System.Windows.Forms.Label11", "cmbDeductPaidDays", "cmbDeductAbsentDays", "_optValidity_0", "_optValidity_1", "_optValidity_2", "cmbMonth", "System.Windows.Forms.Label12", "txtEligibilityDays", "System.Windows.Forms.Label13", "frmvalidityPeriod", "Column_0_cmbMastersList", "Column_1_cmbMastersList", "cmbMastersList", "Column_0_grdLeaveEarningDetails", "Column_1_grdLeaveEarningDetails", "grdLeaveEarningDetails", "frmLeaveEarnings", "tabLeaveDetails", "optValidity", "txtCommonTextBox", "txtDisplayLabel"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public System.Windows.Forms.TextBox txtLeaveDaysAfterSOP;
		public System.Windows.Forms.Label System.Windows.Forms.Label2;
		public System.Windows.Forms.Label System.Windows.Forms.Label3;
		public System.Windows.Forms.TextBox txtWDPerMonthAfterSOP;
		public System.Windows.Forms.GroupBox Frame2;
		public System.Windows.Forms.TextBox txtLeaveDaysBeforeSOP;
		public System.Windows.Forms.Label System.Windows.Forms.Label8;
		public System.Windows.Forms.Label System.Windows.Forms.Label9;
		public System.Windows.Forms.TextBox txtWDPerMonthBeforeSOP;
		public System.Windows.Forms.GroupBox Frame1;
		public System.Windows.Forms.TextBox txtComment;
		public System.Windows.Forms.CheckBox chkIncludeInDefaultLeaveTypes;
		public System.Windows.Forms.Button cmdUpdateEmployees;
		private System.Windows.Forms.TextBox _txtCommonTextBox_0;
		private System.Windows.Forms.Label _txtDisplayLabel_0;
		public System.Windows.Forms.Label System.Windows.Forms.Label7;
		public System.Windows.Forms.Label System.Windows.Forms.Label10;
		private System.Windows.Forms.TextBox _txtCommonTextBox_1;
		private System.Windows.Forms.Label _txtDisplayLabel_1;
		public System.Windows.Forms.GroupBox Frame3;
		public System.Windows.Forms.CheckBox chkIncludeWeekend;
		public System.Windows.Forms.CheckBox chkCalcOnCalendarDays;
		public System.Windows.Forms.ComboBox cmbLeaveType;
		public System.Windows.Forms.TextBox txtLeaveNo;
		public System.Windows.Forms.Label lblLeaveName;
		public System.Windows.Forms.TextBox txtLLeaveName;
		public System.Windows.Forms.Label lblALeaveName;
		public System.Windows.Forms.TextBox txtALeaveName;
		public System.Windows.Forms.Label lblComments;
		public System.Windows.Forms.Label lblLeaveNo;
		public System.Windows.Forms.Label System.Windows.Forms.Label6;
		public System.Windows.Forms.Label System.Windows.Forms.Label1;
		public System.Windows.Forms.Label System.Windows.Forms.Label4;
		public System.Windows.Forms.ComboBox cmbDeductUnpaidDays;
		public System.Windows.Forms.Label System.Windows.Forms.Label5;
		public System.Windows.Forms.TextBox txtLeaveSwitchOverPeriod;
		public System.Windows.Forms.Label System.Windows.Forms.Label11;
		public System.Windows.Forms.ComboBox cmbDeductPaidDays;
		public System.Windows.Forms.ComboBox cmbDeductAbsentDays;
		private System.Windows.Forms.RadioButton _optValidity_0;
		private System.Windows.Forms.RadioButton _optValidity_1;
		private System.Windows.Forms.RadioButton _optValidity_2;
		public System.Windows.Forms.ComboBox cmbMonth;
		public System.Windows.Forms.Label System.Windows.Forms.Label12;
		public System.Windows.Forms.TextBox txtEligibilityDays;
		public System.Windows.Forms.Label System.Windows.Forms.Label13;
		public System.Windows.Forms.GroupBox frmvalidityPeriod;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_0_cmbMastersList;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_1_cmbMastersList;
		public C1.Win.C1TrueDBGrid.C1TrueDBDropdown cmbMastersList;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_0_grdLeaveEarningDetails;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_1_grdLeaveEarningDetails;
		public C1.Win.C1TrueDBGrid.C1TrueDBGrid grdLeaveEarningDetails;
		public AxC1SizerLib.AxC1Elastic frmLeaveEarnings;
		public AxC1SizerLib.AxC1Tab tabLeaveDetails;
		public System.Windows.Forms.RadioButton[] optValidity = new System.Windows.Forms.RadioButton[3];
		public System.Windows.Forms.TextBox[] txtCommonTextBox = new System.Windows.Forms.TextBox[2];
		public System.Windows.Forms.Label[] txtDisplayLabel = new System.Windows.Forms.Label[2];
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPayLeave));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this.Frame2 = new System.Windows.Forms.GroupBox();
			this.txtLeaveDaysAfterSOP = new System.Windows.Forms.TextBox();
			this.System.Windows.Forms.Label2 = new System.Windows.Forms.Label();
			this.System.Windows.Forms.Label3 = new System.Windows.Forms.Label();
			this.txtWDPerMonthAfterSOP = new System.Windows.Forms.TextBox();
			this.Frame1 = new System.Windows.Forms.GroupBox();
			this.txtLeaveDaysBeforeSOP = new System.Windows.Forms.TextBox();
			this.System.Windows.Forms.Label8 = new System.Windows.Forms.Label();
			this.System.Windows.Forms.Label9 = new System.Windows.Forms.Label();
			this.txtWDPerMonthBeforeSOP = new System.Windows.Forms.TextBox();
			this.txtComment = new System.Windows.Forms.TextBox();
			this.chkIncludeInDefaultLeaveTypes = new System.Windows.Forms.CheckBox();
			this.cmdUpdateEmployees = new System.Windows.Forms.Button();
			this.Frame3 = new System.Windows.Forms.GroupBox();
			this._txtCommonTextBox_0 = new System.Windows.Forms.TextBox();
			this._txtDisplayLabel_0 = new System.Windows.Forms.Label();
			this.System.Windows.Forms.Label7 = new System.Windows.Forms.Label();
			this.System.Windows.Forms.Label10 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_1 = new System.Windows.Forms.TextBox();
			this._txtDisplayLabel_1 = new System.Windows.Forms.Label();
			this.chkIncludeWeekend = new System.Windows.Forms.CheckBox();
			this.chkCalcOnCalendarDays = new System.Windows.Forms.CheckBox();
			this.cmbLeaveType = new System.Windows.Forms.ComboBox();
			this.txtLeaveNo = new System.Windows.Forms.TextBox();
			this.lblLeaveName = new System.Windows.Forms.Label();
			this.txtLLeaveName = new System.Windows.Forms.TextBox();
			this.lblALeaveName = new System.Windows.Forms.Label();
			this.txtALeaveName = new System.Windows.Forms.TextBox();
			this.lblComments = new System.Windows.Forms.Label();
			this.lblLeaveNo = new System.Windows.Forms.Label();
			this.System.Windows.Forms.Label6 = new System.Windows.Forms.Label();
			this.System.Windows.Forms.Label1 = new System.Windows.Forms.Label();
			this.System.Windows.Forms.Label4 = new System.Windows.Forms.Label();
			this.cmbDeductUnpaidDays = new System.Windows.Forms.ComboBox();
			this.System.Windows.Forms.Label5 = new System.Windows.Forms.Label();
			this.txtLeaveSwitchOverPeriod = new System.Windows.Forms.TextBox();
			this.System.Windows.Forms.Label11 = new System.Windows.Forms.Label();
			this.cmbDeductPaidDays = new System.Windows.Forms.ComboBox();
			this.cmbDeductAbsentDays = new System.Windows.Forms.ComboBox();
			this.tabLeaveDetails = new AxC1SizerLib.AxC1Tab();
			this.frmvalidityPeriod = new System.Windows.Forms.GroupBox();
			this._optValidity_0 = new System.Windows.Forms.RadioButton();
			this._optValidity_1 = new System.Windows.Forms.RadioButton();
			this._optValidity_2 = new System.Windows.Forms.RadioButton();
			this.cmbMonth = new System.Windows.Forms.ComboBox();
			this.System.Windows.Forms.Label12 = new System.Windows.Forms.Label();
			this.txtEligibilityDays = new System.Windows.Forms.TextBox();
			this.System.Windows.Forms.Label13 = new System.Windows.Forms.Label();
			this.frmLeaveEarnings = new AxC1SizerLib.AxC1Elastic();
			this.cmbMastersList = new C1.Win.C1TrueDBGrid.C1TrueDBDropdown();
			this.Column_0_cmbMastersList = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.Column_1_cmbMastersList = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.grdLeaveEarningDetails = new C1.Win.C1TrueDBGrid.C1TrueDBGrid();
			this.Column_0_grdLeaveEarningDetails = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.Column_1_grdLeaveEarningDetails = new C1.Win.C1TrueDBGrid.C1DataColumn();
			// //((System.ComponentModel.ISupportInitialize) this.frmLeaveEarnings).BeginInit();
			// //((System.ComponentModel.ISupportInitialize) this.tabLeaveDetails).BeginInit();
			this.Frame2.SuspendLayout();
			this.Frame1.SuspendLayout();
			this.Frame3.SuspendLayout();
			this.tabLeaveDetails.SuspendLayout();
			this.frmvalidityPeriod.SuspendLayout();
			this.frmLeaveEarnings.SuspendLayout();
			this.cmbMastersList.SuspendLayout();
			this.grdLeaveEarningDetails.SuspendLayout();
			this.SuspendLayout();
			// 
			// Frame2
			// 
			this.Frame2.AllowDrop = true;
			this.Frame2.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.Frame2.Controls.Add(this.txtLeaveDaysAfterSOP);
			this.Frame2.Controls.Add(this.System.Windows.Forms.Label2);
			this.Frame2.Controls.Add(this.System.Windows.Forms.Label3);
			this.Frame2.Controls.Add(this.txtWDPerMonthAfterSOP);
			this.Frame2.Enabled = true;
			this.Frame2.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Frame2.Location = new System.Drawing.Point(257, 166);
			this.Frame2.Name = "Frame2";
			this.Frame2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Frame2.Size = new System.Drawing.Size(235, 65);
			this.Frame2.TabIndex = 17;
			this.Frame2.Text = " After Switch Over Period ";
			this.Frame2.Visible = true;
			// 
			// txtLeaveDaysAfterSOP
			// 
			this.txtLeaveDaysAfterSOP.AllowDrop = true;
			// this.txtLeaveDaysAfterSOP.DisplayFormat = "####0.000###;;0.000;0.000";
			// this.txtLeaveDaysAfterSOP.Format = "###########0.000";
			this.txtLeaveDaysAfterSOP.Location = new System.Drawing.Point(134, 16);
			// this.txtLeaveDaysAfterSOP.MaxValue = 2147483647;
			// this.txtLeaveDaysAfterSOP.MinValue = 0;
			this.txtLeaveDaysAfterSOP.Name = "txtLeaveDaysAfterSOP";
			this.txtLeaveDaysAfterSOP.Size = new System.Drawing.Size(95, 19);
			this.txtLeaveDaysAfterSOP.TabIndex = 18;
			this.txtLeaveDaysAfterSOP.Text = "0.000";
			// 
			// System.Windows.Forms.Label2
			// 
			this.System.Windows.Forms.Label2.AllowDrop = true;
			this.System.Windows.Forms.Label2.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.System.Windows.Forms.Label2.Caption = "Working Days Per Month";
			this.System.Windows.Forms.Label2.Location = new System.Drawing.Point(12, 39);
			this.System.Windows.Forms.Label2.mLabelId = 1093;
			this.System.Windows.Forms.Label2.Name = "System.Windows.Forms.Label2";
			this.System.Windows.Forms.Label2.Size = new System.Drawing.Size(118, 14);
			this.System.Windows.Forms.Label2.TabIndex = 19;
			// 
			// System.Windows.Forms.Label3
			// 
			this.System.Windows.Forms.Label3.AllowDrop = true;
			this.System.Windows.Forms.Label3.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.System.Windows.Forms.Label3.Caption = "Leave Days";
			this.System.Windows.Forms.Label3.Location = new System.Drawing.Point(12, 18);
			this.System.Windows.Forms.Label3.mLabelId = 369;
			this.System.Windows.Forms.Label3.Name = "System.Windows.Forms.Label3";
			this.System.Windows.Forms.Label3.Size = new System.Drawing.Size(58, 14);
			this.System.Windows.Forms.Label3.TabIndex = 20;
			// 
			// txtWDPerMonthAfterSOP
			// 
			this.txtWDPerMonthAfterSOP.AllowDrop = true;
			// this.txtWDPerMonthAfterSOP.DisplayFormat = "####0.000###;;0.000;0.000";
			// this.txtWDPerMonthAfterSOP.Format = "###########0.000";
			this.txtWDPerMonthAfterSOP.Location = new System.Drawing.Point(134, 37);
			// this.txtWDPerMonthAfterSOP.MaxValue = 2147483647;
			// this.txtWDPerMonthAfterSOP.MinValue = 0;
			this.txtWDPerMonthAfterSOP.Name = "txtWDPerMonthAfterSOP";
			this.txtWDPerMonthAfterSOP.Size = new System.Drawing.Size(95, 19);
			this.txtWDPerMonthAfterSOP.TabIndex = 21;
			this.txtWDPerMonthAfterSOP.Text = "0.000";
			// 
			// Frame1
			// 
			this.Frame1.AllowDrop = true;
			this.Frame1.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.Frame1.Controls.Add(this.txtLeaveDaysBeforeSOP);
			this.Frame1.Controls.Add(this.System.Windows.Forms.Label8);
			this.Frame1.Controls.Add(this.System.Windows.Forms.Label9);
			this.Frame1.Controls.Add(this.txtWDPerMonthBeforeSOP);
			this.Frame1.Enabled = true;
			this.Frame1.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Frame1.Location = new System.Drawing.Point(11, 166);
			this.Frame1.Name = "Frame1";
			this.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Frame1.Size = new System.Drawing.Size(241, 65);
			this.Frame1.TabIndex = 12;
			this.Frame1.Text = " Before Switch Over Period ";
			this.Frame1.Visible = true;
			// 
			// txtLeaveDaysBeforeSOP
			// 
			this.txtLeaveDaysBeforeSOP.AllowDrop = true;
			// this.txtLeaveDaysBeforeSOP.DisplayFormat = "####0.000###;;0.000;0.000";
			// this.txtLeaveDaysBeforeSOP.Format = "###########0.000";
			this.txtLeaveDaysBeforeSOP.Location = new System.Drawing.Point(138, 16);
			// this.txtLeaveDaysBeforeSOP.MaxValue = 2147483647;
			// this.txtLeaveDaysBeforeSOP.MinValue = 0;
			this.txtLeaveDaysBeforeSOP.Name = "txtLeaveDaysBeforeSOP";
			this.txtLeaveDaysBeforeSOP.Size = new System.Drawing.Size(95, 19);
			this.txtLeaveDaysBeforeSOP.TabIndex = 13;
			this.txtLeaveDaysBeforeSOP.Text = "0.000";
			// 
			// System.Windows.Forms.Label8
			// 
			this.System.Windows.Forms.Label8.AllowDrop = true;
			this.System.Windows.Forms.Label8.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.System.Windows.Forms.Label8.Caption = "Working Days Per Month";
			this.System.Windows.Forms.Label8.Location = new System.Drawing.Point(8, 39);
			this.System.Windows.Forms.Label8.mLabelId = 1093;
			this.System.Windows.Forms.Label8.Name = "System.Windows.Forms.Label8";
			this.System.Windows.Forms.Label8.Size = new System.Drawing.Size(118, 14);
			this.System.Windows.Forms.Label8.TabIndex = 14;
			// 
			// System.Windows.Forms.Label9
			// 
			this.System.Windows.Forms.Label9.AllowDrop = true;
			this.System.Windows.Forms.Label9.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.System.Windows.Forms.Label9.Caption = "Leave Days";
			this.System.Windows.Forms.Label9.Location = new System.Drawing.Point(8, 18);
			this.System.Windows.Forms.Label9.mLabelId = 369;
			this.System.Windows.Forms.Label9.Name = "System.Windows.Forms.Label9";
			this.System.Windows.Forms.Label9.Size = new System.Drawing.Size(58, 14);
			this.System.Windows.Forms.Label9.TabIndex = 15;
			// 
			// txtWDPerMonthBeforeSOP
			// 
			this.txtWDPerMonthBeforeSOP.AllowDrop = true;
			// this.txtWDPerMonthBeforeSOP.DisplayFormat = "####0.000###;;0.000;0.000";
			// this.txtWDPerMonthBeforeSOP.Format = "###########0.000";
			this.txtWDPerMonthBeforeSOP.Location = new System.Drawing.Point(138, 37);
			// this.txtWDPerMonthBeforeSOP.MaxValue = 2147483647;
			// this.txtWDPerMonthBeforeSOP.MinValue = 0;
			this.txtWDPerMonthBeforeSOP.Name = "txtWDPerMonthBeforeSOP";
			this.txtWDPerMonthBeforeSOP.Size = new System.Drawing.Size(95, 19);
			this.txtWDPerMonthBeforeSOP.TabIndex = 16;
			this.txtWDPerMonthBeforeSOP.Text = "0.000";
			// 
			// txtComment
			// 
			this.txtComment.AcceptsReturn = true;
			this.txtComment.AllowDrop = true;
			this.txtComment.BackColor = System.Drawing.SystemColors.Window;
			this.txtComment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtComment.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtComment.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtComment.Location = new System.Drawing.Point(143, 292);
			this.txtComment.MaxLength = 100;
			this.txtComment.Multiline = true;
			this.txtComment.Name = "txtComment";
			this.txtComment.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtComment.Size = new System.Drawing.Size(348, 19);
			this.txtComment.TabIndex = 11;
			// 
			// chkIncludeInDefaultLeaveTypes
			// 
			this.chkIncludeInDefaultLeaveTypes.AllowDrop = true;
			this.chkIncludeInDefaultLeaveTypes.Appearance = System.Windows.Forms.Appearance.Normal;
			this.chkIncludeInDefaultLeaveTypes.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.chkIncludeInDefaultLeaveTypes.CausesValidation = true;
			this.chkIncludeInDefaultLeaveTypes.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkIncludeInDefaultLeaveTypes.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this.chkIncludeInDefaultLeaveTypes.Enabled = true;
			this.chkIncludeInDefaultLeaveTypes.ForeColor = System.Drawing.SystemColors.ControlText;
			this.chkIncludeInDefaultLeaveTypes.Location = new System.Drawing.Point(321, 102);
			this.chkIncludeInDefaultLeaveTypes.Name = "chkIncludeInDefaultLeaveTypes";
			this.chkIncludeInDefaultLeaveTypes.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.chkIncludeInDefaultLeaveTypes.Size = new System.Drawing.Size(169, 19);
			this.chkIncludeInDefaultLeaveTypes.TabIndex = 10;
			this.chkIncludeInDefaultLeaveTypes.TabStop = true;
			this.chkIncludeInDefaultLeaveTypes.Text = "Include In Default Leave Types";
			this.chkIncludeInDefaultLeaveTypes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkIncludeInDefaultLeaveTypes.Visible = true;
			// 
			// cmdUpdateEmployees
			// 
			this.cmdUpdateEmployees.AllowDrop = true;
			this.cmdUpdateEmployees.BackColor = System.Drawing.SystemColors.Control;
			this.cmdUpdateEmployees.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdUpdateEmployees.Location = new System.Drawing.Point(381, 520);
			this.cmdUpdateEmployees.Name = "cmdUpdateEmployees";
			this.cmdUpdateEmployees.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdUpdateEmployees.Size = new System.Drawing.Size(109, 25);
			this.cmdUpdateEmployees.TabIndex = 9;
			this.cmdUpdateEmployees.Text = "Update Employees";
			this.cmdUpdateEmployees.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.cmdUpdateEmployees.UseVisualStyleBackColor = false;
			// this.cmdUpdateEmployees.Click += new System.EventHandler(this.cmdUpdateEmployees_Click);
			// 
			// Frame3
			// 
			this.Frame3.AllowDrop = true;
			this.Frame3.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.Frame3.Controls.Add(this._txtCommonTextBox_0);
			this.Frame3.Controls.Add(this._txtDisplayLabel_0);
			this.Frame3.Controls.Add(this.System.Windows.Forms.Label7);
			this.Frame3.Controls.Add(this.System.Windows.Forms.Label10);
			this.Frame3.Controls.Add(this._txtCommonTextBox_1);
			this.Frame3.Controls.Add(this._txtDisplayLabel_1);
			this.Frame3.Enabled = true;
			this.Frame3.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Frame3.Location = new System.Drawing.Point(9, 319);
			this.Frame3.Name = "Frame3";
			this.Frame3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Frame3.Size = new System.Drawing.Size(481, 69);
			this.Frame3.TabIndex = 2;
			this.Frame3.Text = "Related Earning And Deduction";
			this.Frame3.Visible = true;
			// 
			// _txtCommonTextBox_0
			// 
			this._txtCommonTextBox_0.AllowDrop = true;
			this._txtCommonTextBox_0.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_0.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_0.Location = new System.Drawing.Point(138, 22);
			this._txtCommonTextBox_0.MaxLength = 10;
			this._txtCommonTextBox_0.Name = "_txtCommonTextBox_0";
			// this._txtCommonTextBox_0.ShowButton = true;
			this._txtCommonTextBox_0.Size = new System.Drawing.Size(101, 19);
			this._txtCommonTextBox_0.TabIndex = 3;
			this._txtCommonTextBox_0.Text = "";
			// this.this._txtCommonTextBox_0.Watermark = "";
			// this.this._txtCommonTextBox_0.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_0.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _txtDisplayLabel_0
			// 
			this._txtDisplayLabel_0.AllowDrop = true;
			this._txtDisplayLabel_0.Location = new System.Drawing.Point(239, 22);
			this._txtDisplayLabel_0.Name = "_txtDisplayLabel_0";
			this._txtDisplayLabel_0.Size = new System.Drawing.Size(227, 19);
			this._txtDisplayLabel_0.TabIndex = 4;
			this._txtDisplayLabel_0.TabStop = false;
			// 
			// System.Windows.Forms.Label7
			// 
			this.System.Windows.Forms.Label7.AllowDrop = true;
			this.System.Windows.Forms.Label7.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.System.Windows.Forms.Label7.Caption = "Earning";
			this.System.Windows.Forms.Label7.Location = new System.Drawing.Point(10, 25);
			this.System.Windows.Forms.Label7.mLabelId = 1995;
			this.System.Windows.Forms.Label7.Name = "System.Windows.Forms.Label7";
			this.System.Windows.Forms.Label7.Size = new System.Drawing.Size(36, 14);
			this.System.Windows.Forms.Label7.TabIndex = 5;
			// 
			// System.Windows.Forms.Label10
			// 
			this.System.Windows.Forms.Label10.AllowDrop = true;
			this.System.Windows.Forms.Label10.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.System.Windows.Forms.Label10.Caption = "Deduction";
			this.System.Windows.Forms.Label10.Location = new System.Drawing.Point(10, 44);
			this.System.Windows.Forms.Label10.mLabelId = 1997;
			this.System.Windows.Forms.Label10.Name = "System.Windows.Forms.Label10";
			this.System.Windows.Forms.Label10.Size = new System.Drawing.Size(48, 14);
			this.System.Windows.Forms.Label10.TabIndex = 6;
			// 
			// _txtCommonTextBox_1
			// 
			this._txtCommonTextBox_1.AllowDrop = true;
			this._txtCommonTextBox_1.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_1.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_1.Location = new System.Drawing.Point(138, 41);
			this._txtCommonTextBox_1.MaxLength = 10;
			this._txtCommonTextBox_1.Name = "_txtCommonTextBox_1";
			// this._txtCommonTextBox_1.ShowButton = true;
			this._txtCommonTextBox_1.Size = new System.Drawing.Size(101, 19);
			this._txtCommonTextBox_1.TabIndex = 7;
			this._txtCommonTextBox_1.Text = "";
			// this.this._txtCommonTextBox_1.Watermark = "";
			// this.this._txtCommonTextBox_1.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_1.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _txtDisplayLabel_1
			// 
			this._txtDisplayLabel_1.AllowDrop = true;
			this._txtDisplayLabel_1.Location = new System.Drawing.Point(239, 41);
			this._txtDisplayLabel_1.Name = "_txtDisplayLabel_1";
			this._txtDisplayLabel_1.Size = new System.Drawing.Size(227, 19);
			this._txtDisplayLabel_1.TabIndex = 8;
			this._txtDisplayLabel_1.TabStop = false;
			// 
			// chkIncludeWeekend
			// 
			this.chkIncludeWeekend.AllowDrop = true;
			this.chkIncludeWeekend.Appearance = System.Windows.Forms.Appearance.Normal;
			this.chkIncludeWeekend.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.chkIncludeWeekend.CausesValidation = true;
			this.chkIncludeWeekend.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkIncludeWeekend.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this.chkIncludeWeekend.Enabled = true;
			this.chkIncludeWeekend.ForeColor = System.Drawing.SystemColors.ControlText;
			this.chkIncludeWeekend.Location = new System.Drawing.Point(321, 121);
			this.chkIncludeWeekend.Name = "chkIncludeWeekend";
			this.chkIncludeWeekend.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.chkIncludeWeekend.Size = new System.Drawing.Size(169, 19);
			this.chkIncludeWeekend.TabIndex = 1;
			this.chkIncludeWeekend.TabStop = true;
			this.chkIncludeWeekend.Text = "Include Weekends";
			this.chkIncludeWeekend.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkIncludeWeekend.Visible = true;
			// 
			// chkCalcOnCalendarDays
			// 
			this.chkCalcOnCalendarDays.AllowDrop = true;
			this.chkCalcOnCalendarDays.Appearance = System.Windows.Forms.Appearance.Normal;
			this.chkCalcOnCalendarDays.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.chkCalcOnCalendarDays.CausesValidation = true;
			this.chkCalcOnCalendarDays.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkCalcOnCalendarDays.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this.chkCalcOnCalendarDays.Enabled = true;
			this.chkCalcOnCalendarDays.ForeColor = System.Drawing.SystemColors.ControlText;
			this.chkCalcOnCalendarDays.Location = new System.Drawing.Point(321, 142);
			this.chkCalcOnCalendarDays.Name = "chkCalcOnCalendarDays";
			this.chkCalcOnCalendarDays.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.chkCalcOnCalendarDays.Size = new System.Drawing.Size(169, 19);
			this.chkCalcOnCalendarDays.TabIndex = 0;
			this.chkCalcOnCalendarDays.TabStop = true;
			this.chkCalcOnCalendarDays.Text = "Calculate On Calendar Days";
			this.chkCalcOnCalendarDays.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkCalcOnCalendarDays.Visible = true;
			// 
			// cmbLeaveType
			// 
			this.cmbLeaveType.AllowDrop = true;
			this.cmbLeaveType.Location = new System.Drawing.Point(149, 101);
			this.cmbLeaveType.Name = "cmbLeaveType";
			this.cmbLeaveType.Size = new System.Drawing.Size(115, 21);
			this.cmbLeaveType.TabIndex = 22;
			// 
			// txtLeaveNo
			// 
			this.txtLeaveNo.AllowDrop = true;
			this.txtLeaveNo.BackColor = System.Drawing.Color.White;
			// this.txtLeaveNo.bolNumericOnly = true;
			this.txtLeaveNo.ForeColor = System.Drawing.Color.Black;
			this.txtLeaveNo.Location = new System.Drawing.Point(149, 38);
			this.txtLeaveNo.MaxLength = 15;
			// this.txtLeaveNo.mDropDownType = System.Windows.Forms.TextBox.DropDownTypes.ddtNextNumber;
			this.txtLeaveNo.Name = "txtLeaveNo";
			// this.txtLeaveNo.ShowButton = true;
			this.txtLeaveNo.Size = new System.Drawing.Size(101, 19);
			this.txtLeaveNo.TabIndex = 23;
			this.txtLeaveNo.Text = "";
			// this.this.txtLeaveNo.Watermark = "";
			// this.this.txtLeaveNo.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtLeaveNo_DropButtonClick);
			// 
			// lblLeaveName
			// 
			this.lblLeaveName.AllowDrop = true;
			this.lblLeaveName.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblLeaveName.Text = "Leave Name (English)";
			this.lblLeaveName.Location = new System.Drawing.Point(11, 61);
			// this.lblLeaveName.mLabelId = 1125;
			this.lblLeaveName.Name = "lblLeaveName";
			this.lblLeaveName.Size = new System.Drawing.Size(105, 14);
			this.lblLeaveName.TabIndex = 24;
			// 
			// txtLLeaveName
			// 
			this.txtLLeaveName.AllowDrop = true;
			this.txtLLeaveName.BackColor = System.Drawing.Color.White;
			this.txtLLeaveName.ForeColor = System.Drawing.Color.Black;
			this.txtLLeaveName.Location = new System.Drawing.Point(149, 59);
			this.txtLLeaveName.MaxLength = 50;
			this.txtLLeaveName.Name = "txtLLeaveName";
			this.txtLLeaveName.Size = new System.Drawing.Size(201, 19);
			this.txtLLeaveName.TabIndex = 25;
			this.txtLLeaveName.Text = "";
			// this.this.txtLLeaveName.Watermark = "";
			// 
			// lblALeaveName
			// 
			this.lblALeaveName.AllowDrop = true;
			this.lblALeaveName.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblALeaveName.Text = "Leave Name (Arabic)";
			this.lblALeaveName.Location = new System.Drawing.Point(11, 82);
			// this.lblALeaveName.mLabelId = 1126;
			this.lblALeaveName.Name = "lblALeaveName";
			this.lblALeaveName.Size = new System.Drawing.Size(103, 14);
			this.lblALeaveName.TabIndex = 26;
			// 
			// txtALeaveName
			// 
			this.txtALeaveName.AllowDrop = true;
			this.txtALeaveName.BackColor = System.Drawing.Color.White;
			this.txtALeaveName.ForeColor = System.Drawing.Color.Black;
			this.txtALeaveName.Location = new System.Drawing.Point(149, 80);
			// this.txtALeaveName.mArabicEnabled = true;
			this.txtALeaveName.MaxLength = 50;
			this.txtALeaveName.Name = "txtALeaveName";
			this.txtALeaveName.Size = new System.Drawing.Size(201, 19);
			this.txtALeaveName.TabIndex = 27;
			this.txtALeaveName.Text = "";
			// this.this.txtALeaveName.Watermark = "";
			// 
			// lblComments
			// 
			this.lblComments.AllowDrop = true;
			this.lblComments.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblComments.Text = "Comment";
			this.lblComments.Location = new System.Drawing.Point(11, 292);
			// this.lblComments.mLabelId = 1851;
			this.lblComments.Name = "lblComments";
			this.lblComments.Size = new System.Drawing.Size(44, 14);
			this.lblComments.TabIndex = 28;
			// 
			// lblLeaveNo
			// 
			this.lblLeaveNo.AllowDrop = true;
			this.lblLeaveNo.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblLeaveNo.Text = "Leave Code";
			this.lblLeaveNo.Location = new System.Drawing.Point(11, 40);
			// this.lblLeaveNo.mLabelId = 1124;
			this.lblLeaveNo.Name = "lblLeaveNo";
			this.lblLeaveNo.Size = new System.Drawing.Size(58, 14);
			this.lblLeaveNo.TabIndex = 29;
			// 
			// System.Windows.Forms.Label6
			// 
			this.System.Windows.Forms.Label6.AllowDrop = true;
			this.System.Windows.Forms.Label6.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.System.Windows.Forms.Label6.Caption = "Leave Switch Over Period";
			this.System.Windows.Forms.Label6.Location = new System.Drawing.Point(11, 143);
			this.System.Windows.Forms.Label6.mLabelId = 1128;
			this.System.Windows.Forms.Label6.Name = "System.Windows.Forms.Label6";
			this.System.Windows.Forms.Label6.Size = new System.Drawing.Size(127, 14);
			this.System.Windows.Forms.Label6.TabIndex = 30;
			// 
			// System.Windows.Forms.Label1
			// 
			this.System.Windows.Forms.Label1.AllowDrop = true;
			this.System.Windows.Forms.Label1.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.System.Windows.Forms.Label1.Caption = "Leave Type";
			this.System.Windows.Forms.Label1.Location = new System.Drawing.Point(11, 104);
			this.System.Windows.Forms.Label1.mLabelId = 1127;
			this.System.Windows.Forms.Label1.Name = "System.Windows.Forms.Label1";
			this.System.Windows.Forms.Label1.Size = new System.Drawing.Size(57, 14);
			this.System.Windows.Forms.Label1.TabIndex = 31;
			// 
			// System.Windows.Forms.Label4
			// 
			this.System.Windows.Forms.Label4.AllowDrop = true;
			this.System.Windows.Forms.Label4.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.System.Windows.Forms.Label4.Caption = "Deduct Paid Days";
			this.System.Windows.Forms.Label4.Location = new System.Drawing.Point(8, 243);
			this.System.Windows.Forms.Label4.mLabelId = 1089;
			this.System.Windows.Forms.Label4.Name = "System.Windows.Forms.Label4";
			this.System.Windows.Forms.Label4.Size = new System.Drawing.Size(85, 14);
			this.System.Windows.Forms.Label4.TabIndex = 32;
			// 
			// cmbDeductUnpaidDays
			// 
			this.cmbDeductUnpaidDays.AllowDrop = true;
			this.cmbDeductUnpaidDays.Location = new System.Drawing.Point(390, 238);
			this.cmbDeductUnpaidDays.Name = "cmbDeductUnpaidDays";
			this.cmbDeductUnpaidDays.Size = new System.Drawing.Size(99, 21);
			this.cmbDeductUnpaidDays.TabIndex = 33;
			// 
			// System.Windows.Forms.Label5
			// 
			this.System.Windows.Forms.Label5.AllowDrop = true;
			this.System.Windows.Forms.Label5.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.System.Windows.Forms.Label5.Caption = "Deduct Unpaid Days";
			this.System.Windows.Forms.Label5.Location = new System.Drawing.Point(258, 241);
			this.System.Windows.Forms.Label5.mLabelId = 1095;
			this.System.Windows.Forms.Label5.Name = "System.Windows.Forms.Label5";
			this.System.Windows.Forms.Label5.Size = new System.Drawing.Size(98, 14);
			this.System.Windows.Forms.Label5.TabIndex = 34;
			// 
			// txtLeaveSwitchOverPeriod
			// 
			this.txtLeaveSwitchOverPeriod.AllowDrop = true;
			// this.txtLeaveSwitchOverPeriod.DisplayFormat = "####0;;0";
			this.txtLeaveSwitchOverPeriod.Location = new System.Drawing.Point(149, 140);
			// this.txtLeaveSwitchOverPeriod.MaxValue = 2147483647;
			// this.txtLeaveSwitchOverPeriod.MinValue = 0;
			this.txtLeaveSwitchOverPeriod.Name = "txtLeaveSwitchOverPeriod";
			this.txtLeaveSwitchOverPeriod.Size = new System.Drawing.Size(75, 21);
			this.txtLeaveSwitchOverPeriod.TabIndex = 35;
			// 
			// System.Windows.Forms.Label11
			// 
			this.System.Windows.Forms.Label11.AllowDrop = true;
			this.System.Windows.Forms.Label11.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.System.Windows.Forms.Label11.Caption = "Deduct Absent Days";
			this.System.Windows.Forms.Label11.Location = new System.Drawing.Point(8, 266);
			this.System.Windows.Forms.Label11.mLabelId = 2174;
			this.System.Windows.Forms.Label11.Name = "System.Windows.Forms.Label11";
			this.System.Windows.Forms.Label11.Size = new System.Drawing.Size(100, 14);
			this.System.Windows.Forms.Label11.TabIndex = 36;
			// 
			// cmbDeductPaidDays
			// 
			this.cmbDeductPaidDays.AllowDrop = true;
			this.cmbDeductPaidDays.Location = new System.Drawing.Point(143, 240);
			this.cmbDeductPaidDays.Name = "cmbDeductPaidDays";
			this.cmbDeductPaidDays.Size = new System.Drawing.Size(96, 21);
			this.cmbDeductPaidDays.TabIndex = 37;
			// 
			// cmbDeductAbsentDays
			// 
			this.cmbDeductAbsentDays.AllowDrop = true;
			this.cmbDeductAbsentDays.Location = new System.Drawing.Point(143, 263);
			this.cmbDeductAbsentDays.Name = "cmbDeductAbsentDays";
			this.cmbDeductAbsentDays.Size = new System.Drawing.Size(96, 21);
			this.cmbDeductAbsentDays.TabIndex = 38;
			// 
			// tabLeaveDetails
			// 
			this.tabLeaveDetails.Align = C1SizerLib.AlignSettings.asNone;
			this.tabLeaveDetails.AllowDrop = true;
			this.tabLeaveDetails.Controls.Add(this.frmvalidityPeriod);
			this.tabLeaveDetails.Controls.Add(this.frmLeaveEarnings);
			this.tabLeaveDetails.Location = new System.Drawing.Point(8, 392);
			this.tabLeaveDetails.Name = "tabLeaveDetails";
			("tabLeaveDetails.OcxState");
			this.tabLeaveDetails.Size = new System.Drawing.Size(481, 125);
			this.tabLeaveDetails.TabIndex = 39;
			// 
			// frmvalidityPeriod
			// 
			this.frmvalidityPeriod.AllowDrop = true;
			this.frmvalidityPeriod.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.frmvalidityPeriod.Controls.Add(this._optValidity_0);
			this.frmvalidityPeriod.Controls.Add(this._optValidity_1);
			this.frmvalidityPeriod.Controls.Add(this._optValidity_2);
			this.frmvalidityPeriod.Controls.Add(this.cmbMonth);
			this.frmvalidityPeriod.Controls.Add(this.System.Windows.Forms.Label12);
			this.frmvalidityPeriod.Controls.Add(this.txtEligibilityDays);
			this.frmvalidityPeriod.Controls.Add(this.System.Windows.Forms.Label13);
			this.frmvalidityPeriod.Enabled = true;
			this.frmvalidityPeriod.ForeColor = System.Drawing.SystemColors.ControlText;
			this.frmvalidityPeriod.Location = new System.Drawing.Point(1, 23);
			this.frmvalidityPeriod.Name = "frmvalidityPeriod";
			this.frmvalidityPeriod.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.frmvalidityPeriod.Size = new System.Drawing.Size(479, 101);
			this.frmvalidityPeriod.TabIndex = 43;
			this.frmvalidityPeriod.Visible = true;
			// 
			// _optValidity_0
			// 
			this._optValidity_0.AllowDrop = true;
			this._optValidity_0.Appearance = System.Windows.Forms.Appearance.Normal;
			this._optValidity_0.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._optValidity_0.CausesValidation = true;
			this._optValidity_0.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._optValidity_0.Checked = false;
			this._optValidity_0.Enabled = true;
			this._optValidity_0.ForeColor = System.Drawing.Color.Navy;
			this._optValidity_0.Location = new System.Drawing.Point(16, 18);
			this._optValidity_0.Name = "_optValidity_0";
			this._optValidity_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._optValidity_0.Size = new System.Drawing.Size(109, 23);
			this._optValidity_0.TabIndex = 50;
			this._optValidity_0.TabStop = true;
			this._optValidity_0.Text = "Per Fiscal Year";
			this._optValidity_0.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._optValidity_0.Visible = true;
			this._optValidity_0.CheckedChanged += new System.EventHandler(this.optValidity_CheckedChanged);
			// 
			// _optValidity_1
			// 
			this._optValidity_1.AllowDrop = true;
			this._optValidity_1.Appearance = System.Windows.Forms.Appearance.Normal;
			this._optValidity_1.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._optValidity_1.CausesValidation = true;
			this._optValidity_1.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._optValidity_1.Checked = false;
			this._optValidity_1.Enabled = true;
			this._optValidity_1.ForeColor = System.Drawing.Color.Navy;
			this._optValidity_1.Location = new System.Drawing.Point(16, 56);
			this._optValidity_1.Name = "_optValidity_1";
			this._optValidity_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._optValidity_1.Size = new System.Drawing.Size(87, 25);
			this._optValidity_1.TabIndex = 49;
			this._optValidity_1.TabStop = true;
			this._optValidity_1.Text = "Per Year";
			this._optValidity_1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._optValidity_1.Visible = true;
			this._optValidity_1.CheckedChanged += new System.EventHandler(this.optValidity_CheckedChanged);
			// 
			// _optValidity_2
			// 
			this._optValidity_2.AllowDrop = true;
			this._optValidity_2.Appearance = System.Windows.Forms.Appearance.Normal;
			this._optValidity_2.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._optValidity_2.CausesValidation = true;
			this._optValidity_2.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._optValidity_2.Checked = false;
			this._optValidity_2.Enabled = true;
			this._optValidity_2.ForeColor = System.Drawing.Color.Navy;
			this._optValidity_2.Location = new System.Drawing.Point(16, 78);
			this._optValidity_2.Name = "_optValidity_2";
			this._optValidity_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._optValidity_2.Size = new System.Drawing.Size(103, 21);
			this._optValidity_2.TabIndex = 48;
			this._optValidity_2.TabStop = true;
			this._optValidity_2.Text = "Per Employment";
			this._optValidity_2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._optValidity_2.Visible = true;
			this._optValidity_2.CheckedChanged += new System.EventHandler(this.optValidity_CheckedChanged);
			// 
			// cmbMonth
			// 
			this.cmbMonth.AllowDrop = true;
			this.cmbMonth.Location = new System.Drawing.Point(92, 38);
			this.cmbMonth.Name = "cmbMonth";
			this.cmbMonth.Size = new System.Drawing.Size(79, 21);
			this.cmbMonth.TabIndex = 44;
			// 
			// System.Windows.Forms.Label12
			// 
			this.System.Windows.Forms.Label12.AllowDrop = true;
			this.System.Windows.Forms.Label12.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.System.Windows.Forms.Label12.Caption = "Month";
			this.System.Windows.Forms.Label12.Location = new System.Drawing.Point(54, 41);
			this.System.Windows.Forms.Label12.Name = "System.Windows.Forms.Label12";
			this.System.Windows.Forms.Label12.Size = new System.Drawing.Size(29, 14);
			this.System.Windows.Forms.Label12.TabIndex = 45;
			// 
			// txtEligibilityDays
			// 
			this.txtEligibilityDays.AllowDrop = true;
			// this.txtEligibilityDays.DisplayFormat = "####0;;0";
			this.txtEligibilityDays.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtEligibilityDays.Location = new System.Drawing.Point(338, 22);
			this.txtEligibilityDays.Name = "txtEligibilityDays";
			this.txtEligibilityDays.Size = new System.Drawing.Size(95, 21);
			this.txtEligibilityDays.TabIndex = 46;
			// 
			// System.Windows.Forms.Label13
			// 
			this.System.Windows.Forms.Label13.AllowDrop = true;
			this.System.Windows.Forms.Label13.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.System.Windows.Forms.Label13.Caption = "Eligbility Days";
			this.System.Windows.Forms.Label13.Location = new System.Drawing.Point(240, 26);
			this.System.Windows.Forms.Label13.Name = "System.Windows.Forms.Label13";
			this.System.Windows.Forms.Label13.Size = new System.Drawing.Size(65, 14);
			this.System.Windows.Forms.Label13.TabIndex = 47;
			// 
			// frmLeaveEarnings
			// 
			this.frmLeaveEarnings.Align = C1SizerLib.AlignSettings.asNone;
			this.frmLeaveEarnings.AllowDrop = true;
			this.frmLeaveEarnings.Controls.Add(this.cmbMastersList);
			this.frmLeaveEarnings.Controls.Add(this.grdLeaveEarningDetails);
			this.frmLeaveEarnings.Location = new System.Drawing.Point(522, 23);
			this.frmLeaveEarnings.Name = "frmLeaveEarnings";
			("frmLeaveEarnings.OcxState");
			this.frmLeaveEarnings.Size = new System.Drawing.Size(479, 101);
			this.frmLeaveEarnings.TabIndex = 40;
			this.frmLeaveEarnings.TabStop = false;
			// 
			// cmbMastersList
			// 
			this.cmbMastersList.AllowDrop = true;
			this.cmbMastersList.ColumnHeaders = true;
			this.cmbMastersList.Enabled = true;
			this.cmbMastersList.Location = new System.Drawing.Point(16, 120);
			this.cmbMastersList.Name = "cmbMastersList";
			this.cmbMastersList.Size = new System.Drawing.Size(53, 37);
			this.cmbMastersList.TabIndex = 41;
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
			// grdLeaveEarningDetails
			// 
			this.grdLeaveEarningDetails.AllowDrop = true;
			this.grdLeaveEarningDetails.BackColor = System.Drawing.Color.FromArgb(212, 208, 200);
			this.grdLeaveEarningDetails.CellTipsWidth = 0;
			this.grdLeaveEarningDetails.Location = new System.Drawing.Point(0, 0);
			this.grdLeaveEarningDetails.Name = "grdLeaveEarningDetails";
			this.grdLeaveEarningDetails.RowDivider.Color = System.Drawing.Color.FromArgb(212, 208, 200);
			this.grdLeaveEarningDetails.Size = new System.Drawing.Size(477, 99);
			this.grdLeaveEarningDetails.TabIndex = 42;
			this.grdLeaveEarningDetails.Columns.Add(this.Column_0_grdLeaveEarningDetails);
			this.grdLeaveEarningDetails.Columns.Add(this.Column_1_grdLeaveEarningDetails);
			this.grdLeaveEarningDetails.GotFocus += new System.EventHandler(this.grdLeaveEarningDetails_GotFocus);
			this.grdLeaveEarningDetails.RowColChange += new C1.Win.C1TrueDBGrid.RowColChangeEventHandler(this.grdLeaveEarningDetails_RowColChange);
			// 
			// Column_0_grdLeaveEarningDetails
			// 
			this.Column_0_grdLeaveEarningDetails.DataField = "";
			this.Column_0_grdLeaveEarningDetails.ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.Normal;
			// 
			// Column_1_grdLeaveEarningDetails
			// 
			this.Column_1_grdLeaveEarningDetails.DataField = "";
			this.Column_1_grdLeaveEarningDetails.ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.Normal;
			// 
			// frmPayLeave
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.ClientSize = new System.Drawing.Size(890, 684);
			this.Controls.Add(this.Frame2);
			this.Controls.Add(this.Frame1);
			this.Controls.Add(this.txtComment);
			this.Controls.Add(this.chkIncludeInDefaultLeaveTypes);
			this.Controls.Add(this.cmdUpdateEmployees);
			this.Controls.Add(this.Frame3);
			this.Controls.Add(this.chkIncludeWeekend);
			this.Controls.Add(this.chkCalcOnCalendarDays);
			this.Controls.Add(this.cmbLeaveType);
			this.Controls.Add(this.txtLeaveNo);
			this.Controls.Add(this.lblLeaveName);
			this.Controls.Add(this.txtLLeaveName);
			this.Controls.Add(this.lblALeaveName);
			this.Controls.Add(this.txtALeaveName);
			this.Controls.Add(this.lblComments);
			this.Controls.Add(this.lblLeaveNo);
			this.Controls.Add(this.System.Windows.Forms.Label6);
			this.Controls.Add(this.System.Windows.Forms.Label1);
			this.Controls.Add(this.System.Windows.Forms.Label4);
			this.Controls.Add(this.cmbDeductUnpaidDays);
			this.Controls.Add(this.System.Windows.Forms.Label5);
			this.Controls.Add(this.txtLeaveSwitchOverPeriod);
			this.Controls.Add(this.System.Windows.Forms.Label11);
			this.Controls.Add(this.cmbDeductPaidDays);
			this.Controls.Add(this.cmbDeductAbsentDays);
			this.Controls.Add(this.tabLeaveDetails);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			//this.Icon = (System.Drawing.Icon) resources.GetObject("frmPayLeave.Icon");
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(221, 125);
			this.MaximizeBox = true;
			this.MinimizeBox = true;
			this.Name = "frmPayLeave";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Leave";
			// this.Activated += new System.EventHandler(this.frmPayLeave_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
			// this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
			//((System.ComponentModel.ISupportInitialize) this.frmLeaveEarnings).EndInit();
			//((System.ComponentModel.ISupportInitialize) this.tabLeaveDetails).EndInit();
			this.Frame2.ResumeLayout(false);
			this.Frame1.ResumeLayout(false);
			this.Frame3.ResumeLayout(false);
			this.tabLeaveDetails.ResumeLayout(false);
			this.frmvalidityPeriod.ResumeLayout(false);
			this.frmLeaveEarnings.ResumeLayout(false);
			this.cmbMastersList.ResumeLayout(false);
			this.grdLeaveEarningDetails.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		void ReLoadForm(bool addEvents)
		{
			InitializetxtDisplayLabel();
			InitializetxtCommonTextBox();
			InitializeoptValidity();
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
			this.txtDisplayLabel = new System.Windows.Forms.Label[2];
			this.txtDisplayLabel[0] = _txtDisplayLabel_0;
			this.txtDisplayLabel[1] = _txtDisplayLabel_1;
		}
		void InitializetxtCommonTextBox()
		{
			this.txtCommonTextBox = new System.Windows.Forms.TextBox[2];
			this.txtCommonTextBox[0] = _txtCommonTextBox_0;
			this.txtCommonTextBox[1] = _txtCommonTextBox_1;
		}
		void InitializeoptValidity()
		{
			this.optValidity = new System.Windows.Forms.RadioButton[3];
			this.optValidity[0] = _optValidity_0;
			this.optValidity[1] = _optValidity_1;
			this.optValidity[2] = _optValidity_2;
		}
		#endregion
	}
}