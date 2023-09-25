
namespace Xtreme
{
	partial class frmPayeEmployeeRehire
	{

		#region "Upgrade Support "
		private static frmPayeEmployeeRehire m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmPayeEmployeeRehire DefInstance
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
		public static frmPayeEmployeeRehire CreateInstance()
		{
			frmPayeEmployeeRehire theInstance = new frmPayeEmployeeRehire();
			
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
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "chkPayrollEarning", "_lblCommonLabel_2", "_lblCommonLabel_0", "_lblCommonLabel_1", "_txtCommonTextBox_1", "_txtDisplayLabel_4", "_txtDisplayLabel_3", "_txtDisplayLabel_2", "_txtDisplayLabel_1", "_txtDisplayLabel_0", "_lblCommonLabel_3", "txtStartDate", "_lblCommonLabel_4", "txtResumeDate", "CHKOldWithZeroAccrual", "CHkOldWithNoPay", "CHKOldWithPayDays", "ChkNewEmp", "txtNewEmpNo", "System.Windows.Forms.Label4", "txtnopaydays", "txtLastAccrualDate", "txtDateOfJoining", "System.Windows.Forms.Label3", "System.Windows.Forms.Label2", "System.Windows.Forms.Label1", "Line1", "frmDetail", "lblCommonLabel", "txtCommonTextBox", "txtDisplayLabel"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public System.Windows.Forms.CheckBox chkPayrollEarning;
		private System.Windows.Forms.Label _lblCommonLabel_2;
		private System.Windows.Forms.Label _lblCommonLabel_0;
		private System.Windows.Forms.Label _lblCommonLabel_1;
		private System.Windows.Forms.TextBox _txtCommonTextBox_1;
		private System.Windows.Forms.Label _txtDisplayLabel_4;
		private System.Windows.Forms.Label _txtDisplayLabel_3;
		private System.Windows.Forms.Label _txtDisplayLabel_2;
		private System.Windows.Forms.Label _txtDisplayLabel_1;
		private System.Windows.Forms.Label _txtDisplayLabel_0;
		private System.Windows.Forms.Label _lblCommonLabel_3;
		public Syncfusion.WinForms.Input.SfDateTimeEdit txtStartDate;
		private System.Windows.Forms.Label _lblCommonLabel_4;
		public Syncfusion.WinForms.Input.SfDateTimeEdit txtResumeDate;
		public System.Windows.Forms.RadioButton CHKOldWithZeroAccrual;
		public System.Windows.Forms.RadioButton CHkOldWithNoPay;
		public System.Windows.Forms.RadioButton CHKOldWithPayDays;
		public System.Windows.Forms.RadioButton ChkNewEmp;
		public System.Windows.Forms.TextBox txtNewEmpNo;
		public System.Windows.Forms.Label Label4;
		public System.Windows.Forms.TextBox txtnopaydays;
		public Syncfusion.WinForms.Input.SfDateTimeEdit txtLastAccrualDate;
		public Syncfusion.WinForms.Input.SfDateTimeEdit txtDateOfJoining;
		public System.Windows.Forms.Label Label3;
		public System.Windows.Forms.Label Label2;
		public System.Windows.Forms.Label Label1;
		public System.Windows.Forms.Label Line1;
		public System.Windows.Forms.GroupBox frmDetail;
		public System.Windows.Forms.Label[] lblCommonLabel = new System.Windows.Forms.Label[5];
		public System.Windows.Forms.TextBox[] txtCommonTextBox = new System.Windows.Forms.TextBox[2];
		public System.Windows.Forms.Label[] txtDisplayLabel = new System.Windows.Forms.Label[5];
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPayeEmployeeRehire));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this.chkPayrollEarning = new System.Windows.Forms.CheckBox();
			this._lblCommonLabel_2 = new System.Windows.Forms.Label();
			this._lblCommonLabel_0 = new System.Windows.Forms.Label();
			this._lblCommonLabel_1 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_1 = new System.Windows.Forms.TextBox();
			this._txtDisplayLabel_4 = new System.Windows.Forms.Label();
			this._txtDisplayLabel_3 = new System.Windows.Forms.Label();
			this._txtDisplayLabel_2 = new System.Windows.Forms.Label();
			this._txtDisplayLabel_1 = new System.Windows.Forms.Label();
			this._txtDisplayLabel_0 = new System.Windows.Forms.Label();
			this._lblCommonLabel_3 = new System.Windows.Forms.Label();
			this.txtStartDate = new Syncfusion.WinForms.Input.SfDateTimeEdit();
			this._lblCommonLabel_4 = new System.Windows.Forms.Label();
			this.txtResumeDate = new Syncfusion.WinForms.Input.SfDateTimeEdit();
			this.frmDetail = new System.Windows.Forms.GroupBox();
			this.CHKOldWithZeroAccrual = new System.Windows.Forms.RadioButton();
			this.CHkOldWithNoPay = new System.Windows.Forms.RadioButton();
			this.CHKOldWithPayDays = new System.Windows.Forms.RadioButton();
			this.ChkNewEmp = new System.Windows.Forms.RadioButton();
			this.txtNewEmpNo = new System.Windows.Forms.TextBox();
			this.Label4 = new System.Windows.Forms.Label();
			this.txtnopaydays = new System.Windows.Forms.TextBox();
			this.txtLastAccrualDate = new Syncfusion.WinForms.Input.SfDateTimeEdit();
			this.txtDateOfJoining = new Syncfusion.WinForms.Input.SfDateTimeEdit();
			this.Label3 = new System.Windows.Forms.Label();
			this.Label2 = new System.Windows.Forms.Label();
			this.Label1 = new System.Windows.Forms.Label();
			this.Line1 = new System.Windows.Forms.Label();
			//this.frmDetail.SuspendLayout();
			this.SuspendLayout();
			// 
			// chkPayrollEarning
			// 
			this.chkPayrollEarning.AllowDrop = true;
			this.chkPayrollEarning.Appearance = System.Windows.Forms.Appearance.Normal;
			this.chkPayrollEarning.BackColor = System.Drawing.Color.White;
			this.chkPayrollEarning.CausesValidation = true;
			this.chkPayrollEarning.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkPayrollEarning.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this.chkPayrollEarning.Enabled = true;
			this.chkPayrollEarning.ForeColor = System.Drawing.SystemColors.ControlText;
			this.chkPayrollEarning.Location = new System.Drawing.Point(249, 303);
			this.chkPayrollEarning.Name = "chkPayrollEarning";
			this.chkPayrollEarning.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.chkPayrollEarning.Size = new System.Drawing.Size(229, 16);
			this.chkPayrollEarning.TabIndex = 26;
			this.chkPayrollEarning.TabStop = true;
			this.chkPayrollEarning.Text = "      Generate Last Month Payroll Earning";
			this.chkPayrollEarning.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkPayrollEarning.Visible = false;
			// 
			// _lblCommonLabel_2
			// 
			this._lblCommonLabel_2.AllowDrop = true;
			this._lblCommonLabel_2.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_2.Text = "Employee Code";
			this._lblCommonLabel_2.Location = new System.Drawing.Point(6, 46);
			// // this._lblCommonLabel_2.mLabelId = 236;
			this._lblCommonLabel_2.Name = "_lblCommonLabel_2";
			this._lblCommonLabel_2.Size = new System.Drawing.Size(74, 14);
			this._lblCommonLabel_2.TabIndex = 0;
			// 
			// _lblCommonLabel_0
			// 
			this._lblCommonLabel_0.AllowDrop = true;
			this._lblCommonLabel_0.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_0.Text = "Department Code";
			this._lblCommonLabel_0.Location = new System.Drawing.Point(6, 67);
			// // this._lblCommonLabel_0.mLabelId = 1973;
			this._lblCommonLabel_0.Name = "_lblCommonLabel_0";
			this._lblCommonLabel_0.Size = new System.Drawing.Size(83, 14);
			this._lblCommonLabel_0.TabIndex = 7;
			// 
			// _lblCommonLabel_1
			// 
			this._lblCommonLabel_1.AllowDrop = true;
			this._lblCommonLabel_1.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_1.Text = "Designation Code";
			this._lblCommonLabel_1.Location = new System.Drawing.Point(6, 88);
			// // this._lblCommonLabel_1.mLabelId = 1049;
			this._lblCommonLabel_1.Name = "_lblCommonLabel_1";
			this._lblCommonLabel_1.Size = new System.Drawing.Size(84, 14);
			this._lblCommonLabel_1.TabIndex = 8;
			// 
			// _txtCommonTextBox_1
			// 
			this._txtCommonTextBox_1.AllowDrop = true;
			this._txtCommonTextBox_1.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_1.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_1.Location = new System.Drawing.Point(96, 44);
			this._txtCommonTextBox_1.MaxLength = 10;
			this._txtCommonTextBox_1.Name = "_txtCommonTextBox_1";
			// this._txtCommonTextBox_1.ShowButton = true;
			this._txtCommonTextBox_1.Size = new System.Drawing.Size(101, 19);
			this._txtCommonTextBox_1.TabIndex = 1;
			this._txtCommonTextBox_1.Text = "";
			// this.// = "";
			// this.//this._txtCommonTextBox_1.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(//this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_1.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _txtDisplayLabel_4
			// 
			this._txtDisplayLabel_4.AllowDrop = true;
			this._txtDisplayLabel_4.Enabled = false;
			this._txtDisplayLabel_4.Location = new System.Drawing.Point(199, 44);
			this._txtDisplayLabel_4.Name = "_txtDisplayLabel_4";
			this._txtDisplayLabel_4.Size = new System.Drawing.Size(295, 19);
			this._txtDisplayLabel_4.TabIndex = 9;
			this._txtDisplayLabel_4.TabStop = false;
			// 
			// _txtDisplayLabel_3
			// 
			this._txtDisplayLabel_3.AllowDrop = true;
			this._txtDisplayLabel_3.Enabled = false;
			this._txtDisplayLabel_3.Location = new System.Drawing.Point(199, 86);
			this._txtDisplayLabel_3.Name = "_txtDisplayLabel_3";
			this._txtDisplayLabel_3.Size = new System.Drawing.Size(295, 19);
			this._txtDisplayLabel_3.TabIndex = 10;
			this._txtDisplayLabel_3.TabStop = false;
			// 
			// _txtDisplayLabel_2
			// 
			this._txtDisplayLabel_2.AllowDrop = true;
			this._txtDisplayLabel_2.Enabled = false;
			this._txtDisplayLabel_2.Location = new System.Drawing.Point(96, 86);
			this._txtDisplayLabel_2.Name = "_txtDisplayLabel_2";
			this._txtDisplayLabel_2.Size = new System.Drawing.Size(101, 19);
			this._txtDisplayLabel_2.TabIndex = 11;
			this._txtDisplayLabel_2.TabStop = false;
			// 
			// _txtDisplayLabel_1
			// 
			this._txtDisplayLabel_1.AllowDrop = true;
			this._txtDisplayLabel_1.Enabled = false;
			this._txtDisplayLabel_1.Location = new System.Drawing.Point(199, 65);
			this._txtDisplayLabel_1.Name = "_txtDisplayLabel_1";
			this._txtDisplayLabel_1.Size = new System.Drawing.Size(295, 19);
			this._txtDisplayLabel_1.TabIndex = 12;
			this._txtDisplayLabel_1.TabStop = false;
			// 
			// _txtDisplayLabel_0
			// 
			this._txtDisplayLabel_0.AllowDrop = true;
			this._txtDisplayLabel_0.Enabled = false;
			this._txtDisplayLabel_0.Location = new System.Drawing.Point(96, 65);
			this._txtDisplayLabel_0.Name = "_txtDisplayLabel_0";
			this._txtDisplayLabel_0.Size = new System.Drawing.Size(101, 19);
			this._txtDisplayLabel_0.TabIndex = 13;
			this._txtDisplayLabel_0.TabStop = false;
			// 
			// _lblCommonLabel_3
			// 
			this._lblCommonLabel_3.AllowDrop = true;
			this._lblCommonLabel_3.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_3.Text = "Start Date";
			this._lblCommonLabel_3.Location = new System.Drawing.Point(6, 120);
			// // this._lblCommonLabel_3.mLabelId = 1703;
			this._lblCommonLabel_3.Name = "_lblCommonLabel_3";
			this._lblCommonLabel_3.Size = new System.Drawing.Size(48, 14);
			this._lblCommonLabel_3.TabIndex = 14;
			// 
			// txtStartDate
			// 
			this.txtStartDate.AllowDrop = true;
			this.txtStartDate.BackColor = System.Drawing.Color.White;
			// this.txtStartDate.CheckDateRange = false;
			this.txtStartDate.Location = new System.Drawing.Point(94, 116);
			// this.txtStartDate.MaxDate = 2958465;
			// this.txtStartDate.MinDate = -657434;
			this.txtStartDate.Name = "txtStartDate";
			//// = "_";
			this.txtStartDate.Size = new System.Drawing.Size(143, 21);
			this.txtStartDate.TabIndex = 2;
			// this.txtStartDate.Text = "13/04/2010";
			// this.txtStartDate.Value = 40281;
			// 
			// _lblCommonLabel_4
			// 
			this._lblCommonLabel_4.AllowDrop = true;
			this._lblCommonLabel_4.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_4.Text = "Resume Date";
			this._lblCommonLabel_4.Location = new System.Drawing.Point(260, 120);
			// // this._lblCommonLabel_4.mLabelId = 1132;
			this._lblCommonLabel_4.Name = "_lblCommonLabel_4";
			this._lblCommonLabel_4.Size = new System.Drawing.Size(64, 14);
			this._lblCommonLabel_4.TabIndex = 15;
			// 
			// txtResumeDate
			// 
			this.txtResumeDate.AllowDrop = true;
			this.txtResumeDate.BackColor = System.Drawing.Color.White;
			// this.txtResumeDate.CheckDateRange = false;
			this.txtResumeDate.Location = new System.Drawing.Point(350, 116);
			// this.txtResumeDate.MaxDate = 2958465;
			// this.txtResumeDate.MinDate = -657434;
			this.txtResumeDate.Name = "txtResumeDate";
			// = "_";
			this.txtResumeDate.Size = new System.Drawing.Size(143, 21);
			this.txtResumeDate.TabIndex = 3;
			// this.txtResumeDate.Text = "13/04/2010";
			// this.txtResumeDate.Value = 40281;
			// this.this.txtResumeDate.Change += new Syncfusion.WinForms.Input.SfDateTimeEdit.ChangeHandler(this.txtResumeDate_Change);
			this.txtResumeDate.Validating += new System.ComponentModel.CancelEventHandler(this.txtResumeDate_Validating);
			// 
			// frmDetail
			// 
			this.frmDetail.AllowDrop = true;
			this.frmDetail.BackColor = System.Drawing.Color.White;
			this.frmDetail.Controls.Add(this.CHKOldWithZeroAccrual);
			this.frmDetail.Controls.Add(this.CHkOldWithNoPay);
			this.frmDetail.Controls.Add(this.CHKOldWithPayDays);
			this.frmDetail.Controls.Add(this.ChkNewEmp);
			this.frmDetail.Controls.Add(this.txtNewEmpNo);
			this.frmDetail.Controls.Add(this.Label4);
			this.frmDetail.Controls.Add(this.txtnopaydays);
			this.frmDetail.Controls.Add(this.txtLastAccrualDate);
			this.frmDetail.Controls.Add(this.txtDateOfJoining);
			this.frmDetail.Controls.Add(this.Label3);
			this.frmDetail.Controls.Add(this.Label2);
			this.frmDetail.Controls.Add(this.Label1);
			this.frmDetail.Controls.Add(this.Line1);
			this.frmDetail.Enabled = true;
			this.frmDetail.ForeColor = System.Drawing.SystemColors.ControlText;
			this.frmDetail.Location = new System.Drawing.Point(4, 141);
			this.frmDetail.Name = "frmDetail";
			this.frmDetail.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.frmDetail.Size = new System.Drawing.Size(495, 193);
			this.frmDetail.TabIndex = 16;
			this.frmDetail.Visible = true;
			// 
			// CHKOldWithZeroAccrual
			// 
			this.CHKOldWithZeroAccrual.AllowDrop = true;
			this.CHKOldWithZeroAccrual.Appearance = System.Windows.Forms.Appearance.Normal;
			this.CHKOldWithZeroAccrual.BackColor = System.Drawing.SystemColors.ControlLight;
			this.CHKOldWithZeroAccrual.CausesValidation = true;
			this.CHKOldWithZeroAccrual.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.CHKOldWithZeroAccrual.Checked = false;
			this.CHKOldWithZeroAccrual.Enabled = true;
			this.CHKOldWithZeroAccrual.ForeColor = System.Drawing.Color.Navy;
			this.CHKOldWithZeroAccrual.Location = new System.Drawing.Point(10, 66);
			this.CHKOldWithZeroAccrual.Name = "CHKOldWithZeroAccrual";
			this.CHKOldWithZeroAccrual.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.CHKOldWithZeroAccrual.Size = new System.Drawing.Size(209, 29);
			this.CHKOldWithZeroAccrual.TabIndex = 25;
			this.CHKOldWithZeroAccrual.TabStop = true;
			this.CHKOldWithZeroAccrual.Text = "As Old Employee But Zero Accrual";
			this.CHKOldWithZeroAccrual.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.CHKOldWithZeroAccrual.Visible = true;
			this.CHKOldWithZeroAccrual.CheckedChanged += new System.EventHandler(this.CHKOldWithZeroAccrual_CheckedChanged);
			// 
			// CHkOldWithNoPay
			// 
			this.CHkOldWithNoPay.AllowDrop = true;
			this.CHkOldWithNoPay.Appearance = System.Windows.Forms.Appearance.Normal;
			this.CHkOldWithNoPay.BackColor = System.Drawing.SystemColors.ControlLight;
			this.CHkOldWithNoPay.CausesValidation = true;
			this.CHkOldWithNoPay.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.CHkOldWithNoPay.Checked = false;
			this.CHkOldWithNoPay.Enabled = true;
			this.CHkOldWithNoPay.ForeColor = System.Drawing.Color.Navy;
			this.CHkOldWithNoPay.Location = new System.Drawing.Point(10, 113);
			this.CHkOldWithNoPay.Name = "CHkOldWithNoPay";
			this.CHkOldWithNoPay.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.CHkOldWithNoPay.Size = new System.Drawing.Size(209, 29);
			this.CHkOldWithNoPay.TabIndex = 24;
			this.CHkOldWithNoPay.TabStop = true;
			this.CHkOldWithNoPay.Text = "As Old Employee But with No Paid Days";
			this.CHkOldWithNoPay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.CHkOldWithNoPay.Visible = true;
			this.CHkOldWithNoPay.CheckedChanged += new System.EventHandler(this.CHkOldWithNoPay_CheckedChanged);
			// 
			// CHKOldWithPayDays
			// 
			this.CHKOldWithPayDays.AllowDrop = true;
			this.CHKOldWithPayDays.Appearance = System.Windows.Forms.Appearance.Normal;
			this.CHKOldWithPayDays.BackColor = System.Drawing.SystemColors.ControlLight;
			this.CHKOldWithPayDays.CausesValidation = true;
			this.CHKOldWithPayDays.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.CHKOldWithPayDays.Checked = false;
			this.CHKOldWithPayDays.Enabled = true;
			this.CHKOldWithPayDays.ForeColor = System.Drawing.Color.Navy;
			this.CHKOldWithPayDays.Location = new System.Drawing.Point(10, 155);
			this.CHKOldWithPayDays.Name = "CHKOldWithPayDays";
			this.CHKOldWithPayDays.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.CHKOldWithPayDays.Size = new System.Drawing.Size(209, 29);
			this.CHKOldWithPayDays.TabIndex = 23;
			this.CHKOldWithPayDays.TabStop = true;
			this.CHKOldWithPayDays.Text = "As Old Employee But with All PayDays";
			this.CHKOldWithPayDays.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.CHKOldWithPayDays.Visible = true;
			this.CHKOldWithPayDays.CheckedChanged += new System.EventHandler(this.CHKOldWithPayDays_CheckedChanged);
			// 
			// ChkNewEmp
			// 
			this.ChkNewEmp.AllowDrop = true;
			this.ChkNewEmp.Appearance = System.Windows.Forms.Appearance.Normal;
			this.ChkNewEmp.BackColor = System.Drawing.SystemColors.ControlLight;
			this.ChkNewEmp.CausesValidation = true;
			this.ChkNewEmp.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.ChkNewEmp.Checked = false;
			this.ChkNewEmp.Enabled = true;
			this.ChkNewEmp.ForeColor = System.Drawing.Color.Navy;
			this.ChkNewEmp.Location = new System.Drawing.Point(10, 20);
			this.ChkNewEmp.Name = "ChkNewEmp";
			this.ChkNewEmp.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.ChkNewEmp.Size = new System.Drawing.Size(143, 29);
			this.ChkNewEmp.TabIndex = 22;
			this.ChkNewEmp.TabStop = true;
			this.ChkNewEmp.Text = "As New Employee";
			this.ChkNewEmp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.ChkNewEmp.Visible = true;
			this.ChkNewEmp.CheckedChanged += new System.EventHandler(this.ChkNewEmp_CheckedChanged);
			// 
			// txtNewEmpNo
			// 
			this.txtNewEmpNo.AllowDrop = true;
			this.txtNewEmpNo.BackColor = System.Drawing.Color.FromArgb(239, 239, 239);
			// // = false;
			this.txtNewEmpNo.Enabled = false;
			this.txtNewEmpNo.ForeColor = System.Drawing.Color.Black;
			this.txtNewEmpNo.Location = new System.Drawing.Point(342, 38);
			// // = (System.Windows.Forms.TextBox.DropDownTypes) 0;
			this.txtNewEmpNo.Name = "txtNewEmpNo";
			this.txtNewEmpNo.Size = new System.Drawing.Size(83, 19);
			this.txtNewEmpNo.TabIndex = 21;
			this.txtNewEmpNo.Text = "";
			// this.// = "";
			// 
			// System.Windows.Forms.Label4
			// 
			this.Label4.AllowDrop = true;
			this.Label4.BackColor = System.Drawing.SystemColors.Window;
			this.Label4.Text = "Employee No";
			this.Label4.Location = new System.Drawing.Point(234, 41);
			// this.Label4.mLabelId = 1394;
			this.Label4.Name="Label4";
			this.Label4.Size = new System.Drawing.Size(62, 14);
			this.Label4.TabIndex = 20;
			// 
			// txtnopaydays
			// 
			this.txtnopaydays.AllowDrop = true;
			this.txtnopaydays.BackColor = System.Drawing.SystemColors.InactiveBorder;
			this.txtnopaydays.Enabled = false;
			this.txtnopaydays.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtnopaydays.Location = new System.Drawing.Point(342, 92);
			this.txtnopaydays.Name = "txtnopaydays";
			this.txtnopaydays.Size = new System.Drawing.Size(51, 17);
			this.txtnopaydays.TabIndex = 6;
			// 
			// txtLastAccrualDate
			// 
			this.txtLastAccrualDate.AllowDrop = true;
			this.txtLastAccrualDate.BackColor = System.Drawing.Color.FromArgb(239, 239, 239);
			// this.txtLastAccrualDate.CheckDateRange = false;
			this.txtLastAccrualDate.Enabled = false;
			this.txtLastAccrualDate.Location = new System.Drawing.Point(342, 68);
			// this.txtLastAccrualDate.MaxDate = 2958465;
			// this.txtLastAccrualDate.MinDate = -657434;
			this.txtLastAccrualDate.Name = "txtLastAccrualDate";
			// = "_";
			this.txtLastAccrualDate.Size = new System.Drawing.Size(139, 19);
			this.txtLastAccrualDate.TabIndex = 5;
			// this.txtLastAccrualDate.Text = "13/04/2010";
			// this.txtLastAccrualDate.Value = 40281;
			// this.this.txtLastAccrualDate.Change += new Syncfusion.WinForms.Input.SfDateTimeEdit.ChangeHandler(this.txtLastAccrualDate_Change);
			// 
			// txtDateOfJoining
			// 
			this.txtDateOfJoining.AllowDrop = true;
			this.txtDateOfJoining.BackColor = System.Drawing.Color.FromArgb(239, 239, 239);
			// this.txtDateOfJoining.CheckDateRange = false;
			this.txtDateOfJoining.Enabled = false;
			this.txtDateOfJoining.Location = new System.Drawing.Point(342, 16);
			// this.txtDateOfJoining.MaxDate = 2958465;
			// this.txtDateOfJoining.MinDate = -657434;
			this.txtDateOfJoining.Name = "txtDateOfJoining";
			// = "_";
			this.txtDateOfJoining.Size = new System.Drawing.Size(139, 19);
			this.txtDateOfJoining.TabIndex = 4;
			this.txtDateOfJoining.Text = "13/04/2010";
			// this.txtDateOfJoining.Value = 40281;
			// 
			// System.Windows.Forms.Label3
			// 
			this.Label3.AllowDrop = true;
			this.Label3.BackColor = System.Drawing.SystemColors.Window;
			this.Label3.Text = "No PayDays";
			this.Label3.Location = new System.Drawing.Point(234, 93);
			// this.Label3.mLabelId = 1922;
			this.Label3.Name="Label3";
			this.Label3.Size = new System.Drawing.Size(59, 14);
			this.Label3.TabIndex = 19;
			// 
			// System.Windows.Forms.Label2
			// 
			this.Label2.AllowDrop = true;
			this.Label2.BackColor = System.Drawing.SystemColors.Window;
			this.Label2.Text = "Last Accrual Date";
			this.Label2.Location = new System.Drawing.Point(234, 70);
			// this.Label2.mLabelId = 2078;
			this.Label2.Name="Label2";
			this.Label2.Size = new System.Drawing.Size(87, 14);
			this.Label2.TabIndex = 18;
			// 
			// System.Windows.Forms.Label1
			// 
			this.Label1.AllowDrop = true;
			this.Label1.BackColor = System.Drawing.SystemColors.Window;
			this.Label1.Text = "Date Of Joining";
			this.Label1.Location = new System.Drawing.Point(236, 19);
			// this.Label1.mLabelId = 192;
			this.Label1.Name="Label1";
			this.Label1.Size = new System.Drawing.Size(73, 14);
			this.Label1.TabIndex = 17;
			// 
			// Line1
			// 
			this.Line1.AllowDrop = true;
			this.Line1.BackColor = System.Drawing.SystemColors.WindowText;
			this.Line1.Enabled = false;
			this.Line1.Location = new System.Drawing.Point(0, 62);
			this.Line1.Name = "Line1";
			this.Line1.Size = new System.Drawing.Size(498, 1);
			this.Line1.Visible = true;
			// 
			// frmPayeEmployeeRehire
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.ClientSize = new System.Drawing.Size(504, 338);
			this.Controls.Add(this.chkPayrollEarning);
			this.Controls.Add(this._lblCommonLabel_2);
			this.Controls.Add(this._lblCommonLabel_0);
			this.Controls.Add(this._lblCommonLabel_1);
			this.Controls.Add(this._txtCommonTextBox_1);
			this.Controls.Add(this._txtDisplayLabel_4);
			this.Controls.Add(this._txtDisplayLabel_3);
			this.Controls.Add(this._txtDisplayLabel_2);
			this.Controls.Add(this._txtDisplayLabel_1);
			this.Controls.Add(this._txtDisplayLabel_0);
			this.Controls.Add(this._lblCommonLabel_3);
			this.Controls.Add(this.txtStartDate);
			this.Controls.Add(this._lblCommonLabel_4);
			this.Controls.Add(this.txtResumeDate);
			this.Controls.Add(this.frmDetail);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			//this.Icon = (System.Drawing.Icon) resources.GetObject("frmPayeEmployeeRehire.Icon");
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(311, 136);
			this.MaximizeBox = true;
			this.MinimizeBox = true;
			this.Name = "frmPayeEmployeeRehire";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Employee Rehire";
			// this.Activated += new System.EventHandler(this.frmPayeEmployeeRehire_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
			// this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
			this.frmDetail.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		// 
		void InitializetxtDisplayLabel()
		{
			this.txtDisplayLabel = new System.Windows.Forms.Label[5];
			this.txtDisplayLabel[4] = _txtDisplayLabel_4;
			this.txtDisplayLabel[3] = _txtDisplayLabel_3;
			this.txtDisplayLabel[2] = _txtDisplayLabel_2;
			this.txtDisplayLabel[1] = _txtDisplayLabel_1;
			this.txtDisplayLabel[0] = _txtDisplayLabel_0;
		}
		void InitializetxtCommonTextBox()
		{
			this.txtCommonTextBox = new System.Windows.Forms.TextBox[2];
			this.txtCommonTextBox[1] = _txtCommonTextBox_1;
		}
		void InitializelblCommonLabel()
		{
			this.lblCommonLabel = new System.Windows.Forms.Label[5];
			this.lblCommonLabel[2] = _lblCommonLabel_2;
			this.lblCommonLabel[0] = _lblCommonLabel_0;
			this.lblCommonLabel[1] = _lblCommonLabel_1;
			this.lblCommonLabel[3] = _lblCommonLabel_3;
			this.lblCommonLabel[4] = _lblCommonLabel_4;
		}
		#endregion
	}
}//ENDSHERE
