
namespace Xtreme
{
	partial class frmSysYearClose
	{

		#region "Upgrade Support "
		private static frmSysYearClose m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmSysYearClose DefInstance
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
		public static frmSysYearClose CreateInstance()
		{
			frmSysYearClose theInstance = new frmSysYearClose();
			
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
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "_lblCommon_1", "_lblCommon_4", "_lblCommon_5", "txtVoucherDate", "_txtCommonSearch_7", "_lblCommon_6", "_lblCommon_8", "_lblCommon_9", "_txtCommonSearch_5", "_lblCommon_10", "_txtCommon_7", "_txtCommon_5", "_txtCommon_4", "_txtCommon_3", "_Line1_1", "_Line1_2", "lblNoticeText", "cntMasterDetails", "_lblCommon_0", "_lblCommon_2", "_lblCommon_3", "_btnReportOptions_1", "_btnReportOptions_2", "_txtCommon_2", "_txtCommon_1", "_txtCommon_0", "_cntButtons_1", "_Line1_0", "Line1", "btnReportOptions", "cntButtons", "lblCommon", "txtCommon", "txtCommonSearch"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		private System.Windows.Forms.Label _lblCommon_1;
		private System.Windows.Forms.Label _lblCommon_4;
		private System.Windows.Forms.Label _lblCommon_5;
		public Syncfusion.WinForms.Input.SfDateTimeEdit txtVoucherDate;
		private System.Windows.Forms.TextBox _txtCommonSearch_7;
		private System.Windows.Forms.Label _lblCommon_6;
		private System.Windows.Forms.Label _lblCommon_8;
		private System.Windows.Forms.Label _lblCommon_9;
		private System.Windows.Forms.TextBox _txtCommonSearch_5;
		private System.Windows.Forms.Label _lblCommon_10;
		private System.Windows.Forms.Label _txtCommon_7;
		private System.Windows.Forms.Label _txtCommon_5;
		private System.Windows.Forms.Label _txtCommon_4;
		private System.Windows.Forms.Label _txtCommon_3;
		private System.Windows.Forms.Label _Line1_1;
		private System.Windows.Forms.Label _Line1_2;
		public System.Windows.Forms.Label lblNoticeText;
		public System.Windows.Forms.Panel cntMasterDetails;
		private System.Windows.Forms.Label _lblCommon_0;
		private System.Windows.Forms.Label _lblCommon_2;
		private System.Windows.Forms.Label _lblCommon_3;
		private AxSmartNetButtonProject.AxSmartNetButton _btnReportOptions_1;
		private AxSmartNetButtonProject.AxSmartNetButton _btnReportOptions_2;
		private System.Windows.Forms.Label _txtCommon_2;
		private System.Windows.Forms.Label _txtCommon_1;
		private System.Windows.Forms.Label _txtCommon_0;
		private UpgradeHelpers.Gui.ShapeHelper _cntButtons_1;
		private System.Windows.Forms.Label _Line1_0;
		public System.Windows.Forms.Label[] Line1 = new System.Windows.Forms.Label[3];
		public AxSmartNetButtonProject.AxSmartNetButton[] btnReportOptions = new AxSmartNetButtonProject.AxSmartNetButton[3];
		public UpgradeHelpers.Gui.ShapeHelper[] cntButtons = new UpgradeHelpers.Gui.ShapeHelper[2];
		public System.Windows.Forms.Label[] lblCommon = new System.Windows.Forms.Label[11];
		public System.Windows.Forms.Label[] txtCommon = new System.Windows.Forms.Label[8];
		public System.Windows.Forms.TextBox[] txtCommonSearch = new System.Windows.Forms.TextBox[8];
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSysYearClose));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this.cntMasterDetails = new System.Windows.Forms.Panel();
			this._lblCommon_1 = new System.Windows.Forms.Label();
			this._lblCommon_4 = new System.Windows.Forms.Label();
			this._lblCommon_5 = new System.Windows.Forms.Label();
			this.txtVoucherDate = new Syncfusion.WinForms.Input.SfDateTimeEdit();
			this._txtCommonSearch_7 = new System.Windows.Forms.TextBox();
			this._lblCommon_6 = new System.Windows.Forms.Label();
			this._lblCommon_8 = new System.Windows.Forms.Label();
			this._lblCommon_9 = new System.Windows.Forms.Label();
			this._txtCommonSearch_5 = new System.Windows.Forms.TextBox();
			this._lblCommon_10 = new System.Windows.Forms.Label();
			this._txtCommon_7 = new System.Windows.Forms.Label();
			this._txtCommon_5 = new System.Windows.Forms.Label();
			this._txtCommon_4 = new System.Windows.Forms.Label();
			this._txtCommon_3 = new System.Windows.Forms.Label();
			this._Line1_1 = new System.Windows.Forms.Label();
			this._Line1_2 = new System.Windows.Forms.Label();
			this.lblNoticeText = new System.Windows.Forms.Label();
			this._lblCommon_0 = new System.Windows.Forms.Label();
			this._lblCommon_2 = new System.Windows.Forms.Label();
			this._lblCommon_3 = new System.Windows.Forms.Label();
			this._btnReportOptions_1 = new AxSmartNetButtonProject.AxSmartNetButton();
			this._btnReportOptions_2 = new AxSmartNetButtonProject.AxSmartNetButton();
			this._txtCommon_2 = new System.Windows.Forms.Label();
			this._txtCommon_1 = new System.Windows.Forms.Label();
			this._txtCommon_0 = new System.Windows.Forms.Label();
			this._cntButtons_1 = new UpgradeHelpers.Gui.ShapeHelper();
			this._Line1_0 = new System.Windows.Forms.Label();
			// //((System.ComponentModel.ISupportInitialize) this.cntMasterDetails).BeginInit();
			// //((System.ComponentModel.ISupportInitialize) this._btnReportOptions_1).BeginInit();
			// //((System.ComponentModel.ISupportInitialize) this._btnReportOptions_2).BeginInit();
			this.cntMasterDetails.SuspendLayout();
			this.SuspendLayout();
			// 
			// cntMasterDetails
			// 
			this.cntMasterDetails.AllowDrop = true;
			this.cntMasterDetails.Controls.Add(this._lblCommon_1);
			this.cntMasterDetails.Controls.Add(this._lblCommon_4);
			this.cntMasterDetails.Controls.Add(this._lblCommon_5);
			this.cntMasterDetails.Controls.Add(this.txtVoucherDate);
			this.cntMasterDetails.Controls.Add(this._txtCommonSearch_7);
			this.cntMasterDetails.Controls.Add(this._lblCommon_6);
			this.cntMasterDetails.Controls.Add(this._lblCommon_8);
			this.cntMasterDetails.Controls.Add(this._lblCommon_9);
			this.cntMasterDetails.Controls.Add(this._txtCommonSearch_5);
			this.cntMasterDetails.Controls.Add(this._lblCommon_10);
			this.cntMasterDetails.Controls.Add(this._txtCommon_7);
			this.cntMasterDetails.Controls.Add(this._txtCommon_5);
			this.cntMasterDetails.Controls.Add(this._txtCommon_4);
			this.cntMasterDetails.Controls.Add(this._txtCommon_3);
			this.cntMasterDetails.Controls.Add(this._Line1_1);
			this.cntMasterDetails.Controls.Add(this._Line1_2);
			this.cntMasterDetails.Controls.Add(this.lblNoticeText);
			this.cntMasterDetails.Location = new System.Drawing.Point(6, 104);
			this.cntMasterDetails.Name = "cntMasterDetails";
			//
			this.cntMasterDetails.Size = new System.Drawing.Size(517, 269);
			this.cntMasterDetails.TabIndex = 10;
			// 
			// _lblCommon_1
			// 
			this._lblCommon_1.AllowDrop = true;
			this._lblCommon_1.BackColor = System.Drawing.SystemColors.Window;
			this._lblCommon_1.Text = "C a u t i o n  :";
			this._lblCommon_1.Location = new System.Drawing.Point(8, 194);
			this._lblCommon_1.Name = "_lblCommon_1";
			this._lblCommon_1.Size = new System.Drawing.Size(65, 13);
			this._lblCommon_1.TabIndex = 11;
			// 
			// _lblCommon_4
			// 
			this._lblCommon_4.AllowDrop = true;
			this._lblCommon_4.BackColor = System.Drawing.SystemColors.Window;
			this._lblCommon_4.Text = "New Current Fiscal Year";
			this._lblCommon_4.Location = new System.Drawing.Point(6, 14);
			this._lblCommon_4.Name = "_lblCommon_4";
			this._lblCommon_4.Size = new System.Drawing.Size(115, 13);
			this._lblCommon_4.TabIndex = 15;
			// 
			// _lblCommon_5
			// 
			this._lblCommon_5.AllowDrop = true;
			this._lblCommon_5.BackColor = System.Drawing.SystemColors.Window;
			this._lblCommon_5.Text = "New Next Fiscal Year";
			this._lblCommon_5.Location = new System.Drawing.Point(6, 34);
			this._lblCommon_5.Name = "_lblCommon_5";
			this._lblCommon_5.Size = new System.Drawing.Size(101, 13);
			this._lblCommon_5.TabIndex = 16;
			// 
			// txtVoucherDate
			// 
			this.txtVoucherDate.AllowDrop = true;
			this.txtVoucherDate.BackColor = System.Drawing.Color.FromArgb(239, 239, 239);
			this.txtVoucherDate.Enabled = false;
			this.txtVoucherDate.Location = new System.Drawing.Point(129, 148);
			// this.txtVoucherDate.MaxDate = 2958465;
			// this.txtVoucherDate.MinDate = 2;
			this.txtVoucherDate.Name = "txtVoucherDate";
			this.txtVoucherDate.ReadOnly = true;
			this.txtVoucherDate.Size = new System.Drawing.Size(101, 19);
			this.txtVoucherDate.TabIndex = 2;
			// this.txtVoucherDate.Text = "10-May-2002";
			// this.txtVoucherDate.Value = 37386;
			// 
			// _txtCommonSearch_7
			// 
			this._txtCommonSearch_7.AllowDrop = true;
			this._txtCommonSearch_7.BackColor = System.Drawing.Color.White;
			this._txtCommonSearch_7.ForeColor = System.Drawing.Color.Black;
			this._txtCommonSearch_7.Location = new System.Drawing.Point(129, 106);
			this._txtCommonSearch_7.Name = "_txtCommonSearch_7";
			// this._txtCommonSearch_7.ShowButton = true;
			this._txtCommonSearch_7.Size = new System.Drawing.Size(101, 19);
			this._txtCommonSearch_7.TabIndex = 0;
			this._txtCommonSearch_7.Text = "";
			// this.this._txtCommonSearch_7.Watermark = "";
			// this.this._txtCommonSearch_7.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonSearch_DropButtonClick);
			// this._txtCommonSearch_7.Leave += new System.EventHandler(this.txtCommonSearch_Leave);
			// 
			// _lblCommon_6
			// 
			this._lblCommon_6.AllowDrop = true;
			this._lblCommon_6.BackColor = System.Drawing.SystemColors.Window;
			this._lblCommon_6.Text = "Voucher Type";
			this._lblCommon_6.Location = new System.Drawing.Point(7, 130);
			this._lblCommon_6.Name = "_lblCommon_6";
			this._lblCommon_6.Size = new System.Drawing.Size(66, 13);
			this._lblCommon_6.TabIndex = 5;
			// 
			// _lblCommon_8
			// 
			this._lblCommon_8.AllowDrop = true;
			this._lblCommon_8.BackColor = System.Drawing.SystemColors.Window;
			this._lblCommon_8.Text = "Capital A/c";
			this._lblCommon_8.Location = new System.Drawing.Point(7, 109);
			this._lblCommon_8.Name = "_lblCommon_8";
			this._lblCommon_8.Size = new System.Drawing.Size(52, 13);
			this._lblCommon_8.TabIndex = 6;
			// 
			// _lblCommon_9
			// 
			this._lblCommon_9.AllowDrop = true;
			this._lblCommon_9.BackColor = System.Drawing.SystemColors.Window;
			this._lblCommon_9.Text = "Voucher Date";
			this._lblCommon_9.Location = new System.Drawing.Point(7, 151);
			this._lblCommon_9.Name = "_lblCommon_9";
			this._lblCommon_9.Size = new System.Drawing.Size(65, 13);
			this._lblCommon_9.TabIndex = 7;
			// 
			// _txtCommonSearch_5
			// 
			this._txtCommonSearch_5.AllowDrop = true;
			this._txtCommonSearch_5.BackColor = System.Drawing.Color.FromArgb(239, 239, 239);
			this._txtCommonSearch_5.Enabled = false;
			this._txtCommonSearch_5.ForeColor = System.Drawing.Color.Black;
			this._txtCommonSearch_5.Location = new System.Drawing.Point(129, 127);
			this._txtCommonSearch_5.Name = "_txtCommonSearch_5";
			this._txtCommonSearch_5.Size = new System.Drawing.Size(101, 19);
			this._txtCommonSearch_5.TabIndex = 1;
			this._txtCommonSearch_5.Text = "";
			// this.this._txtCommonSearch_5.Watermark = "";
			// this.this._txtCommonSearch_5.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonSearch_DropButtonClick);
			// this._txtCommonSearch_5.Leave += new System.EventHandler(this.txtCommonSearch_Leave);
			// 
			// _lblCommon_10
			// 
			this._lblCommon_10.AllowDrop = true;
			this._lblCommon_10.BackColor = System.Drawing.SystemColors.Window;
			this._lblCommon_10.Text = " Generated Opening Voucher Information (for P && L Transfer) ";
			this._lblCommon_10.Location = new System.Drawing.Point(8, 82);
			this._lblCommon_10.Name = "_lblCommon_10";
			this._lblCommon_10.Size = new System.Drawing.Size(297, 13);
			this._lblCommon_10.TabIndex = 8;
			// 
			// _txtCommon_7
			// 
			this._txtCommon_7.AllowDrop = true;
			this._txtCommon_7.Location = new System.Drawing.Point(232, 106);
			this._txtCommon_7.Name = "_txtCommon_7";
			this._txtCommon_7.Size = new System.Drawing.Size(201, 19);
			this._txtCommon_7.TabIndex = 17;
			// 
			// _txtCommon_5
			// 
			this._txtCommon_5.AllowDrop = true;
			this._txtCommon_5.Location = new System.Drawing.Point(232, 127);
			this._txtCommon_5.Name = "_txtCommon_5";
			this._txtCommon_5.Size = new System.Drawing.Size(201, 19);
			this._txtCommon_5.TabIndex = 18;
			// 
			// _txtCommon_4
			// 
			this._txtCommon_4.AllowDrop = true;
			this._txtCommon_4.Location = new System.Drawing.Point(129, 32);
			this._txtCommon_4.Name = "_txtCommon_4";
			this._txtCommon_4.Size = new System.Drawing.Size(201, 19);
			this._txtCommon_4.TabIndex = 19;
			// 
			// _txtCommon_3
			// 
			this._txtCommon_3.AllowDrop = true;
			this._txtCommon_3.Location = new System.Drawing.Point(129, 11);
			this._txtCommon_3.Name = "_txtCommon_3";
			this._txtCommon_3.Size = new System.Drawing.Size(201, 19);
			this._txtCommon_3.TabIndex = 20;
			// 
			// _Line1_1
			// 
			this._Line1_1.AllowDrop = true;
			this._Line1_1.BackColor = System.Drawing.Color.White;
			this._Line1_1.Enabled = false;
			this._Line1_1.Location = new System.Drawing.Point(1, 89);
			this._Line1_1.Name = "_Line1_1";
			this._Line1_1.Size = new System.Drawing.Size(510, 1);
			this._Line1_1.Visible = true;
			// 
			// _Line1_2
			// 
			this._Line1_2.AllowDrop = true;
			this._Line1_2.BackColor = System.Drawing.Color.Gray;
			this._Line1_2.Enabled = false;
			this._Line1_2.Location = new System.Drawing.Point(1, 90);
			this._Line1_2.Name = "_Line1_2";
			this._Line1_2.Size = new System.Drawing.Size(510, 1);
			this._Line1_2.Visible = true;
			// 
			// lblNoticeText
			// 
			this.lblNoticeText.AllowDrop = true;
			this.lblNoticeText.BackColor = System.Drawing.Color.FromArgb(255, 106, 106);
			this.lblNoticeText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblNoticeText.ForeColor = System.Drawing.SystemColors.WindowText;
			this.lblNoticeText.Location = new System.Drawing.Point(6, 212);
			this.lblNoticeText.Name = "lblNoticeText";
			this.lblNoticeText.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblNoticeText.Size = new System.Drawing.Size(493, 43);
			this.lblNoticeText.TabIndex = 12;
			this.lblNoticeText.Text = "Closing the fiscal year will post all the vouchers of the current fiscal year.";
			// 
			// _lblCommon_0
			// 
			this._lblCommon_0.AllowDrop = true;
			this._lblCommon_0.BackColor = System.Drawing.SystemColors.Window;
			this._lblCommon_0.Text = "Company";
			this._lblCommon_0.Location = new System.Drawing.Point(9, 13);
			this._lblCommon_0.Name = "_lblCommon_0";
			this._lblCommon_0.Size = new System.Drawing.Size(45, 13);
			this._lblCommon_0.TabIndex = 9;
			// 
			// _lblCommon_2
			// 
			this._lblCommon_2.AllowDrop = true;
			this._lblCommon_2.BackColor = System.Drawing.SystemColors.Window;
			this._lblCommon_2.Text = "Current Fiscal Year";
			this._lblCommon_2.Location = new System.Drawing.Point(9, 34);
			this._lblCommon_2.Name = "_lblCommon_2";
			this._lblCommon_2.Size = new System.Drawing.Size(91, 13);
			this._lblCommon_2.TabIndex = 13;
			// 
			// _lblCommon_3
			// 
			this._lblCommon_3.AllowDrop = true;
			this._lblCommon_3.BackColor = System.Drawing.SystemColors.Window;
			this._lblCommon_3.Text = "Next Fiscal Year";
			this._lblCommon_3.Location = new System.Drawing.Point(9, 55);
			this._lblCommon_3.Name = "_lblCommon_3";
			this._lblCommon_3.Size = new System.Drawing.Size(77, 13);
			this._lblCommon_3.TabIndex = 14;
			// 
			// _btnReportOptions_1
			// 
			this._btnReportOptions_1.AllowDrop = true;
			this._btnReportOptions_1.Location = new System.Drawing.Point(531, 309);
			this._btnReportOptions_1.Name = "_btnReportOptions_1";
			//
			this._btnReportOptions_1.Size = new System.Drawing.Size(96, 28);
			this._btnReportOptions_1.TabIndex = 3;
			//// this._btnReportOptions_1.ClickEvent += new System.EventHandler(this.btnReportOptions_ClickEvent);
			this._btnReportOptions_1.KeyDownEvent += new AxSmartNetButtonProject.__SmartNetButton_KeyDownEventHandler(this.btnReportOptions_KeyDownEvent);
			// 
			// _btnReportOptions_2
			// 
			this._btnReportOptions_2.AllowDrop = true;
			this._btnReportOptions_2.Location = new System.Drawing.Point(531, 338);
			this._btnReportOptions_2.Name = "_btnReportOptions_2";
			//
			this._btnReportOptions_2.Size = new System.Drawing.Size(96, 28);
			this._btnReportOptions_2.TabIndex = 4;
			//// this._btnReportOptions_2.ClickEvent += new System.EventHandler(this.btnReportOptions_ClickEvent);
			this._btnReportOptions_2.KeyDownEvent += new AxSmartNetButtonProject.__SmartNetButton_KeyDownEventHandler(this.btnReportOptions_KeyDownEvent);
			// 
			// _txtCommon_2
			// 
			this._txtCommon_2.AllowDrop = true;
			this._txtCommon_2.Location = new System.Drawing.Point(136, 52);
			this._txtCommon_2.Name = "_txtCommon_2";
			this._txtCommon_2.Size = new System.Drawing.Size(201, 19);
			this._txtCommon_2.TabIndex = 21;
			// 
			// _txtCommon_1
			// 
			this._txtCommon_1.AllowDrop = true;
			this._txtCommon_1.Location = new System.Drawing.Point(136, 31);
			this._txtCommon_1.Name = "_txtCommon_1";
			this._txtCommon_1.Size = new System.Drawing.Size(201, 19);
			this._txtCommon_1.TabIndex = 22;
			// 
			// _txtCommon_0
			// 
			this._txtCommon_0.AllowDrop = true;
			this._txtCommon_0.Location = new System.Drawing.Point(136, 10);
			this._txtCommon_0.Name = "_txtCommon_0";
			this._txtCommon_0.Size = new System.Drawing.Size(201, 19);
			this._txtCommon_0.TabIndex = 23;
			// 
			// _cntButtons_1
			// 
			this._cntButtons_1.AllowDrop = true;
			this._cntButtons_1.BackColor = System.Drawing.Color.FromArgb(64, 64, 0);
			this._cntButtons_1.BackStyle = 1;
			this._cntButtons_1.BorderStyle = 0;
			this._cntButtons_1.Enabled = false;
			this._cntButtons_1.FillColor = System.Drawing.Color.Black;
			this._cntButtons_1.FillStyle = 1;
			this._cntButtons_1.Location = new System.Drawing.Point(530, 308);
			this._cntButtons_1.Name = "_cntButtons_1";
			this._cntButtons_1.Size = new System.Drawing.Size(99, 60);
			this._cntButtons_1.Visible = true;
			// 
			// _Line1_0
			// 
			this._Line1_0.AllowDrop = true;
			this._Line1_0.BackColor = System.Drawing.SystemColors.WindowText;
			this._Line1_0.Enabled = false;
			this._Line1_0.Location = new System.Drawing.Point(0, 94);
			this._Line1_0.Name = "_Line1_0";
			this._Line1_0.Size = new System.Drawing.Size(634, 1);
			this._Line1_0.Visible = true;
			// 
			// frmSysYearClose
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.ClientSize = new System.Drawing.Size(634, 379);
			this.Controls.Add(this.cntMasterDetails);
			this.Controls.Add(this._lblCommon_0);
			this.Controls.Add(this._lblCommon_2);
			this.Controls.Add(this._lblCommon_3);
			this.Controls.Add(this._btnReportOptions_1);
			this.Controls.Add(this._btnReportOptions_2);
			this.Controls.Add(this._txtCommon_2);
			this.Controls.Add(this._txtCommon_1);
			this.Controls.Add(this._txtCommon_0);
			this.Controls.Add(this._cntButtons_1);
			this.Controls.Add(this._Line1_0);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			//this.Icon = (System.Drawing.Icon) resources.GetObject("frmSysYearClose.Icon");
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(58, 105);
			this.MaximizeBox = true;
			this.MinimizeBox = true;
			this.Name = "frmSysYearClose";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Close Fiscal Year";
			// this.Activated += new System.EventHandler(this.frmSysYearClose_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
			// this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
			//((System.ComponentModel.ISupportInitialize) this.cntMasterDetails).EndInit();
			//((System.ComponentModel.ISupportInitialize) this._btnReportOptions_1).EndInit();
			//((System.ComponentModel.ISupportInitialize) this._btnReportOptions_2).EndInit();
			this.cntMasterDetails.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		// 
		void InitializetxtCommonSearch()
		{
			this.txtCommonSearch = new System.Windows.Forms.TextBox[8];
			this.txtCommonSearch[7] = _txtCommonSearch_7;
			this.txtCommonSearch[5] = _txtCommonSearch_5;
		}
		void InitializetxtCommon()
		{
			this.txtCommon = new System.Windows.Forms.Label[8];
			this.txtCommon[7] = _txtCommon_7;
			this.txtCommon[5] = _txtCommon_5;
			this.txtCommon[4] = _txtCommon_4;
			this.txtCommon[3] = _txtCommon_3;
			this.txtCommon[2] = _txtCommon_2;
			this.txtCommon[1] = _txtCommon_1;
			this.txtCommon[0] = _txtCommon_0;
		}
		void InitializelblCommon()
		{
			this.lblCommon = new System.Windows.Forms.Label[11];
			this.lblCommon[1] = _lblCommon_1;
			this.lblCommon[4] = _lblCommon_4;
			this.lblCommon[5] = _lblCommon_5;
			this.lblCommon[6] = _lblCommon_6;
			this.lblCommon[8] = _lblCommon_8;
			this.lblCommon[9] = _lblCommon_9;
			this.lblCommon[10] = _lblCommon_10;
			this.lblCommon[0] = _lblCommon_0;
			this.lblCommon[2] = _lblCommon_2;
			this.lblCommon[3] = _lblCommon_3;
		}
		void InitializecntButtons()
		{
			this.cntButtons = new UpgradeHelpers.Gui.ShapeHelper[2];
			this.cntButtons[1] = _cntButtons_1;
		}
		void InitializebtnReportOptions()
		{
			this.btnReportOptions = new AxSmartNetButtonProject.AxSmartNetButton[3];
			this.btnReportOptions[1] = _btnReportOptions_1;
			this.btnReportOptions[2] = _btnReportOptions_2;
		}
		void InitializeLine1()
		{
			this.Line1 = new System.Windows.Forms.Label[3];
			this.Line1[1] = _Line1_1;
			this.Line1[2] = _Line1_2;
			this.Line1[0] = _Line1_0;
		}
		#endregion
	}
}//ENDSHERE
