
namespace Xtreme
{
	partial class frmFAWritingofAssets
	{

		#region "Upgrade Support "
		private static frmFAWritingofAssets m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmFAWritingofAssets DefInstance
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
		public static frmFAWritingofAssets CreateInstance()
		{
			frmFAWritingofAssets theInstance = new frmFAWritingofAssets();
			
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
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "lblWriteofDate", "lblPurchaseDate", "lblLastDeprDate", "lblLastAdjDate", "lblInvoiceValueLC", "lblWriteofDeprAmount", "lblWriteofAmount", "lblLastWriteOffDate", "lblAccumDeptAmt", "lblSellingAmountFC", "lblComments", "lblAdjustmentValue", "lblWriteoffValue", "lblBookValue", "lblExchangeRate", "lblActualWriteoffAmt", "lblDepreciationAmt", "lblWriteofQuantity", "_txtCommonNumber_2", "_txtCommon_2", "_txtCommonNumber_3", "_txtCommonNumber_1", "lblCustomerAccountCode", "_txtCommonNumber_5", "_txtCommonNumber_6", "_txtCommonNumber_4", "_txtCommonNumber_0", "lblAssetCode", "_txtCommon_0", "txtWriteoffDate", "System.Windows.Forms.Label1", "_txtCommon_3", "_txtCommon_1", "System.Windows.Forms.Label2", "_txtCommonDisplay_11", "_txtCommonDisplay_10", "_txtCommonDisplay_9", "_txtCommonDisplay_8", "_txtCommonDisplay_7", "_txtCommonDisplay_6", "_txtCommonDisplay_5", "_txtCommonDisplay_4", "_txtCommonDisplay_3", "_txtCommonDisplay_2", "_txtCommonDisplay_1", "_txtCommonDisplay_0", "txtCommon", "txtCommonDisplay", "txtCommonNumber"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public System.Windows.Forms.Label lblWriteofDate;
		public System.Windows.Forms.Label lblPurchaseDate;
		public System.Windows.Forms.Label lblLastDeprDate;
		public System.Windows.Forms.Label lblLastAdjDate;
		public System.Windows.Forms.Label lblInvoiceValueLC;
		public System.Windows.Forms.Label lblWriteofDeprAmount;
		public System.Windows.Forms.Label lblWriteofAmount;
		public System.Windows.Forms.Label lblLastWriteOffDate;
		public System.Windows.Forms.Label lblAccumDeptAmt;
		public System.Windows.Forms.Label lblSellingAmountFC;
		public System.Windows.Forms.Label lblComments;
		public System.Windows.Forms.Label lblAdjustmentValue;
		public System.Windows.Forms.Label lblWriteoffValue;
		public System.Windows.Forms.Label lblBookValue;
		public System.Windows.Forms.Label lblExchangeRate;
		public System.Windows.Forms.Label lblActualWriteoffAmt;
		public System.Windows.Forms.Label lblDepreciationAmt;
		public System.Windows.Forms.Label lblWriteofQuantity;
		private System.Windows.Forms.TextBox _txtCommonNumber_2;
		private System.Windows.Forms.TextBox _txtCommon_2;
		private System.Windows.Forms.TextBox _txtCommonNumber_3;
		private System.Windows.Forms.TextBox _txtCommonNumber_1;
		public System.Windows.Forms.Label lblCustomerAccountCode;
		private System.Windows.Forms.TextBox _txtCommonNumber_5;
		private System.Windows.Forms.TextBox _txtCommonNumber_6;
		private System.Windows.Forms.TextBox _txtCommonNumber_4;
		private System.Windows.Forms.TextBox _txtCommonNumber_0;
		public System.Windows.Forms.Label lblAssetCode;
		private System.Windows.Forms.TextBox _txtCommon_0;
		public Syncfusion.WinForms.Input.SfDateTimeEdit txtWriteoffDate;
		public System.Windows.Forms.Label Label1;
		private System.Windows.Forms.TextBox _txtCommon_3;
		private System.Windows.Forms.TextBox _txtCommon_1;
		public System.Windows.Forms.Label Label2;
		private System.Windows.Forms.Label _txtCommonDisplay_11;
		private System.Windows.Forms.Label _txtCommonDisplay_10;
		private System.Windows.Forms.Label _txtCommonDisplay_9;
		private System.Windows.Forms.Label _txtCommonDisplay_8;
		private System.Windows.Forms.Label _txtCommonDisplay_7;
		private System.Windows.Forms.Label _txtCommonDisplay_6;
		private System.Windows.Forms.Label _txtCommonDisplay_5;
		private System.Windows.Forms.Label _txtCommonDisplay_4;
		private System.Windows.Forms.Label _txtCommonDisplay_3;
		private System.Windows.Forms.Label _txtCommonDisplay_2;
		private System.Windows.Forms.Label _txtCommonDisplay_1;
		private System.Windows.Forms.Label _txtCommonDisplay_0;
		public System.Windows.Forms.TextBox[] txtCommon = new System.Windows.Forms.TextBox[4];
		public System.Windows.Forms.Label[] txtCommonDisplay = new System.Windows.Forms.Label[12];
		public System.Windows.Forms.TextBox[] txtCommonNumber = new System.Windows.Forms.TextBox[7];
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFAWritingofAssets));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this.lblWriteofDate = new System.Windows.Forms.Label();
			this.lblPurchaseDate = new System.Windows.Forms.Label();
			this.lblLastDeprDate = new System.Windows.Forms.Label();
			this.lblLastAdjDate = new System.Windows.Forms.Label();
			this.lblInvoiceValueLC = new System.Windows.Forms.Label();
			this.lblWriteofDeprAmount = new System.Windows.Forms.Label();
			this.lblWriteofAmount = new System.Windows.Forms.Label();
			this.lblLastWriteOffDate = new System.Windows.Forms.Label();
			this.lblAccumDeptAmt = new System.Windows.Forms.Label();
			this.lblSellingAmountFC = new System.Windows.Forms.Label();
			this.lblComments = new System.Windows.Forms.Label();
			// this.lblAdjustmentValue = new System.Windows.Forms.Label();
			// this.lblWriteoffValue = new System.Windows.Forms.Label();
			// this.lblBookValue = new System.Windows.Forms.Label();
			this.lblExchangeRate = new System.Windows.Forms.Label();
			this.lblActualWriteoffAmt = new System.Windows.Forms.Label();
			this.lblDepreciationAmt = new System.Windows.Forms.Label();
			this.lblWriteofQuantity = new System.Windows.Forms.Label();
			this._txtCommonNumber_2 = new System.Windows.Forms.TextBox();
			this._txtCommon_2 = new System.Windows.Forms.TextBox();
			this._txtCommonNumber_3 = new System.Windows.Forms.TextBox();
			this._txtCommonNumber_1 = new System.Windows.Forms.TextBox();
			this.lblCustomerAccountCode = new System.Windows.Forms.Label();
			this._txtCommonNumber_5 = new System.Windows.Forms.TextBox();
			this._txtCommonNumber_6 = new System.Windows.Forms.TextBox();
			this._txtCommonNumber_4 = new System.Windows.Forms.TextBox();
			this._txtCommonNumber_0 = new System.Windows.Forms.TextBox();
			this.lblAssetCode = new System.Windows.Forms.Label();
			this._txtCommon_0 = new System.Windows.Forms.TextBox();
			this.txtWriteoffDate = new Syncfusion.WinForms.Input.SfDateTimeEdit();
			this.Label1 = new System.Windows.Forms.Label();
			this._txtCommon_3 = new System.Windows.Forms.TextBox();
			this._txtCommon_1 = new System.Windows.Forms.TextBox();
			this.Label2 = new System.Windows.Forms.Label();
			this._txtCommonDisplay_11 = new System.Windows.Forms.Label();
			this._txtCommonDisplay_10 = new System.Windows.Forms.Label();
			this._txtCommonDisplay_9 = new System.Windows.Forms.Label();
			this._txtCommonDisplay_8 = new System.Windows.Forms.Label();
			this._txtCommonDisplay_7 = new System.Windows.Forms.Label();
			this._txtCommonDisplay_6 = new System.Windows.Forms.Label();
			this._txtCommonDisplay_5 = new System.Windows.Forms.Label();
			this._txtCommonDisplay_4 = new System.Windows.Forms.Label();
			this._txtCommonDisplay_3 = new System.Windows.Forms.Label();
			this._txtCommonDisplay_2 = new System.Windows.Forms.Label();
			this._txtCommonDisplay_1 = new System.Windows.Forms.Label();
			this._txtCommonDisplay_0 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// lblWriteofDate
			// 
			this.lblWriteofDate.AllowDrop = true;
			this.lblWriteofDate.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			// this.lblWriteofDate.Text = "Writeoff Date";
			this.lblWriteofDate.ForeColor = System.Drawing.Color.Black;
			this.lblWriteofDate.Location = new System.Drawing.Point(12, 212);
			// // this.lblWriteofDate.mLabelId = 1007;
			this.lblWriteofDate.Name = "lblWriteofDate";
			this.lblWriteofDate.Size = new System.Drawing.Size(64, 14);
			this.lblWriteofDate.TabIndex = 12;
			// 
			// lblPurchaseDate
			// 
			this.lblPurchaseDate.AllowDrop = true;
			this.lblPurchaseDate.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			// this.lblPurchaseDate.Text = "Purchase Date";
			this.lblPurchaseDate.ForeColor = System.Drawing.Color.Black;
			this.lblPurchaseDate.Location = new System.Drawing.Point(12, 87);
			// // this.lblPurchaseDate.mLabelId = 994;
			this.lblPurchaseDate.Name = "lblPurchaseDate";
			this.lblPurchaseDate.Size = new System.Drawing.Size(71, 14);
			this.lblPurchaseDate.TabIndex = 13;
			// 
			// lblLastDeprDate
			// 
			this.lblLastDeprDate.AllowDrop = true;
			this.lblLastDeprDate.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			// this.lblLastDeprDate.Text = "Last Depr. Date";
			this.lblLastDeprDate.ForeColor = System.Drawing.Color.Black;
			this.lblLastDeprDate.Location = new System.Drawing.Point(12, 109);
			// // this.lblLastDeprDate.mLabelId = 1006;
			this.lblLastDeprDate.Name = "lblLastDeprDate";
			this.lblLastDeprDate.Size = new System.Drawing.Size(75, 14);
			this.lblLastDeprDate.TabIndex = 14;
			// 
			// lblLastAdjDate
			// 
			this.lblLastAdjDate.AllowDrop = true;
			this.lblLastAdjDate.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			// this.lblLastAdjDate.Text = "Last Adj. Date";
			this.lblLastAdjDate.ForeColor = System.Drawing.Color.Black;
			this.lblLastAdjDate.Location = new System.Drawing.Point(12, 131);
			// // this.lblLastAdjDate.mLabelId = 1009;
			this.lblLastAdjDate.Name = "lblLastAdjDate";
			this.lblLastAdjDate.Size = new System.Drawing.Size(68, 14);
			this.lblLastAdjDate.TabIndex = 15;
			// 
			// lblInvoiceValueLC
			// 
			this.lblInvoiceValueLC.AllowDrop = true;
			this.lblInvoiceValueLC.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblInvoiceValueLC.Text = "Invoice Amount";
			this.lblInvoiceValueLC.ForeColor = System.Drawing.Color.Black;
			this.lblInvoiceValueLC.Location = new System.Drawing.Point(288, 87);
			// // this.lblInvoiceValueLC.mLabelId = 995;
			this.lblInvoiceValueLC.Name = "lblInvoiceValueLC";
			this.lblInvoiceValueLC.Size = new System.Drawing.Size(74, 14);
			this.lblInvoiceValueLC.TabIndex = 16;
			// 
			// lblWriteofDeprAmount
			// 
			this.lblWriteofDeprAmount.AllowDrop = true;
			this.lblWriteofDeprAmount.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblWriteofDeprAmount.Text = "Writeoff Depr.  Amount";
			this.lblWriteofDeprAmount.ForeColor = System.Drawing.Color.Black;
			this.lblWriteofDeprAmount.Location = new System.Drawing.Point(12, 256);
			// // this.lblWriteofDeprAmount.mLabelId = 1032;
			this.lblWriteofDeprAmount.Name = "lblWriteofDeprAmount";
			this.lblWriteofDeprAmount.Size = new System.Drawing.Size(111, 14);
			this.lblWriteofDeprAmount.TabIndex = 17;
			// 
			// lblWriteofAmount
			// 
			this.lblWriteofAmount.AllowDrop = true;
			this.lblWriteofAmount.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblWriteofAmount.Text = "Writeoff Amount";
			this.lblWriteofAmount.ForeColor = System.Drawing.Color.Black;
			this.lblWriteofAmount.Location = new System.Drawing.Point(12, 234);
			// // this.lblWriteofAmount.mLabelId = 1031;
			this.lblWriteofAmount.Name = "lblWriteofAmount";
			this.lblWriteofAmount.Size = new System.Drawing.Size(79, 14);
			this.lblWriteofAmount.TabIndex = 18;
			// 
			// lblLastWriteOffDate
			// 
			this.lblLastWriteOffDate.AllowDrop = true;
			this.lblLastWriteOffDate.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			// this.lblLastWriteOffDate.Text = "Last Writeoff Date";
			this.lblLastWriteOffDate.ForeColor = System.Drawing.Color.Black;
			this.lblLastWriteOffDate.Location = new System.Drawing.Point(12, 153);
			// // this.lblLastWriteOffDate.mLabelId = 1007;
			this.lblLastWriteOffDate.Name = "lblLastWriteOffDate";
			this.lblLastWriteOffDate.Size = new System.Drawing.Size(88, 14);
			this.lblLastWriteOffDate.TabIndex = 19;
			// 
			// lblAccumDeptAmt
			// 
			this.lblAccumDeptAmt.AllowDrop = true;
			this.lblAccumDeptAmt.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblAccumDeptAmt.Text = "Accum Depr Amt";
			this.lblAccumDeptAmt.ForeColor = System.Drawing.Color.Black;
			this.lblAccumDeptAmt.Location = new System.Drawing.Point(288, 109);
			// // this.lblAccumDeptAmt.mLabelId = 1035;
			this.lblAccumDeptAmt.Name = "lblAccumDeptAmt";
			this.lblAccumDeptAmt.Size = new System.Drawing.Size(82, 14);
			this.lblAccumDeptAmt.TabIndex = 20;
			// 
			// lblSellingAmountFC
			// 
			this.lblSellingAmountFC.AllowDrop = true;
			this.lblSellingAmountFC.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblSellingAmountFC.Text = "Selling Amount";
			this.lblSellingAmountFC.ForeColor = System.Drawing.Color.Black;
			this.lblSellingAmountFC.Location = new System.Drawing.Point(12, 300);
			// // this.lblSellingAmountFC.mLabelId = 1034;
			this.lblSellingAmountFC.Name = "lblSellingAmountFC";
			this.lblSellingAmountFC.Size = new System.Drawing.Size(71, 14);
			this.lblSellingAmountFC.TabIndex = 21;
			// 
			// lblComments
			// 
			this.lblComments.AllowDrop = true;
			this.lblComments.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblComments.Text = "Comments";
			this.lblComments.ForeColor = System.Drawing.Color.Black;
			this.lblComments.Location = new System.Drawing.Point(12, 322);
			// // this.lblComments.mLabelId = 135;
			this.lblComments.Name = "lblComments";
			this.lblComments.Size = new System.Drawing.Size(50, 14);
			this.lblComments.TabIndex = 22;
			// 
			// lblAdjustmentValue
			// 
			this.lblAdjustmentValue.AllowDrop = true;
			this.lblAdjustmentValue.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblAdjustmentValue.Text = "Adjustment Amount";
			this.lblAdjustmentValue.ForeColor = System.Drawing.Color.Black;
			this.lblAdjustmentValue.Location = new System.Drawing.Point(288, 131);
			// // this.lblAdjustmentValue.mLabelId = 1016;
			this.lblAdjustmentValue.Name = "lblAdjustmentValue";
			this.lblAdjustmentValue.Size = new System.Drawing.Size(94, 14);
			this.lblAdjustmentValue.TabIndex = 23;
			// 
			// lblWriteoffValue
			// 
			this.lblWriteoffValue.AllowDrop = true;
			this.lblWriteoffValue.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblWriteoffValue.Text = "Writeoff Amount";
			this.lblWriteoffValue.ForeColor = System.Drawing.Color.Black;
			this.lblWriteoffValue.Location = new System.Drawing.Point(288, 153);
			// // this.lblWriteoffValue.mLabelId = 1031;
			this.lblWriteoffValue.Name = "lblWriteoffValue";
			this.lblWriteoffValue.Size = new System.Drawing.Size(79, 14);
			this.lblWriteoffValue.TabIndex = 24;
			// 
			// lblBookValue
			// 
			this.lblBookValue.AllowDrop = true;
			this.lblBookValue.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblBookValue.Text = "Book Value";
			this.lblBookValue.ForeColor = System.Drawing.Color.Black;
			this.lblBookValue.Location = new System.Drawing.Point(288, 175);
			// // this.lblBookValue.mLabelId = 1036;
			this.lblBookValue.Name = "lblBookValue";
			this.lblBookValue.Size = new System.Drawing.Size(55, 14);
			this.lblBookValue.TabIndex = 25;
			// 
			// lblExchangeRate
			// 
			this.lblExchangeRate.AllowDrop = true;
			this.lblExchangeRate.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			// this.lblExchangeRate.Text = "Exchange Rate";
			this.lblExchangeRate.ForeColor = System.Drawing.Color.Black;
			this.lblExchangeRate.Location = new System.Drawing.Point(288, 300);
			// // this.lblExchangeRate.mLabelId = 260;
			this.lblExchangeRate.Name = "lblExchangeRate";
			this.lblExchangeRate.Size = new System.Drawing.Size(73, 14);
			this.lblExchangeRate.TabIndex = 26;
			// 
			// lblActualWriteoffAmt
			// 
			this.lblActualWriteoffAmt.AllowDrop = true;
			this.lblActualWriteoffAmt.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblActualWriteoffAmt.Text = "Actual Writeoff Amt";
			this.lblActualWriteoffAmt.ForeColor = System.Drawing.Color.Black;
			this.lblActualWriteoffAmt.Location = new System.Drawing.Point(288, 256);
			// // this.lblActualWriteoffAmt.mLabelId = 1039;
			this.lblActualWriteoffAmt.Name = "lblActualWriteoffAmt";
			this.lblActualWriteoffAmt.Size = new System.Drawing.Size(95, 14);
			this.lblActualWriteoffAmt.TabIndex = 27;
			// 
			// lblDepreciationAmt
			// 
			this.lblDepreciationAmt.AllowDrop = true;
			this.lblDepreciationAmt.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblDepreciationAmt.Text = "Depreciation Amt";
			this.lblDepreciationAmt.ForeColor = System.Drawing.Color.Black;
			this.lblDepreciationAmt.Location = new System.Drawing.Point(288, 234);
			// // this.lblDepreciationAmt.mLabelId = 1038;
			this.lblDepreciationAmt.Name = "lblDepreciationAmt";
			this.lblDepreciationAmt.Size = new System.Drawing.Size(82, 14);
			this.lblDepreciationAmt.TabIndex = 28;
			// 
			// lblWriteofQuantity
			// 
			this.lblWriteofQuantity.AllowDrop = true;
			this.lblWriteofQuantity.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblWriteofQuantity.Text = "Writeoff Quantity";
			this.lblWriteofQuantity.ForeColor = System.Drawing.Color.Black;
			this.lblWriteofQuantity.Location = new System.Drawing.Point(288, 212);
			// // this.lblWriteofQuantity.mLabelId = 1037;
			this.lblWriteofQuantity.Name = "lblWriteofQuantity";
			this.lblWriteofQuantity.Size = new System.Drawing.Size(82, 14);
			this.lblWriteofQuantity.TabIndex = 29;
			// 
			// _txtCommonNumber_2
			// 
			this._txtCommonNumber_2.AllowDrop = true;
			this._txtCommonNumber_2.BackColor = System.Drawing.Color.FromArgb(239, 239, 239);
			// this._txtCommonNumber_2.DisplayFormat = "########0.000###;;0.000;0.000";
			this._txtCommonNumber_2.Enabled = false;
			// this._txtCommonNumber_2.Format = "###########0.000";
			this._txtCommonNumber_2.Location = new System.Drawing.Point(131, 254);
			// this._txtCommonNumber_2.MaxValue = 2147483647;
			// this._txtCommonNumber_2.MinValue = 0;
			this._txtCommonNumber_2.Name = "_txtCommonNumber_2";
			this._txtCommonNumber_2.Size = new System.Drawing.Size(101, 19);
			this._txtCommonNumber_2.TabIndex = 6;
			this._txtCommonNumber_2.Text = "0.000";
			// this._txtCommonNumber_2.Leave += new System.EventHandler(this.txtCommonNumber_Leave);
			this._txtCommonNumber_2.Validated += new System.EventHandler(this.txtCommonNumber_Validated);
			this._txtCommonNumber_2.Validating += new System.ComponentModel.CancelEventHandler(this.txtCommonNumber_Validating);
			// 
			// _txtCommon_2
			// 
			this._txtCommon_2.AllowDrop = true;
			this._txtCommon_2.BackColor = System.Drawing.Color.White;
			this._txtCommon_2.ForeColor = System.Drawing.Color.Black;
			this._txtCommon_2.Location = new System.Drawing.Point(131, 320);
			this._txtCommon_2.MaxLength = 10;
			this._txtCommon_2.Name = "_txtCommon_2";
			this._txtCommon_2.Size = new System.Drawing.Size(357, 19);
			this._txtCommon_2.TabIndex = 11;
			this._txtCommon_2.Text = "";
			// this.this._txtCommon_2.Watermark = "";
			// this.this._txtCommon_2.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommon_DropButtonClick);
			// this._txtCommon_2.Leave += new System.EventHandler(this.txtCommon_Leave);
			// 
			// _txtCommonNumber_3
			// 
			this._txtCommonNumber_3.AllowDrop = true;
			// this._txtCommonNumber_3.DisplayFormat = "########0.000###;;0.000;0.000";
			// this._txtCommonNumber_3.Format = "###########0.000";
			this._txtCommonNumber_3.Location = new System.Drawing.Point(131, 298);
			// this._txtCommonNumber_3.MaxValue = 2147483647;
			// this._txtCommonNumber_3.MinValue = 0;
			this._txtCommonNumber_3.Name = "_txtCommonNumber_3";
			this._txtCommonNumber_3.Size = new System.Drawing.Size(101, 19);
			this._txtCommonNumber_3.TabIndex = 9;
			this._txtCommonNumber_3.Text = "0.000";
			// this._txtCommonNumber_3.Leave += new System.EventHandler(this.txtCommonNumber_Leave);
			this._txtCommonNumber_3.Validated += new System.EventHandler(this.txtCommonNumber_Validated);
			this._txtCommonNumber_3.Validating += new System.ComponentModel.CancelEventHandler(this.txtCommonNumber_Validating);
			// 
			// _txtCommonNumber_1
			// 
			this._txtCommonNumber_1.AllowDrop = true;
			// this._txtCommonNumber_1.DisplayFormat = "########0.000###;;0.000;0.000";
			this._txtCommonNumber_1.Enabled = false;
			// this._txtCommonNumber_1.Format = "###########0.000";
			this._txtCommonNumber_1.Location = new System.Drawing.Point(131, 232);
			// this._txtCommonNumber_1.MaxValue = 2147483647;
			// this._txtCommonNumber_1.MinValue = 0;
			this._txtCommonNumber_1.Name = "_txtCommonNumber_1";
			this._txtCommonNumber_1.Size = new System.Drawing.Size(101, 19);
			this._txtCommonNumber_1.TabIndex = 4;
			this._txtCommonNumber_1.Text = "0.000";
			// this._txtCommonNumber_1.Leave += new System.EventHandler(this.txtCommonNumber_Leave);
			this._txtCommonNumber_1.Validated += new System.EventHandler(this.txtCommonNumber_Validated);
			this._txtCommonNumber_1.Validating += new System.ComponentModel.CancelEventHandler(this.txtCommonNumber_Validating);
			// 
			// lblCustomerAccountCode
			// 
			this.lblCustomerAccountCode.AllowDrop = true;
			this.lblCustomerAccountCode.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblCustomerAccountCode.Text = "Customer Account Code";
			this.lblCustomerAccountCode.ForeColor = System.Drawing.Color.Black;
			this.lblCustomerAccountCode.Location = new System.Drawing.Point(12, 278);
			// // this.lblCustomerAccountCode.mLabelId = 1033;
			this.lblCustomerAccountCode.Name = "lblCustomerAccountCode";
			this.lblCustomerAccountCode.Size = new System.Drawing.Size(118, 14);
			this.lblCustomerAccountCode.TabIndex = 30;
			// 
			// _txtCommonNumber_5
			// 
			this._txtCommonNumber_5.AllowDrop = true;
			this._txtCommonNumber_5.BackColor = System.Drawing.Color.FromArgb(239, 239, 239);
			// this._txtCommonNumber_5.DisplayFormat = "########0.000###;;0.000;0.000";
			this._txtCommonNumber_5.Enabled = false;
			// this._txtCommonNumber_5.Format = "###########0.000";
			this._txtCommonNumber_5.Location = new System.Drawing.Point(387, 254);
			// this._txtCommonNumber_5.MaxValue = 2147483647;
			// this._txtCommonNumber_5.MinValue = 0;
			this._txtCommonNumber_5.Name = "_txtCommonNumber_5";
			this._txtCommonNumber_5.Size = new System.Drawing.Size(101, 19);
			this._txtCommonNumber_5.TabIndex = 7;
			this._txtCommonNumber_5.Text = "0.000";
			// this._txtCommonNumber_5.Leave += new System.EventHandler(this.txtCommonNumber_Leave);
			this._txtCommonNumber_5.Validated += new System.EventHandler(this.txtCommonNumber_Validated);
			this._txtCommonNumber_5.Validating += new System.ComponentModel.CancelEventHandler(this.txtCommonNumber_Validating);
			// 
			// _txtCommonNumber_6
			// 
			this._txtCommonNumber_6.AllowDrop = true;
			// this._txtCommonNumber_6.DisplayFormat = "########0.000###;;0.000;0.000";
			this._txtCommonNumber_6.Enabled = false;
			// this._txtCommonNumber_6.Format = "###########0.000";
			this._txtCommonNumber_6.Location = new System.Drawing.Point(387, 298);
			// this._txtCommonNumber_6.MaxValue = 2147483647;
			// this._txtCommonNumber_6.MinValue = 0;
			this._txtCommonNumber_6.Name = "_txtCommonNumber_6";
			this._txtCommonNumber_6.Size = new System.Drawing.Size(101, 19);
			this._txtCommonNumber_6.TabIndex = 10;
			this._txtCommonNumber_6.Text = "0.000";
			// this._txtCommonNumber_6.Leave += new System.EventHandler(this.txtCommonNumber_Leave);
			this._txtCommonNumber_6.Validated += new System.EventHandler(this.txtCommonNumber_Validated);
			this._txtCommonNumber_6.Validating += new System.ComponentModel.CancelEventHandler(this.txtCommonNumber_Validating);
			// 
			// _txtCommonNumber_4
			// 
			this._txtCommonNumber_4.AllowDrop = true;
			this._txtCommonNumber_4.BackColor = System.Drawing.Color.FromArgb(239, 239, 239);
			// this._txtCommonNumber_4.DisplayFormat = "########0.000###;;0.000;0.000";
			this._txtCommonNumber_4.Enabled = false;
			// this._txtCommonNumber_4.Format = "###########0.000";
			this._txtCommonNumber_4.Location = new System.Drawing.Point(387, 232);
			// this._txtCommonNumber_4.MaxValue = 2147483647;
			// this._txtCommonNumber_4.MinValue = 0;
			this._txtCommonNumber_4.Name = "_txtCommonNumber_4";
			this._txtCommonNumber_4.Size = new System.Drawing.Size(101, 19);
			this._txtCommonNumber_4.TabIndex = 5;
			this._txtCommonNumber_4.Text = "0.000";
			// this._txtCommonNumber_4.Leave += new System.EventHandler(this.txtCommonNumber_Leave);
			this._txtCommonNumber_4.Validated += new System.EventHandler(this.txtCommonNumber_Validated);
			this._txtCommonNumber_4.Validating += new System.ComponentModel.CancelEventHandler(this.txtCommonNumber_Validating);
			// 
			// _txtCommonNumber_0
			// 
			this._txtCommonNumber_0.AllowDrop = true;
			this._txtCommonNumber_0.Enabled = false;
			this._txtCommonNumber_0.Location = new System.Drawing.Point(387, 210);
			// this._txtCommonNumber_0.MaxValue = 2147483647;
			// this._txtCommonNumber_0.MinValue = 0;
			this._txtCommonNumber_0.Name = "_txtCommonNumber_0";
			this._txtCommonNumber_0.Size = new System.Drawing.Size(101, 19);
			this._txtCommonNumber_0.TabIndex = 3;
			// this._txtCommonNumber_0.Leave += new System.EventHandler(this.txtCommonNumber_Leave);
			this._txtCommonNumber_0.Validated += new System.EventHandler(this.txtCommonNumber_Validated);
			this._txtCommonNumber_0.Validating += new System.ComponentModel.CancelEventHandler(this.txtCommonNumber_Validating);
			// 
			// lblAssetCode
			// 
			this.lblAssetCode.AllowDrop = true;
			this.lblAssetCode.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblAssetCode.Text = "Asset Code";
			this.lblAssetCode.ForeColor = System.Drawing.Color.Black;
			this.lblAssetCode.Location = new System.Drawing.Point(12, 65);
			// // this.lblAssetCode.mLabelId = 981;
			this.lblAssetCode.Name = "lblAssetCode";
			this.lblAssetCode.Size = new System.Drawing.Size(57, 14);
			this.lblAssetCode.TabIndex = 31;
			// 
			// _txtCommon_0
			// 
			this._txtCommon_0.AllowDrop = true;
			this._txtCommon_0.BackColor = System.Drawing.Color.White;
			this._txtCommon_0.ForeColor = System.Drawing.Color.Black;
			this._txtCommon_0.Location = new System.Drawing.Point(131, 64);
			this._txtCommon_0.MaxLength = 15;
			this._txtCommon_0.Name = "_txtCommon_0";
			// this._txtCommon_0.ShowButton = true;
			this._txtCommon_0.Size = new System.Drawing.Size(101, 19);
			this._txtCommon_0.TabIndex = 1;
			this._txtCommon_0.Text = "";
			// this.this._txtCommon_0.Watermark = "";
			// this.this._txtCommon_0.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommon_DropButtonClick);
			// this._txtCommon_0.Leave += new System.EventHandler(this.txtCommon_Leave);
			// 
			// txtWriteoffDate
			// 
			this.txtWriteoffDate.AllowDrop = true;
			this.txtWriteoffDate.BackColor = System.Drawing.Color.FromArgb(239, 239, 239);
			// this.txtWriteoffDate.CheckDateRange = false;
			this.txtWriteoffDate.Enabled = false;
			this.txtWriteoffDate.Location = new System.Drawing.Point(131, 210);
			// this.txtWriteoffDate.MaxDate = 2958465;
			// this.txtWriteoffDate.MinDate = 2;
			this.txtWriteoffDate.Name = "txtWriteoffDate";
			this.txtWriteoffDate.Size = new System.Drawing.Size(101, 19);
			this.txtWriteoffDate.TabIndex = 2;
			// this.txtWriteoffDate.Text = "15/03/2014";
			this.txtWriteoffDate.Validating += new System.ComponentModel.CancelEventHandler(this.txtWriteoffDate_Validating);
			// 
			// System.Windows.Forms.Label1
			// 
			this.Label1.AllowDrop = true;
			this.Label1.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.Label1.Text = "Transaction No";
			this.Label1.ForeColor = System.Drawing.Color.Black;
			this.Label1.Location = new System.Drawing.Point(12, 44);
			// this.Label1.mLabelId = 1022;
			this.Label1.Name = "System.Windows.Forms.Label1";
			this.Label1.Size = new System.Drawing.Size(73, 14);
			this.Label1.TabIndex = 32;
			// 
			// _txtCommon_3
			// 
			this._txtCommon_3.AllowDrop = true;
			this._txtCommon_3.BackColor = System.Drawing.Color.FromArgb(239, 239, 239);
			this._txtCommon_3.Enabled = false;
			this._txtCommon_3.ForeColor = System.Drawing.Color.Black;
			this._txtCommon_3.Location = new System.Drawing.Point(131, 42);
			this._txtCommon_3.MaxLength = 15;
			this._txtCommon_3.Name = "_txtCommon_3";
			this._txtCommon_3.Size = new System.Drawing.Size(101, 19);
			this._txtCommon_3.TabIndex = 0;
			this._txtCommon_3.Text = "";
			// this.this._txtCommon_3.Watermark = "";
			// this.this._txtCommon_3.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommon_DropButtonClick);
			// this._txtCommon_3.Leave += new System.EventHandler(this.txtCommon_Leave);
			// 
			// _txtCommon_1
			// 
			this._txtCommon_1.AllowDrop = true;
			this._txtCommon_1.BackColor = System.Drawing.Color.White;
			this._txtCommon_1.ForeColor = System.Drawing.Color.Black;
			this._txtCommon_1.Location = new System.Drawing.Point(131, 276);
			this._txtCommon_1.MaxLength = 15;
			this._txtCommon_1.Name = "_txtCommon_1";
			// this._txtCommon_1.ShowButton = true;
			this._txtCommon_1.Size = new System.Drawing.Size(101, 19);
			this._txtCommon_1.TabIndex = 8;
			this._txtCommon_1.Text = "";
			// this.this._txtCommon_1.Watermark = "";
			// this.this._txtCommon_1.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommon_DropButtonClick);
			// this._txtCommon_1.Leave += new System.EventHandler(this.txtCommon_Leave);
			// 
			// System.Windows.Forms.Label2
			// 
			this.Label2.AllowDrop = true;
			this.Label2.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.Label2.Text = "Current Asset Value";
			this.Label2.ForeColor = System.Drawing.Color.Black;
			this.Label2.Location = new System.Drawing.Point(12, 176);
			// this.Label2.mLabelId = 1030;
			this.Label2.Name = "System.Windows.Forms.Label2";
			this.Label2.Size = new System.Drawing.Size(99, 14);
			this.Label2.TabIndex = 33;
			// 
			// _txtCommonDisplay_11
			// 
			// this._txtCommonDisplay_11.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
			this._txtCommonDisplay_11.AllowDrop = true;
			this._txtCommonDisplay_11.Location = new System.Drawing.Point(131, 174);
			this._txtCommonDisplay_11.Name = "_txtCommonDisplay_11";
			this._txtCommonDisplay_11.Size = new System.Drawing.Size(101, 19);
			this._txtCommonDisplay_11.TabIndex = 34;
			// 
			// _txtCommonDisplay_10
			// 
			this._txtCommonDisplay_10.AllowDrop = true;
			this._txtCommonDisplay_10.Location = new System.Drawing.Point(235, 276);
			this._txtCommonDisplay_10.Name = "_txtCommonDisplay_10";
			this._txtCommonDisplay_10.Size = new System.Drawing.Size(254, 19);
			this._txtCommonDisplay_10.TabIndex = 35;
			// 
			// _txtCommonDisplay_9
			// 
			// this._txtCommonDisplay_9.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
			this._txtCommonDisplay_9.AllowDrop = true;
			this._txtCommonDisplay_9.Location = new System.Drawing.Point(388, 173);
			this._txtCommonDisplay_9.Name = "_txtCommonDisplay_9";
			this._txtCommonDisplay_9.Size = new System.Drawing.Size(101, 19);
			this._txtCommonDisplay_9.TabIndex = 36;
			// 
			// _txtCommonDisplay_8
			// 
			// this._txtCommonDisplay_8.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
			this._txtCommonDisplay_8.AllowDrop = true;
			this._txtCommonDisplay_8.Location = new System.Drawing.Point(388, 151);
			this._txtCommonDisplay_8.Name = "_txtCommonDisplay_8";
			this._txtCommonDisplay_8.Size = new System.Drawing.Size(101, 19);
			this._txtCommonDisplay_8.TabIndex = 37;
			// 
			// _txtCommonDisplay_7
			// 
			// this._txtCommonDisplay_7.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
			this._txtCommonDisplay_7.AllowDrop = true;
			this._txtCommonDisplay_7.Location = new System.Drawing.Point(388, 129);
			this._txtCommonDisplay_7.Name = "_txtCommonDisplay_7";
			this._txtCommonDisplay_7.Size = new System.Drawing.Size(101, 19);
			this._txtCommonDisplay_7.TabIndex = 38;
			// 
			// _txtCommonDisplay_6
			// 
			// this._txtCommonDisplay_6.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
			this._txtCommonDisplay_6.AllowDrop = true;
			this._txtCommonDisplay_6.Location = new System.Drawing.Point(388, 107);
			this._txtCommonDisplay_6.Name = "_txtCommonDisplay_6";
			this._txtCommonDisplay_6.Size = new System.Drawing.Size(101, 19);
			this._txtCommonDisplay_6.TabIndex = 39;
			// 
			// _txtCommonDisplay_5
			// 
			// this._txtCommonDisplay_5.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
			this._txtCommonDisplay_5.AllowDrop = true;
			this._txtCommonDisplay_5.Location = new System.Drawing.Point(388, 85);
			this._txtCommonDisplay_5.Name = "_txtCommonDisplay_5";
			this._txtCommonDisplay_5.Size = new System.Drawing.Size(101, 19);
			this._txtCommonDisplay_5.TabIndex = 40;
			// 
			// _txtCommonDisplay_4
			// 
			// this._txtCommonDisplay_4.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
			this._txtCommonDisplay_4.AllowDrop = true;
			this._txtCommonDisplay_4.Location = new System.Drawing.Point(131, 151);
			this._txtCommonDisplay_4.Name = "_txtCommonDisplay_4";
			this._txtCommonDisplay_4.Size = new System.Drawing.Size(101, 19);
			this._txtCommonDisplay_4.TabIndex = 41;
			// 
			// _txtCommonDisplay_3
			// 
			// this._txtCommonDisplay_3.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
			this._txtCommonDisplay_3.AllowDrop = true;
			this._txtCommonDisplay_3.Location = new System.Drawing.Point(131, 129);
			this._txtCommonDisplay_3.Name = "_txtCommonDisplay_3";
			this._txtCommonDisplay_3.Size = new System.Drawing.Size(101, 19);
			this._txtCommonDisplay_3.TabIndex = 42;
			// 
			// _txtCommonDisplay_2
			// 
			// this._txtCommonDisplay_2.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
			this._txtCommonDisplay_2.AllowDrop = true;
			this._txtCommonDisplay_2.Location = new System.Drawing.Point(131, 107);
			this._txtCommonDisplay_2.Name = "_txtCommonDisplay_2";
			this._txtCommonDisplay_2.Size = new System.Drawing.Size(101, 19);
			this._txtCommonDisplay_2.TabIndex = 43;
			// 
			// _txtCommonDisplay_1
			// 
			// this._txtCommonDisplay_1.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
			this._txtCommonDisplay_1.AllowDrop = true;
			this._txtCommonDisplay_1.Location = new System.Drawing.Point(131, 85);
			this._txtCommonDisplay_1.Name = "_txtCommonDisplay_1";
			this._txtCommonDisplay_1.Size = new System.Drawing.Size(101, 19);
			this._txtCommonDisplay_1.TabIndex = 44;
			// 
			// _txtCommonDisplay_0
			// 
			this._txtCommonDisplay_0.AllowDrop = true;
			this._txtCommonDisplay_0.Location = new System.Drawing.Point(235, 63);
			this._txtCommonDisplay_0.Name = "_txtCommonDisplay_0";
			this._txtCommonDisplay_0.Size = new System.Drawing.Size(254, 19);
			this._txtCommonDisplay_0.TabIndex = 45;
			// 
			// frmFAWritingofAssets
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.ClientSize = new System.Drawing.Size(511, 388);
			this.Controls.Add(this.lblWriteofDate);
			this.Controls.Add(this.lblPurchaseDate);
			this.Controls.Add(this.lblLastDeprDate);
			this.Controls.Add(this.lblLastAdjDate);
			this.Controls.Add(this.lblInvoiceValueLC);
			this.Controls.Add(this.lblWriteofDeprAmount);
			this.Controls.Add(this.lblWriteofAmount);
			this.Controls.Add(this.lblLastWriteOffDate);
			this.Controls.Add(this.lblAccumDeptAmt);
			this.Controls.Add(this.lblSellingAmountFC);
			this.Controls.Add(this.lblComments);
			this.Controls.Add(this.lblAdjustmentValue);
			this.Controls.Add(this.lblWriteoffValue);
			this.Controls.Add(this.lblBookValue);
			this.Controls.Add(this.lblExchangeRate);
			this.Controls.Add(this.lblActualWriteoffAmt);
			this.Controls.Add(this.lblDepreciationAmt);
			this.Controls.Add(this.lblWriteofQuantity);
			this.Controls.Add(this._txtCommonNumber_2);
			this.Controls.Add(this._txtCommon_2);
			this.Controls.Add(this._txtCommonNumber_3);
			this.Controls.Add(this._txtCommonNumber_1);
			this.Controls.Add(this.lblCustomerAccountCode);
			this.Controls.Add(this._txtCommonNumber_5);
			this.Controls.Add(this._txtCommonNumber_6);
			this.Controls.Add(this._txtCommonNumber_4);
			this.Controls.Add(this._txtCommonNumber_0);
			this.Controls.Add(this.lblAssetCode);
			this.Controls.Add(this._txtCommon_0);
			this.Controls.Add(this.txtWriteoffDate);
			this.Controls.Add(this.Label1);
			this.Controls.Add(this._txtCommon_3);
			this.Controls.Add(this._txtCommon_1);
			this.Controls.Add(this.Label2);
			this.Controls.Add(this._txtCommonDisplay_11);
			this.Controls.Add(this._txtCommonDisplay_10);
			this.Controls.Add(this._txtCommonDisplay_9);
			this.Controls.Add(this._txtCommonDisplay_8);
			this.Controls.Add(this._txtCommonDisplay_7);
			this.Controls.Add(this._txtCommonDisplay_6);
			this.Controls.Add(this._txtCommonDisplay_5);
			this.Controls.Add(this._txtCommonDisplay_4);
			this.Controls.Add(this._txtCommonDisplay_3);
			this.Controls.Add(this._txtCommonDisplay_2);
			this.Controls.Add(this._txtCommonDisplay_1);
			this.Controls.Add(this._txtCommonDisplay_0);
			//this.Icon = (System.Drawing.Icon) resources.GetObject("frmFAWritingofAssets.Icon");
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(634, 295);
			this.MaximizeBox = true;
			this.MinimizeBox = true;
			this.Name = "frmFAWritingofAssets";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Writeoff Assets";
			// this.Activated += new System.EventHandler(this.frmFAWritingofAssets_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
			// this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
			this.ResumeLayout(false);
		}
		// 
		void InitializetxtCommonNumber()
		{
			this.txtCommonNumber = new System.Windows.Forms.TextBox[7];
			this.txtCommonNumber[2] = _txtCommonNumber_2;
			this.txtCommonNumber[3] = _txtCommonNumber_3;
			this.txtCommonNumber[1] = _txtCommonNumber_1;
			this.txtCommonNumber[5] = _txtCommonNumber_5;
			this.txtCommonNumber[6] = _txtCommonNumber_6;
			this.txtCommonNumber[4] = _txtCommonNumber_4;
			this.txtCommonNumber[0] = _txtCommonNumber_0;
		}
		void InitializetxtCommonDisplay()
		{
			this.txtCommonDisplay = new System.Windows.Forms.Label[12];
			this.txtCommonDisplay[11] = _txtCommonDisplay_11;
			this.txtCommonDisplay[10] = _txtCommonDisplay_10;
			this.txtCommonDisplay[9] = _txtCommonDisplay_9;
			this.txtCommonDisplay[8] = _txtCommonDisplay_8;
			this.txtCommonDisplay[7] = _txtCommonDisplay_7;
			this.txtCommonDisplay[6] = _txtCommonDisplay_6;
			this.txtCommonDisplay[5] = _txtCommonDisplay_5;
			this.txtCommonDisplay[4] = _txtCommonDisplay_4;
			this.txtCommonDisplay[3] = _txtCommonDisplay_3;
			this.txtCommonDisplay[2] = _txtCommonDisplay_2;
			this.txtCommonDisplay[1] = _txtCommonDisplay_1;
			this.txtCommonDisplay[0] = _txtCommonDisplay_0;
		}
		void InitializetxtCommon()
		{
			this.txtCommon = new System.Windows.Forms.TextBox[4];
			this.txtCommon[2] = _txtCommon_2;
			this.txtCommon[0] = _txtCommon_0;
			this.txtCommon[3] = _txtCommon_3;
			this.txtCommon[1] = _txtCommon_1;
		}
		#endregion
	}
}//ENDSHERE
