
namespace Xtreme
{
	partial class frmPayEmployeeIndemnity
	{

		#region "Upgrade Support "
		private static frmPayEmployeeIndemnity m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmPayEmployeeIndemnity DefInstance
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
		public static frmPayEmployeeIndemnity CreateInstance()
		{
			frmPayEmployeeIndemnity theInstance = new frmPayEmployeeIndemnity();
			
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
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "_lblCommon_10", "_lblCommon_9", "_txtCommonNumber_1", "_txtCommonNumber_0", "fraFixedLeaveInfo", "_lblCommon_8", "_lblCommon_11", "_txtCommonNumber_3", "_txtCommonNumber_2", "Frame1", "lblSystemComponents", "_lblCommon_113", "_txtDisplayLabel_0", "_txtDisplayLabel_1", "_lblCommon_5", "_lblCommon_15", "txtOpeningBalanceAsOn", "_txtCommonNumber_4", "_CmbCommon_0", "_lblCommon_2", "_lblCommon_12", "_CmbCommon_1", "_lblCommon_19", "_lblCommon_0", "_txtCommon_0", "_lblCommon_4", "_txtDisplayLabel_5", "_txtDisplayLabel_4", "_CmbCommon_2", "_lblCommon_1", "Line1", "CmbCommon", "lblCommon", "txtCommon", "txtCommonNumber", "txtDisplayLabel"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		private System.Windows.Forms.Label _lblCommon_10;
		private System.Windows.Forms.Label _lblCommon_9;
		private System.Windows.Forms.TextBox _txtCommonNumber_1;
		private System.Windows.Forms.TextBox _txtCommonNumber_0;
		public System.Windows.Forms.GroupBox fraFixedLeaveInfo;
		private System.Windows.Forms.Label _lblCommon_8;
		private System.Windows.Forms.Label _lblCommon_11;
		private System.Windows.Forms.TextBox _txtCommonNumber_3;
		private System.Windows.Forms.TextBox _txtCommonNumber_2;
		public System.Windows.Forms.GroupBox Frame1;
		public System.Windows.Forms.Label lblSystemComponents;
		private System.Windows.Forms.Label _lblCommon_113;
		private System.Windows.Forms.Label _txtDisplayLabel_0;
		private System.Windows.Forms.Label _txtDisplayLabel_1;
		private System.Windows.Forms.Label _lblCommon_5;
		private System.Windows.Forms.Label _lblCommon_15;
		public Syncfusion.WinForms.Input.SfDateTimeEdit txtOpeningBalanceAsOn;
		private System.Windows.Forms.TextBox _txtCommonNumber_4;
		private System.Windows.Forms.ComboBox _CmbCommon_0;
		private System.Windows.Forms.Label _lblCommon_2;
		private System.Windows.Forms.Label _lblCommon_12;
		private System.Windows.Forms.ComboBox _CmbCommon_1;
		private System.Windows.Forms.Label _lblCommon_19;
		private System.Windows.Forms.Label _lblCommon_0;
		private System.Windows.Forms.TextBox _txtCommon_0;
		private System.Windows.Forms.Label _lblCommon_4;
		private System.Windows.Forms.Label _txtDisplayLabel_5;
		private System.Windows.Forms.Label _txtDisplayLabel_4;
		private System.Windows.Forms.ComboBox _CmbCommon_2;
		private System.Windows.Forms.Label _lblCommon_1;
		public System.Windows.Forms.Label Line1;
		public System.Windows.Forms.ComboBox[] CmbCommon = new System.Windows.Forms.ComboBox[3];
		public System.Windows.Forms.Label[] lblCommon = new System.Windows.Forms.Label[114];
		public System.Windows.Forms.TextBox[] txtCommon = new System.Windows.Forms.TextBox[1];
		public System.Windows.Forms.TextBox[] txtCommonNumber = new System.Windows.Forms.TextBox[5];
		public System.Windows.Forms.Label[] txtDisplayLabel = new System.Windows.Forms.Label[6];
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPayEmployeeIndemnity));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this.fraFixedLeaveInfo = new System.Windows.Forms.GroupBox();
			this._lblCommon_10 = new System.Windows.Forms.Label();
			this._lblCommon_9 = new System.Windows.Forms.Label();
			this._txtCommonNumber_1 = new System.Windows.Forms.TextBox();
			this._txtCommonNumber_0 = new System.Windows.Forms.TextBox();
			this.Frame1 = new System.Windows.Forms.GroupBox();
			this._lblCommon_8 = new System.Windows.Forms.Label();
			this._lblCommon_11 = new System.Windows.Forms.Label();
			this._txtCommonNumber_3 = new System.Windows.Forms.TextBox();
			this._txtCommonNumber_2 = new System.Windows.Forms.TextBox();
			this.lblSystemComponents = new System.Windows.Forms.Label();
			this._lblCommon_113 = new System.Windows.Forms.Label();
			this._txtDisplayLabel_0 = new System.Windows.Forms.Label();
			this._txtDisplayLabel_1 = new System.Windows.Forms.Label();
			this._lblCommon_5 = new System.Windows.Forms.Label();
			this._lblCommon_15 = new System.Windows.Forms.Label();
			this.txtOpeningBalanceAsOn = new Syncfusion.WinForms.Input.SfDateTimeEdit();
			this._txtCommonNumber_4 = new System.Windows.Forms.TextBox();
			this._CmbCommon_0 = new System.Windows.Forms.ComboBox();
			this._lblCommon_2 = new System.Windows.Forms.Label();
			this._lblCommon_12 = new System.Windows.Forms.Label();
			this._CmbCommon_1 = new System.Windows.Forms.ComboBox();
			this._lblCommon_19 = new System.Windows.Forms.Label();
			this._lblCommon_0 = new System.Windows.Forms.Label();
			this._txtCommon_0 = new System.Windows.Forms.TextBox();
			this._lblCommon_4 = new System.Windows.Forms.Label();
			this._txtDisplayLabel_5 = new System.Windows.Forms.Label();
			this._txtDisplayLabel_4 = new System.Windows.Forms.Label();
			this._CmbCommon_2 = new System.Windows.Forms.ComboBox();
			this._lblCommon_1 = new System.Windows.Forms.Label();
			this.Line1 = new System.Windows.Forms.Label();
			this.fraFixedLeaveInfo.SuspendLayout();
			this.Frame1.SuspendLayout();
			this.SuspendLayout();
			// 
			// fraFixedLeaveInfo
			// 
			this.fraFixedLeaveInfo.AllowDrop = true;
			this.fraFixedLeaveInfo.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.fraFixedLeaveInfo.Controls.Add(this._lblCommon_10);
			this.fraFixedLeaveInfo.Controls.Add(this._lblCommon_9);
			this.fraFixedLeaveInfo.Controls.Add(this._txtCommonNumber_1);
			this.fraFixedLeaveInfo.Controls.Add(this._txtCommonNumber_0);
			this.fraFixedLeaveInfo.Enabled = true;
			this.fraFixedLeaveInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 178);
			this.fraFixedLeaveInfo.ForeColor = System.Drawing.Color.FromArgb(53, 91, 225);
			this.fraFixedLeaveInfo.Location = new System.Drawing.Point(8, 130);
			this.fraFixedLeaveInfo.Name = "fraFixedLeaveInfo";
			this.fraFixedLeaveInfo.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.fraFixedLeaveInfo.Size = new System.Drawing.Size(283, 63);
			this.fraFixedLeaveInfo.TabIndex = 9;
			this.fraFixedLeaveInfo.Text = " Before Switch Over Period ";
			this.fraFixedLeaveInfo.Visible = true;
			// 
			// _lblCommon_10
			// 
			this._lblCommon_10.AllowDrop = true;
			this._lblCommon_10.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_10.Text = "Indemnity Days";
			this._lblCommon_10.Location = new System.Drawing.Point(10, 21);
			// // this._lblCommon_10.mLabelId = 1092;
			this._lblCommon_10.Name = "_lblCommon_10";
			this._lblCommon_10.Size = new System.Drawing.Size(75, 13);
			this._lblCommon_10.TabIndex = 10;
			// 
			// _lblCommon_9
			// 
			this._lblCommon_9.AllowDrop = true;
			this._lblCommon_9.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_9.Text = "Working Days Per Month";
			this._lblCommon_9.Location = new System.Drawing.Point(10, 42);
			// // this._lblCommon_9.mLabelId = 1093;
			this._lblCommon_9.Name = "_lblCommon_9";
			this._lblCommon_9.Size = new System.Drawing.Size(118, 13);
			this._lblCommon_9.TabIndex = 11;
			// 
			// _txtCommonNumber_1
			// 
			this._txtCommonNumber_1.AllowDrop = true;
			// this._txtCommonNumber_1.DisplayFormat = "####0.000###;;0.000;0.000";
			// this._txtCommonNumber_1.Format = "###########0.000";
			this._txtCommonNumber_1.Location = new System.Drawing.Point(162, 39);
			// this._txtCommonNumber_1.MaxValue = 2147483647;
			// this._txtCommonNumber_1.MinValue = 0;
			this._txtCommonNumber_1.Name = "_txtCommonNumber_1";
			this._txtCommonNumber_1.Size = new System.Drawing.Size(101, 19);
			this._txtCommonNumber_1.TabIndex = 12;
			this._txtCommonNumber_1.Text = "0.000";
			// 
			// _txtCommonNumber_0
			// 
			this._txtCommonNumber_0.AllowDrop = true;
			// this._txtCommonNumber_0.DisplayFormat = "####0.000###;;0.000;0.000";
			// this._txtCommonNumber_0.Format = "###########0.000";
			this._txtCommonNumber_0.Location = new System.Drawing.Point(162, 18);
			// this._txtCommonNumber_0.MaxValue = 2147483647;
			// this._txtCommonNumber_0.MinValue = 0;
			this._txtCommonNumber_0.Name = "_txtCommonNumber_0";
			this._txtCommonNumber_0.Size = new System.Drawing.Size(101, 19);
			this._txtCommonNumber_0.TabIndex = 13;
			this._txtCommonNumber_0.Text = "0.000";
			// 
			// Frame1
			// 
			this.Frame1.AllowDrop = true;
			this.Frame1.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.Frame1.Controls.Add(this._lblCommon_8);
			this.Frame1.Controls.Add(this._lblCommon_11);
			this.Frame1.Controls.Add(this._txtCommonNumber_3);
			this.Frame1.Controls.Add(this._txtCommonNumber_2);
			this.Frame1.Enabled = true;
			this.Frame1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 178);
			this.Frame1.ForeColor = System.Drawing.Color.FromArgb(53, 91, 225);
			this.Frame1.Location = new System.Drawing.Point(352, 128);
			this.Frame1.Name = "Frame1";
			this.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Frame1.Size = new System.Drawing.Size(281, 63);
			this.Frame1.TabIndex = 4;
			this.Frame1.Text = " After Switch Over Period ";
			this.Frame1.Visible = true;
			// 
			// _lblCommon_8
			// 
			this._lblCommon_8.AllowDrop = true;
			this._lblCommon_8.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_8.Text = "Indemnity Days";
			this._lblCommon_8.Location = new System.Drawing.Point(10, 21);
			// // this._lblCommon_8.mLabelId = 1092;
			this._lblCommon_8.Name = "_lblCommon_8";
			this._lblCommon_8.Size = new System.Drawing.Size(75, 13);
			this._lblCommon_8.TabIndex = 5;
			// 
			// _lblCommon_11
			// 
			this._lblCommon_11.AllowDrop = true;
			this._lblCommon_11.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_11.Text = "Working Days Per Month";
			this._lblCommon_11.Location = new System.Drawing.Point(10, 42);
			// // this._lblCommon_11.mLabelId = 1093;
			this._lblCommon_11.Name = "_lblCommon_11";
			this._lblCommon_11.Size = new System.Drawing.Size(118, 13);
			this._lblCommon_11.TabIndex = 6;
			// 
			// _txtCommonNumber_3
			// 
			this._txtCommonNumber_3.AllowDrop = true;
			// this._txtCommonNumber_3.DisplayFormat = "####0.000###;;0.000;0.000";
			// this._txtCommonNumber_3.Format = "###########0.000";
			this._txtCommonNumber_3.Location = new System.Drawing.Point(164, 39);
			// this._txtCommonNumber_3.MaxValue = 2147483647;
			// this._txtCommonNumber_3.MinValue = 0;
			this._txtCommonNumber_3.Name = "_txtCommonNumber_3";
			this._txtCommonNumber_3.Size = new System.Drawing.Size(101, 19);
			this._txtCommonNumber_3.TabIndex = 7;
			this._txtCommonNumber_3.Text = "0.000";
			// 
			// _txtCommonNumber_2
			// 
			this._txtCommonNumber_2.AllowDrop = true;
			// this._txtCommonNumber_2.DisplayFormat = "####0.000###;;0.000;0.000";
			// this._txtCommonNumber_2.Format = "###########0.000";
			this._txtCommonNumber_2.Location = new System.Drawing.Point(164, 18);
			// this._txtCommonNumber_2.MaxValue = 2147483647;
			// this._txtCommonNumber_2.MinValue = 0;
			this._txtCommonNumber_2.Name = "_txtCommonNumber_2";
			this._txtCommonNumber_2.Size = new System.Drawing.Size(101, 19);
			this._txtCommonNumber_2.TabIndex = 8;
			this._txtCommonNumber_2.Text = "0.000";
			// 
			// lblSystemComponents
			// 
			this.lblSystemComponents.AllowDrop = true;
			this.lblSystemComponents.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblSystemComponents.Text = " Indemnity Information ";
			this.lblSystemComponents.Location = new System.Drawing.Point(12, 82);
			// // this.lblSystemComponents.mLabelId = 1086;
			this.lblSystemComponents.Name = "lblSystemComponents";
			this.lblSystemComponents.Size = new System.Drawing.Size(136, 13);
			this.lblSystemComponents.TabIndex = 0;
			// 
			// _lblCommon_113
			// 
			this._lblCommon_113.AllowDrop = true;
			this._lblCommon_113.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_113.Text = "Employee Code";
			this._lblCommon_113.Location = new System.Drawing.Point(24, 53);
			// // this._lblCommon_113.mLabelId = 236;
			this._lblCommon_113.Name = "_lblCommon_113";
			this._lblCommon_113.Size = new System.Drawing.Size(74, 14);
			this._lblCommon_113.TabIndex = 1;
			// 
			// _txtDisplayLabel_0
			// 
			this._txtDisplayLabel_0.AllowDrop = true;
			this._txtDisplayLabel_0.Location = new System.Drawing.Point(108, 50);
			this._txtDisplayLabel_0.Name = "_txtDisplayLabel_0";
			this._txtDisplayLabel_0.Size = new System.Drawing.Size(101, 19);
			this._txtDisplayLabel_0.TabIndex = 2;
			// 
			// _txtDisplayLabel_1
			// 
			this._txtDisplayLabel_1.AllowDrop = true;
			this._txtDisplayLabel_1.Location = new System.Drawing.Point(211, 50);
			this._txtDisplayLabel_1.Name = "_txtDisplayLabel_1";
			this._txtDisplayLabel_1.Size = new System.Drawing.Size(201, 19);
			this._txtDisplayLabel_1.TabIndex = 3;
			// 
			// _lblCommon_5
			// 
			this._lblCommon_5.AllowDrop = true;
			this._lblCommon_5.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_5.Text = "Opening Indemnity Balance (Days)";
			this._lblCommon_5.Location = new System.Drawing.Point(10, 258);
			// // this._lblCommon_5.mLabelId = 1090;
			this._lblCommon_5.Name = "_lblCommon_5";
			this._lblCommon_5.Size = new System.Drawing.Size(166, 13);
			this._lblCommon_5.TabIndex = 14;
			this._lblCommon_5.Visible = false;
			// 
			// _lblCommon_15
			// 
			this._lblCommon_15.AllowDrop = true;
			this._lblCommon_15.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_15.Text = "As On";
			this._lblCommon_15.Location = new System.Drawing.Point(298, 257);
			// // this._lblCommon_15.mLabelId = 1094;
			this._lblCommon_15.Name = "_lblCommon_15";
			this._lblCommon_15.Size = new System.Drawing.Size(29, 13);
			this._lblCommon_15.TabIndex = 15;
			this._lblCommon_15.Visible = false;
			// 
			// txtOpeningBalanceAsOn
			// 
			this.txtOpeningBalanceAsOn.AllowDrop = true;
			// this.txtOpeningBalanceAsOn.CheckDateRange = false;
			this.txtOpeningBalanceAsOn.Location = new System.Drawing.Point(331, 255);
			// this.txtOpeningBalanceAsOn.MaxDate = 2958465;
			// this.txtOpeningBalanceAsOn.MinDate = 2;
			this.txtOpeningBalanceAsOn.Name = "txtOpeningBalanceAsOn";
			this.txtOpeningBalanceAsOn.Size = new System.Drawing.Size(91, 19);
			this.txtOpeningBalanceAsOn.TabIndex = 16;
			this.txtOpeningBalanceAsOn.Text = "06/04/2006";
			// this.txtOpeningBalanceAsOn.Value = 38813;
			this.txtOpeningBalanceAsOn.Visible = false;
			// 
			// _txtCommonNumber_4
			// 
			this._txtCommonNumber_4.AllowDrop = true;
			// this._txtCommonNumber_4.DisplayFormat = "####0.000###;;0.000;0.000";
			// this._txtCommonNumber_4.Format = "###########0.000";
			this._txtCommonNumber_4.Location = new System.Drawing.Point(190, 255);
			// this._txtCommonNumber_4.MaxValue = 2147483647;
			// this._txtCommonNumber_4.MinValue = 0;
			this._txtCommonNumber_4.Name = "_txtCommonNumber_4";
			this._txtCommonNumber_4.Size = new System.Drawing.Size(101, 19);
			this._txtCommonNumber_4.TabIndex = 17;
			this._txtCommonNumber_4.Text = "0.000";
			this._txtCommonNumber_4.Visible = false;
			// 
			// _CmbCommon_0
			// 
			this._CmbCommon_0.AllowDrop = true;
			this._CmbCommon_0.Location = new System.Drawing.Point(236, 204);
			this._CmbCommon_0.Name = "_CmbCommon_0";
			this._CmbCommon_0.Size = new System.Drawing.Size(55, 21);
			this._CmbCommon_0.TabIndex = 18;
			// 
			// _lblCommon_2
			// 
			this._lblCommon_2.AllowDrop = true;
			this._lblCommon_2.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_2.Text = "Deduct Paid Days";
			this._lblCommon_2.Location = new System.Drawing.Point(10, 208);
			// // this._lblCommon_2.mLabelId = 1089;
			this._lblCommon_2.Name = "_lblCommon_2";
			this._lblCommon_2.Size = new System.Drawing.Size(84, 13);
			this._lblCommon_2.TabIndex = 19;
			// 
			// _lblCommon_12
			// 
			this._lblCommon_12.AllowDrop = true;
			this._lblCommon_12.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_12.Text = "Deduct Unpaid Days";
			this._lblCommon_12.Location = new System.Drawing.Point(428, 204);
			// // this._lblCommon_12.mLabelId = 1095;
			this._lblCommon_12.Name = "_lblCommon_12";
			this._lblCommon_12.Size = new System.Drawing.Size(97, 13);
			this._lblCommon_12.TabIndex = 20;
			// 
			// _CmbCommon_1
			// 
			this._CmbCommon_1.AllowDrop = true;
			this._CmbCommon_1.Location = new System.Drawing.Point(578, 204);
			this._CmbCommon_1.Name = "_CmbCommon_1";
			this._CmbCommon_1.Size = new System.Drawing.Size(55, 21);
			this._CmbCommon_1.TabIndex = 21;
			// 
			// _lblCommon_19
			// 
			this._lblCommon_19.AllowDrop = true;
			this._lblCommon_19.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_19.Text = "Indemnity Balance As Of";
			this._lblCommon_19.Location = new System.Drawing.Point(10, 279);
			// // this._lblCommon_19.mLabelId = 1091;
			this._lblCommon_19.Name = "_lblCommon_19";
			this._lblCommon_19.Size = new System.Drawing.Size(118, 13);
			this._lblCommon_19.TabIndex = 22;
			// 
			// _lblCommon_0
			// 
			this._lblCommon_0.AllowDrop = true;
			this._lblCommon_0.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_0.Text = "Indemnity Swich Over Period (Year)";
			this._lblCommon_0.Location = new System.Drawing.Point(8, 103);
			// // this._lblCommon_0.mLabelId = 1087;
			this._lblCommon_0.Name = "_lblCommon_0";
			this._lblCommon_0.Size = new System.Drawing.Size(171, 13);
			this._lblCommon_0.TabIndex = 23;
			// 
			// _txtCommon_0
			// 
			this._txtCommon_0.AllowDrop = true;
			this._txtCommon_0.BackColor = System.Drawing.Color.White;
			// this._txtCommon_0.bolNumericOnly = true;
			this._txtCommon_0.ForeColor = System.Drawing.Color.Black;
			this._txtCommon_0.Location = new System.Drawing.Point(188, 100);
			this._txtCommon_0.Name = "_txtCommon_0";
			this._txtCommon_0.Size = new System.Drawing.Size(101, 19);
			this._txtCommon_0.TabIndex = 24;
			this._txtCommon_0.Text = "";
			// this.this._txtCommon_0.Watermark = "";
			// 
			// _lblCommon_4
			// 
			this._lblCommon_4.AllowDrop = true;
			this._lblCommon_4.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_4.Text = "Indemnity Amount As Of";
			this._lblCommon_4.Location = new System.Drawing.Point(408, 279);
			// // this._lblCommon_4.mLabelId = 1096;
			this._lblCommon_4.Name = "_lblCommon_4";
			this._lblCommon_4.Size = new System.Drawing.Size(118, 13);
			this._lblCommon_4.TabIndex = 25;
			// 
			// _txtDisplayLabel_5
			// 
			// this._txtDisplayLabel_5.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
			this._txtDisplayLabel_5.AllowDrop = true;
			this._txtDisplayLabel_5.Location = new System.Drawing.Point(532, 276);
			this._txtDisplayLabel_5.Name = "_txtDisplayLabel_5";
			this._txtDisplayLabel_5.Size = new System.Drawing.Size(101, 19);
			this._txtDisplayLabel_5.TabIndex = 26;
			// 
			// _txtDisplayLabel_4
			// 
			// this._txtDisplayLabel_4.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
			this._txtDisplayLabel_4.AllowDrop = true;
			this._txtDisplayLabel_4.Location = new System.Drawing.Point(190, 276);
			this._txtDisplayLabel_4.Name = "_txtDisplayLabel_4";
			this._txtDisplayLabel_4.Size = new System.Drawing.Size(101, 19);
			this._txtDisplayLabel_4.TabIndex = 27;
			// 
			// _CmbCommon_2
			// 
			this._CmbCommon_2.AllowDrop = true;
			this._CmbCommon_2.Location = new System.Drawing.Point(235, 229);
			this._CmbCommon_2.Name = "_CmbCommon_2";
			this._CmbCommon_2.Size = new System.Drawing.Size(55, 21);
			this._CmbCommon_2.TabIndex = 28;
			// 
			// _lblCommon_1
			// 
			this._lblCommon_1.AllowDrop = true;
			this._lblCommon_1.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_1.Text = "Deduct Absent Days";
			this._lblCommon_1.Location = new System.Drawing.Point(10, 233);
			this._lblCommon_1.Name = "_lblCommon_1";
			this._lblCommon_1.Size = new System.Drawing.Size(98, 13);
			this._lblCommon_1.TabIndex = 29;
			// 
			// Line1
			// 
			this.Line1.AllowDrop = true;
			this.Line1.BackColor = System.Drawing.SystemColors.WindowText;
			this.Line1.Enabled = false;
			this.Line1.Location = new System.Drawing.Point(0, 90);
			this.Line1.Name = "Line1";
			this.Line1.Size = new System.Drawing.Size(660, 1);
			this.Line1.Visible = true;
			// 
			// frmPayEmployeeIndemnity
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.ClientSize = new System.Drawing.Size(1043, 492);
			this.Controls.Add(this.fraFixedLeaveInfo);
			this.Controls.Add(this.Frame1);
			this.Controls.Add(this.lblSystemComponents);
			this.Controls.Add(this._lblCommon_113);
			this.Controls.Add(this._txtDisplayLabel_0);
			this.Controls.Add(this._txtDisplayLabel_1);
			this.Controls.Add(this._lblCommon_5);
			this.Controls.Add(this._lblCommon_15);
			this.Controls.Add(this.txtOpeningBalanceAsOn);
			this.Controls.Add(this._txtCommonNumber_4);
			this.Controls.Add(this._CmbCommon_0);
			this.Controls.Add(this._lblCommon_2);
			this.Controls.Add(this._lblCommon_12);
			this.Controls.Add(this._CmbCommon_1);
			this.Controls.Add(this._lblCommon_19);
			this.Controls.Add(this._lblCommon_0);
			this.Controls.Add(this._txtCommon_0);
			this.Controls.Add(this._lblCommon_4);
			this.Controls.Add(this._txtDisplayLabel_5);
			this.Controls.Add(this._txtDisplayLabel_4);
			this.Controls.Add(this._CmbCommon_2);
			this.Controls.Add(this._lblCommon_1);
			this.Controls.Add(this.Line1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			//this.Icon = (System.Drawing.Icon) resources.GetObject("frmPayEmployeeIndemnity.Icon");
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(272, 211);
			this.MaximizeBox = true;
			this.MinimizeBox = true;
			this.Name = "frmPayEmployeeIndemnity";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Employee Indemnity";
			// this.Activated += new System.EventHandler(this.Form_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
			// this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
			this.fraFixedLeaveInfo.ResumeLayout(false);
			this.Frame1.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		void ReLoadForm(bool addEvents)
		{
			InitializetxtDisplayLabel();
			InitializetxtCommonNumber();
			InitializetxtCommon();
			InitializelblCommon();
			InitializeCmbCommon();
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
			this.txtDisplayLabel = new System.Windows.Forms.Label[6];
			this.txtDisplayLabel[0] = _txtDisplayLabel_0;
			this.txtDisplayLabel[1] = _txtDisplayLabel_1;
			this.txtDisplayLabel[5] = _txtDisplayLabel_5;
			this.txtDisplayLabel[4] = _txtDisplayLabel_4;
		}
		void InitializetxtCommonNumber()
		{
			this.txtCommonNumber = new System.Windows.Forms.TextBox[5];
			this.txtCommonNumber[1] = _txtCommonNumber_1;
			this.txtCommonNumber[0] = _txtCommonNumber_0;
			this.txtCommonNumber[3] = _txtCommonNumber_3;
			this.txtCommonNumber[2] = _txtCommonNumber_2;
			this.txtCommonNumber[4] = _txtCommonNumber_4;
		}
		void InitializetxtCommon()
		{
			this.txtCommon = new System.Windows.Forms.TextBox[1];
			this.txtCommon[0] = _txtCommon_0;
		}
		void InitializelblCommon()
		{
			this.lblCommon = new System.Windows.Forms.Label[114];
			this.lblCommon[10] = _lblCommon_10;
			this.lblCommon[9] = _lblCommon_9;
			this.lblCommon[8] = _lblCommon_8;
			this.lblCommon[11] = _lblCommon_11;
			this.lblCommon[113] = _lblCommon_113;
			this.lblCommon[5] = _lblCommon_5;
			this.lblCommon[15] = _lblCommon_15;
			this.lblCommon[2] = _lblCommon_2;
			this.lblCommon[12] = _lblCommon_12;
			this.lblCommon[19] = _lblCommon_19;
			this.lblCommon[0] = _lblCommon_0;
			this.lblCommon[4] = _lblCommon_4;
			this.lblCommon[1] = _lblCommon_1;
		}
		void InitializeCmbCommon()
		{
			this.CmbCommon = new System.Windows.Forms.ComboBox[3];
			this.CmbCommon[0] = _CmbCommon_0;
			this.CmbCommon[1] = _CmbCommon_1;
			this.CmbCommon[2] = _CmbCommon_2;
		}
		#endregion
	}
}//ENDSHERE
