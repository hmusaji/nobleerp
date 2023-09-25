
namespace Xtreme
{
	partial class frmSysDatabaseRestore
	{

		#region "Upgrade Support "
		private static frmSysDatabaseRestore m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmSysDatabaseRestore DefInstance
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
		public static frmSysDatabaseRestore CreateInstance()
		{
			frmSysDatabaseRestore theInstance = new frmSysDatabaseRestore();
			
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
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "System.Windows.Forms.Label2", "txtRestoreDBName", "System.Windows.Forms.Label1", "cmdCancel", "cmdOK", "Dir1", "File1", "Drive1"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public System.Windows.Forms.Label Label2;
		public System.Windows.Forms.TextBox txtRestoreDBName;
		public System.Windows.Forms.Label Label1;
		public System.Windows.Forms.Button cmdCancel;
		public System.Windows.Forms.Button cmdOK;
		public UpgradeHelpers.Gui.DirListBoxHelper Dir1;
		public UpgradeHelpers.Gui.FileListBoxHelper File1;
		public UpgradeHelpers.Gui.DriveListBoxHelper Drive1;
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSysDatabaseRestore));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this.Label2 = new System.Windows.Forms.Label();
			this.txtRestoreDBName = new System.Windows.Forms.TextBox();
			this.Label1 = new System.Windows.Forms.Label();
			this.cmdCancel = new System.Windows.Forms.Button();
			this.cmdOK = new System.Windows.Forms.Button();
			this.Dir1 = new UpgradeHelpers.Gui.DirListBoxHelper();
			this.File1 = new UpgradeHelpers.Gui.FileListBoxHelper();
			this.Drive1 = new UpgradeHelpers.Gui.DriveListBoxHelper();
			this.SuspendLayout();
			// 
			// System.Windows.Forms.Label2
			// 
			this.Label2.AllowDrop = true;
			this.Label2.BackColor = System.Drawing.SystemColors.Window;
			this.Label2.Text = "Restore Database Name";
			this.Label2.ForeColor = System.Drawing.Color.Black;
			this.Label2.Location = new System.Drawing.Point(20, 282);
			this.Label2.Name="Label2";
			this.Label2.Size = new System.Drawing.Size(117, 13);
			this.Label2.TabIndex = 7;
			// 
			// txtRestoreDBName
			// 
			this.txtRestoreDBName.AllowDrop = true;
			this.txtRestoreDBName.BackColor = System.Drawing.Color.White;
			// // = false;
			this.txtRestoreDBName.ForeColor = System.Drawing.Color.Black;
			this.txtRestoreDBName.Location = new System.Drawing.Point(144, 278);
			// // = (System.Windows.Forms.TextBox.DropDownTypes) 0;
			this.txtRestoreDBName.Name = "txtRestoreDBName";
			this.txtRestoreDBName.Size = new System.Drawing.Size(105, 21);
			this.txtRestoreDBName.TabIndex = 6;
			this.txtRestoreDBName.Text = "";
			// 
			// System.Windows.Forms.Label1
			// 
			this.Label1.AllowDrop = true;
			this.Label1.BackColor = System.Drawing.SystemColors.Window;
			this.Label1.Text = "Select the file to Restore:";
			this.Label1.Location = new System.Drawing.Point(16, 22);
			this.Label1.Name="Label1";
			this.Label1.Size = new System.Drawing.Size(119, 13);
			this.Label1.TabIndex = 5;
			// 
			// cmdCancel
			// 
			this.cmdCancel.AllowDrop = true;
			this.cmdCancel.BackColor = System.Drawing.SystemColors.Control;
			this.cmdCancel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdCancel.Location = new System.Drawing.Point(283, 340);
			this.cmdCancel.Name = "cmdCancel";
			this.cmdCancel.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdCancel.Size = new System.Drawing.Size(113, 27);
			this.cmdCancel.TabIndex = 4;
			this.cmdCancel.Text = "&Cancel";
			this.cmdCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.cmdCancel.UseVisualStyleBackColor = false;
			// this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
			// 
			// cmdOK
			// 
			this.cmdOK.AllowDrop = true;
			this.cmdOK.BackColor = System.Drawing.SystemColors.Control;
			this.cmdOK.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdOK.Location = new System.Drawing.Point(170, 340);
			this.cmdOK.Name = "cmdOK";
			this.cmdOK.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdOK.Size = new System.Drawing.Size(113, 27);
			this.cmdOK.TabIndex = 3;
			this.cmdOK.Text = "&OK";
			this.cmdOK.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.cmdOK.UseVisualStyleBackColor = false;
			// this.cmdOK.Click += new System.EventHandler(this.cmdOk_Click);
			// 
			// Dir1
			// 
			this.Dir1.AllowDrop = true;
			this.Dir1.BackColor = System.Drawing.SystemColors.Window;
			this.Dir1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.Dir1.CausesValidation = true;
			this.Dir1.Enabled = true;
			this.Dir1.ForeColor = System.Drawing.SystemColors.WindowText;
			this.Dir1.Location = new System.Drawing.Point(16, 64);
			this.Dir1.Name = "Dir1";
			this.Dir1.Size = new System.Drawing.Size(257, 201);
			this.Dir1.TabIndex = 2;
			this.Dir1.TabStop = true;
			this.Dir1.Visible = true;
			this.Dir1.PathChange += new System.EventHandler(this.Dir1_PathChange);
			// 
			// File1
			// 
			this.File1.@System = false;
			this.File1.AllowDrop = true;
			this.File1.Archive = true;
			this.File1.BackColor = System.Drawing.SystemColors.Window;
			this.File1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.File1.CausesValidation = true;
			this.File1.Enabled = true;
			this.File1.ForeColor = System.Drawing.SystemColors.WindowText;
			this.File1.Hidden = false;
			this.File1.Location = new System.Drawing.Point(273, 62);
			this.File1.Name = "File1";
			this.File1.Normal = true;
			this.File1.Pattern = "*.*";
			this.File1.ReadOnly = true;
			this.File1.SelectionMode = System.Windows.Forms.SelectionMode.One;
			this.File1.Size = new System.Drawing.Size(257, 201);
			this.File1.TabIndex = 1;
			this.File1.TabStop = true;
			this.File1.TopIndex = 0;
			this.File1.Visible = true;
			this.File1.SelectedIndexChanged += new System.EventHandler(this.File1_SelectedIndexChanged);
			// 
			// Drive1
			// 
			this.Drive1.AllowDrop = true;
			this.Drive1.BackColor = System.Drawing.SystemColors.Window;
			this.Drive1.CausesValidation = true;
			this.Drive1.Enabled = true;
			this.Drive1.ForeColor = System.Drawing.SystemColors.WindowText;
			this.Drive1.Location = new System.Drawing.Point(16, 42);
			this.Drive1.Name = "Drive1";
			this.Drive1.Size = new System.Drawing.Size(257, 21);
			this.Drive1.TabIndex = 0;
			this.Drive1.TabStop = true;
			this.Drive1.Visible = true;
			this.Drive1.SelectedIndexChanged += new System.EventHandler(this.Drive1_SelectedIndexChanged);
			// 
			// frmSysDatabaseRestore
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.FromArgb(239, 221, 211);
			this.CancelButton = this.cmdCancel;
			this.ClientSize = new System.Drawing.Size(551, 375);
			this.Controls.Add(this.Label2);
			this.Controls.Add(this.txtRestoreDBName);
			this.Controls.Add(this.Label1);
			this.Controls.Add(this.cmdCancel);
			this.Controls.Add(this.cmdOK);
			this.Controls.Add(this.Dir1);
			this.Controls.Add(this.File1);
			this.Controls.Add(this.Drive1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			//this.Icon = (System.Drawing.Icon) resources.GetObject("frmSysDatabaseRestore.Icon");
			this.Location = new System.Drawing.Point(164, 130);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmSysDatabaseRestore";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Restore Database";
			// this.Activated += new System.EventHandler(this.frmSysDatabaseRestore_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
			this.ResumeLayout(false);
		}
		// 
		#endregion
	}
}//ENDSHERE
