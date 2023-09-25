
namespace Xtreme
{
	partial class frmSysChangePassword
	{

		#region "Upgrade Support "
		private static frmSysChangePassword m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmSysChangePassword DefInstance
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
		public static frmSysChangePassword CreateInstance()
		{
			frmSysChangePassword theInstance = new frmSysChangePassword();
			
			return theInstance;
		}
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "txtConfirmPassword", "txtPassword", "lblConfirmPassword", "lblPassword", "System.Windows.Forms.Label1", "System.Windows.Forms.Label2", "txtOldPassword", "cmdOKCancel", "lblUserID"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public System.Windows.Forms.TextBox txtConfirmPassword;
		public System.Windows.Forms.TextBox txtPassword;
		public System.Windows.Forms.Label lblConfirmPassword;
		public System.Windows.Forms.Label lblPassword;
		public System.Windows.Forms.Label System.Windows.Forms.Label1;
		public System.Windows.Forms.Label System.Windows.Forms.Label2;
		public System.Windows.Forms.TextBox txtOldPassword;
		public UCOkCancel cmdOKCancel;
		public System.Windows.Forms.Label lblUserID;
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSysChangePassword));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this.txtConfirmPassword = new System.Windows.Forms.TextBox();
			this.txtPassword = new System.Windows.Forms.TextBox();
			this.lblConfirmPassword = new System.Windows.Forms.Label();
			this.lblPassword = new System.Windows.Forms.Label();
			this.System.Windows.Forms.Label1 = new System.Windows.Forms.Label();
			this.System.Windows.Forms.Label2 = new System.Windows.Forms.Label();
			this.txtOldPassword = new System.Windows.Forms.TextBox();
			this.cmdOKCancel = new UCOkCancel();
			this.lblUserID = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// txtConfirmPassword
			// 
			this.txtConfirmPassword.AllowDrop = true;
			this.txtConfirmPassword.BackColor = System.Drawing.Color.White;
			this.txtConfirmPassword.ForeColor = System.Drawing.Color.Black;
			this.txtConfirmPassword.Location = new System.Drawing.Point(156, 93);
			this.txtConfirmPassword.MaxLength = 50;
			this.txtConfirmPassword.Name = "txtConfirmPassword";
			// this.this.txtConfirmPassword.PasswordChar = "42";
			this.txtConfirmPassword.Size = new System.Drawing.Size(121, 19);
			this.txtConfirmPassword.TabIndex = 2;
			this.txtConfirmPassword.Text = "";
			// this.this.txtConfirmPassword.Watermark = "";
			// 
			// txtPassword
			// 
			this.txtPassword.AllowDrop = true;
			this.txtPassword.BackColor = System.Drawing.Color.White;
			this.txtPassword.ForeColor = System.Drawing.Color.Black;
			this.txtPassword.Location = new System.Drawing.Point(156, 72);
			this.txtPassword.MaxLength = 50;
			this.txtPassword.Name = "txtPassword";
			// this.this.txtPassword.PasswordChar = "42";
			this.txtPassword.Size = new System.Drawing.Size(121, 19);
			this.txtPassword.TabIndex = 1;
			this.txtPassword.Text = "";
			// this.this.txtPassword.Watermark = "";
			// 
			// lblConfirmPassword
			// 
			this.lblConfirmPassword.AllowDrop = true;
			this.lblConfirmPassword.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblConfirmPassword.Text = "Confirm New  Password";
			this.lblConfirmPassword.ForeColor = System.Drawing.Color.Black;
			this.lblConfirmPassword.Location = new System.Drawing.Point(12, 95);
			this.lblConfirmPassword.Name = "lblConfirmPassword";
			this.lblConfirmPassword.Size = new System.Drawing.Size(119, 14);
			this.lblConfirmPassword.TabIndex = 4;
			// 
			// lblPassword
			// 
			this.lblPassword.AllowDrop = true;
			this.lblPassword.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblPassword.Text = "New Password";
			this.lblPassword.ForeColor = System.Drawing.Color.Black;
			this.lblPassword.Location = new System.Drawing.Point(12, 74);
			this.lblPassword.Name = "lblPassword";
			this.lblPassword.Size = new System.Drawing.Size(76, 14);
			this.lblPassword.TabIndex = 5;
			// 
			// System.Windows.Forms.Label1
			// 
			this.System.Windows.Forms.Label1.AllowDrop = true;
			this.System.Windows.Forms.Label1.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.System.Windows.Forms.Label1.Caption = "User ID";
			this.System.Windows.Forms.Label1.ForeColor = System.Drawing.Color.Black;
			this.System.Windows.Forms.Label1.Location = new System.Drawing.Point(12, 26);
			this.System.Windows.Forms.Label1.Name = "System.Windows.Forms.Label1";
			this.System.Windows.Forms.Label1.Size = new System.Drawing.Size(35, 14);
			this.System.Windows.Forms.Label1.TabIndex = 6;
			// 
			// System.Windows.Forms.Label2
			// 
			this.System.Windows.Forms.Label2.AllowDrop = true;
			this.System.Windows.Forms.Label2.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.System.Windows.Forms.Label2.Caption = "Old Password";
			this.System.Windows.Forms.Label2.ForeColor = System.Drawing.Color.Black;
			this.System.Windows.Forms.Label2.Location = new System.Drawing.Point(12, 53);
			this.System.Windows.Forms.Label2.Name = "System.Windows.Forms.Label2";
			this.System.Windows.Forms.Label2.Size = new System.Drawing.Size(69, 14);
			this.System.Windows.Forms.Label2.TabIndex = 7;
			// 
			// txtOldPassword
			// 
			this.txtOldPassword.AllowDrop = true;
			this.txtOldPassword.BackColor = System.Drawing.Color.White;
			this.txtOldPassword.ForeColor = System.Drawing.Color.Black;
			this.txtOldPassword.Location = new System.Drawing.Point(156, 51);
			this.txtOldPassword.MaxLength = 50;
			this.txtOldPassword.Name = "txtOldPassword";
			// this.this.txtOldPassword.PasswordChar = "42";
			this.txtOldPassword.Size = new System.Drawing.Size(121, 19);
			this.txtOldPassword.TabIndex = 0;
			this.txtOldPassword.Text = "";
			// this.this.txtOldPassword.Watermark = "";
			// 
			// cmdOKCancel
			// 
			this.cmdOKCancel.AllowDrop = true;
			this.cmdOKCancel.DisplayButton = 0;
			this.cmdOKCancel.Location = new System.Drawing.Point(43, 128);
			this.cmdOKCancel.Name = "cmdOKCancel";
			this.cmdOKCancel.OkCaption = "C&hange";
			this.cmdOKCancel.Size = new System.Drawing.Size(206, 31);
			this.cmdOKCancel.TabIndex = 3;
			this.cmdOKCancel.CancelClick += new UCOkCancel.CancelClickHandler(this.cmdOKCancel_CancelClick);
			this.cmdOKCancel.OKClick += new UCOkCancel.OKClickHandler(this.cmdOKCancel_OKClick);
			// 
			// lblUserID
			// 
			this.lblUserID.AllowDrop = true;
			this.lblUserID.Location = new System.Drawing.Point(156, 24);
			this.lblUserID.Name = "lblUserID";
			this.lblUserID.Size = new System.Drawing.Size(121, 19);
			this.lblUserID.TabIndex = 8;
			// 
			// frmSysChangePassword
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.ClientSize = new System.Drawing.Size(298, 171);
			this.Controls.Add(this.txtConfirmPassword);
			this.Controls.Add(this.txtPassword);
			this.Controls.Add(this.lblConfirmPassword);
			this.Controls.Add(this.lblPassword);
			this.Controls.Add(this.System.Windows.Forms.Label1);
			this.Controls.Add(this.System.Windows.Forms.Label2);
			this.Controls.Add(this.txtOldPassword);
			this.Controls.Add(this.cmdOKCancel);
			this.Controls.Add(this.lblUserID);
			this.ForeColor = System.Drawing.Color.Silver;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(478, 258);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmSysChangePassword";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Change Password";
			// this.Activated += new System.EventHandler(this.frmSysChangePassword_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
			// this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
			this.ResumeLayout(false);
		}
		#endregion
	}
}