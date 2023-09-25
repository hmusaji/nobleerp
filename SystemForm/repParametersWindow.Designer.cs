
namespace Xtreme
{
	partial class repParametersWindow
	{

		#region "Upgrade Support "
		private static repParametersWindow m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static repParametersWindow DefInstance
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
		public static repParametersWindow CreateInstance()
		{
			repParametersWindow theInstance = new repParametersWindow();
			
			return theInstance;
		}
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "txtDAnalysisName2", "txtDAnalysisName1", "txtAnalysisCode2", "txtAnalysisCode1", "lblAnalysisCode2", "lblAnalysisCode1", "chkShowLedgerWithZeroBalance", "chkShowLYCurrentBalance", "chkShowLYProfitAndLoss", "chkShowLYOpeningBalance", "chkShowCYProfitAndLoss", "chkShowCYCurrentBalance", "chkShowCYOpeningBalance", "txtProjectCode", "lblProjectCode", "txtDProjectName", "txtCostCenterCode", "lblCostCenterCode", "txtDCostCenterName", "txtTabSpaceInTree", "lblReportLevel", "txtGroupPrefix", "lblGroupPrefix", "txtGroupSuffix", "lblGroupSuffix", "lblTabSpaceInTree", "cmbReportLevel", "fraOptions", "cmdOKCancel", "lblVoucherRange", "txtToVoucherNo", "lblToVoucherNo", "txtFromVoucherNo", "lblFromVoucherNo", "fraVoucherRange", "txtLocationCode", "lblLocationCode", "lblDateRange", "lblToDate", "lblFromDate", "txtFromDate", "txtToDate", "fraDateRange", "lblMasterCode", "txtMasterCode", "txtLocationName", "txtMasterName", "cntMainParameter", "_lblCommon_6", "cmdPostMode", "Line1", "lblCommon"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public System.Windows.Forms.Label txtDAnalysisName2;
		public System.Windows.Forms.Label txtDAnalysisName1;
		public System.Windows.Forms.TextBox txtAnalysisCode2;
		public System.Windows.Forms.TextBox txtAnalysisCode1;
		public System.Windows.Forms.Label lblAnalysisCode2;
		public System.Windows.Forms.Label lblAnalysisCode1;
		public System.Windows.Forms.CheckBox chkShowLedgerWithZeroBalance;
		public System.Windows.Forms.CheckBox chkShowLYCurrentBalance;
		public System.Windows.Forms.CheckBox chkShowLYProfitAndLoss;
		public System.Windows.Forms.CheckBox chkShowLYOpeningBalance;
		public System.Windows.Forms.CheckBox chkShowCYProfitAndLoss;
		public System.Windows.Forms.CheckBox chkShowCYCurrentBalance;
		public System.Windows.Forms.CheckBox chkShowCYOpeningBalance;
		public System.Windows.Forms.TextBox txtProjectCode;
		public System.Windows.Forms.Label lblProjectCode;
		public System.Windows.Forms.Label txtDProjectName;
		public System.Windows.Forms.TextBox txtCostCenterCode;
		public System.Windows.Forms.Label lblCostCenterCode;
		public System.Windows.Forms.Label txtDCostCenterName;
		public System.Windows.Forms.TextBox txtTabSpaceInTree;
		public System.Windows.Forms.Label lblReportLevel;
		public System.Windows.Forms.TextBox txtGroupPrefix;
		public System.Windows.Forms.Label lblGroupPrefix;
		public System.Windows.Forms.TextBox txtGroupSuffix;
		public System.Windows.Forms.Label lblGroupSuffix;
		public System.Windows.Forms.Label lblTabSpaceInTree;
		public System.Windows.Forms.ComboBox cmbReportLevel;
		public System.Windows.Forms.Panel fraOptions;
		public UCOkCancel cmdOKCancel;
		public System.Windows.Forms.Label lblVoucherRange;
		public System.Windows.Forms.TextBox txtToVoucherNo;
		public System.Windows.Forms.Label lblToVoucherNo;
		public System.Windows.Forms.TextBox txtFromVoucherNo;
		public System.Windows.Forms.Label lblFromVoucherNo;
		public System.Windows.Forms.Panel fraVoucherRange;
		public System.Windows.Forms.TextBox txtLocationCode;
		public System.Windows.Forms.Label lblLocationCode;
		public System.Windows.Forms.Label lblDateRange;
		public System.Windows.Forms.Label lblToDate;
		public System.Windows.Forms.Label lblFromDate;
		public Syncfusion.WinForms.Input.SfDateTimeEdit txtFromDate;
		public Syncfusion.WinForms.Input.SfDateTimeEdit txtToDate;
		public System.Windows.Forms.Panel fraDateRange;
		public System.Windows.Forms.Label lblMasterCode;
		public System.Windows.Forms.TextBox txtMasterCode;
		public System.Windows.Forms.Label txtLocationName;
		public System.Windows.Forms.Label txtMasterName;
		public System.Windows.Forms.Panel cntMainParameter;
		private System.Windows.Forms.Label _lblCommon_6;
		public UCOkCancel cmdPostMode;
		public System.Windows.Forms.Label Line1;
		public System.Windows.Forms.Label[] lblCommon = new System.Windows.Forms.Label[7];
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(repParametersWindow));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this.fraOptions = new System.Windows.Forms.Panel();
			this.txtDAnalysisName2 = new System.Windows.Forms.Label();
			this.txtDAnalysisName1 = new System.Windows.Forms.Label();
			this.txtAnalysisCode2 = new System.Windows.Forms.TextBox();
			this.txtAnalysisCode1 = new System.Windows.Forms.TextBox();
			this.lblAnalysisCode2 = new System.Windows.Forms.Label();
			this.lblAnalysisCode1 = new System.Windows.Forms.Label();
			this.chkShowLedgerWithZeroBalance = new System.Windows.Forms.CheckBox();
			this.chkShowLYCurrentBalance = new System.Windows.Forms.CheckBox();
			this.chkShowLYProfitAndLoss = new System.Windows.Forms.CheckBox();
			this.chkShowLYOpeningBalance = new System.Windows.Forms.CheckBox();
			this.chkShowCYProfitAndLoss = new System.Windows.Forms.CheckBox();
			this.chkShowCYCurrentBalance = new System.Windows.Forms.CheckBox();
			this.chkShowCYOpeningBalance = new System.Windows.Forms.CheckBox();
			this.txtProjectCode = new System.Windows.Forms.TextBox();
			this.lblProjectCode = new System.Windows.Forms.Label();
			this.txtDProjectName = new System.Windows.Forms.Label();
			this.txtCostCenterCode = new System.Windows.Forms.TextBox();
			this.lblCostCenterCode = new System.Windows.Forms.Label();
			this.txtDCostCenterName = new System.Windows.Forms.Label();
			this.txtTabSpaceInTree = new System.Windows.Forms.TextBox();
			this.lblReportLevel = new System.Windows.Forms.Label();
			this.txtGroupPrefix = new System.Windows.Forms.TextBox();
			this.lblGroupPrefix = new System.Windows.Forms.Label();
			this.txtGroupSuffix = new System.Windows.Forms.TextBox();
			this.lblGroupSuffix = new System.Windows.Forms.Label();
			this.lblTabSpaceInTree = new System.Windows.Forms.Label();
			this.cmbReportLevel = new System.Windows.Forms.ComboBox();
			this.cmdOKCancel = new UCOkCancel();
			this.cntMainParameter = new System.Windows.Forms.Panel();
			this.lblVoucherRange = new System.Windows.Forms.Label();
			this.fraVoucherRange = new System.Windows.Forms.Panel();
			this.txtToVoucherNo = new System.Windows.Forms.TextBox();
			this.lblToVoucherNo = new System.Windows.Forms.Label();
			this.txtFromVoucherNo = new System.Windows.Forms.TextBox();
			this.lblFromVoucherNo = new System.Windows.Forms.Label();
			this.txtLocationCode = new System.Windows.Forms.TextBox();
			this.lblLocationCode = new System.Windows.Forms.Label();
			this.lblDateRange = new System.Windows.Forms.Label();
			this.fraDateRange = new System.Windows.Forms.Panel();
			this.lblToDate = new System.Windows.Forms.Label();
			this.lblFromDate = new System.Windows.Forms.Label();
			this.txtFromDate = new Syncfusion.WinForms.Input.SfDateTimeEdit();
			this.txtToDate = new Syncfusion.WinForms.Input.SfDateTimeEdit();
			this.lblMasterCode = new System.Windows.Forms.Label();
			this.txtMasterCode = new System.Windows.Forms.TextBox();
			this.txtLocationName = new System.Windows.Forms.Label();
			this.txtMasterName = new System.Windows.Forms.Label();
			this._lblCommon_6 = new System.Windows.Forms.Label();
			this.cmdPostMode = new UCOkCancel();
			this.Line1 = new System.Windows.Forms.Label();
			// //((System.ComponentModel.ISupportInitialize) this.cntMainParameter).BeginInit();
			this.fraOptions.SuspendLayout();
			this.cntMainParameter.SuspendLayout();
			this.fraVoucherRange.SuspendLayout();
			this.fraDateRange.SuspendLayout();
			this.SuspendLayout();
			// 
			// fraOptions
			// 
			this.fraOptions.AllowDrop = true;
			this.fraOptions.BackColor = System.Drawing.Color.FromArgb(176, 178, 156);
			this.fraOptions.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.fraOptions.Controls.Add(this.txtDAnalysisName2);
			this.fraOptions.Controls.Add(this.txtDAnalysisName1);
			this.fraOptions.Controls.Add(this.txtAnalysisCode2);
			this.fraOptions.Controls.Add(this.txtAnalysisCode1);
			this.fraOptions.Controls.Add(this.lblAnalysisCode2);
			this.fraOptions.Controls.Add(this.lblAnalysisCode1);
			this.fraOptions.Controls.Add(this.chkShowLedgerWithZeroBalance);
			this.fraOptions.Controls.Add(this.chkShowLYCurrentBalance);
			this.fraOptions.Controls.Add(this.chkShowLYProfitAndLoss);
			this.fraOptions.Controls.Add(this.chkShowLYOpeningBalance);
			this.fraOptions.Controls.Add(this.chkShowCYProfitAndLoss);
			this.fraOptions.Controls.Add(this.chkShowCYCurrentBalance);
			this.fraOptions.Controls.Add(this.chkShowCYOpeningBalance);
			this.fraOptions.Controls.Add(this.txtProjectCode);
			this.fraOptions.Controls.Add(this.lblProjectCode);
			this.fraOptions.Controls.Add(this.txtDProjectName);
			this.fraOptions.Controls.Add(this.txtCostCenterCode);
			this.fraOptions.Controls.Add(this.lblCostCenterCode);
			this.fraOptions.Controls.Add(this.txtDCostCenterName);
			this.fraOptions.Controls.Add(this.txtTabSpaceInTree);
			this.fraOptions.Controls.Add(this.lblReportLevel);
			this.fraOptions.Controls.Add(this.txtGroupPrefix);
			this.fraOptions.Controls.Add(this.lblGroupPrefix);
			this.fraOptions.Controls.Add(this.txtGroupSuffix);
			this.fraOptions.Controls.Add(this.lblGroupSuffix);
			this.fraOptions.Controls.Add(this.lblTabSpaceInTree);
			this.fraOptions.Controls.Add(this.cmbReportLevel);
			this.fraOptions.Enabled = false;
			this.fraOptions.ForeColor = System.Drawing.SystemColors.WindowText;
			this.fraOptions.Location = new System.Drawing.Point(2, 246);
			this.fraOptions.Name = "fraOptions";
			this.fraOptions.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.fraOptions.Size = new System.Drawing.Size(460, 224);
			this.fraOptions.TabIndex = 37;
			this.fraOptions.Text = " Partial Posting Options ";
			this.fraOptions.Visible = true;
			// 
			// txtDAnalysisName2
			// 
			this.txtDAnalysisName2.AllowDrop = true;
			this.txtDAnalysisName2.BackColor = System.Drawing.SystemColors.Window;
			this.txtDAnalysisName2.Enabled = false;
			this.txtDAnalysisName2.Location = new System.Drawing.Point(206, 73);
			this.txtDAnalysisName2.Name = "txtDAnalysisName2";
			this.txtDAnalysisName2.Size = new System.Drawing.Size(201, 19);
			this.txtDAnalysisName2.TabIndex = 45;
			// 
			// txtDAnalysisName1
			// 
			this.txtDAnalysisName1.AllowDrop = true;
			this.txtDAnalysisName1.BackColor = System.Drawing.SystemColors.Window;
			this.txtDAnalysisName1.Enabled = false;
			this.txtDAnalysisName1.Location = new System.Drawing.Point(206, 52);
			this.txtDAnalysisName1.Name = "txtDAnalysisName1";
			this.txtDAnalysisName1.Size = new System.Drawing.Size(201, 19);
			this.txtDAnalysisName1.TabIndex = 44;
			// 
			// txtAnalysisCode2
			// 
			this.txtAnalysisCode2.AllowDrop = true;
			this.txtAnalysisCode2.BackColor = System.Drawing.Color.White;
			// this.txtAnalysisCode2.bolAllowDecimal = false;
			this.txtAnalysisCode2.ForeColor = System.Drawing.Color.Black;
			this.txtAnalysisCode2.Location = new System.Drawing.Point(103, 73);
			this.txtAnalysisCode2.MaxLength = 12;
			// this.txtAnalysisCode2.mDropDownType = (System.Windows.Forms.TextBox.DropDownTypes) 0;
			this.txtAnalysisCode2.Name = "txtAnalysisCode2";
			// this.txtAnalysisCode2.ShowButton = true;
			this.txtAnalysisCode2.Size = new System.Drawing.Size(101, 19);
			this.txtAnalysisCode2.TabIndex = 11;
			this.txtAnalysisCode2.Text = "";
			// this.this.txtAnalysisCode2.Watermark = "";
			// this.this.txtAnalysisCode2.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtAnalysisCode2_DropButtonClick);
			// this.txtAnalysisCode2.Leave += new System.EventHandler(this.txtAnalysisCode2_Leave);
			// 
			// txtAnalysisCode1
			// 
			this.txtAnalysisCode1.AllowDrop = true;
			this.txtAnalysisCode1.BackColor = System.Drawing.Color.White;
			// this.txtAnalysisCode1.bolAllowDecimal = false;
			this.txtAnalysisCode1.ForeColor = System.Drawing.Color.Black;
			this.txtAnalysisCode1.Location = new System.Drawing.Point(103, 52);
			this.txtAnalysisCode1.MaxLength = 12;
			// this.txtAnalysisCode1.mDropDownType = (System.Windows.Forms.TextBox.DropDownTypes) 0;
			this.txtAnalysisCode1.Name = "txtAnalysisCode1";
			// this.txtAnalysisCode1.ShowButton = true;
			this.txtAnalysisCode1.Size = new System.Drawing.Size(101, 19);
			this.txtAnalysisCode1.TabIndex = 10;
			this.txtAnalysisCode1.Text = "";
			// this.this.txtAnalysisCode1.Watermark = "";
			// this.this.txtAnalysisCode1.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtAnalysisCode1_DropButtonClick);
			// this.txtAnalysisCode1.Leave += new System.EventHandler(this.txtAnalysisCode1_Leave);
			// 
			// lblAnalysisCode2
			// 
			this.lblAnalysisCode2.AllowDrop = true;
			this.lblAnalysisCode2.BackColor = System.Drawing.SystemColors.Window;
			this.lblAnalysisCode2.Text = "Analysis Code 2";
			this.lblAnalysisCode2.ForeColor = System.Drawing.Color.Black;
			this.lblAnalysisCode2.Location = new System.Drawing.Point(9, 76);
			this.lblAnalysisCode2.Name = "lblAnalysisCode2";
			this.lblAnalysisCode2.Size = new System.Drawing.Size(75, 13);
			this.lblAnalysisCode2.TabIndex = 43;
			// 
			// lblAnalysisCode1
			// 
			this.lblAnalysisCode1.AllowDrop = true;
			this.lblAnalysisCode1.BackColor = System.Drawing.SystemColors.Window;
			this.lblAnalysisCode1.Text = "Analysis Code 1";
			this.lblAnalysisCode1.ForeColor = System.Drawing.Color.Black;
			this.lblAnalysisCode1.Location = new System.Drawing.Point(9, 55);
			this.lblAnalysisCode1.Name = "lblAnalysisCode1";
			this.lblAnalysisCode1.Size = new System.Drawing.Size(75, 13);
			this.lblAnalysisCode1.TabIndex = 42;
			// 
			// chkShowLedgerWithZeroBalance
			// 
			this.chkShowLedgerWithZeroBalance.AllowDrop = true;
			this.chkShowLedgerWithZeroBalance.Appearance = System.Windows.Forms.Appearance.Normal;
			this.chkShowLedgerWithZeroBalance.BackColor = System.Drawing.Color.FromArgb(176, 178, 156);
			this.chkShowLedgerWithZeroBalance.CausesValidation = true;
			this.chkShowLedgerWithZeroBalance.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkShowLedgerWithZeroBalance.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this.chkShowLedgerWithZeroBalance.Enabled = true;
			this.chkShowLedgerWithZeroBalance.ForeColor = System.Drawing.Color.Black;
			this.chkShowLedgerWithZeroBalance.Location = new System.Drawing.Point(254, 196);
			this.chkShowLedgerWithZeroBalance.Name = "chkShowLedgerWithZeroBalance";
			this.chkShowLedgerWithZeroBalance.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.chkShowLedgerWithZeroBalance.Size = new System.Drawing.Size(205, 15);
			this.chkShowLedgerWithZeroBalance.TabIndex = 22;
			this.chkShowLedgerWithZeroBalance.TabStop = true;
			this.chkShowLedgerWithZeroBalance.Text = "Show Ledger With Zero Balance";
			this.chkShowLedgerWithZeroBalance.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkShowLedgerWithZeroBalance.Visible = true;
			// 
			// chkShowLYCurrentBalance
			// 
			this.chkShowLYCurrentBalance.AllowDrop = true;
			this.chkShowLYCurrentBalance.Appearance = System.Windows.Forms.Appearance.Normal;
			this.chkShowLYCurrentBalance.BackColor = System.Drawing.Color.FromArgb(176, 178, 156);
			this.chkShowLYCurrentBalance.CausesValidation = true;
			this.chkShowLYCurrentBalance.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkShowLYCurrentBalance.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this.chkShowLYCurrentBalance.Enabled = true;
			this.chkShowLYCurrentBalance.ForeColor = System.Drawing.Color.Black;
			this.chkShowLYCurrentBalance.Location = new System.Drawing.Point(254, 162);
			this.chkShowLYCurrentBalance.Name = "chkShowLYCurrentBalance";
			this.chkShowLYCurrentBalance.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.chkShowLYCurrentBalance.Size = new System.Drawing.Size(157, 15);
			this.chkShowLYCurrentBalance.TabIndex = 20;
			this.chkShowLYCurrentBalance.TabStop = true;
			this.chkShowLYCurrentBalance.Text = "Show LY Current Balance";
			this.chkShowLYCurrentBalance.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkShowLYCurrentBalance.Visible = true;
			// 
			// chkShowLYProfitAndLoss
			// 
			this.chkShowLYProfitAndLoss.AllowDrop = true;
			this.chkShowLYProfitAndLoss.Appearance = System.Windows.Forms.Appearance.Normal;
			this.chkShowLYProfitAndLoss.BackColor = System.Drawing.Color.FromArgb(176, 178, 156);
			this.chkShowLYProfitAndLoss.CausesValidation = true;
			this.chkShowLYProfitAndLoss.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkShowLYProfitAndLoss.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this.chkShowLYProfitAndLoss.Enabled = true;
			this.chkShowLYProfitAndLoss.ForeColor = System.Drawing.Color.Black;
			this.chkShowLYProfitAndLoss.Location = new System.Drawing.Point(254, 179);
			this.chkShowLYProfitAndLoss.Name = "chkShowLYProfitAndLoss";
			this.chkShowLYProfitAndLoss.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.chkShowLYProfitAndLoss.Size = new System.Drawing.Size(157, 15);
			this.chkShowLYProfitAndLoss.TabIndex = 21;
			this.chkShowLYProfitAndLoss.TabStop = true;
			this.chkShowLYProfitAndLoss.Text = "Show LY Profit and Loss";
			this.chkShowLYProfitAndLoss.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkShowLYProfitAndLoss.Visible = true;
			// 
			// chkShowLYOpeningBalance
			// 
			this.chkShowLYOpeningBalance.AllowDrop = true;
			this.chkShowLYOpeningBalance.Appearance = System.Windows.Forms.Appearance.Normal;
			this.chkShowLYOpeningBalance.BackColor = System.Drawing.Color.FromArgb(176, 178, 156);
			this.chkShowLYOpeningBalance.CausesValidation = true;
			this.chkShowLYOpeningBalance.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkShowLYOpeningBalance.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this.chkShowLYOpeningBalance.Enabled = true;
			this.chkShowLYOpeningBalance.ForeColor = System.Drawing.Color.Black;
			this.chkShowLYOpeningBalance.Location = new System.Drawing.Point(254, 145);
			this.chkShowLYOpeningBalance.Name = "chkShowLYOpeningBalance";
			this.chkShowLYOpeningBalance.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.chkShowLYOpeningBalance.Size = new System.Drawing.Size(157, 15);
			this.chkShowLYOpeningBalance.TabIndex = 19;
			this.chkShowLYOpeningBalance.TabStop = true;
			this.chkShowLYOpeningBalance.Text = "Show LY Opening Balance";
			this.chkShowLYOpeningBalance.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkShowLYOpeningBalance.Visible = true;
			// 
			// chkShowCYProfitAndLoss
			// 
			this.chkShowCYProfitAndLoss.AllowDrop = true;
			this.chkShowCYProfitAndLoss.Appearance = System.Windows.Forms.Appearance.Normal;
			this.chkShowCYProfitAndLoss.BackColor = System.Drawing.Color.FromArgb(176, 178, 156);
			this.chkShowCYProfitAndLoss.CausesValidation = true;
			this.chkShowCYProfitAndLoss.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkShowCYProfitAndLoss.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this.chkShowCYProfitAndLoss.Enabled = true;
			this.chkShowCYProfitAndLoss.ForeColor = System.Drawing.Color.Black;
			this.chkShowCYProfitAndLoss.Location = new System.Drawing.Point(254, 128);
			this.chkShowCYProfitAndLoss.Name = "chkShowCYProfitAndLoss";
			this.chkShowCYProfitAndLoss.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.chkShowCYProfitAndLoss.Size = new System.Drawing.Size(157, 15);
			this.chkShowCYProfitAndLoss.TabIndex = 18;
			this.chkShowCYProfitAndLoss.TabStop = true;
			this.chkShowCYProfitAndLoss.Text = "Show CY Profit and Loss";
			this.chkShowCYProfitAndLoss.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkShowCYProfitAndLoss.Visible = true;
			// 
			// chkShowCYCurrentBalance
			// 
			this.chkShowCYCurrentBalance.AllowDrop = true;
			this.chkShowCYCurrentBalance.Appearance = System.Windows.Forms.Appearance.Normal;
			this.chkShowCYCurrentBalance.BackColor = System.Drawing.Color.FromArgb(176, 178, 156);
			this.chkShowCYCurrentBalance.CausesValidation = true;
			this.chkShowCYCurrentBalance.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkShowCYCurrentBalance.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this.chkShowCYCurrentBalance.Enabled = true;
			this.chkShowCYCurrentBalance.ForeColor = System.Drawing.Color.Black;
			this.chkShowCYCurrentBalance.Location = new System.Drawing.Point(254, 111);
			this.chkShowCYCurrentBalance.Name = "chkShowCYCurrentBalance";
			this.chkShowCYCurrentBalance.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.chkShowCYCurrentBalance.Size = new System.Drawing.Size(157, 15);
			this.chkShowCYCurrentBalance.TabIndex = 17;
			this.chkShowCYCurrentBalance.TabStop = true;
			this.chkShowCYCurrentBalance.Text = "Show CY Current Balance";
			this.chkShowCYCurrentBalance.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkShowCYCurrentBalance.Visible = true;
			// 
			// chkShowCYOpeningBalance
			// 
			this.chkShowCYOpeningBalance.AllowDrop = true;
			this.chkShowCYOpeningBalance.Appearance = System.Windows.Forms.Appearance.Normal;
			this.chkShowCYOpeningBalance.BackColor = System.Drawing.Color.FromArgb(176, 178, 156);
			this.chkShowCYOpeningBalance.CausesValidation = true;
			this.chkShowCYOpeningBalance.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkShowCYOpeningBalance.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this.chkShowCYOpeningBalance.Enabled = true;
			this.chkShowCYOpeningBalance.ForeColor = System.Drawing.Color.Black;
			this.chkShowCYOpeningBalance.Location = new System.Drawing.Point(254, 94);
			this.chkShowCYOpeningBalance.Name = "chkShowCYOpeningBalance";
			this.chkShowCYOpeningBalance.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.chkShowCYOpeningBalance.Size = new System.Drawing.Size(157, 15);
			this.chkShowCYOpeningBalance.TabIndex = 16;
			this.chkShowCYOpeningBalance.TabStop = true;
			this.chkShowCYOpeningBalance.Text = "Show CY Opening Balance";
			this.chkShowCYOpeningBalance.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkShowCYOpeningBalance.Visible = true;
			// 
			// txtProjectCode
			// 
			this.txtProjectCode.AllowDrop = true;
			this.txtProjectCode.BackColor = System.Drawing.Color.White;
			this.txtProjectCode.ForeColor = System.Drawing.Color.Black;
			this.txtProjectCode.Location = new System.Drawing.Point(103, 31);
			this.txtProjectCode.Name = "txtProjectCode";
			// this.txtProjectCode.ShowButton = true;
			this.txtProjectCode.Size = new System.Drawing.Size(101, 19);
			this.txtProjectCode.TabIndex = 9;
			this.txtProjectCode.Text = "";
			// this.this.txtProjectCode.Watermark = "";
			// this.this.txtProjectCode.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtProjectCode_DropButtonClick);
			// this.txtProjectCode.Leave += new System.EventHandler(this.txtProjectCode_Leave);
			// 
			// lblProjectCode
			// 
			this.lblProjectCode.AllowDrop = true;
			this.lblProjectCode.BackColor = System.Drawing.SystemColors.Window;
			this.lblProjectCode.Text = "Project Code";
			this.lblProjectCode.ForeColor = System.Drawing.Color.Black;
			this.lblProjectCode.Location = new System.Drawing.Point(9, 34);
			this.lblProjectCode.Name = "lblProjectCode";
			this.lblProjectCode.Size = new System.Drawing.Size(62, 13);
			this.lblProjectCode.TabIndex = 38;
			// 
			// txtDProjectName
			// 
			this.txtDProjectName.AllowDrop = true;
			this.txtDProjectName.Enabled = false;
			this.txtDProjectName.Location = new System.Drawing.Point(206, 31);
			this.txtDProjectName.Name = "txtDProjectName";
			this.txtDProjectName.Size = new System.Drawing.Size(201, 19);
			this.txtDProjectName.TabIndex = 39;
			// 
			// txtCostCenterCode
			// 
			this.txtCostCenterCode.AllowDrop = true;
			this.txtCostCenterCode.BackColor = System.Drawing.Color.White;
			this.txtCostCenterCode.ForeColor = System.Drawing.Color.Black;
			this.txtCostCenterCode.Location = new System.Drawing.Point(103, 10);
			this.txtCostCenterCode.Name = "txtCostCenterCode";
			// this.txtCostCenterCode.ShowButton = true;
			this.txtCostCenterCode.Size = new System.Drawing.Size(101, 19);
			this.txtCostCenterCode.TabIndex = 8;
			this.txtCostCenterCode.Text = "";
			// this.this.txtCostCenterCode.Watermark = "";
			// this.this.txtCostCenterCode.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCostCenterCode_DropButtonClick);
			// this.txtCostCenterCode.Leave += new System.EventHandler(this.txtCostCenterCode_Leave);
			// 
			// lblCostCenterCode
			// 
			this.lblCostCenterCode.AllowDrop = true;
			this.lblCostCenterCode.BackColor = System.Drawing.SystemColors.Window;
			this.lblCostCenterCode.Text = "Cost Center Code";
			this.lblCostCenterCode.ForeColor = System.Drawing.Color.Black;
			this.lblCostCenterCode.Location = new System.Drawing.Point(9, 13);
			this.lblCostCenterCode.Name = "lblCostCenterCode";
			this.lblCostCenterCode.Size = new System.Drawing.Size(86, 13);
			this.lblCostCenterCode.TabIndex = 40;
			// 
			// txtDCostCenterName
			// 
			this.txtDCostCenterName.AllowDrop = true;
			this.txtDCostCenterName.Enabled = false;
			this.txtDCostCenterName.Location = new System.Drawing.Point(206, 10);
			this.txtDCostCenterName.Name = "txtDCostCenterName";
			this.txtDCostCenterName.Size = new System.Drawing.Size(201, 19);
			this.txtDCostCenterName.TabIndex = 41;
			// 
			// txtTabSpaceInTree
			// 
			this.txtTabSpaceInTree.AllowDrop = true;
			this.txtTabSpaceInTree.Location = new System.Drawing.Point(103, 159);
			// this.txtTabSpaceInTree.MaxValue = 50;
			// this.txtTabSpaceInTree.MinValue = 0;
			this.txtTabSpaceInTree.Name = "txtTabSpaceInTree";
			this.txtTabSpaceInTree.Size = new System.Drawing.Size(101, 19);
			this.txtTabSpaceInTree.TabIndex = 15;
			// 
			// lblReportLevel
			// 
			this.lblReportLevel.AllowDrop = true;
			this.lblReportLevel.BackColor = System.Drawing.SystemColors.Window;
			this.lblReportLevel.Text = "Report Level";
			this.lblReportLevel.ForeColor = System.Drawing.Color.Black;
			this.lblReportLevel.Location = new System.Drawing.Point(9, 98);
			this.lblReportLevel.Name = "lblReportLevel";
			this.lblReportLevel.Size = new System.Drawing.Size(61, 13);
			this.lblReportLevel.TabIndex = 46;
			// 
			// txtGroupPrefix
			// 
			this.txtGroupPrefix.AllowDrop = true;
			this.txtGroupPrefix.BackColor = System.Drawing.Color.White;
			this.txtGroupPrefix.ForeColor = System.Drawing.Color.Black;
			this.txtGroupPrefix.Location = new System.Drawing.Point(103, 117);
			this.txtGroupPrefix.MaxLength = 12;
			// this.txtGroupPrefix.mDropDownType = (System.Windows.Forms.TextBox.DropDownTypes) 0;
			this.txtGroupPrefix.Name = "txtGroupPrefix";
			this.txtGroupPrefix.Size = new System.Drawing.Size(101, 19);
			this.txtGroupPrefix.TabIndex = 13;
			this.txtGroupPrefix.Text = "";
			// this.this.txtGroupPrefix.Watermark = "";
			// 
			// lblGroupPrefix
			// 
			this.lblGroupPrefix.AllowDrop = true;
			this.lblGroupPrefix.BackColor = System.Drawing.SystemColors.Window;
			this.lblGroupPrefix.Text = "Group Prefix";
			this.lblGroupPrefix.ForeColor = System.Drawing.Color.Black;
			this.lblGroupPrefix.Location = new System.Drawing.Point(9, 120);
			this.lblGroupPrefix.Name = "lblGroupPrefix";
			this.lblGroupPrefix.Size = new System.Drawing.Size(60, 13);
			this.lblGroupPrefix.TabIndex = 47;
			// 
			// txtGroupSuffix
			// 
			this.txtGroupSuffix.AllowDrop = true;
			this.txtGroupSuffix.BackColor = System.Drawing.Color.White;
			this.txtGroupSuffix.ForeColor = System.Drawing.Color.Black;
			this.txtGroupSuffix.Location = new System.Drawing.Point(103, 138);
			this.txtGroupSuffix.MaxLength = 12;
			// this.txtGroupSuffix.mDropDownType = (System.Windows.Forms.TextBox.DropDownTypes) 0;
			this.txtGroupSuffix.Name = "txtGroupSuffix";
			this.txtGroupSuffix.Size = new System.Drawing.Size(101, 19);
			this.txtGroupSuffix.TabIndex = 14;
			this.txtGroupSuffix.Text = "";
			// this.this.txtGroupSuffix.Watermark = "";
			// 
			// lblGroupSuffix
			// 
			this.lblGroupSuffix.AllowDrop = true;
			this.lblGroupSuffix.BackColor = System.Drawing.SystemColors.Window;
			this.lblGroupSuffix.Text = "Group Suffix";
			this.lblGroupSuffix.ForeColor = System.Drawing.Color.Black;
			this.lblGroupSuffix.Location = new System.Drawing.Point(9, 141);
			this.lblGroupSuffix.Name = "lblGroupSuffix";
			this.lblGroupSuffix.Size = new System.Drawing.Size(60, 13);
			this.lblGroupSuffix.TabIndex = 48;
			// 
			// lblTabSpaceInTree
			// 
			this.lblTabSpaceInTree.AllowDrop = true;
			this.lblTabSpaceInTree.BackColor = System.Drawing.SystemColors.Window;
			this.lblTabSpaceInTree.Text = "Tab Space In Tree";
			this.lblTabSpaceInTree.ForeColor = System.Drawing.Color.Black;
			this.lblTabSpaceInTree.Location = new System.Drawing.Point(9, 162);
			this.lblTabSpaceInTree.Name = "lblTabSpaceInTree";
			this.lblTabSpaceInTree.Size = new System.Drawing.Size(88, 13);
			this.lblTabSpaceInTree.TabIndex = 49;
			// 
			// cmbReportLevel
			// 
			this.cmbReportLevel.AllowDrop = true;
			this.cmbReportLevel.Location = new System.Drawing.Point(103, 94);
			this.cmbReportLevel.Name = "cmbReportLevel";
			this.cmbReportLevel.Size = new System.Drawing.Size(101, 21);
			this.cmbReportLevel.TabIndex = 12;
			// 
			// cmdOKCancel
			// 
			this.cmdOKCancel.AllowDrop = true;
			this.cmdOKCancel.Location = new System.Drawing.Point(250, 190);
			this.cmdOKCancel.Name = "cmdOKCancel";
			this.cmdOKCancel.OkCaption = "&Ok";
			this.cmdOKCancel.Size = new System.Drawing.Size(205, 29);
			this.cmdOKCancel.TabIndex = 7;
			//this.cmdOKCancel.CancelClick += new UCOkCancel.CancelClickHandler(this.cmdOKCancel_CancelClick);
			//this.cmdOKCancel.OKClick += new UCOkCancel.OKClickHandler(this.cmdOKCancel_OKClick);
			// 
			// cntMainParameter
			// 
			this.cntMainParameter.AllowDrop = true;
			this.cntMainParameter.Controls.Add(this.lblVoucherRange);
			this.cntMainParameter.Controls.Add(this.fraVoucherRange);
			this.cntMainParameter.Controls.Add(this.txtLocationCode);
			this.cntMainParameter.Controls.Add(this.lblLocationCode);
			this.cntMainParameter.Controls.Add(this.lblDateRange);
			this.cntMainParameter.Controls.Add(this.fraDateRange);
			this.cntMainParameter.Controls.Add(this.lblMasterCode);
			this.cntMainParameter.Controls.Add(this.txtMasterCode);
			this.cntMainParameter.Controls.Add(this.txtLocationName);
			this.cntMainParameter.Controls.Add(this.txtMasterName);
			this.cntMainParameter.Location = new System.Drawing.Point(5, 9);
			this.cntMainParameter.Name = "cntMainParameter";
			//
			this.cntMainParameter.Size = new System.Drawing.Size(457, 169);
			this.cntMainParameter.TabIndex = 25;
			// 
			// lblVoucherRange
			// 
			this.lblVoucherRange.AllowDrop = true;
			this.lblVoucherRange.BackColor = System.Drawing.SystemColors.Window;
			this.lblVoucherRange.Text = " Voucher Range ";
			this.lblVoucherRange.ForeColor = System.Drawing.Color.Black;
			this.lblVoucherRange.Location = new System.Drawing.Point(244, 76);
			this.lblVoucherRange.Name = "lblVoucherRange";
			this.lblVoucherRange.Size = new System.Drawing.Size(79, 13);
			this.lblVoucherRange.TabIndex = 33;
			this.lblVoucherRange.Visible = false;
			// 
			// fraVoucherRange
			// 
			this.fraVoucherRange.AllowDrop = true;
			this.fraVoucherRange.BackColor = System.Drawing.Color.FromArgb(240, 240, 236);
			this.fraVoucherRange.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.fraVoucherRange.Controls.Add(this.txtToVoucherNo);
			this.fraVoucherRange.Controls.Add(this.lblToVoucherNo);
			this.fraVoucherRange.Controls.Add(this.txtFromVoucherNo);
			this.fraVoucherRange.Controls.Add(this.lblFromVoucherNo);
			this.fraVoucherRange.Enabled = true;
			this.fraVoucherRange.ForeColor = System.Drawing.SystemColors.ControlText;
			this.fraVoucherRange.Location = new System.Drawing.Point(234, 86);
			this.fraVoucherRange.Name = "fraVoucherRange";
			this.fraVoucherRange.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.fraVoucherRange.Size = new System.Drawing.Size(207, 71);
			this.fraVoucherRange.TabIndex = 24;
			this.fraVoucherRange.Text = "Frame1";
			this.fraVoucherRange.Visible = false;
			// 
			// txtToVoucherNo
			// 
			this.txtToVoucherNo.AllowDrop = true;
			this.txtToVoucherNo.BackColor = System.Drawing.Color.White;
			// this.txtToVoucherNo.bolNumericOnly = true;
			this.txtToVoucherNo.ForeColor = System.Drawing.Color.Black;
			this.txtToVoucherNo.Location = new System.Drawing.Point(108, 43);
			this.txtToVoucherNo.MaxLength = 12;
			// this.txtToVoucherNo.mDropDownType = (System.Windows.Forms.TextBox.DropDownTypes) 0;
			this.txtToVoucherNo.Name = "txtToVoucherNo";
			this.txtToVoucherNo.Size = new System.Drawing.Size(88, 19);
			this.txtToVoucherNo.TabIndex = 5;
			this.txtToVoucherNo.Text = "";
			// this.this.txtToVoucherNo.Watermark = "";
			// this.txtToVoucherNo.Leave += new System.EventHandler(this.txtToVoucherNo_Leave);
			// 
			// lblToVoucherNo
			// 
			this.lblToVoucherNo.AllowDrop = true;
			this.lblToVoucherNo.BackColor = System.Drawing.SystemColors.Window;
			this.lblToVoucherNo.Text = "To Voucher No";
			this.lblToVoucherNo.ForeColor = System.Drawing.Color.Black;
			this.lblToVoucherNo.Location = new System.Drawing.Point(12, 46);
			this.lblToVoucherNo.Name = "lblToVoucherNo";
			this.lblToVoucherNo.Size = new System.Drawing.Size(70, 13);
			this.lblToVoucherNo.TabIndex = 31;
			// 
			// txtFromVoucherNo
			// 
			this.txtFromVoucherNo.AllowDrop = true;
			this.txtFromVoucherNo.BackColor = System.Drawing.Color.White;
			// this.txtFromVoucherNo.bolNumericOnly = true;
			this.txtFromVoucherNo.ForeColor = System.Drawing.Color.Black;
			this.txtFromVoucherNo.Location = new System.Drawing.Point(108, 22);
			this.txtFromVoucherNo.MaxLength = 12;
			// this.txtFromVoucherNo.mDropDownType = (System.Windows.Forms.TextBox.DropDownTypes) 0;
			this.txtFromVoucherNo.Name = "txtFromVoucherNo";
			this.txtFromVoucherNo.Size = new System.Drawing.Size(88, 19);
			this.txtFromVoucherNo.TabIndex = 4;
			this.txtFromVoucherNo.Text = "";
			// this.this.txtFromVoucherNo.Watermark = "";
			// this.txtFromVoucherNo.Leave += new System.EventHandler(this.txtFromVoucherNo_Leave);
			// 
			// lblFromVoucherNo
			// 
			this.lblFromVoucherNo.AllowDrop = true;
			this.lblFromVoucherNo.BackColor = System.Drawing.SystemColors.Window;
			this.lblFromVoucherNo.Text = "From Voucher No";
			this.lblFromVoucherNo.ForeColor = System.Drawing.Color.Black;
			this.lblFromVoucherNo.Location = new System.Drawing.Point(12, 25);
			this.lblFromVoucherNo.Name = "lblFromVoucherNo";
			this.lblFromVoucherNo.Size = new System.Drawing.Size(82, 13);
			this.lblFromVoucherNo.TabIndex = 32;
			// 
			// txtLocationCode
			// 
			this.txtLocationCode.AllowDrop = true;
			this.txtLocationCode.BackColor = System.Drawing.Color.White;
			this.txtLocationCode.ForeColor = System.Drawing.Color.Black;
			this.txtLocationCode.Location = new System.Drawing.Point(107, 43);
			this.txtLocationCode.Name = "txtLocationCode";
			// this.txtLocationCode.ShowButton = true;
			this.txtLocationCode.Size = new System.Drawing.Size(101, 19);
			this.txtLocationCode.TabIndex = 1;
			this.txtLocationCode.Text = "";
			this.txtLocationCode.Visible = false;
			// this.this.txtLocationCode.Watermark = "";
			// this.this.txtLocationCode.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtLocationCode_DropButtonClick);
			// this.txtLocationCode.Leave += new System.EventHandler(this.txtLocationCode_Leave);
			// 
			// lblLocationCode
			// 
			this.lblLocationCode.AllowDrop = true;
			this.lblLocationCode.BackColor = System.Drawing.SystemColors.Window;
			this.lblLocationCode.Text = "Location Code";
			this.lblLocationCode.ForeColor = System.Drawing.Color.Black;
			this.lblLocationCode.Location = new System.Drawing.Point(9, 46);
			this.lblLocationCode.Name = "lblLocationCode";
			this.lblLocationCode.Size = new System.Drawing.Size(68, 13);
			this.lblLocationCode.TabIndex = 30;
			this.lblLocationCode.Visible = false;
			// 
			// lblDateRange
			// 
			this.lblDateRange.AllowDrop = true;
			this.lblDateRange.BackColor = System.Drawing.SystemColors.Window;
			this.lblDateRange.Text = " Date Range ";
			this.lblDateRange.ForeColor = System.Drawing.Color.Black;
			this.lblDateRange.Location = new System.Drawing.Point(18, 78);
			this.lblDateRange.Name = "lblDateRange";
			this.lblDateRange.Size = new System.Drawing.Size(63, 13);
			this.lblDateRange.TabIndex = 29;
			// 
			// fraDateRange
			// 
			this.fraDateRange.AllowDrop = true;
			this.fraDateRange.BackColor = System.Drawing.Color.FromArgb(240, 240, 236);
			this.fraDateRange.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.fraDateRange.Controls.Add(this.lblToDate);
			this.fraDateRange.Controls.Add(this.lblFromDate);
			this.fraDateRange.Controls.Add(this.txtFromDate);
			this.fraDateRange.Controls.Add(this.txtToDate);
			this.fraDateRange.Enabled = true;
			this.fraDateRange.ForeColor = System.Drawing.SystemColors.WindowText;
			this.fraDateRange.Location = new System.Drawing.Point(9, 86);
			this.fraDateRange.Name = "fraDateRange";
			this.fraDateRange.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.fraDateRange.Size = new System.Drawing.Size(207, 71);
			this.fraDateRange.TabIndex = 23;
			this.fraDateRange.Visible = true;
			// 
			// lblToDate
			// 
			this.lblToDate.AllowDrop = true;
			this.lblToDate.BackColor = System.Drawing.SystemColors.Window;
			// this.lblToDate.Text = "To Date";
			this.lblToDate.ForeColor = System.Drawing.Color.Black;
			this.lblToDate.Location = new System.Drawing.Point(12, 46);
			this.lblToDate.Name = "lblToDate";
			this.lblToDate.Size = new System.Drawing.Size(38, 13);
			this.lblToDate.TabIndex = 27;
			// 
			// lblFromDate
			// 
			this.lblFromDate.AllowDrop = true;
			this.lblFromDate.BackColor = System.Drawing.SystemColors.Window;
			// this.lblFromDate.Text = "From Date";
			this.lblFromDate.ForeColor = System.Drawing.Color.Black;
			this.lblFromDate.Location = new System.Drawing.Point(12, 25);
			this.lblFromDate.Name = "lblFromDate";
			this.lblFromDate.Size = new System.Drawing.Size(50, 13);
			this.lblFromDate.TabIndex = 28;
			// 
			// txtFromDate
			// 
			this.txtFromDate.AllowDrop = true;
			// this.txtFromDate.CheckDateRange = false;
			this.txtFromDate.Location = new System.Drawing.Point(94, 22);
			// this.txtFromDate.MaxDate = 2958465;
			// this.txtFromDate.MinDate = 2;
			this.txtFromDate.Name = "txtFromDate";
			this.txtFromDate.Size = new System.Drawing.Size(101, 19);
			this.txtFromDate.TabIndex = 2;
			// this.txtFromDate.Text = "18/07/2001";
			// this.txtFromDate.Value = 37090;
			this.txtFromDate.Validating += new System.ComponentModel.CancelEventHandler(this.txtFromDate_Validating);
			// 
			// txtToDate
			// 
			this.txtToDate.AllowDrop = true;
			// this.txtToDate.CheckDateRange = false;
			this.txtToDate.Location = new System.Drawing.Point(94, 43);
			// this.txtToDate.MaxDate = 2958465;
			// this.txtToDate.MinDate = 2;
			this.txtToDate.Name = "txtToDate";
			this.txtToDate.Size = new System.Drawing.Size(101, 19);
			this.txtToDate.TabIndex = 3;
			// this.txtToDate.Text = "18/07/2001";
			// this.txtToDate.Value = 37090;
			this.txtToDate.Validating += new System.ComponentModel.CancelEventHandler(this.txtToDate_Validating);
			// 
			// lblMasterCode
			// 
			this.lblMasterCode.AllowDrop = true;
			this.lblMasterCode.BackColor = System.Drawing.SystemColors.Window;
			this.lblMasterCode.Text = "Master Code";
			this.lblMasterCode.ForeColor = System.Drawing.Color.Black;
			this.lblMasterCode.Location = new System.Drawing.Point(9, 24);
			this.lblMasterCode.Name = "lblMasterCode";
			this.lblMasterCode.Size = new System.Drawing.Size(61, 14);
			this.lblMasterCode.TabIndex = 26;
			// 
			// txtMasterCode
			// 
			this.txtMasterCode.AllowDrop = true;
			this.txtMasterCode.BackColor = System.Drawing.Color.White;
			this.txtMasterCode.ForeColor = System.Drawing.Color.Black;
			this.txtMasterCode.Location = new System.Drawing.Point(107, 22);
			this.txtMasterCode.Name = "txtMasterCode";
			// this.txtMasterCode.ShowButton = true;
			this.txtMasterCode.Size = new System.Drawing.Size(101, 19);
			this.txtMasterCode.TabIndex = 0;
			this.txtMasterCode.Text = "";
			// this.this.txtMasterCode.Watermark = "";
			// this.this.txtMasterCode.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtMasterCode_DropButtonClick);
			// this.txtMasterCode.Leave += new System.EventHandler(this.txtMasterCode_Leave);
			// 
			// txtLocationName
			// 
			this.txtLocationName.AllowDrop = true;
			this.txtLocationName.Enabled = false;
			this.txtLocationName.Location = new System.Drawing.Point(210, 43);
			this.txtLocationName.Name = "txtLocationName";
			this.txtLocationName.Size = new System.Drawing.Size(201, 19);
			this.txtLocationName.TabIndex = 34;
			this.txtLocationName.Visible = false;
			// 
			// txtMasterName
			// 
			this.txtMasterName.AllowDrop = true;
			this.txtMasterName.Enabled = false;
			this.txtMasterName.Location = new System.Drawing.Point(210, 22);
			this.txtMasterName.Name = "txtMasterName";
			this.txtMasterName.Size = new System.Drawing.Size(201, 19);
			this.txtMasterName.TabIndex = 35;
			// 
			// _lblCommon_6
			// 
			this._lblCommon_6.AllowDrop = true;
			this._lblCommon_6.BackColor = System.Drawing.SystemColors.Window;
			this._lblCommon_6.Text = " Additional Parameters ";
			this._lblCommon_6.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_6.Location = new System.Drawing.Point(1, 234);
			this._lblCommon_6.Name = "_lblCommon_6";
			this._lblCommon_6.Size = new System.Drawing.Size(111, 13);
			this._lblCommon_6.TabIndex = 36;
			// 
			// cmdPostMode
			// 
			this.cmdPostMode.AllowDrop = true;
			this.cmdPostMode.DisplayButton = 1;
			this.cmdPostMode.Location = new System.Drawing.Point(5, 190);
			this.cmdPostMode.Name = "cmdPostMode";
			this.cmdPostMode.OkCaption = "&Advanced Mode >>";
			this.cmdPostMode.Size = new System.Drawing.Size(205, 29);
			this.cmdPostMode.TabIndex = 6;
			this.cmdPostMode.OKClick += new UCOkCancel.OKClickHandler(this.cmdPostMode_OKClick);
			// 
			// Line1
			// 
			this.Line1.AllowDrop = true;
			this.Line1.BackColor = System.Drawing.SystemColors.WindowText;
			this.Line1.Enabled = false;
			this.Line1.Location = new System.Drawing.Point(110, 242);
			this.Line1.Name = "Line1";
			this.Line1.Size = new System.Drawing.Size(356, 1);
			this.Line1.Visible = true;
			// 
			// repParametersWindow
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(176, 178, 156);
			this.ClientSize = new System.Drawing.Size(464, 471);
			this.ControlBox = false;
			this.Controls.Add(this.fraOptions);
			this.Controls.Add(this.cmdOKCancel);
			this.Controls.Add(this.cntMainParameter);
			this.Controls.Add(this._lblCommon_6);
			this.Controls.Add(this.cmdPostMode);
			this.Controls.Add(this.Line1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			//this.Icon = (System.Drawing.Icon) resources.GetObject("repParametersWindow.Icon");
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(419, 246);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "repParametersWindow";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.ShowInTaskbar = false;
			this.Text = "Parameter Report Name";
			// this.Activated += new System.EventHandler(this.repParametersWindow_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
			// this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
			//((System.ComponentModel.ISupportInitialize) this.cntMainParameter).EndInit();
			this.fraOptions.ResumeLayout(false);
			this.cntMainParameter.ResumeLayout(false);
			this.fraVoucherRange.ResumeLayout(false);
			this.fraDateRange.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		// 
		void InitializelblCommon()
		{
			this.lblCommon = new System.Windows.Forms.Label[7];
			this.lblCommon[6] = _lblCommon_6;
		}
		#endregion
	}
}//ENDSHERE
