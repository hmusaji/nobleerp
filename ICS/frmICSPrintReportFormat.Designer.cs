
namespace Xtreme
{
	partial class frmICSPrintReportFormat
	{

		#region "Upgrade Support "
		private static frmICSPrintReportFormat m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmICSPrintReportFormat DefInstance
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
		public static frmICSPrintReportFormat CreateInstance()
		{
			frmICSPrintReportFormat theInstance = new frmICSPrintReportFormat();
			
			return theInstance;
		}
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "cmdOK", "cmdCancle", "Column_0_rptGrid", "Column_1_rptGrid", "rptGrid"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public System.Windows.Forms.Button cmdOK;
		public System.Windows.Forms.Button cmdCancle;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_0_rptGrid;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_1_rptGrid;
		public C1.Win.C1TrueDBGrid.C1TrueDBGrid rptGrid;
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmICSPrintReportFormat));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this.cmdOK = new System.Windows.Forms.Button();
			this.cmdCancle = new System.Windows.Forms.Button();
			this.rptGrid = new C1.Win.C1TrueDBGrid.C1TrueDBGrid();
			this.Column_0_rptGrid = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.Column_1_rptGrid = new C1.Win.C1TrueDBGrid.C1DataColumn();
			//this.rptGrid.SuspendLayout();
			this.SuspendLayout();
			// 
			// cmdOK
			// 
			this.cmdOK.AllowDrop = true;
			this.cmdOK.BackColor = System.Drawing.SystemColors.Control;
			this.cmdOK.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdOK.Location = new System.Drawing.Point(186, 118);
			this.cmdOK.Name = "cmdOK";
			this.cmdOK.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdOK.Size = new System.Drawing.Size(71, 29);
			this.cmdOK.TabIndex = 1;
			this.cmdOK.Text = "&Ok";
			this.cmdOK.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.cmdOK.UseVisualStyleBackColor = false;
			// this.cmdOK.Click += new System.EventHandler(this.cmdOk_Click);
			// 
			// cmdCancle
			// 
			this.cmdCancle.AllowDrop = true;
			this.cmdCancle.BackColor = System.Drawing.SystemColors.Control;
			this.cmdCancle.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdCancle.Location = new System.Drawing.Point(258, 118);
			this.cmdCancle.Name = "cmdCancle";
			this.cmdCancle.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdCancle.Size = new System.Drawing.Size(71, 29);
			this.cmdCancle.TabIndex = 2;
			this.cmdCancle.Text = "&Cancel";
			this.cmdCancle.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.cmdCancle.UseVisualStyleBackColor = false;
			// this.cmdCancle.Click += new System.EventHandler(this.cmdCancle_Click);
			// 
			// rptGrid
			// 
			this.rptGrid.AllowDrop = true;
			this.rptGrid.BackColor = System.Drawing.Color.FromArgb(212, 208, 200);
			this.rptGrid.CellTipsWidth = 0;
			this.rptGrid.Location = new System.Drawing.Point(4, 4);
			this.rptGrid.Name = "rptGrid";
			this.rptGrid.RowDivider.Color = System.Drawing.Color.FromArgb(212, 208, 200);
			this.rptGrid.Size = new System.Drawing.Size(323, 111);
			this.rptGrid.TabIndex = 0;
			this.rptGrid.Columns.Add(this.Column_0_rptGrid);
			this.rptGrid.Columns.Add(this.Column_1_rptGrid);
			// this.this.rptGrid.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.rptGrid_KeyPress);
			this.rptGrid.MouseUp += new System.Windows.Forms.MouseEventHandler(this.rptGrid_MouseUp);
			// 
			// Column_0_rptGrid
			// 
			this.Column_0_rptGrid.DataField = "";
			this.Column_0_rptGrid.ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.Normal;
			// 
			// Column_1_rptGrid
			// 
			this.Column_1_rptGrid.DataField = "";
			this.Column_1_rptGrid.ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.Normal;
			// 
			// frmICSPrintReportFormat
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.ClientSize = new System.Drawing.Size(332, 152);
			this.ControlBox = false;
			this.Controls.Add(this.cmdOK);
			this.Controls.Add(this.cmdCancle);
			this.Controls.Add(this.rptGrid);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			//this.Icon = (System.Drawing.Icon) resources.GetObject("frmICSPrintReportFormat.Icon");
			this.Location = new System.Drawing.Point(198, 241);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmICSPrintReportFormat";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Print Format's";
			// this.Activated += new System.EventHandler(this.frmICSPrintReportFormat_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
			this.rptGrid.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		#endregion
	}
}//ENDSHERE
