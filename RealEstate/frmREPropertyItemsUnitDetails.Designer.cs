
namespace Xtreme
{
	partial class frmREPropertyItemsUnitDetails
	{

		#region "Upgrade Support "
		private static frmREPropertyItemsUnitDetails m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmREPropertyItemsUnitDetails DefInstance
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
		public static frmREPropertyItemsUnitDetails CreateInstance()
		{
			frmREPropertyItemsUnitDetails theInstance = new frmREPropertyItemsUnitDetails();
			
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
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "_lblCommon_11", "_txtCommon_8", "_lblCommon_12", "_txtCommon_9", "_lblCommon_15", "_txtCommon_10", "_lblCommon_14", "_txtCommon_11", "_lblCommon_13", "_txtCommon_12", "_lblCommon_9", "_txtCommon_6", "_lblCommon_10", "_txtCommon_7", "_fraMasterInformation_1", "txtRemarks", "_lblCommon_0", "_lblCommon_2", "_lblCommon_1", "_txtCommon_1", "_lblCommon_4", "_lblCommon_5", "_lblCommon_3", "_txtCommon_0", "_txtCommon_2", "_txtCommon_3", "_txtNumber_0", "_lblCommon_6", "_lblCommon_8", "_lblCommon_7", "_txtCommonDisplay_6", "_txtCommonDisplay_5", "_txtCommonDisplay_3", "_txtCommonDisplay_0", "_txtCommonDisplay_1", "_txtCommonDisplay_2", "_txtCommonDisplay_4", "_fraMasterInformation_0", "tabMaster", "fraMasterInformation", "lblCommon", "txtCommon", "txtCommonDisplay", "txtNumber"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		private System.Windows.Forms.Label _lblCommon_11;
		private System.Windows.Forms.TextBox _txtCommon_8;
		private System.Windows.Forms.Label _lblCommon_12;
		private System.Windows.Forms.TextBox _txtCommon_9;
		private System.Windows.Forms.Label _lblCommon_15;
		private System.Windows.Forms.TextBox _txtCommon_10;
		private System.Windows.Forms.Label _lblCommon_14;
		private System.Windows.Forms.TextBox _txtCommon_11;
		private System.Windows.Forms.Label _lblCommon_13;
		private System.Windows.Forms.TextBox _txtCommon_12;
		private System.Windows.Forms.Label _lblCommon_9;
		private System.Windows.Forms.TextBox _txtCommon_6;
		private System.Windows.Forms.Label _lblCommon_10;
		private System.Windows.Forms.TextBox _txtCommon_7;
		private System.Windows.Forms.Panel _fraMasterInformation_1;
		public System.Windows.Forms.TextBox txtRemarks;
		private System.Windows.Forms.Label _lblCommon_0;
		private System.Windows.Forms.Label _lblCommon_2;
		private System.Windows.Forms.Label _lblCommon_1;
		private System.Windows.Forms.TextBox _txtCommon_1;
		private System.Windows.Forms.Label _lblCommon_4;
		private System.Windows.Forms.Label _lblCommon_5;
		private System.Windows.Forms.Label _lblCommon_3;
		private System.Windows.Forms.TextBox _txtCommon_0;
		private System.Windows.Forms.TextBox _txtCommon_2;
		private System.Windows.Forms.TextBox _txtCommon_3;
		private System.Windows.Forms.TextBox _txtNumber_0;
		private System.Windows.Forms.Label _lblCommon_6;
		private System.Windows.Forms.Label _lblCommon_8;
		private System.Windows.Forms.Label _lblCommon_7;
		private System.Windows.Forms.Label _txtCommonDisplay_6;
		private System.Windows.Forms.Label _txtCommonDisplay_5;
		private System.Windows.Forms.Label _txtCommonDisplay_3;
		private System.Windows.Forms.Label _txtCommonDisplay_0;
		private System.Windows.Forms.Label _txtCommonDisplay_1;
		private System.Windows.Forms.Label _txtCommonDisplay_2;
		private System.Windows.Forms.Label _txtCommonDisplay_4;
		private System.Windows.Forms.Panel _fraMasterInformation_0;
		public AxC1SizerLib.AxC1Tab tabMaster;
		public System.Windows.Forms.Panel[] fraMasterInformation = new System.Windows.Forms.Panel[2];
		public System.Windows.Forms.Label[] lblCommon = new System.Windows.Forms.Label[16];
		public System.Windows.Forms.TextBox[] txtCommon = new System.Windows.Forms.TextBox[13];
		public System.Windows.Forms.Label[] txtCommonDisplay = new System.Windows.Forms.Label[7];
		public System.Windows.Forms.TextBox[] txtNumber = new System.Windows.Forms.TextBox[1];
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmREPropertyItemsUnitDetails));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this.tabMaster = new AxC1SizerLib.AxC1Tab();
			this._fraMasterInformation_1 = new System.Windows.Forms.Panel();
			this._lblCommon_11 = new System.Windows.Forms.Label();
			this._txtCommon_8 = new System.Windows.Forms.TextBox();
			this._lblCommon_12 = new System.Windows.Forms.Label();
			this._txtCommon_9 = new System.Windows.Forms.TextBox();
			this._lblCommon_15 = new System.Windows.Forms.Label();
			this._txtCommon_10 = new System.Windows.Forms.TextBox();
			this._lblCommon_14 = new System.Windows.Forms.Label();
			this._txtCommon_11 = new System.Windows.Forms.TextBox();
			this._lblCommon_13 = new System.Windows.Forms.Label();
			this._txtCommon_12 = new System.Windows.Forms.TextBox();
			this._lblCommon_9 = new System.Windows.Forms.Label();
			this._txtCommon_6 = new System.Windows.Forms.TextBox();
			this._lblCommon_10 = new System.Windows.Forms.Label();
			this._txtCommon_7 = new System.Windows.Forms.TextBox();
			this._fraMasterInformation_0 = new System.Windows.Forms.Panel();
			this.txtRemarks = new System.Windows.Forms.TextBox();
			this._lblCommon_0 = new System.Windows.Forms.Label();
			this._lblCommon_2 = new System.Windows.Forms.Label();
			this._lblCommon_1 = new System.Windows.Forms.Label();
			this._txtCommon_1 = new System.Windows.Forms.TextBox();
			this._lblCommon_4 = new System.Windows.Forms.Label();
			this._lblCommon_5 = new System.Windows.Forms.Label();
			this._lblCommon_3 = new System.Windows.Forms.Label();
			this._txtCommon_0 = new System.Windows.Forms.TextBox();
			this._txtCommon_2 = new System.Windows.Forms.TextBox();
			this._txtCommon_3 = new System.Windows.Forms.TextBox();
			this._txtNumber_0 = new System.Windows.Forms.TextBox();
			this._lblCommon_6 = new System.Windows.Forms.Label();
			this._lblCommon_8 = new System.Windows.Forms.Label();
			this._lblCommon_7 = new System.Windows.Forms.Label();
			this._txtCommonDisplay_6 = new System.Windows.Forms.Label();
			this._txtCommonDisplay_5 = new System.Windows.Forms.Label();
			this._txtCommonDisplay_3 = new System.Windows.Forms.Label();
			this._txtCommonDisplay_0 = new System.Windows.Forms.Label();
			this._txtCommonDisplay_1 = new System.Windows.Forms.Label();
			this._txtCommonDisplay_2 = new System.Windows.Forms.Label();
			this._txtCommonDisplay_4 = new System.Windows.Forms.Label();
			// //((System.ComponentModel.ISupportInitialize) this.tabMaster).BeginInit();
			this.tabMaster.SuspendLayout();
			this._fraMasterInformation_1.SuspendLayout();
			this._fraMasterInformation_0.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabMaster
			// 
			this.tabMaster.Align = C1SizerLib.AlignSettings.asNone;
			this.tabMaster.AllowDrop = true;
			this.tabMaster.Controls.Add(this._fraMasterInformation_1);
			this.tabMaster.Controls.Add(this._fraMasterInformation_0);
			this.tabMaster.Location = new System.Drawing.Point(8, 32);
			this.tabMaster.Name = "tabMaster";
			("tabMaster.OcxState");
			this.tabMaster.Size = new System.Drawing.Size(448, 250);
			this.tabMaster.TabIndex = 0;
			this.tabMaster.TabStop = false;
			// 
			// _fraMasterInformation_1
			// 
			this._fraMasterInformation_1.AllowDrop = true;
			this._fraMasterInformation_1.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._fraMasterInformation_1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._fraMasterInformation_1.Controls.Add(this._lblCommon_11);
			this._fraMasterInformation_1.Controls.Add(this._txtCommon_8);
			this._fraMasterInformation_1.Controls.Add(this._lblCommon_12);
			this._fraMasterInformation_1.Controls.Add(this._txtCommon_9);
			this._fraMasterInformation_1.Controls.Add(this._lblCommon_15);
			this._fraMasterInformation_1.Controls.Add(this._txtCommon_10);
			this._fraMasterInformation_1.Controls.Add(this._lblCommon_14);
			this._fraMasterInformation_1.Controls.Add(this._txtCommon_11);
			this._fraMasterInformation_1.Controls.Add(this._lblCommon_13);
			this._fraMasterInformation_1.Controls.Add(this._txtCommon_12);
			this._fraMasterInformation_1.Controls.Add(this._lblCommon_9);
			this._fraMasterInformation_1.Controls.Add(this._txtCommon_6);
			this._fraMasterInformation_1.Controls.Add(this._lblCommon_10);
			this._fraMasterInformation_1.Controls.Add(this._txtCommon_7);
			this._fraMasterInformation_1.Enabled = true;
			this._fraMasterInformation_1.ForeColor = System.Drawing.SystemColors.ControlText;
			this._fraMasterInformation_1.Location = new System.Drawing.Point(489, 23);
			this._fraMasterInformation_1.Name = "_fraMasterInformation_1";
			this._fraMasterInformation_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._fraMasterInformation_1.Size = new System.Drawing.Size(446, 226);
			this._fraMasterInformation_1.TabIndex = 24;
			this._fraMasterInformation_1.Visible = true;
			// 
			// _lblCommon_11
			// 
			this._lblCommon_11.AllowDrop = true;
			this._lblCommon_11.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_11.Text = "Total Rest Rooms";
			this._lblCommon_11.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lblCommon_11.Location = new System.Drawing.Point(8, 67);
			// // this._lblCommon_11.mLabelId = 1203;
			this._lblCommon_11.Name = "_lblCommon_11";
			this._lblCommon_11.Size = new System.Drawing.Size(84, 14);
			this._lblCommon_11.TabIndex = 25;
			// 
			// _txtCommon_8
			// 
			this._txtCommon_8.AllowDrop = true;
			this._txtCommon_8.BackColor = System.Drawing.Color.White;
			this._txtCommon_8.ForeColor = System.Drawing.Color.Black;
			this._txtCommon_8.Location = new System.Drawing.Point(108, 64);
			this._txtCommon_8.MaxLength = 10;
			this._txtCommon_8.Name = "_txtCommon_8";
			this._txtCommon_8.Size = new System.Drawing.Size(101, 19);
			this._txtCommon_8.TabIndex = 26;
			this._txtCommon_8.Text = "";
			// this.this._txtCommon_8.Watermark = "";
			// this.this._txtCommon_8.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommon_DropButtonClick);
			// this._txtCommon_8.Leave += new System.EventHandler(this.txtCommon_Leave);
			// 
			// _lblCommon_12
			// 
			this._lblCommon_12.AllowDrop = true;
			this._lblCommon_12.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_12.Text = "Total Balcony";
			this._lblCommon_12.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lblCommon_12.Location = new System.Drawing.Point(8, 88);
			// // this._lblCommon_12.mLabelId = 1204;
			this._lblCommon_12.Name = "_lblCommon_12";
			this._lblCommon_12.Size = new System.Drawing.Size(65, 14);
			this._lblCommon_12.TabIndex = 27;
			// 
			// _txtCommon_9
			// 
			this._txtCommon_9.AllowDrop = true;
			this._txtCommon_9.BackColor = System.Drawing.Color.White;
			this._txtCommon_9.ForeColor = System.Drawing.Color.Black;
			this._txtCommon_9.Location = new System.Drawing.Point(108, 85);
			this._txtCommon_9.MaxLength = 10;
			this._txtCommon_9.Name = "_txtCommon_9";
			this._txtCommon_9.Size = new System.Drawing.Size(101, 19);
			this._txtCommon_9.TabIndex = 28;
			this._txtCommon_9.Text = "";
			// this.this._txtCommon_9.Watermark = "";
			// this.this._txtCommon_9.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommon_DropButtonClick);
			// this._txtCommon_9.Leave += new System.EventHandler(this.txtCommon_Leave);
			// 
			// _lblCommon_15
			// 
			this._lblCommon_15.AllowDrop = true;
			this._lblCommon_15.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_15.Text = "Total Kitchens";
			this._lblCommon_15.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lblCommon_15.Location = new System.Drawing.Point(8, 151);
			// // this._lblCommon_15.mLabelId = 1207;
			this._lblCommon_15.Name = "_lblCommon_15";
			this._lblCommon_15.Size = new System.Drawing.Size(68, 14);
			this._lblCommon_15.TabIndex = 29;
			// 
			// _txtCommon_10
			// 
			this._txtCommon_10.AllowDrop = true;
			this._txtCommon_10.BackColor = System.Drawing.Color.White;
			this._txtCommon_10.ForeColor = System.Drawing.Color.Black;
			this._txtCommon_10.Location = new System.Drawing.Point(108, 148);
			this._txtCommon_10.MaxLength = 10;
			this._txtCommon_10.Name = "_txtCommon_10";
			this._txtCommon_10.Size = new System.Drawing.Size(101, 19);
			this._txtCommon_10.TabIndex = 30;
			this._txtCommon_10.Text = "";
			// this.this._txtCommon_10.Watermark = "";
			// this.this._txtCommon_10.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommon_DropButtonClick);
			// this._txtCommon_10.Leave += new System.EventHandler(this.txtCommon_Leave);
			// 
			// _lblCommon_14
			// 
			this._lblCommon_14.AllowDrop = true;
			this._lblCommon_14.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_14.Text = "Total Bed Rooms";
			this._lblCommon_14.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lblCommon_14.Location = new System.Drawing.Point(8, 130);
			// // this._lblCommon_14.mLabelId = 1206;
			this._lblCommon_14.Name = "_lblCommon_14";
			this._lblCommon_14.Size = new System.Drawing.Size(81, 14);
			this._lblCommon_14.TabIndex = 31;
			// 
			// _txtCommon_11
			// 
			this._txtCommon_11.AllowDrop = true;
			this._txtCommon_11.BackColor = System.Drawing.Color.White;
			this._txtCommon_11.ForeColor = System.Drawing.Color.Black;
			this._txtCommon_11.Location = new System.Drawing.Point(108, 127);
			this._txtCommon_11.MaxLength = 10;
			this._txtCommon_11.Name = "_txtCommon_11";
			this._txtCommon_11.Size = new System.Drawing.Size(101, 19);
			this._txtCommon_11.TabIndex = 32;
			this._txtCommon_11.Text = "";
			// this.this._txtCommon_11.Watermark = "";
			// this.this._txtCommon_11.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommon_DropButtonClick);
			// this._txtCommon_11.Leave += new System.EventHandler(this.txtCommon_Leave);
			// 
			// _lblCommon_13
			// 
			this._lblCommon_13.AllowDrop = true;
			this._lblCommon_13.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_13.Text = "Total Bath Rooms";
			this._lblCommon_13.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lblCommon_13.Location = new System.Drawing.Point(8, 109);
			// // this._lblCommon_13.mLabelId = 1205;
			this._lblCommon_13.Name = "_lblCommon_13";
			this._lblCommon_13.Size = new System.Drawing.Size(84, 14);
			this._lblCommon_13.TabIndex = 33;
			// 
			// _txtCommon_12
			// 
			this._txtCommon_12.AllowDrop = true;
			this._txtCommon_12.BackColor = System.Drawing.Color.White;
			this._txtCommon_12.ForeColor = System.Drawing.Color.Black;
			this._txtCommon_12.Location = new System.Drawing.Point(108, 106);
			this._txtCommon_12.MaxLength = 10;
			this._txtCommon_12.Name = "_txtCommon_12";
			this._txtCommon_12.Size = new System.Drawing.Size(101, 19);
			this._txtCommon_12.TabIndex = 34;
			this._txtCommon_12.Text = "";
			// this.this._txtCommon_12.Watermark = "";
			// this.this._txtCommon_12.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommon_DropButtonClick);
			// this._txtCommon_12.Leave += new System.EventHandler(this.txtCommon_Leave);
			// 
			// _lblCommon_9
			// 
			this._lblCommon_9.AllowDrop = true;
			this._lblCommon_9.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_9.Text = "Floor No";
			this._lblCommon_9.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lblCommon_9.Location = new System.Drawing.Point(8, 25);
			// // this._lblCommon_9.mLabelId = 1201;
			this._lblCommon_9.Name = "_lblCommon_9";
			this._lblCommon_9.Size = new System.Drawing.Size(40, 14);
			this._lblCommon_9.TabIndex = 35;
			// 
			// _txtCommon_6
			// 
			this._txtCommon_6.AllowDrop = true;
			this._txtCommon_6.BackColor = System.Drawing.Color.White;
			this._txtCommon_6.ForeColor = System.Drawing.Color.Black;
			this._txtCommon_6.Location = new System.Drawing.Point(108, 22);
			this._txtCommon_6.MaxLength = 10;
			this._txtCommon_6.Name = "_txtCommon_6";
			this._txtCommon_6.Size = new System.Drawing.Size(101, 19);
			this._txtCommon_6.TabIndex = 36;
			this._txtCommon_6.Text = "";
			// this.this._txtCommon_6.Watermark = "";
			// this.this._txtCommon_6.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommon_DropButtonClick);
			// this._txtCommon_6.Leave += new System.EventHandler(this.txtCommon_Leave);
			// 
			// _lblCommon_10
			// 
			this._lblCommon_10.AllowDrop = true;
			this._lblCommon_10.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_10.Text = "Area Size";
			this._lblCommon_10.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lblCommon_10.Location = new System.Drawing.Point(8, 46);
			// // this._lblCommon_10.mLabelId = 1202;
			this._lblCommon_10.Name = "_lblCommon_10";
			this._lblCommon_10.Size = new System.Drawing.Size(48, 14);
			this._lblCommon_10.TabIndex = 37;
			// 
			// _txtCommon_7
			// 
			this._txtCommon_7.AllowDrop = true;
			this._txtCommon_7.BackColor = System.Drawing.Color.White;
			this._txtCommon_7.ForeColor = System.Drawing.Color.Black;
			this._txtCommon_7.Location = new System.Drawing.Point(108, 43);
			this._txtCommon_7.MaxLength = 10;
			this._txtCommon_7.Name = "_txtCommon_7";
			this._txtCommon_7.Size = new System.Drawing.Size(101, 19);
			this._txtCommon_7.TabIndex = 38;
			this._txtCommon_7.Text = "";
			// this.this._txtCommon_7.Watermark = "";
			// this.this._txtCommon_7.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommon_DropButtonClick);
			// this._txtCommon_7.Leave += new System.EventHandler(this.txtCommon_Leave);
			// 
			// _fraMasterInformation_0
			// 
			this._fraMasterInformation_0.AllowDrop = true;
			this._fraMasterInformation_0.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._fraMasterInformation_0.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._fraMasterInformation_0.Controls.Add(this.txtRemarks);
			this._fraMasterInformation_0.Controls.Add(this._lblCommon_0);
			this._fraMasterInformation_0.Controls.Add(this._lblCommon_2);
			this._fraMasterInformation_0.Controls.Add(this._lblCommon_1);
			this._fraMasterInformation_0.Controls.Add(this._txtCommon_1);
			this._fraMasterInformation_0.Controls.Add(this._lblCommon_4);
			this._fraMasterInformation_0.Controls.Add(this._lblCommon_5);
			this._fraMasterInformation_0.Controls.Add(this._lblCommon_3);
			this._fraMasterInformation_0.Controls.Add(this._txtCommon_0);
			this._fraMasterInformation_0.Controls.Add(this._txtCommon_2);
			this._fraMasterInformation_0.Controls.Add(this._txtCommon_3);
			this._fraMasterInformation_0.Controls.Add(this._txtNumber_0);
			this._fraMasterInformation_0.Controls.Add(this._lblCommon_6);
			this._fraMasterInformation_0.Controls.Add(this._lblCommon_8);
			this._fraMasterInformation_0.Controls.Add(this._lblCommon_7);
			this._fraMasterInformation_0.Controls.Add(this._txtCommonDisplay_6);
			this._fraMasterInformation_0.Controls.Add(this._txtCommonDisplay_5);
			this._fraMasterInformation_0.Controls.Add(this._txtCommonDisplay_3);
			this._fraMasterInformation_0.Controls.Add(this._txtCommonDisplay_0);
			this._fraMasterInformation_0.Controls.Add(this._txtCommonDisplay_1);
			this._fraMasterInformation_0.Controls.Add(this._txtCommonDisplay_2);
			this._fraMasterInformation_0.Controls.Add(this._txtCommonDisplay_4);
			this._fraMasterInformation_0.Enabled = true;
			this._fraMasterInformation_0.ForeColor = System.Drawing.SystemColors.WindowText;
			this._fraMasterInformation_0.Location = new System.Drawing.Point(1, 23);
			this._fraMasterInformation_0.Name = "_fraMasterInformation_0";
			this._fraMasterInformation_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._fraMasterInformation_0.Size = new System.Drawing.Size(446, 226);
			this._fraMasterInformation_0.TabIndex = 1;
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
			this.txtRemarks.Location = new System.Drawing.Point(108, 169);
			this.txtRemarks.MaxLength = 250;
			this.txtRemarks.Multiline = true;
			this.txtRemarks.Name = "txtRemarks";
			this.txtRemarks.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtRemarks.Size = new System.Drawing.Size(305, 35);
			this.txtRemarks.TabIndex = 2;
			// 
			// _lblCommon_0
			// 
			this._lblCommon_0.AllowDrop = true;
			this._lblCommon_0.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_0.Text = "Unit Code";
			this._lblCommon_0.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_0.Location = new System.Drawing.Point(8, 66);
			// // this._lblCommon_0.mLabelId = 988;
			this._lblCommon_0.Name = "_lblCommon_0";
			this._lblCommon_0.Size = new System.Drawing.Size(46, 14);
			this._lblCommon_0.TabIndex = 3;
			// 
			// _lblCommon_2
			// 
			this._lblCommon_2.AllowDrop = true;
			this._lblCommon_2.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_2.Text = "Property Code";
			this._lblCommon_2.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_2.Location = new System.Drawing.Point(8, 24);
			// // this._lblCommon_2.mLabelId = 1158;
			this._lblCommon_2.Name = "_lblCommon_2";
			this._lblCommon_2.Size = new System.Drawing.Size(69, 14);
			this._lblCommon_2.TabIndex = 4;
			// 
			// _lblCommon_1
			// 
			this._lblCommon_1.AllowDrop = true;
			this._lblCommon_1.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_1.Text = "Item Code";
			this._lblCommon_1.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_1.Location = new System.Drawing.Point(8, 46);
			// // this._lblCommon_1.mLabelId = 340;
			this._lblCommon_1.Name = "_lblCommon_1";
			this._lblCommon_1.Size = new System.Drawing.Size(47, 14);
			this._lblCommon_1.TabIndex = 5;
			// 
			// _txtCommon_1
			// 
			this._txtCommon_1.AllowDrop = true;
			this._txtCommon_1.BackColor = System.Drawing.Color.White;
			// this._txtCommon_1.bolNumericOnly = true;
			this._txtCommon_1.ForeColor = System.Drawing.Color.Black;
			this._txtCommon_1.Location = new System.Drawing.Point(108, 43);
			this._txtCommon_1.MaxLength = 15;
			this._txtCommon_1.Name = "_txtCommon_1";
			// this._txtCommon_1.ShowButton = true;
			this._txtCommon_1.Size = new System.Drawing.Size(101, 19);
			this._txtCommon_1.TabIndex = 6;
			this._txtCommon_1.Text = "";
			// this.this._txtCommon_1.Watermark = "";
			// this.this._txtCommon_1.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommon_DropButtonClick);
			// this._txtCommon_1.Leave += new System.EventHandler(this.txtCommon_Leave);
			// 
			// _lblCommon_4
			// 
			this._lblCommon_4.AllowDrop = true;
			this._lblCommon_4.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_4.Text = "Status Code";
			this._lblCommon_4.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_4.Location = new System.Drawing.Point(8, 109);
			// // this._lblCommon_4.mLabelId = 1159;
			this._lblCommon_4.Name = "_lblCommon_4";
			this._lblCommon_4.Size = new System.Drawing.Size(59, 14);
			this._lblCommon_4.TabIndex = 7;
			// 
			// _lblCommon_5
			// 
			this._lblCommon_5.AllowDrop = true;
			this._lblCommon_5.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_5.Text = "Contract Code";
			this._lblCommon_5.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_5.Location = new System.Drawing.Point(8, 130);
			// // this._lblCommon_5.mLabelId = 1200;
			this._lblCommon_5.Name = "_lblCommon_5";
			this._lblCommon_5.Size = new System.Drawing.Size(69, 14);
			this._lblCommon_5.TabIndex = 8;
			// 
			// _lblCommon_3
			// 
			this._lblCommon_3.AllowDrop = true;
			this._lblCommon_3.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_3.Text = "Unit Amount";
			this._lblCommon_3.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_3.Location = new System.Drawing.Point(8, 88);
			// // this._lblCommon_3.mLabelId = 1199;
			this._lblCommon_3.Name = "_lblCommon_3";
			this._lblCommon_3.Size = new System.Drawing.Size(58, 14);
			this._lblCommon_3.TabIndex = 9;
			// 
			// _txtCommon_0
			// 
			this._txtCommon_0.AllowDrop = true;
			this._txtCommon_0.BackColor = System.Drawing.Color.White;
			this._txtCommon_0.ForeColor = System.Drawing.Color.Black;
			this._txtCommon_0.Location = new System.Drawing.Point(108, 64);
			this._txtCommon_0.MaxLength = 15;
			// this._txtCommon_0.mDropDownType = System.Windows.Forms.TextBox.DropDownTypes.ddtNextNumber;
			this._txtCommon_0.Name = "_txtCommon_0";
			// this._txtCommon_0.ShowButton = true;
			this._txtCommon_0.Size = new System.Drawing.Size(101, 19);
			this._txtCommon_0.TabIndex = 10;
			this._txtCommon_0.Text = "";
			// this.this._txtCommon_0.Watermark = "";
			// this.this._txtCommon_0.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommon_DropButtonClick);
			// this._txtCommon_0.Leave += new System.EventHandler(this.txtCommon_Leave);
			// 
			// _txtCommon_2
			// 
			this._txtCommon_2.AllowDrop = true;
			this._txtCommon_2.BackColor = System.Drawing.Color.White;
			this._txtCommon_2.ForeColor = System.Drawing.Color.Black;
			this._txtCommon_2.Location = new System.Drawing.Point(108, 22);
			this._txtCommon_2.MaxLength = 15;
			this._txtCommon_2.Name = "_txtCommon_2";
			// this._txtCommon_2.ShowButton = true;
			this._txtCommon_2.Size = new System.Drawing.Size(101, 19);
			this._txtCommon_2.TabIndex = 11;
			this._txtCommon_2.Text = "";
			// this.this._txtCommon_2.Watermark = "";
			// this.this._txtCommon_2.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommon_DropButtonClick);
			// this._txtCommon_2.Leave += new System.EventHandler(this.txtCommon_Leave);
			// 
			// _txtCommon_3
			// 
			this._txtCommon_3.AllowDrop = true;
			this._txtCommon_3.BackColor = System.Drawing.Color.FromArgb(239, 239, 239);
			// this._txtCommon_3.bolNumericOnly = true;
			this._txtCommon_3.Enabled = false;
			this._txtCommon_3.ForeColor = System.Drawing.Color.Black;
			this._txtCommon_3.Location = new System.Drawing.Point(108, 106);
			this._txtCommon_3.MaxLength = 15;
			this._txtCommon_3.Name = "_txtCommon_3";
			// this._txtCommon_3.ShowButton = true;
			this._txtCommon_3.Size = new System.Drawing.Size(101, 19);
			this._txtCommon_3.TabIndex = 12;
			this._txtCommon_3.Text = "";
			// this.this._txtCommon_3.Watermark = "";
			// this.this._txtCommon_3.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommon_DropButtonClick);
			// this._txtCommon_3.Leave += new System.EventHandler(this.txtCommon_Leave);
			// 
			// _txtNumber_0
			// 
			this._txtNumber_0.AllowDrop = true;
			// this._txtNumber_0.DisplayFormat = "########0.000###;;0.000;0.000";
			// this._txtNumber_0.Format = "###########0.000";
			this._txtNumber_0.Location = new System.Drawing.Point(108, 85);
			// this._txtNumber_0.MaxValue = 2147483647;
			// this._txtNumber_0.MinValue = 0;
			this._txtNumber_0.Name = "_txtNumber_0";
			this._txtNumber_0.Size = new System.Drawing.Size(101, 19);
			this._txtNumber_0.TabIndex = 13;
			this._txtNumber_0.Text = "0.000";
			// 
			// _lblCommon_6
			// 
			this._lblCommon_6.AllowDrop = true;
			this._lblCommon_6.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_6.Text = "Contract Amount";
			this._lblCommon_6.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_6.Location = new System.Drawing.Point(218, 130);
			// // this._lblCommon_6.mLabelId = 1172;
			this._lblCommon_6.Name = "_lblCommon_6";
			this._lblCommon_6.Size = new System.Drawing.Size(81, 14);
			this._lblCommon_6.TabIndex = 14;
			// 
			// _lblCommon_8
			// 
			this._lblCommon_8.AllowDrop = true;
			this._lblCommon_8.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_8.Text = "comments";
			this._lblCommon_8.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_8.Location = new System.Drawing.Point(8, 169);
			// // this._lblCommon_8.mLabelId = 135;
			this._lblCommon_8.Name = "_lblCommon_8";
			this._lblCommon_8.Size = new System.Drawing.Size(48, 13);
			this._lblCommon_8.TabIndex = 15;
			// 
			// _lblCommon_7
			// 
			this._lblCommon_7.AllowDrop = true;
			this._lblCommon_7.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_7.Text = "Tenant Code";
			this._lblCommon_7.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_7.Location = new System.Drawing.Point(8, 151);
			// // this._lblCommon_7.mLabelId = 1156;
			this._lblCommon_7.Name = "_lblCommon_7";
			this._lblCommon_7.Size = new System.Drawing.Size(61, 14);
			this._lblCommon_7.TabIndex = 16;
			// 
			// _txtCommonDisplay_6
			// 
			this._txtCommonDisplay_6.AllowDrop = true;
			this._txtCommonDisplay_6.Location = new System.Drawing.Point(108, 148);
			this._txtCommonDisplay_6.Name = "_txtCommonDisplay_6";
			this._txtCommonDisplay_6.Size = new System.Drawing.Size(101, 19);
			this._txtCommonDisplay_6.TabIndex = 17;
			// 
			// _txtCommonDisplay_5
			// 
			this._txtCommonDisplay_5.AllowDrop = true;
			this._txtCommonDisplay_5.Location = new System.Drawing.Point(211, 148);
			this._txtCommonDisplay_5.Name = "_txtCommonDisplay_5";
			this._txtCommonDisplay_5.Size = new System.Drawing.Size(201, 19);
			this._txtCommonDisplay_5.TabIndex = 18;
			// 
			// _txtCommonDisplay_3
			// 
			this._txtCommonDisplay_3.AllowDrop = true;
			this._txtCommonDisplay_3.Location = new System.Drawing.Point(311, 127);
			this._txtCommonDisplay_3.Name = "_txtCommonDisplay_3";
			this._txtCommonDisplay_3.Size = new System.Drawing.Size(101, 19);
			this._txtCommonDisplay_3.TabIndex = 19;
			// 
			// _txtCommonDisplay_0
			// 
			this._txtCommonDisplay_0.AllowDrop = true;
			this._txtCommonDisplay_0.Location = new System.Drawing.Point(211, 43);
			this._txtCommonDisplay_0.Name = "_txtCommonDisplay_0";
			this._txtCommonDisplay_0.Size = new System.Drawing.Size(201, 19);
			this._txtCommonDisplay_0.TabIndex = 20;
			// 
			// _txtCommonDisplay_1
			// 
			this._txtCommonDisplay_1.AllowDrop = true;
			this._txtCommonDisplay_1.Location = new System.Drawing.Point(211, 22);
			this._txtCommonDisplay_1.Name = "_txtCommonDisplay_1";
			this._txtCommonDisplay_1.Size = new System.Drawing.Size(201, 19);
			this._txtCommonDisplay_1.TabIndex = 21;
			// 
			// _txtCommonDisplay_2
			// 
			this._txtCommonDisplay_2.AllowDrop = true;
			this._txtCommonDisplay_2.Location = new System.Drawing.Point(211, 106);
			this._txtCommonDisplay_2.Name = "_txtCommonDisplay_2";
			this._txtCommonDisplay_2.Size = new System.Drawing.Size(201, 19);
			this._txtCommonDisplay_2.TabIndex = 22;
			// 
			// _txtCommonDisplay_4
			// 
			this._txtCommonDisplay_4.AllowDrop = true;
			this._txtCommonDisplay_4.Location = new System.Drawing.Point(108, 127);
			this._txtCommonDisplay_4.Name = "_txtCommonDisplay_4";
			this._txtCommonDisplay_4.Size = new System.Drawing.Size(101, 19);
			this._txtCommonDisplay_4.TabIndex = 23;
			// 
			// frmREPropertyItemsUnitDetails
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.ClientSize = new System.Drawing.Size(1043, 645);
			this.Controls.Add(this.tabMaster);
			//this.Icon = (System.Drawing.Icon) resources.GetObject("frmREPropertyItemsUnitDetails.Icon");
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(66, 133);
			this.MaximizeBox = true;
			this.MinimizeBox = true;
			this.Name = "frmREPropertyItemsUnitDetails";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Property Item Unit Details";
			// this.Activated += new System.EventHandler(this.frmREPropertyItemsUnitDetails_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
			// this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
			//((System.ComponentModel.ISupportInitialize) this.tabMaster).EndInit();
			this.tabMaster.ResumeLayout(false);
			this._fraMasterInformation_1.ResumeLayout(false);
			this._fraMasterInformation_0.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		void ReLoadForm(bool addEvents)
		{
			InitializetxtNumber();
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
		void InitializetxtNumber()
		{
			this.txtNumber = new System.Windows.Forms.TextBox[1];
			this.txtNumber[0] = _txtNumber_0;
		}
		void InitializetxtCommonDisplay()
		{
			this.txtCommonDisplay = new System.Windows.Forms.Label[7];
			this.txtCommonDisplay[6] = _txtCommonDisplay_6;
			this.txtCommonDisplay[5] = _txtCommonDisplay_5;
			this.txtCommonDisplay[3] = _txtCommonDisplay_3;
			this.txtCommonDisplay[0] = _txtCommonDisplay_0;
			this.txtCommonDisplay[1] = _txtCommonDisplay_1;
			this.txtCommonDisplay[2] = _txtCommonDisplay_2;
			this.txtCommonDisplay[4] = _txtCommonDisplay_4;
		}
		void InitializetxtCommon()
		{
			this.txtCommon = new System.Windows.Forms.TextBox[13];
			this.txtCommon[8] = _txtCommon_8;
			this.txtCommon[9] = _txtCommon_9;
			this.txtCommon[10] = _txtCommon_10;
			this.txtCommon[11] = _txtCommon_11;
			this.txtCommon[12] = _txtCommon_12;
			this.txtCommon[6] = _txtCommon_6;
			this.txtCommon[7] = _txtCommon_7;
			this.txtCommon[1] = _txtCommon_1;
			this.txtCommon[0] = _txtCommon_0;
			this.txtCommon[2] = _txtCommon_2;
			this.txtCommon[3] = _txtCommon_3;
		}
		void InitializelblCommon()
		{
			this.lblCommon = new System.Windows.Forms.Label[16];
			this.lblCommon[11] = _lblCommon_11;
			this.lblCommon[12] = _lblCommon_12;
			this.lblCommon[15] = _lblCommon_15;
			this.lblCommon[14] = _lblCommon_14;
			this.lblCommon[13] = _lblCommon_13;
			this.lblCommon[9] = _lblCommon_9;
			this.lblCommon[10] = _lblCommon_10;
			this.lblCommon[0] = _lblCommon_0;
			this.lblCommon[2] = _lblCommon_2;
			this.lblCommon[1] = _lblCommon_1;
			this.lblCommon[4] = _lblCommon_4;
			this.lblCommon[5] = _lblCommon_5;
			this.lblCommon[3] = _lblCommon_3;
			this.lblCommon[6] = _lblCommon_6;
			this.lblCommon[8] = _lblCommon_8;
			this.lblCommon[7] = _lblCommon_7;
		}
		void InitializefraMasterInformation()
		{
			this.fraMasterInformation = new System.Windows.Forms.Panel[2];
			this.fraMasterInformation[1] = _fraMasterInformation_1;
			this.fraMasterInformation[0] = _fraMasterInformation_0;
		}
		#endregion
	}
}//ENDSHERE
