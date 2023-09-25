
namespace Xtreme
{
	partial class frmPayEmployee
	{

		#region "Upgrade Support "
		private static frmPayEmployee m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmPayEmployee DefInstance
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
		public static frmPayEmployee CreateInstance()
		{
			frmPayEmployee theInstance = new frmPayEmployee();
			
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
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "_lblCommon_47", "_lblCommon_48", "_txtCommonTextBox_31", "System.Windows.Forms.Label3", "_txtCommonTextBox_57", "System.Windows.Forms.Label2", "_lblCommon_1", "_txtCommonTextBox_29", "_lblCommon_3", "_lblCommon_5", "_txtCommonTextBox_26", "_lblCommon_11", "_txtCommonTextBox_25", "_lblCommon_12", "_txtCommonTextBox_22", "_lblCommon_13", "_txtCommonTextBox_24", "_lblCommon_14", "_lblCommon_15", "_txtCommonTextBox_21", "_lblCommon_16", "_lblCommon_17", "_txtCommonTextBox_19", "_lblCommon_18", "_txtCommonTextBox_18", "_lblCommon_19", "_txtCommonTextBox_17", "_lblCommon_20", "_lblCommon_21", "_lblCommon_22", "_lblCommon_24", "_txtCommonTextBox_34", "_lblCommon_25", "_txtCommonTextBox_33", "_lblCommon_26", "_txtCommonTextBox_32", "_txtCommonTextBox_35", "_lblCommon_36", "_txtCommonTextBox_37", "_lblCommon_65", "_lblCommon_66", "_lblCommon_67", "_lblCommon_69", "_lblCommon_71", "_lblCommon_72", "_txtCommonTextBox_65", "_txtCommonTextBox_66", "_txtCommonTextBox_67", "_txtCommonTextBox_68", "_txtCommonTextBox_69", "_lblCommon_2", "_txtCommonTextBox_28", "_txtCommonTextBox_27", "_txtCommonTextBox_23", "_txtCommonTextBox_20", "_txtCommonTextBox_16", "_txtCommonTextBox_30", "Shape3", "Shape1", "Shape2", "_fraEmployeeInformation_1", "TabControlPage4", "_lblCommon_40", "_txtCommonTextBox_51", "_txtDisplayLabel_9", "_lblCommon_39", "_txtCommonTextBox_50", "_lblCommon_30", "_txtCommonTextBox_38", "_lblCommon_0", "_txtCommonTextBox_14", "_lblCommon_38", "_txtCommonTextBox_49", "frmRasidence", "System.Windows.Forms.Label5", "txtLoginID", "System.Windows.Forms.Label4", "txtDlblDefaultProject", "txtDefaultProject", "_lblCommon_27", "_txtCommonTextBox_40", "_lblCommon_28", "_txtCommonTextBox_41", "_lblCommon_29", "_txtCommonTextBox_42", "_lblCommon_31", "_txtCommonTextBox_43", "_lblCommon_32", "_lblCommon_115", "_lblCommon_33", "_txtCommonTextBox_46", "_lblCommon_34", "_txtCommonTextBox_47", "_lblCommon_35", "_txtCommonTextBox_48", "_txtCommonTextBox_44", "_txtCommonTextBox_45", "_txtDisplayLabel_15", "_txtCommonTextBox_54", "_txtCommonTextBox_55", "_lblCommon_44", "_lblCommon_45", "_txtCommonTextBox_53", "_lblCommon_43", "lblDefaultProject", "_lblCommon_60", "_lblCommon_61", "_lblCommon_62", "_lblCommon_63", "_txtCommonTextBox_60", "_txtCommonTextBox_61", "_lblCommon_64", "_txtCommonTextBox_62", "_txtCommonTextBox_63", "_txtCommonTextBox_64", "_fraEmployeeInformation_2", "TabControlPage3", "chkAllowTicket", "txtTicketAccrualStartDate", "_lblCommon_23", "_lblCommon_54", "_txtCommonTextBox_71", "_lblCommon_68", "_txtCommonTextBox_73", "_lblCommon_70", "_txtDisplayLabel_11", "_txtDisplayLabel_12", "_lblCommonLabel_12", "_txtDisplayLabel_13", "_fraEmployeeInformation_3", "TabControlPage2", "_txtCommonTextBox_72", "_lblCommon_74", "_txtDisplayLabel_18", "_fraEmployeeInformation_4", "TabControlPage1", "cmdPullGradeSetting", "txtNoticePeriod", "txtContractPeriod", "_txtCommonTextBox_9", "_lblCommon_116", "_txtCommonTextBox_10", "_lblCommon_105", "_txtCommonTextBox_11", "_lblCommon_114", "_txtCommonTextBox_12", "_lblCommon_104", "_lblCommon_108", "txtBirthDate", "_lblCommon_109", "txtJoiningDate", "_txtCommonTextBox_13", "_lblCommon_112", "_txtCommonTextBox_15", "_lblCommon_103", "Label1_1", "_cmbCommon_3", "Label1_3", "_cmbCommon_1", "_cmbCommon_2", "System.Windows.Forms.Label12", "_txtCommonTextBox_36", "_txtDisplayLabel_1", "_txtDisplayLabel_2", "_txtDisplayLabel_3", "_txtDisplayLabel_4", "_txtDisplayLabel_8", "_txtDisplayLabel_5", "_lblCommon_37", "_txtDisplayLabel_6", "txtProbationEndDate", "_txtDisplayLabel_7", "_txtCommonTextBox_39", "_txtCommonTextBox_52", "_txtDisplayLabel_10", "_txtCommonTextBox_56", "txtDeductionHrs", "_lblCommon_55", "txtContractStratDate", "txtContractEndDate", "_txtDisplayLabel_14", "_txtDisplayLabel_16", "_lblCommon_56", "_lblCommon_57", "_txtCommonTextBox_70", "_lblCommon_73", "_txtDisplayLabel_17", "txtDSeveranceDate", "_lblCommon_42", "_lblCommon_111", "_lblCommonLabel_0", "Label1_2", "_lblCommon_41", "_lblCommon_49", "lblDeductionHrs", "Label1_4", "Label1_5", "lblNoticePeriod", "_fraEmployeeInformation_0", "tabEmployee", "CommonDialog1Open", "CommonDialog1", "_cmbCommon_0", "_lblCommon_113", "_txtCommonTextBox_0", "Label1_0", "_lblCommon_102", "_lblCommon_6", "_txtCommonTextBox_8", "_txtCommonTextBox_7", "_txtCommonTextBox_6", "_txtCommonTextBox_5", "_txtCommonTextBox_4", "_txtCommonTextBox_3", "_txtCommonTextBox_2", "_lblCommon_7", "_lblCommon_8", "_lblCommon_9", "_lblCommon_10", "_lblCommon_4", "_txtCommonTextBox_1", "_txtDisplayLabel_0", "_lblCommon_46", "_lblCommon_50", "_lblCommon_51", "_lblCommon_52", "_lblCommon_53", "_txtCommonTextBox_58", "_txtCommonTextBox_59", "_lblCommon_58", "_lblCommon_59", "imgPicture", "Image1", "System.Windows.Forms.Label1", "cmbCommon", "fraEmployeeInformation", "lblCommon", "lblCommonLabel", "txtCommonTextBox", "txtDisplayLabel"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		private System.Windows.Forms.Label _lblCommon_47;
		private System.Windows.Forms.Label _lblCommon_48;
		private System.Windows.Forms.TextBox _txtCommonTextBox_31;
		public System.Windows.Forms.LabelLabel3;
		private System.Windows.Forms.TextBox _txtCommonTextBox_57;
		public System.Windows.Forms.LabelLabel2;
		private System.Windows.Forms.Label _lblCommon_1;
		private System.Windows.Forms.TextBox _txtCommonTextBox_29;
		private System.Windows.Forms.Label _lblCommon_3;
		private System.Windows.Forms.Label _lblCommon_5;
		private System.Windows.Forms.TextBox _txtCommonTextBox_26;
		private System.Windows.Forms.Label _lblCommon_11;
		private System.Windows.Forms.TextBox _txtCommonTextBox_25;
		private System.Windows.Forms.Label _lblCommon_12;
		private System.Windows.Forms.TextBox _txtCommonTextBox_22;
		private System.Windows.Forms.Label _lblCommon_13;
		private System.Windows.Forms.TextBox _txtCommonTextBox_24;
		private System.Windows.Forms.Label _lblCommon_14;
		private System.Windows.Forms.Label _lblCommon_15;
		private System.Windows.Forms.TextBox _txtCommonTextBox_21;
		private System.Windows.Forms.Label _lblCommon_16;
		private System.Windows.Forms.Label _lblCommon_17;
		private System.Windows.Forms.TextBox _txtCommonTextBox_19;
		private System.Windows.Forms.Label _lblCommon_18;
		private System.Windows.Forms.TextBox _txtCommonTextBox_18;
		private System.Windows.Forms.Label _lblCommon_19;
		private System.Windows.Forms.TextBox _txtCommonTextBox_17;
		private System.Windows.Forms.Label _lblCommon_20;
		private System.Windows.Forms.Label _lblCommon_21;
		private System.Windows.Forms.Label _lblCommon_22;
		private System.Windows.Forms.Label _lblCommon_24;
		private System.Windows.Forms.TextBox _txtCommonTextBox_34;
		private System.Windows.Forms.Label _lblCommon_25;
		private System.Windows.Forms.TextBox _txtCommonTextBox_33;
		private System.Windows.Forms.Label _lblCommon_26;
		private System.Windows.Forms.TextBox _txtCommonTextBox_32;
		private System.Windows.Forms.TextBox _txtCommonTextBox_35;
		private System.Windows.Forms.Label _lblCommon_36;
		private System.Windows.Forms.TextBox _txtCommonTextBox_37;
		private System.Windows.Forms.Label _lblCommon_65;
		private System.Windows.Forms.Label _lblCommon_66;
		private System.Windows.Forms.Label _lblCommon_67;
		private System.Windows.Forms.Label _lblCommon_69;
		private System.Windows.Forms.Label _lblCommon_71;
		private System.Windows.Forms.Label _lblCommon_72;
		private System.Windows.Forms.TextBox _txtCommonTextBox_65;
		private System.Windows.Forms.TextBox _txtCommonTextBox_66;
		private System.Windows.Forms.TextBox _txtCommonTextBox_67;
		private System.Windows.Forms.TextBox _txtCommonTextBox_68;
		private System.Windows.Forms.TextBox _txtCommonTextBox_69;
		private System.Windows.Forms.Label _lblCommon_2;
		private System.Windows.Forms.TextBox _txtCommonTextBox_28;
		private System.Windows.Forms.TextBox _txtCommonTextBox_27;
		private System.Windows.Forms.TextBox _txtCommonTextBox_23;
		private System.Windows.Forms.TextBox _txtCommonTextBox_20;
		private System.Windows.Forms.TextBox _txtCommonTextBox_16;
		private System.Windows.Forms.TextBox _txtCommonTextBox_30;
		public UpgradeHelpers.Gui.ShapeHelper Shape3;
		public UpgradeHelpers.Gui.ShapeHelper Shape1;
		public UpgradeHelpers.Gui.ShapeHelper Shape2;
		private AxXtremeSuiteControls.AxTabControlPage _fraEmployeeInformation_1;
		public AxXtremeSuiteControls.AxTabControlPage TabControlPage4;
		private System.Windows.Forms.Label _lblCommon_40;
		private System.Windows.Forms.TextBox _txtCommonTextBox_51;
		private System.Windows.Forms.Label _txtDisplayLabel_9;
		private System.Windows.Forms.Label _lblCommon_39;
		private System.Windows.Forms.TextBox _txtCommonTextBox_50;
		private System.Windows.Forms.Label _lblCommon_30;
		private System.Windows.Forms.TextBox _txtCommonTextBox_38;
		private System.Windows.Forms.Label _lblCommon_0;
		private System.Windows.Forms.TextBox _txtCommonTextBox_14;
		private System.Windows.Forms.Label _lblCommon_38;
		private System.Windows.Forms.TextBox _txtCommonTextBox_49;
		public System.Windows.Forms.GroupBox frmRasidence;
		public System.Windows.Forms.LabelLabel5;
		public System.Windows.Forms.TextBox txtLoginID;
		public System.Windows.Forms.LabelLabel4;
		public System.Windows.Forms.Label txtDlblDefaultProject;
		public System.Windows.Forms.TextBox txtDefaultProject;
		private System.Windows.Forms.Label _lblCommon_27;
		private System.Windows.Forms.TextBox _txtCommonTextBox_40;
		private System.Windows.Forms.Label _lblCommon_28;
		private System.Windows.Forms.TextBox _txtCommonTextBox_41;
		private System.Windows.Forms.Label _lblCommon_29;
		private System.Windows.Forms.TextBox _txtCommonTextBox_42;
		private System.Windows.Forms.Label _lblCommon_31;
		private System.Windows.Forms.TextBox _txtCommonTextBox_43;
		private System.Windows.Forms.Label _lblCommon_32;
		private System.Windows.Forms.Label _lblCommon_115;
		private System.Windows.Forms.Label _lblCommon_33;
		private System.Windows.Forms.TextBox _txtCommonTextBox_46;
		private System.Windows.Forms.Label _lblCommon_34;
		private System.Windows.Forms.TextBox _txtCommonTextBox_47;
		private System.Windows.Forms.Label _lblCommon_35;
		private System.Windows.Forms.TextBox _txtCommonTextBox_48;
		private System.Windows.Forms.TextBox _txtCommonTextBox_44;
		private System.Windows.Forms.TextBox _txtCommonTextBox_45;
		private System.Windows.Forms.Label _txtDisplayLabel_15;
		private System.Windows.Forms.TextBox _txtCommonTextBox_54;
		private System.Windows.Forms.TextBox _txtCommonTextBox_55;
		private System.Windows.Forms.Label _lblCommon_44;
		private System.Windows.Forms.Label _lblCommon_45;
		private System.Windows.Forms.TextBox _txtCommonTextBox_53;
		private System.Windows.Forms.Label _lblCommon_43;
		public System.Windows.Forms.Label lblDefaultProject;
		private System.Windows.Forms.Label _lblCommon_60;
		private System.Windows.Forms.Label _lblCommon_61;
		private System.Windows.Forms.Label _lblCommon_62;
		private System.Windows.Forms.Label _lblCommon_63;
		private System.Windows.Forms.TextBox _txtCommonTextBox_60;
		private System.Windows.Forms.TextBox _txtCommonTextBox_61;
		private System.Windows.Forms.Label _lblCommon_64;
		private System.Windows.Forms.TextBox _txtCommonTextBox_62;
		private System.Windows.Forms.TextBox _txtCommonTextBox_63;
		private System.Windows.Forms.TextBox _txtCommonTextBox_64;
		private AxXtremeSuiteControls.AxTabControlPage _fraEmployeeInformation_2;
		public AxXtremeSuiteControls.AxTabControlPage TabControlPage3;
		public System.Windows.Forms.CheckBox chkAllowTicket;
		public Syncfusion.WinForms.Input.SfDateTimeEdit txtTicketAccrualStartDate;
		private System.Windows.Forms.Label _lblCommon_23;
		private System.Windows.Forms.Label _lblCommon_54;
		private System.Windows.Forms.TextBox _txtCommonTextBox_71;
		private System.Windows.Forms.Label _lblCommon_68;
		private System.Windows.Forms.TextBox _txtCommonTextBox_73;
		private System.Windows.Forms.Label _lblCommon_70;
		private System.Windows.Forms.Label _txtDisplayLabel_11;
		private System.Windows.Forms.Label _txtDisplayLabel_12;
		private System.Windows.Forms.Label _lblCommonLabel_12;
		private System.Windows.Forms.Label _txtDisplayLabel_13;
		private AxXtremeSuiteControls.AxTabControlPage _fraEmployeeInformation_3;
		public AxXtremeSuiteControls.AxTabControlPage TabControlPage2;
		private System.Windows.Forms.TextBox _txtCommonTextBox_72;
		private System.Windows.Forms.Label _lblCommon_74;
		private System.Windows.Forms.Label _txtDisplayLabel_18;
		private AxXtremeSuiteControls.AxTabControlPage _fraEmployeeInformation_4;
		public AxXtremeSuiteControls.AxTabControlPage TabControlPage1;
		public System.Windows.Forms.Button cmdPullGradeSetting;
		public System.Windows.Forms.TextBox txtNoticePeriod;
		public System.Windows.Forms.TextBox txtContractPeriod;
		private System.Windows.Forms.TextBox _txtCommonTextBox_9;
		private System.Windows.Forms.Label _lblCommon_116;
		private System.Windows.Forms.TextBox _txtCommonTextBox_10;
		private System.Windows.Forms.Label _lblCommon_105;
		private System.Windows.Forms.TextBox _txtCommonTextBox_11;
		private System.Windows.Forms.Label _lblCommon_114;
		private System.Windows.Forms.TextBox _txtCommonTextBox_12;
		private System.Windows.Forms.Label _lblCommon_104;
		private System.Windows.Forms.Label _lblCommon_108;
		public Syncfusion.WinForms.Input.SfDateTimeEdit txtBirthDate;
		private System.Windows.Forms.Label _lblCommon_109;
		public Syncfusion.WinForms.Input.SfDateTimeEdit txtJoiningDate;
		private System.Windows.Forms.TextBox _txtCommonTextBox_13;
		private System.Windows.Forms.Label _lblCommon_112;
		private System.Windows.Forms.TextBox _txtCommonTextBox_15;
		private System.Windows.Forms.Label _lblCommon_103;
		private System.Windows.Forms.Label Label1_1;
		private System.Windows.Forms.ComboBox _cmbCommon_3;
		private System.Windows.Forms.Label Label1_3;
		private System.Windows.Forms.ComboBox _cmbCommon_1;
		private System.Windows.Forms.ComboBox _cmbCommon_2;
		public System.Windows.Forms.LabelLabel12;
		private System.Windows.Forms.TextBox _txtCommonTextBox_36;
		private System.Windows.Forms.Label _txtDisplayLabel_1;
		private System.Windows.Forms.Label _txtDisplayLabel_2;
		private System.Windows.Forms.Label _txtDisplayLabel_3;
		private System.Windows.Forms.Label _txtDisplayLabel_4;
		private System.Windows.Forms.Label _txtDisplayLabel_8;
		private System.Windows.Forms.Label _txtDisplayLabel_5;
		private System.Windows.Forms.Label _lblCommon_37;
		private System.Windows.Forms.Label _txtDisplayLabel_6;
		public Syncfusion.WinForms.Input.SfDateTimeEdit txtProbationEndDate;
		private System.Windows.Forms.Label _txtDisplayLabel_7;
		private System.Windows.Forms.TextBox _txtCommonTextBox_39;
		private System.Windows.Forms.TextBox _txtCommonTextBox_52;
		private System.Windows.Forms.Label _txtDisplayLabel_10;
		private System.Windows.Forms.TextBox _txtCommonTextBox_56;
		public System.Windows.Forms.TextBox txtDeductionHrs;
		private System.Windows.Forms.Label _lblCommon_55;
		public Syncfusion.WinForms.Input.SfDateTimeEdit txtContractStratDate;
		public Syncfusion.WinForms.Input.SfDateTimeEdit txtContractEndDate;
		private System.Windows.Forms.Label _txtDisplayLabel_14;
		private System.Windows.Forms.Label _txtDisplayLabel_16;
		private System.Windows.Forms.Label _lblCommon_56;
		private System.Windows.Forms.Label _lblCommon_57;
		private System.Windows.Forms.TextBox _txtCommonTextBox_70;
		private System.Windows.Forms.Label _lblCommon_73;
		private System.Windows.Forms.Label _txtDisplayLabel_17;
		public Syncfusion.WinForms.Input.SfDateTimeEdit txtDSeveranceDate;
		private System.Windows.Forms.Label _lblCommon_42;
		private System.Windows.Forms.Label _lblCommon_111;
		private System.Windows.Forms.Label _lblCommonLabel_0;
		private System.Windows.Forms.Label Label1_2;
		private System.Windows.Forms.Label _lblCommon_41;
		private System.Windows.Forms.Label _lblCommon_49;
		public System.Windows.Forms.Label lblDeductionHrs;
		private System.Windows.Forms.Label Label1_4;
		private System.Windows.Forms.Label Label1_5;
		public System.Windows.Forms.Label lblNoticePeriod;
		private AxXtremeSuiteControls.AxTabControlPage _fraEmployeeInformation_0;
		public AxXtremeSuiteControls.AxTabControl tabEmployee;
		public System.Windows.Forms.OpenFileDialog CommonDialog1Open;
		public UpgradeStubs.AxMSComDlg_AxCommonDialog CommonDialog1;
		private System.Windows.Forms.ComboBox _cmbCommon_0;
		private System.Windows.Forms.Label _lblCommon_113;
		private System.Windows.Forms.TextBox _txtCommonTextBox_0;
		private System.Windows.Forms.Label Label1_0;
		private System.Windows.Forms.Label _lblCommon_102;
		private System.Windows.Forms.Label _lblCommon_6;
		private System.Windows.Forms.TextBox _txtCommonTextBox_8;
		private System.Windows.Forms.TextBox _txtCommonTextBox_7;
		private System.Windows.Forms.TextBox _txtCommonTextBox_6;
		private System.Windows.Forms.TextBox _txtCommonTextBox_5;
		private System.Windows.Forms.TextBox _txtCommonTextBox_4;
		private System.Windows.Forms.TextBox _txtCommonTextBox_3;
		private System.Windows.Forms.TextBox _txtCommonTextBox_2;
		private System.Windows.Forms.Label _lblCommon_7;
		private System.Windows.Forms.Label _lblCommon_8;
		private System.Windows.Forms.Label _lblCommon_9;
		private System.Windows.Forms.Label _lblCommon_10;
		private System.Windows.Forms.Label _lblCommon_4;
		private System.Windows.Forms.TextBox _txtCommonTextBox_1;
		private System.Windows.Forms.Label _txtDisplayLabel_0;
		private System.Windows.Forms.Label _lblCommon_46;
		private System.Windows.Forms.Label _lblCommon_50;
		private System.Windows.Forms.Label _lblCommon_51;
		private System.Windows.Forms.Label _lblCommon_52;
		private System.Windows.Forms.Label _lblCommon_53;
		private System.Windows.Forms.TextBox _txtCommonTextBox_58;
		private System.Windows.Forms.TextBox _txtCommonTextBox_59;
		private System.Windows.Forms.Label _lblCommon_58;
		private System.Windows.Forms.Label _lblCommon_59;
		public System.Windows.Forms.PictureBox imgPicture;
		public System.Windows.Forms.PictureBox Image1;
		public System.Windows.Forms.Label[] Label1 = new System.Windows.Forms.Label[6];
		public System.Windows.Forms.ComboBox[] cmbCommon = new System.Windows.Forms.ComboBox[4];
		public AxXtremeSuiteControls.AxTabControlPage[] fraEmployeeInformation = new AxXtremeSuiteControls.AxTabControlPage[5];
		public System.Windows.Forms.Label[] lblCommon = new System.Windows.Forms.Label[117];
		public System.Windows.Forms.Label[] lblCommonLabel = new System.Windows.Forms.Label[13];
		public System.Windows.Forms.TextBox[] txtCommonTextBox = new System.Windows.Forms.TextBox[74];
		public System.Windows.Forms.Label[] txtDisplayLabel = new System.Windows.Forms.Label[19];
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPayEmployee));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this.tabEmployee = new AxXtremeSuiteControls.AxTabControl();
			this.TabControlPage4 = new AxXtremeSuiteControls.AxTabControlPage();
			this._fraEmployeeInformation_1 = new AxXtremeSuiteControls.AxTabControlPage();
			this._lblCommon_47 = new System.Windows.Forms.Label();
			this._lblCommon_48 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_31 = new System.Windows.Forms.TextBox();
			this.Label3 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_57 = new System.Windows.Forms.TextBox();
			this.Label2 = new System.Windows.Forms.Label();
			this._lblCommon_1 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_29 = new System.Windows.Forms.TextBox();
			this._lblCommon_3 = new System.Windows.Forms.Label();
			this._lblCommon_5 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_26 = new System.Windows.Forms.TextBox();
			this._lblCommon_11 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_25 = new System.Windows.Forms.TextBox();
			this._lblCommon_12 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_22 = new System.Windows.Forms.TextBox();
			this._lblCommon_13 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_24 = new System.Windows.Forms.TextBox();
			this._lblCommon_14 = new System.Windows.Forms.Label();
			this._lblCommon_15 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_21 = new System.Windows.Forms.TextBox();
			this._lblCommon_16 = new System.Windows.Forms.Label();
			this._lblCommon_17 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_19 = new System.Windows.Forms.TextBox();
			this._lblCommon_18 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_18 = new System.Windows.Forms.TextBox();
			this._lblCommon_19 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_17 = new System.Windows.Forms.TextBox();
			this._lblCommon_20 = new System.Windows.Forms.Label();
			this._lblCommon_21 = new System.Windows.Forms.Label();
			this._lblCommon_22 = new System.Windows.Forms.Label();
			this._lblCommon_24 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_34 = new System.Windows.Forms.TextBox();
			this._lblCommon_25 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_33 = new System.Windows.Forms.TextBox();
			this._lblCommon_26 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_32 = new System.Windows.Forms.TextBox();
			this._txtCommonTextBox_35 = new System.Windows.Forms.TextBox();
			this._lblCommon_36 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_37 = new System.Windows.Forms.TextBox();
			this._lblCommon_65 = new System.Windows.Forms.Label();
			this._lblCommon_66 = new System.Windows.Forms.Label();
			this._lblCommon_67 = new System.Windows.Forms.Label();
			this._lblCommon_69 = new System.Windows.Forms.Label();
			this._lblCommon_71 = new System.Windows.Forms.Label();
			this._lblCommon_72 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_65 = new System.Windows.Forms.TextBox();
			this._txtCommonTextBox_66 = new System.Windows.Forms.TextBox();
			this._txtCommonTextBox_67 = new System.Windows.Forms.TextBox();
			this._txtCommonTextBox_68 = new System.Windows.Forms.TextBox();
			this._txtCommonTextBox_69 = new System.Windows.Forms.TextBox();
			this._lblCommon_2 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_28 = new System.Windows.Forms.TextBox();
			this._txtCommonTextBox_27 = new System.Windows.Forms.TextBox();
			this._txtCommonTextBox_23 = new System.Windows.Forms.TextBox();
			this._txtCommonTextBox_20 = new System.Windows.Forms.TextBox();
			this._txtCommonTextBox_16 = new System.Windows.Forms.TextBox();
			this._txtCommonTextBox_30 = new System.Windows.Forms.TextBox();
			this.Shape3 = new UpgradeHelpers.Gui.ShapeHelper();
			this.Shape1 = new UpgradeHelpers.Gui.ShapeHelper();
			this.Shape2 = new UpgradeHelpers.Gui.ShapeHelper();
			this.TabControlPage3 = new AxXtremeSuiteControls.AxTabControlPage();
			this._fraEmployeeInformation_2 = new AxXtremeSuiteControls.AxTabControlPage();
			this.frmRasidence = new System.Windows.Forms.GroupBox();
			this._lblCommon_40 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_51 = new System.Windows.Forms.TextBox();
			this._txtDisplayLabel_9 = new System.Windows.Forms.Label();
			this._lblCommon_39 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_50 = new System.Windows.Forms.TextBox();
			this._lblCommon_30 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_38 = new System.Windows.Forms.TextBox();
			this._lblCommon_0 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_14 = new System.Windows.Forms.TextBox();
			this._lblCommon_38 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_49 = new System.Windows.Forms.TextBox();
			this.Label5 = new System.Windows.Forms.Label();
			this.txtLoginID = new System.Windows.Forms.TextBox();
			this.Label4 = new System.Windows.Forms.Label();
			this.txtDlblDefaultProject = new System.Windows.Forms.Label();
			this.txtDefaultProject = new System.Windows.Forms.TextBox();
			this._lblCommon_27 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_40 = new System.Windows.Forms.TextBox();
			this._lblCommon_28 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_41 = new System.Windows.Forms.TextBox();
			this._lblCommon_29 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_42 = new System.Windows.Forms.TextBox();
			this._lblCommon_31 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_43 = new System.Windows.Forms.TextBox();
			this._lblCommon_32 = new System.Windows.Forms.Label();
			this._lblCommon_115 = new System.Windows.Forms.Label();
			this._lblCommon_33 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_46 = new System.Windows.Forms.TextBox();
			this._lblCommon_34 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_47 = new System.Windows.Forms.TextBox();
			this._lblCommon_35 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_48 = new System.Windows.Forms.TextBox();
			this._txtCommonTextBox_44 = new System.Windows.Forms.TextBox();
			this._txtCommonTextBox_45 = new System.Windows.Forms.TextBox();
			this._txtDisplayLabel_15 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_54 = new System.Windows.Forms.TextBox();
			this._txtCommonTextBox_55 = new System.Windows.Forms.TextBox();
			this._lblCommon_44 = new System.Windows.Forms.Label();
			this._lblCommon_45 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_53 = new System.Windows.Forms.TextBox();
			this._lblCommon_43 = new System.Windows.Forms.Label();
			this.lblDefaultProject = new System.Windows.Forms.Label();
			this._lblCommon_60 = new System.Windows.Forms.Label();
			this._lblCommon_61 = new System.Windows.Forms.Label();
			this._lblCommon_62 = new System.Windows.Forms.Label();
			this._lblCommon_63 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_60 = new System.Windows.Forms.TextBox();
			this._txtCommonTextBox_61 = new System.Windows.Forms.TextBox();
			this._lblCommon_64 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_62 = new System.Windows.Forms.TextBox();
			this._txtCommonTextBox_63 = new System.Windows.Forms.TextBox();
			this._txtCommonTextBox_64 = new System.Windows.Forms.TextBox();
			this.TabControlPage2 = new AxXtremeSuiteControls.AxTabControlPage();
			this._fraEmployeeInformation_3 = new AxXtremeSuiteControls.AxTabControlPage();
			this.chkAllowTicket = new System.Windows.Forms.CheckBox();
			this.txtTicketAccrualStartDate = new Syncfusion.WinForms.Input.SfDateTimeEdit();
			this._lblCommon_23 = new System.Windows.Forms.Label();
			this._lblCommon_54 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_71 = new System.Windows.Forms.TextBox();
			this._lblCommon_68 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_73 = new System.Windows.Forms.TextBox();
			this._lblCommon_70 = new System.Windows.Forms.Label();
			this._txtDisplayLabel_11 = new System.Windows.Forms.Label();
			this._txtDisplayLabel_12 = new System.Windows.Forms.Label();
			this._lblCommonLabel_12 = new System.Windows.Forms.Label();
			this._txtDisplayLabel_13 = new System.Windows.Forms.Label();
			this.TabControlPage1 = new AxXtremeSuiteControls.AxTabControlPage();
			this._fraEmployeeInformation_4 = new AxXtremeSuiteControls.AxTabControlPage();
			this._txtCommonTextBox_72 = new System.Windows.Forms.TextBox();
			this._lblCommon_74 = new System.Windows.Forms.Label();
			this._txtDisplayLabel_18 = new System.Windows.Forms.Label();
			this._fraEmployeeInformation_0 = new AxXtremeSuiteControls.AxTabControlPage();
			this.cmdPullGradeSetting = new System.Windows.Forms.Button();
			this.txtNoticePeriod = new System.Windows.Forms.TextBox();
			this.txtContractPeriod = new System.Windows.Forms.TextBox();
			this._txtCommonTextBox_9 = new System.Windows.Forms.TextBox();
			this._lblCommon_116 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_10 = new System.Windows.Forms.TextBox();
			this._lblCommon_105 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_11 = new System.Windows.Forms.TextBox();
			this._lblCommon_114 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_12 = new System.Windows.Forms.TextBox();
			this._lblCommon_104 = new System.Windows.Forms.Label();
			this._lblCommon_108 = new System.Windows.Forms.Label();
			this.txtBirthDate = new Syncfusion.WinForms.Input.SfDateTimeEdit();
			this._lblCommon_109 = new System.Windows.Forms.Label();
			this.txtJoiningDate = new Syncfusion.WinForms.Input.SfDateTimeEdit();
			this._txtCommonTextBox_13 = new System.Windows.Forms.TextBox();
			this._lblCommon_112 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_15 = new System.Windows.Forms.TextBox();
			this._lblCommon_103 = new System.Windows.Forms.Label();
			this.Label1_1 = new System.Windows.Forms.Label();
			this._cmbCommon_3 = new System.Windows.Forms.ComboBox();
			this.Label1_3 = new System.Windows.Forms.Label();
			this._cmbCommon_1 = new System.Windows.Forms.ComboBox();
			this._cmbCommon_2 = new System.Windows.Forms.ComboBox();
			this.Label12 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_36 = new System.Windows.Forms.TextBox();
			this._txtDisplayLabel_1 = new System.Windows.Forms.Label();
			this._txtDisplayLabel_2 = new System.Windows.Forms.Label();
			this._txtDisplayLabel_3 = new System.Windows.Forms.Label();
			this._txtDisplayLabel_4 = new System.Windows.Forms.Label();
			this._txtDisplayLabel_8 = new System.Windows.Forms.Label();
			this._txtDisplayLabel_5 = new System.Windows.Forms.Label();
			this._lblCommon_37 = new System.Windows.Forms.Label();
			this._txtDisplayLabel_6 = new System.Windows.Forms.Label();
			this.txtProbationEndDate = new Syncfusion.WinForms.Input.SfDateTimeEdit();
			this._txtDisplayLabel_7 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_39 = new System.Windows.Forms.TextBox();
			this._txtCommonTextBox_52 = new System.Windows.Forms.TextBox();
			this._txtDisplayLabel_10 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_56 = new System.Windows.Forms.TextBox();
			this.txtDeductionHrs = new System.Windows.Forms.TextBox();
			this._lblCommon_55 = new System.Windows.Forms.Label();
			this.txtContractStratDate = new Syncfusion.WinForms.Input.SfDateTimeEdit();
			this.txtContractEndDate = new Syncfusion.WinForms.Input.SfDateTimeEdit();
			this._txtDisplayLabel_14 = new System.Windows.Forms.Label();
			this._txtDisplayLabel_16 = new System.Windows.Forms.Label();
			this._lblCommon_56 = new System.Windows.Forms.Label();
			this._lblCommon_57 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_70 = new System.Windows.Forms.TextBox();
			this._lblCommon_73 = new System.Windows.Forms.Label();
			this._txtDisplayLabel_17 = new System.Windows.Forms.Label();
			this.txtDSeveranceDate = new Syncfusion.WinForms.Input.SfDateTimeEdit();
			this._lblCommon_42 = new System.Windows.Forms.Label();
			this._lblCommon_111 = new System.Windows.Forms.Label();
			this._lblCommonLabel_0 = new System.Windows.Forms.Label();
			this.Label1_2 = new System.Windows.Forms.Label();
			this._lblCommon_41 = new System.Windows.Forms.Label();
			this._lblCommon_49 = new System.Windows.Forms.Label();
			this.lblDeductionHrs = new System.Windows.Forms.Label();
			this.Label1_4 = new System.Windows.Forms.Label();
			this.Label1_5 = new System.Windows.Forms.Label();
			this.lblNoticePeriod = new System.Windows.Forms.Label();
			this.CommonDialog1Open = new System.Windows.Forms.OpenFileDialog();
			this.CommonDialog1 = new UpgradeStubs.AxMSComDlg_AxCommonDialog();
			this._cmbCommon_0 = new System.Windows.Forms.ComboBox();
			this._lblCommon_113 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_0 = new System.Windows.Forms.TextBox();
			this.Label1_0 = new System.Windows.Forms.Label();
			this._lblCommon_102 = new System.Windows.Forms.Label();
			this._lblCommon_6 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_8 = new System.Windows.Forms.TextBox();
			this._txtCommonTextBox_7 = new System.Windows.Forms.TextBox();
			this._txtCommonTextBox_6 = new System.Windows.Forms.TextBox();
			this._txtCommonTextBox_5 = new System.Windows.Forms.TextBox();
			this._txtCommonTextBox_4 = new System.Windows.Forms.TextBox();
			this._txtCommonTextBox_3 = new System.Windows.Forms.TextBox();
			this._txtCommonTextBox_2 = new System.Windows.Forms.TextBox();
			this._lblCommon_7 = new System.Windows.Forms.Label();
			this._lblCommon_8 = new System.Windows.Forms.Label();
			this._lblCommon_9 = new System.Windows.Forms.Label();
			this._lblCommon_10 = new System.Windows.Forms.Label();
			this._lblCommon_4 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_1 = new System.Windows.Forms.TextBox();
			this._txtDisplayLabel_0 = new System.Windows.Forms.Label();
			this._lblCommon_46 = new System.Windows.Forms.Label();
			this._lblCommon_50 = new System.Windows.Forms.Label();
			this._lblCommon_51 = new System.Windows.Forms.Label();
			this._lblCommon_52 = new System.Windows.Forms.Label();
			this._lblCommon_53 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_58 = new System.Windows.Forms.TextBox();
			this._txtCommonTextBox_59 = new System.Windows.Forms.TextBox();
			this._lblCommon_58 = new System.Windows.Forms.Label();
			this._lblCommon_59 = new System.Windows.Forms.Label();
			this.imgPicture = new System.Windows.Forms.PictureBox();
			this.Image1 = new System.Windows.Forms.PictureBox();
			// //((System.ComponentModel.ISupportInitialize) this._fraEmployeeInformation_1).BeginInit();
			// //((System.ComponentModel.ISupportInitialize) this.TabControlPage4).BeginInit();
			// //((System.ComponentModel.ISupportInitialize) this._fraEmployeeInformation_2).BeginInit();
			// //((System.ComponentModel.ISupportInitialize) this.TabControlPage3).BeginInit();
			// //((System.ComponentModel.ISupportInitialize) this._fraEmployeeInformation_3).BeginInit();
			// //((System.ComponentModel.ISupportInitialize) this.TabControlPage2).BeginInit();
			// //((System.ComponentModel.ISupportInitialize) this._fraEmployeeInformation_4).BeginInit();
			// //((System.ComponentModel.ISupportInitialize) this.TabControlPage1).BeginInit();
			// //((System.ComponentModel.ISupportInitialize) this._fraEmployeeInformation_0).BeginInit();
			// //((System.ComponentModel.ISupportInitialize) this.tabEmployee).BeginInit();
			this.tabEmployee.SuspendLayout();
			this.TabControlPage4.SuspendLayout();
			this._fraEmployeeInformation_1.SuspendLayout();
			this.TabControlPage3.SuspendLayout();
			this._fraEmployeeInformation_2.SuspendLayout();
			this.frmRasidence.SuspendLayout();
			this.TabControlPage2.SuspendLayout();
			this._fraEmployeeInformation_3.SuspendLayout();
			this.TabControlPage1.SuspendLayout();
			this._fraEmployeeInformation_4.SuspendLayout();
			this._fraEmployeeInformation_0.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabEmployee
			// 
			this.tabEmployee.AllowDrop = true;
			this.tabEmployee.Controls.Add(this.TabControlPage4);
			this.tabEmployee.Controls.Add(this.TabControlPage3);
			this.tabEmployee.Controls.Add(this.TabControlPage2);
			this.tabEmployee.Controls.Add(this.TabControlPage1);
			this.tabEmployee.Controls.Add(this._fraEmployeeInformation_0);
			this.tabEmployee.Location = new System.Drawing.Point(6, 198);
			this.tabEmployee.Name = "tabEmployee";
			("tabEmployee.OcxState");
			this.tabEmployee.Size = new System.Drawing.Size(867, 383);
			this.tabEmployee.TabIndex = 29;
			this.tabEmployee.TabStop = false;
			// 
			// TabControlPage4
			// 
			this.TabControlPage4.AllowDrop = true;
			this.TabControlPage4.Controls.Add(this._fraEmployeeInformation_1);
			this.TabControlPage4.Location = new System.Drawing.Point(-4664, 28);
			this.TabControlPage4.Name = "TabControlPage4";
			("TabControlPage4.OcxState");
			this.TabControlPage4.Size = new System.Drawing.Size(863, 353);
			this.TabControlPage4.TabIndex = 30;
			this.TabControlPage4.Visible = false;
			// 
			// _fraEmployeeInformation_1
			// 
			this._fraEmployeeInformation_1.AllowDrop = true;
			this._fraEmployeeInformation_1.Controls.Add(this._lblCommon_47);
			this._fraEmployeeInformation_1.Controls.Add(this._lblCommon_48);
			this._fraEmployeeInformation_1.Controls.Add(this._txtCommonTextBox_31);
			this._fraEmployeeInformation_1.Controls.Add(this.Label3);
			this._fraEmployeeInformation_1.Controls.Add(this._txtCommonTextBox_57);
			this._fraEmployeeInformation_1.Controls.Add(this.Label2);
			this._fraEmployeeInformation_1.Controls.Add(this._lblCommon_1);
			this._fraEmployeeInformation_1.Controls.Add(this._txtCommonTextBox_29);
			this._fraEmployeeInformation_1.Controls.Add(this._lblCommon_3);
			this._fraEmployeeInformation_1.Controls.Add(this._lblCommon_5);
			this._fraEmployeeInformation_1.Controls.Add(this._txtCommonTextBox_26);
			this._fraEmployeeInformation_1.Controls.Add(this._lblCommon_11);
			this._fraEmployeeInformation_1.Controls.Add(this._txtCommonTextBox_25);
			this._fraEmployeeInformation_1.Controls.Add(this._lblCommon_12);
			this._fraEmployeeInformation_1.Controls.Add(this._txtCommonTextBox_22);
			this._fraEmployeeInformation_1.Controls.Add(this._lblCommon_13);
			this._fraEmployeeInformation_1.Controls.Add(this._txtCommonTextBox_24);
			this._fraEmployeeInformation_1.Controls.Add(this._lblCommon_14);
			this._fraEmployeeInformation_1.Controls.Add(this._lblCommon_15);
			this._fraEmployeeInformation_1.Controls.Add(this._txtCommonTextBox_21);
			this._fraEmployeeInformation_1.Controls.Add(this._lblCommon_16);
			this._fraEmployeeInformation_1.Controls.Add(this._lblCommon_17);
			this._fraEmployeeInformation_1.Controls.Add(this._txtCommonTextBox_19);
			this._fraEmployeeInformation_1.Controls.Add(this._lblCommon_18);
			this._fraEmployeeInformation_1.Controls.Add(this._txtCommonTextBox_18);
			this._fraEmployeeInformation_1.Controls.Add(this._lblCommon_19);
			this._fraEmployeeInformation_1.Controls.Add(this._txtCommonTextBox_17);
			this._fraEmployeeInformation_1.Controls.Add(this._lblCommon_20);
			this._fraEmployeeInformation_1.Controls.Add(this._lblCommon_21);
			this._fraEmployeeInformation_1.Controls.Add(this._lblCommon_22);
			this._fraEmployeeInformation_1.Controls.Add(this._lblCommon_24);
			this._fraEmployeeInformation_1.Controls.Add(this._txtCommonTextBox_34);
			this._fraEmployeeInformation_1.Controls.Add(this._lblCommon_25);
			this._fraEmployeeInformation_1.Controls.Add(this._txtCommonTextBox_33);
			this._fraEmployeeInformation_1.Controls.Add(this._lblCommon_26);
			this._fraEmployeeInformation_1.Controls.Add(this._txtCommonTextBox_32);
			this._fraEmployeeInformation_1.Controls.Add(this._txtCommonTextBox_35);
			this._fraEmployeeInformation_1.Controls.Add(this._lblCommon_36);
			this._fraEmployeeInformation_1.Controls.Add(this._txtCommonTextBox_37);
			this._fraEmployeeInformation_1.Controls.Add(this._lblCommon_65);
			this._fraEmployeeInformation_1.Controls.Add(this._lblCommon_66);
			this._fraEmployeeInformation_1.Controls.Add(this._lblCommon_67);
			this._fraEmployeeInformation_1.Controls.Add(this._lblCommon_69);
			this._fraEmployeeInformation_1.Controls.Add(this._lblCommon_71);
			this._fraEmployeeInformation_1.Controls.Add(this._lblCommon_72);
			this._fraEmployeeInformation_1.Controls.Add(this._txtCommonTextBox_65);
			this._fraEmployeeInformation_1.Controls.Add(this._txtCommonTextBox_66);
			this._fraEmployeeInformation_1.Controls.Add(this._txtCommonTextBox_67);
			this._fraEmployeeInformation_1.Controls.Add(this._txtCommonTextBox_68);
			this._fraEmployeeInformation_1.Controls.Add(this._txtCommonTextBox_69);
			this._fraEmployeeInformation_1.Controls.Add(this._lblCommon_2);
			this._fraEmployeeInformation_1.Controls.Add(this._txtCommonTextBox_28);
			this._fraEmployeeInformation_1.Controls.Add(this._txtCommonTextBox_27);
			this._fraEmployeeInformation_1.Controls.Add(this._txtCommonTextBox_23);
			this._fraEmployeeInformation_1.Controls.Add(this._txtCommonTextBox_20);
			this._fraEmployeeInformation_1.Controls.Add(this._txtCommonTextBox_16);
			this._fraEmployeeInformation_1.Controls.Add(this._txtCommonTextBox_30);
			this._fraEmployeeInformation_1.Controls.Add(this.Shape3);
			this._fraEmployeeInformation_1.Controls.Add(this.Shape1);
			this._fraEmployeeInformation_1.Controls.Add(this.Shape2);
			this._fraEmployeeInformation_1.Location = new System.Drawing.Point(2, 0);
			this._fraEmployeeInformation_1.Name = "_fraEmployeeInformation_1";
			("_fraEmployeeInformation_1.OcxState");
			this._fraEmployeeInformation_1.Size = new System.Drawing.Size(793, 315);
			this._fraEmployeeInformation_1.TabIndex = 31;
			// 
			// _lblCommon_47
			// 
			this._lblCommon_47.AllowDrop = true;
			this._lblCommon_47.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_47.Text = " Local Address ";
			this._lblCommon_47.Location = new System.Drawing.Point(16, 0);
			// // this._lblCommon_47.mLabelId = 1062;
			this._lblCommon_47.Name = "_lblCommon_47";
			this._lblCommon_47.Size = new System.Drawing.Size(72, 13);
			this._lblCommon_47.TabIndex = 66;
			// 
			// _lblCommon_48
			// 
			this._lblCommon_48.AllowDrop = true;
			this._lblCommon_48.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_48.Text = " Permanent Address ";
			this._lblCommon_48.Location = new System.Drawing.Point(10, 127);
			// // this._lblCommon_48.mLabelId = 1077;
			this._lblCommon_48.Name = "_lblCommon_48";
			this._lblCommon_48.Size = new System.Drawing.Size(100, 13);
			this._lblCommon_48.TabIndex = 70;
			// 
			// _txtCommonTextBox_31
			// 
			this._txtCommonTextBox_31.AllowDrop = true;
			this._txtCommonTextBox_31.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_31.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_31.Location = new System.Drawing.Point(277, 103);
			this._txtCommonTextBox_31.Name = "_txtCommonTextBox_31";
			this._txtCommonTextBox_31.Size = new System.Drawing.Size(476, 19);
			this._txtCommonTextBox_31.TabIndex = 68;
			this._txtCommonTextBox_31.Text = "";
			// this.this._txtCommonTextBox_31.Watermark = "";
			// this.this._txtCommonTextBox_31.Change += new System.Windows.Forms.TextBox.ChangeHandler(this.txtCommonTextBox_Change);
			// this.this._txtCommonTextBox_31.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_31.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// System.Windows.Forms.Label3
			// 
			this.Label3.AllowDrop = true;
			this.Label3.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.Label3.Text = "Telephone";
			this.Label3.Location = new System.Drawing.Point(203, 82);
			// this.Label3.mLabelId = 2268;
			this.Label3.Name = "System.Windows.Forms.Label3";
			this.Label3.Size = new System.Drawing.Size(50, 14);
			this.Label3.TabIndex = 58;
			// 
			// _txtCommonTextBox_57
			// 
			this._txtCommonTextBox_57.AllowDrop = true;
			this._txtCommonTextBox_57.BackColor = System.Drawing.Color.White;
			// this._txtCommonTextBox_57.bolAllowDecimal = false;
			this._txtCommonTextBox_57.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_57.Location = new System.Drawing.Point(89, 206);
			// this._txtCommonTextBox_57.mDropDownType = (System.Windows.Forms.TextBox.DropDownTypes) 0;
			this._txtCommonTextBox_57.Name = "_txtCommonTextBox_57";
			this._txtCommonTextBox_57.Size = new System.Drawing.Size(667, 21);
			this._txtCommonTextBox_57.TabIndex = 77;
			this._txtCommonTextBox_57.Text = "";
			// this.this._txtCommonTextBox_57.Watermark = "";
			// this.this._txtCommonTextBox_57.Change += new System.Windows.Forms.TextBox.ChangeHandler(this.txtCommonTextBox_Change);
			// this.this._txtCommonTextBox_57.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_57.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// System.Windows.Forms.Label2
			// 
			this.Label2.AllowDrop = true;
			this.Label2.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.Label2.Text = "Address4";
			this.Label2.Location = new System.Drawing.Point(9, 209);
			// this.Label2.mLabelId = 2244;
			this.Label2.Name = "System.Windows.Forms.Label2";
			this.Label2.Size = new System.Drawing.Size(48, 14);
			this.Label2.TabIndex = 76;
			// 
			// _lblCommon_1
			// 
			this._lblCommon_1.AllowDrop = true;
			this._lblCommon_1.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_1.Text = "Mobile No.";
			this._lblCommon_1.Location = new System.Drawing.Point(389, 82);
			// // this._lblCommon_1.mLabelId = 1073;
			this._lblCommon_1.Name = "_lblCommon_1";
			this._lblCommon_1.Size = new System.Drawing.Size(50, 13);
			this._lblCommon_1.TabIndex = 40;
			// 
			// _txtCommonTextBox_29
			// 
			this._txtCommonTextBox_29.AllowDrop = true;
			this._txtCommonTextBox_29.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_29.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_29.Location = new System.Drawing.Point(463, 79);
			this._txtCommonTextBox_29.Name = "_txtCommonTextBox_29";
			this._txtCommonTextBox_29.Size = new System.Drawing.Size(101, 19);
			this._txtCommonTextBox_29.TabIndex = 59;
			this._txtCommonTextBox_29.Text = "";
			// this.this._txtCommonTextBox_29.Watermark = "";
			// this.this._txtCommonTextBox_29.Change += new System.Windows.Forms.TextBox.ChangeHandler(this.txtCommonTextBox_Change);
			// this.this._txtCommonTextBox_29.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_29.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _lblCommon_3
			// 
			this._lblCommon_3.AllowDrop = true;
			this._lblCommon_3.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_3.Text = "Zip Code";
			this._lblCommon_3.Location = new System.Drawing.Point(6, 82);
			// // this._lblCommon_3.mLabelId = 1072;
			this._lblCommon_3.Name = "_lblCommon_3";
			this._lblCommon_3.Size = new System.Drawing.Size(42, 13);
			this._lblCommon_3.TabIndex = 42;
			// 
			// _lblCommon_5
			// 
			this._lblCommon_5.AllowDrop = true;
			this._lblCommon_5.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_5.Text = "P.O. Box";
			this._lblCommon_5.Location = new System.Drawing.Point(573, 61);
			// // this._lblCommon_5.mLabelId = 1066;
			this._lblCommon_5.Name = "_lblCommon_5";
			this._lblCommon_5.Size = new System.Drawing.Size(43, 13);
			this._lblCommon_5.TabIndex = 43;
			// 
			// _txtCommonTextBox_26
			// 
			this._txtCommonTextBox_26.AllowDrop = true;
			this._txtCommonTextBox_26.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_26.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_26.Location = new System.Drawing.Point(653, 58);
			this._txtCommonTextBox_26.Name = "_txtCommonTextBox_26";
			this._txtCommonTextBox_26.Size = new System.Drawing.Size(101, 19);
			this._txtCommonTextBox_26.TabIndex = 56;
			this._txtCommonTextBox_26.Text = "";
			// this.this._txtCommonTextBox_26.Watermark = "";
			// this.this._txtCommonTextBox_26.Change += new System.Windows.Forms.TextBox.ChangeHandler(this.txtCommonTextBox_Change);
			// this.this._txtCommonTextBox_26.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_26.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _lblCommon_11
			// 
			this._lblCommon_11.AllowDrop = true;
			this._lblCommon_11.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_11.Text = "Entrance";
			this._lblCommon_11.Location = new System.Drawing.Point(389, 61);
			// // this._lblCommon_11.mLabelId = 1075;
			this._lblCommon_11.Name = "_lblCommon_11";
			this._lblCommon_11.Size = new System.Drawing.Size(43, 13);
			this._lblCommon_11.TabIndex = 44;
			// 
			// _txtCommonTextBox_25
			// 
			this._txtCommonTextBox_25.AllowDrop = true;
			this._txtCommonTextBox_25.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_25.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_25.Location = new System.Drawing.Point(463, 58);
			this._txtCommonTextBox_25.Name = "_txtCommonTextBox_25";
			this._txtCommonTextBox_25.Size = new System.Drawing.Size(101, 19);
			this._txtCommonTextBox_25.TabIndex = 55;
			this._txtCommonTextBox_25.Text = "";
			// this.this._txtCommonTextBox_25.Watermark = "";
			// this.this._txtCommonTextBox_25.Change += new System.Windows.Forms.TextBox.ChangeHandler(this.txtCommonTextBox_Change);
			// this.this._txtCommonTextBox_25.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_25.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _lblCommon_12
			// 
			this._lblCommon_12.AllowDrop = true;
			this._lblCommon_12.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_12.Text = "Qasima";
			this._lblCommon_12.Location = new System.Drawing.Point(574, 40);
			// // this._lblCommon_12.mLabelId = 1074;
			this._lblCommon_12.Name = "_lblCommon_12";
			this._lblCommon_12.Size = new System.Drawing.Size(35, 13);
			this._lblCommon_12.TabIndex = 45;
			// 
			// _txtCommonTextBox_22
			// 
			this._txtCommonTextBox_22.AllowDrop = true;
			this._txtCommonTextBox_22.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_22.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_22.Location = new System.Drawing.Point(653, 37);
			this._txtCommonTextBox_22.Name = "_txtCommonTextBox_22";
			this._txtCommonTextBox_22.Size = new System.Drawing.Size(101, 19);
			this._txtCommonTextBox_22.TabIndex = 38;
			this._txtCommonTextBox_22.Text = "";
			// this.this._txtCommonTextBox_22.Watermark = "";
			// this.this._txtCommonTextBox_22.Change += new System.Windows.Forms.TextBox.ChangeHandler(this.txtCommonTextBox_Change);
			// this.this._txtCommonTextBox_22.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_22.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _lblCommon_13
			// 
			this._lblCommon_13.AllowDrop = true;
			this._lblCommon_13.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_13.Text = "Flat No.";
			this._lblCommon_13.Location = new System.Drawing.Point(203, 61);
			// // this._lblCommon_13.mLabelId = 1071;
			this._lblCommon_13.Name = "_lblCommon_13";
			this._lblCommon_13.Size = new System.Drawing.Size(38, 13);
			this._lblCommon_13.TabIndex = 46;
			// 
			// _txtCommonTextBox_24
			// 
			this._txtCommonTextBox_24.AllowDrop = true;
			this._txtCommonTextBox_24.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_24.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_24.Location = new System.Drawing.Point(277, 58);
			this._txtCommonTextBox_24.Name = "_txtCommonTextBox_24";
			this._txtCommonTextBox_24.Size = new System.Drawing.Size(101, 19);
			this._txtCommonTextBox_24.TabIndex = 54;
			this._txtCommonTextBox_24.Text = "";
			// this.this._txtCommonTextBox_24.Watermark = "";
			// this.this._txtCommonTextBox_24.Change += new System.Windows.Forms.TextBox.ChangeHandler(this.txtCommonTextBox_Change);
			// this.this._txtCommonTextBox_24.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_24.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _lblCommon_14
			// 
			this._lblCommon_14.AllowDrop = true;
			this._lblCommon_14.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_14.Text = "Floor";
			this._lblCommon_14.Location = new System.Drawing.Point(6, 61);
			// // this._lblCommon_14.mLabelId = 1065;
			this._lblCommon_14.Name = "_lblCommon_14";
			this._lblCommon_14.Size = new System.Drawing.Size(24, 13);
			this._lblCommon_14.TabIndex = 47;
			// 
			// _lblCommon_15
			// 
			this._lblCommon_15.AllowDrop = true;
			this._lblCommon_15.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_15.Text = "Building No.";
			this._lblCommon_15.Location = new System.Drawing.Point(389, 40);
			// // this._lblCommon_15.mLabelId = 1070;
			this._lblCommon_15.Name = "_lblCommon_15";
			this._lblCommon_15.Size = new System.Drawing.Size(56, 13);
			this._lblCommon_15.TabIndex = 48;
			// 
			// _txtCommonTextBox_21
			// 
			this._txtCommonTextBox_21.AllowDrop = true;
			this._txtCommonTextBox_21.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_21.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_21.Location = new System.Drawing.Point(463, 37);
			this._txtCommonTextBox_21.Name = "_txtCommonTextBox_21";
			this._txtCommonTextBox_21.Size = new System.Drawing.Size(101, 19);
			this._txtCommonTextBox_21.TabIndex = 37;
			this._txtCommonTextBox_21.Text = "";
			// this.this._txtCommonTextBox_21.Watermark = "";
			// this.this._txtCommonTextBox_21.Change += new System.Windows.Forms.TextBox.ChangeHandler(this.txtCommonTextBox_Change);
			// this.this._txtCommonTextBox_21.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_21.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _lblCommon_16
			// 
			this._lblCommon_16.AllowDrop = true;
			this._lblCommon_16.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_16.Text = "Type Of Building";
			this._lblCommon_16.Location = new System.Drawing.Point(6, 40);
			// // this._lblCommon_16.mLabelId = 1064;
			this._lblCommon_16.Name = "_lblCommon_16";
			this._lblCommon_16.Size = new System.Drawing.Size(78, 13);
			this._lblCommon_16.TabIndex = 49;
			// 
			// _lblCommon_17
			// 
			this._lblCommon_17.AllowDrop = true;
			this._lblCommon_17.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_17.Text = "Lane";
			this._lblCommon_17.Location = new System.Drawing.Point(203, 40);
			// // this._lblCommon_17.mLabelId = 1069;
			this._lblCommon_17.Name = "_lblCommon_17";
			this._lblCommon_17.Size = new System.Drawing.Size(23, 13);
			this._lblCommon_17.TabIndex = 50;
			// 
			// _txtCommonTextBox_19
			// 
			this._txtCommonTextBox_19.AllowDrop = true;
			this._txtCommonTextBox_19.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_19.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_19.Location = new System.Drawing.Point(277, 37);
			this._txtCommonTextBox_19.Name = "_txtCommonTextBox_19";
			this._txtCommonTextBox_19.Size = new System.Drawing.Size(101, 19);
			this._txtCommonTextBox_19.TabIndex = 35;
			this._txtCommonTextBox_19.Text = "";
			// this.this._txtCommonTextBox_19.Watermark = "";
			// this.this._txtCommonTextBox_19.Change += new System.Windows.Forms.TextBox.ChangeHandler(this.txtCommonTextBox_Change);
			// this.this._txtCommonTextBox_19.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_19.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _lblCommon_18
			// 
			this._lblCommon_18.AllowDrop = true;
			this._lblCommon_18.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_18.Text = "Street";
			this._lblCommon_18.Location = new System.Drawing.Point(389, 19);
			// // this._lblCommon_18.mLabelId = 1983;
			this._lblCommon_18.Name = "_lblCommon_18";
			this._lblCommon_18.Size = new System.Drawing.Size(30, 13);
			this._lblCommon_18.TabIndex = 51;
			// 
			// _txtCommonTextBox_18
			// 
			this._txtCommonTextBox_18.AllowDrop = true;
			this._txtCommonTextBox_18.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_18.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_18.Location = new System.Drawing.Point(463, 16);
			this._txtCommonTextBox_18.Name = "_txtCommonTextBox_18";
			this._txtCommonTextBox_18.Size = new System.Drawing.Size(101, 19);
			this._txtCommonTextBox_18.TabIndex = 34;
			this._txtCommonTextBox_18.Text = "";
			// this.this._txtCommonTextBox_18.Watermark = "";
			// this.this._txtCommonTextBox_18.Change += new System.Windows.Forms.TextBox.ChangeHandler(this.txtCommonTextBox_Change);
			// this.this._txtCommonTextBox_18.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_18.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _lblCommon_19
			// 
			this._lblCommon_19.AllowDrop = true;
			this._lblCommon_19.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_19.Text = "Block";
			this._lblCommon_19.Location = new System.Drawing.Point(203, 19);
			// // this._lblCommon_19.mLabelId = 1941;
			this._lblCommon_19.Name = "_lblCommon_19";
			this._lblCommon_19.Size = new System.Drawing.Size(24, 13);
			this._lblCommon_19.TabIndex = 52;
			// 
			// _txtCommonTextBox_17
			// 
			this._txtCommonTextBox_17.AllowDrop = true;
			this._txtCommonTextBox_17.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_17.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_17.Location = new System.Drawing.Point(277, 16);
			this._txtCommonTextBox_17.Name = "_txtCommonTextBox_17";
			this._txtCommonTextBox_17.Size = new System.Drawing.Size(101, 19);
			this._txtCommonTextBox_17.TabIndex = 33;
			this._txtCommonTextBox_17.Text = "";
			// this.this._txtCommonTextBox_17.Watermark = "";
			// this.this._txtCommonTextBox_17.Change += new System.Windows.Forms.TextBox.ChangeHandler(this.txtCommonTextBox_Change);
			// this.this._txtCommonTextBox_17.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_17.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _lblCommon_20
			// 
			this._lblCommon_20.AllowDrop = true;
			this._lblCommon_20.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_20.Text = "Area";
			this._lblCommon_20.Location = new System.Drawing.Point(6, 19);
			// // this._lblCommon_20.mLabelId = 1063;
			this._lblCommon_20.Name = "_lblCommon_20";
			this._lblCommon_20.Size = new System.Drawing.Size(23, 13);
			this._lblCommon_20.TabIndex = 53;
			// 
			// _lblCommon_21
			// 
			this._lblCommon_21.AllowDrop = true;
			this._lblCommon_21.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_21.Text = "Email Address";
			this._lblCommon_21.Location = new System.Drawing.Point(203, 106);
			// // this._lblCommon_21.mLabelId = 899;
			this._lblCommon_21.Name = "_lblCommon_21";
			this._lblCommon_21.Size = new System.Drawing.Size(66, 13);
			this._lblCommon_21.TabIndex = 63;
			// 
			// _lblCommon_22
			// 
			this._lblCommon_22.AllowDrop = true;
			this._lblCommon_22.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_22.Text = "Pager No.";
			this._lblCommon_22.Location = new System.Drawing.Point(6, 103);
			// // this._lblCommon_22.mLabelId = 1068;
			this._lblCommon_22.Name = "_lblCommon_22";
			this._lblCommon_22.Size = new System.Drawing.Size(48, 13);
			this._lblCommon_22.TabIndex = 64;
			// 
			// _lblCommon_24
			// 
			this._lblCommon_24.AllowDrop = true;
			this._lblCommon_24.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_24.Text = "Address3";
			this._lblCommon_24.Location = new System.Drawing.Point(9, 188);
			// // this._lblCommon_24.mLabelId = 2243;
			this._lblCommon_24.Name = "_lblCommon_24";
			this._lblCommon_24.Size = new System.Drawing.Size(45, 13);
			this._lblCommon_24.TabIndex = 72;
			// 
			// _txtCommonTextBox_34
			// 
			this._txtCommonTextBox_34.AllowDrop = true;
			this._txtCommonTextBox_34.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_34.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_34.Location = new System.Drawing.Point(89, 185);
			this._txtCommonTextBox_34.Name = "_txtCommonTextBox_34";
			this._txtCommonTextBox_34.Size = new System.Drawing.Size(667, 19);
			this._txtCommonTextBox_34.TabIndex = 75;
			this._txtCommonTextBox_34.Text = "";
			// this.this._txtCommonTextBox_34.Watermark = "";
			// this.this._txtCommonTextBox_34.Change += new System.Windows.Forms.TextBox.ChangeHandler(this.txtCommonTextBox_Change);
			// this.this._txtCommonTextBox_34.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_34.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _lblCommon_25
			// 
			this._lblCommon_25.AllowDrop = true;
			this._lblCommon_25.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_25.Text = "Address2";
			this._lblCommon_25.Location = new System.Drawing.Point(9, 167);
			// // this._lblCommon_25.mLabelId = 2242;
			this._lblCommon_25.Name = "_lblCommon_25";
			this._lblCommon_25.Size = new System.Drawing.Size(45, 13);
			this._lblCommon_25.TabIndex = 73;
			// 
			// _txtCommonTextBox_33
			// 
			this._txtCommonTextBox_33.AllowDrop = true;
			this._txtCommonTextBox_33.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_33.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_33.Location = new System.Drawing.Point(89, 164);
			this._txtCommonTextBox_33.Name = "_txtCommonTextBox_33";
			this._txtCommonTextBox_33.Size = new System.Drawing.Size(667, 19);
			this._txtCommonTextBox_33.TabIndex = 74;
			this._txtCommonTextBox_33.Text = "";
			// this.this._txtCommonTextBox_33.Watermark = "";
			// this.this._txtCommonTextBox_33.Change += new System.Windows.Forms.TextBox.ChangeHandler(this.txtCommonTextBox_Change);
			// this.this._txtCommonTextBox_33.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_33.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _lblCommon_26
			// 
			this._lblCommon_26.AllowDrop = true;
			this._lblCommon_26.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_26.Text = "Address1";
			this._lblCommon_26.Location = new System.Drawing.Point(9, 146);
			// // this._lblCommon_26.mLabelId = 2241;
			this._lblCommon_26.Name = "_lblCommon_26";
			this._lblCommon_26.Size = new System.Drawing.Size(45, 13);
			this._lblCommon_26.TabIndex = 69;
			// 
			// _txtCommonTextBox_32
			// 
			this._txtCommonTextBox_32.AllowDrop = true;
			this._txtCommonTextBox_32.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_32.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_32.Location = new System.Drawing.Point(89, 143);
			this._txtCommonTextBox_32.Name = "_txtCommonTextBox_32";
			this._txtCommonTextBox_32.Size = new System.Drawing.Size(667, 19);
			this._txtCommonTextBox_32.TabIndex = 71;
			this._txtCommonTextBox_32.Text = "";
			// this.this._txtCommonTextBox_32.Watermark = "";
			// this.this._txtCommonTextBox_32.Change += new System.Windows.Forms.TextBox.ChangeHandler(this.txtCommonTextBox_Change);
			// this.this._txtCommonTextBox_32.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_32.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _txtCommonTextBox_35
			// 
			this._txtCommonTextBox_35.AllowDrop = true;
			this._txtCommonTextBox_35.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_35.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_35.Location = new System.Drawing.Point(277, 80);
			this._txtCommonTextBox_35.Name = "_txtCommonTextBox_35";
			this._txtCommonTextBox_35.Size = new System.Drawing.Size(101, 19);
			this._txtCommonTextBox_35.TabIndex = 61;
			this._txtCommonTextBox_35.Text = "";
			// this.this._txtCommonTextBox_35.Watermark = "";
			// this.this._txtCommonTextBox_35.Change += new System.Windows.Forms.TextBox.ChangeHandler(this.txtCommonTextBox_Change);
			// this.this._txtCommonTextBox_35.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_35.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _lblCommon_36
			// 
			this._lblCommon_36.AllowDrop = true;
			this._lblCommon_36.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_36.Text = "Fax No.";
			this._lblCommon_36.Location = new System.Drawing.Point(575, 82);
			// // this._lblCommon_36.mLabelId = 1076;
			this._lblCommon_36.Name = "_lblCommon_36";
			this._lblCommon_36.Size = new System.Drawing.Size(38, 13);
			this._lblCommon_36.TabIndex = 65;
			// 
			// _txtCommonTextBox_37
			// 
			this._txtCommonTextBox_37.AllowDrop = true;
			this._txtCommonTextBox_37.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_37.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_37.Location = new System.Drawing.Point(653, 79);
			this._txtCommonTextBox_37.Name = "_txtCommonTextBox_37";
			this._txtCommonTextBox_37.Size = new System.Drawing.Size(101, 19);
			this._txtCommonTextBox_37.TabIndex = 62;
			this._txtCommonTextBox_37.Text = "";
			// this.this._txtCommonTextBox_37.Watermark = "";
			// this.this._txtCommonTextBox_37.Change += new System.Windows.Forms.TextBox.ChangeHandler(this.txtCommonTextBox_Change);
			// this.this._txtCommonTextBox_37.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_37.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _lblCommon_65
			// 
			this._lblCommon_65.AllowDrop = true;
			this._lblCommon_65.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_65.Text = "GL Segment";
			this._lblCommon_65.Location = new System.Drawing.Point(14, 235);
			this._lblCommon_65.Name = "_lblCommon_65";
			this._lblCommon_65.Size = new System.Drawing.Size(57, 13);
			this._lblCommon_65.TabIndex = 78;
			// 
			// _lblCommon_66
			// 
			this._lblCommon_66.AllowDrop = true;
			this._lblCommon_66.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_66.Text = " Analysis1";
			this._lblCommon_66.Location = new System.Drawing.Point(8, 259);
			// // this._lblCommon_66.mLabelId = 2202;
			this._lblCommon_66.Name = "_lblCommon_66";
			this._lblCommon_66.Size = new System.Drawing.Size(48, 13);
			this._lblCommon_66.TabIndex = 79;
			// 
			// _lblCommon_67
			// 
			this._lblCommon_67.AllowDrop = true;
			this._lblCommon_67.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_67.Text = " Analysis2";
			this._lblCommon_67.Location = new System.Drawing.Point(167, 259);
			// // this._lblCommon_67.mLabelId = 2203;
			this._lblCommon_67.Name = "_lblCommon_67";
			this._lblCommon_67.Size = new System.Drawing.Size(48, 13);
			this._lblCommon_67.TabIndex = 81;
			// 
			// _lblCommon_69
			// 
			this._lblCommon_69.AllowDrop = true;
			this._lblCommon_69.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_69.Text = " Analysis3";
			this._lblCommon_69.Location = new System.Drawing.Point(326, 259);
			// // this._lblCommon_69.mLabelId = 2204;
			this._lblCommon_69.Name = "_lblCommon_69";
			this._lblCommon_69.Size = new System.Drawing.Size(48, 13);
			this._lblCommon_69.TabIndex = 83;
			// 
			// _lblCommon_71
			// 
			this._lblCommon_71.AllowDrop = true;
			this._lblCommon_71.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_71.Text = " Analysis4";
			this._lblCommon_71.Location = new System.Drawing.Point(482, 259);
			// // this._lblCommon_71.mLabelId = 2205;
			this._lblCommon_71.Name = "_lblCommon_71";
			this._lblCommon_71.Size = new System.Drawing.Size(48, 13);
			this._lblCommon_71.TabIndex = 85;
			// 
			// _lblCommon_72
			// 
			this._lblCommon_72.AllowDrop = true;
			this._lblCommon_72.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_72.Text = " Analysis5";
			this._lblCommon_72.Location = new System.Drawing.Point(635, 259);
			// // this._lblCommon_72.mLabelId = 2206;
			this._lblCommon_72.Name = "_lblCommon_72";
			this._lblCommon_72.Size = new System.Drawing.Size(48, 13);
			this._lblCommon_72.TabIndex = 87;
			// 
			// _txtCommonTextBox_65
			// 
			this._txtCommonTextBox_65.AllowDrop = true;
			this._txtCommonTextBox_65.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_65.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_65.Location = new System.Drawing.Point(71, 256);
			this._txtCommonTextBox_65.Name = "_txtCommonTextBox_65";
			this._txtCommonTextBox_65.Size = new System.Drawing.Size(83, 19);
			this._txtCommonTextBox_65.TabIndex = 80;
			this._txtCommonTextBox_65.Text = "";
			// this.this._txtCommonTextBox_65.Watermark = "";
			// this.this._txtCommonTextBox_65.Change += new System.Windows.Forms.TextBox.ChangeHandler(this.txtCommonTextBox_Change);
			// this.this._txtCommonTextBox_65.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_65.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _txtCommonTextBox_66
			// 
			this._txtCommonTextBox_66.AllowDrop = true;
			this._txtCommonTextBox_66.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_66.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_66.Location = new System.Drawing.Point(227, 256);
			this._txtCommonTextBox_66.Name = "_txtCommonTextBox_66";
			this._txtCommonTextBox_66.Size = new System.Drawing.Size(86, 19);
			this._txtCommonTextBox_66.TabIndex = 82;
			this._txtCommonTextBox_66.Text = "";
			// this.this._txtCommonTextBox_66.Watermark = "";
			// this.this._txtCommonTextBox_66.Change += new System.Windows.Forms.TextBox.ChangeHandler(this.txtCommonTextBox_Change);
			// this.this._txtCommonTextBox_66.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_66.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _txtCommonTextBox_67
			// 
			this._txtCommonTextBox_67.AllowDrop = true;
			this._txtCommonTextBox_67.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_67.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_67.Location = new System.Drawing.Point(383, 256);
			this._txtCommonTextBox_67.Name = "_txtCommonTextBox_67";
			this._txtCommonTextBox_67.Size = new System.Drawing.Size(86, 19);
			this._txtCommonTextBox_67.TabIndex = 84;
			this._txtCommonTextBox_67.Text = "";
			// this.this._txtCommonTextBox_67.Watermark = "";
			// this.this._txtCommonTextBox_67.Change += new System.Windows.Forms.TextBox.ChangeHandler(this.txtCommonTextBox_Change);
			// this.this._txtCommonTextBox_67.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_67.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _txtCommonTextBox_68
			// 
			this._txtCommonTextBox_68.AllowDrop = true;
			this._txtCommonTextBox_68.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_68.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_68.Location = new System.Drawing.Point(539, 256);
			this._txtCommonTextBox_68.Name = "_txtCommonTextBox_68";
			this._txtCommonTextBox_68.Size = new System.Drawing.Size(86, 19);
			this._txtCommonTextBox_68.TabIndex = 86;
			this._txtCommonTextBox_68.Text = "";
			// this.this._txtCommonTextBox_68.Watermark = "";
			// this.this._txtCommonTextBox_68.Change += new System.Windows.Forms.TextBox.ChangeHandler(this.txtCommonTextBox_Change);
			// this.this._txtCommonTextBox_68.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_68.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _txtCommonTextBox_69
			// 
			this._txtCommonTextBox_69.AllowDrop = true;
			this._txtCommonTextBox_69.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_69.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_69.Location = new System.Drawing.Point(689, 256);
			this._txtCommonTextBox_69.Name = "_txtCommonTextBox_69";
			this._txtCommonTextBox_69.Size = new System.Drawing.Size(86, 19);
			this._txtCommonTextBox_69.TabIndex = 88;
			this._txtCommonTextBox_69.Text = "";
			// this.this._txtCommonTextBox_69.Watermark = "";
			// this.this._txtCommonTextBox_69.Change += new System.Windows.Forms.TextBox.ChangeHandler(this.txtCommonTextBox_Change);
			// this.this._txtCommonTextBox_69.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_69.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _lblCommon_2
			// 
			this._lblCommon_2.AllowDrop = true;
			this._lblCommon_2.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._lblCommon_2.Text = "Telephone No.";
			this._lblCommon_2.Location = new System.Drawing.Point(322, 109);
			// // this._lblCommon_2.mLabelId = 1067;
			this._lblCommon_2.Name = "_lblCommon_2";
			this._lblCommon_2.Size = new System.Drawing.Size(70, 13);
			this._lblCommon_2.TabIndex = 41;
			this._lblCommon_2.Visible = false;
			// 
			// _txtCommonTextBox_28
			// 
			this._txtCommonTextBox_28.AllowDrop = true;
			this._txtCommonTextBox_28.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_28.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_28.Location = new System.Drawing.Point(402, 103);
			this._txtCommonTextBox_28.Name = "_txtCommonTextBox_28";
			this._txtCommonTextBox_28.Size = new System.Drawing.Size(14, 19);
			this._txtCommonTextBox_28.TabIndex = 67;
			this._txtCommonTextBox_28.Text = "";
			this._txtCommonTextBox_28.Visible = false;
			// this.this._txtCommonTextBox_28.Watermark = "";
			// this.this._txtCommonTextBox_28.Change += new System.Windows.Forms.TextBox.ChangeHandler(this.txtCommonTextBox_Change);
			// this.this._txtCommonTextBox_28.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_28.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _txtCommonTextBox_27
			// 
			this._txtCommonTextBox_27.AllowDrop = true;
			this._txtCommonTextBox_27.BackColor = System.Drawing.Color.White;
			// this._txtCommonTextBox_27.bolNumericOnly = true;
			this._txtCommonTextBox_27.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_27.Location = new System.Drawing.Point(90, 79);
			this._txtCommonTextBox_27.Name = "_txtCommonTextBox_27";
			this._txtCommonTextBox_27.Size = new System.Drawing.Size(101, 19);
			this._txtCommonTextBox_27.TabIndex = 57;
			this._txtCommonTextBox_27.Text = "";
			// this.this._txtCommonTextBox_27.Watermark = "";
			// this.this._txtCommonTextBox_27.Change += new System.Windows.Forms.TextBox.ChangeHandler(this.txtCommonTextBox_Change);
			// this.this._txtCommonTextBox_27.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_27.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _txtCommonTextBox_23
			// 
			this._txtCommonTextBox_23.AllowDrop = true;
			this._txtCommonTextBox_23.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_23.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_23.Location = new System.Drawing.Point(90, 58);
			this._txtCommonTextBox_23.Name = "_txtCommonTextBox_23";
			this._txtCommonTextBox_23.Size = new System.Drawing.Size(101, 19);
			this._txtCommonTextBox_23.TabIndex = 39;
			this._txtCommonTextBox_23.Text = "";
			// this.this._txtCommonTextBox_23.Watermark = "";
			// this.this._txtCommonTextBox_23.Change += new System.Windows.Forms.TextBox.ChangeHandler(this.txtCommonTextBox_Change);
			// this.this._txtCommonTextBox_23.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_23.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _txtCommonTextBox_20
			// 
			this._txtCommonTextBox_20.AllowDrop = true;
			this._txtCommonTextBox_20.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_20.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_20.Location = new System.Drawing.Point(90, 37);
			this._txtCommonTextBox_20.Name = "_txtCommonTextBox_20";
			this._txtCommonTextBox_20.Size = new System.Drawing.Size(101, 19);
			this._txtCommonTextBox_20.TabIndex = 36;
			this._txtCommonTextBox_20.Text = "";
			// this.this._txtCommonTextBox_20.Watermark = "";
			// this.this._txtCommonTextBox_20.Change += new System.Windows.Forms.TextBox.ChangeHandler(this.txtCommonTextBox_Change);
			// this.this._txtCommonTextBox_20.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_20.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _txtCommonTextBox_16
			// 
			this._txtCommonTextBox_16.AllowDrop = true;
			this._txtCommonTextBox_16.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_16.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_16.Location = new System.Drawing.Point(90, 16);
			this._txtCommonTextBox_16.Name = "_txtCommonTextBox_16";
			this._txtCommonTextBox_16.Size = new System.Drawing.Size(101, 19);
			this._txtCommonTextBox_16.TabIndex = 32;
			this._txtCommonTextBox_16.Text = "";
			// this.this._txtCommonTextBox_16.Watermark = "";
			// this.this._txtCommonTextBox_16.Change += new System.Windows.Forms.TextBox.ChangeHandler(this.txtCommonTextBox_Change);
			// this.this._txtCommonTextBox_16.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_16.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _txtCommonTextBox_30
			// 
			this._txtCommonTextBox_30.AllowDrop = true;
			this._txtCommonTextBox_30.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_30.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_30.Location = new System.Drawing.Point(90, 100);
			this._txtCommonTextBox_30.Name = "_txtCommonTextBox_30";
			this._txtCommonTextBox_30.Size = new System.Drawing.Size(101, 19);
			this._txtCommonTextBox_30.TabIndex = 60;
			this._txtCommonTextBox_30.Text = "";
			// this.this._txtCommonTextBox_30.Watermark = "";
			// this.this._txtCommonTextBox_30.Change += new System.Windows.Forms.TextBox.ChangeHandler(this.txtCommonTextBox_Change);
			// this.this._txtCommonTextBox_30.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_30.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// Shape3
			// 
			this.Shape3.AllowDrop = true;
			this.Shape3.BackColor = System.Drawing.SystemColors.Window;
			this.Shape3.BackStyle = 0;
			this.Shape3.BorderStyle = 1;
			this.Shape3.Enabled = false;
			this.Shape3.FillColor = System.Drawing.Color.Black;
			this.Shape3.FillStyle = 1;
			this.Shape3.Location = new System.Drawing.Point(4, 241);
			this.Shape3.Name = "Shape3";
			this.Shape3.Size = new System.Drawing.Size(775, 47);
			this.Shape3.Visible = true;
			// 
			// Shape1
			// 
			this.Shape1.AllowDrop = true;
			this.Shape1.BackColor = System.Drawing.SystemColors.Window;
			this.Shape1.BackStyle = 0;
			this.Shape1.BorderStyle = 1;
			this.Shape1.Enabled = false;
			this.Shape1.FillColor = System.Drawing.Color.Black;
			this.Shape1.FillStyle = 1;
			this.Shape1.Location = new System.Drawing.Point(4, 8);
			this.Shape1.Name = "Shape1";
			this.Shape1.Size = new System.Drawing.Size(778, 119);
			this.Shape1.Visible = true;
			// 
			// Shape2
			// 
			this.Shape2.AllowDrop = true;
			this.Shape2.BackColor = System.Drawing.SystemColors.Window;
			this.Shape2.BackStyle = 0;
			this.Shape2.BorderStyle = 1;
			this.Shape2.Enabled = false;
			this.Shape2.FillColor = System.Drawing.Color.Black;
			this.Shape2.FillStyle = 1;
			this.Shape2.Location = new System.Drawing.Point(4, 134);
			this.Shape2.Name = "Shape2";
			this.Shape2.Size = new System.Drawing.Size(775, 98);
			this.Shape2.Visible = true;
			// 
			// TabControlPage3
			// 
			this.TabControlPage3.AllowDrop = true;
			this.TabControlPage3.Controls.Add(this._fraEmployeeInformation_2);
			this.TabControlPage3.Location = new System.Drawing.Point(-4664, 28);
			this.TabControlPage3.Name = "TabControlPage3";
			("TabControlPage3.OcxState");
			this.TabControlPage3.Size = new System.Drawing.Size(863, 353);
			this.TabControlPage3.TabIndex = 89;
			this.TabControlPage3.Visible = false;
			// 
			// _fraEmployeeInformation_2
			// 
			this._fraEmployeeInformation_2.AllowDrop = true;
			this._fraEmployeeInformation_2.Controls.Add(this.frmRasidence);
			this._fraEmployeeInformation_2.Controls.Add(this.Label5);
			this._fraEmployeeInformation_2.Controls.Add(this.txtLoginID);
			this._fraEmployeeInformation_2.Controls.Add(this.Label4);
			this._fraEmployeeInformation_2.Controls.Add(this.txtDlblDefaultProject);
			this._fraEmployeeInformation_2.Controls.Add(this.txtDefaultProject);
			this._fraEmployeeInformation_2.Controls.Add(this._lblCommon_27);
			this._fraEmployeeInformation_2.Controls.Add(this._txtCommonTextBox_40);
			this._fraEmployeeInformation_2.Controls.Add(this._lblCommon_28);
			this._fraEmployeeInformation_2.Controls.Add(this._txtCommonTextBox_41);
			this._fraEmployeeInformation_2.Controls.Add(this._lblCommon_29);
			this._fraEmployeeInformation_2.Controls.Add(this._txtCommonTextBox_42);
			this._fraEmployeeInformation_2.Controls.Add(this._lblCommon_31);
			this._fraEmployeeInformation_2.Controls.Add(this._txtCommonTextBox_43);
			this._fraEmployeeInformation_2.Controls.Add(this._lblCommon_32);
			this._fraEmployeeInformation_2.Controls.Add(this._lblCommon_115);
			this._fraEmployeeInformation_2.Controls.Add(this._lblCommon_33);
			this._fraEmployeeInformation_2.Controls.Add(this._txtCommonTextBox_46);
			this._fraEmployeeInformation_2.Controls.Add(this._lblCommon_34);
			this._fraEmployeeInformation_2.Controls.Add(this._txtCommonTextBox_47);
			this._fraEmployeeInformation_2.Controls.Add(this._lblCommon_35);
			this._fraEmployeeInformation_2.Controls.Add(this._txtCommonTextBox_48);
			this._fraEmployeeInformation_2.Controls.Add(this._txtCommonTextBox_44);
			this._fraEmployeeInformation_2.Controls.Add(this._txtCommonTextBox_45);
			this._fraEmployeeInformation_2.Controls.Add(this._txtDisplayLabel_15);
			this._fraEmployeeInformation_2.Controls.Add(this._txtCommonTextBox_54);
			this._fraEmployeeInformation_2.Controls.Add(this._txtCommonTextBox_55);
			this._fraEmployeeInformation_2.Controls.Add(this._lblCommon_44);
			this._fraEmployeeInformation_2.Controls.Add(this._lblCommon_45);
			this._fraEmployeeInformation_2.Controls.Add(this._txtCommonTextBox_53);
			this._fraEmployeeInformation_2.Controls.Add(this._lblCommon_43);
			this._fraEmployeeInformation_2.Controls.Add(this.lblDefaultProject);
			this._fraEmployeeInformation_2.Controls.Add(this._lblCommon_60);
			this._fraEmployeeInformation_2.Controls.Add(this._lblCommon_61);
			this._fraEmployeeInformation_2.Controls.Add(this._lblCommon_62);
			this._fraEmployeeInformation_2.Controls.Add(this._lblCommon_63);
			this._fraEmployeeInformation_2.Controls.Add(this._txtCommonTextBox_60);
			this._fraEmployeeInformation_2.Controls.Add(this._txtCommonTextBox_61);
			this._fraEmployeeInformation_2.Controls.Add(this._lblCommon_64);
			this._fraEmployeeInformation_2.Controls.Add(this._txtCommonTextBox_62);
			this._fraEmployeeInformation_2.Controls.Add(this._txtCommonTextBox_63);
			this._fraEmployeeInformation_2.Controls.Add(this._txtCommonTextBox_64);
			this._fraEmployeeInformation_2.Location = new System.Drawing.Point(0, 0);
			this._fraEmployeeInformation_2.Name = "_fraEmployeeInformation_2";
			("_fraEmployeeInformation_2.OcxState");
			this._fraEmployeeInformation_2.Size = new System.Drawing.Size(793, 315);
			this._fraEmployeeInformation_2.TabIndex = 90;
			// 
			// frmRasidence
			// 
			this.frmRasidence.AllowDrop = true;
			this.frmRasidence.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.frmRasidence.Controls.Add(this._lblCommon_40);
			this.frmRasidence.Controls.Add(this._txtCommonTextBox_51);
			this.frmRasidence.Controls.Add(this._txtDisplayLabel_9);
			this.frmRasidence.Controls.Add(this._lblCommon_39);
			this.frmRasidence.Controls.Add(this._txtCommonTextBox_50);
			this.frmRasidence.Controls.Add(this._lblCommon_30);
			this.frmRasidence.Controls.Add(this._txtCommonTextBox_38);
			this.frmRasidence.Controls.Add(this._lblCommon_0);
			this.frmRasidence.Controls.Add(this._txtCommonTextBox_14);
			this.frmRasidence.Controls.Add(this._lblCommon_38);
			this.frmRasidence.Controls.Add(this._txtCommonTextBox_49);
			this.frmRasidence.Enabled = true;
			this.frmRasidence.ForeColor = System.Drawing.SystemColors.ControlText;
			this.frmRasidence.Location = new System.Drawing.Point(10, 223);
			this.frmRasidence.Name = "frmRasidence";
			this.frmRasidence.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.frmRasidence.Size = new System.Drawing.Size(775, 64);
			this.frmRasidence.TabIndex = 132;
			this.frmRasidence.Visible = true;
			// 
			// _lblCommon_40
			// 
			this._lblCommon_40.AllowDrop = true;
			this._lblCommon_40.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_40.Text = "Visa Type Code";
			this._lblCommon_40.Location = new System.Drawing.Point(3, 18);
			// // this._lblCommon_40.mLabelId = 1967;
			this._lblCommon_40.Name = "_lblCommon_40";
			this._lblCommon_40.Size = new System.Drawing.Size(74, 13);
			this._lblCommon_40.TabIndex = 142;
			// 
			// _txtCommonTextBox_51
			// 
			this._txtCommonTextBox_51.AllowDrop = true;
			this._txtCommonTextBox_51.BackColor = System.Drawing.Color.White;
			// this._txtCommonTextBox_51.bolNumericOnly = true;
			this._txtCommonTextBox_51.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_51.Location = new System.Drawing.Point(84, 15);
			this._txtCommonTextBox_51.MaxLength = 20;
			this._txtCommonTextBox_51.Name = "_txtCommonTextBox_51";
			// this._txtCommonTextBox_51.ShowButton = true;
			this._txtCommonTextBox_51.Size = new System.Drawing.Size(86, 19);
			this._txtCommonTextBox_51.TabIndex = 133;
			this._txtCommonTextBox_51.Text = "";
			// this.this._txtCommonTextBox_51.Watermark = "";
			// this.this._txtCommonTextBox_51.Change += new System.Windows.Forms.TextBox.ChangeHandler(this.txtCommonTextBox_Change);
			// this.this._txtCommonTextBox_51.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_51.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _txtDisplayLabel_9
			// 
			this._txtDisplayLabel_9.AllowDrop = true;
			this._txtDisplayLabel_9.Location = new System.Drawing.Point(171, 15);
			this._txtDisplayLabel_9.Name = "_txtDisplayLabel_9";
			this._txtDisplayLabel_9.Size = new System.Drawing.Size(243, 19);
			this._txtDisplayLabel_9.TabIndex = 134;
			this._txtDisplayLabel_9.TabStop = false;
			// 
			// _lblCommon_39
			// 
			this._lblCommon_39.AllowDrop = true;
			this._lblCommon_39.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_39.Text = "Visa No.";
			this._lblCommon_39.Location = new System.Drawing.Point(3, 41);
			// // this._lblCommon_39.mLabelId = 1968;
			this._lblCommon_39.Name = "_lblCommon_39";
			this._lblCommon_39.Size = new System.Drawing.Size(39, 13);
			this._lblCommon_39.TabIndex = 141;
			// 
			// _txtCommonTextBox_50
			// 
			this._txtCommonTextBox_50.AllowDrop = true;
			this._txtCommonTextBox_50.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_50.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_50.Location = new System.Drawing.Point(84, 39);
			this._txtCommonTextBox_50.MaxLength = 20;
			this._txtCommonTextBox_50.Name = "_txtCommonTextBox_50";
			this._txtCommonTextBox_50.Size = new System.Drawing.Size(86, 22);
			this._txtCommonTextBox_50.TabIndex = 138;
			this._txtCommonTextBox_50.Text = "";
			// this.this._txtCommonTextBox_50.Watermark = "";
			// this.this._txtCommonTextBox_50.Change += new System.Windows.Forms.TextBox.ChangeHandler(this.txtCommonTextBox_Change);
			// this.this._txtCommonTextBox_50.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_50.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _lblCommon_30
			// 
			this._lblCommon_30.AllowDrop = true;
			this._lblCommon_30.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_30.Text = "Civil Id";
			this._lblCommon_30.Location = new System.Drawing.Point(507, 41);
			// // this._lblCommon_30.mLabelId = 1930;
			this._lblCommon_30.Name = "_lblCommon_30";
			this._lblCommon_30.Size = new System.Drawing.Size(32, 13);
			this._lblCommon_30.TabIndex = 139;
			// 
			// _txtCommonTextBox_38
			// 
			this._txtCommonTextBox_38.AllowDrop = true;
			this._txtCommonTextBox_38.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_38.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_38.Location = new System.Drawing.Point(600, 39);
			this._txtCommonTextBox_38.MaxLength = 20;
			this._txtCommonTextBox_38.Name = "_txtCommonTextBox_38";
			this._txtCommonTextBox_38.Size = new System.Drawing.Size(167, 19);
			this._txtCommonTextBox_38.TabIndex = 143;
			this._txtCommonTextBox_38.Text = "";
			// this.this._txtCommonTextBox_38.Watermark = "";
			// this.this._txtCommonTextBox_38.Change += new System.Windows.Forms.TextBox.ChangeHandler(this.txtCommonTextBox_Change);
			// this.this._txtCommonTextBox_38.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_38.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _lblCommon_0
			// 
			this._lblCommon_0.AllowDrop = true;
			this._lblCommon_0.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_0.Text = "Passport No.";
			this._lblCommon_0.Location = new System.Drawing.Point(507, 18);
			// // this._lblCommon_0.mLabelId = 1550;
			this._lblCommon_0.Name = "_lblCommon_0";
			this._lblCommon_0.Size = new System.Drawing.Size(62, 13);
			this._lblCommon_0.TabIndex = 135;
			// 
			// _txtCommonTextBox_14
			// 
			this._txtCommonTextBox_14.AllowDrop = true;
			this._txtCommonTextBox_14.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_14.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_14.Location = new System.Drawing.Point(600, 15);
			this._txtCommonTextBox_14.MaxLength = 20;
			this._txtCommonTextBox_14.Name = "_txtCommonTextBox_14";
			this._txtCommonTextBox_14.Size = new System.Drawing.Size(167, 19);
			this._txtCommonTextBox_14.TabIndex = 136;
			this._txtCommonTextBox_14.Text = "";
			// this.this._txtCommonTextBox_14.Watermark = "";
			// this.this._txtCommonTextBox_14.Change += new System.Windows.Forms.TextBox.ChangeHandler(this.txtCommonTextBox_Change);
			// this.this._txtCommonTextBox_14.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_14.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _lblCommon_38
			// 
			this._lblCommon_38.AllowDrop = true;
			this._lblCommon_38.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_38.Text = "Work Permit No.";
			this._lblCommon_38.Location = new System.Drawing.Point(177, 41);
			// // this._lblCommon_38.mLabelId = 1966;
			this._lblCommon_38.Name = "_lblCommon_38";
			this._lblCommon_38.Size = new System.Drawing.Size(78, 13);
			this._lblCommon_38.TabIndex = 140;
			// 
			// _txtCommonTextBox_49
			// 
			this._txtCommonTextBox_49.AllowDrop = true;
			this._txtCommonTextBox_49.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_49.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_49.Location = new System.Drawing.Point(283, 39);
			this._txtCommonTextBox_49.MaxLength = 20;
			this._txtCommonTextBox_49.Name = "_txtCommonTextBox_49";
			this._txtCommonTextBox_49.Size = new System.Drawing.Size(131, 19);
			this._txtCommonTextBox_49.TabIndex = 137;
			this._txtCommonTextBox_49.Text = "";
			// this.this._txtCommonTextBox_49.Watermark = "";
			// this.this._txtCommonTextBox_49.Change += new System.Windows.Forms.TextBox.ChangeHandler(this.txtCommonTextBox_Change);
			// this.this._txtCommonTextBox_49.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_49.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// System.Windows.Forms.Label5
			// 
			this.Label5.AllowDrop = true;
			this.Label5.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.Label5.Text = "DomainName\\ UserName";
			this.Label5.Location = new System.Drawing.Point(664, 160);
			this.Label5.Name = "System.Windows.Forms.Label5";
			this.Label5.Size = new System.Drawing.Size(118, 14);
			this.Label5.TabIndex = 116;
			// 
			// txtLoginID
			// 
			this.txtLoginID.AllowDrop = true;
			this.txtLoginID.BackColor = System.Drawing.Color.White;
			// this.txtLoginID.bolAllowDecimal = false;
			this.txtLoginID.ForeColor = System.Drawing.Color.Black;
			this.txtLoginID.Location = new System.Drawing.Point(517, 159);
			// this.txtLoginID.mDropDownType = (System.Windows.Forms.TextBox.DropDownTypes) 0;
			this.txtLoginID.Name = "txtLoginID";
			this.txtLoginID.Size = new System.Drawing.Size(142, 19);
			this.txtLoginID.TabIndex = 126;
			this.txtLoginID.Text = "";
			// this.this.txtLoginID.Watermark = "";
			// 
			// System.Windows.Forms.Label4
			// 
			this.Label4.AllowDrop = true;
			this.Label4.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.Label4.Text = "Login ID";
			this.Label4.Location = new System.Drawing.Point(428, 161);
			this.Label4.Name = "System.Windows.Forms.Label4";
			this.Label4.Size = new System.Drawing.Size(38, 14);
			this.Label4.TabIndex = 125;
			// 
			// txtDlblDefaultProject
			// 
			this.txtDlblDefaultProject.AllowDrop = true;
			this.txtDlblDefaultProject.Enabled = false;
			this.txtDlblDefaultProject.Location = new System.Drawing.Point(607, 117);
			this.txtDlblDefaultProject.Name = "txtDlblDefaultProject";
			this.txtDlblDefaultProject.Size = new System.Drawing.Size(177, 19);
			this.txtDlblDefaultProject.TabIndex = 111;
			// 
			// txtDefaultProject
			// 
			this.txtDefaultProject.AllowDrop = true;
			this.txtDefaultProject.BackColor = System.Drawing.Color.White;
			// this.txtDefaultProject.bolAllowDecimal = false;
			this.txtDefaultProject.ForeColor = System.Drawing.Color.Black;
			this.txtDefaultProject.Location = new System.Drawing.Point(517, 117);
			// this.txtDefaultProject.mDropDownType = (System.Windows.Forms.TextBox.DropDownTypes) 0;
			this.txtDefaultProject.Name = "txtDefaultProject";
			// this.txtDefaultProject.ShowButton = true;
			this.txtDefaultProject.Size = new System.Drawing.Size(89, 19);
			this.txtDefaultProject.TabIndex = 110;
			this.txtDefaultProject.Text = "";
			// this.this.txtDefaultProject.Watermark = "";
			// this.this.txtDefaultProject.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtDefaultProject_DropButtonClick);
			// this.txtDefaultProject.Leave += new System.EventHandler(this.txtDefaultProject_Leave);
			// 
			// _lblCommon_27
			// 
			this._lblCommon_27.AllowDrop = true;
			this._lblCommon_27.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_27.Text = "Father Name (English)";
			this._lblCommon_27.Location = new System.Drawing.Point(11, 14);
			// // this._lblCommon_27.mLabelId = 2245;
			this._lblCommon_27.Name = "_lblCommon_27";
			this._lblCommon_27.Size = new System.Drawing.Size(106, 13);
			this._lblCommon_27.TabIndex = 91;
			// 
			// _txtCommonTextBox_40
			// 
			this._txtCommonTextBox_40.AllowDrop = true;
			this._txtCommonTextBox_40.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_40.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_40.Location = new System.Drawing.Point(127, 12);
			this._txtCommonTextBox_40.Name = "_txtCommonTextBox_40";
			this._txtCommonTextBox_40.Size = new System.Drawing.Size(659, 19);
			this._txtCommonTextBox_40.TabIndex = 92;
			this._txtCommonTextBox_40.Text = "";
			// this.this._txtCommonTextBox_40.Watermark = "";
			// this.this._txtCommonTextBox_40.Change += new System.Windows.Forms.TextBox.ChangeHandler(this.txtCommonTextBox_Change);
			// this.this._txtCommonTextBox_40.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_40.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _lblCommon_28
			// 
			this._lblCommon_28.AllowDrop = true;
			this._lblCommon_28.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_28.Text = "Father Name (Arabic)";
			this._lblCommon_28.Location = new System.Drawing.Point(11, 36);
			// // this._lblCommon_28.mLabelId = 2246;
			this._lblCommon_28.Name = "_lblCommon_28";
			this._lblCommon_28.Size = new System.Drawing.Size(103, 13);
			this._lblCommon_28.TabIndex = 93;
			// 
			// _txtCommonTextBox_41
			// 
			this._txtCommonTextBox_41.AllowDrop = true;
			this._txtCommonTextBox_41.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_41.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_41.Location = new System.Drawing.Point(127, 33);
			// this._txtCommonTextBox_41.mArabicEnabled = true;
			this._txtCommonTextBox_41.Name = "_txtCommonTextBox_41";
			this._txtCommonTextBox_41.Size = new System.Drawing.Size(659, 19);
			this._txtCommonTextBox_41.TabIndex = 94;
			this._txtCommonTextBox_41.Text = "";
			// this.this._txtCommonTextBox_41.Watermark = "";
			// this.this._txtCommonTextBox_41.Change += new System.Windows.Forms.TextBox.ChangeHandler(this.txtCommonTextBox_Change);
			// this.this._txtCommonTextBox_41.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_41.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _lblCommon_29
			// 
			this._lblCommon_29.AllowDrop = true;
			this._lblCommon_29.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_29.Text = "Mother Name (English)";
			this._lblCommon_29.Location = new System.Drawing.Point(11, 57);
			// // this._lblCommon_29.mLabelId = 2247;
			this._lblCommon_29.Name = "_lblCommon_29";
			this._lblCommon_29.Size = new System.Drawing.Size(108, 13);
			this._lblCommon_29.TabIndex = 95;
			// 
			// _txtCommonTextBox_42
			// 
			this._txtCommonTextBox_42.AllowDrop = true;
			this._txtCommonTextBox_42.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_42.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_42.Location = new System.Drawing.Point(127, 54);
			this._txtCommonTextBox_42.Name = "_txtCommonTextBox_42";
			this._txtCommonTextBox_42.Size = new System.Drawing.Size(659, 19);
			this._txtCommonTextBox_42.TabIndex = 96;
			this._txtCommonTextBox_42.Text = "";
			// this.this._txtCommonTextBox_42.Watermark = "";
			// this.this._txtCommonTextBox_42.Change += new System.Windows.Forms.TextBox.ChangeHandler(this.txtCommonTextBox_Change);
			// this.this._txtCommonTextBox_42.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_42.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _lblCommon_31
			// 
			this._lblCommon_31.AllowDrop = true;
			this._lblCommon_31.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_31.Text = "Mother Name (Arabic)";
			this._lblCommon_31.Location = new System.Drawing.Point(11, 78);
			// // this._lblCommon_31.mLabelId = 2248;
			this._lblCommon_31.Name = "_lblCommon_31";
			this._lblCommon_31.Size = new System.Drawing.Size(105, 13);
			this._lblCommon_31.TabIndex = 97;
			// 
			// _txtCommonTextBox_43
			// 
			this._txtCommonTextBox_43.AllowDrop = true;
			this._txtCommonTextBox_43.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_43.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_43.Location = new System.Drawing.Point(127, 75);
			// this._txtCommonTextBox_43.mArabicEnabled = true;
			this._txtCommonTextBox_43.Name = "_txtCommonTextBox_43";
			this._txtCommonTextBox_43.Size = new System.Drawing.Size(659, 19);
			this._txtCommonTextBox_43.TabIndex = 98;
			this._txtCommonTextBox_43.Text = "";
			// this.this._txtCommonTextBox_43.Watermark = "";
			// this.this._txtCommonTextBox_43.Change += new System.Windows.Forms.TextBox.ChangeHandler(this.txtCommonTextBox_Change);
			// this.this._txtCommonTextBox_43.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_43.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _lblCommon_32
			// 
			this._lblCommon_32.AllowDrop = true;
			this._lblCommon_32.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_32.Text = "Place Of Birth";
			this._lblCommon_32.Location = new System.Drawing.Point(11, 99);
			// // this._lblCommon_32.mLabelId = 1985;
			this._lblCommon_32.Name = "_lblCommon_32";
			this._lblCommon_32.Size = new System.Drawing.Size(65, 13);
			this._lblCommon_32.TabIndex = 99;
			// 
			// _lblCommon_115
			// 
			this._lblCommon_115.AllowDrop = true;
			this._lblCommon_115.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_115.Text = "Qualification Code";
			this._lblCommon_115.Location = new System.Drawing.Point(11, 161);
			// // this._lblCommon_115.mLabelId = 1082;
			this._lblCommon_115.Name = "_lblCommon_115";
			this._lblCommon_115.Size = new System.Drawing.Size(87, 14);
			this._lblCommon_115.TabIndex = 122;
			// 
			// _lblCommon_33
			// 
			this._lblCommon_33.AllowDrop = true;
			this._lblCommon_33.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_33.Text = "Blood Group";
			this._lblCommon_33.Location = new System.Drawing.Point(617, 98);
			// // this._lblCommon_33.mLabelId = 1083;
			this._lblCommon_33.Name = "_lblCommon_33";
			this._lblCommon_33.Size = new System.Drawing.Size(58, 13);
			this._lblCommon_33.TabIndex = 102;
			// 
			// _txtCommonTextBox_46
			// 
			this._txtCommonTextBox_46.AllowDrop = true;
			this._txtCommonTextBox_46.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_46.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_46.Location = new System.Drawing.Point(695, 96);
			this._txtCommonTextBox_46.Name = "_txtCommonTextBox_46";
			this._txtCommonTextBox_46.Size = new System.Drawing.Size(89, 19);
			this._txtCommonTextBox_46.TabIndex = 105;
			this._txtCommonTextBox_46.Text = "";
			// this.this._txtCommonTextBox_46.Watermark = "";
			// this.this._txtCommonTextBox_46.Change += new System.Windows.Forms.TextBox.ChangeHandler(this.txtCommonTextBox_Change);
			// this.this._txtCommonTextBox_46.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_46.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _lblCommon_34
			// 
			this._lblCommon_34.AllowDrop = true;
			this._lblCommon_34.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_34.Text = "No. of Wives";
			this._lblCommon_34.Location = new System.Drawing.Point(232, 99);
			// // this._lblCommon_34.mLabelId = 1084;
			this._lblCommon_34.Name = "_lblCommon_34";
			this._lblCommon_34.Size = new System.Drawing.Size(62, 13);
			this._lblCommon_34.TabIndex = 103;
			// 
			// _txtCommonTextBox_47
			// 
			this._txtCommonTextBox_47.AllowDrop = true;
			this._txtCommonTextBox_47.BackColor = System.Drawing.Color.White;
			// this._txtCommonTextBox_47.bolAllowDecimal = false;
			// this._txtCommonTextBox_47.bolNumericOnly = true;
			this._txtCommonTextBox_47.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_47.Location = new System.Drawing.Point(359, 96);
			this._txtCommonTextBox_47.MaxLength = 2;
			this._txtCommonTextBox_47.Name = "_txtCommonTextBox_47";
			this._txtCommonTextBox_47.Size = new System.Drawing.Size(60, 19);
			this._txtCommonTextBox_47.TabIndex = 101;
			this._txtCommonTextBox_47.Text = "";
			// this.this._txtCommonTextBox_47.Watermark = "";
			// this.this._txtCommonTextBox_47.Change += new System.Windows.Forms.TextBox.ChangeHandler(this.txtCommonTextBox_Change);
			// this.this._txtCommonTextBox_47.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_47.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _lblCommon_35
			// 
			this._lblCommon_35.AllowDrop = true;
			this._lblCommon_35.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_35.Text = "No. of Children";
			this._lblCommon_35.Location = new System.Drawing.Point(428, 99);
			// // this._lblCommon_35.mLabelId = 1085;
			this._lblCommon_35.Name = "_lblCommon_35";
			this._lblCommon_35.Size = new System.Drawing.Size(72, 13);
			this._lblCommon_35.TabIndex = 104;
			// 
			// _txtCommonTextBox_48
			// 
			this._txtCommonTextBox_48.AllowDrop = true;
			this._txtCommonTextBox_48.BackColor = System.Drawing.Color.White;
			// this._txtCommonTextBox_48.bolAllowDecimal = false;
			// this._txtCommonTextBox_48.bolNumericOnly = true;
			this._txtCommonTextBox_48.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_48.Location = new System.Drawing.Point(517, 96);
			this._txtCommonTextBox_48.MaxLength = 2;
			this._txtCommonTextBox_48.Name = "_txtCommonTextBox_48";
			this._txtCommonTextBox_48.Size = new System.Drawing.Size(89, 19);
			this._txtCommonTextBox_48.TabIndex = 106;
			this._txtCommonTextBox_48.Text = "";
			// this.this._txtCommonTextBox_48.Watermark = "";
			// this.this._txtCommonTextBox_48.Change += new System.Windows.Forms.TextBox.ChangeHandler(this.txtCommonTextBox_Change);
			// this.this._txtCommonTextBox_48.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_48.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _txtCommonTextBox_44
			// 
			this._txtCommonTextBox_44.AllowDrop = true;
			this._txtCommonTextBox_44.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_44.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_44.Location = new System.Drawing.Point(127, 96);
			this._txtCommonTextBox_44.Name = "_txtCommonTextBox_44";
			this._txtCommonTextBox_44.Size = new System.Drawing.Size(101, 19);
			this._txtCommonTextBox_44.TabIndex = 100;
			this._txtCommonTextBox_44.Text = "";
			// this.this._txtCommonTextBox_44.Watermark = "";
			// this.this._txtCommonTextBox_44.Change += new System.Windows.Forms.TextBox.ChangeHandler(this.txtCommonTextBox_Change);
			// this.this._txtCommonTextBox_44.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_44.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _txtCommonTextBox_45
			// 
			this._txtCommonTextBox_45.AllowDrop = true;
			this._txtCommonTextBox_45.BackColor = System.Drawing.Color.White;
			// this._txtCommonTextBox_45.bolNumericOnly = true;
			this._txtCommonTextBox_45.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_45.Location = new System.Drawing.Point(127, 159);
			this._txtCommonTextBox_45.MaxLength = 4;
			this._txtCommonTextBox_45.Name = "_txtCommonTextBox_45";
			// this._txtCommonTextBox_45.ShowButton = true;
			this._txtCommonTextBox_45.Size = new System.Drawing.Size(101, 19);
			this._txtCommonTextBox_45.TabIndex = 123;
			this._txtCommonTextBox_45.Text = "";
			// this.this._txtCommonTextBox_45.Watermark = "";
			// this.this._txtCommonTextBox_45.Change += new System.Windows.Forms.TextBox.ChangeHandler(this.txtCommonTextBox_Change);
			// this.this._txtCommonTextBox_45.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_45.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _txtDisplayLabel_15
			// 
			this._txtDisplayLabel_15.AllowDrop = true;
			this._txtDisplayLabel_15.Location = new System.Drawing.Point(229, 159);
			this._txtDisplayLabel_15.Name = "_txtDisplayLabel_15";
			this._txtDisplayLabel_15.Size = new System.Drawing.Size(189, 19);
			this._txtDisplayLabel_15.TabIndex = 124;
			this._txtDisplayLabel_15.TabStop = false;
			// 
			// _txtCommonTextBox_54
			// 
			this._txtCommonTextBox_54.AllowDrop = true;
			this._txtCommonTextBox_54.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_54.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_54.Location = new System.Drawing.Point(127, 138);
			this._txtCommonTextBox_54.MaxLength = 100;
			this._txtCommonTextBox_54.Name = "_txtCommonTextBox_54";
			this._txtCommonTextBox_54.Size = new System.Drawing.Size(293, 19);
			this._txtCommonTextBox_54.TabIndex = 113;
			this._txtCommonTextBox_54.Text = "";
			// this.this._txtCommonTextBox_54.Watermark = "";
			// this.this._txtCommonTextBox_54.Change += new System.Windows.Forms.TextBox.ChangeHandler(this.txtCommonTextBox_Change);
			// this.this._txtCommonTextBox_54.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_54.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _txtCommonTextBox_55
			// 
			this._txtCommonTextBox_55.AllowDrop = true;
			this._txtCommonTextBox_55.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_55.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_55.Location = new System.Drawing.Point(517, 138);
			this._txtCommonTextBox_55.MaxLength = 100;
			this._txtCommonTextBox_55.Name = "_txtCommonTextBox_55";
			this._txtCommonTextBox_55.Size = new System.Drawing.Size(266, 19);
			this._txtCommonTextBox_55.TabIndex = 115;
			this._txtCommonTextBox_55.Text = "";
			// this.this._txtCommonTextBox_55.Watermark = "";
			// this.this._txtCommonTextBox_55.Change += new System.Windows.Forms.TextBox.ChangeHandler(this.txtCommonTextBox_Change);
			// this.this._txtCommonTextBox_55.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_55.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _lblCommon_44
			// 
			this._lblCommon_44.AllowDrop = true;
			this._lblCommon_44.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_44.Text = "Comments 2";
			this._lblCommon_44.Location = new System.Drawing.Point(11, 141);
			// // this._lblCommon_44.mLabelId = 2012;
			this._lblCommon_44.Name = "_lblCommon_44";
			this._lblCommon_44.Size = new System.Drawing.Size(59, 13);
			this._lblCommon_44.TabIndex = 112;
			// 
			// _lblCommon_45
			// 
			this._lblCommon_45.AllowDrop = true;
			this._lblCommon_45.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_45.Text = "Comments 3";
			this._lblCommon_45.Location = new System.Drawing.Point(430, 141);
			// // this._lblCommon_45.mLabelId = 2013;
			this._lblCommon_45.Name = "_lblCommon_45";
			this._lblCommon_45.Size = new System.Drawing.Size(59, 13);
			this._lblCommon_45.TabIndex = 114;
			// 
			// _txtCommonTextBox_53
			// 
			this._txtCommonTextBox_53.AllowDrop = true;
			this._txtCommonTextBox_53.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_53.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_53.Location = new System.Drawing.Point(127, 117);
			this._txtCommonTextBox_53.MaxLength = 100;
			this._txtCommonTextBox_53.Name = "_txtCommonTextBox_53";
			this._txtCommonTextBox_53.Size = new System.Drawing.Size(293, 19);
			this._txtCommonTextBox_53.TabIndex = 108;
			this._txtCommonTextBox_53.Text = "";
			// this.this._txtCommonTextBox_53.Watermark = "";
			// this.this._txtCommonTextBox_53.Change += new System.Windows.Forms.TextBox.ChangeHandler(this.txtCommonTextBox_Change);
			// this.this._txtCommonTextBox_53.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_53.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _lblCommon_43
			// 
			this._lblCommon_43.AllowDrop = true;
			this._lblCommon_43.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_43.Text = "Comments 1";
			this._lblCommon_43.Location = new System.Drawing.Point(11, 120);
			// // this._lblCommon_43.mLabelId = 2010;
			this._lblCommon_43.Name = "_lblCommon_43";
			this._lblCommon_43.Size = new System.Drawing.Size(59, 13);
			this._lblCommon_43.TabIndex = 107;
			// 
			// lblDefaultProject
			// 
			this.lblDefaultProject.AllowDrop = true;
			this.lblDefaultProject.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblDefaultProject.Text = "Default Project";
			this.lblDefaultProject.Location = new System.Drawing.Point(428, 121);
			// // this.lblDefaultProject.mLabelId = 2160;
			this.lblDefaultProject.Name = "lblDefaultProject";
			this.lblDefaultProject.Size = new System.Drawing.Size(72, 13);
			this.lblDefaultProject.TabIndex = 109;
			// 
			// _lblCommon_60
			// 
			this._lblCommon_60.AllowDrop = true;
			this._lblCommon_60.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_60.Text = "Qualification Desc";
			this._lblCommon_60.Location = new System.Drawing.Point(13, 184);
			// // this._lblCommon_60.mLabelId = 2220;
			this._lblCommon_60.Name = "_lblCommon_60";
			this._lblCommon_60.Size = new System.Drawing.Size(85, 13);
			this._lblCommon_60.TabIndex = 117;
			// 
			// _lblCommon_61
			// 
			this._lblCommon_61.AllowDrop = true;
			this._lblCommon_61.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_61.Text = "Professional Desc";
			this._lblCommon_61.Location = new System.Drawing.Point(13, 205);
			// // this._lblCommon_61.mLabelId = 2221;
			this._lblCommon_61.Name = "_lblCommon_61";
			this._lblCommon_61.Size = new System.Drawing.Size(84, 13);
			this._lblCommon_61.TabIndex = 118;
			// 
			// _lblCommon_62
			// 
			this._lblCommon_62.AllowDrop = true;
			this._lblCommon_62.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_62.Text = "YearofPassing";
			this._lblCommon_62.Location = new System.Drawing.Point(427, 184);
			// // this._lblCommon_62.mLabelId = 2222;
			this._lblCommon_62.Name = "_lblCommon_62";
			this._lblCommon_62.Size = new System.Drawing.Size(68, 13);
			this._lblCommon_62.TabIndex = 119;
			// 
			// _lblCommon_63
			// 
			this._lblCommon_63.AllowDrop = true;
			this._lblCommon_63.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_63.Text = "Relevant Exp";
			this._lblCommon_63.Location = new System.Drawing.Point(427, 205);
			// // this._lblCommon_63.mLabelId = 2223;
			this._lblCommon_63.Name = "_lblCommon_63";
			this._lblCommon_63.Size = new System.Drawing.Size(64, 13);
			this._lblCommon_63.TabIndex = 120;
			// 
			// _txtCommonTextBox_60
			// 
			this._txtCommonTextBox_60.AllowDrop = true;
			this._txtCommonTextBox_60.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_60.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_60.Location = new System.Drawing.Point(127, 181);
			this._txtCommonTextBox_60.MaxLength = 100;
			this._txtCommonTextBox_60.Name = "_txtCommonTextBox_60";
			this._txtCommonTextBox_60.Size = new System.Drawing.Size(293, 19);
			this._txtCommonTextBox_60.TabIndex = 127;
			this._txtCommonTextBox_60.Text = "";
			// this.this._txtCommonTextBox_60.Watermark = "";
			// this.this._txtCommonTextBox_60.Change += new System.Windows.Forms.TextBox.ChangeHandler(this.txtCommonTextBox_Change);
			// this.this._txtCommonTextBox_60.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_60.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _txtCommonTextBox_61
			// 
			this._txtCommonTextBox_61.AllowDrop = true;
			this._txtCommonTextBox_61.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_61.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_61.Location = new System.Drawing.Point(127, 202);
			this._txtCommonTextBox_61.MaxLength = 100;
			this._txtCommonTextBox_61.Name = "_txtCommonTextBox_61";
			this._txtCommonTextBox_61.Size = new System.Drawing.Size(293, 19);
			this._txtCommonTextBox_61.TabIndex = 128;
			this._txtCommonTextBox_61.Text = "";
			// this.this._txtCommonTextBox_61.Watermark = "";
			// this.this._txtCommonTextBox_61.Change += new System.Windows.Forms.TextBox.ChangeHandler(this.txtCommonTextBox_Change);
			// this.this._txtCommonTextBox_61.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_61.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _lblCommon_64
			// 
			this._lblCommon_64.AllowDrop = true;
			this._lblCommon_64.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_64.Text = "Irrelevant Exp";
			this._lblCommon_64.Location = new System.Drawing.Point(617, 205);
			// // this._lblCommon_64.mLabelId = 2224;
			this._lblCommon_64.Name = "_lblCommon_64";
			this._lblCommon_64.Size = new System.Drawing.Size(69, 13);
			this._lblCommon_64.TabIndex = 121;
			// 
			// _txtCommonTextBox_62
			// 
			this._txtCommonTextBox_62.AllowDrop = true;
			this._txtCommonTextBox_62.BackColor = System.Drawing.Color.White;
			// this._txtCommonTextBox_62.bolAllowDecimal = false;
			// this._txtCommonTextBox_62.bolNumericOnly = true;
			this._txtCommonTextBox_62.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_62.Location = new System.Drawing.Point(517, 202);
			this._txtCommonTextBox_62.MaxLength = 2;
			this._txtCommonTextBox_62.Name = "_txtCommonTextBox_62";
			this._txtCommonTextBox_62.Size = new System.Drawing.Size(89, 19);
			this._txtCommonTextBox_62.TabIndex = 129;
			this._txtCommonTextBox_62.Text = "";
			// this.this._txtCommonTextBox_62.Watermark = "";
			// this.this._txtCommonTextBox_62.Change += new System.Windows.Forms.TextBox.ChangeHandler(this.txtCommonTextBox_Change);
			// this.this._txtCommonTextBox_62.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_62.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _txtCommonTextBox_63
			// 
			this._txtCommonTextBox_63.AllowDrop = true;
			this._txtCommonTextBox_63.BackColor = System.Drawing.Color.White;
			// this._txtCommonTextBox_63.bolAllowDecimal = false;
			// this._txtCommonTextBox_63.bolNumericOnly = true;
			this._txtCommonTextBox_63.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_63.Location = new System.Drawing.Point(697, 202);
			this._txtCommonTextBox_63.MaxLength = 2;
			this._txtCommonTextBox_63.Name = "_txtCommonTextBox_63";
			this._txtCommonTextBox_63.Size = new System.Drawing.Size(86, 19);
			this._txtCommonTextBox_63.TabIndex = 130;
			this._txtCommonTextBox_63.Text = "";
			// this.this._txtCommonTextBox_63.Watermark = "";
			// this.this._txtCommonTextBox_63.Change += new System.Windows.Forms.TextBox.ChangeHandler(this.txtCommonTextBox_Change);
			// this.this._txtCommonTextBox_63.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_63.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _txtCommonTextBox_64
			// 
			this._txtCommonTextBox_64.AllowDrop = true;
			this._txtCommonTextBox_64.BackColor = System.Drawing.Color.White;
			// this._txtCommonTextBox_64.bolAllowDecimal = false;
			// this._txtCommonTextBox_64.bolNumericOnly = true;
			this._txtCommonTextBox_64.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_64.Location = new System.Drawing.Point(517, 181);
			this._txtCommonTextBox_64.MaxLength = 2;
			this._txtCommonTextBox_64.Name = "_txtCommonTextBox_64";
			this._txtCommonTextBox_64.Size = new System.Drawing.Size(89, 19);
			this._txtCommonTextBox_64.TabIndex = 131;
			this._txtCommonTextBox_64.Text = "";
			// this.this._txtCommonTextBox_64.Watermark = "";
			// this.this._txtCommonTextBox_64.Change += new System.Windows.Forms.TextBox.ChangeHandler(this.txtCommonTextBox_Change);
			// this.this._txtCommonTextBox_64.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_64.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// TabControlPage2
			// 
			this.TabControlPage2.AllowDrop = true;
			this.TabControlPage2.Controls.Add(this._fraEmployeeInformation_3);
			this.TabControlPage2.Location = new System.Drawing.Point(-4664, 28);
			this.TabControlPage2.Name = "TabControlPage2";
			("TabControlPage2.OcxState");
			this.TabControlPage2.Size = new System.Drawing.Size(863, 353);
			this.TabControlPage2.TabIndex = 144;
			this.TabControlPage2.Visible = false;
			// 
			// _fraEmployeeInformation_3
			// 
			this._fraEmployeeInformation_3.AllowDrop = true;
			this._fraEmployeeInformation_3.Controls.Add(this.chkAllowTicket);
			this._fraEmployeeInformation_3.Controls.Add(this.txtTicketAccrualStartDate);
			this._fraEmployeeInformation_3.Controls.Add(this._lblCommon_23);
			this._fraEmployeeInformation_3.Controls.Add(this._lblCommon_54);
			this._fraEmployeeInformation_3.Controls.Add(this._txtCommonTextBox_71);
			this._fraEmployeeInformation_3.Controls.Add(this._lblCommon_68);
			this._fraEmployeeInformation_3.Controls.Add(this._txtCommonTextBox_73);
			this._fraEmployeeInformation_3.Controls.Add(this._lblCommon_70);
			this._fraEmployeeInformation_3.Controls.Add(this._txtDisplayLabel_11);
			this._fraEmployeeInformation_3.Controls.Add(this._txtDisplayLabel_12);
			this._fraEmployeeInformation_3.Controls.Add(this._lblCommonLabel_12);
			this._fraEmployeeInformation_3.Controls.Add(this._txtDisplayLabel_13);
			this._fraEmployeeInformation_3.Location = new System.Drawing.Point(0, 0);
			this._fraEmployeeInformation_3.Name = "_fraEmployeeInformation_3";
			("_fraEmployeeInformation_3.OcxState");
			this._fraEmployeeInformation_3.Size = new System.Drawing.Size(793, 315);
			this._fraEmployeeInformation_3.TabIndex = 145;
			// 
			// chkAllowTicket
			// 
			this.chkAllowTicket.AllowDrop = true;
			this.chkAllowTicket.Appearance = System.Windows.Forms.Appearance.Normal;
			this.chkAllowTicket.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.chkAllowTicket.CausesValidation = true;
			this.chkAllowTicket.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkAllowTicket.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this.chkAllowTicket.Enabled = true;
			this.chkAllowTicket.ForeColor = System.Drawing.SystemColors.ControlText;
			this.chkAllowTicket.Location = new System.Drawing.Point(120, 12);
			this.chkAllowTicket.Name = "chkAllowTicket";
			this.chkAllowTicket.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.chkAllowTicket.Size = new System.Drawing.Size(17, 13);
			this.chkAllowTicket.TabIndex = 146;
			this.chkAllowTicket.TabStop = true;
			this.chkAllowTicket.Text = "";
			this.chkAllowTicket.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkAllowTicket.Visible = true;
			// 
			// txtTicketAccrualStartDate
			// 
			this.txtTicketAccrualStartDate.AllowDrop = true;
			// this.txtTicketAccrualStartDate.CheckDateRange = false;
			this.txtTicketAccrualStartDate.Location = new System.Drawing.Point(120, 74);
			// this.txtTicketAccrualStartDate.MaxDate = 2958465;
			// this.txtTicketAccrualStartDate.MinDate = -657434;
			this.txtTicketAccrualStartDate.Name = "txtTicketAccrualStartDate";
			this.txtTicketAccrualStartDate.PromptChar = "_";
			this.txtTicketAccrualStartDate.Size = new System.Drawing.Size(100, 19);
			this.txtTicketAccrualStartDate.TabIndex = 155;
			this.txtTicketAccrualStartDate.Text = "15/Aug/2009";
			// this.txtTicketAccrualStartDate.Value = 40040;
			// 
			// _lblCommon_23
			// 
			this._lblCommon_23.AllowDrop = true;
			this._lblCommon_23.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_23.Text = "Accrual Start Date";
			this._lblCommon_23.Location = new System.Drawing.Point(12, 76);
			this._lblCommon_23.Name = "_lblCommon_23";
			this._lblCommon_23.Size = new System.Drawing.Size(89, 14);
			this._lblCommon_23.TabIndex = 149;
			// 
			// _lblCommon_54
			// 
			this._lblCommon_54.AllowDrop = true;
			this._lblCommon_54.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_54.Text = "Allow Ticket";
			this._lblCommon_54.Location = new System.Drawing.Point(12, 12);
			this._lblCommon_54.Name = "_lblCommon_54";
			this._lblCommon_54.Size = new System.Drawing.Size(56, 13);
			this._lblCommon_54.TabIndex = 150;
			// 
			// _txtCommonTextBox_71
			// 
			this._txtCommonTextBox_71.AllowDrop = true;
			this._txtCommonTextBox_71.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_71.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_71.Location = new System.Drawing.Point(120, 54);
			this._txtCommonTextBox_71.MaxLength = 100;
			this._txtCommonTextBox_71.Name = "_txtCommonTextBox_71";
			// this._txtCommonTextBox_71.ShowButton = true;
			this._txtCommonTextBox_71.Size = new System.Drawing.Size(100, 19);
			this._txtCommonTextBox_71.TabIndex = 153;
			this._txtCommonTextBox_71.Text = "";
			// this.this._txtCommonTextBox_71.Watermark = "";
			// this.this._txtCommonTextBox_71.Change += new System.Windows.Forms.TextBox.ChangeHandler(this.txtCommonTextBox_Change);
			// this.this._txtCommonTextBox_71.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_71.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _lblCommon_68
			// 
			this._lblCommon_68.AllowDrop = true;
			this._lblCommon_68.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_68.Text = "Tickect Destination";
			this._lblCommon_68.Location = new System.Drawing.Point(12, 57);
			this._lblCommon_68.Name = "_lblCommon_68";
			this._lblCommon_68.Size = new System.Drawing.Size(90, 13);
			this._lblCommon_68.TabIndex = 151;
			// 
			// _txtCommonTextBox_73
			// 
			this._txtCommonTextBox_73.AllowDrop = true;
			this._txtCommonTextBox_73.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_73.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_73.Location = new System.Drawing.Point(120, 33);
			this._txtCommonTextBox_73.MaxLength = 100;
			this._txtCommonTextBox_73.Name = "_txtCommonTextBox_73";
			// this._txtCommonTextBox_73.ShowButton = true;
			this._txtCommonTextBox_73.Size = new System.Drawing.Size(100, 19);
			this._txtCommonTextBox_73.TabIndex = 147;
			this._txtCommonTextBox_73.Text = "";
			// this.this._txtCommonTextBox_73.Watermark = "";
			// this.this._txtCommonTextBox_73.Change += new System.Windows.Forms.TextBox.ChangeHandler(this.txtCommonTextBox_Change);
			// this.this._txtCommonTextBox_73.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_73.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _lblCommon_70
			// 
			this._lblCommon_70.AllowDrop = true;
			this._lblCommon_70.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_70.Text = "Ticket Type";
			this._lblCommon_70.Location = new System.Drawing.Point(12, 36);
			this._lblCommon_70.Name = "_lblCommon_70";
			this._lblCommon_70.Size = new System.Drawing.Size(55, 13);
			this._lblCommon_70.TabIndex = 152;
			// 
			// _txtDisplayLabel_11
			// 
			this._txtDisplayLabel_11.AllowDrop = true;
			this._txtDisplayLabel_11.Location = new System.Drawing.Point(222, 33);
			this._txtDisplayLabel_11.Name = "_txtDisplayLabel_11";
			this._txtDisplayLabel_11.Size = new System.Drawing.Size(233, 19);
			this._txtDisplayLabel_11.TabIndex = 148;
			this._txtDisplayLabel_11.TabStop = false;
			// 
			// _txtDisplayLabel_12
			// 
			this._txtDisplayLabel_12.AllowDrop = true;
			this._txtDisplayLabel_12.Location = new System.Drawing.Point(222, 54);
			this._txtDisplayLabel_12.Name = "_txtDisplayLabel_12";
			this._txtDisplayLabel_12.Size = new System.Drawing.Size(233, 19);
			this._txtDisplayLabel_12.TabIndex = 154;
			this._txtDisplayLabel_12.TabStop = false;
			// 
			// _lblCommonLabel_12
			// 
			this._lblCommonLabel_12.AllowDrop = true;
			this._lblCommonLabel_12.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_12.Text = "Ticket  Balance";
			this._lblCommonLabel_12.Location = new System.Drawing.Point(239, 77);
			// // this._lblCommonLabel_12.mLabelId = 2084;
			this._lblCommonLabel_12.Name = "_lblCommonLabel_12";
			this._lblCommonLabel_12.Size = new System.Drawing.Size(73, 14);
			this._lblCommonLabel_12.TabIndex = 156;
			// 
			// _txtDisplayLabel_13
			// 
			// this._txtDisplayLabel_13.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
			this._txtDisplayLabel_13.AllowDrop = true;
			this._txtDisplayLabel_13.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			this._txtDisplayLabel_13.Location = new System.Drawing.Point(348, 74);
			this._txtDisplayLabel_13.Name = "_txtDisplayLabel_13";
			this._txtDisplayLabel_13.Size = new System.Drawing.Size(107, 19);
			this._txtDisplayLabel_13.TabIndex = 157;
			this._txtDisplayLabel_13.TabStop = false;
			// 
			// TabControlPage1
			// 
			this.TabControlPage1.AllowDrop = true;
			this.TabControlPage1.Controls.Add(this._fraEmployeeInformation_4);
			this.TabControlPage1.Location = new System.Drawing.Point(-4664, 28);
			this.TabControlPage1.Name = "TabControlPage1";
			("TabControlPage1.OcxState");
			this.TabControlPage1.Size = new System.Drawing.Size(863, 353);
			this.TabControlPage1.TabIndex = 158;
			this.TabControlPage1.Visible = false;
			// 
			// _fraEmployeeInformation_4
			// 
			this._fraEmployeeInformation_4.AllowDrop = true;
			this._fraEmployeeInformation_4.Controls.Add(this._txtCommonTextBox_72);
			this._fraEmployeeInformation_4.Controls.Add(this._lblCommon_74);
			this._fraEmployeeInformation_4.Controls.Add(this._txtDisplayLabel_18);
			this._fraEmployeeInformation_4.Location = new System.Drawing.Point(0, 0);
			this._fraEmployeeInformation_4.Name = "_fraEmployeeInformation_4";
			("_fraEmployeeInformation_4.OcxState");
			this._fraEmployeeInformation_4.Size = new System.Drawing.Size(793, 315);
			this._fraEmployeeInformation_4.TabIndex = 159;
			// 
			// _txtCommonTextBox_72
			// 
			this._txtCommonTextBox_72.AllowDrop = true;
			this._txtCommonTextBox_72.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_72.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_72.Location = new System.Drawing.Point(118, 16);
			this._txtCommonTextBox_72.MaxLength = 100;
			this._txtCommonTextBox_72.Name = "_txtCommonTextBox_72";
			// this._txtCommonTextBox_72.ShowButton = true;
			this._txtCommonTextBox_72.Size = new System.Drawing.Size(100, 19);
			this._txtCommonTextBox_72.TabIndex = 161;
			this._txtCommonTextBox_72.Text = "";
			// this.this._txtCommonTextBox_72.Watermark = "";
			// this.this._txtCommonTextBox_72.Change += new System.Windows.Forms.TextBox.ChangeHandler(this.txtCommonTextBox_Change);
			// this.this._txtCommonTextBox_72.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_72.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _lblCommon_74
			// 
			this._lblCommon_74.AllowDrop = true;
			this._lblCommon_74.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_74.Text = "Budget Head Count";
			this._lblCommon_74.Location = new System.Drawing.Point(10, 19);
			this._lblCommon_74.Name = "_lblCommon_74";
			this._lblCommon_74.Size = new System.Drawing.Size(94, 13);
			this._lblCommon_74.TabIndex = 160;
			// 
			// _txtDisplayLabel_18
			// 
			this._txtDisplayLabel_18.AllowDrop = true;
			this._txtDisplayLabel_18.Location = new System.Drawing.Point(220, 16);
			this._txtDisplayLabel_18.Name = "_txtDisplayLabel_18";
			this._txtDisplayLabel_18.Size = new System.Drawing.Size(233, 19);
			this._txtDisplayLabel_18.TabIndex = 162;
			this._txtDisplayLabel_18.TabStop = false;
			// 
			// _fraEmployeeInformation_0
			// 
			this._fraEmployeeInformation_0.AllowDrop = true;
			this._fraEmployeeInformation_0.Controls.Add(this.cmdPullGradeSetting);
			this._fraEmployeeInformation_0.Controls.Add(this.txtNoticePeriod);
			this._fraEmployeeInformation_0.Controls.Add(this.txtContractPeriod);
			this._fraEmployeeInformation_0.Controls.Add(this._txtCommonTextBox_9);
			this._fraEmployeeInformation_0.Controls.Add(this._lblCommon_116);
			this._fraEmployeeInformation_0.Controls.Add(this._txtCommonTextBox_10);
			this._fraEmployeeInformation_0.Controls.Add(this._lblCommon_105);
			this._fraEmployeeInformation_0.Controls.Add(this._txtCommonTextBox_11);
			this._fraEmployeeInformation_0.Controls.Add(this._lblCommon_114);
			this._fraEmployeeInformation_0.Controls.Add(this._txtCommonTextBox_12);
			this._fraEmployeeInformation_0.Controls.Add(this._lblCommon_104);
			this._fraEmployeeInformation_0.Controls.Add(this._lblCommon_108);
			this._fraEmployeeInformation_0.Controls.Add(this.txtBirthDate);
			this._fraEmployeeInformation_0.Controls.Add(this._lblCommon_109);
			this._fraEmployeeInformation_0.Controls.Add(this.txtJoiningDate);
			this._fraEmployeeInformation_0.Controls.Add(this._txtCommonTextBox_13);
			this._fraEmployeeInformation_0.Controls.Add(this._lblCommon_112);
			this._fraEmployeeInformation_0.Controls.Add(this._txtCommonTextBox_15);
			this._fraEmployeeInformation_0.Controls.Add(this._lblCommon_103);
			this._fraEmployeeInformation_0.Controls.Add(this.Label1_1);
			this._fraEmployeeInformation_0.Controls.Add(this._cmbCommon_3);
			this._fraEmployeeInformation_0.Controls.Add(this.Label1_3);
			this._fraEmployeeInformation_0.Controls.Add(this._cmbCommon_1);
			this._fraEmployeeInformation_0.Controls.Add(this._cmbCommon_2);
			this._fraEmployeeInformation_0.Controls.Add(this.Label12);
			this._fraEmployeeInformation_0.Controls.Add(this._txtCommonTextBox_36);
			this._fraEmployeeInformation_0.Controls.Add(this._txtDisplayLabel_1);
			this._fraEmployeeInformation_0.Controls.Add(this._txtDisplayLabel_2);
			this._fraEmployeeInformation_0.Controls.Add(this._txtDisplayLabel_3);
			this._fraEmployeeInformation_0.Controls.Add(this._txtDisplayLabel_4);
			this._fraEmployeeInformation_0.Controls.Add(this._txtDisplayLabel_8);
			this._fraEmployeeInformation_0.Controls.Add(this._txtDisplayLabel_5);
			this._fraEmployeeInformation_0.Controls.Add(this._lblCommon_37);
			this._fraEmployeeInformation_0.Controls.Add(this._txtDisplayLabel_6);
			this._fraEmployeeInformation_0.Controls.Add(this.txtProbationEndDate);
			this._fraEmployeeInformation_0.Controls.Add(this._txtDisplayLabel_7);
			this._fraEmployeeInformation_0.Controls.Add(this._txtCommonTextBox_39);
			this._fraEmployeeInformation_0.Controls.Add(this._txtCommonTextBox_52);
			this._fraEmployeeInformation_0.Controls.Add(this._txtDisplayLabel_10);
			this._fraEmployeeInformation_0.Controls.Add(this._txtCommonTextBox_56);
			this._fraEmployeeInformation_0.Controls.Add(this.txtDeductionHrs);
			this._fraEmployeeInformation_0.Controls.Add(this._lblCommon_55);
			this._fraEmployeeInformation_0.Controls.Add(this.txtContractStratDate);
			this._fraEmployeeInformation_0.Controls.Add(this.txtContractEndDate);
			this._fraEmployeeInformation_0.Controls.Add(this._txtDisplayLabel_14);
			this._fraEmployeeInformation_0.Controls.Add(this._txtDisplayLabel_16);
			this._fraEmployeeInformation_0.Controls.Add(this._lblCommon_56);
			this._fraEmployeeInformation_0.Controls.Add(this._lblCommon_57);
			this._fraEmployeeInformation_0.Controls.Add(this._txtCommonTextBox_70);
			this._fraEmployeeInformation_0.Controls.Add(this._lblCommon_73);
			this._fraEmployeeInformation_0.Controls.Add(this._txtDisplayLabel_17);
			this._fraEmployeeInformation_0.Controls.Add(this.txtDSeveranceDate);
			this._fraEmployeeInformation_0.Controls.Add(this._lblCommon_42);
			this._fraEmployeeInformation_0.Controls.Add(this._lblCommon_111);
			this._fraEmployeeInformation_0.Controls.Add(this._lblCommonLabel_0);
			this._fraEmployeeInformation_0.Controls.Add(this.Label1_2);
			this._fraEmployeeInformation_0.Controls.Add(this._lblCommon_41);
			this._fraEmployeeInformation_0.Controls.Add(this._lblCommon_49);
			this._fraEmployeeInformation_0.Controls.Add(this.lblDeductionHrs);
			this._fraEmployeeInformation_0.Controls.Add(this.Label1_4);
			this._fraEmployeeInformation_0.Controls.Add(this.Label1_5);
			this._fraEmployeeInformation_0.Controls.Add(this.lblNoticePeriod);
			this._fraEmployeeInformation_0.Location = new System.Drawing.Point(2, 28);
			this._fraEmployeeInformation_0.Name = "_fraEmployeeInformation_0";
			("_fraEmployeeInformation_0.OcxState");
			this._fraEmployeeInformation_0.Size = new System.Drawing.Size(863, 353);
			this._fraEmployeeInformation_0.TabIndex = 163;
			// 
			// cmdPullGradeSetting
			// 
			this.cmdPullGradeSetting.AllowDrop = true;
			this.cmdPullGradeSetting.BackColor = System.Drawing.SystemColors.Control;
			this.cmdPullGradeSetting.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdPullGradeSetting.Location = new System.Drawing.Point(790, 77);
			this.cmdPullGradeSetting.Name = "cmdPullGradeSetting";
			this.cmdPullGradeSetting.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdPullGradeSetting.Size = new System.Drawing.Size(47, 19);
			this.cmdPullGradeSetting.TabIndex = 185;
			this.cmdPullGradeSetting.Text = "Pull";
			this.cmdPullGradeSetting.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.cmdPullGradeSetting.UseVisualStyleBackColor = false;
			// this.cmdPullGradeSetting.Click += new System.EventHandler(this.cmdPullGradeSetting_Click);
			// 
			// txtNoticePeriod
			// 
			this.txtNoticePeriod.AllowDrop = true;
			// this.txtNoticePeriod.DisplayFormat = "####0.000###;;0.000;0.000";
			this.txtNoticePeriod.ForeColor = System.Drawing.SystemColors.WindowText;
			// this.txtNoticePeriod.Format = "###########0.000";
			this.txtNoticePeriod.Location = new System.Drawing.Point(734, 181);
			this.txtNoticePeriod.Name = "txtNoticePeriod";
			this.txtNoticePeriod.Size = new System.Drawing.Size(103, 19);
			this.txtNoticePeriod.TabIndex = 219;
			this.txtNoticePeriod.Text = "0.000";
			// 
			// txtContractPeriod
			// 
			this.txtContractPeriod.AllowDrop = true;
			this.txtContractPeriod.Enabled = false;
			this.txtContractPeriod.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtContractPeriod.Location = new System.Drawing.Point(284, 181);
			this.txtContractPeriod.Name = "txtContractPeriod";
			this.txtContractPeriod.Size = new System.Drawing.Size(92, 19);
			this.txtContractPeriod.TabIndex = 215;
			// this.this.txtContractPeriod.Change += new System.Windows.Forms.TextBox.ChangeHandler(this.txtContractPeriod_Change);
			// 
			// _txtCommonTextBox_9
			// 
			this._txtCommonTextBox_9.AllowDrop = true;
			this._txtCommonTextBox_9.BackColor = System.Drawing.Color.White;
			// this._txtCommonTextBox_9.bolNumericOnly = true;
			this._txtCommonTextBox_9.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_9.Location = new System.Drawing.Point(98, 12);
			this._txtCommonTextBox_9.MaxLength = 8;
			this._txtCommonTextBox_9.Name = "_txtCommonTextBox_9";
			// this._txtCommonTextBox_9.ShowButton = true;
			this._txtCommonTextBox_9.Size = new System.Drawing.Size(101, 19);
			this._txtCommonTextBox_9.TabIndex = 165;
			this._txtCommonTextBox_9.Text = "";
			// this.this._txtCommonTextBox_9.Watermark = "";
			// this.this._txtCommonTextBox_9.Change += new System.Windows.Forms.TextBox.ChangeHandler(this.txtCommonTextBox_Change);
			// this.this._txtCommonTextBox_9.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_9.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _lblCommon_116
			// 
			this._lblCommon_116.AllowDrop = true;
			this._lblCommon_116.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_116.Text = "Department Code";
			this._lblCommon_116.Location = new System.Drawing.Point(10, 14);
			// // this._lblCommon_116.mLabelId = 1973;
			this._lblCommon_116.Name = "_lblCommon_116";
			this._lblCommon_116.Size = new System.Drawing.Size(83, 14);
			this._lblCommon_116.TabIndex = 164;
			// 
			// _txtCommonTextBox_10
			// 
			this._txtCommonTextBox_10.AllowDrop = true;
			this._txtCommonTextBox_10.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_10.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_10.Location = new System.Drawing.Point(539, 33);
			this._txtCommonTextBox_10.MaxLength = 10;
			this._txtCommonTextBox_10.Name = "_txtCommonTextBox_10";
			// this._txtCommonTextBox_10.ShowButton = true;
			this._txtCommonTextBox_10.Size = new System.Drawing.Size(101, 19);
			this._txtCommonTextBox_10.TabIndex = 173;
			this._txtCommonTextBox_10.Text = "";
			// this.this._txtCommonTextBox_10.Watermark = "";
			// this.this._txtCommonTextBox_10.Change += new System.Windows.Forms.TextBox.ChangeHandler(this.txtCommonTextBox_Change);
			// this.this._txtCommonTextBox_10.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_10.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _lblCommon_105
			// 
			this._lblCommon_105.AllowDrop = true;
			this._lblCommon_105.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_105.Text = "Manager Code";
			this._lblCommon_105.Location = new System.Drawing.Point(458, 35);
			// // this._lblCommon_105.mLabelId = 1060;
			this._lblCommon_105.Name = "_lblCommon_105";
			this._lblCommon_105.Size = new System.Drawing.Size(70, 14);
			this._lblCommon_105.TabIndex = 171;
			// 
			// _txtCommonTextBox_11
			// 
			this._txtCommonTextBox_11.AllowDrop = true;
			this._txtCommonTextBox_11.BackColor = System.Drawing.Color.White;
			// this._txtCommonTextBox_11.bolNumericOnly = true;
			this._txtCommonTextBox_11.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_11.Location = new System.Drawing.Point(98, 33);
			this._txtCommonTextBox_11.MaxLength = 8;
			this._txtCommonTextBox_11.Name = "_txtCommonTextBox_11";
			// this._txtCommonTextBox_11.ShowButton = true;
			this._txtCommonTextBox_11.Size = new System.Drawing.Size(101, 19);
			this._txtCommonTextBox_11.TabIndex = 172;
			this._txtCommonTextBox_11.Text = "";
			// this.this._txtCommonTextBox_11.Watermark = "";
			// this.this._txtCommonTextBox_11.Change += new System.Windows.Forms.TextBox.ChangeHandler(this.txtCommonTextBox_Change);
			// this.this._txtCommonTextBox_11.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_11.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _lblCommon_114
			// 
			this._lblCommon_114.AllowDrop = true;
			this._lblCommon_114.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_114.Text = "Designation Code";
			this._lblCommon_114.Location = new System.Drawing.Point(10, 35);
			// // this._lblCommon_114.mLabelId = 1049;
			this._lblCommon_114.Name = "_lblCommon_114";
			this._lblCommon_114.Size = new System.Drawing.Size(84, 14);
			this._lblCommon_114.TabIndex = 169;
			// 
			// _txtCommonTextBox_12
			// 
			this._txtCommonTextBox_12.AllowDrop = true;
			this._txtCommonTextBox_12.BackColor = System.Drawing.Color.White;
			// this._txtCommonTextBox_12.bolNumericOnly = true;
			this._txtCommonTextBox_12.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_12.Location = new System.Drawing.Point(539, 78);
			this._txtCommonTextBox_12.MaxLength = 8;
			this._txtCommonTextBox_12.Name = "_txtCommonTextBox_12";
			// this._txtCommonTextBox_12.ShowButton = true;
			this._txtCommonTextBox_12.Size = new System.Drawing.Size(101, 19);
			this._txtCommonTextBox_12.TabIndex = 189;
			this._txtCommonTextBox_12.Text = "";
			// this.this._txtCommonTextBox_12.Watermark = "";
			// this.this._txtCommonTextBox_12.Change += new System.Windows.Forms.TextBox.ChangeHandler(this.txtCommonTextBox_Change);
			// this.this._txtCommonTextBox_12.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_12.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _lblCommon_104
			// 
			this._lblCommon_104.AllowDrop = true;
			this._lblCommon_104.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_104.Text = "Grade Code";
			this._lblCommon_104.Location = new System.Drawing.Point(458, 80);
			// // this._lblCommon_104.mLabelId = 1061;
			this._lblCommon_104.Name = "_lblCommon_104";
			this._lblCommon_104.Size = new System.Drawing.Size(58, 14);
			this._lblCommon_104.TabIndex = 183;
			// 
			// _lblCommon_108
			// 
			this._lblCommon_108.AllowDrop = true;
			this._lblCommon_108.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_108.Text = "Birth Date";
			this._lblCommon_108.Location = new System.Drawing.Point(10, 58);
			// // this._lblCommon_108.mLabelId = 1056;
			this._lblCommon_108.Name = "_lblCommon_108";
			this._lblCommon_108.Size = new System.Drawing.Size(47, 14);
			this._lblCommon_108.TabIndex = 175;
			// 
			// txtBirthDate
			// 
			this.txtBirthDate.AllowDrop = true;
			this.txtBirthDate.CenturyMode = TDBDate6.dbiCenturyModeConst.dbiDateWindow;
			// this.txtBirthDate.CheckDateRange = false;
			this.txtBirthDate.Location = new System.Drawing.Point(98, 55);
			// this.txtBirthDate.MaxDate = 51501;
			// this.txtBirthDate.MinDate = 2;
			this.txtBirthDate.Name = "txtBirthDate";
			this.txtBirthDate.Size = new System.Drawing.Size(102, 21);
			this.txtBirthDate.TabIndex = 176;
			this.txtBirthDate.Text = "06/Apr/2003";
			// this.txtBirthDate.Value = 37717;
			// this.this.txtBirthDate.Change += new Syncfusion.WinForms.Input.SfDateTimeEdit.ChangeHandler(this.txtBirthDate_Change);
			// 
			// _lblCommon_109
			// 
			this._lblCommon_109.AllowDrop = true;
			this._lblCommon_109.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_109.Text = "Joining Date";
			this._lblCommon_109.Location = new System.Drawing.Point(10, 80);
			// // this._lblCommon_109.mLabelId = 1057;
			this._lblCommon_109.Name = "_lblCommon_109";
			this._lblCommon_109.Size = new System.Drawing.Size(58, 14);
			this._lblCommon_109.TabIndex = 184;
			// 
			// txtJoiningDate
			// 
			this.txtJoiningDate.AllowDrop = true;
			// this.txtJoiningDate.CheckDateRange = false;
			this.txtJoiningDate.Location = new System.Drawing.Point(98, 78);
			// this.txtJoiningDate.MaxDate = 2958465;
			// this.txtJoiningDate.MinDate = 2;
			this.txtJoiningDate.Name = "txtJoiningDate";
			this.txtJoiningDate.Size = new System.Drawing.Size(102, 19);
			this.txtJoiningDate.TabIndex = 186;
			this.txtJoiningDate.Text = "18/Jul/2001";
			// this.txtJoiningDate.Value = 37090;
			// this.this.txtJoiningDate.Change += new Syncfusion.WinForms.Input.SfDateTimeEdit.ChangeHandler(this.txtJoiningDate_Change);
			// 
			// _txtCommonTextBox_13
			// 
			this._txtCommonTextBox_13.AllowDrop = true;
			this._txtCommonTextBox_13.BackColor = System.Drawing.Color.White;
			// this._txtCommonTextBox_13.bolNumericOnly = true;
			this._txtCommonTextBox_13.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_13.Location = new System.Drawing.Point(98, 102);
			this._txtCommonTextBox_13.MaxLength = 8;
			this._txtCommonTextBox_13.Name = "_txtCommonTextBox_13";
			// this._txtCommonTextBox_13.ShowButton = true;
			this._txtCommonTextBox_13.Size = new System.Drawing.Size(101, 19);
			this._txtCommonTextBox_13.TabIndex = 191;
			this._txtCommonTextBox_13.Text = "";
			// this.this._txtCommonTextBox_13.Watermark = "";
			// this.this._txtCommonTextBox_13.Change += new System.Windows.Forms.TextBox.ChangeHandler(this.txtCommonTextBox_Change);
			// this.this._txtCommonTextBox_13.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_13.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _lblCommon_112
			// 
			this._lblCommon_112.AllowDrop = true;
			this._lblCommon_112.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_112.Text = "Nationality Code";
			this._lblCommon_112.Location = new System.Drawing.Point(10, 107);
			// // this._lblCommon_112.mLabelId = 1058;
			this._lblCommon_112.Name = "_lblCommon_112";
			this._lblCommon_112.Size = new System.Drawing.Size(77, 14);
			this._lblCommon_112.TabIndex = 196;
			// 
			// _txtCommonTextBox_15
			// 
			this._txtCommonTextBox_15.AllowDrop = true;
			this._txtCommonTextBox_15.BackColor = System.Drawing.Color.White;
			// this._txtCommonTextBox_15.bolNumericOnly = true;
			this._txtCommonTextBox_15.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_15.Location = new System.Drawing.Point(98, 128);
			this._txtCommonTextBox_15.MaxLength = 8;
			this._txtCommonTextBox_15.Name = "_txtCommonTextBox_15";
			// this._txtCommonTextBox_15.ShowButton = true;
			this._txtCommonTextBox_15.Size = new System.Drawing.Size(101, 19);
			this._txtCommonTextBox_15.TabIndex = 197;
			this._txtCommonTextBox_15.Text = "";
			// this.this._txtCommonTextBox_15.Watermark = "";
			// this.this._txtCommonTextBox_15.Change += new System.Windows.Forms.TextBox.ChangeHandler(this.txtCommonTextBox_Change);
			// this.this._txtCommonTextBox_15.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_15.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _lblCommon_103
			// 
			this._lblCommon_103.AllowDrop = true;
			this._lblCommon_103.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_103.Text = "Religion Code";
			this._lblCommon_103.Location = new System.Drawing.Point(10, 130);
			// // this._lblCommon_103.mLabelId = 1059;
			this._lblCommon_103.Name = "_lblCommon_103";
			this._lblCommon_103.Size = new System.Drawing.Size(65, 14);
			this._lblCommon_103.TabIndex = 195;
			// 
			// Label1_1
			// 
			this.Label1_1.AllowDrop = true;
			this.Label1_1.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.Label1_1.Text = "Sex";
			this.Label1_1.Location = new System.Drawing.Point(10, 158);
			// this.Label1_1.mLabelId = 1981;
			this.Label1_1.Name = "Label1_1";
			this.Label1_1.Size = new System.Drawing.Size(19, 14);
			this.Label1_1.TabIndex = 204;
			// 
			// _cmbCommon_3
			// 
			this._cmbCommon_3.AllowDrop = true;
			this._cmbCommon_3.Location = new System.Drawing.Point(539, 155);
			this._cmbCommon_3.Name = "_cmbCommon_3";
			this._cmbCommon_3.Size = new System.Drawing.Size(101, 21);
			this._cmbCommon_3.TabIndex = 211;
			// this.this._cmbCommon_3.Change += new System.Windows.Forms.ComboBox.ChangeHandler(this.cmbCommon_Change);
			// this._cmbCommon_3.Click += new System.Windows.Forms.ComboBox.ClickHandler(this.cmbCommon_Click);
			// 
			// Label1_3
			// 
			this.Label1_3.AllowDrop = true;
			this.Label1_3.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.Label1_3.Text = "Employee Type";
			this.Label1_3.Location = new System.Drawing.Point(458, 158);
			// this.Label1_3.mLabelId = 249;
			this.Label1_3.Name = "Label1_3";
			this.Label1_3.Size = new System.Drawing.Size(73, 14);
			this.Label1_3.TabIndex = 210;
			// 
			// _cmbCommon_1
			// 
			this._cmbCommon_1.AllowDrop = true;
			this._cmbCommon_1.Location = new System.Drawing.Point(98, 155);
			this._cmbCommon_1.Name = "_cmbCommon_1";
			this._cmbCommon_1.Size = new System.Drawing.Size(101, 21);
			this._cmbCommon_1.TabIndex = 207;
			// this.this._cmbCommon_1.Change += new System.Windows.Forms.ComboBox.ChangeHandler(this.cmbCommon_Change);
			// this._cmbCommon_1.Click += new System.Windows.Forms.ComboBox.ClickHandler(this.cmbCommon_Click);
			// 
			// _cmbCommon_2
			// 
			this._cmbCommon_2.AllowDrop = true;
			this._cmbCommon_2.Location = new System.Drawing.Point(284, 155);
			this._cmbCommon_2.Name = "_cmbCommon_2";
			this._cmbCommon_2.Size = new System.Drawing.Size(92, 21);
			this._cmbCommon_2.TabIndex = 208;
			// this.this._cmbCommon_2.Change += new System.Windows.Forms.ComboBox.ChangeHandler(this.cmbCommon_Change);
			// this._cmbCommon_2.Click += new System.Windows.Forms.ComboBox.ClickHandler(this.cmbCommon_Click);
			// 
			// System.Windows.Forms.Label12
			// 
			this.Label12.AllowDrop = true;
			this.Label12.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.Label12.Text = "Comments";
			this.Label12.Location = new System.Drawing.Point(10, 208);
			// this.Label12.mLabelId = 1851;
			this.Label12.Name = "System.Windows.Forms.Label12";
			this.Label12.Size = new System.Drawing.Size(50, 14);
			this.Label12.TabIndex = 220;
			// 
			// _txtCommonTextBox_36
			// 
			this._txtCommonTextBox_36.AllowDrop = true;
			this._txtCommonTextBox_36.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_36.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_36.Location = new System.Drawing.Point(98, 206);
			this._txtCommonTextBox_36.MaxLength = 100;
			this._txtCommonTextBox_36.Name = "_txtCommonTextBox_36";
			this._txtCommonTextBox_36.Size = new System.Drawing.Size(740, 19);
			this._txtCommonTextBox_36.TabIndex = 221;
			this._txtCommonTextBox_36.Text = "";
			// this.this._txtCommonTextBox_36.Watermark = "";
			// this.this._txtCommonTextBox_36.Change += new System.Windows.Forms.TextBox.ChangeHandler(this.txtCommonTextBox_Change);
			// this.this._txtCommonTextBox_36.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_36.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _txtDisplayLabel_1
			// 
			this._txtDisplayLabel_1.AllowDrop = true;
			this._txtDisplayLabel_1.Location = new System.Drawing.Point(201, 12);
			this._txtDisplayLabel_1.Name = "_txtDisplayLabel_1";
			this._txtDisplayLabel_1.Size = new System.Drawing.Size(173, 19);
			this._txtDisplayLabel_1.TabIndex = 167;
			this._txtDisplayLabel_1.TabStop = false;
			// 
			// _txtDisplayLabel_2
			// 
			this._txtDisplayLabel_2.AllowDrop = true;
			this._txtDisplayLabel_2.Location = new System.Drawing.Point(643, 33);
			this._txtDisplayLabel_2.Name = "_txtDisplayLabel_2";
			this._txtDisplayLabel_2.Size = new System.Drawing.Size(194, 19);
			this._txtDisplayLabel_2.TabIndex = 174;
			this._txtDisplayLabel_2.TabStop = false;
			// 
			// _txtDisplayLabel_3
			// 
			this._txtDisplayLabel_3.AllowDrop = true;
			this._txtDisplayLabel_3.Location = new System.Drawing.Point(201, 33);
			this._txtDisplayLabel_3.Name = "_txtDisplayLabel_3";
			this._txtDisplayLabel_3.Size = new System.Drawing.Size(173, 19);
			this._txtDisplayLabel_3.TabIndex = 170;
			this._txtDisplayLabel_3.TabStop = false;
			// 
			// _txtDisplayLabel_4
			// 
			this._txtDisplayLabel_4.AllowDrop = true;
			this._txtDisplayLabel_4.Location = new System.Drawing.Point(643, 78);
			this._txtDisplayLabel_4.Name = "_txtDisplayLabel_4";
			this._txtDisplayLabel_4.Size = new System.Drawing.Size(146, 19);
			this._txtDisplayLabel_4.TabIndex = 190;
			this._txtDisplayLabel_4.TabStop = false;
			// 
			// _txtDisplayLabel_8
			// 
			this._txtDisplayLabel_8.AllowDrop = true;
			this._txtDisplayLabel_8.Location = new System.Drawing.Point(201, 128);
			this._txtDisplayLabel_8.Name = "_txtDisplayLabel_8";
			this._txtDisplayLabel_8.Size = new System.Drawing.Size(173, 19);
			this._txtDisplayLabel_8.TabIndex = 200;
			this._txtDisplayLabel_8.TabStop = false;
			// 
			// _txtDisplayLabel_5
			// 
			this._txtDisplayLabel_5.AllowDrop = true;
			this._txtDisplayLabel_5.Location = new System.Drawing.Point(539, 55);
			this._txtDisplayLabel_5.Name = "_txtDisplayLabel_5";
			this._txtDisplayLabel_5.Size = new System.Drawing.Size(29, 21);
			this._txtDisplayLabel_5.TabIndex = 180;
			this._txtDisplayLabel_5.TabStop = false;
			// 
			// _lblCommon_37
			// 
			this._lblCommon_37.AllowDrop = true;
			this._lblCommon_37.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_37.Text = "Company Code";
			this._lblCommon_37.Location = new System.Drawing.Point(458, 106);
			// // this._lblCommon_37.mLabelId = 1927;
			this._lblCommon_37.Name = "_lblCommon_37";
			this._lblCommon_37.Size = new System.Drawing.Size(73, 14);
			this._lblCommon_37.TabIndex = 192;
			// 
			// _txtDisplayLabel_6
			// 
			this._txtDisplayLabel_6.AllowDrop = true;
			this._txtDisplayLabel_6.Location = new System.Drawing.Point(643, 104);
			this._txtDisplayLabel_6.Name = "_txtDisplayLabel_6";
			this._txtDisplayLabel_6.Size = new System.Drawing.Size(194, 19);
			this._txtDisplayLabel_6.TabIndex = 193;
			this._txtDisplayLabel_6.TabStop = false;
			// 
			// txtProbationEndDate
			// 
			this.txtProbationEndDate.AllowDrop = true;
			// this.txtProbationEndDate.CheckDateRange = false;
			this.txtProbationEndDate.Location = new System.Drawing.Point(277, 78);
			// this.txtProbationEndDate.MaxDate = 2958465;
			// this.txtProbationEndDate.MinDate = 2;
			this.txtProbationEndDate.Name = "txtProbationEndDate";
			this.txtProbationEndDate.Size = new System.Drawing.Size(97, 19);
			this.txtProbationEndDate.TabIndex = 188;
			this.txtProbationEndDate.Text = "18/Jul/2001";
			// this.txtProbationEndDate.Value = 37090;
			// 
			// _txtDisplayLabel_7
			// 
			this._txtDisplayLabel_7.AllowDrop = true;
			this._txtDisplayLabel_7.Location = new System.Drawing.Point(201, 105);
			this._txtDisplayLabel_7.Name = "_txtDisplayLabel_7";
			this._txtDisplayLabel_7.Size = new System.Drawing.Size(173, 19);
			this._txtDisplayLabel_7.TabIndex = 194;
			this._txtDisplayLabel_7.TabStop = false;
			// 
			// _txtCommonTextBox_39
			// 
			this._txtCommonTextBox_39.AllowDrop = true;
			this._txtCommonTextBox_39.BackColor = System.Drawing.Color.White;
			// this._txtCommonTextBox_39.bolNumericOnly = true;
			this._txtCommonTextBox_39.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_39.Location = new System.Drawing.Point(539, 104);
			this._txtCommonTextBox_39.MaxLength = 8;
			this._txtCommonTextBox_39.Name = "_txtCommonTextBox_39";
			// this._txtCommonTextBox_39.ShowButton = true;
			this._txtCommonTextBox_39.Size = new System.Drawing.Size(101, 19);
			this._txtCommonTextBox_39.TabIndex = 198;
			this._txtCommonTextBox_39.Text = "";
			// this.this._txtCommonTextBox_39.Watermark = "";
			// this.this._txtCommonTextBox_39.Change += new System.Windows.Forms.TextBox.ChangeHandler(this.txtCommonTextBox_Change);
			// this.this._txtCommonTextBox_39.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_39.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _txtCommonTextBox_52
			// 
			this._txtCommonTextBox_52.AllowDrop = true;
			this._txtCommonTextBox_52.BackColor = System.Drawing.Color.White;
			// this._txtCommonTextBox_52.bolNumericOnly = true;
			this._txtCommonTextBox_52.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_52.Location = new System.Drawing.Point(539, 126);
			this._txtCommonTextBox_52.MaxLength = 20;
			this._txtCommonTextBox_52.Name = "_txtCommonTextBox_52";
			// this._txtCommonTextBox_52.ShowButton = true;
			this._txtCommonTextBox_52.Size = new System.Drawing.Size(101, 19);
			this._txtCommonTextBox_52.TabIndex = 199;
			this._txtCommonTextBox_52.Text = "";
			// this.this._txtCommonTextBox_52.Watermark = "";
			// this.this._txtCommonTextBox_52.Change += new System.Windows.Forms.TextBox.ChangeHandler(this.txtCommonTextBox_Change);
			// this.this._txtCommonTextBox_52.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_52.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _txtDisplayLabel_10
			// 
			this._txtDisplayLabel_10.AllowDrop = true;
			this._txtDisplayLabel_10.Location = new System.Drawing.Point(643, 126);
			this._txtDisplayLabel_10.Name = "_txtDisplayLabel_10";
			this._txtDisplayLabel_10.Size = new System.Drawing.Size(194, 19);
			this._txtDisplayLabel_10.TabIndex = 202;
			this._txtDisplayLabel_10.TabStop = false;
			// 
			// _txtCommonTextBox_56
			// 
			this._txtCommonTextBox_56.AllowDrop = true;
			this._txtCommonTextBox_56.BackColor = System.Drawing.Color.White;
			// this._txtCommonTextBox_56.bolNumericOnly = true;
			this._txtCommonTextBox_56.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_56.Location = new System.Drawing.Point(202, 78);
			this._txtCommonTextBox_56.MaxLength = 8;
			this._txtCommonTextBox_56.Name = "_txtCommonTextBox_56";
			this._txtCommonTextBox_56.Size = new System.Drawing.Size(73, 19);
			this._txtCommonTextBox_56.TabIndex = 187;
			this._txtCommonTextBox_56.Text = "";
			// this.this._txtCommonTextBox_56.Watermark = "";
			// this.this._txtCommonTextBox_56.Change += new System.Windows.Forms.TextBox.ChangeHandler(this.txtCommonTextBox_Change);
			// this.this._txtCommonTextBox_56.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_56.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// txtDeductionHrs
			// 
			this.txtDeductionHrs.AllowDrop = true;
			this.txtDeductionHrs.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			this.txtDeductionHrs.Enabled = false;
			this.txtDeductionHrs.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtDeductionHrs.Location = new System.Drawing.Point(734, 153);
			this.txtDeductionHrs.Name = "txtDeductionHrs";
			this.txtDeductionHrs.Size = new System.Drawing.Size(103, 21);
			this.txtDeductionHrs.TabIndex = 206;
			this.txtDeductionHrs.Visible = false;
			// 
			// _lblCommon_55
			// 
			this._lblCommon_55.AllowDrop = true;
			this._lblCommon_55.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_55.Text = "Contract Date";
			this._lblCommon_55.Location = new System.Drawing.Point(10, 183);
			// // this._lblCommon_55.mLabelId = 2141;
			this._lblCommon_55.Name = "_lblCommon_55";
			this._lblCommon_55.Size = new System.Drawing.Size(66, 14);
			this._lblCommon_55.TabIndex = 212;
			// 
			// txtContractStratDate
			// 
			this.txtContractStratDate.AllowDrop = true;
			this.txtContractStratDate.BackColor = System.Drawing.Color.FromArgb(239, 239, 239);
			// this.txtContractStratDate.CheckDateRange = false;
			this.txtContractStratDate.Enabled = false;
			this.txtContractStratDate.Location = new System.Drawing.Point(98, 181);
			// this.txtContractStratDate.MaxDate = 2958465;
			// this.txtContractStratDate.MinDate = 2;
			this.txtContractStratDate.Name = "txtContractStratDate";
			this.txtContractStratDate.Size = new System.Drawing.Size(102, 19);
			this.txtContractStratDate.TabIndex = 213;
			this.txtContractStratDate.Text = "18/Jul/2001";
			// this.txtContractStratDate.Value = 37090;
			// 
			// txtContractEndDate
			// 
			this.txtContractEndDate.AllowDrop = true;
			this.txtContractEndDate.BackColor = System.Drawing.Color.FromArgb(239, 239, 239);
			// this.txtContractEndDate.CheckDateRange = false;
			this.txtContractEndDate.Enabled = false;
			this.txtContractEndDate.Location = new System.Drawing.Point(539, 181);
			// this.txtContractEndDate.MaxDate = 2958465;
			// this.txtContractEndDate.MinDate = 2;
			this.txtContractEndDate.Name = "txtContractEndDate";
			this.txtContractEndDate.Size = new System.Drawing.Size(102, 19);
			this.txtContractEndDate.TabIndex = 217;
			this.txtContractEndDate.Text = "18/Jul/2001";
			// this.txtContractEndDate.Value = 37090;
			// 
			// _txtDisplayLabel_14
			// 
			this._txtDisplayLabel_14.AllowDrop = true;
			this._txtDisplayLabel_14.Location = new System.Drawing.Point(98, 244);
			this._txtDisplayLabel_14.Name = "_txtDisplayLabel_14";
			this._txtDisplayLabel_14.Size = new System.Drawing.Size(738, 19);
			this._txtDisplayLabel_14.TabIndex = 223;
			this._txtDisplayLabel_14.TabStop = false;
			this._txtDisplayLabel_14.Visible = false;
			// 
			// _txtDisplayLabel_16
			// 
			this._txtDisplayLabel_16.AllowDrop = true;
			this._txtDisplayLabel_16.Location = new System.Drawing.Point(98, 265);
			this._txtDisplayLabel_16.Name = "_txtDisplayLabel_16";
			this._txtDisplayLabel_16.Size = new System.Drawing.Size(738, 19);
			this._txtDisplayLabel_16.TabIndex = 225;
			this._txtDisplayLabel_16.TabStop = false;
			this._txtDisplayLabel_16.Visible = false;
			// 
			// _lblCommon_56
			// 
			this._lblCommon_56.AllowDrop = true;
			this._lblCommon_56.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_56.Text = "Emp Full Name";
			this._lblCommon_56.Location = new System.Drawing.Point(10, 246);
			this._lblCommon_56.Name = "_lblCommon_56";
			this._lblCommon_56.Size = new System.Drawing.Size(69, 14);
			this._lblCommon_56.TabIndex = 222;
			this._lblCommon_56.Visible = false;
			// 
			// _lblCommon_57
			// 
			this._lblCommon_57.AllowDrop = true;
			this._lblCommon_57.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_57.Text = "Emp Full Name";
			this._lblCommon_57.Location = new System.Drawing.Point(10, 267);
			this._lblCommon_57.Name = "_lblCommon_57";
			this._lblCommon_57.Size = new System.Drawing.Size(69, 14);
			this._lblCommon_57.TabIndex = 224;
			this._lblCommon_57.Visible = false;
			// 
			// _txtCommonTextBox_70
			// 
			this._txtCommonTextBox_70.AllowDrop = true;
			this._txtCommonTextBox_70.BackColor = System.Drawing.Color.White;
			// this._txtCommonTextBox_70.bolNumericOnly = true;
			this._txtCommonTextBox_70.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_70.Location = new System.Drawing.Point(539, 12);
			this._txtCommonTextBox_70.MaxLength = 20;
			this._txtCommonTextBox_70.Name = "_txtCommonTextBox_70";
			// this._txtCommonTextBox_70.ShowButton = true;
			this._txtCommonTextBox_70.Size = new System.Drawing.Size(101, 19);
			this._txtCommonTextBox_70.TabIndex = 166;
			this._txtCommonTextBox_70.Text = "";
			// this.this._txtCommonTextBox_70.Watermark = "";
			// this.this._txtCommonTextBox_70.Change += new System.Windows.Forms.TextBox.ChangeHandler(this.txtCommonTextBox_Change);
			// this.this._txtCommonTextBox_70.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_70.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _lblCommon_73
			// 
			this._lblCommon_73.AllowDrop = true;
			this._lblCommon_73.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_73.Text = "Location";
			this._lblCommon_73.Location = new System.Drawing.Point(458, 13);
			// // this._lblCommon_73.mLabelId = 414;
			this._lblCommon_73.Name = "_lblCommon_73";
			this._lblCommon_73.Size = new System.Drawing.Size(41, 14);
			this._lblCommon_73.TabIndex = 168;
			// 
			// _txtDisplayLabel_17
			// 
			this._txtDisplayLabel_17.AllowDrop = true;
			this._txtDisplayLabel_17.Location = new System.Drawing.Point(643, 12);
			this._txtDisplayLabel_17.Name = "_txtDisplayLabel_17";
			this._txtDisplayLabel_17.Size = new System.Drawing.Size(194, 19);
			this._txtDisplayLabel_17.TabIndex = 203;
			this._txtDisplayLabel_17.TabStop = false;
			// 
			// txtDSeveranceDate
			// 
			this.txtDSeveranceDate.AllowDrop = true;
			this.txtDSeveranceDate.BackColor = System.Drawing.Color.FromArgb(239, 239, 239);
			// this.txtDSeveranceDate.CheckDateRange = false;
			this.txtDSeveranceDate.Enabled = false;
			this.txtDSeveranceDate.Location = new System.Drawing.Point(735, 55);
			// this.txtDSeveranceDate.MaxDate = 2958465;
			// this.txtDSeveranceDate.MinDate = 32874;
			this.txtDSeveranceDate.Name = "txtDSeveranceDate";
			this.txtDSeveranceDate.Size = new System.Drawing.Size(102, 21);
			this.txtDSeveranceDate.TabIndex = 182;
			this.txtDSeveranceDate.Text = "01/Apr/2012";
			// this.txtDSeveranceDate.Value = 41000;
			// 
			// _lblCommon_42
			// 
			this._lblCommon_42.AllowDrop = true;
			this._lblCommon_42.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_42.Text = "Probation End ";
			this._lblCommon_42.Location = new System.Drawing.Point(296, 58);
			// // this._lblCommon_42.mLabelId = 1992;
			this._lblCommon_42.Name = "_lblCommon_42";
			this._lblCommon_42.Size = new System.Drawing.Size(69, 14);
			this._lblCommon_42.TabIndex = 177;
			// 
			// _lblCommon_111
			// 
			this._lblCommon_111.AllowDrop = true;
			this._lblCommon_111.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_111.Text = "Age";
			this._lblCommon_111.Location = new System.Drawing.Point(458, 59);
			// // this._lblCommon_111.mLabelId = 1982;
			this._lblCommon_111.Name = "_lblCommon_111";
			this._lblCommon_111.Size = new System.Drawing.Size(20, 14);
			this._lblCommon_111.TabIndex = 179;
			// 
			// _lblCommonLabel_0
			// 
			this._lblCommonLabel_0.AllowDrop = true;
			this._lblCommonLabel_0.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_0.Text = "Severance Date";
			this._lblCommonLabel_0.Location = new System.Drawing.Point(644, 60);
			// // this._lblCommonLabel_0.mLabelId = 1235;
			this._lblCommonLabel_0.Name = "_lblCommonLabel_0";
			this._lblCommonLabel_0.Size = new System.Drawing.Size(78, 14);
			this._lblCommonLabel_0.TabIndex = 181;
			// 
			// Label1_2
			// 
			this.Label1_2.AllowDrop = true;
			this.Label1_2.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.Label1_2.Text = "Marital Status";
			this.Label1_2.Location = new System.Drawing.Point(208, 158);
			// this.Label1_2.mLabelId = 1928;
			this.Label1_2.Name = "Label1_2";
			this.Label1_2.Size = new System.Drawing.Size(65, 14);
			this.Label1_2.TabIndex = 205;
			// 
			// _lblCommon_41
			// 
			this._lblCommon_41.AllowDrop = true;
			this._lblCommon_41.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_41.Text = "Sponsor Code";
			this._lblCommon_41.Location = new System.Drawing.Point(458, 129);
			// // this._lblCommon_41.mLabelId = 1939;
			this._lblCommon_41.Name = "_lblCommon_41";
			this._lblCommon_41.Size = new System.Drawing.Size(67, 13);
			this._lblCommon_41.TabIndex = 201;
			// 
			// _lblCommon_49
			// 
			this._lblCommon_49.AllowDrop = true;
			this._lblCommon_49.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_49.Text = "Probation Days";
			this._lblCommon_49.Location = new System.Drawing.Point(204, 58);
			this._lblCommon_49.Name = "_lblCommon_49";
			this._lblCommon_49.Size = new System.Drawing.Size(73, 14);
			this._lblCommon_49.TabIndex = 178;
			// 
			// lblDeductionHrs
			// 
			this.lblDeductionHrs.AllowDrop = true;
			this.lblDeductionHrs.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblDeductionHrs.Text = "Deduction Hours";
			this.lblDeductionHrs.Location = new System.Drawing.Point(649, 156);
			this.lblDeductionHrs.Name = "lblDeductionHrs";
			this.lblDeductionHrs.Size = new System.Drawing.Size(80, 14);
			this.lblDeductionHrs.TabIndex = 209;
			this.lblDeductionHrs.Visible = false;
			// 
			// Label1_4
			// 
			this.Label1_4.AllowDrop = true;
			this.Label1_4.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.Label1_4.Text = "Contract Period";
			this.Label1_4.Location = new System.Drawing.Point(204, 183);
			// this.Label1_4.mLabelId = 2143;
			this.Label1_4.Name = "Label1_4";
			this.Label1_4.Size = new System.Drawing.Size(74, 14);
			this.Label1_4.TabIndex = 214;
			// 
			// Label1_5
			// 
			this.Label1_5.AllowDrop = true;
			this.Label1_5.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.Label1_5.Text = "Contarct End";
			this.Label1_5.Location = new System.Drawing.Point(460, 183);
			// this.Label1_5.mLabelId = 2142;
			this.Label1_5.Name = "Label1_5";
			this.Label1_5.Size = new System.Drawing.Size(62, 14);
			this.Label1_5.TabIndex = 216;
			// 
			// lblNoticePeriod
			// 
			this.lblNoticePeriod.AllowDrop = true;
			this.lblNoticePeriod.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblNoticePeriod.Text = "Notice Period";
			this.lblNoticePeriod.Location = new System.Drawing.Point(649, 183);
			// // this.lblNoticePeriod.mLabelId = 2175;
			this.lblNoticePeriod.Name = "lblNoticePeriod";
			this.lblNoticePeriod.Size = new System.Drawing.Size(63, 14);
			this.lblNoticePeriod.TabIndex = 218;
			// 
			// _cmbCommon_0
			// 
			this._cmbCommon_0.AllowDrop = true;
			this._cmbCommon_0.Location = new System.Drawing.Point(465, 52);
			this._cmbCommon_0.Name = "_cmbCommon_0";
			this._cmbCommon_0.Size = new System.Drawing.Size(101, 21);
			this._cmbCommon_0.TabIndex = 2;
			// this.this._cmbCommon_0.Change += new System.Windows.Forms.ComboBox.ChangeHandler(this.cmbCommon_Change);
			// this._cmbCommon_0.Click += new System.Windows.Forms.ComboBox.ClickHandler(this.cmbCommon_Click);
			// 
			// _lblCommon_113
			// 
			this._lblCommon_113.AllowDrop = true;
			this._lblCommon_113.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_113.Text = "Employee Code";
			this._lblCommon_113.Location = new System.Drawing.Point(171, 54);
			// // this._lblCommon_113.mLabelId = 236;
			this._lblCommon_113.Name = "_lblCommon_113";
			this._lblCommon_113.Size = new System.Drawing.Size(74, 14);
			this._lblCommon_113.TabIndex = 18;
			// 
			// _txtCommonTextBox_0
			// 
			this._txtCommonTextBox_0.AllowDrop = true;
			this._txtCommonTextBox_0.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_0.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_0.Location = new System.Drawing.Point(255, 52);
			this._txtCommonTextBox_0.MaxLength = 20;
			// this._txtCommonTextBox_0.mDropDownType = System.Windows.Forms.TextBox.DropDownTypes.ddtNextNumber;
			this._txtCommonTextBox_0.Name = "_txtCommonTextBox_0";
			// this._txtCommonTextBox_0.ShowButton = true;
			this._txtCommonTextBox_0.Size = new System.Drawing.Size(102, 19);
			this._txtCommonTextBox_0.TabIndex = 0;
			this._txtCommonTextBox_0.Text = "";
			// this.this._txtCommonTextBox_0.Watermark = "";
			// this.this._txtCommonTextBox_0.Change += new System.Windows.Forms.TextBox.ChangeHandler(this.txtCommonTextBox_Change);
			// this.this._txtCommonTextBox_0.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_0.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// Label1_0
			// 
			this.Label1_0.AllowDrop = true;
			this.Label1_0.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.Label1_0.Text = "Title";
			this.Label1_0.Location = new System.Drawing.Point(439, 55);
			// this.Label1_0.mLabelId = 1052;
			this.Label1_0.Name = "Label1_0";
			this.Label1_0.Size = new System.Drawing.Size(19, 14);
			this.Label1_0.TabIndex = 1;
			// 
			// _lblCommon_102
			// 
			this._lblCommon_102.AllowDrop = true;
			this._lblCommon_102.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_102.Text = "Status";
			this._lblCommon_102.Location = new System.Drawing.Point(605, 54);
			// // this._lblCommon_102.mLabelId = 1834;
			this._lblCommon_102.Name = "_lblCommon_102";
			this._lblCommon_102.Size = new System.Drawing.Size(31, 14);
			this._lblCommon_102.TabIndex = 17;
			// 
			// _lblCommon_6
			// 
			this._lblCommon_6.AllowDrop = true;
			this._lblCommon_6.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_6.Text = "Name (Arabic)";
			this._lblCommon_6.Location = new System.Drawing.Point(171, 135);
			// // this._lblCommon_6.mLabelId = 1054;
			this._lblCommon_6.Name = "_lblCommon_6";
			this._lblCommon_6.Size = new System.Drawing.Size(68, 13);
			this._lblCommon_6.TabIndex = 5;
			// 
			// _txtCommonTextBox_8
			// 
			this._txtCommonTextBox_8.AllowDrop = true;
			this._txtCommonTextBox_8.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_8.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_8.Location = new System.Drawing.Point(360, 132);
			// this._txtCommonTextBox_8.mArabicEnabled = true;
			this._txtCommonTextBox_8.Name = "_txtCommonTextBox_8";
			this._txtCommonTextBox_8.Size = new System.Drawing.Size(102, 19);
			this._txtCommonTextBox_8.TabIndex = 27;
			this._txtCommonTextBox_8.Text = "";
			// this.this._txtCommonTextBox_8.Watermark = "";
			// this.this._txtCommonTextBox_8.Change += new System.Windows.Forms.TextBox.ChangeHandler(this.txtCommonTextBox_Change);
			// this.this._txtCommonTextBox_8.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_8.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _txtCommonTextBox_7
			// 
			this._txtCommonTextBox_7.AllowDrop = true;
			this._txtCommonTextBox_7.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_7.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_7.Location = new System.Drawing.Point(464, 132);
			// this._txtCommonTextBox_7.mArabicEnabled = true;
			this._txtCommonTextBox_7.Name = "_txtCommonTextBox_7";
			this._txtCommonTextBox_7.Size = new System.Drawing.Size(102, 19);
			this._txtCommonTextBox_7.TabIndex = 26;
			this._txtCommonTextBox_7.Text = "";
			// this.this._txtCommonTextBox_7.Watermark = "";
			// this.this._txtCommonTextBox_7.Change += new System.Windows.Forms.TextBox.ChangeHandler(this.txtCommonTextBox_Change);
			// this.this._txtCommonTextBox_7.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_7.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _txtCommonTextBox_6
			// 
			this._txtCommonTextBox_6.AllowDrop = true;
			this._txtCommonTextBox_6.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_6.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_6.Location = new System.Drawing.Point(568, 132);
			// this._txtCommonTextBox_6.mArabicEnabled = true;
			this._txtCommonTextBox_6.Name = "_txtCommonTextBox_6";
			this._txtCommonTextBox_6.Size = new System.Drawing.Size(102, 19);
			this._txtCommonTextBox_6.TabIndex = 25;
			this._txtCommonTextBox_6.Text = "";
			// this.this._txtCommonTextBox_6.Watermark = "";
			// this.this._txtCommonTextBox_6.Change += new System.Windows.Forms.TextBox.ChangeHandler(this.txtCommonTextBox_Change);
			// this.this._txtCommonTextBox_6.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_6.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _txtCommonTextBox_5
			// 
			this._txtCommonTextBox_5.AllowDrop = true;
			this._txtCommonTextBox_5.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_5.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_5.Location = new System.Drawing.Point(672, 132);
			// this._txtCommonTextBox_5.mArabicEnabled = true;
			this._txtCommonTextBox_5.Name = "_txtCommonTextBox_5";
			this._txtCommonTextBox_5.Size = new System.Drawing.Size(102, 19);
			this._txtCommonTextBox_5.TabIndex = 24;
			this._txtCommonTextBox_5.Text = "";
			// this.this._txtCommonTextBox_5.Watermark = "";
			// this.this._txtCommonTextBox_5.Change += new System.Windows.Forms.TextBox.ChangeHandler(this.txtCommonTextBox_Change);
			// this.this._txtCommonTextBox_5.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_5.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _txtCommonTextBox_4
			// 
			this._txtCommonTextBox_4.AllowDrop = true;
			this._txtCommonTextBox_4.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_4.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_4.Location = new System.Drawing.Point(567, 94);
			this._txtCommonTextBox_4.Name = "_txtCommonTextBox_4";
			this._txtCommonTextBox_4.Size = new System.Drawing.Size(102, 19);
			this._txtCommonTextBox_4.TabIndex = 22;
			this._txtCommonTextBox_4.Text = "";
			// this.this._txtCommonTextBox_4.Watermark = "Fourth Name";
			// this.this._txtCommonTextBox_4.Change += new System.Windows.Forms.TextBox.ChangeHandler(this.txtCommonTextBox_Change);
			// this.this._txtCommonTextBox_4.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_4.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _txtCommonTextBox_3
			// 
			this._txtCommonTextBox_3.AllowDrop = true;
			this._txtCommonTextBox_3.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_3.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_3.Location = new System.Drawing.Point(463, 94);
			this._txtCommonTextBox_3.Name = "_txtCommonTextBox_3";
			this._txtCommonTextBox_3.Size = new System.Drawing.Size(102, 19);
			this._txtCommonTextBox_3.TabIndex = 21;
			this._txtCommonTextBox_3.Text = "";
			// this.this._txtCommonTextBox_3.Watermark = "Third Name";
			// this.this._txtCommonTextBox_3.Change += new System.Windows.Forms.TextBox.ChangeHandler(this.txtCommonTextBox_Change);
			// this.this._txtCommonTextBox_3.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_3.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _txtCommonTextBox_2
			// 
			this._txtCommonTextBox_2.AllowDrop = true;
			this._txtCommonTextBox_2.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_2.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_2.Location = new System.Drawing.Point(359, 94);
			this._txtCommonTextBox_2.Name = "_txtCommonTextBox_2";
			this._txtCommonTextBox_2.Size = new System.Drawing.Size(102, 19);
			this._txtCommonTextBox_2.TabIndex = 20;
			this._txtCommonTextBox_2.Text = "";
			// this.this._txtCommonTextBox_2.Watermark = "Second Name";
			// this.this._txtCommonTextBox_2.Change += new System.Windows.Forms.TextBox.ChangeHandler(this.txtCommonTextBox_Change);
			// this.this._txtCommonTextBox_2.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_2.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _lblCommon_7
			// 
			this._lblCommon_7.AllowDrop = true;
			this._lblCommon_7.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_7.Text = "Fourth Name";
			this._lblCommon_7.Location = new System.Drawing.Point(587, 80);
			// // this._lblCommon_7.mLabelId = 1975;
			this._lblCommon_7.Name = "_lblCommon_7";
			this._lblCommon_7.Size = new System.Drawing.Size(62, 13);
			this._lblCommon_7.TabIndex = 6;
			// 
			// _lblCommon_8
			// 
			this._lblCommon_8.AllowDrop = true;
			this._lblCommon_8.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_8.Text = "Third Name";
			this._lblCommon_8.Location = new System.Drawing.Point(487, 80);
			// // this._lblCommon_8.mLabelId = 1977;
			this._lblCommon_8.Name = "_lblCommon_8";
			this._lblCommon_8.Size = new System.Drawing.Size(54, 13);
			this._lblCommon_8.TabIndex = 7;
			// 
			// _lblCommon_9
			// 
			this._lblCommon_9.AllowDrop = true;
			this._lblCommon_9.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_9.Text = "Second Name";
			this._lblCommon_9.Location = new System.Drawing.Point(378, 80);
			// // this._lblCommon_9.mLabelId = 1976;
			this._lblCommon_9.Name = "_lblCommon_9";
			this._lblCommon_9.Size = new System.Drawing.Size(65, 13);
			this._lblCommon_9.TabIndex = 8;
			// 
			// _lblCommon_10
			// 
			this._lblCommon_10.AllowDrop = true;
			this._lblCommon_10.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_10.Text = "Name (English)";
			this._lblCommon_10.Location = new System.Drawing.Point(171, 97);
			// // this._lblCommon_10.mLabelId = 1053;
			this._lblCommon_10.Name = "_lblCommon_10";
			this._lblCommon_10.Size = new System.Drawing.Size(71, 13);
			this._lblCommon_10.TabIndex = 9;
			// 
			// _lblCommon_4
			// 
			this._lblCommon_4.AllowDrop = true;
			this._lblCommon_4.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_4.Text = "First Name";
			this._lblCommon_4.Location = new System.Drawing.Point(281, 80);
			// // this._lblCommon_4.mLabelId = 1974;
			this._lblCommon_4.Name = "_lblCommon_4";
			this._lblCommon_4.Size = new System.Drawing.Size(51, 13);
			this._lblCommon_4.TabIndex = 4;
			// 
			// _txtCommonTextBox_1
			// 
			this._txtCommonTextBox_1.AllowDrop = true;
			this._txtCommonTextBox_1.BackColor = System.Drawing.Color.White;
			// this.this._txtCommonTextBox_1.bolIsRequired = true;
			this._txtCommonTextBox_1.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_1.Location = new System.Drawing.Point(255, 94);
			this._txtCommonTextBox_1.Name = "_txtCommonTextBox_1";
			this._txtCommonTextBox_1.Size = new System.Drawing.Size(102, 19);
			this._txtCommonTextBox_1.TabIndex = 19;
			this._txtCommonTextBox_1.Text = "";
			// this.this._txtCommonTextBox_1.Watermark = "First Name";
			// this.this._txtCommonTextBox_1.Change += new System.Windows.Forms.TextBox.ChangeHandler(this.txtCommonTextBox_Change);
			// this.this._txtCommonTextBox_1.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_1.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _txtDisplayLabel_0
			// 
			this._txtDisplayLabel_0.AllowDrop = true;
			this._txtDisplayLabel_0.Location = new System.Drawing.Point(670, 52);
			this._txtDisplayLabel_0.Name = "_txtDisplayLabel_0";
			this._txtDisplayLabel_0.Size = new System.Drawing.Size(101, 19);
			this._txtDisplayLabel_0.TabIndex = 3;
			this._txtDisplayLabel_0.TabStop = false;
			// 
			// _lblCommon_46
			// 
			this._lblCommon_46.AllowDrop = true;
			this._lblCommon_46.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._lblCommon_46.Text = "Probation End ";
			this._lblCommon_46.Location = new System.Drawing.Point(202, 246);
			// // this._lblCommon_46.mLabelId = 1992;
			this._lblCommon_46.Name = "_lblCommon_46";
			this._lblCommon_46.Size = new System.Drawing.Size(69, 14);
			this._lblCommon_46.TabIndex = 10;
			// 
			// _lblCommon_50
			// 
			this._lblCommon_50.AllowDrop = true;
			this._lblCommon_50.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_50.Text = "Fourth Name";
			this._lblCommon_50.Location = new System.Drawing.Point(378, 118);
			// // this._lblCommon_50.mLabelId = 1975;
			this._lblCommon_50.Name = "_lblCommon_50";
			this._lblCommon_50.Size = new System.Drawing.Size(62, 13);
			this._lblCommon_50.TabIndex = 11;
			// 
			// _lblCommon_51
			// 
			this._lblCommon_51.AllowDrop = true;
			this._lblCommon_51.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_51.Text = "Third Name";
			this._lblCommon_51.Location = new System.Drawing.Point(484, 118);
			// // this._lblCommon_51.mLabelId = 1977;
			this._lblCommon_51.Name = "_lblCommon_51";
			this._lblCommon_51.Size = new System.Drawing.Size(54, 13);
			this._lblCommon_51.TabIndex = 12;
			// 
			// _lblCommon_52
			// 
			this._lblCommon_52.AllowDrop = true;
			this._lblCommon_52.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_52.Text = "Second Name";
			this._lblCommon_52.Location = new System.Drawing.Point(588, 118);
			// // this._lblCommon_52.mLabelId = 1976;
			this._lblCommon_52.Name = "_lblCommon_52";
			this._lblCommon_52.Size = new System.Drawing.Size(65, 13);
			this._lblCommon_52.TabIndex = 13;
			// 
			// _lblCommon_53
			// 
			this._lblCommon_53.AllowDrop = true;
			this._lblCommon_53.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_53.Text = "First Name";
			this._lblCommon_53.Location = new System.Drawing.Point(696, 118);
			// // this._lblCommon_53.mLabelId = 1974;
			this._lblCommon_53.Name = "_lblCommon_53";
			this._lblCommon_53.Size = new System.Drawing.Size(51, 13);
			this._lblCommon_53.TabIndex = 14;
			// 
			// _txtCommonTextBox_58
			// 
			this._txtCommonTextBox_58.AllowDrop = true;
			this._txtCommonTextBox_58.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_58.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_58.Location = new System.Drawing.Point(255, 132);
			// this._txtCommonTextBox_58.mArabicEnabled = true;
			this._txtCommonTextBox_58.Name = "_txtCommonTextBox_58";
			this._txtCommonTextBox_58.Size = new System.Drawing.Size(102, 19);
			this._txtCommonTextBox_58.TabIndex = 28;
			this._txtCommonTextBox_58.Text = "";
			// this.this._txtCommonTextBox_58.Watermark = "";
			// this.this._txtCommonTextBox_58.Change += new System.Windows.Forms.TextBox.ChangeHandler(this.txtCommonTextBox_Change);
			// this.this._txtCommonTextBox_58.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_58.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _txtCommonTextBox_59
			// 
			this._txtCommonTextBox_59.AllowDrop = true;
			this._txtCommonTextBox_59.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_59.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_59.Location = new System.Drawing.Point(672, 94);
			// this._txtCommonTextBox_59.mArabicEnabled = true;
			this._txtCommonTextBox_59.Name = "_txtCommonTextBox_59";
			this._txtCommonTextBox_59.Size = new System.Drawing.Size(102, 19);
			this._txtCommonTextBox_59.TabIndex = 23;
			this._txtCommonTextBox_59.Text = "";
			// this.this._txtCommonTextBox_59.Watermark = "Fifth Name";
			// this.this._txtCommonTextBox_59.Change += new System.Windows.Forms.TextBox.ChangeHandler(this.txtCommonTextBox_Change);
			// this.this._txtCommonTextBox_59.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_59.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _lblCommon_58
			// 
			this._lblCommon_58.AllowDrop = true;
			this._lblCommon_58.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_58.Text = "Fifth Name";
			this._lblCommon_58.Location = new System.Drawing.Point(690, 80);
			// // this._lblCommon_58.mLabelId = 2219;
			this._lblCommon_58.Name = "_lblCommon_58";
			this._lblCommon_58.Size = new System.Drawing.Size(52, 13);
			this._lblCommon_58.TabIndex = 15;
			// 
			// _lblCommon_59
			// 
			this._lblCommon_59.AllowDrop = true;
			this._lblCommon_59.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_59.Text = "Fifth Name";
			this._lblCommon_59.Location = new System.Drawing.Point(270, 118);
			// // this._lblCommon_59.mLabelId = 2219;
			this._lblCommon_59.Name = "_lblCommon_59";
			this._lblCommon_59.Size = new System.Drawing.Size(52, 13);
			this._lblCommon_59.TabIndex = 16;
			// 
			// imgPicture
			// 
			this.imgPicture.AllowDrop = true;
			this.imgPicture.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.imgPicture.Cursor = System.Windows.Forms.Cursors.Help;
			this.imgPicture.Enabled = true;
			this.imgPicture.Location = new System.Drawing.Point(22, 36);
			this.imgPicture.Name = "imgPicture";
			this.imgPicture.Size = new System.Drawing.Size(126, 126);
			this.imgPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.imgPicture.Visible = true;
			this.imgPicture.DoubleClick += new System.EventHandler(this.imgPicture_DoubleClick);
			this.imgPicture.MouseMove += new System.Windows.Forms.MouseEventHandler(this.imgPicture_MouseMove);
			// 
			// Image1
			// 
			this.Image1.AllowDrop = true;
			this.Image1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Image1.Enabled = true;
			//this.Image1.Image = (System.Drawing.Image) resources.GetObject("Image1.Image");
			this.Image1.Location = new System.Drawing.Point(20, 34);
			this.Image1.Name = "Image1";
			this.Image1.Size = new System.Drawing.Size(130, 130);
			this.Image1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal;
			this.Image1.Visible = true;
			// 
			// frmPayEmployee
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.ClientSize = new System.Drawing.Size(947, 607);
			this.Controls.Add(this.tabEmployee);
			this.Controls.Add(this._cmbCommon_0);
			this.Controls.Add(this._lblCommon_113);
			this.Controls.Add(this._txtCommonTextBox_0);
			this.Controls.Add(this.Label1_0);
			this.Controls.Add(this._lblCommon_102);
			this.Controls.Add(this._lblCommon_6);
			this.Controls.Add(this._txtCommonTextBox_8);
			this.Controls.Add(this._txtCommonTextBox_7);
			this.Controls.Add(this._txtCommonTextBox_6);
			this.Controls.Add(this._txtCommonTextBox_5);
			this.Controls.Add(this._txtCommonTextBox_4);
			this.Controls.Add(this._txtCommonTextBox_3);
			this.Controls.Add(this._txtCommonTextBox_2);
			this.Controls.Add(this._lblCommon_7);
			this.Controls.Add(this._lblCommon_8);
			this.Controls.Add(this._lblCommon_9);
			this.Controls.Add(this._lblCommon_10);
			this.Controls.Add(this._lblCommon_4);
			this.Controls.Add(this._txtCommonTextBox_1);
			this.Controls.Add(this._txtDisplayLabel_0);
			this.Controls.Add(this._lblCommon_46);
			this.Controls.Add(this._lblCommon_50);
			this.Controls.Add(this._lblCommon_51);
			this.Controls.Add(this._lblCommon_52);
			this.Controls.Add(this._lblCommon_53);
			this.Controls.Add(this._txtCommonTextBox_58);
			this.Controls.Add(this._txtCommonTextBox_59);
			this.Controls.Add(this._lblCommon_58);
			this.Controls.Add(this._lblCommon_59);
			this.Controls.Add(this.imgPicture);
			this.Controls.Add(this.Image1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			//this.Icon = (System.Drawing.Icon) resources.GetObject("frmPayEmployee.Icon");
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(177, 139);
			this.MaximizeBox = true;
			this.MinimizeBox = true;
			this.Name = "frmPayEmployee";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Employee";
			this.ToolTipMain.SetToolTip(this.imgPicture, "Double Click to Select Picture");
			// this.Activated += new System.EventHandler(this.frmPayEmployee_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
			// this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
			//this.Resize += new System.EventHandler(this.Form_Resize);
			//((System.ComponentModel.ISupportInitialize) this._fraEmployeeInformation_1).EndInit();
			//((System.ComponentModel.ISupportInitialize) this.TabControlPage4).EndInit();
			//((System.ComponentModel.ISupportInitialize) this._fraEmployeeInformation_2).EndInit();
			//((System.ComponentModel.ISupportInitialize) this.TabControlPage3).EndInit();
			//((System.ComponentModel.ISupportInitialize) this._fraEmployeeInformation_3).EndInit();
			//((System.ComponentModel.ISupportInitialize) this.TabControlPage2).EndInit();
			//((System.ComponentModel.ISupportInitialize) this._fraEmployeeInformation_4).EndInit();
			//((System.ComponentModel.ISupportInitialize) this.TabControlPage1).EndInit();
			//((System.ComponentModel.ISupportInitialize) this._fraEmployeeInformation_0).EndInit();
			//((System.ComponentModel.ISupportInitialize) this.tabEmployee).EndInit();
			this.tabEmployee.ResumeLayout(false);
			this.TabControlPage4.ResumeLayout(false);
			this._fraEmployeeInformation_1.ResumeLayout(false);
			this.TabControlPage3.ResumeLayout(false);
			this._fraEmployeeInformation_2.ResumeLayout(false);
			this.frmRasidence.ResumeLayout(false);
			this.TabControlPage2.ResumeLayout(false);
			this._fraEmployeeInformation_3.ResumeLayout(false);
			this.TabControlPage1.ResumeLayout(false);
			this._fraEmployeeInformation_4.ResumeLayout(false);
			this._fraEmployeeInformation_0.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		void ReLoadForm(bool addEvents)
		{
			InitializetxtDisplayLabel();
			InitializetxtCommonTextBox();
			InitializelblCommonLabel();
			InitializelblCommon();
			InitializefraEmployeeInformation();
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
			this.txtDisplayLabel = new System.Windows.Forms.Label[19];
			this.txtDisplayLabel[9] = _txtDisplayLabel_9;
			this.txtDisplayLabel[15] = _txtDisplayLabel_15;
			this.txtDisplayLabel[11] = _txtDisplayLabel_11;
			this.txtDisplayLabel[12] = _txtDisplayLabel_12;
			this.txtDisplayLabel[13] = _txtDisplayLabel_13;
			this.txtDisplayLabel[18] = _txtDisplayLabel_18;
			this.txtDisplayLabel[1] = _txtDisplayLabel_1;
			this.txtDisplayLabel[2] = _txtDisplayLabel_2;
			this.txtDisplayLabel[3] = _txtDisplayLabel_3;
			this.txtDisplayLabel[4] = _txtDisplayLabel_4;
			this.txtDisplayLabel[8] = _txtDisplayLabel_8;
			this.txtDisplayLabel[5] = _txtDisplayLabel_5;
			this.txtDisplayLabel[6] = _txtDisplayLabel_6;
			this.txtDisplayLabel[7] = _txtDisplayLabel_7;
			this.txtDisplayLabel[10] = _txtDisplayLabel_10;
			this.txtDisplayLabel[14] = _txtDisplayLabel_14;
			this.txtDisplayLabel[16] = _txtDisplayLabel_16;
			this.txtDisplayLabel[17] = _txtDisplayLabel_17;
			this.txtDisplayLabel[0] = _txtDisplayLabel_0;
		}
		void InitializetxtCommonTextBox()
		{
			this.txtCommonTextBox = new System.Windows.Forms.TextBox[74];
			this.txtCommonTextBox[31] = _txtCommonTextBox_31;
			this.txtCommonTextBox[57] = _txtCommonTextBox_57;
			this.txtCommonTextBox[29] = _txtCommonTextBox_29;
			this.txtCommonTextBox[26] = _txtCommonTextBox_26;
			this.txtCommonTextBox[25] = _txtCommonTextBox_25;
			this.txtCommonTextBox[22] = _txtCommonTextBox_22;
			this.txtCommonTextBox[24] = _txtCommonTextBox_24;
			this.txtCommonTextBox[21] = _txtCommonTextBox_21;
			this.txtCommonTextBox[19] = _txtCommonTextBox_19;
			this.txtCommonTextBox[18] = _txtCommonTextBox_18;
			this.txtCommonTextBox[17] = _txtCommonTextBox_17;
			this.txtCommonTextBox[34] = _txtCommonTextBox_34;
			this.txtCommonTextBox[33] = _txtCommonTextBox_33;
			this.txtCommonTextBox[32] = _txtCommonTextBox_32;
			this.txtCommonTextBox[35] = _txtCommonTextBox_35;
			this.txtCommonTextBox[37] = _txtCommonTextBox_37;
			this.txtCommonTextBox[65] = _txtCommonTextBox_65;
			this.txtCommonTextBox[66] = _txtCommonTextBox_66;
			this.txtCommonTextBox[67] = _txtCommonTextBox_67;
			this.txtCommonTextBox[68] = _txtCommonTextBox_68;
			this.txtCommonTextBox[69] = _txtCommonTextBox_69;
			this.txtCommonTextBox[28] = _txtCommonTextBox_28;
			this.txtCommonTextBox[27] = _txtCommonTextBox_27;
			this.txtCommonTextBox[23] = _txtCommonTextBox_23;
			this.txtCommonTextBox[20] = _txtCommonTextBox_20;
			this.txtCommonTextBox[16] = _txtCommonTextBox_16;
			this.txtCommonTextBox[30] = _txtCommonTextBox_30;
			this.txtCommonTextBox[51] = _txtCommonTextBox_51;
			this.txtCommonTextBox[50] = _txtCommonTextBox_50;
			this.txtCommonTextBox[38] = _txtCommonTextBox_38;
			this.txtCommonTextBox[14] = _txtCommonTextBox_14;
			this.txtCommonTextBox[49] = _txtCommonTextBox_49;
			this.txtCommonTextBox[40] = _txtCommonTextBox_40;
			this.txtCommonTextBox[41] = _txtCommonTextBox_41;
			this.txtCommonTextBox[42] = _txtCommonTextBox_42;
			this.txtCommonTextBox[43] = _txtCommonTextBox_43;
			this.txtCommonTextBox[46] = _txtCommonTextBox_46;
			this.txtCommonTextBox[47] = _txtCommonTextBox_47;
			this.txtCommonTextBox[48] = _txtCommonTextBox_48;
			this.txtCommonTextBox[44] = _txtCommonTextBox_44;
			this.txtCommonTextBox[45] = _txtCommonTextBox_45;
			this.txtCommonTextBox[54] = _txtCommonTextBox_54;
			this.txtCommonTextBox[55] = _txtCommonTextBox_55;
			this.txtCommonTextBox[53] = _txtCommonTextBox_53;
			this.txtCommonTextBox[60] = _txtCommonTextBox_60;
			this.txtCommonTextBox[61] = _txtCommonTextBox_61;
			this.txtCommonTextBox[62] = _txtCommonTextBox_62;
			this.txtCommonTextBox[63] = _txtCommonTextBox_63;
			this.txtCommonTextBox[64] = _txtCommonTextBox_64;
			this.txtCommonTextBox[71] = _txtCommonTextBox_71;
			this.txtCommonTextBox[73] = _txtCommonTextBox_73;
			this.txtCommonTextBox[72] = _txtCommonTextBox_72;
			this.txtCommonTextBox[9] = _txtCommonTextBox_9;
			this.txtCommonTextBox[10] = _txtCommonTextBox_10;
			this.txtCommonTextBox[11] = _txtCommonTextBox_11;
			this.txtCommonTextBox[12] = _txtCommonTextBox_12;
			this.txtCommonTextBox[13] = _txtCommonTextBox_13;
			this.txtCommonTextBox[15] = _txtCommonTextBox_15;
			this.txtCommonTextBox[36] = _txtCommonTextBox_36;
			this.txtCommonTextBox[39] = _txtCommonTextBox_39;
			this.txtCommonTextBox[52] = _txtCommonTextBox_52;
			this.txtCommonTextBox[56] = _txtCommonTextBox_56;
			this.txtCommonTextBox[70] = _txtCommonTextBox_70;
			this.txtCommonTextBox[0] = _txtCommonTextBox_0;
			this.txtCommonTextBox[8] = _txtCommonTextBox_8;
			this.txtCommonTextBox[7] = _txtCommonTextBox_7;
			this.txtCommonTextBox[6] = _txtCommonTextBox_6;
			this.txtCommonTextBox[5] = _txtCommonTextBox_5;
			this.txtCommonTextBox[4] = _txtCommonTextBox_4;
			this.txtCommonTextBox[3] = _txtCommonTextBox_3;
			this.txtCommonTextBox[2] = _txtCommonTextBox_2;
			this.txtCommonTextBox[1] = _txtCommonTextBox_1;
			this.txtCommonTextBox[58] = _txtCommonTextBox_58;
			this.txtCommonTextBox[59] = _txtCommonTextBox_59;
		}
		void InitializelblCommonLabel()
		{
			this.lblCommonLabel = new System.Windows.Forms.Label[13];
			this.lblCommonLabel[12] = _lblCommonLabel_12;
			this.lblCommonLabel[0] = _lblCommonLabel_0;
		}
		void InitializelblCommon()
		{
			this.lblCommon = new System.Windows.Forms.Label[117];
			this.lblCommon[47] = _lblCommon_47;
			this.lblCommon[48] = _lblCommon_48;
			this.lblCommon[1] = _lblCommon_1;
			this.lblCommon[3] = _lblCommon_3;
			this.lblCommon[5] = _lblCommon_5;
			this.lblCommon[11] = _lblCommon_11;
			this.lblCommon[12] = _lblCommon_12;
			this.lblCommon[13] = _lblCommon_13;
			this.lblCommon[14] = _lblCommon_14;
			this.lblCommon[15] = _lblCommon_15;
			this.lblCommon[16] = _lblCommon_16;
			this.lblCommon[17] = _lblCommon_17;
			this.lblCommon[18] = _lblCommon_18;
			this.lblCommon[19] = _lblCommon_19;
			this.lblCommon[20] = _lblCommon_20;
			this.lblCommon[21] = _lblCommon_21;
			this.lblCommon[22] = _lblCommon_22;
			this.lblCommon[24] = _lblCommon_24;
			this.lblCommon[25] = _lblCommon_25;
			this.lblCommon[26] = _lblCommon_26;
			this.lblCommon[36] = _lblCommon_36;
			this.lblCommon[65] = _lblCommon_65;
			this.lblCommon[66] = _lblCommon_66;
			this.lblCommon[67] = _lblCommon_67;
			this.lblCommon[69] = _lblCommon_69;
			this.lblCommon[71] = _lblCommon_71;
			this.lblCommon[72] = _lblCommon_72;
			this.lblCommon[2] = _lblCommon_2;
			this.lblCommon[40] = _lblCommon_40;
			this.lblCommon[39] = _lblCommon_39;
			this.lblCommon[30] = _lblCommon_30;
			this.lblCommon[0] = _lblCommon_0;
			this.lblCommon[38] = _lblCommon_38;
			this.lblCommon[27] = _lblCommon_27;
			this.lblCommon[28] = _lblCommon_28;
			this.lblCommon[29] = _lblCommon_29;
			this.lblCommon[31] = _lblCommon_31;
			this.lblCommon[32] = _lblCommon_32;
			this.lblCommon[115] = _lblCommon_115;
			this.lblCommon[33] = _lblCommon_33;
			this.lblCommon[34] = _lblCommon_34;
			this.lblCommon[35] = _lblCommon_35;
			this.lblCommon[44] = _lblCommon_44;
			this.lblCommon[45] = _lblCommon_45;
			this.lblCommon[43] = _lblCommon_43;
			this.lblCommon[60] = _lblCommon_60;
			this.lblCommon[61] = _lblCommon_61;
			this.lblCommon[62] = _lblCommon_62;
			this.lblCommon[63] = _lblCommon_63;
			this.lblCommon[64] = _lblCommon_64;
			this.lblCommon[23] = _lblCommon_23;
			this.lblCommon[54] = _lblCommon_54;
			this.lblCommon[68] = _lblCommon_68;
			this.lblCommon[70] = _lblCommon_70;
			this.lblCommon[74] = _lblCommon_74;
			this.lblCommon[116] = _lblCommon_116;
			this.lblCommon[105] = _lblCommon_105;
			this.lblCommon[114] = _lblCommon_114;
			this.lblCommon[104] = _lblCommon_104;
			this.lblCommon[108] = _lblCommon_108;
			this.lblCommon[109] = _lblCommon_109;
			this.lblCommon[112] = _lblCommon_112;
			this.lblCommon[103] = _lblCommon_103;
			this.lblCommon[37] = _lblCommon_37;
			this.lblCommon[55] = _lblCommon_55;
			this.lblCommon[56] = _lblCommon_56;
			this.lblCommon[57] = _lblCommon_57;
			this.lblCommon[73] = _lblCommon_73;
			this.lblCommon[42] = _lblCommon_42;
			this.lblCommon[111] = _lblCommon_111;
			this.lblCommon[41] = _lblCommon_41;
			this.lblCommon[49] = _lblCommon_49;
			this.lblCommon[113] = _lblCommon_113;
			this.lblCommon[102] = _lblCommon_102;
			this.lblCommon[6] = _lblCommon_6;
			this.lblCommon[7] = _lblCommon_7;
			this.lblCommon[8] = _lblCommon_8;
			this.lblCommon[9] = _lblCommon_9;
			this.lblCommon[10] = _lblCommon_10;
			this.lblCommon[4] = _lblCommon_4;
			this.lblCommon[46] = _lblCommon_46;
			this.lblCommon[50] = _lblCommon_50;
			this.lblCommon[51] = _lblCommon_51;
			this.lblCommon[52] = _lblCommon_52;
			this.lblCommon[53] = _lblCommon_53;
			this.lblCommon[58] = _lblCommon_58;
			this.lblCommon[59] = _lblCommon_59;
		}
		void InitializefraEmployeeInformation()
		{
			this.fraEmployeeInformation = new AxXtremeSuiteControls.AxTabControlPage[5];
			this.fraEmployeeInformation[1] = _fraEmployeeInformation_1;
			this.fraEmployeeInformation[2] = _fraEmployeeInformation_2;
			this.fraEmployeeInformation[3] = _fraEmployeeInformation_3;
			this.fraEmployeeInformation[4] = _fraEmployeeInformation_4;
			this.fraEmployeeInformation[0] = _fraEmployeeInformation_0;
		}
		void InitializecmbCommon()
		{
			this.cmbCommon = new System.Windows.Forms.ComboBox[4];
			this.cmbCommon[3] = _cmbCommon_3;
			this.cmbCommon[1] = _cmbCommon_1;
			this.cmbCommon[2] = _cmbCommon_2;
			this.cmbCommon[0] = _cmbCommon_0;
		}
		void InitializeSystem.Windows.Forms.Label1()
		{
			this.Label1 = new System.Windows.Forms.Label[6];
			this.Label1[1] = Label1_1;
			this.Label1[3] = Label1_3;
			this.Label1[2] = Label1_2;
			this.Label1[4] = Label1_4;
			this.Label1[5] = Label1_5;
			this.Label1[0] = Label1_0;
		}
		#endregion
	}
}//ENDSHERE
