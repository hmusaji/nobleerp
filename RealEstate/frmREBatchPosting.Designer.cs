
namespace Xtreme
{
	partial class frmREBatchPosting
	{

		
		#region "Windows Form Designer generated code "
		public static frmREBatchPosting CreateInstance()
		{
			frmREBatchPosting theInstance = new frmREBatchPosting();
			
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
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "lblTransactionType", "cmbTransactionType", "txtToVoucherNo", "txtFromVoucherNo", "lblToDate", "lblFromDate", "txtFromDate", "txtToDate", "System.Windows.Forms.Label1", "System.Windows.Forms.Label2", "cntMainParameter", "cmdOKCancel"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public System.Windows.Forms.Label lblTransactionType;
		public System.Windows.Forms.ComboBox cmbTransactionType;
		public System.Windows.Forms.TextBox txtToVoucherNo;
		public System.Windows.Forms.TextBox txtFromVoucherNo;
		public System.Windows.Forms.Label lblToDate;
		public System.Windows.Forms.Label lblFromDate;
		public Syncfusion.WinForms.Input.SfDateTimeEdit txtFromDate;
		public Syncfusion.WinForms.Input.SfDateTimeEdit txtToDate;
		public System.Windows.Forms.Label Label1;
		public System.Windows.Forms.Label Label2;
		public System.Windows.Forms.Panel cntMainParameter;
		public UCOkCancel cmdOKCancel;
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmREBatchPosting));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this.cntMainParameter = new System.Windows.Forms.Panel();
			this.lblTransactionType = new System.Windows.Forms.Label();
			this.cmbTransactionType = new System.Windows.Forms.ComboBox();
			this.txtToVoucherNo = new System.Windows.Forms.TextBox();
			this.txtFromVoucherNo = new System.Windows.Forms.TextBox();
			this.lblToDate = new System.Windows.Forms.Label();
			this.lblFromDate = new System.Windows.Forms.Label();
			this.txtFromDate = new Syncfusion.WinForms.Input.SfDateTimeEdit();
			this.txtToDate = new Syncfusion.WinForms.Input.SfDateTimeEdit();
			this.Label1 = new System.Windows.Forms.Label();
			this.Label2 = new System.Windows.Forms.Label();
			this.cmdOKCancel = new UCOkCancel();
			// //((System.ComponentModel.ISupportInitialize) this.cntMainParameter).BeginInit();
			this.cntMainParameter.SuspendLayout();
			this.SuspendLayout();
			// 
			// cntMainParameter
			// 
			this.cntMainParameter.AllowDrop = true;
			this.cntMainParameter.Controls.Add(this.lblTransactionType);
			this.cntMainParameter.Controls.Add(this.cmbTransactionType);
			this.cntMainParameter.Controls.Add(this.txtToVoucherNo);
			this.cntMainParameter.Controls.Add(this.txtFromVoucherNo);
			this.cntMainParameter.Controls.Add(this.lblToDate);
			this.cntMainParameter.Controls.Add(this.lblFromDate);
			this.cntMainParameter.Controls.Add(this.txtFromDate);
			this.cntMainParameter.Controls.Add(this.txtToDate);
			this.cntMainParameter.Controls.Add(this.Label1);
			this.cntMainParameter.Controls.Add(this.Label2);
			this.cntMainParameter.Location = new System.Drawing.Point(4, 8);
			this.cntMainParameter.Name = "cntMainParameter";
			//
			this.cntMainParameter.Size = new System.Drawing.Size(481, 144);
			this.cntMainParameter.TabIndex = 6;
			// 
			// lblTransactionType
			// 
			this.lblTransactionType.AllowDrop = true;
			this.lblTransactionType.Location = new System.Drawing.Point(8, 24);
			this.lblTransactionType.Name = "lblTransactionType";
			this.lblTransactionType.Size = new System.Drawing.Size(83, 13);
			this.lblTransactionType.TabIndex = 7;
			// 
			// cmbTransactionType
			// 
			this.cmbTransactionType.AllowDrop = true;
			this.cmbTransactionType.Location = new System.Drawing.Point(112, 20);
			this.cmbTransactionType.Name = "cmbTransactionType";
			this.cmbTransactionType.Size = new System.Drawing.Size(227, 21);
			this.cmbTransactionType.TabIndex = 0;
			// 
			// txtToVoucherNo
			// 
			this.txtToVoucherNo.AllowDrop = true;
			this.txtToVoucherNo.BackColor = System.Drawing.Color.White;
			this.txtToVoucherNo.ForeColor = System.Drawing.Color.Black;
			this.txtToVoucherNo.Location = new System.Drawing.Point(364, 95);
			this.txtToVoucherNo.Name = "txtToVoucherNo";
			this.txtToVoucherNo.Size = new System.Drawing.Size(101, 19);
			this.txtToVoucherNo.TabIndex = 4;
			this.txtToVoucherNo.Text = "";
			// this.this.txtToVoucherNo.Watermark = "";
			// this.txtToVoucherNo.Leave += new System.EventHandler(this.txtToVoucherNo_Leave);
			// 
			// txtFromVoucherNo
			// 
			this.txtFromVoucherNo.AllowDrop = true;
			this.txtFromVoucherNo.BackColor = System.Drawing.Color.White;
			this.txtFromVoucherNo.ForeColor = System.Drawing.Color.Black;
			this.txtFromVoucherNo.Location = new System.Drawing.Point(364, 74);
			this.txtFromVoucherNo.Name = "txtFromVoucherNo";
			this.txtFromVoucherNo.Size = new System.Drawing.Size(101, 19);
			this.txtFromVoucherNo.TabIndex = 3;
			this.txtFromVoucherNo.Text = "";
			// this.this.txtFromVoucherNo.Watermark = "";
			// this.txtFromVoucherNo.Leave += new System.EventHandler(this.txtFromVoucherNo_Leave);
			// 
			// lblToDate
			// 
			this.lblToDate.AllowDrop = true;
			this.lblToDate.Location = new System.Drawing.Point(8, 98);
			this.lblToDate.Name = "lblToDate";
			this.lblToDate.Size = new System.Drawing.Size(38, 13);
			this.lblToDate.TabIndex = 8;
			// 
			// lblFromDate
			// 
			this.lblFromDate.AllowDrop = true;
			this.lblFromDate.Location = new System.Drawing.Point(8, 77);
			this.lblFromDate.Name = "lblFromDate";
			this.lblFromDate.Size = new System.Drawing.Size(50, 13);
			this.lblFromDate.TabIndex = 9;
			// 
			// txtFromDate
			// 
			this.txtFromDate.AllowDrop = true;
			this.txtFromDate.Location = new System.Drawing.Point(112, 74);
			// this.txtFromDate.MaxDate = 2958465;
			// this.txtFromDate.MinDate = -657434;
			this.txtFromDate.Name = "txtFromDate";
			this.txtFromDate.Size = new System.Drawing.Size(101, 19);
			this.txtFromDate.TabIndex = 1;
			// this.txtFromDate.Text = "13/02/2014";
			// 
			// txtToDate
			// 
			this.txtToDate.AllowDrop = true;
			this.txtToDate.Location = new System.Drawing.Point(112, 95);
			// this.txtToDate.MaxDate = 2958465;
			// this.txtToDate.MinDate = -657434;
			this.txtToDate.Name = "txtToDate";
			this.txtToDate.Size = new System.Drawing.Size(101, 19);
			this.txtToDate.TabIndex = 2;
			// this.txtToDate.Text = "13/02/2014";
			// 
			// System.Windows.Forms.Label1
			// 
			this.Label1.AllowDrop = true;
			this.Label1.Location = new System.Drawing.Point(260, 98);
			this.Label1.Name = "System.Windows.Forms.Label1";
			this.Label1.Size = new System.Drawing.Size(70, 13);
			this.Label1.TabIndex = 10;
			// 
			// System.Windows.Forms.Label2
			// 
			this.Label2.AllowDrop = true;
			this.Label2.Location = new System.Drawing.Point(260, 77);
			this.Label2.Name = "System.Windows.Forms.Label2";
			this.Label2.Size = new System.Drawing.Size(82, 13);
			this.Label2.TabIndex = 11;
			// 
			// cmdOKCancel
			// 
			this.cmdOKCancel.AllowDrop = true;
			this.cmdOKCancel.Location = new System.Drawing.Point(143, 166);
			this.cmdOKCancel.Name = "cmdOKCancel";
			this.cmdOKCancel.Size = new System.Drawing.Size(206, 31);
			this.cmdOKCancel.TabIndex = 5;
			//this.cmdOKCancel.CancelClick += new UCOkCancel.CancelClickHandler(this.cmdOKCancel_CancelClick);
			//this.cmdOKCancel.OKClick += new UCOkCancel.OKClickHandler(this.cmdOKCancel_OKClick);
			// 
			// frmREBatchPosting
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.ClientSize = new System.Drawing.Size(492, 207);
			this.Controls.Add(this.cntMainParameter);
			this.Controls.Add(this.cmdOKCancel);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			//this.Icon = (System.Drawing.Icon) resources.GetObject("frmREBatchPosting.Icon");
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(129, 118);
			this.MaximizeBox = false;
			this.MinimizeBox = true;
			this.Name = "frmREBatchPosting";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Tag = "False";
			this.Text = "Periodical Posting (General Ledger System)";
			// this.Activated += new System.EventHandler(this.frmREBatchPosting_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
			// this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
			//((System.ComponentModel.ISupportInitialize) this.cntMainParameter).EndInit();
			this.cntMainParameter.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		// 
		#endregion
	}
}//ENDSHERE
