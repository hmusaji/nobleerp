
namespace Xtreme
{
	partial class frmPaySalaryVariation
	{

		#region "Upgrade Support "
		private static frmPaySalaryVariation m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmPaySalaryVariation DefInstance
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
		public static frmPaySalaryVariation CreateInstance()
		{
			frmPaySalaryVariation theInstance = new frmPaySalaryVariation();
			
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
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "chkIsReplacement", "chkBudget", "_txtCommonTextBox_72", "_lblCommon_74", "_txtDisplayLabel_18", "_txtCommonTextBox_6", "_lblCommon_8", "_txtDisplayLabel_7", "_fraEmployeeInformation_3", "cmdSubmmitApproval", "txtDlblAppTemplateName", "txtApprovalTemplate", "_lblCommonLabel_28", "Frame3", "_lblCommon_107", "txtoldBankName", "txtOldBankCd", "txtOldBankAccountNo", "_lblCommon_4", "txtOldRatePerDay", "_lblCommonLabel_11", "_System.Windows.Forms.Label1_9", "_cmbCommon_1", "txtNewBankName", "txtNewBankCd", "txtNewBankAccountNo", "_lblCommon_1", "txtNewRatePerDay", "_lblCommonLabel_13", "_System.Windows.Forms.Label1_0", "_cmbCommon_0", "_lblCommon_2", "txtOldCompBankName", "txtoldCompBank", "_lblCommon_0", "_lblCommon_3", "txtNewCompBankName", "txtNewCompBank", "txtOldGrade", "_lblCommon_104", "txtDGradeName", "txtNewGrade", "_lblCommon_5", "txtDNewGradeName", "txtOldAccountNo", "_lblCommon_6", "txtNewAccountNo", "_lblCommon_7", "txtDlblDefaultProject", "txtDefaultProjectDispl", "lblDefaultProject", "txtDlblNewDefaultProject", "txtDefaultProjectNew", "System.Windows.Forms.Label2", "Frame2", "Column_0_grdVoucherDetails", "Column_1_grdVoucherDetails", "grdVoucherDetails", "txtTempDate", "Column_0_cmbMastersList", "Column_1_cmbMastersList", "cmbMastersList", "Frame1", "tabSalaryVariation", "_txtCommonTextBox_11", "_lblCommonLabel_9", "_lblCommonLabel_12", "_lblCommonLabel_4", "_lblCommonLabel_2", "_lblCommonLabel_5", "_lblCommonLabel_6", "txtVoucherDate", "_txtCommonTextBox_0", "_lblCommonLabel_23", "_lblCommonLabel_21", "System.Windows.Forms.Label12", "_txtCommonTextBox_2", "_lblCommonLabel_0", "_txtCommonTextBox_3", "_txtDisplayLabel_1", "_txtDisplayLabel_4", "_txtDisplayLabel_5", "_txtDisplayLabel_6", "_lblCommonLabel_1", "_txtDisplayLabel_2", "_txtDisplayLabel_3", "_txtCommonTextBox_1", "_txtDisplayLabel_0", "_txtDisplayLabel_8", "_lblCommonLabel_7", "_txtDisplayLabel_10", "_txtCommonTextBox_4", "_txtCommonTextBox_5", "_lblCommonLabel_3", "_lblCommonLabel_8", "cmbType", "_lblCommonLabel_10", "txtEffectiveDate", "fraTabPage0", "System.Windows.Forms.Label1", "cmbCommon", "fraEmployeeInformation", "lblCommon", "lblCommonLabel", "txtCommonTextBox", "txtDisplayLabel"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public System.Windows.Forms.CheckBox chkIsReplacement;
		public System.Windows.Forms.CheckBox chkBudget;
		private System.Windows.Forms.TextBox _txtCommonTextBox_72;
		private System.Windows.Forms.Label _lblCommon_74;
		private System.Windows.Forms.Label _txtDisplayLabel_18;
		private System.Windows.Forms.TextBox _txtCommonTextBox_6;
		private System.Windows.Forms.Label _lblCommon_8;
		private System.Windows.Forms.Label _txtDisplayLabel_7;
		private System.Windows.Forms.Panel _fraEmployeeInformation_3;
		public System.Windows.Forms.Button cmdSubmmitApproval;
		public System.Windows.Forms.Label txtDlblAppTemplateName;
		public System.Windows.Forms.TextBox txtApprovalTemplate;
		private System.Windows.Forms.Label _lblCommonLabel_28;
		public System.Windows.Forms.Panel Frame3;
		private System.Windows.Forms.Label _lblCommon_107;
		public System.Windows.Forms.Label txtoldBankName;
		public System.Windows.Forms.TextBox txtOldBankCd;
		public System.Windows.Forms.TextBox txtOldBankAccountNo;
		private System.Windows.Forms.Label _lblCommon_4;
		public System.Windows.Forms.TextBox txtOldRatePerDay;
		private System.Windows.Forms.Label _lblCommonLabel_11;
		private System.Windows.Forms.Label _System.Windows.Forms.Label1_9;
		private System.Windows.Forms.ComboBox _cmbCommon_1;
		public System.Windows.Forms.Label txtNewBankName;
		public System.Windows.Forms.TextBox txtNewBankCd;
		public System.Windows.Forms.TextBox txtNewBankAccountNo;
		private System.Windows.Forms.Label _lblCommon_1;
		public System.Windows.Forms.TextBox txtNewRatePerDay;
		private System.Windows.Forms.Label _lblCommonLabel_13;
		private System.Windows.Forms.Label _System.Windows.Forms.Label1_0;
		private System.Windows.Forms.ComboBox _cmbCommon_0;
		private System.Windows.Forms.Label _lblCommon_2;
		public System.Windows.Forms.Label txtOldCompBankName;
		public System.Windows.Forms.TextBox txtoldCompBank;
		private System.Windows.Forms.Label _lblCommon_0;
		private System.Windows.Forms.Label _lblCommon_3;
		public System.Windows.Forms.Label txtNewCompBankName;
		public System.Windows.Forms.TextBox txtNewCompBank;
		public System.Windows.Forms.TextBox txtOldGrade;
		private System.Windows.Forms.Label _lblCommon_104;
		public System.Windows.Forms.Label txtDGradeName;
		public System.Windows.Forms.TextBox txtNewGrade;
		private System.Windows.Forms.Label _lblCommon_5;
		public System.Windows.Forms.Label txtDNewGradeName;
		public System.Windows.Forms.TextBox txtOldAccountNo;
		private System.Windows.Forms.Label _lblCommon_6;
		public System.Windows.Forms.TextBox txtNewAccountNo;
		private System.Windows.Forms.Label _lblCommon_7;
		public System.Windows.Forms.Label txtDlblDefaultProject;
		public System.Windows.Forms.TextBox txtDefaultProjectDispl;
		public System.Windows.Forms.Label lblDefaultProject;
		public System.Windows.Forms.Label txtDlblNewDefaultProject;
		public System.Windows.Forms.TextBox txtDefaultProjectNew;
		public System.Windows.Forms.Label System.Windows.Forms.Label2;
		public System.Windows.Forms.Panel Frame2;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_0_grdVoucherDetails;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_1_grdVoucherDetails;
		public C1.Win.C1TrueDBGrid.C1TrueDBGrid grdVoucherDetails;
		public Syncfusion.WinForms.Input.SfDateTimeEdit txtTempDate;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_0_cmbMastersList;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_1_cmbMastersList;
		public C1.Win.C1TrueDBGrid.C1TrueDBDropdown cmbMastersList;
		public System.Windows.Forms.Panel Frame1;
		public AxC1SizerLib.AxC1Tab tabSalaryVariation;
		private System.Windows.Forms.TextBox _txtCommonTextBox_11;
		private System.Windows.Forms.Label _lblCommonLabel_9;
		private System.Windows.Forms.Label _lblCommonLabel_12;
		private System.Windows.Forms.Label _lblCommonLabel_4;
		private System.Windows.Forms.Label _lblCommonLabel_2;
		private System.Windows.Forms.Label _lblCommonLabel_5;
		private System.Windows.Forms.Label _lblCommonLabel_6;
		public Syncfusion.WinForms.Input.SfDateTimeEdit txtVoucherDate;
		private System.Windows.Forms.TextBox _txtCommonTextBox_0;
		private System.Windows.Forms.Label _lblCommonLabel_23;
		private System.Windows.Forms.Label _lblCommonLabel_21;
		public System.Windows.Forms.Label System.Windows.Forms.Label12;
		private System.Windows.Forms.TextBox _txtCommonTextBox_2;
		private System.Windows.Forms.Label _lblCommonLabel_0;
		private System.Windows.Forms.TextBox _txtCommonTextBox_3;
		private System.Windows.Forms.Label _txtDisplayLabel_1;
		private System.Windows.Forms.Label _txtDisplayLabel_4;
		private System.Windows.Forms.Label _txtDisplayLabel_5;
		private System.Windows.Forms.Label _txtDisplayLabel_6;
		private System.Windows.Forms.Label _lblCommonLabel_1;
		private System.Windows.Forms.Label _txtDisplayLabel_2;
		private System.Windows.Forms.Label _txtDisplayLabel_3;
		private System.Windows.Forms.TextBox _txtCommonTextBox_1;
		private System.Windows.Forms.Label _txtDisplayLabel_0;
		private System.Windows.Forms.Label _txtDisplayLabel_8;
		private System.Windows.Forms.Label _lblCommonLabel_7;
		private System.Windows.Forms.Label _txtDisplayLabel_10;
		private System.Windows.Forms.TextBox _txtCommonTextBox_4;
		private System.Windows.Forms.TextBox _txtCommonTextBox_5;
		private System.Windows.Forms.Label _lblCommonLabel_3;
		private System.Windows.Forms.Label _lblCommonLabel_8;
		public System.Windows.Forms.ComboBox cmbType;
		private System.Windows.Forms.Label _lblCommonLabel_10;
		public Syncfusion.WinForms.Input.SfDateTimeEdit txtEffectiveDate;
		public AxTDBContainer3D6.AxTDBContainer3D fraTabPage0;
		public System.Windows.Forms.Label[] System.Windows.Forms.Label1 = new System.Windows.Forms.Label[10];
		public System.Windows.Forms.ComboBox[] cmbCommon = new System.Windows.Forms.ComboBox[2];
		public System.Windows.Forms.Panel[] fraEmployeeInformation = new System.Windows.Forms.Panel[4];
		public System.Windows.Forms.Label[] lblCommon = new System.Windows.Forms.Label[108];
		public System.Windows.Forms.Label[] lblCommonLabel = new System.Windows.Forms.Label[29];
		public System.Windows.Forms.TextBox[] txtCommonTextBox = new System.Windows.Forms.TextBox[73];
		public System.Windows.Forms.Label[] txtDisplayLabel = new System.Windows.Forms.Label[19];
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPaySalaryVariation));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this.tabSalaryVariation = new AxC1SizerLib.AxC1Tab();
			this._fraEmployeeInformation_3 = new System.Windows.Forms.Panel();
			this.chkIsReplacement = new System.Windows.Forms.CheckBox();
			this.chkBudget = new System.Windows.Forms.CheckBox();
			this._txtCommonTextBox_72 = new System.Windows.Forms.TextBox();
			this._lblCommon_74 = new System.Windows.Forms.Label();
			this._txtDisplayLabel_18 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_6 = new System.Windows.Forms.TextBox();
			this._lblCommon_8 = new System.Windows.Forms.Label();
			this._txtDisplayLabel_7 = new System.Windows.Forms.Label();
			this.Frame3 = new System.Windows.Forms.Panel();
			this.cmdSubmmitApproval = new System.Windows.Forms.Button();
			this.txtDlblAppTemplateName = new System.Windows.Forms.Label();
			this.txtApprovalTemplate = new System.Windows.Forms.TextBox();
			this._lblCommonLabel_28 = new System.Windows.Forms.Label();
			this.Frame2 = new System.Windows.Forms.Panel();
			this._lblCommon_107 = new System.Windows.Forms.Label();
			this.txtoldBankName = new System.Windows.Forms.Label();
			this.txtOldBankCd = new System.Windows.Forms.TextBox();
			this.txtOldBankAccountNo = new System.Windows.Forms.TextBox();
			this._lblCommon_4 = new System.Windows.Forms.Label();
			this.txtOldRatePerDay = new System.Windows.Forms.TextBox();
			this._lblCommonLabel_11 = new System.Windows.Forms.Label();
			this._System.Windows.Forms.Label1_9 = new System.Windows.Forms.Label();
			this._cmbCommon_1 = new System.Windows.Forms.ComboBox();
			this.txtNewBankName = new System.Windows.Forms.Label();
			this.txtNewBankCd = new System.Windows.Forms.TextBox();
			this.txtNewBankAccountNo = new System.Windows.Forms.TextBox();
			this._lblCommon_1 = new System.Windows.Forms.Label();
			this.txtNewRatePerDay = new System.Windows.Forms.TextBox();
			this._lblCommonLabel_13 = new System.Windows.Forms.Label();
			this._System.Windows.Forms.Label1_0 = new System.Windows.Forms.Label();
			this._cmbCommon_0 = new System.Windows.Forms.ComboBox();
			this._lblCommon_2 = new System.Windows.Forms.Label();
			this.txtOldCompBankName = new System.Windows.Forms.Label();
			this.txtoldCompBank = new System.Windows.Forms.TextBox();
			this._lblCommon_0 = new System.Windows.Forms.Label();
			this._lblCommon_3 = new System.Windows.Forms.Label();
			this.txtNewCompBankName = new System.Windows.Forms.Label();
			this.txtNewCompBank = new System.Windows.Forms.TextBox();
			this.txtOldGrade = new System.Windows.Forms.TextBox();
			this._lblCommon_104 = new System.Windows.Forms.Label();
			this.txtDGradeName = new System.Windows.Forms.Label();
			this.txtNewGrade = new System.Windows.Forms.TextBox();
			this._lblCommon_5 = new System.Windows.Forms.Label();
			this.txtDNewGradeName = new System.Windows.Forms.Label();
			this.txtOldAccountNo = new System.Windows.Forms.TextBox();
			this._lblCommon_6 = new System.Windows.Forms.Label();
			this.txtNewAccountNo = new System.Windows.Forms.TextBox();
			this._lblCommon_7 = new System.Windows.Forms.Label();
			this.txtDlblDefaultProject = new System.Windows.Forms.Label();
			this.txtDefaultProjectDispl = new System.Windows.Forms.TextBox();
			this.lblDefaultProject = new System.Windows.Forms.Label();
			this.txtDlblNewDefaultProject = new System.Windows.Forms.Label();
			this.txtDefaultProjectNew = new System.Windows.Forms.TextBox();
			this.System.Windows.Forms.Label2 = new System.Windows.Forms.Label();
			this.Frame1 = new System.Windows.Forms.Panel();
			this.grdVoucherDetails = new C1.Win.C1TrueDBGrid.C1TrueDBGrid();
			this.Column_0_grdVoucherDetails = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.Column_1_grdVoucherDetails = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.txtTempDate = new Syncfusion.WinForms.Input.SfDateTimeEdit();
			this.cmbMastersList = new C1.Win.C1TrueDBGrid.C1TrueDBDropdown();
			this.Column_0_cmbMastersList = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.Column_1_cmbMastersList = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this._txtCommonTextBox_11 = new System.Windows.Forms.TextBox();
			this._lblCommonLabel_9 = new System.Windows.Forms.Label();
			this._lblCommonLabel_12 = new System.Windows.Forms.Label();
			this.fraTabPage0 = new AxTDBContainer3D6.AxTDBContainer3D();
			this._lblCommonLabel_4 = new System.Windows.Forms.Label();
			this._lblCommonLabel_2 = new System.Windows.Forms.Label();
			this._lblCommonLabel_5 = new System.Windows.Forms.Label();
			this._lblCommonLabel_6 = new System.Windows.Forms.Label();
			this.txtVoucherDate = new Syncfusion.WinForms.Input.SfDateTimeEdit();
			this._txtCommonTextBox_0 = new System.Windows.Forms.TextBox();
			this._lblCommonLabel_23 = new System.Windows.Forms.Label();
			this._lblCommonLabel_21 = new System.Windows.Forms.Label();
			this.System.Windows.Forms.Label12 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_2 = new System.Windows.Forms.TextBox();
			this._lblCommonLabel_0 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_3 = new System.Windows.Forms.TextBox();
			this._txtDisplayLabel_1 = new System.Windows.Forms.Label();
			this._txtDisplayLabel_4 = new System.Windows.Forms.Label();
			this._txtDisplayLabel_5 = new System.Windows.Forms.Label();
			this._txtDisplayLabel_6 = new System.Windows.Forms.Label();
			this._lblCommonLabel_1 = new System.Windows.Forms.Label();
			this._txtDisplayLabel_2 = new System.Windows.Forms.Label();
			this._txtDisplayLabel_3 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_1 = new System.Windows.Forms.TextBox();
			this._txtDisplayLabel_0 = new System.Windows.Forms.Label();
			this._txtDisplayLabel_8 = new System.Windows.Forms.Label();
			this._lblCommonLabel_7 = new System.Windows.Forms.Label();
			this._txtDisplayLabel_10 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_4 = new System.Windows.Forms.TextBox();
			this._txtCommonTextBox_5 = new System.Windows.Forms.TextBox();
			this._lblCommonLabel_3 = new System.Windows.Forms.Label();
			this._lblCommonLabel_8 = new System.Windows.Forms.Label();
			this.cmbType = new System.Windows.Forms.ComboBox();
			this._lblCommonLabel_10 = new System.Windows.Forms.Label();
			this.txtEffectiveDate = new Syncfusion.WinForms.Input.SfDateTimeEdit();
			// //((System.ComponentModel.ISupportInitialize) this.txtTempDate).BeginInit();
			// //((System.ComponentModel.ISupportInitialize) this.tabSalaryVariation).BeginInit();
			// //((System.ComponentModel.ISupportInitialize) this.fraTabPage0).BeginInit();
			this.tabSalaryVariation.SuspendLayout();
			this._fraEmployeeInformation_3.SuspendLayout();
			this.Frame3.SuspendLayout();
			this.Frame2.SuspendLayout();
			this.Frame1.SuspendLayout();
			this.grdVoucherDetails.SuspendLayout();
			this.cmbMastersList.SuspendLayout();
			this.fraTabPage0.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabSalaryVariation
			// 
			this.tabSalaryVariation.Align = C1SizerLib.AlignSettings.asNone;
			this.tabSalaryVariation.AllowDrop = true;
			this.tabSalaryVariation.Controls.Add(this._fraEmployeeInformation_3);
			this.tabSalaryVariation.Controls.Add(this.Frame3);
			this.tabSalaryVariation.Controls.Add(this.Frame2);
			this.tabSalaryVariation.Controls.Add(this.Frame1);
			this.tabSalaryVariation.Location = new System.Drawing.Point(3, 195);
			this.tabSalaryVariation.Name = "tabSalaryVariation";
			("tabSalaryVariation.OcxState");
			this.tabSalaryVariation.Size = new System.Drawing.Size(811, 223);
			this.tabSalaryVariation.TabIndex = 46;
			// 
			// _fraEmployeeInformation_3
			// 
			this._fraEmployeeInformation_3.AllowDrop = true;
			this._fraEmployeeInformation_3.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._fraEmployeeInformation_3.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._fraEmployeeInformation_3.Controls.Add(this.chkIsReplacement);
			this._fraEmployeeInformation_3.Controls.Add(this.chkBudget);
			this._fraEmployeeInformation_3.Controls.Add(this._txtCommonTextBox_72);
			this._fraEmployeeInformation_3.Controls.Add(this._lblCommon_74);
			this._fraEmployeeInformation_3.Controls.Add(this._txtDisplayLabel_18);
			this._fraEmployeeInformation_3.Controls.Add(this._txtCommonTextBox_6);
			this._fraEmployeeInformation_3.Controls.Add(this._lblCommon_8);
			this._fraEmployeeInformation_3.Controls.Add(this._txtDisplayLabel_7);
			this._fraEmployeeInformation_3.Enabled = true;
			this._fraEmployeeInformation_3.ForeColor = System.Drawing.SystemColors.WindowText;
			this._fraEmployeeInformation_3.Location = new System.Drawing.Point(874, 22);
			this._fraEmployeeInformation_3.Name = "_fraEmployeeInformation_3";
			this._fraEmployeeInformation_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._fraEmployeeInformation_3.Size = new System.Drawing.Size(805, 198);
			this._fraEmployeeInformation_3.TabIndex = 85;
			this._fraEmployeeInformation_3.Visible = true;
			// 
			// chkIsReplacement
			// 
			this.chkIsReplacement.AllowDrop = true;
			this.chkIsReplacement.Appearance = System.Windows.Forms.Appearance.Normal;
			this.chkIsReplacement.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this.chkIsReplacement.CausesValidation = true;
			this.chkIsReplacement.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkIsReplacement.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this.chkIsReplacement.Enabled = true;
			this.chkIsReplacement.ForeColor = System.Drawing.Color.Navy;
			this.chkIsReplacement.Location = new System.Drawing.Point(477, 75);
			this.chkIsReplacement.Name = "chkIsReplacement";
			this.chkIsReplacement.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.chkIsReplacement.Size = new System.Drawing.Size(103, 19);
			this.chkIsReplacement.TabIndex = 84;
			this.chkIsReplacement.TabStop = true;
			this.chkIsReplacement.Text = "Is Replacement";
			this.chkIsReplacement.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkIsReplacement.Visible = true;
			// 
			// chkBudget
			// 
			this.chkBudget.AllowDrop = true;
			this.chkBudget.Appearance = System.Windows.Forms.Appearance.Normal;
			this.chkBudget.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this.chkBudget.CausesValidation = true;
			this.chkBudget.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkBudget.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this.chkBudget.Enabled = true;
			this.chkBudget.ForeColor = System.Drawing.Color.Navy;
			this.chkBudget.Location = new System.Drawing.Point(15, 27);
			this.chkBudget.Name = "chkBudget";
			this.chkBudget.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.chkBudget.Size = new System.Drawing.Size(91, 19);
			this.chkBudget.TabIndex = 81;
			this.chkBudget.TabStop = true;
			this.chkBudget.Text = "Is Budgeted";
			this.chkBudget.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkBudget.Visible = false;
			this.chkBudget.CheckStateChanged += new System.EventHandler(this.chkBudget_CheckStateChanged);
			// 
			// _txtCommonTextBox_72
			// 
			this._txtCommonTextBox_72.AllowDrop = true;
			this._txtCommonTextBox_72.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_72.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_72.Location = new System.Drawing.Point(123, 54);
			this._txtCommonTextBox_72.MaxLength = 100;
			this._txtCommonTextBox_72.Name = "_txtCommonTextBox_72";
			// this._txtCommonTextBox_72.ShowButton = true;
			this._txtCommonTextBox_72.Size = new System.Drawing.Size(100, 19);
			this._txtCommonTextBox_72.TabIndex = 82;
			this._txtCommonTextBox_72.Text = "";
			// this.this._txtCommonTextBox_72.Watermark = "";
			// this.this._txtCommonTextBox_72.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_72.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _lblCommon_74
			// 
			this._lblCommon_74.AllowDrop = true;
			this._lblCommon_74.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._lblCommon_74.Text = "New Head Count";
			this._lblCommon_74.Location = new System.Drawing.Point(15, 57);
			this._lblCommon_74.Name = "_lblCommon_74";
			this._lblCommon_74.Size = new System.Drawing.Size(81, 13);
			this._lblCommon_74.TabIndex = 86;
			// 
			// _txtDisplayLabel_18
			// 
			this._txtDisplayLabel_18.AllowDrop = true;
			this._txtDisplayLabel_18.Location = new System.Drawing.Point(225, 54);
			this._txtDisplayLabel_18.Name = "_txtDisplayLabel_18";
			this._txtDisplayLabel_18.Size = new System.Drawing.Size(233, 19);
			this._txtDisplayLabel_18.TabIndex = 87;
			this._txtDisplayLabel_18.TabStop = false;
			// 
			// _txtCommonTextBox_6
			// 
			this._txtCommonTextBox_6.AllowDrop = true;
			this._txtCommonTextBox_6.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_6.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_6.Location = new System.Drawing.Point(123, 75);
			this._txtCommonTextBox_6.Locked = true;
			this._txtCommonTextBox_6.MaxLength = 100;
			this._txtCommonTextBox_6.Name = "_txtCommonTextBox_6";
			// this._txtCommonTextBox_6.ShowButton = true;
			this._txtCommonTextBox_6.Size = new System.Drawing.Size(100, 19);
			this._txtCommonTextBox_6.TabIndex = 83;
			this._txtCommonTextBox_6.Text = "";
			// this.this._txtCommonTextBox_6.Watermark = "";
			// this.this._txtCommonTextBox_6.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_6.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _lblCommon_8
			// 
			this._lblCommon_8.AllowDrop = true;
			this._lblCommon_8.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._lblCommon_8.Text = "Old Head Count";
			this._lblCommon_8.Location = new System.Drawing.Point(15, 78);
			this._lblCommon_8.Name = "_lblCommon_8";
			this._lblCommon_8.Size = new System.Drawing.Size(76, 13);
			this._lblCommon_8.TabIndex = 88;
			// 
			// _txtDisplayLabel_7
			// 
			this._txtDisplayLabel_7.AllowDrop = true;
			this._txtDisplayLabel_7.Location = new System.Drawing.Point(225, 75);
			this._txtDisplayLabel_7.Name = "_txtDisplayLabel_7";
			this._txtDisplayLabel_7.Size = new System.Drawing.Size(233, 19);
			this._txtDisplayLabel_7.TabIndex = 89;
			this._txtDisplayLabel_7.TabStop = false;
			// 
			// Frame3
			// 
			this.Frame3.AllowDrop = true;
			this.Frame3.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this.Frame3.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Frame3.Controls.Add(this.cmdSubmmitApproval);
			this.Frame3.Controls.Add(this.txtDlblAppTemplateName);
			this.Frame3.Controls.Add(this.txtApprovalTemplate);
			this.Frame3.Controls.Add(this._lblCommonLabel_28);
			this.Frame3.Enabled = true;
			this.Frame3.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Frame3.Location = new System.Drawing.Point(854, 22);
			this.Frame3.Name = "Frame3";
			this.Frame3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Frame3.Size = new System.Drawing.Size(805, 198);
			this.Frame3.TabIndex = 52;
			this.Frame3.Visible = true;
			// 
			// cmdSubmmitApproval
			// 
			this.cmdSubmmitApproval.AllowDrop = true;
			this.cmdSubmmitApproval.BackColor = System.Drawing.SystemColors.Control;
			this.cmdSubmmitApproval.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdSubmmitApproval.Location = new System.Drawing.Point(459, 18);
			this.cmdSubmmitApproval.Name = "cmdSubmmitApproval";
			this.cmdSubmmitApproval.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdSubmmitApproval.Size = new System.Drawing.Size(97, 28);
			this.cmdSubmmitApproval.TabIndex = 53;
			this.cmdSubmmitApproval.Text = "Submmit";
			this.cmdSubmmitApproval.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.cmdSubmmitApproval.UseVisualStyleBackColor = false;
			// this.cmdSubmmitApproval.Click += new System.EventHandler(this.cmdSubmmitApproval_Click);
			// 
			// txtDlblAppTemplateName
			// 
			this.txtDlblAppTemplateName.AllowDrop = true;
			this.txtDlblAppTemplateName.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			this.txtDlblAppTemplateName.Enabled = false;
			this.txtDlblAppTemplateName.Location = new System.Drawing.Point(228, 24);
			this.txtDlblAppTemplateName.Name = "txtDlblAppTemplateName";
			this.txtDlblAppTemplateName.Size = new System.Drawing.Size(226, 19);
			this.txtDlblAppTemplateName.TabIndex = 54;
			// 
			// txtApprovalTemplate
			// 
			this.txtApprovalTemplate.AllowDrop = true;
			this.txtApprovalTemplate.BackColor = System.Drawing.Color.White;
			// this.txtApprovalTemplate.bolAllowDecimal = false;
			this.txtApprovalTemplate.ForeColor = System.Drawing.Color.Black;
			this.txtApprovalTemplate.Location = new System.Drawing.Point(120, 24);
			// this.txtApprovalTemplate.mDropDownType = (System.Windows.Forms.TextBox.DropDownTypes) 0;
			this.txtApprovalTemplate.Name = "txtApprovalTemplate";
			// this.txtApprovalTemplate.ShowButton = true;
			this.txtApprovalTemplate.Size = new System.Drawing.Size(106, 19);
			this.txtApprovalTemplate.TabIndex = 55;
			this.txtApprovalTemplate.Text = "";
			// this.this.txtApprovalTemplate.Watermark = "";
			// this.this.txtApprovalTemplate.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtApprovalTemplate_DropButtonClick);
			// this.txtApprovalTemplate.Leave += new System.EventHandler(this.txtApprovalTemplate_Leave);
			// 
			// _lblCommonLabel_28
			// 
			this._lblCommonLabel_28.AllowDrop = true;
			this._lblCommonLabel_28.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._lblCommonLabel_28.Text = "Approval Template";
			this._lblCommonLabel_28.Location = new System.Drawing.Point(15, 27);
			this._lblCommonLabel_28.Name = "_lblCommonLabel_28";
			this._lblCommonLabel_28.Size = new System.Drawing.Size(90, 14);
			this._lblCommonLabel_28.TabIndex = 56;
			// 
			// Frame2
			// 
			this.Frame2.AllowDrop = true;
			this.Frame2.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this.Frame2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Frame2.Controls.Add(this._lblCommon_107);
			this.Frame2.Controls.Add(this.txtoldBankName);
			this.Frame2.Controls.Add(this.txtOldBankCd);
			this.Frame2.Controls.Add(this.txtOldBankAccountNo);
			this.Frame2.Controls.Add(this._lblCommon_4);
			this.Frame2.Controls.Add(this.txtOldRatePerDay);
			this.Frame2.Controls.Add(this._lblCommonLabel_11);
			this.Frame2.Controls.Add(this._System.Windows.Forms.Label1_9);
			this.Frame2.Controls.Add(this._cmbCommon_1);
			this.Frame2.Controls.Add(this.txtNewBankName);
			this.Frame2.Controls.Add(this.txtNewBankCd);
			this.Frame2.Controls.Add(this.txtNewBankAccountNo);
			this.Frame2.Controls.Add(this._lblCommon_1);
			this.Frame2.Controls.Add(this.txtNewRatePerDay);
			this.Frame2.Controls.Add(this._lblCommonLabel_13);
			this.Frame2.Controls.Add(this._System.Windows.Forms.Label1_0);
			this.Frame2.Controls.Add(this._cmbCommon_0);
			this.Frame2.Controls.Add(this._lblCommon_2);
			this.Frame2.Controls.Add(this.txtOldCompBankName);
			this.Frame2.Controls.Add(this.txtoldCompBank);
			this.Frame2.Controls.Add(this._lblCommon_0);
			this.Frame2.Controls.Add(this._lblCommon_3);
			this.Frame2.Controls.Add(this.txtNewCompBankName);
			this.Frame2.Controls.Add(this.txtNewCompBank);
			this.Frame2.Controls.Add(this.txtOldGrade);
			this.Frame2.Controls.Add(this._lblCommon_104);
			this.Frame2.Controls.Add(this.txtDGradeName);
			this.Frame2.Controls.Add(this.txtNewGrade);
			this.Frame2.Controls.Add(this._lblCommon_5);
			this.Frame2.Controls.Add(this.txtDNewGradeName);
			this.Frame2.Controls.Add(this.txtOldAccountNo);
			this.Frame2.Controls.Add(this._lblCommon_6);
			this.Frame2.Controls.Add(this.txtNewAccountNo);
			this.Frame2.Controls.Add(this._lblCommon_7);
			this.Frame2.Controls.Add(this.txtDlblDefaultProject);
			this.Frame2.Controls.Add(this.txtDefaultProjectDispl);
			this.Frame2.Controls.Add(this.lblDefaultProject);
			this.Frame2.Controls.Add(this.txtDlblNewDefaultProject);
			this.Frame2.Controls.Add(this.txtDefaultProjectNew);
			this.Frame2.Controls.Add(this.System.Windows.Forms.Label2);
			this.Frame2.Enabled = true;
			this.Frame2.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Frame2.Location = new System.Drawing.Point(3, 22);
			this.Frame2.Name = "Frame2";
			this.Frame2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Frame2.Size = new System.Drawing.Size(805, 198);
			this.Frame2.TabIndex = 48;
			this.Frame2.Visible = true;
			// 
			// _lblCommon_107
			// 
			this._lblCommon_107.AllowDrop = true;
			this._lblCommon_107.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._lblCommon_107.Text = "Bank";
			this._lblCommon_107.Location = new System.Drawing.Point(3, 30);
			// this._lblCommon_107.mLabelId = 1980;
			this._lblCommon_107.Name = "_lblCommon_107";
			this._lblCommon_107.Size = new System.Drawing.Size(24, 14);
			this._lblCommon_107.TabIndex = 57;
			// 
			// txtoldBankName
			// 
			this.txtoldBankName.AllowDrop = true;
			this.txtoldBankName.Location = new System.Drawing.Point(199, 27);
			this.txtoldBankName.Name = "txtoldBankName";
			this.txtoldBankName.Size = new System.Drawing.Size(173, 19);
			this.txtoldBankName.TabIndex = 58;
			this.txtoldBankName.TabStop = false;
			// 
			// txtOldBankCd
			// 
			this.txtOldBankCd.AllowDrop = true;
			this.txtOldBankCd.BackColor = System.Drawing.Color.FromArgb(239, 239, 239);
			// this.txtOldBankCd.bolNumericOnly = true;
			this.txtOldBankCd.Enabled = false;
			this.txtOldBankCd.ForeColor = System.Drawing.Color.Black;
			this.txtOldBankCd.Location = new System.Drawing.Point(96, 27);
			this.txtOldBankCd.MaxLength = 4;
			this.txtOldBankCd.Name = "txtOldBankCd";
			// this.txtOldBankCd.ShowButton = true;
			this.txtOldBankCd.Size = new System.Drawing.Size(101, 19);
			this.txtOldBankCd.TabIndex = 10;
			this.txtOldBankCd.Text = "";
			// this.this.txtOldBankCd.Watermark = "";
			// this.this.txtOldBankCd.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtOldBankCd_DropButtonClick);
			// this.txtOldBankCd.Leave += new System.EventHandler(this.txtOldBankCd_Leave);
			// 
			// txtOldBankAccountNo
			// 
			this.txtOldBankAccountNo.AllowDrop = true;
			this.txtOldBankAccountNo.BackColor = System.Drawing.Color.FromArgb(239, 239, 239);
			this.txtOldBankAccountNo.Enabled = false;
			this.txtOldBankAccountNo.ForeColor = System.Drawing.Color.Black;
			this.txtOldBankAccountNo.Location = new System.Drawing.Point(96, 69);
			this.txtOldBankAccountNo.Name = "txtOldBankAccountNo";
			this.txtOldBankAccountNo.Size = new System.Drawing.Size(276, 19);
			this.txtOldBankAccountNo.TabIndex = 11;
			this.txtOldBankAccountNo.Text = "";
			// this.this.txtOldBankAccountNo.Watermark = "";
			// 
			// _lblCommon_4
			// 
			this._lblCommon_4.AllowDrop = true;
			this._lblCommon_4.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._lblCommon_4.Text = "IBAN No";
			this._lblCommon_4.Location = new System.Drawing.Point(3, 72);
			// this._lblCommon_4.mLabelId = 2236;
			this._lblCommon_4.Name = "_lblCommon_4";
			this._lblCommon_4.Size = new System.Drawing.Size(40, 13);
			this._lblCommon_4.TabIndex = 59;
			// 
			// txtOldRatePerDay
			// 
			this.txtOldRatePerDay.AllowDrop = true;
			// this.txtOldRatePerDay.DisplayFormat = "####0.000###;;0.000;0.000";
			this.txtOldRatePerDay.Enabled = false;
			// this.txtOldRatePerDay.Format = "###########0.000";
			this.txtOldRatePerDay.Location = new System.Drawing.Point(96, 132);
			// this.txtOldRatePerDay.MaxValue = 2147483647;
			// this.txtOldRatePerDay.MinValue = 0;
			this.txtOldRatePerDay.Name = "txtOldRatePerDay";
			this.txtOldRatePerDay.Size = new System.Drawing.Size(101, 19);
			this.txtOldRatePerDay.TabIndex = 12;
			this.txtOldRatePerDay.Text = "0.000";
			// 
			// _lblCommonLabel_11
			// 
			this._lblCommonLabel_11.AllowDrop = true;
			this._lblCommonLabel_11.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._lblCommonLabel_11.Text = "Rate Per Day";
			this._lblCommonLabel_11.Location = new System.Drawing.Point(3, 134);
			this._lblCommonLabel_11.Name = "_lblCommonLabel_11";
			this._lblCommonLabel_11.Size = new System.Drawing.Size(64, 13);
			this._lblCommonLabel_11.TabIndex = 60;
			// 
			// _System.Windows.Forms.Label1_9
			// 
			this._System.Windows.Forms.Label1_9.AllowDrop = true;
			this._System.Windows.Forms.Label1_9.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._System.Windows.Forms.Label1_9.Caption = "Payment Type";
			this._System.Windows.Forms.Label1_9.Location = new System.Drawing.Point(3, 155);
			this._System.Windows.Forms.Label1_9.mLabelId = 1111;
			this._System.Windows.Forms.Label1_9.Name = "_System.Windows.Forms.Label1_9";
			this._System.Windows.Forms.Label1_9.Size = new System.Drawing.Size(68, 14);
			this._System.Windows.Forms.Label1_9.TabIndex = 61;
			// 
			// _cmbCommon_1
			// 
			this._cmbCommon_1.AllowDrop = true;
			this._cmbCommon_1.Enabled = false;
			this._cmbCommon_1.Location = new System.Drawing.Point(96, 153);
			this._cmbCommon_1.Name = "_cmbCommon_1";
			this._cmbCommon_1.Size = new System.Drawing.Size(101, 21);
			this._cmbCommon_1.TabIndex = 13;
			// 
			// txtNewBankName
			// 
			this.txtNewBankName.AllowDrop = true;
			this.txtNewBankName.Location = new System.Drawing.Point(595, 27);
			this.txtNewBankName.Name = "txtNewBankName";
			this.txtNewBankName.Size = new System.Drawing.Size(173, 19);
			this.txtNewBankName.TabIndex = 62;
			this.txtNewBankName.TabStop = false;
			// 
			// txtNewBankCd
			// 
			this.txtNewBankCd.AllowDrop = true;
			this.txtNewBankCd.BackColor = System.Drawing.Color.White;
			// this.txtNewBankCd.bolNumericOnly = true;
			this.txtNewBankCd.ForeColor = System.Drawing.Color.Black;
			this.txtNewBankCd.Location = new System.Drawing.Point(492, 27);
			this.txtNewBankCd.MaxLength = 4;
			this.txtNewBankCd.Name = "txtNewBankCd";
			// this.txtNewBankCd.ShowButton = true;
			this.txtNewBankCd.Size = new System.Drawing.Size(101, 19);
			this.txtNewBankCd.TabIndex = 14;
			this.txtNewBankCd.Text = "";
			// this.this.txtNewBankCd.Watermark = "";
			// this.this.txtNewBankCd.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtNewBankCd_DropButtonClick);
			// this.txtNewBankCd.Leave += new System.EventHandler(this.txtNewBankCd_Leave);
			// 
			// txtNewBankAccountNo
			// 
			this.txtNewBankAccountNo.AllowDrop = true;
			this.txtNewBankAccountNo.BackColor = System.Drawing.Color.White;
			this.txtNewBankAccountNo.ForeColor = System.Drawing.Color.Black;
			this.txtNewBankAccountNo.Location = new System.Drawing.Point(492, 69);
			this.txtNewBankAccountNo.Name = "txtNewBankAccountNo";
			this.txtNewBankAccountNo.Size = new System.Drawing.Size(276, 19);
			this.txtNewBankAccountNo.TabIndex = 16;
			this.txtNewBankAccountNo.Text = "";
			// this.this.txtNewBankAccountNo.Watermark = "";
			// 
			// _lblCommon_1
			// 
			this._lblCommon_1.AllowDrop = true;
			this._lblCommon_1.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._lblCommon_1.Text = "New IBAN  No";
			this._lblCommon_1.Location = new System.Drawing.Point(378, 72);
			// this._lblCommon_1.mLabelId = 2237;
			this._lblCommon_1.Name = "_lblCommon_1";
			this._lblCommon_1.Size = new System.Drawing.Size(67, 13);
			this._lblCommon_1.TabIndex = 63;
			// 
			// txtNewRatePerDay
			// 
			this.txtNewRatePerDay.AllowDrop = true;
			// this.txtNewRatePerDay.DisplayFormat = "####0.000###;;0.000;0.000";
			// this.txtNewRatePerDay.Format = "###########0.000";
			this.txtNewRatePerDay.Location = new System.Drawing.Point(492, 132);
			// this.txtNewRatePerDay.MaxValue = 2147483647;
			// this.txtNewRatePerDay.MinValue = 0;
			this.txtNewRatePerDay.Name = "txtNewRatePerDay";
			this.txtNewRatePerDay.Size = new System.Drawing.Size(101, 19);
			this.txtNewRatePerDay.TabIndex = 18;
			this.txtNewRatePerDay.Text = "0.000";
			// 
			// _lblCommonLabel_13
			// 
			this._lblCommonLabel_13.AllowDrop = true;
			this._lblCommonLabel_13.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._lblCommonLabel_13.Text = "New Rate Per Day";
			this._lblCommonLabel_13.Location = new System.Drawing.Point(378, 134);
			this._lblCommonLabel_13.Name = "_lblCommonLabel_13";
			this._lblCommonLabel_13.Size = new System.Drawing.Size(88, 13);
			this._lblCommonLabel_13.TabIndex = 64;
			// 
			// _System.Windows.Forms.Label1_0
			// 
			this._System.Windows.Forms.Label1_0.AllowDrop = true;
			this._System.Windows.Forms.Label1_0.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._System.Windows.Forms.Label1_0.Caption = "New Payment Type";
			this._System.Windows.Forms.Label1_0.Location = new System.Drawing.Point(378, 155);
			this._System.Windows.Forms.Label1_0.Name = "_System.Windows.Forms.Label1_0";
			this._System.Windows.Forms.Label1_0.Size = new System.Drawing.Size(94, 14);
			this._System.Windows.Forms.Label1_0.TabIndex = 65;
			// 
			// _cmbCommon_0
			// 
			this._cmbCommon_0.AllowDrop = true;
			this._cmbCommon_0.Location = new System.Drawing.Point(492, 153);
			this._cmbCommon_0.Name = "_cmbCommon_0";
			this._cmbCommon_0.Size = new System.Drawing.Size(101, 21);
			this._cmbCommon_0.TabIndex = 19;
			// 
			// _lblCommon_2
			// 
			this._lblCommon_2.AllowDrop = true;
			this._lblCommon_2.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._lblCommon_2.Text = "Company Bank";
			this._lblCommon_2.Location = new System.Drawing.Point(3, 50);
			// this._lblCommon_2.mLabelId = 1960;
			this._lblCommon_2.Name = "_lblCommon_2";
			this._lblCommon_2.Size = new System.Drawing.Size(72, 14);
			this._lblCommon_2.TabIndex = 66;
			// 
			// txtOldCompBankName
			// 
			this.txtOldCompBankName.AllowDrop = true;
			this.txtOldCompBankName.Location = new System.Drawing.Point(199, 48);
			this.txtOldCompBankName.Name = "txtOldCompBankName";
			this.txtOldCompBankName.Size = new System.Drawing.Size(173, 19);
			this.txtOldCompBankName.TabIndex = 67;
			this.txtOldCompBankName.TabStop = false;
			// 
			// txtoldCompBank
			// 
			this.txtoldCompBank.AllowDrop = true;
			this.txtoldCompBank.BackColor = System.Drawing.Color.FromArgb(239, 239, 239);
			this.txtoldCompBank.Enabled = false;
			this.txtoldCompBank.ForeColor = System.Drawing.Color.Black;
			this.txtoldCompBank.Location = new System.Drawing.Point(96, 48);
			this.txtoldCompBank.MaxLength = 100;
			this.txtoldCompBank.Name = "txtoldCompBank";
			// this.txtoldCompBank.ShowButton = true;
			this.txtoldCompBank.Size = new System.Drawing.Size(101, 19);
			this.txtoldCompBank.TabIndex = 68;
			this.txtoldCompBank.Text = "";
			// this.this.txtoldCompBank.Watermark = "";
			// this.this.txtoldCompBank.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtoldCompBank_DropButtonClick);
			// this.txtoldCompBank.Leave += new System.EventHandler(this.txtoldCompBank_Leave);
			// 
			// _lblCommon_0
			// 
			this._lblCommon_0.AllowDrop = true;
			this._lblCommon_0.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._lblCommon_0.Text = "New Bank";
			this._lblCommon_0.Location = new System.Drawing.Point(378, 27);
			this._lblCommon_0.Name = "_lblCommon_0";
			this._lblCommon_0.Size = new System.Drawing.Size(50, 14);
			this._lblCommon_0.TabIndex = 69;
			// 
			// _lblCommon_3
			// 
			this._lblCommon_3.AllowDrop = true;
			this._lblCommon_3.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._lblCommon_3.Text = "New Comp Bank";
			this._lblCommon_3.Location = new System.Drawing.Point(378, 50);
			// this._lblCommon_3.mLabelId = 2240;
			this._lblCommon_3.Name = "_lblCommon_3";
			this._lblCommon_3.Size = new System.Drawing.Size(80, 14);
			this._lblCommon_3.TabIndex = 70;
			// 
			// txtNewCompBankName
			// 
			this.txtNewCompBankName.AllowDrop = true;
			this.txtNewCompBankName.Location = new System.Drawing.Point(595, 48);
			this.txtNewCompBankName.Name = "txtNewCompBankName";
			this.txtNewCompBankName.Size = new System.Drawing.Size(173, 19);
			this.txtNewCompBankName.TabIndex = 71;
			this.txtNewCompBankName.TabStop = false;
			// 
			// txtNewCompBank
			// 
			this.txtNewCompBank.AllowDrop = true;
			this.txtNewCompBank.BackColor = System.Drawing.Color.White;
			// this.txtNewCompBank.bolAllowDecimal = false;
			this.txtNewCompBank.ForeColor = System.Drawing.Color.Black;
			this.txtNewCompBank.Location = new System.Drawing.Point(492, 48);
			this.txtNewCompBank.MaxLength = 100;
			this.txtNewCompBank.Name = "txtNewCompBank";
			// this.txtNewCompBank.ShowButton = true;
			this.txtNewCompBank.Size = new System.Drawing.Size(101, 19);
			this.txtNewCompBank.TabIndex = 15;
			this.txtNewCompBank.Text = "";
			// this.this.txtNewCompBank.Watermark = "";
			// this.this.txtNewCompBank.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtNewCompBank_DropButtonClick);
			// this.txtNewCompBank.Leave += new System.EventHandler(this.txtNewCompBank_Leave);
			// 
			// txtOldGrade
			// 
			this.txtOldGrade.AllowDrop = true;
			this.txtOldGrade.BackColor = System.Drawing.Color.FromArgb(239, 239, 239);
			// this.txtOldGrade.bolNumericOnly = true;
			this.txtOldGrade.Enabled = false;
			this.txtOldGrade.ForeColor = System.Drawing.Color.Black;
			this.txtOldGrade.Location = new System.Drawing.Point(96, 111);
			this.txtOldGrade.MaxLength = 8;
			this.txtOldGrade.Name = "txtOldGrade";
			// this.txtOldGrade.ShowButton = true;
			this.txtOldGrade.Size = new System.Drawing.Size(101, 19);
			this.txtOldGrade.TabIndex = 72;
			this.txtOldGrade.Text = "";
			// this.this.txtOldGrade.Watermark = "";
			// this.this.txtOldGrade.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtOldGrade_DropButtonClick);
			// this.txtOldGrade.Leave += new System.EventHandler(this.txtOldGrade_Leave);
			// 
			// _lblCommon_104
			// 
			this._lblCommon_104.AllowDrop = true;
			this._lblCommon_104.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._lblCommon_104.Text = "Grade Code";
			this._lblCommon_104.Location = new System.Drawing.Point(3, 113);
			// this._lblCommon_104.mLabelId = 1061;
			this._lblCommon_104.Name = "_lblCommon_104";
			this._lblCommon_104.Size = new System.Drawing.Size(58, 14);
			this._lblCommon_104.TabIndex = 73;
			// 
			// txtDGradeName
			// 
			this.txtDGradeName.AllowDrop = true;
			this.txtDGradeName.Location = new System.Drawing.Point(199, 111);
			this.txtDGradeName.Name = "txtDGradeName";
			this.txtDGradeName.Size = new System.Drawing.Size(173, 19);
			this.txtDGradeName.TabIndex = 74;
			this.txtDGradeName.TabStop = false;
			// 
			// txtNewGrade
			// 
			this.txtNewGrade.AllowDrop = true;
			this.txtNewGrade.BackColor = System.Drawing.Color.White;
			// this.txtNewGrade.bolNumericOnly = true;
			this.txtNewGrade.ForeColor = System.Drawing.Color.Black;
			this.txtNewGrade.Location = new System.Drawing.Point(492, 111);
			this.txtNewGrade.MaxLength = 8;
			this.txtNewGrade.Name = "txtNewGrade";
			// this.txtNewGrade.ShowButton = true;
			this.txtNewGrade.Size = new System.Drawing.Size(101, 19);
			this.txtNewGrade.TabIndex = 17;
			this.txtNewGrade.Text = "";
			// this.this.txtNewGrade.Watermark = "";
			// this.this.txtNewGrade.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtNewGrade_DropButtonClick);
			// this.txtNewGrade.Leave += new System.EventHandler(this.txtNewGrade_Leave);
			// 
			// _lblCommon_5
			// 
			this._lblCommon_5.AllowDrop = true;
			this._lblCommon_5.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._lblCommon_5.Text = "New Grade";
			this._lblCommon_5.Location = new System.Drawing.Point(378, 113);
			// this._lblCommon_5.mLabelId = 2239;
			this._lblCommon_5.Name = "_lblCommon_5";
			this._lblCommon_5.Size = new System.Drawing.Size(56, 14);
			this._lblCommon_5.TabIndex = 75;
			// 
			// txtDNewGradeName
			// 
			this.txtDNewGradeName.AllowDrop = true;
			this.txtDNewGradeName.Location = new System.Drawing.Point(595, 111);
			this.txtDNewGradeName.Name = "txtDNewGradeName";
			this.txtDNewGradeName.Size = new System.Drawing.Size(173, 19);
			this.txtDNewGradeName.TabIndex = 76;
			this.txtDNewGradeName.TabStop = false;
			// 
			// txtOldAccountNo
			// 
			this.txtOldAccountNo.AllowDrop = true;
			this.txtOldAccountNo.BackColor = System.Drawing.Color.FromArgb(239, 239, 239);
			this.txtOldAccountNo.Enabled = false;
			this.txtOldAccountNo.ForeColor = System.Drawing.Color.Black;
			this.txtOldAccountNo.Location = new System.Drawing.Point(96, 90);
			this.txtOldAccountNo.Name = "txtOldAccountNo";
			this.txtOldAccountNo.Size = new System.Drawing.Size(276, 19);
			this.txtOldAccountNo.TabIndex = 77;
			this.txtOldAccountNo.Text = "";
			// this.this.txtOldAccountNo.Watermark = "";
			// 
			// _lblCommon_6
			// 
			this._lblCommon_6.AllowDrop = true;
			this._lblCommon_6.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._lblCommon_6.Text = "Account No";
			this._lblCommon_6.Location = new System.Drawing.Point(3, 93);
			// this._lblCommon_6.mLabelId = 1978;
			this._lblCommon_6.Name = "_lblCommon_6";
			this._lblCommon_6.Size = new System.Drawing.Size(55, 13);
			this._lblCommon_6.TabIndex = 78;
			// 
			// txtNewAccountNo
			// 
			this.txtNewAccountNo.AllowDrop = true;
			this.txtNewAccountNo.BackColor = System.Drawing.Color.White;
			this.txtNewAccountNo.ForeColor = System.Drawing.Color.Black;
			this.txtNewAccountNo.Location = new System.Drawing.Point(492, 90);
			this.txtNewAccountNo.Name = "txtNewAccountNo";
			this.txtNewAccountNo.Size = new System.Drawing.Size(276, 19);
			this.txtNewAccountNo.TabIndex = 79;
			this.txtNewAccountNo.Text = "";
			// this.this.txtNewAccountNo.Watermark = "";
			// 
			// _lblCommon_7
			// 
			this._lblCommon_7.AllowDrop = true;
			this._lblCommon_7.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._lblCommon_7.Text = "New Account No";
			this._lblCommon_7.Location = new System.Drawing.Point(378, 93);
			// this._lblCommon_7.mLabelId = 2238;
			this._lblCommon_7.Name = "_lblCommon_7";
			this._lblCommon_7.Size = new System.Drawing.Size(79, 13);
			this._lblCommon_7.TabIndex = 80;
			// 
			// txtDlblDefaultProject
			// 
			this.txtDlblDefaultProject.AllowDrop = true;
			this.txtDlblDefaultProject.Enabled = false;
			this.txtDlblDefaultProject.Location = new System.Drawing.Point(199, 177);
			this.txtDlblDefaultProject.Name = "txtDlblDefaultProject";
			this.txtDlblDefaultProject.Size = new System.Drawing.Size(173, 19);
			this.txtDlblDefaultProject.TabIndex = 90;
			// 
			// txtDefaultProjectDispl
			// 
			this.txtDefaultProjectDispl.AllowDrop = true;
			this.txtDefaultProjectDispl.BackColor = System.Drawing.Color.FromArgb(239, 239, 239);
			// this.txtDefaultProjectDispl.bolAllowDecimal = false;
			this.txtDefaultProjectDispl.Enabled = false;
			this.txtDefaultProjectDispl.ForeColor = System.Drawing.Color.Black;
			this.txtDefaultProjectDispl.Location = new System.Drawing.Point(96, 177);
			// this.txtDefaultProjectDispl.mDropDownType = (System.Windows.Forms.TextBox.DropDownTypes) 0;
			this.txtDefaultProjectDispl.Name = "txtDefaultProjectDispl";
			// this.txtDefaultProjectDispl.ShowButton = true;
			this.txtDefaultProjectDispl.Size = new System.Drawing.Size(101, 19);
			this.txtDefaultProjectDispl.TabIndex = 91;
			this.txtDefaultProjectDispl.Text = "";
			// this.this.txtDefaultProjectDispl.Watermark = "";
			// 
			// lblDefaultProject
			// 
			this.lblDefaultProject.AllowDrop = true;
			this.lblDefaultProject.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this.lblDefaultProject.Text = "Default Project";
			this.lblDefaultProject.Location = new System.Drawing.Point(3, 181);
			// this.lblDefaultProject.mLabelId = 2160;
			this.lblDefaultProject.Name = "lblDefaultProject";
			this.lblDefaultProject.Size = new System.Drawing.Size(72, 13);
			this.lblDefaultProject.TabIndex = 92;
			// 
			// txtDlblNewDefaultProject
			// 
			this.txtDlblNewDefaultProject.AllowDrop = true;
			this.txtDlblNewDefaultProject.Enabled = false;
			this.txtDlblNewDefaultProject.Location = new System.Drawing.Point(595, 177);
			this.txtDlblNewDefaultProject.Name = "txtDlblNewDefaultProject";
			this.txtDlblNewDefaultProject.Size = new System.Drawing.Size(173, 19);
			this.txtDlblNewDefaultProject.TabIndex = 93;
			// 
			// txtDefaultProjectNew
			// 
			this.txtDefaultProjectNew.AllowDrop = true;
			this.txtDefaultProjectNew.BackColor = System.Drawing.Color.White;
			// this.txtDefaultProjectNew.bolAllowDecimal = false;
			this.txtDefaultProjectNew.ForeColor = System.Drawing.Color.Black;
			this.txtDefaultProjectNew.Location = new System.Drawing.Point(492, 177);
			// this.txtDefaultProjectNew.mDropDownType = (System.Windows.Forms.TextBox.DropDownTypes) 0;
			this.txtDefaultProjectNew.Name = "txtDefaultProjectNew";
			// this.txtDefaultProjectNew.ShowButton = true;
			this.txtDefaultProjectNew.Size = new System.Drawing.Size(101, 19);
			this.txtDefaultProjectNew.TabIndex = 20;
			this.txtDefaultProjectNew.Text = "";
			// this.this.txtDefaultProjectNew.Watermark = "";
			// this.this.txtDefaultProjectNew.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtDefaultProjectNew_DropButtonClick);
			// this.txtDefaultProjectNew.Leave += new System.EventHandler(this.txtDefaultProjectNew_Leave);
			// 
			// System.Windows.Forms.Label2
			// 
			this.System.Windows.Forms.Label2.AllowDrop = true;
			this.System.Windows.Forms.Label2.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this.System.Windows.Forms.Label2.Caption = "New Default Project";
			this.System.Windows.Forms.Label2.Location = new System.Drawing.Point(378, 181);
			this.System.Windows.Forms.Label2.Name = "System.Windows.Forms.Label2";
			this.System.Windows.Forms.Label2.Size = new System.Drawing.Size(96, 13);
			this.System.Windows.Forms.Label2.TabIndex = 94;
			// 
			// Frame1
			// 
			this.Frame1.AllowDrop = true;
			this.Frame1.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this.Frame1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Frame1.Controls.Add(this.grdVoucherDetails);
			this.Frame1.Controls.Add(this.txtTempDate);
			this.Frame1.Controls.Add(this.cmbMastersList);
			this.Frame1.Enabled = true;
			this.Frame1.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Frame1.Location = new System.Drawing.Point(-848, 22);
			this.Frame1.Name = "Frame1";
			this.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Frame1.Size = new System.Drawing.Size(805, 198);
			this.Frame1.TabIndex = 47;
			this.Frame1.Visible = true;
			// 
			// grdVoucherDetails
			// 
			this.grdVoucherDetails.AllowDrop = true;
			this.grdVoucherDetails.BackColor = System.Drawing.Color.Silver;
			this.grdVoucherDetails.CellTipsWidth = 0;
			this.grdVoucherDetails.Location = new System.Drawing.Point(0, 3);
			this.grdVoucherDetails.Name = "grdVoucherDetails";
			this.grdVoucherDetails.RowDivider.Color = System.Drawing.Color.Silver;
			this.grdVoucherDetails.Size = new System.Drawing.Size(809, 179);
			this.grdVoucherDetails.TabIndex = 49;
			this.grdVoucherDetails.Columns.Add(this.Column_0_grdVoucherDetails);
			this.grdVoucherDetails.Columns.Add(this.Column_1_grdVoucherDetails);
			this.grdVoucherDetails.AfterColUpdate += new C1.Win.C1TrueDBGrid.ColEventHandler(this.grdVoucherDetails_AfterColUpdate);
			this.grdVoucherDetails.BeforeColEdit += new C1.Win.C1TrueDBGrid.BeforeColEditEventHandler(this.grdVoucherDetails_BeforeColEdit);
			this.grdVoucherDetails.GotFocus += new System.EventHandler(this.grdVoucherDetails_GotFocus);
			// this.this.grdVoucherDetails.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.grdVoucherDetails_KeyPress);
			this.grdVoucherDetails.MouseUp += new System.Windows.Forms.MouseEventHandler(this.grdVoucherDetails_MouseUp);
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
			// txtTempDate
			// 
			this.txtTempDate.AllowDrop = true;
			this.txtTempDate.Location = new System.Drawing.Point(264, 63);
			this.txtTempDate.Name = "txtTempDate";
			("txtTempDate.OcxState");
			this.txtTempDate.Size = new System.Drawing.Size(109, 19);
			this.txtTempDate.TabIndex = 50;
			this.txtTempDate.Visible = false;
			// 
			// cmbMastersList
			// 
			this.cmbMastersList.AllowDrop = true;
			this.cmbMastersList.ColumnHeaders = true;
			this.cmbMastersList.Enabled = true;
			this.cmbMastersList.Location = new System.Drawing.Point(0, 0);
			this.cmbMastersList.Name = "cmbMastersList";
			this.cmbMastersList.Size = new System.Drawing.Size(61, 45);
			this.cmbMastersList.TabIndex = 51;
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
			// _txtCommonTextBox_11
			// 
			this._txtCommonTextBox_11.AllowDrop = true;
			this._txtCommonTextBox_11.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_11.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_11.Location = new System.Drawing.Point(62, 434);
			this._txtCommonTextBox_11.MaxLength = 200;
			this._txtCommonTextBox_11.Name = "_txtCommonTextBox_11";
			this._txtCommonTextBox_11.Size = new System.Drawing.Size(303, 19);
			this._txtCommonTextBox_11.TabIndex = 9;
			this._txtCommonTextBox_11.TabStop = false;
			this._txtCommonTextBox_11.Text = "";
			// this.this._txtCommonTextBox_11.Watermark = "";
			// this.this._txtCommonTextBox_11.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_11.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _lblCommonLabel_9
			// 
			this._lblCommonLabel_9.AllowDrop = true;
			this._lblCommonLabel_9.BackColor = System.Drawing.Color.FromArgb(213, 213, 213);
			this._lblCommonLabel_9.Text = "Narration";
			this._lblCommonLabel_9.Location = new System.Drawing.Point(7, 437);
			this._lblCommonLabel_9.Name = "_lblCommonLabel_9";
			this._lblCommonLabel_9.Size = new System.Drawing.Size(45, 13);
			this._lblCommonLabel_9.TabIndex = 21;
			// 
			// _lblCommonLabel_12
			// 
			this._lblCommonLabel_12.AllowDrop = true;
			this._lblCommonLabel_12.BackColor = System.Drawing.Color.FromArgb(213, 213, 213);
			this._lblCommonLabel_12.Text = "Product Details :";
			this._lblCommonLabel_12.Location = new System.Drawing.Point(368, 433);
			this._lblCommonLabel_12.Name = "_lblCommonLabel_12";
			this._lblCommonLabel_12.Size = new System.Drawing.Size(79, 13);
			this._lblCommonLabel_12.TabIndex = 22;
			// 
			// fraTabPage0
			// 
			this.fraTabPage0.AllowDrop = true;
			this.fraTabPage0.Controls.Add(this._lblCommonLabel_4);
			this.fraTabPage0.Controls.Add(this._lblCommonLabel_2);
			this.fraTabPage0.Controls.Add(this._lblCommonLabel_5);
			this.fraTabPage0.Controls.Add(this._lblCommonLabel_6);
			this.fraTabPage0.Controls.Add(this.txtVoucherDate);
			this.fraTabPage0.Controls.Add(this._txtCommonTextBox_0);
			this.fraTabPage0.Controls.Add(this._lblCommonLabel_23);
			this.fraTabPage0.Controls.Add(this._lblCommonLabel_21);
			this.fraTabPage0.Controls.Add(this.System.Windows.Forms.Label12);
			this.fraTabPage0.Controls.Add(this._txtCommonTextBox_2);
			this.fraTabPage0.Controls.Add(this._lblCommonLabel_0);
			this.fraTabPage0.Controls.Add(this._txtCommonTextBox_3);
			this.fraTabPage0.Controls.Add(this._txtDisplayLabel_1);
			this.fraTabPage0.Controls.Add(this._txtDisplayLabel_4);
			this.fraTabPage0.Controls.Add(this._txtDisplayLabel_5);
			this.fraTabPage0.Controls.Add(this._txtDisplayLabel_6);
			this.fraTabPage0.Controls.Add(this._lblCommonLabel_1);
			this.fraTabPage0.Controls.Add(this._txtDisplayLabel_2);
			this.fraTabPage0.Controls.Add(this._txtDisplayLabel_3);
			this.fraTabPage0.Controls.Add(this._txtCommonTextBox_1);
			this.fraTabPage0.Controls.Add(this._txtDisplayLabel_0);
			this.fraTabPage0.Controls.Add(this._txtDisplayLabel_8);
			this.fraTabPage0.Controls.Add(this._lblCommonLabel_7);
			this.fraTabPage0.Controls.Add(this._txtDisplayLabel_10);
			this.fraTabPage0.Controls.Add(this._txtCommonTextBox_4);
			this.fraTabPage0.Controls.Add(this._txtCommonTextBox_5);
			this.fraTabPage0.Controls.Add(this._lblCommonLabel_3);
			this.fraTabPage0.Controls.Add(this._lblCommonLabel_8);
			this.fraTabPage0.Controls.Add(this.cmbType);
			this.fraTabPage0.Controls.Add(this._lblCommonLabel_10);
			this.fraTabPage0.Controls.Add(this.txtEffectiveDate);
			this.fraTabPage0.Location = new System.Drawing.Point(4, 42);
			this.fraTabPage0.Name = "fraTabPage0";
			("fraTabPage0.OcxState");
			this.fraTabPage0.Size = new System.Drawing.Size(809, 145);
			this.fraTabPage0.TabIndex = 23;
			// 
			// _lblCommonLabel_4
			// 
			this._lblCommonLabel_4.AllowDrop = true;
			this._lblCommonLabel_4.BackColor = System.Drawing.Color.White;
			this._lblCommonLabel_4.Text = "Basic Salary";
			this._lblCommonLabel_4.Location = new System.Drawing.Point(616, 34);
			// this._lblCommonLabel_4.mLabelId = 1970;
			this._lblCommonLabel_4.Name = "_lblCommonLabel_4";
			this._lblCommonLabel_4.Size = new System.Drawing.Size(57, 13);
			this._lblCommonLabel_4.TabIndex = 24;
			// 
			// _lblCommonLabel_2
			// 
			this._lblCommonLabel_2.AllowDrop = true;
			this._lblCommonLabel_2.BackColor = System.Drawing.Color.White;
			this._lblCommonLabel_2.Text = "Employee Code";
			this._lblCommonLabel_2.Location = new System.Drawing.Point(6, 54);
			// this._lblCommonLabel_2.mLabelId = 236;
			this._lblCommonLabel_2.Name = "_lblCommonLabel_2";
			this._lblCommonLabel_2.Size = new System.Drawing.Size(74, 14);
			this._lblCommonLabel_2.TabIndex = 25;
			// 
			// _lblCommonLabel_5
			// 
			this._lblCommonLabel_5.AllowDrop = true;
			this._lblCommonLabel_5.BackColor = System.Drawing.Color.White;
			this._lblCommonLabel_5.Text = "Transaction No.";
			this._lblCommonLabel_5.Location = new System.Drawing.Point(6, 12);
			// this._lblCommonLabel_5.mLabelId = 1232;
			this._lblCommonLabel_5.Name = "_lblCommonLabel_5";
			this._lblCommonLabel_5.Size = new System.Drawing.Size(76, 14);
			this._lblCommonLabel_5.TabIndex = 26;
			// 
			// _lblCommonLabel_6
			// 
			this._lblCommonLabel_6.AllowDrop = true;
			this._lblCommonLabel_6.BackColor = System.Drawing.Color.White;
			this._lblCommonLabel_6.Text = "Trans. Date";
			this._lblCommonLabel_6.Location = new System.Drawing.Point(402, 12);
			// this._lblCommonLabel_6.mLabelId = 1233;
			this._lblCommonLabel_6.Name = "_lblCommonLabel_6";
			this._lblCommonLabel_6.Size = new System.Drawing.Size(56, 14);
			this._lblCommonLabel_6.TabIndex = 27;
			// 
			// txtVoucherDate
			// 
			this.txtVoucherDate.AllowDrop = true;
			// this.txtVoucherDate.CheckDateRange = false;
			this.txtVoucherDate.Location = new System.Drawing.Point(507, 10);
			// this.txtVoucherDate.MaxDate = 2958465;
			// this.txtVoucherDate.MinDate = 32874;
			this.txtVoucherDate.Name = "txtVoucherDate";
			this.txtVoucherDate.Size = new System.Drawing.Size(101, 19);
			this.txtVoucherDate.TabIndex = 2;
			this.txtVoucherDate.Text = "18-Jul-2001";
			this.txtVoucherDate.Value = 37090;
			// 
			// _txtCommonTextBox_0
			// 
			this._txtCommonTextBox_0.AllowDrop = true;
			this._txtCommonTextBox_0.BackColor = System.Drawing.Color.White;
			// this._txtCommonTextBox_0.bolAllowDecimal = false;
			// this._txtCommonTextBox_0.bolNumericOnly = true;
			this._txtCommonTextBox_0.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_0.Location = new System.Drawing.Point(89, 10);
			// this._txtCommonTextBox_0.mDropDownType = System.Windows.Forms.TextBox.DropDownTypes.ddtNextNumber;
			this._txtCommonTextBox_0.Name = "_txtCommonTextBox_0";
			// this._txtCommonTextBox_0.ShowButton = true;
			this._txtCommonTextBox_0.Size = new System.Drawing.Size(102, 19);
			this._txtCommonTextBox_0.TabIndex = 0;
			this._txtCommonTextBox_0.Text = "";
			// this.this._txtCommonTextBox_0.Watermark = "";
			// this.this._txtCommonTextBox_0.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_0.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _lblCommonLabel_23
			// 
			this._lblCommonLabel_23.AllowDrop = true;
			this._lblCommonLabel_23.BackColor = System.Drawing.Color.White;
			this._lblCommonLabel_23.Text = "Total Salary";
			this._lblCommonLabel_23.Location = new System.Drawing.Point(616, 54);
			// this._lblCommonLabel_23.mLabelId = 818;
			this._lblCommonLabel_23.Name = "_lblCommonLabel_23";
			this._lblCommonLabel_23.Size = new System.Drawing.Size(57, 14);
			this._lblCommonLabel_23.TabIndex = 28;
			// 
			// _lblCommonLabel_21
			// 
			this._lblCommonLabel_21.AllowDrop = true;
			this._lblCommonLabel_21.BackColor = System.Drawing.Color.White;
			this._lblCommonLabel_21.Text = "Designation";
			this._lblCommonLabel_21.Location = new System.Drawing.Point(6, 75);
			// this._lblCommonLabel_21.mLabelId = 1969;
			this._lblCommonLabel_21.Name = "_lblCommonLabel_21";
			this._lblCommonLabel_21.Size = new System.Drawing.Size(56, 14);
			this._lblCommonLabel_21.TabIndex = 29;
			// 
			// System.Windows.Forms.Label12
			// 
			this.System.Windows.Forms.Label12.AllowDrop = true;
			this.System.Windows.Forms.Label12.BackColor = System.Drawing.Color.White;
			this.System.Windows.Forms.Label12.Caption = "Comments";
			this.System.Windows.Forms.Label12.Location = new System.Drawing.Point(6, 117);
			this.System.Windows.Forms.Label12.mLabelId = 1851;
			this.System.Windows.Forms.Label12.Name = "System.Windows.Forms.Label12";
			this.System.Windows.Forms.Label12.Size = new System.Drawing.Size(50, 14);
			this.System.Windows.Forms.Label12.TabIndex = 30;
			// 
			// _txtCommonTextBox_2
			// 
			this._txtCommonTextBox_2.AllowDrop = true;
			this._txtCommonTextBox_2.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_2.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_2.Location = new System.Drawing.Point(89, 115);
			this._txtCommonTextBox_2.MaxLength = 100;
			this._txtCommonTextBox_2.Name = "_txtCommonTextBox_2";
			this._txtCommonTextBox_2.Size = new System.Drawing.Size(710, 19);
			this._txtCommonTextBox_2.TabIndex = 8;
			this._txtCommonTextBox_2.Text = "";
			// this.this._txtCommonTextBox_2.Watermark = "";
			// this.this._txtCommonTextBox_2.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_2.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _lblCommonLabel_0
			// 
			this._lblCommonLabel_0.AllowDrop = true;
			this._lblCommonLabel_0.BackColor = System.Drawing.Color.White;
			this._lblCommonLabel_0.Text = "Reference No.";
			this._lblCommonLabel_0.Location = new System.Drawing.Point(6, 32);
			// this._lblCommonLabel_0.mLabelId = 1964;
			this._lblCommonLabel_0.Name = "_lblCommonLabel_0";
			this._lblCommonLabel_0.Size = new System.Drawing.Size(70, 14);
			this._lblCommonLabel_0.TabIndex = 31;
			// 
			// _txtCommonTextBox_3
			// 
			this._txtCommonTextBox_3.AllowDrop = true;
			this._txtCommonTextBox_3.BackColor = System.Drawing.Color.White;
			// this._txtCommonTextBox_3.bolNumericOnly = true;
			this._txtCommonTextBox_3.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_3.Location = new System.Drawing.Point(89, 31);
			this._txtCommonTextBox_3.Name = "_txtCommonTextBox_3";
			this._txtCommonTextBox_3.Size = new System.Drawing.Size(102, 19);
			this._txtCommonTextBox_3.TabIndex = 4;
			this._txtCommonTextBox_3.Text = "";
			// this.this._txtCommonTextBox_3.Watermark = "";
			// this.this._txtCommonTextBox_3.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_3.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _txtDisplayLabel_1
			// 
			this._txtDisplayLabel_1.AllowDrop = true;
			this._txtDisplayLabel_1.Location = new System.Drawing.Point(697, 31);
			this._txtDisplayLabel_1.Name = "_txtDisplayLabel_1";
			this._txtDisplayLabel_1.Size = new System.Drawing.Size(101, 19);
			this._txtDisplayLabel_1.TabIndex = 32;
			this._txtDisplayLabel_1.TabStop = false;
			// 
			// _txtDisplayLabel_4
			// 
			this._txtDisplayLabel_4.AllowDrop = true;
			this._txtDisplayLabel_4.Location = new System.Drawing.Point(697, 52);
			this._txtDisplayLabel_4.Name = "_txtDisplayLabel_4";
			this._txtDisplayLabel_4.Size = new System.Drawing.Size(101, 19);
			this._txtDisplayLabel_4.TabIndex = 33;
			this._txtDisplayLabel_4.TabStop = false;
			// 
			// _txtDisplayLabel_5
			// 
			this._txtDisplayLabel_5.AllowDrop = true;
			this._txtDisplayLabel_5.Location = new System.Drawing.Point(89, 94);
			this._txtDisplayLabel_5.Name = "_txtDisplayLabel_5";
			this._txtDisplayLabel_5.Size = new System.Drawing.Size(101, 19);
			this._txtDisplayLabel_5.TabIndex = 34;
			this._txtDisplayLabel_5.TabStop = false;
			// 
			// _txtDisplayLabel_6
			// 
			this._txtDisplayLabel_6.AllowDrop = true;
			this._txtDisplayLabel_6.Location = new System.Drawing.Point(192, 94);
			this._txtDisplayLabel_6.Name = "_txtDisplayLabel_6";
			this._txtDisplayLabel_6.Size = new System.Drawing.Size(201, 19);
			this._txtDisplayLabel_6.TabIndex = 35;
			this._txtDisplayLabel_6.TabStop = false;
			// 
			// _lblCommonLabel_1
			// 
			this._lblCommonLabel_1.AllowDrop = true;
			this._lblCommonLabel_1.BackColor = System.Drawing.Color.White;
			this._lblCommonLabel_1.Text = "Department";
			this._lblCommonLabel_1.Location = new System.Drawing.Point(6, 96);
			// this._lblCommonLabel_1.mLabelId = 1973;
			this._lblCommonLabel_1.Name = "_lblCommonLabel_1";
			this._lblCommonLabel_1.Size = new System.Drawing.Size(55, 14);
			this._lblCommonLabel_1.TabIndex = 36;
			// 
			// _txtDisplayLabel_2
			// 
			this._txtDisplayLabel_2.AllowDrop = true;
			this._txtDisplayLabel_2.Location = new System.Drawing.Point(89, 73);
			this._txtDisplayLabel_2.Name = "_txtDisplayLabel_2";
			this._txtDisplayLabel_2.Size = new System.Drawing.Size(101, 19);
			this._txtDisplayLabel_2.TabIndex = 37;
			this._txtDisplayLabel_2.TabStop = false;
			// 
			// _txtDisplayLabel_3
			// 
			this._txtDisplayLabel_3.AllowDrop = true;
			this._txtDisplayLabel_3.Location = new System.Drawing.Point(192, 73);
			this._txtDisplayLabel_3.Name = "_txtDisplayLabel_3";
			this._txtDisplayLabel_3.Size = new System.Drawing.Size(201, 19);
			this._txtDisplayLabel_3.TabIndex = 38;
			this._txtDisplayLabel_3.TabStop = false;
			// 
			// _txtCommonTextBox_1
			// 
			this._txtCommonTextBox_1.AllowDrop = true;
			this._txtCommonTextBox_1.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_1.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_1.Location = new System.Drawing.Point(89, 52);
			this._txtCommonTextBox_1.MaxLength = 10;
			this._txtCommonTextBox_1.Name = "_txtCommonTextBox_1";
			// this._txtCommonTextBox_1.ShowButton = true;
			this._txtCommonTextBox_1.Size = new System.Drawing.Size(101, 19);
			this._txtCommonTextBox_1.TabIndex = 5;
			this._txtCommonTextBox_1.Text = "";
			// this.this._txtCommonTextBox_1.Watermark = "";
			// this.this._txtCommonTextBox_1.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_1.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _txtDisplayLabel_0
			// 
			this._txtDisplayLabel_0.AllowDrop = true;
			this._txtDisplayLabel_0.Location = new System.Drawing.Point(192, 52);
			this._txtDisplayLabel_0.Name = "_txtDisplayLabel_0";
			this._txtDisplayLabel_0.Size = new System.Drawing.Size(417, 19);
			this._txtDisplayLabel_0.TabIndex = 39;
			this._txtDisplayLabel_0.TabStop = false;
			// 
			// _txtDisplayLabel_8
			// 
			this._txtDisplayLabel_8.AllowDrop = true;
			this._txtDisplayLabel_8.Location = new System.Drawing.Point(611, 74);
			this._txtDisplayLabel_8.Name = "_txtDisplayLabel_8";
			this._txtDisplayLabel_8.Size = new System.Drawing.Size(188, 19);
			this._txtDisplayLabel_8.TabIndex = 40;
			this._txtDisplayLabel_8.TabStop = false;
			// 
			// _lblCommonLabel_7
			// 
			this._lblCommonLabel_7.AllowDrop = true;
			this._lblCommonLabel_7.BackColor = System.Drawing.Color.White;
			this._lblCommonLabel_7.Text = "New Department";
			this._lblCommonLabel_7.Location = new System.Drawing.Point(396, 96);
			// this._lblCommonLabel_7.mLabelId = 1225;
			this._lblCommonLabel_7.Name = "_lblCommonLabel_7";
			this._lblCommonLabel_7.Size = new System.Drawing.Size(81, 14);
			this._lblCommonLabel_7.TabIndex = 41;
			// 
			// _txtDisplayLabel_10
			// 
			this._txtDisplayLabel_10.AllowDrop = true;
			this._txtDisplayLabel_10.Location = new System.Drawing.Point(611, 95);
			this._txtDisplayLabel_10.Name = "_txtDisplayLabel_10";
			this._txtDisplayLabel_10.Size = new System.Drawing.Size(188, 19);
			this._txtDisplayLabel_10.TabIndex = 42;
			this._txtDisplayLabel_10.TabStop = false;
			// 
			// _txtCommonTextBox_4
			// 
			this._txtCommonTextBox_4.AllowDrop = true;
			this._txtCommonTextBox_4.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_4.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_4.Location = new System.Drawing.Point(507, 73);
			this._txtCommonTextBox_4.MaxLength = 10;
			this._txtCommonTextBox_4.Name = "_txtCommonTextBox_4";
			// this._txtCommonTextBox_4.ShowButton = true;
			this._txtCommonTextBox_4.Size = new System.Drawing.Size(101, 19);
			this._txtCommonTextBox_4.TabIndex = 6;
			this._txtCommonTextBox_4.Text = "";
			// this.this._txtCommonTextBox_4.Watermark = "";
			// this.this._txtCommonTextBox_4.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_4.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _txtCommonTextBox_5
			// 
			this._txtCommonTextBox_5.AllowDrop = true;
			this._txtCommonTextBox_5.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_5.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_5.Location = new System.Drawing.Point(507, 94);
			this._txtCommonTextBox_5.MaxLength = 10;
			this._txtCommonTextBox_5.Name = "_txtCommonTextBox_5";
			// this._txtCommonTextBox_5.ShowButton = true;
			this._txtCommonTextBox_5.Size = new System.Drawing.Size(101, 19);
			this._txtCommonTextBox_5.TabIndex = 7;
			this._txtCommonTextBox_5.Text = "";
			// this.this._txtCommonTextBox_5.Watermark = "";
			// this.this._txtCommonTextBox_5.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_5.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _lblCommonLabel_3
			// 
			this._lblCommonLabel_3.AllowDrop = true;
			this._lblCommonLabel_3.BackColor = System.Drawing.Color.White;
			this._lblCommonLabel_3.Text = "New Designation";
			this._lblCommonLabel_3.Location = new System.Drawing.Point(396, 75);
			// this._lblCommonLabel_3.mLabelId = 1226;
			this._lblCommonLabel_3.Name = "_lblCommonLabel_3";
			this._lblCommonLabel_3.Size = new System.Drawing.Size(82, 14);
			this._lblCommonLabel_3.TabIndex = 43;
			// 
			// _lblCommonLabel_8
			// 
			this._lblCommonLabel_8.AllowDrop = true;
			this._lblCommonLabel_8.BackColor = System.Drawing.Color.White;
			this._lblCommonLabel_8.Text = "Type";
			this._lblCommonLabel_8.Location = new System.Drawing.Point(226, 13);
			// this._lblCommonLabel_8.mLabelId = 2120;
			this._lblCommonLabel_8.Name = "_lblCommonLabel_8";
			this._lblCommonLabel_8.Size = new System.Drawing.Size(24, 14);
			this._lblCommonLabel_8.TabIndex = 44;
			// 
			// cmbType
			// 
			this.cmbType.AllowDrop = true;
			this.cmbType.Location = new System.Drawing.Point(281, 9);
			this.cmbType.Name = "cmbType";
			this.cmbType.Size = new System.Drawing.Size(112, 21);
			this.cmbType.TabIndex = 1;
			// this.cmbType.Click += new System.Windows.Forms.ComboBox.ClickHandler(this.cmbType_Click);
			// 
			// _lblCommonLabel_10
			// 
			this._lblCommonLabel_10.AllowDrop = true;
			this._lblCommonLabel_10.BackColor = System.Drawing.Color.White;
			this._lblCommonLabel_10.Text = "Effective Date";
			this._lblCommonLabel_10.Location = new System.Drawing.Point(616, 13);
			// this._lblCommonLabel_10.mLabelId = 2147;
			this._lblCommonLabel_10.Name = "_lblCommonLabel_10";
			this._lblCommonLabel_10.Size = new System.Drawing.Size(68, 14);
			this._lblCommonLabel_10.TabIndex = 45;
			// 
			// txtEffectiveDate
			// 
			this.txtEffectiveDate.AllowDrop = true;
			// this.txtEffectiveDate.CheckDateRange = false;
			this.txtEffectiveDate.Location = new System.Drawing.Point(697, 10);
			// this.txtEffectiveDate.MaxDate = 2958465;
			// this.txtEffectiveDate.MinDate = 32874;
			this.txtEffectiveDate.Name = "txtEffectiveDate";
			this.txtEffectiveDate.Size = new System.Drawing.Size(102, 19);
			this.txtEffectiveDate.TabIndex = 3;
			this.txtEffectiveDate.Text = "18-Jul-2001";
			this.txtEffectiveDate.Value = 37090;
			// 
			// frmPaySalaryVariation
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.ClientSize = new System.Drawing.Size(820, 421);
			this.Controls.Add(this.tabSalaryVariation);
			this.Controls.Add(this._txtCommonTextBox_11);
			this.Controls.Add(this._lblCommonLabel_9);
			this.Controls.Add(this._lblCommonLabel_12);
			this.Controls.Add(this.fraTabPage0);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			//this.Icon = (System.Drawing.Icon) resources.GetObject("frmPaySalaryVariation.Icon");
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(84, 159);
			this.MaximizeBox = true;
			this.MinimizeBox = true;
			this.Name = "frmPaySalaryVariation";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Tag = "\"H: 6225  W:9570\"";
			this.Text = "Salary Variation";
			// this.Activated += new System.EventHandler(this.Form_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
			// this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
			//((System.ComponentModel.ISupportInitialize) this.txtTempDate).EndInit();
			//((System.ComponentModel.ISupportInitialize) this.tabSalaryVariation).EndInit();
			//((System.ComponentModel.ISupportInitialize) this.fraTabPage0).EndInit();
			this.tabSalaryVariation.ResumeLayout(false);
			this._fraEmployeeInformation_3.ResumeLayout(false);
			this.Frame3.ResumeLayout(false);
			this.Frame2.ResumeLayout(false);
			this.Frame1.ResumeLayout(false);
			this.grdVoucherDetails.ResumeLayout(false);
			this.cmbMastersList.ResumeLayout(false);
			this.fraTabPage0.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		void ReLoadForm(bool addEvents)
		{
			InitializetxtDisplayLabel();
			InitializetxtCommonTextBox();
			InitializelblCommonLabel();
			InitializelblCommon();
			InitializefraEmployeeInformation();
			InitializecmbCommon();
			InitializeSystem.Windows.Forms.Label1();
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
			this.txtDisplayLabel = new System.Windows.Forms.Label[19];
			this.txtDisplayLabel[18] = _txtDisplayLabel_18;
			this.txtDisplayLabel[7] = _txtDisplayLabel_7;
			this.txtDisplayLabel[1] = _txtDisplayLabel_1;
			this.txtDisplayLabel[4] = _txtDisplayLabel_4;
			this.txtDisplayLabel[5] = _txtDisplayLabel_5;
			this.txtDisplayLabel[6] = _txtDisplayLabel_6;
			this.txtDisplayLabel[2] = _txtDisplayLabel_2;
			this.txtDisplayLabel[3] = _txtDisplayLabel_3;
			this.txtDisplayLabel[0] = _txtDisplayLabel_0;
			this.txtDisplayLabel[8] = _txtDisplayLabel_8;
			this.txtDisplayLabel[10] = _txtDisplayLabel_10;
		}
		void InitializetxtCommonTextBox()
		{
			this.txtCommonTextBox = new System.Windows.Forms.TextBox[73];
			this.txtCommonTextBox[72] = _txtCommonTextBox_72;
			this.txtCommonTextBox[6] = _txtCommonTextBox_6;
			this.txtCommonTextBox[11] = _txtCommonTextBox_11;
			this.txtCommonTextBox[0] = _txtCommonTextBox_0;
			this.txtCommonTextBox[2] = _txtCommonTextBox_2;
			this.txtCommonTextBox[3] = _txtCommonTextBox_3;
			this.txtCommonTextBox[1] = _txtCommonTextBox_1;
			this.txtCommonTextBox[4] = _txtCommonTextBox_4;
			this.txtCommonTextBox[5] = _txtCommonTextBox_5;
		}
		void InitializelblCommonLabel()
		{
			this.lblCommonLabel = new System.Windows.Forms.Label[29];
			this.lblCommonLabel[28] = _lblCommonLabel_28;
			this.lblCommonLabel[11] = _lblCommonLabel_11;
			this.lblCommonLabel[13] = _lblCommonLabel_13;
			this.lblCommonLabel[9] = _lblCommonLabel_9;
			this.lblCommonLabel[12] = _lblCommonLabel_12;
			this.lblCommonLabel[4] = _lblCommonLabel_4;
			this.lblCommonLabel[2] = _lblCommonLabel_2;
			this.lblCommonLabel[5] = _lblCommonLabel_5;
			this.lblCommonLabel[6] = _lblCommonLabel_6;
			this.lblCommonLabel[23] = _lblCommonLabel_23;
			this.lblCommonLabel[21] = _lblCommonLabel_21;
			this.lblCommonLabel[0] = _lblCommonLabel_0;
			this.lblCommonLabel[1] = _lblCommonLabel_1;
			this.lblCommonLabel[7] = _lblCommonLabel_7;
			this.lblCommonLabel[3] = _lblCommonLabel_3;
			this.lblCommonLabel[8] = _lblCommonLabel_8;
			this.lblCommonLabel[10] = _lblCommonLabel_10;
		}
		void InitializelblCommon()
		{
			this.lblCommon = new System.Windows.Forms.Label[108];
			this.lblCommon[74] = _lblCommon_74;
			this.lblCommon[8] = _lblCommon_8;
			this.lblCommon[107] = _lblCommon_107;
			this.lblCommon[4] = _lblCommon_4;
			this.lblCommon[1] = _lblCommon_1;
			this.lblCommon[2] = _lblCommon_2;
			this.lblCommon[0] = _lblCommon_0;
			this.lblCommon[3] = _lblCommon_3;
			this.lblCommon[104] = _lblCommon_104;
			this.lblCommon[5] = _lblCommon_5;
			this.lblCommon[6] = _lblCommon_6;
			this.lblCommon[7] = _lblCommon_7;
		}
		void InitializefraEmployeeInformation()
		{
			this.fraEmployeeInformation = new System.Windows.Forms.Panel[4];
			this.fraEmployeeInformation[3] = _fraEmployeeInformation_3;
		}
		void InitializecmbCommon()
		{
			this.cmbCommon = new System.Windows.Forms.ComboBox[2];
			this.cmbCommon[1] = _cmbCommon_1;
			this.cmbCommon[0] = _cmbCommon_0;
		}
		void InitializeSystem.Windows.Forms.Label1()
		{
			this.System.Windows.Forms.Label1 = new System.Windows.Forms.Label[10];
			this.System.Windows.Forms.Label1[9] = _System.Windows.Forms.Label1_9;
			this.System.Windows.Forms.Label1[0] = _System.Windows.Forms.Label1_0;
		}
		#endregion
	}
}