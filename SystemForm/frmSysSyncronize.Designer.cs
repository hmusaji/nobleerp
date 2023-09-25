
namespace Xtreme
{
	partial class frmSysSyncronize
	{

		#region "Upgrade Support "
		private static frmSysSyncronize m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmSysSyncronize DefInstance
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
		public static frmSysSyncronize CreateInstance()
		{
			frmSysSyncronize theInstance = new frmSysSyncronize();
			
			return theInstance;
		}
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "chkPostTransactions", "txtImportPath", "System.Windows.Forms.Label2", "lblImportStatus", "ImportProgress", "frmImport2", "cmdImport", "txtImportDisplayLocation", "Label_2", "lblImportLocation", "txtImportLocationCode", "txtImportFromDate", "Label_3", "txtImportToDate", "Label_4", "CommonDialog1Open", "CommonDialog1", "frmImport1", "tbExport", "cmdExport", "txtExportPath", "lblPath", "lblExportStatus", "ExportProgress", "Frame1", "txtExportDisplayLocation", "Label_0", "lblExportLocation", "txtExportLocationCode", "txtExportFromDate", "Label_7", "txtExportToDate", "Label_1", "Frame", "tbImport", "TabControlPage1", "tbTabControl", "System.Windows.Forms.Label"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public System.Windows.Forms.CheckBox chkPostTransactions;
		public System.Windows.Forms.TextBox txtImportPath;
		public System.Windows.Forms.Label Label2;
		public System.Windows.Forms.Label lblImportStatus;
		public Syncfusion.Windows.Forms.Tools.ProgressBarAdv ImportProgress;
		public System.Windows.Forms.GroupBox frmImport2;
		public System.Windows.Forms.Button cmdImport;
		public System.Windows.Forms.Label txtImportDisplayLocation;
		private System.Windows.Forms.Label Label_2;
		public System.Windows.Forms.Label lblImportLocation;
		public System.Windows.Forms.TextBox txtImportLocationCode;
		public Syncfusion.WinForms.Input.SfDateTimeEdit txtImportFromDate;
		private System.Windows.Forms.Label Label_3;
		public Syncfusion.WinForms.Input.SfDateTimeEdit txtImportToDate;
		private System.Windows.Forms.Label Label_4;
		public System.Windows.Forms.OpenFileDialog CommonDialog1Open;
		//public UpgradeStubs.AxMSComDlg_AxCommonDialog CommonDialog1;
		public System.Windows.Forms.GroupBox frmImport1;
		public Syncfusion.Windows.Forms.Tools.TabPageAdv tbExport;
		public System.Windows.Forms.Button cmdExport;
		public System.Windows.Forms.TextBox txtExportPath;
		public System.Windows.Forms.Label lblPath;
		public System.Windows.Forms.Label lblExportStatus;
		public Syncfusion.Windows.Forms.Tools.ProgressBarAdv ExportProgress;
		public System.Windows.Forms.GroupBox Frame1;
		public System.Windows.Forms.Label txtExportDisplayLocation;
		private System.Windows.Forms.Label Label_0;
		public System.Windows.Forms.Label lblExportLocation;
		public System.Windows.Forms.TextBox txtExportLocationCode;
		public Syncfusion.WinForms.Input.SfDateTimeEdit txtExportFromDate;
		private System.Windows.Forms.Label Label_7;
		public Syncfusion.WinForms.Input.SfDateTimeEdit txtExportToDate;
		private System.Windows.Forms.Label Label_1;
		public System.Windows.Forms.GroupBox Frame;
		public Syncfusion.Windows.Forms.Tools.TabPageAdv tbImport;
		public Syncfusion.Windows.Forms.Tools.TabPageAdv TabControlPage1;
		public Syncfusion.Windows.Forms.Tools.TabControlAdv tbTabControl;
		public System.Windows.Forms.Label[] Label = new System.Windows.Forms.Label[8];
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSysSyncronize));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this.tbTabControl = new Syncfusion.Windows.Forms.Tools.TabControlAdv();
			this.tbExport = new Syncfusion.Windows.Forms.Tools.TabPageAdv();
			this.frmImport2 = new System.Windows.Forms.GroupBox();
			this.chkPostTransactions = new System.Windows.Forms.CheckBox();
			this.txtImportPath = new System.Windows.Forms.TextBox();
			this.Label2 = new System.Windows.Forms.Label();
			this.lblImportStatus = new System.Windows.Forms.Label();
			this.ImportProgress = new Syncfusion.Windows.Forms.Tools.ProgressBarAdv();
			this.cmdImport = new System.Windows.Forms.Button();
			this.frmImport1 = new System.Windows.Forms.GroupBox();
			this.txtImportDisplayLocation = new System.Windows.Forms.Label();
			this.Label_2 = new System.Windows.Forms.Label();
			this.lblImportLocation = new System.Windows.Forms.Label();
			this.txtImportLocationCode = new System.Windows.Forms.TextBox();
			this.txtImportFromDate = new Syncfusion.WinForms.Input.SfDateTimeEdit();
			this.Label_3 = new System.Windows.Forms.Label();
			this.txtImportToDate = new Syncfusion.WinForms.Input.SfDateTimeEdit();
			this.Label_4 = new System.Windows.Forms.Label();
			this.CommonDialog1Open = new System.Windows.Forms.OpenFileDialog();
			//this.CommonDialog1 = new UpgradeStubs.AxMSComDlg_AxCommonDialog();
			this.tbImport = new Syncfusion.Windows.Forms.Tools.TabPageAdv();
			this.cmdExport = new System.Windows.Forms.Button();
			this.Frame1 = new System.Windows.Forms.GroupBox();
			this.txtExportPath = new System.Windows.Forms.TextBox();
			this.lblPath = new System.Windows.Forms.Label();
			this.lblExportStatus = new System.Windows.Forms.Label();
			this.ExportProgress = new Syncfusion.Windows.Forms.Tools.ProgressBarAdv();
			this.Frame = new System.Windows.Forms.GroupBox();
			this.txtExportDisplayLocation = new System.Windows.Forms.Label();
			this.Label_0 = new System.Windows.Forms.Label();
			this.lblExportLocation = new System.Windows.Forms.Label();
			this.txtExportLocationCode = new System.Windows.Forms.TextBox();
			this.txtExportFromDate = new Syncfusion.WinForms.Input.SfDateTimeEdit();
			this.Label_7 = new System.Windows.Forms.Label();
			this.txtExportToDate = new Syncfusion.WinForms.Input.SfDateTimeEdit();
			this.Label_1 = new System.Windows.Forms.Label();
			this.TabControlPage1 = new Syncfusion.Windows.Forms.Tools.TabPageAdv();
			// //((System.ComponentModel.ISupportInitialize) this.ImportProgress).BeginInit();
			// //((System.ComponentModel.ISupportInitialize) this.tbExport).BeginInit();
			// //((System.ComponentModel.ISupportInitialize) this.ExportProgress).BeginInit();
			// //((System.ComponentModel.ISupportInitialize) this.tbImport).BeginInit();
			// //((System.ComponentModel.ISupportInitialize) this.TabControlPage1).BeginInit();
			// //((System.ComponentModel.ISupportInitialize) this.tbTabControl).BeginInit();
			//this.tbTabControl.SuspendLayout();
			//this.tbExport.SuspendLayout();
			//this.frmImport2.SuspendLayout();
			//this.frmImport1.SuspendLayout();
			//this.tbImport.SuspendLayout();
			//this.Frame1.SuspendLayout();
			//this.Frame.SuspendLayout();
			this.SuspendLayout();
			// 
			// tbTabControl
			// 
			this.tbTabControl.AllowDrop = true;
			this.tbTabControl.Controls.Add(this.tbExport);
			this.tbTabControl.Controls.Add(this.tbImport);
			this.tbTabControl.Controls.Add(this.TabControlPage1);
			this.tbTabControl.Location = new System.Drawing.Point(-2, 0);
			this.tbTabControl.Name = "tbTabControl";
			//
			this.tbTabControl.Size = new System.Drawing.Size(443, 249);
			this.tbTabControl.TabIndex = 0;
			// 
			// tbExport
			// 
			this.tbExport.AllowDrop = true;
			this.tbExport.Controls.Add(this.frmImport2);
			this.tbExport.Controls.Add(this.cmdImport);
			this.tbExport.Controls.Add(this.frmImport1);
			this.tbExport.Location = new System.Drawing.Point(-4664, 26);
			this.tbExport.Name = "tbExport";
			//
			this.tbExport.Size = new System.Drawing.Size(439, 221);
			this.tbExport.TabIndex = 3;
			this.tbExport.Visible = false;
			// 
			// frmImport2
			// 
			this.frmImport2.AllowDrop = true;
			this.frmImport2.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.frmImport2.Controls.Add(this.chkPostTransactions);
			this.frmImport2.Controls.Add(this.txtImportPath);
			this.frmImport2.Controls.Add(this.Label2);
			this.frmImport2.Controls.Add(this.lblImportStatus);
			this.frmImport2.Controls.Add(this.ImportProgress);
			this.frmImport2.Enabled = true;
			this.frmImport2.ForeColor = System.Drawing.SystemColors.ControlText;
			this.frmImport2.Location = new System.Drawing.Point(16, 106);
			this.frmImport2.Name = "frmImport2";
			this.frmImport2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.frmImport2.Size = new System.Drawing.Size(407, 79);
			this.frmImport2.TabIndex = 27;
			this.frmImport2.Visible = true;
			// 
			// chkPostTransactions
			// 
			this.chkPostTransactions.AllowDrop = true;
			this.chkPostTransactions.Appearance = System.Windows.Forms.Appearance.Normal;
			this.chkPostTransactions.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.chkPostTransactions.CausesValidation = true;
			this.chkPostTransactions.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkPostTransactions.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this.chkPostTransactions.Enabled = true;
			this.chkPostTransactions.ForeColor = System.Drawing.SystemColors.ControlText;
			this.chkPostTransactions.Location = new System.Drawing.Point(78, 34);
			this.chkPostTransactions.Name = "chkPostTransactions";
			this.chkPostTransactions.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.chkPostTransactions.Size = new System.Drawing.Size(105, 17);
			this.chkPostTransactions.TabIndex = 28;
			this.chkPostTransactions.TabStop = true;
			this.chkPostTransactions.Text = "Post Transactions";
			this.chkPostTransactions.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkPostTransactions.Visible = false;
			// 
			// txtImportPath
			// 
			this.txtImportPath.AllowDrop = true;
			this.txtImportPath.BackColor = System.Drawing.Color.White;
			// // = false;
			this.txtImportPath.ForeColor = System.Drawing.Color.Black;
			this.txtImportPath.Location = new System.Drawing.Point(78, 12);
			// // = (System.Windows.Forms.TextBox.DropDownTypes) 0;
			this.txtImportPath.Name = "txtImportPath";
			// this.txtImportPath.ShowButton = true;
			this.txtImportPath.Size = new System.Drawing.Size(321, 19);
			this.txtImportPath.TabIndex = 29;
			this.txtImportPath.Text = "";
			// this.// = "";
			// this.//this.txtImportPath.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(//this.txtImportPath_DropButtonClick);
			// 
			// System.Windows.Forms.Label2
			// 
			this.Label2.AllowDrop = true;
			this.Label2.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.Label2.Text = "File Path";
			this.Label2.ForeColor = System.Drawing.SystemColors.WindowText;
			this.Label2.Location = new System.Drawing.Point(10, 14);
			this.Label2.Name="Label2";
			this.Label2.Size = new System.Drawing.Size(40, 14);
			this.Label2.TabIndex = 30;
			// 
			// lblImportStatus
			// 
			this.lblImportStatus.AllowDrop = true;
			this.lblImportStatus.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblImportStatus.ForeColor = System.Drawing.SystemColors.WindowText;
			this.lblImportStatus.Location = new System.Drawing.Point(10, 36);
			this.lblImportStatus.Name = "lblImportStatus";
			this.lblImportStatus.Size = new System.Drawing.Size(3, 14);
			this.lblImportStatus.TabIndex = 33;
			// 
			// ImportProgress
			// 
			this.ImportProgress.AllowDrop = true;
			this.ImportProgress.Location = new System.Drawing.Point(6, 54);
			this.ImportProgress.Name = "ImportProgress";
			//
			this.ImportProgress.Size = new System.Drawing.Size(397, 21);
			this.ImportProgress.TabIndex = 34;
			// 
			// cmdImport
			// 
			this.cmdImport.AllowDrop = true;
			this.cmdImport.BackColor = System.Drawing.SystemColors.Control;
			this.cmdImport.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdImport.Location = new System.Drawing.Point(340, 190);
			this.cmdImport.Name = "cmdImport";
			this.cmdImport.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdImport.Size = new System.Drawing.Size(82, 24);
			this.cmdImport.TabIndex = 26;
			this.cmdImport.Text = "Import Data";
			this.cmdImport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.cmdImport.UseVisualStyleBackColor = false;
			// this.cmdImport.Click += new System.EventHandler(this.cmdImport_Click);
			// 
			// frmImport1
			// 
			this.frmImport1.AllowDrop = true;
			this.frmImport1.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.frmImport1.Controls.Add(this.txtImportDisplayLocation);
			this.frmImport1.Controls.Add(this.Label_2);
			this.frmImport1.Controls.Add(this.lblImportLocation);
			this.frmImport1.Controls.Add(this.txtImportLocationCode);
			this.frmImport1.Controls.Add(this.txtImportFromDate);
			this.frmImport1.Controls.Add(this.Label_3);
			this.frmImport1.Controls.Add(this.txtImportToDate);
			this.frmImport1.Controls.Add(this.Label_4);
			this.frmImport1.Enabled = true;
			this.frmImport1.ForeColor = System.Drawing.SystemColors.ControlText;
			this.frmImport1.Location = new System.Drawing.Point(16, 14);
			this.frmImport1.Name = "frmImport1";
			this.frmImport1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.frmImport1.Size = new System.Drawing.Size(407, 89);
			this.frmImport1.TabIndex = 17;
			this.frmImport1.Visible = true;
			// 
			// txtImportDisplayLocation
			// 
			this.txtImportDisplayLocation.AllowDrop = true;
			this.txtImportDisplayLocation.BackColor = System.Drawing.Color.White;
			this.txtImportDisplayLocation.Enabled = false;
			this.txtImportDisplayLocation.Location = new System.Drawing.Point(172, 12);
			this.txtImportDisplayLocation.Name = "txtImportDisplayLocation";
			this.txtImportDisplayLocation.Size = new System.Drawing.Size(227, 19);
			this.txtImportDisplayLocation.TabIndex = 18;
			// 
			// Label_2
			// 
			this.Label_2.AllowDrop = true;
			this.Label_2.BackColor = System.Drawing.SystemColors.Window;
			// = VSReport8Lib.BackStyleSettings.vsrTransparent;
			this.Label_2.ForeColor = System.Drawing.SystemColors.WindowText;
			this.Label_2.Location = new System.Drawing.Point(12, 44);
			this.Label_2.Name = "Label_2";
			this.Label_2.Size = new System.Drawing.Size(3, 14);
			this.Label_2.TabIndex = 19;
			// 
			// lblImportLocation
			// 
			this.lblImportLocation.AllowDrop = true;
			this.lblImportLocation.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblImportLocation.Text = "From Location";
			this.lblImportLocation.ForeColor = System.Drawing.SystemColors.WindowText;
			this.lblImportLocation.Location = new System.Drawing.Point(10, 14);
			this.lblImportLocation.Name = "lblImportLocation";
			this.lblImportLocation.Size = new System.Drawing.Size(68, 14);
			this.lblImportLocation.TabIndex = 20;
			// 
			// txtImportLocationCode
			// 
			this.txtImportLocationCode.AllowDrop = true;
			this.txtImportLocationCode.BackColor = System.Drawing.Color.White;
			// // = false;
			this.txtImportLocationCode.ForeColor = System.Drawing.Color.Black;
			this.txtImportLocationCode.Location = new System.Drawing.Point(80, 12);
			// // = (System.Windows.Forms.TextBox.DropDownTypes) 0;
			this.txtImportLocationCode.Name = "txtImportLocationCode";
			// this.txtImportLocationCode.ShowButton = true;
			this.txtImportLocationCode.Size = new System.Drawing.Size(89, 19);
			this.txtImportLocationCode.TabIndex = 21;
			this.txtImportLocationCode.Text = "";
			// this.// = "";
			// this.//this.txtImportLocationCode.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(//this.txtImportLocationCode_DropButtonClick);
			// this.txtImportLocationCode.Leave += new System.EventHandler(this.txtImportLocationCode_Leave);
			// 
			// txtImportFromDate
			// 
			this.txtImportFromDate.AllowDrop = true;
			// this.txtImportFromDate.CheckDateRange = false;
			this.txtImportFromDate.Location = new System.Drawing.Point(80, 34);
			// this.txtImportFromDate.MaxDate = 2958465;
			// this.txtImportFromDate.MinDate = -657434;
			this.txtImportFromDate.Name = "txtImportFromDate";
			// = "_";
			this.txtImportFromDate.Size = new System.Drawing.Size(89, 19);
			this.txtImportFromDate.TabIndex = 22;
			// this.txtImportFromDate.Text = "31-Aug-2015";
			// 
			// Label_3
			// 
			this.Label_3.AllowDrop = true;
			this.Label_3.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.Label_3.Text = "From Date";
			this.Label_3.ForeColor = System.Drawing.SystemColors.WindowText;
			this.Label_3.Location = new System.Drawing.Point(10, 37);
			this.Label_3.Name = "Label_3";
			this.Label_3.Size = new System.Drawing.Size(49, 14);
			this.Label_3.TabIndex = 23;
			// 
			// txtImportToDate
			// 
			this.txtImportToDate.AllowDrop = true;
			// this.txtImportToDate.CheckDateRange = false;
			this.txtImportToDate.Location = new System.Drawing.Point(80, 56);
			// this.txtImportToDate.MaxDate = 2958465;
			// this.txtImportToDate.MinDate = -657434;
			this.txtImportToDate.Name = "txtImportToDate";
			// = "_";
			this.txtImportToDate.Size = new System.Drawing.Size(89, 19);
			this.txtImportToDate.TabIndex = 24;
			// this.txtImportToDate.Text = "31-Aug-2015";
			// 
			// Label_4
			// 
			this.Label_4.AllowDrop = true;
			this.Label_4.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.Label_4.Text = "To Date";
			this.Label_4.ForeColor = System.Drawing.SystemColors.WindowText;
			this.Label_4.Location = new System.Drawing.Point(10, 59);
			this.Label_4.Name = "Label_4";
			this.Label_4.Size = new System.Drawing.Size(37, 14);
			this.Label_4.TabIndex = 25;
			// 
			// tbImport
			// 
			this.tbImport.AllowDrop = true;
			this.tbImport.Controls.Add(this.cmdExport);
			this.tbImport.Controls.Add(this.Frame1);
			this.tbImport.Controls.Add(this.Frame);
			this.tbImport.Location = new System.Drawing.Point(2, 26);
			this.tbImport.Name = "tbImport";
			//
			this.tbImport.Size = new System.Drawing.Size(439, 221);
			this.tbImport.TabIndex = 2;
			// 
			// cmdExport
			// 
			this.cmdExport.AllowDrop = true;
			this.cmdExport.BackColor = System.Drawing.SystemColors.Control;
			this.cmdExport.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdExport.Location = new System.Drawing.Point(340, 190);
			this.cmdExport.Name = "cmdExport";
			this.cmdExport.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdExport.Size = new System.Drawing.Size(82, 24);
			this.cmdExport.TabIndex = 16;
			this.cmdExport.Text = "Export Data";
			this.cmdExport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.cmdExport.UseVisualStyleBackColor = false;
			// this.cmdExport.Click += new System.EventHandler(this.cmdExport_Click);
			// 
			// Frame1
			// 
			this.Frame1.AllowDrop = true;
			this.Frame1.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.Frame1.Controls.Add(this.txtExportPath);
			this.Frame1.Controls.Add(this.lblPath);
			this.Frame1.Controls.Add(this.lblExportStatus);
			this.Frame1.Controls.Add(this.ExportProgress);
			this.Frame1.Enabled = true;
			this.Frame1.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Frame1.Location = new System.Drawing.Point(16, 106);
			this.Frame1.Name = "Frame1";
			this.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Frame1.Size = new System.Drawing.Size(407, 79);
			this.Frame1.TabIndex = 13;
			this.Frame1.Visible = true;
			// 
			// txtExportPath
			// 
			this.txtExportPath.AllowDrop = true;
			this.txtExportPath.BackColor = System.Drawing.Color.White;
			// // = false;
			this.txtExportPath.ForeColor = System.Drawing.Color.Black;
			this.txtExportPath.Location = new System.Drawing.Point(78, 12);
			// // = (System.Windows.Forms.TextBox.DropDownTypes) 0;
			this.txtExportPath.Name = "txtExportPath";
			// this.txtExportPath.ShowButton = true;
			this.txtExportPath.Size = new System.Drawing.Size(319, 19);
			this.txtExportPath.TabIndex = 14;
			this.txtExportPath.Text = "";
			// this.// = "";
			// this.//this.txtExportPath.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(//this.txtExportPath_DropButtonClick);
			// 
			// lblPath
			// 
			this.lblPath.AllowDrop = true;
			this.lblPath.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblPath.Text = "File Path";
			this.lblPath.ForeColor = System.Drawing.SystemColors.WindowText;
			this.lblPath.Location = new System.Drawing.Point(10, 14);
			this.lblPath.Name = "lblPath";
			this.lblPath.Size = new System.Drawing.Size(40, 14);
			this.lblPath.TabIndex = 15;
			// 
			// lblExportStatus
			// 
			this.lblExportStatus.AllowDrop = true;
			this.lblExportStatus.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblExportStatus.ForeColor = System.Drawing.SystemColors.WindowText;
			this.lblExportStatus.Location = new System.Drawing.Point(8, 36);
			this.lblExportStatus.Name = "lblExportStatus";
			this.lblExportStatus.Size = new System.Drawing.Size(3, 14);
			this.lblExportStatus.TabIndex = 31;
			// 
			// ExportProgress
			// 
			this.ExportProgress.AllowDrop = true;
			this.ExportProgress.Location = new System.Drawing.Point(4, 54);
			this.ExportProgress.Name = "ExportProgress";
			//
			this.ExportProgress.Size = new System.Drawing.Size(397, 21);
			this.ExportProgress.TabIndex = 32;
			// 
			// Frame
			// 
			this.Frame.AllowDrop = true;
			this.Frame.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.Frame.Controls.Add(this.txtExportDisplayLocation);
			this.Frame.Controls.Add(this.Label_0);
			this.Frame.Controls.Add(this.lblExportLocation);
			this.Frame.Controls.Add(this.txtExportLocationCode);
			this.Frame.Controls.Add(this.txtExportFromDate);
			this.Frame.Controls.Add(this.Label_7);
			this.Frame.Controls.Add(this.txtExportToDate);
			this.Frame.Controls.Add(this.Label_1);
			this.Frame.Enabled = true;
			this.Frame.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Frame.Location = new System.Drawing.Point(16, 14);
			this.Frame.Name = "Frame";
			this.Frame.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Frame.Size = new System.Drawing.Size(407, 89);
			this.Frame.TabIndex = 4;
			this.Frame.Visible = true;
			// 
			// txtExportDisplayLocation
			// 
			this.txtExportDisplayLocation.AllowDrop = true;
			this.txtExportDisplayLocation.BackColor = System.Drawing.Color.White;
			this.txtExportDisplayLocation.Enabled = false;
			this.txtExportDisplayLocation.Location = new System.Drawing.Point(170, 12);
			this.txtExportDisplayLocation.Name = "txtExportDisplayLocation";
			this.txtExportDisplayLocation.Size = new System.Drawing.Size(227, 19);
			this.txtExportDisplayLocation.TabIndex = 5;
			// 
			// Label_0
			// 
			this.Label_0.AllowDrop = true;
			this.Label_0.BackColor = System.Drawing.SystemColors.Window;
			// = VSReport8Lib.BackStyleSettings.vsrTransparent;
			this.Label_0.ForeColor = System.Drawing.SystemColors.WindowText;
			this.Label_0.Location = new System.Drawing.Point(12, 44);
			this.Label_0.Name = "Label_0";
			this.Label_0.Size = new System.Drawing.Size(3, 14);
			this.Label_0.TabIndex = 6;
			// 
			// lblExportLocation
			// 
			this.lblExportLocation.AllowDrop = true;
			this.lblExportLocation.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblExportLocation.Text = "To Location";
			this.lblExportLocation.ForeColor = System.Drawing.SystemColors.WindowText;
			this.lblExportLocation.Location = new System.Drawing.Point(10, 14);
			this.lblExportLocation.Name = "lblExportLocation";
			this.lblExportLocation.Size = new System.Drawing.Size(56, 14);
			this.lblExportLocation.TabIndex = 7;
			// 
			// txtExportLocationCode
			// 
			this.txtExportLocationCode.AllowDrop = true;
			this.txtExportLocationCode.BackColor = System.Drawing.Color.White;
			// // = false;
			this.txtExportLocationCode.ForeColor = System.Drawing.Color.Black;
			this.txtExportLocationCode.Location = new System.Drawing.Point(80, 12);
			// // = (System.Windows.Forms.TextBox.DropDownTypes) 0;
			this.txtExportLocationCode.Name = "txtExportLocationCode";
			// this.txtExportLocationCode.ShowButton = true;
			this.txtExportLocationCode.Size = new System.Drawing.Size(89, 19);
			this.txtExportLocationCode.TabIndex = 8;
			this.txtExportLocationCode.Text = "";
			// this.// = "";
			// this.//this.txtExportLocationCode.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(//this.txtExportLocationCode_DropButtonClick);
			// this.txtExportLocationCode.Leave += new System.EventHandler(this.txtExportLocationCode_Leave);
			// 
			// txtExportFromDate
			// 
			this.txtExportFromDate.AllowDrop = true;
			// this.txtExportFromDate.CheckDateRange = false;
			this.txtExportFromDate.Location = new System.Drawing.Point(80, 34);
			// this.txtExportFromDate.MaxDate = 2958465;
			// this.txtExportFromDate.MinDate = -657434;
			this.txtExportFromDate.Name = "txtExportFromDate";
			// = "_";
			this.txtExportFromDate.Size = new System.Drawing.Size(89, 19);
			this.txtExportFromDate.TabIndex = 9;
			// this.txtExportFromDate.Text = "31-Aug-2015";
			// 
			// Label_7
			// 
			this.Label_7.AllowDrop = true;
			this.Label_7.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.Label_7.Text = "From Date";
			this.Label_7.ForeColor = System.Drawing.SystemColors.WindowText;
			this.Label_7.Location = new System.Drawing.Point(10, 37);
			this.Label_7.Name = "Label_7";
			this.Label_7.Size = new System.Drawing.Size(49, 14);
			this.Label_7.TabIndex = 10;
			// 
			// txtExportToDate
			// 
			this.txtExportToDate.AllowDrop = true;
			// this.txtExportToDate.CheckDateRange = false;
			this.txtExportToDate.Location = new System.Drawing.Point(80, 56);
			// this.txtExportToDate.MaxDate = 2958465;
			// this.txtExportToDate.MinDate = -657434;
			this.txtExportToDate.Name = "txtExportToDate";
			// = "_";
			this.txtExportToDate.Size = new System.Drawing.Size(89, 19);
			this.txtExportToDate.TabIndex = 11;
			// this.txtExportToDate.Text = "31-Aug-2015";
			// 
			// Label_1
			// 
			this.Label_1.AllowDrop = true;
			this.Label_1.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.Label_1.Text = "To Date";
			this.Label_1.ForeColor = System.Drawing.SystemColors.WindowText;
			this.Label_1.Location = new System.Drawing.Point(10, 59);
			this.Label_1.Name = "Label_1";
			this.Label_1.Size = new System.Drawing.Size(37, 14);
			this.Label_1.TabIndex = 12;
			// 
			// TabControlPage1
			// 
			this.TabControlPage1.AllowDrop = true;
			this.TabControlPage1.Location = new System.Drawing.Point(2, 26);
			this.TabControlPage1.Name = "TabControlPage1";
			//
			this.TabControlPage1.Size = new System.Drawing.Size(439, 221);
			this.TabControlPage1.TabIndex = 1;
			// 
			// frmSysSyncronize
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.ClientSize = new System.Drawing.Size(441, 248);
			this.Controls.Add(this.tbTabControl);
			this.Font = new System.Drawing.Font("Tahoma", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 178);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Location = new System.Drawing.Point(487, 371);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmSysSyncronize";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Syncronize Data";
			// this.Activated += new System.EventHandler(this.Form_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
			// this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
			//this.Resize += new System.EventHandler(this.Form_Resize);
			//((System.ComponentModel.ISupportInitialize) this.ImportProgress).EndInit();
			//((System.ComponentModel.ISupportInitialize) this.tbExport).EndInit();
			//((System.ComponentModel.ISupportInitialize) this.ExportProgress).EndInit();
			//((System.ComponentModel.ISupportInitialize) this.tbImport).EndInit();
			//((System.ComponentModel.ISupportInitialize) this.TabControlPage1).EndInit();
			//((System.ComponentModel.ISupportInitialize) this.tbTabControl).EndInit();
			this.tbTabControl.ResumeLayout(false);
			this.tbExport.ResumeLayout(false);
			this.frmImport2.ResumeLayout(false);
			this.frmImport1.ResumeLayout(false);
			this.tbImport.ResumeLayout(false);
			this.Frame1.ResumeLayout(false);
			this.Frame.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		// 
		void InitializeSystemWindowsFormsLabel()
		{
			this.Label = new System.Windows.Forms.Label[8];
			this.Label[2] = Label_2;
			this.Label[3] = Label_3;
			this.Label[4] = Label_4;
			this.Label[0] = Label_0;
			this.Label[7] = Label_7;
			this.Label[1] = Label_1;
		}
		#endregion
	}
}//ENDSHERE
