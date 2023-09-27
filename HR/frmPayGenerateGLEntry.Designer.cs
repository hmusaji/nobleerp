
namespace Xtreme
{
	partial class frmPayGenerateGLEntry
	{

		#region "Upgrade Support "
		private static frmPayGenerateGLEntry m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmPayGenerateGLEntry DefInstance
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
		public static frmPayGenerateGLEntry CreateInstance()
		{
			frmPayGenerateGLEntry theInstance = new frmPayGenerateGLEntry();
			
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
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "ChkGenerateSeprateJv", "lblDocDate", "lblDocType", "Command1", "Column_0_cmbMastersList", "Column_1_cmbMastersList", "cmbMastersList", "_lblCommon_5", "Column_0_grdVoucherDetails", "Column_1_grdVoucherDetails", "grdVoucherDetails", "txtDPayrollDate", "lblExchangeRate", "txtDocType", "txtDocDate", "txtNExchangeRate", "lblDocNo", "txtDocNo", "_lblCommon_37", "txtCompanyName", "txtCompanyCode", "Line1", "lblCommon"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public System.Windows.Forms.CheckBox ChkGenerateSeprateJv;
		public System.Windows.Forms.Label lblDocDate;
		public System.Windows.Forms.Label lblDocType;
		public System.Windows.Forms.Button Command1;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_0_cmbMastersList;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_1_cmbMastersList;
		public C1.Win.C1TrueDBGrid.C1TrueDBDropdown cmbMastersList;
		private System.Windows.Forms.Label _lblCommon_5;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_0_grdVoucherDetails;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_1_grdVoucherDetails;
		public C1.Win.C1TrueDBGrid.C1TrueDBGrid grdVoucherDetails;
		public Syncfusion.WinForms.Input.SfDateTimeEdit txtDPayrollDate;
		public System.Windows.Forms.Label lblExchangeRate;
		public System.Windows.Forms.TextBox txtDocType;
		public Syncfusion.WinForms.Input.SfDateTimeEdit txtDocDate;
		public System.Windows.Forms.TextBox txtNExchangeRate;
		public System.Windows.Forms.Label lblDocNo;
		public System.Windows.Forms.TextBox txtDocNo;
		private System.Windows.Forms.Label _lblCommon_37;
		public System.Windows.Forms.Label txtCompanyName;
		public System.Windows.Forms.TextBox txtCompanyCode;
		public System.Windows.Forms.Label Line1;
		public System.Windows.Forms.Label[] lblCommon = new System.Windows.Forms.Label[38];
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPayGenerateGLEntry));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this.ChkGenerateSeprateJv = new System.Windows.Forms.CheckBox();
			this.lblDocDate = new System.Windows.Forms.Label();
			this.lblDocType = new System.Windows.Forms.Label();
			this.Command1 = new System.Windows.Forms.Button();
			this.cmbMastersList = new C1.Win.C1TrueDBGrid.C1TrueDBDropdown();
			this.Column_0_cmbMastersList = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.Column_1_cmbMastersList = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this._lblCommon_5 = new System.Windows.Forms.Label();
			this.grdVoucherDetails = new C1.Win.C1TrueDBGrid.C1TrueDBGrid();
			this.Column_0_grdVoucherDetails = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.Column_1_grdVoucherDetails = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.txtDPayrollDate = new Syncfusion.WinForms.Input.SfDateTimeEdit();
			this.lblExchangeRate = new System.Windows.Forms.Label();
			this.txtDocType = new System.Windows.Forms.TextBox();
			this.txtDocDate = new Syncfusion.WinForms.Input.SfDateTimeEdit();
			this.txtNExchangeRate = new System.Windows.Forms.TextBox();
			this.lblDocNo = new System.Windows.Forms.Label();
			this.txtDocNo = new System.Windows.Forms.TextBox();
			this._lblCommon_37 = new System.Windows.Forms.Label();
			this.txtCompanyName = new System.Windows.Forms.Label();
			this.txtCompanyCode = new System.Windows.Forms.TextBox();
			this.Line1 = new System.Windows.Forms.Label();
			//this.cmbMastersList.SuspendLayout();
			//this.grdVoucherDetails.SuspendLayout();
			this.SuspendLayout();
			// 
			// ChkGenerateSeprateJv
			// 
			//this.ChkGenerateSeprateJv.AllowDrop = true;
			this.ChkGenerateSeprateJv.Appearance = System.Windows.Forms.Appearance.Normal;
			this.ChkGenerateSeprateJv.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.ChkGenerateSeprateJv.CausesValidation = true;
			this.ChkGenerateSeprateJv.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.ChkGenerateSeprateJv.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this.ChkGenerateSeprateJv.Enabled = true;
			this.ChkGenerateSeprateJv.ForeColor = System.Drawing.SystemColors.ControlText;
			this.ChkGenerateSeprateJv.Location = new System.Drawing.Point(297, 45);
			this.ChkGenerateSeprateJv.Name = "ChkGenerateSeprateJv";
			this.ChkGenerateSeprateJv.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.ChkGenerateSeprateJv.Size = new System.Drawing.Size(259, 16);
			this.ChkGenerateSeprateJv.TabIndex = 13;
			this.ChkGenerateSeprateJv.TabStop = true;
			this.ChkGenerateSeprateJv.Text = "Generate Seprate JV";
			this.ChkGenerateSeprateJv.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.ChkGenerateSeprateJv.Visible = true;
			// 
			// lblDocDate
			// 
			//this.lblDocDate.AllowDrop = true;
			this.lblDocDate.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			// this.lblDocDate.Text = "Document Date";
			this.lblDocDate.ForeColor = System.Drawing.SystemColors.WindowText;
			this.lblDocDate.Location = new System.Drawing.Point(364, 100);
			this.lblDocDate.Name = "lblDocDate";
			this.lblDocDate.Size = new System.Drawing.Size(73, 14);
			this.lblDocDate.TabIndex = 10;
			// 
			// lblDocType
			// 
			//this.lblDocType.AllowDrop = true;
			this.lblDocType.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblDocType.Text = "Document Type";
			this.lblDocType.ForeColor = System.Drawing.SystemColors.WindowText;
			this.lblDocType.Location = new System.Drawing.Point(4, 100);
			this.lblDocType.Name = "lblDocType";
			this.lblDocType.Size = new System.Drawing.Size(75, 14);
			this.lblDocType.TabIndex = 9;
			// 
			// Command1
			// 
			//this.Command1.AllowDrop = true;
			this.Command1.BackColor = System.Drawing.SystemColors.Control;
			this.Command1.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Command1.Location = new System.Drawing.Point(188, 42);
			this.Command1.Name = "Command1";
			this.Command1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Command1.Size = new System.Drawing.Size(67, 27);
			this.Command1.TabIndex = 6;
			this.Command1.Text = "Generate";
			this.Command1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.Command1.UseVisualStyleBackColor = false;
			// this.Command1.Click += new System.EventHandler(this.Command1_Click);
			// 
			// cmbMastersList
			// 
			//this.cmbMastersList.AllowDrop = true;
			this.cmbMastersList.ColumnHeaders = true;
			this.cmbMastersList.Enabled = true;
			this.cmbMastersList.Location = new System.Drawing.Point(27, 153);
			this.cmbMastersList.Name = "cmbMastersList";
			this.cmbMastersList.Size = new System.Drawing.Size(333, 133);
			this.cmbMastersList.TabIndex = 0;
			this.cmbMastersList.Columns.Add(this.Column_0_cmbMastersList);
			this.cmbMastersList.Columns.Add(this.Column_1_cmbMastersList);
			// 
			// Column_0_cmbMastersList
			// 
			this.Column_0_cmbMastersList.DataField = "";
			this.Column_0_cmbMastersList.ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.Normal;
			// 
			// Column_1_cmbMastersList
			// 
			this.Column_1_cmbMastersList.DataField = "";
			this.Column_1_cmbMastersList.ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.Normal;
			// 
			// _lblCommon_5
			// 
			//this._lblCommon_5.AllowDrop = true;
			this._lblCommon_5.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_5.Text = "Payroll Date";
			this._lblCommon_5.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_5.Location = new System.Drawing.Point(4, 47);
			this._lblCommon_5.Name = "_lblCommon_5";
			this._lblCommon_5.Size = new System.Drawing.Size(57, 14);
			this._lblCommon_5.TabIndex = 7;
			// 
			// grdVoucherDetails
			// 
			//this.grdVoucherDetails.AllowDrop = true;
			this.grdVoucherDetails.BackColor = System.Drawing.Color.FromArgb(212, 208, 200);
			this.grdVoucherDetails.CellTipsWidth = 0;
			this.grdVoucherDetails.Enabled = false;
			this.grdVoucherDetails.Location = new System.Drawing.Point(2, 132);
			this.grdVoucherDetails.Name = "grdVoucherDetails";
			this.grdVoucherDetails.RowDivider.Color = System.Drawing.Color.FromArgb(212, 208, 200);
			this.grdVoucherDetails.Size = new System.Drawing.Size(1107, 333);
			this.grdVoucherDetails.TabIndex = 8;
			this.grdVoucherDetails.Columns.Add(this.Column_0_grdVoucherDetails);
			this.grdVoucherDetails.Columns.Add(this.Column_1_grdVoucherDetails);
			//this.grdVoucherDetails.GotFocus += new System.EventHandler(this.grdVoucherDetails_GotFocus);
			//this.grdVoucherDetails.RowColChange += new C1.Win.C1TrueDBGrid.RowColChangeEventHandler(this.grdVoucherDetails_RowColChange);
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
			// txtDPayrollDate
			// 
			//this.txtDPayrollDate.AllowDrop = true;
			// this.txtDPayrollDate.CheckDateRange = false;
			this.txtDPayrollDate.Location = new System.Drawing.Point(84, 46);
			// this.txtDPayrollDate.MaxDate = 2958465;
			// this.txtDPayrollDate.MinDate = -657434;
			this.txtDPayrollDate.Name = "txtDPayrollDate";
			// = "_";
			this.txtDPayrollDate.Size = new System.Drawing.Size(97, 19);
			this.txtDPayrollDate.TabIndex = 1;
			// this.txtDPayrollDate.Text = "30/06/2011";
			// this.txtDPayrollDate.Value = 40724;
			// 
			// lblExchangeRate
			// 
			//this.lblExchangeRate.AllowDrop = true;
			this.lblExchangeRate.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			// this.lblExchangeRate.Text = "Exchange Rate";
			this.lblExchangeRate.ForeColor = System.Drawing.SystemColors.WindowText;
			this.lblExchangeRate.Location = new System.Drawing.Point(572, 100);
			this.lblExchangeRate.Name = "lblExchangeRate";
			this.lblExchangeRate.Size = new System.Drawing.Size(73, 14);
			this.lblExchangeRate.TabIndex = 11;
			// 
			// txtDocType
			// 
			//this.txtDocType.AllowDrop = true;
			this.txtDocType.BackColor = System.Drawing.Color.White;
			// // = false;
			this.txtDocType.ForeColor = System.Drawing.Color.Black;
			this.txtDocType.Location = new System.Drawing.Point(84, 98);
			// // = (System.Windows.Forms.TextBox.DropDownTypes) 0;
			this.txtDocType.Name = "txtDocType";
			this.txtDocType.Size = new System.Drawing.Size(100, 19);
			this.txtDocType.TabIndex = 2;
			this.txtDocType.Text = "";
			// this.// = "";
			// 
			// txtDocDate
			// 
			//this.txtDocDate.AllowDrop = true;
			this.txtDocDate.Location = new System.Drawing.Point(442, 98);
			// this.txtDocDate.MaxDate = 2958465;
			// this.txtDocDate.MinDate = -657434;
			this.txtDocDate.Name = "txtDocDate";
			// = "_";
			this.txtDocDate.Size = new System.Drawing.Size(117, 19);
			this.txtDocDate.TabIndex = 4;
			// this.txtDocDate.Text = "25/03/2004";
			// this.txtDocDate.Value = 38071;
			// 
			// txtNExchangeRate
			// 
			//this.txtNExchangeRate.AllowDrop = true;
			// this.txtNExchangeRate.DisplayFormat = "####0.00000###;;0.00000;0.00000";
			this.txtNExchangeRate.ForeColor = System.Drawing.SystemColors.WindowText;
			// this.txtNExchangeRate.Format = "#########0.00000";
			this.txtNExchangeRate.Location = new System.Drawing.Point(658, 98);
			this.txtNExchangeRate.Name = "txtNExchangeRate";
			this.txtNExchangeRate.Size = new System.Drawing.Size(103, 19);
			this.txtNExchangeRate.TabIndex = 5;
			// this.txtNExchangeRate.Text = "0.00000";
			// 
			// lblDocNo
			// 
			//this.lblDocNo.AllowDrop = true;
			this.lblDocNo.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblDocNo.Text = "Document No";
			this.lblDocNo.ForeColor = System.Drawing.SystemColors.WindowText;
			this.lblDocNo.Location = new System.Drawing.Point(190, 100);
			this.lblDocNo.Name = "lblDocNo";
			this.lblDocNo.Size = new System.Drawing.Size(64, 14);
			this.lblDocNo.TabIndex = 12;
			// 
			// txtDocNo
			// 
			//this.txtDocNo.AllowDrop = true;
			this.txtDocNo.BackColor = System.Drawing.Color.White;
			// // = false;
			this.txtDocNo.ForeColor = System.Drawing.Color.Black;
			this.txtDocNo.Location = new System.Drawing.Point(260, 98);
			// // = (System.Windows.Forms.TextBox.DropDownTypes) 0;
			this.txtDocNo.Name = "txtDocNo";
			this.txtDocNo.Size = new System.Drawing.Size(100, 19);
			this.txtDocNo.TabIndex = 3;
			this.txtDocNo.Text = "";
			// this.// = "";
			// 
			// _lblCommon_37
			// 
			//this._lblCommon_37.AllowDrop = true;
			this._lblCommon_37.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_37.Text = "Company Code";
			this._lblCommon_37.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_37.Location = new System.Drawing.Point(4, 77);
			// // this._lblCommon_37.mLabelId = 1927;
			this._lblCommon_37.Name = "_lblCommon_37";
			this._lblCommon_37.Size = new System.Drawing.Size(73, 14);
			this._lblCommon_37.TabIndex = 14;
			// 
			// txtCompanyName
			// 
			//this.txtCompanyName.AllowDrop = true;
			this.txtCompanyName.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.txtCompanyName.Location = new System.Drawing.Point(186, 75);
			this.txtCompanyName.Name = "txtCompanyName";
			this.txtCompanyName.Size = new System.Drawing.Size(371, 19);
			this.txtCompanyName.TabIndex = 15;
			this.txtCompanyName.TabStop = false;
			// 
			// txtCompanyCode
			// 
			//this.txtCompanyCode.AllowDrop = true;
			this.txtCompanyCode.BackColor = System.Drawing.Color.White;
			// this.txtCompanyCode.bolNumericOnly = true;
			this.txtCompanyCode.ForeColor = System.Drawing.Color.Black;
			this.txtCompanyCode.Location = new System.Drawing.Point(84, 75);
			this.txtCompanyCode.MaxLength = 8;
			this.txtCompanyCode.Name = "txtCompanyCode";
			// this.txtCompanyCode.ShowButton = true;
			this.txtCompanyCode.Size = new System.Drawing.Size(101, 19);
			this.txtCompanyCode.TabIndex = 16;
			this.txtCompanyCode.Text = "";
			// this.// = "";
			// this.//this.txtCompanyCode.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(//this.txtCompanyCode_DropButtonClick);
			// this.txtCompanyCode.Leave += new System.EventHandler(this.txtCompanyCode_Leave);
			// 
			// Line1
			// 
			//this.Line1.AllowDrop = true;
			this.Line1.BackColor = System.Drawing.Color.Red;
			//this.Line1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Line1.Enabled = false;
			this.Line1.ForeColor = System.Drawing.Color.Black;
			this.Line1.Location = new System.Drawing.Point(0, 125);
			this.Line1.Name = "Line1";
			this.Line1.Size = new System.Drawing.Size(1107, 1);
			this.Line1.Text = "Line1";
			this.Line1.Visible = true;
			// 
			// frmPayGenerateGLEntry
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.ClientSize = new System.Drawing.Size(1008, 469);
			this.Controls.Add(this.ChkGenerateSeprateJv);
			this.Controls.Add(this.lblDocDate);
			this.Controls.Add(this.lblDocType);
			this.Controls.Add(this.Command1);
			this.Controls.Add(this.cmbMastersList);
			this.Controls.Add(this._lblCommon_5);
			this.Controls.Add(this.grdVoucherDetails);
			this.Controls.Add(this.txtDPayrollDate);
			this.Controls.Add(this.lblExchangeRate);
			this.Controls.Add(this.txtDocType);
			this.Controls.Add(this.txtDocDate);
			this.Controls.Add(this.txtNExchangeRate);
			this.Controls.Add(this.lblDocNo);
			this.Controls.Add(this.txtDocNo);
			this.Controls.Add(this._lblCommon_37);
			this.Controls.Add(this.txtCompanyName);
			this.Controls.Add(this.txtCompanyCode);
			this.Controls.Add(this.Line1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			//this.Icon = (System.Drawing.Icon) resources.GetObject("frmPayGenerateGLEntry.Icon");
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(117, 283);
			this.MaximizeBox = true;
			this.MinimizeBox = true;
			this.Name = "frmPayGenerateGLEntry";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Generate GL Entry";
			// this.Activated += new System.EventHandler(this.Form_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
			// this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
			this.cmbMastersList.ResumeLayout(false);
			this.grdVoucherDetails.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		// 
		void InitializelblCommon()
		{
			this.lblCommon = new System.Windows.Forms.Label[38];
			this.lblCommon[5] = _lblCommon_5;
			this.lblCommon[37] = _lblCommon_37;
		}
		#endregion
	}
}//ENDSHERE
