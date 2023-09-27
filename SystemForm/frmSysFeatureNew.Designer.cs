
namespace Xtreme
{
	partial class frmSysFeatureNew
	{

		#region "Upgrade Support "
		private static frmSysFeatureNew m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmSysFeatureNew DefInstance
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
		public static frmSysFeatureNew CreateInstance()
		{
			frmSysFeatureNew theInstance = new frmSysFeatureNew();
			
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
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "txtRemarks", "grdFeature"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public System.Windows.Forms.TextBox txtRemarks;
		public C1.Win.C1FlexGrid.C1FlexGrid grdFeature;
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSysFeatureNew));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this.txtRemarks = new System.Windows.Forms.TextBox();
			this.grdFeature = new C1.Win.C1FlexGrid.C1FlexGrid();
			this.SuspendLayout();
			// 
			// txtRemarks
			// 
			this.txtRemarks.AcceptsReturn = true;
			//this.txtRemarks.AllowDrop = true;
			this.txtRemarks.BackColor = System.Drawing.SystemColors.Window;
			//this.txtRemarks.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.txtRemarks.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtRemarks.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 178);
			this.txtRemarks.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtRemarks.Location = new System.Drawing.Point(0, 422);
			this.txtRemarks.MaxLength = 0;
			this.txtRemarks.Multiline = true;
			this.txtRemarks.Name = "txtRemarks";
			this.txtRemarks.ReadOnly = true;
			this.txtRemarks.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtRemarks.Size = new System.Drawing.Size(793, 27);
			this.txtRemarks.TabIndex = 0;
			this.txtRemarks.Text = "Text1";
			// 
			// grdFeature
			// 
			this.grdFeature.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None;
			//this.grdFeature.AllowDrop = true;
			this.grdFeature.AllowEditing = true;
			this.grdFeature.AllowFreezing = C1.Win.C1FlexGrid.AllowFreezingEnum.None;
			this.grdFeature.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.None;
			this.grdFeature.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.None;
			this.grdFeature.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.Columns;
			this.grdFeature.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;
			this.grdFeature.AutoResize = false;
			this.grdFeature.AutoSearch = C1.Win.C1FlexGrid.AutoSearchEnum.None;
			this.grdFeature.AutoSearchDelay = 4;
			this.grdFeature.BackColor = System.Drawing.SystemColors.Window;
			//this.grdFeature.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle;
			//this.grdFeature.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.None;
			this.grdFeature.Cols.Count = 10;
			this.grdFeature.Cols.Fixed = 1;
			this.grdFeature.Cols.Frozen = 0;
			this.grdFeature.Cols.MaxSize = 0;
			this.grdFeature.Cols.MinSize = 0;
			this.grdFeature.Cursor = System.Windows.Forms.Cursors.Default;
			this.grdFeature.DrawMode = C1.Win.C1FlexGrid.DrawModeEnum.Normal;
			this.grdFeature.EditOptions = (C1.Win.C1FlexGrid.EditFlags) (C1.Win.C1FlexGrid.EditFlags.AutoSearch | C1.Win.C1FlexGrid.EditFlags.CycleOnDoubleClick | C1.Win.C1FlexGrid.EditFlags.MultiCheck | C1.Win.C1FlexGrid.EditFlags.DelayedCommit | C1.Win.C1FlexGrid.EditFlags.ExitOnLeftRightKeys | C1.Win.C1FlexGrid.EditFlags.EditOnRequest);
			this.grdFeature.Enabled = true;
			this.grdFeature.ExtendLastCol = true;
			this.grdFeature.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.Light;
			this.grdFeature.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 178);
			this.grdFeature.ForeColor = System.Drawing.SystemColors.WindowText;
			this.grdFeature.HighLight = C1.Win.C1FlexGrid.HighLightEnum.Always;
			this.grdFeature.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.None;
			this.grdFeature.Location = new System.Drawing.Point(0, 4);
			this.grdFeature.Name = "grdFeature";
			this.grdFeature.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.grdFeature.Rows.Count = 50;
			this.grdFeature.Rows.Fixed = 1;
			this.grdFeature.Rows.Frozen = 0;
			this.grdFeature.Rows.MaxSize = 0;
			this.grdFeature.Rows.MinSize = 0;
			this.grdFeature.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.grdFeature.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Default;
			// this.grdFeature.ShowButtons = C1.Win.C1FlexGrid.ShowButtonsEnum.WithFocus;
			this.grdFeature.ShowSortPosition = C1.Win.C1FlexGrid.ShowSortPositionEnum.None;
			this.grdFeature.Size = new System.Drawing.Size(793, 417);
			this.grdFeature.Styles.Alternate.BackColor = System.Drawing.SystemColors.Window;
			this.grdFeature.Styles.EmptyArea.BackColor = System.Drawing.SystemColors.AppWorkspace;
			this.grdFeature.Styles.Fixed.BackColor = System.Drawing.Color.FromArgb(123, 136, 119);
			this.grdFeature.Styles.Fixed.Border.Color = System.Drawing.SystemColors.ControlDark;
			this.grdFeature.Styles.Fixed.Border.Direction = C1.Win.C1FlexGrid.BorderDirEnum.Both;
			this.grdFeature.Styles.Fixed.Border.Style = C1.Win.C1FlexGrid.BorderStyleEnum.Inset;
			this.grdFeature.Styles.Fixed.ForeColor = System.Drawing.Color.White;
			this.grdFeature.Styles.Fixed.TextEffect = C1.Win.C1FlexGrid.TextEffectEnum.Flat;
			this.grdFeature.Styles.Frozen.BackColor = System.Drawing.Color.Black;
			this.grdFeature.Styles.Frozen.ForeColor = System.Drawing.Color.Black;
			this.grdFeature.Styles.Highlight.BackColor = System.Drawing.SystemColors.Highlight;
			this.grdFeature.Styles.Highlight.ForeColor = System.Drawing.SystemColors.HighlightText;
			this.grdFeature.Styles.Normal.Border.Color = System.Drawing.Color.Silver;
			this.grdFeature.Styles.Normal.Border.Direction = C1.Win.C1FlexGrid.BorderDirEnum.Both;
			this.grdFeature.Styles.Normal.Border.Style = C1.Win.C1FlexGrid.BorderStyleEnum.Flat;
			this.grdFeature.Styles.Normal.Border.Width = 1;
			this.grdFeature.Styles.Normal.ImageAlign = C1.Win.C1FlexGrid.ImageAlignEnum.Stretch;
			this.grdFeature.Styles.Normal.TextEffect = C1.Win.C1FlexGrid.TextEffectEnum.Flat;
			this.grdFeature.Styles.Normal.Trimming = System.Drawing.StringTrimming.None;
			this.grdFeature.Styles.Normal.WordWrap = false;
			this.grdFeature.Styles[C1.Win.C1FlexGrid.CellStyleEnum.EmptyArea].Border.Color = System.Drawing.SystemColors.WindowFrame;
			this.grdFeature.SubtotalPosition = C1.Win.C1FlexGrid.SubtotalPositionEnum.AboveData;
			this.grdFeature.TabIndex = 1;
			this.grdFeature.Tree.Column = 0;
			this.grdFeature.Tree.LineColor = System.Drawing.SystemColors.ControlDark;
			this.grdFeature.Tree.Style = C1.Win.C1FlexGrid.TreeStyleFlags.None;
			//this.grdFeature.StartEdit += new C1.Win.C1FlexGrid.RowColEventHandler(this.grdFeature_StartEdit);
			// 
			// frmSysFeatureNew
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.ClientSize = new System.Drawing.Size(795, 508);
			this.Controls.Add(this.txtRemarks);
			this.Controls.Add(this.grdFeature);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			//this.Icon = (System.Drawing.Icon) resources.GetObject("frmSysFeatureNew.Icon");
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(100, 122);
			this.MaximizeBox = true;
			this.MinimizeBox = true;
			this.Name = "frmSysFeatureNew";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "System Feature New";
			// this.Activated += new System.EventHandler(this.Form_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
			// this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
			this.ResumeLayout(false);
		}
		// 
		#endregion
	}
}//ENDSHERE
