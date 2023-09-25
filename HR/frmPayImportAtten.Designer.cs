
namespace Xtreme
{
	partial class frmPayImportAtten
	{

		#region "Upgrade Support "
		private static frmPayImportAtten m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmPayImportAtten DefInstance
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
		public static frmPayImportAtten CreateInstance()
		{
			frmPayImportAtten theInstance = new frmPayImportAtten();
			
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
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "chkIncludeLeaveEmployee", "lblerrorpath", "txtErrorFilePAth", "_optDownloadFormat_3", "txtDate", "lblDate", "_optDownloadFormat_2", "_optDownloadFormat_1", "_optDownloadFormat_0", "Frame1", "btnDeleteLine", "cmdMigrate", "cmdVerify", "btnLoadGrid", "grdMigrate2", "CommonDialog1Open", "CommonDialog1", "lblmsg", "optDownloadFormat"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public System.Windows.Forms.CheckBox chkIncludeLeaveEmployee;
		public System.Windows.Forms.Label lblerrorpath;
		public System.Windows.Forms.TextBox txtErrorFilePAth;
		private System.Windows.Forms.RadioButton _optDownloadFormat_3;
		public Syncfusion.WinForms.Input.SfDateTimeEdit txtDate;
		public System.Windows.Forms.Label lblDate;
		private System.Windows.Forms.RadioButton _optDownloadFormat_2;
		private System.Windows.Forms.RadioButton _optDownloadFormat_1;
		private System.Windows.Forms.RadioButton _optDownloadFormat_0;
		public System.Windows.Forms.GroupBox Frame1;
		public System.Windows.Forms.Button btnDeleteLine;
		public System.Windows.Forms.Button cmdMigrate;
		public System.Windows.Forms.Button cmdVerify;
		public System.Windows.Forms.Button btnLoadGrid;
		public C1.Win.C1FlexGrid.C1FlexGrid grdMigrate2;
		public System.Windows.Forms.OpenFileDialog CommonDialog1Open;
		public UpgradeStubs.AxMSComDlg_AxCommonDialog CommonDialog1;
		public System.Windows.Forms.Label lblmsg;
		public System.Windows.Forms.RadioButton[] optDownloadFormat = new System.Windows.Forms.RadioButton[4];
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPayImportAtten));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this.chkIncludeLeaveEmployee = new System.Windows.Forms.CheckBox();
			this.lblerrorpath = new System.Windows.Forms.Label();
			this.txtErrorFilePAth = new System.Windows.Forms.TextBox();
			this.Frame1 = new System.Windows.Forms.GroupBox();
			this._optDownloadFormat_3 = new System.Windows.Forms.RadioButton();
			this.txtDate = new Syncfusion.WinForms.Input.SfDateTimeEdit();
			this.lblDate = new System.Windows.Forms.Label();
			this._optDownloadFormat_2 = new System.Windows.Forms.RadioButton();
			this._optDownloadFormat_1 = new System.Windows.Forms.RadioButton();
			this._optDownloadFormat_0 = new System.Windows.Forms.RadioButton();
			this.btnDeleteLine = new System.Windows.Forms.Button();
			this.cmdMigrate = new System.Windows.Forms.Button();
			this.cmdVerify = new System.Windows.Forms.Button();
			this.btnLoadGrid = new System.Windows.Forms.Button();
			this.grdMigrate2 = new C1.Win.C1FlexGrid.C1FlexGrid();
			this.CommonDialog1Open = new System.Windows.Forms.OpenFileDialog();
			this.CommonDialog1 = new UpgradeStubs.AxMSComDlg_AxCommonDialog();
			this.lblmsg = new System.Windows.Forms.Label();
			this.Frame1.SuspendLayout();
			this.SuspendLayout();
			// 
			// chkIncludeLeaveEmployee
			// 
			this.chkIncludeLeaveEmployee.AllowDrop = true;
			this.chkIncludeLeaveEmployee.Appearance = System.Windows.Forms.Appearance.Normal;
			this.chkIncludeLeaveEmployee.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			this.chkIncludeLeaveEmployee.CausesValidation = true;
			this.chkIncludeLeaveEmployee.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkIncludeLeaveEmployee.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this.chkIncludeLeaveEmployee.Enabled = true;
			this.chkIncludeLeaveEmployee.ForeColor = System.Drawing.Color.Navy;
			this.chkIncludeLeaveEmployee.Location = new System.Drawing.Point(816, 57);
			this.chkIncludeLeaveEmployee.Name = "chkIncludeLeaveEmployee";
			this.chkIncludeLeaveEmployee.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.chkIncludeLeaveEmployee.Size = new System.Drawing.Size(187, 19);
			this.chkIncludeLeaveEmployee.TabIndex = 14;
			this.chkIncludeLeaveEmployee.TabStop = true;
			this.chkIncludeLeaveEmployee.Text = "Exclude Employee On Leave";
			this.chkIncludeLeaveEmployee.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkIncludeLeaveEmployee.Visible = false;
			// 
			// lblerrorpath
			// 
			this.lblerrorpath.AllowDrop = true;
			this.lblerrorpath.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblerrorpath.Text = "Error File Path";
			this.lblerrorpath.Location = new System.Drawing.Point(123, 15);
			this.lblerrorpath.Name = "lblerrorpath";
			this.lblerrorpath.Size = new System.Drawing.Size(67, 14);
			this.lblerrorpath.TabIndex = 13;
			// 
			// txtErrorFilePAth
			// 
			this.txtErrorFilePAth.AllowDrop = true;
			this.txtErrorFilePAth.BackColor = System.Drawing.Color.White;
			// this.txtErrorFilePAth.bolAllowDecimal = false;
			this.txtErrorFilePAth.ForeColor = System.Drawing.Color.Black;
			this.txtErrorFilePAth.Location = new System.Drawing.Point(201, 12);
			// this.txtErrorFilePAth.mDropDownType = (System.Windows.Forms.TextBox.DropDownTypes) 0;
			this.txtErrorFilePAth.Name = "txtErrorFilePAth";
			this.txtErrorFilePAth.Size = new System.Drawing.Size(322, 19);
			this.txtErrorFilePAth.TabIndex = 12;
			this.txtErrorFilePAth.Text = "";
			// this.this.txtErrorFilePAth.Watermark = "";
			// 
			// Frame1
			// 
			this.Frame1.AllowDrop = true;
			this.Frame1.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.Frame1.Controls.Add(this._optDownloadFormat_3);
			this.Frame1.Controls.Add(this.txtDate);
			this.Frame1.Controls.Add(this.lblDate);
			this.Frame1.Controls.Add(this._optDownloadFormat_2);
			this.Frame1.Controls.Add(this._optDownloadFormat_1);
			this.Frame1.Controls.Add(this._optDownloadFormat_0);
			this.Frame1.Enabled = true;
			this.Frame1.ForeColor = System.Drawing.SystemColors.WindowText;
			this.Frame1.Location = new System.Drawing.Point(572, 6);
			this.Frame1.Name = "Frame1";
			this.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Frame1.Size = new System.Drawing.Size(449, 77);
			this.Frame1.TabIndex = 6;
			this.Frame1.Visible = true;
			// 
			// _optDownloadFormat_3
			// 
			this._optDownloadFormat_3.AllowDrop = true;
			this._optDownloadFormat_3.Appearance = System.Windows.Forms.Appearance.Normal;
			this._optDownloadFormat_3.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._optDownloadFormat_3.CausesValidation = true;
			this._optDownloadFormat_3.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._optDownloadFormat_3.Checked = false;
			this._optDownloadFormat_3.Enabled = true;
			this._optDownloadFormat_3.ForeColor = System.Drawing.Color.Navy;
			this._optDownloadFormat_3.Location = new System.Drawing.Point(14, 33);
			this._optDownloadFormat_3.Name = "_optDownloadFormat_3";
			this._optDownloadFormat_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._optDownloadFormat_3.Size = new System.Drawing.Size(161, 17);
			this._optDownloadFormat_3.TabIndex = 15;
			this._optDownloadFormat_3.TabStop = true;
			this._optDownloadFormat_3.Text = "Import Approved Attendance";
			this._optDownloadFormat_3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._optDownloadFormat_3.Visible = false;
			this._optDownloadFormat_3.CheckedChanged += new System.EventHandler(this.optDownloadFormat_CheckedChanged);
			// 
			// txtDate
			// 
			this.txtDate.AllowDrop = true;
			// this.txtDate.CheckDateRange = false;
			this.txtDate.Location = new System.Drawing.Point(94, 51);
			// this.txtDate.MaxDate = 2958465;
			// this.txtDate.MinDate = -657434;
			this.txtDate.Name = "txtDate";
			this.txtDate.PromptChar = "_";
			this.txtDate.Size = new System.Drawing.Size(105, 19);
			this.txtDate.TabIndex = 11;
			// this.txtDate.Text = "31-Oct-2011";
			// this.txtDate.Value = 40847;
			this.txtDate.Visible = false;
			// 
			// lblDate
			// 
			this.lblDate.AllowDrop = true;
			this.lblDate.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			// this.lblDate.Text = "For The Period";
			this.lblDate.Location = new System.Drawing.Point(12, 54);
			this.lblDate.Name = "lblDate";
			this.lblDate.Size = new System.Drawing.Size(70, 14);
			this.lblDate.TabIndex = 10;
			this.lblDate.Visible = false;
			// 
			// _optDownloadFormat_2
			// 
			this._optDownloadFormat_2.AllowDrop = true;
			this._optDownloadFormat_2.Appearance = System.Windows.Forms.Appearance.Normal;
			this._optDownloadFormat_2.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._optDownloadFormat_2.CausesValidation = true;
			this._optDownloadFormat_2.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._optDownloadFormat_2.Checked = false;
			this._optDownloadFormat_2.Enabled = true;
			this._optDownloadFormat_2.ForeColor = System.Drawing.Color.Navy;
			this._optDownloadFormat_2.Location = new System.Drawing.Point(244, 31);
			this._optDownloadFormat_2.Name = "_optDownloadFormat_2";
			this._optDownloadFormat_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._optDownloadFormat_2.Size = new System.Drawing.Size(161, 17);
			this._optDownloadFormat_2.TabIndex = 9;
			this._optDownloadFormat_2.TabStop = true;
			this._optDownloadFormat_2.Text = "Import OverTime For Project";
			this._optDownloadFormat_2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._optDownloadFormat_2.Visible = true;
			this._optDownloadFormat_2.CheckedChanged += new System.EventHandler(this.optDownloadFormat_CheckedChanged);
			// 
			// _optDownloadFormat_1
			// 
			this._optDownloadFormat_1.AllowDrop = true;
			this._optDownloadFormat_1.Appearance = System.Windows.Forms.Appearance.Normal;
			this._optDownloadFormat_1.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._optDownloadFormat_1.CausesValidation = true;
			this._optDownloadFormat_1.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._optDownloadFormat_1.Checked = false;
			this._optDownloadFormat_1.Enabled = true;
			this._optDownloadFormat_1.ForeColor = System.Drawing.Color.Navy;
			this._optDownloadFormat_1.Location = new System.Drawing.Point(244, 11);
			this._optDownloadFormat_1.Name = "_optDownloadFormat_1";
			this._optDownloadFormat_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._optDownloadFormat_1.Size = new System.Drawing.Size(161, 17);
			this._optDownloadFormat_1.TabIndex = 8;
			this._optDownloadFormat_1.TabStop = true;
			this._optDownloadFormat_1.Text = "Import OverTime For Payroll";
			this._optDownloadFormat_1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._optDownloadFormat_1.Visible = true;
			this._optDownloadFormat_1.CheckedChanged += new System.EventHandler(this.optDownloadFormat_CheckedChanged);
			// 
			// _optDownloadFormat_0
			// 
			this._optDownloadFormat_0.AllowDrop = true;
			this._optDownloadFormat_0.Appearance = System.Windows.Forms.Appearance.Normal;
			this._optDownloadFormat_0.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._optDownloadFormat_0.CausesValidation = true;
			this._optDownloadFormat_0.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._optDownloadFormat_0.Checked = false;
			this._optDownloadFormat_0.Enabled = true;
			this._optDownloadFormat_0.ForeColor = System.Drawing.Color.Navy;
			this._optDownloadFormat_0.Location = new System.Drawing.Point(14, 14);
			this._optDownloadFormat_0.Name = "_optDownloadFormat_0";
			this._optDownloadFormat_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._optDownloadFormat_0.Size = new System.Drawing.Size(221, 17);
			this._optDownloadFormat_0.TabIndex = 7;
			this._optDownloadFormat_0.TabStop = true;
			this._optDownloadFormat_0.Text = "Import Time & Attendance";
			this._optDownloadFormat_0.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._optDownloadFormat_0.Visible = true;
			this._optDownloadFormat_0.CheckedChanged += new System.EventHandler(this.optDownloadFormat_CheckedChanged);
			// 
			// btnDeleteLine
			// 
			this.btnDeleteLine.AllowDrop = true;
			this.btnDeleteLine.BackColor = System.Drawing.SystemColors.Control;
			this.btnDeleteLine.ForeColor = System.Drawing.SystemColors.ControlText;
			this.btnDeleteLine.Location = new System.Drawing.Point(544, 24);
			this.btnDeleteLine.Name = "btnDeleteLine";
			this.btnDeleteLine.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.btnDeleteLine.Size = new System.Drawing.Size(25, 21);
			this.btnDeleteLine.TabIndex = 4;
			this.btnDeleteLine.Text = "&Delete Line";
			this.btnDeleteLine.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.btnDeleteLine.UseVisualStyleBackColor = false;
			this.btnDeleteLine.Visible = false;
			// this.btnDeleteLine.Click += new System.EventHandler(this.btnDeleteLine_Click);
			// 
			// cmdMigrate
			// 
			this.cmdMigrate.AllowDrop = true;
			this.cmdMigrate.BackColor = System.Drawing.SystemColors.Control;
			this.cmdMigrate.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdMigrate.Location = new System.Drawing.Point(3, 39);
			this.cmdMigrate.Name = "cmdMigrate";
			this.cmdMigrate.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdMigrate.Size = new System.Drawing.Size(100, 33);
			this.cmdMigrate.TabIndex = 3;
			// this.cmdMigrate.Text = "&Import Attendance";
			// this.cmdMigrate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.cmdMigrate.UseVisualStyleBackColor = false;
			// this.cmdMigrate.Click += new System.EventHandler(this.cmdMigrate_Click);
			// 
			// cmdVerify
			// 
			this.cmdVerify.AllowDrop = true;
			this.cmdVerify.BackColor = System.Drawing.SystemColors.Control;
			this.cmdVerify.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdVerify.Location = new System.Drawing.Point(544, 2);
			this.cmdVerify.Name = "cmdVerify";
			this.cmdVerify.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdVerify.Size = new System.Drawing.Size(25, 21);
			this.cmdVerify.TabIndex = 2;
			this.cmdVerify.Text = "&Verify";
			this.cmdVerify.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.cmdVerify.UseVisualStyleBackColor = false;
			this.cmdVerify.Visible = false;
			// this.cmdVerify.Click += new System.EventHandler(this.cmdVerify_Click);
			// 
			// btnLoadGrid
			// 
			this.btnLoadGrid.AllowDrop = true;
			this.btnLoadGrid.BackColor = System.Drawing.SystemColors.Control;
			this.btnLoadGrid.ForeColor = System.Drawing.SystemColors.ControlText;
			this.btnLoadGrid.Location = new System.Drawing.Point(3, 4);
			this.btnLoadGrid.Name = "btnLoadGrid";
			this.btnLoadGrid.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.btnLoadGrid.Size = new System.Drawing.Size(100, 33);
			this.btnLoadGrid.TabIndex = 1;
			this.btnLoadGrid.Text = "&Load Excel Data";
			this.btnLoadGrid.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.btnLoadGrid.UseVisualStyleBackColor = false;
			// this.btnLoadGrid.Click += new System.EventHandler(this.btnLoadGrid_Click);
			// 
			// grdMigrate2
			// 
			this.grdMigrate2.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None;
			this.grdMigrate2.AllowDrop = true;
			this.grdMigrate2.AllowEditing = true;
			this.grdMigrate2.AllowFreezing = C1.Win.C1FlexGrid.AllowFreezingEnum.None;
			this.grdMigrate2.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.None;
			this.grdMigrate2.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.Columns;
			this.grdMigrate2.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.Columns;
			this.grdMigrate2.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.SingleColumn;
			this.grdMigrate2.AutoResize = true;
			this.grdMigrate2.AutoSearch = C1.Win.C1FlexGrid.AutoSearchEnum.None;
			this.grdMigrate2.AutoSearchDelay = 5;
			this.grdMigrate2.BackColor = System.Drawing.SystemColors.Window;
			this.grdMigrate2.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.Fixed3D;
			this.grdMigrate2.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.None;
			this.grdMigrate2.Cols.Count = 10;
			this.grdMigrate2.Cols.Fixed = 1;
			this.grdMigrate2.Cols.Frozen = 0;
			this.grdMigrate2.Cols.MaxSize = 0;
			this.grdMigrate2.Cols.MinSize = 0;
			this.grdMigrate2.Cursor = System.Windows.Forms.Cursors.Default;
			this.grdMigrate2.DrawMode = C1.Win.C1FlexGrid.DrawModeEnum.Normal;
			this.grdMigrate2.EditOptions = (C1.Win.C1FlexGrid.EditFlags) (C1.Win.C1FlexGrid.EditFlags.AutoSearch | C1.Win.C1FlexGrid.EditFlags.CycleOnDoubleClick | C1.Win.C1FlexGrid.EditFlags.MultiCheck | C1.Win.C1FlexGrid.EditFlags.DelayedCommit | C1.Win.C1FlexGrid.EditFlags.ExitOnLeftRightKeys | C1.Win.C1FlexGrid.EditFlags.EditOnRequest);
			this.grdMigrate2.Enabled = true;
			this.grdMigrate2.ExtendLastCol = false;
			this.grdMigrate2.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.Light;
			this.grdMigrate2.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 178);
			this.grdMigrate2.ForeColor = System.Drawing.SystemColors.WindowText;
			this.grdMigrate2.HighLight = C1.Win.C1FlexGrid.HighLightEnum.Always;
			this.grdMigrate2.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.None;
			this.grdMigrate2.Location = new System.Drawing.Point(2, 90);
			this.grdMigrate2.Name = "grdMigrate2";
			this.grdMigrate2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.grdMigrate2.Rows.Count = 50;
			this.grdMigrate2.Rows.Fixed = 1;
			this.grdMigrate2.Rows.Frozen = 0;
			this.grdMigrate2.Rows.MaxSize = 0;
			this.grdMigrate2.Rows.MinSize = 0;
			this.grdMigrate2.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.grdMigrate2.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Default;
			// this.grdMigrate2.ShowButtons = C1.Win.C1FlexGrid.ShowButtonsEnum.WhenEditing;
			this.grdMigrate2.ShowSortPosition = C1.Win.C1FlexGrid.ShowSortPositionEnum.None;
			this.grdMigrate2.Size = new System.Drawing.Size(1023, 435);
			this.grdMigrate2.Styles.Alternate.BackColor = System.Drawing.SystemColors.Window;
			this.grdMigrate2.Styles.EmptyArea.BackColor = System.Drawing.Color.Gray;
			this.grdMigrate2.Styles.Fixed.BackColor = System.Drawing.SystemColors.Control;
			this.grdMigrate2.Styles.Fixed.Border.Color = System.Drawing.SystemColors.ControlDark;
			this.grdMigrate2.Styles.Fixed.Border.Direction = C1.Win.C1FlexGrid.BorderDirEnum.Both;
			this.grdMigrate2.Styles.Fixed.Border.Style = C1.Win.C1FlexGrid.BorderStyleEnum.Inset;
			this.grdMigrate2.Styles.Fixed.ForeColor = System.Drawing.SystemColors.ControlText;
			this.grdMigrate2.Styles.Fixed.TextEffect = C1.Win.C1FlexGrid.TextEffectEnum.Flat;
			this.grdMigrate2.Styles.Frozen.BackColor = System.Drawing.Color.Black;
			this.grdMigrate2.Styles.Frozen.ForeColor = System.Drawing.Color.Black;
			this.grdMigrate2.Styles.Highlight.BackColor = System.Drawing.SystemColors.Highlight;
			this.grdMigrate2.Styles.Highlight.ForeColor = System.Drawing.SystemColors.HighlightText;
			this.grdMigrate2.Styles.Normal.Border.Color = System.Drawing.SystemColors.Control;
			this.grdMigrate2.Styles.Normal.Border.Direction = C1.Win.C1FlexGrid.BorderDirEnum.Both;
			this.grdMigrate2.Styles.Normal.Border.Style = C1.Win.C1FlexGrid.BorderStyleEnum.Flat;
			this.grdMigrate2.Styles.Normal.Border.Width = 1;
			this.grdMigrate2.Styles.Normal.ImageAlign = C1.Win.C1FlexGrid.ImageAlignEnum.Stretch;
			this.grdMigrate2.Styles.Normal.TextEffect = C1.Win.C1FlexGrid.TextEffectEnum.Flat;
			this.grdMigrate2.Styles.Normal.Trimming = System.Drawing.StringTrimming.None;
			this.grdMigrate2.Styles.Normal.WordWrap = false;
			this.grdMigrate2.Styles[C1.Win.C1FlexGrid.CellStyleEnum.EmptyArea].Border.Color = System.Drawing.SystemColors.WindowFrame;
			this.grdMigrate2.SubtotalPosition = C1.Win.C1FlexGrid.SubtotalPositionEnum.AboveData;
			this.grdMigrate2.TabIndex = 0;
			this.grdMigrate2.Tree.Column = 0;
			this.grdMigrate2.Tree.LineColor = System.Drawing.SystemColors.ControlDark;
			this.grdMigrate2.Tree.Style = C1.Win.C1FlexGrid.TreeStyleFlags.None;
			// 
			// lblmsg
			// 
			this.lblmsg.AllowDrop = true;
			this.lblmsg.BackColor = System.Drawing.Color.Transparent;
			this.lblmsg.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lblmsg.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 178);
			this.lblmsg.ForeColor = System.Drawing.Color.FromArgb(192, 0, 0);
			this.lblmsg.Location = new System.Drawing.Point(112, 44);
			this.lblmsg.Name = "lblmsg";
			this.lblmsg.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblmsg.Size = new System.Drawing.Size(422, 23);
			this.lblmsg.TabIndex = 5;
			// 
			// frmPayImportAtten
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.ClientSize = new System.Drawing.Size(1462, 582);
			this.Controls.Add(this.chkIncludeLeaveEmployee);
			this.Controls.Add(this.lblerrorpath);
			this.Controls.Add(this.txtErrorFilePAth);
			this.Controls.Add(this.Frame1);
			this.Controls.Add(this.btnDeleteLine);
			this.Controls.Add(this.cmdMigrate);
			this.Controls.Add(this.cmdVerify);
			this.Controls.Add(this.btnLoadGrid);
			this.Controls.Add(this.grdMigrate2);
			this.Controls.Add(this.lblmsg);
			//this.Icon = (System.Drawing.Icon) resources.GetObject("frmPayImportAtten.Icon");
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(35, 124);
			this.MaximizeBox = true;
			this.MinimizeBox = true;
			this.Name = "frmPayImportAtten";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Import Attendance";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			// this.Activated += new System.EventHandler(this.frmPayImportAtten_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
			//this.Resize += new System.EventHandler(this.Form_Resize);
			this.Frame1.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		// 
		void InitializeoptDownloadFormat()
		{
			this.optDownloadFormat = new System.Windows.Forms.RadioButton[4];
			this.optDownloadFormat[3] = _optDownloadFormat_3;
			this.optDownloadFormat[2] = _optDownloadFormat_2;
			this.optDownloadFormat[1] = _optDownloadFormat_1;
			this.optDownloadFormat[0] = _optDownloadFormat_0;
		}
		#endregion
	}
}//ENDSHERE
