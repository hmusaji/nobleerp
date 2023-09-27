
namespace Xtreme
{
	partial class frmPayPassport
	{

		#region "Upgrade Support "
		private static frmPayPassport m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmPayPassport DefInstance
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
		public static frmPayPassport CreateInstance()
		{
			frmPayPassport theInstance = new frmPayPassport();
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
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "_btnFormToolBar_0", "_btnFormToolBar_1", "_btnFormToolBar_5", "_btnFormToolBar_2", "_btnFormToolBar_3", "_btnFormToolBar_6", "_btnFormToolBar_4", "_btnFormToolBar_7", "picFormToolbar", "_txtCommonTextBox_2", "_lblCommonLabel_7", "_lblCommonLabel_5", "_lblCommonLabel_6", "_txtCommonDate_0", "_txtCommonTextBox_0", "_lblCommonLabel_2", "_lblCommonLabel_0", "_lblCommonLabel_1", "System.Windows.Forms.Label12", "_txtCommonTextBox_4", "_lblCommonLabel_19", "_txtCommonTextBox_1", "_lblCommonLabel_20", "_txtCommonDate_2", "_txtCommonDate_1", "_txtDisplayLabel_5", "_txtDisplayLabel_3", "_txtDisplayLabel_2", "_txtDisplayLabel_1", "_txtDisplayLabel_0", "btnFormToolBar", "lblCommonLabel", "txtCommonDate", "txtCommonTextBox", "txtDisplayLabel"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		private System.Windows.Forms.Button _btnFormToolBar_0;
		private System.Windows.Forms.Button _btnFormToolBar_1;
		private System.Windows.Forms.Button _btnFormToolBar_5;
		private System.Windows.Forms.Button _btnFormToolBar_2;
		private System.Windows.Forms.Button _btnFormToolBar_3;
		private System.Windows.Forms.Button _btnFormToolBar_6;
		private System.Windows.Forms.Button _btnFormToolBar_4;
		private System.Windows.Forms.Button _btnFormToolBar_7;
		public System.Windows.Forms.PictureBox picFormToolbar;
		private System.Windows.Forms.TextBox _txtCommonTextBox_2;
		private System.Windows.Forms.Label _lblCommonLabel_7;
		private System.Windows.Forms.Label _lblCommonLabel_5;
		private System.Windows.Forms.Label _lblCommonLabel_6;
		private Syncfusion.WinForms.Input.SfDateTimeEdit _txtCommonDate_0;
		private System.Windows.Forms.TextBox _txtCommonTextBox_0;
		private System.Windows.Forms.Label _lblCommonLabel_2;
		private System.Windows.Forms.Label _lblCommonLabel_0;
		private System.Windows.Forms.Label _lblCommonLabel_1;
		public System.Windows.Forms.Label Label12;
		private System.Windows.Forms.TextBox _txtCommonTextBox_4;
		private System.Windows.Forms.Label _lblCommonLabel_19;
		private System.Windows.Forms.TextBox _txtCommonTextBox_1;
		private System.Windows.Forms.Label _lblCommonLabel_20;
		private Syncfusion.WinForms.Input.SfDateTimeEdit _txtCommonDate_2;
		private Syncfusion.WinForms.Input.SfDateTimeEdit _txtCommonDate_1;
		private System.Windows.Forms.Label _txtDisplayLabel_5;
		private System.Windows.Forms.Label _txtDisplayLabel_3;
		private System.Windows.Forms.Label _txtDisplayLabel_2;
		private System.Windows.Forms.Label _txtDisplayLabel_1;
		private System.Windows.Forms.Label _txtDisplayLabel_0;
		public System.Windows.Forms.Button[] btnFormToolBar = new System.Windows.Forms.Button[8];
		public System.Windows.Forms.Label[] lblCommonLabel = new System.Windows.Forms.Label[21];
		public Syncfusion.WinForms.Input.SfDateTimeEdit[] txtCommonDate = new Syncfusion.WinForms.Input.SfDateTimeEdit[3];
		public System.Windows.Forms.TextBox[] txtCommonTextBox = new System.Windows.Forms.TextBox[5];
		public System.Windows.Forms.Label[] txtDisplayLabel = new System.Windows.Forms.Label[6];
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPayPassport));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this.picFormToolbar = new System.Windows.Forms.PictureBox();
			this._btnFormToolBar_0 = new System.Windows.Forms.Button();
			this._btnFormToolBar_1 = new System.Windows.Forms.Button();
			this._btnFormToolBar_5 = new System.Windows.Forms.Button();
			this._btnFormToolBar_2 = new System.Windows.Forms.Button();
			this._btnFormToolBar_3 = new System.Windows.Forms.Button();
			this._btnFormToolBar_6 = new System.Windows.Forms.Button();
			this._btnFormToolBar_4 = new System.Windows.Forms.Button();
			this._btnFormToolBar_7 = new System.Windows.Forms.Button();
			this._txtCommonTextBox_2 = new System.Windows.Forms.TextBox();
			this._lblCommonLabel_7 = new System.Windows.Forms.Label();
			this._lblCommonLabel_5 = new System.Windows.Forms.Label();
			this._lblCommonLabel_6 = new System.Windows.Forms.Label();
			this._txtCommonDate_0 = new Syncfusion.WinForms.Input.SfDateTimeEdit();
			this._txtCommonTextBox_0 = new System.Windows.Forms.TextBox();
			this._lblCommonLabel_2 = new System.Windows.Forms.Label();
			this._lblCommonLabel_0 = new System.Windows.Forms.Label();
			this._lblCommonLabel_1 = new System.Windows.Forms.Label();
			this.Label12 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_4 = new System.Windows.Forms.TextBox();
			this._lblCommonLabel_19 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_1 = new System.Windows.Forms.TextBox();
			this._lblCommonLabel_20 = new System.Windows.Forms.Label();
			this._txtCommonDate_2 = new Syncfusion.WinForms.Input.SfDateTimeEdit();
			this._txtCommonDate_1 = new Syncfusion.WinForms.Input.SfDateTimeEdit();
			this._txtDisplayLabel_5 = new System.Windows.Forms.Label();
			this._txtDisplayLabel_3 = new System.Windows.Forms.Label();
			this._txtDisplayLabel_2 = new System.Windows.Forms.Label();
			this._txtDisplayLabel_1 = new System.Windows.Forms.Label();
			this._txtDisplayLabel_0 = new System.Windows.Forms.Label();
			// //((System.ComponentModel.ISupportInitialize) this._btnFormToolBar_0).BeginInit();
			// //((System.ComponentModel.ISupportInitialize) this._btnFormToolBar_1).BeginInit();
			// //((System.ComponentModel.ISupportInitialize) this._btnFormToolBar_5).BeginInit();
			// //((System.ComponentModel.ISupportInitialize) this._btnFormToolBar_2).BeginInit();
			// //((System.ComponentModel.ISupportInitialize) this._btnFormToolBar_3).BeginInit();
			// //((System.ComponentModel.ISupportInitialize) this._btnFormToolBar_6).BeginInit();
			// //((System.ComponentModel.ISupportInitialize) this._btnFormToolBar_4).BeginInit();
			// //((System.ComponentModel.ISupportInitialize) this._btnFormToolBar_7).BeginInit();
			//this.picFormToolbar.SuspendLayout();
			this.SuspendLayout();
			// 
			// picFormToolbar
			// 
			//this.picFormToolbar.AllowDrop = true;
			this.picFormToolbar.BackColor = System.Drawing.SystemColors.Control;
			//this.picFormToolbar.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.picFormToolbar.CausesValidation = true;
			this.picFormToolbar.Controls.Add(this._btnFormToolBar_0);
			this.picFormToolbar.Controls.Add(this._btnFormToolBar_1);
			this.picFormToolbar.Controls.Add(this._btnFormToolBar_5);
			this.picFormToolbar.Controls.Add(this._btnFormToolBar_2);
			this.picFormToolbar.Controls.Add(this._btnFormToolBar_3);
			this.picFormToolbar.Controls.Add(this._btnFormToolBar_6);
			this.picFormToolbar.Controls.Add(this._btnFormToolBar_4);
			this.picFormToolbar.Controls.Add(this._btnFormToolBar_7);
			this.picFormToolbar.Dock = System.Windows.Forms.DockStyle.Top;
			this.picFormToolbar.Enabled = true;
			this.picFormToolbar.Location = new System.Drawing.Point(0, 0);
			this.picFormToolbar.Name = "picFormToolbar";
			this.picFormToolbar.Size = new System.Drawing.Size(610, 38);
			this.picFormToolbar.TabIndex = 15;
			this.picFormToolbar.TabStop = false;
			this.picFormToolbar.Visible = true;
			// 
			// _btnFormToolBar_0
			// 
			//this._btnFormToolBar_0.AllowDrop = true;
			this._btnFormToolBar_0.Location = new System.Drawing.Point(2, 2);
			this._btnFormToolBar_0.Name = "_btnFormToolBar_0";
			//
			this._btnFormToolBar_0.Size = new System.Drawing.Size(51, 34);
			this._btnFormToolBar_0.TabIndex = 16;
			this._btnFormToolBar_0.TabStop = false;
			this._btnFormToolBar_0.Tag = "New";
			// 
			// _btnFormToolBar_1
			// 
			//this._btnFormToolBar_1.AllowDrop = true;
			this._btnFormToolBar_1.Location = new System.Drawing.Point(53, 2);
			this._btnFormToolBar_1.Name = "_btnFormToolBar_1";
			//
			this._btnFormToolBar_1.Size = new System.Drawing.Size(51, 34);
			this._btnFormToolBar_1.TabIndex = 17;
			this._btnFormToolBar_1.TabStop = false;
			this._btnFormToolBar_1.Tag = "Save";
			// 
			// _btnFormToolBar_5
			// 
			//this._btnFormToolBar_5.AllowDrop = true;
			this._btnFormToolBar_5.Location = new System.Drawing.Point(257, 2);
			this._btnFormToolBar_5.Name = "_btnFormToolBar_5";
			//
			this._btnFormToolBar_5.Size = new System.Drawing.Size(51, 34);
			this._btnFormToolBar_5.TabIndex = 18;
			this._btnFormToolBar_5.TabStop = false;
			this._btnFormToolBar_5.Tag = "Help";
			// 
			// _btnFormToolBar_2
			// 
			//this._btnFormToolBar_2.AllowDrop = true;
			this._btnFormToolBar_2.Location = new System.Drawing.Point(104, 2);
			this._btnFormToolBar_2.Name = "_btnFormToolBar_2";
			//
			this._btnFormToolBar_2.Size = new System.Drawing.Size(51, 34);
			this._btnFormToolBar_2.TabIndex = 19;
			this._btnFormToolBar_2.TabStop = false;
			this._btnFormToolBar_2.Tag = "Delete";
			// 
			// _btnFormToolBar_3
			// 
			//this._btnFormToolBar_3.AllowDrop = true;
			this._btnFormToolBar_3.Location = new System.Drawing.Point(155, 2);
			this._btnFormToolBar_3.Name = "_btnFormToolBar_3";
			//
			this._btnFormToolBar_3.Size = new System.Drawing.Size(51, 34);
			this._btnFormToolBar_3.TabIndex = 20;
			this._btnFormToolBar_3.TabStop = false;
			this._btnFormToolBar_3.Tag = "Print";
			// 
			// _btnFormToolBar_6
			// 
			//this._btnFormToolBar_6.AllowDrop = true;
			this._btnFormToolBar_6.Location = new System.Drawing.Point(370, 2);
			this._btnFormToolBar_6.Name = "_btnFormToolBar_6";
			//
			this._btnFormToolBar_6.Size = new System.Drawing.Size(51, 34);
			this._btnFormToolBar_6.TabIndex = 21;
			this._btnFormToolBar_6.TabStop = false;
			this._btnFormToolBar_6.Tag = "Exit";
			// 
			// _btnFormToolBar_4
			// 
			//this._btnFormToolBar_4.AllowDrop = true;
			this._btnFormToolBar_4.Location = new System.Drawing.Point(206, 2);
			this._btnFormToolBar_4.Name = "_btnFormToolBar_4";
			//
			this._btnFormToolBar_4.Size = new System.Drawing.Size(51, 34);
			this._btnFormToolBar_4.TabIndex = 22;
			this._btnFormToolBar_4.TabStop = false;
			this._btnFormToolBar_4.Tag = "Find";
			// 
			// _btnFormToolBar_7
			// 
			//this._btnFormToolBar_7.AllowDrop = true;
			this._btnFormToolBar_7.Location = new System.Drawing.Point(308, 2);
			this._btnFormToolBar_7.Name = "_btnFormToolBar_7";
			//
			this._btnFormToolBar_7.Size = new System.Drawing.Size(51, 34);
			this._btnFormToolBar_7.TabIndex = 23;
			this._btnFormToolBar_7.TabStop = false;
			this._btnFormToolBar_7.Tag = "Post";
			// 
			// _txtCommonTextBox_2
			// 
			//this._txtCommonTextBox_2.AllowDrop = true;
			this._txtCommonTextBox_2.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_2.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_2.Location = new System.Drawing.Point(104, 167);
			this._txtCommonTextBox_2.MaxLength = 20;
			this._txtCommonTextBox_2.Name = "_txtCommonTextBox_2";
			this._txtCommonTextBox_2.Size = new System.Drawing.Size(102, 19);
			this._txtCommonTextBox_2.TabIndex = 3;
			this._txtCommonTextBox_2.Text = "";
			// 
			// _lblCommonLabel_7
			// 
			//this._lblCommonLabel_7.AllowDrop = true;
			this._lblCommonLabel_7.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_7.Text = "Passport No.";
			this._lblCommonLabel_7.Location = new System.Drawing.Point(10, 170);
			// // this._lblCommonLabel_7.mLabelId = 1550;
			this._lblCommonLabel_7.Name = "_lblCommonLabel_7";
			this._lblCommonLabel_7.Size = new System.Drawing.Size(62, 13);
			this._lblCommonLabel_7.TabIndex = 6;
			// 
			// _lblCommonLabel_5
			// 
			//this._lblCommonLabel_5.AllowDrop = true;
			this._lblCommonLabel_5.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_5.Text = "Transaction No.";
			this._lblCommonLabel_5.Location = new System.Drawing.Point(10, 53);
			// // this._lblCommonLabel_5.mLabelId = 1022;
			this._lblCommonLabel_5.Name = "_lblCommonLabel_5";
			this._lblCommonLabel_5.Size = new System.Drawing.Size(76, 14);
			this._lblCommonLabel_5.TabIndex = 8;
			// 
			// _lblCommonLabel_6
			// 
			//this._lblCommonLabel_6.AllowDrop = true;
			this._lblCommonLabel_6.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_6.Text = "Transaction Date";
			this._lblCommonLabel_6.Location = new System.Drawing.Point(10, 75);
			// // this._lblCommonLabel_6.mLabelId = 948;
			this._lblCommonLabel_6.Name = "_lblCommonLabel_6";
			this._lblCommonLabel_6.Size = new System.Drawing.Size(82, 14);
			this._lblCommonLabel_6.TabIndex = 9;
			// 
			// _txtCommonDate_0
			// 
			//this._txtCommonDate_0.AllowDrop = true;
			// this._txtCommonDate_0.CheckDateRange = false;
			this._txtCommonDate_0.Location = new System.Drawing.Point(104, 72);
			// this._txtCommonDate_0.MaxDate = 2958465;
			// this._txtCommonDate_0.MinDate = 32874;
			this._txtCommonDate_0.Name = "_txtCommonDate_0";
			this._txtCommonDate_0.Size = new System.Drawing.Size(102, 19);
			this._txtCommonDate_0.TabIndex = 1;
			this._txtCommonDate_0.Text = "18/07/2001";
			// this._txtCommonDate_0.Value = 37090;
			// 
			// _txtCommonTextBox_0
			// 
			//this._txtCommonTextBox_0.AllowDrop = true;
			this._txtCommonTextBox_0.BackColor = System.Drawing.Color.White;
			// this._txtCommonTextBox_0.bolNumericOnly = true;
			this._txtCommonTextBox_0.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_0.Location = new System.Drawing.Point(104, 50);
			// // = System.Windows.Forms.TextBox.DropDownTypes.ddtNextNumber;
			this._txtCommonTextBox_0.Name = "_txtCommonTextBox_0";
			// this._txtCommonTextBox_0.ShowButton = true;
			this._txtCommonTextBox_0.Size = new System.Drawing.Size(102, 19);
			this._txtCommonTextBox_0.TabIndex = 0;
			this._txtCommonTextBox_0.Text = "";
			// 
			// _lblCommonLabel_2
			// 
			//this._lblCommonLabel_2.AllowDrop = true;
			this._lblCommonLabel_2.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_2.Text = "Employee Code";
			this._lblCommonLabel_2.Location = new System.Drawing.Point(10, 107);
			// // this._lblCommonLabel_2.mLabelId = 236;
			this._lblCommonLabel_2.Name = "_lblCommonLabel_2";
			this._lblCommonLabel_2.Size = new System.Drawing.Size(74, 14);
			this._lblCommonLabel_2.TabIndex = 10;
			// 
			// _lblCommonLabel_0
			// 
			//this._lblCommonLabel_0.AllowDrop = true;
			this._lblCommonLabel_0.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_0.Text = "Department Code";
			this._lblCommonLabel_0.Location = new System.Drawing.Point(10, 128);
			// // this._lblCommonLabel_0.mLabelId = 211;
			this._lblCommonLabel_0.Name = "_lblCommonLabel_0";
			this._lblCommonLabel_0.Size = new System.Drawing.Size(83, 14);
			this._lblCommonLabel_0.TabIndex = 11;
			// 
			// _lblCommonLabel_1
			// 
			//this._lblCommonLabel_1.AllowDrop = true;
			this._lblCommonLabel_1.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_1.Text = "Designation Code";
			this._lblCommonLabel_1.Location = new System.Drawing.Point(10, 148);
			// // this._lblCommonLabel_1.mLabelId = 1049;
			this._lblCommonLabel_1.Name = "_lblCommonLabel_1";
			this._lblCommonLabel_1.Size = new System.Drawing.Size(84, 14);
			this._lblCommonLabel_1.TabIndex = 12;
			// 
			// System.Windows.Forms.Label12
			// 
			//this.Label12.AllowDrop = true;
			this.Label12.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.Label12.Text = "Comments";
			this.Label12.Location = new System.Drawing.Point(10, 212);
			// this.Label12.mLabelId = 135;
			this.Label12.Name="Label12";
			this.Label12.Size = new System.Drawing.Size(50, 14);
			this.Label12.TabIndex = 13;
			// 
			// _txtCommonTextBox_4
			// 
			//this._txtCommonTextBox_4.AllowDrop = true;
			this._txtCommonTextBox_4.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_4.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_4.Location = new System.Drawing.Point(104, 209);
			this._txtCommonTextBox_4.MaxLength = 100;
			this._txtCommonTextBox_4.Name = "_txtCommonTextBox_4";
			this._txtCommonTextBox_4.Size = new System.Drawing.Size(498, 19);
			this._txtCommonTextBox_4.TabIndex = 7;
			this._txtCommonTextBox_4.Text = "";
			// 
			// _lblCommonLabel_19
			// 
			//this._lblCommonLabel_19.AllowDrop = true;
			this._lblCommonLabel_19.BackColor = System.Drawing.Color.FromArgb(237, 231, 235);
			this._lblCommonLabel_19.Text = "Return Date";
			this._lblCommonLabel_19.Location = new System.Drawing.Point(242, 191);
			// // this._lblCommonLabel_19.mLabelId = 1800;
			this._lblCommonLabel_19.Name = "_lblCommonLabel_19";
			this._lblCommonLabel_19.Size = new System.Drawing.Size(57, 14);
			this._lblCommonLabel_19.TabIndex = 14;
			// 
			// _txtCommonTextBox_1
			// 
			//this._txtCommonTextBox_1.AllowDrop = true;
			this._txtCommonTextBox_1.BackColor = System.Drawing.Color.White;
			// this._txtCommonTextBox_1.bolNumericOnly = true;
			this._txtCommonTextBox_1.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_1.Location = new System.Drawing.Point(104, 104);
			this._txtCommonTextBox_1.MaxLength = 4;
			this._txtCommonTextBox_1.Name = "_txtCommonTextBox_1";
			// this._txtCommonTextBox_1.ShowButton = true;
			this._txtCommonTextBox_1.Size = new System.Drawing.Size(101, 19);
			this._txtCommonTextBox_1.TabIndex = 2;
			this._txtCommonTextBox_1.Text = "";
			// 
			// _lblCommonLabel_20
			// 
			//this._lblCommonLabel_20.AllowDrop = true;
			this._lblCommonLabel_20.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_20.Text = "Delivery Date";
			this._lblCommonLabel_20.Location = new System.Drawing.Point(10, 191);
			// // this._lblCommonLabel_20.mLabelId = 1799;
			this._lblCommonLabel_20.Name = "_lblCommonLabel_20";
			this._lblCommonLabel_20.Size = new System.Drawing.Size(64, 14);
			this._lblCommonLabel_20.TabIndex = 24;
			// 
			// _txtCommonDate_2
			// 
			//this._txtCommonDate_2.AllowDrop = true;
			// this._txtCommonDate_2.CheckDateRange = false;
			this._txtCommonDate_2.Location = new System.Drawing.Point(306, 188);
			// this._txtCommonDate_2.MaxDate = 2958465;
			// this._txtCommonDate_2.MinDate = 32874;
			this._txtCommonDate_2.Name = "_txtCommonDate_2";
			this._txtCommonDate_2.Size = new System.Drawing.Size(102, 19);
			this._txtCommonDate_2.TabIndex = 5;
			this._txtCommonDate_2.Text = "18/07/2001";
			// this._txtCommonDate_2.Value = 37090;
			// 
			// _txtCommonDate_1
			// 
			//this._txtCommonDate_1.AllowDrop = true;
			// this._txtCommonDate_1.CheckDateRange = false;
			this._txtCommonDate_1.Location = new System.Drawing.Point(104, 188);
			// this._txtCommonDate_1.MaxDate = 2958465;
			// this._txtCommonDate_1.MinDate = 32874;
			this._txtCommonDate_1.Name = "_txtCommonDate_1";
			this._txtCommonDate_1.Size = new System.Drawing.Size(102, 19);
			this._txtCommonDate_1.TabIndex = 4;
			this._txtCommonDate_1.Text = "18/07/2001";
			// this._txtCommonDate_1.Value = 37090;
			// 
			// _txtDisplayLabel_5
			// 
			//this._txtDisplayLabel_5.AllowDrop = true;
			this._txtDisplayLabel_5.Location = new System.Drawing.Point(207, 104);
			this._txtDisplayLabel_5.Name = "_txtDisplayLabel_5";
			this._txtDisplayLabel_5.Size = new System.Drawing.Size(395, 19);
			this._txtDisplayLabel_5.TabIndex = 25;
			// 
			// _txtDisplayLabel_3
			// 
			//this._txtDisplayLabel_3.AllowDrop = true;
			this._txtDisplayLabel_3.Location = new System.Drawing.Point(207, 146);
			this._txtDisplayLabel_3.Name = "_txtDisplayLabel_3";
			this._txtDisplayLabel_3.Size = new System.Drawing.Size(201, 19);
			this._txtDisplayLabel_3.TabIndex = 26;
			// 
			// _txtDisplayLabel_2
			// 
			//this._txtDisplayLabel_2.AllowDrop = true;
			this._txtDisplayLabel_2.Location = new System.Drawing.Point(104, 146);
			this._txtDisplayLabel_2.Name = "_txtDisplayLabel_2";
			this._txtDisplayLabel_2.Size = new System.Drawing.Size(101, 19);
			this._txtDisplayLabel_2.TabIndex = 27;
			// 
			// _txtDisplayLabel_1
			// 
			//this._txtDisplayLabel_1.AllowDrop = true;
			this._txtDisplayLabel_1.Location = new System.Drawing.Point(207, 125);
			this._txtDisplayLabel_1.Name = "_txtDisplayLabel_1";
			this._txtDisplayLabel_1.Size = new System.Drawing.Size(201, 19);
			this._txtDisplayLabel_1.TabIndex = 28;
			// 
			// _txtDisplayLabel_0
			// 
			//this._txtDisplayLabel_0.AllowDrop = true;
			this._txtDisplayLabel_0.Location = new System.Drawing.Point(104, 125);
			this._txtDisplayLabel_0.Name = "_txtDisplayLabel_0";
			this._txtDisplayLabel_0.Size = new System.Drawing.Size(101, 19);
			this._txtDisplayLabel_0.TabIndex = 29;
			// 
			// frmPayPassport
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.ClientSize = new System.Drawing.Size(610, 232);
			this.Controls.Add(this.picFormToolbar);
			this.Controls.Add(this._txtCommonTextBox_2);
			this.Controls.Add(this._lblCommonLabel_7);
			this.Controls.Add(this._lblCommonLabel_5);
			this.Controls.Add(this._lblCommonLabel_6);
			this.Controls.Add(this._txtCommonDate_0);
			this.Controls.Add(this._txtCommonTextBox_0);
			this.Controls.Add(this._lblCommonLabel_2);
			this.Controls.Add(this._lblCommonLabel_0);
			this.Controls.Add(this._lblCommonLabel_1);
			this.Controls.Add(this.Label12);
			this.Controls.Add(this._txtCommonTextBox_4);
			this.Controls.Add(this._lblCommonLabel_19);
			this.Controls.Add(this._txtCommonTextBox_1);
			this.Controls.Add(this._lblCommonLabel_20);
			this.Controls.Add(this._txtCommonDate_2);
			this.Controls.Add(this._txtCommonDate_1);
			this.Controls.Add(this._txtDisplayLabel_5);
			this.Controls.Add(this._txtDisplayLabel_3);
			this.Controls.Add(this._txtDisplayLabel_2);
			this.Controls.Add(this._txtDisplayLabel_1);
			this.Controls.Add(this._txtDisplayLabel_0);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			//this.Icon = (System.Drawing.Icon) resources.GetObject("frmPayPassport.Icon");
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(111, 180);
			this.MaximizeBox = true;
			this.MinimizeBox = true;
			this.Name = "frmPayPassport";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Passport Details";
			// this.Activated += new System.EventHandler(this.frmPayPassport_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
			//((System.ComponentModel.ISupportInitialize) this._btnFormToolBar_0).EndInit();
			//((System.ComponentModel.ISupportInitialize) this._btnFormToolBar_1).EndInit();
			//((System.ComponentModel.ISupportInitialize) this._btnFormToolBar_5).EndInit();
			//((System.ComponentModel.ISupportInitialize) this._btnFormToolBar_2).EndInit();
			//((System.ComponentModel.ISupportInitialize) this._btnFormToolBar_3).EndInit();
			//((System.ComponentModel.ISupportInitialize) this._btnFormToolBar_6).EndInit();
			//((System.ComponentModel.ISupportInitialize) this._btnFormToolBar_4).EndInit();
			//((System.ComponentModel.ISupportInitialize) this._btnFormToolBar_7).EndInit();
			this.picFormToolbar.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		// 
		void InitializetxtDisplayLabel()
		{
			this.txtDisplayLabel = new System.Windows.Forms.Label[6];
			this.txtDisplayLabel[5] = _txtDisplayLabel_5;
			this.txtDisplayLabel[3] = _txtDisplayLabel_3;
			this.txtDisplayLabel[2] = _txtDisplayLabel_2;
			this.txtDisplayLabel[1] = _txtDisplayLabel_1;
			this.txtDisplayLabel[0] = _txtDisplayLabel_0;
		}
		void InitializetxtCommonTextBox()
		{
			this.txtCommonTextBox = new System.Windows.Forms.TextBox[5];
			this.txtCommonTextBox[2] = _txtCommonTextBox_2;
			this.txtCommonTextBox[0] = _txtCommonTextBox_0;
			this.txtCommonTextBox[4] = _txtCommonTextBox_4;
			this.txtCommonTextBox[1] = _txtCommonTextBox_1;
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
			this.lblCommonLabel[19] = _lblCommonLabel_19;
			this.lblCommonLabel[20] = _lblCommonLabel_20;
		}
		void InitializebtnFormToolBar()
		{
			this.btnFormToolBar = new System.Windows.Forms.Button[8];
			this.btnFormToolBar[0] = _btnFormToolBar_0;
			this.btnFormToolBar[1] = _btnFormToolBar_1;
			this.btnFormToolBar[5] = _btnFormToolBar_5;
			this.btnFormToolBar[2] = _btnFormToolBar_2;
			this.btnFormToolBar[3] = _btnFormToolBar_3;
			this.btnFormToolBar[6] = _btnFormToolBar_6;
			this.btnFormToolBar[4] = _btnFormToolBar_4;
			this.btnFormToolBar[7] = _btnFormToolBar_7;
		}
		#endregion
	}
}//ENDSHERE
