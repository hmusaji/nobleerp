
namespace Xtreme
{
	partial class frmPayTermination
	{

		#region "Upgrade Support "
		private static frmPayTermination m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmPayTermination DefInstance
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
		public static frmPayTermination CreateInstance()
		{
			frmPayTermination theInstance = new frmPayTermination();
			
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
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "chkIsReplacement", "chkBudget", "_txtCommonTextBox_72", "_lblCommon_74", "_txtDisplayLabel_26", "_fraEmployeeInformation_3", "Column_0_cmbMastersList", "Column_1_cmbMastersList", "cmbMastersList", "Column_0_grdVoucherDetails", "Column_1_grdVoucherDetails", "grdVoucherDetails", "frmTerminationDetails", "cmdSubmmitApproval", "txtDlblAppTemplateName", "txtApprovalTemplate", "_lblCommonLabel_28", "frmApproval", "_lblCommonLabel_7", "_lblCommonLabel_9", "_lblCommonLabel_15", "_lblCommonLabel_16", "_lblCommonLabel_14", "_lblCommonLabel_13", "_txtCommonNumber_1", "_lblCommonLabel_11", "_lblCommonLabel_19", "_txtCommonNumber_0", "_txtDisplayLabel_11", "_txtDisplayLabel_10", "_txtDisplayLabel_9", "_txtDisplayLabel_7", "_txtDisplayLabel_8", "_txtDisplayLabel_12", "_lblCommonLabel_18", "_txtDisplayLabel_15", "_txtDisplayLabel_14", "_lblCommonLabel_17", "_txtCommonNumber_2", "_txtDisplayLabel_17", "_txtDisplayLabel_13", "_lblCommonLabel_20", "_txtDisplayLabel_16", "_txtDisplayLabel_22", "_txtDisplayLabel_23", "_txtDisplayLabel_24", "_lblCommonLabel_31", "_txtDisplayLabel_25", "Line1", "Line2", "frmTermination", "tabTermination", "_lblCommonLabel_0", "_lblCommonLabel_6", "_lblCommonLabel_10", "_lblCommonLabel_12", "txtVoucherDate", "_CmbCommon_0", "_txtCommonTextBox_2", "_txtCommonTextBox_0", "_txtCommonTextBox_3", "_lblCommonLabel_2", "_lblCommonLabel_1", "_lblCommonLabel_3", "_lblCommonLabel_4", "_txtCommonTextBox_1", "_lblCommonLabel_5", "_txtDisplayLabel_0", "_txtDisplayLabel_1", "_txtDisplayLabel_2", "_txtDisplayLabel_3", "_txtDisplayLabel_4", "_txtDisplayLabel_6", "_txtDisplayLabel_5", "_lblCommonLabel_21", "_txtCommonTextBox_4", "_txtDisplayLabel_18", "_txtCommonNumber_3", "_lblCommonLabel_24", "_lblCommonLabel_22", "_lblCommonLabel_23", "_txtDisplayLabel_19", "_txtCommonNumber_4", "_txtCommonTextBox_5", "_lblCommonLabel_25", "_lblCommonLabel_26", "_lblCommonLabel_27", "_txtCommonNumber_5", "_txtDisplayLabel_20", "_lblCommon_102", "_txtDisplayLabel_21", "txtNoticePeriod", "lblNoticePeriod", "_lblCommonLabel_29", "txtDSubmittedDate", "_lblCommonLabel_8", "_lblCommonLabel_30", "_cmbSeveranceStatus_0", "_lblCommon_109", "txtJoiningDate", "CmbCommon", "cmbSeveranceStatus", "fraEmployeeInformation", "lblCommon", "lblCommonLabel", "txtCommonNumber", "txtCommonTextBox", "txtDisplayLabel"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public System.Windows.Forms.CheckBox chkIsReplacement;
		public System.Windows.Forms.CheckBox chkBudget;
		private System.Windows.Forms.TextBox _txtCommonTextBox_72;
		private System.Windows.Forms.Label _lblCommon_74;
		private System.Windows.Forms.Label _txtDisplayLabel_26;
		private System.Windows.Forms.Panel _fraEmployeeInformation_3;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_0_cmbMastersList;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_1_cmbMastersList;
		public C1.Win.C1TrueDBGrid.C1TrueDBDropdown cmbMastersList;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_0_grdVoucherDetails;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_1_grdVoucherDetails;
		public C1.Win.C1TrueDBGrid.C1TrueDBGrid grdVoucherDetails;
		public System.Windows.Forms.GroupBox frmTerminationDetails;
		public System.Windows.Forms.Button cmdSubmmitApproval;
		public System.Windows.Forms.Label txtDlblAppTemplateName;
		public System.Windows.Forms.TextBox txtApprovalTemplate;
		private System.Windows.Forms.Label _lblCommonLabel_28;
		public System.Windows.Forms.Panel frmApproval;
		private System.Windows.Forms.Label _lblCommonLabel_7;
		private System.Windows.Forms.Label _lblCommonLabel_9;
		private System.Windows.Forms.Label _lblCommonLabel_15;
		private System.Windows.Forms.Label _lblCommonLabel_16;
		private System.Windows.Forms.Label _lblCommonLabel_14;
		private System.Windows.Forms.Label _lblCommonLabel_13;
		private System.Windows.Forms.TextBox _txtCommonNumber_1;
		private System.Windows.Forms.Label _lblCommonLabel_11;
		private System.Windows.Forms.Label _lblCommonLabel_19;
		private System.Windows.Forms.TextBox _txtCommonNumber_0;
		private System.Windows.Forms.Label _txtDisplayLabel_11;
		private System.Windows.Forms.Label _txtDisplayLabel_10;
		private System.Windows.Forms.Label _txtDisplayLabel_9;
		private System.Windows.Forms.Label _txtDisplayLabel_7;
		private System.Windows.Forms.Label _txtDisplayLabel_8;
		private System.Windows.Forms.Label _txtDisplayLabel_12;
		private System.Windows.Forms.Label _lblCommonLabel_18;
		private System.Windows.Forms.Label _txtDisplayLabel_15;
		private System.Windows.Forms.Label _txtDisplayLabel_14;
		private System.Windows.Forms.Label _lblCommonLabel_17;
		private System.Windows.Forms.TextBox _txtCommonNumber_2;
		private System.Windows.Forms.Label _txtDisplayLabel_17;
		private System.Windows.Forms.Label _txtDisplayLabel_13;
		private System.Windows.Forms.Label _lblCommonLabel_20;
		private System.Windows.Forms.Label _txtDisplayLabel_16;
		private System.Windows.Forms.Label _txtDisplayLabel_22;
		private System.Windows.Forms.Label _txtDisplayLabel_23;
		private System.Windows.Forms.Label _txtDisplayLabel_24;
		private System.Windows.Forms.Label _lblCommonLabel_31;
		private System.Windows.Forms.Label _txtDisplayLabel_25;
		public System.Windows.Forms.Label Line1;
		public System.Windows.Forms.Label Line2;
		public System.Windows.Forms.GroupBox frmTermination;
		public Syncfusion.Windows.Forms.Tools.TabControlAdv tabTermination;
		private System.Windows.Forms.Label _lblCommonLabel_0;
		private System.Windows.Forms.Label _lblCommonLabel_6;
		private System.Windows.Forms.Label _lblCommonLabel_10;
		private System.Windows.Forms.Label _lblCommonLabel_12;
		public Syncfusion.WinForms.Input.SfDateTimeEdit txtVoucherDate;
		private System.Windows.Forms.ComboBox _CmbCommon_0;
		private System.Windows.Forms.TextBox _txtCommonTextBox_2;
		private System.Windows.Forms.TextBox _txtCommonTextBox_0;
		private System.Windows.Forms.TextBox _txtCommonTextBox_3;
		private System.Windows.Forms.Label _lblCommonLabel_2;
		private System.Windows.Forms.Label _lblCommonLabel_1;
		private System.Windows.Forms.Label _lblCommonLabel_3;
		private System.Windows.Forms.Label _lblCommonLabel_4;
		private System.Windows.Forms.TextBox _txtCommonTextBox_1;
		private System.Windows.Forms.Label _lblCommonLabel_5;
		private System.Windows.Forms.Label _txtDisplayLabel_0;
		private System.Windows.Forms.Label _txtDisplayLabel_1;
		private System.Windows.Forms.Label _txtDisplayLabel_2;
		private System.Windows.Forms.Label _txtDisplayLabel_3;
		private System.Windows.Forms.Label _txtDisplayLabel_4;
		private System.Windows.Forms.Label _txtDisplayLabel_6;
		private System.Windows.Forms.Label _txtDisplayLabel_5;
		private System.Windows.Forms.Label _lblCommonLabel_21;
		private System.Windows.Forms.TextBox _txtCommonTextBox_4;
		private System.Windows.Forms.Label _txtDisplayLabel_18;
		private System.Windows.Forms.TextBox _txtCommonNumber_3;
		private System.Windows.Forms.Label _lblCommonLabel_24;
		private System.Windows.Forms.Label _lblCommonLabel_22;
		private System.Windows.Forms.Label _lblCommonLabel_23;
		private System.Windows.Forms.Label _txtDisplayLabel_19;
		private System.Windows.Forms.TextBox _txtCommonNumber_4;
		private System.Windows.Forms.TextBox _txtCommonTextBox_5;
		private System.Windows.Forms.Label _lblCommonLabel_25;
		private System.Windows.Forms.Label _lblCommonLabel_26;
		private System.Windows.Forms.Label _lblCommonLabel_27;
		private System.Windows.Forms.TextBox _txtCommonNumber_5;
		private System.Windows.Forms.Label _txtDisplayLabel_20;
		private System.Windows.Forms.Label _lblCommon_102;
		private System.Windows.Forms.Label _txtDisplayLabel_21;
		public System.Windows.Forms.TextBox txtNoticePeriod;
		public System.Windows.Forms.Label lblNoticePeriod;
		private System.Windows.Forms.Label _lblCommonLabel_29;
		public Syncfusion.WinForms.Input.SfDateTimeEdit txtDSubmittedDate;
		private System.Windows.Forms.Label _lblCommonLabel_8;
		private System.Windows.Forms.Label _lblCommonLabel_30;
		private System.Windows.Forms.ComboBox _cmbSeveranceStatus_0;
		private System.Windows.Forms.Label _lblCommon_109;
		public Syncfusion.WinForms.Input.SfDateTimeEdit txtJoiningDate;
		public System.Windows.Forms.ComboBox[] CmbCommon = new System.Windows.Forms.ComboBox[1];
		public System.Windows.Forms.ComboBox[] cmbSeveranceStatus = new System.Windows.Forms.ComboBox[1];
		public System.Windows.Forms.Panel[] fraEmployeeInformation = new System.Windows.Forms.Panel[4];
		public System.Windows.Forms.Label[] lblCommon = new System.Windows.Forms.Label[110];
		public System.Windows.Forms.Label[] lblCommonLabel = new System.Windows.Forms.Label[32];
		public System.Windows.Forms.TextBox[] txtCommonNumber = new System.Windows.Forms.TextBox[6];
		public System.Windows.Forms.TextBox[] txtCommonTextBox = new System.Windows.Forms.TextBox[73];
		public System.Windows.Forms.Label[] txtDisplayLabel = new System.Windows.Forms.Label[27];
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPayTermination));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this.tabTermination = new Syncfusion.Windows.Forms.Tools.TabControlAdv();
			this._fraEmployeeInformation_3 = new System.Windows.Forms.Panel();
			this.chkIsReplacement = new System.Windows.Forms.CheckBox();
			this.chkBudget = new System.Windows.Forms.CheckBox();
			this._txtCommonTextBox_72 = new System.Windows.Forms.TextBox();
			this._lblCommon_74 = new System.Windows.Forms.Label();
			this._txtDisplayLabel_26 = new System.Windows.Forms.Label();
			this.frmTerminationDetails = new System.Windows.Forms.GroupBox();
			this.cmbMastersList = new C1.Win.C1TrueDBGrid.C1TrueDBDropdown();
			this.Column_0_cmbMastersList = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.Column_1_cmbMastersList = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.grdVoucherDetails = new C1.Win.C1TrueDBGrid.C1TrueDBGrid();
			this.Column_0_grdVoucherDetails = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.Column_1_grdVoucherDetails = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.frmTermination = new System.Windows.Forms.GroupBox();
			this.frmApproval = new System.Windows.Forms.Panel();
			this.cmdSubmmitApproval = new System.Windows.Forms.Button();
			this.txtDlblAppTemplateName = new System.Windows.Forms.Label();
			this.txtApprovalTemplate = new System.Windows.Forms.TextBox();
			this._lblCommonLabel_28 = new System.Windows.Forms.Label();
			this._lblCommonLabel_7 = new System.Windows.Forms.Label();
			this._lblCommonLabel_9 = new System.Windows.Forms.Label();
			this._lblCommonLabel_15 = new System.Windows.Forms.Label();
			this._lblCommonLabel_16 = new System.Windows.Forms.Label();
			this._lblCommonLabel_14 = new System.Windows.Forms.Label();
			this._lblCommonLabel_13 = new System.Windows.Forms.Label();
			this._txtCommonNumber_1 = new System.Windows.Forms.TextBox();
			this._lblCommonLabel_11 = new System.Windows.Forms.Label();
			this._lblCommonLabel_19 = new System.Windows.Forms.Label();
			this._txtCommonNumber_0 = new System.Windows.Forms.TextBox();
			this._txtDisplayLabel_11 = new System.Windows.Forms.Label();
			this._txtDisplayLabel_10 = new System.Windows.Forms.Label();
			this._txtDisplayLabel_9 = new System.Windows.Forms.Label();
			this._txtDisplayLabel_7 = new System.Windows.Forms.Label();
			this._txtDisplayLabel_8 = new System.Windows.Forms.Label();
			this._txtDisplayLabel_12 = new System.Windows.Forms.Label();
			this._lblCommonLabel_18 = new System.Windows.Forms.Label();
			this._txtDisplayLabel_15 = new System.Windows.Forms.Label();
			this._txtDisplayLabel_14 = new System.Windows.Forms.Label();
			this._lblCommonLabel_17 = new System.Windows.Forms.Label();
			this._txtCommonNumber_2 = new System.Windows.Forms.TextBox();
			this._txtDisplayLabel_17 = new System.Windows.Forms.Label();
			this._txtDisplayLabel_13 = new System.Windows.Forms.Label();
			this._lblCommonLabel_20 = new System.Windows.Forms.Label();
			this._txtDisplayLabel_16 = new System.Windows.Forms.Label();
			this._txtDisplayLabel_22 = new System.Windows.Forms.Label();
			this._txtDisplayLabel_23 = new System.Windows.Forms.Label();
			this._txtDisplayLabel_24 = new System.Windows.Forms.Label();
			this._lblCommonLabel_31 = new System.Windows.Forms.Label();
			this._txtDisplayLabel_25 = new System.Windows.Forms.Label();
			this.Line1 = new System.Windows.Forms.Label();
			this.Line2 = new System.Windows.Forms.Label();
			this._lblCommonLabel_0 = new System.Windows.Forms.Label();
			this._lblCommonLabel_6 = new System.Windows.Forms.Label();
			this._lblCommonLabel_10 = new System.Windows.Forms.Label();
			this._lblCommonLabel_12 = new System.Windows.Forms.Label();
			this.txtVoucherDate = new Syncfusion.WinForms.Input.SfDateTimeEdit();
			this._CmbCommon_0 = new System.Windows.Forms.ComboBox();
			this._txtCommonTextBox_2 = new System.Windows.Forms.TextBox();
			this._txtCommonTextBox_0 = new System.Windows.Forms.TextBox();
			this._txtCommonTextBox_3 = new System.Windows.Forms.TextBox();
			this._lblCommonLabel_2 = new System.Windows.Forms.Label();
			this._lblCommonLabel_1 = new System.Windows.Forms.Label();
			this._lblCommonLabel_3 = new System.Windows.Forms.Label();
			this._lblCommonLabel_4 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_1 = new System.Windows.Forms.TextBox();
			this._lblCommonLabel_5 = new System.Windows.Forms.Label();
			this._txtDisplayLabel_0 = new System.Windows.Forms.Label();
			this._txtDisplayLabel_1 = new System.Windows.Forms.Label();
			this._txtDisplayLabel_2 = new System.Windows.Forms.Label();
			this._txtDisplayLabel_3 = new System.Windows.Forms.Label();
			this._txtDisplayLabel_4 = new System.Windows.Forms.Label();
			this._txtDisplayLabel_6 = new System.Windows.Forms.Label();
			this._txtDisplayLabel_5 = new System.Windows.Forms.Label();
			this._lblCommonLabel_21 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_4 = new System.Windows.Forms.TextBox();
			this._txtDisplayLabel_18 = new System.Windows.Forms.Label();
			this._txtCommonNumber_3 = new System.Windows.Forms.TextBox();
			this._lblCommonLabel_24 = new System.Windows.Forms.Label();
			this._lblCommonLabel_22 = new System.Windows.Forms.Label();
			this._lblCommonLabel_23 = new System.Windows.Forms.Label();
			this._txtDisplayLabel_19 = new System.Windows.Forms.Label();
			this._txtCommonNumber_4 = new System.Windows.Forms.TextBox();
			this._txtCommonTextBox_5 = new System.Windows.Forms.TextBox();
			this._lblCommonLabel_25 = new System.Windows.Forms.Label();
			this._lblCommonLabel_26 = new System.Windows.Forms.Label();
			this._lblCommonLabel_27 = new System.Windows.Forms.Label();
			this._txtCommonNumber_5 = new System.Windows.Forms.TextBox();
			this._txtDisplayLabel_20 = new System.Windows.Forms.Label();
			this._lblCommon_102 = new System.Windows.Forms.Label();
			this._txtDisplayLabel_21 = new System.Windows.Forms.Label();
			this.txtNoticePeriod = new System.Windows.Forms.TextBox();
			this.lblNoticePeriod = new System.Windows.Forms.Label();
			this._lblCommonLabel_29 = new System.Windows.Forms.Label();
			this.txtDSubmittedDate = new Syncfusion.WinForms.Input.SfDateTimeEdit();
			this._lblCommonLabel_8 = new System.Windows.Forms.Label();
			this._lblCommonLabel_30 = new System.Windows.Forms.Label();
			this._cmbSeveranceStatus_0 = new System.Windows.Forms.ComboBox();
			this._lblCommon_109 = new System.Windows.Forms.Label();
			this.txtJoiningDate = new Syncfusion.WinForms.Input.SfDateTimeEdit();
			// //((System.ComponentModel.ISupportInitialize) this.tabTermination).BeginInit();
			//this.tabTermination.SuspendLayout();
			//this._fraEmployeeInformation_3.SuspendLayout();
			//this.frmTerminationDetails.SuspendLayout();
			//this.cmbMastersList.SuspendLayout();
			//this.grdVoucherDetails.SuspendLayout();
			//this.frmTermination.SuspendLayout();
			//this.frmApproval.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabTermination
			// 
			this.tabTermination.Align = C1SizerLib.AlignSettings.asNone;
			this.tabTermination.AllowDrop = true;
			this.tabTermination.Controls.Add(this._fraEmployeeInformation_3);
			this.tabTermination.Controls.Add(this.frmTerminationDetails);
			this.tabTermination.Controls.Add(this.frmTermination);
			this.tabTermination.Location = new System.Drawing.Point(3, 221);
			this.tabTermination.Name = "tabTermination";
			//
			this.tabTermination.Size = new System.Drawing.Size(613, 283);
			this.tabTermination.TabIndex = 8;
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
			this._fraEmployeeInformation_3.Controls.Add(this._txtDisplayLabel_26);
			this._fraEmployeeInformation_3.Enabled = true;
			this._fraEmployeeInformation_3.ForeColor = System.Drawing.SystemColors.WindowText;
			this._fraEmployeeInformation_3.Location = new System.Drawing.Point(1, 21);
			this._fraEmployeeInformation_3.Name = "_fraEmployeeInformation_3";
			this._fraEmployeeInformation_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._fraEmployeeInformation_3.Size = new System.Drawing.Size(611, 261);
			this._fraEmployeeInformation_3.TabIndex = 88;
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
			this.chkIsReplacement.Location = new System.Drawing.Point(444, 54);
			this.chkIsReplacement.Name = "chkIsReplacement";
			this.chkIsReplacement.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.chkIsReplacement.Size = new System.Drawing.Size(103, 19);
			this.chkIsReplacement.TabIndex = 91;
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
			this.chkBudget.Location = new System.Drawing.Point(15, 21);
			this.chkBudget.Name = "chkBudget";
			this.chkBudget.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.chkBudget.Size = new System.Drawing.Size(91, 19);
			this.chkBudget.TabIndex = 89;
			this.chkBudget.TabStop = true;
			this.chkBudget.Text = "Is Budgeted";
			this.chkBudget.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkBudget.Visible = true;
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
			this._txtCommonTextBox_72.TabIndex = 90;
			this._txtCommonTextBox_72.Text = "";
			// this.// = "";
			// this.//this._txtCommonTextBox_72.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(//this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_72.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _lblCommon_74
			// 
			this._lblCommon_74.AllowDrop = true;
			this._lblCommon_74.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._lblCommon_74.Text = "New Head Count";
			this._lblCommon_74.Location = new System.Drawing.Point(15, 57);
			this._lblCommon_74.Name = "_lblCommon_74";
			this._lblCommon_74.Size = new System.Drawing.Size(57, 13);
			this._lblCommon_74.TabIndex = 92;
			// 
			// _txtDisplayLabel_26
			// 
			this._txtDisplayLabel_26.AllowDrop = true;
			this._txtDisplayLabel_26.Location = new System.Drawing.Point(225, 54);
			this._txtDisplayLabel_26.Name = "_txtDisplayLabel_26";
			this._txtDisplayLabel_26.Size = new System.Drawing.Size(203, 19);
			this._txtDisplayLabel_26.TabIndex = 93;
			this._txtDisplayLabel_26.TabStop = false;
			// 
			// frmTerminationDetails
			// 
			this.frmTerminationDetails.AllowDrop = true;
			this.frmTerminationDetails.BackColor = System.Drawing.SystemColors.Control;
			this.frmTerminationDetails.Controls.Add(this.cmbMastersList);
			this.frmTerminationDetails.Controls.Add(this.grdVoucherDetails);
			this.frmTerminationDetails.Enabled = true;
			this.frmTerminationDetails.ForeColor = System.Drawing.SystemColors.ControlText;
			this.frmTerminationDetails.Location = new System.Drawing.Point(-652, 21);
			this.frmTerminationDetails.Name = "frmTerminationDetails";
			this.frmTerminationDetails.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.frmTerminationDetails.Size = new System.Drawing.Size(611, 261);
			this.frmTerminationDetails.TabIndex = 49;
			this.frmTerminationDetails.Visible = true;
			// 
			// cmbMastersList
			// 
			this.cmbMastersList.AllowDrop = true;
			this.cmbMastersList.ColumnHeaders = true;
			this.cmbMastersList.Enabled = true;
			this.cmbMastersList.Location = new System.Drawing.Point(60, 69);
			this.cmbMastersList.Name = "cmbMastersList";
			this.cmbMastersList.Size = new System.Drawing.Size(53, 37);
			this.cmbMastersList.TabIndex = 50;
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
			// grdVoucherDetails
			// 
			this.grdVoucherDetails.AllowDrop = true;
			this.grdVoucherDetails.BackColor = System.Drawing.Color.Silver;
			this.grdVoucherDetails.CellTipsWidth = 0;
			this.grdVoucherDetails.Location = new System.Drawing.Point(0, 9);
			this.grdVoucherDetails.Name = "grdVoucherDetails";
			this.grdVoucherDetails.RowDivider.Color = System.Drawing.Color.Silver;
			this.grdVoucherDetails.Size = new System.Drawing.Size(602, 245);
			this.grdVoucherDetails.TabIndex = 13;
			this.grdVoucherDetails.Columns.Add(this.Column_0_grdVoucherDetails);
			this.grdVoucherDetails.Columns.Add(this.Column_1_grdVoucherDetails);
			this.grdVoucherDetails.AfterColUpdate += new C1.Win.C1TrueDBGrid.ColEventHandler(this.grdVoucherDetails_AfterColUpdate);
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
			// frmTermination
			// 
			this.frmTermination.AllowDrop = true;
			this.frmTermination.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this.frmTermination.Controls.Add(this.frmApproval);
			this.frmTermination.Controls.Add(this._lblCommonLabel_7);
			this.frmTermination.Controls.Add(this._lblCommonLabel_9);
			this.frmTermination.Controls.Add(this._lblCommonLabel_15);
			this.frmTermination.Controls.Add(this._lblCommonLabel_16);
			this.frmTermination.Controls.Add(this._lblCommonLabel_14);
			this.frmTermination.Controls.Add(this._lblCommonLabel_13);
			this.frmTermination.Controls.Add(this._txtCommonNumber_1);
			this.frmTermination.Controls.Add(this._lblCommonLabel_11);
			this.frmTermination.Controls.Add(this._lblCommonLabel_19);
			this.frmTermination.Controls.Add(this._txtCommonNumber_0);
			this.frmTermination.Controls.Add(this._txtDisplayLabel_11);
			this.frmTermination.Controls.Add(this._txtDisplayLabel_10);
			this.frmTermination.Controls.Add(this._txtDisplayLabel_9);
			this.frmTermination.Controls.Add(this._txtDisplayLabel_7);
			this.frmTermination.Controls.Add(this._txtDisplayLabel_8);
			this.frmTermination.Controls.Add(this._txtDisplayLabel_12);
			this.frmTermination.Controls.Add(this._lblCommonLabel_18);
			this.frmTermination.Controls.Add(this._txtDisplayLabel_15);
			this.frmTermination.Controls.Add(this._txtDisplayLabel_14);
			this.frmTermination.Controls.Add(this._lblCommonLabel_17);
			this.frmTermination.Controls.Add(this._txtCommonNumber_2);
			this.frmTermination.Controls.Add(this._txtDisplayLabel_17);
			this.frmTermination.Controls.Add(this._txtDisplayLabel_13);
			this.frmTermination.Controls.Add(this._lblCommonLabel_20);
			this.frmTermination.Controls.Add(this._txtDisplayLabel_16);
			this.frmTermination.Controls.Add(this._txtDisplayLabel_22);
			this.frmTermination.Controls.Add(this._txtDisplayLabel_23);
			this.frmTermination.Controls.Add(this._txtDisplayLabel_24);
			this.frmTermination.Controls.Add(this._lblCommonLabel_31);
			this.frmTermination.Controls.Add(this._txtDisplayLabel_25);
			this.frmTermination.Controls.Add(this.Line1);
			this.frmTermination.Controls.Add(this.Line2);
			this.frmTermination.Enabled = true;
			this.frmTermination.ForeColor = System.Drawing.SystemColors.ControlText;
			this.frmTermination.Location = new System.Drawing.Point(-672, 21);
			this.frmTermination.Name = "frmTermination";
			this.frmTermination.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.frmTermination.Size = new System.Drawing.Size(611, 261);
			this.frmTermination.TabIndex = 48;
			this.frmTermination.Visible = true;
			// 
			// frmApproval
			// 
			this.frmApproval.AllowDrop = true;
			this.frmApproval.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this.frmApproval.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.frmApproval.Controls.Add(this.cmdSubmmitApproval);
			this.frmApproval.Controls.Add(this.txtDlblAppTemplateName);
			this.frmApproval.Controls.Add(this.txtApprovalTemplate);
			this.frmApproval.Controls.Add(this._lblCommonLabel_28);
			this.frmApproval.Enabled = true;
			this.frmApproval.ForeColor = System.Drawing.SystemColors.ControlText;
			this.frmApproval.Location = new System.Drawing.Point(9, 207);
			this.frmApproval.Name = "frmApproval";
			this.frmApproval.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.frmApproval.Size = new System.Drawing.Size(592, 43);
			this.frmApproval.TabIndex = 72;
			this.frmApproval.Visible = true;
			// 
			// cmdSubmmitApproval
			// 
			this.cmdSubmmitApproval.AllowDrop = true;
			this.cmdSubmmitApproval.BackColor = System.Drawing.SystemColors.Control;
			this.cmdSubmmitApproval.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdSubmmitApproval.Location = new System.Drawing.Point(456, 12);
			this.cmdSubmmitApproval.Name = "cmdSubmmitApproval";
			this.cmdSubmmitApproval.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdSubmmitApproval.Size = new System.Drawing.Size(97, 25);
			this.cmdSubmmitApproval.TabIndex = 14;
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
			this.txtDlblAppTemplateName.Location = new System.Drawing.Point(210, 15);
			this.txtDlblAppTemplateName.Name = "txtDlblAppTemplateName";
			this.txtDlblAppTemplateName.Size = new System.Drawing.Size(226, 19);
			this.txtDlblAppTemplateName.TabIndex = 73;
			// 
			// txtApprovalTemplate
			// 
			this.txtApprovalTemplate.AllowDrop = true;
			this.txtApprovalTemplate.BackColor = System.Drawing.Color.White;
			// // = false;
			this.txtApprovalTemplate.ForeColor = System.Drawing.Color.Black;
			this.txtApprovalTemplate.Location = new System.Drawing.Point(102, 15);
			// // = (System.Windows.Forms.TextBox.DropDownTypes) 0;
			this.txtApprovalTemplate.Name = "txtApprovalTemplate";
			// this.txtApprovalTemplate.ShowButton = true;
			this.txtApprovalTemplate.Size = new System.Drawing.Size(106, 19);
			this.txtApprovalTemplate.TabIndex = 12;
			// this.txtApprovalTemplate.Text = "";
			// this.// = "";
			// this.//this.txtApprovalTemplate.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(//this.txtApprovalTemplate_DropButtonClick);
			// this.txtApprovalTemplate.Leave += new System.EventHandler(this.txtApprovalTemplate_Leave);
			// 
			// _lblCommonLabel_28
			// 
			this._lblCommonLabel_28.AllowDrop = true;
			this._lblCommonLabel_28.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._lblCommonLabel_28.Text = "Approval Template";
			this._lblCommonLabel_28.Location = new System.Drawing.Point(6, 17);
			this._lblCommonLabel_28.Name = "_lblCommonLabel_28";
			this._lblCommonLabel_28.Size = new System.Drawing.Size(90, 14);
			this._lblCommonLabel_28.TabIndex = 74;
			// 
			// _lblCommonLabel_7
			// 
			this._lblCommonLabel_7.AllowDrop = true;
			this._lblCommonLabel_7.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._lblCommonLabel_7.Text = "Indemnity";
			this._lblCommonLabel_7.Location = new System.Drawing.Point(9, 65);
			// // this._lblCommonLabel_7.mLabelId = 1237;
			this._lblCommonLabel_7.Name = "_lblCommonLabel_7";
			this._lblCommonLabel_7.Size = new System.Drawing.Size(45, 14);
			this._lblCommonLabel_7.TabIndex = 51;
			// 
			// _lblCommonLabel_9
			// 
			this._lblCommonLabel_9.AllowDrop = true;
			this._lblCommonLabel_9.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._lblCommonLabel_9.Text = "Leave";
			this._lblCommonLabel_9.Location = new System.Drawing.Point(9, 44);
			// // this._lblCommonLabel_9.mLabelId = 363;
			this._lblCommonLabel_9.Name = "_lblCommonLabel_9";
			this._lblCommonLabel_9.Size = new System.Drawing.Size(30, 14);
			this._lblCommonLabel_9.TabIndex = 52;
			// 
			// _lblCommonLabel_15
			// 
			this._lblCommonLabel_15.AllowDrop = true;
			this._lblCommonLabel_15.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._lblCommonLabel_15.Text = "Amt to be Paid";
			this._lblCommonLabel_15.Location = new System.Drawing.Point(518, 27);
			this._lblCommonLabel_15.Name = "_lblCommonLabel_15";
			this._lblCommonLabel_15.Size = new System.Drawing.Size(69, 14);
			this._lblCommonLabel_15.TabIndex = 53;
			// 
			// _lblCommonLabel_16
			// 
			this._lblCommonLabel_16.AllowDrop = true;
			this._lblCommonLabel_16.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._lblCommonLabel_16.Text = "Account Due";
			this._lblCommonLabel_16.Location = new System.Drawing.Point(346, 27);
			this._lblCommonLabel_16.Name = "_lblCommonLabel_16";
			this._lblCommonLabel_16.Size = new System.Drawing.Size(63, 14);
			this._lblCommonLabel_16.TabIndex = 54;
			// 
			// _lblCommonLabel_14
			// 
			this._lblCommonLabel_14.AllowDrop = true;
			this._lblCommonLabel_14.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._lblCommonLabel_14.Text = "==";
			this._lblCommonLabel_14.Location = new System.Drawing.Point(313, 66);
			this._lblCommonLabel_14.Name = "_lblCommonLabel_14";
			this._lblCommonLabel_14.Size = new System.Drawing.Size(12, 14);
			this._lblCommonLabel_14.TabIndex = 55;
			// 
			// _lblCommonLabel_13
			// 
			this._lblCommonLabel_13.AllowDrop = true;
			this._lblCommonLabel_13.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._lblCommonLabel_13.Text = "==";
			this._lblCommonLabel_13.Location = new System.Drawing.Point(313, 44);
			this._lblCommonLabel_13.Name = "_lblCommonLabel_13";
			this._lblCommonLabel_13.Size = new System.Drawing.Size(12, 14);
			this._lblCommonLabel_13.TabIndex = 56;
			// 
			// _txtCommonNumber_1
			// 
			this._txtCommonNumber_1.AllowDrop = true;
			// this._txtCommonNumber_1.DisplayFormat = "####0.000###;;0.000;0.000";
			// this._txtCommonNumber_1.Format = "###########0.000";
			this._txtCommonNumber_1.Location = new System.Drawing.Point(508, 63);
			// // = 2147483647;
			// // = 0;
			this._txtCommonNumber_1.Name = "_txtCommonNumber_1";
			this._txtCommonNumber_1.Size = new System.Drawing.Size(89, 19);
			this._txtCommonNumber_1.TabIndex = 10;
			this._txtCommonNumber_1.Text = "0.000";
			// this.this._txtCommonNumber_1.Change += new System.Windows.Forms.TextBox.ChangeHandler(this.txtCommonNumber_Change);
			// 
			// _lblCommonLabel_11
			// 
			this._lblCommonLabel_11.AllowDrop = true;
			this._lblCommonLabel_11.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._lblCommonLabel_11.Text = "Days";
			this._lblCommonLabel_11.Location = new System.Drawing.Point(137, 27);
			// // this._lblCommonLabel_11.mLabelId = 1238;
			this._lblCommonLabel_11.Name = "_lblCommonLabel_11";
			this._lblCommonLabel_11.Size = new System.Drawing.Size(25, 14);
			this._lblCommonLabel_11.TabIndex = 57;
			// 
			// _lblCommonLabel_19
			// 
			this._lblCommonLabel_19.AllowDrop = true;
			this._lblCommonLabel_19.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._lblCommonLabel_19.Text = "Amount Per Day";
			this._lblCommonLabel_19.Location = new System.Drawing.Point(213, 27);
			// // this._lblCommonLabel_19.mLabelId = 1243;
			this._lblCommonLabel_19.Name = "_lblCommonLabel_19";
			this._lblCommonLabel_19.Size = new System.Drawing.Size(78, 14);
			this._lblCommonLabel_19.TabIndex = 58;
			// 
			// _txtCommonNumber_0
			// 
			this._txtCommonNumber_0.AllowDrop = true;
			// this._txtCommonNumber_0.DisplayFormat = "####0.000###;;0.000;0.000";
			// this._txtCommonNumber_0.Format = "###########0.000";
			this._txtCommonNumber_0.Location = new System.Drawing.Point(508, 42);
			// // = 2147483647;
			// // = 0;
			this._txtCommonNumber_0.Name = "_txtCommonNumber_0";
			this._txtCommonNumber_0.Size = new System.Drawing.Size(89, 19);
			this._txtCommonNumber_0.TabIndex = 9;
			this._txtCommonNumber_0.Text = "0.000";
			// this.this._txtCommonNumber_0.Change += new System.Windows.Forms.TextBox.ChangeHandler(this.txtCommonNumber_Change);
			// 
			// _txtDisplayLabel_11
			// 
			// this._txtDisplayLabel_11.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
			this._txtDisplayLabel_11.AllowDrop = true;
			this._txtDisplayLabel_11.Location = new System.Drawing.Point(331, 42);
			this._txtDisplayLabel_11.Name = "_txtDisplayLabel_11";
			this._txtDisplayLabel_11.Size = new System.Drawing.Size(86, 19);
			this._txtDisplayLabel_11.TabIndex = 59;
			this._txtDisplayLabel_11.TabStop = false;
			// 
			// _txtDisplayLabel_10
			// 
			// this._txtDisplayLabel_10.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
			this._txtDisplayLabel_10.AllowDrop = true;
			this._txtDisplayLabel_10.Location = new System.Drawing.Point(202, 63);
			this._txtDisplayLabel_10.Name = "_txtDisplayLabel_10";
			this._txtDisplayLabel_10.Size = new System.Drawing.Size(101, 19);
			this._txtDisplayLabel_10.TabIndex = 60;
			this._txtDisplayLabel_10.TabStop = false;
			// 
			// _txtDisplayLabel_9
			// 
			// this._txtDisplayLabel_9.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
			this._txtDisplayLabel_9.AllowDrop = true;
			this._txtDisplayLabel_9.Location = new System.Drawing.Point(202, 42);
			this._txtDisplayLabel_9.Name = "_txtDisplayLabel_9";
			this._txtDisplayLabel_9.Size = new System.Drawing.Size(101, 19);
			this._txtDisplayLabel_9.TabIndex = 61;
			this._txtDisplayLabel_9.TabStop = false;
			// 
			// _txtDisplayLabel_7
			// 
			// this._txtDisplayLabel_7.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
			this._txtDisplayLabel_7.AllowDrop = true;
			this._txtDisplayLabel_7.Location = new System.Drawing.Point(99, 42);
			this._txtDisplayLabel_7.Name = "_txtDisplayLabel_7";
			this._txtDisplayLabel_7.Size = new System.Drawing.Size(101, 19);
			this._txtDisplayLabel_7.TabIndex = 62;
			this._txtDisplayLabel_7.TabStop = false;
			// 
			// _txtDisplayLabel_8
			// 
			// this._txtDisplayLabel_8.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
			this._txtDisplayLabel_8.AllowDrop = true;
			this._txtDisplayLabel_8.Location = new System.Drawing.Point(99, 63);
			this._txtDisplayLabel_8.Name = "_txtDisplayLabel_8";
			this._txtDisplayLabel_8.Size = new System.Drawing.Size(101, 19);
			this._txtDisplayLabel_8.TabIndex = 63;
			this._txtDisplayLabel_8.TabStop = false;
			// 
			// _txtDisplayLabel_12
			// 
			// this._txtDisplayLabel_12.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
			this._txtDisplayLabel_12.AllowDrop = true;
			this._txtDisplayLabel_12.Location = new System.Drawing.Point(331, 63);
			this._txtDisplayLabel_12.Name = "_txtDisplayLabel_12";
			this._txtDisplayLabel_12.Size = new System.Drawing.Size(86, 19);
			this._txtDisplayLabel_12.TabIndex = 64;
			this._txtDisplayLabel_12.TabStop = false;
			// 
			// _lblCommonLabel_18
			// 
			this._lblCommonLabel_18.AllowDrop = true;
			this._lblCommonLabel_18.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._lblCommonLabel_18.Text = "Total";
			this._lblCommonLabel_18.Location = new System.Drawing.Point(259, 135);
			// // this._lblCommonLabel_18.mLabelId = 1926;
			this._lblCommonLabel_18.Name = "_lblCommonLabel_18";
			this._lblCommonLabel_18.Size = new System.Drawing.Size(23, 14);
			this._lblCommonLabel_18.TabIndex = 65;
			// 
			// _txtDisplayLabel_15
			// 
			// this._txtDisplayLabel_15.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
			this._txtDisplayLabel_15.AllowDrop = true;
			this._txtDisplayLabel_15.Location = new System.Drawing.Point(508, 133);
			this._txtDisplayLabel_15.Name = "_txtDisplayLabel_15";
			this._txtDisplayLabel_15.Size = new System.Drawing.Size(89, 19);
			this._txtDisplayLabel_15.TabIndex = 66;
			this._txtDisplayLabel_15.TabStop = false;
			// 
			// _txtDisplayLabel_14
			// 
			// this._txtDisplayLabel_14.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
			this._txtDisplayLabel_14.AllowDrop = true;
			this._txtDisplayLabel_14.Location = new System.Drawing.Point(331, 133);
			this._txtDisplayLabel_14.Name = "_txtDisplayLabel_14";
			this._txtDisplayLabel_14.Size = new System.Drawing.Size(86, 19);
			this._txtDisplayLabel_14.TabIndex = 67;
			this._txtDisplayLabel_14.TabStop = false;
			// 
			// _lblCommonLabel_17
			// 
			this._lblCommonLabel_17.AllowDrop = true;
			this._lblCommonLabel_17.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._lblCommonLabel_17.Text = "==";
			this._lblCommonLabel_17.Location = new System.Drawing.Point(313, 89);
			this._lblCommonLabel_17.Name = "_lblCommonLabel_17";
			this._lblCommonLabel_17.Size = new System.Drawing.Size(12, 14);
			this._lblCommonLabel_17.TabIndex = 68;
			// 
			// _txtCommonNumber_2
			// 
			this._txtCommonNumber_2.AllowDrop = true;
			// this._txtCommonNumber_2.DisplayFormat = "####0.000###;;0.000;0.000";
			// this._txtCommonNumber_2.Format = "###########0.000";
			this._txtCommonNumber_2.Location = new System.Drawing.Point(508, 87);
			// // = 2147483647;
			// // = -2147483648;
			this._txtCommonNumber_2.Name = "_txtCommonNumber_2";
			this._txtCommonNumber_2.Size = new System.Drawing.Size(89, 19);
			this._txtCommonNumber_2.TabIndex = 11;
			this._txtCommonNumber_2.Text = "0.000";
			// this.this._txtCommonNumber_2.Change += new System.Windows.Forms.TextBox.ChangeHandler(this.txtCommonNumber_Change);
			// 
			// _txtDisplayLabel_17
			// 
			// this._txtDisplayLabel_17.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
			this._txtDisplayLabel_17.AllowDrop = true;
			this._txtDisplayLabel_17.Location = new System.Drawing.Point(99, 87);
			this._txtDisplayLabel_17.Name = "_txtDisplayLabel_17";
			this._txtDisplayLabel_17.Size = new System.Drawing.Size(101, 19);
			this._txtDisplayLabel_17.TabIndex = 69;
			this._txtDisplayLabel_17.TabStop = false;
			// 
			// _txtDisplayLabel_13
			// 
			// this._txtDisplayLabel_13.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
			this._txtDisplayLabel_13.AllowDrop = true;
			this._txtDisplayLabel_13.Location = new System.Drawing.Point(331, 87);
			this._txtDisplayLabel_13.Name = "_txtDisplayLabel_13";
			this._txtDisplayLabel_13.Size = new System.Drawing.Size(86, 19);
			this._txtDisplayLabel_13.TabIndex = 70;
			this._txtDisplayLabel_13.TabStop = false;
			// 
			// _lblCommonLabel_20
			// 
			this._lblCommonLabel_20.AllowDrop = true;
			this._lblCommonLabel_20.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._lblCommonLabel_20.Text = "Fixed Salary";
			this._lblCommonLabel_20.Location = new System.Drawing.Point(9, 90);
			// // this._lblCommonLabel_20.mLabelId = 2150;
			this._lblCommonLabel_20.Name = "_lblCommonLabel_20";
			this._lblCommonLabel_20.Size = new System.Drawing.Size(60, 14);
			this._lblCommonLabel_20.TabIndex = 71;
			// 
			// _txtDisplayLabel_16
			// 
			// this._txtDisplayLabel_16.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
			this._txtDisplayLabel_16.AllowDrop = true;
			this._txtDisplayLabel_16.Location = new System.Drawing.Point(202, 87);
			this._txtDisplayLabel_16.Name = "_txtDisplayLabel_16";
			this._txtDisplayLabel_16.Size = new System.Drawing.Size(8, 19);
			this._txtDisplayLabel_16.TabIndex = 75;
			this._txtDisplayLabel_16.TabStop = false;
			this._txtDisplayLabel_16.Visible = false;
			// 
			// _txtDisplayLabel_22
			// 
			// this._txtDisplayLabel_22.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
			this._txtDisplayLabel_22.AllowDrop = true;
			this._txtDisplayLabel_22.Location = new System.Drawing.Point(420, 42);
			this._txtDisplayLabel_22.Name = "_txtDisplayLabel_22";
			this._txtDisplayLabel_22.Size = new System.Drawing.Size(86, 19);
			this._txtDisplayLabel_22.TabIndex = 83;
			this._txtDisplayLabel_22.TabStop = false;
			// 
			// _txtDisplayLabel_23
			// 
			// this._txtDisplayLabel_23.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
			this._txtDisplayLabel_23.AllowDrop = true;
			this._txtDisplayLabel_23.Location = new System.Drawing.Point(420, 63);
			this._txtDisplayLabel_23.Name = "_txtDisplayLabel_23";
			this._txtDisplayLabel_23.Size = new System.Drawing.Size(86, 19);
			this._txtDisplayLabel_23.TabIndex = 84;
			this._txtDisplayLabel_23.TabStop = false;
			// 
			// _txtDisplayLabel_24
			// 
			// this._txtDisplayLabel_24.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
			this._txtDisplayLabel_24.AllowDrop = true;
			this._txtDisplayLabel_24.Location = new System.Drawing.Point(420, 87);
			this._txtDisplayLabel_24.Name = "_txtDisplayLabel_24";
			this._txtDisplayLabel_24.Size = new System.Drawing.Size(86, 19);
			this._txtDisplayLabel_24.TabIndex = 85;
			this._txtDisplayLabel_24.TabStop = false;
			// 
			// _lblCommonLabel_31
			// 
			this._lblCommonLabel_31.AllowDrop = true;
			this._lblCommonLabel_31.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._lblCommonLabel_31.Text = "Actual Due Amt";
			this._lblCommonLabel_31.Location = new System.Drawing.Point(423, 27);
			this._lblCommonLabel_31.Name = "_lblCommonLabel_31";
			this._lblCommonLabel_31.Size = new System.Drawing.Size(75, 14);
			this._lblCommonLabel_31.TabIndex = 86;
			// 
			// _txtDisplayLabel_25
			// 
			// this._txtDisplayLabel_25.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
			this._txtDisplayLabel_25.AllowDrop = true;
			this._txtDisplayLabel_25.Location = new System.Drawing.Point(420, 133);
			this._txtDisplayLabel_25.Name = "_txtDisplayLabel_25";
			this._txtDisplayLabel_25.Size = new System.Drawing.Size(86, 19);
			this._txtDisplayLabel_25.TabIndex = 87;
			this._txtDisplayLabel_25.TabStop = false;
			// 
			// Line1
			// 
			this.Line1.AllowDrop = true;
			this.Line1.BackColor = System.Drawing.SystemColors.WindowText;
			this.Line1.Enabled = false;
			this.Line1.Location = new System.Drawing.Point(315, 125);
			this.Line1.Name = "Line1";
			this.Line1.Size = new System.Drawing.Size(285, 1);
			this.Line1.Visible = true;
			// 
			// Line2
			// 
			this.Line2.AllowDrop = true;
			this.Line2.BackColor = System.Drawing.SystemColors.WindowText;
			this.Line2.Enabled = false;
			this.Line2.Location = new System.Drawing.Point(315, 123);
			this.Line2.Name = "Line2";
			this.Line2.Size = new System.Drawing.Size(285, 1);
			this.Line2.Visible = true;
			// 
			// _lblCommonLabel_0
			// 
			this._lblCommonLabel_0.AllowDrop = true;
			this._lblCommonLabel_0.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_0.Text = "Refrence  No.";
			this._lblCommonLabel_0.Location = new System.Drawing.Point(418, 60);
			// // this._lblCommonLabel_0.mLabelId = 1964;
			this._lblCommonLabel_0.Name = "_lblCommonLabel_0";
			this._lblCommonLabel_0.Size = new System.Drawing.Size(67, 14);
			this._lblCommonLabel_0.TabIndex = 19;
			// 
			// _lblCommonLabel_6
			// 
			this._lblCommonLabel_6.AllowDrop = true;
			this._lblCommonLabel_6.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_6.Text = "Severance Type";
			this._lblCommonLabel_6.Location = new System.Drawing.Point(418, 174);
			// // this._lblCommonLabel_6.mLabelId = 1240;
			this._lblCommonLabel_6.Name = "_lblCommonLabel_6";
			this._lblCommonLabel_6.Size = new System.Drawing.Size(80, 14);
			this._lblCommonLabel_6.TabIndex = 20;
			// 
			// _lblCommonLabel_10
			// 
			this._lblCommonLabel_10.AllowDrop = true;
			this._lblCommonLabel_10.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_10.Text = "Termination  No.";
			this._lblCommonLabel_10.Location = new System.Drawing.Point(8, 59);
			// // this._lblCommonLabel_10.mLabelId = 1234;
			this._lblCommonLabel_10.Name = "_lblCommonLabel_10";
			this._lblCommonLabel_10.Size = new System.Drawing.Size(77, 14);
			this._lblCommonLabel_10.TabIndex = 21;
			// 
			// _lblCommonLabel_12
			// 
			this._lblCommonLabel_12.AllowDrop = true;
			this._lblCommonLabel_12.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_12.Text = "Severance Date";
			this._lblCommonLabel_12.Location = new System.Drawing.Point(418, 148);
			// // this._lblCommonLabel_12.mLabelId = 1235;
			this._lblCommonLabel_12.Name = "_lblCommonLabel_12";
			this._lblCommonLabel_12.Size = new System.Drawing.Size(78, 14);
			this._lblCommonLabel_12.TabIndex = 22;
			// 
			// txtVoucherDate
			// 
			this.txtVoucherDate.AllowDrop = true;
			// this.txtVoucherDate.CheckDateRange = false;
			this.txtVoucherDate.Location = new System.Drawing.Point(509, 146);
			// this.txtVoucherDate.MaxDate = 2958465;
			// this.txtVoucherDate.MinDate = 32874;
			this.txtVoucherDate.Name = "txtVoucherDate";
			this.txtVoucherDate.Size = new System.Drawing.Size(102, 21);
			this.txtVoucherDate.TabIndex = 4;
			// this.txtVoucherDate.Text = "18/07/2001";
			// this.txtVoucherDate.Value = 37090;
			// this.txtVoucherDate.Enter += new System.EventHandler(this.txtVoucherDate_Enter);
			// this.txtVoucherDate.Leave += new System.EventHandler(this.txtVoucherDate_Leave);
			// 
			// _CmbCommon_0
			// 
			this._CmbCommon_0.AllowDrop = true;
			this._CmbCommon_0.Location = new System.Drawing.Point(509, 171);
			this._CmbCommon_0.Name = "_CmbCommon_0";
			this._CmbCommon_0.Size = new System.Drawing.Size(102, 21);
			this._CmbCommon_0.TabIndex = 6;
			// this._CmbCommon_0.Click += new System.Windows.Forms.ComboBox.ClickHandler(this.CmbCommon_Click);
			// this._CmbCommon_0.Leave += new System.EventHandler(this.cmbCommon_Leave);
			// 
			// _txtCommonTextBox_2
			// 
			this._txtCommonTextBox_2.AllowDrop = true;
			this._txtCommonTextBox_2.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_2.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_2.Location = new System.Drawing.Point(509, 57);
			this._txtCommonTextBox_2.MaxLength = 20;
			this._txtCommonTextBox_2.Name = "_txtCommonTextBox_2";
			this._txtCommonTextBox_2.Size = new System.Drawing.Size(102, 19);
			this._txtCommonTextBox_2.TabIndex = 1;
			this._txtCommonTextBox_2.Text = "";
			// this.// = "";
			// this.//this._txtCommonTextBox_2.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(//this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_2.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _txtCommonTextBox_0
			// 
			this._txtCommonTextBox_0.AllowDrop = true;
			this._txtCommonTextBox_0.BackColor = System.Drawing.Color.White;
			// this._txtCommonTextBox_0.bolNumericOnly = true;
			this._txtCommonTextBox_0.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_0.Location = new System.Drawing.Point(109, 57);
			// // = System.Windows.Forms.TextBox.DropDownTypes.ddtNextNumber;
			this._txtCommonTextBox_0.Name = "_txtCommonTextBox_0";
			// this._txtCommonTextBox_0.ShowButton = true;
			this._txtCommonTextBox_0.Size = new System.Drawing.Size(102, 19);
			this._txtCommonTextBox_0.TabIndex = 0;
			this._txtCommonTextBox_0.Text = "";
			// this.// = "";
			// this.//this._txtCommonTextBox_0.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(//this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_0.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _txtCommonTextBox_3
			// 
			this._txtCommonTextBox_3.AllowDrop = true;
			this._txtCommonTextBox_3.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_3.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_3.Location = new System.Drawing.Point(109, 196);
			this._txtCommonTextBox_3.MaxLength = 100;
			this._txtCommonTextBox_3.Name = "_txtCommonTextBox_3";
			this._txtCommonTextBox_3.Size = new System.Drawing.Size(505, 19);
			this._txtCommonTextBox_3.TabIndex = 7;
			this._txtCommonTextBox_3.Text = "";
			// this.// = "";
			// this.//this._txtCommonTextBox_3.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(//this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_3.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _lblCommonLabel_2
			// 
			this._lblCommonLabel_2.AllowDrop = true;
			this._lblCommonLabel_2.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_2.Text = "Employee Code";
			this._lblCommonLabel_2.Location = new System.Drawing.Point(8, 83);
			// // this._lblCommonLabel_2.mLabelId = 236;
			this._lblCommonLabel_2.Name = "_lblCommonLabel_2";
			this._lblCommonLabel_2.Size = new System.Drawing.Size(74, 14);
			this._lblCommonLabel_2.TabIndex = 23;
			// 
			// _lblCommonLabel_1
			// 
			this._lblCommonLabel_1.AllowDrop = true;
			this._lblCommonLabel_1.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_1.Text = "Department Code";
			this._lblCommonLabel_1.Location = new System.Drawing.Point(8, 104);
			// // this._lblCommonLabel_1.mLabelId = 1973;
			this._lblCommonLabel_1.Name = "_lblCommonLabel_1";
			this._lblCommonLabel_1.Size = new System.Drawing.Size(83, 14);
			this._lblCommonLabel_1.TabIndex = 24;
			// 
			// _lblCommonLabel_3
			// 
			this._lblCommonLabel_3.AllowDrop = true;
			this._lblCommonLabel_3.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_3.Text = "Designation Code";
			this._lblCommonLabel_3.Location = new System.Drawing.Point(8, 125);
			// // this._lblCommonLabel_3.mLabelId = 1049;
			this._lblCommonLabel_3.Name = "_lblCommonLabel_3";
			this._lblCommonLabel_3.Size = new System.Drawing.Size(84, 14);
			this._lblCommonLabel_3.TabIndex = 25;
			// 
			// _lblCommonLabel_4
			// 
			this._lblCommonLabel_4.AllowDrop = true;
			this._lblCommonLabel_4.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_4.Text = "Leave Salary";
			this._lblCommonLabel_4.Location = new System.Drawing.Point(418, 104);
			// // this._lblCommonLabel_4.mLabelId = 1135;
			this._lblCommonLabel_4.Name = "_lblCommonLabel_4";
			this._lblCommonLabel_4.Size = new System.Drawing.Size(64, 14);
			this._lblCommonLabel_4.TabIndex = 26;
			// 
			// _txtCommonTextBox_1
			// 
			this._txtCommonTextBox_1.AllowDrop = true;
			this._txtCommonTextBox_1.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_1.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_1.Location = new System.Drawing.Point(109, 81);
			this._txtCommonTextBox_1.MaxLength = 10;
			this._txtCommonTextBox_1.Name = "_txtCommonTextBox_1";
			// this._txtCommonTextBox_1.ShowButton = true;
			this._txtCommonTextBox_1.Size = new System.Drawing.Size(101, 19);
			this._txtCommonTextBox_1.TabIndex = 2;
			this._txtCommonTextBox_1.Text = "";
			// this.// = "";
			// this.//this._txtCommonTextBox_1.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(//this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_1.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _lblCommonLabel_5
			// 
			this._lblCommonLabel_5.AllowDrop = true;
			this._lblCommonLabel_5.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_5.Text = "Indemnity Salary";
			this._lblCommonLabel_5.Location = new System.Drawing.Point(418, 125);
			// // this._lblCommonLabel_5.mLabelId = 1239;
			this._lblCommonLabel_5.Name = "_lblCommonLabel_5";
			this._lblCommonLabel_5.Size = new System.Drawing.Size(79, 14);
			this._lblCommonLabel_5.TabIndex = 27;
			// 
			// _txtDisplayLabel_0
			// 
			this._txtDisplayLabel_0.AllowDrop = true;
			this._txtDisplayLabel_0.Location = new System.Drawing.Point(109, 102);
			this._txtDisplayLabel_0.Name = "_txtDisplayLabel_0";
			this._txtDisplayLabel_0.Size = new System.Drawing.Size(101, 19);
			this._txtDisplayLabel_0.TabIndex = 28;
			this._txtDisplayLabel_0.TabStop = false;
			// 
			// _txtDisplayLabel_1
			// 
			this._txtDisplayLabel_1.AllowDrop = true;
			this._txtDisplayLabel_1.Location = new System.Drawing.Point(213, 102);
			this._txtDisplayLabel_1.Name = "_txtDisplayLabel_1";
			this._txtDisplayLabel_1.Size = new System.Drawing.Size(201, 19);
			this._txtDisplayLabel_1.TabIndex = 29;
			this._txtDisplayLabel_1.TabStop = false;
			// 
			// _txtDisplayLabel_2
			// 
			this._txtDisplayLabel_2.AllowDrop = true;
			this._txtDisplayLabel_2.Location = new System.Drawing.Point(109, 123);
			this._txtDisplayLabel_2.Name = "_txtDisplayLabel_2";
			this._txtDisplayLabel_2.Size = new System.Drawing.Size(101, 19);
			this._txtDisplayLabel_2.TabIndex = 30;
			this._txtDisplayLabel_2.TabStop = false;
			// 
			// _txtDisplayLabel_3
			// 
			this._txtDisplayLabel_3.AllowDrop = true;
			this._txtDisplayLabel_3.Location = new System.Drawing.Point(213, 123);
			this._txtDisplayLabel_3.Name = "_txtDisplayLabel_3";
			this._txtDisplayLabel_3.Size = new System.Drawing.Size(201, 19);
			this._txtDisplayLabel_3.TabIndex = 31;
			this._txtDisplayLabel_3.TabStop = false;
			// 
			// _txtDisplayLabel_4
			// 
			// this._txtDisplayLabel_4.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
			this._txtDisplayLabel_4.AllowDrop = true;
			this._txtDisplayLabel_4.Location = new System.Drawing.Point(509, 102);
			this._txtDisplayLabel_4.Name = "_txtDisplayLabel_4";
			this._txtDisplayLabel_4.Size = new System.Drawing.Size(102, 19);
			this._txtDisplayLabel_4.TabIndex = 32;
			this._txtDisplayLabel_4.TabStop = false;
			// 
			// _txtDisplayLabel_6
			// 
			this._txtDisplayLabel_6.AllowDrop = true;
			this._txtDisplayLabel_6.Location = new System.Drawing.Point(213, 81);
			this._txtDisplayLabel_6.Name = "_txtDisplayLabel_6";
			this._txtDisplayLabel_6.Size = new System.Drawing.Size(201, 19);
			this._txtDisplayLabel_6.TabIndex = 33;
			this._txtDisplayLabel_6.TabStop = false;
			// 
			// _txtDisplayLabel_5
			// 
			// this._txtDisplayLabel_5.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
			this._txtDisplayLabel_5.AllowDrop = true;
			this._txtDisplayLabel_5.Location = new System.Drawing.Point(509, 123);
			this._txtDisplayLabel_5.Name = "_txtDisplayLabel_5";
			this._txtDisplayLabel_5.Size = new System.Drawing.Size(102, 19);
			this._txtDisplayLabel_5.TabIndex = 34;
			this._txtDisplayLabel_5.TabStop = false;
			// 
			// _lblCommonLabel_21
			// 
			this._lblCommonLabel_21.AllowDrop = true;
			this._lblCommonLabel_21.Text = "Other Earnings";
			this._lblCommonLabel_21.Location = new System.Drawing.Point(8, 307);
			// // this._lblCommonLabel_21.mLabelId = 1988;
			this._lblCommonLabel_21.Name = "_lblCommonLabel_21";
			this._lblCommonLabel_21.Size = new System.Drawing.Size(72, 14);
			this._lblCommonLabel_21.TabIndex = 35;
			this._lblCommonLabel_21.Visible = false;
			// 
			// _txtCommonTextBox_4
			// 
			this._txtCommonTextBox_4.AllowDrop = true;
			this._txtCommonTextBox_4.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_4.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_4.Location = new System.Drawing.Point(14, 305);
			this._txtCommonTextBox_4.MaxLength = 100;
			this._txtCommonTextBox_4.Name = "_txtCommonTextBox_4";
			this._txtCommonTextBox_4.Size = new System.Drawing.Size(6, 19);
			this._txtCommonTextBox_4.TabIndex = 15;
			this._txtCommonTextBox_4.Text = "";
			this._txtCommonTextBox_4.Visible = false;
			// this.// = "";
			// this.//this._txtCommonTextBox_4.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(//this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_4.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _txtDisplayLabel_18
			// 
			// this._txtDisplayLabel_18.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
			this._txtDisplayLabel_18.AllowDrop = true;
			this._txtDisplayLabel_18.Location = new System.Drawing.Point(21, 305);
			this._txtDisplayLabel_18.Name = "_txtDisplayLabel_18";
			this._txtDisplayLabel_18.Size = new System.Drawing.Size(5, 19);
			this._txtDisplayLabel_18.TabIndex = 36;
			this._txtDisplayLabel_18.TabStop = false;
			this._txtDisplayLabel_18.Visible = false;
			// 
			// _txtCommonNumber_3
			// 
			this._txtCommonNumber_3.AllowDrop = true;
			// this._txtCommonNumber_3.DisplayFormat = "####0.000###;;0.000;0.000";
			// this._txtCommonNumber_3.Format = "###########0.000";
			this._txtCommonNumber_3.Location = new System.Drawing.Point(26, 305);
			// // = 2147483647;
			// // = 0;
			this._txtCommonNumber_3.Name = "_txtCommonNumber_3";
			this._txtCommonNumber_3.Size = new System.Drawing.Size(5, 19);
			this._txtCommonNumber_3.TabIndex = 16;
			this._txtCommonNumber_3.Text = "0.000";
			this._txtCommonNumber_3.Visible = false;
			// this.this._txtCommonNumber_3.Change += new System.Windows.Forms.TextBox.ChangeHandler(this.txtCommonNumber_Change);
			// 
			// _lblCommonLabel_24
			// 
			this._lblCommonLabel_24.AllowDrop = true;
			this._lblCommonLabel_24.Text = "Remarks";
			this._lblCommonLabel_24.Location = new System.Drawing.Point(42, 321);
			// // this._lblCommonLabel_24.mLabelId = 1990;
			this._lblCommonLabel_24.Name = "_lblCommonLabel_24";
			this._lblCommonLabel_24.Size = new System.Drawing.Size(42, 14);
			this._lblCommonLabel_24.TabIndex = 37;
			this._lblCommonLabel_24.Visible = false;
			// 
			// _lblCommonLabel_22
			// 
			this._lblCommonLabel_22.AllowDrop = true;
			this._lblCommonLabel_22.Text = "==";
			this._lblCommonLabel_22.Location = new System.Drawing.Point(30, 304);
			this._lblCommonLabel_22.Name = "_lblCommonLabel_22";
			this._lblCommonLabel_22.Size = new System.Drawing.Size(12, 14);
			this._lblCommonLabel_22.TabIndex = 38;
			this._lblCommonLabel_22.Visible = false;
			// 
			// _lblCommonLabel_23
			// 
			this._lblCommonLabel_23.AllowDrop = true;
			this._lblCommonLabel_23.Text = "Other Deductions";
			this._lblCommonLabel_23.Location = new System.Drawing.Point(8, 328);
			// // this._lblCommonLabel_23.mLabelId = 1991;
			this._lblCommonLabel_23.Name = "_lblCommonLabel_23";
			this._lblCommonLabel_23.Size = new System.Drawing.Size(84, 14);
			this._lblCommonLabel_23.TabIndex = 39;
			this._lblCommonLabel_23.Visible = false;
			// 
			// _txtDisplayLabel_19
			// 
			// this._txtDisplayLabel_19.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
			this._txtDisplayLabel_19.AllowDrop = true;
			this._txtDisplayLabel_19.Location = new System.Drawing.Point(21, 326);
			this._txtDisplayLabel_19.Name = "_txtDisplayLabel_19";
			this._txtDisplayLabel_19.Size = new System.Drawing.Size(5, 19);
			this._txtDisplayLabel_19.TabIndex = 40;
			this._txtDisplayLabel_19.TabStop = false;
			this._txtDisplayLabel_19.Visible = false;
			// 
			// _txtCommonNumber_4
			// 
			this._txtCommonNumber_4.AllowDrop = true;
			// this._txtCommonNumber_4.DisplayFormat = "####0.000###;;0.000;0.000";
			// this._txtCommonNumber_4.Format = "###########0.000";
			this._txtCommonNumber_4.Location = new System.Drawing.Point(26, 326);
			// // = 2147483647;
			// // = 0;
			this._txtCommonNumber_4.Name = "_txtCommonNumber_4";
			this._txtCommonNumber_4.Size = new System.Drawing.Size(5, 19);
			this._txtCommonNumber_4.TabIndex = 18;
			this._txtCommonNumber_4.Text = "0.000";
			this._txtCommonNumber_4.Visible = false;
			// this.this._txtCommonNumber_4.Change += new System.Windows.Forms.TextBox.ChangeHandler(this.txtCommonNumber_Change);
			// 
			// _txtCommonTextBox_5
			// 
			this._txtCommonTextBox_5.AllowDrop = true;
			this._txtCommonTextBox_5.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_5.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_5.Location = new System.Drawing.Point(14, 326);
			this._txtCommonTextBox_5.MaxLength = 100;
			this._txtCommonTextBox_5.Name = "_txtCommonTextBox_5";
			this._txtCommonTextBox_5.Size = new System.Drawing.Size(6, 19);
			this._txtCommonTextBox_5.TabIndex = 17;
			this._txtCommonTextBox_5.Text = "";
			this._txtCommonTextBox_5.Visible = false;
			// this.// = "";
			// this.//this._txtCommonTextBox_5.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(//this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_5.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _lblCommonLabel_25
			// 
			this._lblCommonLabel_25.AllowDrop = true;
			this._lblCommonLabel_25.Text = "==";
			this._lblCommonLabel_25.Location = new System.Drawing.Point(30, 325);
			this._lblCommonLabel_25.Name = "_lblCommonLabel_25";
			this._lblCommonLabel_25.Size = new System.Drawing.Size(12, 14);
			this._lblCommonLabel_25.TabIndex = 41;
			this._lblCommonLabel_25.Visible = false;
			// 
			// _lblCommonLabel_26
			// 
			this._lblCommonLabel_26.AllowDrop = true;
			this._lblCommonLabel_26.Text = "Loan Amount";
			this._lblCommonLabel_26.Location = new System.Drawing.Point(8, 349);
			// // this._lblCommonLabel_26.mLabelId = 404;
			this._lblCommonLabel_26.Name = "_lblCommonLabel_26";
			this._lblCommonLabel_26.Size = new System.Drawing.Size(64, 14);
			this._lblCommonLabel_26.TabIndex = 42;
			this._lblCommonLabel_26.Visible = false;
			// 
			// _lblCommonLabel_27
			// 
			this._lblCommonLabel_27.AllowDrop = true;
			this._lblCommonLabel_27.Text = "==";
			this._lblCommonLabel_27.Location = new System.Drawing.Point(30, 346);
			this._lblCommonLabel_27.Name = "_lblCommonLabel_27";
			this._lblCommonLabel_27.Size = new System.Drawing.Size(12, 14);
			this._lblCommonLabel_27.TabIndex = 43;
			this._lblCommonLabel_27.Visible = false;
			// 
			// _txtCommonNumber_5
			// 
			this._txtCommonNumber_5.AllowDrop = true;
			// this._txtCommonNumber_5.DisplayFormat = "####0.000###;;0.000;0.000";
			// this._txtCommonNumber_5.Format = "###########0.000";
			this._txtCommonNumber_5.Location = new System.Drawing.Point(26, 347);
			// // = 2147483647;
			// // = 0;
			this._txtCommonNumber_5.Name = "_txtCommonNumber_5";
			this._txtCommonNumber_5.Size = new System.Drawing.Size(5, 19);
			this._txtCommonNumber_5.TabIndex = 44;
			this._txtCommonNumber_5.Text = "0.000";
			this._txtCommonNumber_5.Visible = false;
			// this.this._txtCommonNumber_5.Change += new System.Windows.Forms.TextBox.ChangeHandler(this.txtCommonNumber_Change);
			// 
			// _txtDisplayLabel_20
			// 
			// this._txtDisplayLabel_20.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
			this._txtDisplayLabel_20.AllowDrop = true;
			this._txtDisplayLabel_20.Location = new System.Drawing.Point(21, 347);
			this._txtDisplayLabel_20.Name = "_txtDisplayLabel_20";
			this._txtDisplayLabel_20.Size = new System.Drawing.Size(5, 19);
			this._txtDisplayLabel_20.TabIndex = 45;
			this._txtDisplayLabel_20.TabStop = false;
			this._txtDisplayLabel_20.Visible = false;
			// 
			// _lblCommon_102
			// 
			this._lblCommon_102.AllowDrop = true;
			this._lblCommon_102.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_102.Text = "Status";
			this._lblCommon_102.Location = new System.Drawing.Point(418, 83);
			// // this._lblCommon_102.mLabelId = 1834;
			this._lblCommon_102.Name = "_lblCommon_102";
			this._lblCommon_102.Size = new System.Drawing.Size(31, 14);
			this._lblCommon_102.TabIndex = 46;
			// 
			// _txtDisplayLabel_21
			// 
			this._txtDisplayLabel_21.AllowDrop = true;
			this._txtDisplayLabel_21.Location = new System.Drawing.Point(509, 81);
			this._txtDisplayLabel_21.Name = "_txtDisplayLabel_21";
			this._txtDisplayLabel_21.Size = new System.Drawing.Size(102, 19);
			this._txtDisplayLabel_21.TabIndex = 47;
			this._txtDisplayLabel_21.TabStop = false;
			// 
			// txtNoticePeriod
			// 
			this.txtNoticePeriod.AllowDrop = true;
			this.txtNoticePeriod.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			// this.txtNoticePeriod.DisplayFormat = "####0.000###;;0.000;0.000";
			this.txtNoticePeriod.Enabled = false;
			this.txtNoticePeriod.ForeColor = System.Drawing.Color.Black;
			// this.txtNoticePeriod.Format = "###########0.000";
			this.txtNoticePeriod.Location = new System.Drawing.Point(312, 147);
			this.txtNoticePeriod.Name = "txtNoticePeriod";
			this.txtNoticePeriod.Size = new System.Drawing.Size(102, 19);
			this.txtNoticePeriod.TabIndex = 76;
			this.txtNoticePeriod.Text = "0.000";
			// 
			// lblNoticePeriod
			// 
			this.lblNoticePeriod.AllowDrop = true;
			this.lblNoticePeriod.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblNoticePeriod.Text = "Notice Period";
			this.lblNoticePeriod.Location = new System.Drawing.Point(225, 150);
			// // this.lblNoticePeriod.mLabelId = 2175;
			this.lblNoticePeriod.Name = "lblNoticePeriod";
			this.lblNoticePeriod.Size = new System.Drawing.Size(63, 14);
			this.lblNoticePeriod.TabIndex = 77;
			// 
			// _lblCommonLabel_29
			// 
			this._lblCommonLabel_29.AllowDrop = true;
			this._lblCommonLabel_29.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_29.Text = "Submitted Date";
			this._lblCommonLabel_29.Location = new System.Drawing.Point(8, 151);
			this._lblCommonLabel_29.Name = "_lblCommonLabel_29";
			this._lblCommonLabel_29.Size = new System.Drawing.Size(72, 14);
			this._lblCommonLabel_29.TabIndex = 78;
			// 
			// txtDSubmittedDate
			// 
			this.txtDSubmittedDate.AllowDrop = true;
			// this.txtDSubmittedDate.CheckDateRange = false;
			this.txtDSubmittedDate.Location = new System.Drawing.Point(109, 147);
			// this.txtDSubmittedDate.MaxDate = 2958465;
			// this.txtDSubmittedDate.MinDate = 32874;
			this.txtDSubmittedDate.Name = "txtDSubmittedDate";
			this.txtDSubmittedDate.Size = new System.Drawing.Size(102, 21);
			this.txtDSubmittedDate.TabIndex = 3;
			// this.txtDSubmittedDate.Text = "18/07/2001";
			// this.txtDSubmittedDate.Value = 37090;
			// this.txtDSubmittedDate.Enter += new System.EventHandler(this.txtDSubmittedDate_Enter);
			// this.txtDSubmittedDate.Leave += new System.EventHandler(this.txtDSubmittedDate_Leave);
			// 
			// _lblCommonLabel_8
			// 
			this._lblCommonLabel_8.AllowDrop = true;
			this._lblCommonLabel_8.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_8.Text = "Reason";
			this._lblCommonLabel_8.Location = new System.Drawing.Point(8, 199);
			// // this._lblCommonLabel_8.mLabelId = 1236;
			this._lblCommonLabel_8.Name = "_lblCommonLabel_8";
			this._lblCommonLabel_8.Size = new System.Drawing.Size(37, 14);
			this._lblCommonLabel_8.TabIndex = 79;
			// 
			// _lblCommonLabel_30
			// 
			this._lblCommonLabel_30.AllowDrop = true;
			this._lblCommonLabel_30.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_30.Text = "Severance Status";
			this._lblCommonLabel_30.Location = new System.Drawing.Point(8, 175);
			this._lblCommonLabel_30.Name = "_lblCommonLabel_30";
			this._lblCommonLabel_30.Size = new System.Drawing.Size(87, 14);
			this._lblCommonLabel_30.TabIndex = 80;
			// 
			// _cmbSeveranceStatus_0
			// 
			this._cmbSeveranceStatus_0.AllowDrop = true;
			this._cmbSeveranceStatus_0.Location = new System.Drawing.Point(109, 171);
			this._cmbSeveranceStatus_0.Name = "_cmbSeveranceStatus_0";
			this._cmbSeveranceStatus_0.Size = new System.Drawing.Size(107, 21);
			this._cmbSeveranceStatus_0.TabIndex = 5;
			// this._cmbSeveranceStatus_0.Leave += new System.EventHandler(this.cmbSeveranceStatus_Leave);
			// 
			// _lblCommon_109
			// 
			this._lblCommon_109.AllowDrop = true;
			this._lblCommon_109.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_109.Text = "Joining Date";
			this._lblCommon_109.Location = new System.Drawing.Point(225, 173);
			// // this._lblCommon_109.mLabelId = 1057;
			this._lblCommon_109.Name = "_lblCommon_109";
			this._lblCommon_109.Size = new System.Drawing.Size(58, 14);
			this._lblCommon_109.TabIndex = 81;
			// 
			// txtJoiningDate
			// 
			this.txtJoiningDate.AllowDrop = true;
			this.txtJoiningDate.BackColor = System.Drawing.Color.FromArgb(239, 239, 239);
			// this.txtJoiningDate.CheckDateRange = false;
			this.txtJoiningDate.Enabled = false;
			this.txtJoiningDate.Location = new System.Drawing.Point(313, 171);
			// this.txtJoiningDate.MaxDate = 2958465;
			// this.txtJoiningDate.MinDate = 2;
			this.txtJoiningDate.Name = "txtJoiningDate";
			this.txtJoiningDate.Size = new System.Drawing.Size(102, 19);
			this.txtJoiningDate.TabIndex = 82;
			// this.txtJoiningDate.Text = "18/07/2001";
			// this.txtJoiningDate.Value = 37090;
			// 
			// frmPayTermination
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.ClientSize = new System.Drawing.Size(620, 506);
			this.Controls.Add(this.tabTermination);
			this.Controls.Add(this._lblCommonLabel_0);
			this.Controls.Add(this._lblCommonLabel_6);
			this.Controls.Add(this._lblCommonLabel_10);
			this.Controls.Add(this._lblCommonLabel_12);
			this.Controls.Add(this.txtVoucherDate);
			this.Controls.Add(this._CmbCommon_0);
			this.Controls.Add(this._txtCommonTextBox_2);
			this.Controls.Add(this._txtCommonTextBox_0);
			this.Controls.Add(this._txtCommonTextBox_3);
			this.Controls.Add(this._lblCommonLabel_2);
			this.Controls.Add(this._lblCommonLabel_1);
			this.Controls.Add(this._lblCommonLabel_3);
			this.Controls.Add(this._lblCommonLabel_4);
			this.Controls.Add(this._txtCommonTextBox_1);
			this.Controls.Add(this._lblCommonLabel_5);
			this.Controls.Add(this._txtDisplayLabel_0);
			this.Controls.Add(this._txtDisplayLabel_1);
			this.Controls.Add(this._txtDisplayLabel_2);
			this.Controls.Add(this._txtDisplayLabel_3);
			this.Controls.Add(this._txtDisplayLabel_4);
			this.Controls.Add(this._txtDisplayLabel_6);
			this.Controls.Add(this._txtDisplayLabel_5);
			this.Controls.Add(this._lblCommonLabel_21);
			this.Controls.Add(this._txtCommonTextBox_4);
			this.Controls.Add(this._txtDisplayLabel_18);
			this.Controls.Add(this._txtCommonNumber_3);
			this.Controls.Add(this._lblCommonLabel_24);
			this.Controls.Add(this._lblCommonLabel_22);
			this.Controls.Add(this._lblCommonLabel_23);
			this.Controls.Add(this._txtDisplayLabel_19);
			this.Controls.Add(this._txtCommonNumber_4);
			this.Controls.Add(this._txtCommonTextBox_5);
			this.Controls.Add(this._lblCommonLabel_25);
			this.Controls.Add(this._lblCommonLabel_26);
			this.Controls.Add(this._lblCommonLabel_27);
			this.Controls.Add(this._txtCommonNumber_5);
			this.Controls.Add(this._txtDisplayLabel_20);
			this.Controls.Add(this._lblCommon_102);
			this.Controls.Add(this._txtDisplayLabel_21);
			this.Controls.Add(this.txtNoticePeriod);
			this.Controls.Add(this.lblNoticePeriod);
			this.Controls.Add(this._lblCommonLabel_29);
			this.Controls.Add(this.txtDSubmittedDate);
			this.Controls.Add(this._lblCommonLabel_8);
			this.Controls.Add(this._lblCommonLabel_30);
			this.Controls.Add(this._cmbSeveranceStatus_0);
			this.Controls.Add(this._lblCommon_109);
			this.Controls.Add(this.txtJoiningDate);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			//this.Icon = (System.Drawing.Icon) resources.GetObject("frmPayTermination.Icon");
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(222, 160);
			this.MaximizeBox = true;
			this.MinimizeBox = true;
			this.Name = "frmPayTermination";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Employee Termination";
			// this.Activated += new System.EventHandler(this.frmPayTermination_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
			// this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
			//((System.ComponentModel.ISupportInitialize) this.tabTermination).EndInit();
			this.tabTermination.ResumeLayout(false);
			this._fraEmployeeInformation_3.ResumeLayout(false);
			this.frmTerminationDetails.ResumeLayout(false);
			this.cmbMastersList.ResumeLayout(false);
			this.grdVoucherDetails.ResumeLayout(false);
			this.frmTermination.ResumeLayout(false);
			this.frmApproval.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		// 
		void InitializetxtDisplayLabel()
		{
			this.txtDisplayLabel = new System.Windows.Forms.Label[27];
			this.txtDisplayLabel[26] = _txtDisplayLabel_26;
			this.txtDisplayLabel[11] = _txtDisplayLabel_11;
			this.txtDisplayLabel[10] = _txtDisplayLabel_10;
			this.txtDisplayLabel[9] = _txtDisplayLabel_9;
			this.txtDisplayLabel[7] = _txtDisplayLabel_7;
			this.txtDisplayLabel[8] = _txtDisplayLabel_8;
			this.txtDisplayLabel[12] = _txtDisplayLabel_12;
			this.txtDisplayLabel[15] = _txtDisplayLabel_15;
			this.txtDisplayLabel[14] = _txtDisplayLabel_14;
			this.txtDisplayLabel[17] = _txtDisplayLabel_17;
			this.txtDisplayLabel[13] = _txtDisplayLabel_13;
			this.txtDisplayLabel[16] = _txtDisplayLabel_16;
			this.txtDisplayLabel[22] = _txtDisplayLabel_22;
			this.txtDisplayLabel[23] = _txtDisplayLabel_23;
			this.txtDisplayLabel[24] = _txtDisplayLabel_24;
			this.txtDisplayLabel[25] = _txtDisplayLabel_25;
			this.txtDisplayLabel[0] = _txtDisplayLabel_0;
			this.txtDisplayLabel[1] = _txtDisplayLabel_1;
			this.txtDisplayLabel[2] = _txtDisplayLabel_2;
			this.txtDisplayLabel[3] = _txtDisplayLabel_3;
			this.txtDisplayLabel[4] = _txtDisplayLabel_4;
			this.txtDisplayLabel[6] = _txtDisplayLabel_6;
			this.txtDisplayLabel[5] = _txtDisplayLabel_5;
			this.txtDisplayLabel[18] = _txtDisplayLabel_18;
			this.txtDisplayLabel[19] = _txtDisplayLabel_19;
			this.txtDisplayLabel[20] = _txtDisplayLabel_20;
			this.txtDisplayLabel[21] = _txtDisplayLabel_21;
		}
		void InitializetxtCommonTextBox()
		{
			this.txtCommonTextBox = new System.Windows.Forms.TextBox[73];
			this.txtCommonTextBox[72] = _txtCommonTextBox_72;
			this.txtCommonTextBox[2] = _txtCommonTextBox_2;
			this.txtCommonTextBox[0] = _txtCommonTextBox_0;
			this.txtCommonTextBox[3] = _txtCommonTextBox_3;
			this.txtCommonTextBox[1] = _txtCommonTextBox_1;
			this.txtCommonTextBox[4] = _txtCommonTextBox_4;
			this.txtCommonTextBox[5] = _txtCommonTextBox_5;
		}
		void InitializetxtCommonNumber()
		{
			this.txtCommonNumber = new System.Windows.Forms.TextBox[6];
			this.txtCommonNumber[1] = _txtCommonNumber_1;
			this.txtCommonNumber[0] = _txtCommonNumber_0;
			this.txtCommonNumber[2] = _txtCommonNumber_2;
			this.txtCommonNumber[3] = _txtCommonNumber_3;
			this.txtCommonNumber[4] = _txtCommonNumber_4;
			this.txtCommonNumber[5] = _txtCommonNumber_5;
		}
		void InitializelblCommonLabel()
		{
			this.lblCommonLabel = new System.Windows.Forms.Label[32];
			this.lblCommonLabel[28] = _lblCommonLabel_28;
			this.lblCommonLabel[7] = _lblCommonLabel_7;
			this.lblCommonLabel[9] = _lblCommonLabel_9;
			this.lblCommonLabel[15] = _lblCommonLabel_15;
			this.lblCommonLabel[16] = _lblCommonLabel_16;
			this.lblCommonLabel[14] = _lblCommonLabel_14;
			this.lblCommonLabel[13] = _lblCommonLabel_13;
			this.lblCommonLabel[11] = _lblCommonLabel_11;
			this.lblCommonLabel[19] = _lblCommonLabel_19;
			this.lblCommonLabel[18] = _lblCommonLabel_18;
			this.lblCommonLabel[17] = _lblCommonLabel_17;
			this.lblCommonLabel[20] = _lblCommonLabel_20;
			this.lblCommonLabel[31] = _lblCommonLabel_31;
			this.lblCommonLabel[0] = _lblCommonLabel_0;
			this.lblCommonLabel[6] = _lblCommonLabel_6;
			this.lblCommonLabel[10] = _lblCommonLabel_10;
			this.lblCommonLabel[12] = _lblCommonLabel_12;
			this.lblCommonLabel[2] = _lblCommonLabel_2;
			this.lblCommonLabel[1] = _lblCommonLabel_1;
			this.lblCommonLabel[3] = _lblCommonLabel_3;
			this.lblCommonLabel[4] = _lblCommonLabel_4;
			this.lblCommonLabel[5] = _lblCommonLabel_5;
			this.lblCommonLabel[21] = _lblCommonLabel_21;
			this.lblCommonLabel[24] = _lblCommonLabel_24;
			this.lblCommonLabel[22] = _lblCommonLabel_22;
			this.lblCommonLabel[23] = _lblCommonLabel_23;
			this.lblCommonLabel[25] = _lblCommonLabel_25;
			this.lblCommonLabel[26] = _lblCommonLabel_26;
			this.lblCommonLabel[27] = _lblCommonLabel_27;
			this.lblCommonLabel[29] = _lblCommonLabel_29;
			this.lblCommonLabel[8] = _lblCommonLabel_8;
			this.lblCommonLabel[30] = _lblCommonLabel_30;
		}
		void InitializelblCommon()
		{
			this.lblCommon = new System.Windows.Forms.Label[110];
			this.lblCommon[74] = _lblCommon_74;
			this.lblCommon[102] = _lblCommon_102;
			this.lblCommon[109] = _lblCommon_109;
		}
		void InitializefraEmployeeInformation()
		{
			this.fraEmployeeInformation = new System.Windows.Forms.Panel[4];
			this.fraEmployeeInformation[3] = _fraEmployeeInformation_3;
		}
		void InitializecmbSeveranceStatus()
		{
			this.cmbSeveranceStatus = new System.Windows.Forms.ComboBox[1];
			this.cmbSeveranceStatus[0] = _cmbSeveranceStatus_0;
		}
		void InitializeCmbCommon()
		{
			this.CmbCommon = new System.Windows.Forms.ComboBox[1];
			this.CmbCommon[0] = _CmbCommon_0;
		}
		#endregion
	}
}//ENDSHERE
