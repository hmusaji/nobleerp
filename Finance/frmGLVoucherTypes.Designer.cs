
namespace Xtreme
{
	partial class frmGLVoucherTypes
	{

		#region "Upgrade Support "
		private static frmGLVoucherTypes m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmGLVoucherTypes DefInstance
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
		public static frmGLVoucherTypes CreateInstance()
		{
			frmGLVoucherTypes theInstance = new frmGLVoucherTypes();
			
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
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "_optCommonAffectType_1", "_optCommonAffectType_2", "_lblCommon_2", "_txtControl_15", "_txtControl_19", "Frame8", "_optCommonQtyEffect_2", "_optCommonQtyEffect_3", "_txtCommon_12", "_lblCommon_12", "_lblCommon_13", "_lblCommon_14", "_txtControl_22", "_txtControl_2", "_txtControl_4", "_txtControl_5", "_lblCommon_0", "_lblCommon_1", "_txtControl_10", "_txtControl_11", "_txtControl_12", "_txtControl_13", "Column_0_cmbPrintList", "Column_1_cmbPrintList", "cmbPrintList", "Column_0_grdPrintTask", "Column_1_grdPrintTask", "grdPrintTask", "Frame7", "Frame6", "_txtMultiLineControl_11", "_txtMultiLineControl_10", "_lblControl_8", "_lblControl_9", "_txtControl_51", "_lblControl_14", "Frame5", "_chkControl_13", "_chkControl_11", "_chkControl_10", "_chkControl_9", "_chkControl_8", "_chkControl_0", "_chkControl_18", "_chkControl_1", "_chkControl_7", "_chkControl_2", "_chkControl_3", "_chkControl_5", "_chkControl_6", "_chkControl_28", "_chkControl_19", "_chkControl_21", "_chkControl_22", "_chkControl_23", "_chkControl_24", "_chkControl_25", "_chkControl_26", "_chkControl_27", "_chkControl_29", "_chkControl_30", "_chkControl_31", "_chkControl_32", "_chkControl_34", "_chkControl_35", "_chkControl_37", "_chkControl_39", "_chkControl_40", "_chkControl_41", "_chkControl_38", "Frame3", "txtNumber", "_chkControl_12", "_chkControl_15", "_lblControl_1", "_lblControl_10", "_lblControl_11", "_lblControl_12", "_lblControl_13", "_txtControl_58", "_cmbControl_13", "_txtControl_16", "_txtControl_17", "_txtControl_14", "_txtControl_18", "Frame4", "_chkControl_36", "_chkControl_33", "_chkControl_4", "_lblControl_15", "_cmbControl_20", "_lblControl_2", "_cmbControl_0", "_lblControl_22", "Frame2", "_chkControl_46", "_chkControl_47", "_chkControl_48", "_lblControl_0", "_txtControl_1", "_txtControl_7", "_txtControl_8", "_txtControl_9", "_lblControl_3", "_lblControl_4", "_lblControl_5", "_lblControl_6", "_lblControl_7", "_lblControl_16", "_lblControl_17", "_lblControl_18", "_lblControl_19", "_lblControl_20", "_txtControl_45", "_txtControl_42", "_txtControl_43", "_txtControl_44", "_txtControl_49", "_txtControl_52", "_txtControl_53", "_txtControl_54", "_txtControl_55", "_txtControl_56", "_txtControl_3", "_txtControl_6", "_lblControl_21", "_txtControl_21", "_txtControl_23", "Frame1", "tabGLVoucherType", "chkControl", "cmbControl", "lblCommon", "lblControl", "optCommonAffectType", "optCommonQtyEffect", "txtCommon", "txtControl", "txtMultiLineControl"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		private System.Windows.Forms.RadioButton _optCommonAffectType_1;
		private System.Windows.Forms.RadioButton _optCommonAffectType_2;
		private System.Windows.Forms.Label _lblCommon_2;
		private System.Windows.Forms.TextBox _txtControl_15;
		private System.Windows.Forms.TextBox _txtControl_19;
		public System.Windows.Forms.GroupBox Frame8;
		private System.Windows.Forms.RadioButton _optCommonQtyEffect_2;
		private System.Windows.Forms.RadioButton _optCommonQtyEffect_3;
		private System.Windows.Forms.TextBox _txtCommon_12;
		private System.Windows.Forms.Label _lblCommon_12;
		private System.Windows.Forms.Label _lblCommon_13;
		private System.Windows.Forms.Label _lblCommon_14;
		private System.Windows.Forms.TextBox _txtControl_22;
		private System.Windows.Forms.TextBox _txtControl_2;
		private System.Windows.Forms.TextBox _txtControl_4;
		private System.Windows.Forms.TextBox _txtControl_5;
		private System.Windows.Forms.Label _lblCommon_0;
		private System.Windows.Forms.Label _lblCommon_1;
		private System.Windows.Forms.TextBox _txtControl_10;
		private System.Windows.Forms.TextBox _txtControl_11;
		private System.Windows.Forms.TextBox _txtControl_12;
		private System.Windows.Forms.TextBox _txtControl_13;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_0_cmbPrintList;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_1_cmbPrintList;
		public C1.Win.C1TrueDBGrid.C1TrueDBDropdown cmbPrintList;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_0_grdPrintTask;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_1_grdPrintTask;
		public C1.Win.C1TrueDBGrid.C1TrueDBGrid grdPrintTask;
		public System.Windows.Forms.GroupBox Frame7;
		public System.Windows.Forms.GroupBox Frame6;
		private System.Windows.Forms.TextBox _txtMultiLineControl_11;
		private System.Windows.Forms.TextBox _txtMultiLineControl_10;
		private System.Windows.Forms.Label _lblControl_8;
		private System.Windows.Forms.Label _lblControl_9;
		private System.Windows.Forms.TextBox _txtControl_51;
		private System.Windows.Forms.Label _lblControl_14;
		public System.Windows.Forms.GroupBox Frame5;
		private System.Windows.Forms.CheckBox _chkControl_13;
		private System.Windows.Forms.CheckBox _chkControl_11;
		private System.Windows.Forms.CheckBox _chkControl_10;
		private System.Windows.Forms.CheckBox _chkControl_9;
		private System.Windows.Forms.CheckBox _chkControl_8;
		private System.Windows.Forms.CheckBox _chkControl_0;
		private System.Windows.Forms.CheckBox _chkControl_18;
		private System.Windows.Forms.CheckBox _chkControl_1;
		private System.Windows.Forms.CheckBox _chkControl_7;
		private System.Windows.Forms.CheckBox _chkControl_2;
		private System.Windows.Forms.CheckBox _chkControl_3;
		private System.Windows.Forms.CheckBox _chkControl_5;
		private System.Windows.Forms.CheckBox _chkControl_6;
		private System.Windows.Forms.CheckBox _chkControl_28;
		private System.Windows.Forms.CheckBox _chkControl_19;
		private System.Windows.Forms.CheckBox _chkControl_21;
		private System.Windows.Forms.CheckBox _chkControl_22;
		private System.Windows.Forms.CheckBox _chkControl_23;
		private System.Windows.Forms.CheckBox _chkControl_24;
		private System.Windows.Forms.CheckBox _chkControl_25;
		private System.Windows.Forms.CheckBox _chkControl_26;
		private System.Windows.Forms.CheckBox _chkControl_27;
		private System.Windows.Forms.CheckBox _chkControl_29;
		private System.Windows.Forms.CheckBox _chkControl_30;
		private System.Windows.Forms.CheckBox _chkControl_31;
		private System.Windows.Forms.CheckBox _chkControl_32;
		private System.Windows.Forms.CheckBox _chkControl_34;
		private System.Windows.Forms.CheckBox _chkControl_35;
		private System.Windows.Forms.CheckBox _chkControl_37;
		private System.Windows.Forms.CheckBox _chkControl_39;
		private System.Windows.Forms.CheckBox _chkControl_40;
		private System.Windows.Forms.CheckBox _chkControl_41;
		private System.Windows.Forms.CheckBox _chkControl_38;
		public System.Windows.Forms.GroupBox Frame3;
		public System.Windows.Forms.TextBox txtNumber;
		private System.Windows.Forms.CheckBox _chkControl_12;
		private System.Windows.Forms.CheckBox _chkControl_15;
		private System.Windows.Forms.Label _lblControl_1;
		private System.Windows.Forms.Label _lblControl_10;
		private System.Windows.Forms.Label _lblControl_11;
		private System.Windows.Forms.Label _lblControl_12;
		private System.Windows.Forms.Label _lblControl_13;
		private System.Windows.Forms.TextBox _txtControl_58;
		private System.Windows.Forms.ComboBox _cmbControl_13;
		private System.Windows.Forms.TextBox _txtControl_16;
		private System.Windows.Forms.TextBox _txtControl_17;
		private System.Windows.Forms.TextBox _txtControl_14;
		private System.Windows.Forms.TextBox _txtControl_18;
		public System.Windows.Forms.GroupBox Frame4;
		private System.Windows.Forms.CheckBox _chkControl_36;
		private System.Windows.Forms.CheckBox _chkControl_33;
		private System.Windows.Forms.CheckBox _chkControl_4;
		private System.Windows.Forms.Label _lblControl_15;
		private System.Windows.Forms.ComboBox _cmbControl_20;
		private System.Windows.Forms.Label _lblControl_2;
		private System.Windows.Forms.ComboBox _cmbControl_0;
		private System.Windows.Forms.Label _lblControl_22;
		public System.Windows.Forms.GroupBox Frame2;
		private System.Windows.Forms.CheckBox _chkControl_46;
		private System.Windows.Forms.CheckBox _chkControl_47;
		private System.Windows.Forms.CheckBox _chkControl_48;
		private System.Windows.Forms.Label _lblControl_0;
		private System.Windows.Forms.TextBox _txtControl_1;
		private System.Windows.Forms.TextBox _txtControl_7;
		private System.Windows.Forms.TextBox _txtControl_8;
		private System.Windows.Forms.TextBox _txtControl_9;
		private System.Windows.Forms.Label _lblControl_3;
		private System.Windows.Forms.Label _lblControl_4;
		private System.Windows.Forms.Label _lblControl_5;
		private System.Windows.Forms.Label _lblControl_6;
		private System.Windows.Forms.Label _lblControl_7;
		private System.Windows.Forms.Label _lblControl_16;
		private System.Windows.Forms.Label _lblControl_17;
		private System.Windows.Forms.Label _lblControl_18;
		private System.Windows.Forms.Label _lblControl_19;
		private System.Windows.Forms.Label _lblControl_20;
		private System.Windows.Forms.TextBox _txtControl_45;
		private System.Windows.Forms.TextBox _txtControl_42;
		private System.Windows.Forms.TextBox _txtControl_43;
		private System.Windows.Forms.TextBox _txtControl_44;
		private System.Windows.Forms.TextBox _txtControl_49;
		private System.Windows.Forms.TextBox _txtControl_52;
		private System.Windows.Forms.TextBox _txtControl_53;
		private System.Windows.Forms.TextBox _txtControl_54;
		private System.Windows.Forms.TextBox _txtControl_55;
		private System.Windows.Forms.TextBox _txtControl_56;
		private System.Windows.Forms.TextBox _txtControl_3;
		private System.Windows.Forms.TextBox _txtControl_6;
		private System.Windows.Forms.Label _lblControl_21;
		private System.Windows.Forms.TextBox _txtControl_21;
		private System.Windows.Forms.TextBox _txtControl_23;
		public System.Windows.Forms.GroupBox Frame1;
		public AxC1SizerLib.AxC1Tab tabGLVoucherType;
		public System.Windows.Forms.CheckBox[] chkControl = new System.Windows.Forms.CheckBox[49];
		public System.Windows.Forms.ComboBox[] cmbControl = new System.Windows.Forms.ComboBox[21];
		public System.Windows.Forms.Label[] lblCommon = new System.Windows.Forms.Label[15];
		public System.Windows.Forms.Label[] lblControl = new System.Windows.Forms.Label[23];
		public System.Windows.Forms.RadioButton[] optCommonAffectType = new System.Windows.Forms.RadioButton[3];
		public System.Windows.Forms.RadioButton[] optCommonQtyEffect = new System.Windows.Forms.RadioButton[4];
		public System.Windows.Forms.TextBox[] txtCommon = new System.Windows.Forms.TextBox[13];
		public System.Windows.Forms.TextBox[] txtControl = new System.Windows.Forms.TextBox[59];
		public System.Windows.Forms.TextBox[] txtMultiLineControl = new System.Windows.Forms.TextBox[12];
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGLVoucherTypes));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this.tabGLVoucherType = new AxC1SizerLib.AxC1Tab();
			this.Frame6 = new System.Windows.Forms.GroupBox();
			this.Frame8 = new System.Windows.Forms.GroupBox();
			this._optCommonAffectType_1 = new System.Windows.Forms.RadioButton();
			this._optCommonAffectType_2 = new System.Windows.Forms.RadioButton();
			this._lblCommon_2 = new System.Windows.Forms.Label();
			this._txtControl_15 = new System.Windows.Forms.TextBox();
			this._txtControl_19 = new System.Windows.Forms.TextBox();
			this.Frame7 = new System.Windows.Forms.GroupBox();
			this._optCommonQtyEffect_2 = new System.Windows.Forms.RadioButton();
			this._optCommonQtyEffect_3 = new System.Windows.Forms.RadioButton();
			this._txtCommon_12 = new System.Windows.Forms.TextBox();
			this._lblCommon_12 = new System.Windows.Forms.Label();
			this._lblCommon_13 = new System.Windows.Forms.Label();
			this._lblCommon_14 = new System.Windows.Forms.Label();
			this._txtControl_22 = new System.Windows.Forms.TextBox();
			this._txtControl_2 = new System.Windows.Forms.TextBox();
			this._txtControl_4 = new System.Windows.Forms.TextBox();
			this._txtControl_5 = new System.Windows.Forms.TextBox();
			this._lblCommon_0 = new System.Windows.Forms.Label();
			this._lblCommon_1 = new System.Windows.Forms.Label();
			this._txtControl_10 = new System.Windows.Forms.TextBox();
			this._txtControl_11 = new System.Windows.Forms.TextBox();
			this._txtControl_12 = new System.Windows.Forms.TextBox();
			this._txtControl_13 = new System.Windows.Forms.TextBox();
			this.cmbPrintList = new C1.Win.C1TrueDBGrid.C1TrueDBDropdown();
			this.Column_0_cmbPrintList = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.Column_1_cmbPrintList = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.grdPrintTask = new C1.Win.C1TrueDBGrid.C1TrueDBGrid();
			this.Column_0_grdPrintTask = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.Column_1_grdPrintTask = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.Frame5 = new System.Windows.Forms.GroupBox();
			this._txtMultiLineControl_11 = new System.Windows.Forms.TextBox();
			this._txtMultiLineControl_10 = new System.Windows.Forms.TextBox();
			this._lblControl_8 = new System.Windows.Forms.Label();
			this._lblControl_9 = new System.Windows.Forms.Label();
			this._txtControl_51 = new System.Windows.Forms.TextBox();
			this._lblControl_14 = new System.Windows.Forms.Label();
			this.Frame3 = new System.Windows.Forms.GroupBox();
			this._chkControl_13 = new System.Windows.Forms.CheckBox();
			this._chkControl_11 = new System.Windows.Forms.CheckBox();
			this._chkControl_10 = new System.Windows.Forms.CheckBox();
			this._chkControl_9 = new System.Windows.Forms.CheckBox();
			this._chkControl_8 = new System.Windows.Forms.CheckBox();
			this._chkControl_0 = new System.Windows.Forms.CheckBox();
			this._chkControl_18 = new System.Windows.Forms.CheckBox();
			this._chkControl_1 = new System.Windows.Forms.CheckBox();
			this._chkControl_7 = new System.Windows.Forms.CheckBox();
			this._chkControl_2 = new System.Windows.Forms.CheckBox();
			this._chkControl_3 = new System.Windows.Forms.CheckBox();
			this._chkControl_5 = new System.Windows.Forms.CheckBox();
			this._chkControl_6 = new System.Windows.Forms.CheckBox();
			this._chkControl_28 = new System.Windows.Forms.CheckBox();
			this._chkControl_19 = new System.Windows.Forms.CheckBox();
			this._chkControl_21 = new System.Windows.Forms.CheckBox();
			this._chkControl_22 = new System.Windows.Forms.CheckBox();
			this._chkControl_23 = new System.Windows.Forms.CheckBox();
			this._chkControl_24 = new System.Windows.Forms.CheckBox();
			this._chkControl_25 = new System.Windows.Forms.CheckBox();
			this._chkControl_26 = new System.Windows.Forms.CheckBox();
			this._chkControl_27 = new System.Windows.Forms.CheckBox();
			this._chkControl_29 = new System.Windows.Forms.CheckBox();
			this._chkControl_30 = new System.Windows.Forms.CheckBox();
			this._chkControl_31 = new System.Windows.Forms.CheckBox();
			this._chkControl_32 = new System.Windows.Forms.CheckBox();
			this._chkControl_34 = new System.Windows.Forms.CheckBox();
			this._chkControl_35 = new System.Windows.Forms.CheckBox();
			this._chkControl_37 = new System.Windows.Forms.CheckBox();
			this._chkControl_39 = new System.Windows.Forms.CheckBox();
			this._chkControl_40 = new System.Windows.Forms.CheckBox();
			this._chkControl_41 = new System.Windows.Forms.CheckBox();
			this._chkControl_38 = new System.Windows.Forms.CheckBox();
			this.Frame2 = new System.Windows.Forms.GroupBox();
			this.txtNumber = new System.Windows.Forms.TextBox();
			this._chkControl_12 = new System.Windows.Forms.CheckBox();
			this.Frame4 = new System.Windows.Forms.GroupBox();
			this._chkControl_15 = new System.Windows.Forms.CheckBox();
			this._lblControl_1 = new System.Windows.Forms.Label();
			this._lblControl_10 = new System.Windows.Forms.Label();
			this._lblControl_11 = new System.Windows.Forms.Label();
			this._lblControl_12 = new System.Windows.Forms.Label();
			this._lblControl_13 = new System.Windows.Forms.Label();
			this._txtControl_58 = new System.Windows.Forms.TextBox();
			this._cmbControl_13 = new System.Windows.Forms.ComboBox();
			this._txtControl_16 = new System.Windows.Forms.TextBox();
			this._txtControl_17 = new System.Windows.Forms.TextBox();
			this._txtControl_14 = new System.Windows.Forms.TextBox();
			this._txtControl_18 = new System.Windows.Forms.TextBox();
			this._chkControl_36 = new System.Windows.Forms.CheckBox();
			this._chkControl_33 = new System.Windows.Forms.CheckBox();
			this._chkControl_4 = new System.Windows.Forms.CheckBox();
			this._lblControl_15 = new System.Windows.Forms.Label();
			this._cmbControl_20 = new System.Windows.Forms.ComboBox();
			this._lblControl_2 = new System.Windows.Forms.Label();
			this._cmbControl_0 = new System.Windows.Forms.ComboBox();
			this._lblControl_22 = new System.Windows.Forms.Label();
			this.Frame1 = new System.Windows.Forms.GroupBox();
			this._chkControl_46 = new System.Windows.Forms.CheckBox();
			this._chkControl_47 = new System.Windows.Forms.CheckBox();
			this._chkControl_48 = new System.Windows.Forms.CheckBox();
			this._lblControl_0 = new System.Windows.Forms.Label();
			this._txtControl_1 = new System.Windows.Forms.TextBox();
			this._txtControl_7 = new System.Windows.Forms.TextBox();
			this._txtControl_8 = new System.Windows.Forms.TextBox();
			this._txtControl_9 = new System.Windows.Forms.TextBox();
			this._lblControl_3 = new System.Windows.Forms.Label();
			this._lblControl_4 = new System.Windows.Forms.Label();
			this._lblControl_5 = new System.Windows.Forms.Label();
			this._lblControl_6 = new System.Windows.Forms.Label();
			this._lblControl_7 = new System.Windows.Forms.Label();
			this._lblControl_16 = new System.Windows.Forms.Label();
			this._lblControl_17 = new System.Windows.Forms.Label();
			this._lblControl_18 = new System.Windows.Forms.Label();
			this._lblControl_19 = new System.Windows.Forms.Label();
			this._lblControl_20 = new System.Windows.Forms.Label();
			this._txtControl_45 = new System.Windows.Forms.TextBox();
			this._txtControl_42 = new System.Windows.Forms.TextBox();
			this._txtControl_43 = new System.Windows.Forms.TextBox();
			this._txtControl_44 = new System.Windows.Forms.TextBox();
			this._txtControl_49 = new System.Windows.Forms.TextBox();
			this._txtControl_52 = new System.Windows.Forms.TextBox();
			this._txtControl_53 = new System.Windows.Forms.TextBox();
			this._txtControl_54 = new System.Windows.Forms.TextBox();
			this._txtControl_55 = new System.Windows.Forms.TextBox();
			this._txtControl_56 = new System.Windows.Forms.TextBox();
			this._txtControl_3 = new System.Windows.Forms.TextBox();
			this._txtControl_6 = new System.Windows.Forms.TextBox();
			this._lblControl_21 = new System.Windows.Forms.Label();
			this._txtControl_21 = new System.Windows.Forms.TextBox();
			this._txtControl_23 = new System.Windows.Forms.TextBox();
			// //((System.ComponentModel.ISupportInitialize) this.tabGLVoucherType).BeginInit();
			this.tabGLVoucherType.SuspendLayout();
			this.Frame6.SuspendLayout();
			this.Frame8.SuspendLayout();
			this.Frame7.SuspendLayout();
			this.cmbPrintList.SuspendLayout();
			this.grdPrintTask.SuspendLayout();
			this.Frame5.SuspendLayout();
			this.Frame3.SuspendLayout();
			this.Frame2.SuspendLayout();
			this.Frame4.SuspendLayout();
			this.Frame1.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabGLVoucherType
			// 
			this.tabGLVoucherType.Align = C1SizerLib.AlignSettings.asNone;
			this.tabGLVoucherType.AllowDrop = true;
			this.tabGLVoucherType.Controls.Add(this.Frame6);
			this.tabGLVoucherType.Controls.Add(this.Frame5);
			this.tabGLVoucherType.Controls.Add(this.Frame3);
			this.tabGLVoucherType.Controls.Add(this.Frame2);
			this.tabGLVoucherType.Controls.Add(this.Frame1);
			this.tabGLVoucherType.Location = new System.Drawing.Point(4, 10);
			this.tabGLVoucherType.Name = "tabGLVoucherType";
			("tabGLVoucherType.OcxState");
			this.tabGLVoucherType.Size = new System.Drawing.Size(461, 347);
			this.tabGLVoucherType.TabIndex = 64;
			// 
			// Frame6
			// 
			this.Frame6.AllowDrop = true;
			this.Frame6.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this.Frame6.Controls.Add(this.Frame8);
			this.Frame6.Controls.Add(this.Frame7);
			this.Frame6.Enabled = true;
			this.Frame6.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Frame6.Location = new System.Drawing.Point(564, 23);
			this.Frame6.Name = "Frame6";
			this.Frame6.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Frame6.Size = new System.Drawing.Size(455, 321);
			this.Frame6.TabIndex = 91;
			this.Frame6.Visible = true;
			// 
			// Frame8
			// 
			this.Frame8.AllowDrop = true;
			this.Frame8.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this.Frame8.Controls.Add(this._optCommonAffectType_1);
			this.Frame8.Controls.Add(this._optCommonAffectType_2);
			this.Frame8.Controls.Add(this._lblCommon_2);
			this.Frame8.Controls.Add(this._txtControl_15);
			this.Frame8.Controls.Add(this._txtControl_19);
			this.Frame8.Enabled = true;
			this.Frame8.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Frame8.Location = new System.Drawing.Point(6, 12);
			this.Frame8.Name = "Frame8";
			this.Frame8.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Frame8.Size = new System.Drawing.Size(439, 79);
			this.Frame8.TabIndex = 98;
			this.Frame8.Text = "Post Dated Cheque Details";
			this.Frame8.Visible = true;
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
			this._optCommonAffectType_1.Location = new System.Drawing.Point(16, 16);
			this._optCommonAffectType_1.Name = "_optCommonAffectType_1";
			this._optCommonAffectType_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._optCommonAffectType_1.Size = new System.Drawing.Size(174, 19);
			this._optCommonAffectType_1.TabIndex = 6;
			this._optCommonAffectType_1.TabStop = true;
			this._optCommonAffectType_1.Text = "PDC Payment Type";
			this._optCommonAffectType_1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._optCommonAffectType_1.Visible = true;
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
			this._optCommonAffectType_2.Location = new System.Drawing.Point(16, 34);
			this._optCommonAffectType_2.Name = "_optCommonAffectType_2";
			this._optCommonAffectType_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._optCommonAffectType_2.Size = new System.Drawing.Size(174, 19);
			this._optCommonAffectType_2.TabIndex = 7;
			this._optCommonAffectType_2.TabStop = true;
			this._optCommonAffectType_2.Text = "PDC RecieptType";
			this._optCommonAffectType_2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._optCommonAffectType_2.Visible = true;
			// 
			// _lblCommon_2
			// 
			this._lblCommon_2.AllowDrop = true;
			this._lblCommon_2.BackColor = System.Drawing.SystemColors.Window;
			this._lblCommon_2.Text = "PDC Generated Linked Voucher Type";
			this._lblCommon_2.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_2.Location = new System.Drawing.Point(16, 56);
			this._lblCommon_2.Name = "_lblCommon_2";
			this._lblCommon_2.Size = new System.Drawing.Size(180, 14);
			this._lblCommon_2.TabIndex = 99;
			// 
			// _txtControl_15
			// 
			this._txtControl_15.AllowDrop = true;
			this._txtControl_15.BackColor = System.Drawing.Color.FromArgb(239, 239, 239);
			this._txtControl_15.Enabled = false;
			this._txtControl_15.ForeColor = System.Drawing.Color.Black;
			this._txtControl_15.Location = new System.Drawing.Point(278, 54);
			this._txtControl_15.Name = "_txtControl_15";
			this._txtControl_15.Size = new System.Drawing.Size(123, 19);
			this._txtControl_15.TabIndex = 29;
			this._txtControl_15.Text = "";
			// this.this._txtControl_15.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtControl_DropButtonClick);
			// this._txtControl_15.Leave += new System.EventHandler(this.txtControl_Leave);
			// 
			// _txtControl_19
			// 
			this._txtControl_19.AllowDrop = true;
			this._txtControl_19.BackColor = System.Drawing.Color.White;
			// this._txtControl_19.bolAllowDecimal = false;
			// this._txtControl_19.bolNumericOnly = true;
			this._txtControl_19.ForeColor = System.Drawing.Color.Black;
			this._txtControl_19.Location = new System.Drawing.Point(202, 54);
			this._txtControl_19.MaxLength = 8;
			this._txtControl_19.Name = "_txtControl_19";
			// this._txtControl_19.ShowButton = true;
			this._txtControl_19.Size = new System.Drawing.Size(69, 19);
			this._txtControl_19.TabIndex = 8;
			this._txtControl_19.Text = "";
			// this.this._txtControl_19.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtControl_DropButtonClick);
			// this._txtControl_19.Leave += new System.EventHandler(this.txtControl_Leave);
			// 
			// Frame7
			// 
			this.Frame7.AllowDrop = true;
			this.Frame7.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this.Frame7.Controls.Add(this._optCommonQtyEffect_2);
			this.Frame7.Controls.Add(this._optCommonQtyEffect_3);
			this.Frame7.Controls.Add(this._txtCommon_12);
			this.Frame7.Controls.Add(this._lblCommon_12);
			this.Frame7.Controls.Add(this._lblCommon_13);
			this.Frame7.Controls.Add(this._lblCommon_14);
			this.Frame7.Controls.Add(this._txtControl_22);
			this.Frame7.Controls.Add(this._txtControl_2);
			this.Frame7.Controls.Add(this._txtControl_4);
			this.Frame7.Controls.Add(this._txtControl_5);
			this.Frame7.Controls.Add(this._lblCommon_0);
			this.Frame7.Controls.Add(this._lblCommon_1);
			this.Frame7.Controls.Add(this._txtControl_10);
			this.Frame7.Controls.Add(this._txtControl_11);
			this.Frame7.Controls.Add(this._txtControl_12);
			this.Frame7.Controls.Add(this._txtControl_13);
			this.Frame7.Controls.Add(this.cmbPrintList);
			this.Frame7.Controls.Add(this.grdPrintTask);
			this.Frame7.Enabled = true;
			this.Frame7.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Frame7.Location = new System.Drawing.Point(6, 94);
			this.Frame7.Name = "Frame7";
			this.Frame7.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Frame7.Size = new System.Drawing.Size(439, 221);
			this.Frame7.TabIndex = 92;
			this.Frame7.Text = "Reporting Details";
			this.Frame7.Visible = true;
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
			this._optCommonQtyEffect_2.Location = new System.Drawing.Point(6, 60);
			this._optCommonQtyEffect_2.Name = "_optCommonQtyEffect_2";
			this._optCommonQtyEffect_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._optCommonQtyEffect_2.Size = new System.Drawing.Size(123, 19);
			this._optCommonQtyEffect_2.TabIndex = 0;
			this._optCommonQtyEffect_2.TabStop = true;
			this._optCommonQtyEffect_2.Text = "Use Crystal Reports";
			this._optCommonQtyEffect_2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._optCommonQtyEffect_2.Visible = true;
			this._optCommonQtyEffect_2.CheckedChanged += new System.EventHandler(this.optCommonQtyEffect_CheckedChanged);
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
			this._optCommonQtyEffect_3.Location = new System.Drawing.Point(6, 16);
			this._optCommonQtyEffect_3.Name = "_optCommonQtyEffect_3";
			this._optCommonQtyEffect_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._optCommonQtyEffect_3.Size = new System.Drawing.Size(123, 19);
			this._optCommonQtyEffect_3.TabIndex = 28;
			this._optCommonQtyEffect_3.TabStop = true;
			this._optCommonQtyEffect_3.Text = "Use XML Reports";
			this._optCommonQtyEffect_3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._optCommonQtyEffect_3.Visible = true;
			this._optCommonQtyEffect_3.CheckedChanged += new System.EventHandler(this.optCommonQtyEffect_CheckedChanged);
			// 
			// _txtCommon_12
			// 
			this._txtCommon_12.AllowDrop = true;
			this._txtCommon_12.BackColor = System.Drawing.Color.FromArgb(239, 239, 239);
			// this._txtCommon_12.bolAllowDecimal = false;
			this._txtCommon_12.Enabled = false;
			this._txtCommon_12.ForeColor = System.Drawing.Color.Black;
			this._txtCommon_12.Location = new System.Drawing.Point(150, 34);
			// this._txtCommon_12.mDropDownType = (System.Windows.Forms.TextBox.DropDownTypes) 0;
			this._txtCommon_12.Name = "_txtCommon_12";
			this._txtCommon_12.Size = new System.Drawing.Size(197, 19);
			this._txtCommon_12.TabIndex = 5;
			this._txtCommon_12.Text = "";
			// 
			// _lblCommon_12
			// 
			this._lblCommon_12.AllowDrop = true;
			this._lblCommon_12.BackColor = System.Drawing.SystemColors.Window;
			this._lblCommon_12.Text = "Report ID(English)";
			this._lblCommon_12.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_12.Location = new System.Drawing.Point(148, 62);
			this._lblCommon_12.Name = "_lblCommon_12";
			this._lblCommon_12.Size = new System.Drawing.Size(86, 14);
			this._lblCommon_12.TabIndex = 93;
			this._lblCommon_12.Visible = false;
			// 
			// _lblCommon_13
			// 
			this._lblCommon_13.AllowDrop = true;
			this._lblCommon_13.BackColor = System.Drawing.SystemColors.Window;
			this._lblCommon_13.Text = "Entry Id(English)";
			this._lblCommon_13.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_13.Location = new System.Drawing.Point(148, 62);
			this._lblCommon_13.Name = "_lblCommon_13";
			this._lblCommon_13.Size = new System.Drawing.Size(78, 14);
			this._lblCommon_13.TabIndex = 94;
			this._lblCommon_13.Visible = false;
			// 
			// _lblCommon_14
			// 
			this._lblCommon_14.AllowDrop = true;
			this._lblCommon_14.BackColor = System.Drawing.SystemColors.Window;
			this._lblCommon_14.Text = "Print Voucher Name";
			this._lblCommon_14.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_14.Location = new System.Drawing.Point(30, 36);
			this._lblCommon_14.Name = "_lblCommon_14";
			this._lblCommon_14.Size = new System.Drawing.Size(96, 14);
			this._lblCommon_14.TabIndex = 95;
			// 
			// _txtControl_22
			// 
			this._txtControl_22.AllowDrop = true;
			this._txtControl_22.BackColor = System.Drawing.Color.FromArgb(239, 239, 239);
			this._txtControl_22.Enabled = false;
			this._txtControl_22.ForeColor = System.Drawing.Color.Black;
			this._txtControl_22.Location = new System.Drawing.Point(284, 60);
			this._txtControl_22.Name = "_txtControl_22";
			this._txtControl_22.Size = new System.Drawing.Size(69, 19);
			this._txtControl_22.TabIndex = 25;
			this._txtControl_22.Text = "";
			this._txtControl_22.Visible = false;
			// this.this._txtControl_22.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtControl_DropButtonClick);
			// this._txtControl_22.Leave += new System.EventHandler(this.txtControl_Leave);
			// 
			// _txtControl_2
			// 
			this._txtControl_2.AllowDrop = true;
			this._txtControl_2.BackColor = System.Drawing.Color.White;
			// this._txtControl_2.bolAllowDecimal = false;
			// this._txtControl_2.bolNumericOnly = true;
			this._txtControl_2.ForeColor = System.Drawing.Color.Black;
			this._txtControl_2.Location = new System.Drawing.Point(284, 60);
			this._txtControl_2.MaxLength = 10;
			this._txtControl_2.Name = "_txtControl_2";
			// this._txtControl_2.ShowButton = true;
			this._txtControl_2.Size = new System.Drawing.Size(69, 19);
			this._txtControl_2.TabIndex = 2;
			this._txtControl_2.Text = "";
			this._txtControl_2.Visible = false;
			// this.this._txtControl_2.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtControl_DropButtonClick);
			// this._txtControl_2.Leave += new System.EventHandler(this.txtControl_Leave);
			// 
			// _txtControl_4
			// 
			this._txtControl_4.AllowDrop = true;
			this._txtControl_4.BackColor = System.Drawing.Color.FromArgb(239, 239, 239);
			this._txtControl_4.Enabled = false;
			this._txtControl_4.ForeColor = System.Drawing.Color.Black;
			this._txtControl_4.Location = new System.Drawing.Point(284, 60);
			this._txtControl_4.Name = "_txtControl_4";
			this._txtControl_4.Size = new System.Drawing.Size(69, 19);
			this._txtControl_4.TabIndex = 24;
			this._txtControl_4.Text = "";
			this._txtControl_4.Visible = false;
			// this.this._txtControl_4.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtControl_DropButtonClick);
			// this._txtControl_4.Leave += new System.EventHandler(this.txtControl_Leave);
			// 
			// _txtControl_5
			// 
			this._txtControl_5.AllowDrop = true;
			this._txtControl_5.BackColor = System.Drawing.Color.White;
			// this._txtControl_5.bolAllowDecimal = false;
			// this._txtControl_5.bolNumericOnly = true;
			this._txtControl_5.ForeColor = System.Drawing.Color.Black;
			this._txtControl_5.Location = new System.Drawing.Point(284, 60);
			this._txtControl_5.MaxLength = 10;
			this._txtControl_5.Name = "_txtControl_5";
			// this._txtControl_5.ShowButton = true;
			this._txtControl_5.Size = new System.Drawing.Size(69, 19);
			this._txtControl_5.TabIndex = 1;
			this._txtControl_5.Text = "";
			this._txtControl_5.Visible = false;
			// this.this._txtControl_5.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtControl_DropButtonClick);
			// this._txtControl_5.Leave += new System.EventHandler(this.txtControl_Leave);
			// 
			// _lblCommon_0
			// 
			this._lblCommon_0.AllowDrop = true;
			this._lblCommon_0.BackColor = System.Drawing.SystemColors.Window;
			this._lblCommon_0.Text = "Report ID(Arabic)";
			this._lblCommon_0.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_0.Location = new System.Drawing.Point(148, 62);
			this._lblCommon_0.Name = "_lblCommon_0";
			this._lblCommon_0.Size = new System.Drawing.Size(84, 14);
			this._lblCommon_0.TabIndex = 96;
			this._lblCommon_0.Visible = false;
			// 
			// _lblCommon_1
			// 
			this._lblCommon_1.AllowDrop = true;
			this._lblCommon_1.BackColor = System.Drawing.SystemColors.Window;
			this._lblCommon_1.Text = "Entry Id(Arabic)";
			this._lblCommon_1.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_1.Location = new System.Drawing.Point(148, 62);
			this._lblCommon_1.Name = "_lblCommon_1";
			this._lblCommon_1.Size = new System.Drawing.Size(76, 14);
			this._lblCommon_1.TabIndex = 97;
			this._lblCommon_1.Visible = false;
			// 
			// _txtControl_10
			// 
			this._txtControl_10.AllowDrop = true;
			this._txtControl_10.BackColor = System.Drawing.Color.FromArgb(239, 239, 239);
			this._txtControl_10.Enabled = false;
			this._txtControl_10.ForeColor = System.Drawing.Color.Black;
			this._txtControl_10.Location = new System.Drawing.Point(284, 60);
			this._txtControl_10.Name = "_txtControl_10";
			this._txtControl_10.Size = new System.Drawing.Size(69, 19);
			this._txtControl_10.TabIndex = 27;
			this._txtControl_10.Text = "";
			this._txtControl_10.Visible = false;
			// this.this._txtControl_10.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtControl_DropButtonClick);
			// this._txtControl_10.Leave += new System.EventHandler(this.txtControl_Leave);
			// 
			// _txtControl_11
			// 
			this._txtControl_11.AllowDrop = true;
			this._txtControl_11.BackColor = System.Drawing.Color.White;
			// this._txtControl_11.bolAllowDecimal = false;
			// this._txtControl_11.bolNumericOnly = true;
			this._txtControl_11.ForeColor = System.Drawing.Color.Black;
			this._txtControl_11.Location = new System.Drawing.Point(284, 60);
			this._txtControl_11.MaxLength = 10;
			this._txtControl_11.Name = "_txtControl_11";
			// this._txtControl_11.ShowButton = true;
			this._txtControl_11.Size = new System.Drawing.Size(69, 19);
			this._txtControl_11.TabIndex = 4;
			this._txtControl_11.Text = "";
			this._txtControl_11.Visible = false;
			// this.this._txtControl_11.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtControl_DropButtonClick);
			// this._txtControl_11.Leave += new System.EventHandler(this.txtControl_Leave);
			// 
			// _txtControl_12
			// 
			this._txtControl_12.AllowDrop = true;
			this._txtControl_12.BackColor = System.Drawing.Color.FromArgb(239, 239, 239);
			this._txtControl_12.Enabled = false;
			this._txtControl_12.ForeColor = System.Drawing.Color.Black;
			this._txtControl_12.Location = new System.Drawing.Point(284, 60);
			this._txtControl_12.Name = "_txtControl_12";
			this._txtControl_12.Size = new System.Drawing.Size(69, 19);
			this._txtControl_12.TabIndex = 26;
			this._txtControl_12.Text = "";
			this._txtControl_12.Visible = false;
			// this.this._txtControl_12.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtControl_DropButtonClick);
			// this._txtControl_12.Leave += new System.EventHandler(this.txtControl_Leave);
			// 
			// _txtControl_13
			// 
			this._txtControl_13.AllowDrop = true;
			this._txtControl_13.BackColor = System.Drawing.Color.White;
			// this._txtControl_13.bolAllowDecimal = false;
			// this._txtControl_13.bolNumericOnly = true;
			this._txtControl_13.ForeColor = System.Drawing.Color.Black;
			this._txtControl_13.Location = new System.Drawing.Point(284, 60);
			this._txtControl_13.MaxLength = 10;
			this._txtControl_13.Name = "_txtControl_13";
			// this._txtControl_13.ShowButton = true;
			this._txtControl_13.Size = new System.Drawing.Size(69, 19);
			this._txtControl_13.TabIndex = 3;
			this._txtControl_13.Text = "";
			this._txtControl_13.Visible = false;
			// this.this._txtControl_13.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtControl_DropButtonClick);
			// this._txtControl_13.Leave += new System.EventHandler(this.txtControl_Leave);
			// 
			// cmbPrintList
			// 
			this.cmbPrintList.AllowDrop = true;
			this.cmbPrintList.ColumnHeaders = true;
			this.cmbPrintList.Enabled = true;
			this.cmbPrintList.Location = new System.Drawing.Point(86, 102);
			this.cmbPrintList.Name = "cmbPrintList";
			this.cmbPrintList.Size = new System.Drawing.Size(227, 78);
			this.cmbPrintList.TabIndex = 121;
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
			this.grdPrintTask.Location = new System.Drawing.Point(4, 82);
			this.grdPrintTask.Name = "grdPrintTask";
			this.grdPrintTask.RowDivider.Color = System.Drawing.Color.LightGray;
			this.grdPrintTask.RowDivider.Color = System.Drawing.Color.FromArgb(236, 233, 216);
			this.grdPrintTask.RowDivider.Style = C1.Win.C1TrueDBGrid.LineStyleEnum.Single;
			this.grdPrintTask.Size = new System.Drawing.Size(431, 133);
			this.grdPrintTask.TabIndex = 122;
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
			// Frame5
			// 
			this.Frame5.AllowDrop = true;
			this.Frame5.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this.Frame5.Controls.Add(this._txtMultiLineControl_11);
			this.Frame5.Controls.Add(this._txtMultiLineControl_10);
			this.Frame5.Controls.Add(this._lblControl_8);
			this.Frame5.Controls.Add(this._lblControl_9);
			this.Frame5.Controls.Add(this._txtControl_51);
			this.Frame5.Controls.Add(this._lblControl_14);
			this.Frame5.Enabled = true;
			this.Frame5.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Frame5.Location = new System.Drawing.Point(544, 23);
			this.Frame5.Name = "Frame5";
			this.Frame5.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Frame5.Size = new System.Drawing.Size(455, 321);
			this.Frame5.TabIndex = 86;
			this.Frame5.Visible = true;
			// 
			// _txtMultiLineControl_11
			// 
			this._txtMultiLineControl_11.AcceptsReturn = true;
			this._txtMultiLineControl_11.AllowDrop = true;
			this._txtMultiLineControl_11.BackColor = System.Drawing.SystemColors.Window;
			this._txtMultiLineControl_11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this._txtMultiLineControl_11.Cursor = System.Windows.Forms.Cursors.IBeam;
			this._txtMultiLineControl_11.ForeColor = System.Drawing.SystemColors.WindowText;
			this._txtMultiLineControl_11.Location = new System.Drawing.Point(110, 163);
			this._txtMultiLineControl_11.MaxLength = 1000;
			this._txtMultiLineControl_11.Multiline = true;
			this._txtMultiLineControl_11.Name = "_txtMultiLineControl_11";
			this._txtMultiLineControl_11.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtMultiLineControl_11.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this._txtMultiLineControl_11.Size = new System.Drawing.Size(325, 123);
			this._txtMultiLineControl_11.TabIndex = 63;
			this._txtMultiLineControl_11.WordWrap = false;
			// 
			// _txtMultiLineControl_10
			// 
			this._txtMultiLineControl_10.AcceptsReturn = true;
			this._txtMultiLineControl_10.AllowDrop = true;
			this._txtMultiLineControl_10.BackColor = System.Drawing.SystemColors.Window;
			this._txtMultiLineControl_10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this._txtMultiLineControl_10.Cursor = System.Windows.Forms.Cursors.IBeam;
			this._txtMultiLineControl_10.ForeColor = System.Drawing.SystemColors.WindowText;
			this._txtMultiLineControl_10.Location = new System.Drawing.Point(110, 40);
			this._txtMultiLineControl_10.MaxLength = 1000;
			this._txtMultiLineControl_10.Multiline = true;
			this._txtMultiLineControl_10.Name = "_txtMultiLineControl_10";
			this._txtMultiLineControl_10.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtMultiLineControl_10.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this._txtMultiLineControl_10.Size = new System.Drawing.Size(325, 123);
			this._txtMultiLineControl_10.TabIndex = 62;
			this._txtMultiLineControl_10.WordWrap = false;
			// 
			// _lblControl_8
			// 
			this._lblControl_8.AllowDrop = true;
			this._lblControl_8.BackColor = System.Drawing.SystemColors.Window;
			this._lblControl_8.Text = "Debit Filter Condition";
			this._lblControl_8.ForeColor = System.Drawing.Color.Black;
			this._lblControl_8.Location = new System.Drawing.Point(4, 95);
			this._lblControl_8.Name = "_lblControl_8";
			this._lblControl_8.Size = new System.Drawing.Size(100, 13);
			this._lblControl_8.TabIndex = 87;
			// 
			// _lblControl_9
			// 
			this._lblControl_9.AllowDrop = true;
			this._lblControl_9.BackColor = System.Drawing.SystemColors.Window;
			this._lblControl_9.Text = "Credit Filter Condition";
			this._lblControl_9.ForeColor = System.Drawing.Color.Black;
			this._lblControl_9.Location = new System.Drawing.Point(4, 218);
			this._lblControl_9.Name = "_lblControl_9";
			this._lblControl_9.Size = new System.Drawing.Size(104, 13);
			this._lblControl_9.TabIndex = 88;
			// 
			// _txtControl_51
			// 
			this._txtControl_51.AllowDrop = true;
			this._txtControl_51.BackColor = System.Drawing.Color.White;
			this._txtControl_51.ForeColor = System.Drawing.Color.Black;
			this._txtControl_51.Location = new System.Drawing.Point(110, 18);
			this._txtControl_51.MaxLength = 30;
			this._txtControl_51.Name = "_txtControl_51";
			this._txtControl_51.Size = new System.Drawing.Size(93, 19);
			this._txtControl_51.TabIndex = 61;
			this._txtControl_51.Text = "";
			// this.this._txtControl_51.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtControl_DropButtonClick);
			// this._txtControl_51.Leave += new System.EventHandler(this.txtControl_Leave);
			// 
			// _lblControl_14
			// 
			this._lblControl_14.AllowDrop = true;
			this._lblControl_14.BackColor = System.Drawing.SystemColors.Window;
			this._lblControl_14.Text = "Find ID";
			this._lblControl_14.ForeColor = System.Drawing.Color.Black;
			this._lblControl_14.Location = new System.Drawing.Point(4, 21);
			this._lblControl_14.Name = "_lblControl_14";
			this._lblControl_14.Size = new System.Drawing.Size(34, 13);
			this._lblControl_14.TabIndex = 89;
			// 
			// Frame3
			// 
			this.Frame3.AllowDrop = true;
			this.Frame3.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this.Frame3.Controls.Add(this._chkControl_13);
			this.Frame3.Controls.Add(this._chkControl_11);
			this.Frame3.Controls.Add(this._chkControl_10);
			this.Frame3.Controls.Add(this._chkControl_9);
			this.Frame3.Controls.Add(this._chkControl_8);
			this.Frame3.Controls.Add(this._chkControl_0);
			this.Frame3.Controls.Add(this._chkControl_18);
			this.Frame3.Controls.Add(this._chkControl_1);
			this.Frame3.Controls.Add(this._chkControl_7);
			this.Frame3.Controls.Add(this._chkControl_2);
			this.Frame3.Controls.Add(this._chkControl_3);
			this.Frame3.Controls.Add(this._chkControl_5);
			this.Frame3.Controls.Add(this._chkControl_6);
			this.Frame3.Controls.Add(this._chkControl_28);
			this.Frame3.Controls.Add(this._chkControl_19);
			this.Frame3.Controls.Add(this._chkControl_21);
			this.Frame3.Controls.Add(this._chkControl_22);
			this.Frame3.Controls.Add(this._chkControl_23);
			this.Frame3.Controls.Add(this._chkControl_24);
			this.Frame3.Controls.Add(this._chkControl_25);
			this.Frame3.Controls.Add(this._chkControl_26);
			this.Frame3.Controls.Add(this._chkControl_27);
			this.Frame3.Controls.Add(this._chkControl_29);
			this.Frame3.Controls.Add(this._chkControl_30);
			this.Frame3.Controls.Add(this._chkControl_31);
			this.Frame3.Controls.Add(this._chkControl_32);
			this.Frame3.Controls.Add(this._chkControl_34);
			this.Frame3.Controls.Add(this._chkControl_35);
			this.Frame3.Controls.Add(this._chkControl_37);
			this.Frame3.Controls.Add(this._chkControl_39);
			this.Frame3.Controls.Add(this._chkControl_40);
			this.Frame3.Controls.Add(this._chkControl_41);
			this.Frame3.Controls.Add(this._chkControl_38);
			this.Frame3.Enabled = true;
			this.Frame3.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Frame3.Location = new System.Drawing.Point(524, 23);
			this.Frame3.Name = "Frame3";
			this.Frame3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Frame3.Size = new System.Drawing.Size(455, 321);
			this.Frame3.TabIndex = 67;
			this.Frame3.Visible = true;
			// 
			// _chkControl_13
			// 
			this._chkControl_13.AllowDrop = true;
			this._chkControl_13.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkControl_13.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._chkControl_13.CausesValidation = true;
			this._chkControl_13.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkControl_13.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkControl_13.Enabled = true;
			this._chkControl_13.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkControl_13.Location = new System.Drawing.Point(248, 296);
			this._chkControl_13.Name = "_chkControl_13";
			this._chkControl_13.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkControl_13.Size = new System.Drawing.Size(177, 17);
			this._chkControl_13.TabIndex = 125;
			this._chkControl_13.TabStop = true;
			this._chkControl_13.Text = "Show Default Salesman In Detail";
			this._chkControl_13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkControl_13.Visible = true;
			this._chkControl_13.CheckStateChanged += new System.EventHandler(this.chkControl_CheckStateChanged);
			// 
			// _chkControl_11
			// 
			this._chkControl_11.AllowDrop = true;
			this._chkControl_11.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkControl_11.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._chkControl_11.CausesValidation = true;
			this._chkControl_11.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkControl_11.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkControl_11.Enabled = true;
			this._chkControl_11.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkControl_11.Location = new System.Drawing.Point(248, 278);
			this._chkControl_11.Name = "_chkControl_11";
			this._chkControl_11.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkControl_11.Size = new System.Drawing.Size(167, 17);
			this._chkControl_11.TabIndex = 124;
			this._chkControl_11.TabStop = true;
			this._chkControl_11.Text = "Display Voucher No After Save";
			this._chkControl_11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkControl_11.Visible = true;
			this._chkControl_11.CheckStateChanged += new System.EventHandler(this.chkControl_CheckStateChanged);
			// 
			// _chkControl_10
			// 
			this._chkControl_10.AllowDrop = true;
			this._chkControl_10.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkControl_10.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._chkControl_10.CausesValidation = true;
			this._chkControl_10.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkControl_10.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkControl_10.Enabled = true;
			this._chkControl_10.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkControl_10.Location = new System.Drawing.Point(14, 296);
			this._chkControl_10.Name = "_chkControl_10";
			this._chkControl_10.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkControl_10.Size = new System.Drawing.Size(167, 17);
			this._chkControl_10.TabIndex = 123;
			this._chkControl_10.TabStop = true;
			this._chkControl_10.Text = "Show Flex1 In Details";
			this._chkControl_10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkControl_10.Visible = true;
			this._chkControl_10.CheckStateChanged += new System.EventHandler(this.chkControl_CheckStateChanged);
			// 
			// _chkControl_9
			// 
			this._chkControl_9.AllowDrop = true;
			this._chkControl_9.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkControl_9.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._chkControl_9.CausesValidation = true;
			this._chkControl_9.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkControl_9.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkControl_9.Enabled = true;
			this._chkControl_9.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkControl_9.Location = new System.Drawing.Point(248, 260);
			this._chkControl_9.Name = "_chkControl_9";
			this._chkControl_9.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkControl_9.Size = new System.Drawing.Size(167, 17);
			this._chkControl_9.TabIndex = 120;
			this._chkControl_9.TabStop = true;
			this._chkControl_9.Text = "Show Consignment In Details";
			this._chkControl_9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkControl_9.Visible = true;
			this._chkControl_9.CheckStateChanged += new System.EventHandler(this.chkControl_CheckStateChanged);
			// 
			// _chkControl_8
			// 
			this._chkControl_8.AllowDrop = true;
			this._chkControl_8.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkControl_8.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._chkControl_8.CausesValidation = true;
			this._chkControl_8.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkControl_8.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkControl_8.Enabled = true;
			this._chkControl_8.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkControl_8.Location = new System.Drawing.Point(248, 242);
			this._chkControl_8.Name = "_chkControl_8";
			this._chkControl_8.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkControl_8.Size = new System.Drawing.Size(167, 17);
			this._chkControl_8.TabIndex = 119;
			this._chkControl_8.TabStop = true;
			this._chkControl_8.Text = "Get Max New Voucher No";
			this._chkControl_8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkControl_8.Visible = true;
			this._chkControl_8.CheckStateChanged += new System.EventHandler(this.chkControl_CheckStateChanged);
			// 
			// _chkControl_0
			// 
			this._chkControl_0.AllowDrop = true;
			this._chkControl_0.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkControl_0.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._chkControl_0.CausesValidation = true;
			this._chkControl_0.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkControl_0.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkControl_0.Enabled = true;
			this._chkControl_0.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkControl_0.Location = new System.Drawing.Point(14, 278);
			this._chkControl_0.Name = "_chkControl_0";
			this._chkControl_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkControl_0.Size = new System.Drawing.Size(167, 17);
			this._chkControl_0.TabIndex = 118;
			this._chkControl_0.TabStop = true;
			this._chkControl_0.Text = "Enable Combo List";
			this._chkControl_0.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkControl_0.Visible = true;
			this._chkControl_0.CheckStateChanged += new System.EventHandler(this.chkControl_CheckStateChanged);
			// 
			// _chkControl_18
			// 
			this._chkControl_18.AllowDrop = true;
			this._chkControl_18.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkControl_18.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._chkControl_18.CausesValidation = true;
			this._chkControl_18.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkControl_18.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkControl_18.Enabled = true;
			this._chkControl_18.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkControl_18.Location = new System.Drawing.Point(248, 204);
			this._chkControl_18.Name = "_chkControl_18";
			this._chkControl_18.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkControl_18.Size = new System.Drawing.Size(149, 17);
			this._chkControl_18.TabIndex = 106;
			this._chkControl_18.TabStop = true;
			this._chkControl_18.Text = "Begin With Line Seperator";
			this._chkControl_18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkControl_18.Visible = true;
			this._chkControl_18.CheckStateChanged += new System.EventHandler(this.chkControl_CheckStateChanged);
			// 
			// _chkControl_1
			// 
			this._chkControl_1.AllowDrop = true;
			this._chkControl_1.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkControl_1.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._chkControl_1.CausesValidation = true;
			this._chkControl_1.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkControl_1.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkControl_1.Enabled = true;
			this._chkControl_1.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkControl_1.Location = new System.Drawing.Point(248, 186);
			this._chkControl_1.Name = "_chkControl_1";
			this._chkControl_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkControl_1.Size = new System.Drawing.Size(101, 17);
			this._chkControl_1.TabIndex = 105;
			this._chkControl_1.TabStop = true;
			this._chkControl_1.Text = "Affect GLS";
			this._chkControl_1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkControl_1.Visible = true;
			this._chkControl_1.CheckStateChanged += new System.EventHandler(this.chkControl_CheckStateChanged);
			// 
			// _chkControl_7
			// 
			this._chkControl_7.AllowDrop = true;
			this._chkControl_7.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkControl_7.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._chkControl_7.CausesValidation = true;
			this._chkControl_7.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkControl_7.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkControl_7.Enabled = true;
			this._chkControl_7.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkControl_7.Location = new System.Drawing.Point(248, 224);
			this._chkControl_7.Name = "_chkControl_7";
			this._chkControl_7.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkControl_7.Size = new System.Drawing.Size(167, 17);
			this._chkControl_7.TabIndex = 104;
			this._chkControl_7.TabStop = true;
			this._chkControl_7.Text = "Show Branch Code In Header";
			this._chkControl_7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkControl_7.Visible = true;
			this._chkControl_7.CheckStateChanged += new System.EventHandler(this.chkControl_CheckStateChanged);
			// 
			// _chkControl_2
			// 
			this._chkControl_2.AllowDrop = true;
			this._chkControl_2.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkControl_2.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._chkControl_2.CausesValidation = true;
			this._chkControl_2.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkControl_2.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkControl_2.Enabled = true;
			this._chkControl_2.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkControl_2.Location = new System.Drawing.Point(14, 222);
			this._chkControl_2.Name = "_chkControl_2";
			this._chkControl_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkControl_2.Size = new System.Drawing.Size(117, 17);
			this._chkControl_2.TabIndex = 103;
			this._chkControl_2.TabStop = true;
			this._chkControl_2.Text = "Show Maturity date";
			this._chkControl_2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkControl_2.Visible = true;
			this._chkControl_2.CheckStateChanged += new System.EventHandler(this.chkControl_CheckStateChanged);
			// 
			// _chkControl_3
			// 
			this._chkControl_3.AllowDrop = true;
			this._chkControl_3.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkControl_3.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._chkControl_3.CausesValidation = true;
			this._chkControl_3.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkControl_3.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkControl_3.Enabled = true;
			this._chkControl_3.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkControl_3.Location = new System.Drawing.Point(14, 204);
			this._chkControl_3.Name = "_chkControl_3";
			this._chkControl_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkControl_3.Size = new System.Drawing.Size(115, 17);
			this._chkControl_3.TabIndex = 102;
			this._chkControl_3.TabStop = true;
			this._chkControl_3.Text = "Show Cheque No.";
			this._chkControl_3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkControl_3.Visible = true;
			this._chkControl_3.CheckStateChanged += new System.EventHandler(this.chkControl_CheckStateChanged);
			// 
			// _chkControl_5
			// 
			this._chkControl_5.AllowDrop = true;
			this._chkControl_5.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkControl_5.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._chkControl_5.CausesValidation = true;
			this._chkControl_5.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkControl_5.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkControl_5.Enabled = true;
			this._chkControl_5.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkControl_5.Location = new System.Drawing.Point(14, 242);
			this._chkControl_5.Name = "_chkControl_5";
			this._chkControl_5.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkControl_5.Size = new System.Drawing.Size(135, 17);
			this._chkControl_5.TabIndex = 101;
			this._chkControl_5.TabStop = true;
			this._chkControl_5.Text = "Show Flex01in Header";
			this._chkControl_5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkControl_5.Visible = true;
			this._chkControl_5.CheckStateChanged += new System.EventHandler(this.chkControl_CheckStateChanged);
			// 
			// _chkControl_6
			// 
			this._chkControl_6.AllowDrop = true;
			this._chkControl_6.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkControl_6.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._chkControl_6.CausesValidation = true;
			this._chkControl_6.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkControl_6.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkControl_6.Enabled = true;
			this._chkControl_6.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkControl_6.Location = new System.Drawing.Point(14, 260);
			this._chkControl_6.Name = "_chkControl_6";
			this._chkControl_6.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkControl_6.Size = new System.Drawing.Size(157, 17);
			this._chkControl_6.TabIndex = 100;
			this._chkControl_6.TabStop = true;
			this._chkControl_6.Text = "Show Cheque No. In Details";
			this._chkControl_6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkControl_6.Visible = true;
			this._chkControl_6.CheckStateChanged += new System.EventHandler(this.chkControl_CheckStateChanged);
			// 
			// _chkControl_28
			// 
			this._chkControl_28.AllowDrop = true;
			this._chkControl_28.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkControl_28.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._chkControl_28.CausesValidation = true;
			this._chkControl_28.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkControl_28.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkControl_28.Enabled = true;
			this._chkControl_28.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkControl_28.Location = new System.Drawing.Point(14, 163);
			this._chkControl_28.Name = "_chkControl_28";
			this._chkControl_28.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkControl_28.Size = new System.Drawing.Size(109, 17);
			this._chkControl_28.TabIndex = 49;
			this._chkControl_28.TabStop = true;
			this._chkControl_28.Text = "Show Cost Center";
			this._chkControl_28.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkControl_28.Visible = true;
			this._chkControl_28.CheckStateChanged += new System.EventHandler(this.chkControl_CheckStateChanged);
			// 
			// _chkControl_19
			// 
			this._chkControl_19.AllowDrop = true;
			this._chkControl_19.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkControl_19.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._chkControl_19.CausesValidation = true;
			this._chkControl_19.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkControl_19.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkControl_19.Enabled = false;
			this._chkControl_19.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkControl_19.Location = new System.Drawing.Point(14, 11);
			this._chkControl_19.Name = "_chkControl_19";
			this._chkControl_19.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkControl_19.Size = new System.Drawing.Size(209, 17);
			this._chkControl_19.TabIndex = 41;
			this._chkControl_19.TabStop = true;
			this._chkControl_19.Text = "Adjust Difference In Opp. Ledger Code";
			this._chkControl_19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkControl_19.Visible = true;
			this._chkControl_19.CheckStateChanged += new System.EventHandler(this.chkControl_CheckStateChanged);
			// 
			// _chkControl_21
			// 
			this._chkControl_21.AllowDrop = true;
			this._chkControl_21.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkControl_21.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._chkControl_21.CausesValidation = true;
			this._chkControl_21.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkControl_21.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkControl_21.Enabled = true;
			this._chkControl_21.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkControl_21.Location = new System.Drawing.Point(14, 30);
			this._chkControl_21.Name = "_chkControl_21";
			this._chkControl_21.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkControl_21.Size = new System.Drawing.Size(101, 17);
			this._chkControl_21.TabIndex = 42;
			this._chkControl_21.TabStop = true;
			this._chkControl_21.Text = "Show Line No";
			this._chkControl_21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkControl_21.Visible = true;
			this._chkControl_21.CheckStateChanged += new System.EventHandler(this.chkControl_CheckStateChanged);
			// 
			// _chkControl_22
			// 
			this._chkControl_22.AllowDrop = true;
			this._chkControl_22.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkControl_22.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._chkControl_22.CausesValidation = true;
			this._chkControl_22.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkControl_22.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkControl_22.Enabled = true;
			this._chkControl_22.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkControl_22.Location = new System.Drawing.Point(14, 49);
			this._chkControl_22.Name = "_chkControl_22";
			this._chkControl_22.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkControl_22.Size = new System.Drawing.Size(109, 17);
			this._chkControl_22.TabIndex = 43;
			this._chkControl_22.TabStop = true;
			this._chkControl_22.Text = "Show Dr/Cr Type";
			this._chkControl_22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkControl_22.Visible = true;
			this._chkControl_22.CheckStateChanged += new System.EventHandler(this.chkControl_CheckStateChanged);
			// 
			// _chkControl_23
			// 
			this._chkControl_23.AllowDrop = true;
			this._chkControl_23.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkControl_23.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._chkControl_23.CausesValidation = true;
			this._chkControl_23.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkControl_23.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkControl_23.Enabled = true;
			this._chkControl_23.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkControl_23.Location = new System.Drawing.Point(14, 68);
			this._chkControl_23.Name = "_chkControl_23";
			this._chkControl_23.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkControl_23.Size = new System.Drawing.Size(115, 17);
			this._chkControl_23.TabIndex = 44;
			this._chkControl_23.TabStop = true;
			this._chkControl_23.Text = "Show Ledger Code";
			this._chkControl_23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkControl_23.Visible = true;
			this._chkControl_23.CheckStateChanged += new System.EventHandler(this.chkControl_CheckStateChanged);
			// 
			// _chkControl_24
			// 
			this._chkControl_24.AllowDrop = true;
			this._chkControl_24.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkControl_24.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._chkControl_24.CausesValidation = true;
			this._chkControl_24.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkControl_24.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkControl_24.Enabled = true;
			this._chkControl_24.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkControl_24.Location = new System.Drawing.Point(14, 87);
			this._chkControl_24.Name = "_chkControl_24";
			this._chkControl_24.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkControl_24.Size = new System.Drawing.Size(121, 17);
			this._chkControl_24.TabIndex = 45;
			this._chkControl_24.TabStop = true;
			this._chkControl_24.Text = "Show Ledger Name";
			this._chkControl_24.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkControl_24.Visible = true;
			this._chkControl_24.CheckStateChanged += new System.EventHandler(this.chkControl_CheckStateChanged);
			// 
			// _chkControl_25
			// 
			this._chkControl_25.AllowDrop = true;
			this._chkControl_25.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkControl_25.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._chkControl_25.CausesValidation = true;
			this._chkControl_25.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkControl_25.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkControl_25.Enabled = true;
			this._chkControl_25.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkControl_25.Location = new System.Drawing.Point(14, 106);
			this._chkControl_25.Name = "_chkControl_25";
			this._chkControl_25.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkControl_25.Size = new System.Drawing.Size(101, 17);
			this._chkControl_25.TabIndex = 46;
			this._chkControl_25.TabStop = true;
			this._chkControl_25.Text = "Show Currency";
			this._chkControl_25.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkControl_25.Visible = true;
			this._chkControl_25.CheckStateChanged += new System.EventHandler(this.chkControl_CheckStateChanged);
			// 
			// _chkControl_26
			// 
			this._chkControl_26.AllowDrop = true;
			this._chkControl_26.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkControl_26.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._chkControl_26.CausesValidation = true;
			this._chkControl_26.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkControl_26.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkControl_26.Enabled = true;
			this._chkControl_26.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkControl_26.Location = new System.Drawing.Point(14, 125);
			this._chkControl_26.Name = "_chkControl_26";
			this._chkControl_26.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkControl_26.Size = new System.Drawing.Size(101, 17);
			this._chkControl_26.TabIndex = 47;
			this._chkControl_26.TabStop = true;
			this._chkControl_26.Text = "Show Dr Amount";
			this._chkControl_26.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkControl_26.Visible = true;
			this._chkControl_26.CheckStateChanged += new System.EventHandler(this.chkControl_CheckStateChanged);
			// 
			// _chkControl_27
			// 
			this._chkControl_27.AllowDrop = true;
			this._chkControl_27.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkControl_27.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._chkControl_27.CausesValidation = true;
			this._chkControl_27.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkControl_27.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkControl_27.Enabled = true;
			this._chkControl_27.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkControl_27.Location = new System.Drawing.Point(14, 144);
			this._chkControl_27.Name = "_chkControl_27";
			this._chkControl_27.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkControl_27.Size = new System.Drawing.Size(101, 17);
			this._chkControl_27.TabIndex = 48;
			this._chkControl_27.TabStop = true;
			this._chkControl_27.Text = "Show Cr Amount";
			this._chkControl_27.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkControl_27.Visible = true;
			this._chkControl_27.CheckStateChanged += new System.EventHandler(this.chkControl_CheckStateChanged);
			// 
			// _chkControl_29
			// 
			this._chkControl_29.AllowDrop = true;
			this._chkControl_29.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkControl_29.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._chkControl_29.CausesValidation = true;
			this._chkControl_29.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkControl_29.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkControl_29.Enabled = true;
			this._chkControl_29.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkControl_29.Location = new System.Drawing.Point(14, 184);
			this._chkControl_29.Name = "_chkControl_29";
			this._chkControl_29.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkControl_29.Size = new System.Drawing.Size(101, 17);
			this._chkControl_29.TabIndex = 50;
			this._chkControl_29.TabStop = true;
			this._chkControl_29.Text = "Show Salesman";
			this._chkControl_29.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkControl_29.Visible = true;
			this._chkControl_29.CheckStateChanged += new System.EventHandler(this.chkControl_CheckStateChanged);
			// 
			// _chkControl_30
			// 
			this._chkControl_30.AllowDrop = true;
			this._chkControl_30.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkControl_30.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._chkControl_30.CausesValidation = true;
			this._chkControl_30.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkControl_30.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkControl_30.Enabled = true;
			this._chkControl_30.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkControl_30.Location = new System.Drawing.Point(248, 11);
			this._chkControl_30.Name = "_chkControl_30";
			this._chkControl_30.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkControl_30.Size = new System.Drawing.Size(139, 19);
			this._chkControl_30.TabIndex = 51;
			this._chkControl_30.TabStop = true;
			this._chkControl_30.Text = "Show Remarks In Detail";
			this._chkControl_30.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkControl_30.Visible = true;
			this._chkControl_30.CheckStateChanged += new System.EventHandler(this.chkControl_CheckStateChanged);
			// 
			// _chkControl_31
			// 
			this._chkControl_31.AllowDrop = true;
			this._chkControl_31.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkControl_31.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._chkControl_31.CausesValidation = true;
			this._chkControl_31.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkControl_31.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkControl_31.Enabled = true;
			this._chkControl_31.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkControl_31.Location = new System.Drawing.Point(248, 28);
			this._chkControl_31.Name = "_chkControl_31";
			this._chkControl_31.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkControl_31.Size = new System.Drawing.Size(147, 17);
			this._chkControl_31.TabIndex = 52;
			this._chkControl_31.TabStop = true;
			this._chkControl_31.Text = "Show Remarks In Header";
			this._chkControl_31.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkControl_31.Visible = true;
			this._chkControl_31.CheckStateChanged += new System.EventHandler(this.chkControl_CheckStateChanged);
			// 
			// _chkControl_32
			// 
			this._chkControl_32.AllowDrop = true;
			this._chkControl_32.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkControl_32.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._chkControl_32.CausesValidation = true;
			this._chkControl_32.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkControl_32.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkControl_32.Enabled = false;
			this._chkControl_32.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkControl_32.Location = new System.Drawing.Point(248, 60);
			this._chkControl_32.Name = "_chkControl_32";
			this._chkControl_32.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkControl_32.Size = new System.Drawing.Size(173, 17);
			this._chkControl_32.TabIndex = 54;
			this._chkControl_32.TabStop = true;
			this._chkControl_32.Text = "Show Additional Ledger Details";
			this._chkControl_32.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkControl_32.Visible = true;
			this._chkControl_32.CheckStateChanged += new System.EventHandler(this.chkControl_CheckStateChanged);
			// 
			// _chkControl_34
			// 
			this._chkControl_34.AllowDrop = true;
			this._chkControl_34.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkControl_34.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._chkControl_34.CausesValidation = true;
			this._chkControl_34.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkControl_34.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkControl_34.Enabled = true;
			this._chkControl_34.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkControl_34.Location = new System.Drawing.Point(248, 77);
			this._chkControl_34.Name = "_chkControl_34";
			this._chkControl_34.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkControl_34.Size = new System.Drawing.Size(157, 17);
			this._chkControl_34.TabIndex = 55;
			this._chkControl_34.TabStop = true;
			this._chkControl_34.Text = "Allow Listing of Ledger Code";
			this._chkControl_34.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkControl_34.Visible = true;
			this._chkControl_34.CheckStateChanged += new System.EventHandler(this.chkControl_CheckStateChanged);
			// 
			// _chkControl_35
			// 
			this._chkControl_35.AllowDrop = true;
			this._chkControl_35.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkControl_35.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._chkControl_35.CausesValidation = true;
			this._chkControl_35.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkControl_35.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkControl_35.Enabled = true;
			this._chkControl_35.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkControl_35.Location = new System.Drawing.Point(248, 94);
			this._chkControl_35.Name = "_chkControl_35";
			this._chkControl_35.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkControl_35.Size = new System.Drawing.Size(161, 17);
			this._chkControl_35.TabIndex = 56;
			this._chkControl_35.TabStop = true;
			this._chkControl_35.Text = "Allow Listing of Ledger Name";
			this._chkControl_35.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkControl_35.Visible = true;
			this._chkControl_35.CheckStateChanged += new System.EventHandler(this.chkControl_CheckStateChanged);
			// 
			// _chkControl_37
			// 
			this._chkControl_37.AllowDrop = true;
			this._chkControl_37.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkControl_37.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._chkControl_37.CausesValidation = true;
			this._chkControl_37.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkControl_37.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkControl_37.Enabled = true;
			this._chkControl_37.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkControl_37.Location = new System.Drawing.Point(248, 111);
			this._chkControl_37.Name = "_chkControl_37";
			this._chkControl_37.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkControl_37.Size = new System.Drawing.Size(109, 17);
			this._chkControl_37.TabIndex = 57;
			this._chkControl_37.TabStop = true;
			this._chkControl_37.Text = "Print After Save";
			this._chkControl_37.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkControl_37.Visible = true;
			this._chkControl_37.CheckStateChanged += new System.EventHandler(this.chkControl_CheckStateChanged);
			// 
			// _chkControl_39
			// 
			this._chkControl_39.AllowDrop = true;
			this._chkControl_39.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkControl_39.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._chkControl_39.CausesValidation = true;
			this._chkControl_39.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkControl_39.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkControl_39.Enabled = true;
			this._chkControl_39.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkControl_39.Location = new System.Drawing.Point(248, 128);
			this._chkControl_39.Name = "_chkControl_39";
			this._chkControl_39.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkControl_39.Size = new System.Drawing.Size(135, 17);
			this._chkControl_39.TabIndex = 58;
			this._chkControl_39.TabStop = true;
			this._chkControl_39.Text = "Show Page Setup First";
			this._chkControl_39.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkControl_39.Visible = true;
			this._chkControl_39.CheckStateChanged += new System.EventHandler(this.chkControl_CheckStateChanged);
			// 
			// _chkControl_40
			// 
			this._chkControl_40.AllowDrop = true;
			this._chkControl_40.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkControl_40.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._chkControl_40.CausesValidation = true;
			this._chkControl_40.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkControl_40.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkControl_40.Enabled = true;
			this._chkControl_40.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkControl_40.Location = new System.Drawing.Point(248, 147);
			this._chkControl_40.Name = "_chkControl_40";
			this._chkControl_40.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkControl_40.Size = new System.Drawing.Size(185, 17);
			this._chkControl_40.TabIndex = 59;
			this._chkControl_40.TabStop = true;
			this._chkControl_40.Text = "Close Preview Window After Print";
			this._chkControl_40.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkControl_40.Visible = true;
			this._chkControl_40.CheckStateChanged += new System.EventHandler(this.chkControl_CheckStateChanged);
			// 
			// _chkControl_41
			// 
			this._chkControl_41.AllowDrop = true;
			this._chkControl_41.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkControl_41.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._chkControl_41.CausesValidation = true;
			this._chkControl_41.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkControl_41.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkControl_41.Enabled = true;
			this._chkControl_41.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkControl_41.Location = new System.Drawing.Point(248, 43);
			this._chkControl_41.Name = "_chkControl_41";
			this._chkControl_41.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkControl_41.Size = new System.Drawing.Size(109, 17);
			this._chkControl_41.TabIndex = 53;
			this._chkControl_41.TabStop = true;
			this._chkControl_41.Text = "Show In Menu";
			this._chkControl_41.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkControl_41.Visible = true;
			this._chkControl_41.CheckStateChanged += new System.EventHandler(this.chkControl_CheckStateChanged);
			// 
			// _chkControl_38
			// 
			this._chkControl_38.AllowDrop = true;
			this._chkControl_38.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkControl_38.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._chkControl_38.CausesValidation = true;
			this._chkControl_38.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkControl_38.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkControl_38.Enabled = true;
			this._chkControl_38.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkControl_38.Location = new System.Drawing.Point(248, 166);
			this._chkControl_38.Name = "_chkControl_38";
			this._chkControl_38.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkControl_38.Size = new System.Drawing.Size(137, 17);
			this._chkControl_38.TabIndex = 60;
			this._chkControl_38.TabStop = true;
			this._chkControl_38.Text = "Show Print Preview First";
			this._chkControl_38.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkControl_38.Visible = true;
			this._chkControl_38.CheckStateChanged += new System.EventHandler(this.chkControl_CheckStateChanged);
			// 
			// Frame2
			// 
			this.Frame2.AllowDrop = true;
			this.Frame2.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this.Frame2.Controls.Add(this.txtNumber);
			this.Frame2.Controls.Add(this._chkControl_12);
			this.Frame2.Controls.Add(this.Frame4);
			this.Frame2.Controls.Add(this._chkControl_36);
			this.Frame2.Controls.Add(this._chkControl_33);
			this.Frame2.Controls.Add(this._chkControl_4);
			this.Frame2.Controls.Add(this._lblControl_15);
			this.Frame2.Controls.Add(this._cmbControl_20);
			this.Frame2.Controls.Add(this._lblControl_2);
			this.Frame2.Controls.Add(this._cmbControl_0);
			this.Frame2.Controls.Add(this._lblControl_22);
			this.Frame2.Enabled = true;
			this.Frame2.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Frame2.Location = new System.Drawing.Point(504, 23);
			this.Frame2.Name = "Frame2";
			this.Frame2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Frame2.Size = new System.Drawing.Size(455, 321);
			this.Frame2.TabIndex = 66;
			this.Frame2.Visible = true;
			// 
			// txtNumber
			// 
			this.txtNumber.AllowDrop = true;
			this.txtNumber.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtNumber.Location = new System.Drawing.Point(142, 274);
			this.txtNumber.Name = "txtNumber";
			this.txtNumber.Size = new System.Drawing.Size(101, 23);
			this.txtNumber.TabIndex = 114;
			// 
			// _chkControl_12
			// 
			this._chkControl_12.AllowDrop = true;
			this._chkControl_12.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkControl_12.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._chkControl_12.CausesValidation = true;
			this._chkControl_12.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkControl_12.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkControl_12.Enabled = true;
			this._chkControl_12.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkControl_12.Location = new System.Drawing.Point(18, 20);
			this._chkControl_12.Name = "_chkControl_12";
			this._chkControl_12.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkControl_12.Size = new System.Drawing.Size(107, 17);
			this._chkControl_12.TabIndex = 30;
			this._chkControl_12.TabStop = true;
			this._chkControl_12.Text = "Allow Single Entry";
			this._chkControl_12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkControl_12.Visible = true;
			this._chkControl_12.CheckStateChanged += new System.EventHandler(this.chkControl_CheckStateChanged);
			// 
			// Frame4
			// 
			this.Frame4.AllowDrop = true;
			this.Frame4.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this.Frame4.Controls.Add(this._chkControl_15);
			this.Frame4.Controls.Add(this._lblControl_1);
			this.Frame4.Controls.Add(this._lblControl_10);
			this.Frame4.Controls.Add(this._lblControl_11);
			this.Frame4.Controls.Add(this._lblControl_12);
			this.Frame4.Controls.Add(this._lblControl_13);
			this.Frame4.Controls.Add(this._txtControl_58);
			this.Frame4.Controls.Add(this._cmbControl_13);
			this.Frame4.Controls.Add(this._txtControl_16);
			this.Frame4.Controls.Add(this._txtControl_17);
			this.Frame4.Controls.Add(this._txtControl_14);
			this.Frame4.Controls.Add(this._txtControl_18);
			this.Frame4.Enabled = false;
			this.Frame4.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Frame4.Location = new System.Drawing.Point(8, 22);
			this.Frame4.Name = "Frame4";
			this.Frame4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Frame4.Size = new System.Drawing.Size(433, 163);
			this.Frame4.TabIndex = 79;
			this.Frame4.Visible = true;
			// 
			// _chkControl_15
			// 
			this._chkControl_15.AllowDrop = true;
			this._chkControl_15.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkControl_15.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._chkControl_15.CausesValidation = true;
			this._chkControl_15.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkControl_15.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkControl_15.Enabled = true;
			this._chkControl_15.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkControl_15.Location = new System.Drawing.Point(136, 76);
			this._chkControl_15.Name = "_chkControl_15";
			this._chkControl_15.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkControl_15.Size = new System.Drawing.Size(185, 17);
			this._chkControl_15.TabIndex = 33;
			this._chkControl_15.TabStop = true;
			this._chkControl_15.Text = "Show Opposite Ledger in Header";
			this._chkControl_15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkControl_15.Visible = true;
			this._chkControl_15.CheckStateChanged += new System.EventHandler(this.chkControl_CheckStateChanged);
			// 
			// _lblControl_1
			// 
			this._lblControl_1.AllowDrop = true;
			this._lblControl_1.BackColor = System.Drawing.SystemColors.Window;
			this._lblControl_1.Text = "Opp. Ledger Name Cap.";
			this._lblControl_1.ForeColor = System.Drawing.Color.Black;
			this._lblControl_1.Location = new System.Drawing.Point(8, 139);
			this._lblControl_1.Name = "_lblControl_1";
			this._lblControl_1.Size = new System.Drawing.Size(116, 13);
			this._lblControl_1.TabIndex = 80;
			// 
			// _lblControl_10
			// 
			this._lblControl_10.AllowDrop = true;
			this._lblControl_10.BackColor = System.Drawing.SystemColors.Window;
			this._lblControl_10.Text = "Single Entry Type";
			this._lblControl_10.ForeColor = System.Drawing.Color.Black;
			this._lblControl_10.Location = new System.Drawing.Point(8, 20);
			this._lblControl_10.Name = "_lblControl_10";
			this._lblControl_10.Size = new System.Drawing.Size(84, 13);
			this._lblControl_10.TabIndex = 81;
			// 
			// _lblControl_11
			// 
			this._lblControl_11.AllowDrop = true;
			this._lblControl_11.BackColor = System.Drawing.SystemColors.Window;
			this._lblControl_11.Text = "Opp. Ledger Code";
			this._lblControl_11.ForeColor = System.Drawing.Color.Black;
			this._lblControl_11.Location = new System.Drawing.Point(8, 42);
			this._lblControl_11.Name = "_lblControl_11";
			this._lblControl_11.Size = new System.Drawing.Size(88, 13);
			this._lblControl_11.TabIndex = 82;
			// 
			// _lblControl_12
			// 
			this._lblControl_12.AllowDrop = true;
			this._lblControl_12.BackColor = System.Drawing.SystemColors.Window;
			this._lblControl_12.Text = "Opp. Ledger Header Cap.";
			this._lblControl_12.ForeColor = System.Drawing.Color.Black;
			this._lblControl_12.Location = new System.Drawing.Point(8, 97);
			this._lblControl_12.Name = "_lblControl_12";
			this._lblControl_12.Size = new System.Drawing.Size(124, 13);
			this._lblControl_12.TabIndex = 83;
			// 
			// _lblControl_13
			// 
			this._lblControl_13.AllowDrop = true;
			this._lblControl_13.BackColor = System.Drawing.SystemColors.Window;
			this._lblControl_13.Text = "Opp. Ledger Code Cap.";
			this._lblControl_13.ForeColor = System.Drawing.Color.Black;
			this._lblControl_13.Location = new System.Drawing.Point(8, 118);
			this._lblControl_13.Name = "_lblControl_13";
			this._lblControl_13.Size = new System.Drawing.Size(114, 13);
			this._lblControl_13.TabIndex = 84;
			// 
			// _txtControl_58
			// 
			this._txtControl_58.AllowDrop = true;
			this._txtControl_58.BackColor = System.Drawing.Color.FromArgb(239, 239, 239);
			this._txtControl_58.Enabled = false;
			this._txtControl_58.ForeColor = System.Drawing.Color.Black;
			this._txtControl_58.Location = new System.Drawing.Point(240, 38);
			this._txtControl_58.Name = "_txtControl_58";
			this._txtControl_58.Size = new System.Drawing.Size(183, 19);
			this._txtControl_58.TabIndex = 85;
			this._txtControl_58.Text = "";
			// this.this._txtControl_58.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtControl_DropButtonClick);
			// this._txtControl_58.Leave += new System.EventHandler(this.txtControl_Leave);
			// 
			// _cmbControl_13
			// 
			this._cmbControl_13.AllowDrop = true;
			this._cmbControl_13.Location = new System.Drawing.Point(136, 16);
			this._cmbControl_13.Name = "_cmbControl_13";
			this._cmbControl_13.Size = new System.Drawing.Size(55, 21);
			this._cmbControl_13.TabIndex = 31;
			// 
			// _txtControl_16
			// 
			this._txtControl_16.AllowDrop = true;
			this._txtControl_16.BackColor = System.Drawing.Color.White;
			this._txtControl_16.ForeColor = System.Drawing.Color.Black;
			this._txtControl_16.Location = new System.Drawing.Point(136, 94);
			this._txtControl_16.MaxLength = 30;
			this._txtControl_16.Name = "_txtControl_16";
			this._txtControl_16.Size = new System.Drawing.Size(289, 19);
			this._txtControl_16.TabIndex = 34;
			this._txtControl_16.Text = "";
			// this.this._txtControl_16.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtControl_DropButtonClick);
			// this._txtControl_16.Leave += new System.EventHandler(this.txtControl_Leave);
			// 
			// _txtControl_17
			// 
			this._txtControl_17.AllowDrop = true;
			this._txtControl_17.BackColor = System.Drawing.Color.White;
			this._txtControl_17.ForeColor = System.Drawing.Color.Black;
			this._txtControl_17.Location = new System.Drawing.Point(136, 115);
			this._txtControl_17.MaxLength = 30;
			this._txtControl_17.Name = "_txtControl_17";
			this._txtControl_17.Size = new System.Drawing.Size(289, 19);
			this._txtControl_17.TabIndex = 35;
			this._txtControl_17.Text = "";
			// this.this._txtControl_17.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtControl_DropButtonClick);
			// this._txtControl_17.Leave += new System.EventHandler(this.txtControl_Leave);
			// 
			// _txtControl_14
			// 
			this._txtControl_14.AllowDrop = true;
			this._txtControl_14.BackColor = System.Drawing.Color.White;
			this._txtControl_14.ForeColor = System.Drawing.Color.Black;
			this._txtControl_14.Location = new System.Drawing.Point(136, 39);
			this._txtControl_14.MaxLength = 10;
			this._txtControl_14.Name = "_txtControl_14";
			// this._txtControl_14.ShowButton = true;
			this._txtControl_14.Size = new System.Drawing.Size(101, 19);
			this._txtControl_14.TabIndex = 32;
			this._txtControl_14.Text = "";
			// this.this._txtControl_14.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtControl_DropButtonClick);
			// this._txtControl_14.Leave += new System.EventHandler(this.txtControl_Leave);
			// 
			// _txtControl_18
			// 
			this._txtControl_18.AllowDrop = true;
			this._txtControl_18.BackColor = System.Drawing.Color.White;
			this._txtControl_18.ForeColor = System.Drawing.Color.Black;
			this._txtControl_18.Location = new System.Drawing.Point(136, 136);
			this._txtControl_18.MaxLength = 30;
			this._txtControl_18.Name = "_txtControl_18";
			this._txtControl_18.Size = new System.Drawing.Size(289, 19);
			this._txtControl_18.TabIndex = 36;
			this._txtControl_18.Text = "";
			// this.this._txtControl_18.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtControl_DropButtonClick);
			// this._txtControl_18.Leave += new System.EventHandler(this.txtControl_Leave);
			// 
			// _chkControl_36
			// 
			this._chkControl_36.AllowDrop = true;
			this._chkControl_36.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkControl_36.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._chkControl_36.CausesValidation = true;
			this._chkControl_36.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkControl_36.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkControl_36.Enabled = true;
			this._chkControl_36.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkControl_36.Location = new System.Drawing.Point(10, 230);
			this._chkControl_36.Name = "_chkControl_36";
			this._chkControl_36.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkControl_36.Size = new System.Drawing.Size(177, 17);
			this._chkControl_36.TabIndex = 39;
			this._chkControl_36.TabStop = true;
			this._chkControl_36.Text = "Auto Generate Voucher No";
			this._chkControl_36.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkControl_36.Visible = true;
			this._chkControl_36.CheckStateChanged += new System.EventHandler(this.chkControl_CheckStateChanged);
			// 
			// _chkControl_33
			// 
			this._chkControl_33.AllowDrop = true;
			this._chkControl_33.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkControl_33.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._chkControl_33.CausesValidation = true;
			this._chkControl_33.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkControl_33.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkControl_33.Enabled = true;
			this._chkControl_33.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkControl_33.Location = new System.Drawing.Point(10, 211);
			this._chkControl_33.Name = "_chkControl_33";
			this._chkControl_33.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkControl_33.Size = new System.Drawing.Size(153, 17);
			this._chkControl_33.TabIndex = 38;
			this._chkControl_33.TabStop = true;
			this._chkControl_33.Text = "Show Voucher Adjustment";
			this._chkControl_33.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkControl_33.Visible = true;
			this._chkControl_33.CheckStateChanged += new System.EventHandler(this.chkControl_CheckStateChanged);
			// 
			// _chkControl_4
			// 
			this._chkControl_4.AllowDrop = true;
			this._chkControl_4.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkControl_4.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._chkControl_4.CausesValidation = true;
			this._chkControl_4.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkControl_4.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkControl_4.Enabled = true;
			this._chkControl_4.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkControl_4.Location = new System.Drawing.Point(10, 192);
			this._chkControl_4.Name = "_chkControl_4";
			this._chkControl_4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkControl_4.Size = new System.Drawing.Size(135, 17);
			this._chkControl_4.TabIndex = 37;
			this._chkControl_4.TabStop = true;
			this._chkControl_4.Text = "Opening Voucher Type";
			this._chkControl_4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkControl_4.Visible = true;
			this._chkControl_4.CheckStateChanged += new System.EventHandler(this.chkControl_CheckStateChanged);
			// 
			// _lblControl_15
			// 
			this._lblControl_15.AllowDrop = true;
			this._lblControl_15.BackColor = System.Drawing.SystemColors.Window;
			this._lblControl_15.Text = "Default Dr/Cr Type";
			this._lblControl_15.ForeColor = System.Drawing.Color.Black;
			this._lblControl_15.Location = new System.Drawing.Point(282, 194);
			this._lblControl_15.Name = "_lblControl_15";
			this._lblControl_15.Size = new System.Drawing.Size(91, 13);
			this._lblControl_15.TabIndex = 90;
			// 
			// _cmbControl_20
			// 
			this._cmbControl_20.AllowDrop = true;
			this._cmbControl_20.Location = new System.Drawing.Point(386, 190);
			this._cmbControl_20.Name = "_cmbControl_20";
			this._cmbControl_20.Size = new System.Drawing.Size(55, 21);
			this._cmbControl_20.TabIndex = 40;
			// 
			// _lblControl_2
			// 
			this._lblControl_2.AllowDrop = true;
			this._lblControl_2.BackColor = System.Drawing.SystemColors.Window;
			this._lblControl_2.Text = "Voucher No Length";
			this._lblControl_2.ForeColor = System.Drawing.Color.Black;
			this._lblControl_2.Location = new System.Drawing.Point(14, 278);
			this._lblControl_2.Name = "_lblControl_2";
			this._lblControl_2.Size = new System.Drawing.Size(91, 13);
			this._lblControl_2.TabIndex = 115;
			// 
			// _cmbControl_0
			// 
			this._cmbControl_0.AllowDrop = true;
			this._cmbControl_0.Location = new System.Drawing.Point(142, 248);
			this._cmbControl_0.Name = "_cmbControl_0";
			this._cmbControl_0.Size = new System.Drawing.Size(101, 21);
			this._cmbControl_0.TabIndex = 116;
			// 
			// _lblControl_22
			// 
			this._lblControl_22.AllowDrop = true;
			this._lblControl_22.BackColor = System.Drawing.SystemColors.Window;
			this._lblControl_22.Text = "Voucher No  Method";
			this._lblControl_22.ForeColor = System.Drawing.Color.Black;
			this._lblControl_22.Location = new System.Drawing.Point(14, 250);
			this._lblControl_22.Name = "_lblControl_22";
			this._lblControl_22.Size = new System.Drawing.Size(97, 13);
			this._lblControl_22.TabIndex = 117;
			// 
			// Frame1
			// 
			this.Frame1.AllowDrop = true;
			this.Frame1.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this.Frame1.Controls.Add(this._chkControl_46);
			this.Frame1.Controls.Add(this._chkControl_47);
			this.Frame1.Controls.Add(this._chkControl_48);
			this.Frame1.Controls.Add(this._lblControl_0);
			this.Frame1.Controls.Add(this._txtControl_1);
			this.Frame1.Controls.Add(this._txtControl_7);
			this.Frame1.Controls.Add(this._txtControl_8);
			this.Frame1.Controls.Add(this._txtControl_9);
			this.Frame1.Controls.Add(this._lblControl_3);
			this.Frame1.Controls.Add(this._lblControl_4);
			this.Frame1.Controls.Add(this._lblControl_5);
			this.Frame1.Controls.Add(this._lblControl_6);
			this.Frame1.Controls.Add(this._lblControl_7);
			this.Frame1.Controls.Add(this._lblControl_16);
			this.Frame1.Controls.Add(this._lblControl_17);
			this.Frame1.Controls.Add(this._lblControl_18);
			this.Frame1.Controls.Add(this._lblControl_19);
			this.Frame1.Controls.Add(this._lblControl_20);
			this.Frame1.Controls.Add(this._txtControl_45);
			this.Frame1.Controls.Add(this._txtControl_42);
			this.Frame1.Controls.Add(this._txtControl_43);
			this.Frame1.Controls.Add(this._txtControl_44);
			this.Frame1.Controls.Add(this._txtControl_49);
			this.Frame1.Controls.Add(this._txtControl_52);
			this.Frame1.Controls.Add(this._txtControl_53);
			this.Frame1.Controls.Add(this._txtControl_54);
			this.Frame1.Controls.Add(this._txtControl_55);
			this.Frame1.Controls.Add(this._txtControl_56);
			this.Frame1.Controls.Add(this._txtControl_3);
			this.Frame1.Controls.Add(this._txtControl_6);
			this.Frame1.Controls.Add(this._lblControl_21);
			this.Frame1.Controls.Add(this._txtControl_21);
			this.Frame1.Controls.Add(this._txtControl_23);
			this.Frame1.Enabled = true;
			this.Frame1.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Frame1.Location = new System.Drawing.Point(3, 23);
			this.Frame1.Name = "Frame1";
			this.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Frame1.Size = new System.Drawing.Size(455, 321);
			this.Frame1.TabIndex = 65;
			this.Frame1.Visible = true;
			// 
			// _chkControl_46
			// 
			this._chkControl_46.AllowDrop = true;
			this._chkControl_46.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkControl_46.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._chkControl_46.CausesValidation = true;
			this._chkControl_46.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkControl_46.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkControl_46.Enabled = false;
			this._chkControl_46.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkControl_46.Location = new System.Drawing.Point(132, 278);
			this._chkControl_46.Name = "_chkControl_46";
			this._chkControl_46.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkControl_46.Size = new System.Drawing.Size(49, 17);
			this._chkControl_46.TabIndex = 21;
			this._chkControl_46.TabStop = true;
			this._chkControl_46.Text = "Used";
			this._chkControl_46.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkControl_46.Visible = true;
			this._chkControl_46.CheckStateChanged += new System.EventHandler(this.chkControl_CheckStateChanged);
			// 
			// _chkControl_47
			// 
			this._chkControl_47.AllowDrop = true;
			this._chkControl_47.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkControl_47.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._chkControl_47.CausesValidation = true;
			this._chkControl_47.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkControl_47.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkControl_47.Enabled = true;
			this._chkControl_47.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkControl_47.Location = new System.Drawing.Point(188, 278);
			this._chkControl_47.Name = "_chkControl_47";
			this._chkControl_47.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkControl_47.Size = new System.Drawing.Size(53, 17);
			this._chkControl_47.TabIndex = 22;
			this._chkControl_47.TabStop = true;
			this._chkControl_47.Text = "Show";
			this._chkControl_47.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkControl_47.Visible = true;
			this._chkControl_47.CheckStateChanged += new System.EventHandler(this.chkControl_CheckStateChanged);
			// 
			// _chkControl_48
			// 
			this._chkControl_48.AllowDrop = true;
			this._chkControl_48.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkControl_48.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._chkControl_48.CausesValidation = true;
			this._chkControl_48.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkControl_48.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkControl_48.Enabled = true;
			this._chkControl_48.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkControl_48.Location = new System.Drawing.Point(240, 278);
			this._chkControl_48.Name = "_chkControl_48";
			this._chkControl_48.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkControl_48.Size = new System.Drawing.Size(71, 17);
			this._chkControl_48.TabIndex = 23;
			this._chkControl_48.TabStop = true;
			this._chkControl_48.Text = "Protected";
			this._chkControl_48.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkControl_48.Visible = true;
			this._chkControl_48.CheckStateChanged += new System.EventHandler(this.chkControl_CheckStateChanged);
			// 
			// _lblControl_0
			// 
			this._lblControl_0.AllowDrop = true;
			this._lblControl_0.BackColor = System.Drawing.SystemColors.Window;
			this._lblControl_0.Text = "Voucher Type";
			this._lblControl_0.ForeColor = System.Drawing.Color.Black;
			this._lblControl_0.Location = new System.Drawing.Point(10, 25);
			this._lblControl_0.Name = "_lblControl_0";
			this._lblControl_0.Size = new System.Drawing.Size(66, 13);
			this._lblControl_0.TabIndex = 68;
			// 
			// _txtControl_1
			// 
			this._txtControl_1.AllowDrop = true;
			this._txtControl_1.BackColor = System.Drawing.Color.White;
			this._txtControl_1.ForeColor = System.Drawing.Color.Black;
			this._txtControl_1.Location = new System.Drawing.Point(132, 22);
			this._txtControl_1.MaxLength = 3;
			this._txtControl_1.Name = "_txtControl_1";
			this._txtControl_1.Size = new System.Drawing.Size(93, 19);
			this._txtControl_1.TabIndex = 9;
			this._txtControl_1.Text = "";
			// this.this._txtControl_1.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtControl_DropButtonClick);
			// this._txtControl_1.Leave += new System.EventHandler(this.txtControl_Leave);
			// 
			// _txtControl_7
			// 
			this._txtControl_7.AllowDrop = true;
			this._txtControl_7.BackColor = System.Drawing.Color.White;
			this._txtControl_7.ForeColor = System.Drawing.Color.Black;
			this._txtControl_7.Location = new System.Drawing.Point(132, 106);
			this._txtControl_7.MaxLength = 50;
			this._txtControl_7.Name = "_txtControl_7";
			this._txtControl_7.Size = new System.Drawing.Size(290, 19);
			this._txtControl_7.TabIndex = 13;
			this._txtControl_7.Text = "";
			// this.this._txtControl_7.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtControl_DropButtonClick);
			// this._txtControl_7.Leave += new System.EventHandler(this.txtControl_Leave);
			// 
			// _txtControl_8
			// 
			this._txtControl_8.AllowDrop = true;
			this._txtControl_8.BackColor = System.Drawing.Color.White;
			this._txtControl_8.ForeColor = System.Drawing.Color.Black;
			this._txtControl_8.Location = new System.Drawing.Point(132, 127);
			this._txtControl_8.MaxLength = 4;
			this._txtControl_8.Name = "_txtControl_8";
			this._txtControl_8.Size = new System.Drawing.Size(93, 19);
			this._txtControl_8.TabIndex = 14;
			this._txtControl_8.Text = "";
			// this.this._txtControl_8.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtControl_DropButtonClick);
			// this._txtControl_8.Leave += new System.EventHandler(this.txtControl_Leave);
			// 
			// _txtControl_9
			// 
			this._txtControl_9.AllowDrop = true;
			this._txtControl_9.BackColor = System.Drawing.Color.White;
			this._txtControl_9.ForeColor = System.Drawing.Color.Black;
			this._txtControl_9.Location = new System.Drawing.Point(132, 148);
			// this._txtControl_9.mArabicEnabled = true;
			this._txtControl_9.MaxLength = 4;
			this._txtControl_9.Name = "_txtControl_9";
			this._txtControl_9.Size = new System.Drawing.Size(93, 19);
			this._txtControl_9.TabIndex = 15;
			this._txtControl_9.Text = "";
			// this.this._txtControl_9.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtControl_DropButtonClick);
			// this._txtControl_9.Leave += new System.EventHandler(this.txtControl_Leave);
			// 
			// _lblControl_3
			// 
			this._lblControl_3.AllowDrop = true;
			this._lblControl_3.BackColor = System.Drawing.SystemColors.Window;
			this._lblControl_3.Text = "Module ID";
			this._lblControl_3.ForeColor = System.Drawing.Color.Black;
			this._lblControl_3.Location = new System.Drawing.Point(10, 45);
			this._lblControl_3.Name = "_lblControl_3";
			this._lblControl_3.Size = new System.Drawing.Size(48, 13);
			this._lblControl_3.TabIndex = 69;
			// 
			// _lblControl_4
			// 
			this._lblControl_4.AllowDrop = true;
			this._lblControl_4.BackColor = System.Drawing.SystemColors.Window;
			this._lblControl_4.Text = "Voucher Name(English)";
			this._lblControl_4.ForeColor = System.Drawing.Color.Black;
			this._lblControl_4.Location = new System.Drawing.Point(10, 88);
			this._lblControl_4.Name = "_lblControl_4";
			this._lblControl_4.Size = new System.Drawing.Size(110, 13);
			this._lblControl_4.TabIndex = 70;
			// 
			// _lblControl_5
			// 
			this._lblControl_5.AllowDrop = true;
			this._lblControl_5.BackColor = System.Drawing.SystemColors.Window;
			this._lblControl_5.Text = "Voucher Name(Arabic)";
			this._lblControl_5.ForeColor = System.Drawing.Color.Black;
			this._lblControl_5.Location = new System.Drawing.Point(10, 109);
			this._lblControl_5.Name = "_lblControl_5";
			this._lblControl_5.Size = new System.Drawing.Size(107, 13);
			this._lblControl_5.TabIndex = 71;
			// 
			// _lblControl_6
			// 
			this._lblControl_6.AllowDrop = true;
			this._lblControl_6.BackColor = System.Drawing.SystemColors.Window;
			this._lblControl_6.Text = "Short Name(English)";
			this._lblControl_6.ForeColor = System.Drawing.Color.Black;
			this._lblControl_6.Location = new System.Drawing.Point(10, 130);
			this._lblControl_6.Name = "_lblControl_6";
			this._lblControl_6.Size = new System.Drawing.Size(97, 13);
			this._lblControl_6.TabIndex = 72;
			// 
			// _lblControl_7
			// 
			this._lblControl_7.AllowDrop = true;
			this._lblControl_7.BackColor = System.Drawing.SystemColors.Window;
			this._lblControl_7.Text = "Short Name(Arabic)";
			this._lblControl_7.ForeColor = System.Drawing.Color.Black;
			this._lblControl_7.Location = new System.Drawing.Point(10, 151);
			this._lblControl_7.Name = "_lblControl_7";
			this._lblControl_7.Size = new System.Drawing.Size(94, 13);
			this._lblControl_7.TabIndex = 73;
			// 
			// _lblControl_16
			// 
			this._lblControl_16.AllowDrop = true;
			this._lblControl_16.BackColor = System.Drawing.SystemColors.Window;
			this._lblControl_16.Text = "Last Debit Ledger Code";
			this._lblControl_16.ForeColor = System.Drawing.Color.Black;
			this._lblControl_16.Location = new System.Drawing.Point(10, 172);
			this._lblControl_16.Name = "_lblControl_16";
			this._lblControl_16.Size = new System.Drawing.Size(112, 13);
			this._lblControl_16.TabIndex = 74;
			// 
			// _lblControl_17
			// 
			this._lblControl_17.AllowDrop = true;
			this._lblControl_17.BackColor = System.Drawing.SystemColors.Window;
			this._lblControl_17.Text = "Last Credit Ledger Code";
			this._lblControl_17.ForeColor = System.Drawing.Color.Black;
			this._lblControl_17.Location = new System.Drawing.Point(10, 193);
			this._lblControl_17.Name = "_lblControl_17";
			this._lblControl_17.Size = new System.Drawing.Size(116, 13);
			this._lblControl_17.TabIndex = 75;
			// 
			// _lblControl_18
			// 
			this._lblControl_18.AllowDrop = true;
			this._lblControl_18.BackColor = System.Drawing.SystemColors.Window;
			this._lblControl_18.Text = "Last Cost Center Code";
			this._lblControl_18.ForeColor = System.Drawing.Color.Black;
			this._lblControl_18.Location = new System.Drawing.Point(10, 214);
			this._lblControl_18.Name = "_lblControl_18";
			this._lblControl_18.Size = new System.Drawing.Size(109, 13);
			this._lblControl_18.TabIndex = 76;
			// 
			// _lblControl_19
			// 
			this._lblControl_19.AllowDrop = true;
			this._lblControl_19.BackColor = System.Drawing.SystemColors.Window;
			this._lblControl_19.Text = "Last Salesman Code";
			this._lblControl_19.ForeColor = System.Drawing.Color.Black;
			this._lblControl_19.Location = new System.Drawing.Point(10, 235);
			this._lblControl_19.Name = "_lblControl_19";
			this._lblControl_19.Size = new System.Drawing.Size(96, 13);
			this._lblControl_19.TabIndex = 77;
			// 
			// _lblControl_20
			// 
			this._lblControl_20.AllowDrop = true;
			this._lblControl_20.BackColor = System.Drawing.SystemColors.Window;
			this._lblControl_20.Text = "Comments";
			this._lblControl_20.ForeColor = System.Drawing.Color.Black;
			this._lblControl_20.Location = new System.Drawing.Point(10, 256);
			this._lblControl_20.Name = "_lblControl_20";
			this._lblControl_20.Size = new System.Drawing.Size(50, 13);
			this._lblControl_20.TabIndex = 78;
			// 
			// _txtControl_45
			// 
			this._txtControl_45.AllowDrop = true;
			this._txtControl_45.BackColor = System.Drawing.Color.FromArgb(239, 239, 239);
			// this._txtControl_45.bolAllowDecimal = false;
			// this._txtControl_45.bolNumericOnly = true;
			this._txtControl_45.Enabled = false;
			this._txtControl_45.ForeColor = System.Drawing.Color.Black;
			this._txtControl_45.Location = new System.Drawing.Point(132, 232);
			this._txtControl_45.MaxLength = 3;
			this._txtControl_45.Name = "_txtControl_45";
			this._txtControl_45.Size = new System.Drawing.Size(93, 19);
			this._txtControl_45.TabIndex = 19;
			this._txtControl_45.Text = "";
			// this.this._txtControl_45.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtControl_DropButtonClick);
			// this._txtControl_45.Leave += new System.EventHandler(this.txtControl_Leave);
			// 
			// _txtControl_42
			// 
			this._txtControl_42.AllowDrop = true;
			this._txtControl_42.BackColor = System.Drawing.Color.FromArgb(239, 239, 239);
			this._txtControl_42.Enabled = false;
			this._txtControl_42.ForeColor = System.Drawing.Color.Black;
			this._txtControl_42.Location = new System.Drawing.Point(132, 169);
			this._txtControl_42.MaxLength = 10;
			this._txtControl_42.Name = "_txtControl_42";
			this._txtControl_42.Size = new System.Drawing.Size(93, 19);
			this._txtControl_42.TabIndex = 16;
			this._txtControl_42.Text = "";
			// this.this._txtControl_42.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtControl_DropButtonClick);
			// this._txtControl_42.Leave += new System.EventHandler(this.txtControl_Leave);
			// 
			// _txtControl_43
			// 
			this._txtControl_43.AllowDrop = true;
			this._txtControl_43.BackColor = System.Drawing.Color.FromArgb(239, 239, 239);
			this._txtControl_43.Enabled = false;
			this._txtControl_43.ForeColor = System.Drawing.Color.Black;
			this._txtControl_43.Location = new System.Drawing.Point(132, 190);
			this._txtControl_43.MaxLength = 10;
			this._txtControl_43.Name = "_txtControl_43";
			this._txtControl_43.Size = new System.Drawing.Size(93, 19);
			this._txtControl_43.TabIndex = 17;
			this._txtControl_43.Text = "";
			// this.this._txtControl_43.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtControl_DropButtonClick);
			// this._txtControl_43.Leave += new System.EventHandler(this.txtControl_Leave);
			// 
			// _txtControl_44
			// 
			this._txtControl_44.AllowDrop = true;
			this._txtControl_44.BackColor = System.Drawing.Color.FromArgb(239, 239, 239);
			// this._txtControl_44.bolAllowDecimal = false;
			// this._txtControl_44.bolNumericOnly = true;
			this._txtControl_44.Enabled = false;
			this._txtControl_44.ForeColor = System.Drawing.Color.Black;
			this._txtControl_44.Location = new System.Drawing.Point(132, 211);
			this._txtControl_44.MaxLength = 4;
			this._txtControl_44.Name = "_txtControl_44";
			this._txtControl_44.Size = new System.Drawing.Size(93, 19);
			this._txtControl_44.TabIndex = 18;
			this._txtControl_44.Text = "";
			// this.this._txtControl_44.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtControl_DropButtonClick);
			// this._txtControl_44.Leave += new System.EventHandler(this.txtControl_Leave);
			// 
			// _txtControl_49
			// 
			this._txtControl_49.AllowDrop = true;
			this._txtControl_49.BackColor = System.Drawing.Color.White;
			this._txtControl_49.ForeColor = System.Drawing.Color.Black;
			this._txtControl_49.Location = new System.Drawing.Point(132, 253);
			this._txtControl_49.MaxLength = 50;
			this._txtControl_49.Name = "_txtControl_49";
			this._txtControl_49.Size = new System.Drawing.Size(290, 19);
			this._txtControl_49.TabIndex = 20;
			this._txtControl_49.Text = "";
			// this.this._txtControl_49.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtControl_DropButtonClick);
			// this._txtControl_49.Leave += new System.EventHandler(this.txtControl_Leave);
			// 
			// _txtControl_52
			// 
			this._txtControl_52.AllowDrop = true;
			this._txtControl_52.BackColor = System.Drawing.Color.FromArgb(239, 239, 239);
			this._txtControl_52.Enabled = false;
			this._txtControl_52.ForeColor = System.Drawing.Color.Black;
			this._txtControl_52.Location = new System.Drawing.Point(227, 43);
			this._txtControl_52.Name = "_txtControl_52";
			this._txtControl_52.Size = new System.Drawing.Size(195, 19);
			this._txtControl_52.TabIndex = 113;
			this._txtControl_52.Text = "";
			// this.this._txtControl_52.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtControl_DropButtonClick);
			// this._txtControl_52.Leave += new System.EventHandler(this.txtControl_Leave);
			// 
			// _txtControl_53
			// 
			this._txtControl_53.AllowDrop = true;
			this._txtControl_53.BackColor = System.Drawing.Color.FromArgb(239, 239, 239);
			this._txtControl_53.Enabled = false;
			this._txtControl_53.ForeColor = System.Drawing.Color.Black;
			this._txtControl_53.Location = new System.Drawing.Point(227, 169);
			this._txtControl_53.Name = "_txtControl_53";
			this._txtControl_53.Size = new System.Drawing.Size(195, 19);
			this._txtControl_53.TabIndex = 111;
			this._txtControl_53.Text = "";
			// this.this._txtControl_53.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtControl_DropButtonClick);
			// this._txtControl_53.Leave += new System.EventHandler(this.txtControl_Leave);
			// 
			// _txtControl_54
			// 
			this._txtControl_54.AllowDrop = true;
			this._txtControl_54.BackColor = System.Drawing.Color.FromArgb(239, 239, 239);
			this._txtControl_54.Enabled = false;
			this._txtControl_54.ForeColor = System.Drawing.Color.Black;
			this._txtControl_54.Location = new System.Drawing.Point(227, 190);
			this._txtControl_54.Name = "_txtControl_54";
			this._txtControl_54.Size = new System.Drawing.Size(195, 19);
			this._txtControl_54.TabIndex = 110;
			this._txtControl_54.Text = "";
			// this.this._txtControl_54.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtControl_DropButtonClick);
			// this._txtControl_54.Leave += new System.EventHandler(this.txtControl_Leave);
			// 
			// _txtControl_55
			// 
			this._txtControl_55.AllowDrop = true;
			this._txtControl_55.BackColor = System.Drawing.Color.FromArgb(239, 239, 239);
			this._txtControl_55.Enabled = false;
			this._txtControl_55.ForeColor = System.Drawing.Color.Black;
			this._txtControl_55.Location = new System.Drawing.Point(227, 211);
			this._txtControl_55.Name = "_txtControl_55";
			this._txtControl_55.Size = new System.Drawing.Size(195, 19);
			this._txtControl_55.TabIndex = 109;
			this._txtControl_55.Text = "";
			// this.this._txtControl_55.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtControl_DropButtonClick);
			// this._txtControl_55.Leave += new System.EventHandler(this.txtControl_Leave);
			// 
			// _txtControl_56
			// 
			this._txtControl_56.AllowDrop = true;
			this._txtControl_56.BackColor = System.Drawing.Color.FromArgb(239, 239, 239);
			this._txtControl_56.Enabled = false;
			this._txtControl_56.ForeColor = System.Drawing.Color.Black;
			this._txtControl_56.Location = new System.Drawing.Point(227, 232);
			this._txtControl_56.Name = "_txtControl_56";
			this._txtControl_56.Size = new System.Drawing.Size(195, 19);
			this._txtControl_56.TabIndex = 108;
			this._txtControl_56.Text = "";
			// this.this._txtControl_56.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtControl_DropButtonClick);
			// this._txtControl_56.Leave += new System.EventHandler(this.txtControl_Leave);
			// 
			// _txtControl_3
			// 
			this._txtControl_3.AllowDrop = true;
			this._txtControl_3.BackColor = System.Drawing.Color.White;
			// this._txtControl_3.bolAllowDecimal = false;
			// this._txtControl_3.bolNumericOnly = true;
			this._txtControl_3.ForeColor = System.Drawing.Color.Black;
			this._txtControl_3.Location = new System.Drawing.Point(132, 43);
			this._txtControl_3.MaxLength = 3;
			this._txtControl_3.Name = "_txtControl_3";
			// this._txtControl_3.ShowButton = true;
			this._txtControl_3.Size = new System.Drawing.Size(93, 19);
			this._txtControl_3.TabIndex = 10;
			this._txtControl_3.Text = "";
			// this.this._txtControl_3.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtControl_DropButtonClick);
			// this._txtControl_3.Leave += new System.EventHandler(this.txtControl_Leave);
			// 
			// _txtControl_6
			// 
			this._txtControl_6.AllowDrop = true;
			this._txtControl_6.BackColor = System.Drawing.Color.White;
			this._txtControl_6.ForeColor = System.Drawing.Color.Black;
			this._txtControl_6.Location = new System.Drawing.Point(132, 85);
			this._txtControl_6.MaxLength = 50;
			this._txtControl_6.Name = "_txtControl_6";
			this._txtControl_6.Size = new System.Drawing.Size(290, 19);
			this._txtControl_6.TabIndex = 12;
			this._txtControl_6.Text = "";
			// this.this._txtControl_6.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtControl_DropButtonClick);
			// this._txtControl_6.Leave += new System.EventHandler(this.txtControl_Leave);
			// 
			// _lblControl_21
			// 
			this._lblControl_21.AllowDrop = true;
			this._lblControl_21.BackColor = System.Drawing.SystemColors.Window;
			this._lblControl_21.Text = "Preference ID";
			this._lblControl_21.ForeColor = System.Drawing.Color.Black;
			this._lblControl_21.Location = new System.Drawing.Point(10, 67);
			this._lblControl_21.Name = "_lblControl_21";
			this._lblControl_21.Size = new System.Drawing.Size(67, 13);
			this._lblControl_21.TabIndex = 107;
			// 
			// _txtControl_21
			// 
			this._txtControl_21.AllowDrop = true;
			this._txtControl_21.BackColor = System.Drawing.Color.FromArgb(239, 239, 239);
			this._txtControl_21.Enabled = false;
			this._txtControl_21.ForeColor = System.Drawing.Color.Black;
			this._txtControl_21.Location = new System.Drawing.Point(227, 64);
			this._txtControl_21.Name = "_txtControl_21";
			this._txtControl_21.Size = new System.Drawing.Size(195, 19);
			this._txtControl_21.TabIndex = 112;
			this._txtControl_21.Text = "";
			// this.this._txtControl_21.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtControl_DropButtonClick);
			// this._txtControl_21.Leave += new System.EventHandler(this.txtControl_Leave);
			// 
			// _txtControl_23
			// 
			this._txtControl_23.AllowDrop = true;
			this._txtControl_23.BackColor = System.Drawing.Color.White;
			// this._txtControl_23.bolAllowDecimal = false;
			// this._txtControl_23.bolNumericOnly = true;
			this._txtControl_23.ForeColor = System.Drawing.Color.Black;
			this._txtControl_23.Location = new System.Drawing.Point(132, 64);
			this._txtControl_23.MaxLength = 3;
			this._txtControl_23.Name = "_txtControl_23";
			// this._txtControl_23.ShowButton = true;
			this._txtControl_23.Size = new System.Drawing.Size(93, 19);
			this._txtControl_23.TabIndex = 11;
			this._txtControl_23.Text = "";
			// this.this._txtControl_23.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtControl_DropButtonClick);
			// this._txtControl_23.Leave += new System.EventHandler(this.txtControl_Leave);
			// 
			// frmGLVoucherTypes
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.ClientSize = new System.Drawing.Size(501, 408);
			this.Controls.Add(this.tabGLVoucherType);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			//this.Icon = (System.Drawing.Icon) resources.GetObject("frmGLVoucherTypes.Icon");
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(289, 179);
			this.MaximizeBox = true;
			this.MinimizeBox = true;
			this.Name = "frmGLVoucherTypes";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "GL Voucher Types";
			// this.Activated += new System.EventHandler(this.frmGLVoucherTypes_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
			// this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
			//((System.ComponentModel.ISupportInitialize) this.tabGLVoucherType).EndInit();
			this.tabGLVoucherType.ResumeLayout(false);
			this.Frame6.ResumeLayout(false);
			this.Frame8.ResumeLayout(false);
			this.Frame7.ResumeLayout(false);
			this.cmbPrintList.ResumeLayout(false);
			this.grdPrintTask.ResumeLayout(false);
			this.Frame5.ResumeLayout(false);
			this.Frame3.ResumeLayout(false);
			this.Frame2.ResumeLayout(false);
			this.Frame4.ResumeLayout(false);
			this.Frame1.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		void ReLoadForm(bool addEvents)
		{
			InitializetxtMultiLineControl();
			InitializetxtControl();
			InitializetxtCommon();
			InitializeoptCommonQtyEffect();
			InitializeoptCommonAffectType();
			InitializelblControl();
			InitializelblCommon();
			InitializecmbControl();
			InitializechkControl();
			//This form is an MDI child.
			//This code simulates the VB6 
			// functionality of automatically
			// loading and showing an MDI
			// child's parent.
			this.MdiParent = Xtreme.frmSysMain.DefInstance;
			Xtreme.frmSysMain.DefInstance.Show();
		}
		void InitializetxtMultiLineControl()
		{
			this.txtMultiLineControl = new System.Windows.Forms.TextBox[12];
			this.txtMultiLineControl[11] = _txtMultiLineControl_11;
			this.txtMultiLineControl[10] = _txtMultiLineControl_10;
		}
		void InitializetxtControl()
		{
			this.txtControl = new System.Windows.Forms.TextBox[59];
			this.txtControl[15] = _txtControl_15;
			this.txtControl[19] = _txtControl_19;
			this.txtControl[22] = _txtControl_22;
			this.txtControl[2] = _txtControl_2;
			this.txtControl[4] = _txtControl_4;
			this.txtControl[5] = _txtControl_5;
			this.txtControl[10] = _txtControl_10;
			this.txtControl[11] = _txtControl_11;
			this.txtControl[12] = _txtControl_12;
			this.txtControl[13] = _txtControl_13;
			this.txtControl[51] = _txtControl_51;
			this.txtControl[58] = _txtControl_58;
			this.txtControl[16] = _txtControl_16;
			this.txtControl[17] = _txtControl_17;
			this.txtControl[14] = _txtControl_14;
			this.txtControl[18] = _txtControl_18;
			this.txtControl[1] = _txtControl_1;
			this.txtControl[7] = _txtControl_7;
			this.txtControl[8] = _txtControl_8;
			this.txtControl[9] = _txtControl_9;
			this.txtControl[45] = _txtControl_45;
			this.txtControl[42] = _txtControl_42;
			this.txtControl[43] = _txtControl_43;
			this.txtControl[44] = _txtControl_44;
			this.txtControl[49] = _txtControl_49;
			this.txtControl[52] = _txtControl_52;
			this.txtControl[53] = _txtControl_53;
			this.txtControl[54] = _txtControl_54;
			this.txtControl[55] = _txtControl_55;
			this.txtControl[56] = _txtControl_56;
			this.txtControl[3] = _txtControl_3;
			this.txtControl[6] = _txtControl_6;
			this.txtControl[21] = _txtControl_21;
			this.txtControl[23] = _txtControl_23;
		}
		void InitializetxtCommon()
		{
			this.txtCommon = new System.Windows.Forms.TextBox[13];
			this.txtCommon[12] = _txtCommon_12;
		}
		void InitializeoptCommonQtyEffect()
		{
			this.optCommonQtyEffect = new System.Windows.Forms.RadioButton[4];
			this.optCommonQtyEffect[2] = _optCommonQtyEffect_2;
			this.optCommonQtyEffect[3] = _optCommonQtyEffect_3;
		}
		void InitializeoptCommonAffectType()
		{
			this.optCommonAffectType = new System.Windows.Forms.RadioButton[3];
			this.optCommonAffectType[1] = _optCommonAffectType_1;
			this.optCommonAffectType[2] = _optCommonAffectType_2;
		}
		void InitializelblControl()
		{
			this.lblControl = new System.Windows.Forms.Label[23];
			this.lblControl[8] = _lblControl_8;
			this.lblControl[9] = _lblControl_9;
			this.lblControl[14] = _lblControl_14;
			this.lblControl[1] = _lblControl_1;
			this.lblControl[10] = _lblControl_10;
			this.lblControl[11] = _lblControl_11;
			this.lblControl[12] = _lblControl_12;
			this.lblControl[13] = _lblControl_13;
			this.lblControl[15] = _lblControl_15;
			this.lblControl[2] = _lblControl_2;
			this.lblControl[22] = _lblControl_22;
			this.lblControl[0] = _lblControl_0;
			this.lblControl[3] = _lblControl_3;
			this.lblControl[4] = _lblControl_4;
			this.lblControl[5] = _lblControl_5;
			this.lblControl[6] = _lblControl_6;
			this.lblControl[7] = _lblControl_7;
			this.lblControl[16] = _lblControl_16;
			this.lblControl[17] = _lblControl_17;
			this.lblControl[18] = _lblControl_18;
			this.lblControl[19] = _lblControl_19;
			this.lblControl[20] = _lblControl_20;
			this.lblControl[21] = _lblControl_21;
		}
		void InitializelblCommon()
		{
			this.lblCommon = new System.Windows.Forms.Label[15];
			this.lblCommon[2] = _lblCommon_2;
			this.lblCommon[12] = _lblCommon_12;
			this.lblCommon[13] = _lblCommon_13;
			this.lblCommon[14] = _lblCommon_14;
			this.lblCommon[0] = _lblCommon_0;
			this.lblCommon[1] = _lblCommon_1;
		}
		void InitializecmbControl()
		{
			this.cmbControl = new System.Windows.Forms.ComboBox[21];
			this.cmbControl[13] = _cmbControl_13;
			this.cmbControl[20] = _cmbControl_20;
			this.cmbControl[0] = _cmbControl_0;
		}
		void InitializechkControl()
		{
			this.chkControl = new System.Windows.Forms.CheckBox[49];
			this.chkControl[13] = _chkControl_13;
			this.chkControl[11] = _chkControl_11;
			this.chkControl[10] = _chkControl_10;
			this.chkControl[9] = _chkControl_9;
			this.chkControl[8] = _chkControl_8;
			this.chkControl[0] = _chkControl_0;
			this.chkControl[18] = _chkControl_18;
			this.chkControl[1] = _chkControl_1;
			this.chkControl[7] = _chkControl_7;
			this.chkControl[2] = _chkControl_2;
			this.chkControl[3] = _chkControl_3;
			this.chkControl[5] = _chkControl_5;
			this.chkControl[6] = _chkControl_6;
			this.chkControl[28] = _chkControl_28;
			this.chkControl[19] = _chkControl_19;
			this.chkControl[21] = _chkControl_21;
			this.chkControl[22] = _chkControl_22;
			this.chkControl[23] = _chkControl_23;
			this.chkControl[24] = _chkControl_24;
			this.chkControl[25] = _chkControl_25;
			this.chkControl[26] = _chkControl_26;
			this.chkControl[27] = _chkControl_27;
			this.chkControl[29] = _chkControl_29;
			this.chkControl[30] = _chkControl_30;
			this.chkControl[31] = _chkControl_31;
			this.chkControl[32] = _chkControl_32;
			this.chkControl[34] = _chkControl_34;
			this.chkControl[35] = _chkControl_35;
			this.chkControl[37] = _chkControl_37;
			this.chkControl[39] = _chkControl_39;
			this.chkControl[40] = _chkControl_40;
			this.chkControl[41] = _chkControl_41;
			this.chkControl[38] = _chkControl_38;
			this.chkControl[12] = _chkControl_12;
			this.chkControl[15] = _chkControl_15;
			this.chkControl[36] = _chkControl_36;
			this.chkControl[33] = _chkControl_33;
			this.chkControl[4] = _chkControl_4;
			this.chkControl[46] = _chkControl_46;
			this.chkControl[47] = _chkControl_47;
			this.chkControl[48] = _chkControl_48;
		}
		#endregion
	}
}