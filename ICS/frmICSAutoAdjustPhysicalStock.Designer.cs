
namespace Xtreme
{
	partial class frmICSAutoAdjustPhysicalStock
	{

		#region "Upgrade Support "
		private static frmICSAutoAdjustPhysicalStock m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmICSAutoAdjustPhysicalStock DefInstance
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
		public static frmICSAutoAdjustPhysicalStock CreateInstance()
		{
			frmICSAutoAdjustPhysicalStock theInstance = new frmICSAutoAdjustPhysicalStock();
			
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
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "lblToDate", "System.Windows.Forms.Label2", "txtToDate", "txtFromDate", "fraDateRange", "txtToVoucherNo", "lblToVoucherNo", "txtFromVoucherNo", "lblFromVoucherNo", "fraVoucherRange", "chkIncludeProcessed", "cmdOKCancel", "txtLocationCode", "txtBatchCode", "txtTransactionDate", "System.Windows.Forms.Label1", "lblLocationCode", "lblMasterCode", "txtBatchName", "txtLocationName"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public System.Windows.Forms.Label lblToDate;
		public System.Windows.Forms.Label Label2;
		public Syncfusion.WinForms.Input.SfDateTimeEdit txtToDate;
		public Syncfusion.WinForms.Input.SfDateTimeEdit txtFromDate;
		public System.Windows.Forms.GroupBox fraDateRange;
		public System.Windows.Forms.TextBox txtToVoucherNo;
		public System.Windows.Forms.Label lblToVoucherNo;
		public System.Windows.Forms.TextBox txtFromVoucherNo;
		public System.Windows.Forms.Label lblFromVoucherNo;
		public System.Windows.Forms.GroupBox fraVoucherRange;
		public System.Windows.Forms.CheckBox chkIncludeProcessed;
		public UCOkCancel cmdOKCancel;
		public System.Windows.Forms.TextBox txtLocationCode;
		public System.Windows.Forms.TextBox txtBatchCode;
		public Syncfusion.WinForms.Input.SfDateTimeEdit txtTransactionDate;
		public System.Windows.Forms.Label Label1;
		public System.Windows.Forms.Label lblLocationCode;
		public System.Windows.Forms.Label lblMasterCode;
		public System.Windows.Forms.Label txtBatchName;
		public System.Windows.Forms.Label txtLocationName;
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmICSAutoAdjustPhysicalStock));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this.fraDateRange = new System.Windows.Forms.GroupBox();
			this.lblToDate = new System.Windows.Forms.Label();
			this.Label2 = new System.Windows.Forms.Label();
			this.txtToDate = new Syncfusion.WinForms.Input.SfDateTimeEdit();
			this.txtFromDate = new Syncfusion.WinForms.Input.SfDateTimeEdit();
			this.fraVoucherRange = new System.Windows.Forms.GroupBox();
			this.txtToVoucherNo = new System.Windows.Forms.TextBox();
			this.lblToVoucherNo = new System.Windows.Forms.Label();
			this.txtFromVoucherNo = new System.Windows.Forms.TextBox();
			this.lblFromVoucherNo = new System.Windows.Forms.Label();
			this.chkIncludeProcessed = new System.Windows.Forms.CheckBox();
			this.cmdOKCancel = new UCOkCancel();
			this.txtLocationCode = new System.Windows.Forms.TextBox();
			this.txtBatchCode = new System.Windows.Forms.TextBox();
			this.txtTransactionDate = new Syncfusion.WinForms.Input.SfDateTimeEdit();
			this.Label1 = new System.Windows.Forms.Label();
			this.lblLocationCode = new System.Windows.Forms.Label();
			this.lblMasterCode = new System.Windows.Forms.Label();
			this.txtBatchName = new System.Windows.Forms.Label();
			this.txtLocationName = new System.Windows.Forms.Label();
			this.fraDateRange.SuspendLayout();
			this.fraVoucherRange.SuspendLayout();
			this.SuspendLayout();
			// 
			// fraDateRange
			// 
			this.fraDateRange.AllowDrop = true;
			this.fraDateRange.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.fraDateRange.Controls.Add(this.lblToDate);
			this.fraDateRange.Controls.Add(this.Label2);
			this.fraDateRange.Controls.Add(this.txtToDate);
			this.fraDateRange.Controls.Add(this.txtFromDate);
			this.fraDateRange.Enabled = true;
			this.fraDateRange.ForeColor = System.Drawing.SystemColors.WindowText;
			this.fraDateRange.Location = new System.Drawing.Point(30, 89);
			this.fraDateRange.Name = "fraDateRange";
			this.fraDateRange.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.fraDateRange.Size = new System.Drawing.Size(207, 71);
			this.fraDateRange.TabIndex = 7;
			this.fraDateRange.Text = " Physical Count Date ";
			this.fraDateRange.Visible = true;
			// 
			// lblToDate
			// 
			this.lblToDate.AllowDrop = true;
			this.lblToDate.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			// this.lblToDate.Text = "From Date";
			this.lblToDate.ForeColor = System.Drawing.Color.Black;
			this.lblToDate.Location = new System.Drawing.Point(9, 23);
			this.lblToDate.Name = "lblToDate";
			this.lblToDate.Size = new System.Drawing.Size(50, 13);
			this.lblToDate.TabIndex = 8;
			// 
			// System.Windows.Forms.Label2
			// 
			this.Label2.AllowDrop = true;
			this.Label2.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.Label2.Text = "To Date";
			this.Label2.ForeColor = System.Drawing.Color.Black;
			this.Label2.Location = new System.Drawing.Point(9, 44);
			this.Label2.Name = "System.Windows.Forms.Label2";
			this.Label2.Size = new System.Drawing.Size(38, 13);
			this.Label2.TabIndex = 9;
			// 
			// txtToDate
			// 
			this.txtToDate.AllowDrop = true;
			// this.txtToDate.CheckDateRange = false;
			this.txtToDate.Location = new System.Drawing.Point(85, 41);
			// this.txtToDate.MaxDate = 2958465;
			// this.txtToDate.MinDate = 2;
			this.txtToDate.Name = "txtToDate";
			this.txtToDate.Size = new System.Drawing.Size(96, 19);
			this.txtToDate.TabIndex = 10;
			// this.txtToDate.Text = "07/18/2001";
			// this.txtToDate.Value = 37090;
			// 
			// txtFromDate
			// 
			this.txtFromDate.AllowDrop = true;
			// this.txtFromDate.CheckDateRange = false;
			this.txtFromDate.Location = new System.Drawing.Point(85, 20);
			// this.txtFromDate.MaxDate = 2958465;
			// this.txtFromDate.MinDate = 2;
			this.txtFromDate.Name = "txtFromDate";
			this.txtFromDate.Size = new System.Drawing.Size(96, 19);
			this.txtFromDate.TabIndex = 11;
			// this.txtFromDate.Text = "07/18/2001";
			// this.txtFromDate.Value = 37090;
			// 
			// fraVoucherRange
			// 
			this.fraVoucherRange.AllowDrop = true;
			this.fraVoucherRange.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.fraVoucherRange.Controls.Add(this.txtToVoucherNo);
			this.fraVoucherRange.Controls.Add(this.lblToVoucherNo);
			this.fraVoucherRange.Controls.Add(this.txtFromVoucherNo);
			this.fraVoucherRange.Controls.Add(this.lblFromVoucherNo);
			this.fraVoucherRange.Enabled = true;
			this.fraVoucherRange.ForeColor = System.Drawing.SystemColors.ControlText;
			this.fraVoucherRange.Location = new System.Drawing.Point(255, 89);
			this.fraVoucherRange.Name = "fraVoucherRange";
			this.fraVoucherRange.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.fraVoucherRange.Size = new System.Drawing.Size(207, 71);
			this.fraVoucherRange.TabIndex = 2;
			this.fraVoucherRange.Text = " Physical Count No ";
			this.fraVoucherRange.Visible = true;
			// 
			// txtToVoucherNo
			// 
			this.txtToVoucherNo.AllowDrop = true;
			this.txtToVoucherNo.BackColor = System.Drawing.Color.White;
			// this.txtToVoucherNo.bolNumericOnly = true;
			this.txtToVoucherNo.ForeColor = System.Drawing.Color.Black;
			this.txtToVoucherNo.Location = new System.Drawing.Point(108, 43);
			this.txtToVoucherNo.MaxLength = 12;
			// this.txtToVoucherNo.mDropDownType = (System.Windows.Forms.TextBox.DropDownTypes) 0;
			this.txtToVoucherNo.Name = "txtToVoucherNo";
			this.txtToVoucherNo.Size = new System.Drawing.Size(88, 19);
			this.txtToVoucherNo.TabIndex = 3;
			this.txtToVoucherNo.Text = "";
			// this.this.txtToVoucherNo.Watermark = "";
			// this.txtToVoucherNo.Leave += new System.EventHandler(this.txtToVoucherNo_Leave);
			// 
			// lblToVoucherNo
			// 
			this.lblToVoucherNo.AllowDrop = true;
			this.lblToVoucherNo.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblToVoucherNo.Text = "To Voucher No";
			this.lblToVoucherNo.ForeColor = System.Drawing.Color.Black;
			this.lblToVoucherNo.Location = new System.Drawing.Point(12, 46);
			// // this.lblToVoucherNo.mLabelId = 954;
			this.lblToVoucherNo.Name = "lblToVoucherNo";
			this.lblToVoucherNo.Size = new System.Drawing.Size(70, 13);
			this.lblToVoucherNo.TabIndex = 4;
			// 
			// txtFromVoucherNo
			// 
			this.txtFromVoucherNo.AllowDrop = true;
			this.txtFromVoucherNo.BackColor = System.Drawing.Color.White;
			// this.txtFromVoucherNo.bolNumericOnly = true;
			this.txtFromVoucherNo.ForeColor = System.Drawing.Color.Black;
			this.txtFromVoucherNo.Location = new System.Drawing.Point(108, 22);
			this.txtFromVoucherNo.MaxLength = 12;
			// this.txtFromVoucherNo.mDropDownType = (System.Windows.Forms.TextBox.DropDownTypes) 0;
			this.txtFromVoucherNo.Name = "txtFromVoucherNo";
			this.txtFromVoucherNo.Size = new System.Drawing.Size(88, 19);
			this.txtFromVoucherNo.TabIndex = 5;
			this.txtFromVoucherNo.Text = "";
			// this.this.txtFromVoucherNo.Watermark = "";
			// this.txtFromVoucherNo.Leave += new System.EventHandler(this.txtFromVoucherNo_Leave);
			// 
			// lblFromVoucherNo
			// 
			this.lblFromVoucherNo.AllowDrop = true;
			this.lblFromVoucherNo.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblFromVoucherNo.Text = "From Voucher No";
			this.lblFromVoucherNo.ForeColor = System.Drawing.Color.Black;
			this.lblFromVoucherNo.Location = new System.Drawing.Point(12, 25);
			// // this.lblFromVoucherNo.mLabelId = 952;
			this.lblFromVoucherNo.Name = "lblFromVoucherNo";
			this.lblFromVoucherNo.Size = new System.Drawing.Size(82, 13);
			this.lblFromVoucherNo.TabIndex = 6;
			// 
			// chkIncludeProcessed
			// 
			this.chkIncludeProcessed.AllowDrop = true;
			this.chkIncludeProcessed.Appearance = System.Windows.Forms.Appearance.Normal;
			this.chkIncludeProcessed.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.chkIncludeProcessed.CausesValidation = true;
			this.chkIncludeProcessed.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkIncludeProcessed.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this.chkIncludeProcessed.Enabled = true;
			this.chkIncludeProcessed.ForeColor = System.Drawing.SystemColors.ControlText;
			this.chkIncludeProcessed.Location = new System.Drawing.Point(307, 57);
			this.chkIncludeProcessed.Name = "chkIncludeProcessed";
			this.chkIncludeProcessed.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.chkIncludeProcessed.Size = new System.Drawing.Size(117, 17);
			this.chkIncludeProcessed.TabIndex = 1;
			this.chkIncludeProcessed.TabStop = true;
			this.chkIncludeProcessed.Text = "Include Processed";
			this.chkIncludeProcessed.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkIncludeProcessed.Visible = true;
			// 
			// cmdOKCancel
			// 
			this.cmdOKCancel.AllowDrop = true;
			this.cmdOKCancel.DisplayButton = 0;
			this.cmdOKCancel.Location = new System.Drawing.Point(124, 178);
			this.cmdOKCancel.Name = "cmdOKCancel";
			this.cmdOKCancel.OkCaption = "&Ok";
			this.cmdOKCancel.Size = new System.Drawing.Size(206, 31);
			this.cmdOKCancel.TabIndex = 0;
			this.cmdOKCancel.CancelClick += new UCOkCancel.CancelClickHandler(this.cmdOKCancel_CancelClick);
			this.cmdOKCancel.OKClick += new UCOkCancel.OKClickHandler(this.cmdOKCancel_OKClick);
			// 
			// txtLocationCode
			// 
			this.txtLocationCode.AllowDrop = true;
			this.txtLocationCode.BackColor = System.Drawing.Color.White;
			this.txtLocationCode.ForeColor = System.Drawing.Color.Black;
			this.txtLocationCode.Location = new System.Drawing.Point(120, 33);
			this.txtLocationCode.Name = "txtLocationCode";
			// this.txtLocationCode.ShowButton = true;
			this.txtLocationCode.Size = new System.Drawing.Size(101, 19);
			this.txtLocationCode.TabIndex = 12;
			this.txtLocationCode.Text = "";
			// this.this.txtLocationCode.Watermark = "";
			// this.this.txtLocationCode.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtLocationCode_DropButtonClick);
			// this.txtLocationCode.Leave += new System.EventHandler(this.txtLocationCode_Leave);
			// 
			// txtBatchCode
			// 
			this.txtBatchCode.AllowDrop = true;
			this.txtBatchCode.BackColor = System.Drawing.Color.White;
			this.txtBatchCode.ForeColor = System.Drawing.Color.Black;
			this.txtBatchCode.Location = new System.Drawing.Point(120, 12);
			this.txtBatchCode.Name = "txtBatchCode";
			// this.txtBatchCode.ShowButton = true;
			this.txtBatchCode.Size = new System.Drawing.Size(101, 19);
			this.txtBatchCode.TabIndex = 13;
			this.txtBatchCode.Text = "";
			// this.this.txtBatchCode.Watermark = "";
			// this.this.txtBatchCode.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtBatchCode_DropButtonClick);
			// this.txtBatchCode.Leave += new System.EventHandler(this.txtBatchCode_Leave);
			// 
			// txtTransactionDate
			// 
			this.txtTransactionDate.AllowDrop = true;
			// this.txtTransactionDate.CheckDateRange = false;
			this.txtTransactionDate.Location = new System.Drawing.Point(120, 54);
			// this.txtTransactionDate.MaxDate = 2958465;
			// this.txtTransactionDate.MinDate = 2;
			this.txtTransactionDate.Name = "txtTransactionDate";
			this.txtTransactionDate.Size = new System.Drawing.Size(101, 19);
			this.txtTransactionDate.TabIndex = 14;
			// this.txtTransactionDate.Text = "03/04/2002";
			// this.txtTransactionDate.Value = 37319;
			// 
			// System.Windows.Forms.Label1
			// 
			this.Label1.AllowDrop = true;
			this.Label1.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.Label1.Text = "Transaction Date";
			this.Label1.ForeColor = System.Drawing.Color.Black;
			this.Label1.Location = new System.Drawing.Point(29, 57);
			// this.Label1.mLabelId = 948;
			this.Label1.Name = "System.Windows.Forms.Label1";
			this.Label1.Size = new System.Drawing.Size(82, 13);
			this.Label1.TabIndex = 15;
			// 
			// lblLocationCode
			// 
			this.lblLocationCode.AllowDrop = true;
			this.lblLocationCode.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblLocationCode.Text = "Location Code";
			this.lblLocationCode.ForeColor = System.Drawing.Color.Black;
			this.lblLocationCode.Location = new System.Drawing.Point(29, 35);
			// // this.lblLocationCode.mLabelId = 416;
			this.lblLocationCode.Name = "lblLocationCode";
			this.lblLocationCode.Size = new System.Drawing.Size(69, 14);
			this.lblLocationCode.TabIndex = 16;
			// 
			// lblMasterCode
			// 
			this.lblMasterCode.AllowDrop = true;
			this.lblMasterCode.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblMasterCode.Text = "Batch Code";
			this.lblMasterCode.ForeColor = System.Drawing.Color.Black;
			this.lblMasterCode.Location = new System.Drawing.Point(29, 14);
			this.lblMasterCode.Name = "lblMasterCode";
			this.lblMasterCode.Size = new System.Drawing.Size(56, 14);
			this.lblMasterCode.TabIndex = 17;
			// 
			// txtBatchName
			// 
			this.txtBatchName.AllowDrop = true;
			this.txtBatchName.Location = new System.Drawing.Point(223, 12);
			this.txtBatchName.Name = "txtBatchName";
			this.txtBatchName.Size = new System.Drawing.Size(201, 19);
			this.txtBatchName.TabIndex = 18;
			// 
			// txtLocationName
			// 
			this.txtLocationName.AllowDrop = true;
			this.txtLocationName.Location = new System.Drawing.Point(223, 33);
			this.txtLocationName.Name = "txtLocationName";
			this.txtLocationName.Size = new System.Drawing.Size(201, 19);
			this.txtLocationName.TabIndex = 19;
			// 
			// frmICSAutoAdjustPhysicalStock
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.ClientSize = new System.Drawing.Size(965, 476);
			this.ControlBox = false;
			this.Controls.Add(this.fraDateRange);
			this.Controls.Add(this.fraVoucherRange);
			this.Controls.Add(this.chkIncludeProcessed);
			this.Controls.Add(this.cmdOKCancel);
			this.Controls.Add(this.txtLocationCode);
			this.Controls.Add(this.txtBatchCode);
			this.Controls.Add(this.txtTransactionDate);
			this.Controls.Add(this.Label1);
			this.Controls.Add(this.lblLocationCode);
			this.Controls.Add(this.lblMasterCode);
			this.Controls.Add(this.txtBatchName);
			this.Controls.Add(this.txtLocationName);
			//this.Icon = (System.Drawing.Icon) resources.GetObject("frmICSAutoAdjustPhysicalStock.Icon");
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(126, 152);
			this.MaximizeBox = true;
			this.MinimizeBox = true;
			this.Name = "frmICSAutoAdjustPhysicalStock";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Auto Adjust Physical Stock";
			// this.Activated += new System.EventHandler(this.frmICSAutoAdjustPhysicalStock_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
			// this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
			this.fraDateRange.ResumeLayout(false);
			this.fraVoucherRange.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		// 
		#endregion
	}
}//ENDSHERE
