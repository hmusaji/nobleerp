
namespace Xtreme
{
	partial class frmICSProductListingSelection
	{

		#region "Upgrade Support "
		private static frmICSProductListingSelection m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmICSProductListingSelection DefInstance
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
		public static frmICSProductListingSelection CreateInstance()
		{
			frmICSProductListingSelection theInstance = new frmICSProductListingSelection();
			
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
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "oReportGrid", "txtPrice", "txtPriceName", "lblPriceList"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public C1.Win.C1FlexGrid.C1FlexGrid oReportGrid;
		public System.Windows.Forms.TextBox txtPrice;
		public System.Windows.Forms.TextBox txtPriceName;
		public System.Windows.Forms.Label lblPriceList;
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmICSProductListingSelection));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this.oReportGrid = new C1.Win.C1FlexGrid.C1FlexGrid();
			this.txtPrice = new System.Windows.Forms.TextBox();
			this.txtPriceName = new System.Windows.Forms.TextBox();
			this.lblPriceList = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// oReportGrid
			// 
			this.oReportGrid.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None;
			this.oReportGrid.AllowDrop = true;
			this.oReportGrid.AllowEditing = false;
			this.oReportGrid.AllowFreezing = C1.Win.C1FlexGrid.AllowFreezingEnum.None;
			this.oReportGrid.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.None;
			this.oReportGrid.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.None;
			this.oReportGrid.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.Columns;
			this.oReportGrid.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;
			this.oReportGrid.AutoResize = true;
			this.oReportGrid.AutoSearch = C1.Win.C1FlexGrid.AutoSearchEnum.None;
			this.oReportGrid.AutoSearchDelay = 2;
			this.oReportGrid.BackColor = System.Drawing.SystemColors.Window;
			this.oReportGrid.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle;
			this.oReportGrid.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.Fixed3D;
			this.oReportGrid.Cols.Count = 10;
			this.oReportGrid.Cols.Fixed = 1;
			this.oReportGrid.Cols.Frozen = 0;
			this.oReportGrid.Cols.MaxSize = 0;
			this.oReportGrid.Cols.MinSize = 0;
			this.oReportGrid.Cursor = System.Windows.Forms.Cursors.Default;
			this.oReportGrid.DrawMode = C1.Win.C1FlexGrid.DrawModeEnum.Normal;
			this.oReportGrid.Enabled = true;
			this.oReportGrid.ExtendLastCol = false;
			this.oReportGrid.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.Light;
			this.oReportGrid.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 178);
			this.oReportGrid.ForeColor = System.Drawing.SystemColors.WindowText;
			this.oReportGrid.HighLight = C1.Win.C1FlexGrid.HighLightEnum.Always;
			this.oReportGrid.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.None;
			this.oReportGrid.Location = new System.Drawing.Point(0, 68);
			this.oReportGrid.Name = "oReportGrid";
			this.oReportGrid.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.oReportGrid.Rows.Count = 50;
			this.oReportGrid.Rows.Fixed = 1;
			this.oReportGrid.Rows.Frozen = 0;
			this.oReportGrid.Rows.MaxSize = 0;
			this.oReportGrid.Rows.MinSize = 0;
			this.oReportGrid.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.oReportGrid.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Default;
			// this.oReportGrid.ShowButtons = C1.Win.C1FlexGrid.ShowButtonsEnum.WithFocus;
			this.oReportGrid.ShowSortPosition = C1.Win.C1FlexGrid.ShowSortPositionEnum.None;
			this.oReportGrid.Size = new System.Drawing.Size(545, 385);
			this.oReportGrid.Styles.Alternate.BackColor = System.Drawing.SystemColors.Window;
			this.oReportGrid.Styles.EmptyArea.BackColor = System.Drawing.SystemColors.AppWorkspace;
			this.oReportGrid.Styles.Fixed.BackColor = System.Drawing.SystemColors.Control;
			this.oReportGrid.Styles.Fixed.Border.Color = System.Drawing.SystemColors.ControlDark;
			this.oReportGrid.Styles.Fixed.Border.Direction = C1.Win.C1FlexGrid.BorderDirEnum.Both;
			this.oReportGrid.Styles.Fixed.Border.Style = C1.Win.C1FlexGrid.BorderStyleEnum.Inset;
			this.oReportGrid.Styles.Fixed.ForeColor = System.Drawing.SystemColors.ControlText;
			this.oReportGrid.Styles.Fixed.TextEffect = C1.Win.C1FlexGrid.TextEffectEnum.Flat;
			this.oReportGrid.Styles.Frozen.BackColor = System.Drawing.Color.Black;
			this.oReportGrid.Styles.Frozen.ForeColor = System.Drawing.Color.Black;
			this.oReportGrid.Styles.Highlight.BackColor = System.Drawing.SystemColors.Highlight;
			this.oReportGrid.Styles.Highlight.ForeColor = System.Drawing.SystemColors.HighlightText;
			this.oReportGrid.Styles.Normal.Border.Color = System.Drawing.SystemColors.Control;
			this.oReportGrid.Styles.Normal.Border.Direction = C1.Win.C1FlexGrid.BorderDirEnum.Both;
			this.oReportGrid.Styles.Normal.Border.Style = C1.Win.C1FlexGrid.BorderStyleEnum.Flat;
			this.oReportGrid.Styles.Normal.Border.Width = 1;
			this.oReportGrid.Styles.Normal.ImageAlign = C1.Win.C1FlexGrid.ImageAlignEnum.Stretch;
			this.oReportGrid.Styles.Normal.TextEffect = C1.Win.C1FlexGrid.TextEffectEnum.Flat;
			this.oReportGrid.Styles.Normal.Trimming = System.Drawing.StringTrimming.None;
			this.oReportGrid.Styles.Normal.WordWrap = false;
			this.oReportGrid.Styles[C1.Win.C1FlexGrid.CellStyleEnum.EmptyArea].Border.Color = System.Drawing.SystemColors.WindowFrame;
			this.oReportGrid.SubtotalPosition = C1.Win.C1FlexGrid.SubtotalPositionEnum.AboveData;
			this.oReportGrid.TabIndex = 0;
			this.oReportGrid.Tree.Column = 0;
			this.oReportGrid.Tree.LineColor = System.Drawing.SystemColors.ControlDark;
			this.oReportGrid.Tree.Style = C1.Win.C1FlexGrid.TreeStyleFlags.None;
			// 
			// txtPrice
			// 
			this.txtPrice.AllowDrop = true;
			this.txtPrice.BackColor = System.Drawing.Color.White;
			// this.txtPrice.bolNumericOnly = true;
			this.txtPrice.ForeColor = System.Drawing.Color.Black;
			this.txtPrice.Location = new System.Drawing.Point(54, 26);
			this.txtPrice.MaxLength = 15;
			this.txtPrice.Name = "txtPrice";
			// this.txtPrice.ShowButton = true;
			this.txtPrice.Size = new System.Drawing.Size(101, 19);
			this.txtPrice.TabIndex = 1;
			this.txtPrice.Text = "";
			// this.this.txtPrice.Watermark = "";
			// this.this.txtPrice.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtPrice_DropButtonClick);
			// this.txtPrice.Leave += new System.EventHandler(this.txtPrice_Leave);
			// 
			// txtPriceName
			// 
			this.txtPriceName.AllowDrop = true;
			this.txtPriceName.BackColor = System.Drawing.Color.FromArgb(239, 239, 239);
			this.txtPriceName.Enabled = false;
			this.txtPriceName.ForeColor = System.Drawing.Color.Black;
			this.txtPriceName.Location = new System.Drawing.Point(157, 26);
			this.txtPriceName.Name = "txtPriceName";
			this.txtPriceName.Size = new System.Drawing.Size(191, 19);
			this.txtPriceName.TabIndex = 2;
			this.txtPriceName.TabStop = false;
			this.txtPriceName.Text = " ";
			// this.this.txtPriceName.Watermark = "";
			// 
			// lblPriceList
			// 
			this.lblPriceList.AllowDrop = true;
			this.lblPriceList.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblPriceList.Text = "Price :";
			this.lblPriceList.ForeColor = System.Drawing.Color.Black;
			this.lblPriceList.Location = new System.Drawing.Point(6, 30);
			// // this.lblPriceList.mLabelId = 504;
			this.lblPriceList.Name = "lblPriceList";
			this.lblPriceList.Size = new System.Drawing.Size(30, 14);
			this.lblPriceList.TabIndex = 3;
			// 
			// frmICSProductListingSelection
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.ClientSize = new System.Drawing.Size(548, 454);
			this.Controls.Add(this.oReportGrid);
			this.Controls.Add(this.txtPrice);
			this.Controls.Add(this.txtPriceName);
			this.Controls.Add(this.lblPriceList);
			//this.Icon = (System.Drawing.Icon) resources.GetObject("frmICSProductListingSelection.Icon");
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(492, 198);
			this.MaximizeBox = true;
			this.MinimizeBox = true;
			this.Name = "frmICSProductListingSelection";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Product Listing";
			// this.Activated += new System.EventHandler(this.frmICSProductListingSelection_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
			// this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
			this.ResumeLayout(false);
		}
		// 
		#endregion
	}
}//ENDSHERE
