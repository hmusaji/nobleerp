
namespace Xtreme
{
	partial class frmICSProductHistory
	{

		#region "Upgrade Support "
		private static frmICSProductHistory m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmICSProductHistory DefInstance
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
		public static frmICSProductHistory CreateInstance()
		{
			frmICSProductHistory theInstance = new frmICSProductHistory();
			
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
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "chkIncludeSubgroup", "cmdGetProductHistory", "chkBeginWith", "chkIncludeParent", "grdTransactionDetails", "cntMasterDetails", "_lblCommon_22", "_lblCommon_6", "_lblCommon_0", "_lblCommon_7", "txtTransactionType", "txtProductCode", "txtLedgerCode", "_lblCommon_1", "_lblCommon_2", "_lblCommon_4", "_lblCommon_3", "_lblCommon_5", "_txtDisplayControl_1", "_txtDisplayControl_0", "_txtDisplayControl_2", "_lblCommon_8", "_lblCommon_9", "txtFromDate", "txtToDate", "_lblCommon_10", "txtGroupCode", "_txtDisplayControl_3", "_lblProductDescription_3", "Line1", "lblCommon", "lblProductDescription", "txtDisplayControl"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public System.Windows.Forms.CheckBox chkIncludeSubgroup;
		public System.Windows.Forms.Button cmdGetProductHistory;
		public System.Windows.Forms.CheckBox chkBeginWith;
		public System.Windows.Forms.CheckBox chkIncludeParent;
		public C1.Win.C1FlexGrid.C1FlexGrid grdTransactionDetails;
		public AxTDBContainer3D6.AxTDBContainer3D cntMasterDetails;
		private System.Windows.Forms.Label _lblCommon_22;
		private System.Windows.Forms.Label _lblCommon_6;
		private System.Windows.Forms.Label _lblCommon_0;
		private System.Windows.Forms.Label _lblCommon_7;
		public System.Windows.Forms.TextBox txtTransactionType;
		public System.Windows.Forms.TextBox txtProductCode;
		public System.Windows.Forms.TextBox txtLedgerCode;
		private System.Windows.Forms.Label _lblCommon_1;
		private System.Windows.Forms.Label _lblCommon_2;
		private System.Windows.Forms.Label _lblCommon_4;
		private System.Windows.Forms.Label _lblCommon_3;
		private System.Windows.Forms.Label _lblCommon_5;
		private System.Windows.Forms.Label _txtDisplayControl_1;
		private System.Windows.Forms.Label _txtDisplayControl_0;
		private System.Windows.Forms.Label _txtDisplayControl_2;
		private System.Windows.Forms.Label _lblCommon_8;
		private System.Windows.Forms.Label _lblCommon_9;
		public Syncfusion.WinForms.Input.SfDateTimeEdit txtFromDate;
		public Syncfusion.WinForms.Input.SfDateTimeEdit txtToDate;
		private System.Windows.Forms.Label _lblCommon_10;
		public System.Windows.Forms.TextBox txtGroupCode;
		private System.Windows.Forms.Label _txtDisplayControl_3;
		private System.Windows.Forms.Label _lblProductDescription_3;
		public System.Windows.Forms.Label Line1;
		public System.Windows.Forms.Label[] lblCommon = new System.Windows.Forms.Label[23];
		public System.Windows.Forms.Label[] lblProductDescription = new System.Windows.Forms.Label[4];
		public System.Windows.Forms.Label[] txtDisplayControl = new System.Windows.Forms.Label[4];
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmICSProductHistory));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this.chkIncludeSubgroup = new System.Windows.Forms.CheckBox();
			this.cmdGetProductHistory = new System.Windows.Forms.Button();
			this.chkBeginWith = new System.Windows.Forms.CheckBox();
			this.chkIncludeParent = new System.Windows.Forms.CheckBox();
			this.cntMasterDetails = new AxTDBContainer3D6.AxTDBContainer3D();
			this.grdTransactionDetails = new C1.Win.C1FlexGrid.C1FlexGrid();
			this._lblCommon_22 = new System.Windows.Forms.Label();
			this._lblCommon_6 = new System.Windows.Forms.Label();
			this._lblCommon_0 = new System.Windows.Forms.Label();
			this._lblCommon_7 = new System.Windows.Forms.Label();
			this.txtTransactionType = new System.Windows.Forms.TextBox();
			this.txtProductCode = new System.Windows.Forms.TextBox();
			this.txtLedgerCode = new System.Windows.Forms.TextBox();
			this._lblCommon_1 = new System.Windows.Forms.Label();
			this._lblCommon_2 = new System.Windows.Forms.Label();
			this._lblCommon_4 = new System.Windows.Forms.Label();
			this._lblCommon_3 = new System.Windows.Forms.Label();
			this._lblCommon_5 = new System.Windows.Forms.Label();
			this._txtDisplayControl_1 = new System.Windows.Forms.Label();
			this._txtDisplayControl_0 = new System.Windows.Forms.Label();
			this._txtDisplayControl_2 = new System.Windows.Forms.Label();
			this._lblCommon_8 = new System.Windows.Forms.Label();
			this._lblCommon_9 = new System.Windows.Forms.Label();
			this.txtFromDate = new Syncfusion.WinForms.Input.SfDateTimeEdit();
			this.txtToDate = new Syncfusion.WinForms.Input.SfDateTimeEdit();
			this._lblCommon_10 = new System.Windows.Forms.Label();
			this.txtGroupCode = new System.Windows.Forms.TextBox();
			this._txtDisplayControl_3 = new System.Windows.Forms.Label();
			this._lblProductDescription_3 = new System.Windows.Forms.Label();
			this.Line1 = new System.Windows.Forms.Label();
			// //((System.ComponentModel.ISupportInitialize) this.cntMasterDetails).BeginInit();
			this.cntMasterDetails.SuspendLayout();
			this.SuspendLayout();
			// 
			// chkIncludeSubgroup
			// 
			this.chkIncludeSubgroup.AllowDrop = true;
			this.chkIncludeSubgroup.Appearance = System.Windows.Forms.Appearance.Normal;
			this.chkIncludeSubgroup.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.chkIncludeSubgroup.CausesValidation = true;
			this.chkIncludeSubgroup.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkIncludeSubgroup.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this.chkIncludeSubgroup.Enabled = true;
			this.chkIncludeSubgroup.ForeColor = System.Drawing.SystemColors.ControlText;
			this.chkIncludeSubgroup.Location = new System.Drawing.Point(430, 39);
			this.chkIncludeSubgroup.Name = "chkIncludeSubgroup";
			this.chkIncludeSubgroup.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.chkIncludeSubgroup.Size = new System.Drawing.Size(151, 19);
			this.chkIncludeSubgroup.TabIndex = 25;
			this.chkIncludeSubgroup.TabStop = true;
			this.chkIncludeSubgroup.Text = "Include Subgroup";
			this.chkIncludeSubgroup.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkIncludeSubgroup.Visible = false;
			// 
			// cmdGetProductHistory
			// 
			this.cmdGetProductHistory.AllowDrop = true;
			this.cmdGetProductHistory.BackColor = System.Drawing.SystemColors.Control;
			this.cmdGetProductHistory.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdGetProductHistory.Location = new System.Drawing.Point(430, 134);
			this.cmdGetProductHistory.Name = "cmdGetProductHistory";
			this.cmdGetProductHistory.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdGetProductHistory.Size = new System.Drawing.Size(81, 29);
			this.cmdGetProductHistory.TabIndex = 5;
			this.cmdGetProductHistory.Text = "Show";
			this.cmdGetProductHistory.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.cmdGetProductHistory.UseVisualStyleBackColor = false;
			// this.cmdGetProductHistory.Click += new System.EventHandler(this.cmdGetProductHistory_Click);
			// this.this.cmdGetProductHistory.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmdGetProductHistory_KeyDown);
			// 
			// chkBeginWith
			// 
			this.chkBeginWith.AllowDrop = true;
			this.chkBeginWith.Appearance = System.Windows.Forms.Appearance.Normal;
			this.chkBeginWith.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.chkBeginWith.CausesValidation = true;
			this.chkBeginWith.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkBeginWith.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this.chkBeginWith.Enabled = true;
			this.chkBeginWith.ForeColor = System.Drawing.SystemColors.ControlText;
			this.chkBeginWith.Location = new System.Drawing.Point(430, 62);
			this.chkBeginWith.Name = "chkBeginWith";
			this.chkBeginWith.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.chkBeginWith.Size = new System.Drawing.Size(151, 19);
			this.chkBeginWith.TabIndex = 24;
			this.chkBeginWith.TabStop = true;
			this.chkBeginWith.Text = "Starting With";
			this.chkBeginWith.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkBeginWith.Visible = false;
			// 
			// chkIncludeParent
			// 
			this.chkIncludeParent.AllowDrop = true;
			this.chkIncludeParent.Appearance = System.Windows.Forms.Appearance.Normal;
			this.chkIncludeParent.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.chkIncludeParent.CausesValidation = true;
			this.chkIncludeParent.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkIncludeParent.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this.chkIncludeParent.Enabled = true;
			this.chkIncludeParent.ForeColor = System.Drawing.SystemColors.ControlText;
			this.chkIncludeParent.Location = new System.Drawing.Point(430, 16);
			this.chkIncludeParent.Name = "chkIncludeParent";
			this.chkIncludeParent.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.chkIncludeParent.Size = new System.Drawing.Size(151, 19);
			this.chkIncludeParent.TabIndex = 21;
			this.chkIncludeParent.TabStop = true;
			this.chkIncludeParent.Text = "Include Parent";
			this.chkIncludeParent.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkIncludeParent.Visible = true;
			// 
			// cntMasterDetails
			// 
			this.cntMasterDetails.AllowDrop = true;
			this.cntMasterDetails.Controls.Add(this.grdTransactionDetails);
			this.cntMasterDetails.Location = new System.Drawing.Point(2, 210);
			this.cntMasterDetails.Name = "cntMasterDetails";
			("cntMasterDetails.OcxState");
			this.cntMasterDetails.Size = new System.Drawing.Size(949, 369);
			this.cntMasterDetails.TabIndex = 7;
			// 
			// grdTransactionDetails
			// 
			this.grdTransactionDetails.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None;
			this.grdTransactionDetails.AllowDrop = true;
			this.grdTransactionDetails.AllowEditing = false;
			this.grdTransactionDetails.AllowFreezing = C1.Win.C1FlexGrid.AllowFreezingEnum.None;
			this.grdTransactionDetails.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.None;
			this.grdTransactionDetails.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.None;
			this.grdTransactionDetails.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.Columns;
			this.grdTransactionDetails.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;
			this.grdTransactionDetails.AutoResize = true;
			this.grdTransactionDetails.AutoSearch = C1.Win.C1FlexGrid.AutoSearchEnum.None;
			this.grdTransactionDetails.AutoSearchDelay = 2;
			this.grdTransactionDetails.BackColor = System.Drawing.SystemColors.Window;
			this.grdTransactionDetails.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.Fixed3D;
			this.grdTransactionDetails.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.Fixed3D;
			this.grdTransactionDetails.Cols.Count = 3;
			this.grdTransactionDetails.Cols.Fixed = 1;
			this.grdTransactionDetails.Cols.Frozen = 0;
			this.grdTransactionDetails.Cols.MaxSize = 0;
			this.grdTransactionDetails.Cols.MinSize = 0;
			this.grdTransactionDetails.Cursor = System.Windows.Forms.Cursors.Default;
			this.grdTransactionDetails.DrawMode = C1.Win.C1FlexGrid.DrawModeEnum.Normal;
			this.grdTransactionDetails.Enabled = true;
			this.grdTransactionDetails.ExtendLastCol = false;
			this.grdTransactionDetails.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.Light;
			this.grdTransactionDetails.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 178);
			this.grdTransactionDetails.ForeColor = System.Drawing.SystemColors.WindowText;
			this.grdTransactionDetails.HighLight = C1.Win.C1FlexGrid.HighLightEnum.Always;
			this.grdTransactionDetails.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.None;
			this.grdTransactionDetails.Location = new System.Drawing.Point(0, 0);
			this.grdTransactionDetails.Name = "grdTransactionDetails";
			this.grdTransactionDetails.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.grdTransactionDetails.Rows.Count = 7;
			this.grdTransactionDetails.Rows.Fixed = 1;
			this.grdTransactionDetails.Rows.Frozen = 0;
			this.grdTransactionDetails.Rows.MaxSize = 0;
			this.grdTransactionDetails.Rows.MinSize = 0;
			this.grdTransactionDetails.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.grdTransactionDetails.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Default;
			// this.grdTransactionDetails.ShowButtons = C1.Win.C1FlexGrid.ShowButtonsEnum.WithFocus;
			this.grdTransactionDetails.ShowSortPosition = C1.Win.C1FlexGrid.ShowSortPositionEnum.None;
			this.grdTransactionDetails.Size = new System.Drawing.Size(895, 363);
			this.grdTransactionDetails.Styles.Alternate.BackColor = System.Drawing.SystemColors.Window;
			this.grdTransactionDetails.Styles.EmptyArea.BackColor = System.Drawing.SystemColors.AppWorkspace;
			this.grdTransactionDetails.Styles.Fixed.BackColor = System.Drawing.SystemColors.Control;
			this.grdTransactionDetails.Styles.Fixed.Border.Color = System.Drawing.SystemColors.ControlDark;
			this.grdTransactionDetails.Styles.Fixed.Border.Direction = C1.Win.C1FlexGrid.BorderDirEnum.Both;
			this.grdTransactionDetails.Styles.Fixed.Border.Style = C1.Win.C1FlexGrid.BorderStyleEnum.Inset;
			this.grdTransactionDetails.Styles.Fixed.ForeColor = System.Drawing.SystemColors.ControlText;
			this.grdTransactionDetails.Styles.Fixed.TextEffect = C1.Win.C1FlexGrid.TextEffectEnum.Flat;
			this.grdTransactionDetails.Styles.Frozen.BackColor = System.Drawing.Color.Black;
			this.grdTransactionDetails.Styles.Frozen.ForeColor = System.Drawing.Color.Black;
			this.grdTransactionDetails.Styles.Highlight.BackColor = System.Drawing.SystemColors.Highlight;
			this.grdTransactionDetails.Styles.Highlight.ForeColor = System.Drawing.SystemColors.HighlightText;
			this.grdTransactionDetails.Styles.Normal.Border.Color = System.Drawing.SystemColors.Control;
			this.grdTransactionDetails.Styles.Normal.Border.Direction = C1.Win.C1FlexGrid.BorderDirEnum.Both;
			this.grdTransactionDetails.Styles.Normal.Border.Style = C1.Win.C1FlexGrid.BorderStyleEnum.Flat;
			this.grdTransactionDetails.Styles.Normal.Border.Width = 1;
			this.grdTransactionDetails.Styles.Normal.ImageAlign = C1.Win.C1FlexGrid.ImageAlignEnum.Stretch;
			this.grdTransactionDetails.Styles.Normal.TextEffect = C1.Win.C1FlexGrid.TextEffectEnum.Flat;
			this.grdTransactionDetails.Styles.Normal.Trimming = System.Drawing.StringTrimming.None;
			this.grdTransactionDetails.Styles.Normal.WordWrap = false;
			this.grdTransactionDetails.Styles[C1.Win.C1FlexGrid.CellStyleEnum.EmptyArea].Border.Color = System.Drawing.SystemColors.WindowFrame;
			this.grdTransactionDetails.SubtotalPosition = C1.Win.C1FlexGrid.SubtotalPositionEnum.AboveData;
			this.grdTransactionDetails.TabIndex = 6;
			this.grdTransactionDetails.Tree.Column = 0;
			this.grdTransactionDetails.Tree.LineColor = System.Drawing.SystemColors.ControlDark;
			this.grdTransactionDetails.Tree.Style = C1.Win.C1FlexGrid.TreeStyleFlags.None;
			this.grdTransactionDetails.AfterScroll += new C1.Win.C1FlexGrid.RangeEventHandler(this.grdTransactionDetails_AfterScroll);
			this.grdTransactionDetails.AfterSort += new C1.Win.C1FlexGrid.SortColEventHandler(this.grdTransactionDetails_AfterSort);
			this.grdTransactionDetails.DoubleClick += new System.EventHandler(this.grdTransactionDetails_DoubleClick);
			// this.this.grdTransactionDetails.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grdTransactionDetails_KeyDown);
			// 
			// _lblCommon_22
			// 
			this._lblCommon_22.AllowDrop = true;
			this._lblCommon_22.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_22.Text = " Transaction  Details ";
			this._lblCommon_22.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_22.Location = new System.Drawing.Point(10, 178);
			this._lblCommon_22.Name = "_lblCommon_22";
			this._lblCommon_22.Size = new System.Drawing.Size(100, 13);
			this._lblCommon_22.TabIndex = 8;
			// 
			// _lblCommon_6
			// 
			this._lblCommon_6.AllowDrop = true;
			this._lblCommon_6.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_6.Text = "Product Code";
			this._lblCommon_6.Location = new System.Drawing.Point(12, 64);
			this._lblCommon_6.Name = "_lblCommon_6";
			this._lblCommon_6.Size = new System.Drawing.Size(65, 13);
			this._lblCommon_6.TabIndex = 9;
			// 
			// _lblCommon_0
			// 
			this._lblCommon_0.AllowDrop = true;
			this._lblCommon_0.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_0.Text = "Transaction Type ";
			this._lblCommon_0.Location = new System.Drawing.Point(12, 18);
			this._lblCommon_0.Name = "_lblCommon_0";
			this._lblCommon_0.Size = new System.Drawing.Size(87, 14);
			this._lblCommon_0.TabIndex = 10;
			// 
			// _lblCommon_7
			// 
			this._lblCommon_7.AllowDrop = true;
			this._lblCommon_7.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_7.Text = "Ledger Code";
			this._lblCommon_7.Location = new System.Drawing.Point(12, 103);
			this._lblCommon_7.Name = "_lblCommon_7";
			this._lblCommon_7.Size = new System.Drawing.Size(61, 13);
			this._lblCommon_7.TabIndex = 11;
			// 
			// txtTransactionType
			// 
			this.txtTransactionType.AllowDrop = true;
			this.txtTransactionType.BackColor = System.Drawing.Color.White;
			this.txtTransactionType.ForeColor = System.Drawing.Color.Black;
			this.txtTransactionType.Location = new System.Drawing.Point(112, 16);
			this.txtTransactionType.Name = "txtTransactionType";
			// this.txtTransactionType.ShowButton = true;
			this.txtTransactionType.Size = new System.Drawing.Size(101, 19);
			this.txtTransactionType.TabIndex = 0;
			this.txtTransactionType.Text = "";
			// this.this.txtTransactionType.Watermark = "";
			// this.this.txtTransactionType.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtTransactionType_DropButtonClick);
			// this.this.txtTransactionType.KeyDown += new System.Windows.Forms.TextBox.KeyDownHandler(this.txtTransactionType_KeyDown);
			// this.txtTransactionType.Leave += new System.EventHandler(this.txtTransactionType_Leave);
			// 
			// txtProductCode
			// 
			this.txtProductCode.AllowDrop = true;
			this.txtProductCode.BackColor = System.Drawing.Color.White;
			this.txtProductCode.ForeColor = System.Drawing.Color.Black;
			this.txtProductCode.Location = new System.Drawing.Point(112, 61);
			this.txtProductCode.Name = "txtProductCode";
			// this.txtProductCode.ShowButton = true;
			this.txtProductCode.Size = new System.Drawing.Size(101, 19);
			this.txtProductCode.TabIndex = 1;
			this.txtProductCode.Text = "";
			// this.this.txtProductCode.Watermark = "";
			// this.this.txtProductCode.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtProductCode_DropButtonClick);
			// this.this.txtProductCode.KeyDown += new System.Windows.Forms.TextBox.KeyDownHandler(this.txtProductCode_KeyDown);
			// this.txtProductCode.Leave += new System.EventHandler(this.txtProductCode_Leave);
			// 
			// txtLedgerCode
			// 
			this.txtLedgerCode.AllowDrop = true;
			this.txtLedgerCode.BackColor = System.Drawing.Color.White;
			this.txtLedgerCode.ForeColor = System.Drawing.Color.Black;
			this.txtLedgerCode.Location = new System.Drawing.Point(112, 100);
			this.txtLedgerCode.Name = "txtLedgerCode";
			// this.txtLedgerCode.ShowButton = true;
			this.txtLedgerCode.Size = new System.Drawing.Size(101, 19);
			this.txtLedgerCode.TabIndex = 2;
			this.txtLedgerCode.Text = "";
			// this.this.txtLedgerCode.Watermark = "";
			// this.this.txtLedgerCode.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtLedgerCode_DropButtonClick);
			// this.this.txtLedgerCode.KeyDown += new System.Windows.Forms.TextBox.KeyDownHandler(this.txtLedgerCode_KeyDown);
			// this.txtLedgerCode.Leave += new System.EventHandler(this.txtLedgerCode_Leave);
			// 
			// _lblCommon_1
			// 
			this._lblCommon_1.AllowDrop = true;
			this._lblCommon_1.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_1.Text = "(Curr. Bal :";
			this._lblCommon_1.Location = new System.Drawing.Point(124, 123);
			this._lblCommon_1.Name = "_lblCommon_1";
			this._lblCommon_1.Size = new System.Drawing.Size(53, 13);
			this._lblCommon_1.TabIndex = 12;
			// 
			// _lblCommon_2
			// 
			this._lblCommon_2.AllowDrop = true;
			this._lblCommon_2.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_2.Text = "Product Desc";
			this._lblCommon_2.Location = new System.Drawing.Point(12, 100);
			this._lblCommon_2.Name = "_lblCommon_2";
			this._lblCommon_2.Size = new System.Drawing.Size(63, 13);
			this._lblCommon_2.TabIndex = 13;
			this._lblCommon_2.Visible = false;
			// 
			// _lblCommon_4
			// 
			this._lblCommon_4.AllowDrop = true;
			this._lblCommon_4.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_4.Text = "0.000 )";
			this._lblCommon_4.Location = new System.Drawing.Point(185, 123);
			this._lblCommon_4.Name = "_lblCommon_4";
			this._lblCommon_4.Size = new System.Drawing.Size(35, 13);
			this._lblCommon_4.TabIndex = 14;
			// 
			// _lblCommon_3
			// 
			this._lblCommon_3.AllowDrop = true;
			this._lblCommon_3.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_3.Text = "(Cost :";
			this._lblCommon_3.Location = new System.Drawing.Point(124, 84);
			this._lblCommon_3.Name = "_lblCommon_3";
			this._lblCommon_3.Size = new System.Drawing.Size(33, 13);
			this._lblCommon_3.TabIndex = 16;
			// 
			// _lblCommon_5
			// 
			this._lblCommon_5.AllowDrop = true;
			this._lblCommon_5.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_5.Text = "0.000 )";
			this._lblCommon_5.Location = new System.Drawing.Point(165, 84);
			this._lblCommon_5.Name = "_lblCommon_5";
			this._lblCommon_5.Size = new System.Drawing.Size(35, 13);
			this._lblCommon_5.TabIndex = 17;
			// 
			// _txtDisplayControl_1
			// 
			this._txtDisplayControl_1.AllowDrop = true;
			this._txtDisplayControl_1.Location = new System.Drawing.Point(215, 100);
			this._txtDisplayControl_1.Name = "_txtDisplayControl_1";
			this._txtDisplayControl_1.Size = new System.Drawing.Size(201, 19);
			this._txtDisplayControl_1.TabIndex = 18;
			this._txtDisplayControl_1.TabStop = false;
			// 
			// _txtDisplayControl_0
			// 
			this._txtDisplayControl_0.AllowDrop = true;
			this._txtDisplayControl_0.Location = new System.Drawing.Point(215, 16);
			this._txtDisplayControl_0.Name = "_txtDisplayControl_0";
			this._txtDisplayControl_0.Size = new System.Drawing.Size(201, 19);
			this._txtDisplayControl_0.TabIndex = 19;
			this._txtDisplayControl_0.TabStop = false;
			// 
			// _txtDisplayControl_2
			// 
			this._txtDisplayControl_2.AllowDrop = true;
			this._txtDisplayControl_2.Location = new System.Drawing.Point(215, 61);
			this._txtDisplayControl_2.Name = "_txtDisplayControl_2";
			this._txtDisplayControl_2.Size = new System.Drawing.Size(201, 19);
			this._txtDisplayControl_2.TabIndex = 20;
			this._txtDisplayControl_2.TabStop = false;
			// 
			// _lblCommon_8
			// 
			this._lblCommon_8.AllowDrop = true;
			this._lblCommon_8.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_8.Text = "From Date";
			this._lblCommon_8.Location = new System.Drawing.Point(14, 144);
			this._lblCommon_8.Name = "_lblCommon_8";
			this._lblCommon_8.Size = new System.Drawing.Size(50, 13);
			this._lblCommon_8.TabIndex = 22;
			// 
			// _lblCommon_9
			// 
			this._lblCommon_9.AllowDrop = true;
			this._lblCommon_9.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_9.Text = "To Date";
			this._lblCommon_9.Location = new System.Drawing.Point(220, 144);
			this._lblCommon_9.Name = "_lblCommon_9";
			this._lblCommon_9.Size = new System.Drawing.Size(38, 13);
			this._lblCommon_9.TabIndex = 23;
			// 
			// txtFromDate
			// 
			this.txtFromDate.AllowDrop = true;
			// this.txtFromDate.CheckDateRange = false;
			this.txtFromDate.Location = new System.Drawing.Point(112, 140);
			// this.txtFromDate.MaxDate = 2958465;
			// this.txtFromDate.MinDate = 2;
			this.txtFromDate.Name = "txtFromDate";
			this.txtFromDate.Size = new System.Drawing.Size(101, 19);
			this.txtFromDate.TabIndex = 3;
			this.txtFromDate.Text = "18/07/2001";
			this.txtFromDate.Value = 37090;
			// 
			// txtToDate
			// 
			this.txtToDate.AllowDrop = true;
			// this.txtToDate.CheckDateRange = false;
			this.txtToDate.Location = new System.Drawing.Point(274, 141);
			// this.txtToDate.MaxDate = 2958465;
			// this.txtToDate.MinDate = 2;
			this.txtToDate.Name = "txtToDate";
			this.txtToDate.Size = new System.Drawing.Size(101, 19);
			this.txtToDate.TabIndex = 4;
			this.txtToDate.Text = "18/07/2001";
			this.txtToDate.Value = 37090;
			// 
			// _lblCommon_10
			// 
			this._lblCommon_10.AllowDrop = true;
			this._lblCommon_10.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_10.Text = "Group Code";
			this._lblCommon_10.Location = new System.Drawing.Point(12, 41);
			this._lblCommon_10.Name = "_lblCommon_10";
			this._lblCommon_10.Size = new System.Drawing.Size(57, 13);
			this._lblCommon_10.TabIndex = 26;
			// 
			// txtGroupCode
			// 
			this.txtGroupCode.AllowDrop = true;
			this.txtGroupCode.BackColor = System.Drawing.Color.White;
			this.txtGroupCode.ForeColor = System.Drawing.Color.Black;
			this.txtGroupCode.Location = new System.Drawing.Point(112, 38);
			this.txtGroupCode.Name = "txtGroupCode";
			// this.txtGroupCode.ShowButton = true;
			this.txtGroupCode.Size = new System.Drawing.Size(101, 19);
			this.txtGroupCode.TabIndex = 27;
			this.txtGroupCode.Text = "";
			// this.this.txtGroupCode.Watermark = "";
			// this.this.txtGroupCode.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtGroupCode_DropButtonClick);
			// this.txtGroupCode.Leave += new System.EventHandler(this.txtGroupCode_Leave);
			// 
			// _txtDisplayControl_3
			// 
			this._txtDisplayControl_3.AllowDrop = true;
			this._txtDisplayControl_3.Location = new System.Drawing.Point(215, 38);
			this._txtDisplayControl_3.Name = "_txtDisplayControl_3";
			this._txtDisplayControl_3.Size = new System.Drawing.Size(201, 19);
			this._txtDisplayControl_3.TabIndex = 28;
			this._txtDisplayControl_3.TabStop = false;
			// 
			// _lblProductDescription_3
			// 
			this._lblProductDescription_3.AllowDrop = true;
			this._lblProductDescription_3.BackColor = System.Drawing.Color.FromArgb(239, 239, 239);
			this._lblProductDescription_3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._lblProductDescription_3.ForeColor = System.Drawing.SystemColors.WindowText;
			this._lblProductDescription_3.Location = new System.Drawing.Point(112, 100);
			this._lblProductDescription_3.Name = "_lblProductDescription_3";
			this._lblProductDescription_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblProductDescription_3.Size = new System.Drawing.Size(304, 16);
			this._lblProductDescription_3.TabIndex = 15;
			this._lblProductDescription_3.Visible = false;
			// 
			// Line1
			// 
			this.Line1.AllowDrop = true;
			this.Line1.BackColor = System.Drawing.SystemColors.WindowText;
			this.Line1.Enabled = false;
			this.Line1.Location = new System.Drawing.Point(0, 186);
			this.Line1.Name = "Line1";
			this.Line1.Size = new System.Drawing.Size(947, 1);
			this.Line1.Visible = true;
			// 
			// frmICSProductHistory
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.ClientSize = new System.Drawing.Size(993, 696);
			this.Controls.Add(this.chkIncludeSubgroup);
			this.Controls.Add(this.cmdGetProductHistory);
			this.Controls.Add(this.chkBeginWith);
			this.Controls.Add(this.chkIncludeParent);
			this.Controls.Add(this.cntMasterDetails);
			this.Controls.Add(this._lblCommon_22);
			this.Controls.Add(this._lblCommon_6);
			this.Controls.Add(this._lblCommon_0);
			this.Controls.Add(this._lblCommon_7);
			this.Controls.Add(this.txtTransactionType);
			this.Controls.Add(this.txtProductCode);
			this.Controls.Add(this.txtLedgerCode);
			this.Controls.Add(this._lblCommon_1);
			this.Controls.Add(this._lblCommon_2);
			this.Controls.Add(this._lblCommon_4);
			this.Controls.Add(this._lblCommon_3);
			this.Controls.Add(this._lblCommon_5);
			this.Controls.Add(this._txtDisplayControl_1);
			this.Controls.Add(this._txtDisplayControl_0);
			this.Controls.Add(this._txtDisplayControl_2);
			this.Controls.Add(this._lblCommon_8);
			this.Controls.Add(this._lblCommon_9);
			this.Controls.Add(this.txtFromDate);
			this.Controls.Add(this.txtToDate);
			this.Controls.Add(this._lblCommon_10);
			this.Controls.Add(this.txtGroupCode);
			this.Controls.Add(this._txtDisplayControl_3);
			this.Controls.Add(this._lblProductDescription_3);
			this.Controls.Add(this.Line1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			//this.Icon = (System.Drawing.Icon) resources.GetObject("frmICSProductHistory.Icon");
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(131, 114);
			this.MaximizeBox = true;
			this.MinimizeBox = true;
			this.Name = "frmICSProductHistory";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Product History";
			// this.Activated += new System.EventHandler(this.frmICSProductHistory_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
			// this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
			//this.Resize += new System.EventHandler(this.Form_Resize);
			//((System.ComponentModel.ISupportInitialize) this.cntMasterDetails).EndInit();
			this.cntMasterDetails.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		void ReLoadForm(bool addEvents)
		{
			InitializetxtDisplayControl();
			InitializelblProductDescription();
			InitializelblCommon();
			//This form is an MDI child.
			//This code simulates the VB6 
			// functionality of automatically
			// loading and showing an MDI
			// child's parent.
			this.MdiParent = Xtreme.frmSysMain.DefInstance;
			Xtreme.frmSysMain.DefInstance.Show();
		}
		void InitializetxtDisplayControl()
		{
			this.txtDisplayControl = new System.Windows.Forms.Label[4];
			this.txtDisplayControl[1] = _txtDisplayControl_1;
			this.txtDisplayControl[0] = _txtDisplayControl_0;
			this.txtDisplayControl[2] = _txtDisplayControl_2;
			this.txtDisplayControl[3] = _txtDisplayControl_3;
		}
		void InitializelblProductDescription()
		{
			this.lblProductDescription = new System.Windows.Forms.Label[4];
			this.lblProductDescription[3] = _lblProductDescription_3;
		}
		void InitializelblCommon()
		{
			this.lblCommon = new System.Windows.Forms.Label[23];
			this.lblCommon[22] = _lblCommon_22;
			this.lblCommon[6] = _lblCommon_6;
			this.lblCommon[0] = _lblCommon_0;
			this.lblCommon[7] = _lblCommon_7;
			this.lblCommon[1] = _lblCommon_1;
			this.lblCommon[2] = _lblCommon_2;
			this.lblCommon[4] = _lblCommon_4;
			this.lblCommon[3] = _lblCommon_3;
			this.lblCommon[5] = _lblCommon_5;
			this.lblCommon[8] = _lblCommon_8;
			this.lblCommon[9] = _lblCommon_9;
			this.lblCommon[10] = _lblCommon_10;
		}
		#endregion
	}
}