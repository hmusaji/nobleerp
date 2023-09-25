
namespace Xtreme
{
	partial class frmICSAlternateUnit
	{

		#region "Upgrade Support "
		private static frmICSAlternateUnit m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmICSAlternateUnit DefInstance
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
		public static frmICSAlternateUnit CreateInstance()
		{
			frmICSAlternateUnit theInstance = new frmICSAlternateUnit();
			
			return theInstance;
		}
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "_cmdOkCancel_2", "Column_0_cmbAltUnit", "Column_1_cmbAltUnit", "cmbAltUnit", "Column_0_grdVoucherDetails", "grdVoucherDetails", "cmdOkCancel"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		private System.Windows.Forms.Button _cmdOkCancel_2;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_0_cmbAltUnit;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_1_cmbAltUnit;
		public C1.Win.C1TrueDBGrid.C1TrueDBDropdown cmbAltUnit;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_0_grdVoucherDetails;
		public C1.Win.C1TrueDBGrid.C1TrueDBGrid grdVoucherDetails;
		public System.Windows.Forms.Button[] cmdOkCancel = new System.Windows.Forms.Button[3];
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmICSAlternateUnit));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this._cmdOkCancel_2 = new System.Windows.Forms.Button();
			this.cmbAltUnit = new C1.Win.C1TrueDBGrid.C1TrueDBDropdown();
			this.Column_0_cmbAltUnit = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.Column_1_cmbAltUnit = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.grdVoucherDetails = new C1.Win.C1TrueDBGrid.C1TrueDBGrid();
			this.Column_0_grdVoucherDetails = new C1.Win.C1TrueDBGrid.C1DataColumn();
			// //((System.ComponentModel.ISupportInitialize) this._cmdOkCancel_2).BeginInit();
			//this.cmbAltUnit.SuspendLayout();
			//this.grdVoucherDetails.SuspendLayout();
			this.SuspendLayout();
			// 
			// _cmdOkCancel_2
			// 
			this._cmdOkCancel_2.AllowDrop = true;
			this._cmdOkCancel_2.Location = new System.Drawing.Point(308, 112);
			this._cmdOkCancel_2.Name = "_cmdOkCancel_2";
			//
			this._cmdOkCancel_2.Size = new System.Drawing.Size(69, 27);
			this._cmdOkCancel_2.TabIndex = 2;
			//// this._cmdOkCancel_2.ClickEvent += new System.EventHandler(this.cmdOkCancel_ClickEvent);
			// 
			// cmbAltUnit
			// 
			this.cmbAltUnit.AllowDrop = true;
			this.cmbAltUnit.ColumnHeaders = true;
			this.cmbAltUnit.Enabled = true;
			this.cmbAltUnit.Location = new System.Drawing.Point(18, 110);
			this.cmbAltUnit.Name = "cmbAltUnit";
			this.cmbAltUnit.Size = new System.Drawing.Size(203, 97);
			this.cmbAltUnit.TabIndex = 0;
			this.cmbAltUnit.Columns.Add(this.Column_0_cmbAltUnit);
			this.cmbAltUnit.Columns.Add(this.Column_1_cmbAltUnit);
			// 
			// Column_0_cmbAltUnit
			// 
			this.Column_0_cmbAltUnit.DataField = "";
			this.Column_0_cmbAltUnit.ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.Normal;
			// 
			// Column_1_cmbAltUnit
			// 
			this.Column_1_cmbAltUnit.DataField = "";
			this.Column_1_cmbAltUnit.ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.Normal;
			// 
			// grdVoucherDetails
			// 
			this.grdVoucherDetails.AllowAddNew = true;
			this.grdVoucherDetails.AllowDelete = true;
			this.grdVoucherDetails.AllowDrop = true;
			this.grdVoucherDetails.BackColor = System.Drawing.Color.Silver;
			this.grdVoucherDetails.CellTipsWidth = 0;
			this.grdVoucherDetails.Location = new System.Drawing.Point(2, 2);
			this.grdVoucherDetails.Name = "grdVoucherDetails";
			this.grdVoucherDetails.RowDivider.Color = System.Drawing.Color.Silver;
			this.grdVoucherDetails.Size = new System.Drawing.Size(387, 107);
			this.grdVoucherDetails.TabIndex = 1;
			this.grdVoucherDetails.Columns.Add(this.Column_0_grdVoucherDetails);
			// 
			// Column_0_grdVoucherDetails
			// 
			this.Column_0_grdVoucherDetails.DataField = "";
			this.Column_0_grdVoucherDetails.ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.Normal;
			// 
			// frmICSAlternateUnit
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.ClientSize = new System.Drawing.Size(391, 142);
			this.ControlBox = false;
			this.Controls.Add(this._cmdOkCancel_2);
			this.Controls.Add(this.cmbAltUnit);
			this.Controls.Add(this.grdVoucherDetails);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			//this.Icon = (System.Drawing.Icon) resources.GetObject("frmICSAlternateUnit.Icon");
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(302, 242);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmICSAlternateUnit";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.ShowInTaskbar = false;
			this.Text = "Alternate Unit";
			// this.Activated += new System.EventHandler(this.Form_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
			// this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
			//((System.ComponentModel.ISupportInitialize) this._cmdOkCancel_2).EndInit();
			this.cmbAltUnit.ResumeLayout(false);
			this.grdVoucherDetails.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		// 
		void InitializecmdOkCancel()
		{
			this.cmdOkCancel = new System.Windows.Forms.Button[3];
			this.cmdOkCancel[2] = _cmdOkCancel_2;
		}
		#endregion
	}
}//ENDSHERE
