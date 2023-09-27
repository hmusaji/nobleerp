
namespace Xtreme
{
	partial class frmREContractStatus
	{

		#region "Upgrade Support "
		private static frmREContractStatus m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmREContractStatus DefInstance
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
		public static frmREContractStatus CreateInstance()
		{
			frmREContractStatus theInstance = new frmREContractStatus();
			
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
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "txtComments", "_lblCommon_2", "_txtCommon_2", "_lblCommon_3", "_lblCommon_10", "_txtCommonDate_3", "_txtCommonDisplay_1", "_fraCommon_1", "_lblCommon_1", "_txtCommon_1", "_txtCommon_0", "_lblCommon_0", "_lblCommon_5", "_lblCommon_6", "_lblCommon_4", "_txtCommonDate_0", "_lblCommon_8", "_lblCommon_9", "_lblCommon_7", "_txtCommonDate_1", "_txtCommonDate_2", "_txtCommonDisplay_0", "_txtCommonDisplay_7", "_txtCommonDisplay_6", "_txtCommonDisplay_5", "_txtCommonDisplay_3", "_txtCommonDisplay_4", "_fraCommon_0", "fraCommon", "lblCommon", "txtCommon", "txtCommonDate", "txtCommonDisplay"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public System.Windows.Forms.TextBox txtComments;
		private System.Windows.Forms.Label _lblCommon_2;
		private System.Windows.Forms.TextBox _txtCommon_2;
		private System.Windows.Forms.Label _lblCommon_3;
		private System.Windows.Forms.Label _lblCommon_10;
		private Syncfusion.WinForms.Input.SfDateTimeEdit _txtCommonDate_3;
		private System.Windows.Forms.Label _txtCommonDisplay_1;
		private System.Windows.Forms.GroupBox _fraCommon_1;
		private System.Windows.Forms.Label _lblCommon_1;
		private System.Windows.Forms.TextBox _txtCommon_1;
		private System.Windows.Forms.TextBox _txtCommon_0;
		private System.Windows.Forms.Label _lblCommon_0;
		private System.Windows.Forms.Label _lblCommon_5;
		private System.Windows.Forms.Label _lblCommon_6;
		private System.Windows.Forms.Label _lblCommon_4;
		private Syncfusion.WinForms.Input.SfDateTimeEdit _txtCommonDate_0;
		private System.Windows.Forms.Label _lblCommon_8;
		private System.Windows.Forms.Label _lblCommon_9;
		private System.Windows.Forms.Label _lblCommon_7;
		private Syncfusion.WinForms.Input.SfDateTimeEdit _txtCommonDate_1;
		private Syncfusion.WinForms.Input.SfDateTimeEdit _txtCommonDate_2;
		private System.Windows.Forms.Label _txtCommonDisplay_0;
		private System.Windows.Forms.Label _txtCommonDisplay_7;
		private System.Windows.Forms.Label _txtCommonDisplay_6;
		private System.Windows.Forms.Label _txtCommonDisplay_5;
		private System.Windows.Forms.Label _txtCommonDisplay_3;
		private System.Windows.Forms.Label _txtCommonDisplay_4;
		private System.Windows.Forms.GroupBox _fraCommon_0;
		public System.Windows.Forms.GroupBox[] fraCommon = new System.Windows.Forms.GroupBox[2];
		public System.Windows.Forms.Label[] lblCommon = new System.Windows.Forms.Label[11];
		public System.Windows.Forms.TextBox[] txtCommon = new System.Windows.Forms.TextBox[3];
		public Syncfusion.WinForms.Input.SfDateTimeEdit[] txtCommonDate = new Syncfusion.WinForms.Input.SfDateTimeEdit[4];
		public System.Windows.Forms.Label[] txtCommonDisplay = new System.Windows.Forms.Label[8];
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmREContractStatus));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this._fraCommon_1 = new System.Windows.Forms.GroupBox();
			this.txtComments = new System.Windows.Forms.TextBox();
			this._lblCommon_2 = new System.Windows.Forms.Label();
			this._txtCommon_2 = new System.Windows.Forms.TextBox();
			this._lblCommon_3 = new System.Windows.Forms.Label();
			this._lblCommon_10 = new System.Windows.Forms.Label();
			this._txtCommonDate_3 = new Syncfusion.WinForms.Input.SfDateTimeEdit();
			this._txtCommonDisplay_1 = new System.Windows.Forms.Label();
			this._fraCommon_0 = new System.Windows.Forms.GroupBox();
			this._lblCommon_1 = new System.Windows.Forms.Label();
			this._txtCommon_1 = new System.Windows.Forms.TextBox();
			this._txtCommon_0 = new System.Windows.Forms.TextBox();
			this._lblCommon_0 = new System.Windows.Forms.Label();
			this._lblCommon_5 = new System.Windows.Forms.Label();
			this._lblCommon_6 = new System.Windows.Forms.Label();
			this._lblCommon_4 = new System.Windows.Forms.Label();
			this._txtCommonDate_0 = new Syncfusion.WinForms.Input.SfDateTimeEdit();
			this._lblCommon_8 = new System.Windows.Forms.Label();
			this._lblCommon_9 = new System.Windows.Forms.Label();
			this._lblCommon_7 = new System.Windows.Forms.Label();
			this._txtCommonDate_1 = new Syncfusion.WinForms.Input.SfDateTimeEdit();
			this._txtCommonDate_2 = new Syncfusion.WinForms.Input.SfDateTimeEdit();
			this._txtCommonDisplay_0 = new System.Windows.Forms.Label();
			this._txtCommonDisplay_7 = new System.Windows.Forms.Label();
			this._txtCommonDisplay_6 = new System.Windows.Forms.Label();
			this._txtCommonDisplay_5 = new System.Windows.Forms.Label();
			this._txtCommonDisplay_3 = new System.Windows.Forms.Label();
			this._txtCommonDisplay_4 = new System.Windows.Forms.Label();
			//this._fraCommon_1.SuspendLayout();
			//this._fraCommon_0.SuspendLayout();
			this.SuspendLayout();
			// 
			// _fraCommon_1
			// 
			//this._fraCommon_1.AllowDrop = true;
			this._fraCommon_1.BackColor = System.Drawing.Color.FromArgb(224, 230, 237);
			this._fraCommon_1.Controls.Add(this.txtComments);
			this._fraCommon_1.Controls.Add(this._lblCommon_2);
			this._fraCommon_1.Controls.Add(this._txtCommon_2);
			this._fraCommon_1.Controls.Add(this._lblCommon_3);
			this._fraCommon_1.Controls.Add(this._lblCommon_10);
			this._fraCommon_1.Controls.Add(this._txtCommonDate_3);
			this._fraCommon_1.Controls.Add(this._txtCommonDisplay_1);
			this._fraCommon_1.Enabled = true;
			this._fraCommon_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Italic | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 178);
			this._fraCommon_1.ForeColor = System.Drawing.SystemColors.ControlText;
			this._fraCommon_1.Location = new System.Drawing.Point(8, 210);
			this._fraCommon_1.Name = "_fraCommon_1";
			this._fraCommon_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._fraCommon_1.Size = new System.Drawing.Size(441, 111);
			this._fraCommon_1.TabIndex = 17;
			this._fraCommon_1.Text = "Status Change Details  ";
			this._fraCommon_1.Visible = true;
			// 
			// txtComments
			// 
			this.txtComments.AcceptsReturn = true;
			//this.txtComments.AllowDrop = true;
			this.txtComments.BackColor = System.Drawing.SystemColors.Window;
			//this.txtComments.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtComments.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtComments.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtComments.Location = new System.Drawing.Point(122, 62);
			this.txtComments.MaxLength = 100;
			this.txtComments.Multiline = true;
			this.txtComments.Name = "txtComments";
			this.txtComments.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtComments.Size = new System.Drawing.Size(304, 38);
			this.txtComments.TabIndex = 3;
			// 
			// _lblCommon_2
			// 
			//this._lblCommon_2.AllowDrop = true;
			this._lblCommon_2.BackColor = System.Drawing.Color.FromArgb(224, 230, 237);
			this._lblCommon_2.Text = "New Status Code";
			this._lblCommon_2.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_2.Location = new System.Drawing.Point(8, 23);
			// // this._lblCommon_2.mLabelId = 1171;
			this._lblCommon_2.Name = "_lblCommon_2";
			this._lblCommon_2.Size = new System.Drawing.Size(83, 13);
			this._lblCommon_2.TabIndex = 18;
			// 
			// _txtCommon_2
			// 
			//this._txtCommon_2.AllowDrop = true;
			this._txtCommon_2.BackColor = System.Drawing.Color.White;
			// this._txtCommon_2.bolNumericOnly = true;
			this._txtCommon_2.ForeColor = System.Drawing.Color.Black;
			this._txtCommon_2.Location = new System.Drawing.Point(122, 20);
			this._txtCommon_2.MaxLength = 15;
			this._txtCommon_2.Name = "_txtCommon_2";
			// this._txtCommon_2.ShowButton = true;
			this._txtCommon_2.Size = new System.Drawing.Size(101, 19);
			this._txtCommon_2.TabIndex = 1;
			this._txtCommon_2.Text = "";
			// this.// = "";
			// this.//this._txtCommon_2.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(//this.txtCommon_DropButtonClick);
			// this._txtCommon_2.Leave += new System.EventHandler(this.txtCommon_Leave);
			// 
			// _lblCommon_3
			// 
			//this._lblCommon_3.AllowDrop = true;
			this._lblCommon_3.BackColor = System.Drawing.Color.FromArgb(224, 230, 237);
			this._lblCommon_3.Text = "Comments";
			this._lblCommon_3.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_3.Location = new System.Drawing.Point(8, 64);
			// // this._lblCommon_3.mLabelId = 135;
			this._lblCommon_3.Name = "_lblCommon_3";
			this._lblCommon_3.Size = new System.Drawing.Size(49, 13);
			this._lblCommon_3.TabIndex = 19;
			// 
			// _lblCommon_10
			// 
			//this._lblCommon_10.AllowDrop = true;
			this._lblCommon_10.BackColor = System.Drawing.Color.FromArgb(224, 230, 237);
			this._lblCommon_10.Text = "Status Change Date";
			this._lblCommon_10.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_10.Location = new System.Drawing.Point(8, 44);
			// // this._lblCommon_10.mLabelId = 1171;
			this._lblCommon_10.Name = "_lblCommon_10";
			this._lblCommon_10.Size = new System.Drawing.Size(96, 13);
			this._lblCommon_10.TabIndex = 20;
			// 
			// _txtCommonDate_3
			// 
			//this._txtCommonDate_3.AllowDrop = true;
			this._txtCommonDate_3.BackColor = System.Drawing.Color.White;
			// this._txtCommonDate_3.CheckDateRange = false;
			this._txtCommonDate_3.Location = new System.Drawing.Point(122, 41);
			// this._txtCommonDate_3.MaxDate = 2958465;
			// this._txtCommonDate_3.MinDate = 2;
			this._txtCommonDate_3.Name = "_txtCommonDate_3";
			this._txtCommonDate_3.Size = new System.Drawing.Size(101, 19);
			this._txtCommonDate_3.TabIndex = 2;
			this._txtCommonDate_3.Text = "12/03/2004";
			// this._txtCommonDate_3.Value = 38058;
			// 
			// _txtCommonDisplay_1
			// 
			//this._txtCommonDisplay_1.AllowDrop = true;
			this._txtCommonDisplay_1.Location = new System.Drawing.Point(225, 20);
			this._txtCommonDisplay_1.Name = "_txtCommonDisplay_1";
			this._txtCommonDisplay_1.Size = new System.Drawing.Size(201, 19);
			this._txtCommonDisplay_1.TabIndex = 21;
			// 
			// _fraCommon_0
			// 
			//this._fraCommon_0.AllowDrop = true;
			this._fraCommon_0.BackColor = System.Drawing.Color.FromArgb(224, 230, 237);
			this._fraCommon_0.Controls.Add(this._lblCommon_1);
			this._fraCommon_0.Controls.Add(this._txtCommon_1);
			this._fraCommon_0.Controls.Add(this._txtCommon_0);
			this._fraCommon_0.Controls.Add(this._lblCommon_0);
			this._fraCommon_0.Controls.Add(this._lblCommon_5);
			this._fraCommon_0.Controls.Add(this._lblCommon_6);
			this._fraCommon_0.Controls.Add(this._lblCommon_4);
			this._fraCommon_0.Controls.Add(this._txtCommonDate_0);
			this._fraCommon_0.Controls.Add(this._lblCommon_8);
			this._fraCommon_0.Controls.Add(this._lblCommon_9);
			this._fraCommon_0.Controls.Add(this._lblCommon_7);
			this._fraCommon_0.Controls.Add(this._txtCommonDate_1);
			this._fraCommon_0.Controls.Add(this._txtCommonDate_2);
			this._fraCommon_0.Controls.Add(this._txtCommonDisplay_0);
			this._fraCommon_0.Controls.Add(this._txtCommonDisplay_7);
			this._fraCommon_0.Controls.Add(this._txtCommonDisplay_6);
			this._fraCommon_0.Controls.Add(this._txtCommonDisplay_5);
			this._fraCommon_0.Controls.Add(this._txtCommonDisplay_3);
			this._fraCommon_0.Controls.Add(this._txtCommonDisplay_4);
			this._fraCommon_0.Enabled = true;
			this._fraCommon_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Italic | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 178);
			this._fraCommon_0.ForeColor = System.Drawing.SystemColors.ControlText;
			this._fraCommon_0.Location = new System.Drawing.Point(8, 48);
			this._fraCommon_0.Name = "_fraCommon_0";
			this._fraCommon_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._fraCommon_0.Size = new System.Drawing.Size(441, 155);
			this._fraCommon_0.TabIndex = 4;
			this._fraCommon_0.Text = "Contract Details  ";
			this._fraCommon_0.Visible = true;
			// 
			// _lblCommon_1
			// 
			//this._lblCommon_1.AllowDrop = true;
			this._lblCommon_1.BackColor = System.Drawing.Color.FromArgb(224, 230, 237);
			this._lblCommon_1.Text = "Current Status Code";
			this._lblCommon_1.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_1.Location = new System.Drawing.Point(8, 42);
			// // this._lblCommon_1.mLabelId = 1170;
			this._lblCommon_1.Name = "_lblCommon_1";
			this._lblCommon_1.Size = new System.Drawing.Size(95, 13);
			this._lblCommon_1.TabIndex = 5;
			// 
			// _txtCommon_1
			// 
			//this._txtCommon_1.AllowDrop = true;
			this._txtCommon_1.BackColor = System.Drawing.Color.FromArgb(239, 239, 239);
			// this._txtCommon_1.bolNumericOnly = true;
			this._txtCommon_1.Enabled = false;
			this._txtCommon_1.ForeColor = System.Drawing.Color.Black;
			this._txtCommon_1.Location = new System.Drawing.Point(122, 39);
			this._txtCommon_1.MaxLength = 15;
			this._txtCommon_1.Name = "_txtCommon_1";
			this._txtCommon_1.Size = new System.Drawing.Size(101, 19);
			this._txtCommon_1.TabIndex = 6;
			this._txtCommon_1.Text = "";
			// this.// = "";
			// this.//this._txtCommon_1.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(//this.txtCommon_DropButtonClick);
			// this._txtCommon_1.Leave += new System.EventHandler(this.txtCommon_Leave);
			// 
			// _txtCommon_0
			// 
			//this._txtCommon_0.AllowDrop = true;
			this._txtCommon_0.BackColor = System.Drawing.Color.White;
			this._txtCommon_0.ForeColor = System.Drawing.Color.Black;
			this._txtCommon_0.Location = new System.Drawing.Point(122, 18);
			this._txtCommon_0.MaxLength = 15;
			this._txtCommon_0.Name = "_txtCommon_0";
			// this._txtCommon_0.ShowButton = true;
			this._txtCommon_0.Size = new System.Drawing.Size(101, 19);
			this._txtCommon_0.TabIndex = 0;
			this._txtCommon_0.Text = "";
			// this.// = "";
			// this.//this._txtCommon_0.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(//this.txtCommon_DropButtonClick);
			// this._txtCommon_0.Leave += new System.EventHandler(this.txtCommon_Leave);
			// 
			// _lblCommon_0
			// 
			//this._lblCommon_0.AllowDrop = true;
			this._lblCommon_0.BackColor = System.Drawing.Color.FromArgb(224, 230, 237);
			this._lblCommon_0.Text = "Contract No";
			this._lblCommon_0.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_0.Location = new System.Drawing.Point(8, 21);
			// // this._lblCommon_0.mLabelId = 1155;
			this._lblCommon_0.Name = "_lblCommon_0";
			this._lblCommon_0.Size = new System.Drawing.Size(57, 13);
			this._lblCommon_0.TabIndex = 7;
			// 
			// _lblCommon_5
			// 
			//this._lblCommon_5.AllowDrop = true;
			this._lblCommon_5.BackColor = System.Drawing.Color.FromArgb(224, 230, 237);
			this._lblCommon_5.Text = "Tenant Code";
			this._lblCommon_5.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_5.Location = new System.Drawing.Point(8, 105);
			// // this._lblCommon_5.mLabelId = 1156;
			this._lblCommon_5.Name = "_lblCommon_5";
			this._lblCommon_5.Size = new System.Drawing.Size(62, 13);
			this._lblCommon_5.TabIndex = 8;
			// 
			// _lblCommon_6
			// 
			//this._lblCommon_6.AllowDrop = true;
			this._lblCommon_6.BackColor = System.Drawing.Color.FromArgb(224, 230, 237);
			this._lblCommon_6.Text = "Pay. Method Code";
			this._lblCommon_6.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_6.Location = new System.Drawing.Point(8, 126);
			// // this._lblCommon_6.mLabelId = 1157;
			this._lblCommon_6.Name = "_lblCommon_6";
			this._lblCommon_6.Size = new System.Drawing.Size(88, 13);
			this._lblCommon_6.TabIndex = 9;
			// 
			// _lblCommon_4
			// 
			//this._lblCommon_4.AllowDrop = true;
			this._lblCommon_4.BackColor = System.Drawing.Color.FromArgb(224, 230, 237);
			this._lblCommon_4.Text = "Contract Amount";
			this._lblCommon_4.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_4.Location = new System.Drawing.Point(8, 63);
			// // this._lblCommon_4.mLabelId = 1172;
			this._lblCommon_4.Name = "_lblCommon_4";
			this._lblCommon_4.Size = new System.Drawing.Size(79, 13);
			this._lblCommon_4.TabIndex = 10;
			// 
			// _txtCommonDate_0
			// 
			//this._txtCommonDate_0.AllowDrop = true;
			this._txtCommonDate_0.BackColor = System.Drawing.Color.FromArgb(239, 239, 239);
			// this._txtCommonDate_0.CheckDateRange = false;
			this._txtCommonDate_0.Enabled = false;
			this._txtCommonDate_0.Location = new System.Drawing.Point(122, 81);
			// this._txtCommonDate_0.MaxDate = 2958465;
			// this._txtCommonDate_0.MinDate = 2;
			this._txtCommonDate_0.Name = "_txtCommonDate_0";
			this._txtCommonDate_0.Size = new System.Drawing.Size(101, 19);
			this._txtCommonDate_0.TabIndex = 11;
			this._txtCommonDate_0.Text = "12/03/2004";
			// this._txtCommonDate_0.Value = 38058;
			// 
			// _lblCommon_8
			// 
			//this._lblCommon_8.AllowDrop = true;
			this._lblCommon_8.BackColor = System.Drawing.Color.FromArgb(224, 230, 237);
			this._lblCommon_8.Text = "Signed Date";
			this._lblCommon_8.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_8.Location = new System.Drawing.Point(248, 63);
			// // this._lblCommon_8.mLabelId = 1162;
			this._lblCommon_8.Name = "_lblCommon_8";
			this._lblCommon_8.Size = new System.Drawing.Size(59, 13);
			this._lblCommon_8.TabIndex = 12;
			// 
			// _lblCommon_9
			// 
			//this._lblCommon_9.AllowDrop = true;
			this._lblCommon_9.BackColor = System.Drawing.Color.FromArgb(224, 230, 237);
			this._lblCommon_9.Text = "Ending Date";
			this._lblCommon_9.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_9.Location = new System.Drawing.Point(248, 84);
			// // this._lblCommon_9.mLabelId = 1161;
			this._lblCommon_9.Name = "_lblCommon_9";
			this._lblCommon_9.Size = new System.Drawing.Size(59, 13);
			this._lblCommon_9.TabIndex = 13;
			// 
			// _lblCommon_7
			// 
			//this._lblCommon_7.AllowDrop = true;
			this._lblCommon_7.BackColor = System.Drawing.Color.FromArgb(224, 230, 237);
			this._lblCommon_7.Text = "Starting Date";
			this._lblCommon_7.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_7.Location = new System.Drawing.Point(8, 84);
			// // this._lblCommon_7.mLabelId = 1160;
			this._lblCommon_7.Name = "_lblCommon_7";
			this._lblCommon_7.Size = new System.Drawing.Size(62, 13);
			this._lblCommon_7.TabIndex = 14;
			// 
			// _txtCommonDate_1
			// 
			//this._txtCommonDate_1.AllowDrop = true;
			this._txtCommonDate_1.BackColor = System.Drawing.Color.FromArgb(239, 239, 239);
			// this._txtCommonDate_1.CheckDateRange = false;
			this._txtCommonDate_1.Enabled = false;
			this._txtCommonDate_1.Location = new System.Drawing.Point(325, 81);
			// this._txtCommonDate_1.MaxDate = 2958465;
			// this._txtCommonDate_1.MinDate = 2;
			this._txtCommonDate_1.Name = "_txtCommonDate_1";
			this._txtCommonDate_1.Size = new System.Drawing.Size(101, 19);
			this._txtCommonDate_1.TabIndex = 15;
			this._txtCommonDate_1.Text = "12/03/2004";
			// this._txtCommonDate_1.Value = 38058;
			// 
			// _txtCommonDate_2
			// 
			//this._txtCommonDate_2.AllowDrop = true;
			this._txtCommonDate_2.BackColor = System.Drawing.Color.FromArgb(239, 239, 239);
			// this._txtCommonDate_2.CheckDateRange = false;
			this._txtCommonDate_2.Enabled = false;
			this._txtCommonDate_2.Location = new System.Drawing.Point(325, 60);
			// this._txtCommonDate_2.MaxDate = 2958465;
			// this._txtCommonDate_2.MinDate = 2;
			this._txtCommonDate_2.Name = "_txtCommonDate_2";
			this._txtCommonDate_2.Size = new System.Drawing.Size(101, 19);
			this._txtCommonDate_2.TabIndex = 16;
			this._txtCommonDate_2.Text = "12/03/2004";
			// this._txtCommonDate_2.Value = 38058;
			// 
			// _txtCommonDisplay_0
			// 
			//this._txtCommonDisplay_0.AllowDrop = true;
			this._txtCommonDisplay_0.Location = new System.Drawing.Point(225, 39);
			this._txtCommonDisplay_0.Name = "_txtCommonDisplay_0";
			this._txtCommonDisplay_0.Size = new System.Drawing.Size(201, 19);
			this._txtCommonDisplay_0.TabIndex = 22;
			// 
			// _txtCommonDisplay_7
			// 
			//this._txtCommonDisplay_7.AllowDrop = true;
			this._txtCommonDisplay_7.Location = new System.Drawing.Point(122, 102);
			this._txtCommonDisplay_7.Name = "_txtCommonDisplay_7";
			this._txtCommonDisplay_7.Size = new System.Drawing.Size(101, 19);
			this._txtCommonDisplay_7.TabIndex = 23;
			// 
			// _txtCommonDisplay_6
			// 
			//this._txtCommonDisplay_6.AllowDrop = true;
			this._txtCommonDisplay_6.Location = new System.Drawing.Point(225, 102);
			this._txtCommonDisplay_6.Name = "_txtCommonDisplay_6";
			this._txtCommonDisplay_6.Size = new System.Drawing.Size(201, 19);
			this._txtCommonDisplay_6.TabIndex = 24;
			// 
			// _txtCommonDisplay_5
			// 
			//this._txtCommonDisplay_5.AllowDrop = true;
			this._txtCommonDisplay_5.Location = new System.Drawing.Point(122, 123);
			this._txtCommonDisplay_5.Name = "_txtCommonDisplay_5";
			this._txtCommonDisplay_5.Size = new System.Drawing.Size(101, 19);
			this._txtCommonDisplay_5.TabIndex = 25;
			// 
			// _txtCommonDisplay_3
			// 
			//this._txtCommonDisplay_3.AllowDrop = true;
			this._txtCommonDisplay_3.Location = new System.Drawing.Point(225, 123);
			this._txtCommonDisplay_3.Name = "_txtCommonDisplay_3";
			this._txtCommonDisplay_3.Size = new System.Drawing.Size(201, 19);
			this._txtCommonDisplay_3.TabIndex = 26;
			// 
			// _txtCommonDisplay_4
			// 
			// //this._txtCommonDisplay_4.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
			//this._txtCommonDisplay_4.AllowDrop = true;
			this._txtCommonDisplay_4.Location = new System.Drawing.Point(122, 60);
			this._txtCommonDisplay_4.Name = "_txtCommonDisplay_4";
			this._txtCommonDisplay_4.Size = new System.Drawing.Size(101, 19);
			this._txtCommonDisplay_4.TabIndex = 27;
			// 
			// frmREContractStatus
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.FromArgb(224, 230, 237);
			this.ClientSize = new System.Drawing.Size(458, 329);
			this.Controls.Add(this._fraCommon_1);
			this.Controls.Add(this._fraCommon_0);
			//this.Icon = (System.Drawing.Icon) resources.GetObject("frmREContractStatus.Icon");
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(56, 150);
			this.MaximizeBox = true;
			this.MinimizeBox = true;
			this.Name = "frmREContractStatus";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Contract Status";
			// this.Activated += new System.EventHandler(this.frmREContractStatus_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
			// this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
			this._fraCommon_1.ResumeLayout(false);
			this._fraCommon_0.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		// 
		void InitializetxtCommonDisplay()
		{
			this.txtCommonDisplay = new System.Windows.Forms.Label[8];
			this.txtCommonDisplay[1] = _txtCommonDisplay_1;
			this.txtCommonDisplay[0] = _txtCommonDisplay_0;
			this.txtCommonDisplay[7] = _txtCommonDisplay_7;
			this.txtCommonDisplay[6] = _txtCommonDisplay_6;
			this.txtCommonDisplay[5] = _txtCommonDisplay_5;
			this.txtCommonDisplay[3] = _txtCommonDisplay_3;
			this.txtCommonDisplay[4] = _txtCommonDisplay_4;
		}
		void InitializetxtCommonDate()
		{
			this.txtCommonDate = new Syncfusion.WinForms.Input.SfDateTimeEdit[4];
			this.txtCommonDate[3] = _txtCommonDate_3;
			this.txtCommonDate[0] = _txtCommonDate_0;
			this.txtCommonDate[1] = _txtCommonDate_1;
			this.txtCommonDate[2] = _txtCommonDate_2;
		}
		void InitializetxtCommon()
		{
			this.txtCommon = new System.Windows.Forms.TextBox[3];
			this.txtCommon[2] = _txtCommon_2;
			this.txtCommon[1] = _txtCommon_1;
			this.txtCommon[0] = _txtCommon_0;
		}
		void InitializelblCommon()
		{
			this.lblCommon = new System.Windows.Forms.Label[11];
			this.lblCommon[2] = _lblCommon_2;
			this.lblCommon[3] = _lblCommon_3;
			this.lblCommon[10] = _lblCommon_10;
			this.lblCommon[1] = _lblCommon_1;
			this.lblCommon[0] = _lblCommon_0;
			this.lblCommon[5] = _lblCommon_5;
			this.lblCommon[6] = _lblCommon_6;
			this.lblCommon[4] = _lblCommon_4;
			this.lblCommon[8] = _lblCommon_8;
			this.lblCommon[9] = _lblCommon_9;
			this.lblCommon[7] = _lblCommon_7;
		}
		void InitializefraCommon()
		{
			this.fraCommon = new System.Windows.Forms.GroupBox[2];
			this.fraCommon[1] = _fraCommon_1;
			this.fraCommon[0] = _fraCommon_0;
		}
		#endregion
	}
}//ENDSHERE
