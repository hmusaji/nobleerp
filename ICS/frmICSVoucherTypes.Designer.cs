
namespace Xtreme
{
	partial class frmICSVoucherTypes
	{

		#region "Upgrade Support "
		private static frmICSVoucherTypes m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmICSVoucherTypes DefInstance
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
		public static frmICSVoucherTypes CreateInstance()
		{
			frmICSVoucherTypes theInstance = new frmICSVoucherTypes();
			
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
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "UCOkCancel1", "Column_0_grdVoucherParentDetails", "grdVoucherParentDetails", "Column_0_cmbParentsList", "Column_1_cmbParentsList", "cmbParentsList", "_fraCommon_23", "cmdParentDetails", "_optCommonAffectType_11", "_optCommonAffectType_10", "_optCommonAffectType_9", "_chkCommon_75", "_chkCommon_121", "_chkCommon_135", "_chkCommon_134", "_chkCommon_117", "_chkCommon_118", "_chkCommon_119", "_chkCommon_116", "_chkCommon_120", "_chkCommon_77", "_fraCommon_22", "_chkCommon_82", "_chkCommon_80", "_chkCommon_78", "_fraCommon_21", "_chkCommon_81", "_chkCommon_79", "_chkCommon_76", "_chkCommon_74", "_lblCommon_18", "_lblCommon_19", "_lblCommon_20", "_lblCommon_21", "_lblCommon_22", "_lblCommon_23", "_txtCommon_32", "_txtCommon_31", "_txtCommonLabel_11", "_txtCommonLabel_12", "_txtCommon_28", "_txtCommon_29", "_txtCommon_30", "_txtCommon_33", "_fraCommon_18", "_lblCommon_43", "_txtCommonLabel_29", "_lblCommon_34", "_txtCommonLabel_0", "_txtCommon_17", "_txtCommon_15", "_fraCommon_1", "dlgColorColor", "dlgColor", "_chkCommon_92", "_txtCommonLabel_6", "_lblCommon_40", "_txtCommon_16", "_fraCommon_3", "_lblCommon_33", "_cmbCommon_2", "_lblCommon_38", "_lblCommon_39", "_lblCommon_41", "_lblCommon_42", "_lblCommon_37", "_txtCommon_23", "_txtCommon_24", "_txtCommon_25", "_txtCommon_26", "_txtCommon_27", "_lblCommon_0", "_txtCommon_34", "_txtCommon_35", "_lblCommon_13", "_txtCommon_11", "_lblCommon_16", "_txtCommon_14", "_lblCommon_31", "_txtCommon_36", "_lblCommon_45", "_txtCommon_37", "_fraCommon_10", "_chkCommon_73", "_chkCommon_108", "_txtCommonLabel_17", "_txtCommonLabel_19", "_txtCommonLabel_20", "_txtCommonLabel_22", "_lblCommon_28", "_lblCommon_29", "_lblCommon_30", "_lblCommon_36", "_fraCommon_20", "_fraCommon_9", "_chkCommon_137", "_chkCommon_130", "_chkCommon_129", "_chkCommon_128", "_chkCommon_125", "_chkCommon_35", "_chkCommon_110", "_chkCommon_109", "_chkCommon_107", "_chkCommon_106", "_chkCommon_105", "_chkCommon_104", "_chkCommon_101", "_chkCommon_100", "_chkCommon_99", "_chkCommon_98", "_chkCommon_96", "_chkCommon_91", "_chkCommon_90", "_chkCommon_89", "_chkCommon_88", "_chkCommon_87", "_chkCommon_86", "_chkCommon_84", "_lblCommon_35", "_cmbCommon_1", "_lblCommon_32", "_txtCommon_19", "_lblCommon_46", "_txtCommon_38", "_lblCommon_48", "_txtCommon_40", "_fraCommon_17", "_fraCommon_8", "_chkCommon_66", "_txtCommon_12", "_chkCommon_65", "_chkCommon_64", "_chkCommon_63", "_chkCommon_62", "_chkCommon_61", "_optCommonQtyEffect_3", "_optCommonQtyEffect_2", "_lblCommon_12", "_txtCommon_10", "_lblCommon_14", "_lblCommon_15", "_txtCommon_13", "_txtCommonLabel_4", "Column_0_cmbPrintList", "Column_1_cmbPrintList", "cmbPrintList", "Column_0_grdPrintTask", "Column_1_grdPrintTask", "grdPrintTask", "_fraCommon_15", "_fraCommon_7", "_lblCommon_24", "_lblCommon_25", "_lblCommon_26", "_lblCommon_27", "_txtCommonLabel_14", "_txtCommonLabel_15", "_txtCommonLabel_16", "_txtCommonLabel_13", "_txtCommon_18", "_txtCommon_20", "_txtCommon_21", "_txtCommon_22", "_fraCommon_19", "_chkCommon_94", "_chkCommon_95", "_chkCommon_97", "_fraCommon_25", "_chkCommon_127", "_chkCommon_60", "_chkCommon_59", "_chkCommon_58", "_chkCommon_57", "_chkCommon_56", "_chkCommon_55", "_chkCommon_54", "_fraCommon_16", "_chkCommon_53", "_chkCommon_52", "_chkCommon_51", "_chkCommon_50", "_chkCommon_49", "_chkCommon_48", "_fraCommon_14", "_fraCommon_6", "_chkCommon_133", "_chkCommon_123", "_chkCommon_115", "_chkCommon_71", "_chkCommon_114", "_chkCommon_111", "_chkCommon_8", "_chkCommon_22", "_chkCommon_23", "_chkCommon_26", "_chkCommon_27", "_chkCommon_28", "_chkCommon_30", "_chkCommon_31", "_chkCommon_32", "_chkCommon_40", "_chkCommon_67", "_chkCommon_70", "_fraCommon_11", "_chkCommon_136", "_chkCommon_72", "_chkCommon_12", "_chkCommon_11", "_chkCommon_10", "_chkCommon_39", "_chkCommon_38", "_chkCommon_37", "_chkCommon_34", "_chkCommon_33", "_chkCommon_29", "_chkCommon_25", "_chkCommon_24", "_chkCommon_15", "_chkCommon_9", "_chkCommon_36", "_chkCommon_85", "_chkCommon_83", "_chkCommon_132", "_chkCommon_126", "_chkCommon_103", "_chkCommon_20", "_chkCommon_113", "_chkCommon_112", "_chkCommon_13", "_chkCommon_14", "_chkCommon_16", "_chkCommon_19", "_chkCommon_21", "_chkCommon_68", "_chkCommon_69", "_fraCommon_12", "_chkCommon_18", "_chkCommon_17", "_chkCommon_41", "_chkCommon_42", "_chkCommon_43", "_chkCommon_44", "_chkCommon_45", "_chkCommon_46", "_chkCommon_47", "_fraCommon_13", "_fraCommon_5", "_chkCommon_102", "_chkCommon_124", "_chkCommon_7", "_lblCommon_47", "_txtCommon_39", "_fraCommon_24", "_chkCommon_6", "_chkCommon_131", "_chkCommon_122", "_chkCommon_93", "_chkCommon_0", "_chkCommon_1", "_chkCommon_2", "_chkCommon_3", "_chkCommon_5", "_optCommonAffectType_8", "_optCommonAffectType_7", "_optCommonAffectType_2", "_optCommonAffectType_3", "_optCommonAffectType_4", "_optCommonAffectType_5", "_optCommonAffectType_6", "_optCommonAffectType_1", "_optCommonAffectType_0", "_fraCommon_2", "_optCommonQtyEffect_1", "_optCommonQtyEffect_0", "_fraCommon_4", "_chkCommon_4", "_lblCommon_8", "_lblCommon_9", "_lblCommon_10", "_lblCommon_11", "_txtCommonLabel_1", "_lblCommon_17", "_txtCommonLabel_3", "_txtCommon_7", "_txtCommon_8", "_txtCommonLabel_2", "_txtCommonLabel_21", "_txtCommon_6", "_txtCommon_9", "_cmbCommon_0", "_fraCommon_0", "tabVoucherDetails", "_txtCommon_1", "_txtCommon_2", "_txtCommon_0", "_lblCommon_1", "_lblCommon_6", "_lblCommon_7", "_lblCommon_2", "_txtCommon_3", "_txtCommon_4", "_txtCommon_5", "_lblCommon_4", "_lblCommon_5", "_lblCommon_44", "chkCommon", "cmbCommon", "fraCommon", "lblCommon", "optCommonAffectType", "optCommonQtyEffect", "txtCommon", "txtCommonLabel"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public UCOkCancel UCOkCancel1;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_0_grdVoucherParentDetails;
		public C1.Win.C1TrueDBGrid.C1TrueDBGrid grdVoucherParentDetails;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_0_cmbParentsList;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_1_cmbParentsList;
		public C1.Win.C1TrueDBGrid.C1TrueDBDropdown cmbParentsList;
		private System.Windows.Forms.GroupBox _fraCommon_23;
		public System.Windows.Forms.Button cmdParentDetails;
		private System.Windows.Forms.RadioButton _optCommonAffectType_11;
		private System.Windows.Forms.RadioButton _optCommonAffectType_10;
		private System.Windows.Forms.RadioButton _optCommonAffectType_9;
		private System.Windows.Forms.CheckBox _chkCommon_75;
		private System.Windows.Forms.CheckBox _chkCommon_121;
		private System.Windows.Forms.CheckBox _chkCommon_135;
		private System.Windows.Forms.CheckBox _chkCommon_134;
		private System.Windows.Forms.CheckBox _chkCommon_117;
		private System.Windows.Forms.CheckBox _chkCommon_118;
		private System.Windows.Forms.CheckBox _chkCommon_119;
		private System.Windows.Forms.CheckBox _chkCommon_116;
		private System.Windows.Forms.CheckBox _chkCommon_120;
		private System.Windows.Forms.CheckBox _chkCommon_77;
		private System.Windows.Forms.GroupBox _fraCommon_22;
		private System.Windows.Forms.CheckBox _chkCommon_82;
		private System.Windows.Forms.CheckBox _chkCommon_80;
		private System.Windows.Forms.CheckBox _chkCommon_78;
		private System.Windows.Forms.GroupBox _fraCommon_21;
		private System.Windows.Forms.CheckBox _chkCommon_81;
		private System.Windows.Forms.CheckBox _chkCommon_79;
		private System.Windows.Forms.CheckBox _chkCommon_76;
		private System.Windows.Forms.CheckBox _chkCommon_74;
		private System.Windows.Forms.Label _lblCommon_18;
		private System.Windows.Forms.Label _lblCommon_19;
		private System.Windows.Forms.Label _lblCommon_20;
		private System.Windows.Forms.Label _lblCommon_21;
		private System.Windows.Forms.Label _lblCommon_22;
		private System.Windows.Forms.Label _lblCommon_23;
		private System.Windows.Forms.TextBox _txtCommon_32;
		private System.Windows.Forms.TextBox _txtCommon_31;
		private System.Windows.Forms.Label _txtCommonLabel_11;
		private System.Windows.Forms.Label _txtCommonLabel_12;
		private System.Windows.Forms.TextBox _txtCommon_28;
		private System.Windows.Forms.TextBox _txtCommon_29;
		private System.Windows.Forms.TextBox _txtCommon_30;
		private System.Windows.Forms.TextBox _txtCommon_33;
		private System.Windows.Forms.GroupBox _fraCommon_18;
		private System.Windows.Forms.Label _lblCommon_43;
		private System.Windows.Forms.Label _txtCommonLabel_29;
		private System.Windows.Forms.Label _lblCommon_34;
		private System.Windows.Forms.Label _txtCommonLabel_0;
		private System.Windows.Forms.TextBox _txtCommon_17;
		private System.Windows.Forms.TextBox _txtCommon_15;
		private System.Windows.Forms.GroupBox _fraCommon_1;
		public System.Windows.Forms.ColorDialog dlgColorColor;
		public UpgradeStubs.AxMSComDlg_AxCommonDialog dlgColor;
		private System.Windows.Forms.CheckBox _chkCommon_92;
		private System.Windows.Forms.Label _txtCommonLabel_6;
		private System.Windows.Forms.Label _lblCommon_40;
		private System.Windows.Forms.TextBox _txtCommon_16;
		private System.Windows.Forms.GroupBox _fraCommon_3;
		private System.Windows.Forms.Label _lblCommon_33;
		private System.Windows.Forms.ComboBox _cmbCommon_2;
		private System.Windows.Forms.Label _lblCommon_38;
		private System.Windows.Forms.Label _lblCommon_39;
		private System.Windows.Forms.Label _lblCommon_41;
		private System.Windows.Forms.Label _lblCommon_42;
		private System.Windows.Forms.Label _lblCommon_37;
		private System.Windows.Forms.TextBox _txtCommon_23;
		private System.Windows.Forms.TextBox _txtCommon_24;
		private System.Windows.Forms.TextBox _txtCommon_25;
		private System.Windows.Forms.TextBox _txtCommon_26;
		private System.Windows.Forms.TextBox _txtCommon_27;
		private System.Windows.Forms.Label _lblCommon_0;
		private System.Windows.Forms.TextBox _txtCommon_34;
		private System.Windows.Forms.TextBox _txtCommon_35;
		private System.Windows.Forms.Label _lblCommon_13;
		private System.Windows.Forms.TextBox _txtCommon_11;
		private System.Windows.Forms.Label _lblCommon_16;
		private System.Windows.Forms.TextBox _txtCommon_14;
		private System.Windows.Forms.Label _lblCommon_31;
		private System.Windows.Forms.TextBox _txtCommon_36;
		private System.Windows.Forms.Label _lblCommon_45;
		private System.Windows.Forms.TextBox _txtCommon_37;
		private System.Windows.Forms.GroupBox _fraCommon_10;
		private System.Windows.Forms.CheckBox _chkCommon_73;
		private System.Windows.Forms.CheckBox _chkCommon_108;
		private System.Windows.Forms.Label _txtCommonLabel_17;
		private System.Windows.Forms.Label _txtCommonLabel_19;
		private System.Windows.Forms.Label _txtCommonLabel_20;
		private System.Windows.Forms.Label _txtCommonLabel_22;
		private System.Windows.Forms.Label _lblCommon_28;
		private System.Windows.Forms.Label _lblCommon_29;
		private System.Windows.Forms.Label _lblCommon_30;
		private System.Windows.Forms.Label _lblCommon_36;
		private System.Windows.Forms.GroupBox _fraCommon_20;
		private System.Windows.Forms.GroupBox _fraCommon_9;
		private System.Windows.Forms.CheckBox _chkCommon_137;
		private System.Windows.Forms.CheckBox _chkCommon_130;
		private System.Windows.Forms.CheckBox _chkCommon_129;
		private System.Windows.Forms.CheckBox _chkCommon_128;
		private System.Windows.Forms.CheckBox _chkCommon_125;
		private System.Windows.Forms.CheckBox _chkCommon_35;
		private System.Windows.Forms.CheckBox _chkCommon_110;
		private System.Windows.Forms.CheckBox _chkCommon_109;
		private System.Windows.Forms.CheckBox _chkCommon_107;
		private System.Windows.Forms.CheckBox _chkCommon_106;
		private System.Windows.Forms.CheckBox _chkCommon_105;
		private System.Windows.Forms.CheckBox _chkCommon_104;
		private System.Windows.Forms.CheckBox _chkCommon_101;
		private System.Windows.Forms.CheckBox _chkCommon_100;
		private System.Windows.Forms.CheckBox _chkCommon_99;
		private System.Windows.Forms.CheckBox _chkCommon_98;
		private System.Windows.Forms.CheckBox _chkCommon_96;
		private System.Windows.Forms.CheckBox _chkCommon_91;
		private System.Windows.Forms.CheckBox _chkCommon_90;
		private System.Windows.Forms.CheckBox _chkCommon_89;
		private System.Windows.Forms.CheckBox _chkCommon_88;
		private System.Windows.Forms.CheckBox _chkCommon_87;
		private System.Windows.Forms.CheckBox _chkCommon_86;
		private System.Windows.Forms.CheckBox _chkCommon_84;
		private System.Windows.Forms.Label _lblCommon_35;
		private System.Windows.Forms.ComboBox _cmbCommon_1;
		private System.Windows.Forms.Label _lblCommon_32;
		private System.Windows.Forms.TextBox _txtCommon_19;
		private System.Windows.Forms.Label _lblCommon_46;
		private System.Windows.Forms.TextBox _txtCommon_38;
		private System.Windows.Forms.Label _lblCommon_48;
		private System.Windows.Forms.TextBox _txtCommon_40;
		private System.Windows.Forms.GroupBox _fraCommon_17;
		private System.Windows.Forms.GroupBox _fraCommon_8;
		private System.Windows.Forms.CheckBox _chkCommon_66;
		private System.Windows.Forms.TextBox _txtCommon_12;
		private System.Windows.Forms.CheckBox _chkCommon_65;
		private System.Windows.Forms.CheckBox _chkCommon_64;
		private System.Windows.Forms.CheckBox _chkCommon_63;
		private System.Windows.Forms.CheckBox _chkCommon_62;
		private System.Windows.Forms.CheckBox _chkCommon_61;
		private System.Windows.Forms.RadioButton _optCommonQtyEffect_3;
		private System.Windows.Forms.RadioButton _optCommonQtyEffect_2;
		private System.Windows.Forms.Label _lblCommon_12;
		private System.Windows.Forms.TextBox _txtCommon_10;
		private System.Windows.Forms.Label _lblCommon_14;
		private System.Windows.Forms.Label _lblCommon_15;
		private System.Windows.Forms.TextBox _txtCommon_13;
		private System.Windows.Forms.Label _txtCommonLabel_4;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_0_cmbPrintList;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_1_cmbPrintList;
		public C1.Win.C1TrueDBGrid.C1TrueDBDropdown cmbPrintList;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_0_grdPrintTask;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_1_grdPrintTask;
		public C1.Win.C1TrueDBGrid.C1TrueDBGrid grdPrintTask;
		private System.Windows.Forms.GroupBox _fraCommon_15;
		private System.Windows.Forms.GroupBox _fraCommon_7;
		private System.Windows.Forms.Label _lblCommon_24;
		private System.Windows.Forms.Label _lblCommon_25;
		private System.Windows.Forms.Label _lblCommon_26;
		private System.Windows.Forms.Label _lblCommon_27;
		private System.Windows.Forms.Label _txtCommonLabel_14;
		private System.Windows.Forms.Label _txtCommonLabel_15;
		private System.Windows.Forms.Label _txtCommonLabel_16;
		private System.Windows.Forms.Label _txtCommonLabel_13;
		private System.Windows.Forms.TextBox _txtCommon_18;
		private System.Windows.Forms.TextBox _txtCommon_20;
		private System.Windows.Forms.TextBox _txtCommon_21;
		private System.Windows.Forms.TextBox _txtCommon_22;
		private System.Windows.Forms.GroupBox _fraCommon_19;
		private System.Windows.Forms.CheckBox _chkCommon_94;
		private System.Windows.Forms.CheckBox _chkCommon_95;
		private System.Windows.Forms.CheckBox _chkCommon_97;
		private System.Windows.Forms.GroupBox _fraCommon_25;
		private System.Windows.Forms.CheckBox _chkCommon_127;
		private System.Windows.Forms.CheckBox _chkCommon_60;
		private System.Windows.Forms.CheckBox _chkCommon_59;
		private System.Windows.Forms.CheckBox _chkCommon_58;
		private System.Windows.Forms.CheckBox _chkCommon_57;
		private System.Windows.Forms.CheckBox _chkCommon_56;
		private System.Windows.Forms.CheckBox _chkCommon_55;
		private System.Windows.Forms.CheckBox _chkCommon_54;
		private System.Windows.Forms.GroupBox _fraCommon_16;
		private System.Windows.Forms.CheckBox _chkCommon_53;
		private System.Windows.Forms.CheckBox _chkCommon_52;
		private System.Windows.Forms.CheckBox _chkCommon_51;
		private System.Windows.Forms.CheckBox _chkCommon_50;
		private System.Windows.Forms.CheckBox _chkCommon_49;
		private System.Windows.Forms.CheckBox _chkCommon_48;
		private System.Windows.Forms.GroupBox _fraCommon_14;
		private System.Windows.Forms.GroupBox _fraCommon_6;
		private System.Windows.Forms.CheckBox _chkCommon_133;
		private System.Windows.Forms.CheckBox _chkCommon_123;
		private System.Windows.Forms.CheckBox _chkCommon_115;
		private System.Windows.Forms.CheckBox _chkCommon_71;
		private System.Windows.Forms.CheckBox _chkCommon_114;
		private System.Windows.Forms.CheckBox _chkCommon_111;
		private System.Windows.Forms.CheckBox _chkCommon_8;
		private System.Windows.Forms.CheckBox _chkCommon_22;
		private System.Windows.Forms.CheckBox _chkCommon_23;
		private System.Windows.Forms.CheckBox _chkCommon_26;
		private System.Windows.Forms.CheckBox _chkCommon_27;
		private System.Windows.Forms.CheckBox _chkCommon_28;
		private System.Windows.Forms.CheckBox _chkCommon_30;
		private System.Windows.Forms.CheckBox _chkCommon_31;
		private System.Windows.Forms.CheckBox _chkCommon_32;
		private System.Windows.Forms.CheckBox _chkCommon_40;
		private System.Windows.Forms.CheckBox _chkCommon_67;
		private System.Windows.Forms.CheckBox _chkCommon_70;
		private System.Windows.Forms.GroupBox _fraCommon_11;
		private System.Windows.Forms.CheckBox _chkCommon_136;
		private System.Windows.Forms.CheckBox _chkCommon_72;
		private System.Windows.Forms.CheckBox _chkCommon_12;
		private System.Windows.Forms.CheckBox _chkCommon_11;
		private System.Windows.Forms.CheckBox _chkCommon_10;
		private System.Windows.Forms.CheckBox _chkCommon_39;
		private System.Windows.Forms.CheckBox _chkCommon_38;
		private System.Windows.Forms.CheckBox _chkCommon_37;
		private System.Windows.Forms.CheckBox _chkCommon_34;
		private System.Windows.Forms.CheckBox _chkCommon_33;
		private System.Windows.Forms.CheckBox _chkCommon_29;
		private System.Windows.Forms.CheckBox _chkCommon_25;
		private System.Windows.Forms.CheckBox _chkCommon_24;
		private System.Windows.Forms.CheckBox _chkCommon_15;
		private System.Windows.Forms.CheckBox _chkCommon_9;
		private System.Windows.Forms.CheckBox _chkCommon_36;
		private System.Windows.Forms.CheckBox _chkCommon_85;
		private System.Windows.Forms.CheckBox _chkCommon_83;
		private System.Windows.Forms.CheckBox _chkCommon_132;
		private System.Windows.Forms.CheckBox _chkCommon_126;
		private System.Windows.Forms.CheckBox _chkCommon_103;
		private System.Windows.Forms.CheckBox _chkCommon_20;
		private System.Windows.Forms.CheckBox _chkCommon_113;
		private System.Windows.Forms.CheckBox _chkCommon_112;
		private System.Windows.Forms.CheckBox _chkCommon_13;
		private System.Windows.Forms.CheckBox _chkCommon_14;
		private System.Windows.Forms.CheckBox _chkCommon_16;
		private System.Windows.Forms.CheckBox _chkCommon_19;
		private System.Windows.Forms.CheckBox _chkCommon_21;
		private System.Windows.Forms.CheckBox _chkCommon_68;
		private System.Windows.Forms.CheckBox _chkCommon_69;
		private System.Windows.Forms.GroupBox _fraCommon_12;
		private System.Windows.Forms.CheckBox _chkCommon_18;
		private System.Windows.Forms.CheckBox _chkCommon_17;
		private System.Windows.Forms.CheckBox _chkCommon_41;
		private System.Windows.Forms.CheckBox _chkCommon_42;
		private System.Windows.Forms.CheckBox _chkCommon_43;
		private System.Windows.Forms.CheckBox _chkCommon_44;
		private System.Windows.Forms.CheckBox _chkCommon_45;
		private System.Windows.Forms.CheckBox _chkCommon_46;
		private System.Windows.Forms.CheckBox _chkCommon_47;
		private System.Windows.Forms.GroupBox _fraCommon_13;
		private System.Windows.Forms.GroupBox _fraCommon_5;
		private System.Windows.Forms.CheckBox _chkCommon_102;
		private System.Windows.Forms.CheckBox _chkCommon_124;
		private System.Windows.Forms.CheckBox _chkCommon_7;
		private System.Windows.Forms.Label _lblCommon_47;
		private System.Windows.Forms.TextBox _txtCommon_39;
		private System.Windows.Forms.GroupBox _fraCommon_24;
		private System.Windows.Forms.CheckBox _chkCommon_6;
		private System.Windows.Forms.CheckBox _chkCommon_131;
		private System.Windows.Forms.CheckBox _chkCommon_122;
		private System.Windows.Forms.CheckBox _chkCommon_93;
		private System.Windows.Forms.CheckBox _chkCommon_0;
		private System.Windows.Forms.CheckBox _chkCommon_1;
		private System.Windows.Forms.CheckBox _chkCommon_2;
		private System.Windows.Forms.CheckBox _chkCommon_3;
		private System.Windows.Forms.CheckBox _chkCommon_5;
		private System.Windows.Forms.RadioButton _optCommonAffectType_8;
		private System.Windows.Forms.RadioButton _optCommonAffectType_7;
		private System.Windows.Forms.RadioButton _optCommonAffectType_2;
		private System.Windows.Forms.RadioButton _optCommonAffectType_3;
		private System.Windows.Forms.RadioButton _optCommonAffectType_4;
		private System.Windows.Forms.RadioButton _optCommonAffectType_5;
		private System.Windows.Forms.RadioButton _optCommonAffectType_6;
		private System.Windows.Forms.RadioButton _optCommonAffectType_1;
		private System.Windows.Forms.RadioButton _optCommonAffectType_0;
		private System.Windows.Forms.GroupBox _fraCommon_2;
		private System.Windows.Forms.RadioButton _optCommonQtyEffect_1;
		private System.Windows.Forms.RadioButton _optCommonQtyEffect_0;
		private System.Windows.Forms.GroupBox _fraCommon_4;
		private System.Windows.Forms.CheckBox _chkCommon_4;
		private System.Windows.Forms.Label _lblCommon_8;
		private System.Windows.Forms.Label _lblCommon_9;
		private System.Windows.Forms.Label _lblCommon_10;
		private System.Windows.Forms.Label _lblCommon_11;
		private System.Windows.Forms.Label _txtCommonLabel_1;
		private System.Windows.Forms.Label _lblCommon_17;
		private System.Windows.Forms.Label _txtCommonLabel_3;
		private System.Windows.Forms.TextBox _txtCommon_7;
		private System.Windows.Forms.TextBox _txtCommon_8;
		private System.Windows.Forms.Label _txtCommonLabel_2;
		private System.Windows.Forms.Label _txtCommonLabel_21;
		private System.Windows.Forms.TextBox _txtCommon_6;
		private System.Windows.Forms.TextBox _txtCommon_9;
		private System.Windows.Forms.ComboBox _cmbCommon_0;
		private System.Windows.Forms.GroupBox _fraCommon_0;
		public AxC1SizerLib.AxC1Tab tabVoucherDetails;
		private System.Windows.Forms.TextBox _txtCommon_1;
		private System.Windows.Forms.TextBox _txtCommon_2;
		private System.Windows.Forms.TextBox _txtCommon_0;
		private System.Windows.Forms.Label _lblCommon_1;
		private System.Windows.Forms.Label _lblCommon_6;
		private System.Windows.Forms.Label _lblCommon_7;
		private System.Windows.Forms.Label _lblCommon_2;
		private System.Windows.Forms.TextBox _txtCommon_3;
		private System.Windows.Forms.TextBox _txtCommon_4;
		private System.Windows.Forms.TextBox _txtCommon_5;
		private System.Windows.Forms.Label _lblCommon_4;
		private System.Windows.Forms.Label _lblCommon_5;
		private System.Windows.Forms.Label _lblCommon_44;
		public System.Windows.Forms.CheckBox[] chkCommon = new System.Windows.Forms.CheckBox[138];
		public System.Windows.Forms.ComboBox[] cmbCommon = new System.Windows.Forms.ComboBox[3];
		public System.Windows.Forms.GroupBox[] fraCommon = new System.Windows.Forms.GroupBox[26];
		public System.Windows.Forms.Label[] lblCommon = new System.Windows.Forms.Label[49];
		public System.Windows.Forms.RadioButton[] optCommonAffectType = new System.Windows.Forms.RadioButton[12];
		public System.Windows.Forms.RadioButton[] optCommonQtyEffect = new System.Windows.Forms.RadioButton[4];
		public System.Windows.Forms.TextBox[] txtCommon = new System.Windows.Forms.TextBox[41];
		public System.Windows.Forms.Label[] txtCommonLabel = new System.Windows.Forms.Label[30];
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmICSVoucherTypes));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this._fraCommon_23 = new System.Windows.Forms.GroupBox();
			this.UCOkCancel1 = new UCOkCancel();
			this.grdVoucherParentDetails = new C1.Win.C1TrueDBGrid.C1TrueDBGrid();
			this.Column_0_grdVoucherParentDetails = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.cmbParentsList = new C1.Win.C1TrueDBGrid.C1TrueDBDropdown();
			this.Column_0_cmbParentsList = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.Column_1_cmbParentsList = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.tabVoucherDetails = new AxC1SizerLib.AxC1Tab();
			this._fraCommon_1 = new System.Windows.Forms.GroupBox();
			this.cmdParentDetails = new System.Windows.Forms.Button();
			this._optCommonAffectType_11 = new System.Windows.Forms.RadioButton();
			this._optCommonAffectType_10 = new System.Windows.Forms.RadioButton();
			this._optCommonAffectType_9 = new System.Windows.Forms.RadioButton();
			this._fraCommon_22 = new System.Windows.Forms.GroupBox();
			this._chkCommon_75 = new System.Windows.Forms.CheckBox();
			this._chkCommon_121 = new System.Windows.Forms.CheckBox();
			this._chkCommon_135 = new System.Windows.Forms.CheckBox();
			this._chkCommon_134 = new System.Windows.Forms.CheckBox();
			this._chkCommon_117 = new System.Windows.Forms.CheckBox();
			this._chkCommon_118 = new System.Windows.Forms.CheckBox();
			this._chkCommon_119 = new System.Windows.Forms.CheckBox();
			this._chkCommon_116 = new System.Windows.Forms.CheckBox();
			this._chkCommon_120 = new System.Windows.Forms.CheckBox();
			this._chkCommon_77 = new System.Windows.Forms.CheckBox();
			this._fraCommon_21 = new System.Windows.Forms.GroupBox();
			this._chkCommon_82 = new System.Windows.Forms.CheckBox();
			this._chkCommon_80 = new System.Windows.Forms.CheckBox();
			this._chkCommon_78 = new System.Windows.Forms.CheckBox();
			this._chkCommon_81 = new System.Windows.Forms.CheckBox();
			this._chkCommon_79 = new System.Windows.Forms.CheckBox();
			this._chkCommon_76 = new System.Windows.Forms.CheckBox();
			this._chkCommon_74 = new System.Windows.Forms.CheckBox();
			this._fraCommon_18 = new System.Windows.Forms.GroupBox();
			this._lblCommon_18 = new System.Windows.Forms.Label();
			this._lblCommon_19 = new System.Windows.Forms.Label();
			this._lblCommon_20 = new System.Windows.Forms.Label();
			this._lblCommon_21 = new System.Windows.Forms.Label();
			this._lblCommon_22 = new System.Windows.Forms.Label();
			this._lblCommon_23 = new System.Windows.Forms.Label();
			this._txtCommon_32 = new System.Windows.Forms.TextBox();
			this._txtCommon_31 = new System.Windows.Forms.TextBox();
			this._txtCommonLabel_11 = new System.Windows.Forms.Label();
			this._txtCommonLabel_12 = new System.Windows.Forms.Label();
			this._txtCommon_28 = new System.Windows.Forms.TextBox();
			this._txtCommon_29 = new System.Windows.Forms.TextBox();
			this._txtCommon_30 = new System.Windows.Forms.TextBox();
			this._txtCommon_33 = new System.Windows.Forms.TextBox();
			this._lblCommon_43 = new System.Windows.Forms.Label();
			this._txtCommonLabel_29 = new System.Windows.Forms.Label();
			this._lblCommon_34 = new System.Windows.Forms.Label();
			this._txtCommonLabel_0 = new System.Windows.Forms.Label();
			this._txtCommon_17 = new System.Windows.Forms.TextBox();
			this._txtCommon_15 = new System.Windows.Forms.TextBox();
			this._fraCommon_10 = new System.Windows.Forms.GroupBox();
			this.dlgColorColor = new System.Windows.Forms.ColorDialog();
			this.dlgColor = new UpgradeStubs.AxMSComDlg_AxCommonDialog();
			this._fraCommon_3 = new System.Windows.Forms.GroupBox();
			this._chkCommon_92 = new System.Windows.Forms.CheckBox();
			this._txtCommonLabel_6 = new System.Windows.Forms.Label();
			this._lblCommon_40 = new System.Windows.Forms.Label();
			this._txtCommon_16 = new System.Windows.Forms.TextBox();
			this._lblCommon_33 = new System.Windows.Forms.Label();
			this._cmbCommon_2 = new System.Windows.Forms.ComboBox();
			this._lblCommon_38 = new System.Windows.Forms.Label();
			this._lblCommon_39 = new System.Windows.Forms.Label();
			this._lblCommon_41 = new System.Windows.Forms.Label();
			this._lblCommon_42 = new System.Windows.Forms.Label();
			this._lblCommon_37 = new System.Windows.Forms.Label();
			this._txtCommon_23 = new System.Windows.Forms.TextBox();
			this._txtCommon_24 = new System.Windows.Forms.TextBox();
			this._txtCommon_25 = new System.Windows.Forms.TextBox();
			this._txtCommon_26 = new System.Windows.Forms.TextBox();
			this._txtCommon_27 = new System.Windows.Forms.TextBox();
			this._lblCommon_0 = new System.Windows.Forms.Label();
			this._txtCommon_34 = new System.Windows.Forms.TextBox();
			this._txtCommon_35 = new System.Windows.Forms.TextBox();
			this._lblCommon_13 = new System.Windows.Forms.Label();
			this._txtCommon_11 = new System.Windows.Forms.TextBox();
			this._lblCommon_16 = new System.Windows.Forms.Label();
			this._txtCommon_14 = new System.Windows.Forms.TextBox();
			this._lblCommon_31 = new System.Windows.Forms.Label();
			this._txtCommon_36 = new System.Windows.Forms.TextBox();
			this._lblCommon_45 = new System.Windows.Forms.Label();
			this._txtCommon_37 = new System.Windows.Forms.TextBox();
			this._fraCommon_9 = new System.Windows.Forms.GroupBox();
			this._fraCommon_20 = new System.Windows.Forms.GroupBox();
			this._chkCommon_73 = new System.Windows.Forms.CheckBox();
			this._chkCommon_108 = new System.Windows.Forms.CheckBox();
			this._txtCommonLabel_17 = new System.Windows.Forms.Label();
			this._txtCommonLabel_19 = new System.Windows.Forms.Label();
			this._txtCommonLabel_20 = new System.Windows.Forms.Label();
			this._txtCommonLabel_22 = new System.Windows.Forms.Label();
			this._lblCommon_28 = new System.Windows.Forms.Label();
			this._lblCommon_29 = new System.Windows.Forms.Label();
			this._lblCommon_30 = new System.Windows.Forms.Label();
			this._lblCommon_36 = new System.Windows.Forms.Label();
			this._fraCommon_8 = new System.Windows.Forms.GroupBox();
			this._fraCommon_17 = new System.Windows.Forms.GroupBox();
			this._chkCommon_137 = new System.Windows.Forms.CheckBox();
			this._chkCommon_130 = new System.Windows.Forms.CheckBox();
			this._chkCommon_129 = new System.Windows.Forms.CheckBox();
			this._chkCommon_128 = new System.Windows.Forms.CheckBox();
			this._chkCommon_125 = new System.Windows.Forms.CheckBox();
			this._chkCommon_35 = new System.Windows.Forms.CheckBox();
			this._chkCommon_110 = new System.Windows.Forms.CheckBox();
			this._chkCommon_109 = new System.Windows.Forms.CheckBox();
			this._chkCommon_107 = new System.Windows.Forms.CheckBox();
			this._chkCommon_106 = new System.Windows.Forms.CheckBox();
			this._chkCommon_105 = new System.Windows.Forms.CheckBox();
			this._chkCommon_104 = new System.Windows.Forms.CheckBox();
			this._chkCommon_101 = new System.Windows.Forms.CheckBox();
			this._chkCommon_100 = new System.Windows.Forms.CheckBox();
			this._chkCommon_99 = new System.Windows.Forms.CheckBox();
			this._chkCommon_98 = new System.Windows.Forms.CheckBox();
			this._chkCommon_96 = new System.Windows.Forms.CheckBox();
			this._chkCommon_91 = new System.Windows.Forms.CheckBox();
			this._chkCommon_90 = new System.Windows.Forms.CheckBox();
			this._chkCommon_89 = new System.Windows.Forms.CheckBox();
			this._chkCommon_88 = new System.Windows.Forms.CheckBox();
			this._chkCommon_87 = new System.Windows.Forms.CheckBox();
			this._chkCommon_86 = new System.Windows.Forms.CheckBox();
			this._chkCommon_84 = new System.Windows.Forms.CheckBox();
			this._lblCommon_35 = new System.Windows.Forms.Label();
			this._cmbCommon_1 = new System.Windows.Forms.ComboBox();
			this._lblCommon_32 = new System.Windows.Forms.Label();
			this._txtCommon_19 = new System.Windows.Forms.TextBox();
			this._lblCommon_46 = new System.Windows.Forms.Label();
			this._txtCommon_38 = new System.Windows.Forms.TextBox();
			this._lblCommon_48 = new System.Windows.Forms.Label();
			this._txtCommon_40 = new System.Windows.Forms.TextBox();
			this._fraCommon_7 = new System.Windows.Forms.GroupBox();
			this._fraCommon_15 = new System.Windows.Forms.GroupBox();
			this._chkCommon_66 = new System.Windows.Forms.CheckBox();
			this._txtCommon_12 = new System.Windows.Forms.TextBox();
			this._chkCommon_65 = new System.Windows.Forms.CheckBox();
			this._chkCommon_64 = new System.Windows.Forms.CheckBox();
			this._chkCommon_63 = new System.Windows.Forms.CheckBox();
			this._chkCommon_62 = new System.Windows.Forms.CheckBox();
			this._chkCommon_61 = new System.Windows.Forms.CheckBox();
			this._optCommonQtyEffect_3 = new System.Windows.Forms.RadioButton();
			this._optCommonQtyEffect_2 = new System.Windows.Forms.RadioButton();
			this._lblCommon_12 = new System.Windows.Forms.Label();
			this._txtCommon_10 = new System.Windows.Forms.TextBox();
			this._lblCommon_14 = new System.Windows.Forms.Label();
			this._lblCommon_15 = new System.Windows.Forms.Label();
			this._txtCommon_13 = new System.Windows.Forms.TextBox();
			this._txtCommonLabel_4 = new System.Windows.Forms.Label();
			this.cmbPrintList = new C1.Win.C1TrueDBGrid.C1TrueDBDropdown();
			this.Column_0_cmbPrintList = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.Column_1_cmbPrintList = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.grdPrintTask = new C1.Win.C1TrueDBGrid.C1TrueDBGrid();
			this.Column_0_grdPrintTask = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.Column_1_grdPrintTask = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this._fraCommon_6 = new System.Windows.Forms.GroupBox();
			this._fraCommon_19 = new System.Windows.Forms.GroupBox();
			this._lblCommon_24 = new System.Windows.Forms.Label();
			this._lblCommon_25 = new System.Windows.Forms.Label();
			this._lblCommon_26 = new System.Windows.Forms.Label();
			this._lblCommon_27 = new System.Windows.Forms.Label();
			this._txtCommonLabel_14 = new System.Windows.Forms.Label();
			this._txtCommonLabel_15 = new System.Windows.Forms.Label();
			this._txtCommonLabel_16 = new System.Windows.Forms.Label();
			this._txtCommonLabel_13 = new System.Windows.Forms.Label();
			this._txtCommon_18 = new System.Windows.Forms.TextBox();
			this._txtCommon_20 = new System.Windows.Forms.TextBox();
			this._txtCommon_21 = new System.Windows.Forms.TextBox();
			this._txtCommon_22 = new System.Windows.Forms.TextBox();
			this._fraCommon_25 = new System.Windows.Forms.GroupBox();
			this._chkCommon_94 = new System.Windows.Forms.CheckBox();
			this._chkCommon_95 = new System.Windows.Forms.CheckBox();
			this._chkCommon_97 = new System.Windows.Forms.CheckBox();
			this._chkCommon_127 = new System.Windows.Forms.CheckBox();
			this._chkCommon_60 = new System.Windows.Forms.CheckBox();
			this._fraCommon_16 = new System.Windows.Forms.GroupBox();
			this._chkCommon_59 = new System.Windows.Forms.CheckBox();
			this._chkCommon_58 = new System.Windows.Forms.CheckBox();
			this._chkCommon_57 = new System.Windows.Forms.CheckBox();
			this._chkCommon_56 = new System.Windows.Forms.CheckBox();
			this._chkCommon_55 = new System.Windows.Forms.CheckBox();
			this._chkCommon_54 = new System.Windows.Forms.CheckBox();
			this._fraCommon_14 = new System.Windows.Forms.GroupBox();
			this._chkCommon_53 = new System.Windows.Forms.CheckBox();
			this._chkCommon_52 = new System.Windows.Forms.CheckBox();
			this._chkCommon_51 = new System.Windows.Forms.CheckBox();
			this._chkCommon_50 = new System.Windows.Forms.CheckBox();
			this._chkCommon_49 = new System.Windows.Forms.CheckBox();
			this._chkCommon_48 = new System.Windows.Forms.CheckBox();
			this._fraCommon_5 = new System.Windows.Forms.GroupBox();
			this._fraCommon_11 = new System.Windows.Forms.GroupBox();
			this._chkCommon_133 = new System.Windows.Forms.CheckBox();
			this._chkCommon_123 = new System.Windows.Forms.CheckBox();
			this._chkCommon_115 = new System.Windows.Forms.CheckBox();
			this._chkCommon_71 = new System.Windows.Forms.CheckBox();
			this._chkCommon_114 = new System.Windows.Forms.CheckBox();
			this._chkCommon_111 = new System.Windows.Forms.CheckBox();
			this._chkCommon_8 = new System.Windows.Forms.CheckBox();
			this._chkCommon_22 = new System.Windows.Forms.CheckBox();
			this._chkCommon_23 = new System.Windows.Forms.CheckBox();
			this._chkCommon_26 = new System.Windows.Forms.CheckBox();
			this._chkCommon_27 = new System.Windows.Forms.CheckBox();
			this._chkCommon_28 = new System.Windows.Forms.CheckBox();
			this._chkCommon_30 = new System.Windows.Forms.CheckBox();
			this._chkCommon_31 = new System.Windows.Forms.CheckBox();
			this._chkCommon_32 = new System.Windows.Forms.CheckBox();
			this._chkCommon_40 = new System.Windows.Forms.CheckBox();
			this._chkCommon_67 = new System.Windows.Forms.CheckBox();
			this._chkCommon_70 = new System.Windows.Forms.CheckBox();
			this._fraCommon_12 = new System.Windows.Forms.GroupBox();
			this._chkCommon_136 = new System.Windows.Forms.CheckBox();
			this._chkCommon_72 = new System.Windows.Forms.CheckBox();
			this._chkCommon_12 = new System.Windows.Forms.CheckBox();
			this._chkCommon_11 = new System.Windows.Forms.CheckBox();
			this._chkCommon_10 = new System.Windows.Forms.CheckBox();
			this._chkCommon_39 = new System.Windows.Forms.CheckBox();
			this._chkCommon_38 = new System.Windows.Forms.CheckBox();
			this._chkCommon_37 = new System.Windows.Forms.CheckBox();
			this._chkCommon_34 = new System.Windows.Forms.CheckBox();
			this._chkCommon_33 = new System.Windows.Forms.CheckBox();
			this._chkCommon_29 = new System.Windows.Forms.CheckBox();
			this._chkCommon_25 = new System.Windows.Forms.CheckBox();
			this._chkCommon_24 = new System.Windows.Forms.CheckBox();
			this._chkCommon_15 = new System.Windows.Forms.CheckBox();
			this._chkCommon_9 = new System.Windows.Forms.CheckBox();
			this._chkCommon_36 = new System.Windows.Forms.CheckBox();
			this._chkCommon_85 = new System.Windows.Forms.CheckBox();
			this._chkCommon_83 = new System.Windows.Forms.CheckBox();
			this._chkCommon_132 = new System.Windows.Forms.CheckBox();
			this._chkCommon_126 = new System.Windows.Forms.CheckBox();
			this._chkCommon_103 = new System.Windows.Forms.CheckBox();
			this._chkCommon_20 = new System.Windows.Forms.CheckBox();
			this._chkCommon_113 = new System.Windows.Forms.CheckBox();
			this._chkCommon_112 = new System.Windows.Forms.CheckBox();
			this._chkCommon_13 = new System.Windows.Forms.CheckBox();
			this._chkCommon_14 = new System.Windows.Forms.CheckBox();
			this._chkCommon_16 = new System.Windows.Forms.CheckBox();
			this._chkCommon_19 = new System.Windows.Forms.CheckBox();
			this._chkCommon_21 = new System.Windows.Forms.CheckBox();
			this._chkCommon_68 = new System.Windows.Forms.CheckBox();
			this._chkCommon_69 = new System.Windows.Forms.CheckBox();
			this._fraCommon_13 = new System.Windows.Forms.GroupBox();
			this._chkCommon_18 = new System.Windows.Forms.CheckBox();
			this._chkCommon_17 = new System.Windows.Forms.CheckBox();
			this._chkCommon_41 = new System.Windows.Forms.CheckBox();
			this._chkCommon_42 = new System.Windows.Forms.CheckBox();
			this._chkCommon_43 = new System.Windows.Forms.CheckBox();
			this._chkCommon_44 = new System.Windows.Forms.CheckBox();
			this._chkCommon_45 = new System.Windows.Forms.CheckBox();
			this._chkCommon_46 = new System.Windows.Forms.CheckBox();
			this._chkCommon_47 = new System.Windows.Forms.CheckBox();
			this._fraCommon_0 = new System.Windows.Forms.GroupBox();
			this._chkCommon_102 = new System.Windows.Forms.CheckBox();
			this._fraCommon_24 = new System.Windows.Forms.GroupBox();
			this._chkCommon_124 = new System.Windows.Forms.CheckBox();
			this._chkCommon_7 = new System.Windows.Forms.CheckBox();
			this._lblCommon_47 = new System.Windows.Forms.Label();
			this._txtCommon_39 = new System.Windows.Forms.TextBox();
			this._chkCommon_6 = new System.Windows.Forms.CheckBox();
			this._fraCommon_2 = new System.Windows.Forms.GroupBox();
			this._chkCommon_131 = new System.Windows.Forms.CheckBox();
			this._chkCommon_122 = new System.Windows.Forms.CheckBox();
			this._chkCommon_93 = new System.Windows.Forms.CheckBox();
			this._chkCommon_0 = new System.Windows.Forms.CheckBox();
			this._chkCommon_1 = new System.Windows.Forms.CheckBox();
			this._chkCommon_2 = new System.Windows.Forms.CheckBox();
			this._chkCommon_3 = new System.Windows.Forms.CheckBox();
			this._chkCommon_5 = new System.Windows.Forms.CheckBox();
			this._optCommonAffectType_8 = new System.Windows.Forms.RadioButton();
			this._optCommonAffectType_7 = new System.Windows.Forms.RadioButton();
			this._optCommonAffectType_2 = new System.Windows.Forms.RadioButton();
			this._optCommonAffectType_3 = new System.Windows.Forms.RadioButton();
			this._optCommonAffectType_4 = new System.Windows.Forms.RadioButton();
			this._optCommonAffectType_5 = new System.Windows.Forms.RadioButton();
			this._optCommonAffectType_6 = new System.Windows.Forms.RadioButton();
			this._optCommonAffectType_1 = new System.Windows.Forms.RadioButton();
			this._optCommonAffectType_0 = new System.Windows.Forms.RadioButton();
			this._fraCommon_4 = new System.Windows.Forms.GroupBox();
			this._optCommonQtyEffect_1 = new System.Windows.Forms.RadioButton();
			this._optCommonQtyEffect_0 = new System.Windows.Forms.RadioButton();
			this._chkCommon_4 = new System.Windows.Forms.CheckBox();
			this._lblCommon_8 = new System.Windows.Forms.Label();
			this._lblCommon_9 = new System.Windows.Forms.Label();
			this._lblCommon_10 = new System.Windows.Forms.Label();
			this._lblCommon_11 = new System.Windows.Forms.Label();
			this._txtCommonLabel_1 = new System.Windows.Forms.Label();
			this._lblCommon_17 = new System.Windows.Forms.Label();
			this._txtCommonLabel_3 = new System.Windows.Forms.Label();
			this._txtCommon_7 = new System.Windows.Forms.TextBox();
			this._txtCommon_8 = new System.Windows.Forms.TextBox();
			this._txtCommonLabel_2 = new System.Windows.Forms.Label();
			this._txtCommonLabel_21 = new System.Windows.Forms.Label();
			this._txtCommon_6 = new System.Windows.Forms.TextBox();
			this._txtCommon_9 = new System.Windows.Forms.TextBox();
			this._cmbCommon_0 = new System.Windows.Forms.ComboBox();
			this._txtCommon_1 = new System.Windows.Forms.TextBox();
			this._txtCommon_2 = new System.Windows.Forms.TextBox();
			this._txtCommon_0 = new System.Windows.Forms.TextBox();
			this._lblCommon_1 = new System.Windows.Forms.Label();
			this._lblCommon_6 = new System.Windows.Forms.Label();
			this._lblCommon_7 = new System.Windows.Forms.Label();
			this._lblCommon_2 = new System.Windows.Forms.Label();
			this._txtCommon_3 = new System.Windows.Forms.TextBox();
			this._txtCommon_4 = new System.Windows.Forms.TextBox();
			this._txtCommon_5 = new System.Windows.Forms.TextBox();
			this._lblCommon_4 = new System.Windows.Forms.Label();
			this._lblCommon_5 = new System.Windows.Forms.Label();
			this._lblCommon_44 = new System.Windows.Forms.Label();
			// //((System.ComponentModel.ISupportInitialize) this.tabVoucherDetails).BeginInit();
			this._fraCommon_23.SuspendLayout();
			this.grdVoucherParentDetails.SuspendLayout();
			this.cmbParentsList.SuspendLayout();
			this.tabVoucherDetails.SuspendLayout();
			this._fraCommon_1.SuspendLayout();
			this._fraCommon_22.SuspendLayout();
			this._fraCommon_21.SuspendLayout();
			this._fraCommon_18.SuspendLayout();
			this._fraCommon_10.SuspendLayout();
			this._fraCommon_3.SuspendLayout();
			this._fraCommon_9.SuspendLayout();
			this._fraCommon_20.SuspendLayout();
			this._fraCommon_8.SuspendLayout();
			this._fraCommon_17.SuspendLayout();
			this._fraCommon_7.SuspendLayout();
			this._fraCommon_15.SuspendLayout();
			this.cmbPrintList.SuspendLayout();
			this.grdPrintTask.SuspendLayout();
			this._fraCommon_6.SuspendLayout();
			this._fraCommon_19.SuspendLayout();
			this._fraCommon_25.SuspendLayout();
			this._fraCommon_16.SuspendLayout();
			this._fraCommon_14.SuspendLayout();
			this._fraCommon_5.SuspendLayout();
			this._fraCommon_11.SuspendLayout();
			this._fraCommon_12.SuspendLayout();
			this._fraCommon_13.SuspendLayout();
			this._fraCommon_0.SuspendLayout();
			this._fraCommon_24.SuspendLayout();
			this._fraCommon_2.SuspendLayout();
			this._fraCommon_4.SuspendLayout();
			this.SuspendLayout();
			// 
			// _fraCommon_23
			// 
			this._fraCommon_23.AllowDrop = true;
			this._fraCommon_23.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._fraCommon_23.Controls.Add(this.UCOkCancel1);
			this._fraCommon_23.Controls.Add(this.grdVoucherParentDetails);
			this._fraCommon_23.Controls.Add(this.cmbParentsList);
			this._fraCommon_23.Enabled = true;
			this._fraCommon_23.ForeColor = System.Drawing.SystemColors.WindowText;
			this._fraCommon_23.Location = new System.Drawing.Point(342, 2);
			this._fraCommon_23.Name = "_fraCommon_23";
			this._fraCommon_23.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._fraCommon_23.Size = new System.Drawing.Size(25, 19);
			this._fraCommon_23.TabIndex = 215;
			this._fraCommon_23.Text = "Voucher Parent Details";
			this._fraCommon_23.Visible = false;
			// 
			// UCOkCancel1
			// 
			this.UCOkCancel1.AllowDrop = true;
			this.UCOkCancel1.DisplayButton = 0;
			this.UCOkCancel1.Location = new System.Drawing.Point(122, 120);
			this.UCOkCancel1.Name = "UCOkCancel1";
			this.UCOkCancel1.OkCaption = "&Ok";
			this.UCOkCancel1.Size = new System.Drawing.Size(205, 29);
			this.UCOkCancel1.TabIndex = 216;
			this.UCOkCancel1.CancelClick += new UCOkCancel.CancelClickHandler(this.UCOkCancel1_CancelClick);
			this.UCOkCancel1.OKClick += new UCOkCancel.OKClickHandler(this.UCOkCancel1_OKClick);
			// 
			// grdVoucherParentDetails
			// 
			this.grdVoucherParentDetails.AllowDrop = true;
			this.grdVoucherParentDetails.BackColor = System.Drawing.Color.FromArgb(212, 208, 200);
			this.grdVoucherParentDetails.CellTipsWidth = 0;
			this.grdVoucherParentDetails.Location = new System.Drawing.Point(2, 2);
			this.grdVoucherParentDetails.Name = "grdVoucherParentDetails";
			this.grdVoucherParentDetails.RowDivider.Color = System.Drawing.Color.FromArgb(212, 208, 200);
			this.grdVoucherParentDetails.Size = new System.Drawing.Size(327, 115);
			this.grdVoucherParentDetails.TabIndex = 217;
			this.grdVoucherParentDetails.Columns.Add(this.Column_0_grdVoucherParentDetails);
			this.grdVoucherParentDetails.GotFocus += new System.EventHandler(this.grdVoucherParentDetails_GotFocus);
			this.grdVoucherParentDetails.RowColChange += new C1.Win.C1TrueDBGrid.RowColChangeEventHandler(this.grdVoucherParentDetails_RowColChange);
			// 
			// Column_0_grdVoucherParentDetails
			// 
			this.Column_0_grdVoucherParentDetails.DataField = "";
			this.Column_0_grdVoucherParentDetails.ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.Normal;
			// 
			// cmbParentsList
			// 
			this.cmbParentsList.AllowDrop = true;
			this.cmbParentsList.ColumnHeaders = true;
			this.cmbParentsList.Enabled = true;
			this.cmbParentsList.Location = new System.Drawing.Point(20, 6);
			this.cmbParentsList.Name = "cmbParentsList";
			this.cmbParentsList.Size = new System.Drawing.Size(227, 104);
			this.cmbParentsList.TabIndex = 218;
			this.cmbParentsList.Columns.Add(this.Column_0_cmbParentsList);
			this.cmbParentsList.Columns.Add(this.Column_1_cmbParentsList);
			// 
			// Column_0_cmbParentsList
			// 
			this.Column_0_cmbParentsList.DataField = "";
			this.Column_0_cmbParentsList.ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.Normal;
			// 
			// Column_1_cmbParentsList
			// 
			this.Column_1_cmbParentsList.DataField = "";
			this.Column_1_cmbParentsList.ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.Normal;
			// 
			// tabVoucherDetails
			// 
			this.tabVoucherDetails.Align = C1SizerLib.AlignSettings.asNone;
			this.tabVoucherDetails.AllowDrop = true;
			this.tabVoucherDetails.Controls.Add(this._fraCommon_1);
			this.tabVoucherDetails.Controls.Add(this._fraCommon_10);
			this.tabVoucherDetails.Controls.Add(this._fraCommon_9);
			this.tabVoucherDetails.Controls.Add(this._fraCommon_8);
			this.tabVoucherDetails.Controls.Add(this._fraCommon_7);
			this.tabVoucherDetails.Controls.Add(this._fraCommon_6);
			this.tabVoucherDetails.Controls.Add(this._fraCommon_5);
			this.tabVoucherDetails.Controls.Add(this._fraCommon_0);
			this.tabVoucherDetails.Location = new System.Drawing.Point(6, 122);
			this.tabVoucherDetails.Name = "tabVoucherDetails";
			("tabVoucherDetails.OcxState");
			this.tabVoucherDetails.Size = new System.Drawing.Size(747, 359);
			this.tabVoucherDetails.TabIndex = 151;
			//// this.tabVoucherDetails.ClickEvent += new System.EventHandler(this.tabVoucherDetails_ClickEvent);
			// 
			// _fraCommon_1
			// 
			this._fraCommon_1.AllowDrop = true;
			this._fraCommon_1.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._fraCommon_1.Controls.Add(this.cmdParentDetails);
			this._fraCommon_1.Controls.Add(this._optCommonAffectType_11);
			this._fraCommon_1.Controls.Add(this._optCommonAffectType_10);
			this._fraCommon_1.Controls.Add(this._optCommonAffectType_9);
			this._fraCommon_1.Controls.Add(this._fraCommon_22);
			this._fraCommon_1.Controls.Add(this._fraCommon_21);
			this._fraCommon_1.Controls.Add(this._chkCommon_81);
			this._fraCommon_1.Controls.Add(this._chkCommon_79);
			this._fraCommon_1.Controls.Add(this._chkCommon_76);
			this._fraCommon_1.Controls.Add(this._chkCommon_74);
			this._fraCommon_1.Controls.Add(this._fraCommon_18);
			this._fraCommon_1.Controls.Add(this._lblCommon_43);
			this._fraCommon_1.Controls.Add(this._txtCommonLabel_29);
			this._fraCommon_1.Controls.Add(this._lblCommon_34);
			this._fraCommon_1.Controls.Add(this._txtCommonLabel_0);
			this._fraCommon_1.Controls.Add(this._txtCommon_17);
			this._fraCommon_1.Controls.Add(this._txtCommon_15);
			this._fraCommon_1.Enabled = true;
			this._fraCommon_1.ForeColor = System.Drawing.SystemColors.WindowText;
			this._fraCommon_1.Location = new System.Drawing.Point(-846, 23);
			this._fraCommon_1.Name = "_fraCommon_1";
			this._fraCommon_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._fraCommon_1.Size = new System.Drawing.Size(745, 335);
			this._fraCommon_1.TabIndex = 163;
			this._fraCommon_1.Text = "Frame1";
			this._fraCommon_1.Visible = true;
			// 
			// cmdParentDetails
			// 
			this.cmdParentDetails.AllowDrop = true;
			this.cmdParentDetails.BackColor = System.Drawing.SystemColors.Control;
			this.cmdParentDetails.CausesValidation = false;
			this.cmdParentDetails.Enabled = false;
			this.cmdParentDetails.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdParentDetails.Location = new System.Drawing.Point(326, 176);
			this.cmdParentDetails.Name = "cmdParentDetails";
			this.cmdParentDetails.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdParentDetails.Size = new System.Drawing.Size(24, 19);
			this.cmdParentDetails.TabIndex = 220;
			this.cmdParentDetails.TabStop = false;
			this.cmdParentDetails.Text = "&...";
			this.cmdParentDetails.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			// this.cmdParentDetails.Click += new System.EventHandler(this.cmdParentDetails_Click);
			// 
			// _optCommonAffectType_11
			// 
			this._optCommonAffectType_11.AllowDrop = true;
			this._optCommonAffectType_11.Appearance = System.Windows.Forms.Appearance.Normal;
			this._optCommonAffectType_11.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._optCommonAffectType_11.CausesValidation = true;
			this._optCommonAffectType_11.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._optCommonAffectType_11.Checked = false;
			this._optCommonAffectType_11.Enabled = true;
			this._optCommonAffectType_11.ForeColor = System.Drawing.SystemColors.ControlText;
			this._optCommonAffectType_11.Location = new System.Drawing.Point(8, 250);
			this._optCommonAffectType_11.Name = "_optCommonAffectType_11";
			this._optCommonAffectType_11.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._optCommonAffectType_11.Size = new System.Drawing.Size(202, 19);
			this._optCommonAffectType_11.TabIndex = 219;
			this._optCommonAffectType_11.TabStop = true;
			this._optCommonAffectType_11.Text = "None";
			this._optCommonAffectType_11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._optCommonAffectType_11.Visible = true;
			this._optCommonAffectType_11.CheckedChanged += new System.EventHandler(this.optCommonAffectType_CheckedChanged);
			// 
			// _optCommonAffectType_10
			// 
			this._optCommonAffectType_10.AllowDrop = true;
			this._optCommonAffectType_10.Appearance = System.Windows.Forms.Appearance.Normal;
			this._optCommonAffectType_10.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._optCommonAffectType_10.CausesValidation = true;
			this._optCommonAffectType_10.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._optCommonAffectType_10.Checked = false;
			this._optCommonAffectType_10.Enabled = true;
			this._optCommonAffectType_10.ForeColor = System.Drawing.SystemColors.ControlText;
			this._optCommonAffectType_10.Location = new System.Drawing.Point(8, 6);
			this._optCommonAffectType_10.Name = "_optCommonAffectType_10";
			this._optCommonAffectType_10.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._optCommonAffectType_10.Size = new System.Drawing.Size(256, 19);
			this._optCommonAffectType_10.TabIndex = 205;
			this._optCommonAffectType_10.TabStop = true;
			this._optCommonAffectType_10.Text = "Show import Linked Voucher on Header";
			this._optCommonAffectType_10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._optCommonAffectType_10.Visible = true;
			this._optCommonAffectType_10.CheckedChanged += new System.EventHandler(this.optCommonAffectType_CheckedChanged);
			// 
			// _optCommonAffectType_9
			// 
			this._optCommonAffectType_9.AllowDrop = true;
			this._optCommonAffectType_9.Appearance = System.Windows.Forms.Appearance.Normal;
			this._optCommonAffectType_9.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._optCommonAffectType_9.CausesValidation = true;
			this._optCommonAffectType_9.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._optCommonAffectType_9.Checked = false;
			this._optCommonAffectType_9.Enabled = true;
			this._optCommonAffectType_9.ForeColor = System.Drawing.SystemColors.ControlText;
			this._optCommonAffectType_9.Location = new System.Drawing.Point(8, 174);
			this._optCommonAffectType_9.Name = "_optCommonAffectType_9";
			this._optCommonAffectType_9.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._optCommonAffectType_9.Size = new System.Drawing.Size(202, 19);
			this._optCommonAffectType_9.TabIndex = 204;
			this._optCommonAffectType_9.TabStop = true;
			this._optCommonAffectType_9.Text = "Show import Linked Voucher on Detail";
			this._optCommonAffectType_9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._optCommonAffectType_9.Visible = true;
			this._optCommonAffectType_9.CheckedChanged += new System.EventHandler(this.optCommonAffectType_CheckedChanged);
			// 
			// _fraCommon_22
			// 
			this._fraCommon_22.AllowDrop = true;
			this._fraCommon_22.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._fraCommon_22.Controls.Add(this._chkCommon_75);
			this._fraCommon_22.Controls.Add(this._chkCommon_121);
			this._fraCommon_22.Controls.Add(this._chkCommon_135);
			this._fraCommon_22.Controls.Add(this._chkCommon_134);
			this._fraCommon_22.Controls.Add(this._chkCommon_117);
			this._fraCommon_22.Controls.Add(this._chkCommon_118);
			this._fraCommon_22.Controls.Add(this._chkCommon_119);
			this._fraCommon_22.Controls.Add(this._chkCommon_116);
			this._fraCommon_22.Controls.Add(this._chkCommon_120);
			this._fraCommon_22.Controls.Add(this._chkCommon_77);
			this._fraCommon_22.Enabled = true;
			this._fraCommon_22.ForeColor = System.Drawing.SystemColors.WindowText;
			this._fraCommon_22.Location = new System.Drawing.Point(390, 6);
			this._fraCommon_22.Name = "_fraCommon_22";
			this._fraCommon_22.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._fraCommon_22.Size = new System.Drawing.Size(349, 191);
			this._fraCommon_22.TabIndex = 24;
			this._fraCommon_22.Text = "Settings During Link";
			this._fraCommon_22.Visible = true;
			// 
			// _chkCommon_75
			// 
			this._chkCommon_75.AllowDrop = true;
			this._chkCommon_75.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkCommon_75.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._chkCommon_75.CausesValidation = true;
			this._chkCommon_75.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_75.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkCommon_75.Enabled = true;
			this._chkCommon_75.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkCommon_75.Location = new System.Drawing.Point(10, 166);
			this._chkCommon_75.Name = "_chkCommon_75";
			this._chkCommon_75.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkCommon_75.Size = new System.Drawing.Size(192, 17);
			this._chkCommon_75.TabIndex = 277;
			this._chkCommon_75.TabStop = true;
			this._chkCommon_75.Text = "Preserve Grid Value During Import";
			this._chkCommon_75.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_75.Visible = true;
			this._chkCommon_75.CheckStateChanged += new System.EventHandler(this.chkCommon_CheckStateChanged);
			// 
			// _chkCommon_121
			// 
			this._chkCommon_121.AllowDrop = true;
			this._chkCommon_121.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkCommon_121.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._chkCommon_121.CausesValidation = true;
			this._chkCommon_121.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_121.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkCommon_121.Enabled = true;
			this._chkCommon_121.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkCommon_121.Location = new System.Drawing.Point(10, 149);
			this._chkCommon_121.Name = "_chkCommon_121";
			this._chkCommon_121.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkCommon_121.Size = new System.Drawing.Size(224, 17);
			this._chkCommon_121.TabIndex = 276;
			this._chkCommon_121.TabStop = true;
			this._chkCommon_121.Text = "Import Non Inventory from Parent Voucher";
			this._chkCommon_121.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_121.Visible = true;
			this._chkCommon_121.CheckStateChanged += new System.EventHandler(this.chkCommon_CheckStateChanged);
			// 
			// _chkCommon_135
			// 
			this._chkCommon_135.AllowDrop = true;
			this._chkCommon_135.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkCommon_135.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._chkCommon_135.CausesValidation = true;
			this._chkCommon_135.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_135.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkCommon_135.Enabled = true;
			this._chkCommon_135.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkCommon_135.Location = new System.Drawing.Point(10, 133);
			this._chkCommon_135.Name = "_chkCommon_135";
			this._chkCommon_135.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkCommon_135.Size = new System.Drawing.Size(98, 17);
			this._chkCommon_135.TabIndex = 250;
			this._chkCommon_135.TabStop = true;
			this._chkCommon_135.Text = "Overwrite Price";
			this._chkCommon_135.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_135.Visible = true;
			this._chkCommon_135.CheckStateChanged += new System.EventHandler(this.chkCommon_CheckStateChanged);
			// 
			// _chkCommon_134
			// 
			this._chkCommon_134.AllowDrop = true;
			this._chkCommon_134.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkCommon_134.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._chkCommon_134.CausesValidation = true;
			this._chkCommon_134.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_134.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkCommon_134.Enabled = true;
			this._chkCommon_134.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkCommon_134.Location = new System.Drawing.Point(10, 116);
			this._chkCommon_134.Name = "_chkCommon_134";
			this._chkCommon_134.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkCommon_134.Size = new System.Drawing.Size(254, 17);
			this._chkCommon_134.TabIndex = 248;
			this._chkCommon_134.TabStop = true;
			this._chkCommon_134.Text = "Import Cash Credit Information";
			this._chkCommon_134.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_134.Visible = true;
			this._chkCommon_134.CheckStateChanged += new System.EventHandler(this.chkCommon_CheckStateChanged);
			// 
			// _chkCommon_117
			// 
			this._chkCommon_117.AllowDrop = true;
			this._chkCommon_117.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkCommon_117.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._chkCommon_117.CausesValidation = true;
			this._chkCommon_117.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_117.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkCommon_117.Enabled = true;
			this._chkCommon_117.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkCommon_117.Location = new System.Drawing.Point(10, 48);
			this._chkCommon_117.Name = "_chkCommon_117";
			this._chkCommon_117.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkCommon_117.Size = new System.Drawing.Size(172, 17);
			this._chkCommon_117.TabIndex = 17;
			this._chkCommon_117.TabStop = true;
			this._chkCommon_117.Text = "Enable Discount When Linked";
			this._chkCommon_117.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_117.Visible = true;
			this._chkCommon_117.CheckStateChanged += new System.EventHandler(this.chkCommon_CheckStateChanged);
			// 
			// _chkCommon_118
			// 
			this._chkCommon_118.AllowDrop = true;
			this._chkCommon_118.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkCommon_118.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._chkCommon_118.CausesValidation = true;
			this._chkCommon_118.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_118.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkCommon_118.Enabled = true;
			this._chkCommon_118.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkCommon_118.Location = new System.Drawing.Point(10, 65);
			this._chkCommon_118.Name = "_chkCommon_118";
			this._chkCommon_118.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkCommon_118.Size = new System.Drawing.Size(162, 17);
			this._chkCommon_118.TabIndex = 18;
			this._chkCommon_118.TabStop = true;
			this._chkCommon_118.Text = "Enable Amount When Linked";
			this._chkCommon_118.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_118.Visible = true;
			this._chkCommon_118.CheckStateChanged += new System.EventHandler(this.chkCommon_CheckStateChanged);
			// 
			// _chkCommon_119
			// 
			this._chkCommon_119.AllowDrop = true;
			this._chkCommon_119.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkCommon_119.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._chkCommon_119.CausesValidation = true;
			this._chkCommon_119.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_119.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkCommon_119.Enabled = true;
			this._chkCommon_119.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkCommon_119.Location = new System.Drawing.Point(10, 82);
			this._chkCommon_119.Name = "_chkCommon_119";
			this._chkCommon_119.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkCommon_119.Size = new System.Drawing.Size(180, 17);
			this._chkCommon_119.TabIndex = 19;
			this._chkCommon_119.TabStop = true;
			this._chkCommon_119.Text = "Enable Cash/Credit When Linked";
			this._chkCommon_119.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_119.Visible = true;
			this._chkCommon_119.CheckStateChanged += new System.EventHandler(this.chkCommon_CheckStateChanged);
			// 
			// _chkCommon_116
			// 
			this._chkCommon_116.AllowDrop = true;
			this._chkCommon_116.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkCommon_116.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._chkCommon_116.CausesValidation = true;
			this._chkCommon_116.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_116.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkCommon_116.Enabled = true;
			this._chkCommon_116.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkCommon_116.Location = new System.Drawing.Point(10, 14);
			this._chkCommon_116.Name = "_chkCommon_116";
			this._chkCommon_116.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkCommon_116.Size = new System.Drawing.Size(152, 17);
			this._chkCommon_116.TabIndex = 15;
			this._chkCommon_116.TabStop = true;
			this._chkCommon_116.Text = "Enable Rate When Linked";
			this._chkCommon_116.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_116.Visible = true;
			this._chkCommon_116.CheckStateChanged += new System.EventHandler(this.chkCommon_CheckStateChanged);
			// 
			// _chkCommon_120
			// 
			this._chkCommon_120.AllowDrop = true;
			this._chkCommon_120.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkCommon_120.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._chkCommon_120.CausesValidation = true;
			this._chkCommon_120.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_120.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkCommon_120.Enabled = true;
			this._chkCommon_120.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkCommon_120.Location = new System.Drawing.Point(10, 31);
			this._chkCommon_120.Name = "_chkCommon_120";
			this._chkCommon_120.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkCommon_120.Size = new System.Drawing.Size(210, 17);
			this._chkCommon_120.TabIndex = 16;
			this._chkCommon_120.TabStop = true;
			this._chkCommon_120.Text = "Enable Percent Discount When Linked";
			this._chkCommon_120.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_120.Visible = true;
			this._chkCommon_120.CheckStateChanged += new System.EventHandler(this.chkCommon_CheckStateChanged);
			// 
			// _chkCommon_77
			// 
			this._chkCommon_77.AllowDrop = true;
			this._chkCommon_77.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkCommon_77.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._chkCommon_77.CausesValidation = true;
			this._chkCommon_77.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_77.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkCommon_77.Enabled = true;
			this._chkCommon_77.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkCommon_77.Location = new System.Drawing.Point(10, 99);
			this._chkCommon_77.Name = "_chkCommon_77";
			this._chkCommon_77.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkCommon_77.Size = new System.Drawing.Size(254, 17);
			this._chkCommon_77.TabIndex = 20;
			this._chkCommon_77.TabStop = true;
			this._chkCommon_77.Text = "Allow Excess Quantity When Linked";
			this._chkCommon_77.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_77.Visible = true;
			this._chkCommon_77.CheckStateChanged += new System.EventHandler(this.chkCommon_CheckStateChanged);
			// 
			// _fraCommon_21
			// 
			this._fraCommon_21.AllowDrop = true;
			this._fraCommon_21.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._fraCommon_21.Controls.Add(this._chkCommon_82);
			this._fraCommon_21.Controls.Add(this._chkCommon_80);
			this._fraCommon_21.Controls.Add(this._chkCommon_78);
			this._fraCommon_21.Enabled = true;
			this._fraCommon_21.ForeColor = System.Drawing.SystemColors.WindowText;
			this._fraCommon_21.Location = new System.Drawing.Point(38, 192);
			this._fraCommon_21.Name = "_fraCommon_21";
			this._fraCommon_21.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._fraCommon_21.Size = new System.Drawing.Size(311, 55);
			this._fraCommon_21.TabIndex = 203;
			this._fraCommon_21.Text = "Links";
			this._fraCommon_21.Visible = true;
			// 
			// _chkCommon_82
			// 
			this._chkCommon_82.AllowDrop = true;
			this._chkCommon_82.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkCommon_82.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._chkCommon_82.CausesValidation = true;
			this._chkCommon_82.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_82.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkCommon_82.Enabled = true;
			this._chkCommon_82.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkCommon_82.Location = new System.Drawing.Point(158, 14);
			this._chkCommon_82.Name = "_chkCommon_82";
			this._chkCommon_82.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkCommon_82.Size = new System.Drawing.Size(148, 17);
			this._chkCommon_82.TabIndex = 222;
			this._chkCommon_82.TabStop = true;
			this._chkCommon_82.Text = "Allow Direct Transaction";
			this._chkCommon_82.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_82.Visible = false;
			this._chkCommon_82.CheckStateChanged += new System.EventHandler(this.chkCommon_CheckStateChanged);
			// 
			// _chkCommon_80
			// 
			this._chkCommon_80.AllowDrop = true;
			this._chkCommon_80.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkCommon_80.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._chkCommon_80.CausesValidation = true;
			this._chkCommon_80.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_80.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkCommon_80.Enabled = true;
			this._chkCommon_80.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkCommon_80.Location = new System.Drawing.Point(32, 34);
			this._chkCommon_80.Name = "_chkCommon_80";
			this._chkCommon_80.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkCommon_80.Size = new System.Drawing.Size(218, 17);
			this._chkCommon_80.TabIndex = 9;
			this._chkCommon_80.TabStop = true;
			this._chkCommon_80.Text = "Bind To Parent Header Location";
			this._chkCommon_80.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_80.Visible = true;
			this._chkCommon_80.CheckStateChanged += new System.EventHandler(this.chkCommon_CheckStateChanged);
			// 
			// _chkCommon_78
			// 
			this._chkCommon_78.AllowDrop = true;
			this._chkCommon_78.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkCommon_78.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._chkCommon_78.CausesValidation = true;
			this._chkCommon_78.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_78.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkCommon_78.Enabled = true;
			this._chkCommon_78.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkCommon_78.Location = new System.Drawing.Point(14, 14);
			this._chkCommon_78.Name = "_chkCommon_78";
			this._chkCommon_78.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkCommon_78.Size = new System.Drawing.Size(104, 17);
			this._chkCommon_78.TabIndex = 8;
			this._chkCommon_78.TabStop = true;
			this._chkCommon_78.Text = "Bind To Parent";
			this._chkCommon_78.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_78.Visible = true;
			this._chkCommon_78.CheckStateChanged += new System.EventHandler(this.chkCommon_CheckStateChanged);
			// 
			// _chkCommon_81
			// 
			this._chkCommon_81.AllowDrop = true;
			this._chkCommon_81.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkCommon_81.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._chkCommon_81.CausesValidation = true;
			this._chkCommon_81.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_81.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkCommon_81.Enabled = false;
			this._chkCommon_81.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkCommon_81.Location = new System.Drawing.Point(400, 234);
			this._chkCommon_81.Name = "_chkCommon_81";
			this._chkCommon_81.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkCommon_81.Size = new System.Drawing.Size(304, 17);
			this._chkCommon_81.TabIndex = 23;
			this._chkCommon_81.TabStop = true;
			this._chkCommon_81.Text = "Enable Auto Generate Linked Voucher for Cash Transaction";
			this._chkCommon_81.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_81.Visible = true;
			this._chkCommon_81.CheckStateChanged += new System.EventHandler(this.chkCommon_CheckStateChanged);
			// 
			// _chkCommon_79
			// 
			this._chkCommon_79.AllowDrop = true;
			this._chkCommon_79.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkCommon_79.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._chkCommon_79.CausesValidation = true;
			this._chkCommon_79.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_79.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkCommon_79.Enabled = true;
			this._chkCommon_79.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkCommon_79.Location = new System.Drawing.Point(400, 217);
			this._chkCommon_79.Name = "_chkCommon_79";
			this._chkCommon_79.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkCommon_79.Size = new System.Drawing.Size(232, 17);
			this._chkCommon_79.TabIndex = 22;
			this._chkCommon_79.TabStop = true;
			this._chkCommon_79.Text = "Auto Generate Linked Voucher All Location";
			this._chkCommon_79.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_79.Visible = true;
			this._chkCommon_79.CheckStateChanged += new System.EventHandler(this.chkCommon_CheckStateChanged);
			// 
			// _chkCommon_76
			// 
			this._chkCommon_76.AllowDrop = true;
			this._chkCommon_76.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkCommon_76.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._chkCommon_76.CausesValidation = true;
			this._chkCommon_76.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_76.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkCommon_76.Enabled = true;
			this._chkCommon_76.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkCommon_76.Location = new System.Drawing.Point(118, 314);
			this._chkCommon_76.Name = "_chkCommon_76";
			this._chkCommon_76.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkCommon_76.Size = new System.Drawing.Size(252, 17);
			this._chkCommon_76.TabIndex = 14;
			this._chkCommon_76.TabStop = true;
			this._chkCommon_76.Text = "Auto Post Stock Generate Linked Voucher Type";
			this._chkCommon_76.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_76.Visible = true;
			this._chkCommon_76.CheckStateChanged += new System.EventHandler(this.chkCommon_CheckStateChanged);
			// 
			// _chkCommon_74
			// 
			this._chkCommon_74.AllowDrop = true;
			this._chkCommon_74.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkCommon_74.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._chkCommon_74.CausesValidation = true;
			this._chkCommon_74.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_74.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkCommon_74.Enabled = true;
			this._chkCommon_74.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkCommon_74.Location = new System.Drawing.Point(400, 200);
			this._chkCommon_74.Name = "_chkCommon_74";
			this._chkCommon_74.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkCommon_74.Size = new System.Drawing.Size(172, 17);
			this._chkCommon_74.TabIndex = 21;
			this._chkCommon_74.TabStop = true;
			this._chkCommon_74.Text = "Auto Generate Linked Voucher";
			this._chkCommon_74.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_74.Visible = true;
			this._chkCommon_74.CheckStateChanged += new System.EventHandler(this.chkCommon_CheckStateChanged);
			// 
			// _fraCommon_18
			// 
			this._fraCommon_18.AllowDrop = true;
			this._fraCommon_18.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._fraCommon_18.Controls.Add(this._lblCommon_18);
			this._fraCommon_18.Controls.Add(this._lblCommon_19);
			this._fraCommon_18.Controls.Add(this._lblCommon_20);
			this._fraCommon_18.Controls.Add(this._lblCommon_21);
			this._fraCommon_18.Controls.Add(this._lblCommon_22);
			this._fraCommon_18.Controls.Add(this._lblCommon_23);
			this._fraCommon_18.Controls.Add(this._txtCommon_32);
			this._fraCommon_18.Controls.Add(this._txtCommon_31);
			this._fraCommon_18.Controls.Add(this._txtCommonLabel_11);
			this._fraCommon_18.Controls.Add(this._txtCommonLabel_12);
			this._fraCommon_18.Controls.Add(this._txtCommon_28);
			this._fraCommon_18.Controls.Add(this._txtCommon_29);
			this._fraCommon_18.Controls.Add(this._txtCommon_30);
			this._fraCommon_18.Controls.Add(this._txtCommon_33);
			this._fraCommon_18.Enabled = true;
			this._fraCommon_18.ForeColor = System.Drawing.SystemColors.WindowText;
			this._fraCommon_18.Location = new System.Drawing.Point(32, 22);
			this._fraCommon_18.Name = "_fraCommon_18";
			this._fraCommon_18.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._fraCommon_18.Size = new System.Drawing.Size(341, 147);
			this._fraCommon_18.TabIndex = 181;
			this._fraCommon_18.Text = "Legacy  Links ";
			this._fraCommon_18.Visible = true;
			// 
			// _lblCommon_18
			// 
			this._lblCommon_18.AllowDrop = true;
			this._lblCommon_18.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._lblCommon_18.Text = "ICS Master Table Name";
			this._lblCommon_18.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_18.Location = new System.Drawing.Point(10, 19);
			this._lblCommon_18.Name = "_lblCommon_18";
			this._lblCommon_18.Size = new System.Drawing.Size(111, 14);
			this._lblCommon_18.TabIndex = 185;
			// 
			// _lblCommon_19
			// 
			this._lblCommon_19.AllowDrop = true;
			this._lblCommon_19.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._lblCommon_19.Text = "ICS Details Table Name";
			this._lblCommon_19.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_19.Location = new System.Drawing.Point(8, 40);
			this._lblCommon_19.Name = "_lblCommon_19";
			this._lblCommon_19.Size = new System.Drawing.Size(110, 14);
			this._lblCommon_19.TabIndex = 186;
			// 
			// _lblCommon_20
			// 
			this._lblCommon_20.AllowDrop = true;
			this._lblCommon_20.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._lblCommon_20.Text = "ICS Parent Masters Table Name";
			this._lblCommon_20.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_20.Location = new System.Drawing.Point(8, 61);
			this._lblCommon_20.Name = "_lblCommon_20";
			this._lblCommon_20.Size = new System.Drawing.Size(151, 14);
			this._lblCommon_20.TabIndex = 187;
			// 
			// _lblCommon_21
			// 
			this._lblCommon_21.AllowDrop = true;
			this._lblCommon_21.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._lblCommon_21.Text = "ICS Parent Details Table Name";
			this._lblCommon_21.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_21.Location = new System.Drawing.Point(8, 82);
			this._lblCommon_21.Name = "_lblCommon_21";
			this._lblCommon_21.Size = new System.Drawing.Size(144, 14);
			this._lblCommon_21.TabIndex = 188;
			// 
			// _lblCommon_22
			// 
			this._lblCommon_22.AllowDrop = true;
			this._lblCommon_22.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._lblCommon_22.Text = "Parent ICS Voucher Type Code";
			this._lblCommon_22.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_22.Location = new System.Drawing.Point(8, 103);
			this._lblCommon_22.Name = "_lblCommon_22";
			this._lblCommon_22.Size = new System.Drawing.Size(150, 14);
			this._lblCommon_22.TabIndex = 189;
			// 
			// _lblCommon_23
			// 
			this._lblCommon_23.AllowDrop = true;
			this._lblCommon_23.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._lblCommon_23.Text = "Child ICS Voucher Type Code";
			this._lblCommon_23.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_23.Location = new System.Drawing.Point(8, 124);
			this._lblCommon_23.Name = "_lblCommon_23";
			this._lblCommon_23.Size = new System.Drawing.Size(142, 14);
			this._lblCommon_23.TabIndex = 190;
			// 
			// _txtCommon_32
			// 
			this._txtCommon_32.AllowDrop = true;
			this._txtCommon_32.BackColor = System.Drawing.Color.White;
			// this._txtCommon_32.bolNumericOnly = true;
			this._txtCommon_32.ForeColor = System.Drawing.Color.Black;
			this._txtCommon_32.Location = new System.Drawing.Point(170, 100);
			this._txtCommon_32.Name = "_txtCommon_32";
			// this._txtCommon_32.ShowButton = true;
			this._txtCommon_32.Size = new System.Drawing.Size(47, 19);
			this._txtCommon_32.TabIndex = 4;
			this._txtCommon_32.Text = "";
			// this.this._txtCommon_32.Change += new System.Windows.Forms.TextBox.ChangeHandler(this.txtCommon_Change);
			// this.this._txtCommon_32.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommon_DropButtonClick);
			// this._txtCommon_32.Leave += new System.EventHandler(this.txtCommon_Leave);
			// 
			// _txtCommon_31
			// 
			this._txtCommon_31.AllowDrop = true;
			this._txtCommon_31.BackColor = System.Drawing.Color.White;
			// this._txtCommon_31.bolNumericOnly = true;
			this._txtCommon_31.ForeColor = System.Drawing.Color.Black;
			this._txtCommon_31.Location = new System.Drawing.Point(170, 121);
			this._txtCommon_31.Name = "_txtCommon_31";
			// this._txtCommon_31.ShowButton = true;
			this._txtCommon_31.Size = new System.Drawing.Size(47, 19);
			this._txtCommon_31.TabIndex = 6;
			this._txtCommon_31.Text = "";
			// this.this._txtCommon_31.Change += new System.Windows.Forms.TextBox.ChangeHandler(this.txtCommon_Change);
			// this.this._txtCommon_31.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommon_DropButtonClick);
			// this._txtCommon_31.Leave += new System.EventHandler(this.txtCommon_Leave);
			// 
			// _txtCommonLabel_11
			// 
			this._txtCommonLabel_11.AllowDrop = true;
			this._txtCommonLabel_11.Location = new System.Drawing.Point(218, 100);
			this._txtCommonLabel_11.Name = "_txtCommonLabel_11";
			this._txtCommonLabel_11.Size = new System.Drawing.Size(109, 19);
			this._txtCommonLabel_11.TabIndex = 5;
			// 
			// _txtCommonLabel_12
			// 
			this._txtCommonLabel_12.AllowDrop = true;
			this._txtCommonLabel_12.Location = new System.Drawing.Point(218, 121);
			this._txtCommonLabel_12.Name = "_txtCommonLabel_12";
			this._txtCommonLabel_12.Size = new System.Drawing.Size(109, 19);
			this._txtCommonLabel_12.TabIndex = 7;
			// 
			// _txtCommon_28
			// 
			this._txtCommon_28.AllowDrop = true;
			this._txtCommon_28.BackColor = System.Drawing.Color.FromArgb(239, 239, 239);
			// this._txtCommon_28.bolAllowDecimal = false;
			this._txtCommon_28.Enabled = false;
			this._txtCommon_28.ForeColor = System.Drawing.Color.Black;
			this._txtCommon_28.Location = new System.Drawing.Point(218, 19);
			// this._txtCommon_28.mDropDownType = (System.Windows.Forms.TextBox.DropDownTypes) 0;
			this._txtCommon_28.Name = "_txtCommon_28";
			this._txtCommon_28.Size = new System.Drawing.Size(109, 19);
			this._txtCommon_28.TabIndex = 0;
			this._txtCommon_28.Text = "";
			// this.this._txtCommon_28.Change += new System.Windows.Forms.TextBox.ChangeHandler(this.txtCommon_Change);
			// this.this._txtCommon_28.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommon_DropButtonClick);
			// this._txtCommon_28.Leave += new System.EventHandler(this.txtCommon_Leave);
			// 
			// _txtCommon_29
			// 
			this._txtCommon_29.AllowDrop = true;
			this._txtCommon_29.BackColor = System.Drawing.Color.FromArgb(239, 239, 239);
			// this._txtCommon_29.bolAllowDecimal = false;
			this._txtCommon_29.Enabled = false;
			this._txtCommon_29.ForeColor = System.Drawing.Color.Black;
			this._txtCommon_29.Location = new System.Drawing.Point(218, 40);
			// this._txtCommon_29.mDropDownType = (System.Windows.Forms.TextBox.DropDownTypes) 0;
			this._txtCommon_29.Name = "_txtCommon_29";
			this._txtCommon_29.Size = new System.Drawing.Size(109, 19);
			this._txtCommon_29.TabIndex = 1;
			this._txtCommon_29.Text = "";
			// this.this._txtCommon_29.Change += new System.Windows.Forms.TextBox.ChangeHandler(this.txtCommon_Change);
			// this.this._txtCommon_29.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommon_DropButtonClick);
			// this._txtCommon_29.Leave += new System.EventHandler(this.txtCommon_Leave);
			// 
			// _txtCommon_30
			// 
			this._txtCommon_30.AllowDrop = true;
			this._txtCommon_30.BackColor = System.Drawing.Color.White;
			// this._txtCommon_30.bolAllowDecimal = false;
			this._txtCommon_30.ForeColor = System.Drawing.Color.Black;
			this._txtCommon_30.Location = new System.Drawing.Point(218, 60);
			// this._txtCommon_30.mDropDownType = (System.Windows.Forms.TextBox.DropDownTypes) 0;
			this._txtCommon_30.Name = "_txtCommon_30";
			this._txtCommon_30.Size = new System.Drawing.Size(109, 19);
			this._txtCommon_30.TabIndex = 2;
			this._txtCommon_30.Text = "";
			// this.this._txtCommon_30.Change += new System.Windows.Forms.TextBox.ChangeHandler(this.txtCommon_Change);
			// this.this._txtCommon_30.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommon_DropButtonClick);
			// this._txtCommon_30.Leave += new System.EventHandler(this.txtCommon_Leave);
			// 
			// _txtCommon_33
			// 
			this._txtCommon_33.AllowDrop = true;
			this._txtCommon_33.BackColor = System.Drawing.Color.White;
			// this._txtCommon_33.bolAllowDecimal = false;
			this._txtCommon_33.ForeColor = System.Drawing.Color.Black;
			this._txtCommon_33.Location = new System.Drawing.Point(218, 80);
			// this._txtCommon_33.mDropDownType = (System.Windows.Forms.TextBox.DropDownTypes) 0;
			this._txtCommon_33.Name = "_txtCommon_33";
			this._txtCommon_33.Size = new System.Drawing.Size(109, 19);
			this._txtCommon_33.TabIndex = 3;
			this._txtCommon_33.Text = "";
			// this.this._txtCommon_33.Change += new System.Windows.Forms.TextBox.ChangeHandler(this.txtCommon_Change);
			// this.this._txtCommon_33.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommon_DropButtonClick);
			// this._txtCommon_33.Leave += new System.EventHandler(this.txtCommon_Leave);
			// 
			// _lblCommon_43
			// 
			this._lblCommon_43.AllowDrop = true;
			this._lblCommon_43.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._lblCommon_43.Text = "Dented Stock Generated Linked Voucher";
			this._lblCommon_43.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_43.Location = new System.Drawing.Point(8, 295);
			this._lblCommon_43.Name = "_lblCommon_43";
			this._lblCommon_43.Size = new System.Drawing.Size(197, 14);
			this._lblCommon_43.TabIndex = 201;
			// 
			// _txtCommonLabel_29
			// 
			this._txtCommonLabel_29.AllowDrop = true;
			this._txtCommonLabel_29.Location = new System.Drawing.Point(261, 293);
			this._txtCommonLabel_29.Name = "_txtCommonLabel_29";
			this._txtCommonLabel_29.Size = new System.Drawing.Size(109, 19);
			this._txtCommonLabel_29.TabIndex = 13;
			// 
			// _lblCommon_34
			// 
			this._lblCommon_34.AllowDrop = true;
			this._lblCommon_34.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._lblCommon_34.Text = "Linked Assembly Group Adjust Voucher";
			this._lblCommon_34.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_34.Location = new System.Drawing.Point(8, 276);
			this._lblCommon_34.Name = "_lblCommon_34";
			this._lblCommon_34.Size = new System.Drawing.Size(194, 14);
			this._lblCommon_34.TabIndex = 202;
			// 
			// _txtCommonLabel_0
			// 
			this._txtCommonLabel_0.AllowDrop = true;
			this._txtCommonLabel_0.Location = new System.Drawing.Point(261, 274);
			this._txtCommonLabel_0.Name = "_txtCommonLabel_0";
			this._txtCommonLabel_0.Size = new System.Drawing.Size(109, 19);
			this._txtCommonLabel_0.TabIndex = 11;
			// 
			// _txtCommon_17
			// 
			this._txtCommon_17.AllowDrop = true;
			this._txtCommon_17.BackColor = System.Drawing.Color.White;
			// this._txtCommon_17.bolNumericOnly = true;
			this._txtCommon_17.ForeColor = System.Drawing.Color.Black;
			this._txtCommon_17.Location = new System.Drawing.Point(212, 293);
			this._txtCommon_17.Name = "_txtCommon_17";
			// this._txtCommon_17.ShowButton = true;
			this._txtCommon_17.Size = new System.Drawing.Size(47, 19);
			this._txtCommon_17.TabIndex = 12;
			this._txtCommon_17.Text = "";
			// this.this._txtCommon_17.Change += new System.Windows.Forms.TextBox.ChangeHandler(this.txtCommon_Change);
			// this.this._txtCommon_17.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommon_DropButtonClick);
			// this._txtCommon_17.Leave += new System.EventHandler(this.txtCommon_Leave);
			// 
			// _txtCommon_15
			// 
			this._txtCommon_15.AllowDrop = true;
			this._txtCommon_15.BackColor = System.Drawing.Color.White;
			// this._txtCommon_15.bolNumericOnly = true;
			this._txtCommon_15.ForeColor = System.Drawing.Color.Black;
			this._txtCommon_15.Location = new System.Drawing.Point(212, 274);
			this._txtCommon_15.Name = "_txtCommon_15";
			// this._txtCommon_15.ShowButton = true;
			this._txtCommon_15.Size = new System.Drawing.Size(47, 19);
			this._txtCommon_15.TabIndex = 10;
			this._txtCommon_15.Text = "";
			// this.this._txtCommon_15.Change += new System.Windows.Forms.TextBox.ChangeHandler(this.txtCommon_Change);
			// this.this._txtCommon_15.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommon_DropButtonClick);
			// this._txtCommon_15.Leave += new System.EventHandler(this.txtCommon_Leave);
			// 
			// _fraCommon_10
			// 
			this._fraCommon_10.AllowDrop = true;
			this._fraCommon_10.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._fraCommon_10.Controls.Add(this._fraCommon_3);
			this._fraCommon_10.Controls.Add(this._lblCommon_33);
			this._fraCommon_10.Controls.Add(this._cmbCommon_2);
			this._fraCommon_10.Controls.Add(this._lblCommon_38);
			this._fraCommon_10.Controls.Add(this._lblCommon_39);
			this._fraCommon_10.Controls.Add(this._lblCommon_41);
			this._fraCommon_10.Controls.Add(this._lblCommon_42);
			this._fraCommon_10.Controls.Add(this._lblCommon_37);
			this._fraCommon_10.Controls.Add(this._txtCommon_23);
			this._fraCommon_10.Controls.Add(this._txtCommon_24);
			this._fraCommon_10.Controls.Add(this._txtCommon_25);
			this._fraCommon_10.Controls.Add(this._txtCommon_26);
			this._fraCommon_10.Controls.Add(this._txtCommon_27);
			this._fraCommon_10.Controls.Add(this._lblCommon_0);
			this._fraCommon_10.Controls.Add(this._txtCommon_34);
			this._fraCommon_10.Controls.Add(this._txtCommon_35);
			this._fraCommon_10.Controls.Add(this._lblCommon_13);
			this._fraCommon_10.Controls.Add(this._txtCommon_11);
			this._fraCommon_10.Controls.Add(this._lblCommon_16);
			this._fraCommon_10.Controls.Add(this._txtCommon_14);
			this._fraCommon_10.Controls.Add(this._lblCommon_31);
			this._fraCommon_10.Controls.Add(this._txtCommon_36);
			this._fraCommon_10.Controls.Add(this._lblCommon_45);
			this._fraCommon_10.Controls.Add(this._txtCommon_37);
			this._fraCommon_10.Enabled = true;
			this._fraCommon_10.ForeColor = System.Drawing.SystemColors.WindowText;
			this._fraCommon_10.Location = new System.Drawing.Point(808, 23);
			this._fraCommon_10.Name = "_fraCommon_10";
			this._fraCommon_10.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._fraCommon_10.Size = new System.Drawing.Size(745, 335);
			this._fraCommon_10.TabIndex = 171;
			this._fraCommon_10.Text = "Frame1";
			this._fraCommon_10.Visible = true;
			// 
			// _fraCommon_3
			// 
			this._fraCommon_3.AllowDrop = true;
			this._fraCommon_3.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._fraCommon_3.Controls.Add(this._chkCommon_92);
			this._fraCommon_3.Controls.Add(this._txtCommonLabel_6);
			this._fraCommon_3.Controls.Add(this._lblCommon_40);
			this._fraCommon_3.Controls.Add(this._txtCommon_16);
			this._fraCommon_3.Enabled = true;
			this._fraCommon_3.ForeColor = System.Drawing.SystemColors.WindowText;
			this._fraCommon_3.Location = new System.Drawing.Point(24, 12);
			this._fraCommon_3.Name = "_fraCommon_3";
			this._fraCommon_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._fraCommon_3.Size = new System.Drawing.Size(491, 67);
			this._fraCommon_3.TabIndex = 172;
			this._fraCommon_3.Text = "Revision";
			this._fraCommon_3.Visible = true;
			// 
			// _chkCommon_92
			// 
			this._chkCommon_92.AllowDrop = true;
			this._chkCommon_92.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkCommon_92.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._chkCommon_92.CausesValidation = true;
			this._chkCommon_92.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_92.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkCommon_92.Enabled = true;
			this._chkCommon_92.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkCommon_92.Location = new System.Drawing.Point(14, 18);
			this._chkCommon_92.Name = "_chkCommon_92";
			this._chkCommon_92.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkCommon_92.Size = new System.Drawing.Size(145, 17);
			this._chkCommon_92.TabIndex = 143;
			this._chkCommon_92.TabStop = true;
			this._chkCommon_92.Text = "Enable Revision";
			this._chkCommon_92.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_92.Visible = true;
			this._chkCommon_92.CheckStateChanged += new System.EventHandler(this.chkCommon_CheckStateChanged);
			// 
			// _txtCommonLabel_6
			// 
			this._txtCommonLabel_6.AllowDrop = true;
			this._txtCommonLabel_6.Enabled = false;
			this._txtCommonLabel_6.Location = new System.Drawing.Point(274, 38);
			this._txtCommonLabel_6.Name = "_txtCommonLabel_6";
			this._txtCommonLabel_6.Size = new System.Drawing.Size(201, 19);
			this._txtCommonLabel_6.TabIndex = 193;
			// 
			// _lblCommon_40
			// 
			this._lblCommon_40.AllowDrop = true;
			this._lblCommon_40.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._lblCommon_40.Text = "Revised History Voucher Type";
			this._lblCommon_40.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_40.Location = new System.Drawing.Point(14, 42);
			this._lblCommon_40.Name = "_lblCommon_40";
			this._lblCommon_40.Size = new System.Drawing.Size(148, 14);
			this._lblCommon_40.TabIndex = 198;
			// 
			// _txtCommon_16
			// 
			this._txtCommon_16.AllowDrop = true;
			this._txtCommon_16.BackColor = System.Drawing.Color.FromArgb(239, 239, 239);
			// this._txtCommon_16.bolAllowDecimal = false;
			this._txtCommon_16.Enabled = false;
			this._txtCommon_16.ForeColor = System.Drawing.Color.Black;
			this._txtCommon_16.Location = new System.Drawing.Point(172, 38);
			this._txtCommon_16.MaxLength = 10;
			// this._txtCommon_16.mDropDownType = System.Windows.Forms.TextBox.DropDownTypes.ddtNextNumber;
			this._txtCommon_16.Name = "_txtCommon_16";
			// this._txtCommon_16.ShowButton = true;
			this._txtCommon_16.Size = new System.Drawing.Size(101, 19);
			this._txtCommon_16.TabIndex = 144;
			this._txtCommon_16.Text = "";
			// this.this._txtCommon_16.Change += new System.Windows.Forms.TextBox.ChangeHandler(this.txtCommon_Change);
			// this.this._txtCommon_16.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommon_DropButtonClick);
			// this._txtCommon_16.Leave += new System.EventHandler(this.txtCommon_Leave);
			// 
			// _lblCommon_33
			// 
			this._lblCommon_33.AllowDrop = true;
			this._lblCommon_33.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._lblCommon_33.Text = "Reference Number Generation Method";
			this._lblCommon_33.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_33.Location = new System.Drawing.Point(26, 85);
			this._lblCommon_33.Name = "_lblCommon_33";
			this._lblCommon_33.Size = new System.Drawing.Size(185, 14);
			this._lblCommon_33.TabIndex = 192;
			// 
			// _cmbCommon_2
			// 
			this._cmbCommon_2.AllowDrop = true;
			this._cmbCommon_2.Location = new System.Drawing.Point(216, 82);
			this._cmbCommon_2.Name = "_cmbCommon_2";
			this._cmbCommon_2.Size = new System.Drawing.Size(129, 21);
			this._cmbCommon_2.TabIndex = 145;
			// 
			// _lblCommon_38
			// 
			this._lblCommon_38.AllowDrop = true;
			this._lblCommon_38.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._lblCommon_38.Text = "Additional Cash Find Where Clause";
			this._lblCommon_38.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_38.Location = new System.Drawing.Point(26, 129);
			this._lblCommon_38.Name = "_lblCommon_38";
			this._lblCommon_38.Size = new System.Drawing.Size(169, 14);
			this._lblCommon_38.TabIndex = 196;
			// 
			// _lblCommon_39
			// 
			this._lblCommon_39.AllowDrop = true;
			this._lblCommon_39.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._lblCommon_39.Text = "Voucher Grid Back Color";
			this._lblCommon_39.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_39.Location = new System.Drawing.Point(26, 150);
			this._lblCommon_39.Name = "_lblCommon_39";
			this._lblCommon_39.Size = new System.Drawing.Size(120, 14);
			this._lblCommon_39.TabIndex = 197;
			// 
			// _lblCommon_41
			// 
			this._lblCommon_41.AllowDrop = true;
			this._lblCommon_41.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._lblCommon_41.Text = "Party Name Caption";
			this._lblCommon_41.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_41.Location = new System.Drawing.Point(26, 192);
			this._lblCommon_41.Name = "_lblCommon_41";
			this._lblCommon_41.Size = new System.Drawing.Size(94, 14);
			this._lblCommon_41.TabIndex = 199;
			// 
			// _lblCommon_42
			// 
			this._lblCommon_42.AllowDrop = true;
			this._lblCommon_42.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._lblCommon_42.Text = "Party Name Caption (Arabic)";
			this._lblCommon_42.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_42.Location = new System.Drawing.Point(26, 213);
			this._lblCommon_42.Name = "_lblCommon_42";
			this._lblCommon_42.Size = new System.Drawing.Size(137, 14);
			this._lblCommon_42.TabIndex = 200;
			// 
			// _lblCommon_37
			// 
			this._lblCommon_37.AllowDrop = true;
			this._lblCommon_37.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._lblCommon_37.Text = "Additional Ledger Find Where Clause";
			this._lblCommon_37.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_37.Location = new System.Drawing.Point(26, 171);
			this._lblCommon_37.Name = "_lblCommon_37";
			this._lblCommon_37.Size = new System.Drawing.Size(178, 14);
			this._lblCommon_37.TabIndex = 195;
			// 
			// _txtCommon_23
			// 
			this._txtCommon_23.AllowDrop = true;
			this._txtCommon_23.BackColor = System.Drawing.Color.White;
			// this._txtCommon_23.bolAllowDecimal = false;
			this._txtCommon_23.ForeColor = System.Drawing.Color.Black;
			this._txtCommon_23.Location = new System.Drawing.Point(216, 127);
			this._txtCommon_23.Locked = true;
			// this._txtCommon_23.mDropDownType = (System.Windows.Forms.TextBox.DropDownTypes) 0;
			this._txtCommon_23.Name = "_txtCommon_23";
			this._txtCommon_23.Size = new System.Drawing.Size(191, 19);
			this._txtCommon_23.TabIndex = 146;
			this._txtCommon_23.Text = "";
			// this.this._txtCommon_23.Change += new System.Windows.Forms.TextBox.ChangeHandler(this.txtCommon_Change);
			// this.this._txtCommon_23.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommon_DropButtonClick);
			// this._txtCommon_23.Leave += new System.EventHandler(this.txtCommon_Leave);
			// 
			// _txtCommon_24
			// 
			this._txtCommon_24.AllowDrop = true;
			this._txtCommon_24.BackColor = System.Drawing.Color.White;
			// this._txtCommon_24.bolAllowDecimal = false;
			this._txtCommon_24.ForeColor = System.Drawing.Color.Black;
			this._txtCommon_24.Location = new System.Drawing.Point(216, 148);
			this._txtCommon_24.Locked = true;
			// this._txtCommon_24.mDropDownType = (System.Windows.Forms.TextBox.DropDownTypes) 0;
			this._txtCommon_24.Name = "_txtCommon_24";
			// this._txtCommon_24.ShowButton = true;
			this._txtCommon_24.Size = new System.Drawing.Size(143, 19);
			this._txtCommon_24.TabIndex = 147;
			this._txtCommon_24.Text = "";
			// this.this._txtCommon_24.Change += new System.Windows.Forms.TextBox.ChangeHandler(this.txtCommon_Change);
			// this.this._txtCommon_24.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommon_DropButtonClick);
			// this._txtCommon_24.Leave += new System.EventHandler(this.txtCommon_Leave);
			// 
			// _txtCommon_25
			// 
			this._txtCommon_25.AllowDrop = true;
			this._txtCommon_25.BackColor = System.Drawing.Color.White;
			// this._txtCommon_25.bolAllowDecimal = false;
			this._txtCommon_25.ForeColor = System.Drawing.Color.Black;
			this._txtCommon_25.Location = new System.Drawing.Point(216, 169);
			// this._txtCommon_25.mDropDownType = (System.Windows.Forms.TextBox.DropDownTypes) 0;
			this._txtCommon_25.Name = "_txtCommon_25";
			this._txtCommon_25.Size = new System.Drawing.Size(191, 19);
			this._txtCommon_25.TabIndex = 148;
			this._txtCommon_25.Text = "";
			// this.this._txtCommon_25.Change += new System.Windows.Forms.TextBox.ChangeHandler(this.txtCommon_Change);
			// this.this._txtCommon_25.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommon_DropButtonClick);
			// this._txtCommon_25.Leave += new System.EventHandler(this.txtCommon_Leave);
			// 
			// _txtCommon_26
			// 
			this._txtCommon_26.AllowDrop = true;
			this._txtCommon_26.BackColor = System.Drawing.Color.White;
			// this._txtCommon_26.bolAllowDecimal = false;
			this._txtCommon_26.ForeColor = System.Drawing.Color.Black;
			this._txtCommon_26.Location = new System.Drawing.Point(216, 190);
			// this._txtCommon_26.mDropDownType = (System.Windows.Forms.TextBox.DropDownTypes) 0;
			this._txtCommon_26.Name = "_txtCommon_26";
			this._txtCommon_26.Size = new System.Drawing.Size(191, 19);
			this._txtCommon_26.TabIndex = 149;
			this._txtCommon_26.Text = "";
			// this.this._txtCommon_26.Change += new System.Windows.Forms.TextBox.ChangeHandler(this.txtCommon_Change);
			// this.this._txtCommon_26.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommon_DropButtonClick);
			// this._txtCommon_26.Leave += new System.EventHandler(this.txtCommon_Leave);
			// 
			// _txtCommon_27
			// 
			this._txtCommon_27.AllowDrop = true;
			this._txtCommon_27.BackColor = System.Drawing.Color.White;
			// this._txtCommon_27.bolAllowDecimal = false;
			this._txtCommon_27.ForeColor = System.Drawing.Color.Black;
			this._txtCommon_27.Location = new System.Drawing.Point(216, 211);
			// this._txtCommon_27.mDropDownType = (System.Windows.Forms.TextBox.DropDownTypes) 0;
			this._txtCommon_27.Name = "_txtCommon_27";
			this._txtCommon_27.Size = new System.Drawing.Size(191, 19);
			this._txtCommon_27.TabIndex = 150;
			this._txtCommon_27.Text = "";
			// this.this._txtCommon_27.Change += new System.Windows.Forms.TextBox.ChangeHandler(this.txtCommon_Change);
			// this.this._txtCommon_27.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommon_DropButtonClick);
			// this._txtCommon_27.Leave += new System.EventHandler(this.txtCommon_Leave);
			// 
			// _lblCommon_0
			// 
			this._lblCommon_0.AllowDrop = true;
			this._lblCommon_0.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._lblCommon_0.Text = "Reference Number Caption";
			this._lblCommon_0.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_0.Location = new System.Drawing.Point(28, 108);
			this._lblCommon_0.Name = "_lblCommon_0";
			this._lblCommon_0.Size = new System.Drawing.Size(130, 14);
			this._lblCommon_0.TabIndex = 212;
			// 
			// _txtCommon_34
			// 
			this._txtCommon_34.AllowDrop = true;
			this._txtCommon_34.BackColor = System.Drawing.Color.White;
			// this._txtCommon_34.bolAllowDecimal = false;
			this._txtCommon_34.ForeColor = System.Drawing.Color.Black;
			this._txtCommon_34.Location = new System.Drawing.Point(216, 106);
			// this._txtCommon_34.mDropDownType = (System.Windows.Forms.TextBox.DropDownTypes) 0;
			this._txtCommon_34.Name = "_txtCommon_34";
			this._txtCommon_34.Size = new System.Drawing.Size(191, 19);
			this._txtCommon_34.TabIndex = 213;
			this._txtCommon_34.Text = "";
			// this.this._txtCommon_34.Change += new System.Windows.Forms.TextBox.ChangeHandler(this.txtCommon_Change);
			// this.this._txtCommon_34.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommon_DropButtonClick);
			// this._txtCommon_34.Leave += new System.EventHandler(this.txtCommon_Leave);
			// 
			// _txtCommon_35
			// 
			this._txtCommon_35.AllowDrop = true;
			this._txtCommon_35.BackColor = System.Drawing.Color.FromArgb(239, 239, 239);
			this._txtCommon_35.Enabled = false;
			this._txtCommon_35.ForeColor = System.Drawing.Color.Black;
			this._txtCommon_35.Location = new System.Drawing.Point(362, 148);
			// this._txtCommon_35.mArabicEnabled = true;
			this._txtCommon_35.MaxLength = 4;
			this._txtCommon_35.Name = "_txtCommon_35";
			this._txtCommon_35.Size = new System.Drawing.Size(46, 19);
			this._txtCommon_35.TabIndex = 214;
			this._txtCommon_35.TabStop = false;
			this._txtCommon_35.Text = "";
			// this.this._txtCommon_35.Change += new System.Windows.Forms.TextBox.ChangeHandler(this.txtCommon_Change);
			// this.this._txtCommon_35.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommon_DropButtonClick);
			// this._txtCommon_35.Leave += new System.EventHandler(this.txtCommon_Leave);
			// 
			// _lblCommon_13
			// 
			this._lblCommon_13.AllowDrop = true;
			this._lblCommon_13.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._lblCommon_13.Text = "Form Height Size";
			this._lblCommon_13.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_13.Location = new System.Drawing.Point(26, 234);
			this._lblCommon_13.Name = "_lblCommon_13";
			this._lblCommon_13.Size = new System.Drawing.Size(81, 14);
			this._lblCommon_13.TabIndex = 229;
			// 
			// _txtCommon_11
			// 
			this._txtCommon_11.AllowDrop = true;
			this._txtCommon_11.BackColor = System.Drawing.Color.White;
			// this._txtCommon_11.bolAllowDecimal = false;
			this._txtCommon_11.ForeColor = System.Drawing.Color.Black;
			this._txtCommon_11.Location = new System.Drawing.Point(216, 232);
			// this._txtCommon_11.mDropDownType = (System.Windows.Forms.TextBox.DropDownTypes) 0;
			this._txtCommon_11.Name = "_txtCommon_11";
			this._txtCommon_11.Size = new System.Drawing.Size(191, 19);
			this._txtCommon_11.TabIndex = 230;
			this._txtCommon_11.Text = "";
			// this.this._txtCommon_11.Change += new System.Windows.Forms.TextBox.ChangeHandler(this.txtCommon_Change);
			// this.this._txtCommon_11.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommon_DropButtonClick);
			// this._txtCommon_11.Leave += new System.EventHandler(this.txtCommon_Leave);
			// 
			// _lblCommon_16
			// 
			this._lblCommon_16.AllowDrop = true;
			this._lblCommon_16.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._lblCommon_16.Text = "Grid Row Height Size";
			this._lblCommon_16.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_16.Location = new System.Drawing.Point(26, 256);
			this._lblCommon_16.Name = "_lblCommon_16";
			this._lblCommon_16.Size = new System.Drawing.Size(103, 14);
			this._lblCommon_16.TabIndex = 231;
			// 
			// _txtCommon_14
			// 
			this._txtCommon_14.AllowDrop = true;
			this._txtCommon_14.BackColor = System.Drawing.Color.White;
			// this._txtCommon_14.bolAllowDecimal = false;
			this._txtCommon_14.ForeColor = System.Drawing.Color.Black;
			this._txtCommon_14.Location = new System.Drawing.Point(216, 254);
			// this._txtCommon_14.mDropDownType = (System.Windows.Forms.TextBox.DropDownTypes) 0;
			this._txtCommon_14.Name = "_txtCommon_14";
			this._txtCommon_14.Size = new System.Drawing.Size(191, 19);
			this._txtCommon_14.TabIndex = 232;
			this._txtCommon_14.Text = "";
			// this.this._txtCommon_14.Change += new System.Windows.Forms.TextBox.ChangeHandler(this.txtCommon_Change);
			// this.this._txtCommon_14.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommon_DropButtonClick);
			// this._txtCommon_14.Leave += new System.EventHandler(this.txtCommon_Leave);
			// 
			// _lblCommon_31
			// 
			this._lblCommon_31.AllowDrop = true;
			this._lblCommon_31.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._lblCommon_31.Text = "Expenses Ldgr Find Where Clause";
			this._lblCommon_31.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_31.Location = new System.Drawing.Point(26, 278);
			this._lblCommon_31.Name = "_lblCommon_31";
			this._lblCommon_31.Size = new System.Drawing.Size(167, 14);
			this._lblCommon_31.TabIndex = 233;
			// 
			// _txtCommon_36
			// 
			this._txtCommon_36.AllowDrop = true;
			this._txtCommon_36.BackColor = System.Drawing.Color.White;
			// this._txtCommon_36.bolAllowDecimal = false;
			this._txtCommon_36.ForeColor = System.Drawing.Color.Black;
			this._txtCommon_36.Location = new System.Drawing.Point(216, 276);
			// this._txtCommon_36.mDropDownType = (System.Windows.Forms.TextBox.DropDownTypes) 0;
			this._txtCommon_36.Name = "_txtCommon_36";
			this._txtCommon_36.Size = new System.Drawing.Size(191, 19);
			this._txtCommon_36.TabIndex = 234;
			this._txtCommon_36.Text = "";
			// this.this._txtCommon_36.Change += new System.Windows.Forms.TextBox.ChangeHandler(this.txtCommon_Change);
			// this.this._txtCommon_36.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommon_DropButtonClick);
			// this._txtCommon_36.Leave += new System.EventHandler(this.txtCommon_Leave);
			// 
			// _lblCommon_45
			// 
			this._lblCommon_45.AllowDrop = true;
			this._lblCommon_45.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._lblCommon_45.Text = "Product List Where Clause";
			this._lblCommon_45.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_45.Location = new System.Drawing.Point(26, 300);
			this._lblCommon_45.Name = "_lblCommon_45";
			this._lblCommon_45.Size = new System.Drawing.Size(128, 14);
			this._lblCommon_45.TabIndex = 236;
			// 
			// _txtCommon_37
			// 
			this._txtCommon_37.AllowDrop = true;
			this._txtCommon_37.BackColor = System.Drawing.Color.White;
			// this._txtCommon_37.bolAllowDecimal = false;
			this._txtCommon_37.ForeColor = System.Drawing.Color.Black;
			this._txtCommon_37.Location = new System.Drawing.Point(216, 298);
			// this._txtCommon_37.mDropDownType = (System.Windows.Forms.TextBox.DropDownTypes) 0;
			this._txtCommon_37.Name = "_txtCommon_37";
			this._txtCommon_37.Size = new System.Drawing.Size(191, 19);
			this._txtCommon_37.TabIndex = 237;
			this._txtCommon_37.Text = "";
			// this.this._txtCommon_37.Change += new System.Windows.Forms.TextBox.ChangeHandler(this.txtCommon_Change);
			// this.this._txtCommon_37.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommon_DropButtonClick);
			// this._txtCommon_37.Leave += new System.EventHandler(this.txtCommon_Leave);
			// 
			// _fraCommon_9
			// 
			this._fraCommon_9.AllowDrop = true;
			this._fraCommon_9.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._fraCommon_9.Controls.Add(this._fraCommon_20);
			this._fraCommon_9.Enabled = true;
			this._fraCommon_9.ForeColor = System.Drawing.SystemColors.WindowText;
			this._fraCommon_9.Location = new System.Drawing.Point(788, 23);
			this._fraCommon_9.Name = "_fraCommon_9";
			this._fraCommon_9.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._fraCommon_9.Size = new System.Drawing.Size(745, 335);
			this._fraCommon_9.TabIndex = 170;
			this._fraCommon_9.Text = "Frame1";
			this._fraCommon_9.Visible = true;
			// 
			// _fraCommon_20
			// 
			this._fraCommon_20.AllowDrop = true;
			this._fraCommon_20.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._fraCommon_20.Controls.Add(this._chkCommon_73);
			this._fraCommon_20.Controls.Add(this._chkCommon_108);
			this._fraCommon_20.Controls.Add(this._txtCommonLabel_17);
			this._fraCommon_20.Controls.Add(this._txtCommonLabel_19);
			this._fraCommon_20.Controls.Add(this._txtCommonLabel_20);
			this._fraCommon_20.Controls.Add(this._txtCommonLabel_22);
			this._fraCommon_20.Controls.Add(this._lblCommon_28);
			this._fraCommon_20.Controls.Add(this._lblCommon_29);
			this._fraCommon_20.Controls.Add(this._lblCommon_30);
			this._fraCommon_20.Controls.Add(this._lblCommon_36);
			this._fraCommon_20.Enabled = true;
			this._fraCommon_20.ForeColor = System.Drawing.SystemColors.WindowText;
			this._fraCommon_20.Location = new System.Drawing.Point(10, 8);
			this._fraCommon_20.Name = "_fraCommon_20";
			this._fraCommon_20.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._fraCommon_20.Size = new System.Drawing.Size(315, 175);
			this._fraCommon_20.TabIndex = 191;
			this._fraCommon_20.Text = "Last Transaction Settings";
			this._fraCommon_20.Visible = true;
			// 
			// _chkCommon_73
			// 
			this._chkCommon_73.AllowDrop = true;
			this._chkCommon_73.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkCommon_73.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._chkCommon_73.CausesValidation = true;
			this._chkCommon_73.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_73.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkCommon_73.Enabled = false;
			this._chkCommon_73.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkCommon_73.Location = new System.Drawing.Point(26, 40);
			this._chkCommon_73.Name = "_chkCommon_73";
			this._chkCommon_73.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkCommon_73.Size = new System.Drawing.Size(185, 17);
			this._chkCommon_73.TabIndex = 138;
			this._chkCommon_73.TabStop = true;
			this._chkCommon_73.Text = "Last Transaction Cash Type";
			this._chkCommon_73.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_73.Visible = true;
			this._chkCommon_73.CheckStateChanged += new System.EventHandler(this.chkCommon_CheckStateChanged);
			// 
			// _chkCommon_108
			// 
			this._chkCommon_108.AllowDrop = true;
			this._chkCommon_108.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkCommon_108.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._chkCommon_108.CausesValidation = true;
			this._chkCommon_108.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_108.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkCommon_108.Enabled = true;
			this._chkCommon_108.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkCommon_108.Location = new System.Drawing.Point(8, 20);
			this._chkCommon_108.Name = "_chkCommon_108";
			this._chkCommon_108.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkCommon_108.Size = new System.Drawing.Size(185, 17);
			this._chkCommon_108.TabIndex = 137;
			this._chkCommon_108.TabStop = true;
			this._chkCommon_108.Text = "Restore Last Transaction Settings";
			this._chkCommon_108.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_108.Visible = true;
			this._chkCommon_108.CheckStateChanged += new System.EventHandler(this.chkCommon_CheckStateChanged);
			// 
			// _txtCommonLabel_17
			// 
			this._txtCommonLabel_17.AllowDrop = true;
			this._txtCommonLabel_17.Enabled = false;
			this._txtCommonLabel_17.Location = new System.Drawing.Point(184, 64);
			this._txtCommonLabel_17.Name = "_txtCommonLabel_17";
			this._txtCommonLabel_17.Size = new System.Drawing.Size(120, 19);
			this._txtCommonLabel_17.TabIndex = 139;
			// 
			// _txtCommonLabel_19
			// 
			this._txtCommonLabel_19.AllowDrop = true;
			this._txtCommonLabel_19.Enabled = false;
			this._txtCommonLabel_19.Location = new System.Drawing.Point(184, 138);
			this._txtCommonLabel_19.Name = "_txtCommonLabel_19";
			this._txtCommonLabel_19.Size = new System.Drawing.Size(120, 19);
			this._txtCommonLabel_19.TabIndex = 142;
			// 
			// _txtCommonLabel_20
			// 
			this._txtCommonLabel_20.AllowDrop = true;
			this._txtCommonLabel_20.Enabled = false;
			this._txtCommonLabel_20.Location = new System.Drawing.Point(184, 113);
			this._txtCommonLabel_20.Name = "_txtCommonLabel_20";
			this._txtCommonLabel_20.Size = new System.Drawing.Size(120, 19);
			this._txtCommonLabel_20.TabIndex = 141;
			// 
			// _txtCommonLabel_22
			// 
			this._txtCommonLabel_22.AllowDrop = true;
			this._txtCommonLabel_22.Enabled = false;
			this._txtCommonLabel_22.Location = new System.Drawing.Point(184, 88);
			this._txtCommonLabel_22.Name = "_txtCommonLabel_22";
			this._txtCommonLabel_22.Size = new System.Drawing.Size(120, 19);
			this._txtCommonLabel_22.TabIndex = 140;
			// 
			// _lblCommon_28
			// 
			this._lblCommon_28.AllowDrop = true;
			this._lblCommon_28.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._lblCommon_28.Text = "Last Transaction Party Code.";
			this._lblCommon_28.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_28.Location = new System.Drawing.Point(26, 88);
			this._lblCommon_28.Name = "_lblCommon_28";
			this._lblCommon_28.Size = new System.Drawing.Size(140, 14);
			this._lblCommon_28.TabIndex = 208;
			// 
			// _lblCommon_29
			// 
			this._lblCommon_29.AllowDrop = true;
			this._lblCommon_29.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._lblCommon_29.Text = "Last Transaction Salesman No.";
			this._lblCommon_29.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_29.Location = new System.Drawing.Point(26, 115);
			this._lblCommon_29.Name = "_lblCommon_29";
			this._lblCommon_29.Size = new System.Drawing.Size(150, 14);
			this._lblCommon_29.TabIndex = 209;
			// 
			// _lblCommon_30
			// 
			this._lblCommon_30.AllowDrop = true;
			this._lblCommon_30.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._lblCommon_30.Text = "Last Transaction Location No.";
			this._lblCommon_30.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_30.Location = new System.Drawing.Point(26, 64);
			this._lblCommon_30.Name = "_lblCommon_30";
			this._lblCommon_30.Size = new System.Drawing.Size(144, 14);
			this._lblCommon_30.TabIndex = 210;
			// 
			// _lblCommon_36
			// 
			this._lblCommon_36.AllowDrop = true;
			this._lblCommon_36.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._lblCommon_36.Text = "Last Transaction Ledger No.";
			this._lblCommon_36.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_36.Location = new System.Drawing.Point(26, 140);
			this._lblCommon_36.Name = "_lblCommon_36";
			this._lblCommon_36.Size = new System.Drawing.Size(137, 14);
			this._lblCommon_36.TabIndex = 211;
			// 
			// _fraCommon_8
			// 
			this._fraCommon_8.AllowDrop = true;
			this._fraCommon_8.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._fraCommon_8.Controls.Add(this._fraCommon_17);
			this._fraCommon_8.Enabled = true;
			this._fraCommon_8.ForeColor = System.Drawing.SystemColors.WindowText;
			this._fraCommon_8.Location = new System.Drawing.Point(1, 23);
			this._fraCommon_8.Name = "_fraCommon_8";
			this._fraCommon_8.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._fraCommon_8.Size = new System.Drawing.Size(745, 335);
			this._fraCommon_8.TabIndex = 169;
			this._fraCommon_8.Text = "Frame1";
			this._fraCommon_8.Visible = true;
			// 
			// _fraCommon_17
			// 
			this._fraCommon_17.AllowDrop = true;
			this._fraCommon_17.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._fraCommon_17.Controls.Add(this._chkCommon_137);
			this._fraCommon_17.Controls.Add(this._chkCommon_130);
			this._fraCommon_17.Controls.Add(this._chkCommon_129);
			this._fraCommon_17.Controls.Add(this._chkCommon_128);
			this._fraCommon_17.Controls.Add(this._chkCommon_125);
			this._fraCommon_17.Controls.Add(this._chkCommon_35);
			this._fraCommon_17.Controls.Add(this._chkCommon_110);
			this._fraCommon_17.Controls.Add(this._chkCommon_109);
			this._fraCommon_17.Controls.Add(this._chkCommon_107);
			this._fraCommon_17.Controls.Add(this._chkCommon_106);
			this._fraCommon_17.Controls.Add(this._chkCommon_105);
			this._fraCommon_17.Controls.Add(this._chkCommon_104);
			this._fraCommon_17.Controls.Add(this._chkCommon_101);
			this._fraCommon_17.Controls.Add(this._chkCommon_100);
			this._fraCommon_17.Controls.Add(this._chkCommon_99);
			this._fraCommon_17.Controls.Add(this._chkCommon_98);
			this._fraCommon_17.Controls.Add(this._chkCommon_96);
			this._fraCommon_17.Controls.Add(this._chkCommon_91);
			this._fraCommon_17.Controls.Add(this._chkCommon_90);
			this._fraCommon_17.Controls.Add(this._chkCommon_89);
			this._fraCommon_17.Controls.Add(this._chkCommon_88);
			this._fraCommon_17.Controls.Add(this._chkCommon_87);
			this._fraCommon_17.Controls.Add(this._chkCommon_86);
			this._fraCommon_17.Controls.Add(this._chkCommon_84);
			this._fraCommon_17.Controls.Add(this._lblCommon_35);
			this._fraCommon_17.Controls.Add(this._cmbCommon_1);
			this._fraCommon_17.Controls.Add(this._lblCommon_32);
			this._fraCommon_17.Controls.Add(this._txtCommon_19);
			this._fraCommon_17.Controls.Add(this._lblCommon_46);
			this._fraCommon_17.Controls.Add(this._txtCommon_38);
			this._fraCommon_17.Controls.Add(this._lblCommon_48);
			this._fraCommon_17.Controls.Add(this._txtCommon_40);
			this._fraCommon_17.Enabled = true;
			this._fraCommon_17.ForeColor = System.Drawing.SystemColors.WindowText;
			this._fraCommon_17.Location = new System.Drawing.Point(6, 8);
			this._fraCommon_17.Name = "_fraCommon_17";
			this._fraCommon_17.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._fraCommon_17.Size = new System.Drawing.Size(723, 233);
			this._fraCommon_17.TabIndex = 180;
			this._fraCommon_17.Text = "POS Settings";
			this._fraCommon_17.Visible = true;
			// 
			// _chkCommon_137
			// 
			this._chkCommon_137.AllowDrop = true;
			this._chkCommon_137.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkCommon_137.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._chkCommon_137.CausesValidation = true;
			this._chkCommon_137.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_137.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkCommon_137.Enabled = true;
			this._chkCommon_137.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkCommon_137.Location = new System.Drawing.Point(506, 18);
			this._chkCommon_137.Name = "_chkCommon_137";
			this._chkCommon_137.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkCommon_137.Size = new System.Drawing.Size(201, 17);
			this._chkCommon_137.TabIndex = 296;
			this._chkCommon_137.TabStop = true;
			this._chkCommon_137.Text = "Set Focus To Qty After Name Entered";
			this._chkCommon_137.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_137.Visible = true;
			this._chkCommon_137.CheckStateChanged += new System.EventHandler(this.chkCommon_CheckStateChanged);
			// 
			// _chkCommon_130
			// 
			this._chkCommon_130.AllowDrop = true;
			this._chkCommon_130.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkCommon_130.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._chkCommon_130.CausesValidation = true;
			this._chkCommon_130.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_130.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkCommon_130.Enabled = true;
			this._chkCommon_130.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkCommon_130.Location = new System.Drawing.Point(506, 100);
			this._chkCommon_130.Name = "_chkCommon_130";
			this._chkCommon_130.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkCommon_130.Size = new System.Drawing.Size(201, 17);
			this._chkCommon_130.TabIndex = 243;
			this._chkCommon_130.TabStop = true;
			this._chkCommon_130.Text = "Show Message Maximum Level";
			this._chkCommon_130.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_130.Visible = true;
			this._chkCommon_130.CheckStateChanged += new System.EventHandler(this.chkCommon_CheckStateChanged);
			// 
			// _chkCommon_129
			// 
			this._chkCommon_129.AllowDrop = true;
			this._chkCommon_129.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkCommon_129.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._chkCommon_129.CausesValidation = true;
			this._chkCommon_129.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_129.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkCommon_129.Enabled = true;
			this._chkCommon_129.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkCommon_129.Location = new System.Drawing.Point(506, 84);
			this._chkCommon_129.Name = "_chkCommon_129";
			this._chkCommon_129.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkCommon_129.Size = new System.Drawing.Size(201, 17);
			this._chkCommon_129.TabIndex = 242;
			this._chkCommon_129.TabStop = true;
			this._chkCommon_129.Text = "Show Message Minimum Level";
			this._chkCommon_129.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_129.Visible = true;
			this._chkCommon_129.CheckStateChanged += new System.EventHandler(this.chkCommon_CheckStateChanged);
			// 
			// _chkCommon_128
			// 
			this._chkCommon_128.AllowDrop = true;
			this._chkCommon_128.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkCommon_128.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._chkCommon_128.CausesValidation = true;
			this._chkCommon_128.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_128.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkCommon_128.Enabled = true;
			this._chkCommon_128.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkCommon_128.Location = new System.Drawing.Point(506, 67);
			this._chkCommon_128.Name = "_chkCommon_128";
			this._chkCommon_128.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkCommon_128.Size = new System.Drawing.Size(201, 17);
			this._chkCommon_128.TabIndex = 241;
			this._chkCommon_128.TabStop = true;
			this._chkCommon_128.Text = "Show Message Below Reorder";
			this._chkCommon_128.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_128.Visible = true;
			this._chkCommon_128.CheckStateChanged += new System.EventHandler(this.chkCommon_CheckStateChanged);
			// 
			// _chkCommon_125
			// 
			this._chkCommon_125.AllowDrop = true;
			this._chkCommon_125.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkCommon_125.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._chkCommon_125.CausesValidation = true;
			this._chkCommon_125.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_125.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkCommon_125.Enabled = true;
			this._chkCommon_125.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkCommon_125.Location = new System.Drawing.Point(506, 51);
			this._chkCommon_125.Name = "_chkCommon_125";
			this._chkCommon_125.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkCommon_125.Size = new System.Drawing.Size(201, 17);
			this._chkCommon_125.TabIndex = 228;
			this._chkCommon_125.TabStop = true;
			this._chkCommon_125.Text = "Allow Zero Amount Transaction";
			this._chkCommon_125.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_125.Visible = true;
			this._chkCommon_125.CheckStateChanged += new System.EventHandler(this.chkCommon_CheckStateChanged);
			// 
			// _chkCommon_35
			// 
			this._chkCommon_35.AllowDrop = true;
			this._chkCommon_35.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkCommon_35.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._chkCommon_35.CausesValidation = true;
			this._chkCommon_35.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_35.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkCommon_35.Enabled = true;
			this._chkCommon_35.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkCommon_35.Location = new System.Drawing.Point(20, 122);
			this._chkCommon_35.Name = "_chkCommon_35";
			this._chkCommon_35.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkCommon_35.Size = new System.Drawing.Size(243, 17);
			this._chkCommon_35.TabIndex = 122;
			this._chkCommon_35.TabStop = true;
			this._chkCommon_35.Text = "Enable Auto Fill PreText  With Product Name";
			this._chkCommon_35.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_35.Visible = true;
			this._chkCommon_35.CheckStateChanged += new System.EventHandler(this.chkCommon_CheckStateChanged);
			// 
			// _chkCommon_110
			// 
			this._chkCommon_110.AllowDrop = true;
			this._chkCommon_110.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkCommon_110.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._chkCommon_110.CausesValidation = true;
			this._chkCommon_110.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_110.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkCommon_110.Enabled = true;
			this._chkCommon_110.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkCommon_110.Location = new System.Drawing.Point(506, 34);
			this._chkCommon_110.Name = "_chkCommon_110";
			this._chkCommon_110.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkCommon_110.Size = new System.Drawing.Size(201, 17);
			this._chkCommon_110.TabIndex = 134;
			this._chkCommon_110.TabStop = true;
			this._chkCommon_110.Text = "Show Default Location Salesman";
			this._chkCommon_110.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_110.Visible = true;
			this._chkCommon_110.CheckStateChanged += new System.EventHandler(this.chkCommon_CheckStateChanged);
			// 
			// _chkCommon_109
			// 
			this._chkCommon_109.AllowDrop = true;
			this._chkCommon_109.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkCommon_109.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._chkCommon_109.CausesValidation = true;
			this._chkCommon_109.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_109.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkCommon_109.Enabled = true;
			this._chkCommon_109.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkCommon_109.Location = new System.Drawing.Point(272, 155);
			this._chkCommon_109.Name = "_chkCommon_109";
			this._chkCommon_109.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkCommon_109.Size = new System.Drawing.Size(185, 17);
			this._chkCommon_109.TabIndex = 133;
			this._chkCommon_109.TabStop = true;
			this._chkCommon_109.Text = "Show Location Specific Product";
			this._chkCommon_109.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_109.Visible = true;
			this._chkCommon_109.CheckStateChanged += new System.EventHandler(this.chkCommon_CheckStateChanged);
			// 
			// _chkCommon_107
			// 
			this._chkCommon_107.AllowDrop = true;
			this._chkCommon_107.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkCommon_107.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._chkCommon_107.CausesValidation = true;
			this._chkCommon_107.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_107.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkCommon_107.Enabled = true;
			this._chkCommon_107.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkCommon_107.Location = new System.Drawing.Point(272, 138);
			this._chkCommon_107.Name = "_chkCommon_107";
			this._chkCommon_107.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkCommon_107.Size = new System.Drawing.Size(193, 17);
			this._chkCommon_107.TabIndex = 132;
			this._chkCommon_107.TabStop = true;
			this._chkCommon_107.Text = "Display Voucher Number After Save";
			this._chkCommon_107.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_107.Visible = true;
			this._chkCommon_107.CheckStateChanged += new System.EventHandler(this.chkCommon_CheckStateChanged);
			// 
			// _chkCommon_106
			// 
			this._chkCommon_106.AllowDrop = true;
			this._chkCommon_106.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkCommon_106.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._chkCommon_106.CausesValidation = true;
			this._chkCommon_106.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_106.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkCommon_106.Enabled = true;
			this._chkCommon_106.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkCommon_106.Location = new System.Drawing.Point(272, 121);
			this._chkCommon_106.Name = "_chkCommon_106";
			this._chkCommon_106.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkCommon_106.Size = new System.Drawing.Size(149, 17);
			this._chkCommon_106.TabIndex = 131;
			this._chkCommon_106.TabStop = true;
			this._chkCommon_106.Text = "Show Amount Over Rate";
			this._chkCommon_106.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_106.Visible = true;
			this._chkCommon_106.CheckStateChanged += new System.EventHandler(this.chkCommon_CheckStateChanged);
			// 
			// _chkCommon_105
			// 
			this._chkCommon_105.AllowDrop = true;
			this._chkCommon_105.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkCommon_105.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._chkCommon_105.CausesValidation = true;
			this._chkCommon_105.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_105.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkCommon_105.Enabled = true;
			this._chkCommon_105.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkCommon_105.Location = new System.Drawing.Point(20, 156);
			this._chkCommon_105.Name = "_chkCommon_105";
			this._chkCommon_105.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkCommon_105.Size = new System.Drawing.Size(249, 17);
			this._chkCommon_105.TabIndex = 130;
			this._chkCommon_105.TabStop = true;
			this._chkCommon_105.Text = "Set Focus to Newline after Quantity Entered";
			this._chkCommon_105.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_105.Visible = true;
			this._chkCommon_105.CheckStateChanged += new System.EventHandler(this.chkCommon_CheckStateChanged);
			// 
			// _chkCommon_104
			// 
			this._chkCommon_104.AllowDrop = true;
			this._chkCommon_104.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkCommon_104.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._chkCommon_104.CausesValidation = true;
			this._chkCommon_104.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_104.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkCommon_104.Enabled = true;
			this._chkCommon_104.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkCommon_104.Location = new System.Drawing.Point(272, 104);
			this._chkCommon_104.Name = "_chkCommon_104";
			this._chkCommon_104.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkCommon_104.Size = new System.Drawing.Size(249, 17);
			this._chkCommon_104.TabIndex = 129;
			this._chkCommon_104.TabStop = true;
			this._chkCommon_104.Text = "Set Focus to Newline after Barcode Entered";
			this._chkCommon_104.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_104.Visible = true;
			this._chkCommon_104.CheckStateChanged += new System.EventHandler(this.chkCommon_CheckStateChanged);
			// 
			// _chkCommon_101
			// 
			this._chkCommon_101.AllowDrop = true;
			this._chkCommon_101.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkCommon_101.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._chkCommon_101.CausesValidation = true;
			this._chkCommon_101.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_101.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkCommon_101.Enabled = true;
			this._chkCommon_101.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkCommon_101.Location = new System.Drawing.Point(272, 70);
			this._chkCommon_101.Name = "_chkCommon_101";
			this._chkCommon_101.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkCommon_101.Size = new System.Drawing.Size(249, 17);
			this._chkCommon_101.TabIndex = 127;
			this._chkCommon_101.TabStop = true;
			this._chkCommon_101.Text = "Allow to Add new Voucher";
			this._chkCommon_101.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_101.Visible = true;
			this._chkCommon_101.CheckStateChanged += new System.EventHandler(this.chkCommon_CheckStateChanged);
			// 
			// _chkCommon_100
			// 
			this._chkCommon_100.AllowDrop = true;
			this._chkCommon_100.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkCommon_100.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._chkCommon_100.CausesValidation = true;
			this._chkCommon_100.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_100.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkCommon_100.Enabled = true;
			this._chkCommon_100.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkCommon_100.Location = new System.Drawing.Point(272, 87);
			this._chkCommon_100.Name = "_chkCommon_100";
			this._chkCommon_100.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkCommon_100.Size = new System.Drawing.Size(249, 17);
			this._chkCommon_100.TabIndex = 128;
			this._chkCommon_100.TabStop = true;
			this._chkCommon_100.Text = "Allow to Update Voucher";
			this._chkCommon_100.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_100.Visible = true;
			this._chkCommon_100.CheckStateChanged += new System.EventHandler(this.chkCommon_CheckStateChanged);
			// 
			// _chkCommon_99
			// 
			this._chkCommon_99.AllowDrop = true;
			this._chkCommon_99.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkCommon_99.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._chkCommon_99.CausesValidation = true;
			this._chkCommon_99.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_99.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkCommon_99.Enabled = true;
			this._chkCommon_99.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkCommon_99.Location = new System.Drawing.Point(272, 53);
			this._chkCommon_99.Name = "_chkCommon_99";
			this._chkCommon_99.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkCommon_99.Size = new System.Drawing.Size(249, 17);
			this._chkCommon_99.TabIndex = 126;
			this._chkCommon_99.TabStop = true;
			this._chkCommon_99.Text = "Allow to Add Serial No when not exists";
			this._chkCommon_99.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_99.Visible = true;
			this._chkCommon_99.CheckStateChanged += new System.EventHandler(this.chkCommon_CheckStateChanged);
			// 
			// _chkCommon_98
			// 
			this._chkCommon_98.AllowDrop = true;
			this._chkCommon_98.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkCommon_98.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._chkCommon_98.CausesValidation = true;
			this._chkCommon_98.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_98.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkCommon_98.Enabled = true;
			this._chkCommon_98.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkCommon_98.Location = new System.Drawing.Point(272, 36);
			this._chkCommon_98.Name = "_chkCommon_98";
			this._chkCommon_98.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkCommon_98.Size = new System.Drawing.Size(249, 17);
			this._chkCommon_98.TabIndex = 125;
			this._chkCommon_98.TabStop = true;
			this._chkCommon_98.Text = "Allow Product Name Alteration";
			this._chkCommon_98.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_98.Visible = true;
			this._chkCommon_98.CheckStateChanged += new System.EventHandler(this.chkCommon_CheckStateChanged);
			// 
			// _chkCommon_96
			// 
			this._chkCommon_96.AllowDrop = true;
			this._chkCommon_96.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkCommon_96.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._chkCommon_96.CausesValidation = true;
			this._chkCommon_96.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_96.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkCommon_96.Enabled = true;
			this._chkCommon_96.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkCommon_96.Location = new System.Drawing.Point(272, 18);
			this._chkCommon_96.Name = "_chkCommon_96";
			this._chkCommon_96.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkCommon_96.Size = new System.Drawing.Size(203, 17);
			this._chkCommon_96.TabIndex = 124;
			this._chkCommon_96.TabStop = true;
			this._chkCommon_96.Text = "Show Message When Negative Stock";
			this._chkCommon_96.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_96.Visible = true;
			this._chkCommon_96.CheckStateChanged += new System.EventHandler(this.chkCommon_CheckStateChanged);
			// 
			// _chkCommon_91
			// 
			this._chkCommon_91.AllowDrop = true;
			this._chkCommon_91.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkCommon_91.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._chkCommon_91.CausesValidation = true;
			this._chkCommon_91.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_91.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkCommon_91.Enabled = true;
			this._chkCommon_91.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkCommon_91.Location = new System.Drawing.Point(20, 18);
			this._chkCommon_91.Name = "_chkCommon_91";
			this._chkCommon_91.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkCommon_91.Size = new System.Drawing.Size(249, 17);
			this._chkCommon_91.TabIndex = 116;
			this._chkCommon_91.TabStop = true;
			this._chkCommon_91.Text = "Enable ICS Voucher Type Final Payment Screen";
			this._chkCommon_91.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_91.Visible = true;
			this._chkCommon_91.CheckStateChanged += new System.EventHandler(this.chkCommon_CheckStateChanged);
			// 
			// _chkCommon_90
			// 
			this._chkCommon_90.AllowDrop = true;
			this._chkCommon_90.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkCommon_90.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._chkCommon_90.CausesValidation = true;
			this._chkCommon_90.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_90.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkCommon_90.Enabled = true;
			this._chkCommon_90.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkCommon_90.Location = new System.Drawing.Point(20, 36);
			this._chkCommon_90.Name = "_chkCommon_90";
			this._chkCommon_90.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkCommon_90.Size = new System.Drawing.Size(174, 17);
			this._chkCommon_90.TabIndex = 117;
			this._chkCommon_90.TabStop = true;
			this._chkCommon_90.Text = "Import External Data";
			this._chkCommon_90.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_90.Visible = true;
			this._chkCommon_90.CheckStateChanged += new System.EventHandler(this.chkCommon_CheckStateChanged);
			// 
			// _chkCommon_89
			// 
			this._chkCommon_89.AllowDrop = true;
			this._chkCommon_89.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkCommon_89.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._chkCommon_89.CausesValidation = true;
			this._chkCommon_89.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_89.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkCommon_89.Enabled = true;
			this._chkCommon_89.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkCommon_89.Location = new System.Drawing.Point(20, 53);
			this._chkCommon_89.Name = "_chkCommon_89";
			this._chkCommon_89.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkCommon_89.Size = new System.Drawing.Size(251, 17);
			this._chkCommon_89.TabIndex = 118;
			this._chkCommon_89.TabStop = true;
			this._chkCommon_89.Text = "Set Focus To Grid After Add New";
			this._chkCommon_89.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_89.Visible = true;
			this._chkCommon_89.CheckStateChanged += new System.EventHandler(this.chkCommon_CheckStateChanged);
			// 
			// _chkCommon_88
			// 
			this._chkCommon_88.AllowDrop = true;
			this._chkCommon_88.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkCommon_88.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._chkCommon_88.CausesValidation = true;
			this._chkCommon_88.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_88.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkCommon_88.Enabled = true;
			this._chkCommon_88.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkCommon_88.Location = new System.Drawing.Point(20, 70);
			this._chkCommon_88.Name = "_chkCommon_88";
			this._chkCommon_88.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkCommon_88.Size = new System.Drawing.Size(174, 17);
			this._chkCommon_88.TabIndex = 119;
			this._chkCommon_88.TabStop = true;
			this._chkCommon_88.Text = "Check Part Number Exists";
			this._chkCommon_88.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_88.Visible = true;
			this._chkCommon_88.CheckStateChanged += new System.EventHandler(this.chkCommon_CheckStateChanged);
			// 
			// _chkCommon_87
			// 
			this._chkCommon_87.AllowDrop = true;
			this._chkCommon_87.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkCommon_87.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._chkCommon_87.CausesValidation = true;
			this._chkCommon_87.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_87.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkCommon_87.Enabled = true;
			this._chkCommon_87.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkCommon_87.Location = new System.Drawing.Point(20, 87);
			this._chkCommon_87.Name = "_chkCommon_87";
			this._chkCommon_87.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkCommon_87.Size = new System.Drawing.Size(174, 17);
			this._chkCommon_87.TabIndex = 120;
			this._chkCommon_87.TabStop = true;
			this._chkCommon_87.Text = "Check Product Name Exists";
			this._chkCommon_87.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_87.Visible = true;
			this._chkCommon_87.CheckStateChanged += new System.EventHandler(this.chkCommon_CheckStateChanged);
			// 
			// _chkCommon_86
			// 
			this._chkCommon_86.AllowDrop = true;
			this._chkCommon_86.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkCommon_86.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._chkCommon_86.CausesValidation = true;
			this._chkCommon_86.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_86.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkCommon_86.Enabled = true;
			this._chkCommon_86.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkCommon_86.Location = new System.Drawing.Point(20, 104);
			this._chkCommon_86.Name = "_chkCommon_86";
			this._chkCommon_86.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkCommon_86.Size = new System.Drawing.Size(174, 17);
			this._chkCommon_86.TabIndex = 121;
			this._chkCommon_86.TabStop = true;
			this._chkCommon_86.Text = "Enable Partial Receipt";
			this._chkCommon_86.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_86.Visible = true;
			this._chkCommon_86.CheckStateChanged += new System.EventHandler(this.chkCommon_CheckStateChanged);
			// 
			// _chkCommon_84
			// 
			this._chkCommon_84.AllowDrop = true;
			this._chkCommon_84.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkCommon_84.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._chkCommon_84.CausesValidation = true;
			this._chkCommon_84.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_84.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkCommon_84.Enabled = true;
			this._chkCommon_84.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkCommon_84.Location = new System.Drawing.Point(20, 139);
			this._chkCommon_84.Name = "_chkCommon_84";
			this._chkCommon_84.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkCommon_84.Size = new System.Drawing.Size(211, 17);
			this._chkCommon_84.TabIndex = 123;
			this._chkCommon_84.TabStop = true;
			this._chkCommon_84.Text = "Enable Additional Voucher Details 2";
			this._chkCommon_84.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_84.Visible = true;
			this._chkCommon_84.CheckStateChanged += new System.EventHandler(this.chkCommon_CheckStateChanged);
			// 
			// _lblCommon_35
			// 
			this._lblCommon_35.AllowDrop = true;
			this._lblCommon_35.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._lblCommon_35.Text = "Default Price Level Priority";
			this._lblCommon_35.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_35.Location = new System.Drawing.Point(234, 184);
			this._lblCommon_35.Name = "_lblCommon_35";
			this._lblCommon_35.Size = new System.Drawing.Size(126, 14);
			this._lblCommon_35.TabIndex = 194;
			// 
			// _cmbCommon_1
			// 
			this._cmbCommon_1.AllowDrop = true;
			this._cmbCommon_1.Location = new System.Drawing.Point(364, 181);
			this._cmbCommon_1.Name = "_cmbCommon_1";
			this._cmbCommon_1.Size = new System.Drawing.Size(106, 21);
			this._cmbCommon_1.TabIndex = 136;
			// 
			// _lblCommon_32
			// 
			this._lblCommon_32.AllowDrop = true;
			this._lblCommon_32.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._lblCommon_32.Text = "After Save Scriipt";
			this._lblCommon_32.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_32.Location = new System.Drawing.Point(20, 206);
			this._lblCommon_32.Name = "_lblCommon_32";
			this._lblCommon_32.Size = new System.Drawing.Size(86, 14);
			this._lblCommon_32.TabIndex = 206;
			// 
			// _txtCommon_19
			// 
			this._txtCommon_19.AllowDrop = true;
			this._txtCommon_19.BackColor = System.Drawing.Color.White;
			// this._txtCommon_19.bolAllowDecimal = false;
			this._txtCommon_19.ForeColor = System.Drawing.Color.Black;
			this._txtCommon_19.Location = new System.Drawing.Point(118, 204);
			// this._txtCommon_19.mDropDownType = (System.Windows.Forms.TextBox.DropDownTypes) 0;
			this._txtCommon_19.Name = "_txtCommon_19";
			this._txtCommon_19.Size = new System.Drawing.Size(595, 19);
			this._txtCommon_19.TabIndex = 135;
			this._txtCommon_19.Text = "";
			// this.this._txtCommon_19.Change += new System.Windows.Forms.TextBox.ChangeHandler(this.txtCommon_Change);
			// this.this._txtCommon_19.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommon_DropButtonClick);
			// this._txtCommon_19.Leave += new System.EventHandler(this.txtCommon_Leave);
			// 
			// _lblCommon_46
			// 
			this._lblCommon_46.AllowDrop = true;
			this._lblCommon_46.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._lblCommon_46.Text = "Default Cash Code";
			this._lblCommon_46.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_46.Location = new System.Drawing.Point(20, 182);
			this._lblCommon_46.Name = "_lblCommon_46";
			this._lblCommon_46.Size = new System.Drawing.Size(90, 14);
			this._lblCommon_46.TabIndex = 244;
			// 
			// _txtCommon_38
			// 
			this._txtCommon_38.AllowDrop = true;
			this._txtCommon_38.BackColor = System.Drawing.Color.White;
			// this._txtCommon_38.bolAllowDecimal = false;
			this._txtCommon_38.ForeColor = System.Drawing.Color.Black;
			this._txtCommon_38.Location = new System.Drawing.Point(118, 182);
			// this._txtCommon_38.mDropDownType = (System.Windows.Forms.TextBox.DropDownTypes) 0;
			this._txtCommon_38.Name = "_txtCommon_38";
			// this._txtCommon_38.ShowButton = true;
			this._txtCommon_38.Size = new System.Drawing.Size(109, 19);
			this._txtCommon_38.TabIndex = 245;
			this._txtCommon_38.Text = "";
			// this.this._txtCommon_38.Change += new System.Windows.Forms.TextBox.ChangeHandler(this.txtCommon_Change);
			// this.this._txtCommon_38.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommon_DropButtonClick);
			// this._txtCommon_38.Leave += new System.EventHandler(this.txtCommon_Leave);
			// 
			// _lblCommon_48
			// 
			this._lblCommon_48.AllowDrop = true;
			this._lblCommon_48.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._lblCommon_48.Text = "Default Credit Card Code";
			this._lblCommon_48.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_48.Location = new System.Drawing.Point(478, 184);
			this._lblCommon_48.Name = "_lblCommon_48";
			this._lblCommon_48.Size = new System.Drawing.Size(119, 14);
			this._lblCommon_48.TabIndex = 256;
			// 
			// _txtCommon_40
			// 
			this._txtCommon_40.AllowDrop = true;
			this._txtCommon_40.BackColor = System.Drawing.Color.White;
			// this._txtCommon_40.bolAllowDecimal = false;
			this._txtCommon_40.ForeColor = System.Drawing.Color.Black;
			this._txtCommon_40.Location = new System.Drawing.Point(604, 182);
			// this._txtCommon_40.mDropDownType = (System.Windows.Forms.TextBox.DropDownTypes) 0;
			this._txtCommon_40.Name = "_txtCommon_40";
			// this._txtCommon_40.ShowButton = true;
			this._txtCommon_40.Size = new System.Drawing.Size(109, 19);
			this._txtCommon_40.TabIndex = 257;
			this._txtCommon_40.Text = "";
			// this.this._txtCommon_40.Change += new System.Windows.Forms.TextBox.ChangeHandler(this.txtCommon_Change);
			// this.this._txtCommon_40.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommon_DropButtonClick);
			// this._txtCommon_40.Leave += new System.EventHandler(this.txtCommon_Leave);
			// 
			// _fraCommon_7
			// 
			this._fraCommon_7.AllowDrop = true;
			this._fraCommon_7.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._fraCommon_7.Controls.Add(this._fraCommon_15);
			this._fraCommon_7.Enabled = true;
			this._fraCommon_7.ForeColor = System.Drawing.SystemColors.WindowText;
			this._fraCommon_7.Location = new System.Drawing.Point(-786, 23);
			this._fraCommon_7.Name = "_fraCommon_7";
			this._fraCommon_7.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._fraCommon_7.Size = new System.Drawing.Size(745, 335);
			this._fraCommon_7.TabIndex = 168;
			this._fraCommon_7.Text = "Frame1";
			this._fraCommon_7.Visible = true;
			// 
			// _fraCommon_15
			// 
			this._fraCommon_15.AllowDrop = true;
			this._fraCommon_15.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._fraCommon_15.Controls.Add(this._chkCommon_66);
			this._fraCommon_15.Controls.Add(this._txtCommon_12);
			this._fraCommon_15.Controls.Add(this._chkCommon_65);
			this._fraCommon_15.Controls.Add(this._chkCommon_64);
			this._fraCommon_15.Controls.Add(this._chkCommon_63);
			this._fraCommon_15.Controls.Add(this._chkCommon_62);
			this._fraCommon_15.Controls.Add(this._chkCommon_61);
			this._fraCommon_15.Controls.Add(this._optCommonQtyEffect_3);
			this._fraCommon_15.Controls.Add(this._optCommonQtyEffect_2);
			this._fraCommon_15.Controls.Add(this._lblCommon_12);
			this._fraCommon_15.Controls.Add(this._txtCommon_10);
			this._fraCommon_15.Controls.Add(this._lblCommon_14);
			this._fraCommon_15.Controls.Add(this._lblCommon_15);
			this._fraCommon_15.Controls.Add(this._txtCommon_13);
			this._fraCommon_15.Controls.Add(this._txtCommonLabel_4);
			this._fraCommon_15.Controls.Add(this.cmbPrintList);
			this._fraCommon_15.Controls.Add(this.grdPrintTask);
			this._fraCommon_15.Enabled = true;
			this._fraCommon_15.ForeColor = System.Drawing.SystemColors.WindowText;
			this._fraCommon_15.Location = new System.Drawing.Point(12, 8);
			this._fraCommon_15.Name = "_fraCommon_15";
			this._fraCommon_15.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._fraCommon_15.Size = new System.Drawing.Size(727, 319);
			this._fraCommon_15.TabIndex = 175;
			this._fraCommon_15.Text = " Voucher Printing Setting ";
			this._fraCommon_15.Visible = true;
			// 
			// _chkCommon_66
			// 
			this._chkCommon_66.AllowDrop = true;
			this._chkCommon_66.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkCommon_66.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._chkCommon_66.CausesValidation = true;
			this._chkCommon_66.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_66.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkCommon_66.Enabled = true;
			this._chkCommon_66.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkCommon_66.Location = new System.Drawing.Point(288, 56);
			this._chkCommon_66.Name = "_chkCommon_66";
			this._chkCommon_66.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkCommon_66.Size = new System.Drawing.Size(207, 17);
			this._chkCommon_66.TabIndex = 221;
			this._chkCommon_66.TabStop = true;
			this._chkCommon_66.Text = "Export To Word";
			this._chkCommon_66.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_66.Visible = true;
			this._chkCommon_66.CheckStateChanged += new System.EventHandler(this.chkCommon_CheckStateChanged);
			// 
			// _txtCommon_12
			// 
			this._txtCommon_12.AllowDrop = true;
			this._txtCommon_12.BackColor = System.Drawing.Color.FromArgb(239, 239, 239);
			// this._txtCommon_12.bolAllowDecimal = false;
			this._txtCommon_12.Enabled = false;
			this._txtCommon_12.ForeColor = System.Drawing.Color.Black;
			this._txtCommon_12.Location = new System.Drawing.Point(150, 101);
			// this._txtCommon_12.mDropDownType = (System.Windows.Forms.TextBox.DropDownTypes) 0;
			this._txtCommon_12.Name = "_txtCommon_12";
			this._txtCommon_12.Size = new System.Drawing.Size(339, 19);
			this._txtCommon_12.TabIndex = 32;
			this._txtCommon_12.Text = "";
			// this.this._txtCommon_12.Change += new System.Windows.Forms.TextBox.ChangeHandler(this.txtCommon_Change);
			// this.this._txtCommon_12.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommon_DropButtonClick);
			// this._txtCommon_12.Leave += new System.EventHandler(this.txtCommon_Leave);
			// 
			// _chkCommon_65
			// 
			this._chkCommon_65.AllowDrop = true;
			this._chkCommon_65.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkCommon_65.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._chkCommon_65.CausesValidation = true;
			this._chkCommon_65.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_65.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkCommon_65.Enabled = true;
			this._chkCommon_65.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkCommon_65.Location = new System.Drawing.Point(288, 37);
			this._chkCommon_65.Name = "_chkCommon_65";
			this._chkCommon_65.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkCommon_65.Size = new System.Drawing.Size(207, 17);
			this._chkCommon_65.TabIndex = 29;
			this._chkCommon_65.TabStop = true;
			this._chkCommon_65.Text = "Use NumToChar Function";
			this._chkCommon_65.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_65.Visible = true;
			this._chkCommon_65.CheckStateChanged += new System.EventHandler(this.chkCommon_CheckStateChanged);
			// 
			// _chkCommon_64
			// 
			this._chkCommon_64.AllowDrop = true;
			this._chkCommon_64.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkCommon_64.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._chkCommon_64.CausesValidation = true;
			this._chkCommon_64.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_64.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkCommon_64.Enabled = true;
			this._chkCommon_64.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkCommon_64.Location = new System.Drawing.Point(288, 20);
			this._chkCommon_64.Name = "_chkCommon_64";
			this._chkCommon_64.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkCommon_64.Size = new System.Drawing.Size(207, 17);
			this._chkCommon_64.TabIndex = 28;
			this._chkCommon_64.TabStop = true;
			this._chkCommon_64.Text = "Print After Saving";
			this._chkCommon_64.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_64.Visible = false;
			this._chkCommon_64.CheckStateChanged += new System.EventHandler(this.chkCommon_CheckStateChanged);
			// 
			// _chkCommon_63
			// 
			this._chkCommon_63.AllowDrop = true;
			this._chkCommon_63.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkCommon_63.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._chkCommon_63.CausesValidation = true;
			this._chkCommon_63.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_63.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkCommon_63.Enabled = true;
			this._chkCommon_63.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkCommon_63.Location = new System.Drawing.Point(12, 54);
			this._chkCommon_63.Name = "_chkCommon_63";
			this._chkCommon_63.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkCommon_63.Size = new System.Drawing.Size(207, 17);
			this._chkCommon_63.TabIndex = 27;
			this._chkCommon_63.TabStop = true;
			this._chkCommon_63.Text = "Close Window After Print";
			this._chkCommon_63.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_63.Visible = true;
			this._chkCommon_63.CheckStateChanged += new System.EventHandler(this.chkCommon_CheckStateChanged);
			// 
			// _chkCommon_62
			// 
			this._chkCommon_62.AllowDrop = true;
			this._chkCommon_62.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkCommon_62.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._chkCommon_62.CausesValidation = true;
			this._chkCommon_62.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_62.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkCommon_62.Enabled = true;
			this._chkCommon_62.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkCommon_62.Location = new System.Drawing.Point(12, 37);
			this._chkCommon_62.Name = "_chkCommon_62";
			this._chkCommon_62.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkCommon_62.Size = new System.Drawing.Size(207, 17);
			this._chkCommon_62.TabIndex = 26;
			this._chkCommon_62.TabStop = true;
			this._chkCommon_62.Text = "Show Page Setup Window on Initialize";
			this._chkCommon_62.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_62.Visible = true;
			this._chkCommon_62.CheckStateChanged += new System.EventHandler(this.chkCommon_CheckStateChanged);
			// 
			// _chkCommon_61
			// 
			this._chkCommon_61.AllowDrop = true;
			this._chkCommon_61.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkCommon_61.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._chkCommon_61.CausesValidation = true;
			this._chkCommon_61.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_61.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkCommon_61.Enabled = true;
			this._chkCommon_61.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkCommon_61.Location = new System.Drawing.Point(12, 20);
			this._chkCommon_61.Name = "_chkCommon_61";
			this._chkCommon_61.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkCommon_61.Size = new System.Drawing.Size(207, 17);
			this._chkCommon_61.TabIndex = 25;
			this._chkCommon_61.TabStop = true;
			this._chkCommon_61.Text = "Show Print Preview on Initialize";
			this._chkCommon_61.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_61.Visible = true;
			this._chkCommon_61.CheckStateChanged += new System.EventHandler(this.chkCommon_CheckStateChanged);
			// 
			// _optCommonQtyEffect_3
			// 
			this._optCommonQtyEffect_3.AllowDrop = true;
			this._optCommonQtyEffect_3.Appearance = System.Windows.Forms.Appearance.Normal;
			this._optCommonQtyEffect_3.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._optCommonQtyEffect_3.CausesValidation = true;
			this._optCommonQtyEffect_3.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._optCommonQtyEffect_3.Checked = false;
			this._optCommonQtyEffect_3.Enabled = true;
			this._optCommonQtyEffect_3.ForeColor = System.Drawing.SystemColors.ControlText;
			this._optCommonQtyEffect_3.Location = new System.Drawing.Point(12, 78);
			this._optCommonQtyEffect_3.Name = "_optCommonQtyEffect_3";
			this._optCommonQtyEffect_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._optCommonQtyEffect_3.Size = new System.Drawing.Size(123, 19);
			this._optCommonQtyEffect_3.TabIndex = 176;
			this._optCommonQtyEffect_3.TabStop = true;
			this._optCommonQtyEffect_3.Text = "Use XML Reports";
			this._optCommonQtyEffect_3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._optCommonQtyEffect_3.Visible = true;
			this._optCommonQtyEffect_3.CheckedChanged += new System.EventHandler(this.optCommonQtyEffect_CheckedChanged);
			// 
			// _optCommonQtyEffect_2
			// 
			this._optCommonQtyEffect_2.AllowDrop = true;
			this._optCommonQtyEffect_2.Appearance = System.Windows.Forms.Appearance.Normal;
			this._optCommonQtyEffect_2.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._optCommonQtyEffect_2.CausesValidation = true;
			this._optCommonQtyEffect_2.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._optCommonQtyEffect_2.Checked = false;
			this._optCommonQtyEffect_2.Enabled = true;
			this._optCommonQtyEffect_2.ForeColor = System.Drawing.SystemColors.ControlText;
			this._optCommonQtyEffect_2.Location = new System.Drawing.Point(8, 150);
			this._optCommonQtyEffect_2.Name = "_optCommonQtyEffect_2";
			this._optCommonQtyEffect_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._optCommonQtyEffect_2.Size = new System.Drawing.Size(123, 19);
			this._optCommonQtyEffect_2.TabIndex = 115;
			this._optCommonQtyEffect_2.TabStop = true;
			this._optCommonQtyEffect_2.Text = "Use Crystal Reports";
			this._optCommonQtyEffect_2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._optCommonQtyEffect_2.Visible = true;
			this._optCommonQtyEffect_2.CheckedChanged += new System.EventHandler(this.optCommonQtyEffect_CheckedChanged);
			// 
			// _lblCommon_12
			// 
			this._lblCommon_12.AllowDrop = true;
			this._lblCommon_12.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._lblCommon_12.Text = "Report ID";
			this._lblCommon_12.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_12.Location = new System.Drawing.Point(148, 150);
			this._lblCommon_12.Name = "_lblCommon_12";
			this._lblCommon_12.Size = new System.Drawing.Size(60, 14);
			this._lblCommon_12.TabIndex = 177;
			this._lblCommon_12.Visible = false;
			// 
			// _txtCommon_10
			// 
			this._txtCommon_10.AllowDrop = true;
			this._txtCommon_10.BackColor = System.Drawing.Color.White;
			// this._txtCommon_10.bolNumericOnly = true;
			this._txtCommon_10.ForeColor = System.Drawing.Color.Black;
			this._txtCommon_10.Location = new System.Drawing.Point(200, 148);
			this._txtCommon_10.Name = "_txtCommon_10";
			// this._txtCommon_10.ShowButton = true;
			this._txtCommon_10.Size = new System.Drawing.Size(101, 19);
			this._txtCommon_10.TabIndex = 30;
			this._txtCommon_10.Text = "";
			this._txtCommon_10.Visible = false;
			// this.this._txtCommon_10.Change += new System.Windows.Forms.TextBox.ChangeHandler(this.txtCommon_Change);
			// this.this._txtCommon_10.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommon_DropButtonClick);
			// this._txtCommon_10.Leave += new System.EventHandler(this.txtCommon_Leave);
			// 
			// _lblCommon_14
			// 
			this._lblCommon_14.AllowDrop = true;
			this._lblCommon_14.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._lblCommon_14.Text = "Print Voucher Name";
			this._lblCommon_14.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_14.Location = new System.Drawing.Point(42, 103);
			this._lblCommon_14.Name = "_lblCommon_14";
			this._lblCommon_14.Size = new System.Drawing.Size(96, 14);
			this._lblCommon_14.TabIndex = 178;
			// 
			// _lblCommon_15
			// 
			this._lblCommon_15.AllowDrop = true;
			this._lblCommon_15.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._lblCommon_15.Text = "Print Voucher SQL";
			this._lblCommon_15.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_15.Location = new System.Drawing.Point(42, 124);
			this._lblCommon_15.Name = "_lblCommon_15";
			this._lblCommon_15.Size = new System.Drawing.Size(90, 14);
			this._lblCommon_15.TabIndex = 179;
			// 
			// _txtCommon_13
			// 
			this._txtCommon_13.AllowDrop = true;
			this._txtCommon_13.BackColor = System.Drawing.Color.FromArgb(239, 239, 239);
			// this._txtCommon_13.bolAllowDecimal = false;
			this._txtCommon_13.Enabled = false;
			this._txtCommon_13.ForeColor = System.Drawing.Color.Black;
			this._txtCommon_13.Location = new System.Drawing.Point(150, 122);
			// this._txtCommon_13.mDropDownType = (System.Windows.Forms.TextBox.DropDownTypes) 0;
			this._txtCommon_13.Name = "_txtCommon_13";
			this._txtCommon_13.Size = new System.Drawing.Size(339, 19);
			this._txtCommon_13.TabIndex = 33;
			this._txtCommon_13.Text = "";
			// this.this._txtCommon_13.Change += new System.Windows.Forms.TextBox.ChangeHandler(this.txtCommon_Change);
			// this.this._txtCommon_13.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommon_DropButtonClick);
			// this._txtCommon_13.Leave += new System.EventHandler(this.txtCommon_Leave);
			// 
			// _txtCommonLabel_4
			// 
			this._txtCommonLabel_4.AllowDrop = true;
			this._txtCommonLabel_4.Location = new System.Drawing.Point(303, 148);
			this._txtCommonLabel_4.Name = "_txtCommonLabel_4";
			this._txtCommonLabel_4.Size = new System.Drawing.Size(135, 19);
			this._txtCommonLabel_4.TabIndex = 31;
			this._txtCommonLabel_4.Visible = false;
			// 
			// cmbPrintList
			// 
			this.cmbPrintList.AllowDrop = true;
			this.cmbPrintList.ColumnHeaders = true;
			this.cmbPrintList.Enabled = true;
			this.cmbPrintList.Location = new System.Drawing.Point(94, 216);
			this.cmbPrintList.Name = "cmbPrintList";
			this.cmbPrintList.Size = new System.Drawing.Size(227, 78);
			this.cmbPrintList.TabIndex = 239;
			this.cmbPrintList.Columns.Add(this.Column_0_cmbPrintList);
			this.cmbPrintList.Columns.Add(this.Column_1_cmbPrintList);
			// 
			// Column_0_cmbPrintList
			// 
			this.Column_0_cmbPrintList.DataField = "";
			this.Column_0_cmbPrintList.ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.Normal;
			// 
			// Column_1_cmbPrintList
			// 
			this.Column_1_cmbPrintList.DataField = "";
			this.Column_1_cmbPrintList.ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.Normal;
			// 
			// grdPrintTask
			// 
			this.grdPrintTask.AllowDrop = true;
			this.grdPrintTask.BackColor = System.Drawing.Color.FromArgb(236, 233, 216);
			this.grdPrintTask.CellTipsWidth = 0;
			this.grdPrintTask.Location = new System.Drawing.Point(6, 174);
			this.grdPrintTask.Name = "grdPrintTask";
			this.grdPrintTask.RowDivider.Color = System.Drawing.Color.LightGray;
			this.grdPrintTask.RowDivider.Color = System.Drawing.Color.FromArgb(236, 233, 216);
			this.grdPrintTask.RowDivider.Style = C1.Win.C1TrueDBGrid.LineStyleEnum.Single;
			this.grdPrintTask.Size = new System.Drawing.Size(715, 139);
			this.grdPrintTask.TabIndex = 240;
			this.grdPrintTask.Columns.Add(this.Column_0_grdPrintTask);
			this.grdPrintTask.Columns.Add(this.Column_1_grdPrintTask);
			this.grdPrintTask.GotFocus += new System.EventHandler(this.grdPrintTask_GotFocus);
			// this.this.grdPrintTask.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.grdPrintTask_KeyPress);
			this.grdPrintTask.MouseUp += new System.Windows.Forms.MouseEventHandler(this.grdPrintTask_MouseUp);
			this.grdPrintTask.RowColChange += new C1.Win.C1TrueDBGrid.RowColChangeEventHandler(this.grdPrintTask_RowColChange);
			// 
			// Column_0_grdPrintTask
			// 
			this.Column_0_grdPrintTask.DataField = "";
			this.Column_0_grdPrintTask.ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.Normal;
			// 
			// Column_1_grdPrintTask
			// 
			this.Column_1_grdPrintTask.DataField = "";
			this.Column_1_grdPrintTask.ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.Normal;
			// 
			// _fraCommon_6
			// 
			this._fraCommon_6.AllowDrop = true;
			this._fraCommon_6.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._fraCommon_6.Controls.Add(this._fraCommon_19);
			this._fraCommon_6.Controls.Add(this._fraCommon_25);
			this._fraCommon_6.Controls.Add(this._chkCommon_127);
			this._fraCommon_6.Controls.Add(this._chkCommon_60);
			this._fraCommon_6.Controls.Add(this._fraCommon_16);
			this._fraCommon_6.Controls.Add(this._fraCommon_14);
			this._fraCommon_6.Enabled = true;
			this._fraCommon_6.ForeColor = System.Drawing.SystemColors.WindowText;
			this._fraCommon_6.Location = new System.Drawing.Point(-806, 23);
			this._fraCommon_6.Name = "_fraCommon_6";
			this._fraCommon_6.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._fraCommon_6.Size = new System.Drawing.Size(745, 335);
			this._fraCommon_6.TabIndex = 167;
			this._fraCommon_6.Text = "Frame1";
			this._fraCommon_6.Visible = true;
			// 
			// _fraCommon_19
			// 
			this._fraCommon_19.AllowDrop = true;
			this._fraCommon_19.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._fraCommon_19.Controls.Add(this._lblCommon_24);
			this._fraCommon_19.Controls.Add(this._lblCommon_25);
			this._fraCommon_19.Controls.Add(this._lblCommon_26);
			this._fraCommon_19.Controls.Add(this._lblCommon_27);
			this._fraCommon_19.Controls.Add(this._txtCommonLabel_14);
			this._fraCommon_19.Controls.Add(this._txtCommonLabel_15);
			this._fraCommon_19.Controls.Add(this._txtCommonLabel_16);
			this._fraCommon_19.Controls.Add(this._txtCommonLabel_13);
			this._fraCommon_19.Controls.Add(this._txtCommon_18);
			this._fraCommon_19.Controls.Add(this._txtCommon_20);
			this._fraCommon_19.Controls.Add(this._txtCommon_21);
			this._fraCommon_19.Controls.Add(this._txtCommon_22);
			this._fraCommon_19.Enabled = true;
			this._fraCommon_19.ForeColor = System.Drawing.SystemColors.WindowText;
			this._fraCommon_19.Location = new System.Drawing.Point(10, 14);
			this._fraCommon_19.Name = "_fraCommon_19";
			this._fraCommon_19.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._fraCommon_19.Size = new System.Drawing.Size(467, 99);
			this._fraCommon_19.TabIndex = 263;
			this._fraCommon_19.Text = " GL Links ";
			this._fraCommon_19.Visible = true;
			// 
			// _lblCommon_24
			// 
			this._lblCommon_24.AllowDrop = true;
			this._lblCommon_24.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._lblCommon_24.Text = "GL Voucher Type";
			this._lblCommon_24.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_24.Location = new System.Drawing.Point(8, 14);
			this._lblCommon_24.Name = "_lblCommon_24";
			this._lblCommon_24.Size = new System.Drawing.Size(86, 14);
			this._lblCommon_24.TabIndex = 264;
			// 
			// _lblCommon_25
			// 
			this._lblCommon_25.AllowDrop = true;
			this._lblCommon_25.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._lblCommon_25.Text = "GL Reciept Voucher Type";
			this._lblCommon_25.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_25.Location = new System.Drawing.Point(8, 35);
			this._lblCommon_25.Name = "_lblCommon_25";
			this._lblCommon_25.Size = new System.Drawing.Size(125, 14);
			this._lblCommon_25.TabIndex = 265;
			// 
			// _lblCommon_26
			// 
			this._lblCommon_26.AllowDrop = true;
			this._lblCommon_26.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._lblCommon_26.Text = "GL Journal Voucher Type";
			this._lblCommon_26.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_26.Location = new System.Drawing.Point(8, 77);
			this._lblCommon_26.Name = "_lblCommon_26";
			this._lblCommon_26.Size = new System.Drawing.Size(124, 14);
			this._lblCommon_26.TabIndex = 266;
			// 
			// _lblCommon_27
			// 
			this._lblCommon_27.AllowDrop = true;
			this._lblCommon_27.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._lblCommon_27.Text = "GL Payment Voucher Type";
			this._lblCommon_27.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_27.Location = new System.Drawing.Point(8, 56);
			this._lblCommon_27.Name = "_lblCommon_27";
			this._lblCommon_27.Size = new System.Drawing.Size(130, 14);
			this._lblCommon_27.TabIndex = 267;
			// 
			// _txtCommonLabel_14
			// 
			this._txtCommonLabel_14.AllowDrop = true;
			this._txtCommonLabel_14.Location = new System.Drawing.Point(194, 33);
			this._txtCommonLabel_14.Name = "_txtCommonLabel_14";
			this._txtCommonLabel_14.Size = new System.Drawing.Size(261, 19);
			this._txtCommonLabel_14.TabIndex = 268;
			// 
			// _txtCommonLabel_15
			// 
			this._txtCommonLabel_15.AllowDrop = true;
			this._txtCommonLabel_15.Location = new System.Drawing.Point(194, 54);
			this._txtCommonLabel_15.Name = "_txtCommonLabel_15";
			this._txtCommonLabel_15.Size = new System.Drawing.Size(261, 19);
			this._txtCommonLabel_15.TabIndex = 269;
			// 
			// _txtCommonLabel_16
			// 
			this._txtCommonLabel_16.AllowDrop = true;
			this._txtCommonLabel_16.Location = new System.Drawing.Point(194, 75);
			this._txtCommonLabel_16.Name = "_txtCommonLabel_16";
			this._txtCommonLabel_16.Size = new System.Drawing.Size(261, 19);
			this._txtCommonLabel_16.TabIndex = 270;
			// 
			// _txtCommonLabel_13
			// 
			this._txtCommonLabel_13.AllowDrop = true;
			this._txtCommonLabel_13.Location = new System.Drawing.Point(194, 12);
			this._txtCommonLabel_13.Name = "_txtCommonLabel_13";
			this._txtCommonLabel_13.Size = new System.Drawing.Size(261, 19);
			this._txtCommonLabel_13.TabIndex = 271;
			// 
			// _txtCommon_18
			// 
			this._txtCommon_18.AllowDrop = true;
			this._txtCommon_18.BackColor = System.Drawing.Color.White;
			// this._txtCommon_18.bolNumericOnly = true;
			this._txtCommon_18.ForeColor = System.Drawing.Color.Black;
			this._txtCommon_18.Location = new System.Drawing.Point(146, 12);
			this._txtCommon_18.Name = "_txtCommon_18";
			// this._txtCommon_18.ShowButton = true;
			this._txtCommon_18.Size = new System.Drawing.Size(47, 19);
			this._txtCommon_18.TabIndex = 272;
			this._txtCommon_18.Text = "";
			// this.this._txtCommon_18.Change += new System.Windows.Forms.TextBox.ChangeHandler(this.txtCommon_Change);
			// this.this._txtCommon_18.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommon_DropButtonClick);
			// this._txtCommon_18.Leave += new System.EventHandler(this.txtCommon_Leave);
			// 
			// _txtCommon_20
			// 
			this._txtCommon_20.AllowDrop = true;
			this._txtCommon_20.BackColor = System.Drawing.Color.White;
			// this._txtCommon_20.bolNumericOnly = true;
			this._txtCommon_20.ForeColor = System.Drawing.Color.Black;
			this._txtCommon_20.Location = new System.Drawing.Point(146, 33);
			this._txtCommon_20.Name = "_txtCommon_20";
			// this._txtCommon_20.ShowButton = true;
			this._txtCommon_20.Size = new System.Drawing.Size(47, 19);
			this._txtCommon_20.TabIndex = 273;
			this._txtCommon_20.Text = "";
			// this.this._txtCommon_20.Change += new System.Windows.Forms.TextBox.ChangeHandler(this.txtCommon_Change);
			// this.this._txtCommon_20.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommon_DropButtonClick);
			// this._txtCommon_20.Leave += new System.EventHandler(this.txtCommon_Leave);
			// 
			// _txtCommon_21
			// 
			this._txtCommon_21.AllowDrop = true;
			this._txtCommon_21.BackColor = System.Drawing.Color.White;
			// this._txtCommon_21.bolNumericOnly = true;
			this._txtCommon_21.ForeColor = System.Drawing.Color.Black;
			this._txtCommon_21.Location = new System.Drawing.Point(146, 54);
			this._txtCommon_21.Name = "_txtCommon_21";
			// this._txtCommon_21.ShowButton = true;
			this._txtCommon_21.Size = new System.Drawing.Size(47, 19);
			this._txtCommon_21.TabIndex = 274;
			this._txtCommon_21.Text = "";
			// this.this._txtCommon_21.Change += new System.Windows.Forms.TextBox.ChangeHandler(this.txtCommon_Change);
			// this.this._txtCommon_21.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommon_DropButtonClick);
			// this._txtCommon_21.Leave += new System.EventHandler(this.txtCommon_Leave);
			// 
			// _txtCommon_22
			// 
			this._txtCommon_22.AllowDrop = true;
			this._txtCommon_22.BackColor = System.Drawing.Color.White;
			// this._txtCommon_22.bolNumericOnly = true;
			this._txtCommon_22.ForeColor = System.Drawing.Color.Black;
			this._txtCommon_22.Location = new System.Drawing.Point(146, 75);
			this._txtCommon_22.Name = "_txtCommon_22";
			// this._txtCommon_22.ShowButton = true;
			this._txtCommon_22.Size = new System.Drawing.Size(47, 19);
			this._txtCommon_22.TabIndex = 275;
			this._txtCommon_22.Text = "";
			// this.this._txtCommon_22.Change += new System.Windows.Forms.TextBox.ChangeHandler(this.txtCommon_Change);
			// this.this._txtCommon_22.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommon_DropButtonClick);
			// this._txtCommon_22.Leave += new System.EventHandler(this.txtCommon_Leave);
			// 
			// _fraCommon_25
			// 
			this._fraCommon_25.AllowDrop = true;
			this._fraCommon_25.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._fraCommon_25.Controls.Add(this._chkCommon_94);
			this._fraCommon_25.Controls.Add(this._chkCommon_95);
			this._fraCommon_25.Controls.Add(this._chkCommon_97);
			this._fraCommon_25.Enabled = true;
			this._fraCommon_25.ForeColor = System.Drawing.SystemColors.WindowText;
			this._fraCommon_25.Location = new System.Drawing.Point(488, 14);
			this._fraCommon_25.Name = "_fraCommon_25";
			this._fraCommon_25.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._fraCommon_25.Size = new System.Drawing.Size(249, 99);
			this._fraCommon_25.TabIndex = 258;
			this._fraCommon_25.Text = "Auto generate voucher Settings ";
			this._fraCommon_25.Visible = true;
			// 
			// _chkCommon_94
			// 
			this._chkCommon_94.AllowDrop = true;
			this._chkCommon_94.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkCommon_94.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._chkCommon_94.CausesValidation = true;
			this._chkCommon_94.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_94.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkCommon_94.Enabled = true;
			this._chkCommon_94.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkCommon_94.Location = new System.Drawing.Point(8, 37);
			this._chkCommon_94.Name = "_chkCommon_94";
			this._chkCommon_94.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkCommon_94.Size = new System.Drawing.Size(195, 17);
			this._chkCommon_94.TabIndex = 261;
			this._chkCommon_94.TabStop = true;
			this._chkCommon_94.Text = "Include Voucher No. in Voucher";
			this._chkCommon_94.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_94.Visible = true;
			this._chkCommon_94.CheckStateChanged += new System.EventHandler(this.chkCommon_CheckStateChanged);
			// 
			// _chkCommon_95
			// 
			this._chkCommon_95.AllowDrop = true;
			this._chkCommon_95.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkCommon_95.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._chkCommon_95.CausesValidation = true;
			this._chkCommon_95.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_95.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkCommon_95.Enabled = true;
			this._chkCommon_95.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkCommon_95.Location = new System.Drawing.Point(8, 20);
			this._chkCommon_95.Name = "_chkCommon_95";
			this._chkCommon_95.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkCommon_95.Size = new System.Drawing.Size(195, 17);
			this._chkCommon_95.TabIndex = 260;
			this._chkCommon_95.TabStop = true;
			this._chkCommon_95.Text = "Include Location in Voucher";
			this._chkCommon_95.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_95.Visible = true;
			this._chkCommon_95.CheckStateChanged += new System.EventHandler(this.chkCommon_CheckStateChanged);
			// 
			// _chkCommon_97
			// 
			this._chkCommon_97.AllowDrop = true;
			this._chkCommon_97.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkCommon_97.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._chkCommon_97.CausesValidation = true;
			this._chkCommon_97.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_97.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkCommon_97.Enabled = true;
			this._chkCommon_97.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkCommon_97.Location = new System.Drawing.Point(8, 54);
			this._chkCommon_97.Name = "_chkCommon_97";
			this._chkCommon_97.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkCommon_97.Size = new System.Drawing.Size(195, 17);
			this._chkCommon_97.TabIndex = 259;
			this._chkCommon_97.TabStop = true;
			this._chkCommon_97.Text = "Include Reference No. in Voucher";
			this._chkCommon_97.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_97.Visible = true;
			this._chkCommon_97.CheckStateChanged += new System.EventHandler(this.chkCommon_CheckStateChanged);
			// 
			// _chkCommon_127
			// 
			this._chkCommon_127.AllowDrop = true;
			this._chkCommon_127.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkCommon_127.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._chkCommon_127.CausesValidation = true;
			this._chkCommon_127.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_127.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkCommon_127.Enabled = true;
			this._chkCommon_127.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkCommon_127.Location = new System.Drawing.Point(264, 126);
			this._chkCommon_127.Name = "_chkCommon_127";
			this._chkCommon_127.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkCommon_127.Size = new System.Drawing.Size(161, 17);
			this._chkCommon_127.TabIndex = 238;
			this._chkCommon_127.TabStop = true;
			this._chkCommon_127.Text = "Show in Batch Posting";
			this._chkCommon_127.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_127.Visible = true;
			this._chkCommon_127.CheckStateChanged += new System.EventHandler(this.chkCommon_CheckStateChanged);
			// 
			// _chkCommon_60
			// 
			this._chkCommon_60.AllowDrop = true;
			this._chkCommon_60.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkCommon_60.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._chkCommon_60.CausesValidation = true;
			this._chkCommon_60.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_60.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkCommon_60.Enabled = true;
			this._chkCommon_60.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkCommon_60.Location = new System.Drawing.Point(24, 126);
			this._chkCommon_60.Name = "_chkCommon_60";
			this._chkCommon_60.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkCommon_60.Size = new System.Drawing.Size(133, 17);
			this._chkCommon_60.TabIndex = 46;
			this._chkCommon_60.TabStop = true;
			this._chkCommon_60.Text = "Allow Online Posting";
			this._chkCommon_60.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_60.Visible = true;
			this._chkCommon_60.CheckStateChanged += new System.EventHandler(this.chkCommon_CheckStateChanged);
			// 
			// _fraCommon_16
			// 
			this._fraCommon_16.AllowDrop = true;
			this._fraCommon_16.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._fraCommon_16.Controls.Add(this._chkCommon_59);
			this._fraCommon_16.Controls.Add(this._chkCommon_58);
			this._fraCommon_16.Controls.Add(this._chkCommon_57);
			this._fraCommon_16.Controls.Add(this._chkCommon_56);
			this._fraCommon_16.Controls.Add(this._chkCommon_55);
			this._fraCommon_16.Controls.Add(this._chkCommon_54);
			this._fraCommon_16.Enabled = true;
			this._fraCommon_16.ForeColor = System.Drawing.SystemColors.WindowText;
			this._fraCommon_16.Location = new System.Drawing.Point(251, 146);
			this._fraCommon_16.Name = "_fraCommon_16";
			this._fraCommon_16.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._fraCommon_16.Size = new System.Drawing.Size(225, 153);
			this._fraCommon_16.TabIndex = 174;
			this._fraCommon_16.Text = " Batch Post Settings ";
			this._fraCommon_16.Visible = true;
			// 
			// _chkCommon_59
			// 
			this._chkCommon_59.AllowDrop = true;
			this._chkCommon_59.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkCommon_59.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._chkCommon_59.CausesValidation = true;
			this._chkCommon_59.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_59.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkCommon_59.Enabled = true;
			this._chkCommon_59.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkCommon_59.Location = new System.Drawing.Point(12, 20);
			this._chkCommon_59.Name = "_chkCommon_59";
			this._chkCommon_59.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkCommon_59.Size = new System.Drawing.Size(174, 17);
			this._chkCommon_59.TabIndex = 40;
			this._chkCommon_59.TabStop = true;
			this._chkCommon_59.Text = "Stock Qty";
			this._chkCommon_59.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_59.Visible = true;
			this._chkCommon_59.CheckStateChanged += new System.EventHandler(this.chkCommon_CheckStateChanged);
			// 
			// _chkCommon_58
			// 
			this._chkCommon_58.AllowDrop = true;
			this._chkCommon_58.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkCommon_58.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._chkCommon_58.CausesValidation = true;
			this._chkCommon_58.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_58.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkCommon_58.Enabled = true;
			this._chkCommon_58.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkCommon_58.Location = new System.Drawing.Point(12, 37);
			this._chkCommon_58.Name = "_chkCommon_58";
			this._chkCommon_58.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkCommon_58.Size = new System.Drawing.Size(174, 17);
			this._chkCommon_58.TabIndex = 41;
			this._chkCommon_58.TabStop = true;
			this._chkCommon_58.Text = "Cash / Party Balances";
			this._chkCommon_58.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_58.Visible = true;
			this._chkCommon_58.CheckStateChanged += new System.EventHandler(this.chkCommon_CheckStateChanged);
			// 
			// _chkCommon_57
			// 
			this._chkCommon_57.AllowDrop = true;
			this._chkCommon_57.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkCommon_57.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._chkCommon_57.CausesValidation = true;
			this._chkCommon_57.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_57.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkCommon_57.Enabled = true;
			this._chkCommon_57.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkCommon_57.Location = new System.Drawing.Point(12, 105);
			this._chkCommon_57.Name = "_chkCommon_57";
			this._chkCommon_57.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkCommon_57.Size = new System.Drawing.Size(174, 17);
			this._chkCommon_57.TabIndex = 45;
			this._chkCommon_57.TabStop = true;
			this._chkCommon_57.Text = "General Ledger";
			this._chkCommon_57.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_57.Visible = true;
			this._chkCommon_57.CheckStateChanged += new System.EventHandler(this.chkCommon_CheckStateChanged);
			// 
			// _chkCommon_56
			// 
			this._chkCommon_56.AllowDrop = true;
			this._chkCommon_56.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkCommon_56.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._chkCommon_56.CausesValidation = true;
			this._chkCommon_56.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_56.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkCommon_56.Enabled = true;
			this._chkCommon_56.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkCommon_56.Location = new System.Drawing.Point(12, 88);
			this._chkCommon_56.Name = "_chkCommon_56";
			this._chkCommon_56.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkCommon_56.Size = new System.Drawing.Size(174, 17);
			this._chkCommon_56.TabIndex = 44;
			this._chkCommon_56.TabStop = true;
			this._chkCommon_56.Text = "Inventory / Cost of Sales";
			this._chkCommon_56.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_56.Visible = true;
			this._chkCommon_56.CheckStateChanged += new System.EventHandler(this.chkCommon_CheckStateChanged);
			// 
			// _chkCommon_55
			// 
			this._chkCommon_55.AllowDrop = true;
			this._chkCommon_55.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkCommon_55.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._chkCommon_55.CausesValidation = true;
			this._chkCommon_55.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_55.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkCommon_55.Enabled = true;
			this._chkCommon_55.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkCommon_55.Location = new System.Drawing.Point(12, 71);
			this._chkCommon_55.Name = "_chkCommon_55";
			this._chkCommon_55.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkCommon_55.Size = new System.Drawing.Size(174, 17);
			this._chkCommon_55.TabIndex = 43;
			this._chkCommon_55.TabStop = true;
			this._chkCommon_55.Text = "Expenses";
			this._chkCommon_55.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_55.Visible = true;
			this._chkCommon_55.CheckStateChanged += new System.EventHandler(this.chkCommon_CheckStateChanged);
			// 
			// _chkCommon_54
			// 
			this._chkCommon_54.AllowDrop = true;
			this._chkCommon_54.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkCommon_54.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._chkCommon_54.CausesValidation = true;
			this._chkCommon_54.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_54.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkCommon_54.Enabled = true;
			this._chkCommon_54.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkCommon_54.Location = new System.Drawing.Point(12, 54);
			this._chkCommon_54.Name = "_chkCommon_54";
			this._chkCommon_54.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkCommon_54.Size = new System.Drawing.Size(174, 17);
			this._chkCommon_54.TabIndex = 42;
			this._chkCommon_54.TabStop = true;
			this._chkCommon_54.Text = "Transaction Status";
			this._chkCommon_54.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_54.Visible = true;
			this._chkCommon_54.CheckStateChanged += new System.EventHandler(this.chkCommon_CheckStateChanged);
			// 
			// _fraCommon_14
			// 
			this._fraCommon_14.AllowDrop = true;
			this._fraCommon_14.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._fraCommon_14.Controls.Add(this._chkCommon_53);
			this._fraCommon_14.Controls.Add(this._chkCommon_52);
			this._fraCommon_14.Controls.Add(this._chkCommon_51);
			this._fraCommon_14.Controls.Add(this._chkCommon_50);
			this._fraCommon_14.Controls.Add(this._chkCommon_49);
			this._fraCommon_14.Controls.Add(this._chkCommon_48);
			this._fraCommon_14.Enabled = true;
			this._fraCommon_14.ForeColor = System.Drawing.SystemColors.WindowText;
			this._fraCommon_14.Location = new System.Drawing.Point(10, 146);
			this._fraCommon_14.Name = "_fraCommon_14";
			this._fraCommon_14.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._fraCommon_14.Size = new System.Drawing.Size(225, 153);
			this._fraCommon_14.TabIndex = 173;
			this._fraCommon_14.Text = " Auto Post Settings ";
			this._fraCommon_14.Visible = true;
			// 
			// _chkCommon_53
			// 
			this._chkCommon_53.AllowDrop = true;
			this._chkCommon_53.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkCommon_53.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._chkCommon_53.CausesValidation = true;
			this._chkCommon_53.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_53.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkCommon_53.Enabled = true;
			this._chkCommon_53.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkCommon_53.Location = new System.Drawing.Point(12, 54);
			this._chkCommon_53.Name = "_chkCommon_53";
			this._chkCommon_53.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkCommon_53.Size = new System.Drawing.Size(174, 17);
			this._chkCommon_53.TabIndex = 36;
			this._chkCommon_53.TabStop = true;
			this._chkCommon_53.Text = "Transaction Status";
			this._chkCommon_53.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_53.Visible = true;
			this._chkCommon_53.CheckStateChanged += new System.EventHandler(this.chkCommon_CheckStateChanged);
			// 
			// _chkCommon_52
			// 
			this._chkCommon_52.AllowDrop = true;
			this._chkCommon_52.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkCommon_52.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._chkCommon_52.CausesValidation = true;
			this._chkCommon_52.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_52.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkCommon_52.Enabled = true;
			this._chkCommon_52.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkCommon_52.Location = new System.Drawing.Point(12, 71);
			this._chkCommon_52.Name = "_chkCommon_52";
			this._chkCommon_52.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkCommon_52.Size = new System.Drawing.Size(174, 17);
			this._chkCommon_52.TabIndex = 37;
			this._chkCommon_52.TabStop = true;
			this._chkCommon_52.Text = "Expenses";
			this._chkCommon_52.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_52.Visible = true;
			this._chkCommon_52.CheckStateChanged += new System.EventHandler(this.chkCommon_CheckStateChanged);
			// 
			// _chkCommon_51
			// 
			this._chkCommon_51.AllowDrop = true;
			this._chkCommon_51.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkCommon_51.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._chkCommon_51.CausesValidation = true;
			this._chkCommon_51.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_51.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkCommon_51.Enabled = true;
			this._chkCommon_51.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkCommon_51.Location = new System.Drawing.Point(12, 88);
			this._chkCommon_51.Name = "_chkCommon_51";
			this._chkCommon_51.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkCommon_51.Size = new System.Drawing.Size(174, 17);
			this._chkCommon_51.TabIndex = 38;
			this._chkCommon_51.TabStop = true;
			this._chkCommon_51.Text = "Inventory / Cost of Sales";
			this._chkCommon_51.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_51.Visible = true;
			this._chkCommon_51.CheckStateChanged += new System.EventHandler(this.chkCommon_CheckStateChanged);
			// 
			// _chkCommon_50
			// 
			this._chkCommon_50.AllowDrop = true;
			this._chkCommon_50.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkCommon_50.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._chkCommon_50.CausesValidation = true;
			this._chkCommon_50.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_50.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkCommon_50.Enabled = true;
			this._chkCommon_50.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkCommon_50.Location = new System.Drawing.Point(12, 105);
			this._chkCommon_50.Name = "_chkCommon_50";
			this._chkCommon_50.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkCommon_50.Size = new System.Drawing.Size(174, 17);
			this._chkCommon_50.TabIndex = 39;
			this._chkCommon_50.TabStop = true;
			this._chkCommon_50.Text = "General Ledger";
			this._chkCommon_50.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_50.Visible = true;
			this._chkCommon_50.CheckStateChanged += new System.EventHandler(this.chkCommon_CheckStateChanged);
			// 
			// _chkCommon_49
			// 
			this._chkCommon_49.AllowDrop = true;
			this._chkCommon_49.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkCommon_49.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._chkCommon_49.CausesValidation = true;
			this._chkCommon_49.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_49.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkCommon_49.Enabled = true;
			this._chkCommon_49.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkCommon_49.Location = new System.Drawing.Point(12, 37);
			this._chkCommon_49.Name = "_chkCommon_49";
			this._chkCommon_49.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkCommon_49.Size = new System.Drawing.Size(174, 17);
			this._chkCommon_49.TabIndex = 35;
			this._chkCommon_49.TabStop = true;
			this._chkCommon_49.Text = "Cash / Party Balances";
			this._chkCommon_49.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_49.Visible = true;
			this._chkCommon_49.CheckStateChanged += new System.EventHandler(this.chkCommon_CheckStateChanged);
			// 
			// _chkCommon_48
			// 
			this._chkCommon_48.AllowDrop = true;
			this._chkCommon_48.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkCommon_48.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._chkCommon_48.CausesValidation = true;
			this._chkCommon_48.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_48.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkCommon_48.Enabled = true;
			this._chkCommon_48.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkCommon_48.Location = new System.Drawing.Point(12, 20);
			this._chkCommon_48.Name = "_chkCommon_48";
			this._chkCommon_48.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkCommon_48.Size = new System.Drawing.Size(174, 17);
			this._chkCommon_48.TabIndex = 34;
			this._chkCommon_48.TabStop = true;
			this._chkCommon_48.Text = "Stock Qty";
			this._chkCommon_48.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_48.Visible = true;
			this._chkCommon_48.CheckStateChanged += new System.EventHandler(this.chkCommon_CheckStateChanged);
			// 
			// _fraCommon_5
			// 
			this._fraCommon_5.AllowDrop = true;
			this._fraCommon_5.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._fraCommon_5.Controls.Add(this._fraCommon_11);
			this._fraCommon_5.Controls.Add(this._fraCommon_12);
			this._fraCommon_5.Controls.Add(this._fraCommon_13);
			this._fraCommon_5.Enabled = true;
			this._fraCommon_5.ForeColor = System.Drawing.SystemColors.WindowText;
			this._fraCommon_5.Location = new System.Drawing.Point(-826, 23);
			this._fraCommon_5.Name = "_fraCommon_5";
			this._fraCommon_5.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._fraCommon_5.Size = new System.Drawing.Size(745, 335);
			this._fraCommon_5.TabIndex = 166;
			this._fraCommon_5.Text = "Frame1";
			this._fraCommon_5.Visible = true;
			// 
			// _fraCommon_11
			// 
			this._fraCommon_11.AllowDrop = true;
			this._fraCommon_11.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._fraCommon_11.Controls.Add(this._chkCommon_133);
			this._fraCommon_11.Controls.Add(this._chkCommon_123);
			this._fraCommon_11.Controls.Add(this._chkCommon_115);
			this._fraCommon_11.Controls.Add(this._chkCommon_71);
			this._fraCommon_11.Controls.Add(this._chkCommon_114);
			this._fraCommon_11.Controls.Add(this._chkCommon_111);
			this._fraCommon_11.Controls.Add(this._chkCommon_8);
			this._fraCommon_11.Controls.Add(this._chkCommon_22);
			this._fraCommon_11.Controls.Add(this._chkCommon_23);
			this._fraCommon_11.Controls.Add(this._chkCommon_26);
			this._fraCommon_11.Controls.Add(this._chkCommon_27);
			this._fraCommon_11.Controls.Add(this._chkCommon_28);
			this._fraCommon_11.Controls.Add(this._chkCommon_30);
			this._fraCommon_11.Controls.Add(this._chkCommon_31);
			this._fraCommon_11.Controls.Add(this._chkCommon_32);
			this._fraCommon_11.Controls.Add(this._chkCommon_40);
			this._fraCommon_11.Controls.Add(this._chkCommon_67);
			this._fraCommon_11.Controls.Add(this._chkCommon_70);
			this._fraCommon_11.Enabled = true;
			this._fraCommon_11.ForeColor = System.Drawing.SystemColors.WindowText;
			this._fraCommon_11.Location = new System.Drawing.Point(10, 10);
			this._fraCommon_11.Name = "_fraCommon_11";
			this._fraCommon_11.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._fraCommon_11.Size = new System.Drawing.Size(191, 312);
			this._fraCommon_11.TabIndex = 184;
			this._fraCommon_11.Text = " Voucher Header Settings ";
			this._fraCommon_11.Visible = true;
			// 
			// _chkCommon_133
			// 
			this._chkCommon_133.AllowDrop = true;
			this._chkCommon_133.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkCommon_133.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._chkCommon_133.CausesValidation = true;
			this._chkCommon_133.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_133.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkCommon_133.Enabled = true;
			this._chkCommon_133.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkCommon_133.Location = new System.Drawing.Point(12, 64);
			this._chkCommon_133.Name = "_chkCommon_133";
			this._chkCommon_133.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkCommon_133.Size = new System.Drawing.Size(174, 17);
			this._chkCommon_133.TabIndex = 249;
			this._chkCommon_133.TabStop = true;
			this._chkCommon_133.Text = "Enable Cash Credit";
			this._chkCommon_133.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_133.Visible = true;
			this._chkCommon_133.CheckStateChanged += new System.EventHandler(this.chkCommon_CheckStateChanged);
			// 
			// _chkCommon_123
			// 
			this._chkCommon_123.AllowDrop = true;
			this._chkCommon_123.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkCommon_123.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._chkCommon_123.CausesValidation = true;
			this._chkCommon_123.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_123.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkCommon_123.Enabled = true;
			this._chkCommon_123.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkCommon_123.Location = new System.Drawing.Point(12, 284);
			this._chkCommon_123.Name = "_chkCommon_123";
			this._chkCommon_123.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkCommon_123.Size = new System.Drawing.Size(174, 17);
			this._chkCommon_123.TabIndex = 227;
			this._chkCommon_123.TabStop = true;
			this._chkCommon_123.Text = "Show Branch";
			this._chkCommon_123.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_123.Visible = true;
			this._chkCommon_123.CheckStateChanged += new System.EventHandler(this.chkCommon_CheckStateChanged);
			// 
			// _chkCommon_115
			// 
			this._chkCommon_115.AllowDrop = true;
			this._chkCommon_115.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkCommon_115.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._chkCommon_115.CausesValidation = true;
			this._chkCommon_115.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_115.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkCommon_115.Enabled = true;
			this._chkCommon_115.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkCommon_115.Location = new System.Drawing.Point(12, 269);
			this._chkCommon_115.Name = "_chkCommon_115";
			this._chkCommon_115.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkCommon_115.Size = new System.Drawing.Size(174, 17);
			this._chkCommon_115.TabIndex = 225;
			this._chkCommon_115.TabStop = true;
			this._chkCommon_115.Text = "Show Expenses Ldger Code";
			this._chkCommon_115.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_115.Visible = true;
			this._chkCommon_115.CheckStateChanged += new System.EventHandler(this.chkCommon_CheckStateChanged);
			// 
			// _chkCommon_71
			// 
			this._chkCommon_71.AllowDrop = true;
			this._chkCommon_71.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkCommon_71.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._chkCommon_71.CausesValidation = true;
			this._chkCommon_71.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_71.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkCommon_71.Enabled = true;
			this._chkCommon_71.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkCommon_71.Location = new System.Drawing.Point(12, 253);
			this._chkCommon_71.Name = "_chkCommon_71";
			this._chkCommon_71.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkCommon_71.Size = new System.Drawing.Size(174, 17);
			this._chkCommon_71.TabIndex = 224;
			this._chkCommon_71.TabStop = true;
			this._chkCommon_71.Text = "Show Doctor Prescription";
			this._chkCommon_71.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_71.Visible = true;
			this._chkCommon_71.CheckStateChanged += new System.EventHandler(this.chkCommon_CheckStateChanged);
			// 
			// _chkCommon_114
			// 
			this._chkCommon_114.AllowDrop = true;
			this._chkCommon_114.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkCommon_114.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._chkCommon_114.CausesValidation = true;
			this._chkCommon_114.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_114.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkCommon_114.Enabled = true;
			this._chkCommon_114.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkCommon_114.Location = new System.Drawing.Point(12, 238);
			this._chkCommon_114.Name = "_chkCommon_114";
			this._chkCommon_114.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkCommon_114.Size = new System.Drawing.Size(174, 17);
			this._chkCommon_114.TabIndex = 95;
			this._chkCommon_114.TabStop = true;
			this._chkCommon_114.Text = "Show Batch Code";
			this._chkCommon_114.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_114.Visible = true;
			this._chkCommon_114.CheckStateChanged += new System.EventHandler(this.chkCommon_CheckStateChanged);
			// 
			// _chkCommon_111
			// 
			this._chkCommon_111.AllowDrop = true;
			this._chkCommon_111.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkCommon_111.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._chkCommon_111.CausesValidation = true;
			this._chkCommon_111.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_111.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkCommon_111.Enabled = true;
			this._chkCommon_111.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkCommon_111.Location = new System.Drawing.Point(12, 222);
			this._chkCommon_111.Name = "_chkCommon_111";
			this._chkCommon_111.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkCommon_111.Size = new System.Drawing.Size(174, 17);
			this._chkCommon_111.TabIndex = 94;
			this._chkCommon_111.TabStop = true;
			this._chkCommon_111.Text = "Show Party Balance";
			this._chkCommon_111.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_111.Visible = true;
			this._chkCommon_111.CheckStateChanged += new System.EventHandler(this.chkCommon_CheckStateChanged);
			// 
			// _chkCommon_8
			// 
			this._chkCommon_8.AllowDrop = true;
			this._chkCommon_8.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkCommon_8.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._chkCommon_8.CausesValidation = true;
			this._chkCommon_8.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_8.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkCommon_8.Enabled = true;
			this._chkCommon_8.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkCommon_8.Location = new System.Drawing.Point(12, 32);
			this._chkCommon_8.Name = "_chkCommon_8";
			this._chkCommon_8.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkCommon_8.Size = new System.Drawing.Size(174, 17);
			this._chkCommon_8.TabIndex = 83;
			this._chkCommon_8.TabStop = true;
			this._chkCommon_8.Text = "Show Ledger";
			this._chkCommon_8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_8.Visible = true;
			this._chkCommon_8.CheckStateChanged += new System.EventHandler(this.chkCommon_CheckStateChanged);
			// 
			// _chkCommon_22
			// 
			this._chkCommon_22.AllowDrop = true;
			this._chkCommon_22.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkCommon_22.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._chkCommon_22.CausesValidation = true;
			this._chkCommon_22.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_22.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkCommon_22.Enabled = true;
			this._chkCommon_22.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkCommon_22.Location = new System.Drawing.Point(12, 16);
			this._chkCommon_22.Name = "_chkCommon_22";
			this._chkCommon_22.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkCommon_22.Size = new System.Drawing.Size(174, 17);
			this._chkCommon_22.TabIndex = 82;
			this._chkCommon_22.TabStop = true;
			this._chkCommon_22.Text = "Show Location";
			this._chkCommon_22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_22.Visible = true;
			this._chkCommon_22.CheckStateChanged += new System.EventHandler(this.chkCommon_CheckStateChanged);
			// 
			// _chkCommon_23
			// 
			this._chkCommon_23.AllowDrop = true;
			this._chkCommon_23.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkCommon_23.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._chkCommon_23.CausesValidation = true;
			this._chkCommon_23.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_23.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkCommon_23.Enabled = true;
			this._chkCommon_23.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkCommon_23.Location = new System.Drawing.Point(12, 48);
			this._chkCommon_23.Name = "_chkCommon_23";
			this._chkCommon_23.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkCommon_23.Size = new System.Drawing.Size(174, 17);
			this._chkCommon_23.TabIndex = 84;
			this._chkCommon_23.TabStop = true;
			this._chkCommon_23.Text = "Show Cash / Credit";
			this._chkCommon_23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_23.Visible = true;
			this._chkCommon_23.CheckStateChanged += new System.EventHandler(this.chkCommon_CheckStateChanged);
			// 
			// _chkCommon_26
			// 
			this._chkCommon_26.AllowDrop = true;
			this._chkCommon_26.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkCommon_26.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._chkCommon_26.CausesValidation = true;
			this._chkCommon_26.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_26.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkCommon_26.Enabled = true;
			this._chkCommon_26.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkCommon_26.Location = new System.Drawing.Point(12, 174);
			this._chkCommon_26.Name = "_chkCommon_26";
			this._chkCommon_26.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkCommon_26.Size = new System.Drawing.Size(174, 17);
			this._chkCommon_26.TabIndex = 91;
			this._chkCommon_26.TabStop = true;
			this._chkCommon_26.Text = "Show Net Amount";
			this._chkCommon_26.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_26.Visible = true;
			this._chkCommon_26.CheckStateChanged += new System.EventHandler(this.chkCommon_CheckStateChanged);
			// 
			// _chkCommon_27
			// 
			this._chkCommon_27.AllowDrop = true;
			this._chkCommon_27.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkCommon_27.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._chkCommon_27.CausesValidation = true;
			this._chkCommon_27.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_27.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkCommon_27.Enabled = true;
			this._chkCommon_27.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkCommon_27.Location = new System.Drawing.Point(12, 159);
			this._chkCommon_27.Name = "_chkCommon_27";
			this._chkCommon_27.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkCommon_27.Size = new System.Drawing.Size(174, 17);
			this._chkCommon_27.TabIndex = 90;
			this._chkCommon_27.TabStop = true;
			this._chkCommon_27.Text = "Show Discount in Percent";
			this._chkCommon_27.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_27.Visible = true;
			this._chkCommon_27.CheckStateChanged += new System.EventHandler(this.chkCommon_CheckStateChanged);
			// 
			// _chkCommon_28
			// 
			this._chkCommon_28.AllowDrop = true;
			this._chkCommon_28.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkCommon_28.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._chkCommon_28.CausesValidation = true;
			this._chkCommon_28.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_28.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkCommon_28.Enabled = true;
			this._chkCommon_28.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkCommon_28.Location = new System.Drawing.Point(12, 143);
			this._chkCommon_28.Name = "_chkCommon_28";
			this._chkCommon_28.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkCommon_28.Size = new System.Drawing.Size(174, 17);
			this._chkCommon_28.TabIndex = 89;
			this._chkCommon_28.TabStop = true;
			this._chkCommon_28.Text = "Show Expenses";
			this._chkCommon_28.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_28.Visible = true;
			this._chkCommon_28.CheckStateChanged += new System.EventHandler(this.chkCommon_CheckStateChanged);
			// 
			// _chkCommon_30
			// 
			this._chkCommon_30.AllowDrop = true;
			this._chkCommon_30.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkCommon_30.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._chkCommon_30.CausesValidation = true;
			this._chkCommon_30.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_30.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkCommon_30.Enabled = true;
			this._chkCommon_30.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkCommon_30.Location = new System.Drawing.Point(12, 127);
			this._chkCommon_30.Name = "_chkCommon_30";
			this._chkCommon_30.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkCommon_30.Size = new System.Drawing.Size(174, 17);
			this._chkCommon_30.TabIndex = 88;
			this._chkCommon_30.TabStop = true;
			this._chkCommon_30.Text = "Show Salesman";
			this._chkCommon_30.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_30.Visible = true;
			this._chkCommon_30.CheckStateChanged += new System.EventHandler(this.chkCommon_CheckStateChanged);
			// 
			// _chkCommon_31
			// 
			this._chkCommon_31.AllowDrop = true;
			this._chkCommon_31.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkCommon_31.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._chkCommon_31.CausesValidation = true;
			this._chkCommon_31.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_31.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkCommon_31.Enabled = true;
			this._chkCommon_31.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkCommon_31.Location = new System.Drawing.Point(12, 111);
			this._chkCommon_31.Name = "_chkCommon_31";
			this._chkCommon_31.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkCommon_31.Size = new System.Drawing.Size(174, 17);
			this._chkCommon_31.TabIndex = 87;
			this._chkCommon_31.TabStop = true;
			this._chkCommon_31.Text = "Show Exchange Rate";
			this._chkCommon_31.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_31.Visible = true;
			this._chkCommon_31.CheckStateChanged += new System.EventHandler(this.chkCommon_CheckStateChanged);
			// 
			// _chkCommon_32
			// 
			this._chkCommon_32.AllowDrop = true;
			this._chkCommon_32.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkCommon_32.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._chkCommon_32.CausesValidation = true;
			this._chkCommon_32.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_32.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkCommon_32.Enabled = true;
			this._chkCommon_32.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkCommon_32.Location = new System.Drawing.Point(12, 95);
			this._chkCommon_32.Name = "_chkCommon_32";
			this._chkCommon_32.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkCommon_32.Size = new System.Drawing.Size(174, 17);
			this._chkCommon_32.TabIndex = 85;
			this._chkCommon_32.TabStop = true;
			this._chkCommon_32.Text = "Show Remarks";
			this._chkCommon_32.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_32.Visible = true;
			this._chkCommon_32.CheckStateChanged += new System.EventHandler(this.chkCommon_CheckStateChanged);
			// 
			// _chkCommon_40
			// 
			this._chkCommon_40.AllowDrop = true;
			this._chkCommon_40.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkCommon_40.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._chkCommon_40.CausesValidation = true;
			this._chkCommon_40.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_40.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkCommon_40.Enabled = true;
			this._chkCommon_40.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkCommon_40.Location = new System.Drawing.Point(12, 80);
			this._chkCommon_40.Name = "_chkCommon_40";
			this._chkCommon_40.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkCommon_40.Size = new System.Drawing.Size(174, 17);
			this._chkCommon_40.TabIndex = 86;
			this._chkCommon_40.TabStop = true;
			this._chkCommon_40.Text = "Show Addition Voucher Details";
			this._chkCommon_40.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_40.Visible = true;
			this._chkCommon_40.CheckStateChanged += new System.EventHandler(this.chkCommon_CheckStateChanged);
			// 
			// _chkCommon_67
			// 
			this._chkCommon_67.AllowDrop = true;
			this._chkCommon_67.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkCommon_67.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._chkCommon_67.CausesValidation = true;
			this._chkCommon_67.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_67.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkCommon_67.Enabled = true;
			this._chkCommon_67.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkCommon_67.Location = new System.Drawing.Point(12, 190);
			this._chkCommon_67.Name = "_chkCommon_67";
			this._chkCommon_67.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkCommon_67.Size = new System.Drawing.Size(174, 17);
			this._chkCommon_67.TabIndex = 92;
			this._chkCommon_67.TabStop = true;
			this._chkCommon_67.Text = "Show Due Date";
			this._chkCommon_67.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_67.Visible = true;
			this._chkCommon_67.CheckStateChanged += new System.EventHandler(this.chkCommon_CheckStateChanged);
			// 
			// _chkCommon_70
			// 
			this._chkCommon_70.AllowDrop = true;
			this._chkCommon_70.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkCommon_70.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._chkCommon_70.CausesValidation = true;
			this._chkCommon_70.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_70.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkCommon_70.Enabled = true;
			this._chkCommon_70.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkCommon_70.Location = new System.Drawing.Point(12, 206);
			this._chkCommon_70.Name = "_chkCommon_70";
			this._chkCommon_70.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkCommon_70.Size = new System.Drawing.Size(174, 17);
			this._chkCommon_70.TabIndex = 93;
			this._chkCommon_70.TabStop = true;
			this._chkCommon_70.Text = "Show Job Code";
			this._chkCommon_70.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_70.Visible = true;
			this._chkCommon_70.CheckStateChanged += new System.EventHandler(this.chkCommon_CheckStateChanged);
			// 
			// _fraCommon_12
			// 
			this._fraCommon_12.AllowDrop = true;
			this._fraCommon_12.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._fraCommon_12.Controls.Add(this._chkCommon_136);
			this._fraCommon_12.Controls.Add(this._chkCommon_72);
			this._fraCommon_12.Controls.Add(this._chkCommon_12);
			this._fraCommon_12.Controls.Add(this._chkCommon_11);
			this._fraCommon_12.Controls.Add(this._chkCommon_10);
			this._fraCommon_12.Controls.Add(this._chkCommon_39);
			this._fraCommon_12.Controls.Add(this._chkCommon_38);
			this._fraCommon_12.Controls.Add(this._chkCommon_37);
			this._fraCommon_12.Controls.Add(this._chkCommon_34);
			this._fraCommon_12.Controls.Add(this._chkCommon_33);
			this._fraCommon_12.Controls.Add(this._chkCommon_29);
			this._fraCommon_12.Controls.Add(this._chkCommon_25);
			this._fraCommon_12.Controls.Add(this._chkCommon_24);
			this._fraCommon_12.Controls.Add(this._chkCommon_15);
			this._fraCommon_12.Controls.Add(this._chkCommon_9);
			this._fraCommon_12.Controls.Add(this._chkCommon_36);
			this._fraCommon_12.Controls.Add(this._chkCommon_85);
			this._fraCommon_12.Controls.Add(this._chkCommon_83);
			this._fraCommon_12.Controls.Add(this._chkCommon_132);
			this._fraCommon_12.Controls.Add(this._chkCommon_126);
			this._fraCommon_12.Controls.Add(this._chkCommon_103);
			this._fraCommon_12.Controls.Add(this._chkCommon_20);
			this._fraCommon_12.Controls.Add(this._chkCommon_113);
			this._fraCommon_12.Controls.Add(this._chkCommon_112);
			this._fraCommon_12.Controls.Add(this._chkCommon_13);
			this._fraCommon_12.Controls.Add(this._chkCommon_14);
			this._fraCommon_12.Controls.Add(this._chkCommon_16);
			this._fraCommon_12.Controls.Add(this._chkCommon_19);
			this._fraCommon_12.Controls.Add(this._chkCommon_21);
			this._fraCommon_12.Controls.Add(this._chkCommon_68);
			this._fraCommon_12.Controls.Add(this._chkCommon_69);
			this._fraCommon_12.Enabled = true;
			this._fraCommon_12.ForeColor = System.Drawing.SystemColors.WindowText;
			this._fraCommon_12.Location = new System.Drawing.Point(202, 10);
			this._fraCommon_12.Name = "_fraCommon_12";
			this._fraCommon_12.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._fraCommon_12.Size = new System.Drawing.Size(349, 312);
			this._fraCommon_12.TabIndex = 183;
			this._fraCommon_12.Text = " Voucher Details Settings ";
			this._fraCommon_12.Visible = true;
			// 
			// _chkCommon_136
			// 
			this._chkCommon_136.AllowDrop = true;
			this._chkCommon_136.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkCommon_136.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._chkCommon_136.CausesValidation = true;
			this._chkCommon_136.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_136.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkCommon_136.Enabled = true;
			this._chkCommon_136.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkCommon_136.Location = new System.Drawing.Point(160, 236);
			this._chkCommon_136.Name = "_chkCommon_136";
			this._chkCommon_136.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkCommon_136.Size = new System.Drawing.Size(147, 17);
			this._chkCommon_136.TabIndex = 295;
			this._chkCommon_136.TabStop = true;
			this._chkCommon_136.Text = "Show Pack Qty";
			this._chkCommon_136.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_136.Visible = true;
			this._chkCommon_136.CheckStateChanged += new System.EventHandler(this.chkCommon_CheckStateChanged);
			// 
			// _chkCommon_72
			// 
			this._chkCommon_72.AllowDrop = true;
			this._chkCommon_72.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkCommon_72.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._chkCommon_72.CausesValidation = true;
			this._chkCommon_72.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_72.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkCommon_72.Enabled = true;
			this._chkCommon_72.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkCommon_72.Location = new System.Drawing.Point(12, 252);
			this._chkCommon_72.Name = "_chkCommon_72";
			this._chkCommon_72.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkCommon_72.Size = new System.Drawing.Size(178, 17);
			this._chkCommon_72.TabIndex = 294;
			this._chkCommon_72.TabStop = true;
			this._chkCommon_72.Text = "Show Product Discount Percent ";
			this._chkCommon_72.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_72.Visible = true;
			this._chkCommon_72.CheckStateChanged += new System.EventHandler(this.chkCommon_CheckStateChanged);
			// 
			// _chkCommon_12
			// 
			this._chkCommon_12.AllowDrop = true;
			this._chkCommon_12.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkCommon_12.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._chkCommon_12.CausesValidation = true;
			this._chkCommon_12.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_12.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkCommon_12.Enabled = true;
			this._chkCommon_12.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkCommon_12.Location = new System.Drawing.Point(12, 218);
			this._chkCommon_12.Name = "_chkCommon_12";
			this._chkCommon_12.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkCommon_12.Size = new System.Drawing.Size(147, 17);
			this._chkCommon_12.TabIndex = 293;
			this._chkCommon_12.TabStop = true;
			this._chkCommon_12.Text = "Show Remarks";
			this._chkCommon_12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_12.Visible = true;
			this._chkCommon_12.CheckStateChanged += new System.EventHandler(this.chkCommon_CheckStateChanged);
			// 
			// _chkCommon_11
			// 
			this._chkCommon_11.AllowDrop = true;
			this._chkCommon_11.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkCommon_11.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._chkCommon_11.CausesValidation = true;
			this._chkCommon_11.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_11.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkCommon_11.Enabled = true;
			this._chkCommon_11.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkCommon_11.Location = new System.Drawing.Point(12, 235);
			this._chkCommon_11.Name = "_chkCommon_11";
			this._chkCommon_11.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkCommon_11.Size = new System.Drawing.Size(147, 17);
			this._chkCommon_11.TabIndex = 292;
			this._chkCommon_11.TabStop = true;
			this._chkCommon_11.Text = "Show Serial No.";
			this._chkCommon_11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_11.Visible = true;
			this._chkCommon_11.CheckStateChanged += new System.EventHandler(this.chkCommon_CheckStateChanged);
			// 
			// _chkCommon_10
			// 
			this._chkCommon_10.AllowDrop = true;
			this._chkCommon_10.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkCommon_10.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._chkCommon_10.CausesValidation = true;
			this._chkCommon_10.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_10.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkCommon_10.Enabled = true;
			this._chkCommon_10.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkCommon_10.Location = new System.Drawing.Point(12, 33);
			this._chkCommon_10.Name = "_chkCommon_10";
			this._chkCommon_10.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkCommon_10.Size = new System.Drawing.Size(108, 17);
			this._chkCommon_10.TabIndex = 291;
			this._chkCommon_10.TabStop = true;
			this._chkCommon_10.Text = "Show Barcode";
			this._chkCommon_10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_10.Visible = true;
			this._chkCommon_10.CheckStateChanged += new System.EventHandler(this.chkCommon_CheckStateChanged);
			// 
			// _chkCommon_39
			// 
			this._chkCommon_39.AllowDrop = true;
			this._chkCommon_39.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkCommon_39.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._chkCommon_39.CausesValidation = true;
			this._chkCommon_39.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_39.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkCommon_39.Enabled = true;
			this._chkCommon_39.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkCommon_39.Location = new System.Drawing.Point(12, 67);
			this._chkCommon_39.Name = "_chkCommon_39";
			this._chkCommon_39.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkCommon_39.Size = new System.Drawing.Size(147, 17);
			this._chkCommon_39.TabIndex = 290;
			this._chkCommon_39.TabStop = true;
			this._chkCommon_39.Text = "Show Product Name";
			this._chkCommon_39.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_39.Visible = true;
			this._chkCommon_39.CheckStateChanged += new System.EventHandler(this.chkCommon_CheckStateChanged);
			// 
			// _chkCommon_38
			// 
			this._chkCommon_38.AllowDrop = true;
			this._chkCommon_38.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkCommon_38.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._chkCommon_38.CausesValidation = true;
			this._chkCommon_38.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_38.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkCommon_38.Enabled = true;
			this._chkCommon_38.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkCommon_38.Location = new System.Drawing.Point(12, 83);
			this._chkCommon_38.Name = "_chkCommon_38";
			this._chkCommon_38.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkCommon_38.Size = new System.Drawing.Size(147, 17);
			this._chkCommon_38.TabIndex = 289;
			this._chkCommon_38.TabStop = true;
			this._chkCommon_38.Text = "Show Unit";
			this._chkCommon_38.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_38.Visible = true;
			this._chkCommon_38.CheckStateChanged += new System.EventHandler(this.chkCommon_CheckStateChanged);
			// 
			// _chkCommon_37
			// 
			this._chkCommon_37.AllowDrop = true;
			this._chkCommon_37.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkCommon_37.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._chkCommon_37.CausesValidation = true;
			this._chkCommon_37.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_37.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkCommon_37.Enabled = true;
			this._chkCommon_37.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkCommon_37.Location = new System.Drawing.Point(12, 117);
			this._chkCommon_37.Name = "_chkCommon_37";
			this._chkCommon_37.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkCommon_37.Size = new System.Drawing.Size(147, 17);
			this._chkCommon_37.TabIndex = 288;
			this._chkCommon_37.TabStop = true;
			this._chkCommon_37.Text = "Show Qty";
			this._chkCommon_37.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_37.Visible = true;
			this._chkCommon_37.CheckStateChanged += new System.EventHandler(this.chkCommon_CheckStateChanged);
			// 
			// _chkCommon_34
			// 
			this._chkCommon_34.AllowDrop = true;
			this._chkCommon_34.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkCommon_34.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._chkCommon_34.CausesValidation = true;
			this._chkCommon_34.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_34.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkCommon_34.Enabled = true;
			this._chkCommon_34.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkCommon_34.Location = new System.Drawing.Point(12, 151);
			this._chkCommon_34.Name = "_chkCommon_34";
			this._chkCommon_34.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkCommon_34.Size = new System.Drawing.Size(147, 17);
			this._chkCommon_34.TabIndex = 287;
			this._chkCommon_34.TabStop = true;
			this._chkCommon_34.Text = "Show Rate";
			this._chkCommon_34.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_34.Visible = true;
			this._chkCommon_34.CheckStateChanged += new System.EventHandler(this.chkCommon_CheckStateChanged);
			// 
			// _chkCommon_33
			// 
			this._chkCommon_33.AllowDrop = true;
			this._chkCommon_33.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkCommon_33.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._chkCommon_33.CausesValidation = true;
			this._chkCommon_33.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_33.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkCommon_33.Enabled = true;
			this._chkCommon_33.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkCommon_33.Location = new System.Drawing.Point(12, 50);
			this._chkCommon_33.Name = "_chkCommon_33";
			this._chkCommon_33.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkCommon_33.Size = new System.Drawing.Size(147, 17);
			this._chkCommon_33.TabIndex = 286;
			this._chkCommon_33.TabStop = true;
			this._chkCommon_33.Text = "Show Part No.";
			this._chkCommon_33.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_33.Visible = true;
			this._chkCommon_33.CheckStateChanged += new System.EventHandler(this.chkCommon_CheckStateChanged);
			// 
			// _chkCommon_29
			// 
			this._chkCommon_29.AllowDrop = true;
			this._chkCommon_29.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkCommon_29.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._chkCommon_29.CausesValidation = true;
			this._chkCommon_29.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_29.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkCommon_29.Enabled = true;
			this._chkCommon_29.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkCommon_29.Location = new System.Drawing.Point(12, 100);
			this._chkCommon_29.Name = "_chkCommon_29";
			this._chkCommon_29.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkCommon_29.Size = new System.Drawing.Size(147, 17);
			this._chkCommon_29.TabIndex = 285;
			this._chkCommon_29.TabStop = true;
			this._chkCommon_29.Text = "Show Promotion Type";
			this._chkCommon_29.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_29.Visible = true;
			this._chkCommon_29.CheckStateChanged += new System.EventHandler(this.chkCommon_CheckStateChanged);
			// 
			// _chkCommon_25
			// 
			this._chkCommon_25.AllowDrop = true;
			this._chkCommon_25.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkCommon_25.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._chkCommon_25.CausesValidation = true;
			this._chkCommon_25.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_25.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkCommon_25.Enabled = true;
			this._chkCommon_25.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkCommon_25.Location = new System.Drawing.Point(12, 168);
			this._chkCommon_25.Name = "_chkCommon_25";
			this._chkCommon_25.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkCommon_25.Size = new System.Drawing.Size(147, 17);
			this._chkCommon_25.TabIndex = 284;
			this._chkCommon_25.TabStop = true;
			this._chkCommon_25.Text = "Show Discount";
			this._chkCommon_25.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_25.Visible = true;
			this._chkCommon_25.CheckStateChanged += new System.EventHandler(this.chkCommon_CheckStateChanged);
			// 
			// _chkCommon_24
			// 
			this._chkCommon_24.AllowDrop = true;
			this._chkCommon_24.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkCommon_24.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._chkCommon_24.CausesValidation = true;
			this._chkCommon_24.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_24.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkCommon_24.Enabled = true;
			this._chkCommon_24.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkCommon_24.Location = new System.Drawing.Point(12, 16);
			this._chkCommon_24.Name = "_chkCommon_24";
			this._chkCommon_24.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkCommon_24.Size = new System.Drawing.Size(147, 17);
			this._chkCommon_24.TabIndex = 283;
			this._chkCommon_24.TabStop = true;
			this._chkCommon_24.Text = "Show Line No.";
			this._chkCommon_24.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_24.Visible = true;
			this._chkCommon_24.CheckStateChanged += new System.EventHandler(this.chkCommon_CheckStateChanged);
			// 
			// _chkCommon_15
			// 
			this._chkCommon_15.AllowDrop = true;
			this._chkCommon_15.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkCommon_15.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._chkCommon_15.CausesValidation = true;
			this._chkCommon_15.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_15.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkCommon_15.Enabled = true;
			this._chkCommon_15.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkCommon_15.Location = new System.Drawing.Point(12, 202);
			this._chkCommon_15.Name = "_chkCommon_15";
			this._chkCommon_15.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkCommon_15.Size = new System.Drawing.Size(147, 17);
			this._chkCommon_15.TabIndex = 282;
			this._chkCommon_15.TabStop = true;
			this._chkCommon_15.Text = "Show Location";
			this._chkCommon_15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_15.Visible = true;
			this._chkCommon_15.CheckStateChanged += new System.EventHandler(this.chkCommon_CheckStateChanged);
			// 
			// _chkCommon_9
			// 
			this._chkCommon_9.AllowDrop = true;
			this._chkCommon_9.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkCommon_9.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._chkCommon_9.CausesValidation = true;
			this._chkCommon_9.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_9.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkCommon_9.Enabled = true;
			this._chkCommon_9.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkCommon_9.Location = new System.Drawing.Point(12, 185);
			this._chkCommon_9.Name = "_chkCommon_9";
			this._chkCommon_9.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkCommon_9.Size = new System.Drawing.Size(147, 17);
			this._chkCommon_9.TabIndex = 281;
			this._chkCommon_9.TabStop = true;
			this._chkCommon_9.Text = "Show Amount";
			this._chkCommon_9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_9.Visible = true;
			this._chkCommon_9.CheckStateChanged += new System.EventHandler(this.chkCommon_CheckStateChanged);
			// 
			// _chkCommon_36
			// 
			this._chkCommon_36.AllowDrop = true;
			this._chkCommon_36.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkCommon_36.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._chkCommon_36.CausesValidation = true;
			this._chkCommon_36.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_36.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkCommon_36.Enabled = true;
			this._chkCommon_36.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkCommon_36.Location = new System.Drawing.Point(12, 134);
			this._chkCommon_36.Name = "_chkCommon_36";
			this._chkCommon_36.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkCommon_36.Size = new System.Drawing.Size(147, 17);
			this._chkCommon_36.TabIndex = 280;
			this._chkCommon_36.TabStop = true;
			this._chkCommon_36.Text = "Show Remaining Qty";
			this._chkCommon_36.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_36.Visible = true;
			this._chkCommon_36.CheckStateChanged += new System.EventHandler(this.chkCommon_CheckStateChanged);
			// 
			// _chkCommon_85
			// 
			this._chkCommon_85.AllowDrop = true;
			this._chkCommon_85.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkCommon_85.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._chkCommon_85.CausesValidation = true;
			this._chkCommon_85.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_85.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkCommon_85.Enabled = true;
			this._chkCommon_85.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkCommon_85.Location = new System.Drawing.Point(12, 286);
			this._chkCommon_85.Name = "_chkCommon_85";
			this._chkCommon_85.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkCommon_85.Size = new System.Drawing.Size(243, 17);
			this._chkCommon_85.TabIndex = 279;
			this._chkCommon_85.TabStop = true;
			this._chkCommon_85.Text = "Show Multiline Post Description";
			this._chkCommon_85.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_85.Visible = true;
			this._chkCommon_85.CheckStateChanged += new System.EventHandler(this.chkCommon_CheckStateChanged);
			// 
			// _chkCommon_83
			// 
			this._chkCommon_83.AllowDrop = true;
			this._chkCommon_83.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkCommon_83.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._chkCommon_83.CausesValidation = true;
			this._chkCommon_83.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_83.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkCommon_83.Enabled = true;
			this._chkCommon_83.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkCommon_83.Location = new System.Drawing.Point(12, 269);
			this._chkCommon_83.Name = "_chkCommon_83";
			this._chkCommon_83.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkCommon_83.Size = new System.Drawing.Size(243, 17);
			this._chkCommon_83.TabIndex = 278;
			this._chkCommon_83.TabStop = true;
			this._chkCommon_83.Text = "Show Multiline Pre Description";
			this._chkCommon_83.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_83.Visible = true;
			this._chkCommon_83.CheckStateChanged += new System.EventHandler(this.chkCommon_CheckStateChanged);
			// 
			// _chkCommon_132
			// 
			this._chkCommon_132.AllowDrop = true;
			this._chkCommon_132.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkCommon_132.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._chkCommon_132.CausesValidation = true;
			this._chkCommon_132.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_132.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkCommon_132.Enabled = true;
			this._chkCommon_132.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkCommon_132.Location = new System.Drawing.Point(160, 220);
			this._chkCommon_132.Name = "_chkCommon_132";
			this._chkCommon_132.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkCommon_132.Size = new System.Drawing.Size(178, 17);
			this._chkCommon_132.TabIndex = 247;
			this._chkCommon_132.TabStop = true;
			this._chkCommon_132.Text = "Show Flex1";
			this._chkCommon_132.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_132.Visible = true;
			this._chkCommon_132.CheckStateChanged += new System.EventHandler(this.chkCommon_CheckStateChanged);
			// 
			// _chkCommon_126
			// 
			this._chkCommon_126.AllowDrop = true;
			this._chkCommon_126.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkCommon_126.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._chkCommon_126.CausesValidation = true;
			this._chkCommon_126.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_126.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkCommon_126.Enabled = true;
			this._chkCommon_126.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkCommon_126.Location = new System.Drawing.Point(160, 203);
			this._chkCommon_126.Name = "_chkCommon_126";
			this._chkCommon_126.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkCommon_126.Size = new System.Drawing.Size(178, 17);
			this._chkCommon_126.TabIndex = 235;
			this._chkCommon_126.TabStop = true;
			this._chkCommon_126.Text = "Show Expiry";
			this._chkCommon_126.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_126.Visible = true;
			this._chkCommon_126.CheckStateChanged += new System.EventHandler(this.chkCommon_CheckStateChanged);
			// 
			// _chkCommon_103
			// 
			this._chkCommon_103.AllowDrop = true;
			this._chkCommon_103.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkCommon_103.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._chkCommon_103.CausesValidation = true;
			this._chkCommon_103.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_103.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkCommon_103.Enabled = true;
			this._chkCommon_103.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkCommon_103.Location = new System.Drawing.Point(160, 186);
			this._chkCommon_103.Name = "_chkCommon_103";
			this._chkCommon_103.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkCommon_103.Size = new System.Drawing.Size(178, 17);
			this._chkCommon_103.TabIndex = 223;
			this._chkCommon_103.TabStop = true;
			this._chkCommon_103.Text = "Show Supplier Tab";
			this._chkCommon_103.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_103.Visible = true;
			this._chkCommon_103.CheckStateChanged += new System.EventHandler(this.chkCommon_CheckStateChanged);
			// 
			// _chkCommon_20
			// 
			this._chkCommon_20.AllowDrop = true;
			this._chkCommon_20.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkCommon_20.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._chkCommon_20.CausesValidation = true;
			this._chkCommon_20.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_20.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkCommon_20.Enabled = true;
			this._chkCommon_20.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkCommon_20.Location = new System.Drawing.Point(160, 135);
			this._chkCommon_20.Name = "_chkCommon_20";
			this._chkCommon_20.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkCommon_20.Size = new System.Drawing.Size(178, 17);
			this._chkCommon_20.TabIndex = 103;
			this._chkCommon_20.TabStop = true;
			this._chkCommon_20.Text = "Show Purchase Price in List";
			this._chkCommon_20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_20.Visible = true;
			this._chkCommon_20.CheckStateChanged += new System.EventHandler(this.chkCommon_CheckStateChanged);
			// 
			// _chkCommon_113
			// 
			this._chkCommon_113.AllowDrop = true;
			this._chkCommon_113.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkCommon_113.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._chkCommon_113.CausesValidation = true;
			this._chkCommon_113.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_113.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkCommon_113.Enabled = true;
			this._chkCommon_113.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkCommon_113.Location = new System.Drawing.Point(160, 34);
			this._chkCommon_113.Name = "_chkCommon_113";
			this._chkCommon_113.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkCommon_113.Size = new System.Drawing.Size(178, 17);
			this._chkCommon_113.TabIndex = 99;
			this._chkCommon_113.TabStop = true;
			this._chkCommon_113.Text = "Show Dented Stock Option";
			this._chkCommon_113.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_113.Visible = true;
			this._chkCommon_113.CheckStateChanged += new System.EventHandler(this.chkCommon_CheckStateChanged);
			// 
			// _chkCommon_112
			// 
			this._chkCommon_112.AllowDrop = true;
			this._chkCommon_112.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkCommon_112.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._chkCommon_112.CausesValidation = true;
			this._chkCommon_112.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_112.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkCommon_112.Enabled = true;
			this._chkCommon_112.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkCommon_112.Location = new System.Drawing.Point(160, 17);
			this._chkCommon_112.Name = "_chkCommon_112";
			this._chkCommon_112.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkCommon_112.Size = new System.Drawing.Size(178, 17);
			this._chkCommon_112.TabIndex = 98;
			this._chkCommon_112.TabStop = true;
			this._chkCommon_112.Text = "Show Non Inventory Product";
			this._chkCommon_112.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_112.Visible = true;
			this._chkCommon_112.CheckStateChanged += new System.EventHandler(this.chkCommon_CheckStateChanged);
			// 
			// _chkCommon_13
			// 
			this._chkCommon_13.AllowDrop = true;
			this._chkCommon_13.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkCommon_13.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._chkCommon_13.CausesValidation = true;
			this._chkCommon_13.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_13.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkCommon_13.Enabled = true;
			this._chkCommon_13.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkCommon_13.Location = new System.Drawing.Point(160, 101);
			this._chkCommon_13.Name = "_chkCommon_13";
			this._chkCommon_13.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkCommon_13.Size = new System.Drawing.Size(178, 17);
			this._chkCommon_13.TabIndex = 101;
			this._chkCommon_13.TabStop = true;
			this._chkCommon_13.Text = "Show Product Group in List";
			this._chkCommon_13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_13.Visible = true;
			this._chkCommon_13.CheckStateChanged += new System.EventHandler(this.chkCommon_CheckStateChanged);
			// 
			// _chkCommon_14
			// 
			this._chkCommon_14.AllowDrop = true;
			this._chkCommon_14.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkCommon_14.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._chkCommon_14.CausesValidation = true;
			this._chkCommon_14.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_14.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkCommon_14.Enabled = true;
			this._chkCommon_14.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkCommon_14.Location = new System.Drawing.Point(160, 84);
			this._chkCommon_14.Name = "_chkCommon_14";
			this._chkCommon_14.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkCommon_14.Size = new System.Drawing.Size(178, 17);
			this._chkCommon_14.TabIndex = 100;
			this._chkCommon_14.TabStop = true;
			this._chkCommon_14.Text = "Show Base Unit in List";
			this._chkCommon_14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_14.Visible = true;
			this._chkCommon_14.CheckStateChanged += new System.EventHandler(this.chkCommon_CheckStateChanged);
			// 
			// _chkCommon_16
			// 
			this._chkCommon_16.AllowDrop = true;
			this._chkCommon_16.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkCommon_16.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._chkCommon_16.CausesValidation = true;
			this._chkCommon_16.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_16.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkCommon_16.Enabled = true;
			this._chkCommon_16.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkCommon_16.Location = new System.Drawing.Point(160, 51);
			this._chkCommon_16.Name = "_chkCommon_16";
			this._chkCommon_16.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkCommon_16.Size = new System.Drawing.Size(178, 17);
			this._chkCommon_16.TabIndex = 96;
			this._chkCommon_16.TabStop = true;
			this._chkCommon_16.Text = "Show Project";
			this._chkCommon_16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_16.Visible = true;
			this._chkCommon_16.CheckStateChanged += new System.EventHandler(this.chkCommon_CheckStateChanged);
			// 
			// _chkCommon_19
			// 
			this._chkCommon_19.AllowDrop = true;
			this._chkCommon_19.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkCommon_19.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._chkCommon_19.CausesValidation = true;
			this._chkCommon_19.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_19.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkCommon_19.Enabled = true;
			this._chkCommon_19.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkCommon_19.Location = new System.Drawing.Point(160, 152);
			this._chkCommon_19.Name = "_chkCommon_19";
			this._chkCommon_19.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkCommon_19.Size = new System.Drawing.Size(178, 17);
			this._chkCommon_19.TabIndex = 104;
			this._chkCommon_19.TabStop = true;
			this._chkCommon_19.Text = "Show Sales Price in List";
			this._chkCommon_19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_19.Visible = true;
			this._chkCommon_19.CheckStateChanged += new System.EventHandler(this.chkCommon_CheckStateChanged);
			// 
			// _chkCommon_21
			// 
			this._chkCommon_21.AllowDrop = true;
			this._chkCommon_21.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkCommon_21.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._chkCommon_21.CausesValidation = true;
			this._chkCommon_21.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_21.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkCommon_21.Enabled = true;
			this._chkCommon_21.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkCommon_21.Location = new System.Drawing.Point(160, 118);
			this._chkCommon_21.Name = "_chkCommon_21";
			this._chkCommon_21.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkCommon_21.Size = new System.Drawing.Size(178, 17);
			this._chkCommon_21.TabIndex = 102;
			this._chkCommon_21.TabStop = true;
			this._chkCommon_21.Text = "Show Product Category in List";
			this._chkCommon_21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_21.Visible = true;
			this._chkCommon_21.CheckStateChanged += new System.EventHandler(this.chkCommon_CheckStateChanged);
			// 
			// _chkCommon_68
			// 
			this._chkCommon_68.AllowDrop = true;
			this._chkCommon_68.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkCommon_68.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._chkCommon_68.CausesValidation = true;
			this._chkCommon_68.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_68.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkCommon_68.Enabled = true;
			this._chkCommon_68.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkCommon_68.Location = new System.Drawing.Point(160, 68);
			this._chkCommon_68.Name = "_chkCommon_68";
			this._chkCommon_68.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkCommon_68.Size = new System.Drawing.Size(178, 17);
			this._chkCommon_68.TabIndex = 97;
			this._chkCommon_68.TabStop = true;
			this._chkCommon_68.Text = "Show Weight";
			this._chkCommon_68.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_68.Visible = true;
			this._chkCommon_68.CheckStateChanged += new System.EventHandler(this.chkCommon_CheckStateChanged);
			// 
			// _chkCommon_69
			// 
			this._chkCommon_69.AllowDrop = true;
			this._chkCommon_69.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkCommon_69.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._chkCommon_69.CausesValidation = true;
			this._chkCommon_69.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_69.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkCommon_69.Enabled = true;
			this._chkCommon_69.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkCommon_69.Location = new System.Drawing.Point(160, 169);
			this._chkCommon_69.Name = "_chkCommon_69";
			this._chkCommon_69.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkCommon_69.Size = new System.Drawing.Size(178, 17);
			this._chkCommon_69.TabIndex = 105;
			this._chkCommon_69.TabStop = true;
			this._chkCommon_69.Text = "Show Rate UOM in List";
			this._chkCommon_69.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_69.Visible = true;
			this._chkCommon_69.CheckStateChanged += new System.EventHandler(this.chkCommon_CheckStateChanged);
			// 
			// _fraCommon_13
			// 
			this._fraCommon_13.AllowDrop = true;
			this._fraCommon_13.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._fraCommon_13.Controls.Add(this._chkCommon_18);
			this._fraCommon_13.Controls.Add(this._chkCommon_17);
			this._fraCommon_13.Controls.Add(this._chkCommon_41);
			this._fraCommon_13.Controls.Add(this._chkCommon_42);
			this._fraCommon_13.Controls.Add(this._chkCommon_43);
			this._fraCommon_13.Controls.Add(this._chkCommon_44);
			this._fraCommon_13.Controls.Add(this._chkCommon_45);
			this._fraCommon_13.Controls.Add(this._chkCommon_46);
			this._fraCommon_13.Controls.Add(this._chkCommon_47);
			this._fraCommon_13.Enabled = true;
			this._fraCommon_13.ForeColor = System.Drawing.SystemColors.WindowText;
			this._fraCommon_13.Location = new System.Drawing.Point(552, 10);
			this._fraCommon_13.Name = "_fraCommon_13";
			this._fraCommon_13.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._fraCommon_13.Size = new System.Drawing.Size(191, 312);
			this._fraCommon_13.TabIndex = 182;
			this._fraCommon_13.Text = " Voucher Status Settings ";
			this._fraCommon_13.Visible = true;
			// 
			// _chkCommon_18
			// 
			this._chkCommon_18.AllowDrop = true;
			this._chkCommon_18.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkCommon_18.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._chkCommon_18.CausesValidation = true;
			this._chkCommon_18.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_18.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkCommon_18.Enabled = true;
			this._chkCommon_18.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkCommon_18.Location = new System.Drawing.Point(12, 20);
			this._chkCommon_18.Name = "_chkCommon_18";
			this._chkCommon_18.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkCommon_18.Size = new System.Drawing.Size(174, 17);
			this._chkCommon_18.TabIndex = 106;
			this._chkCommon_18.TabStop = true;
			this._chkCommon_18.Text = "Show Base Unit";
			this._chkCommon_18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_18.Visible = true;
			this._chkCommon_18.CheckStateChanged += new System.EventHandler(this.chkCommon_CheckStateChanged);
			// 
			// _chkCommon_17
			// 
			this._chkCommon_17.AllowDrop = true;
			this._chkCommon_17.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkCommon_17.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._chkCommon_17.CausesValidation = true;
			this._chkCommon_17.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_17.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkCommon_17.Enabled = true;
			this._chkCommon_17.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkCommon_17.Location = new System.Drawing.Point(12, 36);
			this._chkCommon_17.Name = "_chkCommon_17";
			this._chkCommon_17.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkCommon_17.Size = new System.Drawing.Size(174, 17);
			this._chkCommon_17.TabIndex = 107;
			this._chkCommon_17.TabStop = true;
			this._chkCommon_17.Text = "Show Stock in Hand";
			this._chkCommon_17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_17.Visible = true;
			this._chkCommon_17.CheckStateChanged += new System.EventHandler(this.chkCommon_CheckStateChanged);
			// 
			// _chkCommon_41
			// 
			this._chkCommon_41.AllowDrop = true;
			this._chkCommon_41.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkCommon_41.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._chkCommon_41.CausesValidation = true;
			this._chkCommon_41.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_41.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkCommon_41.Enabled = true;
			this._chkCommon_41.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkCommon_41.Location = new System.Drawing.Point(12, 54);
			this._chkCommon_41.Name = "_chkCommon_41";
			this._chkCommon_41.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkCommon_41.Size = new System.Drawing.Size(174, 17);
			this._chkCommon_41.TabIndex = 108;
			this._chkCommon_41.TabStop = true;
			this._chkCommon_41.Text = "Show Allocated Stock";
			this._chkCommon_41.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_41.Visible = true;
			this._chkCommon_41.CheckStateChanged += new System.EventHandler(this.chkCommon_CheckStateChanged);
			// 
			// _chkCommon_42
			// 
			this._chkCommon_42.AllowDrop = true;
			this._chkCommon_42.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkCommon_42.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._chkCommon_42.CausesValidation = true;
			this._chkCommon_42.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_42.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkCommon_42.Enabled = true;
			this._chkCommon_42.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkCommon_42.Location = new System.Drawing.Point(12, 71);
			this._chkCommon_42.Name = "_chkCommon_42";
			this._chkCommon_42.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkCommon_42.Size = new System.Drawing.Size(174, 17);
			this._chkCommon_42.TabIndex = 109;
			this._chkCommon_42.TabStop = true;
			this._chkCommon_42.Text = "Show Stock Available";
			this._chkCommon_42.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_42.Visible = true;
			this._chkCommon_42.CheckStateChanged += new System.EventHandler(this.chkCommon_CheckStateChanged);
			// 
			// _chkCommon_43
			// 
			this._chkCommon_43.AllowDrop = true;
			this._chkCommon_43.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkCommon_43.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._chkCommon_43.CausesValidation = true;
			this._chkCommon_43.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_43.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkCommon_43.Enabled = true;
			this._chkCommon_43.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkCommon_43.Location = new System.Drawing.Point(12, 88);
			this._chkCommon_43.Name = "_chkCommon_43";
			this._chkCommon_43.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkCommon_43.Size = new System.Drawing.Size(174, 17);
			this._chkCommon_43.TabIndex = 110;
			this._chkCommon_43.TabStop = true;
			this._chkCommon_43.Text = "Show Stock in Transit";
			this._chkCommon_43.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_43.Visible = true;
			this._chkCommon_43.CheckStateChanged += new System.EventHandler(this.chkCommon_CheckStateChanged);
			// 
			// _chkCommon_44
			// 
			this._chkCommon_44.AllowDrop = true;
			this._chkCommon_44.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkCommon_44.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._chkCommon_44.CausesValidation = true;
			this._chkCommon_44.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_44.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkCommon_44.Enabled = true;
			this._chkCommon_44.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkCommon_44.Location = new System.Drawing.Point(12, 105);
			this._chkCommon_44.Name = "_chkCommon_44";
			this._chkCommon_44.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkCommon_44.Size = new System.Drawing.Size(174, 17);
			this._chkCommon_44.TabIndex = 111;
			this._chkCommon_44.TabStop = true;
			this._chkCommon_44.Text = "Show Stock on Order";
			this._chkCommon_44.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_44.Visible = true;
			this._chkCommon_44.CheckStateChanged += new System.EventHandler(this.chkCommon_CheckStateChanged);
			// 
			// _chkCommon_45
			// 
			this._chkCommon_45.AllowDrop = true;
			this._chkCommon_45.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkCommon_45.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._chkCommon_45.CausesValidation = true;
			this._chkCommon_45.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_45.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkCommon_45.Enabled = true;
			this._chkCommon_45.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkCommon_45.Location = new System.Drawing.Point(12, 122);
			this._chkCommon_45.Name = "_chkCommon_45";
			this._chkCommon_45.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkCommon_45.Size = new System.Drawing.Size(174, 17);
			this._chkCommon_45.TabIndex = 112;
			this._chkCommon_45.TabStop = true;
			this._chkCommon_45.Text = "Show Advanced Booked Stock";
			this._chkCommon_45.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_45.Visible = true;
			this._chkCommon_45.CheckStateChanged += new System.EventHandler(this.chkCommon_CheckStateChanged);
			// 
			// _chkCommon_46
			// 
			this._chkCommon_46.AllowDrop = true;
			this._chkCommon_46.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkCommon_46.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._chkCommon_46.CausesValidation = true;
			this._chkCommon_46.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_46.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkCommon_46.Enabled = true;
			this._chkCommon_46.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkCommon_46.Location = new System.Drawing.Point(12, 139);
			this._chkCommon_46.Name = "_chkCommon_46";
			this._chkCommon_46.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkCommon_46.Size = new System.Drawing.Size(174, 17);
			this._chkCommon_46.TabIndex = 113;
			this._chkCommon_46.TabStop = true;
			this._chkCommon_46.Text = "Show Stock Return in Transit";
			this._chkCommon_46.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_46.Visible = true;
			this._chkCommon_46.CheckStateChanged += new System.EventHandler(this.chkCommon_CheckStateChanged);
			// 
			// _chkCommon_47
			// 
			this._chkCommon_47.AllowDrop = true;
			this._chkCommon_47.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkCommon_47.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._chkCommon_47.CausesValidation = true;
			this._chkCommon_47.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_47.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkCommon_47.Enabled = true;
			this._chkCommon_47.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkCommon_47.Location = new System.Drawing.Point(12, 156);
			this._chkCommon_47.Name = "_chkCommon_47";
			this._chkCommon_47.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkCommon_47.Size = new System.Drawing.Size(174, 17);
			this._chkCommon_47.TabIndex = 114;
			this._chkCommon_47.TabStop = true;
			this._chkCommon_47.Text = "Show On Order Stock (Sales)";
			this._chkCommon_47.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_47.Visible = true;
			this._chkCommon_47.CheckStateChanged += new System.EventHandler(this.chkCommon_CheckStateChanged);
			// 
			// _fraCommon_0
			// 
			this._fraCommon_0.AllowDrop = true;
			this._fraCommon_0.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._fraCommon_0.Controls.Add(this._chkCommon_102);
			this._fraCommon_0.Controls.Add(this._fraCommon_24);
			this._fraCommon_0.Controls.Add(this._chkCommon_6);
			this._fraCommon_0.Controls.Add(this._fraCommon_2);
			this._fraCommon_0.Controls.Add(this._fraCommon_4);
			this._fraCommon_0.Controls.Add(this._chkCommon_4);
			this._fraCommon_0.Controls.Add(this._lblCommon_8);
			this._fraCommon_0.Controls.Add(this._lblCommon_9);
			this._fraCommon_0.Controls.Add(this._lblCommon_10);
			this._fraCommon_0.Controls.Add(this._lblCommon_11);
			this._fraCommon_0.Controls.Add(this._txtCommonLabel_1);
			this._fraCommon_0.Controls.Add(this._lblCommon_17);
			this._fraCommon_0.Controls.Add(this._txtCommonLabel_3);
			this._fraCommon_0.Controls.Add(this._txtCommon_7);
			this._fraCommon_0.Controls.Add(this._txtCommon_8);
			this._fraCommon_0.Controls.Add(this._txtCommonLabel_2);
			this._fraCommon_0.Controls.Add(this._txtCommonLabel_21);
			this._fraCommon_0.Controls.Add(this._txtCommon_6);
			this._fraCommon_0.Controls.Add(this._txtCommon_9);
			this._fraCommon_0.Controls.Add(this._cmbCommon_0);
			this._fraCommon_0.Enabled = true;
			this._fraCommon_0.ForeColor = System.Drawing.SystemColors.WindowText;
			this._fraCommon_0.Location = new System.Drawing.Point(-866, 23);
			this._fraCommon_0.Name = "_fraCommon_0";
			this._fraCommon_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._fraCommon_0.Size = new System.Drawing.Size(745, 335);
			this._fraCommon_0.TabIndex = 158;
			this._fraCommon_0.Text = "Frame1";
			this._fraCommon_0.Visible = true;
			// 
			// _chkCommon_102
			// 
			this._chkCommon_102.AllowDrop = true;
			this._chkCommon_102.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkCommon_102.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._chkCommon_102.CausesValidation = true;
			this._chkCommon_102.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_102.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkCommon_102.Enabled = true;
			this._chkCommon_102.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkCommon_102.Location = new System.Drawing.Point(418, 240);
			this._chkCommon_102.Name = "_chkCommon_102";
			this._chkCommon_102.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkCommon_102.Size = new System.Drawing.Size(149, 17);
			this._chkCommon_102.TabIndex = 262;
			this._chkCommon_102.TabStop = true;
			this._chkCommon_102.Text = "Begin with Line Seperator";
			this._chkCommon_102.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_102.Visible = true;
			this._chkCommon_102.CheckStateChanged += new System.EventHandler(this.chkCommon_CheckStateChanged);
			// 
			// _fraCommon_24
			// 
			this._fraCommon_24.AllowDrop = true;
			this._fraCommon_24.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._fraCommon_24.Controls.Add(this._chkCommon_124);
			this._fraCommon_24.Controls.Add(this._chkCommon_7);
			this._fraCommon_24.Controls.Add(this._lblCommon_47);
			this._fraCommon_24.Controls.Add(this._txtCommon_39);
			this._fraCommon_24.Enabled = true;
			this._fraCommon_24.ForeColor = System.Drawing.SystemColors.WindowText;
			this._fraCommon_24.Location = new System.Drawing.Point(404, 8);
			this._fraCommon_24.Name = "_fraCommon_24";
			this._fraCommon_24.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._fraCommon_24.Size = new System.Drawing.Size(169, 87);
			this._fraCommon_24.TabIndex = 251;
			this._fraCommon_24.Text = "Voucher Number";
			this._fraCommon_24.Visible = true;
			// 
			// _chkCommon_124
			// 
			this._chkCommon_124.AllowDrop = true;
			this._chkCommon_124.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkCommon_124.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._chkCommon_124.CausesValidation = true;
			this._chkCommon_124.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_124.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkCommon_124.Enabled = true;
			this._chkCommon_124.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkCommon_124.Location = new System.Drawing.Point(6, 38);
			this._chkCommon_124.Name = "_chkCommon_124";
			this._chkCommon_124.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkCommon_124.Size = new System.Drawing.Size(156, 17);
			this._chkCommon_124.TabIndex = 253;
			this._chkCommon_124.TabStop = true;
			this._chkCommon_124.Text = "Get Max New Voucher No.";
			this._chkCommon_124.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_124.Visible = true;
			this._chkCommon_124.CheckStateChanged += new System.EventHandler(this.chkCommon_CheckStateChanged);
			// 
			// _chkCommon_7
			// 
			this._chkCommon_7.AllowDrop = true;
			this._chkCommon_7.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkCommon_7.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._chkCommon_7.CausesValidation = true;
			this._chkCommon_7.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_7.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkCommon_7.Enabled = true;
			this._chkCommon_7.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkCommon_7.Location = new System.Drawing.Point(6, 18);
			this._chkCommon_7.Name = "_chkCommon_7";
			this._chkCommon_7.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkCommon_7.Size = new System.Drawing.Size(154, 17);
			this._chkCommon_7.TabIndex = 252;
			this._chkCommon_7.TabStop = true;
			this._chkCommon_7.Text = "Auto Generate Voucher No.";
			this._chkCommon_7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_7.Visible = true;
			this._chkCommon_7.CheckStateChanged += new System.EventHandler(this.chkCommon_CheckStateChanged);
			// 
			// _lblCommon_47
			// 
			this._lblCommon_47.AllowDrop = true;
			this._lblCommon_47.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._lblCommon_47.Text = "Number Method";
			this._lblCommon_47.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_47.Location = new System.Drawing.Point(6, 60);
			this._lblCommon_47.Name = "_lblCommon_47";
			this._lblCommon_47.Size = new System.Drawing.Size(75, 14);
			this._lblCommon_47.TabIndex = 254;
			// 
			// _txtCommon_39
			// 
			this._txtCommon_39.AllowDrop = true;
			this._txtCommon_39.BackColor = System.Drawing.Color.White;
			// this._txtCommon_39.bolNumericOnly = true;
			this._txtCommon_39.ForeColor = System.Drawing.Color.Black;
			this._txtCommon_39.Location = new System.Drawing.Point(86, 58);
			this._txtCommon_39.Name = "_txtCommon_39";
			this._txtCommon_39.Size = new System.Drawing.Size(67, 19);
			this._txtCommon_39.TabIndex = 255;
			this._txtCommon_39.Text = "";
			// this.this._txtCommon_39.Change += new System.Windows.Forms.TextBox.ChangeHandler(this.txtCommon_Change);
			// this.this._txtCommon_39.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommon_DropButtonClick);
			// this._txtCommon_39.Leave += new System.EventHandler(this.txtCommon_Leave);
			// 
			// _chkCommon_6
			// 
			this._chkCommon_6.AllowDrop = true;
			this._chkCommon_6.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkCommon_6.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._chkCommon_6.CausesValidation = true;
			this._chkCommon_6.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_6.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkCommon_6.Enabled = true;
			this._chkCommon_6.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkCommon_6.Location = new System.Drawing.Point(404, 224);
			this._chkCommon_6.Name = "_chkCommon_6";
			this._chkCommon_6.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkCommon_6.Size = new System.Drawing.Size(94, 17);
			this._chkCommon_6.TabIndex = 81;
			this._chkCommon_6.TabStop = true;
			this._chkCommon_6.Text = "Show in Menu";
			this._chkCommon_6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_6.Visible = true;
			this._chkCommon_6.CheckStateChanged += new System.EventHandler(this.chkCommon_CheckStateChanged);
			// 
			// _fraCommon_2
			// 
			this._fraCommon_2.AllowDrop = true;
			this._fraCommon_2.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._fraCommon_2.Controls.Add(this._chkCommon_131);
			this._fraCommon_2.Controls.Add(this._chkCommon_122);
			this._fraCommon_2.Controls.Add(this._chkCommon_93);
			this._fraCommon_2.Controls.Add(this._chkCommon_0);
			this._fraCommon_2.Controls.Add(this._chkCommon_1);
			this._fraCommon_2.Controls.Add(this._chkCommon_2);
			this._fraCommon_2.Controls.Add(this._chkCommon_3);
			this._fraCommon_2.Controls.Add(this._chkCommon_5);
			this._fraCommon_2.Controls.Add(this._optCommonAffectType_8);
			this._fraCommon_2.Controls.Add(this._optCommonAffectType_7);
			this._fraCommon_2.Controls.Add(this._optCommonAffectType_2);
			this._fraCommon_2.Controls.Add(this._optCommonAffectType_3);
			this._fraCommon_2.Controls.Add(this._optCommonAffectType_4);
			this._fraCommon_2.Controls.Add(this._optCommonAffectType_5);
			this._fraCommon_2.Controls.Add(this._optCommonAffectType_6);
			this._fraCommon_2.Controls.Add(this._optCommonAffectType_1);
			this._fraCommon_2.Controls.Add(this._optCommonAffectType_0);
			this._fraCommon_2.Enabled = true;
			this._fraCommon_2.ForeColor = System.Drawing.SystemColors.WindowText;
			this._fraCommon_2.Location = new System.Drawing.Point(6, 104);
			this._fraCommon_2.Name = "_fraCommon_2";
			this._fraCommon_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._fraCommon_2.Size = new System.Drawing.Size(391, 195);
			this._fraCommon_2.TabIndex = 164;
			this._fraCommon_2.Text = " Voucher Affects ";
			this._fraCommon_2.Visible = true;
			// 
			// _chkCommon_131
			// 
			this._chkCommon_131.AllowDrop = true;
			this._chkCommon_131.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkCommon_131.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._chkCommon_131.CausesValidation = true;
			this._chkCommon_131.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_131.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkCommon_131.Enabled = true;
			this._chkCommon_131.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkCommon_131.Location = new System.Drawing.Point(216, 60);
			this._chkCommon_131.Name = "_chkCommon_131";
			this._chkCommon_131.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkCommon_131.Size = new System.Drawing.Size(133, 17);
			this._chkCommon_131.TabIndex = 246;
			this._chkCommon_131.TabStop = true;
			this._chkCommon_131.Text = "Generate R/P Voucher";
			this._chkCommon_131.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_131.Visible = true;
			this._chkCommon_131.CheckStateChanged += new System.EventHandler(this.chkCommon_CheckStateChanged);
			// 
			// _chkCommon_122
			// 
			this._chkCommon_122.AllowDrop = true;
			this._chkCommon_122.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkCommon_122.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._chkCommon_122.CausesValidation = true;
			this._chkCommon_122.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_122.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkCommon_122.Enabled = true;
			this._chkCommon_122.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkCommon_122.Location = new System.Drawing.Point(216, 174);
			this._chkCommon_122.Name = "_chkCommon_122";
			this._chkCommon_122.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkCommon_122.Size = new System.Drawing.Size(170, 17);
			this._chkCommon_122.TabIndex = 226;
			this._chkCommon_122.TabStop = true;
			this._chkCommon_122.Text = "Affect GL With Expenses";
			this._chkCommon_122.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_122.Visible = true;
			this._chkCommon_122.CheckStateChanged += new System.EventHandler(this.chkCommon_CheckStateChanged);
			// 
			// _chkCommon_93
			// 
			this._chkCommon_93.AllowDrop = true;
			this._chkCommon_93.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkCommon_93.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._chkCommon_93.CausesValidation = true;
			this._chkCommon_93.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_93.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkCommon_93.Enabled = false;
			this._chkCommon_93.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkCommon_93.Location = new System.Drawing.Point(216, 155);
			this._chkCommon_93.Name = "_chkCommon_93";
			this._chkCommon_93.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkCommon_93.Size = new System.Drawing.Size(170, 17);
			this._chkCommon_93.TabIndex = 75;
			this._chkCommon_93.TabStop = true;
			this._chkCommon_93.Text = "Generate On Multiple Locations";
			this._chkCommon_93.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_93.Visible = true;
			this._chkCommon_93.CheckStateChanged += new System.EventHandler(this.chkCommon_CheckStateChanged);
			// 
			// _chkCommon_0
			// 
			this._chkCommon_0.AllowDrop = true;
			this._chkCommon_0.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkCommon_0.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._chkCommon_0.CausesValidation = true;
			this._chkCommon_0.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_0.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkCommon_0.Enabled = true;
			this._chkCommon_0.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkCommon_0.Location = new System.Drawing.Point(216, 40);
			this._chkCommon_0.Name = "_chkCommon_0";
			this._chkCommon_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkCommon_0.Size = new System.Drawing.Size(143, 17);
			this._chkCommon_0.TabIndex = 70;
			this._chkCommon_0.TabStop = true;
			this._chkCommon_0.Text = "Affect GLS";
			this._chkCommon_0.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_0.Visible = true;
			this._chkCommon_0.CheckStateChanged += new System.EventHandler(this.chkCommon_CheckStateChanged);
			// 
			// _chkCommon_1
			// 
			this._chkCommon_1.AllowDrop = true;
			this._chkCommon_1.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkCommon_1.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._chkCommon_1.CausesValidation = true;
			this._chkCommon_1.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_1.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkCommon_1.Enabled = true;
			this._chkCommon_1.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkCommon_1.Location = new System.Drawing.Point(216, 79);
			this._chkCommon_1.Name = "_chkCommon_1";
			this._chkCommon_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkCommon_1.Size = new System.Drawing.Size(143, 17);
			this._chkCommon_1.TabIndex = 71;
			this._chkCommon_1.TabStop = true;
			this._chkCommon_1.Text = "Affect ICS";
			this._chkCommon_1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_1.Visible = true;
			this._chkCommon_1.CheckStateChanged += new System.EventHandler(this.chkCommon_CheckStateChanged);
			// 
			// _chkCommon_2
			// 
			this._chkCommon_2.AllowDrop = true;
			this._chkCommon_2.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkCommon_2.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._chkCommon_2.CausesValidation = true;
			this._chkCommon_2.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_2.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkCommon_2.Enabled = true;
			this._chkCommon_2.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkCommon_2.Location = new System.Drawing.Point(216, 98);
			this._chkCommon_2.Name = "_chkCommon_2";
			this._chkCommon_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkCommon_2.Size = new System.Drawing.Size(143, 17);
			this._chkCommon_2.TabIndex = 72;
			this._chkCommon_2.TabStop = true;
			this._chkCommon_2.Text = "Affect Cost";
			this._chkCommon_2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_2.Visible = true;
			this._chkCommon_2.CheckStateChanged += new System.EventHandler(this.chkCommon_CheckStateChanged);
			// 
			// _chkCommon_3
			// 
			this._chkCommon_3.AllowDrop = true;
			this._chkCommon_3.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkCommon_3.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._chkCommon_3.CausesValidation = true;
			this._chkCommon_3.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_3.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkCommon_3.Enabled = true;
			this._chkCommon_3.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkCommon_3.Location = new System.Drawing.Point(216, 117);
			this._chkCommon_3.Name = "_chkCommon_3";
			this._chkCommon_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkCommon_3.Size = new System.Drawing.Size(143, 17);
			this._chkCommon_3.TabIndex = 73;
			this._chkCommon_3.TabStop = true;
			this._chkCommon_3.Text = "Affect Opening Value";
			this._chkCommon_3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_3.Visible = true;
			this._chkCommon_3.CheckStateChanged += new System.EventHandler(this.chkCommon_CheckStateChanged);
			// 
			// _chkCommon_5
			// 
			this._chkCommon_5.AllowDrop = true;
			this._chkCommon_5.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkCommon_5.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._chkCommon_5.CausesValidation = true;
			this._chkCommon_5.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_5.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkCommon_5.Enabled = true;
			this._chkCommon_5.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkCommon_5.Location = new System.Drawing.Point(216, 136);
			this._chkCommon_5.Name = "_chkCommon_5";
			this._chkCommon_5.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkCommon_5.Size = new System.Drawing.Size(143, 17);
			this._chkCommon_5.TabIndex = 74;
			this._chkCommon_5.TabStop = true;
			this._chkCommon_5.Text = "Store to Store";
			this._chkCommon_5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_5.Visible = true;
			this._chkCommon_5.CheckStateChanged += new System.EventHandler(this.chkCommon_CheckStateChanged);
			// 
			// _optCommonAffectType_8
			// 
			this._optCommonAffectType_8.AllowDrop = true;
			this._optCommonAffectType_8.Appearance = System.Windows.Forms.Appearance.Normal;
			this._optCommonAffectType_8.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._optCommonAffectType_8.CausesValidation = true;
			this._optCommonAffectType_8.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._optCommonAffectType_8.Checked = false;
			this._optCommonAffectType_8.Enabled = true;
			this._optCommonAffectType_8.ForeColor = System.Drawing.SystemColors.ControlText;
			this._optCommonAffectType_8.Location = new System.Drawing.Point(12, 172);
			this._optCommonAffectType_8.Name = "_optCommonAffectType_8";
			this._optCommonAffectType_8.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._optCommonAffectType_8.Size = new System.Drawing.Size(174, 19);
			this._optCommonAffectType_8.TabIndex = 69;
			this._optCommonAffectType_8.TabStop = true;
			this._optCommonAffectType_8.Text = "None";
			this._optCommonAffectType_8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._optCommonAffectType_8.Visible = true;
			this._optCommonAffectType_8.CheckedChanged += new System.EventHandler(this.optCommonAffectType_CheckedChanged);
			// 
			// _optCommonAffectType_7
			// 
			this._optCommonAffectType_7.AllowDrop = true;
			this._optCommonAffectType_7.Appearance = System.Windows.Forms.Appearance.Normal;
			this._optCommonAffectType_7.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._optCommonAffectType_7.CausesValidation = true;
			this._optCommonAffectType_7.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._optCommonAffectType_7.Checked = false;
			this._optCommonAffectType_7.Enabled = true;
			this._optCommonAffectType_7.ForeColor = System.Drawing.SystemColors.ControlText;
			this._optCommonAffectType_7.Location = new System.Drawing.Point(12, 96);
			this._optCommonAffectType_7.Name = "_optCommonAffectType_7";
			this._optCommonAffectType_7.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._optCommonAffectType_7.Size = new System.Drawing.Size(174, 19);
			this._optCommonAffectType_7.TabIndex = 65;
			this._optCommonAffectType_7.TabStop = true;
			this._optCommonAffectType_7.Text = "Stock On Order (Sales)";
			this._optCommonAffectType_7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._optCommonAffectType_7.Visible = true;
			this._optCommonAffectType_7.CheckedChanged += new System.EventHandler(this.optCommonAffectType_CheckedChanged);
			// 
			// _optCommonAffectType_2
			// 
			this._optCommonAffectType_2.AllowDrop = true;
			this._optCommonAffectType_2.Appearance = System.Windows.Forms.Appearance.Normal;
			this._optCommonAffectType_2.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._optCommonAffectType_2.CausesValidation = true;
			this._optCommonAffectType_2.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._optCommonAffectType_2.Checked = false;
			this._optCommonAffectType_2.Enabled = true;
			this._optCommonAffectType_2.ForeColor = System.Drawing.SystemColors.ControlText;
			this._optCommonAffectType_2.Location = new System.Drawing.Point(12, 39);
			this._optCommonAffectType_2.Name = "_optCommonAffectType_2";
			this._optCommonAffectType_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._optCommonAffectType_2.Size = new System.Drawing.Size(174, 19);
			this._optCommonAffectType_2.TabIndex = 62;
			this._optCommonAffectType_2.TabStop = true;
			this._optCommonAffectType_2.Text = "Stock In Transit (Purchase)";
			this._optCommonAffectType_2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._optCommonAffectType_2.Visible = true;
			this._optCommonAffectType_2.CheckedChanged += new System.EventHandler(this.optCommonAffectType_CheckedChanged);
			// 
			// _optCommonAffectType_3
			// 
			this._optCommonAffectType_3.AllowDrop = true;
			this._optCommonAffectType_3.Appearance = System.Windows.Forms.Appearance.Normal;
			this._optCommonAffectType_3.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._optCommonAffectType_3.CausesValidation = true;
			this._optCommonAffectType_3.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._optCommonAffectType_3.Checked = false;
			this._optCommonAffectType_3.Enabled = true;
			this._optCommonAffectType_3.ForeColor = System.Drawing.SystemColors.ControlText;
			this._optCommonAffectType_3.Location = new System.Drawing.Point(12, 58);
			this._optCommonAffectType_3.Name = "_optCommonAffectType_3";
			this._optCommonAffectType_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._optCommonAffectType_3.Size = new System.Drawing.Size(174, 19);
			this._optCommonAffectType_3.TabIndex = 63;
			this._optCommonAffectType_3.TabStop = true;
			this._optCommonAffectType_3.Text = "Stock On Order (Purchase)";
			this._optCommonAffectType_3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._optCommonAffectType_3.Visible = true;
			this._optCommonAffectType_3.CheckedChanged += new System.EventHandler(this.optCommonAffectType_CheckedChanged);
			// 
			// _optCommonAffectType_4
			// 
			this._optCommonAffectType_4.AllowDrop = true;
			this._optCommonAffectType_4.Appearance = System.Windows.Forms.Appearance.Normal;
			this._optCommonAffectType_4.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._optCommonAffectType_4.CausesValidation = true;
			this._optCommonAffectType_4.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._optCommonAffectType_4.Checked = false;
			this._optCommonAffectType_4.Enabled = true;
			this._optCommonAffectType_4.ForeColor = System.Drawing.SystemColors.ControlText;
			this._optCommonAffectType_4.Location = new System.Drawing.Point(12, 153);
			this._optCommonAffectType_4.Name = "_optCommonAffectType_4";
			this._optCommonAffectType_4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._optCommonAffectType_4.Size = new System.Drawing.Size(174, 19);
			this._optCommonAffectType_4.TabIndex = 68;
			this._optCommonAffectType_4.TabStop = true;
			this._optCommonAffectType_4.Text = "Reserved Stock";
			this._optCommonAffectType_4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._optCommonAffectType_4.Visible = true;
			this._optCommonAffectType_4.CheckedChanged += new System.EventHandler(this.optCommonAffectType_CheckedChanged);
			// 
			// _optCommonAffectType_5
			// 
			this._optCommonAffectType_5.AllowDrop = true;
			this._optCommonAffectType_5.Appearance = System.Windows.Forms.Appearance.Normal;
			this._optCommonAffectType_5.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._optCommonAffectType_5.CausesValidation = true;
			this._optCommonAffectType_5.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._optCommonAffectType_5.Checked = false;
			this._optCommonAffectType_5.Enabled = true;
			this._optCommonAffectType_5.ForeColor = System.Drawing.SystemColors.ControlText;
			this._optCommonAffectType_5.Location = new System.Drawing.Point(12, 134);
			this._optCommonAffectType_5.Name = "_optCommonAffectType_5";
			this._optCommonAffectType_5.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._optCommonAffectType_5.Size = new System.Drawing.Size(174, 19);
			this._optCommonAffectType_5.TabIndex = 67;
			this._optCommonAffectType_5.TabStop = true;
			this._optCommonAffectType_5.Text = "Advanced Booked Stock";
			this._optCommonAffectType_5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._optCommonAffectType_5.Visible = true;
			this._optCommonAffectType_5.CheckedChanged += new System.EventHandler(this.optCommonAffectType_CheckedChanged);
			// 
			// _optCommonAffectType_6
			// 
			this._optCommonAffectType_6.AllowDrop = true;
			this._optCommonAffectType_6.Appearance = System.Windows.Forms.Appearance.Normal;
			this._optCommonAffectType_6.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._optCommonAffectType_6.CausesValidation = true;
			this._optCommonAffectType_6.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._optCommonAffectType_6.Checked = false;
			this._optCommonAffectType_6.Enabled = true;
			this._optCommonAffectType_6.ForeColor = System.Drawing.SystemColors.ControlText;
			this._optCommonAffectType_6.Location = new System.Drawing.Point(12, 115);
			this._optCommonAffectType_6.Name = "_optCommonAffectType_6";
			this._optCommonAffectType_6.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._optCommonAffectType_6.Size = new System.Drawing.Size(174, 19);
			this._optCommonAffectType_6.TabIndex = 66;
			this._optCommonAffectType_6.TabStop = true;
			this._optCommonAffectType_6.Text = "Stock Return in Transit (Sales)";
			this._optCommonAffectType_6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._optCommonAffectType_6.Visible = true;
			this._optCommonAffectType_6.CheckedChanged += new System.EventHandler(this.optCommonAffectType_CheckedChanged);
			// 
			// _optCommonAffectType_1
			// 
			this._optCommonAffectType_1.AllowDrop = true;
			this._optCommonAffectType_1.Appearance = System.Windows.Forms.Appearance.Normal;
			this._optCommonAffectType_1.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._optCommonAffectType_1.CausesValidation = true;
			this._optCommonAffectType_1.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._optCommonAffectType_1.Checked = false;
			this._optCommonAffectType_1.Enabled = true;
			this._optCommonAffectType_1.ForeColor = System.Drawing.SystemColors.ControlText;
			this._optCommonAffectType_1.Location = new System.Drawing.Point(12, 77);
			this._optCommonAffectType_1.Name = "_optCommonAffectType_1";
			this._optCommonAffectType_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._optCommonAffectType_1.Size = new System.Drawing.Size(174, 19);
			this._optCommonAffectType_1.TabIndex = 64;
			this._optCommonAffectType_1.TabStop = true;
			this._optCommonAffectType_1.Text = "Allocated Stock (Sales)";
			this._optCommonAffectType_1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._optCommonAffectType_1.Visible = true;
			this._optCommonAffectType_1.CheckedChanged += new System.EventHandler(this.optCommonAffectType_CheckedChanged);
			// 
			// _optCommonAffectType_0
			// 
			this._optCommonAffectType_0.AllowDrop = true;
			this._optCommonAffectType_0.Appearance = System.Windows.Forms.Appearance.Normal;
			this._optCommonAffectType_0.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._optCommonAffectType_0.CausesValidation = true;
			this._optCommonAffectType_0.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._optCommonAffectType_0.Checked = false;
			this._optCommonAffectType_0.Enabled = true;
			this._optCommonAffectType_0.ForeColor = System.Drawing.SystemColors.ControlText;
			this._optCommonAffectType_0.Location = new System.Drawing.Point(12, 20);
			this._optCommonAffectType_0.Name = "_optCommonAffectType_0";
			this._optCommonAffectType_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._optCommonAffectType_0.Size = new System.Drawing.Size(174, 19);
			this._optCommonAffectType_0.TabIndex = 61;
			this._optCommonAffectType_0.TabStop = true;
			this._optCommonAffectType_0.Text = "On Hand Stock";
			this._optCommonAffectType_0.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._optCommonAffectType_0.Visible = true;
			this._optCommonAffectType_0.CheckedChanged += new System.EventHandler(this.optCommonAffectType_CheckedChanged);
			// 
			// _fraCommon_4
			// 
			this._fraCommon_4.AllowDrop = true;
			this._fraCommon_4.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._fraCommon_4.Controls.Add(this._optCommonQtyEffect_1);
			this._fraCommon_4.Controls.Add(this._optCommonQtyEffect_0);
			this._fraCommon_4.Enabled = true;
			this._fraCommon_4.ForeColor = System.Drawing.SystemColors.WindowText;
			this._fraCommon_4.Location = new System.Drawing.Point(404, 104);
			this._fraCommon_4.Name = "_fraCommon_4";
			this._fraCommon_4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._fraCommon_4.Size = new System.Drawing.Size(169, 65);
			this._fraCommon_4.TabIndex = 165;
			this._fraCommon_4.Text = " Effect on Qty ";
			this._fraCommon_4.Visible = true;
			// 
			// _optCommonQtyEffect_1
			// 
			this._optCommonQtyEffect_1.AllowDrop = true;
			this._optCommonQtyEffect_1.Appearance = System.Windows.Forms.Appearance.Normal;
			this._optCommonQtyEffect_1.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._optCommonQtyEffect_1.CausesValidation = true;
			this._optCommonQtyEffect_1.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._optCommonQtyEffect_1.Checked = false;
			this._optCommonQtyEffect_1.Enabled = true;
			this._optCommonQtyEffect_1.ForeColor = System.Drawing.SystemColors.ControlText;
			this._optCommonQtyEffect_1.Location = new System.Drawing.Point(12, 39);
			this._optCommonQtyEffect_1.Name = "_optCommonQtyEffect_1";
			this._optCommonQtyEffect_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._optCommonQtyEffect_1.Size = new System.Drawing.Size(123, 19);
			this._optCommonQtyEffect_1.TabIndex = 79;
			this._optCommonQtyEffect_1.TabStop = true;
			this._optCommonQtyEffect_1.Text = "Deduct Stock";
			this._optCommonQtyEffect_1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._optCommonQtyEffect_1.Visible = true;
			this._optCommonQtyEffect_1.CheckedChanged += new System.EventHandler(this.optCommonQtyEffect_CheckedChanged);
			// 
			// _optCommonQtyEffect_0
			// 
			this._optCommonQtyEffect_0.AllowDrop = true;
			this._optCommonQtyEffect_0.Appearance = System.Windows.Forms.Appearance.Normal;
			this._optCommonQtyEffect_0.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._optCommonQtyEffect_0.CausesValidation = true;
			this._optCommonQtyEffect_0.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._optCommonQtyEffect_0.Checked = false;
			this._optCommonQtyEffect_0.Enabled = true;
			this._optCommonQtyEffect_0.ForeColor = System.Drawing.SystemColors.ControlText;
			this._optCommonQtyEffect_0.Location = new System.Drawing.Point(12, 20);
			this._optCommonQtyEffect_0.Name = "_optCommonQtyEffect_0";
			this._optCommonQtyEffect_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._optCommonQtyEffect_0.Size = new System.Drawing.Size(123, 19);
			this._optCommonQtyEffect_0.TabIndex = 78;
			this._optCommonQtyEffect_0.TabStop = true;
			this._optCommonQtyEffect_0.Text = "Increase Stock";
			this._optCommonQtyEffect_0.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._optCommonQtyEffect_0.Visible = true;
			this._optCommonQtyEffect_0.CheckedChanged += new System.EventHandler(this.optCommonQtyEffect_CheckedChanged);
			// 
			// _chkCommon_4
			// 
			this._chkCommon_4.AllowDrop = true;
			this._chkCommon_4.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkCommon_4.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._chkCommon_4.CausesValidation = true;
			this._chkCommon_4.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_4.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkCommon_4.Enabled = true;
			this._chkCommon_4.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkCommon_4.Location = new System.Drawing.Point(404, 208);
			this._chkCommon_4.Name = "_chkCommon_4";
			this._chkCommon_4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkCommon_4.Size = new System.Drawing.Size(54, 17);
			this._chkCommon_4.TabIndex = 80;
			this._chkCommon_4.TabStop = true;
			this._chkCommon_4.Text = "Show";
			this._chkCommon_4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommon_4.Visible = true;
			this._chkCommon_4.CheckStateChanged += new System.EventHandler(this.chkCommon_CheckStateChanged);
			// 
			// _lblCommon_8
			// 
			this._lblCommon_8.AllowDrop = true;
			this._lblCommon_8.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._lblCommon_8.Text = "Parent Type";
			this._lblCommon_8.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_8.Location = new System.Drawing.Point(8, 16);
			this._lblCommon_8.Name = "_lblCommon_8";
			this._lblCommon_8.Size = new System.Drawing.Size(58, 14);
			this._lblCommon_8.TabIndex = 159;
			// 
			// _lblCommon_9
			// 
			this._lblCommon_9.AllowDrop = true;
			this._lblCommon_9.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._lblCommon_9.Text = "Module Id";
			this._lblCommon_9.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_9.Location = new System.Drawing.Point(8, 37);
			this._lblCommon_9.Name = "_lblCommon_9";
			this._lblCommon_9.Size = new System.Drawing.Size(45, 14);
			this._lblCommon_9.TabIndex = 160;
			// 
			// _lblCommon_10
			// 
			this._lblCommon_10.AllowDrop = true;
			this._lblCommon_10.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._lblCommon_10.Text = "Preference Id";
			this._lblCommon_10.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_10.Location = new System.Drawing.Point(8, 58);
			this._lblCommon_10.Name = "_lblCommon_10";
			this._lblCommon_10.Size = new System.Drawing.Size(65, 14);
			this._lblCommon_10.TabIndex = 161;
			// 
			// _lblCommon_11
			// 
			this._lblCommon_11.AllowDrop = true;
			this._lblCommon_11.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._lblCommon_11.Text = "Find Id";
			this._lblCommon_11.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_11.Location = new System.Drawing.Point(8, 79);
			this._lblCommon_11.Name = "_lblCommon_11";
			this._lblCommon_11.Size = new System.Drawing.Size(31, 14);
			this._lblCommon_11.TabIndex = 162;
			// 
			// _txtCommonLabel_1
			// 
			this._txtCommonLabel_1.AllowDrop = true;
			this._txtCommonLabel_1.Location = new System.Drawing.Point(193, 35);
			this._txtCommonLabel_1.Name = "_txtCommonLabel_1";
			this._txtCommonLabel_1.Size = new System.Drawing.Size(201, 19);
			this._txtCommonLabel_1.TabIndex = 56;
			// 
			// _lblCommon_17
			// 
			this._lblCommon_17.AllowDrop = true;
			this._lblCommon_17.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._lblCommon_17.Text = "Document Type";
			this._lblCommon_17.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_17.Location = new System.Drawing.Point(404, 188);
			this._lblCommon_17.Name = "_lblCommon_17";
			this._lblCommon_17.Size = new System.Drawing.Size(75, 14);
			this._lblCommon_17.TabIndex = 76;
			// 
			// _txtCommonLabel_3
			// 
			this._txtCommonLabel_3.AllowDrop = true;
			this._txtCommonLabel_3.Location = new System.Drawing.Point(193, 14);
			this._txtCommonLabel_3.Name = "_txtCommonLabel_3";
			this._txtCommonLabel_3.Size = new System.Drawing.Size(201, 19);
			this._txtCommonLabel_3.TabIndex = 54;
			// 
			// _txtCommon_7
			// 
			this._txtCommon_7.AllowDrop = true;
			this._txtCommon_7.BackColor = System.Drawing.Color.White;
			// this._txtCommon_7.bolNumericOnly = true;
			this._txtCommon_7.ForeColor = System.Drawing.Color.Black;
			this._txtCommon_7.Location = new System.Drawing.Point(90, 56);
			this._txtCommon_7.Name = "_txtCommon_7";
			// this._txtCommon_7.ShowButton = true;
			this._txtCommon_7.Size = new System.Drawing.Size(101, 19);
			this._txtCommon_7.TabIndex = 57;
			this._txtCommon_7.Text = "";
			// this.this._txtCommon_7.Change += new System.Windows.Forms.TextBox.ChangeHandler(this.txtCommon_Change);
			// this.this._txtCommon_7.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommon_DropButtonClick);
			// this._txtCommon_7.Leave += new System.EventHandler(this.txtCommon_Leave);
			// 
			// _txtCommon_8
			// 
			this._txtCommon_8.AllowDrop = true;
			this._txtCommon_8.BackColor = System.Drawing.Color.White;
			// this._txtCommon_8.bolNumericOnly = true;
			this._txtCommon_8.ForeColor = System.Drawing.Color.Black;
			this._txtCommon_8.Location = new System.Drawing.Point(90, 77);
			this._txtCommon_8.Name = "_txtCommon_8";
			// this._txtCommon_8.ShowButton = true;
			this._txtCommon_8.Size = new System.Drawing.Size(101, 19);
			this._txtCommon_8.TabIndex = 59;
			this._txtCommon_8.Text = "";
			// this.this._txtCommon_8.Change += new System.Windows.Forms.TextBox.ChangeHandler(this.txtCommon_Change);
			// this.this._txtCommon_8.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommon_DropButtonClick);
			// this._txtCommon_8.Leave += new System.EventHandler(this.txtCommon_Leave);
			// 
			// _txtCommonLabel_2
			// 
			this._txtCommonLabel_2.AllowDrop = true;
			this._txtCommonLabel_2.Location = new System.Drawing.Point(193, 77);
			this._txtCommonLabel_2.Name = "_txtCommonLabel_2";
			this._txtCommonLabel_2.Size = new System.Drawing.Size(201, 19);
			this._txtCommonLabel_2.TabIndex = 60;
			// 
			// _txtCommonLabel_21
			// 
			this._txtCommonLabel_21.AllowDrop = true;
			this._txtCommonLabel_21.Location = new System.Drawing.Point(193, 56);
			this._txtCommonLabel_21.Name = "_txtCommonLabel_21";
			this._txtCommonLabel_21.Size = new System.Drawing.Size(201, 19);
			this._txtCommonLabel_21.TabIndex = 58;
			// 
			// _txtCommon_6
			// 
			this._txtCommon_6.AllowDrop = true;
			this._txtCommon_6.BackColor = System.Drawing.Color.White;
			// this._txtCommon_6.bolNumericOnly = true;
			this._txtCommon_6.ForeColor = System.Drawing.Color.Black;
			this._txtCommon_6.Location = new System.Drawing.Point(90, 35);
			this._txtCommon_6.Name = "_txtCommon_6";
			// this._txtCommon_6.ShowButton = true;
			this._txtCommon_6.Size = new System.Drawing.Size(101, 19);
			this._txtCommon_6.TabIndex = 55;
			this._txtCommon_6.Text = "";
			// this.this._txtCommon_6.Change += new System.Windows.Forms.TextBox.ChangeHandler(this.txtCommon_Change);
			// this.this._txtCommon_6.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommon_DropButtonClick);
			// this._txtCommon_6.Leave += new System.EventHandler(this.txtCommon_Leave);
			// 
			// _txtCommon_9
			// 
			this._txtCommon_9.AllowDrop = true;
			this._txtCommon_9.BackColor = System.Drawing.Color.White;
			// this._txtCommon_9.bolAllowDecimal = false;
			this._txtCommon_9.ForeColor = System.Drawing.Color.Black;
			this._txtCommon_9.Location = new System.Drawing.Point(90, 14);
			this._txtCommon_9.MaxLength = 10;
			// this._txtCommon_9.mDropDownType = System.Windows.Forms.TextBox.DropDownTypes.ddtNextNumber;
			this._txtCommon_9.Name = "_txtCommon_9";
			// this._txtCommon_9.ShowButton = true;
			this._txtCommon_9.Size = new System.Drawing.Size(101, 19);
			this._txtCommon_9.TabIndex = 53;
			this._txtCommon_9.Text = "";
			// this.this._txtCommon_9.Change += new System.Windows.Forms.TextBox.ChangeHandler(this.txtCommon_Change);
			// this.this._txtCommon_9.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommon_DropButtonClick);
			// this._txtCommon_9.Leave += new System.EventHandler(this.txtCommon_Leave);
			// 
			// _cmbCommon_0
			// 
			this._cmbCommon_0.AllowDrop = true;
			this._cmbCommon_0.Location = new System.Drawing.Point(488, 184);
			this._cmbCommon_0.Name = "_cmbCommon_0";
			this._cmbCommon_0.Size = new System.Drawing.Size(72, 21);
			this._cmbCommon_0.TabIndex = 77;
			// 
			// _txtCommon_1
			// 
			this._txtCommon_1.AllowDrop = true;
			this._txtCommon_1.BackColor = System.Drawing.Color.White;
			this._txtCommon_1.ForeColor = System.Drawing.Color.Black;
			this._txtCommon_1.Location = new System.Drawing.Point(328, 26);
			this._txtCommon_1.MaxLength = 50;
			this._txtCommon_1.Name = "_txtCommon_1";
			this._txtCommon_1.Size = new System.Drawing.Size(201, 19);
			this._txtCommon_1.TabIndex = 48;
			this._txtCommon_1.Text = "";
			// this.this._txtCommon_1.Change += new System.Windows.Forms.TextBox.ChangeHandler(this.txtCommon_Change);
			// this.this._txtCommon_1.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommon_DropButtonClick);
			// this._txtCommon_1.Leave += new System.EventHandler(this.txtCommon_Leave);
			// 
			// _txtCommon_2
			// 
			this._txtCommon_2.AllowDrop = true;
			this._txtCommon_2.BackColor = System.Drawing.Color.White;
			this._txtCommon_2.ForeColor = System.Drawing.Color.Black;
			this._txtCommon_2.Location = new System.Drawing.Point(328, 47);
			// this._txtCommon_2.mArabicEnabled = true;
			this._txtCommon_2.MaxLength = 50;
			this._txtCommon_2.Name = "_txtCommon_2";
			this._txtCommon_2.Size = new System.Drawing.Size(201, 19);
			this._txtCommon_2.TabIndex = 49;
			this._txtCommon_2.Text = "";
			// this.this._txtCommon_2.Change += new System.Windows.Forms.TextBox.ChangeHandler(this.txtCommon_Change);
			// this.this._txtCommon_2.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommon_DropButtonClick);
			// this._txtCommon_2.Leave += new System.EventHandler(this.txtCommon_Leave);
			// 
			// _txtCommon_0
			// 
			this._txtCommon_0.AllowDrop = true;
			this._txtCommon_0.BackColor = System.Drawing.Color.White;
			// this._txtCommon_0.bolAllowDecimal = false;
			this._txtCommon_0.ForeColor = System.Drawing.Color.Black;
			this._txtCommon_0.Location = new System.Drawing.Point(82, 26);
			this._txtCommon_0.MaxLength = 10;
			// this._txtCommon_0.mDropDownType = System.Windows.Forms.TextBox.DropDownTypes.ddtNextNumber;
			this._txtCommon_0.Name = "_txtCommon_0";
			// this._txtCommon_0.ShowButton = true;
			this._txtCommon_0.Size = new System.Drawing.Size(101, 19);
			this._txtCommon_0.TabIndex = 47;
			this._txtCommon_0.Text = "";
			// this.this._txtCommon_0.Change += new System.Windows.Forms.TextBox.ChangeHandler(this.txtCommon_Change);
			// this.this._txtCommon_0.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommon_DropButtonClick);
			// this._txtCommon_0.Leave += new System.EventHandler(this.txtCommon_Leave);
			// 
			// _lblCommon_1
			// 
			this._lblCommon_1.AllowDrop = true;
			this._lblCommon_1.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_1.Text = "Voucher Name (English)";
			this._lblCommon_1.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_1.Location = new System.Drawing.Point(204, 28);
			this._lblCommon_1.Name = "_lblCommon_1";
			this._lblCommon_1.Size = new System.Drawing.Size(117, 14);
			this._lblCommon_1.TabIndex = 152;
			// 
			// _lblCommon_6
			// 
			this._lblCommon_6.AllowDrop = true;
			this._lblCommon_6.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_6.Text = "Voucher Name (Arabic)";
			this._lblCommon_6.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_6.Location = new System.Drawing.Point(204, 49);
			this._lblCommon_6.Name = "_lblCommon_6";
			this._lblCommon_6.Size = new System.Drawing.Size(115, 14);
			this._lblCommon_6.TabIndex = 153;
			// 
			// _lblCommon_7
			// 
			this._lblCommon_7.AllowDrop = true;
			this._lblCommon_7.BackColor = System.Drawing.SystemColors.Window;
			this._lblCommon_7.Text = "(Total No of Transactions : 0) ";
			this._lblCommon_7.ForeColor = System.Drawing.Color.FromArgb(126, 126, 126);
			this._lblCommon_7.Location = new System.Drawing.Point(554, 98);
			this._lblCommon_7.Name = "_lblCommon_7";
			this._lblCommon_7.Size = new System.Drawing.Size(144, 14);
			this._lblCommon_7.TabIndex = 154;
			this._lblCommon_7.Visible = false;
			// 
			// _lblCommon_2
			// 
			this._lblCommon_2.AllowDrop = true;
			this._lblCommon_2.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_2.Text = "Description";
			this._lblCommon_2.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_2.Location = new System.Drawing.Point(8, 78);
			this._lblCommon_2.Name = "_lblCommon_2";
			this._lblCommon_2.Size = new System.Drawing.Size(54, 14);
			this._lblCommon_2.TabIndex = 155;
			// 
			// _txtCommon_3
			// 
			this._txtCommon_3.AllowDrop = true;
			this._txtCommon_3.BackColor = System.Drawing.Color.White;
			this._txtCommon_3.ForeColor = System.Drawing.Color.White;
			this._txtCommon_3.Location = new System.Drawing.Point(82, 74);
			this._txtCommon_3.MaxLength = 100;
			this._txtCommon_3.Name = "_txtCommon_3";
			this._txtCommon_3.Size = new System.Drawing.Size(649, 19);
			this._txtCommon_3.TabIndex = 52;
			this._txtCommon_3.Text = "";
			// this.this._txtCommon_3.Change += new System.Windows.Forms.TextBox.ChangeHandler(this.txtCommon_Change);
			// this.this._txtCommon_3.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommon_DropButtonClick);
			// this._txtCommon_3.Leave += new System.EventHandler(this.txtCommon_Leave);
			// 
			// _txtCommon_4
			// 
			this._txtCommon_4.AllowDrop = true;
			this._txtCommon_4.BackColor = System.Drawing.Color.White;
			this._txtCommon_4.ForeColor = System.Drawing.Color.Black;
			this._txtCommon_4.Location = new System.Drawing.Point(664, 26);
			this._txtCommon_4.MaxLength = 4;
			this._txtCommon_4.Name = "_txtCommon_4";
			this._txtCommon_4.Size = new System.Drawing.Size(50, 19);
			this._txtCommon_4.TabIndex = 50;
			this._txtCommon_4.Text = "";
			// this.this._txtCommon_4.Change += new System.Windows.Forms.TextBox.ChangeHandler(this.txtCommon_Change);
			// this.this._txtCommon_4.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommon_DropButtonClick);
			// this._txtCommon_4.Leave += new System.EventHandler(this.txtCommon_Leave);
			// 
			// _txtCommon_5
			// 
			this._txtCommon_5.AllowDrop = true;
			this._txtCommon_5.BackColor = System.Drawing.Color.White;
			this._txtCommon_5.ForeColor = System.Drawing.Color.Black;
			this._txtCommon_5.Location = new System.Drawing.Point(664, 47);
			// this._txtCommon_5.mArabicEnabled = true;
			this._txtCommon_5.MaxLength = 4;
			this._txtCommon_5.Name = "_txtCommon_5";
			this._txtCommon_5.Size = new System.Drawing.Size(50, 19);
			this._txtCommon_5.TabIndex = 51;
			this._txtCommon_5.Text = "";
			// this.this._txtCommon_5.Change += new System.Windows.Forms.TextBox.ChangeHandler(this.txtCommon_Change);
			// this.this._txtCommon_5.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommon_DropButtonClick);
			// this._txtCommon_5.Leave += new System.EventHandler(this.txtCommon_Leave);
			// 
			// _lblCommon_4
			// 
			this._lblCommon_4.AllowDrop = true;
			this._lblCommon_4.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_4.Text = "Short Name (English)";
			this._lblCommon_4.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_4.Location = new System.Drawing.Point(550, 28);
			this._lblCommon_4.Name = "_lblCommon_4";
			this._lblCommon_4.Size = new System.Drawing.Size(101, 14);
			this._lblCommon_4.TabIndex = 156;
			// 
			// _lblCommon_5
			// 
			this._lblCommon_5.AllowDrop = true;
			this._lblCommon_5.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_5.Text = "Short Name (Arabic)";
			this._lblCommon_5.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_5.Location = new System.Drawing.Point(550, 49);
			this._lblCommon_5.Name = "_lblCommon_5";
			this._lblCommon_5.Size = new System.Drawing.Size(99, 14);
			this._lblCommon_5.TabIndex = 157;
			// 
			// _lblCommon_44
			// 
			this._lblCommon_44.AllowDrop = true;
			this._lblCommon_44.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_44.Text = "Voucher Type";
			this._lblCommon_44.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_44.Location = new System.Drawing.Point(8, 26);
			this._lblCommon_44.Name = "_lblCommon_44";
			this._lblCommon_44.Size = new System.Drawing.Size(69, 14);
			this._lblCommon_44.TabIndex = 207;
			// 
			// frmICSVoucherTypes
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.ClientSize = new System.Drawing.Size(758, 534);
			this.Controls.Add(this._fraCommon_23);
			this.Controls.Add(this.tabVoucherDetails);
			this.Controls.Add(this._txtCommon_1);
			this.Controls.Add(this._txtCommon_2);
			this.Controls.Add(this._txtCommon_0);
			this.Controls.Add(this._lblCommon_1);
			this.Controls.Add(this._lblCommon_6);
			this.Controls.Add(this._lblCommon_7);
			this.Controls.Add(this._lblCommon_2);
			this.Controls.Add(this._txtCommon_3);
			this.Controls.Add(this._txtCommon_4);
			this.Controls.Add(this._txtCommon_5);
			this.Controls.Add(this._lblCommon_4);
			this.Controls.Add(this._lblCommon_5);
			this.Controls.Add(this._lblCommon_44);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			//this.Icon = (System.Drawing.Icon) resources.GetObject("frmICSVoucherTypes.Icon");
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(135, 98);
			this.MaximizeBox = true;
			this.MinimizeBox = true;
			this.Name = "frmICSVoucherTypes";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "ICS Voucher Types";
			// this.Activated += new System.EventHandler(this.frmICSVoucherTypes_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
			// this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
			//((System.ComponentModel.ISupportInitialize) this.tabVoucherDetails).EndInit();
			this._fraCommon_23.ResumeLayout(false);
			this.grdVoucherParentDetails.ResumeLayout(false);
			this.cmbParentsList.ResumeLayout(false);
			this.tabVoucherDetails.ResumeLayout(false);
			this._fraCommon_1.ResumeLayout(false);
			this._fraCommon_22.ResumeLayout(false);
			this._fraCommon_21.ResumeLayout(false);
			this._fraCommon_18.ResumeLayout(false);
			this._fraCommon_10.ResumeLayout(false);
			this._fraCommon_3.ResumeLayout(false);
			this._fraCommon_9.ResumeLayout(false);
			this._fraCommon_20.ResumeLayout(false);
			this._fraCommon_8.ResumeLayout(false);
			this._fraCommon_17.ResumeLayout(false);
			this._fraCommon_7.ResumeLayout(false);
			this._fraCommon_15.ResumeLayout(false);
			this.cmbPrintList.ResumeLayout(false);
			this.grdPrintTask.ResumeLayout(false);
			this._fraCommon_6.ResumeLayout(false);
			this._fraCommon_19.ResumeLayout(false);
			this._fraCommon_25.ResumeLayout(false);
			this._fraCommon_16.ResumeLayout(false);
			this._fraCommon_14.ResumeLayout(false);
			this._fraCommon_5.ResumeLayout(false);
			this._fraCommon_11.ResumeLayout(false);
			this._fraCommon_12.ResumeLayout(false);
			this._fraCommon_13.ResumeLayout(false);
			this._fraCommon_0.ResumeLayout(false);
			this._fraCommon_24.ResumeLayout(false);
			this._fraCommon_2.ResumeLayout(false);
			this._fraCommon_4.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		void ReLoadForm(bool addEvents)
		{
			InitializetxtCommonLabel();
			InitializetxtCommon();
			InitializeoptCommonQtyEffect();
			InitializeoptCommonAffectType();
			InitializelblCommon();
			InitializefraCommon();
			InitializecmbCommon();
			InitializechkCommon();
			//This form is an MDI child.
			//This code simulates the VB6 
			// functionality of automatically
			// loading and showing an MDI
			// child's parent.
			this.MdiParent = Xtreme.frmSysMain.DefInstance;
			Xtreme.frmSysMain.DefInstance.Show();
			Form_Initialize();
		}
		void InitializetxtCommonLabel()
		{
			this.txtCommonLabel = new System.Windows.Forms.Label[30];
			this.txtCommonLabel[11] = _txtCommonLabel_11;
			this.txtCommonLabel[12] = _txtCommonLabel_12;
			this.txtCommonLabel[29] = _txtCommonLabel_29;
			this.txtCommonLabel[0] = _txtCommonLabel_0;
			this.txtCommonLabel[6] = _txtCommonLabel_6;
			this.txtCommonLabel[17] = _txtCommonLabel_17;
			this.txtCommonLabel[19] = _txtCommonLabel_19;
			this.txtCommonLabel[20] = _txtCommonLabel_20;
			this.txtCommonLabel[22] = _txtCommonLabel_22;
			this.txtCommonLabel[4] = _txtCommonLabel_4;
			this.txtCommonLabel[14] = _txtCommonLabel_14;
			this.txtCommonLabel[15] = _txtCommonLabel_15;
			this.txtCommonLabel[16] = _txtCommonLabel_16;
			this.txtCommonLabel[13] = _txtCommonLabel_13;
			this.txtCommonLabel[1] = _txtCommonLabel_1;
			this.txtCommonLabel[3] = _txtCommonLabel_3;
			this.txtCommonLabel[2] = _txtCommonLabel_2;
			this.txtCommonLabel[21] = _txtCommonLabel_21;
		}
		void InitializetxtCommon()
		{
			this.txtCommon = new System.Windows.Forms.TextBox[41];
			this.txtCommon[32] = _txtCommon_32;
			this.txtCommon[31] = _txtCommon_31;
			this.txtCommon[28] = _txtCommon_28;
			this.txtCommon[29] = _txtCommon_29;
			this.txtCommon[30] = _txtCommon_30;
			this.txtCommon[33] = _txtCommon_33;
			this.txtCommon[17] = _txtCommon_17;
			this.txtCommon[15] = _txtCommon_15;
			this.txtCommon[16] = _txtCommon_16;
			this.txtCommon[23] = _txtCommon_23;
			this.txtCommon[24] = _txtCommon_24;
			this.txtCommon[25] = _txtCommon_25;
			this.txtCommon[26] = _txtCommon_26;
			this.txtCommon[27] = _txtCommon_27;
			this.txtCommon[34] = _txtCommon_34;
			this.txtCommon[35] = _txtCommon_35;
			this.txtCommon[11] = _txtCommon_11;
			this.txtCommon[14] = _txtCommon_14;
			this.txtCommon[36] = _txtCommon_36;
			this.txtCommon[37] = _txtCommon_37;
			this.txtCommon[19] = _txtCommon_19;
			this.txtCommon[38] = _txtCommon_38;
			this.txtCommon[40] = _txtCommon_40;
			this.txtCommon[12] = _txtCommon_12;
			this.txtCommon[10] = _txtCommon_10;
			this.txtCommon[13] = _txtCommon_13;
			this.txtCommon[18] = _txtCommon_18;
			this.txtCommon[20] = _txtCommon_20;
			this.txtCommon[21] = _txtCommon_21;
			this.txtCommon[22] = _txtCommon_22;
			this.txtCommon[39] = _txtCommon_39;
			this.txtCommon[7] = _txtCommon_7;
			this.txtCommon[8] = _txtCommon_8;
			this.txtCommon[6] = _txtCommon_6;
			this.txtCommon[9] = _txtCommon_9;
			this.txtCommon[1] = _txtCommon_1;
			this.txtCommon[2] = _txtCommon_2;
			this.txtCommon[0] = _txtCommon_0;
			this.txtCommon[3] = _txtCommon_3;
			this.txtCommon[4] = _txtCommon_4;
			this.txtCommon[5] = _txtCommon_5;
		}
		void InitializeoptCommonQtyEffect()
		{
			this.optCommonQtyEffect = new System.Windows.Forms.RadioButton[4];
			this.optCommonQtyEffect[3] = _optCommonQtyEffect_3;
			this.optCommonQtyEffect[2] = _optCommonQtyEffect_2;
			this.optCommonQtyEffect[1] = _optCommonQtyEffect_1;
			this.optCommonQtyEffect[0] = _optCommonQtyEffect_0;
		}
		void InitializeoptCommonAffectType()
		{
			this.optCommonAffectType = new System.Windows.Forms.RadioButton[12];
			this.optCommonAffectType[11] = _optCommonAffectType_11;
			this.optCommonAffectType[10] = _optCommonAffectType_10;
			this.optCommonAffectType[9] = _optCommonAffectType_9;
			this.optCommonAffectType[8] = _optCommonAffectType_8;
			this.optCommonAffectType[7] = _optCommonAffectType_7;
			this.optCommonAffectType[2] = _optCommonAffectType_2;
			this.optCommonAffectType[3] = _optCommonAffectType_3;
			this.optCommonAffectType[4] = _optCommonAffectType_4;
			this.optCommonAffectType[5] = _optCommonAffectType_5;
			this.optCommonAffectType[6] = _optCommonAffectType_6;
			this.optCommonAffectType[1] = _optCommonAffectType_1;
			this.optCommonAffectType[0] = _optCommonAffectType_0;
		}
		void InitializelblCommon()
		{
			this.lblCommon = new System.Windows.Forms.Label[49];
			this.lblCommon[18] = _lblCommon_18;
			this.lblCommon[19] = _lblCommon_19;
			this.lblCommon[20] = _lblCommon_20;
			this.lblCommon[21] = _lblCommon_21;
			this.lblCommon[22] = _lblCommon_22;
			this.lblCommon[23] = _lblCommon_23;
			this.lblCommon[43] = _lblCommon_43;
			this.lblCommon[34] = _lblCommon_34;
			this.lblCommon[40] = _lblCommon_40;
			this.lblCommon[33] = _lblCommon_33;
			this.lblCommon[38] = _lblCommon_38;
			this.lblCommon[39] = _lblCommon_39;
			this.lblCommon[41] = _lblCommon_41;
			this.lblCommon[42] = _lblCommon_42;
			this.lblCommon[37] = _lblCommon_37;
			this.lblCommon[0] = _lblCommon_0;
			this.lblCommon[13] = _lblCommon_13;
			this.lblCommon[16] = _lblCommon_16;
			this.lblCommon[31] = _lblCommon_31;
			this.lblCommon[45] = _lblCommon_45;
			this.lblCommon[28] = _lblCommon_28;
			this.lblCommon[29] = _lblCommon_29;
			this.lblCommon[30] = _lblCommon_30;
			this.lblCommon[36] = _lblCommon_36;
			this.lblCommon[35] = _lblCommon_35;
			this.lblCommon[32] = _lblCommon_32;
			this.lblCommon[46] = _lblCommon_46;
			this.lblCommon[48] = _lblCommon_48;
			this.lblCommon[12] = _lblCommon_12;
			this.lblCommon[14] = _lblCommon_14;
			this.lblCommon[15] = _lblCommon_15;
			this.lblCommon[24] = _lblCommon_24;
			this.lblCommon[25] = _lblCommon_25;
			this.lblCommon[26] = _lblCommon_26;
			this.lblCommon[27] = _lblCommon_27;
			this.lblCommon[47] = _lblCommon_47;
			this.lblCommon[8] = _lblCommon_8;
			this.lblCommon[9] = _lblCommon_9;
			this.lblCommon[10] = _lblCommon_10;
			this.lblCommon[11] = _lblCommon_11;
			this.lblCommon[17] = _lblCommon_17;
			this.lblCommon[1] = _lblCommon_1;
			this.lblCommon[6] = _lblCommon_6;
			this.lblCommon[7] = _lblCommon_7;
			this.lblCommon[2] = _lblCommon_2;
			this.lblCommon[4] = _lblCommon_4;
			this.lblCommon[5] = _lblCommon_5;
			this.lblCommon[44] = _lblCommon_44;
		}
		void InitializefraCommon()
		{
			this.fraCommon = new System.Windows.Forms.GroupBox[26];
			this.fraCommon[23] = _fraCommon_23;
			this.fraCommon[22] = _fraCommon_22;
			this.fraCommon[21] = _fraCommon_21;
			this.fraCommon[18] = _fraCommon_18;
			this.fraCommon[1] = _fraCommon_1;
			this.fraCommon[3] = _fraCommon_3;
			this.fraCommon[10] = _fraCommon_10;
			this.fraCommon[20] = _fraCommon_20;
			this.fraCommon[9] = _fraCommon_9;
			this.fraCommon[17] = _fraCommon_17;
			this.fraCommon[8] = _fraCommon_8;
			this.fraCommon[15] = _fraCommon_15;
			this.fraCommon[7] = _fraCommon_7;
			this.fraCommon[19] = _fraCommon_19;
			this.fraCommon[25] = _fraCommon_25;
			this.fraCommon[16] = _fraCommon_16;
			this.fraCommon[14] = _fraCommon_14;
			this.fraCommon[6] = _fraCommon_6;
			this.fraCommon[11] = _fraCommon_11;
			this.fraCommon[12] = _fraCommon_12;
			this.fraCommon[13] = _fraCommon_13;
			this.fraCommon[5] = _fraCommon_5;
			this.fraCommon[24] = _fraCommon_24;
			this.fraCommon[2] = _fraCommon_2;
			this.fraCommon[4] = _fraCommon_4;
			this.fraCommon[0] = _fraCommon_0;
		}
		void InitializecmbCommon()
		{
			this.cmbCommon = new System.Windows.Forms.ComboBox[3];
			this.cmbCommon[2] = _cmbCommon_2;
			this.cmbCommon[1] = _cmbCommon_1;
			this.cmbCommon[0] = _cmbCommon_0;
		}
		void InitializechkCommon()
		{
			this.chkCommon = new System.Windows.Forms.CheckBox[138];
			this.chkCommon[75] = _chkCommon_75;
			this.chkCommon[121] = _chkCommon_121;
			this.chkCommon[135] = _chkCommon_135;
			this.chkCommon[134] = _chkCommon_134;
			this.chkCommon[117] = _chkCommon_117;
			this.chkCommon[118] = _chkCommon_118;
			this.chkCommon[119] = _chkCommon_119;
			this.chkCommon[116] = _chkCommon_116;
			this.chkCommon[120] = _chkCommon_120;
			this.chkCommon[77] = _chkCommon_77;
			this.chkCommon[82] = _chkCommon_82;
			this.chkCommon[80] = _chkCommon_80;
			this.chkCommon[78] = _chkCommon_78;
			this.chkCommon[81] = _chkCommon_81;
			this.chkCommon[79] = _chkCommon_79;
			this.chkCommon[76] = _chkCommon_76;
			this.chkCommon[74] = _chkCommon_74;
			this.chkCommon[92] = _chkCommon_92;
			this.chkCommon[73] = _chkCommon_73;
			this.chkCommon[108] = _chkCommon_108;
			this.chkCommon[137] = _chkCommon_137;
			this.chkCommon[130] = _chkCommon_130;
			this.chkCommon[129] = _chkCommon_129;
			this.chkCommon[128] = _chkCommon_128;
			this.chkCommon[125] = _chkCommon_125;
			this.chkCommon[35] = _chkCommon_35;
			this.chkCommon[110] = _chkCommon_110;
			this.chkCommon[109] = _chkCommon_109;
			this.chkCommon[107] = _chkCommon_107;
			this.chkCommon[106] = _chkCommon_106;
			this.chkCommon[105] = _chkCommon_105;
			this.chkCommon[104] = _chkCommon_104;
			this.chkCommon[101] = _chkCommon_101;
			this.chkCommon[100] = _chkCommon_100;
			this.chkCommon[99] = _chkCommon_99;
			this.chkCommon[98] = _chkCommon_98;
			this.chkCommon[96] = _chkCommon_96;
			this.chkCommon[91] = _chkCommon_91;
			this.chkCommon[90] = _chkCommon_90;
			this.chkCommon[89] = _chkCommon_89;
			this.chkCommon[88] = _chkCommon_88;
			this.chkCommon[87] = _chkCommon_87;
			this.chkCommon[86] = _chkCommon_86;
			this.chkCommon[84] = _chkCommon_84;
			this.chkCommon[66] = _chkCommon_66;
			this.chkCommon[65] = _chkCommon_65;
			this.chkCommon[64] = _chkCommon_64;
			this.chkCommon[63] = _chkCommon_63;
			this.chkCommon[62] = _chkCommon_62;
			this.chkCommon[61] = _chkCommon_61;
			this.chkCommon[94] = _chkCommon_94;
			this.chkCommon[95] = _chkCommon_95;
			this.chkCommon[97] = _chkCommon_97;
			this.chkCommon[127] = _chkCommon_127;
			this.chkCommon[60] = _chkCommon_60;
			this.chkCommon[59] = _chkCommon_59;
			this.chkCommon[58] = _chkCommon_58;
			this.chkCommon[57] = _chkCommon_57;
			this.chkCommon[56] = _chkCommon_56;
			this.chkCommon[55] = _chkCommon_55;
			this.chkCommon[54] = _chkCommon_54;
			this.chkCommon[53] = _chkCommon_53;
			this.chkCommon[52] = _chkCommon_52;
			this.chkCommon[51] = _chkCommon_51;
			this.chkCommon[50] = _chkCommon_50;
			this.chkCommon[49] = _chkCommon_49;
			this.chkCommon[48] = _chkCommon_48;
			this.chkCommon[133] = _chkCommon_133;
			this.chkCommon[123] = _chkCommon_123;
			this.chkCommon[115] = _chkCommon_115;
			this.chkCommon[71] = _chkCommon_71;
			this.chkCommon[114] = _chkCommon_114;
			this.chkCommon[111] = _chkCommon_111;
			this.chkCommon[8] = _chkCommon_8;
			this.chkCommon[22] = _chkCommon_22;
			this.chkCommon[23] = _chkCommon_23;
			this.chkCommon[26] = _chkCommon_26;
			this.chkCommon[27] = _chkCommon_27;
			this.chkCommon[28] = _chkCommon_28;
			this.chkCommon[30] = _chkCommon_30;
			this.chkCommon[31] = _chkCommon_31;
			this.chkCommon[32] = _chkCommon_32;
			this.chkCommon[40] = _chkCommon_40;
			this.chkCommon[67] = _chkCommon_67;
			this.chkCommon[70] = _chkCommon_70;
			this.chkCommon[136] = _chkCommon_136;
			this.chkCommon[72] = _chkCommon_72;
			this.chkCommon[12] = _chkCommon_12;
			this.chkCommon[11] = _chkCommon_11;
			this.chkCommon[10] = _chkCommon_10;
			this.chkCommon[39] = _chkCommon_39;
			this.chkCommon[38] = _chkCommon_38;
			this.chkCommon[37] = _chkCommon_37;
			this.chkCommon[34] = _chkCommon_34;
			this.chkCommon[33] = _chkCommon_33;
			this.chkCommon[29] = _chkCommon_29;
			this.chkCommon[25] = _chkCommon_25;
			this.chkCommon[24] = _chkCommon_24;
			this.chkCommon[15] = _chkCommon_15;
			this.chkCommon[9] = _chkCommon_9;
			this.chkCommon[36] = _chkCommon_36;
			this.chkCommon[85] = _chkCommon_85;
			this.chkCommon[83] = _chkCommon_83;
			this.chkCommon[132] = _chkCommon_132;
			this.chkCommon[126] = _chkCommon_126;
			this.chkCommon[103] = _chkCommon_103;
			this.chkCommon[20] = _chkCommon_20;
			this.chkCommon[113] = _chkCommon_113;
			this.chkCommon[112] = _chkCommon_112;
			this.chkCommon[13] = _chkCommon_13;
			this.chkCommon[14] = _chkCommon_14;
			this.chkCommon[16] = _chkCommon_16;
			this.chkCommon[19] = _chkCommon_19;
			this.chkCommon[21] = _chkCommon_21;
			this.chkCommon[68] = _chkCommon_68;
			this.chkCommon[69] = _chkCommon_69;
			this.chkCommon[18] = _chkCommon_18;
			this.chkCommon[17] = _chkCommon_17;
			this.chkCommon[41] = _chkCommon_41;
			this.chkCommon[42] = _chkCommon_42;
			this.chkCommon[43] = _chkCommon_43;
			this.chkCommon[44] = _chkCommon_44;
			this.chkCommon[45] = _chkCommon_45;
			this.chkCommon[46] = _chkCommon_46;
			this.chkCommon[47] = _chkCommon_47;
			this.chkCommon[102] = _chkCommon_102;
			this.chkCommon[124] = _chkCommon_124;
			this.chkCommon[7] = _chkCommon_7;
			this.chkCommon[6] = _chkCommon_6;
			this.chkCommon[131] = _chkCommon_131;
			this.chkCommon[122] = _chkCommon_122;
			this.chkCommon[93] = _chkCommon_93;
			this.chkCommon[0] = _chkCommon_0;
			this.chkCommon[1] = _chkCommon_1;
			this.chkCommon[2] = _chkCommon_2;
			this.chkCommon[3] = _chkCommon_3;
			this.chkCommon[5] = _chkCommon_5;
			this.chkCommon[4] = _chkCommon_4;
		}
		#endregion
	}
}