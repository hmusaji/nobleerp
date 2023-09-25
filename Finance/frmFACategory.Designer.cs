
namespace Xtreme
{
	partial class frmFACategory
	{

		#region "Upgrade Support "
		private static frmFACategory m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmFACategory DefInstance
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
		public static frmFACategory CreateInstance()
		{
			frmFACategory theInstance = new frmFACategory();
			
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
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "txtComment", "txtCatNo", "lblGroupNo", "lblLGroupName", "txtLCatName", "lblParentGroup", "lblAGroupName", "txtACatName", "lblComments", "txtParentCatNo", "txtParentCatName", "_fraLedgerInformation_0", "Column_0_grdVoucherDetails", "Column_1_grdVoucherDetails", "grdVoucherDetails", "Column_0_cmbCommon", "Column_1_cmbCommon", "cmbCommon", "_fraLedgerInformation_3", "tabMaster", "ElasticOne1", "fraLedgerInformation"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public System.Windows.Forms.TextBox txtComment;
		public System.Windows.Forms.TextBox txtCatNo;
		public System.Windows.Forms.Label lblGroupNo;
		public System.Windows.Forms.Label lblLGroupName;
		public System.Windows.Forms.TextBox txtLCatName;
		public System.Windows.Forms.Label lblParentGroup;
		public System.Windows.Forms.Label lblAGroupName;
		public System.Windows.Forms.TextBox txtACatName;
		public System.Windows.Forms.Label lblComments;
		public System.Windows.Forms.TextBox txtParentCatNo;
		public System.Windows.Forms.TextBox txtParentCatName;
		private System.Windows.Forms.Panel _fraLedgerInformation_0;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_0_grdVoucherDetails;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_1_grdVoucherDetails;
		public C1.Win.C1TrueDBGrid.C1TrueDBGrid grdVoucherDetails;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_0_cmbCommon;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_1_cmbCommon;
		public C1.Win.C1TrueDBGrid.C1TrueDBDropdown cmbCommon;
		private System.Windows.Forms.Panel _fraLedgerInformation_3;
		public AxC1SizerLib.AxC1Tab tabMaster;
		public AxC1SizerLib.AxC1Elastic ElasticOne1;
		public System.Windows.Forms.Panel[] fraLedgerInformation = new System.Windows.Forms.Panel[4];
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFACategory));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this.tabMaster = new AxC1SizerLib.AxC1Tab();
			this._fraLedgerInformation_0 = new System.Windows.Forms.Panel();
			this.txtComment = new System.Windows.Forms.TextBox();
			this.txtCatNo = new System.Windows.Forms.TextBox();
			this.lblGroupNo = new System.Windows.Forms.Label();
			this.lblLGroupName = new System.Windows.Forms.Label();
			this.txtLCatName = new System.Windows.Forms.TextBox();
			this.lblParentGroup = new System.Windows.Forms.Label();
			this.lblAGroupName = new System.Windows.Forms.Label();
			this.txtACatName = new System.Windows.Forms.TextBox();
			this.lblComments = new System.Windows.Forms.Label();
			this.txtParentCatNo = new System.Windows.Forms.TextBox();
			this.txtParentCatName = new System.Windows.Forms.TextBox();
			this._fraLedgerInformation_3 = new System.Windows.Forms.Panel();
			this.grdVoucherDetails = new C1.Win.C1TrueDBGrid.C1TrueDBGrid();
			this.Column_0_grdVoucherDetails = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.Column_1_grdVoucherDetails = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.cmbCommon = new C1.Win.C1TrueDBGrid.C1TrueDBDropdown();
			this.Column_0_cmbCommon = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.Column_1_cmbCommon = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.ElasticOne1 = new AxC1SizerLib.AxC1Elastic();
			// //((System.ComponentModel.ISupportInitialize) this.tabMaster).BeginInit();
			// //((System.ComponentModel.ISupportInitialize) this.ElasticOne1).BeginInit();
			this.tabMaster.SuspendLayout();
			this._fraLedgerInformation_0.SuspendLayout();
			this._fraLedgerInformation_3.SuspendLayout();
			this.grdVoucherDetails.SuspendLayout();
			this.cmbCommon.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabMaster
			// 
			this.tabMaster.Align = C1SizerLib.AlignSettings.asNone;
			this.tabMaster.AllowDrop = true;
			this.tabMaster.Controls.Add(this._fraLedgerInformation_0);
			this.tabMaster.Controls.Add(this._fraLedgerInformation_3);
			this.tabMaster.Location = new System.Drawing.Point(6, 51);
			this.tabMaster.Name = "tabMaster";
			("tabMaster.OcxState");
			this.tabMaster.Size = new System.Drawing.Size(593, 269);
			this.tabMaster.TabIndex = 6;
			this.tabMaster.TabStop = false;
			// 
			// _fraLedgerInformation_0
			// 
			this._fraLedgerInformation_0.AllowDrop = true;
			this._fraLedgerInformation_0.BackColor = System.Drawing.Color.White;
			this._fraLedgerInformation_0.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._fraLedgerInformation_0.Controls.Add(this.txtComment);
			this._fraLedgerInformation_0.Controls.Add(this.txtCatNo);
			this._fraLedgerInformation_0.Controls.Add(this.lblGroupNo);
			this._fraLedgerInformation_0.Controls.Add(this.lblLGroupName);
			this._fraLedgerInformation_0.Controls.Add(this.txtLCatName);
			this._fraLedgerInformation_0.Controls.Add(this.lblParentGroup);
			this._fraLedgerInformation_0.Controls.Add(this.lblAGroupName);
			this._fraLedgerInformation_0.Controls.Add(this.txtACatName);
			this._fraLedgerInformation_0.Controls.Add(this.lblComments);
			this._fraLedgerInformation_0.Controls.Add(this.txtParentCatNo);
			this._fraLedgerInformation_0.Controls.Add(this.txtParentCatName);
			this._fraLedgerInformation_0.Enabled = true;
			this._fraLedgerInformation_0.ForeColor = System.Drawing.SystemColors.WindowText;
			this._fraLedgerInformation_0.Location = new System.Drawing.Point(1, 23);
			this._fraLedgerInformation_0.Name = "_fraLedgerInformation_0";
			this._fraLedgerInformation_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._fraLedgerInformation_0.Size = new System.Drawing.Size(591, 245);
			this._fraLedgerInformation_0.TabIndex = 9;
			this._fraLedgerInformation_0.Visible = true;
			// 
			// txtComment
			// 
			this.txtComment.AcceptsReturn = true;
			this.txtComment.AllowDrop = true;
			this.txtComment.BackColor = System.Drawing.SystemColors.Window;
			this.txtComment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtComment.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtComment.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtComment.Location = new System.Drawing.Point(150, 104);
			this.txtComment.MaxLength = 100;
			this.txtComment.Multiline = true;
			this.txtComment.Name = "txtComment";
			this.txtComment.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtComment.Size = new System.Drawing.Size(294, 49);
			this.txtComment.TabIndex = 4;
			// 
			// txtCatNo
			// 
			this.txtCatNo.AllowDrop = true;
			this.txtCatNo.BackColor = System.Drawing.Color.White;
			// this.txtCatNo.bolNumericOnly = true;
			this.txtCatNo.ForeColor = System.Drawing.Color.Black;
			this.txtCatNo.Location = new System.Drawing.Point(150, 18);
			this.txtCatNo.MaxLength = 15;
			// this.txtCatNo.mDropDownType = System.Windows.Forms.TextBox.DropDownTypes.ddtNextNumber;
			this.txtCatNo.Name = "txtCatNo";
			// this.txtCatNo.ShowButton = true;
			this.txtCatNo.Size = new System.Drawing.Size(101, 19);
			this.txtCatNo.TabIndex = 0;
			this.txtCatNo.Text = "";
			// this.this.txtCatNo.Watermark = "";
			// this.this.txtCatNo.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCatNo_DropButtonClick);
			// 
			// lblGroupNo
			// 
			this.lblGroupNo.AllowDrop = true;
			this.lblGroupNo.BackColor = System.Drawing.SystemColors.Window;
			this.lblGroupNo.Text = "Category Code";
			this.lblGroupNo.ForeColor = System.Drawing.Color.Black;
			this.lblGroupNo.Location = new System.Drawing.Point(24, 20);
			// // this.lblGroupNo.mLabelId = 987;
			this.lblGroupNo.Name = "lblGroupNo";
			this.lblGroupNo.Size = new System.Drawing.Size(72, 14);
			this.lblGroupNo.TabIndex = 10;
			// 
			// lblLGroupName
			// 
			this.lblLGroupName.AllowDrop = true;
			this.lblLGroupName.BackColor = System.Drawing.SystemColors.Window;
			this.lblLGroupName.Text = "Category Name (English)";
			this.lblLGroupName.ForeColor = System.Drawing.Color.Black;
			this.lblLGroupName.Location = new System.Drawing.Point(24, 42);
			// // this.lblLGroupName.mLabelId = 1019;
			this.lblLGroupName.Name = "lblLGroupName";
			this.lblLGroupName.Size = new System.Drawing.Size(119, 14);
			this.lblLGroupName.TabIndex = 11;
			// 
			// txtLCatName
			// 
			this.txtLCatName.AllowDrop = true;
			this.txtLCatName.BackColor = System.Drawing.Color.White;
			this.txtLCatName.ForeColor = System.Drawing.Color.Black;
			this.txtLCatName.Location = new System.Drawing.Point(150, 39);
			this.txtLCatName.MaxLength = 50;
			this.txtLCatName.Name = "txtLCatName";
			this.txtLCatName.Size = new System.Drawing.Size(201, 19);
			this.txtLCatName.TabIndex = 1;
			this.txtLCatName.Text = "";
			// this.this.txtLCatName.Watermark = "";
			// 
			// lblParentGroup
			// 
			this.lblParentGroup.AllowDrop = true;
			this.lblParentGroup.BackColor = System.Drawing.SystemColors.Window;
			this.lblParentGroup.Text = "Parent Category Code";
			this.lblParentGroup.ForeColor = System.Drawing.Color.Black;
			this.lblParentGroup.Location = new System.Drawing.Point(24, 84);
			// // this.lblParentGroup.mLabelId = 1021;
			this.lblParentGroup.Name = "lblParentGroup";
			this.lblParentGroup.Size = new System.Drawing.Size(106, 14);
			this.lblParentGroup.TabIndex = 12;
			// 
			// lblAGroupName
			// 
			this.lblAGroupName.AllowDrop = true;
			this.lblAGroupName.BackColor = System.Drawing.SystemColors.Window;
			this.lblAGroupName.Text = "Category Name (Arabic)";
			this.lblAGroupName.ForeColor = System.Drawing.Color.Black;
			this.lblAGroupName.Location = new System.Drawing.Point(24, 63);
			// // this.lblAGroupName.mLabelId = 1020;
			this.lblAGroupName.Name = "lblAGroupName";
			this.lblAGroupName.Size = new System.Drawing.Size(117, 14);
			this.lblAGroupName.TabIndex = 13;
			// 
			// txtACatName
			// 
			this.txtACatName.AllowDrop = true;
			this.txtACatName.BackColor = System.Drawing.Color.White;
			this.txtACatName.ForeColor = System.Drawing.Color.Black;
			this.txtACatName.Location = new System.Drawing.Point(150, 60);
			// this.txtACatName.mArabicEnabled = true;
			this.txtACatName.MaxLength = 50;
			this.txtACatName.Name = "txtACatName";
			this.txtACatName.Size = new System.Drawing.Size(201, 19);
			this.txtACatName.TabIndex = 2;
			this.txtACatName.Text = "";
			// this.this.txtACatName.Watermark = "";
			// 
			// lblComments
			// 
			this.lblComments.AllowDrop = true;
			this.lblComments.BackColor = System.Drawing.SystemColors.Window;
			this.lblComments.Text = "Comment";
			this.lblComments.ForeColor = System.Drawing.Color.Black;
			this.lblComments.Location = new System.Drawing.Point(24, 104);
			// // this.lblComments.mLabelId = 135;
			this.lblComments.Name = "lblComments";
			this.lblComments.Size = new System.Drawing.Size(44, 14);
			this.lblComments.TabIndex = 14;
			// 
			// txtParentCatNo
			// 
			this.txtParentCatNo.AllowDrop = true;
			this.txtParentCatNo.BackColor = System.Drawing.Color.White;
			// this.txtParentCatNo.bolNumericOnly = true;
			this.txtParentCatNo.ForeColor = System.Drawing.Color.Black;
			this.txtParentCatNo.Location = new System.Drawing.Point(150, 81);
			this.txtParentCatNo.MaxLength = 15;
			this.txtParentCatNo.Name = "txtParentCatNo";
			// this.txtParentCatNo.ShowButton = true;
			this.txtParentCatNo.Size = new System.Drawing.Size(101, 19);
			this.txtParentCatNo.TabIndex = 3;
			this.txtParentCatNo.Text = "";
			// this.this.txtParentCatNo.Watermark = "";
			// this.this.txtParentCatNo.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtParentCatNo_DropButtonClick);
			// this.txtParentCatNo.Leave += new System.EventHandler(this.txtParentCatNo_Leave);
			// 
			// txtParentCatName
			// 
			this.txtParentCatName.AllowDrop = true;
			this.txtParentCatName.BackColor = System.Drawing.Color.FromArgb(239, 239, 239);
			this.txtParentCatName.Enabled = false;
			this.txtParentCatName.ForeColor = System.Drawing.Color.Black;
			this.txtParentCatName.Location = new System.Drawing.Point(252, 81);
			this.txtParentCatName.Name = "txtParentCatName";
			this.txtParentCatName.Size = new System.Drawing.Size(193, 19);
			this.txtParentCatName.TabIndex = 15;
			this.txtParentCatName.TabStop = false;
			this.txtParentCatName.Text = " ";
			// this.this.txtParentCatName.Watermark = "";
			// 
			// _fraLedgerInformation_3
			// 
			this._fraLedgerInformation_3.AllowDrop = true;
			this._fraLedgerInformation_3.BackColor = System.Drawing.Color.White;
			this._fraLedgerInformation_3.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._fraLedgerInformation_3.Controls.Add(this.grdVoucherDetails);
			this._fraLedgerInformation_3.Controls.Add(this.cmbCommon);
			this._fraLedgerInformation_3.Enabled = true;
			this._fraLedgerInformation_3.ForeColor = System.Drawing.SystemColors.WindowText;
			this._fraLedgerInformation_3.Location = new System.Drawing.Point(634, 23);
			this._fraLedgerInformation_3.Name = "_fraLedgerInformation_3";
			this._fraLedgerInformation_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._fraLedgerInformation_3.Size = new System.Drawing.Size(591, 245);
			this._fraLedgerInformation_3.TabIndex = 7;
			this._fraLedgerInformation_3.Text = "Frame2";
			this._fraLedgerInformation_3.Visible = true;
			// 
			// grdVoucherDetails
			// 
			this.grdVoucherDetails.AllowDrop = true;
			this.grdVoucherDetails.BackColor = System.Drawing.Color.FromArgb(212, 208, 200);
			this.grdVoucherDetails.CellTipsWidth = 0;
			this.grdVoucherDetails.Location = new System.Drawing.Point(0, 12);
			this.grdVoucherDetails.Name = "grdVoucherDetails";
			this.grdVoucherDetails.RowDivider.Color = System.Drawing.Color.FromArgb(212, 208, 200);
			this.grdVoucherDetails.Size = new System.Drawing.Size(635, 233);
			this.grdVoucherDetails.TabIndex = 5;
			this.grdVoucherDetails.Columns.Add(this.Column_0_grdVoucherDetails);
			this.grdVoucherDetails.Columns.Add(this.Column_1_grdVoucherDetails);
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
			// cmbCommon
			// 
			this.cmbCommon.AllowDrop = true;
			this.cmbCommon.ColumnHeaders = true;
			this.cmbCommon.Enabled = true;
			this.cmbCommon.Location = new System.Drawing.Point(38, 74);
			this.cmbCommon.Name = "cmbCommon";
			this.cmbCommon.Size = new System.Drawing.Size(113, 33);
			this.cmbCommon.TabIndex = 8;
			this.cmbCommon.Columns.Add(this.Column_0_cmbCommon);
			this.cmbCommon.Columns.Add(this.Column_1_cmbCommon);
			// 
			// Column_0_cmbCommon
			// 
			this.Column_0_cmbCommon.DataField = "";
			this.Column_0_cmbCommon.ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.Normal;
			// 
			// Column_1_cmbCommon
			// 
			this.Column_1_cmbCommon.DataField = "";
			this.Column_1_cmbCommon.ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.Normal;
			// 
			// ElasticOne1
			// 
			this.ElasticOne1.Align = C1SizerLib.AlignSettings.asNone;
			this.ElasticOne1.AllowDrop = true;
			this.ElasticOne1.Location = new System.Drawing.Point(-36, 40);
			this.ElasticOne1.Name = "ElasticOne1";
			("ElasticOne1.OcxState");
			this.ElasticOne1.Size = new System.Drawing.Size(689, 546);
			this.ElasticOne1.TabIndex = 16;
			this.ElasticOne1.TabStop = false;
			// 
			// frmFACategory
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.ClientSize = new System.Drawing.Size(624, 336);
			this.Controls.Add(this.tabMaster);
			this.Controls.Add(this.ElasticOne1);
			//this.Icon = (System.Drawing.Icon) resources.GetObject("frmFACategory.Icon");
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(107, 464);
			this.MaximizeBox = true;
			this.MinimizeBox = true;
			this.Name = "frmFACategory";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Fixed Assets Category";
			// this.Activated += new System.EventHandler(this.frmFACategory_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
			// this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
			//((System.ComponentModel.ISupportInitialize) this.tabMaster).EndInit();
			//((System.ComponentModel.ISupportInitialize) this.ElasticOne1).EndInit();
			this.tabMaster.ResumeLayout(false);
			this._fraLedgerInformation_0.ResumeLayout(false);
			this._fraLedgerInformation_3.ResumeLayout(false);
			this.grdVoucherDetails.ResumeLayout(false);
			this.cmbCommon.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		// 
		void InitializefraLedgerInformation()
		{
			this.fraLedgerInformation = new System.Windows.Forms.Panel[4];
			this.fraLedgerInformation[0] = _fraLedgerInformation_0;
			this.fraLedgerInformation[3] = _fraLedgerInformation_3;
		}
		#endregion
	}
}//ENDSHERE
