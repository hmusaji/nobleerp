
namespace Xtreme
{
	partial class frmGLProjects
	{

		#region "Upgrade Support "
		private static frmGLProjects m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmGLProjects DefInstance
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
		public static frmGLProjects CreateInstance()
		{
			frmGLProjects theInstance = new frmGLProjects();
			
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
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "Column_0_cmbPriceList", "Column_1_cmbPriceList", "cmbPriceList", "Column_0_grdActivityDetails", "Column_1_grdActivityDetails", "grdActivityDetails", "_fraLedgerInformation_3", "_lblCommon_40", "txtWIPCd", "txtBillingCodeName", "_lblCommon_42", "txtWIPCodeName", "txtReceivableCd", "_lblCommon_4", "txtReceivableCodeName", "txtBillingCd", "_fraLedgerInformation_2", "txtWeb", "txtEmailAddress", "txtFax", "txtMobile", "txtPhone", "txtCountry", "txtAAdd3", "txtAAdd2", "txtAAdd1", "txtLAdd3", "txtLAdd2", "txtSupervisorName", "txtCity", "txtLAdd1", "_lblCommon_11", "_lblCommon_12", "_lblCommon_13", "_lblCommon_14", "_lblCommon_15", "_lblCommon_16", "_lblCommon_17", "_lblCommon_19", "_lblCommon_20", "_lblCommon_21", "_lblCommon_33", "_lblCommon_34", "_lblCommon_35", "_lblCommon_39", "_fraLedgerInformation_1", "txtComment", "_lblCommon_9", "_lblCommon_24", "_txt_2", "txtPercentCompleted", "fraProjectCompletedDetails", "_lblCommon_5", "_lblCommon_6", "_lblCommon_7", "_lblCommon_8", "_lblCommon_10", "System.Windows.Forms.Label1", "txtEstimatedIncome", "txtParentProjectNo", "txtExtimatedExp", "txtProjectType", "txtEndDate", "txtStartDate", "txtParentProjectName", "txtProjectTypeName", "System.Windows.Forms.Label2", "_fraLedgerInformation_0", "tabMaster", "txtLProjectName", "txtAprojectName", "_lblCommon_0", "txtProjectNo", "_lblCommon_1", "_lblCommon_2", "_lblCommon_3", "Line1", "fraLedgerInformation", "lblCommon", "txt"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_0_cmbPriceList;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_1_cmbPriceList;
		public C1.Win.C1TrueDBGrid.C1TrueDBDropdown cmbPriceList;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_0_grdActivityDetails;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_1_grdActivityDetails;
		public C1.Win.C1TrueDBGrid.C1TrueDBGrid grdActivityDetails;
		private AxXtremeSuiteControls.AxTabControlPage _fraLedgerInformation_3;
		private System.Windows.Forms.Label _lblCommon_40;
		public System.Windows.Forms.TextBox txtWIPCd;
		public System.Windows.Forms.Label txtBillingCodeName;
		private System.Windows.Forms.Label _lblCommon_42;
		public System.Windows.Forms.Label txtWIPCodeName;
		public System.Windows.Forms.TextBox txtReceivableCd;
		private System.Windows.Forms.Label _lblCommon_4;
		public System.Windows.Forms.Label txtReceivableCodeName;
		public System.Windows.Forms.TextBox txtBillingCd;
		private AxXtremeSuiteControls.AxTabControlPage _fraLedgerInformation_2;
		public System.Windows.Forms.TextBox txtWeb;
		public System.Windows.Forms.TextBox txtEmailAddress;
		public System.Windows.Forms.TextBox txtFax;
		public System.Windows.Forms.TextBox txtMobile;
		public System.Windows.Forms.TextBox txtPhone;
		public System.Windows.Forms.TextBox txtCountry;
		public System.Windows.Forms.TextBox txtAAdd3;
		public System.Windows.Forms.TextBox txtAAdd2;
		public System.Windows.Forms.TextBox txtAAdd1;
		public System.Windows.Forms.TextBox txtLAdd3;
		public System.Windows.Forms.TextBox txtLAdd2;
		public System.Windows.Forms.TextBox txtSupervisorName;
		public System.Windows.Forms.TextBox txtCity;
		public System.Windows.Forms.TextBox txtLAdd1;
		private System.Windows.Forms.Label _lblCommon_11;
		private System.Windows.Forms.Label _lblCommon_12;
		private System.Windows.Forms.Label _lblCommon_13;
		private System.Windows.Forms.Label _lblCommon_14;
		private System.Windows.Forms.Label _lblCommon_15;
		private System.Windows.Forms.Label _lblCommon_16;
		private System.Windows.Forms.Label _lblCommon_17;
		private System.Windows.Forms.Label _lblCommon_19;
		private System.Windows.Forms.Label _lblCommon_20;
		private System.Windows.Forms.Label _lblCommon_21;
		private System.Windows.Forms.Label _lblCommon_33;
		private System.Windows.Forms.Label _lblCommon_34;
		private System.Windows.Forms.Label _lblCommon_35;
		private System.Windows.Forms.Label _lblCommon_39;
		private AxXtremeSuiteControls.AxTabControlPage _fraLedgerInformation_1;
		public System.Windows.Forms.TextBox txtComment;
		private System.Windows.Forms.Label _lblCommon_9;
		private System.Windows.Forms.Label _lblCommon_24;
		private System.Windows.Forms.Label _txt_2;
		public System.Windows.Forms.Label txtPercentCompleted;
		public System.Windows.Forms.GroupBox fraProjectCompletedDetails;
		private System.Windows.Forms.Label _lblCommon_5;
		private System.Windows.Forms.Label _lblCommon_6;
		private System.Windows.Forms.Label _lblCommon_7;
		private System.Windows.Forms.Label _lblCommon_8;
		private System.Windows.Forms.Label _lblCommon_10;
		public System.Windows.Forms.LabelLabel1;
		public System.Windows.Forms.TextBox txtEstimatedIncome;
		public System.Windows.Forms.TextBox txtParentProjectNo;
		public System.Windows.Forms.TextBox txtExtimatedExp;
		public System.Windows.Forms.TextBox txtProjectType;
		public Syncfusion.WinForms.Input.SfDateTimeEdit txtEndDate;
		public Syncfusion.WinForms.Input.SfDateTimeEdit txtStartDate;
		public System.Windows.Forms.Label txtParentProjectName;
		public System.Windows.Forms.Label txtProjectTypeName;
		public System.Windows.Forms.LabelLabel2;
		private AxXtremeSuiteControls.AxTabControlPage _fraLedgerInformation_0;
		public AxXtremeSuiteControls.AxTabControl tabMaster;
		public System.Windows.Forms.TextBox txtLProjectName;
		public System.Windows.Forms.TextBox txtAprojectName;
		private System.Windows.Forms.Label _lblCommon_0;
		public System.Windows.Forms.TextBox txtProjectNo;
		private System.Windows.Forms.Label _lblCommon_1;
		private System.Windows.Forms.Label _lblCommon_2;
		private System.Windows.Forms.Label _lblCommon_3;
		public System.Windows.Forms.Label Line1;
		public AxXtremeSuiteControls.AxTabControlPage[] fraLedgerInformation = new AxXtremeSuiteControls.AxTabControlPage[4];
		public System.Windows.Forms.Label[] lblCommon = new System.Windows.Forms.Label[43];
		public System.Windows.Forms.Label[] txt = new System.Windows.Forms.Label[3];
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGLProjects));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this.tabMaster = new AxXtremeSuiteControls.AxTabControl();
			this._fraLedgerInformation_3 = new AxXtremeSuiteControls.AxTabControlPage();
			this.cmbPriceList = new C1.Win.C1TrueDBGrid.C1TrueDBDropdown();
			this.Column_0_cmbPriceList = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.Column_1_cmbPriceList = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.grdActivityDetails = new C1.Win.C1TrueDBGrid.C1TrueDBGrid();
			this.Column_0_grdActivityDetails = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.Column_1_grdActivityDetails = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this._fraLedgerInformation_2 = new AxXtremeSuiteControls.AxTabControlPage();
			this._lblCommon_40 = new System.Windows.Forms.Label();
			this.txtWIPCd = new System.Windows.Forms.TextBox();
			this.txtBillingCodeName = new System.Windows.Forms.Label();
			this._lblCommon_42 = new System.Windows.Forms.Label();
			this.txtWIPCodeName = new System.Windows.Forms.Label();
			this.txtReceivableCd = new System.Windows.Forms.TextBox();
			this._lblCommon_4 = new System.Windows.Forms.Label();
			this.txtReceivableCodeName = new System.Windows.Forms.Label();
			this.txtBillingCd = new System.Windows.Forms.TextBox();
			this._fraLedgerInformation_1 = new AxXtremeSuiteControls.AxTabControlPage();
			this.txtWeb = new System.Windows.Forms.TextBox();
			this.txtEmailAddress = new System.Windows.Forms.TextBox();
			this.txtFax = new System.Windows.Forms.TextBox();
			this.txtMobile = new System.Windows.Forms.TextBox();
			this.txtPhone = new System.Windows.Forms.TextBox();
			this.txtCountry = new System.Windows.Forms.TextBox();
			this.txtAAdd3 = new System.Windows.Forms.TextBox();
			this.txtAAdd2 = new System.Windows.Forms.TextBox();
			this.txtAAdd1 = new System.Windows.Forms.TextBox();
			this.txtLAdd3 = new System.Windows.Forms.TextBox();
			this.txtLAdd2 = new System.Windows.Forms.TextBox();
			this.txtSupervisorName = new System.Windows.Forms.TextBox();
			this.txtCity = new System.Windows.Forms.TextBox();
			this.txtLAdd1 = new System.Windows.Forms.TextBox();
			this._lblCommon_11 = new System.Windows.Forms.Label();
			this._lblCommon_12 = new System.Windows.Forms.Label();
			this._lblCommon_13 = new System.Windows.Forms.Label();
			this._lblCommon_14 = new System.Windows.Forms.Label();
			this._lblCommon_15 = new System.Windows.Forms.Label();
			this._lblCommon_16 = new System.Windows.Forms.Label();
			this._lblCommon_17 = new System.Windows.Forms.Label();
			this._lblCommon_19 = new System.Windows.Forms.Label();
			this._lblCommon_20 = new System.Windows.Forms.Label();
			this._lblCommon_21 = new System.Windows.Forms.Label();
			this._lblCommon_33 = new System.Windows.Forms.Label();
			this._lblCommon_34 = new System.Windows.Forms.Label();
			this._lblCommon_35 = new System.Windows.Forms.Label();
			this._lblCommon_39 = new System.Windows.Forms.Label();
			this._fraLedgerInformation_0 = new AxXtremeSuiteControls.AxTabControlPage();
			this.txtComment = new System.Windows.Forms.TextBox();
			this.fraProjectCompletedDetails = new System.Windows.Forms.GroupBox();
			this._lblCommon_9 = new System.Windows.Forms.Label();
			this._lblCommon_24 = new System.Windows.Forms.Label();
			this._txt_2 = new System.Windows.Forms.Label();
			this.txtPercentCompleted = new System.Windows.Forms.Label();
			this._lblCommon_5 = new System.Windows.Forms.Label();
			this._lblCommon_6 = new System.Windows.Forms.Label();
			this._lblCommon_7 = new System.Windows.Forms.Label();
			this._lblCommon_8 = new System.Windows.Forms.Label();
			this._lblCommon_10 = new System.Windows.Forms.Label();
			this.Label1 = new System.Windows.Forms.Label();
			this.txtEstimatedIncome = new System.Windows.Forms.TextBox();
			this.txtParentProjectNo = new System.Windows.Forms.TextBox();
			this.txtExtimatedExp = new System.Windows.Forms.TextBox();
			this.txtProjectType = new System.Windows.Forms.TextBox();
			this.txtEndDate = new Syncfusion.WinForms.Input.SfDateTimeEdit();
			this.txtStartDate = new Syncfusion.WinForms.Input.SfDateTimeEdit();
			this.txtParentProjectName = new System.Windows.Forms.Label();
			this.txtProjectTypeName = new System.Windows.Forms.Label();
			this.Label2 = new System.Windows.Forms.Label();
			this.txtLProjectName = new System.Windows.Forms.TextBox();
			this.txtAprojectName = new System.Windows.Forms.TextBox();
			this._lblCommon_0 = new System.Windows.Forms.Label();
			this.txtProjectNo = new System.Windows.Forms.TextBox();
			this._lblCommon_1 = new System.Windows.Forms.Label();
			this._lblCommon_2 = new System.Windows.Forms.Label();
			this._lblCommon_3 = new System.Windows.Forms.Label();
			this.Line1 = new System.Windows.Forms.Label();
			// //((System.ComponentModel.ISupportInitialize) this._fraLedgerInformation_3).BeginInit();
			// //((System.ComponentModel.ISupportInitialize) this._fraLedgerInformation_2).BeginInit();
			// //((System.ComponentModel.ISupportInitialize) this._fraLedgerInformation_1).BeginInit();
			// //((System.ComponentModel.ISupportInitialize) this._fraLedgerInformation_0).BeginInit();
			// //((System.ComponentModel.ISupportInitialize) this.tabMaster).BeginInit();
			this.tabMaster.SuspendLayout();
			this._fraLedgerInformation_3.SuspendLayout();
			this.cmbPriceList.SuspendLayout();
			this.grdActivityDetails.SuspendLayout();
			this._fraLedgerInformation_2.SuspendLayout();
			this._fraLedgerInformation_1.SuspendLayout();
			this._fraLedgerInformation_0.SuspendLayout();
			this.fraProjectCompletedDetails.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabMaster
			// 
			this.tabMaster.AllowDrop = true;
			this.tabMaster.Controls.Add(this._fraLedgerInformation_3);
			this.tabMaster.Controls.Add(this._fraLedgerInformation_2);
			this.tabMaster.Controls.Add(this._fraLedgerInformation_1);
			this.tabMaster.Controls.Add(this._fraLedgerInformation_0);
			this.tabMaster.Location = new System.Drawing.Point(4, 128);
			this.tabMaster.Name = "tabMaster";
			("tabMaster.OcxState");
			this.tabMaster.Size = new System.Drawing.Size(633, 245);
			this.tabMaster.TabIndex = 7;
			this.tabMaster.SelectedChanged += new AxXtremeSuiteControls._DTabControlEvents_SelectedChangedEventHandler(this.tabMaster_SelectedChanged);
			// 
			// _fraLedgerInformation_3
			// 
			this._fraLedgerInformation_3.AllowDrop = true;
			this._fraLedgerInformation_3.Controls.Add(this.cmbPriceList);
			this._fraLedgerInformation_3.Controls.Add(this.grdActivityDetails);
			this._fraLedgerInformation_3.Location = new System.Drawing.Point(-4664, 28);
			this._fraLedgerInformation_3.Name = "_fraLedgerInformation_3";
			("_fraLedgerInformation_3.OcxState");
			this._fraLedgerInformation_3.Size = new System.Drawing.Size(629, 215);
			this._fraLedgerInformation_3.TabIndex = 60;
			this._fraLedgerInformation_3.Visible = false;
			// 
			// cmbPriceList
			// 
			this.cmbPriceList.AllowDrop = true;
			this.cmbPriceList.ColumnHeaders = true;
			this.cmbPriceList.Enabled = true;
			this.cmbPriceList.Location = new System.Drawing.Point(11, 22);
			this.cmbPriceList.Name = "cmbPriceList";
			this.cmbPriceList.Size = new System.Drawing.Size(267, 105);
			this.cmbPriceList.TabIndex = 70;
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
			// grdActivityDetails
			// 
			this.grdActivityDetails.AllowAddNew = true;
			this.grdActivityDetails.AllowDelete = true;
			this.grdActivityDetails.AllowDrop = true;
			this.grdActivityDetails.BackColor = System.Drawing.Color.Silver;
			this.grdActivityDetails.CellTipsWidth = 0;
			this.grdActivityDetails.Location = new System.Drawing.Point(0, 0);
			this.grdActivityDetails.Name = "grdActivityDetails";
			this.grdActivityDetails.RowDivider.Color = System.Drawing.Color.Silver;
			this.grdActivityDetails.Size = new System.Drawing.Size(629, 213);
			this.grdActivityDetails.TabIndex = 71;
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
			// _fraLedgerInformation_2
			// 
			this._fraLedgerInformation_2.AllowDrop = true;
			this._fraLedgerInformation_2.Controls.Add(this._lblCommon_40);
			this._fraLedgerInformation_2.Controls.Add(this.txtWIPCd);
			this._fraLedgerInformation_2.Controls.Add(this.txtBillingCodeName);
			this._fraLedgerInformation_2.Controls.Add(this._lblCommon_42);
			this._fraLedgerInformation_2.Controls.Add(this.txtWIPCodeName);
			this._fraLedgerInformation_2.Controls.Add(this.txtReceivableCd);
			this._fraLedgerInformation_2.Controls.Add(this._lblCommon_4);
			this._fraLedgerInformation_2.Controls.Add(this.txtReceivableCodeName);
			this._fraLedgerInformation_2.Controls.Add(this.txtBillingCd);
			this._fraLedgerInformation_2.Location = new System.Drawing.Point(-4664, 28);
			this._fraLedgerInformation_2.Name = "_fraLedgerInformation_2";
			("_fraLedgerInformation_2.OcxState");
			this._fraLedgerInformation_2.Size = new System.Drawing.Size(629, 215);
			this._fraLedgerInformation_2.TabIndex = 59;
			this._fraLedgerInformation_2.Visible = false;
			// 
			// _lblCommon_40
			// 
			this._lblCommon_40.AllowDrop = true;
			this._lblCommon_40.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_40.Text = "Billing Code";
			this._lblCommon_40.Location = new System.Drawing.Point(22, 22);
			this._lblCommon_40.Name = "_lblCommon_40";
			this._lblCommon_40.Size = new System.Drawing.Size(55, 14);
			this._lblCommon_40.TabIndex = 61;
			// 
			// txtWIPCd
			// 
			this.txtWIPCd.AllowDrop = true;
			this.txtWIPCd.BackColor = System.Drawing.Color.White;
			this.txtWIPCd.ForeColor = System.Drawing.Color.Black;
			this.txtWIPCd.Location = new System.Drawing.Point(112, 41);
			this.txtWIPCd.Name = "txtWIPCd";
			// this.txtWIPCd.ShowButton = true;
			this.txtWIPCd.Size = new System.Drawing.Size(101, 19);
			this.txtWIPCd.TabIndex = 62;
			this.txtWIPCd.Text = "";
			// this.this.txtWIPCd.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtWIPCd_DropButtonClick);
			// this.txtWIPCd.Leave += new System.EventHandler(this.txtWIPCd_Leave);
			// 
			// txtBillingCodeName
			// 
			this.txtBillingCodeName.AllowDrop = true;
			this.txtBillingCodeName.Location = new System.Drawing.Point(215, 20);
			this.txtBillingCodeName.Name = "txtBillingCodeName";
			this.txtBillingCodeName.Size = new System.Drawing.Size(201, 19);
			this.txtBillingCodeName.TabIndex = 63;
			// 
			// _lblCommon_42
			// 
			this._lblCommon_42.AllowDrop = true;
			this._lblCommon_42.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_42.Text = "WIP Code";
			this._lblCommon_42.Location = new System.Drawing.Point(22, 43);
			this._lblCommon_42.Name = "_lblCommon_42";
			this._lblCommon_42.Size = new System.Drawing.Size(46, 14);
			this._lblCommon_42.TabIndex = 64;
			// 
			// txtWIPCodeName
			// 
			this.txtWIPCodeName.AllowDrop = true;
			this.txtWIPCodeName.Location = new System.Drawing.Point(215, 41);
			this.txtWIPCodeName.Name = "txtWIPCodeName";
			this.txtWIPCodeName.Size = new System.Drawing.Size(201, 19);
			this.txtWIPCodeName.TabIndex = 65;
			// 
			// txtReceivableCd
			// 
			this.txtReceivableCd.AllowDrop = true;
			this.txtReceivableCd.BackColor = System.Drawing.Color.White;
			this.txtReceivableCd.ForeColor = System.Drawing.Color.Black;
			this.txtReceivableCd.Location = new System.Drawing.Point(112, 62);
			this.txtReceivableCd.Name = "txtReceivableCd";
			// this.txtReceivableCd.ShowButton = true;
			this.txtReceivableCd.Size = new System.Drawing.Size(101, 19);
			this.txtReceivableCd.TabIndex = 66;
			this.txtReceivableCd.Text = "";
			// this.this.txtReceivableCd.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtReceivableCd_DropButtonClick);
			// this.txtReceivableCd.Leave += new System.EventHandler(this.txtReceivableCd_Leave);
			// 
			// _lblCommon_4
			// 
			this._lblCommon_4.AllowDrop = true;
			this._lblCommon_4.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_4.Text = "Receivable Code";
			this._lblCommon_4.Location = new System.Drawing.Point(22, 64);
			this._lblCommon_4.Name = "_lblCommon_4";
			this._lblCommon_4.Size = new System.Drawing.Size(81, 14);
			this._lblCommon_4.TabIndex = 67;
			// 
			// txtReceivableCodeName
			// 
			this.txtReceivableCodeName.AllowDrop = true;
			this.txtReceivableCodeName.Location = new System.Drawing.Point(215, 62);
			this.txtReceivableCodeName.Name = "txtReceivableCodeName";
			this.txtReceivableCodeName.Size = new System.Drawing.Size(201, 19);
			this.txtReceivableCodeName.TabIndex = 68;
			// 
			// txtBillingCd
			// 
			this.txtBillingCd.AllowDrop = true;
			this.txtBillingCd.BackColor = System.Drawing.Color.White;
			this.txtBillingCd.ForeColor = System.Drawing.Color.Black;
			this.txtBillingCd.Location = new System.Drawing.Point(112, 20);
			this.txtBillingCd.MaxLength = 15;
			this.txtBillingCd.Name = "txtBillingCd";
			// this.txtBillingCd.ShowButton = true;
			this.txtBillingCd.Size = new System.Drawing.Size(101, 19);
			this.txtBillingCd.TabIndex = 69;
			this.txtBillingCd.Text = "";
			// this.this.txtBillingCd.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtBillingCd_DropButtonClick);
			// this.txtBillingCd.Leave += new System.EventHandler(this.txtBillingCd_Leave);
			// 
			// _fraLedgerInformation_1
			// 
			this._fraLedgerInformation_1.AllowDrop = true;
			this._fraLedgerInformation_1.Controls.Add(this.txtWeb);
			this._fraLedgerInformation_1.Controls.Add(this.txtEmailAddress);
			this._fraLedgerInformation_1.Controls.Add(this.txtFax);
			this._fraLedgerInformation_1.Controls.Add(this.txtMobile);
			this._fraLedgerInformation_1.Controls.Add(this.txtPhone);
			this._fraLedgerInformation_1.Controls.Add(this.txtCountry);
			this._fraLedgerInformation_1.Controls.Add(this.txtAAdd3);
			this._fraLedgerInformation_1.Controls.Add(this.txtAAdd2);
			this._fraLedgerInformation_1.Controls.Add(this.txtAAdd1);
			this._fraLedgerInformation_1.Controls.Add(this.txtLAdd3);
			this._fraLedgerInformation_1.Controls.Add(this.txtLAdd2);
			this._fraLedgerInformation_1.Controls.Add(this.txtSupervisorName);
			this._fraLedgerInformation_1.Controls.Add(this.txtCity);
			this._fraLedgerInformation_1.Controls.Add(this.txtLAdd1);
			this._fraLedgerInformation_1.Controls.Add(this._lblCommon_11);
			this._fraLedgerInformation_1.Controls.Add(this._lblCommon_12);
			this._fraLedgerInformation_1.Controls.Add(this._lblCommon_13);
			this._fraLedgerInformation_1.Controls.Add(this._lblCommon_14);
			this._fraLedgerInformation_1.Controls.Add(this._lblCommon_15);
			this._fraLedgerInformation_1.Controls.Add(this._lblCommon_16);
			this._fraLedgerInformation_1.Controls.Add(this._lblCommon_17);
			this._fraLedgerInformation_1.Controls.Add(this._lblCommon_19);
			this._fraLedgerInformation_1.Controls.Add(this._lblCommon_20);
			this._fraLedgerInformation_1.Controls.Add(this._lblCommon_21);
			this._fraLedgerInformation_1.Controls.Add(this._lblCommon_33);
			this._fraLedgerInformation_1.Controls.Add(this._lblCommon_34);
			this._fraLedgerInformation_1.Controls.Add(this._lblCommon_35);
			this._fraLedgerInformation_1.Controls.Add(this._lblCommon_39);
			this._fraLedgerInformation_1.Location = new System.Drawing.Point(-4664, 28);
			this._fraLedgerInformation_1.Name = "_fraLedgerInformation_1";
			("_fraLedgerInformation_1.OcxState");
			this._fraLedgerInformation_1.Size = new System.Drawing.Size(629, 215);
			this._fraLedgerInformation_1.TabIndex = 9;
			this._fraLedgerInformation_1.Visible = false;
			// 
			// txtWeb
			// 
			this.txtWeb.AllowDrop = true;
			this.txtWeb.BackColor = System.Drawing.Color.White;
			this.txtWeb.ForeColor = System.Drawing.Color.Black;
			this.txtWeb.Location = new System.Drawing.Point(448, 154);
			this.txtWeb.Name = "txtWeb";
			this.txtWeb.Size = new System.Drawing.Size(173, 19);
			this.txtWeb.TabIndex = 31;
			this.txtWeb.Text = "";
			// 
			// txtEmailAddress
			// 
			this.txtEmailAddress.AllowDrop = true;
			this.txtEmailAddress.BackColor = System.Drawing.Color.White;
			this.txtEmailAddress.ForeColor = System.Drawing.Color.Black;
			this.txtEmailAddress.Location = new System.Drawing.Point(448, 129);
			this.txtEmailAddress.Name = "txtEmailAddress";
			this.txtEmailAddress.Size = new System.Drawing.Size(173, 19);
			this.txtEmailAddress.TabIndex = 32;
			this.txtEmailAddress.Text = "";
			// 
			// txtFax
			// 
			this.txtFax.AllowDrop = true;
			this.txtFax.BackColor = System.Drawing.Color.White;
			this.txtFax.ForeColor = System.Drawing.Color.Black;
			this.txtFax.Location = new System.Drawing.Point(448, 106);
			this.txtFax.Name = "txtFax";
			this.txtFax.Size = new System.Drawing.Size(173, 19);
			this.txtFax.TabIndex = 33;
			this.txtFax.Text = "";
			// 
			// txtMobile
			// 
			this.txtMobile.AllowDrop = true;
			this.txtMobile.BackColor = System.Drawing.Color.White;
			this.txtMobile.ForeColor = System.Drawing.Color.Black;
			this.txtMobile.Location = new System.Drawing.Point(448, 81);
			this.txtMobile.Name = "txtMobile";
			this.txtMobile.Size = new System.Drawing.Size(173, 19);
			this.txtMobile.TabIndex = 34;
			this.txtMobile.Text = "";
			// 
			// txtPhone
			// 
			this.txtPhone.AllowDrop = true;
			this.txtPhone.BackColor = System.Drawing.Color.White;
			this.txtPhone.ForeColor = System.Drawing.Color.Black;
			this.txtPhone.Location = new System.Drawing.Point(448, 58);
			this.txtPhone.Name = "txtPhone";
			this.txtPhone.Size = new System.Drawing.Size(173, 19);
			this.txtPhone.TabIndex = 35;
			this.txtPhone.Text = "";
			// 
			// txtCountry
			// 
			this.txtCountry.AllowDrop = true;
			this.txtCountry.BackColor = System.Drawing.Color.White;
			this.txtCountry.ForeColor = System.Drawing.Color.Black;
			this.txtCountry.Location = new System.Drawing.Point(448, 35);
			this.txtCountry.Name = "txtCountry";
			this.txtCountry.Size = new System.Drawing.Size(173, 19);
			this.txtCountry.TabIndex = 36;
			this.txtCountry.Text = "";
			// 
			// txtAAdd3
			// 
			this.txtAAdd3.AllowDrop = true;
			this.txtAAdd3.BackColor = System.Drawing.Color.White;
			// this.txtAAdd3.bolAllowDecimal = false;
			this.txtAAdd3.ForeColor = System.Drawing.Color.Black;
			this.txtAAdd3.Location = new System.Drawing.Point(126, 129);
			// this.txtAAdd3.mArabicEnabled = true;
			// this.txtAAdd3.mDropDownType = (System.Windows.Forms.TextBox.DropDownTypes) 0;
			this.txtAAdd3.Name = "txtAAdd3";
			this.txtAAdd3.Size = new System.Drawing.Size(173, 19);
			this.txtAAdd3.TabIndex = 37;
			this.txtAAdd3.Text = "";
			// 
			// txtAAdd2
			// 
			this.txtAAdd2.AllowDrop = true;
			this.txtAAdd2.BackColor = System.Drawing.Color.White;
			// this.txtAAdd2.bolAllowDecimal = false;
			this.txtAAdd2.ForeColor = System.Drawing.Color.Black;
			this.txtAAdd2.Location = new System.Drawing.Point(126, 106);
			// this.txtAAdd2.mArabicEnabled = true;
			// this.txtAAdd2.mDropDownType = (System.Windows.Forms.TextBox.DropDownTypes) 0;
			this.txtAAdd2.Name = "txtAAdd2";
			this.txtAAdd2.Size = new System.Drawing.Size(173, 19);
			this.txtAAdd2.TabIndex = 38;
			this.txtAAdd2.Text = "";
			// 
			// txtAAdd1
			// 
			this.txtAAdd1.AllowDrop = true;
			this.txtAAdd1.BackColor = System.Drawing.Color.White;
			// this.txtAAdd1.bolAllowDecimal = false;
			this.txtAAdd1.ForeColor = System.Drawing.Color.Black;
			this.txtAAdd1.Location = new System.Drawing.Point(126, 81);
			// this.txtAAdd1.mArabicEnabled = true;
			// this.txtAAdd1.mDropDownType = (System.Windows.Forms.TextBox.DropDownTypes) 0;
			this.txtAAdd1.Name = "txtAAdd1";
			this.txtAAdd1.Size = new System.Drawing.Size(173, 19);
			this.txtAAdd1.TabIndex = 39;
			this.txtAAdd1.Text = "";
			// 
			// txtLAdd3
			// 
			this.txtLAdd3.AllowDrop = true;
			this.txtLAdd3.BackColor = System.Drawing.Color.White;
			// this.txtLAdd3.bolAllowDecimal = false;
			this.txtLAdd3.ForeColor = System.Drawing.Color.Black;
			this.txtLAdd3.Location = new System.Drawing.Point(126, 58);
			// this.txtLAdd3.mDropDownType = (System.Windows.Forms.TextBox.DropDownTypes) 0;
			this.txtLAdd3.Name = "txtLAdd3";
			this.txtLAdd3.Size = new System.Drawing.Size(173, 19);
			this.txtLAdd3.TabIndex = 40;
			this.txtLAdd3.Text = "";
			// 
			// txtLAdd2
			// 
			this.txtLAdd2.AllowDrop = true;
			this.txtLAdd2.BackColor = System.Drawing.Color.White;
			this.txtLAdd2.ForeColor = System.Drawing.Color.Black;
			this.txtLAdd2.Location = new System.Drawing.Point(126, 35);
			this.txtLAdd2.Name = "txtLAdd2";
			this.txtLAdd2.Size = new System.Drawing.Size(173, 19);
			this.txtLAdd2.TabIndex = 41;
			this.txtLAdd2.Text = "";
			// 
			// txtSupervisorName
			// 
			this.txtSupervisorName.AllowDrop = true;
			this.txtSupervisorName.BackColor = System.Drawing.Color.White;
			this.txtSupervisorName.ForeColor = System.Drawing.Color.Black;
			this.txtSupervisorName.Location = new System.Drawing.Point(126, 152);
			this.txtSupervisorName.Name = "txtSupervisorName";
			this.txtSupervisorName.Size = new System.Drawing.Size(173, 19);
			this.txtSupervisorName.TabIndex = 42;
			this.txtSupervisorName.Text = "";
			// 
			// txtCity
			// 
			this.txtCity.AllowDrop = true;
			this.txtCity.BackColor = System.Drawing.Color.White;
			this.txtCity.ForeColor = System.Drawing.Color.Black;
			this.txtCity.Location = new System.Drawing.Point(448, 10);
			this.txtCity.Name = "txtCity";
			this.txtCity.Size = new System.Drawing.Size(173, 19);
			this.txtCity.TabIndex = 43;
			this.txtCity.Text = "";
			// 
			// txtLAdd1
			// 
			this.txtLAdd1.AllowDrop = true;
			this.txtLAdd1.BackColor = System.Drawing.Color.White;
			this.txtLAdd1.ForeColor = System.Drawing.Color.Black;
			this.txtLAdd1.Location = new System.Drawing.Point(126, 10);
			this.txtLAdd1.Name = "txtLAdd1";
			this.txtLAdd1.Size = new System.Drawing.Size(173, 19);
			this.txtLAdd1.TabIndex = 44;
			this.txtLAdd1.Text = "";
			// 
			// _lblCommon_11
			// 
			this._lblCommon_11.AllowDrop = true;
			this._lblCommon_11.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_11.Text = "Address 1 (English)";
			this._lblCommon_11.Location = new System.Drawing.Point(18, 12);
			this._lblCommon_11.Name = "_lblCommon_11";
			this._lblCommon_11.Size = new System.Drawing.Size(96, 14);
			this._lblCommon_11.TabIndex = 45;
			// 
			// _lblCommon_12
			// 
			this._lblCommon_12.AllowDrop = true;
			this._lblCommon_12.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_12.Text = "Address 2 (English)";
			this._lblCommon_12.Location = new System.Drawing.Point(18, 38);
			this._lblCommon_12.Name = "_lblCommon_12";
			this._lblCommon_12.Size = new System.Drawing.Size(96, 14);
			this._lblCommon_12.TabIndex = 46;
			// 
			// _lblCommon_13
			// 
			this._lblCommon_13.AllowDrop = true;
			this._lblCommon_13.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_13.Text = "Address 3 (English)";
			this._lblCommon_13.Location = new System.Drawing.Point(18, 61);
			this._lblCommon_13.Name = "_lblCommon_13";
			this._lblCommon_13.Size = new System.Drawing.Size(96, 14);
			this._lblCommon_13.TabIndex = 47;
			// 
			// _lblCommon_14
			// 
			this._lblCommon_14.AllowDrop = true;
			this._lblCommon_14.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_14.Text = "Supervisor Name";
			this._lblCommon_14.Location = new System.Drawing.Point(18, 154);
			this._lblCommon_14.Name = "_lblCommon_14";
			this._lblCommon_14.Size = new System.Drawing.Size(83, 14);
			this._lblCommon_14.TabIndex = 48;
			// 
			// _lblCommon_15
			// 
			this._lblCommon_15.AllowDrop = true;
			this._lblCommon_15.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_15.Text = "Mobile";
			this._lblCommon_15.Location = new System.Drawing.Point(366, 86);
			this._lblCommon_15.Name = "_lblCommon_15";
			this._lblCommon_15.Size = new System.Drawing.Size(30, 14);
			this._lblCommon_15.TabIndex = 49;
			// 
			// _lblCommon_16
			// 
			this._lblCommon_16.AllowDrop = true;
			this._lblCommon_16.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_16.Text = "Country";
			this._lblCommon_16.Location = new System.Drawing.Point(366, 38);
			this._lblCommon_16.Name = "_lblCommon_16";
			this._lblCommon_16.Size = new System.Drawing.Size(38, 14);
			this._lblCommon_16.TabIndex = 50;
			// 
			// _lblCommon_17
			// 
			this._lblCommon_17.AllowDrop = true;
			this._lblCommon_17.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_17.Text = "City";
			this._lblCommon_17.Location = new System.Drawing.Point(366, 12);
			this._lblCommon_17.Name = "_lblCommon_17";
			this._lblCommon_17.Size = new System.Drawing.Size(18, 14);
			this._lblCommon_17.TabIndex = 51;
			// 
			// _lblCommon_19
			// 
			this._lblCommon_19.AllowDrop = true;
			this._lblCommon_19.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_19.Text = "Web Address";
			this._lblCommon_19.Location = new System.Drawing.Point(366, 157);
			this._lblCommon_19.Name = "_lblCommon_19";
			this._lblCommon_19.Size = new System.Drawing.Size(67, 14);
			this._lblCommon_19.TabIndex = 52;
			// 
			// _lblCommon_20
			// 
			this._lblCommon_20.AllowDrop = true;
			this._lblCommon_20.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_20.Text = "Email Address";
			this._lblCommon_20.Location = new System.Drawing.Point(366, 132);
			this._lblCommon_20.Name = "_lblCommon_20";
			this._lblCommon_20.Size = new System.Drawing.Size(69, 14);
			this._lblCommon_20.TabIndex = 53;
			// 
			// _lblCommon_21
			// 
			this._lblCommon_21.AllowDrop = true;
			this._lblCommon_21.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_21.Text = "Phone";
			this._lblCommon_21.Location = new System.Drawing.Point(366, 61);
			this._lblCommon_21.Name = "_lblCommon_21";
			this._lblCommon_21.Size = new System.Drawing.Size(30, 14);
			this._lblCommon_21.TabIndex = 54;
			// 
			// _lblCommon_33
			// 
			this._lblCommon_33.AllowDrop = true;
			this._lblCommon_33.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_33.Text = "Address 1 (Arabic)";
			this._lblCommon_33.Location = new System.Drawing.Point(18, 84);
			this._lblCommon_33.Name = "_lblCommon_33";
			this._lblCommon_33.Size = new System.Drawing.Size(94, 14);
			this._lblCommon_33.TabIndex = 55;
			// 
			// _lblCommon_34
			// 
			this._lblCommon_34.AllowDrop = true;
			this._lblCommon_34.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_34.Text = "Address 2 (Arabic)";
			this._lblCommon_34.Location = new System.Drawing.Point(18, 109);
			this._lblCommon_34.Name = "_lblCommon_34";
			this._lblCommon_34.Size = new System.Drawing.Size(94, 14);
			this._lblCommon_34.TabIndex = 56;
			// 
			// _lblCommon_35
			// 
			this._lblCommon_35.AllowDrop = true;
			this._lblCommon_35.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_35.Text = "Address 3 (Arabic)";
			this._lblCommon_35.Location = new System.Drawing.Point(18, 132);
			this._lblCommon_35.Name = "_lblCommon_35";
			this._lblCommon_35.Size = new System.Drawing.Size(94, 14);
			this._lblCommon_35.TabIndex = 57;
			// 
			// _lblCommon_39
			// 
			this._lblCommon_39.AllowDrop = true;
			this._lblCommon_39.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_39.Text = "Fax";
			this._lblCommon_39.Location = new System.Drawing.Point(366, 109);
			this._lblCommon_39.Name = "_lblCommon_39";
			this._lblCommon_39.Size = new System.Drawing.Size(18, 14);
			this._lblCommon_39.TabIndex = 58;
			// 
			// _fraLedgerInformation_0
			// 
			this._fraLedgerInformation_0.AllowDrop = true;
			this._fraLedgerInformation_0.Controls.Add(this.txtComment);
			this._fraLedgerInformation_0.Controls.Add(this.fraProjectCompletedDetails);
			this._fraLedgerInformation_0.Controls.Add(this._lblCommon_5);
			this._fraLedgerInformation_0.Controls.Add(this._lblCommon_6);
			this._fraLedgerInformation_0.Controls.Add(this._lblCommon_7);
			this._fraLedgerInformation_0.Controls.Add(this._lblCommon_8);
			this._fraLedgerInformation_0.Controls.Add(this._lblCommon_10);
			this._fraLedgerInformation_0.Controls.Add(this.Label1);
			this._fraLedgerInformation_0.Controls.Add(this.txtEstimatedIncome);
			this._fraLedgerInformation_0.Controls.Add(this.txtParentProjectNo);
			this._fraLedgerInformation_0.Controls.Add(this.txtExtimatedExp);
			this._fraLedgerInformation_0.Controls.Add(this.txtProjectType);
			this._fraLedgerInformation_0.Controls.Add(this.txtEndDate);
			this._fraLedgerInformation_0.Controls.Add(this.txtStartDate);
			this._fraLedgerInformation_0.Controls.Add(this.txtParentProjectName);
			this._fraLedgerInformation_0.Controls.Add(this.txtProjectTypeName);
			this._fraLedgerInformation_0.Controls.Add(this.Label2);
			this._fraLedgerInformation_0.Location = new System.Drawing.Point(2, 28);
			this._fraLedgerInformation_0.Name = "_fraLedgerInformation_0";
			("_fraLedgerInformation_0.OcxState");
			this._fraLedgerInformation_0.Size = new System.Drawing.Size(629, 215);
			this._fraLedgerInformation_0.TabIndex = 8;
			// 
			// txtComment
			// 
			this.txtComment.AcceptsReturn = true;
			this.txtComment.AllowDrop = true;
			this.txtComment.BackColor = System.Drawing.Color.White;
			this.txtComment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtComment.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtComment.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtComment.Location = new System.Drawing.Point(94, 113);
			this.txtComment.MaxLength = 100;
			this.txtComment.Multiline = true;
			this.txtComment.Name = "txtComment";
			this.txtComment.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtComment.Size = new System.Drawing.Size(530, 59);
			this.txtComment.TabIndex = 15;
			// 
			// fraProjectCompletedDetails
			// 
			this.fraProjectCompletedDetails.AllowDrop = true;
			this.fraProjectCompletedDetails.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.fraProjectCompletedDetails.Controls.Add(this._lblCommon_9);
			this.fraProjectCompletedDetails.Controls.Add(this._lblCommon_24);
			this.fraProjectCompletedDetails.Controls.Add(this._txt_2);
			this.fraProjectCompletedDetails.Controls.Add(this.txtPercentCompleted);
			this.fraProjectCompletedDetails.Enabled = true;
			this.fraProjectCompletedDetails.ForeColor = System.Drawing.Color.Navy;
			this.fraProjectCompletedDetails.Location = new System.Drawing.Point(407, 14);
			this.fraProjectCompletedDetails.Name = "fraProjectCompletedDetails";
			this.fraProjectCompletedDetails.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.fraProjectCompletedDetails.Size = new System.Drawing.Size(217, 83);
			this.fraProjectCompletedDetails.TabIndex = 10;
			this.fraProjectCompletedDetails.Text = "Project Completed Details";
			this.fraProjectCompletedDetails.Visible = true;
			// 
			// _lblCommon_9
			// 
			this._lblCommon_9.AllowDrop = true;
			this._lblCommon_9.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_9.Text = "Upto Project Value";
			this._lblCommon_9.Location = new System.Drawing.Point(10, 42);
			this._lblCommon_9.Name = "_lblCommon_9";
			this._lblCommon_9.Size = new System.Drawing.Size(89, 14);
			this._lblCommon_9.TabIndex = 11;
			// 
			// _lblCommon_24
			// 
			this._lblCommon_24.AllowDrop = true;
			this._lblCommon_24.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_24.Text = "Completed (%)";
			this._lblCommon_24.Location = new System.Drawing.Point(10, 63);
			this._lblCommon_24.Name = "_lblCommon_24";
			this._lblCommon_24.Size = new System.Drawing.Size(71, 14);
			this._lblCommon_24.TabIndex = 12;
			// 
			// _txt_2
			// 
			this._txt_2.AllowDrop = true;
			this._txt_2.Location = new System.Drawing.Point(121, 40);
			this._txt_2.Name = "_txt_2";
			this._txt_2.Size = new System.Drawing.Size(91, 19);
			this._txt_2.TabIndex = 13;
			// 
			// txtPercentCompleted
			// 
			this.txtPercentCompleted.AllowDrop = true;
			this.txtPercentCompleted.Location = new System.Drawing.Point(121, 61);
			this.txtPercentCompleted.Name = "txtPercentCompleted";
			this.txtPercentCompleted.Size = new System.Drawing.Size(91, 19);
			this.txtPercentCompleted.TabIndex = 14;
			// 
			// _lblCommon_5
			// 
			this._lblCommon_5.AllowDrop = true;
			this._lblCommon_5.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_5.Text = "Project Group";
			this._lblCommon_5.Location = new System.Drawing.Point(4, 20);
			this._lblCommon_5.Name = "_lblCommon_5";
			this._lblCommon_5.Size = new System.Drawing.Size(66, 14);
			this._lblCommon_5.TabIndex = 16;
			// 
			// _lblCommon_6
			// 
			this._lblCommon_6.AllowDrop = true;
			this._lblCommon_6.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_6.Text = "Revenues";
			this._lblCommon_6.Location = new System.Drawing.Point(233, 83);
			this._lblCommon_6.Name = "_lblCommon_6";
			this._lblCommon_6.Size = new System.Drawing.Size(49, 14);
			this._lblCommon_6.TabIndex = 17;
			// 
			// _lblCommon_7
			// 
			this._lblCommon_7.AllowDrop = true;
			this._lblCommon_7.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_7.Text = "Project Type";
			this._lblCommon_7.Location = new System.Drawing.Point(4, 41);
			this._lblCommon_7.Name = "_lblCommon_7";
			this._lblCommon_7.Size = new System.Drawing.Size(60, 14);
			this._lblCommon_7.TabIndex = 18;
			// 
			// _lblCommon_8
			// 
			this._lblCommon_8.AllowDrop = true;
			this._lblCommon_8.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_8.Text = "Project Details";
			this._lblCommon_8.Location = new System.Drawing.Point(4, 113);
			this._lblCommon_8.Name = "_lblCommon_8";
			this._lblCommon_8.Size = new System.Drawing.Size(68, 14);
			this._lblCommon_8.TabIndex = 19;
			// 
			// _lblCommon_10
			// 
			this._lblCommon_10.AllowDrop = true;
			this._lblCommon_10.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_10.Text = "Estimated Value";
			this._lblCommon_10.Location = new System.Drawing.Point(4, 83);
			this._lblCommon_10.Name = "_lblCommon_10";
			this._lblCommon_10.Size = new System.Drawing.Size(77, 14);
			this._lblCommon_10.TabIndex = 20;
			// 
			// System.Windows.Forms.Label1
			// 
			this.Label1.AllowDrop = true;
			this.Label1.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.Label1.Text = "Start Date";
			this.Label1.Location = new System.Drawing.Point(4, 63);
			this.Label1.Name = "System.Windows.Forms.Label1";
			this.Label1.Size = new System.Drawing.Size(50, 13);
			this.Label1.TabIndex = 21;
			// 
			// txtEstimatedIncome
			// 
			this.txtEstimatedIncome.AllowDrop = true;
			// this.txtEstimatedIncome.DisplayFormat = "########0.000###;;0.000;0.000";
			// this.txtEstimatedIncome.Format = "###########0.000";
			this.txtEstimatedIncome.Location = new System.Drawing.Point(297, 81);
			// this.txtEstimatedIncome.MaxValue = 2147483647;
			// this.txtEstimatedIncome.MinValue = 0;
			this.txtEstimatedIncome.Name = "txtEstimatedIncome";
			this.txtEstimatedIncome.Size = new System.Drawing.Size(101, 19);
			this.txtEstimatedIncome.TabIndex = 22;
			this.txtEstimatedIncome.Text = "0.000";
			// 
			// txtParentProjectNo
			// 
			this.txtParentProjectNo.AllowDrop = true;
			this.txtParentProjectNo.BackColor = System.Drawing.Color.White;
			// this.txtParentProjectNo.bolNumericOnly = true;
			this.txtParentProjectNo.ForeColor = System.Drawing.Color.Black;
			this.txtParentProjectNo.Location = new System.Drawing.Point(94, 18);
			this.txtParentProjectNo.MaxLength = 15;
			this.txtParentProjectNo.Name = "txtParentProjectNo";
			// this.txtParentProjectNo.ShowButton = true;
			this.txtParentProjectNo.Size = new System.Drawing.Size(101, 19);
			this.txtParentProjectNo.TabIndex = 23;
			this.txtParentProjectNo.Text = "";
			// this.this.txtParentProjectNo.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtParentProjectNo_DropButtonClick);
			// this.txtParentProjectNo.Leave += new System.EventHandler(this.txtParentProjectNo_Leave);
			// 
			// txtExtimatedExp
			// 
			this.txtExtimatedExp.AllowDrop = true;
			this.txtExtimatedExp.BackColor = System.Drawing.Color.White;
			// this.txtExtimatedExp.DisplayFormat = "########0.000###;;0.000;0.000";
			// this.txtExtimatedExp.Format = "###########0.000";
			this.txtExtimatedExp.Location = new System.Drawing.Point(94, 81);
			// this.txtExtimatedExp.MaxValue = 2147483647;
			// this.txtExtimatedExp.MinValue = 0;
			this.txtExtimatedExp.Name = "txtExtimatedExp";
			this.txtExtimatedExp.Size = new System.Drawing.Size(101, 19);
			this.txtExtimatedExp.TabIndex = 24;
			this.txtExtimatedExp.Text = "0.000";
			// 
			// txtProjectType
			// 
			this.txtProjectType.AllowDrop = true;
			this.txtProjectType.BackColor = System.Drawing.Color.White;
			// this.txtProjectType.bolNumericOnly = true;
			this.txtProjectType.ForeColor = System.Drawing.Color.Black;
			this.txtProjectType.Location = new System.Drawing.Point(94, 39);
			this.txtProjectType.Name = "txtProjectType";
			// this.txtProjectType.ShowButton = true;
			this.txtProjectType.Size = new System.Drawing.Size(101, 19);
			this.txtProjectType.TabIndex = 25;
			this.txtProjectType.Text = "";
			// this.this.txtProjectType.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtProjectType_DropButtonClick);
			// this.txtProjectType.Leave += new System.EventHandler(this.txtProjectType_Leave);
			// 
			// txtEndDate
			// 
			this.txtEndDate.AllowDrop = true;
			// this.txtEndDate.CheckDateRange = false;
			this.txtEndDate.Location = new System.Drawing.Point(297, 60);
			// this.txtEndDate.MaxDate = 2958465;
			// this.txtEndDate.MinDate = 2;
			this.txtEndDate.Name = "txtEndDate";
			this.txtEndDate.Size = new System.Drawing.Size(101, 19);
			this.txtEndDate.TabIndex = 26;
			this.txtEndDate.Text = "8/6/2003";
			// this.txtEndDate.Value = 37839;
			// 
			// txtStartDate
			// 
			this.txtStartDate.AllowDrop = true;
			// this.txtStartDate.CheckDateRange = false;
			this.txtStartDate.Location = new System.Drawing.Point(94, 60);
			// this.txtStartDate.MaxDate = 2958465;
			// this.txtStartDate.MinDate = 2;
			this.txtStartDate.Name = "txtStartDate";
			this.txtStartDate.Size = new System.Drawing.Size(101, 19);
			this.txtStartDate.TabIndex = 27;
			this.txtStartDate.Text = "8/6/2003";
			// this.txtStartDate.Value = 37839;
			// 
			// txtParentProjectName
			// 
			this.txtParentProjectName.AllowDrop = true;
			this.txtParentProjectName.Location = new System.Drawing.Point(198, 18);
			this.txtParentProjectName.Name = "txtParentProjectName";
			this.txtParentProjectName.Size = new System.Drawing.Size(201, 19);
			this.txtParentProjectName.TabIndex = 28;
			// 
			// txtProjectTypeName
			// 
			this.txtProjectTypeName.AllowDrop = true;
			this.txtProjectTypeName.Location = new System.Drawing.Point(198, 38);
			this.txtProjectTypeName.Name = "txtProjectTypeName";
			this.txtProjectTypeName.Size = new System.Drawing.Size(201, 19);
			this.txtProjectTypeName.TabIndex = 29;
			// 
			// System.Windows.Forms.Label2
			// 
			this.Label2.AllowDrop = true;
			this.Label2.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.Label2.Text = "End Date";
			this.Label2.Location = new System.Drawing.Point(234, 62);
			this.Label2.Name = "System.Windows.Forms.Label2";
			this.Label2.Size = new System.Drawing.Size(44, 13);
			this.Label2.TabIndex = 30;
			// 
			// txtLProjectName
			// 
			this.txtLProjectName.AllowDrop = true;
			this.txtLProjectName.BackColor = System.Drawing.Color.White;
			this.txtLProjectName.ForeColor = System.Drawing.Color.Black;
			this.txtLProjectName.Location = new System.Drawing.Point(374, 44);
			this.txtLProjectName.MaxLength = 50;
			this.txtLProjectName.Name = "txtLProjectName";
			this.txtLProjectName.Size = new System.Drawing.Size(201, 19);
			this.txtLProjectName.TabIndex = 1;
			this.txtLProjectName.Text = "";
			// 
			// txtAprojectName
			// 
			this.txtAprojectName.AllowDrop = true;
			this.txtAprojectName.BackColor = System.Drawing.Color.White;
			this.txtAprojectName.ForeColor = System.Drawing.Color.Black;
			this.txtAprojectName.Location = new System.Drawing.Point(374, 65);
			// this.txtAprojectName.mArabicEnabled = true;
			this.txtAprojectName.MaxLength = 50;
			this.txtAprojectName.Name = "txtAprojectName";
			this.txtAprojectName.Size = new System.Drawing.Size(201, 19);
			this.txtAprojectName.TabIndex = 2;
			this.txtAprojectName.Text = "";
			// 
			// _lblCommon_0
			// 
			this._lblCommon_0.AllowDrop = true;
			this._lblCommon_0.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_0.Text = "Project Code";
			this._lblCommon_0.Location = new System.Drawing.Point(8, 46);
			this._lblCommon_0.Name = "_lblCommon_0";
			this._lblCommon_0.Size = new System.Drawing.Size(61, 14);
			this._lblCommon_0.TabIndex = 3;
			// 
			// txtProjectNo
			// 
			this.txtProjectNo.AllowDrop = true;
			this.txtProjectNo.BackColor = System.Drawing.Color.White;
			// this.txtProjectNo.bolAllowDecimal = false;
			this.txtProjectNo.ForeColor = System.Drawing.Color.Black;
			this.txtProjectNo.Location = new System.Drawing.Point(86, 44);
			this.txtProjectNo.MaxLength = 15;
			// this.txtProjectNo.mDropDownType = System.Windows.Forms.TextBox.DropDownTypes.ddtNextNumber;
			this.txtProjectNo.Name = "txtProjectNo";
			// this.txtProjectNo.ShowButton = true;
			this.txtProjectNo.Size = new System.Drawing.Size(101, 19);
			this.txtProjectNo.TabIndex = 0;
			this.txtProjectNo.Text = "";
			// this.this.txtProjectNo.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtProjectNo_DropButtonClick);
			// 
			// _lblCommon_1
			// 
			this._lblCommon_1.AllowDrop = true;
			this._lblCommon_1.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_1.Text = "Project Name (English)";
			this._lblCommon_1.Location = new System.Drawing.Point(240, 46);
			this._lblCommon_1.Name = "_lblCommon_1";
			this._lblCommon_1.Size = new System.Drawing.Size(108, 14);
			this._lblCommon_1.TabIndex = 4;
			// 
			// _lblCommon_2
			// 
			this._lblCommon_2.AllowDrop = true;
			this._lblCommon_2.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_2.Text = "Project Name (Arabic)";
			this._lblCommon_2.Location = new System.Drawing.Point(240, 67);
			this._lblCommon_2.Name = "_lblCommon_2";
			this._lblCommon_2.Size = new System.Drawing.Size(106, 14);
			this._lblCommon_2.TabIndex = 5;
			// 
			// _lblCommon_3
			// 
			this._lblCommon_3.AllowDrop = true;
			this._lblCommon_3.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_3.Text = "Project  Information ";
			this._lblCommon_3.Location = new System.Drawing.Point(16, 104);
			this._lblCommon_3.Name = "_lblCommon_3";
			this._lblCommon_3.Size = new System.Drawing.Size(112, 14);
			this._lblCommon_3.TabIndex = 6;
			// 
			// Line1
			// 
			this.Line1.AllowDrop = true;
			this.Line1.BackColor = System.Drawing.SystemColors.WindowText;
			this.Line1.Enabled = false;
			this.Line1.Location = new System.Drawing.Point(0, 112);
			this.Line1.Name = "Line1";
			this.Line1.Size = new System.Drawing.Size(736, 1);
			this.Line1.Visible = true;
			// 
			// frmGLProjects
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.ClientSize = new System.Drawing.Size(1133, 425);
			this.Controls.Add(this.tabMaster);
			this.Controls.Add(this.txtLProjectName);
			this.Controls.Add(this.txtAprojectName);
			this.Controls.Add(this._lblCommon_0);
			this.Controls.Add(this.txtProjectNo);
			this.Controls.Add(this._lblCommon_1);
			this.Controls.Add(this._lblCommon_2);
			this.Controls.Add(this._lblCommon_3);
			this.Controls.Add(this.Line1);
			//this.Icon = (System.Drawing.Icon) resources.GetObject("frmGLProjects.Icon");
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(159, 327);
			this.MaximizeBox = true;
			this.MinimizeBox = true;
			this.Name = "frmGLProjects";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Projects";
			// this.Activated += new System.EventHandler(this.frmGLProjects_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
			// this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
			//((System.ComponentModel.ISupportInitialize) this._fraLedgerInformation_3).EndInit();
			//((System.ComponentModel.ISupportInitialize) this._fraLedgerInformation_2).EndInit();
			//((System.ComponentModel.ISupportInitialize) this._fraLedgerInformation_1).EndInit();
			//((System.ComponentModel.ISupportInitialize) this._fraLedgerInformation_0).EndInit();
			//((System.ComponentModel.ISupportInitialize) this.tabMaster).EndInit();
			this.tabMaster.ResumeLayout(false);
			this._fraLedgerInformation_3.ResumeLayout(false);
			this.cmbPriceList.ResumeLayout(false);
			this.grdActivityDetails.ResumeLayout(false);
			this._fraLedgerInformation_2.ResumeLayout(false);
			this._fraLedgerInformation_1.ResumeLayout(false);
			this._fraLedgerInformation_0.ResumeLayout(false);
			this.fraProjectCompletedDetails.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		void ReLoadForm(bool addEvents)
		{
			Initializetxt();
			InitializelblCommon();
			InitializefraLedgerInformation();
			//This form is an MDI child.
			//This code simulates the VB6 
			// functionality of automatically
			// loading and showing an MDI
			// child's parent.
			this.MdiParent = Xtreme.frmSysMain.DefInstance;
			Xtreme.frmSysMain.DefInstance.Show();
		}
		void Initializetxt()
		{
			this.txt = new System.Windows.Forms.Label[3];
			this.txt[2] = _txt_2;
		}
		void InitializelblCommon()
		{
			this.lblCommon = new System.Windows.Forms.Label[43];
			this.lblCommon[40] = _lblCommon_40;
			this.lblCommon[42] = _lblCommon_42;
			this.lblCommon[4] = _lblCommon_4;
			this.lblCommon[11] = _lblCommon_11;
			this.lblCommon[12] = _lblCommon_12;
			this.lblCommon[13] = _lblCommon_13;
			this.lblCommon[14] = _lblCommon_14;
			this.lblCommon[15] = _lblCommon_15;
			this.lblCommon[16] = _lblCommon_16;
			this.lblCommon[17] = _lblCommon_17;
			this.lblCommon[19] = _lblCommon_19;
			this.lblCommon[20] = _lblCommon_20;
			this.lblCommon[21] = _lblCommon_21;
			this.lblCommon[33] = _lblCommon_33;
			this.lblCommon[34] = _lblCommon_34;
			this.lblCommon[35] = _lblCommon_35;
			this.lblCommon[39] = _lblCommon_39;
			this.lblCommon[9] = _lblCommon_9;
			this.lblCommon[24] = _lblCommon_24;
			this.lblCommon[5] = _lblCommon_5;
			this.lblCommon[6] = _lblCommon_6;
			this.lblCommon[7] = _lblCommon_7;
			this.lblCommon[8] = _lblCommon_8;
			this.lblCommon[10] = _lblCommon_10;
			this.lblCommon[0] = _lblCommon_0;
			this.lblCommon[1] = _lblCommon_1;
			this.lblCommon[2] = _lblCommon_2;
			this.lblCommon[3] = _lblCommon_3;
		}
		void InitializefraLedgerInformation()
		{
			this.fraLedgerInformation = new AxXtremeSuiteControls.AxTabControlPage[4];
			this.fraLedgerInformation[3] = _fraLedgerInformation_3;
			this.fraLedgerInformation[2] = _fraLedgerInformation_2;
			this.fraLedgerInformation[1] = _fraLedgerInformation_1;
			this.fraLedgerInformation[0] = _fraLedgerInformation_0;
		}
		#endregion
	}
}//ENDSHERE
