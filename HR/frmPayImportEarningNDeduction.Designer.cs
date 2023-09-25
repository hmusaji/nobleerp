
namespace Xtreme
{
	partial class frmPayImportEarningNDeduction
	{

		#region "Upgrade Support "
		private static frmPayImportEarningNDeduction m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmPayImportEarningNDeduction DefInstance
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
		public static frmPayImportEarningNDeduction CreateInstance()
		{
			frmPayImportEarningNDeduction theInstance = new frmPayImportEarningNDeduction();
			
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
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "btnDeleteLine", "System.Windows.Forms.Label1", "txtDMonthDate", "chkExcludeLeaveEmployee", "btnLoadGrid", "cmdMigrate", "grdMigrate2", "CommonDialog1Open", "CommonDialog1", "lblProgress", "Line1"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public System.Windows.Forms.Button btnDeleteLine;
		public System.Windows.Forms.Label Label1;
		public Syncfusion.WinForms.Input.SfDateTimeEdit txtDMonthDate;
		public System.Windows.Forms.CheckBox chkExcludeLeaveEmployee;
		public System.Windows.Forms.Button btnLoadGrid;
		public System.Windows.Forms.Button cmdMigrate;
		public C1.Win.C1FlexGrid.C1FlexGrid grdMigrate2;
		public System.Windows.Forms.OpenFileDialog CommonDialog1Open;
		public UpgradeStubs.AxMSComDlg_AxCommonDialog CommonDialog1;
		public System.Windows.Forms.Label lblProgress;
		public System.Windows.Forms.Label Line1;
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPayImportEarningNDeduction));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this.btnDeleteLine = new System.Windows.Forms.Button();
			this.Label1 = new System.Windows.Forms.Label();
			this.txtDMonthDate = new Syncfusion.WinForms.Input.SfDateTimeEdit();
			this.chkExcludeLeaveEmployee = new System.Windows.Forms.CheckBox();
			this.btnLoadGrid = new System.Windows.Forms.Button();
			this.cmdMigrate = new System.Windows.Forms.Button();
			this.grdMigrate2 = new C1.Win.C1FlexGrid.C1FlexGrid();
			this.CommonDialog1Open = new System.Windows.Forms.OpenFileDialog();
			this.CommonDialog1 = new UpgradeStubs.AxMSComDlg_AxCommonDialog();
			this.lblProgress = new System.Windows.Forms.Label();
			this.Line1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// btnDeleteLine
			// 
			this.btnDeleteLine.AllowDrop = true;
			this.btnDeleteLine.BackColor = System.Drawing.SystemColors.Control;
			this.btnDeleteLine.ForeColor = System.Drawing.SystemColors.ControlText;
			this.btnDeleteLine.Location = new System.Drawing.Point(225, 36);
			this.btnDeleteLine.Name = "btnDeleteLine";
			this.btnDeleteLine.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.btnDeleteLine.Size = new System.Drawing.Size(97, 25);
			this.btnDeleteLine.TabIndex = 7;
			this.btnDeleteLine.Text = "&Delete Line";
			this.btnDeleteLine.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.btnDeleteLine.UseVisualStyleBackColor = false;
			// this.btnDeleteLine.Click += new System.EventHandler(this.btnDeleteLine_Click);
			// 
			// System.Windows.Forms.Label1
			// 
			this.Label1.AllowDrop = true;
			this.Label1.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.Label1.Enabled = false;
			this.Label1.Location = new System.Drawing.Point(12, 9);
			this.Label1.Name = "System.Windows.Forms.Label1";
			this.Label1.Size = new System.Drawing.Size(76, 22);
			this.Label1.TabIndex = 6;
			this.Label1.Text = "Current Period";
			// 
			// txtDMonthDate
			// 
			this.txtDMonthDate.AllowDrop = true;
			this.txtDMonthDate.BackColor = System.Drawing.Color.FromArgb(239, 239, 239);
			// this.txtDMonthDate.CheckDateRange = false;
			this.txtDMonthDate.Enabled = false;
			this.txtDMonthDate.Location = new System.Drawing.Point(90, 9);
			// this.txtDMonthDate.MaxDate = 2958465;
			// this.txtDMonthDate.MinDate = -657434;
			this.txtDMonthDate.Name = "txtDMonthDate";
			this.txtDMonthDate.PromptChar = "_";
			this.txtDMonthDate.ReadOnly = true;
			this.txtDMonthDate.Size = new System.Drawing.Size(124, 22);
			this.txtDMonthDate.TabIndex = 5;
			// this.txtDMonthDate.Text = "31-Jan-2012";
			// this.txtDMonthDate.Value = 40939;
			// 
			// chkExcludeLeaveEmployee
			// 
			this.chkExcludeLeaveEmployee.AllowDrop = true;
			this.chkExcludeLeaveEmployee.Appearance = System.Windows.Forms.Appearance.Normal;
			this.chkExcludeLeaveEmployee.BackColor = System.Drawing.SystemColors.Control;
			this.chkExcludeLeaveEmployee.CausesValidation = true;
			this.chkExcludeLeaveEmployee.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkExcludeLeaveEmployee.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this.chkExcludeLeaveEmployee.Enabled = true;
			this.chkExcludeLeaveEmployee.ForeColor = System.Drawing.Color.Black;
			this.chkExcludeLeaveEmployee.Location = new System.Drawing.Point(12, 36);
			this.chkExcludeLeaveEmployee.Name = "chkExcludeLeaveEmployee";
			this.chkExcludeLeaveEmployee.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.chkExcludeLeaveEmployee.Size = new System.Drawing.Size(202, 25);
			this.chkExcludeLeaveEmployee.TabIndex = 2;
			this.chkExcludeLeaveEmployee.TabStop = true;
			this.chkExcludeLeaveEmployee.Text = "Exclude Employee On Leave";
			this.chkExcludeLeaveEmployee.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkExcludeLeaveEmployee.Visible = true;
			// 
			// btnLoadGrid
			// 
			this.btnLoadGrid.AllowDrop = true;
			this.btnLoadGrid.BackColor = System.Drawing.SystemColors.Control;
			this.btnLoadGrid.ForeColor = System.Drawing.SystemColors.ControlText;
			this.btnLoadGrid.Location = new System.Drawing.Point(12, 66);
			this.btnLoadGrid.Name = "btnLoadGrid";
			this.btnLoadGrid.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.btnLoadGrid.Size = new System.Drawing.Size(100, 24);
			this.btnLoadGrid.TabIndex = 1;
			this.btnLoadGrid.Text = "&Load Excel Data";
			this.btnLoadGrid.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.btnLoadGrid.UseVisualStyleBackColor = false;
			// this.btnLoadGrid.Click += new System.EventHandler(this.btnLoadGrid_Click);
			// 
			// cmdMigrate
			// 
			this.cmdMigrate.AllowDrop = true;
			this.cmdMigrate.BackColor = System.Drawing.SystemColors.Control;
			this.cmdMigrate.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdMigrate.Location = new System.Drawing.Point(114, 66);
			this.cmdMigrate.Name = "cmdMigrate";
			this.cmdMigrate.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdMigrate.Size = new System.Drawing.Size(100, 24);
			this.cmdMigrate.TabIndex = 3;
			// this.cmdMigrate.Text = "&Import ";
			// this.cmdMigrate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.cmdMigrate.UseVisualStyleBackColor = false;
			// this.cmdMigrate.Click += new System.EventHandler(this.cmdMigrate_Click);
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
			this.grdMigrate2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 178);
			this.grdMigrate2.ForeColor = System.Drawing.SystemColors.WindowText;
			this.grdMigrate2.HighLight = C1.Win.C1FlexGrid.HighLightEnum.Always;
			this.grdMigrate2.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.None;
			this.grdMigrate2.Location = new System.Drawing.Point(3, 105);
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
			this.grdMigrate2.Size = new System.Drawing.Size(780, 456);
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
			// lblProgress
			// 
			this.lblProgress.AllowDrop = true;
			this.lblProgress.BackColor = System.Drawing.SystemColors.Control;
			this.lblProgress.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lblProgress.ForeColor = System.Drawing.Color.Red;
			this.lblProgress.Location = new System.Drawing.Point(225, 66);
			this.lblProgress.Name = "lblProgress";
			this.lblProgress.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblProgress.Size = new System.Drawing.Size(292, 22);
			this.lblProgress.TabIndex = 4;
			// 
			// Line1
			// 
			this.Line1.AllowDrop = true;
			this.Line1.BackColor = System.Drawing.SystemColors.WindowText;
			this.Line1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Line1.Enabled = false;
			this.Line1.Location = new System.Drawing.Point(3, 99);
			this.Line1.Name = "Line1";
			this.Line1.Size = new System.Drawing.Size(783, 1);
			this.Line1.Visible = true;
			// 
			// frmPayImportEarningNDeduction
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.ClientSize = new System.Drawing.Size(786, 565);
			this.Controls.Add(this.btnDeleteLine);
			this.Controls.Add(this.Label1);
			this.Controls.Add(this.txtDMonthDate);
			this.Controls.Add(this.chkExcludeLeaveEmployee);
			this.Controls.Add(this.btnLoadGrid);
			this.Controls.Add(this.cmdMigrate);
			this.Controls.Add(this.grdMigrate2);
			this.Controls.Add(this.lblProgress);
			this.Controls.Add(this.Line1);
			//this.Icon = (System.Drawing.Icon) resources.GetObject("frmPayImportEarningNDeduction.Icon");
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(227, 193);
			this.MaximizeBox = true;
			this.MinimizeBox = true;
			this.Name = "frmPayImportEarningNDeduction";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Import Earning & Dedcution";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			// this.Activated += new System.EventHandler(this.frmPayImportEarningNDeduction_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
			//this.Resize += new System.EventHandler(this.Form_Resize);
			this.ResumeLayout(false);
		}
		// 
		#endregion
	}
}//ENDSHERE
