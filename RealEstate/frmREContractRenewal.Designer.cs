
namespace Xtreme
{
	partial class frmREContractRenewal
	{

		#region "Upgrade Support "
		private static frmREContractRenewal m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmREContractRenewal DefInstance
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
		public static frmREContractRenewal CreateInstance()
		{
			frmREContractRenewal theInstance = new frmREContractRenewal();
			
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
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "cmdOkCancel", "_grdCommon_0", "_lblCommon_0", "_grdCommon_1", "_lblCommon_1", "cntMasterDetails", "cmdSelectContract", "grdCommon", "lblCommon"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public UCOkCancel cmdOkCancel;
		private C1.Win.C1FlexGrid.C1FlexGrid _grdCommon_0;
		private System.Windows.Forms.Label _lblCommon_0;
		private C1.Win.C1FlexGrid.C1FlexGrid _grdCommon_1;
		private System.Windows.Forms.Label _lblCommon_1;
		public AxTDBContainer3D6.AxTDBContainer3D cntMasterDetails;
		public UCOkCancel cmdSelectContract;
		public C1.Win.C1FlexGrid.C1FlexGrid[] grdCommon = new C1.Win.C1FlexGrid.C1FlexGrid[2];
		public System.Windows.Forms.Label[] lblCommon = new System.Windows.Forms.Label[2];
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmREContractRenewal));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this.cmdOkCancel = new UCOkCancel();
			this.cntMasterDetails = new AxTDBContainer3D6.AxTDBContainer3D();
			this._grdCommon_0 = new C1.Win.C1FlexGrid.C1FlexGrid();
			this._lblCommon_0 = new System.Windows.Forms.Label();
			this._grdCommon_1 = new C1.Win.C1FlexGrid.C1FlexGrid();
			this._lblCommon_1 = new System.Windows.Forms.Label();
			this.cmdSelectContract = new UCOkCancel();
			// //((System.ComponentModel.ISupportInitialize) this.cntMasterDetails).BeginInit();
			this.cntMasterDetails.SuspendLayout();
			this.SuspendLayout();
			// 
			// cmdOkCancel
			// 
			this.cmdOkCancel.AllowDrop = true;
			this.cmdOkCancel.DisplayButton = 0;
			this.cmdOkCancel.Location = new System.Drawing.Point(484, 408);
			this.cmdOkCancel.Name = "cmdOkCancel";
			this.cmdOkCancel.OkCaption = "&Renew";
			this.cmdOkCancel.Size = new System.Drawing.Size(206, 31);
			this.cmdOkCancel.TabIndex = 5;
			this.cmdOkCancel.CancelClick += new UCOkCancel.CancelClickHandler(this.cmdOkCancel_CancelClick);
			this.cmdOkCancel.OKClick += new UCOkCancel.OKClickHandler(this.cmdOkCancel_OKClick);
			// 
			// cntMasterDetails
			// 
			this.cntMasterDetails.AllowDrop = true;
			this.cntMasterDetails.Controls.Add(this._grdCommon_0);
			this.cntMasterDetails.Controls.Add(this._lblCommon_0);
			this.cntMasterDetails.Controls.Add(this._grdCommon_1);
			this.cntMasterDetails.Controls.Add(this._lblCommon_1);
			this.cntMasterDetails.Location = new System.Drawing.Point(4, 6);
			this.cntMasterDetails.Name = "cntMasterDetails";
			("cntMasterDetails.OcxState");
			this.cntMasterDetails.Size = new System.Drawing.Size(686, 396);
			this.cntMasterDetails.TabIndex = 0;
			// 
			// _grdCommon_0
			// 
			this._grdCommon_0.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None;
			this._grdCommon_0.AllowDrop = true;
			this._grdCommon_0.AllowEditing = false;
			this._grdCommon_0.AllowFreezing = C1.Win.C1FlexGrid.AllowFreezingEnum.None;
			this._grdCommon_0.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.None;
			this._grdCommon_0.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.None;
			this._grdCommon_0.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.Columns;
			this._grdCommon_0.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;
			this._grdCommon_0.AutoResize = true;
			this._grdCommon_0.AutoSearch = C1.Win.C1FlexGrid.AutoSearchEnum.None;
			this._grdCommon_0.AutoSearchDelay = 2;
			this._grdCommon_0.BackColor = System.Drawing.SystemColors.Window;
			this._grdCommon_0.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.Fixed3D;
			this._grdCommon_0.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.Fixed3D;
			this._grdCommon_0.Cols.Count = 10;
			this._grdCommon_0.Cols.Fixed = 1;
			this._grdCommon_0.Cols.Frozen = 0;
			this._grdCommon_0.Cols.MaxSize = 0;
			this._grdCommon_0.Cols.MinSize = 0;
			this._grdCommon_0.Cursor = System.Windows.Forms.Cursors.Default;
			this._grdCommon_0.DrawMode = C1.Win.C1FlexGrid.DrawModeEnum.Normal;
			this._grdCommon_0.Enabled = true;
			this._grdCommon_0.ExtendLastCol = false;
			this._grdCommon_0.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.Light;
			this._grdCommon_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 178);
			this._grdCommon_0.ForeColor = System.Drawing.SystemColors.WindowText;
			this._grdCommon_0.HighLight = C1.Win.C1FlexGrid.HighLightEnum.Always;
			this._grdCommon_0.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.None;
			this._grdCommon_0.Location = new System.Drawing.Point(0, 28);
			this._grdCommon_0.Name = "_grdCommon_0";
			this._grdCommon_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._grdCommon_0.Rows.Count = 50;
			this._grdCommon_0.Rows.Fixed = 1;
			this._grdCommon_0.Rows.Frozen = 0;
			this._grdCommon_0.Rows.MaxSize = 0;
			this._grdCommon_0.Rows.MinSize = 0;
			this._grdCommon_0.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this._grdCommon_0.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Default;
			// this._grdCommon_0.ShowButtons = C1.Win.C1FlexGrid.ShowButtonsEnum.WithFocus;
			this._grdCommon_0.ShowSortPosition = C1.Win.C1FlexGrid.ShowSortPositionEnum.None;
			this._grdCommon_0.Size = new System.Drawing.Size(681, 189);
			this._grdCommon_0.Styles.Alternate.BackColor = System.Drawing.SystemColors.Window;
			this._grdCommon_0.Styles.EmptyArea.BackColor = System.Drawing.SystemColors.AppWorkspace;
			this._grdCommon_0.Styles.Fixed.BackColor = System.Drawing.SystemColors.Control;
			this._grdCommon_0.Styles.Fixed.Border.Color = System.Drawing.SystemColors.ControlDark;
			this._grdCommon_0.Styles.Fixed.Border.Direction = C1.Win.C1FlexGrid.BorderDirEnum.Both;
			this._grdCommon_0.Styles.Fixed.Border.Style = C1.Win.C1FlexGrid.BorderStyleEnum.Inset;
			this._grdCommon_0.Styles.Fixed.ForeColor = System.Drawing.SystemColors.ControlText;
			this._grdCommon_0.Styles.Fixed.TextEffect = C1.Win.C1FlexGrid.TextEffectEnum.Flat;
			this._grdCommon_0.Styles.Frozen.BackColor = System.Drawing.Color.Black;
			this._grdCommon_0.Styles.Frozen.ForeColor = System.Drawing.Color.Black;
			this._grdCommon_0.Styles.Highlight.BackColor = System.Drawing.SystemColors.Highlight;
			this._grdCommon_0.Styles.Highlight.ForeColor = System.Drawing.SystemColors.HighlightText;
			this._grdCommon_0.Styles.Normal.Border.Color = System.Drawing.SystemColors.Control;
			this._grdCommon_0.Styles.Normal.Border.Direction = C1.Win.C1FlexGrid.BorderDirEnum.Both;
			this._grdCommon_0.Styles.Normal.Border.Style = C1.Win.C1FlexGrid.BorderStyleEnum.Flat;
			this._grdCommon_0.Styles.Normal.Border.Width = 1;
			this._grdCommon_0.Styles.Normal.ImageAlign = C1.Win.C1FlexGrid.ImageAlignEnum.Stretch;
			this._grdCommon_0.Styles.Normal.TextEffect = C1.Win.C1FlexGrid.TextEffectEnum.Flat;
			this._grdCommon_0.Styles.Normal.Trimming = System.Drawing.StringTrimming.None;
			this._grdCommon_0.Styles.Normal.WordWrap = false;
			this._grdCommon_0.Styles[C1.Win.C1FlexGrid.CellStyleEnum.EmptyArea].Border.Color = System.Drawing.SystemColors.WindowFrame;
			this._grdCommon_0.SubtotalPosition = C1.Win.C1FlexGrid.SubtotalPositionEnum.AboveData;
			this._grdCommon_0.TabIndex = 1;
			this._grdCommon_0.Tree.Column = 0;
			this._grdCommon_0.Tree.LineColor = System.Drawing.SystemColors.ControlDark;
			this._grdCommon_0.Tree.Style = C1.Win.C1FlexGrid.TreeStyleFlags.None;
			this._grdCommon_0.RowColChange += new System.EventHandler(this.grdCommon_RowColChange);
			// 
			// _lblCommon_0
			// 
			this._lblCommon_0.AllowDrop = true;
			this._lblCommon_0.BackColor = System.Drawing.Color.FromArgb(235, 239, 243);
			this._lblCommon_0.Text = "C o n t r a c t  D e t a i l s ";
			this._lblCommon_0.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_0.Location = new System.Drawing.Point(4, 226);
			// // this._lblCommon_0.mLabelId = 1169;
			this._lblCommon_0.Name = "_lblCommon_0";
			this._lblCommon_0.Size = new System.Drawing.Size(136, 13);
			this._lblCommon_0.TabIndex = 2;
			this._lblCommon_0.Tag = "C o n t r a c t  D e t a i l s ";
			// 
			// _grdCommon_1
			// 
			this._grdCommon_1.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None;
			this._grdCommon_1.AllowDrop = true;
			this._grdCommon_1.AllowEditing = false;
			this._grdCommon_1.AllowFreezing = C1.Win.C1FlexGrid.AllowFreezingEnum.None;
			this._grdCommon_1.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.None;
			this._grdCommon_1.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.None;
			this._grdCommon_1.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.Columns;
			this._grdCommon_1.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;
			this._grdCommon_1.AutoResize = true;
			this._grdCommon_1.AutoSearch = C1.Win.C1FlexGrid.AutoSearchEnum.None;
			this._grdCommon_1.AutoSearchDelay = 2;
			this._grdCommon_1.BackColor = System.Drawing.SystemColors.Window;
			this._grdCommon_1.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.Fixed3D;
			this._grdCommon_1.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.Fixed3D;
			this._grdCommon_1.Cols.Count = 10;
			this._grdCommon_1.Cols.Fixed = 1;
			this._grdCommon_1.Cols.Frozen = 0;
			this._grdCommon_1.Cols.MaxSize = 0;
			this._grdCommon_1.Cols.MinSize = 0;
			this._grdCommon_1.Cursor = System.Windows.Forms.Cursors.Default;
			this._grdCommon_1.DrawMode = C1.Win.C1FlexGrid.DrawModeEnum.Normal;
			this._grdCommon_1.Enabled = true;
			this._grdCommon_1.ExtendLastCol = false;
			this._grdCommon_1.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.Light;
			this._grdCommon_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 178);
			this._grdCommon_1.ForeColor = System.Drawing.SystemColors.WindowText;
			this._grdCommon_1.HighLight = C1.Win.C1FlexGrid.HighLightEnum.Always;
			this._grdCommon_1.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.None;
			this._grdCommon_1.Location = new System.Drawing.Point(0, 242);
			this._grdCommon_1.Name = "_grdCommon_1";
			this._grdCommon_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._grdCommon_1.Rows.Count = 50;
			this._grdCommon_1.Rows.Fixed = 1;
			this._grdCommon_1.Rows.Frozen = 0;
			this._grdCommon_1.Rows.MaxSize = 0;
			this._grdCommon_1.Rows.MinSize = 0;
			this._grdCommon_1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this._grdCommon_1.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Default;
			// this._grdCommon_1.ShowButtons = C1.Win.C1FlexGrid.ShowButtonsEnum.WithFocus;
			this._grdCommon_1.ShowSortPosition = C1.Win.C1FlexGrid.ShowSortPositionEnum.None;
			this._grdCommon_1.Size = new System.Drawing.Size(681, 148);
			this._grdCommon_1.Styles.Alternate.BackColor = System.Drawing.SystemColors.Window;
			this._grdCommon_1.Styles.EmptyArea.BackColor = System.Drawing.SystemColors.AppWorkspace;
			this._grdCommon_1.Styles.Fixed.BackColor = System.Drawing.SystemColors.Control;
			this._grdCommon_1.Styles.Fixed.Border.Color = System.Drawing.SystemColors.ControlDark;
			this._grdCommon_1.Styles.Fixed.Border.Direction = C1.Win.C1FlexGrid.BorderDirEnum.Both;
			this._grdCommon_1.Styles.Fixed.Border.Style = C1.Win.C1FlexGrid.BorderStyleEnum.Inset;
			this._grdCommon_1.Styles.Fixed.ForeColor = System.Drawing.SystemColors.ControlText;
			this._grdCommon_1.Styles.Fixed.TextEffect = C1.Win.C1FlexGrid.TextEffectEnum.Flat;
			this._grdCommon_1.Styles.Frozen.BackColor = System.Drawing.Color.Black;
			this._grdCommon_1.Styles.Frozen.ForeColor = System.Drawing.Color.Black;
			this._grdCommon_1.Styles.Highlight.BackColor = System.Drawing.SystemColors.Highlight;
			this._grdCommon_1.Styles.Highlight.ForeColor = System.Drawing.SystemColors.HighlightText;
			this._grdCommon_1.Styles.Normal.Border.Color = System.Drawing.SystemColors.Control;
			this._grdCommon_1.Styles.Normal.Border.Direction = C1.Win.C1FlexGrid.BorderDirEnum.Both;
			this._grdCommon_1.Styles.Normal.Border.Style = C1.Win.C1FlexGrid.BorderStyleEnum.Flat;
			this._grdCommon_1.Styles.Normal.Border.Width = 1;
			this._grdCommon_1.Styles.Normal.ImageAlign = C1.Win.C1FlexGrid.ImageAlignEnum.Stretch;
			this._grdCommon_1.Styles.Normal.TextEffect = C1.Win.C1FlexGrid.TextEffectEnum.Flat;
			this._grdCommon_1.Styles.Normal.Trimming = System.Drawing.StringTrimming.None;
			this._grdCommon_1.Styles.Normal.WordWrap = false;
			this._grdCommon_1.Styles[C1.Win.C1FlexGrid.CellStyleEnum.EmptyArea].Border.Color = System.Drawing.SystemColors.WindowFrame;
			this._grdCommon_1.SubtotalPosition = C1.Win.C1FlexGrid.SubtotalPositionEnum.AboveData;
			this._grdCommon_1.TabIndex = 3;
			this._grdCommon_1.Tree.Column = 0;
			this._grdCommon_1.Tree.LineColor = System.Drawing.SystemColors.ControlDark;
			this._grdCommon_1.Tree.Style = C1.Win.C1FlexGrid.TreeStyleFlags.None;
			this._grdCommon_1.RowColChange += new System.EventHandler(this.grdCommon_RowColChange);
			// 
			// _lblCommon_1
			// 
			this._lblCommon_1.AllowDrop = true;
			this._lblCommon_1.BackColor = System.Drawing.Color.FromArgb(235, 239, 243);
			this._lblCommon_1.Text = "List of Expired Contracts ";
			this._lblCommon_1.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_1.Location = new System.Drawing.Point(4, 10);
			// // this._lblCommon_1.mLabelId = 1168;
			this._lblCommon_1.Name = "_lblCommon_1";
			this._lblCommon_1.Size = new System.Drawing.Size(140, 13);
			this._lblCommon_1.TabIndex = 4;
			this._lblCommon_1.Tag = "List of Expired Contracts ";
			// 
			// cmdSelectContract
			// 
			this.cmdSelectContract.AllowDrop = true;
			this.cmdSelectContract.CancelCaption = "Select &None";
			this.cmdSelectContract.DisplayButton = 0;
			this.cmdSelectContract.Location = new System.Drawing.Point(4, 408);
			this.cmdSelectContract.Name = "cmdSelectContract";
			this.cmdSelectContract.OkCaption = "&Select All";
			this.cmdSelectContract.Size = new System.Drawing.Size(206, 31);
			this.cmdSelectContract.TabIndex = 6;
			this.cmdSelectContract.CancelClick += new UCOkCancel.CancelClickHandler(this.cmdSelectContract_CancelClick);
			this.cmdSelectContract.OKClick += new UCOkCancel.OKClickHandler(this.cmdSelectContract_OKClick);
			// 
			// frmREContractRenewal
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.ClientSize = new System.Drawing.Size(788, 512);
			this.Controls.Add(this.cmdOkCancel);
			this.Controls.Add(this.cntMasterDetails);
			this.Controls.Add(this.cmdSelectContract);
			//this.Icon = (System.Drawing.Icon) resources.GetObject("frmREContractRenewal.Icon");
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(33, 132);
			this.MaximizeBox = true;
			this.MinimizeBox = true;
			this.Name = "frmREContractRenewal";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Contract Renewal";
			// this.Activated += new System.EventHandler(this.frmREContractRenewal_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
			// this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
			//((System.ComponentModel.ISupportInitialize) this.cntMasterDetails).EndInit();
			this.cntMasterDetails.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		void ReLoadForm(bool addEvents)
		{
			InitializelblCommon();
			InitializegrdCommon();
			//This form is an MDI child.
			//This code simulates the VB6 
			// functionality of automatically
			// loading and showing an MDI
			// child's parent.
			this.MdiParent = Xtreme.frmSysMain.DefInstance;
			Xtreme.frmSysMain.DefInstance.Show();
		}
		void InitializelblCommon()
		{
			this.lblCommon = new System.Windows.Forms.Label[2];
			this.lblCommon[0] = _lblCommon_0;
			this.lblCommon[1] = _lblCommon_1;
		}
		void InitializegrdCommon()
		{
			this.grdCommon = new C1.Win.C1FlexGrid.C1FlexGrid[2];
			this.grdCommon[0] = _grdCommon_0;
			this.grdCommon[1] = _grdCommon_1;
		}
		#endregion
	}
}//ENDSHERE
