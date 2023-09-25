
namespace Xtreme
{
	partial class frmPayCashPayment
	{

		#region "Upgrade Support "
		private static frmPayCashPayment m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmPayCashPayment DefInstance
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
		public static frmPayCashPayment CreateInstance()
		{
			frmPayCashPayment theInstance = new frmPayCashPayment();
			
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
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "_txtCommonTextBox_2", "_lblCommonLabel_7", "_lblCommonLabel_5", "_lblCommonLabel_6", "txtVoucherDate", "_txtCommonTextBox_0", "_txtCommonTextBox_1", "_lblCommonLabel_2", "_lblCommonLabel_0", "_lblCommonLabel_3", "txtCashAmount", "_lblCommonLabel_10", "_lblCommonLabel_17", "System.Windows.Forms.Label12", "_txtCommonTextBox_3", "_txtDisplayLabel_0", "_txtDisplayLabel_3", "_txtDisplayLabel_2", "_txtDisplayLabel_1", "_lblCommonLabel_16", "_txtDisplayLabel_4", "lblCommonLabel", "txtCommonTextBox", "txtDisplayLabel"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		private System.Windows.Forms.TextBox _txtCommonTextBox_2;
		private System.Windows.Forms.Label _lblCommonLabel_7;
		private System.Windows.Forms.Label _lblCommonLabel_5;
		private System.Windows.Forms.Label _lblCommonLabel_6;
		public Syncfusion.WinForms.Input.SfDateTimeEdit txtVoucherDate;
		private System.Windows.Forms.TextBox _txtCommonTextBox_0;
		private System.Windows.Forms.TextBox _txtCommonTextBox_1;
		private System.Windows.Forms.Label _lblCommonLabel_2;
		private System.Windows.Forms.Label _lblCommonLabel_0;
		private System.Windows.Forms.Label _lblCommonLabel_3;
		public System.Windows.Forms.TextBox txtCashAmount;
		private System.Windows.Forms.Label _lblCommonLabel_10;
		private System.Windows.Forms.Label _lblCommonLabel_17;
		public System.Windows.Forms.Label Label12;
		private System.Windows.Forms.TextBox _txtCommonTextBox_3;
		private System.Windows.Forms.Label _txtDisplayLabel_0;
		private System.Windows.Forms.Label _txtDisplayLabel_3;
		private System.Windows.Forms.Label _txtDisplayLabel_2;
		private System.Windows.Forms.Label _txtDisplayLabel_1;
		private System.Windows.Forms.Label _lblCommonLabel_16;
		private System.Windows.Forms.Label _txtDisplayLabel_4;
		public System.Windows.Forms.Label[] lblCommonLabel = new System.Windows.Forms.Label[18];
		public System.Windows.Forms.TextBox[] txtCommonTextBox = new System.Windows.Forms.TextBox[4];
		public System.Windows.Forms.Label[] txtDisplayLabel = new System.Windows.Forms.Label[5];
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPayCashPayment));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this._txtCommonTextBox_2 = new System.Windows.Forms.TextBox();
			this._lblCommonLabel_7 = new System.Windows.Forms.Label();
			this._lblCommonLabel_5 = new System.Windows.Forms.Label();
			this._lblCommonLabel_6 = new System.Windows.Forms.Label();
			this.txtVoucherDate = new Syncfusion.WinForms.Input.SfDateTimeEdit();
			this._txtCommonTextBox_0 = new System.Windows.Forms.TextBox();
			this._txtCommonTextBox_1 = new System.Windows.Forms.TextBox();
			this._lblCommonLabel_2 = new System.Windows.Forms.Label();
			this._lblCommonLabel_0 = new System.Windows.Forms.Label();
			this._lblCommonLabel_3 = new System.Windows.Forms.Label();
			this.txtCashAmount = new System.Windows.Forms.TextBox();
			this._lblCommonLabel_10 = new System.Windows.Forms.Label();
			this._lblCommonLabel_17 = new System.Windows.Forms.Label();
			this.Label12 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_3 = new System.Windows.Forms.TextBox();
			this._txtDisplayLabel_0 = new System.Windows.Forms.Label();
			this._txtDisplayLabel_3 = new System.Windows.Forms.Label();
			this._txtDisplayLabel_2 = new System.Windows.Forms.Label();
			this._txtDisplayLabel_1 = new System.Windows.Forms.Label();
			this._lblCommonLabel_16 = new System.Windows.Forms.Label();
			this._txtDisplayLabel_4 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// _txtCommonTextBox_2
			// 
			this._txtCommonTextBox_2.AllowDrop = true;
			this._txtCommonTextBox_2.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_2.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_2.Location = new System.Drawing.Point(106, 71);
			this._txtCommonTextBox_2.MaxLength = 20;
			this._txtCommonTextBox_2.Name = "_txtCommonTextBox_2";
			this._txtCommonTextBox_2.Size = new System.Drawing.Size(102, 19);
			this._txtCommonTextBox_2.TabIndex = 2;
			this._txtCommonTextBox_2.Text = "";
			this._txtCommonTextBox_2.Visible = false;
			// this.this._txtCommonTextBox_2.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_2.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _lblCommonLabel_7
			// 
			this._lblCommonLabel_7.AllowDrop = true;
			this._lblCommonLabel_7.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_7.Text = "Reference No.";
			this._lblCommonLabel_7.Location = new System.Drawing.Point(8, 74);
			// // this._lblCommonLabel_7.mLabelId = 614;
			this._lblCommonLabel_7.Name = "_lblCommonLabel_7";
			this._lblCommonLabel_7.Size = new System.Drawing.Size(70, 13);
			this._lblCommonLabel_7.TabIndex = 6;
			this._lblCommonLabel_7.Visible = false;
			// 
			// _lblCommonLabel_5
			// 
			this._lblCommonLabel_5.AllowDrop = true;
			this._lblCommonLabel_5.BackColor = System.Drawing.Color.FromArgb(237, 231, 235);
			this._lblCommonLabel_5.Text = "Voucher No.";
			this._lblCommonLabel_5.Location = new System.Drawing.Point(8, 52);
			// // this._lblCommonLabel_5.mLabelId = 850;
			this._lblCommonLabel_5.Name = "_lblCommonLabel_5";
			this._lblCommonLabel_5.Size = new System.Drawing.Size(61, 14);
			this._lblCommonLabel_5.TabIndex = 7;
			// 
			// _lblCommonLabel_6
			// 
			this._lblCommonLabel_6.AllowDrop = true;
			this._lblCommonLabel_6.BackColor = System.Drawing.Color.FromArgb(237, 231, 235);
			this._lblCommonLabel_6.Text = "Voucher Date";
			this._lblCommonLabel_6.Location = new System.Drawing.Point(228, 52);
			// // this._lblCommonLabel_6.mLabelId = 848;
			this._lblCommonLabel_6.Name = "_lblCommonLabel_6";
			this._lblCommonLabel_6.Size = new System.Drawing.Size(67, 14);
			this._lblCommonLabel_6.TabIndex = 8;
			// 
			// txtVoucherDate
			// 
			this.txtVoucherDate.AllowDrop = true;
			// this.txtVoucherDate.CheckDateRange = false;
			this.txtVoucherDate.Location = new System.Drawing.Point(330, 50);
			// this.txtVoucherDate.MaxDate = 2958465;
			// this.txtVoucherDate.MinDate = 32874;
			this.txtVoucherDate.Name = "txtVoucherDate";
			this.txtVoucherDate.Size = new System.Drawing.Size(102, 19);
			this.txtVoucherDate.TabIndex = 1;
			// this.txtVoucherDate.Text = "18/07/2001";
			// this.txtVoucherDate.Value = 37090;
			// 
			// _txtCommonTextBox_0
			// 
			this._txtCommonTextBox_0.AllowDrop = true;
			this._txtCommonTextBox_0.BackColor = System.Drawing.Color.White;
			// this._txtCommonTextBox_0.bolNumericOnly = true;
			this._txtCommonTextBox_0.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_0.Location = new System.Drawing.Point(106, 50);
			// this._txtCommonTextBox_0.mDropDownType = System.Windows.Forms.TextBox.DropDownTypes.ddtNextNumber;
			this._txtCommonTextBox_0.Name = "_txtCommonTextBox_0";
			// this._txtCommonTextBox_0.ShowButton = true;
			this._txtCommonTextBox_0.Size = new System.Drawing.Size(102, 19);
			this._txtCommonTextBox_0.TabIndex = 0;
			this._txtCommonTextBox_0.Text = "";
			// this.this._txtCommonTextBox_0.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_0.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _txtCommonTextBox_1
			// 
			this._txtCommonTextBox_1.AllowDrop = true;
			this._txtCommonTextBox_1.BackColor = System.Drawing.Color.White;
			// this._txtCommonTextBox_1.bolNumericOnly = true;
			this._txtCommonTextBox_1.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_1.Location = new System.Drawing.Point(106, 104);
			this._txtCommonTextBox_1.MaxLength = 4;
			this._txtCommonTextBox_1.Name = "_txtCommonTextBox_1";
			// this._txtCommonTextBox_1.ShowButton = true;
			this._txtCommonTextBox_1.Size = new System.Drawing.Size(101, 19);
			this._txtCommonTextBox_1.TabIndex = 3;
			this._txtCommonTextBox_1.Text = "";
			// this.this._txtCommonTextBox_1.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_1.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _lblCommonLabel_2
			// 
			this._lblCommonLabel_2.AllowDrop = true;
			this._lblCommonLabel_2.BackColor = System.Drawing.Color.FromArgb(237, 231, 235);
			this._lblCommonLabel_2.Text = "Loan No.";
			this._lblCommonLabel_2.Location = new System.Drawing.Point(8, 107);
			// // this._lblCommonLabel_2.mLabelId = 1044;
			this._lblCommonLabel_2.Name = "_lblCommonLabel_2";
			this._lblCommonLabel_2.Size = new System.Drawing.Size(43, 14);
			this._lblCommonLabel_2.TabIndex = 9;
			// 
			// _lblCommonLabel_0
			// 
			this._lblCommonLabel_0.AllowDrop = true;
			this._lblCommonLabel_0.BackColor = System.Drawing.Color.FromArgb(237, 231, 235);
			this._lblCommonLabel_0.Text = "Employee Code";
			this._lblCommonLabel_0.Location = new System.Drawing.Point(8, 127);
			// // this._lblCommonLabel_0.mLabelId = 236;
			this._lblCommonLabel_0.Name = "_lblCommonLabel_0";
			this._lblCommonLabel_0.Size = new System.Drawing.Size(74, 14);
			this._lblCommonLabel_0.TabIndex = 10;
			// 
			// _lblCommonLabel_3
			// 
			this._lblCommonLabel_3.AllowDrop = true;
			this._lblCommonLabel_3.BackColor = System.Drawing.Color.FromArgb(237, 231, 235);
			this._lblCommonLabel_3.Text = "Loan Amount";
			this._lblCommonLabel_3.Location = new System.Drawing.Point(8, 149);
			// // this._lblCommonLabel_3.mLabelId = 404;
			this._lblCommonLabel_3.Name = "_lblCommonLabel_3";
			this._lblCommonLabel_3.Size = new System.Drawing.Size(64, 14);
			this._lblCommonLabel_3.TabIndex = 11;
			// 
			// txtCashAmount
			// 
			this.txtCashAmount.AllowDrop = true;
			// this.txtCashAmount.DisplayFormat = "####0.000###;;0.000;0.000";
			// this.txtCashAmount.Format = "###########0.000";
			this.txtCashAmount.Location = new System.Drawing.Point(330, 167);
			// this.txtCashAmount.MaxValue = 2147483647;
			// this.txtCashAmount.MinValue = 0;
			this.txtCashAmount.Name = "txtCashAmount";
			this.txtCashAmount.Size = new System.Drawing.Size(101, 19);
			this.txtCashAmount.TabIndex = 4;
			this.txtCashAmount.Text = "0.000";
			// 
			// _lblCommonLabel_10
			// 
			this._lblCommonLabel_10.AllowDrop = true;
			this._lblCommonLabel_10.BackColor = System.Drawing.Color.FromArgb(237, 231, 235);
			this._lblCommonLabel_10.Text = "Cash Paid";
			this._lblCommonLabel_10.Location = new System.Drawing.Point(228, 170);
			// // this._lblCommonLabel_10.mLabelId = 1972;
			this._lblCommonLabel_10.Name = "_lblCommonLabel_10";
			this._lblCommonLabel_10.Size = new System.Drawing.Size(48, 14);
			this._lblCommonLabel_10.TabIndex = 12;
			// 
			// _lblCommonLabel_17
			// 
			this._lblCommonLabel_17.AllowDrop = true;
			this._lblCommonLabel_17.BackColor = System.Drawing.Color.FromArgb(237, 231, 235);
			this._lblCommonLabel_17.Text = "Loan Date";
			this._lblCommonLabel_17.Location = new System.Drawing.Point(230, 106);
			// // this._lblCommonLabel_17.mLabelId = 1045;
			this._lblCommonLabel_17.Name = "_lblCommonLabel_17";
			this._lblCommonLabel_17.Size = new System.Drawing.Size(49, 14);
			this._lblCommonLabel_17.TabIndex = 13;
			// 
			// System.Windows.Forms.Label12
			// 
			this.Label12.AllowDrop = true;
			this.Label12.BackColor = System.Drawing.Color.FromArgb(237, 231, 235);
			this.Label12.Text = "Description";
			this.Label12.Location = new System.Drawing.Point(8, 202);
			// this.Label12.mLabelId = 1971;
			this.Label12.Name = "System.Windows.Forms.Label12";
			this.Label12.Size = new System.Drawing.Size(50, 14);
			this.Label12.TabIndex = 14;
			// 
			// _txtCommonTextBox_3
			// 
			this._txtCommonTextBox_3.AllowDrop = true;
			this._txtCommonTextBox_3.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_3.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_3.Location = new System.Drawing.Point(106, 200);
			this._txtCommonTextBox_3.MaxLength = 100;
			this._txtCommonTextBox_3.Name = "_txtCommonTextBox_3";
			this._txtCommonTextBox_3.Size = new System.Drawing.Size(328, 19);
			this._txtCommonTextBox_3.TabIndex = 5;
			this._txtCommonTextBox_3.Text = "";
			// this.this._txtCommonTextBox_3.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_3.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _txtDisplayLabel_0
			// 
			this._txtDisplayLabel_0.AllowDrop = true;
			this._txtDisplayLabel_0.Location = new System.Drawing.Point(331, 104);
			this._txtDisplayLabel_0.Name = "_txtDisplayLabel_0";
			this._txtDisplayLabel_0.Size = new System.Drawing.Size(101, 19);
			this._txtDisplayLabel_0.TabIndex = 15;
			// 
			// _txtDisplayLabel_3
			// 
			// this._txtDisplayLabel_3.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
			this._txtDisplayLabel_3.AllowDrop = true;
			this._txtDisplayLabel_3.Location = new System.Drawing.Point(106, 146);
			this._txtDisplayLabel_3.Name = "_txtDisplayLabel_3";
			this._txtDisplayLabel_3.Size = new System.Drawing.Size(101, 19);
			this._txtDisplayLabel_3.TabIndex = 16;
			// 
			// _txtDisplayLabel_2
			// 
			this._txtDisplayLabel_2.AllowDrop = true;
			this._txtDisplayLabel_2.Location = new System.Drawing.Point(209, 125);
			this._txtDisplayLabel_2.Name = "_txtDisplayLabel_2";
			this._txtDisplayLabel_2.Size = new System.Drawing.Size(223, 19);
			this._txtDisplayLabel_2.TabIndex = 17;
			// 
			// _txtDisplayLabel_1
			// 
			this._txtDisplayLabel_1.AllowDrop = true;
			this._txtDisplayLabel_1.Location = new System.Drawing.Point(106, 125);
			this._txtDisplayLabel_1.Name = "_txtDisplayLabel_1";
			this._txtDisplayLabel_1.Size = new System.Drawing.Size(101, 19);
			this._txtDisplayLabel_1.TabIndex = 18;
			// 
			// _lblCommonLabel_16
			// 
			this._lblCommonLabel_16.AllowDrop = true;
			this._lblCommonLabel_16.BackColor = System.Drawing.Color.FromArgb(237, 231, 235);
			this._lblCommonLabel_16.Text = "Balance";
			this._lblCommonLabel_16.Location = new System.Drawing.Point(228, 149);
			// // this._lblCommonLabel_16.mLabelId = 1862;
			this._lblCommonLabel_16.Name = "_lblCommonLabel_16";
			this._lblCommonLabel_16.Size = new System.Drawing.Size(39, 14);
			this._lblCommonLabel_16.TabIndex = 19;
			// 
			// _txtDisplayLabel_4
			// 
			// this._txtDisplayLabel_4.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
			this._txtDisplayLabel_4.AllowDrop = true;
			this._txtDisplayLabel_4.Location = new System.Drawing.Point(331, 146);
			this._txtDisplayLabel_4.Name = "_txtDisplayLabel_4";
			this._txtDisplayLabel_4.Size = new System.Drawing.Size(101, 19);
			this._txtDisplayLabel_4.TabIndex = 20;
			// 
			// frmPayCashPayment
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.ClientSize = new System.Drawing.Size(456, 234);
			this.Controls.Add(this._txtCommonTextBox_2);
			this.Controls.Add(this._lblCommonLabel_7);
			this.Controls.Add(this._lblCommonLabel_5);
			this.Controls.Add(this._lblCommonLabel_6);
			this.Controls.Add(this.txtVoucherDate);
			this.Controls.Add(this._txtCommonTextBox_0);
			this.Controls.Add(this._txtCommonTextBox_1);
			this.Controls.Add(this._lblCommonLabel_2);
			this.Controls.Add(this._lblCommonLabel_0);
			this.Controls.Add(this._lblCommonLabel_3);
			this.Controls.Add(this.txtCashAmount);
			this.Controls.Add(this._lblCommonLabel_10);
			this.Controls.Add(this._lblCommonLabel_17);
			this.Controls.Add(this.Label12);
			this.Controls.Add(this._txtCommonTextBox_3);
			this.Controls.Add(this._txtDisplayLabel_0);
			this.Controls.Add(this._txtDisplayLabel_3);
			this.Controls.Add(this._txtDisplayLabel_2);
			this.Controls.Add(this._txtDisplayLabel_1);
			this.Controls.Add(this._lblCommonLabel_16);
			this.Controls.Add(this._txtDisplayLabel_4);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			//this.Icon = (System.Drawing.Icon) resources.GetObject("frmPayCashPayment.Icon");
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(52, 153);
			this.MaximizeBox = true;
			this.MinimizeBox = true;
			this.Name = "frmPayCashPayment";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Cash Payment";
			// this.Activated += new System.EventHandler(this.frmPayCashPayment_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
			// this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
			this.ResumeLayout(false);
		}
		// 
		void InitializetxtDisplayLabel()
		{
			this.txtDisplayLabel = new System.Windows.Forms.Label[5];
			this.txtDisplayLabel[0] = _txtDisplayLabel_0;
			this.txtDisplayLabel[3] = _txtDisplayLabel_3;
			this.txtDisplayLabel[2] = _txtDisplayLabel_2;
			this.txtDisplayLabel[1] = _txtDisplayLabel_1;
			this.txtDisplayLabel[4] = _txtDisplayLabel_4;
		}
		void InitializetxtCommonTextBox()
		{
			this.txtCommonTextBox = new System.Windows.Forms.TextBox[4];
			this.txtCommonTextBox[2] = _txtCommonTextBox_2;
			this.txtCommonTextBox[0] = _txtCommonTextBox_0;
			this.txtCommonTextBox[1] = _txtCommonTextBox_1;
			this.txtCommonTextBox[3] = _txtCommonTextBox_3;
		}
		void InitializelblCommonLabel()
		{
			this.lblCommonLabel = new System.Windows.Forms.Label[18];
			this.lblCommonLabel[7] = _lblCommonLabel_7;
			this.lblCommonLabel[5] = _lblCommonLabel_5;
			this.lblCommonLabel[6] = _lblCommonLabel_6;
			this.lblCommonLabel[2] = _lblCommonLabel_2;
			this.lblCommonLabel[0] = _lblCommonLabel_0;
			this.lblCommonLabel[3] = _lblCommonLabel_3;
			this.lblCommonLabel[10] = _lblCommonLabel_10;
			this.lblCommonLabel[17] = _lblCommonLabel_17;
			this.lblCommonLabel[16] = _lblCommonLabel_16;
		}
		#endregion
	}
}//ENDSHERE
