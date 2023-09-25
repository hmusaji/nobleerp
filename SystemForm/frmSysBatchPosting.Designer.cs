
namespace Xtreme
{
	partial class frmSysBatchPosting
	{

		#region "Upgrade Support "
		private static frmSysBatchPosting m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmSysBatchPosting DefInstance
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
		public static frmSysBatchPosting CreateInstance()
		{
			frmSysBatchPosting theInstance = new frmSysBatchPosting();
			
			return theInstance;
		}
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "_cmdNav_4", "_cmdNav_3", "_cmdNav_2", "_cmdNav_1", "_Line1_0", "picNav", "_chkCommonPost_0", "_chkCommonPost_1", "_chkCommonPost_2", "_chkCommonPost_3", "_chkCommonPost_4", "_chkCommonPost_5", "AdvanceOptionFrame", "cmdDefaultSetting", "_imgStep_3", "_lblStep_3", "_fraStep_2", "txtToVoucherNo", "txtFromVoucherNo", "_lblCommon_5", "_lblCommon_4", "VoucherRange", "_lblCommon_3", "_lblCommon_2", "txtFromDate", "txtToDate", "DateRangeFrame", "_lblStep_0", "_imgStep_0", "_fraStep_1", "_chkCommonInclude_1", "_chkCommonInclude_0", "cmbVoucherTypes", "cmbLocation", "System.Windows.Forms.Label2", "Label1_0", "Label2", "Label1", "VoucherFrame", "cmbModule", "Label1_1", "Frame1", "_lblStep_1", "_imgStep_1", "_fraStep_0", "ProgressBar1", "_Label3_0", "_lblStep_2", "_imgStep_2", "_fraStep_3", "Label3", "Line1", "System.Windows.Forms.Label1", "chkCommonInclude", "chkCommonPost", "cmdNav", "fraStep", "imgStep", "lblCommon", "lblStep", "commandButtonHelper1"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		private System.Windows.Forms.Button _cmdNav_4;
		private System.Windows.Forms.Button _cmdNav_3;
		private System.Windows.Forms.Button _cmdNav_2;
		private System.Windows.Forms.Button _cmdNav_1;
		private System.Windows.Forms.Label _Line1_0;
		public System.Windows.Forms.PictureBox picNav;
		private System.Windows.Forms.CheckBox _chkCommonPost_0;
		private System.Windows.Forms.CheckBox _chkCommonPost_1;
		private System.Windows.Forms.CheckBox _chkCommonPost_2;
		private System.Windows.Forms.CheckBox _chkCommonPost_3;
		private System.Windows.Forms.CheckBox _chkCommonPost_4;
		private System.Windows.Forms.CheckBox _chkCommonPost_5;
		public System.Windows.Forms.GroupBox AdvanceOptionFrame;
		public System.Windows.Forms.Button cmdDefaultSetting;
		private System.Windows.Forms.PictureBox _imgStep_3;
		private System.Windows.Forms.Label _lblStep_3;
		private System.Windows.Forms.Panel _fraStep_2;
		public System.Windows.Forms.TextBox txtToVoucherNo;
		public System.Windows.Forms.TextBox txtFromVoucherNo;
		private System.Windows.Forms.Label _lblCommon_5;
		private System.Windows.Forms.Label _lblCommon_4;
		public System.Windows.Forms.GroupBox VoucherRange;
		private System.Windows.Forms.Label _lblCommon_3;
		private System.Windows.Forms.Label _lblCommon_2;
		public Syncfusion.WinForms.Input.SfDateTimeEdit txtFromDate;
		public Syncfusion.WinForms.Input.SfDateTimeEdit txtToDate;
		public System.Windows.Forms.GroupBox DateRangeFrame;
		private System.Windows.Forms.Label _lblStep_0;
		private System.Windows.Forms.PictureBox _imgStep_0;
		private System.Windows.Forms.Panel _fraStep_1;
		private System.Windows.Forms.CheckBox _chkCommonInclude_1;
		private System.Windows.Forms.CheckBox _chkCommonInclude_0;
		public System.Windows.Forms.ComboBox cmbVoucherTypes;
		public System.Windows.Forms.ComboBox cmbLocation;
		public System.Windows.Forms.Label Label2;
		private System.Windows.Forms.Label Label1_0;
		public System.Windows.Forms.Label Label2;
		public System.Windows.Forms.Label Label1;
		public System.Windows.Forms.GroupBox VoucherFrame;
		public System.Windows.Forms.ComboBox cmbModule;
		private System.Windows.Forms.Label Label1_1;
		public System.Windows.Forms.GroupBox Frame1;
		private System.Windows.Forms.Label _lblStep_1;
		private System.Windows.Forms.PictureBox _imgStep_1;
		private System.Windows.Forms.Panel _fraStep_0;
		public System.Windows.Forms.ProgressBar ProgressBar1;
		private System.Windows.Forms.Label _Label3_0;
		private System.Windows.Forms.Label _lblStep_2;
		private System.Windows.Forms.PictureBox _imgStep_2;
		private System.Windows.Forms.Panel _fraStep_3;
		public System.Windows.Forms.Label[] Label3 = new System.Windows.Forms.Label[1];
		public System.Windows.Forms.Label[] Line1 = new System.Windows.Forms.Label[1];
		public System.Windows.Forms.Label[] Label1 = new System.Windows.Forms.Label[2];
		public System.Windows.Forms.CheckBox[] chkCommonInclude = new System.Windows.Forms.CheckBox[2];
		public System.Windows.Forms.CheckBox[] chkCommonPost = new System.Windows.Forms.CheckBox[6];
		public System.Windows.Forms.Button[] cmdNav = new System.Windows.Forms.Button[5];
		public System.Windows.Forms.Panel[] fraStep = new System.Windows.Forms.Panel[4];
		public System.Windows.Forms.PictureBox[] imgStep = new System.Windows.Forms.PictureBox[4];
		public System.Windows.Forms.Label[] lblCommon = new System.Windows.Forms.Label[6];
		public System.Windows.Forms.Label[] lblStep = new System.Windows.Forms.Label[4];
		//public UpgradeHelpers.Gui.CommandButtonHelper commandButtonHelper1;
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSysBatchPosting));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this.picNav = new System.Windows.Forms.PictureBox();
			this._cmdNav_4 = new System.Windows.Forms.Button();
			this._cmdNav_3 = new System.Windows.Forms.Button();
			this._cmdNav_2 = new System.Windows.Forms.Button();
			this._cmdNav_1 = new System.Windows.Forms.Button();
			this._Line1_0 = new System.Windows.Forms.Label();
			this._fraStep_2 = new System.Windows.Forms.Panel();
			this.AdvanceOptionFrame = new System.Windows.Forms.GroupBox();
			this._chkCommonPost_0 = new System.Windows.Forms.CheckBox();
			this._chkCommonPost_1 = new System.Windows.Forms.CheckBox();
			this._chkCommonPost_2 = new System.Windows.Forms.CheckBox();
			this._chkCommonPost_3 = new System.Windows.Forms.CheckBox();
			this._chkCommonPost_4 = new System.Windows.Forms.CheckBox();
			this._chkCommonPost_5 = new System.Windows.Forms.CheckBox();
			this.cmdDefaultSetting = new System.Windows.Forms.Button();
			this._imgStep_3 = new System.Windows.Forms.PictureBox();
			this._lblStep_3 = new System.Windows.Forms.Label();
			this._fraStep_1 = new System.Windows.Forms.Panel();
			this.VoucherRange = new System.Windows.Forms.GroupBox();
			this.txtToVoucherNo = new System.Windows.Forms.TextBox();
			this.txtFromVoucherNo = new System.Windows.Forms.TextBox();
			this._lblCommon_5 = new System.Windows.Forms.Label();
			this._lblCommon_4 = new System.Windows.Forms.Label();
			this.DateRangeFrame = new System.Windows.Forms.GroupBox();
			this._lblCommon_3 = new System.Windows.Forms.Label();
			this._lblCommon_2 = new System.Windows.Forms.Label();
			this.txtFromDate = new Syncfusion.WinForms.Input.SfDateTimeEdit();
			this.txtToDate = new Syncfusion.WinForms.Input.SfDateTimeEdit();
			this._lblStep_0 = new System.Windows.Forms.Label();
			this._imgStep_0 = new System.Windows.Forms.PictureBox();
			this._fraStep_0 = new System.Windows.Forms.Panel();
			this.VoucherFrame = new System.Windows.Forms.GroupBox();
			this._chkCommonInclude_1 = new System.Windows.Forms.CheckBox();
			this._chkCommonInclude_0 = new System.Windows.Forms.CheckBox();
			this.cmbVoucherTypes = new System.Windows.Forms.ComboBox();
			this.cmbLocation = new System.Windows.Forms.ComboBox();
			this.Label2 = new System.Windows.Forms.Label();
			this.Label1_0 = new System.Windows.Forms.Label();
			this.Label2 = new System.Windows.Forms.Label();
			this.Label1 = new System.Windows.Forms.Label();
			this.Frame1 = new System.Windows.Forms.GroupBox();
			this.cmbModule = new System.Windows.Forms.ComboBox();
			this.Label1_1 = new System.Windows.Forms.Label();
			this._lblStep_1 = new System.Windows.Forms.Label();
			this._imgStep_1 = new System.Windows.Forms.PictureBox();
			this._fraStep_3 = new System.Windows.Forms.Panel();
			this.ProgressBar1 = new System.Windows.Forms.ProgressBar();
			this._Label3_0 = new System.Windows.Forms.Label();
			this._lblStep_2 = new System.Windows.Forms.Label();
			this._imgStep_2 = new System.Windows.Forms.PictureBox();
			this.picNav.SuspendLayout();
			this._fraStep_2.SuspendLayout();
			this.AdvanceOptionFrame.SuspendLayout();
			this._fraStep_1.SuspendLayout();
			this.VoucherRange.SuspendLayout();
			this.DateRangeFrame.SuspendLayout();
			this._fraStep_0.SuspendLayout();
			this.VoucherFrame.SuspendLayout();
			this.Frame1.SuspendLayout();
			this._fraStep_3.SuspendLayout();
			this.SuspendLayout();
			//this.commandButtonHelper1 = new UpgradeHelpers.Gui.CommandButtonHelper(this.components);
			// 
			// picNav
			// 
			this.picNav.AllowDrop = true;
			this.picNav.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.picNav.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.picNav.CausesValidation = true;
			this.picNav.Controls.Add(this._cmdNav_4);
			this.picNav.Controls.Add(this._cmdNav_3);
			this.picNav.Controls.Add(this._cmdNav_2);
			this.picNav.Controls.Add(this._cmdNav_1);
			this.picNav.Controls.Add(this._Line1_0);
			this.picNav.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.picNav.Enabled = true;
			this.picNav.Location = new System.Drawing.Point(0, 295);
			this.picNav.Name = "picNav";
			this.picNav.Size = new System.Drawing.Size(519, 38);
			this.picNav.TabIndex = 3;
			this.picNav.TabStop = true;
			this.picNav.Visible = true;
			// 
			// _cmdNav_4
			// 
			this._cmdNav_4.AllowDrop = true;
			this._cmdNav_4.BackColor = System.Drawing.SystemColors.Control;
			this._cmdNav_4.Enabled = false;
			this._cmdNav_4.ForeColor = System.Drawing.SystemColors.ControlText;
			this._cmdNav_4.Location = new System.Drawing.Point(396, 8);
			this._cmdNav_4.Name = "_cmdNav_4";
			this._cmdNav_4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._cmdNav_4.Size = new System.Drawing.Size(73, 21);
			this._cmdNav_4.TabIndex = 7;
			this._cmdNav_4.Tag = "104";
			this._cmdNav_4.Text = "&Finish";
			this._cmdNav_4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			// this._cmdNav_4.Click += new System.EventHandler(this.cmdNav_Click);
			// 
			// _cmdNav_3
			// 
			this._cmdNav_3.AllowDrop = true;
			this._cmdNav_3.BackColor = System.Drawing.SystemColors.Control;
			this._cmdNav_3.ForeColor = System.Drawing.SystemColors.ControlText;
			this._cmdNav_3.Location = new System.Drawing.Point(303, 8);
			this._cmdNav_3.Name = "_cmdNav_3";
			this._cmdNav_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._cmdNav_3.Size = new System.Drawing.Size(73, 21);
			this._cmdNav_3.TabIndex = 6;
			this._cmdNav_3.Tag = "103";
			this._cmdNav_3.Text = "&Next >";
			this._cmdNav_3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this._cmdNav_3.UseVisualStyleBackColor = false;
			// this._cmdNav_3.Click += new System.EventHandler(this.cmdNav_Click);
			// 
			// _cmdNav_2
			// 
			this._cmdNav_2.AllowDrop = true;
			this._cmdNav_2.BackColor = System.Drawing.SystemColors.Control;
			this._cmdNav_2.ForeColor = System.Drawing.SystemColors.ControlText;
			this._cmdNav_2.Location = new System.Drawing.Point(229, 8);
			this._cmdNav_2.Name = "_cmdNav_2";
			this._cmdNav_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._cmdNav_2.Size = new System.Drawing.Size(73, 21);
			this._cmdNav_2.TabIndex = 5;
			this._cmdNav_2.Tag = "102";
			this._cmdNav_2.Text = "< &Back";
			this._cmdNav_2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this._cmdNav_2.UseVisualStyleBackColor = false;
			// this._cmdNav_2.Click += new System.EventHandler(this.cmdNav_Click);
			// 
			// _cmdNav_1
			// 
			this._cmdNav_1.AllowDrop = true;
			this._cmdNav_1.BackColor = System.Drawing.SystemColors.Control;
			this._cmdNav_1.ForeColor = System.Drawing.SystemColors.ControlText;
			this._cmdNav_1.Location = new System.Drawing.Point(150, 8);
			this._cmdNav_1.Name = "_cmdNav_1";
			this._cmdNav_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._cmdNav_1.Size = new System.Drawing.Size(73, 21);
			this._cmdNav_1.TabIndex = 4;
			this._cmdNav_1.Tag = "101";
			this._cmdNav_1.Text = "Cancel";
			this._cmdNav_1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this._cmdNav_1.UseVisualStyleBackColor = false;
			// this._cmdNav_1.Click += new System.EventHandler(this.cmdNav_Click);
			// 
			// _Line1_0
			// 
			this._Line1_0.AllowDrop = true;
			this._Line1_0.BackColor = System.Drawing.Color.White;
			this._Line1_0.Enabled = false;
			this._Line1_0.Location = new System.Drawing.Point(1, 0);
			this._Line1_0.Name = "_Line1_0";
			this._Line1_0.Size = new System.Drawing.Size(519, 1);
			this._Line1_0.Visible = true;
			// 
			// _fraStep_2
			// 
			this._fraStep_2.AllowDrop = true;
			this._fraStep_2.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._fraStep_2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._fraStep_2.Controls.Add(this.AdvanceOptionFrame);
			this._fraStep_2.Controls.Add(this.cmdDefaultSetting);
			this._fraStep_2.Controls.Add(this._imgStep_3);
			this._fraStep_2.Controls.Add(this._lblStep_3);
			this._fraStep_2.Enabled = false;
			this._fraStep_2.ForeColor = System.Drawing.SystemColors.ControlText;
			this._fraStep_2.Location = new System.Drawing.Point(0, 0);
			this._fraStep_2.Name = "_fraStep_2";
			this._fraStep_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._fraStep_2.Size = new System.Drawing.Size(517, 295);
			this._fraStep_2.TabIndex = 35;
			this._fraStep_2.Tag = "2000";
			this._fraStep_2.Visible = true;
			// 
			// AdvanceOptionFrame
			// 
			this.AdvanceOptionFrame.AllowDrop = true;
			this.AdvanceOptionFrame.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.AdvanceOptionFrame.Controls.Add(this._chkCommonPost_0);
			this.AdvanceOptionFrame.Controls.Add(this._chkCommonPost_1);
			this.AdvanceOptionFrame.Controls.Add(this._chkCommonPost_2);
			this.AdvanceOptionFrame.Controls.Add(this._chkCommonPost_3);
			this.AdvanceOptionFrame.Controls.Add(this._chkCommonPost_4);
			this.AdvanceOptionFrame.Controls.Add(this._chkCommonPost_5);
			this.AdvanceOptionFrame.Enabled = true;
			this.AdvanceOptionFrame.ForeColor = System.Drawing.SystemColors.ControlText;
			this.AdvanceOptionFrame.Location = new System.Drawing.Point(172, 64);
			this.AdvanceOptionFrame.Name = "AdvanceOptionFrame";
			this.AdvanceOptionFrame.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.AdvanceOptionFrame.Size = new System.Drawing.Size(333, 163);
			this.AdvanceOptionFrame.TabIndex = 38;
			this.AdvanceOptionFrame.Text = "Advance Options";
			this.AdvanceOptionFrame.Visible = true;
			// 
			// _chkCommonPost_0
			// 
			this._chkCommonPost_0.AllowDrop = true;
			this._chkCommonPost_0.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkCommonPost_0.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._chkCommonPost_0.CausesValidation = true;
			this._chkCommonPost_0.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommonPost_0.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkCommonPost_0.Enabled = true;
			this._chkCommonPost_0.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkCommonPost_0.Location = new System.Drawing.Point(12, 28);
			this._chkCommonPost_0.Name = "_chkCommonPost_0";
			this._chkCommonPost_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkCommonPost_0.Size = new System.Drawing.Size(267, 19);
			this._chkCommonPost_0.TabIndex = 44;
			this._chkCommonPost_0.TabStop = true;
			this._chkCommonPost_0.Text = "Approve Transactions (Read Only Status)";
			this._chkCommonPost_0.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommonPost_0.Visible = true;
			this._chkCommonPost_0.CheckStateChanged += new System.EventHandler(this.chkCommonPost_CheckStateChanged);
			// 
			// _chkCommonPost_1
			// 
			this._chkCommonPost_1.AllowDrop = true;
			this._chkCommonPost_1.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkCommonPost_1.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._chkCommonPost_1.CausesValidation = true;
			this._chkCommonPost_1.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommonPost_1.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkCommonPost_1.Enabled = true;
			this._chkCommonPost_1.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkCommonPost_1.Location = new System.Drawing.Point(12, 47);
			this._chkCommonPost_1.Name = "_chkCommonPost_1";
			this._chkCommonPost_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkCommonPost_1.Size = new System.Drawing.Size(267, 19);
			this._chkCommonPost_1.TabIndex = 43;
			this._chkCommonPost_1.TabStop = true;
			this._chkCommonPost_1.Text = "Post Transactions To ICS";
			this._chkCommonPost_1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommonPost_1.Visible = true;
			this._chkCommonPost_1.CheckStateChanged += new System.EventHandler(this.chkCommonPost_CheckStateChanged);
			// 
			// _chkCommonPost_2
			// 
			this._chkCommonPost_2.AllowDrop = true;
			this._chkCommonPost_2.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkCommonPost_2.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._chkCommonPost_2.CausesValidation = true;
			this._chkCommonPost_2.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommonPost_2.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkCommonPost_2.Enabled = true;
			this._chkCommonPost_2.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkCommonPost_2.Location = new System.Drawing.Point(12, 66);
			this._chkCommonPost_2.Name = "_chkCommonPost_2";
			this._chkCommonPost_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkCommonPost_2.Size = new System.Drawing.Size(267, 19);
			this._chkCommonPost_2.TabIndex = 42;
			this._chkCommonPost_2.TabStop = true;
			this._chkCommonPost_2.Text = "Post Transactions To GLS";
			this._chkCommonPost_2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommonPost_2.Visible = true;
			this._chkCommonPost_2.CheckStateChanged += new System.EventHandler(this.chkCommonPost_CheckStateChanged);
			// 
			// _chkCommonPost_3
			// 
			this._chkCommonPost_3.AllowDrop = true;
			this._chkCommonPost_3.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkCommonPost_3.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._chkCommonPost_3.CausesValidation = true;
			this._chkCommonPost_3.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommonPost_3.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkCommonPost_3.Enabled = true;
			this._chkCommonPost_3.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkCommonPost_3.Location = new System.Drawing.Point(50, 89);
			this._chkCommonPost_3.Name = "_chkCommonPost_3";
			this._chkCommonPost_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkCommonPost_3.Size = new System.Drawing.Size(267, 19);
			this._chkCommonPost_3.TabIndex = 41;
			this._chkCommonPost_3.TabStop = true;
			this._chkCommonPost_3.Text = "Party / Cash / Bank Accounts Only";
			this._chkCommonPost_3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommonPost_3.Visible = true;
			this._chkCommonPost_3.CheckStateChanged += new System.EventHandler(this.chkCommonPost_CheckStateChanged);
			// 
			// _chkCommonPost_4
			// 
			this._chkCommonPost_4.AllowDrop = true;
			this._chkCommonPost_4.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkCommonPost_4.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._chkCommonPost_4.CausesValidation = true;
			this._chkCommonPost_4.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommonPost_4.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkCommonPost_4.Enabled = true;
			this._chkCommonPost_4.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkCommonPost_4.Location = new System.Drawing.Point(50, 108);
			this._chkCommonPost_4.Name = "_chkCommonPost_4";
			this._chkCommonPost_4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkCommonPost_4.Size = new System.Drawing.Size(267, 19);
			this._chkCommonPost_4.TabIndex = 40;
			this._chkCommonPost_4.TabStop = true;
			this._chkCommonPost_4.Text = "Voucher Expenses Only";
			this._chkCommonPost_4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommonPost_4.Visible = true;
			this._chkCommonPost_4.CheckStateChanged += new System.EventHandler(this.chkCommonPost_CheckStateChanged);
			// 
			// _chkCommonPost_5
			// 
			this._chkCommonPost_5.AllowDrop = true;
			this._chkCommonPost_5.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkCommonPost_5.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._chkCommonPost_5.CausesValidation = true;
			this._chkCommonPost_5.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommonPost_5.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkCommonPost_5.Enabled = true;
			this._chkCommonPost_5.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkCommonPost_5.Location = new System.Drawing.Point(50, 127);
			this._chkCommonPost_5.Name = "_chkCommonPost_5";
			this._chkCommonPost_5.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkCommonPost_5.Size = new System.Drawing.Size(267, 19);
			this._chkCommonPost_5.TabIndex = 39;
			this._chkCommonPost_5.TabStop = true;
			this._chkCommonPost_5.Text = "Inventory Accounts (With Item Costing) Only";
			this._chkCommonPost_5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommonPost_5.Visible = true;
			this._chkCommonPost_5.CheckStateChanged += new System.EventHandler(this.chkCommonPost_CheckStateChanged);
			// 
			// cmdDefaultSetting
			// 
			this.cmdDefaultSetting.AllowDrop = true;
			this.cmdDefaultSetting.BackColor = System.Drawing.SystemColors.Control;
			this.cmdDefaultSetting.Font = new System.Drawing.Font("Tahoma", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 178);
			this.cmdDefaultSetting.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdDefaultSetting.Location = new System.Drawing.Point(396, 242);
			this.cmdDefaultSetting.Name = "cmdDefaultSetting";
			this.cmdDefaultSetting.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdDefaultSetting.Size = new System.Drawing.Size(100, 27);
			this.cmdDefaultSetting.TabIndex = 37;
			this.cmdDefaultSetting.Text = "Save Settings";
			this.cmdDefaultSetting.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.cmdDefaultSetting.UseVisualStyleBackColor = false;
			// this.cmdDefaultSetting.Click += new System.EventHandler(this.cmdDefaultSetting_Click);
			// 
			// _imgStep_3
			// 
			this._imgStep_3.AllowDrop = true;
			this._imgStep_3.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._imgStep_3.Enabled = true;
			//this._imgStep_3.Image = (System.Drawing.Image) resources.GetObject("_imgStep_3.Image");
			this._imgStep_3.Location = new System.Drawing.Point(0, 0);
			this._imgStep_3.Name = "_imgStep_3";
			this._imgStep_3.Size = new System.Drawing.Size(158, 299);
			this._imgStep_3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this._imgStep_3.Visible = true;
			// 
			// _lblStep_3
			// 
			this._lblStep_3.AllowDrop = true;
			this._lblStep_3.BackColor = System.Drawing.Color.Transparent;
			this._lblStep_3.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lblStep_3.Font = new System.Drawing.Font("Arial", 14.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this._lblStep_3.ForeColor = System.Drawing.Color.FromArgb(0, 64, 128);
			this._lblStep_3.Location = new System.Drawing.Point(186, 24);
			this._lblStep_3.Name = "_lblStep_3";
			this._lblStep_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblStep_3.Size = new System.Drawing.Size(324, 46);
			this._lblStep_3.TabIndex = 36;
			this._lblStep_3.Tag = "2001";
			this._lblStep_3.Text = "Please select advance options";
			// 
			// _fraStep_1
			// 
			this._fraStep_1.AllowDrop = true;
			this._fraStep_1.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._fraStep_1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._fraStep_1.Controls.Add(this.VoucherRange);
			this._fraStep_1.Controls.Add(this.DateRangeFrame);
			this._fraStep_1.Controls.Add(this._lblStep_0);
			this._fraStep_1.Controls.Add(this._imgStep_0);
			this._fraStep_1.Enabled = false;
			this._fraStep_1.ForeColor = System.Drawing.SystemColors.ControlText;
			this._fraStep_1.Location = new System.Drawing.Point(0, 0);
			this._fraStep_1.Name = "_fraStep_1";
			this._fraStep_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._fraStep_1.Size = new System.Drawing.Size(517, 295);
			this._fraStep_1.TabIndex = 2;
			this._fraStep_1.Tag = "2000";
			this._fraStep_1.Text = "Step 1";
			this._fraStep_1.Visible = true;
			// 
			// VoucherRange
			// 
			this.VoucherRange.AllowDrop = true;
			this.VoucherRange.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.VoucherRange.Controls.Add(this.txtToVoucherNo);
			this.VoucherRange.Controls.Add(this.txtFromVoucherNo);
			this.VoucherRange.Controls.Add(this._lblCommon_5);
			this.VoucherRange.Controls.Add(this._lblCommon_4);
			this.VoucherRange.Enabled = true;
			this.VoucherRange.ForeColor = System.Drawing.SystemColors.ControlText;
			this.VoucherRange.Location = new System.Drawing.Point(176, 166);
			this.VoucherRange.Name = "VoucherRange";
			this.VoucherRange.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.VoucherRange.Size = new System.Drawing.Size(325, 103);
			this.VoucherRange.TabIndex = 23;
			this.VoucherRange.Text = "Voucher Number";
			this.VoucherRange.Visible = true;
			// 
			// txtToVoucherNo
			// 
			this.txtToVoucherNo.AllowDrop = true;
			this.txtToVoucherNo.BackColor = System.Drawing.Color.White;
			// this.txtToVoucherNo.bolNumericOnly = true;
			this.txtToVoucherNo.ForeColor = System.Drawing.Color.Black;
			this.txtToVoucherNo.Location = new System.Drawing.Point(114, 63);
			this.txtToVoucherNo.MaxLength = 12;
			// this.txtToVoucherNo.mDropDownType = (System.Windows.Forms.TextBox.DropDownTypes) 0;
			this.txtToVoucherNo.Name = "txtToVoucherNo";
			this.txtToVoucherNo.Size = new System.Drawing.Size(101, 19);
			this.txtToVoucherNo.TabIndex = 28;
			this.txtToVoucherNo.Text = "";
			// this.this.txtToVoucherNo.Watermark = "";
			// 
			// txtFromVoucherNo
			// 
			this.txtFromVoucherNo.AllowDrop = true;
			this.txtFromVoucherNo.BackColor = System.Drawing.Color.White;
			// this.txtFromVoucherNo.bolNumericOnly = true;
			this.txtFromVoucherNo.ForeColor = System.Drawing.Color.Black;
			this.txtFromVoucherNo.Location = new System.Drawing.Point(114, 28);
			this.txtFromVoucherNo.MaxLength = 12;
			// this.txtFromVoucherNo.mDropDownType = (System.Windows.Forms.TextBox.DropDownTypes) 0;
			this.txtFromVoucherNo.Name = "txtFromVoucherNo";
			this.txtFromVoucherNo.Size = new System.Drawing.Size(101, 19);
			this.txtFromVoucherNo.TabIndex = 29;
			this.txtFromVoucherNo.Text = "";
			// this.this.txtFromVoucherNo.Watermark = "";
			// 
			// _lblCommon_5
			// 
			this._lblCommon_5.AllowDrop = true;
			this._lblCommon_5.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_5.Text = "To Voucher No";
			this._lblCommon_5.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_5.Location = new System.Drawing.Point(10, 66);
			this._lblCommon_5.Name = "_lblCommon_5";
			this._lblCommon_5.Size = new System.Drawing.Size(70, 13);
			this._lblCommon_5.TabIndex = 30;
			// 
			// _lblCommon_4
			// 
			this._lblCommon_4.AllowDrop = true;
			this._lblCommon_4.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_4.Text = "From Voucher No";
			this._lblCommon_4.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_4.Location = new System.Drawing.Point(10, 31);
			this._lblCommon_4.Name = "_lblCommon_4";
			this._lblCommon_4.Size = new System.Drawing.Size(82, 13);
			this._lblCommon_4.TabIndex = 31;
			// 
			// DateRangeFrame
			// 
			this.DateRangeFrame.AllowDrop = true;
			this.DateRangeFrame.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.DateRangeFrame.Controls.Add(this._lblCommon_3);
			this.DateRangeFrame.Controls.Add(this._lblCommon_2);
			this.DateRangeFrame.Controls.Add(this.txtFromDate);
			this.DateRangeFrame.Controls.Add(this.txtToDate);
			this.DateRangeFrame.Enabled = true;
			this.DateRangeFrame.ForeColor = System.Drawing.SystemColors.ControlText;
			this.DateRangeFrame.Location = new System.Drawing.Point(176, 50);
			this.DateRangeFrame.Name = "DateRangeFrame";
			this.DateRangeFrame.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.DateRangeFrame.Size = new System.Drawing.Size(327, 103);
			this.DateRangeFrame.TabIndex = 22;
			this.DateRangeFrame.Text = "Date Range";
			this.DateRangeFrame.Visible = true;
			// 
			// _lblCommon_3
			// 
			this._lblCommon_3.AllowDrop = true;
			this._lblCommon_3.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_3.Text = "To Date";
			this._lblCommon_3.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_3.Location = new System.Drawing.Point(14, 60);
			this._lblCommon_3.Name = "_lblCommon_3";
			this._lblCommon_3.Size = new System.Drawing.Size(38, 13);
			this._lblCommon_3.TabIndex = 24;
			// 
			// _lblCommon_2
			// 
			this._lblCommon_2.AllowDrop = true;
			this._lblCommon_2.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_2.Text = "From Date";
			this._lblCommon_2.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_2.Location = new System.Drawing.Point(14, 29);
			this._lblCommon_2.Name = "_lblCommon_2";
			this._lblCommon_2.Size = new System.Drawing.Size(50, 13);
			this._lblCommon_2.TabIndex = 25;
			// 
			// txtFromDate
			// 
			this.txtFromDate.AllowDrop = true;
			// this.txtFromDate.CheckDateRange = false;
			this.txtFromDate.Location = new System.Drawing.Point(118, 26);
			// this.txtFromDate.MaxDate = 2958465;
			// this.txtFromDate.MinDate = 2;
			this.txtFromDate.Name = "txtFromDate";
			this.txtFromDate.Size = new System.Drawing.Size(101, 19);
			this.txtFromDate.TabIndex = 26;
			// this.txtFromDate.Text = "07/18/2001";
			// this.txtFromDate.Value = 37090;
			// 
			// txtToDate
			// 
			this.txtToDate.AllowDrop = true;
			// this.txtToDate.CheckDateRange = false;
			this.txtToDate.Location = new System.Drawing.Point(118, 57);
			// this.txtToDate.MaxDate = 2958465;
			// this.txtToDate.MinDate = 2;
			this.txtToDate.Name = "txtToDate";
			this.txtToDate.Size = new System.Drawing.Size(101, 19);
			this.txtToDate.TabIndex = 27;
			// this.txtToDate.Text = "07/18/2001";
			// this.txtToDate.Value = 37090;
			// 
			// _lblStep_0
			// 
			this._lblStep_0.AllowDrop = true;
			this._lblStep_0.BackColor = System.Drawing.Color.Transparent;
			this._lblStep_0.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lblStep_0.Font = new System.Drawing.Font("Arial", 14.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this._lblStep_0.ForeColor = System.Drawing.Color.FromArgb(0, 64, 128);
			this._lblStep_0.Location = new System.Drawing.Point(180, 8);
			this._lblStep_0.Name = "_lblStep_0";
			this._lblStep_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblStep_0.Size = new System.Drawing.Size(324, 38);
			this._lblStep_0.TabIndex = 21;
			this._lblStep_0.Tag = "2001";
			this._lblStep_0.Text = "Specify Parameters";
			// 
			// _imgStep_0
			// 
			this._imgStep_0.AllowDrop = true;
			this._imgStep_0.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._imgStep_0.Enabled = true;
			//this._imgStep_0.Image = (System.Drawing.Image) resources.GetObject("_imgStep_0.Image");
			this._imgStep_0.Location = new System.Drawing.Point(0, 0);
			this._imgStep_0.Name = "_imgStep_0";
			this._imgStep_0.Size = new System.Drawing.Size(158, 299);
			this._imgStep_0.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this._imgStep_0.Visible = true;
			// 
			// _fraStep_0
			// 
			this._fraStep_0.AllowDrop = true;
			this._fraStep_0.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._fraStep_0.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._fraStep_0.Controls.Add(this.VoucherFrame);
			this._fraStep_0.Controls.Add(this.Frame1);
			this._fraStep_0.Controls.Add(this._lblStep_1);
			this._fraStep_0.Controls.Add(this._imgStep_1);
			this._fraStep_0.Enabled = false;
			this._fraStep_0.ForeColor = System.Drawing.SystemColors.ControlText;
			this._fraStep_0.Location = new System.Drawing.Point(0, 0);
			this._fraStep_0.Name = "_fraStep_0";
			this._fraStep_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._fraStep_0.Size = new System.Drawing.Size(517, 295);
			this._fraStep_0.TabIndex = 0;
			this._fraStep_0.Tag = "2000";
			this._fraStep_0.Text = "Step 1";
			this._fraStep_0.Visible = true;
			// 
			// VoucherFrame
			// 
			this.VoucherFrame.AllowDrop = true;
			this.VoucherFrame.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.VoucherFrame.Controls.Add(this._chkCommonInclude_1);
			this.VoucherFrame.Controls.Add(this._chkCommonInclude_0);
			this.VoucherFrame.Controls.Add(this.cmbVoucherTypes);
			this.VoucherFrame.Controls.Add(this.cmbLocation);
			this.VoucherFrame.Controls.Add(this.Label2);
			this.VoucherFrame.Controls.Add(this.Label1_0);
			this.VoucherFrame.Controls.Add(this.Label2);
			this.VoucherFrame.Controls.Add(this.Label1);
			this.VoucherFrame.Enabled = false;
			this.VoucherFrame.ForeColor = System.Drawing.SystemColors.ControlText;
			this.VoucherFrame.Location = new System.Drawing.Point(174, 136);
			this.VoucherFrame.Name = "VoucherFrame";
			this.VoucherFrame.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.VoucherFrame.Size = new System.Drawing.Size(327, 137);
			this.VoucherFrame.TabIndex = 11;
			this.VoucherFrame.Text = "Transaction Type";
			this.VoucherFrame.Visible = true;
			// 
			// _chkCommonInclude_1
			// 
			this._chkCommonInclude_1.AllowDrop = true;
			this._chkCommonInclude_1.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkCommonInclude_1.BackColor = System.Drawing.Color.FromArgb(248, 247, 239);
			this._chkCommonInclude_1.CausesValidation = true;
			this._chkCommonInclude_1.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommonInclude_1.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkCommonInclude_1.Enabled = true;
			this._chkCommonInclude_1.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkCommonInclude_1.Location = new System.Drawing.Point(192, 93);
			this._chkCommonInclude_1.Name = "_chkCommonInclude_1";
			this._chkCommonInclude_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkCommonInclude_1.Size = new System.Drawing.Size(13, 13);
			this._chkCommonInclude_1.TabIndex = 13;
			this._chkCommonInclude_1.TabStop = true;
			this._chkCommonInclude_1.Text = "Include All";
			this._chkCommonInclude_1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommonInclude_1.Visible = true;
			// 
			// _chkCommonInclude_0
			// 
			this._chkCommonInclude_0.AllowDrop = true;
			this._chkCommonInclude_0.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkCommonInclude_0.BackColor = System.Drawing.Color.FromArgb(248, 247, 239);
			this._chkCommonInclude_0.CausesValidation = true;
			this._chkCommonInclude_0.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommonInclude_0.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkCommonInclude_0.Enabled = true;
			this._chkCommonInclude_0.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkCommonInclude_0.Location = new System.Drawing.Point(192, 44);
			this._chkCommonInclude_0.Name = "_chkCommonInclude_0";
			this._chkCommonInclude_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkCommonInclude_0.Size = new System.Drawing.Size(13, 13);
			this._chkCommonInclude_0.TabIndex = 12;
			this._chkCommonInclude_0.TabStop = true;
			this._chkCommonInclude_0.Text = "Include All";
			this._chkCommonInclude_0.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommonInclude_0.Visible = true;
			// 
			// cmbVoucherTypes
			// 
			this.cmbVoucherTypes.AllowDrop = true;
			this.cmbVoucherTypes.Location = new System.Drawing.Point(10, 40);
			this.cmbVoucherTypes.Name = "cmbVoucherTypes";
			this.cmbVoucherTypes.Size = new System.Drawing.Size(173, 21);
			this.cmbVoucherTypes.TabIndex = 14;
			// 
			// cmbLocation
			// 
			this.cmbLocation.AllowDrop = true;
			this.cmbLocation.Location = new System.Drawing.Point(10, 90);
			this.cmbLocation.Name = "cmbLocation";
			this.cmbLocation.Size = new System.Drawing.Size(173, 21);
			this.cmbLocation.TabIndex = 15;
			// 
			// System.Windows.Forms.Label2
			// 
			this.Label2.AllowDrop = true;
			this.Label2.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.Label2.Text = "Select Location";
			this.Label2.Location = new System.Drawing.Point(10, 72);
			this.Label2.Name = "System.Windows.Forms.Label2";
			this.Label2.Size = new System.Drawing.Size(74, 13);
			this.Label2.TabIndex = 16;
			// 
			// Label1_0
			// 
			this.Label1_0.AllowDrop = true;
			this.Label1_0.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.Label1_0.Text = "Select Transaction Type";
			this.Label1_0.Location = new System.Drawing.Point(10, 22);
			this.Label1_0.Name = "Label1_0";
			this.Label1_0.Size = new System.Drawing.Size(116, 13);
			this.Label1_0.TabIndex = 17;
			// 
			// Label2
			// 
			this.Label2.AllowDrop = true;
			this.Label2.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.Label2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Label2.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Label2.Location = new System.Drawing.Point(208, 92);
			this.Label2.Name = "Label2";
			this.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label2.Size = new System.Drawing.Size(61, 17);
			this.Label2.TabIndex = 19;
			this.Label2.Text = "Select All";
			// 
			// Label1
			// 
			this.Label1.AllowDrop = true;
			this.Label1.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.Label1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Label1.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Label1.Location = new System.Drawing.Point(208, 44);
			this.Label1.Name = "Label1";
			this.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label1.Size = new System.Drawing.Size(61, 17);
			this.Label1.TabIndex = 18;
			this.Label1.Text = "Select All";
			// 
			// Frame1
			// 
			this.Frame1.AllowDrop = true;
			this.Frame1.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.Frame1.Controls.Add(this.cmbModule);
			this.Frame1.Controls.Add(this.Label1_1);
			this.Frame1.Enabled = true;
			this.Frame1.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Frame1.Location = new System.Drawing.Point(174, 56);
			this.Frame1.Name = "Frame1";
			this.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Frame1.Size = new System.Drawing.Size(327, 69);
			this.Frame1.TabIndex = 8;
			this.Frame1.Text = "Module";
			this.Frame1.Visible = true;
			// 
			// cmbModule
			// 
			this.cmbModule.AllowDrop = true;
			this.cmbModule.Location = new System.Drawing.Point(10, 36);
			this.cmbModule.Name = "cmbModule";
			this.cmbModule.Size = new System.Drawing.Size(173, 21);
			this.cmbModule.TabIndex = 9;
			// this.cmbModule.Click += new System.Windows.Forms.ComboBox.ClickHandler(this.cmbModule_Click);
			// 
			// Label1_1
			// 
			this.Label1_1.AllowDrop = true;
			this.Label1_1.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.Label1_1.Text = "Select Module";
			this.Label1_1.Location = new System.Drawing.Point(10, 18);
			this.Label1_1.Name = "Label1_1";
			this.Label1_1.Size = new System.Drawing.Size(73, 13);
			this.Label1_1.TabIndex = 10;
			// 
			// _lblStep_1
			// 
			this._lblStep_1.AllowDrop = true;
			this._lblStep_1.BackColor = System.Drawing.Color.Transparent;
			this._lblStep_1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lblStep_1.Font = new System.Drawing.Font("Arial", 18f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this._lblStep_1.ForeColor = System.Drawing.Color.FromArgb(0, 64, 128);
			this._lblStep_1.Location = new System.Drawing.Point(192, 16);
			this._lblStep_1.Name = "_lblStep_1";
			this._lblStep_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblStep_1.Size = new System.Drawing.Size(324, 38);
			this._lblStep_1.TabIndex = 1;
			this._lblStep_1.Tag = "2001";
			this._lblStep_1.Text = "Welcome To Post Wizard";
			// 
			// _imgStep_1
			// 
			this._imgStep_1.AllowDrop = true;
			this._imgStep_1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._imgStep_1.Enabled = true;
			//this._imgStep_1.Image = (System.Drawing.Image) resources.GetObject("_imgStep_1.Image");
			this._imgStep_1.Location = new System.Drawing.Point(0, 0);
			this._imgStep_1.Name = "_imgStep_1";
			this._imgStep_1.Size = new System.Drawing.Size(158, 299);
			this._imgStep_1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this._imgStep_1.Visible = true;
			// 
			// _fraStep_3
			// 
			this._fraStep_3.AllowDrop = true;
			this._fraStep_3.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._fraStep_3.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._fraStep_3.Controls.Add(this.ProgressBar1);
			this._fraStep_3.Controls.Add(this._Label3_0);
			this._fraStep_3.Controls.Add(this._lblStep_2);
			this._fraStep_3.Controls.Add(this._imgStep_2);
			this._fraStep_3.Enabled = false;
			this._fraStep_3.ForeColor = System.Drawing.SystemColors.ControlText;
			this._fraStep_3.Location = new System.Drawing.Point(0, 0);
			this._fraStep_3.Name = "_fraStep_3";
			this._fraStep_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._fraStep_3.Size = new System.Drawing.Size(517, 295);
			this._fraStep_3.TabIndex = 20;
			this._fraStep_3.Tag = "2000";
			this._fraStep_3.Visible = true;
			// 
			// ProgressBar1
			// 
			this.ProgressBar1.AllowDrop = true;
			this.ProgressBar1.Location = new System.Drawing.Point(164, 244);
			this.ProgressBar1.Name = "ProgressBar1";
			this.ProgressBar1.Size = new System.Drawing.Size(349, 25);
			this.ProgressBar1.TabIndex = 33;
			// 
			// _Label3_0
			// 
			this._Label3_0.AllowDrop = true;
			this._Label3_0.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._Label3_0.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._Label3_0.ForeColor = System.Drawing.SystemColors.ControlText;
			this._Label3_0.Location = new System.Drawing.Point(170, 218);
			this._Label3_0.Name = "_Label3_0";
			this._Label3_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._Label3_0.Size = new System.Drawing.Size(71, 15);
			this._Label3_0.TabIndex = 34;
			this._Label3_0.Text = "Complete :";
			// 
			// _lblStep_2
			// 
			this._lblStep_2.AllowDrop = true;
			this._lblStep_2.BackColor = System.Drawing.Color.Transparent;
			this._lblStep_2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lblStep_2.Font = new System.Drawing.Font("Arial", 14.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this._lblStep_2.ForeColor = System.Drawing.Color.FromArgb(0, 64, 128);
			this._lblStep_2.Location = new System.Drawing.Point(186, 24);
			this._lblStep_2.Name = "_lblStep_2";
			this._lblStep_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblStep_2.Size = new System.Drawing.Size(324, 46);
			this._lblStep_2.TabIndex = 32;
			this._lblStep_2.Tag = "2001";
			this._lblStep_2.Text = "Transaction are being posted Please wait....";
			// 
			// _imgStep_2
			// 
			this._imgStep_2.AllowDrop = true;
			this._imgStep_2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._imgStep_2.Enabled = true;
			//this._imgStep_2.Image = (System.Drawing.Image) resources.GetObject("_imgStep_2.Image");
			this._imgStep_2.Location = new System.Drawing.Point(0, 0);
			this._imgStep_2.Name = "_imgStep_2";
			this._imgStep_2.Size = new System.Drawing.Size(158, 299);
			this._imgStep_2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this._imgStep_2.Visible = true;
			// 
			// frmSysBatchPosting
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.CancelButton = this._cmdNav_1;
			this.ClientSize = new System.Drawing.Size(519, 333);
			this.Controls.Add(this.picNav);
			this.Controls.Add(this._fraStep_2);
			this.Controls.Add(this._fraStep_1);
			this.Controls.Add(this._fraStep_0);
			this.Controls.Add(this._fraStep_3);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			//this.Icon = (System.Drawing.Icon) resources.GetObject("frmSysBatchPosting.Icon");
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(283, 241);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmSysBatchPosting";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Post Wizard";
			this.commandButtonHelper1.SetStyle(this.cmdDefaultSetting, 1);
			// this.Activated += new System.EventHandler(this.frmSysBatchPosting_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
			// this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
			this.picNav.ResumeLayout(false);
			this._fraStep_2.ResumeLayout(false);
			this.AdvanceOptionFrame.ResumeLayout(false);
			this._fraStep_1.ResumeLayout(false);
			this.VoucherRange.ResumeLayout(false);
			this.DateRangeFrame.ResumeLayout(false);
			this._fraStep_0.ResumeLayout(false);
			this.VoucherFrame.ResumeLayout(false);
			this.Frame1.ResumeLayout(false);
			this._fraStep_3.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		// 
		void InitializelblStep()
		{
			this.lblStep = new System.Windows.Forms.Label[4];
			this.lblStep[3] = _lblStep_3;
			this.lblStep[0] = _lblStep_0;
			this.lblStep[1] = _lblStep_1;
			this.lblStep[2] = _lblStep_2;
		}
		void InitializelblCommon()
		{
			this.lblCommon = new System.Windows.Forms.Label[6];
			this.lblCommon[5] = _lblCommon_5;
			this.lblCommon[4] = _lblCommon_4;
			this.lblCommon[3] = _lblCommon_3;
			this.lblCommon[2] = _lblCommon_2;
		}
		void InitializeimgStep()
		{
			this.imgStep = new System.Windows.Forms.PictureBox[4];
			this.imgStep[3] = _imgStep_3;
			this.imgStep[0] = _imgStep_0;
			this.imgStep[1] = _imgStep_1;
			this.imgStep[2] = _imgStep_2;
		}
		void InitializefraStep()
		{
			this.fraStep = new System.Windows.Forms.Panel[4];
			this.fraStep[2] = _fraStep_2;
			this.fraStep[1] = _fraStep_1;
			this.fraStep[0] = _fraStep_0;
			this.fraStep[3] = _fraStep_3;
		}
		void InitializecmdNav()
		{
			this.cmdNav = new System.Windows.Forms.Button[5];
			this.cmdNav[4] = _cmdNav_4;
			this.cmdNav[3] = _cmdNav_3;
			this.cmdNav[2] = _cmdNav_2;
			this.cmdNav[1] = _cmdNav_1;
		}
		void InitializechkCommonPost()
		{
			this.chkCommonPost = new System.Windows.Forms.CheckBox[6];
			this.chkCommonPost[0] = _chkCommonPost_0;
			this.chkCommonPost[1] = _chkCommonPost_1;
			this.chkCommonPost[2] = _chkCommonPost_2;
			this.chkCommonPost[3] = _chkCommonPost_3;
			this.chkCommonPost[4] = _chkCommonPost_4;
			this.chkCommonPost[5] = _chkCommonPost_5;
		}
		void InitializechkCommonInclude()
		{
			this.chkCommonInclude = new System.Windows.Forms.CheckBox[2];
			this.chkCommonInclude[1] = _chkCommonInclude_1;
			this.chkCommonInclude[0] = _chkCommonInclude_0;
		}
		void InitializeSystem.Windows.Forms.Label1()
		{
			this.Label1 = new System.Windows.Forms.Label[2];
			this.Label1[0] = Label1_0;
			this.Label1[1] = Label1_1;
		}
		void InitializeLine1()
		{
			this.Line1 = new System.Windows.Forms.Label[1];
			this.Line1[0] = _Line1_0;
		}
		void InitializeLabel3()
		{
			this.Label3 = new System.Windows.Forms.Label[1];
			this.Label3[0] = _Label3_0;
		}
		#endregion
	}
}//ENDSHERE
