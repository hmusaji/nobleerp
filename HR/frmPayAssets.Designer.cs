
namespace Xtreme
{
	partial class frmPayAssets
	{

		#region "Upgrade Support "
		private static frmPayAssets m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmPayAssets DefInstance
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
		public static frmPayAssets CreateInstance()
		{
			frmPayAssets theInstance = new frmPayAssets();
			
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
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "txtSupplier", "txtComments", "_txtCommonNumber_0", "txtAssetTypeName", "txtAssetNo", "lblGroupNo", "lblLGroupName", "txtLAssetName", "lblAGroupName", "txtAAssetName", "System.Windows.Forms.Label1", "txtAssetTypeCode", "System.Windows.Forms.Label2", "System.Windows.Forms.Label3", "System.Windows.Forms.Label4", "_System.Windows.Forms.Label5_0", "System.Windows.Forms.Label6", "_txtCommonNumber_2", "_txtCommonNumber_3", "_txtCommonNumber_4", "_System.Windows.Forms.Label7_0", "_txtCommonNumber_1", "System.Windows.Forms.Label8", "txtDWarrantyEnd", "_System.Windows.Forms.Label7_1", "txtDPurchaseDate", "_System.Windows.Forms.Label5_1", "_System.Windows.Forms.Label5_2", "txtSpecification", "System.Windows.Forms.Label5", "System.Windows.Forms.Label7", "txtCommonNumber"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public System.Windows.Forms.TextBox txtSupplier;
		public System.Windows.Forms.TextBox txtComments;
		private System.Windows.Forms.TextBox _txtCommonNumber_0;
		public System.Windows.Forms.Label txtAssetTypeName;
		public System.Windows.Forms.TextBox txtAssetNo;
		public System.Windows.Forms.Label lblGroupNo;
		public System.Windows.Forms.Label lblLGroupName;
		public System.Windows.Forms.TextBox txtLAssetName;
		public System.Windows.Forms.Label lblAGroupName;
		public System.Windows.Forms.TextBox txtAAssetName;
		public System.Windows.Forms.Label System.Windows.Forms.Label1;
		public System.Windows.Forms.TextBox txtAssetTypeCode;
		public System.Windows.Forms.Label System.Windows.Forms.Label2;
		public System.Windows.Forms.Label System.Windows.Forms.Label3;
		public System.Windows.Forms.Label System.Windows.Forms.Label4;
		private System.Windows.Forms.Label _System.Windows.Forms.Label5_0;
		public System.Windows.Forms.Label System.Windows.Forms.Label6;
		private System.Windows.Forms.TextBox _txtCommonNumber_2;
		private System.Windows.Forms.TextBox _txtCommonNumber_3;
		private System.Windows.Forms.TextBox _txtCommonNumber_4;
		private System.Windows.Forms.Label _System.Windows.Forms.Label7_0;
		private System.Windows.Forms.TextBox _txtCommonNumber_1;
		public System.Windows.Forms.Label System.Windows.Forms.Label8;
		public Syncfusion.WinForms.Input.SfDateTimeEdit txtDWarrantyEnd;
		private System.Windows.Forms.Label _System.Windows.Forms.Label7_1;
		public Syncfusion.WinForms.Input.SfDateTimeEdit txtDPurchaseDate;
		private System.Windows.Forms.Label _System.Windows.Forms.Label5_1;
		private System.Windows.Forms.Label _System.Windows.Forms.Label5_2;
		public System.Windows.Forms.TextBox txtSpecification;
		public System.Windows.Forms.Label[] System.Windows.Forms.Label5 = new System.Windows.Forms.Label[3];
		public System.Windows.Forms.Label[] System.Windows.Forms.Label7 = new System.Windows.Forms.Label[2];
		public System.Windows.Forms.TextBox[] txtCommonNumber = new System.Windows.Forms.TextBox[5];
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPayAssets));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this.txtSupplier = new System.Windows.Forms.TextBox();
			this.txtComments = new System.Windows.Forms.TextBox();
			this._txtCommonNumber_0 = new System.Windows.Forms.TextBox();
			this.txtAssetTypeName = new System.Windows.Forms.Label();
			this.txtAssetNo = new System.Windows.Forms.TextBox();
			this.lblGroupNo = new System.Windows.Forms.Label();
			this.lblLGroupName = new System.Windows.Forms.Label();
			this.txtLAssetName = new System.Windows.Forms.TextBox();
			this.lblAGroupName = new System.Windows.Forms.Label();
			this.txtAAssetName = new System.Windows.Forms.TextBox();
			this.System.Windows.Forms.Label1 = new System.Windows.Forms.Label();
			this.txtAssetTypeCode = new System.Windows.Forms.TextBox();
			this.System.Windows.Forms.Label2 = new System.Windows.Forms.Label();
			this.System.Windows.Forms.Label3 = new System.Windows.Forms.Label();
			this.System.Windows.Forms.Label4 = new System.Windows.Forms.Label();
			this._System.Windows.Forms.Label5_0 = new System.Windows.Forms.Label();
			this.System.Windows.Forms.Label6 = new System.Windows.Forms.Label();
			this._txtCommonNumber_2 = new System.Windows.Forms.TextBox();
			this._txtCommonNumber_3 = new System.Windows.Forms.TextBox();
			this._txtCommonNumber_4 = new System.Windows.Forms.TextBox();
			this._System.Windows.Forms.Label7_0 = new System.Windows.Forms.Label();
			this._txtCommonNumber_1 = new System.Windows.Forms.TextBox();
			this.System.Windows.Forms.Label8 = new System.Windows.Forms.Label();
			this.txtDWarrantyEnd = new Syncfusion.WinForms.Input.SfDateTimeEdit();
			this._System.Windows.Forms.Label7_1 = new System.Windows.Forms.Label();
			this.txtDPurchaseDate = new Syncfusion.WinForms.Input.SfDateTimeEdit();
			this._System.Windows.Forms.Label5_1 = new System.Windows.Forms.Label();
			this._System.Windows.Forms.Label5_2 = new System.Windows.Forms.Label();
			this.txtSpecification = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// txtSupplier
			// 
			this.txtSupplier.AllowDrop = true;
			this.txtSupplier.BackColor = System.Drawing.Color.White;
			// this.txtSupplier.bolAllowDecimal = false;
			this.txtSupplier.ForeColor = System.Drawing.Color.Black;
			this.txtSupplier.Location = new System.Drawing.Point(135, 219);
			// this.txtSupplier.mDropDownType = (System.Windows.Forms.TextBox.DropDownTypes) 0;
			this.txtSupplier.Name = "txtSupplier";
			this.txtSupplier.Size = new System.Drawing.Size(367, 19);
			this.txtSupplier.TabIndex = 9;
			this.txtSupplier.Text = "";
			// 
			// txtComments
			// 
			this.txtComments.AllowDrop = true;
			this.txtComments.BackColor = System.Drawing.Color.White;
			// this.txtComments.bolAllowDecimal = false;
			this.txtComments.ForeColor = System.Drawing.Color.Black;
			this.txtComments.Location = new System.Drawing.Point(135, 261);
			// this.txtComments.mDropDownType = (System.Windows.Forms.TextBox.DropDownTypes) 0;
			this.txtComments.Name = "txtComments";
			this.txtComments.Size = new System.Drawing.Size(367, 43);
			this.txtComments.TabIndex = 11;
			this.txtComments.Text = "";
			// 
			// _txtCommonNumber_0
			// 
			this._txtCommonNumber_0.AllowDrop = true;
			// this._txtCommonNumber_0.DisplayFormat = "####0.000###;;0.000;0.000";
			this._txtCommonNumber_0.ForeColor = System.Drawing.SystemColors.WindowText;
			// this._txtCommonNumber_0.Format = "###########0.000";
			this._txtCommonNumber_0.Location = new System.Drawing.Point(136, 149);
			this._txtCommonNumber_0.Name = "_txtCommonNumber_0";
			this._txtCommonNumber_0.Size = new System.Drawing.Size(105, 19);
			this._txtCommonNumber_0.TabIndex = 6;
			this._txtCommonNumber_0.Text = "0.000";
			// 
			// txtAssetTypeName
			// 
			this.txtAssetTypeName.AllowDrop = true;
			this.txtAssetTypeName.BackColor = System.Drawing.SystemColors.Window;
			this.txtAssetTypeName.Enabled = false;
			this.txtAssetTypeName.Location = new System.Drawing.Point(239, 124);
			this.txtAssetTypeName.Name = "txtAssetTypeName";
			this.txtAssetTypeName.Size = new System.Drawing.Size(263, 19);
			this.txtAssetTypeName.TabIndex = 15;
			this.txtAssetTypeName.TabStop = false;
			// 
			// txtAssetNo
			// 
			this.txtAssetNo.AllowDrop = true;
			this.txtAssetNo.BackColor = System.Drawing.Color.White;
			this.txtAssetNo.ForeColor = System.Drawing.Color.Black;
			this.txtAssetNo.Location = new System.Drawing.Point(136, 60);
			this.txtAssetNo.MaxLength = 15;
			// this.txtAssetNo.mDropDownType = System.Windows.Forms.TextBox.DropDownTypes.ddtNextNumber;
			this.txtAssetNo.Name = "txtAssetNo";
			// this.txtAssetNo.ShowButton = true;
			this.txtAssetNo.Size = new System.Drawing.Size(103, 19);
			this.txtAssetNo.TabIndex = 1;
			this.txtAssetNo.Text = "";
			// 
			// lblGroupNo
			// 
			this.lblGroupNo.AllowDrop = true;
			this.lblGroupNo.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblGroupNo.Text = "Assets Code";
			this.lblGroupNo.Location = new System.Drawing.Point(7, 62);
			// this.lblGroupNo.mLabelId = 1284;
			this.lblGroupNo.Name = "lblGroupNo";
			this.lblGroupNo.Size = new System.Drawing.Size(63, 14);
			this.lblGroupNo.TabIndex = 0;
			// 
			// lblLGroupName
			// 
			this.lblLGroupName.AllowDrop = true;
			this.lblLGroupName.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblLGroupName.Text = "Asset Name (English)";
			this.lblLGroupName.Location = new System.Drawing.Point(7, 84);
			// this.lblLGroupName.mLabelId = 982;
			this.lblLGroupName.Name = "lblLGroupName";
			this.lblLGroupName.Size = new System.Drawing.Size(104, 14);
			this.lblLGroupName.TabIndex = 12;
			// 
			// txtLAssetName
			// 
			this.txtLAssetName.AllowDrop = true;
			this.txtLAssetName.BackColor = System.Drawing.Color.White;
			this.txtLAssetName.ForeColor = System.Drawing.Color.Black;
			this.txtLAssetName.Location = new System.Drawing.Point(135, 81);
			this.txtLAssetName.MaxLength = 50;
			this.txtLAssetName.Name = "txtLAssetName";
			this.txtLAssetName.Size = new System.Drawing.Size(367, 19);
			this.txtLAssetName.TabIndex = 3;
			this.txtLAssetName.Text = "";
			// 
			// lblAGroupName
			// 
			this.lblAGroupName.AllowDrop = true;
			this.lblAGroupName.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblAGroupName.Text = "Asset Name (Arabic)";
			this.lblAGroupName.Location = new System.Drawing.Point(7, 105);
			// this.lblAGroupName.mLabelId = 983;
			this.lblAGroupName.Name = "lblAGroupName";
			this.lblAGroupName.Size = new System.Drawing.Size(102, 14);
			this.lblAGroupName.TabIndex = 13;
			// 
			// txtAAssetName
			// 
			this.txtAAssetName.AllowDrop = true;
			this.txtAAssetName.BackColor = System.Drawing.Color.White;
			this.txtAAssetName.ForeColor = System.Drawing.Color.Black;
			this.txtAAssetName.Location = new System.Drawing.Point(135, 102);
			// this.txtAAssetName.mArabicEnabled = true;
			this.txtAAssetName.MaxLength = 50;
			this.txtAAssetName.Name = "txtAAssetName";
			this.txtAAssetName.Size = new System.Drawing.Size(367, 19);
			this.txtAAssetName.TabIndex = 4;
			this.txtAAssetName.Text = "";
			// 
			// System.Windows.Forms.Label1
			// 
			this.System.Windows.Forms.Label1.AllowDrop = true;
			this.System.Windows.Forms.Label1.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.System.Windows.Forms.Label1.Caption = "Asset Type Code";
			this.System.Windows.Forms.Label1.Location = new System.Drawing.Point(7, 126);
			this.System.Windows.Forms.Label1.mLabelId = 2105;
			this.System.Windows.Forms.Label1.Name = "System.Windows.Forms.Label1";
			this.System.Windows.Forms.Label1.Size = new System.Drawing.Size(84, 14);
			this.System.Windows.Forms.Label1.TabIndex = 14;
			// 
			// txtAssetTypeCode
			// 
			this.txtAssetTypeCode.AllowDrop = true;
			this.txtAssetTypeCode.BackColor = System.Drawing.Color.White;
			// this.txtAssetTypeCode.bolNumericOnly = true;
			this.txtAssetTypeCode.ForeColor = System.Drawing.Color.Black;
			this.txtAssetTypeCode.Location = new System.Drawing.Point(136, 124);
			this.txtAssetTypeCode.MaxLength = 15;
			// this.txtAssetTypeCode.mDropDownType = System.Windows.Forms.TextBox.DropDownTypes.ddtNextNumber;
			this.txtAssetTypeCode.Name = "txtAssetTypeCode";
			// this.txtAssetTypeCode.ShowButton = true;
			this.txtAssetTypeCode.Size = new System.Drawing.Size(101, 19);
			this.txtAssetTypeCode.TabIndex = 5;
			this.txtAssetTypeCode.Text = "";
			// this.this.txtAssetTypeCode.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtAssetTypeCode_DropButtonClick);
			// this.txtAssetTypeCode.Leave += new System.EventHandler(this.txtAssetTypeCode_Leave);
			// 
			// System.Windows.Forms.Label2
			// 
			this.System.Windows.Forms.Label2.AllowDrop = true;
			this.System.Windows.Forms.Label2.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.System.Windows.Forms.Label2.Caption = "Asset Value";
			this.System.Windows.Forms.Label2.Location = new System.Drawing.Point(7, 152);
			this.System.Windows.Forms.Label2.mLabelId = 2104;
			this.System.Windows.Forms.Label2.Name = "System.Windows.Forms.Label2";
			this.System.Windows.Forms.Label2.Size = new System.Drawing.Size(60, 14);
			this.System.Windows.Forms.Label2.TabIndex = 16;
			// 
			// System.Windows.Forms.Label3
			// 
			this.System.Windows.Forms.Label3.AllowDrop = true;
			this.System.Windows.Forms.Label3.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.System.Windows.Forms.Label3.Caption = "Asset Quantity";
			this.System.Windows.Forms.Label3.Location = new System.Drawing.Point(267, 152);
			this.System.Windows.Forms.Label3.mLabelId = 2109;
			this.System.Windows.Forms.Label3.Name = "System.Windows.Forms.Label3";
			this.System.Windows.Forms.Label3.Size = new System.Drawing.Size(72, 14);
			this.System.Windows.Forms.Label3.TabIndex = 17;
			// 
			// System.Windows.Forms.Label4
			// 
			this.System.Windows.Forms.Label4.AllowDrop = true;
			this.System.Windows.Forms.Label4.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.System.Windows.Forms.Label4.Caption = "Issued Quantity";
			this.System.Windows.Forms.Label4.Location = new System.Drawing.Point(7, 174);
			this.System.Windows.Forms.Label4.mLabelId = 2110;
			this.System.Windows.Forms.Label4.Name = "System.Windows.Forms.Label4";
			this.System.Windows.Forms.Label4.Size = new System.Drawing.Size(75, 14);
			this.System.Windows.Forms.Label4.TabIndex = 18;
			// 
			// _System.Windows.Forms.Label5_0
			// 
			this._System.Windows.Forms.Label5_0.AllowDrop = true;
			this._System.Windows.Forms.Label5_0.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._System.Windows.Forms.Label5_0.Caption = "Damage Quantity";
			this._System.Windows.Forms.Label5_0.Location = new System.Drawing.Point(7, 198);
			this._System.Windows.Forms.Label5_0.mLabelId = 2111;
			this._System.Windows.Forms.Label5_0.Name = "_System.Windows.Forms.Label5_0";
			this._System.Windows.Forms.Label5_0.Size = new System.Drawing.Size(82, 14);
			this._System.Windows.Forms.Label5_0.TabIndex = 19;
			// 
			// System.Windows.Forms.Label6
			// 
			this.System.Windows.Forms.Label6.AllowDrop = true;
			this.System.Windows.Forms.Label6.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.System.Windows.Forms.Label6.Caption = "Balance Quantity";
			this.System.Windows.Forms.Label6.Location = new System.Drawing.Point(267, 198);
			this.System.Windows.Forms.Label6.mLabelId = 2112;
			this.System.Windows.Forms.Label6.Name = "System.Windows.Forms.Label6";
			this.System.Windows.Forms.Label6.Size = new System.Drawing.Size(82, 14);
			this.System.Windows.Forms.Label6.TabIndex = 20;
			// 
			// _txtCommonNumber_2
			// 
			this._txtCommonNumber_2.AllowDrop = true;
			this._txtCommonNumber_2.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			this._txtCommonNumber_2.Enabled = false;
			this._txtCommonNumber_2.ForeColor = System.Drawing.SystemColors.WindowText;
			this._txtCommonNumber_2.Location = new System.Drawing.Point(136, 171);
			this._txtCommonNumber_2.Name = "_txtCommonNumber_2";
			this._txtCommonNumber_2.Size = new System.Drawing.Size(105, 19);
			this._txtCommonNumber_2.TabIndex = 21;
			this._txtCommonNumber_2.TabStop = false;
			// 
			// _txtCommonNumber_3
			// 
			this._txtCommonNumber_3.AllowDrop = true;
			this._txtCommonNumber_3.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			this._txtCommonNumber_3.Enabled = false;
			this._txtCommonNumber_3.ForeColor = System.Drawing.SystemColors.WindowText;
			this._txtCommonNumber_3.Location = new System.Drawing.Point(136, 195);
			this._txtCommonNumber_3.Name = "_txtCommonNumber_3";
			this._txtCommonNumber_3.Size = new System.Drawing.Size(105, 19);
			this._txtCommonNumber_3.TabIndex = 22;
			this._txtCommonNumber_3.TabStop = false;
			// 
			// _txtCommonNumber_4
			// 
			this._txtCommonNumber_4.AllowDrop = true;
			this._txtCommonNumber_4.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			this._txtCommonNumber_4.Enabled = false;
			this._txtCommonNumber_4.ForeColor = System.Drawing.SystemColors.WindowText;
			this._txtCommonNumber_4.Location = new System.Drawing.Point(385, 195);
			this._txtCommonNumber_4.Name = "_txtCommonNumber_4";
			this._txtCommonNumber_4.Size = new System.Drawing.Size(117, 19);
			this._txtCommonNumber_4.TabIndex = 23;
			this._txtCommonNumber_4.TabStop = false;
			// 
			// _System.Windows.Forms.Label7_0
			// 
			this._System.Windows.Forms.Label7_0.AllowDrop = true;
			this._System.Windows.Forms.Label7_0.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._System.Windows.Forms.Label7_0.Caption = "Warranty End";
			this._System.Windows.Forms.Label7_0.Location = new System.Drawing.Point(267, 173);
			this._System.Windows.Forms.Label7_0.mLabelId = 2176;
			this._System.Windows.Forms.Label7_0.Name = "_System.Windows.Forms.Label7_0";
			this._System.Windows.Forms.Label7_0.Size = new System.Drawing.Size(66, 14);
			this._System.Windows.Forms.Label7_0.TabIndex = 24;
			// 
			// _txtCommonNumber_1
			// 
			this._txtCommonNumber_1.AllowDrop = true;
			this._txtCommonNumber_1.ForeColor = System.Drawing.SystemColors.WindowText;
			// this._txtCommonNumber_1.Format = "###########0.000";
			this._txtCommonNumber_1.Location = new System.Drawing.Point(385, 149);
			this._txtCommonNumber_1.Name = "_txtCommonNumber_1";
			this._txtCommonNumber_1.Size = new System.Drawing.Size(117, 19);
			this._txtCommonNumber_1.TabIndex = 7;
			this._txtCommonNumber_1.Text = "0.000";
			// 
			// System.Windows.Forms.Label8
			// 
			this.System.Windows.Forms.Label8.AllowDrop = true;
			this.System.Windows.Forms.Label8.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.System.Windows.Forms.Label8.Caption = "Comments";
			this.System.Windows.Forms.Label8.Location = new System.Drawing.Point(7, 267);
			this.System.Windows.Forms.Label8.mLabelId = 1851;
			this.System.Windows.Forms.Label8.Name = "System.Windows.Forms.Label8";
			this.System.Windows.Forms.Label8.Size = new System.Drawing.Size(50, 14);
			this.System.Windows.Forms.Label8.TabIndex = 25;
			// 
			// txtDWarrantyEnd
			// 
			this.txtDWarrantyEnd.AllowDrop = true;
			// this.txtDWarrantyEnd.CheckDateRange = false;
			this.txtDWarrantyEnd.Location = new System.Drawing.Point(385, 171);
			// this.txtDWarrantyEnd.MaxDate = 2958465;
			// this.txtDWarrantyEnd.MinDate = 2;
			this.txtDWarrantyEnd.Name = "txtDWarrantyEnd";
			this.txtDWarrantyEnd.Size = new System.Drawing.Size(117, 19);
			this.txtDWarrantyEnd.TabIndex = 8;
			this.txtDWarrantyEnd.Text = "18/07/2001";
			this.txtDWarrantyEnd.Value = 37090;
			// 
			// _System.Windows.Forms.Label7_1
			// 
			this._System.Windows.Forms.Label7_1.AllowDrop = true;
			this._System.Windows.Forms.Label7_1.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._System.Windows.Forms.Label7_1.Caption = "Purchase Date";
			this._System.Windows.Forms.Label7_1.Location = new System.Drawing.Point(270, 62);
			this._System.Windows.Forms.Label7_1.mLabelId = 2178;
			this._System.Windows.Forms.Label7_1.Name = "_System.Windows.Forms.Label7_1";
			this._System.Windows.Forms.Label7_1.Size = new System.Drawing.Size(71, 14);
			this._System.Windows.Forms.Label7_1.TabIndex = 26;
			// 
			// txtDPurchaseDate
			// 
			this.txtDPurchaseDate.AllowDrop = true;
			// this.txtDPurchaseDate.CheckDateRange = false;
			this.txtDPurchaseDate.Location = new System.Drawing.Point(385, 60);
			// this.txtDPurchaseDate.MaxDate = 2958465;
			// this.txtDPurchaseDate.MinDate = 2;
			this.txtDPurchaseDate.Name = "txtDPurchaseDate";
			this.txtDPurchaseDate.Size = new System.Drawing.Size(117, 19);
			this.txtDPurchaseDate.TabIndex = 2;
			this.txtDPurchaseDate.Text = "18/07/2001";
			this.txtDPurchaseDate.Value = 37090;
			// 
			// _System.Windows.Forms.Label5_1
			// 
			this._System.Windows.Forms.Label5_1.AllowDrop = true;
			this._System.Windows.Forms.Label5_1.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._System.Windows.Forms.Label5_1.Caption = "Supplier";
			this._System.Windows.Forms.Label5_1.Location = new System.Drawing.Point(7, 222);
			this._System.Windows.Forms.Label5_1.mLabelId = 2177;
			this._System.Windows.Forms.Label5_1.Name = "_System.Windows.Forms.Label5_1";
			this._System.Windows.Forms.Label5_1.Size = new System.Drawing.Size(39, 14);
			this._System.Windows.Forms.Label5_1.TabIndex = 27;
			// 
			// _System.Windows.Forms.Label5_2
			// 
			this._System.Windows.Forms.Label5_2.AllowDrop = true;
			this._System.Windows.Forms.Label5_2.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._System.Windows.Forms.Label5_2.Caption = "Specification";
			this._System.Windows.Forms.Label5_2.Location = new System.Drawing.Point(7, 246);
			this._System.Windows.Forms.Label5_2.mLabelId = 2179;
			this._System.Windows.Forms.Label5_2.Name = "_System.Windows.Forms.Label5_2";
			this._System.Windows.Forms.Label5_2.Size = new System.Drawing.Size(62, 14);
			this._System.Windows.Forms.Label5_2.TabIndex = 28;
			// 
			// txtSpecification
			// 
			this.txtSpecification.AllowDrop = true;
			this.txtSpecification.BackColor = System.Drawing.Color.White;
			// this.txtSpecification.bolAllowDecimal = false;
			this.txtSpecification.ForeColor = System.Drawing.Color.Black;
			this.txtSpecification.Location = new System.Drawing.Point(135, 240);
			// this.txtSpecification.mDropDownType = (System.Windows.Forms.TextBox.DropDownTypes) 0;
			this.txtSpecification.Name = "txtSpecification";
			this.txtSpecification.Size = new System.Drawing.Size(367, 19);
			this.txtSpecification.TabIndex = 10;
			this.txtSpecification.Text = "";
			// 
			// frmPayAssets
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.ClientSize = new System.Drawing.Size(508, 316);
			this.Controls.Add(this.txtSupplier);
			this.Controls.Add(this.txtComments);
			this.Controls.Add(this._txtCommonNumber_0);
			this.Controls.Add(this.txtAssetTypeName);
			this.Controls.Add(this.txtAssetNo);
			this.Controls.Add(this.lblGroupNo);
			this.Controls.Add(this.lblLGroupName);
			this.Controls.Add(this.txtLAssetName);
			this.Controls.Add(this.lblAGroupName);
			this.Controls.Add(this.txtAAssetName);
			this.Controls.Add(this.System.Windows.Forms.Label1);
			this.Controls.Add(this.txtAssetTypeCode);
			this.Controls.Add(this.System.Windows.Forms.Label2);
			this.Controls.Add(this.System.Windows.Forms.Label3);
			this.Controls.Add(this.System.Windows.Forms.Label4);
			this.Controls.Add(this._System.Windows.Forms.Label5_0);
			this.Controls.Add(this.System.Windows.Forms.Label6);
			this.Controls.Add(this._txtCommonNumber_2);
			this.Controls.Add(this._txtCommonNumber_3);
			this.Controls.Add(this._txtCommonNumber_4);
			this.Controls.Add(this._System.Windows.Forms.Label7_0);
			this.Controls.Add(this._txtCommonNumber_1);
			this.Controls.Add(this.System.Windows.Forms.Label8);
			this.Controls.Add(this.txtDWarrantyEnd);
			this.Controls.Add(this._System.Windows.Forms.Label7_1);
			this.Controls.Add(this.txtDPurchaseDate);
			this.Controls.Add(this._System.Windows.Forms.Label5_1);
			this.Controls.Add(this._System.Windows.Forms.Label5_2);
			this.Controls.Add(this.txtSpecification);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			//this.Icon = (System.Drawing.Icon) resources.GetObject("frmPayAssets.Icon");
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(309, 100);
			this.MaximizeBox = true;
			this.MinimizeBox = true;
			this.Name = "frmPayAssets";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Asset";
			// this.Activated += new System.EventHandler(this.frmPayAssets_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
			// this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
			this.ResumeLayout(false);
		}
		void ReLoadForm(bool addEvents)
		{
			InitializetxtCommonNumber();
			InitializeSystem.Windows.Forms.Label7();
			InitializeSystem.Windows.Forms.Label5();
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
			this.txtCommonNumber[2] = _txtCommonNumber_2;
			this.txtCommonNumber[3] = _txtCommonNumber_3;
			this.txtCommonNumber[4] = _txtCommonNumber_4;
			this.txtCommonNumber[1] = _txtCommonNumber_1;
		}
		void InitializeSystem.Windows.Forms.Label7()
		{
			this.System.Windows.Forms.Label7 = new System.Windows.Forms.Label[2];
			this.System.Windows.Forms.Label7[0] = _System.Windows.Forms.Label7_0;
			this.System.Windows.Forms.Label7[1] = _System.Windows.Forms.Label7_1;
		}
		void InitializeSystem.Windows.Forms.Label5()
		{
			this.System.Windows.Forms.Label5 = new System.Windows.Forms.Label[3];
			this.System.Windows.Forms.Label5[0] = _System.Windows.Forms.Label5_0;
			this.System.Windows.Forms.Label5[1] = _System.Windows.Forms.Label5_1;
			this.System.Windows.Forms.Label5[2] = _System.Windows.Forms.Label5_2;
		}
		#endregion
	}
}