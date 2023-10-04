
namespace Xtreme
{
	partial class frmSysLogin
	{

	
		#region "Windows Form Designer generated code "
		public static frmSysLogin CreateInstance()
		{
			frmSysLogin theInstance = new frmSysLogin();
			return theInstance;
		}
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "btnLogin", "chkSaveUser", "chkSavePassword", "cmdVerify", "txtPassword", "txtUserID", "txtLocationNo", "txtLocationName", "_cmbLanguage_0", "btnExit", "cmbCompany", "Image2", "Image3", "Label2", "Label1", "lblLanguage", "lblCompanyCode", "lblLocationCode", "lblPassword", "lblUserID", "Image1", "ImageManager", "mnuSystemMenu", "cmbLanguage", "commandButtonHelper1"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public System.Windows.Forms.Button btnLogin;
		public System.Windows.Forms.CheckBox chkSaveUser;
		public System.Windows.Forms.CheckBox chkSavePassword;
		public System.Windows.Forms.Button cmdVerify;
		public System.Windows.Forms.TextBox txtPassword;
		public System.Windows.Forms.TextBox txtUserID;
		public System.Windows.Forms.ComboBox txtLocationNo;
		public System.Windows.Forms.Label txtLocationName;
		private System.Windows.Forms.ComboBox _cmbLanguage_0;
		public System.Windows.Forms.Button btnExit;
		public System.Windows.Forms.ComboBox cmbCompany;
		public System.Windows.Forms.PictureBox Image2;
		public System.Windows.Forms.PictureBox Image3;
		public System.Windows.Forms.Label Label2;
		public System.Windows.Forms.Label Label1;
		public System.Windows.Forms.Label lblLanguage;
		public System.Windows.Forms.Label lblCompanyCode;
		public System.Windows.Forms.Label lblLocationCode;
		public System.Windows.Forms.Label lblPassword;
		public System.Windows.Forms.Label lblUserID;
		public System.Windows.Forms.PictureBox Image1;
		public System.Windows.Forms.PictureBox ImageManager;
		public Syncfusion.Windows.Forms.Tools.CommandBarController mnuSystemMenu;
		public System.Windows.Forms.ComboBox[] cmbLanguage = new System.Windows.Forms.ComboBox[1];
		//public UpgradeHelpers.Gui.CommandButtonHelper commandButtonHelper1;
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
            this.btnLogin = new System.Windows.Forms.Button();
            this.chkSaveUser = new System.Windows.Forms.CheckBox();
            this.chkSavePassword = new System.Windows.Forms.CheckBox();
            this.cmdVerify = new System.Windows.Forms.Button();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUserID = new System.Windows.Forms.TextBox();
            this.txtLocationNo = new System.Windows.Forms.ComboBox();
            this.txtLocationName = new System.Windows.Forms.Label();
            this._cmbLanguage_0 = new System.Windows.Forms.ComboBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.cmbCompany = new System.Windows.Forms.ComboBox();
            this.Image2 = new System.Windows.Forms.PictureBox();
            this.Image3 = new System.Windows.Forms.PictureBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.lblLanguage = new System.Windows.Forms.Label();
            this.lblCompanyCode = new System.Windows.Forms.Label();
            this.lblLocationCode = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblUserID = new System.Windows.Forms.Label();
            this.Image1 = new System.Windows.Forms.PictureBox();
            this.ImageManager = new System.Windows.Forms.PictureBox();
            this.mnuSystemMenu = new Syncfusion.Windows.Forms.Tools.CommandBarController(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.Image2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Image3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Image1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImageManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mnuSystemMenu)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(170, 416);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(79, 33);
            this.btnLogin.TabIndex = 5;
            this.btnLogin.Text = "Login";
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_ClickEvent);
            // 
            // chkSaveUser
            // 
            this.chkSaveUser.BackColor = System.Drawing.SystemColors.Highlight;
            this.chkSaveUser.Checked = true;
            this.chkSaveUser.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSaveUser.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkSaveUser.Location = new System.Drawing.Point(147, 416);
            this.chkSaveUser.Name = "chkSaveUser";
            this.chkSaveUser.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chkSaveUser.Size = new System.Drawing.Size(13, 13);
            this.chkSaveUser.TabIndex = 8;
            this.chkSaveUser.Text = "Save User Name";
            this.chkSaveUser.UseVisualStyleBackColor = false;
            // 
            // chkSavePassword
            // 
            this.chkSavePassword.BackColor = System.Drawing.SystemColors.Highlight;
            this.chkSavePassword.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkSavePassword.Location = new System.Drawing.Point(147, 434);
            this.chkSavePassword.Name = "chkSavePassword";
            this.chkSavePassword.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chkSavePassword.Size = new System.Drawing.Size(13, 13);
            this.chkSavePassword.TabIndex = 9;
            this.chkSavePassword.Text = "Save Password";
            this.chkSavePassword.UseVisualStyleBackColor = false;
            // 
            // cmdVerify
            // 
            this.cmdVerify.BackColor = System.Drawing.SystemColors.Control;
            this.cmdVerify.Font = new System.Drawing.Font("Wingdings", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.cmdVerify.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmdVerify.Location = new System.Drawing.Point(218, 500);
            this.cmdVerify.Name = "cmdVerify";
            this.cmdVerify.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmdVerify.Size = new System.Drawing.Size(25, 21);
            this.cmdVerify.TabIndex = 0;
            this.cmdVerify.TabStop = false;
            this.cmdVerify.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.cmdVerify.UseVisualStyleBackColor = false;
            this.cmdVerify.Visible = false;
            // 
            // txtPassword
            // 
            this.txtPassword.BackColor = System.Drawing.Color.White;
            this.txtPassword.ForeColor = System.Drawing.Color.Black;
            this.txtPassword.Location = new System.Drawing.Point(92, 368);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(237, 20);
            this.txtPassword.TabIndex = 3;
            // 
            // txtUserID
            // 
            this.txtUserID.BackColor = System.Drawing.Color.White;
            this.txtUserID.ForeColor = System.Drawing.Color.Black;
            this.txtUserID.Location = new System.Drawing.Point(92, 346);
            this.txtUserID.Name = "txtUserID";
            this.txtUserID.Size = new System.Drawing.Size(237, 20);
            this.txtUserID.TabIndex = 2;
            // 
            // txtLocationNo
            // 
            this.txtLocationNo.BackColor = System.Drawing.Color.White;
            this.txtLocationNo.ForeColor = System.Drawing.Color.Black;
            this.txtLocationNo.Location = new System.Drawing.Point(92, 390);
            this.txtLocationNo.Name = "txtLocationNo";
            this.txtLocationNo.Size = new System.Drawing.Size(67, 20);
            this.txtLocationNo.TabIndex = 4;
            // 
            // txtLocationName
            // 
            this.txtLocationName.Location = new System.Drawing.Point(160, 390);
            this.txtLocationName.Name = "txtLocationName";
            this.txtLocationName.Size = new System.Drawing.Size(169, 19);
            this.txtLocationName.TabIndex = 10;
            // 
            // _cmbLanguage_0
            // 
            this._cmbLanguage_0.Location = new System.Drawing.Point(92, 458);
            this._cmbLanguage_0.Name = "_cmbLanguage_0";
            this._cmbLanguage_0.Size = new System.Drawing.Size(237, 21);
            this._cmbLanguage_0.TabIndex = 7;
            this._cmbLanguage_0.Visible = false;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(250, 416);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(79, 33);
            this.btnExit.TabIndex = 6;
            this.btnExit.Text = "Exit";
            // 
            // cmbCompany
            // 
            this.cmbCompany.Location = new System.Drawing.Point(92, 322);
            this.cmbCompany.Name = "cmbCompany";
            this.cmbCompany.Size = new System.Drawing.Size(237, 21);
            this.cmbCompany.TabIndex = 1;
            // 
            // Image2
            // 
            this.Image2.Location = new System.Drawing.Point(0, 50);
            this.Image2.Name = "Image2";
            this.Image2.Size = new System.Drawing.Size(342, 244);
            this.Image2.TabIndex = 11;
            this.Image2.TabStop = false;
            // 
            // Image3
            // 
            this.Image3.Location = new System.Drawing.Point(484, 214);
            this.Image3.Name = "Image3";
            this.Image3.Size = new System.Drawing.Size(550, 328);
            this.Image3.TabIndex = 12;
            this.Image3.TabStop = false;
            // 
            // Label2
            // 
            this.Label2.BackColor = System.Drawing.Color.Transparent;
            this.Label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.Label2.Location = new System.Drawing.Point(10, 432);
            this.Label2.Name = "Label2";
            this.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Label2.Size = new System.Drawing.Size(131, 19);
            this.Label2.TabIndex = 17;
            this.Label2.Text = "Remember Password";
            // 
            // Label1
            // 
            this.Label1.BackColor = System.Drawing.Color.Transparent;
            this.Label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.Label1.Location = new System.Drawing.Point(10, 414);
            this.Label1.Name = "Label1";
            this.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Label1.Size = new System.Drawing.Size(125, 19);
            this.Label1.TabIndex = 16;
            this.Label1.Text = "Remember User ID";
            // 
            // lblLanguage
            // 
            this.lblLanguage.BackColor = System.Drawing.Color.Transparent;
            this.lblLanguage.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLanguage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.lblLanguage.Location = new System.Drawing.Point(10, 460);
            this.lblLanguage.Name = "lblLanguage";
            this.lblLanguage.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblLanguage.Size = new System.Drawing.Size(65, 19);
            this.lblLanguage.TabIndex = 15;
            this.lblLanguage.Text = "Language";
            // 
            // lblCompanyCode
            // 
            this.lblCompanyCode.BackColor = System.Drawing.Color.Transparent;
            this.lblCompanyCode.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCompanyCode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.lblCompanyCode.Location = new System.Drawing.Point(8, 326);
            this.lblCompanyCode.Name = "lblCompanyCode";
            this.lblCompanyCode.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblCompanyCode.Size = new System.Drawing.Size(57, 19);
            this.lblCompanyCode.TabIndex = 14;
            this.lblCompanyCode.Text = "Company";
            // 
            // lblLocationCode
            // 
            this.lblLocationCode.BackColor = System.Drawing.Color.Transparent;
            this.lblLocationCode.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLocationCode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.lblLocationCode.Location = new System.Drawing.Point(10, 394);
            this.lblLocationCode.Name = "lblLocationCode";
            this.lblLocationCode.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblLocationCode.Size = new System.Drawing.Size(57, 15);
            this.lblLocationCode.TabIndex = 13;
            this.lblLocationCode.Text = "Location";
            // 
            // lblPassword
            // 
            this.lblPassword.BackColor = System.Drawing.Color.Transparent;
            this.lblPassword.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.lblPassword.Location = new System.Drawing.Point(10, 372);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblPassword.Size = new System.Drawing.Size(67, 13);
            this.lblPassword.TabIndex = 12;
            this.lblPassword.Text = "Password";
            // 
            // lblUserID
            // 
            this.lblUserID.BackColor = System.Drawing.Color.Transparent;
            this.lblUserID.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.lblUserID.Location = new System.Drawing.Point(10, 350);
            this.lblUserID.Name = "lblUserID";
            this.lblUserID.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblUserID.Size = new System.Drawing.Size(64, 22);
            this.lblUserID.TabIndex = 11;
            this.lblUserID.Text = "User ID";
            // 
            // Image1
            // 
            this.Image1.Location = new System.Drawing.Point(0, 294);
            this.Image1.Name = "Image1";
            this.Image1.Size = new System.Drawing.Size(342, 490);
            this.Image1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Image1.TabIndex = 18;
            this.Image1.TabStop = false;
            // 
            // ImageManager
            // 
            this.ImageManager.Location = new System.Drawing.Point(28, 308);
            this.ImageManager.Name = "ImageManager";
            this.ImageManager.Size = new System.Drawing.Size(100, 50);
            this.ImageManager.TabIndex = 19;
            this.ImageManager.TabStop = false;
            // 
            // mnuSystemMenu
            // 
            this.mnuSystemMenu.HostForm = this;
            this.mnuSystemMenu.MetroBackColor = System.Drawing.Color.White;
            this.mnuSystemMenu.MetroColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.mnuSystemMenu.UseBackwardCompatiblity = false;
            // 
            // frmSysLogin
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1006, 790);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.chkSaveUser);
            this.Controls.Add(this.chkSavePassword);
            this.Controls.Add(this.cmdVerify);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUserID);
            this.Controls.Add(this.txtLocationNo);
            this.Controls.Add(this.txtLocationName);
            this.Controls.Add(this._cmbLanguage_0);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.cmbCompany);
            this.Controls.Add(this.Image2);
            this.Controls.Add(this.Image3);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.lblLanguage);
            this.Controls.Add(this.lblCompanyCode);
            this.Controls.Add(this.lblLocationCode);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.lblUserID);
            this.Controls.Add(this.Image1);
            this.Controls.Add(this.ImageManager);
            this.KeyPreview = true;
            this.Location = new System.Drawing.Point(533, 103);
            this.Name = "frmSysLogin";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Text = "Innova Login";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmSysLogin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Image2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Image3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Image1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImageManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mnuSystemMenu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
		// 
		
		#endregion
	}
}//ENDSHERE
