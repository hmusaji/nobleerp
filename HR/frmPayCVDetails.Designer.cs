
namespace Xtreme
{
	partial class frmPayCVDetails
	{

		#region "Upgrade Support "
		private static frmPayCVDetails m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmPayCVDetails DefInstance
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
		public static frmPayCVDetails CreateInstance()
		{
			frmPayCVDetails theInstance = new frmPayCVDetails();
			
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
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "txtComments", "chkDrivingLicence", "Column_0_grdWorkExperenceDetails", "Column_1_grdWorkExperenceDetails", "grdWorkExperenceDetails", "C1Elastic4", "Column_0_grdSkillDetails", "Column_1_grdSkillDetails", "grdSkillDetails", "C1Elastic3", "Column_0_cmbMastersList1", "Column_1_cmbMastersList1", "cmbMastersList1", "Column_0_grdQualificationDetails", "Column_1_grdQualificationDetails", "grdQualificationDetails", "C1Elastic2", "Column_0_cmbMastersList", "Column_1_cmbMastersList", "cmbMastersList", "Column_0_grdLanguageDetails", "Column_1_grdLanguageDetails", "grdLanguageDetails", "C1Elastic1", "tabCV", "_txtCommonTextBox_4", "_txtCommonTextBox_3", "_txtCommonTextBox_2", "_lblCommon_7", "_lblCommon_8", "_lblCommon_9", "_lblCommon_10", "_lblCommon_4", "_lblCommon_112", "_lblCommon_0", "_lblCommon_2", "_txtCommonTextBox_1", "_txtCommonTextBox_6", "_txtCommonTextBox_7", "_txtDisplayLabel_0", "_txtCommonTextBox_5", "_lblCommon_5", "txtEmail", "_System.Windows.Forms.Label1_1", "_cmbCommon_1", "_lblCommon_108", "_System.Windows.Forms.Label1_2", "_cmbCommon_0", "_lblCommon_23", "_txtCommonTextBox_8", "_lblCommon_1", "txtBirthDate", "_txtCommonTextBox_9", "_lblCommon_3", "_lblCommon_6", "_txtCommonTextBox_11", "_lblCommon_11", "_txtCommonTextBox_10", "_lblCommon_12", "System.Windows.Forms.Label1", "cmbCommon", "lblCommon", "txtCommonTextBox", "txtDisplayLabel"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public System.Windows.Forms.TextBox txtComments;
		public System.Windows.Forms.CheckBox chkDrivingLicence;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_0_grdWorkExperenceDetails;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_1_grdWorkExperenceDetails;
		public C1.Win.C1TrueDBGrid.C1TrueDBGrid grdWorkExperenceDetails;
		public AxC1SizerLib.AxC1Elastic C1Elastic4;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_0_grdSkillDetails;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_1_grdSkillDetails;
		public C1.Win.C1TrueDBGrid.C1TrueDBGrid grdSkillDetails;
		public AxC1SizerLib.AxC1Elastic C1Elastic3;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_0_cmbMastersList1;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_1_cmbMastersList1;
		public C1.Win.C1TrueDBGrid.C1TrueDBDropdown cmbMastersList1;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_0_grdQualificationDetails;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_1_grdQualificationDetails;
		public C1.Win.C1TrueDBGrid.C1TrueDBGrid grdQualificationDetails;
		public AxC1SizerLib.AxC1Elastic C1Elastic2;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_0_cmbMastersList;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_1_cmbMastersList;
		public C1.Win.C1TrueDBGrid.C1TrueDBDropdown cmbMastersList;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_0_grdLanguageDetails;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_1_grdLanguageDetails;
		public C1.Win.C1TrueDBGrid.C1TrueDBGrid grdLanguageDetails;
		public AxC1SizerLib.AxC1Elastic C1Elastic1;
		public AxC1SizerLib.AxC1Tab tabCV;
		private System.Windows.Forms.TextBox _txtCommonTextBox_4;
		private System.Windows.Forms.TextBox _txtCommonTextBox_3;
		private System.Windows.Forms.TextBox _txtCommonTextBox_2;
		private System.Windows.Forms.Label _lblCommon_7;
		private System.Windows.Forms.Label _lblCommon_8;
		private System.Windows.Forms.Label _lblCommon_9;
		private System.Windows.Forms.Label _lblCommon_10;
		private System.Windows.Forms.Label _lblCommon_4;
		private System.Windows.Forms.Label _lblCommon_112;
		private System.Windows.Forms.Label _lblCommon_0;
		private System.Windows.Forms.Label _lblCommon_2;
		private System.Windows.Forms.TextBox _txtCommonTextBox_1;
		private System.Windows.Forms.TextBox _txtCommonTextBox_6;
		private System.Windows.Forms.TextBox _txtCommonTextBox_7;
		private System.Windows.Forms.Label _txtDisplayLabel_0;
		private System.Windows.Forms.TextBox _txtCommonTextBox_5;
		private System.Windows.Forms.Label _lblCommon_5;
		public System.Windows.Forms.TextBox txtEmail;
		private System.Windows.Forms.Label _System.Windows.Forms.Label1_1;
		private System.Windows.Forms.ComboBox _cmbCommon_1;
		private System.Windows.Forms.Label _lblCommon_108;
		private System.Windows.Forms.Label _System.Windows.Forms.Label1_2;
		private System.Windows.Forms.ComboBox _cmbCommon_0;
		private System.Windows.Forms.Label _lblCommon_23;
		private System.Windows.Forms.TextBox _txtCommonTextBox_8;
		private System.Windows.Forms.Label _lblCommon_1;
		public Syncfusion.WinForms.Input.SfDateTimeEdit txtBirthDate;
		private System.Windows.Forms.TextBox _txtCommonTextBox_9;
		private System.Windows.Forms.Label _lblCommon_3;
		private System.Windows.Forms.Label _lblCommon_6;
		private System.Windows.Forms.TextBox _txtCommonTextBox_11;
		private System.Windows.Forms.Label _lblCommon_11;
		private System.Windows.Forms.TextBox _txtCommonTextBox_10;
		private System.Windows.Forms.Label _lblCommon_12;
		public System.Windows.Forms.Label[] System.Windows.Forms.Label1 = new System.Windows.Forms.Label[3];
		public System.Windows.Forms.ComboBox[] cmbCommon = new System.Windows.Forms.ComboBox[2];
		public System.Windows.Forms.Label[] lblCommon = new System.Windows.Forms.Label[113];
		public System.Windows.Forms.TextBox[] txtCommonTextBox = new System.Windows.Forms.TextBox[12];
		public System.Windows.Forms.Label[] txtDisplayLabel = new System.Windows.Forms.Label[1];
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPayCVDetails));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this.txtComments = new System.Windows.Forms.TextBox();
			this.chkDrivingLicence = new System.Windows.Forms.CheckBox();
			this.tabCV = new AxC1SizerLib.AxC1Tab();
			this.C1Elastic4 = new AxC1SizerLib.AxC1Elastic();
			this.grdWorkExperenceDetails = new C1.Win.C1TrueDBGrid.C1TrueDBGrid();
			this.Column_0_grdWorkExperenceDetails = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.Column_1_grdWorkExperenceDetails = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.C1Elastic3 = new AxC1SizerLib.AxC1Elastic();
			this.grdSkillDetails = new C1.Win.C1TrueDBGrid.C1TrueDBGrid();
			this.Column_0_grdSkillDetails = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.Column_1_grdSkillDetails = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.C1Elastic2 = new AxC1SizerLib.AxC1Elastic();
			this.cmbMastersList1 = new C1.Win.C1TrueDBGrid.C1TrueDBDropdown();
			this.Column_0_cmbMastersList1 = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.Column_1_cmbMastersList1 = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.grdQualificationDetails = new C1.Win.C1TrueDBGrid.C1TrueDBGrid();
			this.Column_0_grdQualificationDetails = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.Column_1_grdQualificationDetails = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.C1Elastic1 = new AxC1SizerLib.AxC1Elastic();
			this.cmbMastersList = new C1.Win.C1TrueDBGrid.C1TrueDBDropdown();
			this.Column_0_cmbMastersList = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.Column_1_cmbMastersList = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.grdLanguageDetails = new C1.Win.C1TrueDBGrid.C1TrueDBGrid();
			this.Column_0_grdLanguageDetails = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.Column_1_grdLanguageDetails = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this._txtCommonTextBox_4 = new System.Windows.Forms.TextBox();
			this._txtCommonTextBox_3 = new System.Windows.Forms.TextBox();
			this._txtCommonTextBox_2 = new System.Windows.Forms.TextBox();
			this._lblCommon_7 = new System.Windows.Forms.Label();
			this._lblCommon_8 = new System.Windows.Forms.Label();
			this._lblCommon_9 = new System.Windows.Forms.Label();
			this._lblCommon_10 = new System.Windows.Forms.Label();
			this._lblCommon_4 = new System.Windows.Forms.Label();
			this._lblCommon_112 = new System.Windows.Forms.Label();
			this._lblCommon_0 = new System.Windows.Forms.Label();
			this._lblCommon_2 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_1 = new System.Windows.Forms.TextBox();
			this._txtCommonTextBox_6 = new System.Windows.Forms.TextBox();
			this._txtCommonTextBox_7 = new System.Windows.Forms.TextBox();
			this._txtDisplayLabel_0 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_5 = new System.Windows.Forms.TextBox();
			this._lblCommon_5 = new System.Windows.Forms.Label();
			this.txtEmail = new System.Windows.Forms.TextBox();
			this._System.Windows.Forms.Label1_1 = new System.Windows.Forms.Label();
			this._cmbCommon_1 = new System.Windows.Forms.ComboBox();
			this._lblCommon_108 = new System.Windows.Forms.Label();
			this._System.Windows.Forms.Label1_2 = new System.Windows.Forms.Label();
			this._cmbCommon_0 = new System.Windows.Forms.ComboBox();
			this._lblCommon_23 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_8 = new System.Windows.Forms.TextBox();
			this._lblCommon_1 = new System.Windows.Forms.Label();
			this.txtBirthDate = new Syncfusion.WinForms.Input.SfDateTimeEdit();
			this._txtCommonTextBox_9 = new System.Windows.Forms.TextBox();
			this._lblCommon_3 = new System.Windows.Forms.Label();
			this._lblCommon_6 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_11 = new System.Windows.Forms.TextBox();
			this._lblCommon_11 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_10 = new System.Windows.Forms.TextBox();
			this._lblCommon_12 = new System.Windows.Forms.Label();
			// //((System.ComponentModel.ISupportInitialize) this.C1Elastic4).BeginInit();
			// //((System.ComponentModel.ISupportInitialize) this.C1Elastic3).BeginInit();
			// //((System.ComponentModel.ISupportInitialize) this.C1Elastic2).BeginInit();
			// //((System.ComponentModel.ISupportInitialize) this.C1Elastic1).BeginInit();
			// //((System.ComponentModel.ISupportInitialize) this.tabCV).BeginInit();
			this.tabCV.SuspendLayout();
			this.C1Elastic4.SuspendLayout();
			this.grdWorkExperenceDetails.SuspendLayout();
			this.C1Elastic3.SuspendLayout();
			this.grdSkillDetails.SuspendLayout();
			this.C1Elastic2.SuspendLayout();
			this.cmbMastersList1.SuspendLayout();
			this.grdQualificationDetails.SuspendLayout();
			this.C1Elastic1.SuspendLayout();
			this.cmbMastersList.SuspendLayout();
			this.grdLanguageDetails.SuspendLayout();
			this.SuspendLayout();
			// 
			// txtComments
			// 
			this.txtComments.AcceptsReturn = true;
			this.txtComments.AllowDrop = true;
			this.txtComments.BackColor = System.Drawing.SystemColors.Window;
			this.txtComments.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.txtComments.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtComments.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtComments.Location = new System.Drawing.Point(102, 240);
			this.txtComments.MaxLength = 0;
			this.txtComments.Multiline = true;
			this.txtComments.Name = "txtComments";
			this.txtComments.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtComments.Size = new System.Drawing.Size(515, 41);
			this.txtComments.TabIndex = 16;
			// 
			// chkDrivingLicence
			// 
			this.chkDrivingLicence.AllowDrop = true;
			this.chkDrivingLicence.Appearance = System.Windows.Forms.Appearance.Normal;
			this.chkDrivingLicence.BackColor = System.Drawing.Color.FromArgb(241, 242, 234);
			this.chkDrivingLicence.CausesValidation = true;
			this.chkDrivingLicence.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkDrivingLicence.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this.chkDrivingLicence.Enabled = true;
			this.chkDrivingLicence.ForeColor = System.Drawing.SystemColors.ControlText;
			this.chkDrivingLicence.Location = new System.Drawing.Point(102, 222);
			this.chkDrivingLicence.Name = "chkDrivingLicence";
			this.chkDrivingLicence.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.chkDrivingLicence.Size = new System.Drawing.Size(12, 13);
			this.chkDrivingLicence.TabIndex = 15;
			this.chkDrivingLicence.TabStop = true;
			this.chkDrivingLicence.Text = "";
			this.chkDrivingLicence.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkDrivingLicence.Visible = true;
			// 
			// tabCV
			// 
			this.tabCV.Align = C1SizerLib.AlignSettings.asNone;
			this.tabCV.AllowDrop = true;
			this.tabCV.Controls.Add(this.C1Elastic4);
			this.tabCV.Controls.Add(this.C1Elastic3);
			this.tabCV.Controls.Add(this.C1Elastic2);
			this.tabCV.Controls.Add(this.C1Elastic1);
			this.tabCV.Location = new System.Drawing.Point(2, 284);
			this.tabCV.Name = "tabCV";
			("tabCV.OcxState");
			this.tabCV.Size = new System.Drawing.Size(619, 239);
			this.tabCV.TabIndex = 18;
			// 
			// C1Elastic4
			// 
			this.C1Elastic4.Align = C1SizerLib.AlignSettings.asNone;
			this.C1Elastic4.AllowDrop = true;
			this.C1Elastic4.Controls.Add(this.grdWorkExperenceDetails);
			this.C1Elastic4.Location = new System.Drawing.Point(700, 24);
			this.C1Elastic4.Name = "C1Elastic4";
			("C1Elastic4.OcxState");
			this.C1Elastic4.Size = new System.Drawing.Size(617, 214);
			this.C1Elastic4.TabIndex = 31;
			this.C1Elastic4.TabStop = false;
			// 
			// grdWorkExperenceDetails
			// 
			this.grdWorkExperenceDetails.AllowDrop = true;
			this.grdWorkExperenceDetails.BackColor = System.Drawing.Color.FromArgb(212, 208, 200);
			this.grdWorkExperenceDetails.CellTipsWidth = 0;
			this.grdWorkExperenceDetails.Location = new System.Drawing.Point(0, 0);
			this.grdWorkExperenceDetails.Name = "grdWorkExperenceDetails";
			this.grdWorkExperenceDetails.RowDivider.Color = System.Drawing.Color.FromArgb(212, 208, 200);
			this.grdWorkExperenceDetails.Size = new System.Drawing.Size(613, 211);
			this.grdWorkExperenceDetails.TabIndex = 34;
			this.grdWorkExperenceDetails.Columns.Add(this.Column_0_grdWorkExperenceDetails);
			this.grdWorkExperenceDetails.Columns.Add(this.Column_1_grdWorkExperenceDetails);
			// 
			// Column_0_grdWorkExperenceDetails
			// 
			this.Column_0_grdWorkExperenceDetails.DataField = "";
			this.Column_0_grdWorkExperenceDetails.ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.Normal;
			// 
			// Column_1_grdWorkExperenceDetails
			// 
			this.Column_1_grdWorkExperenceDetails.DataField = "";
			this.Column_1_grdWorkExperenceDetails.ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.Normal;
			// 
			// C1Elastic3
			// 
			this.C1Elastic3.Align = C1SizerLib.AlignSettings.asNone;
			this.C1Elastic3.AllowDrop = true;
			this.C1Elastic3.Controls.Add(this.grdSkillDetails);
			this.C1Elastic3.Location = new System.Drawing.Point(680, 24);
			this.C1Elastic3.Name = "C1Elastic3";
			("C1Elastic3.OcxState");
			this.C1Elastic3.Size = new System.Drawing.Size(617, 214);
			this.C1Elastic3.TabIndex = 30;
			this.C1Elastic3.TabStop = false;
			// 
			// grdSkillDetails
			// 
			this.grdSkillDetails.AllowDrop = true;
			this.grdSkillDetails.BackColor = System.Drawing.Color.FromArgb(212, 208, 200);
			this.grdSkillDetails.CellTipsWidth = 0;
			this.grdSkillDetails.Location = new System.Drawing.Point(0, 0);
			this.grdSkillDetails.Name = "grdSkillDetails";
			this.grdSkillDetails.RowDivider.Color = System.Drawing.Color.FromArgb(212, 208, 200);
			this.grdSkillDetails.Size = new System.Drawing.Size(615, 211);
			this.grdSkillDetails.TabIndex = 33;
			this.grdSkillDetails.Columns.Add(this.Column_0_grdSkillDetails);
			this.grdSkillDetails.Columns.Add(this.Column_1_grdSkillDetails);
			// 
			// Column_0_grdSkillDetails
			// 
			this.Column_0_grdSkillDetails.DataField = "";
			this.Column_0_grdSkillDetails.ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.Normal;
			// 
			// Column_1_grdSkillDetails
			// 
			this.Column_1_grdSkillDetails.DataField = "";
			this.Column_1_grdSkillDetails.ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.Normal;
			// 
			// C1Elastic2
			// 
			this.C1Elastic2.Align = C1SizerLib.AlignSettings.asNone;
			this.C1Elastic2.AllowDrop = true;
			this.C1Elastic2.Controls.Add(this.cmbMastersList1);
			this.C1Elastic2.Controls.Add(this.grdQualificationDetails);
			this.C1Elastic2.Location = new System.Drawing.Point(660, 24);
			this.C1Elastic2.Name = "C1Elastic2";
			("C1Elastic2.OcxState");
			this.C1Elastic2.Size = new System.Drawing.Size(617, 214);
			this.C1Elastic2.TabIndex = 29;
			this.C1Elastic2.TabStop = false;
			// 
			// cmbMastersList1
			// 
			this.cmbMastersList1.AllowDrop = true;
			this.cmbMastersList1.ColumnHeaders = true;
			this.cmbMastersList1.Enabled = true;
			this.cmbMastersList1.Location = new System.Drawing.Point(78, 100);
			this.cmbMastersList1.Name = "cmbMastersList1";
			this.cmbMastersList1.Size = new System.Drawing.Size(53, 37);
			this.cmbMastersList1.TabIndex = 46;
			this.cmbMastersList1.Columns.Add(this.Column_0_cmbMastersList1);
			this.cmbMastersList1.Columns.Add(this.Column_1_cmbMastersList1);
			// 
			// Column_0_cmbMastersList1
			// 
			this.Column_0_cmbMastersList1.DataField = "";
			this.Column_0_cmbMastersList1.ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.Normal;
			// 
			// Column_1_cmbMastersList1
			// 
			this.Column_1_cmbMastersList1.DataField = "";
			this.Column_1_cmbMastersList1.ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.Normal;
			// 
			// grdQualificationDetails
			// 
			this.grdQualificationDetails.AllowDrop = true;
			this.grdQualificationDetails.BackColor = System.Drawing.Color.FromArgb(212, 208, 200);
			this.grdQualificationDetails.CellTipsWidth = 0;
			this.grdQualificationDetails.Location = new System.Drawing.Point(0, 0);
			this.grdQualificationDetails.Name = "grdQualificationDetails";
			this.grdQualificationDetails.RowDivider.Color = System.Drawing.Color.FromArgb(212, 208, 200);
			this.grdQualificationDetails.Size = new System.Drawing.Size(615, 211);
			this.grdQualificationDetails.TabIndex = 32;
			this.grdQualificationDetails.Columns.Add(this.Column_0_grdQualificationDetails);
			this.grdQualificationDetails.Columns.Add(this.Column_1_grdQualificationDetails);
			this.grdQualificationDetails.GotFocus += new System.EventHandler(this.grdQualificationDetails_GotFocus);
			this.grdQualificationDetails.RowColChange += new C1.Win.C1TrueDBGrid.RowColChangeEventHandler(this.grdQualificationDetails_RowColChange);
			// 
			// Column_0_grdQualificationDetails
			// 
			this.Column_0_grdQualificationDetails.DataField = "";
			this.Column_0_grdQualificationDetails.ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.Normal;
			// 
			// Column_1_grdQualificationDetails
			// 
			this.Column_1_grdQualificationDetails.DataField = "";
			this.Column_1_grdQualificationDetails.ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.Normal;
			// 
			// C1Elastic1
			// 
			this.C1Elastic1.Align = C1SizerLib.AlignSettings.asNone;
			this.C1Elastic1.AllowDrop = true;
			this.C1Elastic1.Controls.Add(this.cmbMastersList);
			this.C1Elastic1.Controls.Add(this.grdLanguageDetails);
			this.C1Elastic1.Location = new System.Drawing.Point(1, 24);
			this.C1Elastic1.Name = "C1Elastic1";
			("C1Elastic1.OcxState");
			this.C1Elastic1.Size = new System.Drawing.Size(617, 214);
			this.C1Elastic1.TabIndex = 27;
			this.C1Elastic1.TabStop = false;
			// 
			// cmbMastersList
			// 
			this.cmbMastersList.AllowDrop = true;
			this.cmbMastersList.ColumnHeaders = true;
			this.cmbMastersList.Enabled = true;
			this.cmbMastersList.Location = new System.Drawing.Point(106, 90);
			this.cmbMastersList.Name = "cmbMastersList";
			this.cmbMastersList.Size = new System.Drawing.Size(53, 37);
			this.cmbMastersList.TabIndex = 45;
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
			// grdLanguageDetails
			// 
			this.grdLanguageDetails.AllowAddNew = true;
			this.grdLanguageDetails.AllowDelete = true;
			this.grdLanguageDetails.AllowDrop = true;
			this.grdLanguageDetails.BackColor = System.Drawing.Color.FromArgb(212, 208, 200);
			this.grdLanguageDetails.CellTipsWidth = 0;
			this.grdLanguageDetails.Location = new System.Drawing.Point(0, 2);
			this.grdLanguageDetails.Name = "grdLanguageDetails";
			this.grdLanguageDetails.RowDivider.Color = System.Drawing.Color.FromArgb(212, 208, 200);
			this.grdLanguageDetails.Size = new System.Drawing.Size(615, 211);
			this.grdLanguageDetails.TabIndex = 28;
			this.grdLanguageDetails.Columns.Add(this.Column_0_grdLanguageDetails);
			this.grdLanguageDetails.Columns.Add(this.Column_1_grdLanguageDetails);
			this.grdLanguageDetails.GotFocus += new System.EventHandler(this.grdLanguageDetails_GotFocus);
			this.grdLanguageDetails.RowColChange += new C1.Win.C1TrueDBGrid.RowColChangeEventHandler(this.grdLanguageDetails_RowColChange);
			// 
			// Column_0_grdLanguageDetails
			// 
			this.Column_0_grdLanguageDetails.DataField = "";
			this.Column_0_grdLanguageDetails.ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.Normal;
			// 
			// Column_1_grdLanguageDetails
			// 
			this.Column_1_grdLanguageDetails.DataField = "";
			this.Column_1_grdLanguageDetails.ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.Normal;
			// 
			// _txtCommonTextBox_4
			// 
			this._txtCommonTextBox_4.AllowDrop = true;
			this._txtCommonTextBox_4.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_4.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_4.Location = new System.Drawing.Point(487, 64);
			this._txtCommonTextBox_4.Name = "_txtCommonTextBox_4";
			this._txtCommonTextBox_4.Size = new System.Drawing.Size(130, 19);
			this._txtCommonTextBox_4.TabIndex = 3;
			this._txtCommonTextBox_4.Text = "";
			// this.this._txtCommonTextBox_4.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_4.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _txtCommonTextBox_3
			// 
			this._txtCommonTextBox_3.AllowDrop = true;
			this._txtCommonTextBox_3.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_3.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_3.Location = new System.Drawing.Point(358, 64);
			this._txtCommonTextBox_3.Name = "_txtCommonTextBox_3";
			this._txtCommonTextBox_3.Size = new System.Drawing.Size(128, 19);
			this._txtCommonTextBox_3.TabIndex = 2;
			this._txtCommonTextBox_3.Text = "";
			// this.this._txtCommonTextBox_3.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_3.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _txtCommonTextBox_2
			// 
			this._txtCommonTextBox_2.AllowDrop = true;
			this._txtCommonTextBox_2.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_2.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_2.Location = new System.Drawing.Point(230, 64);
			this._txtCommonTextBox_2.Name = "_txtCommonTextBox_2";
			this._txtCommonTextBox_2.Size = new System.Drawing.Size(128, 19);
			this._txtCommonTextBox_2.TabIndex = 1;
			this._txtCommonTextBox_2.Text = "";
			// this.this._txtCommonTextBox_2.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_2.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _lblCommon_7
			// 
			this._lblCommon_7.AllowDrop = true;
			this._lblCommon_7.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_7.Text = "Fourth Name";
			this._lblCommon_7.Location = new System.Drawing.Point(518, 48);
			// this._lblCommon_7.mLabelId = 1975;
			this._lblCommon_7.Name = "_lblCommon_7";
			this._lblCommon_7.Size = new System.Drawing.Size(62, 13);
			this._lblCommon_7.TabIndex = 17;
			// 
			// _lblCommon_8
			// 
			this._lblCommon_8.AllowDrop = true;
			this._lblCommon_8.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_8.Text = "Third Name";
			this._lblCommon_8.Location = new System.Drawing.Point(398, 48);
			// this._lblCommon_8.mLabelId = 1977;
			this._lblCommon_8.Name = "_lblCommon_8";
			this._lblCommon_8.Size = new System.Drawing.Size(54, 13);
			this._lblCommon_8.TabIndex = 19;
			// 
			// _lblCommon_9
			// 
			this._lblCommon_9.AllowDrop = true;
			this._lblCommon_9.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_9.Text = "Second Name";
			this._lblCommon_9.Location = new System.Drawing.Point(258, 48);
			// this._lblCommon_9.mLabelId = 1976;
			this._lblCommon_9.Name = "_lblCommon_9";
			this._lblCommon_9.Size = new System.Drawing.Size(65, 13);
			this._lblCommon_9.TabIndex = 20;
			// 
			// _lblCommon_10
			// 
			this._lblCommon_10.AllowDrop = true;
			this._lblCommon_10.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_10.Text = "Name (English)";
			this._lblCommon_10.Location = new System.Drawing.Point(10, 67);
			// this._lblCommon_10.mLabelId = 1053;
			this._lblCommon_10.Name = "_lblCommon_10";
			this._lblCommon_10.Size = new System.Drawing.Size(71, 13);
			this._lblCommon_10.TabIndex = 21;
			// 
			// _lblCommon_4
			// 
			this._lblCommon_4.AllowDrop = true;
			this._lblCommon_4.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_4.Text = "First Name";
			this._lblCommon_4.Location = new System.Drawing.Point(130, 48);
			// this._lblCommon_4.mLabelId = 1974;
			this._lblCommon_4.Name = "_lblCommon_4";
			this._lblCommon_4.Size = new System.Drawing.Size(51, 13);
			this._lblCommon_4.TabIndex = 22;
			// 
			// _lblCommon_112
			// 
			this._lblCommon_112.AllowDrop = true;
			this._lblCommon_112.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_112.Text = "Nationality Code";
			this._lblCommon_112.Location = new System.Drawing.Point(10, 88);
			// this._lblCommon_112.mLabelId = 1058;
			this._lblCommon_112.Name = "_lblCommon_112";
			this._lblCommon_112.Size = new System.Drawing.Size(77, 14);
			this._lblCommon_112.TabIndex = 23;
			// 
			// _lblCommon_0
			// 
			this._lblCommon_0.AllowDrop = true;
			this._lblCommon_0.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_0.Text = "Designation";
			this._lblCommon_0.Location = new System.Drawing.Point(10, 112);
			// this._lblCommon_0.mLabelId = 2098;
			this._lblCommon_0.Name = "_lblCommon_0";
			this._lblCommon_0.Size = new System.Drawing.Size(56, 13);
			this._lblCommon_0.TabIndex = 24;
			// 
			// _lblCommon_2
			// 
			this._lblCommon_2.AllowDrop = true;
			this._lblCommon_2.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_2.Text = "Carrer Objective";
			this._lblCommon_2.Location = new System.Drawing.Point(10, 132);
			// this._lblCommon_2.mLabelId = 2099;
			this._lblCommon_2.Name = "_lblCommon_2";
			this._lblCommon_2.Size = new System.Drawing.Size(80, 13);
			this._lblCommon_2.TabIndex = 25;
			// 
			// _txtCommonTextBox_1
			// 
			this._txtCommonTextBox_1.AllowDrop = true;
			this._txtCommonTextBox_1.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_1.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_1.Location = new System.Drawing.Point(102, 64);
			this._txtCommonTextBox_1.Name = "_txtCommonTextBox_1";
			this._txtCommonTextBox_1.Size = new System.Drawing.Size(128, 19);
			this._txtCommonTextBox_1.TabIndex = 0;
			this._txtCommonTextBox_1.Text = "";
			// this.this._txtCommonTextBox_1.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_1.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _txtCommonTextBox_6
			// 
			this._txtCommonTextBox_6.AllowDrop = true;
			this._txtCommonTextBox_6.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_6.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_6.Location = new System.Drawing.Point(102, 108);
			this._txtCommonTextBox_6.Name = "_txtCommonTextBox_6";
			// this._txtCommonTextBox_6.ShowButton = true;
			this._txtCommonTextBox_6.Size = new System.Drawing.Size(516, 19);
			this._txtCommonTextBox_6.TabIndex = 5;
			this._txtCommonTextBox_6.Text = "";
			// this.this._txtCommonTextBox_6.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_6.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _txtCommonTextBox_7
			// 
			this._txtCommonTextBox_7.AllowDrop = true;
			this._txtCommonTextBox_7.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_7.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_7.Location = new System.Drawing.Point(102, 128);
			this._txtCommonTextBox_7.Name = "_txtCommonTextBox_7";
			this._txtCommonTextBox_7.Size = new System.Drawing.Size(516, 19);
			this._txtCommonTextBox_7.TabIndex = 6;
			this._txtCommonTextBox_7.Text = "";
			// this.this._txtCommonTextBox_7.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_7.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _txtDisplayLabel_0
			// 
			this._txtDisplayLabel_0.AllowDrop = true;
			this._txtDisplayLabel_0.Location = new System.Drawing.Point(186, 86);
			this._txtDisplayLabel_0.Name = "_txtDisplayLabel_0";
			this._txtDisplayLabel_0.Size = new System.Drawing.Size(209, 19);
			this._txtDisplayLabel_0.TabIndex = 26;
			this._txtDisplayLabel_0.TabStop = false;
			// 
			// _txtCommonTextBox_5
			// 
			this._txtCommonTextBox_5.AllowDrop = true;
			this._txtCommonTextBox_5.BackColor = System.Drawing.Color.White;
			// this._txtCommonTextBox_5.bolNumericOnly = true;
			this._txtCommonTextBox_5.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_5.Location = new System.Drawing.Point(102, 86);
			this._txtCommonTextBox_5.MaxLength = 8;
			this._txtCommonTextBox_5.Name = "_txtCommonTextBox_5";
			// this._txtCommonTextBox_5.ShowButton = true;
			this._txtCommonTextBox_5.Size = new System.Drawing.Size(83, 19);
			this._txtCommonTextBox_5.TabIndex = 4;
			this._txtCommonTextBox_5.Text = "";
			// this.this._txtCommonTextBox_5.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_5.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _lblCommon_5
			// 
			this._lblCommon_5.AllowDrop = true;
			this._lblCommon_5.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_5.Text = "Email";
			this._lblCommon_5.Location = new System.Drawing.Point(10, 152);
			this._lblCommon_5.Name = "_lblCommon_5";
			this._lblCommon_5.Size = new System.Drawing.Size(24, 13);
			this._lblCommon_5.TabIndex = 35;
			// 
			// txtEmail
			// 
			this.txtEmail.AllowDrop = true;
			this.txtEmail.BackColor = System.Drawing.Color.White;
			this.txtEmail.ForeColor = System.Drawing.Color.Black;
			this.txtEmail.Location = new System.Drawing.Point(103, 148);
			this.txtEmail.Name = "txtEmail";
			this.txtEmail.Size = new System.Drawing.Size(292, 19);
			this.txtEmail.TabIndex = 7;
			this.txtEmail.Text = "";
			// 
			// _System.Windows.Forms.Label1_1
			// 
			this._System.Windows.Forms.Label1_1.AllowDrop = true;
			this._System.Windows.Forms.Label1_1.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._System.Windows.Forms.Label1_1.Caption = "Sex";
			this._System.Windows.Forms.Label1_1.Location = new System.Drawing.Point(214, 196);
			this._System.Windows.Forms.Label1_1.mLabelId = 1981;
			this._System.Windows.Forms.Label1_1.Name = "_System.Windows.Forms.Label1_1";
			this._System.Windows.Forms.Label1_1.Size = new System.Drawing.Size(19, 14);
			this._System.Windows.Forms.Label1_1.TabIndex = 36;
			// 
			// _cmbCommon_1
			// 
			this._cmbCommon_1.AllowDrop = true;
			this._cmbCommon_1.Location = new System.Drawing.Point(294, 194);
			this._cmbCommon_1.Name = "_cmbCommon_1";
			this._cmbCommon_1.Size = new System.Drawing.Size(101, 21);
			this._cmbCommon_1.TabIndex = 13;
			// 
			// _lblCommon_108
			// 
			this._lblCommon_108.AllowDrop = true;
			this._lblCommon_108.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_108.Text = "Birth Date";
			this._lblCommon_108.Location = new System.Drawing.Point(434, 152);
			// this._lblCommon_108.mLabelId = 1056;
			this._lblCommon_108.Name = "_lblCommon_108";
			this._lblCommon_108.Size = new System.Drawing.Size(47, 14);
			this._lblCommon_108.TabIndex = 37;
			// 
			// _System.Windows.Forms.Label1_2
			// 
			this._System.Windows.Forms.Label1_2.AllowDrop = true;
			this._System.Windows.Forms.Label1_2.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._System.Windows.Forms.Label1_2.Caption = "Marital Status";
			this._System.Windows.Forms.Label1_2.Location = new System.Drawing.Point(10, 171);
			this._System.Windows.Forms.Label1_2.mLabelId = 1928;
			this._System.Windows.Forms.Label1_2.Name = "_System.Windows.Forms.Label1_2";
			this._System.Windows.Forms.Label1_2.Size = new System.Drawing.Size(65, 14);
			this._System.Windows.Forms.Label1_2.TabIndex = 38;
			// 
			// _cmbCommon_0
			// 
			this._cmbCommon_0.AllowDrop = true;
			this._cmbCommon_0.Location = new System.Drawing.Point(103, 170);
			this._cmbCommon_0.Name = "_cmbCommon_0";
			this._cmbCommon_0.Size = new System.Drawing.Size(98, 21);
			this._cmbCommon_0.TabIndex = 9;
			// 
			// _lblCommon_23
			// 
			this._lblCommon_23.AllowDrop = true;
			this._lblCommon_23.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_23.Text = "Telephone No";
			this._lblCommon_23.Location = new System.Drawing.Point(214, 173);
			// this._lblCommon_23.mLabelId = 1067;
			this._lblCommon_23.Name = "_lblCommon_23";
			this._lblCommon_23.Size = new System.Drawing.Size(66, 13);
			this._lblCommon_23.TabIndex = 39;
			// 
			// _txtCommonTextBox_8
			// 
			this._txtCommonTextBox_8.AllowDrop = true;
			this._txtCommonTextBox_8.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_8.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_8.Location = new System.Drawing.Point(294, 170);
			this._txtCommonTextBox_8.Name = "_txtCommonTextBox_8";
			this._txtCommonTextBox_8.Size = new System.Drawing.Size(101, 19);
			this._txtCommonTextBox_8.TabIndex = 10;
			this._txtCommonTextBox_8.Text = "";
			// this.this._txtCommonTextBox_8.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_8.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _lblCommon_1
			// 
			this._lblCommon_1.AllowDrop = true;
			this._lblCommon_1.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_1.Text = "Passport No.";
			this._lblCommon_1.Location = new System.Drawing.Point(10, 198);
			// this._lblCommon_1.mLabelId = 1550;
			this._lblCommon_1.Name = "_lblCommon_1";
			this._lblCommon_1.Size = new System.Drawing.Size(62, 13);
			this._lblCommon_1.TabIndex = 40;
			// 
			// txtBirthDate
			// 
			this.txtBirthDate.AllowDrop = true;
			// this.txtBirthDate.CheckDateRange = false;
			this.txtBirthDate.Location = new System.Drawing.Point(516, 150);
			// this.txtBirthDate.MaxDate = 2958465;
			// this.txtBirthDate.MinDate = 2;
			this.txtBirthDate.Name = "txtBirthDate";
			this.txtBirthDate.Size = new System.Drawing.Size(102, 19);
			this.txtBirthDate.TabIndex = 8;
			this.txtBirthDate.Text = "06/04/2003";
			this.txtBirthDate.Value = 37717;
			// 
			// _txtCommonTextBox_9
			// 
			this._txtCommonTextBox_9.AllowDrop = true;
			this._txtCommonTextBox_9.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_9.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_9.Location = new System.Drawing.Point(102, 194);
			this._txtCommonTextBox_9.MaxLength = 20;
			this._txtCommonTextBox_9.Name = "_txtCommonTextBox_9";
			this._txtCommonTextBox_9.Size = new System.Drawing.Size(101, 19);
			this._txtCommonTextBox_9.TabIndex = 12;
			this._txtCommonTextBox_9.Text = "";
			// this.this._txtCommonTextBox_9.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_9.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _lblCommon_3
			// 
			this._lblCommon_3.AllowDrop = true;
			this._lblCommon_3.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_3.Text = "Driving Licence";
			this._lblCommon_3.Location = new System.Drawing.Point(10, 222);
			// this._lblCommon_3.mLabelId = 2097;
			this._lblCommon_3.Name = "_lblCommon_3";
			this._lblCommon_3.Size = new System.Drawing.Size(71, 13);
			this._lblCommon_3.TabIndex = 41;
			// 
			// _lblCommon_6
			// 
			this._lblCommon_6.AllowDrop = true;
			this._lblCommon_6.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_6.Text = "Telephone No.";
			this._lblCommon_6.Location = new System.Drawing.Point(434, 175);
			// this._lblCommon_6.mLabelId = 1067;
			this._lblCommon_6.Name = "_lblCommon_6";
			this._lblCommon_6.Size = new System.Drawing.Size(70, 13);
			this._lblCommon_6.TabIndex = 42;
			// 
			// _txtCommonTextBox_11
			// 
			this._txtCommonTextBox_11.AllowDrop = true;
			this._txtCommonTextBox_11.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_11.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_11.Location = new System.Drawing.Point(516, 172);
			this._txtCommonTextBox_11.Name = "_txtCommonTextBox_11";
			this._txtCommonTextBox_11.Size = new System.Drawing.Size(102, 19);
			this._txtCommonTextBox_11.TabIndex = 11;
			this._txtCommonTextBox_11.Text = "";
			// this.this._txtCommonTextBox_11.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_11.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _lblCommon_11
			// 
			this._lblCommon_11.AllowDrop = true;
			this._lblCommon_11.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_11.Text = "Mobile No.";
			this._lblCommon_11.Location = new System.Drawing.Point(434, 197);
			// this._lblCommon_11.mLabelId = 1954;
			this._lblCommon_11.Name = "_lblCommon_11";
			this._lblCommon_11.Size = new System.Drawing.Size(50, 13);
			this._lblCommon_11.TabIndex = 43;
			// 
			// _txtCommonTextBox_10
			// 
			this._txtCommonTextBox_10.AllowDrop = true;
			this._txtCommonTextBox_10.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_10.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_10.Location = new System.Drawing.Point(516, 194);
			this._txtCommonTextBox_10.Name = "_txtCommonTextBox_10";
			this._txtCommonTextBox_10.Size = new System.Drawing.Size(102, 19);
			this._txtCommonTextBox_10.TabIndex = 14;
			this._txtCommonTextBox_10.Text = "";
			// this.this._txtCommonTextBox_10.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_10.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _lblCommon_12
			// 
			this._lblCommon_12.AllowDrop = true;
			this._lblCommon_12.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_12.Text = "Comments";
			this._lblCommon_12.Location = new System.Drawing.Point(10, 256);
			// this._lblCommon_12.mLabelId = 135;
			this._lblCommon_12.Name = "_lblCommon_12";
			this._lblCommon_12.Size = new System.Drawing.Size(50, 13);
			this._lblCommon_12.TabIndex = 44;
			// 
			// frmPayCVDetails
			// 
			this.'MaxButton = 0;
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.ClientSize = new System.Drawing.Size(621, 524);
			this.Controls.Add(this.txtComments);
			this.Controls.Add(this.chkDrivingLicence);
			this.Controls.Add(this.tabCV);
			this.Controls.Add(this._txtCommonTextBox_4);
			this.Controls.Add(this._txtCommonTextBox_3);
			this.Controls.Add(this._txtCommonTextBox_2);
			this.Controls.Add(this._lblCommon_7);
			this.Controls.Add(this._lblCommon_8);
			this.Controls.Add(this._lblCommon_9);
			this.Controls.Add(this._lblCommon_10);
			this.Controls.Add(this._lblCommon_4);
			this.Controls.Add(this._lblCommon_112);
			this.Controls.Add(this._lblCommon_0);
			this.Controls.Add(this._lblCommon_2);
			this.Controls.Add(this._txtCommonTextBox_1);
			this.Controls.Add(this._txtCommonTextBox_6);
			this.Controls.Add(this._txtCommonTextBox_7);
			this.Controls.Add(this._txtDisplayLabel_0);
			this.Controls.Add(this._txtCommonTextBox_5);
			this.Controls.Add(this._lblCommon_5);
			this.Controls.Add(this.txtEmail);
			this.Controls.Add(this._System.Windows.Forms.Label1_1);
			this.Controls.Add(this._cmbCommon_1);
			this.Controls.Add(this._lblCommon_108);
			this.Controls.Add(this._System.Windows.Forms.Label1_2);
			this.Controls.Add(this._cmbCommon_0);
			this.Controls.Add(this._lblCommon_23);
			this.Controls.Add(this._txtCommonTextBox_8);
			this.Controls.Add(this._lblCommon_1);
			this.Controls.Add(this.txtBirthDate);
			this.Controls.Add(this._txtCommonTextBox_9);
			this.Controls.Add(this._lblCommon_3);
			this.Controls.Add(this._lblCommon_6);
			this.Controls.Add(this._txtCommonTextBox_11);
			this.Controls.Add(this._lblCommon_11);
			this.Controls.Add(this._txtCommonTextBox_10);
			this.Controls.Add(this._lblCommon_12);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			//this.Icon = (System.Drawing.Icon) resources.GetObject("frmPayCVDetails.Icon");
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(129, 150);
			this.MaximizeBox = true;
			this.MinimizeBox = true;
			this.Name = "frmPayCVDetails";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "CV";
			// this.Activated += new System.EventHandler(this.frmPayCVDetails_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
			// this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
			//((System.ComponentModel.ISupportInitialize) this.C1Elastic4).EndInit();
			//((System.ComponentModel.ISupportInitialize) this.C1Elastic3).EndInit();
			//((System.ComponentModel.ISupportInitialize) this.C1Elastic2).EndInit();
			//((System.ComponentModel.ISupportInitialize) this.C1Elastic1).EndInit();
			//((System.ComponentModel.ISupportInitialize) this.tabCV).EndInit();
			this.tabCV.ResumeLayout(false);
			this.C1Elastic4.ResumeLayout(false);
			this.grdWorkExperenceDetails.ResumeLayout(false);
			this.C1Elastic3.ResumeLayout(false);
			this.grdSkillDetails.ResumeLayout(false);
			this.C1Elastic2.ResumeLayout(false);
			this.cmbMastersList1.ResumeLayout(false);
			this.grdQualificationDetails.ResumeLayout(false);
			this.C1Elastic1.ResumeLayout(false);
			this.cmbMastersList.ResumeLayout(false);
			this.grdLanguageDetails.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		void ReLoadForm(bool addEvents)
		{
			InitializetxtDisplayLabel();
			InitializetxtCommonTextBox();
			InitializelblCommon();
			InitializecmbCommon();
			InitializeSystem.Windows.Forms.Label1();
			//This form is an MDI child.
			//This code simulates the VB6 
			// functionality of automatically
			// loading and showing an MDI
			// child's parent.
			this.MdiParent = Xtreme.frmSysMain.DefInstance;
			Xtreme.frmSysMain.DefInstance.Show();
		}
		void InitializetxtDisplayLabel()
		{
			this.txtDisplayLabel = new System.Windows.Forms.Label[1];
			this.txtDisplayLabel[0] = _txtDisplayLabel_0;
		}
		void InitializetxtCommonTextBox()
		{
			this.txtCommonTextBox = new System.Windows.Forms.TextBox[12];
			this.txtCommonTextBox[4] = _txtCommonTextBox_4;
			this.txtCommonTextBox[3] = _txtCommonTextBox_3;
			this.txtCommonTextBox[2] = _txtCommonTextBox_2;
			this.txtCommonTextBox[1] = _txtCommonTextBox_1;
			this.txtCommonTextBox[6] = _txtCommonTextBox_6;
			this.txtCommonTextBox[7] = _txtCommonTextBox_7;
			this.txtCommonTextBox[5] = _txtCommonTextBox_5;
			this.txtCommonTextBox[8] = _txtCommonTextBox_8;
			this.txtCommonTextBox[9] = _txtCommonTextBox_9;
			this.txtCommonTextBox[11] = _txtCommonTextBox_11;
			this.txtCommonTextBox[10] = _txtCommonTextBox_10;
		}
		void InitializelblCommon()
		{
			this.lblCommon = new System.Windows.Forms.Label[113];
			this.lblCommon[7] = _lblCommon_7;
			this.lblCommon[8] = _lblCommon_8;
			this.lblCommon[9] = _lblCommon_9;
			this.lblCommon[10] = _lblCommon_10;
			this.lblCommon[4] = _lblCommon_4;
			this.lblCommon[112] = _lblCommon_112;
			this.lblCommon[0] = _lblCommon_0;
			this.lblCommon[2] = _lblCommon_2;
			this.lblCommon[5] = _lblCommon_5;
			this.lblCommon[108] = _lblCommon_108;
			this.lblCommon[23] = _lblCommon_23;
			this.lblCommon[1] = _lblCommon_1;
			this.lblCommon[3] = _lblCommon_3;
			this.lblCommon[6] = _lblCommon_6;
			this.lblCommon[11] = _lblCommon_11;
			this.lblCommon[12] = _lblCommon_12;
		}
		void InitializecmbCommon()
		{
			this.cmbCommon = new System.Windows.Forms.ComboBox[2];
			this.cmbCommon[1] = _cmbCommon_1;
			this.cmbCommon[0] = _cmbCommon_0;
		}
		void InitializeSystem.Windows.Forms.Label1()
		{
			this.System.Windows.Forms.Label1 = new System.Windows.Forms.Label[3];
			this.System.Windows.Forms.Label1[1] = _System.Windows.Forms.Label1_1;
			this.System.Windows.Forms.Label1[2] = _System.Windows.Forms.Label1_2;
		}
		#endregion
	}
}