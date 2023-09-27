
namespace Xtreme
{
	partial class frmICSLoadDocument
	{

		#region "Upgrade Support "
		private static frmICSLoadDocument m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmICSLoadDocument DefInstance
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
		public static frmICSLoadDocument CreateInstance()
		{
			frmICSLoadDocument theInstance = new frmICSLoadDocument();
			return theInstance;
		}
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "cmdOKCancel", "cmbVoucherTypes", "lblVoucherType", "cmbLocation", "lblLocation", "Column_0_grdVoucherDetails", "Column_1_grdVoucherDetails", "grdVoucherDetails", "fraLoadDocument"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public UCOkCancel cmdOKCancel;
		public System.Windows.Forms.ComboBox cmbVoucherTypes;
		public System.Windows.Forms.Label lblVoucherType;
		public System.Windows.Forms.ComboBox cmbLocation;
		public System.Windows.Forms.Label lblLocation;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_0_grdVoucherDetails;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_1_grdVoucherDetails;
		public C1.Win.C1TrueDBGrid.C1TrueDBGrid grdVoucherDetails;
		public System.Windows.Forms.Panel fraLoadDocument;
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmICSLoadDocument));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this.fraLoadDocument = new System.Windows.Forms.Panel();
			this.cmdOKCancel = new UCOkCancel();
			this.cmbVoucherTypes = new System.Windows.Forms.ComboBox();
			this.lblVoucherType = new System.Windows.Forms.Label();
			this.cmbLocation = new System.Windows.Forms.ComboBox();
			this.lblLocation = new System.Windows.Forms.Label();
			this.grdVoucherDetails = new C1.Win.C1TrueDBGrid.C1TrueDBGrid();
			this.Column_0_grdVoucherDetails = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.Column_1_grdVoucherDetails = new C1.Win.C1TrueDBGrid.C1DataColumn();
			// //((System.ComponentModel.ISupportInitialize) this.fraLoadDocument).BeginInit();
			//this.fraLoadDocument.SuspendLayout();
			//this.grdVoucherDetails.SuspendLayout();
			this.SuspendLayout();
			// 
			// fraLoadDocument
			// 
			//this.fraLoadDocument.AllowDrop = true;
			this.fraLoadDocument.Controls.Add(this.cmdOKCancel);
			this.fraLoadDocument.Controls.Add(this.cmbVoucherTypes);
			this.fraLoadDocument.Controls.Add(this.lblVoucherType);
			this.fraLoadDocument.Controls.Add(this.cmbLocation);
			this.fraLoadDocument.Controls.Add(this.lblLocation);
			this.fraLoadDocument.Controls.Add(this.grdVoucherDetails);
			this.fraLoadDocument.Location = new System.Drawing.Point(6, 6);
			this.fraLoadDocument.Name = "fraLoadDocument";
			//
			this.fraLoadDocument.Size = new System.Drawing.Size(345, 261);
			this.fraLoadDocument.TabIndex = 3;
			// 
			// cmdOKCancel
			// 
			//this.cmdOKCancel.AllowDrop = true;
			this.cmdOKCancel.Location = new System.Drawing.Point(72, 218);
			this.cmdOKCancel.Name = "cmdOKCancel";
			this.cmdOKCancel.OkCaption = "&Ok";
			this.cmdOKCancel.Size = new System.Drawing.Size(206, 31);
			this.cmdOKCancel.TabIndex = 6;
			// 
			// cmbVoucherTypes
			// 
			//this.cmbVoucherTypes.AllowDrop = true;
			this.cmbVoucherTypes.Location = new System.Drawing.Point(97, 12);
			this.cmbVoucherTypes.Name = "cmbVoucherTypes";
			this.cmbVoucherTypes.Size = new System.Drawing.Size(237, 21);
			this.cmbVoucherTypes.TabIndex = 0;
			// 
			// lblVoucherType
			// 
			//this.lblVoucherType.AllowDrop = true;
			this.lblVoucherType.BackColor = System.Drawing.Color.White;
			this.lblVoucherType.Text = "Voucher Type";
			this.lblVoucherType.Location = new System.Drawing.Point(16, 16);
			this.lblVoucherType.Name = "lblVoucherType";
			this.lblVoucherType.Size = new System.Drawing.Size(66, 13);
			this.lblVoucherType.TabIndex = 4;
			// 
			// cmbLocation
			// 
			//this.cmbLocation.AllowDrop = true;
			this.cmbLocation.Location = new System.Drawing.Point(97, 36);
			this.cmbLocation.Name = "cmbLocation";
			this.cmbLocation.Size = new System.Drawing.Size(237, 21);
			this.cmbLocation.TabIndex = 1;
			// 
			// lblLocation
			// 
			//this.lblLocation.AllowDrop = true;
			this.lblLocation.BackColor = System.Drawing.Color.White;
			this.lblLocation.Text = "Location";
			this.lblLocation.Location = new System.Drawing.Point(16, 42);
			this.lblLocation.Name = "lblLocation";
			this.lblLocation.Size = new System.Drawing.Size(40, 13);
			this.lblLocation.TabIndex = 5;
			// 
			// grdVoucherDetails
			// 
			//this.grdVoucherDetails.AllowDrop = true;
			this.grdVoucherDetails.BackColor = System.Drawing.Color.Silver;
			this.grdVoucherDetails.CellTipsWidth = 0;
			this.grdVoucherDetails.Location = new System.Drawing.Point(12, 68);
			this.grdVoucherDetails.Name = "grdVoucherDetails";
			this.grdVoucherDetails.RowDivider.Color = System.Drawing.Color.Silver;
			this.grdVoucherDetails.Size = new System.Drawing.Size(319, 144);
			this.grdVoucherDetails.TabIndex = 2;
			this.grdVoucherDetails.Columns.Add(this.Column_0_grdVoucherDetails);
			this.grdVoucherDetails.Columns.Add(this.Column_1_grdVoucherDetails);
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
			// frmICSLoadDocument
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(64, 64, 64);
			this.ClientSize = new System.Drawing.Size(353, 277);
			this.Controls.Add(this.fraLoadDocument);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			//this.Icon = (System.Drawing.Icon) resources.GetObject("frmICSLoadDocument.Icon");
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(204, 128);
			this.MaximizeBox = true;
			this.MinimizeBox = true;
			this.Name = "frmICSLoadDocument";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.ShowInTaskbar = false;
			this.Text = "Load Document";
			// this.Activated += new System.EventHandler(this.frmICSLoadDocument_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
			//((System.ComponentModel.ISupportInitialize) this.fraLoadDocument).EndInit();
			this.fraLoadDocument.ResumeLayout(false);
			this.grdVoucherDetails.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		#endregion
	}
}//ENDSHERE
