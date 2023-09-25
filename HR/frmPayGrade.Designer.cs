
namespace Xtreme
{
	partial class frmPayGrade
	{

		#region "Upgrade Support "
		private static frmPayGrade m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmPayGrade DefInstance
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
		public static frmPayGrade CreateInstance()
		{
			frmPayGrade theInstance = new frmPayGrade();
			
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
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "txtComment", "_lblCommon_2", "_lblCommon_12", "_CmbCommon_0", "_CmbCommon_1", "Frame2", "_lblCommon_8", "_lblCommon_11", "_txtCommonNumber_3", "_txtCommonNumber_2", "Frame1", "_lblCommon_10", "_lblCommon_9", "_txtCommonNumber_1", "_txtCommonNumber_0", "fraFixedLeaveInfo", "_lblCommon_0", "_txtCommon_0", "frmIndemnity", "Column_0_cmbMastersList", "Column_1_cmbMastersList", "cmbMastersList", "_lblCommon_5", "_lblCommon_6", "_txtCommonNumber_5", "_txtCommonNumber_7", "Frame4", "_lblCommon_3", "_lblCommon_4", "_txtCommonNumber_4", "_txtCommonNumber_6", "Frame3", "Column_0_grdVoucherDetails", "Column_1_grdVoucherDetails", "grdVoucherDetails", "_lblCommon_1", "_txtCommon_7", "_lblCommon_7", "_CmbCommon_2", "_lblCommon_13", "_CmbCommon_3", "frmLeaveDet", "Column_0_grdVoucherDetailsFS", "Column_1_grdVoucherDetailsFS", "grdVoucherDetailsFS", "Column_0_cmbMastersListFS", "Column_1_cmbMastersListFS", "cmbMastersListFS", "frmFixedSal", "tabEmployee", "txtGradeNo", "lblLNatName", "txtLGradeName", "lblANatName", "txtAGradeName", "lblComments", "lblNatNo", "_lblCommonLabel_2", "txtJobTypeName", "txtJobTypeNo", "_lblCommonLabel_13", "_lblCommonLabel_0", "_lblCommonLabel_1", "_lblCommonLabel_3", "txtNMin", "txtNMid", "txtNMax", "Line1", "CmbCommon", "lblCommon", "lblCommonLabel", "txtCommon", "txtCommonNumber"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public System.Windows.Forms.TextBox txtComment;
		private System.Windows.Forms.Label _lblCommon_2;
		private System.Windows.Forms.Label _lblCommon_12;
		private System.Windows.Forms.ComboBox _CmbCommon_0;
		private System.Windows.Forms.ComboBox _CmbCommon_1;
		public System.Windows.Forms.GroupBox Frame2;
		private System.Windows.Forms.Label _lblCommon_8;
		private System.Windows.Forms.Label _lblCommon_11;
		private System.Windows.Forms.TextBox _txtCommonNumber_3;
		private System.Windows.Forms.TextBox _txtCommonNumber_2;
		public System.Windows.Forms.GroupBox Frame1;
		private System.Windows.Forms.Label _lblCommon_10;
		private System.Windows.Forms.Label _lblCommon_9;
		private System.Windows.Forms.TextBox _txtCommonNumber_1;
		private System.Windows.Forms.TextBox _txtCommonNumber_0;
		public System.Windows.Forms.GroupBox fraFixedLeaveInfo;
		private System.Windows.Forms.Label _lblCommon_0;
		private System.Windows.Forms.TextBox _txtCommon_0;
		public System.Windows.Forms.Panel frmIndemnity;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_0_cmbMastersList;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_1_cmbMastersList;
		public C1.Win.C1TrueDBGrid.C1TrueDBDropdown cmbMastersList;
		private System.Windows.Forms.Label _lblCommon_5;
		private System.Windows.Forms.Label _lblCommon_6;
		private System.Windows.Forms.TextBox _txtCommonNumber_5;
		private System.Windows.Forms.TextBox _txtCommonNumber_7;
		public System.Windows.Forms.GroupBox Frame4;
		private System.Windows.Forms.Label _lblCommon_3;
		private System.Windows.Forms.Label _lblCommon_4;
		private System.Windows.Forms.TextBox _txtCommonNumber_4;
		private System.Windows.Forms.TextBox _txtCommonNumber_6;
		public System.Windows.Forms.GroupBox Frame3;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_0_grdVoucherDetails;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_1_grdVoucherDetails;
		public C1.Win.C1TrueDBGrid.C1TrueDBGrid grdVoucherDetails;
		private System.Windows.Forms.Label _lblCommon_1;
		private System.Windows.Forms.TextBox _txtCommon_7;
		private System.Windows.Forms.Label _lblCommon_7;
		private System.Windows.Forms.ComboBox _CmbCommon_2;
		private System.Windows.Forms.Label _lblCommon_13;
		private System.Windows.Forms.ComboBox _CmbCommon_3;
		public System.Windows.Forms.Panel frmLeaveDet;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_0_grdVoucherDetailsFS;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_1_grdVoucherDetailsFS;
		public C1.Win.C1TrueDBGrid.C1TrueDBGrid grdVoucherDetailsFS;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_0_cmbMastersListFS;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_1_cmbMastersListFS;
		public C1.Win.C1TrueDBGrid.C1TrueDBDropdown cmbMastersListFS;
		public System.Windows.Forms.Panel frmFixedSal;
		public AxC1SizerLib.AxC1Tab tabEmployee;
		public System.Windows.Forms.TextBox txtGradeNo;
		public System.Windows.Forms.Label lblLNatName;
		public System.Windows.Forms.TextBox txtLGradeName;
		public System.Windows.Forms.Label lblANatName;
		public System.Windows.Forms.TextBox txtAGradeName;
		public System.Windows.Forms.Label lblComments;
		public System.Windows.Forms.Label lblNatNo;
		private System.Windows.Forms.Label _lblCommonLabel_2;
		public System.Windows.Forms.Label txtJobTypeName;
		public System.Windows.Forms.TextBox txtJobTypeNo;
		private System.Windows.Forms.Label _lblCommonLabel_13;
		private System.Windows.Forms.Label _lblCommonLabel_0;
		private System.Windows.Forms.Label _lblCommonLabel_1;
		private System.Windows.Forms.Label _lblCommonLabel_3;
		public System.Windows.Forms.TextBox txtNMin;
		public System.Windows.Forms.TextBox txtNMid;
		public System.Windows.Forms.TextBox txtNMax;
		public System.Windows.Forms.Label Line1;
		public System.Windows.Forms.ComboBox[] CmbCommon = new System.Windows.Forms.ComboBox[4];
		public System.Windows.Forms.Label[] lblCommon = new System.Windows.Forms.Label[14];
		public System.Windows.Forms.Label[] lblCommonLabel = new System.Windows.Forms.Label[14];
		public System.Windows.Forms.TextBox[] txtCommon = new System.Windows.Forms.TextBox[8];
		public System.Windows.Forms.TextBox[] txtCommonNumber = new System.Windows.Forms.TextBox[8];
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPayGrade));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this.txtComment = new System.Windows.Forms.TextBox();
			this.tabEmployee = new AxC1SizerLib.AxC1Tab();
			this.frmIndemnity = new System.Windows.Forms.Panel();
			this.Frame2 = new System.Windows.Forms.GroupBox();
			this._lblCommon_2 = new System.Windows.Forms.Label();
			this._lblCommon_12 = new System.Windows.Forms.Label();
			this._CmbCommon_0 = new System.Windows.Forms.ComboBox();
			this._CmbCommon_1 = new System.Windows.Forms.ComboBox();
			this.Frame1 = new System.Windows.Forms.GroupBox();
			this._lblCommon_8 = new System.Windows.Forms.Label();
			this._lblCommon_11 = new System.Windows.Forms.Label();
			this._txtCommonNumber_3 = new System.Windows.Forms.TextBox();
			this._txtCommonNumber_2 = new System.Windows.Forms.TextBox();
			this.fraFixedLeaveInfo = new System.Windows.Forms.GroupBox();
			this._lblCommon_10 = new System.Windows.Forms.Label();
			this._lblCommon_9 = new System.Windows.Forms.Label();
			this._txtCommonNumber_1 = new System.Windows.Forms.TextBox();
			this._txtCommonNumber_0 = new System.Windows.Forms.TextBox();
			this._lblCommon_0 = new System.Windows.Forms.Label();
			this._txtCommon_0 = new System.Windows.Forms.TextBox();
			this.frmLeaveDet = new System.Windows.Forms.Panel();
			this.cmbMastersList = new C1.Win.C1TrueDBGrid.C1TrueDBDropdown();
			this.Column_0_cmbMastersList = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.Column_1_cmbMastersList = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.Frame4 = new System.Windows.Forms.GroupBox();
			this._lblCommon_5 = new System.Windows.Forms.Label();
			this._lblCommon_6 = new System.Windows.Forms.Label();
			this._txtCommonNumber_5 = new System.Windows.Forms.TextBox();
			this._txtCommonNumber_7 = new System.Windows.Forms.TextBox();
			this.Frame3 = new System.Windows.Forms.GroupBox();
			this._lblCommon_3 = new System.Windows.Forms.Label();
			this._lblCommon_4 = new System.Windows.Forms.Label();
			this._txtCommonNumber_4 = new System.Windows.Forms.TextBox();
			this._txtCommonNumber_6 = new System.Windows.Forms.TextBox();
			this.grdVoucherDetails = new C1.Win.C1TrueDBGrid.C1TrueDBGrid();
			this.Column_0_grdVoucherDetails = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.Column_1_grdVoucherDetails = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this._lblCommon_1 = new System.Windows.Forms.Label();
			this._txtCommon_7 = new System.Windows.Forms.TextBox();
			this._lblCommon_7 = new System.Windows.Forms.Label();
			this._CmbCommon_2 = new System.Windows.Forms.ComboBox();
			this._lblCommon_13 = new System.Windows.Forms.Label();
			this._CmbCommon_3 = new System.Windows.Forms.ComboBox();
			this.frmFixedSal = new System.Windows.Forms.Panel();
			this.grdVoucherDetailsFS = new C1.Win.C1TrueDBGrid.C1TrueDBGrid();
			this.Column_0_grdVoucherDetailsFS = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.Column_1_grdVoucherDetailsFS = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.cmbMastersListFS = new C1.Win.C1TrueDBGrid.C1TrueDBDropdown();
			this.Column_0_cmbMastersListFS = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.Column_1_cmbMastersListFS = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.txtGradeNo = new System.Windows.Forms.TextBox();
			this.lblLNatName = new System.Windows.Forms.Label();
			this.txtLGradeName = new System.Windows.Forms.TextBox();
			this.lblANatName = new System.Windows.Forms.Label();
			this.txtAGradeName = new System.Windows.Forms.TextBox();
			this.lblComments = new System.Windows.Forms.Label();
			this.lblNatNo = new System.Windows.Forms.Label();
			this._lblCommonLabel_2 = new System.Windows.Forms.Label();
			this.txtJobTypeName = new System.Windows.Forms.Label();
			this.txtJobTypeNo = new System.Windows.Forms.TextBox();
			this._lblCommonLabel_13 = new System.Windows.Forms.Label();
			this._lblCommonLabel_0 = new System.Windows.Forms.Label();
			this._lblCommonLabel_1 = new System.Windows.Forms.Label();
			this._lblCommonLabel_3 = new System.Windows.Forms.Label();
			this.txtNMin = new System.Windows.Forms.TextBox();
			this.txtNMid = new System.Windows.Forms.TextBox();
			this.txtNMax = new System.Windows.Forms.TextBox();
			this.Line1 = new System.Windows.Forms.Label();
			// //((System.ComponentModel.ISupportInitialize) this.tabEmployee).BeginInit();
			this.tabEmployee.SuspendLayout();
			this.frmIndemnity.SuspendLayout();
			this.Frame2.SuspendLayout();
			this.Frame1.SuspendLayout();
			this.fraFixedLeaveInfo.SuspendLayout();
			this.frmLeaveDet.SuspendLayout();
			this.cmbMastersList.SuspendLayout();
			this.Frame4.SuspendLayout();
			this.Frame3.SuspendLayout();
			this.grdVoucherDetails.SuspendLayout();
			this.frmFixedSal.SuspendLayout();
			this.grdVoucherDetailsFS.SuspendLayout();
			this.cmbMastersListFS.SuspendLayout();
			this.SuspendLayout();
			// 
			// txtComment
			// 
			this.txtComment.AcceptsReturn = true;
			this.txtComment.AllowDrop = true;
			this.txtComment.BackColor = System.Drawing.SystemColors.Window;
			this.txtComment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtComment.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtComment.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtComment.Location = new System.Drawing.Point(150, 152);
			this.txtComment.MaxLength = 100;
			this.txtComment.Multiline = true;
			this.txtComment.Name = "txtComment";
			this.txtComment.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtComment.Size = new System.Drawing.Size(304, 59);
			this.txtComment.TabIndex = 41;
			// 
			// tabEmployee
			// 
			this.tabEmployee.Align = C1SizerLib.AlignSettings.asNone;
			this.tabEmployee.AllowDrop = true;
			this.tabEmployee.Controls.Add(this.frmIndemnity);
			this.tabEmployee.Controls.Add(this.frmLeaveDet);
			this.tabEmployee.Controls.Add(this.frmFixedSal);
			this.tabEmployee.Location = new System.Drawing.Point(2, 245);
			this.tabEmployee.Name = "tabEmployee";
			("tabEmployee.OcxState");
			this.tabEmployee.Size = new System.Drawing.Size(605, 285);
			this.tabEmployee.TabIndex = 0;
			// 
			// frmIndemnity
			// 
			this.frmIndemnity.AllowDrop = true;
			this.frmIndemnity.BackColor = System.Drawing.Color.FromArgb(237, 231, 235);
			this.frmIndemnity.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.frmIndemnity.Controls.Add(this.Frame2);
			this.frmIndemnity.Controls.Add(this.Frame1);
			this.frmIndemnity.Controls.Add(this.fraFixedLeaveInfo);
			this.frmIndemnity.Controls.Add(this._lblCommon_0);
			this.frmIndemnity.Controls.Add(this._txtCommon_0);
			this.frmIndemnity.Enabled = true;
			this.frmIndemnity.ForeColor = System.Drawing.SystemColors.ControlText;
			this.frmIndemnity.Location = new System.Drawing.Point(666, 23);
			this.frmIndemnity.Name = "frmIndemnity";
			this.frmIndemnity.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.frmIndemnity.Size = new System.Drawing.Size(603, 261);
			this.frmIndemnity.TabIndex = 19;
			this.frmIndemnity.Visible = true;
			// 
			// Frame2
			// 
			this.Frame2.AllowDrop = true;
			this.Frame2.BackColor = System.Drawing.Color.FromArgb(237, 231, 235);
			this.Frame2.Controls.Add(this._lblCommon_2);
			this.Frame2.Controls.Add(this._lblCommon_12);
			this.Frame2.Controls.Add(this._CmbCommon_0);
			this.Frame2.Controls.Add(this._CmbCommon_1);
			this.Frame2.Enabled = true;
			this.Frame2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 178);
			this.Frame2.ForeColor = System.Drawing.Color.FromArgb(53, 91, 225);
			this.Frame2.Location = new System.Drawing.Point(8, 132);
			this.Frame2.Name = "Frame2";
			this.Frame2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Frame2.Size = new System.Drawing.Size(279, 73);
			this.Frame2.TabIndex = 28;
			this.Frame2.Text = "Deduct Days Setting";
			this.Frame2.Visible = true;
			// 
			// _lblCommon_2
			// 
			this._lblCommon_2.AllowDrop = true;
			this._lblCommon_2.BackColor = System.Drawing.Color.FromArgb(237, 231, 235);
			this._lblCommon_2.Text = "Deduct Paid Days";
			this._lblCommon_2.Location = new System.Drawing.Point(6, 22);
			// // this._lblCommon_2.mLabelId = 1089;
			this._lblCommon_2.Name = "_lblCommon_2";
			this._lblCommon_2.Size = new System.Drawing.Size(84, 13);
			this._lblCommon_2.TabIndex = 29;
			// 
			// _lblCommon_12
			// 
			this._lblCommon_12.AllowDrop = true;
			this._lblCommon_12.BackColor = System.Drawing.Color.FromArgb(237, 231, 235);
			this._lblCommon_12.Text = "Deduct Unpaid Days";
			this._lblCommon_12.Location = new System.Drawing.Point(6, 48);
			// // this._lblCommon_12.mLabelId = 1095;
			this._lblCommon_12.Name = "_lblCommon_12";
			this._lblCommon_12.Size = new System.Drawing.Size(97, 13);
			this._lblCommon_12.TabIndex = 30;
			// 
			// _CmbCommon_0
			// 
			this._CmbCommon_0.AllowDrop = true;
			this._CmbCommon_0.Location = new System.Drawing.Point(154, 18);
			this._CmbCommon_0.Name = "_CmbCommon_0";
			this._CmbCommon_0.Size = new System.Drawing.Size(55, 21);
			this._CmbCommon_0.TabIndex = 8;
			// 
			// _CmbCommon_1
			// 
			this._CmbCommon_1.AllowDrop = true;
			this._CmbCommon_1.Location = new System.Drawing.Point(154, 44);
			this._CmbCommon_1.Name = "_CmbCommon_1";
			this._CmbCommon_1.Size = new System.Drawing.Size(55, 21);
			this._CmbCommon_1.TabIndex = 9;
			// 
			// Frame1
			// 
			this.Frame1.AllowDrop = true;
			this.Frame1.BackColor = System.Drawing.Color.FromArgb(237, 231, 235);
			this.Frame1.Controls.Add(this._lblCommon_8);
			this.Frame1.Controls.Add(this._lblCommon_11);
			this.Frame1.Controls.Add(this._txtCommonNumber_3);
			this.Frame1.Controls.Add(this._txtCommonNumber_2);
			this.Frame1.Enabled = true;
			this.Frame1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 178);
			this.Frame1.ForeColor = System.Drawing.Color.FromArgb(53, 91, 225);
			this.Frame1.Location = new System.Drawing.Point(304, 56);
			this.Frame1.Name = "Frame1";
			this.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Frame1.Size = new System.Drawing.Size(281, 63);
			this.Frame1.TabIndex = 25;
			this.Frame1.Text = " After Switch Over Period ";
			this.Frame1.Visible = true;
			// 
			// _lblCommon_8
			// 
			this._lblCommon_8.AllowDrop = true;
			this._lblCommon_8.BackColor = System.Drawing.Color.FromArgb(237, 231, 235);
			this._lblCommon_8.Text = "Indemnity Days";
			this._lblCommon_8.Location = new System.Drawing.Point(10, 19);
			// // this._lblCommon_8.mLabelId = 1092;
			this._lblCommon_8.Name = "_lblCommon_8";
			this._lblCommon_8.Size = new System.Drawing.Size(75, 13);
			this._lblCommon_8.TabIndex = 26;
			// 
			// _lblCommon_11
			// 
			this._lblCommon_11.AllowDrop = true;
			this._lblCommon_11.BackColor = System.Drawing.Color.FromArgb(237, 231, 235);
			this._lblCommon_11.Text = "Working Days Per Month";
			this._lblCommon_11.Location = new System.Drawing.Point(10, 40);
			// // this._lblCommon_11.mLabelId = 1093;
			this._lblCommon_11.Name = "_lblCommon_11";
			this._lblCommon_11.Size = new System.Drawing.Size(118, 13);
			this._lblCommon_11.TabIndex = 27;
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
			this._txtCommonNumber_3.TabIndex = 7;
			this._txtCommonNumber_3.Text = "0.000";
			// 
			// _txtCommonNumber_2
			// 
			this._txtCommonNumber_2.AllowDrop = true;
			// this._txtCommonNumber_2.DisplayFormat = "####0.000###;;0.000;0.000";
			// this._txtCommonNumber_2.Format = "###########0.000";
			this._txtCommonNumber_2.Location = new System.Drawing.Point(164, 16);
			// this._txtCommonNumber_2.MaxValue = 2147483647;
			// this._txtCommonNumber_2.MinValue = 0;
			this._txtCommonNumber_2.Name = "_txtCommonNumber_2";
			this._txtCommonNumber_2.Size = new System.Drawing.Size(101, 19);
			this._txtCommonNumber_2.TabIndex = 6;
			this._txtCommonNumber_2.Text = "0.000";
			// 
			// fraFixedLeaveInfo
			// 
			this.fraFixedLeaveInfo.AllowDrop = true;
			this.fraFixedLeaveInfo.BackColor = System.Drawing.Color.FromArgb(237, 231, 235);
			this.fraFixedLeaveInfo.Controls.Add(this._lblCommon_10);
			this.fraFixedLeaveInfo.Controls.Add(this._lblCommon_9);
			this.fraFixedLeaveInfo.Controls.Add(this._txtCommonNumber_1);
			this.fraFixedLeaveInfo.Controls.Add(this._txtCommonNumber_0);
			this.fraFixedLeaveInfo.Enabled = true;
			this.fraFixedLeaveInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 178);
			this.fraFixedLeaveInfo.ForeColor = System.Drawing.Color.FromArgb(53, 91, 225);
			this.fraFixedLeaveInfo.Location = new System.Drawing.Point(6, 56);
			this.fraFixedLeaveInfo.Name = "fraFixedLeaveInfo";
			this.fraFixedLeaveInfo.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.fraFixedLeaveInfo.Size = new System.Drawing.Size(283, 63);
			this.fraFixedLeaveInfo.TabIndex = 22;
			this.fraFixedLeaveInfo.Text = " Before Switch Over Period ";
			this.fraFixedLeaveInfo.Visible = true;
			// 
			// _lblCommon_10
			// 
			this._lblCommon_10.AllowDrop = true;
			this._lblCommon_10.BackColor = System.Drawing.Color.FromArgb(237, 231, 235);
			this._lblCommon_10.Text = "Indemnity Days";
			this._lblCommon_10.Location = new System.Drawing.Point(10, 19);
			// // this._lblCommon_10.mLabelId = 1092;
			this._lblCommon_10.Name = "_lblCommon_10";
			this._lblCommon_10.Size = new System.Drawing.Size(75, 13);
			this._lblCommon_10.TabIndex = 23;
			// 
			// _lblCommon_9
			// 
			this._lblCommon_9.AllowDrop = true;
			this._lblCommon_9.BackColor = System.Drawing.Color.FromArgb(237, 231, 235);
			this._lblCommon_9.Text = "Working Days Per Month";
			this._lblCommon_9.Location = new System.Drawing.Point(10, 40);
			// // this._lblCommon_9.mLabelId = 1093;
			this._lblCommon_9.Name = "_lblCommon_9";
			this._lblCommon_9.Size = new System.Drawing.Size(118, 13);
			this._lblCommon_9.TabIndex = 24;
			// 
			// _txtCommonNumber_1
			// 
			this._txtCommonNumber_1.AllowDrop = true;
			// this._txtCommonNumber_1.DisplayFormat = "####0.000###;;0.000;0.000";
			// this._txtCommonNumber_1.Format = "###########0.000";
			this._txtCommonNumber_1.Location = new System.Drawing.Point(162, 37);
			// this._txtCommonNumber_1.MaxValue = 2147483647;
			// this._txtCommonNumber_1.MinValue = 0;
			this._txtCommonNumber_1.Name = "_txtCommonNumber_1";
			this._txtCommonNumber_1.Size = new System.Drawing.Size(101, 19);
			this._txtCommonNumber_1.TabIndex = 5;
			this._txtCommonNumber_1.Text = "0.000";
			// 
			// _txtCommonNumber_0
			// 
			this._txtCommonNumber_0.AllowDrop = true;
			// this._txtCommonNumber_0.DisplayFormat = "####0.000###;;0.000;0.000";
			// this._txtCommonNumber_0.Format = "###########0.000";
			this._txtCommonNumber_0.Location = new System.Drawing.Point(162, 16);
			// this._txtCommonNumber_0.MaxValue = 2147483647;
			// this._txtCommonNumber_0.MinValue = 0;
			this._txtCommonNumber_0.Name = "_txtCommonNumber_0";
			this._txtCommonNumber_0.Size = new System.Drawing.Size(101, 19);
			this._txtCommonNumber_0.TabIndex = 4;
			this._txtCommonNumber_0.Text = "0.000";
			// 
			// _lblCommon_0
			// 
			this._lblCommon_0.AllowDrop = true;
			this._lblCommon_0.BackColor = System.Drawing.Color.FromArgb(237, 231, 235);
			this._lblCommon_0.Text = "Indemnity Swich Over Period (Year)";
			this._lblCommon_0.Location = new System.Drawing.Point(8, 29);
			// // this._lblCommon_0.mLabelId = 1087;
			this._lblCommon_0.Name = "_lblCommon_0";
			this._lblCommon_0.Size = new System.Drawing.Size(171, 13);
			this._lblCommon_0.TabIndex = 21;
			// 
			// _txtCommon_0
			// 
			this._txtCommon_0.AllowDrop = true;
			this._txtCommon_0.BackColor = System.Drawing.Color.White;
			// this._txtCommon_0.bolNumericOnly = true;
			this._txtCommon_0.ForeColor = System.Drawing.Color.Black;
			this._txtCommon_0.Location = new System.Drawing.Point(188, 26);
			this._txtCommon_0.Name = "_txtCommon_0";
			this._txtCommon_0.Size = new System.Drawing.Size(101, 19);
			this._txtCommon_0.TabIndex = 3;
			this._txtCommon_0.Text = "";
			// this.this._txtCommon_0.Watermark = "";
			// 
			// frmLeaveDet
			// 
			this.frmLeaveDet.AllowDrop = true;
			this.frmLeaveDet.BackColor = System.Drawing.Color.FromArgb(237, 231, 235);
			this.frmLeaveDet.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.frmLeaveDet.Controls.Add(this.cmbMastersList);
			this.frmLeaveDet.Controls.Add(this.Frame4);
			this.frmLeaveDet.Controls.Add(this.Frame3);
			this.frmLeaveDet.Controls.Add(this.grdVoucherDetails);
			this.frmLeaveDet.Controls.Add(this._lblCommon_1);
			this.frmLeaveDet.Controls.Add(this._txtCommon_7);
			this.frmLeaveDet.Controls.Add(this._lblCommon_7);
			this.frmLeaveDet.Controls.Add(this._CmbCommon_2);
			this.frmLeaveDet.Controls.Add(this._lblCommon_13);
			this.frmLeaveDet.Controls.Add(this._CmbCommon_3);
			this.frmLeaveDet.Enabled = true;
			this.frmLeaveDet.ForeColor = System.Drawing.SystemColors.ControlText;
			this.frmLeaveDet.Location = new System.Drawing.Point(646, 23);
			this.frmLeaveDet.Name = "frmLeaveDet";
			this.frmLeaveDet.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.frmLeaveDet.Size = new System.Drawing.Size(603, 261);
			this.frmLeaveDet.TabIndex = 18;
			this.frmLeaveDet.Visible = true;
			// 
			// cmbMastersList
			// 
			this.cmbMastersList.AllowDrop = true;
			this.cmbMastersList.ColumnHeaders = true;
			this.cmbMastersList.Enabled = true;
			this.cmbMastersList.Location = new System.Drawing.Point(26, 52);
			this.cmbMastersList.Name = "cmbMastersList";
			this.cmbMastersList.Size = new System.Drawing.Size(69, 57);
			this.cmbMastersList.TabIndex = 38;
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
			// Frame4
			// 
			this.Frame4.AllowDrop = true;
			this.Frame4.BackColor = System.Drawing.Color.FromArgb(237, 231, 235);
			this.Frame4.Controls.Add(this._lblCommon_5);
			this.Frame4.Controls.Add(this._lblCommon_6);
			this.Frame4.Controls.Add(this._txtCommonNumber_5);
			this.Frame4.Controls.Add(this._txtCommonNumber_7);
			this.Frame4.Enabled = true;
			this.Frame4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 178);
			this.Frame4.ForeColor = System.Drawing.Color.FromArgb(53, 91, 225);
			this.Frame4.Location = new System.Drawing.Point(314, 160);
			this.Frame4.Name = "Frame4";
			this.Frame4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Frame4.Size = new System.Drawing.Size(281, 63);
			this.Frame4.TabIndex = 35;
			this.Frame4.Text = " After Switch Over Period ";
			this.Frame4.Visible = true;
			// 
			// _lblCommon_5
			// 
			this._lblCommon_5.AllowDrop = true;
			this._lblCommon_5.BackColor = System.Drawing.Color.FromArgb(237, 231, 235);
			this._lblCommon_5.Text = "Leave Days";
			this._lblCommon_5.Location = new System.Drawing.Point(10, 19);
			// // this._lblCommon_5.mLabelId = 369;
			this._lblCommon_5.Name = "_lblCommon_5";
			this._lblCommon_5.Size = new System.Drawing.Size(56, 13);
			this._lblCommon_5.TabIndex = 36;
			// 
			// _lblCommon_6
			// 
			this._lblCommon_6.AllowDrop = true;
			this._lblCommon_6.BackColor = System.Drawing.Color.FromArgb(237, 231, 235);
			this._lblCommon_6.Text = "Working Days Per Month";
			this._lblCommon_6.Location = new System.Drawing.Point(10, 40);
			// // this._lblCommon_6.mLabelId = 1093;
			this._lblCommon_6.Name = "_lblCommon_6";
			this._lblCommon_6.Size = new System.Drawing.Size(118, 13);
			this._lblCommon_6.TabIndex = 37;
			// 
			// _txtCommonNumber_5
			// 
			this._txtCommonNumber_5.AllowDrop = true;
			// this._txtCommonNumber_5.DisplayFormat = "####0.000###;;0.000;0.000";
			// this._txtCommonNumber_5.Format = "###########0.000";
			this._txtCommonNumber_5.Location = new System.Drawing.Point(164, 37);
			// this._txtCommonNumber_5.MaxValue = 2147483647;
			// this._txtCommonNumber_5.MinValue = 0;
			this._txtCommonNumber_5.Name = "_txtCommonNumber_5";
			this._txtCommonNumber_5.Size = new System.Drawing.Size(101, 19);
			this._txtCommonNumber_5.TabIndex = 14;
			this._txtCommonNumber_5.Text = "0.000";
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
			this._txtCommonNumber_7.TabIndex = 13;
			this._txtCommonNumber_7.Text = "0.000";
			// 
			// Frame3
			// 
			this.Frame3.AllowDrop = true;
			this.Frame3.BackColor = System.Drawing.Color.FromArgb(237, 231, 235);
			this.Frame3.Controls.Add(this._lblCommon_3);
			this.Frame3.Controls.Add(this._lblCommon_4);
			this.Frame3.Controls.Add(this._txtCommonNumber_4);
			this.Frame3.Controls.Add(this._txtCommonNumber_6);
			this.Frame3.Enabled = true;
			this.Frame3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 178);
			this.Frame3.ForeColor = System.Drawing.Color.FromArgb(53, 91, 225);
			this.Frame3.Location = new System.Drawing.Point(4, 160);
			this.Frame3.Name = "Frame3";
			this.Frame3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Frame3.Size = new System.Drawing.Size(281, 63);
			this.Frame3.TabIndex = 32;
			this.Frame3.Text = " Before Switch Over Period ";
			this.Frame3.Visible = true;
			// 
			// _lblCommon_3
			// 
			this._lblCommon_3.AllowDrop = true;
			this._lblCommon_3.BackColor = System.Drawing.Color.FromArgb(237, 231, 235);
			this._lblCommon_3.Text = "Leave Days";
			this._lblCommon_3.Location = new System.Drawing.Point(10, 19);
			// // this._lblCommon_3.mLabelId = 369;
			this._lblCommon_3.Name = "_lblCommon_3";
			this._lblCommon_3.Size = new System.Drawing.Size(56, 13);
			this._lblCommon_3.TabIndex = 33;
			// 
			// _lblCommon_4
			// 
			this._lblCommon_4.AllowDrop = true;
			this._lblCommon_4.BackColor = System.Drawing.Color.FromArgb(237, 231, 235);
			this._lblCommon_4.Text = "Working Days Per Month";
			this._lblCommon_4.Location = new System.Drawing.Point(10, 40);
			// // this._lblCommon_4.mLabelId = 1093;
			this._lblCommon_4.Name = "_lblCommon_4";
			this._lblCommon_4.Size = new System.Drawing.Size(118, 13);
			this._lblCommon_4.TabIndex = 34;
			// 
			// _txtCommonNumber_4
			// 
			this._txtCommonNumber_4.AllowDrop = true;
			// this._txtCommonNumber_4.DisplayFormat = "####0.000###;;0.000;0.000";
			// this._txtCommonNumber_4.Format = "###########0.000";
			this._txtCommonNumber_4.Location = new System.Drawing.Point(162, 37);
			// this._txtCommonNumber_4.MaxValue = 2147483647;
			// this._txtCommonNumber_4.MinValue = 0;
			this._txtCommonNumber_4.Name = "_txtCommonNumber_4";
			this._txtCommonNumber_4.Size = new System.Drawing.Size(101, 19);
			this._txtCommonNumber_4.TabIndex = 12;
			this._txtCommonNumber_4.Text = "0.000";
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
			this._txtCommonNumber_6.TabIndex = 11;
			this._txtCommonNumber_6.Text = "0.000";
			// 
			// grdVoucherDetails
			// 
			this.grdVoucherDetails.AllowDrop = true;
			this.grdVoucherDetails.BackColor = System.Drawing.Color.Silver;
			this.grdVoucherDetails.CellTipsWidth = 0;
			this.grdVoucherDetails.Location = new System.Drawing.Point(2, 2);
			this.grdVoucherDetails.Name = "grdVoucherDetails";
			this.grdVoucherDetails.RowDivider.Color = System.Drawing.Color.Silver;
			this.grdVoucherDetails.Size = new System.Drawing.Size(601, 122);
			this.grdVoucherDetails.TabIndex = 2;
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
			// _lblCommon_1
			// 
			this._lblCommon_1.AllowDrop = true;
			this._lblCommon_1.BackColor = System.Drawing.Color.FromArgb(237, 231, 235);
			this._lblCommon_1.Text = "Leave Swich Over Period (Years)";
			this._lblCommon_1.Location = new System.Drawing.Point(6, 138);
			// // this._lblCommon_1.mLabelId = 1098;
			this._lblCommon_1.Name = "_lblCommon_1";
			this._lblCommon_1.Size = new System.Drawing.Size(157, 13);
			this._lblCommon_1.TabIndex = 31;
			// 
			// _txtCommon_7
			// 
			this._txtCommon_7.AllowDrop = true;
			this._txtCommon_7.BackColor = System.Drawing.Color.White;
			// this._txtCommon_7.bolNumericOnly = true;
			this._txtCommon_7.ForeColor = System.Drawing.Color.Black;
			this._txtCommon_7.Location = new System.Drawing.Point(184, 136);
			this._txtCommon_7.MaxLength = 2;
			this._txtCommon_7.Name = "_txtCommon_7";
			this._txtCommon_7.Size = new System.Drawing.Size(101, 19);
			this._txtCommon_7.TabIndex = 10;
			this._txtCommon_7.Text = "";
			// this.this._txtCommon_7.Watermark = "";
			// 
			// _lblCommon_7
			// 
			this._lblCommon_7.AllowDrop = true;
			this._lblCommon_7.BackColor = System.Drawing.Color.FromArgb(237, 231, 235);
			this._lblCommon_7.Text = "Deduct Paid Days";
			this._lblCommon_7.Location = new System.Drawing.Point(14, 228);
			// // this._lblCommon_7.mLabelId = 1089;
			this._lblCommon_7.Name = "_lblCommon_7";
			this._lblCommon_7.Size = new System.Drawing.Size(84, 13);
			this._lblCommon_7.TabIndex = 39;
			// 
			// _CmbCommon_2
			// 
			this._CmbCommon_2.AllowDrop = true;
			this._CmbCommon_2.Location = new System.Drawing.Point(166, 224);
			this._CmbCommon_2.Name = "_CmbCommon_2";
			this._CmbCommon_2.Size = new System.Drawing.Size(55, 21);
			this._CmbCommon_2.TabIndex = 15;
			// 
			// _lblCommon_13
			// 
			this._lblCommon_13.AllowDrop = true;
			this._lblCommon_13.BackColor = System.Drawing.Color.FromArgb(237, 231, 235);
			this._lblCommon_13.Text = "Deduct Unpaid Days";
			this._lblCommon_13.Location = new System.Drawing.Point(326, 228);
			// // this._lblCommon_13.mLabelId = 1095;
			this._lblCommon_13.Name = "_lblCommon_13";
			this._lblCommon_13.Size = new System.Drawing.Size(97, 13);
			this._lblCommon_13.TabIndex = 40;
			// 
			// _CmbCommon_3
			// 
			this._CmbCommon_3.AllowDrop = true;
			this._CmbCommon_3.Location = new System.Drawing.Point(478, 224);
			this._CmbCommon_3.Name = "_CmbCommon_3";
			this._CmbCommon_3.Size = new System.Drawing.Size(55, 21);
			this._CmbCommon_3.TabIndex = 16;
			// 
			// frmFixedSal
			// 
			this.frmFixedSal.AllowDrop = true;
			this.frmFixedSal.BackColor = System.Drawing.Color.White;
			this.frmFixedSal.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.frmFixedSal.Controls.Add(this.grdVoucherDetailsFS);
			this.frmFixedSal.Controls.Add(this.cmbMastersListFS);
			this.frmFixedSal.Enabled = true;
			this.frmFixedSal.ForeColor = System.Drawing.SystemColors.ControlText;
			this.frmFixedSal.Location = new System.Drawing.Point(1, 23);
			this.frmFixedSal.Name = "frmFixedSal";
			this.frmFixedSal.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.frmFixedSal.Size = new System.Drawing.Size(603, 261);
			this.frmFixedSal.TabIndex = 17;
			this.frmFixedSal.Visible = true;
			// 
			// grdVoucherDetailsFS
			// 
			this.grdVoucherDetailsFS.AllowDrop = true;
			this.grdVoucherDetailsFS.BackColor = System.Drawing.Color.Silver;
			this.grdVoucherDetailsFS.CellTipsWidth = 0;
			this.grdVoucherDetailsFS.Location = new System.Drawing.Point(0, 0);
			this.grdVoucherDetailsFS.Name = "grdVoucherDetailsFS";
			this.grdVoucherDetailsFS.RowDivider.Color = System.Drawing.Color.Silver;
			this.grdVoucherDetailsFS.Size = new System.Drawing.Size(600, 259);
			this.grdVoucherDetailsFS.TabIndex = 1;
			this.grdVoucherDetailsFS.Columns.Add(this.Column_0_grdVoucherDetailsFS);
			this.grdVoucherDetailsFS.Columns.Add(this.Column_1_grdVoucherDetailsFS);
			this.grdVoucherDetailsFS.AfterColUpdate += new C1.Win.C1TrueDBGrid.ColEventHandler(this.grdVoucherDetailsFS_AfterColUpdate);
			this.grdVoucherDetailsFS.BeforeColEdit += new C1.Win.C1TrueDBGrid.BeforeColEditEventHandler(this.grdVoucherDetailsFS_BeforeColEdit);
			this.grdVoucherDetailsFS.GotFocus += new System.EventHandler(this.grdVoucherDetailsFS_GotFocus);
			// this.this.grdVoucherDetailsFS.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.grdVoucherDetailsFS_KeyPress);
			this.grdVoucherDetailsFS.MouseUp += new System.Windows.Forms.MouseEventHandler(this.grdVoucherDetailsFS_MouseUp);
			this.grdVoucherDetailsFS.RowColChange += new C1.Win.C1TrueDBGrid.RowColChangeEventHandler(this.grdVoucherDetailsFS_RowColChange);
			// 
			// Column_0_grdVoucherDetailsFS
			// 
			this.Column_0_grdVoucherDetailsFS.DataField = "";
			this.Column_0_grdVoucherDetailsFS.ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.Normal;
			// 
			// Column_1_grdVoucherDetailsFS
			// 
			this.Column_1_grdVoucherDetailsFS.DataField = "";
			this.Column_1_grdVoucherDetailsFS.ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.Normal;
			// 
			// cmbMastersListFS
			// 
			this.cmbMastersListFS.AllowDrop = true;
			this.cmbMastersListFS.ColumnHeaders = true;
			this.cmbMastersListFS.Enabled = true;
			this.cmbMastersListFS.Location = new System.Drawing.Point(44, 62);
			this.cmbMastersListFS.Name = "cmbMastersListFS";
			this.cmbMastersListFS.Size = new System.Drawing.Size(53, 37);
			this.cmbMastersListFS.TabIndex = 20;
			this.cmbMastersListFS.Columns.Add(this.Column_0_cmbMastersListFS);
			this.cmbMastersListFS.Columns.Add(this.Column_1_cmbMastersListFS);
			// 
			// Column_0_cmbMastersListFS
			// 
			this.Column_0_cmbMastersListFS.DataField = "";
			this.Column_0_cmbMastersListFS.ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.Normal;
			// 
			// Column_1_cmbMastersListFS
			// 
			this.Column_1_cmbMastersListFS.DataField = "";
			this.Column_1_cmbMastersListFS.ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.Normal;
			// 
			// txtGradeNo
			// 
			this.txtGradeNo.AllowDrop = true;
			this.txtGradeNo.BackColor = System.Drawing.Color.White;
			// this.txtGradeNo.bolNumericOnly = true;
			this.txtGradeNo.ForeColor = System.Drawing.Color.Black;
			this.txtGradeNo.Location = new System.Drawing.Point(150, 46);
			this.txtGradeNo.MaxLength = 15;
			// this.txtGradeNo.mDropDownType = System.Windows.Forms.TextBox.DropDownTypes.ddtNextNumber;
			this.txtGradeNo.Name = "txtGradeNo";
			// this.txtGradeNo.ShowButton = true;
			this.txtGradeNo.Size = new System.Drawing.Size(101, 19);
			this.txtGradeNo.TabIndex = 42;
			this.txtGradeNo.Text = "";
			// this.this.txtGradeNo.Watermark = "";
			// this.this.txtGradeNo.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtGradeNo_DropButtonClick);
			// 
			// lblLNatName
			// 
			this.lblLNatName.AllowDrop = true;
			this.lblLNatName.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblLNatName.Text = "Grade Name (English)";
			this.lblLNatName.Location = new System.Drawing.Point(12, 69);
			// // this.lblLNatName.mLabelId = 1122;
			this.lblLNatName.Name = "lblLNatName";
			this.lblLNatName.Size = new System.Drawing.Size(105, 14);
			this.lblLNatName.TabIndex = 43;
			// 
			// txtLGradeName
			// 
			this.txtLGradeName.AllowDrop = true;
			this.txtLGradeName.BackColor = System.Drawing.Color.White;
			this.txtLGradeName.ForeColor = System.Drawing.Color.Black;
			this.txtLGradeName.Location = new System.Drawing.Point(150, 67);
			this.txtLGradeName.MaxLength = 50;
			this.txtLGradeName.Name = "txtLGradeName";
			this.txtLGradeName.Size = new System.Drawing.Size(303, 19);
			this.txtLGradeName.TabIndex = 44;
			this.txtLGradeName.Text = "";
			// this.this.txtLGradeName.Watermark = "";
			// 
			// lblANatName
			// 
			this.lblANatName.AllowDrop = true;
			this.lblANatName.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblANatName.Text = "Grade Name (Arabic)";
			this.lblANatName.Location = new System.Drawing.Point(12, 90);
			// // this.lblANatName.mLabelId = 1123;
			this.lblANatName.Name = "lblANatName";
			this.lblANatName.Size = new System.Drawing.Size(103, 14);
			this.lblANatName.TabIndex = 45;
			// 
			// txtAGradeName
			// 
			this.txtAGradeName.AllowDrop = true;
			this.txtAGradeName.BackColor = System.Drawing.Color.White;
			this.txtAGradeName.ForeColor = System.Drawing.Color.Black;
			this.txtAGradeName.Location = new System.Drawing.Point(150, 88);
			// this.txtAGradeName.mArabicEnabled = true;
			this.txtAGradeName.MaxLength = 50;
			this.txtAGradeName.Name = "txtAGradeName";
			this.txtAGradeName.Size = new System.Drawing.Size(303, 19);
			this.txtAGradeName.TabIndex = 46;
			this.txtAGradeName.Text = "";
			// this.this.txtAGradeName.Watermark = "";
			// 
			// lblComments
			// 
			this.lblComments.AllowDrop = true;
			this.lblComments.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblComments.Text = "Comment";
			this.lblComments.Location = new System.Drawing.Point(12, 152);
			// // this.lblComments.mLabelId = 1851;
			this.lblComments.Name = "lblComments";
			this.lblComments.Size = new System.Drawing.Size(44, 14);
			this.lblComments.TabIndex = 47;
			// 
			// lblNatNo
			// 
			this.lblNatNo.AllowDrop = true;
			this.lblNatNo.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblNatNo.Text = "Grade Code";
			this.lblNatNo.Location = new System.Drawing.Point(12, 48);
			// // this.lblNatNo.mLabelId = 1061;
			this.lblNatNo.Name = "lblNatNo";
			this.lblNatNo.Size = new System.Drawing.Size(58, 14);
			this.lblNatNo.TabIndex = 48;
			// 
			// _lblCommonLabel_2
			// 
			this._lblCommonLabel_2.AllowDrop = true;
			this._lblCommonLabel_2.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_2.Text = "Job Type No";
			this._lblCommonLabel_2.Location = new System.Drawing.Point(12, 111);
			// // this._lblCommonLabel_2.mLabelId = 2225;
			this._lblCommonLabel_2.Name = "_lblCommonLabel_2";
			this._lblCommonLabel_2.Size = new System.Drawing.Size(60, 14);
			this._lblCommonLabel_2.TabIndex = 49;
			// 
			// txtJobTypeName
			// 
			this.txtJobTypeName.AllowDrop = true;
			this.txtJobTypeName.Location = new System.Drawing.Point(256, 109);
			this.txtJobTypeName.Name = "txtJobTypeName";
			this.txtJobTypeName.Size = new System.Drawing.Size(198, 19);
			this.txtJobTypeName.TabIndex = 50;
			this.txtJobTypeName.TabStop = false;
			// 
			// txtJobTypeNo
			// 
			this.txtJobTypeNo.AllowDrop = true;
			this.txtJobTypeNo.BackColor = System.Drawing.Color.White;
			// this.txtJobTypeNo.bolAllowDecimal = false;
			this.txtJobTypeNo.ForeColor = System.Drawing.Color.Black;
			this.txtJobTypeNo.Location = new System.Drawing.Point(149, 109);
			// this.txtJobTypeNo.mDropDownType = (System.Windows.Forms.TextBox.DropDownTypes) 0;
			this.txtJobTypeNo.Name = "txtJobTypeNo";
			// this.txtJobTypeNo.ShowButton = true;
			this.txtJobTypeNo.Size = new System.Drawing.Size(105, 19);
			this.txtJobTypeNo.TabIndex = 51;
			this.txtJobTypeNo.Text = "";
			// this.this.txtJobTypeNo.Watermark = "";
			// this.this.txtJobTypeNo.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtJobTypeNo_DropButtonClick);
			// this.txtJobTypeNo.Leave += new System.EventHandler(this.txtJobTypeNo_Leave);
			// 
			// _lblCommonLabel_13
			// 
			this._lblCommonLabel_13.AllowDrop = true;
			this._lblCommonLabel_13.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_13.Text = "Min";
			this._lblCommonLabel_13.Location = new System.Drawing.Point(151, 133);
			// // this._lblCommonLabel_13.mLabelId = 2227;
			this._lblCommonLabel_13.Name = "_lblCommonLabel_13";
			this._lblCommonLabel_13.Size = new System.Drawing.Size(16, 14);
			this._lblCommonLabel_13.TabIndex = 52;
			// 
			// _lblCommonLabel_0
			// 
			this._lblCommonLabel_0.AllowDrop = true;
			this._lblCommonLabel_0.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_0.Text = "Mid";
			this._lblCommonLabel_0.Location = new System.Drawing.Point(256, 133);
			// // this._lblCommonLabel_0.mLabelId = 2228;
			this._lblCommonLabel_0.Name = "_lblCommonLabel_0";
			this._lblCommonLabel_0.Size = new System.Drawing.Size(16, 14);
			this._lblCommonLabel_0.TabIndex = 53;
			// 
			// _lblCommonLabel_1
			// 
			this._lblCommonLabel_1.AllowDrop = true;
			this._lblCommonLabel_1.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_1.Text = "Max";
			this._lblCommonLabel_1.Location = new System.Drawing.Point(355, 133);
			// // this._lblCommonLabel_1.mLabelId = 2229;
			this._lblCommonLabel_1.Name = "_lblCommonLabel_1";
			this._lblCommonLabel_1.Size = new System.Drawing.Size(20, 14);
			this._lblCommonLabel_1.TabIndex = 54;
			// 
			// _lblCommonLabel_3
			// 
			this._lblCommonLabel_3.AllowDrop = true;
			this._lblCommonLabel_3.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_3.Text = "Grade Salary";
			this._lblCommonLabel_3.Location = new System.Drawing.Point(13, 133);
			// // this._lblCommonLabel_3.mLabelId = 2226;
			this._lblCommonLabel_3.Name = "_lblCommonLabel_3";
			this._lblCommonLabel_3.Size = new System.Drawing.Size(64, 14);
			this._lblCommonLabel_3.TabIndex = 55;
			// 
			// txtNMin
			// 
			this.txtNMin.AllowDrop = true;
			this.txtNMin.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtNMin.Location = new System.Drawing.Point(175, 130);
			this.txtNMin.Name = "txtNMin";
			this.txtNMin.Size = new System.Drawing.Size(76, 19);
			this.txtNMin.TabIndex = 56;
			// 
			// txtNMid
			// 
			this.txtNMid.AllowDrop = true;
			this.txtNMid.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtNMid.Location = new System.Drawing.Point(277, 130);
			this.txtNMid.Name = "txtNMid";
			this.txtNMid.Size = new System.Drawing.Size(76, 19);
			this.txtNMid.TabIndex = 57;
			// 
			// txtNMax
			// 
			this.txtNMax.AllowDrop = true;
			this.txtNMax.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtNMax.Location = new System.Drawing.Point(379, 130);
			this.txtNMax.Name = "txtNMax";
			this.txtNMax.Size = new System.Drawing.Size(76, 19);
			this.txtNMax.TabIndex = 58;
			// 
			// Line1
			// 
			this.Line1.AllowDrop = true;
			this.Line1.BackColor = System.Drawing.SystemColors.WindowText;
			this.Line1.Enabled = false;
			this.Line1.Location = new System.Drawing.Point(0, 236);
			this.Line1.Name = "Line1";
			this.Line1.Size = new System.Drawing.Size(608, 1);
			this.Line1.Visible = true;
			// 
			// frmPayGrade
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.ClientSize = new System.Drawing.Size(1012, 626);
			this.Controls.Add(this.txtComment);
			this.Controls.Add(this.tabEmployee);
			this.Controls.Add(this.txtGradeNo);
			this.Controls.Add(this.lblLNatName);
			this.Controls.Add(this.txtLGradeName);
			this.Controls.Add(this.lblANatName);
			this.Controls.Add(this.txtAGradeName);
			this.Controls.Add(this.lblComments);
			this.Controls.Add(this.lblNatNo);
			this.Controls.Add(this._lblCommonLabel_2);
			this.Controls.Add(this.txtJobTypeName);
			this.Controls.Add(this.txtJobTypeNo);
			this.Controls.Add(this._lblCommonLabel_13);
			this.Controls.Add(this._lblCommonLabel_0);
			this.Controls.Add(this._lblCommonLabel_1);
			this.Controls.Add(this._lblCommonLabel_3);
			this.Controls.Add(this.txtNMin);
			this.Controls.Add(this.txtNMid);
			this.Controls.Add(this.txtNMax);
			this.Controls.Add(this.Line1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			//this.Icon = (System.Drawing.Icon) resources.GetObject("frmPayGrade.Icon");
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(219, 152);
			this.MaximizeBox = true;
			this.MinimizeBox = true;
			this.Name = "frmPayGrade";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Grade";
			// this.Activated += new System.EventHandler(this.frmPayGrade_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
			// this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
			//((System.ComponentModel.ISupportInitialize) this.tabEmployee).EndInit();
			this.tabEmployee.ResumeLayout(false);
			this.frmIndemnity.ResumeLayout(false);
			this.Frame2.ResumeLayout(false);
			this.Frame1.ResumeLayout(false);
			this.fraFixedLeaveInfo.ResumeLayout(false);
			this.frmLeaveDet.ResumeLayout(false);
			this.cmbMastersList.ResumeLayout(false);
			this.Frame4.ResumeLayout(false);
			this.Frame3.ResumeLayout(false);
			this.grdVoucherDetails.ResumeLayout(false);
			this.frmFixedSal.ResumeLayout(false);
			this.grdVoucherDetailsFS.ResumeLayout(false);
			this.cmbMastersListFS.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		// 
		void InitializetxtCommonNumber()
		{
			this.txtCommonNumber = new System.Windows.Forms.TextBox[8];
			this.txtCommonNumber[3] = _txtCommonNumber_3;
			this.txtCommonNumber[2] = _txtCommonNumber_2;
			this.txtCommonNumber[1] = _txtCommonNumber_1;
			this.txtCommonNumber[0] = _txtCommonNumber_0;
			this.txtCommonNumber[5] = _txtCommonNumber_5;
			this.txtCommonNumber[7] = _txtCommonNumber_7;
			this.txtCommonNumber[4] = _txtCommonNumber_4;
			this.txtCommonNumber[6] = _txtCommonNumber_6;
		}
		void InitializetxtCommon()
		{
			this.txtCommon = new System.Windows.Forms.TextBox[8];
			this.txtCommon[0] = _txtCommon_0;
			this.txtCommon[7] = _txtCommon_7;
		}
		void InitializelblCommonLabel()
		{
			this.lblCommonLabel = new System.Windows.Forms.Label[14];
			this.lblCommonLabel[2] = _lblCommonLabel_2;
			this.lblCommonLabel[13] = _lblCommonLabel_13;
			this.lblCommonLabel[0] = _lblCommonLabel_0;
			this.lblCommonLabel[1] = _lblCommonLabel_1;
			this.lblCommonLabel[3] = _lblCommonLabel_3;
		}
		void InitializelblCommon()
		{
			this.lblCommon = new System.Windows.Forms.Label[14];
			this.lblCommon[2] = _lblCommon_2;
			this.lblCommon[12] = _lblCommon_12;
			this.lblCommon[8] = _lblCommon_8;
			this.lblCommon[11] = _lblCommon_11;
			this.lblCommon[10] = _lblCommon_10;
			this.lblCommon[9] = _lblCommon_9;
			this.lblCommon[0] = _lblCommon_0;
			this.lblCommon[5] = _lblCommon_5;
			this.lblCommon[6] = _lblCommon_6;
			this.lblCommon[3] = _lblCommon_3;
			this.lblCommon[4] = _lblCommon_4;
			this.lblCommon[1] = _lblCommon_1;
			this.lblCommon[7] = _lblCommon_7;
			this.lblCommon[13] = _lblCommon_13;
		}
		void InitializeCmbCommon()
		{
			this.CmbCommon = new System.Windows.Forms.ComboBox[4];
			this.CmbCommon[0] = _CmbCommon_0;
			this.CmbCommon[1] = _CmbCommon_1;
			this.CmbCommon[2] = _CmbCommon_2;
			this.CmbCommon[3] = _CmbCommon_3;
		}
		#endregion
	}
}//ENDSHERE
