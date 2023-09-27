
namespace Xtreme
{
	partial class frmSysBarcode
	{

		#region "Upgrade Support "
		private static frmSysBarcode m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmSysBarcode DefInstance
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
		public static frmSysBarcode CreateInstance()
		{
			frmSysBarcode theInstance = new frmSysBarcode();
			
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
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "Column_0_grdVoucherDetails", "Column_1_grdVoucherDetails", "grdVoucherDetails", "_cmbFields_3", "_lblCommon_7", "_cmbFields_2", "_cmbFields_1", "_lblCommon_6", "_lblCommon_5", "_lblCommon_4", "_cmbFields_0", "_Frame_1", "cmbReport", "chkPreview", "cmdSaveSetting", "cmbPrinter", "_txtCommon_0", "Label1_0", "Label1_2", "_txtCommon_10", "_txtFlex_1", "Label1_1", "Label_3", "_txtFlex_2", "_txtFlex_3", "_txtFlexDisplay_1", "_txtFlexDisplay_2", "_txtFlexDisplay_3", "frmFlex", "_txtCommonDisplay_0", "cmdBulkPrint", "Label_0", "lblCompany", "Label_1", "_txtCommon_4", "_txtCommon_5", "_txtCommonDisplay_1", "_Frame_0", "_lblCommon_0", "_lblCommon_1", "_lblCommon_2", "_lblCommon_3", "Picture1", "_txtCommon_1", "_txtCommon_2", "_txtCommon_3", "Column_0_cmbMastersList", "Column_1_cmbMastersList", "cmbMastersList", "_txtCommon_6", "_lblCommon_8", "_lblCommon_9", "_lblCommon_10", "_lblCommon_11", "_txtCommon_7", "_txtCommon_8", "_txtCommon_9", "txtTempDate", "Label1", "lblPrinter", "Frame", "System.Windows.Forms.Label", "System.Windows.Forms.Label1", "cmbFields", "lblCommon", "txtCommon", "txtCommonDisplay", "txtFlex", "txtFlexDisplay"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_0_grdVoucherDetails;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_1_grdVoucherDetails;
		public C1.Win.C1TrueDBGrid.C1TrueDBGrid grdVoucherDetails;
		private System.Windows.Forms.ComboBox _cmbFields_3;
		private System.Windows.Forms.Label _lblCommon_7;
		private System.Windows.Forms.ComboBox _cmbFields_2;
		private System.Windows.Forms.ComboBox _cmbFields_1;
		private System.Windows.Forms.Label _lblCommon_6;
		private System.Windows.Forms.Label _lblCommon_5;
		private System.Windows.Forms.Label _lblCommon_4;
		private System.Windows.Forms.ComboBox _cmbFields_0;
		private System.Windows.Forms.GroupBox _Frame_1;
		public System.Windows.Forms.ComboBox cmbReport;
		public System.Windows.Forms.CheckBox chkPreview;
		public System.Windows.Forms.Button cmdSaveSetting;
		public System.Windows.Forms.ComboBox cmbPrinter;
		private System.Windows.Forms.TextBox _txtCommon_0;
		private System.Windows.Forms.Label Label1_0;
		private System.Windows.Forms.Label Label1_2;
		private System.Windows.Forms.TextBox _txtCommon_10;
		private System.Windows.Forms.TextBox _txtFlex_1;
		private System.Windows.Forms.Label Label1_1;
		private System.Windows.Forms.Label Label_3;
		private System.Windows.Forms.TextBox _txtFlex_2;
		private System.Windows.Forms.TextBox _txtFlex_3;
		private System.Windows.Forms.Label _txtFlexDisplay_1;
		private System.Windows.Forms.Label _txtFlexDisplay_2;
		private System.Windows.Forms.Label _txtFlexDisplay_3;
		public System.Windows.Forms.Panel frmFlex;
		private System.Windows.Forms.Label _txtCommonDisplay_0;
		public System.Windows.Forms.Button cmdBulkPrint;
		private System.Windows.Forms.Label Label_0;
		public System.Windows.Forms.Label lblCompany;
		private System.Windows.Forms.Label Label_1;
		private System.Windows.Forms.TextBox _txtCommon_4;
		private System.Windows.Forms.TextBox _txtCommon_5;
		private System.Windows.Forms.Label _txtCommonDisplay_1;
		private System.Windows.Forms.GroupBox _Frame_0;
		private System.Windows.Forms.Label _lblCommon_0;
		private System.Windows.Forms.Label _lblCommon_1;
		private System.Windows.Forms.Label _lblCommon_2;
		private System.Windows.Forms.Label _lblCommon_3;
		public System.Windows.Forms.PictureBox Picture1;
		private System.Windows.Forms.TextBox _txtCommon_1;
		private System.Windows.Forms.TextBox _txtCommon_2;
		private System.Windows.Forms.TextBox _txtCommon_3;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_0_cmbMastersList;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_1_cmbMastersList;
		public C1.Win.C1TrueDBGrid.C1TrueDBDropdown cmbMastersList;
		private System.Windows.Forms.TextBox _txtCommon_6;
		private System.Windows.Forms.Label _lblCommon_8;
		private System.Windows.Forms.Label _lblCommon_9;
		private System.Windows.Forms.Label _lblCommon_10;
		private System.Windows.Forms.Label _lblCommon_11;
		private System.Windows.Forms.TextBox _txtCommon_7;
		private System.Windows.Forms.TextBox _txtCommon_8;
		private System.Windows.Forms.TextBox _txtCommon_9;
		public Syncfusion.WinForms.Input.SfDateTimeEdit txtTempDate;
		//public System.Windows.Forms.Label Label1;
		public System.Windows.Forms.Label lblPrinter;
		public System.Windows.Forms.GroupBox[] Frame = new System.Windows.Forms.GroupBox[2];
		public System.Windows.Forms.Label[] Label = new System.Windows.Forms.Label[4];
		public System.Windows.Forms.Label[] Label1 = new System.Windows.Forms.Label[3];
		public System.Windows.Forms.ComboBox[] cmbFields = new System.Windows.Forms.ComboBox[4];
		public System.Windows.Forms.Label[] lblCommon = new System.Windows.Forms.Label[12];
		public System.Windows.Forms.TextBox[] txtCommon = new System.Windows.Forms.TextBox[11];
		public System.Windows.Forms.Label[] txtCommonDisplay = new System.Windows.Forms.Label[2];
		public System.Windows.Forms.TextBox[] txtFlex = new System.Windows.Forms.TextBox[4];
		public System.Windows.Forms.Label[] txtFlexDisplay = new System.Windows.Forms.Label[4];
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSysBarcode));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this.grdVoucherDetails = new C1.Win.C1TrueDBGrid.C1TrueDBGrid();
			this.Column_0_grdVoucherDetails = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.Column_1_grdVoucherDetails = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this._Frame_1 = new System.Windows.Forms.GroupBox();
			this._cmbFields_3 = new System.Windows.Forms.ComboBox();
			this._lblCommon_7 = new System.Windows.Forms.Label();
			this._cmbFields_2 = new System.Windows.Forms.ComboBox();
			this._cmbFields_1 = new System.Windows.Forms.ComboBox();
			this._lblCommon_6 = new System.Windows.Forms.Label();
			this._lblCommon_5 = new System.Windows.Forms.Label();
			this._lblCommon_4 = new System.Windows.Forms.Label();
			this._cmbFields_0 = new System.Windows.Forms.ComboBox();
			this.cmbReport = new System.Windows.Forms.ComboBox();
			this.chkPreview = new System.Windows.Forms.CheckBox();
			this.cmdSaveSetting = new System.Windows.Forms.Button();
			this.cmbPrinter = new System.Windows.Forms.ComboBox();
			this._txtCommon_0 = new System.Windows.Forms.TextBox();
			this._Frame_0 = new System.Windows.Forms.GroupBox();
			this.frmFlex = new System.Windows.Forms.Panel();
			this.Label1_0 = new System.Windows.Forms.Label();
			this.Label1_2 = new System.Windows.Forms.Label();
			this._txtCommon_10 = new System.Windows.Forms.TextBox();
			this._txtFlex_1 = new System.Windows.Forms.TextBox();
			this.Label1_1 = new System.Windows.Forms.Label();
			this.Label_3 = new System.Windows.Forms.Label();
			this._txtFlex_2 = new System.Windows.Forms.TextBox();
			this._txtFlex_3 = new System.Windows.Forms.TextBox();
			this._txtFlexDisplay_1 = new System.Windows.Forms.Label();
			this._txtFlexDisplay_2 = new System.Windows.Forms.Label();
			this._txtFlexDisplay_3 = new System.Windows.Forms.Label();
			this._txtCommonDisplay_0 = new System.Windows.Forms.Label();
			this.cmdBulkPrint = new System.Windows.Forms.Button();
			this.Label_0 = new System.Windows.Forms.Label();
			this.lblCompany = new System.Windows.Forms.Label();
			this.Label_1 = new System.Windows.Forms.Label();
			this._txtCommon_4 = new System.Windows.Forms.TextBox();
			this._txtCommon_5 = new System.Windows.Forms.TextBox();
			this._txtCommonDisplay_1 = new System.Windows.Forms.Label();
			this._lblCommon_0 = new System.Windows.Forms.Label();
			this._lblCommon_1 = new System.Windows.Forms.Label();
			this._lblCommon_2 = new System.Windows.Forms.Label();
			this._lblCommon_3 = new System.Windows.Forms.Label();
			this.Picture1 = new System.Windows.Forms.PictureBox();
			this._txtCommon_1 = new System.Windows.Forms.TextBox();
			this._txtCommon_2 = new System.Windows.Forms.TextBox();
			this._txtCommon_3 = new System.Windows.Forms.TextBox();
			this.cmbMastersList = new C1.Win.C1TrueDBGrid.C1TrueDBDropdown();
			this.Column_0_cmbMastersList = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.Column_1_cmbMastersList = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this._txtCommon_6 = new System.Windows.Forms.TextBox();
			this._lblCommon_8 = new System.Windows.Forms.Label();
			this._lblCommon_9 = new System.Windows.Forms.Label();
			this._lblCommon_10 = new System.Windows.Forms.Label();
			this._lblCommon_11 = new System.Windows.Forms.Label();
			this._txtCommon_7 = new System.Windows.Forms.TextBox();
			this._txtCommon_8 = new System.Windows.Forms.TextBox();
			this._txtCommon_9 = new System.Windows.Forms.TextBox();
			this.txtTempDate = new Syncfusion.WinForms.Input.SfDateTimeEdit();
			//this.Label1 = new System.Windows.Forms.Label();
			this.lblPrinter = new System.Windows.Forms.Label();
			// //((System.ComponentModel.ISupportInitialize) this.txtTempDate).BeginInit();
			//this.grdVoucherDetails.SuspendLayout();
			//this._Frame_1.SuspendLayout();
			//this._Frame_0.SuspendLayout();
			//this.frmFlex.SuspendLayout();
			//this.cmbMastersList.SuspendLayout();
			this.SuspendLayout();
			// 
			// grdVoucherDetails
			// 
			//this.grdVoucherDetails.AllowDrop = true;
			this.grdVoucherDetails.BackColor = System.Drawing.Color.FromArgb(236, 233, 216);
			this.grdVoucherDetails.CellTipsWidth = 0;
			this.grdVoucherDetails.Location = new System.Drawing.Point(4, 148);
			this.grdVoucherDetails.Name = "grdVoucherDetails";
			this.grdVoucherDetails.RowDivider.Color = System.Drawing.Color.FromArgb(236, 233, 216);
			this.grdVoucherDetails.Size = new System.Drawing.Size(1133, 285);
			this.grdVoucherDetails.TabIndex = 13;
			this.grdVoucherDetails.Columns.Add(this.Column_0_grdVoucherDetails);
			this.grdVoucherDetails.Columns.Add(this.Column_1_grdVoucherDetails);
			//this.grdVoucherDetails.AfterColUpdate += new C1.Win.C1TrueDBGrid.ColEventHandler(this.grdVoucherDetails_AfterColUpdate);
			////this.grdVoucherDetails.GotFocus += new System.EventHandler(this.grdVoucherDetails_GotFocus);
			////this.grdVoucherDetails.RowColChange += new C1.Win.C1TrueDBGrid.RowColChangeEventHandler(this.grdVoucherDetails_RowColChange);
			// 
			// Column_0_grdVoucherDetails
			// 
			this.Column_0_grdVoucherDetails.DataField = "";
			this.Column_0_grdVoucherDetails.ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.Normal;
			// 
			// Column_1_grdVoucherDetails
			// 
			this.Column_1_grdVoucherDetails.DataField = "";
			this.Column_1_grdVoucherDetails.ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.Normal;
			// 
			// _Frame_1
			// 
			//this._Frame_1.AllowDrop = true;
			this._Frame_1.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._Frame_1.Controls.Add(this._cmbFields_3);
			this._Frame_1.Controls.Add(this._lblCommon_7);
			this._Frame_1.Controls.Add(this._cmbFields_2);
			this._Frame_1.Controls.Add(this._cmbFields_1);
			this._Frame_1.Controls.Add(this._lblCommon_6);
			this._Frame_1.Controls.Add(this._lblCommon_5);
			this._Frame_1.Controls.Add(this._lblCommon_4);
			this._Frame_1.Controls.Add(this._cmbFields_0);
			this._Frame_1.Enabled = true;
			this._Frame_1.ForeColor = System.Drawing.SystemColors.ControlText;
			this._Frame_1.Location = new System.Drawing.Point(6, 2);
			this._Frame_1.Name = "_Frame_1";
			this._Frame_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._Frame_1.Size = new System.Drawing.Size(267, 137);
			this._Frame_1.TabIndex = 47;
			this._Frame_1.Visible = true;
			// 
			// _cmbFields_3
			// 
			//this._cmbFields_3.AllowDrop = true;
			this._cmbFields_3.Location = new System.Drawing.Point(76, 86);
			this._cmbFields_3.Name = "_cmbFields_3";
			this._cmbFields_3.Size = new System.Drawing.Size(173, 21);
			this._cmbFields_3.TabIndex = 48;
			// 
			// _lblCommon_7
			// 
			//this._lblCommon_7.AllowDrop = true;
			this._lblCommon_7.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_7.Text = "Page";
			this._lblCommon_7.ForeColor = System.Drawing.SystemColors.WindowText;
			this._lblCommon_7.Location = new System.Drawing.Point(6, 88);
			this._lblCommon_7.Name = "_lblCommon_7";
			this._lblCommon_7.Size = new System.Drawing.Size(24, 14);
			this._lblCommon_7.TabIndex = 49;
			// 
			// _cmbFields_2
			// 
			//this._cmbFields_2.AllowDrop = true;
			this._cmbFields_2.Location = new System.Drawing.Point(76, 62);
			this._cmbFields_2.Name = "_cmbFields_2";
			this._cmbFields_2.Size = new System.Drawing.Size(173, 21);
			this._cmbFields_2.TabIndex = 50;
			// 
			// _cmbFields_1
			// 
			//this._cmbFields_1.AllowDrop = true;
			this._cmbFields_1.Location = new System.Drawing.Point(76, 38);
			this._cmbFields_1.Name = "_cmbFields_1";
			this._cmbFields_1.Size = new System.Drawing.Size(173, 21);
			this._cmbFields_1.TabIndex = 51;
			// 
			// _lblCommon_6
			// 
			//this._lblCommon_6.AllowDrop = true;
			this._lblCommon_6.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_6.Text = "Footer 2";
			this._lblCommon_6.ForeColor = System.Drawing.SystemColors.WindowText;
			this._lblCommon_6.Location = new System.Drawing.Point(6, 64);
			this._lblCommon_6.Name = "_lblCommon_6";
			this._lblCommon_6.Size = new System.Drawing.Size(40, 14);
			this._lblCommon_6.TabIndex = 52;
			// 
			// _lblCommon_5
			// 
			//this._lblCommon_5.AllowDrop = true;
			this._lblCommon_5.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_5.Text = "Footer 1";
			this._lblCommon_5.ForeColor = System.Drawing.SystemColors.WindowText;
			this._lblCommon_5.Location = new System.Drawing.Point(6, 40);
			this._lblCommon_5.Name = "_lblCommon_5";
			this._lblCommon_5.Size = new System.Drawing.Size(40, 14);
			this._lblCommon_5.TabIndex = 53;
			// 
			// _lblCommon_4
			// 
			//this._lblCommon_4.AllowDrop = true;
			this._lblCommon_4.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_4.Text = "Header";
			this._lblCommon_4.ForeColor = System.Drawing.SystemColors.WindowText;
			this._lblCommon_4.Location = new System.Drawing.Point(6, 16);
			this._lblCommon_4.Name = "_lblCommon_4";
			this._lblCommon_4.Size = new System.Drawing.Size(35, 14);
			this._lblCommon_4.TabIndex = 54;
			// 
			// _cmbFields_0
			// 
			//this._cmbFields_0.AllowDrop = true;
			this._cmbFields_0.Location = new System.Drawing.Point(76, 14);
			this._cmbFields_0.Name = "_cmbFields_0";
			this._cmbFields_0.Size = new System.Drawing.Size(173, 21);
			this._cmbFields_0.TabIndex = 55;
			// 
			// cmbReport
			// 
			//this.cmbReport.AllowDrop = true;
			this.cmbReport.BackColor = System.Drawing.SystemColors.Window;
			this.cmbReport.CausesValidation = true;
			this.cmbReport.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			this.cmbReport.Enabled = true;
			this.cmbReport.ForeColor = System.Drawing.SystemColors.WindowText;
			this.cmbReport.IntegralHeight = true;
			this.cmbReport.Location = new System.Drawing.Point(52, 466);
			this.cmbReport.Name = "cmbReport";
			this.cmbReport.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmbReport.Size = new System.Drawing.Size(165, 21);
			this.cmbReport.Sorted = false;
			this.cmbReport.TabIndex = 45;
			this.cmbReport.TabStop = true;
			this.cmbReport.Visible = true;
			// 
			// chkPreview
			// 
			//this.chkPreview.AllowDrop = true;
			this.chkPreview.Appearance = System.Windows.Forms.Appearance.Normal;
			this.chkPreview.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.chkPreview.CausesValidation = true;
			this.chkPreview.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkPreview.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this.chkPreview.Enabled = true;
			this.chkPreview.ForeColor = System.Drawing.SystemColors.ControlText;
			this.chkPreview.Location = new System.Drawing.Point(238, 444);
			this.chkPreview.Name = "chkPreview";
			this.chkPreview.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.chkPreview.Size = new System.Drawing.Size(185, 15);
			this.chkPreview.TabIndex = 23;
			this.chkPreview.TabStop = true;
			this.chkPreview.Text = "Show Preview";
			this.chkPreview.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkPreview.Visible = true;
			// 
			// cmdSaveSetting
			// 
			//this.cmdSaveSetting.AllowDrop = true;
			this.cmdSaveSetting.BackColor = System.Drawing.SystemColors.Control;
			this.cmdSaveSetting.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdSaveSetting.Location = new System.Drawing.Point(489, 442);
			this.cmdSaveSetting.Name = "cmdSaveSetting";
			this.cmdSaveSetting.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdSaveSetting.Size = new System.Drawing.Size(83, 27);
			this.cmdSaveSetting.TabIndex = 20;
			this.cmdSaveSetting.Text = "&Save Settings";
			this.cmdSaveSetting.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.cmdSaveSetting.UseVisualStyleBackColor = false;
			// this.cmdSaveSetting.Click += new System.EventHandler(this.cmdSaveSetting_Click);
			// 
			// cmbPrinter
			// 
			//this.cmbPrinter.AllowDrop = true;
			this.cmbPrinter.BackColor = System.Drawing.SystemColors.Window;
			this.cmbPrinter.CausesValidation = true;
			this.cmbPrinter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			this.cmbPrinter.Enabled = true;
			this.cmbPrinter.ForeColor = System.Drawing.SystemColors.WindowText;
			this.cmbPrinter.IntegralHeight = true;
			this.cmbPrinter.Location = new System.Drawing.Point(52, 440);
			this.cmbPrinter.Name = "cmbPrinter";
			this.cmbPrinter.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmbPrinter.Size = new System.Drawing.Size(165, 21);
			this.cmbPrinter.Sorted = false;
			this.cmbPrinter.TabIndex = 19;
			this.cmbPrinter.TabStop = true;
			this.cmbPrinter.Visible = true;
			// 
			// _txtCommon_0
			// 
			//this._txtCommon_0.AllowDrop = true;
			this._txtCommon_0.BackColor = System.Drawing.Color.White;
			// // = false;
			this._txtCommon_0.ForeColor = System.Drawing.Color.Black;
			this._txtCommon_0.Location = new System.Drawing.Point(758, 180);
			// // = (System.Windows.Forms.TextBox.DropDownTypes) 0;
			this._txtCommon_0.Name = "_txtCommon_0";
			this._txtCommon_0.Size = new System.Drawing.Size(89, 19);
			this._txtCommon_0.TabIndex = 8;
			this._txtCommon_0.Text = "";
			this._txtCommon_0.Visible = false;
			// this.// = "";
			// this.//this._txtCommon_0.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(//this.txtCommon_DropButtonClick);
			// this._txtCommon_0.Leave += new System.EventHandler(this.txtCommon_Leave);
			// 
			// _Frame_0
			// 
			//this._Frame_0.AllowDrop = true;
			this._Frame_0.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._Frame_0.Controls.Add(this.frmFlex);
			this._Frame_0.Controls.Add(this._txtCommonDisplay_0);
			this._Frame_0.Controls.Add(this.cmdBulkPrint);
			this._Frame_0.Controls.Add(this.Label_0);
			this._Frame_0.Controls.Add(this.lblCompany);
			this._Frame_0.Controls.Add(this.Label_1);
			this._Frame_0.Controls.Add(this._txtCommon_4);
			this._Frame_0.Controls.Add(this._txtCommon_5);
			this._Frame_0.Controls.Add(this._txtCommonDisplay_1);
			this._Frame_0.Enabled = true;
			this._Frame_0.ForeColor = System.Drawing.SystemColors.ControlText;
			this._Frame_0.Location = new System.Drawing.Point(280, 2);
			this._Frame_0.Name = "_Frame_0";
			this._Frame_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._Frame_0.Size = new System.Drawing.Size(563, 137);
			this._Frame_0.TabIndex = 4;
			this._Frame_0.Visible = true;
			// 
			// frmFlex
			// 
			//this.frmFlex.AllowDrop = true;
			this.frmFlex.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			//this.frmFlex.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.frmFlex.Controls.Add(this.Label1_0);
			this.frmFlex.Controls.Add(this.Label1_2);
			this.frmFlex.Controls.Add(this._txtCommon_10);
			this.frmFlex.Controls.Add(this._txtFlex_1);
			this.frmFlex.Controls.Add(this.Label1_1);
			this.frmFlex.Controls.Add(this.Label_3);
			this.frmFlex.Controls.Add(this._txtFlex_2);
			this.frmFlex.Controls.Add(this._txtFlex_3);
			this.frmFlex.Controls.Add(this._txtFlexDisplay_1);
			this.frmFlex.Controls.Add(this._txtFlexDisplay_2);
			this.frmFlex.Controls.Add(this._txtFlexDisplay_3);
			this.frmFlex.Enabled = true;
			this.frmFlex.ForeColor = System.Drawing.SystemColors.ControlText;
			this.frmFlex.Location = new System.Drawing.Point(6, 54);
			this.frmFlex.Name = "frmFlex";
			this.frmFlex.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.frmFlex.Size = new System.Drawing.Size(407, 79);
			this.frmFlex.TabIndex = 33;
			this.frmFlex.Visible = false;
			// 
			// Label1_0
			// 
			//this.Label1_0.AllowDrop = true;
			this.Label1_0.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.Label1_0.Text = "Style No";
			this.Label1_0.ForeColor = System.Drawing.SystemColors.WindowText;
			this.Label1_0.Location = new System.Drawing.Point(4, 2);
			// this.Label1_0.mLabelId = 765;
			this.Label1_0.Name = "Label1_0";
			this.Label1_0.Size = new System.Drawing.Size(40, 14);
			this.Label1_0.TabIndex = 34;
			// 
			// Label1_2
			// 
			//this.Label1_2.AllowDrop = true;
			this.Label1_2.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.Label1_2.Text = "Flex 1";
			this.Label1_2.ForeColor = System.Drawing.SystemColors.WindowText;
			this.Label1_2.Location = new System.Drawing.Point(4, 22);
			// this.Label1_2.mLabelId = 2014;
			this.Label1_2.Name = "Label1_2";
			this.Label1_2.Size = new System.Drawing.Size(29, 14);
			this.Label1_2.TabIndex = 35;
			// 
			// _txtCommon_10
			// 
			//this._txtCommon_10.AllowDrop = true;
			this._txtCommon_10.BackColor = System.Drawing.Color.White;
			// // = false;
			this._txtCommon_10.ForeColor = System.Drawing.Color.Black;
			this._txtCommon_10.Location = new System.Drawing.Point(94, 0);
			// // = (System.Windows.Forms.TextBox.DropDownTypes) 0;
			this._txtCommon_10.Name = "_txtCommon_10";
			this._txtCommon_10.Size = new System.Drawing.Size(103, 19);
			this._txtCommon_10.TabIndex = 36;
			this._txtCommon_10.Text = "";
			// this.// = "";
			// this.//this._txtCommon_10.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(//this.txtCommon_DropButtonClick);
			// this._txtCommon_10.Leave += new System.EventHandler(this.txtCommon_Leave);
			// 
			// _txtFlex_1
			// 
			//this._txtFlex_1.AllowDrop = true;
			this._txtFlex_1.BackColor = System.Drawing.Color.White;
			// // = false;
			this._txtFlex_1.ForeColor = System.Drawing.Color.Black;
			this._txtFlex_1.Location = new System.Drawing.Point(94, 20);
			// // = (System.Windows.Forms.TextBox.DropDownTypes) 0;
			this._txtFlex_1.Name = "_txtFlex_1";
			// this._txtFlex_1.ShowButton = true;
			this._txtFlex_1.Size = new System.Drawing.Size(103, 19);
			this._txtFlex_1.TabIndex = 37;
			this._txtFlex_1.Text = "";
			// this.// = "";
			// this.//this._txtFlex_1.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(//this.txtFlex_DropButtonClick);
			// this._txtFlex_1.Leave += new System.EventHandler(this.txtFlex_Leave);
			// 
			// Label1_1
			// 
			//this.Label1_1.AllowDrop = true;
			this.Label1_1.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.Label1_1.Text = "Flex 2";
			this.Label1_1.ForeColor = System.Drawing.SystemColors.WindowText;
			this.Label1_1.Location = new System.Drawing.Point(4, 42);
			// this.Label1_1.mLabelId = 2015;
			this.Label1_1.Name = "Label1_1";
			this.Label1_1.Size = new System.Drawing.Size(29, 14);
			this.Label1_1.TabIndex = 38;
			// 
			// Label_3
			// 
			//this.Label_3.AllowDrop = true;
			this.Label_3.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.Label_3.Text = "Flex 3";
			this.Label_3.ForeColor = System.Drawing.SystemColors.WindowText;
			this.Label_3.Location = new System.Drawing.Point(4, 62);
			// this.Label_3.mLabelId = 2016;
			this.Label_3.Name = "Label_3";
			this.Label_3.Size = new System.Drawing.Size(29, 14);
			this.Label_3.TabIndex = 39;
			// 
			// _txtFlex_2
			// 
			//this._txtFlex_2.AllowDrop = true;
			this._txtFlex_2.BackColor = System.Drawing.Color.White;
			// // = false;
			this._txtFlex_2.ForeColor = System.Drawing.Color.Black;
			this._txtFlex_2.Location = new System.Drawing.Point(94, 40);
			// // = (System.Windows.Forms.TextBox.DropDownTypes) 0;
			this._txtFlex_2.Name = "_txtFlex_2";
			// this._txtFlex_2.ShowButton = true;
			this._txtFlex_2.Size = new System.Drawing.Size(103, 19);
			this._txtFlex_2.TabIndex = 40;
			this._txtFlex_2.Text = "";
			// this.// = "";
			// this.//this._txtFlex_2.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(//this.txtFlex_DropButtonClick);
			// this._txtFlex_2.Leave += new System.EventHandler(this.txtFlex_Leave);
			// 
			// _txtFlex_3
			// 
			//this._txtFlex_3.AllowDrop = true;
			this._txtFlex_3.BackColor = System.Drawing.Color.White;
			// // = false;
			this._txtFlex_3.ForeColor = System.Drawing.Color.Black;
			this._txtFlex_3.Location = new System.Drawing.Point(94, 60);
			// // = (System.Windows.Forms.TextBox.DropDownTypes) 0;
			this._txtFlex_3.Name = "_txtFlex_3";
			// this._txtFlex_3.ShowButton = true;
			this._txtFlex_3.Size = new System.Drawing.Size(103, 19);
			this._txtFlex_3.TabIndex = 41;
			this._txtFlex_3.Text = "";
			// this.// = "";
			// this.//this._txtFlex_3.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(//this.txtFlex_DropButtonClick);
			// this._txtFlex_3.Leave += new System.EventHandler(this.txtFlex_Leave);
			// 
			// _txtFlexDisplay_1
			// 
			//this._txtFlexDisplay_1.AllowDrop = true;
			this._txtFlexDisplay_1.Location = new System.Drawing.Point(200, 20);
			this._txtFlexDisplay_1.Name = "_txtFlexDisplay_1";
			this._txtFlexDisplay_1.Size = new System.Drawing.Size(201, 19);
			this._txtFlexDisplay_1.TabIndex = 42;
			// 
			// _txtFlexDisplay_2
			// 
			//this._txtFlexDisplay_2.AllowDrop = true;
			this._txtFlexDisplay_2.Location = new System.Drawing.Point(200, 40);
			this._txtFlexDisplay_2.Name = "_txtFlexDisplay_2";
			this._txtFlexDisplay_2.Size = new System.Drawing.Size(201, 19);
			this._txtFlexDisplay_2.TabIndex = 43;
			// 
			// _txtFlexDisplay_3
			// 
			//this._txtFlexDisplay_3.AllowDrop = true;
			this._txtFlexDisplay_3.Location = new System.Drawing.Point(200, 60);
			this._txtFlexDisplay_3.Name = "_txtFlexDisplay_3";
			this._txtFlexDisplay_3.Size = new System.Drawing.Size(201, 19);
			this._txtFlexDisplay_3.TabIndex = 44;
			// 
			// _txtCommonDisplay_0
			// 
			//this._txtCommonDisplay_0.AllowDrop = true;
			this._txtCommonDisplay_0.BackColor = System.Drawing.Color.White;
			this._txtCommonDisplay_0.Enabled = false;
			this._txtCommonDisplay_0.Location = new System.Drawing.Point(206, 12);
			this._txtCommonDisplay_0.Name = "_txtCommonDisplay_0";
			this._txtCommonDisplay_0.Size = new System.Drawing.Size(227, 19);
			this._txtCommonDisplay_0.TabIndex = 17;
			// 
			// cmdBulkPrint
			// 
			//this.cmdBulkPrint.AllowDrop = true;
			this.cmdBulkPrint.BackColor = System.Drawing.SystemColors.Control;
			this.cmdBulkPrint.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdBulkPrint.Location = new System.Drawing.Point(462, 96);
			this.cmdBulkPrint.Name = "cmdBulkPrint";
			this.cmdBulkPrint.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdBulkPrint.Size = new System.Drawing.Size(89, 31);
			this.cmdBulkPrint.TabIndex = 16;
			this.cmdBulkPrint.Text = "Bulk Print";
			this.cmdBulkPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.cmdBulkPrint.UseVisualStyleBackColor = false;
			// this.cmdBulkPrint.Click += new System.EventHandler(this.cmdBulkPrint_Click);
			// 
			// Label_0
			// 
			//this.Label_0.AllowDrop = true;
			this.Label_0.BackColor = System.Drawing.SystemColors.Window;
			// = VSReport8Lib.BackStyleSettings.vsrTransparent;
			this.Label_0.ForeColor = System.Drawing.SystemColors.WindowText;
			this.Label_0.Location = new System.Drawing.Point(12, 44);
			this.Label_0.Name = "Label_0";
			this.Label_0.Size = new System.Drawing.Size(3, 14);
			this.Label_0.TabIndex = 6;
			// 
			// lblCompany
			// 
			//this.lblCompany.AllowDrop = true;
			this.lblCompany.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblCompany.Text = "From Item";
			this.lblCompany.ForeColor = System.Drawing.SystemColors.WindowText;
			this.lblCompany.Location = new System.Drawing.Point(10, 14);
			this.lblCompany.Name = "lblCompany";
			this.lblCompany.Size = new System.Drawing.Size(46, 14);
			this.lblCompany.TabIndex = 5;
			// 
			// Label_1
			// 
			//this.Label_1.AllowDrop = true;
			this.Label_1.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.Label_1.Text = "To Item";
			this.Label_1.ForeColor = System.Drawing.SystemColors.WindowText;
			this.Label_1.Location = new System.Drawing.Point(10, 34);
			this.Label_1.Name = "Label_1";
			this.Label_1.Size = new System.Drawing.Size(34, 14);
			this.Label_1.TabIndex = 7;
			// 
			// _txtCommon_4
			// 
			//this._txtCommon_4.AllowDrop = true;
			this._txtCommon_4.BackColor = System.Drawing.Color.White;
			// // = false;
			this._txtCommon_4.ForeColor = System.Drawing.Color.Black;
			this._txtCommon_4.Location = new System.Drawing.Point(100, 12);
			// // = (System.Windows.Forms.TextBox.DropDownTypes) 0;
			this._txtCommon_4.Name = "_txtCommon_4";
			// this._txtCommon_4.ShowButton = true;
			this._txtCommon_4.Size = new System.Drawing.Size(103, 19);
			this._txtCommon_4.TabIndex = 14;
			this._txtCommon_4.Text = "";
			// this.// = "";
			// this.//this._txtCommon_4.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(//this.txtCommon_DropButtonClick);
			// this._txtCommon_4.Leave += new System.EventHandler(this.txtCommon_Leave);
			// 
			// _txtCommon_5
			// 
			//this._txtCommon_5.AllowDrop = true;
			this._txtCommon_5.BackColor = System.Drawing.Color.White;
			// // = false;
			this._txtCommon_5.ForeColor = System.Drawing.Color.Black;
			this._txtCommon_5.Location = new System.Drawing.Point(100, 32);
			// // = (System.Windows.Forms.TextBox.DropDownTypes) 0;
			this._txtCommon_5.Name = "_txtCommon_5";
			// this._txtCommon_5.ShowButton = true;
			this._txtCommon_5.Size = new System.Drawing.Size(103, 19);
			this._txtCommon_5.TabIndex = 15;
			this._txtCommon_5.Text = "";
			// this.// = "";
			// this.//this._txtCommon_5.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(//this.txtCommon_DropButtonClick);
			// this._txtCommon_5.Leave += new System.EventHandler(this.txtCommon_Leave);
			// 
			// _txtCommonDisplay_1
			// 
			//this._txtCommonDisplay_1.AllowDrop = true;
			this._txtCommonDisplay_1.BackColor = System.Drawing.Color.White;
			this._txtCommonDisplay_1.Enabled = false;
			this._txtCommonDisplay_1.Location = new System.Drawing.Point(206, 32);
			this._txtCommonDisplay_1.Name = "_txtCommonDisplay_1";
			this._txtCommonDisplay_1.Size = new System.Drawing.Size(227, 19);
			this._txtCommonDisplay_1.TabIndex = 18;
			// 
			// _lblCommon_0
			// 
			//this._lblCommon_0.AllowDrop = true;
			this._lblCommon_0.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_0.Text = "Width";
			this._lblCommon_0.ForeColor = System.Drawing.SystemColors.WindowText;
			this._lblCommon_0.Location = new System.Drawing.Point(660, 184);
			this._lblCommon_0.Name = "_lblCommon_0";
			this._lblCommon_0.Size = new System.Drawing.Size(27, 14);
			this._lblCommon_0.TabIndex = 0;
			this._lblCommon_0.Visible = false;
			// 
			// _lblCommon_1
			// 
			//this._lblCommon_1.AllowDrop = true;
			this._lblCommon_1.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_1.Text = "Height";
			this._lblCommon_1.ForeColor = System.Drawing.SystemColors.WindowText;
			this._lblCommon_1.Location = new System.Drawing.Point(660, 208);
			this._lblCommon_1.Name = "_lblCommon_1";
			this._lblCommon_1.Size = new System.Drawing.Size(30, 14);
			this._lblCommon_1.TabIndex = 1;
			this._lblCommon_1.Visible = false;
			// 
			// _lblCommon_2
			// 
			//this._lblCommon_2.AllowDrop = true;
			this._lblCommon_2.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_2.Text = "Font Size";
			this._lblCommon_2.ForeColor = System.Drawing.SystemColors.WindowText;
			this._lblCommon_2.Location = new System.Drawing.Point(660, 232);
			this._lblCommon_2.Name = "_lblCommon_2";
			this._lblCommon_2.Size = new System.Drawing.Size(45, 14);
			this._lblCommon_2.TabIndex = 2;
			this._lblCommon_2.Visible = false;
			// 
			// _lblCommon_3
			// 
			//this._lblCommon_3.AllowDrop = true;
			this._lblCommon_3.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_3.Text = "Word Wrap Length";
			this._lblCommon_3.ForeColor = System.Drawing.SystemColors.WindowText;
			this._lblCommon_3.Location = new System.Drawing.Point(660, 256);
			this._lblCommon_3.Name = "_lblCommon_3";
			this._lblCommon_3.Size = new System.Drawing.Size(91, 14);
			this._lblCommon_3.TabIndex = 3;
			this._lblCommon_3.Visible = false;
			// 
			// Picture1
			// 
			//this.Picture1.AllowDrop = true;
			this.Picture1.BackColor = System.Drawing.SystemColors.Control;
			//this.Picture1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.Picture1.CausesValidation = true;
			this.Picture1.Dock = System.Windows.Forms.DockStyle.None;
			this.Picture1.Enabled = true;
			this.Picture1.Location = new System.Drawing.Point(0, 0);
			this.Picture1.Name = "Picture1";
			this.Picture1.Size = new System.Drawing.Size(0, 0);
			this.Picture1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal;
			this.Picture1.TabIndex = 9;
			this.Picture1.TabStop = true;
			this.Picture1.Visible = true;
			// 
			// _txtCommon_1
			// 
			//this._txtCommon_1.AllowDrop = true;
			this._txtCommon_1.BackColor = System.Drawing.Color.White;
			// // = false;
			this._txtCommon_1.ForeColor = System.Drawing.Color.Black;
			this._txtCommon_1.Location = new System.Drawing.Point(758, 204);
			// // = (System.Windows.Forms.TextBox.DropDownTypes) 0;
			this._txtCommon_1.Name = "_txtCommon_1";
			this._txtCommon_1.Size = new System.Drawing.Size(89, 19);
			this._txtCommon_1.TabIndex = 10;
			this._txtCommon_1.Text = "";
			this._txtCommon_1.Visible = false;
			// this.// = "";
			// this.//this._txtCommon_1.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(//this.txtCommon_DropButtonClick);
			// this._txtCommon_1.Leave += new System.EventHandler(this.txtCommon_Leave);
			// 
			// _txtCommon_2
			// 
			//this._txtCommon_2.AllowDrop = true;
			this._txtCommon_2.BackColor = System.Drawing.Color.White;
			// // = false;
			this._txtCommon_2.ForeColor = System.Drawing.Color.Black;
			this._txtCommon_2.Location = new System.Drawing.Point(758, 228);
			// // = (System.Windows.Forms.TextBox.DropDownTypes) 0;
			this._txtCommon_2.Name = "_txtCommon_2";
			this._txtCommon_2.Size = new System.Drawing.Size(89, 19);
			this._txtCommon_2.TabIndex = 11;
			this._txtCommon_2.Text = "";
			this._txtCommon_2.Visible = false;
			// this.// = "";
			// this.//this._txtCommon_2.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(//this.txtCommon_DropButtonClick);
			// this._txtCommon_2.Leave += new System.EventHandler(this.txtCommon_Leave);
			// 
			// _txtCommon_3
			// 
			//this._txtCommon_3.AllowDrop = true;
			this._txtCommon_3.BackColor = System.Drawing.Color.White;
			// // = false;
			this._txtCommon_3.ForeColor = System.Drawing.Color.Black;
			this._txtCommon_3.Location = new System.Drawing.Point(758, 254);
			// // = (System.Windows.Forms.TextBox.DropDownTypes) 0;
			this._txtCommon_3.Name = "_txtCommon_3";
			this._txtCommon_3.Size = new System.Drawing.Size(89, 19);
			this._txtCommon_3.TabIndex = 12;
			this._txtCommon_3.Text = "";
			this._txtCommon_3.Visible = false;
			// this.// = "";
			// this.//this._txtCommon_3.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(//this.txtCommon_DropButtonClick);
			// this._txtCommon_3.Leave += new System.EventHandler(this.txtCommon_Leave);
			// 
			// cmbMastersList
			// 
			//this.cmbMastersList.AllowDrop = true;
			this.cmbMastersList.ColumnHeaders = true;
			this.cmbMastersList.Enabled = true;
			this.cmbMastersList.Location = new System.Drawing.Point(0, 312);
			this.cmbMastersList.Name = "cmbMastersList";
			this.cmbMastersList.Size = new System.Drawing.Size(227, 97);
			this.cmbMastersList.TabIndex = 22;
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
			// _txtCommon_6
			// 
			//this._txtCommon_6.AllowDrop = true;
			this._txtCommon_6.BackColor = System.Drawing.Color.White;
			// // = false;
			this._txtCommon_6.ForeColor = System.Drawing.Color.Black;
			this._txtCommon_6.Location = new System.Drawing.Point(400, 174);
			// // = (System.Windows.Forms.TextBox.DropDownTypes) 0;
			this._txtCommon_6.Name = "_txtCommon_6";
			this._txtCommon_6.Size = new System.Drawing.Size(225, 19);
			this._txtCommon_6.TabIndex = 24;
			this._txtCommon_6.Text = "";
			this._txtCommon_6.Visible = false;
			// this.// = "";
			// this.//this._txtCommon_6.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(//this.txtCommon_DropButtonClick);
			// this._txtCommon_6.Leave += new System.EventHandler(this.txtCommon_Leave);
			// 
			// _lblCommon_8
			// 
			//this._lblCommon_8.AllowDrop = true;
			this._lblCommon_8.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_8.Text = "Custom Field 1";
			this._lblCommon_8.ForeColor = System.Drawing.SystemColors.WindowText;
			this._lblCommon_8.Location = new System.Drawing.Point(302, 178);
			// // this._lblCommon_8.mLabelId = 2185;
			this._lblCommon_8.Name = "_lblCommon_8";
			this._lblCommon_8.Size = new System.Drawing.Size(70, 14);
			this._lblCommon_8.TabIndex = 25;
			this._lblCommon_8.Visible = false;
			// 
			// _lblCommon_9
			// 
			//this._lblCommon_9.AllowDrop = true;
			this._lblCommon_9.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_9.Text = "Custom Field 2";
			this._lblCommon_9.ForeColor = System.Drawing.SystemColors.WindowText;
			this._lblCommon_9.Location = new System.Drawing.Point(302, 202);
			// // this._lblCommon_9.mLabelId = 2186;
			this._lblCommon_9.Name = "_lblCommon_9";
			this._lblCommon_9.Size = new System.Drawing.Size(70, 14);
			this._lblCommon_9.TabIndex = 26;
			this._lblCommon_9.Visible = false;
			// 
			// _lblCommon_10
			// 
			//this._lblCommon_10.AllowDrop = true;
			this._lblCommon_10.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_10.Text = "Custom Field 3";
			this._lblCommon_10.ForeColor = System.Drawing.SystemColors.WindowText;
			this._lblCommon_10.Location = new System.Drawing.Point(302, 226);
			// // this._lblCommon_10.mLabelId = 2187;
			this._lblCommon_10.Name = "_lblCommon_10";
			this._lblCommon_10.Size = new System.Drawing.Size(70, 14);
			this._lblCommon_10.TabIndex = 27;
			this._lblCommon_10.Visible = false;
			// 
			// _lblCommon_11
			// 
			//this._lblCommon_11.AllowDrop = true;
			this._lblCommon_11.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_11.Text = "Custom Field 1";
			this._lblCommon_11.ForeColor = System.Drawing.SystemColors.WindowText;
			this._lblCommon_11.Location = new System.Drawing.Point(302, 250);
			// // this._lblCommon_11.mLabelId = 2188;
			this._lblCommon_11.Name = "_lblCommon_11";
			this._lblCommon_11.Size = new System.Drawing.Size(70, 14);
			this._lblCommon_11.TabIndex = 28;
			this._lblCommon_11.Visible = false;
			// 
			// _txtCommon_7
			// 
			//this._txtCommon_7.AllowDrop = true;
			this._txtCommon_7.BackColor = System.Drawing.Color.White;
			// // = false;
			this._txtCommon_7.ForeColor = System.Drawing.Color.Black;
			this._txtCommon_7.Location = new System.Drawing.Point(400, 198);
			// // = (System.Windows.Forms.TextBox.DropDownTypes) 0;
			this._txtCommon_7.Name = "_txtCommon_7";
			this._txtCommon_7.Size = new System.Drawing.Size(225, 19);
			this._txtCommon_7.TabIndex = 29;
			this._txtCommon_7.Text = "";
			this._txtCommon_7.Visible = false;
			// this.// = "";
			// this.//this._txtCommon_7.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(//this.txtCommon_DropButtonClick);
			// this._txtCommon_7.Leave += new System.EventHandler(this.txtCommon_Leave);
			// 
			// _txtCommon_8
			// 
			//this._txtCommon_8.AllowDrop = true;
			this._txtCommon_8.BackColor = System.Drawing.Color.White;
			// // = false;
			this._txtCommon_8.ForeColor = System.Drawing.Color.Black;
			this._txtCommon_8.Location = new System.Drawing.Point(400, 222);
			// // = (System.Windows.Forms.TextBox.DropDownTypes) 0;
			this._txtCommon_8.Name = "_txtCommon_8";
			this._txtCommon_8.Size = new System.Drawing.Size(225, 19);
			this._txtCommon_8.TabIndex = 30;
			this._txtCommon_8.Text = "";
			this._txtCommon_8.Visible = false;
			// this.// = "";
			// this.//this._txtCommon_8.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(//this.txtCommon_DropButtonClick);
			// this._txtCommon_8.Leave += new System.EventHandler(this.txtCommon_Leave);
			// 
			// _txtCommon_9
			// 
			//this._txtCommon_9.AllowDrop = true;
			this._txtCommon_9.BackColor = System.Drawing.Color.White;
			// // = false;
			this._txtCommon_9.ForeColor = System.Drawing.Color.Black;
			this._txtCommon_9.Location = new System.Drawing.Point(400, 248);
			// // = (System.Windows.Forms.TextBox.DropDownTypes) 0;
			this._txtCommon_9.Name = "_txtCommon_9";
			this._txtCommon_9.Size = new System.Drawing.Size(225, 19);
			this._txtCommon_9.TabIndex = 31;
			this._txtCommon_9.Text = "";
			this._txtCommon_9.Visible = false;
			// this.// = "";
			// this.//this._txtCommon_9.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(//this.txtCommon_DropButtonClick);
			// this._txtCommon_9.Leave += new System.EventHandler(this.txtCommon_Leave);
			// 
			// txtTempDate
			// 
			//this.txtTempDate.AllowDrop = true;
			this.txtTempDate.Location = new System.Drawing.Point(10, 282);
			this.txtTempDate.Name = "txtTempDate";
			//
			this.txtTempDate.Size = new System.Drawing.Size(109, 19);
			this.txtTempDate.TabIndex = 32;
			this.txtTempDate.Visible = false;
			// 
			// Label1
			// 
			////this.Label1.AllowDrop = true;
			//this.Label1.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			////this.Label1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			//this.Label1.ForeColor = System.Drawing.SystemColors.ControlText;
			//this.Label1.Location = new System.Drawing.Point(12, 468);
			//this.Label1.Name = "Label1";
			//this.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			//this.Label1.Size = new System.Drawing.Size(39, 17);
			//this.Label1.TabIndex = 46;
			//this.Label1.Text = "Report:";
			// 
			// lblPrinter
			// 
			//this.lblPrinter.AllowDrop = true;
			this.lblPrinter.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			//this.lblPrinter.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lblPrinter.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblPrinter.Location = new System.Drawing.Point(12, 442);
			this.lblPrinter.Name = "lblPrinter";
			this.lblPrinter.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblPrinter.Size = new System.Drawing.Size(39, 17);
			this.lblPrinter.TabIndex = 21;
			this.lblPrinter.Text = "Printer:";
			// 
			// frmSysBarcode
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.ClientSize = new System.Drawing.Size(1217, 572);
			this.Controls.Add(this.grdVoucherDetails);
			this.Controls.Add(this._Frame_1);
			this.Controls.Add(this.cmbReport);
			this.Controls.Add(this.chkPreview);
			this.Controls.Add(this.cmdSaveSetting);
			this.Controls.Add(this.cmbPrinter);
			this.Controls.Add(this._txtCommon_0);
			this.Controls.Add(this._Frame_0);
			this.Controls.Add(this._lblCommon_0);
			this.Controls.Add(this._lblCommon_1);
			this.Controls.Add(this._lblCommon_2);
			this.Controls.Add(this._lblCommon_3);
			this.Controls.Add(this.Picture1);
			this.Controls.Add(this._txtCommon_1);
			this.Controls.Add(this._txtCommon_2);
			this.Controls.Add(this._txtCommon_3);
			this.Controls.Add(this.cmbMastersList);
			this.Controls.Add(this._txtCommon_6);
			this.Controls.Add(this._lblCommon_8);
			this.Controls.Add(this._lblCommon_9);
			this.Controls.Add(this._lblCommon_10);
			this.Controls.Add(this._lblCommon_11);
			this.Controls.Add(this._txtCommon_7);
			this.Controls.Add(this._txtCommon_8);
			this.Controls.Add(this._txtCommon_9);
			this.Controls.Add(this.txtTempDate);
			//this.Controls.Add(this.Label1);
			this.Controls.Add(this.lblPrinter);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			//this.Icon = (System.Drawing.Icon) resources.GetObject("frmSysBarcode.Icon");
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(215, 139);
			this.MaximizeBox = true;
			this.MinimizeBox = true;
			this.Name = "frmSysBarcode";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Generate Barcode";
			// this.Activated += new System.EventHandler(this.Form_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
			// this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
			//this.Resize += new System.EventHandler(this.Form_Resize);
			//((System.ComponentModel.ISupportInitialize) this.txtTempDate).EndInit();
			this.grdVoucherDetails.ResumeLayout(false);
			this._Frame_1.ResumeLayout(false);
			this._Frame_0.ResumeLayout(false);
			this.frmFlex.ResumeLayout(false);
			this.cmbMastersList.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		// 
		void InitializetxtFlexDisplay()
		{
			this.txtFlexDisplay = new System.Windows.Forms.Label[4];
			this.txtFlexDisplay[1] = _txtFlexDisplay_1;
			this.txtFlexDisplay[2] = _txtFlexDisplay_2;
			this.txtFlexDisplay[3] = _txtFlexDisplay_3;
		}
		void InitializetxtFlex()
		{
			this.txtFlex = new System.Windows.Forms.TextBox[4];
			this.txtFlex[1] = _txtFlex_1;
			this.txtFlex[2] = _txtFlex_2;
			this.txtFlex[3] = _txtFlex_3;
		}
		void InitializetxtCommonDisplay()
		{
			this.txtCommonDisplay = new System.Windows.Forms.Label[2];
			this.txtCommonDisplay[0] = _txtCommonDisplay_0;
			this.txtCommonDisplay[1] = _txtCommonDisplay_1;
		}
		void InitializetxtCommon()
		{
			this.txtCommon = new System.Windows.Forms.TextBox[11];
			this.txtCommon[0] = _txtCommon_0;
			this.txtCommon[10] = _txtCommon_10;
			this.txtCommon[4] = _txtCommon_4;
			this.txtCommon[5] = _txtCommon_5;
			this.txtCommon[1] = _txtCommon_1;
			this.txtCommon[2] = _txtCommon_2;
			this.txtCommon[3] = _txtCommon_3;
			this.txtCommon[6] = _txtCommon_6;
			this.txtCommon[7] = _txtCommon_7;
			this.txtCommon[8] = _txtCommon_8;
			this.txtCommon[9] = _txtCommon_9;
		}
		void InitializelblCommon()
		{
			this.lblCommon = new System.Windows.Forms.Label[12];
			this.lblCommon[7] = _lblCommon_7;
			this.lblCommon[6] = _lblCommon_6;
			this.lblCommon[5] = _lblCommon_5;
			this.lblCommon[4] = _lblCommon_4;
			this.lblCommon[0] = _lblCommon_0;
			this.lblCommon[1] = _lblCommon_1;
			this.lblCommon[2] = _lblCommon_2;
			this.lblCommon[3] = _lblCommon_3;
			this.lblCommon[8] = _lblCommon_8;
			this.lblCommon[9] = _lblCommon_9;
			this.lblCommon[10] = _lblCommon_10;
			this.lblCommon[11] = _lblCommon_11;
		}
		void InitializecmbFields()
		{
			this.cmbFields = new System.Windows.Forms.ComboBox[4];
			this.cmbFields[3] = _cmbFields_3;
			this.cmbFields[2] = _cmbFields_2;
			this.cmbFields[1] = _cmbFields_1;
			this.cmbFields[0] = _cmbFields_0;
		}
		void InitializeSystemWindowsFormsLabel1()
		{
			this.Label1 = new System.Windows.Forms.Label[3];
			this.Label1[0] = Label1_0;
			this.Label1[2] = Label1_2;
			this.Label1[1] = Label1_1;
		}
		void InitializeSystemWindowsFormsLabel()
		{
			this.Label = new System.Windows.Forms.Label[4];
			this.Label[3] = Label_3;
			this.Label[0] = Label_0;
			this.Label[1] = Label_1;
		}
		void InitializeFrame()
		{
			this.Frame = new System.Windows.Forms.GroupBox[2];
			this.Frame[1] = _Frame_1;
			this.Frame[0] = _Frame_0;
		}
		#endregion
	}
}//ENDSHERE
