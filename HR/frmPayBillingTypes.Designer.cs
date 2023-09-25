
namespace Xtreme
{
	partial class frmPayBillingTypes
	{

		#region "Upgrade Support "
		private static frmPayBillingTypes m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmPayBillingTypes DefInstance
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
		public static frmPayBillingTypes CreateInstance()
		{
			frmPayBillingTypes theInstance = new frmPayBillingTypes();
			
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
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "txtNoOfMonths", "System.Windows.Forms.Label2", "OptNone", "OptPriodWise", "OptChkCalculate", "Frame1", "Column_0_cmbMastersList", "Column_1_cmbMastersList", "cmbMastersList", "Column_0_grdLeaveEarningDetails", "Column_1_grdLeaveEarningDetails", "grdLeaveEarningDetails", "_fraEmployeeInformation_1", "chkIncludeInBudget", "CHKIncludeInBankTransfer", "txtRoundDigit", "txtComment", "chkIncludeInDefaultBillingTypes", "_cmbCommon_0", "lblLNatName", "txtLBillName", "lblANatName", "txtABillName", "lblComments", "lblNatNo", "_System.Windows.Forms.Label1_0", "txtBillNo", "_cmbCommon_1", "_System.Windows.Forms.Label1_1", "_System.Windows.Forms.Label1_2", "_fraEmployeeInformation_0", "_lblCommon_27", "_txtCommonTextBox_40", "_lblCommon_28", "_txtCommonTextBox_41", "_lblCommon_29", "_txtCommonTextBox_42", "_lblCommon_31", "_txtCommonTextBox_43", "_lblCommon_32", "_lblCommon_115", "_lblCommon_33", "_txtCommonTextBox_46", "_lblCommon_34", "_txtCommonTextBox_47", "_lblCommon_35", "_txtCommonTextBox_48", "_txtCommonTextBox_44", "_txtCommonTextBox_45", "_txtDisplayLabel_15", "_lblCommon_0", "_txtCommonTextBox_14", "_lblCommon_30", "_txtCommonTextBox_38", "_lblCommon_38", "_txtCommonTextBox_49", "_lblCommon_39", "_txtCommonTextBox_50", "_lblCommon_40", "_txtCommonTextBox_51", "_txtDisplayLabel_9", "_txtCommonTextBox_54", "_txtCommonTextBox_55", "_lblCommon_44", "_lblCommon_45", "_txtCommonTextBox_53", "_lblCommon_43", "_fraEmployeeInformation_4", "chkAllowTicket", "txtTicketAccrualStartDate", "_lblCommon_23", "_lblCommon_54", "_txtCommonTextBox_71", "_lblCommon_68", "_txtCommonTextBox_73", "_lblCommon_70", "_txtDisplayLabel_11", "_txtDisplayLabel_12", "_fraEmployeeInformation_2", "tabBillingType", "System.Windows.Forms.Label1", "cmbCommon", "fraEmployeeInformation", "lblCommon", "txtCommonTextBox", "txtDisplayLabel"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public System.Windows.Forms.TextBox txtNoOfMonths;
		public System.Windows.Forms.Label System.Windows.Forms.Label2;
		public System.Windows.Forms.RadioButton OptNone;
		public System.Windows.Forms.RadioButton OptPriodWise;
		public System.Windows.Forms.RadioButton OptChkCalculate;
		public System.Windows.Forms.GroupBox Frame1;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_0_cmbMastersList;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_1_cmbMastersList;
		public C1.Win.C1TrueDBGrid.C1TrueDBDropdown cmbMastersList;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_0_grdLeaveEarningDetails;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_1_grdLeaveEarningDetails;
		public C1.Win.C1TrueDBGrid.C1TrueDBGrid grdLeaveEarningDetails;
		private System.Windows.Forms.Panel _fraEmployeeInformation_1;
		public System.Windows.Forms.CheckBox chkIncludeInBudget;
		public System.Windows.Forms.CheckBox CHKIncludeInBankTransfer;
		public System.Windows.Forms.TextBox txtRoundDigit;
		public System.Windows.Forms.TextBox txtComment;
		public System.Windows.Forms.CheckBox chkIncludeInDefaultBillingTypes;
		private System.Windows.Forms.ComboBox _cmbCommon_0;
		public System.Windows.Forms.Label lblLNatName;
		public System.Windows.Forms.TextBox txtLBillName;
		public System.Windows.Forms.Label lblANatName;
		public System.Windows.Forms.TextBox txtABillName;
		public System.Windows.Forms.Label lblComments;
		public System.Windows.Forms.Label lblNatNo;
		private System.Windows.Forms.Label _System.Windows.Forms.Label1_0;
		public System.Windows.Forms.TextBox txtBillNo;
		private System.Windows.Forms.ComboBox _cmbCommon_1;
		private System.Windows.Forms.Label _System.Windows.Forms.Label1_1;
		private System.Windows.Forms.Label _System.Windows.Forms.Label1_2;
		private System.Windows.Forms.Panel _fraEmployeeInformation_0;
		private System.Windows.Forms.Label _lblCommon_27;
		private System.Windows.Forms.TextBox _txtCommonTextBox_40;
		private System.Windows.Forms.Label _lblCommon_28;
		private System.Windows.Forms.TextBox _txtCommonTextBox_41;
		private System.Windows.Forms.Label _lblCommon_29;
		private System.Windows.Forms.TextBox _txtCommonTextBox_42;
		private System.Windows.Forms.Label _lblCommon_31;
		private System.Windows.Forms.TextBox _txtCommonTextBox_43;
		private System.Windows.Forms.Label _lblCommon_32;
		private System.Windows.Forms.Label _lblCommon_115;
		private System.Windows.Forms.Label _lblCommon_33;
		private System.Windows.Forms.TextBox _txtCommonTextBox_46;
		private System.Windows.Forms.Label _lblCommon_34;
		private System.Windows.Forms.TextBox _txtCommonTextBox_47;
		private System.Windows.Forms.Label _lblCommon_35;
		private System.Windows.Forms.TextBox _txtCommonTextBox_48;
		private System.Windows.Forms.TextBox _txtCommonTextBox_44;
		private System.Windows.Forms.TextBox _txtCommonTextBox_45;
		private System.Windows.Forms.Label _txtDisplayLabel_15;
		private System.Windows.Forms.Label _lblCommon_0;
		private System.Windows.Forms.TextBox _txtCommonTextBox_14;
		private System.Windows.Forms.Label _lblCommon_30;
		private System.Windows.Forms.TextBox _txtCommonTextBox_38;
		private System.Windows.Forms.Label _lblCommon_38;
		private System.Windows.Forms.TextBox _txtCommonTextBox_49;
		private System.Windows.Forms.Label _lblCommon_39;
		private System.Windows.Forms.TextBox _txtCommonTextBox_50;
		private System.Windows.Forms.Label _lblCommon_40;
		private System.Windows.Forms.TextBox _txtCommonTextBox_51;
		private System.Windows.Forms.Label _txtDisplayLabel_9;
		private System.Windows.Forms.TextBox _txtCommonTextBox_54;
		private System.Windows.Forms.TextBox _txtCommonTextBox_55;
		private System.Windows.Forms.Label _lblCommon_44;
		private System.Windows.Forms.Label _lblCommon_45;
		private System.Windows.Forms.TextBox _txtCommonTextBox_53;
		private System.Windows.Forms.Label _lblCommon_43;
		private System.Windows.Forms.Panel _fraEmployeeInformation_4;
		public System.Windows.Forms.CheckBox chkAllowTicket;
		public Syncfusion.WinForms.Input.SfDateTimeEdit txtTicketAccrualStartDate;
		private System.Windows.Forms.Label _lblCommon_23;
		private System.Windows.Forms.Label _lblCommon_54;
		private System.Windows.Forms.TextBox _txtCommonTextBox_71;
		private System.Windows.Forms.Label _lblCommon_68;
		private System.Windows.Forms.TextBox _txtCommonTextBox_73;
		private System.Windows.Forms.Label _lblCommon_70;
		private System.Windows.Forms.Label _txtDisplayLabel_11;
		private System.Windows.Forms.Label _txtDisplayLabel_12;
		private System.Windows.Forms.Panel _fraEmployeeInformation_2;
		public AxC1SizerLib.AxC1Tab tabBillingType;
		public System.Windows.Forms.Label[] System.Windows.Forms.Label1 = new System.Windows.Forms.Label[3];
		public System.Windows.Forms.ComboBox[] cmbCommon = new System.Windows.Forms.ComboBox[2];
		public System.Windows.Forms.Panel[] fraEmployeeInformation = new System.Windows.Forms.Panel[5];
		public System.Windows.Forms.Label[] lblCommon = new System.Windows.Forms.Label[116];
		public System.Windows.Forms.TextBox[] txtCommonTextBox = new System.Windows.Forms.TextBox[74];
		public System.Windows.Forms.Label[] txtDisplayLabel = new System.Windows.Forms.Label[16];
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPayBillingTypes));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this.tabBillingType = new AxC1SizerLib.AxC1Tab();
			this._fraEmployeeInformation_1 = new System.Windows.Forms.Panel();
			this.txtNoOfMonths = new System.Windows.Forms.TextBox();
			this.System.Windows.Forms.Label2 = new System.Windows.Forms.Label();
			this.Frame1 = new System.Windows.Forms.GroupBox();
			this.OptNone = new System.Windows.Forms.RadioButton();
			this.OptPriodWise = new System.Windows.Forms.RadioButton();
			this.OptChkCalculate = new System.Windows.Forms.RadioButton();
			this.cmbMastersList = new C1.Win.C1TrueDBGrid.C1TrueDBDropdown();
			this.Column_0_cmbMastersList = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.Column_1_cmbMastersList = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.grdLeaveEarningDetails = new C1.Win.C1TrueDBGrid.C1TrueDBGrid();
			this.Column_0_grdLeaveEarningDetails = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.Column_1_grdLeaveEarningDetails = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this._fraEmployeeInformation_0 = new System.Windows.Forms.Panel();
			this.chkIncludeInBudget = new System.Windows.Forms.CheckBox();
			this.CHKIncludeInBankTransfer = new System.Windows.Forms.CheckBox();
			this.txtRoundDigit = new System.Windows.Forms.TextBox();
			this.txtComment = new System.Windows.Forms.TextBox();
			this.chkIncludeInDefaultBillingTypes = new System.Windows.Forms.CheckBox();
			this._cmbCommon_0 = new System.Windows.Forms.ComboBox();
			this.lblLNatName = new System.Windows.Forms.Label();
			this.txtLBillName = new System.Windows.Forms.TextBox();
			this.lblANatName = new System.Windows.Forms.Label();
			this.txtABillName = new System.Windows.Forms.TextBox();
			this.lblComments = new System.Windows.Forms.Label();
			this.lblNatNo = new System.Windows.Forms.Label();
			this._System.Windows.Forms.Label1_0 = new System.Windows.Forms.Label();
			this.txtBillNo = new System.Windows.Forms.TextBox();
			this._cmbCommon_1 = new System.Windows.Forms.ComboBox();
			this._System.Windows.Forms.Label1_1 = new System.Windows.Forms.Label();
			this._System.Windows.Forms.Label1_2 = new System.Windows.Forms.Label();
			this._fraEmployeeInformation_4 = new System.Windows.Forms.Panel();
			this._lblCommon_27 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_40 = new System.Windows.Forms.TextBox();
			this._lblCommon_28 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_41 = new System.Windows.Forms.TextBox();
			this._lblCommon_29 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_42 = new System.Windows.Forms.TextBox();
			this._lblCommon_31 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_43 = new System.Windows.Forms.TextBox();
			this._lblCommon_32 = new System.Windows.Forms.Label();
			this._lblCommon_115 = new System.Windows.Forms.Label();
			this._lblCommon_33 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_46 = new System.Windows.Forms.TextBox();
			this._lblCommon_34 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_47 = new System.Windows.Forms.TextBox();
			this._lblCommon_35 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_48 = new System.Windows.Forms.TextBox();
			this._txtCommonTextBox_44 = new System.Windows.Forms.TextBox();
			this._txtCommonTextBox_45 = new System.Windows.Forms.TextBox();
			this._txtDisplayLabel_15 = new System.Windows.Forms.Label();
			this._lblCommon_0 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_14 = new System.Windows.Forms.TextBox();
			this._lblCommon_30 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_38 = new System.Windows.Forms.TextBox();
			this._lblCommon_38 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_49 = new System.Windows.Forms.TextBox();
			this._lblCommon_39 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_50 = new System.Windows.Forms.TextBox();
			this._lblCommon_40 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_51 = new System.Windows.Forms.TextBox();
			this._txtDisplayLabel_9 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_54 = new System.Windows.Forms.TextBox();
			this._txtCommonTextBox_55 = new System.Windows.Forms.TextBox();
			this._lblCommon_44 = new System.Windows.Forms.Label();
			this._lblCommon_45 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_53 = new System.Windows.Forms.TextBox();
			this._lblCommon_43 = new System.Windows.Forms.Label();
			this._fraEmployeeInformation_2 = new System.Windows.Forms.Panel();
			this.chkAllowTicket = new System.Windows.Forms.CheckBox();
			this.txtTicketAccrualStartDate = new Syncfusion.WinForms.Input.SfDateTimeEdit();
			this._lblCommon_23 = new System.Windows.Forms.Label();
			this._lblCommon_54 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_71 = new System.Windows.Forms.TextBox();
			this._lblCommon_68 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_73 = new System.Windows.Forms.TextBox();
			this._lblCommon_70 = new System.Windows.Forms.Label();
			this._txtDisplayLabel_11 = new System.Windows.Forms.Label();
			this._txtDisplayLabel_12 = new System.Windows.Forms.Label();
			// //((System.ComponentModel.ISupportInitialize) this.tabBillingType).BeginInit();
			this.tabBillingType.SuspendLayout();
			this._fraEmployeeInformation_1.SuspendLayout();
			this.Frame1.SuspendLayout();
			this.cmbMastersList.SuspendLayout();
			this.grdLeaveEarningDetails.SuspendLayout();
			this._fraEmployeeInformation_0.SuspendLayout();
			this._fraEmployeeInformation_4.SuspendLayout();
			this._fraEmployeeInformation_2.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabBillingType
			// 
			this.tabBillingType.Align = C1SizerLib.AlignSettings.asNone;
			this.tabBillingType.AllowDrop = true;
			this.tabBillingType.Controls.Add(this._fraEmployeeInformation_1);
			this.tabBillingType.Controls.Add(this._fraEmployeeInformation_0);
			this.tabBillingType.Controls.Add(this._fraEmployeeInformation_4);
			this.tabBillingType.Controls.Add(this._fraEmployeeInformation_2);
			this.tabBillingType.Location = new System.Drawing.Point(4, 60);
			this.tabBillingType.Name = "tabBillingType";
			("tabBillingType.OcxState");
			this.tabBillingType.Size = new System.Drawing.Size(477, 239);
			this.tabBillingType.TabIndex = 0;
			// 
			// _fraEmployeeInformation_1
			// 
			this._fraEmployeeInformation_1.AllowDrop = true;
			this._fraEmployeeInformation_1.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._fraEmployeeInformation_1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._fraEmployeeInformation_1.Controls.Add(this.txtNoOfMonths);
			this._fraEmployeeInformation_1.Controls.Add(this.System.Windows.Forms.Label2);
			this._fraEmployeeInformation_1.Controls.Add(this.Frame1);
			this._fraEmployeeInformation_1.Controls.Add(this.cmbMastersList);
			this._fraEmployeeInformation_1.Controls.Add(this.grdLeaveEarningDetails);
			this._fraEmployeeInformation_1.Enabled = true;
			this._fraEmployeeInformation_1.ForeColor = System.Drawing.SystemColors.WindowText;
			this._fraEmployeeInformation_1.Location = new System.Drawing.Point(518, 23);
			this._fraEmployeeInformation_1.Name = "_fraEmployeeInformation_1";
			this._fraEmployeeInformation_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._fraEmployeeInformation_1.Size = new System.Drawing.Size(475, 215);
			this._fraEmployeeInformation_1.TabIndex = 60;
			this._fraEmployeeInformation_1.Visible = true;
			// 
			// txtNoOfMonths
			// 
			this.txtNoOfMonths.AllowDrop = true;
			this.txtNoOfMonths.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtNoOfMonths.Location = new System.Drawing.Point(372, 6);
			this.txtNoOfMonths.Name = "txtNoOfMonths";
			this.txtNoOfMonths.Size = new System.Drawing.Size(91, 22);
			this.txtNoOfMonths.TabIndex = 74;
			// 
			// System.Windows.Forms.Label2
			// 
			this.System.Windows.Forms.Label2.AllowDrop = true;
			this.System.Windows.Forms.Label2.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this.System.Windows.Forms.Label2.Caption = "No of Months";
			this.System.Windows.Forms.Label2.Location = new System.Drawing.Point(288, 9);
			this.System.Windows.Forms.Label2.Name = "System.Windows.Forms.Label2";
			this.System.Windows.Forms.Label2.Size = new System.Drawing.Size(64, 14);
			this.System.Windows.Forms.Label2.TabIndex = 73;
			// 
			// Frame1
			// 
			this.Frame1.AllowDrop = true;
			this.Frame1.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this.Frame1.Controls.Add(this.OptNone);
			this.Frame1.Controls.Add(this.OptPriodWise);
			this.Frame1.Controls.Add(this.OptChkCalculate);
			this.Frame1.Enabled = true;
			this.Frame1.ForeColor = System.Drawing.SystemColors.WindowText;
			this.Frame1.Location = new System.Drawing.Point(3, -3);
			this.Frame1.Name = "Frame1";
			this.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Frame1.Size = new System.Drawing.Size(277, 34);
			this.Frame1.TabIndex = 70;
			this.Frame1.Visible = true;
			// 
			// OptNone
			// 
			this.OptNone.AllowDrop = true;
			this.OptNone.Appearance = System.Windows.Forms.Appearance.Normal;
			this.OptNone.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this.OptNone.CausesValidation = true;
			this.OptNone.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.OptNone.Checked = false;
			this.OptNone.Enabled = true;
			this.OptNone.ForeColor = System.Drawing.Color.Navy;
			this.OptNone.Location = new System.Drawing.Point(192, 12);
			this.OptNone.Name = "OptNone";
			this.OptNone.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.OptNone.Size = new System.Drawing.Size(73, 16);
			this.OptNone.TabIndex = 75;
			this.OptNone.TabStop = true;
			this.OptNone.Text = "None";
			this.OptNone.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.OptNone.Visible = true;
			this.OptNone.CheckedChanged += new System.EventHandler(this.OptNone_CheckedChanged);
			// 
			// OptPriodWise
			// 
			this.OptPriodWise.AllowDrop = true;
			this.OptPriodWise.Appearance = System.Windows.Forms.Appearance.Normal;
			this.OptPriodWise.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this.OptPriodWise.CausesValidation = true;
			this.OptPriodWise.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.OptPriodWise.Checked = false;
			this.OptPriodWise.Enabled = true;
			this.OptPriodWise.ForeColor = System.Drawing.Color.Navy;
			this.OptPriodWise.Location = new System.Drawing.Point(90, 12);
			this.OptPriodWise.Name = "OptPriodWise";
			this.OptPriodWise.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.OptPriodWise.Size = new System.Drawing.Size(85, 16);
			this.OptPriodWise.TabIndex = 72;
			this.OptPriodWise.TabStop = true;
			this.OptPriodWise.Text = "Period Wise";
			this.OptPriodWise.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.OptPriodWise.Visible = true;
			this.OptPriodWise.CheckedChanged += new System.EventHandler(this.OptPriodWise_CheckedChanged);
			// 
			// OptChkCalculate
			// 
			this.OptChkCalculate.AllowDrop = true;
			this.OptChkCalculate.Appearance = System.Windows.Forms.Appearance.Normal;
			this.OptChkCalculate.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this.OptChkCalculate.CausesValidation = true;
			this.OptChkCalculate.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.OptChkCalculate.Checked = false;
			this.OptChkCalculate.Enabled = true;
			this.OptChkCalculate.ForeColor = System.Drawing.Color.Navy;
			this.OptChkCalculate.Location = new System.Drawing.Point(3, 12);
			this.OptChkCalculate.Name = "OptChkCalculate";
			this.OptChkCalculate.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.OptChkCalculate.Size = new System.Drawing.Size(79, 19);
			this.OptChkCalculate.TabIndex = 71;
			this.OptChkCalculate.TabStop = true;
			this.OptChkCalculate.Text = "Percentage";
			this.OptChkCalculate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.OptChkCalculate.Visible = true;
			this.OptChkCalculate.CheckedChanged += new System.EventHandler(this.OptChkCalculate_CheckedChanged);
			// 
			// cmbMastersList
			// 
			this.cmbMastersList.AllowDrop = true;
			this.cmbMastersList.ColumnHeaders = true;
			this.cmbMastersList.Enabled = true;
			this.cmbMastersList.Location = new System.Drawing.Point(44, 86);
			this.cmbMastersList.Name = "cmbMastersList";
			this.cmbMastersList.Size = new System.Drawing.Size(53, 37);
			this.cmbMastersList.TabIndex = 67;
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
			this.grdLeaveEarningDetails.AllowDelete = true;
			this.grdLeaveEarningDetails.AllowDrop = true;
			this.grdLeaveEarningDetails.BackColor = System.Drawing.Color.FromArgb(212, 208, 200);
			this.grdLeaveEarningDetails.CellTipsWidth = 0;
			this.grdLeaveEarningDetails.Location = new System.Drawing.Point(2, 32);
			this.grdLeaveEarningDetails.Name = "grdLeaveEarningDetails";
			this.grdLeaveEarningDetails.RowDivider.Color = System.Drawing.Color.FromArgb(212, 208, 200);
			this.grdLeaveEarningDetails.Size = new System.Drawing.Size(471, 165);
			this.grdLeaveEarningDetails.TabIndex = 66;
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
			// _fraEmployeeInformation_0
			// 
			this._fraEmployeeInformation_0.AllowDrop = true;
			this._fraEmployeeInformation_0.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._fraEmployeeInformation_0.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._fraEmployeeInformation_0.Controls.Add(this.chkIncludeInBudget);
			this._fraEmployeeInformation_0.Controls.Add(this.CHKIncludeInBankTransfer);
			this._fraEmployeeInformation_0.Controls.Add(this.txtRoundDigit);
			this._fraEmployeeInformation_0.Controls.Add(this.txtComment);
			this._fraEmployeeInformation_0.Controls.Add(this.chkIncludeInDefaultBillingTypes);
			this._fraEmployeeInformation_0.Controls.Add(this._cmbCommon_0);
			this._fraEmployeeInformation_0.Controls.Add(this.lblLNatName);
			this._fraEmployeeInformation_0.Controls.Add(this.txtLBillName);
			this._fraEmployeeInformation_0.Controls.Add(this.lblANatName);
			this._fraEmployeeInformation_0.Controls.Add(this.txtABillName);
			this._fraEmployeeInformation_0.Controls.Add(this.lblComments);
			this._fraEmployeeInformation_0.Controls.Add(this.lblNatNo);
			this._fraEmployeeInformation_0.Controls.Add(this._System.Windows.Forms.Label1_0);
			this._fraEmployeeInformation_0.Controls.Add(this.txtBillNo);
			this._fraEmployeeInformation_0.Controls.Add(this._cmbCommon_1);
			this._fraEmployeeInformation_0.Controls.Add(this._System.Windows.Forms.Label1_1);
			this._fraEmployeeInformation_0.Controls.Add(this._System.Windows.Forms.Label1_2);
			this._fraEmployeeInformation_0.Enabled = true;
			this._fraEmployeeInformation_0.ForeColor = System.Drawing.SystemColors.WindowText;
			this._fraEmployeeInformation_0.Location = new System.Drawing.Point(1, 23);
			this._fraEmployeeInformation_0.Name = "_fraEmployeeInformation_0";
			this._fraEmployeeInformation_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._fraEmployeeInformation_0.Size = new System.Drawing.Size(475, 215);
			this._fraEmployeeInformation_0.TabIndex = 59;
			this._fraEmployeeInformation_0.Visible = true;
			// 
			// chkIncludeInBudget
			// 
			this.chkIncludeInBudget.AllowDrop = true;
			this.chkIncludeInBudget.Appearance = System.Windows.Forms.Appearance.Normal;
			this.chkIncludeInBudget.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this.chkIncludeInBudget.CausesValidation = true;
			this.chkIncludeInBudget.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkIncludeInBudget.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this.chkIncludeInBudget.Enabled = true;
			this.chkIncludeInBudget.ForeColor = System.Drawing.SystemColors.ControlText;
			this.chkIncludeInBudget.Location = new System.Drawing.Point(294, 153);
			this.chkIncludeInBudget.Name = "chkIncludeInBudget";
			this.chkIncludeInBudget.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.chkIncludeInBudget.Size = new System.Drawing.Size(140, 15);
			this.chkIncludeInBudget.TabIndex = 9;
			this.chkIncludeInBudget.TabStop = true;
			this.chkIncludeInBudget.Text = "Include In Budget";
			this.chkIncludeInBudget.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkIncludeInBudget.Visible = true;
			// 
			// CHKIncludeInBankTransfer
			// 
			this.CHKIncludeInBankTransfer.AllowDrop = true;
			this.CHKIncludeInBankTransfer.Appearance = System.Windows.Forms.Appearance.Normal;
			this.CHKIncludeInBankTransfer.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this.CHKIncludeInBankTransfer.CausesValidation = true;
			this.CHKIncludeInBankTransfer.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.CHKIncludeInBankTransfer.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this.CHKIncludeInBankTransfer.Enabled = true;
			this.CHKIncludeInBankTransfer.ForeColor = System.Drawing.SystemColors.ControlText;
			this.CHKIncludeInBankTransfer.Location = new System.Drawing.Point(111, 153);
			this.CHKIncludeInBankTransfer.Name = "CHKIncludeInBankTransfer";
			this.CHKIncludeInBankTransfer.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.CHKIncludeInBankTransfer.Size = new System.Drawing.Size(173, 15);
			this.CHKIncludeInBankTransfer.TabIndex = 8;
			this.CHKIncludeInBankTransfer.TabStop = true;
			this.CHKIncludeInBankTransfer.Text = "Include In Bank Transfer";
			this.CHKIncludeInBankTransfer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.CHKIncludeInBankTransfer.Visible = true;
			// 
			// txtRoundDigit
			// 
			this.txtRoundDigit.AllowDrop = true;
			this.txtRoundDigit.BackColor = System.Drawing.Color.White;
			// this.txtRoundDigit.bolAllowDecimal = false;
			// this.txtRoundDigit.bolNumericOnly = true;
			this.txtRoundDigit.ForeColor = System.Drawing.Color.Black;
			this.txtRoundDigit.Location = new System.Drawing.Point(388, 108);
			// this.txtRoundDigit.mDropDownType = (System.Windows.Forms.TextBox.DropDownTypes) 0;
			this.txtRoundDigit.Name = "txtRoundDigit";
			this.txtRoundDigit.Size = new System.Drawing.Size(45, 19);
			this.txtRoundDigit.TabIndex = 6;
			this.txtRoundDigit.Text = "";
			// this.this.txtRoundDigit.Watermark = "";
			// 
			// txtComment
			// 
			this.txtComment.AcceptsReturn = true;
			this.txtComment.AllowDrop = true;
			this.txtComment.BackColor = System.Drawing.SystemColors.Window;
			this.txtComment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtComment.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtComment.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtComment.Location = new System.Drawing.Point(110, 172);
			this.txtComment.MaxLength = 100;
			this.txtComment.Multiline = true;
			this.txtComment.Name = "txtComment";
			this.txtComment.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtComment.Size = new System.Drawing.Size(325, 38);
			this.txtComment.TabIndex = 10;
			// 
			// chkIncludeInDefaultBillingTypes
			// 
			this.chkIncludeInDefaultBillingTypes.AllowDrop = true;
			this.chkIncludeInDefaultBillingTypes.Appearance = System.Windows.Forms.Appearance.Normal;
			this.chkIncludeInDefaultBillingTypes.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this.chkIncludeInDefaultBillingTypes.CausesValidation = true;
			this.chkIncludeInDefaultBillingTypes.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkIncludeInDefaultBillingTypes.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this.chkIncludeInDefaultBillingTypes.Enabled = true;
			this.chkIncludeInDefaultBillingTypes.ForeColor = System.Drawing.SystemColors.ControlText;
			this.chkIncludeInDefaultBillingTypes.Location = new System.Drawing.Point(111, 134);
			this.chkIncludeInDefaultBillingTypes.Name = "chkIncludeInDefaultBillingTypes";
			this.chkIncludeInDefaultBillingTypes.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.chkIncludeInDefaultBillingTypes.Size = new System.Drawing.Size(173, 15);
			this.chkIncludeInDefaultBillingTypes.TabIndex = 7;
			this.chkIncludeInDefaultBillingTypes.TabStop = true;
			this.chkIncludeInDefaultBillingTypes.Text = "Include In Default Billing Types";
			this.chkIncludeInDefaultBillingTypes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkIncludeInDefaultBillingTypes.Visible = true;
			// 
			// _cmbCommon_0
			// 
			this._cmbCommon_0.AllowDrop = true;
			this._cmbCommon_0.Location = new System.Drawing.Point(110, 86);
			this._cmbCommon_0.Name = "_cmbCommon_0";
			this._cmbCommon_0.Size = new System.Drawing.Size(201, 21);
			this._cmbCommon_0.TabIndex = 4;
			// 
			// lblLNatName
			// 
			this.lblLNatName.AllowDrop = true;
			this.lblLNatName.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this.lblLNatName.Text = "Billing Name (English)";
			this.lblLNatName.Location = new System.Drawing.Point(2, 44);
			// this.lblLNatName.mLabelId = 1042;
			this.lblLNatName.Name = "lblLNatName";
			this.lblLNatName.Size = new System.Drawing.Size(102, 14);
			this.lblLNatName.TabIndex = 61;
			// 
			// txtLBillName
			// 
			this.txtLBillName.AllowDrop = true;
			this.txtLBillName.BackColor = System.Drawing.Color.White;
			this.txtLBillName.ForeColor = System.Drawing.Color.Black;
			this.txtLBillName.Location = new System.Drawing.Point(110, 42);
			this.txtLBillName.MaxLength = 50;
			this.txtLBillName.Name = "txtLBillName";
			this.txtLBillName.Size = new System.Drawing.Size(201, 19);
			this.txtLBillName.TabIndex = 2;
			this.txtLBillName.Text = "";
			// this.this.txtLBillName.Watermark = "";
			// 
			// lblANatName
			// 
			this.lblANatName.AllowDrop = true;
			this.lblANatName.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this.lblANatName.Text = "Billing Name (Arabic)";
			this.lblANatName.Location = new System.Drawing.Point(2, 66);
			// this.lblANatName.mLabelId = 1043;
			this.lblANatName.Name = "lblANatName";
			this.lblANatName.Size = new System.Drawing.Size(100, 14);
			this.lblANatName.TabIndex = 62;
			// 
			// txtABillName
			// 
			this.txtABillName.AllowDrop = true;
			this.txtABillName.BackColor = System.Drawing.Color.White;
			this.txtABillName.ForeColor = System.Drawing.Color.Black;
			this.txtABillName.Location = new System.Drawing.Point(110, 64);
			// this.txtABillName.mArabicEnabled = true;
			this.txtABillName.MaxLength = 50;
			this.txtABillName.Name = "txtABillName";
			this.txtABillName.Size = new System.Drawing.Size(201, 19);
			this.txtABillName.TabIndex = 3;
			this.txtABillName.Text = "";
			// this.this.txtABillName.Watermark = "";
			// 
			// lblComments
			// 
			this.lblComments.AllowDrop = true;
			this.lblComments.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this.lblComments.Text = "Comment";
			this.lblComments.Location = new System.Drawing.Point(2, 184);
			// this.lblComments.mLabelId = 1851;
			this.lblComments.Name = "lblComments";
			this.lblComments.Size = new System.Drawing.Size(44, 14);
			this.lblComments.TabIndex = 63;
			// 
			// lblNatNo
			// 
			this.lblNatNo.AllowDrop = true;
			this.lblNatNo.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this.lblNatNo.Text = "Billing Code";
			this.lblNatNo.Location = new System.Drawing.Point(2, 22);
			// this.lblNatNo.mLabelId = 1041;
			this.lblNatNo.Name = "lblNatNo";
			this.lblNatNo.Size = new System.Drawing.Size(55, 14);
			this.lblNatNo.TabIndex = 64;
			// 
			// _System.Windows.Forms.Label1_0
			// 
			this._System.Windows.Forms.Label1_0.AllowDrop = true;
			this._System.Windows.Forms.Label1_0.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._System.Windows.Forms.Label1_0.Caption = "Billing Types";
			this._System.Windows.Forms.Label1_0.Location = new System.Drawing.Point(2, 89);
			this._System.Windows.Forms.Label1_0.mLabelId = 1979;
			this._System.Windows.Forms.Label1_0.Name = "_System.Windows.Forms.Label1_0";
			this._System.Windows.Forms.Label1_0.Size = new System.Drawing.Size(60, 14);
			this._System.Windows.Forms.Label1_0.TabIndex = 65;
			// 
			// txtBillNo
			// 
			this.txtBillNo.AllowDrop = true;
			this.txtBillNo.BackColor = System.Drawing.Color.White;
			this.txtBillNo.ForeColor = System.Drawing.Color.Black;
			this.txtBillNo.Location = new System.Drawing.Point(110, 22);
			this.txtBillNo.MaxLength = 20;
			// this.txtBillNo.mDropDownType = System.Windows.Forms.TextBox.DropDownTypes.ddtNextNumber;
			this.txtBillNo.Name = "txtBillNo";
			// this.txtBillNo.ShowButton = true;
			this.txtBillNo.Size = new System.Drawing.Size(102, 19);
			this.txtBillNo.TabIndex = 1;
			this.txtBillNo.Text = "";
			// this.this.txtBillNo.Watermark = "";
			// this.this.txtBillNo.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtBillNo_DropButtonClick);
			// 
			// _cmbCommon_1
			// 
			this._cmbCommon_1.AllowDrop = true;
			this._cmbCommon_1.Location = new System.Drawing.Point(110, 108);
			this._cmbCommon_1.Name = "_cmbCommon_1";
			this._cmbCommon_1.Size = new System.Drawing.Size(201, 21);
			this._cmbCommon_1.TabIndex = 5;
			// 
			// _System.Windows.Forms.Label1_1
			// 
			this._System.Windows.Forms.Label1_1.AllowDrop = true;
			this._System.Windows.Forms.Label1_1.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._System.Windows.Forms.Label1_1.Caption = "Billing Method";
			this._System.Windows.Forms.Label1_1.Location = new System.Drawing.Point(2, 112);
			this._System.Windows.Forms.Label1_1.mLabelId = 2151;
			this._System.Windows.Forms.Label1_1.Name = "_System.Windows.Forms.Label1_1";
			this._System.Windows.Forms.Label1_1.Size = new System.Drawing.Size(65, 14);
			this._System.Windows.Forms.Label1_1.TabIndex = 68;
			// 
			// _System.Windows.Forms.Label1_2
			// 
			this._System.Windows.Forms.Label1_2.AllowDrop = true;
			this._System.Windows.Forms.Label1_2.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._System.Windows.Forms.Label1_2.Caption = "Round On";
			this._System.Windows.Forms.Label1_2.Location = new System.Drawing.Point(318, 110);
			this._System.Windows.Forms.Label1_2.mLabelId = 2152;
			this._System.Windows.Forms.Label1_2.Name = "_System.Windows.Forms.Label1_2";
			this._System.Windows.Forms.Label1_2.Size = new System.Drawing.Size(48, 14);
			this._System.Windows.Forms.Label1_2.TabIndex = 69;
			// 
			// _fraEmployeeInformation_4
			// 
			this._fraEmployeeInformation_4.AllowDrop = true;
			this._fraEmployeeInformation_4.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._fraEmployeeInformation_4.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._fraEmployeeInformation_4.Controls.Add(this._lblCommon_27);
			this._fraEmployeeInformation_4.Controls.Add(this._txtCommonTextBox_40);
			this._fraEmployeeInformation_4.Controls.Add(this._lblCommon_28);
			this._fraEmployeeInformation_4.Controls.Add(this._txtCommonTextBox_41);
			this._fraEmployeeInformation_4.Controls.Add(this._lblCommon_29);
			this._fraEmployeeInformation_4.Controls.Add(this._txtCommonTextBox_42);
			this._fraEmployeeInformation_4.Controls.Add(this._lblCommon_31);
			this._fraEmployeeInformation_4.Controls.Add(this._txtCommonTextBox_43);
			this._fraEmployeeInformation_4.Controls.Add(this._lblCommon_32);
			this._fraEmployeeInformation_4.Controls.Add(this._lblCommon_115);
			this._fraEmployeeInformation_4.Controls.Add(this._lblCommon_33);
			this._fraEmployeeInformation_4.Controls.Add(this._txtCommonTextBox_46);
			this._fraEmployeeInformation_4.Controls.Add(this._lblCommon_34);
			this._fraEmployeeInformation_4.Controls.Add(this._txtCommonTextBox_47);
			this._fraEmployeeInformation_4.Controls.Add(this._lblCommon_35);
			this._fraEmployeeInformation_4.Controls.Add(this._txtCommonTextBox_48);
			this._fraEmployeeInformation_4.Controls.Add(this._txtCommonTextBox_44);
			this._fraEmployeeInformation_4.Controls.Add(this._txtCommonTextBox_45);
			this._fraEmployeeInformation_4.Controls.Add(this._txtDisplayLabel_15);
			this._fraEmployeeInformation_4.Controls.Add(this._lblCommon_0);
			this._fraEmployeeInformation_4.Controls.Add(this._txtCommonTextBox_14);
			this._fraEmployeeInformation_4.Controls.Add(this._lblCommon_30);
			this._fraEmployeeInformation_4.Controls.Add(this._txtCommonTextBox_38);
			this._fraEmployeeInformation_4.Controls.Add(this._lblCommon_38);
			this._fraEmployeeInformation_4.Controls.Add(this._txtCommonTextBox_49);
			this._fraEmployeeInformation_4.Controls.Add(this._lblCommon_39);
			this._fraEmployeeInformation_4.Controls.Add(this._txtCommonTextBox_50);
			this._fraEmployeeInformation_4.Controls.Add(this._lblCommon_40);
			this._fraEmployeeInformation_4.Controls.Add(this._txtCommonTextBox_51);
			this._fraEmployeeInformation_4.Controls.Add(this._txtDisplayLabel_9);
			this._fraEmployeeInformation_4.Controls.Add(this._txtCommonTextBox_54);
			this._fraEmployeeInformation_4.Controls.Add(this._txtCommonTextBox_55);
			this._fraEmployeeInformation_4.Controls.Add(this._lblCommon_44);
			this._fraEmployeeInformation_4.Controls.Add(this._lblCommon_45);
			this._fraEmployeeInformation_4.Controls.Add(this._txtCommonTextBox_53);
			this._fraEmployeeInformation_4.Controls.Add(this._lblCommon_43);
			this._fraEmployeeInformation_4.Enabled = true;
			this._fraEmployeeInformation_4.ForeColor = System.Drawing.SystemColors.WindowText;
			this._fraEmployeeInformation_4.Location = new System.Drawing.Point(538, 23);
			this._fraEmployeeInformation_4.Name = "_fraEmployeeInformation_4";
			this._fraEmployeeInformation_4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._fraEmployeeInformation_4.Size = new System.Drawing.Size(475, 215);
			this._fraEmployeeInformation_4.TabIndex = 22;
			this._fraEmployeeInformation_4.Visible = true;
			// 
			// _lblCommon_27
			// 
			this._lblCommon_27.AllowDrop = true;
			this._lblCommon_27.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._lblCommon_27.Text = "Father Name (English)";
			this._lblCommon_27.Location = new System.Drawing.Point(10, 16);
			// this._lblCommon_27.mLabelId = 1078;
			this._lblCommon_27.Name = "_lblCommon_27";
			this._lblCommon_27.Size = new System.Drawing.Size(106, 13);
			this._lblCommon_27.TabIndex = 23;
			// 
			// _txtCommonTextBox_40
			// 
			this._txtCommonTextBox_40.AllowDrop = true;
			this._txtCommonTextBox_40.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_40.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_40.Location = new System.Drawing.Point(126, 14);
			this._txtCommonTextBox_40.Name = "_txtCommonTextBox_40";
			this._txtCommonTextBox_40.Size = new System.Drawing.Size(461, 19);
			this._txtCommonTextBox_40.TabIndex = 24;
			this._txtCommonTextBox_40.Text = "";
			// this.this._txtCommonTextBox_40.Watermark = "";
			// 
			// _lblCommon_28
			// 
			this._lblCommon_28.AllowDrop = true;
			this._lblCommon_28.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._lblCommon_28.Text = "Father Name (Arabic)";
			this._lblCommon_28.Location = new System.Drawing.Point(10, 38);
			// this._lblCommon_28.mLabelId = 1079;
			this._lblCommon_28.Name = "_lblCommon_28";
			this._lblCommon_28.Size = new System.Drawing.Size(103, 13);
			this._lblCommon_28.TabIndex = 25;
			// 
			// _txtCommonTextBox_41
			// 
			this._txtCommonTextBox_41.AllowDrop = true;
			this._txtCommonTextBox_41.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_41.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_41.Location = new System.Drawing.Point(126, 35);
			// this._txtCommonTextBox_41.mArabicEnabled = true;
			this._txtCommonTextBox_41.Name = "_txtCommonTextBox_41";
			this._txtCommonTextBox_41.Size = new System.Drawing.Size(461, 19);
			this._txtCommonTextBox_41.TabIndex = 26;
			this._txtCommonTextBox_41.Text = "";
			// this.this._txtCommonTextBox_41.Watermark = "";
			// 
			// _lblCommon_29
			// 
			this._lblCommon_29.AllowDrop = true;
			this._lblCommon_29.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._lblCommon_29.Text = "Mother Name (English)";
			this._lblCommon_29.Location = new System.Drawing.Point(10, 59);
			// this._lblCommon_29.mLabelId = 1080;
			this._lblCommon_29.Name = "_lblCommon_29";
			this._lblCommon_29.Size = new System.Drawing.Size(108, 13);
			this._lblCommon_29.TabIndex = 27;
			// 
			// _txtCommonTextBox_42
			// 
			this._txtCommonTextBox_42.AllowDrop = true;
			this._txtCommonTextBox_42.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_42.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_42.Location = new System.Drawing.Point(126, 56);
			this._txtCommonTextBox_42.Name = "_txtCommonTextBox_42";
			this._txtCommonTextBox_42.Size = new System.Drawing.Size(461, 19);
			this._txtCommonTextBox_42.TabIndex = 28;
			this._txtCommonTextBox_42.Text = "";
			// this.this._txtCommonTextBox_42.Watermark = "";
			// 
			// _lblCommon_31
			// 
			this._lblCommon_31.AllowDrop = true;
			this._lblCommon_31.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._lblCommon_31.Text = "Mother Name (Arabic)";
			this._lblCommon_31.Location = new System.Drawing.Point(10, 80);
			// this._lblCommon_31.mLabelId = 1081;
			this._lblCommon_31.Name = "_lblCommon_31";
			this._lblCommon_31.Size = new System.Drawing.Size(105, 13);
			this._lblCommon_31.TabIndex = 29;
			// 
			// _txtCommonTextBox_43
			// 
			this._txtCommonTextBox_43.AllowDrop = true;
			this._txtCommonTextBox_43.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_43.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_43.Location = new System.Drawing.Point(126, 77);
			// this._txtCommonTextBox_43.mArabicEnabled = true;
			this._txtCommonTextBox_43.Name = "_txtCommonTextBox_43";
			this._txtCommonTextBox_43.Size = new System.Drawing.Size(461, 19);
			this._txtCommonTextBox_43.TabIndex = 30;
			this._txtCommonTextBox_43.Text = "";
			// this.this._txtCommonTextBox_43.Watermark = "";
			// 
			// _lblCommon_32
			// 
			this._lblCommon_32.AllowDrop = true;
			this._lblCommon_32.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._lblCommon_32.Text = "Place Of Birth";
			this._lblCommon_32.Location = new System.Drawing.Point(10, 101);
			// this._lblCommon_32.mLabelId = 1985;
			this._lblCommon_32.Name = "_lblCommon_32";
			this._lblCommon_32.Size = new System.Drawing.Size(65, 13);
			this._lblCommon_32.TabIndex = 31;
			// 
			// _lblCommon_115
			// 
			this._lblCommon_115.AllowDrop = true;
			this._lblCommon_115.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._lblCommon_115.Text = "Qualification Code";
			this._lblCommon_115.Location = new System.Drawing.Point(10, 122);
			// this._lblCommon_115.mLabelId = 1082;
			this._lblCommon_115.Name = "_lblCommon_115";
			this._lblCommon_115.Size = new System.Drawing.Size(87, 14);
			this._lblCommon_115.TabIndex = 32;
			// 
			// _lblCommon_33
			// 
			this._lblCommon_33.AllowDrop = true;
			this._lblCommon_33.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._lblCommon_33.Text = "Blood Group";
			this._lblCommon_33.Location = new System.Drawing.Point(10, 142);
			// this._lblCommon_33.mLabelId = 1083;
			this._lblCommon_33.Name = "_lblCommon_33";
			this._lblCommon_33.Size = new System.Drawing.Size(58, 13);
			this._lblCommon_33.TabIndex = 33;
			// 
			// _txtCommonTextBox_46
			// 
			this._txtCommonTextBox_46.AllowDrop = true;
			this._txtCommonTextBox_46.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_46.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_46.Location = new System.Drawing.Point(126, 140);
			this._txtCommonTextBox_46.Name = "_txtCommonTextBox_46";
			this._txtCommonTextBox_46.Size = new System.Drawing.Size(51, 19);
			this._txtCommonTextBox_46.TabIndex = 34;
			this._txtCommonTextBox_46.Text = "";
			// this.this._txtCommonTextBox_46.Watermark = "";
			// 
			// _lblCommon_34
			// 
			this._lblCommon_34.AllowDrop = true;
			this._lblCommon_34.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._lblCommon_34.Text = "No. of Wives";
			this._lblCommon_34.Location = new System.Drawing.Point(256, 143);
			// this._lblCommon_34.mLabelId = 1084;
			this._lblCommon_34.Name = "_lblCommon_34";
			this._lblCommon_34.Size = new System.Drawing.Size(62, 13);
			this._lblCommon_34.TabIndex = 35;
			// 
			// _txtCommonTextBox_47
			// 
			this._txtCommonTextBox_47.AllowDrop = true;
			this._txtCommonTextBox_47.BackColor = System.Drawing.Color.White;
			// this._txtCommonTextBox_47.bolAllowDecimal = false;
			// this._txtCommonTextBox_47.bolNumericOnly = true;
			this._txtCommonTextBox_47.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_47.Location = new System.Drawing.Point(328, 140);
			this._txtCommonTextBox_47.MaxLength = 2;
			this._txtCommonTextBox_47.Name = "_txtCommonTextBox_47";
			this._txtCommonTextBox_47.Size = new System.Drawing.Size(51, 19);
			this._txtCommonTextBox_47.TabIndex = 36;
			this._txtCommonTextBox_47.Text = "";
			// this.this._txtCommonTextBox_47.Watermark = "";
			// 
			// _lblCommon_35
			// 
			this._lblCommon_35.AllowDrop = true;
			this._lblCommon_35.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._lblCommon_35.Text = "No. of Children";
			this._lblCommon_35.Location = new System.Drawing.Point(454, 144);
			// this._lblCommon_35.mLabelId = 1085;
			this._lblCommon_35.Name = "_lblCommon_35";
			this._lblCommon_35.Size = new System.Drawing.Size(72, 13);
			this._lblCommon_35.TabIndex = 37;
			// 
			// _txtCommonTextBox_48
			// 
			this._txtCommonTextBox_48.AllowDrop = true;
			this._txtCommonTextBox_48.BackColor = System.Drawing.Color.White;
			// this._txtCommonTextBox_48.bolAllowDecimal = false;
			// this._txtCommonTextBox_48.bolNumericOnly = true;
			this._txtCommonTextBox_48.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_48.Location = new System.Drawing.Point(536, 140);
			this._txtCommonTextBox_48.MaxLength = 2;
			this._txtCommonTextBox_48.Name = "_txtCommonTextBox_48";
			this._txtCommonTextBox_48.Size = new System.Drawing.Size(51, 19);
			this._txtCommonTextBox_48.TabIndex = 38;
			this._txtCommonTextBox_48.Text = "";
			// this.this._txtCommonTextBox_48.Watermark = "";
			// 
			// _txtCommonTextBox_44
			// 
			this._txtCommonTextBox_44.AllowDrop = true;
			this._txtCommonTextBox_44.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_44.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_44.Location = new System.Drawing.Point(126, 98);
			this._txtCommonTextBox_44.Name = "_txtCommonTextBox_44";
			this._txtCommonTextBox_44.Size = new System.Drawing.Size(101, 19);
			this._txtCommonTextBox_44.TabIndex = 39;
			this._txtCommonTextBox_44.Text = "";
			// this.this._txtCommonTextBox_44.Watermark = "";
			// 
			// _txtCommonTextBox_45
			// 
			this._txtCommonTextBox_45.AllowDrop = true;
			this._txtCommonTextBox_45.BackColor = System.Drawing.Color.White;
			// this._txtCommonTextBox_45.bolNumericOnly = true;
			this._txtCommonTextBox_45.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_45.Location = new System.Drawing.Point(126, 119);
			this._txtCommonTextBox_45.MaxLength = 4;
			this._txtCommonTextBox_45.Name = "_txtCommonTextBox_45";
			// this._txtCommonTextBox_45.ShowButton = true;
			this._txtCommonTextBox_45.Size = new System.Drawing.Size(101, 19);
			this._txtCommonTextBox_45.TabIndex = 40;
			this._txtCommonTextBox_45.Text = "";
			// this.this._txtCommonTextBox_45.Watermark = "";
			// 
			// _txtDisplayLabel_15
			// 
			this._txtDisplayLabel_15.AllowDrop = true;
			this._txtDisplayLabel_15.Location = new System.Drawing.Point(228, 119);
			this._txtDisplayLabel_15.Name = "_txtDisplayLabel_15";
			this._txtDisplayLabel_15.Size = new System.Drawing.Size(201, 19);
			this._txtDisplayLabel_15.TabIndex = 41;
			this._txtDisplayLabel_15.TabStop = false;
			// 
			// _lblCommon_0
			// 
			this._lblCommon_0.AllowDrop = true;
			this._lblCommon_0.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._lblCommon_0.Text = "Passport No.";
			this._lblCommon_0.Location = new System.Drawing.Point(256, 164);
			// this._lblCommon_0.mLabelId = 1550;
			this._lblCommon_0.Name = "_lblCommon_0";
			this._lblCommon_0.Size = new System.Drawing.Size(62, 13);
			this._lblCommon_0.TabIndex = 42;
			// 
			// _txtCommonTextBox_14
			// 
			this._txtCommonTextBox_14.AllowDrop = true;
			this._txtCommonTextBox_14.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_14.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_14.Location = new System.Drawing.Point(328, 161);
			this._txtCommonTextBox_14.MaxLength = 20;
			this._txtCommonTextBox_14.Name = "_txtCommonTextBox_14";
			this._txtCommonTextBox_14.Size = new System.Drawing.Size(101, 19);
			this._txtCommonTextBox_14.TabIndex = 43;
			this._txtCommonTextBox_14.Text = "";
			// this.this._txtCommonTextBox_14.Watermark = "";
			// 
			// _lblCommon_30
			// 
			this._lblCommon_30.AllowDrop = true;
			this._lblCommon_30.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._lblCommon_30.Text = "Civil Id";
			this._lblCommon_30.Location = new System.Drawing.Point(10, 164);
			// this._lblCommon_30.mLabelId = 1930;
			this._lblCommon_30.Name = "_lblCommon_30";
			this._lblCommon_30.Size = new System.Drawing.Size(32, 13);
			this._lblCommon_30.TabIndex = 44;
			// 
			// _txtCommonTextBox_38
			// 
			this._txtCommonTextBox_38.AllowDrop = true;
			this._txtCommonTextBox_38.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_38.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_38.Location = new System.Drawing.Point(126, 161);
			this._txtCommonTextBox_38.MaxLength = 20;
			this._txtCommonTextBox_38.Name = "_txtCommonTextBox_38";
			this._txtCommonTextBox_38.Size = new System.Drawing.Size(101, 19);
			this._txtCommonTextBox_38.TabIndex = 45;
			this._txtCommonTextBox_38.Text = "";
			// this.this._txtCommonTextBox_38.Watermark = "";
			// 
			// _lblCommon_38
			// 
			this._lblCommon_38.AllowDrop = true;
			this._lblCommon_38.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._lblCommon_38.Text = "Work Permit No.";
			this._lblCommon_38.Location = new System.Drawing.Point(10, 183);
			// this._lblCommon_38.mLabelId = 1966;
			this._lblCommon_38.Name = "_lblCommon_38";
			this._lblCommon_38.Size = new System.Drawing.Size(78, 13);
			this._lblCommon_38.TabIndex = 46;
			// 
			// _txtCommonTextBox_49
			// 
			this._txtCommonTextBox_49.AllowDrop = true;
			this._txtCommonTextBox_49.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_49.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_49.Location = new System.Drawing.Point(126, 180);
			this._txtCommonTextBox_49.MaxLength = 20;
			this._txtCommonTextBox_49.Name = "_txtCommonTextBox_49";
			this._txtCommonTextBox_49.Size = new System.Drawing.Size(101, 19);
			this._txtCommonTextBox_49.TabIndex = 47;
			this._txtCommonTextBox_49.Text = "";
			// this.this._txtCommonTextBox_49.Watermark = "";
			// 
			// _lblCommon_39
			// 
			this._lblCommon_39.AllowDrop = true;
			this._lblCommon_39.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._lblCommon_39.Text = "Visa No.";
			this._lblCommon_39.Location = new System.Drawing.Point(446, 202);
			// this._lblCommon_39.mLabelId = 1968;
			this._lblCommon_39.Name = "_lblCommon_39";
			this._lblCommon_39.Size = new System.Drawing.Size(39, 13);
			this._lblCommon_39.TabIndex = 48;
			// 
			// _txtCommonTextBox_50
			// 
			this._txtCommonTextBox_50.AllowDrop = true;
			this._txtCommonTextBox_50.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_50.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_50.Location = new System.Drawing.Point(490, 200);
			this._txtCommonTextBox_50.MaxLength = 20;
			this._txtCommonTextBox_50.Name = "_txtCommonTextBox_50";
			this._txtCommonTextBox_50.Size = new System.Drawing.Size(97, 19);
			this._txtCommonTextBox_50.TabIndex = 49;
			this._txtCommonTextBox_50.Text = "";
			// this.this._txtCommonTextBox_50.Watermark = "";
			// 
			// _lblCommon_40
			// 
			this._lblCommon_40.AllowDrop = true;
			this._lblCommon_40.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._lblCommon_40.Text = "Visa Type Code";
			this._lblCommon_40.Location = new System.Drawing.Point(10, 203);
			// this._lblCommon_40.mLabelId = 1967;
			this._lblCommon_40.Name = "_lblCommon_40";
			this._lblCommon_40.Size = new System.Drawing.Size(74, 13);
			this._lblCommon_40.TabIndex = 50;
			// 
			// _txtCommonTextBox_51
			// 
			this._txtCommonTextBox_51.AllowDrop = true;
			this._txtCommonTextBox_51.BackColor = System.Drawing.Color.White;
			// this._txtCommonTextBox_51.bolNumericOnly = true;
			this._txtCommonTextBox_51.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_51.Location = new System.Drawing.Point(126, 200);
			this._txtCommonTextBox_51.MaxLength = 20;
			this._txtCommonTextBox_51.Name = "_txtCommonTextBox_51";
			// this._txtCommonTextBox_51.ShowButton = true;
			this._txtCommonTextBox_51.Size = new System.Drawing.Size(101, 19);
			this._txtCommonTextBox_51.TabIndex = 51;
			this._txtCommonTextBox_51.Text = "";
			// this.this._txtCommonTextBox_51.Watermark = "";
			// 
			// _txtDisplayLabel_9
			// 
			this._txtDisplayLabel_9.AllowDrop = true;
			this._txtDisplayLabel_9.Location = new System.Drawing.Point(228, 200);
			this._txtDisplayLabel_9.Name = "_txtDisplayLabel_9";
			this._txtDisplayLabel_9.Size = new System.Drawing.Size(201, 19);
			this._txtDisplayLabel_9.TabIndex = 52;
			this._txtDisplayLabel_9.TabStop = false;
			// 
			// _txtCommonTextBox_54
			// 
			this._txtCommonTextBox_54.AllowDrop = true;
			this._txtCommonTextBox_54.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_54.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_54.Location = new System.Drawing.Point(126, 242);
			this._txtCommonTextBox_54.MaxLength = 100;
			this._txtCommonTextBox_54.Name = "_txtCommonTextBox_54";
			this._txtCommonTextBox_54.Size = new System.Drawing.Size(461, 19);
			this._txtCommonTextBox_54.TabIndex = 53;
			this._txtCommonTextBox_54.Text = "";
			// this.this._txtCommonTextBox_54.Watermark = "";
			// 
			// _txtCommonTextBox_55
			// 
			this._txtCommonTextBox_55.AllowDrop = true;
			this._txtCommonTextBox_55.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_55.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_55.Location = new System.Drawing.Point(126, 263);
			this._txtCommonTextBox_55.MaxLength = 100;
			this._txtCommonTextBox_55.Name = "_txtCommonTextBox_55";
			this._txtCommonTextBox_55.Size = new System.Drawing.Size(461, 19);
			this._txtCommonTextBox_55.TabIndex = 54;
			this._txtCommonTextBox_55.Text = "";
			// this.this._txtCommonTextBox_55.Watermark = "";
			// 
			// _lblCommon_44
			// 
			this._lblCommon_44.AllowDrop = true;
			this._lblCommon_44.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._lblCommon_44.Text = "Comments 2";
			this._lblCommon_44.Location = new System.Drawing.Point(10, 245);
			// this._lblCommon_44.mLabelId = 2012;
			this._lblCommon_44.Name = "_lblCommon_44";
			this._lblCommon_44.Size = new System.Drawing.Size(59, 13);
			this._lblCommon_44.TabIndex = 55;
			// 
			// _lblCommon_45
			// 
			this._lblCommon_45.AllowDrop = true;
			this._lblCommon_45.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._lblCommon_45.Text = "Comments 3";
			this._lblCommon_45.Location = new System.Drawing.Point(10, 266);
			// this._lblCommon_45.mLabelId = 2013;
			this._lblCommon_45.Name = "_lblCommon_45";
			this._lblCommon_45.Size = new System.Drawing.Size(59, 13);
			this._lblCommon_45.TabIndex = 56;
			// 
			// _txtCommonTextBox_53
			// 
			this._txtCommonTextBox_53.AllowDrop = true;
			this._txtCommonTextBox_53.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_53.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_53.Location = new System.Drawing.Point(126, 221);
			this._txtCommonTextBox_53.MaxLength = 100;
			this._txtCommonTextBox_53.Name = "_txtCommonTextBox_53";
			this._txtCommonTextBox_53.Size = new System.Drawing.Size(461, 19);
			this._txtCommonTextBox_53.TabIndex = 57;
			this._txtCommonTextBox_53.Text = "";
			// this.this._txtCommonTextBox_53.Watermark = "";
			// 
			// _lblCommon_43
			// 
			this._lblCommon_43.AllowDrop = true;
			this._lblCommon_43.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._lblCommon_43.Text = "Comments 1";
			this._lblCommon_43.Location = new System.Drawing.Point(10, 224);
			// this._lblCommon_43.mLabelId = 2010;
			this._lblCommon_43.Name = "_lblCommon_43";
			this._lblCommon_43.Size = new System.Drawing.Size(59, 13);
			this._lblCommon_43.TabIndex = 58;
			// 
			// _fraEmployeeInformation_2
			// 
			this._fraEmployeeInformation_2.AllowDrop = true;
			this._fraEmployeeInformation_2.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._fraEmployeeInformation_2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._fraEmployeeInformation_2.Controls.Add(this.chkAllowTicket);
			this._fraEmployeeInformation_2.Controls.Add(this.txtTicketAccrualStartDate);
			this._fraEmployeeInformation_2.Controls.Add(this._lblCommon_23);
			this._fraEmployeeInformation_2.Controls.Add(this._lblCommon_54);
			this._fraEmployeeInformation_2.Controls.Add(this._txtCommonTextBox_71);
			this._fraEmployeeInformation_2.Controls.Add(this._lblCommon_68);
			this._fraEmployeeInformation_2.Controls.Add(this._txtCommonTextBox_73);
			this._fraEmployeeInformation_2.Controls.Add(this._lblCommon_70);
			this._fraEmployeeInformation_2.Controls.Add(this._txtDisplayLabel_11);
			this._fraEmployeeInformation_2.Controls.Add(this._txtDisplayLabel_12);
			this._fraEmployeeInformation_2.Enabled = true;
			this._fraEmployeeInformation_2.ForeColor = System.Drawing.SystemColors.WindowText;
			this._fraEmployeeInformation_2.Location = new System.Drawing.Point(558, 23);
			this._fraEmployeeInformation_2.Name = "_fraEmployeeInformation_2";
			this._fraEmployeeInformation_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._fraEmployeeInformation_2.Size = new System.Drawing.Size(475, 215);
			this._fraEmployeeInformation_2.TabIndex = 11;
			this._fraEmployeeInformation_2.Visible = true;
			// 
			// chkAllowTicket
			// 
			this.chkAllowTicket.AllowDrop = true;
			this.chkAllowTicket.Appearance = System.Windows.Forms.Appearance.Normal;
			this.chkAllowTicket.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.chkAllowTicket.CausesValidation = true;
			this.chkAllowTicket.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkAllowTicket.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this.chkAllowTicket.Enabled = true;
			this.chkAllowTicket.ForeColor = System.Drawing.SystemColors.ControlText;
			this.chkAllowTicket.Location = new System.Drawing.Point(118, 16);
			this.chkAllowTicket.Name = "chkAllowTicket";
			this.chkAllowTicket.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.chkAllowTicket.Size = new System.Drawing.Size(17, 13);
			this.chkAllowTicket.TabIndex = 14;
			this.chkAllowTicket.TabStop = true;
			this.chkAllowTicket.Text = "";
			this.chkAllowTicket.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkAllowTicket.Visible = true;
			// 
			// txtTicketAccrualStartDate
			// 
			this.txtTicketAccrualStartDate.AllowDrop = true;
			// this.txtTicketAccrualStartDate.CheckDateRange = false;
			this.txtTicketAccrualStartDate.Location = new System.Drawing.Point(118, 78);
			// this.txtTicketAccrualStartDate.MaxDate = 2958465;
			// this.txtTicketAccrualStartDate.MinDate = -657434;
			this.txtTicketAccrualStartDate.Name = "txtTicketAccrualStartDate";
			this.txtTicketAccrualStartDate.PromptChar = "_";
			this.txtTicketAccrualStartDate.Size = new System.Drawing.Size(100, 19);
			this.txtTicketAccrualStartDate.TabIndex = 12;
			this.txtTicketAccrualStartDate.Text = "15/08/2009";
			this.txtTicketAccrualStartDate.Value = 40040;
			// 
			// _lblCommon_23
			// 
			this._lblCommon_23.AllowDrop = true;
			this._lblCommon_23.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._lblCommon_23.Text = "Accrual Start Date";
			this._lblCommon_23.Location = new System.Drawing.Point(10, 81);
			this._lblCommon_23.Name = "_lblCommon_23";
			this._lblCommon_23.Size = new System.Drawing.Size(89, 14);
			this._lblCommon_23.TabIndex = 13;
			// 
			// _lblCommon_54
			// 
			this._lblCommon_54.AllowDrop = true;
			this._lblCommon_54.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._lblCommon_54.Text = "Allow Ticket";
			this._lblCommon_54.Location = new System.Drawing.Point(10, 16);
			this._lblCommon_54.Name = "_lblCommon_54";
			this._lblCommon_54.Size = new System.Drawing.Size(56, 13);
			this._lblCommon_54.TabIndex = 15;
			// 
			// _txtCommonTextBox_71
			// 
			this._txtCommonTextBox_71.AllowDrop = true;
			this._txtCommonTextBox_71.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_71.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_71.Location = new System.Drawing.Point(118, 58);
			this._txtCommonTextBox_71.MaxLength = 100;
			this._txtCommonTextBox_71.Name = "_txtCommonTextBox_71";
			// this._txtCommonTextBox_71.ShowButton = true;
			this._txtCommonTextBox_71.Size = new System.Drawing.Size(100, 19);
			this._txtCommonTextBox_71.TabIndex = 16;
			this._txtCommonTextBox_71.Text = "";
			// this.this._txtCommonTextBox_71.Watermark = "";
			// 
			// _lblCommon_68
			// 
			this._lblCommon_68.AllowDrop = true;
			this._lblCommon_68.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._lblCommon_68.Text = "Tickect Destination";
			this._lblCommon_68.Location = new System.Drawing.Point(10, 61);
			this._lblCommon_68.Name = "_lblCommon_68";
			this._lblCommon_68.Size = new System.Drawing.Size(90, 13);
			this._lblCommon_68.TabIndex = 17;
			// 
			// _txtCommonTextBox_73
			// 
			this._txtCommonTextBox_73.AllowDrop = true;
			this._txtCommonTextBox_73.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_73.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_73.Location = new System.Drawing.Point(118, 37);
			this._txtCommonTextBox_73.MaxLength = 100;
			this._txtCommonTextBox_73.Name = "_txtCommonTextBox_73";
			// this._txtCommonTextBox_73.ShowButton = true;
			this._txtCommonTextBox_73.Size = new System.Drawing.Size(100, 19);
			this._txtCommonTextBox_73.TabIndex = 18;
			this._txtCommonTextBox_73.Text = "";
			// this.this._txtCommonTextBox_73.Watermark = "";
			// 
			// _lblCommon_70
			// 
			this._lblCommon_70.AllowDrop = true;
			this._lblCommon_70.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._lblCommon_70.Text = "Ticket Type";
			this._lblCommon_70.Location = new System.Drawing.Point(10, 40);
			this._lblCommon_70.Name = "_lblCommon_70";
			this._lblCommon_70.Size = new System.Drawing.Size(55, 13);
			this._lblCommon_70.TabIndex = 19;
			// 
			// _txtDisplayLabel_11
			// 
			this._txtDisplayLabel_11.AllowDrop = true;
			this._txtDisplayLabel_11.Location = new System.Drawing.Point(220, 37);
			this._txtDisplayLabel_11.Name = "_txtDisplayLabel_11";
			this._txtDisplayLabel_11.Size = new System.Drawing.Size(234, 19);
			this._txtDisplayLabel_11.TabIndex = 20;
			this._txtDisplayLabel_11.TabStop = false;
			// 
			// _txtDisplayLabel_12
			// 
			this._txtDisplayLabel_12.AllowDrop = true;
			this._txtDisplayLabel_12.Location = new System.Drawing.Point(220, 58);
			this._txtDisplayLabel_12.Name = "_txtDisplayLabel_12";
			this._txtDisplayLabel_12.Size = new System.Drawing.Size(234, 19);
			this._txtDisplayLabel_12.TabIndex = 21;
			this._txtDisplayLabel_12.TabStop = false;
			// 
			// frmPayBillingTypes
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.ClientSize = new System.Drawing.Size(484, 302);
			this.Controls.Add(this.tabBillingType);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			//this.Icon = (System.Drawing.Icon) resources.GetObject("frmPayBillingTypes.Icon");
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(334, 132);
			this.MaximizeBox = true;
			this.MinimizeBox = true;
			this.Name = "frmPayBillingTypes";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Billing Types";
			// this.Activated += new System.EventHandler(this.frmPayBillingTypes_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
			// this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
			//((System.ComponentModel.ISupportInitialize) this.tabBillingType).EndInit();
			this.tabBillingType.ResumeLayout(false);
			this._fraEmployeeInformation_1.ResumeLayout(false);
			this.Frame1.ResumeLayout(false);
			this.cmbMastersList.ResumeLayout(false);
			this.grdLeaveEarningDetails.ResumeLayout(false);
			this._fraEmployeeInformation_0.ResumeLayout(false);
			this._fraEmployeeInformation_4.ResumeLayout(false);
			this._fraEmployeeInformation_2.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		void ReLoadForm(bool addEvents)
		{
			InitializetxtDisplayLabel();
			InitializetxtCommonTextBox();
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
			this.txtDisplayLabel = new System.Windows.Forms.Label[16];
			this.txtDisplayLabel[15] = _txtDisplayLabel_15;
			this.txtDisplayLabel[9] = _txtDisplayLabel_9;
			this.txtDisplayLabel[11] = _txtDisplayLabel_11;
			this.txtDisplayLabel[12] = _txtDisplayLabel_12;
		}
		void InitializetxtCommonTextBox()
		{
			this.txtCommonTextBox = new System.Windows.Forms.TextBox[74];
			this.txtCommonTextBox[40] = _txtCommonTextBox_40;
			this.txtCommonTextBox[41] = _txtCommonTextBox_41;
			this.txtCommonTextBox[42] = _txtCommonTextBox_42;
			this.txtCommonTextBox[43] = _txtCommonTextBox_43;
			this.txtCommonTextBox[46] = _txtCommonTextBox_46;
			this.txtCommonTextBox[47] = _txtCommonTextBox_47;
			this.txtCommonTextBox[48] = _txtCommonTextBox_48;
			this.txtCommonTextBox[44] = _txtCommonTextBox_44;
			this.txtCommonTextBox[45] = _txtCommonTextBox_45;
			this.txtCommonTextBox[14] = _txtCommonTextBox_14;
			this.txtCommonTextBox[38] = _txtCommonTextBox_38;
			this.txtCommonTextBox[49] = _txtCommonTextBox_49;
			this.txtCommonTextBox[50] = _txtCommonTextBox_50;
			this.txtCommonTextBox[51] = _txtCommonTextBox_51;
			this.txtCommonTextBox[54] = _txtCommonTextBox_54;
			this.txtCommonTextBox[55] = _txtCommonTextBox_55;
			this.txtCommonTextBox[53] = _txtCommonTextBox_53;
			this.txtCommonTextBox[71] = _txtCommonTextBox_71;
			this.txtCommonTextBox[73] = _txtCommonTextBox_73;
		}
		void InitializelblCommon()
		{
			this.lblCommon = new System.Windows.Forms.Label[116];
			this.lblCommon[27] = _lblCommon_27;
			this.lblCommon[28] = _lblCommon_28;
			this.lblCommon[29] = _lblCommon_29;
			this.lblCommon[31] = _lblCommon_31;
			this.lblCommon[32] = _lblCommon_32;
			this.lblCommon[115] = _lblCommon_115;
			this.lblCommon[33] = _lblCommon_33;
			this.lblCommon[34] = _lblCommon_34;
			this.lblCommon[35] = _lblCommon_35;
			this.lblCommon[0] = _lblCommon_0;
			this.lblCommon[30] = _lblCommon_30;
			this.lblCommon[38] = _lblCommon_38;
			this.lblCommon[39] = _lblCommon_39;
			this.lblCommon[40] = _lblCommon_40;
			this.lblCommon[44] = _lblCommon_44;
			this.lblCommon[45] = _lblCommon_45;
			this.lblCommon[43] = _lblCommon_43;
			this.lblCommon[23] = _lblCommon_23;
			this.lblCommon[54] = _lblCommon_54;
			this.lblCommon[68] = _lblCommon_68;
			this.lblCommon[70] = _lblCommon_70;
		}
		void InitializefraEmployeeInformation()
		{
			this.fraEmployeeInformation = new System.Windows.Forms.Panel[5];
			this.fraEmployeeInformation[1] = _fraEmployeeInformation_1;
			this.fraEmployeeInformation[0] = _fraEmployeeInformation_0;
			this.fraEmployeeInformation[4] = _fraEmployeeInformation_4;
			this.fraEmployeeInformation[2] = _fraEmployeeInformation_2;
		}
		void InitializecmbCommon()
		{
			this.cmbCommon = new System.Windows.Forms.ComboBox[2];
			this.cmbCommon[0] = _cmbCommon_0;
			this.cmbCommon[1] = _cmbCommon_1;
		}
		void InitializeSystem.Windows.Forms.Label1()
		{
			this.System.Windows.Forms.Label1 = new System.Windows.Forms.Label[3];
			this.System.Windows.Forms.Label1[0] = _System.Windows.Forms.Label1_0;
			this.System.Windows.Forms.Label1[1] = _System.Windows.Forms.Label1_1;
			this.System.Windows.Forms.Label1[2] = _System.Windows.Forms.Label1_2;
		}
		#endregion
	}
}