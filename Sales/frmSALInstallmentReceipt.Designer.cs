
namespace Xtreme
{
	partial class frmSALInstallmentReceipt
	{

		#region "Upgrade Support "
		private static frmSALInstallmentReceipt m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmSALInstallmentReceipt DefInstance
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
		public static frmSALInstallmentReceipt CreateInstance()
		{
			frmSALInstallmentReceipt theInstance = new frmSALInstallmentReceipt();
			
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
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "cmdGenerate", "txtFromDate", "Label_7", "txtToDate", "Label_0", "Column_0_cmbMastersList", "Column_1_cmbMastersList", "cmbMastersList", "Column_0_grdVoucherDetails", "Column_1_grdVoucherDetails", "grdVoucherDetails", "txtTempDate", "Frame1", "C1Tab1", "txtCustomerName", "txtCustomerCode", "Label_1", "System.Windows.Forms.Label"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public System.Windows.Forms.Button cmdGenerate;
		public Syncfusion.WinForms.Input.SfDateTimeEdit txtFromDate;
		private System.Windows.Forms.Label Label_7;
		public Syncfusion.WinForms.Input.SfDateTimeEdit txtToDate;
		private System.Windows.Forms.Label Label_0;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_0_cmbMastersList;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_1_cmbMastersList;
		public C1.Win.C1TrueDBGrid.C1TrueDBDropdown cmbMastersList;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_0_grdVoucherDetails;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_1_grdVoucherDetails;
		public C1.Win.C1TrueDBGrid.C1TrueDBGrid grdVoucherDetails;
		public Syncfusion.WinForms.Input.SfDateTimeEdit txtTempDate;
		public System.Windows.Forms.Panel Frame1;
		public AxC1SizerLib.AxC1Tab C1Tab1;
		public System.Windows.Forms.Label txtCustomerName;
		public System.Windows.Forms.TextBox txtCustomerCode;
		private System.Windows.Forms.Label Label_1;
		public System.Windows.Forms.Label[] Label = new System.Windows.Forms.Label[8];
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSALInstallmentReceipt));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this.cmdGenerate = new System.Windows.Forms.Button();
			this.txtFromDate = new Syncfusion.WinForms.Input.SfDateTimeEdit();
			this.Label_7 = new System.Windows.Forms.Label();
			this.txtToDate = new Syncfusion.WinForms.Input.SfDateTimeEdit();
			this.Label_0 = new System.Windows.Forms.Label();
			this.C1Tab1 = new AxC1SizerLib.AxC1Tab();
			this.Frame1 = new System.Windows.Forms.Panel();
			this.cmbMastersList = new C1.Win.C1TrueDBGrid.C1TrueDBDropdown();
			this.Column_0_cmbMastersList = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.Column_1_cmbMastersList = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.grdVoucherDetails = new C1.Win.C1TrueDBGrid.C1TrueDBGrid();
			this.Column_0_grdVoucherDetails = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.Column_1_grdVoucherDetails = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.txtTempDate = new Syncfusion.WinForms.Input.SfDateTimeEdit();
			this.txtCustomerName = new System.Windows.Forms.Label();
			this.txtCustomerCode = new System.Windows.Forms.TextBox();
			this.Label_1 = new System.Windows.Forms.Label();
			// //((System.ComponentModel.ISupportInitialize) this.txtTempDate).BeginInit();
			// //((System.ComponentModel.ISupportInitialize) this.C1Tab1).BeginInit();
			this.C1Tab1.SuspendLayout();
			this.Frame1.SuspendLayout();
			this.cmbMastersList.SuspendLayout();
			this.grdVoucherDetails.SuspendLayout();
			this.SuspendLayout();
			// 
			// cmdGenerate
			// 
			this.cmdGenerate.AllowDrop = true;
			this.cmdGenerate.BackColor = System.Drawing.SystemColors.Control;
			this.cmdGenerate.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdGenerate.Location = new System.Drawing.Point(198, 102);
			this.cmdGenerate.Name = "cmdGenerate";
			this.cmdGenerate.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdGenerate.Size = new System.Drawing.Size(66, 26);
			this.cmdGenerate.TabIndex = 6;
			// this.cmdGenerate.Text = "Show";
			// this.cmdGenerate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.cmdGenerate.UseVisualStyleBackColor = false;
			// this.cmdGenerate.Click += new System.EventHandler(this.cmdGenerate_Click);
			// 
			// txtFromDate
			// 
			this.txtFromDate.AllowDrop = true;
			this.txtFromDate.Location = new System.Drawing.Point(106, 28);
			// this.txtFromDate.MaxDate = 2958465;
			// this.txtFromDate.MinDate = -657434;
			this.txtFromDate.Name = "txtFromDate";
			this.txtFromDate.PromptChar = "_";
			this.txtFromDate.Size = new System.Drawing.Size(89, 19);
			this.txtFromDate.TabIndex = 0;
			// this.txtFromDate.Text = "10/02/2014";
			// 
			// Label_7
			// 
			this.Label_7.AllowDrop = true;
			this.Label_7.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.Label_7.Text = "From Date";
			this.Label_7.ForeColor = System.Drawing.SystemColors.WindowText;
			this.Label_7.Location = new System.Drawing.Point(8, 31);
			this.Label_7.Name = "Label_7";
			this.Label_7.Size = new System.Drawing.Size(49, 14);
			this.Label_7.TabIndex = 8;
			// 
			// txtToDate
			// 
			this.txtToDate.AllowDrop = true;
			this.txtToDate.Location = new System.Drawing.Point(106, 54);
			// this.txtToDate.MaxDate = 2958465;
			// this.txtToDate.MinDate = -657434;
			this.txtToDate.Name = "txtToDate";
			this.txtToDate.PromptChar = "_";
			this.txtToDate.Size = new System.Drawing.Size(89, 19);
			this.txtToDate.TabIndex = 1;
			// this.txtToDate.Text = "10/02/2014";
			// 
			// Label_0
			// 
			this.Label_0.AllowDrop = true;
			this.Label_0.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.Label_0.Text = "To Date";
			this.Label_0.ForeColor = System.Drawing.SystemColors.WindowText;
			this.Label_0.Location = new System.Drawing.Point(8, 57);
			this.Label_0.Name = "Label_0";
			this.Label_0.Size = new System.Drawing.Size(37, 14);
			this.Label_0.TabIndex = 9;
			// 
			// C1Tab1
			// 
			this.C1Tab1.Align = C1SizerLib.AlignSettings.asNone;
			this.C1Tab1.AllowDrop = true;
			this.C1Tab1.Controls.Add(this.Frame1);
			this.C1Tab1.Location = new System.Drawing.Point(6, 132);
			this.C1Tab1.Name = "C1Tab1";
			//
			this.C1Tab1.Size = new System.Drawing.Size(775, 273);
			this.C1Tab1.TabIndex = 3;
			this.C1Tab1.TabStop = false;
			// 
			// Frame1
			// 
			this.Frame1.AllowDrop = true;
			this.Frame1.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this.Frame1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Frame1.Controls.Add(this.cmbMastersList);
			this.Frame1.Controls.Add(this.grdVoucherDetails);
			this.Frame1.Controls.Add(this.txtTempDate);
			this.Frame1.Enabled = true;
			this.Frame1.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Frame1.Location = new System.Drawing.Point(1, 23);
			this.Frame1.Name = "Frame1";
			this.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Frame1.Size = new System.Drawing.Size(773, 249);
			this.Frame1.TabIndex = 10;
			this.Frame1.Visible = true;
			// 
			// cmbMastersList
			// 
			this.cmbMastersList.AllowDrop = true;
			this.cmbMastersList.ColumnHeaders = true;
			this.cmbMastersList.Enabled = true;
			this.cmbMastersList.Location = new System.Drawing.Point(4, 2);
			this.cmbMastersList.Name = "cmbMastersList";
			this.cmbMastersList.Size = new System.Drawing.Size(333, 133);
			this.cmbMastersList.TabIndex = 12;
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
			// grdVoucherDetails
			// 
			this.grdVoucherDetails.AllowDrop = true;
			this.grdVoucherDetails.BackColor = System.Drawing.Color.Silver;
			this.grdVoucherDetails.CellTipsWidth = 0;
			this.grdVoucherDetails.Location = new System.Drawing.Point(8, 6);
			this.grdVoucherDetails.Name = "grdVoucherDetails";
			this.grdVoucherDetails.RowDivider.Color = System.Drawing.Color.Silver;
			this.grdVoucherDetails.Size = new System.Drawing.Size(763, 240);
			this.grdVoucherDetails.TabIndex = 4;
			this.grdVoucherDetails.Columns.Add(this.Column_0_grdVoucherDetails);
			this.grdVoucherDetails.Columns.Add(this.Column_1_grdVoucherDetails);
			this.grdVoucherDetails.AfterColUpdate += new C1.Win.C1TrueDBGrid.ColEventHandler(this.grdVoucherDetails_AfterColUpdate);
			this.grdVoucherDetails.GotFocus += new System.EventHandler(this.grdVoucherDetails_GotFocus);
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
			// txtTempDate
			// 
			this.txtTempDate.AllowDrop = true;
			this.txtTempDate.Location = new System.Drawing.Point(14, 2);
			this.txtTempDate.Name = "txtTempDate";
			//
			this.txtTempDate.Size = new System.Drawing.Size(109, 19);
			this.txtTempDate.TabIndex = 5;
			this.txtTempDate.TabStop = false;
			this.txtTempDate.Visible = false;
			// 
			// txtCustomerName
			// 
			this.txtCustomerName.AllowDrop = true;
			this.txtCustomerName.Enabled = false;
			this.txtCustomerName.Location = new System.Drawing.Point(196, 78);
			this.txtCustomerName.Name = "txtCustomerName";
			this.txtCustomerName.Size = new System.Drawing.Size(329, 19);
			this.txtCustomerName.TabIndex = 7;
			this.txtCustomerName.TabStop = false;
			// 
			// txtCustomerCode
			// 
			this.txtCustomerCode.AllowDrop = true;
			this.txtCustomerCode.BackColor = System.Drawing.Color.White;
			// this.txtCustomerCode.bolAllowDecimal = false;
			this.txtCustomerCode.ForeColor = System.Drawing.Color.Black;
			this.txtCustomerCode.Location = new System.Drawing.Point(106, 78);
			// this.txtCustomerCode.mDropDownType = (System.Windows.Forms.TextBox.DropDownTypes) 0;
			this.txtCustomerCode.Name = "txtCustomerCode";
			// this.txtCustomerCode.ShowButton = true;
			this.txtCustomerCode.Size = new System.Drawing.Size(87, 19);
			this.txtCustomerCode.TabIndex = 2;
			this.txtCustomerCode.Text = "";
			// this.this.txtCustomerCode.Watermark = "";
			// this.this.txtCustomerCode.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCustomerCode_DropButtonClick);
			// this.txtCustomerCode.Leave += new System.EventHandler(this.txtCustomerCode_Leave);
			// 
			// Label_1
			// 
			this.Label_1.AllowDrop = true;
			this.Label_1.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.Label_1.Text = "Customer Name";
			this.Label_1.ForeColor = System.Drawing.SystemColors.WindowText;
			this.Label_1.Location = new System.Drawing.Point(6, 82);
			this.Label_1.Name = "Label_1";
			this.Label_1.Size = new System.Drawing.Size(3, 14);
			this.Label_1.TabIndex = 11;
			// 
			// frmSALInstallmentReceipt
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.ClientSize = new System.Drawing.Size(784, 430);
			this.Controls.Add(this.cmdGenerate);
			this.Controls.Add(this.txtFromDate);
			this.Controls.Add(this.Label_7);
			this.Controls.Add(this.txtToDate);
			this.Controls.Add(this.Label_0);
			this.Controls.Add(this.C1Tab1);
			this.Controls.Add(this.txtCustomerName);
			this.Controls.Add(this.txtCustomerCode);
			this.Controls.Add(this.Label_1);
			this.Font = new System.Drawing.Font("Tahoma", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 178);
			this.Location = new System.Drawing.Point(393, 358);
			this.MaximizeBox = true;
			this.MinimizeBox = true;
			this.Name = "frmSALInstallmentReceipt";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Installment Receipt";
			// this.Activated += new System.EventHandler(this.frmSALInstallmentReceipt_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
			// this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
			this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Form_KeyPress);
			//this.Resize += new System.EventHandler(this.Form_Resize);
			//((System.ComponentModel.ISupportInitialize) this.txtTempDate).EndInit();
			//((System.ComponentModel.ISupportInitialize) this.C1Tab1).EndInit();
			this.C1Tab1.ResumeLayout(false);
			this.Frame1.ResumeLayout(false);
			this.cmbMastersList.ResumeLayout(false);
			this.grdVoucherDetails.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		// 
		void InitializeSystem.Windows.Forms.Label()
		{
			this.Label = new System.Windows.Forms.Label[8];
			this.Label[7] = Label_7;
			this.Label[0] = Label_0;
			this.Label[1] = Label_1;
		}
		#endregion
	}
}//ENDSHERE
