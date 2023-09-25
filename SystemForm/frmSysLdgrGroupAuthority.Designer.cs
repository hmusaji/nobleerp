
namespace Xtreme
{
	partial class frmSysLdgrGroupAuthority
	{

		#region "Upgrade Support "
		private static frmSysLdgrGroupAuthority m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmSysLdgrGroupAuthority DefInstance
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
		public static frmSysLdgrGroupAuthority CreateInstance()
		{
			frmSysLdgrGroupAuthority theInstance = new frmSysLdgrGroupAuthority();
			
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
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "lblLedgerCode", "txtGroupCode", "lblGroup", "grdUserGroups", "lblGroupName", "Line1", "cntOuterFrame", "tcbSystemForm"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public System.Windows.Forms.Label lblLedgerCode;
		public System.Windows.Forms.TextBox txtGroupCode;
		public System.Windows.Forms.Label lblGroup;
		public C1.Win.C1FlexGrid.C1FlexGrid grdUserGroups;
		public System.Windows.Forms.Label lblGroupName;
		public System.Windows.Forms.Label Line1;
		public AxC1SizerLib.AxC1Elastic cntOuterFrame;
		public Syncfusion.Windows.Forms.Tools.CommandBarController tcbSystemForm;
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSysLdgrGroupAuthority));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this.cntOuterFrame = new AxC1SizerLib.AxC1Elastic();
			this.lblLedgerCode = new System.Windows.Forms.Label();
			this.txtGroupCode = new System.Windows.Forms.TextBox();
			this.lblGroup = new System.Windows.Forms.Label();
			this.grdUserGroups = new C1.Win.C1FlexGrid.C1FlexGrid();
			this.lblGroupName = new System.Windows.Forms.Label();
			this.Line1 = new System.Windows.Forms.Label();
			this.tcbSystemForm = new Syncfusion.Windows.Forms.Tools.CommandBarController();
			// //((System.ComponentModel.ISupportInitialize) this.cntOuterFrame).BeginInit();
			// //((System.ComponentModel.ISupportInitialize) this.tcbSystemForm).BeginInit();
			this.cntOuterFrame.SuspendLayout();
			this.SuspendLayout();
			// 
			// cntOuterFrame
			// 
			this.cntOuterFrame.Align = C1SizerLib.AlignSettings.asNone;
			this.cntOuterFrame.AllowDrop = true;
			this.cntOuterFrame.Controls.Add(this.lblLedgerCode);
			this.cntOuterFrame.Controls.Add(this.txtGroupCode);
			this.cntOuterFrame.Controls.Add(this.lblGroup);
			this.cntOuterFrame.Controls.Add(this.grdUserGroups);
			this.cntOuterFrame.Controls.Add(this.lblGroupName);
			this.cntOuterFrame.Controls.Add(this.Line1);
			this.cntOuterFrame.Location = new System.Drawing.Point(0, 38);
			this.cntOuterFrame.Name = "cntOuterFrame";
			("cntOuterFrame.OcxState");
			this.cntOuterFrame.Size = new System.Drawing.Size(607, 493);
			this.cntOuterFrame.TabIndex = 0;
			this.cntOuterFrame.TabStop = false;
			// 
			// lblLedgerCode
			// 
			this.lblLedgerCode.AllowDrop = true;
			this.lblLedgerCode.BackColor = System.Drawing.SystemColors.Window;
			this.lblLedgerCode.Text = " Rights on Ledger Codes";
			this.lblLedgerCode.Location = new System.Drawing.Point(12, 42);
			this.lblLedgerCode.Name = "lblLedgerCode";
			this.lblLedgerCode.Size = new System.Drawing.Size(135, 13);
			this.lblLedgerCode.TabIndex = 1;
			// 
			// txtGroupCode
			// 
			this.txtGroupCode.AllowDrop = true;
			this.txtGroupCode.BackColor = System.Drawing.Color.White;
			this.txtGroupCode.ForeColor = System.Drawing.Color.Black;
			this.txtGroupCode.Location = new System.Drawing.Point(100, 14);
			this.txtGroupCode.MaxLength = 50;
			this.txtGroupCode.Name = "txtGroupCode";
			// this.txtGroupCode.ShowButton = true;
			this.txtGroupCode.Size = new System.Drawing.Size(103, 19);
			this.txtGroupCode.TabIndex = 2;
			this.txtGroupCode.Text = "";
			// this.this.txtGroupCode.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtGroupCode_DropButtonClick);
			// this.txtGroupCode.Leave += new System.EventHandler(this.txtGroupCode_Leave);
			// 
			// lblGroup
			// 
			this.lblGroup.AllowDrop = true;
			this.lblGroup.BackColor = System.Drawing.SystemColors.Window;
			this.lblGroup.Text = "Group Code";
			this.lblGroup.Location = new System.Drawing.Point(20, 17);
			this.lblGroup.Name = "lblGroup";
			this.lblGroup.Size = new System.Drawing.Size(58, 14);
			this.lblGroup.TabIndex = 3;
			// 
			// grdUserGroups
			// 
			this.grdUserGroups.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None;
			this.grdUserGroups.AllowDrop = true;
			this.grdUserGroups.AllowEditing = false;
			this.grdUserGroups.AllowFreezing = C1.Win.C1FlexGrid.AllowFreezingEnum.None;
			this.grdUserGroups.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.None;
			this.grdUserGroups.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.None;
			this.grdUserGroups.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.Columns;
			this.grdUserGroups.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;
			this.grdUserGroups.AutoResize = true;
			this.grdUserGroups.AutoSearch = C1.Win.C1FlexGrid.AutoSearchEnum.None;
			this.grdUserGroups.AutoSearchDelay = 2;
			this.grdUserGroups.BackColor = System.Drawing.SystemColors.Window;
			this.grdUserGroups.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.Fixed3D;
			this.grdUserGroups.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.Fixed3D;
			this.grdUserGroups.Cols.Count = 6;
			this.grdUserGroups.Cols.Fixed = 1;
			this.grdUserGroups.Cols.Frozen = 0;
			this.grdUserGroups.Cols.MaxSize = 0;
			this.grdUserGroups.Cols.MinSize = 0;
			this.grdUserGroups.Cursor = System.Windows.Forms.Cursors.Default;
			this.grdUserGroups.DrawMode = C1.Win.C1FlexGrid.DrawModeEnum.Normal;
			this.grdUserGroups.Enabled = true;
			this.grdUserGroups.ExtendLastCol = false;
			this.grdUserGroups.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.Light;
			this.grdUserGroups.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 178);
			this.grdUserGroups.ForeColor = System.Drawing.SystemColors.WindowText;
			this.grdUserGroups.HighLight = C1.Win.C1FlexGrid.HighLightEnum.Always;
			this.grdUserGroups.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.None;
			this.grdUserGroups.Location = new System.Drawing.Point(8, 64);
			this.grdUserGroups.Name = "grdUserGroups";
			this.grdUserGroups.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.grdUserGroups.Rows.Count = 50;
			this.grdUserGroups.Rows.Fixed = 1;
			this.grdUserGroups.Rows.Frozen = 0;
			this.grdUserGroups.Rows.MaxSize = 0;
			this.grdUserGroups.Rows.MinSize = 0;
			this.grdUserGroups.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.grdUserGroups.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Default;
			// this.grdUserGroups.ShowButtons = C1.Win.C1FlexGrid.ShowButtonsEnum.WithFocus;
			this.grdUserGroups.ShowSortPosition = C1.Win.C1FlexGrid.ShowSortPositionEnum.None;
			this.grdUserGroups.Size = new System.Drawing.Size(591, 225);
			this.grdUserGroups.Styles.Alternate.BackColor = System.Drawing.SystemColors.Window;
			this.grdUserGroups.Styles.EmptyArea.BackColor = System.Drawing.SystemColors.AppWorkspace;
			this.grdUserGroups.Styles.Fixed.BackColor = System.Drawing.SystemColors.Control;
			this.grdUserGroups.Styles.Fixed.Border.Color = System.Drawing.SystemColors.ControlDark;
			this.grdUserGroups.Styles.Fixed.Border.Direction = C1.Win.C1FlexGrid.BorderDirEnum.Both;
			this.grdUserGroups.Styles.Fixed.Border.Style = C1.Win.C1FlexGrid.BorderStyleEnum.Inset;
			this.grdUserGroups.Styles.Fixed.ForeColor = System.Drawing.SystemColors.ControlText;
			this.grdUserGroups.Styles.Fixed.TextEffect = C1.Win.C1FlexGrid.TextEffectEnum.Flat;
			this.grdUserGroups.Styles.Frozen.BackColor = System.Drawing.Color.Black;
			this.grdUserGroups.Styles.Frozen.ForeColor = System.Drawing.Color.Black;
			this.grdUserGroups.Styles.Highlight.BackColor = System.Drawing.SystemColors.Highlight;
			this.grdUserGroups.Styles.Highlight.ForeColor = System.Drawing.SystemColors.HighlightText;
			this.grdUserGroups.Styles.Normal.Border.Color = System.Drawing.SystemColors.Control;
			this.grdUserGroups.Styles.Normal.Border.Direction = C1.Win.C1FlexGrid.BorderDirEnum.Both;
			this.grdUserGroups.Styles.Normal.Border.Style = C1.Win.C1FlexGrid.BorderStyleEnum.Flat;
			this.grdUserGroups.Styles.Normal.Border.Width = 1;
			this.grdUserGroups.Styles.Normal.ImageAlign = C1.Win.C1FlexGrid.ImageAlignEnum.Stretch;
			this.grdUserGroups.Styles.Normal.TextEffect = C1.Win.C1FlexGrid.TextEffectEnum.Flat;
			this.grdUserGroups.Styles.Normal.Trimming = System.Drawing.StringTrimming.None;
			this.grdUserGroups.Styles.Normal.WordWrap = false;
			this.grdUserGroups.Styles[C1.Win.C1FlexGrid.CellStyleEnum.EmptyArea].Border.Color = System.Drawing.SystemColors.WindowFrame;
			this.grdUserGroups.SubtotalPosition = C1.Win.C1FlexGrid.SubtotalPositionEnum.AboveData;
			this.grdUserGroups.TabIndex = 5;
			this.grdUserGroups.Tree.Column = 0;
			this.grdUserGroups.Tree.LineColor = System.Drawing.SystemColors.ControlDark;
			this.grdUserGroups.Tree.Style = C1.Win.C1FlexGrid.TreeStyleFlags.None;
			this.grdUserGroups.BeforeEdit += new C1.Win.C1FlexGrid.RowColEventHandler(this.grdUserGroups_BeforeEdit);
			// this.this.grdUserGroups.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.grdUserGroups_KeyPress);
			this.grdUserGroups.KeyPressEdit += new C1.Win.C1FlexGrid.KeyPressEditEventHandler(this.grdUserGroups_KeyPressEdit);
			// 
			// lblGroupName
			// 
			this.lblGroupName.AllowDrop = true;
			this.lblGroupName.BackColor = System.Drawing.Color.FromArgb(236, 213, 196);
			this.lblGroupName.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lblGroupName.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblGroupName.Location = new System.Drawing.Point(210, 14);
			this.lblGroupName.Name = "lblGroupName";
			this.lblGroupName.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblGroupName.Size = new System.Drawing.Size(209, 19);
			this.lblGroupName.TabIndex = 4;
			// 
			// Line1
			// 
			this.Line1.AllowDrop = true;
			this.Line1.BackColor = System.Drawing.SystemColors.WindowText;
			this.Line1.Enabled = false;
			this.Line1.Location = new System.Drawing.Point(0, 48);
			this.Line1.Name = "Line1";
			this.Line1.Size = new System.Drawing.Size(736, 1);
			this.Line1.Visible = true;
			// 
			// tcbSystemForm
			// 
			this.tcbSystemForm.AllowDrop = true;
			this.tcbSystemForm.Location = new System.Drawing.Point(0, 0);
			this.tcbSystemForm.Name = "tcbSystemForm";
			("tcbSystemForm.OcxState");
			// 
			// frmSysLdgrGroupAuthority
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.SystemColors.Control;
			this.ClientSize = new System.Drawing.Size(609, 339);
			this.Controls.Add(this.cntOuterFrame);
			this.Controls.Add(this.tcbSystemForm);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			//this.Icon = (System.Drawing.Icon) resources.GetObject("frmSysLdgrGroupAuthority.Icon");
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(167, 242);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmSysLdgrGroupAuthority";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Ledger Authority";
			// this.Activated += new System.EventHandler(this.frmSysLdgrGroupAuthority_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
			// this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
			//((System.ComponentModel.ISupportInitialize) this.cntOuterFrame).EndInit();
			//((System.ComponentModel.ISupportInitialize) this.tcbSystemForm).EndInit();
			this.cntOuterFrame.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		// 
		#endregion
	}
}//ENDSHERE
