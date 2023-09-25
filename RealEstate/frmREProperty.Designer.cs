
namespace Xtreme
{
	partial class frmREProperty
	{

		#region "Upgrade Support "
		private static frmREProperty m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmREProperty DefInstance
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
		public static frmREProperty CreateInstance()
		{
			frmREProperty theInstance = new frmREProperty();
			
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
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "txtRemarks", "txtValue", "_txtCommon_0", "_lblCommon_1", "_lblCommon_10", "_lblCommon_0", "_lblCommon_4", "_txtCommon_2", "_txtCommon_1", "_lblCommon_7", "_txtCommon_3", "_lblCommon_3", "_txtCommon_5", "_lblCommon_8", "_txtCommon_7", "_lblCommon_9", "_lblCommon_2", "_txtCommon_8", "_lblCommon_5", "_txtCommon_4", "_lblCommon_6", "_txtCommon_9", "_txtCommon_6", "_txtCommonDisplay_3", "_txtCommonDisplay_2", "_txtCommonDisplay_1", "_txtCommonDisplay_0", "_lblCommon_16", "_txtCommon_15", "_txtCommon_16", "_lblCommon_17", "_lblCommon_18", "_txtCommon_17", "_lblCommon_19", "_txtCommon_18", "_lblCommon_20", "_txtCommon_19", "_lblCommon_21", "_txtCommon_20", "_lblCommon_22", "_fraMasterInformation_0", "_lblCommon_11", "_txtCommon_10", "_lblCommon_12", "_lblCommon_13", "_lblCommon_14", "_lblCommon_15", "_txtCommon_11", "_txtCommon_12", "_txtCommon_13", "_txtCommon_14", "_txtCommonDisplay_5", "_txtCommonDisplay_6", "_txtCommonDisplay_7", "_txtCommonDisplay_8", "_txtCommonDisplay_4", "_fraMasterInformation_1", "tabMaster", "fraMasterInformation", "lblCommon", "txtCommon", "txtCommonDisplay"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public System.Windows.Forms.TextBox txtRemarks;
		public System.Windows.Forms.TextBox txtValue;
		private System.Windows.Forms.TextBox _txtCommon_0;
		private System.Windows.Forms.Label _lblCommon_1;
		private System.Windows.Forms.Label _lblCommon_10;
		private System.Windows.Forms.Label _lblCommon_0;
		private System.Windows.Forms.Label _lblCommon_4;
		private System.Windows.Forms.TextBox _txtCommon_2;
		private System.Windows.Forms.TextBox _txtCommon_1;
		private System.Windows.Forms.Label _lblCommon_7;
		private System.Windows.Forms.TextBox _txtCommon_3;
		private System.Windows.Forms.Label _lblCommon_3;
		private System.Windows.Forms.TextBox _txtCommon_5;
		private System.Windows.Forms.Label _lblCommon_8;
		private System.Windows.Forms.TextBox _txtCommon_7;
		private System.Windows.Forms.Label _lblCommon_9;
		private System.Windows.Forms.Label _lblCommon_2;
		private System.Windows.Forms.TextBox _txtCommon_8;
		private System.Windows.Forms.Label _lblCommon_5;
		private System.Windows.Forms.TextBox _txtCommon_4;
		private System.Windows.Forms.Label _lblCommon_6;
		private System.Windows.Forms.TextBox _txtCommon_9;
		private System.Windows.Forms.TextBox _txtCommon_6;
		private System.Windows.Forms.Label _txtCommonDisplay_3;
		private System.Windows.Forms.Label _txtCommonDisplay_2;
		private System.Windows.Forms.Label _txtCommonDisplay_1;
		private System.Windows.Forms.Label _txtCommonDisplay_0;
		private System.Windows.Forms.Label _lblCommon_16;
		private System.Windows.Forms.TextBox _txtCommon_15;
		private System.Windows.Forms.TextBox _txtCommon_16;
		private System.Windows.Forms.Label _lblCommon_17;
		private System.Windows.Forms.Label _lblCommon_18;
		private System.Windows.Forms.TextBox _txtCommon_17;
		private System.Windows.Forms.Label _lblCommon_19;
		private System.Windows.Forms.TextBox _txtCommon_18;
		private System.Windows.Forms.Label _lblCommon_20;
		private System.Windows.Forms.TextBox _txtCommon_19;
		private System.Windows.Forms.Label _lblCommon_21;
		private System.Windows.Forms.TextBox _txtCommon_20;
		private System.Windows.Forms.Label _lblCommon_22;
		private System.Windows.Forms.Panel _fraMasterInformation_0;
		private System.Windows.Forms.Label _lblCommon_11;
		private System.Windows.Forms.TextBox _txtCommon_10;
		private System.Windows.Forms.Label _lblCommon_12;
		private System.Windows.Forms.Label _lblCommon_13;
		private System.Windows.Forms.Label _lblCommon_14;
		private System.Windows.Forms.Label _lblCommon_15;
		private System.Windows.Forms.TextBox _txtCommon_11;
		private System.Windows.Forms.TextBox _txtCommon_12;
		private System.Windows.Forms.TextBox _txtCommon_13;
		private System.Windows.Forms.TextBox _txtCommon_14;
		private System.Windows.Forms.Label _txtCommonDisplay_5;
		private System.Windows.Forms.Label _txtCommonDisplay_6;
		private System.Windows.Forms.Label _txtCommonDisplay_7;
		private System.Windows.Forms.Label _txtCommonDisplay_8;
		private System.Windows.Forms.Label _txtCommonDisplay_4;
		private System.Windows.Forms.Panel _fraMasterInformation_1;
		public AxC1SizerLib.AxC1Tab tabMaster;
		public System.Windows.Forms.Panel[] fraMasterInformation = new System.Windows.Forms.Panel[2];
		public System.Windows.Forms.Label[] lblCommon = new System.Windows.Forms.Label[23];
		public System.Windows.Forms.TextBox[] txtCommon = new System.Windows.Forms.TextBox[21];
		public System.Windows.Forms.Label[] txtCommonDisplay = new System.Windows.Forms.Label[9];
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmREProperty));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this.tabMaster = new AxC1SizerLib.AxC1Tab();
			this._fraMasterInformation_0 = new System.Windows.Forms.Panel();
			this.txtRemarks = new System.Windows.Forms.TextBox();
			// this.txtValue = new System.Windows.Forms.TextBox();
			this._txtCommon_0 = new System.Windows.Forms.TextBox();
			this._lblCommon_1 = new System.Windows.Forms.Label();
			this._lblCommon_10 = new System.Windows.Forms.Label();
			this._lblCommon_0 = new System.Windows.Forms.Label();
			this._lblCommon_4 = new System.Windows.Forms.Label();
			this._txtCommon_2 = new System.Windows.Forms.TextBox();
			this._txtCommon_1 = new System.Windows.Forms.TextBox();
			this._lblCommon_7 = new System.Windows.Forms.Label();
			this._txtCommon_3 = new System.Windows.Forms.TextBox();
			this._lblCommon_3 = new System.Windows.Forms.Label();
			this._txtCommon_5 = new System.Windows.Forms.TextBox();
			this._lblCommon_8 = new System.Windows.Forms.Label();
			this._txtCommon_7 = new System.Windows.Forms.TextBox();
			this._lblCommon_9 = new System.Windows.Forms.Label();
			this._lblCommon_2 = new System.Windows.Forms.Label();
			this._txtCommon_8 = new System.Windows.Forms.TextBox();
			this._lblCommon_5 = new System.Windows.Forms.Label();
			this._txtCommon_4 = new System.Windows.Forms.TextBox();
			this._lblCommon_6 = new System.Windows.Forms.Label();
			this._txtCommon_9 = new System.Windows.Forms.TextBox();
			this._txtCommon_6 = new System.Windows.Forms.TextBox();
			this._txtCommonDisplay_3 = new System.Windows.Forms.Label();
			this._txtCommonDisplay_2 = new System.Windows.Forms.Label();
			this._txtCommonDisplay_1 = new System.Windows.Forms.Label();
			this._txtCommonDisplay_0 = new System.Windows.Forms.Label();
			this._lblCommon_16 = new System.Windows.Forms.Label();
			this._txtCommon_15 = new System.Windows.Forms.TextBox();
			this._txtCommon_16 = new System.Windows.Forms.TextBox();
			this._lblCommon_17 = new System.Windows.Forms.Label();
			this._lblCommon_18 = new System.Windows.Forms.Label();
			this._txtCommon_17 = new System.Windows.Forms.TextBox();
			this._lblCommon_19 = new System.Windows.Forms.Label();
			this._txtCommon_18 = new System.Windows.Forms.TextBox();
			this._lblCommon_20 = new System.Windows.Forms.Label();
			this._txtCommon_19 = new System.Windows.Forms.TextBox();
			this._lblCommon_21 = new System.Windows.Forms.Label();
			this._txtCommon_20 = new System.Windows.Forms.TextBox();
			this._lblCommon_22 = new System.Windows.Forms.Label();
			this._fraMasterInformation_1 = new System.Windows.Forms.Panel();
			this._lblCommon_11 = new System.Windows.Forms.Label();
			this._txtCommon_10 = new System.Windows.Forms.TextBox();
			this._lblCommon_12 = new System.Windows.Forms.Label();
			this._lblCommon_13 = new System.Windows.Forms.Label();
			this._lblCommon_14 = new System.Windows.Forms.Label();
			this._lblCommon_15 = new System.Windows.Forms.Label();
			this._txtCommon_11 = new System.Windows.Forms.TextBox();
			this._txtCommon_12 = new System.Windows.Forms.TextBox();
			this._txtCommon_13 = new System.Windows.Forms.TextBox();
			this._txtCommon_14 = new System.Windows.Forms.TextBox();
			this._txtCommonDisplay_5 = new System.Windows.Forms.Label();
			this._txtCommonDisplay_6 = new System.Windows.Forms.Label();
			this._txtCommonDisplay_7 = new System.Windows.Forms.Label();
			this._txtCommonDisplay_8 = new System.Windows.Forms.Label();
			this._txtCommonDisplay_4 = new System.Windows.Forms.Label();
			// //((System.ComponentModel.ISupportInitialize) this.tabMaster).BeginInit();
			this.tabMaster.SuspendLayout();
			this._fraMasterInformation_0.SuspendLayout();
			this._fraMasterInformation_1.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabMaster
			// 
			this.tabMaster.Align = C1SizerLib.AlignSettings.asNone;
			this.tabMaster.AllowDrop = true;
			this.tabMaster.Controls.Add(this._fraMasterInformation_0);
			this.tabMaster.Controls.Add(this._fraMasterInformation_1);
			this.tabMaster.Location = new System.Drawing.Point(8, 10);
			this.tabMaster.Name = "tabMaster";
			("tabMaster.OcxState");
			this.tabMaster.Size = new System.Drawing.Size(478, 436);
			this.tabMaster.TabIndex = 0;
			this.tabMaster.TabStop = false;
			// 
			// _fraMasterInformation_0
			// 
			this._fraMasterInformation_0.AllowDrop = true;
			this._fraMasterInformation_0.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._fraMasterInformation_0.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._fraMasterInformation_0.Controls.Add(this.txtRemarks);
			this._fraMasterInformation_0.Controls.Add(this.txtValue);
			this._fraMasterInformation_0.Controls.Add(this._txtCommon_0);
			this._fraMasterInformation_0.Controls.Add(this._lblCommon_1);
			this._fraMasterInformation_0.Controls.Add(this._lblCommon_10);
			this._fraMasterInformation_0.Controls.Add(this._lblCommon_0);
			this._fraMasterInformation_0.Controls.Add(this._lblCommon_4);
			this._fraMasterInformation_0.Controls.Add(this._txtCommon_2);
			this._fraMasterInformation_0.Controls.Add(this._txtCommon_1);
			this._fraMasterInformation_0.Controls.Add(this._lblCommon_7);
			this._fraMasterInformation_0.Controls.Add(this._txtCommon_3);
			this._fraMasterInformation_0.Controls.Add(this._lblCommon_3);
			this._fraMasterInformation_0.Controls.Add(this._txtCommon_5);
			this._fraMasterInformation_0.Controls.Add(this._lblCommon_8);
			this._fraMasterInformation_0.Controls.Add(this._txtCommon_7);
			this._fraMasterInformation_0.Controls.Add(this._lblCommon_9);
			this._fraMasterInformation_0.Controls.Add(this._lblCommon_2);
			this._fraMasterInformation_0.Controls.Add(this._txtCommon_8);
			this._fraMasterInformation_0.Controls.Add(this._lblCommon_5);
			this._fraMasterInformation_0.Controls.Add(this._txtCommon_4);
			this._fraMasterInformation_0.Controls.Add(this._lblCommon_6);
			this._fraMasterInformation_0.Controls.Add(this._txtCommon_9);
			this._fraMasterInformation_0.Controls.Add(this._txtCommon_6);
			this._fraMasterInformation_0.Controls.Add(this._txtCommonDisplay_3);
			this._fraMasterInformation_0.Controls.Add(this._txtCommonDisplay_2);
			this._fraMasterInformation_0.Controls.Add(this._txtCommonDisplay_1);
			this._fraMasterInformation_0.Controls.Add(this._txtCommonDisplay_0);
			this._fraMasterInformation_0.Controls.Add(this._lblCommon_16);
			this._fraMasterInformation_0.Controls.Add(this._txtCommon_15);
			this._fraMasterInformation_0.Controls.Add(this._txtCommon_16);
			this._fraMasterInformation_0.Controls.Add(this._lblCommon_17);
			this._fraMasterInformation_0.Controls.Add(this._lblCommon_18);
			this._fraMasterInformation_0.Controls.Add(this._txtCommon_17);
			this._fraMasterInformation_0.Controls.Add(this._lblCommon_19);
			this._fraMasterInformation_0.Controls.Add(this._txtCommon_18);
			this._fraMasterInformation_0.Controls.Add(this._lblCommon_20);
			this._fraMasterInformation_0.Controls.Add(this._txtCommon_19);
			this._fraMasterInformation_0.Controls.Add(this._lblCommon_21);
			this._fraMasterInformation_0.Controls.Add(this._txtCommon_20);
			this._fraMasterInformation_0.Controls.Add(this._lblCommon_22);
			this._fraMasterInformation_0.Enabled = true;
			this._fraMasterInformation_0.ForeColor = System.Drawing.SystemColors.WindowText;
			this._fraMasterInformation_0.Location = new System.Drawing.Point(1, 23);
			this._fraMasterInformation_0.Name = "_fraMasterInformation_0";
			this._fraMasterInformation_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._fraMasterInformation_0.Size = new System.Drawing.Size(476, 412);
			this._fraMasterInformation_0.TabIndex = 17;
			this._fraMasterInformation_0.Visible = true;
			// 
			// txtRemarks
			// 
			this.txtRemarks.AcceptsReturn = true;
			this.txtRemarks.AllowDrop = true;
			this.txtRemarks.BackColor = System.Drawing.SystemColors.Window;
			this.txtRemarks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtRemarks.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtRemarks.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtRemarks.Location = new System.Drawing.Point(157, 366);
			this.txtRemarks.MaxLength = 100;
			this.txtRemarks.Multiline = true;
			this.txtRemarks.Name = "txtRemarks";
			this.txtRemarks.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtRemarks.Size = new System.Drawing.Size(304, 38);
			this.txtRemarks.TabIndex = 18;
			// 
			// txtValue
			// 
			this.txtValue.AllowDrop = true;
			// this.txtValue.DisplayFormat = "####0.000;;Null";
			this.txtValue.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtValue.Location = new System.Drawing.Point(354, 284);
			this.txtValue.Name = "txtValue";
			this.txtValue.Size = new System.Drawing.Size(105, 19);
			this.txtValue.TabIndex = 19;
			// 
			// _txtCommon_0
			// 
			this._txtCommon_0.AllowDrop = true;
			this._txtCommon_0.BackColor = System.Drawing.Color.White;
			this._txtCommon_0.ForeColor = System.Drawing.Color.Black;
			this._txtCommon_0.Location = new System.Drawing.Point(157, 11);
			this._txtCommon_0.MaxLength = 15;
			// this._txtCommon_0.mDropDownType = System.Windows.Forms.TextBox.DropDownTypes.ddtNextNumber;
			this._txtCommon_0.Name = "_txtCommon_0";
			// this._txtCommon_0.ShowButton = true;
			this._txtCommon_0.Size = new System.Drawing.Size(101, 19);
			this._txtCommon_0.TabIndex = 20;
			this._txtCommon_0.Text = "";
			// this.this._txtCommon_0.Watermark = "";
			// this.this._txtCommon_0.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommon_DropButtonClick);
			// this._txtCommon_0.Leave += new System.EventHandler(this.txtCommon_Leave);
			// 
			// _lblCommon_1
			// 
			this._lblCommon_1.AllowDrop = true;
			this._lblCommon_1.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_1.Text = "Property Name  (English)";
			this._lblCommon_1.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_1.Location = new System.Drawing.Point(8, 35);
			// // this._lblCommon_1.mLabelId = 1189;
			this._lblCommon_1.Name = "_lblCommon_1";
			this._lblCommon_1.Size = new System.Drawing.Size(119, 14);
			this._lblCommon_1.TabIndex = 21;
			// 
			// _lblCommon_10
			// 
			this._lblCommon_10.AllowDrop = true;
			this._lblCommon_10.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_10.Text = "Comments";
			this._lblCommon_10.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_10.Location = new System.Drawing.Point(8, 366);
			// // this._lblCommon_10.mLabelId = 135;
			this._lblCommon_10.Name = "_lblCommon_10";
			this._lblCommon_10.Size = new System.Drawing.Size(49, 13);
			this._lblCommon_10.TabIndex = 22;
			// 
			// _lblCommon_0
			// 
			this._lblCommon_0.AllowDrop = true;
			this._lblCommon_0.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_0.Text = "Property Code";
			this._lblCommon_0.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_0.Location = new System.Drawing.Point(8, 13);
			// // this._lblCommon_0.mLabelId = 1158;
			this._lblCommon_0.Name = "_lblCommon_0";
			this._lblCommon_0.Size = new System.Drawing.Size(69, 14);
			this._lblCommon_0.TabIndex = 23;
			// 
			// _lblCommon_4
			// 
			this._lblCommon_4.AllowDrop = true;
			this._lblCommon_4.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_4.Text = "Area Code";
			this._lblCommon_4.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_4.Location = new System.Drawing.Point(8, 97);
			// // this._lblCommon_4.mLabelId = 1148;
			this._lblCommon_4.Name = "_lblCommon_4";
			this._lblCommon_4.Size = new System.Drawing.Size(52, 14);
			this._lblCommon_4.TabIndex = 24;
			// 
			// _txtCommon_2
			// 
			this._txtCommon_2.AllowDrop = true;
			this._txtCommon_2.BackColor = System.Drawing.Color.White;
			// this._txtCommon_2.bolNumericOnly = true;
			this._txtCommon_2.ForeColor = System.Drawing.Color.Black;
			this._txtCommon_2.Location = new System.Drawing.Point(157, 95);
			this._txtCommon_2.MaxLength = 15;
			this._txtCommon_2.Name = "_txtCommon_2";
			// this._txtCommon_2.ShowButton = true;
			this._txtCommon_2.Size = new System.Drawing.Size(101, 19);
			this._txtCommon_2.TabIndex = 25;
			this._txtCommon_2.Text = "";
			// this.this._txtCommon_2.Watermark = "";
			// this.this._txtCommon_2.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommon_DropButtonClick);
			// this._txtCommon_2.Leave += new System.EventHandler(this.txtCommon_Leave);
			// 
			// _txtCommon_1
			// 
			this._txtCommon_1.AllowDrop = true;
			this._txtCommon_1.BackColor = System.Drawing.Color.White;
			this._txtCommon_1.ForeColor = System.Drawing.Color.Black;
			this._txtCommon_1.Location = new System.Drawing.Point(157, 32);
			this._txtCommon_1.MaxLength = 250;
			this._txtCommon_1.Name = "_txtCommon_1";
			this._txtCommon_1.Size = new System.Drawing.Size(201, 19);
			this._txtCommon_1.TabIndex = 26;
			this._txtCommon_1.Text = "";
			// this.this._txtCommon_1.Watermark = "";
			// this.this._txtCommon_1.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommon_DropButtonClick);
			// this._txtCommon_1.Leave += new System.EventHandler(this.txtCommon_Leave);
			// 
			// _lblCommon_7
			// 
			this._lblCommon_7.AllowDrop = true;
			this._lblCommon_7.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_7.Text = "Total Floors";
			this._lblCommon_7.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_7.Location = new System.Drawing.Point(8, 286);
			// // this._lblCommon_7.mLabelId = 1192;
			this._lblCommon_7.Name = "_lblCommon_7";
			this._lblCommon_7.Size = new System.Drawing.Size(56, 14);
			this._lblCommon_7.TabIndex = 27;
			// 
			// _txtCommon_3
			// 
			this._txtCommon_3.AllowDrop = true;
			this._txtCommon_3.BackColor = System.Drawing.Color.White;
			// this._txtCommon_3.bolNumericOnly = true;
			this._txtCommon_3.ForeColor = System.Drawing.Color.Black;
			this._txtCommon_3.Location = new System.Drawing.Point(157, 284);
			this._txtCommon_3.MaxLength = 15;
			this._txtCommon_3.Name = "_txtCommon_3";
			this._txtCommon_3.Size = new System.Drawing.Size(101, 19);
			this._txtCommon_3.TabIndex = 28;
			this._txtCommon_3.Text = "";
			// this.this._txtCommon_3.Watermark = "";
			// this.this._txtCommon_3.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommon_DropButtonClick);
			// this._txtCommon_3.Leave += new System.EventHandler(this.txtCommon_Leave);
			// 
			// _lblCommon_3
			// 
			this._lblCommon_3.AllowDrop = true;
			this._lblCommon_3.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_3.Text = "Property Type Code";
			this._lblCommon_3.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_3.Location = new System.Drawing.Point(8, 76);
			// // this._lblCommon_3.mLabelId = 1191;
			this._lblCommon_3.Name = "_lblCommon_3";
			this._lblCommon_3.Size = new System.Drawing.Size(96, 14);
			this._lblCommon_3.TabIndex = 29;
			// 
			// _txtCommon_5
			// 
			this._txtCommon_5.AllowDrop = true;
			this._txtCommon_5.BackColor = System.Drawing.Color.White;
			// this._txtCommon_5.bolNumericOnly = true;
			this._txtCommon_5.ForeColor = System.Drawing.Color.Black;
			this._txtCommon_5.Location = new System.Drawing.Point(157, 74);
			this._txtCommon_5.MaxLength = 15;
			this._txtCommon_5.Name = "_txtCommon_5";
			// this._txtCommon_5.ShowButton = true;
			this._txtCommon_5.Size = new System.Drawing.Size(101, 19);
			this._txtCommon_5.TabIndex = 30;
			this._txtCommon_5.Text = "";
			// this.this._txtCommon_5.Watermark = "";
			// this.this._txtCommon_5.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommon_DropButtonClick);
			// this._txtCommon_5.Leave += new System.EventHandler(this.txtCommon_Leave);
			// 
			// _lblCommon_8
			// 
			this._lblCommon_8.AllowDrop = true;
			this._lblCommon_8.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_8.Text = "Other Facilities";
			this._lblCommon_8.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_8.Location = new System.Drawing.Point(8, 305);
			// // this._lblCommon_8.mLabelId = 1193;
			this._lblCommon_8.Name = "_lblCommon_8";
			this._lblCommon_8.Size = new System.Drawing.Size(71, 14);
			this._lblCommon_8.TabIndex = 31;
			// 
			// _txtCommon_7
			// 
			this._txtCommon_7.AllowDrop = true;
			this._txtCommon_7.BackColor = System.Drawing.Color.White;
			this._txtCommon_7.ForeColor = System.Drawing.Color.Black;
			this._txtCommon_7.Location = new System.Drawing.Point(157, 345);
			this._txtCommon_7.MaxLength = 250;
			// this._txtCommon_7.mDropDownType = System.Windows.Forms.TextBox.DropDownTypes.ddtNextNumber;
			this._txtCommon_7.Name = "_txtCommon_7";
			this._txtCommon_7.Size = new System.Drawing.Size(304, 19);
			this._txtCommon_7.TabIndex = 32;
			this._txtCommon_7.Text = "";
			// this.this._txtCommon_7.Watermark = "";
			// this.this._txtCommon_7.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommon_DropButtonClick);
			// this._txtCommon_7.Leave += new System.EventHandler(this.txtCommon_Leave);
			// 
			// _lblCommon_9
			// 
			this._lblCommon_9.AllowDrop = true;
			this._lblCommon_9.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_9.Text = "Address";
			this._lblCommon_9.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_9.Location = new System.Drawing.Point(8, 347);
			// // this._lblCommon_9.mLabelId = 1188;
			this._lblCommon_9.Name = "_lblCommon_9";
			this._lblCommon_9.Size = new System.Drawing.Size(38, 13);
			this._lblCommon_9.TabIndex = 33;
			// 
			// _lblCommon_2
			// 
			this._lblCommon_2.AllowDrop = true;
			this._lblCommon_2.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_2.Text = "Property Name  (Arabic)";
			this._lblCommon_2.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_2.Location = new System.Drawing.Point(8, 56);
			// // this._lblCommon_2.mLabelId = 1190;
			this._lblCommon_2.Name = "_lblCommon_2";
			this._lblCommon_2.Size = new System.Drawing.Size(117, 14);
			this._lblCommon_2.TabIndex = 34;
			// 
			// _txtCommon_8
			// 
			this._txtCommon_8.AllowDrop = true;
			this._txtCommon_8.BackColor = System.Drawing.Color.White;
			this._txtCommon_8.ForeColor = System.Drawing.Color.Black;
			this._txtCommon_8.Location = new System.Drawing.Point(157, 53);
			// this._txtCommon_8.mArabicEnabled = true;
			this._txtCommon_8.MaxLength = 250;
			this._txtCommon_8.Name = "_txtCommon_8";
			this._txtCommon_8.Size = new System.Drawing.Size(201, 19);
			this._txtCommon_8.TabIndex = 35;
			this._txtCommon_8.Text = "";
			// this.this._txtCommon_8.Watermark = "";
			// this.this._txtCommon_8.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommon_DropButtonClick);
			// this._txtCommon_8.Leave += new System.EventHandler(this.txtCommon_Leave);
			// 
			// _lblCommon_5
			// 
			this._lblCommon_5.AllowDrop = true;
			this._lblCommon_5.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_5.Text = "Guard Code";
			this._lblCommon_5.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_5.Location = new System.Drawing.Point(8, 118);
			// // this._lblCommon_5.mLabelId = 1179;
			this._lblCommon_5.Name = "_lblCommon_5";
			this._lblCommon_5.Size = new System.Drawing.Size(58, 14);
			this._lblCommon_5.TabIndex = 36;
			// 
			// _txtCommon_4
			// 
			this._txtCommon_4.AllowDrop = true;
			this._txtCommon_4.BackColor = System.Drawing.Color.White;
			// this._txtCommon_4.bolNumericOnly = true;
			this._txtCommon_4.ForeColor = System.Drawing.Color.Black;
			this._txtCommon_4.Location = new System.Drawing.Point(157, 116);
			this._txtCommon_4.MaxLength = 15;
			this._txtCommon_4.Name = "_txtCommon_4";
			// this._txtCommon_4.ShowButton = true;
			this._txtCommon_4.Size = new System.Drawing.Size(101, 19);
			this._txtCommon_4.TabIndex = 37;
			this._txtCommon_4.Text = "";
			// this.this._txtCommon_4.Watermark = "";
			// this.this._txtCommon_4.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommon_DropButtonClick);
			// this._txtCommon_4.Leave += new System.EventHandler(this.txtCommon_Leave);
			// 
			// _lblCommon_6
			// 
			this._lblCommon_6.AllowDrop = true;
			this._lblCommon_6.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_6.Text = "Status Code";
			this._lblCommon_6.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_6.Location = new System.Drawing.Point(8, 139);
			// // this._lblCommon_6.mLabelId = 1159;
			this._lblCommon_6.Name = "_lblCommon_6";
			this._lblCommon_6.Size = new System.Drawing.Size(59, 14);
			this._lblCommon_6.TabIndex = 38;
			// 
			// _txtCommon_9
			// 
			this._txtCommon_9.AllowDrop = true;
			this._txtCommon_9.BackColor = System.Drawing.Color.White;
			// this._txtCommon_9.bolNumericOnly = true;
			this._txtCommon_9.ForeColor = System.Drawing.Color.Black;
			this._txtCommon_9.Location = new System.Drawing.Point(157, 137);
			this._txtCommon_9.MaxLength = 15;
			this._txtCommon_9.Name = "_txtCommon_9";
			// this._txtCommon_9.ShowButton = true;
			this._txtCommon_9.Size = new System.Drawing.Size(101, 19);
			this._txtCommon_9.TabIndex = 39;
			this._txtCommon_9.Text = "";
			// this.this._txtCommon_9.Watermark = "";
			// this.this._txtCommon_9.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommon_DropButtonClick);
			// this._txtCommon_9.Leave += new System.EventHandler(this.txtCommon_Leave);
			// 
			// _txtCommon_6
			// 
			this._txtCommon_6.AllowDrop = true;
			this._txtCommon_6.BackColor = System.Drawing.Color.White;
			this._txtCommon_6.ForeColor = System.Drawing.Color.Black;
			this._txtCommon_6.Location = new System.Drawing.Point(157, 305);
			this._txtCommon_6.MaxLength = 250;
			// this._txtCommon_6.mDropDownType = System.Windows.Forms.TextBox.DropDownTypes.ddtNextNumber;
			this._txtCommon_6.Name = "_txtCommon_6";
			this._txtCommon_6.Size = new System.Drawing.Size(304, 38);
			this._txtCommon_6.TabIndex = 40;
			this._txtCommon_6.Text = "";
			// this.this._txtCommon_6.Watermark = "";
			// this.this._txtCommon_6.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommon_DropButtonClick);
			// this._txtCommon_6.Leave += new System.EventHandler(this.txtCommon_Leave);
			// 
			// _txtCommonDisplay_3
			// 
			this._txtCommonDisplay_3.AllowDrop = true;
			this._txtCommonDisplay_3.Location = new System.Drawing.Point(260, 137);
			this._txtCommonDisplay_3.Name = "_txtCommonDisplay_3";
			this._txtCommonDisplay_3.Size = new System.Drawing.Size(201, 19);
			this._txtCommonDisplay_3.TabIndex = 41;
			// 
			// _txtCommonDisplay_2
			// 
			this._txtCommonDisplay_2.AllowDrop = true;
			this._txtCommonDisplay_2.Location = new System.Drawing.Point(260, 116);
			this._txtCommonDisplay_2.Name = "_txtCommonDisplay_2";
			this._txtCommonDisplay_2.Size = new System.Drawing.Size(201, 19);
			this._txtCommonDisplay_2.TabIndex = 42;
			// 
			// _txtCommonDisplay_1
			// 
			this._txtCommonDisplay_1.AllowDrop = true;
			this._txtCommonDisplay_1.Location = new System.Drawing.Point(260, 95);
			this._txtCommonDisplay_1.Name = "_txtCommonDisplay_1";
			this._txtCommonDisplay_1.Size = new System.Drawing.Size(201, 19);
			this._txtCommonDisplay_1.TabIndex = 43;
			// 
			// _txtCommonDisplay_0
			// 
			this._txtCommonDisplay_0.AllowDrop = true;
			this._txtCommonDisplay_0.Location = new System.Drawing.Point(260, 74);
			this._txtCommonDisplay_0.Name = "_txtCommonDisplay_0";
			this._txtCommonDisplay_0.Size = new System.Drawing.Size(201, 19);
			this._txtCommonDisplay_0.TabIndex = 44;
			// 
			// _lblCommon_16
			// 
			this._lblCommon_16.AllowDrop = true;
			this._lblCommon_16.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_16.Text = "Region(In English)";
			this._lblCommon_16.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_16.Location = new System.Drawing.Point(8, 161);
			this._lblCommon_16.Name = "_lblCommon_16";
			this._lblCommon_16.Size = new System.Drawing.Size(86, 13);
			this._lblCommon_16.TabIndex = 45;
			// 
			// _txtCommon_15
			// 
			this._txtCommon_15.AllowDrop = true;
			this._txtCommon_15.BackColor = System.Drawing.Color.White;
			this._txtCommon_15.ForeColor = System.Drawing.Color.Black;
			this._txtCommon_15.Location = new System.Drawing.Point(157, 158);
			this._txtCommon_15.MaxLength = 250;
			this._txtCommon_15.Name = "_txtCommon_15";
			this._txtCommon_15.Size = new System.Drawing.Size(303, 19);
			this._txtCommon_15.TabIndex = 46;
			this._txtCommon_15.Text = "";
			// this.this._txtCommon_15.Watermark = "";
			// this.this._txtCommon_15.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommon_DropButtonClick);
			// this._txtCommon_15.Leave += new System.EventHandler(this.txtCommon_Leave);
			// 
			// _txtCommon_16
			// 
			this._txtCommon_16.AllowDrop = true;
			this._txtCommon_16.BackColor = System.Drawing.Color.White;
			this._txtCommon_16.ForeColor = System.Drawing.Color.Black;
			this._txtCommon_16.Location = new System.Drawing.Point(157, 200);
			this._txtCommon_16.MaxLength = 250;
			this._txtCommon_16.Name = "_txtCommon_16";
			this._txtCommon_16.Size = new System.Drawing.Size(303, 19);
			this._txtCommon_16.TabIndex = 47;
			this._txtCommon_16.Text = "";
			// this.this._txtCommon_16.Watermark = "";
			// this.this._txtCommon_16.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommon_DropButtonClick);
			// this._txtCommon_16.Leave += new System.EventHandler(this.txtCommon_Leave);
			// 
			// _lblCommon_17
			// 
			this._lblCommon_17.AllowDrop = true;
			this._lblCommon_17.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_17.Text = "Building No.";
			this._lblCommon_17.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_17.Location = new System.Drawing.Point(8, 203);
			this._lblCommon_17.Name = "_lblCommon_17";
			this._lblCommon_17.Size = new System.Drawing.Size(57, 13);
			this._lblCommon_17.TabIndex = 48;
			// 
			// _lblCommon_18
			// 
			this._lblCommon_18.AllowDrop = true;
			this._lblCommon_18.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_18.Text = "Street Name(In English)";
			this._lblCommon_18.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_18.Location = new System.Drawing.Point(8, 224);
			this._lblCommon_18.Name = "_lblCommon_18";
			this._lblCommon_18.Size = new System.Drawing.Size(111, 13);
			this._lblCommon_18.TabIndex = 49;
			// 
			// _txtCommon_17
			// 
			this._txtCommon_17.AllowDrop = true;
			this._txtCommon_17.BackColor = System.Drawing.Color.White;
			this._txtCommon_17.ForeColor = System.Drawing.Color.Black;
			this._txtCommon_17.Location = new System.Drawing.Point(157, 221);
			this._txtCommon_17.MaxLength = 250;
			this._txtCommon_17.Name = "_txtCommon_17";
			this._txtCommon_17.Size = new System.Drawing.Size(303, 19);
			this._txtCommon_17.TabIndex = 50;
			this._txtCommon_17.Text = "";
			// this.this._txtCommon_17.Watermark = "";
			// this.this._txtCommon_17.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommon_DropButtonClick);
			// this._txtCommon_17.Leave += new System.EventHandler(this.txtCommon_Leave);
			// 
			// _lblCommon_19
			// 
			this._lblCommon_19.AllowDrop = true;
			this._lblCommon_19.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_19.Text = "Plot";
			this._lblCommon_19.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_19.Location = new System.Drawing.Point(8, 266);
			this._lblCommon_19.Name = "_lblCommon_19";
			this._lblCommon_19.Size = new System.Drawing.Size(18, 13);
			this._lblCommon_19.TabIndex = 51;
			// 
			// _txtCommon_18
			// 
			this._txtCommon_18.AllowDrop = true;
			this._txtCommon_18.BackColor = System.Drawing.Color.White;
			this._txtCommon_18.ForeColor = System.Drawing.Color.Black;
			this._txtCommon_18.Location = new System.Drawing.Point(157, 263);
			this._txtCommon_18.MaxLength = 250;
			this._txtCommon_18.Name = "_txtCommon_18";
			this._txtCommon_18.Size = new System.Drawing.Size(303, 19);
			this._txtCommon_18.TabIndex = 52;
			this._txtCommon_18.Text = "";
			// this.this._txtCommon_18.Watermark = "";
			// this.this._txtCommon_18.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommon_DropButtonClick);
			// this._txtCommon_18.Leave += new System.EventHandler(this.txtCommon_Leave);
			// 
			// _lblCommon_20
			// 
			this._lblCommon_20.AllowDrop = true;
			this._lblCommon_20.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_20.Text = "Region(In Arabic)";
			this._lblCommon_20.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_20.Location = new System.Drawing.Point(8, 182);
			this._lblCommon_20.Name = "_lblCommon_20";
			this._lblCommon_20.Size = new System.Drawing.Size(82, 13);
			this._lblCommon_20.TabIndex = 53;
			// 
			// _txtCommon_19
			// 
			this._txtCommon_19.AllowDrop = true;
			this._txtCommon_19.BackColor = System.Drawing.Color.White;
			this._txtCommon_19.ForeColor = System.Drawing.Color.Black;
			this._txtCommon_19.Location = new System.Drawing.Point(157, 179);
			// this._txtCommon_19.mArabicEnabled = true;
			this._txtCommon_19.MaxLength = 250;
			this._txtCommon_19.Name = "_txtCommon_19";
			this._txtCommon_19.Size = new System.Drawing.Size(303, 19);
			this._txtCommon_19.TabIndex = 54;
			this._txtCommon_19.Text = "";
			// this.this._txtCommon_19.Watermark = "";
			// this.this._txtCommon_19.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommon_DropButtonClick);
			// this._txtCommon_19.Leave += new System.EventHandler(this.txtCommon_Leave);
			// 
			// _lblCommon_21
			// 
			this._lblCommon_21.AllowDrop = true;
			this._lblCommon_21.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_21.Text = "Street Name(In Arabic)";
			this._lblCommon_21.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_21.Location = new System.Drawing.Point(8, 245);
			this._lblCommon_21.Name = "_lblCommon_21";
			this._lblCommon_21.Size = new System.Drawing.Size(107, 13);
			this._lblCommon_21.TabIndex = 55;
			// 
			// _txtCommon_20
			// 
			this._txtCommon_20.AllowDrop = true;
			this._txtCommon_20.BackColor = System.Drawing.Color.White;
			this._txtCommon_20.ForeColor = System.Drawing.Color.Black;
			this._txtCommon_20.Location = new System.Drawing.Point(157, 242);
			// this._txtCommon_20.mArabicEnabled = true;
			this._txtCommon_20.MaxLength = 250;
			this._txtCommon_20.Name = "_txtCommon_20";
			this._txtCommon_20.Size = new System.Drawing.Size(303, 19);
			this._txtCommon_20.TabIndex = 56;
			this._txtCommon_20.Text = "";
			// this.this._txtCommon_20.Watermark = "";
			// this.this._txtCommon_20.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommon_DropButtonClick);
			// this._txtCommon_20.Leave += new System.EventHandler(this.txtCommon_Leave);
			// 
			// _lblCommon_22
			// 
			this._lblCommon_22.AllowDrop = true;
			this._lblCommon_22.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_22.Text = "Property Value";
			this._lblCommon_22.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_22.Location = new System.Drawing.Point(280, 286);
			// // this._lblCommon_22.mLabelId = 1192;
			this._lblCommon_22.Name = "_lblCommon_22";
			this._lblCommon_22.Size = new System.Drawing.Size(69, 13);
			this._lblCommon_22.TabIndex = 57;
			// 
			// _fraMasterInformation_1
			// 
			this._fraMasterInformation_1.AllowDrop = true;
			this._fraMasterInformation_1.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._fraMasterInformation_1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._fraMasterInformation_1.Controls.Add(this._lblCommon_11);
			this._fraMasterInformation_1.Controls.Add(this._txtCommon_10);
			this._fraMasterInformation_1.Controls.Add(this._lblCommon_12);
			this._fraMasterInformation_1.Controls.Add(this._lblCommon_13);
			this._fraMasterInformation_1.Controls.Add(this._lblCommon_14);
			this._fraMasterInformation_1.Controls.Add(this._lblCommon_15);
			this._fraMasterInformation_1.Controls.Add(this._txtCommon_11);
			this._fraMasterInformation_1.Controls.Add(this._txtCommon_12);
			this._fraMasterInformation_1.Controls.Add(this._txtCommon_13);
			this._fraMasterInformation_1.Controls.Add(this._txtCommon_14);
			this._fraMasterInformation_1.Controls.Add(this._txtCommonDisplay_5);
			this._fraMasterInformation_1.Controls.Add(this._txtCommonDisplay_6);
			this._fraMasterInformation_1.Controls.Add(this._txtCommonDisplay_7);
			this._fraMasterInformation_1.Controls.Add(this._txtCommonDisplay_8);
			this._fraMasterInformation_1.Controls.Add(this._txtCommonDisplay_4);
			this._fraMasterInformation_1.Enabled = true;
			this._fraMasterInformation_1.ForeColor = System.Drawing.SystemColors.ControlText;
			this._fraMasterInformation_1.Location = new System.Drawing.Point(519, 23);
			this._fraMasterInformation_1.Name = "_fraMasterInformation_1";
			this._fraMasterInformation_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._fraMasterInformation_1.Size = new System.Drawing.Size(476, 412);
			this._fraMasterInformation_1.TabIndex = 1;
			this._fraMasterInformation_1.Visible = true;
			// 
			// _lblCommon_11
			// 
			this._lblCommon_11.AllowDrop = true;
			this._lblCommon_11.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_11.Text = "GL Revenue A/c";
			this._lblCommon_11.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_11.Location = new System.Drawing.Point(8, 35);
			// // this._lblCommon_11.mLabelId = 1194;
			this._lblCommon_11.Name = "_lblCommon_11";
			this._lblCommon_11.Size = new System.Drawing.Size(82, 13);
			this._lblCommon_11.TabIndex = 2;
			// 
			// _txtCommon_10
			// 
			this._txtCommon_10.AllowDrop = true;
			this._txtCommon_10.BackColor = System.Drawing.Color.White;
			this._txtCommon_10.ForeColor = System.Drawing.Color.Black;
			this._txtCommon_10.Location = new System.Drawing.Point(124, 33);
			this._txtCommon_10.MaxLength = 15;
			this._txtCommon_10.Name = "_txtCommon_10";
			// this._txtCommon_10.ShowButton = true;
			this._txtCommon_10.Size = new System.Drawing.Size(101, 19);
			this._txtCommon_10.TabIndex = 3;
			this._txtCommon_10.Text = "";
			// this.this._txtCommon_10.Watermark = "";
			// this.this._txtCommon_10.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommon_DropButtonClick);
			// this._txtCommon_10.Leave += new System.EventHandler(this.txtCommon_Leave);
			// 
			// _lblCommon_12
			// 
			this._lblCommon_12.AllowDrop = true;
			this._lblCommon_12.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_12.Text = "Accrued Charges A/c";
			this._lblCommon_12.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_12.Location = new System.Drawing.Point(8, 57);
			// // this._lblCommon_12.mLabelId = 1174;
			this._lblCommon_12.Name = "_lblCommon_12";
			this._lblCommon_12.Size = new System.Drawing.Size(103, 13);
			this._lblCommon_12.TabIndex = 4;
			// 
			// _lblCommon_13
			// 
			this._lblCommon_13.AllowDrop = true;
			this._lblCommon_13.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_13.Text = "Cash / Bank A/c";
			this._lblCommon_13.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_13.Location = new System.Drawing.Point(8, 78);
			// // this._lblCommon_13.mLabelId = 1175;
			this._lblCommon_13.Name = "_lblCommon_13";
			this._lblCommon_13.Size = new System.Drawing.Size(81, 13);
			this._lblCommon_13.TabIndex = 5;
			// 
			// _lblCommon_14
			// 
			this._lblCommon_14.AllowDrop = true;
			this._lblCommon_14.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_14.Text = "Advance Receipt A/c";
			this._lblCommon_14.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_14.Location = new System.Drawing.Point(8, 99);
			// // this._lblCommon_14.mLabelId = 1176;
			this._lblCommon_14.Name = "_lblCommon_14";
			this._lblCommon_14.Size = new System.Drawing.Size(104, 13);
			this._lblCommon_14.TabIndex = 6;
			// 
			// _lblCommon_15
			// 
			this._lblCommon_15.AllowDrop = true;
			this._lblCommon_15.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_15.Text = "Discount Allowed A/c";
			this._lblCommon_15.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_15.Location = new System.Drawing.Point(8, 120);
			// // this._lblCommon_15.mLabelId = 1177;
			this._lblCommon_15.Name = "_lblCommon_15";
			this._lblCommon_15.Size = new System.Drawing.Size(103, 13);
			this._lblCommon_15.TabIndex = 7;
			// 
			// _txtCommon_11
			// 
			this._txtCommon_11.AllowDrop = true;
			this._txtCommon_11.BackColor = System.Drawing.Color.White;
			this._txtCommon_11.ForeColor = System.Drawing.Color.Black;
			this._txtCommon_11.Location = new System.Drawing.Point(124, 54);
			this._txtCommon_11.MaxLength = 20;
			this._txtCommon_11.Name = "_txtCommon_11";
			// this._txtCommon_11.ShowButton = true;
			this._txtCommon_11.Size = new System.Drawing.Size(101, 19);
			this._txtCommon_11.TabIndex = 8;
			this._txtCommon_11.Text = "";
			// this.this._txtCommon_11.Watermark = "";
			// this.this._txtCommon_11.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommon_DropButtonClick);
			// this._txtCommon_11.Leave += new System.EventHandler(this.txtCommon_Leave);
			// 
			// _txtCommon_12
			// 
			this._txtCommon_12.AllowDrop = true;
			this._txtCommon_12.BackColor = System.Drawing.Color.White;
			this._txtCommon_12.ForeColor = System.Drawing.Color.Black;
			this._txtCommon_12.Location = new System.Drawing.Point(124, 75);
			this._txtCommon_12.MaxLength = 20;
			this._txtCommon_12.Name = "_txtCommon_12";
			// this._txtCommon_12.ShowButton = true;
			this._txtCommon_12.Size = new System.Drawing.Size(101, 19);
			this._txtCommon_12.TabIndex = 9;
			this._txtCommon_12.Text = "";
			// this.this._txtCommon_12.Watermark = "";
			// this.this._txtCommon_12.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommon_DropButtonClick);
			// this._txtCommon_12.Leave += new System.EventHandler(this.txtCommon_Leave);
			// 
			// _txtCommon_13
			// 
			this._txtCommon_13.AllowDrop = true;
			this._txtCommon_13.BackColor = System.Drawing.Color.White;
			this._txtCommon_13.ForeColor = System.Drawing.Color.Black;
			this._txtCommon_13.Location = new System.Drawing.Point(124, 96);
			this._txtCommon_13.MaxLength = 20;
			this._txtCommon_13.Name = "_txtCommon_13";
			// this._txtCommon_13.ShowButton = true;
			this._txtCommon_13.Size = new System.Drawing.Size(101, 19);
			this._txtCommon_13.TabIndex = 10;
			this._txtCommon_13.Text = "";
			// this.this._txtCommon_13.Watermark = "";
			// this.this._txtCommon_13.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommon_DropButtonClick);
			// this._txtCommon_13.Leave += new System.EventHandler(this.txtCommon_Leave);
			// 
			// _txtCommon_14
			// 
			this._txtCommon_14.AllowDrop = true;
			this._txtCommon_14.BackColor = System.Drawing.Color.White;
			this._txtCommon_14.ForeColor = System.Drawing.Color.Black;
			this._txtCommon_14.Location = new System.Drawing.Point(124, 117);
			this._txtCommon_14.MaxLength = 20;
			this._txtCommon_14.Name = "_txtCommon_14";
			// this._txtCommon_14.ShowButton = true;
			this._txtCommon_14.Size = new System.Drawing.Size(101, 19);
			this._txtCommon_14.TabIndex = 11;
			this._txtCommon_14.Text = "";
			// this.this._txtCommon_14.Watermark = "";
			// this.this._txtCommon_14.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommon_DropButtonClick);
			// this._txtCommon_14.Leave += new System.EventHandler(this.txtCommon_Leave);
			// 
			// _txtCommonDisplay_5
			// 
			this._txtCommonDisplay_5.AllowDrop = true;
			this._txtCommonDisplay_5.Location = new System.Drawing.Point(228, 54);
			this._txtCommonDisplay_5.Name = "_txtCommonDisplay_5";
			this._txtCommonDisplay_5.Size = new System.Drawing.Size(201, 19);
			this._txtCommonDisplay_5.TabIndex = 12;
			// 
			// _txtCommonDisplay_6
			// 
			this._txtCommonDisplay_6.AllowDrop = true;
			this._txtCommonDisplay_6.Location = new System.Drawing.Point(228, 75);
			this._txtCommonDisplay_6.Name = "_txtCommonDisplay_6";
			this._txtCommonDisplay_6.Size = new System.Drawing.Size(201, 19);
			this._txtCommonDisplay_6.TabIndex = 13;
			// 
			// _txtCommonDisplay_7
			// 
			this._txtCommonDisplay_7.AllowDrop = true;
			this._txtCommonDisplay_7.Location = new System.Drawing.Point(228, 96);
			this._txtCommonDisplay_7.Name = "_txtCommonDisplay_7";
			this._txtCommonDisplay_7.Size = new System.Drawing.Size(201, 19);
			this._txtCommonDisplay_7.TabIndex = 14;
			// 
			// _txtCommonDisplay_8
			// 
			this._txtCommonDisplay_8.AllowDrop = true;
			this._txtCommonDisplay_8.Location = new System.Drawing.Point(228, 117);
			this._txtCommonDisplay_8.Name = "_txtCommonDisplay_8";
			this._txtCommonDisplay_8.Size = new System.Drawing.Size(201, 19);
			this._txtCommonDisplay_8.TabIndex = 15;
			// 
			// _txtCommonDisplay_4
			// 
			this._txtCommonDisplay_4.AllowDrop = true;
			this._txtCommonDisplay_4.Location = new System.Drawing.Point(228, 33);
			this._txtCommonDisplay_4.Name = "_txtCommonDisplay_4";
			this._txtCommonDisplay_4.Size = new System.Drawing.Size(201, 19);
			this._txtCommonDisplay_4.TabIndex = 16;
			// 
			// frmREProperty
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.ClientSize = new System.Drawing.Size(1369, 680);
			this.Controls.Add(this.tabMaster);
			//this.Icon = (System.Drawing.Icon) resources.GetObject("frmREProperty.Icon");
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(111, 99);
			this.MaximizeBox = true;
			this.MinimizeBox = true;
			this.Name = "frmREProperty";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Property Details";
			// this.Activated += new System.EventHandler(this.frmREProperty_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
			// this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
			//((System.ComponentModel.ISupportInitialize) this.tabMaster).EndInit();
			this.tabMaster.ResumeLayout(false);
			this._fraMasterInformation_0.ResumeLayout(false);
			this._fraMasterInformation_1.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		void ReLoadForm(bool addEvents)
		{
			InitializetxtCommonDisplay();
			InitializetxtCommon();
			InitializelblCommon();
			InitializefraMasterInformation();
			//This form is an MDI child.
			//This code simulates the VB6 
			// functionality of automatically
			// loading and showing an MDI
			// child's parent.
			this.MdiParent = Xtreme.frmSysMain.DefInstance;
			Xtreme.frmSysMain.DefInstance.Show();
		}
		void InitializetxtCommonDisplay()
		{
			this.txtCommonDisplay = new System.Windows.Forms.Label[9];
			this.txtCommonDisplay[3] = _txtCommonDisplay_3;
			this.txtCommonDisplay[2] = _txtCommonDisplay_2;
			this.txtCommonDisplay[1] = _txtCommonDisplay_1;
			this.txtCommonDisplay[0] = _txtCommonDisplay_0;
			this.txtCommonDisplay[5] = _txtCommonDisplay_5;
			this.txtCommonDisplay[6] = _txtCommonDisplay_6;
			this.txtCommonDisplay[7] = _txtCommonDisplay_7;
			this.txtCommonDisplay[8] = _txtCommonDisplay_8;
			this.txtCommonDisplay[4] = _txtCommonDisplay_4;
		}
		void InitializetxtCommon()
		{
			this.txtCommon = new System.Windows.Forms.TextBox[21];
			this.txtCommon[0] = _txtCommon_0;
			this.txtCommon[2] = _txtCommon_2;
			this.txtCommon[1] = _txtCommon_1;
			this.txtCommon[3] = _txtCommon_3;
			this.txtCommon[5] = _txtCommon_5;
			this.txtCommon[7] = _txtCommon_7;
			this.txtCommon[8] = _txtCommon_8;
			this.txtCommon[4] = _txtCommon_4;
			this.txtCommon[9] = _txtCommon_9;
			this.txtCommon[6] = _txtCommon_6;
			this.txtCommon[15] = _txtCommon_15;
			this.txtCommon[16] = _txtCommon_16;
			this.txtCommon[17] = _txtCommon_17;
			this.txtCommon[18] = _txtCommon_18;
			this.txtCommon[19] = _txtCommon_19;
			this.txtCommon[20] = _txtCommon_20;
			this.txtCommon[10] = _txtCommon_10;
			this.txtCommon[11] = _txtCommon_11;
			this.txtCommon[12] = _txtCommon_12;
			this.txtCommon[13] = _txtCommon_13;
			this.txtCommon[14] = _txtCommon_14;
		}
		void InitializelblCommon()
		{
			this.lblCommon = new System.Windows.Forms.Label[23];
			this.lblCommon[1] = _lblCommon_1;
			this.lblCommon[10] = _lblCommon_10;
			this.lblCommon[0] = _lblCommon_0;
			this.lblCommon[4] = _lblCommon_4;
			this.lblCommon[7] = _lblCommon_7;
			this.lblCommon[3] = _lblCommon_3;
			this.lblCommon[8] = _lblCommon_8;
			this.lblCommon[9] = _lblCommon_9;
			this.lblCommon[2] = _lblCommon_2;
			this.lblCommon[5] = _lblCommon_5;
			this.lblCommon[6] = _lblCommon_6;
			this.lblCommon[16] = _lblCommon_16;
			this.lblCommon[17] = _lblCommon_17;
			this.lblCommon[18] = _lblCommon_18;
			this.lblCommon[19] = _lblCommon_19;
			this.lblCommon[20] = _lblCommon_20;
			this.lblCommon[21] = _lblCommon_21;
			this.lblCommon[22] = _lblCommon_22;
			this.lblCommon[11] = _lblCommon_11;
			this.lblCommon[12] = _lblCommon_12;
			this.lblCommon[13] = _lblCommon_13;
			this.lblCommon[14] = _lblCommon_14;
			this.lblCommon[15] = _lblCommon_15;
		}
		void InitializefraMasterInformation()
		{
			this.fraMasterInformation = new System.Windows.Forms.Panel[2];
			this.fraMasterInformation[0] = _fraMasterInformation_0;
			this.fraMasterInformation[1] = _fraMasterInformation_1;
		}
		#endregion
	}
}//ENDSHERE
