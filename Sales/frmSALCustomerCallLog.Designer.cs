
namespace Xtreme
{
	partial class frmSALCustomerCallLog
	{

		#region "Upgrade Support "
		private static frmSALCustomerCallLog m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmSALCustomerCallLog DefInstance
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
		public static frmSALCustomerCallLog CreateInstance()
		{
			frmSALCustomerCallLog theInstance = new frmSALCustomerCallLog();
			
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
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "txtCustomerName", "txtCustomerCode", "txtVoucherDate", "txtVoucherNo", "txtSalesmanName", "txtSalesmanCode", "txtComment", "txtCallRcvrTime", "cmbCallTime", "txtCallDate", "Label_2", "Label_0", "Label_1", "Label_3", "Label_4", "Label_5", "Label_6", "Label_7", "txtComment2", "Label_8", "System.Windows.Forms.Label"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public System.Windows.Forms.Label txtCustomerName;
		public System.Windows.Forms.TextBox txtCustomerCode;
		public Syncfusion.WinForms.Input.SfDateTimeEdit txtVoucherDate;
		public System.Windows.Forms.TextBox txtVoucherNo;
		public System.Windows.Forms.Label txtSalesmanName;
		public System.Windows.Forms.TextBox txtSalesmanCode;
		public System.Windows.Forms.TextBox txtComment;
		//public AxXtremeSuiteControls.AxDateTimePicker txtCallRcvrTime;
		public System.Windows.Forms.ComboBox cmbCallTime;
		public Syncfusion.WinForms.Input.SfDateTimeEdit txtCallDate;
		private System.Windows.Forms.Label Label_2;
		private System.Windows.Forms.Label Label_0;
		private System.Windows.Forms.Label Label_1;
		private System.Windows.Forms.Label Label_3;
		private System.Windows.Forms.Label Label_4;
		private System.Windows.Forms.Label Label_5;
		private System.Windows.Forms.Label Label_6;
		private System.Windows.Forms.Label Label_7;
		public System.Windows.Forms.TextBox txtComment2;
		private System.Windows.Forms.Label Label_8;
		public System.Windows.Forms.Label[] Label = new System.Windows.Forms.Label[9];
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSALCustomerCallLog));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this.txtCustomerName = new System.Windows.Forms.Label();
			this.txtCustomerCode = new System.Windows.Forms.TextBox();
			this.txtVoucherDate = new Syncfusion.WinForms.Input.SfDateTimeEdit();
			this.txtVoucherNo = new System.Windows.Forms.TextBox();
			this.txtSalesmanName = new System.Windows.Forms.Label();
			this.txtSalesmanCode = new System.Windows.Forms.TextBox();
			this.txtComment = new System.Windows.Forms.TextBox();
			//this.txtCallRcvrTime = new AxXtremeSuiteControls.AxDateTimePicker();
			this.cmbCallTime = new System.Windows.Forms.ComboBox();
			this.txtCallDate = new Syncfusion.WinForms.Input.SfDateTimeEdit();
			this.Label_2 = new System.Windows.Forms.Label();
			this.Label_0 = new System.Windows.Forms.Label();
			this.Label_1 = new System.Windows.Forms.Label();
			this.Label_3 = new System.Windows.Forms.Label();
			this.Label_4 = new System.Windows.Forms.Label();
			this.Label_5 = new System.Windows.Forms.Label();
			this.Label_6 = new System.Windows.Forms.Label();
			this.Label_7 = new System.Windows.Forms.Label();
			this.txtComment2 = new System.Windows.Forms.TextBox();
			this.Label_8 = new System.Windows.Forms.Label();
			// //((System.ComponentModel.ISupportInitialize) this.txtCallRcvrTime).BeginInit();
			this.SuspendLayout();
			// 
			// txtCustomerName
			// 
			//this.txtCustomerName.AllowDrop = true;
			this.txtCustomerName.Location = new System.Drawing.Point(208, 68);
			this.txtCustomerName.Name = "txtCustomerName";
			this.txtCustomerName.Size = new System.Drawing.Size(313, 19);
			this.txtCustomerName.TabIndex = 5;
			this.txtCustomerName.TabStop = false;
			// 
			// txtCustomerCode
			// 
			//this.txtCustomerCode.AllowDrop = true;
			this.txtCustomerCode.BackColor = System.Drawing.Color.White;
			this.txtCustomerCode.ForeColor = System.Drawing.Color.Black;
			this.txtCustomerCode.Location = new System.Drawing.Point(114, 68);
			this.txtCustomerCode.Name = "txtCustomerCode";
			// this.txtCustomerCode.ShowButton = true;
			this.txtCustomerCode.Size = new System.Drawing.Size(89, 19);
			this.txtCustomerCode.TabIndex = 2;
			this.txtCustomerCode.Text = "";
			// this.// = "";
			// this.//this.txtCustomerCode.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(//this.txtCustomerCode_DropButtonClick);
			// this.txtCustomerCode.Leave += new System.EventHandler(this.txtCustomerCode_Leave);
			// 
			// txtVoucherDate
			// 
			//this.txtVoucherDate.AllowDrop = true;
			this.txtVoucherDate.Location = new System.Drawing.Point(114, 20);
			// this.txtVoucherDate.MaxDate = 2958465;
			// this.txtVoucherDate.MinDate = -657434;
			this.txtVoucherDate.Name = "txtVoucherDate";
			this.txtVoucherDate.Size = new System.Drawing.Size(89, 19);
			this.txtVoucherDate.TabIndex = 0;
			// this.txtVoucherDate.Text = "11/22/2013";
			// this.txtVoucherDate.Value = 41600;
			// 
			// txtVoucherNo
			// 
			//this.txtVoucherNo.AllowDrop = true;
			this.txtVoucherNo.BackColor = System.Drawing.Color.FromArgb(239, 239, 239);
			this.txtVoucherNo.Enabled = false;
			this.txtVoucherNo.ForeColor = System.Drawing.Color.Black;
			this.txtVoucherNo.Location = new System.Drawing.Point(114, 44);
			this.txtVoucherNo.Name = "txtVoucherNo";
			this.txtVoucherNo.Size = new System.Drawing.Size(89, 19);
			this.txtVoucherNo.TabIndex = 9;
			this.txtVoucherNo.Text = "";
			// this.// = "";
			// 
			// txtSalesmanName
			// 
			//this.txtSalesmanName.AllowDrop = true;
			this.txtSalesmanName.Location = new System.Drawing.Point(208, 92);
			this.txtSalesmanName.Name = "txtSalesmanName";
			this.txtSalesmanName.Size = new System.Drawing.Size(313, 19);
			this.txtSalesmanName.TabIndex = 10;
			this.txtSalesmanName.TabStop = false;
			// 
			// txtSalesmanCode
			// 
			//this.txtSalesmanCode.AllowDrop = true;
			this.txtSalesmanCode.BackColor = System.Drawing.Color.White;
			this.txtSalesmanCode.ForeColor = System.Drawing.Color.Black;
			this.txtSalesmanCode.Location = new System.Drawing.Point(114, 92);
			this.txtSalesmanCode.Name = "txtSalesmanCode";
			// this.txtSalesmanCode.ShowButton = true;
			this.txtSalesmanCode.Size = new System.Drawing.Size(89, 19);
			this.txtSalesmanCode.TabIndex = 3;
			this.txtSalesmanCode.Text = "";
			// this.// = "";
			// this.//this.txtSalesmanCode.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(//this.txtSalesmanCode_DropButtonClick);
			// this.txtSalesmanCode.Leave += new System.EventHandler(this.txtSalesmanCode_Leave);
			// 
			// txtComment
			// 
			//this.txtComment.AllowDrop = true;
			this.txtComment.BackColor = System.Drawing.Color.White;
			this.txtComment.ForeColor = System.Drawing.Color.Black;
			this.txtComment.Location = new System.Drawing.Point(114, 142);
			this.txtComment.Name = "txtComment";
			this.txtComment.Size = new System.Drawing.Size(405, 55);
			this.txtComment.TabIndex = 7;
			this.txtComment.Text = "";
			// 
			// txtCallRcvrTime
			// 
			////this.txtCallRcvrTime.AllowDrop = true;
			//this.txtCallRcvrTime.Location = new System.Drawing.Point(418, 20);
			//this.txtCallRcvrTime.Name = "txtCallRcvrTime";
			////
			//this.txtCallRcvrTime.Size = new System.Drawing.Size(101, 21);
			//this.txtCallRcvrTime.TabIndex = 1;
			// 
			// cmbCallTime
			// 
			//this.cmbCallTime.AllowDrop = true;
			this.cmbCallTime.Location = new System.Drawing.Point(416, 116);
			this.cmbCallTime.Name = "cmbCallTime";
			this.cmbCallTime.Size = new System.Drawing.Size(101, 21);
			this.cmbCallTime.TabIndex = 6;
			// 
			// txtCallDate
			// 
			//this.txtCallDate.AllowDrop = true;
			this.txtCallDate.Location = new System.Drawing.Point(114, 116);
			// this.txtCallDate.MaxDate = 2958465;
			// this.txtCallDate.MinDate = -657434;
			this.txtCallDate.Name = "txtCallDate";
			this.txtCallDate.Size = new System.Drawing.Size(89, 19);
			this.txtCallDate.TabIndex = 4;
			// this.txtCallDate.Text = "11/22/2013";
			// this.txtCallDate.Value = 41600;
			// 
			// Label_2
			// 
			//this.Label_2.AllowDrop = true;
			this.Label_2.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.Label_2.Text = "Voucher No";
			this.Label_2.ForeColor = System.Drawing.SystemColors.WindowText;
			this.Label_2.Location = new System.Drawing.Point(6, 48);
			this.Label_2.Name = "Label_2";
			this.Label_2.Size = new System.Drawing.Size(58, 14);
			this.Label_2.TabIndex = 11;
			// 
			// Label_0
			// 
			//this.Label_0.AllowDrop = true;
			this.Label_0.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.Label_0.Text = "Customer Name";
			this.Label_0.ForeColor = System.Drawing.SystemColors.WindowText;
			this.Label_0.Location = new System.Drawing.Point(6, 72);
			this.Label_0.Name = "Label_0";
			this.Label_0.Size = new System.Drawing.Size(19, 14);
			this.Label_0.TabIndex = 12;
			// 
			// Label_1
			// 
			//this.Label_1.AllowDrop = true;
			this.Label_1.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.Label_1.Text = "Voucher Date";
			this.Label_1.ForeColor = System.Drawing.SystemColors.WindowText;
			this.Label_1.Location = new System.Drawing.Point(6, 24);
			this.Label_1.Name = "Label_1";
			this.Label_1.Size = new System.Drawing.Size(67, 14);
			this.Label_1.TabIndex = 13;
			// 
			// Label_3
			// 
			//this.Label_3.AllowDrop = true;
			this.Label_3.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.Label_3.Text = "Salesman";
			this.Label_3.ForeColor = System.Drawing.SystemColors.WindowText;
			this.Label_3.Location = new System.Drawing.Point(6, 94);
			this.Label_3.Name = "Label_3";
			this.Label_3.Size = new System.Drawing.Size(47, 14);
			this.Label_3.TabIndex = 14;
			// 
			// Label_4
			// 
			//this.Label_4.AllowDrop = true;
			this.Label_4.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.Label_4.Text = "Appointment Date";
			this.Label_4.ForeColor = System.Drawing.SystemColors.WindowText;
			this.Label_4.Location = new System.Drawing.Point(6, 120);
			this.Label_4.Name = "Label_4";
			this.Label_4.Size = new System.Drawing.Size(85, 14);
			this.Label_4.TabIndex = 15;
			// 
			// Label_5
			// 
			//this.Label_5.AllowDrop = true;
			this.Label_5.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.Label_5.Text = "Remarks";
			this.Label_5.ForeColor = System.Drawing.SystemColors.WindowText;
			this.Label_5.Location = new System.Drawing.Point(6, 146);
			this.Label_5.Name = "Label_5";
			this.Label_5.Size = new System.Drawing.Size(42, 14);
			this.Label_5.TabIndex = 16;
			// 
			// Label_6
			// 
			//this.Label_6.AllowDrop = true;
			this.Label_6.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.Label_6.Text = "Call Recd At";
			this.Label_6.ForeColor = System.Drawing.SystemColors.WindowText;
			this.Label_6.Location = new System.Drawing.Point(326, 24);
			this.Label_6.Name = "Label_6";
			this.Label_6.Size = new System.Drawing.Size(59, 14);
			this.Label_6.TabIndex = 17;
			// 
			// Label_7
			// 
			//this.Label_7.AllowDrop = true;
			this.Label_7.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.Label_7.Text = "Time Selection";
			this.Label_7.ForeColor = System.Drawing.SystemColors.WindowText;
			this.Label_7.Location = new System.Drawing.Point(326, 120);
			this.Label_7.Name = "Label_7";
			this.Label_7.Size = new System.Drawing.Size(69, 14);
			this.Label_7.TabIndex = 18;
			// 
			// txtComment2
			// 
			//this.txtComment2.AllowDrop = true;
			this.txtComment2.BackColor = System.Drawing.Color.White;
			this.txtComment2.ForeColor = System.Drawing.Color.Black;
			this.txtComment2.Location = new System.Drawing.Point(114, 204);
			this.txtComment2.Name = "txtComment2";
			this.txtComment2.Size = new System.Drawing.Size(405, 55);
			this.txtComment2.TabIndex = 8;
			this.txtComment2.Text = "";
			// 
			// Label_8
			// 
			//this.Label_8.AllowDrop = true;
			this.Label_8.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.Label_8.Text = "Remarks 2";
			this.Label_8.ForeColor = System.Drawing.SystemColors.WindowText;
			this.Label_8.Location = new System.Drawing.Point(6, 208);
			this.Label_8.Name = "Label_8";
			this.Label_8.Size = new System.Drawing.Size(51, 14);
			this.Label_8.TabIndex = 19;
			// 
			// frmSALCustomerCallLog
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.ClientSize = new System.Drawing.Size(732, 362);
			this.Controls.Add(this.txtCustomerName);
			this.Controls.Add(this.txtCustomerCode);
			this.Controls.Add(this.txtVoucherDate);
			this.Controls.Add(this.txtVoucherNo);
			this.Controls.Add(this.txtSalesmanName);
			this.Controls.Add(this.txtSalesmanCode);
			this.Controls.Add(this.txtComment);
			//this.Controls.Add(this.txtCallRcvrTime);
			this.Controls.Add(this.cmbCallTime);
			this.Controls.Add(this.txtCallDate);
			this.Controls.Add(this.Label_2);
			this.Controls.Add(this.Label_0);
			this.Controls.Add(this.Label_1);
			this.Controls.Add(this.Label_3);
			this.Controls.Add(this.Label_4);
			this.Controls.Add(this.Label_5);
			this.Controls.Add(this.Label_6);
			this.Controls.Add(this.Label_7);
			this.Controls.Add(this.txtComment2);
			this.Controls.Add(this.Label_8);
			this.Font = new System.Drawing.Font("Tahoma", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 178);
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(292, 255);
			this.MaximizeBox = true;
			this.MinimizeBox = true;
			this.Name = "frmSALCustomerCallLog";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Customer Call Log";
			// this.Activated += new System.EventHandler(this.frmSALCustomerCallLog_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
			// this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
			//this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Form_KeyPress);
			//((System.ComponentModel.ISupportInitialize) this.txtCallRcvrTime).EndInit();
			this.ResumeLayout(false);
		}
		// 
		void InitializeSystemWindowsFormsLabel()
		{
			this.Label = new System.Windows.Forms.Label[9];
			this.Label[2] = Label_2;
			this.Label[0] = Label_0;
			this.Label[1] = Label_1;
			this.Label[3] = Label_3;
			this.Label[4] = Label_4;
			this.Label[5] = Label_5;
			this.Label[6] = Label_6;
			this.Label[7] = Label_7;
			this.Label[8] = Label_8;
		}
		#endregion
	}
}//ENDSHERE
