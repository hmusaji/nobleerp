
namespace Xtreme
{
	partial class frmPayLeaveTransaction
	{

		#region "Upgrade Support "
		private static frmPayLeaveTransaction m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmPayLeaveTransaction DefInstance
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
		public static frmPayLeaveTransaction CreateInstance()
		{
			frmPayLeaveTransaction theInstance = new frmPayLeaveTransaction();
			
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
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "cmdSubmmitApproval", "txtDlblAppTemplateName", "txtApprovalTemplate", "_lblCommonLabel_28", "TabControlPage3", "_OptCashOrBooked_0", "_OptCashOrBooked_1", "_txtCommonNumber_5", "_txtDisplayLabel_11", "System.Windows.Forms.Label2", "System.Windows.Forms.Label1", "_lblCommonLabel_24", "_txtCommonDate_5", "_txtCommonTextBox_4", "_lblCommonLabel_25", "Label3_0", "_txtCommonTextBox_6", "_lblCommonLabel_26", "_txtCommonNumber_6", "Label3_1", "_txtCommonNumber_7", "Shape1", "TabControlPage2", "_txtDisplayLabel_14", "_lblCommonLabel_23", "_txtCommonDate_4", "_lblCommonLabel_22", "_txtCommonDate_3", "_lblCommonLabel_15", "_lblCommonLabel_3", "_txtDisplayLabel_4", "frmLeaveInformation", "cmdLeaveAmount", "_txtCommonTextBox_5", "_txtDisplayLabel_13", "_lblCommonLabel_13", "_txtCommonNumber_1", "_lblCommonLabel_4", "_lblCommonLabel_14", "_lblCommonLabel_16", "_lblCommonLabel_17", "System.Windows.Forms.Label12", "_txtCommonTextBox_3", "_lblCommonLabel_18", "_lblCommonLabel_19", "_txtCommonDate_2", "_lblCommonLabel_20", "_txtCommonNumber_3", "_lblCommonLabel_21", "_CmbCommon_0", "_txtDisplayLabel_6", "_txtDisplayLabel_7", "_txtDisplayLabel_8", "_txtCommonNumber_2", "_lblCommonLabel_8", "_txtCommonNumber_4", "_lblCommonLabel_11", "_lblCommonLabel_12", "_txtDisplayLabel_10", "_txtCommonNumber_0", "_lblCommonLabel_10", "_txtCommonDate_1", "_lblCommonLabel_27", "_txtDisplayLabel_12", "TabControlPage1", "tbleave", "chkLoanGenrate", "_txtCommonTextBox_2", "_lblCommonLabel_7", "_lblCommonLabel_5", "_lblCommonLabel_6", "_txtCommonDate_0", "_txtCommonTextBox_0", "_lblCommonLabel_2", "_lblCommonLabel_0", "_lblCommonLabel_1", "_txtCommonTextBox_1", "_lblCommonLabel_9", "_txtDisplayLabel_9", "_txtDisplayLabel_5", "_txtDisplayLabel_3", "_txtDisplayLabel_2", "_txtDisplayLabel_1", "_txtDisplayLabel_0", "txtJoiningDate", "_lblCommonLabel_29", "_lblCommonLabel_30", "CmbCommon", "OptCashOrBooked", "System.Windows.Forms.Label3", "lblCommonLabel", "txtCommonDate", "txtCommonNumber", "txtCommonTextBox", "txtDisplayLabel"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public System.Windows.Forms.Button cmdSubmmitApproval;
		public System.Windows.Forms.Label txtDlblAppTemplateName;
		public System.Windows.Forms.TextBox txtApprovalTemplate;
		private System.Windows.Forms.Label _lblCommonLabel_28;
		public Syncfusion.Windows.Forms.Tools.TabPageAdv TabControlPage3;
		private System.Windows.Forms.RadioButton _OptCashOrBooked_0;
		private System.Windows.Forms.RadioButton _OptCashOrBooked_1;
		private System.Windows.Forms.TextBox _txtCommonNumber_5;
		private System.Windows.Forms.Label _txtDisplayLabel_11;
		public System.Windows.Forms.Label Label2;
		public System.Windows.Forms.Label Label1;
		private System.Windows.Forms.Label _lblCommonLabel_24;
		private Syncfusion.WinForms.Input.SfDateTimeEdit _txtCommonDate_5;
		private System.Windows.Forms.TextBox _txtCommonTextBox_4;
		private System.Windows.Forms.Label _lblCommonLabel_25;
		private System.Windows.Forms.Label Label3_0;
		private System.Windows.Forms.TextBox _txtCommonTextBox_6;
		private System.Windows.Forms.Label _lblCommonLabel_26;
		private System.Windows.Forms.TextBox _txtCommonNumber_6;
		private System.Windows.Forms.Label Label3_1;
		private System.Windows.Forms.TextBox _txtCommonNumber_7;
		public ShapeHelper Shape1;
		public Syncfusion.Windows.Forms.Tools.TabPageAdv TabControlPage2;
		private System.Windows.Forms.Label _txtDisplayLabel_14;
		private System.Windows.Forms.Label _lblCommonLabel_23;
		private Syncfusion.WinForms.Input.SfDateTimeEdit _txtCommonDate_4;
		private System.Windows.Forms.Label _lblCommonLabel_22;
		private Syncfusion.WinForms.Input.SfDateTimeEdit _txtCommonDate_3;
		private System.Windows.Forms.Label _lblCommonLabel_15;
		private System.Windows.Forms.Label _lblCommonLabel_3;
		private System.Windows.Forms.Label _txtDisplayLabel_4;
		public System.Windows.Forms.GroupBox frmLeaveInformation;
		public System.Windows.Forms.Button cmdLeaveAmount;
		private System.Windows.Forms.TextBox _txtCommonTextBox_5;
		private System.Windows.Forms.Label _txtDisplayLabel_13;
		private System.Windows.Forms.Label _lblCommonLabel_13;
		private System.Windows.Forms.TextBox _txtCommonNumber_1;
		private System.Windows.Forms.Label _lblCommonLabel_4;
		private System.Windows.Forms.Label _lblCommonLabel_14;
		private System.Windows.Forms.Label _lblCommonLabel_16;
		private System.Windows.Forms.Label _lblCommonLabel_17;
		public System.Windows.Forms.Label Label12;
		private System.Windows.Forms.TextBox _txtCommonTextBox_3;
		private System.Windows.Forms.Label _lblCommonLabel_18;
		private System.Windows.Forms.Label _lblCommonLabel_19;
		private Syncfusion.WinForms.Input.SfDateTimeEdit _txtCommonDate_2;
		private System.Windows.Forms.Label _lblCommonLabel_20;
		private System.Windows.Forms.TextBox _txtCommonNumber_3;
		private System.Windows.Forms.Label _lblCommonLabel_21;
		private System.Windows.Forms.ComboBox _CmbCommon_0;
		private System.Windows.Forms.Label _txtDisplayLabel_6;
		private System.Windows.Forms.Label _txtDisplayLabel_7;
		private System.Windows.Forms.Label _txtDisplayLabel_8;
		private System.Windows.Forms.TextBox _txtCommonNumber_2;
		private System.Windows.Forms.Label _lblCommonLabel_8;
		private System.Windows.Forms.TextBox _txtCommonNumber_4;
		private System.Windows.Forms.Label _lblCommonLabel_11;
		private System.Windows.Forms.Label _lblCommonLabel_12;
		private System.Windows.Forms.Label _txtDisplayLabel_10;
		private System.Windows.Forms.TextBox _txtCommonNumber_0;
		private System.Windows.Forms.Label _lblCommonLabel_10;
		private Syncfusion.WinForms.Input.SfDateTimeEdit _txtCommonDate_1;
		private System.Windows.Forms.Label _lblCommonLabel_27;
		private System.Windows.Forms.Label _txtDisplayLabel_12;
		public Syncfusion.Windows.Forms.Tools.TabPageAdv TabControlPage1;
		public Syncfusion.Windows.Forms.Tools.TabControlAdv tbleave;
		public System.Windows.Forms.CheckBox chkLoanGenrate;
		private System.Windows.Forms.TextBox _txtCommonTextBox_2;
		private System.Windows.Forms.Label _lblCommonLabel_7;
		private System.Windows.Forms.Label _lblCommonLabel_5;
		private System.Windows.Forms.Label _lblCommonLabel_6;
		private Syncfusion.WinForms.Input.SfDateTimeEdit _txtCommonDate_0;
		private System.Windows.Forms.TextBox _txtCommonTextBox_0;
		private System.Windows.Forms.Label _lblCommonLabel_2;
		private System.Windows.Forms.Label _lblCommonLabel_0;
		private System.Windows.Forms.Label _lblCommonLabel_1;
		private System.Windows.Forms.TextBox _txtCommonTextBox_1;
		private System.Windows.Forms.Label _lblCommonLabel_9;
		private System.Windows.Forms.Label _txtDisplayLabel_9;
		private System.Windows.Forms.Label _txtDisplayLabel_5;
		private System.Windows.Forms.Label _txtDisplayLabel_3;
		private System.Windows.Forms.Label _txtDisplayLabel_2;
		private System.Windows.Forms.Label _txtDisplayLabel_1;
		private System.Windows.Forms.Label _txtDisplayLabel_0;
		public Syncfusion.WinForms.Input.SfDateTimeEdit txtJoiningDate;
		private System.Windows.Forms.Label _lblCommonLabel_29;
		private System.Windows.Forms.Label _lblCommonLabel_30;
		public System.Windows.Forms.ComboBox[] CmbCommon = new System.Windows.Forms.ComboBox[1];
		public System.Windows.Forms.RadioButton[] OptCashOrBooked = new System.Windows.Forms.RadioButton[2];
		public System.Windows.Forms.Label[] Label3 = new System.Windows.Forms.Label[2];
		public System.Windows.Forms.Label[] lblCommonLabel = new System.Windows.Forms.Label[31];
		public Syncfusion.WinForms.Input.SfDateTimeEdit[] txtCommonDate = new Syncfusion.WinForms.Input.SfDateTimeEdit[6];
		public System.Windows.Forms.TextBox[] txtCommonNumber = new System.Windows.Forms.TextBox[8];
		public System.Windows.Forms.TextBox[] txtCommonTextBox = new System.Windows.Forms.TextBox[7];
		public System.Windows.Forms.Label[] txtDisplayLabel = new System.Windows.Forms.Label[15];
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPayLeaveTransaction));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this.tbleave = new Syncfusion.Windows.Forms.Tools.TabControlAdv();
			this.TabControlPage3 = new Syncfusion.Windows.Forms.Tools.TabPageAdv();
			this.cmdSubmmitApproval = new System.Windows.Forms.Button();
			this.txtDlblAppTemplateName = new System.Windows.Forms.Label();
			this.txtApprovalTemplate = new System.Windows.Forms.TextBox();
			this._lblCommonLabel_28 = new System.Windows.Forms.Label();
			this.TabControlPage2 = new Syncfusion.Windows.Forms.Tools.TabPageAdv();
			this._OptCashOrBooked_0 = new System.Windows.Forms.RadioButton();
			this._OptCashOrBooked_1 = new System.Windows.Forms.RadioButton();
			this._txtCommonNumber_5 = new System.Windows.Forms.TextBox();
			this._txtDisplayLabel_11 = new System.Windows.Forms.Label();
			this.Label2 = new System.Windows.Forms.Label();
			this.Label1 = new System.Windows.Forms.Label();
			this._lblCommonLabel_24 = new System.Windows.Forms.Label();
			this._txtCommonDate_5 = new Syncfusion.WinForms.Input.SfDateTimeEdit();
			this._txtCommonTextBox_4 = new System.Windows.Forms.TextBox();
			this._lblCommonLabel_25 = new System.Windows.Forms.Label();
			this.Label3_0 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_6 = new System.Windows.Forms.TextBox();
			this._lblCommonLabel_26 = new System.Windows.Forms.Label();
			this._txtCommonNumber_6 = new System.Windows.Forms.TextBox();
			this.Label3_1 = new System.Windows.Forms.Label();
			this._txtCommonNumber_7 = new System.Windows.Forms.TextBox();
			this.Shape1 = new ShapeHelper();
			this.TabControlPage1 = new Syncfusion.Windows.Forms.Tools.TabPageAdv();
			this.frmLeaveInformation = new System.Windows.Forms.GroupBox();
			this._txtDisplayLabel_14 = new System.Windows.Forms.Label();
			this._lblCommonLabel_23 = new System.Windows.Forms.Label();
			this._txtCommonDate_4 = new Syncfusion.WinForms.Input.SfDateTimeEdit();
			this._lblCommonLabel_22 = new System.Windows.Forms.Label();
			this._txtCommonDate_3 = new Syncfusion.WinForms.Input.SfDateTimeEdit();
			this._lblCommonLabel_15 = new System.Windows.Forms.Label();
			this._lblCommonLabel_3 = new System.Windows.Forms.Label();
			this._txtDisplayLabel_4 = new System.Windows.Forms.Label();
			this.cmdLeaveAmount = new System.Windows.Forms.Button();
			this._txtCommonTextBox_5 = new System.Windows.Forms.TextBox();
			this._txtDisplayLabel_13 = new System.Windows.Forms.Label();
			this._lblCommonLabel_13 = new System.Windows.Forms.Label();
			this._txtCommonNumber_1 = new System.Windows.Forms.TextBox();
			this._lblCommonLabel_4 = new System.Windows.Forms.Label();
			this._lblCommonLabel_14 = new System.Windows.Forms.Label();
			this._lblCommonLabel_16 = new System.Windows.Forms.Label();
			this._lblCommonLabel_17 = new System.Windows.Forms.Label();
			this.Label12 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_3 = new System.Windows.Forms.TextBox();
			this._lblCommonLabel_18 = new System.Windows.Forms.Label();
			this._lblCommonLabel_19 = new System.Windows.Forms.Label();
			this._txtCommonDate_2 = new Syncfusion.WinForms.Input.SfDateTimeEdit();
			this._lblCommonLabel_20 = new System.Windows.Forms.Label();
			this._txtCommonNumber_3 = new System.Windows.Forms.TextBox();
			this._lblCommonLabel_21 = new System.Windows.Forms.Label();
			this._CmbCommon_0 = new System.Windows.Forms.ComboBox();
			this._txtDisplayLabel_6 = new System.Windows.Forms.Label();
			this._txtDisplayLabel_7 = new System.Windows.Forms.Label();
			this._txtDisplayLabel_8 = new System.Windows.Forms.Label();
			this._txtCommonNumber_2 = new System.Windows.Forms.TextBox();
			this._lblCommonLabel_8 = new System.Windows.Forms.Label();
			this._txtCommonNumber_4 = new System.Windows.Forms.TextBox();
			this._lblCommonLabel_11 = new System.Windows.Forms.Label();
			this._lblCommonLabel_12 = new System.Windows.Forms.Label();
			this._txtDisplayLabel_10 = new System.Windows.Forms.Label();
			this._txtCommonNumber_0 = new System.Windows.Forms.TextBox();
			this._lblCommonLabel_10 = new System.Windows.Forms.Label();
			this._txtCommonDate_1 = new Syncfusion.WinForms.Input.SfDateTimeEdit();
			this._lblCommonLabel_27 = new System.Windows.Forms.Label();
			this._txtDisplayLabel_12 = new System.Windows.Forms.Label();
			this.chkLoanGenrate = new System.Windows.Forms.CheckBox();
			this._txtCommonTextBox_2 = new System.Windows.Forms.TextBox();
			this._lblCommonLabel_7 = new System.Windows.Forms.Label();
			this._lblCommonLabel_5 = new System.Windows.Forms.Label();
			this._lblCommonLabel_6 = new System.Windows.Forms.Label();
			this._txtCommonDate_0 = new Syncfusion.WinForms.Input.SfDateTimeEdit();
			this._txtCommonTextBox_0 = new System.Windows.Forms.TextBox();
			this._lblCommonLabel_2 = new System.Windows.Forms.Label();
			this._lblCommonLabel_0 = new System.Windows.Forms.Label();
			this._lblCommonLabel_1 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_1 = new System.Windows.Forms.TextBox();
			this._lblCommonLabel_9 = new System.Windows.Forms.Label();
			this._txtDisplayLabel_9 = new System.Windows.Forms.Label();
			this._txtDisplayLabel_5 = new System.Windows.Forms.Label();
			this._txtDisplayLabel_3 = new System.Windows.Forms.Label();
			this._txtDisplayLabel_2 = new System.Windows.Forms.Label();
			this._txtDisplayLabel_1 = new System.Windows.Forms.Label();
			this._txtDisplayLabel_0 = new System.Windows.Forms.Label();
			this.txtJoiningDate = new Syncfusion.WinForms.Input.SfDateTimeEdit();
			this._lblCommonLabel_29 = new System.Windows.Forms.Label();
			this._lblCommonLabel_30 = new System.Windows.Forms.Label();
			// //((System.ComponentModel.ISupportInitialize) this.TabControlPage3).BeginInit();
			// //((System.ComponentModel.ISupportInitialize) this.TabControlPage2).BeginInit();
			// //((System.ComponentModel.ISupportInitialize) this.TabControlPage1).BeginInit();
			// //((System.ComponentModel.ISupportInitialize) this.tbleave).BeginInit();
			//this.tbleave.SuspendLayout();
			//this.TabControlPage3.SuspendLayout();
			//this.TabControlPage2.SuspendLayout();
			//this.TabControlPage1.SuspendLayout();
			//this.frmLeaveInformation.SuspendLayout();
			this.SuspendLayout();
			// 
			// tbleave
			// 
			this.tbleave.AllowDrop = true;
			this.tbleave.Controls.Add(this.TabControlPage3);
			this.tbleave.Controls.Add(this.TabControlPage2);
			this.tbleave.Controls.Add(this.TabControlPage1);
			this.tbleave.Location = new System.Drawing.Point(6, 146);
			this.tbleave.Name = "tbleave";
			//
			this.tbleave.Size = new System.Drawing.Size(635, 315);
			this.tbleave.TabIndex = 21;
			this.tbleave.TabStop = false;
			// 
			// TabControlPage3
			// 
			this.TabControlPage3.AllowDrop = true;
			this.TabControlPage3.Controls.Add(this.cmdSubmmitApproval);
			this.TabControlPage3.Controls.Add(this.txtDlblAppTemplateName);
			this.TabControlPage3.Controls.Add(this.txtApprovalTemplate);
			this.TabControlPage3.Controls.Add(this._lblCommonLabel_28);
			this.TabControlPage3.Location = new System.Drawing.Point(-4664, 30);
			this.TabControlPage3.Name = "TabControlPage3";
			//
			this.TabControlPage3.Size = new System.Drawing.Size(631, 301);
			this.TabControlPage3.TabIndex = 22;
			this.TabControlPage3.Visible = false;
			// 
			// cmdSubmmitApproval
			// 
			this.cmdSubmmitApproval.AllowDrop = true;
			this.cmdSubmmitApproval.BackColor = System.Drawing.SystemColors.Control;
			this.cmdSubmmitApproval.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdSubmmitApproval.Location = new System.Drawing.Point(465, 20);
			this.cmdSubmmitApproval.Name = "cmdSubmmitApproval";
			this.cmdSubmmitApproval.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdSubmmitApproval.Size = new System.Drawing.Size(97, 28);
			this.cmdSubmmitApproval.TabIndex = 26;
			this.cmdSubmmitApproval.Text = "Submmit";
			this.cmdSubmmitApproval.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.cmdSubmmitApproval.UseVisualStyleBackColor = false;
			// this.cmdSubmmitApproval.Click += new System.EventHandler(this.cmdSubmmitApproval_Click);
			// 
			// txtDlblAppTemplateName
			// 
			this.txtDlblAppTemplateName.AllowDrop = true;
			this.txtDlblAppTemplateName.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			this.txtDlblAppTemplateName.Enabled = false;
			this.txtDlblAppTemplateName.Location = new System.Drawing.Point(225, 23);
			this.txtDlblAppTemplateName.Name = "txtDlblAppTemplateName";
			this.txtDlblAppTemplateName.Size = new System.Drawing.Size(226, 19);
			this.txtDlblAppTemplateName.TabIndex = 25;
			// 
			// txtApprovalTemplate
			// 
			this.txtApprovalTemplate.AllowDrop = true;
			this.txtApprovalTemplate.BackColor = System.Drawing.Color.White;
			// // = false;
			this.txtApprovalTemplate.ForeColor = System.Drawing.Color.Black;
			this.txtApprovalTemplate.Location = new System.Drawing.Point(117, 23);
			// // = (System.Windows.Forms.TextBox.DropDownTypes) 0;
			this.txtApprovalTemplate.Name = "txtApprovalTemplate";
			// this.txtApprovalTemplate.ShowButton = true;
			this.txtApprovalTemplate.Size = new System.Drawing.Size(106, 19);
			this.txtApprovalTemplate.TabIndex = 24;
			// this.txtApprovalTemplate.Text = "";
			// this.// = "";
			// this.//this.txtApprovalTemplate.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(//this.txtApprovalTemplate_DropButtonClick);
			// this.txtApprovalTemplate.Leave += new System.EventHandler(this.txtApprovalTemplate_Leave);
			// 
			// _lblCommonLabel_28
			// 
			this._lblCommonLabel_28.AllowDrop = true;
			this._lblCommonLabel_28.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_28.Text = "Approval Template";
			this._lblCommonLabel_28.ForeColor = System.Drawing.Color.Black;
			this._lblCommonLabel_28.Location = new System.Drawing.Point(12, 26);
			this._lblCommonLabel_28.Name = "_lblCommonLabel_28";
			this._lblCommonLabel_28.Size = new System.Drawing.Size(90, 14);
			this._lblCommonLabel_28.TabIndex = 23;
			// 
			// TabControlPage2
			// 
			this.TabControlPage2.AllowDrop = true;
			this.TabControlPage2.Controls.Add(this._OptCashOrBooked_0);
			this.TabControlPage2.Controls.Add(this._OptCashOrBooked_1);
			this.TabControlPage2.Controls.Add(this._txtCommonNumber_5);
			this.TabControlPage2.Controls.Add(this._txtDisplayLabel_11);
			this.TabControlPage2.Controls.Add(this.Label2);
			this.TabControlPage2.Controls.Add(this.Label1);
			this.TabControlPage2.Controls.Add(this._lblCommonLabel_24);
			this.TabControlPage2.Controls.Add(this._txtCommonDate_5);
			this.TabControlPage2.Controls.Add(this._txtCommonTextBox_4);
			this.TabControlPage2.Controls.Add(this._lblCommonLabel_25);
			this.TabControlPage2.Controls.Add(this.Label3_0);
			this.TabControlPage2.Controls.Add(this._txtCommonTextBox_6);
			this.TabControlPage2.Controls.Add(this._lblCommonLabel_26);
			this.TabControlPage2.Controls.Add(this._txtCommonNumber_6);
			this.TabControlPage2.Controls.Add(this.Label3_1);
			this.TabControlPage2.Controls.Add(this._txtCommonNumber_7);
			this.TabControlPage2.Controls.Add(this.Shape1);
			this.TabControlPage2.Location = new System.Drawing.Point(-4664, 30);
			this.TabControlPage2.Name = "TabControlPage2";
			//
			this.TabControlPage2.Size = new System.Drawing.Size(631, 301);
			this.TabControlPage2.TabIndex = 27;
			this.TabControlPage2.Visible = false;
			// 
			// _OptCashOrBooked_0
			// 
			this._OptCashOrBooked_0.AllowDrop = true;
			this._OptCashOrBooked_0.Appearance = System.Windows.Forms.Appearance.Normal;
			this._OptCashOrBooked_0.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._OptCashOrBooked_0.CausesValidation = true;
			this._OptCashOrBooked_0.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._OptCashOrBooked_0.Checked = true;
			this._OptCashOrBooked_0.Enabled = true;
			this._OptCashOrBooked_0.ForeColor = System.Drawing.SystemColors.ControlText;
			this._OptCashOrBooked_0.Location = new System.Drawing.Point(62, 68);
			this._OptCashOrBooked_0.Name = "_OptCashOrBooked_0";
			this._OptCashOrBooked_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._OptCashOrBooked_0.Size = new System.Drawing.Size(61, 13);
			this._OptCashOrBooked_0.TabIndex = 36;
			this._OptCashOrBooked_0.TabStop = true;
			this._OptCashOrBooked_0.Text = "Cash";
			this._OptCashOrBooked_0.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._OptCashOrBooked_0.Visible = true;
			//this._OptCashOrBooked_0.CheckedChanged += new System.EventHandler(this.OptCashOrBooked_CheckedChanged);
			// 
			// _OptCashOrBooked_1
			// 
			this._OptCashOrBooked_1.AllowDrop = true;
			this._OptCashOrBooked_1.Appearance = System.Windows.Forms.Appearance.Normal;
			this._OptCashOrBooked_1.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._OptCashOrBooked_1.CausesValidation = true;
			this._OptCashOrBooked_1.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._OptCashOrBooked_1.Checked = false;
			this._OptCashOrBooked_1.Enabled = true;
			this._OptCashOrBooked_1.ForeColor = System.Drawing.SystemColors.ControlText;
			this._OptCashOrBooked_1.Location = new System.Drawing.Point(62, 88);
			this._OptCashOrBooked_1.Name = "_OptCashOrBooked_1";
			this._OptCashOrBooked_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._OptCashOrBooked_1.Size = new System.Drawing.Size(61, 15);
			this._OptCashOrBooked_1.TabIndex = 39;
			this._OptCashOrBooked_1.TabStop = true;
			this._OptCashOrBooked_1.Text = "Booked";
			this._OptCashOrBooked_1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._OptCashOrBooked_1.Visible = true;
			//this._OptCashOrBooked_1.CheckedChanged += new System.EventHandler(this.OptCashOrBooked_CheckedChanged);
			// 
			// _txtCommonNumber_5
			// 
			this._txtCommonNumber_5.AllowDrop = true;
			this._txtCommonNumber_5.ForeColor = System.Drawing.SystemColors.WindowText;
			this._txtCommonNumber_5.Location = new System.Drawing.Point(246, 32);
			this._txtCommonNumber_5.Name = "_txtCommonNumber_5";
			this._txtCommonNumber_5.Size = new System.Drawing.Size(57, 19);
			this._txtCommonNumber_5.TabIndex = 35;
			// this.this._txtCommonNumber_5.Change += new System.Windows.Forms.TextBox.ChangeHandler(this.txtCommonNumber_Change);
			// this._txtCommonNumber_5.Enter += new System.EventHandler(this.txtCommonNumber_Enter);
			// this._txtCommonNumber_5.Leave += new System.EventHandler(this.txtCommonNumber_Leave);
			// 
			// _txtDisplayLabel_11
			// 
			this._txtDisplayLabel_11.AllowDrop = true;
			this._txtDisplayLabel_11.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			this._txtDisplayLabel_11.Enabled = false;
			this._txtDisplayLabel_11.Location = new System.Drawing.Point(246, 12);
			this._txtDisplayLabel_11.Name = "_txtDisplayLabel_11";
			this._txtDisplayLabel_11.Size = new System.Drawing.Size(57, 19);
			this._txtDisplayLabel_11.TabIndex = 31;
			this._txtDisplayLabel_11.TabStop = false;
			// 
			// System.Windows.Forms.Label2
			// 
			this.Label2.AllowDrop = true;
			this.Label2.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.Label2.Text = "Ticket Issue";
			this.Label2.ForeColor = System.Drawing.Color.Black;
			this.Label2.Location = new System.Drawing.Point(171, 34);
			// this.Label2.mLabelId = 2086;
			this.Label2.Name="Label2";
			this.Label2.Size = new System.Drawing.Size(57, 14);
			this.Label2.TabIndex = 34;
			// 
			// System.Windows.Forms.Label1
			// 
			this.Label1.AllowDrop = true;
			this.Label1.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.Label1.Text = "Ticket Balance";
			this.Label1.ForeColor = System.Drawing.Color.Black;
			this.Label1.Location = new System.Drawing.Point(171, 14);
			// this.Label1.mLabelId = 2084;
			this.Label1.Name="Label1";
			this.Label1.Size = new System.Drawing.Size(70, 14);
			this.Label1.TabIndex = 33;
			// 
			// _lblCommonLabel_24
			// 
			this._lblCommonLabel_24.AllowDrop = true;
			this._lblCommonLabel_24.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_24.Text = "Issued Upto";
			this._lblCommonLabel_24.ForeColor = System.Drawing.Color.Black;
			this._lblCommonLabel_24.Location = new System.Drawing.Point(4, 14);
			this._lblCommonLabel_24.Name = "_lblCommonLabel_24";
			this._lblCommonLabel_24.Size = new System.Drawing.Size(57, 14);
			this._lblCommonLabel_24.TabIndex = 28;
			// 
			// _txtCommonDate_5
			// 
			this._txtCommonDate_5.AllowDrop = true;
			// this._txtCommonDate_5.CheckDateRange = false;
			this._txtCommonDate_5.Location = new System.Drawing.Point(67, 12);
			// this._txtCommonDate_5.MaxDate = 2958465;
			// this._txtCommonDate_5.MinDate = -657434;
			this._txtCommonDate_5.Name = "_txtCommonDate_5";
			this._txtCommonDate_5.Size = new System.Drawing.Size(102, 19);
			this._txtCommonDate_5.TabIndex = 30;
			this._txtCommonDate_5.Text = "18-Jul-2001";
			// this._txtCommonDate_5.Value = 37090;
			//this._txtCommonDate_5.Validating += new System.ComponentModel.CancelEventHandler(this.txtCommonDate_Validating);
			// 
			// _txtCommonTextBox_4
			// 
			this._txtCommonTextBox_4.AllowDrop = true;
			this._txtCommonTextBox_4.BackColor = System.Drawing.Color.FromArgb(239, 239, 239);
			this._txtCommonTextBox_4.Enabled = false;
			this._txtCommonTextBox_4.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_4.Location = new System.Drawing.Point(437, 10);
			this._txtCommonTextBox_4.MaxLength = 20;
			this._txtCommonTextBox_4.Name = "_txtCommonTextBox_4";
			this._txtCommonTextBox_4.Size = new System.Drawing.Size(166, 19);
			this._txtCommonTextBox_4.TabIndex = 29;
			this._txtCommonTextBox_4.Text = "";
			// this.// = "";
			// this.//this._txtCommonTextBox_4.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(//this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_4.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _lblCommonLabel_25
			// 
			this._lblCommonLabel_25.AllowDrop = true;
			this._lblCommonLabel_25.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_25.Text = "Ticket Destination Entitled";
			this._lblCommonLabel_25.ForeColor = System.Drawing.Color.Black;
			this._lblCommonLabel_25.Location = new System.Drawing.Point(311, 13);
			this._lblCommonLabel_25.Name = "_lblCommonLabel_25";
			this._lblCommonLabel_25.Size = new System.Drawing.Size(124, 13);
			this._lblCommonLabel_25.TabIndex = 32;
			// 
			// Label3_0
			// 
			this.Label3_0.AllowDrop = true;
			this.Label3_0.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.Label3_0.Text = "Ticket  Amount";
			this.Label3_0.ForeColor = System.Drawing.Color.Black;
			this.Label3_0.Location = new System.Drawing.Point(168, 68);
			// this.Label3_0.mLabelId = 2087;
			this.Label3_0.Name = "Label3_0";
			this.Label3_0.Size = new System.Drawing.Size(71, 14);
			this.Label3_0.TabIndex = 37;
			// 
			// _txtCommonTextBox_6
			// 
			this._txtCommonTextBox_6.AllowDrop = true;
			this._txtCommonTextBox_6.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_6.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_6.Location = new System.Drawing.Point(434, 86);
			this._txtCommonTextBox_6.MaxLength = 20;
			this._txtCommonTextBox_6.Name = "_txtCommonTextBox_6";
			// this._txtCommonTextBox_6.ShowButton = true;
			this._txtCommonTextBox_6.Size = new System.Drawing.Size(166, 19);
			this._txtCommonTextBox_6.TabIndex = 43;
			this._txtCommonTextBox_6.Text = "";
			// this.// = "";
			// this.//this._txtCommonTextBox_6.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(//this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_6.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _lblCommonLabel_26
			// 
			this._lblCommonLabel_26.AllowDrop = true;
			this._lblCommonLabel_26.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_26.Text = "Ticket Destination Issued";
			this._lblCommonLabel_26.ForeColor = System.Drawing.Color.Black;
			this._lblCommonLabel_26.Location = new System.Drawing.Point(308, 89);
			this._lblCommonLabel_26.Name = "_lblCommonLabel_26";
			this._lblCommonLabel_26.Size = new System.Drawing.Size(120, 13);
			this._lblCommonLabel_26.TabIndex = 42;
			// 
			// _txtCommonNumber_6
			// 
			this._txtCommonNumber_6.AllowDrop = true;
			// this._txtCommonNumber_6.DisplayFormat = "####0.000###;;0.000;0.000";
			// this._txtCommonNumber_6.Format = "###########0.000";
			this._txtCommonNumber_6.Location = new System.Drawing.Point(243, 68);
			// // = 2147483647;
			// // = 0;
			this._txtCommonNumber_6.Name = "_txtCommonNumber_6";
			this._txtCommonNumber_6.Size = new System.Drawing.Size(57, 19);
			this._txtCommonNumber_6.TabIndex = 38;
			this._txtCommonNumber_6.Text = "0.000";
			// this.this._txtCommonNumber_6.Change += new System.Windows.Forms.TextBox.ChangeHandler(this.txtCommonNumber_Change);
			// this._txtCommonNumber_6.Enter += new System.EventHandler(this.txtCommonNumber_Enter);
			// this._txtCommonNumber_6.Leave += new System.EventHandler(this.txtCommonNumber_Leave);
			// 
			// Label3_1
			// 
			this.Label3_1.AllowDrop = true;
			this.Label3_1.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.Label3_1.Text = "Diff. In Amt.";
			this.Label3_1.ForeColor = System.Drawing.Color.Black;
			this.Label3_1.Location = new System.Drawing.Point(168, 88);
			this.Label3_1.Name = "Label3_1";
			this.Label3_1.Size = new System.Drawing.Size(56, 14);
			this.Label3_1.TabIndex = 40;
			// 
			// _txtCommonNumber_7
			// 
			this._txtCommonNumber_7.AllowDrop = true;
			// this._txtCommonNumber_7.DisplayFormat = "####0.000###;;0.000;0.000";
			this._txtCommonNumber_7.Enabled = false;
			// this._txtCommonNumber_7.Format = "###########0.000";
			this._txtCommonNumber_7.Location = new System.Drawing.Point(243, 86);
			// // = 2147483647;
			// // = 0;
			this._txtCommonNumber_7.Name = "_txtCommonNumber_7";
			this._txtCommonNumber_7.Size = new System.Drawing.Size(57, 19);
			this._txtCommonNumber_7.TabIndex = 41;
			this._txtCommonNumber_7.Text = "0.000";
			// this.this._txtCommonNumber_7.Change += new System.Windows.Forms.TextBox.ChangeHandler(this.txtCommonNumber_Change);
			// this._txtCommonNumber_7.Enter += new System.EventHandler(this.txtCommonNumber_Enter);
			// this._txtCommonNumber_7.Leave += new System.EventHandler(this.txtCommonNumber_Leave);
			// 
			// Shape1
			// 
			this.Shape1.AllowDrop = true;
			this.Shape1.BackColor = System.Drawing.SystemColors.Window;
			// = 0;
			//
			this.Shape1.Enabled = false;
			//this.Shape1.FillColor = System.Drawing.Color.Black;
			//this.Shape1.FillStyle = 1;
			this.Shape1.Location = new System.Drawing.Point(59, 60);
			this.Shape1.Name = "Shape1";
			this.Shape1.Size = new System.Drawing.Size(547, 53);
			this.Shape1.Visible = true;
			// 
			// TabControlPage1
			// 
			this.TabControlPage1.AllowDrop = true;
			this.TabControlPage1.Controls.Add(this.frmLeaveInformation);
			this.TabControlPage1.Controls.Add(this.cmdLeaveAmount);
			this.TabControlPage1.Controls.Add(this._txtCommonTextBox_5);
			this.TabControlPage1.Controls.Add(this._txtDisplayLabel_13);
			this.TabControlPage1.Controls.Add(this._lblCommonLabel_13);
			this.TabControlPage1.Controls.Add(this._txtCommonNumber_1);
			this.TabControlPage1.Controls.Add(this._lblCommonLabel_4);
			this.TabControlPage1.Controls.Add(this._lblCommonLabel_14);
			this.TabControlPage1.Controls.Add(this._lblCommonLabel_16);
			this.TabControlPage1.Controls.Add(this._lblCommonLabel_17);
			this.TabControlPage1.Controls.Add(this.Label12);
			this.TabControlPage1.Controls.Add(this._txtCommonTextBox_3);
			this.TabControlPage1.Controls.Add(this._lblCommonLabel_18);
			this.TabControlPage1.Controls.Add(this._lblCommonLabel_19);
			this.TabControlPage1.Controls.Add(this._txtCommonDate_2);
			this.TabControlPage1.Controls.Add(this._lblCommonLabel_20);
			this.TabControlPage1.Controls.Add(this._txtCommonNumber_3);
			this.TabControlPage1.Controls.Add(this._lblCommonLabel_21);
			this.TabControlPage1.Controls.Add(this._CmbCommon_0);
			this.TabControlPage1.Controls.Add(this._txtDisplayLabel_6);
			this.TabControlPage1.Controls.Add(this._txtDisplayLabel_7);
			this.TabControlPage1.Controls.Add(this._txtDisplayLabel_8);
			this.TabControlPage1.Controls.Add(this._txtCommonNumber_2);
			this.TabControlPage1.Controls.Add(this._lblCommonLabel_8);
			this.TabControlPage1.Controls.Add(this._txtCommonNumber_4);
			this.TabControlPage1.Controls.Add(this._lblCommonLabel_11);
			this.TabControlPage1.Controls.Add(this._lblCommonLabel_12);
			this.TabControlPage1.Controls.Add(this._txtDisplayLabel_10);
			this.TabControlPage1.Controls.Add(this._txtCommonNumber_0);
			this.TabControlPage1.Controls.Add(this._lblCommonLabel_10);
			this.TabControlPage1.Controls.Add(this._txtCommonDate_1);
			this.TabControlPage1.Controls.Add(this._lblCommonLabel_27);
			this.TabControlPage1.Controls.Add(this._txtDisplayLabel_12);
			this.TabControlPage1.Location = new System.Drawing.Point(2, 30);
			this.TabControlPage1.Name = "TabControlPage1";
			//
			this.TabControlPage1.Size = new System.Drawing.Size(631, 283);
			this.TabControlPage1.TabIndex = 44;
			// 
			// frmLeaveInformation
			// 
			this.frmLeaveInformation.AllowDrop = true;
			this.frmLeaveInformation.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.frmLeaveInformation.Controls.Add(this._txtDisplayLabel_14);
			this.frmLeaveInformation.Controls.Add(this._lblCommonLabel_23);
			this.frmLeaveInformation.Controls.Add(this._txtCommonDate_4);
			this.frmLeaveInformation.Controls.Add(this._lblCommonLabel_22);
			this.frmLeaveInformation.Controls.Add(this._txtCommonDate_3);
			this.frmLeaveInformation.Controls.Add(this._lblCommonLabel_15);
			this.frmLeaveInformation.Controls.Add(this._lblCommonLabel_3);
			this.frmLeaveInformation.Controls.Add(this._txtDisplayLabel_4);
			this.frmLeaveInformation.Enabled = true;
			this.frmLeaveInformation.ForeColor = System.Drawing.Color.Black;
			this.frmLeaveInformation.Location = new System.Drawing.Point(98, 32);
			this.frmLeaveInformation.Name = "frmLeaveInformation";
			this.frmLeaveInformation.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.frmLeaveInformation.Size = new System.Drawing.Size(389, 69);
			this.frmLeaveInformation.TabIndex = 47;
			this.frmLeaveInformation.Text = "Leave History";
			this.frmLeaveInformation.Visible = true;
			// 
			// _txtDisplayLabel_14
			// 
			this._txtDisplayLabel_14.AllowDrop = true;
			this._txtDisplayLabel_14.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			this._txtDisplayLabel_14.Enabled = false;
			this._txtDisplayLabel_14.Location = new System.Drawing.Point(94, 40);
			this._txtDisplayLabel_14.Name = "_txtDisplayLabel_14";
			this._txtDisplayLabel_14.Size = new System.Drawing.Size(101, 19);
			this._txtDisplayLabel_14.TabIndex = 55;
			// 
			// _lblCommonLabel_23
			// 
			this._lblCommonLabel_23.AllowDrop = true;
			this._lblCommonLabel_23.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_23.Text = "Total Days Taken";
			this._lblCommonLabel_23.ForeColor = System.Drawing.Color.Black;
			this._lblCommonLabel_23.Location = new System.Drawing.Point(6, 44);
			// // this._lblCommonLabel_23.mLabelId = 2121;
			this._lblCommonLabel_23.Name = "_lblCommonLabel_23";
			this._lblCommonLabel_23.Size = new System.Drawing.Size(83, 14);
			this._lblCommonLabel_23.TabIndex = 53;
			// 
			// _txtCommonDate_4
			// 
			this._txtCommonDate_4.AllowDrop = true;
			this._txtCommonDate_4.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			// this._txtCommonDate_4.CheckDateRange = false;
			this._txtCommonDate_4.Enabled = false;
			this._txtCommonDate_4.Location = new System.Drawing.Point(279, 18);
			// this._txtCommonDate_4.MaxDate = 2958465;
			// this._txtCommonDate_4.MinDate = -657434;
			this._txtCommonDate_4.Name = "_txtCommonDate_4";
			this._txtCommonDate_4.Size = new System.Drawing.Size(101, 19);
			this._txtCommonDate_4.TabIndex = 52;
			this._txtCommonDate_4.Text = "01-Dec-2009";
			// this._txtCommonDate_4.Value = 40148;
			//this._txtCommonDate_4.Validating += new System.ComponentModel.CancelEventHandler(this.txtCommonDate_Validating);
			// 
			// _lblCommonLabel_22
			// 
			this._lblCommonLabel_22.AllowDrop = true;
			this._lblCommonLabel_22.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_22.Text = "Last Leave To";
			this._lblCommonLabel_22.ForeColor = System.Drawing.Color.Black;
			this._lblCommonLabel_22.Location = new System.Drawing.Point(206, 20);
			// // this._lblCommonLabel_22.mLabelId = 2123;
			this._lblCommonLabel_22.Name = "_lblCommonLabel_22";
			this._lblCommonLabel_22.Size = new System.Drawing.Size(69, 14);
			this._lblCommonLabel_22.TabIndex = 51;
			// 
			// _txtCommonDate_3
			// 
			this._txtCommonDate_3.AllowDrop = true;
			this._txtCommonDate_3.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			// this._txtCommonDate_3.CheckDateRange = false;
			this._txtCommonDate_3.Enabled = false;
			this._txtCommonDate_3.Location = new System.Drawing.Point(94, 18);
			// this._txtCommonDate_3.MaxDate = 2958465;
			// this._txtCommonDate_3.MinDate = -657434;
			this._txtCommonDate_3.Name = "_txtCommonDate_3";
			this._txtCommonDate_3.Size = new System.Drawing.Size(101, 17);
			this._txtCommonDate_3.TabIndex = 50;
			this._txtCommonDate_3.Text = "01-Dec-2009";
			// this._txtCommonDate_3.Value = 40148;
			//this._txtCommonDate_3.Validating += new System.ComponentModel.CancelEventHandler(this.txtCommonDate_Validating);
			// 
			// _lblCommonLabel_15
			// 
			this._lblCommonLabel_15.AllowDrop = true;
			this._lblCommonLabel_15.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_15.Text = "Last Leave From";
			this._lblCommonLabel_15.ForeColor = System.Drawing.Color.Black;
			this._lblCommonLabel_15.Location = new System.Drawing.Point(6, 19);
			// // this._lblCommonLabel_15.mLabelId = 2122;
			this._lblCommonLabel_15.Name = "_lblCommonLabel_15";
			this._lblCommonLabel_15.Size = new System.Drawing.Size(81, 14);
			this._lblCommonLabel_15.TabIndex = 49;
			// 
			// _lblCommonLabel_3
			// 
			this._lblCommonLabel_3.AllowDrop = true;
			this._lblCommonLabel_3.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_3.Text = "Leave Salary";
			this._lblCommonLabel_3.ForeColor = System.Drawing.Color.Black;
			this._lblCommonLabel_3.Location = new System.Drawing.Point(206, 42);
			// // this._lblCommonLabel_3.mLabelId = 1135;
			this._lblCommonLabel_3.Name = "_lblCommonLabel_3";
			this._lblCommonLabel_3.Size = new System.Drawing.Size(64, 14);
			this._lblCommonLabel_3.TabIndex = 48;
			// 
			// _txtDisplayLabel_4
			// 
			// //this._txtDisplayLabel_4.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
			this._txtDisplayLabel_4.AllowDrop = true;
			this._txtDisplayLabel_4.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			this._txtDisplayLabel_4.Location = new System.Drawing.Point(279, 40);
			this._txtDisplayLabel_4.Name = "_txtDisplayLabel_4";
			this._txtDisplayLabel_4.Size = new System.Drawing.Size(101, 19);
			this._txtDisplayLabel_4.TabIndex = 54;
			this._txtDisplayLabel_4.TabStop = false;
			// 
			// cmdLeaveAmount
			// 
			this.cmdLeaveAmount.AllowDrop = true;
			this.cmdLeaveAmount.BackColor = System.Drawing.SystemColors.Control;
			this.cmdLeaveAmount.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdLeaveAmount.Location = new System.Drawing.Point(404, 248);
			this.cmdLeaveAmount.Name = "cmdLeaveAmount";
			this.cmdLeaveAmount.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdLeaveAmount.Size = new System.Drawing.Size(15, 21);
			this.cmdLeaveAmount.TabIndex = 79;
			this.cmdLeaveAmount.Text = "A";
			this.cmdLeaveAmount.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.cmdLeaveAmount.UseVisualStyleBackColor = false;
			this.cmdLeaveAmount.Visible = false;
			// this.cmdLeaveAmount.Click += new System.EventHandler(this.cmdLeaveAmount_Click);
			// 
			// _txtCommonTextBox_5
			// 
			this._txtCommonTextBox_5.AllowDrop = true;
			this._txtCommonTextBox_5.BackColor = System.Drawing.Color.White;
			// // = false;
			this._txtCommonTextBox_5.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_5.Location = new System.Drawing.Point(98, 234);
			// // = true;
			this._txtCommonTextBox_5.MaxLength = 200;
			// // = (System.Windows.Forms.TextBox.DropDownTypes) 0;
			this._txtCommonTextBox_5.Name = "_txtCommonTextBox_5";
			this._txtCommonTextBox_5.Size = new System.Drawing.Size(513, 19);
			this._txtCommonTextBox_5.TabIndex = 78;
			this._txtCommonTextBox_5.Text = "";
			// this.// = "";
			// this.//this._txtCommonTextBox_5.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(//this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_5.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _txtDisplayLabel_13
			// 
			this._txtDisplayLabel_13.AllowDrop = true;
			this._txtDisplayLabel_13.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			this._txtDisplayLabel_13.Enabled = false;
			this._txtDisplayLabel_13.Location = new System.Drawing.Point(506, 212);
			this._txtDisplayLabel_13.Name = "_txtDisplayLabel_13";
			this._txtDisplayLabel_13.Size = new System.Drawing.Size(105, 19);
			this._txtDisplayLabel_13.TabIndex = 76;
			// 
			// _lblCommonLabel_13
			// 
			this._lblCommonLabel_13.AllowDrop = true;
			this._lblCommonLabel_13.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_13.Text = "Total Cash Paid";
			this._lblCommonLabel_13.ForeColor = System.Drawing.Color.Black;
			this._lblCommonLabel_13.Location = new System.Drawing.Point(416, 216);
			// // this._lblCommonLabel_13.mLabelId = 1972;
			this._lblCommonLabel_13.Name = "_lblCommonLabel_13";
			this._lblCommonLabel_13.Size = new System.Drawing.Size(74, 14);
			this._lblCommonLabel_13.TabIndex = 81;
			// 
			// _txtCommonNumber_1
			// 
			this._txtCommonNumber_1.AllowDrop = true;
			// this._txtCommonNumber_1.DisplayFormat = "####0.000###;;0.000;0.000";
			// this._txtCommonNumber_1.Format = "###########0.000";
			this._txtCommonNumber_1.Location = new System.Drawing.Point(98, 174);
			// // = 2147483647;
			// // = 0;
			this._txtCommonNumber_1.Name = "_txtCommonNumber_1";
			this._txtCommonNumber_1.Size = new System.Drawing.Size(101, 19);
			this._txtCommonNumber_1.TabIndex = 70;
			this._txtCommonNumber_1.Text = "0.000";
			// this.this._txtCommonNumber_1.Change += new System.Windows.Forms.TextBox.ChangeHandler(this.txtCommonNumber_Change);
			// this._txtCommonNumber_1.Enter += new System.EventHandler(this.txtCommonNumber_Enter);
			// this._txtCommonNumber_1.Leave += new System.EventHandler(this.txtCommonNumber_Leave);
			// 
			// _lblCommonLabel_4
			// 
			this._lblCommonLabel_4.AllowDrop = true;
			this._lblCommonLabel_4.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_4.Text = "Actual Leave Days";
			this._lblCommonLabel_4.ForeColor = System.Drawing.Color.Black;
			this._lblCommonLabel_4.Location = new System.Drawing.Point(4, 176);
			// // this._lblCommonLabel_4.mLabelId = 1131;
			this._lblCommonLabel_4.Name = "_lblCommonLabel_4";
			this._lblCommonLabel_4.Size = new System.Drawing.Size(92, 14);
			this._lblCommonLabel_4.TabIndex = 60;
			// 
			// _lblCommonLabel_14
			// 
			this._lblCommonLabel_14.AllowDrop = true;
			this._lblCommonLabel_14.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_14.Text = "Pay Type";
			this._lblCommonLabel_14.ForeColor = System.Drawing.Color.Black;
			this._lblCommonLabel_14.Location = new System.Drawing.Point(4, 215);
			// // this._lblCommonLabel_14.mLabelId = 1136;
			this._lblCommonLabel_14.Name = "_lblCommonLabel_14";
			this._lblCommonLabel_14.Size = new System.Drawing.Size(45, 14);
			this._lblCommonLabel_14.TabIndex = 82;
			// 
			// _lblCommonLabel_16
			// 
			this._lblCommonLabel_16.AllowDrop = true;
			this._lblCommonLabel_16.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_16.Text = "Leave Amount";
			this._lblCommonLabel_16.ForeColor = System.Drawing.Color.Black;
			this._lblCommonLabel_16.Location = new System.Drawing.Point(416, 194);
			// // this._lblCommonLabel_16.mLabelId = 2081;
			this._lblCommonLabel_16.Name = "_lblCommonLabel_16";
			this._lblCommonLabel_16.Size = new System.Drawing.Size(70, 14);
			this._lblCommonLabel_16.TabIndex = 83;
			// 
			// _lblCommonLabel_17
			// 
			this._lblCommonLabel_17.AllowDrop = true;
			this._lblCommonLabel_17.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_17.Text = "Leave Balance";
			this._lblCommonLabel_17.ForeColor = System.Drawing.Color.Black;
			this._lblCommonLabel_17.Location = new System.Drawing.Point(416, 136);
			// // this._lblCommonLabel_17.mLabelId = 1133;
			this._lblCommonLabel_17.Name = "_lblCommonLabel_17";
			this._lblCommonLabel_17.Size = new System.Drawing.Size(72, 14);
			this._lblCommonLabel_17.TabIndex = 64;
			// 
			// System.Windows.Forms.Label12
			// 
			this.Label12.AllowDrop = true;
			this.Label12.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.Label12.Text = "Comments";
			this.Label12.ForeColor = System.Drawing.Color.Black;
			this.Label12.Location = new System.Drawing.Point(4, 236);
			// this.Label12.mLabelId = 1851;
			this.Label12.Name="Label12";
			this.Label12.Size = new System.Drawing.Size(50, 14);
			this.Label12.TabIndex = 77;
			// 
			// _txtCommonTextBox_3
			// 
			this._txtCommonTextBox_3.AllowDrop = true;
			this._txtCommonTextBox_3.BackColor = System.Drawing.Color.White;
			// this._txtCommonTextBox_3.bolNumericOnly = true;
			this._txtCommonTextBox_3.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_3.Location = new System.Drawing.Point(98, 8);
			this._txtCommonTextBox_3.MaxLength = 4;
			this._txtCommonTextBox_3.Name = "_txtCommonTextBox_3";
			// this._txtCommonTextBox_3.ShowButton = true;
			this._txtCommonTextBox_3.Size = new System.Drawing.Size(101, 19);
			this._txtCommonTextBox_3.TabIndex = 45;
			this._txtCommonTextBox_3.Text = "";
			// this.// = "";
			// this.//this._txtCommonTextBox_3.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(//this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_3.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _lblCommonLabel_18
			// 
			this._lblCommonLabel_18.AllowDrop = true;
			this._lblCommonLabel_18.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_18.Text = "Leave Code";
			this._lblCommonLabel_18.ForeColor = System.Drawing.Color.Black;
			this._lblCommonLabel_18.Location = new System.Drawing.Point(4, 10);
			// // this._lblCommonLabel_18.mLabelId = 1124;
			this._lblCommonLabel_18.Name = "_lblCommonLabel_18";
			this._lblCommonLabel_18.Size = new System.Drawing.Size(58, 14);
			this._lblCommonLabel_18.TabIndex = 65;
			// 
			// _lblCommonLabel_19
			// 
			this._lblCommonLabel_19.AllowDrop = true;
			this._lblCommonLabel_19.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_19.Text = "Leave To";
			this._lblCommonLabel_19.ForeColor = System.Drawing.Color.Black;
			this._lblCommonLabel_19.Location = new System.Drawing.Point(210, 114);
			// // this._lblCommonLabel_19.mLabelId = 375;
			this._lblCommonLabel_19.Name = "_lblCommonLabel_19";
			this._lblCommonLabel_19.Size = new System.Drawing.Size(45, 14);
			this._lblCommonLabel_19.TabIndex = 66;
			// 
			// _txtCommonDate_2
			// 
			this._txtCommonDate_2.AllowDrop = true;
			// this._txtCommonDate_2.CheckDateRange = false;
			this._txtCommonDate_2.Location = new System.Drawing.Point(308, 113);
			// this._txtCommonDate_2.MaxDate = 2958465;
			// this._txtCommonDate_2.MinDate = 36526;
			this._txtCommonDate_2.Name = "_txtCommonDate_2";
			this._txtCommonDate_2.Size = new System.Drawing.Size(102, 19);
			this._txtCommonDate_2.TabIndex = 57;
			this._txtCommonDate_2.Text = "18-Jul-2001";
			// this._txtCommonDate_2.Value = 37090;
			//this._txtCommonDate_2.Validating += new System.ComponentModel.CancelEventHandler(this.txtCommonDate_Validating);
			// 
			// _lblCommonLabel_20
			// 
			this._lblCommonLabel_20.AllowDrop = true;
			this._lblCommonLabel_20.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_20.Text = "Leave From";
			this._lblCommonLabel_20.ForeColor = System.Drawing.Color.Black;
			this._lblCommonLabel_20.Location = new System.Drawing.Point(4, 114);
			// // this._lblCommonLabel_20.mLabelId = 371;
			this._lblCommonLabel_20.Name = "_lblCommonLabel_20";
			this._lblCommonLabel_20.Size = new System.Drawing.Size(57, 14);
			this._lblCommonLabel_20.TabIndex = 67;
			// 
			// _txtCommonNumber_3
			// 
			this._txtCommonNumber_3.AllowDrop = true;
			// this._txtCommonNumber_3.DisplayFormat = "####0.000###;;0.000;0.000";
			// this._txtCommonNumber_3.Format = "###########0.000";
			this._txtCommonNumber_3.Location = new System.Drawing.Point(308, 174);
			// // = 2147483647;
			// // = 0;
			this._txtCommonNumber_3.Name = "_txtCommonNumber_3";
			this._txtCommonNumber_3.Size = new System.Drawing.Size(101, 19);
			this._txtCommonNumber_3.TabIndex = 72;
			this._txtCommonNumber_3.Text = "0.000";
			// this.this._txtCommonNumber_3.Change += new System.Windows.Forms.TextBox.ChangeHandler(this.txtCommonNumber_Change);
			// this._txtCommonNumber_3.Enter += new System.EventHandler(this.txtCommonNumber_Enter);
			// this._txtCommonNumber_3.Leave += new System.EventHandler(this.txtCommonNumber_Leave);
			// 
			// _lblCommonLabel_21
			// 
			this._lblCommonLabel_21.AllowDrop = true;
			this._lblCommonLabel_21.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_21.Text = "Unpaid Days";
			this._lblCommonLabel_21.ForeColor = System.Drawing.Color.Black;
			this._lblCommonLabel_21.Location = new System.Drawing.Point(326, 155);
			// // this._lblCommonLabel_21.mLabelId = 1922;
			this._lblCommonLabel_21.Name = "_lblCommonLabel_21";
			this._lblCommonLabel_21.Size = new System.Drawing.Size(61, 14);
			this._lblCommonLabel_21.TabIndex = 69;
			// 
			// _CmbCommon_0
			// 
			this._CmbCommon_0.AllowDrop = true;
			this._CmbCommon_0.Location = new System.Drawing.Point(98, 212);
			this._CmbCommon_0.Name = "_CmbCommon_0";
			this._CmbCommon_0.Size = new System.Drawing.Size(207, 21);
			this._CmbCommon_0.TabIndex = 75;
			// 
			// _txtDisplayLabel_6
			// 
			this._txtDisplayLabel_6.AllowDrop = true;
			this._txtDisplayLabel_6.Location = new System.Drawing.Point(199, 8);
			this._txtDisplayLabel_6.Name = "_txtDisplayLabel_6";
			this._txtDisplayLabel_6.Size = new System.Drawing.Size(201, 19);
			this._txtDisplayLabel_6.TabIndex = 46;
			this._txtDisplayLabel_6.TabStop = false;
			// 
			// _txtDisplayLabel_7
			// 
			// //this._txtDisplayLabel_7.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
			this._txtDisplayLabel_7.AllowDrop = true;
			this._txtDisplayLabel_7.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			this._txtDisplayLabel_7.Location = new System.Drawing.Point(506, 134);
			this._txtDisplayLabel_7.Name = "_txtDisplayLabel_7";
			this._txtDisplayLabel_7.Size = new System.Drawing.Size(105, 19);
			this._txtDisplayLabel_7.TabIndex = 68;
			this._txtDisplayLabel_7.TabStop = false;
			// 
			// _txtDisplayLabel_8
			// 
			// //this._txtDisplayLabel_8.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
			this._txtDisplayLabel_8.AllowDrop = true;
			this._txtDisplayLabel_8.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			this._txtDisplayLabel_8.Location = new System.Drawing.Point(506, 192);
			this._txtDisplayLabel_8.Name = "_txtDisplayLabel_8";
			this._txtDisplayLabel_8.Size = new System.Drawing.Size(105, 19);
			this._txtDisplayLabel_8.TabIndex = 73;
			this._txtDisplayLabel_8.TabStop = false;
			// 
			// _txtCommonNumber_2
			// 
			this._txtCommonNumber_2.AllowDrop = true;
			// this._txtCommonNumber_2.DisplayFormat = "####0.000###;;0.000;0.000";
			// this._txtCommonNumber_2.Format = "###########0.000";
			this._txtCommonNumber_2.Location = new System.Drawing.Point(203, 174);
			// // = 2147483647;
			// // = 0;
			this._txtCommonNumber_2.Name = "_txtCommonNumber_2";
			this._txtCommonNumber_2.Size = new System.Drawing.Size(101, 19);
			this._txtCommonNumber_2.TabIndex = 71;
			this._txtCommonNumber_2.Text = "0.000";
			// this.this._txtCommonNumber_2.Change += new System.Windows.Forms.TextBox.ChangeHandler(this.txtCommonNumber_Change);
			// this._txtCommonNumber_2.Enter += new System.EventHandler(this.txtCommonNumber_Enter);
			// this._txtCommonNumber_2.Leave += new System.EventHandler(this.txtCommonNumber_Leave);
			// 
			// _lblCommonLabel_8
			// 
			this._lblCommonLabel_8.AllowDrop = true;
			this._lblCommonLabel_8.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_8.Text = "Paid Days";
			this._lblCommonLabel_8.ForeColor = System.Drawing.Color.Black;
			this._lblCommonLabel_8.Location = new System.Drawing.Point(210, 155);
			// // this._lblCommonLabel_8.mLabelId = 499;
			this._lblCommonLabel_8.Name = "_lblCommonLabel_8";
			this._lblCommonLabel_8.Size = new System.Drawing.Size(48, 14);
			this._lblCommonLabel_8.TabIndex = 61;
			// 
			// _txtCommonNumber_4
			// 
			this._txtCommonNumber_4.AllowDrop = true;
			// this._txtCommonNumber_4.DisplayFormat = "####0.000###;;0.000;0.000";
			// this._txtCommonNumber_4.Format = "###########0.000";
			this._txtCommonNumber_4.Location = new System.Drawing.Point(486, 248);
			// // = 2147483647;
			// // = 0;
			this._txtCommonNumber_4.Name = "_txtCommonNumber_4";
			this._txtCommonNumber_4.Size = new System.Drawing.Size(101, 19);
			this._txtCommonNumber_4.TabIndex = 85;
			this._txtCommonNumber_4.Text = "0.000";
			this._txtCommonNumber_4.Visible = false;
			// this.this._txtCommonNumber_4.Change += new System.Windows.Forms.TextBox.ChangeHandler(this.txtCommonNumber_Change);
			// this._txtCommonNumber_4.Enter += new System.EventHandler(this.txtCommonNumber_Enter);
			// this._txtCommonNumber_4.Leave += new System.EventHandler(this.txtCommonNumber_Leave);
			// 
			// _lblCommonLabel_11
			// 
			this._lblCommonLabel_11.AllowDrop = true;
			this._lblCommonLabel_11.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_11.Text = "Paid Hours";
			this._lblCommonLabel_11.ForeColor = System.Drawing.Color.Black;
			this._lblCommonLabel_11.Location = new System.Drawing.Point(428, 252);
			this._lblCommonLabel_11.Name = "_lblCommonLabel_11";
			this._lblCommonLabel_11.Size = new System.Drawing.Size(52, 14);
			this._lblCommonLabel_11.TabIndex = 80;
			this._lblCommonLabel_11.Visible = false;
			// 
			// _lblCommonLabel_12
			// 
			this._lblCommonLabel_12.AllowDrop = true;
			this._lblCommonLabel_12.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_12.Text = "Public Holidays";
			this._lblCommonLabel_12.ForeColor = System.Drawing.Color.Black;
			this._lblCommonLabel_12.Location = new System.Drawing.Point(210, 136);
			// // this._lblCommonLabel_12.mLabelId = 2125;
			this._lblCommonLabel_12.Name = "_lblCommonLabel_12";
			this._lblCommonLabel_12.Size = new System.Drawing.Size(72, 14);
			this._lblCommonLabel_12.TabIndex = 63;
			// 
			// _txtDisplayLabel_10
			// 
			// //this._txtDisplayLabel_10.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
			this._txtDisplayLabel_10.AllowDrop = true;
			this._txtDisplayLabel_10.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			this._txtDisplayLabel_10.Location = new System.Drawing.Point(308, 134);
			this._txtDisplayLabel_10.Name = "_txtDisplayLabel_10";
			this._txtDisplayLabel_10.Size = new System.Drawing.Size(102, 19);
			this._txtDisplayLabel_10.TabIndex = 59;
			this._txtDisplayLabel_10.TabStop = false;
			// 
			// _txtCommonNumber_0
			// 
			this._txtCommonNumber_0.AllowDrop = true;
			this._txtCommonNumber_0.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			// this._txtCommonNumber_0.DisplayFormat = "####0.000###;;0.000;0.000";
			this._txtCommonNumber_0.Enabled = false;
			// this._txtCommonNumber_0.Format = "###########0.000";
			this._txtCommonNumber_0.Location = new System.Drawing.Point(98, 134);
			// // = 2147483647;
			// // = 0;
			this._txtCommonNumber_0.Name = "_txtCommonNumber_0";
			this._txtCommonNumber_0.Size = new System.Drawing.Size(101, 19);
			this._txtCommonNumber_0.TabIndex = 58;
			this._txtCommonNumber_0.TabStop = false;
			this._txtCommonNumber_0.Text = "0.000";
			// this.this._txtCommonNumber_0.Change += new System.Windows.Forms.TextBox.ChangeHandler(this.txtCommonNumber_Change);
			// this._txtCommonNumber_0.Enter += new System.EventHandler(this.txtCommonNumber_Enter);
			// this._txtCommonNumber_0.Leave += new System.EventHandler(this.txtCommonNumber_Leave);
			// 
			// _lblCommonLabel_10
			// 
			this._lblCommonLabel_10.AllowDrop = true;
			this._lblCommonLabel_10.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_10.Text = "Leave Days";
			this._lblCommonLabel_10.ForeColor = System.Drawing.Color.Black;
			this._lblCommonLabel_10.Location = new System.Drawing.Point(4, 136);
			// // this._lblCommonLabel_10.mLabelId = 1986;
			this._lblCommonLabel_10.Name = "_lblCommonLabel_10";
			this._lblCommonLabel_10.Size = new System.Drawing.Size(58, 14);
			this._lblCommonLabel_10.TabIndex = 62;
			// 
			// _txtCommonDate_1
			// 
			this._txtCommonDate_1.AllowDrop = true;
			// this._txtCommonDate_1.CheckDateRange = false;
			this._txtCommonDate_1.Location = new System.Drawing.Point(98, 112);
			// this._txtCommonDate_1.MaxDate = 2958465;
			// this._txtCommonDate_1.MinDate = 36526;
			this._txtCommonDate_1.Name = "_txtCommonDate_1";
			this._txtCommonDate_1.Size = new System.Drawing.Size(102, 19);
			this._txtCommonDate_1.TabIndex = 56;
			this._txtCommonDate_1.Text = "18-Jul-2001";
			// this._txtCommonDate_1.Value = 37090;
			//this._txtCommonDate_1.Validating += new System.ComponentModel.CancelEventHandler(this.txtCommonDate_Validating);
			// 
			// _lblCommonLabel_27
			// 
			this._lblCommonLabel_27.AllowDrop = true;
			this._lblCommonLabel_27.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_27.Text = "Holiday Amount";
			this._lblCommonLabel_27.ForeColor = System.Drawing.Color.Black;
			this._lblCommonLabel_27.Location = new System.Drawing.Point(416, 176);
			// // this._lblCommonLabel_27.mLabelId = 2149;
			this._lblCommonLabel_27.Name = "_lblCommonLabel_27";
			this._lblCommonLabel_27.Size = new System.Drawing.Size(75, 14);
			this._lblCommonLabel_27.TabIndex = 84;
			// 
			// _txtDisplayLabel_12
			// 
			// //this._txtDisplayLabel_12.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
			this._txtDisplayLabel_12.AllowDrop = true;
			this._txtDisplayLabel_12.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			this._txtDisplayLabel_12.Location = new System.Drawing.Point(506, 174);
			this._txtDisplayLabel_12.Name = "_txtDisplayLabel_12";
			this._txtDisplayLabel_12.Size = new System.Drawing.Size(105, 19);
			this._txtDisplayLabel_12.TabIndex = 74;
			this._txtDisplayLabel_12.TabStop = false;
			// 
			// chkLoanGenrate
			// 
			this.chkLoanGenrate.AllowDrop = true;
			this.chkLoanGenrate.Appearance = System.Windows.Forms.Appearance.Normal;
			this.chkLoanGenrate.BackColor = System.Drawing.SystemColors.Control;
			this.chkLoanGenrate.CausesValidation = true;
			this.chkLoanGenrate.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkLoanGenrate.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this.chkLoanGenrate.Enabled = true;
			this.chkLoanGenrate.ForeColor = System.Drawing.SystemColors.ControlText;
			this.chkLoanGenrate.Location = new System.Drawing.Point(507, 120);
			this.chkLoanGenrate.Name = "chkLoanGenrate";
			this.chkLoanGenrate.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.chkLoanGenrate.Size = new System.Drawing.Size(13, 13);
			this.chkLoanGenrate.TabIndex = 20;
			this.chkLoanGenrate.TabStop = true;
			// this.chkLoanGenrate.Text = "";
			// this.chkLoanGenrate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkLoanGenrate.Visible = true;
			// 
			// _txtCommonTextBox_2
			// 
			this._txtCommonTextBox_2.AllowDrop = true;
			this._txtCommonTextBox_2.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_2.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_2.Location = new System.Drawing.Point(104, 41);
			this._txtCommonTextBox_2.MaxLength = 20;
			this._txtCommonTextBox_2.Name = "_txtCommonTextBox_2";
			this._txtCommonTextBox_2.Size = new System.Drawing.Size(102, 19);
			this._txtCommonTextBox_2.TabIndex = 3;
			this._txtCommonTextBox_2.Text = "";
			// this.// = "";
			// this.//this._txtCommonTextBox_2.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(//this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_2.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _lblCommonLabel_7
			// 
			this._lblCommonLabel_7.AllowDrop = true;
			this._lblCommonLabel_7.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_7.Text = "Reference No.";
			this._lblCommonLabel_7.ForeColor = System.Drawing.Color.Black;
			this._lblCommonLabel_7.Location = new System.Drawing.Point(10, 44);
			// // this._lblCommonLabel_7.mLabelId = 1964;
			this._lblCommonLabel_7.Name = "_lblCommonLabel_7";
			this._lblCommonLabel_7.Size = new System.Drawing.Size(70, 13);
			this._lblCommonLabel_7.TabIndex = 14;
			// 
			// _lblCommonLabel_5
			// 
			this._lblCommonLabel_5.AllowDrop = true;
			this._lblCommonLabel_5.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_5.Text = "Transaction No.";
			this._lblCommonLabel_5.ForeColor = System.Drawing.Color.Black;
			this._lblCommonLabel_5.Location = new System.Drawing.Point(10, 22);
			// // this._lblCommonLabel_5.mLabelId = 1744;
			this._lblCommonLabel_5.Name = "_lblCommonLabel_5";
			this._lblCommonLabel_5.Size = new System.Drawing.Size(76, 14);
			this._lblCommonLabel_5.TabIndex = 12;
			// 
			// _lblCommonLabel_6
			// 
			this._lblCommonLabel_6.AllowDrop = true;
			this._lblCommonLabel_6.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_6.Text = "Transaction Date";
			this._lblCommonLabel_6.ForeColor = System.Drawing.Color.Black;
			this._lblCommonLabel_6.Location = new System.Drawing.Point(416, 22);
			// // this._lblCommonLabel_6.mLabelId = 1233;
			this._lblCommonLabel_6.Name = "_lblCommonLabel_6";
			this._lblCommonLabel_6.Size = new System.Drawing.Size(82, 14);
			this._lblCommonLabel_6.TabIndex = 13;
			// 
			// _txtCommonDate_0
			// 
			this._txtCommonDate_0.AllowDrop = true;
			// this._txtCommonDate_0.CheckDateRange = false;
			this._txtCommonDate_0.Location = new System.Drawing.Point(501, 20);
			// this._txtCommonDate_0.MaxDate = 2958465;
			// this._txtCommonDate_0.MinDate = 32874;
			this._txtCommonDate_0.Name = "_txtCommonDate_0";
			this._txtCommonDate_0.Size = new System.Drawing.Size(101, 19);
			this._txtCommonDate_0.TabIndex = 1;
			this._txtCommonDate_0.Text = "18-Jul-2001";
			// this._txtCommonDate_0.Value = 37090;
			//this._txtCommonDate_0.Validating += new System.ComponentModel.CancelEventHandler(this.txtCommonDate_Validating);
			// 
			// _txtCommonTextBox_0
			// 
			this._txtCommonTextBox_0.AllowDrop = true;
			this._txtCommonTextBox_0.BackColor = System.Drawing.Color.FromArgb(239, 239, 239);
			// this._txtCommonTextBox_0.bolNumericOnly = true;
			this._txtCommonTextBox_0.Enabled = false;
			this._txtCommonTextBox_0.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_0.Location = new System.Drawing.Point(104, 20);
			// // = System.Windows.Forms.TextBox.DropDownTypes.ddtNextNumber;
			this._txtCommonTextBox_0.Name = "_txtCommonTextBox_0";
			// this._txtCommonTextBox_0.ShowButton = true;
			this._txtCommonTextBox_0.Size = new System.Drawing.Size(102, 19);
			this._txtCommonTextBox_0.TabIndex = 0;
			this._txtCommonTextBox_0.TabStop = false;
			this._txtCommonTextBox_0.Text = "";
			// this.// = "";
			// this.//this._txtCommonTextBox_0.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(//this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_0.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _lblCommonLabel_2
			// 
			this._lblCommonLabel_2.AllowDrop = true;
			this._lblCommonLabel_2.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_2.Text = "Employee Code";
			this._lblCommonLabel_2.ForeColor = System.Drawing.Color.Black;
			this._lblCommonLabel_2.Location = new System.Drawing.Point(10, 76);
			// // this._lblCommonLabel_2.mLabelId = 236;
			this._lblCommonLabel_2.Name = "_lblCommonLabel_2";
			this._lblCommonLabel_2.Size = new System.Drawing.Size(74, 14);
			this._lblCommonLabel_2.TabIndex = 11;
			// 
			// _lblCommonLabel_0
			// 
			this._lblCommonLabel_0.AllowDrop = true;
			this._lblCommonLabel_0.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_0.Text = "Department Code";
			this._lblCommonLabel_0.ForeColor = System.Drawing.Color.Black;
			this._lblCommonLabel_0.Location = new System.Drawing.Point(10, 97);
			// // this._lblCommonLabel_0.mLabelId = 1973;
			this._lblCommonLabel_0.Name = "_lblCommonLabel_0";
			this._lblCommonLabel_0.Size = new System.Drawing.Size(83, 14);
			this._lblCommonLabel_0.TabIndex = 8;
			// 
			// _lblCommonLabel_1
			// 
			this._lblCommonLabel_1.AllowDrop = true;
			this._lblCommonLabel_1.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_1.Text = "Designation Code";
			this._lblCommonLabel_1.ForeColor = System.Drawing.Color.Black;
			this._lblCommonLabel_1.Location = new System.Drawing.Point(10, 118);
			// // this._lblCommonLabel_1.mLabelId = 1049;
			this._lblCommonLabel_1.Name = "_lblCommonLabel_1";
			this._lblCommonLabel_1.Size = new System.Drawing.Size(84, 14);
			this._lblCommonLabel_1.TabIndex = 10;
			// 
			// _txtCommonTextBox_1
			// 
			this._txtCommonTextBox_1.AllowDrop = true;
			this._txtCommonTextBox_1.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_1.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_1.Location = new System.Drawing.Point(104, 74);
			this._txtCommonTextBox_1.MaxLength = 10;
			this._txtCommonTextBox_1.Name = "_txtCommonTextBox_1";
			// this._txtCommonTextBox_1.ShowButton = true;
			this._txtCommonTextBox_1.Size = new System.Drawing.Size(101, 19);
			this._txtCommonTextBox_1.TabIndex = 2;
			this._txtCommonTextBox_1.Text = "";
			// this.// = "";
			// this.//this._txtCommonTextBox_1.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(//this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_1.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _lblCommonLabel_9
			// 
			this._lblCommonLabel_9.AllowDrop = true;
			this._lblCommonLabel_9.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_9.Text = "Total Salary";
			this._lblCommonLabel_9.ForeColor = System.Drawing.Color.Black;
			this._lblCommonLabel_9.Location = new System.Drawing.Point(416, 50);
			// // this._lblCommonLabel_9.mLabelId = 818;
			this._lblCommonLabel_9.Name = "_lblCommonLabel_9";
			this._lblCommonLabel_9.Size = new System.Drawing.Size(57, 14);
			this._lblCommonLabel_9.TabIndex = 15;
			this._lblCommonLabel_9.Visible = false;
			// 
			// _txtDisplayLabel_9
			// 
			// //this._txtDisplayLabel_9.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
			this._txtDisplayLabel_9.AllowDrop = true;
			this._txtDisplayLabel_9.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			this._txtDisplayLabel_9.Location = new System.Drawing.Point(501, 48);
			this._txtDisplayLabel_9.Name = "_txtDisplayLabel_9";
			this._txtDisplayLabel_9.Size = new System.Drawing.Size(101, 19);
			this._txtDisplayLabel_9.TabIndex = 7;
			this._txtDisplayLabel_9.TabStop = false;
			this._txtDisplayLabel_9.Visible = false;
			// 
			// _txtDisplayLabel_5
			// 
			this._txtDisplayLabel_5.AllowDrop = true;
			this._txtDisplayLabel_5.Location = new System.Drawing.Point(207, 74);
			this._txtDisplayLabel_5.Name = "_txtDisplayLabel_5";
			this._txtDisplayLabel_5.Size = new System.Drawing.Size(395, 19);
			this._txtDisplayLabel_5.TabIndex = 6;
			this._txtDisplayLabel_5.TabStop = false;
			// 
			// _txtDisplayLabel_3
			// 
			this._txtDisplayLabel_3.AllowDrop = true;
			this._txtDisplayLabel_3.Location = new System.Drawing.Point(207, 116);
			this._txtDisplayLabel_3.Name = "_txtDisplayLabel_3";
			this._txtDisplayLabel_3.Size = new System.Drawing.Size(203, 19);
			this._txtDisplayLabel_3.TabIndex = 18;
			this._txtDisplayLabel_3.TabStop = false;
			// 
			// _txtDisplayLabel_2
			// 
			this._txtDisplayLabel_2.AllowDrop = true;
			this._txtDisplayLabel_2.Location = new System.Drawing.Point(104, 116);
			this._txtDisplayLabel_2.Name = "_txtDisplayLabel_2";
			this._txtDisplayLabel_2.Size = new System.Drawing.Size(101, 19);
			this._txtDisplayLabel_2.TabIndex = 17;
			this._txtDisplayLabel_2.TabStop = false;
			// 
			// _txtDisplayLabel_1
			// 
			this._txtDisplayLabel_1.AllowDrop = true;
			this._txtDisplayLabel_1.Location = new System.Drawing.Point(207, 95);
			this._txtDisplayLabel_1.Name = "_txtDisplayLabel_1";
			this._txtDisplayLabel_1.Size = new System.Drawing.Size(203, 19);
			this._txtDisplayLabel_1.TabIndex = 5;
			this._txtDisplayLabel_1.TabStop = false;
			// 
			// _txtDisplayLabel_0
			// 
			this._txtDisplayLabel_0.AllowDrop = true;
			this._txtDisplayLabel_0.Location = new System.Drawing.Point(104, 95);
			this._txtDisplayLabel_0.Name = "_txtDisplayLabel_0";
			this._txtDisplayLabel_0.Size = new System.Drawing.Size(101, 19);
			this._txtDisplayLabel_0.TabIndex = 4;
			this._txtDisplayLabel_0.TabStop = false;
			// 
			// txtJoiningDate
			// 
			this.txtJoiningDate.AllowDrop = true;
			this.txtJoiningDate.BackColor = System.Drawing.Color.FromArgb(239, 239, 239);
			// this.txtJoiningDate.CheckDateRange = false;
			this.txtJoiningDate.Enabled = false;
			this.txtJoiningDate.Location = new System.Drawing.Point(505, 96);
			// this.txtJoiningDate.MaxDate = 2958465;
			// this.txtJoiningDate.MinDate = 2;
			this.txtJoiningDate.Name = "txtJoiningDate";
			this.txtJoiningDate.Size = new System.Drawing.Size(96, 19);
			this.txtJoiningDate.TabIndex = 9;
			// this.txtJoiningDate.Text = "18-Jul-2001";
			// this.txtJoiningDate.Value = 37090;
			// 
			// _lblCommonLabel_29
			// 
			this._lblCommonLabel_29.AllowDrop = true;
			this._lblCommonLabel_29.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_29.Text = "Joining Date";
			this._lblCommonLabel_29.ForeColor = System.Drawing.Color.Black;
			this._lblCommonLabel_29.Location = new System.Drawing.Point(414, 99);
			this._lblCommonLabel_29.Name = "_lblCommonLabel_29";
			this._lblCommonLabel_29.Size = new System.Drawing.Size(58, 14);
			this._lblCommonLabel_29.TabIndex = 16;
			// 
			// _lblCommonLabel_30
			// 
			this._lblCommonLabel_30.AllowDrop = true;
			this._lblCommonLabel_30.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_30.Text = "ReGenerate Loan";
			this._lblCommonLabel_30.ForeColor = System.Drawing.Color.Black;
			this._lblCommonLabel_30.Location = new System.Drawing.Point(414, 120);
			this._lblCommonLabel_30.Name = "_lblCommonLabel_30";
			this._lblCommonLabel_30.Size = new System.Drawing.Size(85, 14);
			this._lblCommonLabel_30.TabIndex = 19;
			// 
			// frmPayLeaveTransaction
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.ClientSize = new System.Drawing.Size(1404, 641);
			this.Controls.Add(this.tbleave);
			this.Controls.Add(this.chkLoanGenrate);
			this.Controls.Add(this._txtCommonTextBox_2);
			this.Controls.Add(this._lblCommonLabel_7);
			this.Controls.Add(this._lblCommonLabel_5);
			this.Controls.Add(this._lblCommonLabel_6);
			this.Controls.Add(this._txtCommonDate_0);
			this.Controls.Add(this._txtCommonTextBox_0);
			this.Controls.Add(this._lblCommonLabel_2);
			this.Controls.Add(this._lblCommonLabel_0);
			this.Controls.Add(this._lblCommonLabel_1);
			this.Controls.Add(this._txtCommonTextBox_1);
			this.Controls.Add(this._lblCommonLabel_9);
			this.Controls.Add(this._txtDisplayLabel_9);
			this.Controls.Add(this._txtDisplayLabel_5);
			this.Controls.Add(this._txtDisplayLabel_3);
			this.Controls.Add(this._txtDisplayLabel_2);
			this.Controls.Add(this._txtDisplayLabel_1);
			this.Controls.Add(this._txtDisplayLabel_0);
			this.Controls.Add(this.txtJoiningDate);
			this.Controls.Add(this._lblCommonLabel_29);
			this.Controls.Add(this._lblCommonLabel_30);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			//this.Icon = (System.Drawing.Icon) resources.GetObject("frmPayLeaveTransaction.Icon");
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(94, 203);
			this.MaximizeBox = true;
			this.MinimizeBox = true;
			this.Name = "frmPayLeaveTransaction";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Leave Transaction";
			// this.Activated += new System.EventHandler(this.frmPayLeaveTransaction_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
			// this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
			//((System.ComponentModel.ISupportInitialize) this.TabControlPage3).EndInit();
			//((System.ComponentModel.ISupportInitialize) this.TabControlPage2).EndInit();
			//((System.ComponentModel.ISupportInitialize) this.TabControlPage1).EndInit();
			//((System.ComponentModel.ISupportInitialize) this.tbleave).EndInit();
			this.tbleave.ResumeLayout(false);
			this.TabControlPage3.ResumeLayout(false);
			this.TabControlPage2.ResumeLayout(false);
			this.TabControlPage1.ResumeLayout(false);
			this.frmLeaveInformation.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		// 
		void InitializetxtDisplayLabel()
		{
			this.txtDisplayLabel = new System.Windows.Forms.Label[15];
			this.txtDisplayLabel[11] = _txtDisplayLabel_11;
			this.txtDisplayLabel[14] = _txtDisplayLabel_14;
			this.txtDisplayLabel[4] = _txtDisplayLabel_4;
			this.txtDisplayLabel[13] = _txtDisplayLabel_13;
			this.txtDisplayLabel[6] = _txtDisplayLabel_6;
			this.txtDisplayLabel[7] = _txtDisplayLabel_7;
			this.txtDisplayLabel[8] = _txtDisplayLabel_8;
			this.txtDisplayLabel[10] = _txtDisplayLabel_10;
			this.txtDisplayLabel[12] = _txtDisplayLabel_12;
			this.txtDisplayLabel[9] = _txtDisplayLabel_9;
			this.txtDisplayLabel[5] = _txtDisplayLabel_5;
			this.txtDisplayLabel[3] = _txtDisplayLabel_3;
			this.txtDisplayLabel[2] = _txtDisplayLabel_2;
			this.txtDisplayLabel[1] = _txtDisplayLabel_1;
			this.txtDisplayLabel[0] = _txtDisplayLabel_0;
		}
		void InitializetxtCommonTextBox()
		{
			this.txtCommonTextBox = new System.Windows.Forms.TextBox[7];
			this.txtCommonTextBox[4] = _txtCommonTextBox_4;
			this.txtCommonTextBox[6] = _txtCommonTextBox_6;
			this.txtCommonTextBox[5] = _txtCommonTextBox_5;
			this.txtCommonTextBox[3] = _txtCommonTextBox_3;
			this.txtCommonTextBox[2] = _txtCommonTextBox_2;
			this.txtCommonTextBox[0] = _txtCommonTextBox_0;
			this.txtCommonTextBox[1] = _txtCommonTextBox_1;
		}
		void InitializetxtCommonNumber()
		{
			this.txtCommonNumber = new System.Windows.Forms.TextBox[8];
			this.txtCommonNumber[5] = _txtCommonNumber_5;
			this.txtCommonNumber[6] = _txtCommonNumber_6;
			this.txtCommonNumber[7] = _txtCommonNumber_7;
			this.txtCommonNumber[1] = _txtCommonNumber_1;
			this.txtCommonNumber[3] = _txtCommonNumber_3;
			this.txtCommonNumber[2] = _txtCommonNumber_2;
			this.txtCommonNumber[4] = _txtCommonNumber_4;
			this.txtCommonNumber[0] = _txtCommonNumber_0;
		}
		void InitializetxtCommonDate()
		{
			this.txtCommonDate = new Syncfusion.WinForms.Input.SfDateTimeEdit[6];
			this.txtCommonDate[5] = _txtCommonDate_5;
			this.txtCommonDate[4] = _txtCommonDate_4;
			this.txtCommonDate[3] = _txtCommonDate_3;
			this.txtCommonDate[2] = _txtCommonDate_2;
			this.txtCommonDate[1] = _txtCommonDate_1;
			this.txtCommonDate[0] = _txtCommonDate_0;
		}
		void InitializelblCommonLabel()
		{
			this.lblCommonLabel = new System.Windows.Forms.Label[31];
			this.lblCommonLabel[28] = _lblCommonLabel_28;
			this.lblCommonLabel[24] = _lblCommonLabel_24;
			this.lblCommonLabel[25] = _lblCommonLabel_25;
			this.lblCommonLabel[26] = _lblCommonLabel_26;
			this.lblCommonLabel[23] = _lblCommonLabel_23;
			this.lblCommonLabel[22] = _lblCommonLabel_22;
			this.lblCommonLabel[15] = _lblCommonLabel_15;
			this.lblCommonLabel[3] = _lblCommonLabel_3;
			this.lblCommonLabel[13] = _lblCommonLabel_13;
			this.lblCommonLabel[4] = _lblCommonLabel_4;
			this.lblCommonLabel[14] = _lblCommonLabel_14;
			this.lblCommonLabel[16] = _lblCommonLabel_16;
			this.lblCommonLabel[17] = _lblCommonLabel_17;
			this.lblCommonLabel[18] = _lblCommonLabel_18;
			this.lblCommonLabel[19] = _lblCommonLabel_19;
			this.lblCommonLabel[20] = _lblCommonLabel_20;
			this.lblCommonLabel[21] = _lblCommonLabel_21;
			this.lblCommonLabel[8] = _lblCommonLabel_8;
			this.lblCommonLabel[11] = _lblCommonLabel_11;
			this.lblCommonLabel[12] = _lblCommonLabel_12;
			this.lblCommonLabel[10] = _lblCommonLabel_10;
			this.lblCommonLabel[27] = _lblCommonLabel_27;
			this.lblCommonLabel[7] = _lblCommonLabel_7;
			this.lblCommonLabel[5] = _lblCommonLabel_5;
			this.lblCommonLabel[6] = _lblCommonLabel_6;
			this.lblCommonLabel[2] = _lblCommonLabel_2;
			this.lblCommonLabel[0] = _lblCommonLabel_0;
			this.lblCommonLabel[1] = _lblCommonLabel_1;
			this.lblCommonLabel[9] = _lblCommonLabel_9;
			this.lblCommonLabel[29] = _lblCommonLabel_29;
			this.lblCommonLabel[30] = _lblCommonLabel_30;
		}
		void InitializeSystemWindowsFormsLabel3()
		{
			this.Label3 = new System.Windows.Forms.Label[2];
			this.Label3[0] = Label3_0;
			this.Label3[1] = Label3_1;
		}
		void InitializeOptCashOrBooked()
		{
			this.OptCashOrBooked = new System.Windows.Forms.RadioButton[2];
			this.OptCashOrBooked[0] = _OptCashOrBooked_0;
			this.OptCashOrBooked[1] = _OptCashOrBooked_1;
		}
		void InitializeCmbCommon()
		{
			this.CmbCommon = new System.Windows.Forms.ComboBox[1];
			this.CmbCommon[0] = _CmbCommon_0;
		}
		#endregion
	}
}//ENDSHERE
