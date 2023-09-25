
namespace Xtreme
{
	partial class frmGLSalesman
	{

		#region "Upgrade Support "
		private static frmGLSalesman m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmGLSalesman DefInstance
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
		public static frmGLSalesman CreateInstance()
		{
			frmGLSalesman theInstance = new frmGLSalesman();
			
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
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "txtCommPercent", "txtComment", "lblFax", "lblPfNo", "lblSmanNo", "lblLSmanName", "lblAddr_1", "lblAddr_2", "lblPhone", "lblCivilId", "lblASmanName", "lblComments", "lblEmail", "lblMobile", "lblCommission", "txtEmail", "txtMobile", "txtPfNo", "txtSmanNo", "txtLSmanName", "txtAdd1", "txtPhone", "txtFax", "txtCivilId", "txtASmanName", "txtAdd2", "txtLocatCode", "_lblCommonLabel_2", "txtDisplayLocatCode", "lblCommonLabel"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public System.Windows.Forms.TextBox txtCommPercent;
		public System.Windows.Forms.TextBox txtComment;
		public System.Windows.Forms.Label lblFax;
		public System.Windows.Forms.Label lblPfNo;
		public System.Windows.Forms.Label lblSmanNo;
		public System.Windows.Forms.Label lblLSmanName;
		public System.Windows.Forms.Label lblAddr_1;
		public System.Windows.Forms.Label lblAddr_2;
		public System.Windows.Forms.Label lblPhone;
		public System.Windows.Forms.Label lblCivilId;
		public System.Windows.Forms.Label lblASmanName;
		public System.Windows.Forms.Label lblComments;
		public System.Windows.Forms.Label lblEmail;
		public System.Windows.Forms.Label lblMobile;
		public System.Windows.Forms.Label lblCommission;
		public System.Windows.Forms.TextBox txtEmail;
		public System.Windows.Forms.TextBox txtMobile;
		public System.Windows.Forms.TextBox txtPfNo;
		public System.Windows.Forms.TextBox txtSmanNo;
		public System.Windows.Forms.TextBox txtLSmanName;
		public System.Windows.Forms.TextBox txtAdd1;
		public System.Windows.Forms.TextBox txtPhone;
		public System.Windows.Forms.TextBox txtFax;
		public System.Windows.Forms.TextBox txtCivilId;
		public System.Windows.Forms.TextBox txtASmanName;
		public System.Windows.Forms.TextBox txtAdd2;
		public System.Windows.Forms.TextBox txtLocatCode;
		private System.Windows.Forms.Label _lblCommonLabel_2;
		public System.Windows.Forms.Label txtDisplayLocatCode;
		public System.Windows.Forms.Label[] lblCommonLabel = new System.Windows.Forms.Label[3];
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGLSalesman));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this.txtCommPercent = new System.Windows.Forms.TextBox();
			this.txtComment = new System.Windows.Forms.TextBox();
			this.lblFax = new System.Windows.Forms.Label();
			this.lblPfNo = new System.Windows.Forms.Label();
			this.lblSmanNo = new System.Windows.Forms.Label();
			this.lblLSmanName = new System.Windows.Forms.Label();
			this.lblAddr_1 = new System.Windows.Forms.Label();
			this.lblAddr_2 = new System.Windows.Forms.Label();
			this.lblPhone = new System.Windows.Forms.Label();
			this.lblCivilId = new System.Windows.Forms.Label();
			this.lblASmanName = new System.Windows.Forms.Label();
			this.lblComments = new System.Windows.Forms.Label();
			this.lblEmail = new System.Windows.Forms.Label();
			this.lblMobile = new System.Windows.Forms.Label();
			this.lblCommission = new System.Windows.Forms.Label();
			this.txtEmail = new System.Windows.Forms.TextBox();
			this.txtMobile = new System.Windows.Forms.TextBox();
			this.txtPfNo = new System.Windows.Forms.TextBox();
			this.txtSmanNo = new System.Windows.Forms.TextBox();
			this.txtLSmanName = new System.Windows.Forms.TextBox();
			this.txtAdd1 = new System.Windows.Forms.TextBox();
			this.txtPhone = new System.Windows.Forms.TextBox();
			this.txtFax = new System.Windows.Forms.TextBox();
			this.txtCivilId = new System.Windows.Forms.TextBox();
			this.txtASmanName = new System.Windows.Forms.TextBox();
			this.txtAdd2 = new System.Windows.Forms.TextBox();
			this.txtLocatCode = new System.Windows.Forms.TextBox();
			this._lblCommonLabel_2 = new System.Windows.Forms.Label();
			this.txtDisplayLocatCode = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// txtCommPercent
			// 
			this.txtCommPercent.AllowDrop = true;
			// this.txtCommPercent.DisplayFormat = "########0.00###;;0.000;0.00";
			this.txtCommPercent.Location = new System.Drawing.Point(332, 166);
			// // = 2147483647;
			// // = 0;
			this.txtCommPercent.Name = "txtCommPercent";
			this.txtCommPercent.Size = new System.Drawing.Size(93, 19);
			this.txtCommPercent.TabIndex = 25;
			// 
			// txtComment
			// 
			this.txtComment.AcceptsReturn = true;
			this.txtComment.AllowDrop = true;
			this.txtComment.BackColor = System.Drawing.SystemColors.Window;
			this.txtComment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtComment.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtComment.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtComment.Location = new System.Drawing.Point(135, 230);
			this.txtComment.MaxLength = 100;
			this.txtComment.Multiline = true;
			this.txtComment.Name = "txtComment";
			this.txtComment.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtComment.Size = new System.Drawing.Size(290, 63);
			this.txtComment.TabIndex = 11;
			// 
			// lblFax
			// 
			this.lblFax.AllowDrop = true;
			this.lblFax.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblFax.Text = "Fax";
			this.lblFax.ForeColor = System.Drawing.Color.Black;
			this.lblFax.Location = new System.Drawing.Point(8, 147);
			// // this.lblFax.mLabelId = 270;
			this.lblFax.Name = "lblFax";
			this.lblFax.Size = new System.Drawing.Size(18, 14);
			this.lblFax.TabIndex = 20;
			// 
			// lblPfNo
			// 
			this.lblPfNo.AllowDrop = true;
			this.lblPfNo.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblPfNo.Text = "PF No.";
			this.lblPfNo.ForeColor = System.Drawing.Color.Black;
			this.lblPfNo.Location = new System.Drawing.Point(8, 168);
			// // this.lblPfNo.mLabelId = 523;
			this.lblPfNo.Name = "lblPfNo";
			this.lblPfNo.Size = new System.Drawing.Size(31, 14);
			this.lblPfNo.TabIndex = 21;
			// 
			// lblSmanNo
			// 
			this.lblSmanNo.AllowDrop = true;
			this.lblSmanNo.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblSmanNo.Text = "Salesman Code";
			this.lblSmanNo.ForeColor = System.Drawing.Color.Black;
			this.lblSmanNo.Location = new System.Drawing.Point(8, 21);
			// // this.lblSmanNo.mLabelId = 688;
			this.lblSmanNo.Name = "lblSmanNo";
			this.lblSmanNo.Size = new System.Drawing.Size(75, 14);
			this.lblSmanNo.TabIndex = 12;
			// 
			// lblLSmanName
			// 
			this.lblLSmanName.AllowDrop = true;
			this.lblLSmanName.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblLSmanName.Text = "Salesman Name (English)";
			this.lblLSmanName.ForeColor = System.Drawing.Color.Black;
			this.lblLSmanName.Location = new System.Drawing.Point(8, 42);
			// // this.lblLSmanName.mLabelId = 969;
			this.lblLSmanName.Name = "lblLSmanName";
			this.lblLSmanName.Size = new System.Drawing.Size(122, 14);
			this.lblLSmanName.TabIndex = 13;
			// 
			// lblAddr_1
			// 
			this.lblAddr_1.AllowDrop = true;
			this.lblAddr_1.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblAddr_1.Text = "Address 1";
			this.lblAddr_1.ForeColor = System.Drawing.Color.Black;
			this.lblAddr_1.Location = new System.Drawing.Point(8, 84);
			// // this.lblAddr_1.mLabelId = 31;
			this.lblAddr_1.Name = "lblAddr_1";
			this.lblAddr_1.Size = new System.Drawing.Size(51, 14);
			this.lblAddr_1.TabIndex = 15;
			// 
			// lblAddr_2
			// 
			this.lblAddr_2.AllowDrop = true;
			this.lblAddr_2.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblAddr_2.Text = "Address2";
			this.lblAddr_2.ForeColor = System.Drawing.Color.Black;
			this.lblAddr_2.Location = new System.Drawing.Point(8, 105);
			// // this.lblAddr_2.mLabelId = 32;
			this.lblAddr_2.Name = "lblAddr_2";
			this.lblAddr_2.Size = new System.Drawing.Size(48, 14);
			this.lblAddr_2.TabIndex = 16;
			// 
			// lblPhone
			// 
			this.lblPhone.AllowDrop = true;
			this.lblPhone.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblPhone.Text = "Phone";
			this.lblPhone.ForeColor = System.Drawing.Color.Black;
			this.lblPhone.Location = new System.Drawing.Point(8, 126);
			// // this.lblPhone.mLabelId = 524;
			this.lblPhone.Name = "lblPhone";
			this.lblPhone.Size = new System.Drawing.Size(30, 14);
			this.lblPhone.TabIndex = 18;
			// 
			// lblCivilId
			// 
			this.lblCivilId.AllowDrop = true;
			this.lblCivilId.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblCivilId.Text = "Civil ID";
			this.lblCivilId.ForeColor = System.Drawing.Color.Black;
			this.lblCivilId.Location = new System.Drawing.Point(240, 147);
			// // this.lblCivilId.mLabelId = 124;
			this.lblCivilId.Name = "lblCivilId";
			this.lblCivilId.Size = new System.Drawing.Size(31, 14);
			this.lblCivilId.TabIndex = 19;
			// 
			// lblASmanName
			// 
			this.lblASmanName.AllowDrop = true;
			this.lblASmanName.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblASmanName.Text = "Salesman Name (Arabic)";
			this.lblASmanName.ForeColor = System.Drawing.Color.Black;
			this.lblASmanName.Location = new System.Drawing.Point(8, 63);
			// // this.lblASmanName.mLabelId = 970;
			this.lblASmanName.Name = "lblASmanName";
			this.lblASmanName.Size = new System.Drawing.Size(120, 14);
			this.lblASmanName.TabIndex = 14;
			// 
			// lblComments
			// 
			this.lblComments.AllowDrop = true;
			this.lblComments.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblComments.Text = "Comment";
			this.lblComments.ForeColor = System.Drawing.Color.Black;
			this.lblComments.Location = new System.Drawing.Point(8, 230);
			// // this.lblComments.mLabelId = 135;
			this.lblComments.Name = "lblComments";
			this.lblComments.Size = new System.Drawing.Size(44, 14);
			this.lblComments.TabIndex = 24;
			// 
			// lblEmail
			// 
			this.lblEmail.AllowDrop = true;
			this.lblEmail.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblEmail.Text = "Email";
			this.lblEmail.ForeColor = System.Drawing.Color.Black;
			this.lblEmail.Location = new System.Drawing.Point(8, 189);
			// // this.lblEmail.mLabelId = 231;
			this.lblEmail.Name = "lblEmail";
			this.lblEmail.Size = new System.Drawing.Size(24, 14);
			this.lblEmail.TabIndex = 23;
			// 
			// lblMobile
			// 
			this.lblMobile.AllowDrop = true;
			this.lblMobile.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblMobile.Text = "Mobile";
			this.lblMobile.ForeColor = System.Drawing.Color.Black;
			this.lblMobile.Location = new System.Drawing.Point(240, 126);
			// // this.lblMobile.mLabelId = 435;
			this.lblMobile.Name = "lblMobile";
			this.lblMobile.Size = new System.Drawing.Size(30, 14);
			this.lblMobile.TabIndex = 17;
			// 
			// lblCommission
			// 
			this.lblCommission.AllowDrop = true;
			this.lblCommission.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblCommission.Text = "Commission (in %)";
			this.lblCommission.ForeColor = System.Drawing.Color.Black;
			this.lblCommission.Location = new System.Drawing.Point(240, 168);
			// // this.lblCommission.mLabelId = 971;
			this.lblCommission.Name = "lblCommission";
			this.lblCommission.Size = new System.Drawing.Size(89, 14);
			this.lblCommission.TabIndex = 22;
			// 
			// txtEmail
			// 
			this.txtEmail.AllowDrop = true;
			this.txtEmail.BackColor = System.Drawing.Color.White;
			this.txtEmail.ForeColor = System.Drawing.Color.Black;
			this.txtEmail.Location = new System.Drawing.Point(135, 187);
			this.txtEmail.MaxLength = 50;
			this.txtEmail.Name = "txtEmail";
			this.txtEmail.Size = new System.Drawing.Size(290, 19);
			this.txtEmail.TabIndex = 10;
			this.txtEmail.Text = "";
			// this.// = "";
			// 
			// txtMobile
			// 
			this.txtMobile.AllowDrop = true;
			this.txtMobile.BackColor = System.Drawing.Color.White;
			this.txtMobile.ForeColor = System.Drawing.Color.Black;
			this.txtMobile.Location = new System.Drawing.Point(332, 124);
			this.txtMobile.MaxLength = 10;
			this.txtMobile.Name = "txtMobile";
			this.txtMobile.Size = new System.Drawing.Size(93, 19);
			this.txtMobile.TabIndex = 6;
			this.txtMobile.Text = "";
			// this.// = "";
			// 
			// txtPfNo
			// 
			this.txtPfNo.AllowDrop = true;
			this.txtPfNo.BackColor = System.Drawing.Color.White;
			this.txtPfNo.ForeColor = System.Drawing.Color.Black;
			this.txtPfNo.Location = new System.Drawing.Point(135, 166);
			this.txtPfNo.MaxLength = 20;
			this.txtPfNo.Name = "txtPfNo";
			this.txtPfNo.Size = new System.Drawing.Size(101, 19);
			this.txtPfNo.TabIndex = 9;
			this.txtPfNo.Text = "";
			// this.// = "";
			// 
			// txtSmanNo
			// 
			this.txtSmanNo.AllowDrop = true;
			this.txtSmanNo.BackColor = System.Drawing.Color.White;
			// this.txtSmanNo.bolNumericOnly = true;
			this.txtSmanNo.ForeColor = System.Drawing.Color.Black;
			this.txtSmanNo.Location = new System.Drawing.Point(135, 19);
			this.txtSmanNo.MaxLength = 4;
			// // = System.Windows.Forms.TextBox.DropDownTypes.ddtNextNumber;
			this.txtSmanNo.Name = "txtSmanNo";
			// this.txtSmanNo.ShowButton = true;
			this.txtSmanNo.Size = new System.Drawing.Size(101, 19);
			this.txtSmanNo.TabIndex = 0;
			this.txtSmanNo.Text = "";
			// this.// = "";
			// this.//this.txtSmanNo.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(//this.txtSmanNo_DropButtonClick);
			// 
			// txtLSmanName
			// 
			this.txtLSmanName.AllowDrop = true;
			this.txtLSmanName.BackColor = System.Drawing.Color.White;
			this.txtLSmanName.ForeColor = System.Drawing.Color.Black;
			this.txtLSmanName.Location = new System.Drawing.Point(135, 40);
			this.txtLSmanName.MaxLength = 50;
			this.txtLSmanName.Name = "txtLSmanName";
			this.txtLSmanName.Size = new System.Drawing.Size(290, 19);
			this.txtLSmanName.TabIndex = 1;
			this.txtLSmanName.Tag = "Salesman Name in English";
			this.txtLSmanName.Text = "";
			// this.// = "";
			// 
			// txtAdd1
			// 
			this.txtAdd1.AllowDrop = true;
			this.txtAdd1.BackColor = System.Drawing.Color.White;
			this.txtAdd1.ForeColor = System.Drawing.Color.Black;
			this.txtAdd1.Location = new System.Drawing.Point(135, 82);
			this.txtAdd1.MaxLength = 50;
			this.txtAdd1.Name = "txtAdd1";
			this.txtAdd1.Size = new System.Drawing.Size(290, 19);
			this.txtAdd1.TabIndex = 3;
			this.txtAdd1.Text = "";
			// this.// = "";
			// 
			// txtPhone
			// 
			this.txtPhone.AllowDrop = true;
			this.txtPhone.BackColor = System.Drawing.Color.White;
			this.txtPhone.ForeColor = System.Drawing.Color.Black;
			this.txtPhone.Location = new System.Drawing.Point(135, 124);
			this.txtPhone.MaxLength = 10;
			this.txtPhone.Name = "txtPhone";
			this.txtPhone.Size = new System.Drawing.Size(101, 19);
			this.txtPhone.TabIndex = 5;
			this.txtPhone.Text = "";
			// this.// = "";
			// 
			// txtFax
			// 
			this.txtFax.AllowDrop = true;
			this.txtFax.BackColor = System.Drawing.Color.White;
			this.txtFax.ForeColor = System.Drawing.Color.Black;
			this.txtFax.Location = new System.Drawing.Point(135, 145);
			this.txtFax.MaxLength = 10;
			this.txtFax.Name = "txtFax";
			this.txtFax.Size = new System.Drawing.Size(101, 19);
			this.txtFax.TabIndex = 7;
			this.txtFax.Text = "";
			// this.// = "";
			// 
			// txtCivilId
			// 
			this.txtCivilId.AllowDrop = true;
			this.txtCivilId.BackColor = System.Drawing.Color.White;
			this.txtCivilId.ForeColor = System.Drawing.Color.Black;
			this.txtCivilId.Location = new System.Drawing.Point(332, 144);
			this.txtCivilId.MaxLength = 20;
			this.txtCivilId.Name = "txtCivilId";
			this.txtCivilId.Size = new System.Drawing.Size(93, 19);
			this.txtCivilId.TabIndex = 8;
			this.txtCivilId.Text = "";
			// this.// = "";
			// 
			// txtASmanName
			// 
			this.txtASmanName.AllowDrop = true;
			this.txtASmanName.BackColor = System.Drawing.Color.White;
			this.txtASmanName.ForeColor = System.Drawing.Color.Black;
			this.txtASmanName.Location = new System.Drawing.Point(135, 61);
			// // = true;
			this.txtASmanName.MaxLength = 50;
			this.txtASmanName.Name = "txtASmanName";
			this.txtASmanName.Size = new System.Drawing.Size(290, 19);
			this.txtASmanName.TabIndex = 2;
			this.txtASmanName.Text = "";
			// this.// = "";
			// 
			// txtAdd2
			// 
			this.txtAdd2.AllowDrop = true;
			this.txtAdd2.BackColor = System.Drawing.Color.White;
			this.txtAdd2.ForeColor = System.Drawing.Color.Black;
			this.txtAdd2.Location = new System.Drawing.Point(135, 103);
			this.txtAdd2.MaxLength = 50;
			this.txtAdd2.Name = "txtAdd2";
			this.txtAdd2.Size = new System.Drawing.Size(290, 19);
			this.txtAdd2.TabIndex = 4;
			this.txtAdd2.Text = "";
			// this.// = "";
			// 
			// txtLocatCode
			// 
			this.txtLocatCode.AllowDrop = true;
			this.txtLocatCode.BackColor = System.Drawing.Color.White;
			// this.txtLocatCode.bolNumericOnly = true;
			this.txtLocatCode.ForeColor = System.Drawing.Color.Black;
			this.txtLocatCode.Location = new System.Drawing.Point(134, 208);
			this.txtLocatCode.MaxLength = 4;
			this.txtLocatCode.Name = "txtLocatCode";
			// this.txtLocatCode.ShowButton = true;
			this.txtLocatCode.Size = new System.Drawing.Size(101, 19);
			this.txtLocatCode.TabIndex = 26;
			this.txtLocatCode.Text = "";
			// this.// = "";
			// this.//this.txtLocatCode.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(//this.txtLocatCode_DropButtonClick);
			// this.txtLocatCode.Leave += new System.EventHandler(this.txtLocatCode_Leave);
			// 
			// _lblCommonLabel_2
			// 
			this._lblCommonLabel_2.AllowDrop = true;
			this._lblCommonLabel_2.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_2.Text = "Location Code";
			this._lblCommonLabel_2.ForeColor = System.Drawing.Color.Black;
			this._lblCommonLabel_2.Location = new System.Drawing.Point(8, 209);
			// // this._lblCommonLabel_2.mLabelId = 416;
			this._lblCommonLabel_2.Name = "_lblCommonLabel_2";
			this._lblCommonLabel_2.Size = new System.Drawing.Size(80, 15);
			this._lblCommonLabel_2.TabIndex = 27;
			// 
			// txtDisplayLocatCode
			// 
			this.txtDisplayLocatCode.AllowDrop = true;
			this.txtDisplayLocatCode.Location = new System.Drawing.Point(238, 208);
			this.txtDisplayLocatCode.Name = "txtDisplayLocatCode";
			this.txtDisplayLocatCode.Size = new System.Drawing.Size(187, 19);
			this.txtDisplayLocatCode.TabIndex = 28;
			this.txtDisplayLocatCode.TabStop = false;
			// 
			// frmGLSalesman
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.ClientSize = new System.Drawing.Size(597, 439);
			this.Controls.Add(this.txtCommPercent);
			this.Controls.Add(this.txtComment);
			this.Controls.Add(this.lblFax);
			this.Controls.Add(this.lblPfNo);
			this.Controls.Add(this.lblSmanNo);
			this.Controls.Add(this.lblLSmanName);
			this.Controls.Add(this.lblAddr_1);
			this.Controls.Add(this.lblAddr_2);
			this.Controls.Add(this.lblPhone);
			this.Controls.Add(this.lblCivilId);
			this.Controls.Add(this.lblASmanName);
			this.Controls.Add(this.lblComments);
			this.Controls.Add(this.lblEmail);
			this.Controls.Add(this.lblMobile);
			this.Controls.Add(this.lblCommission);
			this.Controls.Add(this.txtEmail);
			this.Controls.Add(this.txtMobile);
			this.Controls.Add(this.txtPfNo);
			this.Controls.Add(this.txtSmanNo);
			this.Controls.Add(this.txtLSmanName);
			this.Controls.Add(this.txtAdd1);
			this.Controls.Add(this.txtPhone);
			this.Controls.Add(this.txtFax);
			this.Controls.Add(this.txtCivilId);
			this.Controls.Add(this.txtASmanName);
			this.Controls.Add(this.txtAdd2);
			this.Controls.Add(this.txtLocatCode);
			this.Controls.Add(this._lblCommonLabel_2);
			this.Controls.Add(this.txtDisplayLocatCode);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			//this.Icon = (System.Drawing.Icon) resources.GetObject("frmGLSalesman.Icon");
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(457, 312);
			this.MaximizeBox = true;
			this.MinimizeBox = true;
			this.Name = "frmGLSalesman";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Salesman";
			this.ToolTipMain.SetToolTip(this.txtLSmanName, "Salesman Name in English");
			// this.Activated += new System.EventHandler(this.frmGLSalesman_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
			// this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
			this.ResumeLayout(false);
		}
		// 
		void InitializelblCommonLabel()
		{
			this.lblCommonLabel = new System.Windows.Forms.Label[3];
			this.lblCommonLabel[2] = _lblCommonLabel_2;
		}
		#endregion
	}
}//ENDSHERE
