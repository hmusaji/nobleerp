
namespace Xtreme
{
	partial class frmPayDocumentDetails
	{

		#region "Upgrade Support "
		private static frmPayDocumentDetails m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmPayDocumentDetails DefInstance
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
		public static frmPayDocumentDetails CreateInstance()
		{
			frmPayDocumentDetails theInstance = new frmPayDocumentDetails();
			
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
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "_txtCommonTextBox_5", "_lblCommonLabel_0", "_txtDisplayLabel_3", "lblSystemComponents", "Column_0_cmbMastersList", "Column_1_cmbMastersList", "cmbMastersList", "txtIssueDate", "txtExpireDate", "Column_0_cmbMastersList1", "Column_1_cmbMastersList1", "cmbMastersList1", "Column_0_cmbMastersList2", "Column_1_cmbMastersList2", "cmbMastersList2", "Column_0_grdVoucherDetails", "Column_1_grdVoucherDetails", "grdVoucherDetails", "_lblCommon_102", "txtStatucCd", "CommonDialog1Open", "CommonDialog1", "Line1", "lblCommon", "lblCommonLabel", "txtCommonTextBox", "txtDisplayLabel"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		private System.Windows.Forms.TextBox _txtCommonTextBox_5;
		private System.Windows.Forms.Label _lblCommonLabel_0;
		private System.Windows.Forms.Label _txtDisplayLabel_3;
		public System.Windows.Forms.Label lblSystemComponents;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_0_cmbMastersList;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_1_cmbMastersList;
		public C1.Win.C1TrueDBGrid.C1TrueDBDropdown cmbMastersList;
		public Syncfusion.WinForms.Input.SfDateTimeEdit txtIssueDate;
		public Syncfusion.WinForms.Input.SfDateTimeEdit txtExpireDate;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_0_cmbMastersList1;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_1_cmbMastersList1;
		public C1.Win.C1TrueDBGrid.C1TrueDBDropdown cmbMastersList1;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_0_cmbMastersList2;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_1_cmbMastersList2;
		public C1.Win.C1TrueDBGrid.C1TrueDBDropdown cmbMastersList2;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_0_grdVoucherDetails;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_1_grdVoucherDetails;
		public C1.Win.C1TrueDBGrid.C1TrueDBGrid grdVoucherDetails;
		private System.Windows.Forms.Label _lblCommon_102;
		public System.Windows.Forms.Label txtStatucCd;
		public System.Windows.Forms.OpenFileDialog CommonDialog1Open;
		public UpgradeStubs.AxMSComDlg_AxCommonDialog CommonDialog1;
		public System.Windows.Forms.Label Line1;
		public System.Windows.Forms.Label[] lblCommon = new System.Windows.Forms.Label[103];
		public System.Windows.Forms.Label[] lblCommonLabel = new System.Windows.Forms.Label[1];
		public System.Windows.Forms.TextBox[] txtCommonTextBox = new System.Windows.Forms.TextBox[6];
		public System.Windows.Forms.Label[] txtDisplayLabel = new System.Windows.Forms.Label[4];
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPayDocumentDetails));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this._txtCommonTextBox_5 = new System.Windows.Forms.TextBox();
			this._lblCommonLabel_0 = new System.Windows.Forms.Label();
			this._txtDisplayLabel_3 = new System.Windows.Forms.Label();
			this.lblSystemComponents = new System.Windows.Forms.Label();
			this.cmbMastersList = new C1.Win.C1TrueDBGrid.C1TrueDBDropdown();
			this.Column_0_cmbMastersList = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.Column_1_cmbMastersList = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.txtIssueDate = new Syncfusion.WinForms.Input.SfDateTimeEdit();
			this.txtExpireDate = new Syncfusion.WinForms.Input.SfDateTimeEdit();
			this.cmbMastersList1 = new C1.Win.C1TrueDBGrid.C1TrueDBDropdown();
			this.Column_0_cmbMastersList1 = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.Column_1_cmbMastersList1 = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.cmbMastersList2 = new C1.Win.C1TrueDBGrid.C1TrueDBDropdown();
			this.Column_0_cmbMastersList2 = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.Column_1_cmbMastersList2 = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.grdVoucherDetails = new C1.Win.C1TrueDBGrid.C1TrueDBGrid();
			this.Column_0_grdVoucherDetails = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.Column_1_grdVoucherDetails = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this._lblCommon_102 = new System.Windows.Forms.Label();
			this.txtStatucCd = new System.Windows.Forms.Label();
			this.CommonDialog1Open = new System.Windows.Forms.OpenFileDialog();
			this.CommonDialog1 = new UpgradeStubs.AxMSComDlg_AxCommonDialog();
			this.Line1 = new System.Windows.Forms.Label();
			// //((System.ComponentModel.ISupportInitialize) this.txtIssueDate).BeginInit();
			// //((System.ComponentModel.ISupportInitialize) this.txtExpireDate).BeginInit();
			this.cmbMastersList.SuspendLayout();
			this.cmbMastersList1.SuspendLayout();
			this.cmbMastersList2.SuspendLayout();
			this.grdVoucherDetails.SuspendLayout();
			this.SuspendLayout();
			// 
			// _txtCommonTextBox_5
			// 
			this._txtCommonTextBox_5.AllowDrop = true;
			this._txtCommonTextBox_5.BackColor = System.Drawing.Color.FromArgb(239, 239, 239);
			this._txtCommonTextBox_5.Enabled = false;
			this._txtCommonTextBox_5.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_5.Location = new System.Drawing.Point(102, 54);
			this._txtCommonTextBox_5.MaxLength = 10;
			this._txtCommonTextBox_5.Name = "_txtCommonTextBox_5";
			// this._txtCommonTextBox_5.ShowButton = true;
			this._txtCommonTextBox_5.Size = new System.Drawing.Size(101, 19);
			this._txtCommonTextBox_5.TabIndex = 0;
			this._txtCommonTextBox_5.Text = "";
			// 
			// _lblCommonLabel_0
			// 
			this._lblCommonLabel_0.AllowDrop = true;
			this._lblCommonLabel_0.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_0.Text = "Employee Code";
			this._lblCommonLabel_0.Location = new System.Drawing.Point(6, 56);
			// // this._lblCommonLabel_0.mLabelId = 236;
			this._lblCommonLabel_0.Name = "_lblCommonLabel_0";
			this._lblCommonLabel_0.Size = new System.Drawing.Size(74, 14);
			this._lblCommonLabel_0.TabIndex = 1;
			// 
			// _txtDisplayLabel_3
			// 
			this._txtDisplayLabel_3.AllowDrop = true;
			this._txtDisplayLabel_3.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			this._txtDisplayLabel_3.Location = new System.Drawing.Point(205, 54);
			this._txtDisplayLabel_3.Name = "_txtDisplayLabel_3";
			this._txtDisplayLabel_3.Size = new System.Drawing.Size(213, 19);
			this._txtDisplayLabel_3.TabIndex = 2;
			// 
			// lblSystemComponents
			// 
			this.lblSystemComponents.AllowDrop = true;
			this.lblSystemComponents.BackColor = System.Drawing.Color.FromArgb(237, 231, 235);
			this.lblSystemComponents.Text = "Employee Document Details";
			this.lblSystemComponents.Location = new System.Drawing.Point(15, 78);
			this.lblSystemComponents.Name = "lblSystemComponents";
			this.lblSystemComponents.Size = new System.Drawing.Size(158, 13);
			this.lblSystemComponents.TabIndex = 4;
			// 
			// cmbMastersList
			// 
			this.cmbMastersList.AllowDrop = true;
			this.cmbMastersList.ColumnHeaders = true;
			this.cmbMastersList.Enabled = true;
			this.cmbMastersList.Location = new System.Drawing.Point(360, 156);
			this.cmbMastersList.Name = "cmbMastersList";
			this.cmbMastersList.Size = new System.Drawing.Size(53, 43);
			this.cmbMastersList.TabIndex = 5;
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
			// txtIssueDate
			// 
			this.txtIssueDate.AllowDrop = true;
			this.txtIssueDate.Location = new System.Drawing.Point(573, 183);
			this.txtIssueDate.Name = "txtIssueDate";
			("txtIssueDate.OcxState");
			this.txtIssueDate.Size = new System.Drawing.Size(109, 19);
			this.txtIssueDate.TabIndex = 6;
			this.txtIssueDate.Visible = false;
			// 
			// txtExpireDate
			// 
			this.txtExpireDate.AllowDrop = true;
			this.txtExpireDate.Location = new System.Drawing.Point(573, 156);
			this.txtExpireDate.Name = "txtExpireDate";
			("txtExpireDate.OcxState");
			this.txtExpireDate.Size = new System.Drawing.Size(109, 19);
			this.txtExpireDate.TabIndex = 7;
			this.txtExpireDate.Visible = false;
			// 
			// cmbMastersList1
			// 
			this.cmbMastersList1.AllowDrop = true;
			this.cmbMastersList1.ColumnHeaders = true;
			this.cmbMastersList1.Enabled = true;
			this.cmbMastersList1.Location = new System.Drawing.Point(432, 153);
			this.cmbMastersList1.Name = "cmbMastersList1";
			this.cmbMastersList1.Size = new System.Drawing.Size(53, 43);
			this.cmbMastersList1.TabIndex = 8;
			this.cmbMastersList1.Columns.Add(this.Column_0_cmbMastersList1);
			this.cmbMastersList1.Columns.Add(this.Column_1_cmbMastersList1);
			// 
			// Column_0_cmbMastersList1
			// 
			this.Column_0_cmbMastersList1.DataField = "";
			this.Column_0_cmbMastersList1.ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.Normal;
			// 
			// Column_1_cmbMastersList1
			// 
			this.Column_1_cmbMastersList1.DataField = "";
			this.Column_1_cmbMastersList1.ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.Normal;
			// 
			// cmbMastersList2
			// 
			this.cmbMastersList2.AllowDrop = true;
			this.cmbMastersList2.ColumnHeaders = true;
			this.cmbMastersList2.Enabled = true;
			this.cmbMastersList2.Location = new System.Drawing.Point(489, 153);
			this.cmbMastersList2.Name = "cmbMastersList2";
			this.cmbMastersList2.Size = new System.Drawing.Size(53, 43);
			this.cmbMastersList2.TabIndex = 9;
			this.cmbMastersList2.Columns.Add(this.Column_0_cmbMastersList2);
			this.cmbMastersList2.Columns.Add(this.Column_1_cmbMastersList2);
			// 
			// Column_0_cmbMastersList2
			// 
			this.Column_0_cmbMastersList2.DataField = "";
			this.Column_0_cmbMastersList2.ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.Normal;
			// 
			// Column_1_cmbMastersList2
			// 
			this.Column_1_cmbMastersList2.DataField = "";
			this.Column_1_cmbMastersList2.ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.Normal;
			// 
			// grdVoucherDetails
			// 
			this.grdVoucherDetails.AllowDrop = true;
			this.grdVoucherDetails.BackColor = System.Drawing.Color.Silver;
			this.grdVoucherDetails.CellTipsWidth = 0;
			this.grdVoucherDetails.Location = new System.Drawing.Point(3, 96);
			this.grdVoucherDetails.Name = "grdVoucherDetails";
			this.grdVoucherDetails.RowDivider.Color = System.Drawing.Color.Silver;
			this.grdVoucherDetails.Size = new System.Drawing.Size(807, 261);
			this.grdVoucherDetails.TabIndex = 3;
			this.grdVoucherDetails.Columns.Add(this.Column_0_grdVoucherDetails);
			this.grdVoucherDetails.Columns.Add(this.Column_1_grdVoucherDetails);
			this.grdVoucherDetails.AfterColUpdate += new C1.Win.C1TrueDBGrid.ColEventHandler(this.grdVoucherDetails_AfterColUpdate);
			this.grdVoucherDetails.ButtonClick += new C1.Win.C1TrueDBGrid.ColEventHandler(this.grdVoucherDetails_ButtonClick);
			this.grdVoucherDetails.GotFocus += new System.EventHandler(this.grdVoucherDetails_GotFocus);
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
			// _lblCommon_102
			// 
			this._lblCommon_102.AllowDrop = true;
			this._lblCommon_102.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_102.Text = "Status";
			this._lblCommon_102.Location = new System.Drawing.Point(633, 57);
			// // this._lblCommon_102.mLabelId = 1834;
			this._lblCommon_102.Name = "_lblCommon_102";
			this._lblCommon_102.Size = new System.Drawing.Size(31, 14);
			this._lblCommon_102.TabIndex = 10;
			// 
			// txtStatucCd
			// 
			this.txtStatucCd.AllowDrop = true;
			this.txtStatucCd.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			this.txtStatucCd.Location = new System.Drawing.Point(680, 54);
			this.txtStatucCd.Name = "txtStatucCd";
			this.txtStatucCd.Size = new System.Drawing.Size(89, 19);
			this.txtStatucCd.TabIndex = 11;
			this.txtStatucCd.TabStop = false;
			// 
			// Line1
			// 
			this.Line1.AllowDrop = true;
			this.Line1.BackColor = System.Drawing.SystemColors.WindowText;
			this.Line1.Enabled = false;
			this.Line1.Location = new System.Drawing.Point(0, 84);
			this.Line1.Name = "Line1";
			this.Line1.Size = new System.Drawing.Size(807, 1);
			this.Line1.Visible = true;
			// 
			// frmPayDocumentDetails
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.ClientSize = new System.Drawing.Size(815, 358);
			this.Controls.Add(this._txtCommonTextBox_5);
			this.Controls.Add(this._lblCommonLabel_0);
			this.Controls.Add(this._txtDisplayLabel_3);
			this.Controls.Add(this.lblSystemComponents);
			this.Controls.Add(this.cmbMastersList);
			this.Controls.Add(this.txtIssueDate);
			this.Controls.Add(this.txtExpireDate);
			this.Controls.Add(this.cmbMastersList1);
			this.Controls.Add(this.cmbMastersList2);
			this.Controls.Add(this.grdVoucherDetails);
			this.Controls.Add(this._lblCommon_102);
			this.Controls.Add(this.txtStatucCd);
			this.Controls.Add(this.Line1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			//this.Icon = (System.Drawing.Icon) resources.GetObject("frmPayDocumentDetails.Icon");
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(122, 127);
			this.MaximizeBox = true;
			this.MinimizeBox = true;
			this.Name = "frmPayDocumentDetails";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Document Details";
			// this.Activated += new System.EventHandler(this.frmPayDocumentDetails_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
			// this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
			//((System.ComponentModel.ISupportInitialize) this.txtIssueDate).EndInit();
			//((System.ComponentModel.ISupportInitialize) this.txtExpireDate).EndInit();
			this.cmbMastersList.ResumeLayout(false);
			this.cmbMastersList1.ResumeLayout(false);
			this.cmbMastersList2.ResumeLayout(false);
			this.grdVoucherDetails.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		// 
		void InitializetxtDisplayLabel()
		{
			this.txtDisplayLabel = new System.Windows.Forms.Label[4];
			this.txtDisplayLabel[3] = _txtDisplayLabel_3;
		}
		void InitializetxtCommonTextBox()
		{
			this.txtCommonTextBox = new System.Windows.Forms.TextBox[6];
			this.txtCommonTextBox[5] = _txtCommonTextBox_5;
		}
		void InitializelblCommonLabel()
		{
			this.lblCommonLabel = new System.Windows.Forms.Label[1];
			this.lblCommonLabel[0] = _lblCommonLabel_0;
		}
		void InitializelblCommon()
		{
			this.lblCommon = new System.Windows.Forms.Label[103];
			this.lblCommon[102] = _lblCommon_102;
		}
		#endregion
	}
}//ENDSHERE
