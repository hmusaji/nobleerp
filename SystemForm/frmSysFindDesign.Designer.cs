
namespace Xtreme
{
	partial class frmSysFindDesign
	{

		#region "Upgrade Support "
		private static frmSysFindDesign m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmSysFindDesign DefInstance
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
		public static frmSysFindDesign CreateInstance()
		{
			frmSysFindDesign theInstance = new frmSysFindDesign();
			
			return theInstance;
		}
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "_btnReportOptions_5", "txtCriteriaBox", "_chkCommonSettings_0", "_chkCommonSettings_1", "lblFindResult", "lblRecordsCriteria", "grdRecordsCriteria", "grdFindResult", "lblTips1", "tcbSystemForm", "mnuColors", "fraOuterShadow", "btnReportOptions", "chkCommonSettings", "commandButtonHelper1"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		private System.Windows.Forms.Button _btnReportOptions_5;
		public System.Windows.Forms.TextBox txtCriteriaBox;
		private System.Windows.Forms.CheckBox _chkCommonSettings_0;
		private System.Windows.Forms.CheckBox _chkCommonSettings_1;
		public System.Windows.Forms.Label lblFindResult;
		public System.Windows.Forms.Label lblRecordsCriteria;
		public C1.Win.C1FlexGrid.C1FlexGrid grdRecordsCriteria;
		public C1.Win.C1FlexGrid.C1FlexGrid grdFindResult;
		public System.Windows.Forms.Label lblTips1;
		public Syncfusion.Windows.Forms.Tools.CommandBarController tcbSystemForm;
		public Syncfusion.Windows.Forms.Tools.CommandBarController mnuColors;
		public ShapeHelper fraOuterShadow;
		public System.Windows.Forms.Button[] btnReportOptions = new System.Windows.Forms.Button[6];
		public System.Windows.Forms.CheckBox[] chkCommonSettings = new System.Windows.Forms.CheckBox[2];
		//public UpgradeHelpers.Gui.CommandButtonHelper commandButtonHelper1;
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSysFindDesign));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this._btnReportOptions_5 = new System.Windows.Forms.Button();
			this.txtCriteriaBox = new System.Windows.Forms.TextBox();
			this._chkCommonSettings_0 = new System.Windows.Forms.CheckBox();
			this._chkCommonSettings_1 = new System.Windows.Forms.CheckBox();
			this.lblFindResult = new System.Windows.Forms.Label();
			this.lblRecordsCriteria = new System.Windows.Forms.Label();
			this.grdRecordsCriteria = new C1.Win.C1FlexGrid.C1FlexGrid();
			this.grdFindResult = new C1.Win.C1FlexGrid.C1FlexGrid();
			this.lblTips1 = new System.Windows.Forms.Label();
			this.tcbSystemForm = new Syncfusion.Windows.Forms.Tools.CommandBarController();
			this.mnuColors = new Syncfusion.Windows.Forms.Tools.CommandBarController();
			this.fraOuterShadow = new ShapeHelper();
			// //((System.ComponentModel.ISupportInitialize) this.tcbSystemForm).BeginInit();
			// //((System.ComponentModel.ISupportInitialize) this.mnuColors).BeginInit();
			this.SuspendLayout();
			//this.commandButtonHelper1 = new UpgradeHelpers.Gui.CommandButtonHelper(this.components);
			// 
			// _btnReportOptions_5
			// 
			this._btnReportOptions_5.AllowDrop = true;
			this._btnReportOptions_5.BackColor = System.Drawing.SystemColors.Control;
			this._btnReportOptions_5.ForeColor = System.Drawing.SystemColors.ControlText;
			//this._btnReportOptions_5.Image = (System.Drawing.Image) resources.GetObject("_btnReportOptions_5.Image");
			this._btnReportOptions_5.Location = new System.Drawing.Point(508, 342);
			this._btnReportOptions_5.Name = "_btnReportOptions_5";
			this._btnReportOptions_5.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._btnReportOptions_5.Size = new System.Drawing.Size(55, 33);
			this._btnReportOptions_5.TabIndex = 8;
			this._btnReportOptions_5.Text = "&Close";
			this._btnReportOptions_5.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this._btnReportOptions_5.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this._btnReportOptions_5.UseVisualStyleBackColor = false;
			this._btnReportOptions_5.Visible = false;
			// this._btnReportOptions_5.Click += new System.EventHandler(this.btnReportOptions_Click);
			// 
			// txtCriteriaBox
			// 
			this.txtCriteriaBox.AcceptsReturn = true;
			this.txtCriteriaBox.AllowDrop = true;
			this.txtCriteriaBox.BackColor = System.Drawing.Color.White;
			this.txtCriteriaBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtCriteriaBox.CausesValidation = false;
			this.txtCriteriaBox.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtCriteriaBox.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtCriteriaBox.Location = new System.Drawing.Point(314, 102);
			this.txtCriteriaBox.MaxLength = 0;
			this.txtCriteriaBox.Name = "txtCriteriaBox";
			this.txtCriteriaBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtCriteriaBox.Size = new System.Drawing.Size(125, 17);
			this.txtCriteriaBox.TabIndex = 2;
			// this.this.txtCriteriaBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCriteriaBox_KeyDown);
			// this.this.txtCriteriaBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCriteriaBox_KeyPress);
			this.txtCriteriaBox.TextChanged += new System.EventHandler(this.txtCriteriaBox_TextChanged);
			// 
			// _chkCommonSettings_0
			// 
			this._chkCommonSettings_0.AllowDrop = true;
			this._chkCommonSettings_0.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkCommonSettings_0.BackColor = System.Drawing.SystemColors.ControlLightLight;
			this._chkCommonSettings_0.CausesValidation = true;
			this._chkCommonSettings_0.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommonSettings_0.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkCommonSettings_0.Enabled = true;
			this._chkCommonSettings_0.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkCommonSettings_0.Location = new System.Drawing.Point(416, 66);
			this._chkCommonSettings_0.Name = "_chkCommonSettings_0";
			this._chkCommonSettings_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkCommonSettings_0.Size = new System.Drawing.Size(114, 13);
			this._chkCommonSettings_0.TabIndex = 1;
			this._chkCommonSettings_0.TabStop = false;
			this._chkCommonSettings_0.Text = "S&earch Substring";
			this._chkCommonSettings_0.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommonSettings_0.Visible = false;
			this._chkCommonSettings_0.CheckStateChanged += new System.EventHandler(this.chkCommonSettings_CheckStateChanged);
			// 
			// _chkCommonSettings_1
			// 
			this._chkCommonSettings_1.AllowDrop = true;
			this._chkCommonSettings_1.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkCommonSettings_1.BackColor = System.Drawing.SystemColors.ControlLightLight;
			this._chkCommonSettings_1.CausesValidation = true;
			this._chkCommonSettings_1.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommonSettings_1.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkCommonSettings_1.Enabled = true;
			this._chkCommonSettings_1.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkCommonSettings_1.Location = new System.Drawing.Point(242, 70);
			this._chkCommonSettings_1.Name = "_chkCommonSettings_1";
			this._chkCommonSettings_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkCommonSettings_1.Size = new System.Drawing.Size(135, 13);
			this._chkCommonSettings_1.TabIndex = 0;
			this._chkCommonSettings_1.TabStop = false;
			this._chkCommonSettings_1.Text = "Show &All Records";
			this._chkCommonSettings_1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkCommonSettings_1.Visible = true;
			this._chkCommonSettings_1.CheckStateChanged += new System.EventHandler(this.chkCommonSettings_CheckStateChanged);
			// 
			// lblFindResult
			// 
			this.lblFindResult.AllowDrop = true;
			this.lblFindResult.Location = new System.Drawing.Point(30, 182);
			this.lblFindResult.Name = "lblFindResult";
			this.lblFindResult.Size = new System.Drawing.Size(60, 13);
			this.lblFindResult.TabIndex = 3;
			this.lblFindResult.Tag = " results";
			this.lblFindResult.Visible = false;
			// 
			// lblRecordsCriteria
			// 
			this.lblRecordsCriteria.AllowDrop = true;
			this.lblRecordsCriteria.Location = new System.Drawing.Point(36, 68);
			this.lblRecordsCriteria.Name = "lblRecordsCriteria";
			this.lblRecordsCriteria.Size = new System.Drawing.Size(79, 13);
			this.lblRecordsCriteria.TabIndex = 4;
			this.lblRecordsCriteria.Visible = false;
			// 
			// grdRecordsCriteria
			// 
			this.grdRecordsCriteria.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None;
			this.grdRecordsCriteria.AllowDrop = true;
			this.grdRecordsCriteria.AllowEditing = false;
			this.grdRecordsCriteria.AllowFreezing = C1.Win.C1FlexGrid.AllowFreezingEnum.None;
			this.grdRecordsCriteria.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.None;
			this.grdRecordsCriteria.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.None;
			this.grdRecordsCriteria.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.Columns;
			this.grdRecordsCriteria.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;
			this.grdRecordsCriteria.AutoResize = true;
			this.grdRecordsCriteria.AutoSearch = C1.Win.C1FlexGrid.AutoSearchEnum.None;
			this.grdRecordsCriteria.AutoSearchDelay = 2;
			this.grdRecordsCriteria.BackColor = System.Drawing.SystemColors.Window;
			this.grdRecordsCriteria.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.Fixed3D;
			this.grdRecordsCriteria.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.Fixed3D;
			this.grdRecordsCriteria.Cols.Count = 10;
			this.grdRecordsCriteria.Cols.Fixed = 1;
			this.grdRecordsCriteria.Cols.Frozen = 0;
			this.grdRecordsCriteria.Cols.MaxSize = 0;
			this.grdRecordsCriteria.Cols.MinSize = 0;
			this.grdRecordsCriteria.Cursor = System.Windows.Forms.Cursors.Default;
			this.grdRecordsCriteria.DrawMode = C1.Win.C1FlexGrid.DrawModeEnum.Normal;
			this.grdRecordsCriteria.Enabled = true;
			this.grdRecordsCriteria.ExtendLastCol = false;
			this.grdRecordsCriteria.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.Light;
			this.grdRecordsCriteria.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 178);
			this.grdRecordsCriteria.ForeColor = System.Drawing.SystemColors.WindowText;
			this.grdRecordsCriteria.HighLight = C1.Win.C1FlexGrid.HighLightEnum.Always;
			this.grdRecordsCriteria.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.None;
			this.grdRecordsCriteria.Location = new System.Drawing.Point(34, 104);
			this.grdRecordsCriteria.Name = "grdRecordsCriteria";
			this.grdRecordsCriteria.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.grdRecordsCriteria.Rows.Count = 50;
			this.grdRecordsCriteria.Rows.Fixed = 1;
			this.grdRecordsCriteria.Rows.Frozen = 0;
			this.grdRecordsCriteria.Rows.MaxSize = 0;
			this.grdRecordsCriteria.Rows.MinSize = 0;
			this.grdRecordsCriteria.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.grdRecordsCriteria.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Default;
			// this.grdRecordsCriteria.ShowButtons = C1.Win.C1FlexGrid.ShowButtonsEnum.WithFocus;
			this.grdRecordsCriteria.ShowSortPosition = C1.Win.C1FlexGrid.ShowSortPositionEnum.None;
			this.grdRecordsCriteria.Size = new System.Drawing.Size(245, 29);
			this.grdRecordsCriteria.Styles.Alternate.BackColor = System.Drawing.SystemColors.Window;
			this.grdRecordsCriteria.Styles.EmptyArea.BackColor = System.Drawing.SystemColors.AppWorkspace;
			this.grdRecordsCriteria.Styles.Fixed.BackColor = System.Drawing.SystemColors.Control;
			this.grdRecordsCriteria.Styles.Fixed.Border.Color = System.Drawing.SystemColors.ControlDark;
			this.grdRecordsCriteria.Styles.Fixed.Border.Direction = C1.Win.C1FlexGrid.BorderDirEnum.Both;
			this.grdRecordsCriteria.Styles.Fixed.Border.Style = C1.Win.C1FlexGrid.BorderStyleEnum.Inset;
			this.grdRecordsCriteria.Styles.Fixed.ForeColor = System.Drawing.SystemColors.ControlText;
			this.grdRecordsCriteria.Styles.Fixed.TextEffect = C1.Win.C1FlexGrid.TextEffectEnum.Flat;
			this.grdRecordsCriteria.Styles.Frozen.BackColor = System.Drawing.Color.Black;
			this.grdRecordsCriteria.Styles.Frozen.ForeColor = System.Drawing.Color.Black;
			this.grdRecordsCriteria.Styles.Highlight.BackColor = System.Drawing.SystemColors.Highlight;
			this.grdRecordsCriteria.Styles.Highlight.ForeColor = System.Drawing.SystemColors.HighlightText;
			this.grdRecordsCriteria.Styles.Normal.Border.Color = System.Drawing.SystemColors.Control;
			this.grdRecordsCriteria.Styles.Normal.Border.Direction = C1.Win.C1FlexGrid.BorderDirEnum.Both;
			this.grdRecordsCriteria.Styles.Normal.Border.Style = C1.Win.C1FlexGrid.BorderStyleEnum.Flat;
			this.grdRecordsCriteria.Styles.Normal.Border.Width = 1;
			this.grdRecordsCriteria.Styles.Normal.ImageAlign = C1.Win.C1FlexGrid.ImageAlignEnum.Stretch;
			this.grdRecordsCriteria.Styles.Normal.TextEffect = C1.Win.C1FlexGrid.TextEffectEnum.Flat;
			this.grdRecordsCriteria.Styles.Normal.Trimming = System.Drawing.StringTrimming.None;
			this.grdRecordsCriteria.Styles.Normal.WordWrap = false;
			this.grdRecordsCriteria.Styles[C1.Win.C1FlexGrid.CellStyleEnum.EmptyArea].Border.Color = System.Drawing.SystemColors.WindowFrame;
			this.grdRecordsCriteria.SubtotalPosition = C1.Win.C1FlexGrid.SubtotalPositionEnum.AboveData;
			this.grdRecordsCriteria.TabIndex = 5;
			this.grdRecordsCriteria.Tree.Column = 0;
			this.grdRecordsCriteria.Tree.LineColor = System.Drawing.SystemColors.ControlDark;
			this.grdRecordsCriteria.Tree.Style = C1.Win.C1FlexGrid.TreeStyleFlags.None;
			this.grdRecordsCriteria.AfterResizeColumn += new C1.Win.C1FlexGrid.RowColEventHandler(this.grdRecordsCriteria_AfterResizeColumn);
			this.grdRecordsCriteria.AfterScroll += new C1.Win.C1FlexGrid.RangeEventHandler(this.grdRecordsCriteria_AfterScroll);
			this.grdRecordsCriteria.BeforeRowColChange += new C1.Win.C1FlexGrid.RangeEventHandler(this.grdRecordsCriteria_BeforeRowColChange);
			// this.grdRecordsCriteria.Enter += new System.EventHandler(this.grdRecordsCriteria_Enter);
			this.grdRecordsCriteria.RowColChange += new System.EventHandler(this.grdRecordsCriteria_RowColChange);
			// 
			// grdFindResult
			// 
			this.grdFindResult.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None;
			this.grdFindResult.AllowDrop = true;
			this.grdFindResult.AllowEditing = false;
			this.grdFindResult.AllowFreezing = C1.Win.C1FlexGrid.AllowFreezingEnum.None;
			this.grdFindResult.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.None;
			this.grdFindResult.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.None;
			this.grdFindResult.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.Columns;
			this.grdFindResult.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;
			this.grdFindResult.AutoResize = true;
			this.grdFindResult.AutoSearch = C1.Win.C1FlexGrid.AutoSearchEnum.None;
			this.grdFindResult.AutoSearchDelay = 2;
			this.grdFindResult.BackColor = System.Drawing.SystemColors.Window;
			this.grdFindResult.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.Fixed3D;
			this.grdFindResult.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.Fixed3D;
			this.grdFindResult.Cols.Count = 3;
			this.grdFindResult.Cols.Fixed = 1;
			this.grdFindResult.Cols.Frozen = 0;
			this.grdFindResult.Cols.MaxSize = 0;
			this.grdFindResult.Cols.MinSize = 0;
			this.grdFindResult.Cursor = System.Windows.Forms.Cursors.Default;
			this.grdFindResult.DrawMode = C1.Win.C1FlexGrid.DrawModeEnum.Normal;
			this.grdFindResult.Enabled = true;
			this.grdFindResult.ExtendLastCol = false;
			this.grdFindResult.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.Light;
			this.grdFindResult.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.grdFindResult.ForeColor = System.Drawing.SystemColors.WindowText;
			this.grdFindResult.HighLight = C1.Win.C1FlexGrid.HighLightEnum.Always;
			this.grdFindResult.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.None;
			this.grdFindResult.Location = new System.Drawing.Point(26, 214);
			this.grdFindResult.Name = "grdFindResult";
			this.grdFindResult.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.grdFindResult.Rows.Count = 7;
			this.grdFindResult.Rows.Fixed = 1;
			this.grdFindResult.Rows.Frozen = 0;
			this.grdFindResult.Rows.MaxSize = 0;
			this.grdFindResult.Rows.MinSize = 0;
			this.grdFindResult.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.grdFindResult.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Default;
			// this.grdFindResult.ShowButtons = C1.Win.C1FlexGrid.ShowButtonsEnum.WithFocus;
			this.grdFindResult.ShowSortPosition = C1.Win.C1FlexGrid.ShowSortPositionEnum.None;
			this.grdFindResult.Size = new System.Drawing.Size(369, 103);
			this.grdFindResult.Styles.Alternate.BackColor = System.Drawing.SystemColors.Window;
			this.grdFindResult.Styles.EmptyArea.BackColor = System.Drawing.SystemColors.AppWorkspace;
			this.grdFindResult.Styles.Fixed.BackColor = System.Drawing.SystemColors.Control;
			this.grdFindResult.Styles.Fixed.Border.Color = System.Drawing.SystemColors.ControlDark;
			this.grdFindResult.Styles.Fixed.Border.Direction = C1.Win.C1FlexGrid.BorderDirEnum.Both;
			this.grdFindResult.Styles.Fixed.Border.Style = C1.Win.C1FlexGrid.BorderStyleEnum.Inset;
			this.grdFindResult.Styles.Fixed.ForeColor = System.Drawing.SystemColors.ControlText;
			this.grdFindResult.Styles.Fixed.TextEffect = C1.Win.C1FlexGrid.TextEffectEnum.Flat;
			this.grdFindResult.Styles.Frozen.BackColor = System.Drawing.Color.Black;
			this.grdFindResult.Styles.Frozen.ForeColor = System.Drawing.Color.Black;
			this.grdFindResult.Styles.Highlight.BackColor = System.Drawing.SystemColors.Highlight;
			this.grdFindResult.Styles.Highlight.ForeColor = System.Drawing.SystemColors.HighlightText;
			this.grdFindResult.Styles.Normal.Border.Color = System.Drawing.SystemColors.Control;
			this.grdFindResult.Styles.Normal.Border.Direction = C1.Win.C1FlexGrid.BorderDirEnum.Both;
			this.grdFindResult.Styles.Normal.Border.Style = C1.Win.C1FlexGrid.BorderStyleEnum.Flat;
			this.grdFindResult.Styles.Normal.Border.Width = 1;
			this.grdFindResult.Styles.Normal.ImageAlign = C1.Win.C1FlexGrid.ImageAlignEnum.Stretch;
			this.grdFindResult.Styles.Normal.TextEffect = C1.Win.C1FlexGrid.TextEffectEnum.Flat;
			this.grdFindResult.Styles.Normal.Trimming = System.Drawing.StringTrimming.None;
			this.grdFindResult.Styles.Normal.WordWrap = false;
			this.grdFindResult.Styles[C1.Win.C1FlexGrid.CellStyleEnum.EmptyArea].Border.Color = System.Drawing.SystemColors.WindowFrame;
			this.grdFindResult.SubtotalPosition = C1.Win.C1FlexGrid.SubtotalPositionEnum.AboveData;
			this.grdFindResult.TabIndex = 6;
			this.grdFindResult.Tree.Column = 0;
			this.grdFindResult.Tree.LineColor = System.Drawing.SystemColors.ControlDark;
			this.grdFindResult.Tree.Style = C1.Win.C1FlexGrid.TreeStyleFlags.None;
			this.grdFindResult.AfterResizeColumn += new C1.Win.C1FlexGrid.RowColEventHandler(this.grdFindResult_AfterResizeColumn);
			this.grdFindResult.AfterScroll += new C1.Win.C1FlexGrid.RangeEventHandler(this.grdFindResult_AfterScroll);
			this.grdFindResult.AfterSort += new C1.Win.C1FlexGrid.SortColEventHandler(this.grdFindResult_AfterSort);
			this.grdFindResult.BeforeResizeColumn += new C1.Win.C1FlexGrid.RowColEventHandler(this.grdFindResult_BeforeResizeColumn);
			this.grdFindResult.DoubleClick += new System.EventHandler(this.grdFindResult_DoubleClick);
			// this.this.grdFindResult.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grdFindResult_KeyDown);
			// 
			// lblTips1
			// 
			this.lblTips1.AllowDrop = true;
			this.lblTips1.Location = new System.Drawing.Point(196, 148);
			this.lblTips1.Name = "lblTips1";
			this.lblTips1.Size = new System.Drawing.Size(254, 13);
			this.lblTips1.TabIndex = 7;
			this.lblTips1.Visible = false;
			// 
			// tcbSystemForm
			// 
			this.tcbSystemForm.AllowDrop = true;
			this.tcbSystemForm.Location = new System.Drawing.Point(0, 0);
			this.tcbSystemForm.Name = "tcbSystemForm";
			//
			// 
			// mnuColors
			// 
			this.mnuColors.AllowDrop = true;
			this.mnuColors.Location = new System.Drawing.Point(448, 264);
			this.mnuColors.Name = "mnuColors";
			//
			// 
			// fraOuterShadow
			// 
			this.fraOuterShadow.AllowDrop = true;
			this.fraOuterShadow.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			// = 1;
			this.fraOuterShadow.BorderColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.fraOuterShadow.BorderStyle = 1;
			this.fraOuterShadow.Enabled = false;
			this.fraOuterShadow.FillColor = System.Drawing.Color.Black;
			this.fraOuterShadow.FillStyle = 1;
			this.fraOuterShadow.Location = new System.Drawing.Point(6, 26);
			this.fraOuterShadow.Name = "fraOuterShadow";
			this.fraOuterShadow.Size = new System.Drawing.Size(567, 317);
			this.fraOuterShadow.Visible = true;
			// 
			// frmSysFindDesign
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.ClientSize = new System.Drawing.Size(571, 368);
			this.Controls.Add(this._btnReportOptions_5);
			this.Controls.Add(this.txtCriteriaBox);
			this.Controls.Add(this._chkCommonSettings_0);
			this.Controls.Add(this._chkCommonSettings_1);
			this.Controls.Add(this.lblFindResult);
			this.Controls.Add(this.lblRecordsCriteria);
			this.Controls.Add(this.grdRecordsCriteria);
			this.Controls.Add(this.grdFindResult);
			this.Controls.Add(this.lblTips1);
			this.Controls.Add(this.tcbSystemForm);
			this.Controls.Add(this.mnuColors);
			this.Controls.Add(this.fraOuterShadow);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
			//this.Icon = (System.Drawing.Icon) resources.GetObject("frmSysFindDesign.Icon");
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(243, 161);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmSysFindDesign";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.ShowInTaskbar = false;
			this.Tag = "Find Record";
			this.Text = "Find Record";
			this.commandButtonHelper1.SetStyle(this._btnReportOptions_5, 1);
			// this.Activated += new System.EventHandler(this.Form_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
			// this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
			//this.Resize += new System.EventHandler(this.Form_Resize);
			//((System.ComponentModel.ISupportInitialize) this.tcbSystemForm).EndInit();
			//((System.ComponentModel.ISupportInitialize) this.mnuColors).EndInit();
			this.ResumeLayout(false);
		}
		// 
		void InitializechkCommonSettings()
		{
			this.chkCommonSettings = new System.Windows.Forms.CheckBox[2];
			this.chkCommonSettings[0] = _chkCommonSettings_0;
			this.chkCommonSettings[1] = _chkCommonSettings_1;
		}
		void InitializebtnReportOptions()
		{
			this.btnReportOptions = new System.Windows.Forms.Button[6];
			this.btnReportOptions[5] = _btnReportOptions_5;
		}
		#endregion
	}
}//ENDSHERE
