
namespace Xtreme
{
	partial class frmGLChartOfAccount
	{

		#region "Upgrade Support "
		private static frmGLChartOfAccount m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmGLChartOfAccount DefInstance
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
		public static frmGLChartOfAccount CreateInstance()
		{
			frmGLChartOfAccount theInstance = new frmGLChartOfAccount();
			
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
		private void Ctx_~virtual_@ControlArray_Item_Opening(object sender, System.ComponentModel.CancelEventArgs e)
		{
			System.Collections.Generic.List<System.Windows.Forms.ToolStripItem> list = new System.Collections.Generic.List<System.Windows.Forms.ToolStripItem>();
			Ctx_~virtual_@ControlArray_Item.Items.Clear();
			//We are moving the submenus from original menu to the context menu before displaying it
			foreach (System.Windows.Forms.ToolStripItem item in mnuChartOfAccount[0].DropDownItems)
			{
				list.Add(item);
			}
			foreach (System.Windows.Forms.ToolStripItem item in list)
			{
				Ctx_~virtual_@ControlArray_Item.Items.Add(item);
			}
			e.Cancel = false;
		}
		private void Ctx_~virtual_@ControlArray_Item_Closed(object sender, System.Windows.Forms.ToolStripDropDownClosedEventArgs e)
		{
			System.Collections.Generic.List<System.Windows.Forms.ToolStripItem> list = new System.Collections.Generic.List<System.Windows.Forms.ToolStripItem>();
			//We are moving the submenus the context menu back to the original menu after displaying
			foreach (System.Windows.Forms.ToolStripItem item in Ctx_~virtual_@ControlArray_Item.Items)
			{
				list.Add(item);
			}
			foreach (System.Windows.Forms.ToolStripItem item in list)
			{
				mnuChartOfAccount[0].DropDownItems.Add(item);
			}
		}
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "_mnuChartOfAccount1_0", "_mnuChartOfAccount1_1", "_mnuChartOfAccount1_2", "_mnuChartOfAccount1_3", "_mnuChartOfAccount1_4", "_mnuChartOfAccount_0", "MainMenu1", "fg", "ImgOpenFolder", "imgFolder", "mnuChartOfAccount", "mnuChartOfAccount1", "Ctx_~virtual_@ControlArray_Item"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		private System.Windows.Forms.ToolStripMenuItem _mnuChartOfAccount1_0;
		private System.Windows.Forms.ToolStripMenuItem _mnuChartOfAccount1_1;
		private System.Windows.Forms.ToolStripSeparator _mnuChartOfAccount1_2;
		private System.Windows.Forms.ToolStripMenuItem _mnuChartOfAccount1_3;
		private System.Windows.Forms.ToolStripMenuItem _mnuChartOfAccount1_4;
		private System.Windows.Forms.ToolStripMenuItem _mnuChartOfAccount_0;
		public System.Windows.Forms.MenuStrip MainMenu1;
		public C1.Win.C1FlexGrid.C1FlexGrid fg;
		public System.Windows.Forms.PictureBox ImgOpenFolder;
		public System.Windows.Forms.PictureBox imgFolder;
		public System.Windows.Forms.ToolStripItem[] mnuChartOfAccount = new System.Windows.Forms.ToolStripItem[1];
		public System.Windows.Forms.ToolStripItem[] mnuChartOfAccount1 = new System.Windows.Forms.ToolStripItem[5];
		public System.Windows.Forms.ContextMenuStrip Ctx_~virtual_@ControlArray_Item;
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGLChartOfAccount));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this.MainMenu1 = new System.Windows.Forms.MenuStrip();
			this._mnuChartOfAccount_0 = new System.Windows.Forms.ToolStripMenuItem();
			this._mnuChartOfAccount1_0 = new System.Windows.Forms.ToolStripMenuItem();
			this._mnuChartOfAccount1_1 = new System.Windows.Forms.ToolStripMenuItem();
			this._mnuChartOfAccount1_2 = new System.Windows.Forms.ToolStripSeparator();
			this._mnuChartOfAccount1_3 = new System.Windows.Forms.ToolStripMenuItem();
			this._mnuChartOfAccount1_4 = new System.Windows.Forms.ToolStripMenuItem();
			this.fg = new C1.Win.C1FlexGrid.C1FlexGrid();
			this.ImgOpenFolder = new System.Windows.Forms.PictureBox();
			this.imgFolder = new System.Windows.Forms.PictureBox();
			this.SuspendLayout();
			//Ctx_~virtual_@ControlArray_Item
			this.Ctx_~virtual_@ControlArray_Item = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.Ctx_~virtual_@ControlArray_Item.Size = new System.Drawing.Size(153, 26);
			this.Ctx_~virtual_@ControlArray_Item.Opening += new System.ComponentModel.CancelEventHandler(this.Ctx_~virtual_@ControlArray_Item_Opening);
			this.Ctx_~virtual_@ControlArray_Item.Closed += new System.Windows.Forms.ToolStripDropDownClosedEventHandler(this.Ctx_~virtual_@ControlArray_Item_Closed);
			// 
			// MainMenu1
			// 
			this.MainMenu1.Items.AddRange(new System.Windows.Forms.ToolStripItem[]{this._mnuChartOfAccount_0});
			// 
			// _mnuChartOfAccount_0
			// 
			this._mnuChartOfAccount_0.Available = false;
			this._mnuChartOfAccount_0.Checked = false;
			this._mnuChartOfAccount_0.Enabled = true;
			this._mnuChartOfAccount_0.Name = "_mnuChartOfAccount_0";
			this._mnuChartOfAccount_0.Text = "Chart Of Account";
			this._mnuChartOfAccount_0.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[]{this._mnuChartOfAccount1_0, this._mnuChartOfAccount1_1, this._mnuChartOfAccount1_2, this._mnuChartOfAccount1_3, this._mnuChartOfAccount1_4});
			// 
			// _mnuChartOfAccount1_0
			// 
			this._mnuChartOfAccount1_0.Available = true;
			this._mnuChartOfAccount1_0.Checked = false;
			this._mnuChartOfAccount1_0.Enabled = true;
			this._mnuChartOfAccount1_0.Name = "_mnuChartOfAccount1_0";
			this._mnuChartOfAccount1_0.Text = "Insert Account Group";
			// this._mnuChartOfAccount1_0.Click += new System.EventHandler(this.mnuChartOfAccount1_Click);
			// 
			// _mnuChartOfAccount1_1
			// 
			this._mnuChartOfAccount1_1.Available = true;
			this._mnuChartOfAccount1_1.Checked = false;
			this._mnuChartOfAccount1_1.Enabled = true;
			this._mnuChartOfAccount1_1.Name = "_mnuChartOfAccount1_1";
			this._mnuChartOfAccount1_1.Text = "Insert Ledger Master";
			// this._mnuChartOfAccount1_1.Click += new System.EventHandler(this.mnuChartOfAccount1_Click);
			// 
			// _mnuChartOfAccount1_2
			// 
			this._mnuChartOfAccount1_2.AllowDrop = true;
			this._mnuChartOfAccount1_2.Available = true;
			this._mnuChartOfAccount1_2.Enabled = true;
			this._mnuChartOfAccount1_2.Name = "_mnuChartOfAccount1_2";
			// this._mnuChartOfAccount1_2.Click += new System.EventHandler(this.mnuChartOfAccount1_Click);
			// 
			// _mnuChartOfAccount1_3
			// 
			this._mnuChartOfAccount1_3.Available = true;
			this._mnuChartOfAccount1_3.Checked = false;
			this._mnuChartOfAccount1_3.Enabled = true;
			this._mnuChartOfAccount1_3.Name = "_mnuChartOfAccount1_3";
			this._mnuChartOfAccount1_3.Text = "Edit";
			// this._mnuChartOfAccount1_3.Click += new System.EventHandler(this.mnuChartOfAccount1_Click);
			// 
			// _mnuChartOfAccount1_4
			// 
			this._mnuChartOfAccount1_4.Available = true;
			this._mnuChartOfAccount1_4.Checked = false;
			this._mnuChartOfAccount1_4.Enabled = true;
			this._mnuChartOfAccount1_4.Name = "_mnuChartOfAccount1_4";
			this._mnuChartOfAccount1_4.Text = "Cancel";
			// this._mnuChartOfAccount1_4.Click += new System.EventHandler(this.mnuChartOfAccount1_Click);
			// 
			// fg
			// 
			this.fg.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None;
			this.fg.AllowDrop = true;
			this.fg.AllowEditing = false;
			this.fg.AllowFreezing = C1.Win.C1FlexGrid.AllowFreezingEnum.None;
			this.fg.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.None;
			this.fg.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.None;
			this.fg.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.Columns;
			this.fg.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;
			this.fg.AutoResize = true;
			this.fg.AutoSearch = C1.Win.C1FlexGrid.AutoSearchEnum.None;
			this.fg.AutoSearchDelay = 2;
			this.fg.BackColor = System.Drawing.SystemColors.Window;
			this.fg.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.Fixed3D;
			this.fg.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.Fixed3D;
			this.fg.Cols.Count = 10;
			this.fg.Cols.Fixed = 1;
			this.fg.Cols.Frozen = 0;
			this.fg.Cols.MaxSize = 0;
			this.fg.Cols.MinSize = 0;
			this.fg.Cursor = System.Windows.Forms.Cursors.Default;
			this.fg.DrawMode = C1.Win.C1FlexGrid.DrawModeEnum.Normal;
			this.fg.Enabled = true;
			this.fg.ExtendLastCol = false;
			this.fg.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.Light;
			this.fg.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 178);
			this.fg.ForeColor = System.Drawing.SystemColors.WindowText;
			this.fg.HighLight = C1.Win.C1FlexGrid.HighLightEnum.Always;
			this.fg.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.None;
			this.fg.Location = new System.Drawing.Point(4, 48);
			this.fg.Name = "fg";
			this.fg.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.fg.Rows.Count = 50;
			this.fg.Rows.Fixed = 1;
			this.fg.Rows.Frozen = 0;
			this.fg.Rows.MaxSize = 0;
			this.fg.Rows.MinSize = 0;
			this.fg.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.fg.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Default;
			// this.fg.ShowButtons = C1.Win.C1FlexGrid.ShowButtonsEnum.WithFocus;
			this.fg.ShowSortPosition = C1.Win.C1FlexGrid.ShowSortPositionEnum.None;
			this.fg.Size = new System.Drawing.Size(789, 605);
			this.fg.Styles.Alternate.BackColor = System.Drawing.SystemColors.Window;
			this.fg.Styles.EmptyArea.BackColor = System.Drawing.SystemColors.AppWorkspace;
			this.fg.Styles.Fixed.BackColor = System.Drawing.SystemColors.Control;
			this.fg.Styles.Fixed.Border.Color = System.Drawing.SystemColors.ControlDark;
			this.fg.Styles.Fixed.Border.Direction = C1.Win.C1FlexGrid.BorderDirEnum.Both;
			this.fg.Styles.Fixed.Border.Style = C1.Win.C1FlexGrid.BorderStyleEnum.Inset;
			this.fg.Styles.Fixed.ForeColor = System.Drawing.SystemColors.ControlText;
			this.fg.Styles.Fixed.TextEffect = C1.Win.C1FlexGrid.TextEffectEnum.Flat;
			this.fg.Styles.Frozen.BackColor = System.Drawing.Color.Black;
			this.fg.Styles.Frozen.ForeColor = System.Drawing.Color.Black;
			this.fg.Styles.Highlight.BackColor = System.Drawing.SystemColors.Highlight;
			this.fg.Styles.Highlight.ForeColor = System.Drawing.SystemColors.HighlightText;
			this.fg.Styles.Normal.Border.Color = System.Drawing.SystemColors.Control;
			this.fg.Styles.Normal.Border.Direction = C1.Win.C1FlexGrid.BorderDirEnum.Both;
			this.fg.Styles.Normal.Border.Style = C1.Win.C1FlexGrid.BorderStyleEnum.Flat;
			this.fg.Styles.Normal.Border.Width = 1;
			this.fg.Styles.Normal.ImageAlign = C1.Win.C1FlexGrid.ImageAlignEnum.Stretch;
			this.fg.Styles.Normal.TextEffect = C1.Win.C1FlexGrid.TextEffectEnum.Flat;
			this.fg.Styles.Normal.Trimming = System.Drawing.StringTrimming.None;
			this.fg.Styles.Normal.WordWrap = false;
			this.fg.Styles[C1.Win.C1FlexGrid.CellStyleEnum.EmptyArea].Border.Color = System.Drawing.SystemColors.WindowFrame;
			this.fg.SubtotalPosition = C1.Win.C1FlexGrid.SubtotalPositionEnum.AboveData;
			this.fg.TabIndex = 0;
			this.fg.Tree.Column = 0;
			this.fg.Tree.LineColor = System.Drawing.SystemColors.ControlDark;
			this.fg.Tree.Style = C1.Win.C1FlexGrid.TreeStyleFlags.None;
			// this.this.fg.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fg_KeyDown);
			this.fg.KeyUp += new System.Windows.Forms.KeyEventHandler(this.fg_KeyUp);
			this.fg.MouseDown += new System.Windows.Forms.MouseEventHandler(this.fg_MouseDown);
			this.fg.MouseMove += new System.Windows.Forms.MouseEventHandler(this.fg_MouseMove);
			this.fg.MouseUp += new System.Windows.Forms.MouseEventHandler(this.fg_MouseUp);
			this.fg.RowColChange += new System.EventHandler(this.fg_RowColChange);
			this.fg.SelChange += new System.EventHandler(this.fg_SelChange);
			// 
			// ImgOpenFolder
			// 
			this.ImgOpenFolder.AllowDrop = true;
			this.ImgOpenFolder.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.ImgOpenFolder.Enabled = true;
			//this.ImgOpenFolder.Image = (System.Drawing.Image) resources.GetObject("ImgOpenFolder.Image");
			this.ImgOpenFolder.Location = new System.Drawing.Point(118, 72);
			this.ImgOpenFolder.Name = "ImgOpenFolder";
			this.ImgOpenFolder.Size = new System.Drawing.Size(16, 16);
			this.ImgOpenFolder.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal;
			this.ImgOpenFolder.Visible = true;
			// 
			// imgFolder
			// 
			this.imgFolder.AllowDrop = true;
			this.imgFolder.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.imgFolder.Enabled = true;
			//this.imgFolder.Image = (System.Drawing.Image) resources.GetObject("imgFolder.Image");
			this.imgFolder.Location = new System.Drawing.Point(2, 48);
			this.imgFolder.Name = "imgFolder";
			this.imgFolder.Size = new System.Drawing.Size(16, 16);
			this.imgFolder.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal;
			this.imgFolder.Visible = false;
			// 
			// frmGLChartOfAccount
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.ClientSize = new System.Drawing.Size(1103, 655);
			this.Controls.Add(this.fg);
			this.Controls.Add(this.ImgOpenFolder);
			this.Controls.Add(this.imgFolder);
			this.Controls.Add(MainMenu1);
			//this.Icon = (System.Drawing.Icon) resources.GetObject("frmGLChartOfAccount.Icon");
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(173, 190);
			this.MaximizeBox = true;
			this.MinimizeBox = true;
			this.Name = "frmGLChartOfAccount";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Ledger Accounts";
			// this.Activated += new System.EventHandler(this.frmGLChartOfAccount_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
			// this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
			this.ResumeLayout(false);
		}
		void ReLoadForm(bool addEvents)
		{
			InitializemnuChartOfAccount1();
			InitializemnuChartOfAccount();
			//This form is an MDI child.
			//This code simulates the VB6 
			// functionality of automatically
			// loading and showing an MDI
			// child's parent.
			this.MdiParent = Xtreme.frmSysMain.DefInstance;
			Xtreme.frmSysMain.DefInstance.Show();
		}
		void InitializemnuChartOfAccount1()
		{
			this.mnuChartOfAccount1 = new System.Windows.Forms.ToolStripItem[5];
			this.mnuChartOfAccount1[0] = _mnuChartOfAccount1_0;
			this.mnuChartOfAccount1[1] = _mnuChartOfAccount1_1;
			this.mnuChartOfAccount1[2] = _mnuChartOfAccount1_2;
			this.mnuChartOfAccount1[3] = _mnuChartOfAccount1_3;
			this.mnuChartOfAccount1[4] = _mnuChartOfAccount1_4;
		}
		void InitializemnuChartOfAccount()
		{
			this.mnuChartOfAccount = new System.Windows.Forms.ToolStripItem[1];
			this.mnuChartOfAccount[0] = _mnuChartOfAccount_0;
		}
		#endregion
	}
}//ENDSHERE
