
namespace Xtreme
{
	partial class frmICSItems
	{

		#region "Upgrade Support "
		private static frmICSItems m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmICSItems DefInstance
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
		public static frmICSItems CreateInstance()
		{
			frmICSItems theInstance = new frmICSItems();
			
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
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "txtProdDesc", "_chkCommon_0", "_chkCommon_1", "Column_0_cmbActivityList", "Column_1_cmbActivityList", "cmbActivityList", "Column_0_grdActivityDetails", "Column_1_grdActivityDetails", "grdActivityDetails", "_fraProductInformation_12", "_chkCommon_3", "Column_0_cmbMastersList", "Column_1_cmbMastersList", "cmbMastersList", "_lblCommon_27", "Column_0_grdAssemblyDetails", "Column_1_grdAssemblyDetails", "grdAssemblyDetails", "_fraProductInformation_4", "txtComment", "_cmdCommon_1", "_cmdCommon_2", "_cmdCommon_0", "_txtCommon_9", "imgPicture", "Image1", "_fraProductInformation_5", "_txtCommon_6", "_txtCommon_5", "_lblCommon_6", "_lblCommon_7", "_lblCommon_10", "_txtCommonDisplay_1", "_txtCommonDisplay_2", "_txtCommon_4", "_lblCommon_5", "_txtCommonDisplay_0", "_txtCommon_3", "_lblCommon_50", "_txtCommonDisplay_5", "_fraProductInformation_0", "Column_0_grdPriceDetails", "Column_1_grdPriceDetails", "grdPriceDetails", "_chkCommon_2", "_txtCommonNumber_12", "_txtCommonNumber_11", "_txtCommonNumber_10", "_txtCommonNumber_9", "_lblCommon_20", "_lblCommon_23", "_lblCommon_21", "_lblCommon_22", "_lblCommon_19", "_txtCommonNumber_8", "_fraProductInformation_3", "_txtCommonNumber_4", "_txtCommonNumber_7", "_txtCommonNumber_6", "_txtCommonNumber_5", "_lblCommon_15", "_lblCommon_18", "_lblCommon_16", "_lblCommon_17", "_lblCommon_14", "_fraProductInformation_6", "_txtCommonNumber_14", "_lblCommon_12", "_txtCommonNumber_1", "_lblCommon_25", "_lblCommon_24", "_txtCommonNumber_13", "_lblCommon_13", "_txtCommonNumber_2", "Column_0_cmbPriceList", "Column_1_cmbPriceList", "cmbPriceList", "_txtCommonNumber_3", "_fraProductInformation_1", "txtExpDate", "txtPackDate", "_lblCommon_26", "_lblCommon_33", "_lblCommon_34", "_txtCommon_10", "_txtCommon_12", "_lblCommon_51", "frmPackageInfo", "_lblCommon_32", "_txtCommon_8", "_txtCommon_7", "_lblCommon_31", "_txtCommonDisplay_3", "_fraProductInformation_8", "_lblCommon_29", "_txtCommonNumber_15", "_lblCommon_35", "_txtCommonNumber_16", "_fraProductInformation_2", "Column_0_grdProductLevelDetails", "Column_1_grdProductLevelDetails", "grdProductLevelDetails", "_lblCommon_28", "_fraProductInformation_7", "_txtFlex_1", "_lblCommon_36", "_txtFlexDisplay_1", "_txtFlex_2", "_lblCommon_38", "_txtFlexDisplay_2", "_txtFlex_3", "_lblCommon_39", "_txtFlexDisplay_3", "_txtFlex_4", "_lblCommon_40", "_txtFlexDisplay_4", "_txtFlex_5", "_lblCommon_41", "_txtFlexDisplay_5", "_txtFlex_6", "_lblCommon_42", "_txtFlexDisplay_6", "_txtFlex_7", "_lblCommon_43", "_txtFlexDisplay_7", "_txtFlex_8", "_lblCommon_44", "_txtFlexDisplay_8", "_txtFlex_9", "_lblCommon_45", "_txtFlexDisplay_9", "_txtFlex_10", "_lblCommon_46", "_txtFlexDisplay_10", "_txtFlex_11", "_lblCommon_47", "_txtFlexDisplay_11", "_txtFlex_12", "_lblCommon_48", "_txtFlexDisplay_12", "_txtFlex_13", "_lblCommon_49", "_txtFlexDisplay_13", "_txtFlex_14", "_lblCommon_37", "_txtFlexDisplay_14", "_fraProductInformation_9", "_lblCommon_30", "Column_0_grdSupplierDetails", "Column_1_grdSupplierDetails", "grdSupplierDetails", "Column_0_cmdSupplierList", "Column_1_cmdSupplierList", "cmdSupplierList", "_fraProductInformation_10", "Column_0_cmbBarcodeList", "Column_1_cmbBarcodeList", "cmbBarcodeList", "Column_0_grdBarcodeDetails", "Column_1_grdBarcodeDetails", "grdBarcodeDetails", "_fraProductInformation_11", "tabMaster", "_cmbCommon_0", "_lblCommon_8", "_cmbCommon_1", "_lblCommon_9", "_txtCommonNumber_0", "_lblCommon_11", "_txtCommon_2", "_lblCommon_4", "_txtCommon_0", "_lblCommon_3", "_lblCommon_1", "_txtCommon_1", "_lblCommon_2", "_lblCommon_0", "CommonDialog1Open", "CommonDialog1", "_txtCommon_11", "chkCommon", "cmbCommon", "cmdCommon", "fraProductInformation", "lblCommon", "txtCommon", "txtCommonDisplay", "txtCommonNumber", "txtFlex", "txtFlexDisplay"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public System.Windows.Forms.TextBox txtProdDesc;
		private System.Windows.Forms.CheckBox _chkCommon_0;
		private System.Windows.Forms.CheckBox _chkCommon_1;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_0_cmbActivityList;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_1_cmbActivityList;
		public C1.Win.C1TrueDBGrid.C1TrueDBDropdown cmbActivityList;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_0_grdActivityDetails;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_1_grdActivityDetails;
		public C1.Win.C1TrueDBGrid.C1TrueDBGrid grdActivityDetails;
		private System.Windows.Forms.GroupBox _fraProductInformation_12;
		private System.Windows.Forms.CheckBox _chkCommon_3;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_0_cmbMastersList;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_1_cmbMastersList;
		public C1.Win.C1TrueDBGrid.C1TrueDBDropdown cmbMastersList;
		private System.Windows.Forms.Label _lblCommon_27;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_0_grdAssemblyDetails;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_1_grdAssemblyDetails;
		public C1.Win.C1TrueDBGrid.C1TrueDBGrid grdAssemblyDetails;
		private System.Windows.Forms.GroupBox _fraProductInformation_4;
		public System.Windows.Forms.TextBox txtComment;
		private System.Windows.Forms.Button _cmdCommon_1;
		private System.Windows.Forms.Button _cmdCommon_2;
		private System.Windows.Forms.Button _cmdCommon_0;
		private System.Windows.Forms.TextBox _txtCommon_9;
		public System.Windows.Forms.PictureBox imgPicture;
		public System.Windows.Forms.PictureBox Image1;
		private System.Windows.Forms.GroupBox _fraProductInformation_5;
		private System.Windows.Forms.TextBox _txtCommon_6;
		private System.Windows.Forms.TextBox _txtCommon_5;
		private System.Windows.Forms.Label _lblCommon_6;
		private System.Windows.Forms.Label _lblCommon_7;
		private System.Windows.Forms.Label _lblCommon_10;
		private System.Windows.Forms.Label _txtCommonDisplay_1;
		private System.Windows.Forms.Label _txtCommonDisplay_2;
		private System.Windows.Forms.TextBox _txtCommon_4;
		private System.Windows.Forms.Label _lblCommon_5;
		private System.Windows.Forms.Label _txtCommonDisplay_0;
		private System.Windows.Forms.TextBox _txtCommon_3;
		private System.Windows.Forms.Label _lblCommon_50;
		private System.Windows.Forms.Label _txtCommonDisplay_5;
		private System.Windows.Forms.GroupBox _fraProductInformation_0;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_0_grdPriceDetails;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_1_grdPriceDetails;
		public C1.Win.C1TrueDBGrid.C1TrueDBGrid grdPriceDetails;
		private System.Windows.Forms.CheckBox _chkCommon_2;
		private System.Windows.Forms.TextBox _txtCommonNumber_12;
		private System.Windows.Forms.TextBox _txtCommonNumber_11;
		private System.Windows.Forms.TextBox _txtCommonNumber_10;
		private System.Windows.Forms.TextBox _txtCommonNumber_9;
		private System.Windows.Forms.Label _lblCommon_20;
		private System.Windows.Forms.Label _lblCommon_23;
		private System.Windows.Forms.Label _lblCommon_21;
		private System.Windows.Forms.Label _lblCommon_22;
		private System.Windows.Forms.Label _lblCommon_19;
		private System.Windows.Forms.TextBox _txtCommonNumber_8;
		private System.Windows.Forms.GroupBox _fraProductInformation_3;
		private System.Windows.Forms.TextBox _txtCommonNumber_4;
		private System.Windows.Forms.TextBox _txtCommonNumber_7;
		private System.Windows.Forms.TextBox _txtCommonNumber_6;
		private System.Windows.Forms.TextBox _txtCommonNumber_5;
		private System.Windows.Forms.Label _lblCommon_15;
		private System.Windows.Forms.Label _lblCommon_18;
		private System.Windows.Forms.Label _lblCommon_16;
		private System.Windows.Forms.Label _lblCommon_17;
		private System.Windows.Forms.Label _lblCommon_14;
		private System.Windows.Forms.GroupBox _fraProductInformation_6;
		private System.Windows.Forms.TextBox _txtCommonNumber_14;
		private System.Windows.Forms.Label _lblCommon_12;
		private System.Windows.Forms.TextBox _txtCommonNumber_1;
		private System.Windows.Forms.Label _lblCommon_25;
		private System.Windows.Forms.Label _lblCommon_24;
		private System.Windows.Forms.TextBox _txtCommonNumber_13;
		private System.Windows.Forms.Label _lblCommon_13;
		private System.Windows.Forms.TextBox _txtCommonNumber_2;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_0_cmbPriceList;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_1_cmbPriceList;
		public C1.Win.C1TrueDBGrid.C1TrueDBDropdown cmbPriceList;
		private System.Windows.Forms.TextBox _txtCommonNumber_3;
		private System.Windows.Forms.GroupBox _fraProductInformation_1;
		public Syncfusion.WinForms.Input.SfDateTimeEdit txtExpDate;
		public Syncfusion.WinForms.Input.SfDateTimeEdit txtPackDate;
		private System.Windows.Forms.Label _lblCommon_26;
		private System.Windows.Forms.Label _lblCommon_33;
		private System.Windows.Forms.Label _lblCommon_34;
		private System.Windows.Forms.TextBox _txtCommon_10;
		private System.Windows.Forms.TextBox _txtCommon_12;
		private System.Windows.Forms.Label _lblCommon_51;
		public System.Windows.Forms.GroupBox frmPackageInfo;
		private System.Windows.Forms.Label _lblCommon_32;
		private System.Windows.Forms.TextBox _txtCommon_8;
		private System.Windows.Forms.TextBox _txtCommon_7;
		private System.Windows.Forms.Label _lblCommon_31;
		private System.Windows.Forms.Label _txtCommonDisplay_3;
		private System.Windows.Forms.GroupBox _fraProductInformation_8;
		private System.Windows.Forms.Label _lblCommon_29;
		private System.Windows.Forms.TextBox _txtCommonNumber_15;
		private System.Windows.Forms.Label _lblCommon_35;
		private System.Windows.Forms.TextBox _txtCommonNumber_16;
		private System.Windows.Forms.GroupBox _fraProductInformation_2;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_0_grdProductLevelDetails;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_1_grdProductLevelDetails;
		public C1.Win.C1TrueDBGrid.C1TrueDBGrid grdProductLevelDetails;
		private System.Windows.Forms.Label _lblCommon_28;
		private System.Windows.Forms.GroupBox _fraProductInformation_7;
		private System.Windows.Forms.TextBox _txtFlex_1;
		private System.Windows.Forms.Label _lblCommon_36;
		private System.Windows.Forms.Label _txtFlexDisplay_1;
		private System.Windows.Forms.TextBox _txtFlex_2;
		private System.Windows.Forms.Label _lblCommon_38;
		private System.Windows.Forms.Label _txtFlexDisplay_2;
		private System.Windows.Forms.TextBox _txtFlex_3;
		private System.Windows.Forms.Label _lblCommon_39;
		private System.Windows.Forms.Label _txtFlexDisplay_3;
		private System.Windows.Forms.TextBox _txtFlex_4;
		private System.Windows.Forms.Label _lblCommon_40;
		private System.Windows.Forms.Label _txtFlexDisplay_4;
		private System.Windows.Forms.TextBox _txtFlex_5;
		private System.Windows.Forms.Label _lblCommon_41;
		private System.Windows.Forms.Label _txtFlexDisplay_5;
		private System.Windows.Forms.TextBox _txtFlex_6;
		private System.Windows.Forms.Label _lblCommon_42;
		private System.Windows.Forms.Label _txtFlexDisplay_6;
		private System.Windows.Forms.TextBox _txtFlex_7;
		private System.Windows.Forms.Label _lblCommon_43;
		private System.Windows.Forms.Label _txtFlexDisplay_7;
		private System.Windows.Forms.TextBox _txtFlex_8;
		private System.Windows.Forms.Label _lblCommon_44;
		private System.Windows.Forms.Label _txtFlexDisplay_8;
		private System.Windows.Forms.TextBox _txtFlex_9;
		private System.Windows.Forms.Label _lblCommon_45;
		private System.Windows.Forms.Label _txtFlexDisplay_9;
		private System.Windows.Forms.TextBox _txtFlex_10;
		private System.Windows.Forms.Label _lblCommon_46;
		private System.Windows.Forms.Label _txtFlexDisplay_10;
		private System.Windows.Forms.TextBox _txtFlex_11;
		private System.Windows.Forms.Label _lblCommon_47;
		private System.Windows.Forms.Label _txtFlexDisplay_11;
		private System.Windows.Forms.TextBox _txtFlex_12;
		private System.Windows.Forms.Label _lblCommon_48;
		private System.Windows.Forms.Label _txtFlexDisplay_12;
		private System.Windows.Forms.TextBox _txtFlex_13;
		private System.Windows.Forms.Label _lblCommon_49;
		private System.Windows.Forms.Label _txtFlexDisplay_13;
		private System.Windows.Forms.TextBox _txtFlex_14;
		private System.Windows.Forms.Label _lblCommon_37;
		private System.Windows.Forms.Label _txtFlexDisplay_14;
		private System.Windows.Forms.GroupBox _fraProductInformation_9;
		private System.Windows.Forms.Label _lblCommon_30;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_0_grdSupplierDetails;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_1_grdSupplierDetails;
		public C1.Win.C1TrueDBGrid.C1TrueDBGrid grdSupplierDetails;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_0_cmdSupplierList;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_1_cmdSupplierList;
		public C1.Win.C1TrueDBGrid.C1TrueDBDropdown cmdSupplierList;
		private System.Windows.Forms.GroupBox _fraProductInformation_10;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_0_cmbBarcodeList;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_1_cmbBarcodeList;
		public C1.Win.C1TrueDBGrid.C1TrueDBDropdown cmbBarcodeList;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_0_grdBarcodeDetails;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_1_grdBarcodeDetails;
		public C1.Win.C1TrueDBGrid.C1TrueDBGrid grdBarcodeDetails;
		private System.Windows.Forms.GroupBox _fraProductInformation_11;
		public Syncfusion.Windows.Forms.Tools.TabControlAdv tabMaster;
		private System.Windows.Forms.ComboBox _cmbCommon_0;
		private System.Windows.Forms.Label _lblCommon_8;
		private System.Windows.Forms.ComboBox _cmbCommon_1;
		private System.Windows.Forms.Label _lblCommon_9;
		private System.Windows.Forms.TextBox _txtCommonNumber_0;
		private System.Windows.Forms.Label _lblCommon_11;
		private System.Windows.Forms.TextBox _txtCommon_2;
		private System.Windows.Forms.Label _lblCommon_4;
		private System.Windows.Forms.TextBox _txtCommon_0;
		private System.Windows.Forms.Label _lblCommon_3;
		private System.Windows.Forms.Label _lblCommon_1;
		private System.Windows.Forms.TextBox _txtCommon_1;
		private System.Windows.Forms.Label _lblCommon_2;
		private System.Windows.Forms.Label _lblCommon_0;
		public System.Windows.Forms.OpenFileDialog CommonDialog1Open;
		public UpgradeStubs.AxMSComDlg_AxCommonDialog CommonDialog1;
		private System.Windows.Forms.TextBox _txtCommon_11;
		public System.Windows.Forms.CheckBox[] chkCommon = new System.Windows.Forms.CheckBox[4];
		public System.Windows.Forms.ComboBox[] cmbCommon = new System.Windows.Forms.ComboBox[2];
		public System.Windows.Forms.Button[] cmdCommon = new System.Windows.Forms.Button[3];
		public System.Windows.Forms.GroupBox[] fraProductInformation = new System.Windows.Forms.GroupBox[13];
		public System.Windows.Forms.Label[] lblCommon = new System.Windows.Forms.Label[52];
		public System.Windows.Forms.TextBox[] txtCommon = new System.Windows.Forms.TextBox[13];
		public System.Windows.Forms.Label[] txtCommonDisplay = new System.Windows.Forms.Label[6];
		public System.Windows.Forms.TextBox[] txtCommonNumber = new System.Windows.Forms.TextBox[17];
		public System.Windows.Forms.TextBox[] txtFlex = new System.Windows.Forms.TextBox[15];
		public System.Windows.Forms.Label[] txtFlexDisplay = new System.Windows.Forms.Label[15];
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmICSItems));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this.txtProdDesc = new System.Windows.Forms.TextBox();
			this._chkCommon_0 = new System.Windows.Forms.CheckBox();
			this._chkCommon_1 = new System.Windows.Forms.CheckBox();
			this.tabMaster = new Syncfusion.Windows.Forms.Tools.TabControlAdv();
			this._fraProductInformation_12 = new System.Windows.Forms.GroupBox();
			this.cmbActivityList = new C1.Win.C1TrueDBGrid.C1TrueDBDropdown();
			this.Column_0_cmbActivityList = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.Column_1_cmbActivityList = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.grdActivityDetails = new C1.Win.C1TrueDBGrid.C1TrueDBGrid();
			this.Column_0_grdActivityDetails = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.Column_1_grdActivityDetails = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this._fraProductInformation_4 = new System.Windows.Forms.GroupBox();
			this._chkCommon_3 = new System.Windows.Forms.CheckBox();
			this.cmbMastersList = new C1.Win.C1TrueDBGrid.C1TrueDBDropdown();
			this.Column_0_cmbMastersList = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.Column_1_cmbMastersList = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this._lblCommon_27 = new System.Windows.Forms.Label();
			this.grdAssemblyDetails = new C1.Win.C1TrueDBGrid.C1TrueDBGrid();
			this.Column_0_grdAssemblyDetails = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.Column_1_grdAssemblyDetails = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this._fraProductInformation_0 = new System.Windows.Forms.GroupBox();
			this.txtComment = new System.Windows.Forms.TextBox();
			this._cmdCommon_1 = new System.Windows.Forms.Button();
			this._cmdCommon_2 = new System.Windows.Forms.Button();
			this._cmdCommon_0 = new System.Windows.Forms.Button();
			this._fraProductInformation_5 = new System.Windows.Forms.GroupBox();
			this._txtCommon_9 = new System.Windows.Forms.TextBox();
			this.imgPicture = new System.Windows.Forms.PictureBox();
			this.Image1 = new System.Windows.Forms.PictureBox();
			this._txtCommon_6 = new System.Windows.Forms.TextBox();
			this._txtCommon_5 = new System.Windows.Forms.TextBox();
			this._lblCommon_6 = new System.Windows.Forms.Label();
			this._lblCommon_7 = new System.Windows.Forms.Label();
			this._lblCommon_10 = new System.Windows.Forms.Label();
			this._txtCommonDisplay_1 = new System.Windows.Forms.Label();
			this._txtCommonDisplay_2 = new System.Windows.Forms.Label();
			this._txtCommon_4 = new System.Windows.Forms.TextBox();
			this._lblCommon_5 = new System.Windows.Forms.Label();
			this._txtCommonDisplay_0 = new System.Windows.Forms.Label();
			this._txtCommon_3 = new System.Windows.Forms.TextBox();
			this._lblCommon_50 = new System.Windows.Forms.Label();
			this._txtCommonDisplay_5 = new System.Windows.Forms.Label();
			this._fraProductInformation_1 = new System.Windows.Forms.GroupBox();
			this.grdPriceDetails = new C1.Win.C1TrueDBGrid.C1TrueDBGrid();
			this.Column_0_grdPriceDetails = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.Column_1_grdPriceDetails = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this._chkCommon_2 = new System.Windows.Forms.CheckBox();
			this._fraProductInformation_3 = new System.Windows.Forms.GroupBox();
			this._txtCommonNumber_12 = new System.Windows.Forms.TextBox();
			this._txtCommonNumber_11 = new System.Windows.Forms.TextBox();
			this._txtCommonNumber_10 = new System.Windows.Forms.TextBox();
			this._txtCommonNumber_9 = new System.Windows.Forms.TextBox();
			this._lblCommon_20 = new System.Windows.Forms.Label();
			this._lblCommon_23 = new System.Windows.Forms.Label();
			this._lblCommon_21 = new System.Windows.Forms.Label();
			this._lblCommon_22 = new System.Windows.Forms.Label();
			this._lblCommon_19 = new System.Windows.Forms.Label();
			this._txtCommonNumber_8 = new System.Windows.Forms.TextBox();
			this._fraProductInformation_6 = new System.Windows.Forms.GroupBox();
			this._txtCommonNumber_4 = new System.Windows.Forms.TextBox();
			this._txtCommonNumber_7 = new System.Windows.Forms.TextBox();
			this._txtCommonNumber_6 = new System.Windows.Forms.TextBox();
			this._txtCommonNumber_5 = new System.Windows.Forms.TextBox();
			this._lblCommon_15 = new System.Windows.Forms.Label();
			this._lblCommon_18 = new System.Windows.Forms.Label();
			this._lblCommon_16 = new System.Windows.Forms.Label();
			this._lblCommon_17 = new System.Windows.Forms.Label();
			this._lblCommon_14 = new System.Windows.Forms.Label();
			this._txtCommonNumber_14 = new System.Windows.Forms.TextBox();
			this._lblCommon_12 = new System.Windows.Forms.Label();
			this._txtCommonNumber_1 = new System.Windows.Forms.TextBox();
			this._lblCommon_25 = new System.Windows.Forms.Label();
			this._lblCommon_24 = new System.Windows.Forms.Label();
			this._txtCommonNumber_13 = new System.Windows.Forms.TextBox();
			this._lblCommon_13 = new System.Windows.Forms.Label();
			this._txtCommonNumber_2 = new System.Windows.Forms.TextBox();
			this.cmbPriceList = new C1.Win.C1TrueDBGrid.C1TrueDBDropdown();
			this.Column_0_cmbPriceList = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.Column_1_cmbPriceList = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this._txtCommonNumber_3 = new System.Windows.Forms.TextBox();
			this._fraProductInformation_2 = new System.Windows.Forms.GroupBox();
			this.frmPackageInfo = new System.Windows.Forms.GroupBox();
			this.txtExpDate = new Syncfusion.WinForms.Input.SfDateTimeEdit();
			this.txtPackDate = new Syncfusion.WinForms.Input.SfDateTimeEdit();
			this._lblCommon_26 = new System.Windows.Forms.Label();
			this._lblCommon_33 = new System.Windows.Forms.Label();
			this._lblCommon_34 = new System.Windows.Forms.Label();
			this._txtCommon_10 = new System.Windows.Forms.TextBox();
			this._txtCommon_12 = new System.Windows.Forms.TextBox();
			this._lblCommon_51 = new System.Windows.Forms.Label();
			this._fraProductInformation_8 = new System.Windows.Forms.GroupBox();
			this._lblCommon_32 = new System.Windows.Forms.Label();
			this._txtCommon_8 = new System.Windows.Forms.TextBox();
			this._txtCommon_7 = new System.Windows.Forms.TextBox();
			this._lblCommon_31 = new System.Windows.Forms.Label();
			this._txtCommonDisplay_3 = new System.Windows.Forms.Label();
			this._lblCommon_29 = new System.Windows.Forms.Label();
			this._txtCommonNumber_15 = new System.Windows.Forms.TextBox();
			this._lblCommon_35 = new System.Windows.Forms.Label();
			this._txtCommonNumber_16 = new System.Windows.Forms.TextBox();
			this._fraProductInformation_7 = new System.Windows.Forms.GroupBox();
			this.grdProductLevelDetails = new C1.Win.C1TrueDBGrid.C1TrueDBGrid();
			this.Column_0_grdProductLevelDetails = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.Column_1_grdProductLevelDetails = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this._lblCommon_28 = new System.Windows.Forms.Label();
			this._fraProductInformation_9 = new System.Windows.Forms.GroupBox();
			this._txtFlex_1 = new System.Windows.Forms.TextBox();
			this._lblCommon_36 = new System.Windows.Forms.Label();
			this._txtFlexDisplay_1 = new System.Windows.Forms.Label();
			this._txtFlex_2 = new System.Windows.Forms.TextBox();
			this._lblCommon_38 = new System.Windows.Forms.Label();
			this._txtFlexDisplay_2 = new System.Windows.Forms.Label();
			this._txtFlex_3 = new System.Windows.Forms.TextBox();
			this._lblCommon_39 = new System.Windows.Forms.Label();
			this._txtFlexDisplay_3 = new System.Windows.Forms.Label();
			this._txtFlex_4 = new System.Windows.Forms.TextBox();
			this._lblCommon_40 = new System.Windows.Forms.Label();
			this._txtFlexDisplay_4 = new System.Windows.Forms.Label();
			this._txtFlex_5 = new System.Windows.Forms.TextBox();
			this._lblCommon_41 = new System.Windows.Forms.Label();
			this._txtFlexDisplay_5 = new System.Windows.Forms.Label();
			this._txtFlex_6 = new System.Windows.Forms.TextBox();
			this._lblCommon_42 = new System.Windows.Forms.Label();
			this._txtFlexDisplay_6 = new System.Windows.Forms.Label();
			this._txtFlex_7 = new System.Windows.Forms.TextBox();
			this._lblCommon_43 = new System.Windows.Forms.Label();
			this._txtFlexDisplay_7 = new System.Windows.Forms.Label();
			this._txtFlex_8 = new System.Windows.Forms.TextBox();
			this._lblCommon_44 = new System.Windows.Forms.Label();
			this._txtFlexDisplay_8 = new System.Windows.Forms.Label();
			this._txtFlex_9 = new System.Windows.Forms.TextBox();
			this._lblCommon_45 = new System.Windows.Forms.Label();
			this._txtFlexDisplay_9 = new System.Windows.Forms.Label();
			this._txtFlex_10 = new System.Windows.Forms.TextBox();
			this._lblCommon_46 = new System.Windows.Forms.Label();
			this._txtFlexDisplay_10 = new System.Windows.Forms.Label();
			this._txtFlex_11 = new System.Windows.Forms.TextBox();
			this._lblCommon_47 = new System.Windows.Forms.Label();
			this._txtFlexDisplay_11 = new System.Windows.Forms.Label();
			this._txtFlex_12 = new System.Windows.Forms.TextBox();
			this._lblCommon_48 = new System.Windows.Forms.Label();
			this._txtFlexDisplay_12 = new System.Windows.Forms.Label();
			this._txtFlex_13 = new System.Windows.Forms.TextBox();
			this._lblCommon_49 = new System.Windows.Forms.Label();
			this._txtFlexDisplay_13 = new System.Windows.Forms.Label();
			this._txtFlex_14 = new System.Windows.Forms.TextBox();
			this._lblCommon_37 = new System.Windows.Forms.Label();
			this._txtFlexDisplay_14 = new System.Windows.Forms.Label();
			this._fraProductInformation_10 = new System.Windows.Forms.GroupBox();
			this._lblCommon_30 = new System.Windows.Forms.Label();
			this.grdSupplierDetails = new C1.Win.C1TrueDBGrid.C1TrueDBGrid();
			this.Column_0_grdSupplierDetails = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.Column_1_grdSupplierDetails = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.cmdSupplierList = new C1.Win.C1TrueDBGrid.C1TrueDBDropdown();
			this.Column_0_cmdSupplierList = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.Column_1_cmdSupplierList = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this._fraProductInformation_11 = new System.Windows.Forms.GroupBox();
			this.cmbBarcodeList = new C1.Win.C1TrueDBGrid.C1TrueDBDropdown();
			this.Column_0_cmbBarcodeList = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.Column_1_cmbBarcodeList = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.grdBarcodeDetails = new C1.Win.C1TrueDBGrid.C1TrueDBGrid();
			this.Column_0_grdBarcodeDetails = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.Column_1_grdBarcodeDetails = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this._cmbCommon_0 = new System.Windows.Forms.ComboBox();
			this._lblCommon_8 = new System.Windows.Forms.Label();
			this._cmbCommon_1 = new System.Windows.Forms.ComboBox();
			this._lblCommon_9 = new System.Windows.Forms.Label();
			this._txtCommonNumber_0 = new System.Windows.Forms.TextBox();
			this._lblCommon_11 = new System.Windows.Forms.Label();
			this._txtCommon_2 = new System.Windows.Forms.TextBox();
			this._lblCommon_4 = new System.Windows.Forms.Label();
			this._txtCommon_0 = new System.Windows.Forms.TextBox();
			this._lblCommon_3 = new System.Windows.Forms.Label();
			this._lblCommon_1 = new System.Windows.Forms.Label();
			this._txtCommon_1 = new System.Windows.Forms.TextBox();
			this._lblCommon_2 = new System.Windows.Forms.Label();
			this._lblCommon_0 = new System.Windows.Forms.Label();
			this.CommonDialog1Open = new System.Windows.Forms.OpenFileDialog();
			this.CommonDialog1 = new UpgradeStubs.AxMSComDlg_AxCommonDialog();
			this._txtCommon_11 = new System.Windows.Forms.TextBox();
			// //((System.ComponentModel.ISupportInitialize) this.tabMaster).BeginInit();
			//this.tabMaster.SuspendLayout();
			//this._fraProductInformation_12.SuspendLayout();
			//this.cmbActivityList.SuspendLayout();
			//this.grdActivityDetails.SuspendLayout();
			//this._fraProductInformation_4.SuspendLayout();
			//this.cmbMastersList.SuspendLayout();
			//this.grdAssemblyDetails.SuspendLayout();
			//this._fraProductInformation_0.SuspendLayout();
			//this._fraProductInformation_5.SuspendLayout();
			//this._fraProductInformation_1.SuspendLayout();
			//this.grdPriceDetails.SuspendLayout();
			//this._fraProductInformation_3.SuspendLayout();
			//this._fraProductInformation_6.SuspendLayout();
			//this.cmbPriceList.SuspendLayout();
			//this._fraProductInformation_2.SuspendLayout();
			//this.frmPackageInfo.SuspendLayout();
			//this._fraProductInformation_8.SuspendLayout();
			//this._fraProductInformation_7.SuspendLayout();
			//this.grdProductLevelDetails.SuspendLayout();
			//this._fraProductInformation_9.SuspendLayout();
			//this._fraProductInformation_10.SuspendLayout();
			//this.grdSupplierDetails.SuspendLayout();
			//this.cmdSupplierList.SuspendLayout();
			//this._fraProductInformation_11.SuspendLayout();
			//this.cmbBarcodeList.SuspendLayout();
			//this.grdBarcodeDetails.SuspendLayout();
			this.SuspendLayout();
			// 
			// txtProdDesc
			// 
			this.txtProdDesc.AllowDrop = true;
			this.txtProdDesc.BackColor = System.Drawing.Color.White;
			// // = false;
			this.txtProdDesc.ForeColor = System.Drawing.Color.Black;
			this.txtProdDesc.Location = new System.Drawing.Point(122, 110);
			// // = (System.Windows.Forms.TextBox.FormatBoxDropDownTypes) 0;
			this.txtProdDesc.Name = "txtProdDesc";
			this.txtProdDesc.Size = new System.Drawing.Size(617, 69);
			this.txtProdDesc.TabIndex = 5;
			this.txtProdDesc.Text = "";
			// 
			// _chkCommon_0
			// 
			this._chkCommon_0.AllowDrop = true;
			this._chkCommon_0.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkCommon_0.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._chkCommon_0.CausesValidation = true;
			this._chkCommon_0.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_0.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkCommon_0.Enabled = true;
			this._chkCommon_0.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkCommon_0.Location = new System.Drawing.Point(480, 66);
			this._chkCommon_0.Name = "_chkCommon_0";
			this._chkCommon_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkCommon_0.Size = new System.Drawing.Size(88, 17);
			this._chkCommon_0.TabIndex = 78;
			this._chkCommon_0.TabStop = true;
			this._chkCommon_0.Text = "Seriali&zed";
			this._chkCommon_0.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_0.Visible = false;
			// 
			// _chkCommon_1
			// 
			this._chkCommon_1.AllowDrop = true;
			this._chkCommon_1.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkCommon_1.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._chkCommon_1.CausesValidation = true;
			this._chkCommon_1.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_1.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkCommon_1.Enabled = true;
			this._chkCommon_1.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkCommon_1.Location = new System.Drawing.Point(482, 88);
			this._chkCommon_1.Name = "_chkCommon_1";
			this._chkCommon_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkCommon_1.Size = new System.Drawing.Size(88, 17);
			this._chkCommon_1.TabIndex = 75;
			this._chkCommon_1.TabStop = true;
			this._chkCommon_1.Text = "Discontinued";
			this._chkCommon_1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_1.Visible = true;
			// 
			// tabMaster
			// 
			this.tabMaster.Align = C1SizerLib.AlignSettings.asNone;
			this.tabMaster.AllowDrop = true;
			this.tabMaster.Controls.Add(this._fraProductInformation_12);
			this.tabMaster.Controls.Add(this._fraProductInformation_4);
			this.tabMaster.Controls.Add(this._fraProductInformation_0);
			this.tabMaster.Controls.Add(this._fraProductInformation_1);
			this.tabMaster.Controls.Add(this._fraProductInformation_2);
			this.tabMaster.Controls.Add(this._fraProductInformation_7);
			this.tabMaster.Controls.Add(this._fraProductInformation_9);
			this.tabMaster.Controls.Add(this._fraProductInformation_10);
			this.tabMaster.Controls.Add(this._fraProductInformation_11);
			this.tabMaster.Location = new System.Drawing.Point(4, 192);
			this.tabMaster.Name = "tabMaster";
			//
			this.tabMaster.Size = new System.Drawing.Size(747, 243);
			this.tabMaster.TabIndex = 0;
			this.tabMaster.TabStop = false;
			//// this.tabMaster.ClickEvent += new System.EventHandler(this.tabMaster_ClickEvent);
			// 
			// _fraProductInformation_12
			// 
			this._fraProductInformation_12.AllowDrop = true;
			this._fraProductInformation_12.BackColor = System.Drawing.Color.FromArgb(239, 239, 239);
			this._fraProductInformation_12.Controls.Add(this.cmbActivityList);
			this._fraProductInformation_12.Controls.Add(this.grdActivityDetails);
			this._fraProductInformation_12.Enabled = true;
			this._fraProductInformation_12.ForeColor = System.Drawing.SystemColors.WindowText;
			this._fraProductInformation_12.Location = new System.Drawing.Point(868, 23);
			this._fraProductInformation_12.Name = "_fraProductInformation_12";
			this._fraProductInformation_12.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._fraProductInformation_12.Size = new System.Drawing.Size(745, 219);
			this._fraProductInformation_12.TabIndex = 141;
			this._fraProductInformation_12.Visible = true;
			// 
			// cmbActivityList
			// 
			this.cmbActivityList.AllowDrop = true;
			this.cmbActivityList.ColumnHeaders = true;
			this.cmbActivityList.Enabled = true;
			this.cmbActivityList.Location = new System.Drawing.Point(19, 56);
			this.cmbActivityList.Name = "cmbActivityList";
			this.cmbActivityList.Size = new System.Drawing.Size(267, 105);
			this.cmbActivityList.TabIndex = 79;
			this.cmbActivityList.Columns.Add(this.Column_0_cmbActivityList);
			this.cmbActivityList.Columns.Add(this.Column_1_cmbActivityList);
			// 
			// Column_0_cmbActivityList
			// 
			this.Column_0_cmbActivityList.DataField = "";
			this.Column_0_cmbActivityList.ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.Normal;
			// 
			// Column_1_cmbActivityList
			// 
			this.Column_1_cmbActivityList.DataField = "";
			this.Column_1_cmbActivityList.ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.Normal;
			// 
			// grdActivityDetails
			// 
			this.grdActivityDetails.AllowAddNew = true;
			this.grdActivityDetails.AllowDelete = true;
			this.grdActivityDetails.AllowDrop = true;
			this.grdActivityDetails.BackColor = System.Drawing.Color.Silver;
			this.grdActivityDetails.CellTipsWidth = 0;
			this.grdActivityDetails.Location = new System.Drawing.Point(8, 8);
			this.grdActivityDetails.Name = "grdActivityDetails";
			this.grdActivityDetails.RowDivider.Color = System.Drawing.Color.Silver;
			this.grdActivityDetails.Size = new System.Drawing.Size(731, 189);
			this.grdActivityDetails.TabIndex = 80;
			this.grdActivityDetails.Columns.Add(this.Column_0_grdActivityDetails);
			this.grdActivityDetails.Columns.Add(this.Column_1_grdActivityDetails);
			this.grdActivityDetails.AfterColUpdate += new C1.Win.C1TrueDBGrid.ColEventHandler(this.grdActivityDetails_AfterColUpdate);
			this.grdActivityDetails.GotFocus += new System.EventHandler(this.grdActivityDetails_GotFocus);
			// 
			// Column_0_grdActivityDetails
			// 
			this.Column_0_grdActivityDetails.DataField = "";
			this.Column_0_grdActivityDetails.ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.Normal;
			// 
			// Column_1_grdActivityDetails
			// 
			this.Column_1_grdActivityDetails.DataField = "";
			this.Column_1_grdActivityDetails.ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.Normal;
			// 
			// _fraProductInformation_4
			// 
			this._fraProductInformation_4.AllowDrop = true;
			this._fraProductInformation_4.BackColor = System.Drawing.Color.FromArgb(239, 239, 239);
			this._fraProductInformation_4.Controls.Add(this._chkCommon_3);
			this._fraProductInformation_4.Controls.Add(this.cmbMastersList);
			this._fraProductInformation_4.Controls.Add(this._lblCommon_27);
			this._fraProductInformation_4.Controls.Add(this.grdAssemblyDetails);
			this._fraProductInformation_4.Enabled = true;
			this._fraProductInformation_4.ForeColor = System.Drawing.SystemColors.ControlText;
			this._fraProductInformation_4.Location = new System.Drawing.Point(-806, 23);
			this._fraProductInformation_4.Name = "_fraProductInformation_4";
			this._fraProductInformation_4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._fraProductInformation_4.Size = new System.Drawing.Size(745, 219);
			this._fraProductInformation_4.TabIndex = 131;
			this._fraProductInformation_4.Text = "Frame2";
			this._fraProductInformation_4.Visible = true;
			// 
			// _chkCommon_3
			// 
			this._chkCommon_3.AllowDrop = true;
			this._chkCommon_3.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkCommon_3.BackColor = System.Drawing.Color.FromArgb(239, 239, 239);
			this._chkCommon_3.CausesValidation = true;
			this._chkCommon_3.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_3.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkCommon_3.Enabled = true;
			this._chkCommon_3.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkCommon_3.Location = new System.Drawing.Point(468, 14);
			this._chkCommon_3.Name = "_chkCommon_3";
			this._chkCommon_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkCommon_3.Size = new System.Drawing.Size(161, 13);
			this._chkCommon_3.TabIndex = 72;
			this._chkCommon_3.TabStop = true;
			this._chkCommon_3.Text = "Print Components on Voucher";
			this._chkCommon_3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_3.Visible = true;
			// 
			// cmbMastersList
			// 
			this.cmbMastersList.AllowDrop = true;
			this.cmbMastersList.ColumnHeaders = true;
			this.cmbMastersList.Enabled = true;
			this.cmbMastersList.Location = new System.Drawing.Point(10, 56);
			this.cmbMastersList.Name = "cmbMastersList";
			this.cmbMastersList.Size = new System.Drawing.Size(299, 111);
			this.cmbMastersList.TabIndex = 73;
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
			// _lblCommon_27
			// 
			this._lblCommon_27.AllowDrop = true;
			this._lblCommon_27.BackColor = System.Drawing.Color.FromArgb(239, 239, 239);
			this._lblCommon_27.Text = "Assembly Components :";
			this._lblCommon_27.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_27.Location = new System.Drawing.Point(4, 17);
			// // this._lblCommon_27.mLabelId = 924;
			this._lblCommon_27.Name = "_lblCommon_27";
			this._lblCommon_27.Size = new System.Drawing.Size(117, 14);
			this._lblCommon_27.TabIndex = 132;
			// 
			// grdAssemblyDetails
			// 
			this.grdAssemblyDetails.AllowDrop = true;
			this.grdAssemblyDetails.BackColor = System.Drawing.Color.Silver;
			this.grdAssemblyDetails.CellTipsWidth = 0;
			this.grdAssemblyDetails.Location = new System.Drawing.Point(-1, 34);
			this.grdAssemblyDetails.Name = "grdAssemblyDetails";
			this.grdAssemblyDetails.RowDivider.Color = System.Drawing.Color.Silver;
			this.grdAssemblyDetails.Size = new System.Drawing.Size(743, 166);
			this.grdAssemblyDetails.TabIndex = 74;
			this.grdAssemblyDetails.Columns.Add(this.Column_0_grdAssemblyDetails);
			this.grdAssemblyDetails.Columns.Add(this.Column_1_grdAssemblyDetails);
			this.grdAssemblyDetails.AfterColUpdate += new C1.Win.C1TrueDBGrid.ColEventHandler(this.grdAssemblyDetails_AfterColUpdate);
			this.grdAssemblyDetails.GotFocus += new System.EventHandler(this.grdAssemblyDetails_GotFocus);
			this.grdAssemblyDetails.RowColChange += new C1.Win.C1TrueDBGrid.RowColChangeEventHandler(this.grdAssemblyDetails_RowColChange);
			// 
			// Column_0_grdAssemblyDetails
			// 
			this.Column_0_grdAssemblyDetails.DataField = "";
			this.Column_0_grdAssemblyDetails.ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.Normal;
			// 
			// Column_1_grdAssemblyDetails
			// 
			this.Column_1_grdAssemblyDetails.DataField = "";
			this.Column_1_grdAssemblyDetails.ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.Normal;
			// 
			// _fraProductInformation_0
			// 
			this._fraProductInformation_0.AllowDrop = true;
			this._fraProductInformation_0.BackColor = System.Drawing.Color.FromArgb(239, 239, 239);
			this._fraProductInformation_0.Controls.Add(this.txtComment);
			this._fraProductInformation_0.Controls.Add(this._cmdCommon_1);
			this._fraProductInformation_0.Controls.Add(this._cmdCommon_2);
			this._fraProductInformation_0.Controls.Add(this._cmdCommon_0);
			this._fraProductInformation_0.Controls.Add(this._fraProductInformation_5);
			this._fraProductInformation_0.Controls.Add(this._txtCommon_6);
			this._fraProductInformation_0.Controls.Add(this._txtCommon_5);
			this._fraProductInformation_0.Controls.Add(this._lblCommon_6);
			this._fraProductInformation_0.Controls.Add(this._lblCommon_7);
			this._fraProductInformation_0.Controls.Add(this._lblCommon_10);
			this._fraProductInformation_0.Controls.Add(this._txtCommonDisplay_1);
			this._fraProductInformation_0.Controls.Add(this._txtCommonDisplay_2);
			this._fraProductInformation_0.Controls.Add(this._txtCommon_4);
			this._fraProductInformation_0.Controls.Add(this._lblCommon_5);
			this._fraProductInformation_0.Controls.Add(this._txtCommonDisplay_0);
			this._fraProductInformation_0.Controls.Add(this._txtCommon_3);
			this._fraProductInformation_0.Controls.Add(this._lblCommon_50);
			this._fraProductInformation_0.Controls.Add(this._txtCommonDisplay_5);
			this._fraProductInformation_0.Enabled = true;
			this._fraProductInformation_0.ForeColor = System.Drawing.SystemColors.WindowText;
			this._fraProductInformation_0.Location = new System.Drawing.Point(-826, 23);
			this._fraProductInformation_0.Name = "_fraProductInformation_0";
			this._fraProductInformation_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._fraProductInformation_0.Size = new System.Drawing.Size(745, 219);
			this._fraProductInformation_0.TabIndex = 124;
			this._fraProductInformation_0.Visible = true;
			// 
			// txtComment
			// 
			this.txtComment.AllowDrop = true;
			this.txtComment.BackColor = System.Drawing.Color.White;
			// // = false;
			this.txtComment.ForeColor = System.Drawing.Color.Black;
			this.txtComment.Location = new System.Drawing.Point(94, 102);
			// // = (System.Windows.Forms.TextBox.FormatBoxDropDownTypes) 0;
			this.txtComment.Name = "txtComment";
			this.txtComment.Size = new System.Drawing.Size(364, 75);
			this.txtComment.TabIndex = 12;
			this.txtComment.Text = "";
			// 
			// _cmdCommon_1
			// 
			this._cmdCommon_1.AllowDrop = true;
			this._cmdCommon_1.BackColor = System.Drawing.SystemColors.Control;
			this._cmdCommon_1.ForeColor = System.Drawing.SystemColors.ControlText;
			this._cmdCommon_1.Location = new System.Drawing.Point(400, 10);
			this._cmdCommon_1.Name = "_cmdCommon_1";
			this._cmdCommon_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._cmdCommon_1.Size = new System.Drawing.Size(20, 20);
			this._cmdCommon_1.TabIndex = 7;
			this._cmdCommon_1.TabStop = false;
			this._cmdCommon_1.Text = "...";
			this._cmdCommon_1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this._cmdCommon_1.UseVisualStyleBackColor = false;
			// this._cmdCommon_1.Click += new System.EventHandler(this.cmdCommon_Click);
			// 
			// _cmdCommon_2
			// 
			this._cmdCommon_2.AllowDrop = true;
			this._cmdCommon_2.BackColor = System.Drawing.SystemColors.Control;
			this._cmdCommon_2.ForeColor = System.Drawing.SystemColors.ControlText;
			this._cmdCommon_2.Location = new System.Drawing.Point(400, 31);
			this._cmdCommon_2.Name = "_cmdCommon_2";
			this._cmdCommon_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._cmdCommon_2.Size = new System.Drawing.Size(20, 20);
			this._cmdCommon_2.TabIndex = 9;
			this._cmdCommon_2.TabStop = false;
			this._cmdCommon_2.Text = "...";
			this._cmdCommon_2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this._cmdCommon_2.UseVisualStyleBackColor = false;
			// this._cmdCommon_2.Click += new System.EventHandler(this.cmdCommon_Click);
			// 
			// _cmdCommon_0
			// 
			this._cmdCommon_0.AllowDrop = true;
			this._cmdCommon_0.BackColor = System.Drawing.SystemColors.Control;
			this._cmdCommon_0.ForeColor = System.Drawing.SystemColors.ControlText;
			this._cmdCommon_0.Location = new System.Drawing.Point(400, 52);
			this._cmdCommon_0.Name = "_cmdCommon_0";
			this._cmdCommon_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._cmdCommon_0.Size = new System.Drawing.Size(21, 21);
			this._cmdCommon_0.TabIndex = 13;
			this._cmdCommon_0.TabStop = false;
			this._cmdCommon_0.Text = "&...";
			this._cmdCommon_0.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this._cmdCommon_0.UseVisualStyleBackColor = false;
			this._cmdCommon_0.Visible = false;
			// this._cmdCommon_0.Click += new System.EventHandler(this.cmdCommon_Click);
			// 
			// _fraProductInformation_5
			// 
			this._fraProductInformation_5.AllowDrop = true;
			this._fraProductInformation_5.BackColor = System.Drawing.Color.FromArgb(239, 239, 239);
			this._fraProductInformation_5.Controls.Add(this._txtCommon_9);
			this._fraProductInformation_5.Controls.Add(this.imgPicture);
			this._fraProductInformation_5.Controls.Add(this.Image1);
			this._fraProductInformation_5.Enabled = true;
			this._fraProductInformation_5.ForeColor = System.Drawing.SystemColors.ControlText;
			this._fraProductInformation_5.Location = new System.Drawing.Point(464, 4);
			this._fraProductInformation_5.Name = "_fraProductInformation_5";
			this._fraProductInformation_5.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._fraProductInformation_5.Size = new System.Drawing.Size(275, 213);
			this._fraProductInformation_5.TabIndex = 125;
			this._fraProductInformation_5.Text = " Picture Information ";
			this._fraProductInformation_5.Visible = false;
			// 
			// _txtCommon_9
			// 
			this._txtCommon_9.AllowDrop = true;
			this._txtCommon_9.BackColor = System.Drawing.Color.White;
			this._txtCommon_9.ForeColor = System.Drawing.Color.Black;
			this._txtCommon_9.Location = new System.Drawing.Point(4, 14);
			// // = true;
			this._txtCommon_9.MaxLength = 200;
			this._txtCommon_9.Name = "_txtCommon_9";
			this._txtCommon_9.Size = new System.Drawing.Size(265, 19);
			this._txtCommon_9.TabIndex = 143;
			this._txtCommon_9.Text = "";
			// this.// = "";
			// this.//this._txtCommon_9.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(//this.txtCommon_DropButtonClick);
			// this._txtCommon_9.Leave += new System.EventHandler(this.txtCommon_Leave);
			// 
			// imgPicture
			// 
			this.imgPicture.AllowDrop = true;
			this.imgPicture.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.imgPicture.Enabled = true;
			this.imgPicture.Location = new System.Drawing.Point(4, 34);
			this.imgPicture.Name = "imgPicture";
			this.imgPicture.Size = new System.Drawing.Size(265, 175);
			this.imgPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.imgPicture.Visible = true;
			// this.imgPicture.Click += new System.EventHandler(this.imgPicture_Click);
			// 
			// Image1
			// 
			this.Image1.AllowDrop = true;
			this.Image1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Image1.Enabled = true;
			//this.Image1.Image = (System.Drawing.Image) resources.GetObject("Image1.Image");
			this.Image1.Location = new System.Drawing.Point(6, 36);
			this.Image1.Name = "Image1";
			this.Image1.Size = new System.Drawing.Size(259, 170);
			this.Image1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal;
			this.Image1.Visible = true;
			// 
			// _txtCommon_6
			// 
			this._txtCommon_6.AllowDrop = true;
			this._txtCommon_6.BackColor = System.Drawing.Color.White;
			// this.this._txtCommon_6.bolIsRequired = true;
			// this._txtCommon_6.bolNumericOnly = true;
			this._txtCommon_6.ForeColor = System.Drawing.Color.Black;
			this._txtCommon_6.Location = new System.Drawing.Point(94, 32);
			this._txtCommon_6.MaxLength = 15;
			this._txtCommon_6.Name = "_txtCommon_6";
			// this._txtCommon_6.ShowButton = true;
			this._txtCommon_6.Size = new System.Drawing.Size(101, 19);
			this._txtCommon_6.TabIndex = 8;
			this._txtCommon_6.Text = "";
			this._txtCommon_6.Visible = false;
			// this.// = "Category";
			// this.//this._txtCommon_6.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(//this.txtCommon_DropButtonClick);
			// this._txtCommon_6.Leave += new System.EventHandler(this.txtCommon_Leave);
			// 
			// _txtCommon_5
			// 
			this._txtCommon_5.AllowDrop = true;
			this._txtCommon_5.BackColor = System.Drawing.Color.White;
			// this.this._txtCommon_5.bolIsRequired = true;
			// this._txtCommon_5.bolNumericOnly = true;
			this._txtCommon_5.ForeColor = System.Drawing.Color.Black;
			this._txtCommon_5.Location = new System.Drawing.Point(94, 11);
			this._txtCommon_5.MaxLength = 15;
			this._txtCommon_5.Name = "_txtCommon_5";
			// this._txtCommon_5.ShowButton = true;
			this._txtCommon_5.Size = new System.Drawing.Size(101, 19);
			this._txtCommon_5.TabIndex = 6;
			this._txtCommon_5.Text = "";
			this._txtCommon_5.Visible = false;
			// this.// = "Group";
			// this.//this._txtCommon_5.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(//this.txtCommon_DropButtonClick);
			// this._txtCommon_5.Leave += new System.EventHandler(this.txtCommon_Leave);
			// 
			// _lblCommon_6
			// 
			this._lblCommon_6.AllowDrop = true;
			this._lblCommon_6.BackColor = System.Drawing.Color.FromArgb(239, 239, 239);
			this._lblCommon_6.Text = "Group Code";
			this._lblCommon_6.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_6.Location = new System.Drawing.Point(8, 13);
			// // this._lblCommon_6.mLabelId = 301;
			this._lblCommon_6.Name = "_lblCommon_6";
			this._lblCommon_6.Size = new System.Drawing.Size(58, 14);
			this._lblCommon_6.TabIndex = 126;
			this._lblCommon_6.Visible = false;
			// 
			// _lblCommon_7
			// 
			this._lblCommon_7.AllowDrop = true;
			this._lblCommon_7.BackColor = System.Drawing.Color.FromArgb(239, 239, 239);
			this._lblCommon_7.Text = "Category Code";
			this._lblCommon_7.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_7.Location = new System.Drawing.Point(8, 34);
			// // this._lblCommon_7.mLabelId = 116;
			this._lblCommon_7.Name = "_lblCommon_7";
			this._lblCommon_7.Size = new System.Drawing.Size(72, 14);
			this._lblCommon_7.TabIndex = 127;
			this._lblCommon_7.Visible = false;
			// 
			// _lblCommon_10
			// 
			this._lblCommon_10.AllowDrop = true;
			this._lblCommon_10.BackColor = System.Drawing.Color.FromArgb(239, 239, 239);
			this._lblCommon_10.Text = "Comments";
			this._lblCommon_10.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_10.Location = new System.Drawing.Point(8, 102);
			// // this._lblCommon_10.mLabelId = 135;
			this._lblCommon_10.Name = "_lblCommon_10";
			this._lblCommon_10.Size = new System.Drawing.Size(50, 14);
			this._lblCommon_10.TabIndex = 128;
			// 
			// _txtCommonDisplay_1
			// 
			this._txtCommonDisplay_1.AllowDrop = true;
			this._txtCommonDisplay_1.Location = new System.Drawing.Point(197, 11);
			this._txtCommonDisplay_1.Name = "_txtCommonDisplay_1";
			this._txtCommonDisplay_1.Size = new System.Drawing.Size(201, 19);
			this._txtCommonDisplay_1.TabIndex = 68;
			this._txtCommonDisplay_1.TabStop = false;
			this._txtCommonDisplay_1.Visible = false;
			// 
			// _txtCommonDisplay_2
			// 
			this._txtCommonDisplay_2.AllowDrop = true;
			this._txtCommonDisplay_2.Location = new System.Drawing.Point(197, 32);
			this._txtCommonDisplay_2.Name = "_txtCommonDisplay_2";
			this._txtCommonDisplay_2.Size = new System.Drawing.Size(201, 19);
			this._txtCommonDisplay_2.TabIndex = 69;
			this._txtCommonDisplay_2.TabStop = false;
			this._txtCommonDisplay_2.Visible = false;
			// 
			// _txtCommon_4
			// 
			this._txtCommon_4.AllowDrop = true;
			this._txtCommon_4.BackColor = System.Drawing.Color.White;
			// this.this._txtCommon_4.bolIsRequired = true;
			// this._txtCommon_4.bolNumericOnly = true;
			this._txtCommon_4.ForeColor = System.Drawing.Color.Black;
			this._txtCommon_4.Location = new System.Drawing.Point(94, 54);
			this._txtCommon_4.MaxLength = 15;
			this._txtCommon_4.Name = "_txtCommon_4";
			// this._txtCommon_4.ShowButton = true;
			this._txtCommon_4.Size = new System.Drawing.Size(101, 19);
			this._txtCommon_4.TabIndex = 10;
			this._txtCommon_4.Text = "";
			this._txtCommon_4.Visible = false;
			// this.// = "UOM";
			// this.//this._txtCommon_4.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(//this.txtCommon_DropButtonClick);
			// this._txtCommon_4.Leave += new System.EventHandler(this.txtCommon_Leave);
			// 
			// _lblCommon_5
			// 
			this._lblCommon_5.AllowDrop = true;
			this._lblCommon_5.BackColor = System.Drawing.Color.FromArgb(239, 239, 239);
			this._lblCommon_5.Text = "Base Unit";
			this._lblCommon_5.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_5.Location = new System.Drawing.Point(8, 56);
			// // this._lblCommon_5.mLabelId = 91;
			this._lblCommon_5.Name = "_lblCommon_5";
			this._lblCommon_5.Size = new System.Drawing.Size(46, 14);
			this._lblCommon_5.TabIndex = 129;
			this._lblCommon_5.Visible = false;
			// 
			// _txtCommonDisplay_0
			// 
			this._txtCommonDisplay_0.AllowDrop = true;
			this._txtCommonDisplay_0.Location = new System.Drawing.Point(198, 54);
			this._txtCommonDisplay_0.Name = "_txtCommonDisplay_0";
			this._txtCommonDisplay_0.Size = new System.Drawing.Size(201, 19);
			this._txtCommonDisplay_0.TabIndex = 70;
			this._txtCommonDisplay_0.TabStop = false;
			this._txtCommonDisplay_0.Visible = false;
			// 
			// _txtCommon_3
			// 
			this._txtCommon_3.AllowDrop = true;
			this._txtCommon_3.BackColor = System.Drawing.Color.White;
			// this.this._txtCommon_3.bolIsRequired = true;
			// this._txtCommon_3.bolNumericOnly = true;
			this._txtCommon_3.ForeColor = System.Drawing.Color.Black;
			this._txtCommon_3.Location = new System.Drawing.Point(94, 76);
			this._txtCommon_3.MaxLength = 15;
			this._txtCommon_3.Name = "_txtCommon_3";
			// this._txtCommon_3.ShowButton = true;
			this._txtCommon_3.Size = new System.Drawing.Size(101, 19);
			this._txtCommon_3.TabIndex = 11;
			this._txtCommon_3.Text = "";
			this._txtCommon_3.Visible = false;
			// this.// = "Report UOM";
			// this.//this._txtCommon_3.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(//this.txtCommon_DropButtonClick);
			// this._txtCommon_3.Leave += new System.EventHandler(this.txtCommon_Leave);
			// 
			// _lblCommon_50
			// 
			this._lblCommon_50.AllowDrop = true;
			this._lblCommon_50.BackColor = System.Drawing.Color.FromArgb(239, 239, 239);
			this._lblCommon_50.Text = "Reporting Unit";
			this._lblCommon_50.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_50.Location = new System.Drawing.Point(8, 78);
			// // this._lblCommon_50.mLabelId = 2182;
			this._lblCommon_50.Name = "_lblCommon_50";
			this._lblCommon_50.Size = new System.Drawing.Size(67, 14);
			this._lblCommon_50.TabIndex = 130;
			this._lblCommon_50.Visible = false;
			// 
			// _txtCommonDisplay_5
			// 
			this._txtCommonDisplay_5.AllowDrop = true;
			this._txtCommonDisplay_5.Location = new System.Drawing.Point(198, 76);
			this._txtCommonDisplay_5.Name = "_txtCommonDisplay_5";
			this._txtCommonDisplay_5.Size = new System.Drawing.Size(201, 19);
			this._txtCommonDisplay_5.TabIndex = 71;
			this._txtCommonDisplay_5.TabStop = false;
			this._txtCommonDisplay_5.Visible = false;
			// 
			// _fraProductInformation_1
			// 
			this._fraProductInformation_1.AllowDrop = true;
			this._fraProductInformation_1.BackColor = System.Drawing.Color.FromArgb(239, 239, 239);
			this._fraProductInformation_1.Controls.Add(this.grdPriceDetails);
			this._fraProductInformation_1.Controls.Add(this._chkCommon_2);
			this._fraProductInformation_1.Controls.Add(this._fraProductInformation_3);
			this._fraProductInformation_1.Controls.Add(this._fraProductInformation_6);
			this._fraProductInformation_1.Controls.Add(this._txtCommonNumber_14);
			this._fraProductInformation_1.Controls.Add(this._lblCommon_12);
			this._fraProductInformation_1.Controls.Add(this._txtCommonNumber_1);
			this._fraProductInformation_1.Controls.Add(this._lblCommon_25);
			this._fraProductInformation_1.Controls.Add(this._lblCommon_24);
			this._fraProductInformation_1.Controls.Add(this._txtCommonNumber_13);
			this._fraProductInformation_1.Controls.Add(this._lblCommon_13);
			this._fraProductInformation_1.Controls.Add(this._txtCommonNumber_2);
			this._fraProductInformation_1.Controls.Add(this.cmbPriceList);
			this._fraProductInformation_1.Controls.Add(this._txtCommonNumber_3);
			this._fraProductInformation_1.Enabled = true;
			this._fraProductInformation_1.ForeColor = System.Drawing.SystemColors.WindowText;
			this._fraProductInformation_1.Location = new System.Drawing.Point(-786, 23);
			this._fraProductInformation_1.Name = "_fraProductInformation_1";
			this._fraProductInformation_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._fraProductInformation_1.Size = new System.Drawing.Size(745, 219);
			this._fraProductInformation_1.TabIndex = 107;
			this._fraProductInformation_1.Visible = true;
			// 
			// grdPriceDetails
			// 
			this.grdPriceDetails.AllowAddNew = true;
			this.grdPriceDetails.AllowDelete = true;
			this.grdPriceDetails.AllowDrop = true;
			this.grdPriceDetails.BackColor = System.Drawing.Color.Silver;
			this.grdPriceDetails.CellTipsWidth = 0;
			this.grdPriceDetails.Location = new System.Drawing.Point(6, 36);
			this.grdPriceDetails.Name = "grdPriceDetails";
			this.grdPriceDetails.RowDivider.Color = System.Drawing.Color.Silver;
			this.grdPriceDetails.Size = new System.Drawing.Size(731, 175);
			this.grdPriceDetails.TabIndex = 67;
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
			// _chkCommon_2
			// 
			this._chkCommon_2.AllowDrop = true;
			this._chkCommon_2.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkCommon_2.BackColor = System.Drawing.Color.FromArgb(252, 245, 243);
			this._chkCommon_2.CausesValidation = true;
			this._chkCommon_2.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_2.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkCommon_2.Enabled = true;
			this._chkCommon_2.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkCommon_2.Location = new System.Drawing.Point(51, 168);
			this._chkCommon_2.Name = "_chkCommon_2";
			this._chkCommon_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkCommon_2.Size = new System.Drawing.Size(100, 13);
			this._chkCommon_2.TabIndex = 61;
			this._chkCommon_2.TabStop = true;
			this._chkCommon_2.Text = "Promotional Item";
			this._chkCommon_2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_2.Visible = true;
			// 
			// _fraProductInformation_3
			// 
			this._fraProductInformation_3.AllowDrop = true;
			this._fraProductInformation_3.BackColor = System.Drawing.Color.FromArgb(239, 239, 239);
			this._fraProductInformation_3.Controls.Add(this._txtCommonNumber_12);
			this._fraProductInformation_3.Controls.Add(this._txtCommonNumber_11);
			this._fraProductInformation_3.Controls.Add(this._txtCommonNumber_10);
			this._fraProductInformation_3.Controls.Add(this._txtCommonNumber_9);
			this._fraProductInformation_3.Controls.Add(this._lblCommon_20);
			this._fraProductInformation_3.Controls.Add(this._lblCommon_23);
			this._fraProductInformation_3.Controls.Add(this._lblCommon_21);
			this._fraProductInformation_3.Controls.Add(this._lblCommon_22);
			this._fraProductInformation_3.Controls.Add(this._lblCommon_19);
			this._fraProductInformation_3.Controls.Add(this._txtCommonNumber_8);
			this._fraProductInformation_3.Enabled = true;
			this._fraProductInformation_3.ForeColor = System.Drawing.SystemColors.ControlText;
			this._fraProductInformation_3.Location = new System.Drawing.Point(608, 7);
			this._fraProductInformation_3.Name = "_fraProductInformation_3";
			this._fraProductInformation_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._fraProductInformation_3.Size = new System.Drawing.Size(19, 6);
			this._fraProductInformation_3.TabIndex = 114;
			this._fraProductInformation_3.Text = " Division Wise - Purchase Rates ";
			this._fraProductInformation_3.Visible = false;
			// 
			// _txtCommonNumber_12
			// 
			this._txtCommonNumber_12.AllowDrop = true;
			// this._txtCommonNumber_12.DisplayFormat = "########0.000###;;0.000;0.000";
			// this._txtCommonNumber_12.Format = "###########0.000";
			this._txtCommonNumber_12.Location = new System.Drawing.Point(96, 95);
			// // = 2147483647;
			// // = 0;
			this._txtCommonNumber_12.Name = "_txtCommonNumber_12";
			this._txtCommonNumber_12.Size = new System.Drawing.Size(101, 19);
			this._txtCommonNumber_12.TabIndex = 56;
			this._txtCommonNumber_12.Text = "0.000";
			// 
			// _txtCommonNumber_11
			// 
			this._txtCommonNumber_11.AllowDrop = true;
			// this._txtCommonNumber_11.DisplayFormat = "########0.000###;;0.000;0.000";
			// this._txtCommonNumber_11.Format = "###########0.000";
			this._txtCommonNumber_11.Location = new System.Drawing.Point(96, 78);
			// // = 2147483647;
			// // = 0;
			this._txtCommonNumber_11.Name = "_txtCommonNumber_11";
			this._txtCommonNumber_11.Size = new System.Drawing.Size(101, 19);
			this._txtCommonNumber_11.TabIndex = 57;
			this._txtCommonNumber_11.Text = "0.000";
			// 
			// _txtCommonNumber_10
			// 
			this._txtCommonNumber_10.AllowDrop = true;
			// this._txtCommonNumber_10.DisplayFormat = "########0.000###;;0.000;0.000";
			// this._txtCommonNumber_10.Format = "###########0.000";
			this._txtCommonNumber_10.Location = new System.Drawing.Point(96, 61);
			// // = 2147483647;
			// // = 0;
			this._txtCommonNumber_10.Name = "_txtCommonNumber_10";
			this._txtCommonNumber_10.Size = new System.Drawing.Size(101, 19);
			this._txtCommonNumber_10.TabIndex = 58;
			this._txtCommonNumber_10.Text = "0.000";
			// 
			// _txtCommonNumber_9
			// 
			this._txtCommonNumber_9.AllowDrop = true;
			// this._txtCommonNumber_9.DisplayFormat = "########0.000###;;0.000;0.000";
			// this._txtCommonNumber_9.Format = "###########0.000";
			this._txtCommonNumber_9.Location = new System.Drawing.Point(96, 44);
			// // = 2147483647;
			// // = 0;
			this._txtCommonNumber_9.Name = "_txtCommonNumber_9";
			this._txtCommonNumber_9.Size = new System.Drawing.Size(101, 19);
			this._txtCommonNumber_9.TabIndex = 59;
			this._txtCommonNumber_9.Text = "0.000";
			// 
			// _lblCommon_20
			// 
			this._lblCommon_20.AllowDrop = true;
			this._lblCommon_20.BackColor = System.Drawing.SystemColors.Window;
			this._lblCommon_20.Text = "Level - B";
			this._lblCommon_20.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_20.Location = new System.Drawing.Point(8, 46);
			this._lblCommon_20.Name = "_lblCommon_20";
			this._lblCommon_20.Size = new System.Drawing.Size(43, 14);
			this._lblCommon_20.TabIndex = 115;
			// 
			// _lblCommon_23
			// 
			this._lblCommon_23.AllowDrop = true;
			this._lblCommon_23.BackColor = System.Drawing.SystemColors.Window;
			this._lblCommon_23.Text = "Level - E";
			this._lblCommon_23.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_23.Location = new System.Drawing.Point(8, 97);
			this._lblCommon_23.Name = "_lblCommon_23";
			this._lblCommon_23.Size = new System.Drawing.Size(42, 14);
			this._lblCommon_23.TabIndex = 116;
			// 
			// _lblCommon_21
			// 
			this._lblCommon_21.AllowDrop = true;
			this._lblCommon_21.BackColor = System.Drawing.SystemColors.Window;
			this._lblCommon_21.Text = "Level - C";
			this._lblCommon_21.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_21.Location = new System.Drawing.Point(8, 63);
			this._lblCommon_21.Name = "_lblCommon_21";
			this._lblCommon_21.Size = new System.Drawing.Size(43, 14);
			this._lblCommon_21.TabIndex = 117;
			// 
			// _lblCommon_22
			// 
			this._lblCommon_22.AllowDrop = true;
			this._lblCommon_22.BackColor = System.Drawing.SystemColors.Window;
			this._lblCommon_22.Text = "Level - D";
			this._lblCommon_22.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_22.Location = new System.Drawing.Point(8, 80);
			this._lblCommon_22.Name = "_lblCommon_22";
			this._lblCommon_22.Size = new System.Drawing.Size(43, 14);
			this._lblCommon_22.TabIndex = 118;
			// 
			// _lblCommon_19
			// 
			this._lblCommon_19.AllowDrop = true;
			this._lblCommon_19.BackColor = System.Drawing.SystemColors.Window;
			this._lblCommon_19.Text = "Level - A";
			this._lblCommon_19.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_19.Location = new System.Drawing.Point(8, 29);
			this._lblCommon_19.Name = "_lblCommon_19";
			this._lblCommon_19.Size = new System.Drawing.Size(44, 14);
			this._lblCommon_19.TabIndex = 119;
			// 
			// _txtCommonNumber_8
			// 
			this._txtCommonNumber_8.AllowDrop = true;
			// this._txtCommonNumber_8.DisplayFormat = "########0.000###;;0.000;0.000";
			// this._txtCommonNumber_8.Format = "###########0.000";
			this._txtCommonNumber_8.Location = new System.Drawing.Point(96, 27);
			// // = 2147483647;
			// // = 0;
			this._txtCommonNumber_8.Name = "_txtCommonNumber_8";
			this._txtCommonNumber_8.Size = new System.Drawing.Size(101, 19);
			this._txtCommonNumber_8.TabIndex = 60;
			this._txtCommonNumber_8.Text = "0.000";
			// 
			// _fraProductInformation_6
			// 
			this._fraProductInformation_6.AllowDrop = true;
			this._fraProductInformation_6.BackColor = System.Drawing.Color.FromArgb(239, 239, 239);
			this._fraProductInformation_6.Controls.Add(this._txtCommonNumber_4);
			this._fraProductInformation_6.Controls.Add(this._txtCommonNumber_7);
			this._fraProductInformation_6.Controls.Add(this._txtCommonNumber_6);
			this._fraProductInformation_6.Controls.Add(this._txtCommonNumber_5);
			this._fraProductInformation_6.Controls.Add(this._lblCommon_15);
			this._fraProductInformation_6.Controls.Add(this._lblCommon_18);
			this._fraProductInformation_6.Controls.Add(this._lblCommon_16);
			this._fraProductInformation_6.Controls.Add(this._lblCommon_17);
			this._fraProductInformation_6.Controls.Add(this._lblCommon_14);
			this._fraProductInformation_6.Enabled = true;
			this._fraProductInformation_6.ForeColor = System.Drawing.SystemColors.ControlText;
			this._fraProductInformation_6.Location = new System.Drawing.Point(446, 49);
			this._fraProductInformation_6.Name = "_fraProductInformation_6";
			this._fraProductInformation_6.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._fraProductInformation_6.Size = new System.Drawing.Size(201, 122);
			this._fraProductInformation_6.TabIndex = 108;
			this._fraProductInformation_6.Text = " Division Wise - Sales Rates ";
			this._fraProductInformation_6.Visible = false;
			// 
			// _txtCommonNumber_4
			// 
			this._txtCommonNumber_4.AllowDrop = true;
			// this._txtCommonNumber_4.DisplayFormat = "########0.000###;;0.000;0.000";
			// this._txtCommonNumber_4.Format = "###########0.000";
			this._txtCommonNumber_4.Location = new System.Drawing.Point(94, 44);
			// // = 2147483647;
			// // = 0;
			this._txtCommonNumber_4.Name = "_txtCommonNumber_4";
			this._txtCommonNumber_4.Size = new System.Drawing.Size(101, 19);
			this._txtCommonNumber_4.TabIndex = 52;
			this._txtCommonNumber_4.Text = "0.000";
			// 
			// _txtCommonNumber_7
			// 
			this._txtCommonNumber_7.AllowDrop = true;
			// this._txtCommonNumber_7.DisplayFormat = "########0.000###;;0.000;0.000";
			// this._txtCommonNumber_7.Format = "###########0.000";
			this._txtCommonNumber_7.Location = new System.Drawing.Point(94, 95);
			// // = 2147483647;
			// // = 0;
			this._txtCommonNumber_7.Name = "_txtCommonNumber_7";
			this._txtCommonNumber_7.Size = new System.Drawing.Size(101, 19);
			this._txtCommonNumber_7.TabIndex = 53;
			this._txtCommonNumber_7.Text = "0.000";
			// 
			// _txtCommonNumber_6
			// 
			this._txtCommonNumber_6.AllowDrop = true;
			// this._txtCommonNumber_6.DisplayFormat = "########0.000###;;0.000;0.000";
			// this._txtCommonNumber_6.Format = "###########0.000";
			this._txtCommonNumber_6.Location = new System.Drawing.Point(94, 78);
			// // = 2147483647;
			// // = 0;
			this._txtCommonNumber_6.Name = "_txtCommonNumber_6";
			this._txtCommonNumber_6.Size = new System.Drawing.Size(101, 19);
			this._txtCommonNumber_6.TabIndex = 54;
			this._txtCommonNumber_6.Text = "0.000";
			// 
			// _txtCommonNumber_5
			// 
			this._txtCommonNumber_5.AllowDrop = true;
			// this._txtCommonNumber_5.DisplayFormat = "########0.000###;;0.000;0.000";
			// this._txtCommonNumber_5.Format = "###########0.000";
			this._txtCommonNumber_5.Location = new System.Drawing.Point(94, 61);
			// // = 2147483647;
			// // = 0;
			this._txtCommonNumber_5.Name = "_txtCommonNumber_5";
			this._txtCommonNumber_5.Size = new System.Drawing.Size(101, 19);
			this._txtCommonNumber_5.TabIndex = 55;
			this._txtCommonNumber_5.Text = "0.000";
			// 
			// _lblCommon_15
			// 
			this._lblCommon_15.AllowDrop = true;
			this._lblCommon_15.BackColor = System.Drawing.SystemColors.Window;
			this._lblCommon_15.Text = "Level - B";
			this._lblCommon_15.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_15.Location = new System.Drawing.Point(8, 46);
			this._lblCommon_15.Name = "_lblCommon_15";
			this._lblCommon_15.Size = new System.Drawing.Size(43, 14);
			this._lblCommon_15.TabIndex = 109;
			// 
			// _lblCommon_18
			// 
			this._lblCommon_18.AllowDrop = true;
			this._lblCommon_18.BackColor = System.Drawing.SystemColors.Window;
			this._lblCommon_18.Text = "Level - E";
			this._lblCommon_18.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_18.Location = new System.Drawing.Point(8, 97);
			this._lblCommon_18.Name = "_lblCommon_18";
			this._lblCommon_18.Size = new System.Drawing.Size(42, 14);
			this._lblCommon_18.TabIndex = 110;
			// 
			// _lblCommon_16
			// 
			this._lblCommon_16.AllowDrop = true;
			this._lblCommon_16.BackColor = System.Drawing.SystemColors.Window;
			this._lblCommon_16.Text = "Level - C";
			this._lblCommon_16.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_16.Location = new System.Drawing.Point(8, 63);
			this._lblCommon_16.Name = "_lblCommon_16";
			this._lblCommon_16.Size = new System.Drawing.Size(43, 14);
			this._lblCommon_16.TabIndex = 111;
			// 
			// _lblCommon_17
			// 
			this._lblCommon_17.AllowDrop = true;
			this._lblCommon_17.BackColor = System.Drawing.SystemColors.Window;
			this._lblCommon_17.Text = "Level - D";
			this._lblCommon_17.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_17.Location = new System.Drawing.Point(8, 80);
			this._lblCommon_17.Name = "_lblCommon_17";
			this._lblCommon_17.Size = new System.Drawing.Size(43, 14);
			this._lblCommon_17.TabIndex = 112;
			// 
			// _lblCommon_14
			// 
			this._lblCommon_14.AllowDrop = true;
			this._lblCommon_14.BackColor = System.Drawing.SystemColors.Window;
			this._lblCommon_14.Text = "Level - A";
			this._lblCommon_14.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_14.Location = new System.Drawing.Point(8, 29);
			this._lblCommon_14.Name = "_lblCommon_14";
			this._lblCommon_14.Size = new System.Drawing.Size(44, 14);
			this._lblCommon_14.TabIndex = 113;
			// 
			// _txtCommonNumber_14
			// 
			this._txtCommonNumber_14.AllowDrop = true;
			// this._txtCommonNumber_14.DisplayFormat = "########0.000###;;0.000;0.000";
			// this._txtCommonNumber_14.Format = "###########0.000";
			this._txtCommonNumber_14.Location = new System.Drawing.Point(664, 9);
			// // = 2147483647;
			// // = 0;
			this._txtCommonNumber_14.Name = "_txtCommonNumber_14";
			this._txtCommonNumber_14.Size = new System.Drawing.Size(73, 19);
			this._txtCommonNumber_14.TabIndex = 62;
			this._txtCommonNumber_14.Text = "0.000";
			// 
			// _lblCommon_12
			// 
			this._lblCommon_12.AllowDrop = true;
			this._lblCommon_12.BackColor = System.Drawing.Color.FromArgb(239, 239, 239);
			this._lblCommon_12.Text = "Sales Rate";
			this._lblCommon_12.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_12.Location = new System.Drawing.Point(4, 12);
			// // this._lblCommon_12.mLabelId = 925;
			this._lblCommon_12.Name = "_lblCommon_12";
			this._lblCommon_12.Size = new System.Drawing.Size(52, 14);
			this._lblCommon_12.TabIndex = 120;
			// 
			// _txtCommonNumber_1
			// 
			this._txtCommonNumber_1.AllowDrop = true;
			// this._txtCommonNumber_1.DisplayFormat = "########0.000###;;0.000;0.000";
			// this._txtCommonNumber_1.Format = "###########0.000";
			this._txtCommonNumber_1.Location = new System.Drawing.Point(61, 10);
			// // = 2147483647;
			// // = 0;
			this._txtCommonNumber_1.Name = "_txtCommonNumber_1";
			this._txtCommonNumber_1.Size = new System.Drawing.Size(100, 19);
			this._txtCommonNumber_1.TabIndex = 63;
			this._txtCommonNumber_1.Text = "0.000";
			// 
			// _lblCommon_25
			// 
			this._lblCommon_25.AllowDrop = true;
			this._lblCommon_25.BackColor = System.Drawing.Color.FromArgb(239, 239, 239);
			this._lblCommon_25.Text = "Comm. on Purchase (%)";
			this._lblCommon_25.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_25.Location = new System.Drawing.Point(538, 12);
			// // this._lblCommon_25.mLabelId = 927;
			this._lblCommon_25.Name = "_lblCommon_25";
			this._lblCommon_25.Size = new System.Drawing.Size(117, 13);
			this._lblCommon_25.TabIndex = 121;
			// 
			// _lblCommon_24
			// 
			this._lblCommon_24.AllowDrop = true;
			this._lblCommon_24.BackColor = System.Drawing.Color.FromArgb(239, 239, 239);
			this._lblCommon_24.Text = "Comm. on Sales (%)";
			this._lblCommon_24.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_24.Location = new System.Drawing.Point(351, 13);
			// // this._lblCommon_24.mLabelId = 926;
			this._lblCommon_24.Name = "_lblCommon_24";
			this._lblCommon_24.Size = new System.Drawing.Size(98, 13);
			this._lblCommon_24.TabIndex = 122;
			// 
			// _txtCommonNumber_13
			// 
			this._txtCommonNumber_13.AllowDrop = true;
			// this._txtCommonNumber_13.DisplayFormat = "########0.000###;;0.000;0.000";
			// this._txtCommonNumber_13.Format = "###########0.000";
			this._txtCommonNumber_13.Location = new System.Drawing.Point(456, 36);
			// // = 2147483647;
			// // = 0;
			this._txtCommonNumber_13.Name = "_txtCommonNumber_13";
			this._txtCommonNumber_13.Size = new System.Drawing.Size(73, 19);
			this._txtCommonNumber_13.TabIndex = 64;
			this._txtCommonNumber_13.Text = "0.000";
			// 
			// _lblCommon_13
			// 
			this._lblCommon_13.AllowDrop = true;
			this._lblCommon_13.BackColor = System.Drawing.Color.FromArgb(239, 239, 239);
			this._lblCommon_13.Text = "Purchase Rate";
			this._lblCommon_13.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_13.Location = new System.Drawing.Point(166, 12);
			// // this._lblCommon_13.mLabelId = 581;
			this._lblCommon_13.Name = "_lblCommon_13";
			this._lblCommon_13.Size = new System.Drawing.Size(71, 14);
			this._lblCommon_13.TabIndex = 123;
			// 
			// _txtCommonNumber_2
			// 
			this._txtCommonNumber_2.AllowDrop = true;
			// this._txtCommonNumber_2.DisplayFormat = "########0.000###;;0.000;0.000";
			// this._txtCommonNumber_2.Format = "###########0.000";
			this._txtCommonNumber_2.Location = new System.Drawing.Point(243, 10);
			// // = 2147483647;
			// // = 0;
			this._txtCommonNumber_2.Name = "_txtCommonNumber_2";
			this._txtCommonNumber_2.Size = new System.Drawing.Size(100, 19);
			this._txtCommonNumber_2.TabIndex = 65;
			this._txtCommonNumber_2.Text = "0.000";
			// 
			// cmbPriceList
			// 
			this.cmbPriceList.AllowDrop = true;
			this.cmbPriceList.ColumnHeaders = true;
			this.cmbPriceList.Enabled = true;
			this.cmbPriceList.Location = new System.Drawing.Point(119, 56);
			this.cmbPriceList.Name = "cmbPriceList";
			this.cmbPriceList.Size = new System.Drawing.Size(267, 105);
			this.cmbPriceList.TabIndex = 66;
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
			// _txtCommonNumber_3
			// 
			this._txtCommonNumber_3.AllowDrop = true;
			// this._txtCommonNumber_3.DisplayFormat = "########0.000###;;0.000;0.000";
			// this._txtCommonNumber_3.Format = "###########0.000";
			this._txtCommonNumber_3.Location = new System.Drawing.Point(454, 10);
			// // = 2147483647;
			// // = 0;
			this._txtCommonNumber_3.Name = "_txtCommonNumber_3";
			this._txtCommonNumber_3.Size = new System.Drawing.Size(77, 19);
			this._txtCommonNumber_3.TabIndex = 153;
			this._txtCommonNumber_3.Text = "0.000";
			// 
			// _fraProductInformation_2
			// 
			this._fraProductInformation_2.AllowDrop = true;
			this._fraProductInformation_2.BackColor = System.Drawing.Color.FromArgb(239, 239, 239);
			this._fraProductInformation_2.Controls.Add(this.frmPackageInfo);
			this._fraProductInformation_2.Controls.Add(this._fraProductInformation_8);
			this._fraProductInformation_2.Controls.Add(this._lblCommon_29);
			this._fraProductInformation_2.Controls.Add(this._txtCommonNumber_15);
			this._fraProductInformation_2.Controls.Add(this._lblCommon_35);
			this._fraProductInformation_2.Controls.Add(this._txtCommonNumber_16);
			this._fraProductInformation_2.Enabled = true;
			this._fraProductInformation_2.ForeColor = System.Drawing.SystemColors.ControlText;
			this._fraProductInformation_2.Location = new System.Drawing.Point(1, 23);
			this._fraProductInformation_2.Name = "_fraProductInformation_2";
			this._fraProductInformation_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._fraProductInformation_2.Size = new System.Drawing.Size(745, 219);
			this._fraProductInformation_2.TabIndex = 101;
			this._fraProductInformation_2.Text = "Frame2";
			this._fraProductInformation_2.Visible = true;
			// 
			// frmPackageInfo
			// 
			this.frmPackageInfo.AllowDrop = true;
			this.frmPackageInfo.BackColor = System.Drawing.SystemColors.Control;
			this.frmPackageInfo.Controls.Add(this.txtExpDate);
			this.frmPackageInfo.Controls.Add(this.txtPackDate);
			this.frmPackageInfo.Controls.Add(this._lblCommon_26);
			this.frmPackageInfo.Controls.Add(this._lblCommon_33);
			this.frmPackageInfo.Controls.Add(this._lblCommon_34);
			this.frmPackageInfo.Controls.Add(this._txtCommon_10);
			this.frmPackageInfo.Controls.Add(this._txtCommon_12);
			this.frmPackageInfo.Controls.Add(this._lblCommon_51);
			this.frmPackageInfo.Enabled = true;
			this.frmPackageInfo.ForeColor = System.Drawing.SystemColors.ControlText;
			this.frmPackageInfo.Location = new System.Drawing.Point(12, 12);
			this.frmPackageInfo.Name = "frmPackageInfo";
			this.frmPackageInfo.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.frmPackageInfo.Size = new System.Drawing.Size(341, 109);
			this.frmPackageInfo.TabIndex = 144;
			this.frmPackageInfo.Text = "Package Info";
			this.frmPackageInfo.Visible = true;
			// 
			// txtExpDate
			// 
			this.txtExpDate.AllowDrop = true;
			this.txtExpDate.Location = new System.Drawing.Point(158, 36);
			// this.txtExpDate.MaxDate = 2958465;
			// this.txtExpDate.MinDate = -657434;
			this.txtExpDate.Name = "txtExpDate";
			// = "_";
			this.txtExpDate.Size = new System.Drawing.Size(103, 21);
			this.txtExpDate.TabIndex = 152;
			// this.txtExpDate.Text = "25/Oct/2020";
			// 
			// txtPackDate
			// 
			this.txtPackDate.AllowDrop = true;
			this.txtPackDate.Location = new System.Drawing.Point(158, 58);
			// this.txtPackDate.MaxDate = 2958465;
			// this.txtPackDate.MinDate = -657434;
			this.txtPackDate.Name = "txtPackDate";
			// = "_";
			this.txtPackDate.Size = new System.Drawing.Size(103, 21);
			this.txtPackDate.TabIndex = 151;
			// this.txtPackDate.Text = "25/Oct/2020";
			// 
			// _lblCommon_26
			// 
			this._lblCommon_26.AllowDrop = true;
			this._lblCommon_26.BackColor = System.Drawing.Color.FromArgb(239, 239, 239);
			this._lblCommon_26.Text = "Package";
			this._lblCommon_26.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_26.Location = new System.Drawing.Point(8, 18);
			// // this._lblCommon_26.mLabelId = 2187;
			this._lblCommon_26.Name = "_lblCommon_26";
			this._lblCommon_26.Size = new System.Drawing.Size(41, 14);
			this._lblCommon_26.TabIndex = 145;
			// 
			// _lblCommon_33
			// 
			this._lblCommon_33.AllowDrop = true;
			this._lblCommon_33.BackColor = System.Drawing.Color.FromArgb(239, 239, 239);
			this._lblCommon_33.Text = "Exp. Date";
			this._lblCommon_33.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_33.Location = new System.Drawing.Point(8, 38);
			// // this._lblCommon_33.mLabelId = 2186;
			this._lblCommon_33.Name = "_lblCommon_33";
			this._lblCommon_33.Size = new System.Drawing.Size(46, 14);
			this._lblCommon_33.TabIndex = 146;
			// 
			// _lblCommon_34
			// 
			this._lblCommon_34.AllowDrop = true;
			this._lblCommon_34.BackColor = System.Drawing.Color.FromArgb(239, 239, 239);
			this._lblCommon_34.Text = "Made In";
			this._lblCommon_34.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_34.Location = new System.Drawing.Point(8, 82);
			// // this._lblCommon_34.mLabelId = 2188;
			this._lblCommon_34.Name = "_lblCommon_34";
			this._lblCommon_34.Size = new System.Drawing.Size(37, 14);
			this._lblCommon_34.TabIndex = 147;
			// 
			// _txtCommon_10
			// 
			this._txtCommon_10.AllowDrop = true;
			this._txtCommon_10.BackColor = System.Drawing.Color.White;
			this._txtCommon_10.ForeColor = System.Drawing.Color.Black;
			this._txtCommon_10.Location = new System.Drawing.Point(158, 16);
			this._txtCommon_10.MaxLength = 15;
			this._txtCommon_10.Name = "_txtCommon_10";
			this._txtCommon_10.Size = new System.Drawing.Size(103, 19);
			this._txtCommon_10.TabIndex = 148;
			this._txtCommon_10.Text = "";
			// this.// = "";
			// this.//this._txtCommon_10.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(//this.txtCommon_DropButtonClick);
			// this._txtCommon_10.Leave += new System.EventHandler(this.txtCommon_Leave);
			// 
			// _txtCommon_12
			// 
			this._txtCommon_12.AllowDrop = true;
			this._txtCommon_12.BackColor = System.Drawing.Color.White;
			this._txtCommon_12.ForeColor = System.Drawing.Color.Black;
			this._txtCommon_12.Location = new System.Drawing.Point(158, 80);
			this._txtCommon_12.MaxLength = 15;
			this._txtCommon_12.Name = "_txtCommon_12";
			this._txtCommon_12.Size = new System.Drawing.Size(175, 19);
			this._txtCommon_12.TabIndex = 149;
			this._txtCommon_12.Text = "";
			// this.// = "";
			// this.//this._txtCommon_12.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(//this.txtCommon_DropButtonClick);
			// this._txtCommon_12.Leave += new System.EventHandler(this.txtCommon_Leave);
			// 
			// _lblCommon_51
			// 
			this._lblCommon_51.AllowDrop = true;
			this._lblCommon_51.BackColor = System.Drawing.Color.FromArgb(239, 239, 239);
			this._lblCommon_51.Text = "Packing Date";
			this._lblCommon_51.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_51.Location = new System.Drawing.Point(8, 58);
			// // this._lblCommon_51.mLabelId = 2185;
			this._lblCommon_51.Name = "_lblCommon_51";
			this._lblCommon_51.Size = new System.Drawing.Size(62, 14);
			this._lblCommon_51.TabIndex = 150;
			// 
			// _fraProductInformation_8
			// 
			this._fraProductInformation_8.AllowDrop = true;
			this._fraProductInformation_8.BackColor = System.Drawing.Color.FromArgb(239, 239, 239);
			this._fraProductInformation_8.Controls.Add(this._lblCommon_32);
			this._fraProductInformation_8.Controls.Add(this._txtCommon_8);
			this._fraProductInformation_8.Controls.Add(this._txtCommon_7);
			this._fraProductInformation_8.Controls.Add(this._lblCommon_31);
			this._fraProductInformation_8.Controls.Add(this._txtCommonDisplay_3);
			this._fraProductInformation_8.Enabled = true;
			this._fraProductInformation_8.ForeColor = System.Drawing.SystemColors.ControlText;
			this._fraProductInformation_8.Location = new System.Drawing.Point(373, 12);
			this._fraProductInformation_8.Name = "_fraProductInformation_8";
			this._fraProductInformation_8.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._fraProductInformation_8.Size = new System.Drawing.Size(339, 77);
			this._fraProductInformation_8.TabIndex = 102;
			this._fraProductInformation_8.Text = " Supplier Information ";
			this._fraProductInformation_8.Visible = true;
			// 
			// _lblCommon_32
			// 
			this._lblCommon_32.AllowDrop = true;
			this._lblCommon_32.BackColor = System.Drawing.Color.FromArgb(239, 239, 239);
			this._lblCommon_32.Text = "Supplier Part No";
			this._lblCommon_32.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_32.Location = new System.Drawing.Point(6, 47);
			// // this._lblCommon_32.mLabelId = 765;
			this._lblCommon_32.Name = "_lblCommon_32";
			this._lblCommon_32.Size = new System.Drawing.Size(77, 14);
			this._lblCommon_32.TabIndex = 103;
			// 
			// _txtCommon_8
			// 
			this._txtCommon_8.AllowDrop = true;
			this._txtCommon_8.BackColor = System.Drawing.Color.White;
			this._txtCommon_8.ForeColor = System.Drawing.Color.Black;
			this._txtCommon_8.Location = new System.Drawing.Point(96, 45);
			this._txtCommon_8.MaxLength = 20;
			this._txtCommon_8.Name = "_txtCommon_8";
			this._txtCommon_8.Size = new System.Drawing.Size(235, 19);
			this._txtCommon_8.TabIndex = 47;
			this._txtCommon_8.Text = "";
			// this.// = "";
			// this.//this._txtCommon_8.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(//this.txtCommon_DropButtonClick);
			// this._txtCommon_8.Leave += new System.EventHandler(this.txtCommon_Leave);
			// 
			// _txtCommon_7
			// 
			this._txtCommon_7.AllowDrop = true;
			this._txtCommon_7.BackColor = System.Drawing.Color.White;
			this._txtCommon_7.ForeColor = System.Drawing.Color.Black;
			this._txtCommon_7.Location = new System.Drawing.Point(96, 24);
			this._txtCommon_7.MaxLength = 15;
			this._txtCommon_7.Name = "_txtCommon_7";
			// this._txtCommon_7.ShowButton = true;
			this._txtCommon_7.Size = new System.Drawing.Size(101, 19);
			this._txtCommon_7.TabIndex = 48;
			this._txtCommon_7.Text = "";
			// this.// = "";
			// this.//this._txtCommon_7.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(//this.txtCommon_DropButtonClick);
			// this._txtCommon_7.Leave += new System.EventHandler(this.txtCommon_Leave);
			// 
			// _lblCommon_31
			// 
			this._lblCommon_31.AllowDrop = true;
			this._lblCommon_31.BackColor = System.Drawing.Color.FromArgb(239, 239, 239);
			this._lblCommon_31.Text = "Preferred Supplier";
			this._lblCommon_31.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_31.Location = new System.Drawing.Point(6, 26);
			// // this._lblCommon_31.mLabelId = 928;
			this._lblCommon_31.Name = "_lblCommon_31";
			this._lblCommon_31.Size = new System.Drawing.Size(88, 14);
			this._lblCommon_31.TabIndex = 104;
			// 
			// _txtCommonDisplay_3
			// 
			this._txtCommonDisplay_3.AllowDrop = true;
			this._txtCommonDisplay_3.Location = new System.Drawing.Point(200, 24);
			this._txtCommonDisplay_3.Name = "_txtCommonDisplay_3";
			this._txtCommonDisplay_3.Size = new System.Drawing.Size(127, 19);
			this._txtCommonDisplay_3.TabIndex = 49;
			// 
			// _lblCommon_29
			// 
			this._lblCommon_29.AllowDrop = true;
			this._lblCommon_29.BackColor = System.Drawing.Color.FromArgb(239, 239, 239);
			this._lblCommon_29.Text = "Warranty Period (in days)";
			this._lblCommon_29.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_29.Location = new System.Drawing.Point(21, 157);
			// // this._lblCommon_29.mLabelId = 979;
			this._lblCommon_29.Name = "_lblCommon_29";
			this._lblCommon_29.Size = new System.Drawing.Size(124, 14);
			this._lblCommon_29.TabIndex = 105;
			this._lblCommon_29.Visible = false;
			// 
			// _txtCommonNumber_15
			// 
			this._txtCommonNumber_15.AllowDrop = true;
			// this._txtCommonNumber_15.DisplayFormat = "########0.000###;;0.000;0.000";
			// this._txtCommonNumber_15.Format = "###########0.000";
			this._txtCommonNumber_15.Location = new System.Drawing.Point(171, 155);
			// // = 2147483647;
			// // = 0;
			this._txtCommonNumber_15.Name = "_txtCommonNumber_15";
			this._txtCommonNumber_15.Size = new System.Drawing.Size(100, 19);
			this._txtCommonNumber_15.TabIndex = 50;
			this._txtCommonNumber_15.Text = "0.000";
			this._txtCommonNumber_15.Visible = false;
			// 
			// _lblCommon_35
			// 
			this._lblCommon_35.AllowDrop = true;
			this._lblCommon_35.BackColor = System.Drawing.Color.FromArgb(239, 239, 239);
			this._lblCommon_35.Text = "Weight";
			this._lblCommon_35.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_35.Location = new System.Drawing.Point(20, 133);
			this._lblCommon_35.Name = "_lblCommon_35";
			this._lblCommon_35.Size = new System.Drawing.Size(33, 14);
			this._lblCommon_35.TabIndex = 106;
			// 
			// _txtCommonNumber_16
			// 
			this._txtCommonNumber_16.AllowDrop = true;
			// this._txtCommonNumber_16.DisplayFormat = "########0.000###;;0.000;0.000";
			// this._txtCommonNumber_16.Format = "###########0.000";
			this._txtCommonNumber_16.Location = new System.Drawing.Point(171, 131);
			// // = 2147483647;
			// // = 0;
			this._txtCommonNumber_16.Name = "_txtCommonNumber_16";
			this._txtCommonNumber_16.Size = new System.Drawing.Size(100, 19);
			this._txtCommonNumber_16.TabIndex = 51;
			this._txtCommonNumber_16.Text = "0.000";
			// 
			// _fraProductInformation_7
			// 
			this._fraProductInformation_7.AllowDrop = true;
			this._fraProductInformation_7.BackColor = System.Drawing.Color.FromArgb(239, 239, 239);
			this._fraProductInformation_7.Controls.Add(this.grdProductLevelDetails);
			this._fraProductInformation_7.Controls.Add(this._lblCommon_28);
			this._fraProductInformation_7.Enabled = true;
			this._fraProductInformation_7.ForeColor = System.Drawing.SystemColors.ControlText;
			this._fraProductInformation_7.Location = new System.Drawing.Point(788, 23);
			this._fraProductInformation_7.Name = "_fraProductInformation_7";
			this._fraProductInformation_7.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._fraProductInformation_7.Size = new System.Drawing.Size(745, 219);
			this._fraProductInformation_7.TabIndex = 99;
			this._fraProductInformation_7.Text = "Frame1";
			this._fraProductInformation_7.Visible = true;
			// 
			// grdProductLevelDetails
			// 
			this.grdProductLevelDetails.AllowDrop = true;
			this.grdProductLevelDetails.BackColor = System.Drawing.Color.FromArgb(212, 208, 200);
			this.grdProductLevelDetails.CellTipsWidth = 0;
			this.grdProductLevelDetails.Location = new System.Drawing.Point(-1, 34);
			this.grdProductLevelDetails.Name = "grdProductLevelDetails";
			this.grdProductLevelDetails.RowDivider.Color = System.Drawing.Color.FromArgb(212, 208, 200);
			this.grdProductLevelDetails.Size = new System.Drawing.Size(743, 150);
			this.grdProductLevelDetails.TabIndex = 46;
			this.grdProductLevelDetails.Columns.Add(this.Column_0_grdProductLevelDetails);
			this.grdProductLevelDetails.Columns.Add(this.Column_1_grdProductLevelDetails);
			// this.this.grdProductLevelDetails.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.grdProductLevelDetails_KeyPress);
			this.grdProductLevelDetails.MouseUp += new System.Windows.Forms.MouseEventHandler(this.grdProductLevelDetails_MouseUp);
			// 
			// Column_0_grdProductLevelDetails
			// 
			this.Column_0_grdProductLevelDetails.DataField = "";
			this.Column_0_grdProductLevelDetails.ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.Normal;
			// 
			// Column_1_grdProductLevelDetails
			// 
			this.Column_1_grdProductLevelDetails.DataField = "";
			this.Column_1_grdProductLevelDetails.ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.Normal;
			// 
			// _lblCommon_28
			// 
			this._lblCommon_28.AllowDrop = true;
			this._lblCommon_28.BackColor = System.Drawing.Color.FromArgb(239, 239, 239);
			this._lblCommon_28.Text = " Location wise stock level details : ";
			this._lblCommon_28.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_28.Location = new System.Drawing.Point(4, 17);
			this._lblCommon_28.Name = "_lblCommon_28";
			this._lblCommon_28.Size = new System.Drawing.Size(168, 14);
			this._lblCommon_28.TabIndex = 100;
			// 
			// _fraProductInformation_9
			// 
			this._fraProductInformation_9.AllowDrop = true;
			this._fraProductInformation_9.BackColor = System.Drawing.Color.FromArgb(239, 239, 239);
			this._fraProductInformation_9.Controls.Add(this._txtFlex_1);
			this._fraProductInformation_9.Controls.Add(this._lblCommon_36);
			this._fraProductInformation_9.Controls.Add(this._txtFlexDisplay_1);
			this._fraProductInformation_9.Controls.Add(this._txtFlex_2);
			this._fraProductInformation_9.Controls.Add(this._lblCommon_38);
			this._fraProductInformation_9.Controls.Add(this._txtFlexDisplay_2);
			this._fraProductInformation_9.Controls.Add(this._txtFlex_3);
			this._fraProductInformation_9.Controls.Add(this._lblCommon_39);
			this._fraProductInformation_9.Controls.Add(this._txtFlexDisplay_3);
			this._fraProductInformation_9.Controls.Add(this._txtFlex_4);
			this._fraProductInformation_9.Controls.Add(this._lblCommon_40);
			this._fraProductInformation_9.Controls.Add(this._txtFlexDisplay_4);
			this._fraProductInformation_9.Controls.Add(this._txtFlex_5);
			this._fraProductInformation_9.Controls.Add(this._lblCommon_41);
			this._fraProductInformation_9.Controls.Add(this._txtFlexDisplay_5);
			this._fraProductInformation_9.Controls.Add(this._txtFlex_6);
			this._fraProductInformation_9.Controls.Add(this._lblCommon_42);
			this._fraProductInformation_9.Controls.Add(this._txtFlexDisplay_6);
			this._fraProductInformation_9.Controls.Add(this._txtFlex_7);
			this._fraProductInformation_9.Controls.Add(this._lblCommon_43);
			this._fraProductInformation_9.Controls.Add(this._txtFlexDisplay_7);
			this._fraProductInformation_9.Controls.Add(this._txtFlex_8);
			this._fraProductInformation_9.Controls.Add(this._lblCommon_44);
			this._fraProductInformation_9.Controls.Add(this._txtFlexDisplay_8);
			this._fraProductInformation_9.Controls.Add(this._txtFlex_9);
			this._fraProductInformation_9.Controls.Add(this._lblCommon_45);
			this._fraProductInformation_9.Controls.Add(this._txtFlexDisplay_9);
			this._fraProductInformation_9.Controls.Add(this._txtFlex_10);
			this._fraProductInformation_9.Controls.Add(this._lblCommon_46);
			this._fraProductInformation_9.Controls.Add(this._txtFlexDisplay_10);
			this._fraProductInformation_9.Controls.Add(this._txtFlex_11);
			this._fraProductInformation_9.Controls.Add(this._lblCommon_47);
			this._fraProductInformation_9.Controls.Add(this._txtFlexDisplay_11);
			this._fraProductInformation_9.Controls.Add(this._txtFlex_12);
			this._fraProductInformation_9.Controls.Add(this._lblCommon_48);
			this._fraProductInformation_9.Controls.Add(this._txtFlexDisplay_12);
			this._fraProductInformation_9.Controls.Add(this._txtFlex_13);
			this._fraProductInformation_9.Controls.Add(this._lblCommon_49);
			this._fraProductInformation_9.Controls.Add(this._txtFlexDisplay_13);
			this._fraProductInformation_9.Controls.Add(this._txtFlex_14);
			this._fraProductInformation_9.Controls.Add(this._lblCommon_37);
			this._fraProductInformation_9.Controls.Add(this._txtFlexDisplay_14);
			this._fraProductInformation_9.Enabled = true;
			this._fraProductInformation_9.ForeColor = System.Drawing.SystemColors.ControlText;
			this._fraProductInformation_9.Location = new System.Drawing.Point(808, 23);
			this._fraProductInformation_9.Name = "_fraProductInformation_9";
			this._fraProductInformation_9.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._fraProductInformation_9.Size = new System.Drawing.Size(745, 219);
			this._fraProductInformation_9.TabIndex = 84;
			this._fraProductInformation_9.Text = "Frame1";
			this._fraProductInformation_9.Visible = true;
			// 
			// _txtFlex_1
			// 
			this._txtFlex_1.AllowDrop = true;
			this._txtFlex_1.BackColor = System.Drawing.Color.White;
			// this._txtFlex_1.bolNumericOnly = true;
			this._txtFlex_1.ForeColor = System.Drawing.Color.Black;
			this._txtFlex_1.Location = new System.Drawing.Point(74, 10);
			this._txtFlex_1.MaxLength = 15;
			this._txtFlex_1.Name = "_txtFlex_1";
			// this._txtFlex_1.ShowButton = true;
			this._txtFlex_1.Size = new System.Drawing.Size(75, 19);
			this._txtFlex_1.TabIndex = 18;
			this._txtFlex_1.Text = "";
			// this.// = "";
			// this.//this._txtFlex_1.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(//this.txtFlex_DropButtonClick);
			// this._txtFlex_1.Leave += new System.EventHandler(this.txtFlex_Leave);
			// 
			// _lblCommon_36
			// 
			this._lblCommon_36.AllowDrop = true;
			this._lblCommon_36.BackColor = System.Drawing.Color.FromArgb(239, 239, 239);
			this._lblCommon_36.Text = "Flex1";
			this._lblCommon_36.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_36.Location = new System.Drawing.Point(4, 12);
			// // this._lblCommon_36.mLabelId = 2014;
			this._lblCommon_36.Name = "_lblCommon_36";
			this._lblCommon_36.Size = new System.Drawing.Size(26, 14);
			this._lblCommon_36.TabIndex = 85;
			// 
			// _txtFlexDisplay_1
			// 
			this._txtFlexDisplay_1.AllowDrop = true;
			this._txtFlexDisplay_1.Location = new System.Drawing.Point(149, 10);
			this._txtFlexDisplay_1.Name = "_txtFlexDisplay_1";
			this._txtFlexDisplay_1.Size = new System.Drawing.Size(201, 19);
			this._txtFlexDisplay_1.TabIndex = 19;
			// 
			// _txtFlex_2
			// 
			this._txtFlex_2.AllowDrop = true;
			this._txtFlex_2.BackColor = System.Drawing.Color.White;
			// this._txtFlex_2.bolNumericOnly = true;
			this._txtFlex_2.ForeColor = System.Drawing.Color.Black;
			this._txtFlex_2.Location = new System.Drawing.Point(74, 30);
			this._txtFlex_2.MaxLength = 15;
			this._txtFlex_2.Name = "_txtFlex_2";
			// this._txtFlex_2.ShowButton = true;
			this._txtFlex_2.Size = new System.Drawing.Size(75, 19);
			this._txtFlex_2.TabIndex = 20;
			this._txtFlex_2.Text = "";
			// this.// = "";
			// this.//this._txtFlex_2.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(//this.txtFlex_DropButtonClick);
			// this._txtFlex_2.Leave += new System.EventHandler(this.txtFlex_Leave);
			// 
			// _lblCommon_38
			// 
			this._lblCommon_38.AllowDrop = true;
			this._lblCommon_38.BackColor = System.Drawing.Color.FromArgb(239, 239, 239);
			this._lblCommon_38.Text = "Flex2";
			this._lblCommon_38.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_38.Location = new System.Drawing.Point(4, 32);
			// // this._lblCommon_38.mLabelId = 2015;
			this._lblCommon_38.Name = "_lblCommon_38";
			this._lblCommon_38.Size = new System.Drawing.Size(26, 14);
			this._lblCommon_38.TabIndex = 86;
			// 
			// _txtFlexDisplay_2
			// 
			this._txtFlexDisplay_2.AllowDrop = true;
			this._txtFlexDisplay_2.Location = new System.Drawing.Point(149, 30);
			this._txtFlexDisplay_2.Name = "_txtFlexDisplay_2";
			this._txtFlexDisplay_2.Size = new System.Drawing.Size(201, 19);
			this._txtFlexDisplay_2.TabIndex = 21;
			// 
			// _txtFlex_3
			// 
			this._txtFlex_3.AllowDrop = true;
			this._txtFlex_3.BackColor = System.Drawing.Color.White;
			// this._txtFlex_3.bolNumericOnly = true;
			this._txtFlex_3.ForeColor = System.Drawing.Color.Black;
			this._txtFlex_3.Location = new System.Drawing.Point(74, 50);
			this._txtFlex_3.MaxLength = 15;
			this._txtFlex_3.Name = "_txtFlex_3";
			// this._txtFlex_3.ShowButton = true;
			this._txtFlex_3.Size = new System.Drawing.Size(75, 19);
			this._txtFlex_3.TabIndex = 22;
			this._txtFlex_3.Text = "";
			// this.// = "";
			// this.//this._txtFlex_3.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(//this.txtFlex_DropButtonClick);
			// this._txtFlex_3.Leave += new System.EventHandler(this.txtFlex_Leave);
			// 
			// _lblCommon_39
			// 
			this._lblCommon_39.AllowDrop = true;
			this._lblCommon_39.BackColor = System.Drawing.Color.FromArgb(239, 239, 239);
			this._lblCommon_39.Text = "Flex3";
			this._lblCommon_39.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_39.Location = new System.Drawing.Point(4, 52);
			// // this._lblCommon_39.mLabelId = 2016;
			this._lblCommon_39.Name = "_lblCommon_39";
			this._lblCommon_39.Size = new System.Drawing.Size(26, 14);
			this._lblCommon_39.TabIndex = 87;
			// 
			// _txtFlexDisplay_3
			// 
			this._txtFlexDisplay_3.AllowDrop = true;
			this._txtFlexDisplay_3.Location = new System.Drawing.Point(149, 50);
			this._txtFlexDisplay_3.Name = "_txtFlexDisplay_3";
			this._txtFlexDisplay_3.Size = new System.Drawing.Size(201, 19);
			this._txtFlexDisplay_3.TabIndex = 23;
			// 
			// _txtFlex_4
			// 
			this._txtFlex_4.AllowDrop = true;
			this._txtFlex_4.BackColor = System.Drawing.Color.White;
			// this._txtFlex_4.bolNumericOnly = true;
			this._txtFlex_4.ForeColor = System.Drawing.Color.Black;
			this._txtFlex_4.Location = new System.Drawing.Point(74, 70);
			this._txtFlex_4.MaxLength = 15;
			this._txtFlex_4.Name = "_txtFlex_4";
			// this._txtFlex_4.ShowButton = true;
			this._txtFlex_4.Size = new System.Drawing.Size(75, 19);
			this._txtFlex_4.TabIndex = 24;
			this._txtFlex_4.Text = "";
			// this.// = "";
			// this.//this._txtFlex_4.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(//this.txtFlex_DropButtonClick);
			// this._txtFlex_4.Leave += new System.EventHandler(this.txtFlex_Leave);
			// 
			// _lblCommon_40
			// 
			this._lblCommon_40.AllowDrop = true;
			this._lblCommon_40.BackColor = System.Drawing.Color.FromArgb(239, 239, 239);
			this._lblCommon_40.Text = "Flex4";
			this._lblCommon_40.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_40.Location = new System.Drawing.Point(4, 72);
			// // this._lblCommon_40.mLabelId = 2018;
			this._lblCommon_40.Name = "_lblCommon_40";
			this._lblCommon_40.Size = new System.Drawing.Size(26, 14);
			this._lblCommon_40.TabIndex = 88;
			// 
			// _txtFlexDisplay_4
			// 
			this._txtFlexDisplay_4.AllowDrop = true;
			this._txtFlexDisplay_4.Location = new System.Drawing.Point(149, 70);
			this._txtFlexDisplay_4.Name = "_txtFlexDisplay_4";
			this._txtFlexDisplay_4.Size = new System.Drawing.Size(201, 19);
			this._txtFlexDisplay_4.TabIndex = 25;
			// 
			// _txtFlex_5
			// 
			this._txtFlex_5.AllowDrop = true;
			this._txtFlex_5.BackColor = System.Drawing.Color.White;
			// this._txtFlex_5.bolNumericOnly = true;
			this._txtFlex_5.ForeColor = System.Drawing.Color.Black;
			this._txtFlex_5.Location = new System.Drawing.Point(74, 90);
			this._txtFlex_5.MaxLength = 15;
			this._txtFlex_5.Name = "_txtFlex_5";
			// this._txtFlex_5.ShowButton = true;
			this._txtFlex_5.Size = new System.Drawing.Size(75, 19);
			this._txtFlex_5.TabIndex = 26;
			this._txtFlex_5.Text = "";
			// this.// = "";
			// this.//this._txtFlex_5.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(//this.txtFlex_DropButtonClick);
			// this._txtFlex_5.Leave += new System.EventHandler(this.txtFlex_Leave);
			// 
			// _lblCommon_41
			// 
			this._lblCommon_41.AllowDrop = true;
			this._lblCommon_41.BackColor = System.Drawing.Color.FromArgb(239, 239, 239);
			this._lblCommon_41.Text = "Flex5";
			this._lblCommon_41.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_41.Location = new System.Drawing.Point(4, 92);
			// // this._lblCommon_41.mLabelId = 2019;
			this._lblCommon_41.Name = "_lblCommon_41";
			this._lblCommon_41.Size = new System.Drawing.Size(26, 14);
			this._lblCommon_41.TabIndex = 89;
			// 
			// _txtFlexDisplay_5
			// 
			this._txtFlexDisplay_5.AllowDrop = true;
			this._txtFlexDisplay_5.Location = new System.Drawing.Point(149, 90);
			this._txtFlexDisplay_5.Name = "_txtFlexDisplay_5";
			this._txtFlexDisplay_5.Size = new System.Drawing.Size(201, 19);
			this._txtFlexDisplay_5.TabIndex = 27;
			// 
			// _txtFlex_6
			// 
			this._txtFlex_6.AllowDrop = true;
			this._txtFlex_6.BackColor = System.Drawing.Color.White;
			// this._txtFlex_6.bolNumericOnly = true;
			this._txtFlex_6.ForeColor = System.Drawing.Color.Black;
			this._txtFlex_6.Location = new System.Drawing.Point(74, 110);
			this._txtFlex_6.MaxLength = 15;
			this._txtFlex_6.Name = "_txtFlex_6";
			// this._txtFlex_6.ShowButton = true;
			this._txtFlex_6.Size = new System.Drawing.Size(75, 19);
			this._txtFlex_6.TabIndex = 28;
			this._txtFlex_6.Text = "";
			// this.// = "";
			// this.//this._txtFlex_6.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(//this.txtFlex_DropButtonClick);
			// this._txtFlex_6.Leave += new System.EventHandler(this.txtFlex_Leave);
			// 
			// _lblCommon_42
			// 
			this._lblCommon_42.AllowDrop = true;
			this._lblCommon_42.BackColor = System.Drawing.Color.FromArgb(239, 239, 239);
			this._lblCommon_42.Text = "Flex6";
			this._lblCommon_42.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_42.Location = new System.Drawing.Point(4, 112);
			// // this._lblCommon_42.mLabelId = 2020;
			this._lblCommon_42.Name = "_lblCommon_42";
			this._lblCommon_42.Size = new System.Drawing.Size(26, 14);
			this._lblCommon_42.TabIndex = 90;
			// 
			// _txtFlexDisplay_6
			// 
			this._txtFlexDisplay_6.AllowDrop = true;
			this._txtFlexDisplay_6.Location = new System.Drawing.Point(149, 110);
			this._txtFlexDisplay_6.Name = "_txtFlexDisplay_6";
			this._txtFlexDisplay_6.Size = new System.Drawing.Size(201, 19);
			this._txtFlexDisplay_6.TabIndex = 29;
			// 
			// _txtFlex_7
			// 
			this._txtFlex_7.AllowDrop = true;
			this._txtFlex_7.BackColor = System.Drawing.Color.White;
			// this._txtFlex_7.bolNumericOnly = true;
			this._txtFlex_7.ForeColor = System.Drawing.Color.Black;
			this._txtFlex_7.Location = new System.Drawing.Point(74, 130);
			this._txtFlex_7.MaxLength = 15;
			this._txtFlex_7.Name = "_txtFlex_7";
			// this._txtFlex_7.ShowButton = true;
			this._txtFlex_7.Size = new System.Drawing.Size(75, 19);
			this._txtFlex_7.TabIndex = 30;
			this._txtFlex_7.Text = "";
			// this.// = "";
			// this.//this._txtFlex_7.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(//this.txtFlex_DropButtonClick);
			// this._txtFlex_7.Leave += new System.EventHandler(this.txtFlex_Leave);
			// 
			// _lblCommon_43
			// 
			this._lblCommon_43.AllowDrop = true;
			this._lblCommon_43.BackColor = System.Drawing.Color.FromArgb(239, 239, 239);
			this._lblCommon_43.Text = "Flex7";
			this._lblCommon_43.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_43.Location = new System.Drawing.Point(4, 132);
			// // this._lblCommon_43.mLabelId = 2021;
			this._lblCommon_43.Name = "_lblCommon_43";
			this._lblCommon_43.Size = new System.Drawing.Size(26, 14);
			this._lblCommon_43.TabIndex = 91;
			// 
			// _txtFlexDisplay_7
			// 
			this._txtFlexDisplay_7.AllowDrop = true;
			this._txtFlexDisplay_7.Location = new System.Drawing.Point(149, 130);
			this._txtFlexDisplay_7.Name = "_txtFlexDisplay_7";
			this._txtFlexDisplay_7.Size = new System.Drawing.Size(201, 19);
			this._txtFlexDisplay_7.TabIndex = 31;
			// 
			// _txtFlex_8
			// 
			this._txtFlex_8.AllowDrop = true;
			this._txtFlex_8.BackColor = System.Drawing.Color.White;
			// this._txtFlex_8.bolNumericOnly = true;
			this._txtFlex_8.ForeColor = System.Drawing.Color.Black;
			this._txtFlex_8.Location = new System.Drawing.Point(458, 8);
			this._txtFlex_8.MaxLength = 15;
			this._txtFlex_8.Name = "_txtFlex_8";
			// this._txtFlex_8.ShowButton = true;
			this._txtFlex_8.Size = new System.Drawing.Size(75, 19);
			this._txtFlex_8.TabIndex = 32;
			this._txtFlex_8.Text = "";
			// this.// = "";
			// this.//this._txtFlex_8.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(//this.txtFlex_DropButtonClick);
			// this._txtFlex_8.Leave += new System.EventHandler(this.txtFlex_Leave);
			// 
			// _lblCommon_44
			// 
			this._lblCommon_44.AllowDrop = true;
			this._lblCommon_44.BackColor = System.Drawing.Color.FromArgb(239, 239, 239);
			this._lblCommon_44.Text = "Flex8";
			this._lblCommon_44.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_44.Location = new System.Drawing.Point(368, 10);
			// // this._lblCommon_44.mLabelId = 2022;
			this._lblCommon_44.Name = "_lblCommon_44";
			this._lblCommon_44.Size = new System.Drawing.Size(26, 14);
			this._lblCommon_44.TabIndex = 92;
			// 
			// _txtFlexDisplay_8
			// 
			this._txtFlexDisplay_8.AllowDrop = true;
			this._txtFlexDisplay_8.Location = new System.Drawing.Point(533, 8);
			this._txtFlexDisplay_8.Name = "_txtFlexDisplay_8";
			this._txtFlexDisplay_8.Size = new System.Drawing.Size(201, 19);
			this._txtFlexDisplay_8.TabIndex = 33;
			// 
			// _txtFlex_9
			// 
			this._txtFlex_9.AllowDrop = true;
			this._txtFlex_9.BackColor = System.Drawing.Color.White;
			// this._txtFlex_9.bolNumericOnly = true;
			this._txtFlex_9.ForeColor = System.Drawing.Color.Black;
			this._txtFlex_9.Location = new System.Drawing.Point(458, 28);
			this._txtFlex_9.MaxLength = 15;
			this._txtFlex_9.Name = "_txtFlex_9";
			// this._txtFlex_9.ShowButton = true;
			this._txtFlex_9.Size = new System.Drawing.Size(75, 19);
			this._txtFlex_9.TabIndex = 34;
			this._txtFlex_9.Text = "";
			// this.// = "";
			// this.//this._txtFlex_9.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(//this.txtFlex_DropButtonClick);
			// this._txtFlex_9.Leave += new System.EventHandler(this.txtFlex_Leave);
			// 
			// _lblCommon_45
			// 
			this._lblCommon_45.AllowDrop = true;
			this._lblCommon_45.BackColor = System.Drawing.Color.FromArgb(239, 239, 239);
			this._lblCommon_45.Text = "Flex9";
			this._lblCommon_45.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_45.Location = new System.Drawing.Point(368, 30);
			// // this._lblCommon_45.mLabelId = 2023;
			this._lblCommon_45.Name = "_lblCommon_45";
			this._lblCommon_45.Size = new System.Drawing.Size(26, 14);
			this._lblCommon_45.TabIndex = 93;
			// 
			// _txtFlexDisplay_9
			// 
			this._txtFlexDisplay_9.AllowDrop = true;
			this._txtFlexDisplay_9.Location = new System.Drawing.Point(533, 28);
			this._txtFlexDisplay_9.Name = "_txtFlexDisplay_9";
			this._txtFlexDisplay_9.Size = new System.Drawing.Size(201, 19);
			this._txtFlexDisplay_9.TabIndex = 35;
			// 
			// _txtFlex_10
			// 
			this._txtFlex_10.AllowDrop = true;
			this._txtFlex_10.BackColor = System.Drawing.Color.White;
			// this._txtFlex_10.bolNumericOnly = true;
			this._txtFlex_10.ForeColor = System.Drawing.Color.Black;
			this._txtFlex_10.Location = new System.Drawing.Point(458, 48);
			this._txtFlex_10.MaxLength = 15;
			this._txtFlex_10.Name = "_txtFlex_10";
			// this._txtFlex_10.ShowButton = true;
			this._txtFlex_10.Size = new System.Drawing.Size(75, 19);
			this._txtFlex_10.TabIndex = 36;
			this._txtFlex_10.Text = "";
			// this.// = "";
			// this.//this._txtFlex_10.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(//this.txtFlex_DropButtonClick);
			// this._txtFlex_10.Leave += new System.EventHandler(this.txtFlex_Leave);
			// 
			// _lblCommon_46
			// 
			this._lblCommon_46.AllowDrop = true;
			this._lblCommon_46.BackColor = System.Drawing.Color.FromArgb(239, 239, 239);
			this._lblCommon_46.Text = "Flex10";
			this._lblCommon_46.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_46.Location = new System.Drawing.Point(368, 50);
			// // this._lblCommon_46.mLabelId = 2024;
			this._lblCommon_46.Name = "_lblCommon_46";
			this._lblCommon_46.Size = new System.Drawing.Size(32, 14);
			this._lblCommon_46.TabIndex = 94;
			// 
			// _txtFlexDisplay_10
			// 
			this._txtFlexDisplay_10.AllowDrop = true;
			this._txtFlexDisplay_10.Location = new System.Drawing.Point(533, 48);
			this._txtFlexDisplay_10.Name = "_txtFlexDisplay_10";
			this._txtFlexDisplay_10.Size = new System.Drawing.Size(201, 19);
			this._txtFlexDisplay_10.TabIndex = 37;
			// 
			// _txtFlex_11
			// 
			this._txtFlex_11.AllowDrop = true;
			this._txtFlex_11.BackColor = System.Drawing.Color.White;
			// this._txtFlex_11.bolNumericOnly = true;
			this._txtFlex_11.ForeColor = System.Drawing.Color.Black;
			this._txtFlex_11.Location = new System.Drawing.Point(458, 68);
			this._txtFlex_11.MaxLength = 15;
			this._txtFlex_11.Name = "_txtFlex_11";
			// this._txtFlex_11.ShowButton = true;
			this._txtFlex_11.Size = new System.Drawing.Size(75, 19);
			this._txtFlex_11.TabIndex = 38;
			this._txtFlex_11.Text = "";
			// this.// = "";
			// this.//this._txtFlex_11.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(//this.txtFlex_DropButtonClick);
			// this._txtFlex_11.Leave += new System.EventHandler(this.txtFlex_Leave);
			// 
			// _lblCommon_47
			// 
			this._lblCommon_47.AllowDrop = true;
			this._lblCommon_47.BackColor = System.Drawing.Color.FromArgb(239, 239, 239);
			this._lblCommon_47.Text = "Flex11";
			this._lblCommon_47.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_47.Location = new System.Drawing.Point(368, 70);
			// // this._lblCommon_47.mLabelId = 2025;
			this._lblCommon_47.Name = "_lblCommon_47";
			this._lblCommon_47.Size = new System.Drawing.Size(32, 14);
			this._lblCommon_47.TabIndex = 95;
			// 
			// _txtFlexDisplay_11
			// 
			this._txtFlexDisplay_11.AllowDrop = true;
			this._txtFlexDisplay_11.Location = new System.Drawing.Point(533, 68);
			this._txtFlexDisplay_11.Name = "_txtFlexDisplay_11";
			this._txtFlexDisplay_11.Size = new System.Drawing.Size(201, 19);
			this._txtFlexDisplay_11.TabIndex = 39;
			// 
			// _txtFlex_12
			// 
			this._txtFlex_12.AllowDrop = true;
			this._txtFlex_12.BackColor = System.Drawing.Color.White;
			// this._txtFlex_12.bolNumericOnly = true;
			this._txtFlex_12.ForeColor = System.Drawing.Color.Black;
			this._txtFlex_12.Location = new System.Drawing.Point(458, 88);
			this._txtFlex_12.MaxLength = 15;
			this._txtFlex_12.Name = "_txtFlex_12";
			// this._txtFlex_12.ShowButton = true;
			this._txtFlex_12.Size = new System.Drawing.Size(75, 19);
			this._txtFlex_12.TabIndex = 40;
			this._txtFlex_12.Text = "";
			// this.// = "";
			// this.//this._txtFlex_12.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(//this.txtFlex_DropButtonClick);
			// this._txtFlex_12.Leave += new System.EventHandler(this.txtFlex_Leave);
			// 
			// _lblCommon_48
			// 
			this._lblCommon_48.AllowDrop = true;
			this._lblCommon_48.BackColor = System.Drawing.Color.FromArgb(239, 239, 239);
			this._lblCommon_48.Text = "Flex12";
			this._lblCommon_48.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_48.Location = new System.Drawing.Point(368, 90);
			// // this._lblCommon_48.mLabelId = 2026;
			this._lblCommon_48.Name = "_lblCommon_48";
			this._lblCommon_48.Size = new System.Drawing.Size(32, 14);
			this._lblCommon_48.TabIndex = 96;
			// 
			// _txtFlexDisplay_12
			// 
			this._txtFlexDisplay_12.AllowDrop = true;
			this._txtFlexDisplay_12.Location = new System.Drawing.Point(533, 88);
			this._txtFlexDisplay_12.Name = "_txtFlexDisplay_12";
			this._txtFlexDisplay_12.Size = new System.Drawing.Size(201, 19);
			this._txtFlexDisplay_12.TabIndex = 41;
			// 
			// _txtFlex_13
			// 
			this._txtFlex_13.AllowDrop = true;
			this._txtFlex_13.BackColor = System.Drawing.Color.White;
			// this._txtFlex_13.bolNumericOnly = true;
			this._txtFlex_13.ForeColor = System.Drawing.Color.Black;
			this._txtFlex_13.Location = new System.Drawing.Point(458, 108);
			this._txtFlex_13.MaxLength = 15;
			this._txtFlex_13.Name = "_txtFlex_13";
			// this._txtFlex_13.ShowButton = true;
			this._txtFlex_13.Size = new System.Drawing.Size(75, 19);
			this._txtFlex_13.TabIndex = 42;
			this._txtFlex_13.Text = "";
			// this.// = "";
			// this.//this._txtFlex_13.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(//this.txtFlex_DropButtonClick);
			// this._txtFlex_13.Leave += new System.EventHandler(this.txtFlex_Leave);
			// 
			// _lblCommon_49
			// 
			this._lblCommon_49.AllowDrop = true;
			this._lblCommon_49.BackColor = System.Drawing.Color.FromArgb(239, 239, 239);
			this._lblCommon_49.Text = "Flex13";
			this._lblCommon_49.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_49.Location = new System.Drawing.Point(368, 110);
			// // this._lblCommon_49.mLabelId = 2027;
			this._lblCommon_49.Name = "_lblCommon_49";
			this._lblCommon_49.Size = new System.Drawing.Size(32, 14);
			this._lblCommon_49.TabIndex = 97;
			// 
			// _txtFlexDisplay_13
			// 
			this._txtFlexDisplay_13.AllowDrop = true;
			this._txtFlexDisplay_13.Location = new System.Drawing.Point(533, 108);
			this._txtFlexDisplay_13.Name = "_txtFlexDisplay_13";
			this._txtFlexDisplay_13.Size = new System.Drawing.Size(201, 19);
			this._txtFlexDisplay_13.TabIndex = 43;
			// 
			// _txtFlex_14
			// 
			this._txtFlex_14.AllowDrop = true;
			this._txtFlex_14.BackColor = System.Drawing.Color.White;
			// this._txtFlex_14.bolNumericOnly = true;
			this._txtFlex_14.ForeColor = System.Drawing.Color.Black;
			this._txtFlex_14.Location = new System.Drawing.Point(458, 128);
			this._txtFlex_14.MaxLength = 15;
			this._txtFlex_14.Name = "_txtFlex_14";
			// this._txtFlex_14.ShowButton = true;
			this._txtFlex_14.Size = new System.Drawing.Size(75, 19);
			this._txtFlex_14.TabIndex = 44;
			this._txtFlex_14.Text = "";
			// this.// = "";
			// this.//this._txtFlex_14.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(//this.txtFlex_DropButtonClick);
			// this._txtFlex_14.Leave += new System.EventHandler(this.txtFlex_Leave);
			// 
			// _lblCommon_37
			// 
			this._lblCommon_37.AllowDrop = true;
			this._lblCommon_37.BackColor = System.Drawing.Color.FromArgb(239, 239, 239);
			this._lblCommon_37.Text = "Flex14";
			this._lblCommon_37.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_37.Location = new System.Drawing.Point(368, 130);
			// // this._lblCommon_37.mLabelId = 2028;
			this._lblCommon_37.Name = "_lblCommon_37";
			this._lblCommon_37.Size = new System.Drawing.Size(32, 14);
			this._lblCommon_37.TabIndex = 98;
			// 
			// _txtFlexDisplay_14
			// 
			this._txtFlexDisplay_14.AllowDrop = true;
			this._txtFlexDisplay_14.Location = new System.Drawing.Point(533, 128);
			this._txtFlexDisplay_14.Name = "_txtFlexDisplay_14";
			this._txtFlexDisplay_14.Size = new System.Drawing.Size(201, 19);
			this._txtFlexDisplay_14.TabIndex = 45;
			// 
			// _fraProductInformation_10
			// 
			this._fraProductInformation_10.AllowDrop = true;
			this._fraProductInformation_10.BackColor = System.Drawing.Color.FromArgb(239, 239, 239);
			this._fraProductInformation_10.Controls.Add(this._lblCommon_30);
			this._fraProductInformation_10.Controls.Add(this.grdSupplierDetails);
			this._fraProductInformation_10.Controls.Add(this.cmdSupplierList);
			this._fraProductInformation_10.Enabled = true;
			this._fraProductInformation_10.ForeColor = System.Drawing.SystemColors.ControlText;
			this._fraProductInformation_10.Location = new System.Drawing.Point(828, 23);
			this._fraProductInformation_10.Name = "_fraProductInformation_10";
			this._fraProductInformation_10.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._fraProductInformation_10.Size = new System.Drawing.Size(745, 219);
			this._fraProductInformation_10.TabIndex = 82;
			this._fraProductInformation_10.Text = "Frame1";
			this._fraProductInformation_10.Visible = true;
			// 
			// _lblCommon_30
			// 
			this._lblCommon_30.AllowDrop = true;
			this._lblCommon_30.BackColor = System.Drawing.Color.FromArgb(239, 239, 239);
			this._lblCommon_30.Text = "Supplier Product details : ";
			this._lblCommon_30.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_30.Location = new System.Drawing.Point(4, 17);
			this._lblCommon_30.Name = "_lblCommon_30";
			this._lblCommon_30.Size = new System.Drawing.Size(122, 14);
			this._lblCommon_30.TabIndex = 83;
			// 
			// grdSupplierDetails
			// 
			this.grdSupplierDetails.AllowAddNew = true;
			this.grdSupplierDetails.AllowDelete = true;
			this.grdSupplierDetails.AllowDrop = true;
			this.grdSupplierDetails.BackColor = System.Drawing.Color.FromArgb(212, 208, 200);
			this.grdSupplierDetails.CellTipsWidth = 0;
			this.grdSupplierDetails.Location = new System.Drawing.Point(-1, 34);
			this.grdSupplierDetails.Name = "grdSupplierDetails";
			this.grdSupplierDetails.RowDivider.Color = System.Drawing.Color.FromArgb(212, 208, 200);
			this.grdSupplierDetails.Size = new System.Drawing.Size(743, 166);
			this.grdSupplierDetails.TabIndex = 16;
			this.grdSupplierDetails.Columns.Add(this.Column_0_grdSupplierDetails);
			this.grdSupplierDetails.Columns.Add(this.Column_1_grdSupplierDetails);
			this.grdSupplierDetails.AfterColUpdate += new C1.Win.C1TrueDBGrid.ColEventHandler(this.grdSupplierDetails_AfterColUpdate);
			this.grdSupplierDetails.GotFocus += new System.EventHandler(this.grdSupplierDetails_GotFocus);
			this.grdSupplierDetails.RowColChange += new C1.Win.C1TrueDBGrid.RowColChangeEventHandler(this.grdSupplierDetails_RowColChange);
			// 
			// Column_0_grdSupplierDetails
			// 
			this.Column_0_grdSupplierDetails.DataField = "";
			this.Column_0_grdSupplierDetails.ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.Normal;
			// 
			// Column_1_grdSupplierDetails
			// 
			this.Column_1_grdSupplierDetails.DataField = "";
			this.Column_1_grdSupplierDetails.ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.Normal;
			// 
			// cmdSupplierList
			// 
			this.cmdSupplierList.AllowDrop = true;
			this.cmdSupplierList.ColumnHeaders = true;
			this.cmdSupplierList.Enabled = true;
			this.cmdSupplierList.Location = new System.Drawing.Point(128, 24);
			this.cmdSupplierList.Name = "cmdSupplierList";
			this.cmdSupplierList.Size = new System.Drawing.Size(299, 111);
			this.cmdSupplierList.TabIndex = 17;
			this.cmdSupplierList.Columns.Add(this.Column_0_cmdSupplierList);
			this.cmdSupplierList.Columns.Add(this.Column_1_cmdSupplierList);
			// 
			// Column_0_cmdSupplierList
			// 
			this.Column_0_cmdSupplierList.DataField = "";
			this.Column_0_cmdSupplierList.ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.Normal;
			// 
			// Column_1_cmdSupplierList
			// 
			this.Column_1_cmdSupplierList.DataField = "";
			this.Column_1_cmdSupplierList.ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.Normal;
			// 
			// _fraProductInformation_11
			// 
			this._fraProductInformation_11.AllowDrop = true;
			this._fraProductInformation_11.BackColor = System.Drawing.Color.FromArgb(239, 239, 239);
			this._fraProductInformation_11.Controls.Add(this.cmbBarcodeList);
			this._fraProductInformation_11.Controls.Add(this.grdBarcodeDetails);
			this._fraProductInformation_11.Enabled = true;
			this._fraProductInformation_11.ForeColor = System.Drawing.SystemColors.WindowText;
			this._fraProductInformation_11.Location = new System.Drawing.Point(848, 23);
			this._fraProductInformation_11.Name = "_fraProductInformation_11";
			this._fraProductInformation_11.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._fraProductInformation_11.Size = new System.Drawing.Size(745, 219);
			this._fraProductInformation_11.TabIndex = 81;
			this._fraProductInformation_11.Visible = true;
			// 
			// cmbBarcodeList
			// 
			this.cmbBarcodeList.AllowDrop = true;
			this.cmbBarcodeList.ColumnHeaders = true;
			this.cmbBarcodeList.Enabled = true;
			this.cmbBarcodeList.Location = new System.Drawing.Point(19, 56);
			this.cmbBarcodeList.Name = "cmbBarcodeList";
			this.cmbBarcodeList.Size = new System.Drawing.Size(267, 105);
			this.cmbBarcodeList.TabIndex = 14;
			this.cmbBarcodeList.Columns.Add(this.Column_0_cmbBarcodeList);
			this.cmbBarcodeList.Columns.Add(this.Column_1_cmbBarcodeList);
			// 
			// Column_0_cmbBarcodeList
			// 
			this.Column_0_cmbBarcodeList.DataField = "";
			this.Column_0_cmbBarcodeList.ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.Normal;
			// 
			// Column_1_cmbBarcodeList
			// 
			this.Column_1_cmbBarcodeList.DataField = "";
			this.Column_1_cmbBarcodeList.ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.Normal;
			// 
			// grdBarcodeDetails
			// 
			this.grdBarcodeDetails.AllowAddNew = true;
			this.grdBarcodeDetails.AllowDelete = true;
			this.grdBarcodeDetails.AllowDrop = true;
			this.grdBarcodeDetails.BackColor = System.Drawing.Color.Silver;
			this.grdBarcodeDetails.CellTipsWidth = 0;
			this.grdBarcodeDetails.Location = new System.Drawing.Point(8, 8);
			this.grdBarcodeDetails.Name = "grdBarcodeDetails";
			this.grdBarcodeDetails.RowDivider.Color = System.Drawing.Color.Silver;
			this.grdBarcodeDetails.Size = new System.Drawing.Size(731, 189);
			this.grdBarcodeDetails.TabIndex = 15;
			this.grdBarcodeDetails.Columns.Add(this.Column_0_grdBarcodeDetails);
			this.grdBarcodeDetails.Columns.Add(this.Column_1_grdBarcodeDetails);
			this.grdBarcodeDetails.GotFocus += new System.EventHandler(this.grdBarcodeDetails_GotFocus);
			// 
			// Column_0_grdBarcodeDetails
			// 
			this.Column_0_grdBarcodeDetails.DataField = "";
			this.Column_0_grdBarcodeDetails.ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.Normal;
			// 
			// Column_1_grdBarcodeDetails
			// 
			this.Column_1_grdBarcodeDetails.DataField = "";
			this.Column_1_grdBarcodeDetails.ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.Normal;
			// 
			// _cmbCommon_0
			// 
			this._cmbCommon_0.AllowDrop = true;
			this._cmbCommon_0.Location = new System.Drawing.Point(122, 14);
			this._cmbCommon_0.Name = "_cmbCommon_0";
			this._cmbCommon_0.Size = new System.Drawing.Size(167, 21);
			this._cmbCommon_0.TabIndex = 1;
			this._cmbCommon_0.Visible = false;
			// this._cmbCommon_0.Click += new System.Windows.Forms.ComboBox.ClickHandler(this.cmbCommon_Click);
			// 
			// _lblCommon_8
			// 
			this._lblCommon_8.AllowDrop = true;
			this._lblCommon_8.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_8.Text = "Item Type";
			this._lblCommon_8.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_8.Location = new System.Drawing.Point(6, 18);
			// // this._lblCommon_8.mLabelId = 919;
			this._lblCommon_8.Name = "_lblCommon_8";
			this._lblCommon_8.Size = new System.Drawing.Size(46, 14);
			this._lblCommon_8.TabIndex = 133;
			this._lblCommon_8.Visible = false;
			// 
			// _cmbCommon_1
			// 
			this._cmbCommon_1.AllowDrop = true;
			this._cmbCommon_1.Location = new System.Drawing.Point(380, 14);
			this._cmbCommon_1.Name = "_cmbCommon_1";
			this._cmbCommon_1.Size = new System.Drawing.Size(167, 21);
			this._cmbCommon_1.TabIndex = 76;
			this._cmbCommon_1.Visible = false;
			// this._cmbCommon_1.Click += new System.Windows.Forms.ComboBox.ClickHandler(this.cmbCommon_Click);
			// 
			// _lblCommon_9
			// 
			this._lblCommon_9.AllowDrop = true;
			this._lblCommon_9.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_9.Text = "Costing Method";
			this._lblCommon_9.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_9.Location = new System.Drawing.Point(294, 16);
			// // this._lblCommon_9.mLabelId = 920;
			this._lblCommon_9.Name = "_lblCommon_9";
			this._lblCommon_9.Size = new System.Drawing.Size(74, 14);
			this._lblCommon_9.TabIndex = 134;
			this._lblCommon_9.Visible = false;
			// 
			// _txtCommonNumber_0
			// 
			this._txtCommonNumber_0.AllowDrop = true;
			// this._txtCommonNumber_0.DisplayFormat = "########0.000###;;0.000;0.000";
			// this._txtCommonNumber_0.Format = "###########0.000";
			this._txtCommonNumber_0.Location = new System.Drawing.Point(635, 16);
			// // = 2147483647;
			// // = 0;
			this._txtCommonNumber_0.Name = "_txtCommonNumber_0";
			this._txtCommonNumber_0.Size = new System.Drawing.Size(101, 19);
			this._txtCommonNumber_0.TabIndex = 77;
			this._txtCommonNumber_0.Text = "0.000";
			this._txtCommonNumber_0.Visible = false;
			// 
			// _lblCommon_11
			// 
			this._lblCommon_11.AllowDrop = true;
			this._lblCommon_11.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_11.Text = "Cost";
			this._lblCommon_11.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_11.Location = new System.Drawing.Point(594, 18);
			// // this._lblCommon_11.mLabelId = 147;
			this._lblCommon_11.Name = "_lblCommon_11";
			this._lblCommon_11.Size = new System.Drawing.Size(22, 14);
			this._lblCommon_11.TabIndex = 135;
			this._lblCommon_11.Visible = false;
			// 
			// _txtCommon_2
			// 
			this._txtCommon_2.AllowDrop = true;
			this._txtCommon_2.BackColor = System.Drawing.Color.White;
			this._txtCommon_2.ForeColor = System.Drawing.Color.Black;
			this._txtCommon_2.Location = new System.Drawing.Point(122, 87);
			// // = true;
			this._txtCommon_2.MaxLength = 200;
			this._txtCommon_2.Name = "_txtCommon_2";
			this._txtCommon_2.Size = new System.Drawing.Size(351, 19);
			this._txtCommon_2.TabIndex = 4;
			this._txtCommon_2.Text = "";
			// this.// = "";
			// this.//this._txtCommon_2.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(//this.txtCommon_DropButtonClick);
			// this._txtCommon_2.Leave += new System.EventHandler(this.txtCommon_Leave);
			// 
			// _lblCommon_4
			// 
			this._lblCommon_4.AllowDrop = true;
			this._lblCommon_4.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_4.Text = "(Total No of Transactions : 0) ";
			this._lblCommon_4.ForeColor = System.Drawing.Color.FromArgb(126, 126, 126);
			this._lblCommon_4.Location = new System.Drawing.Point(590, 60);
			this._lblCommon_4.Name = "_lblCommon_4";
			this._lblCommon_4.Size = new System.Drawing.Size(144, 14);
			this._lblCommon_4.TabIndex = 136;
			this._lblCommon_4.Visible = false;
			// 
			// _txtCommon_0
			// 
			this._txtCommon_0.AllowDrop = true;
			this._txtCommon_0.BackColor = System.Drawing.Color.White;
			// this.this._txtCommon_0.bolIsRequired = true;
			this._txtCommon_0.ForeColor = System.Drawing.Color.Black;
			this._txtCommon_0.Location = new System.Drawing.Point(122, 42);
			this._txtCommon_0.MaxLength = 20;
			// // = System.Windows.Forms.TextBox.DropDownTypes.ddtNextNumber;
			this._txtCommon_0.Name = "_txtCommon_0";
			this._txtCommon_0.Size = new System.Drawing.Size(133, 19);
			this._txtCommon_0.TabIndex = 2;
			this._txtCommon_0.Text = "";
			// this.// = "Item Code";
			// this.//this._txtCommon_0.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(//this.txtCommon_DropButtonClick);
			// this._txtCommon_0.Leave += new System.EventHandler(this.txtCommon_Leave);
			// 
			// _lblCommon_3
			// 
			this._lblCommon_3.AllowDrop = true;
			this._lblCommon_3.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_3.Text = "Description";
			this._lblCommon_3.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_3.Location = new System.Drawing.Point(6, 113);
			// // this._lblCommon_3.mLabelId = 216;
			this._lblCommon_3.Name = "_lblCommon_3";
			this._lblCommon_3.Size = new System.Drawing.Size(54, 14);
			this._lblCommon_3.TabIndex = 137;
			// 
			// _lblCommon_1
			// 
			this._lblCommon_1.AllowDrop = true;
			this._lblCommon_1.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_1.Text = "Item Name (English)";
			this._lblCommon_1.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_1.Location = new System.Drawing.Point(6, 66);
			// // this._lblCommon_1.mLabelId = 921;
			this._lblCommon_1.Name = "_lblCommon_1";
			this._lblCommon_1.Size = new System.Drawing.Size(94, 14);
			this._lblCommon_1.TabIndex = 138;
			// 
			// _txtCommon_1
			// 
			this._txtCommon_1.AllowDrop = true;
			this._txtCommon_1.BackColor = System.Drawing.Color.White;
			// this.this._txtCommon_1.bolIsRequired = true;
			this._txtCommon_1.ForeColor = System.Drawing.Color.Black;
			this._txtCommon_1.Location = new System.Drawing.Point(122, 64);
			this._txtCommon_1.MaxLength = 200;
			this._txtCommon_1.Name = "_txtCommon_1";
			this._txtCommon_1.Size = new System.Drawing.Size(351, 19);
			this._txtCommon_1.TabIndex = 3;
			this._txtCommon_1.Text = "";
			// this.// = "Item Name";
			// this.//this._txtCommon_1.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(//this.txtCommon_DropButtonClick);
			// this._txtCommon_1.Leave += new System.EventHandler(this.txtCommon_Leave);
			// 
			// _lblCommon_2
			// 
			this._lblCommon_2.AllowDrop = true;
			this._lblCommon_2.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_2.Text = "Item Name (Arabic)";
			this._lblCommon_2.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_2.Location = new System.Drawing.Point(6, 89);
			// // this._lblCommon_2.mLabelId = 551;
			this._lblCommon_2.Name = "_lblCommon_2";
			this._lblCommon_2.Size = new System.Drawing.Size(92, 14);
			this._lblCommon_2.TabIndex = 139;
			// 
			// _lblCommon_0
			// 
			this._lblCommon_0.AllowDrop = true;
			this._lblCommon_0.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_0.Text = "Item Code";
			this._lblCommon_0.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_0.Location = new System.Drawing.Point(6, 44);
			// // this._lblCommon_0.mLabelId = 545;
			this._lblCommon_0.Name = "_lblCommon_0";
			this._lblCommon_0.Size = new System.Drawing.Size(47, 14);
			this._lblCommon_0.TabIndex = 140;
			// 
			// _txtCommon_11
			// 
			this._txtCommon_11.AllowDrop = true;
			this._txtCommon_11.BackColor = System.Drawing.Color.FromArgb(239, 239, 239);
			this._txtCommon_11.Enabled = false;
			this._txtCommon_11.ForeColor = System.Drawing.Color.Black;
			this._txtCommon_11.Location = new System.Drawing.Point(6, 398);
			this._txtCommon_11.MaxLength = 200;
			this._txtCommon_11.Name = "_txtCommon_11";
			this._txtCommon_11.Size = new System.Drawing.Size(99, 21);
			this._txtCommon_11.TabIndex = 142;
			this._txtCommon_11.Text = "";
			// this.// = "";
			// this.//this._txtCommon_11.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(//this.txtCommon_DropButtonClick);
			// this._txtCommon_11.Leave += new System.EventHandler(this.txtCommon_Leave);
			// 
			// frmICSItems
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.ClientSize = new System.Drawing.Size(1075, 485);
			this.Controls.Add(this.txtProdDesc);
			this.Controls.Add(this._chkCommon_0);
			this.Controls.Add(this._chkCommon_1);
			this.Controls.Add(this.tabMaster);
			this.Controls.Add(this._cmbCommon_0);
			this.Controls.Add(this._lblCommon_8);
			this.Controls.Add(this._cmbCommon_1);
			this.Controls.Add(this._lblCommon_9);
			this.Controls.Add(this._txtCommonNumber_0);
			this.Controls.Add(this._lblCommon_11);
			this.Controls.Add(this._txtCommon_2);
			this.Controls.Add(this._lblCommon_4);
			this.Controls.Add(this._txtCommon_0);
			this.Controls.Add(this._lblCommon_3);
			this.Controls.Add(this._lblCommon_1);
			this.Controls.Add(this._txtCommon_1);
			this.Controls.Add(this._lblCommon_2);
			this.Controls.Add(this._lblCommon_0);
			this.Controls.Add(this._txtCommon_11);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			//this.Icon = (System.Drawing.Icon) resources.GetObject("frmICSItems.Icon");
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(168, 203);
			this.MaximizeBox = true;
			this.MinimizeBox = true;
			this.Name = "frmICSItems";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Item Master";
			// this.Activated += new System.EventHandler(this.Form_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
			// this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
			//((System.ComponentModel.ISupportInitialize) this.tabMaster).EndInit();
			this.tabMaster.ResumeLayout(false);
			this._fraProductInformation_12.ResumeLayout(false);
			this.cmbActivityList.ResumeLayout(false);
			this.grdActivityDetails.ResumeLayout(false);
			this._fraProductInformation_4.ResumeLayout(false);
			this.cmbMastersList.ResumeLayout(false);
			this.grdAssemblyDetails.ResumeLayout(false);
			this._fraProductInformation_0.ResumeLayout(false);
			this._fraProductInformation_5.ResumeLayout(false);
			this._fraProductInformation_1.ResumeLayout(false);
			this.grdPriceDetails.ResumeLayout(false);
			this._fraProductInformation_3.ResumeLayout(false);
			this._fraProductInformation_6.ResumeLayout(false);
			this.cmbPriceList.ResumeLayout(false);
			this._fraProductInformation_2.ResumeLayout(false);
			this.frmPackageInfo.ResumeLayout(false);
			this._fraProductInformation_8.ResumeLayout(false);
			this._fraProductInformation_7.ResumeLayout(false);
			this.grdProductLevelDetails.ResumeLayout(false);
			this._fraProductInformation_9.ResumeLayout(false);
			this._fraProductInformation_10.ResumeLayout(false);
			this.grdSupplierDetails.ResumeLayout(false);
			this.cmdSupplierList.ResumeLayout(false);
			this._fraProductInformation_11.ResumeLayout(false);
			this.cmbBarcodeList.ResumeLayout(false);
			this.grdBarcodeDetails.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		// 
		void InitializetxtFlexDisplay()
		{
			this.txtFlexDisplay = new System.Windows.Forms.Label[15];
			this.txtFlexDisplay[1] = _txtFlexDisplay_1;
			this.txtFlexDisplay[2] = _txtFlexDisplay_2;
			this.txtFlexDisplay[3] = _txtFlexDisplay_3;
			this.txtFlexDisplay[4] = _txtFlexDisplay_4;
			this.txtFlexDisplay[5] = _txtFlexDisplay_5;
			this.txtFlexDisplay[6] = _txtFlexDisplay_6;
			this.txtFlexDisplay[7] = _txtFlexDisplay_7;
			this.txtFlexDisplay[8] = _txtFlexDisplay_8;
			this.txtFlexDisplay[9] = _txtFlexDisplay_9;
			this.txtFlexDisplay[10] = _txtFlexDisplay_10;
			this.txtFlexDisplay[11] = _txtFlexDisplay_11;
			this.txtFlexDisplay[12] = _txtFlexDisplay_12;
			this.txtFlexDisplay[13] = _txtFlexDisplay_13;
			this.txtFlexDisplay[14] = _txtFlexDisplay_14;
		}
		void InitializetxtFlex()
		{
			this.txtFlex = new System.Windows.Forms.TextBox[15];
			this.txtFlex[1] = _txtFlex_1;
			this.txtFlex[2] = _txtFlex_2;
			this.txtFlex[3] = _txtFlex_3;
			this.txtFlex[4] = _txtFlex_4;
			this.txtFlex[5] = _txtFlex_5;
			this.txtFlex[6] = _txtFlex_6;
			this.txtFlex[7] = _txtFlex_7;
			this.txtFlex[8] = _txtFlex_8;
			this.txtFlex[9] = _txtFlex_9;
			this.txtFlex[10] = _txtFlex_10;
			this.txtFlex[11] = _txtFlex_11;
			this.txtFlex[12] = _txtFlex_12;
			this.txtFlex[13] = _txtFlex_13;
			this.txtFlex[14] = _txtFlex_14;
		}
		void InitializetxtCommonNumber()
		{
			this.txtCommonNumber = new System.Windows.Forms.TextBox[17];
			this.txtCommonNumber[12] = _txtCommonNumber_12;
			this.txtCommonNumber[11] = _txtCommonNumber_11;
			this.txtCommonNumber[10] = _txtCommonNumber_10;
			this.txtCommonNumber[9] = _txtCommonNumber_9;
			this.txtCommonNumber[8] = _txtCommonNumber_8;
			this.txtCommonNumber[4] = _txtCommonNumber_4;
			this.txtCommonNumber[7] = _txtCommonNumber_7;
			this.txtCommonNumber[6] = _txtCommonNumber_6;
			this.txtCommonNumber[5] = _txtCommonNumber_5;
			this.txtCommonNumber[14] = _txtCommonNumber_14;
			this.txtCommonNumber[1] = _txtCommonNumber_1;
			this.txtCommonNumber[13] = _txtCommonNumber_13;
			this.txtCommonNumber[2] = _txtCommonNumber_2;
			this.txtCommonNumber[3] = _txtCommonNumber_3;
			this.txtCommonNumber[15] = _txtCommonNumber_15;
			this.txtCommonNumber[16] = _txtCommonNumber_16;
			this.txtCommonNumber[0] = _txtCommonNumber_0;
		}
		void InitializetxtCommonDisplay()
		{
			this.txtCommonDisplay = new System.Windows.Forms.Label[6];
			this.txtCommonDisplay[1] = _txtCommonDisplay_1;
			this.txtCommonDisplay[2] = _txtCommonDisplay_2;
			this.txtCommonDisplay[0] = _txtCommonDisplay_0;
			this.txtCommonDisplay[5] = _txtCommonDisplay_5;
			this.txtCommonDisplay[3] = _txtCommonDisplay_3;
		}
		void InitializetxtCommon()
		{
			this.txtCommon = new System.Windows.Forms.TextBox[13];
			this.txtCommon[9] = _txtCommon_9;
			this.txtCommon[6] = _txtCommon_6;
			this.txtCommon[5] = _txtCommon_5;
			this.txtCommon[4] = _txtCommon_4;
			this.txtCommon[3] = _txtCommon_3;
			this.txtCommon[10] = _txtCommon_10;
			this.txtCommon[12] = _txtCommon_12;
			this.txtCommon[8] = _txtCommon_8;
			this.txtCommon[7] = _txtCommon_7;
			this.txtCommon[2] = _txtCommon_2;
			this.txtCommon[0] = _txtCommon_0;
			this.txtCommon[1] = _txtCommon_1;
			this.txtCommon[11] = _txtCommon_11;
		}
		void InitializelblCommon()
		{
			this.lblCommon = new System.Windows.Forms.Label[52];
			this.lblCommon[27] = _lblCommon_27;
			this.lblCommon[6] = _lblCommon_6;
			this.lblCommon[7] = _lblCommon_7;
			this.lblCommon[10] = _lblCommon_10;
			this.lblCommon[5] = _lblCommon_5;
			this.lblCommon[50] = _lblCommon_50;
			this.lblCommon[20] = _lblCommon_20;
			this.lblCommon[23] = _lblCommon_23;
			this.lblCommon[21] = _lblCommon_21;
			this.lblCommon[22] = _lblCommon_22;
			this.lblCommon[19] = _lblCommon_19;
			this.lblCommon[15] = _lblCommon_15;
			this.lblCommon[18] = _lblCommon_18;
			this.lblCommon[16] = _lblCommon_16;
			this.lblCommon[17] = _lblCommon_17;
			this.lblCommon[14] = _lblCommon_14;
			this.lblCommon[12] = _lblCommon_12;
			this.lblCommon[25] = _lblCommon_25;
			this.lblCommon[24] = _lblCommon_24;
			this.lblCommon[13] = _lblCommon_13;
			this.lblCommon[26] = _lblCommon_26;
			this.lblCommon[33] = _lblCommon_33;
			this.lblCommon[34] = _lblCommon_34;
			this.lblCommon[51] = _lblCommon_51;
			this.lblCommon[32] = _lblCommon_32;
			this.lblCommon[31] = _lblCommon_31;
			this.lblCommon[29] = _lblCommon_29;
			this.lblCommon[35] = _lblCommon_35;
			this.lblCommon[28] = _lblCommon_28;
			this.lblCommon[36] = _lblCommon_36;
			this.lblCommon[38] = _lblCommon_38;
			this.lblCommon[39] = _lblCommon_39;
			this.lblCommon[40] = _lblCommon_40;
			this.lblCommon[41] = _lblCommon_41;
			this.lblCommon[42] = _lblCommon_42;
			this.lblCommon[43] = _lblCommon_43;
			this.lblCommon[44] = _lblCommon_44;
			this.lblCommon[45] = _lblCommon_45;
			this.lblCommon[46] = _lblCommon_46;
			this.lblCommon[47] = _lblCommon_47;
			this.lblCommon[48] = _lblCommon_48;
			this.lblCommon[49] = _lblCommon_49;
			this.lblCommon[37] = _lblCommon_37;
			this.lblCommon[30] = _lblCommon_30;
			this.lblCommon[8] = _lblCommon_8;
			this.lblCommon[9] = _lblCommon_9;
			this.lblCommon[11] = _lblCommon_11;
			this.lblCommon[4] = _lblCommon_4;
			this.lblCommon[3] = _lblCommon_3;
			this.lblCommon[1] = _lblCommon_1;
			this.lblCommon[2] = _lblCommon_2;
			this.lblCommon[0] = _lblCommon_0;
		}
		void InitializefraProductInformation()
		{
			this.fraProductInformation = new System.Windows.Forms.GroupBox[13];
			this.fraProductInformation[12] = _fraProductInformation_12;
			this.fraProductInformation[4] = _fraProductInformation_4;
			this.fraProductInformation[5] = _fraProductInformation_5;
			this.fraProductInformation[0] = _fraProductInformation_0;
			this.fraProductInformation[3] = _fraProductInformation_3;
			this.fraProductInformation[6] = _fraProductInformation_6;
			this.fraProductInformation[1] = _fraProductInformation_1;
			this.fraProductInformation[8] = _fraProductInformation_8;
			this.fraProductInformation[2] = _fraProductInformation_2;
			this.fraProductInformation[7] = _fraProductInformation_7;
			this.fraProductInformation[9] = _fraProductInformation_9;
			this.fraProductInformation[10] = _fraProductInformation_10;
			this.fraProductInformation[11] = _fraProductInformation_11;
		}
		void InitializecmdCommon()
		{
			this.cmdCommon = new System.Windows.Forms.Button[3];
			this.cmdCommon[1] = _cmdCommon_1;
			this.cmdCommon[2] = _cmdCommon_2;
			this.cmdCommon[0] = _cmdCommon_0;
		}
		void InitializecmbCommon()
		{
			this.cmbCommon = new System.Windows.Forms.ComboBox[2];
			this.cmbCommon[0] = _cmbCommon_0;
			this.cmbCommon[1] = _cmbCommon_1;
		}
		void InitializechkCommon()
		{
			this.chkCommon = new System.Windows.Forms.CheckBox[4];
			this.chkCommon[0] = _chkCommon_0;
			this.chkCommon[1] = _chkCommon_1;
			this.chkCommon[3] = _chkCommon_3;
			this.chkCommon[2] = _chkCommon_2;
		}
		#endregion
	}
}//ENDSHERE
