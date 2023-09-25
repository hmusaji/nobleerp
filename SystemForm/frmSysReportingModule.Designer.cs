
namespace Xtreme
{
	partial class frmSysReportingModule
	{

		#region "Upgrade Support "
		private static frmSysReportingModule m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmSysReportingModule DefInstance
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
		public static frmSysReportingModule CreateInstance()
		{
			frmSysReportingModule theInstance = new frmSysReportingModule();
			
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
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "imlShortcutBarIconsBig", "txtAdvanceCostCode", "lblAdvanceCostCode", "txtDCostCenterName", "fraCostCenter", "txtFromVoucherNo", "chkShowCYOpeningBalance", "chkShowCYCurrentBalance", "chkShowCYProfitAndLoss", "chkShowLYOpeningBalance", "chkShowLYProfitAndLoss", "chkShowLYCurrentBalance", "chkShowLedgerWithZeroBalance", "txtDAnalysisName2", "txtDAnalysisName1", "txtAnalysisCode2", "txtAnalysisCode1", "lblAnalysisCode2", "lblAnalysisCode1", "txtProjectCode", "lblProjectCode", "txtDProjectName", "txtTabSpaceInTree", "lblReportLevel", "txtGroupPrefix", "lblGroupPrefix", "txtGroupSuffix", "lblTabSpaceInTree", "rptLevelSlider", "fraOptions", "cmbReportFilter", "lblToDate", "lblFromDate", "txtFromDate", "txtToDate", "fraDateRange", "lstGroup_ColumnHeader_1_", "lstGroup_ColumnHeader_2_", "lstGroup", "lstReport_ColumnHeader_1_", "lstReport", "txtLocationCode", "lblLocationCode", "lblMasterCode", "txtMasterCode", "txtToVoucherNo", "lblToVoucherNo", "lblFromVoucherNo", "fraVoucherRange", "txtCostCenterCode", "lblCostCenterCode", "txtLocationName", "txtMasterName", "lblReportFilter", "fraLedgerInformation", "tabMaster", "imlShortcutBarIcons", "listViewHelper1"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public System.Windows.Forms.ImageList imlShortcutBarIconsBig;
		public System.Windows.Forms.TextBox txtAdvanceCostCode;
		public System.Windows.Forms.Label lblAdvanceCostCode;
		public System.Windows.Forms.Label txtDCostCenterName;
		public System.Windows.Forms.Panel fraCostCenter;
		public System.Windows.Forms.TextBox txtFromVoucherNo;
		public System.Windows.Forms.CheckBox chkShowCYOpeningBalance;
		public System.Windows.Forms.CheckBox chkShowCYCurrentBalance;
		public System.Windows.Forms.CheckBox chkShowCYProfitAndLoss;
		public System.Windows.Forms.CheckBox chkShowLYOpeningBalance;
		public System.Windows.Forms.CheckBox chkShowLYProfitAndLoss;
		public System.Windows.Forms.CheckBox chkShowLYCurrentBalance;
		public System.Windows.Forms.CheckBox chkShowLedgerWithZeroBalance;
		public System.Windows.Forms.Label txtDAnalysisName2;
		public System.Windows.Forms.Label txtDAnalysisName1;
		public System.Windows.Forms.TextBox txtAnalysisCode2;
		public System.Windows.Forms.TextBox txtAnalysisCode1;
		public System.Windows.Forms.Label lblAnalysisCode2;
		public System.Windows.Forms.Label lblAnalysisCode1;
		public System.Windows.Forms.TextBox txtProjectCode;
		public System.Windows.Forms.Label lblProjectCode;
		public System.Windows.Forms.Label txtDProjectName;
		public System.Windows.Forms.TextBox txtTabSpaceInTree;
		public System.Windows.Forms.Label lblReportLevel;
		public System.Windows.Forms.TextBox txtGroupPrefix;
		public System.Windows.Forms.Label lblGroupPrefix;
		public System.Windows.Forms.TextBox txtGroupSuffix;
		public System.Windows.Forms.Label lblTabSpaceInTree;
		public AxXtremeSuiteControls.AxSlider rptLevelSlider;
		public System.Windows.Forms.Panel fraOptions;
		public System.Windows.Forms.ComboBox cmbReportFilter;
		public System.Windows.Forms.Label lblToDate;
		public System.Windows.Forms.Label lblFromDate;
		public Syncfusion.WinForms.Input.SfDateTimeEdit txtFromDate;
		public Syncfusion.WinForms.Input.SfDateTimeEdit txtToDate;
		public System.Windows.Forms.Panel fraDateRange;
		public System.Windows.Forms.ColumnHeader lstGroup_ColumnHeader_1_;
		public System.Windows.Forms.ColumnHeader lstGroup_ColumnHeader_2_;
		public System.Windows.Forms.ListView lstGroup;
		public System.Windows.Forms.ColumnHeader lstReport_ColumnHeader_1_;
		public System.Windows.Forms.ListView lstReport;
		public System.Windows.Forms.TextBox txtLocationCode;
		public System.Windows.Forms.Label lblLocationCode;
		public System.Windows.Forms.Label lblMasterCode;
		public System.Windows.Forms.TextBox txtMasterCode;
		public System.Windows.Forms.TextBox txtToVoucherNo;
		public System.Windows.Forms.Label lblToVoucherNo;
		public System.Windows.Forms.Label lblFromVoucherNo;
		public System.Windows.Forms.Panel fraVoucherRange;
		public System.Windows.Forms.TextBox txtCostCenterCode;
		public System.Windows.Forms.Label lblCostCenterCode;
		public System.Windows.Forms.Label txtLocationName;
		public System.Windows.Forms.Label txtMasterName;
		public System.Windows.Forms.Label lblReportFilter;
		public System.Windows.Forms.Panel fraLedgerInformation;
		public AxC1SizerLib.AxC1Tab tabMaster;
		public System.Windows.Forms.ImageList imlShortcutBarIcons;
		public UpgradeHelpers.Gui.ListViewHelper listViewHelper1;
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSysReportingModule));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this.imlShortcutBarIconsBig = new System.Windows.Forms.ImageList();
			this.tabMaster = new AxC1SizerLib.AxC1Tab();
			this.fraLedgerInformation = new System.Windows.Forms.Panel();
			this.fraCostCenter = new System.Windows.Forms.Panel();
			this.txtAdvanceCostCode = new System.Windows.Forms.TextBox();
			this.lblAdvanceCostCode = new System.Windows.Forms.Label();
			this.txtDCostCenterName = new System.Windows.Forms.Label();
			this.txtFromVoucherNo = new System.Windows.Forms.TextBox();
			this.fraOptions = new System.Windows.Forms.Panel();
			this.chkShowCYOpeningBalance = new System.Windows.Forms.CheckBox();
			this.chkShowCYCurrentBalance = new System.Windows.Forms.CheckBox();
			this.chkShowCYProfitAndLoss = new System.Windows.Forms.CheckBox();
			this.chkShowLYOpeningBalance = new System.Windows.Forms.CheckBox();
			this.chkShowLYProfitAndLoss = new System.Windows.Forms.CheckBox();
			this.chkShowLYCurrentBalance = new System.Windows.Forms.CheckBox();
			this.chkShowLedgerWithZeroBalance = new System.Windows.Forms.CheckBox();
			this.txtDAnalysisName2 = new System.Windows.Forms.Label();
			this.txtDAnalysisName1 = new System.Windows.Forms.Label();
			this.txtAnalysisCode2 = new System.Windows.Forms.TextBox();
			this.txtAnalysisCode1 = new System.Windows.Forms.TextBox();
			this.lblAnalysisCode2 = new System.Windows.Forms.Label();
			this.lblAnalysisCode1 = new System.Windows.Forms.Label();
			this.txtProjectCode = new System.Windows.Forms.TextBox();
			this.lblProjectCode = new System.Windows.Forms.Label();
			this.txtDProjectName = new System.Windows.Forms.Label();
			this.txtTabSpaceInTree = new System.Windows.Forms.TextBox();
			this.lblReportLevel = new System.Windows.Forms.Label();
			this.txtGroupPrefix = new System.Windows.Forms.TextBox();
			this.lblGroupPrefix = new System.Windows.Forms.Label();
			this.txtGroupSuffix = new System.Windows.Forms.TextBox();
			this.lblTabSpaceInTree = new System.Windows.Forms.Label();
			this.rptLevelSlider = new AxXtremeSuiteControls.AxSlider();
			this.cmbReportFilter = new System.Windows.Forms.ComboBox();
			this.fraDateRange = new System.Windows.Forms.Panel();
			this.lblToDate = new System.Windows.Forms.Label();
			this.lblFromDate = new System.Windows.Forms.Label();
			this.txtFromDate = new Syncfusion.WinForms.Input.SfDateTimeEdit();
			this.txtToDate = new Syncfusion.WinForms.Input.SfDateTimeEdit();
			this.lstGroup = new System.Windows.Forms.ListView();
			this.lstGroup_ColumnHeader_1_ = new System.Windows.Forms.ColumnHeader();
			this.lstGroup_ColumnHeader_2_ = new System.Windows.Forms.ColumnHeader();
			this.lstReport = new System.Windows.Forms.ListView();
			this.lstReport_ColumnHeader_1_ = new System.Windows.Forms.ColumnHeader();
			this.txtLocationCode = new System.Windows.Forms.TextBox();
			this.lblLocationCode = new System.Windows.Forms.Label();
			this.lblMasterCode = new System.Windows.Forms.Label();
			this.txtMasterCode = new System.Windows.Forms.TextBox();
			this.fraVoucherRange = new System.Windows.Forms.Panel();
			this.txtToVoucherNo = new System.Windows.Forms.TextBox();
			this.lblToVoucherNo = new System.Windows.Forms.Label();
			this.lblFromVoucherNo = new System.Windows.Forms.Label();
			this.txtCostCenterCode = new System.Windows.Forms.TextBox();
			this.lblCostCenterCode = new System.Windows.Forms.Label();
			this.txtLocationName = new System.Windows.Forms.Label();
			this.txtMasterName = new System.Windows.Forms.Label();
			this.lblReportFilter = new System.Windows.Forms.Label();
			this.imlShortcutBarIcons = new System.Windows.Forms.ImageList();
			// //((System.ComponentModel.ISupportInitialize) this.rptLevelSlider).BeginInit();
			// //((System.ComponentModel.ISupportInitialize) this.tabMaster).BeginInit();
			this.tabMaster.SuspendLayout();
			this.fraLedgerInformation.SuspendLayout();
			this.fraCostCenter.SuspendLayout();
			this.fraOptions.SuspendLayout();
			this.fraDateRange.SuspendLayout();
			this.lstGroup.SuspendLayout();
			this.lstReport.SuspendLayout();
			this.fraVoucherRange.SuspendLayout();
			this.SuspendLayout();
			this.listViewHelper1 = new UpgradeHelpers.Gui.ListViewHelper(this.components);
			// //((System.ComponentModel.ISupportInitialize) this.listViewHelper1).BeginInit();
			// 
			// imlShortcutBarIconsBig
			// 
			this.imlShortcutBarIconsBig.ImageSize = new System.Drawing.Size(24, 24);
			// this.imlShortcutBarIconsBig.ImageStream = (System.Windows.Forms.ImageListStreamer) resources.GetObject("imlShortcutBarIconsBig.ImageStream");
			this.imlShortcutBarIconsBig.TransparentColor = System.Drawing.Color.Silver;
			this.imlShortcutBarIconsBig.Images.SetKeyName(0, "");
			this.imlShortcutBarIconsBig.Images.SetKeyName(1, "");
			this.imlShortcutBarIconsBig.Images.SetKeyName(2, "");
			this.imlShortcutBarIconsBig.Images.SetKeyName(3, "");
			this.imlShortcutBarIconsBig.Images.SetKeyName(4, "");
			this.imlShortcutBarIconsBig.Images.SetKeyName(5, "");
			this.imlShortcutBarIconsBig.Images.SetKeyName(6, "");
			this.imlShortcutBarIconsBig.Images.SetKeyName(7, "");
			this.imlShortcutBarIconsBig.Images.SetKeyName(8, "");
			this.imlShortcutBarIconsBig.Images.SetKeyName(9, "");
			this.imlShortcutBarIconsBig.Images.SetKeyName(10, "");
			this.imlShortcutBarIconsBig.Images.SetKeyName(11, "");
			this.imlShortcutBarIconsBig.Images.SetKeyName(12, "");
			// 
			// tabMaster
			// 
			this.tabMaster.Align = C1SizerLib.AlignSettings.asNone;
			this.tabMaster.AllowDrop = true;
			this.tabMaster.Controls.Add(this.fraLedgerInformation);
			this.tabMaster.Location = new System.Drawing.Point(4, 14);
			this.tabMaster.Name = "tabMaster";
			//
			this.tabMaster.Size = new System.Drawing.Size(1075, 511);
			this.tabMaster.TabIndex = 5;
			this.tabMaster.TabStop = false;
			// 
			// fraLedgerInformation
			// 
			this.fraLedgerInformation.AllowDrop = true;
			this.fraLedgerInformation.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this.fraLedgerInformation.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.fraLedgerInformation.Controls.Add(this.fraCostCenter);
			this.fraLedgerInformation.Controls.Add(this.txtFromVoucherNo);
			this.fraLedgerInformation.Controls.Add(this.fraOptions);
			this.fraLedgerInformation.Controls.Add(this.cmbReportFilter);
			this.fraLedgerInformation.Controls.Add(this.fraDateRange);
			this.fraLedgerInformation.Controls.Add(this.lstGroup);
			this.fraLedgerInformation.Controls.Add(this.lstReport);
			this.fraLedgerInformation.Controls.Add(this.txtLocationCode);
			this.fraLedgerInformation.Controls.Add(this.lblLocationCode);
			this.fraLedgerInformation.Controls.Add(this.lblMasterCode);
			this.fraLedgerInformation.Controls.Add(this.txtMasterCode);
			this.fraLedgerInformation.Controls.Add(this.fraVoucherRange);
			this.fraLedgerInformation.Controls.Add(this.txtCostCenterCode);
			this.fraLedgerInformation.Controls.Add(this.lblCostCenterCode);
			this.fraLedgerInformation.Controls.Add(this.txtLocationName);
			this.fraLedgerInformation.Controls.Add(this.txtMasterName);
			this.fraLedgerInformation.Controls.Add(this.lblReportFilter);
			this.fraLedgerInformation.Enabled = true;
			this.fraLedgerInformation.ForeColor = System.Drawing.SystemColors.WindowText;
			this.fraLedgerInformation.Location = new System.Drawing.Point(3, 25);
			this.fraLedgerInformation.Name = "fraLedgerInformation";
			this.fraLedgerInformation.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.fraLedgerInformation.Size = new System.Drawing.Size(1069, 483);
			this.fraLedgerInformation.TabIndex = 30;
			this.fraLedgerInformation.Visible = true;
			// 
			// fraCostCenter
			// 
			this.fraCostCenter.AllowDrop = true;
			this.fraCostCenter.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this.fraCostCenter.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.fraCostCenter.Controls.Add(this.txtAdvanceCostCode);
			this.fraCostCenter.Controls.Add(this.lblAdvanceCostCode);
			this.fraCostCenter.Controls.Add(this.txtDCostCenterName);
			this.fraCostCenter.Enabled = true;
			this.fraCostCenter.ForeColor = System.Drawing.SystemColors.ControlText;
			this.fraCostCenter.Location = new System.Drawing.Point(526, 230);
			this.fraCostCenter.Name = "fraCostCenter";
			this.fraCostCenter.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.fraCostCenter.Size = new System.Drawing.Size(453, 20);
			this.fraCostCenter.TabIndex = 48;
			this.fraCostCenter.Visible = true;
			// 
			// txtAdvanceCostCode
			// 
			this.txtAdvanceCostCode.AllowDrop = true;
			this.txtAdvanceCostCode.BackColor = System.Drawing.Color.White;
			this.txtAdvanceCostCode.ForeColor = System.Drawing.Color.Black;
			this.txtAdvanceCostCode.Location = new System.Drawing.Point(130, 0);
			this.txtAdvanceCostCode.Name = "txtAdvanceCostCode";
			// this.txtAdvanceCostCode.ShowButton = true;
			this.txtAdvanceCostCode.Size = new System.Drawing.Size(101, 19);
			this.txtAdvanceCostCode.TabIndex = 49;
			this.txtAdvanceCostCode.Text = "";
			// this.this.txtAdvanceCostCode.Watermark = "";
			// this.this.txtAdvanceCostCode.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtAdvanceCostCode_DropButtonClick);
			// this.txtAdvanceCostCode.Leave += new System.EventHandler(this.txtAdvanceCostCode_Leave);
			// 
			// lblAdvanceCostCode
			// 
			this.lblAdvanceCostCode.AllowDrop = true;
			this.lblAdvanceCostCode.BackColor = System.Drawing.SystemColors.Window;
			this.lblAdvanceCostCode.Text = "Cost Center Code";
			this.lblAdvanceCostCode.ForeColor = System.Drawing.Color.Black;
			this.lblAdvanceCostCode.Location = new System.Drawing.Point(0, 4);
			this.lblAdvanceCostCode.Name = "lblAdvanceCostCode";
			this.lblAdvanceCostCode.Size = new System.Drawing.Size(86, 13);
			this.lblAdvanceCostCode.TabIndex = 50;
			// 
			// txtDCostCenterName
			// 
			this.txtDCostCenterName.AllowDrop = true;
			this.txtDCostCenterName.Enabled = false;
			this.txtDCostCenterName.Location = new System.Drawing.Point(234, 0);
			this.txtDCostCenterName.Name = "txtDCostCenterName";
			this.txtDCostCenterName.Size = new System.Drawing.Size(201, 19);
			this.txtDCostCenterName.TabIndex = 51;
			this.txtDCostCenterName.TabStop = false;
			// 
			// txtFromVoucherNo
			// 
			this.txtFromVoucherNo.AllowDrop = true;
			this.txtFromVoucherNo.BackColor = System.Drawing.Color.White;
			this.txtFromVoucherNo.ForeColor = System.Drawing.Color.Black;
			this.txtFromVoucherNo.Location = new System.Drawing.Point(656, 140);
			this.txtFromVoucherNo.Name = "txtFromVoucherNo";
			this.txtFromVoucherNo.Size = new System.Drawing.Size(101, 19);
			this.txtFromVoucherNo.TabIndex = 12;
			this.txtFromVoucherNo.Text = "";
			// this.this.txtFromVoucherNo.Watermark = "";
			// 
			// fraOptions
			// 
			this.fraOptions.AllowDrop = true;
			this.fraOptions.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this.fraOptions.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.fraOptions.Controls.Add(this.chkShowCYOpeningBalance);
			this.fraOptions.Controls.Add(this.chkShowCYCurrentBalance);
			this.fraOptions.Controls.Add(this.chkShowCYProfitAndLoss);
			this.fraOptions.Controls.Add(this.chkShowLYOpeningBalance);
			this.fraOptions.Controls.Add(this.chkShowLYProfitAndLoss);
			this.fraOptions.Controls.Add(this.chkShowLYCurrentBalance);
			this.fraOptions.Controls.Add(this.chkShowLedgerWithZeroBalance);
			this.fraOptions.Controls.Add(this.txtDAnalysisName2);
			this.fraOptions.Controls.Add(this.txtDAnalysisName1);
			this.fraOptions.Controls.Add(this.txtAnalysisCode2);
			this.fraOptions.Controls.Add(this.txtAnalysisCode1);
			this.fraOptions.Controls.Add(this.lblAnalysisCode2);
			this.fraOptions.Controls.Add(this.lblAnalysisCode1);
			this.fraOptions.Controls.Add(this.txtProjectCode);
			this.fraOptions.Controls.Add(this.lblProjectCode);
			this.fraOptions.Controls.Add(this.txtDProjectName);
			this.fraOptions.Controls.Add(this.txtTabSpaceInTree);
			this.fraOptions.Controls.Add(this.lblReportLevel);
			this.fraOptions.Controls.Add(this.txtGroupPrefix);
			this.fraOptions.Controls.Add(this.lblGroupPrefix);
			this.fraOptions.Controls.Add(this.txtGroupSuffix);
			this.fraOptions.Controls.Add(this.lblTabSpaceInTree);
			this.fraOptions.Controls.Add(this.rptLevelSlider);
			this.fraOptions.Enabled = true;
			this.fraOptions.ForeColor = System.Drawing.SystemColors.WindowText;
			this.fraOptions.Location = new System.Drawing.Point(518, 252);
			this.fraOptions.Name = "fraOptions";
			this.fraOptions.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.fraOptions.Size = new System.Drawing.Size(462, 228);
			this.fraOptions.TabIndex = 41;
			this.fraOptions.Text = " Partial Posting Options ";
			this.fraOptions.Visible = true;
			// 
			// chkShowCYOpeningBalance
			// 
			this.chkShowCYOpeningBalance.AllowDrop = true;
			this.chkShowCYOpeningBalance.Appearance = System.Windows.Forms.Appearance.Normal;
			this.chkShowCYOpeningBalance.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this.chkShowCYOpeningBalance.CausesValidation = true;
			this.chkShowCYOpeningBalance.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkShowCYOpeningBalance.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this.chkShowCYOpeningBalance.Enabled = true;
			this.chkShowCYOpeningBalance.ForeColor = System.Drawing.Color.Black;
			this.chkShowCYOpeningBalance.Location = new System.Drawing.Point(258, 188);
			this.chkShowCYOpeningBalance.Name = "chkShowCYOpeningBalance";
			this.chkShowCYOpeningBalance.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.chkShowCYOpeningBalance.Size = new System.Drawing.Size(157, 15);
			this.chkShowCYOpeningBalance.TabIndex = 29;
			this.chkShowCYOpeningBalance.TabStop = true;
			this.chkShowCYOpeningBalance.Text = "Show CY Opening Balance";
			this.chkShowCYOpeningBalance.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkShowCYOpeningBalance.Visible = false;
			// 
			// chkShowCYCurrentBalance
			// 
			this.chkShowCYCurrentBalance.AllowDrop = true;
			this.chkShowCYCurrentBalance.Appearance = System.Windows.Forms.Appearance.Normal;
			this.chkShowCYCurrentBalance.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this.chkShowCYCurrentBalance.CausesValidation = true;
			this.chkShowCYCurrentBalance.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkShowCYCurrentBalance.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this.chkShowCYCurrentBalance.Enabled = true;
			this.chkShowCYCurrentBalance.ForeColor = System.Drawing.Color.Black;
			this.chkShowCYCurrentBalance.Location = new System.Drawing.Point(258, 195);
			this.chkShowCYCurrentBalance.Name = "chkShowCYCurrentBalance";
			this.chkShowCYCurrentBalance.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.chkShowCYCurrentBalance.Size = new System.Drawing.Size(157, 15);
			this.chkShowCYCurrentBalance.TabIndex = 28;
			this.chkShowCYCurrentBalance.TabStop = true;
			this.chkShowCYCurrentBalance.Text = "Show CY Current Balance";
			this.chkShowCYCurrentBalance.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkShowCYCurrentBalance.Visible = false;
			// 
			// chkShowCYProfitAndLoss
			// 
			this.chkShowCYProfitAndLoss.AllowDrop = true;
			this.chkShowCYProfitAndLoss.Appearance = System.Windows.Forms.Appearance.Normal;
			this.chkShowCYProfitAndLoss.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this.chkShowCYProfitAndLoss.CausesValidation = true;
			this.chkShowCYProfitAndLoss.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkShowCYProfitAndLoss.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this.chkShowCYProfitAndLoss.Enabled = true;
			this.chkShowCYProfitAndLoss.ForeColor = System.Drawing.Color.Black;
			this.chkShowCYProfitAndLoss.Location = new System.Drawing.Point(258, 230);
			this.chkShowCYProfitAndLoss.Name = "chkShowCYProfitAndLoss";
			this.chkShowCYProfitAndLoss.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.chkShowCYProfitAndLoss.Size = new System.Drawing.Size(157, 15);
			this.chkShowCYProfitAndLoss.TabIndex = 27;
			this.chkShowCYProfitAndLoss.TabStop = true;
			this.chkShowCYProfitAndLoss.Text = "Show CY Profit and Loss";
			this.chkShowCYProfitAndLoss.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkShowCYProfitAndLoss.Visible = false;
			// 
			// chkShowLYOpeningBalance
			// 
			this.chkShowLYOpeningBalance.AllowDrop = true;
			this.chkShowLYOpeningBalance.Appearance = System.Windows.Forms.Appearance.Normal;
			this.chkShowLYOpeningBalance.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this.chkShowLYOpeningBalance.CausesValidation = true;
			this.chkShowLYOpeningBalance.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkShowLYOpeningBalance.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this.chkShowLYOpeningBalance.Enabled = true;
			this.chkShowLYOpeningBalance.ForeColor = System.Drawing.Color.Black;
			this.chkShowLYOpeningBalance.Location = new System.Drawing.Point(258, 209);
			this.chkShowLYOpeningBalance.Name = "chkShowLYOpeningBalance";
			this.chkShowLYOpeningBalance.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.chkShowLYOpeningBalance.Size = new System.Drawing.Size(157, 15);
			this.chkShowLYOpeningBalance.TabIndex = 26;
			this.chkShowLYOpeningBalance.TabStop = true;
			this.chkShowLYOpeningBalance.Text = "Show LY Opening Balance";
			this.chkShowLYOpeningBalance.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkShowLYOpeningBalance.Visible = false;
			// 
			// chkShowLYProfitAndLoss
			// 
			this.chkShowLYProfitAndLoss.AllowDrop = true;
			this.chkShowLYProfitAndLoss.Appearance = System.Windows.Forms.Appearance.Normal;
			this.chkShowLYProfitAndLoss.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this.chkShowLYProfitAndLoss.CausesValidation = true;
			this.chkShowLYProfitAndLoss.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkShowLYProfitAndLoss.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this.chkShowLYProfitAndLoss.Enabled = true;
			this.chkShowLYProfitAndLoss.ForeColor = System.Drawing.Color.Black;
			this.chkShowLYProfitAndLoss.Location = new System.Drawing.Point(258, 219);
			this.chkShowLYProfitAndLoss.Name = "chkShowLYProfitAndLoss";
			this.chkShowLYProfitAndLoss.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.chkShowLYProfitAndLoss.Size = new System.Drawing.Size(157, 15);
			this.chkShowLYProfitAndLoss.TabIndex = 25;
			this.chkShowLYProfitAndLoss.TabStop = true;
			this.chkShowLYProfitAndLoss.Text = "Show LY Profit and Loss";
			this.chkShowLYProfitAndLoss.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkShowLYProfitAndLoss.Visible = false;
			// 
			// chkShowLYCurrentBalance
			// 
			this.chkShowLYCurrentBalance.AllowDrop = true;
			this.chkShowLYCurrentBalance.Appearance = System.Windows.Forms.Appearance.Normal;
			this.chkShowLYCurrentBalance.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this.chkShowLYCurrentBalance.CausesValidation = true;
			this.chkShowLYCurrentBalance.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkShowLYCurrentBalance.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this.chkShowLYCurrentBalance.Enabled = true;
			this.chkShowLYCurrentBalance.ForeColor = System.Drawing.Color.Black;
			this.chkShowLYCurrentBalance.Location = new System.Drawing.Point(258, 180);
			this.chkShowLYCurrentBalance.Name = "chkShowLYCurrentBalance";
			this.chkShowLYCurrentBalance.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.chkShowLYCurrentBalance.Size = new System.Drawing.Size(157, 15);
			this.chkShowLYCurrentBalance.TabIndex = 24;
			this.chkShowLYCurrentBalance.TabStop = true;
			this.chkShowLYCurrentBalance.Text = "Show LY Current Balance";
			this.chkShowLYCurrentBalance.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkShowLYCurrentBalance.Visible = false;
			// 
			// chkShowLedgerWithZeroBalance
			// 
			this.chkShowLedgerWithZeroBalance.AllowDrop = true;
			this.chkShowLedgerWithZeroBalance.Appearance = System.Windows.Forms.Appearance.Normal;
			this.chkShowLedgerWithZeroBalance.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this.chkShowLedgerWithZeroBalance.CausesValidation = true;
			this.chkShowLedgerWithZeroBalance.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkShowLedgerWithZeroBalance.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this.chkShowLedgerWithZeroBalance.Enabled = true;
			this.chkShowLedgerWithZeroBalance.ForeColor = System.Drawing.Color.Black;
			this.chkShowLedgerWithZeroBalance.Location = new System.Drawing.Point(140, 148);
			this.chkShowLedgerWithZeroBalance.Name = "chkShowLedgerWithZeroBalance";
			this.chkShowLedgerWithZeroBalance.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.chkShowLedgerWithZeroBalance.Size = new System.Drawing.Size(205, 15);
			this.chkShowLedgerWithZeroBalance.TabIndex = 23;
			this.chkShowLedgerWithZeroBalance.TabStop = true;
			this.chkShowLedgerWithZeroBalance.Text = "Show Ledger With Zero Balance";
			this.chkShowLedgerWithZeroBalance.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkShowLedgerWithZeroBalance.Visible = true;
			// 
			// txtDAnalysisName2
			// 
			this.txtDAnalysisName2.AllowDrop = true;
			this.txtDAnalysisName2.BackColor = System.Drawing.SystemColors.Window;
			this.txtDAnalysisName2.Enabled = false;
			this.txtDAnalysisName2.Location = new System.Drawing.Point(242, 43);
			this.txtDAnalysisName2.Name = "txtDAnalysisName2";
			this.txtDAnalysisName2.Size = new System.Drawing.Size(201, 19);
			this.txtDAnalysisName2.TabIndex = 0;
			this.txtDAnalysisName2.TabStop = false;
			// 
			// txtDAnalysisName1
			// 
			this.txtDAnalysisName1.AllowDrop = true;
			this.txtDAnalysisName1.BackColor = System.Drawing.SystemColors.Window;
			this.txtDAnalysisName1.Enabled = false;
			this.txtDAnalysisName1.Location = new System.Drawing.Point(242, 22);
			this.txtDAnalysisName1.Name = "txtDAnalysisName1";
			this.txtDAnalysisName1.Size = new System.Drawing.Size(201, 19);
			this.txtDAnalysisName1.TabIndex = 1;
			this.txtDAnalysisName1.TabStop = false;
			// 
			// txtAnalysisCode2
			// 
			this.txtAnalysisCode2.AllowDrop = true;
			this.txtAnalysisCode2.BackColor = System.Drawing.Color.White;
			// this.txtAnalysisCode2.bolAllowDecimal = false;
			this.txtAnalysisCode2.ForeColor = System.Drawing.Color.Black;
			this.txtAnalysisCode2.Location = new System.Drawing.Point(138, 43);
			this.txtAnalysisCode2.MaxLength = 12;
			// this.txtAnalysisCode2.mDropDownType = (System.Windows.Forms.TextBox.DropDownTypes) 0;
			this.txtAnalysisCode2.Name = "txtAnalysisCode2";
			// this.txtAnalysisCode2.ShowButton = true;
			this.txtAnalysisCode2.Size = new System.Drawing.Size(101, 19);
			this.txtAnalysisCode2.TabIndex = 18;
			this.txtAnalysisCode2.Text = "";
			// this.this.txtAnalysisCode2.Watermark = "";
			// 
			// txtAnalysisCode1
			// 
			this.txtAnalysisCode1.AllowDrop = true;
			this.txtAnalysisCode1.BackColor = System.Drawing.Color.White;
			// this.txtAnalysisCode1.bolAllowDecimal = false;
			this.txtAnalysisCode1.ForeColor = System.Drawing.Color.Black;
			this.txtAnalysisCode1.Location = new System.Drawing.Point(138, 22);
			this.txtAnalysisCode1.MaxLength = 12;
			// this.txtAnalysisCode1.mDropDownType = (System.Windows.Forms.TextBox.DropDownTypes) 0;
			this.txtAnalysisCode1.Name = "txtAnalysisCode1";
			// this.txtAnalysisCode1.ShowButton = true;
			this.txtAnalysisCode1.Size = new System.Drawing.Size(101, 19);
			this.txtAnalysisCode1.TabIndex = 17;
			this.txtAnalysisCode1.Text = "";
			// this.this.txtAnalysisCode1.Watermark = "";
			// 
			// lblAnalysisCode2
			// 
			this.lblAnalysisCode2.AllowDrop = true;
			this.lblAnalysisCode2.BackColor = System.Drawing.SystemColors.Window;
			this.lblAnalysisCode2.Text = "Analysis Code 2";
			this.lblAnalysisCode2.ForeColor = System.Drawing.Color.Black;
			this.lblAnalysisCode2.Location = new System.Drawing.Point(9, 46);
			this.lblAnalysisCode2.Name = "lblAnalysisCode2";
			this.lblAnalysisCode2.Size = new System.Drawing.Size(75, 13);
			this.lblAnalysisCode2.TabIndex = 42;
			// 
			// lblAnalysisCode1
			// 
			this.lblAnalysisCode1.AllowDrop = true;
			this.lblAnalysisCode1.BackColor = System.Drawing.SystemColors.Window;
			this.lblAnalysisCode1.Text = "Analysis Code 1";
			this.lblAnalysisCode1.ForeColor = System.Drawing.Color.Black;
			this.lblAnalysisCode1.Location = new System.Drawing.Point(9, 25);
			this.lblAnalysisCode1.Name = "lblAnalysisCode1";
			this.lblAnalysisCode1.Size = new System.Drawing.Size(75, 13);
			this.lblAnalysisCode1.TabIndex = 43;
			// 
			// txtProjectCode
			// 
			this.txtProjectCode.AllowDrop = true;
			this.txtProjectCode.BackColor = System.Drawing.Color.White;
			this.txtProjectCode.ForeColor = System.Drawing.Color.Black;
			this.txtProjectCode.Location = new System.Drawing.Point(138, 1);
			this.txtProjectCode.Name = "txtProjectCode";
			// this.txtProjectCode.ShowButton = true;
			this.txtProjectCode.Size = new System.Drawing.Size(101, 19);
			this.txtProjectCode.TabIndex = 16;
			this.txtProjectCode.Text = "";
			// this.this.txtProjectCode.Watermark = "";
			// 
			// lblProjectCode
			// 
			this.lblProjectCode.AllowDrop = true;
			this.lblProjectCode.BackColor = System.Drawing.SystemColors.Window;
			this.lblProjectCode.Text = "Project Code";
			this.lblProjectCode.ForeColor = System.Drawing.Color.Black;
			this.lblProjectCode.Location = new System.Drawing.Point(10, 4);
			this.lblProjectCode.Name = "lblProjectCode";
			this.lblProjectCode.Size = new System.Drawing.Size(62, 13);
			this.lblProjectCode.TabIndex = 44;
			// 
			// txtDProjectName
			// 
			this.txtDProjectName.AllowDrop = true;
			this.txtDProjectName.Enabled = false;
			this.txtDProjectName.Location = new System.Drawing.Point(242, 0);
			this.txtDProjectName.Name = "txtDProjectName";
			this.txtDProjectName.Size = new System.Drawing.Size(201, 19);
			this.txtDProjectName.TabIndex = 2;
			this.txtDProjectName.TabStop = false;
			// 
			// txtTabSpaceInTree
			// 
			this.txtTabSpaceInTree.AllowDrop = true;
			this.txtTabSpaceInTree.Location = new System.Drawing.Point(138, 87);
			// this.txtTabSpaceInTree.MaxValue = 50;
			// this.txtTabSpaceInTree.MinValue = 0;
			this.txtTabSpaceInTree.Name = "txtTabSpaceInTree";
			this.txtTabSpaceInTree.Size = new System.Drawing.Size(101, 19);
			this.txtTabSpaceInTree.TabIndex = 21;
			// 
			// lblReportLevel
			// 
			this.lblReportLevel.AllowDrop = true;
			this.lblReportLevel.BackColor = System.Drawing.SystemColors.Window;
			this.lblReportLevel.Text = "Report Level";
			this.lblReportLevel.ForeColor = System.Drawing.Color.Black;
			this.lblReportLevel.Location = new System.Drawing.Point(9, 118);
			this.lblReportLevel.Name = "lblReportLevel";
			this.lblReportLevel.Size = new System.Drawing.Size(61, 13);
			this.lblReportLevel.TabIndex = 45;
			// 
			// txtGroupPrefix
			// 
			this.txtGroupPrefix.AllowDrop = true;
			this.txtGroupPrefix.BackColor = System.Drawing.Color.White;
			this.txtGroupPrefix.ForeColor = System.Drawing.Color.Black;
			this.txtGroupPrefix.Location = new System.Drawing.Point(138, 66);
			this.txtGroupPrefix.MaxLength = 12;
			// this.txtGroupPrefix.mDropDownType = (System.Windows.Forms.TextBox.DropDownTypes) 0;
			this.txtGroupPrefix.Name = "txtGroupPrefix";
			this.txtGroupPrefix.Size = new System.Drawing.Size(49, 19);
			this.txtGroupPrefix.TabIndex = 19;
			this.txtGroupPrefix.Text = "";
			// this.this.txtGroupPrefix.Watermark = "";
			// 
			// lblGroupPrefix
			// 
			this.lblGroupPrefix.AllowDrop = true;
			this.lblGroupPrefix.BackColor = System.Drawing.SystemColors.Window;
			this.lblGroupPrefix.Text = "Group Prefix";
			this.lblGroupPrefix.ForeColor = System.Drawing.Color.Black;
			this.lblGroupPrefix.Location = new System.Drawing.Point(9, 68);
			this.lblGroupPrefix.Name = "lblGroupPrefix";
			this.lblGroupPrefix.Size = new System.Drawing.Size(89, 13);
			this.lblGroupPrefix.TabIndex = 46;
			// 
			// txtGroupSuffix
			// 
			this.txtGroupSuffix.AllowDrop = true;
			this.txtGroupSuffix.BackColor = System.Drawing.Color.White;
			this.txtGroupSuffix.ForeColor = System.Drawing.Color.Black;
			this.txtGroupSuffix.Location = new System.Drawing.Point(190, 65);
			this.txtGroupSuffix.MaxLength = 12;
			// this.txtGroupSuffix.mDropDownType = (System.Windows.Forms.TextBox.DropDownTypes) 0;
			this.txtGroupSuffix.Name = "txtGroupSuffix";
			this.txtGroupSuffix.Size = new System.Drawing.Size(49, 19);
			this.txtGroupSuffix.TabIndex = 20;
			this.txtGroupSuffix.Text = "";
			// this.this.txtGroupSuffix.Watermark = "";
			// 
			// lblTabSpaceInTree
			// 
			this.lblTabSpaceInTree.AllowDrop = true;
			this.lblTabSpaceInTree.BackColor = System.Drawing.SystemColors.Window;
			this.lblTabSpaceInTree.Text = "Tab Space In Tree";
			this.lblTabSpaceInTree.ForeColor = System.Drawing.Color.Black;
			this.lblTabSpaceInTree.Location = new System.Drawing.Point(9, 90);
			this.lblTabSpaceInTree.Name = "lblTabSpaceInTree";
			this.lblTabSpaceInTree.Size = new System.Drawing.Size(90, 13);
			this.lblTabSpaceInTree.TabIndex = 47;
			// 
			// rptLevelSlider
			// 
			this.rptLevelSlider.AllowDrop = true;
			this.rptLevelSlider.Location = new System.Drawing.Point(138, 112);
			this.rptLevelSlider.Name = "rptLevelSlider";
			//
			this.rptLevelSlider.Size = new System.Drawing.Size(303, 33);
			this.rptLevelSlider.TabIndex = 22;
			// 
			// cmbReportFilter
			// 
			this.cmbReportFilter.AllowDrop = true;
			this.cmbReportFilter.Location = new System.Drawing.Point(656, 140);
			this.cmbReportFilter.Name = "cmbReportFilter";
			this.cmbReportFilter.Size = new System.Drawing.Size(103, 21);
			this.cmbReportFilter.TabIndex = 13;
			this.cmbReportFilter.Visible = false;
			// 
			// fraDateRange
			// 
			this.fraDateRange.AllowDrop = true;
			this.fraDateRange.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this.fraDateRange.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.fraDateRange.Controls.Add(this.lblToDate);
			this.fraDateRange.Controls.Add(this.lblFromDate);
			this.fraDateRange.Controls.Add(this.txtFromDate);
			this.fraDateRange.Controls.Add(this.txtToDate);
			this.fraDateRange.Enabled = true;
			this.fraDateRange.ForeColor = System.Drawing.SystemColors.WindowText;
			this.fraDateRange.Location = new System.Drawing.Point(524, 96);
			this.fraDateRange.Name = "fraDateRange";
			this.fraDateRange.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.fraDateRange.Size = new System.Drawing.Size(241, 43);
			this.fraDateRange.TabIndex = 32;
			this.fraDateRange.Visible = false;
			// 
			// lblToDate
			// 
			this.lblToDate.AllowDrop = true;
			this.lblToDate.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this.lblToDate.ForeColor = System.Drawing.Color.Black;
			this.lblToDate.Location = new System.Drawing.Point(0, 26);
			this.lblToDate.Name = "lblToDate";
			this.lblToDate.Size = new System.Drawing.Size(38, 13);
			this.lblToDate.TabIndex = 33;
			this.lblToDate.Visible = false;
			// 
			// lblFromDate
			// 
			this.lblFromDate.AllowDrop = true;
			this.lblFromDate.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this.lblFromDate.ForeColor = System.Drawing.Color.Black;
			this.lblFromDate.Location = new System.Drawing.Point(0, 4);
			this.lblFromDate.Name = "lblFromDate";
			this.lblFromDate.Size = new System.Drawing.Size(50, 13);
			this.lblFromDate.TabIndex = 34;
			this.lblFromDate.Visible = false;
			// 
			// txtFromDate
			// 
			this.txtFromDate.AllowDrop = true;
			this.txtFromDate.Location = new System.Drawing.Point(132, 0);
			// this.txtFromDate.MaxDate = 2958465;
			// this.txtFromDate.MinDate = -657434;
			this.txtFromDate.Name = "txtFromDate";
			this.txtFromDate.Size = new System.Drawing.Size(101, 19);
			this.txtFromDate.TabIndex = 10;
			// this.txtFromDate.Text = "07/Jul/2021";
			this.txtFromDate.Visible = false;
			// 
			// txtToDate
			// 
			this.txtToDate.AllowDrop = true;
			this.txtToDate.Location = new System.Drawing.Point(132, 22);
			// this.txtToDate.MaxDate = 2958465;
			// this.txtToDate.MinDate = -657434;
			this.txtToDate.Name = "txtToDate";
			this.txtToDate.Size = new System.Drawing.Size(101, 19);
			this.txtToDate.TabIndex = 11;
			// this.txtToDate.Text = "07/Jul/2021";
			this.txtToDate.Visible = false;
			// 
			// lstGroup
			// 
			this.lstGroup.AllowDrop = true;
			this.lstGroup.BackColor = System.Drawing.SystemColors.Window;
			this.lstGroup.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lstGroup.Font = new System.Drawing.Font("Arial (Arabic)", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 178);
			this.lstGroup.ForeColor = System.Drawing.SystemColors.WindowText;
			this.lstGroup.FullRowSelect = true;
			this.lstGroup.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
			this.lstGroup.HideSelection = false;
			this.lstGroup.LabelEdit = false;
			this.lstGroup.LargeImageList = imlShortcutBarIconsBig;
			this.lstGroup.Location = new System.Drawing.Point(10, 8);
			this.lstGroup.MultiSelect = false;
			this.lstGroup.Name = "lstGroup";
			this.lstGroup.Size = new System.Drawing.Size(185, 369);
			this.lstGroup.SmallImageList = imlShortcutBarIconsBig;
			this.lstGroup.TabIndex = 6;
			this.lstGroup.View = System.Windows.Forms.View.Details;
			this.lstGroup.Columns.Add(this.lstGroup_ColumnHeader_1_);
			this.lstGroup.Columns.Add(this.lstGroup_ColumnHeader_2_);
			// 
			// lstGroup_ColumnHeader_1_
			// 
			this.lstGroup_ColumnHeader_1_.Text = "Groups";
			this.lstGroup_ColumnHeader_1_.Width = 180;
			// 
			// lstGroup_ColumnHeader_2_
			// 
			this.lstGroup_ColumnHeader_2_.Text = "GroupId";
			this.lstGroup_ColumnHeader_2_.Width = 0;
			// 
			// lstReport
			// 
			this.lstReport.AllowDrop = true;
			this.lstReport.BackColor = System.Drawing.SystemColors.Window;
			this.lstReport.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lstReport.Font = new System.Drawing.Font("Arial (Arabic)", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 178);
			this.lstReport.ForeColor = System.Drawing.SystemColors.WindowText;
			this.lstReport.FullRowSelect = true;
			this.lstReport.HideSelection = false;
			this.lstReport.LabelEdit = false;
			this.lstReport.LargeImageList = imlShortcutBarIcons;
			this.lstReport.Location = new System.Drawing.Point(204, 8);
			this.lstReport.MultiSelect = false;
			this.lstReport.Name = "lstReport";
			this.lstReport.Size = new System.Drawing.Size(317, 369);
			this.lstReport.SmallImageList = imlShortcutBarIcons;
			this.lstReport.TabIndex = 7;
			this.lstReport.View = System.Windows.Forms.View.Details;
			this.lstReport.Columns.Add(this.lstReport_ColumnHeader_1_);
			this.lstReport.DoubleClick += new System.EventHandler(this.lstReport_DoubleClick);
			// this.this.lstReport.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.lstReport_KeyPress);
			// 
			// lstReport_ColumnHeader_1_
			// 
			this.lstReport_ColumnHeader_1_.Text = "Reports";
			this.lstReport_ColumnHeader_1_.Width = 314;
			// 
			// txtLocationCode
			// 
			this.txtLocationCode.AllowDrop = true;
			this.txtLocationCode.BackColor = System.Drawing.Color.White;
			this.txtLocationCode.ForeColor = System.Drawing.Color.Black;
			this.txtLocationCode.Location = new System.Drawing.Point(658, 48);
			this.txtLocationCode.Name = "txtLocationCode";
			// this.txtLocationCode.ShowButton = true;
			this.txtLocationCode.Size = new System.Drawing.Size(101, 19);
			this.txtLocationCode.TabIndex = 9;
			this.txtLocationCode.Text = "";
			this.txtLocationCode.Visible = false;
			// this.this.txtLocationCode.Watermark = "";
			// this.this.txtLocationCode.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtLocationCode_DropButtonClick);
			// this.txtLocationCode.Leave += new System.EventHandler(this.txtLocationCode_Leave);
			// 
			// lblLocationCode
			// 
			this.lblLocationCode.AllowDrop = true;
			this.lblLocationCode.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this.lblLocationCode.ForeColor = System.Drawing.Color.Black;
			this.lblLocationCode.Location = new System.Drawing.Point(524, 50);
			this.lblLocationCode.Name = "lblLocationCode";
			this.lblLocationCode.Size = new System.Drawing.Size(68, 13);
			this.lblLocationCode.TabIndex = 31;
			this.lblLocationCode.Visible = false;
			// 
			// lblMasterCode
			// 
			this.lblMasterCode.AllowDrop = true;
			this.lblMasterCode.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this.lblMasterCode.ForeColor = System.Drawing.Color.Black;
			this.lblMasterCode.Location = new System.Drawing.Point(522, 8);
			this.lblMasterCode.Name = "lblMasterCode";
			this.lblMasterCode.Size = new System.Drawing.Size(61, 14);
			this.lblMasterCode.TabIndex = 35;
			this.lblMasterCode.Visible = false;
			// 
			// txtMasterCode
			// 
			this.txtMasterCode.AllowDrop = true;
			this.txtMasterCode.BackColor = System.Drawing.Color.White;
			this.txtMasterCode.ForeColor = System.Drawing.Color.Black;
			this.txtMasterCode.Location = new System.Drawing.Point(656, 6);
			this.txtMasterCode.Name = "txtMasterCode";
			// this.txtMasterCode.ShowButton = true;
			this.txtMasterCode.Size = new System.Drawing.Size(101, 19);
			this.txtMasterCode.TabIndex = 8;
			this.txtMasterCode.Text = "";
			this.txtMasterCode.Visible = false;
			// this.this.txtMasterCode.Watermark = "";
			// this.this.txtMasterCode.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtMasterCode_DropButtonClick);
			// this.txtMasterCode.Leave += new System.EventHandler(this.txtMasterCode_Leave);
			// 
			// fraVoucherRange
			// 
			this.fraVoucherRange.AllowDrop = true;
			this.fraVoucherRange.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this.fraVoucherRange.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.fraVoucherRange.Controls.Add(this.txtToVoucherNo);
			this.fraVoucherRange.Controls.Add(this.lblToVoucherNo);
			this.fraVoucherRange.Controls.Add(this.lblFromVoucherNo);
			this.fraVoucherRange.Enabled = true;
			this.fraVoucherRange.ForeColor = System.Drawing.SystemColors.WindowText;
			this.fraVoucherRange.Location = new System.Drawing.Point(522, 140);
			this.fraVoucherRange.Name = "fraVoucherRange";
			this.fraVoucherRange.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.fraVoucherRange.Size = new System.Drawing.Size(239, 43);
			this.fraVoucherRange.TabIndex = 36;
			this.fraVoucherRange.Visible = false;
			// 
			// txtToVoucherNo
			// 
			this.txtToVoucherNo.AllowDrop = true;
			this.txtToVoucherNo.BackColor = System.Drawing.Color.White;
			this.txtToVoucherNo.ForeColor = System.Drawing.Color.Black;
			this.txtToVoucherNo.Location = new System.Drawing.Point(134, 24);
			this.txtToVoucherNo.Name = "txtToVoucherNo";
			// this.txtToVoucherNo.ShowButton = true;
			this.txtToVoucherNo.Size = new System.Drawing.Size(101, 19);
			this.txtToVoucherNo.TabIndex = 14;
			this.txtToVoucherNo.Text = "";
			// this.this.txtToVoucherNo.Watermark = "";
			// 
			// lblToVoucherNo
			// 
			this.lblToVoucherNo.AllowDrop = true;
			this.lblToVoucherNo.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this.lblToVoucherNo.ForeColor = System.Drawing.Color.Black;
			this.lblToVoucherNo.Location = new System.Drawing.Point(2, 26);
			this.lblToVoucherNo.Name = "lblToVoucherNo";
			this.lblToVoucherNo.Size = new System.Drawing.Size(70, 13);
			this.lblToVoucherNo.TabIndex = 37;
			// 
			// lblFromVoucherNo
			// 
			this.lblFromVoucherNo.AllowDrop = true;
			this.lblFromVoucherNo.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this.lblFromVoucherNo.ForeColor = System.Drawing.Color.Black;
			this.lblFromVoucherNo.Location = new System.Drawing.Point(2, 6);
			this.lblFromVoucherNo.Name = "lblFromVoucherNo";
			this.lblFromVoucherNo.Size = new System.Drawing.Size(82, 13);
			this.lblFromVoucherNo.TabIndex = 38;
			// 
			// txtCostCenterCode
			// 
			this.txtCostCenterCode.AllowDrop = true;
			this.txtCostCenterCode.BackColor = System.Drawing.Color.White;
			this.txtCostCenterCode.ForeColor = System.Drawing.Color.Black;
			this.txtCostCenterCode.Location = new System.Drawing.Point(656, 186);
			this.txtCostCenterCode.Name = "txtCostCenterCode";
			// this.txtCostCenterCode.ShowButton = true;
			this.txtCostCenterCode.Size = new System.Drawing.Size(101, 19);
			this.txtCostCenterCode.TabIndex = 15;
			this.txtCostCenterCode.Text = "";
			this.txtCostCenterCode.Visible = false;
			// this.this.txtCostCenterCode.Watermark = "";
			// 
			// lblCostCenterCode
			// 
			this.lblCostCenterCode.AllowDrop = true;
			this.lblCostCenterCode.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this.lblCostCenterCode.ForeColor = System.Drawing.Color.Black;
			this.lblCostCenterCode.Location = new System.Drawing.Point(522, 188);
			this.lblCostCenterCode.Name = "lblCostCenterCode";
			this.lblCostCenterCode.Size = new System.Drawing.Size(86, 13);
			this.lblCostCenterCode.TabIndex = 39;
			this.lblCostCenterCode.Visible = false;
			// 
			// txtLocationName
			// 
			this.txtLocationName.AllowDrop = true;
			this.txtLocationName.Location = new System.Drawing.Point(522, 69);
			this.txtLocationName.Name = "txtLocationName";
			this.txtLocationName.Size = new System.Drawing.Size(235, 19);
			this.txtLocationName.TabIndex = 3;
			this.txtLocationName.TabStop = false;
			this.txtLocationName.Visible = false;
			// 
			// txtMasterName
			// 
			this.txtMasterName.AllowDrop = true;
			this.txtMasterName.Location = new System.Drawing.Point(522, 26);
			this.txtMasterName.Name = "txtMasterName";
			this.txtMasterName.Size = new System.Drawing.Size(235, 19);
			this.txtMasterName.TabIndex = 4;
			this.txtMasterName.TabStop = false;
			this.txtMasterName.Visible = false;
			// 
			// lblReportFilter
			// 
			this.lblReportFilter.AllowDrop = true;
			this.lblReportFilter.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this.lblReportFilter.ForeColor = System.Drawing.Color.Black;
			this.lblReportFilter.Location = new System.Drawing.Point(524, 142);
			this.lblReportFilter.Name = "lblReportFilter";
			this.lblReportFilter.Size = new System.Drawing.Size(31, 13);
			this.lblReportFilter.TabIndex = 40;
			this.lblReportFilter.Visible = false;
			// 
			// imlShortcutBarIcons
			// 
			this.imlShortcutBarIcons.ImageSize = new System.Drawing.Size(16, 16);
			// this.imlShortcutBarIcons.ImageStream = (System.Windows.Forms.ImageListStreamer) resources.GetObject("imlShortcutBarIcons.ImageStream");
			this.imlShortcutBarIcons.TransparentColor = System.Drawing.Color.Silver;
			this.imlShortcutBarIcons.Images.SetKeyName(0, "");
			this.imlShortcutBarIcons.Images.SetKeyName(1, "");
			this.imlShortcutBarIcons.Images.SetKeyName(2, "");
			this.imlShortcutBarIcons.Images.SetKeyName(3, "");
			this.imlShortcutBarIcons.Images.SetKeyName(4, "");
			this.imlShortcutBarIcons.Images.SetKeyName(5, "");
			this.imlShortcutBarIcons.Images.SetKeyName(6, "");
			this.imlShortcutBarIcons.Images.SetKeyName(7, "");
			this.imlShortcutBarIcons.Images.SetKeyName(8, "");
			this.imlShortcutBarIcons.Images.SetKeyName(9, "");
			this.imlShortcutBarIcons.Images.SetKeyName(10, "");
			this.imlShortcutBarIcons.Images.SetKeyName(11, "");
			// 
			// frmSysReportingModule
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.ClientSize = new System.Drawing.Size(1092, 582);
			this.Controls.Add(this.tabMaster);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			//this.Icon = (System.Drawing.Icon) resources.GetObject("frmSysReportingModule.Icon");
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(146, 185);
			this.MaximizeBox = true;
			this.MinimizeBox = true;
			this.Name = "frmSysReportingModule";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Reporting Module";
			// this.Activated += new System.EventHandler(this.frmSysReportingModule_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
			// this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
			//this.Resize += new System.EventHandler(this.Form_Resize);
			this.listViewHelper1.SetItemClickMethod(this.lstReport, "lstReport_ItemClick");
			this.listViewHelper1.SetCorrectEventsBehavior(this.lstReport, true);
			this.listViewHelper1.SetItemClickMethod(this.lstGroup, "lstGroup_ItemClick");
			this.listViewHelper1.SetCorrectEventsBehavior(this.lstGroup, true);
			//((System.ComponentModel.ISupportInitialize) this.listViewHelper1).EndInit();
			//((System.ComponentModel.ISupportInitialize) this.rptLevelSlider).EndInit();
			//((System.ComponentModel.ISupportInitialize) this.tabMaster).EndInit();
			this.tabMaster.ResumeLayout(false);
			this.fraLedgerInformation.ResumeLayout(false);
			this.fraCostCenter.ResumeLayout(false);
			this.fraOptions.ResumeLayout(false);
			this.fraDateRange.ResumeLayout(false);
			this.lstGroup.ResumeLayout(false);
			this.lstReport.ResumeLayout(false);
			this.fraVoucherRange.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		// 
		#endregion
	}
}//ENDSHERE
