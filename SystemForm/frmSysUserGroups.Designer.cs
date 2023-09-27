
using Xtreme.UnResolved;

namespace Xtreme
{
	partial class frmSysUserGroups
	{

		#region "Upgrade Support "
		private static frmSysUserGroups m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmSysUserGroups DefInstance
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
		public static frmSysUserGroups CreateInstance()
		{
			frmSysUserGroups theInstance = new frmSysUserGroups();
			
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
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "lblSystemComponents", "_grdUserGroups_0", "_grdUserGroups_1", "_grdUserGroups_2", "_grdUserGroups_3", "_grdUserGroups_4", "tabUserGroups", "txtGroupName", "lblGroupName", "lblBasicGroupName", "txtBasicGroupName", "Line1", "cntOuterFrame", "grdUserGroups"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public System.Windows.Forms.Label lblSystemComponents;
		private C1.Win.C1FlexGrid.C1FlexGrid _grdUserGroups_0;
		private C1.Win.C1FlexGrid.C1FlexGrid _grdUserGroups_1;
		private C1.Win.C1FlexGrid.C1FlexGrid _grdUserGroups_2;
		private C1.Win.C1FlexGrid.C1FlexGrid _grdUserGroups_3;
		private C1.Win.C1FlexGrid.C1FlexGrid _grdUserGroups_4;
		public Syncfusion.Windows.Forms.Tools.TabControlAdv tabUserGroups;
		public System.Windows.Forms.TextBox txtGroupName;
		public System.Windows.Forms.Label lblGroupName;
		public System.Windows.Forms.Label lblBasicGroupName;
		public System.Windows.Forms.TextBox txtBasicGroupName;
		public System.Windows.Forms.Label Line1;
		public AxC1Elastic cntOuterFrame;
		public C1.Win.C1FlexGrid.C1FlexGrid[] grdUserGroups = new C1.Win.C1FlexGrid.C1FlexGrid[5];
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSysUserGroups));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this.cntOuterFrame = new AxC1Elastic();
			this.lblSystemComponents = new System.Windows.Forms.Label();
			this.tabUserGroups = new Syncfusion.Windows.Forms.Tools.TabControlAdv();
			this._grdUserGroups_0 = new C1.Win.C1FlexGrid.C1FlexGrid();
			this._grdUserGroups_1 = new C1.Win.C1FlexGrid.C1FlexGrid();
			this._grdUserGroups_2 = new C1.Win.C1FlexGrid.C1FlexGrid();
			this._grdUserGroups_3 = new C1.Win.C1FlexGrid.C1FlexGrid();
			this._grdUserGroups_4 = new C1.Win.C1FlexGrid.C1FlexGrid();
			this.txtGroupName = new System.Windows.Forms.TextBox();
			this.lblGroupName = new System.Windows.Forms.Label();
			this.lblBasicGroupName = new System.Windows.Forms.Label();
			this.txtBasicGroupName = new System.Windows.Forms.TextBox();
			this.Line1 = new System.Windows.Forms.Label();
			// //((System.ComponentModel.ISupportInitialize) this.tabUserGroups).BeginInit();
			// //((System.ComponentModel.ISupportInitialize) this.cntOuterFrame).BeginInit();
			//this.cntOuterFrame.SuspendLayout();
			//this.tabUserGroups.SuspendLayout();
			this.SuspendLayout();
			// 
			// cntOuterFrame
			// 
			//this.cntOuterFrame.Align = C1SizerLib.AlignSettings.asNone;
			//this.cntOuterFrame.AllowDrop = true;
			this.cntOuterFrame.Controls.Add(this.lblSystemComponents);
			this.cntOuterFrame.Controls.Add(this.tabUserGroups);
			this.cntOuterFrame.Controls.Add(this.txtGroupName);
			this.cntOuterFrame.Controls.Add(this.lblGroupName);
			this.cntOuterFrame.Controls.Add(this.lblBasicGroupName);
			this.cntOuterFrame.Controls.Add(this.txtBasicGroupName);
			this.cntOuterFrame.Controls.Add(this.Line1);
			this.cntOuterFrame.Location = new System.Drawing.Point(6, 6);
			this.cntOuterFrame.Name = "cntOuterFrame";
			//
			this.cntOuterFrame.Size = new System.Drawing.Size(735, 493);
			this.cntOuterFrame.TabIndex = 7;
			this.cntOuterFrame.TabStop = false;
			// 
			// lblSystemComponents
			// 
			//this.lblSystemComponents.AllowDrop = true;
			this.lblSystemComponents.BackColor = System.Drawing.SystemColors.Window;
			this.lblSystemComponents.Text = " Rights on System Components ";
			this.lblSystemComponents.Location = new System.Drawing.Point(12, 68);
			this.lblSystemComponents.Name = "lblSystemComponents";
			this.lblSystemComponents.Size = new System.Drawing.Size(179, 13);
			this.lblSystemComponents.TabIndex = 8;
			// 
			// tabUserGroups
			// 
			//this.tabUserGroups.Align = C1SizerLib.AlignSettings.asNone;
			//this.tabUserGroups.AllowDrop = true;
			this.tabUserGroups.Controls.Add(this._grdUserGroups_0);
			this.tabUserGroups.Controls.Add(this._grdUserGroups_1);
			this.tabUserGroups.Controls.Add(this._grdUserGroups_2);
			this.tabUserGroups.Controls.Add(this._grdUserGroups_3);
			this.tabUserGroups.Controls.Add(this._grdUserGroups_4);
			this.tabUserGroups.Location = new System.Drawing.Point(5, 94);
			this.tabUserGroups.Name = "tabUserGroups";
			//
			this.tabUserGroups.Size = new System.Drawing.Size(725, 367);
			this.tabUserGroups.TabIndex = 2;
			// 
			// _grdUserGroups_0
			// 
			this._grdUserGroups_0.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None;
			//this._grdUserGroups_0.AllowDrop = true;
			this._grdUserGroups_0.AllowEditing = false;
			this._grdUserGroups_0.AllowFreezing = C1.Win.C1FlexGrid.AllowFreezingEnum.None;
			this._grdUserGroups_0.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.None;
			this._grdUserGroups_0.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.None;
			this._grdUserGroups_0.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.Columns;
			this._grdUserGroups_0.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;
			this._grdUserGroups_0.AutoResize = true;
			this._grdUserGroups_0.AutoSearch = C1.Win.C1FlexGrid.AutoSearchEnum.None;
			this._grdUserGroups_0.AutoSearchDelay = 2;
			this._grdUserGroups_0.BackColor = System.Drawing.SystemColors.Window;
			//this._grdUserGroups_0.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.Fixed3D;
			//this._grdUserGroups_0.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.Fixed3D;
			this._grdUserGroups_0.Cols.Count = 6;
			this._grdUserGroups_0.Cols.Fixed = 1;
			this._grdUserGroups_0.Cols.Frozen = 0;
			this._grdUserGroups_0.Cols.MaxSize = 0;
			this._grdUserGroups_0.Cols.MinSize = 0;
			this._grdUserGroups_0.Cursor = System.Windows.Forms.Cursors.Default;
			this._grdUserGroups_0.DrawMode = C1.Win.C1FlexGrid.DrawModeEnum.Normal;
			this._grdUserGroups_0.Enabled = true;
			this._grdUserGroups_0.ExtendLastCol = false;
			this._grdUserGroups_0.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.Light;
			this._grdUserGroups_0.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 178);
			this._grdUserGroups_0.ForeColor = System.Drawing.SystemColors.WindowText;
			this._grdUserGroups_0.HighLight = C1.Win.C1FlexGrid.HighLightEnum.Always;
			this._grdUserGroups_0.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.None;
			this._grdUserGroups_0.Location = new System.Drawing.Point(1, 23);
			this._grdUserGroups_0.Name = "_grdUserGroups_0";
			this._grdUserGroups_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._grdUserGroups_0.Rows.Count = 50;
			this._grdUserGroups_0.Rows.Fixed = 1;
			this._grdUserGroups_0.Rows.Frozen = 0;
			this._grdUserGroups_0.Rows.MaxSize = 0;
			this._grdUserGroups_0.Rows.MinSize = 0;
			this._grdUserGroups_0.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this._grdUserGroups_0.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Default;
			// this._grdUserGroups_0.ShowButtons = C1.Win.C1FlexGrid.ShowButtonsEnum.WithFocus;
			this._grdUserGroups_0.ShowSortPosition = C1.Win.C1FlexGrid.ShowSortPositionEnum.None;
			this._grdUserGroups_0.Size = new System.Drawing.Size(723, 343);
			this._grdUserGroups_0.Styles.Alternate.BackColor = System.Drawing.SystemColors.Window;
			this._grdUserGroups_0.Styles.EmptyArea.BackColor = System.Drawing.SystemColors.AppWorkspace;
			this._grdUserGroups_0.Styles.Fixed.BackColor = System.Drawing.SystemColors.Control;
			this._grdUserGroups_0.Styles.Fixed.Border.Color = System.Drawing.SystemColors.ControlDark;
			this._grdUserGroups_0.Styles.Fixed.Border.Direction = C1.Win.C1FlexGrid.BorderDirEnum.Both;
			this._grdUserGroups_0.Styles.Fixed.Border.Style = C1.Win.C1FlexGrid.BorderStyleEnum.Inset;
			this._grdUserGroups_0.Styles.Fixed.ForeColor = System.Drawing.SystemColors.ControlText;
			this._grdUserGroups_0.Styles.Fixed.TextEffect = C1.Win.C1FlexGrid.TextEffectEnum.Flat;
			this._grdUserGroups_0.Styles.Frozen.BackColor = System.Drawing.Color.Black;
			this._grdUserGroups_0.Styles.Frozen.ForeColor = System.Drawing.Color.Black;
			this._grdUserGroups_0.Styles.Highlight.BackColor = System.Drawing.SystemColors.Highlight;
			this._grdUserGroups_0.Styles.Highlight.ForeColor = System.Drawing.SystemColors.HighlightText;
			this._grdUserGroups_0.Styles.Normal.Border.Color = System.Drawing.SystemColors.Control;
			this._grdUserGroups_0.Styles.Normal.Border.Direction = C1.Win.C1FlexGrid.BorderDirEnum.Both;
			this._grdUserGroups_0.Styles.Normal.Border.Style = C1.Win.C1FlexGrid.BorderStyleEnum.Flat;
			this._grdUserGroups_0.Styles.Normal.Border.Width = 1;
			this._grdUserGroups_0.Styles.Normal.ImageAlign = C1.Win.C1FlexGrid.ImageAlignEnum.Stretch;
			this._grdUserGroups_0.Styles.Normal.TextEffect = C1.Win.C1FlexGrid.TextEffectEnum.Flat;
			this._grdUserGroups_0.Styles.Normal.Trimming = System.Drawing.StringTrimming.None;
			this._grdUserGroups_0.Styles.Normal.WordWrap = false;
			this._grdUserGroups_0.Styles[C1.Win.C1FlexGrid.CellStyleEnum.EmptyArea].Border.Color = System.Drawing.SystemColors.WindowFrame;
			this._grdUserGroups_0.SubtotalPosition = C1.Win.C1FlexGrid.SubtotalPositionEnum.AboveData;
			this._grdUserGroups_0.TabIndex = 3;
			this._grdUserGroups_0.Tree.Column = 0;
			this._grdUserGroups_0.Tree.LineColor = System.Drawing.SystemColors.ControlDark;
			this._grdUserGroups_0.Tree.Style = C1.Win.C1FlexGrid.TreeStyleFlags.None;
			////this._grdUserGroups_0.AfterEdit += new C1.Win.C1FlexGrid.RowColEventHandler(this.grdUserGroups_AfterEdit);
			////this._grdUserGroups_0.BeforeEdit += new C1.Win.C1FlexGrid.RowColEventHandler(this.grdUserGroups_BeforeEdit);
			////this._grdUserGroups_0.DoubleClick += new System.EventHandler(this.grdUserGroups_DoubleClick);
			////this._grdUserGroups_0.StartEdit += new C1.Win.C1FlexGrid.RowColEventHandler(this.grdUserGroups_StartEdit);
			// 
			// _grdUserGroups_1
			// 
			this._grdUserGroups_1.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None;
			//this._grdUserGroups_1.AllowDrop = true;
			this._grdUserGroups_1.AllowEditing = false;
			this._grdUserGroups_1.AllowFreezing = C1.Win.C1FlexGrid.AllowFreezingEnum.None;
			this._grdUserGroups_1.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.None;
			this._grdUserGroups_1.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.None;
			this._grdUserGroups_1.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.Columns;
			this._grdUserGroups_1.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;
			this._grdUserGroups_1.AutoResize = true;
			this._grdUserGroups_1.AutoSearch = C1.Win.C1FlexGrid.AutoSearchEnum.None;
			this._grdUserGroups_1.AutoSearchDelay = 2;
			this._grdUserGroups_1.BackColor = System.Drawing.SystemColors.Window;
			//this._grdUserGroups_1.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.Fixed3D;
			//this._grdUserGroups_1.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.Fixed3D;
			this._grdUserGroups_1.Cols.Count = 10;
			this._grdUserGroups_1.Cols.Fixed = 1;
			this._grdUserGroups_1.Cols.Frozen = 0;
			this._grdUserGroups_1.Cols.MaxSize = 0;
			this._grdUserGroups_1.Cols.MinSize = 0;
			this._grdUserGroups_1.Cursor = System.Windows.Forms.Cursors.Default;
			this._grdUserGroups_1.DrawMode = C1.Win.C1FlexGrid.DrawModeEnum.Normal;
			this._grdUserGroups_1.Enabled = true;
			this._grdUserGroups_1.ExtendLastCol = false;
			this._grdUserGroups_1.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.Light;
			this._grdUserGroups_1.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 178);
			this._grdUserGroups_1.ForeColor = System.Drawing.SystemColors.WindowText;
			this._grdUserGroups_1.HighLight = C1.Win.C1FlexGrid.HighLightEnum.Always;
			this._grdUserGroups_1.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.None;
			this._grdUserGroups_1.Location = new System.Drawing.Point(766, 23);
			this._grdUserGroups_1.Name = "_grdUserGroups_1";
			this._grdUserGroups_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._grdUserGroups_1.Rows.Count = 50;
			this._grdUserGroups_1.Rows.Fixed = 1;
			this._grdUserGroups_1.Rows.Frozen = 0;
			this._grdUserGroups_1.Rows.MaxSize = 0;
			this._grdUserGroups_1.Rows.MinSize = 0;
			this._grdUserGroups_1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this._grdUserGroups_1.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Default;
			// this._grdUserGroups_1.ShowButtons = C1.Win.C1FlexGrid.ShowButtonsEnum.WithFocus;
			this._grdUserGroups_1.ShowSortPosition = C1.Win.C1FlexGrid.ShowSortPositionEnum.None;
			this._grdUserGroups_1.Size = new System.Drawing.Size(723, 343);
			this._grdUserGroups_1.Styles.Alternate.BackColor = System.Drawing.SystemColors.Window;
			this._grdUserGroups_1.Styles.EmptyArea.BackColor = System.Drawing.SystemColors.AppWorkspace;
			this._grdUserGroups_1.Styles.Fixed.BackColor = System.Drawing.SystemColors.Control;
			this._grdUserGroups_1.Styles.Fixed.Border.Color = System.Drawing.SystemColors.ControlDark;
			this._grdUserGroups_1.Styles.Fixed.Border.Direction = C1.Win.C1FlexGrid.BorderDirEnum.Both;
			this._grdUserGroups_1.Styles.Fixed.Border.Style = C1.Win.C1FlexGrid.BorderStyleEnum.Inset;
			this._grdUserGroups_1.Styles.Fixed.ForeColor = System.Drawing.SystemColors.ControlText;
			this._grdUserGroups_1.Styles.Fixed.TextEffect = C1.Win.C1FlexGrid.TextEffectEnum.Flat;
			this._grdUserGroups_1.Styles.Frozen.BackColor = System.Drawing.Color.Black;
			this._grdUserGroups_1.Styles.Frozen.ForeColor = System.Drawing.Color.Black;
			this._grdUserGroups_1.Styles.Highlight.BackColor = System.Drawing.SystemColors.Highlight;
			this._grdUserGroups_1.Styles.Highlight.ForeColor = System.Drawing.SystemColors.HighlightText;
			this._grdUserGroups_1.Styles.Normal.Border.Color = System.Drawing.SystemColors.Control;
			this._grdUserGroups_1.Styles.Normal.Border.Direction = C1.Win.C1FlexGrid.BorderDirEnum.Both;
			this._grdUserGroups_1.Styles.Normal.Border.Style = C1.Win.C1FlexGrid.BorderStyleEnum.Flat;
			this._grdUserGroups_1.Styles.Normal.Border.Width = 1;
			this._grdUserGroups_1.Styles.Normal.ImageAlign = C1.Win.C1FlexGrid.ImageAlignEnum.Stretch;
			this._grdUserGroups_1.Styles.Normal.TextEffect = C1.Win.C1FlexGrid.TextEffectEnum.Flat;
			this._grdUserGroups_1.Styles.Normal.Trimming = System.Drawing.StringTrimming.None;
			this._grdUserGroups_1.Styles.Normal.WordWrap = false;
			this._grdUserGroups_1.Styles[C1.Win.C1FlexGrid.CellStyleEnum.EmptyArea].Border.Color = System.Drawing.SystemColors.WindowFrame;
			this._grdUserGroups_1.SubtotalPosition = C1.Win.C1FlexGrid.SubtotalPositionEnum.AboveData;
			this._grdUserGroups_1.TabIndex = 4;
			this._grdUserGroups_1.Tree.Column = 0;
			this._grdUserGroups_1.Tree.LineColor = System.Drawing.SystemColors.ControlDark;
			this._grdUserGroups_1.Tree.Style = C1.Win.C1FlexGrid.TreeStyleFlags.None;
			//this._grdUserGroups_1.AfterEdit += new C1.Win.C1FlexGrid.RowColEventHandler(this.grdUserGroups_AfterEdit);
			//this._grdUserGroups_1.BeforeEdit += new C1.Win.C1FlexGrid.RowColEventHandler(this.grdUserGroups_BeforeEdit);
			//this._grdUserGroups_1.DoubleClick += new System.EventHandler(this.grdUserGroups_DoubleClick);
			//this._grdUserGroups_1.StartEdit += new C1.Win.C1FlexGrid.RowColEventHandler(this.grdUserGroups_StartEdit);
			// 
			// _grdUserGroups_2
			// 
			this._grdUserGroups_2.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None;
			//this._grdUserGroups_2.AllowDrop = true;
			this._grdUserGroups_2.AllowEditing = false;
			this._grdUserGroups_2.AllowFreezing = C1.Win.C1FlexGrid.AllowFreezingEnum.None;
			this._grdUserGroups_2.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.None;
			this._grdUserGroups_2.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.None;
			this._grdUserGroups_2.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.Columns;
			this._grdUserGroups_2.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;
			this._grdUserGroups_2.AutoResize = true;
			this._grdUserGroups_2.AutoSearch = C1.Win.C1FlexGrid.AutoSearchEnum.None;
			this._grdUserGroups_2.AutoSearchDelay = 2;
			this._grdUserGroups_2.BackColor = System.Drawing.SystemColors.Window;
			//this._grdUserGroups_2.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.Fixed3D;
			//this._grdUserGroups_2.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.Fixed3D;
			this._grdUserGroups_2.Cols.Count = 10;
			this._grdUserGroups_2.Cols.Fixed = 1;
			this._grdUserGroups_2.Cols.Frozen = 0;
			this._grdUserGroups_2.Cols.MaxSize = 0;
			this._grdUserGroups_2.Cols.MinSize = 0;
			this._grdUserGroups_2.Cursor = System.Windows.Forms.Cursors.Default;
			this._grdUserGroups_2.DrawMode = C1.Win.C1FlexGrid.DrawModeEnum.Normal;
			this._grdUserGroups_2.Enabled = true;
			this._grdUserGroups_2.ExtendLastCol = false;
			this._grdUserGroups_2.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.Light;
			this._grdUserGroups_2.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 178);
			this._grdUserGroups_2.ForeColor = System.Drawing.SystemColors.WindowText;
			this._grdUserGroups_2.HighLight = C1.Win.C1FlexGrid.HighLightEnum.Always;
			this._grdUserGroups_2.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.None;
			this._grdUserGroups_2.Location = new System.Drawing.Point(786, 23);
			this._grdUserGroups_2.Name = "_grdUserGroups_2";
			this._grdUserGroups_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._grdUserGroups_2.Rows.Count = 50;
			this._grdUserGroups_2.Rows.Fixed = 1;
			this._grdUserGroups_2.Rows.Frozen = 0;
			this._grdUserGroups_2.Rows.MaxSize = 0;
			this._grdUserGroups_2.Rows.MinSize = 0;
			this._grdUserGroups_2.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this._grdUserGroups_2.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Default;
			// this._grdUserGroups_2.ShowButtons = C1.Win.C1FlexGrid.ShowButtonsEnum.WithFocus;
			this._grdUserGroups_2.ShowSortPosition = C1.Win.C1FlexGrid.ShowSortPositionEnum.None;
			this._grdUserGroups_2.Size = new System.Drawing.Size(723, 343);
			this._grdUserGroups_2.Styles.Alternate.BackColor = System.Drawing.SystemColors.Window;
			this._grdUserGroups_2.Styles.EmptyArea.BackColor = System.Drawing.SystemColors.AppWorkspace;
			this._grdUserGroups_2.Styles.Fixed.BackColor = System.Drawing.SystemColors.Control;
			this._grdUserGroups_2.Styles.Fixed.Border.Color = System.Drawing.SystemColors.ControlDark;
			this._grdUserGroups_2.Styles.Fixed.Border.Direction = C1.Win.C1FlexGrid.BorderDirEnum.Both;
			this._grdUserGroups_2.Styles.Fixed.Border.Style = C1.Win.C1FlexGrid.BorderStyleEnum.Inset;
			this._grdUserGroups_2.Styles.Fixed.ForeColor = System.Drawing.SystemColors.ControlText;
			this._grdUserGroups_2.Styles.Fixed.TextEffect = C1.Win.C1FlexGrid.TextEffectEnum.Flat;
			this._grdUserGroups_2.Styles.Frozen.BackColor = System.Drawing.Color.Black;
			this._grdUserGroups_2.Styles.Frozen.ForeColor = System.Drawing.Color.Black;
			this._grdUserGroups_2.Styles.Highlight.BackColor = System.Drawing.SystemColors.Highlight;
			this._grdUserGroups_2.Styles.Highlight.ForeColor = System.Drawing.SystemColors.HighlightText;
			this._grdUserGroups_2.Styles.Normal.Border.Color = System.Drawing.SystemColors.Control;
			this._grdUserGroups_2.Styles.Normal.Border.Direction = C1.Win.C1FlexGrid.BorderDirEnum.Both;
			this._grdUserGroups_2.Styles.Normal.Border.Style = C1.Win.C1FlexGrid.BorderStyleEnum.Flat;
			this._grdUserGroups_2.Styles.Normal.Border.Width = 1;
			this._grdUserGroups_2.Styles.Normal.ImageAlign = C1.Win.C1FlexGrid.ImageAlignEnum.Stretch;
			this._grdUserGroups_2.Styles.Normal.TextEffect = C1.Win.C1FlexGrid.TextEffectEnum.Flat;
			this._grdUserGroups_2.Styles.Normal.Trimming = System.Drawing.StringTrimming.None;
			this._grdUserGroups_2.Styles.Normal.WordWrap = false;
			this._grdUserGroups_2.Styles[C1.Win.C1FlexGrid.CellStyleEnum.EmptyArea].Border.Color = System.Drawing.SystemColors.WindowFrame;
			this._grdUserGroups_2.SubtotalPosition = C1.Win.C1FlexGrid.SubtotalPositionEnum.AboveData;
			this._grdUserGroups_2.TabIndex = 5;
			this._grdUserGroups_2.Tree.Column = 0;
			this._grdUserGroups_2.Tree.LineColor = System.Drawing.SystemColors.ControlDark;
			this._grdUserGroups_2.Tree.Style = C1.Win.C1FlexGrid.TreeStyleFlags.None;
			////this._grdUserGroups_2.AfterEdit += new C1.Win.C1FlexGrid.RowColEventHandler(this.grdUserGroups_AfterEdit);
			////this._grdUserGroups_2.BeforeEdit += new C1.Win.C1FlexGrid.RowColEventHandler(this.grdUserGroups_BeforeEdit);
			////this._grdUserGroups_2.DoubleClick += new System.EventHandler(this.grdUserGroups_DoubleClick);
			////this._grdUserGroups_2.StartEdit += new C1.Win.C1FlexGrid.RowColEventHandler(this.grdUserGroups_StartEdit);
			// 
			// _grdUserGroups_3
			// 
			this._grdUserGroups_3.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None;
			//this._grdUserGroups_3.AllowDrop = true;
			this._grdUserGroups_3.AllowEditing = false;
			this._grdUserGroups_3.AllowFreezing = C1.Win.C1FlexGrid.AllowFreezingEnum.None;
			this._grdUserGroups_3.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.None;
			this._grdUserGroups_3.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.None;
			this._grdUserGroups_3.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.Columns;
			this._grdUserGroups_3.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;
			this._grdUserGroups_3.AutoResize = true;
			this._grdUserGroups_3.AutoSearch = C1.Win.C1FlexGrid.AutoSearchEnum.None;
			this._grdUserGroups_3.AutoSearchDelay = 2;
			this._grdUserGroups_3.BackColor = System.Drawing.SystemColors.Window;
			//this._grdUserGroups_3.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.Fixed3D;
			//this._grdUserGroups_3.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.Fixed3D;
			this._grdUserGroups_3.Cols.Count = 10;
			this._grdUserGroups_3.Cols.Fixed = 1;
			this._grdUserGroups_3.Cols.Frozen = 0;
			this._grdUserGroups_3.Cols.MaxSize = 0;
			this._grdUserGroups_3.Cols.MinSize = 0;
			this._grdUserGroups_3.Cursor = System.Windows.Forms.Cursors.Default;
			this._grdUserGroups_3.DrawMode = C1.Win.C1FlexGrid.DrawModeEnum.Normal;
			this._grdUserGroups_3.Enabled = true;
			this._grdUserGroups_3.ExtendLastCol = false;
			this._grdUserGroups_3.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.Light;
			this._grdUserGroups_3.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 178);
			this._grdUserGroups_3.ForeColor = System.Drawing.SystemColors.WindowText;
			this._grdUserGroups_3.HighLight = C1.Win.C1FlexGrid.HighLightEnum.Always;
			this._grdUserGroups_3.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.None;
			this._grdUserGroups_3.Location = new System.Drawing.Point(806, 23);
			this._grdUserGroups_3.Name = "_grdUserGroups_3";
			this._grdUserGroups_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._grdUserGroups_3.Rows.Count = 50;
			this._grdUserGroups_3.Rows.Fixed = 1;
			this._grdUserGroups_3.Rows.Frozen = 0;
			this._grdUserGroups_3.Rows.MaxSize = 0;
			this._grdUserGroups_3.Rows.MinSize = 0;
			this._grdUserGroups_3.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this._grdUserGroups_3.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Default;
			// this._grdUserGroups_3.ShowButtons = C1.Win.C1FlexGrid.ShowButtonsEnum.WithFocus;
			this._grdUserGroups_3.ShowSortPosition = C1.Win.C1FlexGrid.ShowSortPositionEnum.None;
			this._grdUserGroups_3.Size = new System.Drawing.Size(723, 343);
			this._grdUserGroups_3.Styles.Alternate.BackColor = System.Drawing.SystemColors.Window;
			this._grdUserGroups_3.Styles.EmptyArea.BackColor = System.Drawing.SystemColors.AppWorkspace;
			this._grdUserGroups_3.Styles.Fixed.BackColor = System.Drawing.SystemColors.Control;
			this._grdUserGroups_3.Styles.Fixed.Border.Color = System.Drawing.SystemColors.ControlDark;
			this._grdUserGroups_3.Styles.Fixed.Border.Direction = C1.Win.C1FlexGrid.BorderDirEnum.Both;
			this._grdUserGroups_3.Styles.Fixed.Border.Style = C1.Win.C1FlexGrid.BorderStyleEnum.Inset;
			this._grdUserGroups_3.Styles.Fixed.ForeColor = System.Drawing.SystemColors.ControlText;
			this._grdUserGroups_3.Styles.Fixed.TextEffect = C1.Win.C1FlexGrid.TextEffectEnum.Flat;
			this._grdUserGroups_3.Styles.Frozen.BackColor = System.Drawing.Color.Black;
			this._grdUserGroups_3.Styles.Frozen.ForeColor = System.Drawing.Color.Black;
			this._grdUserGroups_3.Styles.Highlight.BackColor = System.Drawing.SystemColors.Highlight;
			this._grdUserGroups_3.Styles.Highlight.ForeColor = System.Drawing.SystemColors.HighlightText;
			this._grdUserGroups_3.Styles.Normal.Border.Color = System.Drawing.SystemColors.Control;
			this._grdUserGroups_3.Styles.Normal.Border.Direction = C1.Win.C1FlexGrid.BorderDirEnum.Both;
			this._grdUserGroups_3.Styles.Normal.Border.Style = C1.Win.C1FlexGrid.BorderStyleEnum.Flat;
			this._grdUserGroups_3.Styles.Normal.Border.Width = 1;
			this._grdUserGroups_3.Styles.Normal.ImageAlign = C1.Win.C1FlexGrid.ImageAlignEnum.Stretch;
			this._grdUserGroups_3.Styles.Normal.TextEffect = C1.Win.C1FlexGrid.TextEffectEnum.Flat;
			this._grdUserGroups_3.Styles.Normal.Trimming = System.Drawing.StringTrimming.None;
			this._grdUserGroups_3.Styles.Normal.WordWrap = false;
			this._grdUserGroups_3.Styles[C1.Win.C1FlexGrid.CellStyleEnum.EmptyArea].Border.Color = System.Drawing.SystemColors.WindowFrame;
			this._grdUserGroups_3.SubtotalPosition = C1.Win.C1FlexGrid.SubtotalPositionEnum.AboveData;
			this._grdUserGroups_3.TabIndex = 6;
			this._grdUserGroups_3.Tree.Column = 0;
			this._grdUserGroups_3.Tree.LineColor = System.Drawing.SystemColors.ControlDark;
			this._grdUserGroups_3.Tree.Style = C1.Win.C1FlexGrid.TreeStyleFlags.None;
			////this._grdUserGroups_3.AfterEdit += new C1.Win.C1FlexGrid.RowColEventHandler(this.grdUserGroups_AfterEdit);
			////this._grdUserGroups_3.BeforeEdit += new C1.Win.C1FlexGrid.RowColEventHandler(this.grdUserGroups_BeforeEdit);
			////this._grdUserGroups_3.DoubleClick += new System.EventHandler(this.grdUserGroups_DoubleClick);
			////this._grdUserGroups_3.StartEdit += new C1.Win.C1FlexGrid.RowColEventHandler(this.grdUserGroups_StartEdit);
			// 
			// _grdUserGroups_4
			// 
			this._grdUserGroups_4.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None;
			//this._grdUserGroups_4.AllowDrop = true;
			this._grdUserGroups_4.AllowEditing = false;
			this._grdUserGroups_4.AllowFreezing = C1.Win.C1FlexGrid.AllowFreezingEnum.None;
			this._grdUserGroups_4.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.None;
			this._grdUserGroups_4.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.None;
			this._grdUserGroups_4.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.Columns;
			this._grdUserGroups_4.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;
			this._grdUserGroups_4.AutoResize = true;
			this._grdUserGroups_4.AutoSearch = C1.Win.C1FlexGrid.AutoSearchEnum.None;
			this._grdUserGroups_4.AutoSearchDelay = 2;
			this._grdUserGroups_4.BackColor = System.Drawing.SystemColors.Window;
			//this._grdUserGroups_4.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.Fixed3D;
			//this._grdUserGroups_4.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.Fixed3D;
			this._grdUserGroups_4.Cols.Count = 10;
			this._grdUserGroups_4.Cols.Fixed = 1;
			this._grdUserGroups_4.Cols.Frozen = 0;
			this._grdUserGroups_4.Cols.MaxSize = 0;
			this._grdUserGroups_4.Cols.MinSize = 0;
			this._grdUserGroups_4.Cursor = System.Windows.Forms.Cursors.Default;
			this._grdUserGroups_4.DrawMode = C1.Win.C1FlexGrid.DrawModeEnum.Normal;
			this._grdUserGroups_4.Enabled = true;
			this._grdUserGroups_4.ExtendLastCol = false;
			this._grdUserGroups_4.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.Light;
			this._grdUserGroups_4.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 178);
			this._grdUserGroups_4.ForeColor = System.Drawing.SystemColors.WindowText;
			this._grdUserGroups_4.HighLight = C1.Win.C1FlexGrid.HighLightEnum.Always;
			this._grdUserGroups_4.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.None;
			this._grdUserGroups_4.Location = new System.Drawing.Point(826, 23);
			this._grdUserGroups_4.Name = "_grdUserGroups_4";
			this._grdUserGroups_4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._grdUserGroups_4.Rows.Count = 50;
			this._grdUserGroups_4.Rows.Fixed = 1;
			this._grdUserGroups_4.Rows.Frozen = 0;
			this._grdUserGroups_4.Rows.MaxSize = 0;
			this._grdUserGroups_4.Rows.MinSize = 0;
			this._grdUserGroups_4.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this._grdUserGroups_4.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Default;
			// this._grdUserGroups_4.ShowButtons = C1.Win.C1FlexGrid.ShowButtonsEnum.WithFocus;
			this._grdUserGroups_4.ShowSortPosition = C1.Win.C1FlexGrid.ShowSortPositionEnum.None;
			this._grdUserGroups_4.Size = new System.Drawing.Size(723, 343);
			this._grdUserGroups_4.Styles.Alternate.BackColor = System.Drawing.SystemColors.Window;
			this._grdUserGroups_4.Styles.EmptyArea.BackColor = System.Drawing.SystemColors.AppWorkspace;
			this._grdUserGroups_4.Styles.Fixed.BackColor = System.Drawing.SystemColors.Control;
			this._grdUserGroups_4.Styles.Fixed.Border.Color = System.Drawing.SystemColors.ControlDark;
			this._grdUserGroups_4.Styles.Fixed.Border.Direction = C1.Win.C1FlexGrid.BorderDirEnum.Both;
			this._grdUserGroups_4.Styles.Fixed.Border.Style = C1.Win.C1FlexGrid.BorderStyleEnum.Inset;
			this._grdUserGroups_4.Styles.Fixed.ForeColor = System.Drawing.SystemColors.ControlText;
			this._grdUserGroups_4.Styles.Fixed.TextEffect = C1.Win.C1FlexGrid.TextEffectEnum.Flat;
			this._grdUserGroups_4.Styles.Frozen.BackColor = System.Drawing.Color.Black;
			this._grdUserGroups_4.Styles.Frozen.ForeColor = System.Drawing.Color.Black;
			this._grdUserGroups_4.Styles.Highlight.BackColor = System.Drawing.SystemColors.Highlight;
			this._grdUserGroups_4.Styles.Highlight.ForeColor = System.Drawing.SystemColors.HighlightText;
			this._grdUserGroups_4.Styles.Normal.Border.Color = System.Drawing.SystemColors.Control;
			this._grdUserGroups_4.Styles.Normal.Border.Direction = C1.Win.C1FlexGrid.BorderDirEnum.Both;
			this._grdUserGroups_4.Styles.Normal.Border.Style = C1.Win.C1FlexGrid.BorderStyleEnum.Flat;
			this._grdUserGroups_4.Styles.Normal.Border.Width = 1;
			this._grdUserGroups_4.Styles.Normal.ImageAlign = C1.Win.C1FlexGrid.ImageAlignEnum.Stretch;
			this._grdUserGroups_4.Styles.Normal.TextEffect = C1.Win.C1FlexGrid.TextEffectEnum.Flat;
			this._grdUserGroups_4.Styles.Normal.Trimming = System.Drawing.StringTrimming.None;
			this._grdUserGroups_4.Styles.Normal.WordWrap = false;
			this._grdUserGroups_4.Styles[C1.Win.C1FlexGrid.CellStyleEnum.EmptyArea].Border.Color = System.Drawing.SystemColors.WindowFrame;
			this._grdUserGroups_4.SubtotalPosition = C1.Win.C1FlexGrid.SubtotalPositionEnum.AboveData;
			this._grdUserGroups_4.TabIndex = 9;
			this._grdUserGroups_4.Tree.Column = 0;
			this._grdUserGroups_4.Tree.LineColor = System.Drawing.SystemColors.ControlDark;
			this._grdUserGroups_4.Tree.Style = C1.Win.C1FlexGrid.TreeStyleFlags.None;
			//this._grdUserGroups_4.AfterEdit += new C1.Win.C1FlexGrid.RowColEventHandler(this.grdUserGroups_AfterEdit);
			//this._grdUserGroups_4.BeforeEdit += new C1.Win.C1FlexGrid.RowColEventHandler(this.grdUserGroups_BeforeEdit);
			//this._grdUserGroups_4.DoubleClick += new System.EventHandler(this.grdUserGroups_DoubleClick);
			//this._grdUserGroups_4.StartEdit += new C1.Win.C1FlexGrid.RowColEventHandler(this.grdUserGroups_StartEdit);
			// 
			// txtGroupName
			// 
			//this.txtGroupName.AllowDrop = true;
			this.txtGroupName.BackColor = System.Drawing.Color.White;
			this.txtGroupName.ForeColor = System.Drawing.Color.Black;
			this.txtGroupName.Location = new System.Drawing.Point(128, 14);
			this.txtGroupName.MaxLength = 50;
			this.txtGroupName.Name = "txtGroupName";
			this.txtGroupName.Size = new System.Drawing.Size(195, 19);
			this.txtGroupName.TabIndex = 0;
			this.txtGroupName.Text = "";
			// 
			// lblGroupName
			// 
			//this.lblGroupName.AllowDrop = true;
			this.lblGroupName.BackColor = System.Drawing.SystemColors.Window;
			this.lblGroupName.Text = "Group Name";
			this.lblGroupName.Location = new System.Drawing.Point(20, 17);
			this.lblGroupName.Name = "lblGroupName";
			this.lblGroupName.Size = new System.Drawing.Size(60, 14);
			this.lblGroupName.TabIndex = 10;
			// 
			// lblBasicGroupName
			// 
			//this.lblBasicGroupName.AllowDrop = true;
			this.lblBasicGroupName.BackColor = System.Drawing.SystemColors.Window;
			this.lblBasicGroupName.Text = "Use Basic Facility of :";
			this.lblBasicGroupName.Location = new System.Drawing.Point(20, 37);
			this.lblBasicGroupName.Name = "lblBasicGroupName";
			this.lblBasicGroupName.Size = new System.Drawing.Size(104, 14);
			this.lblBasicGroupName.TabIndex = 11;
			// 
			// txtBasicGroupName
			// 
			//this.txtBasicGroupName.AllowDrop = true;
			this.txtBasicGroupName.BackColor = System.Drawing.Color.White;
			this.txtBasicGroupName.ForeColor = System.Drawing.Color.Black;
			this.txtBasicGroupName.Location = new System.Drawing.Point(128, 35);
			//this.txtBasicGroupName.Locked = true;
			this.txtBasicGroupName.MaxLength = 50;
			this.txtBasicGroupName.Name = "txtBasicGroupName";
			// this.txtBasicGroupName.ShowButton = true;
			this.txtBasicGroupName.Size = new System.Drawing.Size(195, 19);
			this.txtBasicGroupName.TabIndex = 1;
			this.txtBasicGroupName.Text = "";
			// this.//this.txtBasicGroupName.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(//this.txtBasicGroupName_DropButtonClick);
			// 
			// Line1
			// 
			//this.Line1.AllowDrop = true;
			this.Line1.BackColor = System.Drawing.SystemColors.WindowText;
			this.Line1.Enabled = false;
			this.Line1.Location = new System.Drawing.Point(0, 74);
			this.Line1.Name = "Line1";
			this.Line1.Size = new System.Drawing.Size(736, 1);
			this.Line1.Visible = true;
			// 
			// frmSysUserGroups
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.ClientSize = new System.Drawing.Size(784, 523);
			this.Controls.Add(this.cntOuterFrame);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			//this.Icon = (System.Drawing.Icon) resources.GetObject("frmSysUserGroups.Icon");
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(149, 166);
			this.MaximizeBox = true;
			this.MinimizeBox = true;
			this.Name = "frmSysUserGroups";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Maintain User Groups";
			// this.Activated += new System.EventHandler(this.frmSysUserGroups_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
			// this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
			//((System.ComponentModel.ISupportInitialize) this.tabUserGroups).EndInit();
			//((System.ComponentModel.ISupportInitialize) this.cntOuterFrame).EndInit();
			this.cntOuterFrame.ResumeLayout(false);
			this.tabUserGroups.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		// 
		void InitializegrdUserGroups()
		{
			this.grdUserGroups = new C1.Win.C1FlexGrid.C1FlexGrid[5];
			this.grdUserGroups[0] = _grdUserGroups_0;
			this.grdUserGroups[1] = _grdUserGroups_1;
			this.grdUserGroups[2] = _grdUserGroups_2;
			this.grdUserGroups[3] = _grdUserGroups_3;
			this.grdUserGroups[4] = _grdUserGroups_4;
		}
		#endregion
	}
}//ENDSHERE
