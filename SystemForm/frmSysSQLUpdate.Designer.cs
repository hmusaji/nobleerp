
namespace Xtreme
{
	partial class frmSysSQLUpdate
	{

		#region "Upgrade Support "
		private static frmSysSQLUpdate m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmSysSQLUpdate DefInstance
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
		public static frmSysSQLUpdate CreateInstance()
		{
			frmSysSQLUpdate theInstance = new frmSysSQLUpdate();
			
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
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "cmdExecuteSQL", "cmdLoadSQL", "txtSQLCommand", "CommonDialog1Open", "CommonDialog1", "cmbDatabase", "Label2", "Label1", "Line1"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public System.Windows.Forms.Button cmdExecuteSQL;
		public System.Windows.Forms.Button cmdLoadSQL;
		public System.Windows.Forms.TextBox txtSQLCommand;
		public System.Windows.Forms.OpenFileDialog CommonDialog1Open;
		public UpgradeStubs.AxMSComDlg_AxCommonDialog CommonDialog1;
		public System.Windows.Forms.ComboBox cmbDatabase;
		public System.Windows.Forms.Label Label2;
		public System.Windows.Forms.Label Label1;
		public System.Windows.Forms.Label Line1;
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSysSQLUpdate));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this.cmdExecuteSQL = new System.Windows.Forms.Button();
			this.cmdLoadSQL = new System.Windows.Forms.Button();
			this.txtSQLCommand = new System.Windows.Forms.TextBox();
			this.CommonDialog1Open = new System.Windows.Forms.OpenFileDialog();
			this.CommonDialog1 = new UpgradeStubs.AxMSComDlg_AxCommonDialog();
			this.cmbDatabase = new System.Windows.Forms.ComboBox();
			this.Label2 = new System.Windows.Forms.Label();
			this.Label1 = new System.Windows.Forms.Label();
			this.Line1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// cmdExecuteSQL
			// 
			this.cmdExecuteSQL.AllowDrop = true;
			this.cmdExecuteSQL.BackColor = System.Drawing.SystemColors.Control;
			this.cmdExecuteSQL.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdExecuteSQL.Location = new System.Drawing.Point(634, 392);
			this.cmdExecuteSQL.Name = "cmdExecuteSQL";
			this.cmdExecuteSQL.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdExecuteSQL.Size = new System.Drawing.Size(78, 27);
			this.cmdExecuteSQL.TabIndex = 2;
			this.cmdExecuteSQL.Text = "&Execute SQL";
			this.cmdExecuteSQL.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.cmdExecuteSQL.UseVisualStyleBackColor = false;
			// this.cmdExecuteSQL.Click += new System.EventHandler(this.cmdExecuteSQL_Click);
			// 
			// cmdLoadSQL
			// 
			this.cmdLoadSQL.AllowDrop = true;
			this.cmdLoadSQL.BackColor = System.Drawing.SystemColors.Control;
			this.cmdLoadSQL.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdLoadSQL.Location = new System.Drawing.Point(542, 392);
			this.cmdLoadSQL.Name = "cmdLoadSQL";
			this.cmdLoadSQL.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdLoadSQL.Size = new System.Drawing.Size(88, 27);
			this.cmdLoadSQL.TabIndex = 1;
			this.cmdLoadSQL.Text = "L&oad SQL";
			this.cmdLoadSQL.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.cmdLoadSQL.UseVisualStyleBackColor = false;
			// this.cmdLoadSQL.Click += new System.EventHandler(this.cmdLoadSQL_Click);
			// 
			// txtSQLCommand
			// 
			this.txtSQLCommand.AcceptsReturn = true;
			this.txtSQLCommand.AllowDrop = true;
			this.txtSQLCommand.BackColor = System.Drawing.SystemColors.Window;
			this.txtSQLCommand.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.txtSQLCommand.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtSQLCommand.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 178);
			this.txtSQLCommand.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtSQLCommand.Location = new System.Drawing.Point(1, 44);
			this.txtSQLCommand.MaxLength = 0;
			this.txtSQLCommand.Multiline = true;
			this.txtSQLCommand.Name = "txtSQLCommand";
			this.txtSQLCommand.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtSQLCommand.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.txtSQLCommand.Size = new System.Drawing.Size(736, 337);
			this.txtSQLCommand.TabIndex = 0;
			this.txtSQLCommand.WordWrap = false;
			// 
			// cmbDatabase
			// 
			this.cmbDatabase.AllowDrop = true;
			this.cmbDatabase.Location = new System.Drawing.Point(571, 11);
			this.cmbDatabase.Name = "cmbDatabase";
			this.cmbDatabase.Size = new System.Drawing.Size(166, 21);
			this.cmbDatabase.TabIndex = 5;
			// 
			// Label2
			// 
			this.Label2.AllowDrop = true;
			this.Label2.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.Label2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Label2.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 178);
			this.Label2.ForeColor = System.Drawing.SystemColors.WindowText;
			this.Label2.Location = new System.Drawing.Point(500, 14);
			this.Label2.Name = "Label2";
			this.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label2.Size = new System.Drawing.Size(66, 18);
			this.Label2.TabIndex = 4;
			this.Label2.Text = "Database :";
			// 
			// Label1
			// 
			this.Label1.AllowDrop = true;
			this.Label1.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.Label1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Label1.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 178);
			this.Label1.ForeColor = System.Drawing.SystemColors.WindowText;
			this.Label1.Location = new System.Drawing.Point(4, 22);
			this.Label1.Name = "Label1";
			this.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label1.Size = new System.Drawing.Size(112, 16);
			this.Label1.TabIndex = 3;
			this.Label1.Text = "SQL Query ";
			// 
			// Line1
			// 
			this.Line1.AllowDrop = true;
			this.Line1.BackColor = System.Drawing.SystemColors.WindowText;
			this.Line1.Enabled = false;
			this.Line1.Location = new System.Drawing.Point(1, 41);
			this.Line1.Name = "Line1";
			this.Line1.Size = new System.Drawing.Size(737, 1);
			this.Line1.Visible = true;
			// 
			// frmSysSQLUpdate
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.ClientSize = new System.Drawing.Size(741, 425);
			this.Controls.Add(this.cmdExecuteSQL);
			this.Controls.Add(this.cmdLoadSQL);
			this.Controls.Add(this.txtSQLCommand);
			this.Controls.Add(this.cmbDatabase);
			this.Controls.Add(this.Label2);
			this.Controls.Add(this.Label1);
			this.Controls.Add(this.Line1);
			//this.Icon = (System.Drawing.Icon) resources.GetObject("frmSysSQLUpdate.Icon");
			this.Location = new System.Drawing.Point(136, 194);
			this.MaximizeBox = true;
			this.MinimizeBox = true;
			this.Name = "frmSysSQLUpdate";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "SQL Update";
			// this.Activated += new System.EventHandler(this.frmSysSQLUpdate_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
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