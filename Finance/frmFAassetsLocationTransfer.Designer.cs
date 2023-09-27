
namespace Xtreme
{
	partial class frmFAassetsLocationTransfer
	{

		#region "Upgrade Support "
		private static frmFAassetsLocationTransfer m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmFAassetsLocationTransfer DefInstance
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
		public static frmFAassetsLocationTransfer CreateInstance()
		{
			frmFAassetsLocationTransfer theInstance = new frmFAassetsLocationTransfer();
			
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
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "lblTransactionDate", "lblRemarks", "lblTransactionNumber", "txtVoucherDate", "txtComments", "txtVoucherNo", "Column_0_grdVoucherDetails", "Column_1_grdVoucherDetails", "grdVoucherDetails", "Column_0_cmbCommon", "Column_1_cmbCommon", "cmbCommon"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public System.Windows.Forms.Label lblTransactionDate;
		public System.Windows.Forms.Label lblRemarks;
		public System.Windows.Forms.Label lblTransactionNumber;
		public Syncfusion.WinForms.Input.SfDateTimeEdit txtVoucherDate;
		public System.Windows.Forms.TextBox txtComments;
		public System.Windows.Forms.TextBox txtVoucherNo;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_0_grdVoucherDetails;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_1_grdVoucherDetails;
		public C1.Win.C1TrueDBGrid.C1TrueDBGrid grdVoucherDetails;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_0_cmbCommon;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_1_cmbCommon;
		public C1.Win.C1TrueDBGrid.C1TrueDBDropdown cmbCommon;
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFAassetsLocationTransfer));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this.lblTransactionDate = new System.Windows.Forms.Label();
			this.lblRemarks = new System.Windows.Forms.Label();
			this.lblTransactionNumber = new System.Windows.Forms.Label();
			this.txtVoucherDate = new Syncfusion.WinForms.Input.SfDateTimeEdit();
			this.txtComments = new System.Windows.Forms.TextBox();
			this.txtVoucherNo = new System.Windows.Forms.TextBox();
			this.grdVoucherDetails = new C1.Win.C1TrueDBGrid.C1TrueDBGrid();
			this.Column_0_grdVoucherDetails = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.Column_1_grdVoucherDetails = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.cmbCommon = new C1.Win.C1TrueDBGrid.C1TrueDBDropdown();
			this.Column_0_cmbCommon = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.Column_1_cmbCommon = new C1.Win.C1TrueDBGrid.C1DataColumn();
			//this.grdVoucherDetails.SuspendLayout();
			//this.cmbCommon.SuspendLayout();
			this.SuspendLayout();
			// 
			// lblTransactionDate
			// 
			//this.lblTransactionDate.AllowDrop = true;
			this.lblTransactionDate.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			// this.lblTransactionDate.Text = "Transaction  Date";
			this.lblTransactionDate.ForeColor = System.Drawing.Color.Black;
			this.lblTransactionDate.Location = new System.Drawing.Point(8, 74);
			// // this.lblTransactionDate.mLabelId = 1018;
			this.lblTransactionDate.Name = "lblTransactionDate";
			this.lblTransactionDate.Size = new System.Drawing.Size(85, 14);
			this.lblTransactionDate.TabIndex = 3;
			// 
			// lblRemarks
			// 
			//this.lblRemarks.AllowDrop = true;
			this.lblRemarks.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblRemarks.Text = "Comments";
			this.lblRemarks.ForeColor = System.Drawing.Color.Black;
			this.lblRemarks.Location = new System.Drawing.Point(8, 94);
			// // this.lblRemarks.mLabelId = 135;
			this.lblRemarks.Name = "lblRemarks";
			this.lblRemarks.Size = new System.Drawing.Size(50, 14);
			this.lblRemarks.TabIndex = 4;
			// 
			// lblTransactionNumber
			// 
			//this.lblTransactionNumber.AllowDrop = true;
			this.lblTransactionNumber.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblTransactionNumber.Text = "Transaction Number";
			this.lblTransactionNumber.ForeColor = System.Drawing.Color.Black;
			this.lblTransactionNumber.Location = new System.Drawing.Point(8, 53);
			// // this.lblTransactionNumber.mLabelId = 1017;
			this.lblTransactionNumber.Name = "lblTransactionNumber";
			this.lblTransactionNumber.Size = new System.Drawing.Size(97, 14);
			this.lblTransactionNumber.TabIndex = 5;
			// 
			// txtVoucherDate
			// 
			//this.txtVoucherDate.AllowDrop = true;
			// this.txtVoucherDate.CheckDateRange = false;
			this.txtVoucherDate.Location = new System.Drawing.Point(126, 71);
			// this.txtVoucherDate.MaxDate = 2958465;
			// this.txtVoucherDate.MinDate = 2;
			this.txtVoucherDate.Name = "txtVoucherDate";
			this.txtVoucherDate.Size = new System.Drawing.Size(97, 19);
			this.txtVoucherDate.TabIndex = 0;
			// this.txtVoucherDate.Text = "15/03/2014";
			// 
			// txtComments
			// 
			//this.txtComments.AllowDrop = true;
			this.txtComments.BackColor = System.Drawing.Color.White;
			this.txtComments.ForeColor = System.Drawing.Color.Black;
			this.txtComments.Location = new System.Drawing.Point(126, 92);
			this.txtComments.MaxLength = 10;
			this.txtComments.Name = "txtComments";
			this.txtComments.Size = new System.Drawing.Size(397, 19);
			this.txtComments.TabIndex = 1;
			this.txtComments.Text = "";
			// this.// = "";
			// 
			// txtVoucherNo
			// 
			//this.txtVoucherNo.AllowDrop = true;
			this.txtVoucherNo.BackColor = System.Drawing.Color.FromArgb(239, 239, 239);
			// this.txtVoucherNo.bolNumericOnly = true;
			this.txtVoucherNo.Enabled = false;
			this.txtVoucherNo.ForeColor = System.Drawing.Color.Black;
			this.txtVoucherNo.Location = new System.Drawing.Point(126, 50);
			this.txtVoucherNo.MaxLength = 15;
			this.txtVoucherNo.Name = "txtVoucherNo";
			this.txtVoucherNo.Size = new System.Drawing.Size(97, 19);
			this.txtVoucherNo.TabIndex = 6;
			this.txtVoucherNo.Text = "";
			// this.// = "";
			// 
			// grdVoucherDetails
			// 
			//this.grdVoucherDetails.AllowDrop = true;
			this.grdVoucherDetails.BackColor = System.Drawing.Color.FromArgb(212, 208, 200);
			this.grdVoucherDetails.CellTipsWidth = 0;
			this.grdVoucherDetails.Location = new System.Drawing.Point(6, 118);
			this.grdVoucherDetails.Name = "grdVoucherDetails";
			this.grdVoucherDetails.RowDivider.Color = System.Drawing.Color.FromArgb(212, 208, 200);
			this.grdVoucherDetails.Size = new System.Drawing.Size(517, 181);
			this.grdVoucherDetails.TabIndex = 2;
			this.grdVoucherDetails.Columns.Add(this.Column_0_grdVoucherDetails);
			this.grdVoucherDetails.Columns.Add(this.Column_1_grdVoucherDetails);
			////this.grdVoucherDetails.GotFocus += new System.EventHandler(this.grdVoucherDetails_GotFocus);
			////this.grdVoucherDetails.RowColChange += new C1.Win.C1TrueDBGrid.RowColChangeEventHandler(this.grdVoucherDetails_RowColChange);
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
			// cmbCommon
			// 
			//this.cmbCommon.AllowDrop = true;
			this.cmbCommon.ColumnHeaders = true;
			this.cmbCommon.Enabled = true;
			this.cmbCommon.Location = new System.Drawing.Point(52, 178);
			this.cmbCommon.Name = "cmbCommon";
			this.cmbCommon.Size = new System.Drawing.Size(113, 33);
			this.cmbCommon.TabIndex = 7;
			this.cmbCommon.Columns.Add(this.Column_0_cmbCommon);
			this.cmbCommon.Columns.Add(this.Column_1_cmbCommon);
			// 
			// Column_0_cmbCommon
			// 
			this.Column_0_cmbCommon.DataField = "";
			this.Column_0_cmbCommon.ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.Normal;
			// 
			// Column_1_cmbCommon
			// 
			this.Column_1_cmbCommon.DataField = "";
			this.Column_1_cmbCommon.ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.Normal;
			// 
			// frmFAassetsLocationTransfer
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.ClientSize = new System.Drawing.Size(543, 312);
			this.Controls.Add(this.lblTransactionDate);
			this.Controls.Add(this.lblRemarks);
			this.Controls.Add(this.lblTransactionNumber);
			this.Controls.Add(this.txtVoucherDate);
			this.Controls.Add(this.txtComments);
			this.Controls.Add(this.txtVoucherNo);
			this.Controls.Add(this.grdVoucherDetails);
			this.Controls.Add(this.cmbCommon);
			//this.Icon = (System.Drawing.Icon) resources.GetObject("frmFAassetsLocationTransfer.Icon");
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(192, 137);
			this.MaximizeBox = true;
			this.MinimizeBox = true;
			this.Name = "frmFAassetsLocationTransfer";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Asset Location Transfer";
			// this.Activated += new System.EventHandler(this.frmFAassetsLocationTransfer_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
			// this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
			this.grdVoucherDetails.ResumeLayout(false);
			this.cmbCommon.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		// 
		#endregion
	}
}//ENDSHERE
