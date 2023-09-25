
namespace Xtreme
{
	partial class frmICSLocation
	{

		#region "Upgrade Support "
		private static frmICSLocation m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmICSLocation DefInstance
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
		public static frmICSLocation CreateInstance()
		{
			frmICSLocation theInstance = new frmICSLocation();
			
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
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "chkCashType", "lblDefaultLdgrCode", "lblDefaultCashCode", "lblDefaultLdgrName", "lblDefaultCashName", "lblDefaultTransType", "txtDefaultLdgrNo", "txtDefaultCashCode", "txtDataUploadPath", "lblDataUploadPath", "lblDefaultSalesmanCode", "txtDefaultSalesmanNo", "lblDefaultsalesmanName", "_fraMasterInformation_2", "Column_0_grdVoucherDetails", "Column_1_grdVoucherDetails", "grdVoucherDetails", "Column_0_cmbCommon", "Column_1_cmbCommon", "cmbCommon", "_fraMasterInformation_1", "chkCheckNegativeStock", "txtComment", "System.Windows.Forms.Label2", "System.Windows.Forms.Label3", "txtLShortName", "txtAShortName", "lblAddr_1", "lblPhone", "lblComments", "txtAdd1", "lblMobile", "txtPhone", "txtContactPerson", "System.Windows.Forms.Label1", "txtAdd3", "lblAddr_2", "txtAdd2", "_fraMasterInformation_0", "tabMaster", "_lblCommon_3", "lblLSmanName", "lblASmanName", "txtLocationNo", "txtLLocationName", "txtALocationName", "lblSmanNo", "Line1", "cntOuterFrame", "fraMasterInformation", "lblCommon"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public System.Windows.Forms.CheckBox chkCashType;
		public System.Windows.Forms.Label lblDefaultLdgrCode;
		public System.Windows.Forms.Label lblDefaultCashCode;
		public System.Windows.Forms.TextBox lblDefaultLdgrName;
		public System.Windows.Forms.TextBox lblDefaultCashName;
		public System.Windows.Forms.Label lblDefaultTransType;
		public System.Windows.Forms.TextBox txtDefaultLdgrNo;
		public System.Windows.Forms.TextBox txtDefaultCashCode;
		public System.Windows.Forms.TextBox txtDataUploadPath;
		public System.Windows.Forms.Label lblDataUploadPath;
		public System.Windows.Forms.Label lblDefaultSalesmanCode;
		public System.Windows.Forms.TextBox txtDefaultSalesmanNo;
		public System.Windows.Forms.TextBox lblDefaultsalesmanName;
		private System.Windows.Forms.Panel _fraMasterInformation_2;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_0_grdVoucherDetails;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_1_grdVoucherDetails;
		public C1.Win.C1TrueDBGrid.C1TrueDBGrid grdVoucherDetails;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_0_cmbCommon;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_1_cmbCommon;
		public C1.Win.C1TrueDBGrid.C1TrueDBDropdown cmbCommon;
		private System.Windows.Forms.Panel _fraMasterInformation_1;
		public System.Windows.Forms.CheckBox chkCheckNegativeStock;
		public System.Windows.Forms.TextBox txtComment;
		public System.Windows.Forms.Label Label2;
		public System.Windows.Forms.Label Label3;
		public System.Windows.Forms.TextBox txtLShortName;
		public System.Windows.Forms.TextBox txtAShortName;
		public System.Windows.Forms.Label lblAddr_1;
		public System.Windows.Forms.Label lblPhone;
		public System.Windows.Forms.Label lblComments;
		public System.Windows.Forms.TextBox txtAdd1;
		public System.Windows.Forms.Label lblMobile;
		public System.Windows.Forms.TextBox txtPhone;
		public System.Windows.Forms.TextBox txtContactPerson;
		public System.Windows.Forms.Label Label1;
		public System.Windows.Forms.TextBox txtAdd3;
		public System.Windows.Forms.Label lblAddr_2;
		public System.Windows.Forms.TextBox txtAdd2;
		private System.Windows.Forms.Panel _fraMasterInformation_0;
		public AxC1SizerLib.AxC1Tab tabMaster;
		private System.Windows.Forms.Label _lblCommon_3;
		public System.Windows.Forms.Label lblLSmanName;
		public System.Windows.Forms.Label lblASmanName;
		public System.Windows.Forms.TextBox txtLocationNo;
		public System.Windows.Forms.TextBox txtLLocationName;
		public System.Windows.Forms.TextBox txtALocationName;
		public System.Windows.Forms.Label lblSmanNo;
		public System.Windows.Forms.Label Line1;
		public AxC1SizerLib.AxC1Elastic cntOuterFrame;
		public System.Windows.Forms.Panel[] fraMasterInformation = new System.Windows.Forms.Panel[3];
		public System.Windows.Forms.Label[] lblCommon = new System.Windows.Forms.Label[4];
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmICSLocation));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this.cntOuterFrame = new AxC1SizerLib.AxC1Elastic();
			this.tabMaster = new AxC1SizerLib.AxC1Tab();
			this._fraMasterInformation_2 = new System.Windows.Forms.Panel();
			this.chkCashType = new System.Windows.Forms.CheckBox();
			this.lblDefaultLdgrCode = new System.Windows.Forms.Label();
			this.lblDefaultCashCode = new System.Windows.Forms.Label();
			this.lblDefaultLdgrName = new System.Windows.Forms.TextBox();
			this.lblDefaultCashName = new System.Windows.Forms.TextBox();
			this.lblDefaultTransType = new System.Windows.Forms.Label();
			this.txtDefaultLdgrNo = new System.Windows.Forms.TextBox();
			this.txtDefaultCashCode = new System.Windows.Forms.TextBox();
			this.txtDataUploadPath = new System.Windows.Forms.TextBox();
			this.lblDataUploadPath = new System.Windows.Forms.Label();
			this.lblDefaultSalesmanCode = new System.Windows.Forms.Label();
			this.txtDefaultSalesmanNo = new System.Windows.Forms.TextBox();
			this.lblDefaultsalesmanName = new System.Windows.Forms.TextBox();
			this._fraMasterInformation_1 = new System.Windows.Forms.Panel();
			this.grdVoucherDetails = new C1.Win.C1TrueDBGrid.C1TrueDBGrid();
			this.Column_0_grdVoucherDetails = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.Column_1_grdVoucherDetails = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.cmbCommon = new C1.Win.C1TrueDBGrid.C1TrueDBDropdown();
			this.Column_0_cmbCommon = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.Column_1_cmbCommon = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this._fraMasterInformation_0 = new System.Windows.Forms.Panel();
			this.chkCheckNegativeStock = new System.Windows.Forms.CheckBox();
			this.txtComment = new System.Windows.Forms.TextBox();
			this.Label2 = new System.Windows.Forms.Label();
			this.Label3 = new System.Windows.Forms.Label();
			this.txtLShortName = new System.Windows.Forms.TextBox();
			this.txtAShortName = new System.Windows.Forms.TextBox();
			this.lblAddr_1 = new System.Windows.Forms.Label();
			this.lblPhone = new System.Windows.Forms.Label();
			this.lblComments = new System.Windows.Forms.Label();
			this.txtAdd1 = new System.Windows.Forms.TextBox();
			this.lblMobile = new System.Windows.Forms.Label();
			this.txtPhone = new System.Windows.Forms.TextBox();
			this.txtContactPerson = new System.Windows.Forms.TextBox();
			this.Label1 = new System.Windows.Forms.Label();
			this.txtAdd3 = new System.Windows.Forms.TextBox();
			this.lblAddr_2 = new System.Windows.Forms.Label();
			this.txtAdd2 = new System.Windows.Forms.TextBox();
			this._lblCommon_3 = new System.Windows.Forms.Label();
			this.lblLSmanName = new System.Windows.Forms.Label();
			this.lblASmanName = new System.Windows.Forms.Label();
			this.txtLocationNo = new System.Windows.Forms.TextBox();
			this.txtLLocationName = new System.Windows.Forms.TextBox();
			this.txtALocationName = new System.Windows.Forms.TextBox();
			this.lblSmanNo = new System.Windows.Forms.Label();
			this.Line1 = new System.Windows.Forms.Label();
			// //((System.ComponentModel.ISupportInitialize) this.tabMaster).BeginInit();
			// //((System.ComponentModel.ISupportInitialize) this.cntOuterFrame).BeginInit();
			this.cntOuterFrame.SuspendLayout();
			this.tabMaster.SuspendLayout();
			this._fraMasterInformation_2.SuspendLayout();
			this._fraMasterInformation_1.SuspendLayout();
			this.grdVoucherDetails.SuspendLayout();
			this.cmbCommon.SuspendLayout();
			this._fraMasterInformation_0.SuspendLayout();
			this.SuspendLayout();
			// 
			// cntOuterFrame
			// 
			this.cntOuterFrame.Align = C1SizerLib.AlignSettings.asNone;
			this.cntOuterFrame.AllowDrop = true;
			this.cntOuterFrame.Controls.Add(this.tabMaster);
			this.cntOuterFrame.Controls.Add(this._lblCommon_3);
			this.cntOuterFrame.Controls.Add(this.lblLSmanName);
			this.cntOuterFrame.Controls.Add(this.lblASmanName);
			this.cntOuterFrame.Controls.Add(this.txtLocationNo);
			this.cntOuterFrame.Controls.Add(this.txtLLocationName);
			this.cntOuterFrame.Controls.Add(this.txtALocationName);
			this.cntOuterFrame.Controls.Add(this.lblSmanNo);
			this.cntOuterFrame.Controls.Add(this.Line1);
			this.cntOuterFrame.Location = new System.Drawing.Point(0, 0);
			this.cntOuterFrame.Name = "cntOuterFrame";
			("cntOuterFrame.OcxState");
			this.cntOuterFrame.Size = new System.Drawing.Size(651, 343);
			this.cntOuterFrame.TabIndex = 12;
			this.cntOuterFrame.TabStop = false;
			// 
			// tabMaster
			// 
			this.tabMaster.Align = C1SizerLib.AlignSettings.asNone;
			this.tabMaster.AllowDrop = true;
			this.tabMaster.Controls.Add(this._fraMasterInformation_2);
			this.tabMaster.Controls.Add(this._fraMasterInformation_1);
			this.tabMaster.Controls.Add(this._fraMasterInformation_0);
			this.tabMaster.Location = new System.Drawing.Point(6, 94);
			this.tabMaster.Name = "tabMaster";
			("tabMaster.OcxState");
			this.tabMaster.Size = new System.Drawing.Size(634, 233);
			this.tabMaster.TabIndex = 13;
			this.tabMaster.TabStop = false;
			this.tabMaster.Switch += new AxC1SizerLib._C1TabEvents_SwitchEventHandler(this.tabMaster_Switch);
			// 
			// _fraMasterInformation_2
			// 
			this._fraMasterInformation_2.AllowDrop = true;
			this._fraMasterInformation_2.BackColor = System.Drawing.Color.FromArgb(213, 213, 213);
			this._fraMasterInformation_2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._fraMasterInformation_2.Controls.Add(this.chkCashType);
			this._fraMasterInformation_2.Controls.Add(this.lblDefaultLdgrCode);
			this._fraMasterInformation_2.Controls.Add(this.lblDefaultCashCode);
			this._fraMasterInformation_2.Controls.Add(this.lblDefaultLdgrName);
			this._fraMasterInformation_2.Controls.Add(this.lblDefaultCashName);
			this._fraMasterInformation_2.Controls.Add(this.lblDefaultTransType);
			this._fraMasterInformation_2.Controls.Add(this.txtDefaultLdgrNo);
			this._fraMasterInformation_2.Controls.Add(this.txtDefaultCashCode);
			this._fraMasterInformation_2.Controls.Add(this.txtDataUploadPath);
			this._fraMasterInformation_2.Controls.Add(this.lblDataUploadPath);
			this._fraMasterInformation_2.Controls.Add(this.lblDefaultSalesmanCode);
			this._fraMasterInformation_2.Controls.Add(this.txtDefaultSalesmanNo);
			this._fraMasterInformation_2.Controls.Add(this.lblDefaultsalesmanName);
			this._fraMasterInformation_2.Enabled = true;
			this._fraMasterInformation_2.ForeColor = System.Drawing.SystemColors.WindowText;
			this._fraMasterInformation_2.Location = new System.Drawing.Point(695, 23);
			this._fraMasterInformation_2.Name = "_fraMasterInformation_2";
			this._fraMasterInformation_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._fraMasterInformation_2.Size = new System.Drawing.Size(632, 209);
			this._fraMasterInformation_2.TabIndex = 30;
			this._fraMasterInformation_2.Visible = true;
			// 
			// chkCashType
			// 
			this.chkCashType.AllowDrop = true;
			this.chkCashType.Appearance = System.Windows.Forms.Appearance.Normal;
			this.chkCashType.BackColor = System.Drawing.Color.FromArgb(213, 213, 213);
			this.chkCashType.CausesValidation = true;
			this.chkCashType.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkCashType.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this.chkCashType.Enabled = true;
			this.chkCashType.ForeColor = System.Drawing.Color.Black;
			this.chkCashType.Location = new System.Drawing.Point(118, 36);
			this.chkCashType.Name = "chkCashType";
			this.chkCashType.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.chkCashType.Size = new System.Drawing.Size(83, 19);
			this.chkCashType.TabIndex = 38;
			this.chkCashType.TabStop = true;
			this.chkCashType.Text = "Cash";
			this.chkCashType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkCashType.Visible = true;
			// 
			// lblDefaultLdgrCode
			// 
			this.lblDefaultLdgrCode.AllowDrop = true;
			this.lblDefaultLdgrCode.BackColor = System.Drawing.Color.FromArgb(213, 213, 213);
			this.lblDefaultLdgrCode.Text = "Default Ledger Code";
			this.lblDefaultLdgrCode.ForeColor = System.Drawing.Color.Black;
			this.lblDefaultLdgrCode.Location = new System.Drawing.Point(8, 17);
			this.lblDefaultLdgrCode.Name = "lblDefaultLdgrCode";
			this.lblDefaultLdgrCode.Size = new System.Drawing.Size(99, 14);
			this.lblDefaultLdgrCode.TabIndex = 31;
			// 
			// lblDefaultCashCode
			// 
			this.lblDefaultCashCode.AllowDrop = true;
			this.lblDefaultCashCode.BackColor = System.Drawing.Color.FromArgb(213, 213, 213);
			this.lblDefaultCashCode.Text = "Default Cash Code";
			this.lblDefaultCashCode.ForeColor = System.Drawing.Color.Black;
			this.lblDefaultCashCode.Location = new System.Drawing.Point(8, 59);
			this.lblDefaultCashCode.Name = "lblDefaultCashCode";
			this.lblDefaultCashCode.Size = new System.Drawing.Size(90, 14);
			this.lblDefaultCashCode.TabIndex = 32;
			// 
			// lblDefaultLdgrName
			// 
			this.lblDefaultLdgrName.AllowDrop = true;
			this.lblDefaultLdgrName.BackColor = System.Drawing.Color.FromArgb(239, 239, 239);
			this.lblDefaultLdgrName.Enabled = false;
			this.lblDefaultLdgrName.ForeColor = System.Drawing.Color.Black;
			this.lblDefaultLdgrName.Location = new System.Drawing.Point(221, 14);
			this.lblDefaultLdgrName.Name = "lblDefaultLdgrName";
			this.lblDefaultLdgrName.Size = new System.Drawing.Size(191, 19);
			this.lblDefaultLdgrName.TabIndex = 33;
			this.lblDefaultLdgrName.TabStop = false;
			this.lblDefaultLdgrName.Text = " ";
			// this.this.lblDefaultLdgrName.Watermark = "";
			// 
			// lblDefaultCashName
			// 
			this.lblDefaultCashName.AllowDrop = true;
			this.lblDefaultCashName.BackColor = System.Drawing.Color.FromArgb(239, 239, 239);
			this.lblDefaultCashName.Enabled = false;
			this.lblDefaultCashName.ForeColor = System.Drawing.Color.Black;
			this.lblDefaultCashName.Location = new System.Drawing.Point(221, 57);
			this.lblDefaultCashName.Name = "lblDefaultCashName";
			this.lblDefaultCashName.Size = new System.Drawing.Size(191, 19);
			this.lblDefaultCashName.TabIndex = 34;
			this.lblDefaultCashName.TabStop = false;
			this.lblDefaultCashName.Text = " ";
			// this.this.lblDefaultCashName.Watermark = "";
			// 
			// lblDefaultTransType
			// 
			this.lblDefaultTransType.AllowDrop = true;
			this.lblDefaultTransType.BackColor = System.Drawing.Color.FromArgb(213, 213, 213);
			this.lblDefaultTransType.Text = "Default Trans Type";
			this.lblDefaultTransType.ForeColor = System.Drawing.Color.Black;
			this.lblDefaultTransType.Location = new System.Drawing.Point(8, 38);
			this.lblDefaultTransType.Name = "lblDefaultTransType";
			this.lblDefaultTransType.Size = new System.Drawing.Size(92, 14);
			this.lblDefaultTransType.TabIndex = 35;
			// 
			// txtDefaultLdgrNo
			// 
			this.txtDefaultLdgrNo.AllowDrop = true;
			this.txtDefaultLdgrNo.BackColor = System.Drawing.Color.White;
			this.txtDefaultLdgrNo.ForeColor = System.Drawing.Color.Black;
			this.txtDefaultLdgrNo.Location = new System.Drawing.Point(118, 14);
			this.txtDefaultLdgrNo.MaxLength = 15;
			this.txtDefaultLdgrNo.Name = "txtDefaultLdgrNo";
			// this.txtDefaultLdgrNo.ShowButton = true;
			this.txtDefaultLdgrNo.Size = new System.Drawing.Size(101, 19);
			this.txtDefaultLdgrNo.TabIndex = 36;
			this.txtDefaultLdgrNo.Text = "";
			// this.this.txtDefaultLdgrNo.Watermark = "";
			// this.this.txtDefaultLdgrNo.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtDefaultLdgrNo_DropButtonClick);
			// this.txtDefaultLdgrNo.Leave += new System.EventHandler(this.txtDefaultLdgrNo_Leave);
			// 
			// txtDefaultCashCode
			// 
			this.txtDefaultCashCode.AllowDrop = true;
			this.txtDefaultCashCode.BackColor = System.Drawing.Color.White;
			this.txtDefaultCashCode.ForeColor = System.Drawing.Color.Black;
			this.txtDefaultCashCode.Location = new System.Drawing.Point(118, 57);
			this.txtDefaultCashCode.MaxLength = 15;
			this.txtDefaultCashCode.Name = "txtDefaultCashCode";
			// this.txtDefaultCashCode.ShowButton = true;
			this.txtDefaultCashCode.Size = new System.Drawing.Size(101, 19);
			this.txtDefaultCashCode.TabIndex = 37;
			this.txtDefaultCashCode.Text = "";
			// this.this.txtDefaultCashCode.Watermark = "";
			// this.this.txtDefaultCashCode.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtDefaultCashCode_DropButtonClick);
			// this.txtDefaultCashCode.Leave += new System.EventHandler(this.txtDefaultCashCode_Leave);
			// 
			// txtDataUploadPath
			// 
			this.txtDataUploadPath.AllowDrop = true;
			this.txtDataUploadPath.BackColor = System.Drawing.Color.White;
			this.txtDataUploadPath.ForeColor = System.Drawing.Color.Black;
			this.txtDataUploadPath.Location = new System.Drawing.Point(118, 80);
			this.txtDataUploadPath.Name = "txtDataUploadPath";
			this.txtDataUploadPath.Size = new System.Drawing.Size(295, 19);
			this.txtDataUploadPath.TabIndex = 39;
			this.txtDataUploadPath.TabStop = false;
			this.txtDataUploadPath.Text = " ";
			// this.this.txtDataUploadPath.Watermark = "";
			// 
			// lblDataUploadPath
			// 
			this.lblDataUploadPath.AllowDrop = true;
			this.lblDataUploadPath.BackColor = System.Drawing.Color.FromArgb(213, 213, 213);
			this.lblDataUploadPath.Text = "Data Upload Path";
			this.lblDataUploadPath.ForeColor = System.Drawing.Color.Black;
			this.lblDataUploadPath.Location = new System.Drawing.Point(8, 82);
			this.lblDataUploadPath.Name = "lblDataUploadPath";
			this.lblDataUploadPath.Size = new System.Drawing.Size(82, 14);
			this.lblDataUploadPath.TabIndex = 40;
			// 
			// lblDefaultSalesmanCode
			// 
			this.lblDefaultSalesmanCode.AllowDrop = true;
			this.lblDefaultSalesmanCode.BackColor = System.Drawing.Color.FromArgb(213, 213, 213);
			this.lblDefaultSalesmanCode.Text = "Default Salesman Code";
			this.lblDefaultSalesmanCode.ForeColor = System.Drawing.Color.Black;
			this.lblDefaultSalesmanCode.Location = new System.Drawing.Point(6, 104);
			this.lblDefaultSalesmanCode.Name = "lblDefaultSalesmanCode";
			this.lblDefaultSalesmanCode.Size = new System.Drawing.Size(112, 14);
			this.lblDefaultSalesmanCode.TabIndex = 41;
			// 
			// txtDefaultSalesmanNo
			// 
			this.txtDefaultSalesmanNo.AllowDrop = true;
			this.txtDefaultSalesmanNo.BackColor = System.Drawing.Color.White;
			// this.txtDefaultSalesmanNo.bolNumericOnly = true;
			this.txtDefaultSalesmanNo.ForeColor = System.Drawing.Color.Black;
			this.txtDefaultSalesmanNo.Location = new System.Drawing.Point(118, 102);
			this.txtDefaultSalesmanNo.MaxLength = 15;
			this.txtDefaultSalesmanNo.Name = "txtDefaultSalesmanNo";
			// this.txtDefaultSalesmanNo.ShowButton = true;
			this.txtDefaultSalesmanNo.Size = new System.Drawing.Size(101, 19);
			this.txtDefaultSalesmanNo.TabIndex = 42;
			this.txtDefaultSalesmanNo.Text = "";
			// this.this.txtDefaultSalesmanNo.Watermark = "";
			// this.this.txtDefaultSalesmanNo.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtDefaultSalesmanNo_DropButtonClick);
			// this.txtDefaultSalesmanNo.Leave += new System.EventHandler(this.txtDefaultSalesmanNo_Leave);
			// 
			// lblDefaultsalesmanName
			// 
			this.lblDefaultsalesmanName.AllowDrop = true;
			this.lblDefaultsalesmanName.BackColor = System.Drawing.Color.FromArgb(239, 239, 239);
			this.lblDefaultsalesmanName.Enabled = false;
			this.lblDefaultsalesmanName.ForeColor = System.Drawing.Color.Black;
			this.lblDefaultsalesmanName.Location = new System.Drawing.Point(222, 102);
			this.lblDefaultsalesmanName.Name = "lblDefaultsalesmanName";
			this.lblDefaultsalesmanName.Size = new System.Drawing.Size(191, 19);
			this.lblDefaultsalesmanName.TabIndex = 43;
			this.lblDefaultsalesmanName.TabStop = false;
			this.lblDefaultsalesmanName.Text = " ";
			// this.this.lblDefaultsalesmanName.Watermark = "";
			// 
			// _fraMasterInformation_1
			// 
			this._fraMasterInformation_1.AllowDrop = true;
			this._fraMasterInformation_1.BackColor = System.Drawing.Color.FromArgb(249, 240, 236);
			this._fraMasterInformation_1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._fraMasterInformation_1.Controls.Add(this.grdVoucherDetails);
			this._fraMasterInformation_1.Controls.Add(this.cmbCommon);
			this._fraMasterInformation_1.Enabled = true;
			this._fraMasterInformation_1.ForeColor = System.Drawing.SystemColors.ControlText;
			this._fraMasterInformation_1.Location = new System.Drawing.Point(675, 23);
			this._fraMasterInformation_1.Name = "_fraMasterInformation_1";
			this._fraMasterInformation_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._fraMasterInformation_1.Size = new System.Drawing.Size(632, 209);
			this._fraMasterInformation_1.TabIndex = 27;
			this._fraMasterInformation_1.Visible = true;
			// 
			// grdVoucherDetails
			// 
			this.grdVoucherDetails.AllowDrop = true;
			this.grdVoucherDetails.BackColor = System.Drawing.Color.FromArgb(212, 208, 200);
			this.grdVoucherDetails.CellTipsWidth = 0;
			this.grdVoucherDetails.Location = new System.Drawing.Point(-2, 0);
			this.grdVoucherDetails.Name = "grdVoucherDetails";
			this.grdVoucherDetails.RowDivider.Color = System.Drawing.Color.FromArgb(212, 208, 200);
			this.grdVoucherDetails.Size = new System.Drawing.Size(635, 210);
			this.grdVoucherDetails.TabIndex = 29;
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
			this.cmbCommon.Location = new System.Drawing.Point(42, 18);
			this.cmbCommon.Name = "cmbCommon";
			this.cmbCommon.Size = new System.Drawing.Size(113, 33);
			this.cmbCommon.TabIndex = 28;
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
			// _fraMasterInformation_0
			// 
			this._fraMasterInformation_0.AllowDrop = true;
			this._fraMasterInformation_0.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._fraMasterInformation_0.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._fraMasterInformation_0.Controls.Add(this.chkCheckNegativeStock);
			this._fraMasterInformation_0.Controls.Add(this.txtComment);
			this._fraMasterInformation_0.Controls.Add(this.Label2);
			this._fraMasterInformation_0.Controls.Add(this.Label3);
			this._fraMasterInformation_0.Controls.Add(this.txtLShortName);
			this._fraMasterInformation_0.Controls.Add(this.txtAShortName);
			this._fraMasterInformation_0.Controls.Add(this.lblAddr_1);
			this._fraMasterInformation_0.Controls.Add(this.lblPhone);
			this._fraMasterInformation_0.Controls.Add(this.lblComments);
			this._fraMasterInformation_0.Controls.Add(this.txtAdd1);
			this._fraMasterInformation_0.Controls.Add(this.lblMobile);
			this._fraMasterInformation_0.Controls.Add(this.txtPhone);
			this._fraMasterInformation_0.Controls.Add(this.txtContactPerson);
			this._fraMasterInformation_0.Controls.Add(this.Label1);
			this._fraMasterInformation_0.Controls.Add(this.txtAdd3);
			this._fraMasterInformation_0.Controls.Add(this.lblAddr_2);
			this._fraMasterInformation_0.Controls.Add(this.txtAdd2);
			this._fraMasterInformation_0.Enabled = true;
			this._fraMasterInformation_0.ForeColor = System.Drawing.SystemColors.WindowText;
			this._fraMasterInformation_0.Location = new System.Drawing.Point(1, 23);
			this._fraMasterInformation_0.Name = "_fraMasterInformation_0";
			this._fraMasterInformation_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._fraMasterInformation_0.Size = new System.Drawing.Size(632, 209);
			this._fraMasterInformation_0.TabIndex = 14;
			this._fraMasterInformation_0.Visible = true;
			// 
			// chkCheckNegativeStock
			// 
			this.chkCheckNegativeStock.AllowDrop = true;
			this.chkCheckNegativeStock.Appearance = System.Windows.Forms.Appearance.Normal;
			this.chkCheckNegativeStock.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this.chkCheckNegativeStock.CausesValidation = true;
			this.chkCheckNegativeStock.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkCheckNegativeStock.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this.chkCheckNegativeStock.Enabled = true;
			this.chkCheckNegativeStock.ForeColor = System.Drawing.Color.Black;
			this.chkCheckNegativeStock.Location = new System.Drawing.Point(120, 120);
			this.chkCheckNegativeStock.Name = "chkCheckNegativeStock";
			this.chkCheckNegativeStock.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.chkCheckNegativeStock.Size = new System.Drawing.Size(177, 19);
			this.chkCheckNegativeStock.TabIndex = 10;
			this.chkCheckNegativeStock.TabStop = true;
			this.chkCheckNegativeStock.Text = "Check Negative Stock";
			this.chkCheckNegativeStock.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkCheckNegativeStock.Visible = true;
			// 
			// txtComment
			// 
			this.txtComment.AcceptsReturn = true;
			this.txtComment.AllowDrop = true;
			this.txtComment.BackColor = System.Drawing.SystemColors.Window;
			this.txtComment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtComment.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtComment.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtComment.Location = new System.Drawing.Point(120, 143);
			this.txtComment.MaxLength = 100;
			this.txtComment.Multiline = true;
			this.txtComment.Name = "txtComment";
			this.txtComment.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtComment.Size = new System.Drawing.Size(506, 49);
			this.txtComment.TabIndex = 11;
			// 
			// System.Windows.Forms.Label2
			// 
			this.Label2.AllowDrop = true;
			this.Label2.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this.Label2.Text = "Short Name (English)";
			this.Label2.ForeColor = System.Drawing.Color.Black;
			this.Label2.Location = new System.Drawing.Point(8, 16);
			// this.Label2.mLabelId = 709;
			this.Label2.Name = "System.Windows.Forms.Label2";
			this.Label2.Size = new System.Drawing.Size(101, 14);
			this.Label2.TabIndex = 19;
			// 
			// System.Windows.Forms.Label3
			// 
			this.Label3.AllowDrop = true;
			this.Label3.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this.Label3.Text = "Short Name (Arabic)";
			this.Label3.ForeColor = System.Drawing.Color.Black;
			this.Label3.Location = new System.Drawing.Point(8, 37);
			// this.Label3.mLabelId = 958;
			this.Label3.Name = "System.Windows.Forms.Label3";
			this.Label3.Size = new System.Drawing.Size(99, 14);
			this.Label3.TabIndex = 20;
			// 
			// txtLShortName
			// 
			this.txtLShortName.AllowDrop = true;
			this.txtLShortName.BackColor = System.Drawing.Color.White;
			this.txtLShortName.ForeColor = System.Drawing.Color.Black;
			this.txtLShortName.Location = new System.Drawing.Point(120, 14);
			this.txtLShortName.MaxLength = 20;
			this.txtLShortName.Name = "txtLShortName";
			this.txtLShortName.Size = new System.Drawing.Size(127, 19);
			this.txtLShortName.TabIndex = 3;
			this.txtLShortName.Tag = "Salesman Name in English";
			this.txtLShortName.Text = "";
			// this.this.txtLShortName.Watermark = "";
			// 
			// txtAShortName
			// 
			this.txtAShortName.AllowDrop = true;
			this.txtAShortName.BackColor = System.Drawing.Color.White;
			this.txtAShortName.ForeColor = System.Drawing.Color.Black;
			this.txtAShortName.Location = new System.Drawing.Point(120, 35);
			// this.txtAShortName.mArabicEnabled = true;
			this.txtAShortName.MaxLength = 20;
			this.txtAShortName.Name = "txtAShortName";
			this.txtAShortName.Size = new System.Drawing.Size(127, 19);
			this.txtAShortName.TabIndex = 4;
			this.txtAShortName.Text = "";
			// this.this.txtAShortName.Watermark = "";
			// 
			// lblAddr_1
			// 
			this.lblAddr_1.AllowDrop = true;
			this.lblAddr_1.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this.lblAddr_1.Text = "Address 1";
			this.lblAddr_1.ForeColor = System.Drawing.Color.Black;
			this.lblAddr_1.Location = new System.Drawing.Point(8, 59);
			// // this.lblAddr_1.mLabelId = 31;
			this.lblAddr_1.Name = "lblAddr_1";
			this.lblAddr_1.Size = new System.Drawing.Size(51, 14);
			this.lblAddr_1.TabIndex = 21;
			// 
			// lblPhone
			// 
			this.lblPhone.AllowDrop = true;
			this.lblPhone.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this.lblPhone.Text = "Phone";
			this.lblPhone.ForeColor = System.Drawing.Color.Black;
			this.lblPhone.Location = new System.Drawing.Point(416, 79);
			// // this.lblPhone.mLabelId = 524;
			this.lblPhone.Name = "lblPhone";
			this.lblPhone.Size = new System.Drawing.Size(30, 14);
			this.lblPhone.TabIndex = 22;
			// 
			// lblComments
			// 
			this.lblComments.AllowDrop = true;
			this.lblComments.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this.lblComments.Text = "Comment";
			this.lblComments.ForeColor = System.Drawing.Color.Black;
			this.lblComments.Location = new System.Drawing.Point(8, 140);
			// // this.lblComments.mLabelId = 135;
			this.lblComments.Name = "lblComments";
			this.lblComments.Size = new System.Drawing.Size(44, 14);
			this.lblComments.TabIndex = 23;
			// 
			// txtAdd1
			// 
			this.txtAdd1.AllowDrop = true;
			this.txtAdd1.BackColor = System.Drawing.Color.White;
			this.txtAdd1.ForeColor = System.Drawing.Color.Black;
			this.txtAdd1.Location = new System.Drawing.Point(120, 56);
			this.txtAdd1.MaxLength = 50;
			this.txtAdd1.Name = "txtAdd1";
			this.txtAdd1.Size = new System.Drawing.Size(201, 19);
			this.txtAdd1.TabIndex = 5;
			this.txtAdd1.Text = "";
			// this.this.txtAdd1.Watermark = "";
			// 
			// lblMobile
			// 
			this.lblMobile.AllowDrop = true;
			this.lblMobile.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this.lblMobile.Text = "Contact Person";
			this.lblMobile.ForeColor = System.Drawing.Color.Black;
			this.lblMobile.Location = new System.Drawing.Point(416, 100);
			// // this.lblMobile.mLabelId = 142;
			this.lblMobile.Name = "lblMobile";
			this.lblMobile.Size = new System.Drawing.Size(74, 14);
			this.lblMobile.TabIndex = 24;
			// 
			// txtPhone
			// 
			this.txtPhone.AllowDrop = true;
			this.txtPhone.BackColor = System.Drawing.Color.White;
			this.txtPhone.ForeColor = System.Drawing.Color.Black;
			this.txtPhone.Location = new System.Drawing.Point(493, 77);
			this.txtPhone.MaxLength = 10;
			this.txtPhone.Name = "txtPhone";
			this.txtPhone.Size = new System.Drawing.Size(133, 19);
			this.txtPhone.TabIndex = 8;
			this.txtPhone.Text = "";
			// this.this.txtPhone.Watermark = "";
			// 
			// txtContactPerson
			// 
			this.txtContactPerson.AllowDrop = true;
			this.txtContactPerson.BackColor = System.Drawing.Color.White;
			this.txtContactPerson.ForeColor = System.Drawing.Color.Black;
			this.txtContactPerson.Location = new System.Drawing.Point(493, 98);
			this.txtContactPerson.MaxLength = 50;
			this.txtContactPerson.Name = "txtContactPerson";
			this.txtContactPerson.Size = new System.Drawing.Size(133, 19);
			this.txtContactPerson.TabIndex = 9;
			this.txtContactPerson.Text = "";
			// this.this.txtContactPerson.Watermark = "";
			// 
			// System.Windows.Forms.Label1
			// 
			this.Label1.AllowDrop = true;
			this.Label1.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this.Label1.Text = "Address 3";
			this.Label1.ForeColor = System.Drawing.Color.Black;
			this.Label1.Location = new System.Drawing.Point(8, 100);
			// this.Label1.mLabelId = 33;
			this.Label1.Name = "System.Windows.Forms.Label1";
			this.Label1.Size = new System.Drawing.Size(51, 14);
			this.Label1.TabIndex = 25;
			// 
			// txtAdd3
			// 
			this.txtAdd3.AllowDrop = true;
			this.txtAdd3.BackColor = System.Drawing.Color.White;
			this.txtAdd3.ForeColor = System.Drawing.Color.Black;
			this.txtAdd3.Location = new System.Drawing.Point(120, 98);
			this.txtAdd3.MaxLength = 50;
			this.txtAdd3.Name = "txtAdd3";
			this.txtAdd3.Size = new System.Drawing.Size(201, 19);
			this.txtAdd3.TabIndex = 7;
			this.txtAdd3.Text = "";
			// this.this.txtAdd3.Watermark = "";
			// 
			// lblAddr_2
			// 
			this.lblAddr_2.AllowDrop = true;
			this.lblAddr_2.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this.lblAddr_2.Text = "Address 2";
			this.lblAddr_2.ForeColor = System.Drawing.Color.Black;
			this.lblAddr_2.Location = new System.Drawing.Point(8, 79);
			// // this.lblAddr_2.mLabelId = 32;
			this.lblAddr_2.Name = "lblAddr_2";
			this.lblAddr_2.Size = new System.Drawing.Size(51, 14);
			this.lblAddr_2.TabIndex = 26;
			// 
			// txtAdd2
			// 
			this.txtAdd2.AllowDrop = true;
			this.txtAdd2.BackColor = System.Drawing.Color.White;
			this.txtAdd2.ForeColor = System.Drawing.Color.Black;
			this.txtAdd2.Location = new System.Drawing.Point(120, 77);
			this.txtAdd2.MaxLength = 50;
			this.txtAdd2.Name = "txtAdd2";
			this.txtAdd2.Size = new System.Drawing.Size(201, 19);
			this.txtAdd2.TabIndex = 6;
			this.txtAdd2.Text = "";
			// this.this.txtAdd2.Watermark = "";
			// 
			// _lblCommon_3
			// 
			this._lblCommon_3.AllowDrop = true;
			this._lblCommon_3.BackColor = System.Drawing.Color.White;
			this._lblCommon_3.Text = " Location Information ";
			this._lblCommon_3.ForeColor = System.Drawing.Color.FromArgb(57, 77, 102);
			this._lblCommon_3.Location = new System.Drawing.Point(24, 68);
			// // this._lblCommon_3.mLabelId = 957;
			this._lblCommon_3.Name = "_lblCommon_3";
			this._lblCommon_3.Size = new System.Drawing.Size(120, 14);
			this._lblCommon_3.TabIndex = 15;
			// 
			// lblLSmanName
			// 
			this.lblLSmanName.AllowDrop = true;
			this.lblLSmanName.BackColor = System.Drawing.Color.White;
			this.lblLSmanName.Text = "Location Name (English)";
			this.lblLSmanName.ForeColor = System.Drawing.Color.Black;
			this.lblLSmanName.Location = new System.Drawing.Point(260, 24);
			// // this.lblLSmanName.mLabelId = 418;
			this.lblLSmanName.Name = "lblLSmanName";
			this.lblLSmanName.Size = new System.Drawing.Size(116, 14);
			this.lblLSmanName.TabIndex = 16;
			// 
			// lblASmanName
			// 
			this.lblASmanName.AllowDrop = true;
			this.lblASmanName.BackColor = System.Drawing.Color.White;
			this.lblASmanName.Text = "Location Name (Arabic)";
			this.lblASmanName.ForeColor = System.Drawing.Color.Black;
			this.lblASmanName.Location = new System.Drawing.Point(260, 45);
			// // this.lblASmanName.mLabelId = 956;
			this.lblASmanName.Name = "lblASmanName";
			this.lblASmanName.Size = new System.Drawing.Size(114, 14);
			this.lblASmanName.TabIndex = 17;
			// 
			// txtLocationNo
			// 
			this.txtLocationNo.AllowDrop = true;
			this.txtLocationNo.BackColor = System.Drawing.Color.White;
			// this.txtLocationNo.bolNumericOnly = true;
			this.txtLocationNo.ForeColor = System.Drawing.Color.Black;
			this.txtLocationNo.Location = new System.Drawing.Point(94, 22);
			this.txtLocationNo.MaxLength = 4;
			// this.txtLocationNo.mDropDownType = System.Windows.Forms.TextBox.DropDownTypes.ddtNextNumber;
			this.txtLocationNo.Name = "txtLocationNo";
			// this.txtLocationNo.ShowButton = true;
			this.txtLocationNo.Size = new System.Drawing.Size(101, 19);
			this.txtLocationNo.TabIndex = 0;
			this.txtLocationNo.Text = "";
			// this.this.txtLocationNo.Watermark = "";
			// this.this.txtLocationNo.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtLocationNo_DropButtonClick);
			// 
			// txtLLocationName
			// 
			this.txtLLocationName.AllowDrop = true;
			this.txtLLocationName.BackColor = System.Drawing.Color.White;
			this.txtLLocationName.ForeColor = System.Drawing.Color.Black;
			this.txtLLocationName.Location = new System.Drawing.Point(402, 22);
			this.txtLLocationName.MaxLength = 50;
			this.txtLLocationName.Name = "txtLLocationName";
			this.txtLLocationName.Size = new System.Drawing.Size(201, 19);
			this.txtLLocationName.TabIndex = 1;
			this.txtLLocationName.Tag = "Salesman Name in English";
			this.txtLLocationName.Text = "";
			// this.this.txtLLocationName.Watermark = "";
			// 
			// txtALocationName
			// 
			this.txtALocationName.AllowDrop = true;
			this.txtALocationName.BackColor = System.Drawing.Color.White;
			this.txtALocationName.ForeColor = System.Drawing.Color.Black;
			this.txtALocationName.Location = new System.Drawing.Point(402, 43);
			// this.txtALocationName.mArabicEnabled = true;
			this.txtALocationName.MaxLength = 50;
			this.txtALocationName.Name = "txtALocationName";
			this.txtALocationName.Size = new System.Drawing.Size(201, 19);
			this.txtALocationName.TabIndex = 2;
			this.txtALocationName.Text = "";
			// this.this.txtALocationName.Watermark = "";
			// 
			// lblSmanNo
			// 
			this.lblSmanNo.AllowDrop = true;
			this.lblSmanNo.BackColor = System.Drawing.Color.White;
			this.lblSmanNo.Text = "Location Code";
			this.lblSmanNo.ForeColor = System.Drawing.Color.Black;
			this.lblSmanNo.Location = new System.Drawing.Point(8, 24);
			// // this.lblSmanNo.mLabelId = 416;
			this.lblSmanNo.Name = "lblSmanNo";
			this.lblSmanNo.Size = new System.Drawing.Size(69, 14);
			this.lblSmanNo.TabIndex = 18;
			// 
			// Line1
			// 
			this.Line1.AllowDrop = true;
			this.Line1.BackColor = System.Drawing.SystemColors.WindowText;
			this.Line1.Enabled = false;
			this.Line1.Location = new System.Drawing.Point(-8, 76);
			this.Line1.Name = "Line1";
			this.Line1.Size = new System.Drawing.Size(656, 1);
			this.Line1.Visible = true;
			// 
			// frmICSLocation
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.ClientSize = new System.Drawing.Size(966, 544);
			this.Controls.Add(this.cntOuterFrame);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			//this.Icon = (System.Drawing.Icon) resources.GetObject("frmICSLocation.Icon");
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(95, 154);
			this.MaximizeBox = true;
			this.MinimizeBox = true;
			this.Name = "frmICSLocation";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Location";
			this.ToolTipMain.SetToolTip(this.txtLShortName, "Salesman Name in English");
			this.ToolTipMain.SetToolTip(this.txtLLocationName, "Salesman Name in English");
			// this.Activated += new System.EventHandler(this.frmICSLocation_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
			// this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
			//((System.ComponentModel.ISupportInitialize) this.tabMaster).EndInit();
			//((System.ComponentModel.ISupportInitialize) this.cntOuterFrame).EndInit();
			this.cntOuterFrame.ResumeLayout(false);
			this.tabMaster.ResumeLayout(false);
			this._fraMasterInformation_2.ResumeLayout(false);
			this._fraMasterInformation_1.ResumeLayout(false);
			this.grdVoucherDetails.ResumeLayout(false);
			this.cmbCommon.ResumeLayout(false);
			this._fraMasterInformation_0.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		// 
		void InitializelblCommon()
		{
			this.lblCommon = new System.Windows.Forms.Label[4];
			this.lblCommon[3] = _lblCommon_3;
		}
		void InitializefraMasterInformation()
		{
			this.fraMasterInformation = new System.Windows.Forms.Panel[3];
			this.fraMasterInformation[2] = _fraMasterInformation_2;
			this.fraMasterInformation[1] = _fraMasterInformation_1;
			this.fraMasterInformation[0] = _fraMasterInformation_0;
		}
		#endregion
	}
}//ENDSHERE
