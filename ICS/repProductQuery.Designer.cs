
namespace Xtreme
{
	partial class repItemQuery
	{

		#region "Upgrade Support "
		private static repItemQuery m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static repItemQuery DefInstance
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
		public static repItemQuery CreateInstance()
		{
			repItemQuery theInstance = new repItemQuery();
			
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
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "_lblCommon_13", "_lblCommon_12", "_lblCommon_14", "_lblCommon_15", "_lblCommon_17", "_lblCommon_18", "_lblCommon_19", "_lblCommon_20", "_lblCommon_21", "_lblCommon_16", "_txtCommanTextbox_13", "_txtCommanTextbox_14", "_txtCommanTextbox_16", "_txtCommanTextbox_17", "_txtCommanTextbox_18", "_txtCommanTextbox_15", "_txtCommanTextbox_22", "_txtCommanTextbox_23", "_txtCommanTextbox_24", "_txtCommanTextbox_19", "_txtCommanTextbox_20", "_txtCommanTextbox_21", "_Line1_0", "_Line1_1", "_txtLastCommanLabel_4", "_txtLastCommanLabel_1", "_txtLastCommanLabel_5", "_txtLastCommanLabel_2", "_txtLastCommanLabel_3", "_txtLastCommanLabel_6", "Frame2", "tabTransactions", "Column_0_grdLocationDetails", "Column_1_grdLocationDetails", "grdLocationDetails", "_lblCommon_22", "tabDetails", "ChartControl", "tabSummary", "tabLocation", "imgPicture", "Image1", "fraProductInformation", "txtDescription", "_lblCommon_26", "_lblCommon_25", "chkDiscontinue", "_lblCommon_4", "_lblCommon_2", "_lblCommon_9", "_lblCommon_6", "_lblCommon_5", "_lblCommon_0", "_lblCommon_7", "_lblCommon_8", "_lblCommon_1", "_lblCommon_3", "txtPartNo", "_lblCommon_11", "_lblCommon_10", "_lblCommon_23", "_lblCommon_24", "_txtCommanTextbox_26", "_txtCommanTextbox_25", "_txtCommanTextbox_7", "_txtCommanTextbox_6", "_txtCommanTextbox_11", "_txtCommanTextbox_10", "_txtCommanTextbox_1", "_txtCommanTextbox_2", "_txtCommanTextbox_4", "_txtCommanTextbox_8", "_txtCommanTextbox_3", "_txtCommanTextbox_5", "_txtCommanTextbox_9", "_txtCommanTextbox_12", "_txtCommanTextbox_27", "_lblCommon_28", "_txtCommanTextbox_28", "_lblCommon_27", "fraProductDetails", "Line1", "lblCommon", "txtCommanTextbox", "txtLastCommanLabel"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		private System.Windows.Forms.Label _lblCommon_13;
		private System.Windows.Forms.Label _lblCommon_12;
		private System.Windows.Forms.Label _lblCommon_14;
		private System.Windows.Forms.Label _lblCommon_15;
		private System.Windows.Forms.Label _lblCommon_17;
		private System.Windows.Forms.Label _lblCommon_18;
		private System.Windows.Forms.Label _lblCommon_19;
		private System.Windows.Forms.Label _lblCommon_20;
		private System.Windows.Forms.Label _lblCommon_21;
		private System.Windows.Forms.Label _lblCommon_16;
		private System.Windows.Forms.Label _txtCommanTextbox_13;
		private System.Windows.Forms.Label _txtCommanTextbox_14;
		private System.Windows.Forms.Label _txtCommanTextbox_16;
		private System.Windows.Forms.Label _txtCommanTextbox_17;
		private System.Windows.Forms.Label _txtCommanTextbox_18;
		private System.Windows.Forms.Label _txtCommanTextbox_15;
		private System.Windows.Forms.Label _txtCommanTextbox_22;
		private System.Windows.Forms.Label _txtCommanTextbox_23;
		private System.Windows.Forms.Label _txtCommanTextbox_24;
		private System.Windows.Forms.Label _txtCommanTextbox_19;
		private System.Windows.Forms.Label _txtCommanTextbox_20;
		private System.Windows.Forms.Label _txtCommanTextbox_21;
		private System.Windows.Forms.Label _Line1_0;
		private System.Windows.Forms.Label _Line1_1;
		private System.Windows.Forms.Label _txtLastCommanLabel_4;
		private System.Windows.Forms.Label _txtLastCommanLabel_1;
		private System.Windows.Forms.Label _txtLastCommanLabel_5;
		private System.Windows.Forms.Label _txtLastCommanLabel_2;
		private System.Windows.Forms.Label _txtLastCommanLabel_3;
		private System.Windows.Forms.Label _txtLastCommanLabel_6;
		public System.Windows.Forms.Panel Frame2;
		public AxXtremeSuiteControls.AxTabControlPage tabTransactions;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_0_grdLocationDetails;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_1_grdLocationDetails;
		public C1.Win.C1TrueDBGrid.C1TrueDBGrid grdLocationDetails;
		private System.Windows.Forms.Label _lblCommon_22;
		public AxXtremeSuiteControls.AxTabControlPage tabDetails;
		public AxXtremeChartControl.AxChartControl ChartControl;
		public AxXtremeSuiteControls.AxTabControlPage tabSummary;
		public AxXtremeSuiteControls.AxTabControl tabLocation;
		public System.Windows.Forms.PictureBox imgPicture;
		public System.Windows.Forms.PictureBox Image1;
		public System.Windows.Forms.Panel fraProductInformation;
		public System.Windows.Forms.TextBox txtDescription;
		private System.Windows.Forms.Label _lblCommon_26;
		private System.Windows.Forms.Label _lblCommon_25;
		public System.Windows.Forms.CheckBox chkDiscontinue;
		private System.Windows.Forms.Label _lblCommon_4;
		private System.Windows.Forms.Label _lblCommon_2;
		private System.Windows.Forms.Label _lblCommon_9;
		private System.Windows.Forms.Label _lblCommon_6;
		private System.Windows.Forms.Label _lblCommon_5;
		private System.Windows.Forms.Label _lblCommon_0;
		private System.Windows.Forms.Label _lblCommon_7;
		private System.Windows.Forms.Label _lblCommon_8;
		private System.Windows.Forms.Label _lblCommon_1;
		private System.Windows.Forms.Label _lblCommon_3;
		public System.Windows.Forms.TextBox txtPartNo;
		private System.Windows.Forms.Label _lblCommon_11;
		private System.Windows.Forms.Label _lblCommon_10;
		private System.Windows.Forms.Label _lblCommon_23;
		private System.Windows.Forms.Label _lblCommon_24;
		private System.Windows.Forms.Label _txtCommanTextbox_26;
		private System.Windows.Forms.Label _txtCommanTextbox_25;
		private System.Windows.Forms.Label _txtCommanTextbox_7;
		private System.Windows.Forms.Label _txtCommanTextbox_6;
		private System.Windows.Forms.Label _txtCommanTextbox_11;
		private System.Windows.Forms.Label _txtCommanTextbox_10;
		private System.Windows.Forms.Label _txtCommanTextbox_1;
		private System.Windows.Forms.Label _txtCommanTextbox_2;
		private System.Windows.Forms.Label _txtCommanTextbox_4;
		private System.Windows.Forms.Label _txtCommanTextbox_8;
		private System.Windows.Forms.Label _txtCommanTextbox_3;
		private System.Windows.Forms.Label _txtCommanTextbox_5;
		private System.Windows.Forms.Label _txtCommanTextbox_9;
		private System.Windows.Forms.Label _txtCommanTextbox_12;
		private System.Windows.Forms.Label _txtCommanTextbox_27;
		private System.Windows.Forms.Label _lblCommon_28;
		private System.Windows.Forms.Label _txtCommanTextbox_28;
		private System.Windows.Forms.Label _lblCommon_27;
		public System.Windows.Forms.Panel fraProductDetails;
		public System.Windows.Forms.Label[] Line1 = new System.Windows.Forms.Label[2];
		public System.Windows.Forms.Label[] lblCommon = new System.Windows.Forms.Label[29];
		public System.Windows.Forms.Label[] txtCommanTextbox = new System.Windows.Forms.Label[29];
		public System.Windows.Forms.Label[] txtLastCommanLabel = new System.Windows.Forms.Label[7];
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(repItemQuery));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this.tabLocation = new AxXtremeSuiteControls.AxTabControl();
			this.tabTransactions = new AxXtremeSuiteControls.AxTabControlPage();
			this.Frame2 = new System.Windows.Forms.Panel();
			this._lblCommon_13 = new System.Windows.Forms.Label();
			this._lblCommon_12 = new System.Windows.Forms.Label();
			this._lblCommon_14 = new System.Windows.Forms.Label();
			this._lblCommon_15 = new System.Windows.Forms.Label();
			this._lblCommon_17 = new System.Windows.Forms.Label();
			this._lblCommon_18 = new System.Windows.Forms.Label();
			this._lblCommon_19 = new System.Windows.Forms.Label();
			this._lblCommon_20 = new System.Windows.Forms.Label();
			this._lblCommon_21 = new System.Windows.Forms.Label();
			this._lblCommon_16 = new System.Windows.Forms.Label();
			this._txtCommanTextbox_13 = new System.Windows.Forms.Label();
			this._txtCommanTextbox_14 = new System.Windows.Forms.Label();
			this._txtCommanTextbox_16 = new System.Windows.Forms.Label();
			this._txtCommanTextbox_17 = new System.Windows.Forms.Label();
			this._txtCommanTextbox_18 = new System.Windows.Forms.Label();
			this._txtCommanTextbox_15 = new System.Windows.Forms.Label();
			this._txtCommanTextbox_22 = new System.Windows.Forms.Label();
			this._txtCommanTextbox_23 = new System.Windows.Forms.Label();
			this._txtCommanTextbox_24 = new System.Windows.Forms.Label();
			this._txtCommanTextbox_19 = new System.Windows.Forms.Label();
			this._txtCommanTextbox_20 = new System.Windows.Forms.Label();
			this._txtCommanTextbox_21 = new System.Windows.Forms.Label();
			this._Line1_0 = new System.Windows.Forms.Label();
			this._Line1_1 = new System.Windows.Forms.Label();
			this._txtLastCommanLabel_4 = new System.Windows.Forms.Label();
			this._txtLastCommanLabel_1 = new System.Windows.Forms.Label();
			this._txtLastCommanLabel_5 = new System.Windows.Forms.Label();
			this._txtLastCommanLabel_2 = new System.Windows.Forms.Label();
			this._txtLastCommanLabel_3 = new System.Windows.Forms.Label();
			this._txtLastCommanLabel_6 = new System.Windows.Forms.Label();
			this.tabDetails = new AxXtremeSuiteControls.AxTabControlPage();
			this.grdLocationDetails = new C1.Win.C1TrueDBGrid.C1TrueDBGrid();
			this.Column_0_grdLocationDetails = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.Column_1_grdLocationDetails = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this._lblCommon_22 = new System.Windows.Forms.Label();
			this.tabSummary = new AxXtremeSuiteControls.AxTabControlPage();
			this.ChartControl = new AxXtremeChartControl.AxChartControl();
			this.fraProductDetails = new System.Windows.Forms.Panel();
			this.fraProductInformation = new System.Windows.Forms.Panel();
			this.imgPicture = new System.Windows.Forms.PictureBox();
			this.Image1 = new System.Windows.Forms.PictureBox();
			this.txtDescription = new System.Windows.Forms.TextBox();
			this._lblCommon_26 = new System.Windows.Forms.Label();
			this._lblCommon_25 = new System.Windows.Forms.Label();
			this.chkDiscontinue = new System.Windows.Forms.CheckBox();
			this._lblCommon_4 = new System.Windows.Forms.Label();
			this._lblCommon_2 = new System.Windows.Forms.Label();
			this._lblCommon_9 = new System.Windows.Forms.Label();
			this._lblCommon_6 = new System.Windows.Forms.Label();
			this._lblCommon_5 = new System.Windows.Forms.Label();
			this._lblCommon_0 = new System.Windows.Forms.Label();
			this._lblCommon_7 = new System.Windows.Forms.Label();
			this._lblCommon_8 = new System.Windows.Forms.Label();
			this._lblCommon_1 = new System.Windows.Forms.Label();
			this._lblCommon_3 = new System.Windows.Forms.Label();
			this.txtPartNo = new System.Windows.Forms.TextBox();
			this._lblCommon_11 = new System.Windows.Forms.Label();
			this._lblCommon_10 = new System.Windows.Forms.Label();
			this._lblCommon_23 = new System.Windows.Forms.Label();
			this._lblCommon_24 = new System.Windows.Forms.Label();
			this._txtCommanTextbox_26 = new System.Windows.Forms.Label();
			this._txtCommanTextbox_25 = new System.Windows.Forms.Label();
			this._txtCommanTextbox_7 = new System.Windows.Forms.Label();
			this._txtCommanTextbox_6 = new System.Windows.Forms.Label();
			this._txtCommanTextbox_11 = new System.Windows.Forms.Label();
			this._txtCommanTextbox_10 = new System.Windows.Forms.Label();
			this._txtCommanTextbox_1 = new System.Windows.Forms.Label();
			this._txtCommanTextbox_2 = new System.Windows.Forms.Label();
			this._txtCommanTextbox_4 = new System.Windows.Forms.Label();
			this._txtCommanTextbox_8 = new System.Windows.Forms.Label();
			this._txtCommanTextbox_3 = new System.Windows.Forms.Label();
			this._txtCommanTextbox_5 = new System.Windows.Forms.Label();
			this._txtCommanTextbox_9 = new System.Windows.Forms.Label();
			this._txtCommanTextbox_12 = new System.Windows.Forms.Label();
			this._txtCommanTextbox_27 = new System.Windows.Forms.Label();
			this._lblCommon_28 = new System.Windows.Forms.Label();
			this._txtCommanTextbox_28 = new System.Windows.Forms.Label();
			this._lblCommon_27 = new System.Windows.Forms.Label();
			// //((System.ComponentModel.ISupportInitialize) this.tabTransactions).BeginInit();
			// //((System.ComponentModel.ISupportInitialize) this.tabDetails).BeginInit();
			// //((System.ComponentModel.ISupportInitialize) this.ChartControl).BeginInit();
			// //((System.ComponentModel.ISupportInitialize) this.tabSummary).BeginInit();
			// //((System.ComponentModel.ISupportInitialize) this.tabLocation).BeginInit();
			this.tabLocation.SuspendLayout();
			this.tabTransactions.SuspendLayout();
			this.Frame2.SuspendLayout();
			this.tabDetails.SuspendLayout();
			this.grdLocationDetails.SuspendLayout();
			this.tabSummary.SuspendLayout();
			this.fraProductDetails.SuspendLayout();
			this.fraProductInformation.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabLocation
			// 
			this.tabLocation.AllowDrop = true;
			this.tabLocation.Controls.Add(this.tabTransactions);
			this.tabLocation.Controls.Add(this.tabDetails);
			this.tabLocation.Controls.Add(this.tabSummary);
			this.tabLocation.Location = new System.Drawing.Point(0, 238);
			this.tabLocation.Name = "tabLocation";
			("tabLocation.OcxState");
			this.tabLocation.Size = new System.Drawing.Size(859, 269);
			this.tabLocation.TabIndex = 36;
			// 
			// tabTransactions
			// 
			this.tabTransactions.AllowDrop = true;
			this.tabTransactions.Controls.Add(this.Frame2);
			this.tabTransactions.Location = new System.Drawing.Point(-4664, 28);
			this.tabTransactions.Name = "tabTransactions";
			("tabTransactions.OcxState");
			this.tabTransactions.Size = new System.Drawing.Size(855, 239);
			this.tabTransactions.TabIndex = 42;
			this.tabTransactions.Visible = false;
			// 
			// Frame2
			// 
			this.Frame2.AllowDrop = true;
			this.Frame2.BackColor = System.Drawing.SystemColors.Control;
			this.Frame2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Frame2.Controls.Add(this._lblCommon_13);
			this.Frame2.Controls.Add(this._lblCommon_12);
			this.Frame2.Controls.Add(this._lblCommon_14);
			this.Frame2.Controls.Add(this._lblCommon_15);
			this.Frame2.Controls.Add(this._lblCommon_17);
			this.Frame2.Controls.Add(this._lblCommon_18);
			this.Frame2.Controls.Add(this._lblCommon_19);
			this.Frame2.Controls.Add(this._lblCommon_20);
			this.Frame2.Controls.Add(this._lblCommon_21);
			this.Frame2.Controls.Add(this._lblCommon_16);
			this.Frame2.Controls.Add(this._txtCommanTextbox_13);
			this.Frame2.Controls.Add(this._txtCommanTextbox_14);
			this.Frame2.Controls.Add(this._txtCommanTextbox_16);
			this.Frame2.Controls.Add(this._txtCommanTextbox_17);
			this.Frame2.Controls.Add(this._txtCommanTextbox_18);
			this.Frame2.Controls.Add(this._txtCommanTextbox_15);
			this.Frame2.Controls.Add(this._txtCommanTextbox_22);
			this.Frame2.Controls.Add(this._txtCommanTextbox_23);
			this.Frame2.Controls.Add(this._txtCommanTextbox_24);
			this.Frame2.Controls.Add(this._txtCommanTextbox_19);
			this.Frame2.Controls.Add(this._txtCommanTextbox_20);
			this.Frame2.Controls.Add(this._txtCommanTextbox_21);
			this.Frame2.Controls.Add(this._Line1_0);
			this.Frame2.Controls.Add(this._Line1_1);
			this.Frame2.Controls.Add(this._txtLastCommanLabel_4);
			this.Frame2.Controls.Add(this._txtLastCommanLabel_1);
			this.Frame2.Controls.Add(this._txtLastCommanLabel_5);
			this.Frame2.Controls.Add(this._txtLastCommanLabel_2);
			this.Frame2.Controls.Add(this._txtLastCommanLabel_3);
			this.Frame2.Controls.Add(this._txtLastCommanLabel_6);
			this.Frame2.Enabled = true;
			this.Frame2.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Frame2.Location = new System.Drawing.Point(0, 2);
			this.Frame2.Name = "Frame2";
			this.Frame2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Frame2.Size = new System.Drawing.Size(853, 236);
			this.Frame2.TabIndex = 43;
			this.Frame2.Text = " Transaction Details ";
			this.Frame2.Visible = true;
			// 
			// _lblCommon_13
			// 
			this._lblCommon_13.AllowDrop = true;
			this._lblCommon_13.BackColor = System.Drawing.SystemColors.Control;
			this._lblCommon_13.Text = "Last Sold";
			this._lblCommon_13.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_13.Location = new System.Drawing.Point(8, 51);
			// this._lblCommon_13.mLabelId = 975;
			this._lblCommon_13.Name = "_lblCommon_13";
			this._lblCommon_13.Size = new System.Drawing.Size(43, 13);
			this._lblCommon_13.TabIndex = 44;
			// 
			// _lblCommon_12
			// 
			this._lblCommon_12.AllowDrop = true;
			this._lblCommon_12.BackColor = System.Drawing.SystemColors.Control;
			this._lblCommon_12.Text = "Last Purchased";
			this._lblCommon_12.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_12.Location = new System.Drawing.Point(8, 21);
			// this._lblCommon_12.mLabelId = 974;
			this._lblCommon_12.Name = "_lblCommon_12";
			this._lblCommon_12.Size = new System.Drawing.Size(73, 13);
			this._lblCommon_12.TabIndex = 45;
			// 
			// _lblCommon_14
			// 
			this._lblCommon_14.AllowDrop = true;
			this._lblCommon_14.BackColor = System.Drawing.SystemColors.Control;
			this._lblCommon_14.Text = "Total Purchase";
			this._lblCommon_14.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_14.Location = new System.Drawing.Point(8, 101);
			// this._lblCommon_14.mLabelId = 976;
			this._lblCommon_14.Name = "_lblCommon_14";
			this._lblCommon_14.Size = new System.Drawing.Size(71, 13);
			this._lblCommon_14.TabIndex = 46;
			// 
			// _lblCommon_15
			// 
			this._lblCommon_15.AllowDrop = true;
			this._lblCommon_15.BackColor = System.Drawing.SystemColors.Control;
			this._lblCommon_15.Text = "Total Sales";
			this._lblCommon_15.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_15.Location = new System.Drawing.Point(8, 131);
			// this._lblCommon_15.mLabelId = 977;
			this._lblCommon_15.Name = "_lblCommon_15";
			this._lblCommon_15.Size = new System.Drawing.Size(52, 13);
			this._lblCommon_15.TabIndex = 47;
			// 
			// _lblCommon_17
			// 
			this._lblCommon_17.AllowDrop = true;
			this._lblCommon_17.BackColor = System.Drawing.SystemColors.Control;
			this._lblCommon_17.Text = "  Rate  ";
			this._lblCommon_17.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_17.Location = new System.Drawing.Point(232, 74);
			// this._lblCommon_17.mLabelId = 603;
			this._lblCommon_17.Name = "_lblCommon_17";
			this._lblCommon_17.Size = new System.Drawing.Size(35, 13);
			this._lblCommon_17.TabIndex = 48;
			// 
			// _lblCommon_18
			// 
			this._lblCommon_18.AllowDrop = true;
			this._lblCommon_18.BackColor = System.Drawing.SystemColors.Control;
			this._lblCommon_18.Text = "  Discount  ";
			this._lblCommon_18.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_18.Location = new System.Drawing.Point(331, 74);
			// this._lblCommon_18.mLabelId = 221;
			this._lblCommon_18.Name = "_lblCommon_18";
			this._lblCommon_18.Size = new System.Drawing.Size(53, 13);
			this._lblCommon_18.TabIndex = 49;
			// 
			// _lblCommon_19
			// 
			this._lblCommon_19.AllowDrop = true;
			this._lblCommon_19.BackColor = System.Drawing.SystemColors.Control;
			this._lblCommon_19.Text = "  Amount  ";
			this._lblCommon_19.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_19.Location = new System.Drawing.Point(441, 74);
			// this._lblCommon_19.mLabelId = 54;
			this._lblCommon_19.Name = "_lblCommon_19";
			this._lblCommon_19.Size = new System.Drawing.Size(49, 13);
			this._lblCommon_19.TabIndex = 50;
			// 
			// _lblCommon_20
			// 
			this._lblCommon_20.AllowDrop = true;
			this._lblCommon_20.BackColor = System.Drawing.SystemColors.Control;
			this._lblCommon_20.Text = "  Return Quantity  ";
			this._lblCommon_20.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_20.Location = new System.Drawing.Point(526, 74);
			this._lblCommon_20.Name = "_lblCommon_20";
			this._lblCommon_20.Size = new System.Drawing.Size(90, 13);
			this._lblCommon_20.TabIndex = 51;
			// 
			// _lblCommon_21
			// 
			this._lblCommon_21.AllowDrop = true;
			this._lblCommon_21.BackColor = System.Drawing.SystemColors.Control;
			this._lblCommon_21.Text = "  Net Quantity  ";
			this._lblCommon_21.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_21.Location = new System.Drawing.Point(638, 74);
			this._lblCommon_21.Name = "_lblCommon_21";
			this._lblCommon_21.Size = new System.Drawing.Size(74, 13);
			this._lblCommon_21.TabIndex = 52;
			// 
			// _lblCommon_16
			// 
			this._lblCommon_16.AllowDrop = true;
			this._lblCommon_16.BackColor = System.Drawing.SystemColors.Control;
			this._lblCommon_16.Text = "  Quantity  ";
			this._lblCommon_16.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_16.Location = new System.Drawing.Point(114, 74);
			// this._lblCommon_16.mLabelId = 601;
			this._lblCommon_16.Name = "_lblCommon_16";
			this._lblCommon_16.Size = new System.Drawing.Size(54, 13);
			this._lblCommon_16.TabIndex = 53;
			// 
			// _txtCommanTextbox_13
			// 
			// this._txtCommanTextbox_13.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
			this._txtCommanTextbox_13.AllowDrop = true;
			this._txtCommanTextbox_13.BackColor = System.Drawing.Color.White;
			this._txtCommanTextbox_13.Location = new System.Drawing.Point(86, 98);
			this._txtCommanTextbox_13.Name = "_txtCommanTextbox_13";
			this._txtCommanTextbox_13.Size = new System.Drawing.Size(110, 19);
			this._txtCommanTextbox_13.TabIndex = 54;
			// 
			// _txtCommanTextbox_14
			// 
			// this._txtCommanTextbox_14.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
			this._txtCommanTextbox_14.AllowDrop = true;
			this._txtCommanTextbox_14.BackColor = System.Drawing.Color.White;
			this._txtCommanTextbox_14.Location = new System.Drawing.Point(194, 98);
			this._txtCommanTextbox_14.Name = "_txtCommanTextbox_14";
			this._txtCommanTextbox_14.Size = new System.Drawing.Size(110, 19);
			this._txtCommanTextbox_14.TabIndex = 55;
			// 
			// _txtCommanTextbox_16
			// 
			// this._txtCommanTextbox_16.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
			this._txtCommanTextbox_16.AllowDrop = true;
			this._txtCommanTextbox_16.BackColor = System.Drawing.Color.White;
			this._txtCommanTextbox_16.Location = new System.Drawing.Point(410, 98);
			this._txtCommanTextbox_16.Name = "_txtCommanTextbox_16";
			this._txtCommanTextbox_16.Size = new System.Drawing.Size(110, 19);
			this._txtCommanTextbox_16.TabIndex = 56;
			// 
			// _txtCommanTextbox_17
			// 
			// this._txtCommanTextbox_17.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
			this._txtCommanTextbox_17.AllowDrop = true;
			this._txtCommanTextbox_17.BackColor = System.Drawing.Color.White;
			this._txtCommanTextbox_17.Location = new System.Drawing.Point(516, 98);
			this._txtCommanTextbox_17.Name = "_txtCommanTextbox_17";
			this._txtCommanTextbox_17.Size = new System.Drawing.Size(110, 19);
			this._txtCommanTextbox_17.TabIndex = 57;
			// 
			// _txtCommanTextbox_18
			// 
			// this._txtCommanTextbox_18.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
			this._txtCommanTextbox_18.AllowDrop = true;
			this._txtCommanTextbox_18.BackColor = System.Drawing.Color.White;
			this._txtCommanTextbox_18.Location = new System.Drawing.Point(622, 98);
			this._txtCommanTextbox_18.Name = "_txtCommanTextbox_18";
			this._txtCommanTextbox_18.Size = new System.Drawing.Size(110, 19);
			this._txtCommanTextbox_18.TabIndex = 58;
			this._txtCommanTextbox_18.Text = " ";
			// 
			// _txtCommanTextbox_15
			// 
			// this._txtCommanTextbox_15.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
			this._txtCommanTextbox_15.AllowDrop = true;
			this._txtCommanTextbox_15.BackColor = System.Drawing.Color.White;
			this._txtCommanTextbox_15.Location = new System.Drawing.Point(302, 98);
			this._txtCommanTextbox_15.Name = "_txtCommanTextbox_15";
			this._txtCommanTextbox_15.Size = new System.Drawing.Size(110, 19);
			this._txtCommanTextbox_15.TabIndex = 59;
			// 
			// _txtCommanTextbox_22
			// 
			// this._txtCommanTextbox_22.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
			this._txtCommanTextbox_22.AllowDrop = true;
			this._txtCommanTextbox_22.BackColor = System.Drawing.Color.White;
			this._txtCommanTextbox_22.Location = new System.Drawing.Point(410, 128);
			this._txtCommanTextbox_22.Name = "_txtCommanTextbox_22";
			this._txtCommanTextbox_22.Size = new System.Drawing.Size(110, 19);
			this._txtCommanTextbox_22.TabIndex = 60;
			// 
			// _txtCommanTextbox_23
			// 
			// this._txtCommanTextbox_23.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
			this._txtCommanTextbox_23.AllowDrop = true;
			this._txtCommanTextbox_23.BackColor = System.Drawing.Color.White;
			this._txtCommanTextbox_23.Location = new System.Drawing.Point(516, 128);
			this._txtCommanTextbox_23.Name = "_txtCommanTextbox_23";
			this._txtCommanTextbox_23.Size = new System.Drawing.Size(110, 19);
			this._txtCommanTextbox_23.TabIndex = 61;
			// 
			// _txtCommanTextbox_24
			// 
			// this._txtCommanTextbox_24.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
			this._txtCommanTextbox_24.AllowDrop = true;
			this._txtCommanTextbox_24.BackColor = System.Drawing.Color.White;
			this._txtCommanTextbox_24.Location = new System.Drawing.Point(622, 128);
			this._txtCommanTextbox_24.Name = "_txtCommanTextbox_24";
			this._txtCommanTextbox_24.Size = new System.Drawing.Size(110, 19);
			this._txtCommanTextbox_24.TabIndex = 62;
			// 
			// _txtCommanTextbox_19
			// 
			// this._txtCommanTextbox_19.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
			this._txtCommanTextbox_19.AllowDrop = true;
			this._txtCommanTextbox_19.BackColor = System.Drawing.Color.White;
			this._txtCommanTextbox_19.Location = new System.Drawing.Point(86, 128);
			this._txtCommanTextbox_19.Name = "_txtCommanTextbox_19";
			this._txtCommanTextbox_19.Size = new System.Drawing.Size(110, 19);
			this._txtCommanTextbox_19.TabIndex = 63;
			// 
			// _txtCommanTextbox_20
			// 
			// this._txtCommanTextbox_20.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
			this._txtCommanTextbox_20.AllowDrop = true;
			this._txtCommanTextbox_20.BackColor = System.Drawing.Color.White;
			this._txtCommanTextbox_20.Location = new System.Drawing.Point(194, 128);
			this._txtCommanTextbox_20.Name = "_txtCommanTextbox_20";
			this._txtCommanTextbox_20.Size = new System.Drawing.Size(110, 19);
			this._txtCommanTextbox_20.TabIndex = 64;
			// 
			// _txtCommanTextbox_21
			// 
			// this._txtCommanTextbox_21.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
			this._txtCommanTextbox_21.AllowDrop = true;
			this._txtCommanTextbox_21.BackColor = System.Drawing.Color.White;
			this._txtCommanTextbox_21.Location = new System.Drawing.Point(302, 128);
			this._txtCommanTextbox_21.Name = "_txtCommanTextbox_21";
			this._txtCommanTextbox_21.Size = new System.Drawing.Size(110, 19);
			this._txtCommanTextbox_21.TabIndex = 65;
			// 
			// _Line1_0
			// 
			this._Line1_0.AllowDrop = true;
			this._Line1_0.BackColor = System.Drawing.Color.Gray;
			this._Line1_0.Enabled = false;
			this._Line1_0.Location = new System.Drawing.Point(2, 83);
			this._Line1_0.Name = "_Line1_0";
			this._Line1_0.Size = new System.Drawing.Size(748, 1);
			this._Line1_0.Visible = true;
			// 
			// _Line1_1
			// 
			this._Line1_1.AllowDrop = true;
			this._Line1_1.BackColor = System.Drawing.Color.White;
			this._Line1_1.Enabled = false;
			this._Line1_1.Location = new System.Drawing.Point(2, 84);
			this._Line1_1.Name = "_Line1_1";
			this._Line1_1.Size = new System.Drawing.Size(748, 1);
			this._Line1_1.Visible = true;
			// 
			// _txtLastCommanLabel_4
			// 
			this._txtLastCommanLabel_4.AllowDrop = true;
			this._txtLastCommanLabel_4.BackColor = System.Drawing.Color.White;
			this._txtLastCommanLabel_4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._txtLastCommanLabel_4.ForeColor = System.Drawing.Color.Black;
			this._txtLastCommanLabel_4.Location = new System.Drawing.Point(86, 48);
			this._txtLastCommanLabel_4.Name = "_txtLastCommanLabel_4";
			this._txtLastCommanLabel_4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtLastCommanLabel_4.Size = new System.Drawing.Size(73, 19);
			this._txtLastCommanLabel_4.TabIndex = 71;
			// this._txtLastCommanLabel_4.Click += new System.EventHandler(this.txtLastCommanLabel_Click);
			// 
			// _txtLastCommanLabel_1
			// 
			this._txtLastCommanLabel_1.AllowDrop = true;
			this._txtLastCommanLabel_1.BackColor = System.Drawing.Color.White;
			this._txtLastCommanLabel_1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._txtLastCommanLabel_1.ForeColor = System.Drawing.Color.Black;
			this._txtLastCommanLabel_1.Location = new System.Drawing.Point(86, 18);
			this._txtLastCommanLabel_1.Name = "_txtLastCommanLabel_1";
			this._txtLastCommanLabel_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtLastCommanLabel_1.Size = new System.Drawing.Size(74, 19);
			this._txtLastCommanLabel_1.TabIndex = 70;
			// this._txtLastCommanLabel_1.Click += new System.EventHandler(this.txtLastCommanLabel_Click);
			// 
			// _txtLastCommanLabel_5
			// 
			this._txtLastCommanLabel_5.AllowDrop = true;
			this._txtLastCommanLabel_5.BackColor = System.Drawing.Color.White;
			this._txtLastCommanLabel_5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._txtLastCommanLabel_5.ForeColor = System.Drawing.Color.Black;
			this._txtLastCommanLabel_5.Location = new System.Drawing.Point(158, 48);
			this._txtLastCommanLabel_5.Name = "_txtLastCommanLabel_5";
			this._txtLastCommanLabel_5.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtLastCommanLabel_5.Size = new System.Drawing.Size(267, 19);
			this._txtLastCommanLabel_5.TabIndex = 69;
			// this._txtLastCommanLabel_5.Click += new System.EventHandler(this.txtLastCommanLabel_Click);
			// 
			// _txtLastCommanLabel_2
			// 
			this._txtLastCommanLabel_2.AllowDrop = true;
			this._txtLastCommanLabel_2.BackColor = System.Drawing.Color.White;
			this._txtLastCommanLabel_2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._txtLastCommanLabel_2.ForeColor = System.Drawing.Color.Black;
			this._txtLastCommanLabel_2.Location = new System.Drawing.Point(158, 18);
			this._txtLastCommanLabel_2.Name = "_txtLastCommanLabel_2";
			this._txtLastCommanLabel_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtLastCommanLabel_2.Size = new System.Drawing.Size(267, 19);
			this._txtLastCommanLabel_2.TabIndex = 68;
			// this._txtLastCommanLabel_2.Click += new System.EventHandler(this.txtLastCommanLabel_Click);
			// 
			// _txtLastCommanLabel_3
			// 
			this._txtLastCommanLabel_3.AllowDrop = true;
			this._txtLastCommanLabel_3.BackColor = System.Drawing.Color.White;
			this._txtLastCommanLabel_3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._txtLastCommanLabel_3.ForeColor = System.Drawing.Color.Black;
			this._txtLastCommanLabel_3.Location = new System.Drawing.Point(424, 18);
			this._txtLastCommanLabel_3.Name = "_txtLastCommanLabel_3";
			this._txtLastCommanLabel_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtLastCommanLabel_3.Size = new System.Drawing.Size(320, 19);
			this._txtLastCommanLabel_3.TabIndex = 67;
			// this._txtLastCommanLabel_3.Click += new System.EventHandler(this.txtLastCommanLabel_Click);
			// 
			// _txtLastCommanLabel_6
			// 
			this._txtLastCommanLabel_6.AllowDrop = true;
			this._txtLastCommanLabel_6.BackColor = System.Drawing.Color.White;
			this._txtLastCommanLabel_6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._txtLastCommanLabel_6.ForeColor = System.Drawing.Color.Black;
			this._txtLastCommanLabel_6.Location = new System.Drawing.Point(424, 48);
			this._txtLastCommanLabel_6.Name = "_txtLastCommanLabel_6";
			this._txtLastCommanLabel_6.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtLastCommanLabel_6.Size = new System.Drawing.Size(320, 19);
			this._txtLastCommanLabel_6.TabIndex = 66;
			// this._txtLastCommanLabel_6.Click += new System.EventHandler(this.txtLastCommanLabel_Click);
			// 
			// tabDetails
			// 
			this.tabDetails.AllowDrop = true;
			this.tabDetails.Controls.Add(this.grdLocationDetails);
			this.tabDetails.Controls.Add(this._lblCommon_22);
			this.tabDetails.Location = new System.Drawing.Point(2, 28);
			this.tabDetails.Name = "tabDetails";
			("tabDetails.OcxState");
			this.tabDetails.Size = new System.Drawing.Size(855, 239);
			this.tabDetails.TabIndex = 38;
			// 
			// grdLocationDetails
			// 
			this.grdLocationDetails.AllowDrop = true;
			this.grdLocationDetails.BackColor = System.Drawing.Color.FromArgb(212, 208, 200);
			this.grdLocationDetails.CellTipsWidth = 0;
			this.grdLocationDetails.Location = new System.Drawing.Point(0, 28);
			this.grdLocationDetails.Name = "grdLocationDetails";
			this.grdLocationDetails.RowDivider.Color = System.Drawing.Color.FromArgb(212, 208, 200);
			this.grdLocationDetails.Size = new System.Drawing.Size(855, 211);
			this.grdLocationDetails.TabIndex = 40;
			this.grdLocationDetails.Columns.Add(this.Column_0_grdLocationDetails);
			this.grdLocationDetails.Columns.Add(this.Column_1_grdLocationDetails);
			// this.grdLocationDetails.Click += new System.EventHandler(this.grdLocationDetails_Click);
			this.grdLocationDetails.DoubleClick += new System.EventHandler(this.grdLocationDetails_DoubleClick);
			// this.this.grdLocationDetails.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grdLocationDetails_KeyDown);
			// 
			// Column_0_grdLocationDetails
			// 
			this.Column_0_grdLocationDetails.DataField = "";
			this.Column_0_grdLocationDetails.ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.Normal;
			// 
			// Column_1_grdLocationDetails
			// 
			this.Column_1_grdLocationDetails.DataField = "";
			this.Column_1_grdLocationDetails.ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.Normal;
			// 
			// _lblCommon_22
			// 
			this._lblCommon_22.AllowDrop = true;
			this._lblCommon_22.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_22.Text = " Location Level Product Details : ";
			this._lblCommon_22.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_22.Location = new System.Drawing.Point(2, 6);
			this._lblCommon_22.Name = "_lblCommon_22";
			this._lblCommon_22.Size = new System.Drawing.Size(156, 13);
			this._lblCommon_22.TabIndex = 41;
			// 
			// tabSummary
			// 
			this.tabSummary.AllowDrop = true;
			this.tabSummary.Controls.Add(this.ChartControl);
			this.tabSummary.Location = new System.Drawing.Point(-4664, 28);
			this.tabSummary.Name = "tabSummary";
			("tabSummary.OcxState");
			this.tabSummary.Size = new System.Drawing.Size(855, 239);
			this.tabSummary.TabIndex = 37;
			this.tabSummary.Visible = false;
			// 
			// ChartControl
			// 
			this.ChartControl.AllowDrop = true;
			this.ChartControl.Location = new System.Drawing.Point(0, 0);
			this.ChartControl.Name = "ChartControl";
			("ChartControl.OcxState");
			this.ChartControl.Size = new System.Drawing.Size(855, 243);
			this.ChartControl.TabIndex = 39;
			this.ChartControl.MouseDownEvent += new AxXtremeChartControl._DChartControlEvents_MouseDownEventHandler(this.ChartControl_MouseDownEvent);
			this.ChartControl.MouseMoveEvent += new AxXtremeChartControl._DChartControlEvents_MouseMoveEventHandler(this.ChartControl_MouseMoveEvent);
			// 
			// fraProductDetails
			// 
			this.fraProductDetails.AllowDrop = true;
			this.fraProductDetails.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.fraProductDetails.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.fraProductDetails.Controls.Add(this.fraProductInformation);
			this.fraProductDetails.Controls.Add(this.txtDescription);
			this.fraProductDetails.Controls.Add(this._lblCommon_26);
			this.fraProductDetails.Controls.Add(this._lblCommon_25);
			this.fraProductDetails.Controls.Add(this.chkDiscontinue);
			this.fraProductDetails.Controls.Add(this._lblCommon_4);
			this.fraProductDetails.Controls.Add(this._lblCommon_2);
			this.fraProductDetails.Controls.Add(this._lblCommon_9);
			this.fraProductDetails.Controls.Add(this._lblCommon_6);
			this.fraProductDetails.Controls.Add(this._lblCommon_5);
			this.fraProductDetails.Controls.Add(this._lblCommon_0);
			this.fraProductDetails.Controls.Add(this._lblCommon_7);
			this.fraProductDetails.Controls.Add(this._lblCommon_8);
			this.fraProductDetails.Controls.Add(this._lblCommon_1);
			this.fraProductDetails.Controls.Add(this._lblCommon_3);
			this.fraProductDetails.Controls.Add(this.txtPartNo);
			this.fraProductDetails.Controls.Add(this._lblCommon_11);
			this.fraProductDetails.Controls.Add(this._lblCommon_10);
			this.fraProductDetails.Controls.Add(this._lblCommon_23);
			this.fraProductDetails.Controls.Add(this._lblCommon_24);
			this.fraProductDetails.Controls.Add(this._txtCommanTextbox_26);
			this.fraProductDetails.Controls.Add(this._txtCommanTextbox_25);
			this.fraProductDetails.Controls.Add(this._txtCommanTextbox_7);
			this.fraProductDetails.Controls.Add(this._txtCommanTextbox_6);
			this.fraProductDetails.Controls.Add(this._txtCommanTextbox_11);
			this.fraProductDetails.Controls.Add(this._txtCommanTextbox_10);
			this.fraProductDetails.Controls.Add(this._txtCommanTextbox_1);
			this.fraProductDetails.Controls.Add(this._txtCommanTextbox_2);
			this.fraProductDetails.Controls.Add(this._txtCommanTextbox_4);
			this.fraProductDetails.Controls.Add(this._txtCommanTextbox_8);
			this.fraProductDetails.Controls.Add(this._txtCommanTextbox_3);
			this.fraProductDetails.Controls.Add(this._txtCommanTextbox_5);
			this.fraProductDetails.Controls.Add(this._txtCommanTextbox_9);
			this.fraProductDetails.Controls.Add(this._txtCommanTextbox_12);
			this.fraProductDetails.Controls.Add(this._txtCommanTextbox_27);
			this.fraProductDetails.Controls.Add(this._lblCommon_28);
			this.fraProductDetails.Controls.Add(this._txtCommanTextbox_28);
			this.fraProductDetails.Controls.Add(this._lblCommon_27);
			this.fraProductDetails.Enabled = true;
			this.fraProductDetails.ForeColor = System.Drawing.SystemColors.ControlText;
			this.fraProductDetails.Location = new System.Drawing.Point(2, 12);
			this.fraProductDetails.Name = "fraProductDetails";
			this.fraProductDetails.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.fraProductDetails.Size = new System.Drawing.Size(857, 225);
			this.fraProductDetails.TabIndex = 6;
			this.fraProductDetails.Text = "Item Details ";
			this.fraProductDetails.Visible = true;
			// 
			// fraProductInformation
			// 
			this.fraProductInformation.AllowDrop = true;
			this.fraProductInformation.BackColor = System.Drawing.Color.FromArgb(239, 239, 239);
			this.fraProductInformation.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.fraProductInformation.Controls.Add(this.imgPicture);
			this.fraProductInformation.Controls.Add(this.Image1);
			this.fraProductInformation.Enabled = true;
			this.fraProductInformation.ForeColor = System.Drawing.SystemColors.ControlText;
			this.fraProductInformation.Location = new System.Drawing.Point(586, 18);
			this.fraProductInformation.Name = "fraProductInformation";
			this.fraProductInformation.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.fraProductInformation.Size = new System.Drawing.Size(267, 177);
			this.fraProductInformation.TabIndex = 72;
			this.fraProductInformation.Visible = false;
			// 
			// imgPicture
			// 
			this.imgPicture.AllowDrop = true;
			this.imgPicture.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.imgPicture.Enabled = true;
			this.imgPicture.Location = new System.Drawing.Point(0, 0);
			this.imgPicture.Name = "imgPicture";
			this.imgPicture.Size = new System.Drawing.Size(265, 175);
			this.imgPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.imgPicture.Visible = true;
			// this.imgPicture.Click += new System.EventHandler(this.imgPicture_Click);
			// 
			// Image1
			// 
			this.Image1.AllowDrop = true;
			this.Image1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Image1.Enabled = true;
			//this.Image1.Image = (System.Drawing.Image) resources.GetObject("Image1.Image");
			this.Image1.Location = new System.Drawing.Point(2, 2);
			this.Image1.Name = "Image1";
			this.Image1.Size = new System.Drawing.Size(259, 170);
			this.Image1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal;
			this.Image1.Visible = true;
			// 
			// txtDescription
			// 
			this.txtDescription.AcceptsReturn = true;
			this.txtDescription.AllowDrop = true;
			this.txtDescription.BackColor = System.Drawing.Color.White;
			this.txtDescription.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.txtDescription.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtDescription.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtDescription.Location = new System.Drawing.Point(86, 162);
			this.txtDescription.MaxLength = 0;
			this.txtDescription.Multiline = true;
			this.txtDescription.Name = "txtDescription";
			this.txtDescription.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtDescription.Size = new System.Drawing.Size(497, 59);
			this.txtDescription.TabIndex = 35;
			// 
			// _lblCommon_26
			// 
			this._lblCommon_26.AllowDrop = true;
			this._lblCommon_26.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_26.Text = "Purchase Rate";
			this._lblCommon_26.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_26.Location = new System.Drawing.Point(454, 102);
			// this._lblCommon_26.mLabelId = 581;
			this._lblCommon_26.Name = "_lblCommon_26";
			this._lblCommon_26.Size = new System.Drawing.Size(70, 13);
			this._lblCommon_26.TabIndex = 18;
			// 
			// _lblCommon_25
			// 
			this._lblCommon_25.AllowDrop = true;
			this._lblCommon_25.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_25.Text = "Sales Rate - 1";
			this._lblCommon_25.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_25.Location = new System.Drawing.Point(454, 123);
			// this._lblCommon_25.mLabelId = 925;
			this._lblCommon_25.Name = "_lblCommon_25";
			this._lblCommon_25.Size = new System.Drawing.Size(67, 13);
			this._lblCommon_25.TabIndex = 17;
			// 
			// chkDiscontinue
			// 
			this.chkDiscontinue.AllowDrop = true;
			this.chkDiscontinue.Appearance = System.Windows.Forms.Appearance.Normal;
			this.chkDiscontinue.BackColor = System.Drawing.Color.FromArgb(250, 244, 231);
			this.chkDiscontinue.CausesValidation = true;
			this.chkDiscontinue.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkDiscontinue.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this.chkDiscontinue.Enabled = false;
			this.chkDiscontinue.ForeColor = System.Drawing.SystemColors.ControlText;
			this.chkDiscontinue.Location = new System.Drawing.Point(528, 80);
			this.chkDiscontinue.Name = "chkDiscontinue";
			this.chkDiscontinue.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.chkDiscontinue.Size = new System.Drawing.Size(13, 15);
			this.chkDiscontinue.TabIndex = 7;
			this.chkDiscontinue.TabStop = true;
			this.chkDiscontinue.Text = "Check1";
			this.chkDiscontinue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkDiscontinue.Visible = true;
			// 
			// _lblCommon_4
			// 
			this._lblCommon_4.AllowDrop = true;
			this._lblCommon_4.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_4.Text = "Product Type ";
			this._lblCommon_4.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_4.Location = new System.Drawing.Point(8, 122);
			// this._lblCommon_4.mLabelId = 919;
			this._lblCommon_4.Name = "_lblCommon_4";
			this._lblCommon_4.Size = new System.Drawing.Size(67, 13);
			this._lblCommon_4.TabIndex = 8;
			// 
			// _lblCommon_2
			// 
			this._lblCommon_2.AllowDrop = true;
			this._lblCommon_2.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_2.Text = "Costing Method";
			this._lblCommon_2.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_2.Location = new System.Drawing.Point(8, 62);
			// this._lblCommon_2.mLabelId = 920;
			this._lblCommon_2.Name = "_lblCommon_2";
			this._lblCommon_2.Size = new System.Drawing.Size(75, 13);
			this._lblCommon_2.TabIndex = 9;
			// 
			// _lblCommon_9
			// 
			this._lblCommon_9.AllowDrop = true;
			this._lblCommon_9.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_9.Text = "Closing Value";
			this._lblCommon_9.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_9.Location = new System.Drawing.Point(223, 102);
			// this._lblCommon_9.mLabelId = 973;
			this._lblCommon_9.Name = "_lblCommon_9";
			this._lblCommon_9.Size = new System.Drawing.Size(63, 13);
			this._lblCommon_9.TabIndex = 10;
			// 
			// _lblCommon_6
			// 
			this._lblCommon_6.AllowDrop = true;
			this._lblCommon_6.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_6.Text = "Product Name";
			this._lblCommon_6.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_6.Location = new System.Drawing.Point(223, 20);
			// this._lblCommon_6.mLabelId = 550;
			this._lblCommon_6.Name = "_lblCommon_6";
			this._lblCommon_6.Size = new System.Drawing.Size(67, 13);
			this._lblCommon_6.TabIndex = 11;
			// 
			// _lblCommon_5
			// 
			this._lblCommon_5.AllowDrop = true;
			this._lblCommon_5.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_5.Text = "Description";
			this._lblCommon_5.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_5.Location = new System.Drawing.Point(8, 166);
			// this._lblCommon_5.mLabelId = 216;
			this._lblCommon_5.Name = "_lblCommon_5";
			this._lblCommon_5.Size = new System.Drawing.Size(53, 13);
			this._lblCommon_5.TabIndex = 12;
			// 
			// _lblCommon_0
			// 
			this._lblCommon_0.AllowDrop = true;
			this._lblCommon_0.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_0.Text = "Product Code";
			this._lblCommon_0.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_0.Location = new System.Drawing.Point(8, 21);
			// this._lblCommon_0.mLabelId = 545;
			this._lblCommon_0.Name = "_lblCommon_0";
			this._lblCommon_0.Size = new System.Drawing.Size(65, 14);
			this._lblCommon_0.TabIndex = 13;
			// 
			// _lblCommon_7
			// 
			this._lblCommon_7.AllowDrop = true;
			this._lblCommon_7.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_7.Text = "Product Category";
			this._lblCommon_7.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_7.Location = new System.Drawing.Point(223, 42);
			// this._lblCommon_7.mLabelId = 544;
			this._lblCommon_7.Name = "_lblCommon_7";
			this._lblCommon_7.Size = new System.Drawing.Size(85, 13);
			this._lblCommon_7.TabIndex = 14;
			// 
			// _lblCommon_8
			// 
			this._lblCommon_8.AllowDrop = true;
			this._lblCommon_8.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_8.Text = "Product Group";
			this._lblCommon_8.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_8.Location = new System.Drawing.Point(223, 62);
			// this._lblCommon_8.mLabelId = 547;
			this._lblCommon_8.Name = "_lblCommon_8";
			this._lblCommon_8.Size = new System.Drawing.Size(69, 13);
			this._lblCommon_8.TabIndex = 1;
			// 
			// _lblCommon_1
			// 
			this._lblCommon_1.AllowDrop = true;
			this._lblCommon_1.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_1.Text = "Cost Price";
			this._lblCommon_1.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_1.Location = new System.Drawing.Point(8, 42);
			// this._lblCommon_1.mLabelId = 157;
			this._lblCommon_1.Name = "_lblCommon_1";
			this._lblCommon_1.Size = new System.Drawing.Size(48, 13);
			this._lblCommon_1.TabIndex = 2;
			// 
			// _lblCommon_3
			// 
			this._lblCommon_3.AllowDrop = true;
			this._lblCommon_3.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_3.Text = "Closing Balance";
			this._lblCommon_3.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_3.Location = new System.Drawing.Point(8, 102);
			// this._lblCommon_3.mLabelId = 128;
			this._lblCommon_3.Name = "_lblCommon_3";
			this._lblCommon_3.Size = new System.Drawing.Size(74, 13);
			this._lblCommon_3.TabIndex = 3;
			// 
			// txtPartNo
			// 
			this.txtPartNo.AllowDrop = true;
			this.txtPartNo.BackColor = System.Drawing.Color.White;
			this.txtPartNo.ForeColor = System.Drawing.Color.Black;
			this.txtPartNo.Location = new System.Drawing.Point(86, 18);
			this.txtPartNo.Name = "txtPartNo";
			this.txtPartNo.Size = new System.Drawing.Size(121, 19);
			this.txtPartNo.TabIndex = 0;
			this.txtPartNo.Text = "";
			// this.this.txtPartNo.Watermark = "";
			// this.this.txtPartNo.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtPartNo_DropButtonClick);
			// this.this.txtPartNo.KeyDown += new System.Windows.Forms.TextBox.KeyDownHandler(this.txtPartNo_KeyDown);
			// 
			// _lblCommon_11
			// 
			this._lblCommon_11.AllowDrop = true;
			this._lblCommon_11.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_11.Text = "Discontinue";
			this._lblCommon_11.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_11.Location = new System.Drawing.Point(454, 81);
			// this._lblCommon_11.mLabelId = 220;
			this._lblCommon_11.Name = "_lblCommon_11";
			this._lblCommon_11.Size = new System.Drawing.Size(55, 13);
			this._lblCommon_11.TabIndex = 4;
			// 
			// _lblCommon_10
			// 
			this._lblCommon_10.AllowDrop = true;
			this._lblCommon_10.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_10.Text = "Supplier Part No";
			this._lblCommon_10.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_10.Location = new System.Drawing.Point(223, 122);
			// this._lblCommon_10.mLabelId = 765;
			this._lblCommon_10.Name = "_lblCommon_10";
			this._lblCommon_10.Size = new System.Drawing.Size(77, 13);
			this._lblCommon_10.TabIndex = 5;
			// 
			// _lblCommon_23
			// 
			this._lblCommon_23.AllowDrop = true;
			this._lblCommon_23.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_23.Text = "Opening Value";
			this._lblCommon_23.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_23.Location = new System.Drawing.Point(223, 82);
			// this._lblCommon_23.mLabelId = 972;
			this._lblCommon_23.Name = "_lblCommon_23";
			this._lblCommon_23.Size = new System.Drawing.Size(69, 13);
			this._lblCommon_23.TabIndex = 15;
			// 
			// _lblCommon_24
			// 
			this._lblCommon_24.AllowDrop = true;
			this._lblCommon_24.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_24.Text = "Opening Bal.";
			this._lblCommon_24.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_24.Location = new System.Drawing.Point(8, 82);
			// this._lblCommon_24.mLabelId = 477;
			this._lblCommon_24.Name = "_lblCommon_24";
			this._lblCommon_24.Size = new System.Drawing.Size(61, 13);
			this._lblCommon_24.TabIndex = 16;
			// 
			// _txtCommanTextbox_26
			// 
			this._txtCommanTextbox_26.AllowDrop = true;
			this._txtCommanTextbox_26.BackColor = System.Drawing.Color.White;
			this._txtCommanTextbox_26.Location = new System.Drawing.Point(528, 99);
			this._txtCommanTextbox_26.Name = "_txtCommanTextbox_26";
			this._txtCommanTextbox_26.Size = new System.Drawing.Size(55, 19);
			this._txtCommanTextbox_26.TabIndex = 19;
			// 
			// _txtCommanTextbox_25
			// 
			this._txtCommanTextbox_25.AllowDrop = true;
			this._txtCommanTextbox_25.BackColor = System.Drawing.Color.White;
			this._txtCommanTextbox_25.Location = new System.Drawing.Point(528, 120);
			this._txtCommanTextbox_25.Name = "_txtCommanTextbox_25";
			this._txtCommanTextbox_25.Size = new System.Drawing.Size(55, 19);
			this._txtCommanTextbox_25.TabIndex = 20;
			// 
			// _txtCommanTextbox_7
			// 
			this._txtCommanTextbox_7.AllowDrop = true;
			this._txtCommanTextbox_7.BackColor = System.Drawing.Color.White;
			this._txtCommanTextbox_7.Location = new System.Drawing.Point(320, 79);
			this._txtCommanTextbox_7.Name = "_txtCommanTextbox_7";
			this._txtCommanTextbox_7.Size = new System.Drawing.Size(121, 19);
			this._txtCommanTextbox_7.TabIndex = 21;
			// 
			// _txtCommanTextbox_6
			// 
			this._txtCommanTextbox_6.AllowDrop = true;
			this._txtCommanTextbox_6.BackColor = System.Drawing.Color.White;
			this._txtCommanTextbox_6.Location = new System.Drawing.Point(86, 79);
			this._txtCommanTextbox_6.Name = "_txtCommanTextbox_6";
			this._txtCommanTextbox_6.Size = new System.Drawing.Size(121, 19);
			this._txtCommanTextbox_6.TabIndex = 22;
			// 
			// _txtCommanTextbox_11
			// 
			this._txtCommanTextbox_11.AllowDrop = true;
			this._txtCommanTextbox_11.BackColor = System.Drawing.Color.White;
			this._txtCommanTextbox_11.Location = new System.Drawing.Point(320, 119);
			this._txtCommanTextbox_11.Name = "_txtCommanTextbox_11";
			this._txtCommanTextbox_11.Size = new System.Drawing.Size(121, 19);
			this._txtCommanTextbox_11.TabIndex = 23;
			// 
			// _txtCommanTextbox_10
			// 
			this._txtCommanTextbox_10.AllowDrop = true;
			this._txtCommanTextbox_10.BackColor = System.Drawing.Color.White;
			this._txtCommanTextbox_10.Location = new System.Drawing.Point(86, 119);
			this._txtCommanTextbox_10.Name = "_txtCommanTextbox_10";
			this._txtCommanTextbox_10.Size = new System.Drawing.Size(121, 19);
			this._txtCommanTextbox_10.TabIndex = 24;
			// 
			// _txtCommanTextbox_1
			// 
			this._txtCommanTextbox_1.AllowDrop = true;
			this._txtCommanTextbox_1.BackColor = System.Drawing.Color.White;
			this._txtCommanTextbox_1.Location = new System.Drawing.Point(320, 18);
			this._txtCommanTextbox_1.Name = "_txtCommanTextbox_1";
			this._txtCommanTextbox_1.Size = new System.Drawing.Size(263, 19);
			this._txtCommanTextbox_1.TabIndex = 25;
			// 
			// _txtCommanTextbox_2
			// 
			this._txtCommanTextbox_2.AllowDrop = true;
			this._txtCommanTextbox_2.BackColor = System.Drawing.Color.White;
			this._txtCommanTextbox_2.Location = new System.Drawing.Point(86, 39);
			this._txtCommanTextbox_2.Name = "_txtCommanTextbox_2";
			this._txtCommanTextbox_2.Size = new System.Drawing.Size(121, 19);
			this._txtCommanTextbox_2.TabIndex = 26;
			// 
			// _txtCommanTextbox_4
			// 
			this._txtCommanTextbox_4.AllowDrop = true;
			this._txtCommanTextbox_4.BackColor = System.Drawing.Color.White;
			this._txtCommanTextbox_4.Location = new System.Drawing.Point(86, 59);
			this._txtCommanTextbox_4.Name = "_txtCommanTextbox_4";
			this._txtCommanTextbox_4.Size = new System.Drawing.Size(121, 19);
			this._txtCommanTextbox_4.TabIndex = 27;
			// 
			// _txtCommanTextbox_8
			// 
			this._txtCommanTextbox_8.AllowDrop = true;
			this._txtCommanTextbox_8.BackColor = System.Drawing.Color.White;
			this._txtCommanTextbox_8.Location = new System.Drawing.Point(86, 99);
			this._txtCommanTextbox_8.Name = "_txtCommanTextbox_8";
			this._txtCommanTextbox_8.Size = new System.Drawing.Size(121, 19);
			this._txtCommanTextbox_8.TabIndex = 28;
			// 
			// _txtCommanTextbox_3
			// 
			this._txtCommanTextbox_3.AllowDrop = true;
			this._txtCommanTextbox_3.BackColor = System.Drawing.Color.White;
			this._txtCommanTextbox_3.Location = new System.Drawing.Point(320, 39);
			this._txtCommanTextbox_3.Name = "_txtCommanTextbox_3";
			this._txtCommanTextbox_3.Size = new System.Drawing.Size(263, 19);
			this._txtCommanTextbox_3.TabIndex = 29;
			// 
			// _txtCommanTextbox_5
			// 
			this._txtCommanTextbox_5.AllowDrop = true;
			this._txtCommanTextbox_5.BackColor = System.Drawing.Color.White;
			this._txtCommanTextbox_5.Location = new System.Drawing.Point(320, 59);
			this._txtCommanTextbox_5.Name = "_txtCommanTextbox_5";
			this._txtCommanTextbox_5.Size = new System.Drawing.Size(263, 19);
			this._txtCommanTextbox_5.TabIndex = 30;
			// 
			// _txtCommanTextbox_9
			// 
			this._txtCommanTextbox_9.AllowDrop = true;
			this._txtCommanTextbox_9.BackColor = System.Drawing.Color.White;
			this._txtCommanTextbox_9.Location = new System.Drawing.Point(320, 99);
			this._txtCommanTextbox_9.Name = "_txtCommanTextbox_9";
			this._txtCommanTextbox_9.Size = new System.Drawing.Size(121, 19);
			this._txtCommanTextbox_9.TabIndex = 31;
			// 
			// _txtCommanTextbox_12
			// 
			this._txtCommanTextbox_12.AllowDrop = true;
			this._txtCommanTextbox_12.BackColor = System.Drawing.Color.White;
			this._txtCommanTextbox_12.Location = new System.Drawing.Point(248, -8);
			this._txtCommanTextbox_12.Name = "_txtCommanTextbox_12";
			this._txtCommanTextbox_12.Size = new System.Drawing.Size(45, 19);
			this._txtCommanTextbox_12.TabIndex = 32;
			this._txtCommanTextbox_12.Visible = false;
			// 
			// _txtCommanTextbox_27
			// 
			this._txtCommanTextbox_27.AllowDrop = true;
			this._txtCommanTextbox_27.BackColor = System.Drawing.Color.White;
			this._txtCommanTextbox_27.Location = new System.Drawing.Point(86, 140);
			this._txtCommanTextbox_27.Name = "_txtCommanTextbox_27";
			this._txtCommanTextbox_27.Size = new System.Drawing.Size(121, 19);
			this._txtCommanTextbox_27.TabIndex = 33;
			// 
			// _lblCommon_28
			// 
			this._lblCommon_28.AllowDrop = true;
			this._lblCommon_28.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_28.Text = "B.Unit";
			this._lblCommon_28.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_28.Location = new System.Drawing.Point(8, 143);
			this._lblCommon_28.Name = "_lblCommon_28";
			this._lblCommon_28.Size = new System.Drawing.Size(29, 13);
			this._lblCommon_28.TabIndex = 34;
			// 
			// _txtCommanTextbox_28
			// 
			this._txtCommanTextbox_28.AllowDrop = true;
			this._txtCommanTextbox_28.BackColor = System.Drawing.Color.White;
			this._txtCommanTextbox_28.Location = new System.Drawing.Point(528, 140);
			this._txtCommanTextbox_28.Name = "_txtCommanTextbox_28";
			this._txtCommanTextbox_28.Size = new System.Drawing.Size(55, 19);
			this._txtCommanTextbox_28.TabIndex = 73;
			// 
			// _lblCommon_27
			// 
			this._lblCommon_27.AllowDrop = true;
			this._lblCommon_27.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_27.Text = "Sales Rate - 1";
			this._lblCommon_27.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_27.Location = new System.Drawing.Point(454, 143);
			// this._lblCommon_27.mLabelId = 926;
			this._lblCommon_27.Name = "_lblCommon_27";
			this._lblCommon_27.Size = new System.Drawing.Size(67, 13);
			this._lblCommon_27.TabIndex = 74;
			// 
			// repItemQuery
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.ClientSize = new System.Drawing.Size(939, 614);
			this.Controls.Add(this.tabLocation);
			this.Controls.Add(this.fraProductDetails);
			this.ForeColor = System.Drawing.Color.FromArgb(250, 244, 231);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			//this.Icon = (System.Drawing.Icon) resources.GetObject("repItemQuery.Icon");
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(98, 132);
			this.MaximizeBox = true;
			this.MinimizeBox = true;
			this.Name = "repItemQuery";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Tag = "False";
			this.Text = "Item Query";
			// this.Activated += new System.EventHandler(this.Form_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
			// this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
			//((System.ComponentModel.ISupportInitialize) this.tabTransactions).EndInit();
			//((System.ComponentModel.ISupportInitialize) this.tabDetails).EndInit();
			//((System.ComponentModel.ISupportInitialize) this.ChartControl).EndInit();
			//((System.ComponentModel.ISupportInitialize) this.tabSummary).EndInit();
			//((System.ComponentModel.ISupportInitialize) this.tabLocation).EndInit();
			this.tabLocation.ResumeLayout(false);
			this.tabTransactions.ResumeLayout(false);
			this.Frame2.ResumeLayout(false);
			this.tabDetails.ResumeLayout(false);
			this.grdLocationDetails.ResumeLayout(false);
			this.tabSummary.ResumeLayout(false);
			this.fraProductDetails.ResumeLayout(false);
			this.fraProductInformation.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		void ReLoadForm(bool addEvents)
		{
			InitializetxtLastCommanLabel();
			InitializetxtCommanTextbox();
			InitializelblCommon();
			InitializeLine1();
			//This form is an MDI child.
			//This code simulates the VB6 
			// functionality of automatically
			// loading and showing an MDI
			// child's parent.
			this.MdiParent = Xtreme.frmSysMain.DefInstance;
			Xtreme.frmSysMain.DefInstance.Show();
		}
		void InitializetxtLastCommanLabel()
		{
			this.txtLastCommanLabel = new System.Windows.Forms.Label[7];
			this.txtLastCommanLabel[4] = _txtLastCommanLabel_4;
			this.txtLastCommanLabel[1] = _txtLastCommanLabel_1;
			this.txtLastCommanLabel[5] = _txtLastCommanLabel_5;
			this.txtLastCommanLabel[2] = _txtLastCommanLabel_2;
			this.txtLastCommanLabel[3] = _txtLastCommanLabel_3;
			this.txtLastCommanLabel[6] = _txtLastCommanLabel_6;
		}
		void InitializetxtCommanTextbox()
		{
			this.txtCommanTextbox = new System.Windows.Forms.Label[29];
			this.txtCommanTextbox[13] = _txtCommanTextbox_13;
			this.txtCommanTextbox[14] = _txtCommanTextbox_14;
			this.txtCommanTextbox[16] = _txtCommanTextbox_16;
			this.txtCommanTextbox[17] = _txtCommanTextbox_17;
			this.txtCommanTextbox[18] = _txtCommanTextbox_18;
			this.txtCommanTextbox[15] = _txtCommanTextbox_15;
			this.txtCommanTextbox[22] = _txtCommanTextbox_22;
			this.txtCommanTextbox[23] = _txtCommanTextbox_23;
			this.txtCommanTextbox[24] = _txtCommanTextbox_24;
			this.txtCommanTextbox[19] = _txtCommanTextbox_19;
			this.txtCommanTextbox[20] = _txtCommanTextbox_20;
			this.txtCommanTextbox[21] = _txtCommanTextbox_21;
			this.txtCommanTextbox[26] = _txtCommanTextbox_26;
			this.txtCommanTextbox[25] = _txtCommanTextbox_25;
			this.txtCommanTextbox[7] = _txtCommanTextbox_7;
			this.txtCommanTextbox[6] = _txtCommanTextbox_6;
			this.txtCommanTextbox[11] = _txtCommanTextbox_11;
			this.txtCommanTextbox[10] = _txtCommanTextbox_10;
			this.txtCommanTextbox[1] = _txtCommanTextbox_1;
			this.txtCommanTextbox[2] = _txtCommanTextbox_2;
			this.txtCommanTextbox[4] = _txtCommanTextbox_4;
			this.txtCommanTextbox[8] = _txtCommanTextbox_8;
			this.txtCommanTextbox[3] = _txtCommanTextbox_3;
			this.txtCommanTextbox[5] = _txtCommanTextbox_5;
			this.txtCommanTextbox[9] = _txtCommanTextbox_9;
			this.txtCommanTextbox[12] = _txtCommanTextbox_12;
			this.txtCommanTextbox[27] = _txtCommanTextbox_27;
			this.txtCommanTextbox[28] = _txtCommanTextbox_28;
		}
		void InitializelblCommon()
		{
			this.lblCommon = new System.Windows.Forms.Label[29];
			this.lblCommon[13] = _lblCommon_13;
			this.lblCommon[12] = _lblCommon_12;
			this.lblCommon[14] = _lblCommon_14;
			this.lblCommon[15] = _lblCommon_15;
			this.lblCommon[17] = _lblCommon_17;
			this.lblCommon[18] = _lblCommon_18;
			this.lblCommon[19] = _lblCommon_19;
			this.lblCommon[20] = _lblCommon_20;
			this.lblCommon[21] = _lblCommon_21;
			this.lblCommon[16] = _lblCommon_16;
			this.lblCommon[22] = _lblCommon_22;
			this.lblCommon[26] = _lblCommon_26;
			this.lblCommon[25] = _lblCommon_25;
			this.lblCommon[4] = _lblCommon_4;
			this.lblCommon[2] = _lblCommon_2;
			this.lblCommon[9] = _lblCommon_9;
			this.lblCommon[6] = _lblCommon_6;
			this.lblCommon[5] = _lblCommon_5;
			this.lblCommon[0] = _lblCommon_0;
			this.lblCommon[7] = _lblCommon_7;
			this.lblCommon[8] = _lblCommon_8;
			this.lblCommon[1] = _lblCommon_1;
			this.lblCommon[3] = _lblCommon_3;
			this.lblCommon[11] = _lblCommon_11;
			this.lblCommon[10] = _lblCommon_10;
			this.lblCommon[23] = _lblCommon_23;
			this.lblCommon[24] = _lblCommon_24;
			this.lblCommon[28] = _lblCommon_28;
			this.lblCommon[27] = _lblCommon_27;
		}
		void InitializeLine1()
		{
			this.Line1 = new System.Windows.Forms.Label[2];
			this.Line1[0] = _Line1_0;
			this.Line1[1] = _Line1_1;
		}
		#endregion
	}
}