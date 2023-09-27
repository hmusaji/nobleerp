
namespace Xtreme
{
	partial class frmPayEmployeePayroll
	{

		#region "Upgrade Support "
		private static frmPayEmployeePayroll m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmPayEmployeePayroll DefInstance
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
		public static frmPayEmployeePayroll CreateInstance()
		{
			frmPayEmployeePayroll theInstance = new frmPayEmployeePayroll();
			
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
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "chkHoldSalary", "chkIncludeInPayslipPrinting", "Label1_9", "_lblCommon_107", "_txtCommonTextBox_2", "_lblCommon_106", "_lblCommon_46", "_cmbCommon_4", "Label1_10", "_txtDisplayLabel_7", "_lblCommon_1", "_cmbCommon_3", "_txtCommonTextBox_3", "_txtDisplayLabel_6", "_txtCommonTextBox_1", "_txtDisplayLabel_8", "_txtCommonTextBox_4", "_lblCommon_2", "_lblCommon_4", "txtAccountNo", "frmBank", "chkMobileAllowance", "_lblCommon_36", "_lblCommon_37", "_lblCommonLabel_2", "_lblCommon_102", "_txtDisplayLabel_5", "_txtDisplayLabel_0", "_txtDisplayLabel_1", "_txtDisplayLabel_2", "_txtDisplayLabel_3", "Frame1", "Label1_4", "_lblCommonLabel_40", "_lblCommonLabel_41", "txtDaysPerMonth", "txtHoursPerDay", "_lblCommon_42", "_cmbCommon_1", "_lblCommonLabel_5", "_cmbCommon_0", "_lblCommonLabel_6", "Label1_7", "_cmbCommon_2", "Label1_8", "_lblCommon_43", "_lblCommon_44", "txtFridayOT", "_lblCommon_45", "txtHolidayOT", "_lblCommon_0", "Label1_0", "txtLastSalaryDate", "_lblCommonLabel_0", "txtRatePerHours", "_txtCommonTextBox_0", "_cmbCommon_6", "txtNormalOT", "_cmbCommon_7", "_cmbCommon_5", "txtMobileAllowance", "txtRatePerDay", "_lblCommonLabel_1", "_lblCommon_3", "txtNGeneralOTAmt", "txtCalendarCd", "txtDlblCalendarName", "lblCalendar", "_lblCommon_5", "txtNOTWorkingHrs", "System.Windows.Forms.Label1", "cmbCommon", "lblCommon", "lblCommonLabel", "txtCommonTextBox", "txtDisplayLabel"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public System.Windows.Forms.CheckBox chkHoldSalary;
		public System.Windows.Forms.CheckBox chkIncludeInPayslipPrinting;
		private System.Windows.Forms.Label Label1_9;
		private System.Windows.Forms.Label _lblCommon_107;
		private System.Windows.Forms.TextBox _txtCommonTextBox_2;
		private System.Windows.Forms.Label _lblCommon_106;
		private System.Windows.Forms.Label _lblCommon_46;
		private System.Windows.Forms.ComboBox _cmbCommon_4;
		private System.Windows.Forms.Label Label1_10;
		private System.Windows.Forms.Label _txtDisplayLabel_7;
		private System.Windows.Forms.Label _lblCommon_1;
		private System.Windows.Forms.ComboBox _cmbCommon_3;
		private System.Windows.Forms.TextBox _txtCommonTextBox_3;
		private System.Windows.Forms.Label _txtDisplayLabel_6;
		private System.Windows.Forms.TextBox _txtCommonTextBox_1;
		private System.Windows.Forms.Label _txtDisplayLabel_8;
		private System.Windows.Forms.TextBox _txtCommonTextBox_4;
		private System.Windows.Forms.Label _lblCommon_2;
		private System.Windows.Forms.Label _lblCommon_4;
		public System.Windows.Forms.TextBox txtAccountNo;
		public System.Windows.Forms.GroupBox frmBank;
		public System.Windows.Forms.CheckBox chkMobileAllowance;
		private System.Windows.Forms.Label _lblCommon_36;
		private System.Windows.Forms.Label _lblCommon_37;
		private System.Windows.Forms.Label _lblCommonLabel_2;
		private System.Windows.Forms.Label _lblCommon_102;
		private System.Windows.Forms.Label _txtDisplayLabel_5;
		private System.Windows.Forms.Label _txtDisplayLabel_0;
		private System.Windows.Forms.Label _txtDisplayLabel_1;
		private System.Windows.Forms.Label _txtDisplayLabel_2;
		private System.Windows.Forms.Label _txtDisplayLabel_3;
		public System.Windows.Forms.GroupBox Frame1;
		private System.Windows.Forms.Label Label1_4;
		private System.Windows.Forms.Label _lblCommonLabel_40;
		private System.Windows.Forms.Label _lblCommonLabel_41;
		public System.Windows.Forms.TextBox txtDaysPerMonth;
		public System.Windows.Forms.TextBox txtHoursPerDay;
		private System.Windows.Forms.Label _lblCommon_42;
		private System.Windows.Forms.ComboBox _cmbCommon_1;
		private System.Windows.Forms.Label _lblCommonLabel_5;
		private System.Windows.Forms.ComboBox _cmbCommon_0;
		private System.Windows.Forms.Label _lblCommonLabel_6;
		private System.Windows.Forms.Label Label1_7;
		private System.Windows.Forms.ComboBox _cmbCommon_2;
		private System.Windows.Forms.Label Label1_8;
		private System.Windows.Forms.Label _lblCommon_43;
		private System.Windows.Forms.Label _lblCommon_44;
		public System.Windows.Forms.TextBox txtFridayOT;
		private System.Windows.Forms.Label _lblCommon_45;
		public System.Windows.Forms.TextBox txtHolidayOT;
		private System.Windows.Forms.Label _lblCommon_0;
		private System.Windows.Forms.Label Label1_0;
		public Syncfusion.WinForms.Input.SfDateTimeEdit txtLastSalaryDate;
		private System.Windows.Forms.Label _lblCommonLabel_0;
		public System.Windows.Forms.TextBox txtRatePerHours;
		private System.Windows.Forms.TextBox _txtCommonTextBox_0;
		private System.Windows.Forms.ComboBox _cmbCommon_6;
		public System.Windows.Forms.TextBox txtNormalOT;
		private System.Windows.Forms.ComboBox _cmbCommon_7;
		private System.Windows.Forms.ComboBox _cmbCommon_5;
		public System.Windows.Forms.TextBox txtMobileAllowance;
		public System.Windows.Forms.TextBox txtRatePerDay;
		private System.Windows.Forms.Label _lblCommonLabel_1;
		private System.Windows.Forms.Label _lblCommon_3;
		public System.Windows.Forms.TextBox txtNGeneralOTAmt;
		public System.Windows.Forms.TextBox txtCalendarCd;
		public System.Windows.Forms.Label txtDlblCalendarName;
		public System.Windows.Forms.Label lblCalendar;
		private System.Windows.Forms.Label _lblCommon_5;
		public System.Windows.Forms.TextBox txtNOTWorkingHrs;
		public System.Windows.Forms.Label[] Label1 = new System.Windows.Forms.Label[11];
		public System.Windows.Forms.ComboBox[] cmbCommon = new System.Windows.Forms.ComboBox[8];
		public System.Windows.Forms.Label[] lblCommon = new System.Windows.Forms.Label[108];
		public System.Windows.Forms.Label[] lblCommonLabel = new System.Windows.Forms.Label[42];
		public System.Windows.Forms.TextBox[] txtCommonTextBox = new System.Windows.Forms.TextBox[5];
		public System.Windows.Forms.Label[] txtDisplayLabel = new System.Windows.Forms.Label[9];
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPayEmployeePayroll));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this.frmBank = new System.Windows.Forms.GroupBox();
			this.chkHoldSalary = new System.Windows.Forms.CheckBox();
			this.chkIncludeInPayslipPrinting = new System.Windows.Forms.CheckBox();
			this.Label1_9 = new System.Windows.Forms.Label();
			this._lblCommon_107 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_2 = new System.Windows.Forms.TextBox();
			this._lblCommon_106 = new System.Windows.Forms.Label();
			this._lblCommon_46 = new System.Windows.Forms.Label();
			this._cmbCommon_4 = new System.Windows.Forms.ComboBox();
			this.Label1_10 = new System.Windows.Forms.Label();
			this._txtDisplayLabel_7 = new System.Windows.Forms.Label();
			this._lblCommon_1 = new System.Windows.Forms.Label();
			this._cmbCommon_3 = new System.Windows.Forms.ComboBox();
			this._txtCommonTextBox_3 = new System.Windows.Forms.TextBox();
			this._txtDisplayLabel_6 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_1 = new System.Windows.Forms.TextBox();
			this._txtDisplayLabel_8 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_4 = new System.Windows.Forms.TextBox();
			this._lblCommon_2 = new System.Windows.Forms.Label();
			this._lblCommon_4 = new System.Windows.Forms.Label();
			this.txtAccountNo = new System.Windows.Forms.TextBox();
			this.chkMobileAllowance = new System.Windows.Forms.CheckBox();
			this.Frame1 = new System.Windows.Forms.GroupBox();
			this._lblCommon_36 = new System.Windows.Forms.Label();
			this._lblCommon_37 = new System.Windows.Forms.Label();
			this._lblCommonLabel_2 = new System.Windows.Forms.Label();
			this._lblCommon_102 = new System.Windows.Forms.Label();
			this._txtDisplayLabel_5 = new System.Windows.Forms.Label();
			this._txtDisplayLabel_0 = new System.Windows.Forms.Label();
			this._txtDisplayLabel_1 = new System.Windows.Forms.Label();
			this._txtDisplayLabel_2 = new System.Windows.Forms.Label();
			this._txtDisplayLabel_3 = new System.Windows.Forms.Label();
			this.Label1_4 = new System.Windows.Forms.Label();
			this._lblCommonLabel_40 = new System.Windows.Forms.Label();
			this._lblCommonLabel_41 = new System.Windows.Forms.Label();
			this.txtDaysPerMonth = new System.Windows.Forms.TextBox();
			this.txtHoursPerDay = new System.Windows.Forms.TextBox();
			this._lblCommon_42 = new System.Windows.Forms.Label();
			this._cmbCommon_1 = new System.Windows.Forms.ComboBox();
			this._lblCommonLabel_5 = new System.Windows.Forms.Label();
			this._cmbCommon_0 = new System.Windows.Forms.ComboBox();
			this._lblCommonLabel_6 = new System.Windows.Forms.Label();
			this.Label1_7 = new System.Windows.Forms.Label();
			this._cmbCommon_2 = new System.Windows.Forms.ComboBox();
			this.Label1_8 = new System.Windows.Forms.Label();
			this._lblCommon_43 = new System.Windows.Forms.Label();
			this._lblCommon_44 = new System.Windows.Forms.Label();
			this.txtFridayOT = new System.Windows.Forms.TextBox();
			this._lblCommon_45 = new System.Windows.Forms.Label();
			this.txtHolidayOT = new System.Windows.Forms.TextBox();
			this._lblCommon_0 = new System.Windows.Forms.Label();
			this.Label1_0 = new System.Windows.Forms.Label();
			this.txtLastSalaryDate = new Syncfusion.WinForms.Input.SfDateTimeEdit();
			this._lblCommonLabel_0 = new System.Windows.Forms.Label();
			this.txtRatePerHours = new System.Windows.Forms.TextBox();
			this._txtCommonTextBox_0 = new System.Windows.Forms.TextBox();
			this._cmbCommon_6 = new System.Windows.Forms.ComboBox();
			this.txtNormalOT = new System.Windows.Forms.TextBox();
			this._cmbCommon_7 = new System.Windows.Forms.ComboBox();
			this._cmbCommon_5 = new System.Windows.Forms.ComboBox();
			this.txtMobileAllowance = new System.Windows.Forms.TextBox();
			this.txtRatePerDay = new System.Windows.Forms.TextBox();
			this._lblCommonLabel_1 = new System.Windows.Forms.Label();
			this._lblCommon_3 = new System.Windows.Forms.Label();
			this.txtNGeneralOTAmt = new System.Windows.Forms.TextBox();
			this.txtCalendarCd = new System.Windows.Forms.TextBox();
			this.txtDlblCalendarName = new System.Windows.Forms.Label();
			this.lblCalendar = new System.Windows.Forms.Label();
			this._lblCommon_5 = new System.Windows.Forms.Label();
			this.txtNOTWorkingHrs = new System.Windows.Forms.TextBox();
			//this.frmBank.SuspendLayout();
			//this.Frame1.SuspendLayout();
			this.SuspendLayout();
			// 
			// frmBank
			// 
			//this.frmBank.AllowDrop = true;
			this.frmBank.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.frmBank.Controls.Add(this.chkHoldSalary);
			this.frmBank.Controls.Add(this.chkIncludeInPayslipPrinting);
			this.frmBank.Controls.Add(this.Label1_9);
			this.frmBank.Controls.Add(this._lblCommon_107);
			this.frmBank.Controls.Add(this._txtCommonTextBox_2);
			this.frmBank.Controls.Add(this._lblCommon_106);
			this.frmBank.Controls.Add(this._lblCommon_46);
			this.frmBank.Controls.Add(this._cmbCommon_4);
			this.frmBank.Controls.Add(this.Label1_10);
			this.frmBank.Controls.Add(this._txtDisplayLabel_7);
			this.frmBank.Controls.Add(this._lblCommon_1);
			this.frmBank.Controls.Add(this._cmbCommon_3);
			this.frmBank.Controls.Add(this._txtCommonTextBox_3);
			this.frmBank.Controls.Add(this._txtDisplayLabel_6);
			this.frmBank.Controls.Add(this._txtCommonTextBox_1);
			this.frmBank.Controls.Add(this._txtDisplayLabel_8);
			this.frmBank.Controls.Add(this._txtCommonTextBox_4);
			this.frmBank.Controls.Add(this._lblCommon_2);
			this.frmBank.Controls.Add(this._lblCommon_4);
			this.frmBank.Controls.Add(this.txtAccountNo);
			this.frmBank.Enabled = true;
			this.frmBank.ForeColor = System.Drawing.Color.Navy;
			this.frmBank.Location = new System.Drawing.Point(6, 226);
			this.frmBank.Name = "frmBank";
			this.frmBank.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.frmBank.Size = new System.Drawing.Size(739, 103);
			this.frmBank.TabIndex = 51;
			this.frmBank.Text = "Bank Details";
			this.frmBank.Visible = true;
			// 
			// chkHoldSalary
			// 
			//this.chkHoldSalary.AllowDrop = true;
			this.chkHoldSalary.Appearance = System.Windows.Forms.Appearance.Normal;
			this.chkHoldSalary.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.chkHoldSalary.CausesValidation = true;
			this.chkHoldSalary.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkHoldSalary.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this.chkHoldSalary.Enabled = true;
			this.chkHoldSalary.ForeColor = System.Drawing.Color.Navy;
			this.chkHoldSalary.Location = new System.Drawing.Point(384, 80);
			this.chkHoldSalary.Name = "chkHoldSalary";
			this.chkHoldSalary.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.chkHoldSalary.Size = new System.Drawing.Size(199, 13);
			this.chkHoldSalary.TabIndex = 24;
			this.chkHoldSalary.TabStop = true;
			this.chkHoldSalary.Text = "Exclude In Bank Transfer Report";
			this.chkHoldSalary.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkHoldSalary.Visible = true;
			// 
			// chkIncludeInPayslipPrinting
			// 
			//this.chkIncludeInPayslipPrinting.AllowDrop = true;
			this.chkIncludeInPayslipPrinting.Appearance = System.Windows.Forms.Appearance.Normal;
			this.chkIncludeInPayslipPrinting.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.chkIncludeInPayslipPrinting.CausesValidation = true;
			this.chkIncludeInPayslipPrinting.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkIncludeInPayslipPrinting.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this.chkIncludeInPayslipPrinting.Enabled = true;
			this.chkIncludeInPayslipPrinting.ForeColor = System.Drawing.SystemColors.ControlText;
			this.chkIncludeInPayslipPrinting.Location = new System.Drawing.Point(205, 13);
			this.chkIncludeInPayslipPrinting.Name = "chkIncludeInPayslipPrinting";
			this.chkIncludeInPayslipPrinting.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.chkIncludeInPayslipPrinting.Size = new System.Drawing.Size(141, 19);
			this.chkIncludeInPayslipPrinting.TabIndex = 18;
			this.chkIncludeInPayslipPrinting.TabStop = true;
			this.chkIncludeInPayslipPrinting.Text = "Include In Payslip Printing";
			this.chkIncludeInPayslipPrinting.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkIncludeInPayslipPrinting.Visible = true;
			// 
			// Label1_9
			// 
			//this.Label1_9.AllowDrop = true;
			this.Label1_9.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.Label1_9.Text = "Payment Type";
			this.Label1_9.Location = new System.Drawing.Point(3, 14);
			// this.Label1_9.mLabelId = 1111;
			this.Label1_9.Name = "Label1_9";
			this.Label1_9.Size = new System.Drawing.Size(68, 14);
			this.Label1_9.TabIndex = 52;
			// 
			// _lblCommon_107
			// 
			//this._lblCommon_107.AllowDrop = true;
			this._lblCommon_107.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_107.Text = "Bank";
			this._lblCommon_107.Location = new System.Drawing.Point(3, 35);
			// // this._lblCommon_107.mLabelId = 1980;
			this._lblCommon_107.Name = "_lblCommon_107";
			this._lblCommon_107.Size = new System.Drawing.Size(24, 14);
			this._lblCommon_107.TabIndex = 53;
			// 
			// _txtCommonTextBox_2
			// 
			//this._txtCommonTextBox_2.AllowDrop = true;
			this._txtCommonTextBox_2.BackColor = System.Drawing.Color.White;
			// this._txtCommonTextBox_2.bolNumericOnly = true;
			this._txtCommonTextBox_2.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_2.Location = new System.Drawing.Point(455, 34);
			this._txtCommonTextBox_2.MaxLength = 4;
			this._txtCommonTextBox_2.Name = "_txtCommonTextBox_2";
			// this._txtCommonTextBox_2.ShowButton = true;
			this._txtCommonTextBox_2.Size = new System.Drawing.Size(101, 19);
			this._txtCommonTextBox_2.TabIndex = 22;
			this._txtCommonTextBox_2.Text = "";
			// this.// = "";
			// this.this._txtCommonTextBox_2.Change += new System.Windows.Forms.TextBox.ChangeHandler(this.txtCommonTextBox_Change);
			// this.//this._txtCommonTextBox_2.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(//this.txtCommonTextBox_DropButtonClick);
			// this.this._txtCommonTextBox_2.KeyPress += new System.Windows.Forms.TextBox.KeyPressHandler(this.txtCommonTextBox_KeyPress);
			// this._txtCommonTextBox_2.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _lblCommon_106
			// 
			//this._lblCommon_106.AllowDrop = true;
			this._lblCommon_106.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_106.Text = "Bank Branch";
			this._lblCommon_106.Location = new System.Drawing.Point(383, 36);
			// // this._lblCommon_106.mLabelId = 86;
			this._lblCommon_106.Name = "_lblCommon_106";
			this._lblCommon_106.Size = new System.Drawing.Size(62, 14);
			this._lblCommon_106.TabIndex = 54;
			// 
			// _lblCommon_46
			// 
			//this._lblCommon_46.AllowDrop = true;
			this._lblCommon_46.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_46.Text = "Account No.";
			this._lblCommon_46.Location = new System.Drawing.Point(384, 59);
			// // this._lblCommon_46.mLabelId = 1978;
			this._lblCommon_46.Name = "_lblCommon_46";
			this._lblCommon_46.Size = new System.Drawing.Size(59, 13);
			this._lblCommon_46.TabIndex = 55;
			// 
			// _cmbCommon_4
			// 
			//this._cmbCommon_4.AllowDrop = true;
			this._cmbCommon_4.Location = new System.Drawing.Point(632, 55);
			this._cmbCommon_4.Name = "_cmbCommon_4";
			this._cmbCommon_4.Size = new System.Drawing.Size(100, 21);
			this._cmbCommon_4.TabIndex = 23;
			// this._cmbCommon_4.Click += new System.Windows.Forms.ComboBox.ClickHandler(this.cmbCommon_Click);
			// 
			// Label1_10
			// 
			//this.Label1_10.AllowDrop = true;
			this.Label1_10.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.Label1_10.Text = "Account Type";
			this.Label1_10.Location = new System.Drawing.Point(560, 58);
			// this.Label1_10.mLabelId = 1115;
			this.Label1_10.Name = "Label1_10";
			this.Label1_10.Size = new System.Drawing.Size(68, 14);
			this.Label1_10.TabIndex = 56;
			// 
			// _txtDisplayLabel_7
			// 
			//this._txtDisplayLabel_7.AllowDrop = true;
			this._txtDisplayLabel_7.Location = new System.Drawing.Point(559, 34);
			this._txtDisplayLabel_7.Name = "_txtDisplayLabel_7";
			this._txtDisplayLabel_7.Size = new System.Drawing.Size(173, 19);
			this._txtDisplayLabel_7.TabIndex = 57;
			this._txtDisplayLabel_7.TabStop = false;
			// 
			// _lblCommon_1
			// 
			//this._lblCommon_1.AllowDrop = true;
			this._lblCommon_1.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_1.Text = "Transfer To Bank";
			this._lblCommon_1.Location = new System.Drawing.Point(3, 79);
			// // this._lblCommon_1.mLabelId = 1960;
			this._lblCommon_1.Name = "_lblCommon_1";
			this._lblCommon_1.Size = new System.Drawing.Size(84, 14);
			this._lblCommon_1.TabIndex = 58;
			// 
			// _cmbCommon_3
			// 
			//this._cmbCommon_3.AllowDrop = true;
			this._cmbCommon_3.Location = new System.Drawing.Point(99, 12);
			this._cmbCommon_3.Name = "_cmbCommon_3";
			this._cmbCommon_3.Size = new System.Drawing.Size(101, 21);
			this._cmbCommon_3.TabIndex = 17;
			// this._cmbCommon_3.Click += new System.Windows.Forms.ComboBox.ClickHandler(this.cmbCommon_Click);
			// 
			// _txtCommonTextBox_3
			// 
			//this._txtCommonTextBox_3.AllowDrop = true;
			this._txtCommonTextBox_3.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_3.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_3.Location = new System.Drawing.Point(99, 56);
			this._txtCommonTextBox_3.Name = "_txtCommonTextBox_3";
			this._txtCommonTextBox_3.Size = new System.Drawing.Size(276, 19);
			this._txtCommonTextBox_3.TabIndex = 20;
			this._txtCommonTextBox_3.Text = "";
			// this.// = "";
			// this.this._txtCommonTextBox_3.Change += new System.Windows.Forms.TextBox.ChangeHandler(this.txtCommonTextBox_Change);
			// this.//this._txtCommonTextBox_3.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(//this.txtCommonTextBox_DropButtonClick);
			// this.this._txtCommonTextBox_3.KeyPress += new System.Windows.Forms.TextBox.KeyPressHandler(this.txtCommonTextBox_KeyPress);
			// this._txtCommonTextBox_3.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _txtDisplayLabel_6
			// 
			//this._txtDisplayLabel_6.AllowDrop = true;
			this._txtDisplayLabel_6.Location = new System.Drawing.Point(202, 35);
			this._txtDisplayLabel_6.Name = "_txtDisplayLabel_6";
			this._txtDisplayLabel_6.Size = new System.Drawing.Size(173, 19);
			this._txtDisplayLabel_6.TabIndex = 59;
			this._txtDisplayLabel_6.TabStop = false;
			// 
			// _txtCommonTextBox_1
			// 
			//this._txtCommonTextBox_1.AllowDrop = true;
			this._txtCommonTextBox_1.BackColor = System.Drawing.Color.White;
			// this._txtCommonTextBox_1.bolNumericOnly = true;
			this._txtCommonTextBox_1.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_1.Location = new System.Drawing.Point(99, 35);
			this._txtCommonTextBox_1.MaxLength = 4;
			this._txtCommonTextBox_1.Name = "_txtCommonTextBox_1";
			// this._txtCommonTextBox_1.ShowButton = true;
			this._txtCommonTextBox_1.Size = new System.Drawing.Size(101, 19);
			this._txtCommonTextBox_1.TabIndex = 19;
			this._txtCommonTextBox_1.Text = "";
			// this.// = "";
			// this.this._txtCommonTextBox_1.Change += new System.Windows.Forms.TextBox.ChangeHandler(this.txtCommonTextBox_Change);
			// this.//this._txtCommonTextBox_1.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(//this.txtCommonTextBox_DropButtonClick);
			// this.this._txtCommonTextBox_1.KeyPress += new System.Windows.Forms.TextBox.KeyPressHandler(this.txtCommonTextBox_KeyPress);
			// this._txtCommonTextBox_1.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _txtDisplayLabel_8
			// 
			//this._txtDisplayLabel_8.AllowDrop = true;
			this._txtDisplayLabel_8.Location = new System.Drawing.Point(202, 77);
			this._txtDisplayLabel_8.Name = "_txtDisplayLabel_8";
			this._txtDisplayLabel_8.Size = new System.Drawing.Size(173, 19);
			this._txtDisplayLabel_8.TabIndex = 60;
			this._txtDisplayLabel_8.TabStop = false;
			// 
			// _txtCommonTextBox_4
			// 
			//this._txtCommonTextBox_4.AllowDrop = true;
			this._txtCommonTextBox_4.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_4.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_4.Location = new System.Drawing.Point(99, 77);
			this._txtCommonTextBox_4.MaxLength = 100;
			this._txtCommonTextBox_4.Name = "_txtCommonTextBox_4";
			// this._txtCommonTextBox_4.ShowButton = true;
			this._txtCommonTextBox_4.Size = new System.Drawing.Size(101, 19);
			this._txtCommonTextBox_4.TabIndex = 21;
			this._txtCommonTextBox_4.Text = "";
			// this.// = "";
			// this.this._txtCommonTextBox_4.Change += new System.Windows.Forms.TextBox.ChangeHandler(this.txtCommonTextBox_Change);
			// this.//this._txtCommonTextBox_4.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(//this.txtCommonTextBox_DropButtonClick);
			// this.this._txtCommonTextBox_4.KeyPress += new System.Windows.Forms.TextBox.KeyPressHandler(this.txtCommonTextBox_KeyPress);
			// this._txtCommonTextBox_4.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _lblCommon_2
			// 
			//this._lblCommon_2.AllowDrop = true;
			this._lblCommon_2.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_2.Text = "Mobile Allow. Amt.";
			this._lblCommon_2.Location = new System.Drawing.Point(629, 81);
			this._lblCommon_2.Name = "_lblCommon_2";
			this._lblCommon_2.Size = new System.Drawing.Size(88, 13);
			this._lblCommon_2.TabIndex = 61;
			this._lblCommon_2.Visible = false;
			// 
			// _lblCommon_4
			// 
			//this._lblCommon_4.AllowDrop = true;
			this._lblCommon_4.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_4.Text = "IBAN No.";
			this._lblCommon_4.Location = new System.Drawing.Point(3, 57);
			// // this._lblCommon_4.mLabelId = 2236;
			this._lblCommon_4.Name = "_lblCommon_4";
			this._lblCommon_4.Size = new System.Drawing.Size(44, 13);
			this._lblCommon_4.TabIndex = 66;
			// 
			// txtAccountNo
			// 
			//this.txtAccountNo.AllowDrop = true;
			this.txtAccountNo.BackColor = System.Drawing.Color.White;
			// // = false;
			this.txtAccountNo.ForeColor = System.Drawing.Color.Black;
			this.txtAccountNo.Location = new System.Drawing.Point(456, 56);
			// // = (System.Windows.Forms.TextBox.DropDownTypes) 0;
			this.txtAccountNo.Name = "txtAccountNo";
			this.txtAccountNo.Size = new System.Drawing.Size(100, 19);
			this.txtAccountNo.TabIndex = 67;
			this.txtAccountNo.Text = "";
			// this.// = "";
			// 
			// chkMobileAllowance
			// 
			//this.chkMobileAllowance.AllowDrop = true;
			this.chkMobileAllowance.Appearance = System.Windows.Forms.Appearance.Normal;
			this.chkMobileAllowance.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.chkMobileAllowance.CausesValidation = true;
			this.chkMobileAllowance.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkMobileAllowance.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this.chkMobileAllowance.Enabled = true;
			this.chkMobileAllowance.ForeColor = System.Drawing.SystemColors.ControlText;
			this.chkMobileAllowance.Location = new System.Drawing.Point(598, 266);
			this.chkMobileAllowance.Name = "chkMobileAllowance";
			this.chkMobileAllowance.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.chkMobileAllowance.Size = new System.Drawing.Size(111, 19);
			this.chkMobileAllowance.TabIndex = 25;
			this.chkMobileAllowance.TabStop = true;
			this.chkMobileAllowance.Text = "Mobile Allowance?";
			this.chkMobileAllowance.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkMobileAllowance.Visible = false;
			//this.chkMobileAllowance.CheckStateChanged += new System.EventHandler(this.chkMobileAllowance_CheckStateChanged);
			// 
			// Frame1
			// 
			//this.Frame1.AllowDrop = true;
			this.Frame1.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.Frame1.Controls.Add(this._lblCommon_36);
			this.Frame1.Controls.Add(this._lblCommon_37);
			this.Frame1.Controls.Add(this._lblCommonLabel_2);
			this.Frame1.Controls.Add(this._lblCommon_102);
			this.Frame1.Controls.Add(this._txtDisplayLabel_5);
			this.Frame1.Controls.Add(this._txtDisplayLabel_0);
			this.Frame1.Controls.Add(this._txtDisplayLabel_1);
			this.Frame1.Controls.Add(this._txtDisplayLabel_2);
			this.Frame1.Controls.Add(this._txtDisplayLabel_3);
			this.Frame1.Enabled = true;
			this.Frame1.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Frame1.Location = new System.Drawing.Point(7, 42);
			this.Frame1.Name = "Frame1";
			this.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Frame1.Size = new System.Drawing.Size(729, 41);
			this.Frame1.TabIndex = 38;
			this.Frame1.Visible = true;
			// 
			// _lblCommon_36
			// 
			//this._lblCommon_36.AllowDrop = true;
			this._lblCommon_36.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_36.Text = "Basic Salary";
			this._lblCommon_36.Location = new System.Drawing.Point(10, 38);
			// // this._lblCommon_36.mLabelId = 1970;
			this._lblCommon_36.Name = "_lblCommon_36";
			this._lblCommon_36.Size = new System.Drawing.Size(57, 13);
			this._lblCommon_36.TabIndex = 39;
			this._lblCommon_36.Visible = false;
			// 
			// _lblCommon_37
			// 
			//this._lblCommon_37.AllowDrop = true;
			this._lblCommon_37.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_37.Text = "Total Salary";
			this._lblCommon_37.Location = new System.Drawing.Point(266, 38);
			// // this._lblCommon_37.mLabelId = 818;
			this._lblCommon_37.Name = "_lblCommon_37";
			this._lblCommon_37.Size = new System.Drawing.Size(57, 13);
			this._lblCommon_37.TabIndex = 40;
			this._lblCommon_37.Visible = false;
			// 
			// _lblCommonLabel_2
			// 
			//this._lblCommonLabel_2.AllowDrop = true;
			this._lblCommonLabel_2.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_2.Text = "Employee Code";
			this._lblCommonLabel_2.Location = new System.Drawing.Point(10, 16);
			// // this._lblCommonLabel_2.mLabelId = 236;
			this._lblCommonLabel_2.Name = "_lblCommonLabel_2";
			this._lblCommonLabel_2.Size = new System.Drawing.Size(74, 14);
			this._lblCommonLabel_2.TabIndex = 41;
			// 
			// _lblCommon_102
			// 
			//this._lblCommon_102.AllowDrop = true;
			this._lblCommon_102.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_102.Text = "Status";
			this._lblCommon_102.Location = new System.Drawing.Point(520, 17);
			// // this._lblCommon_102.mLabelId = 1834;
			this._lblCommon_102.Name = "_lblCommon_102";
			this._lblCommon_102.Size = new System.Drawing.Size(31, 14);
			this._lblCommon_102.TabIndex = 42;
			// 
			// _txtDisplayLabel_5
			// 
			//this._txtDisplayLabel_5.AllowDrop = true;
			this._txtDisplayLabel_5.Location = new System.Drawing.Point(622, 14);
			this._txtDisplayLabel_5.Name = "_txtDisplayLabel_5";
			this._txtDisplayLabel_5.Size = new System.Drawing.Size(101, 19);
			this._txtDisplayLabel_5.TabIndex = 45;
			this._txtDisplayLabel_5.TabStop = false;
			// 
			// _txtDisplayLabel_0
			// 
			//this._txtDisplayLabel_0.AllowDrop = true;
			this._txtDisplayLabel_0.Location = new System.Drawing.Point(102, 14);
			this._txtDisplayLabel_0.Name = "_txtDisplayLabel_0";
			this._txtDisplayLabel_0.Size = new System.Drawing.Size(101, 19);
			this._txtDisplayLabel_0.TabIndex = 46;
			this._txtDisplayLabel_0.TabStop = false;
			// 
			// _txtDisplayLabel_1
			// 
			//this._txtDisplayLabel_1.AllowDrop = true;
			this._txtDisplayLabel_1.Location = new System.Drawing.Point(205, 14);
			this._txtDisplayLabel_1.Name = "_txtDisplayLabel_1";
			this._txtDisplayLabel_1.Size = new System.Drawing.Size(247, 19);
			this._txtDisplayLabel_1.TabIndex = 47;
			this._txtDisplayLabel_1.TabStop = false;
			// 
			// _txtDisplayLabel_2
			// 
			//this._txtDisplayLabel_2.AllowDrop = true;
			this._txtDisplayLabel_2.Location = new System.Drawing.Point(102, 35);
			this._txtDisplayLabel_2.Name = "_txtDisplayLabel_2";
			this._txtDisplayLabel_2.Size = new System.Drawing.Size(101, 19);
			this._txtDisplayLabel_2.TabIndex = 48;
			this._txtDisplayLabel_2.Visible = false;
			// 
			// _txtDisplayLabel_3
			// 
			//this._txtDisplayLabel_3.AllowDrop = true;
			this._txtDisplayLabel_3.Location = new System.Drawing.Point(351, 35);
			this._txtDisplayLabel_3.Name = "_txtDisplayLabel_3";
			this._txtDisplayLabel_3.Size = new System.Drawing.Size(101, 19);
			this._txtDisplayLabel_3.TabIndex = 49;
			this._txtDisplayLabel_3.Visible = false;
			// 
			// Label1_4
			// 
			//this.Label1_4.AllowDrop = true;
			this.Label1_4.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.Label1_4.Text = "Payroll Employee";
			this.Label1_4.Location = new System.Drawing.Point(6, 114);
			// this.Label1_4.mLabelId = 1107;
			this.Label1_4.Name = "Label1_4";
			this.Label1_4.Size = new System.Drawing.Size(81, 14);
			this.Label1_4.TabIndex = 27;
			// 
			// _lblCommonLabel_40
			// 
			//this._lblCommonLabel_40.AllowDrop = true;
			this._lblCommonLabel_40.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_40.Text = "Days Per Month";
			this._lblCommonLabel_40.Location = new System.Drawing.Point(234, 89);
			// // this._lblCommonLabel_40.mLabelId = 1112;
			this._lblCommonLabel_40.Name = "_lblCommonLabel_40";
			this._lblCommonLabel_40.Size = new System.Drawing.Size(76, 13);
			this._lblCommonLabel_40.TabIndex = 28;
			// 
			// _lblCommonLabel_41
			// 
			//this._lblCommonLabel_41.AllowDrop = true;
			this._lblCommonLabel_41.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_41.Text = "Hours Per Day";
			this._lblCommonLabel_41.Location = new System.Drawing.Point(518, 91);
			// // this._lblCommonLabel_41.mLabelId = 1116;
			this._lblCommonLabel_41.Name = "_lblCommonLabel_41";
			this._lblCommonLabel_41.Size = new System.Drawing.Size(69, 13);
			this._lblCommonLabel_41.TabIndex = 29;
			// 
			// txtDaysPerMonth
			// 
			//this.txtDaysPerMonth.AllowDrop = true;
			// this.txtDaysPerMonth.DisplayFormat = "####0.000###;;0.000;0.000";
			// this.txtDaysPerMonth.Format = "###########0.000";
			this.txtDaysPerMonth.Location = new System.Drawing.Point(350, 88);
			// // = 2147483647;
			// // = 0;
			this.txtDaysPerMonth.Name = "txtDaysPerMonth";
			this.txtDaysPerMonth.Size = new System.Drawing.Size(101, 19);
			this.txtDaysPerMonth.TabIndex = 1;
			this.txtDaysPerMonth.Text = "0.000";
			// 
			// txtHoursPerDay
			// 
			//this.txtHoursPerDay.AllowDrop = true;
			// this.txtHoursPerDay.DisplayFormat = "####0.000###;;0.000;0.000";
			// this.txtHoursPerDay.Format = "###########0.000";
			this.txtHoursPerDay.Location = new System.Drawing.Point(632, 88);
			// // = 2147483647;
			// // = 0;
			this.txtHoursPerDay.Name = "txtHoursPerDay";
			this.txtHoursPerDay.Size = new System.Drawing.Size(101, 19);
			this.txtHoursPerDay.TabIndex = 2;
			this.txtHoursPerDay.Text = "0.000";
			// 
			// _lblCommon_42
			// 
			//this._lblCommon_42.AllowDrop = true;
			this._lblCommon_42.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_42.Text = "Weekend Days";
			this._lblCommon_42.Location = new System.Drawing.Point(6, 136);
			// // this._lblCommon_42.mLabelId = 1108;
			this._lblCommon_42.Name = "_lblCommon_42";
			this._lblCommon_42.Size = new System.Drawing.Size(72, 13);
			this._lblCommon_42.TabIndex = 30;
			// 
			// _cmbCommon_1
			// 
			//this._cmbCommon_1.AllowDrop = true;
			this._cmbCommon_1.Enabled = false;
			this._cmbCommon_1.Location = new System.Drawing.Point(632, 130);
			this._cmbCommon_1.Name = "_cmbCommon_1";
			this._cmbCommon_1.Size = new System.Drawing.Size(101, 21);
			this._cmbCommon_1.TabIndex = 8;
			// this._cmbCommon_1.Click += new System.Windows.Forms.ComboBox.ClickHandler(this.cmbCommon_Click);
			// 
			// _lblCommonLabel_5
			// 
			//this._lblCommonLabel_5.AllowDrop = true;
			this._lblCommonLabel_5.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_5.Text = "Weekend Day 2";
			this._lblCommonLabel_5.Location = new System.Drawing.Point(518, 134);
			// // this._lblCommonLabel_5.mLabelId = 1117;
			this._lblCommonLabel_5.Name = "_lblCommonLabel_5";
			this._lblCommonLabel_5.Size = new System.Drawing.Size(76, 14);
			this._lblCommonLabel_5.TabIndex = 31;
			// 
			// _cmbCommon_0
			// 
			//this._cmbCommon_0.AllowDrop = true;
			this._cmbCommon_0.Enabled = false;
			this._cmbCommon_0.Location = new System.Drawing.Point(350, 132);
			this._cmbCommon_0.Name = "_cmbCommon_0";
			this._cmbCommon_0.Size = new System.Drawing.Size(101, 21);
			this._cmbCommon_0.TabIndex = 7;
			// this._cmbCommon_0.Click += new System.Windows.Forms.ComboBox.ClickHandler(this.cmbCommon_Click);
			// 
			// _lblCommonLabel_6
			// 
			//this._lblCommonLabel_6.AllowDrop = true;
			this._lblCommonLabel_6.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_6.Text = "Weekend Day 1";
			this._lblCommonLabel_6.Location = new System.Drawing.Point(234, 133);
			// // this._lblCommonLabel_6.mLabelId = 1113;
			this._lblCommonLabel_6.Name = "_lblCommonLabel_6";
			this._lblCommonLabel_6.Size = new System.Drawing.Size(76, 14);
			this._lblCommonLabel_6.TabIndex = 32;
			// 
			// Label1_7
			// 
			//this.Label1_7.AllowDrop = true;
			this.Label1_7.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.Label1_7.Text = "OverTime";
			this.Label1_7.Location = new System.Drawing.Point(6, 157);
			// this.Label1_7.mLabelId = 1109;
			this.Label1_7.Name = "Label1_7";
			this.Label1_7.Size = new System.Drawing.Size(46, 14);
			this.Label1_7.TabIndex = 33;
			// 
			// _cmbCommon_2
			// 
			//this._cmbCommon_2.AllowDrop = true;
			this._cmbCommon_2.Enabled = false;
			this._cmbCommon_2.Location = new System.Drawing.Point(632, 154);
			this._cmbCommon_2.Name = "_cmbCommon_2";
			this._cmbCommon_2.Size = new System.Drawing.Size(101, 21);
			this._cmbCommon_2.TabIndex = 11;
			this._cmbCommon_2.Visible = false;
			// this._cmbCommon_2.Click += new System.Windows.Forms.ComboBox.ClickHandler(this.cmbCommon_Click);
			// 
			// Label1_8
			// 
			//this.Label1_8.AllowDrop = true;
			this.Label1_8.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.Label1_8.Text = "Overtime Calc. Method";
			this.Label1_8.Location = new System.Drawing.Point(518, 157);
			// this.Label1_8.mLabelId = 1118;
			this.Label1_8.Name = "Label1_8";
			this.Label1_8.Size = new System.Drawing.Size(108, 14);
			this.Label1_8.TabIndex = 34;
			this.Label1_8.Visible = false;
			// 
			// _lblCommon_43
			// 
			//this._lblCommon_43.AllowDrop = true;
			this._lblCommon_43.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_43.Text = "Normal OT";
			this._lblCommon_43.Location = new System.Drawing.Point(6, 183);
			// // this._lblCommon_43.mLabelId = 1110;
			this._lblCommon_43.Name = "_lblCommon_43";
			this._lblCommon_43.Size = new System.Drawing.Size(50, 13);
			this._lblCommon_43.TabIndex = 35;
			// 
			// _lblCommon_44
			// 
			//this._lblCommon_44.AllowDrop = true;
			this._lblCommon_44.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_44.Text = "Friday OT";
			this._lblCommon_44.Location = new System.Drawing.Point(234, 183);
			// // this._lblCommon_44.mLabelId = 1114;
			this._lblCommon_44.Name = "_lblCommon_44";
			this._lblCommon_44.Size = new System.Drawing.Size(47, 13);
			this._lblCommon_44.TabIndex = 36;
			// 
			// txtFridayOT
			// 
			//this.txtFridayOT.AllowDrop = true;
			// this.txtFridayOT.DisplayFormat = "####0.000###;;0.000;0.000";
			// this.txtFridayOT.Format = "###########0.000";
			this.txtFridayOT.Location = new System.Drawing.Point(350, 180);
			// // = 2147483647;
			// // = 0;
			this.txtFridayOT.Name = "txtFridayOT";
			this.txtFridayOT.Size = new System.Drawing.Size(101, 19);
			this.txtFridayOT.TabIndex = 13;
			this.txtFridayOT.Text = "0.000";
			// 
			// _lblCommon_45
			// 
			//this._lblCommon_45.AllowDrop = true;
			this._lblCommon_45.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_45.Text = "Holiday OT";
			this._lblCommon_45.Location = new System.Drawing.Point(518, 183);
			// // this._lblCommon_45.mLabelId = 1119;
			this._lblCommon_45.Name = "_lblCommon_45";
			this._lblCommon_45.Size = new System.Drawing.Size(52, 13);
			this._lblCommon_45.TabIndex = 37;
			// 
			// txtHolidayOT
			// 
			//this.txtHolidayOT.AllowDrop = true;
			// this.txtHolidayOT.DisplayFormat = "####0.000###;;0.000;0.000";
			// this.txtHolidayOT.Format = "###########0.000";
			this.txtHolidayOT.Location = new System.Drawing.Point(632, 180);
			// // = 2147483647;
			// // = 0;
			this.txtHolidayOT.Name = "txtHolidayOT";
			this.txtHolidayOT.Size = new System.Drawing.Size(101, 19);
			this.txtHolidayOT.TabIndex = 14;
			this.txtHolidayOT.Text = "0.000";
			// 
			// _lblCommon_0
			// 
			//this._lblCommon_0.AllowDrop = true;
			this._lblCommon_0.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_0.Text = "Last Salary Date";
			this._lblCommon_0.Location = new System.Drawing.Point(234, 158);
			// // this._lblCommon_0.mLabelId = 1931;
			this._lblCommon_0.Name = "_lblCommon_0";
			this._lblCommon_0.Size = new System.Drawing.Size(79, 13);
			this._lblCommon_0.TabIndex = 43;
			// 
			// Label1_0
			// 
			//this.Label1_0.AllowDrop = true;
			this.Label1_0.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.Label1_0.Text = "Rate Calc. Method";
			this.Label1_0.Location = new System.Drawing.Point(6, 91);
			// this.Label1_0.mLabelId = 1106;
			this.Label1_0.Name = "Label1_0";
			this.Label1_0.Size = new System.Drawing.Size(87, 14);
			this.Label1_0.TabIndex = 44;
			// 
			// txtLastSalaryDate
			// 
			//this.txtLastSalaryDate.AllowDrop = true;
			this.txtLastSalaryDate.BackColor = System.Drawing.Color.FromArgb(239, 239, 239);
			// this.txtLastSalaryDate.CheckDateRange = false;
			this.txtLastSalaryDate.Enabled = false;
			this.txtLastSalaryDate.Location = new System.Drawing.Point(350, 155);
			// this.txtLastSalaryDate.MaxDate = 2958465;
			// this.txtLastSalaryDate.MinDate = 2;
			this.txtLastSalaryDate.Name = "txtLastSalaryDate";
			this.txtLastSalaryDate.Size = new System.Drawing.Size(101, 19);
			this.txtLastSalaryDate.TabIndex = 9;
			this.txtLastSalaryDate.TabStop = false;
			// this.txtLastSalaryDate.Text = "22-Jan-2011";
			// this.txtLastSalaryDate.Value = 40565;
			// 
			// _lblCommonLabel_0
			// 
			//this._lblCommonLabel_0.AllowDrop = true;
			this._lblCommonLabel_0.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_0.Text = "Rate Per Hours";
			this._lblCommonLabel_0.Location = new System.Drawing.Point(234, 112);
			// // this._lblCommonLabel_0.mLabelId = 2070;
			this._lblCommonLabel_0.Name = "_lblCommonLabel_0";
			this._lblCommonLabel_0.Size = new System.Drawing.Size(73, 13);
			this._lblCommonLabel_0.TabIndex = 50;
			// 
			// txtRatePerHours
			// 
			//this.txtRatePerHours.AllowDrop = true;
			// this.txtRatePerHours.DisplayFormat = "####0.000###;;0.000;0.000";
			// this.txtRatePerHours.Format = "###########0.000";
			this.txtRatePerHours.Location = new System.Drawing.Point(350, 110);
			// // = 2147483647;
			// // = 0;
			this.txtRatePerHours.Name = "txtRatePerHours";
			this.txtRatePerHours.ReadOnly = true;
			this.txtRatePerHours.Size = new System.Drawing.Size(101, 19);
			this.txtRatePerHours.TabIndex = 4;
			this.txtRatePerHours.Text = "0.000";
			// 
			// _txtCommonTextBox_0
			// 
			//this._txtCommonTextBox_0.AllowDrop = true;
			this._txtCommonTextBox_0.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_0.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_0.Location = new System.Drawing.Point(106, 134);
			this._txtCommonTextBox_0.MaxLength = 1;
			this._txtCommonTextBox_0.Name = "_txtCommonTextBox_0";
			this._txtCommonTextBox_0.Size = new System.Drawing.Size(101, 19);
			this._txtCommonTextBox_0.TabIndex = 6;
			this._txtCommonTextBox_0.Text = "";
			// this.// = "";
			// this.this._txtCommonTextBox_0.Change += new System.Windows.Forms.TextBox.ChangeHandler(this.txtCommonTextBox_Change);
			// this.//this._txtCommonTextBox_0.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(//this.txtCommonTextBox_DropButtonClick);
			// this.this._txtCommonTextBox_0.KeyPress += new System.Windows.Forms.TextBox.KeyPressHandler(this.txtCommonTextBox_KeyPress);
			// this._txtCommonTextBox_0.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _cmbCommon_6
			// 
			//this._cmbCommon_6.AllowDrop = true;
			this._cmbCommon_6.Location = new System.Drawing.Point(106, 155);
			this._cmbCommon_6.Name = "_cmbCommon_6";
			this._cmbCommon_6.Size = new System.Drawing.Size(101, 21);
			this._cmbCommon_6.TabIndex = 10;
			// this._cmbCommon_6.Click += new System.Windows.Forms.ComboBox.ClickHandler(this.cmbCommon_Click);
			// 
			// txtNormalOT
			// 
			//this.txtNormalOT.AllowDrop = true;
			// this.txtNormalOT.DisplayFormat = "####0.000###;;0.000;0.000";
			// this.txtNormalOT.Format = "###########0.000";
			this.txtNormalOT.Location = new System.Drawing.Point(106, 180);
			// // = 2147483647;
			// // = 0;
			this.txtNormalOT.Name = "txtNormalOT";
			this.txtNormalOT.Size = new System.Drawing.Size(101, 19);
			this.txtNormalOT.TabIndex = 12;
			this.txtNormalOT.Text = "0.000";
			// 
			// _cmbCommon_7
			// 
			//this._cmbCommon_7.AllowDrop = true;
			this._cmbCommon_7.Location = new System.Drawing.Point(106, 88);
			this._cmbCommon_7.Name = "_cmbCommon_7";
			this._cmbCommon_7.Size = new System.Drawing.Size(101, 21);
			this._cmbCommon_7.TabIndex = 0;
			// this._cmbCommon_7.Click += new System.Windows.Forms.ComboBox.ClickHandler(this.cmbCommon_Click);
			// 
			// _cmbCommon_5
			// 
			//this._cmbCommon_5.AllowDrop = true;
			this._cmbCommon_5.Location = new System.Drawing.Point(106, 111);
			this._cmbCommon_5.Name = "_cmbCommon_5";
			this._cmbCommon_5.Size = new System.Drawing.Size(101, 21);
			this._cmbCommon_5.TabIndex = 3;
			// this._cmbCommon_5.Click += new System.Windows.Forms.ComboBox.ClickHandler(this.cmbCommon_Click);
			// 
			// txtMobileAllowance
			// 
			//this.txtMobileAllowance.AllowDrop = true;
			// this.txtMobileAllowance.DisplayFormat = "####0.000###;;0.000;0.000";
			// this.txtMobileAllowance.Format = "###########0.000";
			this.txtMobileAllowance.Location = new System.Drawing.Point(634, 264);
			// // = 2147483647;
			// // = 0;
			this.txtMobileAllowance.Name = "txtMobileAllowance";
			this.txtMobileAllowance.Size = new System.Drawing.Size(101, 19);
			this.txtMobileAllowance.TabIndex = 26;
			this.txtMobileAllowance.Text = "0.000";
			this.txtMobileAllowance.Visible = false;
			// 
			// txtRatePerDay
			// 
			//this.txtRatePerDay.AllowDrop = true;
			// this.txtRatePerDay.DisplayFormat = "####0.000###;;0.000;0.000";
			// this.txtRatePerDay.Format = "###########0.000";
			this.txtRatePerDay.Location = new System.Drawing.Point(632, 110);
			// // = 2147483647;
			// // = 0;
			this.txtRatePerDay.Name = "txtRatePerDay";
			this.txtRatePerDay.Size = new System.Drawing.Size(101, 19);
			this.txtRatePerDay.TabIndex = 5;
			this.txtRatePerDay.Text = "0.000";
			// this.this.txtRatePerDay.Change += new System.Windows.Forms.TextBox.ChangeHandler(this.txtRatePerDay_Change);
			// 
			// _lblCommonLabel_1
			// 
			//this._lblCommonLabel_1.AllowDrop = true;
			this._lblCommonLabel_1.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_1.Text = "Rate Per Day";
			this._lblCommonLabel_1.Location = new System.Drawing.Point(518, 112);
			this._lblCommonLabel_1.Name = "_lblCommonLabel_1";
			this._lblCommonLabel_1.Size = new System.Drawing.Size(64, 13);
			this._lblCommonLabel_1.TabIndex = 62;
			// 
			// _lblCommon_3
			// 
			//this._lblCommon_3.AllowDrop = true;
			this._lblCommon_3.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_3.Text = "General OT Amount";
			this._lblCommon_3.Location = new System.Drawing.Point(5, 202);
			this._lblCommon_3.Name = "_lblCommon_3";
			this._lblCommon_3.Size = new System.Drawing.Size(94, 13);
			this._lblCommon_3.TabIndex = 63;
			// 
			// txtNGeneralOTAmt
			// 
			//this.txtNGeneralOTAmt.AllowDrop = true;
			// this.txtNGeneralOTAmt.DisplayFormat = "####0.000###;;0.000;0.000";
			// this.txtNGeneralOTAmt.Format = "###########0.000";
			this.txtNGeneralOTAmt.Location = new System.Drawing.Point(106, 200);
			// // = 2147483647;
			// // = 0;
			this.txtNGeneralOTAmt.Name = "txtNGeneralOTAmt";
			this.txtNGeneralOTAmt.Size = new System.Drawing.Size(101, 19);
			this.txtNGeneralOTAmt.TabIndex = 15;
			this.txtNGeneralOTAmt.Text = "0.000";
			// 
			// txtCalendarCd
			// 
			//this.txtCalendarCd.AllowDrop = true;
			this.txtCalendarCd.BackColor = System.Drawing.Color.White;
			// this.txtCalendarCd.bolNumericOnly = true;
			this.txtCalendarCd.ForeColor = System.Drawing.Color.Black;
			this.txtCalendarCd.Location = new System.Drawing.Point(632, 201);
			this.txtCalendarCd.MaxLength = 8;
			this.txtCalendarCd.Name = "txtCalendarCd";
			// this.txtCalendarCd.ShowButton = true;
			this.txtCalendarCd.Size = new System.Drawing.Size(101, 19);
			this.txtCalendarCd.TabIndex = 16;
			this.txtCalendarCd.Text = "";
			// this.// = "";
			// this.//this.txtCalendarCd.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(//this.txtCalendarCd_DropButtonClick);
			// this.txtCalendarCd.Leave += new System.EventHandler(this.txtCalendarCd_Leave);
			// 
			// txtDlblCalendarName
			// 
			//this.txtDlblCalendarName.AllowDrop = true;
			this.txtDlblCalendarName.Location = new System.Drawing.Point(723, 201);
			this.txtDlblCalendarName.Name = "txtDlblCalendarName";
			this.txtDlblCalendarName.Size = new System.Drawing.Size(2, 19);
			this.txtDlblCalendarName.TabIndex = 64;
			this.txtDlblCalendarName.TabStop = false;
			// 
			// lblCalendar
			// 
			//this.lblCalendar.AllowDrop = true;
			this.lblCalendar.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblCalendar.Text = "Calendar Code";
			this.lblCalendar.Location = new System.Drawing.Point(519, 204);
			this.lblCalendar.Name = "lblCalendar";
			this.lblCalendar.Size = new System.Drawing.Size(71, 13);
			this.lblCalendar.TabIndex = 65;
			// 
			// _lblCommon_5
			// 
			//this._lblCommon_5.AllowDrop = true;
			this._lblCommon_5.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_5.Text = "Overtime Working Days";
			this._lblCommon_5.Location = new System.Drawing.Point(234, 203);
			this._lblCommon_5.Name = "_lblCommon_5";
			this._lblCommon_5.Size = new System.Drawing.Size(113, 13);
			this._lblCommon_5.TabIndex = 68;
			// 
			// txtNOTWorkingHrs
			// 
			//this.txtNOTWorkingHrs.AllowDrop = true;
			// this.txtNOTWorkingHrs.DisplayFormat = "####0.000###;;0.000;0.000";
			// this.txtNOTWorkingHrs.Format = "###########0.000";
			this.txtNOTWorkingHrs.Location = new System.Drawing.Point(350, 201);
			// // = 2147483647;
			// // = 0;
			this.txtNOTWorkingHrs.Name = "txtNOTWorkingHrs";
			this.txtNOTWorkingHrs.Size = new System.Drawing.Size(101, 19);
			this.txtNOTWorkingHrs.TabIndex = 69;
			this.txtNOTWorkingHrs.Text = "0.000";
			// 
			// frmPayEmployeePayroll
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.ClientSize = new System.Drawing.Size(750, 333);
			this.Controls.Add(this.frmBank);
			this.Controls.Add(this.chkMobileAllowance);
			this.Controls.Add(this.Frame1);
			this.Controls.Add(this.Label1_4);
			this.Controls.Add(this._lblCommonLabel_40);
			this.Controls.Add(this._lblCommonLabel_41);
			this.Controls.Add(this.txtDaysPerMonth);
			this.Controls.Add(this.txtHoursPerDay);
			this.Controls.Add(this._lblCommon_42);
			this.Controls.Add(this._cmbCommon_1);
			this.Controls.Add(this._lblCommonLabel_5);
			this.Controls.Add(this._cmbCommon_0);
			this.Controls.Add(this._lblCommonLabel_6);
			this.Controls.Add(this.Label1_7);
			this.Controls.Add(this._cmbCommon_2);
			this.Controls.Add(this.Label1_8);
			this.Controls.Add(this._lblCommon_43);
			this.Controls.Add(this._lblCommon_44);
			this.Controls.Add(this.txtFridayOT);
			this.Controls.Add(this._lblCommon_45);
			this.Controls.Add(this.txtHolidayOT);
			this.Controls.Add(this._lblCommon_0);
			this.Controls.Add(this.Label1_0);
			this.Controls.Add(this.txtLastSalaryDate);
			this.Controls.Add(this._lblCommonLabel_0);
			this.Controls.Add(this.txtRatePerHours);
			this.Controls.Add(this._txtCommonTextBox_0);
			this.Controls.Add(this._cmbCommon_6);
			this.Controls.Add(this.txtNormalOT);
			this.Controls.Add(this._cmbCommon_7);
			this.Controls.Add(this._cmbCommon_5);
			this.Controls.Add(this.txtMobileAllowance);
			this.Controls.Add(this.txtRatePerDay);
			this.Controls.Add(this._lblCommonLabel_1);
			this.Controls.Add(this._lblCommon_3);
			this.Controls.Add(this.txtNGeneralOTAmt);
			this.Controls.Add(this.txtCalendarCd);
			this.Controls.Add(this.txtDlblCalendarName);
			this.Controls.Add(this.lblCalendar);
			this.Controls.Add(this._lblCommon_5);
			this.Controls.Add(this.txtNOTWorkingHrs);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			//this.Icon = (System.Drawing.Icon) resources.GetObject("frmPayEmployeePayroll.Icon");
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(218, 176);
			this.MaximizeBox = true;
			this.MinimizeBox = false;
			this.Name = "frmPayEmployeePayroll";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Employee Payroll";
			// this.Activated += new System.EventHandler(this.Form_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
			// this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
			this.frmBank.ResumeLayout(false);
			this.Frame1.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		// 
		void InitializetxtDisplayLabel()
		{
			this.txtDisplayLabel = new System.Windows.Forms.Label[9];
			this.txtDisplayLabel[7] = _txtDisplayLabel_7;
			this.txtDisplayLabel[6] = _txtDisplayLabel_6;
			this.txtDisplayLabel[8] = _txtDisplayLabel_8;
			this.txtDisplayLabel[5] = _txtDisplayLabel_5;
			this.txtDisplayLabel[0] = _txtDisplayLabel_0;
			this.txtDisplayLabel[1] = _txtDisplayLabel_1;
			this.txtDisplayLabel[2] = _txtDisplayLabel_2;
			this.txtDisplayLabel[3] = _txtDisplayLabel_3;
		}
		void InitializetxtCommonTextBox()
		{
			this.txtCommonTextBox = new System.Windows.Forms.TextBox[5];
			this.txtCommonTextBox[2] = _txtCommonTextBox_2;
			this.txtCommonTextBox[3] = _txtCommonTextBox_3;
			this.txtCommonTextBox[1] = _txtCommonTextBox_1;
			this.txtCommonTextBox[4] = _txtCommonTextBox_4;
			this.txtCommonTextBox[0] = _txtCommonTextBox_0;
		}
		void InitializelblCommonLabel()
		{
			this.lblCommonLabel = new System.Windows.Forms.Label[42];
			this.lblCommonLabel[2] = _lblCommonLabel_2;
			this.lblCommonLabel[40] = _lblCommonLabel_40;
			this.lblCommonLabel[41] = _lblCommonLabel_41;
			this.lblCommonLabel[5] = _lblCommonLabel_5;
			this.lblCommonLabel[6] = _lblCommonLabel_6;
			this.lblCommonLabel[0] = _lblCommonLabel_0;
			this.lblCommonLabel[1] = _lblCommonLabel_1;
		}
		void InitializelblCommon()
		{
			this.lblCommon = new System.Windows.Forms.Label[108];
			this.lblCommon[107] = _lblCommon_107;
			this.lblCommon[106] = _lblCommon_106;
			this.lblCommon[46] = _lblCommon_46;
			this.lblCommon[1] = _lblCommon_1;
			this.lblCommon[2] = _lblCommon_2;
			this.lblCommon[4] = _lblCommon_4;
			this.lblCommon[36] = _lblCommon_36;
			this.lblCommon[37] = _lblCommon_37;
			this.lblCommon[102] = _lblCommon_102;
			this.lblCommon[42] = _lblCommon_42;
			this.lblCommon[43] = _lblCommon_43;
			this.lblCommon[44] = _lblCommon_44;
			this.lblCommon[45] = _lblCommon_45;
			this.lblCommon[0] = _lblCommon_0;
			this.lblCommon[3] = _lblCommon_3;
			this.lblCommon[5] = _lblCommon_5;
		}
		void InitializecmbCommon()
		{
			this.cmbCommon = new System.Windows.Forms.ComboBox[8];
			this.cmbCommon[4] = _cmbCommon_4;
			this.cmbCommon[3] = _cmbCommon_3;
			this.cmbCommon[1] = _cmbCommon_1;
			this.cmbCommon[0] = _cmbCommon_0;
			this.cmbCommon[2] = _cmbCommon_2;
			this.cmbCommon[6] = _cmbCommon_6;
			this.cmbCommon[7] = _cmbCommon_7;
			this.cmbCommon[5] = _cmbCommon_5;
		}
		void InitializeSystemWindowsFormsLabel1()
		{
			this.Label1 = new System.Windows.Forms.Label[11];
			this.Label1[9] = Label1_9;
			this.Label1[10] = Label1_10;
			this.Label1[4] = Label1_4;
			this.Label1[7] = Label1_7;
			this.Label1[8] = Label1_8;
			this.Label1[0] = Label1_0;
		}
		#endregion
	}
}//ENDSHERE
