
namespace Xtreme
{
	partial class frmPayEmployeeRenewContract
	{

		#region "Upgrade Support "
		private static frmPayEmployeeRenewContract m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmPayEmployeeRenewContract DefInstance
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
		public static frmPayEmployeeRenewContract CreateInstance()
		{
			frmPayEmployeeRenewContract theInstance = new frmPayEmployeeRenewContract();
			
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
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "txtNewContractPeriod", "_lblCommonLabel_2", "_lblCommonLabel_0", "_lblCommonLabel_1", "_txtCommonTextBox_1", "_txtDisplayLabel_4", "_txtDisplayLabel_3", "_txtDisplayLabel_2", "_txtDisplayLabel_1", "_txtDisplayLabel_0", "_lblCommonLabel_3", "_lblCommonLabel_4", "_lblCommonLabel_5", "txtContractStartDate", "txtContractEndDate", "lblCommonLabel", "txtCommonTextBox", "txtDisplayLabel"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public System.Windows.Forms.TextBox txtNewContractPeriod;
		private System.Windows.Forms.Label _lblCommonLabel_2;
		private System.Windows.Forms.Label _lblCommonLabel_0;
		private System.Windows.Forms.Label _lblCommonLabel_1;
		private System.Windows.Forms.TextBox _txtCommonTextBox_1;
		private System.Windows.Forms.Label _txtDisplayLabel_4;
		private System.Windows.Forms.Label _txtDisplayLabel_3;
		private System.Windows.Forms.Label _txtDisplayLabel_2;
		private System.Windows.Forms.Label _txtDisplayLabel_1;
		private System.Windows.Forms.Label _txtDisplayLabel_0;
		private System.Windows.Forms.Label _lblCommonLabel_3;
		private System.Windows.Forms.Label _lblCommonLabel_4;
		private System.Windows.Forms.Label _lblCommonLabel_5;
		public Syncfusion.WinForms.Input.SfDateTimeEdit txtContractStartDate;
		public Syncfusion.WinForms.Input.SfDateTimeEdit txtContractEndDate;
		public System.Windows.Forms.Label[] lblCommonLabel = new System.Windows.Forms.Label[6];
		public System.Windows.Forms.TextBox[] txtCommonTextBox = new System.Windows.Forms.TextBox[2];
		public System.Windows.Forms.Label[] txtDisplayLabel = new System.Windows.Forms.Label[5];
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPayEmployeeRenewContract));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this.txtNewContractPeriod = new System.Windows.Forms.TextBox();
			this._lblCommonLabel_2 = new System.Windows.Forms.Label();
			this._lblCommonLabel_0 = new System.Windows.Forms.Label();
			this._lblCommonLabel_1 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_1 = new System.Windows.Forms.TextBox();
			this._txtDisplayLabel_4 = new System.Windows.Forms.Label();
			this._txtDisplayLabel_3 = new System.Windows.Forms.Label();
			this._txtDisplayLabel_2 = new System.Windows.Forms.Label();
			this._txtDisplayLabel_1 = new System.Windows.Forms.Label();
			this._txtDisplayLabel_0 = new System.Windows.Forms.Label();
			this._lblCommonLabel_3 = new System.Windows.Forms.Label();
			this._lblCommonLabel_4 = new System.Windows.Forms.Label();
			this._lblCommonLabel_5 = new System.Windows.Forms.Label();
			this.txtContractStartDate = new Syncfusion.WinForms.Input.SfDateTimeEdit();
			this.txtContractEndDate = new Syncfusion.WinForms.Input.SfDateTimeEdit();
			this.SuspendLayout();
			// 
			// txtNewContractPeriod
			// 
			this.txtNewContractPeriod.AllowDrop = true;
			this.txtNewContractPeriod.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtNewContractPeriod.Location = new System.Drawing.Point(120, 142);
			this.txtNewContractPeriod.Name = "txtNewContractPeriod";
			this.txtNewContractPeriod.Size = new System.Drawing.Size(123, 21);
			this.txtNewContractPeriod.TabIndex = 14;
			// 
			// _lblCommonLabel_2
			// 
			this._lblCommonLabel_2.AllowDrop = true;
			this._lblCommonLabel_2.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_2.Text = "Employee Code";
			this._lblCommonLabel_2.Location = new System.Drawing.Point(4, 57);
			// this._lblCommonLabel_2.mLabelId = 236;
			this._lblCommonLabel_2.Name = "_lblCommonLabel_2";
			this._lblCommonLabel_2.Size = new System.Drawing.Size(74, 14);
			this._lblCommonLabel_2.TabIndex = 1;
			// 
			// _lblCommonLabel_0
			// 
			this._lblCommonLabel_0.AllowDrop = true;
			this._lblCommonLabel_0.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_0.Text = "Department Code";
			this._lblCommonLabel_0.Location = new System.Drawing.Point(4, 77);
			// this._lblCommonLabel_0.mLabelId = 1973;
			this._lblCommonLabel_0.Name = "_lblCommonLabel_0";
			this._lblCommonLabel_0.Size = new System.Drawing.Size(83, 14);
			this._lblCommonLabel_0.TabIndex = 2;
			// 
			// _lblCommonLabel_1
			// 
			this._lblCommonLabel_1.AllowDrop = true;
			this._lblCommonLabel_1.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_1.Text = "Designation Code";
			this._lblCommonLabel_1.Location = new System.Drawing.Point(4, 98);
			// this._lblCommonLabel_1.mLabelId = 1049;
			this._lblCommonLabel_1.Name = "_lblCommonLabel_1";
			this._lblCommonLabel_1.Size = new System.Drawing.Size(84, 14);
			this._lblCommonLabel_1.TabIndex = 3;
			// 
			// _txtCommonTextBox_1
			// 
			this._txtCommonTextBox_1.AllowDrop = true;
			this._txtCommonTextBox_1.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_1.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_1.Location = new System.Drawing.Point(120, 54);
			this._txtCommonTextBox_1.MaxLength = 10;
			this._txtCommonTextBox_1.Name = "_txtCommonTextBox_1";
			// this._txtCommonTextBox_1.ShowButton = true;
			this._txtCommonTextBox_1.Size = new System.Drawing.Size(101, 19);
			this._txtCommonTextBox_1.TabIndex = 0;
			this._txtCommonTextBox_1.Text = "";
			// this.this._txtCommonTextBox_1.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_1.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _txtDisplayLabel_4
			// 
			this._txtDisplayLabel_4.AllowDrop = true;
			this._txtDisplayLabel_4.Location = new System.Drawing.Point(223, 54);
			this._txtDisplayLabel_4.Name = "_txtDisplayLabel_4";
			this._txtDisplayLabel_4.Size = new System.Drawing.Size(263, 19);
			this._txtDisplayLabel_4.TabIndex = 4;
			this._txtDisplayLabel_4.TabStop = false;
			// 
			// _txtDisplayLabel_3
			// 
			this._txtDisplayLabel_3.AllowDrop = true;
			this._txtDisplayLabel_3.Location = new System.Drawing.Point(223, 96);
			this._txtDisplayLabel_3.Name = "_txtDisplayLabel_3";
			this._txtDisplayLabel_3.Size = new System.Drawing.Size(263, 19);
			this._txtDisplayLabel_3.TabIndex = 5;
			this._txtDisplayLabel_3.TabStop = false;
			// 
			// _txtDisplayLabel_2
			// 
			this._txtDisplayLabel_2.AllowDrop = true;
			this._txtDisplayLabel_2.Location = new System.Drawing.Point(120, 96);
			this._txtDisplayLabel_2.Name = "_txtDisplayLabel_2";
			this._txtDisplayLabel_2.Size = new System.Drawing.Size(101, 19);
			this._txtDisplayLabel_2.TabIndex = 6;
			this._txtDisplayLabel_2.TabStop = false;
			// 
			// _txtDisplayLabel_1
			// 
			this._txtDisplayLabel_1.AllowDrop = true;
			this._txtDisplayLabel_1.Location = new System.Drawing.Point(223, 75);
			this._txtDisplayLabel_1.Name = "_txtDisplayLabel_1";
			this._txtDisplayLabel_1.Size = new System.Drawing.Size(263, 19);
			this._txtDisplayLabel_1.TabIndex = 7;
			this._txtDisplayLabel_1.TabStop = false;
			// 
			// _txtDisplayLabel_0
			// 
			this._txtDisplayLabel_0.AllowDrop = true;
			this._txtDisplayLabel_0.Location = new System.Drawing.Point(120, 75);
			this._txtDisplayLabel_0.Name = "_txtDisplayLabel_0";
			this._txtDisplayLabel_0.Size = new System.Drawing.Size(101, 19);
			this._txtDisplayLabel_0.TabIndex = 8;
			this._txtDisplayLabel_0.TabStop = false;
			// 
			// _lblCommonLabel_3
			// 
			this._lblCommonLabel_3.AllowDrop = true;
			this._lblCommonLabel_3.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_3.Text = "Start Date";
			this._lblCommonLabel_3.Location = new System.Drawing.Point(4, 122);
			// this._lblCommonLabel_3.mLabelId = 1703;
			this._lblCommonLabel_3.Name = "_lblCommonLabel_3";
			this._lblCommonLabel_3.Size = new System.Drawing.Size(48, 14);
			this._lblCommonLabel_3.TabIndex = 9;
			// 
			// _lblCommonLabel_4
			// 
			this._lblCommonLabel_4.AllowDrop = true;
			this._lblCommonLabel_4.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_4.Text = "End Date";
			this._lblCommonLabel_4.Location = new System.Drawing.Point(264, 122);
			// this._lblCommonLabel_4.mLabelId = 1407;
			this._lblCommonLabel_4.Name = "_lblCommonLabel_4";
			this._lblCommonLabel_4.Size = new System.Drawing.Size(43, 14);
			this._lblCommonLabel_4.TabIndex = 10;
			// 
			// _lblCommonLabel_5
			// 
			this._lblCommonLabel_5.AllowDrop = true;
			this._lblCommonLabel_5.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_5.Text = "New Contract Period";
			this._lblCommonLabel_5.Location = new System.Drawing.Point(4, 145);
			// this._lblCommonLabel_5.mLabelId = 2148;
			this._lblCommonLabel_5.Name = "_lblCommonLabel_5";
			this._lblCommonLabel_5.Size = new System.Drawing.Size(100, 14);
			this._lblCommonLabel_5.TabIndex = 11;
			// 
			// txtContractStartDate
			// 
			this.txtContractStartDate.AllowDrop = true;
			this.txtContractStartDate.BackColor = System.Drawing.Color.FromArgb(239, 239, 239);
			this.txtContractStartDate.CausesValidation = false;
			// this.txtContractStartDate.CheckDateRange = false;
			this.txtContractStartDate.Enabled = false;
			this.txtContractStartDate.Location = new System.Drawing.Point(120, 118);
			// this.txtContractStartDate.MaxDate = 2958465;
			// this.txtContractStartDate.MinDate = -657434;
			this.txtContractStartDate.Name = "txtContractStartDate";
			this.txtContractStartDate.PromptChar = "_";
			this.txtContractStartDate.Size = new System.Drawing.Size(123, 21);
			this.txtContractStartDate.TabIndex = 12;
			this.txtContractStartDate.Text = "09/02/2013";
			// 
			// txtContractEndDate
			// 
			this.txtContractEndDate.AllowDrop = true;
			this.txtContractEndDate.BackColor = System.Drawing.Color.White;
			// this.txtContractEndDate.CheckDateRange = false;
			this.txtContractEndDate.Location = new System.Drawing.Point(343, 118);
			// this.txtContractEndDate.MaxDate = 2958465;
			// this.txtContractEndDate.MinDate = -657434;
			this.txtContractEndDate.Name = "txtContractEndDate";
			this.txtContractEndDate.PromptChar = "_";
			this.txtContractEndDate.Size = new System.Drawing.Size(143, 21);
			this.txtContractEndDate.TabIndex = 13;
			this.txtContractEndDate.Text = "09/02/2013";
			// 
			// frmPayEmployeeRenewContract
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.ClientSize = new System.Drawing.Size(503, 178);
			this.Controls.Add(this.txtNewContractPeriod);
			this.Controls.Add(this._lblCommonLabel_2);
			this.Controls.Add(this._lblCommonLabel_0);
			this.Controls.Add(this._lblCommonLabel_1);
			this.Controls.Add(this._txtCommonTextBox_1);
			this.Controls.Add(this._txtDisplayLabel_4);
			this.Controls.Add(this._txtDisplayLabel_3);
			this.Controls.Add(this._txtDisplayLabel_2);
			this.Controls.Add(this._txtDisplayLabel_1);
			this.Controls.Add(this._txtDisplayLabel_0);
			this.Controls.Add(this._lblCommonLabel_3);
			this.Controls.Add(this._lblCommonLabel_4);
			this.Controls.Add(this._lblCommonLabel_5);
			this.Controls.Add(this.txtContractStartDate);
			this.Controls.Add(this.txtContractEndDate);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			//this.Icon = (System.Drawing.Icon) resources.GetObject("frmPayEmployeeRenewContract.Icon");
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(185, 226);
			this.MaximizeBox = true;
			this.MinimizeBox = true;
			this.Name = "frmPayEmployeeRenewContract";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Renew Contract";
			// this.Activated += new System.EventHandler(this.frmPayEmployeeRenewContract_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
			// this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
			this.ResumeLayout(false);
		}
		void ReLoadForm(bool addEvents)
		{
			InitializetxtDisplayLabel();
			InitializetxtCommonTextBox();
			InitializelblCommonLabel();
			//This form is an MDI child.
			//This code simulates the VB6 
			// functionality of automatically
			// loading and showing an MDI
			// child's parent.
			this.MdiParent = Xtreme.frmSysMain.DefInstance;
			Xtreme.frmSysMain.DefInstance.Show();
		}
		void InitializetxtDisplayLabel()
		{
			this.txtDisplayLabel = new System.Windows.Forms.Label[5];
			this.txtDisplayLabel[4] = _txtDisplayLabel_4;
			this.txtDisplayLabel[3] = _txtDisplayLabel_3;
			this.txtDisplayLabel[2] = _txtDisplayLabel_2;
			this.txtDisplayLabel[1] = _txtDisplayLabel_1;
			this.txtDisplayLabel[0] = _txtDisplayLabel_0;
		}
		void InitializetxtCommonTextBox()
		{
			this.txtCommonTextBox = new System.Windows.Forms.TextBox[2];
			this.txtCommonTextBox[1] = _txtCommonTextBox_1;
		}
		void InitializelblCommonLabel()
		{
			this.lblCommonLabel = new System.Windows.Forms.Label[6];
			this.lblCommonLabel[2] = _lblCommonLabel_2;
			this.lblCommonLabel[0] = _lblCommonLabel_0;
			this.lblCommonLabel[1] = _lblCommonLabel_1;
			this.lblCommonLabel[3] = _lblCommonLabel_3;
			this.lblCommonLabel[4] = _lblCommonLabel_4;
			this.lblCommonLabel[5] = _lblCommonLabel_5;
		}
		#endregion
	}
}