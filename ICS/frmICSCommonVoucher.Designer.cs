
namespace Xtreme
{
	partial class frmICSTransactionMaster
	{

		#region "Upgrade Support "
		private static frmICSTransactionMaster m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmICSTransactionMaster DefInstance
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
		public static frmICSTransactionMaster CreateInstance()
		{
			frmICSTransactionMaster theInstance = new frmICSTransactionMaster();
			
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
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "_txtCommonTextBox_5", "txtCashAmt", "_txtCommonTextBox_6", "txtCCAmt", "_txtDisplayLabel_3", "_txtDisplayLabel_15", "fraPayments", "txtComment", "cmdApprove", "txtExpenses", "_lblCommonLabel_15", "txtPercentDiscount", "txtDiscount", "_lblCommonLabel_9", "txtNetAmount", "_lblCommonLabel_11", "_lblCommonLabel_10", "_lblCommonLabel_12", "txtDiscount2Percent", "txtDiscount2", "_lblCommonLabel_53", "lblSave", "Line1", "frameBottom", "txtNarration2", "Frame1", "tabOtherInfo", "_comCommon_2", "_lblCommonLabel_37", "System.Windows.Forms.Label2", "txtShipmentNo", "_comCommon_3", "_lblCommonLabel_38", "_comCommon_4", "_lblCommonLabel_39", "_lblCommonLabel_40", "txtDeliveryTerms", "_lblCommonLabel_42", "txtPackingListNo", "_lblCommonLabel_43", "txtDeliveryLocation", "_comCommon_5", "_lblCommonLabel_45", "_lblCommonLabel_46", "_txtCommonTextBox_0", "farDeliveryDeetail", "_lblCommonLabel_41", "txtPaymentTerms", "_comCommon_1", "_lblCommonLabel_36", "System.Windows.Forms.Label1", "txtDrawnOnBank", "txtNAdditionalExpenses", "_lblCommonLabel_44", "fraPaymentDetail", "txtCreditCardDate", "lblRefrenceOrderDate", "lblChequeDate", "lblCreditCardDate", "txtRefrenceOrderDate", "txtChequeDate", "txtCreditCardNo", "txtRefOrderNo", "txtChequeNo", "_lblCommonLabel_32", "_lblCommonLabel_33", "_lblCommonLabel_34", "fraOrderDetail", "_lblCommonLabel_18", "txtLdgrName", "_lblCommonLabel_30", "_lblCommonLabel_35", "txtPhone", "_lblCommonLabel_31", "_lblCommonLabel_0", "_lblCommonLabel_1", "_lblCommonLabel_13", "txtBlockNo", "txtCountry", "txtStreetNo", "_lblCommonLabel_16", "txtCity", "txtAdd1", "txtAdd2", "fraContactDetail", "tabAdditionalInfo", "Column_0_grdSupplierDetails", "grdSupplierDetails", "_TabControlPage3_2", "cmdPull", "Column_0_cmbSupplierList", "Column_1_cmbSupplierList", "cmbSupplierList", "Column_0_grdImportVoucherDetails", "grdImportVoucherDetails", "_TabControlPage2_1", "Check1", "chkSortOnProduct", "txtTempDate", "Column_0_grdVoucherDetails", "grdVoucherDetails", "fraMasterInformation", "tabMaster", "chkProcessed", "_optVoucherType_1", "_optVoucherType_0", "cmdAddtionalDetails", "txtExchangeRate", "_lblCommonLabel_14", "txtVoucherDate", "_txtCommonTextBox_3", "_txtCommonTextBox_1", "_lblCommonLabel_19", "_lblCommonLabel_2", "_lblCommonLabel_5", "_lblCommonLabel_3", "_lblCommonLabel_6", "_txtCommonTextBox_7", "_lblCommonLabel_24", "_txtCommonTextBox_15", "_lblCommonLabel_17", "_txtCommonTextBox_8", "_lblCommonLabel_7", "_txtDisplayLabel_1", "_txtDisplayLabel_8", "_txtDisplayLabel_2", "_txtCommonTextBox_13", "_txtCommonTextBox_23", "_lblCommonLabel_28", "_txtCommonTextBox_24", "_lblCommonLabel_29", "_txtDisplayLabel_10", "_lblCommonLabel_8", "_txtCommonTextBox_9", "_txtDisplayLabel_6", "_txtCommonTextBox_19", "_txtCommonTextBox_18", "_lblCommonLabel_20", "_txtCommonTextBox_17", "_lblCommonLabel_23", "_lblCommonLabel_22", "_lblCommonLabel_21", "_lblCommonLabel_4", "_txtCommonTextBox_4", "_txtCommonTextBox_20", "_lblCommonLabel_25", "_lblCommonLabel_26", "txtDDueDate", "Column_0_cmbImportVoucherList", "Column_1_cmbImportVoucherList", "cmbImportVoucherList", "_txtCommonTextBox_22", "Column_0_cmbMastersList", "Column_1_cmbMastersList", "cmbMastersList", "txtCreditDays", "txtStartDate", "_lblCommonLabel_49", "txtDeliveryReturnDate", "_lblCommonLabel_52", "txtDeliveryDate", "_lblCommonLabel_51", "txtEndDate", "_lblCommonLabel_50", "fraRental", "_lblCommonLabel_47", "_txtCommonTextBox_25", "_txtDisplayLabel_12", "_lblCommonLabel_27", "_txtCommonTextBox_21", "_txtDisplayLabel_11", "_lblCommonLabel_48", "_txtCommonTextBox_26", "_txtDisplayLabel_13", "fraProject", "lblVoucherName", "fraVoucherName", "fraVoucherImport", "fraVoucherType", "fraCustomerDetails", "frmHeader", "fraTransactionHeader", "tabGeneral", "tabMain", "CommandBars", "TabControlPage2", "TabControlPage3", "comCommon", "lblCommonLabel", "optVoucherType", "txtCommonTextBox", "txtDisplayLabel"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		private System.Windows.Forms.TextBox _txtCommonTextBox_5;
		public System.Windows.Forms.TextBox txtCashAmt;
		private System.Windows.Forms.TextBox _txtCommonTextBox_6;
		public System.Windows.Forms.TextBox txtCCAmt;
		private System.Windows.Forms.Label _txtDisplayLabel_3;
		private System.Windows.Forms.Label _txtDisplayLabel_15;
		public System.Windows.Forms.GroupBox fraPayments;
		public System.Windows.Forms.TextBox txtComment;
		public System.Windows.Forms.Button cmdApprove;
		public System.Windows.Forms.TextBox txtExpenses;
		private System.Windows.Forms.Label _lblCommonLabel_15;
		public System.Windows.Forms.TextBox txtPercentDiscount;
		public System.Windows.Forms.TextBox txtDiscount;
		private System.Windows.Forms.Label _lblCommonLabel_9;
		public System.Windows.Forms.TextBox txtNetAmount;
		private System.Windows.Forms.Label _lblCommonLabel_11;
		private System.Windows.Forms.Label _lblCommonLabel_10;
		private System.Windows.Forms.Label _lblCommonLabel_12;
		public System.Windows.Forms.TextBox txtDiscount2Percent;
		public System.Windows.Forms.TextBox txtDiscount2;
		private System.Windows.Forms.Label _lblCommonLabel_53;
		public System.Windows.Forms.Label lblSave;
		public System.Windows.Forms.Label Line1;
		public System.Windows.Forms.Panel frameBottom;
		public UCRichTextBox txtNarration2;
		public System.Windows.Forms.GroupBox Frame1;
		public AxXtremeSuiteControls.AxTabControlPage tabOtherInfo;
		private System.Windows.Forms.ComboBox _comCommon_2;
		private System.Windows.Forms.Label _lblCommonLabel_37;
		public System.Windows.Forms.Label Label2;
		public System.Windows.Forms.TextBox txtShipmentNo;
		private System.Windows.Forms.ComboBox _comCommon_3;
		private System.Windows.Forms.Label _lblCommonLabel_38;
		private System.Windows.Forms.ComboBox _comCommon_4;
		private System.Windows.Forms.Label _lblCommonLabel_39;
		private System.Windows.Forms.Label _lblCommonLabel_40;
		public System.Windows.Forms.TextBox txtDeliveryTerms;
		private System.Windows.Forms.Label _lblCommonLabel_42;
		public System.Windows.Forms.TextBox txtPackingListNo;
		private System.Windows.Forms.Label _lblCommonLabel_43;
		public System.Windows.Forms.TextBox txtDeliveryLocation;
		private System.Windows.Forms.ComboBox _comCommon_5;
		private System.Windows.Forms.Label _lblCommonLabel_45;
		private System.Windows.Forms.Label _lblCommonLabel_46;
		private System.Windows.Forms.TextBox _txtCommonTextBox_0;
		public System.Windows.Forms.GroupBox farDeliveryDeetail;
		private System.Windows.Forms.Label _lblCommonLabel_41;
		public System.Windows.Forms.TextBox txtPaymentTerms;
		private System.Windows.Forms.ComboBox _comCommon_1;
		private System.Windows.Forms.Label _lblCommonLabel_36;
		public System.Windows.Forms.Label Label1;
		public System.Windows.Forms.TextBox txtDrawnOnBank;
		public System.Windows.Forms.TextBox txtNAdditionalExpenses;
		private System.Windows.Forms.Label _lblCommonLabel_44;
		public System.Windows.Forms.GroupBox fraPaymentDetail;
		public Syncfusion.WinForms.Input.SfDateTimeEdit txtCreditCardDate;
		public System.Windows.Forms.Label lblRefrenceOrderDate;
		public System.Windows.Forms.Label lblChequeDate;
		public System.Windows.Forms.Label lblCreditCardDate;
		public Syncfusion.WinForms.Input.SfDateTimeEdit txtRefrenceOrderDate;
		public Syncfusion.WinForms.Input.SfDateTimeEdit txtChequeDate;
		public System.Windows.Forms.TextBox txtCreditCardNo;
		public System.Windows.Forms.TextBox txtRefOrderNo;
		public System.Windows.Forms.TextBox txtChequeNo;
		private System.Windows.Forms.Label _lblCommonLabel_32;
		private System.Windows.Forms.Label _lblCommonLabel_33;
		private System.Windows.Forms.Label _lblCommonLabel_34;
		public System.Windows.Forms.GroupBox fraOrderDetail;
		private System.Windows.Forms.Label _lblCommonLabel_18;
		public System.Windows.Forms.TextBox txtLdgrName;
		private System.Windows.Forms.Label _lblCommonLabel_30;
		private System.Windows.Forms.Label _lblCommonLabel_35;
		public System.Windows.Forms.TextBox txtPhone;
		private System.Windows.Forms.Label _lblCommonLabel_31;
		private System.Windows.Forms.Label _lblCommonLabel_0;
		private System.Windows.Forms.Label _lblCommonLabel_1;
		private System.Windows.Forms.Label _lblCommonLabel_13;
		public System.Windows.Forms.TextBox txtBlockNo;
		public System.Windows.Forms.TextBox txtCountry;
		public System.Windows.Forms.TextBox txtStreetNo;
		private System.Windows.Forms.Label _lblCommonLabel_16;
		public System.Windows.Forms.TextBox txtCity;
		public System.Windows.Forms.TextBox txtAdd1;
		public System.Windows.Forms.TextBox txtAdd2;
		public System.Windows.Forms.GroupBox fraContactDetail;
		public AxXtremeSuiteControls.AxTabControlPage tabAdditionalInfo;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_0_grdSupplierDetails;
		public C1.Win.C1TrueDBGrid.C1TrueDBGrid grdSupplierDetails;
		private AxXtremeSuiteControls.AxTabControlPage _TabControlPage3_2;
		public System.Windows.Forms.Button cmdPull;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_0_cmbSupplierList;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_1_cmbSupplierList;
		public C1.Win.C1TrueDBGrid.C1TrueDBDropdown cmbSupplierList;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_0_grdImportVoucherDetails;
		public C1.Win.C1TrueDBGrid.C1TrueDBGrid grdImportVoucherDetails;
		private AxXtremeSuiteControls.AxTabControlPage _TabControlPage2_1;
		public System.Windows.Forms.CheckBox Check1;
		public System.Windows.Forms.CheckBox chkSortOnProduct;
		public Syncfusion.WinForms.Input.SfDateTimeEdit txtTempDate;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_0_grdVoucherDetails;
		public C1.Win.C1TrueDBGrid.C1TrueDBGrid grdVoucherDetails;
		public AxXtremeSuiteControls.AxTabControlPage fraMasterInformation;
		public AxXtremeSuiteControls.AxTabControl tabMaster;
		public System.Windows.Forms.CheckBox chkProcessed;
		private System.Windows.Forms.RadioButton _optVoucherType_1;
		private System.Windows.Forms.RadioButton _optVoucherType_0;
		public System.Windows.Forms.Button cmdAddtionalDetails;
		public System.Windows.Forms.TextBox txtExchangeRate;
		private System.Windows.Forms.Label _lblCommonLabel_14;
		public Syncfusion.WinForms.Input.SfDateTimeEdit txtVoucherDate;
		private System.Windows.Forms.TextBox _txtCommonTextBox_3;
		private System.Windows.Forms.TextBox _txtCommonTextBox_1;
		private System.Windows.Forms.Label _lblCommonLabel_19;
		private System.Windows.Forms.Label _lblCommonLabel_2;
		private System.Windows.Forms.Label _lblCommonLabel_5;
		private System.Windows.Forms.Label _lblCommonLabel_3;
		private System.Windows.Forms.Label _lblCommonLabel_6;
		private System.Windows.Forms.TextBox _txtCommonTextBox_7;
		private System.Windows.Forms.Label _lblCommonLabel_24;
		private System.Windows.Forms.TextBox _txtCommonTextBox_15;
		private System.Windows.Forms.Label _lblCommonLabel_17;
		private System.Windows.Forms.TextBox _txtCommonTextBox_8;
		private System.Windows.Forms.Label _lblCommonLabel_7;
		private System.Windows.Forms.Label _txtDisplayLabel_1;
		private System.Windows.Forms.Label _txtDisplayLabel_8;
		private System.Windows.Forms.Label _txtDisplayLabel_2;
		private System.Windows.Forms.TextBox _txtCommonTextBox_13;
		private System.Windows.Forms.TextBox _txtCommonTextBox_23;
		private System.Windows.Forms.Label _lblCommonLabel_28;
		private System.Windows.Forms.TextBox _txtCommonTextBox_24;
		private System.Windows.Forms.Label _lblCommonLabel_29;
		private System.Windows.Forms.Label _txtDisplayLabel_10;
		private System.Windows.Forms.Label _lblCommonLabel_8;
		private System.Windows.Forms.TextBox _txtCommonTextBox_9;
		private System.Windows.Forms.Label _txtDisplayLabel_6;
		private System.Windows.Forms.TextBox _txtCommonTextBox_19;
		private System.Windows.Forms.TextBox _txtCommonTextBox_18;
		private System.Windows.Forms.Label _lblCommonLabel_20;
		private System.Windows.Forms.TextBox _txtCommonTextBox_17;
		private System.Windows.Forms.Label _lblCommonLabel_23;
		private System.Windows.Forms.Label _lblCommonLabel_22;
		private System.Windows.Forms.Label _lblCommonLabel_21;
		private System.Windows.Forms.Label _lblCommonLabel_4;
		private System.Windows.Forms.TextBox _txtCommonTextBox_4;
		private System.Windows.Forms.TextBox _txtCommonTextBox_20;
		private System.Windows.Forms.Label _lblCommonLabel_25;
		private System.Windows.Forms.Label _lblCommonLabel_26;
		public Syncfusion.WinForms.Input.SfDateTimeEdit txtDDueDate;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_0_cmbImportVoucherList;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_1_cmbImportVoucherList;
		public C1.Win.C1TrueDBGrid.C1TrueDBDropdown cmbImportVoucherList;
		private System.Windows.Forms.TextBox _txtCommonTextBox_22;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_0_cmbMastersList;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_1_cmbMastersList;
		public C1.Win.C1TrueDBGrid.C1TrueDBDropdown cmbMastersList;
		public System.Windows.Forms.TextBox txtCreditDays;
		public Syncfusion.WinForms.Input.SfDateTimeEdit txtStartDate;
		private System.Windows.Forms.Label _lblCommonLabel_49;
		public Syncfusion.WinForms.Input.SfDateTimeEdit txtDeliveryReturnDate;
		private System.Windows.Forms.Label _lblCommonLabel_52;
		public Syncfusion.WinForms.Input.SfDateTimeEdit txtDeliveryDate;
		private System.Windows.Forms.Label _lblCommonLabel_51;
		public Syncfusion.WinForms.Input.SfDateTimeEdit txtEndDate;
		private System.Windows.Forms.Label _lblCommonLabel_50;
		public System.Windows.Forms.GroupBox fraRental;
		private System.Windows.Forms.Label _lblCommonLabel_47;
		private System.Windows.Forms.TextBox _txtCommonTextBox_25;
		private System.Windows.Forms.Label _txtDisplayLabel_12;
		private System.Windows.Forms.Label _lblCommonLabel_27;
		private System.Windows.Forms.TextBox _txtCommonTextBox_21;
		private System.Windows.Forms.Label _txtDisplayLabel_11;
		private System.Windows.Forms.Label _lblCommonLabel_48;
		private System.Windows.Forms.TextBox _txtCommonTextBox_26;
		private System.Windows.Forms.Label _txtDisplayLabel_13;
		public System.Windows.Forms.GroupBox fraProject;
		public System.Windows.Forms.Label lblVoucherName;
		public UpgradeHelpers.Gui.ShapeHelper fraVoucherName;
		public UpgradeHelpers.Gui.ShapeHelper fraVoucherImport;
		public UpgradeHelpers.Gui.ShapeHelper fraVoucherType;
		public UpgradeHelpers.Gui.ShapeHelper fraCustomerDetails;
		public UpgradeHelpers.Gui.ShapeHelper frmHeader;
		public UpgradeHelpers.Gui.ShapeHelper fraTransactionHeader;
		public AxXtremeSuiteControls.AxTabControlPage tabGeneral;
		public AxXtremeSuiteControls.AxTabControl tabMain;
		public Syncfusion.Windows.Forms.Tools.CommandBarController CommandBars;
		public AxXtremeSuiteControls.AxTabControlPage[] TabControlPage2 = new AxXtremeSuiteControls.AxTabControlPage[2];
		public AxXtremeSuiteControls.AxTabControlPage[] TabControlPage3 = new AxXtremeSuiteControls.AxTabControlPage[3];
		public System.Windows.Forms.ComboBox[] comCommon = new System.Windows.Forms.ComboBox[6];
		public System.Windows.Forms.Label[] lblCommonLabel = new System.Windows.Forms.Label[54];
		public System.Windows.Forms.RadioButton[] optVoucherType = new System.Windows.Forms.RadioButton[2];
		public System.Windows.Forms.TextBox[] txtCommonTextBox = new System.Windows.Forms.TextBox[27];
		public System.Windows.Forms.Label[] txtDisplayLabel = new System.Windows.Forms.Label[16];
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmICSTransactionMaster));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this.frameBottom = new System.Windows.Forms.Panel();
			this.fraPayments = new System.Windows.Forms.GroupBox();
			this._txtCommonTextBox_5 = new System.Windows.Forms.TextBox();
			this.txtCashAmt = new System.Windows.Forms.TextBox();
			this._txtCommonTextBox_6 = new System.Windows.Forms.TextBox();
			this.txtCCAmt = new System.Windows.Forms.TextBox();
			this._txtDisplayLabel_3 = new System.Windows.Forms.Label();
			this._txtDisplayLabel_15 = new System.Windows.Forms.Label();
			this.txtComment = new System.Windows.Forms.TextBox();
			this.cmdApprove = new System.Windows.Forms.Button();
			this.txtExpenses = new System.Windows.Forms.TextBox();
			this._lblCommonLabel_15 = new System.Windows.Forms.Label();
			this.txtPercentDiscount = new System.Windows.Forms.TextBox();
			this.txtDiscount = new System.Windows.Forms.TextBox();
			this._lblCommonLabel_9 = new System.Windows.Forms.Label();
			this.txtNetAmount = new System.Windows.Forms.TextBox();
			this._lblCommonLabel_11 = new System.Windows.Forms.Label();
			this._lblCommonLabel_10 = new System.Windows.Forms.Label();
			this._lblCommonLabel_12 = new System.Windows.Forms.Label();
			this.txtDiscount2Percent = new System.Windows.Forms.TextBox();
			this.txtDiscount2 = new System.Windows.Forms.TextBox();
			this._lblCommonLabel_53 = new System.Windows.Forms.Label();
			this.lblSave = new System.Windows.Forms.Label();
			this.Line1 = new System.Windows.Forms.Label();
			this.tabMain = new AxXtremeSuiteControls.AxTabControl();
			this.tabOtherInfo = new AxXtremeSuiteControls.AxTabControlPage();
			this.Frame1 = new System.Windows.Forms.GroupBox();
			this.txtNarration2 = new UCRichTextBox();
			this.tabAdditionalInfo = new AxXtremeSuiteControls.AxTabControlPage();
			this.farDeliveryDeetail = new System.Windows.Forms.GroupBox();
			this._comCommon_2 = new System.Windows.Forms.ComboBox();
			this._lblCommonLabel_37 = new System.Windows.Forms.Label();
			this.Label2 = new System.Windows.Forms.Label();
			this.txtShipmentNo = new System.Windows.Forms.TextBox();
			this._comCommon_3 = new System.Windows.Forms.ComboBox();
			this._lblCommonLabel_38 = new System.Windows.Forms.Label();
			this._comCommon_4 = new System.Windows.Forms.ComboBox();
			this._lblCommonLabel_39 = new System.Windows.Forms.Label();
			this._lblCommonLabel_40 = new System.Windows.Forms.Label();
			this.txtDeliveryTerms = new System.Windows.Forms.TextBox();
			this._lblCommonLabel_42 = new System.Windows.Forms.Label();
			this.txtPackingListNo = new System.Windows.Forms.TextBox();
			this._lblCommonLabel_43 = new System.Windows.Forms.Label();
			this.txtDeliveryLocation = new System.Windows.Forms.TextBox();
			this._comCommon_5 = new System.Windows.Forms.ComboBox();
			this._lblCommonLabel_45 = new System.Windows.Forms.Label();
			this._lblCommonLabel_46 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_0 = new System.Windows.Forms.TextBox();
			this.fraPaymentDetail = new System.Windows.Forms.GroupBox();
			this._lblCommonLabel_41 = new System.Windows.Forms.Label();
			this.txtPaymentTerms = new System.Windows.Forms.TextBox();
			this._comCommon_1 = new System.Windows.Forms.ComboBox();
			this._lblCommonLabel_36 = new System.Windows.Forms.Label();
			this.Label1 = new System.Windows.Forms.Label();
			this.txtDrawnOnBank = new System.Windows.Forms.TextBox();
			this.txtNAdditionalExpenses = new System.Windows.Forms.TextBox();
			this._lblCommonLabel_44 = new System.Windows.Forms.Label();
			this.fraOrderDetail = new System.Windows.Forms.GroupBox();
			this.txtCreditCardDate = new Syncfusion.WinForms.Input.SfDateTimeEdit();
			this.lblRefrenceOrderDate = new System.Windows.Forms.Label();
			this.lblChequeDate = new System.Windows.Forms.Label();
			this.lblCreditCardDate = new System.Windows.Forms.Label();
			this.txtRefrenceOrderDate = new Syncfusion.WinForms.Input.SfDateTimeEdit();
			this.txtChequeDate = new Syncfusion.WinForms.Input.SfDateTimeEdit();
			this.txtCreditCardNo = new System.Windows.Forms.TextBox();
			this.txtRefOrderNo = new System.Windows.Forms.TextBox();
			this.txtChequeNo = new System.Windows.Forms.TextBox();
			this._lblCommonLabel_32 = new System.Windows.Forms.Label();
			this._lblCommonLabel_33 = new System.Windows.Forms.Label();
			this._lblCommonLabel_34 = new System.Windows.Forms.Label();
			this.fraContactDetail = new System.Windows.Forms.GroupBox();
			this._lblCommonLabel_18 = new System.Windows.Forms.Label();
			this.txtLdgrName = new System.Windows.Forms.TextBox();
			this._lblCommonLabel_30 = new System.Windows.Forms.Label();
			this._lblCommonLabel_35 = new System.Windows.Forms.Label();
			this.txtPhone = new System.Windows.Forms.TextBox();
			this._lblCommonLabel_31 = new System.Windows.Forms.Label();
			this._lblCommonLabel_0 = new System.Windows.Forms.Label();
			this._lblCommonLabel_1 = new System.Windows.Forms.Label();
			this._lblCommonLabel_13 = new System.Windows.Forms.Label();
			this.txtBlockNo = new System.Windows.Forms.TextBox();
			this.txtCountry = new System.Windows.Forms.TextBox();
			this.txtStreetNo = new System.Windows.Forms.TextBox();
			this._lblCommonLabel_16 = new System.Windows.Forms.Label();
			this.txtCity = new System.Windows.Forms.TextBox();
			this.txtAdd1 = new System.Windows.Forms.TextBox();
			this.txtAdd2 = new System.Windows.Forms.TextBox();
			this.tabGeneral = new AxXtremeSuiteControls.AxTabControlPage();
			this.tabMaster = new AxXtremeSuiteControls.AxTabControl();
			this._TabControlPage3_2 = new AxXtremeSuiteControls.AxTabControlPage();
			this.grdSupplierDetails = new C1.Win.C1TrueDBGrid.C1TrueDBGrid();
			this.Column_0_grdSupplierDetails = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this._TabControlPage2_1 = new AxXtremeSuiteControls.AxTabControlPage();
			this.cmdPull = new System.Windows.Forms.Button();
			this.cmbSupplierList = new C1.Win.C1TrueDBGrid.C1TrueDBDropdown();
			this.Column_0_cmbSupplierList = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.Column_1_cmbSupplierList = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.grdImportVoucherDetails = new C1.Win.C1TrueDBGrid.C1TrueDBGrid();
			this.Column_0_grdImportVoucherDetails = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.fraMasterInformation = new AxXtremeSuiteControls.AxTabControlPage();
			this.Check1 = new System.Windows.Forms.CheckBox();
			this.chkSortOnProduct = new System.Windows.Forms.CheckBox();
			this.txtTempDate = new Syncfusion.WinForms.Input.SfDateTimeEdit();
			this.grdVoucherDetails = new C1.Win.C1TrueDBGrid.C1TrueDBGrid();
			this.Column_0_grdVoucherDetails = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.chkProcessed = new System.Windows.Forms.CheckBox();
			this._optVoucherType_1 = new System.Windows.Forms.RadioButton();
			this._optVoucherType_0 = new System.Windows.Forms.RadioButton();
			this.cmdAddtionalDetails = new System.Windows.Forms.Button();
			this.txtExchangeRate = new System.Windows.Forms.TextBox();
			this._lblCommonLabel_14 = new System.Windows.Forms.Label();
			this.txtVoucherDate = new Syncfusion.WinForms.Input.SfDateTimeEdit();
			this._txtCommonTextBox_3 = new System.Windows.Forms.TextBox();
			this._txtCommonTextBox_1 = new System.Windows.Forms.TextBox();
			this._lblCommonLabel_19 = new System.Windows.Forms.Label();
			this._lblCommonLabel_2 = new System.Windows.Forms.Label();
			this._lblCommonLabel_5 = new System.Windows.Forms.Label();
			this._lblCommonLabel_3 = new System.Windows.Forms.Label();
			this._lblCommonLabel_6 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_7 = new System.Windows.Forms.TextBox();
			this._lblCommonLabel_24 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_15 = new System.Windows.Forms.TextBox();
			this._lblCommonLabel_17 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_8 = new System.Windows.Forms.TextBox();
			this._lblCommonLabel_7 = new System.Windows.Forms.Label();
			this._txtDisplayLabel_1 = new System.Windows.Forms.Label();
			this._txtDisplayLabel_8 = new System.Windows.Forms.Label();
			this._txtDisplayLabel_2 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_13 = new System.Windows.Forms.TextBox();
			this._txtCommonTextBox_23 = new System.Windows.Forms.TextBox();
			this._lblCommonLabel_28 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_24 = new System.Windows.Forms.TextBox();
			this._lblCommonLabel_29 = new System.Windows.Forms.Label();
			this._txtDisplayLabel_10 = new System.Windows.Forms.Label();
			this._lblCommonLabel_8 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_9 = new System.Windows.Forms.TextBox();
			this._txtDisplayLabel_6 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_19 = new System.Windows.Forms.TextBox();
			this._txtCommonTextBox_18 = new System.Windows.Forms.TextBox();
			this._lblCommonLabel_20 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_17 = new System.Windows.Forms.TextBox();
			this._lblCommonLabel_23 = new System.Windows.Forms.Label();
			this._lblCommonLabel_22 = new System.Windows.Forms.Label();
			this._lblCommonLabel_21 = new System.Windows.Forms.Label();
			this._lblCommonLabel_4 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_4 = new System.Windows.Forms.TextBox();
			this._txtCommonTextBox_20 = new System.Windows.Forms.TextBox();
			this._lblCommonLabel_25 = new System.Windows.Forms.Label();
			this._lblCommonLabel_26 = new System.Windows.Forms.Label();
			this.txtDDueDate = new Syncfusion.WinForms.Input.SfDateTimeEdit();
			this.cmbImportVoucherList = new C1.Win.C1TrueDBGrid.C1TrueDBDropdown();
			this.Column_0_cmbImportVoucherList = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.Column_1_cmbImportVoucherList = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this._txtCommonTextBox_22 = new System.Windows.Forms.TextBox();
			this.cmbMastersList = new C1.Win.C1TrueDBGrid.C1TrueDBDropdown();
			this.Column_0_cmbMastersList = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.Column_1_cmbMastersList = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.txtCreditDays = new System.Windows.Forms.TextBox();
			this.fraRental = new System.Windows.Forms.GroupBox();
			this.txtStartDate = new Syncfusion.WinForms.Input.SfDateTimeEdit();
			this._lblCommonLabel_49 = new System.Windows.Forms.Label();
			this.txtDeliveryReturnDate = new Syncfusion.WinForms.Input.SfDateTimeEdit();
			this._lblCommonLabel_52 = new System.Windows.Forms.Label();
			this.txtDeliveryDate = new Syncfusion.WinForms.Input.SfDateTimeEdit();
			this._lblCommonLabel_51 = new System.Windows.Forms.Label();
			this.txtEndDate = new Syncfusion.WinForms.Input.SfDateTimeEdit();
			this._lblCommonLabel_50 = new System.Windows.Forms.Label();
			this.fraProject = new System.Windows.Forms.GroupBox();
			this._lblCommonLabel_47 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_25 = new System.Windows.Forms.TextBox();
			this._txtDisplayLabel_12 = new System.Windows.Forms.Label();
			this._lblCommonLabel_27 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_21 = new System.Windows.Forms.TextBox();
			this._txtDisplayLabel_11 = new System.Windows.Forms.Label();
			this._lblCommonLabel_48 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_26 = new System.Windows.Forms.TextBox();
			this._txtDisplayLabel_13 = new System.Windows.Forms.Label();
			this.lblVoucherName = new System.Windows.Forms.Label();
			this.fraVoucherName = new UpgradeHelpers.Gui.ShapeHelper();
			this.fraVoucherImport = new UpgradeHelpers.Gui.ShapeHelper();
			this.fraVoucherType = new UpgradeHelpers.Gui.ShapeHelper();
			this.fraCustomerDetails = new UpgradeHelpers.Gui.ShapeHelper();
			this.frmHeader = new UpgradeHelpers.Gui.ShapeHelper();
			this.fraTransactionHeader = new UpgradeHelpers.Gui.ShapeHelper();
			this.CommandBars = new Syncfusion.Windows.Forms.Tools.CommandBarController();
			// //((System.ComponentModel.ISupportInitialize) this.tabOtherInfo).BeginInit();
			// //((System.ComponentModel.ISupportInitialize) this.tabAdditionalInfo).BeginInit();
			// //((System.ComponentModel.ISupportInitialize) this._TabControlPage3_2).BeginInit();
			// //((System.ComponentModel.ISupportInitialize) this._TabControlPage2_1).BeginInit();
			// //((System.ComponentModel.ISupportInitialize) this.txtTempDate).BeginInit();
			// //((System.ComponentModel.ISupportInitialize) this.fraMasterInformation).BeginInit();
			// //((System.ComponentModel.ISupportInitialize) this.tabMaster).BeginInit();
			// //((System.ComponentModel.ISupportInitialize) this.cmdAddtionalDetails).BeginInit();
			// //((System.ComponentModel.ISupportInitialize) this.tabGeneral).BeginInit();
			// //((System.ComponentModel.ISupportInitialize) this.tabMain).BeginInit();
			// //((System.ComponentModel.ISupportInitialize) this.CommandBars).BeginInit();
			this.frameBottom.SuspendLayout();
			this.fraPayments.SuspendLayout();
			this.tabMain.SuspendLayout();
			this.tabOtherInfo.SuspendLayout();
			this.Frame1.SuspendLayout();
			this.tabAdditionalInfo.SuspendLayout();
			this.farDeliveryDeetail.SuspendLayout();
			this.fraPaymentDetail.SuspendLayout();
			this.fraOrderDetail.SuspendLayout();
			this.fraContactDetail.SuspendLayout();
			this.tabGeneral.SuspendLayout();
			this.tabMaster.SuspendLayout();
			this._TabControlPage3_2.SuspendLayout();
			this.grdSupplierDetails.SuspendLayout();
			this._TabControlPage2_1.SuspendLayout();
			this.cmbSupplierList.SuspendLayout();
			this.grdImportVoucherDetails.SuspendLayout();
			this.fraMasterInformation.SuspendLayout();
			this.grdVoucherDetails.SuspendLayout();
			this.cmbImportVoucherList.SuspendLayout();
			this.cmbMastersList.SuspendLayout();
			this.fraRental.SuspendLayout();
			this.fraProject.SuspendLayout();
			this.SuspendLayout();
			// 
			// frameBottom
			// 
			this.frameBottom.AllowDrop = true;
			this.frameBottom.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.frameBottom.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.frameBottom.Controls.Add(this.fraPayments);
			this.frameBottom.Controls.Add(this.txtComment);
			this.frameBottom.Controls.Add(this.cmdApprove);
			this.frameBottom.Controls.Add(this.txtExpenses);
			this.frameBottom.Controls.Add(this._lblCommonLabel_15);
			this.frameBottom.Controls.Add(this.txtPercentDiscount);
			this.frameBottom.Controls.Add(this.txtDiscount);
			this.frameBottom.Controls.Add(this._lblCommonLabel_9);
			this.frameBottom.Controls.Add(this.txtNetAmount);
			this.frameBottom.Controls.Add(this._lblCommonLabel_11);
			this.frameBottom.Controls.Add(this._lblCommonLabel_10);
			this.frameBottom.Controls.Add(this._lblCommonLabel_12);
			this.frameBottom.Controls.Add(this.txtDiscount2Percent);
			this.frameBottom.Controls.Add(this.txtDiscount2);
			this.frameBottom.Controls.Add(this._lblCommonLabel_53);
			this.frameBottom.Controls.Add(this.lblSave);
			this.frameBottom.Controls.Add(this.Line1);
			this.frameBottom.Enabled = true;
			this.frameBottom.ForeColor = System.Drawing.SystemColors.ControlText;
			this.frameBottom.Location = new System.Drawing.Point(2, 502);
			this.frameBottom.Name = "frameBottom";
			this.frameBottom.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.frameBottom.Size = new System.Drawing.Size(1233, 67);
			this.frameBottom.TabIndex = 94;
			this.frameBottom.Visible = true;
			// 
			// fraPayments
			// 
			this.fraPayments.AllowDrop = true;
			this.fraPayments.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.fraPayments.Controls.Add(this._txtCommonTextBox_5);
			this.fraPayments.Controls.Add(this.txtCashAmt);
			this.fraPayments.Controls.Add(this._txtCommonTextBox_6);
			this.fraPayments.Controls.Add(this.txtCCAmt);
			this.fraPayments.Controls.Add(this._txtDisplayLabel_3);
			this.fraPayments.Controls.Add(this._txtDisplayLabel_15);
			this.fraPayments.Enabled = true;
			this.fraPayments.ForeColor = System.Drawing.SystemColors.ControlText;
			this.fraPayments.Location = new System.Drawing.Point(828, -6);
			this.fraPayments.Name = "fraPayments";
			this.fraPayments.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.fraPayments.Size = new System.Drawing.Size(261, 67);
			this.fraPayments.TabIndex = 161;
			this.fraPayments.Visible = true;
			// 
			// _txtCommonTextBox_5
			// 
			this._txtCommonTextBox_5.AllowDrop = true;
			this._txtCommonTextBox_5.BackColor = System.Drawing.Color.FromArgb(239, 239, 239);
			this._txtCommonTextBox_5.Enabled = false;
			this._txtCommonTextBox_5.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_5.Location = new System.Drawing.Point(4, 10);
			this._txtCommonTextBox_5.Name = "_txtCommonTextBox_5";
			// this._txtCommonTextBox_5.ShowButton = true;
			this._txtCommonTextBox_5.Size = new System.Drawing.Size(67, 23);
			this._txtCommonTextBox_5.TabIndex = 162;
			this._txtCommonTextBox_5.Text = "";
			this._txtCommonTextBox_5.Visible = false;
			// this.this._txtCommonTextBox_5.Watermark = "";
			// this.this._txtCommonTextBox_5.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_5.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// txtCashAmt
			// 
			this.txtCashAmt.AllowDrop = true;
			// this.txtCashAmt.DisplayFormat = "####0.000###;;0.000;0.000";
			// this.txtCashAmt.Format = "###########0.000";
			this.txtCashAmt.Location = new System.Drawing.Point(170, 10);
			// this.txtCashAmt.MaxValue = 2147483647;
			// this.txtCashAmt.MinValue = 0;
			this.txtCashAmt.Name = "txtCashAmt";
			this.txtCashAmt.Size = new System.Drawing.Size(87, 23);
			this.txtCashAmt.TabIndex = 163;
			this.txtCashAmt.Text = "0.000";
			// this.txtCashAmt.Leave += new System.EventHandler(this.txtCashAmt_Leave);
			// 
			// _txtCommonTextBox_6
			// 
			this._txtCommonTextBox_6.AllowDrop = true;
			this._txtCommonTextBox_6.BackColor = System.Drawing.Color.FromArgb(239, 239, 239);
			this._txtCommonTextBox_6.Enabled = false;
			this._txtCommonTextBox_6.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_6.Location = new System.Drawing.Point(4, 38);
			this._txtCommonTextBox_6.Name = "_txtCommonTextBox_6";
			// this._txtCommonTextBox_6.ShowButton = true;
			this._txtCommonTextBox_6.Size = new System.Drawing.Size(67, 23);
			this._txtCommonTextBox_6.TabIndex = 164;
			this._txtCommonTextBox_6.Text = "";
			// this.this._txtCommonTextBox_6.Watermark = "";
			// this.this._txtCommonTextBox_6.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_6.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// txtCCAmt
			// 
			this.txtCCAmt.AllowDrop = true;
			// this.txtCCAmt.DisplayFormat = "####0.000###;;0.000;0.000";
			// this.txtCCAmt.Format = "###########0.000";
			this.txtCCAmt.Location = new System.Drawing.Point(170, 38);
			// this.txtCCAmt.MaxValue = 2147483647;
			// this.txtCCAmt.MinValue = 0;
			this.txtCCAmt.Name = "txtCCAmt";
			this.txtCCAmt.Size = new System.Drawing.Size(87, 23);
			this.txtCCAmt.TabIndex = 165;
			this.txtCCAmt.Text = "0.000";
			// this.txtCCAmt.Leave += new System.EventHandler(this.txtCCAmt_Leave);
			// 
			// _txtDisplayLabel_3
			// 
			this._txtDisplayLabel_3.AllowDrop = true;
			this._txtDisplayLabel_3.Location = new System.Drawing.Point(72, 10);
			this._txtDisplayLabel_3.Name = "_txtDisplayLabel_3";
			this._txtDisplayLabel_3.Size = new System.Drawing.Size(97, 23);
			this._txtDisplayLabel_3.TabIndex = 166;
			this._txtDisplayLabel_3.TabStop = false;
			// 
			// _txtDisplayLabel_15
			// 
			this._txtDisplayLabel_15.AllowDrop = true;
			this._txtDisplayLabel_15.Location = new System.Drawing.Point(72, 38);
			this._txtDisplayLabel_15.Name = "_txtDisplayLabel_15";
			this._txtDisplayLabel_15.Size = new System.Drawing.Size(97, 23);
			this._txtDisplayLabel_15.TabIndex = 167;
			this._txtDisplayLabel_15.TabStop = false;
			// 
			// txtComment
			// 
			this.txtComment.AllowDrop = true;
			this.txtComment.BackColor = System.Drawing.Color.White;
			// this.txtComment.bolAllowDecimal = false;
			this.txtComment.ForeColor = System.Drawing.Color.Black;
			this.txtComment.Location = new System.Drawing.Point(60, 4);
			// this.txtComment.mDropDownType = (System.Windows.Forms.TextBox.FormatBoxDropDownTypes) 0;
			this.txtComment.Name = "txtComment";
			this.txtComment.Size = new System.Drawing.Size(339, 55);
			this.txtComment.TabIndex = 20;
			this.txtComment.Text = "";
			// 
			// cmdApprove
			// 
			this.cmdApprove.AllowDrop = true;
			this.cmdApprove.BackColor = System.Drawing.SystemColors.Control;
			this.cmdApprove.CausesValidation = false;
			this.cmdApprove.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 178);
			this.cmdApprove.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdApprove.Location = new System.Drawing.Point(404, 4);
			this.cmdApprove.Name = "cmdApprove";
			this.cmdApprove.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdApprove.Size = new System.Drawing.Size(79, 23);
			this.cmdApprove.TabIndex = 37;
			this.cmdApprove.Text = "&Approve";
			this.cmdApprove.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.cmdApprove.UseVisualStyleBackColor = false;
			this.cmdApprove.Visible = false;
			// this.cmdApprove.Click += new System.EventHandler(this.cmdApprove_Click);
			// 
			// txtExpenses
			// 
			this.txtExpenses.AllowDrop = true;
			this.txtExpenses.BackColor = System.Drawing.Color.FromArgb(239, 239, 239);
			// this.txtExpenses.DisplayFormat = "####0.000###;; ; ";
			this.txtExpenses.Enabled = false;
			// this.txtExpenses.Format = "#########0.000";
			this.txtExpenses.Location = new System.Drawing.Point(496, 33);
			// this.txtExpenses.MaxValue = 2147483647;
			// this.txtExpenses.MinValue = 0;
			this.txtExpenses.Name = "txtExpenses";
			this.txtExpenses.Size = new System.Drawing.Size(80, 23);
			this.txtExpenses.TabIndex = 38;
			this.txtExpenses.Text = "0.000";
			this.txtExpenses.Visible = false;
			// 
			// _lblCommonLabel_15
			// 
			this._lblCommonLabel_15.AllowDrop = true;
			this._lblCommonLabel_15.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_15.Text = "Misc Expenses";
			this._lblCommonLabel_15.ForeColor = System.Drawing.Color.Black;
			this._lblCommonLabel_15.Location = new System.Drawing.Point(401, 37);
			// // this._lblCommonLabel_15.mLabelId = 868;
			this._lblCommonLabel_15.Name = "_lblCommonLabel_15";
			this._lblCommonLabel_15.Size = new System.Drawing.Size(90, 16);
			this._lblCommonLabel_15.TabIndex = 95;
			this._lblCommonLabel_15.Visible = false;
			// 
			// txtPercentDiscount
			// 
			this.txtPercentDiscount.AllowDrop = true;
			// this.txtPercentDiscount.DisplayFormat = "#####0.######;;; ";
			// this.txtPercentDiscount.Format = "#####0.######";
			this.txtPercentDiscount.Location = new System.Drawing.Point(686, 2);
			// this.txtPercentDiscount.MaxValue = 100;
			// this.txtPercentDiscount.MinValue = 0;
			this.txtPercentDiscount.Name = "txtPercentDiscount";
			this.txtPercentDiscount.Size = new System.Drawing.Size(49, 23);
			this.txtPercentDiscount.TabIndex = 17;
			this.txtPercentDiscount.TabStop = false;
			// this.this.txtPercentDiscount.KeyDown += new System.Windows.Forms.TextBox.KeyDownHandler(this.txtPercentDiscount_KeyDown);
			// this.txtPercentDiscount.Leave += new System.EventHandler(this.txtPercentDiscount_Leave);
			this.txtPercentDiscount.MouseMove += new System.Windows.Forms.MouseEventHandler(this.txtPercentDiscount_MouseMove);
			// 
			// txtDiscount
			// 
			this.txtDiscount.AllowDrop = true;
			// this.txtDiscount.DisplayFormat = "####0.000###;;0.000;0.000";
			// this.txtDiscount.Format = "###########0.000";
			this.txtDiscount.Location = new System.Drawing.Point(736, 2);
			// this.txtDiscount.MaxValue = 2147483647;
			// this.txtDiscount.MinValue = 0;
			this.txtDiscount.Name = "txtDiscount";
			this.txtDiscount.Size = new System.Drawing.Size(87, 23);
			this.txtDiscount.TabIndex = 18;
			this.txtDiscount.Text = "0.000";
			// this.this.txtDiscount.KeyDown += new System.Windows.Forms.TextBox.KeyDownHandler(this.txtDiscount_KeyDown);
			// this.txtDiscount.Leave += new System.EventHandler(this.txtDiscount_Leave);
			// 
			// _lblCommonLabel_9
			// 
			this._lblCommonLabel_9.AllowDrop = true;
			this._lblCommonLabel_9.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_9.Text = "Narration";
			this._lblCommonLabel_9.ForeColor = System.Drawing.Color.Black;
			this._lblCommonLabel_9.Location = new System.Drawing.Point(3, 3);
			// // this._lblCommonLabel_9.mLabelId = 869;
			this._lblCommonLabel_9.Name = "_lblCommonLabel_9";
			this._lblCommonLabel_9.Size = new System.Drawing.Size(53, 16);
			this._lblCommonLabel_9.TabIndex = 96;
			// 
			// txtNetAmount
			// 
			this.txtNetAmount.AllowDrop = true;
			// this.txtNetAmount.DisplayFormat = "####0.000###;;0.000;0.000";
			this.txtNetAmount.Enabled = false;
			// this.txtNetAmount.Format = "###########0.000";
			this.txtNetAmount.Location = new System.Drawing.Point(736, 32);
			// this.txtNetAmount.MaxValue = 2147483647;
			// this.txtNetAmount.MinValue = -2147483648;
			this.txtNetAmount.Name = "txtNetAmount";
			this.txtNetAmount.Size = new System.Drawing.Size(87, 23);
			this.txtNetAmount.TabIndex = 19;
			this.txtNetAmount.Text = "0.000";
			this.txtNetAmount.Visible = false;
			// 
			// _lblCommonLabel_11
			// 
			this._lblCommonLabel_11.AllowDrop = true;
			this._lblCommonLabel_11.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_11.Text = "Total";
			this._lblCommonLabel_11.ForeColor = System.Drawing.Color.Black;
			this._lblCommonLabel_11.Location = new System.Drawing.Point(578, 38);
			// // this._lblCommonLabel_11.mLabelId = 449;
			this._lblCommonLabel_11.Name = "_lblCommonLabel_11";
			this._lblCommonLabel_11.Size = new System.Drawing.Size(32, 16);
			this._lblCommonLabel_11.TabIndex = 97;
			this._lblCommonLabel_11.Visible = false;
			// 
			// _lblCommonLabel_10
			// 
			this._lblCommonLabel_10.AllowDrop = true;
			this._lblCommonLabel_10.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_10.Text = "Discount (%)";
			this._lblCommonLabel_10.ForeColor = System.Drawing.Color.Black;
			this._lblCommonLabel_10.Location = new System.Drawing.Point(576, 6);
			// // this._lblCommonLabel_10.mLabelId = 871;
			this._lblCommonLabel_10.Name = "_lblCommonLabel_10";
			this._lblCommonLabel_10.Size = new System.Drawing.Size(75, 16);
			this._lblCommonLabel_10.TabIndex = 98;
			// 
			// _lblCommonLabel_12
			// 
			this._lblCommonLabel_12.AllowDrop = true;
			this._lblCommonLabel_12.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_12.Text = "Item Details :";
			this._lblCommonLabel_12.ForeColor = System.Drawing.Color.Black;
			this._lblCommonLabel_12.Location = new System.Drawing.Point(2, 49);
			// // this._lblCommonLabel_12.mLabelId = 879;
			this._lblCommonLabel_12.Name = "_lblCommonLabel_12";
			this._lblCommonLabel_12.Size = new System.Drawing.Size(77, 16);
			this._lblCommonLabel_12.TabIndex = 99;
			this._lblCommonLabel_12.Visible = false;
			// 
			// txtDiscount2Percent
			// 
			this.txtDiscount2Percent.AllowDrop = true;
			// this.txtDiscount2Percent.DisplayFormat = "#####0.######;;; ";
			// this.txtDiscount2Percent.Format = "#####0.######";
			this.txtDiscount2Percent.Location = new System.Drawing.Point(1092, 32);
			// this.txtDiscount2Percent.MaxValue = 100;
			// this.txtDiscount2Percent.MinValue = 0;
			this.txtDiscount2Percent.Name = "txtDiscount2Percent";
			this.txtDiscount2Percent.Size = new System.Drawing.Size(49, 23);
			this.txtDiscount2Percent.TabIndex = 158;
			// this.this.txtDiscount2Percent.Change += new System.Windows.Forms.TextBox.ChangeHandler(this.txtDiscount2Percent_Change);
			// this.txtDiscount2Percent.Leave += new System.EventHandler(this.txtDiscount2Percent_Leave);
			// 
			// txtDiscount2
			// 
			this.txtDiscount2.AllowDrop = true;
			// this.txtDiscount2.DisplayFormat = "####0.000###;;0.000;0.000";
			// this.txtDiscount2.Format = "###########0.000";
			this.txtDiscount2.Location = new System.Drawing.Point(1142, 32);
			// this.txtDiscount2.MaxValue = 2147483647;
			// this.txtDiscount2.MinValue = 0;
			this.txtDiscount2.Name = "txtDiscount2";
			this.txtDiscount2.Size = new System.Drawing.Size(87, 23);
			this.txtDiscount2.TabIndex = 159;
			this.txtDiscount2.Text = "0.000";
			// this.txtDiscount2.Leave += new System.EventHandler(this.txtDiscount2_Leave);
			// 
			// _lblCommonLabel_53
			// 
			this._lblCommonLabel_53.AllowDrop = true;
			this._lblCommonLabel_53.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_53.Text = "Display Discount (%)";
			this._lblCommonLabel_53.ForeColor = System.Drawing.Color.Black;
			this._lblCommonLabel_53.Location = new System.Drawing.Point(1092, 4);
			this._lblCommonLabel_53.Name = "_lblCommonLabel_53";
			this._lblCommonLabel_53.Size = new System.Drawing.Size(122, 16);
			this._lblCommonLabel_53.TabIndex = 160;
			// 
			// lblSave
			// 
			this.lblSave.AllowDrop = true;
			this.lblSave.AutoSize = true;
			this.lblSave.BackColor = System.Drawing.Color.Transparent;
			this.lblSave.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lblSave.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline | System.Drawing.FontStyle.Italic | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 178);
			this.lblSave.ForeColor = System.Drawing.Color.Blue;
			this.lblSave.Location = new System.Drawing.Point(488, 6);
			this.lblSave.Name = "lblSave";
			this.lblSave.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblSave.Size = new System.Drawing.Size(83, 16);
			this.lblSave.TabIndex = 100;
			this.lblSave.Text = "Payment (F6)";
			this.lblSave.Visible = false;
			// this.lblSave.Click += new System.EventHandler(this.lblSave_Click);
			// 
			// Line1
			// 
			this.Line1.AllowDrop = true;
			this.Line1.BackColor = System.Drawing.Color.Red;
			this.Line1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Line1.Enabled = false;
			this.Line1.ForeColor = System.Drawing.Color.Black;
			this.Line1.Location = new System.Drawing.Point(574, 28);
			this.Line1.Name = "Line1";
			this.Line1.Size = new System.Drawing.Size(249, 1);
			this.Line1.Text = "Line1";
			this.Line1.Visible = true;
			// 
			// tabMain
			// 
			this.tabMain.AllowDrop = true;
			this.tabMain.Controls.Add(this.tabOtherInfo);
			this.tabMain.Controls.Add(this.tabAdditionalInfo);
			this.tabMain.Controls.Add(this.tabGeneral);
			this.tabMain.Location = new System.Drawing.Point(2, 2);
			this.tabMain.Name = "tabMain";
			("tabMain.OcxState");
			this.tabMain.Size = new System.Drawing.Size(1203, 501);
			this.tabMain.TabIndex = 16;
			this.tabMain.TabStop = false;
			this.tabMain.SelectedChanged += new AxXtremeSuiteControls._DTabControlEvents_SelectedChangedEventHandler(this.tabMain_SelectedChanged);
			// 
			// tabOtherInfo
			// 
			this.tabOtherInfo.AllowDrop = true;
			this.tabOtherInfo.Controls.Add(this.Frame1);
			this.tabOtherInfo.Location = new System.Drawing.Point(-4664, 26);
			this.tabOtherInfo.Name = "tabOtherInfo";
			("tabOtherInfo.OcxState");
			this.tabOtherInfo.Size = new System.Drawing.Size(1199, 473);
			this.tabOtherInfo.TabIndex = 73;
			this.tabOtherInfo.Visible = false;
			// 
			// Frame1
			// 
			this.Frame1.AllowDrop = true;
			this.Frame1.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.Frame1.Controls.Add(this.txtNarration2);
			this.Frame1.Enabled = true;
			this.Frame1.ForeColor = System.Drawing.SystemColors.WindowText;
			this.Frame1.Location = new System.Drawing.Point(4, 0);
			this.Frame1.Name = "Frame1";
			this.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Frame1.Size = new System.Drawing.Size(971, 467);
			this.Frame1.TabIndex = 132;
			this.Frame1.Text = "Contact Information";
			this.Frame1.Visible = true;
			// 
			// txtNarration2
			// 
			this.txtNarration2.AllowDrop = true;
			// this.txtNarration2.bolAllowDecimal = false;
			this.txtNarration2.BorderStyle = 0;
			this.txtNarration2.Location = new System.Drawing.Point(6, 20);
			// this.txtNarration2.mDropDownType = (UCRichTextBox.RichTextBoxDropDownTypes) 0;
			this.txtNarration2.Name = "txtNarration2";
			this.txtNarration2.Size = new System.Drawing.Size(953, 435);
			this.txtNarration2.TabIndex = 66;
			this.txtNarration2.Text = "";
			this.txtNarration2.TextRTF = "0";
			// 
			// tabAdditionalInfo
			// 
			this.tabAdditionalInfo.AllowDrop = true;
			this.tabAdditionalInfo.Controls.Add(this.farDeliveryDeetail);
			this.tabAdditionalInfo.Controls.Add(this.fraPaymentDetail);
			this.tabAdditionalInfo.Controls.Add(this.fraOrderDetail);
			this.tabAdditionalInfo.Controls.Add(this.fraContactDetail);
			this.tabAdditionalInfo.Location = new System.Drawing.Point(-4664, 26);
			this.tabAdditionalInfo.Name = "tabAdditionalInfo";
			("tabAdditionalInfo.OcxState");
			this.tabAdditionalInfo.Size = new System.Drawing.Size(1199, 473);
			this.tabAdditionalInfo.TabIndex = 72;
			this.tabAdditionalInfo.Visible = false;
			// 
			// farDeliveryDeetail
			// 
			this.farDeliveryDeetail.AllowDrop = true;
			this.farDeliveryDeetail.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.farDeliveryDeetail.Controls.Add(this._comCommon_2);
			this.farDeliveryDeetail.Controls.Add(this._lblCommonLabel_37);
			this.farDeliveryDeetail.Controls.Add(this.Label2);
			this.farDeliveryDeetail.Controls.Add(this.txtShipmentNo);
			this.farDeliveryDeetail.Controls.Add(this._comCommon_3);
			this.farDeliveryDeetail.Controls.Add(this._lblCommonLabel_38);
			this.farDeliveryDeetail.Controls.Add(this._comCommon_4);
			this.farDeliveryDeetail.Controls.Add(this._lblCommonLabel_39);
			this.farDeliveryDeetail.Controls.Add(this._lblCommonLabel_40);
			this.farDeliveryDeetail.Controls.Add(this.txtDeliveryTerms);
			this.farDeliveryDeetail.Controls.Add(this._lblCommonLabel_42);
			this.farDeliveryDeetail.Controls.Add(this.txtPackingListNo);
			this.farDeliveryDeetail.Controls.Add(this._lblCommonLabel_43);
			this.farDeliveryDeetail.Controls.Add(this.txtDeliveryLocation);
			this.farDeliveryDeetail.Controls.Add(this._comCommon_5);
			this.farDeliveryDeetail.Controls.Add(this._lblCommonLabel_45);
			this.farDeliveryDeetail.Controls.Add(this._lblCommonLabel_46);
			this.farDeliveryDeetail.Controls.Add(this._txtCommonTextBox_0);
			this.farDeliveryDeetail.Enabled = true;
			this.farDeliveryDeetail.ForeColor = System.Drawing.SystemColors.WindowText;
			this.farDeliveryDeetail.Location = new System.Drawing.Point(480, 4);
			this.farDeliveryDeetail.Name = "farDeliveryDeetail";
			this.farDeliveryDeetail.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.farDeliveryDeetail.Size = new System.Drawing.Size(455, 149);
			this.farDeliveryDeetail.TabIndex = 122;
			this.farDeliveryDeetail.Text = "Delivery Information";
			this.farDeliveryDeetail.Visible = true;
			// 
			// _comCommon_2
			// 
			this._comCommon_2.AllowDrop = true;
			this._comCommon_2.Location = new System.Drawing.Point(103, 116);
			this._comCommon_2.Name = "_comCommon_2";
			this._comCommon_2.Size = new System.Drawing.Size(101, 21);
			this._comCommon_2.TabIndex = 55;
			// 
			// _lblCommonLabel_37
			// 
			this._lblCommonLabel_37.AllowDrop = true;
			this._lblCommonLabel_37.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_37.Text = "Shipment Mode";
			this._lblCommonLabel_37.ForeColor = System.Drawing.Color.Black;
			this._lblCommonLabel_37.Location = new System.Drawing.Point(2, 118);
			// // this._lblCommonLabel_37.mLabelId = 2038;
			this._lblCommonLabel_37.Name = "_lblCommonLabel_37";
			this._lblCommonLabel_37.Size = new System.Drawing.Size(73, 14);
			this._lblCommonLabel_37.TabIndex = 123;
			// 
			// System.Windows.Forms.Label2
			// 
			this.Label2.AllowDrop = true;
			this.Label2.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.Label2.Text = "Shipment No.";
			this.Label2.ForeColor = System.Drawing.Color.Black;
			this.Label2.Location = new System.Drawing.Point(237, 19);
			// this.Label2.mLabelId = 2034;
			this.Label2.Name = "System.Windows.Forms.Label2";
			this.Label2.Size = new System.Drawing.Size(63, 14);
			this.Label2.TabIndex = 124;
			// 
			// txtShipmentNo
			// 
			this.txtShipmentNo.AllowDrop = true;
			this.txtShipmentNo.BackColor = System.Drawing.Color.White;
			this.txtShipmentNo.ForeColor = System.Drawing.Color.Black;
			this.txtShipmentNo.Location = new System.Drawing.Point(329, 17);
			this.txtShipmentNo.MaxLength = 100;
			this.txtShipmentNo.Name = "txtShipmentNo";
			this.txtShipmentNo.Size = new System.Drawing.Size(119, 19);
			this.txtShipmentNo.TabIndex = 56;
			this.txtShipmentNo.Text = "";
			// this.this.txtShipmentNo.Watermark = "";
			// 
			// _comCommon_3
			// 
			this._comCommon_3.AllowDrop = true;
			this._comCommon_3.Location = new System.Drawing.Point(329, 116);
			this._comCommon_3.Name = "_comCommon_3";
			this._comCommon_3.Size = new System.Drawing.Size(119, 21);
			this._comCommon_3.TabIndex = 57;
			// 
			// _lblCommonLabel_38
			// 
			this._lblCommonLabel_38.AllowDrop = true;
			this._lblCommonLabel_38.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_38.Text = "Shipment No. Type";
			this._lblCommonLabel_38.ForeColor = System.Drawing.Color.Black;
			this._lblCommonLabel_38.Location = new System.Drawing.Point(237, 118);
			// // this._lblCommonLabel_38.mLabelId = 2039;
			this._lblCommonLabel_38.Name = "_lblCommonLabel_38";
			this._lblCommonLabel_38.Size = new System.Drawing.Size(90, 14);
			this._lblCommonLabel_38.TabIndex = 125;
			// 
			// _comCommon_4
			// 
			this._comCommon_4.AllowDrop = true;
			this._comCommon_4.Location = new System.Drawing.Point(329, 92);
			this._comCommon_4.Name = "_comCommon_4";
			this._comCommon_4.Size = new System.Drawing.Size(119, 21);
			this._comCommon_4.TabIndex = 58;
			// 
			// _lblCommonLabel_39
			// 
			this._lblCommonLabel_39.AllowDrop = true;
			this._lblCommonLabel_39.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_39.Text = "Delivery Period";
			this._lblCommonLabel_39.ForeColor = System.Drawing.Color.Black;
			this._lblCommonLabel_39.Location = new System.Drawing.Point(237, 92);
			// // this._lblCommonLabel_39.mLabelId = 2037;
			this._lblCommonLabel_39.Name = "_lblCommonLabel_39";
			this._lblCommonLabel_39.Size = new System.Drawing.Size(72, 14);
			this._lblCommonLabel_39.TabIndex = 126;
			// 
			// _lblCommonLabel_40
			// 
			this._lblCommonLabel_40.AllowDrop = true;
			this._lblCommonLabel_40.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_40.Text = "Delivery Location";
			this._lblCommonLabel_40.ForeColor = System.Drawing.Color.Black;
			this._lblCommonLabel_40.Location = new System.Drawing.Point(237, 45);
			// // this._lblCommonLabel_40.mLabelId = 2033;
			this._lblCommonLabel_40.Name = "_lblCommonLabel_40";
			this._lblCommonLabel_40.Size = new System.Drawing.Size(83, 14);
			this._lblCommonLabel_40.TabIndex = 127;
			// 
			// txtDeliveryTerms
			// 
			this.txtDeliveryTerms.AllowDrop = true;
			this.txtDeliveryTerms.BackColor = System.Drawing.Color.White;
			this.txtDeliveryTerms.ForeColor = System.Drawing.Color.Black;
			this.txtDeliveryTerms.Location = new System.Drawing.Point(103, 68);
			this.txtDeliveryTerms.MaxLength = 100;
			this.txtDeliveryTerms.Name = "txtDeliveryTerms";
			this.txtDeliveryTerms.Size = new System.Drawing.Size(344, 19);
			this.txtDeliveryTerms.TabIndex = 59;
			this.txtDeliveryTerms.Text = "";
			// this.this.txtDeliveryTerms.Watermark = "";
			// 
			// _lblCommonLabel_42
			// 
			this._lblCommonLabel_42.AllowDrop = true;
			this._lblCommonLabel_42.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_42.Text = "Delivery Terms";
			this._lblCommonLabel_42.ForeColor = System.Drawing.Color.Black;
			this._lblCommonLabel_42.Location = new System.Drawing.Point(2, 70);
			// // this._lblCommonLabel_42.mLabelId = 2032;
			this._lblCommonLabel_42.Name = "_lblCommonLabel_42";
			this._lblCommonLabel_42.Size = new System.Drawing.Size(72, 14);
			this._lblCommonLabel_42.TabIndex = 128;
			// 
			// txtPackingListNo
			// 
			this.txtPackingListNo.AllowDrop = true;
			this.txtPackingListNo.BackColor = System.Drawing.Color.White;
			this.txtPackingListNo.ForeColor = System.Drawing.Color.Black;
			this.txtPackingListNo.Location = new System.Drawing.Point(103, 16);
			this.txtPackingListNo.MaxLength = 100;
			this.txtPackingListNo.Name = "txtPackingListNo";
			this.txtPackingListNo.Size = new System.Drawing.Size(101, 19);
			this.txtPackingListNo.TabIndex = 60;
			this.txtPackingListNo.Text = "";
			// this.this.txtPackingListNo.Watermark = "";
			// 
			// _lblCommonLabel_43
			// 
			this._lblCommonLabel_43.AllowDrop = true;
			this._lblCommonLabel_43.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_43.Text = "Packing List No.";
			this._lblCommonLabel_43.ForeColor = System.Drawing.Color.Black;
			this._lblCommonLabel_43.Location = new System.Drawing.Point(2, 20);
			// // this._lblCommonLabel_43.mLabelId = 2035;
			this._lblCommonLabel_43.Name = "_lblCommonLabel_43";
			this._lblCommonLabel_43.Size = new System.Drawing.Size(76, 14);
			this._lblCommonLabel_43.TabIndex = 129;
			// 
			// txtDeliveryLocation
			// 
			this.txtDeliveryLocation.AllowDrop = true;
			this.txtDeliveryLocation.BackColor = System.Drawing.Color.White;
			this.txtDeliveryLocation.ForeColor = System.Drawing.Color.Black;
			this.txtDeliveryLocation.Location = new System.Drawing.Point(329, 42);
			this.txtDeliveryLocation.MaxLength = 100;
			this.txtDeliveryLocation.Name = "txtDeliveryLocation";
			this.txtDeliveryLocation.Size = new System.Drawing.Size(119, 19);
			this.txtDeliveryLocation.TabIndex = 61;
			this.txtDeliveryLocation.Text = "";
			// this.this.txtDeliveryLocation.Watermark = "";
			// 
			// _comCommon_5
			// 
			this._comCommon_5.AllowDrop = true;
			this._comCommon_5.Location = new System.Drawing.Point(103, 92);
			this._comCommon_5.Name = "_comCommon_5";
			this._comCommon_5.Size = new System.Drawing.Size(101, 21);
			this._comCommon_5.TabIndex = 62;
			// 
			// _lblCommonLabel_45
			// 
			this._lblCommonLabel_45.AllowDrop = true;
			this._lblCommonLabel_45.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_45.Text = "Trans Type";
			this._lblCommonLabel_45.ForeColor = System.Drawing.Color.Black;
			this._lblCommonLabel_45.Location = new System.Drawing.Point(2, 92);
			// // this._lblCommonLabel_45.mLabelId = 2036;
			this._lblCommonLabel_45.Name = "_lblCommonLabel_45";
			this._lblCommonLabel_45.Size = new System.Drawing.Size(55, 14);
			this._lblCommonLabel_45.TabIndex = 130;
			// 
			// _lblCommonLabel_46
			// 
			this._lblCommonLabel_46.AllowDrop = true;
			this._lblCommonLabel_46.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_46.Text = "Bid No";
			this._lblCommonLabel_46.ForeColor = System.Drawing.Color.Black;
			this._lblCommonLabel_46.Location = new System.Drawing.Point(2, 44);
			// // this._lblCommonLabel_46.mLabelId = 2044;
			this._lblCommonLabel_46.Name = "_lblCommonLabel_46";
			this._lblCommonLabel_46.Size = new System.Drawing.Size(31, 14);
			this._lblCommonLabel_46.TabIndex = 131;
			this._lblCommonLabel_46.Visible = false;
			// 
			// _txtCommonTextBox_0
			// 
			this._txtCommonTextBox_0.AllowDrop = true;
			this._txtCommonTextBox_0.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_0.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_0.Location = new System.Drawing.Point(103, 42);
			this._txtCommonTextBox_0.MaxLength = 20;
			this._txtCommonTextBox_0.Name = "_txtCommonTextBox_0";
			// this._txtCommonTextBox_0.ShowButton = true;
			this._txtCommonTextBox_0.Size = new System.Drawing.Size(101, 19);
			this._txtCommonTextBox_0.TabIndex = 63;
			this._txtCommonTextBox_0.Text = "";
			this._txtCommonTextBox_0.Visible = false;
			// this.this._txtCommonTextBox_0.Watermark = "";
			// this.this._txtCommonTextBox_0.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_0.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// fraPaymentDetail
			// 
			this.fraPaymentDetail.AllowDrop = true;
			this.fraPaymentDetail.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.fraPaymentDetail.Controls.Add(this._lblCommonLabel_41);
			this.fraPaymentDetail.Controls.Add(this.txtPaymentTerms);
			this.fraPaymentDetail.Controls.Add(this._comCommon_1);
			this.fraPaymentDetail.Controls.Add(this._lblCommonLabel_36);
			this.fraPaymentDetail.Controls.Add(this.Label1);
			this.fraPaymentDetail.Controls.Add(this.txtDrawnOnBank);
			this.fraPaymentDetail.Controls.Add(this.txtNAdditionalExpenses);
			this.fraPaymentDetail.Controls.Add(this._lblCommonLabel_44);
			this.fraPaymentDetail.Enabled = true;
			this.fraPaymentDetail.ForeColor = System.Drawing.SystemColors.WindowText;
			this.fraPaymentDetail.Location = new System.Drawing.Point(480, 162);
			this.fraPaymentDetail.Name = "fraPaymentDetail";
			this.fraPaymentDetail.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.fraPaymentDetail.Size = new System.Drawing.Size(455, 95);
			this.fraPaymentDetail.TabIndex = 117;
			this.fraPaymentDetail.Text = "Payment Information";
			this.fraPaymentDetail.Visible = true;
			// 
			// _lblCommonLabel_41
			// 
			this._lblCommonLabel_41.AllowDrop = true;
			this._lblCommonLabel_41.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_41.Text = "Payment Terms";
			this._lblCommonLabel_41.ForeColor = System.Drawing.Color.Black;
			this._lblCommonLabel_41.Location = new System.Drawing.Point(2, 20);
			// // this._lblCommonLabel_41.mLabelId = 2031;
			this._lblCommonLabel_41.Name = "_lblCommonLabel_41";
			this._lblCommonLabel_41.Size = new System.Drawing.Size(74, 14);
			this._lblCommonLabel_41.TabIndex = 118;
			// 
			// txtPaymentTerms
			// 
			this.txtPaymentTerms.AllowDrop = true;
			this.txtPaymentTerms.BackColor = System.Drawing.Color.White;
			this.txtPaymentTerms.ForeColor = System.Drawing.Color.Black;
			this.txtPaymentTerms.Location = new System.Drawing.Point(103, 18);
			this.txtPaymentTerms.MaxLength = 100;
			this.txtPaymentTerms.Name = "txtPaymentTerms";
			this.txtPaymentTerms.Size = new System.Drawing.Size(344, 19);
			this.txtPaymentTerms.TabIndex = 51;
			this.txtPaymentTerms.Text = "";
			// this.this.txtPaymentTerms.Watermark = "";
			// 
			// _comCommon_1
			// 
			this._comCommon_1.AllowDrop = true;
			this._comCommon_1.Location = new System.Drawing.Point(103, 40);
			this._comCommon_1.Name = "_comCommon_1";
			this._comCommon_1.Size = new System.Drawing.Size(345, 21);
			this._comCommon_1.TabIndex = 52;
			// 
			// _lblCommonLabel_36
			// 
			this._lblCommonLabel_36.AllowDrop = true;
			this._lblCommonLabel_36.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_36.Text = "Payment Mode";
			this._lblCommonLabel_36.ForeColor = System.Drawing.Color.Black;
			this._lblCommonLabel_36.Location = new System.Drawing.Point(2, 42);
			// // this._lblCommonLabel_36.mLabelId = 942;
			this._lblCommonLabel_36.Name = "_lblCommonLabel_36";
			this._lblCommonLabel_36.Size = new System.Drawing.Size(70, 14);
			this._lblCommonLabel_36.TabIndex = 119;
			// 
			// System.Windows.Forms.Label1
			// 
			this.Label1.AllowDrop = true;
			this.Label1.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.Label1.Text = "Drawn on Bank";
			this.Label1.ForeColor = System.Drawing.Color.Black;
			this.Label1.Location = new System.Drawing.Point(239, 68);
			// this.Label1.mLabelId = 947;
			this.Label1.Name = "System.Windows.Forms.Label1";
			this.Label1.Size = new System.Drawing.Size(75, 14);
			this.Label1.TabIndex = 120;
			// 
			// txtDrawnOnBank
			// 
			this.txtDrawnOnBank.AllowDrop = true;
			this.txtDrawnOnBank.BackColor = System.Drawing.Color.White;
			this.txtDrawnOnBank.ForeColor = System.Drawing.Color.Black;
			this.txtDrawnOnBank.Location = new System.Drawing.Point(329, 66);
			this.txtDrawnOnBank.MaxLength = 100;
			this.txtDrawnOnBank.Name = "txtDrawnOnBank";
			this.txtDrawnOnBank.Size = new System.Drawing.Size(119, 19);
			this.txtDrawnOnBank.TabIndex = 53;
			this.txtDrawnOnBank.Text = "";
			// this.this.txtDrawnOnBank.Watermark = "";
			// 
			// txtNAdditionalExpenses
			// 
			this.txtNAdditionalExpenses.AllowDrop = true;
			// this.txtNAdditionalExpenses.DisplayFormat = "####0.000###;;0.000;0.000";
			// this.txtNAdditionalExpenses.Format = "###########0.000";
			this.txtNAdditionalExpenses.Location = new System.Drawing.Point(103, 66);
			// this.txtNAdditionalExpenses.MaxValue = 2147483647;
			// this.txtNAdditionalExpenses.MinValue = -2147483648;
			this.txtNAdditionalExpenses.Name = "txtNAdditionalExpenses";
			this.txtNAdditionalExpenses.Size = new System.Drawing.Size(101, 19);
			this.txtNAdditionalExpenses.TabIndex = 54;
			this.txtNAdditionalExpenses.Text = "0.000";
			// 
			// _lblCommonLabel_44
			// 
			this._lblCommonLabel_44.AllowDrop = true;
			this._lblCommonLabel_44.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_44.Text = "Additional Expenses";
			this._lblCommonLabel_44.ForeColor = System.Drawing.Color.Black;
			this._lblCommonLabel_44.Location = new System.Drawing.Point(2, 70);
			this._lblCommonLabel_44.Name = "_lblCommonLabel_44";
			this._lblCommonLabel_44.Size = new System.Drawing.Size(98, 14);
			this._lblCommonLabel_44.TabIndex = 121;
			// 
			// fraOrderDetail
			// 
			this.fraOrderDetail.AllowDrop = true;
			this.fraOrderDetail.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.fraOrderDetail.Controls.Add(this.txtCreditCardDate);
			this.fraOrderDetail.Controls.Add(this.lblRefrenceOrderDate);
			this.fraOrderDetail.Controls.Add(this.lblChequeDate);
			this.fraOrderDetail.Controls.Add(this.lblCreditCardDate);
			this.fraOrderDetail.Controls.Add(this.txtRefrenceOrderDate);
			this.fraOrderDetail.Controls.Add(this.txtChequeDate);
			this.fraOrderDetail.Controls.Add(this.txtCreditCardNo);
			this.fraOrderDetail.Controls.Add(this.txtRefOrderNo);
			this.fraOrderDetail.Controls.Add(this.txtChequeNo);
			this.fraOrderDetail.Controls.Add(this._lblCommonLabel_32);
			this.fraOrderDetail.Controls.Add(this._lblCommonLabel_33);
			this.fraOrderDetail.Controls.Add(this._lblCommonLabel_34);
			this.fraOrderDetail.Enabled = true;
			this.fraOrderDetail.ForeColor = System.Drawing.SystemColors.WindowText;
			this.fraOrderDetail.Location = new System.Drawing.Point(16, 258);
			this.fraOrderDetail.Name = "fraOrderDetail";
			this.fraOrderDetail.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.fraOrderDetail.Size = new System.Drawing.Size(455, 85);
			this.fraOrderDetail.TabIndex = 110;
			this.fraOrderDetail.Text = "Order Information";
			this.fraOrderDetail.Visible = true;
			// 
			// txtCreditCardDate
			// 
			this.txtCreditCardDate.AllowDrop = true;
			// this.txtCreditCardDate.CheckDateRange = false;
			this.txtCreditCardDate.Location = new System.Drawing.Point(329, 58);
			// this.txtCreditCardDate.MaxDate = 2958465;
			// this.txtCreditCardDate.MinDate = 2;
			this.txtCreditCardDate.Name = "txtCreditCardDate";
			this.txtCreditCardDate.Size = new System.Drawing.Size(119, 19);
			this.txtCreditCardDate.TabIndex = 45;
			// this.txtCreditCardDate.Text = "04-Feb-2002";
			// this.txtCreditCardDate.Value = 37291;
			// 
			// lblRefrenceOrderDate
			// 
			this.lblRefrenceOrderDate.AllowDrop = true;
			this.lblRefrenceOrderDate.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			// this.lblRefrenceOrderDate.Text = "Ref. Order Date";
			this.lblRefrenceOrderDate.ForeColor = System.Drawing.Color.Black;
			this.lblRefrenceOrderDate.Location = new System.Drawing.Point(237, 18);
			// // this.lblRefrenceOrderDate.mLabelId = 944;
			this.lblRefrenceOrderDate.Name = "lblRefrenceOrderDate";
			this.lblRefrenceOrderDate.Size = new System.Drawing.Size(76, 14);
			this.lblRefrenceOrderDate.TabIndex = 111;
			// 
			// lblChequeDate
			// 
			this.lblChequeDate.AllowDrop = true;
			this.lblChequeDate.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			// this.lblChequeDate.Text = "Cheque Date";
			this.lblChequeDate.ForeColor = System.Drawing.Color.Black;
			this.lblChequeDate.Location = new System.Drawing.Point(237, 39);
			// // this.lblChequeDate.mLabelId = 945;
			this.lblChequeDate.Name = "lblChequeDate";
			this.lblChequeDate.Size = new System.Drawing.Size(62, 14);
			this.lblChequeDate.TabIndex = 112;
			// 
			// lblCreditCardDate
			// 
			this.lblCreditCardDate.AllowDrop = true;
			this.lblCreditCardDate.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			// this.lblCreditCardDate.Text = "Credit Card Date ";
			this.lblCreditCardDate.ForeColor = System.Drawing.Color.Black;
			this.lblCreditCardDate.Location = new System.Drawing.Point(237, 60);
			// // this.lblCreditCardDate.mLabelId = 946;
			this.lblCreditCardDate.Name = "lblCreditCardDate";
			this.lblCreditCardDate.Size = new System.Drawing.Size(82, 14);
			this.lblCreditCardDate.TabIndex = 113;
			// 
			// txtRefrenceOrderDate
			// 
			this.txtRefrenceOrderDate.AllowDrop = true;
			// this.txtRefrenceOrderDate.CheckDateRange = false;
			this.txtRefrenceOrderDate.Location = new System.Drawing.Point(329, 16);
			// this.txtRefrenceOrderDate.MaxDate = 2958465;
			// this.txtRefrenceOrderDate.MinDate = 2;
			this.txtRefrenceOrderDate.Name = "txtRefrenceOrderDate";
			this.txtRefrenceOrderDate.Size = new System.Drawing.Size(119, 19);
			this.txtRefrenceOrderDate.TabIndex = 46;
			// this.txtRefrenceOrderDate.Text = "04-Jan-2002";
			// this.txtRefrenceOrderDate.Value = 37260;
			// 
			// txtChequeDate
			// 
			this.txtChequeDate.AllowDrop = true;
			// this.txtChequeDate.CheckDateRange = false;
			this.txtChequeDate.Location = new System.Drawing.Point(329, 37);
			// this.txtChequeDate.MaxDate = 2958465;
			// this.txtChequeDate.MinDate = 2;
			this.txtChequeDate.Name = "txtChequeDate";
			this.txtChequeDate.Size = new System.Drawing.Size(119, 19);
			this.txtChequeDate.TabIndex = 47;
			// this.txtChequeDate.Text = "04-Jan-2002";
			// this.txtChequeDate.Value = 37260;
			// 
			// txtCreditCardNo
			// 
			this.txtCreditCardNo.AllowDrop = true;
			this.txtCreditCardNo.BackColor = System.Drawing.Color.White;
			this.txtCreditCardNo.ForeColor = System.Drawing.Color.Black;
			this.txtCreditCardNo.Location = new System.Drawing.Point(105, 58);
			this.txtCreditCardNo.MaxLength = 100;
			this.txtCreditCardNo.Name = "txtCreditCardNo";
			this.txtCreditCardNo.Size = new System.Drawing.Size(101, 19);
			this.txtCreditCardNo.TabIndex = 48;
			this.txtCreditCardNo.Text = "";
			// this.this.txtCreditCardNo.Watermark = "";
			// 
			// txtRefOrderNo
			// 
			this.txtRefOrderNo.AllowDrop = true;
			this.txtRefOrderNo.BackColor = System.Drawing.Color.White;
			this.txtRefOrderNo.ForeColor = System.Drawing.Color.Black;
			this.txtRefOrderNo.Location = new System.Drawing.Point(105, 16);
			this.txtRefOrderNo.MaxLength = 100;
			this.txtRefOrderNo.Name = "txtRefOrderNo";
			this.txtRefOrderNo.Size = new System.Drawing.Size(101, 19);
			this.txtRefOrderNo.TabIndex = 49;
			this.txtRefOrderNo.Text = "";
			// this.this.txtRefOrderNo.Watermark = "";
			// 
			// txtChequeNo
			// 
			this.txtChequeNo.AllowDrop = true;
			this.txtChequeNo.BackColor = System.Drawing.Color.White;
			this.txtChequeNo.ForeColor = System.Drawing.Color.Black;
			this.txtChequeNo.Location = new System.Drawing.Point(105, 37);
			this.txtChequeNo.MaxLength = 100;
			this.txtChequeNo.Name = "txtChequeNo";
			this.txtChequeNo.Size = new System.Drawing.Size(101, 19);
			this.txtChequeNo.TabIndex = 50;
			this.txtChequeNo.Text = "";
			// this.this.txtChequeNo.Watermark = "";
			// 
			// _lblCommonLabel_32
			// 
			this._lblCommonLabel_32.AllowDrop = true;
			this._lblCommonLabel_32.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_32.Text = "Ref. Order No.";
			this._lblCommonLabel_32.ForeColor = System.Drawing.Color.Black;
			this._lblCommonLabel_32.Location = new System.Drawing.Point(8, 18);
			// // this._lblCommonLabel_32.mLabelId = 939;
			this._lblCommonLabel_32.Name = "_lblCommonLabel_32";
			this._lblCommonLabel_32.Size = new System.Drawing.Size(70, 14);
			this._lblCommonLabel_32.TabIndex = 114;
			// 
			// _lblCommonLabel_33
			// 
			this._lblCommonLabel_33.AllowDrop = true;
			this._lblCommonLabel_33.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_33.Text = "Cheque No.";
			this._lblCommonLabel_33.ForeColor = System.Drawing.Color.Black;
			this._lblCommonLabel_33.Location = new System.Drawing.Point(8, 39);
			// // this._lblCommonLabel_33.mLabelId = 940;
			this._lblCommonLabel_33.Name = "_lblCommonLabel_33";
			this._lblCommonLabel_33.Size = new System.Drawing.Size(56, 14);
			this._lblCommonLabel_33.TabIndex = 115;
			// 
			// _lblCommonLabel_34
			// 
			this._lblCommonLabel_34.AllowDrop = true;
			this._lblCommonLabel_34.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_34.Text = "Credit Card No.";
			this._lblCommonLabel_34.ForeColor = System.Drawing.Color.Black;
			this._lblCommonLabel_34.Location = new System.Drawing.Point(8, 60);
			// // this._lblCommonLabel_34.mLabelId = 941;
			this._lblCommonLabel_34.Name = "_lblCommonLabel_34";
			this._lblCommonLabel_34.Size = new System.Drawing.Size(73, 14);
			this._lblCommonLabel_34.TabIndex = 116;
			// 
			// fraContactDetail
			// 
			this.fraContactDetail.AllowDrop = true;
			this.fraContactDetail.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.fraContactDetail.Controls.Add(this._lblCommonLabel_18);
			this.fraContactDetail.Controls.Add(this.txtLdgrName);
			this.fraContactDetail.Controls.Add(this._lblCommonLabel_30);
			this.fraContactDetail.Controls.Add(this._lblCommonLabel_35);
			this.fraContactDetail.Controls.Add(this.txtPhone);
			this.fraContactDetail.Controls.Add(this._lblCommonLabel_31);
			this.fraContactDetail.Controls.Add(this._lblCommonLabel_0);
			this.fraContactDetail.Controls.Add(this._lblCommonLabel_1);
			this.fraContactDetail.Controls.Add(this._lblCommonLabel_13);
			this.fraContactDetail.Controls.Add(this.txtBlockNo);
			this.fraContactDetail.Controls.Add(this.txtCountry);
			this.fraContactDetail.Controls.Add(this.txtStreetNo);
			this.fraContactDetail.Controls.Add(this._lblCommonLabel_16);
			this.fraContactDetail.Controls.Add(this.txtCity);
			this.fraContactDetail.Controls.Add(this.txtAdd1);
			this.fraContactDetail.Controls.Add(this.txtAdd2);
			this.fraContactDetail.Enabled = true;
			this.fraContactDetail.ForeColor = System.Drawing.SystemColors.WindowText;
			this.fraContactDetail.Location = new System.Drawing.Point(16, 4);
			this.fraContactDetail.Name = "fraContactDetail";
			this.fraContactDetail.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.fraContactDetail.Size = new System.Drawing.Size(455, 253);
			this.fraContactDetail.TabIndex = 101;
			this.fraContactDetail.Text = "Contact Information";
			this.fraContactDetail.Visible = true;
			// 
			// _lblCommonLabel_18
			// 
			this._lblCommonLabel_18.AllowDrop = true;
			this._lblCommonLabel_18.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_18.Text = "Customer Name";
			this._lblCommonLabel_18.ForeColor = System.Drawing.Color.Black;
			this._lblCommonLabel_18.Location = new System.Drawing.Point(8, 20);
			// // this._lblCommonLabel_18.mLabelId = 935;
			this._lblCommonLabel_18.Name = "_lblCommonLabel_18";
			this._lblCommonLabel_18.Size = new System.Drawing.Size(76, 14);
			this._lblCommonLabel_18.TabIndex = 102;
			// 
			// txtLdgrName
			// 
			this.txtLdgrName.AllowDrop = true;
			this.txtLdgrName.BackColor = System.Drawing.Color.White;
			this.txtLdgrName.ForeColor = System.Drawing.Color.Black;
			this.txtLdgrName.Location = new System.Drawing.Point(103, 18);
			this.txtLdgrName.MaxLength = 100;
			this.txtLdgrName.Name = "txtLdgrName";
			this.txtLdgrName.Size = new System.Drawing.Size(344, 19);
			this.txtLdgrName.TabIndex = 39;
			this.txtLdgrName.Tag = "Salesman Name in English";
			this.txtLdgrName.Text = "";
			// this.this.txtLdgrName.Watermark = "";
			// 
			// _lblCommonLabel_30
			// 
			this._lblCommonLabel_30.AllowDrop = true;
			this._lblCommonLabel_30.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_30.Text = "Address 1";
			this._lblCommonLabel_30.ForeColor = System.Drawing.Color.Black;
			this._lblCommonLabel_30.Location = new System.Drawing.Point(8, 43);
			// // this._lblCommonLabel_30.mLabelId = 936;
			this._lblCommonLabel_30.Name = "_lblCommonLabel_30";
			this._lblCommonLabel_30.Size = new System.Drawing.Size(51, 14);
			this._lblCommonLabel_30.TabIndex = 103;
			// 
			// _lblCommonLabel_35
			// 
			this._lblCommonLabel_35.AllowDrop = true;
			this._lblCommonLabel_35.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_35.Text = "Address 2";
			this._lblCommonLabel_35.ForeColor = System.Drawing.Color.Black;
			this._lblCommonLabel_35.Location = new System.Drawing.Point(8, 117);
			// // this._lblCommonLabel_35.mLabelId = 937;
			this._lblCommonLabel_35.Name = "_lblCommonLabel_35";
			this._lblCommonLabel_35.Size = new System.Drawing.Size(51, 14);
			this._lblCommonLabel_35.TabIndex = 104;
			// 
			// txtPhone
			// 
			this.txtPhone.AllowDrop = true;
			this.txtPhone.BackColor = System.Drawing.Color.White;
			this.txtPhone.ForeColor = System.Drawing.Color.Black;
			this.txtPhone.Location = new System.Drawing.Point(103, 230);
			this.txtPhone.MaxLength = 100;
			this.txtPhone.Name = "txtPhone";
			this.txtPhone.Size = new System.Drawing.Size(101, 19);
			this.txtPhone.TabIndex = 40;
			this.txtPhone.Text = "";
			// this.this.txtPhone.Watermark = "";
			// 
			// _lblCommonLabel_31
			// 
			this._lblCommonLabel_31.AllowDrop = true;
			this._lblCommonLabel_31.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_31.Text = "Phone";
			this._lblCommonLabel_31.ForeColor = System.Drawing.Color.Black;
			this._lblCommonLabel_31.Location = new System.Drawing.Point(8, 232);
			// // this._lblCommonLabel_31.mLabelId = 524;
			this._lblCommonLabel_31.Name = "_lblCommonLabel_31";
			this._lblCommonLabel_31.Size = new System.Drawing.Size(30, 14);
			this._lblCommonLabel_31.TabIndex = 105;
			// 
			// _lblCommonLabel_0
			// 
			this._lblCommonLabel_0.AllowDrop = true;
			this._lblCommonLabel_0.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_0.Text = "City";
			this._lblCommonLabel_0.ForeColor = System.Drawing.Color.Black;
			this._lblCommonLabel_0.Location = new System.Drawing.Point(8, 209);
			// // this._lblCommonLabel_0.mLabelId = 123;
			this._lblCommonLabel_0.Name = "_lblCommonLabel_0";
			this._lblCommonLabel_0.Size = new System.Drawing.Size(18, 14);
			this._lblCommonLabel_0.TabIndex = 106;
			// 
			// _lblCommonLabel_1
			// 
			this._lblCommonLabel_1.AllowDrop = true;
			this._lblCommonLabel_1.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_1.Text = "Block No.";
			this._lblCommonLabel_1.ForeColor = System.Drawing.Color.Black;
			this._lblCommonLabel_1.Location = new System.Drawing.Point(237, 190);
			// // this._lblCommonLabel_1.mLabelId = 943;
			this._lblCommonLabel_1.Name = "_lblCommonLabel_1";
			this._lblCommonLabel_1.Size = new System.Drawing.Size(45, 14);
			this._lblCommonLabel_1.TabIndex = 107;
			// 
			// _lblCommonLabel_13
			// 
			this._lblCommonLabel_13.AllowDrop = true;
			this._lblCommonLabel_13.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_13.Text = "Country";
			this._lblCommonLabel_13.ForeColor = System.Drawing.Color.Black;
			this._lblCommonLabel_13.Location = new System.Drawing.Point(237, 211);
			// // this._lblCommonLabel_13.mLabelId = 158;
			this._lblCommonLabel_13.Name = "_lblCommonLabel_13";
			this._lblCommonLabel_13.Size = new System.Drawing.Size(38, 14);
			this._lblCommonLabel_13.TabIndex = 108;
			// 
			// txtBlockNo
			// 
			this.txtBlockNo.AllowDrop = true;
			this.txtBlockNo.BackColor = System.Drawing.Color.White;
			this.txtBlockNo.ForeColor = System.Drawing.Color.Black;
			this.txtBlockNo.Location = new System.Drawing.Point(329, 188);
			this.txtBlockNo.MaxLength = 100;
			this.txtBlockNo.Name = "txtBlockNo";
			this.txtBlockNo.Size = new System.Drawing.Size(119, 19);
			this.txtBlockNo.TabIndex = 41;
			this.txtBlockNo.Text = "";
			// this.this.txtBlockNo.Watermark = "";
			// 
			// txtCountry
			// 
			this.txtCountry.AllowDrop = true;
			this.txtCountry.BackColor = System.Drawing.Color.White;
			this.txtCountry.ForeColor = System.Drawing.Color.Black;
			this.txtCountry.Location = new System.Drawing.Point(329, 209);
			this.txtCountry.MaxLength = 100;
			this.txtCountry.Name = "txtCountry";
			this.txtCountry.Size = new System.Drawing.Size(119, 19);
			this.txtCountry.TabIndex = 42;
			this.txtCountry.Text = "";
			// this.this.txtCountry.Watermark = "";
			// 
			// txtStreetNo
			// 
			this.txtStreetNo.AllowDrop = true;
			this.txtStreetNo.BackColor = System.Drawing.Color.White;
			this.txtStreetNo.ForeColor = System.Drawing.Color.Black;
			this.txtStreetNo.Location = new System.Drawing.Point(103, 188);
			this.txtStreetNo.MaxLength = 100;
			this.txtStreetNo.Name = "txtStreetNo";
			this.txtStreetNo.Size = new System.Drawing.Size(101, 19);
			this.txtStreetNo.TabIndex = 43;
			this.txtStreetNo.Text = "";
			// this.this.txtStreetNo.Watermark = "";
			// 
			// _lblCommonLabel_16
			// 
			this._lblCommonLabel_16.AllowDrop = true;
			this._lblCommonLabel_16.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_16.Text = "Street No.";
			this._lblCommonLabel_16.ForeColor = System.Drawing.Color.Black;
			this._lblCommonLabel_16.Location = new System.Drawing.Point(8, 190);
			// // this._lblCommonLabel_16.mLabelId = 938;
			this._lblCommonLabel_16.Name = "_lblCommonLabel_16";
			this._lblCommonLabel_16.Size = new System.Drawing.Size(48, 14);
			this._lblCommonLabel_16.TabIndex = 109;
			// 
			// txtCity
			// 
			this.txtCity.AllowDrop = true;
			this.txtCity.BackColor = System.Drawing.Color.White;
			this.txtCity.ForeColor = System.Drawing.Color.Black;
			this.txtCity.Location = new System.Drawing.Point(103, 209);
			this.txtCity.MaxLength = 100;
			this.txtCity.Name = "txtCity";
			this.txtCity.Size = new System.Drawing.Size(101, 19);
			this.txtCity.TabIndex = 44;
			this.txtCity.Text = "";
			// this.this.txtCity.Watermark = "";
			// 
			// txtAdd1
			// 
			this.txtAdd1.AllowDrop = true;
			this.txtAdd1.BackColor = System.Drawing.Color.White;
			// this.txtAdd1.bolAllowDecimal = false;
			this.txtAdd1.ForeColor = System.Drawing.Color.Black;
			this.txtAdd1.Location = new System.Drawing.Point(103, 42);
			// this.txtAdd1.mDropDownType = (System.Windows.Forms.TextBox.FormatBoxDropDownTypes) 0;
			this.txtAdd1.Name = "txtAdd1";
			this.txtAdd1.Size = new System.Drawing.Size(344, 69);
			this.txtAdd1.TabIndex = 64;
			this.txtAdd1.Text = "";
			// 
			// txtAdd2
			// 
			this.txtAdd2.AllowDrop = true;
			this.txtAdd2.BackColor = System.Drawing.Color.White;
			// this.txtAdd2.bolAllowDecimal = false;
			this.txtAdd2.ForeColor = System.Drawing.Color.Black;
			this.txtAdd2.Location = new System.Drawing.Point(103, 114);
			// this.txtAdd2.mDropDownType = (System.Windows.Forms.TextBox.FormatBoxDropDownTypes) 0;
			this.txtAdd2.Name = "txtAdd2";
			this.txtAdd2.Size = new System.Drawing.Size(344, 69);
			this.txtAdd2.TabIndex = 65;
			this.txtAdd2.Text = "";
			// 
			// tabGeneral
			// 
			this.tabGeneral.AllowDrop = true;
			this.tabGeneral.Controls.Add(this.tabMaster);
			this.tabGeneral.Controls.Add(this.chkProcessed);
			this.tabGeneral.Controls.Add(this._optVoucherType_1);
			this.tabGeneral.Controls.Add(this._optVoucherType_0);
			this.tabGeneral.Controls.Add(this.cmdAddtionalDetails);
			this.tabGeneral.Controls.Add(this.txtExchangeRate);
			this.tabGeneral.Controls.Add(this._lblCommonLabel_14);
			this.tabGeneral.Controls.Add(this.txtVoucherDate);
			this.tabGeneral.Controls.Add(this._txtCommonTextBox_3);
			this.tabGeneral.Controls.Add(this._txtCommonTextBox_1);
			this.tabGeneral.Controls.Add(this._lblCommonLabel_19);
			this.tabGeneral.Controls.Add(this._lblCommonLabel_2);
			this.tabGeneral.Controls.Add(this._lblCommonLabel_5);
			this.tabGeneral.Controls.Add(this._lblCommonLabel_3);
			this.tabGeneral.Controls.Add(this._lblCommonLabel_6);
			this.tabGeneral.Controls.Add(this._txtCommonTextBox_7);
			this.tabGeneral.Controls.Add(this._lblCommonLabel_24);
			this.tabGeneral.Controls.Add(this._txtCommonTextBox_15);
			this.tabGeneral.Controls.Add(this._lblCommonLabel_17);
			this.tabGeneral.Controls.Add(this._txtCommonTextBox_8);
			this.tabGeneral.Controls.Add(this._lblCommonLabel_7);
			this.tabGeneral.Controls.Add(this._txtDisplayLabel_1);
			this.tabGeneral.Controls.Add(this._txtDisplayLabel_8);
			this.tabGeneral.Controls.Add(this._txtDisplayLabel_2);
			this.tabGeneral.Controls.Add(this._txtCommonTextBox_13);
			this.tabGeneral.Controls.Add(this._txtCommonTextBox_23);
			this.tabGeneral.Controls.Add(this._lblCommonLabel_28);
			this.tabGeneral.Controls.Add(this._txtCommonTextBox_24);
			this.tabGeneral.Controls.Add(this._lblCommonLabel_29);
			this.tabGeneral.Controls.Add(this._txtDisplayLabel_10);
			this.tabGeneral.Controls.Add(this._lblCommonLabel_8);
			this.tabGeneral.Controls.Add(this._txtCommonTextBox_9);
			this.tabGeneral.Controls.Add(this._txtDisplayLabel_6);
			this.tabGeneral.Controls.Add(this._txtCommonTextBox_19);
			this.tabGeneral.Controls.Add(this._txtCommonTextBox_18);
			this.tabGeneral.Controls.Add(this._lblCommonLabel_20);
			this.tabGeneral.Controls.Add(this._txtCommonTextBox_17);
			this.tabGeneral.Controls.Add(this._lblCommonLabel_23);
			this.tabGeneral.Controls.Add(this._lblCommonLabel_22);
			this.tabGeneral.Controls.Add(this._lblCommonLabel_21);
			this.tabGeneral.Controls.Add(this._lblCommonLabel_4);
			this.tabGeneral.Controls.Add(this._txtCommonTextBox_4);
			this.tabGeneral.Controls.Add(this._txtCommonTextBox_20);
			this.tabGeneral.Controls.Add(this._lblCommonLabel_25);
			this.tabGeneral.Controls.Add(this._lblCommonLabel_26);
			this.tabGeneral.Controls.Add(this.txtDDueDate);
			this.tabGeneral.Controls.Add(this.cmbImportVoucherList);
			this.tabGeneral.Controls.Add(this._txtCommonTextBox_22);
			this.tabGeneral.Controls.Add(this.cmbMastersList);
			this.tabGeneral.Controls.Add(this.txtCreditDays);
			this.tabGeneral.Controls.Add(this.fraRental);
			this.tabGeneral.Controls.Add(this.fraProject);
			this.tabGeneral.Controls.Add(this.lblVoucherName);
			this.tabGeneral.Controls.Add(this.fraVoucherName);
			this.tabGeneral.Controls.Add(this.fraVoucherImport);
			this.tabGeneral.Controls.Add(this.fraVoucherType);
			this.tabGeneral.Controls.Add(this.fraCustomerDetails);
			this.tabGeneral.Controls.Add(this.frmHeader);
			this.tabGeneral.Controls.Add(this.fraTransactionHeader);
			this.tabGeneral.Location = new System.Drawing.Point(4, 26);
			this.tabGeneral.Name = "tabGeneral";
			("tabGeneral.OcxState");
			this.tabGeneral.Size = new System.Drawing.Size(1199, 473);
			this.tabGeneral.TabIndex = 71;
			// 
			// tabMaster
			// 
			this.tabMaster.AllowDrop = true;
			this.tabMaster.Controls.Add(this._TabControlPage3_2);
			this.tabMaster.Controls.Add(this._TabControlPage2_1);
			this.tabMaster.Controls.Add(this.fraMasterInformation);
			this.tabMaster.Location = new System.Drawing.Point(0, 216);
			this.tabMaster.Name = "tabMaster";
			("tabMaster.OcxState");
			this.tabMaster.Size = new System.Drawing.Size(841, 255);
			this.tabMaster.TabIndex = 147;
			// 
			// _TabControlPage3_2
			// 
			this._TabControlPage3_2.AllowDrop = true;
			this._TabControlPage3_2.Controls.Add(this.grdSupplierDetails);
			this._TabControlPage3_2.Location = new System.Drawing.Point(-4664, 22);
			this._TabControlPage3_2.Name = "_TabControlPage3_2";
			("_TabControlPage3_2.OcxState");
			this._TabControlPage3_2.Size = new System.Drawing.Size(837, 231);
			this._TabControlPage3_2.TabIndex = 148;
			this._TabControlPage3_2.Visible = false;
			// 
			// grdSupplierDetails
			// 
			this.grdSupplierDetails.AllowDrop = true;
			this.grdSupplierDetails.BackColor = System.Drawing.Color.FromArgb(212, 208, 200);
			this.grdSupplierDetails.CellTipsWidth = 0;
			this.grdSupplierDetails.Location = new System.Drawing.Point(0, 0);
			this.grdSupplierDetails.Name = "grdSupplierDetails";
			this.grdSupplierDetails.RowDivider.Color = System.Drawing.Color.FromArgb(212, 208, 200);
			this.grdSupplierDetails.Size = new System.Drawing.Size(822, 231);
			this.grdSupplierDetails.TabIndex = 149;
			this.grdSupplierDetails.Columns.Add(this.Column_0_grdSupplierDetails);
			// 
			// Column_0_grdSupplierDetails
			// 
			this.Column_0_grdSupplierDetails.DataField = "";
			this.Column_0_grdSupplierDetails.ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.Normal;
			// 
			// _TabControlPage2_1
			// 
			this._TabControlPage2_1.AllowDrop = true;
			this._TabControlPage2_1.Controls.Add(this.cmdPull);
			this._TabControlPage2_1.Controls.Add(this.cmbSupplierList);
			this._TabControlPage2_1.Controls.Add(this.grdImportVoucherDetails);
			this._TabControlPage2_1.Location = new System.Drawing.Point(-4664, 26);
			this._TabControlPage2_1.Name = "_TabControlPage2_1";
			("_TabControlPage2_1.OcxState");
			this._TabControlPage2_1.Size = new System.Drawing.Size(837, 227);
			this._TabControlPage2_1.TabIndex = 150;
			this._TabControlPage2_1.Visible = false;
			// 
			// cmdPull
			// 
			this.cmdPull.AllowDrop = true;
			this.cmdPull.BackColor = System.Drawing.SystemColors.Control;
			this.cmdPull.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 178);
			this.cmdPull.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdPull.Location = new System.Drawing.Point(510, 2);
			this.cmdPull.Name = "cmdPull";
			this.cmdPull.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdPull.Size = new System.Drawing.Size(81, 27);
			this.cmdPull.TabIndex = 151;
			this.cmdPull.Text = "Import";
			this.cmdPull.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.cmdPull.UseVisualStyleBackColor = false;
			// this.cmdPull.Click += new System.EventHandler(this.cmdPull_Click);
			// 
			// cmbSupplierList
			// 
			this.cmbSupplierList.AllowDrop = true;
			this.cmbSupplierList.ColumnHeaders = true;
			this.cmbSupplierList.Enabled = true;
			this.cmbSupplierList.Location = new System.Drawing.Point(510, 40);
			this.cmbSupplierList.Name = "cmbSupplierList";
			this.cmbSupplierList.Size = new System.Drawing.Size(169, 159);
			this.cmbSupplierList.TabIndex = 152;
			this.cmbSupplierList.Columns.Add(this.Column_0_cmbSupplierList);
			this.cmbSupplierList.Columns.Add(this.Column_1_cmbSupplierList);
			// 
			// Column_0_cmbSupplierList
			// 
			this.Column_0_cmbSupplierList.DataField = "";
			this.Column_0_cmbSupplierList.ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.Normal;
			// 
			// Column_1_cmbSupplierList
			// 
			this.Column_1_cmbSupplierList.DataField = "";
			this.Column_1_cmbSupplierList.ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.Normal;
			// 
			// grdImportVoucherDetails
			// 
			this.grdImportVoucherDetails.AllowDrop = true;
			this.grdImportVoucherDetails.BackColor = System.Drawing.Color.FromArgb(212, 208, 200);
			this.grdImportVoucherDetails.CellTipsWidth = 0;
			this.grdImportVoucherDetails.Location = new System.Drawing.Point(0, 0);
			this.grdImportVoucherDetails.Name = "grdImportVoucherDetails";
			this.grdImportVoucherDetails.RowDivider.Color = System.Drawing.Color.FromArgb(212, 208, 200);
			this.grdImportVoucherDetails.Size = new System.Drawing.Size(507, 233);
			this.grdImportVoucherDetails.TabIndex = 153;
			this.grdImportVoucherDetails.Columns.Add(this.Column_0_grdImportVoucherDetails);
			// 
			// Column_0_grdImportVoucherDetails
			// 
			this.Column_0_grdImportVoucherDetails.DataField = "";
			this.Column_0_grdImportVoucherDetails.ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.Normal;
			// 
			// fraMasterInformation
			// 
			this.fraMasterInformation.AllowDrop = true;
			this.fraMasterInformation.Controls.Add(this.Check1);
			this.fraMasterInformation.Controls.Add(this.chkSortOnProduct);
			this.fraMasterInformation.Controls.Add(this.txtTempDate);
			this.fraMasterInformation.Controls.Add(this.grdVoucherDetails);
			this.fraMasterInformation.Location = new System.Drawing.Point(2, 26);
			this.fraMasterInformation.Name = "fraMasterInformation";
			("fraMasterInformation.OcxState");
			this.fraMasterInformation.Size = new System.Drawing.Size(837, 227);
			this.fraMasterInformation.TabIndex = 154;
			// 
			// Check1
			// 
			this.Check1.AllowDrop = true;
			this.Check1.Appearance = System.Windows.Forms.Appearance.Normal;
			this.Check1.BackColor = System.Drawing.Color.White;
			this.Check1.CausesValidation = true;
			this.Check1.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.Check1.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this.Check1.Enabled = false;
			this.Check1.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 178);
			this.Check1.ForeColor = System.Drawing.Color.Gray;
			this.Check1.Location = new System.Drawing.Point(16, 66);
			this.Check1.Name = "Check1";
			this.Check1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Check1.Size = new System.Drawing.Size(86, 21);
			this.Check1.TabIndex = 156;
			this.Check1.TabStop = true;
			this.Check1.Text = "Processed";
			this.Check1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.Check1.Visible = false;
			// 
			// chkSortOnProduct
			// 
			this.chkSortOnProduct.AllowDrop = true;
			this.chkSortOnProduct.Appearance = System.Windows.Forms.Appearance.Normal;
			this.chkSortOnProduct.BackColor = System.Drawing.Color.FromArgb(249, 240, 236);
			this.chkSortOnProduct.CausesValidation = true;
			this.chkSortOnProduct.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkSortOnProduct.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this.chkSortOnProduct.Enabled = true;
			this.chkSortOnProduct.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 178);
			this.chkSortOnProduct.ForeColor = System.Drawing.Color.Black;
			this.chkSortOnProduct.Location = new System.Drawing.Point(20, 100);
			this.chkSortOnProduct.Name = "chkSortOnProduct";
			this.chkSortOnProduct.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.chkSortOnProduct.Size = new System.Drawing.Size(14, 16);
			this.chkSortOnProduct.TabIndex = 155;
			this.chkSortOnProduct.TabStop = true;
			this.chkSortOnProduct.Text = "Sort by Product";
			this.chkSortOnProduct.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkSortOnProduct.Visible = false;
			// 
			// txtTempDate
			// 
			this.txtTempDate.AllowDrop = true;
			this.txtTempDate.Location = new System.Drawing.Point(0, 0);
			this.txtTempDate.Name = "txtTempDate";
			("txtTempDate.OcxState");
			this.txtTempDate.Size = new System.Drawing.Size(109, 19);
			this.txtTempDate.TabIndex = 157;
			this.txtTempDate.Visible = false;
			// 
			// grdVoucherDetails
			// 
			this.grdVoucherDetails.AllowDrop = true;
			this.grdVoucherDetails.BackColor = System.Drawing.Color.FromArgb(212, 208, 200);
			this.grdVoucherDetails.CellTipsWidth = 0;
			this.grdVoucherDetails.Location = new System.Drawing.Point(0, 0);
			this.grdVoucherDetails.Name = "grdVoucherDetails";
			this.grdVoucherDetails.RowDivider.Color = System.Drawing.Color.FromArgb(212, 208, 200);
			this.grdVoucherDetails.Size = new System.Drawing.Size(836, 229);
			this.grdVoucherDetails.TabIndex = 15;
			this.grdVoucherDetails.Columns.Add(this.Column_0_grdVoucherDetails);
			// 
			// Column_0_grdVoucherDetails
			// 
			this.Column_0_grdVoucherDetails.DataField = "";
			this.Column_0_grdVoucherDetails.ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.Normal;
			// 
			// chkProcessed
			// 
			this.chkProcessed.AllowDrop = true;
			this.chkProcessed.Appearance = System.Windows.Forms.Appearance.Normal;
			this.chkProcessed.BackColor = System.Drawing.Color.White;
			this.chkProcessed.CausesValidation = true;
			this.chkProcessed.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkProcessed.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this.chkProcessed.Enabled = false;
			this.chkProcessed.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 178);
			this.chkProcessed.ForeColor = System.Drawing.Color.Gray;
			this.chkProcessed.Location = new System.Drawing.Point(1084, 407);
			this.chkProcessed.Name = "chkProcessed";
			this.chkProcessed.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.chkProcessed.Size = new System.Drawing.Size(86, 21);
			this.chkProcessed.TabIndex = 31;
			this.chkProcessed.TabStop = true;
			this.chkProcessed.Text = "Processed";
			this.chkProcessed.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkProcessed.Visible = false;
			// 
			// _optVoucherType_1
			// 
			this._optVoucherType_1.AllowDrop = true;
			this._optVoucherType_1.Appearance = System.Windows.Forms.Appearance.Normal;
			this._optVoucherType_1.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._optVoucherType_1.CausesValidation = true;
			this._optVoucherType_1.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._optVoucherType_1.Checked = false;
			this._optVoucherType_1.Enabled = true;
			this._optVoucherType_1.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 178);
			this._optVoucherType_1.ForeColor = System.Drawing.SystemColors.ControlText;
			this._optVoucherType_1.Location = new System.Drawing.Point(591, 173);
			this._optVoucherType_1.Name = "_optVoucherType_1";
			this._optVoucherType_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._optVoucherType_1.Size = new System.Drawing.Size(53, 16);
			this._optVoucherType_1.TabIndex = 13;
			this._optVoucherType_1.TabStop = true;
			this._optVoucherType_1.Text = "&Cash";
			this._optVoucherType_1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._optVoucherType_1.Visible = false;
			this._optVoucherType_1.CheckedChanged += new System.EventHandler(this.optVoucherType_CheckedChanged);
			// 
			// _optVoucherType_0
			// 
			this._optVoucherType_0.AllowDrop = true;
			this._optVoucherType_0.Appearance = System.Windows.Forms.Appearance.Normal;
			this._optVoucherType_0.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._optVoucherType_0.CausesValidation = true;
			this._optVoucherType_0.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._optVoucherType_0.Checked = true;
			this._optVoucherType_0.Enabled = true;
			this._optVoucherType_0.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 178);
			this._optVoucherType_0.ForeColor = System.Drawing.SystemColors.ControlText;
			this._optVoucherType_0.Location = new System.Drawing.Point(526, 173);
			this._optVoucherType_0.Name = "_optVoucherType_0";
			this._optVoucherType_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._optVoucherType_0.Size = new System.Drawing.Size(61, 16);
			this._optVoucherType_0.TabIndex = 12;
			this._optVoucherType_0.TabStop = true;
			this._optVoucherType_0.Text = "C&redit";
			this._optVoucherType_0.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._optVoucherType_0.Visible = false;
			this._optVoucherType_0.CheckedChanged += new System.EventHandler(this.optVoucherType_CheckedChanged);
			// 
			// cmdAddtionalDetails
			// 
			this.cmdAddtionalDetails.AllowDrop = true;
			this.cmdAddtionalDetails.Location = new System.Drawing.Point(520, 130);
			this.cmdAddtionalDetails.Name = "cmdAddtionalDetails";
			("cmdAddtionalDetails.OcxState");
			this.cmdAddtionalDetails.Size = new System.Drawing.Size(25, 23);
			this.cmdAddtionalDetails.TabIndex = 21;
			this.cmdAddtionalDetails.TabStop = false;
			this.cmdAddtionalDetails.Visible = false;
			//// this.cmdAddtionalDetails.ClickEvent += new System.EventHandler(this.cmdAddtionalDetails_ClickEvent);
			// 
			// txtExchangeRate
			// 
			this.txtExchangeRate.AllowDrop = true;
			// this.txtExchangeRate.DisplayFormat = "####0.000######;; ; ";
			this.txtExchangeRate.Enabled = false;
			// this.txtExchangeRate.Format = "####0.000######";
			this.txtExchangeRate.Location = new System.Drawing.Point(410, 154);
			// this.txtExchangeRate.MaxValue = 2147483647;
			// this.txtExchangeRate.MinValue = 0;
			this.txtExchangeRate.Name = "txtExchangeRate";
			this.txtExchangeRate.Size = new System.Drawing.Size(103, 23);
			this.txtExchangeRate.TabIndex = 9;
			// this.txtExchangeRate.Text = "0.000";
			this.txtExchangeRate.Visible = false;
			// 
			// _lblCommonLabel_14
			// 
			this._lblCommonLabel_14.AllowDrop = true;
			this._lblCommonLabel_14.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_14.Text = "Exch. Rate";
			this._lblCommonLabel_14.ForeColor = System.Drawing.Color.Black;
			this._lblCommonLabel_14.Location = new System.Drawing.Point(332, 156);
			// // this._lblCommonLabel_14.mLabelId = 260;
			this._lblCommonLabel_14.Name = "_lblCommonLabel_14";
			this._lblCommonLabel_14.Size = new System.Drawing.Size(65, 16);
			this._lblCommonLabel_14.TabIndex = 74;
			this._lblCommonLabel_14.Visible = false;
			// 
			// txtVoucherDate
			// 
			this.txtVoucherDate.AllowDrop = true;
			// this.txtVoucherDate.CheckDateRange = false;
			this.txtVoucherDate.Location = new System.Drawing.Point(109, 64);
			// this.txtVoucherDate.MaxDate = 2958465;
			// this.txtVoucherDate.MinDate = 32874;
			this.txtVoucherDate.Name = "txtVoucherDate";
			this.txtVoucherDate.Size = new System.Drawing.Size(103, 23);
			this.txtVoucherDate.TabIndex = 3;
			// this.txtVoucherDate.Text = "18-Jul-2001";
			// this.txtVoucherDate.Value = 37090;
			// this.this.txtVoucherDate.Change += new Syncfusion.WinForms.Input.SfDateTimeEdit.ChangeHandler(this.txtVoucherDate_Change);
			this.txtVoucherDate.Validating += new System.ComponentModel.CancelEventHandler(this.txtVoucherDate_Validating);
			// 
			// _txtCommonTextBox_3
			// 
			this._txtCommonTextBox_3.AllowDrop = true;
			this._txtCommonTextBox_3.BackColor = System.Drawing.Color.White;
			// this.this._txtCommonTextBox_3.bolIsRequired = true;
			this._txtCommonTextBox_3.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_3.Location = new System.Drawing.Point(108, 130);
			this._txtCommonTextBox_3.Name = "_txtCommonTextBox_3";
			// this._txtCommonTextBox_3.ShowButton = true;
			this._txtCommonTextBox_3.Size = new System.Drawing.Size(101, 23);
			this._txtCommonTextBox_3.TabIndex = 6;
			this._txtCommonTextBox_3.Text = "";
			this._txtCommonTextBox_3.Visible = false;
			// this.this._txtCommonTextBox_3.Watermark = "";
			// this.this._txtCommonTextBox_3.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_3.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _txtCommonTextBox_1
			// 
			this._txtCommonTextBox_1.AllowDrop = true;
			this._txtCommonTextBox_1.BackColor = System.Drawing.Color.White;
			// this.this._txtCommonTextBox_1.bolIsRequired = true;
			// this._txtCommonTextBox_1.bolNumericOnly = true;
			this._txtCommonTextBox_1.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_1.Location = new System.Drawing.Point(109, 13);
			this._txtCommonTextBox_1.MaxLength = 4;
			this._txtCommonTextBox_1.Name = "_txtCommonTextBox_1";
			// this._txtCommonTextBox_1.ShowButton = true;
			this._txtCommonTextBox_1.Size = new System.Drawing.Size(101, 23);
			this._txtCommonTextBox_1.TabIndex = 0;
			this._txtCommonTextBox_1.Text = "";
			// this.this._txtCommonTextBox_1.Watermark = "";
			// this.this._txtCommonTextBox_1.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_1.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _lblCommonLabel_19
			// 
			this._lblCommonLabel_19.AllowDrop = true;
			this._lblCommonLabel_19.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_19.Text = "Balance : ";
			this._lblCommonLabel_19.ForeColor = System.Drawing.Color.FromArgb(225, 70, 206);
			this._lblCommonLabel_19.Location = new System.Drawing.Point(169, 157);
			// // this._lblCommonLabel_19.mLabelId = 878;
			this._lblCommonLabel_19.Name = "_lblCommonLabel_19";
			this._lblCommonLabel_19.Size = new System.Drawing.Size(59, 16);
			this._lblCommonLabel_19.TabIndex = 75;
			this._lblCommonLabel_19.Tag = "Balance : ";
			this._lblCommonLabel_19.Visible = false;
			// 
			// _lblCommonLabel_2
			// 
			this._lblCommonLabel_2.AllowDrop = true;
			this._lblCommonLabel_2.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_2.Text = "Location Code";
			this._lblCommonLabel_2.ForeColor = System.Drawing.Color.Black;
			this._lblCommonLabel_2.Location = new System.Drawing.Point(9, 16);
			// // this._lblCommonLabel_2.mLabelId = 416;
			this._lblCommonLabel_2.Name = "_lblCommonLabel_2";
			this._lblCommonLabel_2.Size = new System.Drawing.Size(80, 15);
			this._lblCommonLabel_2.TabIndex = 76;
			// 
			// _lblCommonLabel_5
			// 
			this._lblCommonLabel_5.AllowDrop = true;
			this._lblCommonLabel_5.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_5.Text = "Inv. No.";
			this._lblCommonLabel_5.ForeColor = System.Drawing.Color.Black;
			this._lblCommonLabel_5.Location = new System.Drawing.Point(9, 40);
			// // this._lblCommonLabel_5.mLabelId = 850;
			this._lblCommonLabel_5.Name = "_lblCommonLabel_5";
			this._lblCommonLabel_5.Size = new System.Drawing.Size(43, 16);
			this._lblCommonLabel_5.TabIndex = 77;
			// 
			// _lblCommonLabel_3
			// 
			this._lblCommonLabel_3.AllowDrop = true;
			this._lblCommonLabel_3.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_3.Text = "Supplier Code";
			this._lblCommonLabel_3.ForeColor = System.Drawing.Color.Black;
			this._lblCommonLabel_3.Location = new System.Drawing.Point(10, 132);
			this._lblCommonLabel_3.Name = "_lblCommonLabel_3";
			this._lblCommonLabel_3.Size = new System.Drawing.Size(81, 16);
			this._lblCommonLabel_3.TabIndex = 78;
			this._lblCommonLabel_3.Visible = false;
			// 
			// _lblCommonLabel_6
			// 
			this._lblCommonLabel_6.AllowDrop = true;
			this._lblCommonLabel_6.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_6.Text = "Inv. Date";
			this._lblCommonLabel_6.ForeColor = System.Drawing.Color.Black;
			this._lblCommonLabel_6.Location = new System.Drawing.Point(10, 68);
			// // this._lblCommonLabel_6.mLabelId = 848;
			this._lblCommonLabel_6.Name = "_lblCommonLabel_6";
			this._lblCommonLabel_6.Size = new System.Drawing.Size(50, 16);
			this._lblCommonLabel_6.TabIndex = 79;
			// 
			// _txtCommonTextBox_7
			// 
			this._txtCommonTextBox_7.AllowDrop = true;
			this._txtCommonTextBox_7.BackColor = System.Drawing.Color.White;
			// this._txtCommonTextBox_7.bolNumericOnly = true;
			this._txtCommonTextBox_7.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_7.Location = new System.Drawing.Point(109, 38);
			this._txtCommonTextBox_7.MaxLength = 11;
			this._txtCommonTextBox_7.Name = "_txtCommonTextBox_7";
			this._txtCommonTextBox_7.Size = new System.Drawing.Size(103, 23);
			this._txtCommonTextBox_7.TabIndex = 1;
			this._txtCommonTextBox_7.Text = "";
			// this.this._txtCommonTextBox_7.Watermark = "";
			// this.this._txtCommonTextBox_7.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_7.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _lblCommonLabel_24
			// 
			this._lblCommonLabel_24.AllowDrop = true;
			this._lblCommonLabel_24.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_24.Text = "Currency";
			this._lblCommonLabel_24.ForeColor = System.Drawing.Color.FromArgb(255, 128, 128);
			this._lblCommonLabel_24.Location = new System.Drawing.Point(10, 156);
			// // this._lblCommonLabel_24.mLabelId = 877;
			this._lblCommonLabel_24.Name = "_lblCommonLabel_24";
			this._lblCommonLabel_24.Size = new System.Drawing.Size(52, 16);
			this._lblCommonLabel_24.TabIndex = 80;
			this._lblCommonLabel_24.Visible = false;
			// 
			// _txtCommonTextBox_15
			// 
			this._txtCommonTextBox_15.AllowDrop = true;
			this._txtCommonTextBox_15.BackColor = System.Drawing.Color.White;
			// this.this._txtCommonTextBox_15.bolIsRequired = true;
			// this._txtCommonTextBox_15.bolNumericOnly = true;
			this._txtCommonTextBox_15.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_15.Location = new System.Drawing.Point(109, 90);
			this._txtCommonTextBox_15.Name = "_txtCommonTextBox_15";
			// this._txtCommonTextBox_15.ShowButton = true;
			this._txtCommonTextBox_15.Size = new System.Drawing.Size(101, 23);
			this._txtCommonTextBox_15.TabIndex = 4;
			this._txtCommonTextBox_15.Text = "";
			this._txtCommonTextBox_15.Visible = false;
			// this.this._txtCommonTextBox_15.Watermark = "";
			// this.this._txtCommonTextBox_15.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_15.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _lblCommonLabel_17
			// 
			this._lblCommonLabel_17.AllowDrop = true;
			this._lblCommonLabel_17.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_17.Text = "To Location";
			this._lblCommonLabel_17.ForeColor = System.Drawing.Color.Black;
			this._lblCommonLabel_17.Location = new System.Drawing.Point(9, 93);
			// // this._lblCommonLabel_17.mLabelId = 876;
			this._lblCommonLabel_17.Name = "_lblCommonLabel_17";
			this._lblCommonLabel_17.Size = new System.Drawing.Size(56, 14);
			this._lblCommonLabel_17.TabIndex = 81;
			this._lblCommonLabel_17.Visible = false;
			// 
			// _txtCommonTextBox_8
			// 
			this._txtCommonTextBox_8.AllowDrop = true;
			this._txtCommonTextBox_8.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_8.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_8.Location = new System.Drawing.Point(409, 38);
			this._txtCommonTextBox_8.MaxLength = 20;
			this._txtCommonTextBox_8.Name = "_txtCommonTextBox_8";
			this._txtCommonTextBox_8.Size = new System.Drawing.Size(103, 23);
			this._txtCommonTextBox_8.TabIndex = 2;
			this._txtCommonTextBox_8.Text = "";
			this._txtCommonTextBox_8.Visible = false;
			// this.this._txtCommonTextBox_8.Watermark = "";
			// this.this._txtCommonTextBox_8.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_8.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _lblCommonLabel_7
			// 
			this._lblCommonLabel_7.AllowDrop = true;
			this._lblCommonLabel_7.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_7.Text = "Reference No.";
			this._lblCommonLabel_7.ForeColor = System.Drawing.Color.Black;
			this._lblCommonLabel_7.Location = new System.Drawing.Point(319, 39);
			// // this._lblCommonLabel_7.mLabelId = 614;
			this._lblCommonLabel_7.Name = "_lblCommonLabel_7";
			this._lblCommonLabel_7.Size = new System.Drawing.Size(82, 16);
			this._lblCommonLabel_7.TabIndex = 82;
			// 
			// _txtDisplayLabel_1
			// 
			this._txtDisplayLabel_1.AllowDrop = true;
			this._txtDisplayLabel_1.Location = new System.Drawing.Point(212, 13);
			this._txtDisplayLabel_1.Name = "_txtDisplayLabel_1";
			this._txtDisplayLabel_1.Size = new System.Drawing.Size(301, 23);
			this._txtDisplayLabel_1.TabIndex = 22;
			this._txtDisplayLabel_1.TabStop = false;
			// 
			// _txtDisplayLabel_8
			// 
			this._txtDisplayLabel_8.AllowDrop = true;
			this._txtDisplayLabel_8.Location = new System.Drawing.Point(213, 90);
			this._txtDisplayLabel_8.Name = "_txtDisplayLabel_8";
			this._txtDisplayLabel_8.Size = new System.Drawing.Size(299, 23);
			this._txtDisplayLabel_8.TabIndex = 23;
			this._txtDisplayLabel_8.TabStop = false;
			this._txtDisplayLabel_8.Visible = false;
			// 
			// _txtDisplayLabel_2
			// 
			this._txtDisplayLabel_2.AllowDrop = true;
			this._txtDisplayLabel_2.Location = new System.Drawing.Point(476, 72);
			this._txtDisplayLabel_2.Name = "_txtDisplayLabel_2";
			this._txtDisplayLabel_2.Size = new System.Drawing.Size(5, 11);
			this._txtDisplayLabel_2.TabIndex = 24;
			this._txtDisplayLabel_2.TabStop = false;
			this._txtDisplayLabel_2.Visible = false;
			// 
			// _txtCommonTextBox_13
			// 
			this._txtCommonTextBox_13.AllowDrop = true;
			this._txtCommonTextBox_13.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_13.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_13.Location = new System.Drawing.Point(108, 154);
			this._txtCommonTextBox_13.Name = "_txtCommonTextBox_13";
			// this._txtCommonTextBox_13.ShowButton = true;
			this._txtCommonTextBox_13.Size = new System.Drawing.Size(57, 23);
			this._txtCommonTextBox_13.TabIndex = 8;
			this._txtCommonTextBox_13.Text = "";
			// this.this._txtCommonTextBox_13.Watermark = "";
			// this.this._txtCommonTextBox_13.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_13.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _txtCommonTextBox_23
			// 
			this._txtCommonTextBox_23.AllowDrop = true;
			this._txtCommonTextBox_23.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_23.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_23.Location = new System.Drawing.Point(349, 90);
			this._txtCommonTextBox_23.Name = "_txtCommonTextBox_23";
			// this._txtCommonTextBox_23.ShowButton = true;
			this._txtCommonTextBox_23.Size = new System.Drawing.Size(101, 23);
			this._txtCommonTextBox_23.TabIndex = 25;
			this._txtCommonTextBox_23.Text = "";
			this._txtCommonTextBox_23.Visible = false;
			// this.this._txtCommonTextBox_23.Watermark = "";
			// this.this._txtCommonTextBox_23.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_23.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _lblCommonLabel_28
			// 
			this._lblCommonLabel_28.AllowDrop = true;
			this._lblCommonLabel_28.BackColor = System.Drawing.SystemColors.Window;
			this._lblCommonLabel_28.Text = "Exp. Accnt Code";
			this._lblCommonLabel_28.ForeColor = System.Drawing.Color.Black;
			this._lblCommonLabel_28.Location = new System.Drawing.Point(249, 92);
			this._lblCommonLabel_28.Name = "_lblCommonLabel_28";
			this._lblCommonLabel_28.Size = new System.Drawing.Size(99, 16);
			this._lblCommonLabel_28.TabIndex = 83;
			this._lblCommonLabel_28.Visible = false;
			// 
			// _txtCommonTextBox_24
			// 
			this._txtCommonTextBox_24.AllowDrop = true;
			this._txtCommonTextBox_24.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_24.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_24.Location = new System.Drawing.Point(638, 128);
			this._txtCommonTextBox_24.Name = "_txtCommonTextBox_24";
			// this._txtCommonTextBox_24.ShowButton = true;
			this._txtCommonTextBox_24.Size = new System.Drawing.Size(101, 23);
			this._txtCommonTextBox_24.TabIndex = 14;
			this._txtCommonTextBox_24.Text = "";
			// this.this._txtCommonTextBox_24.Watermark = "";
			// this.this._txtCommonTextBox_24.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_24.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _lblCommonLabel_29
			// 
			this._lblCommonLabel_29.AllowDrop = true;
			this._lblCommonLabel_29.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_29.Text = "Consignment";
			this._lblCommonLabel_29.ForeColor = System.Drawing.Color.Black;
			this._lblCommonLabel_29.Location = new System.Drawing.Point(548, 132);
			// // this._lblCommonLabel_29.mLabelId = 2118;
			this._lblCommonLabel_29.Name = "_lblCommonLabel_29";
			this._lblCommonLabel_29.Size = new System.Drawing.Size(76, 16);
			this._lblCommonLabel_29.TabIndex = 84;
			// 
			// _txtDisplayLabel_10
			// 
			this._txtDisplayLabel_10.AllowDrop = true;
			this._txtDisplayLabel_10.Location = new System.Drawing.Point(740, 128);
			this._txtDisplayLabel_10.Name = "_txtDisplayLabel_10";
			this._txtDisplayLabel_10.Size = new System.Drawing.Size(209, 23);
			this._txtDisplayLabel_10.TabIndex = 26;
			this._txtDisplayLabel_10.TabStop = false;
			// 
			// _lblCommonLabel_8
			// 
			this._lblCommonLabel_8.AllowDrop = true;
			this._lblCommonLabel_8.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_8.Text = "Salesman";
			this._lblCommonLabel_8.ForeColor = System.Drawing.Color.Black;
			this._lblCommonLabel_8.Location = new System.Drawing.Point(9, 93);
			// // this._lblCommonLabel_8.mLabelId = 687;
			this._lblCommonLabel_8.Name = "_lblCommonLabel_8";
			this._lblCommonLabel_8.Size = new System.Drawing.Size(58, 16);
			this._lblCommonLabel_8.TabIndex = 85;
			this._lblCommonLabel_8.Visible = false;
			// 
			// _txtCommonTextBox_9
			// 
			this._txtCommonTextBox_9.AllowDrop = true;
			this._txtCommonTextBox_9.BackColor = System.Drawing.Color.White;
			// this.this._txtCommonTextBox_9.bolIsRequired = true;
			// this._txtCommonTextBox_9.bolNumericOnly = true;
			this._txtCommonTextBox_9.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_9.Location = new System.Drawing.Point(109, 90);
			this._txtCommonTextBox_9.MaxLength = 4;
			this._txtCommonTextBox_9.Name = "_txtCommonTextBox_9";
			// this._txtCommonTextBox_9.ShowButton = true;
			this._txtCommonTextBox_9.Size = new System.Drawing.Size(101, 23);
			this._txtCommonTextBox_9.TabIndex = 5;
			this._txtCommonTextBox_9.Text = "";
			this._txtCommonTextBox_9.Visible = false;
			// this.this._txtCommonTextBox_9.Watermark = "";
			// this.this._txtCommonTextBox_9.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_9.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _txtDisplayLabel_6
			// 
			this._txtDisplayLabel_6.AllowDrop = true;
			this._txtDisplayLabel_6.Location = new System.Drawing.Point(213, 90);
			this._txtDisplayLabel_6.Name = "_txtDisplayLabel_6";
			this._txtDisplayLabel_6.Size = new System.Drawing.Size(199, 23);
			this._txtDisplayLabel_6.TabIndex = 27;
			this._txtDisplayLabel_6.Visible = false;
			// 
			// _txtCommonTextBox_19
			// 
			this._txtCommonTextBox_19.AllowDrop = true;
			this._txtCommonTextBox_19.BackColor = System.Drawing.Color.FromArgb(239, 239, 239);
			// this._txtCommonTextBox_19.bolNumericOnly = true;
			this._txtCommonTextBox_19.Enabled = false;
			this._txtCommonTextBox_19.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_19.Location = new System.Drawing.Point(849, 179);
			this._txtCommonTextBox_19.Name = "_txtCommonTextBox_19";
			// this._txtCommonTextBox_19.ShowButton = true;
			this._txtCommonTextBox_19.Size = new System.Drawing.Size(101, 23);
			this._txtCommonTextBox_19.TabIndex = 28;
			this._txtCommonTextBox_19.Text = "";
			this._txtCommonTextBox_19.Visible = false;
			// this.this._txtCommonTextBox_19.Watermark = "";
			// this.this._txtCommonTextBox_19.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_19.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _txtCommonTextBox_18
			// 
			this._txtCommonTextBox_18.AllowDrop = true;
			this._txtCommonTextBox_18.BackColor = System.Drawing.Color.White;
			// this._txtCommonTextBox_18.bolNumericOnly = true;
			this._txtCommonTextBox_18.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_18.Location = new System.Drawing.Point(849, 154);
			this._txtCommonTextBox_18.Name = "_txtCommonTextBox_18";
			// this._txtCommonTextBox_18.ShowButton = true;
			this._txtCommonTextBox_18.Size = new System.Drawing.Size(101, 23);
			this._txtCommonTextBox_18.TabIndex = 29;
			this._txtCommonTextBox_18.Text = "";
			this._txtCommonTextBox_18.Visible = false;
			// this.this._txtCommonTextBox_18.Watermark = "";
			// this.this._txtCommonTextBox_18.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_18.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _lblCommonLabel_20
			// 
			this._lblCommonLabel_20.AllowDrop = true;
			this._lblCommonLabel_20.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_20.Text = " Import Voucher Information ";
			this._lblCommonLabel_20.ForeColor = System.Drawing.Color.Black;
			this._lblCommonLabel_20.Location = new System.Drawing.Point(757, 109);
			// // this._lblCommonLabel_20.mLabelId = 867;
			this._lblCommonLabel_20.Name = "_lblCommonLabel_20";
			this._lblCommonLabel_20.Size = new System.Drawing.Size(167, 16);
			this._lblCommonLabel_20.TabIndex = 86;
			this._lblCommonLabel_20.Visible = false;
			// 
			// _txtCommonTextBox_17
			// 
			this._txtCommonTextBox_17.AllowDrop = true;
			this._txtCommonTextBox_17.BackColor = System.Drawing.Color.White;
			// this._txtCommonTextBox_17.bolNumericOnly = true;
			this._txtCommonTextBox_17.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_17.Location = new System.Drawing.Point(850, 129);
			this._txtCommonTextBox_17.Name = "_txtCommonTextBox_17";
			// this._txtCommonTextBox_17.ShowButton = true;
			this._txtCommonTextBox_17.Size = new System.Drawing.Size(101, 23);
			this._txtCommonTextBox_17.TabIndex = 30;
			this._txtCommonTextBox_17.Text = "";
			this._txtCommonTextBox_17.Visible = false;
			// this.this._txtCommonTextBox_17.Watermark = "";
			// this.this._txtCommonTextBox_17.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_17.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _lblCommonLabel_23
			// 
			this._lblCommonLabel_23.AllowDrop = true;
			this._lblCommonLabel_23.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_23.Text = "Voucher No.";
			this._lblCommonLabel_23.ForeColor = System.Drawing.Color.Black;
			this._lblCommonLabel_23.Location = new System.Drawing.Point(761, 181);
			// // this._lblCommonLabel_23.mLabelId = 850;
			this._lblCommonLabel_23.Name = "_lblCommonLabel_23";
			this._lblCommonLabel_23.Size = new System.Drawing.Size(72, 16);
			this._lblCommonLabel_23.TabIndex = 87;
			this._lblCommonLabel_23.Visible = false;
			// 
			// _lblCommonLabel_22
			// 
			this._lblCommonLabel_22.AllowDrop = true;
			this._lblCommonLabel_22.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_22.Text = "Location Code";
			this._lblCommonLabel_22.ForeColor = System.Drawing.Color.Black;
			this._lblCommonLabel_22.Location = new System.Drawing.Point(761, 156);
			// // this._lblCommonLabel_22.mLabelId = 416;
			this._lblCommonLabel_22.Name = "_lblCommonLabel_22";
			this._lblCommonLabel_22.Size = new System.Drawing.Size(83, 16);
			this._lblCommonLabel_22.TabIndex = 88;
			this._lblCommonLabel_22.Visible = false;
			// 
			// _lblCommonLabel_21
			// 
			this._lblCommonLabel_21.AllowDrop = true;
			this._lblCommonLabel_21.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_21.Text = "Voucher Type";
			this._lblCommonLabel_21.ForeColor = System.Drawing.Color.Black;
			this._lblCommonLabel_21.Location = new System.Drawing.Point(761, 129);
			// // this._lblCommonLabel_21.mLabelId = 851;
			this._lblCommonLabel_21.Name = "_lblCommonLabel_21";
			this._lblCommonLabel_21.Size = new System.Drawing.Size(80, 16);
			this._lblCommonLabel_21.TabIndex = 89;
			this._lblCommonLabel_21.Visible = false;
			// 
			// _lblCommonLabel_4
			// 
			this._lblCommonLabel_4.AllowDrop = true;
			this._lblCommonLabel_4.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_4.ForeColor = System.Drawing.Color.Black;
			this._lblCommonLabel_4.Location = new System.Drawing.Point(674, 58);
			this._lblCommonLabel_4.Name = "_lblCommonLabel_4";
			this._lblCommonLabel_4.Size = new System.Drawing.Size(4, 16);
			this._lblCommonLabel_4.TabIndex = 90;
			this._lblCommonLabel_4.Visible = false;
			// 
			// _txtCommonTextBox_4
			// 
			this._txtCommonTextBox_4.AllowDrop = true;
			this._txtCommonTextBox_4.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_4.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_4.Location = new System.Drawing.Point(212, 130);
			this._txtCommonTextBox_4.Name = "_txtCommonTextBox_4";
			this._txtCommonTextBox_4.Size = new System.Drawing.Size(301, 23);
			this._txtCommonTextBox_4.TabIndex = 7;
			this._txtCommonTextBox_4.Text = "";
			this._txtCommonTextBox_4.Visible = false;
			// this.this._txtCommonTextBox_4.Watermark = "";
			// this.this._txtCommonTextBox_4.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_4.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _txtCommonTextBox_20
			// 
			this._txtCommonTextBox_20.AllowDrop = true;
			this._txtCommonTextBox_20.BackColor = System.Drawing.Color.White;
			// this._txtCommonTextBox_20.bolNumericOnly = true;
			this._txtCommonTextBox_20.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_20.Location = new System.Drawing.Point(408, 63);
			this._txtCommonTextBox_20.Name = "_txtCommonTextBox_20";
			// this._txtCommonTextBox_20.ShowButton = true;
			this._txtCommonTextBox_20.Size = new System.Drawing.Size(102, 23);
			this._txtCommonTextBox_20.TabIndex = 32;
			this._txtCommonTextBox_20.Text = "";
			this._txtCommonTextBox_20.Visible = false;
			// this.this._txtCommonTextBox_20.Watermark = "";
			// this.this._txtCommonTextBox_20.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_20.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _lblCommonLabel_25
			// 
			this._lblCommonLabel_25.AllowDrop = true;
			this._lblCommonLabel_25.BackColor = System.Drawing.SystemColors.Window;
			this._lblCommonLabel_25.Text = "Batch Code";
			this._lblCommonLabel_25.ForeColor = System.Drawing.Color.Black;
			this._lblCommonLabel_25.Location = new System.Drawing.Point(318, 67);
			this._lblCommonLabel_25.Name = "_lblCommonLabel_25";
			this._lblCommonLabel_25.Size = new System.Drawing.Size(56, 14);
			this._lblCommonLabel_25.TabIndex = 92;
			this._lblCommonLabel_25.Visible = false;
			// 
			// _lblCommonLabel_26
			// 
			this._lblCommonLabel_26.AllowDrop = true;
			this._lblCommonLabel_26.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_26.Text = "Credit Days";
			this._lblCommonLabel_26.ForeColor = System.Drawing.Color.Black;
			this._lblCommonLabel_26.Location = new System.Drawing.Point(10, 182);
			// // this._lblCommonLabel_26.mLabelId = 161;
			this._lblCommonLabel_26.Name = "_lblCommonLabel_26";
			this._lblCommonLabel_26.Size = new System.Drawing.Size(56, 14);
			this._lblCommonLabel_26.TabIndex = 93;
			this._lblCommonLabel_26.Visible = false;
			// 
			// txtDDueDate
			// 
			this.txtDDueDate.AllowDrop = true;
			// this.txtDDueDate.CheckDateRange = false;
			this.txtDDueDate.Location = new System.Drawing.Point(145, 179);
			// this.txtDDueDate.MaxDate = 2958465;
			// this.txtDDueDate.MinDate = 32874;
			this.txtDDueDate.Name = "txtDDueDate";
			this.txtDDueDate.Size = new System.Drawing.Size(102, 23);
			this.txtDDueDate.TabIndex = 33;
			// this.txtDDueDate.Text = "18-Jul-2001";
			// this.txtDDueDate.Value = 37090;
			this.txtDDueDate.Visible = false;
			// 
			// cmbImportVoucherList
			// 
			this.cmbImportVoucherList.AllowDrop = true;
			this.cmbImportVoucherList.ColumnHeaders = true;
			this.cmbImportVoucherList.Enabled = true;
			this.cmbImportVoucherList.Location = new System.Drawing.Point(867, 318);
			this.cmbImportVoucherList.Name = "cmbImportVoucherList";
			this.cmbImportVoucherList.Size = new System.Drawing.Size(217, 97);
			this.cmbImportVoucherList.TabIndex = 34;
			this.cmbImportVoucherList.Columns.Add(this.Column_0_cmbImportVoucherList);
			this.cmbImportVoucherList.Columns.Add(this.Column_1_cmbImportVoucherList);
			// 
			// Column_0_cmbImportVoucherList
			// 
			this.Column_0_cmbImportVoucherList.DataField = "";
			this.Column_0_cmbImportVoucherList.ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.Normal;
			// 
			// Column_1_cmbImportVoucherList
			// 
			this.Column_1_cmbImportVoucherList.DataField = "";
			this.Column_1_cmbImportVoucherList.ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.Normal;
			// 
			// _txtCommonTextBox_22
			// 
			this._txtCommonTextBox_22.AllowDrop = true;
			this._txtCommonTextBox_22.BackColor = System.Drawing.Color.FromArgb(239, 239, 239);
			// this._txtCommonTextBox_22.bolNumericOnly = true;
			this._txtCommonTextBox_22.Enabled = false;
			this._txtCommonTextBox_22.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_22.Location = new System.Drawing.Point(438, 379);
			this._txtCommonTextBox_22.Name = "_txtCommonTextBox_22";
			// this._txtCommonTextBox_22.ShowButton = true;
			this._txtCommonTextBox_22.Size = new System.Drawing.Size(21, 23);
			this._txtCommonTextBox_22.TabIndex = 35;
			this._txtCommonTextBox_22.Text = "";
			this._txtCommonTextBox_22.Visible = false;
			// this.this._txtCommonTextBox_22.Watermark = "";
			// this.this._txtCommonTextBox_22.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_22.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// cmbMastersList
			// 
			this.cmbMastersList.AllowDrop = true;
			this.cmbMastersList.ColumnHeaders = true;
			this.cmbMastersList.Enabled = true;
			this.cmbMastersList.Location = new System.Drawing.Point(864, 234);
			this.cmbMastersList.Name = "cmbMastersList";
			this.cmbMastersList.Size = new System.Drawing.Size(227, 97);
			this.cmbMastersList.TabIndex = 36;
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
			// txtCreditDays
			// 
			this.txtCreditDays.AllowDrop = true;
			// this.txtCreditDays.DisplayFormat = "####0;;0;0";
			this.txtCreditDays.Location = new System.Drawing.Point(108, 178);
			// this.txtCreditDays.MaxValue = 2147483647;
			// this.txtCreditDays.MinValue = 0;
			this.txtCreditDays.Name = "txtCreditDays";
			this.txtCreditDays.Size = new System.Drawing.Size(36, 25);
			this.txtCreditDays.TabIndex = 137;
			this.txtCreditDays.Visible = false;
			// this.this.txtCreditDays.Change += new System.Windows.Forms.TextBox.ChangeHandler(this.txtCreditDays_Change);
			// 
			// fraRental
			// 
			this.fraRental.AllowDrop = true;
			this.fraRental.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.fraRental.Controls.Add(this.txtStartDate);
			this.fraRental.Controls.Add(this._lblCommonLabel_49);
			this.fraRental.Controls.Add(this.txtDeliveryReturnDate);
			this.fraRental.Controls.Add(this._lblCommonLabel_52);
			this.fraRental.Controls.Add(this.txtDeliveryDate);
			this.fraRental.Controls.Add(this._lblCommonLabel_51);
			this.fraRental.Controls.Add(this.txtEndDate);
			this.fraRental.Controls.Add(this._lblCommonLabel_50);
			this.fraRental.Enabled = true;
			this.fraRental.ForeColor = System.Drawing.SystemColors.ControlText;
			this.fraRental.Location = new System.Drawing.Point(548, 36);
			this.fraRental.Name = "fraRental";
			this.fraRental.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.fraRental.Size = new System.Drawing.Size(401, 73);
			this.fraRental.TabIndex = 138;
			this.fraRental.Visible = true;
			// 
			// txtStartDate
			// 
			this.txtStartDate.AllowDrop = true;
			// this.txtStartDate.CheckDateRange = false;
			this.txtStartDate.Location = new System.Drawing.Point(90, 12);
			// this.txtStartDate.MaxDate = 2958465;
			// this.txtStartDate.MinDate = 32874;
			this.txtStartDate.Name = "txtStartDate";
			this.txtStartDate.Size = new System.Drawing.Size(103, 23);
			this.txtStartDate.TabIndex = 139;
			// this.txtStartDate.Text = "11-Mar-2020";
			// this.txtStartDate.Leave += new System.EventHandler(this.txtStartDate_Leave);
			this.txtStartDate.Validated += new System.EventHandler(this.txtStartDate_Validated);
			this.txtStartDate.Validating += new System.ComponentModel.CancelEventHandler(this.txtStartDate_Validating);
			// 
			// _lblCommonLabel_49
			// 
			this._lblCommonLabel_49.AllowDrop = true;
			this._lblCommonLabel_49.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_49.Text = "Start Date";
			this._lblCommonLabel_49.ForeColor = System.Drawing.Color.Black;
			this._lblCommonLabel_49.Location = new System.Drawing.Point(10, 14);
			this._lblCommonLabel_49.Name = "_lblCommonLabel_49";
			this._lblCommonLabel_49.Size = new System.Drawing.Size(59, 16);
			this._lblCommonLabel_49.TabIndex = 140;
			// 
			// txtDeliveryReturnDate
			// 
			this.txtDeliveryReturnDate.AllowDrop = true;
			// this.txtDeliveryReturnDate.CheckDateRange = false;
			this.txtDeliveryReturnDate.Location = new System.Drawing.Point(294, 40);
			// this.txtDeliveryReturnDate.MaxDate = 2958465;
			// this.txtDeliveryReturnDate.MinDate = 32874;
			this.txtDeliveryReturnDate.Name = "txtDeliveryReturnDate";
			this.txtDeliveryReturnDate.Size = new System.Drawing.Size(103, 23);
			this.txtDeliveryReturnDate.TabIndex = 141;
			// this.txtDeliveryReturnDate.Text = "11-Mar-2020";
			// 
			// _lblCommonLabel_52
			// 
			this._lblCommonLabel_52.AllowDrop = true;
			this._lblCommonLabel_52.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_52.Text = "Return Date";
			this._lblCommonLabel_52.ForeColor = System.Drawing.Color.Black;
			this._lblCommonLabel_52.Location = new System.Drawing.Point(204, 42);
			this._lblCommonLabel_52.Name = "_lblCommonLabel_52";
			this._lblCommonLabel_52.Size = new System.Drawing.Size(69, 16);
			this._lblCommonLabel_52.TabIndex = 142;
			// 
			// txtDeliveryDate
			// 
			this.txtDeliveryDate.AllowDrop = true;
			// this.txtDeliveryDate.CheckDateRange = false;
			this.txtDeliveryDate.Location = new System.Drawing.Point(294, 14);
			// this.txtDeliveryDate.MaxDate = 2958465;
			// this.txtDeliveryDate.MinDate = 32874;
			this.txtDeliveryDate.Name = "txtDeliveryDate";
			this.txtDeliveryDate.Size = new System.Drawing.Size(103, 23);
			this.txtDeliveryDate.TabIndex = 143;
			// this.txtDeliveryDate.Text = "11-Mar-2020";
			// 
			// _lblCommonLabel_51
			// 
			this._lblCommonLabel_51.AllowDrop = true;
			this._lblCommonLabel_51.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_51.Text = "Delivery Date";
			this._lblCommonLabel_51.ForeColor = System.Drawing.Color.Black;
			this._lblCommonLabel_51.Location = new System.Drawing.Point(204, 16);
			this._lblCommonLabel_51.Name = "_lblCommonLabel_51";
			this._lblCommonLabel_51.Size = new System.Drawing.Size(76, 16);
			this._lblCommonLabel_51.TabIndex = 144;
			// 
			// txtEndDate
			// 
			this.txtEndDate.AllowDrop = true;
			// this.txtEndDate.CheckDateRange = false;
			this.txtEndDate.Location = new System.Drawing.Point(90, 40);
			// this.txtEndDate.MaxDate = 2958465;
			// this.txtEndDate.MinDate = 32874;
			this.txtEndDate.Name = "txtEndDate";
			this.txtEndDate.Size = new System.Drawing.Size(103, 23);
			this.txtEndDate.TabIndex = 145;
			// this.txtEndDate.Text = "11-Mar-2020";
			// this.txtEndDate.Leave += new System.EventHandler(this.txtEndDate_Leave);
			this.txtEndDate.Validated += new System.EventHandler(this.txtEndDate_Validated);
			this.txtEndDate.Validating += new System.ComponentModel.CancelEventHandler(this.txtEndDate_Validating);
			// 
			// _lblCommonLabel_50
			// 
			this._lblCommonLabel_50.AllowDrop = true;
			this._lblCommonLabel_50.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_50.Text = "End Date";
			this._lblCommonLabel_50.ForeColor = System.Drawing.Color.Black;
			this._lblCommonLabel_50.Location = new System.Drawing.Point(10, 42);
			this._lblCommonLabel_50.Name = "_lblCommonLabel_50";
			this._lblCommonLabel_50.Size = new System.Drawing.Size(54, 16);
			this._lblCommonLabel_50.TabIndex = 146;
			// 
			// fraProject
			// 
			this.fraProject.AllowDrop = true;
			this.fraProject.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.fraProject.Controls.Add(this._lblCommonLabel_47);
			this.fraProject.Controls.Add(this._txtCommonTextBox_25);
			this.fraProject.Controls.Add(this._txtDisplayLabel_12);
			this.fraProject.Controls.Add(this._lblCommonLabel_27);
			this.fraProject.Controls.Add(this._txtCommonTextBox_21);
			this.fraProject.Controls.Add(this._txtDisplayLabel_11);
			this.fraProject.Controls.Add(this._lblCommonLabel_48);
			this.fraProject.Controls.Add(this._txtCommonTextBox_26);
			this.fraProject.Controls.Add(this._txtDisplayLabel_13);
			this.fraProject.Enabled = true;
			this.fraProject.ForeColor = System.Drawing.SystemColors.ControlText;
			this.fraProject.Location = new System.Drawing.Point(548, 36);
			this.fraProject.Name = "fraProject";
			this.fraProject.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.fraProject.Size = new System.Drawing.Size(421, 73);
			this.fraProject.TabIndex = 133;
			this.fraProject.Visible = true;
			// 
			// _lblCommonLabel_47
			// 
			this._lblCommonLabel_47.AllowDrop = true;
			this._lblCommonLabel_47.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_47.Text = "Project";
			this._lblCommonLabel_47.ForeColor = System.Drawing.Color.Black;
			this._lblCommonLabel_47.Location = new System.Drawing.Point(10, 16);
			this._lblCommonLabel_47.Name = "_lblCommonLabel_47";
			this._lblCommonLabel_47.Size = new System.Drawing.Size(41, 16);
			this._lblCommonLabel_47.TabIndex = 135;
			this._lblCommonLabel_47.Visible = false;
			// 
			// _txtCommonTextBox_25
			// 
			this._txtCommonTextBox_25.AllowDrop = true;
			this._txtCommonTextBox_25.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_25.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_25.Location = new System.Drawing.Point(70, 12);
			this._txtCommonTextBox_25.Name = "_txtCommonTextBox_25";
			// this._txtCommonTextBox_25.ShowButton = true;
			this._txtCommonTextBox_25.Size = new System.Drawing.Size(101, 23);
			this._txtCommonTextBox_25.TabIndex = 10;
			this._txtCommonTextBox_25.Text = "";
			this._txtCommonTextBox_25.Visible = false;
			// this.this._txtCommonTextBox_25.Watermark = "";
			// this.this._txtCommonTextBox_25.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_25.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _txtDisplayLabel_12
			// 
			this._txtDisplayLabel_12.AllowDrop = true;
			this._txtDisplayLabel_12.Location = new System.Drawing.Point(175, 12);
			this._txtDisplayLabel_12.Name = "_txtDisplayLabel_12";
			this._txtDisplayLabel_12.Size = new System.Drawing.Size(241, 23);
			this._txtDisplayLabel_12.TabIndex = 69;
			this._txtDisplayLabel_12.TabStop = false;
			// 
			// _lblCommonLabel_27
			// 
			this._lblCommonLabel_27.AllowDrop = true;
			this._lblCommonLabel_27.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_27.Text = "Job Code";
			this._lblCommonLabel_27.ForeColor = System.Drawing.Color.Black;
			this._lblCommonLabel_27.Location = new System.Drawing.Point(10, 16);
			this._lblCommonLabel_27.Name = "_lblCommonLabel_27";
			this._lblCommonLabel_27.Size = new System.Drawing.Size(54, 16);
			this._lblCommonLabel_27.TabIndex = 134;
			this._lblCommonLabel_27.Visible = false;
			// 
			// _txtCommonTextBox_21
			// 
			this._txtCommonTextBox_21.AllowDrop = true;
			this._txtCommonTextBox_21.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_21.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_21.Location = new System.Drawing.Point(71, 12);
			this._txtCommonTextBox_21.Name = "_txtCommonTextBox_21";
			// this._txtCommonTextBox_21.ShowButton = true;
			this._txtCommonTextBox_21.Size = new System.Drawing.Size(101, 23);
			this._txtCommonTextBox_21.TabIndex = 67;
			this._txtCommonTextBox_21.Text = "";
			this._txtCommonTextBox_21.Visible = false;
			// this.this._txtCommonTextBox_21.Watermark = "";
			// this.this._txtCommonTextBox_21.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_21.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _txtDisplayLabel_11
			// 
			this._txtDisplayLabel_11.AllowDrop = true;
			this._txtDisplayLabel_11.Location = new System.Drawing.Point(175, 12);
			this._txtDisplayLabel_11.Name = "_txtDisplayLabel_11";
			this._txtDisplayLabel_11.Size = new System.Drawing.Size(241, 23);
			this._txtDisplayLabel_11.TabIndex = 68;
			this._txtDisplayLabel_11.TabStop = false;
			// 
			// _lblCommonLabel_48
			// 
			this._lblCommonLabel_48.AllowDrop = true;
			this._lblCommonLabel_48.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_48.Text = "Activity";
			this._lblCommonLabel_48.ForeColor = System.Drawing.Color.Black;
			this._lblCommonLabel_48.Location = new System.Drawing.Point(10, 42);
			this._lblCommonLabel_48.Name = "_lblCommonLabel_48";
			this._lblCommonLabel_48.Size = new System.Drawing.Size(42, 16);
			this._lblCommonLabel_48.TabIndex = 136;
			this._lblCommonLabel_48.Visible = false;
			// 
			// _txtCommonTextBox_26
			// 
			this._txtCommonTextBox_26.AllowDrop = true;
			this._txtCommonTextBox_26.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_26.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_26.Location = new System.Drawing.Point(71, 38);
			this._txtCommonTextBox_26.Name = "_txtCommonTextBox_26";
			// this._txtCommonTextBox_26.ShowButton = true;
			this._txtCommonTextBox_26.Size = new System.Drawing.Size(101, 23);
			this._txtCommonTextBox_26.TabIndex = 11;
			this._txtCommonTextBox_26.Text = "";
			this._txtCommonTextBox_26.Visible = false;
			// this.this._txtCommonTextBox_26.Watermark = "";
			// this.this._txtCommonTextBox_26.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_26.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _txtDisplayLabel_13
			// 
			this._txtDisplayLabel_13.AllowDrop = true;
			this._txtDisplayLabel_13.Location = new System.Drawing.Point(175, 38);
			this._txtDisplayLabel_13.Name = "_txtDisplayLabel_13";
			this._txtDisplayLabel_13.Size = new System.Drawing.Size(241, 23);
			this._txtDisplayLabel_13.TabIndex = 70;
			this._txtDisplayLabel_13.TabStop = false;
			// 
			// lblVoucherName
			// 
			this.lblVoucherName.AllowDrop = true;
			this.lblVoucherName.AutoSize = true;
			this.lblVoucherName.BackColor = System.Drawing.Color.Transparent;
			this.lblVoucherName.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lblVoucherName.Font = new System.Drawing.Font("Arial", 20.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 178);
			this.lblVoucherName.ForeColor = System.Drawing.Color.Navy;
			this.lblVoucherName.Location = new System.Drawing.Point(532, 12);
			this.lblVoucherName.Name = "lblVoucherName";
			this.lblVoucherName.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblVoucherName.Size = new System.Drawing.Size(76, 32);
			this.lblVoucherName.TabIndex = 91;
			this.lblVoucherName.Text = "Name";
			// 
			// fraVoucherName
			// 
			this.fraVoucherName.AllowDrop = true;
			this.fraVoucherName.BackColor = System.Drawing.Color.Black;
			this.fraVoucherName.BackStyle = 0;
			this.fraVoucherName.BorderColor = System.Drawing.Color.Black;
			this.fraVoucherName.BorderStyle = 1;
			this.fraVoucherName.Enabled = false;
			this.fraVoucherName.FillColor = System.Drawing.Color.Black;
			this.fraVoucherName.FillStyle = 1;
			this.fraVoucherName.Location = new System.Drawing.Point(520, 8);
			this.fraVoucherName.Name = "fraVoucherName";
			this.fraVoucherName.Size = new System.Drawing.Size(302, 41);
			this.fraVoucherName.Visible = true;
			// 
			// fraVoucherImport
			// 
			this.fraVoucherImport.AllowDrop = true;
			this.fraVoucherImport.BackColor = System.Drawing.Color.White;
			this.fraVoucherImport.BackStyle = 0;
			this.fraVoucherImport.BorderColor = System.Drawing.Color.Black;
			this.fraVoucherImport.BorderStyle = 1;
			this.fraVoucherImport.Enabled = false;
			this.fraVoucherImport.FillColor = System.Drawing.Color.Black;
			this.fraVoucherImport.FillStyle = 1;
			this.fraVoucherImport.Location = new System.Drawing.Point(757, 118);
			this.fraVoucherImport.Name = "fraVoucherImport";
			this.fraVoucherImport.Size = new System.Drawing.Size(206, 87);
			this.fraVoucherImport.Visible = false;
			// 
			// fraVoucherType
			// 
			this.fraVoucherType.AllowDrop = true;
			this.fraVoucherType.BackColor = System.Drawing.Color.Black;
			this.fraVoucherType.BackStyle = 0;
			this.fraVoucherType.BorderColor = System.Drawing.Color.Black;
			this.fraVoucherType.BorderStyle = 1;
			this.fraVoucherType.Enabled = false;
			this.fraVoucherType.FillColor = System.Drawing.Color.Black;
			this.fraVoucherType.FillStyle = 1;
			this.fraVoucherType.Location = new System.Drawing.Point(522, 156);
			this.fraVoucherType.Name = "fraVoucherType";
			this.fraVoucherType.Size = new System.Drawing.Size(129, 49);
			this.fraVoucherType.Visible = true;
			// 
			// fraCustomerDetails
			// 
			this.fraCustomerDetails.AllowDrop = true;
			this.fraCustomerDetails.BackColor = System.Drawing.Color.Black;
			this.fraCustomerDetails.BackStyle = 0;
			this.fraCustomerDetails.BorderColor = System.Drawing.Color.Black;
			this.fraCustomerDetails.BorderStyle = 1;
			this.fraCustomerDetails.Enabled = false;
			this.fraCustomerDetails.FillColor = System.Drawing.Color.Black;
			this.fraCustomerDetails.FillStyle = 1;
			this.fraCustomerDetails.Location = new System.Drawing.Point(2, 124);
			this.fraCustomerDetails.Name = "fraCustomerDetails";
			this.fraCustomerDetails.Size = new System.Drawing.Size(517, 81);
			this.fraCustomerDetails.Visible = true;
			// 
			// frmHeader
			// 
			this.frmHeader.AllowDrop = true;
			this.frmHeader.BackColor = System.Drawing.Color.Black;
			this.frmHeader.BackStyle = 0;
			this.frmHeader.BorderColor = System.Drawing.Color.Black;
			this.frmHeader.BorderStyle = 1;
			this.frmHeader.Enabled = false;
			this.frmHeader.FillColor = System.Drawing.Color.Black;
			this.frmHeader.FillStyle = 1;
			this.frmHeader.Location = new System.Drawing.Point(2, 8);
			this.frmHeader.Name = "frmHeader";
			this.frmHeader.Size = new System.Drawing.Size(516, 111);
			this.frmHeader.Visible = true;
			// 
			// fraTransactionHeader
			// 
			this.fraTransactionHeader.AllowDrop = true;
			this.fraTransactionHeader.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.fraTransactionHeader.BackStyle = 1;
			this.fraTransactionHeader.BorderStyle = 0;
			this.fraTransactionHeader.Enabled = false;
			this.fraTransactionHeader.FillColor = System.Drawing.Color.Black;
			this.fraTransactionHeader.FillStyle = 1;
			this.fraTransactionHeader.Location = new System.Drawing.Point(0, 0);
			this.fraTransactionHeader.Name = "fraTransactionHeader";
			this.fraTransactionHeader.Size = new System.Drawing.Size(830, 209);
			this.fraTransactionHeader.Visible = true;
			// 
			// CommandBars
			// 
			this.CommandBars.AllowDrop = true;
			this.CommandBars.Location = new System.Drawing.Point(0, 554);
			this.CommandBars.Name = "CommandBars";
			("CommandBars.OcxState");
			// 
			// frmICSTransactionMaster
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.ClientSize = new System.Drawing.Size(1362, 661);
			this.Controls.Add(this.frameBottom);
			this.Controls.Add(this.tabMain);
			this.Controls.Add(this.CommandBars);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			//this.Icon = (System.Drawing.Icon) resources.GetObject("frmICSTransactionMaster.Icon");
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(-58, 30);
			this.MaximizeBox = true;
			this.MinimizeBox = true;
			this.Name = "frmICSTransactionMaster";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Tag = "\"H: 6225  W:9570\"";
			this.Text = "Common Voucher";
			this.ToolTipMain.SetToolTip(this.txtLdgrName, "Salesman Name in English");
			// this.Activated += new System.EventHandler(this.Form_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
			//this.Resize += new System.EventHandler(this.Form_Resize);
			//((System.ComponentModel.ISupportInitialize) this.tabOtherInfo).EndInit();
			//((System.ComponentModel.ISupportInitialize) this.tabAdditionalInfo).EndInit();
			//((System.ComponentModel.ISupportInitialize) this._TabControlPage3_2).EndInit();
			//((System.ComponentModel.ISupportInitialize) this._TabControlPage2_1).EndInit();
			//((System.ComponentModel.ISupportInitialize) this.txtTempDate).EndInit();
			//((System.ComponentModel.ISupportInitialize) this.fraMasterInformation).EndInit();
			//((System.ComponentModel.ISupportInitialize) this.tabMaster).EndInit();
			//((System.ComponentModel.ISupportInitialize) this.cmdAddtionalDetails).EndInit();
			//((System.ComponentModel.ISupportInitialize) this.tabGeneral).EndInit();
			//((System.ComponentModel.ISupportInitialize) this.tabMain).EndInit();
			//((System.ComponentModel.ISupportInitialize) this.CommandBars).EndInit();
			this.frameBottom.ResumeLayout(false);
			this.fraPayments.ResumeLayout(false);
			this.tabMain.ResumeLayout(false);
			this.tabOtherInfo.ResumeLayout(false);
			this.Frame1.ResumeLayout(false);
			this.tabAdditionalInfo.ResumeLayout(false);
			this.farDeliveryDeetail.ResumeLayout(false);
			this.fraPaymentDetail.ResumeLayout(false);
			this.fraOrderDetail.ResumeLayout(false);
			this.fraContactDetail.ResumeLayout(false);
			this.tabGeneral.ResumeLayout(false);
			this.tabMaster.ResumeLayout(false);
			this._TabControlPage3_2.ResumeLayout(false);
			this.grdSupplierDetails.ResumeLayout(false);
			this._TabControlPage2_1.ResumeLayout(false);
			this.cmbSupplierList.ResumeLayout(false);
			this.grdImportVoucherDetails.ResumeLayout(false);
			this.fraMasterInformation.ResumeLayout(false);
			this.grdVoucherDetails.ResumeLayout(false);
			this.cmbImportVoucherList.ResumeLayout(false);
			this.cmbMastersList.ResumeLayout(false);
			this.fraRental.ResumeLayout(false);
			this.fraProject.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		// 
		void InitializetxtDisplayLabel()
		{
			this.txtDisplayLabel = new System.Windows.Forms.Label[16];
			this.txtDisplayLabel[3] = _txtDisplayLabel_3;
			this.txtDisplayLabel[15] = _txtDisplayLabel_15;
			this.txtDisplayLabel[1] = _txtDisplayLabel_1;
			this.txtDisplayLabel[8] = _txtDisplayLabel_8;
			this.txtDisplayLabel[2] = _txtDisplayLabel_2;
			this.txtDisplayLabel[10] = _txtDisplayLabel_10;
			this.txtDisplayLabel[6] = _txtDisplayLabel_6;
			this.txtDisplayLabel[12] = _txtDisplayLabel_12;
			this.txtDisplayLabel[11] = _txtDisplayLabel_11;
			this.txtDisplayLabel[13] = _txtDisplayLabel_13;
		}
		void InitializetxtCommonTextBox()
		{
			this.txtCommonTextBox = new System.Windows.Forms.TextBox[27];
			this.txtCommonTextBox[5] = _txtCommonTextBox_5;
			this.txtCommonTextBox[6] = _txtCommonTextBox_6;
			this.txtCommonTextBox[0] = _txtCommonTextBox_0;
			this.txtCommonTextBox[3] = _txtCommonTextBox_3;
			this.txtCommonTextBox[1] = _txtCommonTextBox_1;
			this.txtCommonTextBox[7] = _txtCommonTextBox_7;
			this.txtCommonTextBox[15] = _txtCommonTextBox_15;
			this.txtCommonTextBox[8] = _txtCommonTextBox_8;
			this.txtCommonTextBox[13] = _txtCommonTextBox_13;
			this.txtCommonTextBox[23] = _txtCommonTextBox_23;
			this.txtCommonTextBox[24] = _txtCommonTextBox_24;
			this.txtCommonTextBox[9] = _txtCommonTextBox_9;
			this.txtCommonTextBox[19] = _txtCommonTextBox_19;
			this.txtCommonTextBox[18] = _txtCommonTextBox_18;
			this.txtCommonTextBox[17] = _txtCommonTextBox_17;
			this.txtCommonTextBox[4] = _txtCommonTextBox_4;
			this.txtCommonTextBox[20] = _txtCommonTextBox_20;
			this.txtCommonTextBox[22] = _txtCommonTextBox_22;
			this.txtCommonTextBox[25] = _txtCommonTextBox_25;
			this.txtCommonTextBox[21] = _txtCommonTextBox_21;
			this.txtCommonTextBox[26] = _txtCommonTextBox_26;
		}
		void InitializeoptVoucherType()
		{
			this.optVoucherType = new System.Windows.Forms.RadioButton[2];
			this.optVoucherType[1] = _optVoucherType_1;
			this.optVoucherType[0] = _optVoucherType_0;
		}
		void InitializelblCommonLabel()
		{
			this.lblCommonLabel = new System.Windows.Forms.Label[54];
			this.lblCommonLabel[15] = _lblCommonLabel_15;
			this.lblCommonLabel[9] = _lblCommonLabel_9;
			this.lblCommonLabel[11] = _lblCommonLabel_11;
			this.lblCommonLabel[10] = _lblCommonLabel_10;
			this.lblCommonLabel[12] = _lblCommonLabel_12;
			this.lblCommonLabel[53] = _lblCommonLabel_53;
			this.lblCommonLabel[37] = _lblCommonLabel_37;
			this.lblCommonLabel[38] = _lblCommonLabel_38;
			this.lblCommonLabel[39] = _lblCommonLabel_39;
			this.lblCommonLabel[40] = _lblCommonLabel_40;
			this.lblCommonLabel[42] = _lblCommonLabel_42;
			this.lblCommonLabel[43] = _lblCommonLabel_43;
			this.lblCommonLabel[45] = _lblCommonLabel_45;
			this.lblCommonLabel[46] = _lblCommonLabel_46;
			this.lblCommonLabel[41] = _lblCommonLabel_41;
			this.lblCommonLabel[36] = _lblCommonLabel_36;
			this.lblCommonLabel[44] = _lblCommonLabel_44;
			this.lblCommonLabel[32] = _lblCommonLabel_32;
			this.lblCommonLabel[33] = _lblCommonLabel_33;
			this.lblCommonLabel[34] = _lblCommonLabel_34;
			this.lblCommonLabel[18] = _lblCommonLabel_18;
			this.lblCommonLabel[30] = _lblCommonLabel_30;
			this.lblCommonLabel[35] = _lblCommonLabel_35;
			this.lblCommonLabel[31] = _lblCommonLabel_31;
			this.lblCommonLabel[0] = _lblCommonLabel_0;
			this.lblCommonLabel[1] = _lblCommonLabel_1;
			this.lblCommonLabel[13] = _lblCommonLabel_13;
			this.lblCommonLabel[16] = _lblCommonLabel_16;
			this.lblCommonLabel[14] = _lblCommonLabel_14;
			this.lblCommonLabel[19] = _lblCommonLabel_19;
			this.lblCommonLabel[2] = _lblCommonLabel_2;
			this.lblCommonLabel[5] = _lblCommonLabel_5;
			this.lblCommonLabel[3] = _lblCommonLabel_3;
			this.lblCommonLabel[6] = _lblCommonLabel_6;
			this.lblCommonLabel[24] = _lblCommonLabel_24;
			this.lblCommonLabel[17] = _lblCommonLabel_17;
			this.lblCommonLabel[7] = _lblCommonLabel_7;
			this.lblCommonLabel[28] = _lblCommonLabel_28;
			this.lblCommonLabel[29] = _lblCommonLabel_29;
			this.lblCommonLabel[8] = _lblCommonLabel_8;
			this.lblCommonLabel[20] = _lblCommonLabel_20;
			this.lblCommonLabel[23] = _lblCommonLabel_23;
			this.lblCommonLabel[22] = _lblCommonLabel_22;
			this.lblCommonLabel[21] = _lblCommonLabel_21;
			this.lblCommonLabel[4] = _lblCommonLabel_4;
			this.lblCommonLabel[25] = _lblCommonLabel_25;
			this.lblCommonLabel[26] = _lblCommonLabel_26;
			this.lblCommonLabel[49] = _lblCommonLabel_49;
			this.lblCommonLabel[52] = _lblCommonLabel_52;
			this.lblCommonLabel[51] = _lblCommonLabel_51;
			this.lblCommonLabel[50] = _lblCommonLabel_50;
			this.lblCommonLabel[47] = _lblCommonLabel_47;
			this.lblCommonLabel[27] = _lblCommonLabel_27;
			this.lblCommonLabel[48] = _lblCommonLabel_48;
		}
		void InitializecomCommon()
		{
			this.comCommon = new System.Windows.Forms.ComboBox[6];
			this.comCommon[2] = _comCommon_2;
			this.comCommon[3] = _comCommon_3;
			this.comCommon[4] = _comCommon_4;
			this.comCommon[5] = _comCommon_5;
			this.comCommon[1] = _comCommon_1;
		}
		void InitializeTabControlPage3()
		{
			this.TabControlPage3 = new AxXtremeSuiteControls.AxTabControlPage[3];
			this.TabControlPage3[2] = _TabControlPage3_2;
		}
		void InitializeTabControlPage2()
		{
			this.TabControlPage2 = new AxXtremeSuiteControls.AxTabControlPage[2];
			this.TabControlPage2[1] = _TabControlPage2_1;
		}
		#endregion
	}
}//ENDSHERE
