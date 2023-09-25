
namespace Xtreme
{
	partial class frmSysPreferencesNew
	{

		#region "Upgrade Support "
		private static frmSysPreferencesNew m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmSysPreferencesNew DefInstance
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
		public static frmSysPreferencesNew CreateInstance()
		{
			frmSysPreferencesNew theInstance = new frmSysPreferencesNew();
			
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
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "cmbPreferenceDataList", "txtRemarks", "grdPreference", "UCStatusBar"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public System.Windows.Forms.ComboBox cmbPreferenceDataList;
		public System.Windows.Forms.TextBox txtRemarks;
		public C1.Win.C1FlexGrid.C1FlexGrid grdPreference;
		public UCStatusBar UCStatusBar;
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSysPreferencesNew));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this.cmbPreferenceDataList = new System.Windows.Forms.ComboBox();
			this.txtRemarks = new System.Windows.Forms.TextBox();
			this.grdPreference = new C1.Win.C1FlexGrid.C1FlexGrid();
			this.UCStatusBar = new UCStatusBar();
			this.SuspendLayout();
			// 
			// cmbPreferenceDataList
			// 
			this.cmbPreferenceDataList.AllowDrop = true;
			this.cmbPreferenceDataList.BackColor = System.Drawing.SystemColors.Window;
			this.cmbPreferenceDataList.CausesValidation = true;
			this.cmbPreferenceDataList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			this.cmbPreferenceDataList.Enabled = true;
			this.cmbPreferenceDataList.ForeColor = System.Drawing.SystemColors.WindowText;
			this.cmbPreferenceDataList.IntegralHeight = false;
			this.cmbPreferenceDataList.Location = new System.Drawing.Point(560, 128);
			this.cmbPreferenceDataList.Name = "cmbPreferenceDataList";
			this.cmbPreferenceDataList.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmbPreferenceDataList.Size = new System.Drawing.Size(97, 21);
			this.cmbPreferenceDataList.Sorted = true;
			this.cmbPreferenceDataList.TabIndex = 2;
			this.cmbPreferenceDataList.TabStop = true;
			this.cmbPreferenceDataList.Text = "cmbPreferenceDataList";
			this.cmbPreferenceDataList.Visible = true;
			// this.cmbPreferenceDataList.Leave += new System.EventHandler(this.cmbPreferenceDataList_Leave);
			// 
			// txtRemarks
			// 
			this.txtRemarks.AcceptsReturn = true;
			this.txtRemarks.AllowDrop = true;
			this.txtRemarks.BackColor = System.Drawing.SystemColors.Window;
			this.txtRemarks.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
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
			this.txtRemarks.TabIndex = 1;
			this.txtRemarks.Text = "Text1";
			// 
			// grdPreference
			// 
			this.grdPreference.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None;
			this.grdPreference.AllowDrop = true;
			this.grdPreference.AllowEditing = true;
			this.grdPreference.AllowFreezing = C1.Win.C1FlexGrid.AllowFreezingEnum.None;
			this.grdPreference.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.None;
			this.grdPreference.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.None;
			this.grdPreference.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.Columns;
			this.grdPreference.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;
			this.grdPreference.AutoResize = false;
			this.grdPreference.AutoSearch = C1.Win.C1FlexGrid.AutoSearchEnum.None;
			this.grdPreference.AutoSearchDelay = 4;
			this.grdPreference.BackColor = System.Drawing.SystemColors.Window;
			this.grdPreference.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle;
			this.grdPreference.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.None;
			this.grdPreference.Cols.Count = 10;
			this.grdPreference.Cols.Fixed = 1;
			this.grdPreference.Cols.Frozen = 0;
			this.grdPreference.Cols.MaxSize = 0;
			this.grdPreference.Cols.MinSize = 0;
			this.grdPreference.Cursor = System.Windows.Forms.Cursors.Default;
			this.grdPreference.DrawMode = C1.Win.C1FlexGrid.DrawModeEnum.Normal;
			this.grdPreference.EditOptions = (C1.Win.C1FlexGrid.EditFlags) (C1.Win.C1FlexGrid.EditFlags.AutoSearch | C1.Win.C1FlexGrid.EditFlags.CycleOnDoubleClick | C1.Win.C1FlexGrid.EditFlags.MultiCheck | C1.Win.C1FlexGrid.EditFlags.DelayedCommit | C1.Win.C1FlexGrid.EditFlags.ExitOnLeftRightKeys | C1.Win.C1FlexGrid.EditFlags.EditOnRequest);
			this.grdPreference.Enabled = true;
			this.grdPreference.ExtendLastCol = true;
			this.grdPreference.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.Light;
			this.grdPreference.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 178);
			this.grdPreference.ForeColor = System.Drawing.SystemColors.WindowText;
			this.grdPreference.HighLight = C1.Win.C1FlexGrid.HighLightEnum.Always;
			this.grdPreference.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.None;
			this.grdPreference.Location = new System.Drawing.Point(0, 4);
			this.grdPreference.Name = "grdPreference";
			this.grdPreference.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.grdPreference.Rows.Count = 50;
			this.grdPreference.Rows.Fixed = 1;
			this.grdPreference.Rows.Frozen = 0;
			this.grdPreference.Rows.MaxSize = 0;
			this.grdPreference.Rows.MinSize = 0;
			this.grdPreference.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.grdPreference.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Default;
			// this.grdPreference.ShowButtons = C1.Win.C1FlexGrid.ShowButtonsEnum.WithFocus;
			this.grdPreference.ShowSortPosition = C1.Win.C1FlexGrid.ShowSortPositionEnum.None;
			this.grdPreference.Size = new System.Drawing.Size(793, 417);
			this.grdPreference.Styles.Alternate.BackColor = System.Drawing.SystemColors.Window;
			this.grdPreference.Styles.EmptyArea.BackColor = System.Drawing.SystemColors.AppWorkspace;
			this.grdPreference.Styles.Fixed.BackColor = System.Drawing.Color.FromArgb(123, 136, 119);
			this.grdPreference.Styles.Fixed.Border.Color = System.Drawing.SystemColors.ControlDark;
			this.grdPreference.Styles.Fixed.Border.Direction = C1.Win.C1FlexGrid.BorderDirEnum.Both;
			this.grdPreference.Styles.Fixed.Border.Style = C1.Win.C1FlexGrid.BorderStyleEnum.Inset;
			this.grdPreference.Styles.Fixed.ForeColor = System.Drawing.Color.White;
			this.grdPreference.Styles.Fixed.TextEffect = C1.Win.C1FlexGrid.TextEffectEnum.Flat;
			this.grdPreference.Styles.Frozen.BackColor = System.Drawing.Color.Black;
			this.grdPreference.Styles.Frozen.ForeColor = System.Drawing.Color.Black;
			this.grdPreference.Styles.Highlight.BackColor = System.Drawing.SystemColors.Highlight;
			this.grdPreference.Styles.Highlight.ForeColor = System.Drawing.SystemColors.HighlightText;
			this.grdPreference.Styles.Normal.Border.Color = System.Drawing.Color.Silver;
			this.grdPreference.Styles.Normal.Border.Direction = C1.Win.C1FlexGrid.BorderDirEnum.Both;
			this.grdPreference.Styles.Normal.Border.Style = C1.Win.C1FlexGrid.BorderStyleEnum.Flat;
			this.grdPreference.Styles.Normal.Border.Width = 1;
			this.grdPreference.Styles.Normal.ImageAlign = C1.Win.C1FlexGrid.ImageAlignEnum.Stretch;
			this.grdPreference.Styles.Normal.TextEffect = C1.Win.C1FlexGrid.TextEffectEnum.Flat;
			this.grdPreference.Styles.Normal.Trimming = System.Drawing.StringTrimming.None;
			this.grdPreference.Styles.Normal.WordWrap = false;
			this.grdPreference.Styles[C1.Win.C1FlexGrid.CellStyleEnum.EmptyArea].Border.Color = System.Drawing.SystemColors.WindowFrame;
			this.grdPreference.SubtotalPosition = C1.Win.C1FlexGrid.SubtotalPositionEnum.AboveData;
			this.grdPreference.TabIndex = 0;
			this.grdPreference.Tree.Column = 0;
			this.grdPreference.Tree.LineColor = System.Drawing.SystemColors.ControlDark;
			this.grdPreference.Tree.Style = C1.Win.C1FlexGrid.TreeStyleFlags.None;
			this.grdPreference.AfterRowColChange += new C1.Win.C1FlexGrid.RangeEventHandler(this.grdPreference_AfterRowColChange);
			this.grdPreference.AfterScroll += new C1.Win.C1FlexGrid.RangeEventHandler(this.grdPreference_AfterScroll);
			this.grdPreference.BeforeEdit += new C1.Win.C1FlexGrid.RowColEventHandler(this.grdPreference_BeforeEdit);
			this.grdPreference.BeforeResizeColumn += new C1.Win.C1FlexGrid.RowColEventHandler(this.grdPreference_BeforeResizeColumn);
			this.grdPreference.KeyPressEdit += new C1.Win.C1FlexGrid.KeyPressEditEventHandler(this.grdPreference_KeyPressEdit);
			this.grdPreference.StartEdit += new C1.Win.C1FlexGrid.RowColEventHandler(this.grdPreference_StartEdit);
			// 
			// UCStatusBar
			// 
			this.UCStatusBar.AllowDrop = true;
			this.UCStatusBar.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.UCStatusBar.Location = new System.Drawing.Point(0, 491);
			this.UCStatusBar.Name = "UCStatusBar";
			this.UCStatusBar.Size = new System.Drawing.Size(812, 27);
			this.UCStatusBar.TabIndex = 3;
			// 
			// frmSysPreferencesNew
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.ClientSize = new System.Drawing.Size(812, 518);
			this.Controls.Add(this.cmbPreferenceDataList);
			this.Controls.Add(this.txtRemarks);
			this.Controls.Add(this.grdPreference);
			this.Controls.Add(this.UCStatusBar);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			//this.Icon = (System.Drawing.Icon) resources.GetObject("frmSysPreferencesNew.Icon");
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(52, 142);
			this.MaximizeBox = true;
			this.MinimizeBox = true;
			this.Name = "frmSysPreferencesNew";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "System Preferences New";
			// this.Activated += new System.EventHandler(this.Form_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
			// this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
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
