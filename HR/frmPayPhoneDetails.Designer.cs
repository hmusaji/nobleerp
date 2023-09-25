
namespace Xtreme
{
	partial class frmPayPhoneDetails
	{

		#region "Upgrade Support "
		private static frmPayPhoneDetails m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmPayPhoneDetails DefInstance
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
		public static frmPayPhoneDetails CreateInstance()
		{
			frmPayPhoneDetails theInstance = new frmPayPhoneDetails();
			
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
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "cmdImportPhoneDeduction", "cmdClear", "Frame2", "cmdFilterByDept", "txtDeductionCodeName", "txtDeductionCode", "Column_0_grdPhoneDetails", "Column_1_grdPhoneDetails", "grdPhoneDetails", "_lblCommonLabel_2", "txtDepartmentCode", "_lblCommon_116", "txtDepartmentName", "Frame1", "CommonDialog1Open", "CommonDialog1", "Line2", "Line1", "lblTimeAtt", "lblCommon", "lblCommonLabel"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public System.Windows.Forms.Button cmdImportPhoneDeduction;
		public System.Windows.Forms.Button cmdClear;
		public System.Windows.Forms.GroupBox Frame2;
		public System.Windows.Forms.Button cmdFilterByDept;
		public System.Windows.Forms.Label txtDeductionCodeName;
		public System.Windows.Forms.TextBox txtDeductionCode;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_0_grdPhoneDetails;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_1_grdPhoneDetails;
		public C1.Win.C1TrueDBGrid.C1TrueDBGrid grdPhoneDetails;
		private System.Windows.Forms.Label _lblCommonLabel_2;
		public System.Windows.Forms.TextBox txtDepartmentCode;
		private System.Windows.Forms.Label _lblCommon_116;
		public System.Windows.Forms.Label txtDepartmentName;
		public System.Windows.Forms.GroupBox Frame1;
		public System.Windows.Forms.OpenFileDialog CommonDialog1Open;
		public UpgradeStubs.AxMSComDlg_AxCommonDialog CommonDialog1;
		public System.Windows.Forms.Label Line2;
		public System.Windows.Forms.Label Line1;
		public System.Windows.Forms.Label lblTimeAtt;
		public System.Windows.Forms.Label[] lblCommon = new System.Windows.Forms.Label[117];
		public System.Windows.Forms.Label[] lblCommonLabel = new System.Windows.Forms.Label[3];
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPayPhoneDetails));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this.Frame2 = new System.Windows.Forms.GroupBox();
			this.cmdImportPhoneDeduction = new System.Windows.Forms.Button();
			this.cmdClear = new System.Windows.Forms.Button();
			this.cmdFilterByDept = new System.Windows.Forms.Button();
			this.txtDeductionCodeName = new System.Windows.Forms.Label();
			this.txtDeductionCode = new System.Windows.Forms.TextBox();
			this.grdPhoneDetails = new C1.Win.C1TrueDBGrid.C1TrueDBGrid();
			this.Column_0_grdPhoneDetails = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.Column_1_grdPhoneDetails = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this._lblCommonLabel_2 = new System.Windows.Forms.Label();
			this.txtDepartmentCode = new System.Windows.Forms.TextBox();
			this._lblCommon_116 = new System.Windows.Forms.Label();
			this.txtDepartmentName = new System.Windows.Forms.Label();
			this.Frame1 = new System.Windows.Forms.GroupBox();
			this.CommonDialog1Open = new System.Windows.Forms.OpenFileDialog();
			this.CommonDialog1 = new UpgradeStubs.AxMSComDlg_AxCommonDialog();
			this.Line2 = new System.Windows.Forms.Label();
			this.Line1 = new System.Windows.Forms.Label();
			this.lblTimeAtt = new System.Windows.Forms.Label();
			this.Frame2.SuspendLayout();
			this.grdPhoneDetails.SuspendLayout();
			this.SuspendLayout();
			// 
			// Frame2
			// 
			this.Frame2.AllowDrop = true;
			this.Frame2.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.Frame2.Controls.Add(this.cmdImportPhoneDeduction);
			this.Frame2.Controls.Add(this.cmdClear);
			this.Frame2.Enabled = true;
			this.Frame2.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Frame2.Location = new System.Drawing.Point(522, 72);
			this.Frame2.Name = "Frame2";
			this.Frame2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Frame2.Size = new System.Drawing.Size(352, 43);
			this.Frame2.TabIndex = 10;
			this.Frame2.Visible = true;
			// 
			// cmdImportPhoneDeduction
			// 
			this.cmdImportPhoneDeduction.AllowDrop = true;
			this.cmdImportPhoneDeduction.BackColor = System.Drawing.SystemColors.Control;
			this.cmdImportPhoneDeduction.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdImportPhoneDeduction.Location = new System.Drawing.Point(210, 9);
			this.cmdImportPhoneDeduction.Name = "cmdImportPhoneDeduction";
			this.cmdImportPhoneDeduction.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdImportPhoneDeduction.Size = new System.Drawing.Size(136, 25);
			this.cmdImportPhoneDeduction.TabIndex = 12;
			this.cmdImportPhoneDeduction.Text = "Import Phone Deduction";
			this.cmdImportPhoneDeduction.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.cmdImportPhoneDeduction.UseVisualStyleBackColor = false;
			// this.cmdImportPhoneDeduction.Click += new System.EventHandler(this.cmdImportPhoneDeduction_Click);
			// 
			// cmdClear
			// 
			this.cmdClear.AllowDrop = true;
			this.cmdClear.BackColor = System.Drawing.SystemColors.Control;
			this.cmdClear.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdClear.Location = new System.Drawing.Point(63, 9);
			this.cmdClear.Name = "cmdClear";
			this.cmdClear.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdClear.Size = new System.Drawing.Size(136, 25);
			this.cmdClear.TabIndex = 11;
			this.cmdClear.Text = "Clear All Invoice Amount";
			this.cmdClear.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.cmdClear.UseVisualStyleBackColor = false;
			// this.cmdClear.Click += new System.EventHandler(this.cmdClear_Click);
			// 
			// cmdFilterByDept
			// 
			this.cmdFilterByDept.AllowDrop = true;
			this.cmdFilterByDept.BackColor = System.Drawing.SystemColors.Control;
			this.cmdFilterByDept.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdFilterByDept.Location = new System.Drawing.Point(410, 86);
			this.cmdFilterByDept.Name = "cmdFilterByDept";
			this.cmdFilterByDept.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdFilterByDept.Size = new System.Drawing.Size(33, 21);
			this.cmdFilterByDept.TabIndex = 8;
			this.cmdFilterByDept.Text = "Find";
			this.cmdFilterByDept.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.cmdFilterByDept.UseVisualStyleBackColor = false;
			// this.cmdFilterByDept.Click += new System.EventHandler(this.cmdFilterByDept_Click);
			// 
			// txtDeductionCodeName
			// 
			this.txtDeductionCodeName.AllowDrop = true;
			this.txtDeductionCodeName.BackColor = System.Drawing.SystemColors.Window;
			this.txtDeductionCodeName.Enabled = false;
			this.txtDeductionCodeName.Location = new System.Drawing.Point(203, 46);
			this.txtDeductionCodeName.Name = "txtDeductionCodeName";
			this.txtDeductionCodeName.Size = new System.Drawing.Size(227, 19);
			this.txtDeductionCodeName.TabIndex = 4;
			// 
			// txtDeductionCode
			// 
			this.txtDeductionCode.AllowDrop = true;
			this.txtDeductionCode.BackColor = System.Drawing.Color.White;
			// this.txtDeductionCode.bolAllowDecimal = false;
			this.txtDeductionCode.ForeColor = System.Drawing.Color.Black;
			this.txtDeductionCode.Location = new System.Drawing.Point(88, 46);
			// this.txtDeductionCode.mDropDownType = (System.Windows.Forms.TextBox.DropDownTypes) 0;
			this.txtDeductionCode.Name = "txtDeductionCode";
			// this.txtDeductionCode.ShowButton = true;
			this.txtDeductionCode.Size = new System.Drawing.Size(113, 19);
			this.txtDeductionCode.TabIndex = 3;
			this.txtDeductionCode.Text = "";
			// this.this.txtDeductionCode.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtDeductionCode_DropButtonClick);
			// this.txtDeductionCode.Leave += new System.EventHandler(this.txtDeductionCode_Leave);
			// 
			// grdPhoneDetails
			// 
			this.grdPhoneDetails.AllowDrop = true;
			this.grdPhoneDetails.BackColor = System.Drawing.Color.Silver;
			this.grdPhoneDetails.CellTipsWidth = 0;
			this.grdPhoneDetails.Location = new System.Drawing.Point(0, 148);
			this.grdPhoneDetails.Name = "grdPhoneDetails";
			this.grdPhoneDetails.RowDivider.Color = System.Drawing.Color.Silver;
			this.grdPhoneDetails.Size = new System.Drawing.Size(880, 283);
			this.grdPhoneDetails.TabIndex = 0;
			this.grdPhoneDetails.Columns.Add(this.Column_0_grdPhoneDetails);
			this.grdPhoneDetails.Columns.Add(this.Column_1_grdPhoneDetails);
			this.grdPhoneDetails.AfterColUpdate += new C1.Win.C1TrueDBGrid.ColEventHandler(this.grdPhoneDetails_AfterColUpdate);
			// 
			// Column_0_grdPhoneDetails
			// 
			this.Column_0_grdPhoneDetails.DataField = "";
			this.Column_0_grdPhoneDetails.ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.Normal;
			// 
			// Column_1_grdPhoneDetails
			// 
			this.Column_1_grdPhoneDetails.DataField = "";
			this.Column_1_grdPhoneDetails.ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.Normal;
			// 
			// _lblCommonLabel_2
			// 
			this._lblCommonLabel_2.AllowDrop = true;
			this._lblCommonLabel_2.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_2.Text = "Deduction Code";
			this._lblCommonLabel_2.Location = new System.Drawing.Point(4, 48);
			// this._lblCommonLabel_2.mLabelId = 1997;
			this._lblCommonLabel_2.Name = "_lblCommonLabel_2";
			this._lblCommonLabel_2.Size = new System.Drawing.Size(76, 14);
			this._lblCommonLabel_2.TabIndex = 1;
			// 
			// txtDepartmentCode
			// 
			this.txtDepartmentCode.AllowDrop = true;
			this.txtDepartmentCode.BackColor = System.Drawing.Color.White;
			// this.txtDepartmentCode.bolNumericOnly = true;
			this.txtDepartmentCode.ForeColor = System.Drawing.Color.Black;
			this.txtDepartmentCode.Location = new System.Drawing.Point(102, 86);
			this.txtDepartmentCode.MaxLength = 8;
			this.txtDepartmentCode.Name = "txtDepartmentCode";
			// this.txtDepartmentCode.ShowButton = true;
			this.txtDepartmentCode.Size = new System.Drawing.Size(113, 19);
			this.txtDepartmentCode.TabIndex = 5;
			this.txtDepartmentCode.Text = "";
			// this.this.txtDepartmentCode.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtDepartmentCode_DropButtonClick);
			// this.txtDepartmentCode.Leave += new System.EventHandler(this.txtDepartmentCode_Leave);
			// 
			// _lblCommon_116
			// 
			this._lblCommon_116.AllowDrop = true;
			this._lblCommon_116.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_116.Text = "Department Code";
			this._lblCommon_116.Location = new System.Drawing.Point(8, 90);
			// this._lblCommon_116.mLabelId = 1973;
			this._lblCommon_116.Name = "_lblCommon_116";
			this._lblCommon_116.Size = new System.Drawing.Size(83, 14);
			this._lblCommon_116.TabIndex = 6;
			// 
			// txtDepartmentName
			// 
			this.txtDepartmentName.AllowDrop = true;
			this.txtDepartmentName.Location = new System.Drawing.Point(217, 86);
			this.txtDepartmentName.Name = "txtDepartmentName";
			this.txtDepartmentName.Size = new System.Drawing.Size(191, 19);
			this.txtDepartmentName.TabIndex = 7;
			this.txtDepartmentName.TabStop = false;
			// 
			// Frame1
			// 
			this.Frame1.AllowDrop = true;
			this.Frame1.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.Frame1.Enabled = true;
			this.Frame1.ForeColor = System.Drawing.SystemColors.WindowText;
			this.Frame1.Location = new System.Drawing.Point(2, 74);
			this.Frame1.Name = "Frame1";
			this.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Frame1.Size = new System.Drawing.Size(473, 39);
			this.Frame1.TabIndex = 9;
			this.Frame1.Text = "Search ";
			this.Frame1.Visible = true;
			// 
			// Line2
			// 
			this.Line2.AllowDrop = true;
			this.Line2.BackColor = System.Drawing.SystemColors.WindowText;
			this.Line2.Enabled = false;
			this.Line2.Location = new System.Drawing.Point(145, 132);
			this.Line2.Name = "Line2";
			this.Line2.Size = new System.Drawing.Size(733, 1);
			this.Line2.Visible = true;
			// 
			// Line1
			// 
			this.Line1.AllowDrop = true;
			this.Line1.BackColor = System.Drawing.SystemColors.WindowText;
			this.Line1.Enabled = false;
			this.Line1.Location = new System.Drawing.Point(0, 132);
			this.Line1.Name = "Line1";
			this.Line1.Size = new System.Drawing.Size(48, 1);
			this.Line1.Visible = true;
			// 
			// lblTimeAtt
			// 
			this.lblTimeAtt.AllowDrop = true;
			this.lblTimeAtt.BackColor = System.Drawing.Color.Transparent;
			this.lblTimeAtt.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lblTimeAtt.Font = new System.Drawing.Font("Tahoma", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.lblTimeAtt.ForeColor = System.Drawing.Color.Navy;
			this.lblTimeAtt.Location = new System.Drawing.Point(54, 124);
			this.lblTimeAtt.Name = "lblTimeAtt";
			this.lblTimeAtt.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblTimeAtt.Size = new System.Drawing.Size(85, 17);
			this.lblTimeAtt.TabIndex = 2;
			this.lblTimeAtt.Text = "Phone Details";
			// 
			// frmPayPhoneDetails
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.ClientSize = new System.Drawing.Size(881, 433);
			this.Controls.Add(this.Frame2);
			this.Controls.Add(this.cmdFilterByDept);
			this.Controls.Add(this.txtDeductionCodeName);
			this.Controls.Add(this.txtDeductionCode);
			this.Controls.Add(this.grdPhoneDetails);
			this.Controls.Add(this._lblCommonLabel_2);
			this.Controls.Add(this.txtDepartmentCode);
			this.Controls.Add(this._lblCommon_116);
			this.Controls.Add(this.txtDepartmentName);
			this.Controls.Add(this.Frame1);
			this.Controls.Add(this.Line2);
			this.Controls.Add(this.Line1);
			this.Controls.Add(this.lblTimeAtt);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			//this.Icon = (System.Drawing.Icon) resources.GetObject("frmPayPhoneDetails.Icon");
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(91, 153);
			this.MaximizeBox = true;
			this.MinimizeBox = false;
			this.Name = "frmPayPhoneDetails";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Phone Details";
			// this.Activated += new System.EventHandler(this.frmPayPhoneDetails_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
			// this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
			this.Frame2.ResumeLayout(false);
			this.grdPhoneDetails.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		void ReLoadForm(bool addEvents)
		{
			InitializelblCommonLabel();
			InitializelblCommon();
			//This form is an MDI child.
			//This code simulates the VB6 
			// functionality of automatically
			// loading and showing an MDI
			// child's parent.
			this.MdiParent = Xtreme.frmSysMain.DefInstance;
			Xtreme.frmSysMain.DefInstance.Show();
		}
		void InitializelblCommonLabel()
		{
			this.lblCommonLabel = new System.Windows.Forms.Label[3];
			this.lblCommonLabel[2] = _lblCommonLabel_2;
		}
		void InitializelblCommon()
		{
			this.lblCommon = new System.Windows.Forms.Label[117];
			this.lblCommon[116] = _lblCommon_116;
		}
		#endregion
	}
}