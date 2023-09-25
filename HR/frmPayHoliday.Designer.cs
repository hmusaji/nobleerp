
namespace Xtreme
{
	partial class frmPayHoliday
	{

		#region "Upgrade Support "
		private static frmPayHoliday m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmPayHoliday DefInstance
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
		public static frmPayHoliday CreateInstance()
		{
			frmPayHoliday theInstance = new frmPayHoliday();
			
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
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "_txtCommonDate_1", "_txtCommonDate_0", "cmdGenerate", "txtHolidayNo", "lblHolidayCode", "lblLGroupName", "txtLHolidayName", "lblAGroupName", "txtAHolidayName", "txtHolidayDate", "Column_0_grdHolidayDetails", "Column_1_grdHolidayDetails", "grdHolidayDetails", "_System.Windows.Forms.Label1_0", "_System.Windows.Forms.Label1_1", "lblCalendar", "txtCalendarCd", "txtDlblCalendarName", "System.Windows.Forms.Label1", "txtCommonDate"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		private Syncfusion.WinForms.Input.SfDateTimeEdit _txtCommonDate_1;
		private Syncfusion.WinForms.Input.SfDateTimeEdit _txtCommonDate_0;
		public System.Windows.Forms.Button cmdGenerate;
		public System.Windows.Forms.TextBox txtHolidayNo;
		public System.Windows.Forms.Label lblHolidayCode;
		public System.Windows.Forms.Label lblLGroupName;
		public System.Windows.Forms.TextBox txtLHolidayName;
		public System.Windows.Forms.Label lblAGroupName;
		public System.Windows.Forms.TextBox txtAHolidayName;
		public Syncfusion.WinForms.Input.SfDateTimeEdit txtHolidayDate;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_0_grdHolidayDetails;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_1_grdHolidayDetails;
		public C1.Win.C1TrueDBGrid.C1TrueDBGrid grdHolidayDetails;
		private System.Windows.Forms.Label _System.Windows.Forms.Label1_0;
		private System.Windows.Forms.Label _System.Windows.Forms.Label1_1;
		public System.Windows.Forms.Label lblCalendar;
		public System.Windows.Forms.TextBox txtCalendarCd;
		public System.Windows.Forms.Label txtDlblCalendarName;
		public System.Windows.Forms.Label[] System.Windows.Forms.Label1 = new System.Windows.Forms.Label[2];
		public Syncfusion.WinForms.Input.SfDateTimeEdit[] txtCommonDate = new Syncfusion.WinForms.Input.SfDateTimeEdit[2];
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPayHoliday));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this._txtCommonDate_1 = new Syncfusion.WinForms.Input.SfDateTimeEdit();
			this._txtCommonDate_0 = new Syncfusion.WinForms.Input.SfDateTimeEdit();
			this.cmdGenerate = new System.Windows.Forms.Button();
			this.txtHolidayNo = new System.Windows.Forms.TextBox();
			this.lblHolidayCode = new System.Windows.Forms.Label();
			this.lblLGroupName = new System.Windows.Forms.Label();
			this.txtLHolidayName = new System.Windows.Forms.TextBox();
			this.lblAGroupName = new System.Windows.Forms.Label();
			this.txtAHolidayName = new System.Windows.Forms.TextBox();
			this.txtHolidayDate = new Syncfusion.WinForms.Input.SfDateTimeEdit();
			this.grdHolidayDetails = new C1.Win.C1TrueDBGrid.C1TrueDBGrid();
			this.Column_0_grdHolidayDetails = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.Column_1_grdHolidayDetails = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this._System.Windows.Forms.Label1_0 = new System.Windows.Forms.Label();
			this._System.Windows.Forms.Label1_1 = new System.Windows.Forms.Label();
			this.lblCalendar = new System.Windows.Forms.Label();
			this.txtCalendarCd = new System.Windows.Forms.TextBox();
			this.txtDlblCalendarName = new System.Windows.Forms.Label();
			// //((System.ComponentModel.ISupportInitialize) this.txtHolidayDate).BeginInit();
			this.grdHolidayDetails.SuspendLayout();
			this.SuspendLayout();
			// 
			// _txtCommonDate_1
			// 
			this._txtCommonDate_1.AllowDrop = true;
			// this._txtCommonDate_1.CheckDateRange = false;
			this._txtCommonDate_1.Location = new System.Drawing.Point(207, 135);
			// this._txtCommonDate_1.MaxDate = 2958465;
			// this._txtCommonDate_1.MinDate = -657434;
			this._txtCommonDate_1.Name = "_txtCommonDate_1";
			this._txtCommonDate_1.PromptChar = "_";
			this._txtCommonDate_1.Size = new System.Drawing.Size(100, 19);
			this._txtCommonDate_1.TabIndex = 5;
			this._txtCommonDate_1.Text = "05/06/2011";
			this._txtCommonDate_1.Value = 40699;
			// 
			// _txtCommonDate_0
			// 
			this._txtCommonDate_0.AllowDrop = true;
			// this._txtCommonDate_0.CheckDateRange = false;
			this._txtCommonDate_0.Location = new System.Drawing.Point(60, 135);
			// this._txtCommonDate_0.MaxDate = 2958465;
			// this._txtCommonDate_0.MinDate = -657434;
			this._txtCommonDate_0.Name = "_txtCommonDate_0";
			this._txtCommonDate_0.PromptChar = "_";
			this._txtCommonDate_0.Size = new System.Drawing.Size(100, 19);
			this._txtCommonDate_0.TabIndex = 4;
			this._txtCommonDate_0.Text = "05/06/2011";
			this._txtCommonDate_0.Value = 40699;
			// 
			// cmdGenerate
			// 
			this.cmdGenerate.AllowDrop = true;
			this.cmdGenerate.BackColor = System.Drawing.SystemColors.Control;
			this.cmdGenerate.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdGenerate.Location = new System.Drawing.Point(324, 135);
			this.cmdGenerate.Name = "cmdGenerate";
			this.cmdGenerate.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdGenerate.Size = new System.Drawing.Size(73, 19);
			this.cmdGenerate.TabIndex = 6;
			this.cmdGenerate.Text = "Generate";
			this.cmdGenerate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.cmdGenerate.UseVisualStyleBackColor = false;
			// this.cmdGenerate.Click += new System.EventHandler(this.cmdGenerate_Click);
			// 
			// txtHolidayNo
			// 
			this.txtHolidayNo.AllowDrop = true;
			this.txtHolidayNo.BackColor = System.Drawing.Color.White;
			// this.txtHolidayNo.bolNumericOnly = true;
			this.txtHolidayNo.ForeColor = System.Drawing.Color.Black;
			this.txtHolidayNo.Location = new System.Drawing.Point(122, 42);
			this.txtHolidayNo.MaxLength = 15;
			// this.txtHolidayNo.mDropDownType = System.Windows.Forms.TextBox.DropDownTypes.ddtNextNumber;
			this.txtHolidayNo.Name = "txtHolidayNo";
			// this.txtHolidayNo.ShowButton = true;
			this.txtHolidayNo.Size = new System.Drawing.Size(98, 19);
			this.txtHolidayNo.TabIndex = 0;
			this.txtHolidayNo.Text = "";
			// 
			// lblHolidayCode
			// 
			this.lblHolidayCode.AllowDrop = true;
			this.lblHolidayCode.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblHolidayCode.Text = "Holiday Code";
			this.lblHolidayCode.Location = new System.Drawing.Point(6, 44);
			// this.lblHolidayCode.mLabelId = 2073;
			this.lblHolidayCode.Name = "lblHolidayCode";
			this.lblHolidayCode.Size = new System.Drawing.Size(63, 14);
			this.lblHolidayCode.TabIndex = 8;
			// 
			// lblLGroupName
			// 
			this.lblLGroupName.AllowDrop = true;
			this.lblLGroupName.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblLGroupName.Text = "Holiday Name (English)";
			this.lblLGroupName.Location = new System.Drawing.Point(6, 66);
			// this.lblLGroupName.mLabelId = 2052;
			this.lblLGroupName.Name = "lblLGroupName";
			this.lblLGroupName.Size = new System.Drawing.Size(110, 14);
			this.lblLGroupName.TabIndex = 9;
			// 
			// txtLHolidayName
			// 
			this.txtLHolidayName.AllowDrop = true;
			this.txtLHolidayName.BackColor = System.Drawing.Color.White;
			this.txtLHolidayName.ForeColor = System.Drawing.Color.Black;
			this.txtLHolidayName.Location = new System.Drawing.Point(122, 63);
			this.txtLHolidayName.MaxLength = 50;
			this.txtLHolidayName.Name = "txtLHolidayName";
			this.txtLHolidayName.Size = new System.Drawing.Size(273, 19);
			this.txtLHolidayName.TabIndex = 1;
			this.txtLHolidayName.Text = "";
			// 
			// lblAGroupName
			// 
			this.lblAGroupName.AllowDrop = true;
			this.lblAGroupName.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblAGroupName.Text = "Holiday Name (Arabic)";
			this.lblAGroupName.Location = new System.Drawing.Point(6, 87);
			// this.lblAGroupName.mLabelId = 2053;
			this.lblAGroupName.Name = "lblAGroupName";
			this.lblAGroupName.Size = new System.Drawing.Size(108, 14);
			this.lblAGroupName.TabIndex = 10;
			// 
			// txtAHolidayName
			// 
			this.txtAHolidayName.AllowDrop = true;
			this.txtAHolidayName.BackColor = System.Drawing.Color.White;
			this.txtAHolidayName.ForeColor = System.Drawing.Color.Black;
			this.txtAHolidayName.Location = new System.Drawing.Point(122, 84);
			// this.txtAHolidayName.mArabicEnabled = true;
			this.txtAHolidayName.MaxLength = 50;
			this.txtAHolidayName.Name = "txtAHolidayName";
			this.txtAHolidayName.Size = new System.Drawing.Size(273, 19);
			this.txtAHolidayName.TabIndex = 2;
			this.txtAHolidayName.Text = "";
			// 
			// txtHolidayDate
			// 
			this.txtHolidayDate.AllowDrop = true;
			this.txtHolidayDate.Location = new System.Drawing.Point(186, 222);
			this.txtHolidayDate.Name = "txtHolidayDate";
			("txtHolidayDate.OcxState");
			this.txtHolidayDate.Size = new System.Drawing.Size(109, 19);
			this.txtHolidayDate.TabIndex = 11;
			this.txtHolidayDate.Visible = false;
			// 
			// grdHolidayDetails
			// 
			this.grdHolidayDetails.AllowDrop = true;
			this.grdHolidayDetails.BackColor = System.Drawing.Color.FromArgb(212, 208, 200);
			this.grdHolidayDetails.CellTipsWidth = 0;
			this.grdHolidayDetails.Location = new System.Drawing.Point(0, 165);
			this.grdHolidayDetails.Name = "grdHolidayDetails";
			this.grdHolidayDetails.RowDivider.Color = System.Drawing.Color.FromArgb(212, 208, 200);
			this.grdHolidayDetails.Size = new System.Drawing.Size(398, 232);
			this.grdHolidayDetails.TabIndex = 7;
			this.grdHolidayDetails.Columns.Add(this.Column_0_grdHolidayDetails);
			this.grdHolidayDetails.Columns.Add(this.Column_1_grdHolidayDetails);
			// 
			// Column_0_grdHolidayDetails
			// 
			this.Column_0_grdHolidayDetails.DataField = "";
			this.Column_0_grdHolidayDetails.ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.Normal;
			// 
			// Column_1_grdHolidayDetails
			// 
			this.Column_1_grdHolidayDetails.DataField = "";
			this.Column_1_grdHolidayDetails.ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.Normal;
			// 
			// _System.Windows.Forms.Label1_0
			// 
			this._System.Windows.Forms.Label1_0.AllowDrop = true;
			this._System.Windows.Forms.Label1_0.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._System.Windows.Forms.Label1_0.Caption = "FromDate";
			this._System.Windows.Forms.Label1_0.Location = new System.Drawing.Point(3, 137);
			this._System.Windows.Forms.Label1_0.Name = "_System.Windows.Forms.Label1_0";
			this._System.Windows.Forms.Label1_0.Size = new System.Drawing.Size(46, 14);
			this._System.Windows.Forms.Label1_0.TabIndex = 12;
			// 
			// _System.Windows.Forms.Label1_1
			// 
			this._System.Windows.Forms.Label1_1.AllowDrop = true;
			this._System.Windows.Forms.Label1_1.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._System.Windows.Forms.Label1_1.Caption = "ToDate";
			this._System.Windows.Forms.Label1_1.Location = new System.Drawing.Point(168, 137);
			this._System.Windows.Forms.Label1_1.Name = "_System.Windows.Forms.Label1_1";
			this._System.Windows.Forms.Label1_1.Size = new System.Drawing.Size(34, 14);
			this._System.Windows.Forms.Label1_1.TabIndex = 13;
			// 
			// lblCalendar
			// 
			this.lblCalendar.AllowDrop = true;
			this.lblCalendar.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblCalendar.Text = "Calendar Code";
			this.lblCalendar.Location = new System.Drawing.Point(6, 111);
			this.lblCalendar.Name = "lblCalendar";
			this.lblCalendar.Size = new System.Drawing.Size(71, 14);
			this.lblCalendar.TabIndex = 14;
			// 
			// txtCalendarCd
			// 
			this.txtCalendarCd.AllowDrop = true;
			this.txtCalendarCd.BackColor = System.Drawing.Color.White;
			// this.txtCalendarCd.bolNumericOnly = true;
			this.txtCalendarCd.ForeColor = System.Drawing.Color.Black;
			this.txtCalendarCd.Location = new System.Drawing.Point(122, 105);
			this.txtCalendarCd.MaxLength = 8;
			this.txtCalendarCd.Name = "txtCalendarCd";
			// this.txtCalendarCd.ShowButton = true;
			this.txtCalendarCd.Size = new System.Drawing.Size(101, 19);
			this.txtCalendarCd.TabIndex = 3;
			this.txtCalendarCd.Text = "";
			// this.this.txtCalendarCd.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCalendarCd_DropButtonClick);
			// this.txtCalendarCd.Leave += new System.EventHandler(this.txtCalendarCd_Leave);
			// 
			// txtDlblCalendarName
			// 
			this.txtDlblCalendarName.AllowDrop = true;
			this.txtDlblCalendarName.Location = new System.Drawing.Point(225, 105);
			this.txtDlblCalendarName.Name = "txtDlblCalendarName";
			this.txtDlblCalendarName.Size = new System.Drawing.Size(170, 19);
			this.txtDlblCalendarName.TabIndex = 15;
			this.txtDlblCalendarName.TabStop = false;
			// 
			// frmPayHoliday
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.ClientSize = new System.Drawing.Size(401, 402);
			this.Controls.Add(this._txtCommonDate_1);
			this.Controls.Add(this._txtCommonDate_0);
			this.Controls.Add(this.cmdGenerate);
			this.Controls.Add(this.txtHolidayNo);
			this.Controls.Add(this.lblHolidayCode);
			this.Controls.Add(this.lblLGroupName);
			this.Controls.Add(this.txtLHolidayName);
			this.Controls.Add(this.lblAGroupName);
			this.Controls.Add(this.txtAHolidayName);
			this.Controls.Add(this.txtHolidayDate);
			this.Controls.Add(this.grdHolidayDetails);
			this.Controls.Add(this._System.Windows.Forms.Label1_0);
			this.Controls.Add(this._System.Windows.Forms.Label1_1);
			this.Controls.Add(this.lblCalendar);
			this.Controls.Add(this.txtCalendarCd);
			this.Controls.Add(this.txtDlblCalendarName);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			//this.Icon = (System.Drawing.Icon) resources.GetObject("frmPayHoliday.Icon");
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(478, 137);
			this.MaximizeBox = true;
			this.MinimizeBox = true;
			this.Name = "frmPayHoliday";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Holiday";
			// this.Activated += new System.EventHandler(this.frmPayHoliday_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
			// this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
			//((System.ComponentModel.ISupportInitialize) this.txtHolidayDate).EndInit();
			this.grdHolidayDetails.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		void ReLoadForm(bool addEvents)
		{
			InitializetxtCommonDate();
			InitializeSystem.Windows.Forms.Label1();
			//This form is an MDI child.
			//This code simulates the VB6 
			// functionality of automatically
			// loading and showing an MDI
			// child's parent.
			this.MdiParent = Xtreme.frmSysMain.DefInstance;
			Xtreme.frmSysMain.DefInstance.Show();
		}
		void InitializetxtCommonDate()
		{
			this.txtCommonDate = new Syncfusion.WinForms.Input.SfDateTimeEdit[2];
			this.txtCommonDate[1] = _txtCommonDate_1;
			this.txtCommonDate[0] = _txtCommonDate_0;
		}
		void InitializeSystem.Windows.Forms.Label1()
		{
			this.System.Windows.Forms.Label1 = new System.Windows.Forms.Label[2];
			this.System.Windows.Forms.Label1[0] = _System.Windows.Forms.Label1_0;
			this.System.Windows.Forms.Label1[1] = _System.Windows.Forms.Label1_1;
		}
		#endregion
	}
}