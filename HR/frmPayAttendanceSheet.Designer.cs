
namespace Xtreme
{
	partial class frmPayAttendanceSheet
	{

		#region "Upgrade Support "
		private static frmPayAttendanceSheet m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmPayAttendanceSheet DefInstance
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
		public static frmPayAttendanceSheet CreateInstance()
		{
			frmPayAttendanceSheet theInstance = new frmPayAttendanceSheet();
			
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
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "_lblCommonLabel_2", "_txtDisplayEmp_1", "_txtCommonTextBox_3", "_lblCommon_114", "_txtDisplayLabel_4", "Column_0_grdVoucherDetails", "Column_1_grdVoucherDetails", "grdVoucherDetails", "_lblCommonLabel_0", "_txtDisplayLabel_6", "_lblCommonLabel_1", "_txtDisplayEmpName_2", "_txtDisplayLabel_5", "Line2", "lblTimeAtt", "Line1", "lblCommon", "lblCommonLabel", "txtCommonTextBox", "txtDisplayEmp", "txtDisplayEmpName", "txtDisplayLabel"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		private System.Windows.Forms.Label _lblCommonLabel_2;
		private System.Windows.Forms.Label _txtDisplayEmp_1;
		private System.Windows.Forms.TextBox _txtCommonTextBox_3;
		private System.Windows.Forms.Label _lblCommon_114;
		private System.Windows.Forms.Label _txtDisplayLabel_4;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_0_grdVoucherDetails;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_1_grdVoucherDetails;
		public C1.Win.C1TrueDBGrid.C1TrueDBGrid grdVoucherDetails;
		private System.Windows.Forms.Label _lblCommonLabel_0;
		private System.Windows.Forms.Label _txtDisplayLabel_6;
		private System.Windows.Forms.Label _lblCommonLabel_1;
		private System.Windows.Forms.Label _txtDisplayEmpName_2;
		private System.Windows.Forms.Label _txtDisplayLabel_5;
		public System.Windows.Forms.Label Line2;
		public System.Windows.Forms.Label lblTimeAtt;
		public System.Windows.Forms.Label Line1;
		public System.Windows.Forms.Label[] lblCommon = new System.Windows.Forms.Label[115];
		public System.Windows.Forms.Label[] lblCommonLabel = new System.Windows.Forms.Label[3];
		public System.Windows.Forms.TextBox[] txtCommonTextBox = new System.Windows.Forms.TextBox[4];
		public System.Windows.Forms.Label[] txtDisplayEmp = new System.Windows.Forms.Label[2];
		public System.Windows.Forms.Label[] txtDisplayEmpName = new System.Windows.Forms.Label[3];
		public System.Windows.Forms.Label[] txtDisplayLabel = new System.Windows.Forms.Label[7];
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPayAttendanceSheet));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this._lblCommonLabel_2 = new System.Windows.Forms.Label();
			this._txtDisplayEmp_1 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_3 = new System.Windows.Forms.TextBox();
			this._lblCommon_114 = new System.Windows.Forms.Label();
			this._txtDisplayLabel_4 = new System.Windows.Forms.Label();
			this.grdVoucherDetails = new C1.Win.C1TrueDBGrid.C1TrueDBGrid();
			this.Column_0_grdVoucherDetails = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.Column_1_grdVoucherDetails = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this._lblCommonLabel_0 = new System.Windows.Forms.Label();
			this._txtDisplayLabel_6 = new System.Windows.Forms.Label();
			this._lblCommonLabel_1 = new System.Windows.Forms.Label();
			this._txtDisplayEmpName_2 = new System.Windows.Forms.Label();
			this._txtDisplayLabel_5 = new System.Windows.Forms.Label();
			this.Line2 = new System.Windows.Forms.Label();
			this.lblTimeAtt = new System.Windows.Forms.Label();
			this.Line1 = new System.Windows.Forms.Label();
			//this.grdVoucherDetails.SuspendLayout();
			this.SuspendLayout();
			// 
			// _lblCommonLabel_2
			// 
			//this._lblCommonLabel_2.AllowDrop = true;
			this._lblCommonLabel_2.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_2.Text = "Employee Code";
			this._lblCommonLabel_2.Location = new System.Drawing.Point(10, 66);
			// // this._lblCommonLabel_2.mLabelId = 236;
			this._lblCommonLabel_2.Name = "_lblCommonLabel_2";
			this._lblCommonLabel_2.Size = new System.Drawing.Size(74, 14);
			this._lblCommonLabel_2.TabIndex = 1;
			// 
			// _txtDisplayEmp_1
			// 
			//this._txtDisplayEmp_1.AllowDrop = true;
			this._txtDisplayEmp_1.Enabled = false;
			this._txtDisplayEmp_1.Location = new System.Drawing.Point(116, 64);
			this._txtDisplayEmp_1.Name = "_txtDisplayEmp_1";
			this._txtDisplayEmp_1.Size = new System.Drawing.Size(105, 19);
			this._txtDisplayEmp_1.TabIndex = 2;
			// 
			// _txtCommonTextBox_3
			// 
			//this._txtCommonTextBox_3.AllowDrop = true;
			this._txtCommonTextBox_3.BackColor = System.Drawing.Color.FromArgb(239, 239, 239);
			// this._txtCommonTextBox_3.bolNumericOnly = true;
			this._txtCommonTextBox_3.Enabled = false;
			this._txtCommonTextBox_3.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_3.Location = new System.Drawing.Point(116, 85);
			this._txtCommonTextBox_3.MaxLength = 8;
			this._txtCommonTextBox_3.Name = "_txtCommonTextBox_3";
			// this._txtCommonTextBox_3.ShowButton = true;
			this._txtCommonTextBox_3.Size = new System.Drawing.Size(105, 19);
			this._txtCommonTextBox_3.TabIndex = 3;
			this._txtCommonTextBox_3.Text = "";
			// 
			// _lblCommon_114
			// 
			//this._lblCommon_114.AllowDrop = true;
			this._lblCommon_114.BackColor = System.Drawing.Color.FromArgb(227, 226, 219);
			this._lblCommon_114.Text = "Department Code";
			this._lblCommon_114.Location = new System.Drawing.Point(10, 87);
			// // this._lblCommon_114.mLabelId = 1973;
			this._lblCommon_114.Name = "_lblCommon_114";
			this._lblCommon_114.Size = new System.Drawing.Size(83, 14);
			this._lblCommon_114.TabIndex = 4;
			// 
			// _txtDisplayLabel_4
			// 
			//this._txtDisplayLabel_4.AllowDrop = true;
			this._txtDisplayLabel_4.Location = new System.Drawing.Point(223, 85);
			this._txtDisplayLabel_4.Name = "_txtDisplayLabel_4";
			this._txtDisplayLabel_4.Size = new System.Drawing.Size(201, 19);
			this._txtDisplayLabel_4.TabIndex = 5;
			this._txtDisplayLabel_4.TabStop = false;
			// 
			// grdVoucherDetails
			// 
			//this.grdVoucherDetails.AllowDrop = true;
			this.grdVoucherDetails.BackColor = System.Drawing.Color.Silver;
			this.grdVoucherDetails.CellTipsWidth = 0;
			this.grdVoucherDetails.Location = new System.Drawing.Point(0, 140);
			this.grdVoucherDetails.Name = "grdVoucherDetails";
			this.grdVoucherDetails.RowDivider.Color = System.Drawing.Color.Silver;
			this.grdVoucherDetails.Size = new System.Drawing.Size(1189, 386);
			this.grdVoucherDetails.TabIndex = 6;
			this.grdVoucherDetails.Columns.Add(this.Column_0_grdVoucherDetails);
			this.grdVoucherDetails.Columns.Add(this.Column_1_grdVoucherDetails);
			//this.grdVoucherDetails.BeforeColUpdate += new C1.Win.C1TrueDBGrid.BeforeColUpdateEventHandler(this.grdVoucherDetails_BeforeColUpdate);
			// this.this.grdVoucherDetails.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.grdVoucherDetails_KeyPress);
			//this.grdVoucherDetails.MouseUp += new System.Windows.Forms.MouseEventHandler(this.grdVoucherDetails_MouseUp);
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
			//this._lblCommonLabel_0.AllowDrop = true;
			this._lblCommonLabel_0.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_0.Text = "Month";
			this._lblCommonLabel_0.Location = new System.Drawing.Point(536, 87);
			// // this._lblCommonLabel_0.mLabelId = 1145;
			this._lblCommonLabel_0.Name = "_lblCommonLabel_0";
			this._lblCommonLabel_0.Size = new System.Drawing.Size(29, 14);
			this._lblCommonLabel_0.TabIndex = 7;
			// 
			// _txtDisplayLabel_6
			// 
			//this._txtDisplayLabel_6.AllowDrop = true;
			this._txtDisplayLabel_6.Location = new System.Drawing.Point(602, 85);
			this._txtDisplayLabel_6.Name = "_txtDisplayLabel_6";
			this._txtDisplayLabel_6.Size = new System.Drawing.Size(57, 19);
			this._txtDisplayLabel_6.TabIndex = 8;
			// 
			// _lblCommonLabel_1
			// 
			//this._lblCommonLabel_1.AllowDrop = true;
			this._lblCommonLabel_1.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_1.Text = "Year";
			this._lblCommonLabel_1.Location = new System.Drawing.Point(536, 66);
			// // this._lblCommonLabel_1.mLabelId = 1146;
			this._lblCommonLabel_1.Name = "_lblCommonLabel_1";
			this._lblCommonLabel_1.Size = new System.Drawing.Size(31, 14);
			this._lblCommonLabel_1.TabIndex = 9;
			// 
			// _txtDisplayEmpName_2
			// 
			//this._txtDisplayEmpName_2.AllowDrop = true;
			this._txtDisplayEmpName_2.Location = new System.Drawing.Point(223, 64);
			this._txtDisplayEmpName_2.Name = "_txtDisplayEmpName_2";
			this._txtDisplayEmpName_2.Size = new System.Drawing.Size(201, 19);
			this._txtDisplayEmpName_2.TabIndex = 10;
			// 
			// _txtDisplayLabel_5
			// 
			//this._txtDisplayLabel_5.AllowDrop = true;
			this._txtDisplayLabel_5.Location = new System.Drawing.Point(602, 64);
			this._txtDisplayLabel_5.Name = "_txtDisplayLabel_5";
			this._txtDisplayLabel_5.Size = new System.Drawing.Size(57, 19);
			this._txtDisplayLabel_5.TabIndex = 11;
			// 
			// Line2
			// 
			//this.Line2.AllowDrop = true;
			this.Line2.BackColor = System.Drawing.SystemColors.WindowText;
			this.Line2.Enabled = false;
			this.Line2.Location = new System.Drawing.Point(61, 52);
			this.Line2.Name = "Line2";
			this.Line2.Size = new System.Drawing.Size(249, 1);
			this.Line2.Visible = true;
			// 
			// lblTimeAtt
			// 
			//this.lblTimeAtt.AllowDrop = true;
			this.lblTimeAtt.BackColor = System.Drawing.Color.Transparent;
			//this.lblTimeAtt.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lblTimeAtt.Font = new System.Drawing.Font("Tahoma", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.lblTimeAtt.ForeColor = System.Drawing.Color.Navy;
			this.lblTimeAtt.Location = new System.Drawing.Point(56, 120);
			this.lblTimeAtt.Name = "lblTimeAtt";
			this.lblTimeAtt.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblTimeAtt.Size = new System.Drawing.Size(169, 17);
			this.lblTimeAtt.TabIndex = 0;
			this.lblTimeAtt.Text = "Time And Attendance  Sheet";
			// 
			// Line1
			// 
			//this.Line1.AllowDrop = true;
			this.Line1.BackColor = System.Drawing.SystemColors.WindowText;
			this.Line1.Enabled = false;
			this.Line1.Location = new System.Drawing.Point(0, 52);
			this.Line1.Name = "Line1";
			this.Line1.Size = new System.Drawing.Size(13, 1);
			this.Line1.Visible = true;
			// 
			// frmPayAttendanceSheet
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.ClientSize = new System.Drawing.Size(1194, 529);
			this.Controls.Add(this._lblCommonLabel_2);
			this.Controls.Add(this._txtDisplayEmp_1);
			this.Controls.Add(this._txtCommonTextBox_3);
			this.Controls.Add(this._lblCommon_114);
			this.Controls.Add(this._txtDisplayLabel_4);
			this.Controls.Add(this.grdVoucherDetails);
			this.Controls.Add(this._lblCommonLabel_0);
			this.Controls.Add(this._txtDisplayLabel_6);
			this.Controls.Add(this._lblCommonLabel_1);
			this.Controls.Add(this._txtDisplayEmpName_2);
			this.Controls.Add(this._txtDisplayLabel_5);
			this.Controls.Add(this.Line2);
			this.Controls.Add(this.lblTimeAtt);
			this.Controls.Add(this.Line1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			//this.Icon = (System.Drawing.Icon) resources.GetObject("frmPayAttendanceSheet.Icon");
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(62, 107);
			this.MaximizeBox = true;
			this.MinimizeBox = true;
			this.Name = "frmPayAttendanceSheet";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Attendance Sheet";
			// this.Activated += new System.EventHandler(this.frmPayAttendanceSheet_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
			// this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
			this.grdVoucherDetails.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		// 
		void InitializetxtDisplayLabel()
		{
			this.txtDisplayLabel = new System.Windows.Forms.Label[7];
			this.txtDisplayLabel[4] = _txtDisplayLabel_4;
			this.txtDisplayLabel[6] = _txtDisplayLabel_6;
			this.txtDisplayLabel[5] = _txtDisplayLabel_5;
		}
		void InitializetxtDisplayEmpName()
		{
			this.txtDisplayEmpName = new System.Windows.Forms.Label[3];
			this.txtDisplayEmpName[2] = _txtDisplayEmpName_2;
		}
		void InitializetxtDisplayEmp()
		{
			this.txtDisplayEmp = new System.Windows.Forms.Label[2];
			this.txtDisplayEmp[1] = _txtDisplayEmp_1;
		}
		void InitializetxtCommonTextBox()
		{
			this.txtCommonTextBox = new System.Windows.Forms.TextBox[4];
			this.txtCommonTextBox[3] = _txtCommonTextBox_3;
		}
		void InitializelblCommonLabel()
		{
			this.lblCommonLabel = new System.Windows.Forms.Label[3];
			this.lblCommonLabel[2] = _lblCommonLabel_2;
			this.lblCommonLabel[0] = _lblCommonLabel_0;
			this.lblCommonLabel[1] = _lblCommonLabel_1;
		}
		void InitializelblCommon()
		{
			this.lblCommon = new System.Windows.Forms.Label[115];
			this.lblCommon[114] = _lblCommon_114;
		}
		#endregion
	}
}//ENDSHERE
