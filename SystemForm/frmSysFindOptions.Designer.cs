
namespace Xtreme
{
	partial class frmSysFindOptions
	{

		#region "Upgrade Support "
		private static frmSysFindOptions m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmSysFindOptions DefInstance
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
		public static frmSysFindOptions CreateInstance()
		{
			frmSysFindOptions theInstance = new frmSysFindOptions();
			
			return theInstance;
		}
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "chkAdvancedOptions", "fraReportOptions", "tabReportOptions", "_lblCommon_3", "Column_0_grdReportOptions", "Column_1_grdReportOptions", "grdReportOptions", "Column_0_cmbSearchList", "Column_1_cmbSearchList", "cmbSearchList", "tcbSystemForm", "lblCommon"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public System.Windows.Forms.CheckBox chkAdvancedOptions;
		public System.Windows.Forms.Panel fraReportOptions;
		public AxC1SizerLib.AxC1Tab tabReportOptions;
		private System.Windows.Forms.Label _lblCommon_3;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_0_grdReportOptions;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_1_grdReportOptions;
		public C1.Win.C1TrueDBGrid.C1TrueDBGrid grdReportOptions;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_0_cmbSearchList;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_1_cmbSearchList;
		public C1.Win.C1TrueDBGrid.C1TrueDBDropdown cmbSearchList;
		public Syncfusion.Windows.Forms.Tools.CommandBarController tcbSystemForm;
		public System.Windows.Forms.Label[] lblCommon = new System.Windows.Forms.Label[4];
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSysFindOptions));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this.chkAdvancedOptions = new System.Windows.Forms.CheckBox();
			this.tabReportOptions = new AxC1SizerLib.AxC1Tab();
			this.fraReportOptions = new System.Windows.Forms.Panel();
			this._lblCommon_3 = new System.Windows.Forms.Label();
			this.grdReportOptions = new C1.Win.C1TrueDBGrid.C1TrueDBGrid();
			this.Column_0_grdReportOptions = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.Column_1_grdReportOptions = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.cmbSearchList = new C1.Win.C1TrueDBGrid.C1TrueDBDropdown();
			this.Column_0_cmbSearchList = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.Column_1_cmbSearchList = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.tcbSystemForm = new Syncfusion.Windows.Forms.Tools.CommandBarController();
			// //((System.ComponentModel.ISupportInitialize) this.tabReportOptions).BeginInit();
			// //((System.ComponentModel.ISupportInitialize) this.tcbSystemForm).BeginInit();
			this.tabReportOptions.SuspendLayout();
			this.grdReportOptions.SuspendLayout();
			this.cmbSearchList.SuspendLayout();
			this.SuspendLayout();
			// 
			// chkAdvancedOptions
			// 
			this.chkAdvancedOptions.AllowDrop = true;
			this.chkAdvancedOptions.Appearance = System.Windows.Forms.Appearance.Normal;
			this.chkAdvancedOptions.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.chkAdvancedOptions.CausesValidation = true;
			this.chkAdvancedOptions.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkAdvancedOptions.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this.chkAdvancedOptions.Enabled = true;
			this.chkAdvancedOptions.ForeColor = System.Drawing.SystemColors.ControlText;
			this.chkAdvancedOptions.Location = new System.Drawing.Point(100, 40);
			this.chkAdvancedOptions.Name = "chkAdvancedOptions";
			this.chkAdvancedOptions.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.chkAdvancedOptions.Size = new System.Drawing.Size(145, 13);
			this.chkAdvancedOptions.TabIndex = 2;
			this.chkAdvancedOptions.TabStop = true;
			this.chkAdvancedOptions.Text = "Show Advanced O&ptions";
			this.chkAdvancedOptions.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkAdvancedOptions.Visible = false;
			this.chkAdvancedOptions.CheckStateChanged += new System.EventHandler(this.chkAdvancedOptions_CheckStateChanged);
			// 
			// tabReportOptions
			// 
			this.tabReportOptions.Align = C1SizerLib.AlignSettings.asNone;
			this.tabReportOptions.AllowDrop = true;
			this.tabReportOptions.Controls.Add(this.fraReportOptions);
			this.tabReportOptions.Location = new System.Drawing.Point(4, 338);
			this.tabReportOptions.Name = "tabReportOptions";
			("tabReportOptions.OcxState");
			this.tabReportOptions.Size = new System.Drawing.Size(51, 33);
			this.tabReportOptions.TabIndex = 0;
			this.tabReportOptions.TabStop = false;
			//// this.tabReportOptions.ClickEvent += new System.EventHandler(this.tabReportOptions_ClickEvent);
			// 
			// fraReportOptions
			// 
			this.fraReportOptions.AllowDrop = true;
			this.fraReportOptions.BackColor = System.Drawing.SystemColors.Control;
			this.fraReportOptions.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.fraReportOptions.Enabled = true;
			this.fraReportOptions.ForeColor = System.Drawing.SystemColors.ControlText;
			this.fraReportOptions.Location = new System.Drawing.Point(2, 24);
			this.fraReportOptions.Name = "fraReportOptions";
			this.fraReportOptions.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.fraReportOptions.Size = new System.Drawing.Size(46, 7);
			this.fraReportOptions.TabIndex = 1;
			this.fraReportOptions.Visible = true;
			// 
			// _lblCommon_3
			// 
			this._lblCommon_3.AllowDrop = true;
			this._lblCommon_3.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_3.Text = "Filter Range:";
			this._lblCommon_3.Location = new System.Drawing.Point(2, 42);
			this._lblCommon_3.Name = "_lblCommon_3";
			this._lblCommon_3.Size = new System.Drawing.Size(62, 13);
			this._lblCommon_3.TabIndex = 3;
			this._lblCommon_3.Visible = false;
			// 
			// grdReportOptions
			// 
			this.grdReportOptions.AllowDrop = true;
			this.grdReportOptions.BackColor = System.Drawing.Color.FromArgb(236, 233, 216);
			this.grdReportOptions.CellTipsWidth = 0;
			this.grdReportOptions.Location = new System.Drawing.Point(102, 62);
			this.grdReportOptions.Name = "grdReportOptions";
			this.grdReportOptions.RowDivider.Color = System.Drawing.Color.FromArgb(236, 233, 216);
			this.grdReportOptions.Size = new System.Drawing.Size(91, 115);
			this.grdReportOptions.TabIndex = 4;
			this.grdReportOptions.Columns.Add(this.Column_0_grdReportOptions);
			this.grdReportOptions.Columns.Add(this.Column_1_grdReportOptions);
			this.grdReportOptions.BeforeColEdit += new C1.Win.C1TrueDBGrid.BeforeColEditEventHandler(this.grdReportOptions_BeforeColEdit);
			// this.this.grdReportOptions.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.grdReportOptions_KeyPress);
			this.grdReportOptions.MouseUp += new System.Windows.Forms.MouseEventHandler(this.grdReportOptions_MouseUp);
			this.grdReportOptions.RowColChange += new C1.Win.C1TrueDBGrid.RowColChangeEventHandler(this.grdReportOptions_RowColChange);
			// 
			// Column_0_grdReportOptions
			// 
			this.Column_0_grdReportOptions.DataField = "";
			this.Column_0_grdReportOptions.ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.Normal;
			// 
			// Column_1_grdReportOptions
			// 
			this.Column_1_grdReportOptions.DataField = "";
			this.Column_1_grdReportOptions.ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.Normal;
			// 
			// cmbSearchList
			// 
			this.cmbSearchList.AllowDrop = true;
			this.cmbSearchList.ColumnHeaders = true;
			this.cmbSearchList.Enabled = true;
			this.cmbSearchList.Location = new System.Drawing.Point(0, 62);
			this.cmbSearchList.Name = "cmbSearchList";
			this.cmbSearchList.Size = new System.Drawing.Size(101, 117);
			this.cmbSearchList.TabIndex = 5;
			this.cmbSearchList.Columns.Add(this.Column_0_cmbSearchList);
			this.cmbSearchList.Columns.Add(this.Column_1_cmbSearchList);
			// 
			// Column_0_cmbSearchList
			// 
			this.Column_0_cmbSearchList.DataField = "";
			this.Column_0_cmbSearchList.ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.Normal;
			// 
			// Column_1_cmbSearchList
			// 
			this.Column_1_cmbSearchList.DataField = "";
			this.Column_1_cmbSearchList.ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.Normal;
			// 
			// tcbSystemForm
			// 
			this.tcbSystemForm.AllowDrop = true;
			this.tcbSystemForm.Location = new System.Drawing.Point(0, 0);
			this.tcbSystemForm.Name = "tcbSystemForm";
			("tcbSystemForm.OcxState");
			// 
			// frmSysFindOptions
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.ClientSize = new System.Drawing.Size(520, 256);
			this.ControlBox = false;
			this.Controls.Add(this.chkAdvancedOptions);
			this.Controls.Add(this.tabReportOptions);
			this.Controls.Add(this._lblCommon_3);
			this.Controls.Add(this.grdReportOptions);
			this.Controls.Add(this.cmbSearchList);
			this.Controls.Add(this.tcbSystemForm);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			//this.Icon = (System.Drawing.Icon) resources.GetObject("frmSysFindOptions.Icon");
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(374, 187);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmSysFindOptions";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Tag = "Find Record";
			this.Text = "Find Options";
			// this.Activated += new System.EventHandler(this.frmSysFindOptions_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
			// this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
			//((System.ComponentModel.ISupportInitialize) this.tabReportOptions).EndInit();
			//((System.ComponentModel.ISupportInitialize) this.tcbSystemForm).EndInit();
			this.tabReportOptions.ResumeLayout(false);
			this.grdReportOptions.ResumeLayout(false);
			this.cmbSearchList.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		void ReLoadForm(bool addEvents)
		{
			InitializelblCommon();
		}
		void InitializelblCommon()
		{
			this.lblCommon = new System.Windows.Forms.Label[4];
			this.lblCommon[3] = _lblCommon_3;
		}
		#endregion
	}
}