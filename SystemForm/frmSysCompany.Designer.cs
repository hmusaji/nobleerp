
namespace Xtreme
{
	partial class frmSysCompany
	{

		#region "Upgrade Support "
		private static frmSysCompany m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmSysCompany DefInstance
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
		public static frmSysCompany CreateInstance()
		{
			frmSysCompany theInstance = new frmSysCompany();
			
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
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "_chkCommon_5", "_chkCommon_4", "_chkCommon_3", "_chkCommon_2", "_chkCommon_1", "_chkCommon_0", "_optPreferenceSettings_1", "_optPreferenceSettings_0", "_cmbCommon_2", "_lblCommon_17", "fraInitialCompanyLevelPreferences", "_cmbCommon_0", "_lblCommon_14", "_lblCommon_15", "_lblCommon_13", "_txtCommon_6", "_txtCommon_7", "_cmbCommon_1", "_lblCommon_16", "_fraMasterInformation_2", "_lblCommon_10", "_txtCommon_4", "_lblCommon_11", "_txtCommon_5", "_fraMasterInformation_1", "txtComment", "_lblCommon_4", "_txtCommon_3", "_lblCommon_5", "_lblCommon_6", "_lblCommon_7", "_lblCommon_8", "_lblCommon_9", "_txtCommonDate_0", "_txtCommonDate_1", "_txtCommonDate_2", "_txtCommonDate_3", "_lblCommon_12", "_txtCommonDate_4", "_fraMasterInformation_0", "tabMaster", "_txtCommon_1", "_txtCommon_2", "_lblCommon_0", "_txtCommon_0", "_lblCommon_1", "_lblCommon_2", "_lblCommon_3", "Line1", "cntOuterFrame", "tcbSystemForm", "chkCommon", "cmbCommon", "fraMasterInformation", "lblCommon", "optPreferenceSettings", "txtCommon", "txtCommonDate"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		private System.Windows.Forms.CheckBox _chkCommon_5;
		private System.Windows.Forms.CheckBox _chkCommon_4;
		private System.Windows.Forms.CheckBox _chkCommon_3;
		private System.Windows.Forms.CheckBox _chkCommon_2;
		private System.Windows.Forms.CheckBox _chkCommon_1;
		private System.Windows.Forms.CheckBox _chkCommon_0;
		private System.Windows.Forms.RadioButton _optPreferenceSettings_1;
		private System.Windows.Forms.RadioButton _optPreferenceSettings_0;
		private System.Windows.Forms.ComboBox _cmbCommon_2;
		private System.Windows.Forms.Label _lblCommon_17;
		public System.Windows.Forms.GroupBox fraInitialCompanyLevelPreferences;
		private System.Windows.Forms.ComboBox _cmbCommon_0;
		private System.Windows.Forms.Label _lblCommon_14;
		private System.Windows.Forms.Label _lblCommon_15;
		private System.Windows.Forms.Label _lblCommon_13;
		private System.Windows.Forms.TextBox _txtCommon_6;
		private System.Windows.Forms.TextBox _txtCommon_7;
		private System.Windows.Forms.ComboBox _cmbCommon_1;
		private System.Windows.Forms.Label _lblCommon_16;
		private System.Windows.Forms.Panel _fraMasterInformation_2;
		private System.Windows.Forms.Label _lblCommon_10;
		private System.Windows.Forms.TextBox _txtCommon_4;
		private System.Windows.Forms.Label _lblCommon_11;
		private System.Windows.Forms.TextBox _txtCommon_5;
		private System.Windows.Forms.Panel _fraMasterInformation_1;
		public System.Windows.Forms.TextBox txtComment;
		private System.Windows.Forms.Label _lblCommon_4;
		private System.Windows.Forms.TextBox _txtCommon_3;
		private System.Windows.Forms.Label _lblCommon_5;
		private System.Windows.Forms.Label _lblCommon_6;
		private System.Windows.Forms.Label _lblCommon_7;
		private System.Windows.Forms.Label _lblCommon_8;
		private System.Windows.Forms.Label _lblCommon_9;
		private Syncfusion.WinForms.Input.SfDateTimeEdit _txtCommonDate_0;
		private Syncfusion.WinForms.Input.SfDateTimeEdit _txtCommonDate_1;
		private Syncfusion.WinForms.Input.SfDateTimeEdit _txtCommonDate_2;
		private Syncfusion.WinForms.Input.SfDateTimeEdit _txtCommonDate_3;
		private System.Windows.Forms.Label _lblCommon_12;
		private Syncfusion.WinForms.Input.SfDateTimeEdit _txtCommonDate_4;
		private System.Windows.Forms.Panel _fraMasterInformation_0;
		public AxC1SizerLib.AxC1Tab tabMaster;
		private System.Windows.Forms.TextBox _txtCommon_1;
		private System.Windows.Forms.TextBox _txtCommon_2;
		private System.Windows.Forms.Label _lblCommon_0;
		private System.Windows.Forms.TextBox _txtCommon_0;
		private System.Windows.Forms.Label _lblCommon_1;
		private System.Windows.Forms.Label _lblCommon_2;
		private System.Windows.Forms.Label _lblCommon_3;
		public System.Windows.Forms.Label Line1;
		public AxC1SizerLib.AxC1Elastic cntOuterFrame;
		public Syncfusion.Windows.Forms.Tools.CommandBarController tcbSystemForm;
		public System.Windows.Forms.CheckBox[] chkCommon = new System.Windows.Forms.CheckBox[6];
		public System.Windows.Forms.ComboBox[] cmbCommon = new System.Windows.Forms.ComboBox[3];
		public System.Windows.Forms.Panel[] fraMasterInformation = new System.Windows.Forms.Panel[3];
		public System.Windows.Forms.Label[] lblCommon = new System.Windows.Forms.Label[18];
		public System.Windows.Forms.RadioButton[] optPreferenceSettings = new System.Windows.Forms.RadioButton[2];
		public System.Windows.Forms.TextBox[] txtCommon = new System.Windows.Forms.TextBox[8];
		public Syncfusion.WinForms.Input.SfDateTimeEdit[] txtCommonDate = new Syncfusion.WinForms.Input.SfDateTimeEdit[5];
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSysCompany));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this.cntOuterFrame = new AxC1SizerLib.AxC1Elastic();
			this.tabMaster = new AxC1SizerLib.AxC1Tab();
			this._fraMasterInformation_2 = new System.Windows.Forms.Panel();
			this.fraInitialCompanyLevelPreferences = new System.Windows.Forms.GroupBox();
			this._chkCommon_5 = new System.Windows.Forms.CheckBox();
			this._chkCommon_4 = new System.Windows.Forms.CheckBox();
			this._chkCommon_3 = new System.Windows.Forms.CheckBox();
			this._chkCommon_2 = new System.Windows.Forms.CheckBox();
			this._chkCommon_1 = new System.Windows.Forms.CheckBox();
			this._chkCommon_0 = new System.Windows.Forms.CheckBox();
			this._optPreferenceSettings_1 = new System.Windows.Forms.RadioButton();
			this._optPreferenceSettings_0 = new System.Windows.Forms.RadioButton();
			this._cmbCommon_2 = new System.Windows.Forms.ComboBox();
			this._lblCommon_17 = new System.Windows.Forms.Label();
			this._cmbCommon_0 = new System.Windows.Forms.ComboBox();
			this._lblCommon_14 = new System.Windows.Forms.Label();
			this._lblCommon_15 = new System.Windows.Forms.Label();
			this._lblCommon_13 = new System.Windows.Forms.Label();
			this._txtCommon_6 = new System.Windows.Forms.TextBox();
			this._txtCommon_7 = new System.Windows.Forms.TextBox();
			this._cmbCommon_1 = new System.Windows.Forms.ComboBox();
			this._lblCommon_16 = new System.Windows.Forms.Label();
			this._fraMasterInformation_1 = new System.Windows.Forms.Panel();
			this._lblCommon_10 = new System.Windows.Forms.Label();
			this._txtCommon_4 = new System.Windows.Forms.TextBox();
			this._lblCommon_11 = new System.Windows.Forms.Label();
			this._txtCommon_5 = new System.Windows.Forms.TextBox();
			this._fraMasterInformation_0 = new System.Windows.Forms.Panel();
			this.txtComment = new System.Windows.Forms.TextBox();
			this._lblCommon_4 = new System.Windows.Forms.Label();
			this._txtCommon_3 = new System.Windows.Forms.TextBox();
			this._lblCommon_5 = new System.Windows.Forms.Label();
			this._lblCommon_6 = new System.Windows.Forms.Label();
			this._lblCommon_7 = new System.Windows.Forms.Label();
			this._lblCommon_8 = new System.Windows.Forms.Label();
			this._lblCommon_9 = new System.Windows.Forms.Label();
			this._txtCommonDate_0 = new Syncfusion.WinForms.Input.SfDateTimeEdit();
			this._txtCommonDate_1 = new Syncfusion.WinForms.Input.SfDateTimeEdit();
			this._txtCommonDate_2 = new Syncfusion.WinForms.Input.SfDateTimeEdit();
			this._txtCommonDate_3 = new Syncfusion.WinForms.Input.SfDateTimeEdit();
			this._lblCommon_12 = new System.Windows.Forms.Label();
			this._txtCommonDate_4 = new Syncfusion.WinForms.Input.SfDateTimeEdit();
			this._txtCommon_1 = new System.Windows.Forms.TextBox();
			this._txtCommon_2 = new System.Windows.Forms.TextBox();
			this._lblCommon_0 = new System.Windows.Forms.Label();
			this._txtCommon_0 = new System.Windows.Forms.TextBox();
			this._lblCommon_1 = new System.Windows.Forms.Label();
			this._lblCommon_2 = new System.Windows.Forms.Label();
			this._lblCommon_3 = new System.Windows.Forms.Label();
			this.Line1 = new System.Windows.Forms.Label();
			this.tcbSystemForm = new Syncfusion.Windows.Forms.Tools.CommandBarController();
			// //((System.ComponentModel.ISupportInitialize) this.tabMaster).BeginInit();
			// //((System.ComponentModel.ISupportInitialize) this.cntOuterFrame).BeginInit();
			// //((System.ComponentModel.ISupportInitialize) this.tcbSystemForm).BeginInit();
			this.cntOuterFrame.SuspendLayout();
			this.tabMaster.SuspendLayout();
			this._fraMasterInformation_2.SuspendLayout();
			this.fraInitialCompanyLevelPreferences.SuspendLayout();
			this._fraMasterInformation_1.SuspendLayout();
			this._fraMasterInformation_0.SuspendLayout();
			this.SuspendLayout();
			// 
			// cntOuterFrame
			// 
			this.cntOuterFrame.Align = C1SizerLib.AlignSettings.asNone;
			this.cntOuterFrame.AllowDrop = true;
			this.cntOuterFrame.Controls.Add(this.tabMaster);
			this.cntOuterFrame.Controls.Add(this._txtCommon_1);
			this.cntOuterFrame.Controls.Add(this._txtCommon_2);
			this.cntOuterFrame.Controls.Add(this._lblCommon_0);
			this.cntOuterFrame.Controls.Add(this._txtCommon_0);
			this.cntOuterFrame.Controls.Add(this._lblCommon_1);
			this.cntOuterFrame.Controls.Add(this._lblCommon_2);
			this.cntOuterFrame.Controls.Add(this._lblCommon_3);
			this.cntOuterFrame.Controls.Add(this.Line1);
			this.cntOuterFrame.Location = new System.Drawing.Point(0, 38);
			this.cntOuterFrame.Name = "cntOuterFrame";
			("cntOuterFrame.OcxState");
			this.cntOuterFrame.Size = new System.Drawing.Size(800, 555);
			this.cntOuterFrame.TabIndex = 25;
			this.cntOuterFrame.TabStop = false;
			// 
			// tabMaster
			// 
			this.tabMaster.Align = C1SizerLib.AlignSettings.asNone;
			this.tabMaster.AllowDrop = true;
			this.tabMaster.Controls.Add(this._fraMasterInformation_2);
			this.tabMaster.Controls.Add(this._fraMasterInformation_1);
			this.tabMaster.Controls.Add(this._fraMasterInformation_0);
			this.tabMaster.Location = new System.Drawing.Point(4, 94);
			this.tabMaster.Name = "tabMaster";
			("tabMaster.OcxState");
			this.tabMaster.Size = new System.Drawing.Size(598, 261);
			this.tabMaster.TabIndex = 26;
			this.tabMaster.TabStop = false;
			// 
			// _fraMasterInformation_2
			// 
			this._fraMasterInformation_2.AllowDrop = true;
			this._fraMasterInformation_2.BackColor = System.Drawing.Color.FromArgb(243, 243, 243);
			this._fraMasterInformation_2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._fraMasterInformation_2.Controls.Add(this.fraInitialCompanyLevelPreferences);
			this._fraMasterInformation_2.Controls.Add(this._cmbCommon_0);
			this._fraMasterInformation_2.Controls.Add(this._lblCommon_14);
			this._fraMasterInformation_2.Controls.Add(this._lblCommon_15);
			this._fraMasterInformation_2.Controls.Add(this._lblCommon_13);
			this._fraMasterInformation_2.Controls.Add(this._txtCommon_6);
			this._fraMasterInformation_2.Controls.Add(this._txtCommon_7);
			this._fraMasterInformation_2.Controls.Add(this._cmbCommon_1);
			this._fraMasterInformation_2.Controls.Add(this._lblCommon_16);
			this._fraMasterInformation_2.Enabled = true;
			this._fraMasterInformation_2.ForeColor = System.Drawing.SystemColors.WindowText;
			this._fraMasterInformation_2.Location = new System.Drawing.Point(1, 23);
			this._fraMasterInformation_2.Name = "_fraMasterInformation_2";
			this._fraMasterInformation_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._fraMasterInformation_2.Size = new System.Drawing.Size(596, 237);
			this._fraMasterInformation_2.TabIndex = 33;
			this._fraMasterInformation_2.Visible = true;
			// 
			// fraInitialCompanyLevelPreferences
			// 
			this.fraInitialCompanyLevelPreferences.AllowDrop = true;
			this.fraInitialCompanyLevelPreferences.BackColor = System.Drawing.Color.FromArgb(243, 243, 243);
			this.fraInitialCompanyLevelPreferences.Controls.Add(this._chkCommon_5);
			this.fraInitialCompanyLevelPreferences.Controls.Add(this._chkCommon_4);
			this.fraInitialCompanyLevelPreferences.Controls.Add(this._chkCommon_3);
			this.fraInitialCompanyLevelPreferences.Controls.Add(this._chkCommon_2);
			this.fraInitialCompanyLevelPreferences.Controls.Add(this._chkCommon_1);
			this.fraInitialCompanyLevelPreferences.Controls.Add(this._chkCommon_0);
			this.fraInitialCompanyLevelPreferences.Controls.Add(this._optPreferenceSettings_1);
			this.fraInitialCompanyLevelPreferences.Controls.Add(this._optPreferenceSettings_0);
			this.fraInitialCompanyLevelPreferences.Controls.Add(this._cmbCommon_2);
			this.fraInitialCompanyLevelPreferences.Controls.Add(this._lblCommon_17);
			this.fraInitialCompanyLevelPreferences.Enabled = true;
			this.fraInitialCompanyLevelPreferences.ForeColor = System.Drawing.SystemColors.WindowText;
			this.fraInitialCompanyLevelPreferences.Location = new System.Drawing.Point(10, 68);
			this.fraInitialCompanyLevelPreferences.Name = "fraInitialCompanyLevelPreferences";
			this.fraInitialCompanyLevelPreferences.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.fraInitialCompanyLevelPreferences.Size = new System.Drawing.Size(577, 163);
			this.fraInitialCompanyLevelPreferences.TabIndex = 45;
			this.fraInitialCompanyLevelPreferences.Text = " Initial Company Level Preferences ";
			this.fraInitialCompanyLevelPreferences.Visible = true;
			// 
			// _chkCommon_5
			// 
			this._chkCommon_5.AllowDrop = true;
			this._chkCommon_5.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkCommon_5.BackColor = System.Drawing.Color.FromArgb(243, 243, 243);
			this._chkCommon_5.CausesValidation = true;
			this._chkCommon_5.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_5.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkCommon_5.Enabled = false;
			this._chkCommon_5.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkCommon_5.Location = new System.Drawing.Point(376, 69);
			this._chkCommon_5.Name = "_chkCommon_5";
			this._chkCommon_5.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkCommon_5.Size = new System.Drawing.Size(173, 19);
			this._chkCommon_5.TabIndex = 15;
			this._chkCommon_5.TabStop = true;
			this._chkCommon_5.Text = "Make Exact Replica";
			this._chkCommon_5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_5.Visible = true;
			this._chkCommon_5.CheckStateChanged += new System.EventHandler(this.chkCommon_CheckStateChanged);
			// 
			// _chkCommon_4
			// 
			this._chkCommon_4.AllowDrop = true;
			this._chkCommon_4.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkCommon_4.BackColor = System.Drawing.Color.FromArgb(243, 243, 243);
			this._chkCommon_4.CausesValidation = true;
			this._chkCommon_4.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_4.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkCommon_4.Enabled = false;
			this._chkCommon_4.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkCommon_4.Location = new System.Drawing.Point(376, 137);
			this._chkCommon_4.Name = "_chkCommon_4";
			this._chkCommon_4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkCommon_4.Size = new System.Drawing.Size(173, 19);
			this._chkCommon_4.TabIndex = 20;
			this._chkCommon_4.TabStop = true;
			this._chkCommon_4.Text = "Import ICS Masters Data";
			this._chkCommon_4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_4.Visible = true;
			this._chkCommon_4.CheckStateChanged += new System.EventHandler(this.chkCommon_CheckStateChanged);
			// 
			// _chkCommon_3
			// 
			this._chkCommon_3.AllowDrop = true;
			this._chkCommon_3.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkCommon_3.BackColor = System.Drawing.Color.FromArgb(243, 243, 243);
			this._chkCommon_3.CausesValidation = true;
			this._chkCommon_3.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_3.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkCommon_3.Enabled = false;
			this._chkCommon_3.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkCommon_3.Location = new System.Drawing.Point(92, 137);
			this._chkCommon_3.Name = "_chkCommon_3";
			this._chkCommon_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkCommon_3.Size = new System.Drawing.Size(173, 19);
			this._chkCommon_3.TabIndex = 18;
			this._chkCommon_3.TabStop = true;
			this._chkCommon_3.Text = "Import GL Masters Data";
			this._chkCommon_3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_3.Visible = true;
			this._chkCommon_3.CheckStateChanged += new System.EventHandler(this.chkCommon_CheckStateChanged);
			// 
			// _chkCommon_2
			// 
			this._chkCommon_2.AllowDrop = true;
			this._chkCommon_2.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkCommon_2.BackColor = System.Drawing.Color.FromArgb(243, 243, 243);
			this._chkCommon_2.CausesValidation = true;
			this._chkCommon_2.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_2.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkCommon_2.Enabled = false;
			this._chkCommon_2.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkCommon_2.Location = new System.Drawing.Point(376, 116);
			this._chkCommon_2.Name = "_chkCommon_2";
			this._chkCommon_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkCommon_2.Size = new System.Drawing.Size(173, 19);
			this._chkCommon_2.TabIndex = 19;
			this._chkCommon_2.TabStop = true;
			this._chkCommon_2.Text = "Import ICS Vouchers Settings";
			this._chkCommon_2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_2.Visible = true;
			this._chkCommon_2.CheckStateChanged += new System.EventHandler(this.chkCommon_CheckStateChanged);
			// 
			// _chkCommon_1
			// 
			this._chkCommon_1.AllowDrop = true;
			this._chkCommon_1.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkCommon_1.BackColor = System.Drawing.Color.FromArgb(243, 243, 243);
			this._chkCommon_1.CausesValidation = true;
			this._chkCommon_1.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_1.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkCommon_1.Enabled = false;
			this._chkCommon_1.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkCommon_1.Location = new System.Drawing.Point(92, 116);
			this._chkCommon_1.Name = "_chkCommon_1";
			this._chkCommon_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkCommon_1.Size = new System.Drawing.Size(173, 19);
			this._chkCommon_1.TabIndex = 17;
			this._chkCommon_1.TabStop = true;
			this._chkCommon_1.Text = "Import GL Vouchers Settings";
			this._chkCommon_1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_1.Visible = true;
			this._chkCommon_1.CheckStateChanged += new System.EventHandler(this.chkCommon_CheckStateChanged);
			// 
			// _chkCommon_0
			// 
			this._chkCommon_0.AllowDrop = true;
			this._chkCommon_0.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkCommon_0.BackColor = System.Drawing.Color.FromArgb(243, 243, 243);
			this._chkCommon_0.CausesValidation = true;
			this._chkCommon_0.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_0.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkCommon_0.Enabled = false;
			this._chkCommon_0.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkCommon_0.Location = new System.Drawing.Point(92, 95);
			this._chkCommon_0.Name = "_chkCommon_0";
			this._chkCommon_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkCommon_0.Size = new System.Drawing.Size(173, 19);
			this._chkCommon_0.TabIndex = 16;
			this._chkCommon_0.TabStop = true;
			this._chkCommon_0.Text = "Import Preferences && Settings";
			this._chkCommon_0.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_0.Visible = true;
			this._chkCommon_0.CheckStateChanged += new System.EventHandler(this.chkCommon_CheckStateChanged);
			// 
			// _optPreferenceSettings_1
			// 
			this._optPreferenceSettings_1.AllowDrop = true;
			this._optPreferenceSettings_1.Appearance = System.Windows.Forms.Appearance.Normal;
			this._optPreferenceSettings_1.BackColor = System.Drawing.Color.FromArgb(243, 243, 243);
			this._optPreferenceSettings_1.CausesValidation = true;
			this._optPreferenceSettings_1.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._optPreferenceSettings_1.Checked = false;
			this._optPreferenceSettings_1.Enabled = true;
			this._optPreferenceSettings_1.ForeColor = System.Drawing.SystemColors.ControlText;
			this._optPreferenceSettings_1.Location = new System.Drawing.Point(28, 45);
			this._optPreferenceSettings_1.Name = "_optPreferenceSettings_1";
			this._optPreferenceSettings_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._optPreferenceSettings_1.Size = new System.Drawing.Size(209, 19);
			this._optPreferenceSettings_1.TabIndex = 13;
			this._optPreferenceSettings_1.TabStop = true;
			this._optPreferenceSettings_1.Text = "Use Settings From Existing Company";
			this._optPreferenceSettings_1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._optPreferenceSettings_1.Visible = true;
			this._optPreferenceSettings_1.CheckedChanged += new System.EventHandler(this.optPreferenceSettings_CheckedChanged);
			// 
			// _optPreferenceSettings_0
			// 
			this._optPreferenceSettings_0.AllowDrop = true;
			this._optPreferenceSettings_0.Appearance = System.Windows.Forms.Appearance.Normal;
			this._optPreferenceSettings_0.BackColor = System.Drawing.Color.FromArgb(243, 243, 243);
			this._optPreferenceSettings_0.CausesValidation = true;
			this._optPreferenceSettings_0.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._optPreferenceSettings_0.Checked = true;
			this._optPreferenceSettings_0.Enabled = true;
			this._optPreferenceSettings_0.ForeColor = System.Drawing.SystemColors.ControlText;
			this._optPreferenceSettings_0.Location = new System.Drawing.Point(28, 24);
			this._optPreferenceSettings_0.Name = "_optPreferenceSettings_0";
			this._optPreferenceSettings_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._optPreferenceSettings_0.Size = new System.Drawing.Size(209, 19);
			this._optPreferenceSettings_0.TabIndex = 12;
			this._optPreferenceSettings_0.TabStop = true;
			this._optPreferenceSettings_0.Text = "Use Default Settings";
			this._optPreferenceSettings_0.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._optPreferenceSettings_0.Visible = true;
			this._optPreferenceSettings_0.CheckedChanged += new System.EventHandler(this.optPreferenceSettings_CheckedChanged);
			// 
			// _cmbCommon_2
			// 
			this._cmbCommon_2.AllowDrop = true;
			this._cmbCommon_2.Enabled = false;
			this._cmbCommon_2.Location = new System.Drawing.Point(140, 68);
			this._cmbCommon_2.Name = "_cmbCommon_2";
			this._cmbCommon_2.Size = new System.Drawing.Size(201, 21);
			this._cmbCommon_2.TabIndex = 14;
			// 
			// _lblCommon_17
			// 
			this._lblCommon_17.AllowDrop = true;
			this._lblCommon_17.BackColor = System.Drawing.SystemColors.Window;
			this._lblCommon_17.Text = "Company";
			this._lblCommon_17.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_17.Location = new System.Drawing.Point(66, 71);
			this._lblCommon_17.Name = "_lblCommon_17";
			this._lblCommon_17.Size = new System.Drawing.Size(45, 14);
			this._lblCommon_17.TabIndex = 46;
			// 
			// _cmbCommon_0
			// 
			this._cmbCommon_0.AllowDrop = true;
			this._cmbCommon_0.Location = new System.Drawing.Point(96, 14);
			this._cmbCommon_0.Name = "_cmbCommon_0";
			this._cmbCommon_0.Size = new System.Drawing.Size(134, 21);
			this._cmbCommon_0.TabIndex = 8;
			// 
			// _lblCommon_14
			// 
			this._lblCommon_14.AllowDrop = true;
			this._lblCommon_14.BackColor = System.Drawing.SystemColors.Window;
			this._lblCommon_14.Text = "Product Key";
			this._lblCommon_14.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_14.Location = new System.Drawing.Point(268, 18);
			this._lblCommon_14.Name = "_lblCommon_14";
			this._lblCommon_14.Size = new System.Drawing.Size(59, 14);
			this._lblCommon_14.TabIndex = 43;
			// 
			// _lblCommon_15
			// 
			this._lblCommon_15.AllowDrop = true;
			this._lblCommon_15.BackColor = System.Drawing.SystemColors.Window;
			this._lblCommon_15.Text = "System Edition";
			this._lblCommon_15.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_15.Location = new System.Drawing.Point(8, 18);
			this._lblCommon_15.Name = "_lblCommon_15";
			this._lblCommon_15.Size = new System.Drawing.Size(70, 14);
			this._lblCommon_15.TabIndex = 44;
			// 
			// _lblCommon_13
			// 
			this._lblCommon_13.AllowDrop = true;
			this._lblCommon_13.BackColor = System.Drawing.SystemColors.Window;
			this._lblCommon_13.Text = "DB Backend";
			this._lblCommon_13.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_13.Location = new System.Drawing.Point(268, 39);
			this._lblCommon_13.Name = "_lblCommon_13";
			this._lblCommon_13.Size = new System.Drawing.Size(59, 14);
			this._lblCommon_13.TabIndex = 47;
			// 
			// _txtCommon_6
			// 
			this._txtCommon_6.AllowDrop = true;
			this._txtCommon_6.BackColor = System.Drawing.Color.White;
			this._txtCommon_6.ForeColor = System.Drawing.Color.Black;
			this._txtCommon_6.Location = new System.Drawing.Point(354, 36);
			this._txtCommon_6.MaxLength = 50;
			this._txtCommon_6.Name = "_txtCommon_6";
			this._txtCommon_6.Size = new System.Drawing.Size(101, 19);
			this._txtCommon_6.TabIndex = 11;
			this._txtCommon_6.Text = "";
			// this.this._txtCommon_6.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommon_DropButtonClick);
			// this.this._txtCommon_6.KeyPress += new System.Windows.Forms.TextBox.KeyPressHandler(this.txtCommon_KeyPress);
			// 
			// _txtCommon_7
			// 
			this._txtCommon_7.AllowDrop = true;
			this._txtCommon_7.BackColor = System.Drawing.Color.White;
			this._txtCommon_7.ForeColor = System.Drawing.Color.Black;
			this._txtCommon_7.Location = new System.Drawing.Point(354, 15);
			this._txtCommon_7.MaxLength = 50;
			this._txtCommon_7.Name = "_txtCommon_7";
			this._txtCommon_7.Size = new System.Drawing.Size(233, 19);
			this._txtCommon_7.TabIndex = 9;
			this._txtCommon_7.Text = "";
			// this.this._txtCommon_7.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommon_DropButtonClick);
			// this.this._txtCommon_7.KeyPress += new System.Windows.Forms.TextBox.KeyPressHandler(this.txtCommon_KeyPress);
			// 
			// _cmbCommon_1
			// 
			this._cmbCommon_1.AllowDrop = true;
			this._cmbCommon_1.Location = new System.Drawing.Point(96, 37);
			this._cmbCommon_1.Name = "_cmbCommon_1";
			this._cmbCommon_1.Size = new System.Drawing.Size(134, 21);
			this._cmbCommon_1.TabIndex = 10;
			// 
			// _lblCommon_16
			// 
			this._lblCommon_16.AllowDrop = true;
			this._lblCommon_16.BackColor = System.Drawing.SystemColors.Window;
			this._lblCommon_16.Text = "Color Scheme";
			this._lblCommon_16.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_16.Location = new System.Drawing.Point(8, 41);
			this._lblCommon_16.Name = "_lblCommon_16";
			this._lblCommon_16.Size = new System.Drawing.Size(67, 14);
			this._lblCommon_16.TabIndex = 48;
			// 
			// _fraMasterInformation_1
			// 
			this._fraMasterInformation_1.AllowDrop = true;
			this._fraMasterInformation_1.BackColor = System.Drawing.Color.FromArgb(243, 243, 243);
			this._fraMasterInformation_1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._fraMasterInformation_1.Controls.Add(this._lblCommon_10);
			this._fraMasterInformation_1.Controls.Add(this._txtCommon_4);
			this._fraMasterInformation_1.Controls.Add(this._lblCommon_11);
			this._fraMasterInformation_1.Controls.Add(this._txtCommon_5);
			this._fraMasterInformation_1.Enabled = true;
			this._fraMasterInformation_1.ForeColor = System.Drawing.SystemColors.WindowText;
			this._fraMasterInformation_1.Location = new System.Drawing.Point(-637, 23);
			this._fraMasterInformation_1.Name = "_fraMasterInformation_1";
			this._fraMasterInformation_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._fraMasterInformation_1.Size = new System.Drawing.Size(596, 237);
			this._fraMasterInformation_1.TabIndex = 32;
			this._fraMasterInformation_1.Visible = true;
			// 
			// _lblCommon_10
			// 
			this._lblCommon_10.AllowDrop = true;
			this._lblCommon_10.BackColor = System.Drawing.SystemColors.Window;
			this._lblCommon_10.Text = "Address 1";
			this._lblCommon_10.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_10.Location = new System.Drawing.Point(8, 17);
			this._lblCommon_10.Name = "_lblCommon_10";
			this._lblCommon_10.Size = new System.Drawing.Size(51, 14);
			this._lblCommon_10.TabIndex = 40;
			// 
			// _txtCommon_4
			// 
			this._txtCommon_4.AllowDrop = true;
			this._txtCommon_4.BackColor = System.Drawing.Color.White;
			this._txtCommon_4.ForeColor = System.Drawing.Color.Black;
			this._txtCommon_4.Location = new System.Drawing.Point(108, 14);
			this._txtCommon_4.MaxLength = 50;
			this._txtCommon_4.Name = "_txtCommon_4";
			this._txtCommon_4.Size = new System.Drawing.Size(201, 19);
			this._txtCommon_4.TabIndex = 6;
			this._txtCommon_4.Text = "";
			// this.this._txtCommon_4.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommon_DropButtonClick);
			// this.this._txtCommon_4.KeyPress += new System.Windows.Forms.TextBox.KeyPressHandler(this.txtCommon_KeyPress);
			// 
			// _lblCommon_11
			// 
			this._lblCommon_11.AllowDrop = true;
			this._lblCommon_11.BackColor = System.Drawing.SystemColors.Window;
			this._lblCommon_11.Text = "Address 2";
			this._lblCommon_11.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_11.Location = new System.Drawing.Point(8, 38);
			this._lblCommon_11.Name = "_lblCommon_11";
			this._lblCommon_11.Size = new System.Drawing.Size(51, 14);
			this._lblCommon_11.TabIndex = 41;
			// 
			// _txtCommon_5
			// 
			this._txtCommon_5.AllowDrop = true;
			this._txtCommon_5.BackColor = System.Drawing.Color.White;
			this._txtCommon_5.ForeColor = System.Drawing.Color.Black;
			this._txtCommon_5.Location = new System.Drawing.Point(108, 35);
			this._txtCommon_5.MaxLength = 50;
			this._txtCommon_5.Name = "_txtCommon_5";
			this._txtCommon_5.Size = new System.Drawing.Size(201, 19);
			this._txtCommon_5.TabIndex = 7;
			this._txtCommon_5.Text = "";
			// this.this._txtCommon_5.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommon_DropButtonClick);
			// this.this._txtCommon_5.KeyPress += new System.Windows.Forms.TextBox.KeyPressHandler(this.txtCommon_KeyPress);
			// 
			// _fraMasterInformation_0
			// 
			this._fraMasterInformation_0.AllowDrop = true;
			this._fraMasterInformation_0.BackColor = System.Drawing.Color.FromArgb(243, 243, 243);
			this._fraMasterInformation_0.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._fraMasterInformation_0.Controls.Add(this.txtComment);
			this._fraMasterInformation_0.Controls.Add(this._lblCommon_4);
			this._fraMasterInformation_0.Controls.Add(this._txtCommon_3);
			this._fraMasterInformation_0.Controls.Add(this._lblCommon_5);
			this._fraMasterInformation_0.Controls.Add(this._lblCommon_6);
			this._fraMasterInformation_0.Controls.Add(this._lblCommon_7);
			this._fraMasterInformation_0.Controls.Add(this._lblCommon_8);
			this._fraMasterInformation_0.Controls.Add(this._lblCommon_9);
			this._fraMasterInformation_0.Controls.Add(this._txtCommonDate_0);
			this._fraMasterInformation_0.Controls.Add(this._txtCommonDate_1);
			this._fraMasterInformation_0.Controls.Add(this._txtCommonDate_2);
			this._fraMasterInformation_0.Controls.Add(this._txtCommonDate_3);
			this._fraMasterInformation_0.Controls.Add(this._lblCommon_12);
			this._fraMasterInformation_0.Controls.Add(this._txtCommonDate_4);
			this._fraMasterInformation_0.Enabled = true;
			this._fraMasterInformation_0.ForeColor = System.Drawing.SystemColors.WindowText;
			this._fraMasterInformation_0.Location = new System.Drawing.Point(-657, 23);
			this._fraMasterInformation_0.Name = "_fraMasterInformation_0";
			this._fraMasterInformation_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._fraMasterInformation_0.Size = new System.Drawing.Size(596, 237);
			this._fraMasterInformation_0.TabIndex = 31;
			this._fraMasterInformation_0.Visible = true;
			// 
			// txtComment
			// 
			this.txtComment.AcceptsReturn = true;
			this.txtComment.AllowDrop = true;
			this.txtComment.BackColor = System.Drawing.Color.White;
			this.txtComment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtComment.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtComment.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtComment.Location = new System.Drawing.Point(146, 172);
			this.txtComment.MaxLength = 100;
			this.txtComment.Multiline = true;
			this.txtComment.Name = "txtComment";
			this.txtComment.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtComment.Size = new System.Drawing.Size(440, 53);
			this.txtComment.TabIndex = 5;
			// 
			// _lblCommon_4
			// 
			this._lblCommon_4.AllowDrop = true;
			this._lblCommon_4.BackColor = System.Drawing.SystemColors.Window;
			this._lblCommon_4.Text = "DB File Name";
			this._lblCommon_4.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_4.Location = new System.Drawing.Point(8, 17);
			this._lblCommon_4.Name = "_lblCommon_4";
			this._lblCommon_4.Size = new System.Drawing.Size(63, 14);
			this._lblCommon_4.TabIndex = 34;
			// 
			// _txtCommon_3
			// 
			this._txtCommon_3.AllowDrop = true;
			this._txtCommon_3.BackColor = System.Drawing.Color.White;
			this._txtCommon_3.ForeColor = System.Drawing.Color.Black;
			this._txtCommon_3.Location = new System.Drawing.Point(146, 14);
			this._txtCommon_3.MaxLength = 50;
			this._txtCommon_3.Name = "_txtCommon_3";
			this._txtCommon_3.Size = new System.Drawing.Size(140, 19);
			this._txtCommon_3.TabIndex = 3;
			this._txtCommon_3.Text = "";
			// this.this._txtCommon_3.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommon_DropButtonClick);
			// this.this._txtCommon_3.KeyPress += new System.Windows.Forms.TextBox.KeyPressHandler(this.txtCommon_KeyPress);
			// 
			// _lblCommon_5
			// 
			this._lblCommon_5.AllowDrop = true;
			this._lblCommon_5.BackColor = System.Drawing.SystemColors.Window;
			this._lblCommon_5.Text = "Comments";
			this._lblCommon_5.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_5.Location = new System.Drawing.Point(8, 172);
			this._lblCommon_5.Name = "_lblCommon_5";
			this._lblCommon_5.Size = new System.Drawing.Size(50, 14);
			this._lblCommon_5.TabIndex = 35;
			// 
			// _lblCommon_6
			// 
			this._lblCommon_6.AllowDrop = true;
			this._lblCommon_6.BackColor = System.Drawing.SystemColors.Window;
			this._lblCommon_6.Text = "Current Period Start Date";
			this._lblCommon_6.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_6.Location = new System.Drawing.Point(8, 46);
			this._lblCommon_6.Name = "_lblCommon_6";
			this._lblCommon_6.Size = new System.Drawing.Size(120, 14);
			this._lblCommon_6.TabIndex = 36;
			// 
			// _lblCommon_7
			// 
			this._lblCommon_7.AllowDrop = true;
			this._lblCommon_7.BackColor = System.Drawing.SystemColors.Window;
			this._lblCommon_7.Text = "Current Period End Date";
			this._lblCommon_7.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_7.Location = new System.Drawing.Point(8, 67);
			this._lblCommon_7.Name = "_lblCommon_7";
			this._lblCommon_7.Size = new System.Drawing.Size(115, 14);
			this._lblCommon_7.TabIndex = 37;
			// 
			// _lblCommon_8
			// 
			this._lblCommon_8.AllowDrop = true;
			this._lblCommon_8.BackColor = System.Drawing.SystemColors.Window;
			this._lblCommon_8.Text = "Next Period Start Date";
			this._lblCommon_8.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_8.Location = new System.Drawing.Point(356, 45);
			this._lblCommon_8.Name = "_lblCommon_8";
			this._lblCommon_8.Size = new System.Drawing.Size(106, 14);
			this._lblCommon_8.TabIndex = 38;
			// 
			// _lblCommon_9
			// 
			this._lblCommon_9.AllowDrop = true;
			this._lblCommon_9.BackColor = System.Drawing.SystemColors.Window;
			this._lblCommon_9.Text = "Next Period End Date";
			this._lblCommon_9.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_9.Location = new System.Drawing.Point(356, 66);
			this._lblCommon_9.Name = "_lblCommon_9";
			this._lblCommon_9.Size = new System.Drawing.Size(101, 14);
			this._lblCommon_9.TabIndex = 39;
			// 
			// _txtCommonDate_0
			// 
			this._txtCommonDate_0.AllowDrop = true;
			// this._txtCommonDate_0.CheckDateRange = false;
			this._txtCommonDate_0.Location = new System.Drawing.Point(146, 43);
			// this._txtCommonDate_0.MaxDate = 2958465;
			// this._txtCommonDate_0.MinDate = 32874;
			this._txtCommonDate_0.Name = "_txtCommonDate_0";
			this._txtCommonDate_0.Size = new System.Drawing.Size(102, 19);
			this._txtCommonDate_0.TabIndex = 4;
			this._txtCommonDate_0.Text = "7/18/2001";
			this._txtCommonDate_0.Value = 37090;
			// this.this._txtCommonDate_0.Change += new Syncfusion.WinForms.Input.SfDateTimeEdit.ChangeHandler(this.txtCommonDate_Change);
			// 
			// _txtCommonDate_1
			// 
			this._txtCommonDate_1.AllowDrop = true;
			this._txtCommonDate_1.BackColor = System.Drawing.Color.FromArgb(239, 239, 239);
			// this._txtCommonDate_1.CheckDateRange = false;
			this._txtCommonDate_1.Enabled = false;
			this._txtCommonDate_1.Location = new System.Drawing.Point(146, 64);
			// this._txtCommonDate_1.MaxDate = 2958465;
			// this._txtCommonDate_1.MinDate = 32874;
			this._txtCommonDate_1.Name = "_txtCommonDate_1";
			this._txtCommonDate_1.Size = new System.Drawing.Size(102, 19);
			this._txtCommonDate_1.TabIndex = 21;
			this._txtCommonDate_1.Text = "7/18/2001";
			this._txtCommonDate_1.Value = 37090;
			// this.this._txtCommonDate_1.Change += new Syncfusion.WinForms.Input.SfDateTimeEdit.ChangeHandler(this.txtCommonDate_Change);
			// 
			// _txtCommonDate_2
			// 
			this._txtCommonDate_2.AllowDrop = true;
			this._txtCommonDate_2.BackColor = System.Drawing.Color.FromArgb(239, 239, 239);
			// this._txtCommonDate_2.CheckDateRange = false;
			this._txtCommonDate_2.Enabled = false;
			this._txtCommonDate_2.Location = new System.Drawing.Point(484, 43);
			// this._txtCommonDate_2.MaxDate = 2958465;
			// this._txtCommonDate_2.MinDate = 32874;
			this._txtCommonDate_2.Name = "_txtCommonDate_2";
			this._txtCommonDate_2.Size = new System.Drawing.Size(102, 19);
			this._txtCommonDate_2.TabIndex = 22;
			this._txtCommonDate_2.Text = "7/18/2001";
			this._txtCommonDate_2.Value = 37090;
			// this.this._txtCommonDate_2.Change += new Syncfusion.WinForms.Input.SfDateTimeEdit.ChangeHandler(this.txtCommonDate_Change);
			// 
			// _txtCommonDate_3
			// 
			this._txtCommonDate_3.AllowDrop = true;
			this._txtCommonDate_3.BackColor = System.Drawing.Color.FromArgb(239, 239, 239);
			// this._txtCommonDate_3.CheckDateRange = false;
			this._txtCommonDate_3.Enabled = false;
			this._txtCommonDate_3.Location = new System.Drawing.Point(484, 64);
			// this._txtCommonDate_3.MaxDate = 2958465;
			// this._txtCommonDate_3.MinDate = 32874;
			this._txtCommonDate_3.Name = "_txtCommonDate_3";
			this._txtCommonDate_3.Size = new System.Drawing.Size(102, 19);
			this._txtCommonDate_3.TabIndex = 23;
			this._txtCommonDate_3.Text = "7/18/2001";
			this._txtCommonDate_3.Value = 37090;
			// this.this._txtCommonDate_3.Change += new Syncfusion.WinForms.Input.SfDateTimeEdit.ChangeHandler(this.txtCommonDate_Change);
			// 
			// _lblCommon_12
			// 
			this._lblCommon_12.AllowDrop = true;
			this._lblCommon_12.BackColor = System.Drawing.SystemColors.Window;
			this._lblCommon_12.Text = "Last Backup Date";
			this._lblCommon_12.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_12.Location = new System.Drawing.Point(356, 154);
			this._lblCommon_12.Name = "_lblCommon_12";
			this._lblCommon_12.Size = new System.Drawing.Size(85, 14);
			this._lblCommon_12.TabIndex = 42;
			// 
			// _txtCommonDate_4
			// 
			this._txtCommonDate_4.AllowDrop = true;
			this._txtCommonDate_4.BackColor = System.Drawing.Color.FromArgb(239, 239, 239);
			// this._txtCommonDate_4.CheckDateRange = false;
			this._txtCommonDate_4.Enabled = false;
			this._txtCommonDate_4.Location = new System.Drawing.Point(484, 150);
			// this._txtCommonDate_4.MaxDate = 2958465;
			// this._txtCommonDate_4.MinDate = 32874;
			this._txtCommonDate_4.Name = "_txtCommonDate_4";
			this._txtCommonDate_4.Size = new System.Drawing.Size(102, 19);
			this._txtCommonDate_4.TabIndex = 24;
			this._txtCommonDate_4.Text = "7/18/2001";
			this._txtCommonDate_4.Value = 37090;
			// this.this._txtCommonDate_4.Change += new Syncfusion.WinForms.Input.SfDateTimeEdit.ChangeHandler(this.txtCommonDate_Change);
			// 
			// _txtCommon_1
			// 
			this._txtCommon_1.AllowDrop = true;
			this._txtCommon_1.BackColor = System.Drawing.Color.White;
			this._txtCommon_1.ForeColor = System.Drawing.Color.Black;
			this._txtCommon_1.Location = new System.Drawing.Point(376, 16);
			this._txtCommon_1.MaxLength = 50;
			this._txtCommon_1.Name = "_txtCommon_1";
			this._txtCommon_1.Size = new System.Drawing.Size(201, 19);
			this._txtCommon_1.TabIndex = 1;
			this._txtCommon_1.Text = "";
			// this.this._txtCommon_1.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommon_DropButtonClick);
			// this.this._txtCommon_1.KeyPress += new System.Windows.Forms.TextBox.KeyPressHandler(this.txtCommon_KeyPress);
			// 
			// _txtCommon_2
			// 
			this._txtCommon_2.AllowDrop = true;
			this._txtCommon_2.BackColor = System.Drawing.Color.White;
			this._txtCommon_2.ForeColor = System.Drawing.Color.Black;
			this._txtCommon_2.Location = new System.Drawing.Point(376, 37);
			// this._txtCommon_2.mArabicEnabled = true;
			this._txtCommon_2.MaxLength = 50;
			this._txtCommon_2.Name = "_txtCommon_2";
			this._txtCommon_2.Size = new System.Drawing.Size(201, 19);
			this._txtCommon_2.TabIndex = 2;
			this._txtCommon_2.Text = "";
			// this.this._txtCommon_2.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommon_DropButtonClick);
			// this.this._txtCommon_2.KeyPress += new System.Windows.Forms.TextBox.KeyPressHandler(this.txtCommon_KeyPress);
			// 
			// _lblCommon_0
			// 
			this._lblCommon_0.AllowDrop = true;
			this._lblCommon_0.BackColor = System.Drawing.SystemColors.Window;
			this._lblCommon_0.Text = "Comapny Code";
			this._lblCommon_0.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_0.Location = new System.Drawing.Point(8, 19);
			this._lblCommon_0.Name = "_lblCommon_0";
			this._lblCommon_0.Size = new System.Drawing.Size(73, 14);
			this._lblCommon_0.TabIndex = 27;
			// 
			// _txtCommon_0
			// 
			this._txtCommon_0.AllowDrop = true;
			this._txtCommon_0.BackColor = System.Drawing.Color.White;
			// this._txtCommon_0.bolAllowDecimal = false;
			// this._txtCommon_0.bolNumericOnly = true;
			this._txtCommon_0.ForeColor = System.Drawing.Color.Black;
			this._txtCommon_0.Location = new System.Drawing.Point(98, 16);
			this._txtCommon_0.MaxLength = 4;
			// this._txtCommon_0.mDropDownType = System.Windows.Forms.TextBox.DropDownTypes.ddtNextNumber;
			this._txtCommon_0.Name = "_txtCommon_0";
			// this._txtCommon_0.ShowButton = true;
			this._txtCommon_0.Size = new System.Drawing.Size(101, 19);
			this._txtCommon_0.TabIndex = 0;
			this._txtCommon_0.Text = "";
			// this.this._txtCommon_0.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommon_DropButtonClick);
			// this.this._txtCommon_0.KeyPress += new System.Windows.Forms.TextBox.KeyPressHandler(this.txtCommon_KeyPress);
			// 
			// _lblCommon_1
			// 
			this._lblCommon_1.AllowDrop = true;
			this._lblCommon_1.BackColor = System.Drawing.SystemColors.Window;
			this._lblCommon_1.Text = "Comapny Name (English)";
			this._lblCommon_1.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_1.Location = new System.Drawing.Point(238, 19);
			this._lblCommon_1.Name = "_lblCommon_1";
			this._lblCommon_1.Size = new System.Drawing.Size(120, 14);
			this._lblCommon_1.TabIndex = 28;
			// 
			// _lblCommon_2
			// 
			this._lblCommon_2.AllowDrop = true;
			this._lblCommon_2.BackColor = System.Drawing.SystemColors.Window;
			this._lblCommon_2.Text = "Comapny Name (Arabic)";
			this._lblCommon_2.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_2.Location = new System.Drawing.Point(238, 40);
			this._lblCommon_2.Name = "_lblCommon_2";
			this._lblCommon_2.Size = new System.Drawing.Size(118, 14);
			this._lblCommon_2.TabIndex = 29;
			// 
			// _lblCommon_3
			// 
			this._lblCommon_3.AllowDrop = true;
			this._lblCommon_3.BackColor = System.Drawing.SystemColors.Window;
			this._lblCommon_3.Text = " Comapny Information ";
			this._lblCommon_3.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_3.Location = new System.Drawing.Point(32, 68);
			this._lblCommon_3.Name = "_lblCommon_3";
			this._lblCommon_3.Size = new System.Drawing.Size(125, 14);
			this._lblCommon_3.TabIndex = 30;
			// 
			// Line1
			// 
			this.Line1.AllowDrop = true;
			this.Line1.BackColor = System.Drawing.SystemColors.WindowText;
			this.Line1.Enabled = false;
			this.Line1.Location = new System.Drawing.Point(0, 76);
			this.Line1.Name = "Line1";
			this.Line1.Size = new System.Drawing.Size(736, 1);
			this.Line1.Visible = true;
			// 
			// tcbSystemForm
			// 
			this.tcbSystemForm.AllowDrop = true;
			this.tcbSystemForm.Location = new System.Drawing.Point(206, 7);
			this.tcbSystemForm.Name = "tcbSystemForm";
			("tcbSystemForm.OcxState");
			// 
			// frmSysCompany
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.FromArgb(165, 165, 165);
			this.ClientSize = new System.Drawing.Size(607, 400);
			this.Controls.Add(this.cntOuterFrame);
			this.Controls.Add(this.tcbSystemForm);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			//this.Icon = (System.Drawing.Icon) resources.GetObject("frmSysCompany.Icon");
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(121, 71);
			this.MaximizeBox = false;
			this.MinimizeBox = true;
			this.Name = "frmSysCompany";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Maintain Company";
			// this.Activated += new System.EventHandler(this.Form_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
			// this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
			//((System.ComponentModel.ISupportInitialize) this.tabMaster).EndInit();
			//((System.ComponentModel.ISupportInitialize) this.cntOuterFrame).EndInit();
			//((System.ComponentModel.ISupportInitialize) this.tcbSystemForm).EndInit();
			this.cntOuterFrame.ResumeLayout(false);
			this.tabMaster.ResumeLayout(false);
			this._fraMasterInformation_2.ResumeLayout(false);
			this.fraInitialCompanyLevelPreferences.ResumeLayout(false);
			this._fraMasterInformation_1.ResumeLayout(false);
			this._fraMasterInformation_0.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		void ReLoadForm(bool addEvents)
		{
			InitializetxtCommonDate();
			InitializetxtCommon();
			InitializeoptPreferenceSettings();
			InitializelblCommon();
			InitializefraMasterInformation();
			InitializecmbCommon();
			InitializechkCommon();
			//This form is an MDI child.
			//This code simulates the VB6 
			// functionality of automatically
			// loading and showing an MDI
			// child's parent.
			this.MdiParent = Xtreme.frmSysMain.DefInstance;
			Xtreme.frmSysMain.DefInstance.Show();
		}
		void InitializetxtCommonDate()
		{
			this.txtCommonDate = new Syncfusion.WinForms.Input.SfDateTimeEdit[5];
			this.txtCommonDate[0] = _txtCommonDate_0;
			this.txtCommonDate[1] = _txtCommonDate_1;
			this.txtCommonDate[2] = _txtCommonDate_2;
			this.txtCommonDate[3] = _txtCommonDate_3;
			this.txtCommonDate[4] = _txtCommonDate_4;
		}
		void InitializetxtCommon()
		{
			this.txtCommon = new System.Windows.Forms.TextBox[8];
			this.txtCommon[6] = _txtCommon_6;
			this.txtCommon[7] = _txtCommon_7;
			this.txtCommon[4] = _txtCommon_4;
			this.txtCommon[5] = _txtCommon_5;
			this.txtCommon[3] = _txtCommon_3;
			this.txtCommon[1] = _txtCommon_1;
			this.txtCommon[2] = _txtCommon_2;
			this.txtCommon[0] = _txtCommon_0;
		}
		void InitializeoptPreferenceSettings()
		{
			this.optPreferenceSettings = new System.Windows.Forms.RadioButton[2];
			this.optPreferenceSettings[1] = _optPreferenceSettings_1;
			this.optPreferenceSettings[0] = _optPreferenceSettings_0;
		}
		void InitializelblCommon()
		{
			this.lblCommon = new System.Windows.Forms.Label[18];
			this.lblCommon[17] = _lblCommon_17;
			this.lblCommon[14] = _lblCommon_14;
			this.lblCommon[15] = _lblCommon_15;
			this.lblCommon[13] = _lblCommon_13;
			this.lblCommon[16] = _lblCommon_16;
			this.lblCommon[10] = _lblCommon_10;
			this.lblCommon[11] = _lblCommon_11;
			this.lblCommon[4] = _lblCommon_4;
			this.lblCommon[5] = _lblCommon_5;
			this.lblCommon[6] = _lblCommon_6;
			this.lblCommon[7] = _lblCommon_7;
			this.lblCommon[8] = _lblCommon_8;
			this.lblCommon[9] = _lblCommon_9;
			this.lblCommon[12] = _lblCommon_12;
			this.lblCommon[0] = _lblCommon_0;
			this.lblCommon[1] = _lblCommon_1;
			this.lblCommon[2] = _lblCommon_2;
			this.lblCommon[3] = _lblCommon_3;
		}
		void InitializefraMasterInformation()
		{
			this.fraMasterInformation = new System.Windows.Forms.Panel[3];
			this.fraMasterInformation[2] = _fraMasterInformation_2;
			this.fraMasterInformation[1] = _fraMasterInformation_1;
			this.fraMasterInformation[0] = _fraMasterInformation_0;
		}
		void InitializecmbCommon()
		{
			this.cmbCommon = new System.Windows.Forms.ComboBox[3];
			this.cmbCommon[2] = _cmbCommon_2;
			this.cmbCommon[0] = _cmbCommon_0;
			this.cmbCommon[1] = _cmbCommon_1;
		}
		void InitializechkCommon()
		{
			this.chkCommon = new System.Windows.Forms.CheckBox[6];
			this.chkCommon[5] = _chkCommon_5;
			this.chkCommon[4] = _chkCommon_4;
			this.chkCommon[3] = _chkCommon_3;
			this.chkCommon[2] = _chkCommon_2;
			this.chkCommon[1] = _chkCommon_1;
			this.chkCommon[0] = _chkCommon_0;
		}
		#endregion
	}
}