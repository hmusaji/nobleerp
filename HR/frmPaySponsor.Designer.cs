
namespace Xtreme
{
	partial class frmPaySponsors
	{

		#region "Upgrade Support "
		private static frmPaySponsors m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmPaySponsors DefInstance
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
		public static frmPaySponsors CreateInstance()
		{
			frmPaySponsors theInstance = new frmPaySponsors();
			
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
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "_txtCommonTextBox_4", "System.Windows.Forms.Label12", "_txtCommonTextBox_1", "_lblCommonLabel_2", "_lblCommonLabel_7", "_lblCommonLabel_18", "_txtCommonTextBox_2", "_txtCommonTextBox_3", "_txtCommonTextBox_0", "_lblCommonLabel_0", "_txtDisplayLabel_2", "_txtDisplayLabel_1", "_txtDisplayLabel_0", "_txtCommonTextBox_6", "_lblCommonLabel_3", "_lblCommonLabel_8", "_lblCommonLabel_9", "_lblCommonLabel_10", "_lblCommonLabel_12", "_lblCommonLabel_13", "_txtCommonTextBox_7", "_txtCommonTextBox_8", "_txtCommonTextBox_9", "_txtCommonTextBox_10", "_txtCommonTextBox_11", "_txtCommonTextBox_12", "_txtCommonTextBox_13", "_lblCommonLabel_1", "_txtCommonTextBox_14", "_lblCommonLabel_14", "_txtCommonTextBox_15", "_lblCommonLabel_15", "_txtCommonTextBox_16", "_txtCommonTextBox_17", "_lblCommonLabel_16", "_lblCommonLabel_19", "_txtCommonTextBox_18", "_lblCommonLabel_20", "_txtCommonTextBox_19", "_lblCommonLabel_21", "_txtCommonTextBox_20", "_txtCommonTextBox_21", "_lblCommonLabel_22", "_txtCommonTextBox_22", "_lblCommonLabel_23", "_txtCommonTextBox_23", "_lblCommonLabel_24", "_lblCommonLabel_25", "_txtCommonTextBox_24", "_txtCommonTextBox_25", "_lblCommonLabel_26", "_txtCommonTextBox_26", "_lblCommonLabel_27", "_txtCommonTextBox_27", "_lblCommonLabel_28", "_txtCommonTextBox_28", "_lblCommonLabel_29", "_txtCommonTextBox_5", "_lblCommonLabel_4", "lblCommonLabel", "txtCommonTextBox", "txtDisplayLabel"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		private System.Windows.Forms.TextBox _txtCommonTextBox_4;
		public System.Windows.Forms.Label System.Windows.Forms.Label12;
		private System.Windows.Forms.TextBox _txtCommonTextBox_1;
		private System.Windows.Forms.Label _lblCommonLabel_2;
		private System.Windows.Forms.Label _lblCommonLabel_7;
		private System.Windows.Forms.Label _lblCommonLabel_18;
		private System.Windows.Forms.TextBox _txtCommonTextBox_2;
		private System.Windows.Forms.TextBox _txtCommonTextBox_3;
		private System.Windows.Forms.TextBox _txtCommonTextBox_0;
		private System.Windows.Forms.Label _lblCommonLabel_0;
		private System.Windows.Forms.Label _txtDisplayLabel_2;
		private System.Windows.Forms.Label _txtDisplayLabel_1;
		private System.Windows.Forms.Label _txtDisplayLabel_0;
		private System.Windows.Forms.TextBox _txtCommonTextBox_6;
		private System.Windows.Forms.Label _lblCommonLabel_3;
		private System.Windows.Forms.Label _lblCommonLabel_8;
		private System.Windows.Forms.Label _lblCommonLabel_9;
		private System.Windows.Forms.Label _lblCommonLabel_10;
		private System.Windows.Forms.Label _lblCommonLabel_12;
		private System.Windows.Forms.Label _lblCommonLabel_13;
		private System.Windows.Forms.TextBox _txtCommonTextBox_7;
		private System.Windows.Forms.TextBox _txtCommonTextBox_8;
		private System.Windows.Forms.TextBox _txtCommonTextBox_9;
		private System.Windows.Forms.TextBox _txtCommonTextBox_10;
		private System.Windows.Forms.TextBox _txtCommonTextBox_11;
		private System.Windows.Forms.TextBox _txtCommonTextBox_12;
		private System.Windows.Forms.TextBox _txtCommonTextBox_13;
		private System.Windows.Forms.Label _lblCommonLabel_1;
		private System.Windows.Forms.TextBox _txtCommonTextBox_14;
		private System.Windows.Forms.Label _lblCommonLabel_14;
		private System.Windows.Forms.TextBox _txtCommonTextBox_15;
		private System.Windows.Forms.Label _lblCommonLabel_15;
		private System.Windows.Forms.TextBox _txtCommonTextBox_16;
		private System.Windows.Forms.TextBox _txtCommonTextBox_17;
		private System.Windows.Forms.Label _lblCommonLabel_16;
		private System.Windows.Forms.Label _lblCommonLabel_19;
		private System.Windows.Forms.TextBox _txtCommonTextBox_18;
		private System.Windows.Forms.Label _lblCommonLabel_20;
		private System.Windows.Forms.TextBox _txtCommonTextBox_19;
		private System.Windows.Forms.Label _lblCommonLabel_21;
		private System.Windows.Forms.TextBox _txtCommonTextBox_20;
		private System.Windows.Forms.TextBox _txtCommonTextBox_21;
		private System.Windows.Forms.Label _lblCommonLabel_22;
		private System.Windows.Forms.TextBox _txtCommonTextBox_22;
		private System.Windows.Forms.Label _lblCommonLabel_23;
		private System.Windows.Forms.TextBox _txtCommonTextBox_23;
		private System.Windows.Forms.Label _lblCommonLabel_24;
		private System.Windows.Forms.Label _lblCommonLabel_25;
		private System.Windows.Forms.TextBox _txtCommonTextBox_24;
		private System.Windows.Forms.TextBox _txtCommonTextBox_25;
		private System.Windows.Forms.Label _lblCommonLabel_26;
		private System.Windows.Forms.TextBox _txtCommonTextBox_26;
		private System.Windows.Forms.Label _lblCommonLabel_27;
		private System.Windows.Forms.TextBox _txtCommonTextBox_27;
		private System.Windows.Forms.Label _lblCommonLabel_28;
		private System.Windows.Forms.TextBox _txtCommonTextBox_28;
		private System.Windows.Forms.Label _lblCommonLabel_29;
		private System.Windows.Forms.TextBox _txtCommonTextBox_5;
		private System.Windows.Forms.Label _lblCommonLabel_4;
		public System.Windows.Forms.Label[] lblCommonLabel = new System.Windows.Forms.Label[30];
		public System.Windows.Forms.TextBox[] txtCommonTextBox = new System.Windows.Forms.TextBox[29];
		public System.Windows.Forms.Label[] txtDisplayLabel = new System.Windows.Forms.Label[3];
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPaySponsors));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this._txtCommonTextBox_4 = new System.Windows.Forms.TextBox();
			this.System.Windows.Forms.Label12 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_1 = new System.Windows.Forms.TextBox();
			this._lblCommonLabel_2 = new System.Windows.Forms.Label();
			this._lblCommonLabel_7 = new System.Windows.Forms.Label();
			this._lblCommonLabel_18 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_2 = new System.Windows.Forms.TextBox();
			this._txtCommonTextBox_3 = new System.Windows.Forms.TextBox();
			this._txtCommonTextBox_0 = new System.Windows.Forms.TextBox();
			this._lblCommonLabel_0 = new System.Windows.Forms.Label();
			this._txtDisplayLabel_2 = new System.Windows.Forms.Label();
			this._txtDisplayLabel_1 = new System.Windows.Forms.Label();
			this._txtDisplayLabel_0 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_6 = new System.Windows.Forms.TextBox();
			this._lblCommonLabel_3 = new System.Windows.Forms.Label();
			this._lblCommonLabel_8 = new System.Windows.Forms.Label();
			this._lblCommonLabel_9 = new System.Windows.Forms.Label();
			this._lblCommonLabel_10 = new System.Windows.Forms.Label();
			this._lblCommonLabel_12 = new System.Windows.Forms.Label();
			this._lblCommonLabel_13 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_7 = new System.Windows.Forms.TextBox();
			this._txtCommonTextBox_8 = new System.Windows.Forms.TextBox();
			this._txtCommonTextBox_9 = new System.Windows.Forms.TextBox();
			this._txtCommonTextBox_10 = new System.Windows.Forms.TextBox();
			this._txtCommonTextBox_11 = new System.Windows.Forms.TextBox();
			this._txtCommonTextBox_12 = new System.Windows.Forms.TextBox();
			this._txtCommonTextBox_13 = new System.Windows.Forms.TextBox();
			this._lblCommonLabel_1 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_14 = new System.Windows.Forms.TextBox();
			this._lblCommonLabel_14 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_15 = new System.Windows.Forms.TextBox();
			this._lblCommonLabel_15 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_16 = new System.Windows.Forms.TextBox();
			this._txtCommonTextBox_17 = new System.Windows.Forms.TextBox();
			this._lblCommonLabel_16 = new System.Windows.Forms.Label();
			this._lblCommonLabel_19 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_18 = new System.Windows.Forms.TextBox();
			this._lblCommonLabel_20 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_19 = new System.Windows.Forms.TextBox();
			this._lblCommonLabel_21 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_20 = new System.Windows.Forms.TextBox();
			this._txtCommonTextBox_21 = new System.Windows.Forms.TextBox();
			this._lblCommonLabel_22 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_22 = new System.Windows.Forms.TextBox();
			this._lblCommonLabel_23 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_23 = new System.Windows.Forms.TextBox();
			this._lblCommonLabel_24 = new System.Windows.Forms.Label();
			this._lblCommonLabel_25 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_24 = new System.Windows.Forms.TextBox();
			this._txtCommonTextBox_25 = new System.Windows.Forms.TextBox();
			this._lblCommonLabel_26 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_26 = new System.Windows.Forms.TextBox();
			this._lblCommonLabel_27 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_27 = new System.Windows.Forms.TextBox();
			this._lblCommonLabel_28 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_28 = new System.Windows.Forms.TextBox();
			this._lblCommonLabel_29 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_5 = new System.Windows.Forms.TextBox();
			this._lblCommonLabel_4 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// _txtCommonTextBox_4
			// 
			this._txtCommonTextBox_4.AllowDrop = true;
			this._txtCommonTextBox_4.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_4.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_4.Location = new System.Drawing.Point(99, 385);
			this._txtCommonTextBox_4.MaxLength = 200;
			this._txtCommonTextBox_4.Name = "_txtCommonTextBox_4";
			this._txtCommonTextBox_4.Size = new System.Drawing.Size(304, 19);
			this._txtCommonTextBox_4.TabIndex = 28;
			this._txtCommonTextBox_4.Text = "";
			// this.this._txtCommonTextBox_4.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_4.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// System.Windows.Forms.Label12
			// 
			this.System.Windows.Forms.Label12.AllowDrop = true;
			this.System.Windows.Forms.Label12.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.System.Windows.Forms.Label12.Caption = "Comments";
			this.System.Windows.Forms.Label12.Location = new System.Drawing.Point(7, 387);
			this.System.Windows.Forms.Label12.mLabelId = 1851;
			this.System.Windows.Forms.Label12.Name = "System.Windows.Forms.Label12";
			this.System.Windows.Forms.Label12.Size = new System.Drawing.Size(50, 14);
			this.System.Windows.Forms.Label12.TabIndex = 29;
			// 
			// _txtCommonTextBox_1
			// 
			this._txtCommonTextBox_1.AllowDrop = true;
			this._txtCommonTextBox_1.BackColor = System.Drawing.Color.White;
			// this._txtCommonTextBox_1.bolNumericOnly = true;
			this._txtCommonTextBox_1.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_1.Location = new System.Drawing.Point(99, 162);
			this._txtCommonTextBox_1.MaxLength = 4;
			this._txtCommonTextBox_1.Name = "_txtCommonTextBox_1";
			// this._txtCommonTextBox_1.ShowButton = true;
			this._txtCommonTextBox_1.Size = new System.Drawing.Size(101, 19);
			this._txtCommonTextBox_1.TabIndex = 9;
			this._txtCommonTextBox_1.Text = "";
			// this.this._txtCommonTextBox_1.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_1.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _lblCommonLabel_2
			// 
			this._lblCommonLabel_2.AllowDrop = true;
			this._lblCommonLabel_2.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_2.Text = "Nationality Code";
			this._lblCommonLabel_2.Location = new System.Drawing.Point(7, 164);
			// this._lblCommonLabel_2.mLabelId = 1058;
			this._lblCommonLabel_2.Name = "_lblCommonLabel_2";
			this._lblCommonLabel_2.Size = new System.Drawing.Size(77, 14);
			this._lblCommonLabel_2.TabIndex = 30;
			// 
			// _lblCommonLabel_7
			// 
			this._lblCommonLabel_7.AllowDrop = true;
			this._lblCommonLabel_7.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_7.Text = "Company Code";
			this._lblCommonLabel_7.Location = new System.Drawing.Point(7, 186);
			// this._lblCommonLabel_7.mLabelId = 1927;
			this._lblCommonLabel_7.Name = "_lblCommonLabel_7";
			this._lblCommonLabel_7.Size = new System.Drawing.Size(73, 13);
			this._lblCommonLabel_7.TabIndex = 31;
			// 
			// _lblCommonLabel_18
			// 
			this._lblCommonLabel_18.AllowDrop = true;
			this._lblCommonLabel_18.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_18.Text = "Governate Code";
			this._lblCommonLabel_18.Location = new System.Drawing.Point(7, 206);
			// this._lblCommonLabel_18.mLabelId = 1816;
			this._lblCommonLabel_18.Name = "_lblCommonLabel_18";
			this._lblCommonLabel_18.Size = new System.Drawing.Size(79, 14);
			this._lblCommonLabel_18.TabIndex = 32;
			// 
			// _txtCommonTextBox_2
			// 
			this._txtCommonTextBox_2.AllowDrop = true;
			this._txtCommonTextBox_2.BackColor = System.Drawing.Color.White;
			// this._txtCommonTextBox_2.bolNumericOnly = true;
			this._txtCommonTextBox_2.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_2.Location = new System.Drawing.Point(99, 204);
			this._txtCommonTextBox_2.MaxLength = 4;
			this._txtCommonTextBox_2.Name = "_txtCommonTextBox_2";
			// this._txtCommonTextBox_2.ShowButton = true;
			this._txtCommonTextBox_2.Size = new System.Drawing.Size(101, 19);
			this._txtCommonTextBox_2.TabIndex = 11;
			this._txtCommonTextBox_2.Text = "";
			// this.this._txtCommonTextBox_2.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_2.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _txtCommonTextBox_3
			// 
			this._txtCommonTextBox_3.AllowDrop = true;
			this._txtCommonTextBox_3.BackColor = System.Drawing.Color.White;
			// this._txtCommonTextBox_3.bolNumericOnly = true;
			this._txtCommonTextBox_3.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_3.Location = new System.Drawing.Point(99, 183);
			this._txtCommonTextBox_3.MaxLength = 4;
			this._txtCommonTextBox_3.Name = "_txtCommonTextBox_3";
			// this._txtCommonTextBox_3.ShowButton = true;
			this._txtCommonTextBox_3.Size = new System.Drawing.Size(101, 19);
			this._txtCommonTextBox_3.TabIndex = 10;
			this._txtCommonTextBox_3.Text = "";
			// this.this._txtCommonTextBox_3.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_3.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _txtCommonTextBox_0
			// 
			this._txtCommonTextBox_0.AllowDrop = true;
			this._txtCommonTextBox_0.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_0.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_0.Location = new System.Drawing.Point(102, 57);
			this._txtCommonTextBox_0.MaxLength = 50;
			this._txtCommonTextBox_0.Name = "_txtCommonTextBox_0";
			// this._txtCommonTextBox_0.ShowButton = true;
			this._txtCommonTextBox_0.Size = new System.Drawing.Size(101, 19);
			this._txtCommonTextBox_0.TabIndex = 0;
			this._txtCommonTextBox_0.Text = "";
			// this.this._txtCommonTextBox_0.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_0.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _lblCommonLabel_0
			// 
			this._lblCommonLabel_0.AllowDrop = true;
			this._lblCommonLabel_0.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_0.Text = "Sponsor Code";
			this._lblCommonLabel_0.Location = new System.Drawing.Point(7, 59);
			// this._lblCommonLabel_0.mLabelId = 1939;
			this._lblCommonLabel_0.Name = "_lblCommonLabel_0";
			this._lblCommonLabel_0.Size = new System.Drawing.Size(69, 14);
			this._lblCommonLabel_0.TabIndex = 33;
			// 
			// _txtDisplayLabel_2
			// 
			this._txtDisplayLabel_2.AllowDrop = true;
			this._txtDisplayLabel_2.Location = new System.Drawing.Point(202, 183);
			this._txtDisplayLabel_2.Name = "_txtDisplayLabel_2";
			this._txtDisplayLabel_2.Size = new System.Drawing.Size(201, 19);
			this._txtDisplayLabel_2.TabIndex = 34;
			this._txtDisplayLabel_2.TabStop = false;
			// 
			// _txtDisplayLabel_1
			// 
			this._txtDisplayLabel_1.AllowDrop = true;
			this._txtDisplayLabel_1.Location = new System.Drawing.Point(202, 206);
			this._txtDisplayLabel_1.Name = "_txtDisplayLabel_1";
			this._txtDisplayLabel_1.Size = new System.Drawing.Size(201, 19);
			this._txtDisplayLabel_1.TabIndex = 35;
			this._txtDisplayLabel_1.TabStop = false;
			// 
			// _txtDisplayLabel_0
			// 
			this._txtDisplayLabel_0.AllowDrop = true;
			this._txtDisplayLabel_0.Location = new System.Drawing.Point(202, 162);
			this._txtDisplayLabel_0.Name = "_txtDisplayLabel_0";
			this._txtDisplayLabel_0.Size = new System.Drawing.Size(201, 19);
			this._txtDisplayLabel_0.TabIndex = 36;
			this._txtDisplayLabel_0.TabStop = false;
			// 
			// _txtCommonTextBox_6
			// 
			this._txtCommonTextBox_6.AllowDrop = true;
			this._txtCommonTextBox_6.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_6.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_6.Location = new System.Drawing.Point(102, 108);
			this._txtCommonTextBox_6.MaxLength = 50;
			this._txtCommonTextBox_6.Name = "_txtCommonTextBox_6";
			this._txtCommonTextBox_6.Size = new System.Drawing.Size(94, 19);
			this._txtCommonTextBox_6.TabIndex = 1;
			this._txtCommonTextBox_6.Text = "";
			// this.this._txtCommonTextBox_6.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_6.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _lblCommonLabel_3
			// 
			this._lblCommonLabel_3.AllowDrop = true;
			this._lblCommonLabel_3.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_3.Text = "First Name";
			this._lblCommonLabel_3.Location = new System.Drawing.Point(120, 87);
			// this._lblCommonLabel_3.mLabelId = 1974;
			this._lblCommonLabel_3.Name = "_lblCommonLabel_3";
			this._lblCommonLabel_3.Size = new System.Drawing.Size(51, 14);
			this._lblCommonLabel_3.TabIndex = 37;
			// 
			// _lblCommonLabel_8
			// 
			this._lblCommonLabel_8.AllowDrop = true;
			this._lblCommonLabel_8.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_8.Text = "Second Name";
			this._lblCommonLabel_8.Location = new System.Drawing.Point(213, 87);
			// this._lblCommonLabel_8.mLabelId = 1976;
			this._lblCommonLabel_8.Name = "_lblCommonLabel_8";
			this._lblCommonLabel_8.Size = new System.Drawing.Size(67, 14);
			this._lblCommonLabel_8.TabIndex = 38;
			// 
			// _lblCommonLabel_9
			// 
			this._lblCommonLabel_9.AllowDrop = true;
			this._lblCommonLabel_9.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_9.Text = "Third Name";
			this._lblCommonLabel_9.Location = new System.Drawing.Point(309, 87);
			// this._lblCommonLabel_9.mLabelId = 1977;
			this._lblCommonLabel_9.Name = "_lblCommonLabel_9";
			this._lblCommonLabel_9.Size = new System.Drawing.Size(54, 14);
			this._lblCommonLabel_9.TabIndex = 39;
			// 
			// _lblCommonLabel_10
			// 
			this._lblCommonLabel_10.AllowDrop = true;
			this._lblCommonLabel_10.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_10.Text = "Fourth Name";
			this._lblCommonLabel_10.Location = new System.Drawing.Point(405, 87);
			// this._lblCommonLabel_10.mLabelId = 1975;
			this._lblCommonLabel_10.Name = "_lblCommonLabel_10";
			this._lblCommonLabel_10.Size = new System.Drawing.Size(61, 14);
			this._lblCommonLabel_10.TabIndex = 40;
			// 
			// _lblCommonLabel_12
			// 
			this._lblCommonLabel_12.AllowDrop = true;
			this._lblCommonLabel_12.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_12.Text = "Name (English)";
			this._lblCommonLabel_12.Location = new System.Drawing.Point(9, 111);
			// this._lblCommonLabel_12.mLabelId = 1053;
			this._lblCommonLabel_12.Name = "_lblCommonLabel_12";
			this._lblCommonLabel_12.Size = new System.Drawing.Size(72, 14);
			this._lblCommonLabel_12.TabIndex = 41;
			// 
			// _lblCommonLabel_13
			// 
			this._lblCommonLabel_13.AllowDrop = true;
			this._lblCommonLabel_13.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_13.Text = "Name(Arabic)";
			this._lblCommonLabel_13.Location = new System.Drawing.Point(9, 132);
			// this._lblCommonLabel_13.mLabelId = 1054;
			this._lblCommonLabel_13.Name = "_lblCommonLabel_13";
			this._lblCommonLabel_13.Size = new System.Drawing.Size(67, 14);
			this._lblCommonLabel_13.TabIndex = 42;
			// 
			// _txtCommonTextBox_7
			// 
			this._txtCommonTextBox_7.AllowDrop = true;
			this._txtCommonTextBox_7.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_7.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_7.Location = new System.Drawing.Point(198, 108);
			this._txtCommonTextBox_7.MaxLength = 50;
			this._txtCommonTextBox_7.Name = "_txtCommonTextBox_7";
			this._txtCommonTextBox_7.Size = new System.Drawing.Size(94, 19);
			this._txtCommonTextBox_7.TabIndex = 2;
			this._txtCommonTextBox_7.Text = "";
			// this.this._txtCommonTextBox_7.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_7.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _txtCommonTextBox_8
			// 
			this._txtCommonTextBox_8.AllowDrop = true;
			this._txtCommonTextBox_8.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_8.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_8.Location = new System.Drawing.Point(294, 108);
			this._txtCommonTextBox_8.MaxLength = 50;
			this._txtCommonTextBox_8.Name = "_txtCommonTextBox_8";
			this._txtCommonTextBox_8.Size = new System.Drawing.Size(94, 19);
			this._txtCommonTextBox_8.TabIndex = 3;
			this._txtCommonTextBox_8.Text = "";
			// this.this._txtCommonTextBox_8.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_8.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _txtCommonTextBox_9
			// 
			this._txtCommonTextBox_9.AllowDrop = true;
			this._txtCommonTextBox_9.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_9.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_9.Location = new System.Drawing.Point(390, 108);
			this._txtCommonTextBox_9.MaxLength = 50;
			this._txtCommonTextBox_9.Name = "_txtCommonTextBox_9";
			this._txtCommonTextBox_9.Size = new System.Drawing.Size(94, 19);
			this._txtCommonTextBox_9.TabIndex = 4;
			this._txtCommonTextBox_9.Text = "";
			// this.this._txtCommonTextBox_9.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_9.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _txtCommonTextBox_10
			// 
			this._txtCommonTextBox_10.AllowDrop = true;
			this._txtCommonTextBox_10.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_10.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_10.Location = new System.Drawing.Point(102, 129);
			this._txtCommonTextBox_10.MaxLength = 50;
			this._txtCommonTextBox_10.Name = "_txtCommonTextBox_10";
			this._txtCommonTextBox_10.Size = new System.Drawing.Size(94, 19);
			this._txtCommonTextBox_10.TabIndex = 5;
			this._txtCommonTextBox_10.Text = "";
			// this.this._txtCommonTextBox_10.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_10.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _txtCommonTextBox_11
			// 
			this._txtCommonTextBox_11.AllowDrop = true;
			this._txtCommonTextBox_11.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_11.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_11.Location = new System.Drawing.Point(198, 129);
			this._txtCommonTextBox_11.MaxLength = 50;
			this._txtCommonTextBox_11.Name = "_txtCommonTextBox_11";
			this._txtCommonTextBox_11.Size = new System.Drawing.Size(94, 19);
			this._txtCommonTextBox_11.TabIndex = 6;
			this._txtCommonTextBox_11.Text = "";
			// this.this._txtCommonTextBox_11.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_11.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _txtCommonTextBox_12
			// 
			this._txtCommonTextBox_12.AllowDrop = true;
			this._txtCommonTextBox_12.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_12.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_12.Location = new System.Drawing.Point(294, 129);
			this._txtCommonTextBox_12.MaxLength = 50;
			this._txtCommonTextBox_12.Name = "_txtCommonTextBox_12";
			this._txtCommonTextBox_12.Size = new System.Drawing.Size(94, 19);
			this._txtCommonTextBox_12.TabIndex = 7;
			this._txtCommonTextBox_12.Text = "";
			// this.this._txtCommonTextBox_12.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_12.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _txtCommonTextBox_13
			// 
			this._txtCommonTextBox_13.AllowDrop = true;
			this._txtCommonTextBox_13.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_13.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_13.Location = new System.Drawing.Point(390, 129);
			this._txtCommonTextBox_13.MaxLength = 50;
			this._txtCommonTextBox_13.Name = "_txtCommonTextBox_13";
			this._txtCommonTextBox_13.Size = new System.Drawing.Size(94, 19);
			this._txtCommonTextBox_13.TabIndex = 8;
			this._txtCommonTextBox_13.Text = "";
			// this.this._txtCommonTextBox_13.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_13.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _lblCommonLabel_1
			// 
			this._lblCommonLabel_1.AllowDrop = true;
			this._lblCommonLabel_1.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_1.Text = "Registration No.";
			this._lblCommonLabel_1.Location = new System.Drawing.Point(7, 227);
			// this._lblCommonLabel_1.mLabelId = 1940;
			this._lblCommonLabel_1.Name = "_lblCommonLabel_1";
			this._lblCommonLabel_1.Size = new System.Drawing.Size(76, 14);
			this._lblCommonLabel_1.TabIndex = 43;
			// 
			// _txtCommonTextBox_14
			// 
			this._txtCommonTextBox_14.AllowDrop = true;
			this._txtCommonTextBox_14.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_14.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_14.Location = new System.Drawing.Point(99, 225);
			this._txtCommonTextBox_14.MaxLength = 100;
			this._txtCommonTextBox_14.Name = "_txtCommonTextBox_14";
			this._txtCommonTextBox_14.Size = new System.Drawing.Size(157, 19);
			this._txtCommonTextBox_14.TabIndex = 12;
			this._txtCommonTextBox_14.Text = "";
			// this.this._txtCommonTextBox_14.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_14.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _lblCommonLabel_14
			// 
			this._lblCommonLabel_14.AllowDrop = true;
			this._lblCommonLabel_14.BackColor = System.Drawing.Color.FromArgb(237, 231, 235);
			this._lblCommonLabel_14.Text = "Area";
			this._lblCommonLabel_14.Location = new System.Drawing.Point(7, 248);
			// this._lblCommonLabel_14.mLabelId = 1063;
			this._lblCommonLabel_14.Name = "_lblCommonLabel_14";
			this._lblCommonLabel_14.Size = new System.Drawing.Size(24, 14);
			this._lblCommonLabel_14.TabIndex = 44;
			// 
			// _txtCommonTextBox_15
			// 
			this._txtCommonTextBox_15.AllowDrop = true;
			this._txtCommonTextBox_15.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_15.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_15.Location = new System.Drawing.Point(99, 246);
			this._txtCommonTextBox_15.MaxLength = 100;
			this._txtCommonTextBox_15.Name = "_txtCommonTextBox_15";
			this._txtCommonTextBox_15.Size = new System.Drawing.Size(157, 19);
			this._txtCommonTextBox_15.TabIndex = 13;
			this._txtCommonTextBox_15.Text = "";
			// this.this._txtCommonTextBox_15.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_15.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _lblCommonLabel_15
			// 
			this._lblCommonLabel_15.AllowDrop = true;
			this._lblCommonLabel_15.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_15.Text = "Block No.";
			this._lblCommonLabel_15.Location = new System.Drawing.Point(7, 269);
			// this._lblCommonLabel_15.mLabelId = 1941;
			this._lblCommonLabel_15.Name = "_lblCommonLabel_15";
			this._lblCommonLabel_15.Size = new System.Drawing.Size(45, 14);
			this._lblCommonLabel_15.TabIndex = 45;
			// 
			// _txtCommonTextBox_16
			// 
			this._txtCommonTextBox_16.AllowDrop = true;
			this._txtCommonTextBox_16.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_16.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_16.Location = new System.Drawing.Point(99, 267);
			this._txtCommonTextBox_16.MaxLength = 100;
			this._txtCommonTextBox_16.Name = "_txtCommonTextBox_16";
			this._txtCommonTextBox_16.Size = new System.Drawing.Size(157, 19);
			this._txtCommonTextBox_16.TabIndex = 14;
			this._txtCommonTextBox_16.Text = "";
			// this.this._txtCommonTextBox_16.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_16.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _txtCommonTextBox_17
			// 
			this._txtCommonTextBox_17.AllowDrop = true;
			this._txtCommonTextBox_17.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_17.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_17.Location = new System.Drawing.Point(99, 288);
			this._txtCommonTextBox_17.MaxLength = 100;
			this._txtCommonTextBox_17.Name = "_txtCommonTextBox_17";
			this._txtCommonTextBox_17.Size = new System.Drawing.Size(157, 19);
			this._txtCommonTextBox_17.TabIndex = 15;
			this._txtCommonTextBox_17.Text = "";
			// this.this._txtCommonTextBox_17.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_17.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _lblCommonLabel_16
			// 
			this._lblCommonLabel_16.AllowDrop = true;
			this._lblCommonLabel_16.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_16.Text = "Street Name";
			this._lblCommonLabel_16.Location = new System.Drawing.Point(7, 290);
			// this._lblCommonLabel_16.mLabelId = 1943;
			this._lblCommonLabel_16.Name = "_lblCommonLabel_16";
			this._lblCommonLabel_16.Size = new System.Drawing.Size(59, 14);
			this._lblCommonLabel_16.TabIndex = 46;
			// 
			// _lblCommonLabel_19
			// 
			this._lblCommonLabel_19.AllowDrop = true;
			this._lblCommonLabel_19.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_19.Text = "Avenue";
			this._lblCommonLabel_19.Location = new System.Drawing.Point(7, 311);
			// this._lblCommonLabel_19.mLabelId = 1944;
			this._lblCommonLabel_19.Name = "_lblCommonLabel_19";
			this._lblCommonLabel_19.Size = new System.Drawing.Size(38, 14);
			this._lblCommonLabel_19.TabIndex = 47;
			// 
			// _txtCommonTextBox_18
			// 
			this._txtCommonTextBox_18.AllowDrop = true;
			this._txtCommonTextBox_18.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_18.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_18.Location = new System.Drawing.Point(99, 309);
			this._txtCommonTextBox_18.MaxLength = 100;
			this._txtCommonTextBox_18.Name = "_txtCommonTextBox_18";
			this._txtCommonTextBox_18.Size = new System.Drawing.Size(157, 19);
			this._txtCommonTextBox_18.TabIndex = 16;
			this._txtCommonTextBox_18.Text = "";
			// this.this._txtCommonTextBox_18.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_18.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _lblCommonLabel_20
			// 
			this._lblCommonLabel_20.AllowDrop = true;
			this._lblCommonLabel_20.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_20.Text = "House Type";
			this._lblCommonLabel_20.Location = new System.Drawing.Point(6, 332);
			// this._lblCommonLabel_20.mLabelId = 1945;
			this._lblCommonLabel_20.Name = "_lblCommonLabel_20";
			this._lblCommonLabel_20.Size = new System.Drawing.Size(58, 14);
			this._lblCommonLabel_20.TabIndex = 48;
			// 
			// _txtCommonTextBox_19
			// 
			this._txtCommonTextBox_19.AllowDrop = true;
			this._txtCommonTextBox_19.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_19.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_19.Location = new System.Drawing.Point(99, 330);
			this._txtCommonTextBox_19.MaxLength = 100;
			this._txtCommonTextBox_19.Name = "_txtCommonTextBox_19";
			this._txtCommonTextBox_19.Size = new System.Drawing.Size(157, 19);
			this._txtCommonTextBox_19.TabIndex = 17;
			this._txtCommonTextBox_19.Text = "";
			// this.this._txtCommonTextBox_19.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_19.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _lblCommonLabel_21
			// 
			this._lblCommonLabel_21.AllowDrop = true;
			this._lblCommonLabel_21.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_21.Text = "House Name";
			this._lblCommonLabel_21.Location = new System.Drawing.Point(435, 164);
			// this._lblCommonLabel_21.mLabelId = 1946;
			this._lblCommonLabel_21.Name = "_lblCommonLabel_21";
			this._lblCommonLabel_21.Size = new System.Drawing.Size(61, 14);
			this._lblCommonLabel_21.TabIndex = 49;
			// 
			// _txtCommonTextBox_20
			// 
			this._txtCommonTextBox_20.AllowDrop = true;
			this._txtCommonTextBox_20.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_20.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_20.Location = new System.Drawing.Point(528, 162);
			this._txtCommonTextBox_20.MaxLength = 100;
			this._txtCommonTextBox_20.Name = "_txtCommonTextBox_20";
			this._txtCommonTextBox_20.Size = new System.Drawing.Size(157, 19);
			this._txtCommonTextBox_20.TabIndex = 19;
			this._txtCommonTextBox_20.Text = "";
			// this.this._txtCommonTextBox_20.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_20.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _txtCommonTextBox_21
			// 
			this._txtCommonTextBox_21.AllowDrop = true;
			this._txtCommonTextBox_21.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_21.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_21.Location = new System.Drawing.Point(528, 183);
			this._txtCommonTextBox_21.MaxLength = 100;
			this._txtCommonTextBox_21.Name = "_txtCommonTextBox_21";
			this._txtCommonTextBox_21.Size = new System.Drawing.Size(157, 19);
			this._txtCommonTextBox_21.TabIndex = 20;
			this._txtCommonTextBox_21.Text = "";
			// this.this._txtCommonTextBox_21.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_21.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _lblCommonLabel_22
			// 
			this._lblCommonLabel_22.AllowDrop = true;
			this._lblCommonLabel_22.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_22.Text = "Plot No.";
			this._lblCommonLabel_22.Location = new System.Drawing.Point(435, 185);
			// this._lblCommonLabel_22.mLabelId = 1947;
			this._lblCommonLabel_22.Name = "_lblCommonLabel_22";
			this._lblCommonLabel_22.Size = new System.Drawing.Size(36, 14);
			this._lblCommonLabel_22.TabIndex = 50;
			// 
			// _txtCommonTextBox_22
			// 
			this._txtCommonTextBox_22.AllowDrop = true;
			this._txtCommonTextBox_22.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_22.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_22.Location = new System.Drawing.Point(528, 204);
			this._txtCommonTextBox_22.MaxLength = 100;
			this._txtCommonTextBox_22.Name = "_txtCommonTextBox_22";
			this._txtCommonTextBox_22.Size = new System.Drawing.Size(157, 19);
			this._txtCommonTextBox_22.TabIndex = 21;
			this._txtCommonTextBox_22.Text = "";
			// this.this._txtCommonTextBox_22.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_22.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _lblCommonLabel_23
			// 
			this._lblCommonLabel_23.AllowDrop = true;
			this._lblCommonLabel_23.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_23.Text = "Floor No.";
			this._lblCommonLabel_23.Location = new System.Drawing.Point(435, 206);
			// this._lblCommonLabel_23.mLabelId = 1948;
			this._lblCommonLabel_23.Name = "_lblCommonLabel_23";
			this._lblCommonLabel_23.Size = new System.Drawing.Size(43, 14);
			this._lblCommonLabel_23.TabIndex = 51;
			// 
			// _txtCommonTextBox_23
			// 
			this._txtCommonTextBox_23.AllowDrop = true;
			this._txtCommonTextBox_23.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_23.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_23.Location = new System.Drawing.Point(528, 224);
			this._txtCommonTextBox_23.MaxLength = 100;
			this._txtCommonTextBox_23.Name = "_txtCommonTextBox_23";
			this._txtCommonTextBox_23.Size = new System.Drawing.Size(157, 19);
			this._txtCommonTextBox_23.TabIndex = 22;
			this._txtCommonTextBox_23.Text = "";
			// this.this._txtCommonTextBox_23.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_23.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _lblCommonLabel_24
			// 
			this._lblCommonLabel_24.AllowDrop = true;
			this._lblCommonLabel_24.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_24.Text = "Flat No.";
			this._lblCommonLabel_24.Location = new System.Drawing.Point(435, 226);
			// this._lblCommonLabel_24.mLabelId = 1949;
			this._lblCommonLabel_24.Name = "_lblCommonLabel_24";
			this._lblCommonLabel_24.Size = new System.Drawing.Size(36, 14);
			this._lblCommonLabel_24.TabIndex = 52;
			// 
			// _lblCommonLabel_25
			// 
			this._lblCommonLabel_25.AllowDrop = true;
			this._lblCommonLabel_25.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_25.Text = "Entrance";
			this._lblCommonLabel_25.Location = new System.Drawing.Point(435, 247);
			// this._lblCommonLabel_25.mLabelId = 1950;
			this._lblCommonLabel_25.Name = "_lblCommonLabel_25";
			this._lblCommonLabel_25.Size = new System.Drawing.Size(43, 14);
			this._lblCommonLabel_25.TabIndex = 53;
			// 
			// _txtCommonTextBox_24
			// 
			this._txtCommonTextBox_24.AllowDrop = true;
			this._txtCommonTextBox_24.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_24.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_24.Location = new System.Drawing.Point(528, 245);
			this._txtCommonTextBox_24.MaxLength = 100;
			this._txtCommonTextBox_24.Name = "_txtCommonTextBox_24";
			this._txtCommonTextBox_24.Size = new System.Drawing.Size(157, 19);
			this._txtCommonTextBox_24.TabIndex = 23;
			this._txtCommonTextBox_24.Text = "";
			// this.this._txtCommonTextBox_24.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_24.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _txtCommonTextBox_25
			// 
			this._txtCommonTextBox_25.AllowDrop = true;
			this._txtCommonTextBox_25.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_25.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_25.Location = new System.Drawing.Point(528, 266);
			this._txtCommonTextBox_25.MaxLength = 100;
			this._txtCommonTextBox_25.Name = "_txtCommonTextBox_25";
			this._txtCommonTextBox_25.Size = new System.Drawing.Size(157, 19);
			this._txtCommonTextBox_25.TabIndex = 24;
			this._txtCommonTextBox_25.Text = "";
			// this.this._txtCommonTextBox_25.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_25.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _lblCommonLabel_26
			// 
			this._lblCommonLabel_26.AllowDrop = true;
			this._lblCommonLabel_26.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_26.Text = "P.O. Box No.";
			this._lblCommonLabel_26.Location = new System.Drawing.Point(435, 268);
			// this._lblCommonLabel_26.mLabelId = 1951;
			this._lblCommonLabel_26.Name = "_lblCommonLabel_26";
			this._lblCommonLabel_26.Size = new System.Drawing.Size(61, 14);
			this._lblCommonLabel_26.TabIndex = 54;
			// 
			// _txtCommonTextBox_26
			// 
			this._txtCommonTextBox_26.AllowDrop = true;
			this._txtCommonTextBox_26.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_26.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_26.Location = new System.Drawing.Point(528, 287);
			this._txtCommonTextBox_26.MaxLength = 100;
			this._txtCommonTextBox_26.Name = "_txtCommonTextBox_26";
			this._txtCommonTextBox_26.Size = new System.Drawing.Size(157, 19);
			this._txtCommonTextBox_26.TabIndex = 25;
			this._txtCommonTextBox_26.Text = "";
			// this.this._txtCommonTextBox_26.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_26.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _lblCommonLabel_27
			// 
			this._lblCommonLabel_27.AllowDrop = true;
			this._lblCommonLabel_27.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_27.Text = "Zip Code";
			this._lblCommonLabel_27.Location = new System.Drawing.Point(435, 289);
			// this._lblCommonLabel_27.mLabelId = 1952;
			this._lblCommonLabel_27.Name = "_lblCommonLabel_27";
			this._lblCommonLabel_27.Size = new System.Drawing.Size(43, 14);
			this._lblCommonLabel_27.TabIndex = 55;
			// 
			// _txtCommonTextBox_27
			// 
			this._txtCommonTextBox_27.AllowDrop = true;
			this._txtCommonTextBox_27.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_27.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_27.Location = new System.Drawing.Point(528, 308);
			this._txtCommonTextBox_27.MaxLength = 100;
			this._txtCommonTextBox_27.Name = "_txtCommonTextBox_27";
			this._txtCommonTextBox_27.Size = new System.Drawing.Size(157, 19);
			this._txtCommonTextBox_27.TabIndex = 26;
			this._txtCommonTextBox_27.Text = "";
			// this.this._txtCommonTextBox_27.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_27.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _lblCommonLabel_28
			// 
			this._lblCommonLabel_28.AllowDrop = true;
			this._lblCommonLabel_28.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_28.Text = "Telephone No.";
			this._lblCommonLabel_28.Location = new System.Drawing.Point(435, 310);
			// this._lblCommonLabel_28.mLabelId = 1953;
			this._lblCommonLabel_28.Name = "_lblCommonLabel_28";
			this._lblCommonLabel_28.Size = new System.Drawing.Size(69, 14);
			this._lblCommonLabel_28.TabIndex = 56;
			// 
			// _txtCommonTextBox_28
			// 
			this._txtCommonTextBox_28.AllowDrop = true;
			this._txtCommonTextBox_28.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_28.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_28.Location = new System.Drawing.Point(528, 329);
			this._txtCommonTextBox_28.MaxLength = 100;
			this._txtCommonTextBox_28.Name = "_txtCommonTextBox_28";
			this._txtCommonTextBox_28.Size = new System.Drawing.Size(157, 19);
			this._txtCommonTextBox_28.TabIndex = 27;
			this._txtCommonTextBox_28.Text = "";
			// this.this._txtCommonTextBox_28.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_28.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _lblCommonLabel_29
			// 
			this._lblCommonLabel_29.AllowDrop = true;
			this._lblCommonLabel_29.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_29.Text = "Mobile No.";
			this._lblCommonLabel_29.Location = new System.Drawing.Point(435, 331);
			// this._lblCommonLabel_29.mLabelId = 1954;
			this._lblCommonLabel_29.Name = "_lblCommonLabel_29";
			this._lblCommonLabel_29.Size = new System.Drawing.Size(49, 14);
			this._lblCommonLabel_29.TabIndex = 57;
			// 
			// _txtCommonTextBox_5
			// 
			this._txtCommonTextBox_5.AllowDrop = true;
			this._txtCommonTextBox_5.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_5.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_5.Location = new System.Drawing.Point(98, 351);
			this._txtCommonTextBox_5.MaxLength = 100;
			this._txtCommonTextBox_5.Name = "_txtCommonTextBox_5";
			this._txtCommonTextBox_5.Size = new System.Drawing.Size(157, 19);
			this._txtCommonTextBox_5.TabIndex = 18;
			this._txtCommonTextBox_5.Text = "";
			// this.this._txtCommonTextBox_5.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_5.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _lblCommonLabel_4
			// 
			this._lblCommonLabel_4.AllowDrop = true;
			this._lblCommonLabel_4.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_4.Text = "Civil Id. No.";
			this._lblCommonLabel_4.Location = new System.Drawing.Point(6, 353);
			// this._lblCommonLabel_4.mLabelId = 1959;
			this._lblCommonLabel_4.Name = "_lblCommonLabel_4";
			this._lblCommonLabel_4.Size = new System.Drawing.Size(52, 14);
			this._lblCommonLabel_4.TabIndex = 58;
			// 
			// frmPaySponsors
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.ClientSize = new System.Drawing.Size(693, 416);
			this.Controls.Add(this._txtCommonTextBox_4);
			this.Controls.Add(this.System.Windows.Forms.Label12);
			this.Controls.Add(this._txtCommonTextBox_1);
			this.Controls.Add(this._lblCommonLabel_2);
			this.Controls.Add(this._lblCommonLabel_7);
			this.Controls.Add(this._lblCommonLabel_18);
			this.Controls.Add(this._txtCommonTextBox_2);
			this.Controls.Add(this._txtCommonTextBox_3);
			this.Controls.Add(this._txtCommonTextBox_0);
			this.Controls.Add(this._lblCommonLabel_0);
			this.Controls.Add(this._txtDisplayLabel_2);
			this.Controls.Add(this._txtDisplayLabel_1);
			this.Controls.Add(this._txtDisplayLabel_0);
			this.Controls.Add(this._txtCommonTextBox_6);
			this.Controls.Add(this._lblCommonLabel_3);
			this.Controls.Add(this._lblCommonLabel_8);
			this.Controls.Add(this._lblCommonLabel_9);
			this.Controls.Add(this._lblCommonLabel_10);
			this.Controls.Add(this._lblCommonLabel_12);
			this.Controls.Add(this._lblCommonLabel_13);
			this.Controls.Add(this._txtCommonTextBox_7);
			this.Controls.Add(this._txtCommonTextBox_8);
			this.Controls.Add(this._txtCommonTextBox_9);
			this.Controls.Add(this._txtCommonTextBox_10);
			this.Controls.Add(this._txtCommonTextBox_11);
			this.Controls.Add(this._txtCommonTextBox_12);
			this.Controls.Add(this._txtCommonTextBox_13);
			this.Controls.Add(this._lblCommonLabel_1);
			this.Controls.Add(this._txtCommonTextBox_14);
			this.Controls.Add(this._lblCommonLabel_14);
			this.Controls.Add(this._txtCommonTextBox_15);
			this.Controls.Add(this._lblCommonLabel_15);
			this.Controls.Add(this._txtCommonTextBox_16);
			this.Controls.Add(this._txtCommonTextBox_17);
			this.Controls.Add(this._lblCommonLabel_16);
			this.Controls.Add(this._lblCommonLabel_19);
			this.Controls.Add(this._txtCommonTextBox_18);
			this.Controls.Add(this._lblCommonLabel_20);
			this.Controls.Add(this._txtCommonTextBox_19);
			this.Controls.Add(this._lblCommonLabel_21);
			this.Controls.Add(this._txtCommonTextBox_20);
			this.Controls.Add(this._txtCommonTextBox_21);
			this.Controls.Add(this._lblCommonLabel_22);
			this.Controls.Add(this._txtCommonTextBox_22);
			this.Controls.Add(this._lblCommonLabel_23);
			this.Controls.Add(this._txtCommonTextBox_23);
			this.Controls.Add(this._lblCommonLabel_24);
			this.Controls.Add(this._lblCommonLabel_25);
			this.Controls.Add(this._txtCommonTextBox_24);
			this.Controls.Add(this._txtCommonTextBox_25);
			this.Controls.Add(this._lblCommonLabel_26);
			this.Controls.Add(this._txtCommonTextBox_26);
			this.Controls.Add(this._lblCommonLabel_27);
			this.Controls.Add(this._txtCommonTextBox_27);
			this.Controls.Add(this._lblCommonLabel_28);
			this.Controls.Add(this._txtCommonTextBox_28);
			this.Controls.Add(this._lblCommonLabel_29);
			this.Controls.Add(this._txtCommonTextBox_5);
			this.Controls.Add(this._lblCommonLabel_4);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			//this.Icon = (System.Drawing.Icon) resources.GetObject("frmPaySponsors.Icon");
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(35, 109);
			this.MaximizeBox = true;
			this.MinimizeBox = true;
			this.Name = "frmPaySponsors";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Sponsor";
			// this.Activated += new System.EventHandler(this.frmPaySponsors_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
			// this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
			this.ResumeLayout(false);
		}
		void ReLoadForm(bool addEvents)
		{
			InitializetxtDisplayLabel();
			InitializetxtCommonTextBox();
			InitializelblCommonLabel();
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
			this.txtDisplayLabel = new System.Windows.Forms.Label[3];
			this.txtDisplayLabel[2] = _txtDisplayLabel_2;
			this.txtDisplayLabel[1] = _txtDisplayLabel_1;
			this.txtDisplayLabel[0] = _txtDisplayLabel_0;
		}
		void InitializetxtCommonTextBox()
		{
			this.txtCommonTextBox = new System.Windows.Forms.TextBox[29];
			this.txtCommonTextBox[4] = _txtCommonTextBox_4;
			this.txtCommonTextBox[1] = _txtCommonTextBox_1;
			this.txtCommonTextBox[2] = _txtCommonTextBox_2;
			this.txtCommonTextBox[3] = _txtCommonTextBox_3;
			this.txtCommonTextBox[0] = _txtCommonTextBox_0;
			this.txtCommonTextBox[6] = _txtCommonTextBox_6;
			this.txtCommonTextBox[7] = _txtCommonTextBox_7;
			this.txtCommonTextBox[8] = _txtCommonTextBox_8;
			this.txtCommonTextBox[9] = _txtCommonTextBox_9;
			this.txtCommonTextBox[10] = _txtCommonTextBox_10;
			this.txtCommonTextBox[11] = _txtCommonTextBox_11;
			this.txtCommonTextBox[12] = _txtCommonTextBox_12;
			this.txtCommonTextBox[13] = _txtCommonTextBox_13;
			this.txtCommonTextBox[14] = _txtCommonTextBox_14;
			this.txtCommonTextBox[15] = _txtCommonTextBox_15;
			this.txtCommonTextBox[16] = _txtCommonTextBox_16;
			this.txtCommonTextBox[17] = _txtCommonTextBox_17;
			this.txtCommonTextBox[18] = _txtCommonTextBox_18;
			this.txtCommonTextBox[19] = _txtCommonTextBox_19;
			this.txtCommonTextBox[20] = _txtCommonTextBox_20;
			this.txtCommonTextBox[21] = _txtCommonTextBox_21;
			this.txtCommonTextBox[22] = _txtCommonTextBox_22;
			this.txtCommonTextBox[23] = _txtCommonTextBox_23;
			this.txtCommonTextBox[24] = _txtCommonTextBox_24;
			this.txtCommonTextBox[25] = _txtCommonTextBox_25;
			this.txtCommonTextBox[26] = _txtCommonTextBox_26;
			this.txtCommonTextBox[27] = _txtCommonTextBox_27;
			this.txtCommonTextBox[28] = _txtCommonTextBox_28;
			this.txtCommonTextBox[5] = _txtCommonTextBox_5;
		}
		void InitializelblCommonLabel()
		{
			this.lblCommonLabel = new System.Windows.Forms.Label[30];
			this.lblCommonLabel[2] = _lblCommonLabel_2;
			this.lblCommonLabel[7] = _lblCommonLabel_7;
			this.lblCommonLabel[18] = _lblCommonLabel_18;
			this.lblCommonLabel[0] = _lblCommonLabel_0;
			this.lblCommonLabel[3] = _lblCommonLabel_3;
			this.lblCommonLabel[8] = _lblCommonLabel_8;
			this.lblCommonLabel[9] = _lblCommonLabel_9;
			this.lblCommonLabel[10] = _lblCommonLabel_10;
			this.lblCommonLabel[12] = _lblCommonLabel_12;
			this.lblCommonLabel[13] = _lblCommonLabel_13;
			this.lblCommonLabel[1] = _lblCommonLabel_1;
			this.lblCommonLabel[14] = _lblCommonLabel_14;
			this.lblCommonLabel[15] = _lblCommonLabel_15;
			this.lblCommonLabel[16] = _lblCommonLabel_16;
			this.lblCommonLabel[19] = _lblCommonLabel_19;
			this.lblCommonLabel[20] = _lblCommonLabel_20;
			this.lblCommonLabel[21] = _lblCommonLabel_21;
			this.lblCommonLabel[22] = _lblCommonLabel_22;
			this.lblCommonLabel[23] = _lblCommonLabel_23;
			this.lblCommonLabel[24] = _lblCommonLabel_24;
			this.lblCommonLabel[25] = _lblCommonLabel_25;
			this.lblCommonLabel[26] = _lblCommonLabel_26;
			this.lblCommonLabel[27] = _lblCommonLabel_27;
			this.lblCommonLabel[28] = _lblCommonLabel_28;
			this.lblCommonLabel[29] = _lblCommonLabel_29;
			this.lblCommonLabel[4] = _lblCommonLabel_4;
		}
		#endregion
	}
}