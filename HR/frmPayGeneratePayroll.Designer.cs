
namespace Xtreme
{
	partial class frmPayGeneratePayroll
	{

		#region "Upgrade Support "
		private static frmPayGeneratePayroll m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmPayGeneratePayroll DefInstance
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
		public static frmPayGeneratePayroll CreateInstance()
		{
			frmPayGeneratePayroll theInstance = new frmPayGeneratePayroll();
			
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
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "chkClearPayroll", "txtGeneratedEmployee", "chkGenerateAll", "_txtCommonTextBox_0", "_lblCommonLabel_2", "_txtCommonTextBox_1", "_lblCommonLabel_0", "cmdOKCancel", "_txtDisplayLabel_1", "_txtDisplayLabel_0", "cmdPostMode", "lblCommonLabel", "txtCommonTextBox", "txtDisplayLabel"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public System.Windows.Forms.CheckBox chkClearPayroll;
		public System.Windows.Forms.TextBox txtGeneratedEmployee;
		public System.Windows.Forms.CheckBox chkGenerateAll;
		private System.Windows.Forms.TextBox _txtCommonTextBox_0;
		private System.Windows.Forms.Label _lblCommonLabel_2;
		private System.Windows.Forms.TextBox _txtCommonTextBox_1;
		private System.Windows.Forms.Label _lblCommonLabel_0;
		public UCOkCancel cmdOKCancel;
		private System.Windows.Forms.Label _txtDisplayLabel_1;
		private System.Windows.Forms.Label _txtDisplayLabel_0;
		public UCOkCancel cmdPostMode;
		public System.Windows.Forms.Label[] lblCommonLabel = new System.Windows.Forms.Label[3];
		public System.Windows.Forms.TextBox[] txtCommonTextBox = new System.Windows.Forms.TextBox[2];
		public System.Windows.Forms.Label[] txtDisplayLabel = new System.Windows.Forms.Label[2];
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPayGeneratePayroll));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this.chkClearPayroll = new System.Windows.Forms.CheckBox();
			this.txtGeneratedEmployee = new System.Windows.Forms.TextBox();
			this.chkGenerateAll = new System.Windows.Forms.CheckBox();
			this._txtCommonTextBox_0 = new System.Windows.Forms.TextBox();
			this._lblCommonLabel_2 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_1 = new System.Windows.Forms.TextBox();
			this._lblCommonLabel_0 = new System.Windows.Forms.Label();
			this.cmdOKCancel = new UCOkCancel();
			this._txtDisplayLabel_1 = new System.Windows.Forms.Label();
			this._txtDisplayLabel_0 = new System.Windows.Forms.Label();
			this.cmdPostMode = new UCOkCancel();
			this.SuspendLayout();
			// 
			// chkClearPayroll
			// 
			this.chkClearPayroll.AllowDrop = true;
			this.chkClearPayroll.Appearance = System.Windows.Forms.Appearance.Normal;
			this.chkClearPayroll.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.chkClearPayroll.CausesValidation = true;
			this.chkClearPayroll.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkClearPayroll.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this.chkClearPayroll.Enabled = true;
			this.chkClearPayroll.ForeColor = System.Drawing.SystemColors.ControlText;
			this.chkClearPayroll.Location = new System.Drawing.Point(120, 84);
			this.chkClearPayroll.Name = "chkClearPayroll";
			this.chkClearPayroll.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.chkClearPayroll.Size = new System.Drawing.Size(161, 21);
			this.chkClearPayroll.TabIndex = 3;
			this.chkClearPayroll.TabStop = true;
			this.chkClearPayroll.Text = "Clear Payroll";
			this.chkClearPayroll.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkClearPayroll.Visible = true;
			// 
			// txtGeneratedEmployee
			// 
			this.txtGeneratedEmployee.AcceptsReturn = true;
			this.txtGeneratedEmployee.AllowDrop = true;
			this.txtGeneratedEmployee.BackColor = System.Drawing.SystemColors.Window;
			this.txtGeneratedEmployee.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.txtGeneratedEmployee.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtGeneratedEmployee.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtGeneratedEmployee.Location = new System.Drawing.Point(6, 166);
			this.txtGeneratedEmployee.MaxLength = 0;
			this.txtGeneratedEmployee.Multiline = true;
			this.txtGeneratedEmployee.Name = "txtGeneratedEmployee";
			this.txtGeneratedEmployee.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtGeneratedEmployee.Size = new System.Drawing.Size(419, 95);
			this.txtGeneratedEmployee.TabIndex = 10;
			this.txtGeneratedEmployee.Text = "Text1";
			this.txtGeneratedEmployee.Visible = false;
			// 
			// chkGenerateAll
			// 
			this.chkGenerateAll.AllowDrop = true;
			this.chkGenerateAll.Appearance = System.Windows.Forms.Appearance.Normal;
			this.chkGenerateAll.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.chkGenerateAll.CausesValidation = true;
			this.chkGenerateAll.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkGenerateAll.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this.chkGenerateAll.Enabled = true;
			this.chkGenerateAll.ForeColor = System.Drawing.SystemColors.ControlText;
			this.chkGenerateAll.Location = new System.Drawing.Point(120, 58);
			this.chkGenerateAll.Name = "chkGenerateAll";
			this.chkGenerateAll.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.chkGenerateAll.Size = new System.Drawing.Size(161, 21);
			this.chkGenerateAll.TabIndex = 2;
			this.chkGenerateAll.TabStop = true;
			this.chkGenerateAll.Text = "Generate All";
			this.chkGenerateAll.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkGenerateAll.Visible = true;
			this.chkGenerateAll.CheckStateChanged += new System.EventHandler(this.chkGenerateAll_CheckStateChanged);
			// 
			// _txtCommonTextBox_0
			// 
			this._txtCommonTextBox_0.AllowDrop = true;
			this._txtCommonTextBox_0.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_0.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_0.Location = new System.Drawing.Point(119, 14);
			this._txtCommonTextBox_0.MaxLength = 10;
			this._txtCommonTextBox_0.Name = "_txtCommonTextBox_0";
			// this._txtCommonTextBox_0.ShowButton = true;
			this._txtCommonTextBox_0.Size = new System.Drawing.Size(101, 19);
			this._txtCommonTextBox_0.TabIndex = 0;
			this._txtCommonTextBox_0.Text = "";
			// this.// = "";
			// this.this._txtCommonTextBox_0.Change += new System.Windows.Forms.TextBox.ChangeHandler(this.txtCommonTextBox_Change);
			// this.//this._txtCommonTextBox_0.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(//this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_0.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _lblCommonLabel_2
			// 
			this._lblCommonLabel_2.AllowDrop = true;
			this._lblCommonLabel_2.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_2.Text = "From Employee Code";
			this._lblCommonLabel_2.Location = new System.Drawing.Point(12, 16);
			// // this._lblCommonLabel_2.mLabelId = 1120;
			this._lblCommonLabel_2.Name = "_lblCommonLabel_2";
			this._lblCommonLabel_2.Size = new System.Drawing.Size(101, 14);
			this._lblCommonLabel_2.TabIndex = 6;
			// 
			// _txtCommonTextBox_1
			// 
			this._txtCommonTextBox_1.AllowDrop = true;
			this._txtCommonTextBox_1.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_1.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_1.Location = new System.Drawing.Point(119, 34);
			this._txtCommonTextBox_1.MaxLength = 10;
			this._txtCommonTextBox_1.Name = "_txtCommonTextBox_1";
			// this._txtCommonTextBox_1.ShowButton = true;
			this._txtCommonTextBox_1.Size = new System.Drawing.Size(101, 19);
			this._txtCommonTextBox_1.TabIndex = 1;
			this._txtCommonTextBox_1.Text = "";
			// this.// = "";
			// this.this._txtCommonTextBox_1.Change += new System.Windows.Forms.TextBox.ChangeHandler(this.txtCommonTextBox_Change);
			// this.//this._txtCommonTextBox_1.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(//this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_1.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _lblCommonLabel_0
			// 
			this._lblCommonLabel_0.AllowDrop = true;
			this._lblCommonLabel_0.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_0.Text = "To Employee Code";
			this._lblCommonLabel_0.Location = new System.Drawing.Point(12, 36);
			// // this._lblCommonLabel_0.mLabelId = 1121;
			this._lblCommonLabel_0.Name = "_lblCommonLabel_0";
			this._lblCommonLabel_0.Size = new System.Drawing.Size(89, 14);
			this._lblCommonLabel_0.TabIndex = 7;
			// 
			// cmdOKCancel
			// 
			this.cmdOKCancel.AllowDrop = true;
			this.cmdOKCancel.DisplayButton = 0;
			this.cmdOKCancel.Location = new System.Drawing.Point(160, 115);
			this.cmdOKCancel.Name = "cmdOKCancel";
			this.cmdOKCancel.OkCaption = "&Generate";
			this.cmdOKCancel.Size = new System.Drawing.Size(206, 31);
			this.cmdOKCancel.TabIndex = 4;
			//this.cmdOKCancel.CancelClick += new UCOkCancel.CancelClickHandler(this.cmdOKCancel_CancelClick);
			//this.cmdOKCancel.OKClick += new UCOkCancel.OKClickHandler(this.cmdOKCancel_OKClick);
			// 
			// _txtDisplayLabel_1
			// 
			this._txtDisplayLabel_1.AllowDrop = true;
			this._txtDisplayLabel_1.Location = new System.Drawing.Point(222, 34);
			this._txtDisplayLabel_1.Name = "_txtDisplayLabel_1";
			this._txtDisplayLabel_1.Size = new System.Drawing.Size(201, 19);
			this._txtDisplayLabel_1.TabIndex = 8;
			// 
			// _txtDisplayLabel_0
			// 
			this._txtDisplayLabel_0.AllowDrop = true;
			this._txtDisplayLabel_0.Location = new System.Drawing.Point(222, 14);
			this._txtDisplayLabel_0.Name = "_txtDisplayLabel_0";
			this._txtDisplayLabel_0.Size = new System.Drawing.Size(201, 19);
			this._txtDisplayLabel_0.TabIndex = 9;
			// 
			// cmdPostMode
			// 
			this.cmdPostMode.AllowDrop = true;
			this.cmdPostMode.DisplayButton = 1;
			this.cmdPostMode.Location = new System.Drawing.Point(0, 115);
			this.cmdPostMode.Name = "cmdPostMode";
			this.cmdPostMode.OkCaption = "&Advanced Mode >>";
			this.cmdPostMode.Size = new System.Drawing.Size(205, 29);
			this.cmdPostMode.TabIndex = 5;
			this.cmdPostMode.Visible = false;
			this.cmdPostMode.OKClick += new UCOkCancel.OKClickHandler(this.cmdPostMode_OKClick);
			// 
			// frmPayGeneratePayroll
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.ClientSize = new System.Drawing.Size(435, 266);
			this.Controls.Add(this.chkClearPayroll);
			this.Controls.Add(this.txtGeneratedEmployee);
			this.Controls.Add(this.chkGenerateAll);
			this.Controls.Add(this._txtCommonTextBox_0);
			this.Controls.Add(this._lblCommonLabel_2);
			this.Controls.Add(this._txtCommonTextBox_1);
			this.Controls.Add(this._lblCommonLabel_0);
			this.Controls.Add(this.cmdOKCancel);
			this.Controls.Add(this._txtDisplayLabel_1);
			this.Controls.Add(this._txtDisplayLabel_0);
			this.Controls.Add(this.cmdPostMode);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			//this.Icon = (System.Drawing.Icon) resources.GetObject("frmPayGeneratePayroll.Icon");
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(318, 145);
			this.MaximizeBox = true;
			this.MinimizeBox = true;
			this.Name = "frmPayGeneratePayroll";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Generate Payroll";
			// this.Activated += new System.EventHandler(this.Form_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
			// this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
			this.ResumeLayout(false);
		}
		// 
		void InitializetxtDisplayLabel()
		{
			this.txtDisplayLabel = new System.Windows.Forms.Label[2];
			this.txtDisplayLabel[1] = _txtDisplayLabel_1;
			this.txtDisplayLabel[0] = _txtDisplayLabel_0;
		}
		void InitializetxtCommonTextBox()
		{
			this.txtCommonTextBox = new System.Windows.Forms.TextBox[2];
			this.txtCommonTextBox[0] = _txtCommonTextBox_0;
			this.txtCommonTextBox[1] = _txtCommonTextBox_1;
		}
		void InitializelblCommonLabel()
		{
			this.lblCommonLabel = new System.Windows.Forms.Label[3];
			this.lblCommonLabel[2] = _lblCommonLabel_2;
			this.lblCommonLabel[0] = _lblCommonLabel_0;
		}
		#endregion
	}
}//ENDSHERE
