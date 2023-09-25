
namespace Xtreme
{
	partial class frmSysUsers
	{

		#region "Upgrade Support "
		private static frmSysUsers m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmSysUsers DefInstance
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
		public static frmSysUsers CreateInstance()
		{
			frmSysUsers theInstance = new frmSysUsers();
			
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
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "chkDisable", "Column_0_cmbPriceList", "Column_1_cmbPriceList", "cmbPriceList", "Column_0_grdPriceDetails", "Column_1_grdPriceDetails", "grdPriceDetails", "_chkPriceRestriction_1", "_chkPriceRestriction_3", "_cmbPriceLevel_5", "_cmbPriceLevel_4", "_txtCommonNumber_3", "_cmbPriceLevel_1", "_lblCommon_22", "_lblCommon_27", "_lblCommon_28", "_lblCommon_31", "_lblCommon_32", "_txtCommonNumber_2", "fraPurchase", "_chkPriceRestriction_0", "_chkPriceRestriction_2", "_txtCommonNumber_1", "_txtCommonNumber_0", "_cmbPriceLevel_3", "_cmbPriceLevel_2", "_cmbPriceLevel_0", "_lblCommon_18", "_lblCommon_25", "_lblCommon_26", "_lblCommon_29", "_lblCommon_30", "fraSales", "_fraLedgerInformation_3", "chkMultipleLocationAccess", "chkAboveMaximumLevel", "chkBelowMinimumLevel", "chkBelowReorderLevel", "chkAllowFutureDateTransaction", "chkAllowSaleBelowCost", "chkAllowICSNegativeStock", "chkEnableAdvanceModeInICSBatchPosting", "chkEnablePayExpRepPop", "chkRestrictOnExceedingCreditLimit", "chkEnableCostDetails", "_lblCommon_6", "txtAddress2", "_lblCommon_7", "txtPhone", "_lblCommon_9", "txtProvidentFund", "_lblCommon_8", "txtComments", "_lblCommon_5", "txtAddress1", "lblPreferredLanguage", "_cmbCommon_0", "lblDefaultSmanNo", "txtDefaultSmanNo", "_fraLedgerInformation_0", "tabMaster", "_lblCommon_3", "_lblCommon_1", "txtUserName", "_lblCommon_2", "txtPassword", "txtConfirmPassword", "_lblCommon_4", "_lblCommon_0", "lblSystemComponents", "txtUserId", "comGroupName", "Line1", "fraMainInformation", "chkPriceRestriction", "cmbCommon", "cmbPriceLevel", "fraLedgerInformation", "lblCommon", "txtCommonNumber"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public System.Windows.Forms.CheckBox chkDisable;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_0_cmbPriceList;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_1_cmbPriceList;
		public C1.Win.C1TrueDBGrid.C1TrueDBDropdown cmbPriceList;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_0_grdPriceDetails;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_1_grdPriceDetails;
		public C1.Win.C1TrueDBGrid.C1TrueDBGrid grdPriceDetails;
		private System.Windows.Forms.CheckBox _chkPriceRestriction_1;
		private System.Windows.Forms.CheckBox _chkPriceRestriction_3;
		private System.Windows.Forms.ComboBox _cmbPriceLevel_5;
		private System.Windows.Forms.ComboBox _cmbPriceLevel_4;
		private System.Windows.Forms.TextBox _txtCommonNumber_3;
		private System.Windows.Forms.ComboBox _cmbPriceLevel_1;
		private System.Windows.Forms.Label _lblCommon_22;
		private System.Windows.Forms.Label _lblCommon_27;
		private System.Windows.Forms.Label _lblCommon_28;
		private System.Windows.Forms.Label _lblCommon_31;
		private System.Windows.Forms.Label _lblCommon_32;
		private System.Windows.Forms.TextBox _txtCommonNumber_2;
		public System.Windows.Forms.Panel fraPurchase;
		private System.Windows.Forms.CheckBox _chkPriceRestriction_0;
		private System.Windows.Forms.CheckBox _chkPriceRestriction_2;
		private System.Windows.Forms.TextBox _txtCommonNumber_1;
		private System.Windows.Forms.TextBox _txtCommonNumber_0;
		private System.Windows.Forms.ComboBox _cmbPriceLevel_3;
		private System.Windows.Forms.ComboBox _cmbPriceLevel_2;
		private System.Windows.Forms.ComboBox _cmbPriceLevel_0;
		private System.Windows.Forms.Label _lblCommon_18;
		private System.Windows.Forms.Label _lblCommon_25;
		private System.Windows.Forms.Label _lblCommon_26;
		private System.Windows.Forms.Label _lblCommon_29;
		private System.Windows.Forms.Label _lblCommon_30;
		public System.Windows.Forms.Panel fraSales;
		private System.Windows.Forms.Panel _fraLedgerInformation_3;
		public System.Windows.Forms.CheckBox chkMultipleLocationAccess;
		public System.Windows.Forms.CheckBox chkAboveMaximumLevel;
		public System.Windows.Forms.CheckBox chkBelowMinimumLevel;
		public System.Windows.Forms.CheckBox chkBelowReorderLevel;
		public System.Windows.Forms.CheckBox chkAllowFutureDateTransaction;
		public System.Windows.Forms.CheckBox chkAllowSaleBelowCost;
		public System.Windows.Forms.CheckBox chkAllowICSNegativeStock;
		public System.Windows.Forms.CheckBox chkEnableAdvanceModeInICSBatchPosting;
		public System.Windows.Forms.CheckBox chkEnablePayExpRepPop;
		public System.Windows.Forms.CheckBox chkRestrictOnExceedingCreditLimit;
		public System.Windows.Forms.CheckBox chkEnableCostDetails;
		private System.Windows.Forms.Label _lblCommon_6;
		public System.Windows.Forms.TextBox txtAddress2;
		private System.Windows.Forms.Label _lblCommon_7;
		public System.Windows.Forms.TextBox txtPhone;
		private System.Windows.Forms.Label _lblCommon_9;
		public System.Windows.Forms.TextBox txtProvidentFund;
		private System.Windows.Forms.Label _lblCommon_8;
		public System.Windows.Forms.TextBox txtComments;
		private System.Windows.Forms.Label _lblCommon_5;
		public System.Windows.Forms.TextBox txtAddress1;
		public System.Windows.Forms.Label lblPreferredLanguage;
		private System.Windows.Forms.ComboBox _cmbCommon_0;
		public System.Windows.Forms.Label lblDefaultSmanNo;
		public System.Windows.Forms.TextBox txtDefaultSmanNo;
		private System.Windows.Forms.Panel _fraLedgerInformation_0;
		public AxC1SizerLib.AxC1Tab tabMaster;
		private System.Windows.Forms.Label _lblCommon_3;
		private System.Windows.Forms.Label _lblCommon_1;
		public System.Windows.Forms.TextBox txtUserName;
		private System.Windows.Forms.Label _lblCommon_2;
		public System.Windows.Forms.TextBox txtPassword;
		public System.Windows.Forms.TextBox txtConfirmPassword;
		private System.Windows.Forms.Label _lblCommon_4;
		private System.Windows.Forms.Label _lblCommon_0;
		public System.Windows.Forms.Label lblSystemComponents;
		public System.Windows.Forms.TextBox txtUserId;
		public System.Windows.Forms.ComboBox comGroupName;
		public System.Windows.Forms.Label Line1;
		public System.Windows.Forms.Panel fraMainInformation;
		public System.Windows.Forms.CheckBox[] chkPriceRestriction = new System.Windows.Forms.CheckBox[4];
		public System.Windows.Forms.ComboBox[] cmbCommon = new System.Windows.Forms.ComboBox[1];
		public System.Windows.Forms.ComboBox[] cmbPriceLevel = new System.Windows.Forms.ComboBox[6];
		public System.Windows.Forms.Panel[] fraLedgerInformation = new System.Windows.Forms.Panel[4];
		public System.Windows.Forms.Label[] lblCommon = new System.Windows.Forms.Label[33];
		public System.Windows.Forms.TextBox[] txtCommonNumber = new System.Windows.Forms.TextBox[4];
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSysUsers));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this.fraMainInformation = new System.Windows.Forms.Panel();
			this.chkDisable = new System.Windows.Forms.CheckBox();
			this.tabMaster = new AxC1SizerLib.AxC1Tab();
			this._fraLedgerInformation_3 = new System.Windows.Forms.Panel();
			this.cmbPriceList = new C1.Win.C1TrueDBGrid.C1TrueDBDropdown();
			this.Column_0_cmbPriceList = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.Column_1_cmbPriceList = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.grdPriceDetails = new C1.Win.C1TrueDBGrid.C1TrueDBGrid();
			this.Column_0_grdPriceDetails = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.Column_1_grdPriceDetails = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.fraPurchase = new System.Windows.Forms.Panel();
			this._chkPriceRestriction_1 = new System.Windows.Forms.CheckBox();
			this._chkPriceRestriction_3 = new System.Windows.Forms.CheckBox();
			this._cmbPriceLevel_5 = new System.Windows.Forms.ComboBox();
			this._cmbPriceLevel_4 = new System.Windows.Forms.ComboBox();
			this._txtCommonNumber_3 = new System.Windows.Forms.TextBox();
			this._cmbPriceLevel_1 = new System.Windows.Forms.ComboBox();
			this._lblCommon_22 = new System.Windows.Forms.Label();
			this._lblCommon_27 = new System.Windows.Forms.Label();
			this._lblCommon_28 = new System.Windows.Forms.Label();
			this._lblCommon_31 = new System.Windows.Forms.Label();
			this._lblCommon_32 = new System.Windows.Forms.Label();
			this._txtCommonNumber_2 = new System.Windows.Forms.TextBox();
			this.fraSales = new System.Windows.Forms.Panel();
			this._chkPriceRestriction_0 = new System.Windows.Forms.CheckBox();
			this._chkPriceRestriction_2 = new System.Windows.Forms.CheckBox();
			this._txtCommonNumber_1 = new System.Windows.Forms.TextBox();
			this._txtCommonNumber_0 = new System.Windows.Forms.TextBox();
			this._cmbPriceLevel_3 = new System.Windows.Forms.ComboBox();
			this._cmbPriceLevel_2 = new System.Windows.Forms.ComboBox();
			this._cmbPriceLevel_0 = new System.Windows.Forms.ComboBox();
			this._lblCommon_18 = new System.Windows.Forms.Label();
			this._lblCommon_25 = new System.Windows.Forms.Label();
			this._lblCommon_26 = new System.Windows.Forms.Label();
			this._lblCommon_29 = new System.Windows.Forms.Label();
			this._lblCommon_30 = new System.Windows.Forms.Label();
			this._fraLedgerInformation_0 = new System.Windows.Forms.Panel();
			this.chkMultipleLocationAccess = new System.Windows.Forms.CheckBox();
			this.chkAboveMaximumLevel = new System.Windows.Forms.CheckBox();
			this.chkBelowMinimumLevel = new System.Windows.Forms.CheckBox();
			this.chkBelowReorderLevel = new System.Windows.Forms.CheckBox();
			this.chkAllowFutureDateTransaction = new System.Windows.Forms.CheckBox();
			this.chkAllowSaleBelowCost = new System.Windows.Forms.CheckBox();
			this.chkAllowICSNegativeStock = new System.Windows.Forms.CheckBox();
			this.chkEnableAdvanceModeInICSBatchPosting = new System.Windows.Forms.CheckBox();
			this.chkEnablePayExpRepPop = new System.Windows.Forms.CheckBox();
			this.chkRestrictOnExceedingCreditLimit = new System.Windows.Forms.CheckBox();
			this.chkEnableCostDetails = new System.Windows.Forms.CheckBox();
			this._lblCommon_6 = new System.Windows.Forms.Label();
			this.txtAddress2 = new System.Windows.Forms.TextBox();
			this._lblCommon_7 = new System.Windows.Forms.Label();
			this.txtPhone = new System.Windows.Forms.TextBox();
			this._lblCommon_9 = new System.Windows.Forms.Label();
			this.txtProvidentFund = new System.Windows.Forms.TextBox();
			this._lblCommon_8 = new System.Windows.Forms.Label();
			this.txtComments = new System.Windows.Forms.TextBox();
			this._lblCommon_5 = new System.Windows.Forms.Label();
			this.txtAddress1 = new System.Windows.Forms.TextBox();
			this.lblPreferredLanguage = new System.Windows.Forms.Label();
			this._cmbCommon_0 = new System.Windows.Forms.ComboBox();
			this.lblDefaultSmanNo = new System.Windows.Forms.Label();
			this.txtDefaultSmanNo = new System.Windows.Forms.TextBox();
			this._lblCommon_3 = new System.Windows.Forms.Label();
			this._lblCommon_1 = new System.Windows.Forms.Label();
			this.txtUserName = new System.Windows.Forms.TextBox();
			this._lblCommon_2 = new System.Windows.Forms.Label();
			this.txtPassword = new System.Windows.Forms.TextBox();
			this.txtConfirmPassword = new System.Windows.Forms.TextBox();
			this._lblCommon_4 = new System.Windows.Forms.Label();
			this._lblCommon_0 = new System.Windows.Forms.Label();
			this.lblSystemComponents = new System.Windows.Forms.Label();
			this.txtUserId = new System.Windows.Forms.TextBox();
			this.comGroupName = new System.Windows.Forms.ComboBox();
			this.Line1 = new System.Windows.Forms.Label();
			// //((System.ComponentModel.ISupportInitialize) this.tabMaster).BeginInit();
			// //((System.ComponentModel.ISupportInitialize) this.fraMainInformation).BeginInit();
			this.fraMainInformation.SuspendLayout();
			this.tabMaster.SuspendLayout();
			this._fraLedgerInformation_3.SuspendLayout();
			this.cmbPriceList.SuspendLayout();
			this.grdPriceDetails.SuspendLayout();
			this.fraPurchase.SuspendLayout();
			this.fraSales.SuspendLayout();
			this._fraLedgerInformation_0.SuspendLayout();
			this.SuspendLayout();
			// 
			// fraMainInformation
			// 
			this.fraMainInformation.AllowDrop = true;
			this.fraMainInformation.Controls.Add(this.chkDisable);
			this.fraMainInformation.Controls.Add(this.tabMaster);
			this.fraMainInformation.Controls.Add(this._lblCommon_3);
			this.fraMainInformation.Controls.Add(this._lblCommon_1);
			this.fraMainInformation.Controls.Add(this.txtUserName);
			this.fraMainInformation.Controls.Add(this._lblCommon_2);
			this.fraMainInformation.Controls.Add(this.txtPassword);
			this.fraMainInformation.Controls.Add(this.txtConfirmPassword);
			this.fraMainInformation.Controls.Add(this._lblCommon_4);
			this.fraMainInformation.Controls.Add(this._lblCommon_0);
			this.fraMainInformation.Controls.Add(this.lblSystemComponents);
			this.fraMainInformation.Controls.Add(this.txtUserId);
			this.fraMainInformation.Controls.Add(this.comGroupName);
			this.fraMainInformation.Controls.Add(this.Line1);
			this.fraMainInformation.Location = new System.Drawing.Point(10, 10);
			this.fraMainInformation.Name = "fraMainInformation";
			//
			this.fraMainInformation.Size = new System.Drawing.Size(663, 359);
			this.fraMainInformation.TabIndex = 27;
			// 
			// chkDisable
			// 
			this.chkDisable.AllowDrop = true;
			this.chkDisable.Appearance = System.Windows.Forms.Appearance.Normal;
			this.chkDisable.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this.chkDisable.CausesValidation = true;
			this.chkDisable.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkDisable.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this.chkDisable.Enabled = true;
			this.chkDisable.ForeColor = System.Drawing.SystemColors.ControlText;
			this.chkDisable.Location = new System.Drawing.Point(591, 75);
			this.chkDisable.Name = "chkDisable";
			this.chkDisable.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.chkDisable.Size = new System.Drawing.Size(59, 17);
			this.chkDisable.TabIndex = 57;
			this.chkDisable.TabStop = true;
			this.chkDisable.Text = "Disable";
			this.chkDisable.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkDisable.Visible = true;
			// 
			// tabMaster
			// 
			this.tabMaster.Align = C1SizerLib.AlignSettings.asNone;
			this.tabMaster.AllowDrop = true;
			this.tabMaster.Controls.Add(this._fraLedgerInformation_3);
			this.tabMaster.Controls.Add(this._fraLedgerInformation_0);
			this.tabMaster.Location = new System.Drawing.Point(8, 122);
			this.tabMaster.Name = "tabMaster";
			//
			this.tabMaster.Size = new System.Drawing.Size(642, 227);
			this.tabMaster.TabIndex = 34;
			this.tabMaster.TabStop = false;
			//// this.tabMaster.ClickEvent += new System.EventHandler(this.tabMaster_ClickEvent);
			// 
			// _fraLedgerInformation_3
			// 
			this._fraLedgerInformation_3.AllowDrop = true;
			this._fraLedgerInformation_3.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._fraLedgerInformation_3.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._fraLedgerInformation_3.Controls.Add(this.cmbPriceList);
			this._fraLedgerInformation_3.Controls.Add(this.grdPriceDetails);
			this._fraLedgerInformation_3.Controls.Add(this.fraPurchase);
			this._fraLedgerInformation_3.Controls.Add(this.fraSales);
			this._fraLedgerInformation_3.Enabled = true;
			this._fraLedgerInformation_3.ForeColor = System.Drawing.SystemColors.WindowText;
			this._fraLedgerInformation_3.Location = new System.Drawing.Point(683, 23);
			this._fraLedgerInformation_3.Name = "_fraLedgerInformation_3";
			this._fraLedgerInformation_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._fraLedgerInformation_3.Size = new System.Drawing.Size(640, 203);
			this._fraLedgerInformation_3.TabIndex = 41;
			this._fraLedgerInformation_3.Text = "Frame2";
			this._fraLedgerInformation_3.Visible = true;
			// 
			// cmbPriceList
			// 
			this.cmbPriceList.AllowDrop = true;
			this.cmbPriceList.ColumnHeaders = true;
			this.cmbPriceList.Enabled = true;
			this.cmbPriceList.Location = new System.Drawing.Point(12, 90);
			this.cmbPriceList.Name = "cmbPriceList";
			this.cmbPriceList.Size = new System.Drawing.Size(225, 105);
			this.cmbPriceList.TabIndex = 63;
			this.cmbPriceList.Columns.Add(this.Column_0_cmbPriceList);
			this.cmbPriceList.Columns.Add(this.Column_1_cmbPriceList);
			// 
			// Column_0_cmbPriceList
			// 
			this.Column_0_cmbPriceList.DataField = "";
			this.Column_0_cmbPriceList.ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.Normal;
			// 
			// Column_1_cmbPriceList
			// 
			this.Column_1_cmbPriceList.DataField = "";
			this.Column_1_cmbPriceList.ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.Normal;
			// 
			// grdPriceDetails
			// 
			this.grdPriceDetails.AllowDrop = true;
			this.grdPriceDetails.BackColor = System.Drawing.Color.Silver;
			this.grdPriceDetails.CellTipsWidth = 0;
			this.grdPriceDetails.Location = new System.Drawing.Point(8, 74);
			this.grdPriceDetails.Name = "grdPriceDetails";
			this.grdPriceDetails.RowDivider.Color = System.Drawing.Color.Silver;
			this.grdPriceDetails.Size = new System.Drawing.Size(625, 124);
			this.grdPriceDetails.TabIndex = 64;
			this.grdPriceDetails.Columns.Add(this.Column_0_grdPriceDetails);
			this.grdPriceDetails.Columns.Add(this.Column_1_grdPriceDetails);
			this.grdPriceDetails.AfterColUpdate += new C1.Win.C1TrueDBGrid.ColEventHandler(this.grdPriceDetails_AfterColUpdate);
			this.grdPriceDetails.GotFocus += new System.EventHandler(this.grdPriceDetails_GotFocus);
			this.grdPriceDetails.RowColChange += new C1.Win.C1TrueDBGrid.RowColChangeEventHandler(this.grdPriceDetails_RowColChange);
			// 
			// Column_0_grdPriceDetails
			// 
			this.Column_0_grdPriceDetails.DataField = "";
			this.Column_0_grdPriceDetails.ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.Normal;
			// 
			// Column_1_grdPriceDetails
			// 
			this.Column_1_grdPriceDetails.DataField = "";
			this.Column_1_grdPriceDetails.ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.Normal;
			// 
			// fraPurchase
			// 
			this.fraPurchase.AllowDrop = true;
			this.fraPurchase.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this.fraPurchase.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.fraPurchase.Controls.Add(this._chkPriceRestriction_1);
			this.fraPurchase.Controls.Add(this._chkPriceRestriction_3);
			this.fraPurchase.Controls.Add(this._cmbPriceLevel_5);
			this.fraPurchase.Controls.Add(this._cmbPriceLevel_4);
			this.fraPurchase.Controls.Add(this._txtCommonNumber_3);
			this.fraPurchase.Controls.Add(this._cmbPriceLevel_1);
			this.fraPurchase.Controls.Add(this._lblCommon_22);
			this.fraPurchase.Controls.Add(this._lblCommon_27);
			this.fraPurchase.Controls.Add(this._lblCommon_28);
			this.fraPurchase.Controls.Add(this._lblCommon_31);
			this.fraPurchase.Controls.Add(this._lblCommon_32);
			this.fraPurchase.Controls.Add(this._txtCommonNumber_2);
			this.fraPurchase.Enabled = true;
			this.fraPurchase.ForeColor = System.Drawing.SystemColors.ControlText;
			this.fraPurchase.Location = new System.Drawing.Point(324, 4);
			this.fraPurchase.Name = "fraPurchase";
			this.fraPurchase.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.fraPurchase.Size = new System.Drawing.Size(313, 41);
			this.fraPurchase.TabIndex = 48;
			this.fraPurchase.Visible = true;
			// 
			// _chkPriceRestriction_1
			// 
			this._chkPriceRestriction_1.AllowDrop = true;
			this._chkPriceRestriction_1.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkPriceRestriction_1.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._chkPriceRestriction_1.CausesValidation = true;
			this._chkPriceRestriction_1.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkPriceRestriction_1.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkPriceRestriction_1.Enabled = true;
			this._chkPriceRestriction_1.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkPriceRestriction_1.Location = new System.Drawing.Point(8, 42);
			this._chkPriceRestriction_1.Name = "_chkPriceRestriction_1";
			this._chkPriceRestriction_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkPriceRestriction_1.Size = new System.Drawing.Size(187, 21);
			this._chkPriceRestriction_1.TabIndex = 21;
			this._chkPriceRestriction_1.TabStop = true;
			this._chkPriceRestriction_1.Text = "Enable Purchase Price Restrictions";
			this._chkPriceRestriction_1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkPriceRestriction_1.Visible = true;
			// 
			// _chkPriceRestriction_3
			// 
			this._chkPriceRestriction_3.AllowDrop = true;
			this._chkPriceRestriction_3.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkPriceRestriction_3.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._chkPriceRestriction_3.CausesValidation = true;
			this._chkPriceRestriction_3.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkPriceRestriction_3.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkPriceRestriction_3.Enabled = true;
			this._chkPriceRestriction_3.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkPriceRestriction_3.Location = new System.Drawing.Point(8, 62);
			this._chkPriceRestriction_3.Name = "_chkPriceRestriction_3";
			this._chkPriceRestriction_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkPriceRestriction_3.Size = new System.Drawing.Size(180, 21);
			this._chkPriceRestriction_3.TabIndex = 22;
			this._chkPriceRestriction_3.TabStop = true;
			this._chkPriceRestriction_3.Text = "Restrict In Purchase Price Levels";
			this._chkPriceRestriction_3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkPriceRestriction_3.Visible = true;
			// 
			// _cmbPriceLevel_5
			// 
			this._cmbPriceLevel_5.AllowDrop = true;
			this._cmbPriceLevel_5.Location = new System.Drawing.Point(133, 106);
			this._cmbPriceLevel_5.Name = "_cmbPriceLevel_5";
			this._cmbPriceLevel_5.Size = new System.Drawing.Size(173, 21);
			this._cmbPriceLevel_5.TabIndex = 24;
			// 
			// _cmbPriceLevel_4
			// 
			this._cmbPriceLevel_4.AllowDrop = true;
			this._cmbPriceLevel_4.Location = new System.Drawing.Point(133, 87);
			this._cmbPriceLevel_4.Name = "_cmbPriceLevel_4";
			this._cmbPriceLevel_4.Size = new System.Drawing.Size(173, 21);
			this._cmbPriceLevel_4.TabIndex = 23;
			// 
			// _txtCommonNumber_3
			// 
			this._txtCommonNumber_3.AllowDrop = true;
			this._txtCommonNumber_3.Location = new System.Drawing.Point(133, 152);
			// this._txtCommonNumber_3.MaxValue = 2147483647;
			// this._txtCommonNumber_3.MinValue = 0;
			this._txtCommonNumber_3.Name = "_txtCommonNumber_3";
			this._txtCommonNumber_3.Size = new System.Drawing.Size(101, 19);
			this._txtCommonNumber_3.TabIndex = 26;
			// 
			// _cmbPriceLevel_1
			// 
			this._cmbPriceLevel_1.AllowDrop = true;
			this._cmbPriceLevel_1.Location = new System.Drawing.Point(133, 10);
			this._cmbPriceLevel_1.Name = "_cmbPriceLevel_1";
			this._cmbPriceLevel_1.Size = new System.Drawing.Size(173, 21);
			this._cmbPriceLevel_1.TabIndex = 20;
			// 
			// _lblCommon_22
			// 
			this._lblCommon_22.AllowDrop = true;
			this._lblCommon_22.BackColor = System.Drawing.SystemColors.Window;
			this._lblCommon_22.Text = "Default Purchase Price";
			this._lblCommon_22.Location = new System.Drawing.Point(8, 13);
			this._lblCommon_22.Name = "_lblCommon_22";
			this._lblCommon_22.Size = new System.Drawing.Size(110, 14);
			this._lblCommon_22.TabIndex = 49;
			// 
			// _lblCommon_27
			// 
			this._lblCommon_27.AllowDrop = true;
			this._lblCommon_27.BackColor = System.Drawing.SystemColors.Window;
			this._lblCommon_27.Text = "Max Purchase Price";
			this._lblCommon_27.Location = new System.Drawing.Point(22, 90);
			this._lblCommon_27.Name = "_lblCommon_27";
			this._lblCommon_27.Size = new System.Drawing.Size(96, 14);
			this._lblCommon_27.TabIndex = 50;
			// 
			// _lblCommon_28
			// 
			this._lblCommon_28.AllowDrop = true;
			this._lblCommon_28.BackColor = System.Drawing.SystemColors.Window;
			this._lblCommon_28.Text = "Min Purchase Price";
			this._lblCommon_28.Location = new System.Drawing.Point(26, 109);
			this._lblCommon_28.Name = "_lblCommon_28";
			this._lblCommon_28.Size = new System.Drawing.Size(92, 14);
			this._lblCommon_28.TabIndex = 51;
			// 
			// _lblCommon_31
			// 
			this._lblCommon_31.AllowDrop = true;
			this._lblCommon_31.BackColor = System.Drawing.SystemColors.Window;
			this._lblCommon_31.Text = "Max Product Dis. (%)";
			this._lblCommon_31.Location = new System.Drawing.Point(16, 137);
			this._lblCommon_31.Name = "_lblCommon_31";
			this._lblCommon_31.Size = new System.Drawing.Size(102, 14);
			this._lblCommon_31.TabIndex = 52;
			this._lblCommon_31.Visible = false;
			// 
			// _lblCommon_32
			// 
			this._lblCommon_32.AllowDrop = true;
			this._lblCommon_32.BackColor = System.Drawing.SystemColors.Window;
			this._lblCommon_32.Text = "Max Voucher Dis. (%)";
			this._lblCommon_32.Location = new System.Drawing.Point(11, 154);
			this._lblCommon_32.Name = "_lblCommon_32";
			this._lblCommon_32.Size = new System.Drawing.Size(107, 14);
			this._lblCommon_32.TabIndex = 53;
			// 
			// _txtCommonNumber_2
			// 
			this._txtCommonNumber_2.AllowDrop = true;
			this._txtCommonNumber_2.Location = new System.Drawing.Point(133, 135);
			// this._txtCommonNumber_2.MaxValue = 2147483647;
			// this._txtCommonNumber_2.MinValue = 0;
			this._txtCommonNumber_2.Name = "_txtCommonNumber_2";
			this._txtCommonNumber_2.Size = new System.Drawing.Size(101, 19);
			this._txtCommonNumber_2.TabIndex = 25;
			this._txtCommonNumber_2.Visible = false;
			// 
			// fraSales
			// 
			this.fraSales.AllowDrop = true;
			this.fraSales.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this.fraSales.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.fraSales.Controls.Add(this._chkPriceRestriction_0);
			this.fraSales.Controls.Add(this._chkPriceRestriction_2);
			this.fraSales.Controls.Add(this._txtCommonNumber_1);
			this.fraSales.Controls.Add(this._txtCommonNumber_0);
			this.fraSales.Controls.Add(this._cmbPriceLevel_3);
			this.fraSales.Controls.Add(this._cmbPriceLevel_2);
			this.fraSales.Controls.Add(this._cmbPriceLevel_0);
			this.fraSales.Controls.Add(this._lblCommon_18);
			this.fraSales.Controls.Add(this._lblCommon_25);
			this.fraSales.Controls.Add(this._lblCommon_26);
			this.fraSales.Controls.Add(this._lblCommon_29);
			this.fraSales.Controls.Add(this._lblCommon_30);
			this.fraSales.Enabled = true;
			this.fraSales.ForeColor = System.Drawing.SystemColors.ControlText;
			this.fraSales.Location = new System.Drawing.Point(6, 4);
			this.fraSales.Name = "fraSales";
			this.fraSales.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.fraSales.Size = new System.Drawing.Size(313, 65);
			this.fraSales.TabIndex = 42;
			this.fraSales.Visible = true;
			// 
			// _chkPriceRestriction_0
			// 
			this._chkPriceRestriction_0.AllowDrop = true;
			this._chkPriceRestriction_0.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkPriceRestriction_0.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._chkPriceRestriction_0.CausesValidation = true;
			this._chkPriceRestriction_0.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkPriceRestriction_0.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkPriceRestriction_0.Enabled = true;
			this._chkPriceRestriction_0.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkPriceRestriction_0.Location = new System.Drawing.Point(8, 42);
			this._chkPriceRestriction_0.Name = "_chkPriceRestriction_0";
			this._chkPriceRestriction_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkPriceRestriction_0.Size = new System.Drawing.Size(180, 21);
			this._chkPriceRestriction_0.TabIndex = 14;
			this._chkPriceRestriction_0.TabStop = true;
			this._chkPriceRestriction_0.Text = "Enable Sales Price Restrictions";
			this._chkPriceRestriction_0.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkPriceRestriction_0.Visible = true;
			// 
			// _chkPriceRestriction_2
			// 
			this._chkPriceRestriction_2.AllowDrop = true;
			this._chkPriceRestriction_2.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkPriceRestriction_2.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._chkPriceRestriction_2.CausesValidation = true;
			this._chkPriceRestriction_2.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkPriceRestriction_2.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkPriceRestriction_2.Enabled = true;
			this._chkPriceRestriction_2.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkPriceRestriction_2.Location = new System.Drawing.Point(8, 62);
			this._chkPriceRestriction_2.Name = "_chkPriceRestriction_2";
			this._chkPriceRestriction_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkPriceRestriction_2.Size = new System.Drawing.Size(180, 21);
			this._chkPriceRestriction_2.TabIndex = 15;
			this._chkPriceRestriction_2.TabStop = true;
			this._chkPriceRestriction_2.Text = "Restrict In Sales Price Levels";
			this._chkPriceRestriction_2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkPriceRestriction_2.Visible = true;
			// 
			// _txtCommonNumber_1
			// 
			this._txtCommonNumber_1.AllowDrop = true;
			this._txtCommonNumber_1.Location = new System.Drawing.Point(131, 152);
			// this._txtCommonNumber_1.MaxValue = 2147483647;
			// this._txtCommonNumber_1.MinValue = 0;
			this._txtCommonNumber_1.Name = "_txtCommonNumber_1";
			this._txtCommonNumber_1.Size = new System.Drawing.Size(101, 19);
			this._txtCommonNumber_1.TabIndex = 19;
			// 
			// _txtCommonNumber_0
			// 
			this._txtCommonNumber_0.AllowDrop = true;
			this._txtCommonNumber_0.Location = new System.Drawing.Point(131, 135);
			// this._txtCommonNumber_0.MaxValue = 2147483647;
			// this._txtCommonNumber_0.MinValue = 0;
			this._txtCommonNumber_0.Name = "_txtCommonNumber_0";
			this._txtCommonNumber_0.Size = new System.Drawing.Size(101, 19);
			this._txtCommonNumber_0.TabIndex = 18;
			this._txtCommonNumber_0.Visible = false;
			// 
			// _cmbPriceLevel_3
			// 
			this._cmbPriceLevel_3.AllowDrop = true;
			this._cmbPriceLevel_3.Location = new System.Drawing.Point(131, 106);
			this._cmbPriceLevel_3.Name = "_cmbPriceLevel_3";
			this._cmbPriceLevel_3.Size = new System.Drawing.Size(173, 21);
			this._cmbPriceLevel_3.TabIndex = 17;
			// 
			// _cmbPriceLevel_2
			// 
			this._cmbPriceLevel_2.AllowDrop = true;
			this._cmbPriceLevel_2.Location = new System.Drawing.Point(131, 87);
			this._cmbPriceLevel_2.Name = "_cmbPriceLevel_2";
			this._cmbPriceLevel_2.Size = new System.Drawing.Size(173, 21);
			this._cmbPriceLevel_2.TabIndex = 16;
			// 
			// _cmbPriceLevel_0
			// 
			this._cmbPriceLevel_0.AllowDrop = true;
			this._cmbPriceLevel_0.Location = new System.Drawing.Point(131, 10);
			this._cmbPriceLevel_0.Name = "_cmbPriceLevel_0";
			this._cmbPriceLevel_0.Size = new System.Drawing.Size(173, 21);
			this._cmbPriceLevel_0.TabIndex = 13;
			// 
			// _lblCommon_18
			// 
			this._lblCommon_18.AllowDrop = true;
			this._lblCommon_18.BackColor = System.Drawing.SystemColors.Window;
			this._lblCommon_18.Text = "Default Sales Price";
			this._lblCommon_18.Location = new System.Drawing.Point(8, 13);
			this._lblCommon_18.Name = "_lblCommon_18";
			this._lblCommon_18.Size = new System.Drawing.Size(91, 14);
			this._lblCommon_18.TabIndex = 43;
			// 
			// _lblCommon_25
			// 
			this._lblCommon_25.AllowDrop = true;
			this._lblCommon_25.BackColor = System.Drawing.SystemColors.Window;
			this._lblCommon_25.Text = "Max Sales Price";
			this._lblCommon_25.Location = new System.Drawing.Point(14, 90);
			this._lblCommon_25.Name = "_lblCommon_25";
			this._lblCommon_25.Size = new System.Drawing.Size(77, 14);
			this._lblCommon_25.TabIndex = 44;
			// 
			// _lblCommon_26
			// 
			this._lblCommon_26.AllowDrop = true;
			this._lblCommon_26.BackColor = System.Drawing.SystemColors.Window;
			this._lblCommon_26.Text = "Min Sales Price";
			this._lblCommon_26.Location = new System.Drawing.Point(14, 109);
			this._lblCommon_26.Name = "_lblCommon_26";
			this._lblCommon_26.Size = new System.Drawing.Size(73, 14);
			this._lblCommon_26.TabIndex = 45;
			// 
			// _lblCommon_29
			// 
			this._lblCommon_29.AllowDrop = true;
			this._lblCommon_29.BackColor = System.Drawing.SystemColors.Window;
			this._lblCommon_29.Text = "Max Product Dis. (%)";
			this._lblCommon_29.Location = new System.Drawing.Point(14, 137);
			this._lblCommon_29.Name = "_lblCommon_29";
			this._lblCommon_29.Size = new System.Drawing.Size(102, 14);
			this._lblCommon_29.TabIndex = 46;
			this._lblCommon_29.Visible = false;
			// 
			// _lblCommon_30
			// 
			this._lblCommon_30.AllowDrop = true;
			this._lblCommon_30.BackColor = System.Drawing.SystemColors.Window;
			this._lblCommon_30.Text = "Max Voucher Dis. (%)";
			this._lblCommon_30.Location = new System.Drawing.Point(14, 154);
			this._lblCommon_30.Name = "_lblCommon_30";
			this._lblCommon_30.Size = new System.Drawing.Size(107, 14);
			this._lblCommon_30.TabIndex = 47;
			// 
			// _fraLedgerInformation_0
			// 
			this._fraLedgerInformation_0.AllowDrop = true;
			this._fraLedgerInformation_0.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._fraLedgerInformation_0.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._fraLedgerInformation_0.Controls.Add(this.chkMultipleLocationAccess);
			this._fraLedgerInformation_0.Controls.Add(this.chkAboveMaximumLevel);
			this._fraLedgerInformation_0.Controls.Add(this.chkBelowMinimumLevel);
			this._fraLedgerInformation_0.Controls.Add(this.chkBelowReorderLevel);
			this._fraLedgerInformation_0.Controls.Add(this.chkAllowFutureDateTransaction);
			this._fraLedgerInformation_0.Controls.Add(this.chkAllowSaleBelowCost);
			this._fraLedgerInformation_0.Controls.Add(this.chkAllowICSNegativeStock);
			this._fraLedgerInformation_0.Controls.Add(this.chkEnableAdvanceModeInICSBatchPosting);
			this._fraLedgerInformation_0.Controls.Add(this.chkEnablePayExpRepPop);
			this._fraLedgerInformation_0.Controls.Add(this.chkRestrictOnExceedingCreditLimit);
			this._fraLedgerInformation_0.Controls.Add(this.chkEnableCostDetails);
			this._fraLedgerInformation_0.Controls.Add(this._lblCommon_6);
			this._fraLedgerInformation_0.Controls.Add(this.txtAddress2);
			this._fraLedgerInformation_0.Controls.Add(this._lblCommon_7);
			this._fraLedgerInformation_0.Controls.Add(this.txtPhone);
			this._fraLedgerInformation_0.Controls.Add(this._lblCommon_9);
			this._fraLedgerInformation_0.Controls.Add(this.txtProvidentFund);
			this._fraLedgerInformation_0.Controls.Add(this._lblCommon_8);
			this._fraLedgerInformation_0.Controls.Add(this.txtComments);
			this._fraLedgerInformation_0.Controls.Add(this._lblCommon_5);
			this._fraLedgerInformation_0.Controls.Add(this.txtAddress1);
			this._fraLedgerInformation_0.Controls.Add(this.lblPreferredLanguage);
			this._fraLedgerInformation_0.Controls.Add(this._cmbCommon_0);
			this._fraLedgerInformation_0.Controls.Add(this.lblDefaultSmanNo);
			this._fraLedgerInformation_0.Controls.Add(this.txtDefaultSmanNo);
			this._fraLedgerInformation_0.Enabled = true;
			this._fraLedgerInformation_0.ForeColor = System.Drawing.SystemColors.WindowText;
			this._fraLedgerInformation_0.Location = new System.Drawing.Point(1, 23);
			this._fraLedgerInformation_0.Name = "_fraLedgerInformation_0";
			this._fraLedgerInformation_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._fraLedgerInformation_0.Size = new System.Drawing.Size(640, 203);
			this._fraLedgerInformation_0.TabIndex = 35;
			this._fraLedgerInformation_0.Text = "Restrict On Exceeding Credit Limit";
			this._fraLedgerInformation_0.Visible = true;
			// 
			// chkMultipleLocationAccess
			// 
			this.chkMultipleLocationAccess.AllowDrop = true;
			this.chkMultipleLocationAccess.Appearance = System.Windows.Forms.Appearance.Normal;
			this.chkMultipleLocationAccess.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this.chkMultipleLocationAccess.CausesValidation = true;
			this.chkMultipleLocationAccess.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkMultipleLocationAccess.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this.chkMultipleLocationAccess.Enabled = true;
			this.chkMultipleLocationAccess.ForeColor = System.Drawing.SystemColors.ControlText;
			this.chkMultipleLocationAccess.Location = new System.Drawing.Point(406, 164);
			this.chkMultipleLocationAccess.Name = "chkMultipleLocationAccess";
			this.chkMultipleLocationAccess.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.chkMultipleLocationAccess.Size = new System.Drawing.Size(225, 13);
			this.chkMultipleLocationAccess.TabIndex = 68;
			this.chkMultipleLocationAccess.TabStop = true;
			this.chkMultipleLocationAccess.Text = "Multiple Location Access";
			this.chkMultipleLocationAccess.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkMultipleLocationAccess.Visible = true;
			// 
			// chkAboveMaximumLevel
			// 
			this.chkAboveMaximumLevel.AllowDrop = true;
			this.chkAboveMaximumLevel.Appearance = System.Windows.Forms.Appearance.Normal;
			this.chkAboveMaximumLevel.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this.chkAboveMaximumLevel.CausesValidation = true;
			this.chkAboveMaximumLevel.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkAboveMaximumLevel.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this.chkAboveMaximumLevel.Enabled = true;
			this.chkAboveMaximumLevel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.chkAboveMaximumLevel.Location = new System.Drawing.Point(406, 148);
			this.chkAboveMaximumLevel.Name = "chkAboveMaximumLevel";
			this.chkAboveMaximumLevel.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.chkAboveMaximumLevel.Size = new System.Drawing.Size(225, 13);
			this.chkAboveMaximumLevel.TabIndex = 67;
			this.chkAboveMaximumLevel.TabStop = true;
			this.chkAboveMaximumLevel.Text = "Show Message On Above Maximum Level";
			this.chkAboveMaximumLevel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkAboveMaximumLevel.Visible = true;
			// 
			// chkBelowMinimumLevel
			// 
			this.chkBelowMinimumLevel.AllowDrop = true;
			this.chkBelowMinimumLevel.Appearance = System.Windows.Forms.Appearance.Normal;
			this.chkBelowMinimumLevel.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this.chkBelowMinimumLevel.CausesValidation = true;
			this.chkBelowMinimumLevel.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkBelowMinimumLevel.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this.chkBelowMinimumLevel.Enabled = true;
			this.chkBelowMinimumLevel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.chkBelowMinimumLevel.Location = new System.Drawing.Point(406, 132);
			this.chkBelowMinimumLevel.Name = "chkBelowMinimumLevel";
			this.chkBelowMinimumLevel.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.chkBelowMinimumLevel.Size = new System.Drawing.Size(225, 13);
			this.chkBelowMinimumLevel.TabIndex = 66;
			this.chkBelowMinimumLevel.TabStop = true;
			this.chkBelowMinimumLevel.Text = "Show Message On Below Minimum Level";
			this.chkBelowMinimumLevel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkBelowMinimumLevel.Visible = true;
			// 
			// chkBelowReorderLevel
			// 
			this.chkBelowReorderLevel.AllowDrop = true;
			this.chkBelowReorderLevel.Appearance = System.Windows.Forms.Appearance.Normal;
			this.chkBelowReorderLevel.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this.chkBelowReorderLevel.CausesValidation = true;
			this.chkBelowReorderLevel.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkBelowReorderLevel.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this.chkBelowReorderLevel.Enabled = true;
			this.chkBelowReorderLevel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.chkBelowReorderLevel.Location = new System.Drawing.Point(406, 116);
			this.chkBelowReorderLevel.Name = "chkBelowReorderLevel";
			this.chkBelowReorderLevel.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.chkBelowReorderLevel.Size = new System.Drawing.Size(225, 13);
			this.chkBelowReorderLevel.TabIndex = 65;
			this.chkBelowReorderLevel.TabStop = true;
			this.chkBelowReorderLevel.Text = "Show Message On Below Reorder Level";
			this.chkBelowReorderLevel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkBelowReorderLevel.Visible = true;
			// 
			// chkAllowFutureDateTransaction
			// 
			this.chkAllowFutureDateTransaction.AllowDrop = true;
			this.chkAllowFutureDateTransaction.Appearance = System.Windows.Forms.Appearance.Normal;
			this.chkAllowFutureDateTransaction.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this.chkAllowFutureDateTransaction.CausesValidation = true;
			this.chkAllowFutureDateTransaction.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkAllowFutureDateTransaction.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this.chkAllowFutureDateTransaction.Enabled = true;
			this.chkAllowFutureDateTransaction.ForeColor = System.Drawing.SystemColors.ControlText;
			this.chkAllowFutureDateTransaction.Location = new System.Drawing.Point(406, 100);
			this.chkAllowFutureDateTransaction.Name = "chkAllowFutureDateTransaction";
			this.chkAllowFutureDateTransaction.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.chkAllowFutureDateTransaction.Size = new System.Drawing.Size(225, 13);
			this.chkAllowFutureDateTransaction.TabIndex = 62;
			this.chkAllowFutureDateTransaction.TabStop = true;
			this.chkAllowFutureDateTransaction.Text = "Allow Future Date Transaction";
			this.chkAllowFutureDateTransaction.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkAllowFutureDateTransaction.Visible = true;
			// 
			// chkAllowSaleBelowCost
			// 
			this.chkAllowSaleBelowCost.AllowDrop = true;
			this.chkAllowSaleBelowCost.Appearance = System.Windows.Forms.Appearance.Normal;
			this.chkAllowSaleBelowCost.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this.chkAllowSaleBelowCost.CausesValidation = true;
			this.chkAllowSaleBelowCost.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkAllowSaleBelowCost.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this.chkAllowSaleBelowCost.Enabled = true;
			this.chkAllowSaleBelowCost.ForeColor = System.Drawing.SystemColors.ControlText;
			this.chkAllowSaleBelowCost.Location = new System.Drawing.Point(406, 84);
			this.chkAllowSaleBelowCost.Name = "chkAllowSaleBelowCost";
			this.chkAllowSaleBelowCost.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.chkAllowSaleBelowCost.Size = new System.Drawing.Size(225, 13);
			this.chkAllowSaleBelowCost.TabIndex = 61;
			this.chkAllowSaleBelowCost.TabStop = true;
			this.chkAllowSaleBelowCost.Text = "Allow Sale Below Cost";
			this.chkAllowSaleBelowCost.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkAllowSaleBelowCost.Visible = true;
			// 
			// chkAllowICSNegativeStock
			// 
			this.chkAllowICSNegativeStock.AllowDrop = true;
			this.chkAllowICSNegativeStock.Appearance = System.Windows.Forms.Appearance.Normal;
			this.chkAllowICSNegativeStock.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this.chkAllowICSNegativeStock.CausesValidation = true;
			this.chkAllowICSNegativeStock.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkAllowICSNegativeStock.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this.chkAllowICSNegativeStock.Enabled = true;
			this.chkAllowICSNegativeStock.ForeColor = System.Drawing.SystemColors.ControlText;
			this.chkAllowICSNegativeStock.Location = new System.Drawing.Point(406, 68);
			this.chkAllowICSNegativeStock.Name = "chkAllowICSNegativeStock";
			this.chkAllowICSNegativeStock.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.chkAllowICSNegativeStock.Size = new System.Drawing.Size(225, 13);
			this.chkAllowICSNegativeStock.TabIndex = 60;
			this.chkAllowICSNegativeStock.TabStop = true;
			this.chkAllowICSNegativeStock.Text = "Allow ICS Negative Stock";
			this.chkAllowICSNegativeStock.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkAllowICSNegativeStock.Visible = true;
			// 
			// chkEnableAdvanceModeInICSBatchPosting
			// 
			this.chkEnableAdvanceModeInICSBatchPosting.AllowDrop = true;
			this.chkEnableAdvanceModeInICSBatchPosting.Appearance = System.Windows.Forms.Appearance.Normal;
			this.chkEnableAdvanceModeInICSBatchPosting.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this.chkEnableAdvanceModeInICSBatchPosting.CausesValidation = true;
			this.chkEnableAdvanceModeInICSBatchPosting.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkEnableAdvanceModeInICSBatchPosting.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this.chkEnableAdvanceModeInICSBatchPosting.Enabled = true;
			this.chkEnableAdvanceModeInICSBatchPosting.ForeColor = System.Drawing.SystemColors.ControlText;
			this.chkEnableAdvanceModeInICSBatchPosting.Location = new System.Drawing.Point(406, 52);
			this.chkEnableAdvanceModeInICSBatchPosting.Name = "chkEnableAdvanceModeInICSBatchPosting";
			this.chkEnableAdvanceModeInICSBatchPosting.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.chkEnableAdvanceModeInICSBatchPosting.Size = new System.Drawing.Size(225, 13);
			this.chkEnableAdvanceModeInICSBatchPosting.TabIndex = 59;
			this.chkEnableAdvanceModeInICSBatchPosting.TabStop = true;
			this.chkEnableAdvanceModeInICSBatchPosting.Text = "Enable Advn. Mode in ICS Batch Posting";
			this.chkEnableAdvanceModeInICSBatchPosting.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkEnableAdvanceModeInICSBatchPosting.Visible = true;
			// 
			// chkEnablePayExpRepPop
			// 
			this.chkEnablePayExpRepPop.AllowDrop = true;
			this.chkEnablePayExpRepPop.Appearance = System.Windows.Forms.Appearance.Normal;
			this.chkEnablePayExpRepPop.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this.chkEnablePayExpRepPop.CausesValidation = true;
			this.chkEnablePayExpRepPop.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkEnablePayExpRepPop.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this.chkEnablePayExpRepPop.Enabled = true;
			this.chkEnablePayExpRepPop.ForeColor = System.Drawing.SystemColors.ControlText;
			this.chkEnablePayExpRepPop.Location = new System.Drawing.Point(406, 6);
			this.chkEnablePayExpRepPop.Name = "chkEnablePayExpRepPop";
			this.chkEnablePayExpRepPop.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.chkEnablePayExpRepPop.Size = new System.Drawing.Size(179, 13);
			this.chkEnablePayExpRepPop.TabIndex = 56;
			this.chkEnablePayExpRepPop.TabStop = true;
			this.chkEnablePayExpRepPop.Text = "Enable Expiry Document Popup";
			this.chkEnablePayExpRepPop.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkEnablePayExpRepPop.Visible = true;
			// 
			// chkRestrictOnExceedingCreditLimit
			// 
			this.chkRestrictOnExceedingCreditLimit.AllowDrop = true;
			this.chkRestrictOnExceedingCreditLimit.Appearance = System.Windows.Forms.Appearance.Normal;
			this.chkRestrictOnExceedingCreditLimit.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this.chkRestrictOnExceedingCreditLimit.CausesValidation = true;
			this.chkRestrictOnExceedingCreditLimit.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkRestrictOnExceedingCreditLimit.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this.chkRestrictOnExceedingCreditLimit.Enabled = true;
			this.chkRestrictOnExceedingCreditLimit.ForeColor = System.Drawing.SystemColors.ControlText;
			this.chkRestrictOnExceedingCreditLimit.Location = new System.Drawing.Point(406, 36);
			this.chkRestrictOnExceedingCreditLimit.Name = "chkRestrictOnExceedingCreditLimit";
			this.chkRestrictOnExceedingCreditLimit.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.chkRestrictOnExceedingCreditLimit.Size = new System.Drawing.Size(189, 13);
			this.chkRestrictOnExceedingCreditLimit.TabIndex = 9;
			this.chkRestrictOnExceedingCreditLimit.TabStop = true;
			this.chkRestrictOnExceedingCreditLimit.Text = "Restrict On Exceeding Credit Limit";
			this.chkRestrictOnExceedingCreditLimit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkRestrictOnExceedingCreditLimit.Visible = true;
			// 
			// chkEnableCostDetails
			// 
			this.chkEnableCostDetails.AllowDrop = true;
			this.chkEnableCostDetails.Appearance = System.Windows.Forms.Appearance.Normal;
			this.chkEnableCostDetails.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this.chkEnableCostDetails.CausesValidation = true;
			this.chkEnableCostDetails.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkEnableCostDetails.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this.chkEnableCostDetails.Enabled = true;
			this.chkEnableCostDetails.ForeColor = System.Drawing.SystemColors.ControlText;
			this.chkEnableCostDetails.Location = new System.Drawing.Point(406, 21);
			this.chkEnableCostDetails.Name = "chkEnableCostDetails";
			this.chkEnableCostDetails.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.chkEnableCostDetails.Size = new System.Drawing.Size(115, 13);
			this.chkEnableCostDetails.TabIndex = 8;
			this.chkEnableCostDetails.TabStop = true;
			this.chkEnableCostDetails.Text = "Enable Cost Details";
			this.chkEnableCostDetails.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkEnableCostDetails.Visible = true;
			// 
			// _lblCommon_6
			// 
			this._lblCommon_6.AllowDrop = true;
			this._lblCommon_6.BackColor = System.Drawing.SystemColors.Window;
			this._lblCommon_6.Text = "Address 2";
			this._lblCommon_6.Location = new System.Drawing.Point(8, 29);
			// // this._lblCommon_6.mLabelId = 1847;
			this._lblCommon_6.Name = "_lblCommon_6";
			this._lblCommon_6.Size = new System.Drawing.Size(51, 14);
			this._lblCommon_6.TabIndex = 36;
			// 
			// txtAddress2
			// 
			this.txtAddress2.AllowDrop = true;
			this.txtAddress2.BackColor = System.Drawing.Color.White;
			this.txtAddress2.ForeColor = System.Drawing.Color.Black;
			this.txtAddress2.Location = new System.Drawing.Point(116, 27);
			this.txtAddress2.MaxLength = 100;
			this.txtAddress2.Name = "txtAddress2";
			this.txtAddress2.Size = new System.Drawing.Size(201, 19);
			this.txtAddress2.TabIndex = 5;
			this.txtAddress2.Text = "";
			// 
			// _lblCommon_7
			// 
			this._lblCommon_7.AllowDrop = true;
			this._lblCommon_7.BackColor = System.Drawing.SystemColors.Window;
			this._lblCommon_7.Text = "Phone";
			this._lblCommon_7.Location = new System.Drawing.Point(8, 50);
			// // this._lblCommon_7.mLabelId = 524;
			this._lblCommon_7.Name = "_lblCommon_7";
			this._lblCommon_7.Size = new System.Drawing.Size(30, 14);
			this._lblCommon_7.TabIndex = 37;
			// 
			// txtPhone
			// 
			this.txtPhone.AllowDrop = true;
			this.txtPhone.BackColor = System.Drawing.Color.White;
			this.txtPhone.ForeColor = System.Drawing.Color.Black;
			this.txtPhone.Location = new System.Drawing.Point(116, 48);
			this.txtPhone.MaxLength = 20;
			this.txtPhone.Name = "txtPhone";
			this.txtPhone.Size = new System.Drawing.Size(120, 19);
			this.txtPhone.TabIndex = 6;
			this.txtPhone.Text = "";
			// 
			// _lblCommon_9
			// 
			this._lblCommon_9.AllowDrop = true;
			this._lblCommon_9.BackColor = System.Drawing.SystemColors.Window;
			this._lblCommon_9.Text = "Provident Fund ";
			this._lblCommon_9.Location = new System.Drawing.Point(8, 71);
			// // this._lblCommon_9.mLabelId = 1848;
			this._lblCommon_9.Name = "_lblCommon_9";
			this._lblCommon_9.Size = new System.Drawing.Size(75, 14);
			this._lblCommon_9.TabIndex = 38;
			// 
			// txtProvidentFund
			// 
			this.txtProvidentFund.AllowDrop = true;
			this.txtProvidentFund.BackColor = System.Drawing.Color.White;
			this.txtProvidentFund.ForeColor = System.Drawing.Color.Black;
			this.txtProvidentFund.Location = new System.Drawing.Point(116, 69);
			this.txtProvidentFund.MaxLength = 20;
			this.txtProvidentFund.Name = "txtProvidentFund";
			this.txtProvidentFund.Size = new System.Drawing.Size(120, 19);
			this.txtProvidentFund.TabIndex = 7;
			this.txtProvidentFund.Text = "";
			// 
			// _lblCommon_8
			// 
			this._lblCommon_8.AllowDrop = true;
			this._lblCommon_8.BackColor = System.Drawing.SystemColors.Window;
			this._lblCommon_8.Text = "Comments";
			this._lblCommon_8.Location = new System.Drawing.Point(10, 138);
			// // this._lblCommon_8.mLabelId = 1851;
			this._lblCommon_8.Name = "_lblCommon_8";
			this._lblCommon_8.Size = new System.Drawing.Size(50, 14);
			this._lblCommon_8.TabIndex = 39;
			// 
			// txtComments
			// 
			this.txtComments.AllowDrop = true;
			this.txtComments.BackColor = System.Drawing.Color.White;
			this.txtComments.ForeColor = System.Drawing.Color.Black;
			this.txtComments.Location = new System.Drawing.Point(116, 136);
			this.txtComments.MaxLength = 200;
			this.txtComments.Name = "txtComments";
			this.txtComments.Size = new System.Drawing.Size(286, 61);
			this.txtComments.TabIndex = 12;
			this.txtComments.Text = "";
			// 
			// _lblCommon_5
			// 
			this._lblCommon_5.AllowDrop = true;
			this._lblCommon_5.BackColor = System.Drawing.SystemColors.Window;
			this._lblCommon_5.Text = "Address 1";
			this._lblCommon_5.Location = new System.Drawing.Point(8, 8);
			// // this._lblCommon_5.mLabelId = 1846;
			this._lblCommon_5.Name = "_lblCommon_5";
			this._lblCommon_5.Size = new System.Drawing.Size(51, 14);
			this._lblCommon_5.TabIndex = 40;
			// 
			// txtAddress1
			// 
			this.txtAddress1.AllowDrop = true;
			this.txtAddress1.BackColor = System.Drawing.Color.White;
			this.txtAddress1.ForeColor = System.Drawing.Color.Black;
			this.txtAddress1.Location = new System.Drawing.Point(116, 6);
			this.txtAddress1.MaxLength = 100;
			this.txtAddress1.Name = "txtAddress1";
			this.txtAddress1.Size = new System.Drawing.Size(201, 19);
			this.txtAddress1.TabIndex = 4;
			this.txtAddress1.Text = "";
			// 
			// lblPreferredLanguage
			// 
			this.lblPreferredLanguage.AllowDrop = true;
			this.lblPreferredLanguage.BackColor = System.Drawing.SystemColors.Window;
			this.lblPreferredLanguage.Text = "Preferred Language";
			this.lblPreferredLanguage.Location = new System.Drawing.Point(8, 93);
			// // this.lblPreferredLanguage.mLabelId = 1576;
			this.lblPreferredLanguage.Name = "lblPreferredLanguage";
			this.lblPreferredLanguage.Size = new System.Drawing.Size(97, 14);
			this.lblPreferredLanguage.TabIndex = 54;
			// 
			// _cmbCommon_0
			// 
			this._cmbCommon_0.AllowDrop = true;
			this._cmbCommon_0.Location = new System.Drawing.Point(116, 90);
			this._cmbCommon_0.Name = "_cmbCommon_0";
			this._cmbCommon_0.Size = new System.Drawing.Size(101, 21);
			this._cmbCommon_0.TabIndex = 10;
			// 
			// lblDefaultSmanNo
			// 
			this.lblDefaultSmanNo.AllowDrop = true;
			this.lblDefaultSmanNo.BackColor = System.Drawing.SystemColors.Window;
			this.lblDefaultSmanNo.Text = "Default Salesman No.";
			this.lblDefaultSmanNo.Location = new System.Drawing.Point(8, 116);
			this.lblDefaultSmanNo.Name = "lblDefaultSmanNo";
			this.lblDefaultSmanNo.Size = new System.Drawing.Size(103, 14);
			this.lblDefaultSmanNo.TabIndex = 55;
			// 
			// txtDefaultSmanNo
			// 
			this.txtDefaultSmanNo.AllowDrop = true;
			this.txtDefaultSmanNo.BackColor = System.Drawing.Color.White;
			// this.txtDefaultSmanNo.bolNumericOnly = true;
			this.txtDefaultSmanNo.ForeColor = System.Drawing.Color.Black;
			this.txtDefaultSmanNo.Location = new System.Drawing.Point(116, 114);
			this.txtDefaultSmanNo.MaxLength = 15;
			this.txtDefaultSmanNo.Name = "txtDefaultSmanNo";
			// this.txtDefaultSmanNo.ShowButton = true;
			this.txtDefaultSmanNo.Size = new System.Drawing.Size(101, 19);
			this.txtDefaultSmanNo.TabIndex = 11;
			this.txtDefaultSmanNo.Text = "";
			// this.this.txtDefaultSmanNo.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtDefaultSmanNo_DropButtonClick);
			// this.txtDefaultSmanNo.Leave += new System.EventHandler(this.txtDefaultSmanNo_Leave);
			// 
			// _lblCommon_3
			// 
			this._lblCommon_3.AllowDrop = true;
			this._lblCommon_3.BackColor = System.Drawing.SystemColors.Window;
			this._lblCommon_3.Text = "Confirm Password";
			this._lblCommon_3.Location = new System.Drawing.Point(429, 56);
			// // this._lblCommon_3.mLabelId = 1845;
			this._lblCommon_3.Name = "_lblCommon_3";
			this._lblCommon_3.Size = new System.Drawing.Size(90, 14);
			this._lblCommon_3.TabIndex = 28;
			// 
			// _lblCommon_1
			// 
			this._lblCommon_1.AllowDrop = true;
			this._lblCommon_1.BackColor = System.Drawing.SystemColors.Window;
			this._lblCommon_1.Text = "User Name";
			this._lblCommon_1.Location = new System.Drawing.Point(14, 36);
			// // this._lblCommon_1.mLabelId = 1842;
			this._lblCommon_1.Name = "_lblCommon_1";
			this._lblCommon_1.Size = new System.Drawing.Size(53, 14);
			this._lblCommon_1.TabIndex = 29;
			// 
			// txtUserName
			// 
			this.txtUserName.AllowDrop = true;
			this.txtUserName.BackColor = System.Drawing.Color.White;
			this.txtUserName.ForeColor = System.Drawing.Color.Black;
			this.txtUserName.Location = new System.Drawing.Point(116, 33);
			this.txtUserName.MaxLength = 50;
			this.txtUserName.Name = "txtUserName";
			this.txtUserName.Size = new System.Drawing.Size(201, 19);
			this.txtUserName.TabIndex = 1;
			this.txtUserName.Text = "";
			// 
			// _lblCommon_2
			// 
			this._lblCommon_2.AllowDrop = true;
			this._lblCommon_2.BackColor = System.Drawing.SystemColors.Window;
			this._lblCommon_2.Text = "Password";
			this._lblCommon_2.Location = new System.Drawing.Point(14, 56);
			// // this._lblCommon_2.mLabelId = 1844;
			this._lblCommon_2.Name = "_lblCommon_2";
			this._lblCommon_2.Size = new System.Drawing.Size(50, 14);
			this._lblCommon_2.TabIndex = 30;
			// 
			// txtPassword
			// 
			this.txtPassword.AllowDrop = true;
			this.txtPassword.BackColor = System.Drawing.Color.White;
			this.txtPassword.ForeColor = System.Drawing.Color.Black;
			this.txtPassword.Location = new System.Drawing.Point(116, 53);
			this.txtPassword.MaxLength = 50;
			this.txtPassword.Name = "txtPassword";
			// this.this.txtPassword.PasswordChar = "42";
			this.txtPassword.Size = new System.Drawing.Size(120, 19);
			this.txtPassword.TabIndex = 2;
			this.txtPassword.Text = "";
			// 
			// txtConfirmPassword
			// 
			this.txtConfirmPassword.AllowDrop = true;
			this.txtConfirmPassword.BackColor = System.Drawing.Color.White;
			this.txtConfirmPassword.ForeColor = System.Drawing.Color.Black;
			this.txtConfirmPassword.Location = new System.Drawing.Point(530, 53);
			this.txtConfirmPassword.MaxLength = 50;
			this.txtConfirmPassword.Name = "txtConfirmPassword";
			// this.this.txtConfirmPassword.PasswordChar = "42";
			this.txtConfirmPassword.Size = new System.Drawing.Size(120, 19);
			this.txtConfirmPassword.TabIndex = 3;
			this.txtConfirmPassword.Text = "";
			// this.this.txtConfirmPassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtConfirmPassword_KeyPress);
			// 
			// _lblCommon_4
			// 
			this._lblCommon_4.AllowDrop = true;
			this._lblCommon_4.BackColor = System.Drawing.SystemColors.Window;
			this._lblCommon_4.Text = "User Group";
			this._lblCommon_4.Location = new System.Drawing.Point(14, 77);
			// // this._lblCommon_4.mLabelId = 842;
			this._lblCommon_4.Name = "_lblCommon_4";
			this._lblCommon_4.Size = new System.Drawing.Size(56, 14);
			this._lblCommon_4.TabIndex = 31;
			// 
			// _lblCommon_0
			// 
			this._lblCommon_0.AllowDrop = true;
			this._lblCommon_0.BackColor = System.Drawing.SystemColors.Window;
			this._lblCommon_0.Text = "User ID";
			this._lblCommon_0.Location = new System.Drawing.Point(14, 19);
			// // this._lblCommon_0.mLabelId = 1759;
			this._lblCommon_0.Name = "_lblCommon_0";
			this._lblCommon_0.Size = new System.Drawing.Size(35, 14);
			this._lblCommon_0.TabIndex = 32;
			// 
			// lblSystemComponents
			// 
			this.lblSystemComponents.AllowDrop = true;
			this.lblSystemComponents.BackColor = System.Drawing.SystemColors.Window;
			this.lblSystemComponents.Text = " User Information ";
			this.lblSystemComponents.Location = new System.Drawing.Point(10, 104);
			this.lblSystemComponents.Name = "lblSystemComponents";
			this.lblSystemComponents.Size = new System.Drawing.Size(103, 13);
			this.lblSystemComponents.TabIndex = 33;
			// 
			// txtUserId
			// 
			this.txtUserId.AllowDrop = true;
			this.txtUserId.BackColor = System.Drawing.Color.White;
			this.txtUserId.ForeColor = System.Drawing.Color.Black;
			this.txtUserId.Location = new System.Drawing.Point(116, 16);
			this.txtUserId.MaxLength = 20;
			this.txtUserId.Name = "txtUserId";
			this.txtUserId.Size = new System.Drawing.Size(120, 19);
			this.txtUserId.TabIndex = 0;
			this.txtUserId.Text = "";
			// 
			// comGroupName
			// 
			this.comGroupName.AllowDrop = true;
			this.comGroupName.Location = new System.Drawing.Point(116, 73);
			this.comGroupName.Name = "comGroupName";
			this.comGroupName.Size = new System.Drawing.Size(201, 21);
			this.comGroupName.TabIndex = 58;
			// 
			// Line1
			// 
			this.Line1.AllowDrop = true;
			this.Line1.BackColor = System.Drawing.SystemColors.WindowText;
			this.Line1.Enabled = false;
			this.Line1.Location = new System.Drawing.Point(-2, 112);
			this.Line1.Name = "Line1";
			this.Line1.Size = new System.Drawing.Size(652, 1);
			this.Line1.Visible = true;
			// 
			// frmSysUsers
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.ClientSize = new System.Drawing.Size(680, 404);
			this.Controls.Add(this.fraMainInformation);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			//this.Icon = (System.Drawing.Icon) resources.GetObject("frmSysUsers.Icon");
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(197, 175);
			this.MaximizeBox = true;
			this.MinimizeBox = true;
			this.Name = "frmSysUsers";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "System Users";
			// this.Activated += new System.EventHandler(this.frmSysUsers_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
			// this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
			//((System.ComponentModel.ISupportInitialize) this.tabMaster).EndInit();
			//((System.ComponentModel.ISupportInitialize) this.fraMainInformation).EndInit();
			this.fraMainInformation.ResumeLayout(false);
			this.tabMaster.ResumeLayout(false);
			this._fraLedgerInformation_3.ResumeLayout(false);
			this.cmbPriceList.ResumeLayout(false);
			this.grdPriceDetails.ResumeLayout(false);
			this.fraPurchase.ResumeLayout(false);
			this.fraSales.ResumeLayout(false);
			this._fraLedgerInformation_0.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		// 
		void InitializetxtCommonNumber()
		{
			this.txtCommonNumber = new System.Windows.Forms.TextBox[4];
			this.txtCommonNumber[3] = _txtCommonNumber_3;
			this.txtCommonNumber[2] = _txtCommonNumber_2;
			this.txtCommonNumber[1] = _txtCommonNumber_1;
			this.txtCommonNumber[0] = _txtCommonNumber_0;
		}
		void InitializelblCommon()
		{
			this.lblCommon = new System.Windows.Forms.Label[33];
			this.lblCommon[22] = _lblCommon_22;
			this.lblCommon[27] = _lblCommon_27;
			this.lblCommon[28] = _lblCommon_28;
			this.lblCommon[31] = _lblCommon_31;
			this.lblCommon[32] = _lblCommon_32;
			this.lblCommon[18] = _lblCommon_18;
			this.lblCommon[25] = _lblCommon_25;
			this.lblCommon[26] = _lblCommon_26;
			this.lblCommon[29] = _lblCommon_29;
			this.lblCommon[30] = _lblCommon_30;
			this.lblCommon[6] = _lblCommon_6;
			this.lblCommon[7] = _lblCommon_7;
			this.lblCommon[9] = _lblCommon_9;
			this.lblCommon[8] = _lblCommon_8;
			this.lblCommon[5] = _lblCommon_5;
			this.lblCommon[3] = _lblCommon_3;
			this.lblCommon[1] = _lblCommon_1;
			this.lblCommon[2] = _lblCommon_2;
			this.lblCommon[4] = _lblCommon_4;
			this.lblCommon[0] = _lblCommon_0;
		}
		void InitializefraLedgerInformation()
		{
			this.fraLedgerInformation = new System.Windows.Forms.Panel[4];
			this.fraLedgerInformation[3] = _fraLedgerInformation_3;
			this.fraLedgerInformation[0] = _fraLedgerInformation_0;
		}
		void InitializecmbPriceLevel()
		{
			this.cmbPriceLevel = new System.Windows.Forms.ComboBox[6];
			this.cmbPriceLevel[5] = _cmbPriceLevel_5;
			this.cmbPriceLevel[4] = _cmbPriceLevel_4;
			this.cmbPriceLevel[1] = _cmbPriceLevel_1;
			this.cmbPriceLevel[3] = _cmbPriceLevel_3;
			this.cmbPriceLevel[2] = _cmbPriceLevel_2;
			this.cmbPriceLevel[0] = _cmbPriceLevel_0;
		}
		void InitializecmbCommon()
		{
			this.cmbCommon = new System.Windows.Forms.ComboBox[1];
			this.cmbCommon[0] = _cmbCommon_0;
		}
		void InitializechkPriceRestriction()
		{
			this.chkPriceRestriction = new System.Windows.Forms.CheckBox[4];
			this.chkPriceRestriction[1] = _chkPriceRestriction_1;
			this.chkPriceRestriction[3] = _chkPriceRestriction_3;
			this.chkPriceRestriction[0] = _chkPriceRestriction_0;
			this.chkPriceRestriction[2] = _chkPriceRestriction_2;
		}
		#endregion
	}
}//ENDSHERE
