
namespace Xtreme
{
	partial class frmPayPromotion
	{

		#region "Upgrade Support "
		private static frmPayPromotion m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmPayPromotion DefInstance
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
		public static frmPayPromotion CreateInstance()
		{
			frmPayPromotion theInstance = new frmPayPromotion();
			
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
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "_lblCommonLabel_3", "txtNewBasicSalary", "_lblCommonLabel_4", "_txtDisplayLabel_6", "frmBasicSalary", "_lblCommonLabel_1", "_txtCommonTextBox_4", "_lblCommonLabel_9", "_txtDisplayLabel_5", "_txtDisplayLabel_3", "_txtDisplayLabel_4", "frmDesignation", "_lblCommonLabel_0", "_txtCommonTextBox_3", "_lblCommonLabel_8", "_txtDisplayLabel_2", "_txtDisplayLabel_0", "_txtDisplayLabel_1", "frmDepartment", "_lblCommonLabel_7", "_lblCommonLabel_5", "_lblCommonLabel_6", "txtVoucherDate", "_txtCommonTextBox_0", "_txtCommonTextBox_1", "_lblCommonLabel_2", "System.Windows.Forms.Label12", "_txtCommonTextBox_5", "cmbPromotionType", "System.Windows.Forms.Label1", "_txtCommonTextBox_2", "_txtDisplayLabel_7", "lblCommonLabel", "txtCommonTextBox", "txtDisplayLabel"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		private System.Windows.Forms.Label _lblCommonLabel_3;
		public System.Windows.Forms.TextBox txtNewBasicSalary;
		private System.Windows.Forms.Label _lblCommonLabel_4;
		private System.Windows.Forms.Label _txtDisplayLabel_6;
		public System.Windows.Forms.GroupBox frmBasicSalary;
		private System.Windows.Forms.Label _lblCommonLabel_1;
		private System.Windows.Forms.TextBox _txtCommonTextBox_4;
		private System.Windows.Forms.Label _lblCommonLabel_9;
		private System.Windows.Forms.Label _txtDisplayLabel_5;
		private System.Windows.Forms.Label _txtDisplayLabel_3;
		private System.Windows.Forms.Label _txtDisplayLabel_4;
		public System.Windows.Forms.GroupBox frmDesignation;
		private System.Windows.Forms.Label _lblCommonLabel_0;
		private System.Windows.Forms.TextBox _txtCommonTextBox_3;
		private System.Windows.Forms.Label _lblCommonLabel_8;
		private System.Windows.Forms.Label _txtDisplayLabel_2;
		private System.Windows.Forms.Label _txtDisplayLabel_0;
		private System.Windows.Forms.Label _txtDisplayLabel_1;
		public System.Windows.Forms.GroupBox frmDepartment;
		private System.Windows.Forms.Label _lblCommonLabel_7;
		private System.Windows.Forms.Label _lblCommonLabel_5;
		private System.Windows.Forms.Label _lblCommonLabel_6;
		public Syncfusion.WinForms.Input.SfDateTimeEdit txtVoucherDate;
		private System.Windows.Forms.TextBox _txtCommonTextBox_0;
		private System.Windows.Forms.TextBox _txtCommonTextBox_1;
		private System.Windows.Forms.Label _lblCommonLabel_2;
		public System.Windows.Forms.Label Label12;
		private System.Windows.Forms.TextBox _txtCommonTextBox_5;
		public System.Windows.Forms.ComboBox cmbPromotionType;
		public System.Windows.Forms.Label Label1;
		private System.Windows.Forms.TextBox _txtCommonTextBox_2;
		private System.Windows.Forms.Label _txtDisplayLabel_7;
		public System.Windows.Forms.Label[] lblCommonLabel = new System.Windows.Forms.Label[10];
		public System.Windows.Forms.TextBox[] txtCommonTextBox = new System.Windows.Forms.TextBox[6];
		public System.Windows.Forms.Label[] txtDisplayLabel = new System.Windows.Forms.Label[8];
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPayPromotion));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this.frmBasicSalary = new System.Windows.Forms.GroupBox();
			this._lblCommonLabel_3 = new System.Windows.Forms.Label();
			this.txtNewBasicSalary = new System.Windows.Forms.TextBox();
			this._lblCommonLabel_4 = new System.Windows.Forms.Label();
			this._txtDisplayLabel_6 = new System.Windows.Forms.Label();
			this.frmDesignation = new System.Windows.Forms.GroupBox();
			this._lblCommonLabel_1 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_4 = new System.Windows.Forms.TextBox();
			this._lblCommonLabel_9 = new System.Windows.Forms.Label();
			this._txtDisplayLabel_5 = new System.Windows.Forms.Label();
			this._txtDisplayLabel_3 = new System.Windows.Forms.Label();
			this._txtDisplayLabel_4 = new System.Windows.Forms.Label();
			this.frmDepartment = new System.Windows.Forms.GroupBox();
			this._lblCommonLabel_0 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_3 = new System.Windows.Forms.TextBox();
			this._lblCommonLabel_8 = new System.Windows.Forms.Label();
			this._txtDisplayLabel_2 = new System.Windows.Forms.Label();
			this._txtDisplayLabel_0 = new System.Windows.Forms.Label();
			this._txtDisplayLabel_1 = new System.Windows.Forms.Label();
			this._lblCommonLabel_7 = new System.Windows.Forms.Label();
			this._lblCommonLabel_5 = new System.Windows.Forms.Label();
			this._lblCommonLabel_6 = new System.Windows.Forms.Label();
			this.txtVoucherDate = new Syncfusion.WinForms.Input.SfDateTimeEdit();
			this._txtCommonTextBox_0 = new System.Windows.Forms.TextBox();
			this._txtCommonTextBox_1 = new System.Windows.Forms.TextBox();
			this._lblCommonLabel_2 = new System.Windows.Forms.Label();
			this.Label12 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_5 = new System.Windows.Forms.TextBox();
			this.cmbPromotionType = new System.Windows.Forms.ComboBox();
			this.Label1 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_2 = new System.Windows.Forms.TextBox();
			this._txtDisplayLabel_7 = new System.Windows.Forms.Label();
			//this.frmBasicSalary.SuspendLayout();
			//this.frmDesignation.SuspendLayout();
			//this.frmDepartment.SuspendLayout();
			this.SuspendLayout();
			// 
			// frmBasicSalary
			// 
			//this.frmBasicSalary.AllowDrop = true;
			this.frmBasicSalary.BackColor = System.Drawing.Color.FromArgb(237, 231, 235);
			this.frmBasicSalary.Controls.Add(this._lblCommonLabel_3);
			this.frmBasicSalary.Controls.Add(this.txtNewBasicSalary);
			this.frmBasicSalary.Controls.Add(this._lblCommonLabel_4);
			this.frmBasicSalary.Controls.Add(this._txtDisplayLabel_6);
			this.frmBasicSalary.Enabled = true;
			this.frmBasicSalary.ForeColor = System.Drawing.SystemColors.ControlText;
			this.frmBasicSalary.Location = new System.Drawing.Point(8, 268);
			this.frmBasicSalary.Name = "frmBasicSalary";
			this.frmBasicSalary.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.frmBasicSalary.Size = new System.Drawing.Size(475, 37);
			this.frmBasicSalary.TabIndex = 19;
			this.frmBasicSalary.Text = " Basic Salary ";
			this.frmBasicSalary.Visible = false;
			// 
			// _lblCommonLabel_3
			// 
			//this._lblCommonLabel_3.AllowDrop = true;
			this._lblCommonLabel_3.BackColor = System.Drawing.Color.FromArgb(237, 231, 235);
			this._lblCommonLabel_3.Text = "Basic Salary";
			this._lblCommonLabel_3.Location = new System.Drawing.Point(12, 16);
			// // this._lblCommonLabel_3.mLabelId = 92;
			this._lblCommonLabel_3.Name = "_lblCommonLabel_3";
			this._lblCommonLabel_3.Size = new System.Drawing.Size(61, 14);
			this._lblCommonLabel_3.TabIndex = 20;
			// 
			// txtNewBasicSalary
			// 
			//this.txtNewBasicSalary.AllowDrop = true;
			// this.txtNewBasicSalary.DisplayFormat = "####0.000###;;0.000;0.000";
			// this.txtNewBasicSalary.Format = "###########0.000";
			this.txtNewBasicSalary.Location = new System.Drawing.Point(362, 12);
			// // = 2147483647;
			// // = 0;
			this.txtNewBasicSalary.Name = "txtNewBasicSalary";
			this.txtNewBasicSalary.Size = new System.Drawing.Size(101, 19);
			this.txtNewBasicSalary.TabIndex = 6;
			this.txtNewBasicSalary.Text = "0.000";
			// 
			// _lblCommonLabel_4
			// 
			//this._lblCommonLabel_4.AllowDrop = true;
			this._lblCommonLabel_4.BackColor = System.Drawing.Color.FromArgb(237, 231, 235);
			this._lblCommonLabel_4.Text = "New Basic Salary";
			this._lblCommonLabel_4.Location = new System.Drawing.Point(266, 14);
			// // this._lblCommonLabel_4.mLabelId = 1227;
			this._lblCommonLabel_4.Name = "_lblCommonLabel_4";
			this._lblCommonLabel_4.Size = new System.Drawing.Size(87, 14);
			this._lblCommonLabel_4.TabIndex = 21;
			// 
			// _txtDisplayLabel_6
			// 
			// //this._txtDisplayLabel_6.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
			//this._txtDisplayLabel_6.AllowDrop = true;
			this._txtDisplayLabel_6.Location = new System.Drawing.Point(116, 12);
			this._txtDisplayLabel_6.Name = "_txtDisplayLabel_6";
			this._txtDisplayLabel_6.Size = new System.Drawing.Size(101, 19);
			this._txtDisplayLabel_6.TabIndex = 23;
			// 
			// frmDesignation
			// 
			//this.frmDesignation.AllowDrop = true;
			this.frmDesignation.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.frmDesignation.Controls.Add(this._lblCommonLabel_1);
			this.frmDesignation.Controls.Add(this._txtCommonTextBox_4);
			this.frmDesignation.Controls.Add(this._lblCommonLabel_9);
			this.frmDesignation.Controls.Add(this._txtDisplayLabel_5);
			this.frmDesignation.Controls.Add(this._txtDisplayLabel_3);
			this.frmDesignation.Controls.Add(this._txtDisplayLabel_4);
			this.frmDesignation.Enabled = true;
			this.frmDesignation.ForeColor = System.Drawing.SystemColors.ControlText;
			this.frmDesignation.Location = new System.Drawing.Point(8, 175);
			this.frmDesignation.Name = "frmDesignation";
			this.frmDesignation.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.frmDesignation.Size = new System.Drawing.Size(475, 59);
			this.frmDesignation.TabIndex = 16;
			this.frmDesignation.Text = " Designation ";
			this.frmDesignation.Visible = true;
			// 
			// _lblCommonLabel_1
			// 
			//this._lblCommonLabel_1.AllowDrop = true;
			this._lblCommonLabel_1.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_1.Text = "Designation Code";
			this._lblCommonLabel_1.Location = new System.Drawing.Point(6, 14);
			// // this._lblCommonLabel_1.mLabelId = 1049;
			this._lblCommonLabel_1.Name = "_lblCommonLabel_1";
			this._lblCommonLabel_1.Size = new System.Drawing.Size(84, 14);
			this._lblCommonLabel_1.TabIndex = 17;
			// 
			// _txtCommonTextBox_4
			// 
			//this._txtCommonTextBox_4.AllowDrop = true;
			this._txtCommonTextBox_4.BackColor = System.Drawing.Color.White;
			// this._txtCommonTextBox_4.bolNumericOnly = true;
			this._txtCommonTextBox_4.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_4.Location = new System.Drawing.Point(116, 33);
			this._txtCommonTextBox_4.MaxLength = 4;
			this._txtCommonTextBox_4.Name = "_txtCommonTextBox_4";
			// this._txtCommonTextBox_4.ShowButton = true;
			this._txtCommonTextBox_4.Size = new System.Drawing.Size(101, 19);
			this._txtCommonTextBox_4.TabIndex = 5;
			this._txtCommonTextBox_4.Text = "";
			// this.//this._txtCommonTextBox_4.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(//this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_4.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _lblCommonLabel_9
			// 
			//this._lblCommonLabel_9.AllowDrop = true;
			this._lblCommonLabel_9.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_9.Text = "New Designatin Code";
			this._lblCommonLabel_9.Location = new System.Drawing.Point(6, 35);
			// // this._lblCommonLabel_9.mLabelId = 1226;
			this._lblCommonLabel_9.Name = "_lblCommonLabel_9";
			this._lblCommonLabel_9.Size = new System.Drawing.Size(104, 14);
			this._lblCommonLabel_9.TabIndex = 18;
			// 
			// _txtDisplayLabel_5
			// 
			//this._txtDisplayLabel_5.AllowDrop = true;
			this._txtDisplayLabel_5.Location = new System.Drawing.Point(219, 33);
			this._txtDisplayLabel_5.Name = "_txtDisplayLabel_5";
			this._txtDisplayLabel_5.Size = new System.Drawing.Size(247, 19);
			this._txtDisplayLabel_5.TabIndex = 24;
			this._txtDisplayLabel_5.TabStop = false;
			// 
			// _txtDisplayLabel_3
			// 
			//this._txtDisplayLabel_3.AllowDrop = true;
			this._txtDisplayLabel_3.Location = new System.Drawing.Point(116, 12);
			this._txtDisplayLabel_3.Name = "_txtDisplayLabel_3";
			this._txtDisplayLabel_3.Size = new System.Drawing.Size(101, 19);
			this._txtDisplayLabel_3.TabIndex = 25;
			// 
			// _txtDisplayLabel_4
			// 
			//this._txtDisplayLabel_4.AllowDrop = true;
			this._txtDisplayLabel_4.Location = new System.Drawing.Point(219, 12);
			this._txtDisplayLabel_4.Name = "_txtDisplayLabel_4";
			this._txtDisplayLabel_4.Size = new System.Drawing.Size(247, 19);
			this._txtDisplayLabel_4.TabIndex = 26;
			this._txtDisplayLabel_4.TabStop = false;
			// 
			// frmDepartment
			// 
			//this.frmDepartment.AllowDrop = true;
			this.frmDepartment.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.frmDepartment.Controls.Add(this._lblCommonLabel_0);
			this.frmDepartment.Controls.Add(this._txtCommonTextBox_3);
			this.frmDepartment.Controls.Add(this._lblCommonLabel_8);
			this.frmDepartment.Controls.Add(this._txtDisplayLabel_2);
			this.frmDepartment.Controls.Add(this._txtDisplayLabel_0);
			this.frmDepartment.Controls.Add(this._txtDisplayLabel_1);
			this.frmDepartment.Enabled = true;
			this.frmDepartment.ForeColor = System.Drawing.SystemColors.ControlText;
			this.frmDepartment.Location = new System.Drawing.Point(8, 114);
			this.frmDepartment.Name = "frmDepartment";
			this.frmDepartment.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.frmDepartment.Size = new System.Drawing.Size(475, 59);
			this.frmDepartment.TabIndex = 13;
			this.frmDepartment.Text = " Department ";
			this.frmDepartment.Visible = true;
			// 
			// _lblCommonLabel_0
			// 
			//this._lblCommonLabel_0.AllowDrop = true;
			this._lblCommonLabel_0.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_0.Text = "Department Code";
			this._lblCommonLabel_0.Location = new System.Drawing.Point(6, 14);
			// // this._lblCommonLabel_0.mLabelId = 1973;
			this._lblCommonLabel_0.Name = "_lblCommonLabel_0";
			this._lblCommonLabel_0.Size = new System.Drawing.Size(83, 14);
			this._lblCommonLabel_0.TabIndex = 14;
			// 
			// _txtCommonTextBox_3
			// 
			//this._txtCommonTextBox_3.AllowDrop = true;
			this._txtCommonTextBox_3.BackColor = System.Drawing.Color.White;
			// this._txtCommonTextBox_3.bolNumericOnly = true;
			this._txtCommonTextBox_3.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_3.Location = new System.Drawing.Point(116, 33);
			this._txtCommonTextBox_3.MaxLength = 4;
			this._txtCommonTextBox_3.Name = "_txtCommonTextBox_3";
			// this._txtCommonTextBox_3.ShowButton = true;
			this._txtCommonTextBox_3.Size = new System.Drawing.Size(101, 19);
			this._txtCommonTextBox_3.TabIndex = 4;
			this._txtCommonTextBox_3.Text = "";
			// this.//this._txtCommonTextBox_3.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(//this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_3.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _lblCommonLabel_8
			// 
			//this._lblCommonLabel_8.AllowDrop = true;
			this._lblCommonLabel_8.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_8.Text = "New Department Code";
			this._lblCommonLabel_8.Location = new System.Drawing.Point(6, 35);
			// // this._lblCommonLabel_8.mLabelId = 1225;
			this._lblCommonLabel_8.Name = "_lblCommonLabel_8";
			this._lblCommonLabel_8.Size = new System.Drawing.Size(109, 14);
			this._lblCommonLabel_8.TabIndex = 15;
			// 
			// _txtDisplayLabel_2
			// 
			//this._txtDisplayLabel_2.AllowDrop = true;
			this._txtDisplayLabel_2.Location = new System.Drawing.Point(219, 33);
			this._txtDisplayLabel_2.Name = "_txtDisplayLabel_2";
			this._txtDisplayLabel_2.Size = new System.Drawing.Size(247, 19);
			this._txtDisplayLabel_2.TabIndex = 27;
			this._txtDisplayLabel_2.TabStop = false;
			// 
			// _txtDisplayLabel_0
			// 
			//this._txtDisplayLabel_0.AllowDrop = true;
			this._txtDisplayLabel_0.Location = new System.Drawing.Point(116, 12);
			this._txtDisplayLabel_0.Name = "_txtDisplayLabel_0";
			this._txtDisplayLabel_0.Size = new System.Drawing.Size(101, 19);
			this._txtDisplayLabel_0.TabIndex = 28;
			// 
			// _txtDisplayLabel_1
			// 
			//this._txtDisplayLabel_1.AllowDrop = true;
			this._txtDisplayLabel_1.Location = new System.Drawing.Point(219, 12);
			this._txtDisplayLabel_1.Name = "_txtDisplayLabel_1";
			this._txtDisplayLabel_1.Size = new System.Drawing.Size(247, 19);
			this._txtDisplayLabel_1.TabIndex = 29;
			this._txtDisplayLabel_1.TabStop = false;
			// 
			// _lblCommonLabel_7
			// 
			//this._lblCommonLabel_7.AllowDrop = true;
			this._lblCommonLabel_7.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_7.Text = "Reference No.";
			this._lblCommonLabel_7.Location = new System.Drawing.Point(284, 75);
			// // this._lblCommonLabel_7.mLabelId = 1963;
			this._lblCommonLabel_7.Name = "_lblCommonLabel_7";
			this._lblCommonLabel_7.Size = new System.Drawing.Size(70, 13);
			this._lblCommonLabel_7.TabIndex = 8;
			// 
			// _lblCommonLabel_5
			// 
			//this._lblCommonLabel_5.AllowDrop = true;
			this._lblCommonLabel_5.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_5.Text = "Transfer No.";
			this._lblCommonLabel_5.Location = new System.Drawing.Point(14, 52);
			// // this._lblCommonLabel_5.mLabelId = 1222;
			this._lblCommonLabel_5.Name = "_lblCommonLabel_5";
			this._lblCommonLabel_5.Size = new System.Drawing.Size(61, 14);
			this._lblCommonLabel_5.TabIndex = 9;
			// 
			// _lblCommonLabel_6
			// 
			//this._lblCommonLabel_6.AllowDrop = true;
			this._lblCommonLabel_6.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_6.Text = "Transfer Date";
			this._lblCommonLabel_6.Location = new System.Drawing.Point(284, 52);
			// // this._lblCommonLabel_6.mLabelId = 1224;
			this._lblCommonLabel_6.Name = "_lblCommonLabel_6";
			this._lblCommonLabel_6.Size = new System.Drawing.Size(67, 14);
			this._lblCommonLabel_6.TabIndex = 10;
			// 
			// txtVoucherDate
			// 
			//this.txtVoucherDate.AllowDrop = true;
			// this.txtVoucherDate.CheckDateRange = false;
			this.txtVoucherDate.Location = new System.Drawing.Point(372, 50);
			// this.txtVoucherDate.MaxDate = 2958465;
			// this.txtVoucherDate.MinDate = 32874;
			this.txtVoucherDate.Name = "txtVoucherDate";
			this.txtVoucherDate.Size = new System.Drawing.Size(102, 19);
			this.txtVoucherDate.TabIndex = 1;
			// this.txtVoucherDate.Text = "18/07/2001";
			// this.txtVoucherDate.Value = 37090;
			// 
			// _txtCommonTextBox_0
			// 
			//this._txtCommonTextBox_0.AllowDrop = true;
			this._txtCommonTextBox_0.BackColor = System.Drawing.Color.White;
			// this._txtCommonTextBox_0.bolNumericOnly = true;
			this._txtCommonTextBox_0.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_0.Location = new System.Drawing.Point(124, 50);
			// // = System.Windows.Forms.TextBox.DropDownTypes.ddtNextNumber;
			this._txtCommonTextBox_0.Name = "_txtCommonTextBox_0";
			// this._txtCommonTextBox_0.ShowButton = true;
			this._txtCommonTextBox_0.Size = new System.Drawing.Size(102, 19);
			this._txtCommonTextBox_0.TabIndex = 0;
			this._txtCommonTextBox_0.Text = "";
			// this.//this._txtCommonTextBox_0.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(//this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_0.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _txtCommonTextBox_1
			// 
			//this._txtCommonTextBox_1.AllowDrop = true;
			this._txtCommonTextBox_1.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_1.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_1.Location = new System.Drawing.Point(124, 94);
			this._txtCommonTextBox_1.MaxLength = 10;
			this._txtCommonTextBox_1.Name = "_txtCommonTextBox_1";
			// this._txtCommonTextBox_1.ShowButton = true;
			this._txtCommonTextBox_1.Size = new System.Drawing.Size(101, 19);
			this._txtCommonTextBox_1.TabIndex = 3;
			this._txtCommonTextBox_1.Text = "";
			// this.//this._txtCommonTextBox_1.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(//this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_1.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _lblCommonLabel_2
			// 
			//this._lblCommonLabel_2.AllowDrop = true;
			this._lblCommonLabel_2.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_2.Text = "Employee Code";
			this._lblCommonLabel_2.Location = new System.Drawing.Point(14, 96);
			// // this._lblCommonLabel_2.mLabelId = 236;
			this._lblCommonLabel_2.Name = "_lblCommonLabel_2";
			this._lblCommonLabel_2.Size = new System.Drawing.Size(74, 14);
			this._lblCommonLabel_2.TabIndex = 11;
			// 
			// System.Windows.Forms.Label12
			// 
			//this.Label12.AllowDrop = true;
			this.Label12.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.Label12.Text = "Comments";
			this.Label12.Location = new System.Drawing.Point(14, 243);
			// this.Label12.mLabelId = 1851;
			this.Label12.Name="Label12";
			this.Label12.Size = new System.Drawing.Size(50, 14);
			this.Label12.TabIndex = 12;
			// 
			// _txtCommonTextBox_5
			// 
			//this._txtCommonTextBox_5.AllowDrop = true;
			this._txtCommonTextBox_5.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_5.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_5.Location = new System.Drawing.Point(124, 240);
			this._txtCommonTextBox_5.MaxLength = 100;
			this._txtCommonTextBox_5.Name = "_txtCommonTextBox_5";
			this._txtCommonTextBox_5.Size = new System.Drawing.Size(350, 19);
			this._txtCommonTextBox_5.TabIndex = 7;
			this._txtCommonTextBox_5.Text = "";
			// this.//this._txtCommonTextBox_5.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(//this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_5.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// cmbPromotionType
			// 
			//this.cmbPromotionType.AllowDrop = true;
			this.cmbPromotionType.Enabled = false;
			this.cmbPromotionType.Location = new System.Drawing.Point(124, 71);
			this.cmbPromotionType.Name = "cmbPromotionType";
			this.cmbPromotionType.Size = new System.Drawing.Size(102, 21);
			this.cmbPromotionType.TabIndex = 2;
			// 
			// System.Windows.Forms.Label1
			// 
			//this.Label1.AllowDrop = true;
			this.Label1.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.Label1.Text = "Promotion Type";
			this.Label1.Location = new System.Drawing.Point(14, 74);
			// this.Label1.mLabelId = 1223;
			this.Label1.Name="Label1";
			this.Label1.Size = new System.Drawing.Size(74, 14);
			this.Label1.TabIndex = 22;
			// 
			// _txtCommonTextBox_2
			// 
			//this._txtCommonTextBox_2.AllowDrop = true;
			this._txtCommonTextBox_2.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_2.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_2.Location = new System.Drawing.Point(372, 72);
			this._txtCommonTextBox_2.MaxLength = 20;
			this._txtCommonTextBox_2.Name = "_txtCommonTextBox_2";
			this._txtCommonTextBox_2.Size = new System.Drawing.Size(102, 19);
			this._txtCommonTextBox_2.TabIndex = 30;
			this._txtCommonTextBox_2.Text = "";
			// this.//this._txtCommonTextBox_2.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(//this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_2.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _txtDisplayLabel_7
			// 
			//this._txtDisplayLabel_7.AllowDrop = true;
			this._txtDisplayLabel_7.Location = new System.Drawing.Point(227, 94);
			this._txtDisplayLabel_7.Name = "_txtDisplayLabel_7";
			this._txtDisplayLabel_7.Size = new System.Drawing.Size(247, 19);
			this._txtDisplayLabel_7.TabIndex = 31;
			this._txtDisplayLabel_7.TabStop = false;
			// 
			// frmPayPromotion
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.ClientSize = new System.Drawing.Size(491, 266);
			this.Controls.Add(this.frmBasicSalary);
			this.Controls.Add(this.frmDesignation);
			this.Controls.Add(this.frmDepartment);
			this.Controls.Add(this._lblCommonLabel_7);
			this.Controls.Add(this._lblCommonLabel_5);
			this.Controls.Add(this._lblCommonLabel_6);
			this.Controls.Add(this.txtVoucherDate);
			this.Controls.Add(this._txtCommonTextBox_0);
			this.Controls.Add(this._txtCommonTextBox_1);
			this.Controls.Add(this._lblCommonLabel_2);
			this.Controls.Add(this.Label12);
			this.Controls.Add(this._txtCommonTextBox_5);
			this.Controls.Add(this.cmbPromotionType);
			this.Controls.Add(this.Label1);
			this.Controls.Add(this._txtCommonTextBox_2);
			this.Controls.Add(this._txtDisplayLabel_7);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			//this.Icon = (System.Drawing.Icon) resources.GetObject("frmPayPromotion.Icon");
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(145, 127);
			this.MaximizeBox = true;
			this.MinimizeBox = true;
			this.Name = "frmPayPromotion";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Promotion / Transfer";
			// this.Activated += new System.EventHandler(this.frmPayPromotion_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
			// this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
			this.frmBasicSalary.ResumeLayout(false);
			this.frmDesignation.ResumeLayout(false);
			this.frmDepartment.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		// 
		void InitializetxtDisplayLabel()
		{
			this.txtDisplayLabel = new System.Windows.Forms.Label[8];
			this.txtDisplayLabel[6] = _txtDisplayLabel_6;
			this.txtDisplayLabel[5] = _txtDisplayLabel_5;
			this.txtDisplayLabel[3] = _txtDisplayLabel_3;
			this.txtDisplayLabel[4] = _txtDisplayLabel_4;
			this.txtDisplayLabel[2] = _txtDisplayLabel_2;
			this.txtDisplayLabel[0] = _txtDisplayLabel_0;
			this.txtDisplayLabel[1] = _txtDisplayLabel_1;
			this.txtDisplayLabel[7] = _txtDisplayLabel_7;
		}
		void InitializetxtCommonTextBox()
		{
			this.txtCommonTextBox = new System.Windows.Forms.TextBox[6];
			this.txtCommonTextBox[4] = _txtCommonTextBox_4;
			this.txtCommonTextBox[3] = _txtCommonTextBox_3;
			this.txtCommonTextBox[0] = _txtCommonTextBox_0;
			this.txtCommonTextBox[1] = _txtCommonTextBox_1;
			this.txtCommonTextBox[5] = _txtCommonTextBox_5;
			this.txtCommonTextBox[2] = _txtCommonTextBox_2;
		}
		void InitializelblCommonLabel()
		{
			this.lblCommonLabel = new System.Windows.Forms.Label[10];
			this.lblCommonLabel[3] = _lblCommonLabel_3;
			this.lblCommonLabel[4] = _lblCommonLabel_4;
			this.lblCommonLabel[1] = _lblCommonLabel_1;
			this.lblCommonLabel[9] = _lblCommonLabel_9;
			this.lblCommonLabel[0] = _lblCommonLabel_0;
			this.lblCommonLabel[8] = _lblCommonLabel_8;
			this.lblCommonLabel[7] = _lblCommonLabel_7;
			this.lblCommonLabel[5] = _lblCommonLabel_5;
			this.lblCommonLabel[6] = _lblCommonLabel_6;
			this.lblCommonLabel[2] = _lblCommonLabel_2;
		}
		#endregion
	}
}//ENDSHERE
