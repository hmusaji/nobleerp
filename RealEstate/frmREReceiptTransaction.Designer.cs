
namespace Xtreme
{
	partial class frmREReceiptTransaction
	{

		#region "Upgrade Support "
		private static frmREReceiptTransaction m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmREReceiptTransaction DefInstance
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
		public static frmREReceiptTransaction CreateInstance()
		{
			frmREReceiptTransaction theInstance = new frmREReceiptTransaction();
			
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
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "txtRemarks", "grdVoucherDetails", "chkContractCriteria", "_dateCommon_0", "_lblCommon_6", "_lblCommon_7", "_lblCommon_9", "_lblCommon_8", "_lblCommon_10", "_lblCommon_11", "_lblCommon_12", "_dateCommon_1", "_dateCommon_2", "_txtCommonDisplay_7", "_txtCommonDisplay_6", "_txtCommonDisplay_5", "_txtCommonDisplay_4", "_txtCommonDisplay_3", "_txtCommonDisplay_2", "_txtCommonDisplay_1", "_txtCommonDisplay_0", "fraContractDetails", "_txtCommon_0", "_lblCommon_0", "_lblCommon_1", "_lblCommon_4", "_txtCommon_2", "_lblCommon_2", "_txtNCommon_1", "_lblCommon_3", "_txtCommon_3", "_txtCommon_1", "_lblCommon_5", "fraTabPage0", "lblComments", "dateCommon", "lblCommon", "txtCommon", "txtCommonDisplay", "txtNCommon"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public System.Windows.Forms.TextBox txtRemarks;
		public C1.Win.C1TrueDBGrid.C1TrueDBGrid grdVoucherDetails;
		public System.Windows.Forms.CheckBox chkContractCriteria;
		private Syncfusion.WinForms.Input.SfDateTimeEdit _dateCommon_0;
		private System.Windows.Forms.Label _lblCommon_6;
		private System.Windows.Forms.Label _lblCommon_7;
		private System.Windows.Forms.Label _lblCommon_9;
		private System.Windows.Forms.Label _lblCommon_8;
		private System.Windows.Forms.Label _lblCommon_10;
		private System.Windows.Forms.Label _lblCommon_11;
		private System.Windows.Forms.Label _lblCommon_12;
		private Syncfusion.WinForms.Input.SfDateTimeEdit _dateCommon_1;
		private Syncfusion.WinForms.Input.SfDateTimeEdit _dateCommon_2;
		private System.Windows.Forms.Label _txtCommonDisplay_7;
		private System.Windows.Forms.Label _txtCommonDisplay_6;
		private System.Windows.Forms.Label _txtCommonDisplay_5;
		private System.Windows.Forms.Label _txtCommonDisplay_4;
		private System.Windows.Forms.Label _txtCommonDisplay_3;
		private System.Windows.Forms.Label _txtCommonDisplay_2;
		private System.Windows.Forms.Label _txtCommonDisplay_1;
		private System.Windows.Forms.Label _txtCommonDisplay_0;
		public System.Windows.Forms.GroupBox fraContractDetails;
		private System.Windows.Forms.TextBox _txtCommon_0;
		private System.Windows.Forms.Label _lblCommon_0;
		private System.Windows.Forms.Label _lblCommon_1;
		private System.Windows.Forms.Label _lblCommon_4;
		private System.Windows.Forms.TextBox _txtCommon_2;
		private System.Windows.Forms.Label _lblCommon_2;
		private System.Windows.Forms.TextBox _txtNCommon_1;
		private System.Windows.Forms.Label _lblCommon_3;
		private System.Windows.Forms.TextBox _txtCommon_3;
		private System.Windows.Forms.TextBox _txtCommon_1;
		private System.Windows.Forms.Label _lblCommon_5;
		public System.Windows.Forms.Panel fraTabPage0;
		public System.Windows.Forms.Label lblComments;
		public Syncfusion.WinForms.Input.SfDateTimeEdit[] dateCommon = new Syncfusion.WinForms.Input.SfDateTimeEdit[3];
		public System.Windows.Forms.Label[] lblCommon = new System.Windows.Forms.Label[13];
		public System.Windows.Forms.TextBox[] txtCommon = new System.Windows.Forms.TextBox[4];
		public System.Windows.Forms.Label[] txtCommonDisplay = new System.Windows.Forms.Label[8];
		public System.Windows.Forms.TextBox[] txtNCommon = new System.Windows.Forms.TextBox[2];
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmREReceiptTransaction));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this.txtRemarks = new System.Windows.Forms.TextBox();
			this.grdVoucherDetails = new C1.Win.C1TrueDBGrid.C1TrueDBGrid();
			this.fraTabPage0 = new System.Windows.Forms.Panel();
			this.chkContractCriteria = new System.Windows.Forms.CheckBox();
			this._dateCommon_0 = new Syncfusion.WinForms.Input.SfDateTimeEdit();
			this.fraContractDetails = new System.Windows.Forms.GroupBox();
			this._lblCommon_6 = new System.Windows.Forms.Label();
			this._lblCommon_7 = new System.Windows.Forms.Label();
			this._lblCommon_9 = new System.Windows.Forms.Label();
			this._lblCommon_8 = new System.Windows.Forms.Label();
			this._lblCommon_10 = new System.Windows.Forms.Label();
			this._lblCommon_11 = new System.Windows.Forms.Label();
			this._lblCommon_12 = new System.Windows.Forms.Label();
			this._dateCommon_1 = new Syncfusion.WinForms.Input.SfDateTimeEdit();
			this._dateCommon_2 = new Syncfusion.WinForms.Input.SfDateTimeEdit();
			this._txtCommonDisplay_7 = new System.Windows.Forms.Label();
			this._txtCommonDisplay_6 = new System.Windows.Forms.Label();
			this._txtCommonDisplay_5 = new System.Windows.Forms.Label();
			this._txtCommonDisplay_4 = new System.Windows.Forms.Label();
			this._txtCommonDisplay_3 = new System.Windows.Forms.Label();
			this._txtCommonDisplay_2 = new System.Windows.Forms.Label();
			this._txtCommonDisplay_1 = new System.Windows.Forms.Label();
			this._txtCommonDisplay_0 = new System.Windows.Forms.Label();
			this._txtCommon_0 = new System.Windows.Forms.TextBox();
			this._lblCommon_0 = new System.Windows.Forms.Label();
			this._lblCommon_1 = new System.Windows.Forms.Label();
			this._lblCommon_4 = new System.Windows.Forms.Label();
			this._txtCommon_2 = new System.Windows.Forms.TextBox();
			this._lblCommon_2 = new System.Windows.Forms.Label();
			this._txtNCommon_1 = new System.Windows.Forms.TextBox();
			this._lblCommon_3 = new System.Windows.Forms.Label();
			this._txtCommon_3 = new System.Windows.Forms.TextBox();
			this._txtCommon_1 = new System.Windows.Forms.TextBox();
			this._lblCommon_5 = new System.Windows.Forms.Label();
			this.lblComments = new System.Windows.Forms.Label();
			// //((System.ComponentModel.ISupportInitialize) this.fraTabPage0).BeginInit();
			//this.fraTabPage0.SuspendLayout();
			//this.fraContractDetails.SuspendLayout();
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
			this.txtRemarks.Location = new System.Drawing.Point(78, 376);
			this.txtRemarks.MaxLength = 250;
			this.txtRemarks.Multiline = true;
			this.txtRemarks.Name = "txtRemarks";
			this.txtRemarks.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtRemarks.Size = new System.Drawing.Size(613, 19);
			this.txtRemarks.TabIndex = 6;
			// 
			// grdVoucherDetails
			// 
			this.grdVoucherDetails.AllowDrop = true;
			this.grdVoucherDetails.BackColor = System.Drawing.Color.Silver;
			this.grdVoucherDetails.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.grdVoucherDetails.CellTipsWidth = 0;
			this.grdVoucherDetails.Location = new System.Drawing.Point(4, 194);
			this.grdVoucherDetails.Name = "grdVoucherDetails";
			this.grdVoucherDetails.RowDivider.Color = System.Drawing.Color.Silver;
			this.grdVoucherDetails.Size = new System.Drawing.Size(687, 174);
			this.grdVoucherDetails.TabIndex = 5;
			this.grdVoucherDetails.AfterColUpdate += new C1.Win.C1TrueDBGrid.ColEventHandler(this.grdVoucherDetails_AfterColUpdate);
			this.grdVoucherDetails.BeforeColUpdate += new C1.Win.C1TrueDBGrid.BeforeColUpdateEventHandler(this.grdVoucherDetails_BeforeColUpdate);
			// 
			// fraTabPage0
			// 
			this.fraTabPage0.AllowDrop = true;
			this.fraTabPage0.Controls.Add(this.chkContractCriteria);
			this.fraTabPage0.Controls.Add(this._dateCommon_0);
			this.fraTabPage0.Controls.Add(this.fraContractDetails);
			this.fraTabPage0.Controls.Add(this._txtCommon_0);
			this.fraTabPage0.Controls.Add(this._lblCommon_0);
			this.fraTabPage0.Controls.Add(this._lblCommon_1);
			this.fraTabPage0.Controls.Add(this._lblCommon_4);
			this.fraTabPage0.Controls.Add(this._txtCommon_2);
			this.fraTabPage0.Controls.Add(this._lblCommon_2);
			this.fraTabPage0.Controls.Add(this._txtNCommon_1);
			this.fraTabPage0.Controls.Add(this._lblCommon_3);
			this.fraTabPage0.Controls.Add(this._txtCommon_3);
			this.fraTabPage0.Controls.Add(this._txtCommon_1);
			this.fraTabPage0.Controls.Add(this._lblCommon_5);
			this.fraTabPage0.Location = new System.Drawing.Point(4, 44);
			this.fraTabPage0.Name = "fraTabPage0";
			//
			this.fraTabPage0.Size = new System.Drawing.Size(685, 144);
			this.fraTabPage0.TabIndex = 7;
			// 
			// chkContractCriteria
			// 
			this.chkContractCriteria.AllowDrop = true;
			this.chkContractCriteria.Appearance = System.Windows.Forms.Appearance.Normal;
			this.chkContractCriteria.BackColor = System.Drawing.Color.FromArgb(241, 244, 248);
			this.chkContractCriteria.CausesValidation = true;
			this.chkContractCriteria.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkContractCriteria.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this.chkContractCriteria.Enabled = true;
			this.chkContractCriteria.ForeColor = System.Drawing.SystemColors.ControlText;
			this.chkContractCriteria.Location = new System.Drawing.Point(212, 52);
			this.chkContractCriteria.Name = "chkContractCriteria";
			this.chkContractCriteria.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.chkContractCriteria.Size = new System.Drawing.Size(37, 19);
			this.chkContractCriteria.TabIndex = 26;
			this.chkContractCriteria.TabStop = true;
			this.chkContractCriteria.Text = "All";
			this.chkContractCriteria.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkContractCriteria.Visible = true;
			// 
			// _dateCommon_0
			// 
			this._dateCommon_0.AllowDrop = true;
			this._dateCommon_0.Location = new System.Drawing.Point(105, 31);
			// this._dateCommon_0.MaxDate = 2958465;
			// this._dateCommon_0.MinDate = 2;
			this._dateCommon_0.Name = "_dateCommon_0";
			this._dateCommon_0.Size = new System.Drawing.Size(101, 19);
			this._dateCommon_0.TabIndex = 0;
			this._dateCommon_0.Text = "05/07/2005";
			// this._dateCommon_0.Value = 38538;
			// 
			// fraContractDetails
			// 
			this.fraContractDetails.AllowDrop = true;
			this.fraContractDetails.BackColor = System.Drawing.Color.FromArgb(241, 244, 248);
			this.fraContractDetails.Controls.Add(this._lblCommon_6);
			this.fraContractDetails.Controls.Add(this._lblCommon_7);
			this.fraContractDetails.Controls.Add(this._lblCommon_9);
			this.fraContractDetails.Controls.Add(this._lblCommon_8);
			this.fraContractDetails.Controls.Add(this._lblCommon_10);
			this.fraContractDetails.Controls.Add(this._lblCommon_11);
			this.fraContractDetails.Controls.Add(this._lblCommon_12);
			this.fraContractDetails.Controls.Add(this._dateCommon_1);
			this.fraContractDetails.Controls.Add(this._dateCommon_2);
			this.fraContractDetails.Controls.Add(this._txtCommonDisplay_7);
			this.fraContractDetails.Controls.Add(this._txtCommonDisplay_6);
			this.fraContractDetails.Controls.Add(this._txtCommonDisplay_5);
			this.fraContractDetails.Controls.Add(this._txtCommonDisplay_4);
			this.fraContractDetails.Controls.Add(this._txtCommonDisplay_3);
			this.fraContractDetails.Controls.Add(this._txtCommonDisplay_2);
			this.fraContractDetails.Controls.Add(this._txtCommonDisplay_1);
			this.fraContractDetails.Controls.Add(this._txtCommonDisplay_0);
			this.fraContractDetails.Enabled = true;
			this.fraContractDetails.ForeColor = System.Drawing.Color.Black;
			this.fraContractDetails.Location = new System.Drawing.Point(260, 8);
			this.fraContractDetails.Name = "fraContractDetails";
			this.fraContractDetails.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.fraContractDetails.Size = new System.Drawing.Size(415, 127);
			this.fraContractDetails.TabIndex = 8;
			this.fraContractDetails.Text = " Contract Details ";
			this.fraContractDetails.Visible = true;
			// 
			// _lblCommon_6
			// 
			this._lblCommon_6.AllowDrop = true;
			this._lblCommon_6.BackColor = System.Drawing.Color.FromArgb(241, 244, 248);
			this._lblCommon_6.Text = "Tenant Code";
			this._lblCommon_6.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_6.Location = new System.Drawing.Point(8, 19);
			// // this._lblCommon_6.mLabelId = 1156;
			this._lblCommon_6.Name = "_lblCommon_6";
			this._lblCommon_6.Size = new System.Drawing.Size(62, 13);
			this._lblCommon_6.TabIndex = 9;
			// 
			// _lblCommon_7
			// 
			this._lblCommon_7.AllowDrop = true;
			this._lblCommon_7.BackColor = System.Drawing.Color.FromArgb(241, 244, 248);
			this._lblCommon_7.Text = "Pay. Method Code";
			this._lblCommon_7.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_7.Location = new System.Drawing.Point(8, 41);
			// // this._lblCommon_7.mLabelId = 1157;
			this._lblCommon_7.Name = "_lblCommon_7";
			this._lblCommon_7.Size = new System.Drawing.Size(88, 13);
			this._lblCommon_7.TabIndex = 10;
			// 
			// _lblCommon_9
			// 
			this._lblCommon_9.AllowDrop = true;
			this._lblCommon_9.BackColor = System.Drawing.Color.FromArgb(241, 244, 248);
			this._lblCommon_9.Text = "Contract Amount";
			this._lblCommon_9.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_9.Location = new System.Drawing.Point(8, 83);
			// // this._lblCommon_9.mLabelId = 1172;
			this._lblCommon_9.Name = "_lblCommon_9";
			this._lblCommon_9.Size = new System.Drawing.Size(79, 13);
			this._lblCommon_9.TabIndex = 11;
			// 
			// _lblCommon_8
			// 
			this._lblCommon_8.AllowDrop = true;
			this._lblCommon_8.BackColor = System.Drawing.Color.FromArgb(241, 244, 248);
			this._lblCommon_8.Text = "Starting Date";
			this._lblCommon_8.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_8.Location = new System.Drawing.Point(8, 104);
			// // this._lblCommon_8.mLabelId = 1160;
			this._lblCommon_8.Name = "_lblCommon_8";
			this._lblCommon_8.Size = new System.Drawing.Size(62, 13);
			this._lblCommon_8.TabIndex = 13;
			// 
			// _lblCommon_10
			// 
			this._lblCommon_10.AllowDrop = true;
			this._lblCommon_10.BackColor = System.Drawing.Color.FromArgb(241, 244, 248);
			this._lblCommon_10.Text = "Ending Date";
			this._lblCommon_10.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_10.Location = new System.Drawing.Point(218, 104);
			// // this._lblCommon_10.mLabelId = 1161;
			this._lblCommon_10.Name = "_lblCommon_10";
			this._lblCommon_10.Size = new System.Drawing.Size(59, 13);
			this._lblCommon_10.TabIndex = 14;
			// 
			// _lblCommon_11
			// 
			this._lblCommon_11.AllowDrop = true;
			this._lblCommon_11.BackColor = System.Drawing.Color.FromArgb(241, 244, 248);
			this._lblCommon_11.Text = "Status Code";
			this._lblCommon_11.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_11.Location = new System.Drawing.Point(8, 62);
			// // this._lblCommon_11.mLabelId = 1159;
			this._lblCommon_11.Name = "_lblCommon_11";
			this._lblCommon_11.Size = new System.Drawing.Size(58, 13);
			this._lblCommon_11.TabIndex = 22;
			// 
			// _lblCommon_12
			// 
			this._lblCommon_12.AllowDrop = true;
			this._lblCommon_12.BackColor = System.Drawing.Color.FromArgb(241, 244, 248);
			this._lblCommon_12.Text = "Unit No.";
			this._lblCommon_12.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_12.Location = new System.Drawing.Point(218, 83);
			this._lblCommon_12.Name = "_lblCommon_12";
			this._lblCommon_12.Size = new System.Drawing.Size(39, 13);
			this._lblCommon_12.TabIndex = 23;
			// 
			// _dateCommon_1
			// 
			this._dateCommon_1.AllowDrop = true;
			this._dateCommon_1.BackColor = System.Drawing.Color.FromArgb(239, 239, 239);
			// this._dateCommon_1.CheckDateRange = false;
			this._dateCommon_1.Enabled = false;
			this._dateCommon_1.Location = new System.Drawing.Point(104, 101);
			// this._dateCommon_1.MaxDate = 2958465;
			// this._dateCommon_1.MinDate = 2;
			this._dateCommon_1.Name = "_dateCommon_1";
			this._dateCommon_1.Size = new System.Drawing.Size(101, 19);
			this._dateCommon_1.TabIndex = 24;
			this._dateCommon_1.Text = "05/07/2005";
			// this._dateCommon_1.Value = 38538;
			// 
			// _dateCommon_2
			// 
			this._dateCommon_2.AllowDrop = true;
			this._dateCommon_2.BackColor = System.Drawing.Color.FromArgb(239, 239, 239);
			// this._dateCommon_2.CheckDateRange = false;
			this._dateCommon_2.Enabled = false;
			this._dateCommon_2.Location = new System.Drawing.Point(307, 101);
			// this._dateCommon_2.MaxDate = 2958465;
			// this._dateCommon_2.MinDate = 2;
			this._dateCommon_2.Name = "_dateCommon_2";
			this._dateCommon_2.Size = new System.Drawing.Size(101, 19);
			this._dateCommon_2.TabIndex = 25;
			this._dateCommon_2.Text = "05/07/2005";
			// this._dateCommon_2.Value = 38538;
			// 
			// _txtCommonDisplay_7
			// 
			// this._txtCommonDisplay_7.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
			this._txtCommonDisplay_7.AllowDrop = true;
			this._txtCommonDisplay_7.Location = new System.Drawing.Point(307, 80);
			this._txtCommonDisplay_7.Name = "_txtCommonDisplay_7";
			this._txtCommonDisplay_7.Size = new System.Drawing.Size(101, 19);
			this._txtCommonDisplay_7.TabIndex = 27;
			// 
			// _txtCommonDisplay_6
			// 
			this._txtCommonDisplay_6.AllowDrop = true;
			this._txtCommonDisplay_6.Location = new System.Drawing.Point(104, 59);
			this._txtCommonDisplay_6.Name = "_txtCommonDisplay_6";
			this._txtCommonDisplay_6.Size = new System.Drawing.Size(101, 19);
			this._txtCommonDisplay_6.TabIndex = 28;
			// 
			// _txtCommonDisplay_5
			// 
			this._txtCommonDisplay_5.AllowDrop = true;
			this._txtCommonDisplay_5.Location = new System.Drawing.Point(207, 59);
			this._txtCommonDisplay_5.Name = "_txtCommonDisplay_5";
			this._txtCommonDisplay_5.Size = new System.Drawing.Size(201, 19);
			this._txtCommonDisplay_5.TabIndex = 29;
			// 
			// _txtCommonDisplay_4
			// 
			// this._txtCommonDisplay_4.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
			this._txtCommonDisplay_4.AllowDrop = true;
			this._txtCommonDisplay_4.Location = new System.Drawing.Point(104, 80);
			this._txtCommonDisplay_4.Name = "_txtCommonDisplay_4";
			this._txtCommonDisplay_4.Size = new System.Drawing.Size(101, 19);
			this._txtCommonDisplay_4.TabIndex = 30;
			// 
			// _txtCommonDisplay_3
			// 
			this._txtCommonDisplay_3.AllowDrop = true;
			this._txtCommonDisplay_3.Location = new System.Drawing.Point(207, 38);
			this._txtCommonDisplay_3.Name = "_txtCommonDisplay_3";
			this._txtCommonDisplay_3.Size = new System.Drawing.Size(201, 19);
			this._txtCommonDisplay_3.TabIndex = 31;
			// 
			// _txtCommonDisplay_2
			// 
			this._txtCommonDisplay_2.AllowDrop = true;
			this._txtCommonDisplay_2.Location = new System.Drawing.Point(104, 38);
			this._txtCommonDisplay_2.Name = "_txtCommonDisplay_2";
			this._txtCommonDisplay_2.Size = new System.Drawing.Size(101, 19);
			this._txtCommonDisplay_2.TabIndex = 32;
			// 
			// _txtCommonDisplay_1
			// 
			this._txtCommonDisplay_1.AllowDrop = true;
			this._txtCommonDisplay_1.Location = new System.Drawing.Point(207, 17);
			this._txtCommonDisplay_1.Name = "_txtCommonDisplay_1";
			this._txtCommonDisplay_1.Size = new System.Drawing.Size(201, 19);
			this._txtCommonDisplay_1.TabIndex = 33;
			// 
			// _txtCommonDisplay_0
			// 
			this._txtCommonDisplay_0.AllowDrop = true;
			this._txtCommonDisplay_0.Location = new System.Drawing.Point(104, 17);
			this._txtCommonDisplay_0.Name = "_txtCommonDisplay_0";
			this._txtCommonDisplay_0.Size = new System.Drawing.Size(101, 19);
			this._txtCommonDisplay_0.TabIndex = 34;
			// 
			// _txtCommon_0
			// 
			this._txtCommon_0.AllowDrop = true;
			this._txtCommon_0.BackColor = System.Drawing.Color.FromArgb(239, 239, 239);
			this._txtCommon_0.Enabled = false;
			this._txtCommon_0.ForeColor = System.Drawing.Color.Black;
			this._txtCommon_0.Location = new System.Drawing.Point(105, 10);
			this._txtCommon_0.MaxLength = 15;
			// // = System.Windows.Forms.TextBox.DropDownTypes.ddtNextNumber;
			this._txtCommon_0.Name = "_txtCommon_0";
			this._txtCommon_0.Size = new System.Drawing.Size(101, 19);
			this._txtCommon_0.TabIndex = 15;
			this._txtCommon_0.Text = "";
			// this.// = "";
			// this.//this._txtCommon_0.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(//this.txtCommon_DropButtonClick);
			// this._txtCommon_0.Leave += new System.EventHandler(this.txtCommon_Leave);
			// 
			// _lblCommon_0
			// 
			this._lblCommon_0.AllowDrop = true;
			this._lblCommon_0.BackColor = System.Drawing.Color.FromArgb(241, 244, 248);
			this._lblCommon_0.Text = "Reciept No.";
			this._lblCommon_0.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_0.Location = new System.Drawing.Point(12, 12);
			// // this._lblCommon_0.mLabelId = 1216;
			this._lblCommon_0.Name = "_lblCommon_0";
			this._lblCommon_0.Size = new System.Drawing.Size(57, 13);
			this._lblCommon_0.TabIndex = 16;
			// 
			// _lblCommon_1
			// 
			this._lblCommon_1.AllowDrop = true;
			this._lblCommon_1.BackColor = System.Drawing.Color.FromArgb(241, 244, 248);
			this._lblCommon_1.Text = "Receipt Date";
			this._lblCommon_1.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_1.Location = new System.Drawing.Point(12, 34);
			// // this._lblCommon_1.mLabelId = 1217;
			this._lblCommon_1.Name = "_lblCommon_1";
			this._lblCommon_1.Size = new System.Drawing.Size(63, 13);
			this._lblCommon_1.TabIndex = 17;
			// 
			// _lblCommon_4
			// 
			this._lblCommon_4.AllowDrop = true;
			this._lblCommon_4.BackColor = System.Drawing.Color.FromArgb(241, 244, 248);
			this._lblCommon_4.Text = "Paid By";
			this._lblCommon_4.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_4.Location = new System.Drawing.Point(12, 118);
			// // this._lblCommon_4.mLabelId = 1219;
			this._lblCommon_4.Name = "_lblCommon_4";
			this._lblCommon_4.Size = new System.Drawing.Size(36, 13);
			this._lblCommon_4.TabIndex = 18;
			// 
			// _txtCommon_2
			// 
			this._txtCommon_2.AllowDrop = true;
			this._txtCommon_2.BackColor = System.Drawing.Color.White;
			this._txtCommon_2.ForeColor = System.Drawing.Color.Black;
			this._txtCommon_2.Location = new System.Drawing.Point(105, 115);
			this._txtCommon_2.MaxLength = 15;
			this._txtCommon_2.Name = "_txtCommon_2";
			this._txtCommon_2.Size = new System.Drawing.Size(101, 19);
			this._txtCommon_2.TabIndex = 4;
			this._txtCommon_2.Text = "";
			// this.// = "";
			// this.//this._txtCommon_2.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(//this.txtCommon_DropButtonClick);
			// this._txtCommon_2.Leave += new System.EventHandler(this.txtCommon_Leave);
			// 
			// _lblCommon_2
			// 
			this._lblCommon_2.AllowDrop = true;
			this._lblCommon_2.BackColor = System.Drawing.Color.FromArgb(241, 244, 248);
			this._lblCommon_2.Text = "Receipt Amount";
			this._lblCommon_2.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_2.Location = new System.Drawing.Point(12, 76);
			// // this._lblCommon_2.mLabelId = 1218;
			this._lblCommon_2.Name = "_lblCommon_2";
			this._lblCommon_2.Size = new System.Drawing.Size(76, 13);
			this._lblCommon_2.TabIndex = 19;
			// 
			// _txtNCommon_1
			// 
			this._txtNCommon_1.AllowDrop = true;
			// this._txtNCommon_1.DisplayFormat = "########0.000###;;0.000;0.000";
			// this._txtNCommon_1.Format = "###########0.000";
			this._txtNCommon_1.Location = new System.Drawing.Point(105, 73);
			// // = 2147483647;
			// // = 0;
			this._txtNCommon_1.Name = "_txtNCommon_1";
			this._txtNCommon_1.Size = new System.Drawing.Size(101, 19);
			this._txtNCommon_1.TabIndex = 2;
			this._txtNCommon_1.Text = "0.000";
			// this._txtNCommon_1.Leave += new System.EventHandler(this.txtNCommon_Leave);
			// 
			// _lblCommon_3
			// 
			this._lblCommon_3.AllowDrop = true;
			this._lblCommon_3.BackColor = System.Drawing.Color.FromArgb(241, 244, 248);
			this._lblCommon_3.Text = "Reference No.";
			this._lblCommon_3.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_3.Location = new System.Drawing.Point(12, 97);
			// // this._lblCommon_3.mLabelId = 1164;
			this._lblCommon_3.Name = "_lblCommon_3";
			this._lblCommon_3.Size = new System.Drawing.Size(70, 13);
			this._lblCommon_3.TabIndex = 20;
			// 
			// _txtCommon_3
			// 
			this._txtCommon_3.AllowDrop = true;
			this._txtCommon_3.BackColor = System.Drawing.Color.White;
			this._txtCommon_3.ForeColor = System.Drawing.Color.Black;
			this._txtCommon_3.Location = new System.Drawing.Point(105, 94);
			this._txtCommon_3.MaxLength = 15;
			// // = System.Windows.Forms.TextBox.DropDownTypes.ddtNextNumber;
			this._txtCommon_3.Name = "_txtCommon_3";
			this._txtCommon_3.Size = new System.Drawing.Size(101, 19);
			this._txtCommon_3.TabIndex = 3;
			this._txtCommon_3.Text = "";
			// this.// = "";
			// this.//this._txtCommon_3.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(//this.txtCommon_DropButtonClick);
			// this._txtCommon_3.Leave += new System.EventHandler(this.txtCommon_Leave);
			// 
			// _txtCommon_1
			// 
			this._txtCommon_1.AllowDrop = true;
			this._txtCommon_1.BackColor = System.Drawing.Color.White;
			// this._txtCommon_1.bolNumericOnly = true;
			this._txtCommon_1.ForeColor = System.Drawing.Color.Black;
			this._txtCommon_1.Location = new System.Drawing.Point(105, 52);
			this._txtCommon_1.MaxLength = 15;
			this._txtCommon_1.Name = "_txtCommon_1";
			// this._txtCommon_1.ShowButton = true;
			this._txtCommon_1.Size = new System.Drawing.Size(101, 19);
			this._txtCommon_1.TabIndex = 1;
			this._txtCommon_1.Text = "";
			// this.// = "";
			// this.//this._txtCommon_1.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(//this.txtCommon_DropButtonClick);
			// this._txtCommon_1.Leave += new System.EventHandler(this.txtCommon_Leave);
			// 
			// _lblCommon_5
			// 
			this._lblCommon_5.AllowDrop = true;
			this._lblCommon_5.BackColor = System.Drawing.Color.FromArgb(241, 244, 248);
			this._lblCommon_5.Text = "Contract No.";
			this._lblCommon_5.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_5.Location = new System.Drawing.Point(12, 55);
			// // this._lblCommon_5.mLabelId = 1200;
			this._lblCommon_5.Name = "_lblCommon_5";
			this._lblCommon_5.Size = new System.Drawing.Size(60, 13);
			this._lblCommon_5.TabIndex = 21;
			// 
			// lblComments
			// 
			this.lblComments.AllowDrop = true;
			this.lblComments.BackColor = System.Drawing.Color.FromArgb(202, 213, 223);
			this.lblComments.Text = "Comments";
			this.lblComments.ForeColor = System.Drawing.Color.Black;
			this.lblComments.Location = new System.Drawing.Point(6, 378);
			// // this.lblComments.mLabelId = 135;
			this.lblComments.Name = "lblComments";
			this.lblComments.Size = new System.Drawing.Size(49, 13);
			this.lblComments.TabIndex = 12;
			// 
			// frmREReceiptTransaction
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.FromArgb(202, 213, 223);
			this.ClientSize = new System.Drawing.Size(694, 403);
			this.Controls.Add(this.txtRemarks);
			this.Controls.Add(this.grdVoucherDetails);
			this.Controls.Add(this.fraTabPage0);
			this.Controls.Add(this.lblComments);
			//this.Icon = (System.Drawing.Icon) resources.GetObject("frmREReceiptTransaction.Icon");
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(46, 150);
			this.MaximizeBox = true;
			this.MinimizeBox = true;
			this.Name = "frmREReceiptTransaction";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Receipt Transaction";
			// this.Activated += new System.EventHandler(this.frmREReceiptTransaction_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
			// this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
			//((System.ComponentModel.ISupportInitialize) this.fraTabPage0).EndInit();
			this.fraTabPage0.ResumeLayout(false);
			this.fraContractDetails.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		// 
		void InitializetxtNCommon()
		{
			this.txtNCommon = new System.Windows.Forms.TextBox[2];
			this.txtNCommon[1] = _txtNCommon_1;
		}
		void InitializetxtCommonDisplay()
		{
			this.txtCommonDisplay = new System.Windows.Forms.Label[8];
			this.txtCommonDisplay[7] = _txtCommonDisplay_7;
			this.txtCommonDisplay[6] = _txtCommonDisplay_6;
			this.txtCommonDisplay[5] = _txtCommonDisplay_5;
			this.txtCommonDisplay[4] = _txtCommonDisplay_4;
			this.txtCommonDisplay[3] = _txtCommonDisplay_3;
			this.txtCommonDisplay[2] = _txtCommonDisplay_2;
			this.txtCommonDisplay[1] = _txtCommonDisplay_1;
			this.txtCommonDisplay[0] = _txtCommonDisplay_0;
		}
		void InitializetxtCommon()
		{
			this.txtCommon = new System.Windows.Forms.TextBox[4];
			this.txtCommon[0] = _txtCommon_0;
			this.txtCommon[2] = _txtCommon_2;
			this.txtCommon[3] = _txtCommon_3;
			this.txtCommon[1] = _txtCommon_1;
		}
		void InitializelblCommon()
		{
			this.lblCommon = new System.Windows.Forms.Label[13];
			this.lblCommon[6] = _lblCommon_6;
			this.lblCommon[7] = _lblCommon_7;
			this.lblCommon[9] = _lblCommon_9;
			this.lblCommon[8] = _lblCommon_8;
			this.lblCommon[10] = _lblCommon_10;
			this.lblCommon[11] = _lblCommon_11;
			this.lblCommon[12] = _lblCommon_12;
			this.lblCommon[0] = _lblCommon_0;
			this.lblCommon[1] = _lblCommon_1;
			this.lblCommon[4] = _lblCommon_4;
			this.lblCommon[2] = _lblCommon_2;
			this.lblCommon[3] = _lblCommon_3;
			this.lblCommon[5] = _lblCommon_5;
		}
		void InitializedateCommon()
		{
			this.dateCommon = new Syncfusion.WinForms.Input.SfDateTimeEdit[3];
			this.dateCommon[0] = _dateCommon_0;
			this.dateCommon[1] = _dateCommon_1;
			this.dateCommon[2] = _dateCommon_2;
		}
		#endregion
	}
}//ENDSHERE
