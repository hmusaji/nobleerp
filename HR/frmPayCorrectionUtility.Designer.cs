
namespace Xtreme
{
	partial class frmPayCorrectionUtility
	{

		#region "Upgrade Support "
		private static frmPayCorrectionUtility m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmPayCorrectionUtility DefInstance
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
		public static frmPayCorrectionUtility CreateInstance()
		{
			frmPayCorrectionUtility theInstance = new frmPayCorrectionUtility();
			
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
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "Label1_0", "_optoption_2", "_optoption_1", "_optoption_0", "frmoption", "_lblCommonLabel_0", "txtResumtionTransNo", "txtGrantDays", "System.Windows.Forms.Label2", "Label1_1", "txtDisplayVariationDays", "txtEncashmentDays", "txtAdjustUnpaidDays", "txtAdjustPaidDays", "_lblCommonLabel_15", "_lblCommonLabel_16", "_lblCommonLabel_24", "txtActualResumeDate", "_lblCommonLabel_11", "frmResumtion", "txtLeaveTransNo", "_lblCommonLabel_5", "frmLeave", "txtDeductionHrs", "_lblCommonLabel_1", "_lblCommon_109", "txtJoiningDate", "frmEmployee", "tabCorrectionUtility", "_lblCommon_113", "txtEmployeeNo", "_txtDisplayLabel_1", "Line1", "System.Windows.Forms.Label1", "lblCommon", "lblCommonLabel", "optoption", "txtDisplayLabel"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		private System.Windows.Forms.Label Label1_0;
		private System.Windows.Forms.RadioButton _optoption_2;
		private System.Windows.Forms.RadioButton _optoption_1;
		private System.Windows.Forms.RadioButton _optoption_0;
		public System.Windows.Forms.GroupBox frmoption;
		private System.Windows.Forms.Label _lblCommonLabel_0;
		public System.Windows.Forms.TextBox txtResumtionTransNo;
		public System.Windows.Forms.TextBox txtGrantDays;
		public System.Windows.Forms.Label Label2;
		private System.Windows.Forms.Label Label1_1;
		public System.Windows.Forms.Label txtDisplayVariationDays;
		public System.Windows.Forms.TextBox txtEncashmentDays;
		public System.Windows.Forms.TextBox txtAdjustUnpaidDays;
		public System.Windows.Forms.TextBox txtAdjustPaidDays;
		private System.Windows.Forms.Label _lblCommonLabel_15;
		private System.Windows.Forms.Label _lblCommonLabel_16;
		private System.Windows.Forms.Label _lblCommonLabel_24;
		public Syncfusion.WinForms.Input.SfDateTimeEdit txtActualResumeDate;
		private System.Windows.Forms.Label _lblCommonLabel_11;
		public System.Windows.Forms.Panel frmResumtion;
		public System.Windows.Forms.TextBox txtLeaveTransNo;
		private System.Windows.Forms.Label _lblCommonLabel_5;
		public System.Windows.Forms.Panel frmLeave;
		public System.Windows.Forms.TextBox txtDeductionHrs;
		private System.Windows.Forms.Label _lblCommonLabel_1;
		private System.Windows.Forms.Label _lblCommon_109;
		public Syncfusion.WinForms.Input.SfDateTimeEdit txtJoiningDate;
		public System.Windows.Forms.Panel frmEmployee;
		public AxC1SizerLib.AxC1Tab tabCorrectionUtility;
		private System.Windows.Forms.Label _lblCommon_113;
		public System.Windows.Forms.TextBox txtEmployeeNo;
		private System.Windows.Forms.Label _txtDisplayLabel_1;
		public System.Windows.Forms.Label Line1;
		public System.Windows.Forms.Label[] Label1 = new System.Windows.Forms.Label[2];
		public System.Windows.Forms.Label[] lblCommon = new System.Windows.Forms.Label[114];
		public System.Windows.Forms.Label[] lblCommonLabel = new System.Windows.Forms.Label[25];
		public System.Windows.Forms.RadioButton[] optoption = new System.Windows.Forms.RadioButton[3];
		public System.Windows.Forms.Label[] txtDisplayLabel = new System.Windows.Forms.Label[2];
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPayCorrectionUtility));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this.Label1_0 = new System.Windows.Forms.Label();
			this.frmoption = new System.Windows.Forms.GroupBox();
			this._optoption_2 = new System.Windows.Forms.RadioButton();
			this._optoption_1 = new System.Windows.Forms.RadioButton();
			this._optoption_0 = new System.Windows.Forms.RadioButton();
			this.tabCorrectionUtility = new AxC1SizerLib.AxC1Tab();
			this.frmResumtion = new System.Windows.Forms.Panel();
			this._lblCommonLabel_0 = new System.Windows.Forms.Label();
			this.txtResumtionTransNo = new System.Windows.Forms.TextBox();
			this.txtGrantDays = new System.Windows.Forms.TextBox();
			this.Label2 = new System.Windows.Forms.Label();
			this.Label1_1 = new System.Windows.Forms.Label();
			this.txtDisplayVariationDays = new System.Windows.Forms.Label();
			this.txtEncashmentDays = new System.Windows.Forms.TextBox();
			this.txtAdjustUnpaidDays = new System.Windows.Forms.TextBox();
			this.txtAdjustPaidDays = new System.Windows.Forms.TextBox();
			this._lblCommonLabel_15 = new System.Windows.Forms.Label();
			this._lblCommonLabel_16 = new System.Windows.Forms.Label();
			this._lblCommonLabel_24 = new System.Windows.Forms.Label();
			this.txtActualResumeDate = new Syncfusion.WinForms.Input.SfDateTimeEdit();
			this._lblCommonLabel_11 = new System.Windows.Forms.Label();
			this.frmLeave = new System.Windows.Forms.Panel();
			this.txtLeaveTransNo = new System.Windows.Forms.TextBox();
			this._lblCommonLabel_5 = new System.Windows.Forms.Label();
			this.frmEmployee = new System.Windows.Forms.Panel();
			this.txtDeductionHrs = new System.Windows.Forms.TextBox();
			this._lblCommonLabel_1 = new System.Windows.Forms.Label();
			this._lblCommon_109 = new System.Windows.Forms.Label();
			this.txtJoiningDate = new Syncfusion.WinForms.Input.SfDateTimeEdit();
			this._lblCommon_113 = new System.Windows.Forms.Label();
			this.txtEmployeeNo = new System.Windows.Forms.TextBox();
			this._txtDisplayLabel_1 = new System.Windows.Forms.Label();
			this.Line1 = new System.Windows.Forms.Label();
			// //((System.ComponentModel.ISupportInitialize) this.tabCorrectionUtility).BeginInit();
			this.frmoption.SuspendLayout();
			this.tabCorrectionUtility.SuspendLayout();
			this.frmResumtion.SuspendLayout();
			this.frmLeave.SuspendLayout();
			this.frmEmployee.SuspendLayout();
			this.SuspendLayout();
			// 
			// Label1_0
			// 
			this.Label1_0.AllowDrop = true;
			this.Label1_0.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.Label1_0.Text = "Transaction For";
			this.Label1_0.Location = new System.Drawing.Point(8, 120);
			this.Label1_0.Name = "Label1_0";
			this.Label1_0.Size = new System.Drawing.Size(76, 14);
			this.Label1_0.TabIndex = 19;
			// 
			// frmoption
			// 
			this.frmoption.AllowDrop = true;
			this.frmoption.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.frmoption.Controls.Add(this._optoption_2);
			this.frmoption.Controls.Add(this._optoption_1);
			this.frmoption.Controls.Add(this._optoption_0);
			this.frmoption.Enabled = true;
			this.frmoption.ForeColor = System.Drawing.SystemColors.ControlText;
			this.frmoption.Location = new System.Drawing.Point(92, 96);
			this.frmoption.Name = "frmoption";
			this.frmoption.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.frmoption.Size = new System.Drawing.Size(645, 45);
			this.frmoption.TabIndex = 18;
			this.frmoption.Visible = true;
			// 
			// _optoption_2
			// 
			this._optoption_2.AllowDrop = true;
			this._optoption_2.Appearance = System.Windows.Forms.Appearance.Normal;
			this._optoption_2.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._optoption_2.CausesValidation = true;
			this._optoption_2.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._optoption_2.Checked = false;
			this._optoption_2.Enabled = true;
			this._optoption_2.ForeColor = System.Drawing.SystemColors.ControlText;
			this._optoption_2.Location = new System.Drawing.Point(432, 16);
			this._optoption_2.Name = "_optoption_2";
			this._optoption_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._optoption_2.Size = new System.Drawing.Size(201, 17);
			this._optoption_2.TabIndex = 3;
			this._optoption_2.TabStop = true;
			this._optoption_2.Text = "Resumtion";
			this._optoption_2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._optoption_2.Visible = true;
			this._optoption_2.CheckedChanged += new System.EventHandler(this.optoption_CheckedChanged);
			// 
			// _optoption_1
			// 
			this._optoption_1.AllowDrop = true;
			this._optoption_1.Appearance = System.Windows.Forms.Appearance.Normal;
			this._optoption_1.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._optoption_1.CausesValidation = true;
			this._optoption_1.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._optoption_1.Checked = false;
			this._optoption_1.Enabled = true;
			this._optoption_1.ForeColor = System.Drawing.SystemColors.ControlText;
			this._optoption_1.Location = new System.Drawing.Point(192, 16);
			this._optoption_1.Name = "_optoption_1";
			this._optoption_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._optoption_1.Size = new System.Drawing.Size(181, 17);
			this._optoption_1.TabIndex = 2;
			this._optoption_1.TabStop = true;
			this._optoption_1.Text = "Leave ";
			this._optoption_1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._optoption_1.Visible = true;
			this._optoption_1.CheckedChanged += new System.EventHandler(this.optoption_CheckedChanged);
			// 
			// _optoption_0
			// 
			this._optoption_0.AllowDrop = true;
			this._optoption_0.Appearance = System.Windows.Forms.Appearance.Normal;
			this._optoption_0.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._optoption_0.CausesValidation = true;
			this._optoption_0.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._optoption_0.Checked = true;
			this._optoption_0.Enabled = true;
			this._optoption_0.ForeColor = System.Drawing.SystemColors.ControlText;
			this._optoption_0.Location = new System.Drawing.Point(12, 16);
			this._optoption_0.Name = "_optoption_0";
			this._optoption_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._optoption_0.Size = new System.Drawing.Size(141, 13);
			this._optoption_0.TabIndex = 1;
			this._optoption_0.TabStop = true;
			this._optoption_0.Text = "Employee Master";
			this._optoption_0.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._optoption_0.Visible = true;
			this._optoption_0.CheckedChanged += new System.EventHandler(this.optoption_CheckedChanged);
			// 
			// tabCorrectionUtility
			// 
			this.tabCorrectionUtility.Align = C1SizerLib.AlignSettings.asNone;
			this.tabCorrectionUtility.AllowDrop = true;
			this.tabCorrectionUtility.Controls.Add(this.frmResumtion);
			this.tabCorrectionUtility.Controls.Add(this.frmLeave);
			this.tabCorrectionUtility.Controls.Add(this.frmEmployee);
			this.tabCorrectionUtility.Location = new System.Drawing.Point(4, 160);
			this.tabCorrectionUtility.Name = "tabCorrectionUtility";
			//
			this.tabCorrectionUtility.Size = new System.Drawing.Size(737, 203);
			this.tabCorrectionUtility.TabIndex = 5;
			// 
			// frmResumtion
			// 
			this.frmResumtion.AllowDrop = true;
			this.frmResumtion.BackColor = System.Drawing.Color.White;
			this.frmResumtion.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.frmResumtion.Controls.Add(this._lblCommonLabel_0);
			this.frmResumtion.Controls.Add(this.txtResumtionTransNo);
			this.frmResumtion.Controls.Add(this.txtGrantDays);
			this.frmResumtion.Controls.Add(this.Label2);
			this.frmResumtion.Controls.Add(this.Label1_1);
			this.frmResumtion.Controls.Add(this.txtDisplayVariationDays);
			this.frmResumtion.Controls.Add(this.txtEncashmentDays);
			this.frmResumtion.Controls.Add(this.txtAdjustUnpaidDays);
			this.frmResumtion.Controls.Add(this.txtAdjustPaidDays);
			this.frmResumtion.Controls.Add(this._lblCommonLabel_15);
			this.frmResumtion.Controls.Add(this._lblCommonLabel_16);
			this.frmResumtion.Controls.Add(this._lblCommonLabel_24);
			this.frmResumtion.Controls.Add(this.txtActualResumeDate);
			this.frmResumtion.Controls.Add(this._lblCommonLabel_11);
			this.frmResumtion.Enabled = true;
			this.frmResumtion.ForeColor = System.Drawing.SystemColors.ControlText;
			this.frmResumtion.Location = new System.Drawing.Point(798, 23);
			this.frmResumtion.Name = "frmResumtion";
			this.frmResumtion.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.frmResumtion.Size = new System.Drawing.Size(735, 179);
			this.frmResumtion.TabIndex = 16;
			this.frmResumtion.Visible = true;
			// 
			// _lblCommonLabel_0
			// 
			this._lblCommonLabel_0.AllowDrop = true;
			this._lblCommonLabel_0.BackColor = System.Drawing.Color.White;
			this._lblCommonLabel_0.Text = "Transaction No.";
			this._lblCommonLabel_0.Location = new System.Drawing.Point(8, 18);
			// // this._lblCommonLabel_0.mLabelId = 1744;
			this._lblCommonLabel_0.Name = "_lblCommonLabel_0";
			this._lblCommonLabel_0.Size = new System.Drawing.Size(76, 14);
			this._lblCommonLabel_0.TabIndex = 20;
			// 
			// txtResumtionTransNo
			// 
			this.txtResumtionTransNo.AllowDrop = true;
			this.txtResumtionTransNo.BackColor = System.Drawing.Color.White;
			// this.txtResumtionTransNo.bolNumericOnly = true;
			this.txtResumtionTransNo.ForeColor = System.Drawing.Color.Black;
			this.txtResumtionTransNo.Location = new System.Drawing.Point(115, 16);
			// this.txtResumtionTransNo.mDropDownType = System.Windows.Forms.TextBox.DropDownTypes.ddtNextNumber;
			this.txtResumtionTransNo.Name = "txtResumtionTransNo";
			// this.txtResumtionTransNo.ShowButton = true;
			this.txtResumtionTransNo.Size = new System.Drawing.Size(97, 19);
			this.txtResumtionTransNo.TabIndex = 9;
			this.txtResumtionTransNo.Text = "";
			// this.this.txtResumtionTransNo.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtResumtionTransNo_DropButtonClick);
			// this.txtResumtionTransNo.Leave += new System.EventHandler(this.txtResumtionTransNo_Leave);
			// 
			// txtGrantDays
			// 
			this.txtGrantDays.AllowDrop = true;
			// this.txtGrantDays.DisplayFormat = "####0.000###;;0.000;0.000";
			this.txtGrantDays.ForeColor = System.Drawing.SystemColors.WindowText;
			// this.txtGrantDays.Format = "###########0.000";
			this.txtGrantDays.Location = new System.Drawing.Point(307, 85);
			this.txtGrantDays.Name = "txtGrantDays";
			this.txtGrantDays.Size = new System.Drawing.Size(97, 19);
			this.txtGrantDays.TabIndex = 14;
			this.txtGrantDays.Text = "0.000";
			// 
			// System.Windows.Forms.Label2
			// 
			this.Label2.AllowDrop = true;
			this.Label2.BackColor = System.Drawing.Color.White;
			this.Label2.Text = "Encashment Days";
			this.Label2.Location = new System.Drawing.Point(8, 90);
			// this.Label2.mLabelId = 2145;
			this.Label2.Name = "System.Windows.Forms.Label2";
			this.Label2.Size = new System.Drawing.Size(87, 14);
			this.Label2.TabIndex = 21;
			// 
			// Label1_1
			// 
			this.Label1_1.AllowDrop = true;
			this.Label1_1.BackColor = System.Drawing.Color.White;
			this.Label1_1.Text = "Variation Days";
			this.Label1_1.Location = new System.Drawing.Point(220, 46);
			this.Label1_1.Name = "Label1_1";
			this.Label1_1.Size = new System.Drawing.Size(71, 14);
			this.Label1_1.TabIndex = 22;
			// 
			// txtDisplayVariationDays
			// 
			// this.txtDisplayVariationDays.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtDisplayVariationDays.AllowDrop = true;
			this.txtDisplayVariationDays.BackColor = System.Drawing.SystemColors.Window;
			this.txtDisplayVariationDays.Enabled = false;
			this.txtDisplayVariationDays.Location = new System.Drawing.Point(307, 44);
			this.txtDisplayVariationDays.Name = "txtDisplayVariationDays";
			this.txtDisplayVariationDays.Size = new System.Drawing.Size(97, 19);
			this.txtDisplayVariationDays.TabIndex = 23;
			this.txtDisplayVariationDays.TabStop = false;
			this.txtDisplayVariationDays.Text = "0";
			// 
			// txtEncashmentDays
			// 
			this.txtEncashmentDays.AllowDrop = true;
			// this.txtEncashmentDays.DisplayFormat = "####0.000###;;0.000;0.000";
			this.txtEncashmentDays.ForeColor = System.Drawing.SystemColors.WindowText;
			// this.txtEncashmentDays.Format = "###########0.000";
			this.txtEncashmentDays.Location = new System.Drawing.Point(115, 88);
			this.txtEncashmentDays.Name = "txtEncashmentDays";
			this.txtEncashmentDays.Size = new System.Drawing.Size(97, 19);
			this.txtEncashmentDays.TabIndex = 13;
			this.txtEncashmentDays.Text = "0.000";
			// 
			// txtAdjustUnpaidDays
			// 
			this.txtAdjustUnpaidDays.AllowDrop = true;
			// this.txtAdjustUnpaidDays.DisplayFormat = "####0.000###;;0.000;0.000";
			this.txtAdjustUnpaidDays.ForeColor = System.Drawing.SystemColors.WindowText;
			// this.txtAdjustUnpaidDays.Format = "###########0.000";
			this.txtAdjustUnpaidDays.Location = new System.Drawing.Point(307, 65);
			this.txtAdjustUnpaidDays.Name = "txtAdjustUnpaidDays";
			this.txtAdjustUnpaidDays.Size = new System.Drawing.Size(97, 19);
			this.txtAdjustUnpaidDays.TabIndex = 12;
			this.txtAdjustUnpaidDays.Text = "0.000";
			// 
			// txtAdjustPaidDays
			// 
			this.txtAdjustPaidDays.AllowDrop = true;
			// this.txtAdjustPaidDays.DisplayFormat = "####0.000###;;0.000;0.000";
			this.txtAdjustPaidDays.ForeColor = System.Drawing.SystemColors.WindowText;
			// this.txtAdjustPaidDays.Format = "###########0.000";
			this.txtAdjustPaidDays.Location = new System.Drawing.Point(115, 65);
			this.txtAdjustPaidDays.Name = "txtAdjustPaidDays";
			this.txtAdjustPaidDays.Size = new System.Drawing.Size(97, 19);
			this.txtAdjustPaidDays.TabIndex = 11;
			this.txtAdjustPaidDays.Text = "0.000";
			// 
			// _lblCommonLabel_15
			// 
			this._lblCommonLabel_15.AllowDrop = true;
			this._lblCommonLabel_15.BackColor = System.Drawing.Color.White;
			this._lblCommonLabel_15.Text = "Paid Days";
			this._lblCommonLabel_15.Location = new System.Drawing.Point(8, 67);
			// // this._lblCommonLabel_15.mLabelId = 1925;
			this._lblCommonLabel_15.Name = "_lblCommonLabel_15";
			this._lblCommonLabel_15.Size = new System.Drawing.Size(48, 14);
			this._lblCommonLabel_15.TabIndex = 24;
			// 
			// _lblCommonLabel_16
			// 
			this._lblCommonLabel_16.AllowDrop = true;
			this._lblCommonLabel_16.BackColor = System.Drawing.Color.White;
			this._lblCommonLabel_16.Text = "Unpaid Days";
			this._lblCommonLabel_16.Location = new System.Drawing.Point(220, 67);
			// // this._lblCommonLabel_16.mLabelId = 1922;
			this._lblCommonLabel_16.Name = "_lblCommonLabel_16";
			this._lblCommonLabel_16.Size = new System.Drawing.Size(61, 14);
			this._lblCommonLabel_16.TabIndex = 25;
			// 
			// _lblCommonLabel_24
			// 
			this._lblCommonLabel_24.AllowDrop = true;
			this._lblCommonLabel_24.BackColor = System.Drawing.Color.White;
			this._lblCommonLabel_24.Text = "Grant Days";
			this._lblCommonLabel_24.Location = new System.Drawing.Point(220, 88);
			this._lblCommonLabel_24.Name = "_lblCommonLabel_24";
			this._lblCommonLabel_24.Size = new System.Drawing.Size(55, 14);
			this._lblCommonLabel_24.TabIndex = 26;
			// 
			// txtActualResumeDate
			// 
			this.txtActualResumeDate.AllowDrop = true;
			this.txtActualResumeDate.BackColor = System.Drawing.Color.White;
			// this.txtActualResumeDate.CheckDateRange = false;
			this.txtActualResumeDate.Location = new System.Drawing.Point(115, 44);
			// this.txtActualResumeDate.MaxDate = 2958465;
			// this.txtActualResumeDate.MinDate = 32874;
			this.txtActualResumeDate.Name = "txtActualResumeDate";
			this.txtActualResumeDate.Size = new System.Drawing.Size(97, 19);
			this.txtActualResumeDate.TabIndex = 10;
			// this.txtActualResumeDate.Text = "18/07/2001";
			// this.txtActualResumeDate.Value = 37090;
			// this.this.txtActualResumeDate.Change += new Syncfusion.WinForms.Input.SfDateTimeEdit.ChangeHandler(this.txtActualResumeDate_Change);
			// 
			// _lblCommonLabel_11
			// 
			this._lblCommonLabel_11.AllowDrop = true;
			this._lblCommonLabel_11.BackColor = System.Drawing.Color.White;
			this._lblCommonLabel_11.Text = "Actual Resume Date";
			this._lblCommonLabel_11.Location = new System.Drawing.Point(8, 44);
			// // this._lblCommonLabel_11.mLabelId = 1134;
			this._lblCommonLabel_11.Name = "_lblCommonLabel_11";
			this._lblCommonLabel_11.Size = new System.Drawing.Size(98, 14);
			this._lblCommonLabel_11.TabIndex = 27;
			// 
			// frmLeave
			// 
			this.frmLeave.AllowDrop = true;
			this.frmLeave.BackColor = System.Drawing.Color.White;
			this.frmLeave.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.frmLeave.Controls.Add(this.txtLeaveTransNo);
			this.frmLeave.Controls.Add(this._lblCommonLabel_5);
			this.frmLeave.Enabled = true;
			this.frmLeave.ForeColor = System.Drawing.SystemColors.ControlText;
			this.frmLeave.Location = new System.Drawing.Point(778, 23);
			this.frmLeave.Name = "frmLeave";
			this.frmLeave.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.frmLeave.Size = new System.Drawing.Size(735, 179);
			this.frmLeave.TabIndex = 15;
			this.frmLeave.Visible = true;
			// 
			// txtLeaveTransNo
			// 
			this.txtLeaveTransNo.AllowDrop = true;
			this.txtLeaveTransNo.BackColor = System.Drawing.Color.White;
			// this.txtLeaveTransNo.bolNumericOnly = true;
			this.txtLeaveTransNo.ForeColor = System.Drawing.Color.Black;
			this.txtLeaveTransNo.Location = new System.Drawing.Point(110, 24);
			// this.txtLeaveTransNo.mDropDownType = System.Windows.Forms.TextBox.DropDownTypes.ddtNextNumber;
			this.txtLeaveTransNo.Name = "txtLeaveTransNo";
			// this.txtLeaveTransNo.ShowButton = true;
			this.txtLeaveTransNo.Size = new System.Drawing.Size(102, 19);
			this.txtLeaveTransNo.TabIndex = 8;
			this.txtLeaveTransNo.Text = "";
			// this.this.txtLeaveTransNo.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtLeaveTransNo_DropButtonClick);
			// this.txtLeaveTransNo.Leave += new System.EventHandler(this.txtLeaveTransNo_Leave);
			// 
			// _lblCommonLabel_5
			// 
			this._lblCommonLabel_5.AllowDrop = true;
			this._lblCommonLabel_5.BackColor = System.Drawing.Color.White;
			this._lblCommonLabel_5.Text = "Transaction No.";
			this._lblCommonLabel_5.Location = new System.Drawing.Point(16, 27);
			// // this._lblCommonLabel_5.mLabelId = 1744;
			this._lblCommonLabel_5.Name = "_lblCommonLabel_5";
			this._lblCommonLabel_5.Size = new System.Drawing.Size(76, 14);
			this._lblCommonLabel_5.TabIndex = 29;
			// 
			// frmEmployee
			// 
			this.frmEmployee.AllowDrop = true;
			this.frmEmployee.BackColor = System.Drawing.Color.White;
			this.frmEmployee.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.frmEmployee.Controls.Add(this.txtDeductionHrs);
			this.frmEmployee.Controls.Add(this._lblCommonLabel_1);
			this.frmEmployee.Controls.Add(this._lblCommon_109);
			this.frmEmployee.Controls.Add(this.txtJoiningDate);
			this.frmEmployee.Enabled = true;
			this.frmEmployee.ForeColor = System.Drawing.SystemColors.ControlText;
			this.frmEmployee.Location = new System.Drawing.Point(1, 23);
			this.frmEmployee.Name = "frmEmployee";
			this.frmEmployee.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.frmEmployee.Size = new System.Drawing.Size(735, 179);
			this.frmEmployee.TabIndex = 4;
			this.frmEmployee.Visible = true;
			// 
			// txtDeductionHrs
			// 
			this.txtDeductionHrs.AllowDrop = true;
			this.txtDeductionHrs.BackColor = System.Drawing.Color.White;
			// this.txtDeductionHrs.DisplayFormat = "####0.000###;;0.000;0.000";
			this.txtDeductionHrs.ForeColor = System.Drawing.SystemColors.WindowText;
			// this.txtDeductionHrs.Format = "###########0.000";
			this.txtDeductionHrs.Location = new System.Drawing.Point(120, 28);
			this.txtDeductionHrs.Name = "txtDeductionHrs";
			this.txtDeductionHrs.Size = new System.Drawing.Size(102, 21);
			this.txtDeductionHrs.TabIndex = 6;
			this.txtDeductionHrs.Text = "0.000";
			// 
			// _lblCommonLabel_1
			// 
			this._lblCommonLabel_1.AllowDrop = true;
			this._lblCommonLabel_1.BackColor = System.Drawing.Color.White;
			this._lblCommonLabel_1.Text = "Deduction Hours";
			this._lblCommonLabel_1.Location = new System.Drawing.Point(12, 31);
			this._lblCommonLabel_1.Name = "_lblCommonLabel_1";
			this._lblCommonLabel_1.Size = new System.Drawing.Size(80, 14);
			this._lblCommonLabel_1.TabIndex = 30;
			// 
			// _lblCommon_109
			// 
			this._lblCommon_109.AllowDrop = true;
			this._lblCommon_109.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._lblCommon_109.Text = "Joining Date";
			this._lblCommon_109.Location = new System.Drawing.Point(34, 54);
			// // this._lblCommon_109.mLabelId = 1057;
			this._lblCommon_109.Name = "_lblCommon_109";
			this._lblCommon_109.Size = new System.Drawing.Size(58, 14);
			this._lblCommon_109.TabIndex = 31;
			// 
			// txtJoiningDate
			// 
			this.txtJoiningDate.AllowDrop = true;
			// this.txtJoiningDate.CheckDateRange = false;
			this.txtJoiningDate.Location = new System.Drawing.Point(120, 52);
			// this.txtJoiningDate.MaxDate = 2958465;
			// this.txtJoiningDate.MinDate = 2;
			this.txtJoiningDate.Name = "txtJoiningDate";
			this.txtJoiningDate.Size = new System.Drawing.Size(102, 19);
			this.txtJoiningDate.TabIndex = 7;
			// this.txtJoiningDate.Text = "18/07/2001";
			// this.txtJoiningDate.Value = 37090;
			// 
			// _lblCommon_113
			// 
			this._lblCommon_113.AllowDrop = true;
			this._lblCommon_113.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_113.Text = "Employee Code";
			this._lblCommon_113.Location = new System.Drawing.Point(8, 74);
			// // this._lblCommon_113.mLabelId = 236;
			this._lblCommon_113.Name = "_lblCommon_113";
			this._lblCommon_113.Size = new System.Drawing.Size(74, 14);
			this._lblCommon_113.TabIndex = 17;
			// 
			// txtEmployeeNo
			// 
			this.txtEmployeeNo.AllowDrop = true;
			this.txtEmployeeNo.BackColor = System.Drawing.Color.White;
			this.txtEmployeeNo.ForeColor = System.Drawing.Color.Black;
			this.txtEmployeeNo.Location = new System.Drawing.Point(92, 72);
			this.txtEmployeeNo.MaxLength = 20;
			// this.txtEmployeeNo.mDropDownType = System.Windows.Forms.TextBox.DropDownTypes.ddtNextNumber;
			this.txtEmployeeNo.Name = "txtEmployeeNo";
			// this.txtEmployeeNo.ShowButton = true;
			this.txtEmployeeNo.Size = new System.Drawing.Size(102, 19);
			this.txtEmployeeNo.TabIndex = 0;
			this.txtEmployeeNo.Text = "";
			// this.this.txtEmployeeNo.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtEmployeeNo_DropButtonClick);
			// this.txtEmployeeNo.Leave += new System.EventHandler(this.txtEmployeeNo_Leave);
			// 
			// _txtDisplayLabel_1
			// 
			this._txtDisplayLabel_1.AllowDrop = true;
			this._txtDisplayLabel_1.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			this._txtDisplayLabel_1.Location = new System.Drawing.Point(196, 72);
			this._txtDisplayLabel_1.Name = "_txtDisplayLabel_1";
			this._txtDisplayLabel_1.Size = new System.Drawing.Size(247, 19);
			this._txtDisplayLabel_1.TabIndex = 28;
			// 
			// Line1
			// 
			this.Line1.AllowDrop = true;
			this.Line1.BackColor = System.Drawing.SystemColors.WindowText;
			this.Line1.Enabled = false;
			this.Line1.Location = new System.Drawing.Point(4, 152);
			this.Line1.Name = "Line1";
			this.Line1.Size = new System.Drawing.Size(740, 1);
			this.Line1.Visible = true;
			// 
			// frmPayCorrectionUtility
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.ClientSize = new System.Drawing.Size(745, 371);
			this.Controls.Add(this.Label1_0);
			this.Controls.Add(this.frmoption);
			this.Controls.Add(this.tabCorrectionUtility);
			this.Controls.Add(this._lblCommon_113);
			this.Controls.Add(this.txtEmployeeNo);
			this.Controls.Add(this._txtDisplayLabel_1);
			this.Controls.Add(this.Line1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			//this.Icon = (System.Drawing.Icon) resources.GetObject("frmPayCorrectionUtility.Icon");
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(136, 105);
			this.MaximizeBox = true;
			this.MinimizeBox = true;
			this.Name = "frmPayCorrectionUtility";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Payroll Correction Utility";
			// this.Activated += new System.EventHandler(this.frmPayCorrectionUtility_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
			// this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
			//((System.ComponentModel.ISupportInitialize) this.tabCorrectionUtility).EndInit();
			this.frmoption.ResumeLayout(false);
			this.tabCorrectionUtility.ResumeLayout(false);
			this.frmResumtion.ResumeLayout(false);
			this.frmLeave.ResumeLayout(false);
			this.frmEmployee.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		// 
		void InitializetxtDisplayLabel()
		{
			this.txtDisplayLabel = new System.Windows.Forms.Label[2];
			this.txtDisplayLabel[1] = _txtDisplayLabel_1;
		}
		void Initializeoptoption()
		{
			this.optoption = new System.Windows.Forms.RadioButton[3];
			this.optoption[2] = _optoption_2;
			this.optoption[1] = _optoption_1;
			this.optoption[0] = _optoption_0;
		}
		void InitializelblCommonLabel()
		{
			this.lblCommonLabel = new System.Windows.Forms.Label[25];
			this.lblCommonLabel[0] = _lblCommonLabel_0;
			this.lblCommonLabel[15] = _lblCommonLabel_15;
			this.lblCommonLabel[16] = _lblCommonLabel_16;
			this.lblCommonLabel[24] = _lblCommonLabel_24;
			this.lblCommonLabel[11] = _lblCommonLabel_11;
			this.lblCommonLabel[5] = _lblCommonLabel_5;
			this.lblCommonLabel[1] = _lblCommonLabel_1;
		}
		void InitializelblCommon()
		{
			this.lblCommon = new System.Windows.Forms.Label[114];
			this.lblCommon[109] = _lblCommon_109;
			this.lblCommon[113] = _lblCommon_113;
		}
		void InitializeSystem.Windows.Forms.Label1()
		{
			this.Label1 = new System.Windows.Forms.Label[2];
			this.Label1[0] = Label1_0;
			this.Label1[1] = Label1_1;
		}
		#endregion
	}
}//ENDSHERE
