
namespace Xtreme
{
	partial class frmARAPVoucherLinking
	{

		#region "Upgrade Support "
		private static frmARAPVoucherLinking m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmARAPVoucherLinking DefInstance
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
		public static frmARAPVoucherLinking CreateInstance()
		{
			frmARAPVoucherLinking theInstance = new frmARAPVoucherLinking();
			
			return theInstance;
		}
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "cmdOKCancel", "txtToBeAdjusted", "grdVoucherDetails", "txtCurrencySymbol", "lblCurrencySymbol", "txtLdgrName", "txtLdgrNo", "lblLedgerNo", "System.Windows.Forms.Label3", "System.Windows.Forms.Label2", "txtAmountToAdjust", "System.Windows.Forms.Label1", "txtAmountAdjusted", "lblVoucherWiseAdjustment", "Line2", "Line1", "fraVoucherAdjustment"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public UCOkCancel cmdOKCancel;
		public System.Windows.Forms.TextBox txtToBeAdjusted;
		public C1.Win.C1TrueDBGrid.C1TrueDBGrid grdVoucherDetails;
		public System.Windows.Forms.TextBox txtCurrencySymbol;
		public System.Windows.Forms.Label lblCurrencySymbol;
		public System.Windows.Forms.TextBox txtLdgrName;
		public System.Windows.Forms.TextBox txtLdgrNo;
		public System.Windows.Forms.Label lblLedgerNo;
		public System.Windows.Forms.Label Label3;
		public System.Windows.Forms.Label Label2;
		public System.Windows.Forms.TextBox txtAmountToAdjust;
		public System.Windows.Forms.Label Label1;
		public System.Windows.Forms.TextBox txtAmountAdjusted;
		public System.Windows.Forms.Label lblVoucherWiseAdjustment;
		public System.Windows.Forms.Label Line2;
		public System.Windows.Forms.Label Line1;
		public AxTDBContainer3D6.AxTDBContainer3D fraVoucherAdjustment;
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmARAPVoucherLinking));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this.fraVoucherAdjustment = new AxTDBContainer3D6.AxTDBContainer3D();
			this.cmdOKCancel = new UCOkCancel();
			this.txtToBeAdjusted = new System.Windows.Forms.TextBox();
			this.grdVoucherDetails = new C1.Win.C1TrueDBGrid.C1TrueDBGrid();
			this.txtCurrencySymbol = new System.Windows.Forms.TextBox();
			this.lblCurrencySymbol = new System.Windows.Forms.Label();
			this.txtLdgrName = new System.Windows.Forms.TextBox();
			this.txtLdgrNo = new System.Windows.Forms.TextBox();
			this.lblLedgerNo = new System.Windows.Forms.Label();
			this.Label3 = new System.Windows.Forms.Label();
			this.Label2 = new System.Windows.Forms.Label();
			this.txtAmountToAdjust = new System.Windows.Forms.TextBox();
			this.Label1 = new System.Windows.Forms.Label();
			this.txtAmountAdjusted = new System.Windows.Forms.TextBox();
			this.lblVoucherWiseAdjustment = new System.Windows.Forms.Label();
			this.Line2 = new System.Windows.Forms.Label();
			this.Line1 = new System.Windows.Forms.Label();
			// //((System.ComponentModel.ISupportInitialize) this.fraVoucherAdjustment).BeginInit();
			this.fraVoucherAdjustment.SuspendLayout();
			this.SuspendLayout();
			// 
			// fraVoucherAdjustment
			// 
			this.fraVoucherAdjustment.AllowDrop = true;
			this.fraVoucherAdjustment.Controls.Add(this.cmdOKCancel);
			this.fraVoucherAdjustment.Controls.Add(this.txtToBeAdjusted);
			this.fraVoucherAdjustment.Controls.Add(this.grdVoucherDetails);
			this.fraVoucherAdjustment.Controls.Add(this.txtCurrencySymbol);
			this.fraVoucherAdjustment.Controls.Add(this.lblCurrencySymbol);
			this.fraVoucherAdjustment.Controls.Add(this.txtLdgrName);
			this.fraVoucherAdjustment.Controls.Add(this.txtLdgrNo);
			this.fraVoucherAdjustment.Controls.Add(this.lblLedgerNo);
			this.fraVoucherAdjustment.Controls.Add(this.Label3);
			this.fraVoucherAdjustment.Controls.Add(this.Label2);
			this.fraVoucherAdjustment.Controls.Add(this.txtAmountToAdjust);
			this.fraVoucherAdjustment.Controls.Add(this.Label1);
			this.fraVoucherAdjustment.Controls.Add(this.txtAmountAdjusted);
			this.fraVoucherAdjustment.Controls.Add(this.lblVoucherWiseAdjustment);
			this.fraVoucherAdjustment.Controls.Add(this.Line2);
			this.fraVoucherAdjustment.Controls.Add(this.Line1);
			this.fraVoucherAdjustment.Location = new System.Drawing.Point(0, 0);
			this.fraVoucherAdjustment.Name = "fraVoucherAdjustment";
			//
			this.fraVoucherAdjustment.Size = new System.Drawing.Size(687, 245);
			this.fraVoucherAdjustment.TabIndex = 2;
			// 
			// cmdOKCancel
			// 
			this.cmdOKCancel.AllowDrop = true;
			this.cmdOKCancel.DisplayButton = 0;
			this.cmdOKCancel.Location = new System.Drawing.Point(474, 208);
			this.cmdOKCancel.Name = "cmdOKCancel";
			this.cmdOKCancel.OkCaption = "&Ok";
			this.cmdOKCancel.Size = new System.Drawing.Size(206, 31);
			this.cmdOKCancel.TabIndex = 1;
			this.cmdOKCancel.CancelClick += new UCOkCancel.CancelClickHandler(this.cmdOKCancel_CancelClick);
			this.cmdOKCancel.OKClick += new UCOkCancel.OKClickHandler(this.cmdOKCancel_OKClick);
			// 
			// txtToBeAdjusted
			// 
			this.txtToBeAdjusted.AllowDrop = true;
			this.txtToBeAdjusted.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			// this.txtToBeAdjusted.DisplayFormat = "####0.000###;;0.000;0.000";
			this.txtToBeAdjusted.Enabled = false;
			// this.txtToBeAdjusted.Format = "###########0.000";
			this.txtToBeAdjusted.Location = new System.Drawing.Point(182, 220);
			// this.txtToBeAdjusted.MaxValue = 2147483647;
			// this.txtToBeAdjusted.MinValue = 0;
			this.txtToBeAdjusted.Name = "txtToBeAdjusted";
			this.txtToBeAdjusted.Size = new System.Drawing.Size(88, 19);
			this.txtToBeAdjusted.TabIndex = 11;
			this.txtToBeAdjusted.Text = "0.000";
			// 
			// grdVoucherDetails
			// 
			this.grdVoucherDetails.AllowDrop = true;
			this.grdVoucherDetails.BackColor = System.Drawing.Color.Silver;
			this.grdVoucherDetails.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.grdVoucherDetails.CellTipsWidth = 0;
			this.grdVoucherDetails.Location = new System.Drawing.Point(2, 46);
			this.grdVoucherDetails.Name = "grdVoucherDetails";
			this.grdVoucherDetails.RowDivider.Color = System.Drawing.Color.Silver;
			this.grdVoucherDetails.Size = new System.Drawing.Size(677, 156);
			this.grdVoucherDetails.TabIndex = 0;
			this.grdVoucherDetails.BeforeColUpdate += new C1.Win.C1TrueDBGrid.BeforeColUpdateEventHandler(this.grdVoucherDetails_BeforeColUpdate);
			this.grdVoucherDetails.GotFocus += new System.EventHandler(this.grdVoucherDetails_GotFocus);
			// this.grdVoucherDetails.Leave += new System.EventHandler(this.grdVoucherDetails_Leave);
			// 
			// txtCurrencySymbol
			// 
			this.txtCurrencySymbol.AllowDrop = true;
			this.txtCurrencySymbol.BackColor = System.Drawing.Color.FromArgb(239, 239, 239);
			this.txtCurrencySymbol.Enabled = false;
			this.txtCurrencySymbol.ForeColor = System.Drawing.Color.Black;
			this.txtCurrencySymbol.Location = new System.Drawing.Point(645, 6);
			// this.txtCurrencySymbol.mDropDownType = (System.Windows.Forms.TextBox.DropDownTypes) 0;
			this.txtCurrencySymbol.Name = "txtCurrencySymbol";
			this.txtCurrencySymbol.Size = new System.Drawing.Size(33, 19);
			this.txtCurrencySymbol.TabIndex = 4;
			this.txtCurrencySymbol.Text = "";
			// this.this.txtCurrencySymbol.Watermark = "";
			// 
			// lblCurrencySymbol
			// 
			this.lblCurrencySymbol.AllowDrop = true;
			this.lblCurrencySymbol.BackColor = System.Drawing.Color.Silver;
			this.lblCurrencySymbol.Text = "Currency :";
			this.lblCurrencySymbol.ForeColor = System.Drawing.Color.Black;
			this.lblCurrencySymbol.Location = new System.Drawing.Point(590, 9);
			this.lblCurrencySymbol.Name = "lblCurrencySymbol";
			this.lblCurrencySymbol.Size = new System.Drawing.Size(51, 13);
			this.lblCurrencySymbol.TabIndex = 5;
			// 
			// txtLdgrName
			// 
			this.txtLdgrName.AllowDrop = true;
			this.txtLdgrName.BackColor = System.Drawing.Color.FromArgb(239, 239, 239);
			this.txtLdgrName.Enabled = false;
			this.txtLdgrName.ForeColor = System.Drawing.Color.Black;
			this.txtLdgrName.Location = new System.Drawing.Point(384, 6);
			this.txtLdgrName.Name = "txtLdgrName";
			this.txtLdgrName.Size = new System.Drawing.Size(201, 19);
			this.txtLdgrName.TabIndex = 6;
			this.txtLdgrName.Text = "";
			// this.this.txtLdgrName.Watermark = "";
			// 
			// txtLdgrNo
			// 
			this.txtLdgrNo.AllowDrop = true;
			this.txtLdgrNo.BackColor = System.Drawing.Color.FromArgb(239, 239, 239);
			this.txtLdgrNo.Enabled = false;
			this.txtLdgrNo.ForeColor = System.Drawing.Color.Black;
			this.txtLdgrNo.Location = new System.Drawing.Point(296, 6);
			this.txtLdgrNo.MaxLength = 4;
			this.txtLdgrNo.Name = "txtLdgrNo";
			this.txtLdgrNo.Size = new System.Drawing.Size(88, 19);
			this.txtLdgrNo.TabIndex = 7;
			this.txtLdgrNo.Text = "";
			// this.this.txtLdgrNo.Watermark = "";
			// 
			// lblLedgerNo
			// 
			this.lblLedgerNo.AllowDrop = true;
			this.lblLedgerNo.BackColor = System.Drawing.Color.Silver;
			this.lblLedgerNo.Text = "Ledger Code :";
			this.lblLedgerNo.ForeColor = System.Drawing.Color.Black;
			this.lblLedgerNo.Location = new System.Drawing.Point(218, 8);
			this.lblLedgerNo.Name = "lblLedgerNo";
			this.lblLedgerNo.Size = new System.Drawing.Size(68, 14);
			this.lblLedgerNo.TabIndex = 8;
			// 
			// System.Windows.Forms.Label3
			// 
			this.Label3.AllowDrop = true;
			this.Label3.BackColor = System.Drawing.Color.Silver;
			this.Label3.Text = "Amt to Adjust :";
			this.Label3.ForeColor = System.Drawing.Color.Black;
			this.Label3.Location = new System.Drawing.Point(2, 206);
			this.Label3.Name = "System.Windows.Forms.Label3";
			this.Label3.Size = new System.Drawing.Size(71, 14);
			this.Label3.TabIndex = 9;
			// 
			// System.Windows.Forms.Label2
			// 
			this.Label2.AllowDrop = true;
			this.Label2.BackColor = System.Drawing.Color.Silver;
			this.Label2.Text = "To be Adjusted :";
			this.Label2.ForeColor = System.Drawing.Color.Black;
			this.Label2.Location = new System.Drawing.Point(182, 206);
			this.Label2.Name = "System.Windows.Forms.Label2";
			this.Label2.Size = new System.Drawing.Size(79, 14);
			this.Label2.TabIndex = 10;
			// 
			// txtAmountToAdjust
			// 
			this.txtAmountToAdjust.AllowDrop = true;
			this.txtAmountToAdjust.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			// this.txtAmountToAdjust.DisplayFormat = "####0.000###;;0.000;0.000";
			this.txtAmountToAdjust.Enabled = false;
			// this.txtAmountToAdjust.Format = "###########0.000";
			this.txtAmountToAdjust.Location = new System.Drawing.Point(2, 220);
			// this.txtAmountToAdjust.MaxValue = 2147483647;
			// this.txtAmountToAdjust.MinValue = 0;
			this.txtAmountToAdjust.Name = "txtAmountToAdjust";
			this.txtAmountToAdjust.Size = new System.Drawing.Size(88, 19);
			this.txtAmountToAdjust.TabIndex = 12;
			this.txtAmountToAdjust.Text = "0.000";
			// this.this.txtAmountToAdjust.Change += new System.Windows.Forms.TextBox.ChangeHandler(this.txtAmountToAdjust_Change);
			// 
			// System.Windows.Forms.Label1
			// 
			this.Label1.AllowDrop = true;
			this.Label1.BackColor = System.Drawing.Color.Silver;
			this.Label1.Text = "Amt Adjusted :";
			this.Label1.ForeColor = System.Drawing.Color.Black;
			this.Label1.Location = new System.Drawing.Point(92, 206);
			this.Label1.Name = "System.Windows.Forms.Label1";
			this.Label1.Size = new System.Drawing.Size(71, 14);
			this.Label1.TabIndex = 13;
			// 
			// txtAmountAdjusted
			// 
			this.txtAmountAdjusted.AllowDrop = true;
			this.txtAmountAdjusted.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			// this.txtAmountAdjusted.DisplayFormat = "####0.000###;;0.000;0.000";
			this.txtAmountAdjusted.Enabled = false;
			// this.txtAmountAdjusted.Format = "###########0.000";
			this.txtAmountAdjusted.Location = new System.Drawing.Point(92, 220);
			// this.txtAmountAdjusted.MaxValue = 2147483647;
			// this.txtAmountAdjusted.MinValue = 0;
			this.txtAmountAdjusted.Name = "txtAmountAdjusted";
			this.txtAmountAdjusted.Size = new System.Drawing.Size(88, 19);
			this.txtAmountAdjusted.TabIndex = 14;
			this.txtAmountAdjusted.Text = "0.000";
			// this.this.txtAmountAdjusted.Change += new System.Windows.Forms.TextBox.ChangeHandler(this.txtAmountAdjusted_Change);
			// 
			// lblVoucherWiseAdjustment
			// 
			this.lblVoucherWiseAdjustment.AllowDrop = true;
			this.lblVoucherWiseAdjustment.AutoSize = true;
			this.lblVoucherWiseAdjustment.BackColor = System.Drawing.Color.Silver;
			this.lblVoucherWiseAdjustment.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lblVoucherWiseAdjustment.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 178);
			this.lblVoucherWiseAdjustment.ForeColor = System.Drawing.Color.Black;
			this.lblVoucherWiseAdjustment.Location = new System.Drawing.Point(10, 28);
			this.lblVoucherWiseAdjustment.Name = "lblVoucherWiseAdjustment";
			this.lblVoucherWiseAdjustment.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblVoucherWiseAdjustment.Size = new System.Drawing.Size(136, 14);
			this.lblVoucherWiseAdjustment.TabIndex = 3;
			this.lblVoucherWiseAdjustment.Text = " Voucher-Wise Adjustment  ";
			// 
			// Line2
			// 
			this.Line2.AllowDrop = true;
			this.Line2.BackColor = System.Drawing.Color.White;
			this.Line2.Enabled = false;
			this.Line2.Location = new System.Drawing.Point(2, 34);
			this.Line2.Name = "Line2";
			this.Line2.Size = new System.Drawing.Size(678, 1);
			this.Line2.Visible = true;
			// 
			// Line1
			// 
			this.Line1.AllowDrop = true;
			this.Line1.BackColor = System.Drawing.Color.Gray;
			this.Line1.Enabled = false;
			this.Line1.Location = new System.Drawing.Point(2, 34);
			this.Line1.Name = "Line1";
			this.Line1.Size = new System.Drawing.Size(678, 1);
			this.Line1.Visible = true;
			// 
			// frmARAPVoucherLinking
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			this.ClientSize = new System.Drawing.Size(687, 269);
			this.ControlBox = false;
			this.Controls.Add(this.fraVoucherAdjustment);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			//this.Icon = (System.Drawing.Icon) resources.GetObject("frmARAPVoucherLinking.Icon");
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(241, 237);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmARAPVoucherLinking";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.ShowInTaskbar = false;
			// this.Activated += new System.EventHandler(this.frmARAPVoucherLinking_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
			// this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
			//((System.ComponentModel.ISupportInitialize) this.fraVoucherAdjustment).EndInit();
			this.fraVoucherAdjustment.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		#endregion
	}
}//ENDSHERE
