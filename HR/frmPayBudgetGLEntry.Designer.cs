
namespace Xtreme
{
	partial class frmPayBudgetGLEntry
	{

		#region "Upgrade Support "
		private static frmPayBudgetGLEntry m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmPayBudgetGLEntry DefInstance
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
		public static frmPayBudgetGLEntry CreateInstance()
		{
			frmPayBudgetGLEntry theInstance = new frmPayBudgetGLEntry();
			
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
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "Command1", "_lblCommon_5", "txtDPayrollDate", "_lblCommon_37", "txtCompanyName", "txtCompanyCode", "Column_0_grdVoucherDetails", "Column_1_grdVoucherDetails", "grdVoucherDetails", "_lblCommon_0", "txtDlblBudgetName", "txtBudgetCode", "Line1", "lblCommon"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public System.Windows.Forms.Button Command1;
		private System.Windows.Forms.Label _lblCommon_5;
		public Syncfusion.WinForms.Input.SfDateTimeEdit txtDPayrollDate;
		private System.Windows.Forms.Label _lblCommon_37;
		public System.Windows.Forms.Label txtCompanyName;
		public System.Windows.Forms.TextBox txtCompanyCode;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_0_grdVoucherDetails;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_1_grdVoucherDetails;
		public C1.Win.C1TrueDBGrid.C1TrueDBGrid grdVoucherDetails;
		private System.Windows.Forms.Label _lblCommon_0;
		public System.Windows.Forms.Label txtDlblBudgetName;
		public System.Windows.Forms.TextBox txtBudgetCode;
		public System.Windows.Forms.Label Line1;
		public System.Windows.Forms.Label[] lblCommon = new System.Windows.Forms.Label[38];
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPayBudgetGLEntry));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this.Command1 = new System.Windows.Forms.Button();
			this._lblCommon_5 = new System.Windows.Forms.Label();
			this.txtDPayrollDate = new Syncfusion.WinForms.Input.SfDateTimeEdit();
			this._lblCommon_37 = new System.Windows.Forms.Label();
			this.txtCompanyName = new System.Windows.Forms.Label();
			this.txtCompanyCode = new System.Windows.Forms.TextBox();
			this.grdVoucherDetails = new C1.Win.C1TrueDBGrid.C1TrueDBGrid();
			this.Column_0_grdVoucherDetails = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.Column_1_grdVoucherDetails = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this._lblCommon_0 = new System.Windows.Forms.Label();
			this.txtDlblBudgetName = new System.Windows.Forms.Label();
			this.txtBudgetCode = new System.Windows.Forms.TextBox();
			this.Line1 = new System.Windows.Forms.Label();
			this.grdVoucherDetails.SuspendLayout();
			this.SuspendLayout();
			// 
			// Command1
			// 
			this.Command1.AllowDrop = true;
			this.Command1.BackColor = System.Drawing.SystemColors.Control;
			this.Command1.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Command1.Location = new System.Drawing.Point(196, 51);
			this.Command1.Name = "Command1";
			this.Command1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Command1.Size = new System.Drawing.Size(67, 27);
			this.Command1.TabIndex = 0;
			this.Command1.Text = "Generate";
			this.Command1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.Command1.UseVisualStyleBackColor = false;
			// this.Command1.Click += new System.EventHandler(this.Command1_Click);
			// 
			// _lblCommon_5
			// 
			this._lblCommon_5.AllowDrop = true;
			this._lblCommon_5.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_5.Text = "Payroll Date";
			this._lblCommon_5.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_5.Location = new System.Drawing.Point(12, 56);
			this._lblCommon_5.Name = "_lblCommon_5";
			this._lblCommon_5.Size = new System.Drawing.Size(57, 14);
			this._lblCommon_5.TabIndex = 1;
			// 
			// txtDPayrollDate
			// 
			this.txtDPayrollDate.AllowDrop = true;
			// this.txtDPayrollDate.CheckDateRange = false;
			this.txtDPayrollDate.Location = new System.Drawing.Point(90, 55);
			// this.txtDPayrollDate.MaxDate = 2958465;
			// this.txtDPayrollDate.MinDate = -657434;
			this.txtDPayrollDate.Name = "txtDPayrollDate";
			this.txtDPayrollDate.PromptChar = "_";
			this.txtDPayrollDate.Size = new System.Drawing.Size(101, 19);
			this.txtDPayrollDate.TabIndex = 2;
			// this.txtDPayrollDate.Text = "31/01/2012";
			// this.txtDPayrollDate.Value = 40939;
			// 
			// _lblCommon_37
			// 
			this._lblCommon_37.AllowDrop = true;
			this._lblCommon_37.BackColor = System.Drawing.Color.FromArgb(250, 244, 231);
			this._lblCommon_37.Text = "Company Code";
			this._lblCommon_37.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_37.Location = new System.Drawing.Point(9, 83);
			// // this._lblCommon_37.mLabelId = 1927;
			this._lblCommon_37.Name = "_lblCommon_37";
			this._lblCommon_37.Size = new System.Drawing.Size(73, 14);
			this._lblCommon_37.TabIndex = 3;
			// 
			// txtCompanyName
			// 
			this.txtCompanyName.AllowDrop = true;
			this.txtCompanyName.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.txtCompanyName.Location = new System.Drawing.Point(191, 81);
			this.txtCompanyName.Name = "txtCompanyName";
			this.txtCompanyName.Size = new System.Drawing.Size(371, 19);
			this.txtCompanyName.TabIndex = 4;
			this.txtCompanyName.TabStop = false;
			// 
			// txtCompanyCode
			// 
			this.txtCompanyCode.AllowDrop = true;
			this.txtCompanyCode.BackColor = System.Drawing.Color.White;
			// this.txtCompanyCode.bolNumericOnly = true;
			this.txtCompanyCode.ForeColor = System.Drawing.Color.Black;
			this.txtCompanyCode.Location = new System.Drawing.Point(89, 81);
			this.txtCompanyCode.MaxLength = 8;
			this.txtCompanyCode.Name = "txtCompanyCode";
			// this.txtCompanyCode.ShowButton = true;
			this.txtCompanyCode.Size = new System.Drawing.Size(101, 19);
			this.txtCompanyCode.TabIndex = 5;
			this.txtCompanyCode.Text = "";
			// this.this.txtCompanyCode.Watermark = "";
			// this.this.txtCompanyCode.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCompanyCode_DropButtonClick);
			// this.txtCompanyCode.Leave += new System.EventHandler(this.txtCompanyCode_Leave);
			// 
			// grdVoucherDetails
			// 
			this.grdVoucherDetails.AllowDrop = true;
			this.grdVoucherDetails.BackColor = System.Drawing.Color.FromArgb(212, 208, 200);
			this.grdVoucherDetails.CellTipsWidth = 0;
			this.grdVoucherDetails.Enabled = false;
			this.grdVoucherDetails.Location = new System.Drawing.Point(3, 141);
			this.grdVoucherDetails.Name = "grdVoucherDetails";
			this.grdVoucherDetails.RowDivider.Color = System.Drawing.Color.FromArgb(212, 208, 200);
			this.grdVoucherDetails.Size = new System.Drawing.Size(1107, 345);
			this.grdVoucherDetails.TabIndex = 6;
			this.grdVoucherDetails.Columns.Add(this.Column_0_grdVoucherDetails);
			this.grdVoucherDetails.Columns.Add(this.Column_1_grdVoucherDetails);
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
			// _lblCommon_0
			// 
			this._lblCommon_0.AllowDrop = true;
			this._lblCommon_0.BackColor = System.Drawing.Color.FromArgb(250, 244, 231);
			this._lblCommon_0.Text = "Budget Code";
			this._lblCommon_0.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_0.Location = new System.Drawing.Point(9, 107);
			this._lblCommon_0.Name = "_lblCommon_0";
			this._lblCommon_0.Size = new System.Drawing.Size(62, 14);
			this._lblCommon_0.TabIndex = 7;
			// 
			// txtDlblBudgetName
			// 
			this.txtDlblBudgetName.AllowDrop = true;
			this.txtDlblBudgetName.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.txtDlblBudgetName.Location = new System.Drawing.Point(191, 105);
			this.txtDlblBudgetName.Name = "txtDlblBudgetName";
			this.txtDlblBudgetName.Size = new System.Drawing.Size(371, 19);
			this.txtDlblBudgetName.TabIndex = 8;
			this.txtDlblBudgetName.TabStop = false;
			// 
			// txtBudgetCode
			// 
			this.txtBudgetCode.AllowDrop = true;
			this.txtBudgetCode.BackColor = System.Drawing.Color.White;
			// this.txtBudgetCode.bolNumericOnly = true;
			this.txtBudgetCode.ForeColor = System.Drawing.Color.Black;
			this.txtBudgetCode.Location = new System.Drawing.Point(89, 105);
			this.txtBudgetCode.MaxLength = 8;
			this.txtBudgetCode.Name = "txtBudgetCode";
			// this.txtBudgetCode.ShowButton = true;
			this.txtBudgetCode.Size = new System.Drawing.Size(101, 19);
			this.txtBudgetCode.TabIndex = 9;
			this.txtBudgetCode.Text = "";
			// this.this.txtBudgetCode.Watermark = "";
			// this.this.txtBudgetCode.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtBudgetCode_DropButtonClick);
			// this.txtBudgetCode.Leave += new System.EventHandler(this.txtBudgetCode_Leave);
			// 
			// Line1
			// 
			this.Line1.AllowDrop = true;
			this.Line1.BackColor = System.Drawing.Color.Red;
			this.Line1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Line1.Enabled = false;
			this.Line1.ForeColor = System.Drawing.Color.Black;
			this.Line1.Location = new System.Drawing.Point(3, 135);
			this.Line1.Name = "Line1";
			this.Line1.Size = new System.Drawing.Size(1107, 1);
			this.Line1.Text = "Line1";
			this.Line1.Visible = true;
			// 
			// frmPayBudgetGLEntry
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.ClientSize = new System.Drawing.Size(1114, 489);
			this.Controls.Add(this.Command1);
			this.Controls.Add(this._lblCommon_5);
			this.Controls.Add(this.txtDPayrollDate);
			this.Controls.Add(this._lblCommon_37);
			this.Controls.Add(this.txtCompanyName);
			this.Controls.Add(this.txtCompanyCode);
			this.Controls.Add(this.grdVoucherDetails);
			this.Controls.Add(this._lblCommon_0);
			this.Controls.Add(this.txtDlblBudgetName);
			this.Controls.Add(this.txtBudgetCode);
			this.Controls.Add(this.Line1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			//this.Icon = (System.Drawing.Icon) resources.GetObject("frmPayBudgetGLEntry.Icon");
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(77, 160);
			this.MaximizeBox = true;
			this.MinimizeBox = true;
			this.Name = "frmPayBudgetGLEntry";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Budget GL Entry";
			// this.Activated += new System.EventHandler(this.Form_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
			// this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
			this.grdVoucherDetails.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		// 
		void InitializelblCommon()
		{
			this.lblCommon = new System.Windows.Forms.Label[38];
			this.lblCommon[5] = _lblCommon_5;
			this.lblCommon[37] = _lblCommon_37;
			this.lblCommon[0] = _lblCommon_0;
		}
		#endregion
	}
}//ENDSHERE
