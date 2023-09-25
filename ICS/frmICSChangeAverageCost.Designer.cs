
namespace Xtreme
{
	partial class frmICSChangeAverageCost
	{

		#region "Upgrade Support "
		private static frmICSChangeAverageCost m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmICSChangeAverageCost DefInstance
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
		public static frmICSChangeAverageCost CreateInstance()
		{
			frmICSChangeAverageCost theInstance = new frmICSChangeAverageCost();
			
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
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "cmdPostMode", "picPostMode", "_lblCommon_3", "_lblCommon_4", "txtTransactionDate", "_txtCommon_1", "_lblCommon_5", "_txtCommon_2", "_lblCommon_7", "_txtCommon_3", "_txtCommonName_3", "_txtCommonName_2", "_txtCommonName_1", "fraCommon", "cmdOKCancel", "_txtNCommon_0", "_txtCommon_0", "_lblCommon_2", "_lblCommon_1", "_lblCommon_0", "_txtNCommon_1", "_lblCommon_6", "_txtNCommon_2", "_lblCommon_8", "_txtCommonName_0", "Line1", "lblCommon", "txtCommon", "txtCommonName", "txtNCommon"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public AxSmartNetButtonProject.AxSmartNetButton cmdPostMode;
		public System.Windows.Forms.PictureBox picPostMode;
		private System.Windows.Forms.Label _lblCommon_3;
		private System.Windows.Forms.Label _lblCommon_4;
		public Syncfusion.WinForms.Input.SfDateTimeEdit txtTransactionDate;
		private System.Windows.Forms.TextBox _txtCommon_1;
		private System.Windows.Forms.Label _lblCommon_5;
		private System.Windows.Forms.TextBox _txtCommon_2;
		private System.Windows.Forms.Label _lblCommon_7;
		private System.Windows.Forms.TextBox _txtCommon_3;
		private System.Windows.Forms.Label _txtCommonName_3;
		private System.Windows.Forms.Label _txtCommonName_2;
		private System.Windows.Forms.Label _txtCommonName_1;
		public System.Windows.Forms.Panel fraCommon;
		public UCOkCancel cmdOKCancel;
		private System.Windows.Forms.TextBox _txtNCommon_0;
		private System.Windows.Forms.TextBox _txtCommon_0;
		private System.Windows.Forms.Label _lblCommon_2;
		private System.Windows.Forms.Label _lblCommon_1;
		private System.Windows.Forms.Label _lblCommon_0;
		private System.Windows.Forms.TextBox _txtNCommon_1;
		private System.Windows.Forms.Label _lblCommon_6;
		private System.Windows.Forms.TextBox _txtNCommon_2;
		private System.Windows.Forms.Label _lblCommon_8;
		private System.Windows.Forms.Label _txtCommonName_0;
		public System.Windows.Forms.Label Line1;
		public System.Windows.Forms.Label[] lblCommon = new System.Windows.Forms.Label[9];
		public System.Windows.Forms.TextBox[] txtCommon = new System.Windows.Forms.TextBox[4];
		public System.Windows.Forms.Label[] txtCommonName = new System.Windows.Forms.Label[4];
		public System.Windows.Forms.TextBox[] txtNCommon = new System.Windows.Forms.TextBox[3];
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmICSChangeAverageCost));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this.picPostMode = new System.Windows.Forms.PictureBox();
			this.cmdPostMode = new AxSmartNetButtonProject.AxSmartNetButton();
			this.fraCommon = new System.Windows.Forms.Panel();
			this._lblCommon_3 = new System.Windows.Forms.Label();
			this._lblCommon_4 = new System.Windows.Forms.Label();
			this.txtTransactionDate = new Syncfusion.WinForms.Input.SfDateTimeEdit();
			this._txtCommon_1 = new System.Windows.Forms.TextBox();
			this._lblCommon_5 = new System.Windows.Forms.Label();
			this._txtCommon_2 = new System.Windows.Forms.TextBox();
			this._lblCommon_7 = new System.Windows.Forms.Label();
			this._txtCommon_3 = new System.Windows.Forms.TextBox();
			this._txtCommonName_3 = new System.Windows.Forms.Label();
			this._txtCommonName_2 = new System.Windows.Forms.Label();
			this._txtCommonName_1 = new System.Windows.Forms.Label();
			this.cmdOKCancel = new UCOkCancel();
			this._txtNCommon_0 = new System.Windows.Forms.TextBox();
			this._txtCommon_0 = new System.Windows.Forms.TextBox();
			this._lblCommon_2 = new System.Windows.Forms.Label();
			this._lblCommon_1 = new System.Windows.Forms.Label();
			this._lblCommon_0 = new System.Windows.Forms.Label();
			this._txtNCommon_1 = new System.Windows.Forms.TextBox();
			this._lblCommon_6 = new System.Windows.Forms.Label();
			this._txtNCommon_2 = new System.Windows.Forms.TextBox();
			this._lblCommon_8 = new System.Windows.Forms.Label();
			this._txtCommonName_0 = new System.Windows.Forms.Label();
			this.Line1 = new System.Windows.Forms.Label();
			// //((System.ComponentModel.ISupportInitialize) this.cmdPostMode).BeginInit();
			this.picPostMode.SuspendLayout();
			this.fraCommon.SuspendLayout();
			this.SuspendLayout();
			// 
			// picPostMode
			// 
			this.picPostMode.AllowDrop = true;
			this.picPostMode.BackColor = System.Drawing.Color.Navy;
			this.picPostMode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.picPostMode.CausesValidation = true;
			this.picPostMode.Controls.Add(this.cmdPostMode);
			this.picPostMode.Dock = System.Windows.Forms.DockStyle.None;
			this.picPostMode.Enabled = true;
			this.picPostMode.Location = new System.Drawing.Point(8, 100);
			this.picPostMode.Name = "picPostMode";
			this.picPostMode.Size = new System.Drawing.Size(136, 31);
			this.picPostMode.TabIndex = 16;
			this.picPostMode.TabStop = false;
			this.picPostMode.Visible = true;
			// 
			// cmdPostMode
			// 
			this.cmdPostMode.AllowDrop = true;
			this.cmdPostMode.Location = new System.Drawing.Point(0, 0);
			this.cmdPostMode.Name = "cmdPostMode";
			("cmdPostMode.OcxState");
			this.cmdPostMode.Size = new System.Drawing.Size(134, 29);
			this.cmdPostMode.TabIndex = 3;
			this.cmdPostMode.AccessKeyPress += new AxSmartNetButtonProject.__SmartNetButton_AccessKeyPressEventHandler(this.cmdPostMode_AccessKeyPress);
			//// this.cmdPostMode.ClickEvent += new System.EventHandler(this.cmdPostMode_ClickEvent);
			// 
			// fraCommon
			// 
			this.fraCommon.AllowDrop = true;
			this.fraCommon.BackColor = System.Drawing.Color.FromArgb(239, 221, 211);
			this.fraCommon.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.fraCommon.Controls.Add(this._lblCommon_3);
			this.fraCommon.Controls.Add(this._lblCommon_4);
			this.fraCommon.Controls.Add(this.txtTransactionDate);
			this.fraCommon.Controls.Add(this._txtCommon_1);
			this.fraCommon.Controls.Add(this._lblCommon_5);
			this.fraCommon.Controls.Add(this._txtCommon_2);
			this.fraCommon.Controls.Add(this._lblCommon_7);
			this.fraCommon.Controls.Add(this._txtCommon_3);
			this.fraCommon.Controls.Add(this._txtCommonName_3);
			this.fraCommon.Controls.Add(this._txtCommonName_2);
			this.fraCommon.Controls.Add(this._txtCommonName_1);
			this.fraCommon.Enabled = true;
			this.fraCommon.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Italic | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 178);
			this.fraCommon.ForeColor = System.Drawing.SystemColors.WindowText;
			this.fraCommon.Location = new System.Drawing.Point(4, 162);
			this.fraCommon.Name = "fraCommon";
			this.fraCommon.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.fraCommon.Size = new System.Drawing.Size(501, 109);
			this.fraCommon.TabIndex = 12;
			this.fraCommon.Visible = true;
			// 
			// _lblCommon_3
			// 
			this._lblCommon_3.AllowDrop = true;
			this._lblCommon_3.BackColor = System.Drawing.SystemColors.Window;
			this._lblCommon_3.Text = "Transaction Date";
			this._lblCommon_3.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_3.Location = new System.Drawing.Point(4, 19);
			this._lblCommon_3.Name = "_lblCommon_3";
			this._lblCommon_3.Size = new System.Drawing.Size(82, 13);
			this._lblCommon_3.TabIndex = 13;
			// 
			// _lblCommon_4
			// 
			this._lblCommon_4.AllowDrop = true;
			this._lblCommon_4.BackColor = System.Drawing.SystemColors.Window;
			this._lblCommon_4.Text = "Location Code";
			this._lblCommon_4.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_4.Location = new System.Drawing.Point(4, 40);
			this._lblCommon_4.Name = "_lblCommon_4";
			this._lblCommon_4.Size = new System.Drawing.Size(68, 13);
			this._lblCommon_4.TabIndex = 14;
			// 
			// txtTransactionDate
			// 
			this.txtTransactionDate.AllowDrop = true;
			this.txtTransactionDate.Location = new System.Drawing.Point(122, 16);
			// this.txtTransactionDate.MaxDate = 2958465;
			// this.txtTransactionDate.MinDate = 2;
			this.txtTransactionDate.Name = "txtTransactionDate";
			this.txtTransactionDate.Size = new System.Drawing.Size(101, 19);
			this.txtTransactionDate.TabIndex = 5;
			this.txtTransactionDate.Text = "05/01/2005";
			this.txtTransactionDate.Value = 38357;
			// 
			// _txtCommon_1
			// 
			this._txtCommon_1.AllowDrop = true;
			this._txtCommon_1.BackColor = System.Drawing.Color.White;
			// this._txtCommon_1.bolNumericOnly = true;
			this._txtCommon_1.ForeColor = System.Drawing.Color.Black;
			this._txtCommon_1.Location = new System.Drawing.Point(122, 37);
			this._txtCommon_1.Name = "_txtCommon_1";
			// this._txtCommon_1.ShowButton = true;
			this._txtCommon_1.Size = new System.Drawing.Size(101, 19);
			this._txtCommon_1.TabIndex = 6;
			this._txtCommon_1.Text = "";
			// this._txtCommon_1.Click += new System.Windows.Forms.TextBox.ClickHandler(this.txtCommon_Click);
			// this.this._txtCommon_1.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommon_DropButtonClick);
			// this._txtCommon_1.Leave += new System.EventHandler(this.txtCommon_Leave);
			// 
			// _lblCommon_5
			// 
			this._lblCommon_5.AllowDrop = true;
			this._lblCommon_5.BackColor = System.Drawing.SystemColors.Window;
			this._lblCommon_5.Text = "Adj. Voucher (- Qty)";
			this._lblCommon_5.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_5.Location = new System.Drawing.Point(4, 61);
			this._lblCommon_5.Name = "_lblCommon_5";
			this._lblCommon_5.Size = new System.Drawing.Size(98, 13);
			this._lblCommon_5.TabIndex = 17;
			// 
			// _txtCommon_2
			// 
			this._txtCommon_2.AllowDrop = true;
			this._txtCommon_2.BackColor = System.Drawing.Color.FromArgb(239, 239, 239);
			// this._txtCommon_2.bolNumericOnly = true;
			this._txtCommon_2.Enabled = false;
			this._txtCommon_2.ForeColor = System.Drawing.Color.Black;
			this._txtCommon_2.Location = new System.Drawing.Point(122, 58);
			this._txtCommon_2.Name = "_txtCommon_2";
			// this._txtCommon_2.ShowButton = true;
			this._txtCommon_2.Size = new System.Drawing.Size(101, 19);
			this._txtCommon_2.TabIndex = 7;
			this._txtCommon_2.Text = "";
			// this._txtCommon_2.Click += new System.Windows.Forms.TextBox.ClickHandler(this.txtCommon_Click);
			// this.this._txtCommon_2.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommon_DropButtonClick);
			// this._txtCommon_2.Leave += new System.EventHandler(this.txtCommon_Leave);
			// 
			// _lblCommon_7
			// 
			this._lblCommon_7.AllowDrop = true;
			this._lblCommon_7.BackColor = System.Drawing.SystemColors.Window;
			this._lblCommon_7.Text = "Adj. Voucher (+ Qty)";
			this._lblCommon_7.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_7.Location = new System.Drawing.Point(4, 82);
			this._lblCommon_7.Name = "_lblCommon_7";
			this._lblCommon_7.Size = new System.Drawing.Size(102, 13);
			this._lblCommon_7.TabIndex = 18;
			// 
			// _txtCommon_3
			// 
			this._txtCommon_3.AllowDrop = true;
			this._txtCommon_3.BackColor = System.Drawing.Color.FromArgb(239, 239, 239);
			// this._txtCommon_3.bolNumericOnly = true;
			this._txtCommon_3.Enabled = false;
			this._txtCommon_3.ForeColor = System.Drawing.Color.Black;
			this._txtCommon_3.Location = new System.Drawing.Point(122, 79);
			this._txtCommon_3.Name = "_txtCommon_3";
			// this._txtCommon_3.ShowButton = true;
			this._txtCommon_3.Size = new System.Drawing.Size(101, 19);
			this._txtCommon_3.TabIndex = 8;
			this._txtCommon_3.Text = "";
			// this._txtCommon_3.Click += new System.Windows.Forms.TextBox.ClickHandler(this.txtCommon_Click);
			// this.this._txtCommon_3.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommon_DropButtonClick);
			// this._txtCommon_3.Leave += new System.EventHandler(this.txtCommon_Leave);
			// 
			// _txtCommonName_3
			// 
			this._txtCommonName_3.AllowDrop = true;
			this._txtCommonName_3.Location = new System.Drawing.Point(225, 79);
			this._txtCommonName_3.Name = "_txtCommonName_3";
			this._txtCommonName_3.Size = new System.Drawing.Size(201, 19);
			this._txtCommonName_3.TabIndex = 21;
			// 
			// _txtCommonName_2
			// 
			this._txtCommonName_2.AllowDrop = true;
			this._txtCommonName_2.Location = new System.Drawing.Point(225, 58);
			this._txtCommonName_2.Name = "_txtCommonName_2";
			this._txtCommonName_2.Size = new System.Drawing.Size(201, 19);
			this._txtCommonName_2.TabIndex = 22;
			// 
			// _txtCommonName_1
			// 
			this._txtCommonName_1.AllowDrop = true;
			this._txtCommonName_1.Location = new System.Drawing.Point(225, 37);
			this._txtCommonName_1.Name = "_txtCommonName_1";
			this._txtCommonName_1.Size = new System.Drawing.Size(201, 19);
			this._txtCommonName_1.TabIndex = 23;
			// 
			// cmdOKCancel
			// 
			this.cmdOKCancel.AllowDrop = true;
			this.cmdOKCancel.DisplayButton = 0;
			this.cmdOKCancel.Location = new System.Drawing.Point(223, 100);
			this.cmdOKCancel.Name = "cmdOKCancel";
			this.cmdOKCancel.OkCaption = "&Ok";
			this.cmdOKCancel.Size = new System.Drawing.Size(206, 31);
			this.cmdOKCancel.TabIndex = 4;
			this.cmdOKCancel.CancelClick += new UCOkCancel.CancelClickHandler(this.cmdOKCancel_CancelClick);
			this.cmdOKCancel.OKClick += new UCOkCancel.OKClickHandler(this.cmdOKCancel_OKClick);
			// 
			// _txtNCommon_0
			// 
			this._txtNCommon_0.AllowDrop = true;
			this._txtNCommon_0.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			// this._txtNCommon_0.DisplayFormat = "####0.000###;;0.000;0.000";
			this._txtNCommon_0.Enabled = false;
			// this._txtNCommon_0.Format = "###########0.000";
			this._txtNCommon_0.Location = new System.Drawing.Point(125, 37);
			// this._txtNCommon_0.MaxValue = 2147483647;
			// this._txtNCommon_0.MinValue = 0;
			this._txtNCommon_0.Name = "_txtNCommon_0";
			this._txtNCommon_0.Size = new System.Drawing.Size(101, 19);
			this._txtNCommon_0.TabIndex = 1;
			this._txtNCommon_0.Text = "0.000";
			// 
			// _txtCommon_0
			// 
			this._txtCommon_0.AllowDrop = true;
			this._txtCommon_0.BackColor = System.Drawing.Color.White;
			this._txtCommon_0.ForeColor = System.Drawing.Color.Black;
			this._txtCommon_0.Location = new System.Drawing.Point(125, 16);
			this._txtCommon_0.Name = "_txtCommon_0";
			// this._txtCommon_0.ShowButton = true;
			this._txtCommon_0.Size = new System.Drawing.Size(101, 19);
			this._txtCommon_0.TabIndex = 0;
			this._txtCommon_0.Text = "";
			// this._txtCommon_0.Click += new System.Windows.Forms.TextBox.ClickHandler(this.txtCommon_Click);
			// this.this._txtCommon_0.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommon_DropButtonClick);
			// this._txtCommon_0.Leave += new System.EventHandler(this.txtCommon_Leave);
			// 
			// _lblCommon_2
			// 
			this._lblCommon_2.AllowDrop = true;
			this._lblCommon_2.BackColor = System.Drawing.SystemColors.Window;
			this._lblCommon_2.Text = "New Average Cost";
			this._lblCommon_2.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_2.Location = new System.Drawing.Point(8, 61);
			this._lblCommon_2.Name = "_lblCommon_2";
			this._lblCommon_2.Size = new System.Drawing.Size(90, 13);
			this._lblCommon_2.TabIndex = 9;
			// 
			// _lblCommon_1
			// 
			this._lblCommon_1.AllowDrop = true;
			this._lblCommon_1.BackColor = System.Drawing.SystemColors.Window;
			this._lblCommon_1.Text = "Current Average Cost";
			this._lblCommon_1.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_1.Location = new System.Drawing.Point(8, 40);
			this._lblCommon_1.Name = "_lblCommon_1";
			this._lblCommon_1.Size = new System.Drawing.Size(106, 14);
			this._lblCommon_1.TabIndex = 10;
			// 
			// _lblCommon_0
			// 
			this._lblCommon_0.AllowDrop = true;
			this._lblCommon_0.BackColor = System.Drawing.SystemColors.Window;
			this._lblCommon_0.Text = "Product Code";
			this._lblCommon_0.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_0.Location = new System.Drawing.Point(8, 19);
			// this._lblCommon_0.mLabelId = 545;
			this._lblCommon_0.Name = "_lblCommon_0";
			this._lblCommon_0.Size = new System.Drawing.Size(65, 14);
			this._lblCommon_0.TabIndex = 11;
			// 
			// _txtNCommon_1
			// 
			this._txtNCommon_1.AllowDrop = true;
			// this._txtNCommon_1.DisplayFormat = "####0.000###;;0.000;0.000";
			// this._txtNCommon_1.Format = "###########0.000";
			this._txtNCommon_1.Location = new System.Drawing.Point(125, 58);
			// this._txtNCommon_1.MaxValue = 2147483647;
			// this._txtNCommon_1.MinValue = 0;
			this._txtNCommon_1.Name = "_txtNCommon_1";
			this._txtNCommon_1.Size = new System.Drawing.Size(101, 19);
			this._txtNCommon_1.TabIndex = 2;
			this._txtNCommon_1.Text = "0.000";
			// 
			// _lblCommon_6
			// 
			this._lblCommon_6.AllowDrop = true;
			this._lblCommon_6.BackColor = System.Drawing.SystemColors.Window;
			this._lblCommon_6.Text = " Transation Details  ";
			this._lblCommon_6.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_6.Location = new System.Drawing.Point(4, 148);
			this._lblCommon_6.Name = "_lblCommon_6";
			this._lblCommon_6.Size = new System.Drawing.Size(95, 13);
			this._lblCommon_6.TabIndex = 15;
			// 
			// _txtNCommon_2
			// 
			this._txtNCommon_2.AllowDrop = true;
			this._txtNCommon_2.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			// this._txtNCommon_2.DisplayFormat = "####0.000###;;0.000;0.000";
			this._txtNCommon_2.Enabled = false;
			// this._txtNCommon_2.Format = "###########0.000";
			this._txtNCommon_2.Location = new System.Drawing.Point(328, 37);
			// this._txtNCommon_2.MaxValue = 2147483647;
			// this._txtNCommon_2.MinValue = 0;
			this._txtNCommon_2.Name = "_txtNCommon_2";
			this._txtNCommon_2.Size = new System.Drawing.Size(101, 19);
			this._txtNCommon_2.TabIndex = 19;
			this._txtNCommon_2.Text = "0.000";
			// 
			// _lblCommon_8
			// 
			this._lblCommon_8.AllowDrop = true;
			this._lblCommon_8.BackColor = System.Drawing.SystemColors.Window;
			this._lblCommon_8.Text = "Current Qty";
			this._lblCommon_8.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_8.Location = new System.Drawing.Point(256, 40);
			this._lblCommon_8.Name = "_lblCommon_8";
			this._lblCommon_8.Size = new System.Drawing.Size(56, 14);
			this._lblCommon_8.TabIndex = 20;
			// 
			// _txtCommonName_0
			// 
			this._txtCommonName_0.AllowDrop = true;
			this._txtCommonName_0.Location = new System.Drawing.Point(228, 16);
			this._txtCommonName_0.Name = "_txtCommonName_0";
			this._txtCommonName_0.Size = new System.Drawing.Size(201, 19);
			this._txtCommonName_0.TabIndex = 24;
			// 
			// Line1
			// 
			this.Line1.AllowDrop = true;
			this.Line1.BackColor = System.Drawing.SystemColors.WindowText;
			this.Line1.Enabled = false;
			this.Line1.Location = new System.Drawing.Point(98, 156);
			this.Line1.Name = "Line1";
			this.Line1.Size = new System.Drawing.Size(430, 1);
			this.Line1.Visible = true;
			// 
			// frmICSChangeAverageCost
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.FromArgb(239, 221, 211);
			this.ClientSize = new System.Drawing.Size(443, 273);
			this.Controls.Add(this.picPostMode);
			this.Controls.Add(this.fraCommon);
			this.Controls.Add(this.cmdOKCancel);
			this.Controls.Add(this._txtNCommon_0);
			this.Controls.Add(this._txtCommon_0);
			this.Controls.Add(this._lblCommon_2);
			this.Controls.Add(this._lblCommon_1);
			this.Controls.Add(this._lblCommon_0);
			this.Controls.Add(this._txtNCommon_1);
			this.Controls.Add(this._lblCommon_6);
			this.Controls.Add(this._txtNCommon_2);
			this.Controls.Add(this._lblCommon_8);
			this.Controls.Add(this._txtCommonName_0);
			this.Controls.Add(this.Line1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			//this.Icon = (System.Drawing.Icon) resources.GetObject("frmICSChangeAverageCost.Icon");
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(198, 171);
			this.MaximizeBox = false;
			this.MinimizeBox = true;
			this.Name = "frmICSChangeAverageCost";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Change Average Cost";
			// this.Activated += new System.EventHandler(this.frmICSChangeAverageCost_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
			// this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
			//((System.ComponentModel.ISupportInitialize) this.cmdPostMode).EndInit();
			this.picPostMode.ResumeLayout(false);
			this.fraCommon.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		void ReLoadForm(bool addEvents)
		{
			InitializetxtNCommon();
			InitializetxtCommonName();
			InitializetxtCommon();
			InitializelblCommon();
			//This form is an MDI child.
			//This code simulates the VB6 
			// functionality of automatically
			// loading and showing an MDI
			// child's parent.
			this.MdiParent = Xtreme.frmSysMain.DefInstance;
			Xtreme.frmSysMain.DefInstance.Show();
		}
		void InitializetxtNCommon()
		{
			this.txtNCommon = new System.Windows.Forms.TextBox[3];
			this.txtNCommon[0] = _txtNCommon_0;
			this.txtNCommon[1] = _txtNCommon_1;
			this.txtNCommon[2] = _txtNCommon_2;
		}
		void InitializetxtCommonName()
		{
			this.txtCommonName = new System.Windows.Forms.Label[4];
			this.txtCommonName[3] = _txtCommonName_3;
			this.txtCommonName[2] = _txtCommonName_2;
			this.txtCommonName[1] = _txtCommonName_1;
			this.txtCommonName[0] = _txtCommonName_0;
		}
		void InitializetxtCommon()
		{
			this.txtCommon = new System.Windows.Forms.TextBox[4];
			this.txtCommon[1] = _txtCommon_1;
			this.txtCommon[2] = _txtCommon_2;
			this.txtCommon[3] = _txtCommon_3;
			this.txtCommon[0] = _txtCommon_0;
		}
		void InitializelblCommon()
		{
			this.lblCommon = new System.Windows.Forms.Label[9];
			this.lblCommon[3] = _lblCommon_3;
			this.lblCommon[4] = _lblCommon_4;
			this.lblCommon[5] = _lblCommon_5;
			this.lblCommon[7] = _lblCommon_7;
			this.lblCommon[2] = _lblCommon_2;
			this.lblCommon[1] = _lblCommon_1;
			this.lblCommon[0] = _lblCommon_0;
			this.lblCommon[6] = _lblCommon_6;
			this.lblCommon[8] = _lblCommon_8;
		}
		#endregion
	}
}