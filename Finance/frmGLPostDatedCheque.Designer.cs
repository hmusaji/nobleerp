
namespace Xtreme
{
	partial class frmGLPostDatedCheque
	{

		#region "Upgrade Support "
		private static frmGLPostDatedCheque m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmGLPostDatedCheque DefInstance
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
		public static frmGLPostDatedCheque CreateInstance()
		{
			frmGLPostDatedCheque theInstance = new frmGLPostDatedCheque();
			
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
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "txtTempDate", "cmdShow", "txtMaturityDate", "label1", "Column_0_grdVoucherDetails", "Column_1_grdVoucherDetails", "grdVoucherDetails", "cntMasterDetails", "Column_0_cmbMastersList", "Column_1_cmbMastersList", "cmbMastersList", "txtChequeNo", "lblChequeNo", "lblBranchCode", "txtVoucherType", "txtVoucherName", "tcbSystemForm", "Line1", "commandButtonHelper1"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public Syncfusion.WinForms.Input.SfDateTimeEdit txtTempDate;
		public System.Windows.Forms.Button cmdShow;
		public Syncfusion.WinForms.Input.SfDateTimeEdit txtMaturityDate;
		public System.Windows.Forms.Label label1;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_0_grdVoucherDetails;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_1_grdVoucherDetails;
		public C1.Win.C1TrueDBGrid.C1TrueDBGrid grdVoucherDetails;
		public System.Windows.Forms.Panel cntMasterDetails;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_0_cmbMastersList;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_1_cmbMastersList;
		public C1.Win.C1TrueDBGrid.C1TrueDBDropdown cmbMastersList;
		public System.Windows.Forms.TextBox txtChequeNo;
		public System.Windows.Forms.Label lblChequeNo;
		public System.Windows.Forms.Label lblBranchCode;
		public System.Windows.Forms.TextBox txtVoucherType;
		public System.Windows.Forms.TextBox txtVoucherName;
		public Syncfusion.Windows.Forms.Tools.CommandBarController tcbSystemForm;
		public System.Windows.Forms.Label Line1;
		//public UpgradeHelpers.Gui.CommandButtonHelper commandButtonHelper1;
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGLPostDatedCheque));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this.txtTempDate = new Syncfusion.WinForms.Input.SfDateTimeEdit();
			this.cmdShow = new System.Windows.Forms.Button();
			this.txtMaturityDate = new Syncfusion.WinForms.Input.SfDateTimeEdit();
			this.label1 = new System.Windows.Forms.Label();
			this.cntMasterDetails = new System.Windows.Forms.Panel();
			this.grdVoucherDetails = new C1.Win.C1TrueDBGrid.C1TrueDBGrid();
			this.Column_0_grdVoucherDetails = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.Column_1_grdVoucherDetails = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.cmbMastersList = new C1.Win.C1TrueDBGrid.C1TrueDBDropdown();
			this.Column_0_cmbMastersList = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.Column_1_cmbMastersList = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.txtChequeNo = new System.Windows.Forms.TextBox();
			this.lblChequeNo = new System.Windows.Forms.Label();
			this.lblBranchCode = new System.Windows.Forms.Label();
			this.txtVoucherType = new System.Windows.Forms.TextBox();
			this.txtVoucherName = new System.Windows.Forms.TextBox();
			this.tcbSystemForm = new Syncfusion.Windows.Forms.Tools.CommandBarController();
			this.Line1 = new System.Windows.Forms.Label();
			// //((System.ComponentModel.ISupportInitialize) this.txtTempDate).BeginInit();
			// //((System.ComponentModel.ISupportInitialize) this.cntMasterDetails).BeginInit();
			// //((System.ComponentModel.ISupportInitialize) this.tcbSystemForm).BeginInit();
			//this.cntMasterDetails.SuspendLayout();
			//this.grdVoucherDetails.SuspendLayout();
			//this.cmbMastersList.SuspendLayout();
			this.SuspendLayout();
			//this.commandButtonHelper1 = new UpgradeHelpers.Gui.CommandButtonHelper(this.components);
			// 
			// txtTempDate
			// 
			this.txtTempDate.AllowDrop = true;
			this.txtTempDate.Location = new System.Drawing.Point(24, 172);
			this.txtTempDate.Name = "txtTempDate";
			//
			this.txtTempDate.Size = new System.Drawing.Size(109, 19);
			this.txtTempDate.TabIndex = 8;
			this.txtTempDate.Visible = false;
			// 
			// cmdShow
			// 
			this.cmdShow.AllowDrop = true;
			this.cmdShow.BackColor = System.Drawing.Color.FromArgb(249, 238, 221);
			this.cmdShow.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdShow.Location = new System.Drawing.Point(444, 98);
			this.cmdShow.Name = "cmdShow";
			this.cmdShow.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdShow.Size = new System.Drawing.Size(161, 24);
			this.cmdShow.TabIndex = 3;
			this.cmdShow.Text = "Show &Matured Transactions";
			this.cmdShow.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.cmdShow.UseVisualStyleBackColor = false;
			// this.cmdShow.Click += new System.EventHandler(this.cmdShow_Click);
			// 
			// txtMaturityDate
			// 
			this.txtMaturityDate.AllowDrop = true;
			// this.txtMaturityDate.CheckDateRange = false;
			this.txtMaturityDate.Location = new System.Drawing.Point(89, 57);
			// this.txtMaturityDate.MaxDate = 2958465;
			// this.txtMaturityDate.MinDate = 2;
			this.txtMaturityDate.Name = "txtMaturityDate";
			this.txtMaturityDate.Size = new System.Drawing.Size(101, 19);
			this.txtMaturityDate.TabIndex = 0;
			// this.txtMaturityDate.Text = "10/28/2011";
			// 
			// label1
			// 
			this.label1.AllowDrop = true;
			this.label1.BackColor = System.Drawing.SystemColors.Window;
			this.label1.Text = "As On Date:";
			this.label1.ForeColor = System.Drawing.Color.Black;
			this.label1.Location = new System.Drawing.Point(18, 60);
			// // this.label1.mLabelId = 1874;
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(59, 13);
			this.label1.TabIndex = 6;
			// 
			// cntMasterDetails
			// 
			this.cntMasterDetails.AllowDrop = true;
			this.cntMasterDetails.Controls.Add(this.grdVoucherDetails);
			this.cntMasterDetails.Location = new System.Drawing.Point(2, 148);
			this.cntMasterDetails.Name = "cntMasterDetails";
			//
			this.cntMasterDetails.Size = new System.Drawing.Size(753, 268);
			this.cntMasterDetails.TabIndex = 5;
			// 
			// grdVoucherDetails
			// 
			this.grdVoucherDetails.AllowDrop = true;
			this.grdVoucherDetails.BackColor = System.Drawing.Color.FromArgb(212, 208, 200);
			this.grdVoucherDetails.CellTipsWidth = 0;
			this.grdVoucherDetails.Location = new System.Drawing.Point(0, 0);
			this.grdVoucherDetails.Name = "grdVoucherDetails";
			this.grdVoucherDetails.RowDivider.Color = System.Drawing.Color.FromArgb(212, 208, 200);
			this.grdVoucherDetails.Size = new System.Drawing.Size(749, 264);
			this.grdVoucherDetails.TabIndex = 4;
			this.grdVoucherDetails.Columns.Add(this.Column_0_grdVoucherDetails);
			this.grdVoucherDetails.Columns.Add(this.Column_1_grdVoucherDetails);
			this.grdVoucherDetails.BeforeColEdit += new C1.Win.C1TrueDBGrid.BeforeColEditEventHandler(this.grdVoucherDetails_BeforeColEdit);
			this.grdVoucherDetails.GotFocus += new System.EventHandler(this.grdVoucherDetails_GotFocus);
			// this.this.grdVoucherDetails.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.grdVoucherDetails_KeyPress);
			this.grdVoucherDetails.MouseUp += new System.Windows.Forms.MouseEventHandler(this.grdVoucherDetails_MouseUp);
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
			// cmbMastersList
			// 
			this.cmbMastersList.AllowDrop = true;
			this.cmbMastersList.ColumnHeaders = true;
			this.cmbMastersList.Enabled = true;
			this.cmbMastersList.Location = new System.Drawing.Point(27, 171);
			this.cmbMastersList.Name = "cmbMastersList";
			this.cmbMastersList.Size = new System.Drawing.Size(333, 133);
			this.cmbMastersList.TabIndex = 7;
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
			// txtChequeNo
			// 
			this.txtChequeNo.AllowDrop = true;
			this.txtChequeNo.BackColor = System.Drawing.Color.White;
			// // = false;
			this.txtChequeNo.ForeColor = System.Drawing.Color.Black;
			this.txtChequeNo.Location = new System.Drawing.Point(89, 102);
			// // = (System.Windows.Forms.TextBox.DropDownTypes) 0;
			this.txtChequeNo.Name = "txtChequeNo";
			this.txtChequeNo.Size = new System.Drawing.Size(101, 19);
			this.txtChequeNo.TabIndex = 2;
			this.txtChequeNo.Text = "";
			// 
			// lblChequeNo
			// 
			this.lblChequeNo.AllowDrop = true;
			this.lblChequeNo.BackColor = System.Drawing.SystemColors.Window;
			this.lblChequeNo.Text = "Cheque No";
			this.lblChequeNo.ForeColor = System.Drawing.Color.Black;
			this.lblChequeNo.Location = new System.Drawing.Point(18, 105);
			// // this.lblChequeNo.mLabelId = 1852;
			this.lblChequeNo.Name = "lblChequeNo";
			this.lblChequeNo.Size = new System.Drawing.Size(53, 14);
			this.lblChequeNo.TabIndex = 9;
			// 
			// lblBranchCode
			// 
			this.lblBranchCode.AllowDrop = true;
			this.lblBranchCode.BackColor = System.Drawing.SystemColors.Window;
			this.lblBranchCode.Text = "Voucher Type";
			this.lblBranchCode.ForeColor = System.Drawing.Color.Black;
			this.lblBranchCode.Location = new System.Drawing.Point(18, 83);
			this.lblBranchCode.Name = "lblBranchCode";
			this.lblBranchCode.Size = new System.Drawing.Size(66, 13);
			this.lblBranchCode.TabIndex = 10;
			// 
			// txtVoucherType
			// 
			this.txtVoucherType.AllowDrop = true;
			this.txtVoucherType.BackColor = System.Drawing.Color.White;
			this.txtVoucherType.ForeColor = System.Drawing.Color.Black;
			this.txtVoucherType.Location = new System.Drawing.Point(89, 80);
			this.txtVoucherType.Name = "txtVoucherType";
			// this.txtVoucherType.ShowButton = true;
			this.txtVoucherType.Size = new System.Drawing.Size(101, 19);
			this.txtVoucherType.TabIndex = 1;
			this.txtVoucherType.Text = "";
			// this.//this.txtVoucherType.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(//this.txtVoucherType_DropButtonClick);
			// this.txtVoucherType.Leave += new System.EventHandler(this.txtVoucherType_Leave);
			// 
			// txtVoucherName
			// 
			this.txtVoucherName.AllowDrop = true;
			this.txtVoucherName.BackColor = System.Drawing.Color.FromArgb(239, 239, 239);
			this.txtVoucherName.Enabled = false;
			this.txtVoucherName.ForeColor = System.Drawing.Color.Black;
			this.txtVoucherName.Location = new System.Drawing.Point(192, 80);
			this.txtVoucherName.Name = "txtVoucherName";
			this.txtVoucherName.Size = new System.Drawing.Size(201, 19);
			this.txtVoucherName.TabIndex = 11;
			this.txtVoucherName.Text = "";
			// 
			// tcbSystemForm
			// 
			this.tcbSystemForm.AllowDrop = true;
			this.tcbSystemForm.Location = new System.Drawing.Point(0, 0);
			this.tcbSystemForm.Name = "tcbSystemForm";
			//
			// 
			// Line1
			// 
			this.Line1.AllowDrop = true;
			this.Line1.BackColor = System.Drawing.Color.Red;
			this.Line1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Line1.Enabled = false;
			this.Line1.ForeColor = System.Drawing.Color.Black;
			this.Line1.Location = new System.Drawing.Point(0, 139);
			this.Line1.Name = "Line1";
			this.Line1.Size = new System.Drawing.Size(767, 1);
			this.Line1.Text = "Line1";
			this.Line1.Visible = true;
			// 
			// frmGLPostDatedCheque
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.FromArgb(250, 244, 231);
			this.ClientSize = new System.Drawing.Size(758, 425);
			this.Controls.Add(this.txtTempDate);
			this.Controls.Add(this.cmdShow);
			this.Controls.Add(this.txtMaturityDate);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.cntMasterDetails);
			this.Controls.Add(this.cmbMastersList);
			this.Controls.Add(this.txtChequeNo);
			this.Controls.Add(this.lblChequeNo);
			this.Controls.Add(this.lblBranchCode);
			this.Controls.Add(this.txtVoucherType);
			this.Controls.Add(this.txtVoucherName);
			this.Controls.Add(this.tcbSystemForm);
			this.Controls.Add(this.Line1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			//this.Icon = (System.Drawing.Icon) resources.GetObject("frmGLPostDatedCheque.Icon");
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(156, 189);
			this.MaximizeBox = false;
			this.MinimizeBox = true;
			this.Name = "frmGLPostDatedCheque";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Convert Post Dated Cheque ";
			this.commandButtonHelper1.SetStyle(this.cmdShow, 1);
			// this.Activated += new System.EventHandler(this.Form_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
			// this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
			//((System.ComponentModel.ISupportInitialize) this.txtTempDate).EndInit();
			//((System.ComponentModel.ISupportInitialize) this.cntMasterDetails).EndInit();
			//((System.ComponentModel.ISupportInitialize) this.tcbSystemForm).EndInit();
			this.cntMasterDetails.ResumeLayout(false);
			this.grdVoucherDetails.ResumeLayout(false);
			this.cmbMastersList.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		// 
		#endregion
	}
}//ENDSHERE
