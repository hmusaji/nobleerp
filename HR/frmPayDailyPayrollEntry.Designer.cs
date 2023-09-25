
namespace Xtreme
{
	partial class frmPayDailyPayrollEntry
	{

		#region "Upgrade Support "
		private static frmPayDailyPayrollEntry m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmPayDailyPayrollEntry DefInstance
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
		public static frmPayDailyPayrollEntry CreateInstance()
		{
			frmPayDailyPayrollEntry theInstance = new frmPayDailyPayrollEntry();
			
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
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "txtPayDate", "_lblCommonLabel_2", "_txtDisplayLabel_1", "txtEmployeeCode", "_lblCommonLabel_3", "_lblCommonLabel_4", "_txtDisplayLabel_2", "Column_0_grdVoucherDetails", "Column_1_grdVoucherDetails", "grdVoucherDetails", "_lblCommonLabel_0", "_txtDisplayLabel_3", "Line1", "lblCommonLabel", "txtDisplayLabel"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public Syncfusion.WinForms.Input.SfDateTimeEdit txtPayDate;
		private System.Windows.Forms.Label _lblCommonLabel_2;
		private System.Windows.Forms.Label _txtDisplayLabel_1;
		public System.Windows.Forms.TextBox txtEmployeeCode;
		private System.Windows.Forms.Label _lblCommonLabel_3;
		private System.Windows.Forms.Label _lblCommonLabel_4;
		private System.Windows.Forms.Label _txtDisplayLabel_2;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_0_grdVoucherDetails;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_1_grdVoucherDetails;
		public C1.Win.C1TrueDBGrid.C1TrueDBGrid grdVoucherDetails;
		private System.Windows.Forms.Label _lblCommonLabel_0;
		private System.Windows.Forms.Label _txtDisplayLabel_3;
		public System.Windows.Forms.Label Line1;
		public System.Windows.Forms.Label[] lblCommonLabel = new System.Windows.Forms.Label[5];
		public System.Windows.Forms.Label[] txtDisplayLabel = new System.Windows.Forms.Label[4];
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPayDailyPayrollEntry));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this.txtPayDate = new Syncfusion.WinForms.Input.SfDateTimeEdit();
			this._lblCommonLabel_2 = new System.Windows.Forms.Label();
			this._txtDisplayLabel_1 = new System.Windows.Forms.Label();
			this.txtEmployeeCode = new System.Windows.Forms.TextBox();
			this._lblCommonLabel_3 = new System.Windows.Forms.Label();
			this._lblCommonLabel_4 = new System.Windows.Forms.Label();
			this._txtDisplayLabel_2 = new System.Windows.Forms.Label();
			this.grdVoucherDetails = new C1.Win.C1TrueDBGrid.C1TrueDBGrid();
			this.Column_0_grdVoucherDetails = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.Column_1_grdVoucherDetails = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this._lblCommonLabel_0 = new System.Windows.Forms.Label();
			this._txtDisplayLabel_3 = new System.Windows.Forms.Label();
			this.Line1 = new System.Windows.Forms.Label();
			this.grdVoucherDetails.SuspendLayout();
			this.SuspendLayout();
			// 
			// txtPayDate
			// 
			this.txtPayDate.AllowDrop = true;
			// this.txtPayDate.CheckDateRange = false;
			this.txtPayDate.Location = new System.Drawing.Point(98, 89);
			// this.txtPayDate.MaxDate = 2958465;
			// this.txtPayDate.MinDate = -657434;
			this.txtPayDate.Name = "txtPayDate";
			this.txtPayDate.PromptChar = "_";
			this.txtPayDate.Size = new System.Drawing.Size(105, 19);
			this.txtPayDate.TabIndex = 1;
			this.txtPayDate.Text = "01/07/2011";
			this.txtPayDate.Value = 40725;
			// this.txtPayDate.Leave += new System.EventHandler(this.txtPayDate_Leave);
			// 
			// _lblCommonLabel_2
			// 
			this._lblCommonLabel_2.AllowDrop = true;
			this._lblCommonLabel_2.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_2.Text = "Employee Code";
			this._lblCommonLabel_2.Location = new System.Drawing.Point(10, 71);
			// this._lblCommonLabel_2.mLabelId = 236;
			this._lblCommonLabel_2.Name = "_lblCommonLabel_2";
			this._lblCommonLabel_2.Size = new System.Drawing.Size(74, 14);
			this._lblCommonLabel_2.TabIndex = 3;
			// 
			// _txtDisplayLabel_1
			// 
			this._txtDisplayLabel_1.AllowDrop = true;
			this._txtDisplayLabel_1.Location = new System.Drawing.Point(205, 68);
			this._txtDisplayLabel_1.Name = "_txtDisplayLabel_1";
			this._txtDisplayLabel_1.Size = new System.Drawing.Size(243, 19);
			this._txtDisplayLabel_1.TabIndex = 4;
			this._txtDisplayLabel_1.TabStop = false;
			// 
			// txtEmployeeCode
			// 
			this.txtEmployeeCode.AllowDrop = true;
			this.txtEmployeeCode.BackColor = System.Drawing.Color.White;
			// this.txtEmployeeCode.bolAllowDecimal = false;
			this.txtEmployeeCode.ForeColor = System.Drawing.Color.Black;
			this.txtEmployeeCode.Location = new System.Drawing.Point(98, 68);
			// this.txtEmployeeCode.mDropDownType = (System.Windows.Forms.TextBox.DropDownTypes) 0;
			this.txtEmployeeCode.Name = "txtEmployeeCode";
			// this.txtEmployeeCode.ShowButton = true;
			this.txtEmployeeCode.Size = new System.Drawing.Size(105, 19);
			this.txtEmployeeCode.TabIndex = 0;
			this.txtEmployeeCode.Text = "";
			// this.this.txtEmployeeCode.Watermark = "";
			// this.this.txtEmployeeCode.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtEmployeeCode_DropButtonClick);
			// this.txtEmployeeCode.Leave += new System.EventHandler(this.txtEmployeeCode_Leave);
			// 
			// _lblCommonLabel_3
			// 
			this._lblCommonLabel_3.AllowDrop = true;
			this._lblCommonLabel_3.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_3.Text = "Date";
			this._lblCommonLabel_3.Location = new System.Drawing.Point(12, 92);
			// this._lblCommonLabel_3.mLabelId = 186;
			this._lblCommonLabel_3.Name = "_lblCommonLabel_3";
			this._lblCommonLabel_3.Size = new System.Drawing.Size(22, 14);
			this._lblCommonLabel_3.TabIndex = 5;
			// 
			// _lblCommonLabel_4
			// 
			this._lblCommonLabel_4.AllowDrop = true;
			this._lblCommonLabel_4.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_4.Text = "Basic Salary";
			this._lblCommonLabel_4.Location = new System.Drawing.Point(560, 70);
			// this._lblCommonLabel_4.mLabelId = 1970;
			this._lblCommonLabel_4.Name = "_lblCommonLabel_4";
			this._lblCommonLabel_4.Size = new System.Drawing.Size(61, 14);
			this._lblCommonLabel_4.TabIndex = 6;
			// 
			// _txtDisplayLabel_2
			// 
			this._txtDisplayLabel_2.AllowDrop = true;
			this._txtDisplayLabel_2.Location = new System.Drawing.Point(648, 68);
			this._txtDisplayLabel_2.Name = "_txtDisplayLabel_2";
			this._txtDisplayLabel_2.Size = new System.Drawing.Size(77, 19);
			this._txtDisplayLabel_2.TabIndex = 7;
			this._txtDisplayLabel_2.TabStop = false;
			// 
			// grdVoucherDetails
			// 
			this.grdVoucherDetails.AllowDrop = true;
			this.grdVoucherDetails.BackColor = System.Drawing.Color.Silver;
			this.grdVoucherDetails.CellTipsWidth = 0;
			this.grdVoucherDetails.Location = new System.Drawing.Point(4, 132);
			this.grdVoucherDetails.Name = "grdVoucherDetails";
			this.grdVoucherDetails.RowDivider.Color = System.Drawing.Color.Silver;
			this.grdVoucherDetails.Size = new System.Drawing.Size(741, 223);
			this.grdVoucherDetails.TabIndex = 2;
			this.grdVoucherDetails.Columns.Add(this.Column_0_grdVoucherDetails);
			this.grdVoucherDetails.Columns.Add(this.Column_1_grdVoucherDetails);
			this.grdVoucherDetails.AfterColUpdate += new C1.Win.C1TrueDBGrid.ColEventHandler(this.grdVoucherDetails_AfterColUpdate);
			this.grdVoucherDetails.BeforeColUpdate += new C1.Win.C1TrueDBGrid.BeforeColUpdateEventHandler(this.grdVoucherDetails_BeforeColUpdate);
			// this.this.grdVoucherDetails.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.grdVoucherDetails_KeyPress);
			this.grdVoucherDetails.MouseUp += new System.Windows.Forms.MouseEventHandler(this.grdVoucherDetails_MouseUp);
			// 
			// Column_0_grdVoucherDetails
			// 
			this.Column_0_grdVoucherDetails.DataField = "";
			this.Column_0_grdVoucherDetails.ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.Normal;
			// 
			// Column_1_grdVoucherDetails
			// 
			this.Column_1_grdVoucherDetails.DataField = "";
			this.Column_1_grdVoucherDetails.ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.Normal;
			// 
			// _lblCommonLabel_0
			// 
			this._lblCommonLabel_0.AllowDrop = true;
			this._lblCommonLabel_0.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_0.Text = "Total Salary";
			this._lblCommonLabel_0.Location = new System.Drawing.Point(560, 91);
			// this._lblCommonLabel_0.mLabelId = 818;
			this._lblCommonLabel_0.Name = "_lblCommonLabel_0";
			this._lblCommonLabel_0.Size = new System.Drawing.Size(57, 14);
			this._lblCommonLabel_0.TabIndex = 8;
			// 
			// _txtDisplayLabel_3
			// 
			this._txtDisplayLabel_3.AllowDrop = true;
			this._txtDisplayLabel_3.Location = new System.Drawing.Point(648, 89);
			this._txtDisplayLabel_3.Name = "_txtDisplayLabel_3";
			this._txtDisplayLabel_3.Size = new System.Drawing.Size(77, 19);
			this._txtDisplayLabel_3.TabIndex = 9;
			this._txtDisplayLabel_3.TabStop = false;
			// 
			// Line1
			// 
			this.Line1.AllowDrop = true;
			this.Line1.BackColor = System.Drawing.SystemColors.WindowText;
			this.Line1.Enabled = false;
			this.Line1.Location = new System.Drawing.Point(2, 122);
			this.Line1.Name = "Line1";
			this.Line1.Size = new System.Drawing.Size(930, 1);
			this.Line1.Visible = true;
			// 
			// frmPayDailyPayrollEntry
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.ClientSize = new System.Drawing.Size(748, 357);
			this.Controls.Add(this.txtPayDate);
			this.Controls.Add(this._lblCommonLabel_2);
			this.Controls.Add(this._txtDisplayLabel_1);
			this.Controls.Add(this.txtEmployeeCode);
			this.Controls.Add(this._lblCommonLabel_3);
			this.Controls.Add(this._lblCommonLabel_4);
			this.Controls.Add(this._txtDisplayLabel_2);
			this.Controls.Add(this.grdVoucherDetails);
			this.Controls.Add(this._lblCommonLabel_0);
			this.Controls.Add(this._txtDisplayLabel_3);
			this.Controls.Add(this.Line1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			//this.Icon = (System.Drawing.Icon) resources.GetObject("frmPayDailyPayrollEntry.Icon");
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(129, 121);
			this.MaximizeBox = true;
			this.MinimizeBox = true;
			this.Name = "frmPayDailyPayrollEntry";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Daily Payroll Entry";
			// this.Activated += new System.EventHandler(this.Form_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
			// this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
			this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Form_KeyPress);
			this.grdVoucherDetails.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		void ReLoadForm(bool addEvents)
		{
			InitializetxtDisplayLabel();
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
			this.txtDisplayLabel = new System.Windows.Forms.Label[4];
			this.txtDisplayLabel[1] = _txtDisplayLabel_1;
			this.txtDisplayLabel[2] = _txtDisplayLabel_2;
			this.txtDisplayLabel[3] = _txtDisplayLabel_3;
		}
		void InitializelblCommonLabel()
		{
			this.lblCommonLabel = new System.Windows.Forms.Label[5];
			this.lblCommonLabel[2] = _lblCommonLabel_2;
			this.lblCommonLabel[3] = _lblCommonLabel_3;
			this.lblCommonLabel[4] = _lblCommonLabel_4;
			this.lblCommonLabel[0] = _lblCommonLabel_0;
		}
		#endregion
	}
}