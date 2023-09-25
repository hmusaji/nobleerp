
namespace Xtreme
{
	partial class frmARAPAutoAdjustVoucher
	{

		#region "Upgrade Support "
		private static frmARAPAutoAdjustVoucher m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmARAPAutoAdjustVoucher DefInstance
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
		public static frmARAPAutoAdjustVoucher CreateInstance()
		{
			frmARAPAutoAdjustVoucher theInstance = new frmARAPAutoAdjustVoucher();
			
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
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "cmdOKCancel", "chkUnAdjust", "lblDateRange", "lblToDate", "txtAsOnDate", "fraDateRange", "txtGroupType", "lblMasterCode", "txtGroupName", "cntMainParameter"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public UCOkCancel cmdOKCancel;
		public System.Windows.Forms.CheckBox chkUnAdjust;
		public System.Windows.Forms.Label lblDateRange;
		public System.Windows.Forms.Label lblToDate;
		public Syncfusion.WinForms.Input.SfDateTimeEdit txtAsOnDate;
		public System.Windows.Forms.Panel fraDateRange;
		public System.Windows.Forms.TextBox txtGroupType;
		public System.Windows.Forms.Label lblMasterCode;
		public System.Windows.Forms.Label txtGroupName;
		public System.Windows.Forms.Panel cntMainParameter;
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmARAPAutoAdjustVoucher));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this.cmdOKCancel = new UCOkCancel();
			this.cntMainParameter = new System.Windows.Forms.Panel();
			this.chkUnAdjust = new System.Windows.Forms.CheckBox();
			this.lblDateRange = new System.Windows.Forms.Label();
			this.fraDateRange = new System.Windows.Forms.Panel();
			this.lblToDate = new System.Windows.Forms.Label();
			this.txtAsOnDate = new Syncfusion.WinForms.Input.SfDateTimeEdit();
			this.txtGroupType = new System.Windows.Forms.TextBox();
			this.lblMasterCode = new System.Windows.Forms.Label();
			this.txtGroupName = new System.Windows.Forms.Label();
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
			this.cmdOKCancel.TabIndex = 3;
			this.cmdOKCancel.CancelClick += new UCOkCancel.CancelClickHandler(this.cmdOKCancel_CancelClick);
			this.cmdOKCancel.OKClick += new UCOkCancel.OKClickHandler(this.cmdOKCancel_OKClick);
			// 
			// cntMainParameter
			// 
			this.cntMainParameter.AllowDrop = true;
			this.cntMainParameter.Controls.Add(this.chkUnAdjust);
			this.cntMainParameter.Controls.Add(this.lblDateRange);
			this.cntMainParameter.Controls.Add(this.fraDateRange);
			this.cntMainParameter.Controls.Add(this.txtGroupType);
			this.cntMainParameter.Controls.Add(this.lblMasterCode);
			this.cntMainParameter.Controls.Add(this.txtGroupName);
			this.cntMainParameter.Location = new System.Drawing.Point(18, 15);
			this.cntMainParameter.Name = "cntMainParameter";
			//
			this.cntMainParameter.Size = new System.Drawing.Size(457, 175);
			this.cntMainParameter.TabIndex = 4;
			// 
			// chkUnAdjust
			// 
			this.chkUnAdjust.AllowDrop = true;
			this.chkUnAdjust.Appearance = System.Windows.Forms.Appearance.Normal;
			this.chkUnAdjust.BackColor = System.Drawing.Color.FromArgb(241, 242, 234);
			this.chkUnAdjust.CausesValidation = true;
			this.chkUnAdjust.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkUnAdjust.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this.chkUnAdjust.Enabled = true;
			this.chkUnAdjust.ForeColor = System.Drawing.SystemColors.ControlText;
			this.chkUnAdjust.Location = new System.Drawing.Point(276, 102);
			this.chkUnAdjust.Name = "chkUnAdjust";
			this.chkUnAdjust.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.chkUnAdjust.Size = new System.Drawing.Size(149, 17);
			this.chkUnAdjust.TabIndex = 2;
			this.chkUnAdjust.TabStop = true;
			this.chkUnAdjust.Text = "UnAdjust Voucher Link";
			this.chkUnAdjust.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkUnAdjust.Visible = true;
			// 
			// lblDateRange
			// 
			this.lblDateRange.AllowDrop = true;
			this.lblDateRange.BackColor = System.Drawing.Color.FromArgb(241, 242, 234);
			this.lblDateRange.Text = "  Date Range ";
			this.lblDateRange.ForeColor = System.Drawing.Color.Black;
			this.lblDateRange.Location = new System.Drawing.Point(18, 66);
			// // this.lblDateRange.mLabelId = 949;
			this.lblDateRange.Name = "lblDateRange";
			this.lblDateRange.Size = new System.Drawing.Size(61, 13);
			this.lblDateRange.TabIndex = 7;
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
			this.fraDateRange.Location = new System.Drawing.Point(9, 76);
			this.fraDateRange.Name = "fraDateRange";
			this.fraDateRange.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.fraDateRange.Size = new System.Drawing.Size(207, 45);
			this.fraDateRange.TabIndex = 5;
			this.fraDateRange.Visible = true;
			// 
			// lblToDate
			// 
			this.lblToDate.AllowDrop = true;
			this.lblToDate.BackColor = System.Drawing.Color.FromArgb(241, 242, 234);
			// this.lblToDate.Text = "As On Date";
			this.lblToDate.ForeColor = System.Drawing.Color.Black;
			this.lblToDate.Location = new System.Drawing.Point(9, 13);
			this.lblToDate.Name = "lblToDate";
			this.lblToDate.Size = new System.Drawing.Size(55, 13);
			this.lblToDate.TabIndex = 6;
			// 
			// txtAsOnDate
			// 
			this.txtAsOnDate.AllowDrop = true;
			// this.txtAsOnDate.CheckDateRange = false;
			this.txtAsOnDate.Location = new System.Drawing.Point(79, 10);
			// this.txtAsOnDate.MaxDate = 2958465;
			// this.txtAsOnDate.MinDate = 2;
			this.txtAsOnDate.Name = "txtAsOnDate";
			this.txtAsOnDate.Size = new System.Drawing.Size(96, 19);
			this.txtAsOnDate.TabIndex = 1;
			// this.txtAsOnDate.Text = "7/18/2001";
			// this.txtAsOnDate.Value = 37090;
			// 
			// txtGroupType
			// 
			this.txtGroupType.AllowDrop = true;
			this.txtGroupType.BackColor = System.Drawing.Color.White;
			this.txtGroupType.ForeColor = System.Drawing.Color.Black;
			this.txtGroupType.Location = new System.Drawing.Point(99, 26);
			this.txtGroupType.Name = "txtGroupType";
			// this.txtGroupType.ShowButton = true;
			this.txtGroupType.Size = new System.Drawing.Size(101, 19);
			this.txtGroupType.TabIndex = 0;
			this.txtGroupType.Text = "";
			// this.this.txtGroupType.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtGroupType_DropButtonClick);
			// this.txtGroupType.Leave += new System.EventHandler(this.txtGroupType_Leave);
			// 
			// lblMasterCode
			// 
			this.lblMasterCode.AllowDrop = true;
			this.lblMasterCode.BackColor = System.Drawing.Color.FromArgb(241, 242, 234);
			this.lblMasterCode.Text = "Group Type";
			this.lblMasterCode.ForeColor = System.Drawing.Color.Black;
			this.lblMasterCode.Location = new System.Drawing.Point(8, 28);
			this.lblMasterCode.Name = "lblMasterCode";
			this.lblMasterCode.Size = new System.Drawing.Size(57, 14);
			this.lblMasterCode.TabIndex = 8;
			// 
			// txtGroupName
			// 
			this.txtGroupName.AllowDrop = true;
			this.txtGroupName.Location = new System.Drawing.Point(202, 26);
			this.txtGroupName.Name = "txtGroupName";
			this.txtGroupName.Size = new System.Drawing.Size(201, 19);
			this.txtGroupName.TabIndex = 9;
			// 
			// frmARAPAutoAdjustVoucher
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.FromArgb(241, 242, 234);
			this.ClientSize = new System.Drawing.Size(498, 246);
			this.Controls.Add(this.cmdOKCancel);
			this.Controls.Add(this.cntMainParameter);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			//this.Icon = (System.Drawing.Icon) resources.GetObject("frmARAPAutoAdjustVoucher.Icon");
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(162, 221);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmARAPAutoAdjustVoucher";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Auto Adjust GL Voucher";
			// this.Activated += new System.EventHandler(this.frmARAPAutoAdjustVoucher_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
			// this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
			//((System.ComponentModel.ISupportInitialize) this.cntMainParameter).EndInit();
			this.cntMainParameter.ResumeLayout(false);
			this.fraDateRange.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		// 
		#endregion
	}
}//ENDSHERE
