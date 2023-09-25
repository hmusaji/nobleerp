
namespace Xtreme
{
	partial class frmICSBarcodeDataCollection
	{

		#region "Upgrade Support "
		private static frmICSBarcodeDataCollection m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmICSBarcodeDataCollection DefInstance
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
		public static frmICSBarcodeDataCollection CreateInstance()
		{
			frmICSBarcodeDataCollection theInstance = new frmICSBarcodeDataCollection();
			
			return theInstance;
		}
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "conImportICSTrans", "txtGLVoucherName", "txtGLVoucherType", "System.Windows.Forms.Label2", "System.Windows.Forms.Label3", "txtGLVoucherNo", "conImportGLVoucher", "cmdFileSearch", "System.Windows.Forms.Label1", "_txtCommonLable_0", "conFileImport", "tabMaster", "cdgFileSystemOpen", "cdgFileSystem", "UCOkCancel1", "txtCommonLable"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public AxC1SizerLib.AxC1Elastic conImportICSTrans;
		public System.Windows.Forms.Label txtGLVoucherName;
		public System.Windows.Forms.TextBox txtGLVoucherType;
		public System.Windows.Forms.Label Label2;
		public System.Windows.Forms.Label Label3;
		public System.Windows.Forms.TextBox txtGLVoucherNo;
		public AxC1SizerLib.AxC1Elastic conImportGLVoucher;
		public System.Windows.Forms.Button cmdFileSearch;
		public System.Windows.Forms.Label Label1;
		private System.Windows.Forms.Label _txtCommonLable_0;
		public AxC1SizerLib.AxC1Elastic conFileImport;
		public AxC1SizerLib.AxC1Tab tabMaster;
		public System.Windows.Forms.OpenFileDialog cdgFileSystemOpen;
		public UpgradeStubs.AxMSComDlg_AxCommonDialog cdgFileSystem;
		public UCOkCancel UCOkCancel1;
		public System.Windows.Forms.Label[] txtCommonLable = new System.Windows.Forms.Label[1];
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmICSBarcodeDataCollection));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this.tabMaster = new AxC1SizerLib.AxC1Tab();
			this.conImportICSTrans = new AxC1SizerLib.AxC1Elastic();
			this.conImportGLVoucher = new AxC1SizerLib.AxC1Elastic();
			this.txtGLVoucherName = new System.Windows.Forms.Label();
			this.txtGLVoucherType = new System.Windows.Forms.TextBox();
			this.Label2 = new System.Windows.Forms.Label();
			this.Label3 = new System.Windows.Forms.Label();
			this.txtGLVoucherNo = new System.Windows.Forms.TextBox();
			this.conFileImport = new AxC1SizerLib.AxC1Elastic();
			this.cmdFileSearch = new System.Windows.Forms.Button();
			this.Label1 = new System.Windows.Forms.Label();
			this._txtCommonLable_0 = new System.Windows.Forms.Label();
			this.cdgFileSystemOpen = new System.Windows.Forms.OpenFileDialog();
			this.cdgFileSystem = new UpgradeStubs.AxMSComDlg_AxCommonDialog();
			this.UCOkCancel1 = new UCOkCancel();
			// //((System.ComponentModel.ISupportInitialize) this.conImportICSTrans).BeginInit();
			// //((System.ComponentModel.ISupportInitialize) this.conImportGLVoucher).BeginInit();
			// //((System.ComponentModel.ISupportInitialize) this.conFileImport).BeginInit();
			// //((System.ComponentModel.ISupportInitialize) this.tabMaster).BeginInit();
			this.tabMaster.SuspendLayout();
			this.conImportGLVoucher.SuspendLayout();
			this.conFileImport.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabMaster
			// 
			this.tabMaster.Align = C1SizerLib.AlignSettings.asNone;
			this.tabMaster.AllowDrop = true;
			this.tabMaster.Controls.Add(this.conImportICSTrans);
			this.tabMaster.Controls.Add(this.conImportGLVoucher);
			this.tabMaster.Controls.Add(this.conFileImport);
			this.tabMaster.Location = new System.Drawing.Point(4, 2);
			this.tabMaster.Name = "tabMaster";
			("tabMaster.OcxState");
			this.tabMaster.Size = new System.Drawing.Size(455, 155);
			this.tabMaster.TabIndex = 0;
			// 
			// conImportICSTrans
			// 
			this.conImportICSTrans.Align = C1SizerLib.AlignSettings.asNone;
			this.conImportICSTrans.AllowDrop = true;
			this.conImportICSTrans.Location = new System.Drawing.Point(518, 23);
			this.conImportICSTrans.Name = "conImportICSTrans";
			("conImportICSTrans.OcxState");
			this.conImportICSTrans.Size = new System.Drawing.Size(449, 129);
			this.conImportICSTrans.TabIndex = 3;
			this.conImportICSTrans.TabStop = false;
			// 
			// conImportGLVoucher
			// 
			this.conImportGLVoucher.Align = C1SizerLib.AlignSettings.asNone;
			this.conImportGLVoucher.AllowDrop = true;
			this.conImportGLVoucher.Controls.Add(this.txtGLVoucherName);
			this.conImportGLVoucher.Controls.Add(this.txtGLVoucherType);
			this.conImportGLVoucher.Controls.Add(this.Label2);
			this.conImportGLVoucher.Controls.Add(this.Label3);
			this.conImportGLVoucher.Controls.Add(this.txtGLVoucherNo);
			this.conImportGLVoucher.Location = new System.Drawing.Point(498, 23);
			this.conImportGLVoucher.Name = "conImportGLVoucher";
			("conImportGLVoucher.OcxState");
			this.conImportGLVoucher.Size = new System.Drawing.Size(449, 129);
			this.conImportGLVoucher.TabIndex = 2;
			this.conImportGLVoucher.TabStop = false;
			// 
			// txtGLVoucherName
			// 
			this.txtGLVoucherName.AllowDrop = true;
			this.txtGLVoucherName.BackColor = System.Drawing.SystemColors.Window;
			this.txtGLVoucherName.Enabled = false;
			this.txtGLVoucherName.Location = new System.Drawing.Point(177, 29);
			this.txtGLVoucherName.Name = "txtGLVoucherName";
			this.txtGLVoucherName.Size = new System.Drawing.Size(171, 19);
			this.txtGLVoucherName.TabIndex = 11;
			// 
			// txtGLVoucherType
			// 
			this.txtGLVoucherType.AllowDrop = true;
			this.txtGLVoucherType.BackColor = System.Drawing.Color.White;
			// this.txtGLVoucherType.bolAllowDecimal = false;
			this.txtGLVoucherType.ForeColor = System.Drawing.Color.Black;
			this.txtGLVoucherType.Location = new System.Drawing.Point(90, 29);
			// this.txtGLVoucherType.mDropDownType = (System.Windows.Forms.TextBox.DropDownTypes) 0;
			this.txtGLVoucherType.Name = "txtGLVoucherType";
			// this.txtGLVoucherType.ShowButton = true;
			this.txtGLVoucherType.Size = new System.Drawing.Size(85, 19);
			this.txtGLVoucherType.TabIndex = 10;
			this.txtGLVoucherType.Text = "";
			// this.this.txtGLVoucherType.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtGLVoucherType_DropButtonClick);
			// 
			// System.Windows.Forms.Label2
			// 
			this.Label2.AllowDrop = true;
			this.Label2.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.Label2.Text = "Voucher Type";
			this.Label2.Location = new System.Drawing.Point(16, 32);
			this.Label2.Name = "System.Windows.Forms.Label2";
			this.Label2.Size = new System.Drawing.Size(67, 13);
			this.Label2.TabIndex = 8;
			// 
			// System.Windows.Forms.Label3
			// 
			this.Label3.AllowDrop = true;
			this.Label3.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.Label3.Text = "Voucher No";
			this.Label3.Location = new System.Drawing.Point(16, 52);
			this.Label3.Name = "System.Windows.Forms.Label3";
			this.Label3.Size = new System.Drawing.Size(57, 13);
			this.Label3.TabIndex = 9;
			// 
			// txtGLVoucherNo
			// 
			this.txtGLVoucherNo.AllowDrop = true;
			this.txtGLVoucherNo.BackColor = System.Drawing.Color.White;
			// this.txtGLVoucherNo.bolAllowDecimal = false;
			this.txtGLVoucherNo.ForeColor = System.Drawing.Color.Black;
			this.txtGLVoucherNo.Location = new System.Drawing.Point(90, 50);
			// this.txtGLVoucherNo.mDropDownType = (System.Windows.Forms.TextBox.DropDownTypes) 0;
			this.txtGLVoucherNo.Name = "txtGLVoucherNo";
			// this.txtGLVoucherNo.ShowButton = true;
			this.txtGLVoucherNo.Size = new System.Drawing.Size(85, 19);
			this.txtGLVoucherNo.TabIndex = 12;
			this.txtGLVoucherNo.Text = "";
			// this.this.txtGLVoucherNo.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtGLVoucherNo_DropButtonClick);
			// 
			// conFileImport
			// 
			this.conFileImport.Align = C1SizerLib.AlignSettings.asNone;
			this.conFileImport.AllowDrop = true;
			this.conFileImport.Controls.Add(this.cmdFileSearch);
			this.conFileImport.Controls.Add(this.Label1);
			this.conFileImport.Controls.Add(this._txtCommonLable_0);
			this.conFileImport.Location = new System.Drawing.Point(3, 23);
			this.conFileImport.Name = "conFileImport";
			("conFileImport.OcxState");
			this.conFileImport.Size = new System.Drawing.Size(449, 129);
			this.conFileImport.TabIndex = 1;
			this.conFileImport.TabStop = false;
			// 
			// cmdFileSearch
			// 
			this.cmdFileSearch.AllowDrop = true;
			this.cmdFileSearch.BackColor = System.Drawing.SystemColors.Control;
			this.cmdFileSearch.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdFileSearch.Location = new System.Drawing.Point(407, 10);
			this.cmdFileSearch.Name = "cmdFileSearch";
			this.cmdFileSearch.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdFileSearch.Size = new System.Drawing.Size(32, 19);
			this.cmdFileSearch.TabIndex = 5;
			this.cmdFileSearch.Text = "...";
			this.cmdFileSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.cmdFileSearch.UseVisualStyleBackColor = false;
			// this.cmdFileSearch.Click += new System.EventHandler(this.cmdFileSearch_Click);
			// 
			// System.Windows.Forms.Label1
			// 
			this.Label1.AllowDrop = true;
			this.Label1.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.Label1.Text = "File Name";
			this.Label1.Location = new System.Drawing.Point(8, 12);
			this.Label1.Name = "System.Windows.Forms.Label1";
			this.Label1.Size = new System.Drawing.Size(47, 13);
			this.Label1.TabIndex = 4;
			// 
			// _txtCommonLable_0
			// 
			this._txtCommonLable_0.AllowDrop = true;
			this._txtCommonLable_0.Location = new System.Drawing.Point(60, 10);
			this._txtCommonLable_0.Name = "_txtCommonLable_0";
			this._txtCommonLable_0.Size = new System.Drawing.Size(345, 19);
			this._txtCommonLable_0.TabIndex = 6;
			// 
			// UCOkCancel1
			// 
			this.UCOkCancel1.AllowDrop = true;
			this.UCOkCancel1.DisplayButton = 0;
			this.UCOkCancel1.Location = new System.Drawing.Point(250, 162);
			this.UCOkCancel1.Name = "UCOkCancel1";
			this.UCOkCancel1.OkCaption = "&Ok";
			this.UCOkCancel1.Size = new System.Drawing.Size(206, 31);
			this.UCOkCancel1.TabIndex = 7;
			this.UCOkCancel1.CancelClick += new UCOkCancel.CancelClickHandler(this.UCOkCancel1_CancelClick);
			this.UCOkCancel1.OKClick += new UCOkCancel.OKClickHandler(this.UCOkCancel1_OKClick);
			// 
			// frmICSBarcodeDataCollection
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.ClientSize = new System.Drawing.Size(465, 195);
			this.Controls.Add(this.tabMaster);
			this.Controls.Add(this.UCOkCancel1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			//this.Icon = (System.Drawing.Icon) resources.GetObject("frmICSBarcodeDataCollection.Icon");
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(301, 273);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmICSBarcodeDataCollection";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.ShowInTaskbar = false;
			this.Text = "Import Data";
			// this.Activated += new System.EventHandler(this.frmICSBarcodeDataCollection_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
			// this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
			//((System.ComponentModel.ISupportInitialize) this.conImportICSTrans).EndInit();
			//((System.ComponentModel.ISupportInitialize) this.conImportGLVoucher).EndInit();
			//((System.ComponentModel.ISupportInitialize) this.conFileImport).EndInit();
			//((System.ComponentModel.ISupportInitialize) this.tabMaster).EndInit();
			this.tabMaster.ResumeLayout(false);
			this.conImportGLVoucher.ResumeLayout(false);
			this.conFileImport.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		// 
		void InitializetxtCommonLable()
		{
			this.txtCommonLable = new System.Windows.Forms.Label[1];
			this.txtCommonLable[0] = _txtCommonLable_0;
		}
		#endregion
	}
}//ENDSHERE
