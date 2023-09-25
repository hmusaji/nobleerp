
namespace Xtreme
{
	partial class frmPayEmployeeLeave
	{

		#region "Upgrade Support "
		private static frmPayEmployeeLeave m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmPayEmployeeLeave DefInstance
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
		public static frmPayEmployeeLeave CreateInstance()
		{
			frmPayEmployeeLeave theInstance = new frmPayEmployeeLeave();
			
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
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "System.Windows.Forms.Label1", "_txtDisplayLabel_7", "_lblCommon_10", "_lblCommon_9", "_txtCommonNumber_0", "_txtCommonNumber_6", "fraFixedLeaveInfo", "Column_0_cmbMastersList", "Column_1_cmbMastersList", "cmbMastersList", "_lblCommon_1", "_lblCommon_3", "_lblCommon_4", "_lblCommon_5", "_lblCommon_6", "_lblCommon_7", "_lblCommon_15", "_lblCommon_16", "_lblCommon_17", "txtOpeningBalanceAsOn", "_txtCommonNumber_1", "_txtCommonNumber_2", "_txtCommonNumber_4", "_txtCommonNumber_5", "_CmbCommon_0", "_lblCommon_2", "_lblCommon_12", "_CmbCommon_1", "_lblCommon_19", "_lblCommon_0", "_txtCommon_7", "_lblCommon_8", "_lblCommon_11", "_txtCommonNumber_3", "_txtCommonNumber_7", "Frame1", "_txtDisplayLabel_5", "_txtDisplayLabel_4", "_txtDisplayLabel_3", "_txtDisplayLabel_2", "_txtDisplayLabel_1", "Column_0_grdVoucherDetails", "Column_1_grdVoucherDetails", "grdVoucherDetails", "cntMasterDetails", "_lblSystemComponents_1", "_lblCommonLabel_2", "_txtDisplayLabel_6", "_txtDisplayLabel_0", "_Line1_1", "CmbCommon", "Line1", "lblCommon", "lblCommonLabel", "lblSystemComponents", "txtCommon", "txtCommonNumber", "txtDisplayLabel"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public System.Windows.Forms.Label Label1;
		private System.Windows.Forms.Label _txtDisplayLabel_7;
		private System.Windows.Forms.Label _lblCommon_10;
		private System.Windows.Forms.Label _lblCommon_9;
		private System.Windows.Forms.TextBox _txtCommonNumber_0;
		private System.Windows.Forms.TextBox _txtCommonNumber_6;
		public System.Windows.Forms.GroupBox fraFixedLeaveInfo;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_0_cmbMastersList;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_1_cmbMastersList;
		public C1.Win.C1TrueDBGrid.C1TrueDBDropdown cmbMastersList;
		private System.Windows.Forms.Label _lblCommon_1;
		private System.Windows.Forms.Label _lblCommon_3;
		private System.Windows.Forms.Label _lblCommon_4;
		private System.Windows.Forms.Label _lblCommon_5;
		private System.Windows.Forms.Label _lblCommon_6;
		private System.Windows.Forms.Label _lblCommon_7;
		private System.Windows.Forms.Label _lblCommon_15;
		private System.Windows.Forms.Label _lblCommon_16;
		private System.Windows.Forms.Label _lblCommon_17;
		public Syncfusion.WinForms.Input.SfDateTimeEdit txtOpeningBalanceAsOn;
		private System.Windows.Forms.TextBox _txtCommonNumber_1;
		private System.Windows.Forms.TextBox _txtCommonNumber_2;
		private System.Windows.Forms.TextBox _txtCommonNumber_4;
		private System.Windows.Forms.TextBox _txtCommonNumber_5;
		private System.Windows.Forms.ComboBox _CmbCommon_0;
		private System.Windows.Forms.Label _lblCommon_2;
		private System.Windows.Forms.Label _lblCommon_12;
		private System.Windows.Forms.ComboBox _CmbCommon_1;
		private System.Windows.Forms.Label _lblCommon_19;
		private System.Windows.Forms.Label _lblCommon_0;
		private System.Windows.Forms.TextBox _txtCommon_7;
		private System.Windows.Forms.Label _lblCommon_8;
		private System.Windows.Forms.Label _lblCommon_11;
		private System.Windows.Forms.TextBox _txtCommonNumber_3;
		private System.Windows.Forms.TextBox _txtCommonNumber_7;
		public System.Windows.Forms.GroupBox Frame1;
		private System.Windows.Forms.Label _txtDisplayLabel_5;
		private System.Windows.Forms.Label _txtDisplayLabel_4;
		private System.Windows.Forms.Label _txtDisplayLabel_3;
		private System.Windows.Forms.Label _txtDisplayLabel_2;
		private System.Windows.Forms.Label _txtDisplayLabel_1;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_0_grdVoucherDetails;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_1_grdVoucherDetails;
		public C1.Win.C1TrueDBGrid.C1TrueDBGrid grdVoucherDetails;
		public AxTDBContainer3D6.AxTDBContainer3D cntMasterDetails;
		private System.Windows.Forms.Label _lblSystemComponents_1;
		private System.Windows.Forms.Label _lblCommonLabel_2;
		private System.Windows.Forms.Label _txtDisplayLabel_6;
		private System.Windows.Forms.Label _txtDisplayLabel_0;
		private System.Windows.Forms.Label _Line1_1;
		public System.Windows.Forms.ComboBox[] CmbCommon = new System.Windows.Forms.ComboBox[2];
		public System.Windows.Forms.Label[] Line1 = new System.Windows.Forms.Label[2];
		public System.Windows.Forms.Label[] lblCommon = new System.Windows.Forms.Label[20];
		public System.Windows.Forms.Label[] lblCommonLabel = new System.Windows.Forms.Label[3];
		public System.Windows.Forms.Label[] lblSystemComponents = new System.Windows.Forms.Label[2];
		public System.Windows.Forms.TextBox[] txtCommon = new System.Windows.Forms.TextBox[8];
		public System.Windows.Forms.TextBox[] txtCommonNumber = new System.Windows.Forms.TextBox[8];
		public System.Windows.Forms.Label[] txtDisplayLabel = new System.Windows.Forms.Label[8];
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPayEmployeeLeave));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this.cntMasterDetails = new AxTDBContainer3D6.AxTDBContainer3D();
			this.Label1 = new System.Windows.Forms.Label();
			this._txtDisplayLabel_7 = new System.Windows.Forms.Label();
			this.fraFixedLeaveInfo = new System.Windows.Forms.GroupBox();
			this._lblCommon_10 = new System.Windows.Forms.Label();
			this._lblCommon_9 = new System.Windows.Forms.Label();
			this._txtCommonNumber_0 = new System.Windows.Forms.TextBox();
			this._txtCommonNumber_6 = new System.Windows.Forms.TextBox();
			this.cmbMastersList = new C1.Win.C1TrueDBGrid.C1TrueDBDropdown();
			this.Column_0_cmbMastersList = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.Column_1_cmbMastersList = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this._lblCommon_1 = new System.Windows.Forms.Label();
			this._lblCommon_3 = new System.Windows.Forms.Label();
			this._lblCommon_4 = new System.Windows.Forms.Label();
			this._lblCommon_5 = new System.Windows.Forms.Label();
			this._lblCommon_6 = new System.Windows.Forms.Label();
			this._lblCommon_7 = new System.Windows.Forms.Label();
			this._lblCommon_15 = new System.Windows.Forms.Label();
			this._lblCommon_16 = new System.Windows.Forms.Label();
			this._lblCommon_17 = new System.Windows.Forms.Label();
			this.txtOpeningBalanceAsOn = new Syncfusion.WinForms.Input.SfDateTimeEdit();
			this._txtCommonNumber_1 = new System.Windows.Forms.TextBox();
			this._txtCommonNumber_2 = new System.Windows.Forms.TextBox();
			this._txtCommonNumber_4 = new System.Windows.Forms.TextBox();
			this._txtCommonNumber_5 = new System.Windows.Forms.TextBox();
			this._CmbCommon_0 = new System.Windows.Forms.ComboBox();
			this._lblCommon_2 = new System.Windows.Forms.Label();
			this._lblCommon_12 = new System.Windows.Forms.Label();
			this._CmbCommon_1 = new System.Windows.Forms.ComboBox();
			this._lblCommon_19 = new System.Windows.Forms.Label();
			this._lblCommon_0 = new System.Windows.Forms.Label();
			this._txtCommon_7 = new System.Windows.Forms.TextBox();
			this.Frame1 = new System.Windows.Forms.GroupBox();
			this._lblCommon_8 = new System.Windows.Forms.Label();
			this._lblCommon_11 = new System.Windows.Forms.Label();
			this._txtCommonNumber_3 = new System.Windows.Forms.TextBox();
			this._txtCommonNumber_7 = new System.Windows.Forms.TextBox();
			this._txtDisplayLabel_5 = new System.Windows.Forms.Label();
			this._txtDisplayLabel_4 = new System.Windows.Forms.Label();
			this._txtDisplayLabel_3 = new System.Windows.Forms.Label();
			this._txtDisplayLabel_2 = new System.Windows.Forms.Label();
			this._txtDisplayLabel_1 = new System.Windows.Forms.Label();
			this.grdVoucherDetails = new C1.Win.C1TrueDBGrid.C1TrueDBGrid();
			this.Column_0_grdVoucherDetails = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.Column_1_grdVoucherDetails = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this._lblSystemComponents_1 = new System.Windows.Forms.Label();
			this._lblCommonLabel_2 = new System.Windows.Forms.Label();
			this._txtDisplayLabel_6 = new System.Windows.Forms.Label();
			this._txtDisplayLabel_0 = new System.Windows.Forms.Label();
			this._Line1_1 = new System.Windows.Forms.Label();
			// //((System.ComponentModel.ISupportInitialize) this.cntMasterDetails).BeginInit();
			this.cntMasterDetails.SuspendLayout();
			this.fraFixedLeaveInfo.SuspendLayout();
			this.cmbMastersList.SuspendLayout();
			this.Frame1.SuspendLayout();
			this.grdVoucherDetails.SuspendLayout();
			this.SuspendLayout();
			// 
			// cntMasterDetails
			// 
			this.cntMasterDetails.AllowDrop = true;
			this.cntMasterDetails.Controls.Add(this.Label1);
			this.cntMasterDetails.Controls.Add(this._txtDisplayLabel_7);
			this.cntMasterDetails.Controls.Add(this.fraFixedLeaveInfo);
			this.cntMasterDetails.Controls.Add(this.cmbMastersList);
			this.cntMasterDetails.Controls.Add(this._lblCommon_1);
			this.cntMasterDetails.Controls.Add(this._lblCommon_3);
			this.cntMasterDetails.Controls.Add(this._lblCommon_4);
			this.cntMasterDetails.Controls.Add(this._lblCommon_5);
			this.cntMasterDetails.Controls.Add(this._lblCommon_6);
			this.cntMasterDetails.Controls.Add(this._lblCommon_7);
			this.cntMasterDetails.Controls.Add(this._lblCommon_15);
			this.cntMasterDetails.Controls.Add(this._lblCommon_16);
			this.cntMasterDetails.Controls.Add(this._lblCommon_17);
			this.cntMasterDetails.Controls.Add(this.txtOpeningBalanceAsOn);
			this.cntMasterDetails.Controls.Add(this._txtCommonNumber_1);
			this.cntMasterDetails.Controls.Add(this._txtCommonNumber_2);
			this.cntMasterDetails.Controls.Add(this._txtCommonNumber_4);
			this.cntMasterDetails.Controls.Add(this._txtCommonNumber_5);
			this.cntMasterDetails.Controls.Add(this._CmbCommon_0);
			this.cntMasterDetails.Controls.Add(this._lblCommon_2);
			this.cntMasterDetails.Controls.Add(this._lblCommon_12);
			this.cntMasterDetails.Controls.Add(this._CmbCommon_1);
			this.cntMasterDetails.Controls.Add(this._lblCommon_19);
			this.cntMasterDetails.Controls.Add(this._lblCommon_0);
			this.cntMasterDetails.Controls.Add(this._txtCommon_7);
			this.cntMasterDetails.Controls.Add(this.Frame1);
			this.cntMasterDetails.Controls.Add(this._txtDisplayLabel_5);
			this.cntMasterDetails.Controls.Add(this._txtDisplayLabel_4);
			this.cntMasterDetails.Controls.Add(this._txtDisplayLabel_3);
			this.cntMasterDetails.Controls.Add(this._txtDisplayLabel_2);
			this.cntMasterDetails.Controls.Add(this._txtDisplayLabel_1);
			this.cntMasterDetails.Controls.Add(this.grdVoucherDetails);
			this.cntMasterDetails.Location = new System.Drawing.Point(6, 90);
			this.cntMasterDetails.Name = "cntMasterDetails";
			("cntMasterDetails.OcxState");
			this.cntMasterDetails.Size = new System.Drawing.Size(677, 269);
			this.cntMasterDetails.TabIndex = 12;
			// 
			// System.Windows.Forms.Label1
			// 
			this.Label1.AllowDrop = true;
			this.Label1.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this.Label1.Text = "Leave Balance";
			this.Label1.Location = new System.Drawing.Point(10, 244);
			this.Label1.Name = "System.Windows.Forms.Label1";
			this.Label1.Size = new System.Drawing.Size(72, 14);
			this.Label1.TabIndex = 44;
			// 
			// _txtDisplayLabel_7
			// 
			this._txtDisplayLabel_7.AllowDrop = true;
			this._txtDisplayLabel_7.BackColor = System.Drawing.SystemColors.Window;
			this._txtDisplayLabel_7.Enabled = false;
			this._txtDisplayLabel_7.Location = new System.Drawing.Point(192, 242);
			this._txtDisplayLabel_7.Name = "_txtDisplayLabel_7";
			this._txtDisplayLabel_7.Size = new System.Drawing.Size(97, 19);
			this._txtDisplayLabel_7.TabIndex = 43;
			// 
			// fraFixedLeaveInfo
			// 
			this.fraFixedLeaveInfo.AllowDrop = true;
			this.fraFixedLeaveInfo.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this.fraFixedLeaveInfo.Controls.Add(this._lblCommon_10);
			this.fraFixedLeaveInfo.Controls.Add(this._lblCommon_9);
			this.fraFixedLeaveInfo.Controls.Add(this._txtCommonNumber_0);
			this.fraFixedLeaveInfo.Controls.Add(this._txtCommonNumber_6);
			this.fraFixedLeaveInfo.Enabled = true;
			this.fraFixedLeaveInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 178);
			this.fraFixedLeaveInfo.ForeColor = System.Drawing.Color.FromArgb(53, 91, 225);
			this.fraFixedLeaveInfo.Location = new System.Drawing.Point(10, 154);
			this.fraFixedLeaveInfo.Name = "fraFixedLeaveInfo";
			this.fraFixedLeaveInfo.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.fraFixedLeaveInfo.Size = new System.Drawing.Size(281, 63);
			this.fraFixedLeaveInfo.TabIndex = 21;
			this.fraFixedLeaveInfo.Text = " Before Switch Over Period ";
			this.fraFixedLeaveInfo.Visible = true;
			// 
			// _lblCommon_10
			// 
			this._lblCommon_10.AllowDrop = true;
			this._lblCommon_10.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._lblCommon_10.Text = "Leave Days";
			this._lblCommon_10.Location = new System.Drawing.Point(10, 19);
			// // this._lblCommon_10.mLabelId = 369;
			this._lblCommon_10.Name = "_lblCommon_10";
			this._lblCommon_10.Size = new System.Drawing.Size(56, 13);
			this._lblCommon_10.TabIndex = 22;
			// 
			// _lblCommon_9
			// 
			this._lblCommon_9.AllowDrop = true;
			this._lblCommon_9.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._lblCommon_9.Text = "Working Days Per Month";
			this._lblCommon_9.Location = new System.Drawing.Point(10, 40);
			// // this._lblCommon_9.mLabelId = 1093;
			this._lblCommon_9.Name = "_lblCommon_9";
			this._lblCommon_9.Size = new System.Drawing.Size(118, 13);
			this._lblCommon_9.TabIndex = 30;
			// 
			// _txtCommonNumber_0
			// 
			this._txtCommonNumber_0.AllowDrop = true;
			// this._txtCommonNumber_0.DisplayFormat = "####0.000###;;0.000;0.000";
			// this._txtCommonNumber_0.Format = "###########0.000";
			this._txtCommonNumber_0.Location = new System.Drawing.Point(162, 37);
			// this._txtCommonNumber_0.MaxValue = 2147483647;
			// this._txtCommonNumber_0.MinValue = 0;
			this._txtCommonNumber_0.Name = "_txtCommonNumber_0";
			this._txtCommonNumber_0.Size = new System.Drawing.Size(101, 19);
			this._txtCommonNumber_0.TabIndex = 2;
			this._txtCommonNumber_0.Text = "0.000";
			// this.this._txtCommonNumber_0.Change += new System.Windows.Forms.TextBox.ChangeHandler(this.txtCommonNumber_Change);
			// 
			// _txtCommonNumber_6
			// 
			this._txtCommonNumber_6.AllowDrop = true;
			// this._txtCommonNumber_6.DisplayFormat = "####0.000###;;0.000;0.000";
			// this._txtCommonNumber_6.Format = "###########0.000";
			this._txtCommonNumber_6.Location = new System.Drawing.Point(162, 16);
			// this._txtCommonNumber_6.MaxValue = 2147483647;
			// this._txtCommonNumber_6.MinValue = 0;
			this._txtCommonNumber_6.Name = "_txtCommonNumber_6";
			this._txtCommonNumber_6.Size = new System.Drawing.Size(101, 19);
			this._txtCommonNumber_6.TabIndex = 1;
			this._txtCommonNumber_6.Text = "0.000";
			// this.this._txtCommonNumber_6.Change += new System.Windows.Forms.TextBox.ChangeHandler(this.txtCommonNumber_Change);
			// 
			// cmbMastersList
			// 
			this.cmbMastersList.AllowDrop = true;
			this.cmbMastersList.ColumnHeaders = true;
			this.cmbMastersList.Enabled = true;
			this.cmbMastersList.Location = new System.Drawing.Point(12, 4);
			this.cmbMastersList.Name = "cmbMastersList";
			this.cmbMastersList.Size = new System.Drawing.Size(69, 57);
			this.cmbMastersList.TabIndex = 13;
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
			// _lblCommon_1
			// 
			this._lblCommon_1.AllowDrop = true;
			this._lblCommon_1.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._lblCommon_1.Text = "Paid Leave Taken (Days)";
			this._lblCommon_1.Location = new System.Drawing.Point(10, 225);
			// // this._lblCommon_1.mLabelId = 1832;
			this._lblCommon_1.Name = "_lblCommon_1";
			this._lblCommon_1.Size = new System.Drawing.Size(119, 13);
			this._lblCommon_1.TabIndex = 15;
			// 
			// _lblCommon_3
			// 
			this._lblCommon_3.AllowDrop = true;
			this._lblCommon_3.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._lblCommon_3.Text = "Opening Paid Leave Taken (Days)";
			this._lblCommon_3.Location = new System.Drawing.Point(10, 317);
			// // this._lblCommon_3.mLabelId = 1100;
			this._lblCommon_3.Name = "_lblCommon_3";
			this._lblCommon_3.Size = new System.Drawing.Size(162, 13);
			this._lblCommon_3.TabIndex = 16;
			this._lblCommon_3.Visible = false;
			// 
			// _lblCommon_4
			// 
			this._lblCommon_4.AllowDrop = true;
			this._lblCommon_4.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._lblCommon_4.Text = "Total Paid Leave Taken (Days)";
			this._lblCommon_4.Location = new System.Drawing.Point(10, 335);
			// // this._lblCommon_4.mLabelId = 1101;
			this._lblCommon_4.Name = "_lblCommon_4";
			this._lblCommon_4.Size = new System.Drawing.Size(146, 13);
			this._lblCommon_4.TabIndex = 17;
			this._lblCommon_4.Visible = false;
			// 
			// _lblCommon_5
			// 
			this._lblCommon_5.AllowDrop = true;
			this._lblCommon_5.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._lblCommon_5.Text = "Opening Paid Leave Balance (Days)";
			this._lblCommon_5.Location = new System.Drawing.Point(10, 297);
			// // this._lblCommon_5.mLabelId = 1099;
			this._lblCommon_5.Name = "_lblCommon_5";
			this._lblCommon_5.Size = new System.Drawing.Size(170, 13);
			this._lblCommon_5.TabIndex = 18;
			this._lblCommon_5.Visible = false;
			// 
			// _lblCommon_6
			// 
			this._lblCommon_6.AllowDrop = true;
			this._lblCommon_6.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._lblCommon_6.Text = "Unpaid Leave Taken (Days)";
			this._lblCommon_6.Location = new System.Drawing.Point(403, 226);
			// // this._lblCommon_6.mLabelId = 1831;
			this._lblCommon_6.Name = "_lblCommon_6";
			this._lblCommon_6.Size = new System.Drawing.Size(132, 13);
			this._lblCommon_6.TabIndex = 19;
			// 
			// _lblCommon_7
			// 
			this._lblCommon_7.AllowDrop = true;
			this._lblCommon_7.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._lblCommon_7.Text = "Maximum Leave Days";
			this._lblCommon_7.Location = new System.Drawing.Point(432, 296);
			// // this._lblCommon_7.mLabelId = 1103;
			this._lblCommon_7.Name = "_lblCommon_7";
			this._lblCommon_7.Size = new System.Drawing.Size(103, 13);
			this._lblCommon_7.TabIndex = 20;
			this._lblCommon_7.Visible = false;
			// 
			// _lblCommon_15
			// 
			this._lblCommon_15.AllowDrop = true;
			this._lblCommon_15.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._lblCommon_15.Text = "As On";
			this._lblCommon_15.Location = new System.Drawing.Point(298, 296);
			// // this._lblCommon_15.mLabelId = 1094;
			this._lblCommon_15.Name = "_lblCommon_15";
			this._lblCommon_15.Size = new System.Drawing.Size(29, 13);
			this._lblCommon_15.TabIndex = 23;
			this._lblCommon_15.Visible = false;
			// 
			// _lblCommon_16
			// 
			this._lblCommon_16.AllowDrop = true;
			this._lblCommon_16.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._lblCommon_16.Text = "Opening Unpaid Leave Taken (Days)";
			this._lblCommon_16.Location = new System.Drawing.Point(360, 317);
			// // this._lblCommon_16.mLabelId = 1104;
			this._lblCommon_16.Name = "_lblCommon_16";
			this._lblCommon_16.Size = new System.Drawing.Size(175, 13);
			this._lblCommon_16.TabIndex = 24;
			this._lblCommon_16.Visible = false;
			// 
			// _lblCommon_17
			// 
			this._lblCommon_17.AllowDrop = true;
			this._lblCommon_17.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._lblCommon_17.Text = "Total Unpaid Leave Taken (Days)";
			this._lblCommon_17.Location = new System.Drawing.Point(376, 335);
			// // this._lblCommon_17.mLabelId = 1105;
			this._lblCommon_17.Name = "_lblCommon_17";
			this._lblCommon_17.Size = new System.Drawing.Size(159, 13);
			this._lblCommon_17.TabIndex = 25;
			this._lblCommon_17.Visible = false;
			// 
			// txtOpeningBalanceAsOn
			// 
			this.txtOpeningBalanceAsOn.AllowDrop = true;
			// this.txtOpeningBalanceAsOn.CheckDateRange = false;
			this.txtOpeningBalanceAsOn.Location = new System.Drawing.Point(331, 294);
			// this.txtOpeningBalanceAsOn.MaxDate = 2958465;
			// this.txtOpeningBalanceAsOn.MinDate = 2;
			this.txtOpeningBalanceAsOn.Name = "txtOpeningBalanceAsOn";
			this.txtOpeningBalanceAsOn.Size = new System.Drawing.Size(91, 19);
			this.txtOpeningBalanceAsOn.TabIndex = 8;
			this.txtOpeningBalanceAsOn.Text = "09/02/2013";
			this.txtOpeningBalanceAsOn.Visible = false;
			// 
			// _txtCommonNumber_1
			// 
			this._txtCommonNumber_1.AllowDrop = true;
			// this._txtCommonNumber_1.DisplayFormat = "####0.000###;;0.000;0.000";
			// this._txtCommonNumber_1.Format = "###########0.000";
			this._txtCommonNumber_1.Location = new System.Drawing.Point(188, 294);
			// this._txtCommonNumber_1.MaxValue = 2147483647;
			// this._txtCommonNumber_1.MinValue = 0;
			this._txtCommonNumber_1.Name = "_txtCommonNumber_1";
			this._txtCommonNumber_1.Size = new System.Drawing.Size(101, 19);
			this._txtCommonNumber_1.TabIndex = 7;
			this._txtCommonNumber_1.Text = "0.000";
			this._txtCommonNumber_1.Visible = false;
			// this.this._txtCommonNumber_1.Change += new System.Windows.Forms.TextBox.ChangeHandler(this.txtCommonNumber_Change);
			// 
			// _txtCommonNumber_2
			// 
			this._txtCommonNumber_2.AllowDrop = true;
			// this._txtCommonNumber_2.DisplayFormat = "####0.000###;;0.000;0.000";
			// this._txtCommonNumber_2.Format = "###########0.000";
			this._txtCommonNumber_2.Location = new System.Drawing.Point(188, 314);
			// this._txtCommonNumber_2.MaxValue = 2147483647;
			// this._txtCommonNumber_2.MinValue = 0;
			this._txtCommonNumber_2.Name = "_txtCommonNumber_2";
			this._txtCommonNumber_2.Size = new System.Drawing.Size(101, 19);
			this._txtCommonNumber_2.TabIndex = 10;
			this._txtCommonNumber_2.Text = "0.000";
			this._txtCommonNumber_2.Visible = false;
			// this.this._txtCommonNumber_2.Change += new System.Windows.Forms.TextBox.ChangeHandler(this.txtCommonNumber_Change);
			// 
			// _txtCommonNumber_4
			// 
			this._txtCommonNumber_4.AllowDrop = true;
			// this._txtCommonNumber_4.DisplayFormat = "####0.000###;;0.000;0.000";
			// this._txtCommonNumber_4.Format = "###########0.000";
			this._txtCommonNumber_4.Location = new System.Drawing.Point(564, 294);
			// this._txtCommonNumber_4.MaxValue = 2147483647;
			// this._txtCommonNumber_4.MinValue = 0;
			this._txtCommonNumber_4.Name = "_txtCommonNumber_4";
			this._txtCommonNumber_4.Size = new System.Drawing.Size(101, 19);
			this._txtCommonNumber_4.TabIndex = 9;
			this._txtCommonNumber_4.Text = "0.000";
			this._txtCommonNumber_4.Visible = false;
			// this.this._txtCommonNumber_4.Change += new System.Windows.Forms.TextBox.ChangeHandler(this.txtCommonNumber_Change);
			// 
			// _txtCommonNumber_5
			// 
			this._txtCommonNumber_5.AllowDrop = true;
			// this._txtCommonNumber_5.DisplayFormat = "####0.000###;;0.000;0.000";
			// this._txtCommonNumber_5.Format = "###########0.000";
			this._txtCommonNumber_5.Location = new System.Drawing.Point(564, 314);
			// this._txtCommonNumber_5.MaxValue = 2147483647;
			// this._txtCommonNumber_5.MinValue = 0;
			this._txtCommonNumber_5.Name = "_txtCommonNumber_5";
			this._txtCommonNumber_5.Size = new System.Drawing.Size(101, 19);
			this._txtCommonNumber_5.TabIndex = 11;
			this._txtCommonNumber_5.Text = "0.000";
			this._txtCommonNumber_5.Visible = false;
			// this.this._txtCommonNumber_5.Change += new System.Windows.Forms.TextBox.ChangeHandler(this.txtCommonNumber_Change);
			// 
			// _CmbCommon_0
			// 
			this._CmbCommon_0.AllowDrop = true;
			this._CmbCommon_0.Location = new System.Drawing.Point(234, 270);
			this._CmbCommon_0.Name = "_CmbCommon_0";
			this._CmbCommon_0.Size = new System.Drawing.Size(55, 21);
			this._CmbCommon_0.TabIndex = 5;
			this._CmbCommon_0.Visible = false;
			// 
			// _lblCommon_2
			// 
			this._lblCommon_2.AllowDrop = true;
			this._lblCommon_2.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._lblCommon_2.Text = "Deduct Paid Days";
			this._lblCommon_2.Location = new System.Drawing.Point(10, 274);
			// // this._lblCommon_2.mLabelId = 1089;
			this._lblCommon_2.Name = "_lblCommon_2";
			this._lblCommon_2.Size = new System.Drawing.Size(84, 13);
			this._lblCommon_2.TabIndex = 27;
			this._lblCommon_2.Visible = false;
			// 
			// _lblCommon_12
			// 
			this._lblCommon_12.AllowDrop = true;
			this._lblCommon_12.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._lblCommon_12.Text = "Deduct Unpaid Days";
			this._lblCommon_12.Location = new System.Drawing.Point(438, 270);
			// // this._lblCommon_12.mLabelId = 1095;
			this._lblCommon_12.Name = "_lblCommon_12";
			this._lblCommon_12.Size = new System.Drawing.Size(97, 13);
			this._lblCommon_12.TabIndex = 28;
			this._lblCommon_12.Visible = false;
			// 
			// _CmbCommon_1
			// 
			this._CmbCommon_1.AllowDrop = true;
			this._CmbCommon_1.Location = new System.Drawing.Point(610, 270);
			this._CmbCommon_1.Name = "_CmbCommon_1";
			this._CmbCommon_1.Size = new System.Drawing.Size(55, 21);
			this._CmbCommon_1.TabIndex = 6;
			this._CmbCommon_1.Visible = false;
			// 
			// _lblCommon_19
			// 
			this._lblCommon_19.AllowDrop = true;
			this._lblCommon_19.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._lblCommon_19.Text = "Leave Balance As Of";
			this._lblCommon_19.Location = new System.Drawing.Point(386, 133);
			// // this._lblCommon_19.mLabelId = 1102;
			this._lblCommon_19.Name = "_lblCommon_19";
			this._lblCommon_19.Size = new System.Drawing.Size(99, 13);
			this._lblCommon_19.TabIndex = 29;
			this._lblCommon_19.Visible = false;
			// 
			// _lblCommon_0
			// 
			this._lblCommon_0.AllowDrop = true;
			this._lblCommon_0.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._lblCommon_0.Text = "Leave Swich Over Period (Years)";
			this._lblCommon_0.Location = new System.Drawing.Point(10, 133);
			// // this._lblCommon_0.mLabelId = 1098;
			this._lblCommon_0.Name = "_lblCommon_0";
			this._lblCommon_0.Size = new System.Drawing.Size(157, 13);
			this._lblCommon_0.TabIndex = 34;
			// 
			// _txtCommon_7
			// 
			this._txtCommon_7.AllowDrop = true;
			this._txtCommon_7.BackColor = System.Drawing.Color.White;
			// this._txtCommon_7.bolNumericOnly = true;
			this._txtCommon_7.ForeColor = System.Drawing.Color.Black;
			this._txtCommon_7.Location = new System.Drawing.Point(188, 130);
			this._txtCommon_7.MaxLength = 2;
			this._txtCommon_7.Name = "_txtCommon_7";
			this._txtCommon_7.Size = new System.Drawing.Size(101, 19);
			this._txtCommon_7.TabIndex = 0;
			this._txtCommon_7.Text = "";
			// 
			// Frame1
			// 
			this.Frame1.AllowDrop = true;
			this.Frame1.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this.Frame1.Controls.Add(this._lblCommon_8);
			this.Frame1.Controls.Add(this._lblCommon_11);
			this.Frame1.Controls.Add(this._txtCommonNumber_3);
			this.Frame1.Controls.Add(this._txtCommonNumber_7);
			this.Frame1.Enabled = true;
			this.Frame1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 178);
			this.Frame1.ForeColor = System.Drawing.Color.FromArgb(53, 91, 225);
			this.Frame1.Location = new System.Drawing.Point(384, 154);
			this.Frame1.Name = "Frame1";
			this.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Frame1.Size = new System.Drawing.Size(281, 63);
			this.Frame1.TabIndex = 31;
			this.Frame1.Text = " After Switch Over Period ";
			this.Frame1.Visible = true;
			// 
			// _lblCommon_8
			// 
			this._lblCommon_8.AllowDrop = true;
			this._lblCommon_8.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._lblCommon_8.Text = "Leave Days";
			this._lblCommon_8.Location = new System.Drawing.Point(10, 19);
			// // this._lblCommon_8.mLabelId = 369;
			this._lblCommon_8.Name = "_lblCommon_8";
			this._lblCommon_8.Size = new System.Drawing.Size(56, 13);
			this._lblCommon_8.TabIndex = 32;
			// 
			// _lblCommon_11
			// 
			this._lblCommon_11.AllowDrop = true;
			this._lblCommon_11.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._lblCommon_11.Text = "Working Days Per Month";
			this._lblCommon_11.Location = new System.Drawing.Point(10, 40);
			// // this._lblCommon_11.mLabelId = 1093;
			this._lblCommon_11.Name = "_lblCommon_11";
			this._lblCommon_11.Size = new System.Drawing.Size(118, 13);
			this._lblCommon_11.TabIndex = 33;
			// 
			// _txtCommonNumber_3
			// 
			this._txtCommonNumber_3.AllowDrop = true;
			// this._txtCommonNumber_3.DisplayFormat = "####0.000###;;0.000;0.000";
			// this._txtCommonNumber_3.Format = "###########0.000";
			this._txtCommonNumber_3.Location = new System.Drawing.Point(164, 37);
			// this._txtCommonNumber_3.MaxValue = 2147483647;
			// this._txtCommonNumber_3.MinValue = 0;
			this._txtCommonNumber_3.Name = "_txtCommonNumber_3";
			this._txtCommonNumber_3.Size = new System.Drawing.Size(101, 19);
			this._txtCommonNumber_3.TabIndex = 4;
			this._txtCommonNumber_3.Text = "0.000";
			// this.this._txtCommonNumber_3.Change += new System.Windows.Forms.TextBox.ChangeHandler(this.txtCommonNumber_Change);
			// 
			// _txtCommonNumber_7
			// 
			this._txtCommonNumber_7.AllowDrop = true;
			// this._txtCommonNumber_7.DisplayFormat = "####0.000###;;0.000;0.000";
			// this._txtCommonNumber_7.Format = "###########0.000";
			this._txtCommonNumber_7.Location = new System.Drawing.Point(164, 16);
			// this._txtCommonNumber_7.MaxValue = 2147483647;
			// this._txtCommonNumber_7.MinValue = 0;
			this._txtCommonNumber_7.Name = "_txtCommonNumber_7";
			this._txtCommonNumber_7.Size = new System.Drawing.Size(101, 19);
			this._txtCommonNumber_7.TabIndex = 3;
			this._txtCommonNumber_7.Text = "0.000";
			// this.this._txtCommonNumber_7.Change += new System.Windows.Forms.TextBox.ChangeHandler(this.txtCommonNumber_Change);
			// 
			// _txtDisplayLabel_5
			// 
			// this._txtDisplayLabel_5.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
			this._txtDisplayLabel_5.AllowDrop = true;
			this._txtDisplayLabel_5.Location = new System.Drawing.Point(564, 130);
			this._txtDisplayLabel_5.Name = "_txtDisplayLabel_5";
			this._txtDisplayLabel_5.Size = new System.Drawing.Size(101, 19);
			this._txtDisplayLabel_5.TabIndex = 35;
			this._txtDisplayLabel_5.Visible = false;
			// 
			// _txtDisplayLabel_4
			// 
			// this._txtDisplayLabel_4.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
			this._txtDisplayLabel_4.AllowDrop = true;
			this._txtDisplayLabel_4.Location = new System.Drawing.Point(564, 332);
			this._txtDisplayLabel_4.Name = "_txtDisplayLabel_4";
			this._txtDisplayLabel_4.Size = new System.Drawing.Size(101, 19);
			this._txtDisplayLabel_4.TabIndex = 36;
			this._txtDisplayLabel_4.Visible = false;
			// 
			// _txtDisplayLabel_3
			// 
			// this._txtDisplayLabel_3.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
			this._txtDisplayLabel_3.AllowDrop = true;
			this._txtDisplayLabel_3.Location = new System.Drawing.Point(564, 223);
			this._txtDisplayLabel_3.Name = "_txtDisplayLabel_3";
			this._txtDisplayLabel_3.Size = new System.Drawing.Size(101, 19);
			this._txtDisplayLabel_3.TabIndex = 37;
			// 
			// _txtDisplayLabel_2
			// 
			// this._txtDisplayLabel_2.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
			this._txtDisplayLabel_2.AllowDrop = true;
			this._txtDisplayLabel_2.Location = new System.Drawing.Point(188, 332);
			this._txtDisplayLabel_2.Name = "_txtDisplayLabel_2";
			this._txtDisplayLabel_2.Size = new System.Drawing.Size(101, 19);
			this._txtDisplayLabel_2.TabIndex = 38;
			this._txtDisplayLabel_2.Visible = false;
			// 
			// _txtDisplayLabel_1
			// 
			// this._txtDisplayLabel_1.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
			this._txtDisplayLabel_1.AllowDrop = true;
			this._txtDisplayLabel_1.Location = new System.Drawing.Point(192, 223);
			this._txtDisplayLabel_1.Name = "_txtDisplayLabel_1";
			this._txtDisplayLabel_1.Size = new System.Drawing.Size(97, 19);
			this._txtDisplayLabel_1.TabIndex = 39;
			// 
			// grdVoucherDetails
			// 
			this.grdVoucherDetails.AllowDrop = true;
			this.grdVoucherDetails.BackColor = System.Drawing.Color.Silver;
			this.grdVoucherDetails.CellTipsWidth = 0;
			this.grdVoucherDetails.Location = new System.Drawing.Point(0, 0);
			this.grdVoucherDetails.Name = "grdVoucherDetails";
			this.grdVoucherDetails.RowDivider.Color = System.Drawing.Color.Silver;
			this.grdVoucherDetails.Size = new System.Drawing.Size(672, 116);
			this.grdVoucherDetails.TabIndex = 42;
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
			// _lblSystemComponents_1
			// 
			this._lblSystemComponents_1.AllowDrop = true;
			this._lblSystemComponents_1.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblSystemComponents_1.Text = " Allocated Leave Information ";
			this._lblSystemComponents_1.Location = new System.Drawing.Point(8, 72);
			// // this._lblSystemComponents_1.mLabelId = 1097;
			this._lblSystemComponents_1.Name = "_lblSystemComponents_1";
			this._lblSystemComponents_1.Size = new System.Drawing.Size(167, 13);
			this._lblSystemComponents_1.TabIndex = 14;
			// 
			// _lblCommonLabel_2
			// 
			this._lblCommonLabel_2.AllowDrop = true;
			this._lblCommonLabel_2.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_2.Text = "Employee Code";
			this._lblCommonLabel_2.Location = new System.Drawing.Point(22, 46);
			// // this._lblCommonLabel_2.mLabelId = 236;
			this._lblCommonLabel_2.Name = "_lblCommonLabel_2";
			this._lblCommonLabel_2.Size = new System.Drawing.Size(74, 14);
			this._lblCommonLabel_2.TabIndex = 26;
			// 
			// _txtDisplayLabel_6
			// 
			this._txtDisplayLabel_6.AllowDrop = true;
			this._txtDisplayLabel_6.Location = new System.Drawing.Point(217, 44);
			this._txtDisplayLabel_6.Name = "_txtDisplayLabel_6";
			this._txtDisplayLabel_6.Size = new System.Drawing.Size(201, 19);
			this._txtDisplayLabel_6.TabIndex = 40;
			// 
			// _txtDisplayLabel_0
			// 
			this._txtDisplayLabel_0.AllowDrop = true;
			this._txtDisplayLabel_0.Location = new System.Drawing.Point(114, 44);
			this._txtDisplayLabel_0.Name = "_txtDisplayLabel_0";
			this._txtDisplayLabel_0.Size = new System.Drawing.Size(101, 19);
			this._txtDisplayLabel_0.TabIndex = 41;
			// 
			// _Line1_1
			// 
			this._Line1_1.AllowDrop = true;
			this._Line1_1.BackColor = System.Drawing.SystemColors.WindowText;
			this._Line1_1.Enabled = false;
			this._Line1_1.Location = new System.Drawing.Point(-28, 78);
			this._Line1_1.Name = "_Line1_1";
			this._Line1_1.Size = new System.Drawing.Size(828, 1);
			this._Line1_1.Visible = true;
			// 
			// frmPayEmployeeLeave
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.ClientSize = new System.Drawing.Size(688, 362);
			this.Controls.Add(this.cntMasterDetails);
			this.Controls.Add(this._lblSystemComponents_1);
			this.Controls.Add(this._lblCommonLabel_2);
			this.Controls.Add(this._txtDisplayLabel_6);
			this.Controls.Add(this._txtDisplayLabel_0);
			this.Controls.Add(this._Line1_1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			//this.Icon = (System.Drawing.Icon) resources.GetObject("frmPayEmployeeLeave.Icon");
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(202, 155);
			this.MaximizeBox = true;
			this.MinimizeBox = true;
			this.Name = "frmPayEmployeeLeave";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Employee Leave";
			// this.Activated += new System.EventHandler(this.Form_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
			// this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
			//((System.ComponentModel.ISupportInitialize) this.cntMasterDetails).EndInit();
			this.cntMasterDetails.ResumeLayout(false);
			this.fraFixedLeaveInfo.ResumeLayout(false);
			this.cmbMastersList.ResumeLayout(false);
			this.Frame1.ResumeLayout(false);
			this.grdVoucherDetails.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		// 
		void InitializetxtDisplayLabel()
		{
			this.txtDisplayLabel = new System.Windows.Forms.Label[8];
			this.txtDisplayLabel[7] = _txtDisplayLabel_7;
			this.txtDisplayLabel[5] = _txtDisplayLabel_5;
			this.txtDisplayLabel[4] = _txtDisplayLabel_4;
			this.txtDisplayLabel[3] = _txtDisplayLabel_3;
			this.txtDisplayLabel[2] = _txtDisplayLabel_2;
			this.txtDisplayLabel[1] = _txtDisplayLabel_1;
			this.txtDisplayLabel[6] = _txtDisplayLabel_6;
			this.txtDisplayLabel[0] = _txtDisplayLabel_0;
		}
		void InitializetxtCommonNumber()
		{
			this.txtCommonNumber = new System.Windows.Forms.TextBox[8];
			this.txtCommonNumber[0] = _txtCommonNumber_0;
			this.txtCommonNumber[6] = _txtCommonNumber_6;
			this.txtCommonNumber[1] = _txtCommonNumber_1;
			this.txtCommonNumber[2] = _txtCommonNumber_2;
			this.txtCommonNumber[4] = _txtCommonNumber_4;
			this.txtCommonNumber[5] = _txtCommonNumber_5;
			this.txtCommonNumber[3] = _txtCommonNumber_3;
			this.txtCommonNumber[7] = _txtCommonNumber_7;
		}
		void InitializetxtCommon()
		{
			this.txtCommon = new System.Windows.Forms.TextBox[8];
			this.txtCommon[7] = _txtCommon_7;
		}
		void InitializelblSystemComponents()
		{
			this.lblSystemComponents = new System.Windows.Forms.Label[2];
			this.lblSystemComponents[1] = _lblSystemComponents_1;
		}
		void InitializelblCommonLabel()
		{
			this.lblCommonLabel = new System.Windows.Forms.Label[3];
			this.lblCommonLabel[2] = _lblCommonLabel_2;
		}
		void InitializelblCommon()
		{
			this.lblCommon = new System.Windows.Forms.Label[20];
			this.lblCommon[10] = _lblCommon_10;
			this.lblCommon[9] = _lblCommon_9;
			this.lblCommon[1] = _lblCommon_1;
			this.lblCommon[3] = _lblCommon_3;
			this.lblCommon[4] = _lblCommon_4;
			this.lblCommon[5] = _lblCommon_5;
			this.lblCommon[6] = _lblCommon_6;
			this.lblCommon[7] = _lblCommon_7;
			this.lblCommon[15] = _lblCommon_15;
			this.lblCommon[16] = _lblCommon_16;
			this.lblCommon[17] = _lblCommon_17;
			this.lblCommon[2] = _lblCommon_2;
			this.lblCommon[12] = _lblCommon_12;
			this.lblCommon[19] = _lblCommon_19;
			this.lblCommon[0] = _lblCommon_0;
			this.lblCommon[8] = _lblCommon_8;
			this.lblCommon[11] = _lblCommon_11;
		}
		void InitializeLine1()
		{
			this.Line1 = new System.Windows.Forms.Label[2];
			this.Line1[1] = _Line1_1;
		}
		void InitializeCmbCommon()
		{
			this.CmbCommon = new System.Windows.Forms.ComboBox[2];
			this.CmbCommon[0] = _CmbCommon_0;
			this.CmbCommon[1] = _CmbCommon_1;
		}
		#endregion
	}
}//ENDSHERE
