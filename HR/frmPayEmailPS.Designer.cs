
namespace Xtreme
{
	partial class frmPayEmailPS
	{

		#region "Upgrade Support "
		private static frmPayEmailPS m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmPayEmailPS DefInstance
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
		public static frmPayEmailPS CreateInstance()
		{
			frmPayEmailPS theInstance = new frmPayEmailPS();
			
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
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "ChkIncludeSentEmployee", "txtEmployeeComplete", "chkAllEmployees", "cmdCancel", "cmdOk", "txtFromEmp", "lblFromEmp", "lblToEmp", "txtToEmp", "System.Windows.Forms.Label1", "txtFrmEmpCodeName", "txtToEmpCodeName", "System.Windows.Forms.Label2", "txtMonth"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public System.Windows.Forms.CheckBox ChkIncludeSentEmployee;
		public System.Windows.Forms.Label txtEmployeeComplete;
		public System.Windows.Forms.CheckBox chkAllEmployees;
		public System.Windows.Forms.Button cmdCancel;
		public System.Windows.Forms.Button cmdOk;
		public System.Windows.Forms.TextBox txtFromEmp;
		public System.Windows.Forms.Label lblFromEmp;
		public System.Windows.Forms.Label lblToEmp;
		public System.Windows.Forms.TextBox txtToEmp;
		public System.Windows.Forms.Label Label1;
		public System.Windows.Forms.Label txtFrmEmpCodeName;
		public System.Windows.Forms.Label txtToEmpCodeName;
		public System.Windows.Forms.Label Label2;
		public Syncfusion.WinForms.Input.SfDateTimeEdit txtMonth;
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPayEmailPS));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this.ChkIncludeSentEmployee = new System.Windows.Forms.CheckBox();
			this.txtEmployeeComplete = new System.Windows.Forms.Label();
			this.chkAllEmployees = new System.Windows.Forms.CheckBox();
			this.cmdCancel = new System.Windows.Forms.Button();
			this.cmdOk = new System.Windows.Forms.Button();
			this.txtFromEmp = new System.Windows.Forms.TextBox();
			this.lblFromEmp = new System.Windows.Forms.Label();
			this.lblToEmp = new System.Windows.Forms.Label();
			this.txtToEmp = new System.Windows.Forms.TextBox();
			this.Label1 = new System.Windows.Forms.Label();
			this.txtFrmEmpCodeName = new System.Windows.Forms.Label();
			this.txtToEmpCodeName = new System.Windows.Forms.Label();
			this.Label2 = new System.Windows.Forms.Label();
			this.txtMonth = new Syncfusion.WinForms.Input.SfDateTimeEdit();
			this.SuspendLayout();
			// 
			// ChkIncludeSentEmployee
			// 
			this.ChkIncludeSentEmployee.AllowDrop = true;
			this.ChkIncludeSentEmployee.Appearance = System.Windows.Forms.Appearance.Normal;
			this.ChkIncludeSentEmployee.BackColor = System.Drawing.Color.White;
			this.ChkIncludeSentEmployee.CausesValidation = true;
			this.ChkIncludeSentEmployee.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.ChkIncludeSentEmployee.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this.ChkIncludeSentEmployee.Enabled = true;
			this.ChkIncludeSentEmployee.ForeColor = System.Drawing.SystemColors.ControlText;
			this.ChkIncludeSentEmployee.Location = new System.Drawing.Point(248, 110);
			this.ChkIncludeSentEmployee.Name = "ChkIncludeSentEmployee";
			this.ChkIncludeSentEmployee.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.ChkIncludeSentEmployee.Size = new System.Drawing.Size(149, 13);
			this.ChkIncludeSentEmployee.TabIndex = 4;
			this.ChkIncludeSentEmployee.TabStop = true;
			this.ChkIncludeSentEmployee.Text = "Include Sent Employee";
			this.ChkIncludeSentEmployee.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.ChkIncludeSentEmployee.Visible = true;
			// 
			// txtEmployeeComplete
			// 
			this.txtEmployeeComplete.AllowDrop = true;
			this.txtEmployeeComplete.BackColor = System.Drawing.SystemColors.Window;
			this.txtEmployeeComplete.Enabled = false;
			this.txtEmployeeComplete.Location = new System.Drawing.Point(102, 106);
			this.txtEmployeeComplete.Name = "txtEmployeeComplete";
			this.txtEmployeeComplete.Size = new System.Drawing.Size(121, 19);
			this.txtEmployeeComplete.TabIndex = 12;
			// 
			// chkAllEmployees
			// 
			this.chkAllEmployees.AllowDrop = true;
			this.chkAllEmployees.Appearance = System.Windows.Forms.Appearance.Normal;
			this.chkAllEmployees.BackColor = System.Drawing.Color.White;
			this.chkAllEmployees.CausesValidation = true;
			this.chkAllEmployees.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkAllEmployees.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this.chkAllEmployees.Enabled = true;
			this.chkAllEmployees.ForeColor = System.Drawing.SystemColors.ControlText;
			this.chkAllEmployees.Location = new System.Drawing.Point(250, 88);
			this.chkAllEmployees.Name = "chkAllEmployees";
			this.chkAllEmployees.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.chkAllEmployees.Size = new System.Drawing.Size(95, 13);
			this.chkAllEmployees.TabIndex = 3;
			this.chkAllEmployees.TabStop = true;
			this.chkAllEmployees.Text = "All Employees";
			this.chkAllEmployees.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkAllEmployees.Visible = true;
			this.chkAllEmployees.CheckStateChanged += new System.EventHandler(this.chkAllEmployees_CheckStateChanged);
			// 
			// cmdCancel
			// 
			this.cmdCancel.AllowDrop = true;
			this.cmdCancel.BackColor = System.Drawing.SystemColors.Control;
			this.cmdCancel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdCancel.Location = new System.Drawing.Point(204, 140);
			this.cmdCancel.Name = "cmdCancel";
			this.cmdCancel.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdCancel.Size = new System.Drawing.Size(71, 23);
			this.cmdCancel.TabIndex = 6;
			this.cmdCancel.Text = "Cancel";
			this.cmdCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.cmdCancel.UseVisualStyleBackColor = false;
			// 
			// cmdOk
			// 
			this.cmdOk.AllowDrop = true;
			this.cmdOk.BackColor = System.Drawing.SystemColors.Control;
			this.cmdOk.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdOk.Location = new System.Drawing.Point(128, 140);
			this.cmdOk.Name = "cmdOk";
			this.cmdOk.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdOk.Size = new System.Drawing.Size(71, 23);
			this.cmdOk.TabIndex = 5;
			this.cmdOk.Text = "OK";
			this.cmdOk.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.cmdOk.UseVisualStyleBackColor = false;
			// this.cmdOk.Click += new System.EventHandler(this.cmdOk_Click);
			// 
			// txtFromEmp
			// 
			this.txtFromEmp.AllowDrop = true;
			this.txtFromEmp.BackColor = System.Drawing.Color.White;
			// this.txtFromEmp.bolAllowDecimal = false;
			this.txtFromEmp.ForeColor = System.Drawing.Color.Black;
			this.txtFromEmp.Location = new System.Drawing.Point(102, 42);
			// this.txtFromEmp.mDropDownType = (System.Windows.Forms.TextBox.DropDownTypes) 0;
			this.txtFromEmp.Name = "txtFromEmp";
			// this.txtFromEmp.ShowButton = true;
			this.txtFromEmp.Size = new System.Drawing.Size(121, 19);
			this.txtFromEmp.TabIndex = 1;
			this.txtFromEmp.Text = "";
			// this.this.txtFromEmp.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtFromEmp_DropButtonClick);
			// this.txtFromEmp.Leave += new System.EventHandler(this.txtFromEmp_Leave);
			// 
			// lblFromEmp
			// 
			this.lblFromEmp.AllowDrop = true;
			this.lblFromEmp.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblFromEmp.Text = "From Employee";
			this.lblFromEmp.Location = new System.Drawing.Point(4, 44);
			// // this.lblFromEmp.mLabelId = 1914;
			this.lblFromEmp.Name = "lblFromEmp";
			this.lblFromEmp.Size = new System.Drawing.Size(73, 14);
			this.lblFromEmp.TabIndex = 0;
			// 
			// lblToEmp
			// 
			this.lblToEmp.AllowDrop = true;
			this.lblToEmp.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblToEmp.Text = "To Employee";
			this.lblToEmp.Location = new System.Drawing.Point(4, 65);
			// // this.lblToEmp.mLabelId = 1915;
			this.lblToEmp.Name = "lblToEmp";
			this.lblToEmp.Size = new System.Drawing.Size(61, 14);
			this.lblToEmp.TabIndex = 7;
			// 
			// txtToEmp
			// 
			this.txtToEmp.AllowDrop = true;
			this.txtToEmp.BackColor = System.Drawing.Color.White;
			// this.txtToEmp.bolAllowDecimal = false;
			this.txtToEmp.ForeColor = System.Drawing.Color.Black;
			this.txtToEmp.Location = new System.Drawing.Point(102, 63);
			// this.txtToEmp.mDropDownType = (System.Windows.Forms.TextBox.DropDownTypes) 0;
			this.txtToEmp.Name = "txtToEmp";
			// this.txtToEmp.ShowButton = true;
			this.txtToEmp.Size = new System.Drawing.Size(121, 19);
			this.txtToEmp.TabIndex = 2;
			this.txtToEmp.Text = "";
			// this.this.txtToEmp.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtToEmp_DropButtonClick);
			// this.txtToEmp.Leave += new System.EventHandler(this.txtToEmp_Leave);
			// 
			// System.Windows.Forms.Label1
			// 
			this.Label1.AllowDrop = true;
			this.Label1.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.Label1.Text = "Month";
			this.Label1.Location = new System.Drawing.Point(4, 88);
			// this.Label1.mLabelId = 1145;
			this.Label1.Name = "System.Windows.Forms.Label1";
			this.Label1.Size = new System.Drawing.Size(29, 14);
			this.Label1.TabIndex = 8;
			// 
			// txtFrmEmpCodeName
			// 
			this.txtFrmEmpCodeName.AllowDrop = true;
			this.txtFrmEmpCodeName.BackColor = System.Drawing.SystemColors.Window;
			this.txtFrmEmpCodeName.Enabled = false;
			this.txtFrmEmpCodeName.Location = new System.Drawing.Point(226, 42);
			this.txtFrmEmpCodeName.Name = "txtFrmEmpCodeName";
			this.txtFrmEmpCodeName.Size = new System.Drawing.Size(191, 19);
			this.txtFrmEmpCodeName.TabIndex = 9;
			// 
			// txtToEmpCodeName
			// 
			this.txtToEmpCodeName.AllowDrop = true;
			this.txtToEmpCodeName.BackColor = System.Drawing.SystemColors.Window;
			this.txtToEmpCodeName.Enabled = false;
			this.txtToEmpCodeName.Location = new System.Drawing.Point(226, 63);
			this.txtToEmpCodeName.Name = "txtToEmpCodeName";
			this.txtToEmpCodeName.Size = new System.Drawing.Size(191, 19);
			this.txtToEmpCodeName.TabIndex = 10;
			// 
			// System.Windows.Forms.Label2
			// 
			this.Label2.AllowDrop = true;
			this.Label2.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.Label2.Text = "Employee Complete";
			this.Label2.Location = new System.Drawing.Point(4, 110);
			this.Label2.Name = "System.Windows.Forms.Label2";
			this.Label2.Size = new System.Drawing.Size(93, 14);
			this.Label2.TabIndex = 11;
			// 
			// txtMonth
			// 
			this.txtMonth.AllowDrop = true;
			this.txtMonth.CenturyMode = TDBDate6.dbiCenturyModeConst.dbiDateWindow;
			// this.txtMonth.CheckDateRange = false;
			this.txtMonth.Location = new System.Drawing.Point(102, 84);
			// this.txtMonth.MaxDate = 51501;
			// this.txtMonth.MinDate = 14246;
			this.txtMonth.Name = "txtMonth";
			this.txtMonth.Size = new System.Drawing.Size(121, 19);
			this.txtMonth.TabIndex = 13;
			this.txtMonth.Text = "06/04/2003";
			// this.txtMonth.Value = 37717;
			// 
			// frmPayEmailPS
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.ClientSize = new System.Drawing.Size(426, 172);
			this.Controls.Add(this.ChkIncludeSentEmployee);
			this.Controls.Add(this.txtEmployeeComplete);
			this.Controls.Add(this.chkAllEmployees);
			this.Controls.Add(this.cmdCancel);
			this.Controls.Add(this.cmdOk);
			this.Controls.Add(this.txtFromEmp);
			this.Controls.Add(this.lblFromEmp);
			this.Controls.Add(this.lblToEmp);
			this.Controls.Add(this.txtToEmp);
			this.Controls.Add(this.Label1);
			this.Controls.Add(this.txtFrmEmpCodeName);
			this.Controls.Add(this.txtToEmpCodeName);
			this.Controls.Add(this.Label2);
			this.Controls.Add(this.txtMonth);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			//this.Icon = (System.Drawing.Icon) resources.GetObject("frmPayEmailPS.Icon");
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(237, 193);
			this.MaximizeBox = true;
			this.MinimizeBox = true;
			this.Name = "frmPayEmailPS";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Employee Payslip Emailing System";
			// this.Activated += new System.EventHandler(this.frmPayEmailPS_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
			// this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
			this.ResumeLayout(false);
		}
		// 
		#endregion
	}
}//ENDSHERE
