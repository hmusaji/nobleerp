
namespace Xtreme
{
	partial class frmPayGenerateBankFile
	{

		#region "Upgrade Support "
		private static frmPayGenerateBankFile m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmPayGenerateBankFile DefInstance
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
		public static frmPayGenerateBankFile CreateInstance()
		{
			frmPayGenerateBankFile theInstance = new frmPayGenerateBankFile();
			
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
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "cmdPrintReport", "_GenerateOption_1", "_GenerateOption_0", "System.Windows.Forms.Label11", "Frame1", "frmLeave", "txtDToTransDate", "txtDFromTransDate", "System.Windows.Forms.Label6", "txtLeaveToTransNo", "lblLeaveEmpBankName", "txtLeaveEmpBankCd", "System.Windows.Forms.Label7", "txtLeaveCompBankCd", "System.Windows.Forms.Label8", "lblLeaveCompBankName", "_lblCommon_2", "txtLeaveSponsorCd", "lblLeaveSponsorName", "_lblCommon_3", "txtLeaveProjectCd", "lblLeaveProjectName", "txtLeaveFilePath", "System.Windows.Forms.Label12", "txtLeaveFromTransNo", "System.Windows.Forms.Label13", "System.Windows.Forms.Label9", "System.Windows.Forms.Label10", "frmResumtion", "chkSelectAll", "System.Windows.Forms.Label4", "txtDepartmentNameTo", "txtDepartmentCodeTo", "txtEmpBankName", "txtEmpBankAccount", "System.Windows.Forms.Label2", "txtBankAccountNo", "lblMasterCode", "txtFromEmpNo", "lblLocationCode", "txtToEmpNo", "Label1_0", "lblVoucherRange", "txtToEmpName", "txtFromEmpName", "txtBankName", "cmbMonth", "cmbYear", "lblToVoucherNo", "lblFromVoucherNo", "_lblCommon_41", "txtSponsorCd", "txtDlblSponsorName", "_lblCommon_0", "txtProjectCd", "txtDProjectName", "txtFilePath", "System.Windows.Forms.Label5", "_lblCommon_1", "txtCompanyCode", "txtDlblCompanyName", "txtDepartmentName", "txtDepartmentCode", "System.Windows.Forms.Label3", "Shape1", "frmEmployee", "tabBankDisk", "cmdOKCancel", "GenerateOption", "System.Windows.Forms.Label1", "lblCommon"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public System.Windows.Forms.Button cmdPrintReport;
		private System.Windows.Forms.RadioButton _GenerateOption_1;
		private System.Windows.Forms.RadioButton _GenerateOption_0;
		public System.Windows.Forms.Label Label11;
		public System.Windows.Forms.Panel Frame1;
		public System.Windows.Forms.Panel frmLeave;
		public Syncfusion.WinForms.Input.SfDateTimeEdit txtDToTransDate;
		public Syncfusion.WinForms.Input.SfDateTimeEdit txtDFromTransDate;
		public System.Windows.Forms.Label Label6;
		public System.Windows.Forms.TextBox txtLeaveToTransNo;
		public System.Windows.Forms.Label lblLeaveEmpBankName;
		public System.Windows.Forms.TextBox txtLeaveEmpBankCd;
		public System.Windows.Forms.Label Label7;
		public System.Windows.Forms.TextBox txtLeaveCompBankCd;
		public System.Windows.Forms.Label Label8;
		public System.Windows.Forms.Label lblLeaveCompBankName;
		private System.Windows.Forms.Label _lblCommon_2;
		public System.Windows.Forms.TextBox txtLeaveSponsorCd;
		public System.Windows.Forms.Label lblLeaveSponsorName;
		private System.Windows.Forms.Label _lblCommon_3;
		public System.Windows.Forms.TextBox txtLeaveProjectCd;
		public System.Windows.Forms.Label lblLeaveProjectName;
		public System.Windows.Forms.TextBox txtLeaveFilePath;
		public System.Windows.Forms.Label Label12;
		public System.Windows.Forms.TextBox txtLeaveFromTransNo;
		public System.Windows.Forms.Label Label13;
		public System.Windows.Forms.Label Label9;
		public System.Windows.Forms.Label Label10;
		public System.Windows.Forms.Panel frmResumtion;
		public System.Windows.Forms.CheckBox chkSelectAll;
		public System.Windows.Forms.Label Label4;
		public System.Windows.Forms.Label txtDepartmentNameTo;
		public System.Windows.Forms.TextBox txtDepartmentCodeTo;
		public System.Windows.Forms.Label txtEmpBankName;
		public System.Windows.Forms.TextBox txtEmpBankAccount;
		public System.Windows.Forms.Label Label2;
		public System.Windows.Forms.TextBox txtBankAccountNo;
		public System.Windows.Forms.Label lblMasterCode;
		public System.Windows.Forms.TextBox txtFromEmpNo;
		public System.Windows.Forms.Label lblLocationCode;
		public System.Windows.Forms.TextBox txtToEmpNo;
		private System.Windows.Forms.Label Label1_0;
		public System.Windows.Forms.Label lblVoucherRange;
		public System.Windows.Forms.Label txtToEmpName;
		public System.Windows.Forms.Label txtFromEmpName;
		public System.Windows.Forms.Label txtBankName;
		public System.Windows.Forms.ComboBox cmbMonth;
		public System.Windows.Forms.ComboBox cmbYear;
		public System.Windows.Forms.Label lblToVoucherNo;
		public System.Windows.Forms.Label lblFromVoucherNo;
		private System.Windows.Forms.Label _lblCommon_41;
		public System.Windows.Forms.TextBox txtSponsorCd;
		public System.Windows.Forms.Label txtDlblSponsorName;
		private System.Windows.Forms.Label _lblCommon_0;
		public System.Windows.Forms.TextBox txtProjectCd;
		public System.Windows.Forms.Label txtDProjectName;
		public System.Windows.Forms.TextBox txtFilePath;
		public System.Windows.Forms.Label Label5;
		private System.Windows.Forms.Label _lblCommon_1;
		public System.Windows.Forms.TextBox txtCompanyCode;
		public System.Windows.Forms.Label txtDlblCompanyName;
		public System.Windows.Forms.Label txtDepartmentName;
		public System.Windows.Forms.TextBox txtDepartmentCode;
		public System.Windows.Forms.Label Label3;
		public ShapeHelper Shape1;
		public System.Windows.Forms.Panel frmEmployee;
		public Syncfusion.Windows.Forms.Tools.TabControlAdv tabBankDisk;
		public UCOkCancel cmdOKCancel;
		public System.Windows.Forms.RadioButton[] GenerateOption = new System.Windows.Forms.RadioButton[2];
		public System.Windows.Forms.Label[] Label1 = new System.Windows.Forms.Label[1];
		public System.Windows.Forms.Label[] lblCommon = new System.Windows.Forms.Label[42];
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPayGenerateBankFile));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this.cmdPrintReport = new System.Windows.Forms.Button();
			this.Frame1 = new System.Windows.Forms.Panel();
			this._GenerateOption_1 = new System.Windows.Forms.RadioButton();
			this._GenerateOption_0 = new System.Windows.Forms.RadioButton();
			this.Label11 = new System.Windows.Forms.Label();
			this.tabBankDisk = new Syncfusion.Windows.Forms.Tools.TabControlAdv();
			this.frmLeave = new System.Windows.Forms.Panel();
			this.frmResumtion = new System.Windows.Forms.Panel();
			this.txtDToTransDate = new Syncfusion.WinForms.Input.SfDateTimeEdit();
			this.txtDFromTransDate = new Syncfusion.WinForms.Input.SfDateTimeEdit();
			this.Label6 = new System.Windows.Forms.Label();
			this.txtLeaveToTransNo = new System.Windows.Forms.TextBox();
			this.lblLeaveEmpBankName = new System.Windows.Forms.Label();
			this.txtLeaveEmpBankCd = new System.Windows.Forms.TextBox();
			this.Label7 = new System.Windows.Forms.Label();
			this.txtLeaveCompBankCd = new System.Windows.Forms.TextBox();
			this.Label8 = new System.Windows.Forms.Label();
			this.lblLeaveCompBankName = new System.Windows.Forms.Label();
			this._lblCommon_2 = new System.Windows.Forms.Label();
			this.txtLeaveSponsorCd = new System.Windows.Forms.TextBox();
			this.lblLeaveSponsorName = new System.Windows.Forms.Label();
			this._lblCommon_3 = new System.Windows.Forms.Label();
			this.txtLeaveProjectCd = new System.Windows.Forms.TextBox();
			this.lblLeaveProjectName = new System.Windows.Forms.Label();
			this.txtLeaveFilePath = new System.Windows.Forms.TextBox();
			this.Label12 = new System.Windows.Forms.Label();
			this.txtLeaveFromTransNo = new System.Windows.Forms.TextBox();
			this.Label13 = new System.Windows.Forms.Label();
			this.Label9 = new System.Windows.Forms.Label();
			this.Label10 = new System.Windows.Forms.Label();
			this.frmEmployee = new System.Windows.Forms.Panel();
			this.chkSelectAll = new System.Windows.Forms.CheckBox();
			this.Label4 = new System.Windows.Forms.Label();
			this.txtDepartmentNameTo = new System.Windows.Forms.Label();
			this.txtDepartmentCodeTo = new System.Windows.Forms.TextBox();
			this.txtEmpBankName = new System.Windows.Forms.Label();
			this.txtEmpBankAccount = new System.Windows.Forms.TextBox();
			this.Label2 = new System.Windows.Forms.Label();
			this.txtBankAccountNo = new System.Windows.Forms.TextBox();
			this.lblMasterCode = new System.Windows.Forms.Label();
			this.txtFromEmpNo = new System.Windows.Forms.TextBox();
			this.lblLocationCode = new System.Windows.Forms.Label();
			this.txtToEmpNo = new System.Windows.Forms.TextBox();
			this.Label1_0 = new System.Windows.Forms.Label();
			this.lblVoucherRange = new System.Windows.Forms.Label();
			this.txtToEmpName = new System.Windows.Forms.Label();
			this.txtFromEmpName = new System.Windows.Forms.Label();
			this.txtBankName = new System.Windows.Forms.Label();
			this.cmbMonth = new System.Windows.Forms.ComboBox();
			this.cmbYear = new System.Windows.Forms.ComboBox();
			this.lblToVoucherNo = new System.Windows.Forms.Label();
			this.lblFromVoucherNo = new System.Windows.Forms.Label();
			this._lblCommon_41 = new System.Windows.Forms.Label();
			this.txtSponsorCd = new System.Windows.Forms.TextBox();
			this.txtDlblSponsorName = new System.Windows.Forms.Label();
			this._lblCommon_0 = new System.Windows.Forms.Label();
			this.txtProjectCd = new System.Windows.Forms.TextBox();
			this.txtDProjectName = new System.Windows.Forms.Label();
			this.txtFilePath = new System.Windows.Forms.TextBox();
			this.Label5 = new System.Windows.Forms.Label();
			this._lblCommon_1 = new System.Windows.Forms.Label();
			this.txtCompanyCode = new System.Windows.Forms.TextBox();
			this.txtDlblCompanyName = new System.Windows.Forms.Label();
			this.txtDepartmentName = new System.Windows.Forms.Label();
			this.txtDepartmentCode = new System.Windows.Forms.TextBox();
			this.Label3 = new System.Windows.Forms.Label();
			this.Shape1 = new ShapeHelper();
			this.cmdOKCancel = new UCOkCancel();
			// //((System.ComponentModel.ISupportInitialize) this.tabBankDisk).BeginInit();
			//this.Frame1.SuspendLayout();
			//this.tabBankDisk.SuspendLayout();
			//this.frmResumtion.SuspendLayout();
			//this.frmEmployee.SuspendLayout();
			this.SuspendLayout();
			// 
			// cmdPrintReport
			// 
			//this.cmdPrintReport.AllowDrop = true;
			this.cmdPrintReport.BackColor = System.Drawing.SystemColors.Control;
			this.cmdPrintReport.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdPrintReport.Location = new System.Drawing.Point(291, 366);
			this.cmdPrintReport.Name = "cmdPrintReport";
			this.cmdPrintReport.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdPrintReport.Size = new System.Drawing.Size(94, 28);
			this.cmdPrintReport.TabIndex = 66;
			this.cmdPrintReport.Text = "&Bank Report";
			this.cmdPrintReport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.cmdPrintReport.UseVisualStyleBackColor = false;
			this.cmdPrintReport.Visible = false;
			// this.cmdPrintReport.Click += new System.EventHandler(this.cmdPrintReport_Click);
			// 
			// Frame1
			// 
			//this.Frame1.AllowDrop = true;
			this.Frame1.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			//this.Frame1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Frame1.Controls.Add(this._GenerateOption_1);
			this.Frame1.Controls.Add(this._GenerateOption_0);
			this.Frame1.Controls.Add(this.Label11);
			this.Frame1.Enabled = true;
			this.Frame1.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Frame1.Location = new System.Drawing.Point(6, 3);
			this.Frame1.Name = "Frame1";
			this.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Frame1.Size = new System.Drawing.Size(451, 31);
			this.Frame1.TabIndex = 62;
			this.Frame1.Visible = true;
			// 
			// _GenerateOption_1
			// 
			//this._GenerateOption_1.AllowDrop = true;
			this._GenerateOption_1.Appearance = System.Windows.Forms.Appearance.Normal;
			this._GenerateOption_1.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._GenerateOption_1.CausesValidation = true;
			this._GenerateOption_1.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._GenerateOption_1.Checked = false;
			this._GenerateOption_1.Enabled = true;
			this._GenerateOption_1.ForeColor = System.Drawing.SystemColors.ControlText;
			this._GenerateOption_1.Location = new System.Drawing.Point(282, 9);
			this._GenerateOption_1.Name = "_GenerateOption_1";
			this._GenerateOption_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._GenerateOption_1.Size = new System.Drawing.Size(67, 13);
			this._GenerateOption_1.TabIndex = 65;
			this._GenerateOption_1.TabStop = true;
			this._GenerateOption_1.Text = "Leave";
			this._GenerateOption_1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._GenerateOption_1.Visible = true;
			//this._GenerateOption_1.CheckedChanged += new System.EventHandler(this.GenerateOption_CheckedChanged);
			// 
			// _GenerateOption_0
			// 
			//this._GenerateOption_0.AllowDrop = true;
			this._GenerateOption_0.Appearance = System.Windows.Forms.Appearance.Normal;
			this._GenerateOption_0.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._GenerateOption_0.CausesValidation = true;
			this._GenerateOption_0.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._GenerateOption_0.Checked = false;
			this._GenerateOption_0.Enabled = true;
			this._GenerateOption_0.ForeColor = System.Drawing.SystemColors.ControlText;
			this._GenerateOption_0.Location = new System.Drawing.Point(144, 9);
			this._GenerateOption_0.Name = "_GenerateOption_0";
			this._GenerateOption_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._GenerateOption_0.Size = new System.Drawing.Size(70, 16);
			this._GenerateOption_0.TabIndex = 64;
			this._GenerateOption_0.TabStop = true;
			this._GenerateOption_0.Text = "Payroll";
			this._GenerateOption_0.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._GenerateOption_0.Visible = true;
			//this._GenerateOption_0.CheckedChanged += new System.EventHandler(this.GenerateOption_CheckedChanged);
			// 
			// System.Windows.Forms.Label11
			// 
			//this.Label11.AllowDrop = true;
			this.Label11.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.Label11.Text = "Generate For :";
			this.Label11.ForeColor = System.Drawing.SystemColors.WindowText;
			this.Label11.Location = new System.Drawing.Point(6, 9);
			this.Label11.Name="Label11";
			this.Label11.Size = new System.Drawing.Size(70, 14);
			this.Label11.TabIndex = 63;
			// 
			// tabBankDisk
			// 
			//this.tabBankDisk.Align = C1SizerLib.AlignSettings.asNone;
			//this.tabBankDisk.AllowDrop = true;
			this.tabBankDisk.Controls.Add(this.frmLeave);
			this.tabBankDisk.Controls.Add(this.frmResumtion);
			this.tabBankDisk.Controls.Add(this.frmEmployee);
			this.tabBankDisk.Location = new System.Drawing.Point(3, 36);
			this.tabBankDisk.Name = "tabBankDisk";
			//
			this.tabBankDisk.Size = new System.Drawing.Size(455, 326);
			this.tabBankDisk.TabIndex = 20;
			//// this.tabBankDisk.ClickEvent += new System.EventHandler(this.tabBankDisk_ClickEvent);
			// 
			// frmLeave
			// 
			//this.frmLeave.AllowDrop = true;
			this.frmLeave.BackColor = System.Drawing.Color.White;
			//this.frmLeave.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.frmLeave.Enabled = true;
			this.frmLeave.ForeColor = System.Drawing.SystemColors.ControlText;
			this.frmLeave.Location = new System.Drawing.Point(516, 23);
			this.frmLeave.Name = "frmLeave";
			this.frmLeave.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.frmLeave.Size = new System.Drawing.Size(453, 302);
			this.frmLeave.TabIndex = 22;
			this.frmLeave.Visible = true;
			// 
			// frmResumtion
			// 
			//this.frmResumtion.AllowDrop = true;
			this.frmResumtion.BackColor = System.Drawing.Color.White;
			//this.frmResumtion.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.frmResumtion.Controls.Add(this.txtDToTransDate);
			this.frmResumtion.Controls.Add(this.txtDFromTransDate);
			this.frmResumtion.Controls.Add(this.Label6);
			this.frmResumtion.Controls.Add(this.txtLeaveToTransNo);
			this.frmResumtion.Controls.Add(this.lblLeaveEmpBankName);
			this.frmResumtion.Controls.Add(this.txtLeaveEmpBankCd);
			this.frmResumtion.Controls.Add(this.Label7);
			this.frmResumtion.Controls.Add(this.txtLeaveCompBankCd);
			this.frmResumtion.Controls.Add(this.Label8);
			this.frmResumtion.Controls.Add(this.lblLeaveCompBankName);
			this.frmResumtion.Controls.Add(this._lblCommon_2);
			this.frmResumtion.Controls.Add(this.txtLeaveSponsorCd);
			this.frmResumtion.Controls.Add(this.lblLeaveSponsorName);
			this.frmResumtion.Controls.Add(this._lblCommon_3);
			this.frmResumtion.Controls.Add(this.txtLeaveProjectCd);
			this.frmResumtion.Controls.Add(this.lblLeaveProjectName);
			this.frmResumtion.Controls.Add(this.txtLeaveFilePath);
			this.frmResumtion.Controls.Add(this.Label12);
			this.frmResumtion.Controls.Add(this.txtLeaveFromTransNo);
			this.frmResumtion.Controls.Add(this.Label13);
			this.frmResumtion.Controls.Add(this.Label9);
			this.frmResumtion.Controls.Add(this.Label10);
			this.frmResumtion.Enabled = true;
			this.frmResumtion.ForeColor = System.Drawing.SystemColors.ControlText;
			this.frmResumtion.Location = new System.Drawing.Point(496, 23);
			this.frmResumtion.Name = "frmResumtion";
			this.frmResumtion.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.frmResumtion.Size = new System.Drawing.Size(453, 302);
			this.frmResumtion.TabIndex = 21;
			this.frmResumtion.Visible = true;
			// 
			// txtDToTransDate
			// 
			//this.txtDToTransDate.AllowDrop = true;
			this.txtDToTransDate.Location = new System.Drawing.Point(351, 144);
			// this.txtDToTransDate.MaxDate = 2958465;
			// this.txtDToTransDate.MinDate = -657434;
			this.txtDToTransDate.Name = "txtDToTransDate";
			// = "_";
			this.txtDToTransDate.Size = new System.Drawing.Size(94, 19);
			this.txtDToTransDate.TabIndex = 58;
			// this.txtDToTransDate.Text = "09-Oct-2012";
			// this.txtDToTransDate.Value = 41191;
			// 
			// txtDFromTransDate
			// 
			//this.txtDFromTransDate.AllowDrop = true;
			this.txtDFromTransDate.Location = new System.Drawing.Point(141, 144);
			// this.txtDFromTransDate.MaxDate = 2958465;
			// this.txtDFromTransDate.MinDate = -657434;
			this.txtDFromTransDate.Name = "txtDFromTransDate";
			// = "_";
			this.txtDFromTransDate.Size = new System.Drawing.Size(100, 19);
			this.txtDFromTransDate.TabIndex = 57;
			// this.txtDFromTransDate.Text = "09-Oct-2012";
			// this.txtDFromTransDate.Value = 41191;
			// 
			// System.Windows.Forms.Label6
			// 
			//this.Label6.AllowDrop = true;
			this.Label6.BackColor = System.Drawing.Color.White;
			this.Label6.Text = "To Transaction No";
			this.Label6.ForeColor = System.Drawing.SystemColors.WindowText;
			this.Label6.Location = new System.Drawing.Point(15, 123);
			// this.Label6.mLabelId = 2102;
			this.Label6.Name="Label6";
			this.Label6.Size = new System.Drawing.Size(88, 14);
			this.Label6.TabIndex = 46;
			// 
			// txtLeaveToTransNo
			// 
			//this.txtLeaveToTransNo.AllowDrop = true;
			this.txtLeaveToTransNo.BackColor = System.Drawing.Color.White;
			// // = false;
			this.txtLeaveToTransNo.ForeColor = System.Drawing.Color.Black;
			this.txtLeaveToTransNo.Location = new System.Drawing.Point(140, 121);
			// // = (System.Windows.Forms.TextBox.DropDownTypes) 0;
			this.txtLeaveToTransNo.Name = "txtLeaveToTransNo";
			// this.txtLeaveToTransNo.ShowButton = true;
			this.txtLeaveToTransNo.Size = new System.Drawing.Size(101, 19);
			this.txtLeaveToTransNo.TabIndex = 18;
			this.txtLeaveToTransNo.Text = "";
			// this.// = "";
			// this.//this.txtLeaveToTransNo.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(//this.txtLeaveToTransNo_DropButtonClick);
			// this.txtLeaveToTransNo.Leave += new System.EventHandler(this.txtLeaveToTransNo_Leave);
			// 
			// lblLeaveEmpBankName
			// 
			//this.lblLeaveEmpBankName.AllowDrop = true;
			this.lblLeaveEmpBankName.Enabled = false;
			this.lblLeaveEmpBankName.Location = new System.Drawing.Point(243, 34);
			this.lblLeaveEmpBankName.Name = "lblLeaveEmpBankName";
			this.lblLeaveEmpBankName.Size = new System.Drawing.Size(201, 19);
			this.lblLeaveEmpBankName.TabIndex = 47;
			this.lblLeaveEmpBankName.TabStop = false;
			// 
			// txtLeaveEmpBankCd
			// 
			//this.txtLeaveEmpBankCd.AllowDrop = true;
			this.txtLeaveEmpBankCd.BackColor = System.Drawing.Color.White;
			// // = false;
			this.txtLeaveEmpBankCd.ForeColor = System.Drawing.Color.Black;
			this.txtLeaveEmpBankCd.Location = new System.Drawing.Point(140, 33);
			// // = (System.Windows.Forms.TextBox.DropDownTypes) 0;
			this.txtLeaveEmpBankCd.Name = "txtLeaveEmpBankCd";
			// this.txtLeaveEmpBankCd.ShowButton = true;
			this.txtLeaveEmpBankCd.Size = new System.Drawing.Size(101, 21);
			this.txtLeaveEmpBankCd.TabIndex = 14;
			this.txtLeaveEmpBankCd.Text = "";
			// this.// = "";
			// this.//this.txtLeaveEmpBankCd.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(//this.txtLeaveEmpBankCd_DropButtonClick);
			// this.txtLeaveEmpBankCd.Leave += new System.EventHandler(this.txtLeaveEmpBankCd_Leave);
			// 
			// System.Windows.Forms.Label7
			// 
			//this.Label7.AllowDrop = true;
			this.Label7.BackColor = System.Drawing.Color.White;
			this.Label7.Text = "Bank Code";
			this.Label7.ForeColor = System.Drawing.SystemColors.WindowText;
			this.Label7.Location = new System.Drawing.Point(15, 35);
			// this.Label7.mLabelId = 1151;
			this.Label7.Name="Label7";
			this.Label7.Size = new System.Drawing.Size(52, 14);
			this.Label7.TabIndex = 48;
			// 
			// txtLeaveCompBankCd
			// 
			//this.txtLeaveCompBankCd.AllowDrop = true;
			this.txtLeaveCompBankCd.BackColor = System.Drawing.Color.White;
			this.txtLeaveCompBankCd.ForeColor = System.Drawing.Color.Black;
			this.txtLeaveCompBankCd.Location = new System.Drawing.Point(140, 12);
			this.txtLeaveCompBankCd.Name = "txtLeaveCompBankCd";
			// this.txtLeaveCompBankCd.ShowButton = true;
			this.txtLeaveCompBankCd.Size = new System.Drawing.Size(101, 19);
			this.txtLeaveCompBankCd.TabIndex = 13;
			this.txtLeaveCompBankCd.Text = "";
			// this.// = "";
			// this.//this.txtLeaveCompBankCd.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(//this.txtLeaveCompBankCd_DropButtonClick);
			// this.txtLeaveCompBankCd.Leave += new System.EventHandler(this.txtLeaveCompBankCd_Leave);
			// 
			// System.Windows.Forms.Label8
			// 
			//this.Label8.AllowDrop = true;
			this.Label8.BackColor = System.Drawing.Color.White;
			this.Label8.Text = "Comapny Bank Account";
			this.Label8.ForeColor = System.Drawing.Color.Black;
			this.Label8.Location = new System.Drawing.Point(15, 15);
			// this.Label8.mLabelId = 2071;
			this.Label8.Name="Label8";
			this.Label8.Size = new System.Drawing.Size(116, 14);
			this.Label8.TabIndex = 49;
			// 
			// lblLeaveCompBankName
			// 
			//this.lblLeaveCompBankName.AllowDrop = true;
			this.lblLeaveCompBankName.Location = new System.Drawing.Point(243, 13);
			this.lblLeaveCompBankName.Name = "lblLeaveCompBankName";
			this.lblLeaveCompBankName.Size = new System.Drawing.Size(201, 19);
			this.lblLeaveCompBankName.TabIndex = 50;
			this.lblLeaveCompBankName.TabStop = false;
			// 
			// _lblCommon_2
			// 
			//this._lblCommon_2.AllowDrop = true;
			this._lblCommon_2.BackColor = System.Drawing.Color.White;
			this._lblCommon_2.Text = "Sponsor Code";
			this._lblCommon_2.ForeColor = System.Drawing.SystemColors.WindowText;
			this._lblCommon_2.Location = new System.Drawing.Point(15, 58);
			// // this._lblCommon_2.mLabelId = 1939;
			this._lblCommon_2.Name = "_lblCommon_2";
			this._lblCommon_2.Size = new System.Drawing.Size(67, 13);
			this._lblCommon_2.TabIndex = 51;
			// 
			// txtLeaveSponsorCd
			// 
			//this.txtLeaveSponsorCd.AllowDrop = true;
			this.txtLeaveSponsorCd.BackColor = System.Drawing.Color.White;
			// this.txtLeaveSponsorCd.bolNumericOnly = true;
			this.txtLeaveSponsorCd.ForeColor = System.Drawing.Color.Black;
			this.txtLeaveSponsorCd.Location = new System.Drawing.Point(140, 55);
			this.txtLeaveSponsorCd.MaxLength = 20;
			this.txtLeaveSponsorCd.Name = "txtLeaveSponsorCd";
			// this.txtLeaveSponsorCd.ShowButton = true;
			this.txtLeaveSponsorCd.Size = new System.Drawing.Size(101, 22);
			this.txtLeaveSponsorCd.TabIndex = 15;
			this.txtLeaveSponsorCd.Text = "";
			// this.// = "";
			// this.//this.txtLeaveSponsorCd.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(//this.txtLeaveSponsorCd_DropButtonClick);
			// this.txtLeaveSponsorCd.Leave += new System.EventHandler(this.txtLeaveSponsorCd_Leave);
			// 
			// lblLeaveSponsorName
			// 
			//this.lblLeaveSponsorName.AllowDrop = true;
			this.lblLeaveSponsorName.Location = new System.Drawing.Point(243, 55);
			this.lblLeaveSponsorName.Name = "lblLeaveSponsorName";
			this.lblLeaveSponsorName.Size = new System.Drawing.Size(201, 22);
			this.lblLeaveSponsorName.TabIndex = 52;
			this.lblLeaveSponsorName.TabStop = false;
			// 
			// _lblCommon_3
			// 
			//this._lblCommon_3.AllowDrop = true;
			this._lblCommon_3.BackColor = System.Drawing.Color.White;
			this._lblCommon_3.Text = "Project Code";
			this._lblCommon_3.ForeColor = System.Drawing.SystemColors.WindowText;
			this._lblCommon_3.Location = new System.Drawing.Point(15, 81);
			// // this._lblCommon_3.mLabelId = 2160;
			this._lblCommon_3.Name = "_lblCommon_3";
			this._lblCommon_3.Size = new System.Drawing.Size(62, 13);
			this._lblCommon_3.TabIndex = 53;
			// 
			// txtLeaveProjectCd
			// 
			//this.txtLeaveProjectCd.AllowDrop = true;
			this.txtLeaveProjectCd.BackColor = System.Drawing.Color.White;
			this.txtLeaveProjectCd.ForeColor = System.Drawing.Color.Black;
			this.txtLeaveProjectCd.Location = new System.Drawing.Point(140, 78);
			this.txtLeaveProjectCd.MaxLength = 20;
			this.txtLeaveProjectCd.Name = "txtLeaveProjectCd";
			// this.txtLeaveProjectCd.ShowButton = true;
			this.txtLeaveProjectCd.Size = new System.Drawing.Size(101, 19);
			this.txtLeaveProjectCd.TabIndex = 16;
			this.txtLeaveProjectCd.Text = "";
			// this.// = "";
			// this.//this.txtLeaveProjectCd.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(//this.txtLeaveProjectCd_DropButtonClick);
			// this.txtLeaveProjectCd.Leave += new System.EventHandler(this.txtLeaveProjectCd_Leave);
			// 
			// lblLeaveProjectName
			// 
			//this.lblLeaveProjectName.AllowDrop = true;
			this.lblLeaveProjectName.Location = new System.Drawing.Point(243, 78);
			this.lblLeaveProjectName.Name = "lblLeaveProjectName";
			this.lblLeaveProjectName.Size = new System.Drawing.Size(201, 19);
			this.lblLeaveProjectName.TabIndex = 54;
			this.lblLeaveProjectName.TabStop = false;
			// 
			// txtLeaveFilePath
			// 
			//this.txtLeaveFilePath.AllowDrop = true;
			this.txtLeaveFilePath.BackColor = System.Drawing.Color.White;
			// // = false;
			this.txtLeaveFilePath.ForeColor = System.Drawing.Color.Black;
			this.txtLeaveFilePath.Location = new System.Drawing.Point(139, 168);
			// // = (System.Windows.Forms.TextBox.DropDownTypes) 0;
			this.txtLeaveFilePath.Name = "txtLeaveFilePath";
			this.txtLeaveFilePath.Size = new System.Drawing.Size(307, 19);
			this.txtLeaveFilePath.TabIndex = 19;
			this.txtLeaveFilePath.Text = "";
			// this.// = "";
			// 
			// System.Windows.Forms.Label12
			// 
			//this.Label12.AllowDrop = true;
			this.Label12.BackColor = System.Drawing.Color.White;
			this.Label12.Text = "Bank Disk File Path";
			this.Label12.ForeColor = System.Drawing.Color.Black;
			this.Label12.Location = new System.Drawing.Point(15, 168);
			// this.Label12.mLabelId = 1917;
			this.Label12.Name="Label12";
			this.Label12.Size = new System.Drawing.Size(89, 13);
			this.Label12.TabIndex = 55;
			// 
			// txtLeaveFromTransNo
			// 
			//this.txtLeaveFromTransNo.AllowDrop = true;
			this.txtLeaveFromTransNo.BackColor = System.Drawing.Color.White;
			// // = false;
			this.txtLeaveFromTransNo.ForeColor = System.Drawing.Color.Black;
			this.txtLeaveFromTransNo.Location = new System.Drawing.Point(140, 99);
			// // = (System.Windows.Forms.TextBox.DropDownTypes) 0;
			this.txtLeaveFromTransNo.Name = "txtLeaveFromTransNo";
			// this.txtLeaveFromTransNo.ShowButton = true;
			this.txtLeaveFromTransNo.Size = new System.Drawing.Size(101, 21);
			this.txtLeaveFromTransNo.TabIndex = 17;
			this.txtLeaveFromTransNo.Text = "";
			// this.// = "";
			// this.//this.txtLeaveFromTransNo.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(//this.txtLeaveFromTransNo_DropButtonClick);
			// this.txtLeaveFromTransNo.Leave += new System.EventHandler(this.txtLeaveFromTransNo_Leave);
			// 
			// System.Windows.Forms.Label13
			// 
			//this.Label13.AllowDrop = true;
			this.Label13.BackColor = System.Drawing.Color.White;
			this.Label13.Text = "From Transaction No";
			this.Label13.ForeColor = System.Drawing.SystemColors.WindowText;
			this.Label13.Location = new System.Drawing.Point(15, 101);
			this.Label13.Name="Label13";
			this.Label13.Size = new System.Drawing.Size(100, 14);
			this.Label13.TabIndex = 56;
			// 
			// System.Windows.Forms.Label9
			// 
			//this.Label9.AllowDrop = true;
			this.Label9.BackColor = System.Drawing.Color.White;
			this.Label9.Text = "To Transaction Date";
			this.Label9.ForeColor = System.Drawing.SystemColors.WindowText;
			this.Label9.Location = new System.Drawing.Point(246, 147);
			// this.Label9.mLabelId = 2102;
			this.Label9.Name="Label9";
			this.Label9.Size = new System.Drawing.Size(97, 14);
			this.Label9.TabIndex = 59;
			// 
			// System.Windows.Forms.Label10
			// 
			//this.Label10.AllowDrop = true;
			this.Label10.BackColor = System.Drawing.Color.White;
			this.Label10.Text = "From Transaction Date";
			this.Label10.ForeColor = System.Drawing.SystemColors.WindowText;
			this.Label10.Location = new System.Drawing.Point(15, 147);
			this.Label10.Name="Label10";
			this.Label10.Size = new System.Drawing.Size(109, 14);
			this.Label10.TabIndex = 60;
			// 
			// frmEmployee
			// 
			//this.frmEmployee.AllowDrop = true;
			this.frmEmployee.BackColor = System.Drawing.Color.White;
			//this.frmEmployee.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.frmEmployee.Controls.Add(this.chkSelectAll);
			this.frmEmployee.Controls.Add(this.Label4);
			this.frmEmployee.Controls.Add(this.txtDepartmentNameTo);
			this.frmEmployee.Controls.Add(this.txtDepartmentCodeTo);
			this.frmEmployee.Controls.Add(this.txtEmpBankName);
			this.frmEmployee.Controls.Add(this.txtEmpBankAccount);
			this.frmEmployee.Controls.Add(this.Label2);
			this.frmEmployee.Controls.Add(this.txtBankAccountNo);
			this.frmEmployee.Controls.Add(this.lblMasterCode);
			this.frmEmployee.Controls.Add(this.txtFromEmpNo);
			this.frmEmployee.Controls.Add(this.lblLocationCode);
			this.frmEmployee.Controls.Add(this.txtToEmpNo);
			this.frmEmployee.Controls.Add(this.Label1_0);
			this.frmEmployee.Controls.Add(this.lblVoucherRange);
			this.frmEmployee.Controls.Add(this.txtToEmpName);
			this.frmEmployee.Controls.Add(this.txtFromEmpName);
			this.frmEmployee.Controls.Add(this.txtBankName);
			this.frmEmployee.Controls.Add(this.cmbMonth);
			this.frmEmployee.Controls.Add(this.cmbYear);
			this.frmEmployee.Controls.Add(this.lblToVoucherNo);
			this.frmEmployee.Controls.Add(this.lblFromVoucherNo);
			this.frmEmployee.Controls.Add(this._lblCommon_41);
			this.frmEmployee.Controls.Add(this.txtSponsorCd);
			this.frmEmployee.Controls.Add(this.txtDlblSponsorName);
			this.frmEmployee.Controls.Add(this._lblCommon_0);
			this.frmEmployee.Controls.Add(this.txtProjectCd);
			this.frmEmployee.Controls.Add(this.txtDProjectName);
			this.frmEmployee.Controls.Add(this.txtFilePath);
			this.frmEmployee.Controls.Add(this.Label5);
			this.frmEmployee.Controls.Add(this._lblCommon_1);
			this.frmEmployee.Controls.Add(this.txtCompanyCode);
			this.frmEmployee.Controls.Add(this.txtDlblCompanyName);
			this.frmEmployee.Controls.Add(this.txtDepartmentName);
			this.frmEmployee.Controls.Add(this.txtDepartmentCode);
			this.frmEmployee.Controls.Add(this.Label3);
			this.frmEmployee.Controls.Add(this.Shape1);
			this.frmEmployee.Enabled = true;
			this.frmEmployee.ForeColor = System.Drawing.SystemColors.ControlText;
			this.frmEmployee.Location = new System.Drawing.Point(1, 23);
			this.frmEmployee.Name = "frmEmployee";
			this.frmEmployee.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.frmEmployee.Size = new System.Drawing.Size(453, 302);
			this.frmEmployee.TabIndex = 23;
			this.frmEmployee.Visible = true;
			// 
			// chkSelectAll
			// 
			//this.chkSelectAll.AllowDrop = true;
			this.chkSelectAll.Appearance = System.Windows.Forms.Appearance.Normal;
			this.chkSelectAll.BackColor = System.Drawing.Color.White;
			this.chkSelectAll.CausesValidation = true;
			this.chkSelectAll.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkSelectAll.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this.chkSelectAll.Enabled = true;
			this.chkSelectAll.ForeColor = System.Drawing.SystemColors.ControlText;
			this.chkSelectAll.Location = new System.Drawing.Point(140, 200);
			this.chkSelectAll.Name = "chkSelectAll";
			this.chkSelectAll.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.chkSelectAll.Size = new System.Drawing.Size(100, 13);
			this.chkSelectAll.TabIndex = 9;
			this.chkSelectAll.TabStop = true;
			this.chkSelectAll.Text = "Select All";
			this.chkSelectAll.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkSelectAll.Visible = true;
			//this.chkSelectAll.CheckStateChanged += new System.EventHandler(this.chkSelectAll_CheckStateChanged);
			// 
			// System.Windows.Forms.Label4
			// 
			//this.Label4.AllowDrop = true;
			this.Label4.BackColor = System.Drawing.Color.White;
			this.Label4.Text = "To Department";
			this.Label4.ForeColor = System.Drawing.SystemColors.WindowText;
			this.Label4.Location = new System.Drawing.Point(14, 120);
			// this.Label4.mLabelId = 2102;
			this.Label4.Name="Label4";
			this.Label4.Size = new System.Drawing.Size(70, 14);
			this.Label4.TabIndex = 24;
			// 
			// txtDepartmentNameTo
			// 
			//this.txtDepartmentNameTo.AllowDrop = true;
			this.txtDepartmentNameTo.Enabled = false;
			this.txtDepartmentNameTo.Location = new System.Drawing.Point(242, 118);
			this.txtDepartmentNameTo.Name = "txtDepartmentNameTo";
			this.txtDepartmentNameTo.Size = new System.Drawing.Size(201, 19);
			this.txtDepartmentNameTo.TabIndex = 25;
			// 
			// txtDepartmentCodeTo
			// 
			//this.txtDepartmentCodeTo.AllowDrop = true;
			this.txtDepartmentCodeTo.BackColor = System.Drawing.Color.White;
			// // = false;
			this.txtDepartmentCodeTo.ForeColor = System.Drawing.Color.Black;
			this.txtDepartmentCodeTo.Location = new System.Drawing.Point(139, 118);
			// // = (System.Windows.Forms.TextBox.DropDownTypes) 0;
			this.txtDepartmentCodeTo.Name = "txtDepartmentCodeTo";
			// this.txtDepartmentCodeTo.ShowButton = true;
			this.txtDepartmentCodeTo.Size = new System.Drawing.Size(101, 19);
			this.txtDepartmentCodeTo.TabIndex = 5;
			this.txtDepartmentCodeTo.Text = "";
			// this.// = "";
			// this.//this.txtDepartmentCodeTo.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(//this.txtDepartmentCodeTo_DropButtonClick);
			// this.txtDepartmentCodeTo.Leave += new System.EventHandler(this.txtDepartmentCodeTo_Leave);
			// 
			// txtEmpBankName
			// 
			//this.txtEmpBankName.AllowDrop = true;
			this.txtEmpBankName.Enabled = false;
			this.txtEmpBankName.Location = new System.Drawing.Point(242, 31);
			this.txtEmpBankName.Name = "txtEmpBankName";
			this.txtEmpBankName.Size = new System.Drawing.Size(201, 19);
			this.txtEmpBankName.TabIndex = 26;
			this.txtEmpBankName.TabStop = false;
			// 
			// txtEmpBankAccount
			// 
			//this.txtEmpBankAccount.AllowDrop = true;
			this.txtEmpBankAccount.BackColor = System.Drawing.Color.White;
			// // = false;
			this.txtEmpBankAccount.ForeColor = System.Drawing.Color.Black;
			this.txtEmpBankAccount.Location = new System.Drawing.Point(139, 30);
			// // = (System.Windows.Forms.TextBox.DropDownTypes) 0;
			this.txtEmpBankAccount.Name = "txtEmpBankAccount";
			// this.txtEmpBankAccount.ShowButton = true;
			this.txtEmpBankAccount.Size = new System.Drawing.Size(101, 21);
			this.txtEmpBankAccount.TabIndex = 1;
			this.txtEmpBankAccount.Text = "";
			// this.// = "";
			// this.//this.txtEmpBankAccount.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(//this.txtEmpBankAccount_DropButtonClick);
			// this.txtEmpBankAccount.Leave += new System.EventHandler(this.txtEmpBankAccount_Leave);
			// 
			// System.Windows.Forms.Label2
			// 
			//this.Label2.AllowDrop = true;
			this.Label2.BackColor = System.Drawing.Color.White;
			this.Label2.Text = "Bank Code";
			this.Label2.ForeColor = System.Drawing.SystemColors.WindowText;
			this.Label2.Location = new System.Drawing.Point(14, 32);
			// this.Label2.mLabelId = 1151;
			this.Label2.Name="Label2";
			this.Label2.Size = new System.Drawing.Size(52, 14);
			this.Label2.TabIndex = 27;
			// 
			// txtBankAccountNo
			// 
			//this.txtBankAccountNo.AllowDrop = true;
			this.txtBankAccountNo.BackColor = System.Drawing.Color.White;
			this.txtBankAccountNo.ForeColor = System.Drawing.Color.Black;
			this.txtBankAccountNo.Location = new System.Drawing.Point(139, 9);
			this.txtBankAccountNo.Name = "txtBankAccountNo";
			// this.txtBankAccountNo.ShowButton = true;
			this.txtBankAccountNo.Size = new System.Drawing.Size(101, 19);
			this.txtBankAccountNo.TabIndex = 0;
			this.txtBankAccountNo.Text = "";
			// this.// = "";
			// this.//this.txtBankAccountNo.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(//this.txtBankAccountNo_DropButtonClick);
			// this.txtBankAccountNo.Leave += new System.EventHandler(this.txtBankAccountNo_Leave);
			// 
			// lblMasterCode
			// 
			//this.lblMasterCode.AllowDrop = true;
			this.lblMasterCode.BackColor = System.Drawing.Color.White;
			this.lblMasterCode.Text = "Comapny Bank Account";
			this.lblMasterCode.ForeColor = System.Drawing.Color.Black;
			this.lblMasterCode.Location = new System.Drawing.Point(14, 12);
			// // this.lblMasterCode.mLabelId = 2071;
			this.lblMasterCode.Name = "lblMasterCode";
			this.lblMasterCode.Size = new System.Drawing.Size(116, 14);
			this.lblMasterCode.TabIndex = 28;
			// 
			// txtFromEmpNo
			// 
			//this.txtFromEmpNo.AllowDrop = true;
			this.txtFromEmpNo.BackColor = System.Drawing.Color.White;
			this.txtFromEmpNo.ForeColor = System.Drawing.Color.Black;
			this.txtFromEmpNo.Location = new System.Drawing.Point(139, 158);
			this.txtFromEmpNo.Name = "txtFromEmpNo";
			// this.txtFromEmpNo.ShowButton = true;
			this.txtFromEmpNo.Size = new System.Drawing.Size(101, 19);
			this.txtFromEmpNo.TabIndex = 7;
			this.txtFromEmpNo.Text = "";
			// this.// = "";
			// this.//this.txtFromEmpNo.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(//this.txtFromEmpNo_DropButtonClick);
			// this.txtFromEmpNo.Leave += new System.EventHandler(this.TxtFromEmpno_Leave);
			// 
			// lblLocationCode
			// 
			//this.lblLocationCode.AllowDrop = true;
			this.lblLocationCode.BackColor = System.Drawing.Color.White;
			this.lblLocationCode.Text = "From Employee";
			this.lblLocationCode.ForeColor = System.Drawing.Color.Black;
			this.lblLocationCode.Location = new System.Drawing.Point(14, 160);
			// // this.lblLocationCode.mLabelId = 1914;
			this.lblLocationCode.Name = "lblLocationCode";
			this.lblLocationCode.Size = new System.Drawing.Size(73, 14);
			this.lblLocationCode.TabIndex = 29;
			// 
			// txtToEmpNo
			// 
			//this.txtToEmpNo.AllowDrop = true;
			this.txtToEmpNo.BackColor = System.Drawing.Color.White;
			this.txtToEmpNo.ForeColor = System.Drawing.Color.Black;
			this.txtToEmpNo.Location = new System.Drawing.Point(139, 178);
			this.txtToEmpNo.Name = "txtToEmpNo";
			// this.txtToEmpNo.ShowButton = true;
			this.txtToEmpNo.Size = new System.Drawing.Size(101, 19);
			this.txtToEmpNo.TabIndex = 8;
			this.txtToEmpNo.Text = "";
			// this.// = "";
			// this.//this.txtToEmpNo.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(//this.txtToEmpNo_DropButtonClick);
			// this.txtToEmpNo.Leave += new System.EventHandler(this.TxtToEmpNo_Leave);
			// 
			// Label1_0
			// 
			//this.Label1_0.AllowDrop = true;
			this.Label1_0.BackColor = System.Drawing.Color.White;
			this.Label1_0.Text = "To Employee";
			this.Label1_0.ForeColor = System.Drawing.Color.Black;
			this.Label1_0.Location = new System.Drawing.Point(14, 180);
			// this.Label1_0.mLabelId = 1915;
			this.Label1_0.Name = "Label1_0";
			this.Label1_0.Size = new System.Drawing.Size(61, 14);
			this.Label1_0.TabIndex = 30;
			// 
			// lblVoucherRange
			// 
			//this.lblVoucherRange.AllowDrop = true;
			this.lblVoucherRange.BackColor = System.Drawing.Color.White;
			this.lblVoucherRange.Text = " Period ";
			this.lblVoucherRange.ForeColor = System.Drawing.Color.Black;
			this.lblVoucherRange.Location = new System.Drawing.Point(11, 233);
			// // this.lblVoucherRange.mLabelId = 1916;
			this.lblVoucherRange.Name = "lblVoucherRange";
			this.lblVoucherRange.Size = new System.Drawing.Size(36, 13);
			this.lblVoucherRange.TabIndex = 31;
			// 
			// txtToEmpName
			// 
			//this.txtToEmpName.AllowDrop = true;
			this.txtToEmpName.Location = new System.Drawing.Point(242, 178);
			this.txtToEmpName.Name = "txtToEmpName";
			this.txtToEmpName.Size = new System.Drawing.Size(201, 19);
			this.txtToEmpName.TabIndex = 32;
			this.txtToEmpName.TabStop = false;
			// 
			// txtFromEmpName
			// 
			//this.txtFromEmpName.AllowDrop = true;
			this.txtFromEmpName.Location = new System.Drawing.Point(242, 158);
			this.txtFromEmpName.Name = "txtFromEmpName";
			this.txtFromEmpName.Size = new System.Drawing.Size(201, 19);
			this.txtFromEmpName.TabIndex = 33;
			this.txtFromEmpName.TabStop = false;
			// 
			// txtBankName
			// 
			//this.txtBankName.AllowDrop = true;
			this.txtBankName.Location = new System.Drawing.Point(242, 10);
			this.txtBankName.Name = "txtBankName";
			this.txtBankName.Size = new System.Drawing.Size(201, 19);
			this.txtBankName.TabIndex = 34;
			this.txtBankName.TabStop = false;
			// 
			// cmbMonth
			// 
			//this.cmbMonth.AllowDrop = true;
			this.cmbMonth.Location = new System.Drawing.Point(278, 262);
			this.cmbMonth.Name = "cmbMonth";
			this.cmbMonth.Size = new System.Drawing.Size(79, 21);
			this.cmbMonth.TabIndex = 12;
			// 
			// cmbYear
			// 
			//this.cmbYear.AllowDrop = true;
			this.cmbYear.Location = new System.Drawing.Point(136, 264);
			this.cmbYear.Name = "cmbYear";
			this.cmbYear.Size = new System.Drawing.Size(87, 21);
			this.cmbYear.TabIndex = 11;
			// 
			// lblToVoucherNo
			// 
			//this.lblToVoucherNo.AllowDrop = true;
			this.lblToVoucherNo.BackColor = System.Drawing.Color.White;
			this.lblToVoucherNo.Text = "Month";
			this.lblToVoucherNo.ForeColor = System.Drawing.Color.Black;
			this.lblToVoucherNo.Location = new System.Drawing.Point(241, 266);
			// // this.lblToVoucherNo.mLabelId = 1918;
			this.lblToVoucherNo.Name = "lblToVoucherNo";
			this.lblToVoucherNo.Size = new System.Drawing.Size(30, 13);
			this.lblToVoucherNo.TabIndex = 35;
			// 
			// lblFromVoucherNo
			// 
			//this.lblFromVoucherNo.AllowDrop = true;
			this.lblFromVoucherNo.BackColor = System.Drawing.Color.White;
			this.lblFromVoucherNo.Text = "Year";
			this.lblFromVoucherNo.ForeColor = System.Drawing.Color.Black;
			this.lblFromVoucherNo.Location = new System.Drawing.Point(48, 265);
			// // this.lblFromVoucherNo.mLabelId = 1917;
			this.lblFromVoucherNo.Name = "lblFromVoucherNo";
			this.lblFromVoucherNo.Size = new System.Drawing.Size(22, 13);
			this.lblFromVoucherNo.TabIndex = 36;
			// 
			// _lblCommon_41
			// 
			//this._lblCommon_41.AllowDrop = true;
			this._lblCommon_41.BackColor = System.Drawing.Color.White;
			this._lblCommon_41.Text = "Sponsor Code";
			this._lblCommon_41.ForeColor = System.Drawing.SystemColors.WindowText;
			this._lblCommon_41.Location = new System.Drawing.Point(14, 55);
			// // this._lblCommon_41.mLabelId = 1939;
			this._lblCommon_41.Name = "_lblCommon_41";
			this._lblCommon_41.Size = new System.Drawing.Size(67, 13);
			this._lblCommon_41.TabIndex = 37;
			// 
			// txtSponsorCd
			// 
			//this.txtSponsorCd.AllowDrop = true;
			this.txtSponsorCd.BackColor = System.Drawing.Color.White;
			// this.txtSponsorCd.bolNumericOnly = true;
			this.txtSponsorCd.ForeColor = System.Drawing.Color.Black;
			this.txtSponsorCd.Location = new System.Drawing.Point(139, 52);
			this.txtSponsorCd.MaxLength = 20;
			this.txtSponsorCd.Name = "txtSponsorCd";
			// this.txtSponsorCd.ShowButton = true;
			this.txtSponsorCd.Size = new System.Drawing.Size(101, 22);
			this.txtSponsorCd.TabIndex = 2;
			this.txtSponsorCd.Text = "";
			// this.// = "";
			// this.//this.txtSponsorCd.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(//this.txtSponsorCd_DropButtonClick);
			// this.txtSponsorCd.Leave += new System.EventHandler(this.txtSponsorCd_Leave);
			// 
			// txtDlblSponsorName
			// 
			//this.txtDlblSponsorName.AllowDrop = true;
			this.txtDlblSponsorName.Location = new System.Drawing.Point(242, 52);
			this.txtDlblSponsorName.Name = "txtDlblSponsorName";
			this.txtDlblSponsorName.Size = new System.Drawing.Size(201, 22);
			this.txtDlblSponsorName.TabIndex = 38;
			this.txtDlblSponsorName.TabStop = false;
			// 
			// _lblCommon_0
			// 
			//this._lblCommon_0.AllowDrop = true;
			this._lblCommon_0.BackColor = System.Drawing.Color.White;
			this._lblCommon_0.Text = "Project Code";
			this._lblCommon_0.ForeColor = System.Drawing.SystemColors.WindowText;
			this._lblCommon_0.Location = new System.Drawing.Point(14, 78);
			// // this._lblCommon_0.mLabelId = 2160;
			this._lblCommon_0.Name = "_lblCommon_0";
			this._lblCommon_0.Size = new System.Drawing.Size(62, 13);
			this._lblCommon_0.TabIndex = 39;
			// 
			// txtProjectCd
			// 
			//this.txtProjectCd.AllowDrop = true;
			this.txtProjectCd.BackColor = System.Drawing.Color.White;
			this.txtProjectCd.ForeColor = System.Drawing.Color.Black;
			this.txtProjectCd.Location = new System.Drawing.Point(139, 75);
			this.txtProjectCd.MaxLength = 20;
			this.txtProjectCd.Name = "txtProjectCd";
			// this.txtProjectCd.ShowButton = true;
			this.txtProjectCd.Size = new System.Drawing.Size(101, 19);
			this.txtProjectCd.TabIndex = 3;
			this.txtProjectCd.Text = "";
			// this.// = "";
			// this.//this.txtProjectCd.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(//this.txtProjectCd_DropButtonClick);
			// this.txtProjectCd.Leave += new System.EventHandler(this.txtProjectCd_Leave);
			// 
			// txtDProjectName
			// 
			//this.txtDProjectName.AllowDrop = true;
			this.txtDProjectName.Location = new System.Drawing.Point(242, 75);
			this.txtDProjectName.Name = "txtDProjectName";
			this.txtDProjectName.Size = new System.Drawing.Size(201, 19);
			this.txtDProjectName.TabIndex = 40;
			this.txtDProjectName.TabStop = false;
			// 
			// txtFilePath
			// 
			//this.txtFilePath.AllowDrop = true;
			this.txtFilePath.BackColor = System.Drawing.Color.White;
			// // = false;
			this.txtFilePath.ForeColor = System.Drawing.Color.Black;
			this.txtFilePath.Location = new System.Drawing.Point(138, 216);
			// // = (System.Windows.Forms.TextBox.DropDownTypes) 0;
			this.txtFilePath.Name = "txtFilePath";
			this.txtFilePath.Size = new System.Drawing.Size(307, 19);
			this.txtFilePath.TabIndex = 10;
			this.txtFilePath.Text = "";
			// this.// = "";
			// 
			// System.Windows.Forms.Label5
			// 
			//this.Label5.AllowDrop = true;
			this.Label5.BackColor = System.Drawing.Color.White;
			this.Label5.Text = "Bank Disk File Path";
			this.Label5.ForeColor = System.Drawing.Color.Black;
			this.Label5.Location = new System.Drawing.Point(14, 216);
			// this.Label5.mLabelId = 1917;
			this.Label5.Name="Label5";
			this.Label5.Size = new System.Drawing.Size(89, 13);
			this.Label5.TabIndex = 41;
			// 
			// _lblCommon_1
			// 
			//this._lblCommon_1.AllowDrop = true;
			this._lblCommon_1.BackColor = System.Drawing.Color.White;
			this._lblCommon_1.Text = "Company Code";
			this._lblCommon_1.ForeColor = System.Drawing.SystemColors.WindowText;
			this._lblCommon_1.Location = new System.Drawing.Point(14, 141);
			// // this._lblCommon_1.mLabelId = 1927;
			this._lblCommon_1.Name = "_lblCommon_1";
			this._lblCommon_1.Size = new System.Drawing.Size(73, 13);
			this._lblCommon_1.TabIndex = 42;
			// 
			// txtCompanyCode
			// 
			//this.txtCompanyCode.AllowDrop = true;
			this.txtCompanyCode.BackColor = System.Drawing.Color.White;
			this.txtCompanyCode.ForeColor = System.Drawing.Color.Black;
			this.txtCompanyCode.Location = new System.Drawing.Point(139, 138);
			this.txtCompanyCode.MaxLength = 20;
			this.txtCompanyCode.Name = "txtCompanyCode";
			// this.txtCompanyCode.ShowButton = true;
			this.txtCompanyCode.Size = new System.Drawing.Size(101, 19);
			this.txtCompanyCode.TabIndex = 6;
			this.txtCompanyCode.Text = "";
			// this.// = "";
			// this.//this.txtCompanyCode.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(//this.txtCompanyCode_DropButtonClick);
			// this.txtCompanyCode.Leave += new System.EventHandler(this.txtCompanyCode_Leave);
			// 
			// txtDlblCompanyName
			// 
			//this.txtDlblCompanyName.AllowDrop = true;
			this.txtDlblCompanyName.Location = new System.Drawing.Point(242, 138);
			this.txtDlblCompanyName.Name = "txtDlblCompanyName";
			this.txtDlblCompanyName.Size = new System.Drawing.Size(201, 19);
			this.txtDlblCompanyName.TabIndex = 43;
			this.txtDlblCompanyName.TabStop = false;
			// 
			// txtDepartmentName
			// 
			//this.txtDepartmentName.AllowDrop = true;
			this.txtDepartmentName.Enabled = false;
			this.txtDepartmentName.Location = new System.Drawing.Point(242, 97);
			this.txtDepartmentName.Name = "txtDepartmentName";
			this.txtDepartmentName.Size = new System.Drawing.Size(201, 19);
			this.txtDepartmentName.TabIndex = 44;
			this.txtDepartmentName.TabStop = false;
			// 
			// txtDepartmentCode
			// 
			//this.txtDepartmentCode.AllowDrop = true;
			this.txtDepartmentCode.BackColor = System.Drawing.Color.White;
			// // = false;
			this.txtDepartmentCode.ForeColor = System.Drawing.Color.Black;
			this.txtDepartmentCode.Location = new System.Drawing.Point(139, 96);
			// // = (System.Windows.Forms.TextBox.DropDownTypes) 0;
			this.txtDepartmentCode.Name = "txtDepartmentCode";
			// this.txtDepartmentCode.ShowButton = true;
			this.txtDepartmentCode.Size = new System.Drawing.Size(101, 21);
			this.txtDepartmentCode.TabIndex = 4;
			this.txtDepartmentCode.Text = "";
			// this.// = "";
			// this.//this.txtDepartmentCode.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(//this.txtDepartmentCode_DropButtonClick);
			// this.txtDepartmentCode.Leave += new System.EventHandler(this.txtDepartmentCode_Leave);
			// 
			// System.Windows.Forms.Label3
			// 
			//this.Label3.AllowDrop = true;
			this.Label3.BackColor = System.Drawing.Color.White;
			this.Label3.Text = "From Department";
			this.Label3.ForeColor = System.Drawing.SystemColors.WindowText;
			this.Label3.Location = new System.Drawing.Point(14, 98);
			// this.Label3.mLabelId = 1973;
			this.Label3.Name="Label3";
			this.Label3.Size = new System.Drawing.Size(82, 14);
			this.Label3.TabIndex = 45;
			// 
			// Shape1
			// 
			//this.Shape1.AllowDrop = true;
			this.Shape1.BackColor = System.Drawing.SystemColors.Window;
			// = 0;
			//
			this.Shape1.Enabled = false;
			////this.Shape1.FillColor = System.Drawing.Color.Black;
			////this.Shape1.FillStyle = 1;
			this.Shape1.Location = new System.Drawing.Point(13, 249);
			this.Shape1.Name = "Shape1";
			this.Shape1.Size = new System.Drawing.Size(433, 46);
			this.Shape1.Visible = true;
			// 
			// cmdOKCancel
			// 
			//this.cmdOKCancel.AllowDrop = true;
			this.cmdOKCancel.DisplayButton = 0;
			this.cmdOKCancel.Location = new System.Drawing.Point(81, 366);
			this.cmdOKCancel.Name = "cmdOKCancel";
			this.cmdOKCancel.OkCaption = "&Ok";
			this.cmdOKCancel.Size = new System.Drawing.Size(205, 29);
			this.cmdOKCancel.TabIndex = 61;
			////this.cmdOKCancel.CancelClick += new UCOkCancel.CancelClickHandler(this.cmdOKCancel_CancelClick);
			////this.cmdOKCancel.OKClick += new UCOkCancel.OKClickHandler(this.cmdOKCancel_OKClick);
			// 
			// frmPayGenerateBankFile
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.ClientSize = new System.Drawing.Size(718, 505);
			this.ControlBox = false;
			this.Controls.Add(this.cmdPrintReport);
			this.Controls.Add(this.Frame1);
			this.Controls.Add(this.tabBankDisk);
			this.Controls.Add(this.cmdOKCancel);
			//this.Icon = (System.Drawing.Icon) resources.GetObject("frmPayGenerateBankFile.Icon");
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(304, 145);
			this.MaximizeBox = true;
			this.MinimizeBox = true;
			this.Name = "frmPayGenerateBankFile";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Generate Payroll Bank File";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			// this.Activated += new System.EventHandler(this.frmPayGenerateBankFile_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
			// this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
			//((System.ComponentModel.ISupportInitialize) this.tabBankDisk).EndInit();
			this.Frame1.ResumeLayout(false);
			this.tabBankDisk.ResumeLayout(false);
			this.frmResumtion.ResumeLayout(false);
			this.frmEmployee.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		// 
		void InitializelblCommon()
		{
			this.lblCommon = new System.Windows.Forms.Label[42];
			this.lblCommon[2] = _lblCommon_2;
			this.lblCommon[3] = _lblCommon_3;
			this.lblCommon[41] = _lblCommon_41;
			this.lblCommon[0] = _lblCommon_0;
			this.lblCommon[1] = _lblCommon_1;
		}
		void InitializeSystemWindowsFormsLabel1()
		{
			this.Label1 = new System.Windows.Forms.Label[1];
			this.Label1[0] = Label1_0;
		}
		void InitializeGenerateOption()
		{
			this.GenerateOption = new System.Windows.Forms.RadioButton[2];
			this.GenerateOption[1] = _GenerateOption_1;
			this.GenerateOption[0] = _GenerateOption_0;
		}
		#endregion
	}
}//ENDSHERE
