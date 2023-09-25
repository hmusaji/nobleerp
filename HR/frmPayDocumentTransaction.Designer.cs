
namespace Xtreme
{
	partial class frmPayDocumentTransaction
	{

		#region "Upgrade Support "
		private static frmPayDocumentTransaction m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmPayDocumentTransaction DefInstance
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
		public static frmPayDocumentTransaction CreateInstance()
		{
			frmPayDocumentTransaction theInstance = new frmPayDocumentTransaction();
			
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
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "cmbStatus", "_lblCommonLabel_7", "_lblCommonLabel_5", "_lblCommonLabel_6", "_txtCommonDate_0", "_txtCommonTextBox_0", "_lblCommonLabel_2", "_lblCommonLabel_0", "_lblCommonLabel_1", "System.Windows.Forms.Label12", "_txtCommonTextBox_4", "_lblCommonLabel_19", "_lblCommonLabel_20", "_lblCommonLabel_3", "_txtCommonTextBox_3", "_txtCommonDate_2", "_txtCommonDate_1", "_lblCommonLabel_4", "_lblCommonLabel_8", "_txtCommonDate_3", "_txtCommonTextBox_1", "_txtDisplayLabel_6", "_txtDisplayLabel_4", "_txtDisplayLabel_5", "_txtDisplayLabel_3", "_txtDisplayLabel_2", "_txtDisplayLabel_1", "_txtDisplayLabel_0", "lblCommonLabel", "txtCommonDate", "txtCommonTextBox", "txtDisplayLabel"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public System.Windows.Forms.ComboBox cmbStatus;
		private System.Windows.Forms.Label _lblCommonLabel_7;
		private System.Windows.Forms.Label _lblCommonLabel_5;
		private System.Windows.Forms.Label _lblCommonLabel_6;
		private Syncfusion.WinForms.Input.SfDateTimeEdit _txtCommonDate_0;
		private System.Windows.Forms.TextBox _txtCommonTextBox_0;
		private System.Windows.Forms.Label _lblCommonLabel_2;
		private System.Windows.Forms.Label _lblCommonLabel_0;
		private System.Windows.Forms.Label _lblCommonLabel_1;
		public System.Windows.Forms.Label System.Windows.Forms.Label12;
		private System.Windows.Forms.TextBox _txtCommonTextBox_4;
		private System.Windows.Forms.Label _lblCommonLabel_19;
		private System.Windows.Forms.Label _lblCommonLabel_20;
		private System.Windows.Forms.Label _lblCommonLabel_3;
		private System.Windows.Forms.TextBox _txtCommonTextBox_3;
		private Syncfusion.WinForms.Input.SfDateTimeEdit _txtCommonDate_2;
		private Syncfusion.WinForms.Input.SfDateTimeEdit _txtCommonDate_1;
		private System.Windows.Forms.Label _lblCommonLabel_4;
		private System.Windows.Forms.Label _lblCommonLabel_8;
		private Syncfusion.WinForms.Input.SfDateTimeEdit _txtCommonDate_3;
		private System.Windows.Forms.TextBox _txtCommonTextBox_1;
		private System.Windows.Forms.Label _txtDisplayLabel_6;
		private System.Windows.Forms.Label _txtDisplayLabel_4;
		private System.Windows.Forms.Label _txtDisplayLabel_5;
		private System.Windows.Forms.Label _txtDisplayLabel_3;
		private System.Windows.Forms.Label _txtDisplayLabel_2;
		private System.Windows.Forms.Label _txtDisplayLabel_1;
		private System.Windows.Forms.Label _txtDisplayLabel_0;
		public System.Windows.Forms.Label[] lblCommonLabel = new System.Windows.Forms.Label[21];
		public Syncfusion.WinForms.Input.SfDateTimeEdit[] txtCommonDate = new Syncfusion.WinForms.Input.SfDateTimeEdit[4];
		public System.Windows.Forms.TextBox[] txtCommonTextBox = new System.Windows.Forms.TextBox[5];
		public System.Windows.Forms.Label[] txtDisplayLabel = new System.Windows.Forms.Label[7];
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPayDocumentTransaction));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this.cmbStatus = new System.Windows.Forms.ComboBox();
			this._lblCommonLabel_7 = new System.Windows.Forms.Label();
			this._lblCommonLabel_5 = new System.Windows.Forms.Label();
			this._lblCommonLabel_6 = new System.Windows.Forms.Label();
			this._txtCommonDate_0 = new Syncfusion.WinForms.Input.SfDateTimeEdit();
			this._txtCommonTextBox_0 = new System.Windows.Forms.TextBox();
			this._lblCommonLabel_2 = new System.Windows.Forms.Label();
			this._lblCommonLabel_0 = new System.Windows.Forms.Label();
			this._lblCommonLabel_1 = new System.Windows.Forms.Label();
			this.System.Windows.Forms.Label12 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_4 = new System.Windows.Forms.TextBox();
			this._lblCommonLabel_19 = new System.Windows.Forms.Label();
			this._lblCommonLabel_20 = new System.Windows.Forms.Label();
			this._lblCommonLabel_3 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_3 = new System.Windows.Forms.TextBox();
			this._txtCommonDate_2 = new Syncfusion.WinForms.Input.SfDateTimeEdit();
			this._txtCommonDate_1 = new Syncfusion.WinForms.Input.SfDateTimeEdit();
			this._lblCommonLabel_4 = new System.Windows.Forms.Label();
			this._lblCommonLabel_8 = new System.Windows.Forms.Label();
			this._txtCommonDate_3 = new Syncfusion.WinForms.Input.SfDateTimeEdit();
			this._txtCommonTextBox_1 = new System.Windows.Forms.TextBox();
			this._txtDisplayLabel_6 = new System.Windows.Forms.Label();
			this._txtDisplayLabel_4 = new System.Windows.Forms.Label();
			this._txtDisplayLabel_5 = new System.Windows.Forms.Label();
			this._txtDisplayLabel_3 = new System.Windows.Forms.Label();
			this._txtDisplayLabel_2 = new System.Windows.Forms.Label();
			this._txtDisplayLabel_1 = new System.Windows.Forms.Label();
			this._txtDisplayLabel_0 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// cmbStatus
			// 
			this.cmbStatus.AllowDrop = true;
			this.cmbStatus.Location = new System.Drawing.Point(104, 209);
			this.cmbStatus.Name = "cmbStatus";
			this.cmbStatus.Size = new System.Drawing.Size(102, 21);
			this.cmbStatus.TabIndex = 4;
			// this.cmbStatus.Click += new System.Windows.Forms.ComboBox.ClickHandler(this.cmbStatus_Click);
			// 
			// _lblCommonLabel_7
			// 
			this._lblCommonLabel_7.AllowDrop = true;
			this._lblCommonLabel_7.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_7.Text = "Document No.";
			this._lblCommonLabel_7.Location = new System.Drawing.Point(10, 191);
			// this._lblCommonLabel_7.mLabelId = 1962;
			this._lblCommonLabel_7.Name = "_lblCommonLabel_7";
			this._lblCommonLabel_7.Size = new System.Drawing.Size(68, 13);
			this._lblCommonLabel_7.TabIndex = 9;
			// 
			// _lblCommonLabel_5
			// 
			this._lblCommonLabel_5.AllowDrop = true;
			this._lblCommonLabel_5.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_5.Text = "Transaction No.";
			this._lblCommonLabel_5.Location = new System.Drawing.Point(10, 53);
			// this._lblCommonLabel_5.mLabelId = 1744;
			this._lblCommonLabel_5.Name = "_lblCommonLabel_5";
			this._lblCommonLabel_5.Size = new System.Drawing.Size(76, 14);
			this._lblCommonLabel_5.TabIndex = 10;
			// 
			// _lblCommonLabel_6
			// 
			this._lblCommonLabel_6.AllowDrop = true;
			this._lblCommonLabel_6.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_6.Text = "Transaction Date";
			this._lblCommonLabel_6.Location = new System.Drawing.Point(10, 75);
			// this._lblCommonLabel_6.mLabelId = 1233;
			this._lblCommonLabel_6.Name = "_lblCommonLabel_6";
			this._lblCommonLabel_6.Size = new System.Drawing.Size(82, 14);
			this._lblCommonLabel_6.TabIndex = 11;
			// 
			// _txtCommonDate_0
			// 
			this._txtCommonDate_0.AllowDrop = true;
			// this._txtCommonDate_0.CheckDateRange = false;
			this._txtCommonDate_0.Location = new System.Drawing.Point(104, 72);
			// this._txtCommonDate_0.MaxDate = 2958465;
			// this._txtCommonDate_0.MinDate = 32874;
			this._txtCommonDate_0.Name = "_txtCommonDate_0";
			this._txtCommonDate_0.Size = new System.Drawing.Size(102, 19);
			this._txtCommonDate_0.TabIndex = 1;
			this._txtCommonDate_0.Text = "18/07/2001";
			this._txtCommonDate_0.Value = 37090;
			// 
			// _txtCommonTextBox_0
			// 
			this._txtCommonTextBox_0.AllowDrop = true;
			this._txtCommonTextBox_0.BackColor = System.Drawing.Color.White;
			// this._txtCommonTextBox_0.bolNumericOnly = true;
			this._txtCommonTextBox_0.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_0.Location = new System.Drawing.Point(104, 50);
			// this._txtCommonTextBox_0.mDropDownType = System.Windows.Forms.TextBox.DropDownTypes.ddtNextNumber;
			this._txtCommonTextBox_0.Name = "_txtCommonTextBox_0";
			// this._txtCommonTextBox_0.ShowButton = true;
			this._txtCommonTextBox_0.Size = new System.Drawing.Size(102, 19);
			this._txtCommonTextBox_0.TabIndex = 0;
			this._txtCommonTextBox_0.Text = "";
			// this.this._txtCommonTextBox_0.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_0.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _lblCommonLabel_2
			// 
			this._lblCommonLabel_2.AllowDrop = true;
			this._lblCommonLabel_2.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_2.Text = "Employee Code";
			this._lblCommonLabel_2.Location = new System.Drawing.Point(10, 107);
			// this._lblCommonLabel_2.mLabelId = 236;
			this._lblCommonLabel_2.Name = "_lblCommonLabel_2";
			this._lblCommonLabel_2.Size = new System.Drawing.Size(74, 14);
			this._lblCommonLabel_2.TabIndex = 12;
			// 
			// _lblCommonLabel_0
			// 
			this._lblCommonLabel_0.AllowDrop = true;
			this._lblCommonLabel_0.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_0.Text = "Department Code";
			this._lblCommonLabel_0.Location = new System.Drawing.Point(10, 128);
			// this._lblCommonLabel_0.mLabelId = 1973;
			this._lblCommonLabel_0.Name = "_lblCommonLabel_0";
			this._lblCommonLabel_0.Size = new System.Drawing.Size(83, 14);
			this._lblCommonLabel_0.TabIndex = 13;
			// 
			// _lblCommonLabel_1
			// 
			this._lblCommonLabel_1.AllowDrop = true;
			this._lblCommonLabel_1.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_1.Text = "Designation Code";
			this._lblCommonLabel_1.Location = new System.Drawing.Point(10, 149);
			// this._lblCommonLabel_1.mLabelId = 1049;
			this._lblCommonLabel_1.Name = "_lblCommonLabel_1";
			this._lblCommonLabel_1.Size = new System.Drawing.Size(84, 14);
			this._lblCommonLabel_1.TabIndex = 14;
			// 
			// System.Windows.Forms.Label12
			// 
			this.System.Windows.Forms.Label12.AllowDrop = true;
			this.System.Windows.Forms.Label12.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.System.Windows.Forms.Label12.Caption = "Comments";
			this.System.Windows.Forms.Label12.Location = new System.Drawing.Point(10, 277);
			this.System.Windows.Forms.Label12.mLabelId = 1851;
			this.System.Windows.Forms.Label12.Name = "System.Windows.Forms.Label12";
			this.System.Windows.Forms.Label12.Size = new System.Drawing.Size(50, 14);
			this.System.Windows.Forms.Label12.TabIndex = 15;
			// 
			// _txtCommonTextBox_4
			// 
			this._txtCommonTextBox_4.AllowDrop = true;
			this._txtCommonTextBox_4.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_4.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_4.Location = new System.Drawing.Point(104, 274);
			this._txtCommonTextBox_4.MaxLength = 100;
			this._txtCommonTextBox_4.Name = "_txtCommonTextBox_4";
			this._txtCommonTextBox_4.Size = new System.Drawing.Size(384, 19);
			this._txtCommonTextBox_4.TabIndex = 8;
			this._txtCommonTextBox_4.Text = "";
			// this.this._txtCommonTextBox_4.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_4.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _lblCommonLabel_19
			// 
			this._lblCommonLabel_19.AllowDrop = true;
			this._lblCommonLabel_19.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_19.Text = "Return Date";
			this._lblCommonLabel_19.Location = new System.Drawing.Point(276, 235);
			// this._lblCommonLabel_19.mLabelId = 1800;
			this._lblCommonLabel_19.Name = "_lblCommonLabel_19";
			this._lblCommonLabel_19.Size = new System.Drawing.Size(57, 14);
			this._lblCommonLabel_19.TabIndex = 16;
			// 
			// _lblCommonLabel_20
			// 
			this._lblCommonLabel_20.AllowDrop = true;
			this._lblCommonLabel_20.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_20.Text = "Delivery Date";
			this._lblCommonLabel_20.Location = new System.Drawing.Point(10, 235);
			// this._lblCommonLabel_20.mLabelId = 1965;
			this._lblCommonLabel_20.Name = "_lblCommonLabel_20";
			this._lblCommonLabel_20.Size = new System.Drawing.Size(64, 14);
			this._lblCommonLabel_20.TabIndex = 17;
			// 
			// _lblCommonLabel_3
			// 
			this._lblCommonLabel_3.AllowDrop = true;
			this._lblCommonLabel_3.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_3.Text = "Document Code";
			this._lblCommonLabel_3.Location = new System.Drawing.Point(10, 170);
			// this._lblCommonLabel_3.mLabelId = 1961;
			this._lblCommonLabel_3.Name = "_lblCommonLabel_3";
			this._lblCommonLabel_3.Size = new System.Drawing.Size(76, 14);
			this._lblCommonLabel_3.TabIndex = 18;
			// 
			// _txtCommonTextBox_3
			// 
			this._txtCommonTextBox_3.AllowDrop = true;
			this._txtCommonTextBox_3.BackColor = System.Drawing.Color.White;
			// this._txtCommonTextBox_3.bolNumericOnly = true;
			this._txtCommonTextBox_3.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_3.Location = new System.Drawing.Point(104, 167);
			this._txtCommonTextBox_3.MaxLength = 4;
			this._txtCommonTextBox_3.Name = "_txtCommonTextBox_3";
			// this._txtCommonTextBox_3.ShowButton = true;
			this._txtCommonTextBox_3.Size = new System.Drawing.Size(101, 19);
			this._txtCommonTextBox_3.TabIndex = 3;
			this._txtCommonTextBox_3.Text = "";
			// this.this._txtCommonTextBox_3.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_3.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _txtCommonDate_2
			// 
			this._txtCommonDate_2.AllowDrop = true;
			// this._txtCommonDate_2.CheckDateRange = false;
			this._txtCommonDate_2.Location = new System.Drawing.Point(384, 233);
			// this._txtCommonDate_2.MaxDate = 2958465;
			// this._txtCommonDate_2.MinDate = 32874;
			this._txtCommonDate_2.Name = "_txtCommonDate_2";
			this._txtCommonDate_2.Size = new System.Drawing.Size(102, 19);
			this._txtCommonDate_2.TabIndex = 6;
			this._txtCommonDate_2.Text = "18/07/2001";
			this._txtCommonDate_2.Value = 37090;
			// 
			// _txtCommonDate_1
			// 
			this._txtCommonDate_1.AllowDrop = true;
			// this._txtCommonDate_1.CheckDateRange = false;
			this._txtCommonDate_1.Location = new System.Drawing.Point(104, 232);
			// this._txtCommonDate_1.MaxDate = 2958465;
			// this._txtCommonDate_1.MinDate = 32874;
			this._txtCommonDate_1.Name = "_txtCommonDate_1";
			this._txtCommonDate_1.Size = new System.Drawing.Size(102, 19);
			this._txtCommonDate_1.TabIndex = 5;
			this._txtCommonDate_1.Text = "18/07/2001";
			this._txtCommonDate_1.Value = 37090;
			// 
			// _lblCommonLabel_4
			// 
			this._lblCommonLabel_4.AllowDrop = true;
			this._lblCommonLabel_4.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_4.Text = "Status";
			this._lblCommonLabel_4.Location = new System.Drawing.Point(10, 212);
			// this._lblCommonLabel_4.mLabelId = 1834;
			this._lblCommonLabel_4.Name = "_lblCommonLabel_4";
			this._lblCommonLabel_4.Size = new System.Drawing.Size(31, 13);
			this._lblCommonLabel_4.TabIndex = 19;
			// 
			// _lblCommonLabel_8
			// 
			this._lblCommonLabel_8.AllowDrop = true;
			this._lblCommonLabel_8.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_8.Text = "Actual Return Date";
			this._lblCommonLabel_8.Location = new System.Drawing.Point(10, 256);
			// this._lblCommonLabel_8.mLabelId = 1987;
			this._lblCommonLabel_8.Name = "_lblCommonLabel_8";
			this._lblCommonLabel_8.Size = new System.Drawing.Size(91, 14);
			this._lblCommonLabel_8.TabIndex = 20;
			this._lblCommonLabel_8.Visible = false;
			// 
			// _txtCommonDate_3
			// 
			this._txtCommonDate_3.AllowDrop = true;
			// this._txtCommonDate_3.CheckDateRange = false;
			this._txtCommonDate_3.Location = new System.Drawing.Point(104, 253);
			// this._txtCommonDate_3.MaxDate = 2958465;
			// this._txtCommonDate_3.MinDate = 32874;
			this._txtCommonDate_3.Name = "_txtCommonDate_3";
			this._txtCommonDate_3.Size = new System.Drawing.Size(102, 19);
			this._txtCommonDate_3.TabIndex = 7;
			this._txtCommonDate_3.Text = "18/07/2001";
			this._txtCommonDate_3.Value = 37090;
			this._txtCommonDate_3.Visible = false;
			// 
			// _txtCommonTextBox_1
			// 
			this._txtCommonTextBox_1.AllowDrop = true;
			this._txtCommonTextBox_1.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_1.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_1.Location = new System.Drawing.Point(104, 104);
			this._txtCommonTextBox_1.MaxLength = 10;
			this._txtCommonTextBox_1.Name = "_txtCommonTextBox_1";
			// this._txtCommonTextBox_1.ShowButton = true;
			this._txtCommonTextBox_1.Size = new System.Drawing.Size(101, 19);
			this._txtCommonTextBox_1.TabIndex = 2;
			this._txtCommonTextBox_1.Text = "";
			// this.this._txtCommonTextBox_1.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_1.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _txtDisplayLabel_6
			// 
			this._txtDisplayLabel_6.AllowDrop = true;
			this._txtDisplayLabel_6.Location = new System.Drawing.Point(104, 188);
			this._txtDisplayLabel_6.Name = "_txtDisplayLabel_6";
			this._txtDisplayLabel_6.Size = new System.Drawing.Size(101, 19);
			this._txtDisplayLabel_6.TabIndex = 21;
			// 
			// _txtDisplayLabel_4
			// 
			this._txtDisplayLabel_4.AllowDrop = true;
			this._txtDisplayLabel_4.Location = new System.Drawing.Point(207, 167);
			this._txtDisplayLabel_4.Name = "_txtDisplayLabel_4";
			this._txtDisplayLabel_4.Size = new System.Drawing.Size(279, 19);
			this._txtDisplayLabel_4.TabIndex = 22;
			// 
			// _txtDisplayLabel_5
			// 
			this._txtDisplayLabel_5.AllowDrop = true;
			this._txtDisplayLabel_5.Location = new System.Drawing.Point(207, 104);
			this._txtDisplayLabel_5.Name = "_txtDisplayLabel_5";
			this._txtDisplayLabel_5.Size = new System.Drawing.Size(279, 19);
			this._txtDisplayLabel_5.TabIndex = 23;
			// 
			// _txtDisplayLabel_3
			// 
			this._txtDisplayLabel_3.AllowDrop = true;
			this._txtDisplayLabel_3.Location = new System.Drawing.Point(207, 146);
			this._txtDisplayLabel_3.Name = "_txtDisplayLabel_3";
			this._txtDisplayLabel_3.Size = new System.Drawing.Size(279, 19);
			this._txtDisplayLabel_3.TabIndex = 24;
			// 
			// _txtDisplayLabel_2
			// 
			this._txtDisplayLabel_2.AllowDrop = true;
			this._txtDisplayLabel_2.Location = new System.Drawing.Point(104, 146);
			this._txtDisplayLabel_2.Name = "_txtDisplayLabel_2";
			this._txtDisplayLabel_2.Size = new System.Drawing.Size(101, 19);
			this._txtDisplayLabel_2.TabIndex = 25;
			// 
			// _txtDisplayLabel_1
			// 
			this._txtDisplayLabel_1.AllowDrop = true;
			this._txtDisplayLabel_1.Location = new System.Drawing.Point(207, 125);
			this._txtDisplayLabel_1.Name = "_txtDisplayLabel_1";
			this._txtDisplayLabel_1.Size = new System.Drawing.Size(279, 19);
			this._txtDisplayLabel_1.TabIndex = 26;
			// 
			// _txtDisplayLabel_0
			// 
			this._txtDisplayLabel_0.AllowDrop = true;
			this._txtDisplayLabel_0.Location = new System.Drawing.Point(104, 125);
			this._txtDisplayLabel_0.Name = "_txtDisplayLabel_0";
			this._txtDisplayLabel_0.Size = new System.Drawing.Size(101, 19);
			this._txtDisplayLabel_0.TabIndex = 27;
			// 
			// frmPayDocumentTransaction
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.ClientSize = new System.Drawing.Size(511, 308);
			this.Controls.Add(this.cmbStatus);
			this.Controls.Add(this._lblCommonLabel_7);
			this.Controls.Add(this._lblCommonLabel_5);
			this.Controls.Add(this._lblCommonLabel_6);
			this.Controls.Add(this._txtCommonDate_0);
			this.Controls.Add(this._txtCommonTextBox_0);
			this.Controls.Add(this._lblCommonLabel_2);
			this.Controls.Add(this._lblCommonLabel_0);
			this.Controls.Add(this._lblCommonLabel_1);
			this.Controls.Add(this.System.Windows.Forms.Label12);
			this.Controls.Add(this._txtCommonTextBox_4);
			this.Controls.Add(this._lblCommonLabel_19);
			this.Controls.Add(this._lblCommonLabel_20);
			this.Controls.Add(this._lblCommonLabel_3);
			this.Controls.Add(this._txtCommonTextBox_3);
			this.Controls.Add(this._txtCommonDate_2);
			this.Controls.Add(this._txtCommonDate_1);
			this.Controls.Add(this._lblCommonLabel_4);
			this.Controls.Add(this._lblCommonLabel_8);
			this.Controls.Add(this._txtCommonDate_3);
			this.Controls.Add(this._txtCommonTextBox_1);
			this.Controls.Add(this._txtDisplayLabel_6);
			this.Controls.Add(this._txtDisplayLabel_4);
			this.Controls.Add(this._txtDisplayLabel_5);
			this.Controls.Add(this._txtDisplayLabel_3);
			this.Controls.Add(this._txtDisplayLabel_2);
			this.Controls.Add(this._txtDisplayLabel_1);
			this.Controls.Add(this._txtDisplayLabel_0);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			//this.Icon = (System.Drawing.Icon) resources.GetObject("frmPayDocumentTransaction.Icon");
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(317, 91);
			this.MaximizeBox = true;
			this.MinimizeBox = true;
			this.Name = "frmPayDocumentTransaction";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Document Transaction";
			// this.Activated += new System.EventHandler(this.frmPayDocumentTransaction_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
			// this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
			this.ResumeLayout(false);
		}
		void ReLoadForm(bool addEvents)
		{
			InitializetxtDisplayLabel();
			InitializetxtCommonTextBox();
			InitializetxtCommonDate();
			InitializelblCommonLabel();
			//This form is an MDI child.
			//This code simulates the VB6 
			// functionality of automatically
			// loading and showing an MDI
			// child's parent.
			this.MdiParent = Xtreme.frmSysMain.DefInstance;
			Xtreme.frmSysMain.DefInstance.Show();
		}
		void InitializetxtDisplayLabel()
		{
			this.txtDisplayLabel = new System.Windows.Forms.Label[7];
			this.txtDisplayLabel[6] = _txtDisplayLabel_6;
			this.txtDisplayLabel[4] = _txtDisplayLabel_4;
			this.txtDisplayLabel[5] = _txtDisplayLabel_5;
			this.txtDisplayLabel[3] = _txtDisplayLabel_3;
			this.txtDisplayLabel[2] = _txtDisplayLabel_2;
			this.txtDisplayLabel[1] = _txtDisplayLabel_1;
			this.txtDisplayLabel[0] = _txtDisplayLabel_0;
		}
		void InitializetxtCommonTextBox()
		{
			this.txtCommonTextBox = new System.Windows.Forms.TextBox[5];
			this.txtCommonTextBox[0] = _txtCommonTextBox_0;
			this.txtCommonTextBox[4] = _txtCommonTextBox_4;
			this.txtCommonTextBox[3] = _txtCommonTextBox_3;
			this.txtCommonTextBox[1] = _txtCommonTextBox_1;
		}
		void InitializetxtCommonDate()
		{
			this.txtCommonDate = new Syncfusion.WinForms.Input.SfDateTimeEdit[4];
			this.txtCommonDate[0] = _txtCommonDate_0;
			this.txtCommonDate[2] = _txtCommonDate_2;
			this.txtCommonDate[1] = _txtCommonDate_1;
			this.txtCommonDate[3] = _txtCommonDate_3;
		}
		void InitializelblCommonLabel()
		{
			this.lblCommonLabel = new System.Windows.Forms.Label[21];
			this.lblCommonLabel[7] = _lblCommonLabel_7;
			this.lblCommonLabel[5] = _lblCommonLabel_5;
			this.lblCommonLabel[6] = _lblCommonLabel_6;
			this.lblCommonLabel[2] = _lblCommonLabel_2;
			this.lblCommonLabel[0] = _lblCommonLabel_0;
			this.lblCommonLabel[1] = _lblCommonLabel_1;
			this.lblCommonLabel[19] = _lblCommonLabel_19;
			this.lblCommonLabel[20] = _lblCommonLabel_20;
			this.lblCommonLabel[3] = _lblCommonLabel_3;
			this.lblCommonLabel[4] = _lblCommonLabel_4;
			this.lblCommonLabel[8] = _lblCommonLabel_8;
		}
		#endregion
	}
}