
namespace Xtreme
{
	partial class frmGLLedgerFCAmount
	{

		#region "Upgrade Support "
		private static frmGLLedgerFCAmount m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmGLLedgerFCAmount DefInstance
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
		public static frmGLLedgerFCAmount CreateInstance()
		{
			frmGLLedgerFCAmount theInstance = new frmGLLedgerFCAmount();
			
			return theInstance;
		}
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "txtFCAmount", "_cmdOkCancel_1", "_cmdOkCancel_0", "picOkCancel", "lblExchangeRate", "lblAmount", "txtExchangeRate", "fraLedgerAmountDetails", "cmdOkCancel"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public System.Windows.Forms.TextBox txtFCAmount;
		private AxSmartNetButtonProject.AxSmartNetButton _cmdOkCancel_1;
		private AxSmartNetButtonProject.AxSmartNetButton _cmdOkCancel_0;
		public System.Windows.Forms.PictureBox picOkCancel;
		public System.Windows.Forms.Label lblExchangeRate;
		public System.Windows.Forms.Label lblAmount;
		public System.Windows.Forms.TextBox txtExchangeRate;
		public AxTDBContainer3D6.AxTDBContainer3D fraLedgerAmountDetails;
		public AxSmartNetButtonProject.AxSmartNetButton[] cmdOkCancel = new AxSmartNetButtonProject.AxSmartNetButton[2];
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGLLedgerFCAmount));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this.fraLedgerAmountDetails = new AxTDBContainer3D6.AxTDBContainer3D();
			this.txtFCAmount = new System.Windows.Forms.TextBox();
			this.picOkCancel = new System.Windows.Forms.PictureBox();
			this._cmdOkCancel_1 = new AxSmartNetButtonProject.AxSmartNetButton();
			this._cmdOkCancel_0 = new AxSmartNetButtonProject.AxSmartNetButton();
			this.lblExchangeRate = new System.Windows.Forms.Label();
			this.lblAmount = new System.Windows.Forms.Label();
			this.txtExchangeRate = new System.Windows.Forms.TextBox();
			// //((System.ComponentModel.ISupportInitialize) this._cmdOkCancel_1).BeginInit();
			// //((System.ComponentModel.ISupportInitialize) this._cmdOkCancel_0).BeginInit();
			// //((System.ComponentModel.ISupportInitialize) this.fraLedgerAmountDetails).BeginInit();
			this.fraLedgerAmountDetails.SuspendLayout();
			this.picOkCancel.SuspendLayout();
			this.SuspendLayout();
			// 
			// fraLedgerAmountDetails
			// 
			this.fraLedgerAmountDetails.AllowDrop = true;
			this.fraLedgerAmountDetails.Controls.Add(this.txtFCAmount);
			this.fraLedgerAmountDetails.Controls.Add(this.picOkCancel);
			this.fraLedgerAmountDetails.Controls.Add(this.lblExchangeRate);
			this.fraLedgerAmountDetails.Controls.Add(this.lblAmount);
			this.fraLedgerAmountDetails.Controls.Add(this.txtExchangeRate);
			this.fraLedgerAmountDetails.Location = new System.Drawing.Point(2, 0);
			this.fraLedgerAmountDetails.Name = "fraLedgerAmountDetails";
			("fraLedgerAmountDetails.OcxState");
			this.fraLedgerAmountDetails.Size = new System.Drawing.Size(230, 128);
			this.fraLedgerAmountDetails.TabIndex = 4;
			// 
			// txtFCAmount
			// 
			this.txtFCAmount.AllowDrop = true;
			// this.txtFCAmount.DisplayFormat = "###,###,##0.000;;0.000;0.000";
			// this.txtFCAmount.Format = "##########0.000";
			this.txtFCAmount.Location = new System.Drawing.Point(92, 39);
			// this.txtFCAmount.MaxValue = 2147483647;
			// this.txtFCAmount.MinValue = 0;
			this.txtFCAmount.Name = "txtFCAmount";
			this.txtFCAmount.Size = new System.Drawing.Size(102, 19);
			this.txtFCAmount.TabIndex = 1;
			this.txtFCAmount.Text = "0.000";
			// 
			// picOkCancel
			// 
			this.picOkCancel.AllowDrop = true;
			this.picOkCancel.BackColor = System.Drawing.Color.Navy;
			this.picOkCancel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.picOkCancel.CausesValidation = true;
			this.picOkCancel.Controls.Add(this._cmdOkCancel_1);
			this.picOkCancel.Controls.Add(this._cmdOkCancel_0);
			this.picOkCancel.Dock = System.Windows.Forms.DockStyle.None;
			this.picOkCancel.Enabled = true;
			this.picOkCancel.Location = new System.Drawing.Point(58, 74);
			this.picOkCancel.Name = "picOkCancel";
			this.picOkCancel.Size = new System.Drawing.Size(138, 26);
			this.picOkCancel.TabIndex = 7;
			this.picOkCancel.TabStop = false;
			this.picOkCancel.Visible = true;
			// 
			// _cmdOkCancel_1
			// 
			this._cmdOkCancel_1.AllowDrop = true;
			this._cmdOkCancel_1.Location = new System.Drawing.Point(69, 0);
			this._cmdOkCancel_1.Name = "_cmdOkCancel_1";
			("_cmdOkCancel_1.OcxState");
			this._cmdOkCancel_1.Size = new System.Drawing.Size(67, 24);
			this._cmdOkCancel_1.TabIndex = 3;
			this._cmdOkCancel_1.AccessKeyPress += new AxSmartNetButtonProject.__SmartNetButton_AccessKeyPressEventHandler(this.cmdOkCancel_AccessKeyPress);
			//// this._cmdOkCancel_1.ClickEvent += new System.EventHandler(this.cmdOkCancel_ClickEvent);
			this._cmdOkCancel_1.KeyDownEvent += new AxSmartNetButtonProject.__SmartNetButton_KeyDownEventHandler(this.cmdOkCancel_KeyDownEvent);
			// 
			// _cmdOkCancel_0
			// 
			this._cmdOkCancel_0.AllowDrop = true;
			this._cmdOkCancel_0.Location = new System.Drawing.Point(0, 0);
			this._cmdOkCancel_0.Name = "_cmdOkCancel_0";
			("_cmdOkCancel_0.OcxState");
			this._cmdOkCancel_0.Size = new System.Drawing.Size(67, 24);
			this._cmdOkCancel_0.TabIndex = 2;
			this._cmdOkCancel_0.AccessKeyPress += new AxSmartNetButtonProject.__SmartNetButton_AccessKeyPressEventHandler(this.cmdOkCancel_AccessKeyPress);
			//// this._cmdOkCancel_0.ClickEvent += new System.EventHandler(this.cmdOkCancel_ClickEvent);
			this._cmdOkCancel_0.KeyDownEvent += new AxSmartNetButtonProject.__SmartNetButton_KeyDownEventHandler(this.cmdOkCancel_KeyDownEvent);
			// 
			// lblExchangeRate
			// 
			this.lblExchangeRate.AllowDrop = true;
			this.lblExchangeRate.BackColor = System.Drawing.Color.FromArgb(209, 218, 188);
			this.lblExchangeRate.Text = "Exchange Rate";
			this.lblExchangeRate.Location = new System.Drawing.Point(10, 21);
			this.lblExchangeRate.Name = "lblExchangeRate";
			this.lblExchangeRate.Size = new System.Drawing.Size(73, 13);
			this.lblExchangeRate.TabIndex = 6;
			// 
			// lblAmount
			// 
			this.lblAmount.AllowDrop = true;
			this.lblAmount.BackColor = System.Drawing.Color.FromArgb(209, 218, 188);
			this.lblAmount.Text = "Amount";
			this.lblAmount.Location = new System.Drawing.Point(10, 42);
			this.lblAmount.Name = "lblAmount";
			this.lblAmount.Size = new System.Drawing.Size(37, 13);
			this.lblAmount.TabIndex = 5;
			// 
			// txtExchangeRate
			// 
			this.txtExchangeRate.AllowDrop = true;
			// this.txtExchangeRate.DisplayFormat = "####0.0000000###;;0.000;0.000";
			// this.txtExchangeRate.Format = "####0.000######";
			this.txtExchangeRate.Location = new System.Drawing.Point(92, 18);
			// this.txtExchangeRate.MaxValue = 2147483647;
			// this.txtExchangeRate.MinValue = 0;
			this.txtExchangeRate.Name = "txtExchangeRate";
			this.txtExchangeRate.Size = new System.Drawing.Size(102, 19);
			this.txtExchangeRate.TabIndex = 0;
			this.txtExchangeRate.Text = "0.000";
			// 
			// frmGLLedgerFCAmount
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(81, 96, 108);
			this.ClientSize = new System.Drawing.Size(243, 141);
			this.ControlBox = false;
			this.Controls.Add(this.fraLedgerAmountDetails);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			//this.Icon = (System.Drawing.Icon) resources.GetObject("frmGLLedgerFCAmount.Icon");
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(85, 333);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmGLLedgerFCAmount";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.ShowInTaskbar = false;
			// this.Activated += new System.EventHandler(this.frmGLLedgerFCAmount_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
			// this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
			//((System.ComponentModel.ISupportInitialize) this._cmdOkCancel_1).EndInit();
			//((System.ComponentModel.ISupportInitialize) this._cmdOkCancel_0).EndInit();
			//((System.ComponentModel.ISupportInitialize) this.fraLedgerAmountDetails).EndInit();
			this.fraLedgerAmountDetails.ResumeLayout(false);
			this.picOkCancel.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		void ReLoadForm(bool addEvents)
		{
			InitializecmdOkCancel();
		}
		void InitializecmdOkCancel()
		{
			this.cmdOkCancel = new AxSmartNetButtonProject.AxSmartNetButton[2];
			this.cmdOkCancel[1] = _cmdOkCancel_1;
			this.cmdOkCancel[0] = _cmdOkCancel_0;
		}
		#endregion
	}
}//ENDSHERE
