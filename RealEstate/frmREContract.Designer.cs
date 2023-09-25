
namespace Xtreme
{
	partial class frmREContract
	{

		#region "Upgrade Support "
		private static frmREContract m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmREContract DefInstance
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
		public static frmREContract CreateInstance()
		{
			frmREContract theInstance = new frmREContract();
			
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
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "txtRemarks", "_txtCommonNumber_0", "_lblCommon_5", "_txtCommonDate_0", "_txtCommon_0", "_lblCommon_0", "_lblCommon_3", "_txtCommon_2", "_lblCommon_1", "_txtCommon_1", "_lblCommon_2", "_txtCommon_3", "_lblCommon_7", "_lblCommon_6", "_txtCommonDate_1", "_txtCommonDate_2", "_lblCommon_4", "_txtCommon_4", "_lblCommon_9", "_txtCommon_5", "_lblCommon_10", "_txtCommonDisplay_3", "_txtCommonDisplay_2", "_txtCommonDisplay_1", "_txtCommonDisplay_0", "_lblCommon_11", "_txtCommonNumber_1", "fraTabPage0", "grdContractDetails", "Column_0_cmbCommon", "Column_1_cmbCommon", "cmbCommon", "_lblCommon_8", "lblCommon", "txtCommon", "txtCommonDate", "txtCommonDisplay", "txtCommonNumber"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public System.Windows.Forms.TextBox txtRemarks;
		private System.Windows.Forms.TextBox _txtCommonNumber_0;
		private System.Windows.Forms.Label _lblCommon_5;
		private Syncfusion.WinForms.Input.SfDateTimeEdit _txtCommonDate_0;
		private System.Windows.Forms.TextBox _txtCommon_0;
		private System.Windows.Forms.Label _lblCommon_0;
		private System.Windows.Forms.Label _lblCommon_3;
		private System.Windows.Forms.TextBox _txtCommon_2;
		private System.Windows.Forms.Label _lblCommon_1;
		private System.Windows.Forms.TextBox _txtCommon_1;
		private System.Windows.Forms.Label _lblCommon_2;
		private System.Windows.Forms.TextBox _txtCommon_3;
		private System.Windows.Forms.Label _lblCommon_7;
		private System.Windows.Forms.Label _lblCommon_6;
		private Syncfusion.WinForms.Input.SfDateTimeEdit _txtCommonDate_1;
		private Syncfusion.WinForms.Input.SfDateTimeEdit _txtCommonDate_2;
		private System.Windows.Forms.Label _lblCommon_4;
		private System.Windows.Forms.TextBox _txtCommon_4;
		private System.Windows.Forms.Label _lblCommon_9;
		private System.Windows.Forms.TextBox _txtCommon_5;
		private System.Windows.Forms.Label _lblCommon_10;
		private System.Windows.Forms.Label _txtCommonDisplay_3;
		private System.Windows.Forms.Label _txtCommonDisplay_2;
		private System.Windows.Forms.Label _txtCommonDisplay_1;
		private System.Windows.Forms.Label _txtCommonDisplay_0;
		private System.Windows.Forms.Label _lblCommon_11;
		private System.Windows.Forms.TextBox _txtCommonNumber_1;
		public AxTDBContainer3D6.AxTDBContainer3D fraTabPage0;
		public C1.Win.C1TrueDBGrid.C1TrueDBGrid grdContractDetails;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_0_cmbCommon;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_1_cmbCommon;
		public C1.Win.C1TrueDBGrid.C1TrueDBDropdown cmbCommon;
		private System.Windows.Forms.Label _lblCommon_8;
		public System.Windows.Forms.Label[] lblCommon = new System.Windows.Forms.Label[12];
		public System.Windows.Forms.TextBox[] txtCommon = new System.Windows.Forms.TextBox[6];
		public Syncfusion.WinForms.Input.SfDateTimeEdit[] txtCommonDate = new Syncfusion.WinForms.Input.SfDateTimeEdit[3];
		public System.Windows.Forms.Label[] txtCommonDisplay = new System.Windows.Forms.Label[4];
		public System.Windows.Forms.TextBox[] txtCommonNumber = new System.Windows.Forms.TextBox[2];
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmREContract));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this.txtRemarks = new System.Windows.Forms.TextBox();
			this.fraTabPage0 = new AxTDBContainer3D6.AxTDBContainer3D();
			this._txtCommonNumber_0 = new System.Windows.Forms.TextBox();
			this._lblCommon_5 = new System.Windows.Forms.Label();
			this._txtCommonDate_0 = new Syncfusion.WinForms.Input.SfDateTimeEdit();
			this._txtCommon_0 = new System.Windows.Forms.TextBox();
			this._lblCommon_0 = new System.Windows.Forms.Label();
			this._lblCommon_3 = new System.Windows.Forms.Label();
			this._txtCommon_2 = new System.Windows.Forms.TextBox();
			this._lblCommon_1 = new System.Windows.Forms.Label();
			this._txtCommon_1 = new System.Windows.Forms.TextBox();
			this._lblCommon_2 = new System.Windows.Forms.Label();
			this._txtCommon_3 = new System.Windows.Forms.TextBox();
			this._lblCommon_7 = new System.Windows.Forms.Label();
			this._lblCommon_6 = new System.Windows.Forms.Label();
			this._txtCommonDate_1 = new Syncfusion.WinForms.Input.SfDateTimeEdit();
			this._txtCommonDate_2 = new Syncfusion.WinForms.Input.SfDateTimeEdit();
			this._lblCommon_4 = new System.Windows.Forms.Label();
			this._txtCommon_4 = new System.Windows.Forms.TextBox();
			this._lblCommon_9 = new System.Windows.Forms.Label();
			this._txtCommon_5 = new System.Windows.Forms.TextBox();
			this._lblCommon_10 = new System.Windows.Forms.Label();
			this._txtCommonDisplay_3 = new System.Windows.Forms.Label();
			this._txtCommonDisplay_2 = new System.Windows.Forms.Label();
			this._txtCommonDisplay_1 = new System.Windows.Forms.Label();
			this._txtCommonDisplay_0 = new System.Windows.Forms.Label();
			this._lblCommon_11 = new System.Windows.Forms.Label();
			this._txtCommonNumber_1 = new System.Windows.Forms.TextBox();
			this.grdContractDetails = new C1.Win.C1TrueDBGrid.C1TrueDBGrid();
			this.cmbCommon = new C1.Win.C1TrueDBGrid.C1TrueDBDropdown();
			this.Column_0_cmbCommon = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.Column_1_cmbCommon = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this._lblCommon_8 = new System.Windows.Forms.Label();
			// //((System.ComponentModel.ISupportInitialize) this.fraTabPage0).BeginInit();
			this.fraTabPage0.SuspendLayout();
			this.cmbCommon.SuspendLayout();
			this.SuspendLayout();
			// 
			// txtRemarks
			// 
			this.txtRemarks.AcceptsReturn = true;
			this.txtRemarks.AllowDrop = true;
			this.txtRemarks.BackColor = System.Drawing.SystemColors.Window;
			this.txtRemarks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtRemarks.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtRemarks.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtRemarks.Location = new System.Drawing.Point(71, 349);
			this.txtRemarks.MaxLength = 100;
			this.txtRemarks.Multiline = true;
			this.txtRemarks.Name = "txtRemarks";
			this.txtRemarks.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtRemarks.Size = new System.Drawing.Size(562, 19);
			this.txtRemarks.TabIndex = 16;
			// 
			// fraTabPage0
			// 
			this.fraTabPage0.AllowDrop = true;
			this.fraTabPage0.Controls.Add(this._txtCommonNumber_0);
			this.fraTabPage0.Controls.Add(this._lblCommon_5);
			this.fraTabPage0.Controls.Add(this._txtCommonDate_0);
			this.fraTabPage0.Controls.Add(this._txtCommon_0);
			this.fraTabPage0.Controls.Add(this._lblCommon_0);
			this.fraTabPage0.Controls.Add(this._lblCommon_3);
			this.fraTabPage0.Controls.Add(this._txtCommon_2);
			this.fraTabPage0.Controls.Add(this._lblCommon_1);
			this.fraTabPage0.Controls.Add(this._txtCommon_1);
			this.fraTabPage0.Controls.Add(this._lblCommon_2);
			this.fraTabPage0.Controls.Add(this._txtCommon_3);
			this.fraTabPage0.Controls.Add(this._lblCommon_7);
			this.fraTabPage0.Controls.Add(this._lblCommon_6);
			this.fraTabPage0.Controls.Add(this._txtCommonDate_1);
			this.fraTabPage0.Controls.Add(this._txtCommonDate_2);
			this.fraTabPage0.Controls.Add(this._lblCommon_4);
			this.fraTabPage0.Controls.Add(this._txtCommon_4);
			this.fraTabPage0.Controls.Add(this._lblCommon_9);
			this.fraTabPage0.Controls.Add(this._txtCommon_5);
			this.fraTabPage0.Controls.Add(this._lblCommon_10);
			this.fraTabPage0.Controls.Add(this._txtCommonDisplay_3);
			this.fraTabPage0.Controls.Add(this._txtCommonDisplay_2);
			this.fraTabPage0.Controls.Add(this._txtCommonDisplay_1);
			this.fraTabPage0.Controls.Add(this._txtCommonDisplay_0);
			this.fraTabPage0.Controls.Add(this._lblCommon_11);
			this.fraTabPage0.Controls.Add(this._txtCommonNumber_1);
			this.fraTabPage0.Location = new System.Drawing.Point(4, 44);
			this.fraTabPage0.Name = "fraTabPage0";
			("fraTabPage0.OcxState");
			this.fraTabPage0.Size = new System.Drawing.Size(629, 142);
			this.fraTabPage0.TabIndex = 18;
			// 
			// _txtCommonNumber_0
			// 
			this._txtCommonNumber_0.AllowDrop = true;
			// this._txtCommonNumber_0.DisplayFormat = "#,###,##0.000#;;0.000;0.000";
			// this._txtCommonNumber_0.Format = "#########0.000#";
			this._txtCommonNumber_0.Location = new System.Drawing.Point(516, 94);
			// this._txtCommonNumber_0.MaxValue = 2147483647;
			// this._txtCommonNumber_0.MinValue = 0;
			this._txtCommonNumber_0.Name = "_txtCommonNumber_0";
			this._txtCommonNumber_0.Size = new System.Drawing.Size(101, 19);
			this._txtCommonNumber_0.TabIndex = 13;
			this._txtCommonNumber_0.Text = "0.000";
			// 
			// _lblCommon_5
			// 
			this._lblCommon_5.AllowDrop = true;
			this._lblCommon_5.BackColor = System.Drawing.Color.FromArgb(241, 244, 248);
			this._lblCommon_5.Text = "Starting Date";
			this._lblCommon_5.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_5.Location = new System.Drawing.Point(434, 12);
			// this._lblCommon_5.mLabelId = 1160;
			this._lblCommon_5.Name = "_lblCommon_5";
			this._lblCommon_5.Size = new System.Drawing.Size(62, 13);
			this._lblCommon_5.TabIndex = 19;
			// 
			// _txtCommonDate_0
			// 
			this._txtCommonDate_0.AllowDrop = true;
			// this._txtCommonDate_0.CheckDateRange = false;
			this._txtCommonDate_0.Location = new System.Drawing.Point(516, 10);
			// this._txtCommonDate_0.MaxDate = 2958465;
			// this._txtCommonDate_0.MinDate = 2;
			this._txtCommonDate_0.Name = "_txtCommonDate_0";
			this._txtCommonDate_0.Size = new System.Drawing.Size(101, 19);
			this._txtCommonDate_0.TabIndex = 9;
			this._txtCommonDate_0.Text = "10/02/2004";
			this._txtCommonDate_0.Value = 38027;
			// 
			// _txtCommon_0
			// 
			this._txtCommon_0.AllowDrop = true;
			this._txtCommon_0.BackColor = System.Drawing.Color.FromArgb(239, 239, 239);
			this._txtCommon_0.Enabled = false;
			this._txtCommon_0.ForeColor = System.Drawing.Color.Black;
			this._txtCommon_0.Location = new System.Drawing.Point(101, 10);
			this._txtCommon_0.MaxLength = 15;
			// this._txtCommon_0.mDropDownType = System.Windows.Forms.TextBox.DropDownTypes.ddtNextNumber;
			this._txtCommon_0.Name = "_txtCommon_0";
			this._txtCommon_0.Size = new System.Drawing.Size(101, 19);
			this._txtCommon_0.TabIndex = 0;
			this._txtCommon_0.Text = "";
			// this.this._txtCommon_0.Watermark = "";
			// this.this._txtCommon_0.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommon_DropButtonClick);
			// this._txtCommon_0.Leave += new System.EventHandler(this.txtCommon_Leave);
			// 
			// _lblCommon_0
			// 
			this._lblCommon_0.AllowDrop = true;
			this._lblCommon_0.BackColor = System.Drawing.Color.FromArgb(241, 244, 248);
			this._lblCommon_0.Text = "Contract No.";
			this._lblCommon_0.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_0.Location = new System.Drawing.Point(8, 13);
			// this._lblCommon_0.mLabelId = 1155;
			this._lblCommon_0.Name = "_lblCommon_0";
			this._lblCommon_0.Size = new System.Drawing.Size(60, 13);
			this._lblCommon_0.TabIndex = 20;
			// 
			// _lblCommon_3
			// 
			this._lblCommon_3.AllowDrop = true;
			this._lblCommon_3.BackColor = System.Drawing.Color.FromArgb(241, 244, 248);
			this._lblCommon_3.Text = "Status Code";
			this._lblCommon_3.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_3.Location = new System.Drawing.Point(8, 97);
			// this._lblCommon_3.mLabelId = 1159;
			this._lblCommon_3.Name = "_lblCommon_3";
			this._lblCommon_3.Size = new System.Drawing.Size(59, 14);
			this._lblCommon_3.TabIndex = 21;
			// 
			// _txtCommon_2
			// 
			this._txtCommon_2.AllowDrop = true;
			this._txtCommon_2.BackColor = System.Drawing.Color.FromArgb(239, 239, 239);
			// this._txtCommon_2.bolNumericOnly = true;
			this._txtCommon_2.Enabled = false;
			this._txtCommon_2.ForeColor = System.Drawing.Color.Black;
			this._txtCommon_2.Location = new System.Drawing.Point(101, 94);
			this._txtCommon_2.MaxLength = 15;
			this._txtCommon_2.Name = "_txtCommon_2";
			this._txtCommon_2.Size = new System.Drawing.Size(101, 19);
			this._txtCommon_2.TabIndex = 7;
			this._txtCommon_2.Text = "";
			// this.this._txtCommon_2.Watermark = "";
			// this.this._txtCommon_2.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommon_DropButtonClick);
			// this._txtCommon_2.Leave += new System.EventHandler(this.txtCommon_Leave);
			// 
			// _lblCommon_1
			// 
			this._lblCommon_1.AllowDrop = true;
			this._lblCommon_1.BackColor = System.Drawing.Color.FromArgb(241, 244, 248);
			this._lblCommon_1.Text = "Tenant Code";
			this._lblCommon_1.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_1.Location = new System.Drawing.Point(8, 33);
			// this._lblCommon_1.mLabelId = 1156;
			this._lblCommon_1.Name = "_lblCommon_1";
			this._lblCommon_1.Size = new System.Drawing.Size(61, 14);
			this._lblCommon_1.TabIndex = 22;
			// 
			// _txtCommon_1
			// 
			this._txtCommon_1.AllowDrop = true;
			this._txtCommon_1.BackColor = System.Drawing.Color.White;
			// this._txtCommon_1.bolNumericOnly = true;
			this._txtCommon_1.ForeColor = System.Drawing.Color.Black;
			this._txtCommon_1.Location = new System.Drawing.Point(101, 31);
			this._txtCommon_1.MaxLength = 15;
			this._txtCommon_1.Name = "_txtCommon_1";
			// this._txtCommon_1.ShowButton = true;
			this._txtCommon_1.Size = new System.Drawing.Size(101, 19);
			this._txtCommon_1.TabIndex = 1;
			this._txtCommon_1.Text = "";
			// this.this._txtCommon_1.Watermark = "";
			// this.this._txtCommon_1.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommon_DropButtonClick);
			// this._txtCommon_1.Leave += new System.EventHandler(this.txtCommon_Leave);
			// 
			// _lblCommon_2
			// 
			this._lblCommon_2.AllowDrop = true;
			this._lblCommon_2.BackColor = System.Drawing.Color.FromArgb(241, 244, 248);
			this._lblCommon_2.Text = "Pay. Method Code";
			this._lblCommon_2.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_2.Location = new System.Drawing.Point(8, 54);
			// this._lblCommon_2.mLabelId = 1157;
			this._lblCommon_2.Name = "_lblCommon_2";
			this._lblCommon_2.Size = new System.Drawing.Size(87, 14);
			this._lblCommon_2.TabIndex = 23;
			// 
			// _txtCommon_3
			// 
			this._txtCommon_3.AllowDrop = true;
			this._txtCommon_3.BackColor = System.Drawing.Color.White;
			// this._txtCommon_3.bolNumericOnly = true;
			this._txtCommon_3.ForeColor = System.Drawing.Color.Black;
			this._txtCommon_3.Location = new System.Drawing.Point(101, 52);
			this._txtCommon_3.MaxLength = 15;
			this._txtCommon_3.Name = "_txtCommon_3";
			// this._txtCommon_3.ShowButton = true;
			this._txtCommon_3.Size = new System.Drawing.Size(101, 19);
			this._txtCommon_3.TabIndex = 3;
			this._txtCommon_3.Text = "";
			// this.this._txtCommon_3.Watermark = "";
			// this.this._txtCommon_3.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommon_DropButtonClick);
			// this._txtCommon_3.Leave += new System.EventHandler(this.txtCommon_Leave);
			// 
			// _lblCommon_7
			// 
			this._lblCommon_7.AllowDrop = true;
			this._lblCommon_7.BackColor = System.Drawing.Color.FromArgb(241, 244, 248);
			this._lblCommon_7.Text = "Signed Date";
			this._lblCommon_7.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_7.Location = new System.Drawing.Point(434, 55);
			// this._lblCommon_7.mLabelId = 1162;
			this._lblCommon_7.Name = "_lblCommon_7";
			this._lblCommon_7.Size = new System.Drawing.Size(59, 13);
			this._lblCommon_7.TabIndex = 24;
			// 
			// _lblCommon_6
			// 
			this._lblCommon_6.AllowDrop = true;
			this._lblCommon_6.BackColor = System.Drawing.Color.FromArgb(241, 244, 248);
			this._lblCommon_6.Text = "Ending Date";
			this._lblCommon_6.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_6.Location = new System.Drawing.Point(434, 34);
			// this._lblCommon_6.mLabelId = 1161;
			this._lblCommon_6.Name = "_lblCommon_6";
			this._lblCommon_6.Size = new System.Drawing.Size(59, 13);
			this._lblCommon_6.TabIndex = 25;
			// 
			// _txtCommonDate_1
			// 
			this._txtCommonDate_1.AllowDrop = true;
			// this._txtCommonDate_1.CheckDateRange = false;
			this._txtCommonDate_1.Location = new System.Drawing.Point(516, 31);
			// this._txtCommonDate_1.MaxDate = 2958465;
			// this._txtCommonDate_1.MinDate = 2;
			this._txtCommonDate_1.Name = "_txtCommonDate_1";
			this._txtCommonDate_1.Size = new System.Drawing.Size(101, 19);
			this._txtCommonDate_1.TabIndex = 10;
			this._txtCommonDate_1.Text = "10/02/2004";
			this._txtCommonDate_1.Value = 38027;
			// 
			// _txtCommonDate_2
			// 
			this._txtCommonDate_2.AllowDrop = true;
			// this._txtCommonDate_2.CheckDateRange = false;
			this._txtCommonDate_2.Location = new System.Drawing.Point(516, 52);
			// this._txtCommonDate_2.MaxDate = 2958465;
			// this._txtCommonDate_2.MinDate = 2;
			this._txtCommonDate_2.Name = "_txtCommonDate_2";
			this._txtCommonDate_2.Size = new System.Drawing.Size(101, 19);
			this._txtCommonDate_2.TabIndex = 11;
			this._txtCommonDate_2.Text = "10/02/2004";
			this._txtCommonDate_2.Value = 38027;
			// 
			// _lblCommon_4
			// 
			this._lblCommon_4.AllowDrop = true;
			this._lblCommon_4.BackColor = System.Drawing.Color.FromArgb(241, 244, 248);
			this._lblCommon_4.Text = "Reference No.";
			this._lblCommon_4.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_4.Location = new System.Drawing.Point(434, 76);
			// this._lblCommon_4.mLabelId = 1164;
			this._lblCommon_4.Name = "_lblCommon_4";
			this._lblCommon_4.Size = new System.Drawing.Size(70, 13);
			this._lblCommon_4.TabIndex = 27;
			// 
			// _txtCommon_4
			// 
			this._txtCommon_4.AllowDrop = true;
			this._txtCommon_4.BackColor = System.Drawing.Color.White;
			this._txtCommon_4.ForeColor = System.Drawing.Color.Black;
			this._txtCommon_4.Location = new System.Drawing.Point(516, 73);
			this._txtCommon_4.MaxLength = 15;
			// this._txtCommon_4.mDropDownType = System.Windows.Forms.TextBox.DropDownTypes.ddtNextNumber;
			this._txtCommon_4.Name = "_txtCommon_4";
			this._txtCommon_4.Size = new System.Drawing.Size(101, 19);
			this._txtCommon_4.TabIndex = 12;
			this._txtCommon_4.Text = "";
			// this.this._txtCommon_4.Watermark = "";
			// this.this._txtCommon_4.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommon_DropButtonClick);
			// this._txtCommon_4.Leave += new System.EventHandler(this.txtCommon_Leave);
			// 
			// _lblCommon_9
			// 
			this._lblCommon_9.AllowDrop = true;
			this._lblCommon_9.BackColor = System.Drawing.Color.FromArgb(241, 244, 248);
			this._lblCommon_9.Text = "Property Code";
			this._lblCommon_9.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_9.Location = new System.Drawing.Point(8, 76);
			// this._lblCommon_9.mLabelId = 1158;
			this._lblCommon_9.Name = "_lblCommon_9";
			this._lblCommon_9.Size = new System.Drawing.Size(69, 14);
			this._lblCommon_9.TabIndex = 28;
			// 
			// _txtCommon_5
			// 
			this._txtCommon_5.AllowDrop = true;
			this._txtCommon_5.BackColor = System.Drawing.Color.White;
			this._txtCommon_5.ForeColor = System.Drawing.Color.Black;
			this._txtCommon_5.Location = new System.Drawing.Point(101, 73);
			this._txtCommon_5.MaxLength = 15;
			this._txtCommon_5.Name = "_txtCommon_5";
			// this._txtCommon_5.ShowButton = true;
			this._txtCommon_5.Size = new System.Drawing.Size(101, 19);
			this._txtCommon_5.TabIndex = 5;
			this._txtCommon_5.Text = "";
			// this.this._txtCommon_5.Watermark = "";
			// this.this._txtCommon_5.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommon_DropButtonClick);
			// this._txtCommon_5.Leave += new System.EventHandler(this.txtCommon_Leave);
			// 
			// _lblCommon_10
			// 
			this._lblCommon_10.AllowDrop = true;
			this._lblCommon_10.BackColor = System.Drawing.Color.FromArgb(241, 244, 248);
			this._lblCommon_10.Text = "Opening Due";
			this._lblCommon_10.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_10.Location = new System.Drawing.Point(434, 97);
			this._lblCommon_10.Name = "_lblCommon_10";
			this._lblCommon_10.Size = new System.Drawing.Size(63, 13);
			this._lblCommon_10.TabIndex = 29;
			// 
			// _txtCommonDisplay_3
			// 
			this._txtCommonDisplay_3.AllowDrop = true;
			this._txtCommonDisplay_3.Location = new System.Drawing.Point(204, 73);
			this._txtCommonDisplay_3.Name = "_txtCommonDisplay_3";
			this._txtCommonDisplay_3.Size = new System.Drawing.Size(201, 19);
			this._txtCommonDisplay_3.TabIndex = 6;
			this._txtCommonDisplay_3.TabStop = false;
			// 
			// _txtCommonDisplay_2
			// 
			this._txtCommonDisplay_2.AllowDrop = true;
			this._txtCommonDisplay_2.Location = new System.Drawing.Point(204, 52);
			this._txtCommonDisplay_2.Name = "_txtCommonDisplay_2";
			this._txtCommonDisplay_2.Size = new System.Drawing.Size(201, 19);
			this._txtCommonDisplay_2.TabIndex = 4;
			this._txtCommonDisplay_2.TabStop = false;
			// 
			// _txtCommonDisplay_1
			// 
			this._txtCommonDisplay_1.AllowDrop = true;
			this._txtCommonDisplay_1.Location = new System.Drawing.Point(204, 94);
			this._txtCommonDisplay_1.Name = "_txtCommonDisplay_1";
			this._txtCommonDisplay_1.Size = new System.Drawing.Size(201, 19);
			this._txtCommonDisplay_1.TabIndex = 8;
			this._txtCommonDisplay_1.TabStop = false;
			// 
			// _txtCommonDisplay_0
			// 
			this._txtCommonDisplay_0.AllowDrop = true;
			this._txtCommonDisplay_0.Location = new System.Drawing.Point(204, 31);
			this._txtCommonDisplay_0.Name = "_txtCommonDisplay_0";
			this._txtCommonDisplay_0.Size = new System.Drawing.Size(201, 19);
			this._txtCommonDisplay_0.TabIndex = 2;
			this._txtCommonDisplay_0.TabStop = false;
			// 
			// _lblCommon_11
			// 
			this._lblCommon_11.AllowDrop = true;
			this._lblCommon_11.BackColor = System.Drawing.Color.FromArgb(241, 244, 248);
			this._lblCommon_11.Text = "Security Deposit";
			this._lblCommon_11.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_11.Location = new System.Drawing.Point(434, 118);
			this._lblCommon_11.Name = "_lblCommon_11";
			this._lblCommon_11.Size = new System.Drawing.Size(77, 13);
			this._lblCommon_11.TabIndex = 30;
			// 
			// _txtCommonNumber_1
			// 
			this._txtCommonNumber_1.AllowDrop = true;
			// this._txtCommonNumber_1.DisplayFormat = "#,###,##0.000#;;0.000;0.000";
			// this._txtCommonNumber_1.Format = "#########0.000#";
			this._txtCommonNumber_1.Location = new System.Drawing.Point(516, 115);
			// this._txtCommonNumber_1.MaxValue = 2147483647;
			// this._txtCommonNumber_1.MinValue = 0;
			this._txtCommonNumber_1.Name = "_txtCommonNumber_1";
			this._txtCommonNumber_1.Size = new System.Drawing.Size(101, 19);
			this._txtCommonNumber_1.TabIndex = 14;
			this._txtCommonNumber_1.Text = "0.000";
			// 
			// grdContractDetails
			// 
			this.grdContractDetails.AllowDrop = true;
			this.grdContractDetails.BackColor = System.Drawing.Color.Silver;
			this.grdContractDetails.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.grdContractDetails.CellTipsWidth = 0;
			this.grdContractDetails.Location = new System.Drawing.Point(2, 192);
			this.grdContractDetails.Name = "grdContractDetails";
			this.grdContractDetails.RowDivider.Color = System.Drawing.Color.Silver;
			this.grdContractDetails.Size = new System.Drawing.Size(631, 148);
			this.grdContractDetails.TabIndex = 15;
			this.grdContractDetails.AfterColUpdate += new C1.Win.C1TrueDBGrid.ColEventHandler(this.grdContractDetails_AfterColUpdate);
			this.grdContractDetails.GotFocus += new System.EventHandler(this.grdContractDetails_GotFocus);
			this.grdContractDetails.RowColChange += new C1.Win.C1TrueDBGrid.RowColChangeEventHandler(this.grdContractDetails_RowColChange);
			// 
			// cmbCommon
			// 
			this.cmbCommon.AllowDrop = true;
			this.cmbCommon.ColumnHeaders = true;
			this.cmbCommon.Enabled = true;
			this.cmbCommon.Location = new System.Drawing.Point(264, 231);
			this.cmbCommon.Name = "cmbCommon";
			this.cmbCommon.Size = new System.Drawing.Size(127, 79);
			this.cmbCommon.TabIndex = 17;
			this.cmbCommon.Columns.Add(this.Column_0_cmbCommon);
			this.cmbCommon.Columns.Add(this.Column_1_cmbCommon);
			// 
			// Column_0_cmbCommon
			// 
			this.Column_0_cmbCommon.DataField = "";
			this.Column_0_cmbCommon.ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.Normal;
			// 
			// Column_1_cmbCommon
			// 
			this.Column_1_cmbCommon.DataField = "";
			this.Column_1_cmbCommon.ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.Normal;
			// 
			// _lblCommon_8
			// 
			this._lblCommon_8.AllowDrop = true;
			this._lblCommon_8.BackColor = System.Drawing.Color.FromArgb(202, 213, 223);
			this._lblCommon_8.Text = "Comments";
			this._lblCommon_8.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_8.Location = new System.Drawing.Point(8, 351);
			// this._lblCommon_8.mLabelId = 135;
			this._lblCommon_8.Name = "_lblCommon_8";
			this._lblCommon_8.Size = new System.Drawing.Size(50, 14);
			this._lblCommon_8.TabIndex = 26;
			// 
			// frmREContract
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.ClientSize = new System.Drawing.Size(637, 374);
			this.Controls.Add(this.txtRemarks);
			this.Controls.Add(this.fraTabPage0);
			this.Controls.Add(this.grdContractDetails);
			this.Controls.Add(this.cmbCommon);
			this.Controls.Add(this._lblCommon_8);
			//this.Icon = (System.Drawing.Icon) resources.GetObject("frmREContract.Icon");
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(342, 226);
			this.MaximizeBox = true;
			this.MinimizeBox = true;
			this.Name = "frmREContract";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Contract";
			// this.Activated += new System.EventHandler(this.Form_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
			this.Deactivate += new System.EventHandler(this.Form_Deactivate);
			// this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
			//((System.ComponentModel.ISupportInitialize) this.fraTabPage0).EndInit();
			this.fraTabPage0.ResumeLayout(false);
			this.cmbCommon.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		void ReLoadForm(bool addEvents)
		{
			InitializetxtCommonNumber();
			InitializetxtCommonDisplay();
			InitializetxtCommonDate();
			InitializetxtCommon();
			InitializelblCommon();
			//This form is an MDI child.
			//This code simulates the VB6 
			// functionality of automatically
			// loading and showing an MDI
			// child's parent.
			this.MdiParent = Xtreme.frmSysMain.DefInstance;
			Xtreme.frmSysMain.DefInstance.Show();
		}
		void InitializetxtCommonNumber()
		{
			this.txtCommonNumber = new System.Windows.Forms.TextBox[2];
			this.txtCommonNumber[0] = _txtCommonNumber_0;
			this.txtCommonNumber[1] = _txtCommonNumber_1;
		}
		void InitializetxtCommonDisplay()
		{
			this.txtCommonDisplay = new System.Windows.Forms.Label[4];
			this.txtCommonDisplay[3] = _txtCommonDisplay_3;
			this.txtCommonDisplay[2] = _txtCommonDisplay_2;
			this.txtCommonDisplay[1] = _txtCommonDisplay_1;
			this.txtCommonDisplay[0] = _txtCommonDisplay_0;
		}
		void InitializetxtCommonDate()
		{
			this.txtCommonDate = new Syncfusion.WinForms.Input.SfDateTimeEdit[3];
			this.txtCommonDate[0] = _txtCommonDate_0;
			this.txtCommonDate[1] = _txtCommonDate_1;
			this.txtCommonDate[2] = _txtCommonDate_2;
		}
		void InitializetxtCommon()
		{
			this.txtCommon = new System.Windows.Forms.TextBox[6];
			this.txtCommon[0] = _txtCommon_0;
			this.txtCommon[2] = _txtCommon_2;
			this.txtCommon[1] = _txtCommon_1;
			this.txtCommon[3] = _txtCommon_3;
			this.txtCommon[4] = _txtCommon_4;
			this.txtCommon[5] = _txtCommon_5;
		}
		void InitializelblCommon()
		{
			this.lblCommon = new System.Windows.Forms.Label[12];
			this.lblCommon[5] = _lblCommon_5;
			this.lblCommon[0] = _lblCommon_0;
			this.lblCommon[3] = _lblCommon_3;
			this.lblCommon[1] = _lblCommon_1;
			this.lblCommon[2] = _lblCommon_2;
			this.lblCommon[7] = _lblCommon_7;
			this.lblCommon[6] = _lblCommon_6;
			this.lblCommon[4] = _lblCommon_4;
			this.lblCommon[9] = _lblCommon_9;
			this.lblCommon[10] = _lblCommon_10;
			this.lblCommon[11] = _lblCommon_11;
			this.lblCommon[8] = _lblCommon_8;
		}
		#endregion
	}
}