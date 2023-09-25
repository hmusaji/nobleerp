
namespace Xtreme
{
	partial class frmSALContract
	{

		#region "Upgrade Support "
		private static frmSALContract m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmSALContract DefInstance
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
		public static frmSALContract CreateInstance()
		{
			frmSALContract theInstance = new frmSALContract();
			
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
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "HScroll1", "txtVoucherDate", "txtAmount", "Label_3", "Label_7", "txtDiscount", "Label1_4", "Label_2", "txtVoucherNo", "txtNetAmount", "Label1_0", "GroupBox1", "Column_0_grdVoucherDetails", "Column_1_grdVoucherDetails", "grdVoucherDetails", "txtTempDate", "txtComment", "Label1_1", "Frame1", "C1Tab1", "cmdGenerate", "txtRemainingAmount", "Label1_5", "txtInstallments", "Label1_2", "txtInstallmentStartDate", "Label_4", "txtInstallmentAmount", "Label1_6", "txtDownPayment", "Label1_3", "GroupBox2", "txtCustomerName", "txtPercentDiscount", "txtCustomerCode", "Label_1", "txtContractNo", "Label_0", "Frame2", "System.Windows.Forms.Label", "System.Windows.Forms.Label1"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public System.Windows.Forms.VScrollBar HScroll1;
		public Syncfusion.WinForms.Input.SfDateTimeEdit txtVoucherDate;
		public System.Windows.Forms.TextBox txtAmount;
		private System.Windows.Forms.Label Label_3;
		private System.Windows.Forms.Label Label_7;
		public System.Windows.Forms.TextBox txtDiscount;
		private System.Windows.Forms.Label Label1_4;
		private System.Windows.Forms.Label Label_2;
		public System.Windows.Forms.TextBox txtVoucherNo;
		public System.Windows.Forms.TextBox txtNetAmount;
		private System.Windows.Forms.Label Label1_0;
		public System.Windows.Forms.Panel GroupBox1;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_0_grdVoucherDetails;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_1_grdVoucherDetails;
		public C1.Win.C1TrueDBGrid.C1TrueDBGrid grdVoucherDetails;
		public Syncfusion.WinForms.Input.SfDateTimeEdit txtTempDate;
		public System.Windows.Forms.TextBox txtComment;
		private System.Windows.Forms.Label Label1_1;
		public System.Windows.Forms.Panel Frame1;
		public Syncfusion.Windows.Forms.Tools.TabControlAdv C1Tab1;
		public System.Windows.Forms.Button cmdGenerate;
		public System.Windows.Forms.TextBox txtRemainingAmount;
		private System.Windows.Forms.Label Label1_5;
		public System.Windows.Forms.TextBox txtInstallments;
		private System.Windows.Forms.Label Label1_2;
		public Syncfusion.WinForms.Input.SfDateTimeEdit txtInstallmentStartDate;
		private System.Windows.Forms.Label Label_4;
		public System.Windows.Forms.TextBox txtInstallmentAmount;
		private System.Windows.Forms.Label Label1_6;
		public System.Windows.Forms.TextBox txtDownPayment;
		private System.Windows.Forms.Label Label1_3;
		public System.Windows.Forms.Panel GroupBox2;
		public System.Windows.Forms.Label txtCustomerName;
		public System.Windows.Forms.TextBox txtPercentDiscount;
		public System.Windows.Forms.TextBox txtCustomerCode;
		private System.Windows.Forms.Label Label_1;
		public System.Windows.Forms.TextBox txtContractNo;
		private System.Windows.Forms.Label Label_0;
		public System.Windows.Forms.Panel Frame2;
		public System.Windows.Forms.Label[] Label = new System.Windows.Forms.Label[8];
		public System.Windows.Forms.Label[] Label1 = new System.Windows.Forms.Label[7];
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSALContract));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this.HScroll1 = new System.Windows.Forms.VScrollBar();
			this.Frame2 = new System.Windows.Forms.Panel();
			this.GroupBox1 = new System.Windows.Forms.Panel();
			this.txtVoucherDate = new Syncfusion.WinForms.Input.SfDateTimeEdit();
			this.txtAmount = new System.Windows.Forms.TextBox();
			this.Label_3 = new System.Windows.Forms.Label();
			this.Label_7 = new System.Windows.Forms.Label();
			this.txtDiscount = new System.Windows.Forms.TextBox();
			this.Label1_4 = new System.Windows.Forms.Label();
			this.Label_2 = new System.Windows.Forms.Label();
			this.txtVoucherNo = new System.Windows.Forms.TextBox();
			this.txtNetAmount = new System.Windows.Forms.TextBox();
			this.Label1_0 = new System.Windows.Forms.Label();
			this.C1Tab1 = new Syncfusion.Windows.Forms.Tools.TabControlAdv();
			this.Frame1 = new System.Windows.Forms.Panel();
			this.grdVoucherDetails = new C1.Win.C1TrueDBGrid.C1TrueDBGrid();
			this.Column_0_grdVoucherDetails = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.Column_1_grdVoucherDetails = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.txtTempDate = new Syncfusion.WinForms.Input.SfDateTimeEdit();
			this.txtComment = new System.Windows.Forms.TextBox();
			this.Label1_1 = new System.Windows.Forms.Label();
			this.GroupBox2 = new System.Windows.Forms.Panel();
			this.cmdGenerate = new System.Windows.Forms.Button();
			this.txtRemainingAmount = new System.Windows.Forms.TextBox();
			this.Label1_5 = new System.Windows.Forms.Label();
			this.txtInstallments = new System.Windows.Forms.TextBox();
			this.Label1_2 = new System.Windows.Forms.Label();
			this.txtInstallmentStartDate = new Syncfusion.WinForms.Input.SfDateTimeEdit();
			this.Label_4 = new System.Windows.Forms.Label();
			this.txtInstallmentAmount = new System.Windows.Forms.TextBox();
			this.Label1_6 = new System.Windows.Forms.Label();
			this.txtDownPayment = new System.Windows.Forms.TextBox();
			this.Label1_3 = new System.Windows.Forms.Label();
			this.txtCustomerName = new System.Windows.Forms.Label();
			this.txtPercentDiscount = new System.Windows.Forms.TextBox();
			this.txtCustomerCode = new System.Windows.Forms.TextBox();
			this.Label_1 = new System.Windows.Forms.Label();
			this.txtContractNo = new System.Windows.Forms.TextBox();
			this.Label_0 = new System.Windows.Forms.Label();
			// //((System.ComponentModel.ISupportInitialize) this.GroupBox1).BeginInit();
			// //((System.ComponentModel.ISupportInitialize) this.txtTempDate).BeginInit();
			// //((System.ComponentModel.ISupportInitialize) this.C1Tab1).BeginInit();
			// //((System.ComponentModel.ISupportInitialize) this.GroupBox2).BeginInit();
			//this.Frame2.SuspendLayout();
			//this.GroupBox1.SuspendLayout();
			//this.C1Tab1.SuspendLayout();
			//this.Frame1.SuspendLayout();
			//this.grdVoucherDetails.SuspendLayout();
			//this.GroupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// HScroll1
			// 
			this.HScroll1.AllowDrop = true;
			this.HScroll1.CausesValidation = true;
			this.HScroll1.Enabled = true;
			this.HScroll1.LargeChange = 1;
			this.HScroll1.Location = new System.Drawing.Point(608, 0);
			this.HScroll1.Maximum = 32767;
			this.HScroll1.Minimum = 0;
			this.HScroll1.Name = "HScroll1";
			this.HScroll1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.HScroll1.Size = new System.Drawing.Size(23, 99);
			this.HScroll1.SmallChange = 1;
			this.HScroll1.TabIndex = 10;
			this.HScroll1.TabStop = false;
			// this.HScroll1.Value = 0;
			this.HScroll1.Visible = true;
			this.HScroll1.ValueChanged += new System.EventHandler(this.HScroll1_ValueChanged);
			// 
			// Frame2
			// 
			this.Frame2.AllowDrop = true;
			this.Frame2.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.Frame2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Frame2.Controls.Add(this.GroupBox1);
			this.Frame2.Controls.Add(this.C1Tab1);
			this.Frame2.Controls.Add(this.GroupBox2);
			this.Frame2.Controls.Add(this.txtCustomerName);
			this.Frame2.Controls.Add(this.txtPercentDiscount);
			this.Frame2.Controls.Add(this.txtCustomerCode);
			this.Frame2.Controls.Add(this.Label_1);
			this.Frame2.Controls.Add(this.txtContractNo);
			this.Frame2.Controls.Add(this.Label_0);
			this.Frame2.Enabled = true;
			this.Frame2.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Frame2.Location = new System.Drawing.Point(0, 0);
			this.Frame2.Name = "Frame2";
			this.Frame2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Frame2.Size = new System.Drawing.Size(565, 511);
			this.Frame2.TabIndex = 20;
			this.Frame2.Visible = true;
			// 
			// GroupBox1
			// 
			this.GroupBox1.AllowDrop = true;
			this.GroupBox1.Controls.Add(this.txtVoucherDate);
			this.GroupBox1.Controls.Add(this.txtAmount);
			this.GroupBox1.Controls.Add(this.Label_3);
			this.GroupBox1.Controls.Add(this.Label_7);
			this.GroupBox1.Controls.Add(this.txtDiscount);
			this.GroupBox1.Controls.Add(this.Label1_4);
			this.GroupBox1.Controls.Add(this.Label_2);
			this.GroupBox1.Controls.Add(this.txtVoucherNo);
			this.GroupBox1.Controls.Add(this.txtNetAmount);
			this.GroupBox1.Controls.Add(this.Label1_0);
			this.GroupBox1.Location = new System.Drawing.Point(8, 30);
			this.GroupBox1.Name = "GroupBox1";
			//
			this.GroupBox1.Size = new System.Drawing.Size(227, 129);
			this.GroupBox1.TabIndex = 30;
			// 
			// txtVoucherDate
			// 
			this.txtVoucherDate.AllowDrop = true;
			this.txtVoucherDate.Location = new System.Drawing.Point(108, 16);
			// this.txtVoucherDate.MaxDate = 2958465;
			// this.txtVoucherDate.MinDate = -657434;
			this.txtVoucherDate.Name = "txtVoucherDate";
			// = "_";
			this.txtVoucherDate.Size = new System.Drawing.Size(87, 19);
			this.txtVoucherDate.TabIndex = 1;
			// this.txtVoucherDate.Text = "10/02/2014";
			// 
			// txtAmount
			// 
			this.txtAmount.AllowDrop = true;
			// this.txtAmount.DisplayFormat = "##,##,###.000";
			// this.txtAmount.Format = "##,##,###.000";
			this.txtAmount.Location = new System.Drawing.Point(108, 60);
			this.txtAmount.Name = "txtAmount";
			this.txtAmount.Size = new System.Drawing.Size(87, 19);
			this.txtAmount.TabIndex = 2;
			this.txtAmount.Text = ".000";
			// this.txtAmount.Leave += new System.EventHandler(this.txtAmount_Leave);
			// 
			// Label_3
			// 
			this.Label_3.AllowDrop = true;
			this.Label_3.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.Label_3.Text = "Amount";
			this.Label_3.ForeColor = System.Drawing.SystemColors.WindowText;
			this.Label_3.Location = new System.Drawing.Point(8, 62);
			this.Label_3.Name = "Label_3";
			this.Label_3.Size = new System.Drawing.Size(37, 14);
			this.Label_3.TabIndex = 31;
			// 
			// Label_7
			// 
			this.Label_7.AllowDrop = true;
			this.Label_7.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.Label_7.Text = "Sales Date";
			this.Label_7.ForeColor = System.Drawing.SystemColors.WindowText;
			this.Label_7.Location = new System.Drawing.Point(8, 19);
			this.Label_7.Name = "Label_7";
			this.Label_7.Size = new System.Drawing.Size(52, 14);
			this.Label_7.TabIndex = 32;
			// 
			// txtDiscount
			// 
			this.txtDiscount.AllowDrop = true;
			// this.txtDiscount.DisplayFormat = "##,##,###.000";
			// this.txtDiscount.Format = "##,##,###.000";
			this.txtDiscount.Location = new System.Drawing.Point(108, 82);
			this.txtDiscount.Name = "txtDiscount";
			this.txtDiscount.Size = new System.Drawing.Size(87, 19);
			this.txtDiscount.TabIndex = 3;
			this.txtDiscount.Text = ".000";
			// this.txtDiscount.Leave += new System.EventHandler(this.txtDiscount_Leave);
			// 
			// Label1_4
			// 
			this.Label1_4.AllowDrop = true;
			this.Label1_4.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.Label1_4.Text = "Discount";
			this.Label1_4.ForeColor = System.Drawing.SystemColors.WindowText;
			this.Label1_4.Location = new System.Drawing.Point(8, 86);
			this.Label1_4.Name = "Label1_4";
			this.Label1_4.Size = new System.Drawing.Size(42, 14);
			this.Label1_4.TabIndex = 33;
			// 
			// Label_2
			// 
			this.Label_2.AllowDrop = true;
			this.Label_2.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.Label_2.Text = "Voucher No";
			this.Label_2.ForeColor = System.Drawing.SystemColors.WindowText;
			this.Label_2.Location = new System.Drawing.Point(8, 42);
			this.Label_2.Name = "Label_2";
			this.Label_2.Size = new System.Drawing.Size(58, 14);
			this.Label_2.TabIndex = 34;
			// 
			// txtVoucherNo
			// 
			this.txtVoucherNo.AllowDrop = true;
			this.txtVoucherNo.BackColor = System.Drawing.Color.FromArgb(239, 239, 239);
			// // = false;
			this.txtVoucherNo.Enabled = false;
			this.txtVoucherNo.ForeColor = System.Drawing.Color.Black;
			this.txtVoucherNo.Location = new System.Drawing.Point(108, 38);
			// // = (System.Windows.Forms.TextBox.DropDownTypes) 0;
			this.txtVoucherNo.Name = "txtVoucherNo";
			this.txtVoucherNo.Size = new System.Drawing.Size(87, 19);
			this.txtVoucherNo.TabIndex = 8;
			this.txtVoucherNo.TabStop = false;
			this.txtVoucherNo.Text = "";
			// this.// = "";
			// 
			// txtNetAmount
			// 
			this.txtNetAmount.AllowDrop = true;
			this.txtNetAmount.BackColor = System.Drawing.Color.FromArgb(239, 239, 239);
			// this.txtNetAmount.DisplayFormat = "##,##,###.000";
			this.txtNetAmount.Enabled = false;
			// this.txtNetAmount.Format = "##,##,###.000";
			this.txtNetAmount.Location = new System.Drawing.Point(108, 104);
			this.txtNetAmount.Name = "txtNetAmount";
			this.txtNetAmount.Size = new System.Drawing.Size(87, 19);
			this.txtNetAmount.TabIndex = 14;
			this.txtNetAmount.TabStop = false;
			this.txtNetAmount.Text = ".000";
			// 
			// Label1_0
			// 
			this.Label1_0.AllowDrop = true;
			this.Label1_0.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.Label1_0.Text = "Net Amount";
			this.Label1_0.ForeColor = System.Drawing.SystemColors.WindowText;
			this.Label1_0.Location = new System.Drawing.Point(8, 108);
			this.Label1_0.Name = "Label1_0";
			this.Label1_0.Size = new System.Drawing.Size(56, 14);
			this.Label1_0.TabIndex = 35;
			// 
			// C1Tab1
			// 
			this.C1Tab1.Align = C1SizerLib.AlignSettings.asNone;
			this.C1Tab1.AllowDrop = true;
			this.C1Tab1.Controls.Add(this.Frame1);
			this.C1Tab1.Location = new System.Drawing.Point(8, 166);
			this.C1Tab1.Name = "C1Tab1";
			//
			this.C1Tab1.Size = new System.Drawing.Size(551, 339);
			this.C1Tab1.TabIndex = 16;
			this.C1Tab1.TabStop = false;
			// 
			// Frame1
			// 
			this.Frame1.AllowDrop = true;
			this.Frame1.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this.Frame1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Frame1.Controls.Add(this.grdVoucherDetails);
			this.Frame1.Controls.Add(this.txtTempDate);
			this.Frame1.Controls.Add(this.txtComment);
			this.Frame1.Controls.Add(this.Label1_1);
			this.Frame1.Enabled = true;
			this.Frame1.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Frame1.Location = new System.Drawing.Point(1, 23);
			this.Frame1.Name = "Frame1";
			this.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Frame1.Size = new System.Drawing.Size(549, 315);
			this.Frame1.TabIndex = 21;
			this.Frame1.Visible = true;
			// 
			// grdVoucherDetails
			// 
			this.grdVoucherDetails.AllowDrop = true;
			this.grdVoucherDetails.BackColor = System.Drawing.Color.Silver;
			this.grdVoucherDetails.CellTipsWidth = 0;
			this.grdVoucherDetails.Location = new System.Drawing.Point(6, 4);
			this.grdVoucherDetails.Name = "grdVoucherDetails";
			this.grdVoucherDetails.RowDivider.Color = System.Drawing.Color.Silver;
			this.grdVoucherDetails.Size = new System.Drawing.Size(539, 232);
			this.grdVoucherDetails.TabIndex = 17;
			this.grdVoucherDetails.Columns.Add(this.Column_0_grdVoucherDetails);
			this.grdVoucherDetails.Columns.Add(this.Column_1_grdVoucherDetails);
			this.grdVoucherDetails.AfterColUpdate += new C1.Win.C1TrueDBGrid.ColEventHandler(this.grdVoucherDetails_AfterColUpdate);
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
			// txtTempDate
			// 
			this.txtTempDate.AllowDrop = true;
			this.txtTempDate.Location = new System.Drawing.Point(14, 2);
			this.txtTempDate.Name = "txtTempDate";
			//
			this.txtTempDate.Size = new System.Drawing.Size(109, 19);
			this.txtTempDate.TabIndex = 18;
			this.txtTempDate.TabStop = false;
			this.txtTempDate.Visible = false;
			// 
			// txtComment
			// 
			this.txtComment.AllowDrop = true;
			this.txtComment.BackColor = System.Drawing.Color.White;
			// // = false;
			this.txtComment.ForeColor = System.Drawing.Color.Black;
			this.txtComment.Location = new System.Drawing.Point(4, 256);
			// // = (System.Windows.Forms.TextBox.FormatBoxDropDownTypes) 0;
			this.txtComment.Name = "txtComment";
			this.txtComment.Size = new System.Drawing.Size(537, 53);
			this.txtComment.TabIndex = 19;
			this.txtComment.Text = "";
			// 
			// Label1_1
			// 
			this.Label1_1.AllowDrop = true;
			this.Label1_1.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this.Label1_1.Text = "Comments";
			this.Label1_1.ForeColor = System.Drawing.SystemColors.WindowText;
			this.Label1_1.Location = new System.Drawing.Point(4, 238);
			this.Label1_1.Name = "Label1_1";
			this.Label1_1.Size = new System.Drawing.Size(3, 14);
			this.Label1_1.TabIndex = 22;
			// 
			// GroupBox2
			// 
			this.GroupBox2.AllowDrop = true;
			this.GroupBox2.Controls.Add(this.cmdGenerate);
			this.GroupBox2.Controls.Add(this.txtRemainingAmount);
			this.GroupBox2.Controls.Add(this.Label1_5);
			this.GroupBox2.Controls.Add(this.txtInstallments);
			this.GroupBox2.Controls.Add(this.Label1_2);
			this.GroupBox2.Controls.Add(this.txtInstallmentStartDate);
			this.GroupBox2.Controls.Add(this.Label_4);
			this.GroupBox2.Controls.Add(this.txtInstallmentAmount);
			this.GroupBox2.Controls.Add(this.Label1_6);
			this.GroupBox2.Controls.Add(this.txtDownPayment);
			this.GroupBox2.Controls.Add(this.Label1_3);
			this.GroupBox2.Location = new System.Drawing.Point(240, 30);
			this.GroupBox2.Name = "GroupBox2";
			//
			this.GroupBox2.Size = new System.Drawing.Size(319, 129);
			this.GroupBox2.TabIndex = 23;
			// 
			// cmdGenerate
			// 
			this.cmdGenerate.AllowDrop = true;
			this.cmdGenerate.BackColor = System.Drawing.SystemColors.Control;
			this.cmdGenerate.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdGenerate.Location = new System.Drawing.Point(200, 96);
			this.cmdGenerate.Name = "cmdGenerate";
			this.cmdGenerate.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdGenerate.Size = new System.Drawing.Size(114, 28);
			this.cmdGenerate.TabIndex = 15;
			// this.cmdGenerate.Text = "Generate Installment";
			// this.cmdGenerate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.cmdGenerate.UseVisualStyleBackColor = false;
			// this.cmdGenerate.Click += new System.EventHandler(this.cmdGenerate_Click);
			// 
			// txtRemainingAmount
			// 
			this.txtRemainingAmount.AllowDrop = true;
			this.txtRemainingAmount.BackColor = System.Drawing.Color.FromArgb(239, 239, 239);
			// this.txtRemainingAmount.DisplayFormat = "##,##,###.000";
			this.txtRemainingAmount.Enabled = false;
			// this.txtRemainingAmount.Format = "##,##,###.000";
			this.txtRemainingAmount.Location = new System.Drawing.Point(108, 38);
			this.txtRemainingAmount.Name = "txtRemainingAmount";
			this.txtRemainingAmount.Size = new System.Drawing.Size(87, 19);
			this.txtRemainingAmount.TabIndex = 12;
			this.txtRemainingAmount.TabStop = false;
			this.txtRemainingAmount.Text = ".000";
			// 
			// Label1_5
			// 
			this.Label1_5.AllowDrop = true;
			this.Label1_5.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.Label1_5.Text = "Remaining Amount";
			this.Label1_5.ForeColor = System.Drawing.SystemColors.WindowText;
			this.Label1_5.Location = new System.Drawing.Point(8, 42);
			this.Label1_5.Name = "Label1_5";
			this.Label1_5.Size = new System.Drawing.Size(89, 14);
			this.Label1_5.TabIndex = 24;
			// 
			// txtInstallments
			// 
			this.txtInstallments.AllowDrop = true;
			// this.txtInstallments.DisplayFormat = "##";
			// this.txtInstallments.Format = "##";
			this.txtInstallments.Location = new System.Drawing.Point(108, 82);
			this.txtInstallments.Name = "txtInstallments";
			this.txtInstallments.Size = new System.Drawing.Size(87, 19);
			this.txtInstallments.TabIndex = 6;
			this.txtInstallments.Text = "";
			// 
			// Label1_2
			// 
			this.Label1_2.AllowDrop = true;
			this.Label1_2.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.Label1_2.Text = "Total Installments";
			this.Label1_2.ForeColor = System.Drawing.SystemColors.WindowText;
			this.Label1_2.Location = new System.Drawing.Point(8, 86);
			this.Label1_2.Name = "Label1_2";
			this.Label1_2.Size = new System.Drawing.Size(82, 14);
			this.Label1_2.TabIndex = 25;
			// 
			// txtInstallmentStartDate
			// 
			this.txtInstallmentStartDate.AllowDrop = true;
			this.txtInstallmentStartDate.Location = new System.Drawing.Point(108, 60);
			// this.txtInstallmentStartDate.MaxDate = 2958465;
			// this.txtInstallmentStartDate.MinDate = -657434;
			this.txtInstallmentStartDate.Name = "txtInstallmentStartDate";
			// = "_";
			this.txtInstallmentStartDate.Size = new System.Drawing.Size(87, 19);
			this.txtInstallmentStartDate.TabIndex = 5;
			// this.txtInstallmentStartDate.Text = "10/02/2014";
			// 
			// Label_4
			// 
			this.Label_4.AllowDrop = true;
			this.Label_4.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.Label_4.Text = "Installments From";
			this.Label_4.ForeColor = System.Drawing.SystemColors.WindowText;
			this.Label_4.Location = new System.Drawing.Point(8, 62);
			this.Label_4.Name = "Label_4";
			this.Label_4.Size = new System.Drawing.Size(83, 14);
			this.Label_4.TabIndex = 26;
			// 
			// txtInstallmentAmount
			// 
			this.txtInstallmentAmount.AllowDrop = true;
			// this.txtInstallmentAmount.DisplayFormat = "##,##,###.000";
			// this.txtInstallmentAmount.Format = "##,##,###.000";
			this.txtInstallmentAmount.Location = new System.Drawing.Point(108, 104);
			this.txtInstallmentAmount.Name = "txtInstallmentAmount";
			this.txtInstallmentAmount.Size = new System.Drawing.Size(87, 19);
			this.txtInstallmentAmount.TabIndex = 7;
			this.txtInstallmentAmount.Text = ".000";
			// 
			// Label1_6
			// 
			this.Label1_6.AllowDrop = true;
			this.Label1_6.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.Label1_6.Text = "Installment Amount";
			this.Label1_6.ForeColor = System.Drawing.SystemColors.WindowText;
			this.Label1_6.Location = new System.Drawing.Point(8, 108);
			this.Label1_6.Name = "Label1_6";
			this.Label1_6.Size = new System.Drawing.Size(90, 14);
			this.Label1_6.TabIndex = 29;
			// 
			// txtDownPayment
			// 
			this.txtDownPayment.AllowDrop = true;
			// this.txtDownPayment.DisplayFormat = "##,##,###.000";
			// this.txtDownPayment.Format = "##,##,###.000";
			this.txtDownPayment.Location = new System.Drawing.Point(108, 16);
			this.txtDownPayment.Name = "txtDownPayment";
			this.txtDownPayment.Size = new System.Drawing.Size(87, 19);
			this.txtDownPayment.TabIndex = 4;
			this.txtDownPayment.Text = ".000";
			// this.txtDownPayment.Leave += new System.EventHandler(this.txtDownPayment_Leave);
			// 
			// Label1_3
			// 
			this.Label1_3.AllowDrop = true;
			this.Label1_3.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.Label1_3.Text = "Down Payment";
			this.Label1_3.ForeColor = System.Drawing.SystemColors.WindowText;
			this.Label1_3.Location = new System.Drawing.Point(8, 20);
			this.Label1_3.Name = "Label1_3";
			this.Label1_3.Size = new System.Drawing.Size(73, 14);
			this.Label1_3.TabIndex = 36;
			// 
			// txtCustomerName
			// 
			this.txtCustomerName.AllowDrop = true;
			this.txtCustomerName.Enabled = false;
			this.txtCustomerName.Location = new System.Drawing.Point(206, 8);
			this.txtCustomerName.Name = "txtCustomerName";
			this.txtCustomerName.Size = new System.Drawing.Size(329, 19);
			this.txtCustomerName.TabIndex = 11;
			this.txtCustomerName.TabStop = false;
			// 
			// txtPercentDiscount
			// 
			this.txtPercentDiscount.AllowDrop = true;
			// this.txtPercentDiscount.DisplayFormat = "#####0.######;;; ";
			// this.txtPercentDiscount.Format = "#####0.######";
			this.txtPercentDiscount.Location = new System.Drawing.Point(196, 112);
			// // = 100;
			// // = 0;
			this.txtPercentDiscount.Name = "txtPercentDiscount";
			this.txtPercentDiscount.Size = new System.Drawing.Size(37, 19);
			this.txtPercentDiscount.TabIndex = 13;
			this.txtPercentDiscount.TabStop = false;
			this.txtPercentDiscount.Visible = false;
			// 
			// txtCustomerCode
			// 
			this.txtCustomerCode.AllowDrop = true;
			this.txtCustomerCode.BackColor = System.Drawing.Color.White;
			// // = false;
			this.txtCustomerCode.ForeColor = System.Drawing.Color.Black;
			this.txtCustomerCode.Location = new System.Drawing.Point(116, 8);
			// // = (System.Windows.Forms.TextBox.DropDownTypes) 0;
			this.txtCustomerCode.Name = "txtCustomerCode";
			// this.txtCustomerCode.ShowButton = true;
			this.txtCustomerCode.Size = new System.Drawing.Size(87, 19);
			this.txtCustomerCode.TabIndex = 0;
			this.txtCustomerCode.Text = "";
			// this.// = "";
			// this.//this.txtCustomerCode.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(//this.txtCustomerCode_DropButtonClick);
			// this.txtCustomerCode.Leave += new System.EventHandler(this.txtCustomerCode_Leave);
			// 
			// Label_1
			// 
			this.Label_1.AllowDrop = true;
			this.Label_1.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.Label_1.Text = "Contract No";
			this.Label_1.ForeColor = System.Drawing.SystemColors.WindowText;
			this.Label_1.Location = new System.Drawing.Point(250, 32);
			this.Label_1.Name = "Label_1";
			this.Label_1.Size = new System.Drawing.Size(57, 14);
			this.Label_1.TabIndex = 27;
			this.Label_1.Visible = false;
			// 
			// txtContractNo
			// 
			this.txtContractNo.AllowDrop = true;
			this.txtContractNo.BackColor = System.Drawing.Color.White;
			// // = false;
			this.txtContractNo.ForeColor = System.Drawing.Color.Black;
			this.txtContractNo.Location = new System.Drawing.Point(350, 28);
			// // = (System.Windows.Forms.TextBox.DropDownTypes) 0;
			this.txtContractNo.Name = "txtContractNo";
			this.txtContractNo.Size = new System.Drawing.Size(87, 19);
			this.txtContractNo.TabIndex = 9;
			this.txtContractNo.TabStop = false;
			this.txtContractNo.Text = "";
			this.txtContractNo.Visible = false;
			// this.// = "";
			// 
			// Label_0
			// 
			this.Label_0.AllowDrop = true;
			this.Label_0.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.Label_0.Text = "Customer Name";
			this.Label_0.ForeColor = System.Drawing.SystemColors.WindowText;
			this.Label_0.Location = new System.Drawing.Point(16, 10);
			this.Label_0.Name = "Label_0";
			this.Label_0.Size = new System.Drawing.Size(3, 14);
			this.Label_0.TabIndex = 28;
			// 
			// frmSALContract
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.ClientSize = new System.Drawing.Size(638, 544);
			this.Controls.Add(this.HScroll1);
			this.Controls.Add(this.Frame2);
			this.Font = new System.Drawing.Font("Tahoma", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 178);
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(218, 165);
			this.MaximizeBox = true;
			this.MinimizeBox = true;
			this.Name = "frmSALContract";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Sales Contract";
			// this.Activated += new System.EventHandler(this.frmSALContract_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
			// this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
			this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Form_KeyPress);
			//this.Resize += new System.EventHandler(this.Form_Resize);
			//((System.ComponentModel.ISupportInitialize) this.GroupBox1).EndInit();
			//((System.ComponentModel.ISupportInitialize) this.txtTempDate).EndInit();
			//((System.ComponentModel.ISupportInitialize) this.C1Tab1).EndInit();
			//((System.ComponentModel.ISupportInitialize) this.GroupBox2).EndInit();
			this.Frame2.ResumeLayout(false);
			this.GroupBox1.ResumeLayout(false);
			this.C1Tab1.ResumeLayout(false);
			this.Frame1.ResumeLayout(false);
			this.grdVoucherDetails.ResumeLayout(false);
			this.GroupBox2.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		// 
		void InitializeSystemWindowsFormsLabel1()
		{
			this.Label1 = new System.Windows.Forms.Label[7];
			this.Label1[4] = Label1_4;
			this.Label1[0] = Label1_0;
			this.Label1[1] = Label1_1;
			this.Label1[5] = Label1_5;
			this.Label1[2] = Label1_2;
			this.Label1[6] = Label1_6;
			this.Label1[3] = Label1_3;
		}
		void InitializeSystemWindowsFormsLabel()
		{
			this.Label = new System.Windows.Forms.Label[8];
			this.Label[3] = Label_3;
			this.Label[7] = Label_7;
			this.Label[2] = Label_2;
			this.Label[4] = Label_4;
			this.Label[1] = Label_1;
			this.Label[0] = Label_0;
		}
		#endregion
	}
}//ENDSHERE
