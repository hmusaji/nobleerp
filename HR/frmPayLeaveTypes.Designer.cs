
namespace Xtreme
{
	partial class frmPayLeaveTypes
	{

		#region "Upgrade Support "
		private static frmPayLeaveTypes m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmPayLeaveTypes DefInstance
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
		public static frmPayLeaveTypes CreateInstance()
		{
			frmPayLeaveTypes theInstance = new frmPayLeaveTypes();
			
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
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "_btnFormToolBar_0", "_btnFormToolBar_1", "_btnFormToolBar_5", "_btnFormToolBar_2", "_btnFormToolBar_3", "_btnFormToolBar_6", "_btnFormToolBar_4", "picFormToolbar", "System.Windows.Forms.TextBox2", "System.Windows.Forms.TextBox1", "System.Windows.Forms.ComboBox1", "txtComment", "txtGradeNo", "lblLNatName", "txtLGradeName", "lblANatName", "txtAGradeName", "lblComments", "lblNatNo", "System.Windows.Forms.Label3", "System.Windows.Forms.Label4", "System.Windows.Forms.Label5", "System.Windows.Forms.Label6", "System.Windows.Forms.Label7", "System.Windows.Forms.Label8", "System.Windows.Forms.Label9", "System.Windows.Forms.TextBox1", "System.Windows.Forms.TextBox3", "System.Windows.Forms.TextBox4", "System.Windows.Forms.TextBox5", "cntMainParameter", "btnFormToolBar"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		private AxSmartNetButtonProject.AxSmartNetButton _btnFormToolBar_0;
		private AxSmartNetButtonProject.AxSmartNetButton _btnFormToolBar_1;
		private AxSmartNetButtonProject.AxSmartNetButton _btnFormToolBar_5;
		private AxSmartNetButtonProject.AxSmartNetButton _btnFormToolBar_2;
		private AxSmartNetButtonProject.AxSmartNetButton _btnFormToolBar_3;
		private AxSmartNetButtonProject.AxSmartNetButton _btnFormToolBar_6;
		private AxSmartNetButtonProject.AxSmartNetButton _btnFormToolBar_4;
		public System.Windows.Forms.PictureBox picFormToolbar;
		public System.Windows.Forms.TextBox System.Windows.Forms.TextBox2;
		public System.Windows.Forms.TextBox System.Windows.Forms.TextBox1;
		public System.Windows.Forms.ComboBox System.Windows.Forms.ComboBox1;
		public System.Windows.Forms.TextBox txtComment;
		public System.Windows.Forms.TextBox txtGradeNo;
		public System.Windows.Forms.Label lblLNatName;
		public System.Windows.Forms.TextBox txtLGradeName;
		public System.Windows.Forms.Label lblANatName;
		public System.Windows.Forms.TextBox txtAGradeName;
		public System.Windows.Forms.Label lblComments;
		public System.Windows.Forms.Label lblNatNo;
		public System.Windows.Forms.Label Label3;
		public System.Windows.Forms.Label Label4;
		public System.Windows.Forms.Label Label5;
		public System.Windows.Forms.Label Label6;
		public System.Windows.Forms.Label Label7;
		public System.Windows.Forms.Label Label8;
		public System.Windows.Forms.Label Label9;
		public System.Windows.Forms.TextBox System.Windows.Forms.TextBox1;
		public System.Windows.Forms.TextBox System.Windows.Forms.TextBox3;
		public System.Windows.Forms.TextBox System.Windows.Forms.TextBox4;
		public System.Windows.Forms.TextBox System.Windows.Forms.TextBox5;
		public AxTDBContainer3D6.AxTDBContainer3D cntMainParameter;
		public AxSmartNetButtonProject.AxSmartNetButton[] btnFormToolBar = new AxSmartNetButtonProject.AxSmartNetButton[7];
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPayLeaveTypes));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this.picFormToolbar = new System.Windows.Forms.PictureBox();
			this._btnFormToolBar_0 = new AxSmartNetButtonProject.AxSmartNetButton();
			this._btnFormToolBar_1 = new AxSmartNetButtonProject.AxSmartNetButton();
			this._btnFormToolBar_5 = new AxSmartNetButtonProject.AxSmartNetButton();
			this._btnFormToolBar_2 = new AxSmartNetButtonProject.AxSmartNetButton();
			this._btnFormToolBar_3 = new AxSmartNetButtonProject.AxSmartNetButton();
			this._btnFormToolBar_6 = new AxSmartNetButtonProject.AxSmartNetButton();
			this._btnFormToolBar_4 = new AxSmartNetButtonProject.AxSmartNetButton();
			this.cntMainParameter = new AxTDBContainer3D6.AxTDBContainer3D();
			this.TextBox2 = new System.Windows.Forms.TextBox();
			this.TextBox1 = new System.Windows.Forms.TextBox();
			this.ComboBox1 = new System.Windows.Forms.ComboBox();
			this.txtComment = new System.Windows.Forms.TextBox();
			this.txtGradeNo = new System.Windows.Forms.TextBox();
			this.lblLNatName = new System.Windows.Forms.Label();
			this.txtLGradeName = new System.Windows.Forms.TextBox();
			this.lblANatName = new System.Windows.Forms.Label();
			this.txtAGradeName = new System.Windows.Forms.TextBox();
			this.lblComments = new System.Windows.Forms.Label();
			this.lblNatNo = new System.Windows.Forms.Label();
			this.Label3 = new System.Windows.Forms.Label();
			this.Label4 = new System.Windows.Forms.Label();
			this.Label5 = new System.Windows.Forms.Label();
			this.Label6 = new System.Windows.Forms.Label();
			this.Label7 = new System.Windows.Forms.Label();
			this.Label8 = new System.Windows.Forms.Label();
			this.Label9 = new System.Windows.Forms.Label();
			this.TextBox1 = new System.Windows.Forms.TextBox();
			this.TextBox3 = new System.Windows.Forms.TextBox();
			this.TextBox4 = new System.Windows.Forms.TextBox();
			this.TextBox5 = new System.Windows.Forms.TextBox();
			// //((System.ComponentModel.ISupportInitialize) this._btnFormToolBar_0).BeginInit();
			// //((System.ComponentModel.ISupportInitialize) this._btnFormToolBar_1).BeginInit();
			// //((System.ComponentModel.ISupportInitialize) this._btnFormToolBar_5).BeginInit();
			// //((System.ComponentModel.ISupportInitialize) this._btnFormToolBar_2).BeginInit();
			// //((System.ComponentModel.ISupportInitialize) this._btnFormToolBar_3).BeginInit();
			// //((System.ComponentModel.ISupportInitialize) this._btnFormToolBar_6).BeginInit();
			// //((System.ComponentModel.ISupportInitialize) this._btnFormToolBar_4).BeginInit();
			// //((System.ComponentModel.ISupportInitialize) this.cntMainParameter).BeginInit();
			this.picFormToolbar.SuspendLayout();
			this.cntMainParameter.SuspendLayout();
			this.SuspendLayout();
			// 
			// picFormToolbar
			// 
			this.picFormToolbar.AllowDrop = true;
			this.picFormToolbar.BackColor = System.Drawing.SystemColors.Control;
			this.picFormToolbar.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.picFormToolbar.CausesValidation = true;
			this.picFormToolbar.Controls.Add(this._btnFormToolBar_0);
			this.picFormToolbar.Controls.Add(this._btnFormToolBar_1);
			this.picFormToolbar.Controls.Add(this._btnFormToolBar_5);
			this.picFormToolbar.Controls.Add(this._btnFormToolBar_2);
			this.picFormToolbar.Controls.Add(this._btnFormToolBar_3);
			this.picFormToolbar.Controls.Add(this._btnFormToolBar_6);
			this.picFormToolbar.Controls.Add(this._btnFormToolBar_4);
			this.picFormToolbar.Dock = System.Windows.Forms.DockStyle.Top;
			this.picFormToolbar.Enabled = true;
			this.picFormToolbar.Location = new System.Drawing.Point(0, 0);
			this.picFormToolbar.Name = "picFormToolbar";
			this.picFormToolbar.Size = new System.Drawing.Size(527, 38);
			this.picFormToolbar.TabIndex = 4;
			this.picFormToolbar.TabStop = false;
			this.picFormToolbar.Visible = true;
			// 
			// _btnFormToolBar_0
			// 
			this._btnFormToolBar_0.AllowDrop = true;
			this._btnFormToolBar_0.Location = new System.Drawing.Point(2, 2);
			this._btnFormToolBar_0.Name = "_btnFormToolBar_0";
			("_btnFormToolBar_0.OcxState");
			this._btnFormToolBar_0.Size = new System.Drawing.Size(51, 34);
			this._btnFormToolBar_0.TabIndex = 5;
			this._btnFormToolBar_0.TabStop = false;
			this._btnFormToolBar_0.Tag = "New";
			//// this._btnFormToolBar_0.ClickEvent += new System.EventHandler(this.btnFormToolBar_ClickEvent);
			// 
			// _btnFormToolBar_1
			// 
			this._btnFormToolBar_1.AllowDrop = true;
			this._btnFormToolBar_1.Location = new System.Drawing.Point(53, 2);
			this._btnFormToolBar_1.Name = "_btnFormToolBar_1";
			("_btnFormToolBar_1.OcxState");
			this._btnFormToolBar_1.Size = new System.Drawing.Size(51, 34);
			this._btnFormToolBar_1.TabIndex = 6;
			this._btnFormToolBar_1.TabStop = false;
			this._btnFormToolBar_1.Tag = "Save";
			//// this._btnFormToolBar_1.ClickEvent += new System.EventHandler(this.btnFormToolBar_ClickEvent);
			// 
			// _btnFormToolBar_5
			// 
			this._btnFormToolBar_5.AllowDrop = true;
			this._btnFormToolBar_5.Location = new System.Drawing.Point(257, 2);
			this._btnFormToolBar_5.Name = "_btnFormToolBar_5";
			("_btnFormToolBar_5.OcxState");
			this._btnFormToolBar_5.Size = new System.Drawing.Size(51, 34);
			this._btnFormToolBar_5.TabIndex = 7;
			this._btnFormToolBar_5.TabStop = false;
			this._btnFormToolBar_5.Tag = "Help";
			//// this._btnFormToolBar_5.ClickEvent += new System.EventHandler(this.btnFormToolBar_ClickEvent);
			// 
			// _btnFormToolBar_2
			// 
			this._btnFormToolBar_2.AllowDrop = true;
			this._btnFormToolBar_2.Location = new System.Drawing.Point(104, 2);
			this._btnFormToolBar_2.Name = "_btnFormToolBar_2";
			("_btnFormToolBar_2.OcxState");
			this._btnFormToolBar_2.Size = new System.Drawing.Size(51, 34);
			this._btnFormToolBar_2.TabIndex = 8;
			this._btnFormToolBar_2.TabStop = false;
			this._btnFormToolBar_2.Tag = "Delete";
			//// this._btnFormToolBar_2.ClickEvent += new System.EventHandler(this.btnFormToolBar_ClickEvent);
			// 
			// _btnFormToolBar_3
			// 
			this._btnFormToolBar_3.AllowDrop = true;
			this._btnFormToolBar_3.Location = new System.Drawing.Point(155, 2);
			this._btnFormToolBar_3.Name = "_btnFormToolBar_3";
			("_btnFormToolBar_3.OcxState");
			this._btnFormToolBar_3.Size = new System.Drawing.Size(51, 34);
			this._btnFormToolBar_3.TabIndex = 9;
			this._btnFormToolBar_3.TabStop = false;
			this._btnFormToolBar_3.Tag = "Print";
			//// this._btnFormToolBar_3.ClickEvent += new System.EventHandler(this.btnFormToolBar_ClickEvent);
			// 
			// _btnFormToolBar_6
			// 
			this._btnFormToolBar_6.AllowDrop = true;
			this._btnFormToolBar_6.Location = new System.Drawing.Point(320, 2);
			this._btnFormToolBar_6.Name = "_btnFormToolBar_6";
			("_btnFormToolBar_6.OcxState");
			this._btnFormToolBar_6.Size = new System.Drawing.Size(51, 34);
			this._btnFormToolBar_6.TabIndex = 10;
			this._btnFormToolBar_6.TabStop = false;
			this._btnFormToolBar_6.Tag = "Exit";
			//// this._btnFormToolBar_6.ClickEvent += new System.EventHandler(this.btnFormToolBar_ClickEvent);
			// 
			// _btnFormToolBar_4
			// 
			this._btnFormToolBar_4.AllowDrop = true;
			this._btnFormToolBar_4.Location = new System.Drawing.Point(206, 2);
			this._btnFormToolBar_4.Name = "_btnFormToolBar_4";
			("_btnFormToolBar_4.OcxState");
			this._btnFormToolBar_4.Size = new System.Drawing.Size(51, 34);
			this._btnFormToolBar_4.TabIndex = 11;
			this._btnFormToolBar_4.TabStop = false;
			this._btnFormToolBar_4.Tag = "Find";
			//// this._btnFormToolBar_4.ClickEvent += new System.EventHandler(this.btnFormToolBar_ClickEvent);
			// 
			// cntMainParameter
			// 
			this.cntMainParameter.AllowDrop = true;
			this.cntMainParameter.Controls.Add(this.TextBox2);
			this.cntMainParameter.Controls.Add(this.TextBox1);
			this.cntMainParameter.Controls.Add(this.ComboBox1);
			this.cntMainParameter.Controls.Add(this.txtComment);
			this.cntMainParameter.Controls.Add(this.txtGradeNo);
			this.cntMainParameter.Controls.Add(this.lblLNatName);
			this.cntMainParameter.Controls.Add(this.txtLGradeName);
			this.cntMainParameter.Controls.Add(this.lblANatName);
			this.cntMainParameter.Controls.Add(this.txtAGradeName);
			this.cntMainParameter.Controls.Add(this.lblComments);
			this.cntMainParameter.Controls.Add(this.lblNatNo);
			this.cntMainParameter.Controls.Add(this.Label3);
			this.cntMainParameter.Controls.Add(this.Label4);
			this.cntMainParameter.Controls.Add(this.Label5);
			this.cntMainParameter.Controls.Add(this.Label6);
			this.cntMainParameter.Controls.Add(this.Label7);
			this.cntMainParameter.Controls.Add(this.Label8);
			this.cntMainParameter.Controls.Add(this.Label9);
			this.cntMainParameter.Controls.Add(this.TextBox1);
			this.cntMainParameter.Controls.Add(this.TextBox3);
			this.cntMainParameter.Controls.Add(this.TextBox4);
			this.cntMainParameter.Controls.Add(this.TextBox5);
			this.cntMainParameter.Location = new System.Drawing.Point(4, 44);
			this.cntMainParameter.Name = "cntMainParameter";
			("cntMainParameter.OcxState");
			this.cntMainParameter.Size = new System.Drawing.Size(509, 281);
			this.cntMainParameter.TabIndex = 12;
			// 
			// System.Windows.Forms.TextBox2
			// 
			this.TextBox2.AllowDrop = true;
			this.TextBox2.BackColor = System.Drawing.Color.White;
			this.TextBox2.bolAllowDecimal = false;
			this.TextBox2.Location = new System.Drawing.Point(136, 164);
			this.TextBox2.mDropDownType = (System.Windows.Forms.TextBox.DropDownTypes) 0;
			this.TextBox2.Name = "System.Windows.Forms.TextBox2";
			this.TextBox2.Size = new System.Drawing.Size(101, 19);
			this.TextBox2.TabIndex = 30;
			this.TextBox2.Text = "";
			// 
			// System.Windows.Forms.TextBox1
			// 
			this.TextBox1.AllowDrop = true;
			this.TextBox1.Location = new System.Drawing.Point(150, 110);
			this.TextBox1.MaxValue = 2147483647;
			this.TextBox1.MinValue = 0;
			this.TextBox1.Name = "System.Windows.Forms.TextBox1";
			this.TextBox1.Size = new System.Drawing.Size(107, 19);
			this.TextBox1.TabIndex = 26;
			// 
			// System.Windows.Forms.ComboBox1
			// 
			this.ComboBox1.AllowDrop = true;
			this.ComboBox1.Location = new System.Drawing.Point(146, 78);
			this.ComboBox1.Name = "System.Windows.Forms.ComboBox1";
			this.ComboBox1.Size = new System.Drawing.Size(115, 21);
			this.ComboBox1.TabIndex = 24;
			// 
			// txtComment
			// 
			this.txtComment.AcceptsReturn = true;
			this.txtComment.AllowDrop = true;
			this.txtComment.BackColor = System.Drawing.SystemColors.Window;
			this.txtComment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtComment.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtComment.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtComment.Location = new System.Drawing.Point(146, 196);
			this.txtComment.MaxLength = 100;
			this.txtComment.Multiline = true;
			this.txtComment.Name = "txtComment";
			this.txtComment.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtComment.Size = new System.Drawing.Size(304, 59);
			this.txtComment.TabIndex = 3;
			// 
			// txtGradeNo
			// 
			this.txtGradeNo.AllowDrop = true;
			this.txtGradeNo.BackColor = System.Drawing.Color.White;
			// this.txtGradeNo.bolNumericOnly = true;
			this.txtGradeNo.Location = new System.Drawing.Point(146, 12);
			this.txtGradeNo.MaxLength = 15;
			// this.txtGradeNo.mDropDownType = System.Windows.Forms.TextBox.DropDownTypes.ddtNextNumber;
			this.txtGradeNo.Name = "txtGradeNo";
			// this.txtGradeNo.ShowButton = true;
			this.txtGradeNo.Size = new System.Drawing.Size(101, 19);
			this.txtGradeNo.TabIndex = 0;
			this.txtGradeNo.Text = "";
			// this.this.txtGradeNo.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtGradeNo_DropButtonClick);
			// 
			// lblLNatName
			// 
			this.lblLNatName.AllowDrop = true;
			this.lblLNatName.BackColor = System.Drawing.Color.FromArgb(237, 231, 235);
			this.lblLNatName.Text = "Grade Name (English)";
			this.lblLNatName.Location = new System.Drawing.Point(8, 35);
			this.lblLNatName.Name = "lblLNatName";
			this.lblLNatName.Size = new System.Drawing.Size(105, 14);
			this.lblLNatName.TabIndex = 13;
			// 
			// txtLGradeName
			// 
			this.txtLGradeName.AllowDrop = true;
			this.txtLGradeName.BackColor = System.Drawing.Color.White;
			this.txtLGradeName.Location = new System.Drawing.Point(146, 33);
			this.txtLGradeName.MaxLength = 50;
			this.txtLGradeName.Name = "txtLGradeName";
			this.txtLGradeName.Size = new System.Drawing.Size(201, 19);
			this.txtLGradeName.TabIndex = 1;
			this.txtLGradeName.Text = "";
			// 
			// lblANatName
			// 
			this.lblANatName.AllowDrop = true;
			this.lblANatName.BackColor = System.Drawing.Color.FromArgb(237, 231, 235);
			this.lblANatName.Text = "Grade Name (Arabic)";
			this.lblANatName.Location = new System.Drawing.Point(8, 56);
			this.lblANatName.Name = "lblANatName";
			this.lblANatName.Size = new System.Drawing.Size(103, 14);
			this.lblANatName.TabIndex = 14;
			// 
			// txtAGradeName
			// 
			this.txtAGradeName.AllowDrop = true;
			this.txtAGradeName.BackColor = System.Drawing.Color.White;
			this.txtAGradeName.Location = new System.Drawing.Point(146, 54);
			// this.txtAGradeName.mArabicEnabled = true;
			this.txtAGradeName.MaxLength = 50;
			this.txtAGradeName.Name = "txtAGradeName";
			this.txtAGradeName.Size = new System.Drawing.Size(201, 19);
			this.txtAGradeName.TabIndex = 2;
			this.txtAGradeName.Text = "";
			// 
			// lblComments
			// 
			this.lblComments.AllowDrop = true;
			this.lblComments.BackColor = System.Drawing.Color.FromArgb(237, 231, 235);
			this.lblComments.Text = "Comment";
			this.lblComments.Location = new System.Drawing.Point(8, 196);
			this.lblComments.Name = "lblComments";
			this.lblComments.Size = new System.Drawing.Size(44, 14);
			this.lblComments.TabIndex = 15;
			// 
			// lblNatNo
			// 
			this.lblNatNo.AllowDrop = true;
			this.lblNatNo.BackColor = System.Drawing.Color.FromArgb(237, 231, 235);
			this.lblNatNo.Text = "Grade Code";
			this.lblNatNo.Location = new System.Drawing.Point(8, 14);
			this.lblNatNo.Name = "lblNatNo";
			this.lblNatNo.Size = new System.Drawing.Size(58, 14);
			this.lblNatNo.TabIndex = 16;
			// 
			// System.Windows.Forms.Label3
			// 
			this.Label3.AllowDrop = true;
			this.Label3.BackColor = System.Drawing.Color.FromArgb(237, 231, 235);
			this.Label3.Text = "Grade Name (Arabic)";
			this.Label3.Location = new System.Drawing.Point(272, 172);
			this.Label3.Name = "System.Windows.Forms.Label3";
			this.Label3.Size = new System.Drawing.Size(103, 14);
			this.Label3.TabIndex = 17;
			// 
			// System.Windows.Forms.Label4
			// 
			this.Label4.AllowDrop = true;
			this.Label4.BackColor = System.Drawing.Color.FromArgb(237, 231, 235);
			this.Label4.Text = "Grade Name (Arabic)";
			this.Label4.Location = new System.Drawing.Point(14, 164);
			this.Label4.Name = "System.Windows.Forms.Label4";
			this.Label4.Size = new System.Drawing.Size(103, 14);
			this.Label4.TabIndex = 18;
			// 
			// System.Windows.Forms.Label5
			// 
			this.Label5.AllowDrop = true;
			this.Label5.BackColor = System.Drawing.Color.FromArgb(237, 231, 235);
			this.Label5.Text = "Grade Name (Arabic)";
			this.Label5.Location = new System.Drawing.Point(268, 142);
			this.Label5.Name = "System.Windows.Forms.Label5";
			this.Label5.Size = new System.Drawing.Size(103, 14);
			this.Label5.TabIndex = 19;
			// 
			// System.Windows.Forms.Label6
			// 
			this.Label6.AllowDrop = true;
			this.Label6.BackColor = System.Drawing.Color.FromArgb(237, 231, 235);
			this.Label6.Text = "Grade Name (Arabic)";
			this.Label6.Location = new System.Drawing.Point(266, 82);
			this.Label6.Name = "System.Windows.Forms.Label6";
			this.Label6.Size = new System.Drawing.Size(103, 14);
			this.Label6.TabIndex = 20;
			// 
			// System.Windows.Forms.Label7
			// 
			this.Label7.AllowDrop = true;
			this.Label7.BackColor = System.Drawing.Color.FromArgb(237, 231, 235);
			this.Label7.Text = "Grade Name (Arabic)";
			this.Label7.Location = new System.Drawing.Point(262, 116);
			this.Label7.Name = "System.Windows.Forms.Label7";
			this.Label7.Size = new System.Drawing.Size(103, 14);
			this.Label7.TabIndex = 21;
			// 
			// System.Windows.Forms.Label8
			// 
			this.Label8.AllowDrop = true;
			this.Label8.BackColor = System.Drawing.Color.FromArgb(237, 231, 235);
			this.Label8.Text = "Grade Name (Arabic)";
			this.Label8.Location = new System.Drawing.Point(4, 138);
			this.Label8.Name = "System.Windows.Forms.Label8";
			this.Label8.Size = new System.Drawing.Size(103, 14);
			this.Label8.TabIndex = 22;
			// 
			// System.Windows.Forms.Label9
			// 
			this.Label9.AllowDrop = true;
			this.Label9.BackColor = System.Drawing.Color.FromArgb(237, 231, 235);
			this.Label9.Text = "Grade Name (Arabic)";
			this.Label9.Location = new System.Drawing.Point(12, 114);
			this.Label9.Name = "System.Windows.Forms.Label9";
			this.Label9.Size = new System.Drawing.Size(103, 14);
			this.Label9.TabIndex = 23;
			// 
			// System.Windows.Forms.TextBox1
			// 
			this.TextBox1.AllowDrop = true;
			this.TextBox1.BackColor = System.Drawing.Color.White;
			this.TextBox1.Location = new System.Drawing.Point(382, 80);
			this.TextBox1.mArabicEnabled = true;
			this.TextBox1.MaxLength = 50;
			this.TextBox1.Name = "System.Windows.Forms.TextBox1";
			this.TextBox1.Size = new System.Drawing.Size(111, 19);
			this.TextBox1.TabIndex = 25;
			this.TextBox1.Text = "";
			// 
			// System.Windows.Forms.TextBox3
			// 
			this.TextBox3.AllowDrop = true;
			this.TextBox3.Location = new System.Drawing.Point(382, 138);
			this.TextBox3.MaxValue = 2147483647;
			this.TextBox3.MinValue = 0;
			this.TextBox3.Name = "System.Windows.Forms.TextBox3";
			this.TextBox3.Size = new System.Drawing.Size(107, 19);
			this.TextBox3.TabIndex = 27;
			// 
			// System.Windows.Forms.TextBox4
			// 
			this.TextBox4.AllowDrop = true;
			this.TextBox4.Location = new System.Drawing.Point(380, 112);
			this.TextBox4.MaxValue = 2147483647;
			this.TextBox4.MinValue = 0;
			this.TextBox4.Name = "System.Windows.Forms.TextBox4";
			this.TextBox4.Size = new System.Drawing.Size(107, 19);
			this.TextBox4.TabIndex = 28;
			// 
			// System.Windows.Forms.TextBox5
			// 
			this.TextBox5.AllowDrop = true;
			this.TextBox5.Location = new System.Drawing.Point(150, 134);
			this.TextBox5.MaxValue = 2147483647;
			this.TextBox5.MinValue = 0;
			this.TextBox5.Name = "System.Windows.Forms.TextBox5";
			this.TextBox5.Size = new System.Drawing.Size(107, 19);
			this.TextBox5.TabIndex = 29;
			// 
			// frmPayLeaveTypes
			// 
			this.'MaxButton = 0;
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.FromArgb(205, 184, 196);
			this.ClientSize = new System.Drawing.Size(527, 342);
			this.Controls.Add(this.picFormToolbar);
			this.Controls.Add(this.cntMainParameter);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			//this.Icon = (System.Drawing.Icon) resources.GetObject("frmPayLeaveTypes.Icon");
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(119, 177);
			this.MaximizeBox = true;
			this.MinimizeBox = true;
			this.Name = "frmPayLeaveTypes";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Leave Types";
			// this.Activated += new System.EventHandler(this.Form_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
			// this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
			//((System.ComponentModel.ISupportInitialize) this._btnFormToolBar_0).EndInit();
			//((System.ComponentModel.ISupportInitialize) this._btnFormToolBar_1).EndInit();
			//((System.ComponentModel.ISupportInitialize) this._btnFormToolBar_5).EndInit();
			//((System.ComponentModel.ISupportInitialize) this._btnFormToolBar_2).EndInit();
			//((System.ComponentModel.ISupportInitialize) this._btnFormToolBar_3).EndInit();
			//((System.ComponentModel.ISupportInitialize) this._btnFormToolBar_6).EndInit();
			//((System.ComponentModel.ISupportInitialize) this._btnFormToolBar_4).EndInit();
			//((System.ComponentModel.ISupportInitialize) this.cntMainParameter).EndInit();
			this.picFormToolbar.ResumeLayout(false);
			this.cntMainParameter.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		// 
		void InitializebtnFormToolBar()
		{
			this.btnFormToolBar = new AxSmartNetButtonProject.AxSmartNetButton[7];
			this.btnFormToolBar[0] = _btnFormToolBar_0;
			this.btnFormToolBar[1] = _btnFormToolBar_1;
			this.btnFormToolBar[5] = _btnFormToolBar_5;
			this.btnFormToolBar[2] = _btnFormToolBar_2;
			this.btnFormToolBar[3] = _btnFormToolBar_3;
			this.btnFormToolBar[6] = _btnFormToolBar_6;
			this.btnFormToolBar[4] = _btnFormToolBar_4;
		}
		#endregion
	}
}//ENDSHERE
