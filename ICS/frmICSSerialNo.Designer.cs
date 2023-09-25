
namespace Xtreme
{
	partial class frmICSSerialNo
	{

		#region "Upgrade Support "
		private static frmICSSerialNo m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmICSSerialNo DefInstance
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
		public static frmICSSerialNo CreateInstance()
		{
			frmICSSerialNo theInstance = new frmICSSerialNo();
			
			return theInstance;
		}
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "_txtCommonTextBox_5", "txtCashAmt", "_txtCommonTextBox_6", "txtCCAmt", "_txtDisplayLabel_3", "_txtDisplayLabel_15", "fraPayments", "System.Windows.Forms.Label1", "Column_0_grdVoucherDetails", "Column_1_grdVoucherDetails", "grdVoucherDetails", "cmdOKCancel", "Column_0_cmbMasterList", "Column_1_cmbMasterList", "cmbMasterList", "txtTotalSerialNo", "txtCommonTextBox", "txtDisplayLabel"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		private System.Windows.Forms.TextBox _txtCommonTextBox_5;
		public System.Windows.Forms.TextBox txtCashAmt;
		private System.Windows.Forms.TextBox _txtCommonTextBox_6;
		public System.Windows.Forms.TextBox txtCCAmt;
		private System.Windows.Forms.Label _txtDisplayLabel_3;
		private System.Windows.Forms.Label _txtDisplayLabel_15;
		public System.Windows.Forms.GroupBox fraPayments;
		public System.Windows.Forms.Label Label1;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_0_grdVoucherDetails;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_1_grdVoucherDetails;
		public C1.Win.C1TrueDBGrid.C1TrueDBGrid grdVoucherDetails;
		public UCOkCancel cmdOKCancel;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_0_cmbMasterList;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_1_cmbMasterList;
		public C1.Win.C1TrueDBGrid.C1TrueDBDropdown cmbMasterList;
		public System.Windows.Forms.Label txtTotalSerialNo;
		public System.Windows.Forms.TextBox[] txtCommonTextBox = new System.Windows.Forms.TextBox[7];
		public System.Windows.Forms.Label[] txtDisplayLabel = new System.Windows.Forms.Label[16];
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmICSSerialNo));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this.fraPayments = new System.Windows.Forms.GroupBox();
			this._txtCommonTextBox_5 = new System.Windows.Forms.TextBox();
			this.txtCashAmt = new System.Windows.Forms.TextBox();
			this._txtCommonTextBox_6 = new System.Windows.Forms.TextBox();
			this.txtCCAmt = new System.Windows.Forms.TextBox();
			this._txtDisplayLabel_3 = new System.Windows.Forms.Label();
			this._txtDisplayLabel_15 = new System.Windows.Forms.Label();
			this.Label1 = new System.Windows.Forms.Label();
			this.grdVoucherDetails = new C1.Win.C1TrueDBGrid.C1TrueDBGrid();
			this.Column_0_grdVoucherDetails = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.Column_1_grdVoucherDetails = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.cmdOKCancel = new UCOkCancel();
			this.cmbMasterList = new C1.Win.C1TrueDBGrid.C1TrueDBDropdown();
			this.Column_0_cmbMasterList = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.Column_1_cmbMasterList = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.txtTotalSerialNo = new System.Windows.Forms.Label();
			this.fraPayments.SuspendLayout();
			this.grdVoucherDetails.SuspendLayout();
			this.cmbMasterList.SuspendLayout();
			this.SuspendLayout();
			// 
			// fraPayments
			// 
			this.fraPayments.AllowDrop = true;
			this.fraPayments.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.fraPayments.Controls.Add(this._txtCommonTextBox_5);
			this.fraPayments.Controls.Add(this.txtCashAmt);
			this.fraPayments.Controls.Add(this._txtCommonTextBox_6);
			this.fraPayments.Controls.Add(this.txtCCAmt);
			this.fraPayments.Controls.Add(this._txtDisplayLabel_3);
			this.fraPayments.Controls.Add(this._txtDisplayLabel_15);
			this.fraPayments.Enabled = true;
			this.fraPayments.ForeColor = System.Drawing.SystemColors.ControlText;
			this.fraPayments.Location = new System.Drawing.Point(0, 346);
			this.fraPayments.Name = "fraPayments";
			this.fraPayments.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.fraPayments.Size = new System.Drawing.Size(261, 67);
			this.fraPayments.TabIndex = 5;
			this.fraPayments.Visible = true;
			// 
			// _txtCommonTextBox_5
			// 
			this._txtCommonTextBox_5.AllowDrop = true;
			this._txtCommonTextBox_5.BackColor = System.Drawing.Color.FromArgb(239, 239, 239);
			this._txtCommonTextBox_5.Enabled = false;
			this._txtCommonTextBox_5.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_5.Location = new System.Drawing.Point(4, 10);
			this._txtCommonTextBox_5.Name = "_txtCommonTextBox_5";
			// this._txtCommonTextBox_5.ShowButton = true;
			this._txtCommonTextBox_5.Size = new System.Drawing.Size(67, 23);
			this._txtCommonTextBox_5.TabIndex = 6;
			this._txtCommonTextBox_5.Text = "";
			this._txtCommonTextBox_5.Visible = false;
			// this.this._txtCommonTextBox_5.Watermark = "";
			// 
			// txtCashAmt
			// 
			this.txtCashAmt.AllowDrop = true;
			// this.txtCashAmt.DisplayFormat = "####0.000###;;0.000;0.000";
			// this.txtCashAmt.Format = "###########0.000";
			this.txtCashAmt.Location = new System.Drawing.Point(170, 10);
			// this.txtCashAmt.MaxValue = 2147483647;
			// this.txtCashAmt.MinValue = 0;
			this.txtCashAmt.Name = "txtCashAmt";
			this.txtCashAmt.Size = new System.Drawing.Size(87, 23);
			this.txtCashAmt.TabIndex = 7;
			this.txtCashAmt.Text = "0.000";
			// 
			// _txtCommonTextBox_6
			// 
			this._txtCommonTextBox_6.AllowDrop = true;
			this._txtCommonTextBox_6.BackColor = System.Drawing.Color.FromArgb(239, 239, 239);
			this._txtCommonTextBox_6.Enabled = false;
			this._txtCommonTextBox_6.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_6.Location = new System.Drawing.Point(4, 38);
			this._txtCommonTextBox_6.Name = "_txtCommonTextBox_6";
			// this._txtCommonTextBox_6.ShowButton = true;
			this._txtCommonTextBox_6.Size = new System.Drawing.Size(67, 23);
			this._txtCommonTextBox_6.TabIndex = 8;
			this._txtCommonTextBox_6.Text = "";
			// this.this._txtCommonTextBox_6.Watermark = "";
			// 
			// txtCCAmt
			// 
			this.txtCCAmt.AllowDrop = true;
			// this.txtCCAmt.DisplayFormat = "####0.000###;;0.000;0.000";
			// this.txtCCAmt.Format = "###########0.000";
			this.txtCCAmt.Location = new System.Drawing.Point(170, 38);
			// this.txtCCAmt.MaxValue = 2147483647;
			// this.txtCCAmt.MinValue = 0;
			this.txtCCAmt.Name = "txtCCAmt";
			this.txtCCAmt.Size = new System.Drawing.Size(87, 23);
			this.txtCCAmt.TabIndex = 9;
			this.txtCCAmt.Text = "0.000";
			// 
			// _txtDisplayLabel_3
			// 
			this._txtDisplayLabel_3.AllowDrop = true;
			this._txtDisplayLabel_3.Location = new System.Drawing.Point(72, 10);
			this._txtDisplayLabel_3.Name = "_txtDisplayLabel_3";
			this._txtDisplayLabel_3.Size = new System.Drawing.Size(97, 23);
			this._txtDisplayLabel_3.TabIndex = 10;
			this._txtDisplayLabel_3.TabStop = false;
			// 
			// _txtDisplayLabel_15
			// 
			this._txtDisplayLabel_15.AllowDrop = true;
			this._txtDisplayLabel_15.Location = new System.Drawing.Point(72, 38);
			this._txtDisplayLabel_15.Name = "_txtDisplayLabel_15";
			this._txtDisplayLabel_15.Size = new System.Drawing.Size(97, 23);
			this._txtDisplayLabel_15.TabIndex = 11;
			this._txtDisplayLabel_15.TabStop = false;
			// 
			// System.Windows.Forms.Label1
			// 
			this.Label1.AllowDrop = true;
			this.Label1.BackColor = System.Drawing.SystemColors.Window;
			this.Label1.BackStyle = VSReport8Lib.BackStyleSettings.vsrTransparent;
			this.Label1.Text = "Total No.";
			this.Label1.ForeColor = System.Drawing.SystemColors.WindowText;
			this.Label1.Location = new System.Drawing.Point(6, 226);
			this.Label1.Name = "System.Windows.Forms.Label1";
			this.Label1.Size = new System.Drawing.Size(42, 14);
			this.Label1.TabIndex = 4;
			// 
			// grdVoucherDetails
			// 
			this.grdVoucherDetails.AllowDrop = true;
			this.grdVoucherDetails.BackColor = System.Drawing.Color.Silver;
			this.grdVoucherDetails.CellTipsWidth = 0;
			this.grdVoucherDetails.Location = new System.Drawing.Point(4, 6);
			this.grdVoucherDetails.Name = "grdVoucherDetails";
			this.grdVoucherDetails.RowDivider.Color = System.Drawing.Color.Silver;
			this.grdVoucherDetails.Size = new System.Drawing.Size(381, 215);
			this.grdVoucherDetails.TabIndex = 0;
			this.grdVoucherDetails.Columns.Add(this.Column_0_grdVoucherDetails);
			this.grdVoucherDetails.Columns.Add(this.Column_1_grdVoucherDetails);
			this.grdVoucherDetails.AfterColUpdate += new C1.Win.C1TrueDBGrid.ColEventHandler(this.grdVoucherDetails_AfterColUpdate);
			this.grdVoucherDetails.BeforeColUpdate += new C1.Win.C1TrueDBGrid.BeforeColUpdateEventHandler(this.grdVoucherDetails_BeforeColUpdate);
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
			// cmdOKCancel
			// 
			this.cmdOKCancel.AllowDrop = true;
			this.cmdOKCancel.Location = new System.Drawing.Point(86, 260);
			this.cmdOKCancel.Name = "cmdOKCancel";
			this.cmdOKCancel.Size = new System.Drawing.Size(206, 31);
			this.cmdOKCancel.TabIndex = 2;
			//this.cmdOKCancel.CancelClick += new UCOkCancel.CancelClickHandler(this.cmdOKCancel_CancelClick);
			//this.cmdOKCancel.OKClick += new UCOkCancel.OKClickHandler(this.cmdOKCancel_OKClick);
			// 
			// cmbMasterList
			// 
			this.cmbMasterList.AllowDrop = true;
			this.cmbMasterList.ColumnHeaders = true;
			this.cmbMasterList.Enabled = true;
			this.cmbMasterList.Location = new System.Drawing.Point(310, 130);
			this.cmbMasterList.Name = "cmbMasterList";
			this.cmbMasterList.Size = new System.Drawing.Size(103, 53);
			this.cmbMasterList.TabIndex = 1;
			this.cmbMasterList.Columns.Add(this.Column_0_cmbMasterList);
			this.cmbMasterList.Columns.Add(this.Column_1_cmbMasterList);
			// 
			// Column_0_cmbMasterList
			// 
			this.Column_0_cmbMasterList.DataField = "";
			this.Column_0_cmbMasterList.ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.Normal;
			// 
			// Column_1_cmbMasterList
			// 
			this.Column_1_cmbMasterList.DataField = "";
			this.Column_1_cmbMasterList.ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.Normal;
			// 
			// txtTotalSerialNo
			// 
			this.txtTotalSerialNo.AllowDrop = true;
			this.txtTotalSerialNo.Location = new System.Drawing.Point(78, 226);
			this.txtTotalSerialNo.Name = "txtTotalSerialNo";
			this.txtTotalSerialNo.Size = new System.Drawing.Size(75, 19);
			this.txtTotalSerialNo.TabIndex = 3;
			// 
			// frmICSSerialNo
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.ClientSize = new System.Drawing.Size(1191, 644);
			this.ControlBox = false;
			this.Controls.Add(this.fraPayments);
			this.Controls.Add(this.Label1);
			this.Controls.Add(this.grdVoucherDetails);
			this.Controls.Add(this.cmdOKCancel);
			this.Controls.Add(this.cmbMasterList);
			this.Controls.Add(this.txtTotalSerialNo);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			//this.Icon = (System.Drawing.Icon) resources.GetObject("frmICSSerialNo.Icon");
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(195, 221);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmICSSerialNo";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Text = "Serial No.";
			// this.Activated += new System.EventHandler(this.frmICSSerialNo_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
			// this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
			this.fraPayments.ResumeLayout(false);
			this.grdVoucherDetails.ResumeLayout(false);
			this.cmbMasterList.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		// 
		void InitializetxtDisplayLabel()
		{
			this.txtDisplayLabel = new System.Windows.Forms.Label[16];
			this.txtDisplayLabel[3] = _txtDisplayLabel_3;
			this.txtDisplayLabel[15] = _txtDisplayLabel_15;
		}
		void InitializetxtCommonTextBox()
		{
			this.txtCommonTextBox = new System.Windows.Forms.TextBox[7];
			this.txtCommonTextBox[5] = _txtCommonTextBox_5;
			this.txtCommonTextBox[6] = _txtCommonTextBox_6;
		}
		#endregion
	}
}//ENDSHERE
