
namespace Xtreme
{
	partial class frmPayEmployeeWazaraDetails
	{

		#region "Upgrade Support "
		private static frmPayEmployeeWazaraDetails m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmPayEmployeeWazaraDetails DefInstance
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
		public static frmPayEmployeeWazaraDetails CreateInstance()
		{
			frmPayEmployeeWazaraDetails theInstance = new frmPayEmployeeWazaraDetails();
			
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
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "cmdContract", "cmdTransfer", "cmdRenewal", "cmdVisaApplication", "cmdPullMasterData", "_lblCommon_0", "_txtCommonTextBox_16", "_lblCommon_30", "_txtCommonTextBox_17", "_lblCommon_38", "_txtCommonTextBox_19", "_lblCommon_39", "_txtCommonTextBox_21", "_txtCommonTextBox_20", "_lblCommon_43", "_lblCommon_23", "_txtCommonTextBox_22", "_lblCommonLabel_6", "_lblCommonLabel_17", "txtPassExpiryDate", "_lblCommon_42", "_txtCommonTextBox_55", "_lblCommon_44", "_txtCommonTextBox_56", "_lblCommon_45", "_txtCommonTextBox_57", "_lblCommon_46", "_txtCommonTextBox_58", "_lblCommon_49", "_txtCommonTextBox_59", "_lblCommon_54", "_txtCommonTextBox_60", "_lblCommon_55", "_txtCommonTextBox_61", "_lblCommon_56", "_txtCommonTextBox_62", "_lblCommon_57", "_lblCommon_58", "_lblCommon_59", "_txtCommonTextBox_65", "_txtCommonNumber_1", "_txtCommonNumber_0", "_lblCommonLabel_0", "txtDCivilIssueDate", "_lblCommonLabel_1", "txtDCivilExpiryDate", "_lblCommon_61", "_lblCommonLabel_2", "txtTypeofPassport", "txtPassIssueDate", "txtPassNat", "_lblCommonLabel_3", "txtPlaceofIssue", "_lblCommon_62", "_txtCommonTextBox_63", "lblDesignation", "lblsalary", "Frame1", "_lblCommon_114", "_lblCommon_27", "_txtCommonTextBox_12", "_lblCommon_28", "_txtCommonTextBox_13", "_lblCommon_29", "_txtCommonTextBox_14", "_lblCommon_31", "_txtCommonTextBox_15", "_lblCommon_115", "_txtCommonTextBox_10", "_txtCommonTextBox_11", "_lblCommon_34", "_txtCommonTextBox_9", "_txtCommonTextBox_46", "_lblCommon_35", "_txtCommonTextBox_47", "_lblCommon_112", "_txtDisplayLabel_7", "_lblCommon_41", "_txtCommonTextBox_52", "_txtDisplayLabel_10", "_lblCommon_40", "_txtCommonTextBox_51", "_txtDisplayLabel_9", "_lblCommonLabel_18", "_txtCommonTextBox_48", "_txtDisplayLabel_1", "_lblCommon_103", "_System.Windows.Forms.Label1_1", "_System.Windows.Forms.Label1_2", "_txtCommonTextBox_49", "_txtCommonTextBox_50", "_txtCommonTextBox_53", "_lblCommon_32", "_txtCommonTextBox_18", "_lblCommon_33", "_txtCommonTextBox_23", "_lblCommon_108", "txtBirthDate", "_txtCommonTextBox_54", "_lblCommon_37", "_lblCommon_60", "txtDEntryDate", "_fraEmployeeInformation_0", "_txtCommonTextBox_45", "System.Windows.Forms.Label2", "_lblCommon_1", "_txtCommonTextBox_29", "_lblCommon_2", "_txtCommonTextBox_28", "_lblCommon_3", "_txtCommonTextBox_27", "_lblCommon_5", "_txtCommonTextBox_26", "_lblCommon_11", "_txtCommonTextBox_25", "_lblCommon_12", "_txtCommonTextBox_24", "_lblCommon_13", "_txtCommonTextBox_30", "_lblCommon_14", "_txtCommonTextBox_31", "_lblCommon_15", "_txtCommonTextBox_32", "_lblCommon_16", "_txtCommonTextBox_33", "_lblCommon_17", "_txtCommonTextBox_34", "_lblCommon_18", "_txtCommonTextBox_35", "_lblCommon_19", "_txtCommonTextBox_36", "_lblCommon_20", "_txtCommonTextBox_37", "_lblCommon_21", "_txtCommonTextBox_38", "_lblCommon_22", "_txtCommonTextBox_39", "_lblCommon_24", "_txtCommonTextBox_40", "_lblCommon_25", "_txtCommonTextBox_41", "_lblCommon_26", "_txtCommonTextBox_42", "_lblCommon_47", "_lblCommon_48", "_lblCommon_36", "_txtCommonTextBox_44", "System.Windows.Forms.Label3", "_txtCommonTextBox_43", "Shape2", "Shape1", "_fraEmployeeInformation_4", "tabEmployee", "_lblCommon_6", "_txtCommonTextBox_8", "_txtCommonTextBox_7", "_txtCommonTextBox_5", "_txtCommonTextBox_4", "_txtCommonTextBox_3", "_txtCommonTextBox_2", "_lblCommon_7", "_lblCommon_9", "_lblCommon_10", "_lblCommon_4", "_txtCommonTextBox_1", "_lblCommon_50", "_lblCommon_51", "_lblCommon_53", "_lblCommon_113", "_txtCommonTextBox_0", "_txtDisplayLabel_14", "_txtDisplayLabel_16", "_lblCommon_63", "_lblCommon_64", "_txtCommonTextBox_6", "_lblCommon_8", "_lblCommon_52", "_txtCommonTextBox_64", "_lblCommon_65", "_txtCommonTextBox_66", "_lblCommon_66", "System.Windows.Forms.Label1", "fraEmployeeInformation", "lblCommon", "lblCommonLabel", "txtCommonNumber", "txtCommonTextBox", "txtDisplayLabel"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public System.Windows.Forms.Button cmdContract;
		public System.Windows.Forms.Button cmdTransfer;
		public System.Windows.Forms.Button cmdRenewal;
		public System.Windows.Forms.Button cmdVisaApplication;
		public System.Windows.Forms.Button cmdPullMasterData;
		private System.Windows.Forms.Label _lblCommon_0;
		private System.Windows.Forms.TextBox _txtCommonTextBox_16;
		private System.Windows.Forms.Label _lblCommon_30;
		private System.Windows.Forms.TextBox _txtCommonTextBox_17;
		private System.Windows.Forms.Label _lblCommon_38;
		private System.Windows.Forms.TextBox _txtCommonTextBox_19;
		private System.Windows.Forms.Label _lblCommon_39;
		private System.Windows.Forms.TextBox _txtCommonTextBox_21;
		private System.Windows.Forms.TextBox _txtCommonTextBox_20;
		private System.Windows.Forms.Label _lblCommon_43;
		private System.Windows.Forms.Label _lblCommon_23;
		private System.Windows.Forms.TextBox _txtCommonTextBox_22;
		private System.Windows.Forms.Label _lblCommonLabel_6;
		private System.Windows.Forms.Label _lblCommonLabel_17;
		public Syncfusion.WinForms.Input.SfDateTimeEdit txtPassExpiryDate;
		private System.Windows.Forms.Label _lblCommon_42;
		private System.Windows.Forms.TextBox _txtCommonTextBox_55;
		private System.Windows.Forms.Label _lblCommon_44;
		private System.Windows.Forms.TextBox _txtCommonTextBox_56;
		private System.Windows.Forms.Label _lblCommon_45;
		private System.Windows.Forms.TextBox _txtCommonTextBox_57;
		private System.Windows.Forms.Label _lblCommon_46;
		private System.Windows.Forms.TextBox _txtCommonTextBox_58;
		private System.Windows.Forms.Label _lblCommon_49;
		private System.Windows.Forms.TextBox _txtCommonTextBox_59;
		private System.Windows.Forms.Label _lblCommon_54;
		private System.Windows.Forms.TextBox _txtCommonTextBox_60;
		private System.Windows.Forms.Label _lblCommon_55;
		private System.Windows.Forms.TextBox _txtCommonTextBox_61;
		private System.Windows.Forms.Label _lblCommon_56;
		private System.Windows.Forms.TextBox _txtCommonTextBox_62;
		private System.Windows.Forms.Label _lblCommon_57;
		private System.Windows.Forms.Label _lblCommon_58;
		private System.Windows.Forms.Label _lblCommon_59;
		private System.Windows.Forms.TextBox _txtCommonTextBox_65;
		private System.Windows.Forms.TextBox _txtCommonNumber_1;
		private System.Windows.Forms.TextBox _txtCommonNumber_0;
		private System.Windows.Forms.Label _lblCommonLabel_0;
		public Syncfusion.WinForms.Input.SfDateTimeEdit txtDCivilIssueDate;
		private System.Windows.Forms.Label _lblCommonLabel_1;
		public Syncfusion.WinForms.Input.SfDateTimeEdit txtDCivilExpiryDate;
		private System.Windows.Forms.Label _lblCommon_61;
		private System.Windows.Forms.Label _lblCommonLabel_2;
		public System.Windows.Forms.TextBox txtTypeofPassport;
		public Syncfusion.WinForms.Input.SfDateTimeEdit txtPassIssueDate;
		public System.Windows.Forms.TextBox txtPassNat;
		private System.Windows.Forms.Label _lblCommonLabel_3;
		public System.Windows.Forms.TextBox txtPlaceofIssue;
		private System.Windows.Forms.Label _lblCommon_62;
		private System.Windows.Forms.TextBox _txtCommonTextBox_63;
		public System.Windows.Forms.Label lblDesignation;
		public System.Windows.Forms.Label lblsalary;
		public System.Windows.Forms.Panel Frame1;
		private System.Windows.Forms.Label _lblCommon_114;
		private System.Windows.Forms.Label _lblCommon_27;
		private System.Windows.Forms.TextBox _txtCommonTextBox_12;
		private System.Windows.Forms.Label _lblCommon_28;
		private System.Windows.Forms.TextBox _txtCommonTextBox_13;
		private System.Windows.Forms.Label _lblCommon_29;
		private System.Windows.Forms.TextBox _txtCommonTextBox_14;
		private System.Windows.Forms.Label _lblCommon_31;
		private System.Windows.Forms.TextBox _txtCommonTextBox_15;
		private System.Windows.Forms.Label _lblCommon_115;
		private System.Windows.Forms.TextBox _txtCommonTextBox_10;
		private System.Windows.Forms.TextBox _txtCommonTextBox_11;
		private System.Windows.Forms.Label _lblCommon_34;
		private System.Windows.Forms.TextBox _txtCommonTextBox_9;
		private System.Windows.Forms.TextBox _txtCommonTextBox_46;
		private System.Windows.Forms.Label _lblCommon_35;
		private System.Windows.Forms.TextBox _txtCommonTextBox_47;
		private System.Windows.Forms.Label _lblCommon_112;
		private System.Windows.Forms.Label _txtDisplayLabel_7;
		private System.Windows.Forms.Label _lblCommon_41;
		private System.Windows.Forms.TextBox _txtCommonTextBox_52;
		private System.Windows.Forms.Label _txtDisplayLabel_10;
		private System.Windows.Forms.Label _lblCommon_40;
		private System.Windows.Forms.TextBox _txtCommonTextBox_51;
		private System.Windows.Forms.Label _txtDisplayLabel_9;
		private System.Windows.Forms.Label _lblCommonLabel_18;
		private System.Windows.Forms.TextBox _txtCommonTextBox_48;
		private System.Windows.Forms.Label _txtDisplayLabel_1;
		private System.Windows.Forms.Label _lblCommon_103;
		private System.Windows.Forms.Label _System.Windows.Forms.Label1_1;
		private System.Windows.Forms.Label _System.Windows.Forms.Label1_2;
		private System.Windows.Forms.TextBox _txtCommonTextBox_49;
		private System.Windows.Forms.TextBox _txtCommonTextBox_50;
		private System.Windows.Forms.TextBox _txtCommonTextBox_53;
		private System.Windows.Forms.Label _lblCommon_32;
		private System.Windows.Forms.TextBox _txtCommonTextBox_18;
		private System.Windows.Forms.Label _lblCommon_33;
		private System.Windows.Forms.TextBox _txtCommonTextBox_23;
		private System.Windows.Forms.Label _lblCommon_108;
		public Syncfusion.WinForms.Input.SfDateTimeEdit txtBirthDate;
		private System.Windows.Forms.TextBox _txtCommonTextBox_54;
		private System.Windows.Forms.Label _lblCommon_37;
		private System.Windows.Forms.Label _lblCommon_60;
		public Syncfusion.WinForms.Input.SfDateTimeEdit txtDEntryDate;
		private System.Windows.Forms.Panel _fraEmployeeInformation_0;
		private System.Windows.Forms.TextBox _txtCommonTextBox_45;
		public System.Windows.Forms.Label System.Windows.Forms.Label2;
		private System.Windows.Forms.Label _lblCommon_1;
		private System.Windows.Forms.TextBox _txtCommonTextBox_29;
		private System.Windows.Forms.Label _lblCommon_2;
		private System.Windows.Forms.TextBox _txtCommonTextBox_28;
		private System.Windows.Forms.Label _lblCommon_3;
		private System.Windows.Forms.TextBox _txtCommonTextBox_27;
		private System.Windows.Forms.Label _lblCommon_5;
		private System.Windows.Forms.TextBox _txtCommonTextBox_26;
		private System.Windows.Forms.Label _lblCommon_11;
		private System.Windows.Forms.TextBox _txtCommonTextBox_25;
		private System.Windows.Forms.Label _lblCommon_12;
		private System.Windows.Forms.TextBox _txtCommonTextBox_24;
		private System.Windows.Forms.Label _lblCommon_13;
		private System.Windows.Forms.TextBox _txtCommonTextBox_30;
		private System.Windows.Forms.Label _lblCommon_14;
		private System.Windows.Forms.TextBox _txtCommonTextBox_31;
		private System.Windows.Forms.Label _lblCommon_15;
		private System.Windows.Forms.TextBox _txtCommonTextBox_32;
		private System.Windows.Forms.Label _lblCommon_16;
		private System.Windows.Forms.TextBox _txtCommonTextBox_33;
		private System.Windows.Forms.Label _lblCommon_17;
		private System.Windows.Forms.TextBox _txtCommonTextBox_34;
		private System.Windows.Forms.Label _lblCommon_18;
		private System.Windows.Forms.TextBox _txtCommonTextBox_35;
		private System.Windows.Forms.Label _lblCommon_19;
		private System.Windows.Forms.TextBox _txtCommonTextBox_36;
		private System.Windows.Forms.Label _lblCommon_20;
		private System.Windows.Forms.TextBox _txtCommonTextBox_37;
		private System.Windows.Forms.Label _lblCommon_21;
		private System.Windows.Forms.TextBox _txtCommonTextBox_38;
		private System.Windows.Forms.Label _lblCommon_22;
		private System.Windows.Forms.TextBox _txtCommonTextBox_39;
		private System.Windows.Forms.Label _lblCommon_24;
		private System.Windows.Forms.TextBox _txtCommonTextBox_40;
		private System.Windows.Forms.Label _lblCommon_25;
		private System.Windows.Forms.TextBox _txtCommonTextBox_41;
		private System.Windows.Forms.Label _lblCommon_26;
		private System.Windows.Forms.TextBox _txtCommonTextBox_42;
		private System.Windows.Forms.Label _lblCommon_47;
		private System.Windows.Forms.Label _lblCommon_48;
		private System.Windows.Forms.Label _lblCommon_36;
		private System.Windows.Forms.TextBox _txtCommonTextBox_44;
		public System.Windows.Forms.Label System.Windows.Forms.Label3;
		private System.Windows.Forms.TextBox _txtCommonTextBox_43;
		public UpgradeHelpers.Gui.ShapeHelper Shape2;
		public UpgradeHelpers.Gui.ShapeHelper Shape1;
		private System.Windows.Forms.Panel _fraEmployeeInformation_4;
		public AxC1SizerLib.AxC1Tab tabEmployee;
		private System.Windows.Forms.Label _lblCommon_6;
		private System.Windows.Forms.TextBox _txtCommonTextBox_8;
		private System.Windows.Forms.TextBox _txtCommonTextBox_7;
		private System.Windows.Forms.TextBox _txtCommonTextBox_5;
		private System.Windows.Forms.TextBox _txtCommonTextBox_4;
		private System.Windows.Forms.TextBox _txtCommonTextBox_3;
		private System.Windows.Forms.TextBox _txtCommonTextBox_2;
		private System.Windows.Forms.Label _lblCommon_7;
		private System.Windows.Forms.Label _lblCommon_9;
		private System.Windows.Forms.Label _lblCommon_10;
		private System.Windows.Forms.Label _lblCommon_4;
		private System.Windows.Forms.TextBox _txtCommonTextBox_1;
		private System.Windows.Forms.Label _lblCommon_50;
		private System.Windows.Forms.Label _lblCommon_51;
		private System.Windows.Forms.Label _lblCommon_53;
		private System.Windows.Forms.Label _lblCommon_113;
		private System.Windows.Forms.TextBox _txtCommonTextBox_0;
		private System.Windows.Forms.Label _txtDisplayLabel_14;
		private System.Windows.Forms.Label _txtDisplayLabel_16;
		private System.Windows.Forms.Label _lblCommon_63;
		private System.Windows.Forms.Label _lblCommon_64;
		private System.Windows.Forms.TextBox _txtCommonTextBox_6;
		private System.Windows.Forms.Label _lblCommon_8;
		private System.Windows.Forms.Label _lblCommon_52;
		private System.Windows.Forms.TextBox _txtCommonTextBox_64;
		private System.Windows.Forms.Label _lblCommon_65;
		private System.Windows.Forms.TextBox _txtCommonTextBox_66;
		private System.Windows.Forms.Label _lblCommon_66;
		public System.Windows.Forms.Label[] System.Windows.Forms.Label1 = new System.Windows.Forms.Label[3];
		public System.Windows.Forms.Panel[] fraEmployeeInformation = new System.Windows.Forms.Panel[5];
		public System.Windows.Forms.Label[] lblCommon = new System.Windows.Forms.Label[116];
		public System.Windows.Forms.Label[] lblCommonLabel = new System.Windows.Forms.Label[19];
		public System.Windows.Forms.TextBox[] txtCommonNumber = new System.Windows.Forms.TextBox[2];
		public System.Windows.Forms.TextBox[] txtCommonTextBox = new System.Windows.Forms.TextBox[67];
		public System.Windows.Forms.Label[] txtDisplayLabel = new System.Windows.Forms.Label[17];
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPayEmployeeWazaraDetails));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this.cmdContract = new System.Windows.Forms.Button();
			this.cmdTransfer = new System.Windows.Forms.Button();
			this.cmdRenewal = new System.Windows.Forms.Button();
			this.cmdVisaApplication = new System.Windows.Forms.Button();
			this.cmdPullMasterData = new System.Windows.Forms.Button();
			this.tabEmployee = new AxC1SizerLib.AxC1Tab();
			this.Frame1 = new System.Windows.Forms.Panel();
			this._lblCommon_0 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_16 = new System.Windows.Forms.TextBox();
			this._lblCommon_30 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_17 = new System.Windows.Forms.TextBox();
			this._lblCommon_38 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_19 = new System.Windows.Forms.TextBox();
			this._lblCommon_39 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_21 = new System.Windows.Forms.TextBox();
			this._txtCommonTextBox_20 = new System.Windows.Forms.TextBox();
			this._lblCommon_43 = new System.Windows.Forms.Label();
			this._lblCommon_23 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_22 = new System.Windows.Forms.TextBox();
			this._lblCommonLabel_6 = new System.Windows.Forms.Label();
			this._lblCommonLabel_17 = new System.Windows.Forms.Label();
			this.txtPassExpiryDate = new Syncfusion.WinForms.Input.SfDateTimeEdit();
			this._lblCommon_42 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_55 = new System.Windows.Forms.TextBox();
			this._lblCommon_44 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_56 = new System.Windows.Forms.TextBox();
			this._lblCommon_45 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_57 = new System.Windows.Forms.TextBox();
			this._lblCommon_46 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_58 = new System.Windows.Forms.TextBox();
			this._lblCommon_49 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_59 = new System.Windows.Forms.TextBox();
			this._lblCommon_54 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_60 = new System.Windows.Forms.TextBox();
			this._lblCommon_55 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_61 = new System.Windows.Forms.TextBox();
			this._lblCommon_56 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_62 = new System.Windows.Forms.TextBox();
			this._lblCommon_57 = new System.Windows.Forms.Label();
			this._lblCommon_58 = new System.Windows.Forms.Label();
			this._lblCommon_59 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_65 = new System.Windows.Forms.TextBox();
			this._txtCommonNumber_1 = new System.Windows.Forms.TextBox();
			this._txtCommonNumber_0 = new System.Windows.Forms.TextBox();
			this._lblCommonLabel_0 = new System.Windows.Forms.Label();
			this.txtDCivilIssueDate = new Syncfusion.WinForms.Input.SfDateTimeEdit();
			this._lblCommonLabel_1 = new System.Windows.Forms.Label();
			this.txtDCivilExpiryDate = new Syncfusion.WinForms.Input.SfDateTimeEdit();
			this._lblCommon_61 = new System.Windows.Forms.Label();
			this._lblCommonLabel_2 = new System.Windows.Forms.Label();
			this.txtTypeofPassport = new System.Windows.Forms.TextBox();
			this.txtPassIssueDate = new Syncfusion.WinForms.Input.SfDateTimeEdit();
			this.txtPassNat = new System.Windows.Forms.TextBox();
			this._lblCommonLabel_3 = new System.Windows.Forms.Label();
			this.txtPlaceofIssue = new System.Windows.Forms.TextBox();
			this._lblCommon_62 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_63 = new System.Windows.Forms.TextBox();
			this.lblDesignation = new System.Windows.Forms.Label();
			this.lblsalary = new System.Windows.Forms.Label();
			this._fraEmployeeInformation_0 = new System.Windows.Forms.Panel();
			this._lblCommon_114 = new System.Windows.Forms.Label();
			this._lblCommon_27 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_12 = new System.Windows.Forms.TextBox();
			this._lblCommon_28 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_13 = new System.Windows.Forms.TextBox();
			this._lblCommon_29 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_14 = new System.Windows.Forms.TextBox();
			this._lblCommon_31 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_15 = new System.Windows.Forms.TextBox();
			this._lblCommon_115 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_10 = new System.Windows.Forms.TextBox();
			this._txtCommonTextBox_11 = new System.Windows.Forms.TextBox();
			this._lblCommon_34 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_9 = new System.Windows.Forms.TextBox();
			this._txtCommonTextBox_46 = new System.Windows.Forms.TextBox();
			this._lblCommon_35 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_47 = new System.Windows.Forms.TextBox();
			this._lblCommon_112 = new System.Windows.Forms.Label();
			this._txtDisplayLabel_7 = new System.Windows.Forms.Label();
			this._lblCommon_41 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_52 = new System.Windows.Forms.TextBox();
			this._txtDisplayLabel_10 = new System.Windows.Forms.Label();
			this._lblCommon_40 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_51 = new System.Windows.Forms.TextBox();
			this._txtDisplayLabel_9 = new System.Windows.Forms.Label();
			this._lblCommonLabel_18 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_48 = new System.Windows.Forms.TextBox();
			this._txtDisplayLabel_1 = new System.Windows.Forms.Label();
			this._lblCommon_103 = new System.Windows.Forms.Label();
			this._System.Windows.Forms.Label1_1 = new System.Windows.Forms.Label();
			this._System.Windows.Forms.Label1_2 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_49 = new System.Windows.Forms.TextBox();
			this._txtCommonTextBox_50 = new System.Windows.Forms.TextBox();
			this._txtCommonTextBox_53 = new System.Windows.Forms.TextBox();
			this._lblCommon_32 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_18 = new System.Windows.Forms.TextBox();
			this._lblCommon_33 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_23 = new System.Windows.Forms.TextBox();
			this._lblCommon_108 = new System.Windows.Forms.Label();
			this.txtBirthDate = new Syncfusion.WinForms.Input.SfDateTimeEdit();
			this._txtCommonTextBox_54 = new System.Windows.Forms.TextBox();
			this._lblCommon_37 = new System.Windows.Forms.Label();
			this._lblCommon_60 = new System.Windows.Forms.Label();
			this.txtDEntryDate = new Syncfusion.WinForms.Input.SfDateTimeEdit();
			this._fraEmployeeInformation_4 = new System.Windows.Forms.Panel();
			this._txtCommonTextBox_45 = new System.Windows.Forms.TextBox();
			this.System.Windows.Forms.Label2 = new System.Windows.Forms.Label();
			this._lblCommon_1 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_29 = new System.Windows.Forms.TextBox();
			this._lblCommon_2 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_28 = new System.Windows.Forms.TextBox();
			this._lblCommon_3 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_27 = new System.Windows.Forms.TextBox();
			this._lblCommon_5 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_26 = new System.Windows.Forms.TextBox();
			this._lblCommon_11 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_25 = new System.Windows.Forms.TextBox();
			this._lblCommon_12 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_24 = new System.Windows.Forms.TextBox();
			this._lblCommon_13 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_30 = new System.Windows.Forms.TextBox();
			this._lblCommon_14 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_31 = new System.Windows.Forms.TextBox();
			this._lblCommon_15 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_32 = new System.Windows.Forms.TextBox();
			this._lblCommon_16 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_33 = new System.Windows.Forms.TextBox();
			this._lblCommon_17 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_34 = new System.Windows.Forms.TextBox();
			this._lblCommon_18 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_35 = new System.Windows.Forms.TextBox();
			this._lblCommon_19 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_36 = new System.Windows.Forms.TextBox();
			this._lblCommon_20 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_37 = new System.Windows.Forms.TextBox();
			this._lblCommon_21 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_38 = new System.Windows.Forms.TextBox();
			this._lblCommon_22 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_39 = new System.Windows.Forms.TextBox();
			this._lblCommon_24 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_40 = new System.Windows.Forms.TextBox();
			this._lblCommon_25 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_41 = new System.Windows.Forms.TextBox();
			this._lblCommon_26 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_42 = new System.Windows.Forms.TextBox();
			this._lblCommon_47 = new System.Windows.Forms.Label();
			this._lblCommon_48 = new System.Windows.Forms.Label();
			this._lblCommon_36 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_44 = new System.Windows.Forms.TextBox();
			this.System.Windows.Forms.Label3 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_43 = new System.Windows.Forms.TextBox();
			this.Shape2 = new UpgradeHelpers.Gui.ShapeHelper();
			this.Shape1 = new UpgradeHelpers.Gui.ShapeHelper();
			this._lblCommon_6 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_8 = new System.Windows.Forms.TextBox();
			this._txtCommonTextBox_7 = new System.Windows.Forms.TextBox();
			this._txtCommonTextBox_5 = new System.Windows.Forms.TextBox();
			this._txtCommonTextBox_4 = new System.Windows.Forms.TextBox();
			this._txtCommonTextBox_3 = new System.Windows.Forms.TextBox();
			this._txtCommonTextBox_2 = new System.Windows.Forms.TextBox();
			this._lblCommon_7 = new System.Windows.Forms.Label();
			this._lblCommon_9 = new System.Windows.Forms.Label();
			this._lblCommon_10 = new System.Windows.Forms.Label();
			this._lblCommon_4 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_1 = new System.Windows.Forms.TextBox();
			this._lblCommon_50 = new System.Windows.Forms.Label();
			this._lblCommon_51 = new System.Windows.Forms.Label();
			this._lblCommon_53 = new System.Windows.Forms.Label();
			this._lblCommon_113 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_0 = new System.Windows.Forms.TextBox();
			this._txtDisplayLabel_14 = new System.Windows.Forms.Label();
			this._txtDisplayLabel_16 = new System.Windows.Forms.Label();
			this._lblCommon_63 = new System.Windows.Forms.Label();
			this._lblCommon_64 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_6 = new System.Windows.Forms.TextBox();
			this._lblCommon_8 = new System.Windows.Forms.Label();
			this._lblCommon_52 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_64 = new System.Windows.Forms.TextBox();
			this._lblCommon_65 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_66 = new System.Windows.Forms.TextBox();
			this._lblCommon_66 = new System.Windows.Forms.Label();
			// //((System.ComponentModel.ISupportInitialize) this.tabEmployee).BeginInit();
			this.tabEmployee.SuspendLayout();
			this.Frame1.SuspendLayout();
			this._fraEmployeeInformation_0.SuspendLayout();
			this._fraEmployeeInformation_4.SuspendLayout();
			this.SuspendLayout();
			// 
			// cmdContract
			// 
			this.cmdContract.AllowDrop = true;
			this.cmdContract.BackColor = System.Drawing.SystemColors.Control;
			this.cmdContract.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdContract.Location = new System.Drawing.Point(749, 138);
			this.cmdContract.Name = "cmdContract";
			this.cmdContract.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdContract.Size = new System.Drawing.Size(106, 22);
			this.cmdContract.TabIndex = 160;
			this.cmdContract.Text = "Contract";
			this.cmdContract.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.cmdContract.UseVisualStyleBackColor = false;
			// this.cmdContract.Click += new System.EventHandler(this.cmdContract_Click);
			// 
			// cmdTransfer
			// 
			this.cmdTransfer.AllowDrop = true;
			this.cmdTransfer.BackColor = System.Drawing.SystemColors.Control;
			this.cmdTransfer.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdTransfer.Location = new System.Drawing.Point(749, 111);
			this.cmdTransfer.Name = "cmdTransfer";
			this.cmdTransfer.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdTransfer.Size = new System.Drawing.Size(106, 22);
			this.cmdTransfer.TabIndex = 159;
			this.cmdTransfer.Text = "Visa Transfer";
			this.cmdTransfer.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.cmdTransfer.UseVisualStyleBackColor = false;
			// this.cmdTransfer.Click += new System.EventHandler(this.cmdTransfer_Click);
			// 
			// cmdRenewal
			// 
			this.cmdRenewal.AllowDrop = true;
			this.cmdRenewal.BackColor = System.Drawing.SystemColors.Control;
			this.cmdRenewal.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdRenewal.Location = new System.Drawing.Point(749, 84);
			this.cmdRenewal.Name = "cmdRenewal";
			this.cmdRenewal.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdRenewal.Size = new System.Drawing.Size(106, 22);
			this.cmdRenewal.TabIndex = 158;
			this.cmdRenewal.Text = "Visa Renewal";
			this.cmdRenewal.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.cmdRenewal.UseVisualStyleBackColor = false;
			// this.cmdRenewal.Click += new System.EventHandler(this.cmdRenewal_Click);
			// 
			// cmdVisaApplication
			// 
			this.cmdVisaApplication.AllowDrop = true;
			this.cmdVisaApplication.BackColor = System.Drawing.SystemColors.Control;
			this.cmdVisaApplication.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdVisaApplication.Location = new System.Drawing.Point(750, 57);
			this.cmdVisaApplication.Name = "cmdVisaApplication";
			this.cmdVisaApplication.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdVisaApplication.Size = new System.Drawing.Size(106, 22);
			this.cmdVisaApplication.TabIndex = 157;
			this.cmdVisaApplication.Text = "Visa Application";
			this.cmdVisaApplication.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.cmdVisaApplication.UseVisualStyleBackColor = false;
			// this.cmdVisaApplication.Click += new System.EventHandler(this.cmdVisaApplication_Click);
			// 
			// cmdPullMasterData
			// 
			this.cmdPullMasterData.AllowDrop = true;
			this.cmdPullMasterData.BackColor = System.Drawing.SystemColors.Control;
			this.cmdPullMasterData.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdPullMasterData.Location = new System.Drawing.Point(284, 61);
			this.cmdPullMasterData.Name = "cmdPullMasterData";
			this.cmdPullMasterData.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdPullMasterData.Size = new System.Drawing.Size(153, 21);
			this.cmdPullMasterData.TabIndex = 49;
			this.cmdPullMasterData.Text = "Pull Master Data";
			this.cmdPullMasterData.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.cmdPullMasterData.UseVisualStyleBackColor = false;
			// this.cmdPullMasterData.Click += new System.EventHandler(this.cmdPullMasterData_Click);
			// 
			// tabEmployee
			// 
			this.tabEmployee.Align = C1SizerLib.AlignSettings.asNone;
			this.tabEmployee.AllowDrop = true;
			this.tabEmployee.Controls.Add(this.Frame1);
			this.tabEmployee.Controls.Add(this._fraEmployeeInformation_0);
			this.tabEmployee.Controls.Add(this._fraEmployeeInformation_4);
			this.tabEmployee.Location = new System.Drawing.Point(2, 205);
			this.tabEmployee.Name = "tabEmployee";
			("tabEmployee.OcxState");
			this.tabEmployee.Size = new System.Drawing.Size(854, 319);
			this.tabEmployee.TabIndex = 0;
			// 
			// Frame1
			// 
			this.Frame1.AllowDrop = true;
			this.Frame1.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this.Frame1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Frame1.Controls.Add(this._lblCommon_0);
			this.Frame1.Controls.Add(this._txtCommonTextBox_16);
			this.Frame1.Controls.Add(this._lblCommon_30);
			this.Frame1.Controls.Add(this._txtCommonTextBox_17);
			this.Frame1.Controls.Add(this._lblCommon_38);
			this.Frame1.Controls.Add(this._txtCommonTextBox_19);
			this.Frame1.Controls.Add(this._lblCommon_39);
			this.Frame1.Controls.Add(this._txtCommonTextBox_21);
			this.Frame1.Controls.Add(this._txtCommonTextBox_20);
			this.Frame1.Controls.Add(this._lblCommon_43);
			this.Frame1.Controls.Add(this._lblCommon_23);
			this.Frame1.Controls.Add(this._txtCommonTextBox_22);
			this.Frame1.Controls.Add(this._lblCommonLabel_6);
			this.Frame1.Controls.Add(this._lblCommonLabel_17);
			this.Frame1.Controls.Add(this.txtPassExpiryDate);
			this.Frame1.Controls.Add(this._lblCommon_42);
			this.Frame1.Controls.Add(this._txtCommonTextBox_55);
			this.Frame1.Controls.Add(this._lblCommon_44);
			this.Frame1.Controls.Add(this._txtCommonTextBox_56);
			this.Frame1.Controls.Add(this._lblCommon_45);
			this.Frame1.Controls.Add(this._txtCommonTextBox_57);
			this.Frame1.Controls.Add(this._lblCommon_46);
			this.Frame1.Controls.Add(this._txtCommonTextBox_58);
			this.Frame1.Controls.Add(this._lblCommon_49);
			this.Frame1.Controls.Add(this._txtCommonTextBox_59);
			this.Frame1.Controls.Add(this._lblCommon_54);
			this.Frame1.Controls.Add(this._txtCommonTextBox_60);
			this.Frame1.Controls.Add(this._lblCommon_55);
			this.Frame1.Controls.Add(this._txtCommonTextBox_61);
			this.Frame1.Controls.Add(this._lblCommon_56);
			this.Frame1.Controls.Add(this._txtCommonTextBox_62);
			this.Frame1.Controls.Add(this._lblCommon_57);
			this.Frame1.Controls.Add(this._lblCommon_58);
			this.Frame1.Controls.Add(this._lblCommon_59);
			this.Frame1.Controls.Add(this._txtCommonTextBox_65);
			this.Frame1.Controls.Add(this._txtCommonNumber_1);
			this.Frame1.Controls.Add(this._txtCommonNumber_0);
			this.Frame1.Controls.Add(this._lblCommonLabel_0);
			this.Frame1.Controls.Add(this.txtDCivilIssueDate);
			this.Frame1.Controls.Add(this._lblCommonLabel_1);
			this.Frame1.Controls.Add(this.txtDCivilExpiryDate);
			this.Frame1.Controls.Add(this._lblCommon_61);
			this.Frame1.Controls.Add(this._lblCommonLabel_2);
			this.Frame1.Controls.Add(this.txtTypeofPassport);
			this.Frame1.Controls.Add(this.txtPassIssueDate);
			this.Frame1.Controls.Add(this.txtPassNat);
			this.Frame1.Controls.Add(this._lblCommonLabel_3);
			this.Frame1.Controls.Add(this.txtPlaceofIssue);
			this.Frame1.Controls.Add(this._lblCommon_62);
			this.Frame1.Controls.Add(this._txtCommonTextBox_63);
			this.Frame1.Controls.Add(this.lblDesignation);
			this.Frame1.Controls.Add(this.lblsalary);
			this.Frame1.Enabled = true;
			this.Frame1.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Frame1.Location = new System.Drawing.Point(915, 23);
			this.Frame1.Name = "Frame1";
			this.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Frame1.Size = new System.Drawing.Size(852, 295);
			this.Frame1.TabIndex = 50;
			this.Frame1.Visible = true;
			// 
			// _lblCommon_0
			// 
			this._lblCommon_0.AllowDrop = true;
			this._lblCommon_0.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._lblCommon_0.Text = "Passport No.";
			this._lblCommon_0.Location = new System.Drawing.Point(12, 27);
			// this._lblCommon_0.mLabelId = 1550;
			this._lblCommon_0.Name = "_lblCommon_0";
			this._lblCommon_0.Size = new System.Drawing.Size(62, 13);
			this._lblCommon_0.TabIndex = 51;
			// 
			// _txtCommonTextBox_16
			// 
			this._txtCommonTextBox_16.AllowDrop = true;
			this._txtCommonTextBox_16.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_16.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_16.Location = new System.Drawing.Point(122, 24);
			this._txtCommonTextBox_16.MaxLength = 20;
			this._txtCommonTextBox_16.Name = "_txtCommonTextBox_16";
			this._txtCommonTextBox_16.Size = new System.Drawing.Size(186, 19);
			this._txtCommonTextBox_16.TabIndex = 52;
			this._txtCommonTextBox_16.Text = "";
			// this.this._txtCommonTextBox_16.Watermark = "";
			// this.this._txtCommonTextBox_16.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_16.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _lblCommon_30
			// 
			this._lblCommon_30.AllowDrop = true;
			this._lblCommon_30.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._lblCommon_30.Text = "Civil Id";
			this._lblCommon_30.Location = new System.Drawing.Point(12, 69);
			// this._lblCommon_30.mLabelId = 1930;
			this._lblCommon_30.Name = "_lblCommon_30";
			this._lblCommon_30.Size = new System.Drawing.Size(32, 13);
			this._lblCommon_30.TabIndex = 61;
			// 
			// _txtCommonTextBox_17
			// 
			this._txtCommonTextBox_17.AllowDrop = true;
			this._txtCommonTextBox_17.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_17.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_17.Location = new System.Drawing.Point(122, 66);
			this._txtCommonTextBox_17.MaxLength = 20;
			this._txtCommonTextBox_17.Name = "_txtCommonTextBox_17";
			this._txtCommonTextBox_17.Size = new System.Drawing.Size(186, 19);
			this._txtCommonTextBox_17.TabIndex = 58;
			this._txtCommonTextBox_17.Text = "";
			// this.this._txtCommonTextBox_17.Watermark = "";
			// this.this._txtCommonTextBox_17.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_17.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _lblCommon_38
			// 
			this._lblCommon_38.AllowDrop = true;
			this._lblCommon_38.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._lblCommon_38.Text = "Work Permit No.";
			this._lblCommon_38.Location = new System.Drawing.Point(12, 90);
			// this._lblCommon_38.mLabelId = 1966;
			this._lblCommon_38.Name = "_lblCommon_38";
			this._lblCommon_38.Size = new System.Drawing.Size(78, 13);
			this._lblCommon_38.TabIndex = 77;
			// 
			// _txtCommonTextBox_19
			// 
			this._txtCommonTextBox_19.AllowDrop = true;
			this._txtCommonTextBox_19.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_19.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_19.Location = new System.Drawing.Point(122, 87);
			this._txtCommonTextBox_19.MaxLength = 20;
			this._txtCommonTextBox_19.Name = "_txtCommonTextBox_19";
			this._txtCommonTextBox_19.Size = new System.Drawing.Size(186, 19);
			this._txtCommonTextBox_19.TabIndex = 62;
			this._txtCommonTextBox_19.Text = "";
			// this.this._txtCommonTextBox_19.Watermark = "";
			// this.this._txtCommonTextBox_19.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_19.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _lblCommon_39
			// 
			this._lblCommon_39.AllowDrop = true;
			this._lblCommon_39.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._lblCommon_39.Text = "Visa No.";
			this._lblCommon_39.Location = new System.Drawing.Point(12, 114);
			// this._lblCommon_39.mLabelId = 1968;
			this._lblCommon_39.Name = "_lblCommon_39";
			this._lblCommon_39.Size = new System.Drawing.Size(39, 13);
			this._lblCommon_39.TabIndex = 78;
			// 
			// _txtCommonTextBox_21
			// 
			this._txtCommonTextBox_21.AllowDrop = true;
			this._txtCommonTextBox_21.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_21.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_21.Location = new System.Drawing.Point(122, 111);
			this._txtCommonTextBox_21.MaxLength = 20;
			this._txtCommonTextBox_21.Name = "_txtCommonTextBox_21";
			this._txtCommonTextBox_21.Size = new System.Drawing.Size(186, 19);
			this._txtCommonTextBox_21.TabIndex = 63;
			this._txtCommonTextBox_21.Text = "";
			// this.this._txtCommonTextBox_21.Watermark = "";
			// this.this._txtCommonTextBox_21.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_21.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _txtCommonTextBox_20
			// 
			this._txtCommonTextBox_20.AllowDrop = true;
			this._txtCommonTextBox_20.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_20.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_20.Location = new System.Drawing.Point(123, 261);
			this._txtCommonTextBox_20.MaxLength = 100;
			this._txtCommonTextBox_20.Name = "_txtCommonTextBox_20";
			this._txtCommonTextBox_20.Size = new System.Drawing.Size(706, 19);
			this._txtCommonTextBox_20.TabIndex = 76;
			this._txtCommonTextBox_20.Text = "";
			// this.this._txtCommonTextBox_20.Watermark = "";
			// this.this._txtCommonTextBox_20.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_20.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _lblCommon_43
			// 
			this._lblCommon_43.AllowDrop = true;
			this._lblCommon_43.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._lblCommon_43.Text = "Comments";
			this._lblCommon_43.Location = new System.Drawing.Point(12, 264);
			// this._lblCommon_43.mLabelId = 135;
			this._lblCommon_43.Name = "_lblCommon_43";
			this._lblCommon_43.Size = new System.Drawing.Size(50, 13);
			this._lblCommon_43.TabIndex = 79;
			// 
			// _lblCommon_23
			// 
			this._lblCommon_23.AllowDrop = true;
			this._lblCommon_23.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._lblCommon_23.Text = "Residance No";
			this._lblCommon_23.Location = new System.Drawing.Point(314, 114);
			// this._lblCommon_23.mLabelId = 2161;
			this._lblCommon_23.Name = "_lblCommon_23";
			this._lblCommon_23.Size = new System.Drawing.Size(65, 13);
			this._lblCommon_23.TabIndex = 80;
			// 
			// _txtCommonTextBox_22
			// 
			this._txtCommonTextBox_22.AllowDrop = true;
			this._txtCommonTextBox_22.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_22.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_22.Location = new System.Drawing.Point(413, 111);
			this._txtCommonTextBox_22.MaxLength = 20;
			this._txtCommonTextBox_22.Name = "_txtCommonTextBox_22";
			this._txtCommonTextBox_22.Size = new System.Drawing.Size(186, 19);
			this._txtCommonTextBox_22.TabIndex = 64;
			this._txtCommonTextBox_22.Text = "";
			// this.this._txtCommonTextBox_22.Watermark = "";
			// this.this._txtCommonTextBox_22.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_22.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _lblCommonLabel_6
			// 
			this._lblCommonLabel_6.AllowDrop = true;
			this._lblCommonLabel_6.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._lblCommonLabel_6.Text = "Issue Date";
			this._lblCommonLabel_6.Location = new System.Drawing.Point(314, 27);
			// this._lblCommonLabel_6.mLabelId = 1798;
			this._lblCommonLabel_6.Name = "_lblCommonLabel_6";
			this._lblCommonLabel_6.Size = new System.Drawing.Size(51, 14);
			this._lblCommonLabel_6.TabIndex = 143;
			// 
			// _lblCommonLabel_17
			// 
			this._lblCommonLabel_17.AllowDrop = true;
			this._lblCommonLabel_17.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._lblCommonLabel_17.Text = "Expire Date";
			this._lblCommonLabel_17.Location = new System.Drawing.Point(606, 24);
			// this._lblCommonLabel_17.mLabelId = 1795;
			this._lblCommonLabel_17.Name = "_lblCommonLabel_17";
			this._lblCommonLabel_17.Size = new System.Drawing.Size(55, 14);
			this._lblCommonLabel_17.TabIndex = 144;
			// 
			// txtPassExpiryDate
			// 
			this.txtPassExpiryDate.AllowDrop = true;
			// this.txtPassExpiryDate.CheckDateRange = false;
			this.txtPassExpiryDate.Location = new System.Drawing.Point(679, 24);
			// this.txtPassExpiryDate.MaxDate = 2958465;
			// this.txtPassExpiryDate.MinDate = 32874;
			this.txtPassExpiryDate.Name = "txtPassExpiryDate";
			this.txtPassExpiryDate.Size = new System.Drawing.Size(148, 19);
			this.txtPassExpiryDate.TabIndex = 54;
			this.txtPassExpiryDate.Text = "18/Jul/2001";
			this.txtPassExpiryDate.Value = 37090;
			// 
			// _lblCommon_42
			// 
			this._lblCommon_42.AllowDrop = true;
			this._lblCommon_42.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._lblCommon_42.Text = "New File No";
			this._lblCommon_42.Location = new System.Drawing.Point(12, 134);
			// this._lblCommon_42.mLabelId = 2162;
			this._lblCommon_42.Name = "_lblCommon_42";
			this._lblCommon_42.Size = new System.Drawing.Size(56, 13);
			this._lblCommon_42.TabIndex = 146;
			// 
			// _txtCommonTextBox_55
			// 
			this._txtCommonTextBox_55.AllowDrop = true;
			this._txtCommonTextBox_55.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_55.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_55.Location = new System.Drawing.Point(122, 133);
			this._txtCommonTextBox_55.MaxLength = 20;
			this._txtCommonTextBox_55.Name = "_txtCommonTextBox_55";
			this._txtCommonTextBox_55.Size = new System.Drawing.Size(186, 19);
			this._txtCommonTextBox_55.TabIndex = 65;
			this._txtCommonTextBox_55.Text = "";
			// this.this._txtCommonTextBox_55.Watermark = "";
			// this.this._txtCommonTextBox_55.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_55.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _lblCommon_44
			// 
			this._lblCommon_44.AllowDrop = true;
			this._lblCommon_44.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._lblCommon_44.Text = "New Contract No";
			this._lblCommon_44.Location = new System.Drawing.Point(12, 155);
			// this._lblCommon_44.mLabelId = 2164;
			this._lblCommon_44.Name = "_lblCommon_44";
			this._lblCommon_44.Size = new System.Drawing.Size(82, 13);
			this._lblCommon_44.TabIndex = 147;
			// 
			// _txtCommonTextBox_56
			// 
			this._txtCommonTextBox_56.AllowDrop = true;
			this._txtCommonTextBox_56.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_56.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_56.Location = new System.Drawing.Point(122, 154);
			this._txtCommonTextBox_56.MaxLength = 20;
			this._txtCommonTextBox_56.Name = "_txtCommonTextBox_56";
			this._txtCommonTextBox_56.Size = new System.Drawing.Size(186, 19);
			this._txtCommonTextBox_56.TabIndex = 67;
			this._txtCommonTextBox_56.Text = "";
			// this.this._txtCommonTextBox_56.Watermark = "";
			// this.this._txtCommonTextBox_56.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_56.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _lblCommon_45
			// 
			this._lblCommon_45.AllowDrop = true;
			this._lblCommon_45.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._lblCommon_45.Text = "New License No";
			this._lblCommon_45.Location = new System.Drawing.Point(12, 176);
			// this._lblCommon_45.mLabelId = 2166;
			this._lblCommon_45.Name = "_lblCommon_45";
			this._lblCommon_45.Size = new System.Drawing.Size(75, 13);
			this._lblCommon_45.TabIndex = 148;
			// 
			// _txtCommonTextBox_57
			// 
			this._txtCommonTextBox_57.AllowDrop = true;
			this._txtCommonTextBox_57.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_57.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_57.Location = new System.Drawing.Point(122, 175);
			this._txtCommonTextBox_57.MaxLength = 20;
			this._txtCommonTextBox_57.Name = "_txtCommonTextBox_57";
			this._txtCommonTextBox_57.Size = new System.Drawing.Size(186, 19);
			this._txtCommonTextBox_57.TabIndex = 69;
			this._txtCommonTextBox_57.Text = "";
			// this.this._txtCommonTextBox_57.Watermark = "";
			// this.this._txtCommonTextBox_57.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_57.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _lblCommon_46
			// 
			this._lblCommon_46.AllowDrop = true;
			this._lblCommon_46.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._lblCommon_46.Text = "Old File No";
			this._lblCommon_46.Location = new System.Drawing.Point(314, 136);
			// this._lblCommon_46.mLabelId = 2163;
			this._lblCommon_46.Name = "_lblCommon_46";
			this._lblCommon_46.Size = new System.Drawing.Size(51, 13);
			this._lblCommon_46.TabIndex = 149;
			// 
			// _txtCommonTextBox_58
			// 
			this._txtCommonTextBox_58.AllowDrop = true;
			this._txtCommonTextBox_58.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_58.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_58.Location = new System.Drawing.Point(413, 133);
			this._txtCommonTextBox_58.MaxLength = 20;
			this._txtCommonTextBox_58.Name = "_txtCommonTextBox_58";
			this._txtCommonTextBox_58.Size = new System.Drawing.Size(186, 19);
			this._txtCommonTextBox_58.TabIndex = 66;
			this._txtCommonTextBox_58.Text = "";
			// this.this._txtCommonTextBox_58.Watermark = "";
			// this.this._txtCommonTextBox_58.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_58.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _lblCommon_49
			// 
			this._lblCommon_49.AllowDrop = true;
			this._lblCommon_49.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._lblCommon_49.Text = "Old Contract No";
			this._lblCommon_49.Location = new System.Drawing.Point(314, 157);
			// this._lblCommon_49.mLabelId = 2165;
			this._lblCommon_49.Name = "_lblCommon_49";
			this._lblCommon_49.Size = new System.Drawing.Size(77, 13);
			this._lblCommon_49.TabIndex = 150;
			// 
			// _txtCommonTextBox_59
			// 
			this._txtCommonTextBox_59.AllowDrop = true;
			this._txtCommonTextBox_59.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_59.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_59.Location = new System.Drawing.Point(413, 154);
			this._txtCommonTextBox_59.MaxLength = 20;
			this._txtCommonTextBox_59.Name = "_txtCommonTextBox_59";
			this._txtCommonTextBox_59.Size = new System.Drawing.Size(186, 19);
			this._txtCommonTextBox_59.TabIndex = 68;
			this._txtCommonTextBox_59.Text = "";
			// this.this._txtCommonTextBox_59.Watermark = "";
			// this.this._txtCommonTextBox_59.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_59.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _lblCommon_54
			// 
			this._lblCommon_54.AllowDrop = true;
			this._lblCommon_54.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._lblCommon_54.Text = "Old License No";
			this._lblCommon_54.Location = new System.Drawing.Point(314, 178);
			// this._lblCommon_54.mLabelId = 2167;
			this._lblCommon_54.Name = "_lblCommon_54";
			this._lblCommon_54.Size = new System.Drawing.Size(70, 13);
			this._lblCommon_54.TabIndex = 151;
			// 
			// _txtCommonTextBox_60
			// 
			this._txtCommonTextBox_60.AllowDrop = true;
			this._txtCommonTextBox_60.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_60.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_60.Location = new System.Drawing.Point(413, 175);
			this._txtCommonTextBox_60.MaxLength = 20;
			this._txtCommonTextBox_60.Name = "_txtCommonTextBox_60";
			this._txtCommonTextBox_60.Size = new System.Drawing.Size(186, 19);
			this._txtCommonTextBox_60.TabIndex = 70;
			this._txtCommonTextBox_60.Text = "";
			// this.this._txtCommonTextBox_60.Watermark = "";
			// this.this._txtCommonTextBox_60.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_60.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _lblCommon_55
			// 
			this._lblCommon_55.AllowDrop = true;
			this._lblCommon_55.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._lblCommon_55.Text = "New Contract Period";
			this._lblCommon_55.Location = new System.Drawing.Point(12, 197);
			// this._lblCommon_55.mLabelId = 2168;
			this._lblCommon_55.Name = "_lblCommon_55";
			this._lblCommon_55.Size = new System.Drawing.Size(99, 13);
			this._lblCommon_55.TabIndex = 152;
			// 
			// _txtCommonTextBox_61
			// 
			this._txtCommonTextBox_61.AllowDrop = true;
			this._txtCommonTextBox_61.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_61.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_61.Location = new System.Drawing.Point(123, 196);
			this._txtCommonTextBox_61.MaxLength = 20;
			this._txtCommonTextBox_61.Name = "_txtCommonTextBox_61";
			this._txtCommonTextBox_61.Size = new System.Drawing.Size(185, 19);
			this._txtCommonTextBox_61.TabIndex = 71;
			this._txtCommonTextBox_61.Text = "";
			// this.this._txtCommonTextBox_61.Watermark = "";
			// this.this._txtCommonTextBox_61.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_61.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _lblCommon_56
			// 
			this._lblCommon_56.AllowDrop = true;
			this._lblCommon_56.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._lblCommon_56.Text = "Old Contract Period";
			this._lblCommon_56.Location = new System.Drawing.Point(314, 199);
			// this._lblCommon_56.mLabelId = 2169;
			this._lblCommon_56.Name = "_lblCommon_56";
			this._lblCommon_56.Size = new System.Drawing.Size(94, 13);
			this._lblCommon_56.TabIndex = 153;
			// 
			// _txtCommonTextBox_62
			// 
			this._txtCommonTextBox_62.AllowDrop = true;
			this._txtCommonTextBox_62.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_62.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_62.Location = new System.Drawing.Point(413, 196);
			this._txtCommonTextBox_62.MaxLength = 20;
			this._txtCommonTextBox_62.Name = "_txtCommonTextBox_62";
			this._txtCommonTextBox_62.Size = new System.Drawing.Size(186, 19);
			this._txtCommonTextBox_62.TabIndex = 72;
			this._txtCommonTextBox_62.Text = "";
			// this.this._txtCommonTextBox_62.Watermark = "";
			// this.this._txtCommonTextBox_62.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_62.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _lblCommon_57
			// 
			this._lblCommon_57.AllowDrop = true;
			this._lblCommon_57.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._lblCommon_57.Text = "New Contract Salary";
			this._lblCommon_57.Location = new System.Drawing.Point(12, 218);
			// this._lblCommon_57.mLabelId = 2170;
			this._lblCommon_57.Name = "_lblCommon_57";
			this._lblCommon_57.Size = new System.Drawing.Size(99, 13);
			this._lblCommon_57.TabIndex = 154;
			// 
			// _lblCommon_58
			// 
			this._lblCommon_58.AllowDrop = true;
			this._lblCommon_58.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._lblCommon_58.Text = "Old Contract Salary";
			this._lblCommon_58.Location = new System.Drawing.Point(314, 220);
			// this._lblCommon_58.mLabelId = 2171;
			this._lblCommon_58.Name = "_lblCommon_58";
			this._lblCommon_58.Size = new System.Drawing.Size(94, 13);
			this._lblCommon_58.TabIndex = 155;
			// 
			// _lblCommon_59
			// 
			this._lblCommon_59.AllowDrop = true;
			this._lblCommon_59.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._lblCommon_59.Text = "New Profession";
			this._lblCommon_59.Location = new System.Drawing.Point(12, 242);
			// this._lblCommon_59.mLabelId = 2172;
			this._lblCommon_59.Name = "_lblCommon_59";
			this._lblCommon_59.Size = new System.Drawing.Size(74, 13);
			this._lblCommon_59.TabIndex = 156;
			// 
			// _txtCommonTextBox_65
			// 
			this._txtCommonTextBox_65.AllowDrop = true;
			this._txtCommonTextBox_65.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_65.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_65.Location = new System.Drawing.Point(123, 239);
			this._txtCommonTextBox_65.MaxLength = 20;
			this._txtCommonTextBox_65.Name = "_txtCommonTextBox_65";
			// this._txtCommonTextBox_65.ShowButton = true;
			this._txtCommonTextBox_65.Size = new System.Drawing.Size(185, 19);
			this._txtCommonTextBox_65.TabIndex = 75;
			this._txtCommonTextBox_65.Text = "";
			// this.this._txtCommonTextBox_65.Watermark = "";
			// this.this._txtCommonTextBox_65.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_65.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _txtCommonNumber_1
			// 
			this._txtCommonNumber_1.AllowDrop = true;
			// this._txtCommonNumber_1.DisplayFormat = "####0.000###;;0.000;0.000";
			// this._txtCommonNumber_1.Format = "###########0.000";
			this._txtCommonNumber_1.Location = new System.Drawing.Point(123, 217);
			// this._txtCommonNumber_1.MaxValue = 2147483647;
			// this._txtCommonNumber_1.MinValue = 0;
			this._txtCommonNumber_1.Name = "_txtCommonNumber_1";
			this._txtCommonNumber_1.Size = new System.Drawing.Size(185, 19);
			this._txtCommonNumber_1.TabIndex = 73;
			this._txtCommonNumber_1.Text = "0.000";
			// 
			// _txtCommonNumber_0
			// 
			this._txtCommonNumber_0.AllowDrop = true;
			// this._txtCommonNumber_0.DisplayFormat = "####0.000###;;0.000;0.000";
			// this._txtCommonNumber_0.Format = "###########0.000";
			this._txtCommonNumber_0.Location = new System.Drawing.Point(413, 217);
			// this._txtCommonNumber_0.MaxValue = 2147483647;
			// this._txtCommonNumber_0.MinValue = 0;
			this._txtCommonNumber_0.Name = "_txtCommonNumber_0";
			this._txtCommonNumber_0.Size = new System.Drawing.Size(186, 19);
			this._txtCommonNumber_0.TabIndex = 74;
			this._txtCommonNumber_0.Text = "0.000";
			// 
			// _lblCommonLabel_0
			// 
			this._lblCommonLabel_0.AllowDrop = true;
			this._lblCommonLabel_0.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._lblCommonLabel_0.Text = "Issue Date";
			this._lblCommonLabel_0.Location = new System.Drawing.Point(314, 67);
			// this._lblCommonLabel_0.mLabelId = 1798;
			this._lblCommonLabel_0.Name = "_lblCommonLabel_0";
			this._lblCommonLabel_0.Size = new System.Drawing.Size(51, 14);
			this._lblCommonLabel_0.TabIndex = 162;
			// 
			// txtDCivilIssueDate
			// 
			this.txtDCivilIssueDate.AllowDrop = true;
			// this.txtDCivilIssueDate.CheckDateRange = false;
			this.txtDCivilIssueDate.Location = new System.Drawing.Point(416, 65);
			// this.txtDCivilIssueDate.MaxDate = 2958465;
			// this.txtDCivilIssueDate.MinDate = 32874;
			this.txtDCivilIssueDate.Name = "txtDCivilIssueDate";
			this.txtDCivilIssueDate.Size = new System.Drawing.Size(181, 19);
			this.txtDCivilIssueDate.TabIndex = 59;
			this.txtDCivilIssueDate.Text = "18/Jul/2001";
			this.txtDCivilIssueDate.Value = 37090;
			// 
			// _lblCommonLabel_1
			// 
			this._lblCommonLabel_1.AllowDrop = true;
			this._lblCommonLabel_1.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._lblCommonLabel_1.Text = "Expire Date";
			this._lblCommonLabel_1.Location = new System.Drawing.Point(605, 67);
			// this._lblCommonLabel_1.mLabelId = 1795;
			this._lblCommonLabel_1.Name = "_lblCommonLabel_1";
			this._lblCommonLabel_1.Size = new System.Drawing.Size(55, 14);
			this._lblCommonLabel_1.TabIndex = 163;
			// 
			// txtDCivilExpiryDate
			// 
			this.txtDCivilExpiryDate.AllowDrop = true;
			// this.txtDCivilExpiryDate.CheckDateRange = false;
			this.txtDCivilExpiryDate.Location = new System.Drawing.Point(679, 65);
			// this.txtDCivilExpiryDate.MaxDate = 2958465;
			// this.txtDCivilExpiryDate.MinDate = 32874;
			this.txtDCivilExpiryDate.Name = "txtDCivilExpiryDate";
			this.txtDCivilExpiryDate.Size = new System.Drawing.Size(148, 19);
			this.txtDCivilExpiryDate.TabIndex = 60;
			this.txtDCivilExpiryDate.Text = "18/Jul/2001";
			this.txtDCivilExpiryDate.Value = 37090;
			// 
			// _lblCommon_61
			// 
			this._lblCommon_61.AllowDrop = true;
			this._lblCommon_61.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._lblCommon_61.Text = "Type Of Passport";
			this._lblCommon_61.Location = new System.Drawing.Point(12, 47);
			// this._lblCommon_61.mLabelId = 2198;
			this._lblCommon_61.Name = "_lblCommon_61";
			this._lblCommon_61.Size = new System.Drawing.Size(84, 13);
			this._lblCommon_61.TabIndex = 164;
			// 
			// _lblCommonLabel_2
			// 
			this._lblCommonLabel_2.AllowDrop = true;
			this._lblCommonLabel_2.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._lblCommonLabel_2.Text = "Passport Nationality";
			this._lblCommonLabel_2.Location = new System.Drawing.Point(314, 47);
			// this._lblCommonLabel_2.mLabelId = 2199;
			this._lblCommonLabel_2.Name = "_lblCommonLabel_2";
			this._lblCommonLabel_2.Size = new System.Drawing.Size(95, 14);
			this._lblCommonLabel_2.TabIndex = 165;
			// 
			// txtTypeofPassport
			// 
			this.txtTypeofPassport.AllowDrop = true;
			this.txtTypeofPassport.BackColor = System.Drawing.Color.White;
			// this.txtTypeofPassport.bolAllowDecimal = false;
			this.txtTypeofPassport.ForeColor = System.Drawing.Color.Black;
			this.txtTypeofPassport.Location = new System.Drawing.Point(122, 45);
			// this.txtTypeofPassport.mDropDownType = (System.Windows.Forms.TextBox.DropDownTypes) 0;
			this.txtTypeofPassport.Name = "txtTypeofPassport";
			this.txtTypeofPassport.Size = new System.Drawing.Size(186, 19);
			this.txtTypeofPassport.TabIndex = 55;
			this.txtTypeofPassport.Text = "";
			// this.this.txtTypeofPassport.Watermark = "";
			// 
			// txtPassIssueDate
			// 
			this.txtPassIssueDate.AllowDrop = true;
			// this.txtPassIssueDate.CheckDateRange = false;
			this.txtPassIssueDate.Location = new System.Drawing.Point(416, 24);
			// this.txtPassIssueDate.MaxDate = 2958465;
			// this.txtPassIssueDate.MinDate = 32874;
			this.txtPassIssueDate.Name = "txtPassIssueDate";
			this.txtPassIssueDate.Size = new System.Drawing.Size(181, 19);
			this.txtPassIssueDate.TabIndex = 53;
			this.txtPassIssueDate.Text = "18/Jul/2001";
			this.txtPassIssueDate.Value = 37090;
			// 
			// txtPassNat
			// 
			this.txtPassNat.AllowDrop = true;
			this.txtPassNat.BackColor = System.Drawing.Color.White;
			// this.txtPassNat.bolAllowDecimal = false;
			this.txtPassNat.ForeColor = System.Drawing.Color.Black;
			this.txtPassNat.Location = new System.Drawing.Point(416, 45);
			// this.txtPassNat.mDropDownType = (System.Windows.Forms.TextBox.DropDownTypes) 0;
			this.txtPassNat.Name = "txtPassNat";
			// this.txtPassNat.ShowButton = true;
			this.txtPassNat.Size = new System.Drawing.Size(181, 19);
			this.txtPassNat.TabIndex = 56;
			this.txtPassNat.Text = "";
			// this.this.txtPassNat.Watermark = "";
			// this.this.txtPassNat.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtPassNat_DropButtonClick);
			// 
			// _lblCommonLabel_3
			// 
			this._lblCommonLabel_3.AllowDrop = true;
			this._lblCommonLabel_3.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._lblCommonLabel_3.Text = "Place of Issue";
			this._lblCommonLabel_3.Location = new System.Drawing.Point(606, 47);
			// this._lblCommonLabel_3.mLabelId = 2200;
			this._lblCommonLabel_3.Name = "_lblCommonLabel_3";
			this._lblCommonLabel_3.Size = new System.Drawing.Size(68, 14);
			this._lblCommonLabel_3.TabIndex = 166;
			// 
			// txtPlaceofIssue
			// 
			this.txtPlaceofIssue.AllowDrop = true;
			this.txtPlaceofIssue.BackColor = System.Drawing.Color.White;
			// this.txtPlaceofIssue.bolAllowDecimal = false;
			this.txtPlaceofIssue.ForeColor = System.Drawing.Color.Black;
			this.txtPlaceofIssue.Location = new System.Drawing.Point(679, 45);
			// this.txtPlaceofIssue.mDropDownType = (System.Windows.Forms.TextBox.DropDownTypes) 0;
			this.txtPlaceofIssue.Name = "txtPlaceofIssue";
			this.txtPlaceofIssue.Size = new System.Drawing.Size(148, 19);
			this.txtPlaceofIssue.TabIndex = 57;
			this.txtPlaceofIssue.Text = "";
			// this.this.txtPlaceofIssue.Watermark = "";
			// 
			// _lblCommon_62
			// 
			this._lblCommon_62.AllowDrop = true;
			this._lblCommon_62.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._lblCommon_62.Text = "Old Profession";
			this._lblCommon_62.Location = new System.Drawing.Point(315, 243);
			// this._lblCommon_62.mLabelId = 2207;
			this._lblCommon_62.Name = "_lblCommon_62";
			this._lblCommon_62.Size = new System.Drawing.Size(69, 13);
			this._lblCommon_62.TabIndex = 167;
			// 
			// _txtCommonTextBox_63
			// 
			this._txtCommonTextBox_63.AllowDrop = true;
			this._txtCommonTextBox_63.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_63.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_63.Location = new System.Drawing.Point(413, 239);
			this._txtCommonTextBox_63.MaxLength = 20;
			this._txtCommonTextBox_63.Name = "_txtCommonTextBox_63";
			// this._txtCommonTextBox_63.ShowButton = true;
			this._txtCommonTextBox_63.Size = new System.Drawing.Size(186, 19);
			this._txtCommonTextBox_63.TabIndex = 168;
			this._txtCommonTextBox_63.Text = "";
			// this.this._txtCommonTextBox_63.Watermark = "";
			// this.this._txtCommonTextBox_63.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_63.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// lblDesignation
			// 
			this.lblDesignation.AllowDrop = true;
			this.lblDesignation.BackColor = System.Drawing.SystemColors.Control;
			this.lblDesignation.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lblDesignation.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblDesignation.Location = new System.Drawing.Point(606, 240);
			this.lblDesignation.Name = "lblDesignation";
			this.lblDesignation.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblDesignation.Size = new System.Drawing.Size(220, 19);
			this.lblDesignation.TabIndex = 178;
			// 
			// lblsalary
			// 
			this.lblsalary.AllowDrop = true;
			this.lblsalary.BackColor = System.Drawing.SystemColors.Control;
			this.lblsalary.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lblsalary.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblsalary.Location = new System.Drawing.Point(606, 216);
			this.lblsalary.Name = "lblsalary";
			this.lblsalary.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblsalary.Size = new System.Drawing.Size(220, 22);
			this.lblsalary.TabIndex = 177;
			// 
			// _fraEmployeeInformation_0
			// 
			this._fraEmployeeInformation_0.AllowDrop = true;
			this._fraEmployeeInformation_0.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._fraEmployeeInformation_0.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._fraEmployeeInformation_0.Controls.Add(this._lblCommon_114);
			this._fraEmployeeInformation_0.Controls.Add(this._lblCommon_27);
			this._fraEmployeeInformation_0.Controls.Add(this._txtCommonTextBox_12);
			this._fraEmployeeInformation_0.Controls.Add(this._lblCommon_28);
			this._fraEmployeeInformation_0.Controls.Add(this._txtCommonTextBox_13);
			this._fraEmployeeInformation_0.Controls.Add(this._lblCommon_29);
			this._fraEmployeeInformation_0.Controls.Add(this._txtCommonTextBox_14);
			this._fraEmployeeInformation_0.Controls.Add(this._lblCommon_31);
			this._fraEmployeeInformation_0.Controls.Add(this._txtCommonTextBox_15);
			this._fraEmployeeInformation_0.Controls.Add(this._lblCommon_115);
			this._fraEmployeeInformation_0.Controls.Add(this._txtCommonTextBox_10);
			this._fraEmployeeInformation_0.Controls.Add(this._txtCommonTextBox_11);
			this._fraEmployeeInformation_0.Controls.Add(this._lblCommon_34);
			this._fraEmployeeInformation_0.Controls.Add(this._txtCommonTextBox_9);
			this._fraEmployeeInformation_0.Controls.Add(this._txtCommonTextBox_46);
			this._fraEmployeeInformation_0.Controls.Add(this._lblCommon_35);
			this._fraEmployeeInformation_0.Controls.Add(this._txtCommonTextBox_47);
			this._fraEmployeeInformation_0.Controls.Add(this._lblCommon_112);
			this._fraEmployeeInformation_0.Controls.Add(this._txtDisplayLabel_7);
			this._fraEmployeeInformation_0.Controls.Add(this._lblCommon_41);
			this._fraEmployeeInformation_0.Controls.Add(this._txtCommonTextBox_52);
			this._fraEmployeeInformation_0.Controls.Add(this._txtDisplayLabel_10);
			this._fraEmployeeInformation_0.Controls.Add(this._lblCommon_40);
			this._fraEmployeeInformation_0.Controls.Add(this._txtCommonTextBox_51);
			this._fraEmployeeInformation_0.Controls.Add(this._txtDisplayLabel_9);
			this._fraEmployeeInformation_0.Controls.Add(this._lblCommonLabel_18);
			this._fraEmployeeInformation_0.Controls.Add(this._txtCommonTextBox_48);
			this._fraEmployeeInformation_0.Controls.Add(this._txtDisplayLabel_1);
			this._fraEmployeeInformation_0.Controls.Add(this._lblCommon_103);
			this._fraEmployeeInformation_0.Controls.Add(this._System.Windows.Forms.Label1_1);
			this._fraEmployeeInformation_0.Controls.Add(this._System.Windows.Forms.Label1_2);
			this._fraEmployeeInformation_0.Controls.Add(this._txtCommonTextBox_49);
			this._fraEmployeeInformation_0.Controls.Add(this._txtCommonTextBox_50);
			this._fraEmployeeInformation_0.Controls.Add(this._txtCommonTextBox_53);
			this._fraEmployeeInformation_0.Controls.Add(this._lblCommon_32);
			this._fraEmployeeInformation_0.Controls.Add(this._txtCommonTextBox_18);
			this._fraEmployeeInformation_0.Controls.Add(this._lblCommon_33);
			this._fraEmployeeInformation_0.Controls.Add(this._txtCommonTextBox_23);
			this._fraEmployeeInformation_0.Controls.Add(this._lblCommon_108);
			this._fraEmployeeInformation_0.Controls.Add(this.txtBirthDate);
			this._fraEmployeeInformation_0.Controls.Add(this._txtCommonTextBox_54);
			this._fraEmployeeInformation_0.Controls.Add(this._lblCommon_37);
			this._fraEmployeeInformation_0.Controls.Add(this._lblCommon_60);
			this._fraEmployeeInformation_0.Controls.Add(this.txtDEntryDate);
			this._fraEmployeeInformation_0.Enabled = true;
			this._fraEmployeeInformation_0.ForeColor = System.Drawing.SystemColors.WindowText;
			this._fraEmployeeInformation_0.Location = new System.Drawing.Point(1, 23);
			this._fraEmployeeInformation_0.Name = "_fraEmployeeInformation_0";
			this._fraEmployeeInformation_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._fraEmployeeInformation_0.Size = new System.Drawing.Size(852, 295);
			this._fraEmployeeInformation_0.TabIndex = 33;
			this._fraEmployeeInformation_0.Visible = true;
			// 
			// _lblCommon_114
			// 
			this._lblCommon_114.AllowDrop = true;
			this._lblCommon_114.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._lblCommon_114.Text = "Designation Name";
			this._lblCommon_114.Location = new System.Drawing.Point(10, 11);
			// this._lblCommon_114.mLabelId = 2154;
			this._lblCommon_114.Name = "_lblCommon_114";
			this._lblCommon_114.Size = new System.Drawing.Size(86, 14);
			this._lblCommon_114.TabIndex = 34;
			// 
			// _lblCommon_27
			// 
			this._lblCommon_27.AllowDrop = true;
			this._lblCommon_27.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._lblCommon_27.Text = "Father Name (English)";
			this._lblCommon_27.Location = new System.Drawing.Point(10, 52);
			// this._lblCommon_27.mLabelId = 1078;
			this._lblCommon_27.Name = "_lblCommon_27";
			this._lblCommon_27.Size = new System.Drawing.Size(106, 13);
			this._lblCommon_27.TabIndex = 35;
			// 
			// _txtCommonTextBox_12
			// 
			this._txtCommonTextBox_12.AllowDrop = true;
			this._txtCommonTextBox_12.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_12.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_12.Location = new System.Drawing.Point(122, 50);
			this._txtCommonTextBox_12.Name = "_txtCommonTextBox_12";
			this._txtCommonTextBox_12.Size = new System.Drawing.Size(261, 19);
			this._txtCommonTextBox_12.TabIndex = 14;
			this._txtCommonTextBox_12.Text = "";
			// this.this._txtCommonTextBox_12.Watermark = "";
			// this.this._txtCommonTextBox_12.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_12.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _lblCommon_28
			// 
			this._lblCommon_28.AllowDrop = true;
			this._lblCommon_28.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._lblCommon_28.Text = "Father Name (Arabic)";
			this._lblCommon_28.Location = new System.Drawing.Point(10, 74);
			// this._lblCommon_28.mLabelId = 1079;
			this._lblCommon_28.Name = "_lblCommon_28";
			this._lblCommon_28.Size = new System.Drawing.Size(103, 13);
			this._lblCommon_28.TabIndex = 36;
			// 
			// _txtCommonTextBox_13
			// 
			this._txtCommonTextBox_13.AllowDrop = true;
			this._txtCommonTextBox_13.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_13.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_13.Location = new System.Drawing.Point(122, 71);
			// this._txtCommonTextBox_13.mArabicEnabled = true;
			this._txtCommonTextBox_13.Name = "_txtCommonTextBox_13";
			this._txtCommonTextBox_13.Size = new System.Drawing.Size(261, 19);
			this._txtCommonTextBox_13.TabIndex = 15;
			this._txtCommonTextBox_13.Text = "";
			// this.this._txtCommonTextBox_13.Watermark = "";
			// this.this._txtCommonTextBox_13.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_13.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _lblCommon_29
			// 
			this._lblCommon_29.AllowDrop = true;
			this._lblCommon_29.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._lblCommon_29.Text = "Mother Name (English)";
			this._lblCommon_29.Location = new System.Drawing.Point(10, 95);
			// this._lblCommon_29.mLabelId = 1080;
			this._lblCommon_29.Name = "_lblCommon_29";
			this._lblCommon_29.Size = new System.Drawing.Size(108, 13);
			this._lblCommon_29.TabIndex = 37;
			// 
			// _txtCommonTextBox_14
			// 
			this._txtCommonTextBox_14.AllowDrop = true;
			this._txtCommonTextBox_14.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_14.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_14.Location = new System.Drawing.Point(122, 92);
			this._txtCommonTextBox_14.Name = "_txtCommonTextBox_14";
			this._txtCommonTextBox_14.Size = new System.Drawing.Size(261, 19);
			this._txtCommonTextBox_14.TabIndex = 16;
			this._txtCommonTextBox_14.Text = "";
			// this.this._txtCommonTextBox_14.Watermark = "";
			// this.this._txtCommonTextBox_14.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_14.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _lblCommon_31
			// 
			this._lblCommon_31.AllowDrop = true;
			this._lblCommon_31.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._lblCommon_31.Text = "Mother Name (Arabic)";
			this._lblCommon_31.Location = new System.Drawing.Point(10, 116);
			// this._lblCommon_31.mLabelId = 1081;
			this._lblCommon_31.Name = "_lblCommon_31";
			this._lblCommon_31.Size = new System.Drawing.Size(105, 13);
			this._lblCommon_31.TabIndex = 38;
			// 
			// _txtCommonTextBox_15
			// 
			this._txtCommonTextBox_15.AllowDrop = true;
			this._txtCommonTextBox_15.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_15.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_15.Location = new System.Drawing.Point(122, 113);
			// this._txtCommonTextBox_15.mArabicEnabled = true;
			this._txtCommonTextBox_15.Name = "_txtCommonTextBox_15";
			this._txtCommonTextBox_15.Size = new System.Drawing.Size(261, 19);
			this._txtCommonTextBox_15.TabIndex = 17;
			this._txtCommonTextBox_15.Text = "";
			// this.this._txtCommonTextBox_15.Watermark = "";
			// this.this._txtCommonTextBox_15.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_15.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _lblCommon_115
			// 
			this._lblCommon_115.AllowDrop = true;
			this._lblCommon_115.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._lblCommon_115.Text = "Qualification";
			this._lblCommon_115.Location = new System.Drawing.Point(10, 31);
			// this._lblCommon_115.mLabelId = 600;
			this._lblCommon_115.Name = "_lblCommon_115";
			this._lblCommon_115.Size = new System.Drawing.Size(59, 14);
			this._lblCommon_115.TabIndex = 47;
			// 
			// _txtCommonTextBox_10
			// 
			this._txtCommonTextBox_10.AllowDrop = true;
			this._txtCommonTextBox_10.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_10.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_10.Location = new System.Drawing.Point(122, 8);
			this._txtCommonTextBox_10.Name = "_txtCommonTextBox_10";
			// this._txtCommonTextBox_10.ShowButton = true;
			this._txtCommonTextBox_10.Size = new System.Drawing.Size(261, 19);
			this._txtCommonTextBox_10.TabIndex = 12;
			this._txtCommonTextBox_10.Text = "";
			// this.this._txtCommonTextBox_10.Watermark = "";
			// this.this._txtCommonTextBox_10.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_10.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _txtCommonTextBox_11
			// 
			this._txtCommonTextBox_11.AllowDrop = true;
			this._txtCommonTextBox_11.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_11.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_11.Location = new System.Drawing.Point(122, 30);
			this._txtCommonTextBox_11.Name = "_txtCommonTextBox_11";
			// this._txtCommonTextBox_11.ShowButton = true;
			this._txtCommonTextBox_11.Size = new System.Drawing.Size(261, 19);
			this._txtCommonTextBox_11.TabIndex = 13;
			this._txtCommonTextBox_11.Text = "";
			// this.this._txtCommonTextBox_11.Watermark = "";
			// this.this._txtCommonTextBox_11.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_11.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _lblCommon_34
			// 
			this._lblCommon_34.AllowDrop = true;
			this._lblCommon_34.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._lblCommon_34.Text = "Previous Sponsor";
			this._lblCommon_34.Location = new System.Drawing.Point(10, 138);
			// this._lblCommon_34.mLabelId = 2194;
			this._lblCommon_34.Name = "_lblCommon_34";
			this._lblCommon_34.Size = new System.Drawing.Size(83, 13);
			this._lblCommon_34.TabIndex = 127;
			// 
			// _txtCommonTextBox_9
			// 
			this._txtCommonTextBox_9.AllowDrop = true;
			this._txtCommonTextBox_9.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_9.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_9.Location = new System.Drawing.Point(122, 134);
			this._txtCommonTextBox_9.Name = "_txtCommonTextBox_9";
			this._txtCommonTextBox_9.Size = new System.Drawing.Size(643, 19);
			this._txtCommonTextBox_9.TabIndex = 25;
			this._txtCommonTextBox_9.Text = "";
			// this.this._txtCommonTextBox_9.Watermark = "";
			// this.this._txtCommonTextBox_9.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_9.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _txtCommonTextBox_46
			// 
			this._txtCommonTextBox_46.AllowDrop = true;
			this._txtCommonTextBox_46.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_46.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_46.Location = new System.Drawing.Point(122, 156);
			this._txtCommonTextBox_46.Name = "_txtCommonTextBox_46";
			this._txtCommonTextBox_46.Size = new System.Drawing.Size(643, 19);
			this._txtCommonTextBox_46.TabIndex = 26;
			this._txtCommonTextBox_46.Text = "";
			// this.this._txtCommonTextBox_46.Watermark = "";
			// this.this._txtCommonTextBox_46.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_46.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _lblCommon_35
			// 
			this._lblCommon_35.AllowDrop = true;
			this._lblCommon_35.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._lblCommon_35.Text = "Previous Company";
			this._lblCommon_35.Location = new System.Drawing.Point(10, 158);
			// this._lblCommon_35.mLabelId = 2195;
			this._lblCommon_35.Name = "_lblCommon_35";
			this._lblCommon_35.Size = new System.Drawing.Size(89, 13);
			this._lblCommon_35.TabIndex = 128;
			// 
			// _txtCommonTextBox_47
			// 
			this._txtCommonTextBox_47.AllowDrop = true;
			this._txtCommonTextBox_47.BackColor = System.Drawing.Color.White;
			// this._txtCommonTextBox_47.bolNumericOnly = true;
			this._txtCommonTextBox_47.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_47.Location = new System.Drawing.Point(122, 200);
			this._txtCommonTextBox_47.MaxLength = 8;
			this._txtCommonTextBox_47.Name = "_txtCommonTextBox_47";
			// this._txtCommonTextBox_47.ShowButton = true;
			this._txtCommonTextBox_47.Size = new System.Drawing.Size(101, 19);
			this._txtCommonTextBox_47.TabIndex = 28;
			this._txtCommonTextBox_47.Text = "";
			// this.this._txtCommonTextBox_47.Watermark = "";
			// this.this._txtCommonTextBox_47.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_47.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _lblCommon_112
			// 
			this._lblCommon_112.AllowDrop = true;
			this._lblCommon_112.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._lblCommon_112.Text = "Nationality Code";
			this._lblCommon_112.Location = new System.Drawing.Point(10, 202);
			// this._lblCommon_112.mLabelId = 1058;
			this._lblCommon_112.Name = "_lblCommon_112";
			this._lblCommon_112.Size = new System.Drawing.Size(77, 14);
			this._lblCommon_112.TabIndex = 129;
			// 
			// _txtDisplayLabel_7
			// 
			this._txtDisplayLabel_7.AllowDrop = true;
			this._txtDisplayLabel_7.Location = new System.Drawing.Point(227, 200);
			this._txtDisplayLabel_7.Name = "_txtDisplayLabel_7";
			this._txtDisplayLabel_7.Size = new System.Drawing.Size(540, 19);
			this._txtDisplayLabel_7.TabIndex = 130;
			this._txtDisplayLabel_7.TabStop = false;
			// 
			// _lblCommon_41
			// 
			this._lblCommon_41.AllowDrop = true;
			this._lblCommon_41.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._lblCommon_41.Text = "Sponsor Code";
			this._lblCommon_41.Location = new System.Drawing.Point(10, 223);
			// this._lblCommon_41.mLabelId = 1939;
			this._lblCommon_41.Name = "_lblCommon_41";
			this._lblCommon_41.Size = new System.Drawing.Size(67, 13);
			this._lblCommon_41.TabIndex = 131;
			// 
			// _txtCommonTextBox_52
			// 
			this._txtCommonTextBox_52.AllowDrop = true;
			this._txtCommonTextBox_52.BackColor = System.Drawing.Color.White;
			// this._txtCommonTextBox_52.bolNumericOnly = true;
			this._txtCommonTextBox_52.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_52.Location = new System.Drawing.Point(122, 220);
			this._txtCommonTextBox_52.MaxLength = 20;
			this._txtCommonTextBox_52.Name = "_txtCommonTextBox_52";
			// this._txtCommonTextBox_52.ShowButton = true;
			this._txtCommonTextBox_52.Size = new System.Drawing.Size(101, 19);
			this._txtCommonTextBox_52.TabIndex = 29;
			this._txtCommonTextBox_52.Text = "";
			// this.this._txtCommonTextBox_52.Watermark = "";
			// this.this._txtCommonTextBox_52.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_52.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _txtDisplayLabel_10
			// 
			this._txtDisplayLabel_10.AllowDrop = true;
			this._txtDisplayLabel_10.Location = new System.Drawing.Point(227, 220);
			this._txtDisplayLabel_10.Name = "_txtDisplayLabel_10";
			this._txtDisplayLabel_10.Size = new System.Drawing.Size(540, 19);
			this._txtDisplayLabel_10.TabIndex = 132;
			this._txtDisplayLabel_10.TabStop = false;
			// 
			// _lblCommon_40
			// 
			this._lblCommon_40.AllowDrop = true;
			this._lblCommon_40.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._lblCommon_40.Text = "Visa Type Code";
			this._lblCommon_40.Location = new System.Drawing.Point(10, 243);
			// this._lblCommon_40.mLabelId = 1967;
			this._lblCommon_40.Name = "_lblCommon_40";
			this._lblCommon_40.Size = new System.Drawing.Size(74, 13);
			this._lblCommon_40.TabIndex = 133;
			// 
			// _txtCommonTextBox_51
			// 
			this._txtCommonTextBox_51.AllowDrop = true;
			this._txtCommonTextBox_51.BackColor = System.Drawing.Color.White;
			// this._txtCommonTextBox_51.bolNumericOnly = true;
			this._txtCommonTextBox_51.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_51.Location = new System.Drawing.Point(122, 240);
			this._txtCommonTextBox_51.MaxLength = 20;
			this._txtCommonTextBox_51.Name = "_txtCommonTextBox_51";
			// this._txtCommonTextBox_51.ShowButton = true;
			this._txtCommonTextBox_51.Size = new System.Drawing.Size(101, 19);
			this._txtCommonTextBox_51.TabIndex = 30;
			this._txtCommonTextBox_51.Text = "";
			// this.this._txtCommonTextBox_51.Watermark = "";
			// this.this._txtCommonTextBox_51.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_51.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _txtDisplayLabel_9
			// 
			this._txtDisplayLabel_9.AllowDrop = true;
			this._txtDisplayLabel_9.Location = new System.Drawing.Point(227, 240);
			this._txtDisplayLabel_9.Name = "_txtDisplayLabel_9";
			this._txtDisplayLabel_9.Size = new System.Drawing.Size(540, 19);
			this._txtDisplayLabel_9.TabIndex = 134;
			this._txtDisplayLabel_9.TabStop = false;
			// 
			// _lblCommonLabel_18
			// 
			this._lblCommonLabel_18.AllowDrop = true;
			this._lblCommonLabel_18.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._lblCommonLabel_18.Text = "Governate Code";
			this._lblCommonLabel_18.Location = new System.Drawing.Point(10, 262);
			// this._lblCommonLabel_18.mLabelId = 1816;
			this._lblCommonLabel_18.Name = "_lblCommonLabel_18";
			this._lblCommonLabel_18.Size = new System.Drawing.Size(79, 14);
			this._lblCommonLabel_18.TabIndex = 135;
			// 
			// _txtCommonTextBox_48
			// 
			this._txtCommonTextBox_48.AllowDrop = true;
			this._txtCommonTextBox_48.BackColor = System.Drawing.Color.White;
			// this._txtCommonTextBox_48.bolNumericOnly = true;
			this._txtCommonTextBox_48.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_48.Location = new System.Drawing.Point(122, 260);
			this._txtCommonTextBox_48.MaxLength = 4;
			this._txtCommonTextBox_48.Name = "_txtCommonTextBox_48";
			// this._txtCommonTextBox_48.ShowButton = true;
			this._txtCommonTextBox_48.Size = new System.Drawing.Size(101, 19);
			this._txtCommonTextBox_48.TabIndex = 31;
			this._txtCommonTextBox_48.Text = "";
			// this.this._txtCommonTextBox_48.Watermark = "";
			// this.this._txtCommonTextBox_48.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_48.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _txtDisplayLabel_1
			// 
			this._txtDisplayLabel_1.AllowDrop = true;
			this._txtDisplayLabel_1.Location = new System.Drawing.Point(227, 260);
			this._txtDisplayLabel_1.Name = "_txtDisplayLabel_1";
			this._txtDisplayLabel_1.Size = new System.Drawing.Size(540, 19);
			this._txtDisplayLabel_1.TabIndex = 136;
			// 
			// _lblCommon_103
			// 
			this._lblCommon_103.AllowDrop = true;
			this._lblCommon_103.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._lblCommon_103.Text = "Religion Code";
			this._lblCommon_103.Location = new System.Drawing.Point(405, 32);
			// this._lblCommon_103.mLabelId = 1059;
			this._lblCommon_103.Name = "_lblCommon_103";
			this._lblCommon_103.Size = new System.Drawing.Size(65, 14);
			this._lblCommon_103.TabIndex = 137;
			// 
			// _System.Windows.Forms.Label1_1
			// 
			this._System.Windows.Forms.Label1_1.AllowDrop = true;
			this._System.Windows.Forms.Label1_1.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._System.Windows.Forms.Label1_1.Caption = "Sex";
			this._System.Windows.Forms.Label1_1.Location = new System.Drawing.Point(405, 10);
			this._System.Windows.Forms.Label1_1.mLabelId = 1981;
			this._System.Windows.Forms.Label1_1.Name = "_System.Windows.Forms.Label1_1";
			this._System.Windows.Forms.Label1_1.Size = new System.Drawing.Size(19, 14);
			this._System.Windows.Forms.Label1_1.TabIndex = 138;
			// 
			// _System.Windows.Forms.Label1_2
			// 
			this._System.Windows.Forms.Label1_2.AllowDrop = true;
			this._System.Windows.Forms.Label1_2.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._System.Windows.Forms.Label1_2.Caption = "Marital Status";
			this._System.Windows.Forms.Label1_2.Location = new System.Drawing.Point(405, 52);
			this._System.Windows.Forms.Label1_2.mLabelId = 1928;
			this._System.Windows.Forms.Label1_2.Name = "_System.Windows.Forms.Label1_2";
			this._System.Windows.Forms.Label1_2.Size = new System.Drawing.Size(65, 14);
			this._System.Windows.Forms.Label1_2.TabIndex = 139;
			// 
			// _txtCommonTextBox_49
			// 
			this._txtCommonTextBox_49.AllowDrop = true;
			this._txtCommonTextBox_49.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_49.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_49.Location = new System.Drawing.Point(521, 8);
			this._txtCommonTextBox_49.Name = "_txtCommonTextBox_49";
			this._txtCommonTextBox_49.Size = new System.Drawing.Size(244, 19);
			this._txtCommonTextBox_49.TabIndex = 18;
			this._txtCommonTextBox_49.Text = "";
			// this.this._txtCommonTextBox_49.Watermark = "";
			// this.this._txtCommonTextBox_49.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_49.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _txtCommonTextBox_50
			// 
			this._txtCommonTextBox_50.AllowDrop = true;
			this._txtCommonTextBox_50.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_50.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_50.Location = new System.Drawing.Point(521, 30);
			this._txtCommonTextBox_50.Name = "_txtCommonTextBox_50";
			// this._txtCommonTextBox_50.ShowButton = true;
			this._txtCommonTextBox_50.Size = new System.Drawing.Size(244, 19);
			this._txtCommonTextBox_50.TabIndex = 19;
			this._txtCommonTextBox_50.Text = "";
			// this.this._txtCommonTextBox_50.Watermark = "";
			// this.this._txtCommonTextBox_50.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_50.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _txtCommonTextBox_53
			// 
			this._txtCommonTextBox_53.AllowDrop = true;
			this._txtCommonTextBox_53.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_53.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_53.Location = new System.Drawing.Point(521, 50);
			this._txtCommonTextBox_53.Name = "_txtCommonTextBox_53";
			this._txtCommonTextBox_53.Size = new System.Drawing.Size(244, 19);
			this._txtCommonTextBox_53.TabIndex = 20;
			this._txtCommonTextBox_53.Text = "";
			// this.this._txtCommonTextBox_53.Watermark = "";
			// this.this._txtCommonTextBox_53.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_53.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _lblCommon_32
			// 
			this._lblCommon_32.AllowDrop = true;
			this._lblCommon_32.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._lblCommon_32.Text = "Place Of Birth";
			this._lblCommon_32.Location = new System.Drawing.Point(405, 73);
			// this._lblCommon_32.mLabelId = 1985;
			this._lblCommon_32.Name = "_lblCommon_32";
			this._lblCommon_32.Size = new System.Drawing.Size(65, 13);
			this._lblCommon_32.TabIndex = 140;
			// 
			// _txtCommonTextBox_18
			// 
			this._txtCommonTextBox_18.AllowDrop = true;
			this._txtCommonTextBox_18.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_18.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_18.Location = new System.Drawing.Point(521, 70);
			this._txtCommonTextBox_18.Name = "_txtCommonTextBox_18";
			this._txtCommonTextBox_18.Size = new System.Drawing.Size(244, 19);
			this._txtCommonTextBox_18.TabIndex = 21;
			this._txtCommonTextBox_18.Text = "";
			// this.this._txtCommonTextBox_18.Watermark = "";
			// this.this._txtCommonTextBox_18.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_18.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _lblCommon_33
			// 
			this._lblCommon_33.AllowDrop = true;
			this._lblCommon_33.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._lblCommon_33.Text = "Blood Group";
			this._lblCommon_33.Location = new System.Drawing.Point(405, 94);
			// this._lblCommon_33.mLabelId = 1083;
			this._lblCommon_33.Name = "_lblCommon_33";
			this._lblCommon_33.Size = new System.Drawing.Size(58, 13);
			this._lblCommon_33.TabIndex = 141;
			// 
			// _txtCommonTextBox_23
			// 
			this._txtCommonTextBox_23.AllowDrop = true;
			this._txtCommonTextBox_23.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_23.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_23.Location = new System.Drawing.Point(521, 90);
			this._txtCommonTextBox_23.Name = "_txtCommonTextBox_23";
			this._txtCommonTextBox_23.Size = new System.Drawing.Size(244, 19);
			this._txtCommonTextBox_23.TabIndex = 22;
			this._txtCommonTextBox_23.Text = "";
			// this.this._txtCommonTextBox_23.Watermark = "";
			// this.this._txtCommonTextBox_23.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_23.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _lblCommon_108
			// 
			this._lblCommon_108.AllowDrop = true;
			this._lblCommon_108.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._lblCommon_108.Text = "Birth Date";
			this._lblCommon_108.Location = new System.Drawing.Point(405, 114);
			// this._lblCommon_108.mLabelId = 1056;
			this._lblCommon_108.Name = "_lblCommon_108";
			this._lblCommon_108.Size = new System.Drawing.Size(47, 14);
			this._lblCommon_108.TabIndex = 142;
			// 
			// txtBirthDate
			// 
			this.txtBirthDate.AllowDrop = true;
			this.txtBirthDate.CenturyMode = TDBDate6.dbiCenturyModeConst.dbiDateWindow;
			// this.txtBirthDate.CheckDateRange = false;
			this.txtBirthDate.Location = new System.Drawing.Point(521, 112);
			// this.txtBirthDate.MaxDate = 51501;
			// this.txtBirthDate.MinDate = 14246;
			this.txtBirthDate.Name = "txtBirthDate";
			this.txtBirthDate.Size = new System.Drawing.Size(88, 19);
			this.txtBirthDate.TabIndex = 23;
			this.txtBirthDate.Text = "06/Apr/2003";
			this.txtBirthDate.Value = 37717;
			// 
			// _txtCommonTextBox_54
			// 
			this._txtCommonTextBox_54.AllowDrop = true;
			this._txtCommonTextBox_54.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_54.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_54.Location = new System.Drawing.Point(122, 177);
			this._txtCommonTextBox_54.Name = "_txtCommonTextBox_54";
			this._txtCommonTextBox_54.Size = new System.Drawing.Size(643, 19);
			this._txtCommonTextBox_54.TabIndex = 27;
			this._txtCommonTextBox_54.Text = "";
			// this.this._txtCommonTextBox_54.Watermark = "";
			// this.this._txtCommonTextBox_54.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_54.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _lblCommon_37
			// 
			this._lblCommon_37.AllowDrop = true;
			this._lblCommon_37.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._lblCommon_37.Text = "Authorized Signature";
			this._lblCommon_37.Location = new System.Drawing.Point(9, 179);
			// this._lblCommon_37.mLabelId = 2196;
			this._lblCommon_37.Name = "_lblCommon_37";
			this._lblCommon_37.Size = new System.Drawing.Size(101, 13);
			this._lblCommon_37.TabIndex = 145;
			// 
			// _lblCommon_60
			// 
			this._lblCommon_60.AllowDrop = true;
			this._lblCommon_60.BackColor = System.Drawing.Color.White;
			this._lblCommon_60.Text = "Entry Date";
			this._lblCommon_60.Location = new System.Drawing.Point(611, 114);
			// this._lblCommon_60.mLabelId = 2193;
			this._lblCommon_60.Name = "_lblCommon_60";
			this._lblCommon_60.Size = new System.Drawing.Size(50, 14);
			this._lblCommon_60.TabIndex = 161;
			// 
			// txtDEntryDate
			// 
			this.txtDEntryDate.AllowDrop = true;
			this.txtDEntryDate.CenturyMode = TDBDate6.dbiCenturyModeConst.dbiDateWindow;
			// this.txtDEntryDate.CheckDateRange = false;
			this.txtDEntryDate.Location = new System.Drawing.Point(668, 112);
			// this.txtDEntryDate.MaxDate = 51501;
			// this.txtDEntryDate.MinDate = 14246;
			this.txtDEntryDate.Name = "txtDEntryDate";
			this.txtDEntryDate.Size = new System.Drawing.Size(97, 19);
			this.txtDEntryDate.TabIndex = 24;
			this.txtDEntryDate.Text = "06/Apr/2003";
			this.txtDEntryDate.Value = 37717;
			// 
			// _fraEmployeeInformation_4
			// 
			this._fraEmployeeInformation_4.AllowDrop = true;
			this._fraEmployeeInformation_4.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._fraEmployeeInformation_4.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._fraEmployeeInformation_4.Controls.Add(this._txtCommonTextBox_45);
			this._fraEmployeeInformation_4.Controls.Add(this.System.Windows.Forms.Label2);
			this._fraEmployeeInformation_4.Controls.Add(this._lblCommon_1);
			this._fraEmployeeInformation_4.Controls.Add(this._txtCommonTextBox_29);
			this._fraEmployeeInformation_4.Controls.Add(this._lblCommon_2);
			this._fraEmployeeInformation_4.Controls.Add(this._txtCommonTextBox_28);
			this._fraEmployeeInformation_4.Controls.Add(this._lblCommon_3);
			this._fraEmployeeInformation_4.Controls.Add(this._txtCommonTextBox_27);
			this._fraEmployeeInformation_4.Controls.Add(this._lblCommon_5);
			this._fraEmployeeInformation_4.Controls.Add(this._txtCommonTextBox_26);
			this._fraEmployeeInformation_4.Controls.Add(this._lblCommon_11);
			this._fraEmployeeInformation_4.Controls.Add(this._txtCommonTextBox_25);
			this._fraEmployeeInformation_4.Controls.Add(this._lblCommon_12);
			this._fraEmployeeInformation_4.Controls.Add(this._txtCommonTextBox_24);
			this._fraEmployeeInformation_4.Controls.Add(this._lblCommon_13);
			this._fraEmployeeInformation_4.Controls.Add(this._txtCommonTextBox_30);
			this._fraEmployeeInformation_4.Controls.Add(this._lblCommon_14);
			this._fraEmployeeInformation_4.Controls.Add(this._txtCommonTextBox_31);
			this._fraEmployeeInformation_4.Controls.Add(this._lblCommon_15);
			this._fraEmployeeInformation_4.Controls.Add(this._txtCommonTextBox_32);
			this._fraEmployeeInformation_4.Controls.Add(this._lblCommon_16);
			this._fraEmployeeInformation_4.Controls.Add(this._txtCommonTextBox_33);
			this._fraEmployeeInformation_4.Controls.Add(this._lblCommon_17);
			this._fraEmployeeInformation_4.Controls.Add(this._txtCommonTextBox_34);
			this._fraEmployeeInformation_4.Controls.Add(this._lblCommon_18);
			this._fraEmployeeInformation_4.Controls.Add(this._txtCommonTextBox_35);
			this._fraEmployeeInformation_4.Controls.Add(this._lblCommon_19);
			this._fraEmployeeInformation_4.Controls.Add(this._txtCommonTextBox_36);
			this._fraEmployeeInformation_4.Controls.Add(this._lblCommon_20);
			this._fraEmployeeInformation_4.Controls.Add(this._txtCommonTextBox_37);
			this._fraEmployeeInformation_4.Controls.Add(this._lblCommon_21);
			this._fraEmployeeInformation_4.Controls.Add(this._txtCommonTextBox_38);
			this._fraEmployeeInformation_4.Controls.Add(this._lblCommon_22);
			this._fraEmployeeInformation_4.Controls.Add(this._txtCommonTextBox_39);
			this._fraEmployeeInformation_4.Controls.Add(this._lblCommon_24);
			this._fraEmployeeInformation_4.Controls.Add(this._txtCommonTextBox_40);
			this._fraEmployeeInformation_4.Controls.Add(this._lblCommon_25);
			this._fraEmployeeInformation_4.Controls.Add(this._txtCommonTextBox_41);
			this._fraEmployeeInformation_4.Controls.Add(this._lblCommon_26);
			this._fraEmployeeInformation_4.Controls.Add(this._txtCommonTextBox_42);
			this._fraEmployeeInformation_4.Controls.Add(this._lblCommon_47);
			this._fraEmployeeInformation_4.Controls.Add(this._lblCommon_48);
			this._fraEmployeeInformation_4.Controls.Add(this._lblCommon_36);
			this._fraEmployeeInformation_4.Controls.Add(this._txtCommonTextBox_44);
			this._fraEmployeeInformation_4.Controls.Add(this.System.Windows.Forms.Label3);
			this._fraEmployeeInformation_4.Controls.Add(this._txtCommonTextBox_43);
			this._fraEmployeeInformation_4.Controls.Add(this.Shape2);
			this._fraEmployeeInformation_4.Controls.Add(this.Shape1);
			this._fraEmployeeInformation_4.Enabled = true;
			this._fraEmployeeInformation_4.ForeColor = System.Drawing.SystemColors.WindowText;
			this._fraEmployeeInformation_4.Location = new System.Drawing.Point(895, 23);
			this._fraEmployeeInformation_4.Name = "_fraEmployeeInformation_4";
			this._fraEmployeeInformation_4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._fraEmployeeInformation_4.Size = new System.Drawing.Size(852, 295);
			this._fraEmployeeInformation_4.TabIndex = 32;
			this._fraEmployeeInformation_4.Visible = true;
			// 
			// _txtCommonTextBox_45
			// 
			this._txtCommonTextBox_45.AllowDrop = true;
			this._txtCommonTextBox_45.BackColor = System.Drawing.Color.White;
			// this._txtCommonTextBox_45.bolAllowDecimal = false;
			this._txtCommonTextBox_45.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_45.Location = new System.Drawing.Point(92, 256);
			// this._txtCommonTextBox_45.mDropDownType = (System.Windows.Forms.TextBox.DropDownTypes) 0;
			this._txtCommonTextBox_45.Name = "_txtCommonTextBox_45";
			this._txtCommonTextBox_45.Size = new System.Drawing.Size(736, 21);
			this._txtCommonTextBox_45.TabIndex = 124;
			this._txtCommonTextBox_45.Text = "";
			// this.this._txtCommonTextBox_45.Watermark = "";
			// this.this._txtCommonTextBox_45.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_45.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// System.Windows.Forms.Label2
			// 
			this.System.Windows.Forms.Label2.AllowDrop = true;
			this.System.Windows.Forms.Label2.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this.System.Windows.Forms.Label2.Caption = "Address4";
			this.System.Windows.Forms.Label2.Location = new System.Drawing.Point(12, 259);
			this.System.Windows.Forms.Label2.mLabelId = 2197;
			this.System.Windows.Forms.Label2.Name = "System.Windows.Forms.Label2";
			this.System.Windows.Forms.Label2.Size = new System.Drawing.Size(48, 14);
			this.System.Windows.Forms.Label2.TabIndex = 81;
			// 
			// _lblCommon_1
			// 
			this._lblCommon_1.AllowDrop = true;
			this._lblCommon_1.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._lblCommon_1.Text = "Mobile No.";
			this._lblCommon_1.Location = new System.Drawing.Point(260, 126);
			// this._lblCommon_1.mLabelId = 1073;
			this._lblCommon_1.Name = "_lblCommon_1";
			this._lblCommon_1.Size = new System.Drawing.Size(50, 13);
			this._lblCommon_1.TabIndex = 82;
			// 
			// _txtCommonTextBox_29
			// 
			this._txtCommonTextBox_29.AllowDrop = true;
			this._txtCommonTextBox_29.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_29.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_29.Location = new System.Drawing.Point(379, 123);
			this._txtCommonTextBox_29.Name = "_txtCommonTextBox_29";
			this._txtCommonTextBox_29.Size = new System.Drawing.Size(119, 19);
			this._txtCommonTextBox_29.TabIndex = 111;
			this._txtCommonTextBox_29.Text = "";
			// this.this._txtCommonTextBox_29.Watermark = "";
			// this.this._txtCommonTextBox_29.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_29.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _lblCommon_2
			// 
			this._lblCommon_2.AllowDrop = true;
			this._lblCommon_2.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._lblCommon_2.Text = "Telephone No.";
			this._lblCommon_2.Location = new System.Drawing.Point(12, 126);
			// this._lblCommon_2.mLabelId = 1067;
			this._lblCommon_2.Name = "_lblCommon_2";
			this._lblCommon_2.Size = new System.Drawing.Size(70, 13);
			this._lblCommon_2.TabIndex = 83;
			// 
			// _txtCommonTextBox_28
			// 
			this._txtCommonTextBox_28.AllowDrop = true;
			this._txtCommonTextBox_28.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_28.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_28.Location = new System.Drawing.Point(98, 123);
			this._txtCommonTextBox_28.Name = "_txtCommonTextBox_28";
			this._txtCommonTextBox_28.Size = new System.Drawing.Size(125, 19);
			this._txtCommonTextBox_28.TabIndex = 100;
			this._txtCommonTextBox_28.Text = "";
			// this.this._txtCommonTextBox_28.Watermark = "";
			// this.this._txtCommonTextBox_28.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_28.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _lblCommon_3
			// 
			this._lblCommon_3.AllowDrop = true;
			this._lblCommon_3.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._lblCommon_3.Text = "Zip Code";
			this._lblCommon_3.Location = new System.Drawing.Point(260, 105);
			// this._lblCommon_3.mLabelId = 1072;
			this._lblCommon_3.Name = "_lblCommon_3";
			this._lblCommon_3.Size = new System.Drawing.Size(42, 13);
			this._lblCommon_3.TabIndex = 84;
			// 
			// _txtCommonTextBox_27
			// 
			this._txtCommonTextBox_27.AllowDrop = true;
			this._txtCommonTextBox_27.BackColor = System.Drawing.Color.White;
			// this._txtCommonTextBox_27.bolNumericOnly = true;
			this._txtCommonTextBox_27.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_27.Location = new System.Drawing.Point(379, 102);
			this._txtCommonTextBox_27.Name = "_txtCommonTextBox_27";
			this._txtCommonTextBox_27.Size = new System.Drawing.Size(119, 19);
			this._txtCommonTextBox_27.TabIndex = 109;
			this._txtCommonTextBox_27.Text = "";
			// this.this._txtCommonTextBox_27.Watermark = "";
			// this.this._txtCommonTextBox_27.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_27.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _lblCommon_5
			// 
			this._lblCommon_5.AllowDrop = true;
			this._lblCommon_5.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._lblCommon_5.Text = "P.O. Box";
			this._lblCommon_5.Location = new System.Drawing.Point(12, 105);
			// this._lblCommon_5.mLabelId = 1066;
			this._lblCommon_5.Name = "_lblCommon_5";
			this._lblCommon_5.Size = new System.Drawing.Size(43, 13);
			this._lblCommon_5.TabIndex = 85;
			// 
			// _txtCommonTextBox_26
			// 
			this._txtCommonTextBox_26.AllowDrop = true;
			this._txtCommonTextBox_26.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_26.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_26.Location = new System.Drawing.Point(98, 102);
			this._txtCommonTextBox_26.Name = "_txtCommonTextBox_26";
			this._txtCommonTextBox_26.Size = new System.Drawing.Size(125, 19);
			this._txtCommonTextBox_26.TabIndex = 98;
			this._txtCommonTextBox_26.Text = "";
			// this.this._txtCommonTextBox_26.Watermark = "";
			// this.this._txtCommonTextBox_26.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_26.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _lblCommon_11
			// 
			this._lblCommon_11.AllowDrop = true;
			this._lblCommon_11.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._lblCommon_11.Text = "Entrance";
			this._lblCommon_11.Location = new System.Drawing.Point(595, 84);
			// this._lblCommon_11.mLabelId = 1075;
			this._lblCommon_11.Name = "_lblCommon_11";
			this._lblCommon_11.Size = new System.Drawing.Size(43, 13);
			this._lblCommon_11.TabIndex = 86;
			// 
			// _txtCommonTextBox_25
			// 
			this._txtCommonTextBox_25.AllowDrop = true;
			this._txtCommonTextBox_25.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_25.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_25.Location = new System.Drawing.Point(673, 81);
			this._txtCommonTextBox_25.Name = "_txtCommonTextBox_25";
			this._txtCommonTextBox_25.Size = new System.Drawing.Size(152, 19);
			this._txtCommonTextBox_25.TabIndex = 114;
			this._txtCommonTextBox_25.Text = "";
			// this.this._txtCommonTextBox_25.Watermark = "";
			// this.this._txtCommonTextBox_25.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_25.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _lblCommon_12
			// 
			this._lblCommon_12.AllowDrop = true;
			this._lblCommon_12.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._lblCommon_12.Text = "Qasima";
			this._lblCommon_12.Location = new System.Drawing.Point(595, 63);
			// this._lblCommon_12.mLabelId = 1074;
			this._lblCommon_12.Name = "_lblCommon_12";
			this._lblCommon_12.Size = new System.Drawing.Size(35, 13);
			this._lblCommon_12.TabIndex = 87;
			// 
			// _txtCommonTextBox_24
			// 
			this._txtCommonTextBox_24.AllowDrop = true;
			this._txtCommonTextBox_24.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_24.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_24.Location = new System.Drawing.Point(673, 60);
			this._txtCommonTextBox_24.Name = "_txtCommonTextBox_24";
			this._txtCommonTextBox_24.Size = new System.Drawing.Size(152, 19);
			this._txtCommonTextBox_24.TabIndex = 112;
			this._txtCommonTextBox_24.Text = "";
			// this.this._txtCommonTextBox_24.Watermark = "";
			// this.this._txtCommonTextBox_24.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_24.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _lblCommon_13
			// 
			this._lblCommon_13.AllowDrop = true;
			this._lblCommon_13.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._lblCommon_13.Text = "Flat No.";
			this._lblCommon_13.Location = new System.Drawing.Point(260, 84);
			// this._lblCommon_13.mLabelId = 1071;
			this._lblCommon_13.Name = "_lblCommon_13";
			this._lblCommon_13.Size = new System.Drawing.Size(38, 13);
			this._lblCommon_13.TabIndex = 88;
			// 
			// _txtCommonTextBox_30
			// 
			this._txtCommonTextBox_30.AllowDrop = true;
			this._txtCommonTextBox_30.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_30.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_30.Location = new System.Drawing.Point(379, 81);
			this._txtCommonTextBox_30.Name = "_txtCommonTextBox_30";
			this._txtCommonTextBox_30.Size = new System.Drawing.Size(119, 19);
			this._txtCommonTextBox_30.TabIndex = 107;
			this._txtCommonTextBox_30.Text = "";
			// this.this._txtCommonTextBox_30.Watermark = "";
			// this.this._txtCommonTextBox_30.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_30.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _lblCommon_14
			// 
			this._lblCommon_14.AllowDrop = true;
			this._lblCommon_14.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._lblCommon_14.Text = "Floor";
			this._lblCommon_14.Location = new System.Drawing.Point(12, 84);
			// this._lblCommon_14.mLabelId = 1065;
			this._lblCommon_14.Name = "_lblCommon_14";
			this._lblCommon_14.Size = new System.Drawing.Size(24, 13);
			this._lblCommon_14.TabIndex = 89;
			// 
			// _txtCommonTextBox_31
			// 
			this._txtCommonTextBox_31.AllowDrop = true;
			this._txtCommonTextBox_31.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_31.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_31.Location = new System.Drawing.Point(98, 81);
			this._txtCommonTextBox_31.Name = "_txtCommonTextBox_31";
			this._txtCommonTextBox_31.Size = new System.Drawing.Size(125, 19);
			this._txtCommonTextBox_31.TabIndex = 96;
			this._txtCommonTextBox_31.Text = "";
			// this.this._txtCommonTextBox_31.Watermark = "";
			// this.this._txtCommonTextBox_31.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_31.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _lblCommon_15
			// 
			this._lblCommon_15.AllowDrop = true;
			this._lblCommon_15.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._lblCommon_15.Text = "Building No.";
			this._lblCommon_15.Location = new System.Drawing.Point(260, 63);
			// this._lblCommon_15.mLabelId = 1070;
			this._lblCommon_15.Name = "_lblCommon_15";
			this._lblCommon_15.Size = new System.Drawing.Size(56, 13);
			this._lblCommon_15.TabIndex = 90;
			// 
			// _txtCommonTextBox_32
			// 
			this._txtCommonTextBox_32.AllowDrop = true;
			this._txtCommonTextBox_32.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_32.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_32.Location = new System.Drawing.Point(379, 60);
			this._txtCommonTextBox_32.Name = "_txtCommonTextBox_32";
			this._txtCommonTextBox_32.Size = new System.Drawing.Size(119, 19);
			this._txtCommonTextBox_32.TabIndex = 106;
			this._txtCommonTextBox_32.Text = "";
			// this.this._txtCommonTextBox_32.Watermark = "";
			// this.this._txtCommonTextBox_32.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_32.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _lblCommon_16
			// 
			this._lblCommon_16.AllowDrop = true;
			this._lblCommon_16.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._lblCommon_16.Text = "Type Of Building";
			this._lblCommon_16.Location = new System.Drawing.Point(12, 63);
			// this._lblCommon_16.mLabelId = 1064;
			this._lblCommon_16.Name = "_lblCommon_16";
			this._lblCommon_16.Size = new System.Drawing.Size(78, 13);
			this._lblCommon_16.TabIndex = 91;
			// 
			// _txtCommonTextBox_33
			// 
			this._txtCommonTextBox_33.AllowDrop = true;
			this._txtCommonTextBox_33.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_33.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_33.Location = new System.Drawing.Point(98, 60);
			this._txtCommonTextBox_33.Name = "_txtCommonTextBox_33";
			this._txtCommonTextBox_33.Size = new System.Drawing.Size(125, 19);
			this._txtCommonTextBox_33.TabIndex = 95;
			this._txtCommonTextBox_33.Text = "";
			// this.this._txtCommonTextBox_33.Watermark = "";
			// this.this._txtCommonTextBox_33.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_33.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _lblCommon_17
			// 
			this._lblCommon_17.AllowDrop = true;
			this._lblCommon_17.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._lblCommon_17.Text = "Lane";
			this._lblCommon_17.Location = new System.Drawing.Point(260, 42);
			// this._lblCommon_17.mLabelId = 1069;
			this._lblCommon_17.Name = "_lblCommon_17";
			this._lblCommon_17.Size = new System.Drawing.Size(23, 13);
			this._lblCommon_17.TabIndex = 94;
			// 
			// _txtCommonTextBox_34
			// 
			this._txtCommonTextBox_34.AllowDrop = true;
			this._txtCommonTextBox_34.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_34.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_34.Location = new System.Drawing.Point(379, 39);
			this._txtCommonTextBox_34.Name = "_txtCommonTextBox_34";
			this._txtCommonTextBox_34.Size = new System.Drawing.Size(119, 19);
			this._txtCommonTextBox_34.TabIndex = 104;
			this._txtCommonTextBox_34.Text = "";
			// this.this._txtCommonTextBox_34.Watermark = "";
			// this.this._txtCommonTextBox_34.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_34.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _lblCommon_18
			// 
			this._lblCommon_18.AllowDrop = true;
			this._lblCommon_18.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._lblCommon_18.Text = "Street";
			this._lblCommon_18.Location = new System.Drawing.Point(12, 42);
			// this._lblCommon_18.mLabelId = 1983;
			this._lblCommon_18.Name = "_lblCommon_18";
			this._lblCommon_18.Size = new System.Drawing.Size(30, 13);
			this._lblCommon_18.TabIndex = 97;
			// 
			// _txtCommonTextBox_35
			// 
			this._txtCommonTextBox_35.AllowDrop = true;
			this._txtCommonTextBox_35.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_35.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_35.Location = new System.Drawing.Point(98, 39);
			this._txtCommonTextBox_35.Name = "_txtCommonTextBox_35";
			this._txtCommonTextBox_35.Size = new System.Drawing.Size(125, 19);
			this._txtCommonTextBox_35.TabIndex = 93;
			this._txtCommonTextBox_35.Text = "";
			// this.this._txtCommonTextBox_35.Watermark = "";
			// this.this._txtCommonTextBox_35.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_35.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _lblCommon_19
			// 
			this._lblCommon_19.AllowDrop = true;
			this._lblCommon_19.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._lblCommon_19.Text = "Block";
			this._lblCommon_19.Location = new System.Drawing.Point(260, 21);
			// this._lblCommon_19.mLabelId = 1941;
			this._lblCommon_19.Name = "_lblCommon_19";
			this._lblCommon_19.Size = new System.Drawing.Size(24, 13);
			this._lblCommon_19.TabIndex = 99;
			// 
			// _txtCommonTextBox_36
			// 
			this._txtCommonTextBox_36.AllowDrop = true;
			this._txtCommonTextBox_36.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_36.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_36.Location = new System.Drawing.Point(379, 18);
			this._txtCommonTextBox_36.Name = "_txtCommonTextBox_36";
			this._txtCommonTextBox_36.Size = new System.Drawing.Size(119, 19);
			this._txtCommonTextBox_36.TabIndex = 102;
			this._txtCommonTextBox_36.Text = "";
			// this.this._txtCommonTextBox_36.Watermark = "";
			// this.this._txtCommonTextBox_36.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_36.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _lblCommon_20
			// 
			this._lblCommon_20.AllowDrop = true;
			this._lblCommon_20.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._lblCommon_20.Text = "Area";
			this._lblCommon_20.Location = new System.Drawing.Point(12, 21);
			// this._lblCommon_20.mLabelId = 1063;
			this._lblCommon_20.Name = "_lblCommon_20";
			this._lblCommon_20.Size = new System.Drawing.Size(23, 13);
			this._lblCommon_20.TabIndex = 103;
			// 
			// _txtCommonTextBox_37
			// 
			this._txtCommonTextBox_37.AllowDrop = true;
			this._txtCommonTextBox_37.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_37.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_37.Location = new System.Drawing.Point(98, 18);
			this._txtCommonTextBox_37.Name = "_txtCommonTextBox_37";
			this._txtCommonTextBox_37.Size = new System.Drawing.Size(125, 19);
			this._txtCommonTextBox_37.TabIndex = 92;
			this._txtCommonTextBox_37.Text = "";
			// this.this._txtCommonTextBox_37.Watermark = "";
			// this.this._txtCommonTextBox_37.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_37.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _lblCommon_21
			// 
			this._lblCommon_21.AllowDrop = true;
			this._lblCommon_21.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._lblCommon_21.Text = "Email Address";
			this._lblCommon_21.Location = new System.Drawing.Point(260, 147);
			// this._lblCommon_21.mLabelId = 899;
			this._lblCommon_21.Name = "_lblCommon_21";
			this._lblCommon_21.Size = new System.Drawing.Size(66, 13);
			this._lblCommon_21.TabIndex = 105;
			// 
			// _txtCommonTextBox_38
			// 
			this._txtCommonTextBox_38.AllowDrop = true;
			this._txtCommonTextBox_38.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_38.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_38.Location = new System.Drawing.Point(379, 144);
			this._txtCommonTextBox_38.Name = "_txtCommonTextBox_38";
			this._txtCommonTextBox_38.Size = new System.Drawing.Size(446, 19);
			this._txtCommonTextBox_38.TabIndex = 117;
			this._txtCommonTextBox_38.Text = "";
			// this.this._txtCommonTextBox_38.Watermark = "";
			// this.this._txtCommonTextBox_38.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_38.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _lblCommon_22
			// 
			this._lblCommon_22.AllowDrop = true;
			this._lblCommon_22.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._lblCommon_22.Text = "Pager No.";
			this._lblCommon_22.Location = new System.Drawing.Point(12, 147);
			// this._lblCommon_22.mLabelId = 1068;
			this._lblCommon_22.Name = "_lblCommon_22";
			this._lblCommon_22.Size = new System.Drawing.Size(48, 13);
			this._lblCommon_22.TabIndex = 108;
			// 
			// _txtCommonTextBox_39
			// 
			this._txtCommonTextBox_39.AllowDrop = true;
			this._txtCommonTextBox_39.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_39.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_39.Location = new System.Drawing.Point(98, 144);
			this._txtCommonTextBox_39.Name = "_txtCommonTextBox_39";
			this._txtCommonTextBox_39.Size = new System.Drawing.Size(125, 19);
			this._txtCommonTextBox_39.TabIndex = 101;
			this._txtCommonTextBox_39.Text = "";
			// this.this._txtCommonTextBox_39.Watermark = "";
			// this.this._txtCommonTextBox_39.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_39.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _lblCommon_24
			// 
			this._lblCommon_24.AllowDrop = true;
			this._lblCommon_24.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._lblCommon_24.Text = "Address3";
			this._lblCommon_24.Location = new System.Drawing.Point(12, 238);
			// this._lblCommon_24.mLabelId = 1984;
			this._lblCommon_24.Name = "_lblCommon_24";
			this._lblCommon_24.Size = new System.Drawing.Size(45, 13);
			this._lblCommon_24.TabIndex = 110;
			// 
			// _txtCommonTextBox_40
			// 
			this._txtCommonTextBox_40.AllowDrop = true;
			this._txtCommonTextBox_40.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_40.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_40.Location = new System.Drawing.Point(92, 235);
			this._txtCommonTextBox_40.Name = "_txtCommonTextBox_40";
			this._txtCommonTextBox_40.Size = new System.Drawing.Size(736, 19);
			this._txtCommonTextBox_40.TabIndex = 122;
			this._txtCommonTextBox_40.Text = "";
			// this.this._txtCommonTextBox_40.Watermark = "";
			// this.this._txtCommonTextBox_40.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_40.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _lblCommon_25
			// 
			this._lblCommon_25.AllowDrop = true;
			this._lblCommon_25.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._lblCommon_25.Text = "Address2";
			this._lblCommon_25.Location = new System.Drawing.Point(12, 217);
			// this._lblCommon_25.mLabelId = 1847;
			this._lblCommon_25.Name = "_lblCommon_25";
			this._lblCommon_25.Size = new System.Drawing.Size(45, 13);
			this._lblCommon_25.TabIndex = 113;
			// 
			// _txtCommonTextBox_41
			// 
			this._txtCommonTextBox_41.AllowDrop = true;
			this._txtCommonTextBox_41.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_41.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_41.Location = new System.Drawing.Point(92, 214);
			this._txtCommonTextBox_41.Name = "_txtCommonTextBox_41";
			this._txtCommonTextBox_41.Size = new System.Drawing.Size(736, 19);
			this._txtCommonTextBox_41.TabIndex = 120;
			this._txtCommonTextBox_41.Text = "";
			// this.this._txtCommonTextBox_41.Watermark = "";
			// this.this._txtCommonTextBox_41.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_41.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _lblCommon_26
			// 
			this._lblCommon_26.AllowDrop = true;
			this._lblCommon_26.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._lblCommon_26.Text = "Address1";
			this._lblCommon_26.Location = new System.Drawing.Point(12, 196);
			// this._lblCommon_26.mLabelId = 1846;
			this._lblCommon_26.Name = "_lblCommon_26";
			this._lblCommon_26.Size = new System.Drawing.Size(45, 13);
			this._lblCommon_26.TabIndex = 119;
			// 
			// _txtCommonTextBox_42
			// 
			this._txtCommonTextBox_42.AllowDrop = true;
			this._txtCommonTextBox_42.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_42.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_42.Location = new System.Drawing.Point(92, 193);
			this._txtCommonTextBox_42.Name = "_txtCommonTextBox_42";
			this._txtCommonTextBox_42.Size = new System.Drawing.Size(736, 19);
			this._txtCommonTextBox_42.TabIndex = 118;
			this._txtCommonTextBox_42.Text = "";
			// this.this._txtCommonTextBox_42.Watermark = "";
			// this.this._txtCommonTextBox_42.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_42.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _lblCommon_47
			// 
			this._lblCommon_47.AllowDrop = true;
			this._lblCommon_47.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._lblCommon_47.Text = " Local Address ";
			this._lblCommon_47.Location = new System.Drawing.Point(26, 2);
			// this._lblCommon_47.mLabelId = 1062;
			this._lblCommon_47.Name = "_lblCommon_47";
			this._lblCommon_47.Size = new System.Drawing.Size(72, 13);
			this._lblCommon_47.TabIndex = 121;
			// 
			// _lblCommon_48
			// 
			this._lblCommon_48.AllowDrop = true;
			this._lblCommon_48.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._lblCommon_48.Text = " Permanent Address ";
			this._lblCommon_48.Location = new System.Drawing.Point(26, 174);
			// this._lblCommon_48.mLabelId = 1077;
			this._lblCommon_48.Name = "_lblCommon_48";
			this._lblCommon_48.Size = new System.Drawing.Size(100, 13);
			this._lblCommon_48.TabIndex = 123;
			// 
			// _lblCommon_36
			// 
			this._lblCommon_36.AllowDrop = true;
			this._lblCommon_36.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._lblCommon_36.Text = "Fax No.";
			this._lblCommon_36.Location = new System.Drawing.Point(595, 104);
			// this._lblCommon_36.mLabelId = 1076;
			this._lblCommon_36.Name = "_lblCommon_36";
			this._lblCommon_36.Size = new System.Drawing.Size(38, 13);
			this._lblCommon_36.TabIndex = 125;
			// 
			// _txtCommonTextBox_44
			// 
			this._txtCommonTextBox_44.AllowDrop = true;
			this._txtCommonTextBox_44.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_44.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_44.Location = new System.Drawing.Point(673, 101);
			this._txtCommonTextBox_44.Name = "_txtCommonTextBox_44";
			this._txtCommonTextBox_44.Size = new System.Drawing.Size(152, 19);
			this._txtCommonTextBox_44.TabIndex = 115;
			this._txtCommonTextBox_44.Text = "";
			// this.this._txtCommonTextBox_44.Watermark = "";
			// this.this._txtCommonTextBox_44.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_44.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// System.Windows.Forms.Label3
			// 
			this.System.Windows.Forms.Label3.AllowDrop = true;
			this.System.Windows.Forms.Label3.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this.System.Windows.Forms.Label3.Caption = "Telephone";
			this.System.Windows.Forms.Label3.Location = new System.Drawing.Point(595, 124);
			this.System.Windows.Forms.Label3.mLabelId = 2268;
			this.System.Windows.Forms.Label3.Name = "System.Windows.Forms.Label3";
			this.System.Windows.Forms.Label3.Size = new System.Drawing.Size(50, 14);
			this.System.Windows.Forms.Label3.TabIndex = 126;
			// 
			// _txtCommonTextBox_43
			// 
			this._txtCommonTextBox_43.AllowDrop = true;
			this._txtCommonTextBox_43.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_43.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_43.Location = new System.Drawing.Point(673, 122);
			this._txtCommonTextBox_43.Name = "_txtCommonTextBox_43";
			this._txtCommonTextBox_43.Size = new System.Drawing.Size(152, 19);
			this._txtCommonTextBox_43.TabIndex = 116;
			this._txtCommonTextBox_43.Text = "";
			// this.this._txtCommonTextBox_43.Watermark = "";
			// this.this._txtCommonTextBox_43.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_43.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
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
			this.Shape2.Location = new System.Drawing.Point(8, 184);
			this.Shape2.Name = "Shape2";
			this.Shape2.Size = new System.Drawing.Size(835, 101);
			this.Shape2.Visible = true;
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
			this.Shape1.Location = new System.Drawing.Point(8, 10);
			this.Shape1.Name = "Shape1";
			this.Shape1.Size = new System.Drawing.Size(835, 161);
			this.Shape1.Visible = true;
			// 
			// _lblCommon_6
			// 
			this._lblCommon_6.AllowDrop = true;
			this._lblCommon_6.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_6.Text = "Name (Arabic)";
			this._lblCommon_6.Location = new System.Drawing.Point(6, 143);
			// this._lblCommon_6.mLabelId = 1054;
			this._lblCommon_6.Name = "_lblCommon_6";
			this._lblCommon_6.Size = new System.Drawing.Size(68, 13);
			this._lblCommon_6.TabIndex = 39;
			// 
			// _txtCommonTextBox_8
			// 
			this._txtCommonTextBox_8.AllowDrop = true;
			this._txtCommonTextBox_8.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_8.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_8.Location = new System.Drawing.Point(232, 140);
			// this._txtCommonTextBox_8.mArabicEnabled = true;
			this._txtCommonTextBox_8.Name = "_txtCommonTextBox_8";
			this._txtCommonTextBox_8.Size = new System.Drawing.Size(128, 19);
			this._txtCommonTextBox_8.TabIndex = 10;
			this._txtCommonTextBox_8.Text = "";
			// this.this._txtCommonTextBox_8.Watermark = "";
			// this.this._txtCommonTextBox_8.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_8.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _txtCommonTextBox_7
			// 
			this._txtCommonTextBox_7.AllowDrop = true;
			this._txtCommonTextBox_7.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_7.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_7.Location = new System.Drawing.Point(362, 140);
			// this._txtCommonTextBox_7.mArabicEnabled = true;
			this._txtCommonTextBox_7.Name = "_txtCommonTextBox_7";
			this._txtCommonTextBox_7.Size = new System.Drawing.Size(128, 19);
			this._txtCommonTextBox_7.TabIndex = 9;
			this._txtCommonTextBox_7.Text = "";
			// this.this._txtCommonTextBox_7.Watermark = "";
			// this.this._txtCommonTextBox_7.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_7.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _txtCommonTextBox_5
			// 
			this._txtCommonTextBox_5.AllowDrop = true;
			this._txtCommonTextBox_5.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_5.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_5.Location = new System.Drawing.Point(624, 140);
			// this._txtCommonTextBox_5.mArabicEnabled = true;
			this._txtCommonTextBox_5.Name = "_txtCommonTextBox_5";
			this._txtCommonTextBox_5.Size = new System.Drawing.Size(119, 19);
			this._txtCommonTextBox_5.TabIndex = 7;
			this._txtCommonTextBox_5.Text = "";
			// this.this._txtCommonTextBox_5.Watermark = "";
			// this.this._txtCommonTextBox_5.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_5.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _txtCommonTextBox_4
			// 
			this._txtCommonTextBox_4.AllowDrop = true;
			this._txtCommonTextBox_4.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_4.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_4.Location = new System.Drawing.Point(495, 102);
			this._txtCommonTextBox_4.Name = "_txtCommonTextBox_4";
			this._txtCommonTextBox_4.Size = new System.Drawing.Size(125, 19);
			this._txtCommonTextBox_4.TabIndex = 5;
			this._txtCommonTextBox_4.Text = "";
			// this.this._txtCommonTextBox_4.Watermark = "";
			// this.this._txtCommonTextBox_4.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_4.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _txtCommonTextBox_3
			// 
			this._txtCommonTextBox_3.AllowDrop = true;
			this._txtCommonTextBox_3.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_3.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_3.Location = new System.Drawing.Point(363, 102);
			this._txtCommonTextBox_3.Name = "_txtCommonTextBox_3";
			this._txtCommonTextBox_3.Size = new System.Drawing.Size(128, 19);
			this._txtCommonTextBox_3.TabIndex = 4;
			this._txtCommonTextBox_3.Text = "";
			// this.this._txtCommonTextBox_3.Watermark = "";
			// this.this._txtCommonTextBox_3.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_3.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _txtCommonTextBox_2
			// 
			this._txtCommonTextBox_2.AllowDrop = true;
			this._txtCommonTextBox_2.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_2.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_2.Location = new System.Drawing.Point(233, 102);
			this._txtCommonTextBox_2.Name = "_txtCommonTextBox_2";
			this._txtCommonTextBox_2.Size = new System.Drawing.Size(128, 19);
			this._txtCommonTextBox_2.TabIndex = 3;
			this._txtCommonTextBox_2.Text = "";
			// this.this._txtCommonTextBox_2.Watermark = "";
			// this.this._txtCommonTextBox_2.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_2.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _lblCommon_7
			// 
			this._lblCommon_7.AllowDrop = true;
			this._lblCommon_7.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_7.Text = "Fourth Name";
			this._lblCommon_7.Location = new System.Drawing.Point(524, 87);
			// this._lblCommon_7.mLabelId = 1975;
			this._lblCommon_7.Name = "_lblCommon_7";
			this._lblCommon_7.Size = new System.Drawing.Size(62, 13);
			this._lblCommon_7.TabIndex = 40;
			// 
			// _lblCommon_9
			// 
			this._lblCommon_9.AllowDrop = true;
			this._lblCommon_9.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_9.Text = "Second Name";
			this._lblCommon_9.Location = new System.Drawing.Point(274, 88);
			// this._lblCommon_9.mLabelId = 1976;
			this._lblCommon_9.Name = "_lblCommon_9";
			this._lblCommon_9.Size = new System.Drawing.Size(65, 13);
			this._lblCommon_9.TabIndex = 41;
			// 
			// _lblCommon_10
			// 
			this._lblCommon_10.AllowDrop = true;
			this._lblCommon_10.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_10.Text = "Name (English)";
			this._lblCommon_10.Location = new System.Drawing.Point(6, 105);
			// this._lblCommon_10.mLabelId = 1053;
			this._lblCommon_10.Name = "_lblCommon_10";
			this._lblCommon_10.Size = new System.Drawing.Size(71, 13);
			this._lblCommon_10.TabIndex = 42;
			// 
			// _lblCommon_4
			// 
			this._lblCommon_4.AllowDrop = true;
			this._lblCommon_4.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_4.Text = "First Name";
			this._lblCommon_4.Location = new System.Drawing.Point(154, 88);
			// this._lblCommon_4.mLabelId = 1974;
			this._lblCommon_4.Name = "_lblCommon_4";
			this._lblCommon_4.Size = new System.Drawing.Size(51, 13);
			this._lblCommon_4.TabIndex = 43;
			// 
			// _txtCommonTextBox_1
			// 
			this._txtCommonTextBox_1.AllowDrop = true;
			this._txtCommonTextBox_1.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_1.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_1.Location = new System.Drawing.Point(105, 102);
			this._txtCommonTextBox_1.Name = "_txtCommonTextBox_1";
			this._txtCommonTextBox_1.Size = new System.Drawing.Size(125, 19);
			this._txtCommonTextBox_1.TabIndex = 2;
			this._txtCommonTextBox_1.Text = "";
			// this.this._txtCommonTextBox_1.Watermark = "";
			// this.this._txtCommonTextBox_1.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_1.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _lblCommon_50
			// 
			this._lblCommon_50.AllowDrop = true;
			this._lblCommon_50.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_50.Text = "Fourth Name";
			this._lblCommon_50.Location = new System.Drawing.Point(273, 126);
			// this._lblCommon_50.mLabelId = 1975;
			this._lblCommon_50.Name = "_lblCommon_50";
			this._lblCommon_50.Size = new System.Drawing.Size(62, 13);
			this._lblCommon_50.TabIndex = 44;
			// 
			// _lblCommon_51
			// 
			this._lblCommon_51.AllowDrop = true;
			this._lblCommon_51.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_51.Text = "Third Name";
			this._lblCommon_51.Location = new System.Drawing.Point(400, 126);
			// this._lblCommon_51.mLabelId = 1977;
			this._lblCommon_51.Name = "_lblCommon_51";
			this._lblCommon_51.Size = new System.Drawing.Size(54, 13);
			this._lblCommon_51.TabIndex = 45;
			// 
			// _lblCommon_53
			// 
			this._lblCommon_53.AllowDrop = true;
			this._lblCommon_53.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_53.Text = "First Name";
			this._lblCommon_53.Location = new System.Drawing.Point(657, 126);
			// this._lblCommon_53.mLabelId = 1974;
			this._lblCommon_53.Name = "_lblCommon_53";
			this._lblCommon_53.Size = new System.Drawing.Size(51, 13);
			this._lblCommon_53.TabIndex = 46;
			// 
			// _lblCommon_113
			// 
			this._lblCommon_113.AllowDrop = true;
			this._lblCommon_113.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_113.Text = "Employee Code";
			this._lblCommon_113.Location = new System.Drawing.Point(6, 67);
			// this._lblCommon_113.mLabelId = 236;
			this._lblCommon_113.Name = "_lblCommon_113";
			this._lblCommon_113.Size = new System.Drawing.Size(74, 14);
			this._lblCommon_113.TabIndex = 48;
			// 
			// _txtCommonTextBox_0
			// 
			this._txtCommonTextBox_0.AllowDrop = true;
			this._txtCommonTextBox_0.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_0.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_0.Location = new System.Drawing.Point(106, 64);
			this._txtCommonTextBox_0.MaxLength = 20;
			// this._txtCommonTextBox_0.mDropDownType = System.Windows.Forms.TextBox.DropDownTypes.ddtNextNumber;
			this._txtCommonTextBox_0.Name = "_txtCommonTextBox_0";
			// this._txtCommonTextBox_0.ShowButton = true;
			this._txtCommonTextBox_0.Size = new System.Drawing.Size(170, 19);
			this._txtCommonTextBox_0.TabIndex = 1;
			this._txtCommonTextBox_0.Text = "";
			// this.this._txtCommonTextBox_0.Watermark = "";
			// this.this._txtCommonTextBox_0.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_0.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _txtDisplayLabel_14
			// 
			this._txtDisplayLabel_14.AllowDrop = true;
			this._txtDisplayLabel_14.Location = new System.Drawing.Point(106, 162);
			this._txtDisplayLabel_14.Name = "_txtDisplayLabel_14";
			this._txtDisplayLabel_14.Size = new System.Drawing.Size(638, 19);
			this._txtDisplayLabel_14.TabIndex = 169;
			this._txtDisplayLabel_14.TabStop = false;
			// 
			// _txtDisplayLabel_16
			// 
			this._txtDisplayLabel_16.AllowDrop = true;
			this._txtDisplayLabel_16.Location = new System.Drawing.Point(106, 183);
			this._txtDisplayLabel_16.Name = "_txtDisplayLabel_16";
			this._txtDisplayLabel_16.Size = new System.Drawing.Size(638, 19);
			this._txtDisplayLabel_16.TabIndex = 170;
			this._txtDisplayLabel_16.TabStop = false;
			// 
			// _lblCommon_63
			// 
			this._lblCommon_63.AllowDrop = true;
			this._lblCommon_63.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_63.Text = "Emp Full Name ENG";
			this._lblCommon_63.Location = new System.Drawing.Point(6, 164);
			// this._lblCommon_63.mLabelId = 2266;
			this._lblCommon_63.Name = "_lblCommon_63";
			this._lblCommon_63.Size = new System.Drawing.Size(93, 14);
			this._lblCommon_63.TabIndex = 171;
			// 
			// _lblCommon_64
			// 
			this._lblCommon_64.AllowDrop = true;
			this._lblCommon_64.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_64.Text = "Emp Full Name ARB";
			this._lblCommon_64.Location = new System.Drawing.Point(6, 185);
			// this._lblCommon_64.mLabelId = 2267;
			this._lblCommon_64.Name = "_lblCommon_64";
			this._lblCommon_64.Size = new System.Drawing.Size(94, 14);
			this._lblCommon_64.TabIndex = 172;
			// 
			// _txtCommonTextBox_6
			// 
			this._txtCommonTextBox_6.AllowDrop = true;
			this._txtCommonTextBox_6.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_6.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_6.Location = new System.Drawing.Point(492, 140);
			// this._txtCommonTextBox_6.mArabicEnabled = true;
			this._txtCommonTextBox_6.Name = "_txtCommonTextBox_6";
			this._txtCommonTextBox_6.Size = new System.Drawing.Size(128, 19);
			this._txtCommonTextBox_6.TabIndex = 8;
			this._txtCommonTextBox_6.Text = "";
			// this.this._txtCommonTextBox_6.Watermark = "";
			// this.this._txtCommonTextBox_6.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_6.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _lblCommon_8
			// 
			this._lblCommon_8.AllowDrop = true;
			this._lblCommon_8.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_8.Text = "Third Name";
			this._lblCommon_8.Location = new System.Drawing.Point(400, 88);
			// this._lblCommon_8.mLabelId = 1977;
			this._lblCommon_8.Name = "_lblCommon_8";
			this._lblCommon_8.Size = new System.Drawing.Size(54, 13);
			this._lblCommon_8.TabIndex = 173;
			// 
			// _lblCommon_52
			// 
			this._lblCommon_52.AllowDrop = true;
			this._lblCommon_52.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_52.Text = "Second Name";
			this._lblCommon_52.Location = new System.Drawing.Point(525, 126);
			// this._lblCommon_52.mLabelId = 1976;
			this._lblCommon_52.Name = "_lblCommon_52";
			this._lblCommon_52.Size = new System.Drawing.Size(65, 13);
			this._lblCommon_52.TabIndex = 174;
			// 
			// _txtCommonTextBox_64
			// 
			this._txtCommonTextBox_64.AllowDrop = true;
			this._txtCommonTextBox_64.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_64.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_64.Location = new System.Drawing.Point(624, 102);
			this._txtCommonTextBox_64.Name = "_txtCommonTextBox_64";
			this._txtCommonTextBox_64.Size = new System.Drawing.Size(119, 19);
			this._txtCommonTextBox_64.TabIndex = 6;
			this._txtCommonTextBox_64.Text = "";
			// this.this._txtCommonTextBox_64.Watermark = "";
			// this.this._txtCommonTextBox_64.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_64.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _lblCommon_65
			// 
			this._lblCommon_65.AllowDrop = true;
			this._lblCommon_65.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_65.Text = "Fifth Name";
			this._lblCommon_65.Location = new System.Drawing.Point(654, 87);
			// this._lblCommon_65.mLabelId = 2219;
			this._lblCommon_65.Name = "_lblCommon_65";
			this._lblCommon_65.Size = new System.Drawing.Size(52, 13);
			this._lblCommon_65.TabIndex = 175;
			// 
			// _txtCommonTextBox_66
			// 
			this._txtCommonTextBox_66.AllowDrop = true;
			this._txtCommonTextBox_66.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_66.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_66.Location = new System.Drawing.Point(105, 140);
			this._txtCommonTextBox_66.Name = "_txtCommonTextBox_66";
			this._txtCommonTextBox_66.Size = new System.Drawing.Size(125, 19);
			this._txtCommonTextBox_66.TabIndex = 11;
			this._txtCommonTextBox_66.Text = "";
			// this.this._txtCommonTextBox_66.Watermark = "";
			// this.this._txtCommonTextBox_66.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_66.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _lblCommon_66
			// 
			this._lblCommon_66.AllowDrop = true;
			this._lblCommon_66.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_66.Text = "Fifth Name";
			this._lblCommon_66.Location = new System.Drawing.Point(154, 126);
			// this._lblCommon_66.mLabelId = 2219;
			this._lblCommon_66.Name = "_lblCommon_66";
			this._lblCommon_66.Size = new System.Drawing.Size(52, 13);
			this._lblCommon_66.TabIndex = 176;
			// 
			// frmPayEmployeeWazaraDetails
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.ClientSize = new System.Drawing.Size(862, 530);
			this.Controls.Add(this.cmdContract);
			this.Controls.Add(this.cmdTransfer);
			this.Controls.Add(this.cmdRenewal);
			this.Controls.Add(this.cmdVisaApplication);
			this.Controls.Add(this.cmdPullMasterData);
			this.Controls.Add(this.tabEmployee);
			this.Controls.Add(this._lblCommon_6);
			this.Controls.Add(this._txtCommonTextBox_8);
			this.Controls.Add(this._txtCommonTextBox_7);
			this.Controls.Add(this._txtCommonTextBox_5);
			this.Controls.Add(this._txtCommonTextBox_4);
			this.Controls.Add(this._txtCommonTextBox_3);
			this.Controls.Add(this._txtCommonTextBox_2);
			this.Controls.Add(this._lblCommon_7);
			this.Controls.Add(this._lblCommon_9);
			this.Controls.Add(this._lblCommon_10);
			this.Controls.Add(this._lblCommon_4);
			this.Controls.Add(this._txtCommonTextBox_1);
			this.Controls.Add(this._lblCommon_50);
			this.Controls.Add(this._lblCommon_51);
			this.Controls.Add(this._lblCommon_53);
			this.Controls.Add(this._lblCommon_113);
			this.Controls.Add(this._txtCommonTextBox_0);
			this.Controls.Add(this._txtDisplayLabel_14);
			this.Controls.Add(this._txtDisplayLabel_16);
			this.Controls.Add(this._lblCommon_63);
			this.Controls.Add(this._lblCommon_64);
			this.Controls.Add(this._txtCommonTextBox_6);
			this.Controls.Add(this._lblCommon_8);
			this.Controls.Add(this._lblCommon_52);
			this.Controls.Add(this._txtCommonTextBox_64);
			this.Controls.Add(this._lblCommon_65);
			this.Controls.Add(this._txtCommonTextBox_66);
			this.Controls.Add(this._lblCommon_66);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			//this.Icon = (System.Drawing.Icon) resources.GetObject("frmPayEmployeeWazaraDetails.Icon");
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(45, 116);
			this.MaximizeBox = true;
			this.MinimizeBox = true;
			this.Name = "frmPayEmployeeWazaraDetails";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Employee Wazara Details";
			// this.Activated += new System.EventHandler(this.frmPayEmployeeWazaraDetails_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
			// this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
			//((System.ComponentModel.ISupportInitialize) this.tabEmployee).EndInit();
			this.tabEmployee.ResumeLayout(false);
			this.Frame1.ResumeLayout(false);
			this._fraEmployeeInformation_0.ResumeLayout(false);
			this._fraEmployeeInformation_4.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		void ReLoadForm(bool addEvents)
		{
			InitializetxtDisplayLabel();
			InitializetxtCommonTextBox();
			InitializetxtCommonNumber();
			InitializelblCommonLabel();
			InitializelblCommon();
			InitializefraEmployeeInformation();
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
			this.txtDisplayLabel = new System.Windows.Forms.Label[17];
			this.txtDisplayLabel[7] = _txtDisplayLabel_7;
			this.txtDisplayLabel[10] = _txtDisplayLabel_10;
			this.txtDisplayLabel[9] = _txtDisplayLabel_9;
			this.txtDisplayLabel[1] = _txtDisplayLabel_1;
			this.txtDisplayLabel[14] = _txtDisplayLabel_14;
			this.txtDisplayLabel[16] = _txtDisplayLabel_16;
		}
		void InitializetxtCommonTextBox()
		{
			this.txtCommonTextBox = new System.Windows.Forms.TextBox[67];
			this.txtCommonTextBox[16] = _txtCommonTextBox_16;
			this.txtCommonTextBox[17] = _txtCommonTextBox_17;
			this.txtCommonTextBox[19] = _txtCommonTextBox_19;
			this.txtCommonTextBox[21] = _txtCommonTextBox_21;
			this.txtCommonTextBox[20] = _txtCommonTextBox_20;
			this.txtCommonTextBox[22] = _txtCommonTextBox_22;
			this.txtCommonTextBox[55] = _txtCommonTextBox_55;
			this.txtCommonTextBox[56] = _txtCommonTextBox_56;
			this.txtCommonTextBox[57] = _txtCommonTextBox_57;
			this.txtCommonTextBox[58] = _txtCommonTextBox_58;
			this.txtCommonTextBox[59] = _txtCommonTextBox_59;
			this.txtCommonTextBox[60] = _txtCommonTextBox_60;
			this.txtCommonTextBox[61] = _txtCommonTextBox_61;
			this.txtCommonTextBox[62] = _txtCommonTextBox_62;
			this.txtCommonTextBox[65] = _txtCommonTextBox_65;
			this.txtCommonTextBox[63] = _txtCommonTextBox_63;
			this.txtCommonTextBox[12] = _txtCommonTextBox_12;
			this.txtCommonTextBox[13] = _txtCommonTextBox_13;
			this.txtCommonTextBox[14] = _txtCommonTextBox_14;
			this.txtCommonTextBox[15] = _txtCommonTextBox_15;
			this.txtCommonTextBox[10] = _txtCommonTextBox_10;
			this.txtCommonTextBox[11] = _txtCommonTextBox_11;
			this.txtCommonTextBox[9] = _txtCommonTextBox_9;
			this.txtCommonTextBox[46] = _txtCommonTextBox_46;
			this.txtCommonTextBox[47] = _txtCommonTextBox_47;
			this.txtCommonTextBox[52] = _txtCommonTextBox_52;
			this.txtCommonTextBox[51] = _txtCommonTextBox_51;
			this.txtCommonTextBox[48] = _txtCommonTextBox_48;
			this.txtCommonTextBox[49] = _txtCommonTextBox_49;
			this.txtCommonTextBox[50] = _txtCommonTextBox_50;
			this.txtCommonTextBox[53] = _txtCommonTextBox_53;
			this.txtCommonTextBox[18] = _txtCommonTextBox_18;
			this.txtCommonTextBox[23] = _txtCommonTextBox_23;
			this.txtCommonTextBox[54] = _txtCommonTextBox_54;
			this.txtCommonTextBox[45] = _txtCommonTextBox_45;
			this.txtCommonTextBox[29] = _txtCommonTextBox_29;
			this.txtCommonTextBox[28] = _txtCommonTextBox_28;
			this.txtCommonTextBox[27] = _txtCommonTextBox_27;
			this.txtCommonTextBox[26] = _txtCommonTextBox_26;
			this.txtCommonTextBox[25] = _txtCommonTextBox_25;
			this.txtCommonTextBox[24] = _txtCommonTextBox_24;
			this.txtCommonTextBox[30] = _txtCommonTextBox_30;
			this.txtCommonTextBox[31] = _txtCommonTextBox_31;
			this.txtCommonTextBox[32] = _txtCommonTextBox_32;
			this.txtCommonTextBox[33] = _txtCommonTextBox_33;
			this.txtCommonTextBox[34] = _txtCommonTextBox_34;
			this.txtCommonTextBox[35] = _txtCommonTextBox_35;
			this.txtCommonTextBox[36] = _txtCommonTextBox_36;
			this.txtCommonTextBox[37] = _txtCommonTextBox_37;
			this.txtCommonTextBox[38] = _txtCommonTextBox_38;
			this.txtCommonTextBox[39] = _txtCommonTextBox_39;
			this.txtCommonTextBox[40] = _txtCommonTextBox_40;
			this.txtCommonTextBox[41] = _txtCommonTextBox_41;
			this.txtCommonTextBox[42] = _txtCommonTextBox_42;
			this.txtCommonTextBox[44] = _txtCommonTextBox_44;
			this.txtCommonTextBox[43] = _txtCommonTextBox_43;
			this.txtCommonTextBox[8] = _txtCommonTextBox_8;
			this.txtCommonTextBox[7] = _txtCommonTextBox_7;
			this.txtCommonTextBox[5] = _txtCommonTextBox_5;
			this.txtCommonTextBox[4] = _txtCommonTextBox_4;
			this.txtCommonTextBox[3] = _txtCommonTextBox_3;
			this.txtCommonTextBox[2] = _txtCommonTextBox_2;
			this.txtCommonTextBox[1] = _txtCommonTextBox_1;
			this.txtCommonTextBox[0] = _txtCommonTextBox_0;
			this.txtCommonTextBox[6] = _txtCommonTextBox_6;
			this.txtCommonTextBox[64] = _txtCommonTextBox_64;
			this.txtCommonTextBox[66] = _txtCommonTextBox_66;
		}
		void InitializetxtCommonNumber()
		{
			this.txtCommonNumber = new System.Windows.Forms.TextBox[2];
			this.txtCommonNumber[1] = _txtCommonNumber_1;
			this.txtCommonNumber[0] = _txtCommonNumber_0;
		}
		void InitializelblCommonLabel()
		{
			this.lblCommonLabel = new System.Windows.Forms.Label[19];
			this.lblCommonLabel[6] = _lblCommonLabel_6;
			this.lblCommonLabel[17] = _lblCommonLabel_17;
			this.lblCommonLabel[0] = _lblCommonLabel_0;
			this.lblCommonLabel[1] = _lblCommonLabel_1;
			this.lblCommonLabel[2] = _lblCommonLabel_2;
			this.lblCommonLabel[3] = _lblCommonLabel_3;
			this.lblCommonLabel[18] = _lblCommonLabel_18;
		}
		void InitializelblCommon()
		{
			this.lblCommon = new System.Windows.Forms.Label[116];
			this.lblCommon[0] = _lblCommon_0;
			this.lblCommon[30] = _lblCommon_30;
			this.lblCommon[38] = _lblCommon_38;
			this.lblCommon[39] = _lblCommon_39;
			this.lblCommon[43] = _lblCommon_43;
			this.lblCommon[23] = _lblCommon_23;
			this.lblCommon[42] = _lblCommon_42;
			this.lblCommon[44] = _lblCommon_44;
			this.lblCommon[45] = _lblCommon_45;
			this.lblCommon[46] = _lblCommon_46;
			this.lblCommon[49] = _lblCommon_49;
			this.lblCommon[54] = _lblCommon_54;
			this.lblCommon[55] = _lblCommon_55;
			this.lblCommon[56] = _lblCommon_56;
			this.lblCommon[57] = _lblCommon_57;
			this.lblCommon[58] = _lblCommon_58;
			this.lblCommon[59] = _lblCommon_59;
			this.lblCommon[61] = _lblCommon_61;
			this.lblCommon[62] = _lblCommon_62;
			this.lblCommon[114] = _lblCommon_114;
			this.lblCommon[27] = _lblCommon_27;
			this.lblCommon[28] = _lblCommon_28;
			this.lblCommon[29] = _lblCommon_29;
			this.lblCommon[31] = _lblCommon_31;
			this.lblCommon[115] = _lblCommon_115;
			this.lblCommon[34] = _lblCommon_34;
			this.lblCommon[35] = _lblCommon_35;
			this.lblCommon[112] = _lblCommon_112;
			this.lblCommon[41] = _lblCommon_41;
			this.lblCommon[40] = _lblCommon_40;
			this.lblCommon[103] = _lblCommon_103;
			this.lblCommon[32] = _lblCommon_32;
			this.lblCommon[33] = _lblCommon_33;
			this.lblCommon[108] = _lblCommon_108;
			this.lblCommon[37] = _lblCommon_37;
			this.lblCommon[60] = _lblCommon_60;
			this.lblCommon[1] = _lblCommon_1;
			this.lblCommon[2] = _lblCommon_2;
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
			this.lblCommon[47] = _lblCommon_47;
			this.lblCommon[48] = _lblCommon_48;
			this.lblCommon[36] = _lblCommon_36;
			this.lblCommon[6] = _lblCommon_6;
			this.lblCommon[7] = _lblCommon_7;
			this.lblCommon[9] = _lblCommon_9;
			this.lblCommon[10] = _lblCommon_10;
			this.lblCommon[4] = _lblCommon_4;
			this.lblCommon[50] = _lblCommon_50;
			this.lblCommon[51] = _lblCommon_51;
			this.lblCommon[53] = _lblCommon_53;
			this.lblCommon[113] = _lblCommon_113;
			this.lblCommon[63] = _lblCommon_63;
			this.lblCommon[64] = _lblCommon_64;
			this.lblCommon[8] = _lblCommon_8;
			this.lblCommon[52] = _lblCommon_52;
			this.lblCommon[65] = _lblCommon_65;
			this.lblCommon[66] = _lblCommon_66;
		}
		void InitializefraEmployeeInformation()
		{
			this.fraEmployeeInformation = new System.Windows.Forms.Panel[5];
			this.fraEmployeeInformation[0] = _fraEmployeeInformation_0;
			this.fraEmployeeInformation[4] = _fraEmployeeInformation_4;
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