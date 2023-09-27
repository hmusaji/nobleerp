
namespace Xtreme
{
	partial class frmPayLeaveResume
	{

		#region "Upgrade Support "
		private static frmPayLeaveResume m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmPayLeaveResume DefInstance
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
		public static frmPayLeaveResume CreateInstance()
		{
			frmPayLeaveResume theInstance = new frmPayLeaveResume();
			
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
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "cmdSubmmitApproval", "txtDlblAppTemplateName", "txtApprovalTemplate", "_lblCommonLabel_28", "Frame2", "txtGrantDays", "System.Windows.Forms.Label2", "System.Windows.Forms.Label1", "txtDisplayVariationDays", "txtEncashmentDays", "txtAdjustUnpaidDays", "txtAdjustPaidDays", "System.Windows.Forms.Label12", "_txtCommonTextBox_4", "_lblCommonLabel_11", "_txtCommonDate_1", "_lblCommonLabel_15", "_lblCommonLabel_16", "txtLeaveBalOnResume", "_lblCommonLabel_22", "_lblCommonLabel_23", "txtSalaryAdjusted", "_lblCommonLabel_24", "frm", "Frame1", "tabResume", "_txtCommonTextBox_2", "_lblCommonLabel_7", "_lblCommonLabel_5", "_lblCommonLabel_6", "_txtCommonTextBox_0", "_lblCommonLabel_2", "_lblCommonLabel_0", "_lblCommonLabel_1", "_lblCommonLabel_3", "_txtCommonNumber_0", "_lblCommonLabel_10", "_txtCommonNumber_1", "_lblCommonLabel_4", "_lblCommonLabel_17", "_txtCommonTextBox_3", "_lblCommonLabel_18", "_lblCommonLabel_19", "_lblCommonLabel_20", "_txtCommonNumber_2", "_lblCommonLabel_8", "_txtCommonNumber_3", "_lblCommonLabel_21", "_txtCommonTextBox_1", "_lblCommonLabel_9", "_lblCommonLabel_12", "_txtCommonDate_0", "_lblCommonLabel_13", "_txtDisplayLabel_12", "_txtDisplayLabel_11", "_txtDisplayLabel_10", "_txtDisplayLabel_8", "_txtDisplayLabel_0", "_txtDisplayLabel_1", "_txtDisplayLabel_2", "_txtDisplayLabel_3", "_txtDisplayLabel_4", "_txtDisplayLabel_7", "_txtDisplayLabel_6", "_txtDisplayLabel_5", "_txtDisplayLabel_9", "_lblCommonLabel_14", "_txtCommonNumber_4", "txtJoiningDate", "_lblCommonLabel_29", "lblCommonLabel", "txtCommonDate", "txtCommonNumber", "txtCommonTextBox", "txtDisplayLabel"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public System.Windows.Forms.Button cmdSubmmitApproval;
		public System.Windows.Forms.Label txtDlblAppTemplateName;
		public System.Windows.Forms.TextBox txtApprovalTemplate;
		private System.Windows.Forms.Label _lblCommonLabel_28;
		public System.Windows.Forms.Panel Frame2;
		public System.Windows.Forms.TextBox txtGrantDays;
		public System.Windows.Forms.Label Label2;
		public System.Windows.Forms.Label Label1;
		public System.Windows.Forms.Label txtDisplayVariationDays;
		public System.Windows.Forms.TextBox txtEncashmentDays;
		public System.Windows.Forms.TextBox txtAdjustUnpaidDays;
		public System.Windows.Forms.TextBox txtAdjustPaidDays;
		public System.Windows.Forms.Label Label12;
		private System.Windows.Forms.TextBox _txtCommonTextBox_4;
		private System.Windows.Forms.Label _lblCommonLabel_11;
		private Syncfusion.WinForms.Input.SfDateTimeEdit _txtCommonDate_1;
		private System.Windows.Forms.Label _lblCommonLabel_15;
		private System.Windows.Forms.Label _lblCommonLabel_16;
		public System.Windows.Forms.TextBox txtLeaveBalOnResume;
		private System.Windows.Forms.Label _lblCommonLabel_22;
		private System.Windows.Forms.Label _lblCommonLabel_23;
		public System.Windows.Forms.TextBox txtSalaryAdjusted;
		private System.Windows.Forms.Label _lblCommonLabel_24;
		public System.Windows.Forms.GroupBox frm;
		public System.Windows.Forms.Panel Frame1;
		public Syncfusion.Windows.Forms.Tools.TabControlAdv tabResume;
		private System.Windows.Forms.TextBox _txtCommonTextBox_2;
		private System.Windows.Forms.Label _lblCommonLabel_7;
		private System.Windows.Forms.Label _lblCommonLabel_5;
		private System.Windows.Forms.Label _lblCommonLabel_6;
		private System.Windows.Forms.TextBox _txtCommonTextBox_0;
		private System.Windows.Forms.Label _lblCommonLabel_2;
		private System.Windows.Forms.Label _lblCommonLabel_0;
		private System.Windows.Forms.Label _lblCommonLabel_1;
		private System.Windows.Forms.Label _lblCommonLabel_3;
		private System.Windows.Forms.TextBox _txtCommonNumber_0;
		private System.Windows.Forms.Label _lblCommonLabel_10;
		private System.Windows.Forms.TextBox _txtCommonNumber_1;
		private System.Windows.Forms.Label _lblCommonLabel_4;
		private System.Windows.Forms.Label _lblCommonLabel_17;
		private System.Windows.Forms.TextBox _txtCommonTextBox_3;
		private System.Windows.Forms.Label _lblCommonLabel_18;
		private System.Windows.Forms.Label _lblCommonLabel_19;
		private System.Windows.Forms.Label _lblCommonLabel_20;
		private System.Windows.Forms.TextBox _txtCommonNumber_2;
		private System.Windows.Forms.Label _lblCommonLabel_8;
		private System.Windows.Forms.TextBox _txtCommonNumber_3;
		private System.Windows.Forms.Label _lblCommonLabel_21;
		private System.Windows.Forms.TextBox _txtCommonTextBox_1;
		private System.Windows.Forms.Label _lblCommonLabel_9;
		private System.Windows.Forms.Label _lblCommonLabel_12;
		private Syncfusion.WinForms.Input.SfDateTimeEdit _txtCommonDate_0;
		private System.Windows.Forms.Label _lblCommonLabel_13;
		private System.Windows.Forms.Label _txtDisplayLabel_12;
		private System.Windows.Forms.Label _txtDisplayLabel_11;
		private System.Windows.Forms.Label _txtDisplayLabel_10;
		private System.Windows.Forms.Label _txtDisplayLabel_8;
		private System.Windows.Forms.Label _txtDisplayLabel_0;
		private System.Windows.Forms.Label _txtDisplayLabel_1;
		private System.Windows.Forms.Label _txtDisplayLabel_2;
		private System.Windows.Forms.Label _txtDisplayLabel_3;
		private System.Windows.Forms.Label _txtDisplayLabel_4;
		private System.Windows.Forms.Label _txtDisplayLabel_7;
		private System.Windows.Forms.Label _txtDisplayLabel_6;
		private System.Windows.Forms.Label _txtDisplayLabel_5;
		private System.Windows.Forms.Label _txtDisplayLabel_9;
		private System.Windows.Forms.Label _lblCommonLabel_14;
		private System.Windows.Forms.TextBox _txtCommonNumber_4;
		public Syncfusion.WinForms.Input.SfDateTimeEdit txtJoiningDate;
		private System.Windows.Forms.Label _lblCommonLabel_29;
		public System.Windows.Forms.Label[] lblCommonLabel = new System.Windows.Forms.Label[30];
		public Syncfusion.WinForms.Input.SfDateTimeEdit[] txtCommonDate = new Syncfusion.WinForms.Input.SfDateTimeEdit[2];
		public System.Windows.Forms.TextBox[] txtCommonNumber = new System.Windows.Forms.TextBox[5];
		public System.Windows.Forms.TextBox[] txtCommonTextBox = new System.Windows.Forms.TextBox[5];
		public System.Windows.Forms.Label[] txtDisplayLabel = new System.Windows.Forms.Label[13];
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPayLeaveResume));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this.tabResume = new Syncfusion.Windows.Forms.Tools.TabControlAdv();
			this.Frame2 = new System.Windows.Forms.Panel();
			this.cmdSubmmitApproval = new System.Windows.Forms.Button();
			this.txtDlblAppTemplateName = new System.Windows.Forms.Label();
			this.txtApprovalTemplate = new System.Windows.Forms.TextBox();
			this._lblCommonLabel_28 = new System.Windows.Forms.Label();
			this.Frame1 = new System.Windows.Forms.Panel();
			this.frm = new System.Windows.Forms.GroupBox();
			this.txtGrantDays = new System.Windows.Forms.TextBox();
			this.Label2 = new System.Windows.Forms.Label();
			this.Label1 = new System.Windows.Forms.Label();
			this.txtDisplayVariationDays = new System.Windows.Forms.Label();
			this.txtEncashmentDays = new System.Windows.Forms.TextBox();
			this.txtAdjustUnpaidDays = new System.Windows.Forms.TextBox();
			this.txtAdjustPaidDays = new System.Windows.Forms.TextBox();
			this.Label12 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_4 = new System.Windows.Forms.TextBox();
			this._lblCommonLabel_11 = new System.Windows.Forms.Label();
			this._txtCommonDate_1 = new Syncfusion.WinForms.Input.SfDateTimeEdit();
			this._lblCommonLabel_15 = new System.Windows.Forms.Label();
			this._lblCommonLabel_16 = new System.Windows.Forms.Label();
			this.txtLeaveBalOnResume = new System.Windows.Forms.TextBox();
			this._lblCommonLabel_22 = new System.Windows.Forms.Label();
			this._lblCommonLabel_23 = new System.Windows.Forms.Label();
			this.txtSalaryAdjusted = new System.Windows.Forms.TextBox();
			this._lblCommonLabel_24 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_2 = new System.Windows.Forms.TextBox();
			this._lblCommonLabel_7 = new System.Windows.Forms.Label();
			this._lblCommonLabel_5 = new System.Windows.Forms.Label();
			this._lblCommonLabel_6 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_0 = new System.Windows.Forms.TextBox();
			this._lblCommonLabel_2 = new System.Windows.Forms.Label();
			this._lblCommonLabel_0 = new System.Windows.Forms.Label();
			this._lblCommonLabel_1 = new System.Windows.Forms.Label();
			this._lblCommonLabel_3 = new System.Windows.Forms.Label();
			this._txtCommonNumber_0 = new System.Windows.Forms.TextBox();
			this._lblCommonLabel_10 = new System.Windows.Forms.Label();
			this._txtCommonNumber_1 = new System.Windows.Forms.TextBox();
			this._lblCommonLabel_4 = new System.Windows.Forms.Label();
			this._lblCommonLabel_17 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_3 = new System.Windows.Forms.TextBox();
			this._lblCommonLabel_18 = new System.Windows.Forms.Label();
			this._lblCommonLabel_19 = new System.Windows.Forms.Label();
			this._lblCommonLabel_20 = new System.Windows.Forms.Label();
			this._txtCommonNumber_2 = new System.Windows.Forms.TextBox();
			this._lblCommonLabel_8 = new System.Windows.Forms.Label();
			this._txtCommonNumber_3 = new System.Windows.Forms.TextBox();
			this._lblCommonLabel_21 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_1 = new System.Windows.Forms.TextBox();
			this._lblCommonLabel_9 = new System.Windows.Forms.Label();
			this._lblCommonLabel_12 = new System.Windows.Forms.Label();
			this._txtCommonDate_0 = new Syncfusion.WinForms.Input.SfDateTimeEdit();
			this._lblCommonLabel_13 = new System.Windows.Forms.Label();
			this._txtDisplayLabel_12 = new System.Windows.Forms.Label();
			this._txtDisplayLabel_11 = new System.Windows.Forms.Label();
			this._txtDisplayLabel_10 = new System.Windows.Forms.Label();
			this._txtDisplayLabel_8 = new System.Windows.Forms.Label();
			this._txtDisplayLabel_0 = new System.Windows.Forms.Label();
			this._txtDisplayLabel_1 = new System.Windows.Forms.Label();
			this._txtDisplayLabel_2 = new System.Windows.Forms.Label();
			this._txtDisplayLabel_3 = new System.Windows.Forms.Label();
			this._txtDisplayLabel_4 = new System.Windows.Forms.Label();
			this._txtDisplayLabel_7 = new System.Windows.Forms.Label();
			this._txtDisplayLabel_6 = new System.Windows.Forms.Label();
			this._txtDisplayLabel_5 = new System.Windows.Forms.Label();
			this._txtDisplayLabel_9 = new System.Windows.Forms.Label();
			this._lblCommonLabel_14 = new System.Windows.Forms.Label();
			this._txtCommonNumber_4 = new System.Windows.Forms.TextBox();
			this.txtJoiningDate = new Syncfusion.WinForms.Input.SfDateTimeEdit();
			this._lblCommonLabel_29 = new System.Windows.Forms.Label();
			// //((System.ComponentModel.ISupportInitialize) this.tabResume).BeginInit();
			//this.tabResume.SuspendLayout();
			//this.Frame2.SuspendLayout();
			//this.Frame1.SuspendLayout();
			//this.frm.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabResume
			// 
			//this.tabResume.Align = C1SizerLib.AlignSettings.asNone;
			//this.tabResume.AllowDrop = true;
			this.tabResume.Controls.Add(this.Frame2);
			this.tabResume.Controls.Add(this.Frame1);
			this.tabResume.Location = new System.Drawing.Point(3, 273);
			this.tabResume.Name = "tabResume";
			//
			this.tabResume.Size = new System.Drawing.Size(616, 133);
			this.tabResume.TabIndex = 42;
			// 
			// Frame2
			// 
			//this.Frame2.AllowDrop = true;
			this.Frame2.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			//this.Frame2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Frame2.Controls.Add(this.cmdSubmmitApproval);
			this.Frame2.Controls.Add(this.txtDlblAppTemplateName);
			this.Frame2.Controls.Add(this.txtApprovalTemplate);
			this.Frame2.Controls.Add(this._lblCommonLabel_28);
			this.Frame2.Enabled = true;
			this.Frame2.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Frame2.Location = new System.Drawing.Point(659, 22);
			this.Frame2.Name = "Frame2";
			this.Frame2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Frame2.Size = new System.Drawing.Size(610, 108);
			this.Frame2.TabIndex = 44;
			this.Frame2.Visible = true;
			// 
			// cmdSubmmitApproval
			// 
			//this.cmdSubmmitApproval.AllowDrop = true;
			this.cmdSubmmitApproval.BackColor = System.Drawing.SystemColors.Control;
			this.cmdSubmmitApproval.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdSubmmitApproval.Location = new System.Drawing.Point(456, 12);
			this.cmdSubmmitApproval.Name = "cmdSubmmitApproval";
			this.cmdSubmmitApproval.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdSubmmitApproval.Size = new System.Drawing.Size(97, 28);
			this.cmdSubmmitApproval.TabIndex = 64;
			this.cmdSubmmitApproval.Text = "Submmit";
			this.cmdSubmmitApproval.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.cmdSubmmitApproval.UseVisualStyleBackColor = false;
			// this.cmdSubmmitApproval.Click += new System.EventHandler(this.cmdSubmmitApproval_Click);
			// 
			// txtDlblAppTemplateName
			// 
			//this.txtDlblAppTemplateName.AllowDrop = true;
			this.txtDlblAppTemplateName.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			this.txtDlblAppTemplateName.Enabled = false;
			this.txtDlblAppTemplateName.Location = new System.Drawing.Point(225, 18);
			this.txtDlblAppTemplateName.Name = "txtDlblAppTemplateName";
			this.txtDlblAppTemplateName.Size = new System.Drawing.Size(226, 19);
			this.txtDlblAppTemplateName.TabIndex = 65;
			// 
			// txtApprovalTemplate
			// 
			//this.txtApprovalTemplate.AllowDrop = true;
			this.txtApprovalTemplate.BackColor = System.Drawing.Color.FromArgb(239, 239, 239);
			// // = false;
			this.txtApprovalTemplate.Enabled = false;
			this.txtApprovalTemplate.ForeColor = System.Drawing.Color.Black;
			this.txtApprovalTemplate.Location = new System.Drawing.Point(117, 18);
			// // = (System.Windows.Forms.TextBox.DropDownTypes) 0;
			this.txtApprovalTemplate.Name = "txtApprovalTemplate";
			// this.txtApprovalTemplate.ShowButton = true;
			this.txtApprovalTemplate.Size = new System.Drawing.Size(106, 19);
			this.txtApprovalTemplate.TabIndex = 66;
			// this.txtApprovalTemplate.Text = "";
			// this.// = "";
			// 
			// _lblCommonLabel_28
			// 
			//this._lblCommonLabel_28.AllowDrop = true;
			this._lblCommonLabel_28.BackColor = System.Drawing.Color.White;
			this._lblCommonLabel_28.Text = "Approval Template";
			this._lblCommonLabel_28.Location = new System.Drawing.Point(12, 21);
			this._lblCommonLabel_28.Name = "_lblCommonLabel_28";
			this._lblCommonLabel_28.Size = new System.Drawing.Size(90, 14);
			this._lblCommonLabel_28.TabIndex = 67;
			// 
			// Frame1
			// 
			//this.Frame1.AllowDrop = true;
			this.Frame1.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			//this.Frame1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Frame1.Controls.Add(this.frm);
			this.Frame1.Enabled = true;
			this.Frame1.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Frame1.Location = new System.Drawing.Point(3, 22);
			this.Frame1.Name = "Frame1";
			this.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Frame1.Size = new System.Drawing.Size(610, 108);
			this.Frame1.TabIndex = 43;
			this.Frame1.Visible = true;
			// 
			// frm
			// 
			//this.frm.AllowDrop = true;
			this.frm.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			this.frm.Controls.Add(this.txtGrantDays);
			this.frm.Controls.Add(this.Label2);
			this.frm.Controls.Add(this.Label1);
			this.frm.Controls.Add(this.txtDisplayVariationDays);
			this.frm.Controls.Add(this.txtEncashmentDays);
			this.frm.Controls.Add(this.txtAdjustUnpaidDays);
			this.frm.Controls.Add(this.txtAdjustPaidDays);
			this.frm.Controls.Add(this.Label12);
			this.frm.Controls.Add(this._txtCommonTextBox_4);
			this.frm.Controls.Add(this._lblCommonLabel_11);
			this.frm.Controls.Add(this._txtCommonDate_1);
			this.frm.Controls.Add(this._lblCommonLabel_15);
			this.frm.Controls.Add(this._lblCommonLabel_16);
			this.frm.Controls.Add(this.txtLeaveBalOnResume);
			this.frm.Controls.Add(this._lblCommonLabel_22);
			this.frm.Controls.Add(this._lblCommonLabel_23);
			this.frm.Controls.Add(this.txtSalaryAdjusted);
			this.frm.Controls.Add(this._lblCommonLabel_24);
			this.frm.Enabled = true;
			this.frm.ForeColor = System.Drawing.SystemColors.WindowText;
			this.frm.Location = new System.Drawing.Point(0, 0);
			this.frm.Name = "frm";
			this.frm.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.frm.Size = new System.Drawing.Size(609, 107);
			this.frm.TabIndex = 45;
			this.frm.Visible = true;
			// 
			// txtGrantDays
			// 
			//this.txtGrantDays.AllowDrop = true;
			// this.txtGrantDays.DisplayFormat = "####0.000###;;0.000;0.000";
			this.txtGrantDays.ForeColor = System.Drawing.SystemColors.WindowText;
			// this.txtGrantDays.Format = "###########0.000";
			this.txtGrantDays.Location = new System.Drawing.Point(104, 61);
			this.txtGrantDays.Name = "txtGrantDays";
			this.txtGrantDays.Size = new System.Drawing.Size(102, 19);
			this.txtGrantDays.TabIndex = 46;
			this.txtGrantDays.Text = "0.000";
			// this.txtGrantDays.Leave += new System.EventHandler(this.txtGrantDays_Leave);
			// 
			// System.Windows.Forms.Label2
			// 
			//this.Label2.AllowDrop = true;
			this.Label2.BackColor = System.Drawing.Color.FromArgb(237, 231, 235);
			this.Label2.Text = "Encashment Days";
			this.Label2.Location = new System.Drawing.Point(409, 42);
			// this.Label2.mLabelId = 2145;
			this.Label2.Name="Label2";
			this.Label2.Size = new System.Drawing.Size(87, 14);
			this.Label2.TabIndex = 47;
			// 
			// System.Windows.Forms.Label1
			// 
			//this.Label1.AllowDrop = true;
			this.Label1.BackColor = System.Drawing.Color.FromArgb(237, 231, 235);
			this.Label1.Text = "Variation Days";
			this.Label1.Location = new System.Drawing.Point(218, 23);
			this.Label1.Name="Label1";
			this.Label1.Size = new System.Drawing.Size(71, 14);
			this.Label1.TabIndex = 48;
			// 
			// txtDisplayVariationDays
			// 
			// //this.txtDisplayVariationDays.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
			//this.txtDisplayVariationDays.AllowDrop = true;
			this.txtDisplayVariationDays.BackColor = System.Drawing.SystemColors.Window;
			this.txtDisplayVariationDays.Enabled = false;
			this.txtDisplayVariationDays.Location = new System.Drawing.Point(304, 20);
			this.txtDisplayVariationDays.Name = "txtDisplayVariationDays";
			this.txtDisplayVariationDays.Size = new System.Drawing.Size(102, 19);
			this.txtDisplayVariationDays.TabIndex = 49;
			this.txtDisplayVariationDays.TabStop = false;
			this.txtDisplayVariationDays.Text = "0";
			// 
			// txtEncashmentDays
			// 
			//this.txtEncashmentDays.AllowDrop = true;
			// this.txtEncashmentDays.DisplayFormat = "####0.000###;;0.000;0.000";
			this.txtEncashmentDays.ForeColor = System.Drawing.SystemColors.WindowText;
			// this.txtEncashmentDays.Format = "###########0.000";
			this.txtEncashmentDays.Location = new System.Drawing.Point(499, 40);
			this.txtEncashmentDays.Name = "txtEncashmentDays";
			this.txtEncashmentDays.Size = new System.Drawing.Size(101, 19);
			this.txtEncashmentDays.TabIndex = 50;
			this.txtEncashmentDays.Text = "0.000";
			// this.txtEncashmentDays.Leave += new System.EventHandler(this.txtEncashmentDays_Leave);
			// 
			// txtAdjustUnpaidDays
			// 
			//this.txtAdjustUnpaidDays.AllowDrop = true;
			// this.txtAdjustUnpaidDays.DisplayFormat = "####0.000###;;0.000;0.000";
			this.txtAdjustUnpaidDays.ForeColor = System.Drawing.SystemColors.WindowText;
			// this.txtAdjustUnpaidDays.Format = "###########0.000";
			this.txtAdjustUnpaidDays.Location = new System.Drawing.Point(304, 41);
			this.txtAdjustUnpaidDays.Name = "txtAdjustUnpaidDays";
			this.txtAdjustUnpaidDays.Size = new System.Drawing.Size(102, 19);
			this.txtAdjustUnpaidDays.TabIndex = 51;
			this.txtAdjustUnpaidDays.Text = "0.000";
			// this.txtAdjustUnpaidDays.Leave += new System.EventHandler(this.txtAdjustUnpaidDays_Leave);
			// 
			// txtAdjustPaidDays
			// 
			//this.txtAdjustPaidDays.AllowDrop = true;
			// this.txtAdjustPaidDays.DisplayFormat = "####0.000###;;0.000;0.000";
			this.txtAdjustPaidDays.ForeColor = System.Drawing.SystemColors.WindowText;
			// this.txtAdjustPaidDays.Format = "###########0.000";
			this.txtAdjustPaidDays.Location = new System.Drawing.Point(105, 41);
			this.txtAdjustPaidDays.Name = "txtAdjustPaidDays";
			this.txtAdjustPaidDays.Size = new System.Drawing.Size(102, 19);
			this.txtAdjustPaidDays.TabIndex = 52;
			this.txtAdjustPaidDays.Text = "0.000";
			// this.txtAdjustPaidDays.Leave += new System.EventHandler(this.txtAdjustPaidDays_Leave);
			// 
			// System.Windows.Forms.Label12
			// 
			//this.Label12.AllowDrop = true;
			this.Label12.BackColor = System.Drawing.Color.FromArgb(237, 231, 235);
			this.Label12.Text = "Comments";
			this.Label12.Location = new System.Drawing.Point(1, 84);
			// this.Label12.mLabelId = 1851;
			this.Label12.Name="Label12";
			this.Label12.Size = new System.Drawing.Size(50, 14);
			this.Label12.TabIndex = 53;
			// 
			// _txtCommonTextBox_4
			// 
			//this._txtCommonTextBox_4.AllowDrop = true;
			this._txtCommonTextBox_4.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_4.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_4.Location = new System.Drawing.Point(104, 82);
			this._txtCommonTextBox_4.MaxLength = 100;
			this._txtCommonTextBox_4.Name = "_txtCommonTextBox_4";
			this._txtCommonTextBox_4.Size = new System.Drawing.Size(500, 19);
			this._txtCommonTextBox_4.TabIndex = 54;
			this._txtCommonTextBox_4.Text = "";
			// this.// = "";
			// 
			// _lblCommonLabel_11
			// 
			//this._lblCommonLabel_11.AllowDrop = true;
			this._lblCommonLabel_11.BackColor = System.Drawing.Color.FromArgb(237, 231, 235);
			this._lblCommonLabel_11.Text = "Actual Resume Date";
			this._lblCommonLabel_11.Location = new System.Drawing.Point(1, 22);
			// // this._lblCommonLabel_11.mLabelId = 1134;
			this._lblCommonLabel_11.Name = "_lblCommonLabel_11";
			this._lblCommonLabel_11.Size = new System.Drawing.Size(98, 14);
			this._lblCommonLabel_11.TabIndex = 55;
			// 
			// _txtCommonDate_1
			// 
			//this._txtCommonDate_1.AllowDrop = true;
			// this._txtCommonDate_1.CheckDateRange = false;
			this._txtCommonDate_1.Enabled = false;
			this._txtCommonDate_1.Location = new System.Drawing.Point(104, 20);
			// this._txtCommonDate_1.MaxDate = 2958465;
			// this._txtCommonDate_1.MinDate = 32874;
			this._txtCommonDate_1.Name = "_txtCommonDate_1";
			this._txtCommonDate_1.Size = new System.Drawing.Size(102, 19);
			this._txtCommonDate_1.TabIndex = 56;
			this._txtCommonDate_1.Text = "18/07/2001";
			// this._txtCommonDate_1.Value = 37090;
			// this._txtCommonDate_1.Leave += new System.EventHandler(this.txtCommonDate_Leave);
			// 
			// _lblCommonLabel_15
			// 
			//this._lblCommonLabel_15.AllowDrop = true;
			this._lblCommonLabel_15.BackColor = System.Drawing.Color.FromArgb(237, 231, 235);
			this._lblCommonLabel_15.Text = "Paid Days";
			this._lblCommonLabel_15.Location = new System.Drawing.Point(1, 43);
			// // this._lblCommonLabel_15.mLabelId = 1925;
			this._lblCommonLabel_15.Name = "_lblCommonLabel_15";
			this._lblCommonLabel_15.Size = new System.Drawing.Size(48, 14);
			this._lblCommonLabel_15.TabIndex = 57;
			// 
			// _lblCommonLabel_16
			// 
			//this._lblCommonLabel_16.AllowDrop = true;
			this._lblCommonLabel_16.BackColor = System.Drawing.Color.FromArgb(237, 231, 235);
			this._lblCommonLabel_16.Text = "Unpaid Days";
			this._lblCommonLabel_16.Location = new System.Drawing.Point(218, 43);
			// // this._lblCommonLabel_16.mLabelId = 1922;
			this._lblCommonLabel_16.Name = "_lblCommonLabel_16";
			this._lblCommonLabel_16.Size = new System.Drawing.Size(61, 14);
			this._lblCommonLabel_16.TabIndex = 58;
			// 
			// txtLeaveBalOnResume
			// 
			//this.txtLeaveBalOnResume.AllowDrop = true;
			this.txtLeaveBalOnResume.BackColor = System.Drawing.Color.FromArgb(239, 239, 239);
			// this.txtLeaveBalOnResume.DisplayFormat = "####0.000###;;0.000;0.000";
			this.txtLeaveBalOnResume.Enabled = false;
			this.txtLeaveBalOnResume.ForeColor = System.Drawing.SystemColors.WindowText;
			// this.txtLeaveBalOnResume.Format = "###########0.000";
			this.txtLeaveBalOnResume.Location = new System.Drawing.Point(499, 20);
			this.txtLeaveBalOnResume.Name = "txtLeaveBalOnResume";
			this.txtLeaveBalOnResume.Size = new System.Drawing.Size(102, 19);
			this.txtLeaveBalOnResume.TabIndex = 59;
			this.txtLeaveBalOnResume.TabStop = false;
			this.txtLeaveBalOnResume.Text = "0.000";
			// 
			// _lblCommonLabel_22
			// 
			//this._lblCommonLabel_22.AllowDrop = true;
			this._lblCommonLabel_22.BackColor = System.Drawing.Color.FromArgb(237, 231, 235);
			this._lblCommonLabel_22.Text = "Leave Balance";
			this._lblCommonLabel_22.Location = new System.Drawing.Point(409, 22);
			// // this._lblCommonLabel_22.mLabelId = 1133;
			this._lblCommonLabel_22.Name = "_lblCommonLabel_22";
			this._lblCommonLabel_22.Size = new System.Drawing.Size(72, 14);
			this._lblCommonLabel_22.TabIndex = 60;
			// 
			// _lblCommonLabel_23
			// 
			//this._lblCommonLabel_23.AllowDrop = true;
			this._lblCommonLabel_23.BackColor = System.Drawing.Color.FromArgb(237, 231, 235);
			this._lblCommonLabel_23.Text = "Leave Amount";
			this._lblCommonLabel_23.Location = new System.Drawing.Point(218, 63);
			// // this._lblCommonLabel_23.mLabelId = 2081;
			this._lblCommonLabel_23.Name = "_lblCommonLabel_23";
			this._lblCommonLabel_23.Size = new System.Drawing.Size(70, 14);
			this._lblCommonLabel_23.TabIndex = 61;
			// 
			// txtSalaryAdjusted
			// 
			//this.txtSalaryAdjusted.AllowDrop = true;
			this.txtSalaryAdjusted.BackColor = System.Drawing.Color.FromArgb(239, 239, 239);
			// this.txtSalaryAdjusted.DisplayFormat = "####0.000###;;0.000;0.000";
			this.txtSalaryAdjusted.Enabled = false;
			this.txtSalaryAdjusted.ForeColor = System.Drawing.SystemColors.WindowText;
			// this.txtSalaryAdjusted.Format = "###########0.000";
			this.txtSalaryAdjusted.Location = new System.Drawing.Point(304, 61);
			this.txtSalaryAdjusted.Name = "txtSalaryAdjusted";
			this.txtSalaryAdjusted.Size = new System.Drawing.Size(102, 19);
			this.txtSalaryAdjusted.TabIndex = 62;
			this.txtSalaryAdjusted.TabStop = false;
			this.txtSalaryAdjusted.Text = "0.000";
			// 
			// _lblCommonLabel_24
			// 
			//this._lblCommonLabel_24.AllowDrop = true;
			this._lblCommonLabel_24.BackColor = System.Drawing.Color.FromArgb(237, 231, 235);
			this._lblCommonLabel_24.Text = "Grant Days";
			this._lblCommonLabel_24.Location = new System.Drawing.Point(1, 64);
			this._lblCommonLabel_24.Name = "_lblCommonLabel_24";
			this._lblCommonLabel_24.Size = new System.Drawing.Size(55, 14);
			this._lblCommonLabel_24.TabIndex = 63;
			// 
			// _txtCommonTextBox_2
			// 
			//this._txtCommonTextBox_2.AllowDrop = true;
			this._txtCommonTextBox_2.BackColor = System.Drawing.Color.FromArgb(239, 239, 239);
			this._txtCommonTextBox_2.Enabled = false;
			this._txtCommonTextBox_2.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_2.Location = new System.Drawing.Point(104, 71);
			this._txtCommonTextBox_2.MaxLength = 20;
			this._txtCommonTextBox_2.Name = "_txtCommonTextBox_2";
			this._txtCommonTextBox_2.Size = new System.Drawing.Size(102, 19);
			this._txtCommonTextBox_2.TabIndex = 1;
			this._txtCommonTextBox_2.TabStop = false;
			this._txtCommonTextBox_2.Text = "";
			// this.// = "";
			// 
			// _lblCommonLabel_7
			// 
			//this._lblCommonLabel_7.AllowDrop = true;
			this._lblCommonLabel_7.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_7.Text = "Reference No.";
			this._lblCommonLabel_7.Location = new System.Drawing.Point(6, 74);
			// // this._lblCommonLabel_7.mLabelId = 1964;
			this._lblCommonLabel_7.Name = "_lblCommonLabel_7";
			this._lblCommonLabel_7.Size = new System.Drawing.Size(70, 13);
			this._lblCommonLabel_7.TabIndex = 2;
			// 
			// _lblCommonLabel_5
			// 
			//this._lblCommonLabel_5.AllowDrop = true;
			this._lblCommonLabel_5.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_5.Text = "Transaction No.";
			this._lblCommonLabel_5.Location = new System.Drawing.Point(6, 52);
			// // this._lblCommonLabel_5.mLabelId = 1744;
			this._lblCommonLabel_5.Name = "_lblCommonLabel_5";
			this._lblCommonLabel_5.Size = new System.Drawing.Size(76, 14);
			this._lblCommonLabel_5.TabIndex = 3;
			// 
			// _lblCommonLabel_6
			// 
			//this._lblCommonLabel_6.AllowDrop = true;
			this._lblCommonLabel_6.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_6.Text = "Transaction Date";
			this._lblCommonLabel_6.Location = new System.Drawing.Point(416, 53);
			// // this._lblCommonLabel_6.mLabelId = 1233;
			this._lblCommonLabel_6.Name = "_lblCommonLabel_6";
			this._lblCommonLabel_6.Size = new System.Drawing.Size(82, 14);
			this._lblCommonLabel_6.TabIndex = 4;
			// 
			// _txtCommonTextBox_0
			// 
			//this._txtCommonTextBox_0.AllowDrop = true;
			this._txtCommonTextBox_0.BackColor = System.Drawing.Color.FromArgb(239, 239, 239);
			// this._txtCommonTextBox_0.bolNumericOnly = true;
			this._txtCommonTextBox_0.Enabled = false;
			this._txtCommonTextBox_0.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_0.Location = new System.Drawing.Point(104, 50);
			// // = System.Windows.Forms.TextBox.DropDownTypes.ddtNextNumber;
			this._txtCommonTextBox_0.Name = "_txtCommonTextBox_0";
			// this._txtCommonTextBox_0.ShowButton = true;
			this._txtCommonTextBox_0.Size = new System.Drawing.Size(102, 19);
			this._txtCommonTextBox_0.TabIndex = 5;
			this._txtCommonTextBox_0.TabStop = false;
			this._txtCommonTextBox_0.Text = "";
			// this.// = "";
			// 
			// _lblCommonLabel_2
			// 
			//this._lblCommonLabel_2.AllowDrop = true;
			this._lblCommonLabel_2.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_2.Text = "Employee Code";
			this._lblCommonLabel_2.Location = new System.Drawing.Point(6, 106);
			// // this._lblCommonLabel_2.mLabelId = 236;
			this._lblCommonLabel_2.Name = "_lblCommonLabel_2";
			this._lblCommonLabel_2.Size = new System.Drawing.Size(74, 14);
			this._lblCommonLabel_2.TabIndex = 6;
			// 
			// _lblCommonLabel_0
			// 
			//this._lblCommonLabel_0.AllowDrop = true;
			this._lblCommonLabel_0.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_0.Text = "Department Code";
			this._lblCommonLabel_0.Location = new System.Drawing.Point(6, 127);
			// // this._lblCommonLabel_0.mLabelId = 1973;
			this._lblCommonLabel_0.Name = "_lblCommonLabel_0";
			this._lblCommonLabel_0.Size = new System.Drawing.Size(83, 14);
			this._lblCommonLabel_0.TabIndex = 7;
			// 
			// _lblCommonLabel_1
			// 
			//this._lblCommonLabel_1.AllowDrop = true;
			this._lblCommonLabel_1.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_1.Text = "Designation Code";
			this._lblCommonLabel_1.Location = new System.Drawing.Point(6, 148);
			// // this._lblCommonLabel_1.mLabelId = 1049;
			this._lblCommonLabel_1.Name = "_lblCommonLabel_1";
			this._lblCommonLabel_1.Size = new System.Drawing.Size(84, 14);
			this._lblCommonLabel_1.TabIndex = 8;
			// 
			// _lblCommonLabel_3
			// 
			//this._lblCommonLabel_3.AllowDrop = true;
			this._lblCommonLabel_3.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_3.Text = "Basic Salary";
			this._lblCommonLabel_3.Location = new System.Drawing.Point(416, 127);
			// // this._lblCommonLabel_3.mLabelId = 1970;
			this._lblCommonLabel_3.Name = "_lblCommonLabel_3";
			this._lblCommonLabel_3.Size = new System.Drawing.Size(61, 14);
			this._lblCommonLabel_3.TabIndex = 9;
			// 
			// _txtCommonNumber_0
			// 
			//this._txtCommonNumber_0.AllowDrop = true;
			this._txtCommonNumber_0.BackColor = System.Drawing.Color.FromArgb(239, 239, 239);
			// this._txtCommonNumber_0.DisplayFormat = "####0.000###;;0.000;0.000";
			this._txtCommonNumber_0.Enabled = false;
			// this._txtCommonNumber_0.Format = "###########0.000";
			this._txtCommonNumber_0.Location = new System.Drawing.Point(104, 223);
			// // = 2147483647;
			// // = 0;
			this._txtCommonNumber_0.Name = "_txtCommonNumber_0";
			this._txtCommonNumber_0.Size = new System.Drawing.Size(101, 19);
			this._txtCommonNumber_0.TabIndex = 10;
			this._txtCommonNumber_0.TabStop = false;
			this._txtCommonNumber_0.Text = "0.000";
			// 
			// _lblCommonLabel_10
			// 
			//this._lblCommonLabel_10.AllowDrop = true;
			this._lblCommonLabel_10.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_10.Text = "Leave Days";
			this._lblCommonLabel_10.Location = new System.Drawing.Point(6, 225);
			// // this._lblCommonLabel_10.mLabelId = 1986;
			this._lblCommonLabel_10.Name = "_lblCommonLabel_10";
			this._lblCommonLabel_10.Size = new System.Drawing.Size(58, 14);
			this._lblCommonLabel_10.TabIndex = 11;
			// 
			// _txtCommonNumber_1
			// 
			//this._txtCommonNumber_1.AllowDrop = true;
			this._txtCommonNumber_1.BackColor = System.Drawing.Color.FromArgb(239, 239, 239);
			// this._txtCommonNumber_1.DisplayFormat = "####0.000###;;0.000;0.000";
			this._txtCommonNumber_1.Enabled = false;
			// this._txtCommonNumber_1.Format = "###########0.000";
			this._txtCommonNumber_1.Location = new System.Drawing.Point(104, 244);
			// // = 2147483647;
			// // = 0;
			this._txtCommonNumber_1.Name = "_txtCommonNumber_1";
			this._txtCommonNumber_1.Size = new System.Drawing.Size(101, 19);
			this._txtCommonNumber_1.TabIndex = 12;
			this._txtCommonNumber_1.TabStop = false;
			this._txtCommonNumber_1.Text = "0.000";
			// 
			// _lblCommonLabel_4
			// 
			//this._lblCommonLabel_4.AllowDrop = true;
			this._lblCommonLabel_4.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_4.Text = "Actual Leave Days";
			this._lblCommonLabel_4.Location = new System.Drawing.Point(6, 245);
			// // this._lblCommonLabel_4.mLabelId = 1131;
			this._lblCommonLabel_4.Name = "_lblCommonLabel_4";
			this._lblCommonLabel_4.Size = new System.Drawing.Size(92, 14);
			this._lblCommonLabel_4.TabIndex = 13;
			// 
			// _lblCommonLabel_17
			// 
			//this._lblCommonLabel_17.AllowDrop = true;
			this._lblCommonLabel_17.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_17.Text = "Leave Balance";
			this._lblCommonLabel_17.Location = new System.Drawing.Point(416, 205);
			// // this._lblCommonLabel_17.mLabelId = 1133;
			this._lblCommonLabel_17.Name = "_lblCommonLabel_17";
			this._lblCommonLabel_17.Size = new System.Drawing.Size(72, 14);
			this._lblCommonLabel_17.TabIndex = 14;
			// 
			// _txtCommonTextBox_3
			// 
			//this._txtCommonTextBox_3.AllowDrop = true;
			this._txtCommonTextBox_3.BackColor = System.Drawing.Color.FromArgb(239, 239, 239);
			// this._txtCommonTextBox_3.bolNumericOnly = true;
			this._txtCommonTextBox_3.Enabled = false;
			this._txtCommonTextBox_3.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_3.Location = new System.Drawing.Point(104, 182);
			this._txtCommonTextBox_3.MaxLength = 4;
			this._txtCommonTextBox_3.Name = "_txtCommonTextBox_3";
			// this._txtCommonTextBox_3.ShowButton = true;
			this._txtCommonTextBox_3.Size = new System.Drawing.Size(101, 19);
			this._txtCommonTextBox_3.TabIndex = 15;
			this._txtCommonTextBox_3.TabStop = false;
			this._txtCommonTextBox_3.Text = "";
			// this.// = "";
			// 
			// _lblCommonLabel_18
			// 
			//this._lblCommonLabel_18.AllowDrop = true;
			this._lblCommonLabel_18.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_18.Text = "Leave Code";
			this._lblCommonLabel_18.Location = new System.Drawing.Point(6, 184);
			// // this._lblCommonLabel_18.mLabelId = 1124;
			this._lblCommonLabel_18.Name = "_lblCommonLabel_18";
			this._lblCommonLabel_18.Size = new System.Drawing.Size(58, 14);
			this._lblCommonLabel_18.TabIndex = 16;
			// 
			// _lblCommonLabel_19
			// 
			//this._lblCommonLabel_19.AllowDrop = true;
			this._lblCommonLabel_19.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_19.Text = "Leave To";
			this._lblCommonLabel_19.Location = new System.Drawing.Point(209, 204);
			// // this._lblCommonLabel_19.mLabelId = 375;
			this._lblCommonLabel_19.Name = "_lblCommonLabel_19";
			this._lblCommonLabel_19.Size = new System.Drawing.Size(45, 14);
			this._lblCommonLabel_19.TabIndex = 17;
			// 
			// _lblCommonLabel_20
			// 
			//this._lblCommonLabel_20.AllowDrop = true;
			this._lblCommonLabel_20.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_20.Text = "Leave From";
			this._lblCommonLabel_20.Location = new System.Drawing.Point(6, 204);
			// // this._lblCommonLabel_20.mLabelId = 371;
			this._lblCommonLabel_20.Name = "_lblCommonLabel_20";
			this._lblCommonLabel_20.Size = new System.Drawing.Size(57, 14);
			this._lblCommonLabel_20.TabIndex = 18;
			// 
			// _txtCommonNumber_2
			// 
			//this._txtCommonNumber_2.AllowDrop = true;
			this._txtCommonNumber_2.BackColor = System.Drawing.Color.FromArgb(239, 239, 239);
			// this._txtCommonNumber_2.DisplayFormat = "####0.000###;;0.000;0.000";
			this._txtCommonNumber_2.Enabled = false;
			// this._txtCommonNumber_2.Format = "###########0.000";
			this._txtCommonNumber_2.Location = new System.Drawing.Point(306, 223);
			// // = 2147483647;
			// // = 0;
			this._txtCommonNumber_2.Name = "_txtCommonNumber_2";
			this._txtCommonNumber_2.Size = new System.Drawing.Size(101, 19);
			this._txtCommonNumber_2.TabIndex = 19;
			this._txtCommonNumber_2.TabStop = false;
			this._txtCommonNumber_2.Text = "0.000";
			// 
			// _lblCommonLabel_8
			// 
			//this._lblCommonLabel_8.AllowDrop = true;
			this._lblCommonLabel_8.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_8.Text = "Paid Days";
			this._lblCommonLabel_8.Location = new System.Drawing.Point(209, 225);
			// // this._lblCommonLabel_8.mLabelId = 1925;
			this._lblCommonLabel_8.Name = "_lblCommonLabel_8";
			this._lblCommonLabel_8.Size = new System.Drawing.Size(48, 14);
			this._lblCommonLabel_8.TabIndex = 20;
			// 
			// _txtCommonNumber_3
			// 
			//this._txtCommonNumber_3.AllowDrop = true;
			this._txtCommonNumber_3.BackColor = System.Drawing.Color.FromArgb(239, 239, 239);
			// this._txtCommonNumber_3.DisplayFormat = "####0.000###;;0.000;0.000";
			this._txtCommonNumber_3.Enabled = false;
			// this._txtCommonNumber_3.Format = "###########0.000";
			this._txtCommonNumber_3.Location = new System.Drawing.Point(519, 223);
			// // = 2147483647;
			// // = 0;
			this._txtCommonNumber_3.Name = "_txtCommonNumber_3";
			this._txtCommonNumber_3.Size = new System.Drawing.Size(101, 19);
			this._txtCommonNumber_3.TabIndex = 21;
			this._txtCommonNumber_3.TabStop = false;
			this._txtCommonNumber_3.Text = "0.000";
			// 
			// _lblCommonLabel_21
			// 
			//this._lblCommonLabel_21.AllowDrop = true;
			this._lblCommonLabel_21.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_21.Text = "Unpaid Days";
			this._lblCommonLabel_21.Location = new System.Drawing.Point(416, 226);
			// // this._lblCommonLabel_21.mLabelId = 1922;
			this._lblCommonLabel_21.Name = "_lblCommonLabel_21";
			this._lblCommonLabel_21.Size = new System.Drawing.Size(61, 14);
			this._lblCommonLabel_21.TabIndex = 22;
			// 
			// _txtCommonTextBox_1
			// 
			//this._txtCommonTextBox_1.AllowDrop = true;
			this._txtCommonTextBox_1.BackColor = System.Drawing.Color.FromArgb(239, 239, 239);
			this._txtCommonTextBox_1.Enabled = false;
			this._txtCommonTextBox_1.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_1.Location = new System.Drawing.Point(104, 104);
			this._txtCommonTextBox_1.MaxLength = 10;
			this._txtCommonTextBox_1.Name = "_txtCommonTextBox_1";
			// this._txtCommonTextBox_1.ShowButton = true;
			this._txtCommonTextBox_1.Size = new System.Drawing.Size(101, 19);
			this._txtCommonTextBox_1.TabIndex = 23;
			this._txtCommonTextBox_1.TabStop = false;
			this._txtCommonTextBox_1.Text = "";
			// this.// = "";
			// 
			// _lblCommonLabel_9
			// 
			//this._lblCommonLabel_9.AllowDrop = true;
			this._lblCommonLabel_9.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_9.Text = "Total Salary";
			this._lblCommonLabel_9.Location = new System.Drawing.Point(416, 148);
			// // this._lblCommonLabel_9.mLabelId = 818;
			this._lblCommonLabel_9.Name = "_lblCommonLabel_9";
			this._lblCommonLabel_9.Size = new System.Drawing.Size(57, 14);
			this._lblCommonLabel_9.TabIndex = 24;
			// 
			// _lblCommonLabel_12
			// 
			//this._lblCommonLabel_12.AllowDrop = true;
			this._lblCommonLabel_12.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_12.Text = "Resume Date";
			this._lblCommonLabel_12.Location = new System.Drawing.Point(416, 247);
			// // this._lblCommonLabel_12.mLabelId = 1132;
			this._lblCommonLabel_12.Name = "_lblCommonLabel_12";
			this._lblCommonLabel_12.Size = new System.Drawing.Size(64, 14);
			this._lblCommonLabel_12.TabIndex = 25;
			// 
			// _txtCommonDate_0
			// 
			//this._txtCommonDate_0.AllowDrop = true;
			this._txtCommonDate_0.BackColor = System.Drawing.Color.FromArgb(239, 239, 239);
			// this._txtCommonDate_0.CheckDateRange = false;
			this._txtCommonDate_0.Enabled = false;
			this._txtCommonDate_0.Location = new System.Drawing.Point(519, 244);
			// this._txtCommonDate_0.MaxDate = 2958465;
			// this._txtCommonDate_0.MinDate = 32874;
			this._txtCommonDate_0.Name = "_txtCommonDate_0";
			this._txtCommonDate_0.Size = new System.Drawing.Size(102, 19);
			this._txtCommonDate_0.TabIndex = 0;
			this._txtCommonDate_0.TabStop = false;
			this._txtCommonDate_0.Text = "18/07/2001";
			// this._txtCommonDate_0.Value = 37090;
			// this._txtCommonDate_0.Leave += new System.EventHandler(this.txtCommonDate_Leave);
			// 
			// _lblCommonLabel_13
			// 
			//this._lblCommonLabel_13.AllowDrop = true;
			this._lblCommonLabel_13.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_13.Text = "Status";
			this._lblCommonLabel_13.Location = new System.Drawing.Point(416, 72);
			// // this._lblCommonLabel_13.mLabelId = 1834;
			this._lblCommonLabel_13.Name = "_lblCommonLabel_13";
			this._lblCommonLabel_13.Size = new System.Drawing.Size(31, 14);
			this._lblCommonLabel_13.TabIndex = 26;
			// 
			// _txtDisplayLabel_12
			// 
			//this._txtDisplayLabel_12.AllowDrop = true;
			this._txtDisplayLabel_12.Enabled = false;
			this._txtDisplayLabel_12.Location = new System.Drawing.Point(519, 70);
			this._txtDisplayLabel_12.Name = "_txtDisplayLabel_12";
			this._txtDisplayLabel_12.Size = new System.Drawing.Size(101, 19);
			this._txtDisplayLabel_12.TabIndex = 27;
			this._txtDisplayLabel_12.TabStop = false;
			// 
			// _txtDisplayLabel_11
			// 
			// //this._txtDisplayLabel_11.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
			//this._txtDisplayLabel_11.AllowDrop = true;
			this._txtDisplayLabel_11.Enabled = false;
			this._txtDisplayLabel_11.Location = new System.Drawing.Point(306, 202);
			this._txtDisplayLabel_11.Name = "_txtDisplayLabel_11";
			this._txtDisplayLabel_11.Size = new System.Drawing.Size(101, 19);
			this._txtDisplayLabel_11.TabIndex = 28;
			this._txtDisplayLabel_11.TabStop = false;
			// 
			// _txtDisplayLabel_10
			// 
			// //this._txtDisplayLabel_10.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
			//this._txtDisplayLabel_10.AllowDrop = true;
			this._txtDisplayLabel_10.Enabled = false;
			this._txtDisplayLabel_10.Location = new System.Drawing.Point(104, 202);
			this._txtDisplayLabel_10.Name = "_txtDisplayLabel_10";
			this._txtDisplayLabel_10.Size = new System.Drawing.Size(101, 19);
			this._txtDisplayLabel_10.TabIndex = 29;
			this._txtDisplayLabel_10.TabStop = false;
			// 
			// _txtDisplayLabel_8
			// 
			// //this._txtDisplayLabel_8.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
			//this._txtDisplayLabel_8.AllowDrop = true;
			this._txtDisplayLabel_8.Enabled = false;
			this._txtDisplayLabel_8.Location = new System.Drawing.Point(519, 50);
			this._txtDisplayLabel_8.Name = "_txtDisplayLabel_8";
			this._txtDisplayLabel_8.Size = new System.Drawing.Size(101, 19);
			this._txtDisplayLabel_8.TabIndex = 30;
			this._txtDisplayLabel_8.TabStop = false;
			// 
			// _txtDisplayLabel_0
			// 
			//this._txtDisplayLabel_0.AllowDrop = true;
			this._txtDisplayLabel_0.Enabled = false;
			this._txtDisplayLabel_0.Location = new System.Drawing.Point(104, 125);
			this._txtDisplayLabel_0.Name = "_txtDisplayLabel_0";
			this._txtDisplayLabel_0.Size = new System.Drawing.Size(101, 19);
			this._txtDisplayLabel_0.TabIndex = 31;
			this._txtDisplayLabel_0.TabStop = false;
			// 
			// _txtDisplayLabel_1
			// 
			//this._txtDisplayLabel_1.AllowDrop = true;
			this._txtDisplayLabel_1.Enabled = false;
			this._txtDisplayLabel_1.Location = new System.Drawing.Point(207, 125);
			this._txtDisplayLabel_1.Name = "_txtDisplayLabel_1";
			this._txtDisplayLabel_1.Size = new System.Drawing.Size(201, 19);
			this._txtDisplayLabel_1.TabIndex = 32;
			this._txtDisplayLabel_1.TabStop = false;
			// 
			// _txtDisplayLabel_2
			// 
			//this._txtDisplayLabel_2.AllowDrop = true;
			this._txtDisplayLabel_2.Enabled = false;
			this._txtDisplayLabel_2.Location = new System.Drawing.Point(104, 146);
			this._txtDisplayLabel_2.Name = "_txtDisplayLabel_2";
			this._txtDisplayLabel_2.Size = new System.Drawing.Size(101, 19);
			this._txtDisplayLabel_2.TabIndex = 33;
			this._txtDisplayLabel_2.TabStop = false;
			// 
			// _txtDisplayLabel_3
			// 
			//this._txtDisplayLabel_3.AllowDrop = true;
			this._txtDisplayLabel_3.Enabled = false;
			this._txtDisplayLabel_3.Location = new System.Drawing.Point(207, 146);
			this._txtDisplayLabel_3.Name = "_txtDisplayLabel_3";
			this._txtDisplayLabel_3.Size = new System.Drawing.Size(201, 19);
			this._txtDisplayLabel_3.TabIndex = 34;
			this._txtDisplayLabel_3.TabStop = false;
			// 
			// _txtDisplayLabel_4
			// 
			// //this._txtDisplayLabel_4.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
			//this._txtDisplayLabel_4.AllowDrop = true;
			this._txtDisplayLabel_4.Enabled = false;
			this._txtDisplayLabel_4.Location = new System.Drawing.Point(519, 125);
			this._txtDisplayLabel_4.Name = "_txtDisplayLabel_4";
			this._txtDisplayLabel_4.Size = new System.Drawing.Size(101, 19);
			this._txtDisplayLabel_4.TabIndex = 35;
			this._txtDisplayLabel_4.TabStop = false;
			// 
			// _txtDisplayLabel_7
			// 
			// //this._txtDisplayLabel_7.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
			//this._txtDisplayLabel_7.AllowDrop = true;
			this._txtDisplayLabel_7.Enabled = false;
			this._txtDisplayLabel_7.Location = new System.Drawing.Point(519, 202);
			this._txtDisplayLabel_7.Name = "_txtDisplayLabel_7";
			this._txtDisplayLabel_7.Size = new System.Drawing.Size(101, 19);
			this._txtDisplayLabel_7.TabIndex = 36;
			this._txtDisplayLabel_7.TabStop = false;
			// 
			// _txtDisplayLabel_6
			// 
			//this._txtDisplayLabel_6.AllowDrop = true;
			this._txtDisplayLabel_6.Enabled = false;
			this._txtDisplayLabel_6.Location = new System.Drawing.Point(207, 182);
			this._txtDisplayLabel_6.Name = "_txtDisplayLabel_6";
			this._txtDisplayLabel_6.Size = new System.Drawing.Size(201, 19);
			this._txtDisplayLabel_6.TabIndex = 37;
			this._txtDisplayLabel_6.TabStop = false;
			// 
			// _txtDisplayLabel_5
			// 
			//this._txtDisplayLabel_5.AllowDrop = true;
			this._txtDisplayLabel_5.Enabled = false;
			this._txtDisplayLabel_5.Location = new System.Drawing.Point(207, 104);
			this._txtDisplayLabel_5.Name = "_txtDisplayLabel_5";
			this._txtDisplayLabel_5.Size = new System.Drawing.Size(413, 19);
			this._txtDisplayLabel_5.TabIndex = 38;
			this._txtDisplayLabel_5.TabStop = false;
			// 
			// _txtDisplayLabel_9
			// 
			// //this._txtDisplayLabel_9.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
			//this._txtDisplayLabel_9.AllowDrop = true;
			this._txtDisplayLabel_9.Enabled = false;
			this._txtDisplayLabel_9.Location = new System.Drawing.Point(519, 146);
			this._txtDisplayLabel_9.Name = "_txtDisplayLabel_9";
			this._txtDisplayLabel_9.Size = new System.Drawing.Size(101, 19);
			this._txtDisplayLabel_9.TabIndex = 39;
			this._txtDisplayLabel_9.TabStop = false;
			// 
			// _lblCommonLabel_14
			// 
			//this._lblCommonLabel_14.AllowDrop = true;
			this._lblCommonLabel_14.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_14.Text = "Paid Hours";
			this._lblCommonLabel_14.Location = new System.Drawing.Point(209, 246);
			// // this._lblCommonLabel_14.mLabelId = 2124;
			this._lblCommonLabel_14.Name = "_lblCommonLabel_14";
			this._lblCommonLabel_14.Size = new System.Drawing.Size(52, 14);
			this._lblCommonLabel_14.TabIndex = 40;
			// 
			// _txtCommonNumber_4
			// 
			//this._txtCommonNumber_4.AllowDrop = true;
			this._txtCommonNumber_4.BackColor = System.Drawing.Color.FromArgb(239, 239, 239);
			// this._txtCommonNumber_4.DisplayFormat = "####0.000###;;0.000;0.000";
			this._txtCommonNumber_4.Enabled = false;
			// this._txtCommonNumber_4.Format = "###########0.000";
			this._txtCommonNumber_4.Location = new System.Drawing.Point(306, 244);
			// // = 2147483647;
			// // = 0;
			this._txtCommonNumber_4.Name = "_txtCommonNumber_4";
			this._txtCommonNumber_4.Size = new System.Drawing.Size(101, 19);
			this._txtCommonNumber_4.TabIndex = 41;
			this._txtCommonNumber_4.TabStop = false;
			this._txtCommonNumber_4.Text = "0.000";
			// 
			// txtJoiningDate
			// 
			//this.txtJoiningDate.AllowDrop = true;
			this.txtJoiningDate.BackColor = System.Drawing.Color.FromArgb(239, 239, 239);
			// this.txtJoiningDate.CheckDateRange = false;
			this.txtJoiningDate.Enabled = false;
			this.txtJoiningDate.Location = new System.Drawing.Point(518, 180);
			// this.txtJoiningDate.MaxDate = 2958465;
			// this.txtJoiningDate.MinDate = 2;
			this.txtJoiningDate.Name = "txtJoiningDate";
			this.txtJoiningDate.Size = new System.Drawing.Size(102, 19);
			this.txtJoiningDate.TabIndex = 68;
			// this.txtJoiningDate.Text = "18/07/2001";
			// this.txtJoiningDate.Value = 37090;
			// 
			// _lblCommonLabel_29
			// 
			//this._lblCommonLabel_29.AllowDrop = true;
			this._lblCommonLabel_29.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_29.Text = "Joining Date";
			this._lblCommonLabel_29.Location = new System.Drawing.Point(416, 183);
			this._lblCommonLabel_29.Name = "_lblCommonLabel_29";
			this._lblCommonLabel_29.Size = new System.Drawing.Size(58, 14);
			this._lblCommonLabel_29.TabIndex = 69;
			// 
			// frmPayLeaveResume
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.ClientSize = new System.Drawing.Size(624, 406);
			this.Controls.Add(this.tabResume);
			this.Controls.Add(this._txtCommonTextBox_2);
			this.Controls.Add(this._lblCommonLabel_7);
			this.Controls.Add(this._lblCommonLabel_5);
			this.Controls.Add(this._lblCommonLabel_6);
			this.Controls.Add(this._txtCommonTextBox_0);
			this.Controls.Add(this._lblCommonLabel_2);
			this.Controls.Add(this._lblCommonLabel_0);
			this.Controls.Add(this._lblCommonLabel_1);
			this.Controls.Add(this._lblCommonLabel_3);
			this.Controls.Add(this._txtCommonNumber_0);
			this.Controls.Add(this._lblCommonLabel_10);
			this.Controls.Add(this._txtCommonNumber_1);
			this.Controls.Add(this._lblCommonLabel_4);
			this.Controls.Add(this._lblCommonLabel_17);
			this.Controls.Add(this._txtCommonTextBox_3);
			this.Controls.Add(this._lblCommonLabel_18);
			this.Controls.Add(this._lblCommonLabel_19);
			this.Controls.Add(this._lblCommonLabel_20);
			this.Controls.Add(this._txtCommonNumber_2);
			this.Controls.Add(this._lblCommonLabel_8);
			this.Controls.Add(this._txtCommonNumber_3);
			this.Controls.Add(this._lblCommonLabel_21);
			this.Controls.Add(this._txtCommonTextBox_1);
			this.Controls.Add(this._lblCommonLabel_9);
			this.Controls.Add(this._lblCommonLabel_12);
			this.Controls.Add(this._txtCommonDate_0);
			this.Controls.Add(this._lblCommonLabel_13);
			this.Controls.Add(this._txtDisplayLabel_12);
			this.Controls.Add(this._txtDisplayLabel_11);
			this.Controls.Add(this._txtDisplayLabel_10);
			this.Controls.Add(this._txtDisplayLabel_8);
			this.Controls.Add(this._txtDisplayLabel_0);
			this.Controls.Add(this._txtDisplayLabel_1);
			this.Controls.Add(this._txtDisplayLabel_2);
			this.Controls.Add(this._txtDisplayLabel_3);
			this.Controls.Add(this._txtDisplayLabel_4);
			this.Controls.Add(this._txtDisplayLabel_7);
			this.Controls.Add(this._txtDisplayLabel_6);
			this.Controls.Add(this._txtDisplayLabel_5);
			this.Controls.Add(this._txtDisplayLabel_9);
			this.Controls.Add(this._lblCommonLabel_14);
			this.Controls.Add(this._txtCommonNumber_4);
			this.Controls.Add(this.txtJoiningDate);
			this.Controls.Add(this._lblCommonLabel_29);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			//this.Icon = (System.Drawing.Icon) resources.GetObject("frmPayLeaveResume.Icon");
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(248, 161);
			this.MaximizeBox = true;
			this.MinimizeBox = true;
			this.Name = "frmPayLeaveResume";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Employee Resume";
			// this.Activated += new System.EventHandler(this.frmPayLeaveResume_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
			// this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
			//((System.ComponentModel.ISupportInitialize) this.tabResume).EndInit();
			this.tabResume.ResumeLayout(false);
			this.Frame2.ResumeLayout(false);
			this.Frame1.ResumeLayout(false);
			this.frm.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		// 
		void InitializetxtDisplayLabel()
		{
			this.txtDisplayLabel = new System.Windows.Forms.Label[13];
			this.txtDisplayLabel[12] = _txtDisplayLabel_12;
			this.txtDisplayLabel[11] = _txtDisplayLabel_11;
			this.txtDisplayLabel[10] = _txtDisplayLabel_10;
			this.txtDisplayLabel[8] = _txtDisplayLabel_8;
			this.txtDisplayLabel[0] = _txtDisplayLabel_0;
			this.txtDisplayLabel[1] = _txtDisplayLabel_1;
			this.txtDisplayLabel[2] = _txtDisplayLabel_2;
			this.txtDisplayLabel[3] = _txtDisplayLabel_3;
			this.txtDisplayLabel[4] = _txtDisplayLabel_4;
			this.txtDisplayLabel[7] = _txtDisplayLabel_7;
			this.txtDisplayLabel[6] = _txtDisplayLabel_6;
			this.txtDisplayLabel[5] = _txtDisplayLabel_5;
			this.txtDisplayLabel[9] = _txtDisplayLabel_9;
		}
		void InitializetxtCommonTextBox()
		{
			this.txtCommonTextBox = new System.Windows.Forms.TextBox[5];
			this.txtCommonTextBox[4] = _txtCommonTextBox_4;
			this.txtCommonTextBox[2] = _txtCommonTextBox_2;
			this.txtCommonTextBox[0] = _txtCommonTextBox_0;
			this.txtCommonTextBox[3] = _txtCommonTextBox_3;
			this.txtCommonTextBox[1] = _txtCommonTextBox_1;
		}
		void InitializetxtCommonNumber()
		{
			this.txtCommonNumber = new System.Windows.Forms.TextBox[5];
			this.txtCommonNumber[0] = _txtCommonNumber_0;
			this.txtCommonNumber[1] = _txtCommonNumber_1;
			this.txtCommonNumber[2] = _txtCommonNumber_2;
			this.txtCommonNumber[3] = _txtCommonNumber_3;
			this.txtCommonNumber[4] = _txtCommonNumber_4;
		}
		void InitializetxtCommonDate()
		{
			this.txtCommonDate = new Syncfusion.WinForms.Input.SfDateTimeEdit[2];
			this.txtCommonDate[1] = _txtCommonDate_1;
			this.txtCommonDate[0] = _txtCommonDate_0;
		}
		void InitializelblCommonLabel()
		{
			this.lblCommonLabel = new System.Windows.Forms.Label[30];
			this.lblCommonLabel[28] = _lblCommonLabel_28;
			this.lblCommonLabel[11] = _lblCommonLabel_11;
			this.lblCommonLabel[15] = _lblCommonLabel_15;
			this.lblCommonLabel[16] = _lblCommonLabel_16;
			this.lblCommonLabel[22] = _lblCommonLabel_22;
			this.lblCommonLabel[23] = _lblCommonLabel_23;
			this.lblCommonLabel[24] = _lblCommonLabel_24;
			this.lblCommonLabel[7] = _lblCommonLabel_7;
			this.lblCommonLabel[5] = _lblCommonLabel_5;
			this.lblCommonLabel[6] = _lblCommonLabel_6;
			this.lblCommonLabel[2] = _lblCommonLabel_2;
			this.lblCommonLabel[0] = _lblCommonLabel_0;
			this.lblCommonLabel[1] = _lblCommonLabel_1;
			this.lblCommonLabel[3] = _lblCommonLabel_3;
			this.lblCommonLabel[10] = _lblCommonLabel_10;
			this.lblCommonLabel[4] = _lblCommonLabel_4;
			this.lblCommonLabel[17] = _lblCommonLabel_17;
			this.lblCommonLabel[18] = _lblCommonLabel_18;
			this.lblCommonLabel[19] = _lblCommonLabel_19;
			this.lblCommonLabel[20] = _lblCommonLabel_20;
			this.lblCommonLabel[8] = _lblCommonLabel_8;
			this.lblCommonLabel[21] = _lblCommonLabel_21;
			this.lblCommonLabel[9] = _lblCommonLabel_9;
			this.lblCommonLabel[12] = _lblCommonLabel_12;
			this.lblCommonLabel[13] = _lblCommonLabel_13;
			this.lblCommonLabel[14] = _lblCommonLabel_14;
			this.lblCommonLabel[29] = _lblCommonLabel_29;
		}
		#endregion
	}
}//ENDSHERE
