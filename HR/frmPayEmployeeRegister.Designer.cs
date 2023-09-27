
namespace Xtreme
{
	partial class frmPayEmployeeRegister
	{

		#region "Upgrade Support "
		private static frmPayEmployeeRegister m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmPayEmployeeRegister DefInstance
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
		public static frmPayEmployeeRegister CreateInstance()
		{
			frmPayEmployeeRegister theInstance = new frmPayEmployeeRegister();
			
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
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "System.Windows.Forms.Label5", "System.Windows.Forms.Label4", "System.Windows.Forms.Label3", "System.Windows.Forms.Label2", "System.Windows.Forms.Label1", "_txtDisplayLabel_5", "_txtCommonDate_1", "_txtCommonTextBox_0", "_txtCommonTextBox_1", "_txtCommonDate_0", "_txtDisplayLabel_0", "_txtCommonTextBox_2", "txtCommonDate", "txtCommonTextBox", "txtDisplayLabel"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public System.Windows.Forms.Label Label5;
		public System.Windows.Forms.Label Label4;
		public System.Windows.Forms.Label Label3;
		public System.Windows.Forms.Label Label2;
		public System.Windows.Forms.Label Label1;
		private System.Windows.Forms.Label _txtDisplayLabel_5;
		private Syncfusion.WinForms.Input.SfDateTimeEdit _txtCommonDate_1;
		private System.Windows.Forms.TextBox _txtCommonTextBox_0;
		private System.Windows.Forms.TextBox _txtCommonTextBox_1;
		private Syncfusion.WinForms.Input.SfDateTimeEdit _txtCommonDate_0;
		private System.Windows.Forms.Label _txtDisplayLabel_0;
		private System.Windows.Forms.TextBox _txtCommonTextBox_2;
		public Syncfusion.WinForms.Input.SfDateTimeEdit[] txtCommonDate = new Syncfusion.WinForms.Input.SfDateTimeEdit[2];
		public System.Windows.Forms.TextBox[] txtCommonTextBox = new System.Windows.Forms.TextBox[3];
		public System.Windows.Forms.Label[] txtDisplayLabel = new System.Windows.Forms.Label[6];
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPayEmployeeRegister));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this.Label5 = new System.Windows.Forms.Label();
			this.Label4 = new System.Windows.Forms.Label();
			this.Label3 = new System.Windows.Forms.Label();
			this.Label2 = new System.Windows.Forms.Label();
			this.Label1 = new System.Windows.Forms.Label();
			this._txtDisplayLabel_5 = new System.Windows.Forms.Label();
			this._txtCommonDate_1 = new Syncfusion.WinForms.Input.SfDateTimeEdit();
			this._txtCommonTextBox_0 = new System.Windows.Forms.TextBox();
			this._txtCommonTextBox_1 = new System.Windows.Forms.TextBox();
			this._txtCommonDate_0 = new Syncfusion.WinForms.Input.SfDateTimeEdit();
			this._txtDisplayLabel_0 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_2 = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// System.Windows.Forms.Label5
			// 
			//this.Label5.AllowDrop = true;
			this.Label5.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.Label5.Text = "Project";
			this.Label5.ForeColor = System.Drawing.SystemColors.WindowText;
			this.Label5.Location = new System.Drawing.Point(16, 161);
			this.Label5.Name="Label5";
			this.Label5.Size = new System.Drawing.Size(41, 16);
			this.Label5.TabIndex = 4;
			// 
			// System.Windows.Forms.Label4
			// 
			//this.Label4.AllowDrop = true;
			this.Label4.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.Label4.Text = "Time";
			this.Label4.ForeColor = System.Drawing.SystemColors.WindowText;
			this.Label4.Location = new System.Drawing.Point(16, 137);
			this.Label4.Name="Label4";
			this.Label4.Size = new System.Drawing.Size(28, 16);
			this.Label4.TabIndex = 3;
			// 
			// System.Windows.Forms.Label3
			// 
			//this.Label3.AllowDrop = true;
			this.Label3.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.Label3.Text = "To Date";
			this.Label3.ForeColor = System.Drawing.SystemColors.WindowText;
			this.Label3.Location = new System.Drawing.Point(16, 113);
			this.Label3.Name="Label3";
			this.Label3.Size = new System.Drawing.Size(45, 16);
			this.Label3.TabIndex = 2;
			// 
			// System.Windows.Forms.Label2
			// 
			//this.Label2.AllowDrop = true;
			this.Label2.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.Label2.Text = "From Date";
			this.Label2.ForeColor = System.Drawing.SystemColors.WindowText;
			this.Label2.Location = new System.Drawing.Point(16, 89);
			this.Label2.Name="Label2";
			this.Label2.Size = new System.Drawing.Size(61, 16);
			this.Label2.TabIndex = 1;
			// 
			// System.Windows.Forms.Label1
			// 
			//this.Label1.AllowDrop = true;
			this.Label1.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.Label1.Text = "Employee Code";
			this.Label1.ForeColor = System.Drawing.SystemColors.WindowText;
			this.Label1.Location = new System.Drawing.Point(18, 64);
			this.Label1.Name="Label1";
			this.Label1.Size = new System.Drawing.Size(92, 16);
			this.Label1.TabIndex = 0;
			// 
			// _txtDisplayLabel_5
			// 
			//this._txtDisplayLabel_5.AllowDrop = true;
			this._txtDisplayLabel_5.Location = new System.Drawing.Point(223, 64);
			this._txtDisplayLabel_5.Name = "_txtDisplayLabel_5";
			this._txtDisplayLabel_5.Size = new System.Drawing.Size(242, 19);
			this._txtDisplayLabel_5.TabIndex = 5;
			this._txtDisplayLabel_5.TabStop = false;
			// 
			// _txtCommonDate_1
			// 
			//this._txtCommonDate_1.AllowDrop = true;
			// this._txtCommonDate_1.CheckDateRange = false;
			this._txtCommonDate_1.Location = new System.Drawing.Point(120, 112);
			// this._txtCommonDate_1.MaxDate = 2958465;
			// this._txtCommonDate_1.MinDate = 32874;
			this._txtCommonDate_1.Name = "_txtCommonDate_1";
			this._txtCommonDate_1.Size = new System.Drawing.Size(102, 19);
			this._txtCommonDate_1.TabIndex = 6;
			this._txtCommonDate_1.Text = "18/07/2001";
			// this._txtCommonDate_1.Value = 37090;
			// 
			// _txtCommonTextBox_0
			// 
			//this._txtCommonTextBox_0.AllowDrop = true;
			this._txtCommonTextBox_0.BackColor = System.Drawing.Color.FromArgb(239, 239, 239);
			// this._txtCommonTextBox_0.bolNumericOnly = true;
			this._txtCommonTextBox_0.Enabled = false;
			this._txtCommonTextBox_0.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_0.Location = new System.Drawing.Point(120, 136);
			// // = System.Windows.Forms.TextBox.DropDownTypes.ddtNextNumber;
			this._txtCommonTextBox_0.Name = "_txtCommonTextBox_0";
			// this._txtCommonTextBox_0.ShowButton = true;
			this._txtCommonTextBox_0.Size = new System.Drawing.Size(102, 19);
			this._txtCommonTextBox_0.TabIndex = 7;
			this._txtCommonTextBox_0.TabStop = false;
			this._txtCommonTextBox_0.Text = "";
			// this.//this._txtCommonTextBox_0.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(//this.txtCommonTextBox_DropButtonClick);
			// 
			// _txtCommonTextBox_1
			// 
			//this._txtCommonTextBox_1.AllowDrop = true;
			this._txtCommonTextBox_1.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_1.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_1.Location = new System.Drawing.Point(120, 64);
			this._txtCommonTextBox_1.MaxLength = 10;
			this._txtCommonTextBox_1.Name = "_txtCommonTextBox_1";
			// this._txtCommonTextBox_1.ShowButton = true;
			this._txtCommonTextBox_1.Size = new System.Drawing.Size(101, 19);
			this._txtCommonTextBox_1.TabIndex = 8;
			this._txtCommonTextBox_1.Text = "";
			// this.//this._txtCommonTextBox_1.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(//this.txtCommonTextBox_DropButtonClick);
			// 
			// _txtCommonDate_0
			// 
			//this._txtCommonDate_0.AllowDrop = true;
			// this._txtCommonDate_0.CheckDateRange = false;
			this._txtCommonDate_0.Location = new System.Drawing.Point(120, 88);
			// this._txtCommonDate_0.MaxDate = 2958465;
			// this._txtCommonDate_0.MinDate = 32874;
			this._txtCommonDate_0.Name = "_txtCommonDate_0";
			this._txtCommonDate_0.Size = new System.Drawing.Size(102, 19);
			this._txtCommonDate_0.TabIndex = 9;
			this._txtCommonDate_0.Text = "18/07/2001";
			// this._txtCommonDate_0.Value = 37090;
			// 
			// _txtDisplayLabel_0
			// 
			//this._txtDisplayLabel_0.AllowDrop = true;
			this._txtDisplayLabel_0.Location = new System.Drawing.Point(223, 160);
			this._txtDisplayLabel_0.Name = "_txtDisplayLabel_0";
			this._txtDisplayLabel_0.Size = new System.Drawing.Size(242, 19);
			this._txtDisplayLabel_0.TabIndex = 10;
			this._txtDisplayLabel_0.TabStop = false;
			// 
			// _txtCommonTextBox_2
			// 
			//this._txtCommonTextBox_2.AllowDrop = true;
			this._txtCommonTextBox_2.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_2.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_2.Location = new System.Drawing.Point(120, 160);
			this._txtCommonTextBox_2.MaxLength = 10;
			this._txtCommonTextBox_2.Name = "_txtCommonTextBox_2";
			// this._txtCommonTextBox_2.ShowButton = true;
			this._txtCommonTextBox_2.Size = new System.Drawing.Size(101, 19);
			this._txtCommonTextBox_2.TabIndex = 11;
			this._txtCommonTextBox_2.Text = "";
			// this.//this._txtCommonTextBox_2.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(//this.txtCommonTextBox_DropButtonClick);
			// 
			// frmPayEmployeeRegister
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.ClientSize = new System.Drawing.Size(472, 190);
			this.Controls.Add(this.Label5);
			this.Controls.Add(this.Label4);
			this.Controls.Add(this.Label3);
			this.Controls.Add(this.Label2);
			this.Controls.Add(this.Label1);
			this.Controls.Add(this._txtDisplayLabel_5);
			this.Controls.Add(this._txtCommonDate_1);
			this.Controls.Add(this._txtCommonTextBox_0);
			this.Controls.Add(this._txtCommonTextBox_1);
			this.Controls.Add(this._txtCommonDate_0);
			this.Controls.Add(this._txtDisplayLabel_0);
			this.Controls.Add(this._txtCommonTextBox_2);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			//this.Icon = (System.Drawing.Icon) resources.GetObject("frmPayEmployeeRegister.Icon");
			this.Location = new System.Drawing.Point(183, 262);
			this.MaximizeBox = true;
			this.MinimizeBox = false;
			this.Name = "frmPayEmployeeRegister";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Employee Register";
			// this.Activated += new System.EventHandler(this.frmPayEmployeeRegister_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
			this.ResumeLayout(false);
		}
		// 
		void InitializetxtDisplayLabel()
		{
			this.txtDisplayLabel = new System.Windows.Forms.Label[6];
			this.txtDisplayLabel[5] = _txtDisplayLabel_5;
			this.txtDisplayLabel[0] = _txtDisplayLabel_0;
		}
		void InitializetxtCommonTextBox()
		{
			this.txtCommonTextBox = new System.Windows.Forms.TextBox[3];
			this.txtCommonTextBox[0] = _txtCommonTextBox_0;
			this.txtCommonTextBox[1] = _txtCommonTextBox_1;
			this.txtCommonTextBox[2] = _txtCommonTextBox_2;
		}
		void InitializetxtCommonDate()
		{
			this.txtCommonDate = new Syncfusion.WinForms.Input.SfDateTimeEdit[2];
			this.txtCommonDate[1] = _txtCommonDate_1;
			this.txtCommonDate[0] = _txtCommonDate_0;
		}
		#endregion
	}
}//ENDSHERE
