
namespace Xtreme
{
	partial class frmPayLeaveAdjustment
	{

		#region "Upgrade Support "
		private static frmPayLeaveAdjustment m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmPayLeaveAdjustment DefInstance
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
		public static frmPayLeaveAdjustment CreateInstance()
		{
			frmPayLeaveAdjustment theInstance = new frmPayLeaveAdjustment();
			
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
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "cmdLeaveAmount", "_txtCommonTextBox_2", "_lblCommonLabel_7", "_lblCommonLabel_5", "_lblCommonLabel_6", "_txtCommonDate_0", "_txtCommonTextBox_0", "_lblCommonLabel_2", "_lblCommonLabel_0", "_lblCommonLabel_1", "_lblCommonLabel_3", "_txtCommonNumber_0", "_lblCommonLabel_4", "_lblCommonLabel_16", "_lblCommonLabel_17", "System.Windows.Forms.Label12", "_txtCommonTextBox_4", "_txtCommonTextBox_3", "_lblCommonLabel_18", "_txtCommonTextBox_1", "_lblCommonLabel_9", "_txtCommonNumber_1", "_lblCommonLabel_8", "_lblCommonLabel_10", "_lblCommonLabel_11", "_txtDisplayLabel_11", "_txtDisplayLabel_10", "_txtDisplayLabel_5", "_txtDisplayLabel_9", "_txtDisplayLabel_6", "_txtDisplayLabel_7", "_txtDisplayLabel_8", "_txtDisplayLabel_4", "_txtDisplayLabel_3", "_txtDisplayLabel_2", "_txtDisplayLabel_1", "_txtDisplayLabel_0", "_lblCommonLabel_12", "_txtDisplayLabel_12", "_cmbCommon_0", "_lblCommonLabel_13", "_lblCommonLabel_14", "_txtDisplayLabel_13", "_lblCommonLabel_15", "_txtDisplayLabel_14", "_lblCommonLabel_19", "_txtCommonDate_2", "_lblCommonLabel_20", "_txtCommonDate_1", "cmbCommon", "lblCommonLabel", "txtCommonDate", "txtCommonNumber", "txtCommonTextBox", "txtDisplayLabel"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public System.Windows.Forms.Button cmdLeaveAmount;
		private System.Windows.Forms.TextBox _txtCommonTextBox_2;
		private System.Windows.Forms.Label _lblCommonLabel_7;
		private System.Windows.Forms.Label _lblCommonLabel_5;
		private System.Windows.Forms.Label _lblCommonLabel_6;
		private Syncfusion.WinForms.Input.SfDateTimeEdit _txtCommonDate_0;
		private System.Windows.Forms.TextBox _txtCommonTextBox_0;
		private System.Windows.Forms.Label _lblCommonLabel_2;
		private System.Windows.Forms.Label _lblCommonLabel_0;
		private System.Windows.Forms.Label _lblCommonLabel_1;
		private System.Windows.Forms.Label _lblCommonLabel_3;
		private System.Windows.Forms.TextBox _txtCommonNumber_0;
		private System.Windows.Forms.Label _lblCommonLabel_4;
		private System.Windows.Forms.Label _lblCommonLabel_16;
		private System.Windows.Forms.Label _lblCommonLabel_17;
		public System.Windows.Forms.Label Label12;
		private System.Windows.Forms.TextBox _txtCommonTextBox_4;
		private System.Windows.Forms.TextBox _txtCommonTextBox_3;
		private System.Windows.Forms.Label _lblCommonLabel_18;
		private System.Windows.Forms.TextBox _txtCommonTextBox_1;
		private System.Windows.Forms.Label _lblCommonLabel_9;
		private System.Windows.Forms.TextBox _txtCommonNumber_1;
		private System.Windows.Forms.Label _lblCommonLabel_8;
		private System.Windows.Forms.Label _lblCommonLabel_10;
		private System.Windows.Forms.Label _lblCommonLabel_11;
		private System.Windows.Forms.Label _txtDisplayLabel_11;
		private System.Windows.Forms.Label _txtDisplayLabel_10;
		private System.Windows.Forms.Label _txtDisplayLabel_5;
		private System.Windows.Forms.Label _txtDisplayLabel_9;
		private System.Windows.Forms.Label _txtDisplayLabel_6;
		private System.Windows.Forms.Label _txtDisplayLabel_7;
		private System.Windows.Forms.Label _txtDisplayLabel_8;
		private System.Windows.Forms.Label _txtDisplayLabel_4;
		private System.Windows.Forms.Label _txtDisplayLabel_3;
		private System.Windows.Forms.Label _txtDisplayLabel_2;
		private System.Windows.Forms.Label _txtDisplayLabel_1;
		private System.Windows.Forms.Label _txtDisplayLabel_0;
		private System.Windows.Forms.Label _lblCommonLabel_12;
		private System.Windows.Forms.Label _txtDisplayLabel_12;
		private System.Windows.Forms.ComboBox _cmbCommon_0;
		private System.Windows.Forms.Label _lblCommonLabel_13;
		private System.Windows.Forms.Label _lblCommonLabel_14;
		private System.Windows.Forms.Label _txtDisplayLabel_13;
		private System.Windows.Forms.Label _lblCommonLabel_15;
		private System.Windows.Forms.Label _txtDisplayLabel_14;
		private System.Windows.Forms.Label _lblCommonLabel_19;
		private Syncfusion.WinForms.Input.SfDateTimeEdit _txtCommonDate_2;
		private System.Windows.Forms.Label _lblCommonLabel_20;
		private Syncfusion.WinForms.Input.SfDateTimeEdit _txtCommonDate_1;
		public System.Windows.Forms.ComboBox[] cmbCommon = new System.Windows.Forms.ComboBox[1];
		public System.Windows.Forms.Label[] lblCommonLabel = new System.Windows.Forms.Label[21];
		public Syncfusion.WinForms.Input.SfDateTimeEdit[] txtCommonDate = new Syncfusion.WinForms.Input.SfDateTimeEdit[3];
		public System.Windows.Forms.TextBox[] txtCommonNumber = new System.Windows.Forms.TextBox[2];
		public System.Windows.Forms.TextBox[] txtCommonTextBox = new System.Windows.Forms.TextBox[5];
		public System.Windows.Forms.Label[] txtDisplayLabel = new System.Windows.Forms.Label[15];
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPayLeaveAdjustment));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this.cmdLeaveAmount = new System.Windows.Forms.Button();
			this._txtCommonTextBox_2 = new System.Windows.Forms.TextBox();
			this._lblCommonLabel_7 = new System.Windows.Forms.Label();
			this._lblCommonLabel_5 = new System.Windows.Forms.Label();
			this._lblCommonLabel_6 = new System.Windows.Forms.Label();
			this._txtCommonDate_0 = new Syncfusion.WinForms.Input.SfDateTimeEdit();
			this._txtCommonTextBox_0 = new System.Windows.Forms.TextBox();
			this._lblCommonLabel_2 = new System.Windows.Forms.Label();
			this._lblCommonLabel_0 = new System.Windows.Forms.Label();
			this._lblCommonLabel_1 = new System.Windows.Forms.Label();
			this._lblCommonLabel_3 = new System.Windows.Forms.Label();
			this._txtCommonNumber_0 = new System.Windows.Forms.TextBox();
			this._lblCommonLabel_4 = new System.Windows.Forms.Label();
			this._lblCommonLabel_16 = new System.Windows.Forms.Label();
			this._lblCommonLabel_17 = new System.Windows.Forms.Label();
			this.Label12 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_4 = new System.Windows.Forms.TextBox();
			this._txtCommonTextBox_3 = new System.Windows.Forms.TextBox();
			this._lblCommonLabel_18 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_1 = new System.Windows.Forms.TextBox();
			this._lblCommonLabel_9 = new System.Windows.Forms.Label();
			this._txtCommonNumber_1 = new System.Windows.Forms.TextBox();
			this._lblCommonLabel_8 = new System.Windows.Forms.Label();
			this._lblCommonLabel_10 = new System.Windows.Forms.Label();
			this._lblCommonLabel_11 = new System.Windows.Forms.Label();
			this._txtDisplayLabel_11 = new System.Windows.Forms.Label();
			this._txtDisplayLabel_10 = new System.Windows.Forms.Label();
			this._txtDisplayLabel_5 = new System.Windows.Forms.Label();
			this._txtDisplayLabel_9 = new System.Windows.Forms.Label();
			this._txtDisplayLabel_6 = new System.Windows.Forms.Label();
			this._txtDisplayLabel_7 = new System.Windows.Forms.Label();
			this._txtDisplayLabel_8 = new System.Windows.Forms.Label();
			this._txtDisplayLabel_4 = new System.Windows.Forms.Label();
			this._txtDisplayLabel_3 = new System.Windows.Forms.Label();
			this._txtDisplayLabel_2 = new System.Windows.Forms.Label();
			this._txtDisplayLabel_1 = new System.Windows.Forms.Label();
			this._txtDisplayLabel_0 = new System.Windows.Forms.Label();
			this._lblCommonLabel_12 = new System.Windows.Forms.Label();
			this._txtDisplayLabel_12 = new System.Windows.Forms.Label();
			this._cmbCommon_0 = new System.Windows.Forms.ComboBox();
			this._lblCommonLabel_13 = new System.Windows.Forms.Label();
			this._lblCommonLabel_14 = new System.Windows.Forms.Label();
			this._txtDisplayLabel_13 = new System.Windows.Forms.Label();
			this._lblCommonLabel_15 = new System.Windows.Forms.Label();
			this._txtDisplayLabel_14 = new System.Windows.Forms.Label();
			this._lblCommonLabel_19 = new System.Windows.Forms.Label();
			this._txtCommonDate_2 = new Syncfusion.WinForms.Input.SfDateTimeEdit();
			this._lblCommonLabel_20 = new System.Windows.Forms.Label();
			this._txtCommonDate_1 = new Syncfusion.WinForms.Input.SfDateTimeEdit();
			this.SuspendLayout();
			// 
			// cmdLeaveAmount
			// 
			this.cmdLeaveAmount.AllowDrop = true;
			this.cmdLeaveAmount.BackColor = System.Drawing.SystemColors.Control;
			this.cmdLeaveAmount.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdLeaveAmount.Location = new System.Drawing.Point(592, 294);
			this.cmdLeaveAmount.Name = "cmdLeaveAmount";
			this.cmdLeaveAmount.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdLeaveAmount.Size = new System.Drawing.Size(15, 21);
			this.cmdLeaveAmount.TabIndex = 11;
			this.cmdLeaveAmount.Text = "A";
			this.cmdLeaveAmount.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.cmdLeaveAmount.UseVisualStyleBackColor = false;
			this.cmdLeaveAmount.Visible = false;
			// this.cmdLeaveAmount.Click += new System.EventHandler(this.cmdLeaveAmount_Click);
			// 
			// _txtCommonTextBox_2
			// 
			this._txtCommonTextBox_2.AllowDrop = true;
			this._txtCommonTextBox_2.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_2.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_2.Location = new System.Drawing.Point(104, 71);
			this._txtCommonTextBox_2.MaxLength = 20;
			this._txtCommonTextBox_2.Name = "_txtCommonTextBox_2";
			this._txtCommonTextBox_2.Size = new System.Drawing.Size(102, 19);
			this._txtCommonTextBox_2.TabIndex = 2;
			this._txtCommonTextBox_2.Text = "";
			// this.this._txtCommonTextBox_2.Watermark = "";
			// this.this._txtCommonTextBox_2.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_2.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _lblCommonLabel_7
			// 
			this._lblCommonLabel_7.AllowDrop = true;
			this._lblCommonLabel_7.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_7.Text = "Reference No.";
			this._lblCommonLabel_7.Location = new System.Drawing.Point(10, 74);
			// // this._lblCommonLabel_7.mLabelId = 1964;
			this._lblCommonLabel_7.Name = "_lblCommonLabel_7";
			this._lblCommonLabel_7.Size = new System.Drawing.Size(70, 13);
			this._lblCommonLabel_7.TabIndex = 12;
			// 
			// _lblCommonLabel_5
			// 
			this._lblCommonLabel_5.AllowDrop = true;
			this._lblCommonLabel_5.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_5.Text = "Transaction No.";
			this._lblCommonLabel_5.Location = new System.Drawing.Point(10, 52);
			// // this._lblCommonLabel_5.mLabelId = 1744;
			this._lblCommonLabel_5.Name = "_lblCommonLabel_5";
			this._lblCommonLabel_5.Size = new System.Drawing.Size(76, 14);
			this._lblCommonLabel_5.TabIndex = 13;
			// 
			// _lblCommonLabel_6
			// 
			this._lblCommonLabel_6.AllowDrop = true;
			this._lblCommonLabel_6.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_6.Text = "Effective Date";
			this._lblCommonLabel_6.Location = new System.Drawing.Point(424, 52);
			// // this._lblCommonLabel_6.mLabelId = 2147;
			this._lblCommonLabel_6.Name = "_lblCommonLabel_6";
			this._lblCommonLabel_6.Size = new System.Drawing.Size(68, 14);
			this._lblCommonLabel_6.TabIndex = 14;
			// 
			// _txtCommonDate_0
			// 
			this._txtCommonDate_0.AllowDrop = true;
			// this._txtCommonDate_0.CheckDateRange = false;
			this._txtCommonDate_0.Location = new System.Drawing.Point(500, 50);
			// this._txtCommonDate_0.MaxDate = 2958465;
			// this._txtCommonDate_0.MinDate = 32874;
			this._txtCommonDate_0.Name = "_txtCommonDate_0";
			this._txtCommonDate_0.Size = new System.Drawing.Size(108, 19);
			this._txtCommonDate_0.TabIndex = 1;
			this._txtCommonDate_0.Text = "01-Mar-2012";
			// this._txtCommonDate_0.Value = 40969;
			// this.this._txtCommonDate_0.Change += new Syncfusion.WinForms.Input.SfDateTimeEdit.ChangeHandler(this.txtCommonDate_Change);
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
			// this.this._txtCommonTextBox_0.Watermark = "";
			// this.this._txtCommonTextBox_0.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_0.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _lblCommonLabel_2
			// 
			this._lblCommonLabel_2.AllowDrop = true;
			this._lblCommonLabel_2.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_2.Text = "Employee Code";
			this._lblCommonLabel_2.Location = new System.Drawing.Point(10, 106);
			// // this._lblCommonLabel_2.mLabelId = 236;
			this._lblCommonLabel_2.Name = "_lblCommonLabel_2";
			this._lblCommonLabel_2.Size = new System.Drawing.Size(74, 14);
			this._lblCommonLabel_2.TabIndex = 15;
			// 
			// _lblCommonLabel_0
			// 
			this._lblCommonLabel_0.AllowDrop = true;
			this._lblCommonLabel_0.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_0.Text = "Department Code";
			this._lblCommonLabel_0.Location = new System.Drawing.Point(10, 127);
			// // this._lblCommonLabel_0.mLabelId = 1973;
			this._lblCommonLabel_0.Name = "_lblCommonLabel_0";
			this._lblCommonLabel_0.Size = new System.Drawing.Size(83, 14);
			this._lblCommonLabel_0.TabIndex = 16;
			// 
			// _lblCommonLabel_1
			// 
			this._lblCommonLabel_1.AllowDrop = true;
			this._lblCommonLabel_1.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_1.Text = "Designation Code";
			this._lblCommonLabel_1.Location = new System.Drawing.Point(10, 148);
			// // this._lblCommonLabel_1.mLabelId = 1049;
			this._lblCommonLabel_1.Name = "_lblCommonLabel_1";
			this._lblCommonLabel_1.Size = new System.Drawing.Size(84, 14);
			this._lblCommonLabel_1.TabIndex = 17;
			// 
			// _lblCommonLabel_3
			// 
			this._lblCommonLabel_3.AllowDrop = true;
			this._lblCommonLabel_3.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_3.Text = "Basic Salary";
			this._lblCommonLabel_3.Location = new System.Drawing.Point(492, 7);
			// // this._lblCommonLabel_3.mLabelId = 1970;
			this._lblCommonLabel_3.Name = "_lblCommonLabel_3";
			this._lblCommonLabel_3.Size = new System.Drawing.Size(61, 14);
			this._lblCommonLabel_3.TabIndex = 18;
			this._lblCommonLabel_3.Visible = false;
			// 
			// _txtCommonNumber_0
			// 
			this._txtCommonNumber_0.AllowDrop = true;
			// this._txtCommonNumber_0.DisplayFormat = "####0.000###;;0.000;0.000";
			// this._txtCommonNumber_0.Format = "###########0.000";
			this._txtCommonNumber_0.Location = new System.Drawing.Point(307, 233);
			// this._txtCommonNumber_0.MaxValue = 2147483647;
			// this._txtCommonNumber_0.MinValue = -2147483648;
			this._txtCommonNumber_0.Name = "_txtCommonNumber_0";
			this._txtCommonNumber_0.Size = new System.Drawing.Size(101, 19);
			this._txtCommonNumber_0.TabIndex = 8;
			this._txtCommonNumber_0.Text = "0.000";
			// this.this._txtCommonNumber_0.Change += new System.Windows.Forms.TextBox.ChangeHandler(this.txtCommonNumber_Change);
			// 
			// _lblCommonLabel_4
			// 
			this._lblCommonLabel_4.AllowDrop = true;
			this._lblCommonLabel_4.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_4.Text = "Adjust Paid Days";
			this._lblCommonLabel_4.Location = new System.Drawing.Point(210, 235);
			// // this._lblCommonLabel_4.mLabelId = 1129;
			this._lblCommonLabel_4.Name = "_lblCommonLabel_4";
			this._lblCommonLabel_4.Size = new System.Drawing.Size(82, 14);
			this._lblCommonLabel_4.TabIndex = 19;
			// 
			// _lblCommonLabel_16
			// 
			this._lblCommonLabel_16.AllowDrop = true;
			this._lblCommonLabel_16.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_16.Text = "Total Paid Days";
			this._lblCommonLabel_16.Location = new System.Drawing.Point(412, 235);
			// // this._lblCommonLabel_16.mLabelId = 1130;
			this._lblCommonLabel_16.Name = "_lblCommonLabel_16";
			this._lblCommonLabel_16.Size = new System.Drawing.Size(74, 14);
			this._lblCommonLabel_16.TabIndex = 20;
			// 
			// _lblCommonLabel_17
			// 
			this._lblCommonLabel_17.AllowDrop = true;
			this._lblCommonLabel_17.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_17.Text = "Paid Days";
			this._lblCommonLabel_17.Location = new System.Drawing.Point(10, 235);
			// // this._lblCommonLabel_17.mLabelId = 1925;
			this._lblCommonLabel_17.Name = "_lblCommonLabel_17";
			this._lblCommonLabel_17.Size = new System.Drawing.Size(48, 14);
			this._lblCommonLabel_17.TabIndex = 21;
			// 
			// System.Windows.Forms.Label12
			// 
			this.Label12.AllowDrop = true;
			this.Label12.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.Label12.Text = "Comments";
			this.Label12.Location = new System.Drawing.Point(10, 298);
			// this.Label12.mLabelId = 1851;
			this.Label12.Name = "System.Windows.Forms.Label12";
			this.Label12.Size = new System.Drawing.Size(50, 14);
			this.Label12.TabIndex = 22;
			// 
			// _txtCommonTextBox_4
			// 
			this._txtCommonTextBox_4.AllowDrop = true;
			this._txtCommonTextBox_4.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_4.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_4.Location = new System.Drawing.Point(104, 296);
			this._txtCommonTextBox_4.MaxLength = 100;
			this._txtCommonTextBox_4.Name = "_txtCommonTextBox_4";
			this._txtCommonTextBox_4.Size = new System.Drawing.Size(506, 19);
			this._txtCommonTextBox_4.TabIndex = 10;
			this._txtCommonTextBox_4.Text = "";
			// this.this._txtCommonTextBox_4.Watermark = "";
			// this.this._txtCommonTextBox_4.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_4.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _txtCommonTextBox_3
			// 
			this._txtCommonTextBox_3.AllowDrop = true;
			this._txtCommonTextBox_3.BackColor = System.Drawing.Color.White;
			// this._txtCommonTextBox_3.bolNumericOnly = true;
			this._txtCommonTextBox_3.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_3.Location = new System.Drawing.Point(104, 188);
			this._txtCommonTextBox_3.MaxLength = 4;
			this._txtCommonTextBox_3.Name = "_txtCommonTextBox_3";
			// this._txtCommonTextBox_3.ShowButton = true;
			this._txtCommonTextBox_3.Size = new System.Drawing.Size(101, 19);
			this._txtCommonTextBox_3.TabIndex = 5;
			this._txtCommonTextBox_3.Text = "";
			// this.this._txtCommonTextBox_3.Watermark = "";
			// this.this._txtCommonTextBox_3.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_3.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _lblCommonLabel_18
			// 
			this._lblCommonLabel_18.AllowDrop = true;
			this._lblCommonLabel_18.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_18.Text = "Leave Code";
			this._lblCommonLabel_18.Location = new System.Drawing.Point(10, 190);
			// // this._lblCommonLabel_18.mLabelId = 1124;
			this._lblCommonLabel_18.Name = "_lblCommonLabel_18";
			this._lblCommonLabel_18.Size = new System.Drawing.Size(58, 14);
			this._lblCommonLabel_18.TabIndex = 23;
			// 
			// _txtCommonTextBox_1
			// 
			this._txtCommonTextBox_1.AllowDrop = true;
			this._txtCommonTextBox_1.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_1.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_1.Location = new System.Drawing.Point(104, 104);
			this._txtCommonTextBox_1.MaxLength = 25;
			this._txtCommonTextBox_1.Name = "_txtCommonTextBox_1";
			// this._txtCommonTextBox_1.ShowButton = true;
			this._txtCommonTextBox_1.Size = new System.Drawing.Size(101, 19);
			this._txtCommonTextBox_1.TabIndex = 3;
			this._txtCommonTextBox_1.Text = "";
			// this.this._txtCommonTextBox_1.Watermark = "";
			// this.this._txtCommonTextBox_1.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_1.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _lblCommonLabel_9
			// 
			this._lblCommonLabel_9.AllowDrop = true;
			this._lblCommonLabel_9.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_9.Text = "Total Salary";
			this._lblCommonLabel_9.Location = new System.Drawing.Point(492, 28);
			// // this._lblCommonLabel_9.mLabelId = 818;
			this._lblCommonLabel_9.Name = "_lblCommonLabel_9";
			this._lblCommonLabel_9.Size = new System.Drawing.Size(57, 14);
			this._lblCommonLabel_9.TabIndex = 24;
			this._lblCommonLabel_9.Visible = false;
			// 
			// _txtCommonNumber_1
			// 
			this._txtCommonNumber_1.AllowDrop = true;
			// this._txtCommonNumber_1.DisplayFormat = "####0.000###;;0.000;0.000";
			// this._txtCommonNumber_1.Format = "###########0.000";
			this._txtCommonNumber_1.Location = new System.Drawing.Point(307, 254);
			// this._txtCommonNumber_1.MaxValue = 2147483647;
			// this._txtCommonNumber_1.MinValue = -2147483648;
			this._txtCommonNumber_1.Name = "_txtCommonNumber_1";
			this._txtCommonNumber_1.Size = new System.Drawing.Size(101, 19);
			this._txtCommonNumber_1.TabIndex = 9;
			this._txtCommonNumber_1.Text = "0.000";
			// this.this._txtCommonNumber_1.Change += new System.Windows.Forms.TextBox.ChangeHandler(this.txtCommonNumber_Change);
			// 
			// _lblCommonLabel_8
			// 
			this._lblCommonLabel_8.AllowDrop = true;
			this._lblCommonLabel_8.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_8.Text = "Adjust UnPaid Days";
			this._lblCommonLabel_8.Location = new System.Drawing.Point(210, 256);
			// // this._lblCommonLabel_8.mLabelId = 1923;
			this._lblCommonLabel_8.Name = "_lblCommonLabel_8";
			this._lblCommonLabel_8.Size = new System.Drawing.Size(95, 14);
			this._lblCommonLabel_8.TabIndex = 25;
			// 
			// _lblCommonLabel_10
			// 
			this._lblCommonLabel_10.AllowDrop = true;
			this._lblCommonLabel_10.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_10.Text = "Total UnPaid Days";
			this._lblCommonLabel_10.Location = new System.Drawing.Point(412, 256);
			// // this._lblCommonLabel_10.mLabelId = 1924;
			this._lblCommonLabel_10.Name = "_lblCommonLabel_10";
			this._lblCommonLabel_10.Size = new System.Drawing.Size(87, 14);
			this._lblCommonLabel_10.TabIndex = 26;
			// 
			// _lblCommonLabel_11
			// 
			this._lblCommonLabel_11.AllowDrop = true;
			this._lblCommonLabel_11.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_11.Text = "UnPaid Days";
			this._lblCommonLabel_11.Location = new System.Drawing.Point(10, 256);
			// // this._lblCommonLabel_11.mLabelId = 1922;
			this._lblCommonLabel_11.Name = "_lblCommonLabel_11";
			this._lblCommonLabel_11.Size = new System.Drawing.Size(61, 14);
			this._lblCommonLabel_11.TabIndex = 27;
			// 
			// _txtDisplayLabel_11
			// 
			// this._txtDisplayLabel_11.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
			this._txtDisplayLabel_11.AllowDrop = true;
			this._txtDisplayLabel_11.Location = new System.Drawing.Point(501, 254);
			this._txtDisplayLabel_11.Name = "_txtDisplayLabel_11";
			this._txtDisplayLabel_11.Size = new System.Drawing.Size(107, 19);
			this._txtDisplayLabel_11.TabIndex = 28;
			this._txtDisplayLabel_11.TabStop = false;
			// 
			// _txtDisplayLabel_10
			// 
			// this._txtDisplayLabel_10.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
			this._txtDisplayLabel_10.AllowDrop = true;
			this._txtDisplayLabel_10.Location = new System.Drawing.Point(104, 254);
			this._txtDisplayLabel_10.Name = "_txtDisplayLabel_10";
			this._txtDisplayLabel_10.Size = new System.Drawing.Size(101, 19);
			this._txtDisplayLabel_10.TabIndex = 29;
			this._txtDisplayLabel_10.TabStop = false;
			// 
			// _txtDisplayLabel_5
			// 
			// this._txtDisplayLabel_5.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
			this._txtDisplayLabel_5.AllowDrop = true;
			this._txtDisplayLabel_5.Location = new System.Drawing.Point(577, 26);
			this._txtDisplayLabel_5.Name = "_txtDisplayLabel_5";
			this._txtDisplayLabel_5.Size = new System.Drawing.Size(11, 19);
			this._txtDisplayLabel_5.TabIndex = 30;
			this._txtDisplayLabel_5.Visible = false;
			// 
			// _txtDisplayLabel_9
			// 
			this._txtDisplayLabel_9.AllowDrop = true;
			this._txtDisplayLabel_9.Location = new System.Drawing.Point(207, 104);
			this._txtDisplayLabel_9.Name = "_txtDisplayLabel_9";
			this._txtDisplayLabel_9.Size = new System.Drawing.Size(401, 19);
			this._txtDisplayLabel_9.TabIndex = 31;
			this._txtDisplayLabel_9.TabStop = false;
			// 
			// _txtDisplayLabel_6
			// 
			this._txtDisplayLabel_6.AllowDrop = true;
			this._txtDisplayLabel_6.Location = new System.Drawing.Point(207, 188);
			this._txtDisplayLabel_6.Name = "_txtDisplayLabel_6";
			this._txtDisplayLabel_6.Size = new System.Drawing.Size(201, 19);
			this._txtDisplayLabel_6.TabIndex = 32;
			this._txtDisplayLabel_6.TabStop = false;
			// 
			// _txtDisplayLabel_7
			// 
			// this._txtDisplayLabel_7.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
			this._txtDisplayLabel_7.AllowDrop = true;
			this._txtDisplayLabel_7.Location = new System.Drawing.Point(104, 233);
			this._txtDisplayLabel_7.Name = "_txtDisplayLabel_7";
			this._txtDisplayLabel_7.Size = new System.Drawing.Size(101, 19);
			this._txtDisplayLabel_7.TabIndex = 33;
			this._txtDisplayLabel_7.TabStop = false;
			// 
			// _txtDisplayLabel_8
			// 
			// this._txtDisplayLabel_8.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
			this._txtDisplayLabel_8.AllowDrop = true;
			this._txtDisplayLabel_8.Location = new System.Drawing.Point(501, 233);
			this._txtDisplayLabel_8.Name = "_txtDisplayLabel_8";
			this._txtDisplayLabel_8.Size = new System.Drawing.Size(107, 19);
			this._txtDisplayLabel_8.TabIndex = 34;
			this._txtDisplayLabel_8.TabStop = false;
			// 
			// _txtDisplayLabel_4
			// 
			// this._txtDisplayLabel_4.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
			this._txtDisplayLabel_4.AllowDrop = true;
			this._txtDisplayLabel_4.Location = new System.Drawing.Point(577, 5);
			this._txtDisplayLabel_4.Name = "_txtDisplayLabel_4";
			this._txtDisplayLabel_4.Size = new System.Drawing.Size(11, 19);
			this._txtDisplayLabel_4.TabIndex = 35;
			this._txtDisplayLabel_4.Visible = false;
			// 
			// _txtDisplayLabel_3
			// 
			this._txtDisplayLabel_3.AllowDrop = true;
			this._txtDisplayLabel_3.Location = new System.Drawing.Point(207, 146);
			this._txtDisplayLabel_3.Name = "_txtDisplayLabel_3";
			this._txtDisplayLabel_3.Size = new System.Drawing.Size(201, 19);
			this._txtDisplayLabel_3.TabIndex = 36;
			this._txtDisplayLabel_3.TabStop = false;
			// 
			// _txtDisplayLabel_2
			// 
			this._txtDisplayLabel_2.AllowDrop = true;
			this._txtDisplayLabel_2.Location = new System.Drawing.Point(104, 146);
			this._txtDisplayLabel_2.Name = "_txtDisplayLabel_2";
			this._txtDisplayLabel_2.Size = new System.Drawing.Size(101, 19);
			this._txtDisplayLabel_2.TabIndex = 37;
			this._txtDisplayLabel_2.TabStop = false;
			// 
			// _txtDisplayLabel_1
			// 
			this._txtDisplayLabel_1.AllowDrop = true;
			this._txtDisplayLabel_1.Location = new System.Drawing.Point(207, 125);
			this._txtDisplayLabel_1.Name = "_txtDisplayLabel_1";
			this._txtDisplayLabel_1.Size = new System.Drawing.Size(201, 19);
			this._txtDisplayLabel_1.TabIndex = 38;
			this._txtDisplayLabel_1.TabStop = false;
			// 
			// _txtDisplayLabel_0
			// 
			this._txtDisplayLabel_0.AllowDrop = true;
			this._txtDisplayLabel_0.Location = new System.Drawing.Point(104, 125);
			this._txtDisplayLabel_0.Name = "_txtDisplayLabel_0";
			this._txtDisplayLabel_0.Size = new System.Drawing.Size(101, 19);
			this._txtDisplayLabel_0.TabIndex = 39;
			this._txtDisplayLabel_0.TabStop = false;
			// 
			// _lblCommonLabel_12
			// 
			this._lblCommonLabel_12.AllowDrop = true;
			this._lblCommonLabel_12.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_12.Text = "Leave Balance";
			this._lblCommonLabel_12.Location = new System.Drawing.Point(412, 214);
			// // this._lblCommonLabel_12.mLabelId = 1133;
			this._lblCommonLabel_12.Name = "_lblCommonLabel_12";
			this._lblCommonLabel_12.Size = new System.Drawing.Size(72, 14);
			this._lblCommonLabel_12.TabIndex = 40;
			// 
			// _txtDisplayLabel_12
			// 
			// this._txtDisplayLabel_12.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
			this._txtDisplayLabel_12.AllowDrop = true;
			this._txtDisplayLabel_12.Location = new System.Drawing.Point(501, 212);
			this._txtDisplayLabel_12.Name = "_txtDisplayLabel_12";
			this._txtDisplayLabel_12.Size = new System.Drawing.Size(107, 19);
			this._txtDisplayLabel_12.TabIndex = 41;
			this._txtDisplayLabel_12.TabStop = false;
			// 
			// _cmbCommon_0
			// 
			this._cmbCommon_0.AllowDrop = true;
			this._cmbCommon_0.Location = new System.Drawing.Point(501, 146);
			this._cmbCommon_0.Name = "_cmbCommon_0";
			this._cmbCommon_0.Size = new System.Drawing.Size(107, 21);
			this._cmbCommon_0.TabIndex = 4;
			// this._cmbCommon_0.Click += new System.Windows.Forms.ComboBox.ClickHandler(this.cmbCommon_Click);
			// 
			// _lblCommonLabel_13
			// 
			this._lblCommonLabel_13.AllowDrop = true;
			this._lblCommonLabel_13.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_13.Text = "Trans Type";
			this._lblCommonLabel_13.Location = new System.Drawing.Point(416, 149);
			// // this._lblCommonLabel_13.mLabelId = 2036;
			this._lblCommonLabel_13.Name = "_lblCommonLabel_13";
			this._lblCommonLabel_13.Size = new System.Drawing.Size(55, 14);
			this._lblCommonLabel_13.TabIndex = 42;
			// 
			// _lblCommonLabel_14
			// 
			this._lblCommonLabel_14.AllowDrop = true;
			this._lblCommonLabel_14.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_14.Text = "Leave Amount";
			this._lblCommonLabel_14.Location = new System.Drawing.Point(412, 277);
			// // this._lblCommonLabel_14.mLabelId = 2081;
			this._lblCommonLabel_14.Name = "_lblCommonLabel_14";
			this._lblCommonLabel_14.Size = new System.Drawing.Size(70, 14);
			this._lblCommonLabel_14.TabIndex = 43;
			// 
			// _txtDisplayLabel_13
			// 
			// this._txtDisplayLabel_13.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
			this._txtDisplayLabel_13.AllowDrop = true;
			this._txtDisplayLabel_13.Location = new System.Drawing.Point(501, 275);
			this._txtDisplayLabel_13.Name = "_txtDisplayLabel_13";
			this._txtDisplayLabel_13.Size = new System.Drawing.Size(107, 19);
			this._txtDisplayLabel_13.TabIndex = 44;
			this._txtDisplayLabel_13.TabStop = false;
			// 
			// _lblCommonLabel_15
			// 
			this._lblCommonLabel_15.AllowDrop = true;
			this._lblCommonLabel_15.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_15.Text = "Leave Salary";
			this._lblCommonLabel_15.Location = new System.Drawing.Point(414, 128);
			// // this._lblCommonLabel_15.mLabelId = 1135;
			this._lblCommonLabel_15.Name = "_lblCommonLabel_15";
			this._lblCommonLabel_15.Size = new System.Drawing.Size(64, 14);
			this._lblCommonLabel_15.TabIndex = 45;
			// 
			// _txtDisplayLabel_14
			// 
			// this._txtDisplayLabel_14.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
			this._txtDisplayLabel_14.AllowDrop = true;
			this._txtDisplayLabel_14.Location = new System.Drawing.Point(501, 126);
			this._txtDisplayLabel_14.Name = "_txtDisplayLabel_14";
			this._txtDisplayLabel_14.Size = new System.Drawing.Size(107, 19);
			this._txtDisplayLabel_14.TabIndex = 46;
			this._txtDisplayLabel_14.TabStop = false;
			// 
			// _lblCommonLabel_19
			// 
			this._lblCommonLabel_19.AllowDrop = true;
			this._lblCommonLabel_19.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_19.Text = "Leave To";
			this._lblCommonLabel_19.Location = new System.Drawing.Point(215, 212);
			// // this._lblCommonLabel_19.mLabelId = 375;
			this._lblCommonLabel_19.Name = "_lblCommonLabel_19";
			this._lblCommonLabel_19.Size = new System.Drawing.Size(45, 14);
			this._lblCommonLabel_19.TabIndex = 47;
			// 
			// _txtCommonDate_2
			// 
			this._txtCommonDate_2.AllowDrop = true;
			// this._txtCommonDate_2.CheckDateRange = false;
			this._txtCommonDate_2.Location = new System.Drawing.Point(307, 211);
			// this._txtCommonDate_2.MaxDate = 2958465;
			// this._txtCommonDate_2.MinDate = 36526;
			this._txtCommonDate_2.Name = "_txtCommonDate_2";
			this._txtCommonDate_2.Size = new System.Drawing.Size(102, 19);
			this._txtCommonDate_2.TabIndex = 7;
			this._txtCommonDate_2.Text = "01-Mar-2012";
			// this._txtCommonDate_2.Value = 40969;
			// this.this._txtCommonDate_2.Change += new Syncfusion.WinForms.Input.SfDateTimeEdit.ChangeHandler(this.txtCommonDate_Change);
			// 
			// _lblCommonLabel_20
			// 
			this._lblCommonLabel_20.AllowDrop = true;
			this._lblCommonLabel_20.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_20.Text = "Leave From";
			this._lblCommonLabel_20.Location = new System.Drawing.Point(9, 212);
			// // this._lblCommonLabel_20.mLabelId = 371;
			this._lblCommonLabel_20.Name = "_lblCommonLabel_20";
			this._lblCommonLabel_20.Size = new System.Drawing.Size(57, 14);
			this._lblCommonLabel_20.TabIndex = 48;
			// 
			// _txtCommonDate_1
			// 
			this._txtCommonDate_1.AllowDrop = true;
			// this._txtCommonDate_1.CheckDateRange = false;
			this._txtCommonDate_1.Location = new System.Drawing.Point(103, 210);
			// this._txtCommonDate_1.MaxDate = 2958465;
			// this._txtCommonDate_1.MinDate = 36526;
			this._txtCommonDate_1.Name = "_txtCommonDate_1";
			this._txtCommonDate_1.Size = new System.Drawing.Size(102, 19);
			this._txtCommonDate_1.TabIndex = 6;
			this._txtCommonDate_1.Text = "01-Mar-2012";
			// this._txtCommonDate_1.Value = 40969;
			// this.this._txtCommonDate_1.Change += new Syncfusion.WinForms.Input.SfDateTimeEdit.ChangeHandler(this.txtCommonDate_Change);
			// 
			// frmPayLeaveAdjustment
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.ClientSize = new System.Drawing.Size(612, 322);
			this.Controls.Add(this.cmdLeaveAmount);
			this.Controls.Add(this._txtCommonTextBox_2);
			this.Controls.Add(this._lblCommonLabel_7);
			this.Controls.Add(this._lblCommonLabel_5);
			this.Controls.Add(this._lblCommonLabel_6);
			this.Controls.Add(this._txtCommonDate_0);
			this.Controls.Add(this._txtCommonTextBox_0);
			this.Controls.Add(this._lblCommonLabel_2);
			this.Controls.Add(this._lblCommonLabel_0);
			this.Controls.Add(this._lblCommonLabel_1);
			this.Controls.Add(this._lblCommonLabel_3);
			this.Controls.Add(this._txtCommonNumber_0);
			this.Controls.Add(this._lblCommonLabel_4);
			this.Controls.Add(this._lblCommonLabel_16);
			this.Controls.Add(this._lblCommonLabel_17);
			this.Controls.Add(this.Label12);
			this.Controls.Add(this._txtCommonTextBox_4);
			this.Controls.Add(this._txtCommonTextBox_3);
			this.Controls.Add(this._lblCommonLabel_18);
			this.Controls.Add(this._txtCommonTextBox_1);
			this.Controls.Add(this._lblCommonLabel_9);
			this.Controls.Add(this._txtCommonNumber_1);
			this.Controls.Add(this._lblCommonLabel_8);
			this.Controls.Add(this._lblCommonLabel_10);
			this.Controls.Add(this._lblCommonLabel_11);
			this.Controls.Add(this._txtDisplayLabel_11);
			this.Controls.Add(this._txtDisplayLabel_10);
			this.Controls.Add(this._txtDisplayLabel_5);
			this.Controls.Add(this._txtDisplayLabel_9);
			this.Controls.Add(this._txtDisplayLabel_6);
			this.Controls.Add(this._txtDisplayLabel_7);
			this.Controls.Add(this._txtDisplayLabel_8);
			this.Controls.Add(this._txtDisplayLabel_4);
			this.Controls.Add(this._txtDisplayLabel_3);
			this.Controls.Add(this._txtDisplayLabel_2);
			this.Controls.Add(this._txtDisplayLabel_1);
			this.Controls.Add(this._txtDisplayLabel_0);
			this.Controls.Add(this._lblCommonLabel_12);
			this.Controls.Add(this._txtDisplayLabel_12);
			this.Controls.Add(this._cmbCommon_0);
			this.Controls.Add(this._lblCommonLabel_13);
			this.Controls.Add(this._lblCommonLabel_14);
			this.Controls.Add(this._txtDisplayLabel_13);
			this.Controls.Add(this._lblCommonLabel_15);
			this.Controls.Add(this._txtDisplayLabel_14);
			this.Controls.Add(this._lblCommonLabel_19);
			this.Controls.Add(this._txtCommonDate_2);
			this.Controls.Add(this._lblCommonLabel_20);
			this.Controls.Add(this._txtCommonDate_1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			//this.Icon = (System.Drawing.Icon) resources.GetObject("frmPayLeaveAdjustment.Icon");
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(262, 133);
			this.MaximizeBox = true;
			this.MinimizeBox = true;
			this.Name = "frmPayLeaveAdjustment";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Leave Adjustment";
			// this.Activated += new System.EventHandler(this.frmPayLeaveAdjustment_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
			// this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
			this.ResumeLayout(false);
		}
		// 
		void InitializetxtDisplayLabel()
		{
			this.txtDisplayLabel = new System.Windows.Forms.Label[15];
			this.txtDisplayLabel[11] = _txtDisplayLabel_11;
			this.txtDisplayLabel[10] = _txtDisplayLabel_10;
			this.txtDisplayLabel[5] = _txtDisplayLabel_5;
			this.txtDisplayLabel[9] = _txtDisplayLabel_9;
			this.txtDisplayLabel[6] = _txtDisplayLabel_6;
			this.txtDisplayLabel[7] = _txtDisplayLabel_7;
			this.txtDisplayLabel[8] = _txtDisplayLabel_8;
			this.txtDisplayLabel[4] = _txtDisplayLabel_4;
			this.txtDisplayLabel[3] = _txtDisplayLabel_3;
			this.txtDisplayLabel[2] = _txtDisplayLabel_2;
			this.txtDisplayLabel[1] = _txtDisplayLabel_1;
			this.txtDisplayLabel[0] = _txtDisplayLabel_0;
			this.txtDisplayLabel[12] = _txtDisplayLabel_12;
			this.txtDisplayLabel[13] = _txtDisplayLabel_13;
			this.txtDisplayLabel[14] = _txtDisplayLabel_14;
		}
		void InitializetxtCommonTextBox()
		{
			this.txtCommonTextBox = new System.Windows.Forms.TextBox[5];
			this.txtCommonTextBox[2] = _txtCommonTextBox_2;
			this.txtCommonTextBox[0] = _txtCommonTextBox_0;
			this.txtCommonTextBox[4] = _txtCommonTextBox_4;
			this.txtCommonTextBox[3] = _txtCommonTextBox_3;
			this.txtCommonTextBox[1] = _txtCommonTextBox_1;
		}
		void InitializetxtCommonNumber()
		{
			this.txtCommonNumber = new System.Windows.Forms.TextBox[2];
			this.txtCommonNumber[0] = _txtCommonNumber_0;
			this.txtCommonNumber[1] = _txtCommonNumber_1;
		}
		void InitializetxtCommonDate()
		{
			this.txtCommonDate = new Syncfusion.WinForms.Input.SfDateTimeEdit[3];
			this.txtCommonDate[0] = _txtCommonDate_0;
			this.txtCommonDate[2] = _txtCommonDate_2;
			this.txtCommonDate[1] = _txtCommonDate_1;
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
			this.lblCommonLabel[3] = _lblCommonLabel_3;
			this.lblCommonLabel[4] = _lblCommonLabel_4;
			this.lblCommonLabel[16] = _lblCommonLabel_16;
			this.lblCommonLabel[17] = _lblCommonLabel_17;
			this.lblCommonLabel[18] = _lblCommonLabel_18;
			this.lblCommonLabel[9] = _lblCommonLabel_9;
			this.lblCommonLabel[8] = _lblCommonLabel_8;
			this.lblCommonLabel[10] = _lblCommonLabel_10;
			this.lblCommonLabel[11] = _lblCommonLabel_11;
			this.lblCommonLabel[12] = _lblCommonLabel_12;
			this.lblCommonLabel[13] = _lblCommonLabel_13;
			this.lblCommonLabel[14] = _lblCommonLabel_14;
			this.lblCommonLabel[15] = _lblCommonLabel_15;
			this.lblCommonLabel[19] = _lblCommonLabel_19;
			this.lblCommonLabel[20] = _lblCommonLabel_20;
		}
		void InitializecmbCommon()
		{
			this.cmbCommon = new System.Windows.Forms.ComboBox[1];
			this.cmbCommon[0] = _cmbCommon_0;
		}
		#endregion
	}
}//ENDSHERE
