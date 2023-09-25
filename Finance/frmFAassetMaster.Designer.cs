
namespace Xtreme
{
	partial class frmFAAssetMaster
	{

		#region "Upgrade Support "
		private static frmFAAssetMaster m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmFAAssetMaster DefInstance
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
		public static frmFAAssetMaster CreateInstance()
		{
			frmFAAssetMaster theInstance = new frmFAAssetMaster();
			
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
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "_lblCommon_1", "_lblCommon_2", "_lblCommon_0", "lblInvoiceNo", "lblInvoiceAmount", "lblPurchaseDate", "lblQuantity", "lblExchangeRate", "lblReceiptNumber", "txtPurchaseDate", "_txtCommonNumber_0", "_txtCommon_8", "_txtCommonNumber_1", "_txtCommon_6", "_txtCommon_7", "lblExpensesCostCenterCd", "_txtCommon_10", "_txtCommon_4", "lblSupplierCode", "lblAdjustedValue", "lblAccumDeprAmount", "lblBookValue", "lblWriteOffQuantity", "lblLastDeprDate", "lblLastAdjDate", "lblLastWriteOffDt", "txtLastDeprDate", "_txtCommonNumber_4", "System.Windows.Forms.Label1", "lblExpensesAmount", "_txtCommonNumber_2", "_txtCommon_9", "lblExpensesAccount", "System.Windows.Forms.Label2", "_txtCommonDisplay_13", "_txtCommonDisplay_3", "_txtCommonDisplay_8", "_txtCommonDisplay_6", "_txtCommonDisplay_7", "_txtCommonDisplay_9", "_txtCommonDisplay_10", "_txtCommonDisplay_11", "_txtCommonDisplay_1", "_txtCommonDisplay_4", "_Line1_1", "_Line1_2", "_Line1_3", "_fraLedgerInformation_1", "txtComment", "_txtCommon_12", "lblDeprPercent", "lblStartDeprDate", "txtStartDeprDate", "_txtCommonNumber_3", "lblDepreciationMethod", "_txtCommonDisplay_12", "Frame1", "_lblCommon_8", "lblUnit", "lblCategoryCode", "_txtCommon_3", "_txtCommon_5", "lblLocationOfAsset", "_txtCommon_11", "System.Windows.Forms.Label3", "_txtCommon_13", "_txtCommonDisplay_14", "_txtCommonDisplay_2", "_txtCommonDisplay_0", "_txtCommonDisplay_5", "_fraLedgerInformation_0", "Column_0_grdVoucherDetails", "Column_1_grdVoucherDetails", "grdVoucherDetails", "Column_0_cmbCommon", "Column_1_cmbCommon", "cmbCommon", "_fraLedgerInformation_3", "tabMaster", "lblLLAssetName", "lblLAAssetName", "lblAssetCode", "_txtCommon_1", "_txtCommon_2", "_txtCommon_0", "_lblCommon_3", "_Line1_0", "Line1", "fraLedgerInformation", "lblCommon", "txtCommon", "txtCommonDisplay", "txtCommonNumber"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		private System.Windows.Forms.Label _lblCommon_1;
		private System.Windows.Forms.Label _lblCommon_2;
		private System.Windows.Forms.Label _lblCommon_0;
		public System.Windows.Forms.Label lblInvoiceNo;
		public System.Windows.Forms.Label lblInvoiceAmount;
		public System.Windows.Forms.Label lblPurchaseDate;
		public System.Windows.Forms.Label lblQuantity;
		public System.Windows.Forms.Label lblExchangeRate;
		public System.Windows.Forms.Label lblReceiptNumber;
		public Syncfusion.WinForms.Input.SfDateTimeEdit txtPurchaseDate;
		private System.Windows.Forms.TextBox _txtCommonNumber_0;
		private System.Windows.Forms.TextBox _txtCommon_8;
		private System.Windows.Forms.TextBox _txtCommonNumber_1;
		private System.Windows.Forms.TextBox _txtCommon_6;
		private System.Windows.Forms.TextBox _txtCommon_7;
		public System.Windows.Forms.Label lblExpensesCostCenterCd;
		private System.Windows.Forms.TextBox _txtCommon_10;
		private System.Windows.Forms.TextBox _txtCommon_4;
		public System.Windows.Forms.Label lblSupplierCode;
		public System.Windows.Forms.Label lblAdjustedValue;
		public System.Windows.Forms.Label lblAccumDeprAmount;
		public System.Windows.Forms.Label lblBookValue;
		public System.Windows.Forms.Label lblWriteOffQuantity;
		public System.Windows.Forms.Label lblLastDeprDate;
		public System.Windows.Forms.Label lblLastAdjDate;
		public System.Windows.Forms.Label lblLastWriteOffDt;
		public Syncfusion.WinForms.Input.SfDateTimeEdit txtLastDeprDate;
		private System.Windows.Forms.TextBox _txtCommonNumber_4;
		public System.Windows.Forms.Label System.Windows.Forms.Label1;
		public System.Windows.Forms.Label lblExpensesAmount;
		private System.Windows.Forms.TextBox _txtCommonNumber_2;
		private System.Windows.Forms.TextBox _txtCommon_9;
		public System.Windows.Forms.Label lblExpensesAccount;
		public System.Windows.Forms.Label System.Windows.Forms.Label2;
		private System.Windows.Forms.Label _txtCommonDisplay_13;
		private System.Windows.Forms.Label _txtCommonDisplay_3;
		private System.Windows.Forms.Label _txtCommonDisplay_8;
		private System.Windows.Forms.Label _txtCommonDisplay_6;
		private System.Windows.Forms.Label _txtCommonDisplay_7;
		private System.Windows.Forms.Label _txtCommonDisplay_9;
		private System.Windows.Forms.Label _txtCommonDisplay_10;
		private System.Windows.Forms.Label _txtCommonDisplay_11;
		private System.Windows.Forms.Label _txtCommonDisplay_1;
		private System.Windows.Forms.Label _txtCommonDisplay_4;
		private System.Windows.Forms.Label _Line1_1;
		private System.Windows.Forms.Label _Line1_2;
		private System.Windows.Forms.Label _Line1_3;
		private System.Windows.Forms.Panel _fraLedgerInformation_1;
		public System.Windows.Forms.TextBox txtComment;
		private System.Windows.Forms.TextBox _txtCommon_12;
		public System.Windows.Forms.Label lblDeprPercent;
		public System.Windows.Forms.Label lblStartDeprDate;
		public Syncfusion.WinForms.Input.SfDateTimeEdit txtStartDeprDate;
		private System.Windows.Forms.TextBox _txtCommonNumber_3;
		public System.Windows.Forms.Label lblDepreciationMethod;
		private System.Windows.Forms.Label _txtCommonDisplay_12;
		public System.Windows.Forms.Panel Frame1;
		private System.Windows.Forms.Label _lblCommon_8;
		public System.Windows.Forms.Label lblUnit;
		public System.Windows.Forms.Label lblCategoryCode;
		private System.Windows.Forms.TextBox _txtCommon_3;
		private System.Windows.Forms.TextBox _txtCommon_5;
		public System.Windows.Forms.Label lblLocationOfAsset;
		private System.Windows.Forms.TextBox _txtCommon_11;
		public System.Windows.Forms.Label System.Windows.Forms.Label3;
		private System.Windows.Forms.TextBox _txtCommon_13;
		private System.Windows.Forms.Label _txtCommonDisplay_14;
		private System.Windows.Forms.Label _txtCommonDisplay_2;
		private System.Windows.Forms.Label _txtCommonDisplay_0;
		private System.Windows.Forms.Label _txtCommonDisplay_5;
		private System.Windows.Forms.Panel _fraLedgerInformation_0;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_0_grdVoucherDetails;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_1_grdVoucherDetails;
		public C1.Win.C1TrueDBGrid.C1TrueDBGrid grdVoucherDetails;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_0_cmbCommon;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_1_cmbCommon;
		public C1.Win.C1TrueDBGrid.C1TrueDBDropdown cmbCommon;
		private System.Windows.Forms.Panel _fraLedgerInformation_3;
		public AxC1SizerLib.AxC1Tab tabMaster;
		public System.Windows.Forms.Label lblLLAssetName;
		public System.Windows.Forms.Label lblLAAssetName;
		public System.Windows.Forms.Label lblAssetCode;
		private System.Windows.Forms.TextBox _txtCommon_1;
		private System.Windows.Forms.TextBox _txtCommon_2;
		private System.Windows.Forms.TextBox _txtCommon_0;
		private System.Windows.Forms.Label _lblCommon_3;
		private System.Windows.Forms.Label _Line1_0;
		public System.Windows.Forms.Label[] Line1 = new System.Windows.Forms.Label[4];
		public System.Windows.Forms.Panel[] fraLedgerInformation = new System.Windows.Forms.Panel[4];
		public System.Windows.Forms.Label[] lblCommon = new System.Windows.Forms.Label[9];
		public System.Windows.Forms.TextBox[] txtCommon = new System.Windows.Forms.TextBox[14];
		public System.Windows.Forms.Label[] txtCommonDisplay = new System.Windows.Forms.Label[15];
		public System.Windows.Forms.TextBox[] txtCommonNumber = new System.Windows.Forms.TextBox[5];
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFAAssetMaster));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this.tabMaster = new AxC1SizerLib.AxC1Tab();
			this._fraLedgerInformation_1 = new System.Windows.Forms.Panel();
			this._lblCommon_1 = new System.Windows.Forms.Label();
			this._lblCommon_2 = new System.Windows.Forms.Label();
			this._lblCommon_0 = new System.Windows.Forms.Label();
			this.lblInvoiceNo = new System.Windows.Forms.Label();
			this.lblInvoiceAmount = new System.Windows.Forms.Label();
			this.lblPurchaseDate = new System.Windows.Forms.Label();
			this.lblQuantity = new System.Windows.Forms.Label();
			this.lblExchangeRate = new System.Windows.Forms.Label();
			this.lblReceiptNumber = new System.Windows.Forms.Label();
			this.txtPurchaseDate = new Syncfusion.WinForms.Input.SfDateTimeEdit();
			this._txtCommonNumber_0 = new System.Windows.Forms.TextBox();
			this._txtCommon_8 = new System.Windows.Forms.TextBox();
			this._txtCommonNumber_1 = new System.Windows.Forms.TextBox();
			this._txtCommon_6 = new System.Windows.Forms.TextBox();
			this._txtCommon_7 = new System.Windows.Forms.TextBox();
			this.lblExpensesCostCenterCd = new System.Windows.Forms.Label();
			this._txtCommon_10 = new System.Windows.Forms.TextBox();
			this._txtCommon_4 = new System.Windows.Forms.TextBox();
			this.lblSupplierCode = new System.Windows.Forms.Label();
			this.lblAdjustedValue = new System.Windows.Forms.Label();
			this.lblAccumDeprAmount = new System.Windows.Forms.Label();
			this.lblBookValue = new System.Windows.Forms.Label();
			this.lblWriteOffQuantity = new System.Windows.Forms.Label();
			this.lblLastDeprDate = new System.Windows.Forms.Label();
			this.lblLastAdjDate = new System.Windows.Forms.Label();
			this.lblLastWriteOffDt = new System.Windows.Forms.Label();
			this.txtLastDeprDate = new Syncfusion.WinForms.Input.SfDateTimeEdit();
			this._txtCommonNumber_4 = new System.Windows.Forms.TextBox();
			this.System.Windows.Forms.Label1 = new System.Windows.Forms.Label();
			this.lblExpensesAmount = new System.Windows.Forms.Label();
			this._txtCommonNumber_2 = new System.Windows.Forms.TextBox();
			this._txtCommon_9 = new System.Windows.Forms.TextBox();
			this.lblExpensesAccount = new System.Windows.Forms.Label();
			this.System.Windows.Forms.Label2 = new System.Windows.Forms.Label();
			this._txtCommonDisplay_13 = new System.Windows.Forms.Label();
			this._txtCommonDisplay_3 = new System.Windows.Forms.Label();
			this._txtCommonDisplay_8 = new System.Windows.Forms.Label();
			this._txtCommonDisplay_6 = new System.Windows.Forms.Label();
			this._txtCommonDisplay_7 = new System.Windows.Forms.Label();
			this._txtCommonDisplay_9 = new System.Windows.Forms.Label();
			this._txtCommonDisplay_10 = new System.Windows.Forms.Label();
			this._txtCommonDisplay_11 = new System.Windows.Forms.Label();
			this._txtCommonDisplay_1 = new System.Windows.Forms.Label();
			this._txtCommonDisplay_4 = new System.Windows.Forms.Label();
			this._Line1_1 = new System.Windows.Forms.Label();
			this._Line1_2 = new System.Windows.Forms.Label();
			this._Line1_3 = new System.Windows.Forms.Label();
			this._fraLedgerInformation_0 = new System.Windows.Forms.Panel();
			this.txtComment = new System.Windows.Forms.TextBox();
			this.Frame1 = new System.Windows.Forms.Panel();
			this._txtCommon_12 = new System.Windows.Forms.TextBox();
			this.lblDeprPercent = new System.Windows.Forms.Label();
			this.lblStartDeprDate = new System.Windows.Forms.Label();
			this.txtStartDeprDate = new Syncfusion.WinForms.Input.SfDateTimeEdit();
			this._txtCommonNumber_3 = new System.Windows.Forms.TextBox();
			this.lblDepreciationMethod = new System.Windows.Forms.Label();
			this._txtCommonDisplay_12 = new System.Windows.Forms.Label();
			this._lblCommon_8 = new System.Windows.Forms.Label();
			this.lblUnit = new System.Windows.Forms.Label();
			this.lblCategoryCode = new System.Windows.Forms.Label();
			this._txtCommon_3 = new System.Windows.Forms.TextBox();
			this._txtCommon_5 = new System.Windows.Forms.TextBox();
			this.lblLocationOfAsset = new System.Windows.Forms.Label();
			this._txtCommon_11 = new System.Windows.Forms.TextBox();
			this.System.Windows.Forms.Label3 = new System.Windows.Forms.Label();
			this._txtCommon_13 = new System.Windows.Forms.TextBox();
			this._txtCommonDisplay_14 = new System.Windows.Forms.Label();
			this._txtCommonDisplay_2 = new System.Windows.Forms.Label();
			this._txtCommonDisplay_0 = new System.Windows.Forms.Label();
			this._txtCommonDisplay_5 = new System.Windows.Forms.Label();
			this._fraLedgerInformation_3 = new System.Windows.Forms.Panel();
			this.grdVoucherDetails = new C1.Win.C1TrueDBGrid.C1TrueDBGrid();
			this.Column_0_grdVoucherDetails = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.Column_1_grdVoucherDetails = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.cmbCommon = new C1.Win.C1TrueDBGrid.C1TrueDBDropdown();
			this.Column_0_cmbCommon = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.Column_1_cmbCommon = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.lblLLAssetName = new System.Windows.Forms.Label();
			this.lblLAAssetName = new System.Windows.Forms.Label();
			this.lblAssetCode = new System.Windows.Forms.Label();
			this._txtCommon_1 = new System.Windows.Forms.TextBox();
			this._txtCommon_2 = new System.Windows.Forms.TextBox();
			this._txtCommon_0 = new System.Windows.Forms.TextBox();
			this._lblCommon_3 = new System.Windows.Forms.Label();
			this._Line1_0 = new System.Windows.Forms.Label();
			// //((System.ComponentModel.ISupportInitialize) this.tabMaster).BeginInit();
			this.tabMaster.SuspendLayout();
			this._fraLedgerInformation_1.SuspendLayout();
			this._fraLedgerInformation_0.SuspendLayout();
			this.Frame1.SuspendLayout();
			this._fraLedgerInformation_3.SuspendLayout();
			this.grdVoucherDetails.SuspendLayout();
			this.cmbCommon.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabMaster
			// 
			this.tabMaster.Align = C1SizerLib.AlignSettings.asNone;
			this.tabMaster.AllowDrop = true;
			this.tabMaster.Controls.Add(this._fraLedgerInformation_1);
			this.tabMaster.Controls.Add(this._fraLedgerInformation_0);
			this.tabMaster.Controls.Add(this._fraLedgerInformation_3);
			this.tabMaster.Location = new System.Drawing.Point(14, 111);
			this.tabMaster.Name = "tabMaster";
			("tabMaster.OcxState");
			this.tabMaster.Size = new System.Drawing.Size(593, 269);
			this.tabMaster.TabIndex = 0;
			this.tabMaster.TabStop = false;
			// 
			// _fraLedgerInformation_1
			// 
			this._fraLedgerInformation_1.AllowDrop = true;
			this._fraLedgerInformation_1.BackColor = System.Drawing.Color.White;
			this._fraLedgerInformation_1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._fraLedgerInformation_1.Controls.Add(this._lblCommon_1);
			this._fraLedgerInformation_1.Controls.Add(this._lblCommon_2);
			this._fraLedgerInformation_1.Controls.Add(this._lblCommon_0);
			this._fraLedgerInformation_1.Controls.Add(this.lblInvoiceNo);
			this._fraLedgerInformation_1.Controls.Add(this.lblInvoiceAmount);
			this._fraLedgerInformation_1.Controls.Add(this.lblPurchaseDate);
			this._fraLedgerInformation_1.Controls.Add(this.lblQuantity);
			this._fraLedgerInformation_1.Controls.Add(this.lblExchangeRate);
			this._fraLedgerInformation_1.Controls.Add(this.lblReceiptNumber);
			this._fraLedgerInformation_1.Controls.Add(this.txtPurchaseDate);
			this._fraLedgerInformation_1.Controls.Add(this._txtCommonNumber_0);
			this._fraLedgerInformation_1.Controls.Add(this._txtCommon_8);
			this._fraLedgerInformation_1.Controls.Add(this._txtCommonNumber_1);
			this._fraLedgerInformation_1.Controls.Add(this._txtCommon_6);
			this._fraLedgerInformation_1.Controls.Add(this._txtCommon_7);
			this._fraLedgerInformation_1.Controls.Add(this.lblExpensesCostCenterCd);
			this._fraLedgerInformation_1.Controls.Add(this._txtCommon_10);
			this._fraLedgerInformation_1.Controls.Add(this._txtCommon_4);
			this._fraLedgerInformation_1.Controls.Add(this.lblSupplierCode);
			this._fraLedgerInformation_1.Controls.Add(this.lblAdjustedValue);
			this._fraLedgerInformation_1.Controls.Add(this.lblAccumDeprAmount);
			this._fraLedgerInformation_1.Controls.Add(this.lblBookValue);
			this._fraLedgerInformation_1.Controls.Add(this.lblWriteOffQuantity);
			this._fraLedgerInformation_1.Controls.Add(this.lblLastDeprDate);
			this._fraLedgerInformation_1.Controls.Add(this.lblLastAdjDate);
			this._fraLedgerInformation_1.Controls.Add(this.lblLastWriteOffDt);
			this._fraLedgerInformation_1.Controls.Add(this.txtLastDeprDate);
			this._fraLedgerInformation_1.Controls.Add(this._txtCommonNumber_4);
			this._fraLedgerInformation_1.Controls.Add(this.System.Windows.Forms.Label1);
			this._fraLedgerInformation_1.Controls.Add(this.lblExpensesAmount);
			this._fraLedgerInformation_1.Controls.Add(this._txtCommonNumber_2);
			this._fraLedgerInformation_1.Controls.Add(this._txtCommon_9);
			this._fraLedgerInformation_1.Controls.Add(this.lblExpensesAccount);
			this._fraLedgerInformation_1.Controls.Add(this.System.Windows.Forms.Label2);
			this._fraLedgerInformation_1.Controls.Add(this._txtCommonDisplay_13);
			this._fraLedgerInformation_1.Controls.Add(this._txtCommonDisplay_3);
			this._fraLedgerInformation_1.Controls.Add(this._txtCommonDisplay_8);
			this._fraLedgerInformation_1.Controls.Add(this._txtCommonDisplay_6);
			this._fraLedgerInformation_1.Controls.Add(this._txtCommonDisplay_7);
			this._fraLedgerInformation_1.Controls.Add(this._txtCommonDisplay_9);
			this._fraLedgerInformation_1.Controls.Add(this._txtCommonDisplay_10);
			this._fraLedgerInformation_1.Controls.Add(this._txtCommonDisplay_11);
			this._fraLedgerInformation_1.Controls.Add(this._txtCommonDisplay_1);
			this._fraLedgerInformation_1.Controls.Add(this._txtCommonDisplay_4);
			this._fraLedgerInformation_1.Controls.Add(this._Line1_1);
			this._fraLedgerInformation_1.Controls.Add(this._Line1_2);
			this._fraLedgerInformation_1.Controls.Add(this._Line1_3);
			this._fraLedgerInformation_1.Enabled = true;
			this._fraLedgerInformation_1.ForeColor = System.Drawing.SystemColors.WindowText;
			this._fraLedgerInformation_1.Location = new System.Drawing.Point(634, 23);
			this._fraLedgerInformation_1.Name = "_fraLedgerInformation_1";
			this._fraLedgerInformation_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._fraLedgerInformation_1.Size = new System.Drawing.Size(591, 245);
			this._fraLedgerInformation_1.TabIndex = 27;
			this._fraLedgerInformation_1.Visible = true;
			// 
			// _lblCommon_1
			// 
			this._lblCommon_1.AllowDrop = true;
			this._lblCommon_1.BackColor = System.Drawing.SystemColors.Window;
			this._lblCommon_1.Text = "Expense Details";
			this._lblCommon_1.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_1.Location = new System.Drawing.Point(20, 92);
			// this._lblCommon_1.mLabelId = 997;
			this._lblCommon_1.Name = "_lblCommon_1";
			this._lblCommon_1.Size = new System.Drawing.Size(87, 14);
			this._lblCommon_1.TabIndex = 28;
			// 
			// _lblCommon_2
			// 
			this._lblCommon_2.AllowDrop = true;
			this._lblCommon_2.BackColor = System.Drawing.SystemColors.Window;
			this._lblCommon_2.Text = "Asset History";
			this._lblCommon_2.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_2.Location = new System.Drawing.Point(6, 160);
			// this._lblCommon_2.mLabelId = 1001;
			this._lblCommon_2.Name = "_lblCommon_2";
			this._lblCommon_2.Size = new System.Drawing.Size(75, 14);
			this._lblCommon_2.TabIndex = 29;
			// 
			// _lblCommon_0
			// 
			this._lblCommon_0.AllowDrop = true;
			this._lblCommon_0.BackColor = System.Drawing.SystemColors.Window;
			this._lblCommon_0.Text = "Purchase Details";
			this._lblCommon_0.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_0.Location = new System.Drawing.Point(6, 10);
			// this._lblCommon_0.mLabelId = 993;
			this._lblCommon_0.Name = "_lblCommon_0";
			this._lblCommon_0.Size = new System.Drawing.Size(92, 14);
			this._lblCommon_0.TabIndex = 30;
			// 
			// lblInvoiceNo
			// 
			this.lblInvoiceNo.AllowDrop = true;
			this.lblInvoiceNo.BackColor = System.Drawing.SystemColors.Window;
			this.lblInvoiceNo.Text = "Invoice No.";
			this.lblInvoiceNo.ForeColor = System.Drawing.Color.Black;
			this.lblInvoiceNo.Location = new System.Drawing.Point(228, 51);
			// this.lblInvoiceNo.mLabelId = 333;
			this.lblInvoiceNo.Name = "lblInvoiceNo";
			this.lblInvoiceNo.Size = new System.Drawing.Size(53, 14);
			this.lblInvoiceNo.TabIndex = 31;
			// 
			// lblInvoiceAmount
			// 
			this.lblInvoiceAmount.AllowDrop = true;
			this.lblInvoiceAmount.BackColor = System.Drawing.SystemColors.Window;
			this.lblInvoiceAmount.Text = "Invoice Amount";
			this.lblInvoiceAmount.ForeColor = System.Drawing.Color.Black;
			this.lblInvoiceAmount.Location = new System.Drawing.Point(6, 72);
			// this.lblInvoiceAmount.mLabelId = 995;
			this.lblInvoiceAmount.Name = "lblInvoiceAmount";
			this.lblInvoiceAmount.Size = new System.Drawing.Size(74, 14);
			this.lblInvoiceAmount.TabIndex = 32;
			// 
			// lblPurchaseDate
			// 
			this.lblPurchaseDate.AllowDrop = true;
			this.lblPurchaseDate.BackColor = System.Drawing.SystemColors.Window;
			this.lblPurchaseDate.Text = "Purchase Date";
			this.lblPurchaseDate.ForeColor = System.Drawing.Color.Black;
			this.lblPurchaseDate.Location = new System.Drawing.Point(6, 51);
			// this.lblPurchaseDate.mLabelId = 994;
			this.lblPurchaseDate.Name = "lblPurchaseDate";
			this.lblPurchaseDate.Size = new System.Drawing.Size(71, 14);
			this.lblPurchaseDate.TabIndex = 33;
			// 
			// lblQuantity
			// 
			this.lblQuantity.AllowDrop = true;
			this.lblQuantity.BackColor = System.Drawing.SystemColors.Window;
			this.lblQuantity.Text = "Quantity";
			this.lblQuantity.ForeColor = System.Drawing.Color.Black;
			this.lblQuantity.Location = new System.Drawing.Point(422, 51);
			// this.lblQuantity.mLabelId = 601;
			this.lblQuantity.Name = "lblQuantity";
			this.lblQuantity.Size = new System.Drawing.Size(40, 14);
			this.lblQuantity.TabIndex = 34;
			// 
			// lblExchangeRate
			// 
			this.lblExchangeRate.AllowDrop = true;
			this.lblExchangeRate.BackColor = System.Drawing.SystemColors.Window;
			this.lblExchangeRate.Text = "Exchange Rate";
			this.lblExchangeRate.ForeColor = System.Drawing.Color.Black;
			this.lblExchangeRate.Location = new System.Drawing.Point(228, 72);
			// this.lblExchangeRate.mLabelId = 260;
			this.lblExchangeRate.Name = "lblExchangeRate";
			this.lblExchangeRate.Size = new System.Drawing.Size(73, 14);
			this.lblExchangeRate.TabIndex = 35;
			// 
			// lblReceiptNumber
			// 
			this.lblReceiptNumber.AllowDrop = true;
			this.lblReceiptNumber.BackColor = System.Drawing.SystemColors.Window;
			this.lblReceiptNumber.Text = "Receipt No.";
			this.lblReceiptNumber.ForeColor = System.Drawing.Color.Black;
			this.lblReceiptNumber.Location = new System.Drawing.Point(422, 72);
			// this.lblReceiptNumber.mLabelId = 996;
			this.lblReceiptNumber.Name = "lblReceiptNumber";
			this.lblReceiptNumber.Size = new System.Drawing.Size(55, 14);
			this.lblReceiptNumber.TabIndex = 36;
			// 
			// txtPurchaseDate
			// 
			this.txtPurchaseDate.AllowDrop = true;
			// this.txtPurchaseDate.CheckDateRange = false;
			this.txtPurchaseDate.Location = new System.Drawing.Point(102, 49);
			// this.txtPurchaseDate.MaxDate = 2958465;
			// this.txtPurchaseDate.MinDate = 2;
			this.txtPurchaseDate.Name = "txtPurchaseDate";
			this.txtPurchaseDate.Size = new System.Drawing.Size(101, 19);
			this.txtPurchaseDate.TabIndex = 37;
			this.txtPurchaseDate.Text = "15/03/2014";
			// 
			// _txtCommonNumber_0
			// 
			this._txtCommonNumber_0.AllowDrop = true;
			// this._txtCommonNumber_0.DisplayFormat = "########0.000###;;0.000;0.000";
			// this._txtCommonNumber_0.Format = "###########0.000";
			this._txtCommonNumber_0.Location = new System.Drawing.Point(305, 70);
			// this._txtCommonNumber_0.MaxValue = 2147483647;
			// this._txtCommonNumber_0.MinValue = 0;
			this._txtCommonNumber_0.Name = "_txtCommonNumber_0";
			this._txtCommonNumber_0.Size = new System.Drawing.Size(101, 19);
			this._txtCommonNumber_0.TabIndex = 38;
			this._txtCommonNumber_0.Text = "0.000";
			this._txtCommonNumber_0.Validating += new System.ComponentModel.CancelEventHandler(this.txtCommonNumber_Validating);
			// 
			// _txtCommon_8
			// 
			this._txtCommon_8.AllowDrop = true;
			this._txtCommon_8.BackColor = System.Drawing.Color.White;
			this._txtCommon_8.ForeColor = System.Drawing.Color.Black;
			this._txtCommon_8.Location = new System.Drawing.Point(484, 70);
			this._txtCommon_8.MaxLength = 10;
			this._txtCommon_8.Name = "_txtCommon_8";
			this._txtCommon_8.Size = new System.Drawing.Size(101, 19);
			this._txtCommon_8.TabIndex = 39;
			this._txtCommon_8.Text = "";
			// this.this._txtCommon_8.Watermark = "";
			// this.this._txtCommon_8.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommon_DropButtonClick);
			// this._txtCommon_8.Leave += new System.EventHandler(this.txtCommon_Leave);
			// 
			// _txtCommonNumber_1
			// 
			this._txtCommonNumber_1.AllowDrop = true;
			// this._txtCommonNumber_1.DisplayFormat = "########0.000###;;0.000;0.000";
			// this._txtCommonNumber_1.Format = "###########0.000";
			this._txtCommonNumber_1.Location = new System.Drawing.Point(102, 70);
			// this._txtCommonNumber_1.MaxValue = 2147483647;
			// this._txtCommonNumber_1.MinValue = 0;
			this._txtCommonNumber_1.Name = "_txtCommonNumber_1";
			this._txtCommonNumber_1.Size = new System.Drawing.Size(101, 19);
			this._txtCommonNumber_1.TabIndex = 40;
			this._txtCommonNumber_1.Text = "0.000";
			this._txtCommonNumber_1.Validating += new System.ComponentModel.CancelEventHandler(this.txtCommonNumber_Validating);
			// 
			// _txtCommon_6
			// 
			this._txtCommon_6.AllowDrop = true;
			this._txtCommon_6.BackColor = System.Drawing.Color.White;
			// this._txtCommon_6.bolAllowDecimal = false;
			this._txtCommon_6.ForeColor = System.Drawing.Color.Black;
			this._txtCommon_6.Location = new System.Drawing.Point(305, 49);
			this._txtCommon_6.MaxLength = 50;
			this._txtCommon_6.Name = "_txtCommon_6";
			this._txtCommon_6.Size = new System.Drawing.Size(101, 19);
			this._txtCommon_6.TabIndex = 41;
			this._txtCommon_6.Text = "";
			// this.this._txtCommon_6.Watermark = "";
			// this.this._txtCommon_6.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommon_DropButtonClick);
			// this._txtCommon_6.Leave += new System.EventHandler(this.txtCommon_Leave);
			// 
			// _txtCommon_7
			// 
			this._txtCommon_7.AllowDrop = true;
			this._txtCommon_7.BackColor = System.Drawing.Color.White;
			// this._txtCommon_7.bolAllowDecimal = false;
			// this._txtCommon_7.bolNumericOnly = true;
			this._txtCommon_7.ForeColor = System.Drawing.Color.Black;
			this._txtCommon_7.Location = new System.Drawing.Point(484, 49);
			this._txtCommon_7.MaxLength = 50;
			this._txtCommon_7.Name = "_txtCommon_7";
			this._txtCommon_7.Size = new System.Drawing.Size(101, 19);
			this._txtCommon_7.TabIndex = 42;
			this._txtCommon_7.Text = "";
			// this.this._txtCommon_7.Watermark = "";
			// this.this._txtCommon_7.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommon_DropButtonClick);
			// this._txtCommon_7.Leave += new System.EventHandler(this.txtCommon_Leave);
			// 
			// lblExpensesCostCenterCd
			// 
			this.lblExpensesCostCenterCd.AllowDrop = true;
			this.lblExpensesCostCenterCd.BackColor = System.Drawing.SystemColors.Window;
			this.lblExpensesCostCenterCd.Text = "Exp. Cost Center";
			this.lblExpensesCostCenterCd.ForeColor = System.Drawing.Color.Black;
			this.lblExpensesCostCenterCd.Location = new System.Drawing.Point(20, 135);
			// this.lblExpensesCostCenterCd.mLabelId = 999;
			this.lblExpensesCostCenterCd.Name = "lblExpensesCostCenterCd";
			this.lblExpensesCostCenterCd.Size = new System.Drawing.Size(81, 14);
			this.lblExpensesCostCenterCd.TabIndex = 43;
			// 
			// _txtCommon_10
			// 
			this._txtCommon_10.AllowDrop = true;
			this._txtCommon_10.BackColor = System.Drawing.Color.White;
			// this._txtCommon_10.bolNumericOnly = true;
			this._txtCommon_10.ForeColor = System.Drawing.Color.Black;
			this._txtCommon_10.Location = new System.Drawing.Point(102, 133);
			this._txtCommon_10.MaxLength = 15;
			this._txtCommon_10.Name = "_txtCommon_10";
			// this._txtCommon_10.ShowButton = true;
			this._txtCommon_10.Size = new System.Drawing.Size(101, 19);
			this._txtCommon_10.TabIndex = 44;
			this._txtCommon_10.Text = "";
			// this.this._txtCommon_10.Watermark = "";
			// this.this._txtCommon_10.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommon_DropButtonClick);
			// this._txtCommon_10.Leave += new System.EventHandler(this.txtCommon_Leave);
			// 
			// _txtCommon_4
			// 
			this._txtCommon_4.AllowDrop = true;
			this._txtCommon_4.BackColor = System.Drawing.Color.White;
			this._txtCommon_4.ForeColor = System.Drawing.Color.Black;
			this._txtCommon_4.Location = new System.Drawing.Point(102, 28);
			this._txtCommon_4.MaxLength = 15;
			this._txtCommon_4.Name = "_txtCommon_4";
			// this._txtCommon_4.ShowButton = true;
			this._txtCommon_4.Size = new System.Drawing.Size(101, 19);
			this._txtCommon_4.TabIndex = 45;
			this._txtCommon_4.Text = "";
			// this.this._txtCommon_4.Watermark = "";
			// this.this._txtCommon_4.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommon_DropButtonClick);
			// this._txtCommon_4.Leave += new System.EventHandler(this.txtCommon_Leave);
			// 
			// lblSupplierCode
			// 
			this.lblSupplierCode.AllowDrop = true;
			this.lblSupplierCode.BackColor = System.Drawing.SystemColors.Window;
			this.lblSupplierCode.Text = "Supplier Code";
			this.lblSupplierCode.ForeColor = System.Drawing.Color.Black;
			this.lblSupplierCode.Location = new System.Drawing.Point(6, 30);
			// this.lblSupplierCode.mLabelId = 866;
			this.lblSupplierCode.Name = "lblSupplierCode";
			this.lblSupplierCode.Size = new System.Drawing.Size(67, 14);
			this.lblSupplierCode.TabIndex = 46;
			// 
			// lblAdjustedValue
			// 
			this.lblAdjustedValue.AllowDrop = true;
			this.lblAdjustedValue.BackColor = System.Drawing.SystemColors.Window;
			this.lblAdjustedValue.Text = "Adj. Value";
			this.lblAdjustedValue.ForeColor = System.Drawing.Color.Black;
			this.lblAdjustedValue.Location = new System.Drawing.Point(414, 201);
			this.lblAdjustedValue.Name = "lblAdjustedValue";
			this.lblAdjustedValue.Size = new System.Drawing.Size(50, 14);
			this.lblAdjustedValue.TabIndex = 47;
			// 
			// lblAccumDeprAmount
			// 
			this.lblAccumDeprAmount.AllowDrop = true;
			this.lblAccumDeprAmount.BackColor = System.Drawing.SystemColors.Window;
			this.lblAccumDeprAmount.Text = "Accmltd Depr. Amt";
			this.lblAccumDeprAmount.ForeColor = System.Drawing.Color.Black;
			this.lblAccumDeprAmount.Location = new System.Drawing.Point(6, 180);
			// this.lblAccumDeprAmount.mLabelId = 1003;
			this.lblAccumDeprAmount.Name = "lblAccumDeprAmount";
			this.lblAccumDeprAmount.Size = new System.Drawing.Size(90, 14);
			this.lblAccumDeprAmount.TabIndex = 48;
			// 
			// lblBookValue
			// 
			this.lblBookValue.AllowDrop = true;
			this.lblBookValue.BackColor = System.Drawing.SystemColors.Window;
			this.lblBookValue.Text = "Curr. Book Value ";
			this.lblBookValue.ForeColor = System.Drawing.Color.Black;
			this.lblBookValue.Location = new System.Drawing.Point(6, 222);
			// this.lblBookValue.mLabelId = 1005;
			this.lblBookValue.Name = "lblBookValue";
			this.lblBookValue.Size = new System.Drawing.Size(85, 14);
			this.lblBookValue.TabIndex = 49;
			// 
			// lblWriteOffQuantity
			// 
			this.lblWriteOffQuantity.AllowDrop = true;
			this.lblWriteOffQuantity.BackColor = System.Drawing.SystemColors.Window;
			this.lblWriteOffQuantity.Text = "Writeoff Qty";
			this.lblWriteOffQuantity.ForeColor = System.Drawing.Color.Black;
			this.lblWriteOffQuantity.Location = new System.Drawing.Point(212, 222);
			// this.lblWriteOffQuantity.mLabelId = 1008;
			this.lblWriteOffQuantity.Name = "lblWriteOffQuantity";
			this.lblWriteOffQuantity.Size = new System.Drawing.Size(59, 14);
			this.lblWriteOffQuantity.TabIndex = 50;
			// 
			// lblLastDeprDate
			// 
			this.lblLastDeprDate.AllowDrop = true;
			this.lblLastDeprDate.BackColor = System.Drawing.SystemColors.Window;
			this.lblLastDeprDate.Text = "Last Depr. Date";
			this.lblLastDeprDate.ForeColor = System.Drawing.Color.Black;
			this.lblLastDeprDate.Location = new System.Drawing.Point(212, 181);
			// this.lblLastDeprDate.mLabelId = 1006;
			this.lblLastDeprDate.Name = "lblLastDeprDate";
			this.lblLastDeprDate.Size = new System.Drawing.Size(75, 14);
			this.lblLastDeprDate.TabIndex = 51;
			// 
			// lblLastAdjDate
			// 
			this.lblLastAdjDate.AllowDrop = true;
			this.lblLastAdjDate.BackColor = System.Drawing.SystemColors.Window;
			this.lblLastAdjDate.Text = "Last Adj. Date";
			this.lblLastAdjDate.ForeColor = System.Drawing.Color.Black;
			this.lblLastAdjDate.Location = new System.Drawing.Point(414, 180);
			// this.lblLastAdjDate.mLabelId = 1009;
			this.lblLastAdjDate.Name = "lblLastAdjDate";
			this.lblLastAdjDate.Size = new System.Drawing.Size(68, 14);
			this.lblLastAdjDate.TabIndex = 52;
			// 
			// lblLastWriteOffDt
			// 
			this.lblLastWriteOffDt.AllowDrop = true;
			this.lblLastWriteOffDt.BackColor = System.Drawing.SystemColors.Window;
			this.lblLastWriteOffDt.Text = "Last Writeoff Date";
			this.lblLastWriteOffDt.ForeColor = System.Drawing.Color.Black;
			this.lblLastWriteOffDt.Location = new System.Drawing.Point(212, 201);
			// this.lblLastWriteOffDt.mLabelId = 1007;
			this.lblLastWriteOffDt.Name = "lblLastWriteOffDt";
			this.lblLastWriteOffDt.Size = new System.Drawing.Size(88, 14);
			this.lblLastWriteOffDt.TabIndex = 53;
			// 
			// txtLastDeprDate
			// 
			this.txtLastDeprDate.AllowDrop = true;
			// this.txtLastDeprDate.CheckDateRange = false;
			this.txtLastDeprDate.Location = new System.Drawing.Point(305, 178);
			// this.txtLastDeprDate.MaxDate = 2958465;
			// this.txtLastDeprDate.MinDate = 2;
			this.txtLastDeprDate.Name = "txtLastDeprDate";
			this.txtLastDeprDate.Size = new System.Drawing.Size(101, 19);
			this.txtLastDeprDate.TabIndex = 54;
			this.txtLastDeprDate.Text = "15/03/2014";
			// 
			// _txtCommonNumber_4
			// 
			this._txtCommonNumber_4.AllowDrop = true;
			// this._txtCommonNumber_4.DisplayFormat = "########0.000###;;0.000;0.000";
			// this._txtCommonNumber_4.Format = "###########0.000";
			this._txtCommonNumber_4.Location = new System.Drawing.Point(102, 178);
			// this._txtCommonNumber_4.MaxValue = 2147483647;
			// this._txtCommonNumber_4.MinValue = 0;
			this._txtCommonNumber_4.Name = "_txtCommonNumber_4";
			this._txtCommonNumber_4.Size = new System.Drawing.Size(101, 19);
			this._txtCommonNumber_4.TabIndex = 55;
			this._txtCommonNumber_4.Text = "0.000";
			this._txtCommonNumber_4.Validating += new System.ComponentModel.CancelEventHandler(this.txtCommonNumber_Validating);
			// 
			// System.Windows.Forms.Label1
			// 
			this.System.Windows.Forms.Label1.AllowDrop = true;
			this.System.Windows.Forms.Label1.BackColor = System.Drawing.SystemColors.Window;
			this.System.Windows.Forms.Label1.Caption = "Last Depr. Amt";
			this.System.Windows.Forms.Label1.ForeColor = System.Drawing.Color.Black;
			this.System.Windows.Forms.Label1.Location = new System.Drawing.Point(6, 201);
			this.System.Windows.Forms.Label1.mLabelId = 1004;
			this.System.Windows.Forms.Label1.Name = "System.Windows.Forms.Label1";
			this.System.Windows.Forms.Label1.Size = new System.Drawing.Size(72, 14);
			this.System.Windows.Forms.Label1.TabIndex = 56;
			// 
			// lblExpensesAmount
			// 
			this.lblExpensesAmount.AllowDrop = true;
			this.lblExpensesAmount.BackColor = System.Drawing.SystemColors.Window;
			this.lblExpensesAmount.Text = "Exp. Amt";
			this.lblExpensesAmount.ForeColor = System.Drawing.Color.Black;
			this.lblExpensesAmount.Location = new System.Drawing.Point(422, 114);
			// this.lblExpensesAmount.mLabelId = 1000;
			this.lblExpensesAmount.Name = "lblExpensesAmount";
			this.lblExpensesAmount.Size = new System.Drawing.Size(43, 14);
			this.lblExpensesAmount.TabIndex = 57;
			// 
			// _txtCommonNumber_2
			// 
			this._txtCommonNumber_2.AllowDrop = true;
			// this._txtCommonNumber_2.DisplayFormat = "########0.000###;;0.000;0.000";
			// this._txtCommonNumber_2.Format = "###########0.000";
			this._txtCommonNumber_2.Location = new System.Drawing.Point(484, 112);
			// this._txtCommonNumber_2.MaxValue = 2147483647;
			// this._txtCommonNumber_2.MinValue = 0;
			this._txtCommonNumber_2.Name = "_txtCommonNumber_2";
			this._txtCommonNumber_2.Size = new System.Drawing.Size(101, 19);
			this._txtCommonNumber_2.TabIndex = 58;
			this._txtCommonNumber_2.Text = "0.000";
			this._txtCommonNumber_2.Validating += new System.ComponentModel.CancelEventHandler(this.txtCommonNumber_Validating);
			// 
			// _txtCommon_9
			// 
			this._txtCommon_9.AllowDrop = true;
			this._txtCommon_9.BackColor = System.Drawing.Color.White;
			// this._txtCommon_9.bolNumericOnly = true;
			this._txtCommon_9.ForeColor = System.Drawing.Color.Black;
			this._txtCommon_9.Location = new System.Drawing.Point(102, 112);
			this._txtCommon_9.MaxLength = 15;
			this._txtCommon_9.Name = "_txtCommon_9";
			// this._txtCommon_9.ShowButton = true;
			this._txtCommon_9.Size = new System.Drawing.Size(101, 19);
			this._txtCommon_9.TabIndex = 59;
			this._txtCommon_9.Text = "";
			// this.this._txtCommon_9.Watermark = "";
			// this.this._txtCommon_9.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommon_DropButtonClick);
			// this._txtCommon_9.Leave += new System.EventHandler(this.txtCommon_Leave);
			// 
			// lblExpensesAccount
			// 
			this.lblExpensesAccount.AllowDrop = true;
			this.lblExpensesAccount.BackColor = System.Drawing.SystemColors.Window;
			this.lblExpensesAccount.Text = "Exp. Account";
			this.lblExpensesAccount.ForeColor = System.Drawing.Color.Black;
			this.lblExpensesAccount.Location = new System.Drawing.Point(20, 114);
			// this.lblExpensesAccount.mLabelId = 998;
			this.lblExpensesAccount.Name = "lblExpensesAccount";
			this.lblExpensesAccount.Size = new System.Drawing.Size(65, 14);
			this.lblExpensesAccount.TabIndex = 60;
			// 
			// System.Windows.Forms.Label2
			// 
			this.System.Windows.Forms.Label2.AllowDrop = true;
			this.System.Windows.Forms.Label2.BackColor = System.Drawing.SystemColors.Window;
			this.System.Windows.Forms.Label2.Caption = "Writeoff Value";
			this.System.Windows.Forms.Label2.ForeColor = System.Drawing.Color.Black;
			this.System.Windows.Forms.Label2.Location = new System.Drawing.Point(414, 221);
			this.System.Windows.Forms.Label2.mLabelId = 1011;
			this.System.Windows.Forms.Label2.Name = "System.Windows.Forms.Label2";
			this.System.Windows.Forms.Label2.Size = new System.Drawing.Size(70, 14);
			this.System.Windows.Forms.Label2.TabIndex = 61;
			// 
			// _txtCommonDisplay_13
			// 
			// this._txtCommonDisplay_13.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
			this._txtCommonDisplay_13.AllowDrop = true;
			this._txtCommonDisplay_13.Location = new System.Drawing.Point(484, 220);
			this._txtCommonDisplay_13.Name = "_txtCommonDisplay_13";
			this._txtCommonDisplay_13.Size = new System.Drawing.Size(101, 19);
			this._txtCommonDisplay_13.TabIndex = 62;
			// 
			// _txtCommonDisplay_3
			// 
			this._txtCommonDisplay_3.AllowDrop = true;
			this._txtCommonDisplay_3.Location = new System.Drawing.Point(205, 112);
			this._txtCommonDisplay_3.Name = "_txtCommonDisplay_3";
			this._txtCommonDisplay_3.Size = new System.Drawing.Size(201, 19);
			this._txtCommonDisplay_3.TabIndex = 63;
			// 
			// _txtCommonDisplay_8
			// 
			// this._txtCommonDisplay_8.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
			this._txtCommonDisplay_8.AllowDrop = true;
			this._txtCommonDisplay_8.Location = new System.Drawing.Point(305, 220);
			this._txtCommonDisplay_8.Name = "_txtCommonDisplay_8";
			this._txtCommonDisplay_8.Size = new System.Drawing.Size(101, 19);
			this._txtCommonDisplay_8.TabIndex = 64;
			// 
			// _txtCommonDisplay_6
			// 
			// this._txtCommonDisplay_6.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
			this._txtCommonDisplay_6.AllowDrop = true;
			this._txtCommonDisplay_6.Location = new System.Drawing.Point(102, 220);
			this._txtCommonDisplay_6.Name = "_txtCommonDisplay_6";
			this._txtCommonDisplay_6.Size = new System.Drawing.Size(101, 19);
			this._txtCommonDisplay_6.TabIndex = 65;
			// 
			// _txtCommonDisplay_7
			// 
			// this._txtCommonDisplay_7.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
			this._txtCommonDisplay_7.AllowDrop = true;
			this._txtCommonDisplay_7.Location = new System.Drawing.Point(102, 199);
			this._txtCommonDisplay_7.Name = "_txtCommonDisplay_7";
			this._txtCommonDisplay_7.Size = new System.Drawing.Size(101, 19);
			this._txtCommonDisplay_7.TabIndex = 66;
			// 
			// _txtCommonDisplay_9
			// 
			this._txtCommonDisplay_9.AllowDrop = true;
			this._txtCommonDisplay_9.Location = new System.Drawing.Point(305, 199);
			this._txtCommonDisplay_9.Name = "_txtCommonDisplay_9";
			this._txtCommonDisplay_9.Size = new System.Drawing.Size(101, 19);
			this._txtCommonDisplay_9.TabIndex = 67;
			// 
			// _txtCommonDisplay_10
			// 
			this._txtCommonDisplay_10.AllowDrop = true;
			this._txtCommonDisplay_10.Location = new System.Drawing.Point(484, 178);
			this._txtCommonDisplay_10.Name = "_txtCommonDisplay_10";
			this._txtCommonDisplay_10.Size = new System.Drawing.Size(101, 19);
			this._txtCommonDisplay_10.TabIndex = 68;
			// 
			// _txtCommonDisplay_11
			// 
			// this._txtCommonDisplay_11.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
			this._txtCommonDisplay_11.AllowDrop = true;
			this._txtCommonDisplay_11.Location = new System.Drawing.Point(484, 199);
			this._txtCommonDisplay_11.Name = "_txtCommonDisplay_11";
			this._txtCommonDisplay_11.Size = new System.Drawing.Size(101, 19);
			this._txtCommonDisplay_11.TabIndex = 69;
			// 
			// _txtCommonDisplay_1
			// 
			this._txtCommonDisplay_1.AllowDrop = true;
			this._txtCommonDisplay_1.Location = new System.Drawing.Point(205, 28);
			this._txtCommonDisplay_1.Name = "_txtCommonDisplay_1";
			this._txtCommonDisplay_1.Size = new System.Drawing.Size(201, 19);
			this._txtCommonDisplay_1.TabIndex = 70;
			// 
			// _txtCommonDisplay_4
			// 
			this._txtCommonDisplay_4.AllowDrop = true;
			this._txtCommonDisplay_4.Location = new System.Drawing.Point(205, 133);
			this._txtCommonDisplay_4.Name = "_txtCommonDisplay_4";
			this._txtCommonDisplay_4.Size = new System.Drawing.Size(201, 19);
			this._txtCommonDisplay_4.TabIndex = 71;
			// 
			// _Line1_1
			// 
			this._Line1_1.AllowDrop = true;
			this._Line1_1.BackColor = System.Drawing.SystemColors.WindowText;
			this._Line1_1.Enabled = false;
			this._Line1_1.Location = new System.Drawing.Point(98, 16);
			this._Line1_1.Name = "_Line1_1";
			this._Line1_1.Size = new System.Drawing.Size(615, 1);
			this._Line1_1.Visible = true;
			// 
			// _Line1_2
			// 
			this._Line1_2.AllowDrop = true;
			this._Line1_2.BackColor = System.Drawing.SystemColors.WindowText;
			this._Line1_2.Enabled = false;
			this._Line1_2.Location = new System.Drawing.Point(108, 100);
			this._Line1_2.Name = "_Line1_2";
			this._Line1_2.Size = new System.Drawing.Size(615, 1);
			this._Line1_2.Visible = true;
			// 
			// _Line1_3
			// 
			this._Line1_3.AllowDrop = true;
			this._Line1_3.BackColor = System.Drawing.SystemColors.WindowText;
			this._Line1_3.Enabled = false;
			this._Line1_3.Location = new System.Drawing.Point(82, 167);
			this._Line1_3.Name = "_Line1_3";
			this._Line1_3.Size = new System.Drawing.Size(615, 1);
			this._Line1_3.Visible = true;
			// 
			// _fraLedgerInformation_0
			// 
			this._fraLedgerInformation_0.AllowDrop = true;
			this._fraLedgerInformation_0.BackColor = System.Drawing.Color.White;
			this._fraLedgerInformation_0.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._fraLedgerInformation_0.Controls.Add(this.txtComment);
			this._fraLedgerInformation_0.Controls.Add(this.Frame1);
			this._fraLedgerInformation_0.Controls.Add(this._lblCommon_8);
			this._fraLedgerInformation_0.Controls.Add(this.lblUnit);
			this._fraLedgerInformation_0.Controls.Add(this.lblCategoryCode);
			this._fraLedgerInformation_0.Controls.Add(this._txtCommon_3);
			this._fraLedgerInformation_0.Controls.Add(this._txtCommon_5);
			this._fraLedgerInformation_0.Controls.Add(this.lblLocationOfAsset);
			this._fraLedgerInformation_0.Controls.Add(this._txtCommon_11);
			this._fraLedgerInformation_0.Controls.Add(this.System.Windows.Forms.Label3);
			this._fraLedgerInformation_0.Controls.Add(this._txtCommon_13);
			this._fraLedgerInformation_0.Controls.Add(this._txtCommonDisplay_14);
			this._fraLedgerInformation_0.Controls.Add(this._txtCommonDisplay_2);
			this._fraLedgerInformation_0.Controls.Add(this._txtCommonDisplay_0);
			this._fraLedgerInformation_0.Controls.Add(this._txtCommonDisplay_5);
			this._fraLedgerInformation_0.Enabled = true;
			this._fraLedgerInformation_0.ForeColor = System.Drawing.SystemColors.WindowText;
			this._fraLedgerInformation_0.Location = new System.Drawing.Point(1, 23);
			this._fraLedgerInformation_0.Name = "_fraLedgerInformation_0";
			this._fraLedgerInformation_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._fraLedgerInformation_0.Size = new System.Drawing.Size(591, 245);
			this._fraLedgerInformation_0.TabIndex = 4;
			this._fraLedgerInformation_0.Visible = true;
			// 
			// txtComment
			// 
			this.txtComment.AcceptsReturn = true;
			this.txtComment.AllowDrop = true;
			this.txtComment.BackColor = System.Drawing.Color.White;
			this.txtComment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtComment.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtComment.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtComment.Location = new System.Drawing.Point(131, 148);
			this.txtComment.MaxLength = 100;
			this.txtComment.Multiline = true;
			this.txtComment.Name = "txtComment";
			this.txtComment.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtComment.Size = new System.Drawing.Size(452, 85);
			this.txtComment.TabIndex = 13;
			// 
			// Frame1
			// 
			this.Frame1.AllowDrop = true;
			this.Frame1.BackColor = System.Drawing.Color.White;
			this.Frame1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Frame1.Controls.Add(this._txtCommon_12);
			this.Frame1.Controls.Add(this.lblDeprPercent);
			this.Frame1.Controls.Add(this.lblStartDeprDate);
			this.Frame1.Controls.Add(this.txtStartDeprDate);
			this.Frame1.Controls.Add(this._txtCommonNumber_3);
			this.Frame1.Controls.Add(this.lblDepreciationMethod);
			this.Frame1.Controls.Add(this._txtCommonDisplay_12);
			this.Frame1.Enabled = true;
			this.Frame1.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Frame1.Location = new System.Drawing.Point(8, 101);
			this.Frame1.Name = "Frame1";
			this.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Frame1.Size = new System.Drawing.Size(469, 47);
			this.Frame1.TabIndex = 5;
			this.Frame1.Text = " Depreciation Details ";
			this.Frame1.Visible = true;
			// 
			// _txtCommon_12
			// 
			this._txtCommon_12.AllowDrop = true;
			this._txtCommon_12.BackColor = System.Drawing.Color.White;
			// this._txtCommon_12.bolAllowDecimal = false;
			this._txtCommon_12.ForeColor = System.Drawing.Color.Black;
			this._txtCommon_12.Location = new System.Drawing.Point(123, 0);
			this._txtCommon_12.Name = "_txtCommon_12";
			// this._txtCommon_12.ShowButton = true;
			this._txtCommon_12.Size = new System.Drawing.Size(101, 19);
			this._txtCommon_12.TabIndex = 6;
			this._txtCommon_12.Text = "";
			// this.this._txtCommon_12.Watermark = "";
			// this.this._txtCommon_12.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommon_DropButtonClick);
			// this._txtCommon_12.Leave += new System.EventHandler(this.txtCommon_Leave);
			// 
			// lblDeprPercent
			// 
			this.lblDeprPercent.AllowDrop = true;
			this.lblDeprPercent.BackColor = System.Drawing.SystemColors.Window;
			this.lblDeprPercent.Text = "Depr. Percent";
			this.lblDeprPercent.ForeColor = System.Drawing.Color.Black;
			this.lblDeprPercent.Location = new System.Drawing.Point(248, 24);
			// this.lblDeprPercent.mLabelId = 992;
			this.lblDeprPercent.Name = "lblDeprPercent";
			this.lblDeprPercent.Size = new System.Drawing.Size(66, 14);
			this.lblDeprPercent.TabIndex = 7;
			// 
			// lblStartDeprDate
			// 
			this.lblStartDeprDate.AllowDrop = true;
			this.lblStartDeprDate.BackColor = System.Drawing.SystemColors.Window;
			this.lblStartDeprDate.Text = "Start Depr. Date";
			this.lblStartDeprDate.ForeColor = System.Drawing.Color.Black;
			this.lblStartDeprDate.Location = new System.Drawing.Point(0, 24);
			// this.lblStartDeprDate.mLabelId = 991;
			this.lblStartDeprDate.Name = "lblStartDeprDate";
			this.lblStartDeprDate.Size = new System.Drawing.Size(77, 14);
			this.lblStartDeprDate.TabIndex = 8;
			// 
			// txtStartDeprDate
			// 
			this.txtStartDeprDate.AllowDrop = true;
			// this.txtStartDeprDate.CheckDateRange = false;
			this.txtStartDeprDate.Location = new System.Drawing.Point(123, 21);
			// this.txtStartDeprDate.MaxDate = 2958465;
			// this.txtStartDeprDate.MinDate = 2;
			this.txtStartDeprDate.Name = "txtStartDeprDate";
			this.txtStartDeprDate.Size = new System.Drawing.Size(101, 19);
			this.txtStartDeprDate.TabIndex = 9;
			this.txtStartDeprDate.Text = "15/03/2014";
			// 
			// _txtCommonNumber_3
			// 
			this._txtCommonNumber_3.AllowDrop = true;
			// this._txtCommonNumber_3.DisplayFormat = "########0.000###;;0.000;0.000";
			// this._txtCommonNumber_3.Format = "###########0.000";
			this._txtCommonNumber_3.Location = new System.Drawing.Point(326, 21);
			// this._txtCommonNumber_3.MaxValue = 2147483647;
			// this._txtCommonNumber_3.MinValue = 0;
			this._txtCommonNumber_3.Name = "_txtCommonNumber_3";
			this._txtCommonNumber_3.Size = new System.Drawing.Size(101, 19);
			this._txtCommonNumber_3.TabIndex = 10;
			this._txtCommonNumber_3.Text = "0.000";
			this._txtCommonNumber_3.Validating += new System.ComponentModel.CancelEventHandler(this.txtCommonNumber_Validating);
			// 
			// lblDepreciationMethod
			// 
			this.lblDepreciationMethod.AllowDrop = true;
			this.lblDepreciationMethod.BackColor = System.Drawing.SystemColors.Window;
			this.lblDepreciationMethod.Text = "Depreciation Method";
			this.lblDepreciationMethod.ForeColor = System.Drawing.Color.Black;
			this.lblDepreciationMethod.Location = new System.Drawing.Point(0, 3);
			// this.lblDepreciationMethod.mLabelId = 990;
			this.lblDepreciationMethod.Name = "lblDepreciationMethod";
			this.lblDepreciationMethod.Size = new System.Drawing.Size(98, 14);
			this.lblDepreciationMethod.TabIndex = 11;
			// 
			// _txtCommonDisplay_12
			// 
			this._txtCommonDisplay_12.AllowDrop = true;
			this._txtCommonDisplay_12.Location = new System.Drawing.Point(226, 0);
			this._txtCommonDisplay_12.Name = "_txtCommonDisplay_12";
			this._txtCommonDisplay_12.Size = new System.Drawing.Size(201, 19);
			this._txtCommonDisplay_12.TabIndex = 12;
			// 
			// _lblCommon_8
			// 
			this._lblCommon_8.AllowDrop = true;
			this._lblCommon_8.BackColor = System.Drawing.SystemColors.Window;
			this._lblCommon_8.Text = "Comments";
			this._lblCommon_8.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_8.Location = new System.Drawing.Point(8, 148);
			// this._lblCommon_8.mLabelId = 135;
			this._lblCommon_8.Name = "_lblCommon_8";
			this._lblCommon_8.Size = new System.Drawing.Size(50, 14);
			this._lblCommon_8.TabIndex = 14;
			// 
			// lblUnit
			// 
			this.lblUnit.AllowDrop = true;
			this.lblUnit.BackColor = System.Drawing.SystemColors.Window;
			this.lblUnit.Text = "Unit Code";
			this.lblUnit.ForeColor = System.Drawing.Color.Black;
			this.lblUnit.Location = new System.Drawing.Point(8, 59);
			// this.lblUnit.mLabelId = 988;
			this.lblUnit.Name = "lblUnit";
			this.lblUnit.Size = new System.Drawing.Size(46, 14);
			this.lblUnit.TabIndex = 15;
			// 
			// lblCategoryCode
			// 
			this.lblCategoryCode.AllowDrop = true;
			this.lblCategoryCode.BackColor = System.Drawing.SystemColors.Window;
			this.lblCategoryCode.Text = "Category Code";
			this.lblCategoryCode.ForeColor = System.Drawing.Color.Black;
			this.lblCategoryCode.Location = new System.Drawing.Point(8, 17);
			// this.lblCategoryCode.mLabelId = 987;
			this.lblCategoryCode.Name = "lblCategoryCode";
			this.lblCategoryCode.Size = new System.Drawing.Size(72, 14);
			this.lblCategoryCode.TabIndex = 16;
			// 
			// _txtCommon_3
			// 
			this._txtCommon_3.AllowDrop = true;
			this._txtCommon_3.BackColor = System.Drawing.Color.White;
			// this._txtCommon_3.bolNumericOnly = true;
			this._txtCommon_3.ForeColor = System.Drawing.Color.Black;
			this._txtCommon_3.Location = new System.Drawing.Point(131, 14);
			this._txtCommon_3.MaxLength = 15;
			this._txtCommon_3.Name = "_txtCommon_3";
			// this._txtCommon_3.ShowButton = true;
			this._txtCommon_3.Size = new System.Drawing.Size(101, 19);
			this._txtCommon_3.TabIndex = 17;
			this._txtCommon_3.Text = "";
			// this.this._txtCommon_3.Watermark = "";
			// this.this._txtCommon_3.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommon_DropButtonClick);
			// this._txtCommon_3.Leave += new System.EventHandler(this.txtCommon_Leave);
			// 
			// _txtCommon_5
			// 
			this._txtCommon_5.AllowDrop = true;
			this._txtCommon_5.BackColor = System.Drawing.Color.White;
			// this._txtCommon_5.bolNumericOnly = true;
			this._txtCommon_5.ForeColor = System.Drawing.Color.Black;
			this._txtCommon_5.Location = new System.Drawing.Point(131, 56);
			this._txtCommon_5.MaxLength = 15;
			this._txtCommon_5.Name = "_txtCommon_5";
			// this._txtCommon_5.ShowButton = true;
			this._txtCommon_5.Size = new System.Drawing.Size(101, 19);
			this._txtCommon_5.TabIndex = 18;
			this._txtCommon_5.Text = "";
			// this.this._txtCommon_5.Watermark = "";
			// this.this._txtCommon_5.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommon_DropButtonClick);
			// this._txtCommon_5.Leave += new System.EventHandler(this.txtCommon_Leave);
			// 
			// lblLocationOfAsset
			// 
			this.lblLocationOfAsset.AllowDrop = true;
			this.lblLocationOfAsset.BackColor = System.Drawing.SystemColors.Window;
			this.lblLocationOfAsset.Text = "Asset Location";
			this.lblLocationOfAsset.ForeColor = System.Drawing.Color.Black;
			this.lblLocationOfAsset.Location = new System.Drawing.Point(8, 80);
			// this.lblLocationOfAsset.mLabelId = 989;
			this.lblLocationOfAsset.Name = "lblLocationOfAsset";
			this.lblLocationOfAsset.Size = new System.Drawing.Size(73, 14);
			this.lblLocationOfAsset.TabIndex = 19;
			// 
			// _txtCommon_11
			// 
			this._txtCommon_11.AllowDrop = true;
			this._txtCommon_11.BackColor = System.Drawing.Color.White;
			// this._txtCommon_11.bolNumericOnly = true;
			this._txtCommon_11.ForeColor = System.Drawing.Color.Black;
			this._txtCommon_11.Location = new System.Drawing.Point(131, 77);
			this._txtCommon_11.MaxLength = 15;
			this._txtCommon_11.Name = "_txtCommon_11";
			// this._txtCommon_11.ShowButton = true;
			this._txtCommon_11.Size = new System.Drawing.Size(101, 19);
			this._txtCommon_11.TabIndex = 20;
			this._txtCommon_11.Text = "";
			// this.this._txtCommon_11.Watermark = "";
			// this.this._txtCommon_11.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommon_DropButtonClick);
			// this._txtCommon_11.Leave += new System.EventHandler(this.txtCommon_Leave);
			// 
			// System.Windows.Forms.Label3
			// 
			this.System.Windows.Forms.Label3.AllowDrop = true;
			this.System.Windows.Forms.Label3.BackColor = System.Drawing.SystemColors.Window;
			this.System.Windows.Forms.Label3.Caption = "Group Code";
			this.System.Windows.Forms.Label3.ForeColor = System.Drawing.Color.Black;
			this.System.Windows.Forms.Label3.Location = new System.Drawing.Point(8, 37);
			this.System.Windows.Forms.Label3.Name = "System.Windows.Forms.Label3";
			this.System.Windows.Forms.Label3.Size = new System.Drawing.Size(58, 14);
			this.System.Windows.Forms.Label3.TabIndex = 21;
			// 
			// _txtCommon_13
			// 
			this._txtCommon_13.AllowDrop = true;
			this._txtCommon_13.BackColor = System.Drawing.Color.White;
			// this._txtCommon_13.bolNumericOnly = true;
			this._txtCommon_13.ForeColor = System.Drawing.Color.Black;
			this._txtCommon_13.Location = new System.Drawing.Point(131, 35);
			this._txtCommon_13.MaxLength = 15;
			this._txtCommon_13.Name = "_txtCommon_13";
			// this._txtCommon_13.ShowButton = true;
			this._txtCommon_13.Size = new System.Drawing.Size(101, 19);
			this._txtCommon_13.TabIndex = 22;
			this._txtCommon_13.Text = "";
			// this.this._txtCommon_13.Watermark = "";
			// this.this._txtCommon_13.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommon_DropButtonClick);
			// this._txtCommon_13.Leave += new System.EventHandler(this.txtCommon_Leave);
			// 
			// _txtCommonDisplay_14
			// 
			this._txtCommonDisplay_14.AllowDrop = true;
			this._txtCommonDisplay_14.Location = new System.Drawing.Point(234, 35);
			this._txtCommonDisplay_14.Name = "_txtCommonDisplay_14";
			this._txtCommonDisplay_14.Size = new System.Drawing.Size(201, 19);
			this._txtCommonDisplay_14.TabIndex = 23;
			// 
			// _txtCommonDisplay_2
			// 
			this._txtCommonDisplay_2.AllowDrop = true;
			this._txtCommonDisplay_2.Location = new System.Drawing.Point(234, 56);
			this._txtCommonDisplay_2.Name = "_txtCommonDisplay_2";
			this._txtCommonDisplay_2.Size = new System.Drawing.Size(201, 19);
			this._txtCommonDisplay_2.TabIndex = 24;
			// 
			// _txtCommonDisplay_0
			// 
			this._txtCommonDisplay_0.AllowDrop = true;
			this._txtCommonDisplay_0.Location = new System.Drawing.Point(234, 14);
			this._txtCommonDisplay_0.Name = "_txtCommonDisplay_0";
			this._txtCommonDisplay_0.Size = new System.Drawing.Size(201, 19);
			this._txtCommonDisplay_0.TabIndex = 25;
			// 
			// _txtCommonDisplay_5
			// 
			this._txtCommonDisplay_5.AllowDrop = true;
			this._txtCommonDisplay_5.Location = new System.Drawing.Point(234, 77);
			this._txtCommonDisplay_5.Name = "_txtCommonDisplay_5";
			this._txtCommonDisplay_5.Size = new System.Drawing.Size(201, 19);
			this._txtCommonDisplay_5.TabIndex = 26;
			// 
			// _fraLedgerInformation_3
			// 
			this._fraLedgerInformation_3.AllowDrop = true;
			this._fraLedgerInformation_3.BackColor = System.Drawing.Color.White;
			this._fraLedgerInformation_3.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._fraLedgerInformation_3.Controls.Add(this.grdVoucherDetails);
			this._fraLedgerInformation_3.Controls.Add(this.cmbCommon);
			this._fraLedgerInformation_3.Enabled = true;
			this._fraLedgerInformation_3.ForeColor = System.Drawing.SystemColors.WindowText;
			this._fraLedgerInformation_3.Location = new System.Drawing.Point(654, 23);
			this._fraLedgerInformation_3.Name = "_fraLedgerInformation_3";
			this._fraLedgerInformation_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._fraLedgerInformation_3.Size = new System.Drawing.Size(591, 245);
			this._fraLedgerInformation_3.TabIndex = 1;
			this._fraLedgerInformation_3.Text = "Frame2";
			this._fraLedgerInformation_3.Visible = true;
			// 
			// grdVoucherDetails
			// 
			this.grdVoucherDetails.AllowDrop = true;
			this.grdVoucherDetails.BackColor = System.Drawing.Color.FromArgb(212, 208, 200);
			this.grdVoucherDetails.CellTipsWidth = 0;
			this.grdVoucherDetails.Location = new System.Drawing.Point(0, 12);
			this.grdVoucherDetails.Name = "grdVoucherDetails";
			this.grdVoucherDetails.RowDivider.Color = System.Drawing.Color.FromArgb(212, 208, 200);
			this.grdVoucherDetails.Size = new System.Drawing.Size(635, 233);
			this.grdVoucherDetails.TabIndex = 2;
			this.grdVoucherDetails.Columns.Add(this.Column_0_grdVoucherDetails);
			this.grdVoucherDetails.Columns.Add(this.Column_1_grdVoucherDetails);
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
			// cmbCommon
			// 
			this.cmbCommon.AllowDrop = true;
			this.cmbCommon.ColumnHeaders = true;
			this.cmbCommon.Enabled = true;
			this.cmbCommon.Location = new System.Drawing.Point(38, 74);
			this.cmbCommon.Name = "cmbCommon";
			this.cmbCommon.Size = new System.Drawing.Size(113, 33);
			this.cmbCommon.TabIndex = 3;
			this.cmbCommon.Columns.Add(this.Column_0_cmbCommon);
			this.cmbCommon.Columns.Add(this.Column_1_cmbCommon);
			// 
			// Column_0_cmbCommon
			// 
			this.Column_0_cmbCommon.DataField = "";
			this.Column_0_cmbCommon.ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.Normal;
			// 
			// Column_1_cmbCommon
			// 
			this.Column_1_cmbCommon.DataField = "";
			this.Column_1_cmbCommon.ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.Normal;
			// 
			// lblLLAssetName
			// 
			this.lblLLAssetName.AllowDrop = true;
			this.lblLLAssetName.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblLLAssetName.Text = "Asset Name  (English)";
			this.lblLLAssetName.ForeColor = System.Drawing.Color.Black;
			this.lblLLAssetName.Location = new System.Drawing.Point(256, 32);
			// this.lblLLAssetName.mLabelId = 982;
			this.lblLLAssetName.Name = "lblLLAssetName";
			this.lblLLAssetName.Size = new System.Drawing.Size(107, 14);
			this.lblLLAssetName.TabIndex = 72;
			// 
			// lblLAAssetName
			// 
			this.lblLAAssetName.AllowDrop = true;
			this.lblLAAssetName.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblLAAssetName.Text = "Asset Name  (Arabic)";
			this.lblLAAssetName.ForeColor = System.Drawing.Color.Black;
			this.lblLAAssetName.Location = new System.Drawing.Point(256, 53);
			// this.lblLAAssetName.mLabelId = 983;
			this.lblLAAssetName.Name = "lblLAAssetName";
			this.lblLAAssetName.Size = new System.Drawing.Size(105, 14);
			this.lblLAAssetName.TabIndex = 73;
			// 
			// lblAssetCode
			// 
			this.lblAssetCode.AllowDrop = true;
			this.lblAssetCode.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblAssetCode.Text = "Asset Code";
			this.lblAssetCode.ForeColor = System.Drawing.Color.Black;
			this.lblAssetCode.Location = new System.Drawing.Point(24, 32);
			// this.lblAssetCode.mLabelId = 981;
			this.lblAssetCode.Name = "lblAssetCode";
			this.lblAssetCode.Size = new System.Drawing.Size(57, 14);
			this.lblAssetCode.TabIndex = 74;
			// 
			// _txtCommon_1
			// 
			this._txtCommon_1.AllowDrop = true;
			this._txtCommon_1.BackColor = System.Drawing.Color.White;
			this._txtCommon_1.ForeColor = System.Drawing.Color.Black;
			this._txtCommon_1.Location = new System.Drawing.Point(390, 30);
			this._txtCommon_1.MaxLength = 50;
			this._txtCommon_1.Name = "_txtCommon_1";
			this._txtCommon_1.Size = new System.Drawing.Size(201, 19);
			this._txtCommon_1.TabIndex = 75;
			this._txtCommon_1.Tag = "Salesman Name in English";
			this._txtCommon_1.Text = "";
			// this.this._txtCommon_1.Watermark = "";
			// this.this._txtCommon_1.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommon_DropButtonClick);
			// this._txtCommon_1.Leave += new System.EventHandler(this.txtCommon_Leave);
			// 
			// _txtCommon_2
			// 
			this._txtCommon_2.AllowDrop = true;
			this._txtCommon_2.BackColor = System.Drawing.Color.White;
			this._txtCommon_2.ForeColor = System.Drawing.Color.Black;
			this._txtCommon_2.Location = new System.Drawing.Point(390, 51);
			// this._txtCommon_2.mArabicEnabled = true;
			this._txtCommon_2.MaxLength = 50;
			this._txtCommon_2.Name = "_txtCommon_2";
			this._txtCommon_2.Size = new System.Drawing.Size(201, 19);
			this._txtCommon_2.TabIndex = 76;
			this._txtCommon_2.Text = "";
			// this.this._txtCommon_2.Watermark = "";
			// this.this._txtCommon_2.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommon_DropButtonClick);
			// this._txtCommon_2.Leave += new System.EventHandler(this.txtCommon_Leave);
			// 
			// _txtCommon_0
			// 
			this._txtCommon_0.AllowDrop = true;
			this._txtCommon_0.BackColor = System.Drawing.Color.White;
			this._txtCommon_0.ForeColor = System.Drawing.Color.Black;
			this._txtCommon_0.Location = new System.Drawing.Point(102, 30);
			this._txtCommon_0.MaxLength = 20;
			// this._txtCommon_0.mDropDownType = System.Windows.Forms.TextBox.DropDownTypes.ddtNextNumber;
			this._txtCommon_0.Name = "_txtCommon_0";
			// this._txtCommon_0.ShowButton = true;
			this._txtCommon_0.Size = new System.Drawing.Size(101, 19);
			this._txtCommon_0.TabIndex = 77;
			this._txtCommon_0.Text = "";
			// this.this._txtCommon_0.Watermark = "";
			// this.this._txtCommon_0.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommon_DropButtonClick);
			// this._txtCommon_0.Leave += new System.EventHandler(this.txtCommon_Leave);
			// 
			// _lblCommon_3
			// 
			this._lblCommon_3.AllowDrop = true;
			this._lblCommon_3.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_3.Text = " Asset Information ";
			this._lblCommon_3.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_3.Location = new System.Drawing.Point(40, 82);
			// this._lblCommon_3.mLabelId = 887;
			this._lblCommon_3.Name = "_lblCommon_3";
			this._lblCommon_3.Size = new System.Drawing.Size(106, 14);
			this._lblCommon_3.TabIndex = 78;
			// 
			// _Line1_0
			// 
			this._Line1_0.AllowDrop = true;
			this._Line1_0.BackColor = System.Drawing.SystemColors.WindowText;
			this._Line1_0.Enabled = false;
			this._Line1_0.Location = new System.Drawing.Point(8, 90);
			this._Line1_0.Name = "_Line1_0";
			this._Line1_0.Size = new System.Drawing.Size(736, 1);
			this._Line1_0.Visible = true;
			// 
			// frmFAAssetMaster
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.ClientSize = new System.Drawing.Size(913, 565);
			this.Controls.Add(this.tabMaster);
			this.Controls.Add(this.lblLLAssetName);
			this.Controls.Add(this.lblLAAssetName);
			this.Controls.Add(this.lblAssetCode);
			this.Controls.Add(this._txtCommon_1);
			this.Controls.Add(this._txtCommon_2);
			this.Controls.Add(this._txtCommon_0);
			this.Controls.Add(this._lblCommon_3);
			this.Controls.Add(this._Line1_0);
			//this.Icon = (System.Drawing.Icon) resources.GetObject("frmFAAssetMaster.Icon");
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(253, 188);
			this.MaximizeBox = true;
			this.MinimizeBox = true;
			this.Name = "frmFAAssetMaster";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Asset Master";
			this.ToolTipMain.SetToolTip(this._txtCommon_1, "Salesman Name in English");
			// this.Activated += new System.EventHandler(this.frmFAAssetMaster_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
			// this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
			//((System.ComponentModel.ISupportInitialize) this.tabMaster).EndInit();
			this.tabMaster.ResumeLayout(false);
			this._fraLedgerInformation_1.ResumeLayout(false);
			this._fraLedgerInformation_0.ResumeLayout(false);
			this.Frame1.ResumeLayout(false);
			this._fraLedgerInformation_3.ResumeLayout(false);
			this.grdVoucherDetails.ResumeLayout(false);
			this.cmbCommon.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		void ReLoadForm(bool addEvents)
		{
			InitializetxtCommonNumber();
			InitializetxtCommonDisplay();
			InitializetxtCommon();
			InitializelblCommon();
			InitializefraLedgerInformation();
			InitializeLine1();
			//This form is an MDI child.
			//This code simulates the VB6 
			// functionality of automatically
			// loading and showing an MDI
			// child's parent.
			this.MdiParent = Xtreme.frmSysMain.DefInstance;
			Xtreme.frmSysMain.DefInstance.Show();
		}
		void InitializetxtCommonNumber()
		{
			this.txtCommonNumber = new System.Windows.Forms.TextBox[5];
			this.txtCommonNumber[0] = _txtCommonNumber_0;
			this.txtCommonNumber[1] = _txtCommonNumber_1;
			this.txtCommonNumber[4] = _txtCommonNumber_4;
			this.txtCommonNumber[2] = _txtCommonNumber_2;
			this.txtCommonNumber[3] = _txtCommonNumber_3;
		}
		void InitializetxtCommonDisplay()
		{
			this.txtCommonDisplay = new System.Windows.Forms.Label[15];
			this.txtCommonDisplay[13] = _txtCommonDisplay_13;
			this.txtCommonDisplay[3] = _txtCommonDisplay_3;
			this.txtCommonDisplay[8] = _txtCommonDisplay_8;
			this.txtCommonDisplay[6] = _txtCommonDisplay_6;
			this.txtCommonDisplay[7] = _txtCommonDisplay_7;
			this.txtCommonDisplay[9] = _txtCommonDisplay_9;
			this.txtCommonDisplay[10] = _txtCommonDisplay_10;
			this.txtCommonDisplay[11] = _txtCommonDisplay_11;
			this.txtCommonDisplay[1] = _txtCommonDisplay_1;
			this.txtCommonDisplay[4] = _txtCommonDisplay_4;
			this.txtCommonDisplay[12] = _txtCommonDisplay_12;
			this.txtCommonDisplay[14] = _txtCommonDisplay_14;
			this.txtCommonDisplay[2] = _txtCommonDisplay_2;
			this.txtCommonDisplay[0] = _txtCommonDisplay_0;
			this.txtCommonDisplay[5] = _txtCommonDisplay_5;
		}
		void InitializetxtCommon()
		{
			this.txtCommon = new System.Windows.Forms.TextBox[14];
			this.txtCommon[8] = _txtCommon_8;
			this.txtCommon[6] = _txtCommon_6;
			this.txtCommon[7] = _txtCommon_7;
			this.txtCommon[10] = _txtCommon_10;
			this.txtCommon[4] = _txtCommon_4;
			this.txtCommon[9] = _txtCommon_9;
			this.txtCommon[12] = _txtCommon_12;
			this.txtCommon[3] = _txtCommon_3;
			this.txtCommon[5] = _txtCommon_5;
			this.txtCommon[11] = _txtCommon_11;
			this.txtCommon[13] = _txtCommon_13;
			this.txtCommon[1] = _txtCommon_1;
			this.txtCommon[2] = _txtCommon_2;
			this.txtCommon[0] = _txtCommon_0;
		}
		void InitializelblCommon()
		{
			this.lblCommon = new System.Windows.Forms.Label[9];
			this.lblCommon[1] = _lblCommon_1;
			this.lblCommon[2] = _lblCommon_2;
			this.lblCommon[0] = _lblCommon_0;
			this.lblCommon[8] = _lblCommon_8;
			this.lblCommon[3] = _lblCommon_3;
		}
		void InitializefraLedgerInformation()
		{
			this.fraLedgerInformation = new System.Windows.Forms.Panel[4];
			this.fraLedgerInformation[1] = _fraLedgerInformation_1;
			this.fraLedgerInformation[0] = _fraLedgerInformation_0;
			this.fraLedgerInformation[3] = _fraLedgerInformation_3;
		}
		void InitializeLine1()
		{
			this.Line1 = new System.Windows.Forms.Label[4];
			this.Line1[1] = _Line1_1;
			this.Line1[2] = _Line1_2;
			this.Line1[3] = _Line1_3;
			this.Line1[0] = _Line1_0;
		}
		#endregion
	}
}