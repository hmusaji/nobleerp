
namespace Xtreme
{
	partial class frmICSProductAssemblyDetails
	{

		#region "Upgrade Support "
		private static frmICSProductAssemblyDetails m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmICSProductAssemblyDetails DefInstance
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
		public static frmICSProductAssemblyDetails CreateInstance()
		{
			frmICSProductAssemblyDetails theInstance = new frmICSProductAssemblyDetails();
			
			return theInstance;
		}
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "Column_0_grdVoucherDetails", "Column_1_grdVoucherDetails", "grdVoucherDetails", "lblCommon", "cmdOKCancel", "txtTotalQty"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_0_grdVoucherDetails;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_1_grdVoucherDetails;
		public C1.Win.C1TrueDBGrid.C1TrueDBGrid grdVoucherDetails;
		public System.Windows.Forms.Label lblCommon;
		public UCOkCancel cmdOKCancel;
		public System.Windows.Forms.Label txtTotalQty;
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmICSProductAssemblyDetails));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this.grdVoucherDetails = new C1.Win.C1TrueDBGrid.C1TrueDBGrid();
			this.Column_0_grdVoucherDetails = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.Column_1_grdVoucherDetails = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.lblCommon = new System.Windows.Forms.Label();
			this.cmdOKCancel = new UCOkCancel();
			this.txtTotalQty = new System.Windows.Forms.Label();
			this.grdVoucherDetails.SuspendLayout();
			this.SuspendLayout();
			// 
			// grdVoucherDetails
			// 
			this.grdVoucherDetails.AllowDrop = true;
			this.grdVoucherDetails.BackColor = System.Drawing.Color.Silver;
			this.grdVoucherDetails.CellTipsWidth = 0;
			this.grdVoucherDetails.Location = new System.Drawing.Point(0, 0);
			this.grdVoucherDetails.Name = "grdVoucherDetails";
			this.grdVoucherDetails.RowDivider.Color = System.Drawing.Color.Silver;
			this.grdVoucherDetails.Size = new System.Drawing.Size(717, 140);
			this.grdVoucherDetails.TabIndex = 0;
			this.grdVoucherDetails.Columns.Add(this.Column_0_grdVoucherDetails);
			this.grdVoucherDetails.Columns.Add(this.Column_1_grdVoucherDetails);
			this.grdVoucherDetails.AfterColUpdate += new C1.Win.C1TrueDBGrid.ColEventHandler(this.grdVoucherDetails_AfterColUpdate);
			this.grdVoucherDetails.BeforeColUpdate += new C1.Win.C1TrueDBGrid.BeforeColUpdateEventHandler(this.grdVoucherDetails_BeforeColUpdate);
			this.grdVoucherDetails.ButtonClick += new C1.Win.C1TrueDBGrid.ColEventHandler(this.grdVoucherDetails_ButtonClick);
			// this.this.grdVoucherDetails.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.grdVoucherDetails_KeyPress);
			// 
			// Column_0_grdVoucherDetails
			// 
			this.Column_0_grdVoucherDetails.DataField = "";
			this.Column_0_grdVoucherDetails.ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.Normal;
			// 
			// Column_1_grdVoucherDetails
			// 
			this.Column_1_grdVoucherDetails.DataField = "";
			this.Column_1_grdVoucherDetails.ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.Normal;
			// 
			// lblCommon
			// 
			this.lblCommon.AllowDrop = true;
			this.lblCommon.BackColor = System.Drawing.SystemColors.Window;
			this.lblCommon.Text = "Voucher Quantity";
			this.lblCommon.Location = new System.Drawing.Point(8, 175);
			this.lblCommon.Name = "lblCommon";
			this.lblCommon.Size = new System.Drawing.Size(84, 13);
			this.lblCommon.TabIndex = 1;
			// 
			// cmdOKCancel
			// 
			this.cmdOKCancel.AllowDrop = true;
			this.cmdOKCancel.DisplayButton = 0;
			this.cmdOKCancel.Location = new System.Drawing.Point(470, 160);
			this.cmdOKCancel.Name = "cmdOKCancel";
			this.cmdOKCancel.OkCaption = "&Ok";
			this.cmdOKCancel.Size = new System.Drawing.Size(206, 31);
			this.cmdOKCancel.TabIndex = 2;
			//this.cmdOKCancel.CancelClick += new UCOkCancel.CancelClickHandler(this.cmdOKCancel_CancelClick);
			//this.cmdOKCancel.OKClick += new UCOkCancel.OKClickHandler(this.cmdOKCancel_OKClick);
			// 
			// txtTotalQty
			// 
			// this.txtTotalQty.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtTotalQty.AllowDrop = true;
			this.txtTotalQty.Location = new System.Drawing.Point(116, 172);
			this.txtTotalQty.Name = "txtTotalQty";
			this.txtTotalQty.Size = new System.Drawing.Size(101, 19);
			this.txtTotalQty.TabIndex = 3;
			// 
			// frmICSProductAssemblyDetails
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(250, 239, 214);
			this.ClientSize = new System.Drawing.Size(718, 197);
			this.ControlBox = false;
			this.Controls.Add(this.grdVoucherDetails);
			this.Controls.Add(this.lblCommon);
			this.Controls.Add(this.cmdOKCancel);
			this.Controls.Add(this.txtTotalQty);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			//this.Icon = (System.Drawing.Icon) resources.GetObject("frmICSProductAssemblyDetails.Icon");
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(16, 129);
			this.MaximizeBox = false;
			this.MinimizeBox = true;
			this.Name = "frmICSProductAssemblyDetails";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Tag = "False";
			this.Text = "Product Assembly Details";
			// this.Activated += new System.EventHandler(this.frmICSProductAssemblyDetails_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
			// this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
			this.grdVoucherDetails.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		#endregion
	}
}//ENDSHERE
