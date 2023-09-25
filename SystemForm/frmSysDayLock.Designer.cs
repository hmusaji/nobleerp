
namespace Xtreme
{
	partial class frmSysDayLock
	{

		#region "Upgrade Support "
		private static frmSysDayLock m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmSysDayLock DefInstance
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
		public static frmSysDayLock CreateInstance()
		{
			frmSysDayLock theInstance = new frmSysDayLock();
			
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
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "cmdSelect", "txtFromDate", "_lblCommonLabel_6", "txtToDate", "_lblCommonLabel_0", "Column_0_grdDays", "Column_1_grdDays", "grdDays", "lblCommonLabel"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public System.Windows.Forms.Button cmdSelect;
		public Syncfusion.WinForms.Input.SfDateTimeEdit txtFromDate;
		private System.Windows.Forms.Label _lblCommonLabel_6;
		public Syncfusion.WinForms.Input.SfDateTimeEdit txtToDate;
		private System.Windows.Forms.Label _lblCommonLabel_0;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_0_grdDays;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_1_grdDays;
		public C1.Win.C1TrueDBGrid.C1TrueDBGrid grdDays;
		public System.Windows.Forms.Label[] lblCommonLabel = new System.Windows.Forms.Label[7];
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSysDayLock));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this.cmdSelect = new System.Windows.Forms.Button();
			this.txtFromDate = new Syncfusion.WinForms.Input.SfDateTimeEdit();
			this._lblCommonLabel_6 = new System.Windows.Forms.Label();
			this.txtToDate = new Syncfusion.WinForms.Input.SfDateTimeEdit();
			this._lblCommonLabel_0 = new System.Windows.Forms.Label();
			this.grdDays = new C1.Win.C1TrueDBGrid.C1TrueDBGrid();
			this.Column_0_grdDays = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.Column_1_grdDays = new C1.Win.C1TrueDBGrid.C1DataColumn();
			//this.grdDays.SuspendLayout();
			this.SuspendLayout();
			// 
			// cmdSelect
			// 
			this.cmdSelect.AllowDrop = true;
			this.cmdSelect.BackColor = System.Drawing.SystemColors.Control;
			this.cmdSelect.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdSelect.Location = new System.Drawing.Point(204, 36);
			this.cmdSelect.Name = "cmdSelect";
			this.cmdSelect.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdSelect.Size = new System.Drawing.Size(67, 23);
			this.cmdSelect.TabIndex = 4;
			this.cmdSelect.Text = "&Select";
			this.cmdSelect.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.cmdSelect.UseVisualStyleBackColor = false;
			// this.cmdSelect.Click += new System.EventHandler(this.cmdSelect_Click);
			// 
			// txtFromDate
			// 
			this.txtFromDate.AllowDrop = true;
			// this.txtFromDate.CheckDateRange = false;
			this.txtFromDate.Location = new System.Drawing.Point(92, 12);
			// this.txtFromDate.MaxDate = 2958465;
			// this.txtFromDate.MinDate = 32874;
			this.txtFromDate.Name = "txtFromDate";
			this.txtFromDate.Size = new System.Drawing.Size(102, 19);
			this.txtFromDate.TabIndex = 0;
			// this.txtFromDate.Text = "7/18/2001";
			// this.txtFromDate.Value = 37090;
			// 
			// _lblCommonLabel_6
			// 
			this._lblCommonLabel_6.AllowDrop = true;
			this._lblCommonLabel_6.BackColor = System.Drawing.SystemColors.Window;
			this._lblCommonLabel_6.Text = "From Date :";
			this._lblCommonLabel_6.ForeColor = System.Drawing.Color.Black;
			this._lblCommonLabel_6.Location = new System.Drawing.Point(12, 14);
			this._lblCommonLabel_6.Name = "_lblCommonLabel_6";
			this._lblCommonLabel_6.Size = new System.Drawing.Size(55, 14);
			this._lblCommonLabel_6.TabIndex = 1;
			// 
			// txtToDate
			// 
			this.txtToDate.AllowDrop = true;
			// this.txtToDate.CheckDateRange = false;
			this.txtToDate.Location = new System.Drawing.Point(92, 36);
			// this.txtToDate.MaxDate = 2958465;
			// this.txtToDate.MinDate = 32874;
			this.txtToDate.Name = "txtToDate";
			this.txtToDate.Size = new System.Drawing.Size(102, 19);
			this.txtToDate.TabIndex = 2;
			// this.txtToDate.Text = "7/18/2001";
			// this.txtToDate.Value = 37090;
			// 
			// _lblCommonLabel_0
			// 
			this._lblCommonLabel_0.AllowDrop = true;
			this._lblCommonLabel_0.BackColor = System.Drawing.SystemColors.Window;
			this._lblCommonLabel_0.Text = "To Date :";
			this._lblCommonLabel_0.ForeColor = System.Drawing.Color.Black;
			this._lblCommonLabel_0.Location = new System.Drawing.Point(12, 38);
			this._lblCommonLabel_0.Name = "_lblCommonLabel_0";
			this._lblCommonLabel_0.Size = new System.Drawing.Size(43, 14);
			this._lblCommonLabel_0.TabIndex = 3;
			// 
			// grdDays
			// 
			this.grdDays.AllowDrop = true;
			this.grdDays.BackColor = System.Drawing.Color.FromArgb(212, 208, 200);
			this.grdDays.CellTipsWidth = 0;
			this.grdDays.Location = new System.Drawing.Point(2, 68);
			this.grdDays.Name = "grdDays";
			this.grdDays.RowDivider.Color = System.Drawing.Color.FromArgb(212, 208, 200);
			this.grdDays.Size = new System.Drawing.Size(383, 313);
			this.grdDays.TabIndex = 5;
			this.grdDays.Columns.Add(this.Column_0_grdDays);
			this.grdDays.Columns.Add(this.Column_1_grdDays);
			// this.this.grdDays.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.grdDays_KeyPress);
			this.grdDays.MouseUp += new System.Windows.Forms.MouseEventHandler(this.grdDays_MouseUp);
			// 
			// Column_0_grdDays
			// 
			this.Column_0_grdDays.DataField = "";
			this.Column_0_grdDays.ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.Normal;
			// 
			// Column_1_grdDays
			// 
			this.Column_1_grdDays.DataField = "";
			this.Column_1_grdDays.ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.Normal;
			// 
			// frmSysDayLock
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.ClientSize = new System.Drawing.Size(388, 421);
			this.Controls.Add(this.cmdSelect);
			this.Controls.Add(this.txtFromDate);
			this.Controls.Add(this._lblCommonLabel_6);
			this.Controls.Add(this.txtToDate);
			this.Controls.Add(this._lblCommonLabel_0);
			this.Controls.Add(this.grdDays);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			//this.Icon = (System.Drawing.Icon) resources.GetObject("frmSysDayLock.Icon");
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(387, 123);
			this.MaximizeBox = true;
			this.MinimizeBox = true;
			this.Name = "frmSysDayLock";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Day Lock";
			// this.Activated += new System.EventHandler(this.frmSysDayLock_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
			// this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
			this.grdDays.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		// 
		void InitializelblCommonLabel()
		{
			this.lblCommonLabel = new System.Windows.Forms.Label[7];
			this.lblCommonLabel[6] = _lblCommonLabel_6;
			this.lblCommonLabel[0] = _lblCommonLabel_0;
		}
		#endregion
	}
}//ENDSHERE
