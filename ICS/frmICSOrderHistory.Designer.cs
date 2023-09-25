
namespace Xtreme
{
	partial class frmICSOrderHistory
	{

		#region "Upgrade Support "
		private static frmICSOrderHistory m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmICSOrderHistory DefInstance
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
		public static frmICSOrderHistory CreateInstance()
		{
			frmICSOrderHistory theInstance = new frmICSOrderHistory();
			
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
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "grdPurchase", "grdSales", "grdCustomerEnquiry", "cmbYear", "cmdSearch", "System.Windows.Forms.Label1", "System.Windows.Forms.Label2", "System.Windows.Forms.Label3", "System.Windows.Forms.Label4", "System.Windows.Forms.Label5", "txtRefNo", "txtPONo", "txtSalesInvNo", "txtOffer", "txtOrder", "System.Windows.Forms.Label6", "Frame1"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public C1.Win.C1FlexGrid.C1FlexGrid grdPurchase;
		public C1.Win.C1FlexGrid.C1FlexGrid grdSales;
		public C1.Win.C1FlexGrid.C1FlexGrid grdCustomerEnquiry;
		public System.Windows.Forms.ComboBox cmbYear;
		public System.Windows.Forms.Button cmdSearch;
		public System.Windows.Forms.LabelLabel1;
		public System.Windows.Forms.LabelLabel2;
		public System.Windows.Forms.LabelLabel3;
		public System.Windows.Forms.LabelLabel4;
		public System.Windows.Forms.LabelLabel5;
		public System.Windows.Forms.TextBox txtRefNo;
		public System.Windows.Forms.TextBox txtPONo;
		public System.Windows.Forms.TextBox txtSalesInvNo;
		public System.Windows.Forms.TextBox txtOffer;
		public System.Windows.Forms.TextBox txtOrder;
		public System.Windows.Forms.LabelLabel6;
		public System.Windows.Forms.GroupBox Frame1;
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmICSOrderHistory));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this.grdPurchase = new C1.Win.C1FlexGrid.C1FlexGrid();
			this.grdSales = new C1.Win.C1FlexGrid.C1FlexGrid();
			this.grdCustomerEnquiry = new C1.Win.C1FlexGrid.C1FlexGrid();
			this.Frame1 = new System.Windows.Forms.GroupBox();
			this.cmbYear = new System.Windows.Forms.ComboBox();
			this.cmdSearch = new System.Windows.Forms.Button();
			this.Label1 = new System.Windows.Forms.Label();
			this.Label2 = new System.Windows.Forms.Label();
			this.Label3 = new System.Windows.Forms.Label();
			this.Label4 = new System.Windows.Forms.Label();
			this.Label5 = new System.Windows.Forms.Label();
			this.txtRefNo = new System.Windows.Forms.TextBox();
			this.txtPONo = new System.Windows.Forms.TextBox();
			this.txtSalesInvNo = new System.Windows.Forms.TextBox();
			this.txtOffer = new System.Windows.Forms.TextBox();
			this.txtOrder = new System.Windows.Forms.TextBox();
			this.Label6 = new System.Windows.Forms.Label();
			this.Frame1.SuspendLayout();
			this.SuspendLayout();
			// 
			// grdPurchase
			// 
			this.grdPurchase.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None;
			this.grdPurchase.AllowDrop = true;
			this.grdPurchase.AllowEditing = false;
			this.grdPurchase.AllowFreezing = C1.Win.C1FlexGrid.AllowFreezingEnum.Columns;
			this.grdPurchase.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.None;
			this.grdPurchase.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.Columns;
			this.grdPurchase.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.Columns;
			this.grdPurchase.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;
			this.grdPurchase.AutoResize = true;
			this.grdPurchase.AutoSearch = C1.Win.C1FlexGrid.AutoSearchEnum.None;
			this.grdPurchase.AutoSearchDelay = 2;
			this.grdPurchase.BackColor = System.Drawing.SystemColors.Window;
			this.grdPurchase.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.Fixed3D;
			this.grdPurchase.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.Fixed3D;
			this.grdPurchase.Cols.Count = 1;
			this.grdPurchase.Cols.Fixed = 0;
			this.grdPurchase.Cols.Frozen = 0;
			this.grdPurchase.Cols.MaxSize = 0;
			this.grdPurchase.Cols.MinSize = 0;
			this.grdPurchase.Cursor = System.Windows.Forms.Cursors.Default;
			this.grdPurchase.DrawMode = C1.Win.C1FlexGrid.DrawModeEnum.Normal;
			this.grdPurchase.Enabled = true;
			this.grdPurchase.ExtendLastCol = true;
			this.grdPurchase.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.Light;
			this.grdPurchase.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 178);
			this.grdPurchase.ForeColor = System.Drawing.SystemColors.WindowText;
			this.grdPurchase.HighLight = C1.Win.C1FlexGrid.HighLightEnum.Always;
			this.grdPurchase.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.None;
			this.grdPurchase.Location = new System.Drawing.Point(0, 466);
			this.grdPurchase.Name = "grdPurchase";
			this.grdPurchase.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.grdPurchase.Rows.Count = 2;
			this.grdPurchase.Rows.Fixed = 1;
			this.grdPurchase.Rows.Frozen = 0;
			this.grdPurchase.Rows.MaxSize = 0;
			this.grdPurchase.Rows.MinSize = 0;
			this.grdPurchase.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.grdPurchase.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.ListBox;
			// this.grdPurchase.ShowButtons = C1.Win.C1FlexGrid.ShowButtonsEnum.WithFocus;
			this.grdPurchase.ShowSortPosition = C1.Win.C1FlexGrid.ShowSortPositionEnum.None;
			this.grdPurchase.Size = new System.Drawing.Size(977, 201);
			this.grdPurchase.Styles.Alternate.BackColor = System.Drawing.SystemColors.Window;
			this.grdPurchase.Styles.EmptyArea.BackColor = System.Drawing.SystemColors.AppWorkspace;
			this.grdPurchase.Styles.Fixed.BackColor = System.Drawing.SystemColors.Control;
			this.grdPurchase.Styles.Fixed.Border.Color = System.Drawing.SystemColors.ControlDark;
			this.grdPurchase.Styles.Fixed.Border.Direction = C1.Win.C1FlexGrid.BorderDirEnum.Both;
			this.grdPurchase.Styles.Fixed.Border.Style = C1.Win.C1FlexGrid.BorderStyleEnum.Inset;
			this.grdPurchase.Styles.Fixed.ForeColor = System.Drawing.SystemColors.ControlText;
			this.grdPurchase.Styles.Fixed.TextEffect = C1.Win.C1FlexGrid.TextEffectEnum.Flat;
			this.grdPurchase.Styles.Frozen.BackColor = System.Drawing.Color.Black;
			this.grdPurchase.Styles.Frozen.ForeColor = System.Drawing.Color.Black;
			this.grdPurchase.Styles.Highlight.BackColor = System.Drawing.SystemColors.Highlight;
			this.grdPurchase.Styles.Highlight.ForeColor = System.Drawing.SystemColors.HighlightText;
			this.grdPurchase.Styles.Normal.Border.Color = System.Drawing.SystemColors.Control;
			this.grdPurchase.Styles.Normal.Border.Direction = C1.Win.C1FlexGrid.BorderDirEnum.Both;
			this.grdPurchase.Styles.Normal.Border.Style = C1.Win.C1FlexGrid.BorderStyleEnum.Flat;
			this.grdPurchase.Styles.Normal.Border.Width = 1;
			this.grdPurchase.Styles.Normal.ImageAlign = C1.Win.C1FlexGrid.ImageAlignEnum.Stretch;
			this.grdPurchase.Styles.Normal.TextEffect = C1.Win.C1FlexGrid.TextEffectEnum.Flat;
			this.grdPurchase.Styles.Normal.Trimming = System.Drawing.StringTrimming.None;
			this.grdPurchase.Styles.Normal.WordWrap = false;
			this.grdPurchase.Styles[C1.Win.C1FlexGrid.CellStyleEnum.EmptyArea].Border.Color = System.Drawing.SystemColors.WindowFrame;
			this.grdPurchase.SubtotalPosition = C1.Win.C1FlexGrid.SubtotalPositionEnum.AboveData;
			this.grdPurchase.TabIndex = 4;
			this.grdPurchase.Tree.Column = 0;
			this.grdPurchase.Tree.LineColor = System.Drawing.SystemColors.ControlDark;
			this.grdPurchase.Tree.Style = C1.Win.C1FlexGrid.TreeStyleFlags.None;
			this.grdPurchase.DoubleClick += new System.EventHandler(this.grdPurchase_DoubleClick);
			// 
			// grdSales
			// 
			this.grdSales.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None;
			this.grdSales.AllowDrop = true;
			this.grdSales.AllowEditing = false;
			this.grdSales.AllowFreezing = C1.Win.C1FlexGrid.AllowFreezingEnum.Columns;
			this.grdSales.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.None;
			this.grdSales.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.Columns;
			this.grdSales.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.Columns;
			this.grdSales.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;
			this.grdSales.AutoResize = true;
			this.grdSales.AutoSearch = C1.Win.C1FlexGrid.AutoSearchEnum.None;
			this.grdSales.AutoSearchDelay = 2;
			this.grdSales.BackColor = System.Drawing.SystemColors.Window;
			this.grdSales.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.Fixed3D;
			this.grdSales.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.Fixed3D;
			this.grdSales.Cols.Count = 1;
			this.grdSales.Cols.Fixed = 0;
			this.grdSales.Cols.Frozen = 0;
			this.grdSales.Cols.MaxSize = 0;
			this.grdSales.Cols.MinSize = 0;
			this.grdSales.Cursor = System.Windows.Forms.Cursors.Default;
			this.grdSales.DrawMode = C1.Win.C1FlexGrid.DrawModeEnum.Normal;
			this.grdSales.Enabled = true;
			this.grdSales.ExtendLastCol = true;
			this.grdSales.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.Light;
			this.grdSales.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 178);
			this.grdSales.ForeColor = System.Drawing.SystemColors.WindowText;
			this.grdSales.HighLight = C1.Win.C1FlexGrid.HighLightEnum.Always;
			this.grdSales.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.None;
			this.grdSales.Location = new System.Drawing.Point(0, 273);
			this.grdSales.Name = "grdSales";
			this.grdSales.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.grdSales.Rows.Count = 2;
			this.grdSales.Rows.Fixed = 1;
			this.grdSales.Rows.Frozen = 0;
			this.grdSales.Rows.MaxSize = 0;
			this.grdSales.Rows.MinSize = 0;
			this.grdSales.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.grdSales.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.ListBox;
			// this.grdSales.ShowButtons = C1.Win.C1FlexGrid.ShowButtonsEnum.WithFocus;
			this.grdSales.ShowSortPosition = C1.Win.C1FlexGrid.ShowSortPositionEnum.None;
			this.grdSales.Size = new System.Drawing.Size(977, 188);
			this.grdSales.Styles.Alternate.BackColor = System.Drawing.SystemColors.Window;
			this.grdSales.Styles.EmptyArea.BackColor = System.Drawing.SystemColors.AppWorkspace;
			this.grdSales.Styles.Fixed.BackColor = System.Drawing.SystemColors.Control;
			this.grdSales.Styles.Fixed.Border.Color = System.Drawing.SystemColors.ControlDark;
			this.grdSales.Styles.Fixed.Border.Direction = C1.Win.C1FlexGrid.BorderDirEnum.Both;
			this.grdSales.Styles.Fixed.Border.Style = C1.Win.C1FlexGrid.BorderStyleEnum.Inset;
			this.grdSales.Styles.Fixed.ForeColor = System.Drawing.SystemColors.ControlText;
			this.grdSales.Styles.Fixed.TextEffect = C1.Win.C1FlexGrid.TextEffectEnum.Flat;
			this.grdSales.Styles.Frozen.BackColor = System.Drawing.Color.Black;
			this.grdSales.Styles.Frozen.ForeColor = System.Drawing.Color.Black;
			this.grdSales.Styles.Highlight.BackColor = System.Drawing.SystemColors.Highlight;
			this.grdSales.Styles.Highlight.ForeColor = System.Drawing.SystemColors.HighlightText;
			this.grdSales.Styles.Normal.Border.Color = System.Drawing.SystemColors.Control;
			this.grdSales.Styles.Normal.Border.Direction = C1.Win.C1FlexGrid.BorderDirEnum.Both;
			this.grdSales.Styles.Normal.Border.Style = C1.Win.C1FlexGrid.BorderStyleEnum.Flat;
			this.grdSales.Styles.Normal.Border.Width = 1;
			this.grdSales.Styles.Normal.ImageAlign = C1.Win.C1FlexGrid.ImageAlignEnum.Stretch;
			this.grdSales.Styles.Normal.TextEffect = C1.Win.C1FlexGrid.TextEffectEnum.Flat;
			this.grdSales.Styles.Normal.Trimming = System.Drawing.StringTrimming.None;
			this.grdSales.Styles.Normal.WordWrap = false;
			this.grdSales.Styles[C1.Win.C1FlexGrid.CellStyleEnum.EmptyArea].Border.Color = System.Drawing.SystemColors.WindowFrame;
			this.grdSales.SubtotalPosition = C1.Win.C1FlexGrid.SubtotalPositionEnum.AboveData;
			this.grdSales.TabIndex = 3;
			this.grdSales.Tree.Column = 0;
			this.grdSales.Tree.LineColor = System.Drawing.SystemColors.ControlDark;
			this.grdSales.Tree.Style = C1.Win.C1FlexGrid.TreeStyleFlags.None;
			this.grdSales.DoubleClick += new System.EventHandler(this.grdSales_DoubleClick);
			// 
			// grdCustomerEnquiry
			// 
			this.grdCustomerEnquiry.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None;
			this.grdCustomerEnquiry.AllowDrop = true;
			this.grdCustomerEnquiry.AllowEditing = false;
			this.grdCustomerEnquiry.AllowFreezing = C1.Win.C1FlexGrid.AllowFreezingEnum.Columns;
			this.grdCustomerEnquiry.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.None;
			this.grdCustomerEnquiry.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.Columns;
			this.grdCustomerEnquiry.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.Columns;
			this.grdCustomerEnquiry.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;
			this.grdCustomerEnquiry.AutoResize = true;
			this.grdCustomerEnquiry.AutoSearch = C1.Win.C1FlexGrid.AutoSearchEnum.None;
			this.grdCustomerEnquiry.AutoSearchDelay = 2;
			this.grdCustomerEnquiry.BackColor = System.Drawing.SystemColors.Window;
			this.grdCustomerEnquiry.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.Fixed3D;
			this.grdCustomerEnquiry.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.Fixed3D;
			this.grdCustomerEnquiry.Cols.Count = 1;
			this.grdCustomerEnquiry.Cols.Fixed = 0;
			this.grdCustomerEnquiry.Cols.Frozen = 0;
			this.grdCustomerEnquiry.Cols.MaxSize = 0;
			this.grdCustomerEnquiry.Cols.MinSize = 0;
			this.grdCustomerEnquiry.Cursor = System.Windows.Forms.Cursors.Default;
			this.grdCustomerEnquiry.DrawMode = C1.Win.C1FlexGrid.DrawModeEnum.Normal;
			this.grdCustomerEnquiry.Enabled = true;
			this.grdCustomerEnquiry.ExtendLastCol = true;
			this.grdCustomerEnquiry.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.Light;
			this.grdCustomerEnquiry.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 178);
			this.grdCustomerEnquiry.ForeColor = System.Drawing.SystemColors.WindowText;
			this.grdCustomerEnquiry.HighLight = C1.Win.C1FlexGrid.HighLightEnum.Always;
			this.grdCustomerEnquiry.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.None;
			this.grdCustomerEnquiry.Location = new System.Drawing.Point(0, 76);
			this.grdCustomerEnquiry.Name = "grdCustomerEnquiry";
			this.grdCustomerEnquiry.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.grdCustomerEnquiry.Rows.Count = 2;
			this.grdCustomerEnquiry.Rows.Fixed = 1;
			this.grdCustomerEnquiry.Rows.Frozen = 0;
			this.grdCustomerEnquiry.Rows.MaxSize = 0;
			this.grdCustomerEnquiry.Rows.MinSize = 0;
			this.grdCustomerEnquiry.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.grdCustomerEnquiry.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.ListBox;
			// this.grdCustomerEnquiry.ShowButtons = C1.Win.C1FlexGrid.ShowButtonsEnum.WithFocus;
			this.grdCustomerEnquiry.ShowSortPosition = C1.Win.C1FlexGrid.ShowSortPositionEnum.None;
			this.grdCustomerEnquiry.Size = new System.Drawing.Size(977, 191);
			this.grdCustomerEnquiry.Styles.Alternate.BackColor = System.Drawing.SystemColors.Window;
			this.grdCustomerEnquiry.Styles.EmptyArea.BackColor = System.Drawing.SystemColors.AppWorkspace;
			this.grdCustomerEnquiry.Styles.Fixed.BackColor = System.Drawing.SystemColors.Control;
			this.grdCustomerEnquiry.Styles.Fixed.Border.Color = System.Drawing.SystemColors.ControlDark;
			this.grdCustomerEnquiry.Styles.Fixed.Border.Direction = C1.Win.C1FlexGrid.BorderDirEnum.Both;
			this.grdCustomerEnquiry.Styles.Fixed.Border.Style = C1.Win.C1FlexGrid.BorderStyleEnum.Inset;
			this.grdCustomerEnquiry.Styles.Fixed.ForeColor = System.Drawing.SystemColors.ControlText;
			this.grdCustomerEnquiry.Styles.Fixed.TextEffect = C1.Win.C1FlexGrid.TextEffectEnum.Flat;
			this.grdCustomerEnquiry.Styles.Frozen.BackColor = System.Drawing.Color.Black;
			this.grdCustomerEnquiry.Styles.Frozen.ForeColor = System.Drawing.Color.Black;
			this.grdCustomerEnquiry.Styles.Highlight.BackColor = System.Drawing.SystemColors.Highlight;
			this.grdCustomerEnquiry.Styles.Highlight.ForeColor = System.Drawing.SystemColors.HighlightText;
			this.grdCustomerEnquiry.Styles.Normal.Border.Color = System.Drawing.SystemColors.Control;
			this.grdCustomerEnquiry.Styles.Normal.Border.Direction = C1.Win.C1FlexGrid.BorderDirEnum.Both;
			this.grdCustomerEnquiry.Styles.Normal.Border.Style = C1.Win.C1FlexGrid.BorderStyleEnum.Flat;
			this.grdCustomerEnquiry.Styles.Normal.Border.Width = 1;
			this.grdCustomerEnquiry.Styles.Normal.ImageAlign = C1.Win.C1FlexGrid.ImageAlignEnum.Stretch;
			this.grdCustomerEnquiry.Styles.Normal.TextEffect = C1.Win.C1FlexGrid.TextEffectEnum.Flat;
			this.grdCustomerEnquiry.Styles.Normal.Trimming = System.Drawing.StringTrimming.None;
			this.grdCustomerEnquiry.Styles.Normal.WordWrap = false;
			this.grdCustomerEnquiry.Styles[C1.Win.C1FlexGrid.CellStyleEnum.EmptyArea].Border.Color = System.Drawing.SystemColors.WindowFrame;
			this.grdCustomerEnquiry.SubtotalPosition = C1.Win.C1FlexGrid.SubtotalPositionEnum.AboveData;
			this.grdCustomerEnquiry.TabIndex = 2;
			this.grdCustomerEnquiry.Tree.Column = 0;
			this.grdCustomerEnquiry.Tree.LineColor = System.Drawing.SystemColors.ControlDark;
			this.grdCustomerEnquiry.Tree.Style = C1.Win.C1FlexGrid.TreeStyleFlags.None;
			this.grdCustomerEnquiry.DoubleClick += new System.EventHandler(this.grdCustomerEnquiry_DoubleClick);
			// 
			// Frame1
			// 
			this.Frame1.AllowDrop = true;
			this.Frame1.BackColor = System.Drawing.SystemColors.Control;
			this.Frame1.Controls.Add(this.cmbYear);
			this.Frame1.Controls.Add(this.cmdSearch);
			this.Frame1.Controls.Add(this.Label1);
			this.Frame1.Controls.Add(this.Label2);
			this.Frame1.Controls.Add(this.Label3);
			this.Frame1.Controls.Add(this.Label4);
			this.Frame1.Controls.Add(this.Label5);
			this.Frame1.Controls.Add(this.txtRefNo);
			this.Frame1.Controls.Add(this.txtPONo);
			this.Frame1.Controls.Add(this.txtSalesInvNo);
			this.Frame1.Controls.Add(this.txtOffer);
			this.Frame1.Controls.Add(this.txtOrder);
			this.Frame1.Controls.Add(this.Label6);
			this.Frame1.Enabled = true;
			this.Frame1.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 178);
			this.Frame1.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Frame1.Location = new System.Drawing.Point(0, 0);
			this.Frame1.Name = "Frame1";
			this.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Frame1.Size = new System.Drawing.Size(977, 71);
			this.Frame1.TabIndex = 0;
			this.Frame1.Text = "Criteria";
			this.Frame1.Visible = true;
			// 
			// cmbYear
			// 
			this.cmbYear.AllowDrop = true;
			this.cmbYear.BackColor = System.Drawing.SystemColors.Window;
			this.cmbYear.CausesValidation = true;
			this.cmbYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbYear.Enabled = true;
			this.cmbYear.ForeColor = System.Drawing.SystemColors.WindowText;
			this.cmbYear.IntegralHeight = true;
			this.cmbYear.Location = new System.Drawing.Point(160, 42);
			this.cmbYear.Name = "cmbYear";
			this.cmbYear.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmbYear.Size = new System.Drawing.Size(103, 21);
			this.cmbYear.Sorted = false;
			this.cmbYear.TabIndex = 16;
			this.cmbYear.TabStop = true;
			this.cmbYear.Visible = true;
			// 
			// cmdSearch
			// 
			this.cmdSearch.AllowDrop = true;
			this.cmdSearch.BackColor = System.Drawing.SystemColors.Control;
			this.cmdSearch.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdSearch.Location = new System.Drawing.Point(266, 16);
			this.cmdSearch.Name = "cmdSearch";
			this.cmdSearch.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdSearch.Size = new System.Drawing.Size(63, 25);
			this.cmdSearch.TabIndex = 5;
			this.cmdSearch.Text = "&Search";
			this.cmdSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.cmdSearch.UseVisualStyleBackColor = false;
			// this.cmdSearch.Click += new System.EventHandler(this.cmdSearch_Click);
			// 
			// System.Windows.Forms.Label1
			// 
			this.Label1.AllowDrop = true;
			this.Label1.BackColor = System.Drawing.SystemColors.Window;
			this.Label1.Text = "Customer Enquiry Ref. No.";
			this.Label1.ForeColor = System.Drawing.SystemColors.WindowText;
			this.Label1.Location = new System.Drawing.Point(8, 21);
			this.Label1.Name = "System.Windows.Forms.Label1";
			this.Label1.Size = new System.Drawing.Size(146, 15);
			this.Label1.TabIndex = 1;
			// 
			// System.Windows.Forms.Label2
			// 
			this.Label2.AllowDrop = true;
			this.Label2.BackColor = System.Drawing.SystemColors.Window;
			this.Label2.Text = "P.O. No.";
			this.Label2.ForeColor = System.Drawing.SystemColors.WindowText;
			this.Label2.Location = new System.Drawing.Point(332, 21);
			this.Label2.Name = "System.Windows.Forms.Label2";
			this.Label2.Size = new System.Drawing.Size(45, 15);
			this.Label2.TabIndex = 6;
			// 
			// System.Windows.Forms.Label3
			// 
			this.Label3.AllowDrop = true;
			this.Label3.BackColor = System.Drawing.SystemColors.Window;
			this.Label3.Text = "Sales Inv. No.";
			this.Label3.ForeColor = System.Drawing.SystemColors.WindowText;
			this.Label3.Location = new System.Drawing.Point(486, 21);
			this.Label3.Name = "System.Windows.Forms.Label3";
			this.Label3.Size = new System.Drawing.Size(75, 15);
			this.Label3.TabIndex = 7;
			// 
			// System.Windows.Forms.Label4
			// 
			this.Label4.AllowDrop = true;
			this.Label4.BackColor = System.Drawing.SystemColors.Window;
			this.Label4.Text = "Offer";
			this.Label4.ForeColor = System.Drawing.SystemColors.WindowText;
			this.Label4.Location = new System.Drawing.Point(672, 20);
			this.Label4.Name = "System.Windows.Forms.Label4";
			this.Label4.Size = new System.Drawing.Size(26, 15);
			this.Label4.TabIndex = 8;
			// 
			// System.Windows.Forms.Label5
			// 
			this.Label5.AllowDrop = true;
			this.Label5.BackColor = System.Drawing.SystemColors.Window;
			this.Label5.Text = "Sales Order";
			this.Label5.ForeColor = System.Drawing.SystemColors.WindowText;
			this.Label5.Location = new System.Drawing.Point(796, 20);
			this.Label5.Name = "System.Windows.Forms.Label5";
			this.Label5.Size = new System.Drawing.Size(66, 15);
			this.Label5.TabIndex = 9;
			// 
			// txtRefNo
			// 
			this.txtRefNo.AllowDrop = true;
			this.txtRefNo.BackColor = System.Drawing.Color.White;
			// this.txtRefNo.bolAllowDecimal = false;
			this.txtRefNo.ForeColor = System.Drawing.Color.Black;
			this.txtRefNo.Location = new System.Drawing.Point(160, 18);
			// this.txtRefNo.mDropDownType = (System.Windows.Forms.TextBox.DropDownTypes) 0;
			this.txtRefNo.Name = "txtRefNo";
			// this.txtRefNo.ShowButton = true;
			this.txtRefNo.Size = new System.Drawing.Size(103, 20);
			this.txtRefNo.TabIndex = 10;
			this.txtRefNo.Text = "";
			// this.this.txtRefNo.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtRefNo_DropButtonClick);
			// this.this.txtRefNo.KeyDown += new System.Windows.Forms.TextBox.KeyDownHandler(this.txtRefNo_KeyDown);
			// 
			// txtPONo
			// 
			this.txtPONo.AllowDrop = true;
			this.txtPONo.BackColor = System.Drawing.Color.White;
			// this.txtPONo.bolAllowDecimal = false;
			this.txtPONo.ForeColor = System.Drawing.Color.Black;
			this.txtPONo.Location = new System.Drawing.Point(380, 18);
			// this.txtPONo.mDropDownType = (System.Windows.Forms.TextBox.DropDownTypes) 0;
			this.txtPONo.Name = "txtPONo";
			// this.txtPONo.ShowButton = true;
			this.txtPONo.Size = new System.Drawing.Size(103, 20);
			this.txtPONo.TabIndex = 11;
			this.txtPONo.Text = "";
			// this.this.txtPONo.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtPONo_DropButtonClick);
			// this.this.txtPONo.KeyDown += new System.Windows.Forms.TextBox.KeyDownHandler(this.txtPONo_KeyDown);
			// 
			// txtSalesInvNo
			// 
			this.txtSalesInvNo.AllowDrop = true;
			this.txtSalesInvNo.BackColor = System.Drawing.Color.White;
			// this.txtSalesInvNo.bolAllowDecimal = false;
			this.txtSalesInvNo.ForeColor = System.Drawing.Color.Black;
			this.txtSalesInvNo.Location = new System.Drawing.Point(566, 18);
			// this.txtSalesInvNo.mDropDownType = (System.Windows.Forms.TextBox.DropDownTypes) 0;
			this.txtSalesInvNo.Name = "txtSalesInvNo";
			// this.txtSalesInvNo.ShowButton = true;
			this.txtSalesInvNo.Size = new System.Drawing.Size(103, 20);
			this.txtSalesInvNo.TabIndex = 12;
			this.txtSalesInvNo.Text = "";
			// this.this.txtSalesInvNo.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtSalesInvNo_DropButtonClick);
			// this.this.txtSalesInvNo.KeyDown += new System.Windows.Forms.TextBox.KeyDownHandler(this.txtSalesInvNo_KeyDown);
			// 
			// txtOffer
			// 
			this.txtOffer.AllowDrop = true;
			this.txtOffer.BackColor = System.Drawing.Color.White;
			// this.txtOffer.bolAllowDecimal = false;
			this.txtOffer.ForeColor = System.Drawing.Color.Black;
			this.txtOffer.Location = new System.Drawing.Point(702, 18);
			// this.txtOffer.mDropDownType = (System.Windows.Forms.TextBox.DropDownTypes) 0;
			this.txtOffer.Name = "txtOffer";
			// this.txtOffer.ShowButton = true;
			this.txtOffer.Size = new System.Drawing.Size(91, 20);
			this.txtOffer.TabIndex = 13;
			this.txtOffer.Text = "";
			// this.this.txtOffer.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtOffer_DropButtonClick);
			// this.this.txtOffer.KeyDown += new System.Windows.Forms.TextBox.KeyDownHandler(this.txtOffer_KeyDown);
			// 
			// txtOrder
			// 
			this.txtOrder.AllowDrop = true;
			this.txtOrder.BackColor = System.Drawing.Color.White;
			// this.txtOrder.bolAllowDecimal = false;
			this.txtOrder.ForeColor = System.Drawing.Color.Black;
			this.txtOrder.Location = new System.Drawing.Point(866, 18);
			// this.txtOrder.mDropDownType = (System.Windows.Forms.TextBox.DropDownTypes) 0;
			this.txtOrder.Name = "txtOrder";
			// this.txtOrder.ShowButton = true;
			this.txtOrder.Size = new System.Drawing.Size(103, 20);
			this.txtOrder.TabIndex = 14;
			this.txtOrder.Text = "";
			// this.this.txtOrder.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtOrder_DropButtonClick);
			// this.this.txtOrder.KeyDown += new System.Windows.Forms.TextBox.KeyDownHandler(this.txtOrder_KeyDown);
			// 
			// System.Windows.Forms.Label6
			// 
			this.Label6.AllowDrop = true;
			this.Label6.BackColor = System.Drawing.SystemColors.Window;
			this.Label6.Text = "Year";
			this.Label6.ForeColor = System.Drawing.SystemColors.WindowText;
			this.Label6.Location = new System.Drawing.Point(8, 45);
			this.Label6.Name = "System.Windows.Forms.Label6";
			this.Label6.Size = new System.Drawing.Size(27, 16);
			this.Label6.TabIndex = 15;
			// 
			// frmICSOrderHistory
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.SystemColors.Control;
			this.ClientSize = new System.Drawing.Size(978, 668);
			this.Controls.Add(this.grdPurchase);
			this.Controls.Add(this.grdSales);
			this.Controls.Add(this.grdCustomerEnquiry);
			this.Controls.Add(this.Frame1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			//this.Icon = (System.Drawing.Icon) resources.GetObject("frmICSOrderHistory.Icon");
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(13, 55);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmICSOrderHistory";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "BEC Order History";
			// this.Activated += new System.EventHandler(this.frmICSOrderHistory_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
			this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Form_KeyPress);
			this.Frame1.ResumeLayout(false);
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
