
namespace Xtreme
{
	partial class frmSysReportFind
	{

		#region "Upgrade Support "
		private static frmSysReportFind m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmSysReportFind DefInstance
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
		public static frmSysReportFind CreateInstance()
		{
			frmSysReportFind theInstance = new frmSysReportFind();
			
			return theInstance;
		}
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "_optSearchFromPosition_0", "_optSearchFromPosition_1", "chkMatchExact", "chkMatchCase", "Column_0_grdReportFind", "Column_1_grdReportFind", "grdReportFind", "frmSearchOptions", "txtSearchString", "_lblCommon_0", "tcbSystemForm", "lblCommon", "optSearchFromPosition"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		private System.Windows.Forms.RadioButton _optSearchFromPosition_0;
		private System.Windows.Forms.RadioButton _optSearchFromPosition_1;
		public System.Windows.Forms.CheckBox chkMatchExact;
		public System.Windows.Forms.CheckBox chkMatchCase;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_0_grdReportFind;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_1_grdReportFind;
		public C1.Win.C1TrueDBGrid.C1TrueDBGrid grdReportFind;
		public System.Windows.Forms.GroupBox frmSearchOptions;
		public System.Windows.Forms.TextBox txtSearchString;
		private System.Windows.Forms.Label _lblCommon_0;
		public Syncfusion.Windows.Forms.Tools.CommandBarController tcbSystemForm;
		public System.Windows.Forms.Label[] lblCommon = new System.Windows.Forms.Label[1];
		public System.Windows.Forms.RadioButton[] optSearchFromPosition = new System.Windows.Forms.RadioButton[2];
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSysReportFind));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this.frmSearchOptions = new System.Windows.Forms.GroupBox();
			this._optSearchFromPosition_0 = new System.Windows.Forms.RadioButton();
			this._optSearchFromPosition_1 = new System.Windows.Forms.RadioButton();
			this.chkMatchExact = new System.Windows.Forms.CheckBox();
			this.chkMatchCase = new System.Windows.Forms.CheckBox();
			this.grdReportFind = new C1.Win.C1TrueDBGrid.C1TrueDBGrid();
			this.Column_0_grdReportFind = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.Column_1_grdReportFind = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.txtSearchString = new System.Windows.Forms.TextBox();
			this._lblCommon_0 = new System.Windows.Forms.Label();
			this.tcbSystemForm = new Syncfusion.Windows.Forms.Tools.CommandBarController();
			// //((System.ComponentModel.ISupportInitialize) this.tcbSystemForm).BeginInit();
			this.frmSearchOptions.SuspendLayout();
			this.grdReportFind.SuspendLayout();
			this.SuspendLayout();
			// 
			// frmSearchOptions
			// 
			this.frmSearchOptions.AllowDrop = true;
			this.frmSearchOptions.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			this.frmSearchOptions.Controls.Add(this._optSearchFromPosition_0);
			this.frmSearchOptions.Controls.Add(this._optSearchFromPosition_1);
			this.frmSearchOptions.Controls.Add(this.chkMatchExact);
			this.frmSearchOptions.Controls.Add(this.chkMatchCase);
			this.frmSearchOptions.Controls.Add(this.grdReportFind);
			this.frmSearchOptions.Enabled = true;
			this.frmSearchOptions.ForeColor = System.Drawing.SystemColors.ControlText;
			this.frmSearchOptions.Location = new System.Drawing.Point(8, 76);
			this.frmSearchOptions.Name = "frmSearchOptions";
			this.frmSearchOptions.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.frmSearchOptions.Size = new System.Drawing.Size(333, 209);
			this.frmSearchOptions.TabIndex = 2;
			this.frmSearchOptions.Text = "Search Options";
			this.frmSearchOptions.Visible = true;
			// 
			// _optSearchFromPosition_0
			// 
			this._optSearchFromPosition_0.AllowDrop = true;
			this._optSearchFromPosition_0.Appearance = System.Windows.Forms.Appearance.Normal;
			this._optSearchFromPosition_0.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			this._optSearchFromPosition_0.CausesValidation = true;
			this._optSearchFromPosition_0.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._optSearchFromPosition_0.Checked = true;
			this._optSearchFromPosition_0.Enabled = true;
			this._optSearchFromPosition_0.ForeColor = System.Drawing.SystemColors.ControlText;
			this._optSearchFromPosition_0.Location = new System.Drawing.Point(12, 20);
			this._optSearchFromPosition_0.Name = "_optSearchFromPosition_0";
			this._optSearchFromPosition_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._optSearchFromPosition_0.Size = new System.Drawing.Size(157, 13);
			this._optSearchFromPosition_0.TabIndex = 6;
			this._optSearchFromPosition_0.TabStop = true;
			this._optSearchFromPosition_0.Text = "Search from Current &Position";
			this._optSearchFromPosition_0.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._optSearchFromPosition_0.Visible = true;
			// 
			// _optSearchFromPosition_1
			// 
			this._optSearchFromPosition_1.AllowDrop = true;
			this._optSearchFromPosition_1.Appearance = System.Windows.Forms.Appearance.Normal;
			this._optSearchFromPosition_1.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			this._optSearchFromPosition_1.CausesValidation = true;
			this._optSearchFromPosition_1.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._optSearchFromPosition_1.Checked = false;
			this._optSearchFromPosition_1.Enabled = true;
			this._optSearchFromPosition_1.ForeColor = System.Drawing.SystemColors.ControlText;
			this._optSearchFromPosition_1.Location = new System.Drawing.Point(12, 39);
			this._optSearchFromPosition_1.Name = "_optSearchFromPosition_1";
			this._optSearchFromPosition_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._optSearchFromPosition_1.Size = new System.Drawing.Size(157, 13);
			this._optSearchFromPosition_1.TabIndex = 5;
			this._optSearchFromPosition_1.TabStop = true;
			this._optSearchFromPosition_1.Text = "Search from &Beginning ";
			this._optSearchFromPosition_1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._optSearchFromPosition_1.Visible = true;
			// 
			// chkMatchExact
			// 
			this.chkMatchExact.AllowDrop = true;
			this.chkMatchExact.Appearance = System.Windows.Forms.Appearance.Normal;
			this.chkMatchExact.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			this.chkMatchExact.CausesValidation = true;
			this.chkMatchExact.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkMatchExact.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this.chkMatchExact.Enabled = true;
			this.chkMatchExact.ForeColor = System.Drawing.SystemColors.ControlText;
			this.chkMatchExact.Location = new System.Drawing.Point(174, 20);
			this.chkMatchExact.Name = "chkMatchExact";
			this.chkMatchExact.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.chkMatchExact.Size = new System.Drawing.Size(131, 15);
			this.chkMatchExact.TabIndex = 4;
			this.chkMatchExact.TabStop = true;
			this.chkMatchExact.Text = "Find &Whole Word Only";
			this.chkMatchExact.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkMatchExact.Visible = true;
			// 
			// chkMatchCase
			// 
			this.chkMatchCase.AllowDrop = true;
			this.chkMatchCase.Appearance = System.Windows.Forms.Appearance.Normal;
			this.chkMatchCase.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			this.chkMatchCase.CausesValidation = true;
			this.chkMatchCase.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkMatchCase.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this.chkMatchCase.Enabled = true;
			this.chkMatchCase.ForeColor = System.Drawing.SystemColors.ControlText;
			this.chkMatchCase.Location = new System.Drawing.Point(174, 39);
			this.chkMatchCase.Name = "chkMatchCase";
			this.chkMatchCase.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.chkMatchCase.Size = new System.Drawing.Size(131, 15);
			this.chkMatchCase.TabIndex = 3;
			this.chkMatchCase.TabStop = true;
			this.chkMatchCase.Text = "Ma&tch Case";
			this.chkMatchCase.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkMatchCase.Visible = true;
			// 
			// grdReportFind
			// 
			this.grdReportFind.AllowDrop = true;
			this.grdReportFind.BackColor = System.Drawing.Color.FromArgb(236, 233, 216);
			this.grdReportFind.CellTipsWidth = 0;
			this.grdReportFind.Location = new System.Drawing.Point(14, 62);
			this.grdReportFind.Name = "grdReportFind";
			this.grdReportFind.RowDivider.Color = System.Drawing.Color.FromArgb(236, 233, 216);
			this.grdReportFind.Size = new System.Drawing.Size(305, 139);
			this.grdReportFind.TabIndex = 7;
			this.grdReportFind.Columns.Add(this.Column_0_grdReportFind);
			this.grdReportFind.Columns.Add(this.Column_1_grdReportFind);
			this.grdReportFind.BeforeColEdit += new C1.Win.C1TrueDBGrid.BeforeColEditEventHandler(this.grdReportFind_BeforeColEdit);
			// this.this.grdReportFind.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.grdReportFind_KeyPress);
			this.grdReportFind.MouseUp += new System.Windows.Forms.MouseEventHandler(this.grdReportFind_MouseUp);
			// 
			// Column_0_grdReportFind
			// 
			this.Column_0_grdReportFind.DataField = "";
			this.Column_0_grdReportFind.ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.Normal;
			// 
			// Column_1_grdReportFind
			// 
			this.Column_1_grdReportFind.DataField = "";
			this.Column_1_grdReportFind.ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.Normal;
			// 
			// txtSearchString
			// 
			this.txtSearchString.AllowDrop = true;
			this.txtSearchString.BackColor = System.Drawing.Color.White;
			this.txtSearchString.ForeColor = System.Drawing.Color.Black;
			this.txtSearchString.Location = new System.Drawing.Point(113, 48);
			// this.txtSearchString.mDropDownType = (System.Windows.Forms.TextBox.DropDownTypes) 0;
			this.txtSearchString.Name = "txtSearchString";
			this.txtSearchString.Size = new System.Drawing.Size(228, 19);
			this.txtSearchString.TabIndex = 0;
			this.txtSearchString.Text = "";
			// this.this.txtSearchString.Watermark = "";
			// this.this.txtSearchString.KeyDown += new System.Windows.Forms.TextBox.KeyDownHandler(this.txtSearchString_KeyDown);
			// 
			// _lblCommon_0
			// 
			this._lblCommon_0.AllowDrop = true;
			this._lblCommon_0.BackColor = System.Drawing.SystemColors.Window;
			this._lblCommon_0.Text = "Search Expression :";
			this._lblCommon_0.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_0.Location = new System.Drawing.Point(14, 50);
			this._lblCommon_0.Name = "_lblCommon_0";
			this._lblCommon_0.Size = new System.Drawing.Size(95, 13);
			this._lblCommon_0.TabIndex = 1;
			// 
			// tcbSystemForm
			// 
			this.tcbSystemForm.AllowDrop = true;
			this.tcbSystemForm.Location = new System.Drawing.Point(0, 0);
			this.tcbSystemForm.Name = "tcbSystemForm";
			//
			// 
			// frmSysReportFind
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			this.ClientSize = new System.Drawing.Size(347, 290);
			this.ControlBox = false;
			this.Controls.Add(this.frmSearchOptions);
			this.Controls.Add(this.txtSearchString);
			this.Controls.Add(this._lblCommon_0);
			this.Controls.Add(this.tcbSystemForm);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			//this.Icon = (System.Drawing.Icon) resources.GetObject("frmSysReportFind.Icon");
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(372, 282);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmSysReportFind";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Tag = "Find Record";
			this.Text = "Find Record";
			// this.Activated += new System.EventHandler(this.frmSysReportFind_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
			// this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
			//((System.ComponentModel.ISupportInitialize) this.tcbSystemForm).EndInit();
			this.frmSearchOptions.ResumeLayout(false);
			this.grdReportFind.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		// 
		void InitializeoptSearchFromPosition()
		{
			this.optSearchFromPosition = new System.Windows.Forms.RadioButton[2];
			this.optSearchFromPosition[0] = _optSearchFromPosition_0;
			this.optSearchFromPosition[1] = _optSearchFromPosition_1;
		}
		void InitializelblCommon()
		{
			this.lblCommon = new System.Windows.Forms.Label[1];
			this.lblCommon[0] = _lblCommon_0;
		}
		#endregion
	}
}//ENDSHERE
