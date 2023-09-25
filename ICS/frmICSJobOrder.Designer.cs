
namespace Xtreme
{
	partial class frmICSJobOrder
	{

		#region "Upgrade Support "
		private static frmICSJobOrder m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmICSJobOrder DefInstance
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
		public static frmICSJobOrder CreateInstance()
		{
			frmICSJobOrder theInstance = new frmICSJobOrder();
			
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
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "txtNumbering", "_lblCommonLabel_12", "_lblCommonLabel_13", "_lblCommonLabel_14", "_lblCommonLabel_15", "txtPerforation", "txtCoverNo", "txtCoverColor", "Frame3", "txt1Copy", "_lblCommonLabel_2", "_lblCommonLabel_3", "_lblCommonLabel_4", "_lblCommonLabel_7", "txt2Copy", "txt3Copy", "txt4Copy", "Frame2", "TabControlPage2", "Column_0_grdVoucherDetails", "Column_1_grdVoucherDetails", "grdVoucherDetails", "Column_0_cmbMastersList", "Column_1_cmbMastersList", "cmbMastersList", "TabControlPage1", "tabMain", "_optVoucherType_0", "_optVoucherType_1", "_txtCommonTextBox_5", "txtCashAmt", "_txtCommonTextBox_6", "txtCCAmt", "_txtDisplayLabel_3", "_txtDisplayLabel_15", "fraPayments", "_lblCommonLabel_9", "txtRemark", "txtPercentDiscount", "txtDiscount", "txtNetAmount", "_lblCommonLabel_11", "_lblCommonLabel_10", "Line1", "frameBottom", "Check4", "Check3", "Check2", "Check1", "Frame1", "txtVoucherDate", "_txtCommonTextBox_1", "_lblCommonLabel_5", "_lblCommonLabel_6", "_txtCommonTextBox_7", "_txtDisplayLabel_1", "_lblCommonLabel_0", "_txtCommonTextBox_3", "_txtDisplayLabel_6", "_lblCommonLabel_1", "_lblCommonLabel_8", "_txtCommonTextBox_9", "_txtDisplayLabel_2", "fraVoucherType", "lblCommonLabel", "optVoucherType", "txtCommonTextBox", "txtDisplayLabel"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public System.Windows.Forms.TextBox txtNumbering;
		private System.Windows.Forms.Label _lblCommonLabel_12;
		private System.Windows.Forms.Label _lblCommonLabel_13;
		private System.Windows.Forms.Label _lblCommonLabel_14;
		private System.Windows.Forms.Label _lblCommonLabel_15;
		public System.Windows.Forms.TextBox txtPerforation;
		public System.Windows.Forms.TextBox txtCoverNo;
		public System.Windows.Forms.TextBox txtCoverColor;
		public System.Windows.Forms.GroupBox Frame3;
		public System.Windows.Forms.TextBox txt1Copy;
		private System.Windows.Forms.Label _lblCommonLabel_2;
		private System.Windows.Forms.Label _lblCommonLabel_3;
		private System.Windows.Forms.Label _lblCommonLabel_4;
		private System.Windows.Forms.Label _lblCommonLabel_7;
		public System.Windows.Forms.TextBox txt2Copy;
		public System.Windows.Forms.TextBox txt3Copy;
		public System.Windows.Forms.TextBox txt4Copy;
		public System.Windows.Forms.GroupBox Frame2;
		public AxXtremeSuiteControls.AxTabControlPage TabControlPage2;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_0_grdVoucherDetails;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_1_grdVoucherDetails;
		public C1.Win.C1TrueDBGrid.C1TrueDBGrid grdVoucherDetails;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_0_cmbMastersList;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_1_cmbMastersList;
		public C1.Win.C1TrueDBGrid.C1TrueDBDropdown cmbMastersList;
		public AxXtremeSuiteControls.AxTabControlPage TabControlPage1;
		public AxXtremeSuiteControls.AxTabControl tabMain;
		private System.Windows.Forms.RadioButton _optVoucherType_0;
		private System.Windows.Forms.RadioButton _optVoucherType_1;
		private System.Windows.Forms.TextBox _txtCommonTextBox_5;
		public System.Windows.Forms.TextBox txtCashAmt;
		private System.Windows.Forms.TextBox _txtCommonTextBox_6;
		public System.Windows.Forms.TextBox txtCCAmt;
		private System.Windows.Forms.Label _txtDisplayLabel_3;
		private System.Windows.Forms.Label _txtDisplayLabel_15;
		public System.Windows.Forms.GroupBox fraPayments;
		private System.Windows.Forms.Label _lblCommonLabel_9;
		public System.Windows.Forms.TextBox txtRemark;
		public System.Windows.Forms.TextBox txtPercentDiscount;
		public System.Windows.Forms.TextBox txtDiscount;
		public System.Windows.Forms.TextBox txtNetAmount;
		private System.Windows.Forms.Label _lblCommonLabel_11;
		private System.Windows.Forms.Label _lblCommonLabel_10;
		public System.Windows.Forms.Label Line1;
		public System.Windows.Forms.Panel frameBottom;
		public System.Windows.Forms.CheckBox Check4;
		public System.Windows.Forms.CheckBox Check3;
		public System.Windows.Forms.CheckBox Check2;
		public System.Windows.Forms.CheckBox Check1;
		public System.Windows.Forms.GroupBox Frame1;
		public Syncfusion.WinForms.Input.SfDateTimeEdit txtVoucherDate;
		private System.Windows.Forms.TextBox _txtCommonTextBox_1;
		private System.Windows.Forms.Label _lblCommonLabel_5;
		private System.Windows.Forms.Label _lblCommonLabel_6;
		private System.Windows.Forms.TextBox _txtCommonTextBox_7;
		private System.Windows.Forms.Label _txtDisplayLabel_1;
		private System.Windows.Forms.Label _lblCommonLabel_0;
		private System.Windows.Forms.TextBox _txtCommonTextBox_3;
		private System.Windows.Forms.Label _txtDisplayLabel_6;
		private System.Windows.Forms.Label _lblCommonLabel_1;
		private System.Windows.Forms.Label _lblCommonLabel_8;
		private System.Windows.Forms.TextBox _txtCommonTextBox_9;
		private System.Windows.Forms.Label _txtDisplayLabel_2;
		public UpgradeHelpers.Gui.ShapeHelper fraVoucherType;
		public System.Windows.Forms.Label[] lblCommonLabel = new System.Windows.Forms.Label[16];
		public System.Windows.Forms.RadioButton[] optVoucherType = new System.Windows.Forms.RadioButton[2];
		public System.Windows.Forms.TextBox[] txtCommonTextBox = new System.Windows.Forms.TextBox[10];
		public System.Windows.Forms.Label[] txtDisplayLabel = new System.Windows.Forms.Label[16];
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmICSJobOrder));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this.tabMain = new AxXtremeSuiteControls.AxTabControl();
			this.TabControlPage2 = new AxXtremeSuiteControls.AxTabControlPage();
			this.Frame3 = new System.Windows.Forms.GroupBox();
			this.txtNumbering = new System.Windows.Forms.TextBox();
			this._lblCommonLabel_12 = new System.Windows.Forms.Label();
			this._lblCommonLabel_13 = new System.Windows.Forms.Label();
			this._lblCommonLabel_14 = new System.Windows.Forms.Label();
			this._lblCommonLabel_15 = new System.Windows.Forms.Label();
			this.txtPerforation = new System.Windows.Forms.TextBox();
			this.txtCoverNo = new System.Windows.Forms.TextBox();
			this.txtCoverColor = new System.Windows.Forms.TextBox();
			this.Frame2 = new System.Windows.Forms.GroupBox();
			this.txt1Copy = new System.Windows.Forms.TextBox();
			this._lblCommonLabel_2 = new System.Windows.Forms.Label();
			this._lblCommonLabel_3 = new System.Windows.Forms.Label();
			this._lblCommonLabel_4 = new System.Windows.Forms.Label();
			this._lblCommonLabel_7 = new System.Windows.Forms.Label();
			this.txt2Copy = new System.Windows.Forms.TextBox();
			this.txt3Copy = new System.Windows.Forms.TextBox();
			this.txt4Copy = new System.Windows.Forms.TextBox();
			this.TabControlPage1 = new AxXtremeSuiteControls.AxTabControlPage();
			this.grdVoucherDetails = new C1.Win.C1TrueDBGrid.C1TrueDBGrid();
			this.Column_0_grdVoucherDetails = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.Column_1_grdVoucherDetails = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.cmbMastersList = new C1.Win.C1TrueDBGrid.C1TrueDBDropdown();
			this.Column_0_cmbMastersList = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.Column_1_cmbMastersList = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this._optVoucherType_0 = new System.Windows.Forms.RadioButton();
			this._optVoucherType_1 = new System.Windows.Forms.RadioButton();
			this.frameBottom = new System.Windows.Forms.Panel();
			this.fraPayments = new System.Windows.Forms.GroupBox();
			this._txtCommonTextBox_5 = new System.Windows.Forms.TextBox();
			this.txtCashAmt = new System.Windows.Forms.TextBox();
			this._txtCommonTextBox_6 = new System.Windows.Forms.TextBox();
			this.txtCCAmt = new System.Windows.Forms.TextBox();
			this._txtDisplayLabel_3 = new System.Windows.Forms.Label();
			this._txtDisplayLabel_15 = new System.Windows.Forms.Label();
			this._lblCommonLabel_9 = new System.Windows.Forms.Label();
			this.txtRemark = new System.Windows.Forms.TextBox();
			this.txtPercentDiscount = new System.Windows.Forms.TextBox();
			this.txtDiscount = new System.Windows.Forms.TextBox();
			this.txtNetAmount = new System.Windows.Forms.TextBox();
			this._lblCommonLabel_11 = new System.Windows.Forms.Label();
			this._lblCommonLabel_10 = new System.Windows.Forms.Label();
			this.Line1 = new System.Windows.Forms.Label();
			this.Frame1 = new System.Windows.Forms.GroupBox();
			this.Check4 = new System.Windows.Forms.CheckBox();
			this.Check3 = new System.Windows.Forms.CheckBox();
			this.Check2 = new System.Windows.Forms.CheckBox();
			this.Check1 = new System.Windows.Forms.CheckBox();
			this.txtVoucherDate = new Syncfusion.WinForms.Input.SfDateTimeEdit();
			this._txtCommonTextBox_1 = new System.Windows.Forms.TextBox();
			this._lblCommonLabel_5 = new System.Windows.Forms.Label();
			this._lblCommonLabel_6 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_7 = new System.Windows.Forms.TextBox();
			this._txtDisplayLabel_1 = new System.Windows.Forms.Label();
			this._lblCommonLabel_0 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_3 = new System.Windows.Forms.TextBox();
			this._txtDisplayLabel_6 = new System.Windows.Forms.Label();
			this._lblCommonLabel_1 = new System.Windows.Forms.Label();
			this._lblCommonLabel_8 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_9 = new System.Windows.Forms.TextBox();
			this._txtDisplayLabel_2 = new System.Windows.Forms.Label();
			this.fraVoucherType = new UpgradeHelpers.Gui.ShapeHelper();
			// //((System.ComponentModel.ISupportInitialize) this.TabControlPage2).BeginInit();
			// //((System.ComponentModel.ISupportInitialize) this.TabControlPage1).BeginInit();
			// //((System.ComponentModel.ISupportInitialize) this.tabMain).BeginInit();
			this.tabMain.SuspendLayout();
			this.TabControlPage2.SuspendLayout();
			this.Frame3.SuspendLayout();
			this.Frame2.SuspendLayout();
			this.TabControlPage1.SuspendLayout();
			this.grdVoucherDetails.SuspendLayout();
			this.cmbMastersList.SuspendLayout();
			this.frameBottom.SuspendLayout();
			this.fraPayments.SuspendLayout();
			this.Frame1.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabMain
			// 
			this.tabMain.AllowDrop = true;
			this.tabMain.Controls.Add(this.TabControlPage2);
			this.tabMain.Controls.Add(this.TabControlPage1);
			this.tabMain.Location = new System.Drawing.Point(8, 184);
			this.tabMain.Name = "tabMain";
			//
			this.tabMain.Size = new System.Drawing.Size(817, 265);
			this.tabMain.TabIndex = 35;
			// 
			// TabControlPage2
			// 
			this.TabControlPage2.AllowDrop = true;
			this.TabControlPage2.Controls.Add(this.Frame3);
			this.TabControlPage2.Controls.Add(this.Frame2);
			this.TabControlPage2.Location = new System.Drawing.Point(-4664, 26);
			this.TabControlPage2.Name = "TabControlPage2";
			//
			this.TabControlPage2.Size = new System.Drawing.Size(813, 237);
			this.TabControlPage2.TabIndex = 37;
			this.TabControlPage2.Visible = false;
			// 
			// Frame3
			// 
			this.Frame3.AllowDrop = true;
			this.Frame3.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.Frame3.Controls.Add(this.txtNumbering);
			this.Frame3.Controls.Add(this._lblCommonLabel_12);
			this.Frame3.Controls.Add(this._lblCommonLabel_13);
			this.Frame3.Controls.Add(this._lblCommonLabel_14);
			this.Frame3.Controls.Add(this._lblCommonLabel_15);
			this.Frame3.Controls.Add(this.txtPerforation);
			this.Frame3.Controls.Add(this.txtCoverNo);
			this.Frame3.Controls.Add(this.txtCoverColor);
			this.Frame3.Enabled = true;
			this.Frame3.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Frame3.Location = new System.Drawing.Point(352, 16);
			this.Frame3.Name = "Frame3";
			this.Frame3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Frame3.Size = new System.Drawing.Size(329, 121);
			this.Frame3.TabIndex = 49;
			this.Frame3.Visible = true;
			// 
			// txtNumbering
			// 
			this.txtNumbering.AllowDrop = true;
			this.txtNumbering.BackColor = System.Drawing.Color.White;
			// this.txtNumbering.bolAllowDecimal = false;
			this.txtNumbering.ForeColor = System.Drawing.Color.Black;
			this.txtNumbering.Location = new System.Drawing.Point(72, 16);
			// this.txtNumbering.mDropDownType = (System.Windows.Forms.TextBox.DropDownTypes) 0;
			this.txtNumbering.Name = "txtNumbering";
			this.txtNumbering.Size = new System.Drawing.Size(241, 19);
			this.txtNumbering.TabIndex = 50;
			this.txtNumbering.Text = "";
			// this.this.txtNumbering.Watermark = "";
			// 
			// _lblCommonLabel_12
			// 
			this._lblCommonLabel_12.AllowDrop = true;
			this._lblCommonLabel_12.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_12.Text = "Cover Color";
			this._lblCommonLabel_12.ForeColor = System.Drawing.Color.Black;
			this._lblCommonLabel_12.Location = new System.Drawing.Point(8, 88);
			this._lblCommonLabel_12.Name = "_lblCommonLabel_12";
			this._lblCommonLabel_12.Size = new System.Drawing.Size(57, 14);
			this._lblCommonLabel_12.TabIndex = 51;
			// 
			// _lblCommonLabel_13
			// 
			this._lblCommonLabel_13.AllowDrop = true;
			this._lblCommonLabel_13.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_13.Text = "Numbering";
			this._lblCommonLabel_13.ForeColor = System.Drawing.Color.Black;
			this._lblCommonLabel_13.Location = new System.Drawing.Point(8, 16);
			this._lblCommonLabel_13.Name = "_lblCommonLabel_13";
			this._lblCommonLabel_13.Size = new System.Drawing.Size(51, 14);
			this._lblCommonLabel_13.TabIndex = 52;
			// 
			// _lblCommonLabel_14
			// 
			this._lblCommonLabel_14.AllowDrop = true;
			this._lblCommonLabel_14.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_14.Text = "Cover No.";
			this._lblCommonLabel_14.ForeColor = System.Drawing.Color.Black;
			this._lblCommonLabel_14.Location = new System.Drawing.Point(8, 64);
			this._lblCommonLabel_14.Name = "_lblCommonLabel_14";
			this._lblCommonLabel_14.Size = new System.Drawing.Size(48, 14);
			this._lblCommonLabel_14.TabIndex = 53;
			// 
			// _lblCommonLabel_15
			// 
			this._lblCommonLabel_15.AllowDrop = true;
			this._lblCommonLabel_15.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_15.Text = "Perforation";
			this._lblCommonLabel_15.ForeColor = System.Drawing.Color.Black;
			this._lblCommonLabel_15.Location = new System.Drawing.Point(8, 40);
			this._lblCommonLabel_15.Name = "_lblCommonLabel_15";
			this._lblCommonLabel_15.Size = new System.Drawing.Size(53, 14);
			this._lblCommonLabel_15.TabIndex = 54;
			// 
			// txtPerforation
			// 
			this.txtPerforation.AllowDrop = true;
			this.txtPerforation.BackColor = System.Drawing.Color.White;
			// this.txtPerforation.bolAllowDecimal = false;
			this.txtPerforation.ForeColor = System.Drawing.Color.Black;
			this.txtPerforation.Location = new System.Drawing.Point(72, 40);
			// this.txtPerforation.mDropDownType = (System.Windows.Forms.TextBox.DropDownTypes) 0;
			this.txtPerforation.Name = "txtPerforation";
			this.txtPerforation.Size = new System.Drawing.Size(241, 19);
			this.txtPerforation.TabIndex = 55;
			this.txtPerforation.Text = "";
			// this.this.txtPerforation.Watermark = "";
			// 
			// txtCoverNo
			// 
			this.txtCoverNo.AllowDrop = true;
			this.txtCoverNo.BackColor = System.Drawing.Color.White;
			// this.txtCoverNo.bolAllowDecimal = false;
			this.txtCoverNo.ForeColor = System.Drawing.Color.Black;
			this.txtCoverNo.Location = new System.Drawing.Point(72, 64);
			// this.txtCoverNo.mDropDownType = (System.Windows.Forms.TextBox.DropDownTypes) 0;
			this.txtCoverNo.Name = "txtCoverNo";
			this.txtCoverNo.Size = new System.Drawing.Size(241, 19);
			this.txtCoverNo.TabIndex = 56;
			this.txtCoverNo.Text = "";
			// this.this.txtCoverNo.Watermark = "";
			// 
			// txtCoverColor
			// 
			this.txtCoverColor.AllowDrop = true;
			this.txtCoverColor.BackColor = System.Drawing.Color.White;
			// this.txtCoverColor.bolAllowDecimal = false;
			this.txtCoverColor.ForeColor = System.Drawing.Color.Black;
			this.txtCoverColor.Location = new System.Drawing.Point(72, 88);
			// this.txtCoverColor.mDropDownType = (System.Windows.Forms.TextBox.DropDownTypes) 0;
			this.txtCoverColor.Name = "txtCoverColor";
			this.txtCoverColor.Size = new System.Drawing.Size(241, 19);
			this.txtCoverColor.TabIndex = 57;
			this.txtCoverColor.Text = "";
			// this.this.txtCoverColor.Watermark = "";
			// 
			// Frame2
			// 
			this.Frame2.AllowDrop = true;
			this.Frame2.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.Frame2.Controls.Add(this.txt1Copy);
			this.Frame2.Controls.Add(this._lblCommonLabel_2);
			this.Frame2.Controls.Add(this._lblCommonLabel_3);
			this.Frame2.Controls.Add(this._lblCommonLabel_4);
			this.Frame2.Controls.Add(this._lblCommonLabel_7);
			this.Frame2.Controls.Add(this.txt2Copy);
			this.Frame2.Controls.Add(this.txt3Copy);
			this.Frame2.Controls.Add(this.txt4Copy);
			this.Frame2.Enabled = true;
			this.Frame2.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Frame2.Location = new System.Drawing.Point(16, 16);
			this.Frame2.Name = "Frame2";
			this.Frame2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Frame2.Size = new System.Drawing.Size(329, 121);
			this.Frame2.TabIndex = 40;
			this.Frame2.Visible = true;
			// 
			// txt1Copy
			// 
			this.txt1Copy.AllowDrop = true;
			this.txt1Copy.BackColor = System.Drawing.Color.White;
			// this.txt1Copy.bolAllowDecimal = false;
			this.txt1Copy.ForeColor = System.Drawing.Color.Black;
			this.txt1Copy.Location = new System.Drawing.Point(64, 16);
			// this.txt1Copy.mDropDownType = (System.Windows.Forms.TextBox.DropDownTypes) 0;
			this.txt1Copy.Name = "txt1Copy";
			this.txt1Copy.Size = new System.Drawing.Size(241, 19);
			this.txt1Copy.TabIndex = 45;
			this.txt1Copy.Text = "";
			// this.this.txt1Copy.Watermark = "";
			// 
			// _lblCommonLabel_2
			// 
			this._lblCommonLabel_2.AllowDrop = true;
			this._lblCommonLabel_2.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_2.Text = "4th Copy";
			this._lblCommonLabel_2.ForeColor = System.Drawing.Color.Black;
			this._lblCommonLabel_2.Location = new System.Drawing.Point(8, 88);
			this._lblCommonLabel_2.Name = "_lblCommonLabel_2";
			this._lblCommonLabel_2.Size = new System.Drawing.Size(43, 14);
			this._lblCommonLabel_2.TabIndex = 41;
			// 
			// _lblCommonLabel_3
			// 
			this._lblCommonLabel_3.AllowDrop = true;
			this._lblCommonLabel_3.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_3.Text = "1st Copy";
			this._lblCommonLabel_3.ForeColor = System.Drawing.Color.Black;
			this._lblCommonLabel_3.Location = new System.Drawing.Point(8, 16);
			this._lblCommonLabel_3.Name = "_lblCommonLabel_3";
			this._lblCommonLabel_3.Size = new System.Drawing.Size(43, 14);
			this._lblCommonLabel_3.TabIndex = 42;
			// 
			// _lblCommonLabel_4
			// 
			this._lblCommonLabel_4.AllowDrop = true;
			this._lblCommonLabel_4.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_4.Text = "3rd Copy";
			this._lblCommonLabel_4.ForeColor = System.Drawing.Color.Black;
			this._lblCommonLabel_4.Location = new System.Drawing.Point(8, 64);
			this._lblCommonLabel_4.Name = "_lblCommonLabel_4";
			this._lblCommonLabel_4.Size = new System.Drawing.Size(44, 14);
			this._lblCommonLabel_4.TabIndex = 43;
			// 
			// _lblCommonLabel_7
			// 
			this._lblCommonLabel_7.AllowDrop = true;
			this._lblCommonLabel_7.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_7.Text = "2nd Copy";
			this._lblCommonLabel_7.ForeColor = System.Drawing.Color.Black;
			this._lblCommonLabel_7.Location = new System.Drawing.Point(8, 40);
			this._lblCommonLabel_7.Name = "_lblCommonLabel_7";
			this._lblCommonLabel_7.Size = new System.Drawing.Size(46, 14);
			this._lblCommonLabel_7.TabIndex = 44;
			// 
			// txt2Copy
			// 
			this.txt2Copy.AllowDrop = true;
			this.txt2Copy.BackColor = System.Drawing.Color.White;
			// this.txt2Copy.bolAllowDecimal = false;
			this.txt2Copy.ForeColor = System.Drawing.Color.Black;
			this.txt2Copy.Location = new System.Drawing.Point(64, 40);
			// this.txt2Copy.mDropDownType = (System.Windows.Forms.TextBox.DropDownTypes) 0;
			this.txt2Copy.Name = "txt2Copy";
			this.txt2Copy.Size = new System.Drawing.Size(241, 19);
			this.txt2Copy.TabIndex = 46;
			this.txt2Copy.Text = "";
			// this.this.txt2Copy.Watermark = "";
			// 
			// txt3Copy
			// 
			this.txt3Copy.AllowDrop = true;
			this.txt3Copy.BackColor = System.Drawing.Color.White;
			// this.txt3Copy.bolAllowDecimal = false;
			this.txt3Copy.ForeColor = System.Drawing.Color.Black;
			this.txt3Copy.Location = new System.Drawing.Point(64, 64);
			// this.txt3Copy.mDropDownType = (System.Windows.Forms.TextBox.DropDownTypes) 0;
			this.txt3Copy.Name = "txt3Copy";
			this.txt3Copy.Size = new System.Drawing.Size(241, 19);
			this.txt3Copy.TabIndex = 47;
			this.txt3Copy.Text = "";
			// this.this.txt3Copy.Watermark = "";
			// 
			// txt4Copy
			// 
			this.txt4Copy.AllowDrop = true;
			this.txt4Copy.BackColor = System.Drawing.Color.White;
			// this.txt4Copy.bolAllowDecimal = false;
			this.txt4Copy.ForeColor = System.Drawing.Color.Black;
			this.txt4Copy.Location = new System.Drawing.Point(64, 88);
			// this.txt4Copy.mDropDownType = (System.Windows.Forms.TextBox.DropDownTypes) 0;
			this.txt4Copy.Name = "txt4Copy";
			this.txt4Copy.Size = new System.Drawing.Size(241, 19);
			this.txt4Copy.TabIndex = 48;
			this.txt4Copy.Text = "";
			// this.this.txt4Copy.Watermark = "";
			// 
			// TabControlPage1
			// 
			this.TabControlPage1.AllowDrop = true;
			this.TabControlPage1.Controls.Add(this.grdVoucherDetails);
			this.TabControlPage1.Controls.Add(this.cmbMastersList);
			this.TabControlPage1.Location = new System.Drawing.Point(2, 26);
			this.TabControlPage1.Name = "TabControlPage1";
			//
			this.TabControlPage1.Size = new System.Drawing.Size(813, 237);
			this.TabControlPage1.TabIndex = 36;
			// 
			// grdVoucherDetails
			// 
			this.grdVoucherDetails.AllowAddNew = true;
			this.grdVoucherDetails.AllowDelete = true;
			this.grdVoucherDetails.AllowDrop = true;
			this.grdVoucherDetails.BackColor = System.Drawing.Color.FromArgb(212, 208, 200);
			this.grdVoucherDetails.CellTipsWidth = 0;
			this.grdVoucherDetails.Location = new System.Drawing.Point(0, 0);
			this.grdVoucherDetails.Name = "grdVoucherDetails";
			this.grdVoucherDetails.RowDivider.Color = System.Drawing.Color.FromArgb(212, 208, 200);
			this.grdVoucherDetails.Size = new System.Drawing.Size(703, 232);
			this.grdVoucherDetails.TabIndex = 38;
			this.grdVoucherDetails.Columns.Add(this.Column_0_grdVoucherDetails);
			this.grdVoucherDetails.Columns.Add(this.Column_1_grdVoucherDetails);
			this.grdVoucherDetails.AfterColUpdate += new C1.Win.C1TrueDBGrid.ColEventHandler(this.grdVoucherDetails_AfterColUpdate);
			this.grdVoucherDetails.GotFocus += new System.EventHandler(this.grdVoucherDetails_GotFocus);
			this.grdVoucherDetails.RowColChange += new C1.Win.C1TrueDBGrid.RowColChangeEventHandler(this.grdVoucherDetails_RowColChange);
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
			// cmbMastersList
			// 
			this.cmbMastersList.AllowDrop = true;
			this.cmbMastersList.ColumnHeaders = true;
			this.cmbMastersList.Enabled = true;
			this.cmbMastersList.Location = new System.Drawing.Point(0, 0);
			this.cmbMastersList.Name = "cmbMastersList";
			this.cmbMastersList.Size = new System.Drawing.Size(227, 97);
			this.cmbMastersList.TabIndex = 39;
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
			// _optVoucherType_0
			// 
			this._optVoucherType_0.AllowDrop = true;
			this._optVoucherType_0.Appearance = System.Windows.Forms.Appearance.Normal;
			this._optVoucherType_0.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._optVoucherType_0.CausesValidation = true;
			this._optVoucherType_0.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._optVoucherType_0.Checked = true;
			this._optVoucherType_0.Enabled = true;
			this._optVoucherType_0.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 178);
			this._optVoucherType_0.ForeColor = System.Drawing.SystemColors.ControlText;
			this._optVoucherType_0.Location = new System.Drawing.Point(484, 145);
			this._optVoucherType_0.Name = "_optVoucherType_0";
			this._optVoucherType_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._optVoucherType_0.Size = new System.Drawing.Size(61, 16);
			this._optVoucherType_0.TabIndex = 34;
			this._optVoucherType_0.TabStop = true;
			this._optVoucherType_0.Text = "C&redit";
			this._optVoucherType_0.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._optVoucherType_0.Visible = false;
			this._optVoucherType_0.CheckedChanged += new System.EventHandler(this.optVoucherType_CheckedChanged);
			// 
			// _optVoucherType_1
			// 
			this._optVoucherType_1.AllowDrop = true;
			this._optVoucherType_1.Appearance = System.Windows.Forms.Appearance.Normal;
			this._optVoucherType_1.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._optVoucherType_1.CausesValidation = true;
			this._optVoucherType_1.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._optVoucherType_1.Checked = false;
			this._optVoucherType_1.Enabled = true;
			this._optVoucherType_1.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 178);
			this._optVoucherType_1.ForeColor = System.Drawing.SystemColors.ControlText;
			this._optVoucherType_1.Location = new System.Drawing.Point(549, 145);
			this._optVoucherType_1.Name = "_optVoucherType_1";
			this._optVoucherType_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._optVoucherType_1.Size = new System.Drawing.Size(53, 16);
			this._optVoucherType_1.TabIndex = 33;
			this._optVoucherType_1.TabStop = true;
			this._optVoucherType_1.Text = "&Cash";
			this._optVoucherType_1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._optVoucherType_1.Visible = false;
			this._optVoucherType_1.CheckedChanged += new System.EventHandler(this.optVoucherType_CheckedChanged);
			// 
			// frameBottom
			// 
			this.frameBottom.AllowDrop = true;
			this.frameBottom.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.frameBottom.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.frameBottom.Controls.Add(this.fraPayments);
			this.frameBottom.Controls.Add(this._lblCommonLabel_9);
			this.frameBottom.Controls.Add(this.txtRemark);
			this.frameBottom.Controls.Add(this.txtPercentDiscount);
			this.frameBottom.Controls.Add(this.txtDiscount);
			this.frameBottom.Controls.Add(this.txtNetAmount);
			this.frameBottom.Controls.Add(this._lblCommonLabel_11);
			this.frameBottom.Controls.Add(this._lblCommonLabel_10);
			this.frameBottom.Controls.Add(this.Line1);
			this.frameBottom.Enabled = true;
			this.frameBottom.ForeColor = System.Drawing.SystemColors.ControlText;
			this.frameBottom.Location = new System.Drawing.Point(8, 448);
			this.frameBottom.Name = "frameBottom";
			this.frameBottom.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.frameBottom.Size = new System.Drawing.Size(913, 81);
			this.frameBottom.TabIndex = 18;
			this.frameBottom.Text = "Frame2";
			this.frameBottom.Visible = true;
			// 
			// fraPayments
			// 
			this.fraPayments.AllowDrop = true;
			this.fraPayments.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.fraPayments.Controls.Add(this._txtCommonTextBox_5);
			this.fraPayments.Controls.Add(this.txtCashAmt);
			this.fraPayments.Controls.Add(this._txtCommonTextBox_6);
			this.fraPayments.Controls.Add(this.txtCCAmt);
			this.fraPayments.Controls.Add(this._txtDisplayLabel_3);
			this.fraPayments.Controls.Add(this._txtDisplayLabel_15);
			this.fraPayments.Enabled = true;
			this.fraPayments.ForeColor = System.Drawing.SystemColors.ControlText;
			this.fraPayments.Location = new System.Drawing.Point(632, 5);
			this.fraPayments.Name = "fraPayments";
			this.fraPayments.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.fraPayments.Size = new System.Drawing.Size(261, 67);
			this.fraPayments.TabIndex = 19;
			this.fraPayments.Visible = true;
			// 
			// _txtCommonTextBox_5
			// 
			this._txtCommonTextBox_5.AllowDrop = true;
			this._txtCommonTextBox_5.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_5.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_5.Location = new System.Drawing.Point(4, 10);
			this._txtCommonTextBox_5.Name = "_txtCommonTextBox_5";
			// this._txtCommonTextBox_5.ShowButton = true;
			this._txtCommonTextBox_5.Size = new System.Drawing.Size(67, 23);
			this._txtCommonTextBox_5.TabIndex = 20;
			this._txtCommonTextBox_5.Text = "";
			// this.this._txtCommonTextBox_5.Watermark = "";
			// this.this._txtCommonTextBox_5.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_5.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// txtCashAmt
			// 
			this.txtCashAmt.AllowDrop = true;
			// this.txtCashAmt.DisplayFormat = "####0.000###;;0.000;0.000";
			// this.txtCashAmt.Format = "###########0.000";
			this.txtCashAmt.Location = new System.Drawing.Point(170, 10);
			// this.txtCashAmt.MaxValue = 2147483647;
			// this.txtCashAmt.MinValue = 0;
			this.txtCashAmt.Name = "txtCashAmt";
			this.txtCashAmt.Size = new System.Drawing.Size(87, 23);
			this.txtCashAmt.TabIndex = 21;
			this.txtCashAmt.Text = "0.000";
			// this.txtCashAmt.Leave += new System.EventHandler(this.txtCashAmt_Leave);
			// 
			// _txtCommonTextBox_6
			// 
			this._txtCommonTextBox_6.AllowDrop = true;
			this._txtCommonTextBox_6.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_6.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_6.Location = new System.Drawing.Point(4, 38);
			this._txtCommonTextBox_6.Name = "_txtCommonTextBox_6";
			// this._txtCommonTextBox_6.ShowButton = true;
			this._txtCommonTextBox_6.Size = new System.Drawing.Size(67, 23);
			this._txtCommonTextBox_6.TabIndex = 22;
			this._txtCommonTextBox_6.Text = "";
			// this.this._txtCommonTextBox_6.Watermark = "";
			// this.this._txtCommonTextBox_6.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_6.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// txtCCAmt
			// 
			this.txtCCAmt.AllowDrop = true;
			// this.txtCCAmt.DisplayFormat = "####0.000###;;0.000;0.000";
			// this.txtCCAmt.Format = "###########0.000";
			this.txtCCAmt.Location = new System.Drawing.Point(170, 38);
			// this.txtCCAmt.MaxValue = 2147483647;
			// this.txtCCAmt.MinValue = 0;
			this.txtCCAmt.Name = "txtCCAmt";
			this.txtCCAmt.Size = new System.Drawing.Size(87, 23);
			this.txtCCAmt.TabIndex = 23;
			this.txtCCAmt.Text = "0.000";
			// this.txtCCAmt.Leave += new System.EventHandler(this.txtCCAmt_Leave);
			// 
			// _txtDisplayLabel_3
			// 
			this._txtDisplayLabel_3.AllowDrop = true;
			this._txtDisplayLabel_3.Location = new System.Drawing.Point(72, 10);
			this._txtDisplayLabel_3.Name = "_txtDisplayLabel_3";
			this._txtDisplayLabel_3.Size = new System.Drawing.Size(97, 23);
			this._txtDisplayLabel_3.TabIndex = 24;
			this._txtDisplayLabel_3.TabStop = false;
			// 
			// _txtDisplayLabel_15
			// 
			this._txtDisplayLabel_15.AllowDrop = true;
			this._txtDisplayLabel_15.Location = new System.Drawing.Point(72, 38);
			this._txtDisplayLabel_15.Name = "_txtDisplayLabel_15";
			this._txtDisplayLabel_15.Size = new System.Drawing.Size(97, 23);
			this._txtDisplayLabel_15.TabIndex = 25;
			this._txtDisplayLabel_15.TabStop = false;
			// 
			// _lblCommonLabel_9
			// 
			this._lblCommonLabel_9.AllowDrop = true;
			this._lblCommonLabel_9.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_9.Text = "Narration";
			this._lblCommonLabel_9.ForeColor = System.Drawing.Color.Black;
			this._lblCommonLabel_9.Location = new System.Drawing.Point(8, 0);
			this._lblCommonLabel_9.Name = "_lblCommonLabel_9";
			this._lblCommonLabel_9.Size = new System.Drawing.Size(45, 13);
			this._lblCommonLabel_9.TabIndex = 26;
			// 
			// txtRemark
			// 
			this.txtRemark.AllowDrop = true;
			this.txtRemark.BackColor = System.Drawing.Color.White;
			// this.txtRemark.bolAllowDecimal = false;
			this.txtRemark.ForeColor = System.Drawing.Color.Black;
			this.txtRemark.Location = new System.Drawing.Point(0, 21);
			// this.txtRemark.mDropDownType = (System.Windows.Forms.TextBox.FormatBoxDropDownTypes) 0;
			this.txtRemark.Name = "txtRemark";
			this.txtRemark.Size = new System.Drawing.Size(339, 55);
			this.txtRemark.TabIndex = 27;
			this.txtRemark.Text = "";
			// 
			// txtPercentDiscount
			// 
			this.txtPercentDiscount.AllowDrop = true;
			// this.txtPercentDiscount.DisplayFormat = "#####0.######;;; ";
			// this.txtPercentDiscount.Format = "#####0.######";
			this.txtPercentDiscount.Location = new System.Drawing.Point(480, 13);
			// this.txtPercentDiscount.MaxValue = 100;
			// this.txtPercentDiscount.MinValue = 0;
			this.txtPercentDiscount.Name = "txtPercentDiscount";
			this.txtPercentDiscount.Size = new System.Drawing.Size(49, 23);
			this.txtPercentDiscount.TabIndex = 28;
			// this.txtPercentDiscount.Leave += new System.EventHandler(this.txtPercentDiscount_Leave);
			// 
			// txtDiscount
			// 
			this.txtDiscount.AllowDrop = true;
			// this.txtDiscount.DisplayFormat = "####0.000###;;0.000;0.000";
			// this.txtDiscount.Format = "###########0.000";
			this.txtDiscount.Location = new System.Drawing.Point(530, 13);
			// this.txtDiscount.MaxValue = 2147483647;
			// this.txtDiscount.MinValue = 0;
			this.txtDiscount.Name = "txtDiscount";
			this.txtDiscount.Size = new System.Drawing.Size(87, 23);
			this.txtDiscount.TabIndex = 29;
			this.txtDiscount.Text = "0.000";
			// this.txtDiscount.Leave += new System.EventHandler(this.txtDiscount_Leave);
			// 
			// txtNetAmount
			// 
			this.txtNetAmount.AllowDrop = true;
			// this.txtNetAmount.DisplayFormat = "####0.000###;;0.000;0.000";
			this.txtNetAmount.Enabled = false;
			// this.txtNetAmount.Format = "###########0.000";
			this.txtNetAmount.Location = new System.Drawing.Point(530, 43);
			// this.txtNetAmount.MaxValue = 2147483647;
			// this.txtNetAmount.MinValue = -2147483648;
			this.txtNetAmount.Name = "txtNetAmount";
			this.txtNetAmount.Size = new System.Drawing.Size(87, 23);
			this.txtNetAmount.TabIndex = 30;
			this.txtNetAmount.Text = "0.000";
			// 
			// _lblCommonLabel_11
			// 
			this._lblCommonLabel_11.AllowDrop = true;
			this._lblCommonLabel_11.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_11.Text = "Total";
			this._lblCommonLabel_11.ForeColor = System.Drawing.Color.Black;
			this._lblCommonLabel_11.Location = new System.Drawing.Point(372, 49);
			// // this._lblCommonLabel_11.mLabelId = 449;
			this._lblCommonLabel_11.Name = "_lblCommonLabel_11";
			this._lblCommonLabel_11.Size = new System.Drawing.Size(32, 16);
			this._lblCommonLabel_11.TabIndex = 31;
			// 
			// _lblCommonLabel_10
			// 
			this._lblCommonLabel_10.AllowDrop = true;
			this._lblCommonLabel_10.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_10.Text = "Discount (%)";
			this._lblCommonLabel_10.ForeColor = System.Drawing.Color.Black;
			this._lblCommonLabel_10.Location = new System.Drawing.Point(370, 17);
			// // this._lblCommonLabel_10.mLabelId = 871;
			this._lblCommonLabel_10.Name = "_lblCommonLabel_10";
			this._lblCommonLabel_10.Size = new System.Drawing.Size(75, 16);
			this._lblCommonLabel_10.TabIndex = 32;
			// 
			// Line1
			// 
			this.Line1.AllowDrop = true;
			this.Line1.BackColor = System.Drawing.Color.Red;
			this.Line1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Line1.Enabled = false;
			this.Line1.ForeColor = System.Drawing.Color.Black;
			this.Line1.Location = new System.Drawing.Point(368, 39);
			this.Line1.Name = "Line1";
			this.Line1.Size = new System.Drawing.Size(249, 1);
			this.Line1.Text = "Line1";
			this.Line1.Visible = true;
			// 
			// Frame1
			// 
			this.Frame1.AllowDrop = true;
			this.Frame1.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.Frame1.Controls.Add(this.Check4);
			this.Frame1.Controls.Add(this.Check3);
			this.Frame1.Controls.Add(this.Check2);
			this.Frame1.Controls.Add(this.Check1);
			this.Frame1.Enabled = true;
			this.Frame1.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Frame1.Location = new System.Drawing.Point(8, 128);
			this.Frame1.Name = "Frame1";
			this.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Frame1.Size = new System.Drawing.Size(297, 41);
			this.Frame1.TabIndex = 13;
			this.Frame1.Text = "Lamination";
			this.Frame1.Visible = true;
			// 
			// Check4
			// 
			this.Check4.AllowDrop = true;
			this.Check4.Appearance = System.Windows.Forms.Appearance.Normal;
			this.Check4.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.Check4.CausesValidation = true;
			this.Check4.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.Check4.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this.Check4.Enabled = true;
			this.Check4.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Check4.Location = new System.Drawing.Point(232, 16);
			this.Check4.Name = "Check4";
			this.Check4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Check4.Size = new System.Drawing.Size(57, 13);
			this.Check4.TabIndex = 17;
			this.Check4.TabStop = true;
			this.Check4.Text = "Matt";
			this.Check4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.Check4.Visible = true;
			// 
			// Check3
			// 
			this.Check3.AllowDrop = true;
			this.Check3.Appearance = System.Windows.Forms.Appearance.Normal;
			this.Check3.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.Check3.CausesValidation = true;
			this.Check3.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.Check3.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this.Check3.Enabled = true;
			this.Check3.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Check3.Location = new System.Drawing.Point(160, 16);
			this.Check3.Name = "Check3";
			this.Check3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Check3.Size = new System.Drawing.Size(81, 13);
			this.Check3.TabIndex = 16;
			this.Check3.TabStop = true;
			this.Check3.Text = "Glossy";
			this.Check3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.Check3.Visible = true;
			// 
			// Check2
			// 
			this.Check2.AllowDrop = true;
			this.Check2.Appearance = System.Windows.Forms.Appearance.Normal;
			this.Check2.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.Check2.CausesValidation = true;
			this.Check2.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.Check2.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this.Check2.Enabled = true;
			this.Check2.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Check2.Location = new System.Drawing.Point(88, 16);
			this.Check2.Name = "Check2";
			this.Check2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Check2.Size = new System.Drawing.Size(73, 17);
			this.Check2.TabIndex = 15;
			this.Check2.TabStop = true;
			this.Check2.Text = "Two Side";
			this.Check2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.Check2.Visible = true;
			// 
			// Check1
			// 
			this.Check1.AllowDrop = true;
			this.Check1.Appearance = System.Windows.Forms.Appearance.Normal;
			this.Check1.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.Check1.CausesValidation = true;
			this.Check1.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.Check1.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this.Check1.Enabled = true;
			this.Check1.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Check1.Location = new System.Drawing.Point(16, 16);
			this.Check1.Name = "Check1";
			this.Check1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Check1.Size = new System.Drawing.Size(65, 17);
			this.Check1.TabIndex = 14;
			this.Check1.TabStop = true;
			this.Check1.Text = "One Side";
			this.Check1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.Check1.Visible = true;
			// 
			// txtVoucherDate
			// 
			this.txtVoucherDate.AllowDrop = true;
			// this.txtVoucherDate.CheckDateRange = false;
			this.txtVoucherDate.Location = new System.Drawing.Point(96, 60);
			// this.txtVoucherDate.MaxDate = 2958465;
			// this.txtVoucherDate.MinDate = 32874;
			this.txtVoucherDate.Name = "txtVoucherDate";
			this.txtVoucherDate.Size = new System.Drawing.Size(102, 19);
			this.txtVoucherDate.TabIndex = 2;
			// this.txtVoucherDate.Text = "18-Jul-2001";
			// this.txtVoucherDate.Value = 37090;
			// 
			// _txtCommonTextBox_1
			// 
			this._txtCommonTextBox_1.AllowDrop = true;
			this._txtCommonTextBox_1.BackColor = System.Drawing.Color.White;
			// this._txtCommonTextBox_1.bolNumericOnly = true;
			this._txtCommonTextBox_1.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_1.Location = new System.Drawing.Point(96, 16);
			this._txtCommonTextBox_1.MaxLength = 4;
			this._txtCommonTextBox_1.Name = "_txtCommonTextBox_1";
			// this._txtCommonTextBox_1.ShowButton = true;
			this._txtCommonTextBox_1.Size = new System.Drawing.Size(101, 19);
			this._txtCommonTextBox_1.TabIndex = 1;
			this._txtCommonTextBox_1.Text = "";
			// this.this._txtCommonTextBox_1.Watermark = "";
			// this.this._txtCommonTextBox_1.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_1.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _lblCommonLabel_5
			// 
			this._lblCommonLabel_5.AllowDrop = true;
			this._lblCommonLabel_5.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_5.Text = "Voucher No.";
			this._lblCommonLabel_5.ForeColor = System.Drawing.Color.Black;
			this._lblCommonLabel_5.Location = new System.Drawing.Point(16, 40);
			// // this._lblCommonLabel_5.mLabelId = 850;
			this._lblCommonLabel_5.Name = "_lblCommonLabel_5";
			this._lblCommonLabel_5.Size = new System.Drawing.Size(61, 14);
			this._lblCommonLabel_5.TabIndex = 5;
			// 
			// _lblCommonLabel_6
			// 
			this._lblCommonLabel_6.AllowDrop = true;
			this._lblCommonLabel_6.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_6.Text = "Voucher Date";
			this._lblCommonLabel_6.ForeColor = System.Drawing.Color.Black;
			this._lblCommonLabel_6.Location = new System.Drawing.Point(16, 61);
			// // this._lblCommonLabel_6.mLabelId = 848;
			this._lblCommonLabel_6.Name = "_lblCommonLabel_6";
			this._lblCommonLabel_6.Size = new System.Drawing.Size(67, 14);
			this._lblCommonLabel_6.TabIndex = 6;
			// 
			// _txtCommonTextBox_7
			// 
			this._txtCommonTextBox_7.AllowDrop = true;
			this._txtCommonTextBox_7.BackColor = System.Drawing.Color.FromArgb(239, 239, 239);
			// this._txtCommonTextBox_7.bolNumericOnly = true;
			this._txtCommonTextBox_7.Enabled = false;
			this._txtCommonTextBox_7.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_7.Location = new System.Drawing.Point(96, 38);
			this._txtCommonTextBox_7.MaxLength = 11;
			this._txtCommonTextBox_7.Name = "_txtCommonTextBox_7";
			this._txtCommonTextBox_7.Size = new System.Drawing.Size(102, 19);
			this._txtCommonTextBox_7.TabIndex = 7;
			this._txtCommonTextBox_7.Text = "";
			// this.this._txtCommonTextBox_7.Watermark = "";
			// this.this._txtCommonTextBox_7.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_7.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _txtDisplayLabel_1
			// 
			this._txtDisplayLabel_1.AllowDrop = true;
			this._txtDisplayLabel_1.Location = new System.Drawing.Point(202, 16);
			this._txtDisplayLabel_1.Name = "_txtDisplayLabel_1";
			this._txtDisplayLabel_1.Size = new System.Drawing.Size(275, 19);
			this._txtDisplayLabel_1.TabIndex = 8;
			// 
			// _lblCommonLabel_0
			// 
			this._lblCommonLabel_0.AllowDrop = true;
			this._lblCommonLabel_0.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_0.Text = "Customer";
			this._lblCommonLabel_0.ForeColor = System.Drawing.Color.Black;
			this._lblCommonLabel_0.Location = new System.Drawing.Point(16, 84);
			// // this._lblCommonLabel_0.mLabelId = 848;
			this._lblCommonLabel_0.Name = "_lblCommonLabel_0";
			this._lblCommonLabel_0.Size = new System.Drawing.Size(46, 14);
			this._lblCommonLabel_0.TabIndex = 9;
			// 
			// _txtCommonTextBox_3
			// 
			this._txtCommonTextBox_3.AllowDrop = true;
			this._txtCommonTextBox_3.BackColor = System.Drawing.Color.White;
			// this._txtCommonTextBox_3.bolNumericOnly = true;
			this._txtCommonTextBox_3.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_3.Location = new System.Drawing.Point(96, 82);
			this._txtCommonTextBox_3.MaxLength = 20;
			this._txtCommonTextBox_3.Name = "_txtCommonTextBox_3";
			// this._txtCommonTextBox_3.ShowButton = true;
			this._txtCommonTextBox_3.Size = new System.Drawing.Size(101, 19);
			this._txtCommonTextBox_3.TabIndex = 3;
			this._txtCommonTextBox_3.Text = "";
			// this.this._txtCommonTextBox_3.Watermark = "";
			// this.this._txtCommonTextBox_3.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_3.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _txtDisplayLabel_6
			// 
			this._txtDisplayLabel_6.AllowDrop = true;
			this._txtDisplayLabel_6.Location = new System.Drawing.Point(200, 106);
			this._txtDisplayLabel_6.Name = "_txtDisplayLabel_6";
			this._txtDisplayLabel_6.Size = new System.Drawing.Size(275, 19);
			this._txtDisplayLabel_6.TabIndex = 0;
			// 
			// _lblCommonLabel_1
			// 
			this._lblCommonLabel_1.AllowDrop = true;
			this._lblCommonLabel_1.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_1.Text = "Location";
			this._lblCommonLabel_1.ForeColor = System.Drawing.Color.Black;
			this._lblCommonLabel_1.Location = new System.Drawing.Point(18, 16);
			// // this._lblCommonLabel_1.mLabelId = 850;
			this._lblCommonLabel_1.Name = "_lblCommonLabel_1";
			this._lblCommonLabel_1.Size = new System.Drawing.Size(41, 14);
			this._lblCommonLabel_1.TabIndex = 10;
			// 
			// _lblCommonLabel_8
			// 
			this._lblCommonLabel_8.AllowDrop = true;
			this._lblCommonLabel_8.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_8.Text = "Salesman";
			this._lblCommonLabel_8.ForeColor = System.Drawing.Color.Black;
			this._lblCommonLabel_8.Location = new System.Drawing.Point(16, 106);
			// // this._lblCommonLabel_8.mLabelId = 687;
			this._lblCommonLabel_8.Name = "_lblCommonLabel_8";
			this._lblCommonLabel_8.Size = new System.Drawing.Size(47, 14);
			this._lblCommonLabel_8.TabIndex = 11;
			// 
			// _txtCommonTextBox_9
			// 
			this._txtCommonTextBox_9.AllowDrop = true;
			this._txtCommonTextBox_9.BackColor = System.Drawing.Color.White;
			// this._txtCommonTextBox_9.bolNumericOnly = true;
			this._txtCommonTextBox_9.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_9.Location = new System.Drawing.Point(96, 104);
			this._txtCommonTextBox_9.MaxLength = 4;
			this._txtCommonTextBox_9.Name = "_txtCommonTextBox_9";
			// this._txtCommonTextBox_9.ShowButton = true;
			this._txtCommonTextBox_9.Size = new System.Drawing.Size(101, 19);
			this._txtCommonTextBox_9.TabIndex = 4;
			this._txtCommonTextBox_9.Text = "";
			// this.this._txtCommonTextBox_9.Watermark = "";
			// this.this._txtCommonTextBox_9.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_9.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _txtDisplayLabel_2
			// 
			this._txtDisplayLabel_2.AllowDrop = true;
			this._txtDisplayLabel_2.Location = new System.Drawing.Point(200, 80);
			this._txtDisplayLabel_2.Name = "_txtDisplayLabel_2";
			this._txtDisplayLabel_2.Size = new System.Drawing.Size(199, 19);
			this._txtDisplayLabel_2.TabIndex = 12;
			// 
			// fraVoucherType
			// 
			this.fraVoucherType.AllowDrop = true;
			this.fraVoucherType.BackColor = System.Drawing.Color.Black;
			this.fraVoucherType.BackStyle = 0;
			this.fraVoucherType.BorderColor = System.Drawing.Color.Black;
			this.fraVoucherType.BorderStyle = 1;
			this.fraVoucherType.Enabled = false;
			this.fraVoucherType.FillColor = System.Drawing.Color.Black;
			this.fraVoucherType.FillStyle = 1;
			this.fraVoucherType.Location = new System.Drawing.Point(480, 136);
			this.fraVoucherType.Name = "fraVoucherType";
			this.fraVoucherType.Size = new System.Drawing.Size(129, 33);
			this.fraVoucherType.Visible = true;
			// 
			// frmICSJobOrder
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.ClientSize = new System.Drawing.Size(951, 547);
			this.Controls.Add(this.tabMain);
			this.Controls.Add(this._optVoucherType_0);
			this.Controls.Add(this._optVoucherType_1);
			this.Controls.Add(this.frameBottom);
			this.Controls.Add(this.Frame1);
			this.Controls.Add(this.txtVoucherDate);
			this.Controls.Add(this._txtCommonTextBox_1);
			this.Controls.Add(this._lblCommonLabel_5);
			this.Controls.Add(this._lblCommonLabel_6);
			this.Controls.Add(this._txtCommonTextBox_7);
			this.Controls.Add(this._txtDisplayLabel_1);
			this.Controls.Add(this._lblCommonLabel_0);
			this.Controls.Add(this._txtCommonTextBox_3);
			this.Controls.Add(this._txtDisplayLabel_6);
			this.Controls.Add(this._lblCommonLabel_1);
			this.Controls.Add(this._lblCommonLabel_8);
			this.Controls.Add(this._txtCommonTextBox_9);
			this.Controls.Add(this._txtDisplayLabel_2);
			this.Controls.Add(this.fraVoucherType);
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(192, 124);
			this.MaximizeBox = true;
			this.MinimizeBox = true;
			this.Name = "frmICSJobOrder";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Job Order";
			// this.Activated += new System.EventHandler(this.frmICSJobOrder_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
			// this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
			//this.Resize += new System.EventHandler(this.Form_Resize);
			//((System.ComponentModel.ISupportInitialize) this.TabControlPage2).EndInit();
			//((System.ComponentModel.ISupportInitialize) this.TabControlPage1).EndInit();
			//((System.ComponentModel.ISupportInitialize) this.tabMain).EndInit();
			this.tabMain.ResumeLayout(false);
			this.TabControlPage2.ResumeLayout(false);
			this.Frame3.ResumeLayout(false);
			this.Frame2.ResumeLayout(false);
			this.TabControlPage1.ResumeLayout(false);
			this.grdVoucherDetails.ResumeLayout(false);
			this.cmbMastersList.ResumeLayout(false);
			this.frameBottom.ResumeLayout(false);
			this.fraPayments.ResumeLayout(false);
			this.Frame1.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		// 
		void InitializetxtDisplayLabel()
		{
			this.txtDisplayLabel = new System.Windows.Forms.Label[16];
			this.txtDisplayLabel[3] = _txtDisplayLabel_3;
			this.txtDisplayLabel[15] = _txtDisplayLabel_15;
			this.txtDisplayLabel[1] = _txtDisplayLabel_1;
			this.txtDisplayLabel[6] = _txtDisplayLabel_6;
			this.txtDisplayLabel[2] = _txtDisplayLabel_2;
		}
		void InitializetxtCommonTextBox()
		{
			this.txtCommonTextBox = new System.Windows.Forms.TextBox[10];
			this.txtCommonTextBox[5] = _txtCommonTextBox_5;
			this.txtCommonTextBox[6] = _txtCommonTextBox_6;
			this.txtCommonTextBox[1] = _txtCommonTextBox_1;
			this.txtCommonTextBox[7] = _txtCommonTextBox_7;
			this.txtCommonTextBox[3] = _txtCommonTextBox_3;
			this.txtCommonTextBox[9] = _txtCommonTextBox_9;
		}
		void InitializeoptVoucherType()
		{
			this.optVoucherType = new System.Windows.Forms.RadioButton[2];
			this.optVoucherType[0] = _optVoucherType_0;
			this.optVoucherType[1] = _optVoucherType_1;
		}
		void InitializelblCommonLabel()
		{
			this.lblCommonLabel = new System.Windows.Forms.Label[16];
			this.lblCommonLabel[12] = _lblCommonLabel_12;
			this.lblCommonLabel[13] = _lblCommonLabel_13;
			this.lblCommonLabel[14] = _lblCommonLabel_14;
			this.lblCommonLabel[15] = _lblCommonLabel_15;
			this.lblCommonLabel[2] = _lblCommonLabel_2;
			this.lblCommonLabel[3] = _lblCommonLabel_3;
			this.lblCommonLabel[4] = _lblCommonLabel_4;
			this.lblCommonLabel[7] = _lblCommonLabel_7;
			this.lblCommonLabel[9] = _lblCommonLabel_9;
			this.lblCommonLabel[11] = _lblCommonLabel_11;
			this.lblCommonLabel[10] = _lblCommonLabel_10;
			this.lblCommonLabel[5] = _lblCommonLabel_5;
			this.lblCommonLabel[6] = _lblCommonLabel_6;
			this.lblCommonLabel[0] = _lblCommonLabel_0;
			this.lblCommonLabel[1] = _lblCommonLabel_1;
			this.lblCommonLabel[8] = _lblCommonLabel_8;
		}
		#endregion
	}
}//ENDSHERE
