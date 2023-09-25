
namespace Xtreme
{
	partial class frmSysDatabaseBackup
	{

		#region "Upgrade Support "
		private static frmSysDatabaseBackup m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmSysDatabaseBackup DefInstance
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
		public static frmSysDatabaseBackup CreateInstance()
		{
			frmSysDatabaseBackup theInstance = new frmSysDatabaseBackup();
			
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
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "ExportProgress", "Frame4", "txtExportPath", "Frame1", "lstDatabase", "Frame2", "cmdOKCancel", "Frame3", "chkBackupSysDb", "System.Windows.Forms.Label1", "Dir1", "Drive1", "listBoxHelper1"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public AxXtremeSuiteControls.AxProgressBar ExportProgress;
		public System.Windows.Forms.GroupBox Frame4;
		public System.Windows.Forms.TextBox txtExportPath;
		public System.Windows.Forms.GroupBox Frame1;
		public System.Windows.Forms.CheckedListBox lstDatabase;
		public System.Windows.Forms.GroupBox Frame2;
		public UCOkCancel cmdOKCancel;
		public System.Windows.Forms.Panel Frame3;
		public System.Windows.Forms.CheckBox chkBackupSysDb;
		public System.Windows.Forms.LabelLabel1;
		public UpgradeHelpers.Gui.DirListBoxHelper Dir1;
		public UpgradeHelpers.Gui.DriveListBoxHelper Drive1;
		public UpgradeHelpers.Gui.ListBoxHelper listBoxHelper1;
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSysDatabaseBackup));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this.Frame3 = new System.Windows.Forms.Panel();
			this.Frame4 = new System.Windows.Forms.GroupBox();
			this.ExportProgress = new AxXtremeSuiteControls.AxProgressBar();
			this.Frame1 = new System.Windows.Forms.GroupBox();
			this.txtExportPath = new System.Windows.Forms.TextBox();
			this.Frame2 = new System.Windows.Forms.GroupBox();
			this.lstDatabase = new System.Windows.Forms.CheckedListBox();
			this.cmdOKCancel = new UCOkCancel();
			this.chkBackupSysDb = new System.Windows.Forms.CheckBox();
			this.Label1 = new System.Windows.Forms.Label();
			this.Dir1 = new UpgradeHelpers.Gui.DirListBoxHelper();
			this.Drive1 = new UpgradeHelpers.Gui.DriveListBoxHelper();
			// //((System.ComponentModel.ISupportInitialize) this.ExportProgress).BeginInit();
			this.Frame3.SuspendLayout();
			this.Frame4.SuspendLayout();
			this.Frame1.SuspendLayout();
			this.Frame2.SuspendLayout();
			this.SuspendLayout();
			this.listBoxHelper1 = new UpgradeHelpers.Gui.ListBoxHelper(this.components);
			// 
			// Frame3
			// 
			this.Frame3.AllowDrop = true;
			this.Frame3.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.Frame3.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Frame3.Controls.Add(this.Frame4);
			this.Frame3.Controls.Add(this.Frame1);
			this.Frame3.Controls.Add(this.Frame2);
			this.Frame3.Controls.Add(this.cmdOKCancel);
			this.Frame3.Enabled = true;
			this.Frame3.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Frame3.Location = new System.Drawing.Point(0, 2);
			this.Frame3.Name = "Frame3";
			this.Frame3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Frame3.Size = new System.Drawing.Size(359, 331);
			this.Frame3.TabIndex = 4;
			this.Frame3.Visible = true;
			// 
			// Frame4
			// 
			this.Frame4.AllowDrop = true;
			this.Frame4.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.Frame4.Controls.Add(this.ExportProgress);
			this.Frame4.Enabled = true;
			this.Frame4.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Frame4.Location = new System.Drawing.Point(6, 272);
			this.Frame4.Name = "Frame4";
			this.Frame4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Frame4.Size = new System.Drawing.Size(343, 49);
			this.Frame4.TabIndex = 10;
			this.Frame4.Text = "Status";
			this.Frame4.Visible = true;
			// 
			// ExportProgress
			// 
			this.ExportProgress.AllowDrop = true;
			this.ExportProgress.Location = new System.Drawing.Point(4, 16);
			this.ExportProgress.Name = "ExportProgress";
			("ExportProgress.OcxState");
			this.ExportProgress.Size = new System.Drawing.Size(335, 21);
			this.ExportProgress.TabIndex = 11;
			// 
			// Frame1
			// 
			this.Frame1.AllowDrop = true;
			this.Frame1.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.Frame1.Controls.Add(this.txtExportPath);
			this.Frame1.Enabled = true;
			this.Frame1.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Frame1.Location = new System.Drawing.Point(6, 186);
			this.Frame1.Name = "Frame1";
			this.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Frame1.Size = new System.Drawing.Size(343, 49);
			this.Frame1.TabIndex = 7;
			this.Frame1.Text = "File Path";
			this.Frame1.Visible = true;
			// 
			// txtExportPath
			// 
			this.txtExportPath.AllowDrop = true;
			this.txtExportPath.BackColor = System.Drawing.Color.White;
			this.txtExportPath.ForeColor = System.Drawing.Color.Black;
			this.txtExportPath.Location = new System.Drawing.Point(6, 20);
			this.txtExportPath.Name = "txtExportPath";
			// this.txtExportPath.ShowButton = true;
			this.txtExportPath.Size = new System.Drawing.Size(331, 19);
			this.txtExportPath.TabIndex = 8;
			this.txtExportPath.Text = "";
			// this.this.txtExportPath.Watermark = "";
			// this.this.txtExportPath.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtExportPath_DropButtonClick);
			// 
			// Frame2
			// 
			this.Frame2.AllowDrop = true;
			this.Frame2.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.Frame2.Controls.Add(this.lstDatabase);
			this.Frame2.Enabled = true;
			this.Frame2.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Frame2.Location = new System.Drawing.Point(8, 18);
			this.Frame2.Name = "Frame2";
			this.Frame2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Frame2.Size = new System.Drawing.Size(343, 163);
			this.Frame2.TabIndex = 5;
			this.Frame2.Text = "Select Company";
			this.Frame2.Visible = true;
			// 
			// lstDatabase
			// 
			this.lstDatabase.AllowDrop = true;
			this.lstDatabase.BackColor = System.Drawing.SystemColors.Window;
			this.lstDatabase.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lstDatabase.CausesValidation = true;
			this.lstDatabase.Enabled = true;
			this.lstDatabase.ForeColor = System.Drawing.SystemColors.WindowText;
			this.lstDatabase.IntegralHeight = true;
			this.lstDatabase.Location = new System.Drawing.Point(6, 18);
			this.lstDatabase.MultiColumn = false;
			this.lstDatabase.Name = "lstDatabase";
			this.lstDatabase.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lstDatabase.Size = new System.Drawing.Size(330, 139);
			this.lstDatabase.Sorted = false;
			this.lstDatabase.TabIndex = 6;
			this.lstDatabase.TabStop = true;
			this.lstDatabase.Visible = true;
			// 
			// cmdOKCancel
			// 
			this.cmdOKCancel.AllowDrop = true;
			this.cmdOKCancel.Location = new System.Drawing.Point(144, 242);
			this.cmdOKCancel.Name = "cmdOKCancel";
			this.cmdOKCancel.Size = new System.Drawing.Size(206, 31);
			this.cmdOKCancel.TabIndex = 9;
			this.cmdOKCancel.CancelClick += new UCOkCancel.CancelClickHandler(this.cmdOKCancel_CancelClick);
			this.cmdOKCancel.OKClick += new UCOkCancel.OKClickHandler(this.cmdOKCancel_OKClick);
			// 
			// chkBackupSysDb
			// 
			this.chkBackupSysDb.AllowDrop = true;
			this.chkBackupSysDb.Appearance = System.Windows.Forms.Appearance.Normal;
			this.chkBackupSysDb.BackColor = System.Drawing.Color.FromArgb(239, 221, 211);
			this.chkBackupSysDb.CausesValidation = true;
			this.chkBackupSysDb.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkBackupSysDb.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this.chkBackupSysDb.Enabled = true;
			this.chkBackupSysDb.ForeColor = System.Drawing.SystemColors.ControlText;
			this.chkBackupSysDb.Location = new System.Drawing.Point(152, 418);
			this.chkBackupSysDb.Name = "chkBackupSysDb";
			this.chkBackupSysDb.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.chkBackupSysDb.Size = new System.Drawing.Size(200, 17);
			this.chkBackupSysDb.TabIndex = 0;
			this.chkBackupSysDb.TabStop = true;
			this.chkBackupSysDb.Text = "With System Control Database";
			this.chkBackupSysDb.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkBackupSysDb.Visible = false;
			// 
			// System.Windows.Forms.Label1
			// 
			this.Label1.AllowDrop = true;
			this.Label1.Location = new System.Drawing.Point(6, 396);
			this.Label1.Name = "System.Windows.Forms.Label1";
			this.Label1.Size = new System.Drawing.Size(167, 16);
			this.Label1.TabIndex = 3;
			this.Label1.Visible = false;
			// 
			// Dir1
			// 
			this.Dir1.AllowDrop = true;
			this.Dir1.BackColor = System.Drawing.SystemColors.Window;
			this.Dir1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.Dir1.CausesValidation = true;
			this.Dir1.Enabled = true;
			this.Dir1.ForeColor = System.Drawing.SystemColors.WindowText;
			this.Dir1.Location = new System.Drawing.Point(10, 398);
			this.Dir1.Name = "Dir1";
			this.Dir1.Size = new System.Drawing.Size(305, 231);
			this.Dir1.TabIndex = 2;
			this.Dir1.TabStop = true;
			this.Dir1.Visible = false;
			// 
			// Drive1
			// 
			this.Drive1.AllowDrop = true;
			this.Drive1.BackColor = System.Drawing.SystemColors.Window;
			this.Drive1.CausesValidation = true;
			this.Drive1.Enabled = true;
			this.Drive1.ForeColor = System.Drawing.SystemColors.WindowText;
			this.Drive1.Location = new System.Drawing.Point(12, 368);
			this.Drive1.Name = "Drive1";
			this.Drive1.Size = new System.Drawing.Size(305, 21);
			this.Drive1.TabIndex = 1;
			this.Drive1.TabStop = true;
			this.Drive1.Visible = false;
			this.Drive1.SelectedIndexChanged += new System.EventHandler(this.Drive1_SelectedIndexChanged);
			// 
			// frmSysDatabaseBackup
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.ClientSize = new System.Drawing.Size(355, 330);
			this.Controls.Add(this.Frame3);
			this.Controls.Add(this.chkBackupSysDb);
			this.Controls.Add(this.Label1);
			this.Controls.Add(this.Dir1);
			this.Controls.Add(this.Drive1);
			//this.Icon = (System.Drawing.Icon) resources.GetObject("frmSysDatabaseBackup.Icon");
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(215, 193);
			this.MaximizeBox = true;
			this.MinimizeBox = true;
			this.Name = "frmSysDatabaseBackup";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Database Backup";
			this.listBoxHelper1.SetSelectionMode(this.lstDatabase, System.Windows.Forms.SelectionMode.One);
			// this.Activated += new System.EventHandler(this.frmSysDatabaseBackup_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
			// this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
			//((System.ComponentModel.ISupportInitialize) this.ExportProgress).EndInit();
			this.Frame3.ResumeLayout(false);
			this.Frame4.ResumeLayout(false);
			this.Frame1.ResumeLayout(false);
			this.Frame2.ResumeLayout(false);
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
}//ENDSHERE
