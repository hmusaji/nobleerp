
namespace Xtreme
{
	partial class frmICSVoucherRateVariation
	{

		#region "Upgrade Support "
		private static frmICSVoucherRateVariation m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmICSVoucherRateVariation DefInstance
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
		public static frmICSVoucherRateVariation CreateInstance()
		{
			frmICSVoucherRateVariation theInstance = new frmICSVoucherRateVariation();
			
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
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "cmdOKCancel", "lblToDate", "txtToDate", "txtFromDate", "System.Windows.Forms.Label1", "fraDateRange", "txtCurrentRate", "System.Windows.Forms.Label2", "System.Windows.Forms.Label3", "txtNewRate", "Frame1", "txtProductCd", "txtLedgerCd", "lblLocationCode", "lblMasterCode", "txtProductName", "txtLedgerName", "cntMainParameter"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public UCOkCancel cmdOKCancel;
		public System.Windows.Forms.Label lblToDate;
		public Syncfusion.WinForms.Input.SfDateTimeEdit txtToDate;
		public Syncfusion.WinForms.Input.SfDateTimeEdit txtFromDate;
		public System.Windows.Forms.Label Label1;
		public System.Windows.Forms.Panel fraDateRange;
		public System.Windows.Forms.TextBox txtCurrentRate;
		public System.Windows.Forms.Label Label2;
		public System.Windows.Forms.Label Label3;
		public System.Windows.Forms.TextBox txtNewRate;
		public System.Windows.Forms.Panel Frame1;
		public System.Windows.Forms.TextBox txtProductCd;
		public System.Windows.Forms.TextBox txtLedgerCd;
		public System.Windows.Forms.Label lblLocationCode;
		public System.Windows.Forms.Label lblMasterCode;
		public System.Windows.Forms.Label txtProductName;
		public System.Windows.Forms.Label txtLedgerName;
		public AxTDBContainer3D6.AxTDBContainer3D cntMainParameter;
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmICSVoucherRateVariation));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this.cmdOKCancel = new UCOkCancel();
			this.cntMainParameter = new AxTDBContainer3D6.AxTDBContainer3D();
			this.fraDateRange = new System.Windows.Forms.Panel();
			this.lblToDate = new System.Windows.Forms.Label();
			this.txtToDate = new Syncfusion.WinForms.Input.SfDateTimeEdit();
			this.txtFromDate = new Syncfusion.WinForms.Input.SfDateTimeEdit();
			this.Label1 = new System.Windows.Forms.Label();
			this.Frame1 = new System.Windows.Forms.Panel();
			this.txtCurrentRate = new System.Windows.Forms.TextBox();
			this.Label2 = new System.Windows.Forms.Label();
			this.Label3 = new System.Windows.Forms.Label();
			this.txtNewRate = new System.Windows.Forms.TextBox();
			this.txtProductCd = new System.Windows.Forms.TextBox();
			this.txtLedgerCd = new System.Windows.Forms.TextBox();
			this.lblLocationCode = new System.Windows.Forms.Label();
			this.lblMasterCode = new System.Windows.Forms.Label();
			this.txtProductName = new System.Windows.Forms.Label();
			this.txtLedgerName = new System.Windows.Forms.Label();
			// //((System.ComponentModel.ISupportInitialize) this.cntMainParameter).BeginInit();
			this.cntMainParameter.SuspendLayout();
			this.fraDateRange.SuspendLayout();
			this.Frame1.SuspendLayout();
			this.SuspendLayout();
			// 
			// cmdOKCancel
			// 
			this.cmdOKCancel.AllowDrop = true;
			this.cmdOKCancel.DisplayButton = 0;
			this.cmdOKCancel.Location = new System.Drawing.Point(135, 198);
			this.cmdOKCancel.Name = "cmdOKCancel";
			this.cmdOKCancel.OkCaption = "&Ok";
			this.cmdOKCancel.Size = new System.Drawing.Size(206, 31);
			this.cmdOKCancel.TabIndex = 6;
			this.cmdOKCancel.CancelClick += new UCOkCancel.CancelClickHandler(this.cmdOKCancel_CancelClick);
			this.cmdOKCancel.OKClick += new UCOkCancel.OKClickHandler(this.cmdOKCancel_OKClick);
			// 
			// cntMainParameter
			// 
			this.cntMainParameter.AllowDrop = true;
			this.cntMainParameter.Controls.Add(this.fraDateRange);
			this.cntMainParameter.Controls.Add(this.Frame1);
			this.cntMainParameter.Controls.Add(this.txtProductCd);
			this.cntMainParameter.Controls.Add(this.txtLedgerCd);
			this.cntMainParameter.Controls.Add(this.lblLocationCode);
			this.cntMainParameter.Controls.Add(this.lblMasterCode);
			this.cntMainParameter.Controls.Add(this.txtProductName);
			this.cntMainParameter.Controls.Add(this.txtLedgerName);
			this.cntMainParameter.Location = new System.Drawing.Point(12, 11);
			this.cntMainParameter.Name = "cntMainParameter";
			//
			this.cntMainParameter.Size = new System.Drawing.Size(449, 165);
			this.cntMainParameter.TabIndex = 7;
			// 
			// fraDateRange
			// 
			this.fraDateRange.AllowDrop = true;
			this.fraDateRange.BackColor = System.Drawing.Color.FromArgb(241, 242, 234);
			this.fraDateRange.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.fraDateRange.Controls.Add(this.lblToDate);
			this.fraDateRange.Controls.Add(this.txtToDate);
			this.fraDateRange.Controls.Add(this.txtFromDate);
			this.fraDateRange.Controls.Add(this.Label1);
			this.fraDateRange.Enabled = true;
			this.fraDateRange.ForeColor = System.Drawing.SystemColors.WindowText;
			this.fraDateRange.Location = new System.Drawing.Point(9, 81);
			this.fraDateRange.Name = "fraDateRange";
			this.fraDateRange.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.fraDateRange.Size = new System.Drawing.Size(198, 62);
			this.fraDateRange.TabIndex = 13;
			this.fraDateRange.Text = " Date Range ";
			this.fraDateRange.Visible = true;
			// 
			// lblToDate
			// 
			this.lblToDate.AllowDrop = true;
			this.lblToDate.BackColor = System.Drawing.SystemColors.Window;
			// this.lblToDate.Text = "To Date";
			this.lblToDate.ForeColor = System.Drawing.Color.Black;
			this.lblToDate.Location = new System.Drawing.Point(12, 36);
			this.lblToDate.Name = "lblToDate";
			this.lblToDate.Size = new System.Drawing.Size(38, 13);
			this.lblToDate.TabIndex = 14;
			// 
			// txtToDate
			// 
			this.txtToDate.AllowDrop = true;
			// this.txtToDate.CheckDateRange = false;
			this.txtToDate.Location = new System.Drawing.Point(85, 33);
			// this.txtToDate.MaxDate = 2958465;
			// this.txtToDate.MinDate = 2;
			this.txtToDate.Name = "txtToDate";
			this.txtToDate.Size = new System.Drawing.Size(96, 19);
			this.txtToDate.TabIndex = 3;
			// this.txtToDate.Text = "18/07/2001";
			// this.txtToDate.Value = 37090;
			// 
			// txtFromDate
			// 
			this.txtFromDate.AllowDrop = true;
			// this.txtFromDate.CheckDateRange = false;
			this.txtFromDate.Location = new System.Drawing.Point(85, 12);
			// this.txtFromDate.MaxDate = 2958465;
			// this.txtFromDate.MinDate = 2;
			this.txtFromDate.Name = "txtFromDate";
			this.txtFromDate.Size = new System.Drawing.Size(96, 19);
			this.txtFromDate.TabIndex = 2;
			// this.txtFromDate.Text = "04/03/2002";
			// this.txtFromDate.Value = 37319;
			// 
			// System.Windows.Forms.Label1
			// 
			this.Label1.AllowDrop = true;
			this.Label1.BackColor = System.Drawing.SystemColors.Window;
			this.Label1.Text = "From Date";
			this.Label1.ForeColor = System.Drawing.Color.Black;
			this.Label1.Location = new System.Drawing.Point(12, 15);
			// this.Label1.mLabelId = 948;
			this.Label1.Name = "System.Windows.Forms.Label1";
			this.Label1.Size = new System.Drawing.Size(50, 13);
			this.Label1.TabIndex = 15;
			// 
			// Frame1
			// 
			this.Frame1.AllowDrop = true;
			this.Frame1.BackColor = System.Drawing.Color.FromArgb(241, 242, 234);
			this.Frame1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Frame1.Controls.Add(this.txtCurrentRate);
			this.Frame1.Controls.Add(this.Label2);
			this.Frame1.Controls.Add(this.Label3);
			this.Frame1.Controls.Add(this.txtNewRate);
			this.Frame1.Enabled = true;
			this.Frame1.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Frame1.Location = new System.Drawing.Point(222, 81);
			this.Frame1.Name = "Frame1";
			this.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Frame1.Size = new System.Drawing.Size(198, 62);
			this.Frame1.TabIndex = 10;
			this.Frame1.Text = " Price ";
			this.Frame1.Visible = true;
			// 
			// txtCurrentRate
			// 
			this.txtCurrentRate.AllowDrop = true;
			this.txtCurrentRate.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			// this.txtCurrentRate.DisplayFormat = "####0.000###;;0.000;0.000";
			this.txtCurrentRate.Enabled = false;
			// this.txtCurrentRate.Format = "###########0.000";
			this.txtCurrentRate.Location = new System.Drawing.Point(90, 9);
			// this.txtCurrentRate.MaxValue = 2147483647;
			// this.txtCurrentRate.MinValue = 0;
			this.txtCurrentRate.Name = "txtCurrentRate";
			this.txtCurrentRate.Size = new System.Drawing.Size(96, 19);
			this.txtCurrentRate.TabIndex = 4;
			// this.txtCurrentRate.Text = "0.000";
			// 
			// System.Windows.Forms.Label2
			// 
			this.Label2.AllowDrop = true;
			this.Label2.BackColor = System.Drawing.SystemColors.Window;
			this.Label2.Text = "New Rate";
			this.Label2.ForeColor = System.Drawing.Color.Black;
			this.Label2.Location = new System.Drawing.Point(21, 33);
			this.Label2.Name = "System.Windows.Forms.Label2";
			this.Label2.Size = new System.Drawing.Size(47, 13);
			this.Label2.TabIndex = 11;
			// 
			// System.Windows.Forms.Label3
			// 
			this.Label3.AllowDrop = true;
			this.Label3.BackColor = System.Drawing.SystemColors.Window;
			this.Label3.Text = "Current Rate";
			this.Label3.ForeColor = System.Drawing.Color.Black;
			this.Label3.Location = new System.Drawing.Point(21, 12);
			// this.Label3.mLabelId = 948;
			this.Label3.Name = "System.Windows.Forms.Label3";
			this.Label3.Size = new System.Drawing.Size(63, 13);
			this.Label3.TabIndex = 12;
			// 
			// txtNewRate
			// 
			this.txtNewRate.AllowDrop = true;
			// this.txtNewRate.DisplayFormat = "####0.000###;;0.000;0.000";
			// this.txtNewRate.Format = "###########0.000";
			this.txtNewRate.Location = new System.Drawing.Point(90, 30);
			// this.txtNewRate.MaxValue = 2147483647;
			// this.txtNewRate.MinValue = 0;
			this.txtNewRate.Name = "txtNewRate";
			this.txtNewRate.Size = new System.Drawing.Size(96, 19);
			this.txtNewRate.TabIndex = 5;
			// this.txtNewRate.Text = "0.000";
			// 
			// txtProductCd
			// 
			this.txtProductCd.AllowDrop = true;
			this.txtProductCd.BackColor = System.Drawing.Color.White;
			this.txtProductCd.ForeColor = System.Drawing.Color.Black;
			this.txtProductCd.Location = new System.Drawing.Point(101, 32);
			this.txtProductCd.Name = "txtProductCd";
			// this.txtProductCd.ShowButton = true;
			this.txtProductCd.Size = new System.Drawing.Size(101, 19);
			this.txtProductCd.TabIndex = 1;
			this.txtProductCd.Text = "";
			// this.this.txtProductCd.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtProductCd_DropButtonClick);
			// this.txtProductCd.Leave += new System.EventHandler(this.txtProductCd_Leave);
			// 
			// txtLedgerCd
			// 
			this.txtLedgerCd.AllowDrop = true;
			this.txtLedgerCd.BackColor = System.Drawing.Color.White;
			this.txtLedgerCd.ForeColor = System.Drawing.Color.Black;
			this.txtLedgerCd.Location = new System.Drawing.Point(101, 11);
			this.txtLedgerCd.Name = "txtLedgerCd";
			// this.txtLedgerCd.ShowButton = true;
			this.txtLedgerCd.Size = new System.Drawing.Size(101, 19);
			this.txtLedgerCd.TabIndex = 0;
			this.txtLedgerCd.Text = "";
			// this.this.txtLedgerCd.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtLedgerCd_DropButtonClick);
			// this.txtLedgerCd.Leave += new System.EventHandler(this.txtLedgerCd_Leave);
			// 
			// lblLocationCode
			// 
			this.lblLocationCode.AllowDrop = true;
			this.lblLocationCode.BackColor = System.Drawing.SystemColors.Window;
			this.lblLocationCode.Text = "Product Code";
			this.lblLocationCode.ForeColor = System.Drawing.Color.Black;
			this.lblLocationCode.Location = new System.Drawing.Point(10, 34);
			// // this.lblLocationCode.mLabelId = 416;
			this.lblLocationCode.Name = "lblLocationCode";
			this.lblLocationCode.Size = new System.Drawing.Size(65, 14);
			this.lblLocationCode.TabIndex = 8;
			// 
			// lblMasterCode
			// 
			this.lblMasterCode.AllowDrop = true;
			this.lblMasterCode.BackColor = System.Drawing.SystemColors.Window;
			this.lblMasterCode.Text = "Ledger Name";
			this.lblMasterCode.ForeColor = System.Drawing.Color.Black;
			this.lblMasterCode.Location = new System.Drawing.Point(10, 13);
			this.lblMasterCode.Name = "lblMasterCode";
			this.lblMasterCode.Size = new System.Drawing.Size(64, 14);
			this.lblMasterCode.TabIndex = 9;
			// 
			// txtProductName
			// 
			this.txtProductName.AllowDrop = true;
			this.txtProductName.Location = new System.Drawing.Point(204, 32);
			this.txtProductName.Name = "txtProductName";
			this.txtProductName.Size = new System.Drawing.Size(201, 19);
			this.txtProductName.TabIndex = 16;
			// 
			// txtLedgerName
			// 
			this.txtLedgerName.AllowDrop = true;
			this.txtLedgerName.Location = new System.Drawing.Point(204, 11);
			this.txtLedgerName.Name = "txtLedgerName";
			this.txtLedgerName.Size = new System.Drawing.Size(201, 19);
			this.txtLedgerName.TabIndex = 17;
			// 
			// frmICSVoucherRateVariation
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.FromArgb(241, 242, 234);
			this.ClientSize = new System.Drawing.Size(473, 240);
			this.Controls.Add(this.cmdOKCancel);
			this.Controls.Add(this.cntMainParameter);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			//this.Icon = (System.Drawing.Icon) resources.GetObject("frmICSVoucherRateVariation.Icon");
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(145, 182);
			this.MaximizeBox = false;
			this.MinimizeBox = true;
			this.Name = "frmICSVoucherRateVariation";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Voucher Price Variation";
			// this.Activated += new System.EventHandler(this.frmICSVoucherRateVariation_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
			// this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
			//((System.ComponentModel.ISupportInitialize) this.cntMainParameter).EndInit();
			this.cntMainParameter.ResumeLayout(false);
			this.fraDateRange.ResumeLayout(false);
			this.Frame1.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		// 
		#endregion
	}
}//ENDSHERE
