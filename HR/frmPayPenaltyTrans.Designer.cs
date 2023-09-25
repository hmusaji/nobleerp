
namespace Xtreme
{
	partial class frmPayPenaltyTrans
	{

		#region "Upgrade Support "
		private static frmPayPenaltyTrans m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmPayPenaltyTrans DefInstance
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
		public static frmPayPenaltyTrans CreateInstance()
		{
			frmPayPenaltyTrans theInstance = new frmPayPenaltyTrans();
			
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
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "_lblCommonLabel_5", "_lblCommonLabel_6", "txtVoucherDate", "_lblCommonLabel_2", "_lblCommonLabel_0", "_lblCommonLabel_1", "txtMonthPercent", "_lblCommonLabel_10", "txtPenaltyDeductionAmount", "_lblCommonLabel_4", "_lblCommonLabel_8", "_lblCommonLabel_16", "txtStartDeductionDate", "System.Windows.Forms.Label12", "_txtCommonTextBox_3", "_txtDisplayLabel_5", "_txtDisplayLabel_3", "_txtDisplayLabel_2", "_txtDisplayLabel_1", "_txtDisplayLabel_0", "_txtDisplayLabel_13", "_lblCommonLabel_18", "_txtCommonTextBox_4", "_txtDisplayLabel_14", "System.Windows.Forms.Label1", "_txtCommonTextBox_5", "_txtCommonTextBox_0", "_txtCommonTextBox_1", "txtPenaltyDays", "_lblCommonLabel_3", "txtPenaltyAmount", "_lblCommonLabel_7", "_lblCommonLabel_9", "txtDeductionDate", "txtNRepeatDeductPer", "_lblCommonLabel_11", "_lblCommonLabel_12", "txtActualPenaltyDate", "_lblCommonLabel_13", "txtActualPenaltyTo", "lblCommonLabel", "txtCommonTextBox", "txtDisplayLabel"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		private System.Windows.Forms.Label _lblCommonLabel_5;
		private System.Windows.Forms.Label _lblCommonLabel_6;
		public Syncfusion.WinForms.Input.SfDateTimeEdit txtVoucherDate;
		private System.Windows.Forms.Label _lblCommonLabel_2;
		private System.Windows.Forms.Label _lblCommonLabel_0;
		private System.Windows.Forms.Label _lblCommonLabel_1;
		public System.Windows.Forms.TextBox txtMonthPercent;
		private System.Windows.Forms.Label _lblCommonLabel_10;
		public System.Windows.Forms.TextBox txtPenaltyDeductionAmount;
		private System.Windows.Forms.Label _lblCommonLabel_4;
		private System.Windows.Forms.Label _lblCommonLabel_8;
		private System.Windows.Forms.Label _lblCommonLabel_16;
		public Syncfusion.WinForms.Input.SfDateTimeEdit txtStartDeductionDate;
		public System.Windows.Forms.Label Label12;
		private System.Windows.Forms.TextBox _txtCommonTextBox_3;
		private System.Windows.Forms.Label _txtDisplayLabel_5;
		private System.Windows.Forms.Label _txtDisplayLabel_3;
		private System.Windows.Forms.Label _txtDisplayLabel_2;
		private System.Windows.Forms.Label _txtDisplayLabel_1;
		private System.Windows.Forms.Label _txtDisplayLabel_0;
		private System.Windows.Forms.Label _txtDisplayLabel_13;
		private System.Windows.Forms.Label _lblCommonLabel_18;
		private System.Windows.Forms.TextBox _txtCommonTextBox_4;
		private System.Windows.Forms.Label _txtDisplayLabel_14;
		public System.Windows.Forms.Label Label1;
		private System.Windows.Forms.TextBox _txtCommonTextBox_5;
		private System.Windows.Forms.TextBox _txtCommonTextBox_0;
		private System.Windows.Forms.TextBox _txtCommonTextBox_1;
		public System.Windows.Forms.TextBox txtPenaltyDays;
		private System.Windows.Forms.Label _lblCommonLabel_3;
		public System.Windows.Forms.TextBox txtPenaltyAmount;
		private System.Windows.Forms.Label _lblCommonLabel_7;
		private System.Windows.Forms.Label _lblCommonLabel_9;
		public Syncfusion.WinForms.Input.SfDateTimeEdit txtDeductionDate;
		public System.Windows.Forms.TextBox txtNRepeatDeductPer;
		private System.Windows.Forms.Label _lblCommonLabel_11;
		private System.Windows.Forms.Label _lblCommonLabel_12;
		public Syncfusion.WinForms.Input.SfDateTimeEdit txtActualPenaltyDate;
		private System.Windows.Forms.Label _lblCommonLabel_13;
		public Syncfusion.WinForms.Input.SfDateTimeEdit txtActualPenaltyTo;
		public System.Windows.Forms.Label[] lblCommonLabel = new System.Windows.Forms.Label[19];
		public System.Windows.Forms.TextBox[] txtCommonTextBox = new System.Windows.Forms.TextBox[6];
		public System.Windows.Forms.Label[] txtDisplayLabel = new System.Windows.Forms.Label[15];
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPayPenaltyTrans));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this._lblCommonLabel_5 = new System.Windows.Forms.Label();
			this._lblCommonLabel_6 = new System.Windows.Forms.Label();
			this.txtVoucherDate = new Syncfusion.WinForms.Input.SfDateTimeEdit();
			this._lblCommonLabel_2 = new System.Windows.Forms.Label();
			this._lblCommonLabel_0 = new System.Windows.Forms.Label();
			this._lblCommonLabel_1 = new System.Windows.Forms.Label();
			this.txtMonthPercent = new System.Windows.Forms.TextBox();
			this._lblCommonLabel_10 = new System.Windows.Forms.Label();
			this.txtPenaltyDeductionAmount = new System.Windows.Forms.TextBox();
			this._lblCommonLabel_4 = new System.Windows.Forms.Label();
			this._lblCommonLabel_8 = new System.Windows.Forms.Label();
			this._lblCommonLabel_16 = new System.Windows.Forms.Label();
			this.txtStartDeductionDate = new Syncfusion.WinForms.Input.SfDateTimeEdit();
			this.Label12 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_3 = new System.Windows.Forms.TextBox();
			this._txtDisplayLabel_5 = new System.Windows.Forms.Label();
			this._txtDisplayLabel_3 = new System.Windows.Forms.Label();
			this._txtDisplayLabel_2 = new System.Windows.Forms.Label();
			this._txtDisplayLabel_1 = new System.Windows.Forms.Label();
			this._txtDisplayLabel_0 = new System.Windows.Forms.Label();
			this._txtDisplayLabel_13 = new System.Windows.Forms.Label();
			this._lblCommonLabel_18 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_4 = new System.Windows.Forms.TextBox();
			this._txtDisplayLabel_14 = new System.Windows.Forms.Label();
			this.Label1 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_5 = new System.Windows.Forms.TextBox();
			this._txtCommonTextBox_0 = new System.Windows.Forms.TextBox();
			this._txtCommonTextBox_1 = new System.Windows.Forms.TextBox();
			this.txtPenaltyDays = new System.Windows.Forms.TextBox();
			this._lblCommonLabel_3 = new System.Windows.Forms.Label();
			this.txtPenaltyAmount = new System.Windows.Forms.TextBox();
			this._lblCommonLabel_7 = new System.Windows.Forms.Label();
			this._lblCommonLabel_9 = new System.Windows.Forms.Label();
			this.txtDeductionDate = new Syncfusion.WinForms.Input.SfDateTimeEdit();
			this.txtNRepeatDeductPer = new System.Windows.Forms.TextBox();
			this._lblCommonLabel_11 = new System.Windows.Forms.Label();
			this._lblCommonLabel_12 = new System.Windows.Forms.Label();
			this.txtActualPenaltyDate = new Syncfusion.WinForms.Input.SfDateTimeEdit();
			this._lblCommonLabel_13 = new System.Windows.Forms.Label();
			this.txtActualPenaltyTo = new Syncfusion.WinForms.Input.SfDateTimeEdit();
			this.SuspendLayout();
			// 
			// _lblCommonLabel_5
			// 
			this._lblCommonLabel_5.AllowDrop = true;
			this._lblCommonLabel_5.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_5.Text = "Transaction No.";
			this._lblCommonLabel_5.Location = new System.Drawing.Point(6, 50);
			// // this._lblCommonLabel_5.mLabelId = 1232;
			this._lblCommonLabel_5.Name = "_lblCommonLabel_5";
			this._lblCommonLabel_5.Size = new System.Drawing.Size(76, 14);
			this._lblCommonLabel_5.TabIndex = 16;
			// 
			// _lblCommonLabel_6
			// 
			this._lblCommonLabel_6.AllowDrop = true;
			this._lblCommonLabel_6.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_6.Text = "Transaction Date";
			this._lblCommonLabel_6.Location = new System.Drawing.Point(260, 51);
			// // this._lblCommonLabel_6.mLabelId = 1233;
			this._lblCommonLabel_6.Name = "_lblCommonLabel_6";
			this._lblCommonLabel_6.Size = new System.Drawing.Size(82, 14);
			this._lblCommonLabel_6.TabIndex = 17;
			// 
			// txtVoucherDate
			// 
			this.txtVoucherDate.AllowDrop = true;
			// this.txtVoucherDate.CheckDateRange = false;
			this.txtVoucherDate.Location = new System.Drawing.Point(380, 48);
			// this.txtVoucherDate.MaxDate = 2958465;
			// this.txtVoucherDate.MinDate = 32874;
			this.txtVoucherDate.Name = "txtVoucherDate";
			this.txtVoucherDate.Size = new System.Drawing.Size(102, 19);
			this.txtVoucherDate.TabIndex = 1;
			// this.txtVoucherDate.Text = "18/07/2001";
			// this.txtVoucherDate.Value = 37090;
			// 
			// _lblCommonLabel_2
			// 
			this._lblCommonLabel_2.AllowDrop = true;
			this._lblCommonLabel_2.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_2.Text = "Employee Code";
			this._lblCommonLabel_2.Location = new System.Drawing.Point(6, 73);
			// // this._lblCommonLabel_2.mLabelId = 236;
			this._lblCommonLabel_2.Name = "_lblCommonLabel_2";
			this._lblCommonLabel_2.Size = new System.Drawing.Size(74, 14);
			this._lblCommonLabel_2.TabIndex = 18;
			// 
			// _lblCommonLabel_0
			// 
			this._lblCommonLabel_0.AllowDrop = true;
			this._lblCommonLabel_0.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_0.Text = "Department Code";
			this._lblCommonLabel_0.Location = new System.Drawing.Point(6, 114);
			// // this._lblCommonLabel_0.mLabelId = 1973;
			this._lblCommonLabel_0.Name = "_lblCommonLabel_0";
			this._lblCommonLabel_0.Size = new System.Drawing.Size(83, 14);
			this._lblCommonLabel_0.TabIndex = 19;
			// 
			// _lblCommonLabel_1
			// 
			this._lblCommonLabel_1.AllowDrop = true;
			this._lblCommonLabel_1.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_1.Text = "Designation Code";
			this._lblCommonLabel_1.Location = new System.Drawing.Point(6, 135);
			// // this._lblCommonLabel_1.mLabelId = 1049;
			this._lblCommonLabel_1.Name = "_lblCommonLabel_1";
			this._lblCommonLabel_1.Size = new System.Drawing.Size(84, 14);
			this._lblCommonLabel_1.TabIndex = 20;
			// 
			// txtMonthPercent
			// 
			this.txtMonthPercent.AllowDrop = true;
			// this.txtMonthPercent.DisplayFormat = "####0.000###;;0.000;0.000";
			// this.txtMonthPercent.Format = "###########0.000";
			this.txtMonthPercent.Location = new System.Drawing.Point(132, 174);
			// this.txtMonthPercent.MaxValue = 2147483647;
			// this.txtMonthPercent.MinValue = 0;
			this.txtMonthPercent.Name = "txtMonthPercent";
			this.txtMonthPercent.Size = new System.Drawing.Size(101, 19);
			this.txtMonthPercent.TabIndex = 6;
			this.txtMonthPercent.Text = "0.000";
			// this.txtMonthPercent.Leave += new System.EventHandler(this.txtMonthPercent_Leave);
			// 
			// _lblCommonLabel_10
			// 
			this._lblCommonLabel_10.AllowDrop = true;
			this._lblCommonLabel_10.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_10.Text = "Penalty %   ";
			this._lblCommonLabel_10.Location = new System.Drawing.Point(6, 176);
			// // this._lblCommonLabel_10.mLabelId = 2063;
			this._lblCommonLabel_10.Name = "_lblCommonLabel_10";
			this._lblCommonLabel_10.Size = new System.Drawing.Size(57, 14);
			this._lblCommonLabel_10.TabIndex = 21;
			// 
			// txtPenaltyDeductionAmount
			// 
			this.txtPenaltyDeductionAmount.AllowDrop = true;
			this.txtPenaltyDeductionAmount.BackColor = System.Drawing.Color.FromArgb(239, 239, 239);
			// this.txtPenaltyDeductionAmount.DisplayFormat = "####0.000###;;0.000;0.000";
			this.txtPenaltyDeductionAmount.Enabled = false;
			// this.txtPenaltyDeductionAmount.Format = "###########0.000";
			this.txtPenaltyDeductionAmount.Location = new System.Drawing.Point(380, 216);
			// this.txtPenaltyDeductionAmount.MaxValue = 2147483647;
			// this.txtPenaltyDeductionAmount.MinValue = 0;
			this.txtPenaltyDeductionAmount.Name = "txtPenaltyDeductionAmount";
			this.txtPenaltyDeductionAmount.Size = new System.Drawing.Size(101, 19);
			this.txtPenaltyDeductionAmount.TabIndex = 14;
			this.txtPenaltyDeductionAmount.TabStop = false;
			this.txtPenaltyDeductionAmount.Text = "0.000";
			// 
			// _lblCommonLabel_4
			// 
			this._lblCommonLabel_4.AllowDrop = true;
			this._lblCommonLabel_4.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_4.Text = "Penalty Deduction Amount ";
			this._lblCommonLabel_4.Location = new System.Drawing.Point(244, 218);
			// // this._lblCommonLabel_4.mLabelId = 2067;
			this._lblCommonLabel_4.Name = "_lblCommonLabel_4";
			this._lblCommonLabel_4.Size = new System.Drawing.Size(129, 14);
			this._lblCommonLabel_4.TabIndex = 22;
			// 
			// _lblCommonLabel_8
			// 
			this._lblCommonLabel_8.AllowDrop = true;
			this._lblCommonLabel_8.BackColor = System.Drawing.Color.FromArgb(237, 231, 235);
			this._lblCommonLabel_8.Text = "Start Deduction Date";
			this._lblCommonLabel_8.Enabled = false;
			this._lblCommonLabel_8.Location = new System.Drawing.Point(234, 341);
			this._lblCommonLabel_8.Name = "_lblCommonLabel_8";
			this._lblCommonLabel_8.Size = new System.Drawing.Size(99, 14);
			this._lblCommonLabel_8.TabIndex = 23;
			// 
			// _lblCommonLabel_16
			// 
			this._lblCommonLabel_16.AllowDrop = true;
			this._lblCommonLabel_16.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_16.Text = "Repeat No Of Time";
			this._lblCommonLabel_16.Location = new System.Drawing.Point(6, 240);
			// // this._lblCommonLabel_16.mLabelId = 2068;
			this._lblCommonLabel_16.Name = "_lblCommonLabel_16";
			this._lblCommonLabel_16.Size = new System.Drawing.Size(90, 14);
			this._lblCommonLabel_16.TabIndex = 24;
			// 
			// txtStartDeductionDate
			// 
			this.txtStartDeductionDate.AllowDrop = true;
			this.txtStartDeductionDate.BackColor = System.Drawing.Color.FromArgb(239, 239, 239);
			// this.txtStartDeductionDate.CheckDateRange = false;
			this.txtStartDeductionDate.Enabled = false;
			this.txtStartDeductionDate.Location = new System.Drawing.Point(356, 339);
			// this.txtStartDeductionDate.MaxDate = 2958465;
			// this.txtStartDeductionDate.MinDate = 32874;
			this.txtStartDeductionDate.Name = "txtStartDeductionDate";
			this.txtStartDeductionDate.Size = new System.Drawing.Size(101, 19);
			this.txtStartDeductionDate.TabIndex = 15;
			// this.txtStartDeductionDate.Text = "18/07/2001";
			// this.txtStartDeductionDate.Value = 37090;
			// 
			// System.Windows.Forms.Label12
			// 
			this.Label12.AllowDrop = true;
			this.Label12.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.Label12.Text = "Comments  ";
			this.Label12.Location = new System.Drawing.Point(6, 282);
			// this.Label12.mLabelId = 1851;
			this.Label12.Name = "System.Windows.Forms.Label12";
			this.Label12.Size = new System.Drawing.Size(56, 14);
			this.Label12.TabIndex = 25;
			// 
			// _txtCommonTextBox_3
			// 
			this._txtCommonTextBox_3.AllowDrop = true;
			this._txtCommonTextBox_3.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_3.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_3.Location = new System.Drawing.Point(131, 281);
			this._txtCommonTextBox_3.MaxLength = 100;
			this._txtCommonTextBox_3.Name = "_txtCommonTextBox_3";
			this._txtCommonTextBox_3.Size = new System.Drawing.Size(351, 19);
			this._txtCommonTextBox_3.TabIndex = 13;
			this._txtCommonTextBox_3.Text = "";
			// this.this._txtCommonTextBox_3.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_3.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _txtDisplayLabel_5
			// 
			// this._txtDisplayLabel_5.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
			this._txtDisplayLabel_5.AllowDrop = true;
			this._txtDisplayLabel_5.Enabled = false;
			this._txtDisplayLabel_5.Location = new System.Drawing.Point(132, 238);
			this._txtDisplayLabel_5.Name = "_txtDisplayLabel_5";
			this._txtDisplayLabel_5.Size = new System.Drawing.Size(101, 19);
			this._txtDisplayLabel_5.TabIndex = 11;
			this._txtDisplayLabel_5.TabStop = false;
			// 
			// _txtDisplayLabel_3
			// 
			this._txtDisplayLabel_3.AllowDrop = true;
			this._txtDisplayLabel_3.Location = new System.Drawing.Point(235, 132);
			this._txtDisplayLabel_3.Name = "_txtDisplayLabel_3";
			this._txtDisplayLabel_3.Size = new System.Drawing.Size(247, 19);
			this._txtDisplayLabel_3.TabIndex = 26;
			this._txtDisplayLabel_3.TabStop = false;
			// 
			// _txtDisplayLabel_2
			// 
			this._txtDisplayLabel_2.AllowDrop = true;
			this._txtDisplayLabel_2.Location = new System.Drawing.Point(132, 132);
			this._txtDisplayLabel_2.Name = "_txtDisplayLabel_2";
			this._txtDisplayLabel_2.Size = new System.Drawing.Size(101, 19);
			this._txtDisplayLabel_2.TabIndex = 27;
			// 
			// _txtDisplayLabel_1
			// 
			this._txtDisplayLabel_1.AllowDrop = true;
			this._txtDisplayLabel_1.Location = new System.Drawing.Point(235, 111);
			this._txtDisplayLabel_1.Name = "_txtDisplayLabel_1";
			this._txtDisplayLabel_1.Size = new System.Drawing.Size(247, 19);
			this._txtDisplayLabel_1.TabIndex = 28;
			this._txtDisplayLabel_1.TabStop = false;
			// 
			// _txtDisplayLabel_0
			// 
			this._txtDisplayLabel_0.AllowDrop = true;
			this._txtDisplayLabel_0.Location = new System.Drawing.Point(132, 111);
			this._txtDisplayLabel_0.Name = "_txtDisplayLabel_0";
			this._txtDisplayLabel_0.Size = new System.Drawing.Size(101, 19);
			this._txtDisplayLabel_0.TabIndex = 29;
			// 
			// _txtDisplayLabel_13
			// 
			this._txtDisplayLabel_13.AllowDrop = true;
			this._txtDisplayLabel_13.Location = new System.Drawing.Point(235, 70);
			this._txtDisplayLabel_13.Name = "_txtDisplayLabel_13";
			this._txtDisplayLabel_13.Size = new System.Drawing.Size(247, 19);
			this._txtDisplayLabel_13.TabIndex = 30;
			this._txtDisplayLabel_13.TabStop = false;
			// 
			// _lblCommonLabel_18
			// 
			this._lblCommonLabel_18.AllowDrop = true;
			this._lblCommonLabel_18.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_18.Text = "Penalty Code";
			this._lblCommonLabel_18.Location = new System.Drawing.Point(6, 94);
			// // this._lblCommonLabel_18.mLabelId = 2056;
			this._lblCommonLabel_18.Name = "_lblCommonLabel_18";
			this._lblCommonLabel_18.Size = new System.Drawing.Size(63, 14);
			this._lblCommonLabel_18.TabIndex = 31;
			// 
			// _txtCommonTextBox_4
			// 
			this._txtCommonTextBox_4.AllowDrop = true;
			this._txtCommonTextBox_4.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_4.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_4.Location = new System.Drawing.Point(132, 91);
			this._txtCommonTextBox_4.MaxLength = 10;
			this._txtCommonTextBox_4.Name = "_txtCommonTextBox_4";
			// this._txtCommonTextBox_4.ShowButton = true;
			this._txtCommonTextBox_4.Size = new System.Drawing.Size(101, 19);
			this._txtCommonTextBox_4.TabIndex = 3;
			this._txtCommonTextBox_4.Text = "";
			// this.this._txtCommonTextBox_4.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_4.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _txtDisplayLabel_14
			// 
			this._txtDisplayLabel_14.AllowDrop = true;
			this._txtDisplayLabel_14.Location = new System.Drawing.Point(235, 91);
			this._txtDisplayLabel_14.Name = "_txtDisplayLabel_14";
			this._txtDisplayLabel_14.Size = new System.Drawing.Size(247, 19);
			this._txtDisplayLabel_14.TabIndex = 32;
			this._txtDisplayLabel_14.TabStop = false;
			// 
			// System.Windows.Forms.Label1
			// 
			this.Label1.AllowDrop = true;
			this.Label1.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.Label1.Text = "Penalty Action ";
			this.Label1.Location = new System.Drawing.Point(6, 261);
			// this.Label1.mLabelId = 2069;
			this.Label1.Name = "System.Windows.Forms.Label1";
			this.Label1.Size = new System.Drawing.Size(72, 14);
			this.Label1.TabIndex = 33;
			// 
			// _txtCommonTextBox_5
			// 
			this._txtCommonTextBox_5.AllowDrop = true;
			this._txtCommonTextBox_5.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_5.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_5.Location = new System.Drawing.Point(131, 259);
			this._txtCommonTextBox_5.MaxLength = 100;
			this._txtCommonTextBox_5.Name = "_txtCommonTextBox_5";
			this._txtCommonTextBox_5.Size = new System.Drawing.Size(351, 19);
			this._txtCommonTextBox_5.TabIndex = 12;
			this._txtCommonTextBox_5.Text = "";
			// this.this._txtCommonTextBox_5.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_5.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _txtCommonTextBox_0
			// 
			this._txtCommonTextBox_0.AllowDrop = true;
			this._txtCommonTextBox_0.BackColor = System.Drawing.Color.White;
			// this._txtCommonTextBox_0.bolNumericOnly = true;
			this._txtCommonTextBox_0.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_0.Location = new System.Drawing.Point(132, 48);
			// this._txtCommonTextBox_0.mDropDownType = System.Windows.Forms.TextBox.DropDownTypes.ddtNextNumber;
			this._txtCommonTextBox_0.Name = "_txtCommonTextBox_0";
			// this._txtCommonTextBox_0.ShowButton = true;
			this._txtCommonTextBox_0.Size = new System.Drawing.Size(102, 19);
			this._txtCommonTextBox_0.TabIndex = 0;
			this._txtCommonTextBox_0.Text = "";
			// this.this._txtCommonTextBox_0.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_0.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _txtCommonTextBox_1
			// 
			this._txtCommonTextBox_1.AllowDrop = true;
			this._txtCommonTextBox_1.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_1.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_1.Location = new System.Drawing.Point(132, 70);
			this._txtCommonTextBox_1.MaxLength = 10;
			this._txtCommonTextBox_1.Name = "_txtCommonTextBox_1";
			// this._txtCommonTextBox_1.ShowButton = true;
			this._txtCommonTextBox_1.Size = new System.Drawing.Size(101, 19);
			this._txtCommonTextBox_1.TabIndex = 2;
			this._txtCommonTextBox_1.Text = "";
			// this.this._txtCommonTextBox_1.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_1.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// txtPenaltyDays
			// 
			this.txtPenaltyDays.AllowDrop = true;
			// this.txtPenaltyDays.DisplayFormat = "####0.000###;;0.000;0.000";
			// this.txtPenaltyDays.Format = "###########0.000";
			this.txtPenaltyDays.Location = new System.Drawing.Point(132, 195);
			// this.txtPenaltyDays.MaxValue = 2147483647;
			// this.txtPenaltyDays.MinValue = 0;
			this.txtPenaltyDays.Name = "txtPenaltyDays";
			this.txtPenaltyDays.Size = new System.Drawing.Size(101, 19);
			this.txtPenaltyDays.TabIndex = 7;
			this.txtPenaltyDays.Text = "0.000";
			// this.txtPenaltyDays.Leave += new System.EventHandler(this.txtPenaltyDays_Leave);
			// 
			// _lblCommonLabel_3
			// 
			this._lblCommonLabel_3.AllowDrop = true;
			this._lblCommonLabel_3.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_3.Text = "Penalty Days";
			this._lblCommonLabel_3.Location = new System.Drawing.Point(6, 197);
			// // this._lblCommonLabel_3.mLabelId = 2064;
			this._lblCommonLabel_3.Name = "_lblCommonLabel_3";
			this._lblCommonLabel_3.Size = new System.Drawing.Size(63, 14);
			this._lblCommonLabel_3.TabIndex = 34;
			// 
			// txtPenaltyAmount
			// 
			this.txtPenaltyAmount.AllowDrop = true;
			// this.txtPenaltyAmount.DisplayFormat = "####0.000###;;0.000;0.000";
			// this.txtPenaltyAmount.Format = "###########0.000";
			this.txtPenaltyAmount.Location = new System.Drawing.Point(132, 217);
			// this.txtPenaltyAmount.MaxValue = 2147483647;
			// this.txtPenaltyAmount.MinValue = 0;
			this.txtPenaltyAmount.Name = "txtPenaltyAmount";
			this.txtPenaltyAmount.Size = new System.Drawing.Size(101, 19);
			this.txtPenaltyAmount.TabIndex = 8;
			this.txtPenaltyAmount.Text = "0.000";
			// this.txtPenaltyAmount.Leave += new System.EventHandler(this.txtPenaltyAmount_Leave);
			// 
			// _lblCommonLabel_7
			// 
			this._lblCommonLabel_7.AllowDrop = true;
			this._lblCommonLabel_7.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_7.Text = "Penalty Amount";
			this._lblCommonLabel_7.Location = new System.Drawing.Point(6, 219);
			// // this._lblCommonLabel_7.mLabelId = 2065;
			this._lblCommonLabel_7.Name = "_lblCommonLabel_7";
			this._lblCommonLabel_7.Size = new System.Drawing.Size(75, 14);
			this._lblCommonLabel_7.TabIndex = 35;
			// 
			// _lblCommonLabel_9
			// 
			this._lblCommonLabel_9.AllowDrop = true;
			this._lblCommonLabel_9.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_9.Text = "Deduction  Date  ";
			this._lblCommonLabel_9.Location = new System.Drawing.Point(244, 176);
			// // this._lblCommonLabel_9.mLabelId = 2066;
			this._lblCommonLabel_9.Name = "_lblCommonLabel_9";
			this._lblCommonLabel_9.Size = new System.Drawing.Size(82, 14);
			this._lblCommonLabel_9.TabIndex = 36;
			// 
			// txtDeductionDate
			// 
			this.txtDeductionDate.AllowDrop = true;
			// this.txtDeductionDate.CheckDateRange = false;
			this.txtDeductionDate.Location = new System.Drawing.Point(380, 174);
			// this.txtDeductionDate.MaxDate = 2958465;
			// this.txtDeductionDate.MinDate = 32874;
			this.txtDeductionDate.Name = "txtDeductionDate";
			this.txtDeductionDate.Size = new System.Drawing.Size(102, 19);
			this.txtDeductionDate.TabIndex = 9;
			// this.txtDeductionDate.Text = "18/07/2001";
			// this.txtDeductionDate.Value = 37090;
			// 
			// txtNRepeatDeductPer
			// 
			this.txtNRepeatDeductPer.AllowDrop = true;
			// this.txtNRepeatDeductPer.DisplayFormat = "####0.000###;;0.000;0.000";
			// this.txtNRepeatDeductPer.Format = "###########0.000";
			this.txtNRepeatDeductPer.Location = new System.Drawing.Point(380, 195);
			// this.txtNRepeatDeductPer.MaxValue = 2147483647;
			// this.txtNRepeatDeductPer.MinValue = 0;
			this.txtNRepeatDeductPer.Name = "txtNRepeatDeductPer";
			this.txtNRepeatDeductPer.ReadOnly = true;
			this.txtNRepeatDeductPer.Size = new System.Drawing.Size(101, 19);
			this.txtNRepeatDeductPer.TabIndex = 10;
			this.txtNRepeatDeductPer.Text = "0.000";
			// 
			// _lblCommonLabel_11
			// 
			this._lblCommonLabel_11.AllowDrop = true;
			this._lblCommonLabel_11.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_11.Text = "Repeat Deduct  %";
			this._lblCommonLabel_11.Location = new System.Drawing.Point(244, 197);
			this._lblCommonLabel_11.Name = "_lblCommonLabel_11";
			this._lblCommonLabel_11.Size = new System.Drawing.Size(87, 14);
			this._lblCommonLabel_11.TabIndex = 37;
			// 
			// _lblCommonLabel_12
			// 
			this._lblCommonLabel_12.AllowDrop = true;
			this._lblCommonLabel_12.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_12.Text = "Actual Penalty From";
			this._lblCommonLabel_12.Location = new System.Drawing.Point(7, 155);
			this._lblCommonLabel_12.Name = "_lblCommonLabel_12";
			this._lblCommonLabel_12.Size = new System.Drawing.Size(96, 14);
			this._lblCommonLabel_12.TabIndex = 38;
			// 
			// txtActualPenaltyDate
			// 
			this.txtActualPenaltyDate.AllowDrop = true;
			// this.txtActualPenaltyDate.CheckDateRange = false;
			this.txtActualPenaltyDate.Location = new System.Drawing.Point(131, 153);
			// this.txtActualPenaltyDate.MaxDate = 2958465;
			// this.txtActualPenaltyDate.MinDate = 32874;
			this.txtActualPenaltyDate.Name = "txtActualPenaltyDate";
			this.txtActualPenaltyDate.Size = new System.Drawing.Size(102, 19);
			this.txtActualPenaltyDate.TabIndex = 4;
			// this.txtActualPenaltyDate.Text = "18/07/2001";
			// this.txtActualPenaltyDate.Value = 37090;
			// this.txtActualPenaltyDate.Leave += new System.EventHandler(this.txtActualPenaltyDate_Leave);
			// 
			// _lblCommonLabel_13
			// 
			this._lblCommonLabel_13.AllowDrop = true;
			this._lblCommonLabel_13.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_13.Text = "Actual Penalty To";
			this._lblCommonLabel_13.Location = new System.Drawing.Point(246, 156);
			this._lblCommonLabel_13.Name = "_lblCommonLabel_13";
			this._lblCommonLabel_13.Size = new System.Drawing.Size(84, 14);
			this._lblCommonLabel_13.TabIndex = 39;
			// 
			// txtActualPenaltyTo
			// 
			this.txtActualPenaltyTo.AllowDrop = true;
			// this.txtActualPenaltyTo.CheckDateRange = false;
			this.txtActualPenaltyTo.Location = new System.Drawing.Point(380, 153);
			// this.txtActualPenaltyTo.MaxDate = 2958465;
			// this.txtActualPenaltyTo.MinDate = 32874;
			this.txtActualPenaltyTo.Name = "txtActualPenaltyTo";
			this.txtActualPenaltyTo.Size = new System.Drawing.Size(102, 19);
			this.txtActualPenaltyTo.TabIndex = 5;
			this.txtActualPenaltyTo.Text = "18/07/2001";
			// this.txtActualPenaltyTo.Value = 37090;
			// 
			// frmPayPenaltyTrans
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.ClientSize = new System.Drawing.Size(486, 304);
			this.Controls.Add(this._lblCommonLabel_5);
			this.Controls.Add(this._lblCommonLabel_6);
			this.Controls.Add(this.txtVoucherDate);
			this.Controls.Add(this._lblCommonLabel_2);
			this.Controls.Add(this._lblCommonLabel_0);
			this.Controls.Add(this._lblCommonLabel_1);
			this.Controls.Add(this.txtMonthPercent);
			this.Controls.Add(this._lblCommonLabel_10);
			this.Controls.Add(this.txtPenaltyDeductionAmount);
			this.Controls.Add(this._lblCommonLabel_4);
			this.Controls.Add(this._lblCommonLabel_8);
			this.Controls.Add(this._lblCommonLabel_16);
			this.Controls.Add(this.txtStartDeductionDate);
			this.Controls.Add(this.Label12);
			this.Controls.Add(this._txtCommonTextBox_3);
			this.Controls.Add(this._txtDisplayLabel_5);
			this.Controls.Add(this._txtDisplayLabel_3);
			this.Controls.Add(this._txtDisplayLabel_2);
			this.Controls.Add(this._txtDisplayLabel_1);
			this.Controls.Add(this._txtDisplayLabel_0);
			this.Controls.Add(this._txtDisplayLabel_13);
			this.Controls.Add(this._lblCommonLabel_18);
			this.Controls.Add(this._txtCommonTextBox_4);
			this.Controls.Add(this._txtDisplayLabel_14);
			this.Controls.Add(this.Label1);
			this.Controls.Add(this._txtCommonTextBox_5);
			this.Controls.Add(this._txtCommonTextBox_0);
			this.Controls.Add(this._txtCommonTextBox_1);
			this.Controls.Add(this.txtPenaltyDays);
			this.Controls.Add(this._lblCommonLabel_3);
			this.Controls.Add(this.txtPenaltyAmount);
			this.Controls.Add(this._lblCommonLabel_7);
			this.Controls.Add(this._lblCommonLabel_9);
			this.Controls.Add(this.txtDeductionDate);
			this.Controls.Add(this.txtNRepeatDeductPer);
			this.Controls.Add(this._lblCommonLabel_11);
			this.Controls.Add(this._lblCommonLabel_12);
			this.Controls.Add(this.txtActualPenaltyDate);
			this.Controls.Add(this._lblCommonLabel_13);
			this.Controls.Add(this.txtActualPenaltyTo);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			//this.Icon = (System.Drawing.Icon) resources.GetObject("frmPayPenaltyTrans.Icon");
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(227, 129);
			this.MaximizeBox = true;
			this.MinimizeBox = true;
			this.Name = "frmPayPenaltyTrans";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Penalty Transaction";
			// this.Activated += new System.EventHandler(this.frmPayPenaltyTrans_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
			// this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
			this.ResumeLayout(false);
		}
		// 
		void InitializetxtDisplayLabel()
		{
			this.txtDisplayLabel = new System.Windows.Forms.Label[15];
			this.txtDisplayLabel[5] = _txtDisplayLabel_5;
			this.txtDisplayLabel[3] = _txtDisplayLabel_3;
			this.txtDisplayLabel[2] = _txtDisplayLabel_2;
			this.txtDisplayLabel[1] = _txtDisplayLabel_1;
			this.txtDisplayLabel[0] = _txtDisplayLabel_0;
			this.txtDisplayLabel[13] = _txtDisplayLabel_13;
			this.txtDisplayLabel[14] = _txtDisplayLabel_14;
		}
		void InitializetxtCommonTextBox()
		{
			this.txtCommonTextBox = new System.Windows.Forms.TextBox[6];
			this.txtCommonTextBox[3] = _txtCommonTextBox_3;
			this.txtCommonTextBox[4] = _txtCommonTextBox_4;
			this.txtCommonTextBox[5] = _txtCommonTextBox_5;
			this.txtCommonTextBox[0] = _txtCommonTextBox_0;
			this.txtCommonTextBox[1] = _txtCommonTextBox_1;
		}
		void InitializelblCommonLabel()
		{
			this.lblCommonLabel = new System.Windows.Forms.Label[19];
			this.lblCommonLabel[5] = _lblCommonLabel_5;
			this.lblCommonLabel[6] = _lblCommonLabel_6;
			this.lblCommonLabel[2] = _lblCommonLabel_2;
			this.lblCommonLabel[0] = _lblCommonLabel_0;
			this.lblCommonLabel[1] = _lblCommonLabel_1;
			this.lblCommonLabel[10] = _lblCommonLabel_10;
			this.lblCommonLabel[4] = _lblCommonLabel_4;
			this.lblCommonLabel[8] = _lblCommonLabel_8;
			this.lblCommonLabel[16] = _lblCommonLabel_16;
			this.lblCommonLabel[18] = _lblCommonLabel_18;
			this.lblCommonLabel[3] = _lblCommonLabel_3;
			this.lblCommonLabel[7] = _lblCommonLabel_7;
			this.lblCommonLabel[9] = _lblCommonLabel_9;
			this.lblCommonLabel[11] = _lblCommonLabel_11;
			this.lblCommonLabel[12] = _lblCommonLabel_12;
			this.lblCommonLabel[13] = _lblCommonLabel_13;
		}
		#endregion
	}
}//ENDSHERE
