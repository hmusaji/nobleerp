
namespace Xtreme
{
	partial class frmGLAnalysisCode
	{

		#region "Upgrade Support "
		private static frmGLAnalysisCode m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmGLAnalysisCode DefInstance
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
		public static frmGLAnalysisCode CreateInstance()
		{
			frmGLAnalysisCode theInstance = new frmGLAnalysisCode();
			
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
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "comAnalysisHeadNo", "_txtCommon_0", "_lblDisplayLabel_2", "_txtCommon_1", "_lblDisplayLabel_3", "_txtCommon_2", "_lblDisplayLabel_1", "_lblDisplayLabel_0", "_fraLedgerInformation_2", "_cmbPriceLevel_5", "_cmbPriceLevel_4", "_txtCommonNumber_3", "_txtCommonNumber_1", "_txtCommonNumber_0", "_cmbPriceLevel_3", "_cmbPriceLevel_2", "_cmbPriceLevel_1", "_cmbPriceLevel_0", "_lblCommon_18", "_lblCommon_22", "_lblCommon_25", "_lblCommon_26", "_fraLedgerInformation_3", "_lblCommon_36", "_txtCommon_20", "_lblCommon_37", "_txtCommon_21", "_lblCommon_38", "_txtCommon_22", "_txtCommonLable_6", "_txtCommonLable_5", "_txtCommonLable_4", "_fraLedgerInformation_4", "chkFreeze", "txtComment", "_lblCommon_6", "_lblCommon_8", "_lblCommon_10", "System.Windows.Forms.Label2", "System.Windows.Forms.Label1", "txtEstimatedIncome", "txtExtimatedExp", "txtEndDate", "txtStartDate", "_lblDisplayLabel_4", "_txtCommon_3", "_lblDisplayLabel_5", "_txtCommon_4", "_fraLedgerInformation_0", "txtSupervisorName", "_lblCommon_14", "_lblCommon_17", "_fraLedgerInformation_1", "tabMaster", "cmbPriceLevel", "fraLedgerInformation", "lblCommon", "lblDisplayLabel", "txtCommon", "txtCommonLable", "txtCommonNumber"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public System.Windows.Forms.ComboBox comAnalysisHeadNo;
		private System.Windows.Forms.TextBox _txtCommon_0;
		private System.Windows.Forms.Label _lblDisplayLabel_2;
		private System.Windows.Forms.TextBox _txtCommon_1;
		private System.Windows.Forms.Label _lblDisplayLabel_3;
		private System.Windows.Forms.TextBox _txtCommon_2;
		private System.Windows.Forms.Label _lblDisplayLabel_1;
		private System.Windows.Forms.Label _lblDisplayLabel_0;
		private System.Windows.Forms.Panel _fraLedgerInformation_2;
		private System.Windows.Forms.ComboBox _cmbPriceLevel_5;
		private System.Windows.Forms.ComboBox _cmbPriceLevel_4;
		private System.Windows.Forms.TextBox _txtCommonNumber_3;
		private System.Windows.Forms.TextBox _txtCommonNumber_1;
		private System.Windows.Forms.TextBox _txtCommonNumber_0;
		private System.Windows.Forms.ComboBox _cmbPriceLevel_3;
		private System.Windows.Forms.ComboBox _cmbPriceLevel_2;
		private System.Windows.Forms.ComboBox _cmbPriceLevel_1;
		private System.Windows.Forms.ComboBox _cmbPriceLevel_0;
		private System.Windows.Forms.Label _lblCommon_18;
		private System.Windows.Forms.Label _lblCommon_22;
		private System.Windows.Forms.Label _lblCommon_25;
		private System.Windows.Forms.Label _lblCommon_26;
		private System.Windows.Forms.Panel _fraLedgerInformation_3;
		private System.Windows.Forms.Label _lblCommon_36;
		private System.Windows.Forms.TextBox _txtCommon_20;
		private System.Windows.Forms.Label _lblCommon_37;
		private System.Windows.Forms.TextBox _txtCommon_21;
		private System.Windows.Forms.Label _lblCommon_38;
		private System.Windows.Forms.TextBox _txtCommon_22;
		private System.Windows.Forms.Label _txtCommonLable_6;
		private System.Windows.Forms.Label _txtCommonLable_5;
		private System.Windows.Forms.Label _txtCommonLable_4;
		private System.Windows.Forms.Panel _fraLedgerInformation_4;
		public System.Windows.Forms.CheckBox chkFreeze;
		public System.Windows.Forms.TextBox txtComment;
		private System.Windows.Forms.Label _lblCommon_6;
		private System.Windows.Forms.Label _lblCommon_8;
		private System.Windows.Forms.Label _lblCommon_10;
		public System.Windows.Forms.Label Label2;
		public System.Windows.Forms.Label Label1;
		public System.Windows.Forms.TextBox txtEstimatedIncome;
		public System.Windows.Forms.TextBox txtExtimatedExp;
		public Syncfusion.WinForms.Input.SfDateTimeEdit txtEndDate;
		public Syncfusion.WinForms.Input.SfDateTimeEdit txtStartDate;
		private System.Windows.Forms.Label _lblDisplayLabel_4;
		private System.Windows.Forms.TextBox _txtCommon_3;
		private System.Windows.Forms.Label _lblDisplayLabel_5;
		private System.Windows.Forms.TextBox _txtCommon_4;
		private System.Windows.Forms.Panel _fraLedgerInformation_0;
		public System.Windows.Forms.TextBox txtSupervisorName;
		private System.Windows.Forms.Label _lblCommon_14;
		private System.Windows.Forms.Label _lblCommon_17;
		private System.Windows.Forms.Panel _fraLedgerInformation_1;
		public AxC1SizerLib.AxC1Tab tabMaster;
		public System.Windows.Forms.ComboBox[] cmbPriceLevel = new System.Windows.Forms.ComboBox[6];
		public System.Windows.Forms.Panel[] fraLedgerInformation = new System.Windows.Forms.Panel[5];
		public System.Windows.Forms.Label[] lblCommon = new System.Windows.Forms.Label[39];
		public System.Windows.Forms.Label[] lblDisplayLabel = new System.Windows.Forms.Label[6];
		public System.Windows.Forms.TextBox[] txtCommon = new System.Windows.Forms.TextBox[23];
		public System.Windows.Forms.Label[] txtCommonLable = new System.Windows.Forms.Label[7];
		public System.Windows.Forms.TextBox[] txtCommonNumber = new System.Windows.Forms.TextBox[4];
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGLAnalysisCode));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this.comAnalysisHeadNo = new System.Windows.Forms.ComboBox();
			this._txtCommon_0 = new System.Windows.Forms.TextBox();
			this._lblDisplayLabel_2 = new System.Windows.Forms.Label();
			this._txtCommon_1 = new System.Windows.Forms.TextBox();
			this._lblDisplayLabel_3 = new System.Windows.Forms.Label();
			this._txtCommon_2 = new System.Windows.Forms.TextBox();
			this._lblDisplayLabel_1 = new System.Windows.Forms.Label();
			this._lblDisplayLabel_0 = new System.Windows.Forms.Label();
			this.tabMaster = new AxC1SizerLib.AxC1Tab();
			this._fraLedgerInformation_3 = new System.Windows.Forms.Panel();
			this._fraLedgerInformation_2 = new System.Windows.Forms.Panel();
			this._cmbPriceLevel_5 = new System.Windows.Forms.ComboBox();
			this._cmbPriceLevel_4 = new System.Windows.Forms.ComboBox();
			this._txtCommonNumber_3 = new System.Windows.Forms.TextBox();
			this._txtCommonNumber_1 = new System.Windows.Forms.TextBox();
			this._txtCommonNumber_0 = new System.Windows.Forms.TextBox();
			this._cmbPriceLevel_3 = new System.Windows.Forms.ComboBox();
			this._cmbPriceLevel_2 = new System.Windows.Forms.ComboBox();
			this._cmbPriceLevel_1 = new System.Windows.Forms.ComboBox();
			this._cmbPriceLevel_0 = new System.Windows.Forms.ComboBox();
			this._lblCommon_18 = new System.Windows.Forms.Label();
			this._lblCommon_22 = new System.Windows.Forms.Label();
			this._lblCommon_25 = new System.Windows.Forms.Label();
			this._lblCommon_26 = new System.Windows.Forms.Label();
			this._fraLedgerInformation_4 = new System.Windows.Forms.Panel();
			this._lblCommon_36 = new System.Windows.Forms.Label();
			this._txtCommon_20 = new System.Windows.Forms.TextBox();
			this._lblCommon_37 = new System.Windows.Forms.Label();
			this._txtCommon_21 = new System.Windows.Forms.TextBox();
			this._lblCommon_38 = new System.Windows.Forms.Label();
			this._txtCommon_22 = new System.Windows.Forms.TextBox();
			this._txtCommonLable_6 = new System.Windows.Forms.Label();
			this._txtCommonLable_5 = new System.Windows.Forms.Label();
			this._txtCommonLable_4 = new System.Windows.Forms.Label();
			this._fraLedgerInformation_0 = new System.Windows.Forms.Panel();
			this.chkFreeze = new System.Windows.Forms.CheckBox();
			this.txtComment = new System.Windows.Forms.TextBox();
			this._lblCommon_6 = new System.Windows.Forms.Label();
			this._lblCommon_8 = new System.Windows.Forms.Label();
			this._lblCommon_10 = new System.Windows.Forms.Label();
			this.Label2 = new System.Windows.Forms.Label();
			this.Label1 = new System.Windows.Forms.Label();
			this.txtEstimatedIncome = new System.Windows.Forms.TextBox();
			this.txtExtimatedExp = new System.Windows.Forms.TextBox();
			this.txtEndDate = new Syncfusion.WinForms.Input.SfDateTimeEdit();
			this.txtStartDate = new Syncfusion.WinForms.Input.SfDateTimeEdit();
			this._lblDisplayLabel_4 = new System.Windows.Forms.Label();
			this._txtCommon_3 = new System.Windows.Forms.TextBox();
			this._lblDisplayLabel_5 = new System.Windows.Forms.Label();
			this._txtCommon_4 = new System.Windows.Forms.TextBox();
			this._fraLedgerInformation_1 = new System.Windows.Forms.Panel();
			this.txtSupervisorName = new System.Windows.Forms.TextBox();
			this._lblCommon_14 = new System.Windows.Forms.Label();
			this._lblCommon_17 = new System.Windows.Forms.Label();
			// //((System.ComponentModel.ISupportInitialize) this.tabMaster).BeginInit();
			this.tabMaster.SuspendLayout();
			this._fraLedgerInformation_3.SuspendLayout();
			this._fraLedgerInformation_4.SuspendLayout();
			this._fraLedgerInformation_0.SuspendLayout();
			this._fraLedgerInformation_1.SuspendLayout();
			this.SuspendLayout();
			// 
			// comAnalysisHeadNo
			// 
			this.comAnalysisHeadNo.AllowDrop = true;
			this.comAnalysisHeadNo.Location = new System.Drawing.Point(126, 18);
			this.comAnalysisHeadNo.Name = "comAnalysisHeadNo";
			this.comAnalysisHeadNo.Size = new System.Drawing.Size(101, 21);
			this.comAnalysisHeadNo.TabIndex = 7;
			// 
			// _txtCommon_0
			// 
			this._txtCommon_0.AllowDrop = true;
			this._txtCommon_0.BackColor = System.Drawing.Color.White;
			this._txtCommon_0.ForeColor = System.Drawing.Color.Black;
			this._txtCommon_0.Location = new System.Drawing.Point(126, 45);
			this._txtCommon_0.MaxLength = 15;
			// this._txtCommon_0.mDropDownType = System.Windows.Forms.TextBox.DropDownTypes.ddtNextNumber;
			this._txtCommon_0.Name = "_txtCommon_0";
			// this._txtCommon_0.ShowButton = true;
			this._txtCommon_0.Size = new System.Drawing.Size(101, 19);
			this._txtCommon_0.TabIndex = 0;
			this._txtCommon_0.Text = "";
			// this.this._txtCommon_0.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommon_DropButtonClick);
			// 
			// _lblDisplayLabel_2
			// 
			this._lblDisplayLabel_2.AllowDrop = true;
			this._lblDisplayLabel_2.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblDisplayLabel_2.Text = "Name (English)";
			this._lblDisplayLabel_2.ForeColor = System.Drawing.Color.Black;
			this._lblDisplayLabel_2.Location = new System.Drawing.Point(285, 24);
			this._lblDisplayLabel_2.Name = "_lblDisplayLabel_2";
			this._lblDisplayLabel_2.Size = new System.Drawing.Size(72, 14);
			this._lblDisplayLabel_2.TabIndex = 1;
			// 
			// _txtCommon_1
			// 
			this._txtCommon_1.AllowDrop = true;
			this._txtCommon_1.BackColor = System.Drawing.Color.White;
			this._txtCommon_1.ForeColor = System.Drawing.Color.Black;
			this._txtCommon_1.Location = new System.Drawing.Point(374, 22);
			this._txtCommon_1.MaxLength = 240;
			this._txtCommon_1.Name = "_txtCommon_1";
			this._txtCommon_1.Size = new System.Drawing.Size(261, 19);
			this._txtCommon_1.TabIndex = 2;
			this._txtCommon_1.Text = "";
			// this.this._txtCommon_1.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommon_DropButtonClick);
			// 
			// _lblDisplayLabel_3
			// 
			this._lblDisplayLabel_3.AllowDrop = true;
			this._lblDisplayLabel_3.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblDisplayLabel_3.Text = "Name (Arabic)";
			this._lblDisplayLabel_3.ForeColor = System.Drawing.Color.Black;
			this._lblDisplayLabel_3.Location = new System.Drawing.Point(285, 49);
			this._lblDisplayLabel_3.Name = "_lblDisplayLabel_3";
			this._lblDisplayLabel_3.Size = new System.Drawing.Size(70, 14);
			this._lblDisplayLabel_3.TabIndex = 3;
			// 
			// _txtCommon_2
			// 
			this._txtCommon_2.AllowDrop = true;
			this._txtCommon_2.BackColor = System.Drawing.Color.White;
			this._txtCommon_2.ForeColor = System.Drawing.Color.Black;
			this._txtCommon_2.Location = new System.Drawing.Point(374, 47);
			// this._txtCommon_2.mArabicEnabled = true;
			this._txtCommon_2.MaxLength = 240;
			this._txtCommon_2.Name = "_txtCommon_2";
			this._txtCommon_2.Size = new System.Drawing.Size(261, 19);
			this._txtCommon_2.TabIndex = 4;
			this._txtCommon_2.Text = "";
			// this.this._txtCommon_2.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommon_DropButtonClick);
			// 
			// _lblDisplayLabel_1
			// 
			this._lblDisplayLabel_1.AllowDrop = true;
			this._lblDisplayLabel_1.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblDisplayLabel_1.Text = "Job Code";
			this._lblDisplayLabel_1.ForeColor = System.Drawing.Color.Black;
			this._lblDisplayLabel_1.Location = new System.Drawing.Point(17, 47);
			this._lblDisplayLabel_1.Name = "_lblDisplayLabel_1";
			this._lblDisplayLabel_1.Size = new System.Drawing.Size(45, 14);
			this._lblDisplayLabel_1.TabIndex = 5;
			// 
			// _lblDisplayLabel_0
			// 
			this._lblDisplayLabel_0.AllowDrop = true;
			this._lblDisplayLabel_0.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblDisplayLabel_0.Text = "Job Head.";
			this._lblDisplayLabel_0.ForeColor = System.Drawing.Color.Black;
			this._lblDisplayLabel_0.Location = new System.Drawing.Point(17, 22);
			this._lblDisplayLabel_0.Name = "_lblDisplayLabel_0";
			this._lblDisplayLabel_0.Size = new System.Drawing.Size(48, 14);
			this._lblDisplayLabel_0.TabIndex = 6;
			// 
			// tabMaster
			// 
			this.tabMaster.Align = C1SizerLib.AlignSettings.asNone;
			this.tabMaster.AllowDrop = true;
			this.tabMaster.Controls.Add(this._fraLedgerInformation_3);
			this.tabMaster.Controls.Add(this._fraLedgerInformation_4);
			this.tabMaster.Controls.Add(this._fraLedgerInformation_0);
			this.tabMaster.Controls.Add(this._fraLedgerInformation_1);
			this.tabMaster.Location = new System.Drawing.Point(0, 80);
			this.tabMaster.Name = "tabMaster";
			("tabMaster.OcxState");
			this.tabMaster.Size = new System.Drawing.Size(637, 201);
			this.tabMaster.TabIndex = 8;
			this.tabMaster.TabStop = false;
			// 
			// _fraLedgerInformation_3
			// 
			this._fraLedgerInformation_3.AllowDrop = true;
			this._fraLedgerInformation_3.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._fraLedgerInformation_3.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._fraLedgerInformation_3.Controls.Add(this._fraLedgerInformation_2);
			this._fraLedgerInformation_3.Controls.Add(this._cmbPriceLevel_5);
			this._fraLedgerInformation_3.Controls.Add(this._cmbPriceLevel_4);
			this._fraLedgerInformation_3.Controls.Add(this._txtCommonNumber_3);
			this._fraLedgerInformation_3.Controls.Add(this._txtCommonNumber_1);
			this._fraLedgerInformation_3.Controls.Add(this._txtCommonNumber_0);
			this._fraLedgerInformation_3.Controls.Add(this._cmbPriceLevel_3);
			this._fraLedgerInformation_3.Controls.Add(this._cmbPriceLevel_2);
			this._fraLedgerInformation_3.Controls.Add(this._cmbPriceLevel_1);
			this._fraLedgerInformation_3.Controls.Add(this._cmbPriceLevel_0);
			this._fraLedgerInformation_3.Controls.Add(this._lblCommon_18);
			this._fraLedgerInformation_3.Controls.Add(this._lblCommon_22);
			this._fraLedgerInformation_3.Controls.Add(this._lblCommon_25);
			this._fraLedgerInformation_3.Controls.Add(this._lblCommon_26);
			this._fraLedgerInformation_3.Enabled = true;
			this._fraLedgerInformation_3.ForeColor = System.Drawing.SystemColors.WindowText;
			this._fraLedgerInformation_3.Location = new System.Drawing.Point(698, 23);
			this._fraLedgerInformation_3.Name = "_fraLedgerInformation_3";
			this._fraLedgerInformation_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._fraLedgerInformation_3.Size = new System.Drawing.Size(635, 177);
			this._fraLedgerInformation_3.TabIndex = 39;
			this._fraLedgerInformation_3.Text = "Frame2";
			this._fraLedgerInformation_3.Visible = true;
			// 
			// _fraLedgerInformation_2
			// 
			this._fraLedgerInformation_2.AllowDrop = true;
			this._fraLedgerInformation_2.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._fraLedgerInformation_2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._fraLedgerInformation_2.Enabled = true;
			this._fraLedgerInformation_2.ForeColor = System.Drawing.SystemColors.WindowText;
			this._fraLedgerInformation_2.Location = new System.Drawing.Point(-2, 2);
			this._fraLedgerInformation_2.Name = "_fraLedgerInformation_2";
			this._fraLedgerInformation_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._fraLedgerInformation_2.Size = new System.Drawing.Size(635, 177);
			this._fraLedgerInformation_2.TabIndex = 40;
			this._fraLedgerInformation_2.Visible = true;
			// 
			// _cmbPriceLevel_5
			// 
			this._cmbPriceLevel_5.AllowDrop = true;
			this._cmbPriceLevel_5.Location = new System.Drawing.Point(459, 88);
			this._cmbPriceLevel_5.Name = "_cmbPriceLevel_5";
			this._cmbPriceLevel_5.Size = new System.Drawing.Size(173, 21);
			this._cmbPriceLevel_5.TabIndex = 41;
			// 
			// _cmbPriceLevel_4
			// 
			this._cmbPriceLevel_4.AllowDrop = true;
			this._cmbPriceLevel_4.Location = new System.Drawing.Point(459, 69);
			this._cmbPriceLevel_4.Name = "_cmbPriceLevel_4";
			this._cmbPriceLevel_4.Size = new System.Drawing.Size(173, 21);
			this._cmbPriceLevel_4.TabIndex = 42;
			// 
			// _txtCommonNumber_3
			// 
			this._txtCommonNumber_3.AllowDrop = true;
			this._txtCommonNumber_3.Location = new System.Drawing.Point(459, 134);
			// this._txtCommonNumber_3.MaxValue = 2147483647;
			// this._txtCommonNumber_3.MinValue = 0;
			this._txtCommonNumber_3.Name = "_txtCommonNumber_3";
			this._txtCommonNumber_3.Size = new System.Drawing.Size(101, 19);
			this._txtCommonNumber_3.TabIndex = 43;
			// 
			// _txtCommonNumber_1
			// 
			this._txtCommonNumber_1.AllowDrop = true;
			this._txtCommonNumber_1.Location = new System.Drawing.Point(131, 134);
			// this._txtCommonNumber_1.MaxValue = 2147483647;
			// this._txtCommonNumber_1.MinValue = 0;
			this._txtCommonNumber_1.Name = "_txtCommonNumber_1";
			this._txtCommonNumber_1.Size = new System.Drawing.Size(101, 19);
			this._txtCommonNumber_1.TabIndex = 44;
			// 
			// _txtCommonNumber_0
			// 
			this._txtCommonNumber_0.AllowDrop = true;
			this._txtCommonNumber_0.Location = new System.Drawing.Point(131, 117);
			// this._txtCommonNumber_0.MaxValue = 2147483647;
			// this._txtCommonNumber_0.MinValue = 0;
			this._txtCommonNumber_0.Name = "_txtCommonNumber_0";
			this._txtCommonNumber_0.Size = new System.Drawing.Size(101, 19);
			this._txtCommonNumber_0.TabIndex = 45;
			// 
			// _cmbPriceLevel_3
			// 
			this._cmbPriceLevel_3.AllowDrop = true;
			this._cmbPriceLevel_3.Location = new System.Drawing.Point(131, 88);
			this._cmbPriceLevel_3.Name = "_cmbPriceLevel_3";
			this._cmbPriceLevel_3.Size = new System.Drawing.Size(173, 21);
			this._cmbPriceLevel_3.TabIndex = 46;
			// 
			// _cmbPriceLevel_2
			// 
			this._cmbPriceLevel_2.AllowDrop = true;
			this._cmbPriceLevel_2.Location = new System.Drawing.Point(131, 69);
			this._cmbPriceLevel_2.Name = "_cmbPriceLevel_2";
			this._cmbPriceLevel_2.Size = new System.Drawing.Size(173, 21);
			this._cmbPriceLevel_2.TabIndex = 47;
			// 
			// _cmbPriceLevel_1
			// 
			this._cmbPriceLevel_1.AllowDrop = true;
			this._cmbPriceLevel_1.Location = new System.Drawing.Point(459, 14);
			this._cmbPriceLevel_1.Name = "_cmbPriceLevel_1";
			this._cmbPriceLevel_1.Size = new System.Drawing.Size(173, 21);
			this._cmbPriceLevel_1.TabIndex = 48;
			// 
			// _cmbPriceLevel_0
			// 
			this._cmbPriceLevel_0.AllowDrop = true;
			this._cmbPriceLevel_0.Location = new System.Drawing.Point(131, 14);
			this._cmbPriceLevel_0.Name = "_cmbPriceLevel_0";
			this._cmbPriceLevel_0.Size = new System.Drawing.Size(173, 21);
			this._cmbPriceLevel_0.TabIndex = 49;
			// 
			// _lblCommon_18
			// 
			this._lblCommon_18.AllowDrop = true;
			this._lblCommon_18.BackColor = System.Drawing.SystemColors.Window;
			this._lblCommon_18.Text = "Default Sales Price";
			this._lblCommon_18.Location = new System.Drawing.Point(8, 18);
			this._lblCommon_18.Name = "_lblCommon_18";
			this._lblCommon_18.Size = new System.Drawing.Size(91, 14);
			this._lblCommon_18.TabIndex = 50;
			// 
			// _lblCommon_22
			// 
			this._lblCommon_22.AllowDrop = true;
			this._lblCommon_22.BackColor = System.Drawing.SystemColors.Window;
			this._lblCommon_22.Text = "Default Purchase Price";
			this._lblCommon_22.Location = new System.Drawing.Point(334, 17);
			this._lblCommon_22.Name = "_lblCommon_22";
			this._lblCommon_22.Size = new System.Drawing.Size(110, 14);
			this._lblCommon_22.TabIndex = 51;
			// 
			// _lblCommon_25
			// 
			this._lblCommon_25.AllowDrop = true;
			this._lblCommon_25.BackColor = System.Drawing.SystemColors.Window;
			this._lblCommon_25.Text = "Max Sales Price";
			this._lblCommon_25.Location = new System.Drawing.Point(14, 72);
			this._lblCommon_25.Name = "_lblCommon_25";
			this._lblCommon_25.Size = new System.Drawing.Size(77, 14);
			this._lblCommon_25.TabIndex = 52;
			// 
			// _lblCommon_26
			// 
			this._lblCommon_26.AllowDrop = true;
			this._lblCommon_26.BackColor = System.Drawing.SystemColors.Window;
			this._lblCommon_26.Text = "Min Sales Price";
			this._lblCommon_26.Location = new System.Drawing.Point(14, 91);
			this._lblCommon_26.Name = "_lblCommon_26";
			this._lblCommon_26.Size = new System.Drawing.Size(73, 14);
			this._lblCommon_26.TabIndex = 53;
			// 
			// _fraLedgerInformation_4
			// 
			this._fraLedgerInformation_4.AllowDrop = true;
			this._fraLedgerInformation_4.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._fraLedgerInformation_4.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._fraLedgerInformation_4.Controls.Add(this._lblCommon_36);
			this._fraLedgerInformation_4.Controls.Add(this._txtCommon_20);
			this._fraLedgerInformation_4.Controls.Add(this._lblCommon_37);
			this._fraLedgerInformation_4.Controls.Add(this._txtCommon_21);
			this._fraLedgerInformation_4.Controls.Add(this._lblCommon_38);
			this._fraLedgerInformation_4.Controls.Add(this._txtCommon_22);
			this._fraLedgerInformation_4.Controls.Add(this._txtCommonLable_6);
			this._fraLedgerInformation_4.Controls.Add(this._txtCommonLable_5);
			this._fraLedgerInformation_4.Controls.Add(this._txtCommonLable_4);
			this._fraLedgerInformation_4.Enabled = true;
			this._fraLedgerInformation_4.ForeColor = System.Drawing.SystemColors.ControlText;
			this._fraLedgerInformation_4.Location = new System.Drawing.Point(718, 23);
			this._fraLedgerInformation_4.Name = "_fraLedgerInformation_4";
			this._fraLedgerInformation_4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._fraLedgerInformation_4.Size = new System.Drawing.Size(635, 177);
			this._fraLedgerInformation_4.TabIndex = 24;
			this._fraLedgerInformation_4.Visible = true;
			// 
			// _lblCommon_36
			// 
			this._lblCommon_36.AllowDrop = true;
			this._lblCommon_36.BackColor = System.Drawing.SystemColors.Window;
			this._lblCommon_36.Text = "Default Salesman";
			this._lblCommon_36.Location = new System.Drawing.Point(8, 16);
			this._lblCommon_36.Name = "_lblCommon_36";
			this._lblCommon_36.Size = new System.Drawing.Size(84, 14);
			this._lblCommon_36.TabIndex = 25;
			// 
			// _txtCommon_20
			// 
			this._txtCommon_20.AllowDrop = true;
			this._txtCommon_20.BackColor = System.Drawing.Color.White;
			// this._txtCommon_20.bolNumericOnly = true;
			this._txtCommon_20.ForeColor = System.Drawing.Color.Black;
			this._txtCommon_20.Location = new System.Drawing.Point(126, 14);
			this._txtCommon_20.Name = "_txtCommon_20";
			// this._txtCommon_20.ShowButton = true;
			this._txtCommon_20.Size = new System.Drawing.Size(101, 19);
			this._txtCommon_20.TabIndex = 26;
			this._txtCommon_20.Text = "";
			// this.this._txtCommon_20.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommon_DropButtonClick);
			// 
			// _lblCommon_37
			// 
			this._lblCommon_37.AllowDrop = true;
			this._lblCommon_37.BackColor = System.Drawing.SystemColors.Window;
			this._lblCommon_37.Text = "Default Cost Center";
			this._lblCommon_37.Location = new System.Drawing.Point(8, 38);
			this._lblCommon_37.Name = "_lblCommon_37";
			this._lblCommon_37.Size = new System.Drawing.Size(94, 14);
			this._lblCommon_37.TabIndex = 27;
			// 
			// _txtCommon_21
			// 
			this._txtCommon_21.AllowDrop = true;
			this._txtCommon_21.BackColor = System.Drawing.Color.White;
			// this._txtCommon_21.bolNumericOnly = true;
			this._txtCommon_21.ForeColor = System.Drawing.Color.Black;
			this._txtCommon_21.Location = new System.Drawing.Point(126, 35);
			this._txtCommon_21.Name = "_txtCommon_21";
			// this._txtCommon_21.ShowButton = true;
			this._txtCommon_21.Size = new System.Drawing.Size(101, 19);
			this._txtCommon_21.TabIndex = 28;
			this._txtCommon_21.Text = "";
			// this.this._txtCommon_21.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommon_DropButtonClick);
			// 
			// _lblCommon_38
			// 
			this._lblCommon_38.AllowDrop = true;
			this._lblCommon_38.BackColor = System.Drawing.SystemColors.Window;
			this._lblCommon_38.Text = "Default Payment Mode";
			this._lblCommon_38.Location = new System.Drawing.Point(8, 59);
			this._lblCommon_38.Name = "_lblCommon_38";
			this._lblCommon_38.Size = new System.Drawing.Size(107, 14);
			this._lblCommon_38.TabIndex = 29;
			// 
			// _txtCommon_22
			// 
			this._txtCommon_22.AllowDrop = true;
			this._txtCommon_22.BackColor = System.Drawing.Color.White;
			// this._txtCommon_22.bolNumericOnly = true;
			this._txtCommon_22.ForeColor = System.Drawing.Color.Black;
			this._txtCommon_22.Location = new System.Drawing.Point(126, 56);
			this._txtCommon_22.Name = "_txtCommon_22";
			// this._txtCommon_22.ShowButton = true;
			this._txtCommon_22.Size = new System.Drawing.Size(101, 19);
			this._txtCommon_22.TabIndex = 30;
			this._txtCommon_22.Text = "";
			// this.this._txtCommon_22.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommon_DropButtonClick);
			// 
			// _txtCommonLable_6
			// 
			this._txtCommonLable_6.AllowDrop = true;
			this._txtCommonLable_6.Location = new System.Drawing.Point(229, 56);
			this._txtCommonLable_6.Name = "_txtCommonLable_6";
			this._txtCommonLable_6.Size = new System.Drawing.Size(201, 19);
			this._txtCommonLable_6.TabIndex = 31;
			// 
			// _txtCommonLable_5
			// 
			this._txtCommonLable_5.AllowDrop = true;
			this._txtCommonLable_5.Location = new System.Drawing.Point(229, 35);
			this._txtCommonLable_5.Name = "_txtCommonLable_5";
			this._txtCommonLable_5.Size = new System.Drawing.Size(201, 19);
			this._txtCommonLable_5.TabIndex = 32;
			// 
			// _txtCommonLable_4
			// 
			this._txtCommonLable_4.AllowDrop = true;
			this._txtCommonLable_4.Location = new System.Drawing.Point(229, 14);
			this._txtCommonLable_4.Name = "_txtCommonLable_4";
			this._txtCommonLable_4.Size = new System.Drawing.Size(201, 19);
			this._txtCommonLable_4.TabIndex = 33;
			// 
			// _fraLedgerInformation_0
			// 
			this._fraLedgerInformation_0.AllowDrop = true;
			this._fraLedgerInformation_0.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._fraLedgerInformation_0.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._fraLedgerInformation_0.Controls.Add(this.chkFreeze);
			this._fraLedgerInformation_0.Controls.Add(this.txtComment);
			this._fraLedgerInformation_0.Controls.Add(this._lblCommon_6);
			this._fraLedgerInformation_0.Controls.Add(this._lblCommon_8);
			this._fraLedgerInformation_0.Controls.Add(this._lblCommon_10);
			this._fraLedgerInformation_0.Controls.Add(this.Label2);
			this._fraLedgerInformation_0.Controls.Add(this.Label1);
			this._fraLedgerInformation_0.Controls.Add(this.txtEstimatedIncome);
			this._fraLedgerInformation_0.Controls.Add(this.txtExtimatedExp);
			this._fraLedgerInformation_0.Controls.Add(this.txtEndDate);
			this._fraLedgerInformation_0.Controls.Add(this.txtStartDate);
			this._fraLedgerInformation_0.Controls.Add(this._lblDisplayLabel_4);
			this._fraLedgerInformation_0.Controls.Add(this._txtCommon_3);
			this._fraLedgerInformation_0.Controls.Add(this._lblDisplayLabel_5);
			this._fraLedgerInformation_0.Controls.Add(this._txtCommon_4);
			this._fraLedgerInformation_0.Enabled = true;
			this._fraLedgerInformation_0.ForeColor = System.Drawing.SystemColors.WindowText;
			this._fraLedgerInformation_0.Location = new System.Drawing.Point(1, 23);
			this._fraLedgerInformation_0.Name = "_fraLedgerInformation_0";
			this._fraLedgerInformation_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._fraLedgerInformation_0.Size = new System.Drawing.Size(635, 177);
			this._fraLedgerInformation_0.TabIndex = 13;
			this._fraLedgerInformation_0.Visible = true;
			// 
			// chkFreeze
			// 
			this.chkFreeze.AllowDrop = true;
			this.chkFreeze.Appearance = System.Windows.Forms.Appearance.Normal;
			this.chkFreeze.BackColor = System.Drawing.SystemColors.Window;
			this.chkFreeze.CausesValidation = true;
			this.chkFreeze.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkFreeze.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this.chkFreeze.Enabled = true;
			this.chkFreeze.ForeColor = System.Drawing.Color.Navy;
			this.chkFreeze.Location = new System.Drawing.Point(434, 80);
			this.chkFreeze.Name = "chkFreeze";
			this.chkFreeze.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.chkFreeze.Size = new System.Drawing.Size(78, 13);
			this.chkFreeze.TabIndex = 38;
			this.chkFreeze.TabStop = true;
			this.chkFreeze.Text = "Freeze?";
			this.chkFreeze.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkFreeze.Visible = true;
			// 
			// txtComment
			// 
			this.txtComment.AcceptsReturn = true;
			this.txtComment.AllowDrop = true;
			this.txtComment.BackColor = System.Drawing.Color.White;
			this.txtComment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtComment.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtComment.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtComment.Location = new System.Drawing.Point(112, 109);
			this.txtComment.MaxLength = 100;
			this.txtComment.Multiline = true;
			this.txtComment.Name = "txtComment";
			this.txtComment.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtComment.Size = new System.Drawing.Size(514, 59);
			this.txtComment.TabIndex = 14;
			// 
			// _lblCommon_6
			// 
			this._lblCommon_6.AllowDrop = true;
			this._lblCommon_6.BackColor = System.Drawing.SystemColors.Window;
			this._lblCommon_6.Text = "Revenues";
			this._lblCommon_6.Location = new System.Drawing.Point(237, 79);
			this._lblCommon_6.Name = "_lblCommon_6";
			this._lblCommon_6.Size = new System.Drawing.Size(49, 14);
			this._lblCommon_6.TabIndex = 15;
			// 
			// _lblCommon_8
			// 
			this._lblCommon_8.AllowDrop = true;
			this._lblCommon_8.BackColor = System.Drawing.SystemColors.Window;
			this._lblCommon_8.Text = "Project Details";
			this._lblCommon_8.Location = new System.Drawing.Point(6, 109);
			this._lblCommon_8.Name = "_lblCommon_8";
			this._lblCommon_8.Size = new System.Drawing.Size(68, 14);
			this._lblCommon_8.TabIndex = 16;
			// 
			// _lblCommon_10
			// 
			this._lblCommon_10.AllowDrop = true;
			this._lblCommon_10.BackColor = System.Drawing.SystemColors.Window;
			this._lblCommon_10.Text = "Estimated Value";
			this._lblCommon_10.Location = new System.Drawing.Point(6, 79);
			this._lblCommon_10.Name = "_lblCommon_10";
			this._lblCommon_10.Size = new System.Drawing.Size(77, 14);
			this._lblCommon_10.TabIndex = 17;
			// 
			// System.Windows.Forms.Label2
			// 
			this.Label2.AllowDrop = true;
			this.Label2.BackColor = System.Drawing.SystemColors.Window;
			this.Label2.Text = "End Date";
			this.Label2.Location = new System.Drawing.Point(242, 59);
			this.Label2.Name = "System.Windows.Forms.Label2";
			this.Label2.Size = new System.Drawing.Size(44, 13);
			this.Label2.TabIndex = 18;
			// 
			// System.Windows.Forms.Label1
			// 
			this.Label1.AllowDrop = true;
			this.Label1.BackColor = System.Drawing.SystemColors.Window;
			this.Label1.Text = "Start Date";
			this.Label1.Location = new System.Drawing.Point(6, 59);
			this.Label1.Name = "System.Windows.Forms.Label1";
			this.Label1.Size = new System.Drawing.Size(50, 13);
			this.Label1.TabIndex = 19;
			// 
			// txtEstimatedIncome
			// 
			this.txtEstimatedIncome.AllowDrop = true;
			// this.txtEstimatedIncome.DisplayFormat = "########0.000###;;0.000;0.000";
			// this.txtEstimatedIncome.Format = "###########0.000";
			this.txtEstimatedIncome.Location = new System.Drawing.Point(301, 77);
			// this.txtEstimatedIncome.MaxValue = 2147483647;
			// this.txtEstimatedIncome.MinValue = 0;
			this.txtEstimatedIncome.Name = "txtEstimatedIncome";
			this.txtEstimatedIncome.Size = new System.Drawing.Size(101, 19);
			this.txtEstimatedIncome.TabIndex = 20;
			this.txtEstimatedIncome.Text = "0.000";
			// 
			// txtExtimatedExp
			// 
			this.txtExtimatedExp.AllowDrop = true;
			this.txtExtimatedExp.BackColor = System.Drawing.Color.White;
			// this.txtExtimatedExp.DisplayFormat = "########0.000###;;0.000;0.000";
			// this.txtExtimatedExp.Format = "###########0.000";
			this.txtExtimatedExp.Location = new System.Drawing.Point(112, 77);
			// this.txtExtimatedExp.MaxValue = 2147483647;
			// this.txtExtimatedExp.MinValue = 0;
			this.txtExtimatedExp.Name = "txtExtimatedExp";
			this.txtExtimatedExp.Size = new System.Drawing.Size(101, 19);
			this.txtExtimatedExp.TabIndex = 21;
			this.txtExtimatedExp.Text = "0.000";
			// 
			// txtEndDate
			// 
			this.txtEndDate.AllowDrop = true;
			// this.txtEndDate.CheckDateRange = false;
			this.txtEndDate.Location = new System.Drawing.Point(301, 56);
			// this.txtEndDate.MaxDate = 2958465;
			// this.txtEndDate.MinDate = 2;
			this.txtEndDate.Name = "txtEndDate";
			this.txtEndDate.Size = new System.Drawing.Size(101, 19);
			this.txtEndDate.TabIndex = 22;
			// this.txtEndDate.Text = "8/6/2003";
			// this.txtEndDate.Value = 37839;
			// 
			// txtStartDate
			// 
			this.txtStartDate.AllowDrop = true;
			// this.txtStartDate.CheckDateRange = false;
			this.txtStartDate.Location = new System.Drawing.Point(112, 56);
			// this.txtStartDate.MaxDate = 2958465;
			// this.txtStartDate.MinDate = 2;
			this.txtStartDate.Name = "txtStartDate";
			this.txtStartDate.Size = new System.Drawing.Size(101, 19);
			this.txtStartDate.TabIndex = 23;
			// this.txtStartDate.Text = "8/6/2003";
			// this.txtStartDate.Value = 37839;
			// 
			// _lblDisplayLabel_4
			// 
			this._lblDisplayLabel_4.AllowDrop = true;
			this._lblDisplayLabel_4.BackColor = System.Drawing.SystemColors.Window;
			this._lblDisplayLabel_4.Text = "Short Name (English)";
			this._lblDisplayLabel_4.Location = new System.Drawing.Point(4, 10);
			this._lblDisplayLabel_4.Name = "_lblDisplayLabel_4";
			this._lblDisplayLabel_4.Size = new System.Drawing.Size(101, 14);
			this._lblDisplayLabel_4.TabIndex = 34;
			// 
			// _txtCommon_3
			// 
			this._txtCommon_3.AllowDrop = true;
			this._txtCommon_3.BackColor = System.Drawing.Color.White;
			this._txtCommon_3.ForeColor = System.Drawing.Color.Black;
			this._txtCommon_3.Location = new System.Drawing.Point(112, 8);
			this._txtCommon_3.MaxLength = 30;
			this._txtCommon_3.Name = "_txtCommon_3";
			this._txtCommon_3.Size = new System.Drawing.Size(103, 19);
			this._txtCommon_3.TabIndex = 35;
			this._txtCommon_3.Text = "";
			// this.this._txtCommon_3.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommon_DropButtonClick);
			// 
			// _lblDisplayLabel_5
			// 
			this._lblDisplayLabel_5.AllowDrop = true;
			this._lblDisplayLabel_5.BackColor = System.Drawing.SystemColors.Window;
			this._lblDisplayLabel_5.Text = "Short Name (Arabic)";
			this._lblDisplayLabel_5.Location = new System.Drawing.Point(4, 33);
			this._lblDisplayLabel_5.Name = "_lblDisplayLabel_5";
			this._lblDisplayLabel_5.Size = new System.Drawing.Size(99, 14);
			this._lblDisplayLabel_5.TabIndex = 36;
			// 
			// _txtCommon_4
			// 
			this._txtCommon_4.AllowDrop = true;
			this._txtCommon_4.BackColor = System.Drawing.Color.White;
			this._txtCommon_4.ForeColor = System.Drawing.Color.Black;
			this._txtCommon_4.Location = new System.Drawing.Point(112, 31);
			// this._txtCommon_4.mArabicEnabled = true;
			this._txtCommon_4.MaxLength = 30;
			this._txtCommon_4.Name = "_txtCommon_4";
			this._txtCommon_4.Size = new System.Drawing.Size(103, 19);
			this._txtCommon_4.TabIndex = 37;
			this._txtCommon_4.Text = "";
			// this.this._txtCommon_4.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommon_DropButtonClick);
			// 
			// _fraLedgerInformation_1
			// 
			this._fraLedgerInformation_1.AllowDrop = true;
			this._fraLedgerInformation_1.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._fraLedgerInformation_1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._fraLedgerInformation_1.Controls.Add(this.txtSupervisorName);
			this._fraLedgerInformation_1.Controls.Add(this._lblCommon_14);
			this._fraLedgerInformation_1.Controls.Add(this._lblCommon_17);
			this._fraLedgerInformation_1.Enabled = true;
			this._fraLedgerInformation_1.ForeColor = System.Drawing.SystemColors.WindowText;
			this._fraLedgerInformation_1.Location = new System.Drawing.Point(678, 23);
			this._fraLedgerInformation_1.Name = "_fraLedgerInformation_1";
			this._fraLedgerInformation_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._fraLedgerInformation_1.Size = new System.Drawing.Size(635, 177);
			this._fraLedgerInformation_1.TabIndex = 9;
			this._fraLedgerInformation_1.Visible = true;
			// 
			// txtSupervisorName
			// 
			this.txtSupervisorName.AllowDrop = true;
			this.txtSupervisorName.BackColor = System.Drawing.Color.White;
			this.txtSupervisorName.ForeColor = System.Drawing.Color.Black;
			this.txtSupervisorName.Location = new System.Drawing.Point(116, 124);
			this.txtSupervisorName.Name = "txtSupervisorName";
			this.txtSupervisorName.Size = new System.Drawing.Size(173, 19);
			this.txtSupervisorName.TabIndex = 10;
			this.txtSupervisorName.Text = "";
			// 
			// _lblCommon_14
			// 
			this._lblCommon_14.AllowDrop = true;
			this._lblCommon_14.BackColor = System.Drawing.SystemColors.Window;
			this._lblCommon_14.Text = "Supervisor Name";
			this._lblCommon_14.Location = new System.Drawing.Point(8, 126);
			this._lblCommon_14.Name = "_lblCommon_14";
			this._lblCommon_14.Size = new System.Drawing.Size(83, 14);
			this._lblCommon_14.TabIndex = 11;
			// 
			// _lblCommon_17
			// 
			this._lblCommon_17.AllowDrop = true;
			this._lblCommon_17.BackColor = System.Drawing.SystemColors.Window;
			this._lblCommon_17.Text = "City";
			this._lblCommon_17.Location = new System.Drawing.Point(374, 16);
			this._lblCommon_17.Name = "_lblCommon_17";
			this._lblCommon_17.Size = new System.Drawing.Size(18, 14);
			this._lblCommon_17.TabIndex = 12;
			// 
			// frmGLAnalysisCode
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.ClientSize = new System.Drawing.Size(648, 291);
			this.Controls.Add(this.comAnalysisHeadNo);
			this.Controls.Add(this._txtCommon_0);
			this.Controls.Add(this._lblDisplayLabel_2);
			this.Controls.Add(this._txtCommon_1);
			this.Controls.Add(this._lblDisplayLabel_3);
			this.Controls.Add(this._txtCommon_2);
			this.Controls.Add(this._lblDisplayLabel_1);
			this.Controls.Add(this._lblDisplayLabel_0);
			this.Controls.Add(this.tabMaster);
			//this.Icon = (System.Drawing.Icon) resources.GetObject("frmGLAnalysisCode.Icon");
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(420, 255);
			this.MaximizeBox = true;
			this.MinimizeBox = true;
			this.Name = "frmGLAnalysisCode";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Job Code";
			// this.Activated += new System.EventHandler(this.frmGLAnalysisCode_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
			// this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
			//((System.ComponentModel.ISupportInitialize) this.tabMaster).EndInit();
			this.tabMaster.ResumeLayout(false);
			this._fraLedgerInformation_3.ResumeLayout(false);
			this._fraLedgerInformation_4.ResumeLayout(false);
			this._fraLedgerInformation_0.ResumeLayout(false);
			this._fraLedgerInformation_1.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		// 
		void InitializetxtCommonNumber()
		{
			this.txtCommonNumber = new System.Windows.Forms.TextBox[4];
			this.txtCommonNumber[3] = _txtCommonNumber_3;
			this.txtCommonNumber[1] = _txtCommonNumber_1;
			this.txtCommonNumber[0] = _txtCommonNumber_0;
		}
		void InitializetxtCommonLable()
		{
			this.txtCommonLable = new System.Windows.Forms.Label[7];
			this.txtCommonLable[6] = _txtCommonLable_6;
			this.txtCommonLable[5] = _txtCommonLable_5;
			this.txtCommonLable[4] = _txtCommonLable_4;
		}
		void InitializetxtCommon()
		{
			this.txtCommon = new System.Windows.Forms.TextBox[23];
			this.txtCommon[0] = _txtCommon_0;
			this.txtCommon[1] = _txtCommon_1;
			this.txtCommon[2] = _txtCommon_2;
			this.txtCommon[20] = _txtCommon_20;
			this.txtCommon[21] = _txtCommon_21;
			this.txtCommon[22] = _txtCommon_22;
			this.txtCommon[3] = _txtCommon_3;
			this.txtCommon[4] = _txtCommon_4;
		}
		void InitializelblDisplayLabel()
		{
			this.lblDisplayLabel = new System.Windows.Forms.Label[6];
			this.lblDisplayLabel[2] = _lblDisplayLabel_2;
			this.lblDisplayLabel[3] = _lblDisplayLabel_3;
			this.lblDisplayLabel[1] = _lblDisplayLabel_1;
			this.lblDisplayLabel[0] = _lblDisplayLabel_0;
			this.lblDisplayLabel[4] = _lblDisplayLabel_4;
			this.lblDisplayLabel[5] = _lblDisplayLabel_5;
		}
		void InitializelblCommon()
		{
			this.lblCommon = new System.Windows.Forms.Label[39];
			this.lblCommon[18] = _lblCommon_18;
			this.lblCommon[22] = _lblCommon_22;
			this.lblCommon[25] = _lblCommon_25;
			this.lblCommon[26] = _lblCommon_26;
			this.lblCommon[36] = _lblCommon_36;
			this.lblCommon[37] = _lblCommon_37;
			this.lblCommon[38] = _lblCommon_38;
			this.lblCommon[6] = _lblCommon_6;
			this.lblCommon[8] = _lblCommon_8;
			this.lblCommon[10] = _lblCommon_10;
			this.lblCommon[14] = _lblCommon_14;
			this.lblCommon[17] = _lblCommon_17;
		}
		void InitializefraLedgerInformation()
		{
			this.fraLedgerInformation = new System.Windows.Forms.Panel[5];
			this.fraLedgerInformation[2] = _fraLedgerInformation_2;
			this.fraLedgerInformation[3] = _fraLedgerInformation_3;
			this.fraLedgerInformation[4] = _fraLedgerInformation_4;
			this.fraLedgerInformation[0] = _fraLedgerInformation_0;
			this.fraLedgerInformation[1] = _fraLedgerInformation_1;
		}
		void InitializecmbPriceLevel()
		{
			this.cmbPriceLevel = new System.Windows.Forms.ComboBox[6];
			this.cmbPriceLevel[5] = _cmbPriceLevel_5;
			this.cmbPriceLevel[4] = _cmbPriceLevel_4;
			this.cmbPriceLevel[3] = _cmbPriceLevel_3;
			this.cmbPriceLevel[2] = _cmbPriceLevel_2;
			this.cmbPriceLevel[1] = _cmbPriceLevel_1;
			this.cmbPriceLevel[0] = _cmbPriceLevel_0;
		}
		#endregion
	}
}//ENDSHERE
