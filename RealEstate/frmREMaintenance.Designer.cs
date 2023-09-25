
namespace Xtreme
{
	partial class frmREMaintenance
	{

		#region "Upgrade Support "
		private static frmREMaintenance m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmREMaintenance DefInstance
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
		public static frmREMaintenance CreateInstance()
		{
			frmREMaintenance theInstance = new frmREMaintenance();
			
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
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "grdVoucherDetails", "_lblCommon_0", "_lblCommon_1", "_lblCommon_4", "_lblCommon_5", "_lblCommon_6", "_lblCommon_7", "_lblCommon_8", "_lblCommon_9", "_lblCommon_3", "_lblCommon_10", "_txtCommonTextBox_0", "_txtCommonTextBox_1", "_txtCommonDisplay_0", "txtEndDate", "txtAmount", "_txtCommonTextBox_4", "_txtCommonTextBox_2", "_txtCommonTextBox_3", "_txtCommonTextBox_5", "txtVoucherDate", "txtStartDate", "_txtCommonDisplay_1", "fraTabPage0", "lblCommon", "txtCommonDisplay", "txtCommonTextBox"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public C1.Win.C1TrueDBGrid.C1TrueDBGrid grdVoucherDetails;
		private System.Windows.Forms.Label _lblCommon_0;
		private System.Windows.Forms.Label _lblCommon_1;
		private System.Windows.Forms.Label _lblCommon_4;
		private System.Windows.Forms.Label _lblCommon_5;
		private System.Windows.Forms.Label _lblCommon_6;
		private System.Windows.Forms.Label _lblCommon_7;
		private System.Windows.Forms.Label _lblCommon_8;
		private System.Windows.Forms.Label _lblCommon_9;
		private System.Windows.Forms.Label _lblCommon_3;
		private System.Windows.Forms.Label _lblCommon_10;
		private System.Windows.Forms.TextBox _txtCommonTextBox_0;
		private System.Windows.Forms.TextBox _txtCommonTextBox_1;
		private System.Windows.Forms.Label _txtCommonDisplay_0;
		public Syncfusion.WinForms.Input.SfDateTimeEdit txtEndDate;
		public System.Windows.Forms.TextBox txtAmount;
		private System.Windows.Forms.TextBox _txtCommonTextBox_4;
		private System.Windows.Forms.TextBox _txtCommonTextBox_2;
		private System.Windows.Forms.TextBox _txtCommonTextBox_3;
		private System.Windows.Forms.TextBox _txtCommonTextBox_5;
		public Syncfusion.WinForms.Input.SfDateTimeEdit txtVoucherDate;
		public Syncfusion.WinForms.Input.SfDateTimeEdit txtStartDate;
		private System.Windows.Forms.Label _txtCommonDisplay_1;
		public System.Windows.Forms.Panel fraTabPage0;
		public System.Windows.Forms.Label[] lblCommon = new System.Windows.Forms.Label[11];
		public System.Windows.Forms.Label[] txtCommonDisplay = new System.Windows.Forms.Label[2];
		public System.Windows.Forms.TextBox[] txtCommonTextBox = new System.Windows.Forms.TextBox[6];
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmREMaintenance));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this.grdVoucherDetails = new C1.Win.C1TrueDBGrid.C1TrueDBGrid();
			this.fraTabPage0 = new System.Windows.Forms.Panel();
			this._lblCommon_0 = new System.Windows.Forms.Label();
			this._lblCommon_1 = new System.Windows.Forms.Label();
			this._lblCommon_4 = new System.Windows.Forms.Label();
			this._lblCommon_5 = new System.Windows.Forms.Label();
			this._lblCommon_6 = new System.Windows.Forms.Label();
			this._lblCommon_7 = new System.Windows.Forms.Label();
			this._lblCommon_8 = new System.Windows.Forms.Label();
			this._lblCommon_9 = new System.Windows.Forms.Label();
			this._lblCommon_3 = new System.Windows.Forms.Label();
			this._lblCommon_10 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_0 = new System.Windows.Forms.TextBox();
			this._txtCommonTextBox_1 = new System.Windows.Forms.TextBox();
			this._txtCommonDisplay_0 = new System.Windows.Forms.Label();
			this.txtEndDate = new Syncfusion.WinForms.Input.SfDateTimeEdit();
			this.txtAmount = new System.Windows.Forms.TextBox();
			this._txtCommonTextBox_4 = new System.Windows.Forms.TextBox();
			this._txtCommonTextBox_2 = new System.Windows.Forms.TextBox();
			this._txtCommonTextBox_3 = new System.Windows.Forms.TextBox();
			this._txtCommonTextBox_5 = new System.Windows.Forms.TextBox();
			this.txtVoucherDate = new Syncfusion.WinForms.Input.SfDateTimeEdit();
			this.txtStartDate = new Syncfusion.WinForms.Input.SfDateTimeEdit();
			this._txtCommonDisplay_1 = new System.Windows.Forms.Label();
			// //((System.ComponentModel.ISupportInitialize) this.fraTabPage0).BeginInit();
			this.fraTabPage0.SuspendLayout();
			this.SuspendLayout();
			// 
			// grdVoucherDetails
			// 
			this.grdVoucherDetails.AllowDrop = true;
			this.grdVoucherDetails.BackColor = System.Drawing.Color.Silver;
			this.grdVoucherDetails.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.grdVoucherDetails.CellTipsWidth = 0;
			this.grdVoucherDetails.Location = new System.Drawing.Point(4, 168);
			this.grdVoucherDetails.Name = "grdVoucherDetails";
			this.grdVoucherDetails.RowDivider.Color = System.Drawing.Color.Silver;
			this.grdVoucherDetails.Size = new System.Drawing.Size(631, 166);
			this.grdVoucherDetails.TabIndex = 10;
			this.grdVoucherDetails.AfterColUpdate += new C1.Win.C1TrueDBGrid.ColEventHandler(this.grdVoucherDetails_AfterColUpdate);
			this.grdVoucherDetails.BeforeColUpdate += new C1.Win.C1TrueDBGrid.BeforeColUpdateEventHandler(this.grdVoucherDetails_BeforeColUpdate);
			// 
			// fraTabPage0
			// 
			this.fraTabPage0.AllowDrop = true;
			this.fraTabPage0.Controls.Add(this._lblCommon_0);
			this.fraTabPage0.Controls.Add(this._lblCommon_1);
			this.fraTabPage0.Controls.Add(this._lblCommon_4);
			this.fraTabPage0.Controls.Add(this._lblCommon_5);
			this.fraTabPage0.Controls.Add(this._lblCommon_6);
			this.fraTabPage0.Controls.Add(this._lblCommon_7);
			this.fraTabPage0.Controls.Add(this._lblCommon_8);
			this.fraTabPage0.Controls.Add(this._lblCommon_9);
			this.fraTabPage0.Controls.Add(this._lblCommon_3);
			this.fraTabPage0.Controls.Add(this._lblCommon_10);
			this.fraTabPage0.Controls.Add(this._txtCommonTextBox_0);
			this.fraTabPage0.Controls.Add(this._txtCommonTextBox_1);
			this.fraTabPage0.Controls.Add(this._txtCommonDisplay_0);
			this.fraTabPage0.Controls.Add(this.txtEndDate);
			this.fraTabPage0.Controls.Add(this.txtAmount);
			this.fraTabPage0.Controls.Add(this._txtCommonTextBox_4);
			this.fraTabPage0.Controls.Add(this._txtCommonTextBox_2);
			this.fraTabPage0.Controls.Add(this._txtCommonTextBox_3);
			this.fraTabPage0.Controls.Add(this._txtCommonTextBox_5);
			this.fraTabPage0.Controls.Add(this.txtVoucherDate);
			this.fraTabPage0.Controls.Add(this.txtStartDate);
			this.fraTabPage0.Controls.Add(this._txtCommonDisplay_1);
			this.fraTabPage0.Location = new System.Drawing.Point(4, 42);
			this.fraTabPage0.Name = "fraTabPage0";
			//
			this.fraTabPage0.Size = new System.Drawing.Size(633, 122);
			this.fraTabPage0.TabIndex = 11;
			// 
			// _lblCommon_0
			// 
			this._lblCommon_0.AllowDrop = true;
			this._lblCommon_0.BackColor = System.Drawing.Color.FromArgb(241, 244, 248);
			this._lblCommon_0.Text = "Voucher No.";
			this._lblCommon_0.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_0.Location = new System.Drawing.Point(12, 12);
			this._lblCommon_0.Name = "_lblCommon_0";
			this._lblCommon_0.Size = new System.Drawing.Size(60, 13);
			this._lblCommon_0.TabIndex = 12;
			// 
			// _lblCommon_1
			// 
			this._lblCommon_1.AllowDrop = true;
			this._lblCommon_1.BackColor = System.Drawing.Color.FromArgb(241, 244, 248);
			this._lblCommon_1.Text = "Maintenance Code";
			this._lblCommon_1.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_1.Location = new System.Drawing.Point(12, 33);
			this._lblCommon_1.Name = "_lblCommon_1";
			this._lblCommon_1.Size = new System.Drawing.Size(90, 13);
			this._lblCommon_1.TabIndex = 13;
			// 
			// _lblCommon_4
			// 
			this._lblCommon_4.AllowDrop = true;
			this._lblCommon_4.BackColor = System.Drawing.Color.FromArgb(241, 244, 248);
			this._lblCommon_4.Text = "Start Date";
			this._lblCommon_4.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_4.Location = new System.Drawing.Point(426, 54);
			this._lblCommon_4.Name = "_lblCommon_4";
			this._lblCommon_4.Size = new System.Drawing.Size(48, 13);
			this._lblCommon_4.TabIndex = 14;
			// 
			// _lblCommon_5
			// 
			this._lblCommon_5.AllowDrop = true;
			this._lblCommon_5.BackColor = System.Drawing.Color.FromArgb(241, 244, 248);
			this._lblCommon_5.Text = "Property Code";
			this._lblCommon_5.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_5.Location = new System.Drawing.Point(12, 54);
			this._lblCommon_5.Name = "_lblCommon_5";
			this._lblCommon_5.Size = new System.Drawing.Size(67, 13);
			this._lblCommon_5.TabIndex = 15;
			// 
			// _lblCommon_6
			// 
			this._lblCommon_6.AllowDrop = true;
			this._lblCommon_6.BackColor = System.Drawing.Color.FromArgb(241, 244, 248);
			this._lblCommon_6.Text = "End Date";
			this._lblCommon_6.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_6.Location = new System.Drawing.Point(426, 75);
			this._lblCommon_6.Name = "_lblCommon_6";
			this._lblCommon_6.Size = new System.Drawing.Size(45, 13);
			this._lblCommon_6.TabIndex = 16;
			// 
			// _lblCommon_7
			// 
			this._lblCommon_7.AllowDrop = true;
			this._lblCommon_7.BackColor = System.Drawing.Color.FromArgb(241, 244, 248);
			this._lblCommon_7.Text = "Voucher Date";
			this._lblCommon_7.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_7.Location = new System.Drawing.Point(426, 12);
			this._lblCommon_7.Name = "_lblCommon_7";
			this._lblCommon_7.Size = new System.Drawing.Size(66, 13);
			this._lblCommon_7.TabIndex = 17;
			// 
			// _lblCommon_8
			// 
			this._lblCommon_8.AllowDrop = true;
			this._lblCommon_8.BackColor = System.Drawing.Color.FromArgb(241, 244, 248);
			this._lblCommon_8.Text = "Amount";
			this._lblCommon_8.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_8.Location = new System.Drawing.Point(426, 96);
			this._lblCommon_8.Name = "_lblCommon_8";
			this._lblCommon_8.Size = new System.Drawing.Size(36, 13);
			this._lblCommon_8.TabIndex = 18;
			// 
			// _lblCommon_9
			// 
			this._lblCommon_9.AllowDrop = true;
			this._lblCommon_9.BackColor = System.Drawing.Color.FromArgb(241, 244, 248);
			this._lblCommon_9.Text = "Ref. No.";
			this._lblCommon_9.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_9.Location = new System.Drawing.Point(426, 33);
			this._lblCommon_9.Name = "_lblCommon_9";
			this._lblCommon_9.Size = new System.Drawing.Size(40, 13);
			this._lblCommon_9.TabIndex = 19;
			// 
			// _lblCommon_3
			// 
			this._lblCommon_3.AllowDrop = true;
			this._lblCommon_3.BackColor = System.Drawing.Color.FromArgb(241, 244, 248);
			this._lblCommon_3.Text = "Unit Code";
			this._lblCommon_3.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_3.Location = new System.Drawing.Point(12, 75);
			this._lblCommon_3.Name = "_lblCommon_3";
			this._lblCommon_3.Size = new System.Drawing.Size(47, 13);
			this._lblCommon_3.TabIndex = 20;
			// 
			// _lblCommon_10
			// 
			this._lblCommon_10.AllowDrop = true;
			this._lblCommon_10.BackColor = System.Drawing.Color.FromArgb(241, 244, 248);
			this._lblCommon_10.Text = "Comments";
			this._lblCommon_10.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_10.Location = new System.Drawing.Point(12, 96);
			this._lblCommon_10.Name = "_lblCommon_10";
			this._lblCommon_10.Size = new System.Drawing.Size(49, 13);
			this._lblCommon_10.TabIndex = 21;
			// 
			// _txtCommonTextBox_0
			// 
			this._txtCommonTextBox_0.AllowDrop = true;
			this._txtCommonTextBox_0.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_0.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_0.Location = new System.Drawing.Point(114, 9);
			this._txtCommonTextBox_0.MaxLength = 15;
			// this._txtCommonTextBox_0.mDropDownType = System.Windows.Forms.TextBox.DropDownTypes.ddtNextNumber;
			this._txtCommonTextBox_0.Name = "_txtCommonTextBox_0";
			// this._txtCommonTextBox_0.ShowButton = true;
			this._txtCommonTextBox_0.Size = new System.Drawing.Size(101, 19);
			this._txtCommonTextBox_0.TabIndex = 0;
			this._txtCommonTextBox_0.Text = "";
			// this.this._txtCommonTextBox_0.Watermark = "";
			// this.this._txtCommonTextBox_0.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_0.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _txtCommonTextBox_1
			// 
			this._txtCommonTextBox_1.AllowDrop = true;
			this._txtCommonTextBox_1.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_1.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_1.Location = new System.Drawing.Point(114, 30);
			this._txtCommonTextBox_1.MaxLength = 15;
			this._txtCommonTextBox_1.Name = "_txtCommonTextBox_1";
			// this._txtCommonTextBox_1.ShowButton = true;
			this._txtCommonTextBox_1.Size = new System.Drawing.Size(101, 19);
			this._txtCommonTextBox_1.TabIndex = 2;
			this._txtCommonTextBox_1.Text = "";
			// this.this._txtCommonTextBox_1.Watermark = "";
			// this.this._txtCommonTextBox_1.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_1.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _txtCommonDisplay_0
			// 
			this._txtCommonDisplay_0.AllowDrop = true;
			this._txtCommonDisplay_0.Location = new System.Drawing.Point(216, 30);
			this._txtCommonDisplay_0.Name = "_txtCommonDisplay_0";
			this._txtCommonDisplay_0.Size = new System.Drawing.Size(201, 19);
			this._txtCommonDisplay_0.TabIndex = 22;
			// 
			// txtEndDate
			// 
			this.txtEndDate.AllowDrop = true;
			// this.txtEndDate.CheckDateRange = false;
			this.txtEndDate.Location = new System.Drawing.Point(522, 72);
			// this.txtEndDate.MaxDate = 2958465;
			// this.txtEndDate.MinDate = 32874;
			this.txtEndDate.Name = "txtEndDate";
			this.txtEndDate.Size = new System.Drawing.Size(102, 19);
			this.txtEndDate.TabIndex = 8;
			// this.txtEndDate.Text = "18/07/2001";
			// this.txtEndDate.Value = 37090;
			// 
			// txtAmount
			// 
			this.txtAmount.AllowDrop = true;
			// this.txtAmount.DisplayFormat = "####0.000###;;0.000;0.000";
			// this.txtAmount.Format = "###########0.000";
			this.txtAmount.Location = new System.Drawing.Point(522, 93);
			// this.txtAmount.MaxValue = 2147483647;
			// this.txtAmount.MinValue = 0;
			this.txtAmount.Name = "txtAmount";
			this.txtAmount.Size = new System.Drawing.Size(102, 19);
			this.txtAmount.TabIndex = 9;
			this.txtAmount.Text = "0.000";
			// this.txtAmount.Leave += new System.EventHandler(this.txtAmount_Leave);
			// 
			// _txtCommonTextBox_4
			// 
			this._txtCommonTextBox_4.AllowDrop = true;
			this._txtCommonTextBox_4.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_4.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_4.Location = new System.Drawing.Point(114, 93);
			// this._txtCommonTextBox_4.mArabicEnabled = true;
			this._txtCommonTextBox_4.MaxLength = 100;
			this._txtCommonTextBox_4.Name = "_txtCommonTextBox_4";
			this._txtCommonTextBox_4.Size = new System.Drawing.Size(304, 19);
			this._txtCommonTextBox_4.TabIndex = 5;
			this._txtCommonTextBox_4.Text = "";
			// this.this._txtCommonTextBox_4.Watermark = "";
			// this.this._txtCommonTextBox_4.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_4.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _txtCommonTextBox_2
			// 
			this._txtCommonTextBox_2.AllowDrop = true;
			this._txtCommonTextBox_2.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_2.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_2.Location = new System.Drawing.Point(114, 51);
			this._txtCommonTextBox_2.MaxLength = 15;
			this._txtCommonTextBox_2.Name = "_txtCommonTextBox_2";
			// this._txtCommonTextBox_2.ShowButton = true;
			this._txtCommonTextBox_2.Size = new System.Drawing.Size(101, 19);
			this._txtCommonTextBox_2.TabIndex = 3;
			this._txtCommonTextBox_2.Text = "";
			// this.this._txtCommonTextBox_2.Watermark = "";
			// this.this._txtCommonTextBox_2.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_2.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _txtCommonTextBox_3
			// 
			this._txtCommonTextBox_3.AllowDrop = true;
			this._txtCommonTextBox_3.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_3.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_3.Location = new System.Drawing.Point(114, 72);
			this._txtCommonTextBox_3.MaxLength = 15;
			this._txtCommonTextBox_3.Name = "_txtCommonTextBox_3";
			// this._txtCommonTextBox_3.ShowButton = true;
			this._txtCommonTextBox_3.Size = new System.Drawing.Size(101, 19);
			this._txtCommonTextBox_3.TabIndex = 4;
			this._txtCommonTextBox_3.Text = "";
			// this.this._txtCommonTextBox_3.Watermark = "";
			// this.this._txtCommonTextBox_3.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_3.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _txtCommonTextBox_5
			// 
			this._txtCommonTextBox_5.AllowDrop = true;
			this._txtCommonTextBox_5.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_5.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_5.Location = new System.Drawing.Point(522, 30);
			this._txtCommonTextBox_5.MaxLength = 15;
			this._txtCommonTextBox_5.Name = "_txtCommonTextBox_5";
			this._txtCommonTextBox_5.Size = new System.Drawing.Size(101, 19);
			this._txtCommonTextBox_5.TabIndex = 6;
			this._txtCommonTextBox_5.Text = "";
			// this.this._txtCommonTextBox_5.Watermark = "";
			// this.this._txtCommonTextBox_5.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_5.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// txtVoucherDate
			// 
			this.txtVoucherDate.AllowDrop = true;
			// this.txtVoucherDate.CheckDateRange = false;
			this.txtVoucherDate.Location = new System.Drawing.Point(522, 9);
			// this.txtVoucherDate.MaxDate = 2958465;
			// this.txtVoucherDate.MinDate = 32874;
			this.txtVoucherDate.Name = "txtVoucherDate";
			this.txtVoucherDate.Size = new System.Drawing.Size(102, 19);
			this.txtVoucherDate.TabIndex = 1;
			// this.txtVoucherDate.Text = "18/07/2001";
			// this.txtVoucherDate.Value = 37090;
			// 
			// txtStartDate
			// 
			this.txtStartDate.AllowDrop = true;
			// this.txtStartDate.CheckDateRange = false;
			this.txtStartDate.Location = new System.Drawing.Point(522, 51);
			// this.txtStartDate.MaxDate = 2958465;
			// this.txtStartDate.MinDate = 32874;
			this.txtStartDate.Name = "txtStartDate";
			this.txtStartDate.Size = new System.Drawing.Size(102, 19);
			this.txtStartDate.TabIndex = 7;
			// this.txtStartDate.Text = "18/07/2001";
			// this.txtStartDate.Value = 37090;
			// 
			// _txtCommonDisplay_1
			// 
			this._txtCommonDisplay_1.AllowDrop = true;
			this._txtCommonDisplay_1.Location = new System.Drawing.Point(216, 51);
			this._txtCommonDisplay_1.Name = "_txtCommonDisplay_1";
			this._txtCommonDisplay_1.Size = new System.Drawing.Size(201, 19);
			this._txtCommonDisplay_1.TabIndex = 23;
			// 
			// frmREMaintenance
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.ClientSize = new System.Drawing.Size(639, 337);
			this.Controls.Add(this.grdVoucherDetails);
			this.Controls.Add(this.fraTabPage0);
			//this.Icon = (System.Drawing.Icon) resources.GetObject("frmREMaintenance.Icon");
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(751, 265);
			this.MaximizeBox = true;
			this.MinimizeBox = true;
			this.Name = "frmREMaintenance";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Maintenance Payment Transaction";
			// this.Activated += new System.EventHandler(this.frmREMaintenance_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
			// this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
			//((System.ComponentModel.ISupportInitialize) this.fraTabPage0).EndInit();
			this.fraTabPage0.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		// 
		void InitializetxtCommonTextBox()
		{
			this.txtCommonTextBox = new System.Windows.Forms.TextBox[6];
			this.txtCommonTextBox[0] = _txtCommonTextBox_0;
			this.txtCommonTextBox[1] = _txtCommonTextBox_1;
			this.txtCommonTextBox[4] = _txtCommonTextBox_4;
			this.txtCommonTextBox[2] = _txtCommonTextBox_2;
			this.txtCommonTextBox[3] = _txtCommonTextBox_3;
			this.txtCommonTextBox[5] = _txtCommonTextBox_5;
		}
		void InitializetxtCommonDisplay()
		{
			this.txtCommonDisplay = new System.Windows.Forms.Label[2];
			this.txtCommonDisplay[0] = _txtCommonDisplay_0;
			this.txtCommonDisplay[1] = _txtCommonDisplay_1;
		}
		void InitializelblCommon()
		{
			this.lblCommon = new System.Windows.Forms.Label[11];
			this.lblCommon[0] = _lblCommon_0;
			this.lblCommon[1] = _lblCommon_1;
			this.lblCommon[4] = _lblCommon_4;
			this.lblCommon[5] = _lblCommon_5;
			this.lblCommon[6] = _lblCommon_6;
			this.lblCommon[7] = _lblCommon_7;
			this.lblCommon[8] = _lblCommon_8;
			this.lblCommon[9] = _lblCommon_9;
			this.lblCommon[3] = _lblCommon_3;
			this.lblCommon[10] = _lblCommon_10;
		}
		#endregion
	}
}//ENDSHERE
