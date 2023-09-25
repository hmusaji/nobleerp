
namespace Xtreme
{
	partial class frmPayProjectAttandance
	{

		#region "Upgrade Support "
		private static frmPayProjectAttandance m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmPayProjectAttandance DefInstance
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
		public static frmPayProjectAttandance CreateInstance()
		{
			frmPayProjectAttandance theInstance = new frmPayProjectAttandance();
			
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
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "Column_0_cmbMastersList1", "Column_1_cmbMastersList1", "cmbMastersList1", "txtDlBlProjectName", "cmdGetRecord", "Column_0_cmbMastersList", "Column_1_cmbMastersList", "cmbMastersList", "_cmbCommon_0", "txtProjectNo", "txtDAttandanceDate", "Column_0_grdProjectAttendance", "Column_1_grdProjectAttendance", "grdProjectAttendance", "_lblCommonLabel_0", "_lblCommonLabel_1", "_lblCommonLabel_2", "cmbCommon", "lblCommonLabel"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_0_cmbMastersList1;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_1_cmbMastersList1;
		public C1.Win.C1TrueDBGrid.C1TrueDBDropdown cmbMastersList1;
		public System.Windows.Forms.Label txtDlBlProjectName;
		public System.Windows.Forms.Button cmdGetRecord;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_0_cmbMastersList;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_1_cmbMastersList;
		public C1.Win.C1TrueDBGrid.C1TrueDBDropdown cmbMastersList;
		private System.Windows.Forms.ComboBox _cmbCommon_0;
		public System.Windows.Forms.TextBox txtProjectNo;
		public Syncfusion.WinForms.Input.SfDateTimeEdit txtDAttandanceDate;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_0_grdProjectAttendance;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_1_grdProjectAttendance;
		public C1.Win.C1TrueDBGrid.C1TrueDBGrid grdProjectAttendance;
		private System.Windows.Forms.Label _lblCommonLabel_0;
		private System.Windows.Forms.Label _lblCommonLabel_1;
		private System.Windows.Forms.Label _lblCommonLabel_2;
		public System.Windows.Forms.ComboBox[] cmbCommon = new System.Windows.Forms.ComboBox[1];
		public System.Windows.Forms.Label[] lblCommonLabel = new System.Windows.Forms.Label[3];
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPayProjectAttandance));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this.cmbMastersList1 = new C1.Win.C1TrueDBGrid.C1TrueDBDropdown();
			this.Column_0_cmbMastersList1 = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.Column_1_cmbMastersList1 = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.txtDlBlProjectName = new System.Windows.Forms.Label();
			this.cmdGetRecord = new System.Windows.Forms.Button();
			this.cmbMastersList = new C1.Win.C1TrueDBGrid.C1TrueDBDropdown();
			this.Column_0_cmbMastersList = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.Column_1_cmbMastersList = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this._cmbCommon_0 = new System.Windows.Forms.ComboBox();
			this.txtProjectNo = new System.Windows.Forms.TextBox();
			this.txtDAttandanceDate = new Syncfusion.WinForms.Input.SfDateTimeEdit();
			this.grdProjectAttendance = new C1.Win.C1TrueDBGrid.C1TrueDBGrid();
			this.Column_0_grdProjectAttendance = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.Column_1_grdProjectAttendance = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this._lblCommonLabel_0 = new System.Windows.Forms.Label();
			this._lblCommonLabel_1 = new System.Windows.Forms.Label();
			this._lblCommonLabel_2 = new System.Windows.Forms.Label();
			this.cmbMastersList1.SuspendLayout();
			this.cmbMastersList.SuspendLayout();
			this.grdProjectAttendance.SuspendLayout();
			this.SuspendLayout();
			// 
			// cmbMastersList1
			// 
			this.cmbMastersList1.AllowDrop = true;
			this.cmbMastersList1.ColumnHeaders = true;
			this.cmbMastersList1.Enabled = true;
			this.cmbMastersList1.Location = new System.Drawing.Point(777, 240);
			this.cmbMastersList1.Name = "cmbMastersList1";
			this.cmbMastersList1.Size = new System.Drawing.Size(53, 43);
			this.cmbMastersList1.TabIndex = 10;
			this.cmbMastersList1.Columns.Add(this.Column_0_cmbMastersList1);
			this.cmbMastersList1.Columns.Add(this.Column_1_cmbMastersList1);
			// 
			// Column_0_cmbMastersList1
			// 
			this.Column_0_cmbMastersList1.DataField = "";
			this.Column_0_cmbMastersList1.ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.Normal;
			// 
			// Column_1_cmbMastersList1
			// 
			this.Column_1_cmbMastersList1.DataField = "";
			this.Column_1_cmbMastersList1.ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.Normal;
			// 
			// txtDlBlProjectName
			// 
			this.txtDlBlProjectName.AllowDrop = true;
			this.txtDlBlProjectName.BackColor = System.Drawing.SystemColors.Window;
			this.txtDlBlProjectName.Enabled = false;
			this.txtDlBlProjectName.Location = new System.Drawing.Point(192, 90);
			this.txtDlBlProjectName.Name = "txtDlBlProjectName";
			this.txtDlBlProjectName.Size = new System.Drawing.Size(217, 19);
			this.txtDlBlProjectName.TabIndex = 9;
			// 
			// cmdGetRecord
			// 
			this.cmdGetRecord.AllowDrop = true;
			this.cmdGetRecord.BackColor = System.Drawing.SystemColors.Control;
			this.cmdGetRecord.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdGetRecord.Location = new System.Drawing.Point(660, 90);
			this.cmdGetRecord.Name = "cmdGetRecord";
			this.cmdGetRecord.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdGetRecord.Size = new System.Drawing.Size(100, 19);
			this.cmdGetRecord.TabIndex = 3;
			this.cmdGetRecord.Text = "Get Attendance";
			this.cmdGetRecord.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.cmdGetRecord.UseVisualStyleBackColor = false;
			// this.cmdGetRecord.Click += new System.EventHandler(this.cmdGetRecord_Click);
			// 
			// cmbMastersList
			// 
			this.cmbMastersList.AllowDrop = true;
			this.cmbMastersList.ColumnHeaders = true;
			this.cmbMastersList.Enabled = true;
			this.cmbMastersList.Location = new System.Drawing.Point(708, 240);
			this.cmbMastersList.Name = "cmbMastersList";
			this.cmbMastersList.Size = new System.Drawing.Size(53, 37);
			this.cmbMastersList.TabIndex = 8;
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
			// _cmbCommon_0
			// 
			this._cmbCommon_0.AllowDrop = true;
			this._cmbCommon_0.Location = new System.Drawing.Point(513, 90);
			this._cmbCommon_0.Name = "_cmbCommon_0";
			this._cmbCommon_0.Size = new System.Drawing.Size(109, 21);
			this._cmbCommon_0.TabIndex = 2;
			// this._cmbCommon_0.Leave += new System.EventHandler(this.cmbCommon_Leave);
			// 
			// txtProjectNo
			// 
			this.txtProjectNo.AllowDrop = true;
			this.txtProjectNo.BackColor = System.Drawing.Color.White;
			this.txtProjectNo.ForeColor = System.Drawing.Color.Black;
			this.txtProjectNo.Location = new System.Drawing.Point(90, 90);
			this.txtProjectNo.Name = "txtProjectNo";
			// this.txtProjectNo.ShowButton = true;
			this.txtProjectNo.Size = new System.Drawing.Size(100, 19);
			this.txtProjectNo.TabIndex = 1;
			this.txtProjectNo.Text = "";
			// this.this.txtProjectNo.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtProjectNo_DropButtonClick);
			// this.txtProjectNo.Leave += new System.EventHandler(this.txtProjectNo_Leave);
			// 
			// txtDAttandanceDate
			// 
			this.txtDAttandanceDate.AllowDrop = true;
			this.txtDAttandanceDate.CausesValidation = false;
			// this.txtDAttandanceDate.CheckDateRange = false;
			this.txtDAttandanceDate.Location = new System.Drawing.Point(90, 66);
			// this.txtDAttandanceDate.MaxDate = 2958465;
			// this.txtDAttandanceDate.MinDate = -657434;
			this.txtDAttandanceDate.Name = "txtDAttandanceDate";
			this.txtDAttandanceDate.Size = new System.Drawing.Size(100, 19);
			this.txtDAttandanceDate.TabIndex = 0;
			this.txtDAttandanceDate.Text = "16/10/2010";
			// this.txtDAttandanceDate.Value = 40467;
			// 
			// grdProjectAttendance
			// 
			this.grdProjectAttendance.AllowAddNew = true;
			this.grdProjectAttendance.AllowDrop = true;
			this.grdProjectAttendance.BackColor = System.Drawing.Color.Silver;
			this.grdProjectAttendance.CellTipsWidth = 0;
			this.grdProjectAttendance.Location = new System.Drawing.Point(3, 117);
			this.grdProjectAttendance.Name = "grdProjectAttendance";
			this.grdProjectAttendance.RowDivider.Color = System.Drawing.Color.Silver;
			this.grdProjectAttendance.Size = new System.Drawing.Size(919, 422);
			this.grdProjectAttendance.TabIndex = 4;
			this.grdProjectAttendance.Columns.Add(this.Column_0_grdProjectAttendance);
			this.grdProjectAttendance.Columns.Add(this.Column_1_grdProjectAttendance);
			this.grdProjectAttendance.AfterColUpdate += new C1.Win.C1TrueDBGrid.ColEventHandler(this.grdProjectAttendance_AfterColUpdate);
			this.grdProjectAttendance.BeforeColUpdate += new C1.Win.C1TrueDBGrid.BeforeColUpdateEventHandler(this.grdProjectAttendance_BeforeColUpdate);
			this.grdProjectAttendance.GotFocus += new System.EventHandler(this.grdProjectAttendance_GotFocus);
			// this.this.grdProjectAttendance.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.grdProjectAttendance_KeyPress);
			this.grdProjectAttendance.MouseUp += new System.Windows.Forms.MouseEventHandler(this.grdProjectAttendance_MouseUp);
			this.grdProjectAttendance.RowColChange += new C1.Win.C1TrueDBGrid.RowColChangeEventHandler(this.grdProjectAttendance_RowColChange);
			// 
			// Column_0_grdProjectAttendance
			// 
			this.Column_0_grdProjectAttendance.DataField = "";
			this.Column_0_grdProjectAttendance.ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.Normal;
			// 
			// Column_1_grdProjectAttendance
			// 
			this.Column_1_grdProjectAttendance.DataField = "";
			this.Column_1_grdProjectAttendance.ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.Normal;
			// 
			// _lblCommonLabel_0
			// 
			this._lblCommonLabel_0.AllowDrop = true;
			this._lblCommonLabel_0.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_0.Text = "Project No";
			this._lblCommonLabel_0.Location = new System.Drawing.Point(9, 92);
			this._lblCommonLabel_0.Name = "_lblCommonLabel_0";
			this._lblCommonLabel_0.Size = new System.Drawing.Size(49, 14);
			this._lblCommonLabel_0.TabIndex = 5;
			// 
			// _lblCommonLabel_1
			// 
			this._lblCommonLabel_1.AllowDrop = true;
			this._lblCommonLabel_1.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_1.Text = "Employee Type";
			this._lblCommonLabel_1.Location = new System.Drawing.Point(426, 93);
			this._lblCommonLabel_1.Name = "_lblCommonLabel_1";
			this._lblCommonLabel_1.Size = new System.Drawing.Size(73, 14);
			this._lblCommonLabel_1.TabIndex = 6;
			// 
			// _lblCommonLabel_2
			// 
			this._lblCommonLabel_2.AllowDrop = true;
			this._lblCommonLabel_2.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_2.Text = "Date";
			this._lblCommonLabel_2.Location = new System.Drawing.Point(9, 68);
			this._lblCommonLabel_2.Name = "_lblCommonLabel_2";
			this._lblCommonLabel_2.Size = new System.Drawing.Size(22, 14);
			this._lblCommonLabel_2.TabIndex = 7;
			// 
			// frmPayProjectAttandance
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.ClientSize = new System.Drawing.Size(926, 544);
			this.Controls.Add(this.cmbMastersList1);
			this.Controls.Add(this.txtDlBlProjectName);
			this.Controls.Add(this.cmdGetRecord);
			this.Controls.Add(this.cmbMastersList);
			this.Controls.Add(this._cmbCommon_0);
			this.Controls.Add(this.txtProjectNo);
			this.Controls.Add(this.txtDAttandanceDate);
			this.Controls.Add(this.grdProjectAttendance);
			this.Controls.Add(this._lblCommonLabel_0);
			this.Controls.Add(this._lblCommonLabel_1);
			this.Controls.Add(this._lblCommonLabel_2);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			//this.Icon = (System.Drawing.Icon) resources.GetObject("frmPayProjectAttandance.Icon");
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(126, 104);
			this.MaximizeBox = true;
			this.MinimizeBox = true;
			this.Name = "frmPayProjectAttandance";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Project Attendance";
			// this.Activated += new System.EventHandler(this.frmPayProjectAttandance_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
			// this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
			this.cmbMastersList1.ResumeLayout(false);
			this.cmbMastersList.ResumeLayout(false);
			this.grdProjectAttendance.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		void ReLoadForm(bool addEvents)
		{
			InitializelblCommonLabel();
			InitializecmbCommon();
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
			this.lblCommonLabel[0] = _lblCommonLabel_0;
			this.lblCommonLabel[1] = _lblCommonLabel_1;
			this.lblCommonLabel[2] = _lblCommonLabel_2;
		}
		void InitializecmbCommon()
		{
			this.cmbCommon = new System.Windows.Forms.ComboBox[1];
			this.cmbCommon[0] = _cmbCommon_0;
		}
		#endregion
	}
}//ENDSHERE
