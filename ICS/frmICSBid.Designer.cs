
namespace Xtreme
{
	partial class frmICSBid
	{

		#region "Upgrade Support "
		private static frmICSBid m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmICSBid DefInstance
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
		public static frmICSBid CreateInstance()
		{
			frmICSBid theInstance = new frmICSBid();
			
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
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "_lblCommon_3", "txtCurrencyName", "System.Windows.Forms.Label4", "System.Windows.Forms.Label3", "System.Windows.Forms.Label2", "chkCertifiedCheque", "chkBankGuarantee", "_Frame1_0", "txtValidityDate", "lblDate", "txtBidAmount", "lblAmount", "txtBGCCNo", "System.Windows.Forms.Label1", "System.Windows.Forms.Label5", "txtCurrencyCode", "txtIssueDate", "txtBankInitials", "System.Windows.Forms.Label6", "fraDetailsInfo", "txtBidNo", "lblCode", "Line2", "Line1", "tcbSystemForm", "Frame1", "lblCommon"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		private System.Windows.Forms.Label _lblCommon_3;
		public System.Windows.Forms.Label txtCurrencyName;
		public System.Windows.Forms.Label System.Windows.Forms.Label4;
		public System.Windows.Forms.Label System.Windows.Forms.Label3;
		public System.Windows.Forms.Label System.Windows.Forms.Label2;
		public System.Windows.Forms.CheckBox chkCertifiedCheque;
		public System.Windows.Forms.CheckBox chkBankGuarantee;
		private System.Windows.Forms.Panel _Frame1_0;
		public Syncfusion.WinForms.Input.SfDateTimeEdit txtValidityDate;
		public System.Windows.Forms.Label lblDate;
		public System.Windows.Forms.TextBox txtBidAmount;
		public System.Windows.Forms.Label lblAmount;
		public System.Windows.Forms.TextBox txtBGCCNo;
		public System.Windows.Forms.Label System.Windows.Forms.Label1;
		public System.Windows.Forms.Label System.Windows.Forms.Label5;
		public System.Windows.Forms.TextBox txtCurrencyCode;
		public Syncfusion.WinForms.Input.SfDateTimeEdit txtIssueDate;
		public System.Windows.Forms.TextBox txtBankInitials;
		public System.Windows.Forms.Label System.Windows.Forms.Label6;
		public AxTDBContainer3D6.AxTDBContainer3D fraDetailsInfo;
		public System.Windows.Forms.TextBox txtBidNo;
		public System.Windows.Forms.Label lblCode;
		public System.Windows.Forms.Label Line2;
		public System.Windows.Forms.Label Line1;
		public Syncfusion.Windows.Forms.Tools.CommandBarController tcbSystemForm;
		public System.Windows.Forms.Panel[] Frame1 = new System.Windows.Forms.Panel[1];
		public System.Windows.Forms.Label[] lblCommon = new System.Windows.Forms.Label[4];
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmICSBid));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this._lblCommon_3 = new System.Windows.Forms.Label();
			this.fraDetailsInfo = new AxTDBContainer3D6.AxTDBContainer3D();
			this.txtCurrencyName = new System.Windows.Forms.Label();
			this.System.Windows.Forms.Label4 = new System.Windows.Forms.Label();
			this.System.Windows.Forms.Label3 = new System.Windows.Forms.Label();
			this.System.Windows.Forms.Label2 = new System.Windows.Forms.Label();
			this.chkCertifiedCheque = new System.Windows.Forms.CheckBox();
			this.chkBankGuarantee = new System.Windows.Forms.CheckBox();
			this._Frame1_0 = new System.Windows.Forms.Panel();
			this.txtValidityDate = new Syncfusion.WinForms.Input.SfDateTimeEdit();
			this.lblDate = new System.Windows.Forms.Label();
			this.txtBidAmount = new System.Windows.Forms.TextBox();
			this.lblAmount = new System.Windows.Forms.Label();
			this.txtBGCCNo = new System.Windows.Forms.TextBox();
			this.System.Windows.Forms.Label1 = new System.Windows.Forms.Label();
			this.System.Windows.Forms.Label5 = new System.Windows.Forms.Label();
			this.txtCurrencyCode = new System.Windows.Forms.TextBox();
			this.txtIssueDate = new Syncfusion.WinForms.Input.SfDateTimeEdit();
			this.txtBankInitials = new System.Windows.Forms.TextBox();
			this.System.Windows.Forms.Label6 = new System.Windows.Forms.Label();
			this.txtBidNo = new System.Windows.Forms.TextBox();
			this.lblCode = new System.Windows.Forms.Label();
			this.Line2 = new System.Windows.Forms.Label();
			this.Line1 = new System.Windows.Forms.Label();
			this.tcbSystemForm = new Syncfusion.Windows.Forms.Tools.CommandBarController();
			// //((System.ComponentModel.ISupportInitialize) this.fraDetailsInfo).BeginInit();
			// //((System.ComponentModel.ISupportInitialize) this.tcbSystemForm).BeginInit();
			this.fraDetailsInfo.SuspendLayout();
			this.SuspendLayout();
			// 
			// _lblCommon_3
			// 
			this._lblCommon_3.AllowDrop = true;
			this._lblCommon_3.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_3.Text = " Bid Information ";
			this._lblCommon_3.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_3.Location = new System.Drawing.Point(32, 78);
			// this._lblCommon_3.mLabelId = 2047;
			this._lblCommon_3.Name = "_lblCommon_3";
			this._lblCommon_3.Size = new System.Drawing.Size(90, 14);
			this._lblCommon_3.TabIndex = 12;
			// 
			// fraDetailsInfo
			// 
			this.fraDetailsInfo.AllowDrop = true;
			this.fraDetailsInfo.Controls.Add(this.txtCurrencyName);
			this.fraDetailsInfo.Controls.Add(this.System.Windows.Forms.Label4);
			this.fraDetailsInfo.Controls.Add(this.System.Windows.Forms.Label3);
			this.fraDetailsInfo.Controls.Add(this.System.Windows.Forms.Label2);
			this.fraDetailsInfo.Controls.Add(this.chkCertifiedCheque);
			this.fraDetailsInfo.Controls.Add(this.chkBankGuarantee);
			this.fraDetailsInfo.Controls.Add(this._Frame1_0);
			this.fraDetailsInfo.Controls.Add(this.txtValidityDate);
			this.fraDetailsInfo.Controls.Add(this.lblDate);
			this.fraDetailsInfo.Controls.Add(this.txtBidAmount);
			this.fraDetailsInfo.Controls.Add(this.lblAmount);
			this.fraDetailsInfo.Controls.Add(this.txtBGCCNo);
			this.fraDetailsInfo.Controls.Add(this.System.Windows.Forms.Label1);
			this.fraDetailsInfo.Controls.Add(this.System.Windows.Forms.Label5);
			this.fraDetailsInfo.Controls.Add(this.txtCurrencyCode);
			this.fraDetailsInfo.Controls.Add(this.txtIssueDate);
			this.fraDetailsInfo.Controls.Add(this.txtBankInitials);
			this.fraDetailsInfo.Controls.Add(this.System.Windows.Forms.Label6);
			this.fraDetailsInfo.Location = new System.Drawing.Point(2, 94);
			this.fraDetailsInfo.Name = "fraDetailsInfo";
			("fraDetailsInfo.OcxState");
			this.fraDetailsInfo.Size = new System.Drawing.Size(475, 135);
			this.fraDetailsInfo.TabIndex = 11;
			// 
			// txtCurrencyName
			// 
			this.txtCurrencyName.AllowDrop = true;
			this.txtCurrencyName.BackColor = System.Drawing.SystemColors.Window;
			this.txtCurrencyName.Enabled = false;
			this.txtCurrencyName.Location = new System.Drawing.Point(372, 61);
			this.txtCurrencyName.Name = "txtCurrencyName";
			this.txtCurrencyName.Size = new System.Drawing.Size(92, 19);
			this.txtCurrencyName.TabIndex = 19;
			this.txtCurrencyName.TabStop = false;
			// 
			// System.Windows.Forms.Label4
			// 
			this.System.Windows.Forms.Label4.AllowDrop = true;
			this.System.Windows.Forms.Label4.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this.System.Windows.Forms.Label4.Caption = "Currency Code";
			this.System.Windows.Forms.Label4.ForeColor = System.Drawing.SystemColors.WindowText;
			this.System.Windows.Forms.Label4.Location = new System.Drawing.Point(232, 62);
			this.System.Windows.Forms.Label4.mLabelId = 2048;
			this.System.Windows.Forms.Label4.Name = "System.Windows.Forms.Label4";
			this.System.Windows.Forms.Label4.Size = new System.Drawing.Size(73, 14);
			this.System.Windows.Forms.Label4.TabIndex = 18;
			// 
			// System.Windows.Forms.Label3
			// 
			this.System.Windows.Forms.Label3.AllowDrop = true;
			this.System.Windows.Forms.Label3.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this.System.Windows.Forms.Label3.Caption = "Certified Cheque";
			this.System.Windows.Forms.Label3.ForeColor = System.Drawing.SystemColors.WindowText;
			this.System.Windows.Forms.Label3.Location = new System.Drawing.Point(44, 36);
			this.System.Windows.Forms.Label3.mLabelId = 2046;
			this.System.Windows.Forms.Label3.Name = "System.Windows.Forms.Label3";
			this.System.Windows.Forms.Label3.Size = new System.Drawing.Size(80, 14);
			this.System.Windows.Forms.Label3.TabIndex = 10;
			// 
			// System.Windows.Forms.Label2
			// 
			this.System.Windows.Forms.Label2.AllowDrop = true;
			this.System.Windows.Forms.Label2.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this.System.Windows.Forms.Label2.Caption = "Bank Guarantee";
			this.System.Windows.Forms.Label2.ForeColor = System.Drawing.SystemColors.WindowText;
			this.System.Windows.Forms.Label2.Location = new System.Drawing.Point(44, 14);
			this.System.Windows.Forms.Label2.mLabelId = 2045;
			this.System.Windows.Forms.Label2.Name = "System.Windows.Forms.Label2";
			this.System.Windows.Forms.Label2.Size = new System.Drawing.Size(78, 14);
			this.System.Windows.Forms.Label2.TabIndex = 9;
			// 
			// chkCertifiedCheque
			// 
			this.chkCertifiedCheque.AllowDrop = true;
			this.chkCertifiedCheque.Appearance = System.Windows.Forms.Appearance.Normal;
			this.chkCertifiedCheque.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this.chkCertifiedCheque.CausesValidation = true;
			this.chkCertifiedCheque.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkCertifiedCheque.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this.chkCertifiedCheque.Enabled = true;
			this.chkCertifiedCheque.ForeColor = System.Drawing.Color.Black;
			this.chkCertifiedCheque.Location = new System.Drawing.Point(26, 34);
			this.chkCertifiedCheque.Name = "chkCertifiedCheque";
			this.chkCertifiedCheque.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.chkCertifiedCheque.Size = new System.Drawing.Size(17, 17);
			this.chkCertifiedCheque.TabIndex = 2;
			this.chkCertifiedCheque.TabStop = true;
			this.chkCertifiedCheque.Text = "";
			this.chkCertifiedCheque.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkCertifiedCheque.Visible = true;
			// 
			// chkBankGuarantee
			// 
			this.chkBankGuarantee.AllowDrop = true;
			this.chkBankGuarantee.Appearance = System.Windows.Forms.Appearance.Normal;
			this.chkBankGuarantee.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this.chkBankGuarantee.CausesValidation = true;
			this.chkBankGuarantee.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkBankGuarantee.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this.chkBankGuarantee.Enabled = true;
			this.chkBankGuarantee.ForeColor = System.Drawing.Color.Black;
			this.chkBankGuarantee.Location = new System.Drawing.Point(26, 12);
			this.chkBankGuarantee.Name = "chkBankGuarantee";
			this.chkBankGuarantee.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.chkBankGuarantee.Size = new System.Drawing.Size(17, 17);
			this.chkBankGuarantee.TabIndex = 1;
			this.chkBankGuarantee.TabStop = true;
			this.chkBankGuarantee.Text = "";
			this.chkBankGuarantee.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkBankGuarantee.Visible = true;
			// 
			// _Frame1_0
			// 
			this._Frame1_0.AllowDrop = true;
			this._Frame1_0.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._Frame1_0.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._Frame1_0.Enabled = true;
			this._Frame1_0.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Italic | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 178);
			this._Frame1_0.ForeColor = System.Drawing.Color.FromArgb(224, 224, 224);
			this._Frame1_0.Location = new System.Drawing.Point(303, -118);
			this._Frame1_0.Name = "_Frame1_0";
			this._Frame1_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._Frame1_0.Size = new System.Drawing.Size(235, 43);
			this._Frame1_0.TabIndex = 13;
			this._Frame1_0.Visible = true;
			// 
			// txtValidityDate
			// 
			this.txtValidityDate.AllowDrop = true;
			// this.txtValidityDate.CheckDateRange = false;
			this.txtValidityDate.Location = new System.Drawing.Point(104, 60);
			// this.txtValidityDate.MaxDate = 2958465;
			// this.txtValidityDate.MinDate = 32874;
			this.txtValidityDate.Name = "txtValidityDate";
			this.txtValidityDate.Size = new System.Drawing.Size(102, 19);
			this.txtValidityDate.TabIndex = 3;
			this.txtValidityDate.Text = "7/18/2001";
			this.txtValidityDate.Value = 37090;
			// 
			// lblDate
			// 
			this.lblDate.AllowDrop = true;
			this.lblDate.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this.lblDate.Text = "Validity date";
			this.lblDate.ForeColor = System.Drawing.Color.Black;
			this.lblDate.Location = new System.Drawing.Point(26, 62);
			// this.lblDate.mLabelId = 2041;
			this.lblDate.Name = "lblDate";
			this.lblDate.Size = new System.Drawing.Size(59, 14);
			this.lblDate.TabIndex = 14;
			// 
			// txtBidAmount
			// 
			this.txtBidAmount.AllowDrop = true;
			// this.txtBidAmount.DisplayFormat = "####0.000###;;0.000;0.000";
			// this.txtBidAmount.Format = "###########0.000";
			this.txtBidAmount.Location = new System.Drawing.Point(104, 102);
			// this.txtBidAmount.MaxValue = 2147483647;
			// this.txtBidAmount.MinValue = 0;
			this.txtBidAmount.Name = "txtBidAmount";
			this.txtBidAmount.Size = new System.Drawing.Size(102, 19);
			this.txtBidAmount.TabIndex = 5;
			this.txtBidAmount.Text = "0.000";
			// 
			// lblAmount
			// 
			this.lblAmount.AllowDrop = true;
			this.lblAmount.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this.lblAmount.Text = "BG/CC Amount";
			this.lblAmount.ForeColor = System.Drawing.Color.Black;
			this.lblAmount.Location = new System.Drawing.Point(26, 105);
			// this.lblAmount.mLabelId = 2042;
			this.lblAmount.Name = "lblAmount";
			this.lblAmount.Size = new System.Drawing.Size(72, 14);
			this.lblAmount.TabIndex = 15;
			// 
			// txtBGCCNo
			// 
			this.txtBGCCNo.AllowDrop = true;
			this.txtBGCCNo.BackColor = System.Drawing.Color.White;
			// this.txtBGCCNo.bolNumericOnly = true;
			this.txtBGCCNo.ForeColor = System.Drawing.Color.Black;
			this.txtBGCCNo.Location = new System.Drawing.Point(316, 82);
			this.txtBGCCNo.MaxLength = 15;
			// this.txtBGCCNo.mDropDownType = System.Windows.Forms.TextBox.DropDownTypes.ddtNextNumber;
			this.txtBGCCNo.Name = "txtBGCCNo";
			this.txtBGCCNo.Size = new System.Drawing.Size(149, 19);
			this.txtBGCCNo.TabIndex = 7;
			this.txtBGCCNo.Text = "";
			// 
			// System.Windows.Forms.Label1
			// 
			this.System.Windows.Forms.Label1.AllowDrop = true;
			this.System.Windows.Forms.Label1.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this.System.Windows.Forms.Label1.Caption = "BG/CC No.";
			this.System.Windows.Forms.Label1.ForeColor = System.Drawing.Color.Black;
			this.System.Windows.Forms.Label1.Location = new System.Drawing.Point(232, 85);
			this.System.Windows.Forms.Label1.mLabelId = 2043;
			this.System.Windows.Forms.Label1.Name = "System.Windows.Forms.Label1";
			this.System.Windows.Forms.Label1.Size = new System.Drawing.Size(51, 14);
			this.System.Windows.Forms.Label1.TabIndex = 17;
			// 
			// System.Windows.Forms.Label5
			// 
			this.System.Windows.Forms.Label5.AllowDrop = true;
			this.System.Windows.Forms.Label5.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this.System.Windows.Forms.Label5.Caption = "Issue Date";
			this.System.Windows.Forms.Label5.ForeColor = System.Drawing.SystemColors.WindowText;
			this.System.Windows.Forms.Label5.Location = new System.Drawing.Point(26, 84);
			this.System.Windows.Forms.Label5.mLabelId = 2050;
			this.System.Windows.Forms.Label5.Name = "System.Windows.Forms.Label5";
			this.System.Windows.Forms.Label5.Size = new System.Drawing.Size(51, 14);
			this.System.Windows.Forms.Label5.TabIndex = 20;
			// 
			// txtCurrencyCode
			// 
			this.txtCurrencyCode.AllowDrop = true;
			this.txtCurrencyCode.BackColor = System.Drawing.Color.White;
			// this.txtCurrencyCode.bolAllowDecimal = false;
			this.txtCurrencyCode.ForeColor = System.Drawing.Color.Black;
			this.txtCurrencyCode.Location = new System.Drawing.Point(316, 61);
			// this.txtCurrencyCode.mDropDownType = (System.Windows.Forms.TextBox.DropDownTypes) 0;
			this.txtCurrencyCode.Name = "txtCurrencyCode";
			// this.txtCurrencyCode.ShowButton = true;
			this.txtCurrencyCode.Size = new System.Drawing.Size(54, 19);
			this.txtCurrencyCode.TabIndex = 6;
			this.txtCurrencyCode.Text = "";
			// this.this.txtCurrencyCode.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCurrencyCode_DropButtonClick);
			// this.this.txtCurrencyCode.KeyDown += new System.Windows.Forms.TextBox.KeyDownHandler(this.txtCurrencyCode_KeyDown);
			// this.txtCurrencyCode.Leave += new System.EventHandler(this.txtCurrencyCode_Leave);
			// 
			// txtIssueDate
			// 
			this.txtIssueDate.AllowDrop = true;
			// this.txtIssueDate.CheckDateRange = false;
			this.txtIssueDate.Location = new System.Drawing.Point(104, 81);
			// this.txtIssueDate.MaxDate = 2958465;
			// this.txtIssueDate.MinDate = 32874;
			this.txtIssueDate.Name = "txtIssueDate";
			this.txtIssueDate.Size = new System.Drawing.Size(102, 19);
			this.txtIssueDate.TabIndex = 4;
			this.txtIssueDate.Text = "7/18/2001";
			this.txtIssueDate.Value = 37090;
			// 
			// txtBankInitials
			// 
			this.txtBankInitials.AllowDrop = true;
			this.txtBankInitials.BackColor = System.Drawing.Color.White;
			this.txtBankInitials.ForeColor = System.Drawing.Color.Black;
			this.txtBankInitials.Location = new System.Drawing.Point(316, 103);
			this.txtBankInitials.MaxLength = 4;
			// this.txtBankInitials.mDropDownType = System.Windows.Forms.TextBox.DropDownTypes.ddtNextNumber;
			this.txtBankInitials.Name = "txtBankInitials";
			this.txtBankInitials.Size = new System.Drawing.Size(149, 19);
			this.txtBankInitials.TabIndex = 8;
			this.txtBankInitials.Text = "";
			// 
			// System.Windows.Forms.Label6
			// 
			this.System.Windows.Forms.Label6.AllowDrop = true;
			this.System.Windows.Forms.Label6.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this.System.Windows.Forms.Label6.Caption = "Bank Initails";
			this.System.Windows.Forms.Label6.ForeColor = System.Drawing.Color.Black;
			this.System.Windows.Forms.Label6.Location = new System.Drawing.Point(232, 105);
			this.System.Windows.Forms.Label6.mLabelId = 2049;
			this.System.Windows.Forms.Label6.Name = "System.Windows.Forms.Label6";
			this.System.Windows.Forms.Label6.Size = new System.Drawing.Size(56, 14);
			this.System.Windows.Forms.Label6.TabIndex = 21;
			// 
			// txtBidNo
			// 
			this.txtBidNo.AllowDrop = true;
			this.txtBidNo.BackColor = System.Drawing.Color.White;
			this.txtBidNo.ForeColor = System.Drawing.Color.Black;
			this.txtBidNo.Location = new System.Drawing.Point(94, 48);
			this.txtBidNo.MaxLength = 15;
			// this.txtBidNo.mDropDownType = System.Windows.Forms.TextBox.DropDownTypes.ddtNextNumber;
			this.txtBidNo.Name = "txtBidNo";
			// this.txtBidNo.ShowButton = true;
			this.txtBidNo.Size = new System.Drawing.Size(101, 19);
			this.txtBidNo.TabIndex = 0;
			this.txtBidNo.Text = "";
			// this.this.txtBidNo.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtBidNo_DropButtonClick);
			// 
			// lblCode
			// 
			this.lblCode.AllowDrop = true;
			this.lblCode.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblCode.Text = "Bid Code";
			this.lblCode.ForeColor = System.Drawing.Color.Black;
			this.lblCode.Location = new System.Drawing.Point(38, 54);
			// this.lblCode.mLabelId = 2044;
			this.lblCode.Name = "lblCode";
			this.lblCode.Size = new System.Drawing.Size(43, 14);
			this.lblCode.TabIndex = 16;
			// 
			// Line2
			// 
			this.Line2.AllowDrop = true;
			this.Line2.BackColor = System.Drawing.SystemColors.WindowText;
			this.Line2.Enabled = false;
			this.Line2.Location = new System.Drawing.Point(0, 86);
			this.Line2.Name = "Line2";
			this.Line2.Size = new System.Drawing.Size(736, 1);
			this.Line2.Visible = true;
			// 
			// Line1
			// 
			this.Line1.AllowDrop = true;
			this.Line1.BackColor = System.Drawing.SystemColors.WindowText;
			this.Line1.Enabled = false;
			this.Line1.Location = new System.Drawing.Point(0, 0);
			this.Line1.Name = "Line1";
			this.Line1.Size = new System.Drawing.Size(736, 1);
			this.Line1.Visible = true;
			// 
			// tcbSystemForm
			// 
			this.tcbSystemForm.AllowDrop = true;
			this.tcbSystemForm.Location = new System.Drawing.Point(52, 0);
			this.tcbSystemForm.Name = "tcbSystemForm";
			("tcbSystemForm.OcxState");
			// 
			// frmICSBid
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.ClientSize = new System.Drawing.Size(475, 229);
			this.Controls.Add(this._lblCommon_3);
			this.Controls.Add(this.fraDetailsInfo);
			this.Controls.Add(this.txtBidNo);
			this.Controls.Add(this.lblCode);
			this.Controls.Add(this.Line2);
			this.Controls.Add(this.Line1);
			this.Controls.Add(this.tcbSystemForm);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			//this.Icon = (System.Drawing.Icon) resources.GetObject("frmICSBid.Icon");
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(206, 148);
			this.MaximizeBox = false;
			this.MinimizeBox = true;
			this.Name = "frmICSBid";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Bid ";
			// this.Activated += new System.EventHandler(this.Form_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
			// this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
			//((System.ComponentModel.ISupportInitialize) this.fraDetailsInfo).EndInit();
			//((System.ComponentModel.ISupportInitialize) this.tcbSystemForm).EndInit();
			this.fraDetailsInfo.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		void ReLoadForm(bool addEvents)
		{
			InitializelblCommon();
			InitializeFrame1();
			//This form is an MDI child.
			//This code simulates the VB6 
			// functionality of automatically
			// loading and showing an MDI
			// child's parent.
			this.MdiParent = Xtreme.frmSysMain.DefInstance;
			Xtreme.frmSysMain.DefInstance.Show();
		}
		void InitializelblCommon()
		{
			this.lblCommon = new System.Windows.Forms.Label[4];
			this.lblCommon[3] = _lblCommon_3;
		}
		void InitializeFrame1()
		{
			this.Frame1 = new System.Windows.Forms.Panel[1];
			this.Frame1[0] = _Frame1_0;
		}
		#endregion
	}
}