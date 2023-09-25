
namespace Xtreme
{
	partial class frmPayEmployeeSocialSecurity
	{

		#region "Upgrade Support "
		private static frmPayEmployeeSocialSecurity m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmPayEmployeeSocialSecurity DefInstance
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
		public static frmPayEmployeeSocialSecurity CreateInstance()
		{
			frmPayEmployeeSocialSecurity theInstance = new frmPayEmployeeSocialSecurity();
			
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
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "chkIsGenerate", "chkIsCompShare", "txtComments", "txtNTotalSalary", "_lblCommonLabel_2", "txtEmpCode", "txtDEmpName", "_lblCommonLabel_0", "_lblCommonLabel_1", "txtNAdditionSalary", "System.Windows.Forms.Label4", "System.Windows.Forms.Label5", "System.Windows.Forms.Label12", "lblCommonLabel"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public System.Windows.Forms.CheckBox chkIsGenerate;
		public System.Windows.Forms.CheckBox chkIsCompShare;
		public System.Windows.Forms.TextBox txtComments;
		public System.Windows.Forms.TextBox txtNTotalSalary;
		private System.Windows.Forms.Label _lblCommonLabel_2;
		public System.Windows.Forms.TextBox txtEmpCode;
		public System.Windows.Forms.Label txtDEmpName;
		private System.Windows.Forms.Label _lblCommonLabel_0;
		private System.Windows.Forms.Label _lblCommonLabel_1;
		public System.Windows.Forms.TextBox txtNAdditionSalary;
		public System.Windows.Forms.Label Label4;
		public System.Windows.Forms.Label Label5;
		public System.Windows.Forms.Label Label12;
		public System.Windows.Forms.Label[] lblCommonLabel = new System.Windows.Forms.Label[3];
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPayEmployeeSocialSecurity));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this.chkIsGenerate = new System.Windows.Forms.CheckBox();
			this.chkIsCompShare = new System.Windows.Forms.CheckBox();
			this.txtComments = new System.Windows.Forms.TextBox();
			this.txtNTotalSalary = new System.Windows.Forms.TextBox();
			this._lblCommonLabel_2 = new System.Windows.Forms.Label();
			this.txtEmpCode = new System.Windows.Forms.TextBox();
			this.txtDEmpName = new System.Windows.Forms.Label();
			this._lblCommonLabel_0 = new System.Windows.Forms.Label();
			this._lblCommonLabel_1 = new System.Windows.Forms.Label();
			this.txtNAdditionSalary = new System.Windows.Forms.TextBox();
			this.Label4 = new System.Windows.Forms.Label();
			this.Label5 = new System.Windows.Forms.Label();
			this.Label12 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// chkIsGenerate
			// 
			this.chkIsGenerate.AllowDrop = true;
			this.chkIsGenerate.Appearance = System.Windows.Forms.Appearance.Normal;
			this.chkIsGenerate.BackColor = System.Drawing.SystemColors.Control;
			this.chkIsGenerate.CausesValidation = true;
			this.chkIsGenerate.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkIsGenerate.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this.chkIsGenerate.Enabled = true;
			this.chkIsGenerate.ForeColor = System.Drawing.SystemColors.ControlText;
			this.chkIsGenerate.Location = new System.Drawing.Point(114, 153);
			this.chkIsGenerate.Name = "chkIsGenerate";
			this.chkIsGenerate.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.chkIsGenerate.Size = new System.Drawing.Size(13, 16);
			this.chkIsGenerate.TabIndex = 5;
			this.chkIsGenerate.TabStop = true;
			// this.chkIsGenerate.Text = "";
			// this.chkIsGenerate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkIsGenerate.Visible = true;
			// 
			// chkIsCompShare
			// 
			this.chkIsCompShare.AllowDrop = true;
			this.chkIsCompShare.Appearance = System.Windows.Forms.Appearance.Normal;
			this.chkIsCompShare.BackColor = System.Drawing.SystemColors.Control;
			this.chkIsCompShare.CausesValidation = true;
			this.chkIsCompShare.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkIsCompShare.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this.chkIsCompShare.Enabled = true;
			this.chkIsCompShare.ForeColor = System.Drawing.SystemColors.ControlText;
			this.chkIsCompShare.Location = new System.Drawing.Point(114, 132);
			this.chkIsCompShare.Name = "chkIsCompShare";
			this.chkIsCompShare.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.chkIsCompShare.Size = new System.Drawing.Size(13, 16);
			this.chkIsCompShare.TabIndex = 4;
			this.chkIsCompShare.TabStop = true;
			this.chkIsCompShare.Text = "";
			this.chkIsCompShare.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkIsCompShare.Visible = true;
			// 
			// txtComments
			// 
			this.txtComments.AcceptsReturn = true;
			this.txtComments.AllowDrop = true;
			this.txtComments.BackColor = System.Drawing.SystemColors.Window;
			this.txtComments.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.txtComments.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtComments.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtComments.Location = new System.Drawing.Point(114, 177);
			this.txtComments.MaxLength = 0;
			this.txtComments.Multiline = true;
			this.txtComments.Name = "txtComments";
			this.txtComments.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtComments.Size = new System.Drawing.Size(322, 70);
			this.txtComments.TabIndex = 6;
			// 
			// txtNTotalSalary
			// 
			this.txtNTotalSalary.AllowDrop = true;
			this.txtNTotalSalary.Location = new System.Drawing.Point(114, 84);
			this.txtNTotalSalary.Name = "txtNTotalSalary";
			this.txtNTotalSalary.Size = new System.Drawing.Size(100, 19);
			this.txtNTotalSalary.TabIndex = 2;
			// 
			// _lblCommonLabel_2
			// 
			this._lblCommonLabel_2.AllowDrop = true;
			this._lblCommonLabel_2.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_2.Location = new System.Drawing.Point(6, 62);
			this._lblCommonLabel_2.Name = "_lblCommonLabel_2";
			this._lblCommonLabel_2.Size = new System.Drawing.Size(74, 14);
			this._lblCommonLabel_2.TabIndex = 0;
			// 
			// txtEmpCode
			// 
			this.txtEmpCode.AllowDrop = true;
			this.txtEmpCode.BackColor = System.Drawing.Color.White;
			this.txtEmpCode.ForeColor = System.Drawing.Color.Black;
			this.txtEmpCode.Location = new System.Drawing.Point(115, 60);
			this.txtEmpCode.Name = "txtEmpCode";
			this.txtEmpCode.Size = new System.Drawing.Size(101, 19);
			this.txtEmpCode.TabIndex = 1;
			this.txtEmpCode.Text = "";
			// this.//this.txtEmpCode.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(//this.txtEmpCode_DropButtonClick);
			// this.txtEmpCode.Leave += new System.EventHandler(this.txtEmpCode_Leave);
			// 
			// txtDEmpName
			// 
			this.txtDEmpName.AllowDrop = true;
			this.txtDEmpName.Location = new System.Drawing.Point(203, 60);
			this.txtDEmpName.Name = "txtDEmpName";
			this.txtDEmpName.Size = new System.Drawing.Size(234, 19);
			this.txtDEmpName.TabIndex = 7;
			// 
			// _lblCommonLabel_0
			// 
			this._lblCommonLabel_0.AllowDrop = true;
			this._lblCommonLabel_0.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_0.Location = new System.Drawing.Point(6, 86);
			this._lblCommonLabel_0.Name = "_lblCommonLabel_0";
			this._lblCommonLabel_0.Size = new System.Drawing.Size(80, 14);
			this._lblCommonLabel_0.TabIndex = 8;
			// 
			// _lblCommonLabel_1
			// 
			this._lblCommonLabel_1.AllowDrop = true;
			this._lblCommonLabel_1.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_1.Location = new System.Drawing.Point(6, 110);
			this._lblCommonLabel_1.Name = "_lblCommonLabel_1";
			this._lblCommonLabel_1.Size = new System.Drawing.Size(81, 14);
			this._lblCommonLabel_1.TabIndex = 9;
			// 
			// txtNAdditionSalary
			// 
			this.txtNAdditionSalary.AllowDrop = true;
			this.txtNAdditionSalary.Location = new System.Drawing.Point(114, 108);
			this.txtNAdditionSalary.Name = "txtNAdditionSalary";
			this.txtNAdditionSalary.Size = new System.Drawing.Size(100, 19);
			this.txtNAdditionSalary.TabIndex = 3;
			// 
			// System.Windows.Forms.Label4
			// 
			this.Label4.AllowDrop = true;
			this.Label4.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.Label4.Location = new System.Drawing.Point(6, 134);
			this.Label4.Name="Label4";
			this.Label4.Size = new System.Drawing.Size(91, 14);
			this.Label4.TabIndex = 10;
			// 
			// System.Windows.Forms.Label5
			// 
			this.Label5.AllowDrop = true;
			this.Label5.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.Label5.Location = new System.Drawing.Point(6, 155);
			this.Label5.Name="Label5";
			this.Label5.Size = new System.Drawing.Size(58, 14);
			this.Label5.TabIndex = 11;
			// 
			// System.Windows.Forms.Label12
			// 
			this.Label12.AllowDrop = true;
			this.Label12.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.Label12.Location = new System.Drawing.Point(6, 179);
			this.Label12.Name="Label12";
			this.Label12.Size = new System.Drawing.Size(50, 14);
			this.Label12.TabIndex = 12;
			// 
			// frmPayEmployeeSocialSecurity
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.ClientSize = new System.Drawing.Size(450, 256);
			this.Controls.Add(this.chkIsGenerate);
			this.Controls.Add(this.chkIsCompShare);
			this.Controls.Add(this.txtComments);
			this.Controls.Add(this.txtNTotalSalary);
			this.Controls.Add(this._lblCommonLabel_2);
			this.Controls.Add(this.txtEmpCode);
			this.Controls.Add(this.txtDEmpName);
			this.Controls.Add(this._lblCommonLabel_0);
			this.Controls.Add(this._lblCommonLabel_1);
			this.Controls.Add(this.txtNAdditionSalary);
			this.Controls.Add(this.Label4);
			this.Controls.Add(this.Label5);
			this.Controls.Add(this.Label12);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			//this.Icon = (System.Drawing.Icon) resources.GetObject("frmPayEmployeeSocialSecurity.Icon");
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(214, 197);
			this.MaximizeBox = true;
			this.MinimizeBox = true;
			this.Name = "frmPayEmployeeSocialSecurity";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Employee Social Security";
			// this.Activated += new System.EventHandler(this.frmPayEmployeeSocialSecurity_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
			// this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
			this.ResumeLayout(false);
		}
		// 
		void InitializelblCommonLabel()
		{
			this.lblCommonLabel = new System.Windows.Forms.Label[3];
			this.lblCommonLabel[2] = _lblCommonLabel_2;
			this.lblCommonLabel[0] = _lblCommonLabel_0;
			this.lblCommonLabel[1] = _lblCommonLabel_1;
		}
		#endregion
	}
}//ENDSHERE
