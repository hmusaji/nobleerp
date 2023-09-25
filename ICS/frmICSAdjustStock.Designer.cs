
namespace Xtreme
{
	partial class frmICSAdjustStock
	{

		#region "Upgrade Support "
		private static frmICSAdjustStock m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmICSAdjustStock DefInstance
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
		public static frmICSAdjustStock CreateInstance()
		{
			frmICSAdjustStock theInstance = new frmICSAdjustStock();
			
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
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "cmdOKCancel", "chkIncludeAllLocations", "lblDateRange", "lblToDate", "txtAsOnDate", "fraDateRange", "txtLocationCode", "txtVoucherType", "txtTransactionDate", "System.Windows.Forms.Label1", "lblLocationCode", "lblMasterCode", "txtLocationName", "txtVoucherName", "cntMainParameter"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public UCOkCancel cmdOKCancel;
		public System.Windows.Forms.CheckBox chkIncludeAllLocations;
		public System.Windows.Forms.Label lblDateRange;
		public System.Windows.Forms.Label lblToDate;
		public Syncfusion.WinForms.Input.SfDateTimeEdit txtAsOnDate;
		public System.Windows.Forms.Panel fraDateRange;
		public System.Windows.Forms.TextBox txtLocationCode;
		public System.Windows.Forms.TextBox txtVoucherType;
		public Syncfusion.WinForms.Input.SfDateTimeEdit txtTransactionDate;
		public System.Windows.Forms.Label System.Windows.Forms.Label1;
		public System.Windows.Forms.Label lblLocationCode;
		public System.Windows.Forms.Label lblMasterCode;
		public System.Windows.Forms.Label txtLocationName;
		public System.Windows.Forms.Label txtVoucherName;
		public AxTDBContainer3D6.AxTDBContainer3D cntMainParameter;
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmICSAdjustStock));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this.cmdOKCancel = new UCOkCancel();
			this.cntMainParameter = new AxTDBContainer3D6.AxTDBContainer3D();
			this.chkIncludeAllLocations = new System.Windows.Forms.CheckBox();
			this.lblDateRange = new System.Windows.Forms.Label();
			this.fraDateRange = new System.Windows.Forms.Panel();
			this.lblToDate = new System.Windows.Forms.Label();
			this.txtAsOnDate = new Syncfusion.WinForms.Input.SfDateTimeEdit();
			this.txtLocationCode = new System.Windows.Forms.TextBox();
			this.txtVoucherType = new System.Windows.Forms.TextBox();
			this.txtTransactionDate = new Syncfusion.WinForms.Input.SfDateTimeEdit();
			this.System.Windows.Forms.Label1 = new System.Windows.Forms.Label();
			this.lblLocationCode = new System.Windows.Forms.Label();
			this.lblMasterCode = new System.Windows.Forms.Label();
			this.txtLocationName = new System.Windows.Forms.Label();
			this.txtVoucherName = new System.Windows.Forms.Label();
			// //((System.ComponentModel.ISupportInitialize) this.cntMainParameter).BeginInit();
			this.cntMainParameter.SuspendLayout();
			this.fraDateRange.SuspendLayout();
			this.SuspendLayout();
			// 
			// cmdOKCancel
			// 
			this.cmdOKCancel.AllowDrop = true;
			this.cmdOKCancel.DisplayButton = 0;
			this.cmdOKCancel.Location = new System.Drawing.Point(141, 202);
			this.cmdOKCancel.Name = "cmdOKCancel";
			this.cmdOKCancel.OkCaption = "&Ok";
			this.cmdOKCancel.Size = new System.Drawing.Size(206, 31);
			this.cmdOKCancel.TabIndex = 4;
			this.cmdOKCancel.CancelClick += new UCOkCancel.CancelClickHandler(this.cmdOKCancel_CancelClick);
			this.cmdOKCancel.OKClick += new UCOkCancel.OKClickHandler(this.cmdOKCancel_OKClick);
			// 
			// cntMainParameter
			// 
			this.cntMainParameter.AllowDrop = true;
			this.cntMainParameter.Controls.Add(this.chkIncludeAllLocations);
			this.cntMainParameter.Controls.Add(this.lblDateRange);
			this.cntMainParameter.Controls.Add(this.fraDateRange);
			this.cntMainParameter.Controls.Add(this.txtLocationCode);
			this.cntMainParameter.Controls.Add(this.txtVoucherType);
			this.cntMainParameter.Controls.Add(this.txtTransactionDate);
			this.cntMainParameter.Controls.Add(this.System.Windows.Forms.Label1);
			this.cntMainParameter.Controls.Add(this.lblLocationCode);
			this.cntMainParameter.Controls.Add(this.lblMasterCode);
			this.cntMainParameter.Controls.Add(this.txtLocationName);
			this.cntMainParameter.Controls.Add(this.txtVoucherName);
			this.cntMainParameter.Location = new System.Drawing.Point(18, 15);
			this.cntMainParameter.Name = "cntMainParameter";
			("cntMainParameter.OcxState");
			this.cntMainParameter.Size = new System.Drawing.Size(561, 165);
			this.cntMainParameter.TabIndex = 5;
			// 
			// chkIncludeAllLocations
			// 
			this.chkIncludeAllLocations.AllowDrop = true;
			this.chkIncludeAllLocations.Appearance = System.Windows.Forms.Appearance.Normal;
			this.chkIncludeAllLocations.BackColor = System.Drawing.Color.FromArgb(241, 242, 234);
			this.chkIncludeAllLocations.CausesValidation = true;
			this.chkIncludeAllLocations.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkIncludeAllLocations.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this.chkIncludeAllLocations.Enabled = true;
			this.chkIncludeAllLocations.ForeColor = System.Drawing.SystemColors.ControlText;
			this.chkIncludeAllLocations.Location = new System.Drawing.Point(416, 34);
			this.chkIncludeAllLocations.Name = "chkIncludeAllLocations";
			this.chkIncludeAllLocations.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.chkIncludeAllLocations.Size = new System.Drawing.Size(119, 17);
			this.chkIncludeAllLocations.TabIndex = 14;
			this.chkIncludeAllLocations.TabStop = true;
			this.chkIncludeAllLocations.Text = "Include All Locations";
			this.chkIncludeAllLocations.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkIncludeAllLocations.Visible = true;
			this.chkIncludeAllLocations.CheckStateChanged += new System.EventHandler(this.chkIncludeAllLocations_CheckStateChanged);
			// 
			// lblDateRange
			// 
			this.lblDateRange.AllowDrop = true;
			this.lblDateRange.BackColor = System.Drawing.SystemColors.Window;
			this.lblDateRange.Text = "  Date Range ";
			this.lblDateRange.ForeColor = System.Drawing.Color.Black;
			this.lblDateRange.Location = new System.Drawing.Point(18, 84);
			// this.lblDateRange.mLabelId = 949;
			this.lblDateRange.Name = "lblDateRange";
			this.lblDateRange.Size = new System.Drawing.Size(66, 13);
			this.lblDateRange.TabIndex = 6;
			// 
			// fraDateRange
			// 
			this.fraDateRange.AllowDrop = true;
			this.fraDateRange.BackColor = System.Drawing.Color.FromArgb(241, 242, 234);
			this.fraDateRange.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.fraDateRange.Controls.Add(this.lblToDate);
			this.fraDateRange.Controls.Add(this.txtAsOnDate);
			this.fraDateRange.Enabled = true;
			this.fraDateRange.ForeColor = System.Drawing.SystemColors.WindowText;
			this.fraDateRange.Location = new System.Drawing.Point(9, 92);
			this.fraDateRange.Name = "fraDateRange";
			this.fraDateRange.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.fraDateRange.Size = new System.Drawing.Size(207, 53);
			this.fraDateRange.TabIndex = 7;
			this.fraDateRange.Visible = true;
			// 
			// lblToDate
			// 
			this.lblToDate.AllowDrop = true;
			this.lblToDate.BackColor = System.Drawing.SystemColors.Window;
			this.lblToDate.Text = "As On Date";
			this.lblToDate.ForeColor = System.Drawing.Color.Black;
			this.lblToDate.Location = new System.Drawing.Point(9, 23);
			this.lblToDate.Name = "lblToDate";
			this.lblToDate.Size = new System.Drawing.Size(55, 13);
			this.lblToDate.TabIndex = 8;
			// 
			// txtAsOnDate
			// 
			this.txtAsOnDate.AllowDrop = true;
			// this.txtAsOnDate.CheckDateRange = false;
			this.txtAsOnDate.Location = new System.Drawing.Point(85, 20);
			// this.txtAsOnDate.MaxDate = 2958465;
			// this.txtAsOnDate.MinDate = 2;
			this.txtAsOnDate.Name = "txtAsOnDate";
			this.txtAsOnDate.Size = new System.Drawing.Size(96, 19);
			this.txtAsOnDate.TabIndex = 3;
			this.txtAsOnDate.Text = "7/18/2001";
			this.txtAsOnDate.Value = 37090;
			// 
			// txtLocationCode
			// 
			this.txtLocationCode.AllowDrop = true;
			this.txtLocationCode.BackColor = System.Drawing.Color.White;
			this.txtLocationCode.ForeColor = System.Drawing.Color.Black;
			this.txtLocationCode.Location = new System.Drawing.Point(101, 32);
			this.txtLocationCode.Name = "txtLocationCode";
			// this.txtLocationCode.ShowButton = true;
			this.txtLocationCode.Size = new System.Drawing.Size(101, 19);
			this.txtLocationCode.TabIndex = 1;
			this.txtLocationCode.Text = "";
			// this.this.txtLocationCode.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtLocationCode_DropButtonClick);
			// this.txtLocationCode.Leave += new System.EventHandler(this.txtLocationCode_Leave);
			// 
			// txtVoucherType
			// 
			this.txtVoucherType.AllowDrop = true;
			this.txtVoucherType.BackColor = System.Drawing.Color.White;
			this.txtVoucherType.ForeColor = System.Drawing.Color.Black;
			this.txtVoucherType.Location = new System.Drawing.Point(101, 11);
			this.txtVoucherType.Name = "txtVoucherType";
			// this.txtVoucherType.ShowButton = true;
			this.txtVoucherType.Size = new System.Drawing.Size(101, 19);
			this.txtVoucherType.TabIndex = 0;
			this.txtVoucherType.Text = "";
			// this.this.txtVoucherType.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtVoucherType_DropButtonClick);
			// this.txtVoucherType.Leave += new System.EventHandler(this.txtVoucherType_Leave);
			// 
			// txtTransactionDate
			// 
			this.txtTransactionDate.AllowDrop = true;
			// this.txtTransactionDate.CheckDateRange = false;
			this.txtTransactionDate.Location = new System.Drawing.Point(101, 53);
			// this.txtTransactionDate.MaxDate = 2958465;
			// this.txtTransactionDate.MinDate = 2;
			this.txtTransactionDate.Name = "txtTransactionDate";
			this.txtTransactionDate.Size = new System.Drawing.Size(101, 19);
			this.txtTransactionDate.TabIndex = 2;
			this.txtTransactionDate.Text = "3/4/2002";
			this.txtTransactionDate.Value = 37319;
			// 
			// System.Windows.Forms.Label1
			// 
			this.System.Windows.Forms.Label1.AllowDrop = true;
			this.System.Windows.Forms.Label1.BackColor = System.Drawing.SystemColors.Window;
			this.System.Windows.Forms.Label1.Caption = "Transaction Date";
			this.System.Windows.Forms.Label1.ForeColor = System.Drawing.Color.Black;
			this.System.Windows.Forms.Label1.Location = new System.Drawing.Point(10, 56);
			this.System.Windows.Forms.Label1.mLabelId = 948;
			this.System.Windows.Forms.Label1.Name = "System.Windows.Forms.Label1";
			this.System.Windows.Forms.Label1.Size = new System.Drawing.Size(82, 13);
			this.System.Windows.Forms.Label1.TabIndex = 9;
			// 
			// lblLocationCode
			// 
			this.lblLocationCode.AllowDrop = true;
			this.lblLocationCode.BackColor = System.Drawing.SystemColors.Window;
			this.lblLocationCode.Text = "Location Code";
			this.lblLocationCode.ForeColor = System.Drawing.Color.Black;
			this.lblLocationCode.Location = new System.Drawing.Point(10, 35);
			// this.lblLocationCode.mLabelId = 416;
			this.lblLocationCode.Name = "lblLocationCode";
			this.lblLocationCode.Size = new System.Drawing.Size(69, 14);
			this.lblLocationCode.TabIndex = 10;
			// 
			// lblMasterCode
			// 
			this.lblMasterCode.AllowDrop = true;
			this.lblMasterCode.BackColor = System.Drawing.SystemColors.Window;
			this.lblMasterCode.Text = "Voucher Type";
			this.lblMasterCode.ForeColor = System.Drawing.Color.Black;
			this.lblMasterCode.Location = new System.Drawing.Point(10, 13);
			this.lblMasterCode.Name = "lblMasterCode";
			this.lblMasterCode.Size = new System.Drawing.Size(69, 14);
			this.lblMasterCode.TabIndex = 11;
			// 
			// txtLocationName
			// 
			this.txtLocationName.AllowDrop = true;
			this.txtLocationName.Location = new System.Drawing.Point(204, 32);
			this.txtLocationName.Name = "txtLocationName";
			this.txtLocationName.Size = new System.Drawing.Size(201, 19);
			this.txtLocationName.TabIndex = 12;
			// 
			// txtVoucherName
			// 
			this.txtVoucherName.AllowDrop = true;
			this.txtVoucherName.Location = new System.Drawing.Point(204, 11);
			this.txtVoucherName.Name = "txtVoucherName";
			this.txtVoucherName.Size = new System.Drawing.Size(201, 19);
			this.txtVoucherName.TabIndex = 13;
			// 
			// frmICSAdjustStock
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.FromArgb(241, 242, 234);
			this.ClientSize = new System.Drawing.Size(597, 246);
			this.Controls.Add(this.cmdOKCancel);
			this.Controls.Add(this.cntMainParameter);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			//this.Icon = (System.Drawing.Icon) resources.GetObject("frmICSAdjustStock.Icon");
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(83, 142);
			this.MaximizeBox = true;
			this.MinimizeBox = true;
			this.Name = "frmICSAdjustStock";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Adjust Negative Stock";
			// this.Activated += new System.EventHandler(this.frmICSAdjustStock_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
			// this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
			//((System.ComponentModel.ISupportInitialize) this.cntMainParameter).EndInit();
			this.cntMainParameter.ResumeLayout(false);
			this.fraDateRange.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		void ReLoadForm(bool addEvents)
		{
			//This form is an MDI child.
			//This code simulates the VB6 
			// functionality of automatically
			// loading and showing an MDI
			// child's parent.
			this.MdiParent = Xtreme.frmSysMain.DefInstance;
			Xtreme.frmSysMain.DefInstance.Show();
		}
		#endregion
	}
}