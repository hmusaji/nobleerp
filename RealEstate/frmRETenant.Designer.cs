
namespace Xtreme
{
	partial class frmRETenant
	{

		#region "Upgrade Support "
		private static frmRETenant m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmRETenant DefInstance
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
		public static frmRETenant CreateInstance()
		{
			frmRETenant theInstance = new frmRETenant();
			
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
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "_txtCommon_4", "_txtCommon_5", "_txtCommon_3", "_txtCommon_6", "_txtCommon_8", "lblAssetsCode", "lblAssetsAdjustmentNo", "lblAssetsAdjustmentAccount", "System.Windows.Forms.Label1", "System.Windows.Forms.Label3", "System.Windows.Forms.Label4", "Label6_0", "Label7_0", "_txtCommon_7", "lblComments", "System.Windows.Forms.Label5", "_txtCommon_2", "_txtCommon_9", "_txtCommon_0", "_txtCommon_1", "_txtCommonDisplay_1", "_txtCommonDisplay_0", "Label7_1", "_txtCommon_10", "Label6_1", "_txtCommon_11", "Label6_2", "_txtCommon_12", "Label6_3", "_txtCommon_13", "Label6_4", "_txtCommon_14", "System.Windows.Forms.Label6", "System.Windows.Forms.Label7", "txtCommon", "txtCommonDisplay"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		private System.Windows.Forms.TextBox _txtCommon_4;
		private System.Windows.Forms.TextBox _txtCommon_5;
		private System.Windows.Forms.TextBox _txtCommon_3;
		private System.Windows.Forms.TextBox _txtCommon_6;
		private System.Windows.Forms.TextBox _txtCommon_8;
		public System.Windows.Forms.Label lblAssetsCode;
		public System.Windows.Forms.Label lblAssetsAdjustmentNo;
		public System.Windows.Forms.Label lblAssetsAdjustmentAccount;
		public System.Windows.Forms.Label Label1;
		public System.Windows.Forms.Label Label3;
		public System.Windows.Forms.Label Label4;
		private System.Windows.Forms.Label Label6_0;
		private System.Windows.Forms.Label Label7_0;
		private System.Windows.Forms.TextBox _txtCommon_7;
		public System.Windows.Forms.Label lblComments;
		public System.Windows.Forms.Label Label5;
		private System.Windows.Forms.TextBox _txtCommon_2;
		private System.Windows.Forms.TextBox _txtCommon_9;
		private System.Windows.Forms.TextBox _txtCommon_0;
		private System.Windows.Forms.TextBox _txtCommon_1;
		private System.Windows.Forms.Label _txtCommonDisplay_1;
		private System.Windows.Forms.Label _txtCommonDisplay_0;
		private System.Windows.Forms.Label Label7_1;
		private System.Windows.Forms.TextBox _txtCommon_10;
		private System.Windows.Forms.Label Label6_1;
		private System.Windows.Forms.TextBox _txtCommon_11;
		private System.Windows.Forms.Label Label6_2;
		private System.Windows.Forms.TextBox _txtCommon_12;
		private System.Windows.Forms.Label Label6_3;
		private System.Windows.Forms.TextBox _txtCommon_13;
		private System.Windows.Forms.Label Label6_4;
		private System.Windows.Forms.TextBox _txtCommon_14;
		public System.Windows.Forms.Label[] Label6 = new System.Windows.Forms.Label[5];
		public System.Windows.Forms.Label[] Label7 = new System.Windows.Forms.Label[2];
		public System.Windows.Forms.TextBox[] txtCommon = new System.Windows.Forms.TextBox[15];
		public System.Windows.Forms.Label[] txtCommonDisplay = new System.Windows.Forms.Label[2];
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRETenant));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this._txtCommon_4 = new System.Windows.Forms.TextBox();
			this._txtCommon_5 = new System.Windows.Forms.TextBox();
			this._txtCommon_3 = new System.Windows.Forms.TextBox();
			this._txtCommon_6 = new System.Windows.Forms.TextBox();
			this._txtCommon_8 = new System.Windows.Forms.TextBox();
			this.lblAssetsCode = new System.Windows.Forms.Label();
			this.lblAssetsAdjustmentNo = new System.Windows.Forms.Label();
			this.lblAssetsAdjustmentAccount = new System.Windows.Forms.Label();
			this.Label1 = new System.Windows.Forms.Label();
			this.Label3 = new System.Windows.Forms.Label();
			this.Label4 = new System.Windows.Forms.Label();
			this.Label6_0 = new System.Windows.Forms.Label();
			this.Label7_0 = new System.Windows.Forms.Label();
			this._txtCommon_7 = new System.Windows.Forms.TextBox();
			this.lblComments = new System.Windows.Forms.Label();
			this.Label5 = new System.Windows.Forms.Label();
			this._txtCommon_2 = new System.Windows.Forms.TextBox();
			this._txtCommon_9 = new System.Windows.Forms.TextBox();
			this._txtCommon_0 = new System.Windows.Forms.TextBox();
			this._txtCommon_1 = new System.Windows.Forms.TextBox();
			this._txtCommonDisplay_1 = new System.Windows.Forms.Label();
			this._txtCommonDisplay_0 = new System.Windows.Forms.Label();
			this.Label7_1 = new System.Windows.Forms.Label();
			this._txtCommon_10 = new System.Windows.Forms.TextBox();
			this.Label6_1 = new System.Windows.Forms.Label();
			this._txtCommon_11 = new System.Windows.Forms.TextBox();
			this.Label6_2 = new System.Windows.Forms.Label();
			this._txtCommon_12 = new System.Windows.Forms.TextBox();
			this.Label6_3 = new System.Windows.Forms.Label();
			this._txtCommon_13 = new System.Windows.Forms.TextBox();
			this.Label6_4 = new System.Windows.Forms.Label();
			this._txtCommon_14 = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// _txtCommon_4
			// 
			this._txtCommon_4.AllowDrop = true;
			this._txtCommon_4.BackColor = System.Drawing.Color.White;
			// this._txtCommon_4.bolNumericOnly = true;
			this._txtCommon_4.ForeColor = System.Drawing.Color.Black;
			this._txtCommon_4.Location = new System.Drawing.Point(144, 134);
			this._txtCommon_4.MaxLength = 15;
			this._txtCommon_4.Name = "_txtCommon_4";
			// this._txtCommon_4.ShowButton = true;
			this._txtCommon_4.Size = new System.Drawing.Size(101, 19);
			this._txtCommon_4.TabIndex = 4;
			this._txtCommon_4.Text = "";
			// this.this._txtCommon_4.Watermark = "";
			// this.this._txtCommon_4.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommon_DropButtonClick);
			// this._txtCommon_4.Leave += new System.EventHandler(this.txtCommon_Leave);
			// 
			// _txtCommon_5
			// 
			this._txtCommon_5.AllowDrop = true;
			this._txtCommon_5.BackColor = System.Drawing.Color.White;
			this._txtCommon_5.ForeColor = System.Drawing.Color.Black;
			this._txtCommon_5.Location = new System.Drawing.Point(144, 155);
			this._txtCommon_5.MaxLength = 15;
			this._txtCommon_5.Name = "_txtCommon_5";
			this._txtCommon_5.Size = new System.Drawing.Size(101, 19);
			this._txtCommon_5.TabIndex = 5;
			this._txtCommon_5.Text = "";
			// this.this._txtCommon_5.Watermark = "";
			// this.this._txtCommon_5.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommon_DropButtonClick);
			// this._txtCommon_5.Leave += new System.EventHandler(this.txtCommon_Leave);
			// 
			// _txtCommon_3
			// 
			this._txtCommon_3.AllowDrop = true;
			this._txtCommon_3.BackColor = System.Drawing.Color.White;
			// this._txtCommon_3.bolNumericOnly = true;
			this._txtCommon_3.ForeColor = System.Drawing.Color.Black;
			this._txtCommon_3.Location = new System.Drawing.Point(144, 113);
			this._txtCommon_3.MaxLength = 15;
			this._txtCommon_3.Name = "_txtCommon_3";
			// this._txtCommon_3.ShowButton = true;
			this._txtCommon_3.Size = new System.Drawing.Size(101, 19);
			this._txtCommon_3.TabIndex = 3;
			this._txtCommon_3.Text = "";
			// this.this._txtCommon_3.Watermark = "";
			// this.this._txtCommon_3.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommon_DropButtonClick);
			// this._txtCommon_3.Leave += new System.EventHandler(this.txtCommon_Leave);
			// 
			// _txtCommon_6
			// 
			this._txtCommon_6.AllowDrop = true;
			this._txtCommon_6.BackColor = System.Drawing.Color.White;
			this._txtCommon_6.ForeColor = System.Drawing.Color.Black;
			this._txtCommon_6.Location = new System.Drawing.Point(347, 155);
			this._txtCommon_6.MaxLength = 15;
			this._txtCommon_6.Name = "_txtCommon_6";
			this._txtCommon_6.Size = new System.Drawing.Size(101, 19);
			this._txtCommon_6.TabIndex = 6;
			this._txtCommon_6.Text = "";
			// this.this._txtCommon_6.Watermark = "";
			// this.this._txtCommon_6.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommon_DropButtonClick);
			// this._txtCommon_6.Leave += new System.EventHandler(this.txtCommon_Leave);
			// 
			// _txtCommon_8
			// 
			this._txtCommon_8.AllowDrop = true;
			this._txtCommon_8.BackColor = System.Drawing.Color.White;
			this._txtCommon_8.ForeColor = System.Drawing.Color.Black;
			this._txtCommon_8.Location = new System.Drawing.Point(347, 176);
			this._txtCommon_8.MaxLength = 15;
			this._txtCommon_8.Name = "_txtCommon_8";
			this._txtCommon_8.Size = new System.Drawing.Size(101, 19);
			this._txtCommon_8.TabIndex = 8;
			this._txtCommon_8.Text = "";
			// this.this._txtCommon_8.Watermark = "";
			// this.this._txtCommon_8.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommon_DropButtonClick);
			// this._txtCommon_8.Leave += new System.EventHandler(this.txtCommon_Leave);
			// 
			// lblAssetsCode
			// 
			this.lblAssetsCode.AllowDrop = true;
			this.lblAssetsCode.BackColor = System.Drawing.Color.FromArgb(224, 230, 237);
			this.lblAssetsCode.Text = "Tenant Name (English)";
			this.lblAssetsCode.ForeColor = System.Drawing.Color.Black;
			this.lblAssetsCode.Location = new System.Drawing.Point(8, 74);
			// // this.lblAssetsCode.mLabelId = 1220;
			this.lblAssetsCode.Name = "lblAssetsCode";
			this.lblAssetsCode.Size = new System.Drawing.Size(108, 14);
			this.lblAssetsCode.TabIndex = 15;
			// 
			// lblAssetsAdjustmentNo
			// 
			this.lblAssetsAdjustmentNo.AllowDrop = true;
			this.lblAssetsAdjustmentNo.BackColor = System.Drawing.Color.FromArgb(224, 230, 237);
			this.lblAssetsAdjustmentNo.Text = "Tenant Code";
			this.lblAssetsAdjustmentNo.ForeColor = System.Drawing.Color.Black;
			this.lblAssetsAdjustmentNo.Location = new System.Drawing.Point(8, 53);
			// // this.lblAssetsAdjustmentNo.mLabelId = 1156;
			this.lblAssetsAdjustmentNo.Name = "lblAssetsAdjustmentNo";
			this.lblAssetsAdjustmentNo.Size = new System.Drawing.Size(61, 14);
			this.lblAssetsAdjustmentNo.TabIndex = 16;
			// 
			// lblAssetsAdjustmentAccount
			// 
			this.lblAssetsAdjustmentAccount.AllowDrop = true;
			this.lblAssetsAdjustmentAccount.BackColor = System.Drawing.Color.FromArgb(224, 230, 237);
			this.lblAssetsAdjustmentAccount.Text = "Bank Code";
			this.lblAssetsAdjustmentAccount.ForeColor = System.Drawing.Color.Black;
			this.lblAssetsAdjustmentAccount.Location = new System.Drawing.Point(8, 137);
			// // this.lblAssetsAdjustmentAccount.mLabelId = 1151;
			this.lblAssetsAdjustmentAccount.Name = "lblAssetsAdjustmentAccount";
			this.lblAssetsAdjustmentAccount.Size = new System.Drawing.Size(52, 14);
			this.lblAssetsAdjustmentAccount.TabIndex = 17;
			// 
			// System.Windows.Forms.Label1
			// 
			this.Label1.AllowDrop = true;
			this.Label1.BackColor = System.Drawing.Color.FromArgb(224, 230, 237);
			this.Label1.Text = "Passport No";
			this.Label1.ForeColor = System.Drawing.Color.Black;
			this.Label1.Location = new System.Drawing.Point(8, 158);
			// this.Label1.mLabelId = 1182;
			this.Label1.Name = "System.Windows.Forms.Label1";
			this.Label1.Size = new System.Drawing.Size(59, 14);
			this.Label1.TabIndex = 18;
			// 
			// System.Windows.Forms.Label3
			// 
			this.Label3.AllowDrop = true;
			this.Label3.BackColor = System.Drawing.Color.FromArgb(224, 230, 237);
			this.Label3.Text = "Nationality Code";
			this.Label3.ForeColor = System.Drawing.Color.Black;
			this.Label3.Location = new System.Drawing.Point(8, 116);
			// this.Label3.mLabelId = 1058;
			this.Label3.Name = "System.Windows.Forms.Label3";
			this.Label3.Size = new System.Drawing.Size(77, 14);
			this.Label3.TabIndex = 19;
			// 
			// System.Windows.Forms.Label4
			// 
			this.Label4.AllowDrop = true;
			this.Label4.BackColor = System.Drawing.Color.FromArgb(224, 230, 237);
			this.Label4.Text = "Civil Id";
			this.Label4.ForeColor = System.Drawing.Color.Black;
			this.Label4.Location = new System.Drawing.Point(268, 158);
			// this.Label4.mLabelId = 124;
			this.Label4.Name = "System.Windows.Forms.Label4";
			this.Label4.Size = new System.Drawing.Size(30, 14);
			this.Label4.TabIndex = 20;
			// 
			// Label6_0
			// 
			this.Label6_0.AllowDrop = true;
			this.Label6_0.BackColor = System.Drawing.Color.FromArgb(224, 230, 237);
			this.Label6_0.Text = "Tenant Name (Arabic)";
			this.Label6_0.ForeColor = System.Drawing.Color.Black;
			this.Label6_0.Location = new System.Drawing.Point(8, 95);
			// this.Label6_0.mLabelId = 1221;
			this.Label6_0.Name = "Label6_0";
			this.Label6_0.Size = new System.Drawing.Size(106, 14);
			this.Label6_0.TabIndex = 21;
			// 
			// Label7_0
			// 
			this.Label7_0.AllowDrop = true;
			this.Label7_0.BackColor = System.Drawing.Color.FromArgb(224, 230, 237);
			this.Label7_0.Text = "Mobile No";
			this.Label7_0.ForeColor = System.Drawing.Color.Black;
			this.Label7_0.Location = new System.Drawing.Point(8, 199);
			// this.Label7_0.mLabelId = 1073;
			this.Label7_0.Name = "Label7_0";
			this.Label7_0.Size = new System.Drawing.Size(48, 13);
			this.Label7_0.TabIndex = 22;
			// 
			// _txtCommon_7
			// 
			this._txtCommon_7.AllowDrop = true;
			this._txtCommon_7.BackColor = System.Drawing.Color.White;
			this._txtCommon_7.ForeColor = System.Drawing.Color.Black;
			this._txtCommon_7.Location = new System.Drawing.Point(144, 197);
			this._txtCommon_7.MaxLength = 30;
			this._txtCommon_7.Name = "_txtCommon_7";
			this._txtCommon_7.Size = new System.Drawing.Size(101, 19);
			this._txtCommon_7.TabIndex = 9;
			this._txtCommon_7.Text = "";
			// this.this._txtCommon_7.Watermark = "";
			// this.this._txtCommon_7.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommon_DropButtonClick);
			// this._txtCommon_7.Leave += new System.EventHandler(this.txtCommon_Leave);
			// 
			// lblComments
			// 
			this.lblComments.AllowDrop = true;
			this.lblComments.BackColor = System.Drawing.Color.FromArgb(224, 230, 237);
			this.lblComments.Text = "Comments";
			this.lblComments.ForeColor = System.Drawing.Color.Black;
			this.lblComments.Location = new System.Drawing.Point(7, 314);
			// // this.lblComments.mLabelId = 135;
			this.lblComments.Name = "lblComments";
			this.lblComments.Size = new System.Drawing.Size(49, 13);
			this.lblComments.TabIndex = 23;
			// 
			// System.Windows.Forms.Label5
			// 
			this.Label5.AllowDrop = true;
			this.Label5.BackColor = System.Drawing.Color.FromArgb(224, 230, 237);
			this.Label5.Text = "Fax No";
			this.Label5.ForeColor = System.Drawing.Color.Black;
			this.Label5.Location = new System.Drawing.Point(268, 179);
			// this.Label5.mLabelId = 1076;
			this.Label5.Name = "System.Windows.Forms.Label5";
			this.Label5.Size = new System.Drawing.Size(34, 14);
			this.Label5.TabIndex = 24;
			// 
			// _txtCommon_2
			// 
			this._txtCommon_2.AllowDrop = true;
			this._txtCommon_2.BackColor = System.Drawing.Color.White;
			this._txtCommon_2.ForeColor = System.Drawing.Color.Black;
			this._txtCommon_2.Location = new System.Drawing.Point(144, 92);
			// this._txtCommon_2.mArabicEnabled = true;
			this._txtCommon_2.MaxLength = 250;
			this._txtCommon_2.Name = "_txtCommon_2";
			this._txtCommon_2.Size = new System.Drawing.Size(302, 19);
			this._txtCommon_2.TabIndex = 2;
			this._txtCommon_2.Text = "";
			// this.this._txtCommon_2.Watermark = "";
			// this.this._txtCommon_2.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommon_DropButtonClick);
			// this._txtCommon_2.Leave += new System.EventHandler(this.txtCommon_Leave);
			// 
			// _txtCommon_9
			// 
			this._txtCommon_9.AllowDrop = true;
			this._txtCommon_9.BackColor = System.Drawing.Color.White;
			this._txtCommon_9.ForeColor = System.Drawing.Color.Black;
			this._txtCommon_9.Location = new System.Drawing.Point(144, 302);
			this._txtCommon_9.MaxLength = 250;
			this._txtCommon_9.Name = "_txtCommon_9";
			this._txtCommon_9.Size = new System.Drawing.Size(302, 37);
			this._txtCommon_9.TabIndex = 14;
			this._txtCommon_9.Text = "";
			// this.this._txtCommon_9.Watermark = "";
			// this.this._txtCommon_9.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommon_DropButtonClick);
			// this._txtCommon_9.Leave += new System.EventHandler(this.txtCommon_Leave);
			// 
			// _txtCommon_0
			// 
			this._txtCommon_0.AllowDrop = true;
			this._txtCommon_0.BackColor = System.Drawing.Color.White;
			this._txtCommon_0.ForeColor = System.Drawing.Color.Black;
			this._txtCommon_0.Location = new System.Drawing.Point(144, 50);
			this._txtCommon_0.MaxLength = 15;
			// this._txtCommon_0.mDropDownType = System.Windows.Forms.TextBox.DropDownTypes.ddtNextNumber;
			this._txtCommon_0.Name = "_txtCommon_0";
			// this._txtCommon_0.ShowButton = true;
			this._txtCommon_0.Size = new System.Drawing.Size(101, 19);
			this._txtCommon_0.TabIndex = 0;
			this._txtCommon_0.Text = "";
			// this.this._txtCommon_0.Watermark = "";
			// this.this._txtCommon_0.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommon_DropButtonClick);
			// this._txtCommon_0.Leave += new System.EventHandler(this.txtCommon_Leave);
			// 
			// _txtCommon_1
			// 
			this._txtCommon_1.AllowDrop = true;
			this._txtCommon_1.BackColor = System.Drawing.Color.White;
			this._txtCommon_1.ForeColor = System.Drawing.Color.Black;
			this._txtCommon_1.Location = new System.Drawing.Point(144, 71);
			this._txtCommon_1.MaxLength = 250;
			this._txtCommon_1.Name = "_txtCommon_1";
			this._txtCommon_1.Size = new System.Drawing.Size(302, 19);
			this._txtCommon_1.TabIndex = 1;
			this._txtCommon_1.Text = "";
			// this.this._txtCommon_1.Watermark = "";
			// this.this._txtCommon_1.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommon_DropButtonClick);
			// this._txtCommon_1.Leave += new System.EventHandler(this.txtCommon_Leave);
			// 
			// _txtCommonDisplay_1
			// 
			this._txtCommonDisplay_1.AllowDrop = true;
			this._txtCommonDisplay_1.Location = new System.Drawing.Point(247, 134);
			this._txtCommonDisplay_1.Name = "_txtCommonDisplay_1";
			this._txtCommonDisplay_1.Size = new System.Drawing.Size(201, 19);
			this._txtCommonDisplay_1.TabIndex = 25;
			// 
			// _txtCommonDisplay_0
			// 
			this._txtCommonDisplay_0.AllowDrop = true;
			this._txtCommonDisplay_0.Location = new System.Drawing.Point(247, 113);
			this._txtCommonDisplay_0.Name = "_txtCommonDisplay_0";
			this._txtCommonDisplay_0.Size = new System.Drawing.Size(201, 19);
			this._txtCommonDisplay_0.TabIndex = 26;
			// 
			// Label7_1
			// 
			this.Label7_1.AllowDrop = true;
			this.Label7_1.BackColor = System.Drawing.Color.FromArgb(224, 230, 237);
			this.Label7_1.Text = "Tel. No.";
			this.Label7_1.ForeColor = System.Drawing.Color.Black;
			this.Label7_1.Location = new System.Drawing.Point(8, 179);
			this.Label7_1.Name = "Label7_1";
			this.Label7_1.Size = new System.Drawing.Size(38, 13);
			this.Label7_1.TabIndex = 27;
			// 
			// _txtCommon_10
			// 
			this._txtCommon_10.AllowDrop = true;
			this._txtCommon_10.BackColor = System.Drawing.Color.White;
			this._txtCommon_10.ForeColor = System.Drawing.Color.Black;
			this._txtCommon_10.Location = new System.Drawing.Point(144, 176);
			this._txtCommon_10.MaxLength = 30;
			this._txtCommon_10.Name = "_txtCommon_10";
			this._txtCommon_10.Size = new System.Drawing.Size(101, 19);
			this._txtCommon_10.TabIndex = 7;
			this._txtCommon_10.Text = "";
			// this.this._txtCommon_10.Watermark = "";
			// this.this._txtCommon_10.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommon_DropButtonClick);
			// this._txtCommon_10.Leave += new System.EventHandler(this.txtCommon_Leave);
			// 
			// Label6_1
			// 
			this.Label6_1.AllowDrop = true;
			this.Label6_1.BackColor = System.Drawing.Color.FromArgb(224, 230, 237);
			this.Label6_1.Text = "Address 1";
			this.Label6_1.ForeColor = System.Drawing.Color.Black;
			this.Label6_1.Location = new System.Drawing.Point(9, 221);
			this.Label6_1.Name = "Label6_1";
			this.Label6_1.Size = new System.Drawing.Size(47, 13);
			this.Label6_1.TabIndex = 28;
			// 
			// _txtCommon_11
			// 
			this._txtCommon_11.AllowDrop = true;
			this._txtCommon_11.BackColor = System.Drawing.Color.White;
			this._txtCommon_11.ForeColor = System.Drawing.Color.Black;
			this._txtCommon_11.Location = new System.Drawing.Point(144, 218);
			// this._txtCommon_11.mArabicEnabled = true;
			this._txtCommon_11.MaxLength = 100;
			this._txtCommon_11.Name = "_txtCommon_11";
			this._txtCommon_11.Size = new System.Drawing.Size(302, 19);
			this._txtCommon_11.TabIndex = 10;
			this._txtCommon_11.Text = "";
			// this.this._txtCommon_11.Watermark = "";
			// this.this._txtCommon_11.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommon_DropButtonClick);
			// this._txtCommon_11.Leave += new System.EventHandler(this.txtCommon_Leave);
			// 
			// Label6_2
			// 
			this.Label6_2.AllowDrop = true;
			this.Label6_2.BackColor = System.Drawing.Color.FromArgb(224, 230, 237);
			this.Label6_2.Text = "Address 2";
			this.Label6_2.ForeColor = System.Drawing.Color.Black;
			this.Label6_2.Location = new System.Drawing.Point(9, 242);
			this.Label6_2.Name = "Label6_2";
			this.Label6_2.Size = new System.Drawing.Size(47, 13);
			this.Label6_2.TabIndex = 29;
			// 
			// _txtCommon_12
			// 
			this._txtCommon_12.AllowDrop = true;
			this._txtCommon_12.BackColor = System.Drawing.Color.White;
			this._txtCommon_12.ForeColor = System.Drawing.Color.Black;
			this._txtCommon_12.Location = new System.Drawing.Point(144, 239);
			// this._txtCommon_12.mArabicEnabled = true;
			this._txtCommon_12.MaxLength = 100;
			this._txtCommon_12.Name = "_txtCommon_12";
			this._txtCommon_12.Size = new System.Drawing.Size(302, 19);
			this._txtCommon_12.TabIndex = 11;
			this._txtCommon_12.Text = "";
			// this.this._txtCommon_12.Watermark = "";
			// this.this._txtCommon_12.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommon_DropButtonClick);
			// this._txtCommon_12.Leave += new System.EventHandler(this.txtCommon_Leave);
			// 
			// Label6_3
			// 
			this.Label6_3.AllowDrop = true;
			this.Label6_3.BackColor = System.Drawing.Color.FromArgb(224, 230, 237);
			this.Label6_3.Text = "Email Id";
			this.Label6_3.ForeColor = System.Drawing.Color.Black;
			this.Label6_3.Location = new System.Drawing.Point(8, 263);
			this.Label6_3.Name = "Label6_3";
			this.Label6_3.Size = new System.Drawing.Size(37, 13);
			this.Label6_3.TabIndex = 30;
			// 
			// _txtCommon_13
			// 
			this._txtCommon_13.AllowDrop = true;
			this._txtCommon_13.BackColor = System.Drawing.Color.White;
			this._txtCommon_13.ForeColor = System.Drawing.Color.Black;
			this._txtCommon_13.Location = new System.Drawing.Point(144, 260);
			// this._txtCommon_13.mArabicEnabled = true;
			this._txtCommon_13.MaxLength = 50;
			this._txtCommon_13.Name = "_txtCommon_13";
			this._txtCommon_13.Size = new System.Drawing.Size(302, 19);
			this._txtCommon_13.TabIndex = 12;
			this._txtCommon_13.Text = "";
			// this.this._txtCommon_13.Watermark = "";
			// this.this._txtCommon_13.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommon_DropButtonClick);
			// this._txtCommon_13.Leave += new System.EventHandler(this.txtCommon_Leave);
			// 
			// Label6_4
			// 
			this.Label6_4.AllowDrop = true;
			this.Label6_4.BackColor = System.Drawing.Color.FromArgb(224, 230, 237);
			this.Label6_4.Text = "Website";
			this.Label6_4.ForeColor = System.Drawing.Color.Black;
			this.Label6_4.Location = new System.Drawing.Point(8, 284);
			this.Label6_4.Name = "Label6_4";
			this.Label6_4.Size = new System.Drawing.Size(39, 13);
			this.Label6_4.TabIndex = 31;
			// 
			// _txtCommon_14
			// 
			this._txtCommon_14.AllowDrop = true;
			this._txtCommon_14.BackColor = System.Drawing.Color.White;
			this._txtCommon_14.ForeColor = System.Drawing.Color.Black;
			this._txtCommon_14.Location = new System.Drawing.Point(144, 281);
			// this._txtCommon_14.mArabicEnabled = true;
			this._txtCommon_14.MaxLength = 50;
			this._txtCommon_14.Name = "_txtCommon_14";
			this._txtCommon_14.Size = new System.Drawing.Size(302, 19);
			this._txtCommon_14.TabIndex = 13;
			this._txtCommon_14.Text = "";
			// this.this._txtCommon_14.Watermark = "";
			// this.this._txtCommon_14.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommon_DropButtonClick);
			// this._txtCommon_14.Leave += new System.EventHandler(this.txtCommon_Leave);
			// 
			// frmRETenant
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.FromArgb(224, 230, 237);
			this.ClientSize = new System.Drawing.Size(459, 356);
			this.Controls.Add(this._txtCommon_4);
			this.Controls.Add(this._txtCommon_5);
			this.Controls.Add(this._txtCommon_3);
			this.Controls.Add(this._txtCommon_6);
			this.Controls.Add(this._txtCommon_8);
			this.Controls.Add(this.lblAssetsCode);
			this.Controls.Add(this.lblAssetsAdjustmentNo);
			this.Controls.Add(this.lblAssetsAdjustmentAccount);
			this.Controls.Add(this.Label1);
			this.Controls.Add(this.Label3);
			this.Controls.Add(this.Label4);
			this.Controls.Add(this.Label6_0);
			this.Controls.Add(this.Label7_0);
			this.Controls.Add(this._txtCommon_7);
			this.Controls.Add(this.lblComments);
			this.Controls.Add(this.Label5);
			this.Controls.Add(this._txtCommon_2);
			this.Controls.Add(this._txtCommon_9);
			this.Controls.Add(this._txtCommon_0);
			this.Controls.Add(this._txtCommon_1);
			this.Controls.Add(this._txtCommonDisplay_1);
			this.Controls.Add(this._txtCommonDisplay_0);
			this.Controls.Add(this.Label7_1);
			this.Controls.Add(this._txtCommon_10);
			this.Controls.Add(this.Label6_1);
			this.Controls.Add(this._txtCommon_11);
			this.Controls.Add(this.Label6_2);
			this.Controls.Add(this._txtCommon_12);
			this.Controls.Add(this.Label6_3);
			this.Controls.Add(this._txtCommon_13);
			this.Controls.Add(this.Label6_4);
			this.Controls.Add(this._txtCommon_14);
			//this.Icon = (System.Drawing.Icon) resources.GetObject("frmRETenant.Icon");
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(116, 148);
			this.MaximizeBox = true;
			this.MinimizeBox = true;
			this.Name = "frmRETenant";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Tenant";
			// this.Activated += new System.EventHandler(this.frmRETenant_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
			// this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
			this.ResumeLayout(false);
		}
		// 
		void InitializetxtCommonDisplay()
		{
			this.txtCommonDisplay = new System.Windows.Forms.Label[2];
			this.txtCommonDisplay[1] = _txtCommonDisplay_1;
			this.txtCommonDisplay[0] = _txtCommonDisplay_0;
		}
		void InitializetxtCommon()
		{
			this.txtCommon = new System.Windows.Forms.TextBox[15];
			this.txtCommon[4] = _txtCommon_4;
			this.txtCommon[5] = _txtCommon_5;
			this.txtCommon[3] = _txtCommon_3;
			this.txtCommon[6] = _txtCommon_6;
			this.txtCommon[8] = _txtCommon_8;
			this.txtCommon[7] = _txtCommon_7;
			this.txtCommon[2] = _txtCommon_2;
			this.txtCommon[9] = _txtCommon_9;
			this.txtCommon[0] = _txtCommon_0;
			this.txtCommon[1] = _txtCommon_1;
			this.txtCommon[10] = _txtCommon_10;
			this.txtCommon[11] = _txtCommon_11;
			this.txtCommon[12] = _txtCommon_12;
			this.txtCommon[13] = _txtCommon_13;
			this.txtCommon[14] = _txtCommon_14;
		}
		void InitializeSystem.Windows.Forms.Label7()
		{
			this.Label7 = new System.Windows.Forms.Label[2];
			this.Label7[0] = Label7_0;
			this.Label7[1] = Label7_1;
		}
		void InitializeSystem.Windows.Forms.Label6()
		{
			this.Label6 = new System.Windows.Forms.Label[5];
			this.Label6[0] = Label6_0;
			this.Label6[1] = Label6_1;
			this.Label6[2] = Label6_2;
			this.Label6[3] = Label6_3;
			this.Label6[4] = Label6_4;
		}
		#endregion
	}
}//ENDSHERE
