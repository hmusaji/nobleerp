
namespace Xtreme
{
	partial class frmICSPriceListUpdate
	{

		#region "Upgrade Support "
		private static frmICSPriceListUpdate m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmICSPriceListUpdate DefInstance
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
		public static frmICSPriceListUpdate CreateInstance()
		{
			frmICSPriceListUpdate theInstance = new frmICSPriceListUpdate();
			
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
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "txtTip", "cmdMigrate", "cmdVerify", "btnLoadGrid", "btnDeleteLine", "grdMigrate1", "grdMigrate2", "CommonDialog1Open", "CommonDialog1", "Line2", "Line1", "Shape1", "frameMain"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public System.Windows.Forms.TextBox txtTip;
		public System.Windows.Forms.Button cmdMigrate;
		public System.Windows.Forms.Button cmdVerify;
		public System.Windows.Forms.Button btnLoadGrid;
		public System.Windows.Forms.Button btnDeleteLine;
		public C1.Win.C1FlexGrid.C1FlexGrid grdMigrate1;
		public C1.Win.C1FlexGrid.C1FlexGrid grdMigrate2;
		public System.Windows.Forms.OpenFileDialog CommonDialog1Open;
		public UpgradeStubs.AxMSComDlg_AxCommonDialog CommonDialog1;
		public System.Windows.Forms.Label Line2;
		public System.Windows.Forms.Label Line1;
		public ShapeHelper Shape1;
		public System.Windows.Forms.GroupBox frameMain;
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmICSPriceListUpdate));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this.frameMain = new System.Windows.Forms.GroupBox();
			this.txtTip = new System.Windows.Forms.TextBox();
			this.cmdMigrate = new System.Windows.Forms.Button();
			this.cmdVerify = new System.Windows.Forms.Button();
			this.btnLoadGrid = new System.Windows.Forms.Button();
			this.btnDeleteLine = new System.Windows.Forms.Button();
			this.grdMigrate1 = new C1.Win.C1FlexGrid.C1FlexGrid();
			this.grdMigrate2 = new C1.Win.C1FlexGrid.C1FlexGrid();
			this.CommonDialog1Open = new System.Windows.Forms.OpenFileDialog();
			this.CommonDialog1 = new UpgradeStubs.AxMSComDlg_AxCommonDialog();
			this.Line2 = new System.Windows.Forms.Label();
			this.Line1 = new System.Windows.Forms.Label();
			this.Shape1 = new ShapeHelper();
			//this.frameMain.SuspendLayout();
			this.SuspendLayout();
			// 
			// frameMain
			// 
			this.frameMain.AllowDrop = true;
			this.frameMain.BackColor = System.Drawing.Color.FromArgb(241, 244, 248);
			this.frameMain.Controls.Add(this.txtTip);
			this.frameMain.Controls.Add(this.cmdMigrate);
			this.frameMain.Controls.Add(this.cmdVerify);
			this.frameMain.Controls.Add(this.btnLoadGrid);
			this.frameMain.Controls.Add(this.btnDeleteLine);
			this.frameMain.Controls.Add(this.grdMigrate1);
			this.frameMain.Controls.Add(this.grdMigrate2);
			this.frameMain.Controls.Add(this.Line2);
			this.frameMain.Controls.Add(this.Line1);
			this.frameMain.Controls.Add(this.Shape1);
			this.frameMain.Enabled = true;
			this.frameMain.ForeColor = System.Drawing.SystemColors.ControlText;
			this.frameMain.Location = new System.Drawing.Point(0, 0);
			this.frameMain.Name = "frameMain";
			this.frameMain.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.frameMain.Size = new System.Drawing.Size(697, 529);
			this.frameMain.TabIndex = 0;
			this.frameMain.Visible = true;
			// 
			// txtTip
			// 
			this.txtTip.AcceptsReturn = true;
			this.txtTip.AllowDrop = true;
			this.txtTip.BackColor = System.Drawing.SystemColors.Window;
			this.txtTip.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.txtTip.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtTip.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 178);
			this.txtTip.ForeColor = System.Drawing.Color.Blue;
			this.txtTip.Location = new System.Drawing.Point(4, 464);
			this.txtTip.MaxLength = 0;
			this.txtTip.Name = "txtTip";
			this.txtTip.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtTip.Size = new System.Drawing.Size(689, 49);
			this.txtTip.TabIndex = 5;
			this.txtTip.TabStop = false;
			this.txtTip.Text = "Text1";
			// 
			// cmdMigrate
			// 
			this.cmdMigrate.AllowDrop = true;
			this.cmdMigrate.BackColor = System.Drawing.SystemColors.Control;
			this.cmdMigrate.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdMigrate.Location = new System.Drawing.Point(344, 18);
			this.cmdMigrate.Name = "cmdMigrate";
			this.cmdMigrate.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdMigrate.Size = new System.Drawing.Size(57, 21);
			this.cmdMigrate.TabIndex = 4;
			// this.cmdMigrate.Text = "&Migrate";
			// this.cmdMigrate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.cmdMigrate.UseVisualStyleBackColor = false;
			// this.cmdMigrate.Click += new System.EventHandler(this.cmdMigrate_Click);
			// 
			// cmdVerify
			// 
			this.cmdVerify.AllowDrop = true;
			this.cmdVerify.BackColor = System.Drawing.SystemColors.Control;
			this.cmdVerify.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdVerify.Location = new System.Drawing.Point(280, 18);
			this.cmdVerify.Name = "cmdVerify";
			this.cmdVerify.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdVerify.Size = new System.Drawing.Size(57, 21);
			this.cmdVerify.TabIndex = 3;
			this.cmdVerify.Text = "&Verify";
			this.cmdVerify.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.cmdVerify.UseVisualStyleBackColor = false;
			// this.cmdVerify.Click += new System.EventHandler(this.cmdVerify_Click);
			// 
			// btnLoadGrid
			// 
			this.btnLoadGrid.AllowDrop = true;
			this.btnLoadGrid.BackColor = System.Drawing.SystemColors.Control;
			this.btnLoadGrid.ForeColor = System.Drawing.SystemColors.ControlText;
			this.btnLoadGrid.Location = new System.Drawing.Point(8, 18);
			this.btnLoadGrid.Name = "btnLoadGrid";
			this.btnLoadGrid.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.btnLoadGrid.Size = new System.Drawing.Size(97, 21);
			this.btnLoadGrid.TabIndex = 2;
			this.btnLoadGrid.Text = "&Load Excel Data";
			this.btnLoadGrid.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.btnLoadGrid.UseVisualStyleBackColor = false;
			// this.btnLoadGrid.Click += new System.EventHandler(this.btnLoadGrid_Click);
			// 
			// btnDeleteLine
			// 
			this.btnDeleteLine.AllowDrop = true;
			this.btnDeleteLine.BackColor = System.Drawing.SystemColors.Control;
			this.btnDeleteLine.ForeColor = System.Drawing.SystemColors.ControlText;
			this.btnDeleteLine.Location = new System.Drawing.Point(112, 18);
			this.btnDeleteLine.Name = "btnDeleteLine";
			this.btnDeleteLine.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.btnDeleteLine.Size = new System.Drawing.Size(97, 21);
			this.btnDeleteLine.TabIndex = 1;
			this.btnDeleteLine.Text = "&Delete Line";
			this.btnDeleteLine.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.btnDeleteLine.UseVisualStyleBackColor = false;
			// this.btnDeleteLine.Click += new System.EventHandler(this.btnDeleteLine_Click);
			// 
			// grdMigrate1
			// 
			this.grdMigrate1.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None;
			this.grdMigrate1.AllowDrop = true;
			this.grdMigrate1.AllowEditing = false;
			this.grdMigrate1.AllowFreezing = C1.Win.C1FlexGrid.AllowFreezingEnum.None;
			this.grdMigrate1.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.None;
			this.grdMigrate1.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.None;
			this.grdMigrate1.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.Columns;
			this.grdMigrate1.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;
			this.grdMigrate1.AutoResize = true;
			this.grdMigrate1.AutoSearch = C1.Win.C1FlexGrid.AutoSearchEnum.None;
			this.grdMigrate1.AutoSearchDelay = 2;
			this.grdMigrate1.BackColor = System.Drawing.Color.White;
			this.grdMigrate1.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle;
			this.grdMigrate1.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.None;
			this.grdMigrate1.Cols.Count = 10;
			this.grdMigrate1.Cols.Fixed = 1;
			this.grdMigrate1.Cols.Frozen = 0;
			this.grdMigrate1.Cols.MaxSize = 0;
			this.grdMigrate1.Cols.MinSize = 0;
			this.grdMigrate1.Cursor = System.Windows.Forms.Cursors.Default;
			this.grdMigrate1.DrawMode = C1.Win.C1FlexGrid.DrawModeEnum.Normal;
			this.grdMigrate1.Enabled = true;
			this.grdMigrate1.ExtendLastCol = false;
			this.grdMigrate1.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.Light;
			this.grdMigrate1.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 178);
			this.grdMigrate1.ForeColor = System.Drawing.SystemColors.WindowText;
			this.grdMigrate1.HighLight = C1.Win.C1FlexGrid.HighLightEnum.Always;
			this.grdMigrate1.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.None;
			this.grdMigrate1.Location = new System.Drawing.Point(8, 56);
			this.grdMigrate1.Name = "grdMigrate1";
			this.grdMigrate1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.grdMigrate1.Rows.Count = 1;
			this.grdMigrate1.Rows.Fixed = 0;
			this.grdMigrate1.Rows.Frozen = 0;
			this.grdMigrate1.Rows.MaxSize = 0;
			this.grdMigrate1.Rows.MinSize = 0;
			this.grdMigrate1.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.grdMigrate1.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Default;
			// this.grdMigrate1.ShowButtons = C1.Win.C1FlexGrid.ShowButtonsEnum.WithFocus;
			this.grdMigrate1.ShowSortPosition = C1.Win.C1FlexGrid.ShowSortPositionEnum.None;
			this.grdMigrate1.Size = new System.Drawing.Size(681, 25);
			this.grdMigrate1.Styles.Alternate.BackColor = System.Drawing.Color.White;
			this.grdMigrate1.Styles.EmptyArea.BackColor = System.Drawing.Color.FromArgb(202, 213, 223);
			this.grdMigrate1.Styles.Fixed.BackColor = System.Drawing.SystemColors.Control;
			this.grdMigrate1.Styles.Fixed.Border.Color = System.Drawing.Color.Silver;
			this.grdMigrate1.Styles.Fixed.Border.Direction = C1.Win.C1FlexGrid.BorderDirEnum.Horizontal;
			this.grdMigrate1.Styles.Fixed.Border.Style = C1.Win.C1FlexGrid.BorderStyleEnum.Flat;
			this.grdMigrate1.Styles.Fixed.ForeColor = System.Drawing.SystemColors.ControlText;
			this.grdMigrate1.Styles.Fixed.TextEffect = C1.Win.C1FlexGrid.TextEffectEnum.Flat;
			this.grdMigrate1.Styles.Frozen.BackColor = System.Drawing.Color.Black;
			this.grdMigrate1.Styles.Frozen.ForeColor = System.Drawing.Color.Black;
			this.grdMigrate1.Styles.Highlight.BackColor = System.Drawing.SystemColors.Highlight;
			this.grdMigrate1.Styles.Highlight.ForeColor = System.Drawing.SystemColors.HighlightText;
			this.grdMigrate1.Styles.Normal.Border.Color = System.Drawing.Color.FromArgb(64, 64, 64);
			this.grdMigrate1.Styles.Normal.Border.Direction = C1.Win.C1FlexGrid.BorderDirEnum.Both;
			this.grdMigrate1.Styles.Normal.Border.Style = C1.Win.C1FlexGrid.BorderStyleEnum.Raised;
			this.grdMigrate1.Styles.Normal.Border.Width = 1;
			this.grdMigrate1.Styles.Normal.ImageAlign = C1.Win.C1FlexGrid.ImageAlignEnum.Stretch;
			this.grdMigrate1.Styles.Normal.TextEffect = C1.Win.C1FlexGrid.TextEffectEnum.Flat;
			this.grdMigrate1.Styles.Normal.Trimming = System.Drawing.StringTrimming.None;
			this.grdMigrate1.Styles.Normal.WordWrap = false;
			this.grdMigrate1.Styles[C1.Win.C1FlexGrid.CellStyleEnum.EmptyArea].Border.Color = System.Drawing.SystemColors.WindowFrame;
			this.grdMigrate1.SubtotalPosition = C1.Win.C1FlexGrid.SubtotalPositionEnum.AboveData;
			this.grdMigrate1.TabIndex = 6;
			this.grdMigrate1.Tree.Column = 0;
			this.grdMigrate1.Tree.LineColor = System.Drawing.SystemColors.ControlDark;
			this.grdMigrate1.Tree.Style = C1.Win.C1FlexGrid.TreeStyleFlags.None;
			this.grdMigrate1.AfterEdit += new C1.Win.C1FlexGrid.RowColEventHandler(this.grdMigrate1_AfterEdit);
			this.grdMigrate1.AfterRowColChange += new C1.Win.C1FlexGrid.RangeEventHandler(this.grdMigrate1_AfterRowColChange);
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
			this.grdMigrate2.Location = new System.Drawing.Point(8, 80);
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
			this.grdMigrate2.Size = new System.Drawing.Size(681, 377);
			this.grdMigrate2.Styles.Alternate.BackColor = System.Drawing.SystemColors.Window;
			this.grdMigrate2.Styles.EmptyArea.BackColor = System.Drawing.Color.FromArgb(202, 213, 223);
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
			this.grdMigrate2.TabIndex = 7;
			this.grdMigrate2.Tree.Column = 0;
			this.grdMigrate2.Tree.LineColor = System.Drawing.SystemColors.ControlDark;
			this.grdMigrate2.Tree.Style = C1.Win.C1FlexGrid.TreeStyleFlags.None;
			this.grdMigrate2.AfterResizeColumn += new C1.Win.C1FlexGrid.RowColEventHandler(this.grdMigrate2_AfterResizeColumn);
			this.grdMigrate2.AfterRowColChange += new C1.Win.C1FlexGrid.RangeEventHandler(this.grdMigrate2_AfterRowColChange);
			this.grdMigrate2.AfterScroll += new C1.Win.C1FlexGrid.RangeEventHandler(this.grdMigrate2_AfterScroll);
			// 
			// Line2
			// 
			this.Line2.AllowDrop = true;
			this.Line2.BackColor = System.Drawing.Color.Gray;
			this.Line2.Enabled = false;
			this.Line2.Location = new System.Drawing.Point(0, 48);
			this.Line2.Name = "Line2";
			this.Line2.Size = new System.Drawing.Size(696, 1);
			this.Line2.Visible = true;
			// 
			// Line1
			// 
			this.Line1.AllowDrop = true;
			this.Line1.BackColor = System.Drawing.Color.White;
			this.Line1.Enabled = false;
			this.Line1.Location = new System.Drawing.Point(0, 48);
			this.Line1.Name = "Line1";
			this.Line1.Size = new System.Drawing.Size(680, 1);
			this.Line1.Visible = true;
			// 
			// Shape1
			// 
			this.Shape1.AllowDrop = true;
			this.Shape1.BackColor = System.Drawing.SystemColors.Window;
			// = 0;
			this.Shape1.BorderStyle = 1;
			this.Shape1.Enabled = false;
			this.Shape1.FillColor = System.Drawing.Color.Black;
			this.Shape1.FillStyle = 1;
			this.Shape1.Location = new System.Drawing.Point(3, 53);
			this.Shape1.Name = "Shape1";
			this.Shape1.Size = new System.Drawing.Size(690, 409);
			this.Shape1.Visible = true;
			// 
			// frmICSPriceListUpdate
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.ClientSize = new System.Drawing.Size(794, 578);
			this.Controls.Add(this.frameMain);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			//this.Icon = (System.Drawing.Icon) resources.GetObject("frmICSPriceListUpdate.Icon");
			this.Location = new System.Drawing.Point(37, 69);
			this.MaximizeBox = true;
			this.MinimizeBox = true;
			this.Name = "frmICSPriceListUpdate";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Price List Update";
			// this.Activated += new System.EventHandler(this.frmICSPriceListUpdate_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
			//this.Resize += new System.EventHandler(this.Form_Resize);
			this.frameMain.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		// 
		#endregion
	}
}//ENDSHERE
