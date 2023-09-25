
namespace Xtreme
{
	partial class frmSysReportDesign1
	{

		#region "Upgrade Support "
		private static frmSysReportDesign1 m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmSysReportDesign1 DefInstance
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
		public static frmSysReportDesign1 CreateInstance()
		{
			frmSysReportDesign1 theInstance = new frmSysReportDesign1();
			
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
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "cdgCreateFile", "vspReportPrinter", "grdReportHeader", "grdReportDesign", "CommandBars"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public System.Windows.Forms.OpenFileDialog cdgCreateFileOpen;
		public System.Windows.Forms.SaveFileDialog cdgCreateFileSave;
		public System.Windows.Forms.FontDialog cdgCreateFileFont;
		public System.Windows.Forms.ColorDialog cdgCreateFileColor;
		public System.Windows.Forms.PrintDialog cdgCreateFilePrint;
		public UpgradeStubs.AxMSComDlg_AxCommonDialog cdgCreateFile;
		public AxVSPrinter8Lib.AxVSPrinter vspReportPrinter;
		public C1.Win.C1FlexGrid.C1FlexGrid grdReportHeader;
		public C1.Win.C1FlexGrid.C1FlexGrid grdReportDesign;
		public Syncfusion.Windows.Forms.Tools.CommandBarController CommandBars;
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSysReportDesign1));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this.cdgCreateFileOpen = new System.Windows.Forms.OpenFileDialog();
			this.cdgCreateFileSave = new System.Windows.Forms.SaveFileDialog();
			this.cdgCreateFileFont = new System.Windows.Forms.FontDialog();
			this.cdgCreateFileColor = new System.Windows.Forms.ColorDialog();
			this.cdgCreateFilePrint = new System.Windows.Forms.PrintDialog();
			this.cdgCreateFile = new UpgradeStubs.AxMSComDlg_AxCommonDialog();
			this.vspReportPrinter = new AxVSPrinter8Lib.AxVSPrinter();
			this.grdReportDesign = new C1.Win.C1FlexGrid.C1FlexGrid();
			this.grdReportHeader = new C1.Win.C1FlexGrid.C1FlexGrid();
			this.CommandBars = new Syncfusion.Windows.Forms.Tools.CommandBarController();
			// //((System.ComponentModel.ISupportInitialize) this.vspReportPrinter).BeginInit();
			// //((System.ComponentModel.ISupportInitialize) this.CommandBars).BeginInit();
			this.grdReportDesign.SuspendLayout();
			this.SuspendLayout();
			// 
			// vspReportPrinter
			// 
			this.vspReportPrinter.AllowDrop = true;
			this.vspReportPrinter.Location = new System.Drawing.Point(0, 48);
			this.vspReportPrinter.Name = "vspReportPrinter";
			("vspReportPrinter.OcxState");
			this.vspReportPrinter.Size = new System.Drawing.Size(581, 121);
			this.vspReportPrinter.TabIndex = 0;
			this.vspReportPrinter.Visible = false;
			// 
			// grdReportDesign
			// 
			this.grdReportDesign.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None;
			this.grdReportDesign.AllowDrop = true;
			this.grdReportDesign.AllowEditing = false;
			this.grdReportDesign.AllowFreezing = C1.Win.C1FlexGrid.AllowFreezingEnum.None;
			this.grdReportDesign.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.None;
			this.grdReportDesign.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.None;
			this.grdReportDesign.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.Columns;
			this.grdReportDesign.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;
			this.grdReportDesign.AutoResize = true;
			this.grdReportDesign.AutoSearch = C1.Win.C1FlexGrid.AutoSearchEnum.None;
			this.grdReportDesign.AutoSearchDelay = 2;
			this.grdReportDesign.BackColor = System.Drawing.SystemColors.Window;
			this.grdReportDesign.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle;
			this.grdReportDesign.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.None;
			this.grdReportDesign.Cols.Count = 10;
			this.grdReportDesign.Cols.Fixed = 0;
			this.grdReportDesign.Cols.Frozen = 0;
			this.grdReportDesign.Cols.MaxSize = 0;
			this.grdReportDesign.Cols.MinSize = 0;
			this.grdReportDesign.Controls.Add(this.grdReportHeader);
			this.grdReportDesign.Cursor = System.Windows.Forms.Cursors.Default;
			this.grdReportDesign.DrawMode = C1.Win.C1FlexGrid.DrawModeEnum.Normal;
			this.grdReportDesign.Enabled = true;
			this.grdReportDesign.ExtendLastCol = false;
			this.grdReportDesign.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.Light;
			this.grdReportDesign.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 178);
			this.grdReportDesign.ForeColor = System.Drawing.SystemColors.WindowText;
			this.grdReportDesign.HighLight = C1.Win.C1FlexGrid.HighLightEnum.Always;
			this.grdReportDesign.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.None;
			this.grdReportDesign.Location = new System.Drawing.Point(2, 182);
			this.grdReportDesign.Name = "grdReportDesign";
			this.grdReportDesign.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.grdReportDesign.Rows.Count = 5;
			this.grdReportDesign.Rows.Fixed = 0;
			this.grdReportDesign.Rows.Frozen = 0;
			this.grdReportDesign.Rows.MaxSize = 0;
			this.grdReportDesign.Rows.MinSize = 0;
			this.grdReportDesign.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.grdReportDesign.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Default;
			// this.grdReportDesign.ShowButtons = C1.Win.C1FlexGrid.ShowButtonsEnum.WithFocus;
			this.grdReportDesign.ShowSortPosition = C1.Win.C1FlexGrid.ShowSortPositionEnum.None;
			this.grdReportDesign.Size = new System.Drawing.Size(577, 161);
			this.grdReportDesign.Styles.Alternate.BackColor = System.Drawing.SystemColors.Window;
			this.grdReportDesign.Styles.EmptyArea.BackColor = System.Drawing.SystemColors.AppWorkspace;
			this.grdReportDesign.Styles.Fixed.BackColor = System.Drawing.SystemColors.Control;
			this.grdReportDesign.Styles.Fixed.Border.Color = System.Drawing.SystemColors.ControlDark;
			this.grdReportDesign.Styles.Fixed.Border.Direction = C1.Win.C1FlexGrid.BorderDirEnum.Both;
			this.grdReportDesign.Styles.Fixed.Border.Style = C1.Win.C1FlexGrid.BorderStyleEnum.Inset;
			this.grdReportDesign.Styles.Fixed.ForeColor = System.Drawing.SystemColors.ControlText;
			this.grdReportDesign.Styles.Fixed.TextEffect = C1.Win.C1FlexGrid.TextEffectEnum.Flat;
			this.grdReportDesign.Styles.Frozen.BackColor = System.Drawing.Color.Black;
			this.grdReportDesign.Styles.Frozen.ForeColor = System.Drawing.Color.Black;
			this.grdReportDesign.Styles.Highlight.BackColor = System.Drawing.SystemColors.Highlight;
			this.grdReportDesign.Styles.Highlight.ForeColor = System.Drawing.SystemColors.HighlightText;
			this.grdReportDesign.Styles.Normal.Border.Color = System.Drawing.SystemColors.Control;
			this.grdReportDesign.Styles.Normal.Border.Direction = C1.Win.C1FlexGrid.BorderDirEnum.Both;
			this.grdReportDesign.Styles.Normal.Border.Style = C1.Win.C1FlexGrid.BorderStyleEnum.Flat;
			this.grdReportDesign.Styles.Normal.Border.Width = 1;
			this.grdReportDesign.Styles.Normal.ImageAlign = C1.Win.C1FlexGrid.ImageAlignEnum.Stretch;
			this.grdReportDesign.Styles.Normal.TextEffect = C1.Win.C1FlexGrid.TextEffectEnum.Flat;
			this.grdReportDesign.Styles.Normal.Trimming = System.Drawing.StringTrimming.None;
			this.grdReportDesign.Styles.Normal.WordWrap = false;
			this.grdReportDesign.Styles[C1.Win.C1FlexGrid.CellStyleEnum.EmptyArea].Border.Color = System.Drawing.SystemColors.WindowFrame;
			this.grdReportDesign.SubtotalPosition = C1.Win.C1FlexGrid.SubtotalPositionEnum.AboveData;
			this.grdReportDesign.TabIndex = 1;
			this.grdReportDesign.Tree.Column = 0;
			this.grdReportDesign.Tree.LineColor = System.Drawing.SystemColors.ControlDark;
			this.grdReportDesign.Tree.Style = C1.Win.C1FlexGrid.TreeStyleFlags.None;
			// 
			// grdReportHeader
			// 
			this.grdReportHeader.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None;
			this.grdReportHeader.AllowDrop = true;
			this.grdReportHeader.AllowEditing = false;
			this.grdReportHeader.AllowFreezing = C1.Win.C1FlexGrid.AllowFreezingEnum.None;
			this.grdReportHeader.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.None;
			this.grdReportHeader.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.None;
			this.grdReportHeader.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.Columns;
			this.grdReportHeader.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;
			this.grdReportHeader.AutoResize = true;
			this.grdReportHeader.AutoSearch = C1.Win.C1FlexGrid.AutoSearchEnum.None;
			this.grdReportHeader.AutoSearchDelay = 2;
			this.grdReportHeader.BackColor = System.Drawing.Color.FromArgb(255, 192, 192);
			this.grdReportHeader.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.Fixed3D;
			this.grdReportHeader.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.Fixed3D;
			this.grdReportHeader.Cols.Count = 10;
			this.grdReportHeader.Cols.Fixed = 1;
			this.grdReportHeader.Cols.Frozen = 0;
			this.grdReportHeader.Cols.MaxSize = 0;
			this.grdReportHeader.Cols.MinSize = 0;
			this.grdReportHeader.Cursor = System.Windows.Forms.Cursors.Default;
			this.grdReportHeader.DrawMode = C1.Win.C1FlexGrid.DrawModeEnum.Normal;
			this.grdReportHeader.Enabled = true;
			this.grdReportHeader.ExtendLastCol = false;
			this.grdReportHeader.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.Light;
			this.grdReportHeader.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 178);
			this.grdReportHeader.ForeColor = System.Drawing.SystemColors.WindowText;
			this.grdReportHeader.HighLight = C1.Win.C1FlexGrid.HighLightEnum.Always;
			this.grdReportHeader.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.None;
			this.grdReportHeader.Location = new System.Drawing.Point(110, 26);
			this.grdReportHeader.Name = "grdReportHeader";
			this.grdReportHeader.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.grdReportHeader.Rows.Count = 50;
			this.grdReportHeader.Rows.Fixed = 1;
			this.grdReportHeader.Rows.Frozen = 0;
			this.grdReportHeader.Rows.MaxSize = 0;
			this.grdReportHeader.Rows.MinSize = 0;
			this.grdReportHeader.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.grdReportHeader.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Default;
			// this.grdReportHeader.ShowButtons = C1.Win.C1FlexGrid.ShowButtonsEnum.WithFocus;
			this.grdReportHeader.ShowSortPosition = C1.Win.C1FlexGrid.ShowSortPositionEnum.None;
			this.grdReportHeader.Size = new System.Drawing.Size(193, 63);
			this.grdReportHeader.Styles.Alternate.BackColor = System.Drawing.Color.FromArgb(255, 192, 192);
			this.grdReportHeader.Styles.EmptyArea.BackColor = System.Drawing.SystemColors.AppWorkspace;
			this.grdReportHeader.Styles.Fixed.BackColor = System.Drawing.SystemColors.Control;
			this.grdReportHeader.Styles.Fixed.Border.Color = System.Drawing.SystemColors.ControlDark;
			this.grdReportHeader.Styles.Fixed.Border.Direction = C1.Win.C1FlexGrid.BorderDirEnum.Both;
			this.grdReportHeader.Styles.Fixed.Border.Style = C1.Win.C1FlexGrid.BorderStyleEnum.Inset;
			this.grdReportHeader.Styles.Fixed.ForeColor = System.Drawing.SystemColors.ControlText;
			this.grdReportHeader.Styles.Fixed.TextEffect = C1.Win.C1FlexGrid.TextEffectEnum.Flat;
			this.grdReportHeader.Styles.Frozen.BackColor = System.Drawing.Color.Black;
			this.grdReportHeader.Styles.Frozen.ForeColor = System.Drawing.Color.Black;
			this.grdReportHeader.Styles.Highlight.BackColor = System.Drawing.SystemColors.Highlight;
			this.grdReportHeader.Styles.Highlight.ForeColor = System.Drawing.SystemColors.HighlightText;
			this.grdReportHeader.Styles.Normal.Border.Color = System.Drawing.SystemColors.Control;
			this.grdReportHeader.Styles.Normal.Border.Direction = C1.Win.C1FlexGrid.BorderDirEnum.Both;
			this.grdReportHeader.Styles.Normal.Border.Style = C1.Win.C1FlexGrid.BorderStyleEnum.Flat;
			this.grdReportHeader.Styles.Normal.Border.Width = 1;
			this.grdReportHeader.Styles.Normal.ImageAlign = C1.Win.C1FlexGrid.ImageAlignEnum.Stretch;
			this.grdReportHeader.Styles.Normal.TextEffect = C1.Win.C1FlexGrid.TextEffectEnum.Flat;
			this.grdReportHeader.Styles.Normal.Trimming = System.Drawing.StringTrimming.None;
			this.grdReportHeader.Styles.Normal.WordWrap = false;
			this.grdReportHeader.Styles[C1.Win.C1FlexGrid.CellStyleEnum.EmptyArea].Border.Color = System.Drawing.SystemColors.WindowFrame;
			this.grdReportHeader.SubtotalPosition = C1.Win.C1FlexGrid.SubtotalPositionEnum.AboveData;
			this.grdReportHeader.TabIndex = 2;
			this.grdReportHeader.Tree.Column = 0;
			this.grdReportHeader.Tree.LineColor = System.Drawing.SystemColors.ControlDark;
			this.grdReportHeader.Tree.Style = C1.Win.C1FlexGrid.TreeStyleFlags.None;
			// 
			// CommandBars
			// 
			this.CommandBars.AllowDrop = true;
			this.CommandBars.Location = new System.Drawing.Point(16, 4);
			this.CommandBars.Name = "CommandBars";
			("CommandBars.OcxState");
			this.CommandBars.Execute += new AxXtremeCommandBars._DCommandBarsEvents_ExecuteEventHandler(this.CommandBars_Execute);
			// 
			// frmSysReportDesign1
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.ClientSize = new System.Drawing.Size(811, 527);
			this.Controls.Add(this.vspReportPrinter);
			this.Controls.Add(this.grdReportDesign);
			this.Controls.Add(this.CommandBars);
			this.Location = new System.Drawing.Point(393, 145);
			this.MaximizeBox = true;
			this.MinimizeBox = true;
			this.Name = "frmSysReportDesign1";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Test Report";
			// this.Activated += new System.EventHandler(this.frmSysReportDesign1_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
			//((System.ComponentModel.ISupportInitialize) this.vspReportPrinter).EndInit();
			//((System.ComponentModel.ISupportInitialize) this.CommandBars).EndInit();
			this.grdReportDesign.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		void ReLoadForm(bool addEvents)
		{
			//This form is an MDI child.
			//This code simulates the VB6 
			// functionality of automatically
			// loading and showing an MDI
			// child's parent.
			this.MdiParent = Xtreme.frmSysMain.DefInstance;
			Xtreme.frmSysMain.DefInstance.Show();
		}
		#endregion
	}
}//ENDSHERE
