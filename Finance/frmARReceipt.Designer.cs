
namespace Xtreme
{
	partial class frmARReceipt
	{

		#region "Upgrade Support "
		private static frmARReceipt m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmARReceipt DefInstance
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
		public static frmARReceipt CreateInstance()
		{
			frmARReceipt theInstance = new frmARReceipt();
			
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
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "cmdAutoAdjust", "txtBalAmt", "txtComments", "txtVoucherDate", "txtReceiptAmt", "txtCustomerName", "Label_0", "Label_1", "Label_3", "Label_4", "txtCashBankCD", "Label_7", "Label1_1", "txtCashBankLedName", "txtDiscountAmt", "Label1_4", "Label1_5", "txtDiscountCD", "txtDiscountLedName", "txtPercentDiscount", "Label_2", "txtVoucherNo", "txtCustomerCode", "Column_0_grdVoucherDetails", "Column_1_grdVoucherDetails", "grdVoucherDetails", "System.Windows.Forms.Label", "System.Windows.Forms.Label1"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public System.Windows.Forms.Button cmdAutoAdjust;
		public System.Windows.Forms.Label txtBalAmt;
		public System.Windows.Forms.TextBox txtComments;
		public Syncfusion.WinForms.Input.SfDateTimeEdit txtVoucherDate;
		public System.Windows.Forms.TextBox txtReceiptAmt;
		public System.Windows.Forms.Label txtCustomerName;
		private System.Windows.Forms.Label Label_0;
		private System.Windows.Forms.Label Label_1;
		private System.Windows.Forms.Label Label_3;
		private System.Windows.Forms.Label Label_4;
		public System.Windows.Forms.TextBox txtCashBankCD;
		private System.Windows.Forms.Label Label_7;
		private System.Windows.Forms.Label Label1_1;
		public System.Windows.Forms.Label txtCashBankLedName;
		public System.Windows.Forms.TextBox txtDiscountAmt;
		private System.Windows.Forms.Label Label1_4;
		private System.Windows.Forms.Label Label1_5;
		public System.Windows.Forms.TextBox txtDiscountCD;
		public System.Windows.Forms.Label txtDiscountLedName;
		public System.Windows.Forms.TextBox txtPercentDiscount;
		private System.Windows.Forms.Label Label_2;
		public System.Windows.Forms.TextBox txtVoucherNo;
		public System.Windows.Forms.TextBox txtCustomerCode;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_0_grdVoucherDetails;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_1_grdVoucherDetails;
		public C1.Win.C1TrueDBGrid.C1TrueDBGrid grdVoucherDetails;
		public System.Windows.Forms.Label[] Label = new System.Windows.Forms.Label[8];
		public System.Windows.Forms.Label[] Label1 = new System.Windows.Forms.Label[6];
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmARReceipt));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this.cmdAutoAdjust = new System.Windows.Forms.Button();
			this.txtBalAmt = new System.Windows.Forms.Label();
			this.txtComments = new System.Windows.Forms.TextBox();
			this.txtVoucherDate = new Syncfusion.WinForms.Input.SfDateTimeEdit();
			this.txtReceiptAmt = new System.Windows.Forms.TextBox();
			this.txtCustomerName = new System.Windows.Forms.Label();
			this.Label_0 = new System.Windows.Forms.Label();
			this.Label_1 = new System.Windows.Forms.Label();
			this.Label_3 = new System.Windows.Forms.Label();
			this.Label_4 = new System.Windows.Forms.Label();
			this.txtCashBankCD = new System.Windows.Forms.TextBox();
			this.Label_7 = new System.Windows.Forms.Label();
			this.Label1_1 = new System.Windows.Forms.Label();
			this.txtCashBankLedName = new System.Windows.Forms.Label();
			this.txtDiscountAmt = new System.Windows.Forms.TextBox();
			this.Label1_4 = new System.Windows.Forms.Label();
			this.Label1_5 = new System.Windows.Forms.Label();
			this.txtDiscountCD = new System.Windows.Forms.TextBox();
			this.txtDiscountLedName = new System.Windows.Forms.Label();
			this.txtPercentDiscount = new System.Windows.Forms.TextBox();
			this.Label_2 = new System.Windows.Forms.Label();
			this.txtVoucherNo = new System.Windows.Forms.TextBox();
			this.txtCustomerCode = new System.Windows.Forms.TextBox();
			this.grdVoucherDetails = new C1.Win.C1TrueDBGrid.C1TrueDBGrid();
			this.Column_0_grdVoucherDetails = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.Column_1_grdVoucherDetails = new C1.Win.C1TrueDBGrid.C1DataColumn();
			//this.grdVoucherDetails.SuspendLayout();
			this.SuspendLayout();
			// 
			// cmdAutoAdjust
			// 
			this.cmdAutoAdjust.AllowDrop = true;
			this.cmdAutoAdjust.BackColor = System.Drawing.SystemColors.Control;
			this.cmdAutoAdjust.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdAutoAdjust.Location = new System.Drawing.Point(516, 138);
			this.cmdAutoAdjust.Name = "cmdAutoAdjust";
			this.cmdAutoAdjust.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdAutoAdjust.Size = new System.Drawing.Size(81, 25);
			this.cmdAutoAdjust.TabIndex = 9;
			this.cmdAutoAdjust.Text = "Auto Adjust";
			this.cmdAutoAdjust.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.cmdAutoAdjust.UseVisualStyleBackColor = false;
			// this.cmdAutoAdjust.Click += new System.EventHandler(this.cmdAutoAdjust_Click);
			// 
			// txtBalAmt
			// 
			// this.txtBalAmt.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtBalAmt.AllowDrop = true;
			this.txtBalAmt.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.txtBalAmt.Enabled = false;
			this.txtBalAmt.Location = new System.Drawing.Point(364, 36);
			this.txtBalAmt.Name = "txtBalAmt";
			this.txtBalAmt.Size = new System.Drawing.Size(131, 19);
			this.txtBalAmt.TabIndex = 0;
			// 
			// txtComments
			// 
			this.txtComments.AllowDrop = true;
			this.txtComments.BackColor = System.Drawing.Color.White;
			// // = false;
			this.txtComments.ForeColor = System.Drawing.Color.Black;
			this.txtComments.Location = new System.Drawing.Point(94, 136);
			// // = (System.Windows.Forms.TextBox.DropDownTypes) 0;
			this.txtComments.Name = "txtComments";
			this.txtComments.Size = new System.Drawing.Size(401, 19);
			this.txtComments.TabIndex = 8;
			this.txtComments.Text = "";
			// this.// = "";
			// 
			// txtVoucherDate
			// 
			this.txtVoucherDate.AllowDrop = true;
			this.txtVoucherDate.Location = new System.Drawing.Point(94, 34);
			// this.txtVoucherDate.MaxDate = 2958465;
			// this.txtVoucherDate.MinDate = -657434;
			this.txtVoucherDate.Name = "txtVoucherDate";
			// = "_";
			this.txtVoucherDate.Size = new System.Drawing.Size(75, 19);
			this.txtVoucherDate.TabIndex = 2;
			// this.txtVoucherDate.Text = "29-Jul-2019";
			// 
			// txtReceiptAmt
			// 
			this.txtReceiptAmt.AllowDrop = true;
			// this.txtReceiptAmt.DisplayFormat = "##,##,###.000";
			// this.txtReceiptAmt.Format = "##,##,###.000";
			this.txtReceiptAmt.Location = new System.Drawing.Point(410, 80);
			this.txtReceiptAmt.Name = "txtReceiptAmt";
			this.txtReceiptAmt.Size = new System.Drawing.Size(87, 19);
			this.txtReceiptAmt.TabIndex = 5;
			this.txtReceiptAmt.Text = ".000";
			// 
			// txtCustomerName
			// 
			this.txtCustomerName.AllowDrop = true;
			this.txtCustomerName.Enabled = false;
			this.txtCustomerName.Location = new System.Drawing.Point(170, 12);
			this.txtCustomerName.Name = "txtCustomerName";
			this.txtCustomerName.Size = new System.Drawing.Size(327, 19);
			this.txtCustomerName.TabIndex = 11;
			this.txtCustomerName.TabStop = false;
			// 
			// Label_0
			// 
			this.Label_0.AllowDrop = true;
			this.Label_0.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.Label_0.Text = "Customer Name";
			this.Label_0.ForeColor = System.Drawing.SystemColors.WindowText;
			this.Label_0.Location = new System.Drawing.Point(8, 16);
			this.Label_0.Name = "Label_0";
			this.Label_0.Size = new System.Drawing.Size(3, 14);
			this.Label_0.TabIndex = 12;
			// 
			// Label_1
			// 
			this.Label_1.AllowDrop = true;
			this.Label_1.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.Label_1.Text = "Customer Bal";
			this.Label_1.ForeColor = System.Drawing.SystemColors.WindowText;
			this.Label_1.Location = new System.Drawing.Point(290, 38);
			this.Label_1.Name = "Label_1";
			this.Label_1.Size = new System.Drawing.Size(64, 14);
			this.Label_1.TabIndex = 13;
			// 
			// Label_3
			// 
			this.Label_3.AllowDrop = true;
			this.Label_3.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.Label_3.Text = "Receipt Amt.";
			this.Label_3.ForeColor = System.Drawing.SystemColors.WindowText;
			this.Label_3.Location = new System.Drawing.Point(328, 80);
			this.Label_3.Name = "Label_3";
			this.Label_3.Size = new System.Drawing.Size(73, 14);
			this.Label_3.TabIndex = 14;
			// 
			// Label_4
			// 
			this.Label_4.AllowDrop = true;
			this.Label_4.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.Label_4.Text = "Cash/Bank Code";
			this.Label_4.ForeColor = System.Drawing.SystemColors.WindowText;
			this.Label_4.Location = new System.Drawing.Point(8, 82);
			this.Label_4.Name = "Label_4";
			this.Label_4.Size = new System.Drawing.Size(3, 14);
			this.Label_4.TabIndex = 15;
			// 
			// txtCashBankCD
			// 
			this.txtCashBankCD.AllowDrop = true;
			this.txtCashBankCD.BackColor = System.Drawing.Color.White;
			// // = false;
			this.txtCashBankCD.ForeColor = System.Drawing.Color.Black;
			this.txtCashBankCD.Location = new System.Drawing.Point(94, 78);
			// // = (System.Windows.Forms.TextBox.DropDownTypes) 0;
			this.txtCashBankCD.Name = "txtCashBankCD";
			// this.txtCashBankCD.ShowButton = true;
			this.txtCashBankCD.Size = new System.Drawing.Size(75, 19);
			this.txtCashBankCD.TabIndex = 4;
			this.txtCashBankCD.Text = "";
			// this.// = "";
			// this.//this.txtCashBankCD.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(//this.txtCashBankCD_DropButtonClick);
			// this.this.txtCashBankCD.KeyDown += new System.Windows.Forms.TextBox.KeyDownHandler(this.txtCashBankCD_KeyDown);
			// this.txtCashBankCD.Leave += new System.EventHandler(this.txtCashBankCD_Leave);
			// 
			// Label_7
			// 
			this.Label_7.AllowDrop = true;
			this.Label_7.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.Label_7.Text = "Voucher Date";
			this.Label_7.ForeColor = System.Drawing.SystemColors.WindowText;
			this.Label_7.Location = new System.Drawing.Point(8, 37);
			this.Label_7.Name = "Label_7";
			this.Label_7.Size = new System.Drawing.Size(71, 14);
			this.Label_7.TabIndex = 16;
			// 
			// Label1_1
			// 
			this.Label1_1.AllowDrop = true;
			this.Label1_1.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.Label1_1.Text = "Comments";
			this.Label1_1.ForeColor = System.Drawing.SystemColors.WindowText;
			this.Label1_1.Location = new System.Drawing.Point(8, 142);
			this.Label1_1.Name = "Label1_1";
			this.Label1_1.Size = new System.Drawing.Size(3, 14);
			this.Label1_1.TabIndex = 17;
			// 
			// txtCashBankLedName
			// 
			this.txtCashBankLedName.AllowDrop = true;
			this.txtCashBankLedName.Enabled = false;
			this.txtCashBankLedName.Location = new System.Drawing.Point(170, 78);
			this.txtCashBankLedName.Name = "txtCashBankLedName";
			this.txtCashBankLedName.Size = new System.Drawing.Size(153, 19);
			this.txtCashBankLedName.TabIndex = 18;
			this.txtCashBankLedName.TabStop = false;
			// 
			// txtDiscountAmt
			// 
			this.txtDiscountAmt.AllowDrop = true;
			// this.txtDiscountAmt.DisplayFormat = "##,##,###.000";
			// this.txtDiscountAmt.Format = "##,##,###.000";
			this.txtDiscountAmt.Location = new System.Drawing.Point(410, 102);
			this.txtDiscountAmt.Name = "txtDiscountAmt";
			this.txtDiscountAmt.Size = new System.Drawing.Size(87, 19);
			this.txtDiscountAmt.TabIndex = 7;
			this.txtDiscountAmt.Text = ".000";
			// 
			// Label1_4
			// 
			this.Label1_4.AllowDrop = true;
			this.Label1_4.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.Label1_4.Text = "Discount Amt.";
			this.Label1_4.ForeColor = System.Drawing.SystemColors.WindowText;
			this.Label1_4.Location = new System.Drawing.Point(328, 104);
			this.Label1_4.Name = "Label1_4";
			this.Label1_4.Size = new System.Drawing.Size(67, 14);
			this.Label1_4.TabIndex = 19;
			// 
			// Label1_5
			// 
			this.Label1_5.AllowDrop = true;
			this.Label1_5.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.Label1_5.Text = "Discount Code";
			this.Label1_5.ForeColor = System.Drawing.SystemColors.WindowText;
			this.Label1_5.Location = new System.Drawing.Point(8, 102);
			this.Label1_5.Name = "Label1_5";
			this.Label1_5.Size = new System.Drawing.Size(70, 14);
			this.Label1_5.TabIndex = 20;
			// 
			// txtDiscountCD
			// 
			this.txtDiscountCD.AllowDrop = true;
			this.txtDiscountCD.BackColor = System.Drawing.Color.White;
			// // = false;
			this.txtDiscountCD.ForeColor = System.Drawing.Color.Black;
			this.txtDiscountCD.Location = new System.Drawing.Point(94, 100);
			// // = (System.Windows.Forms.TextBox.DropDownTypes) 0;
			this.txtDiscountCD.Name = "txtDiscountCD";
			// this.txtDiscountCD.ShowButton = true;
			this.txtDiscountCD.Size = new System.Drawing.Size(75, 19);
			this.txtDiscountCD.TabIndex = 6;
			this.txtDiscountCD.Text = "";
			// this.// = "";
			// this.//this.txtDiscountCD.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(//this.txtDiscountCD_DropButtonClick);
			// this.this.txtDiscountCD.KeyDown += new System.Windows.Forms.TextBox.KeyDownHandler(this.txtDiscountCD_KeyDown);
			// this.txtDiscountCD.Leave += new System.EventHandler(this.txtDiscountCD_Leave);
			// 
			// txtDiscountLedName
			// 
			this.txtDiscountLedName.AllowDrop = true;
			this.txtDiscountLedName.Enabled = false;
			this.txtDiscountLedName.Location = new System.Drawing.Point(170, 100);
			this.txtDiscountLedName.Name = "txtDiscountLedName";
			this.txtDiscountLedName.Size = new System.Drawing.Size(153, 19);
			this.txtDiscountLedName.TabIndex = 21;
			this.txtDiscountLedName.TabStop = false;
			// 
			// txtPercentDiscount
			// 
			this.txtPercentDiscount.AllowDrop = true;
			// this.txtPercentDiscount.DisplayFormat = "#####0.######;;; ";
			// this.txtPercentDiscount.Format = "#####0.######";
			this.txtPercentDiscount.Location = new System.Drawing.Point(426, 118);
			// // = 100;
			// // = 0;
			this.txtPercentDiscount.Name = "txtPercentDiscount";
			this.txtPercentDiscount.Size = new System.Drawing.Size(37, 19);
			this.txtPercentDiscount.TabIndex = 22;
			this.txtPercentDiscount.Visible = false;
			// 
			// Label_2
			// 
			this.Label_2.AllowDrop = true;
			this.Label_2.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.Label_2.Text = "Voucher No";
			this.Label_2.ForeColor = System.Drawing.SystemColors.WindowText;
			this.Label_2.Location = new System.Drawing.Point(8, 60);
			this.Label_2.Name = "Label_2";
			this.Label_2.Size = new System.Drawing.Size(58, 14);
			this.Label_2.TabIndex = 23;
			// 
			// txtVoucherNo
			// 
			this.txtVoucherNo.AllowDrop = true;
			this.txtVoucherNo.BackColor = System.Drawing.Color.White;
			// // = false;
			this.txtVoucherNo.ForeColor = System.Drawing.Color.Black;
			this.txtVoucherNo.Location = new System.Drawing.Point(94, 56);
			// // = (System.Windows.Forms.TextBox.DropDownTypes) 0;
			this.txtVoucherNo.Name = "txtVoucherNo";
			this.txtVoucherNo.Size = new System.Drawing.Size(75, 19);
			this.txtVoucherNo.TabIndex = 3;
			this.txtVoucherNo.Text = "";
			// this.// = "";
			// 
			// txtCustomerCode
			// 
			this.txtCustomerCode.AllowDrop = true;
			this.txtCustomerCode.BackColor = System.Drawing.Color.White;
			// // = false;
			this.txtCustomerCode.ForeColor = System.Drawing.Color.Black;
			this.txtCustomerCode.Location = new System.Drawing.Point(94, 12);
			// // = (System.Windows.Forms.TextBox.DropDownTypes) 0;
			this.txtCustomerCode.Name = "txtCustomerCode";
			// this.txtCustomerCode.ShowButton = true;
			this.txtCustomerCode.Size = new System.Drawing.Size(75, 19);
			this.txtCustomerCode.TabIndex = 1;
			this.txtCustomerCode.Text = "";
			// this.// = "";
			// this.//this.txtCustomerCode.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(//this.txtCustomerCode_DropButtonClick);
			// this.txtCustomerCode.Leave += new System.EventHandler(this.txtCustomerCode_Leave);
			// 
			// grdVoucherDetails
			// 
			this.grdVoucherDetails.AllowDrop = true;
			this.grdVoucherDetails.BackColor = System.Drawing.Color.Silver;
			this.grdVoucherDetails.CellTipsWidth = 0;
			this.grdVoucherDetails.Location = new System.Drawing.Point(0, 172);
			this.grdVoucherDetails.Name = "grdVoucherDetails";
			this.grdVoucherDetails.RowDivider.Color = System.Drawing.Color.Silver;
			this.grdVoucherDetails.Size = new System.Drawing.Size(773, 232);
			this.grdVoucherDetails.TabIndex = 10;
			this.grdVoucherDetails.Columns.Add(this.Column_0_grdVoucherDetails);
			this.grdVoucherDetails.Columns.Add(this.Column_1_grdVoucherDetails);
			this.grdVoucherDetails.AfterColUpdate += new C1.Win.C1TrueDBGrid.ColEventHandler(this.grdVoucherDetails_AfterColUpdate);
			this.grdVoucherDetails.BeforeColUpdate += new C1.Win.C1TrueDBGrid.BeforeColUpdateEventHandler(this.grdVoucherDetails_BeforeColUpdate);
			// this.grdVoucherDetails.Leave += new System.EventHandler(this.grdVoucherDetails_Leave);
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
			// frmARReceipt
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.ClientSize = new System.Drawing.Size(796, 413);
			this.Controls.Add(this.cmdAutoAdjust);
			this.Controls.Add(this.txtBalAmt);
			this.Controls.Add(this.txtComments);
			this.Controls.Add(this.txtVoucherDate);
			this.Controls.Add(this.txtReceiptAmt);
			this.Controls.Add(this.txtCustomerName);
			this.Controls.Add(this.Label_0);
			this.Controls.Add(this.Label_1);
			this.Controls.Add(this.Label_3);
			this.Controls.Add(this.Label_4);
			this.Controls.Add(this.txtCashBankCD);
			this.Controls.Add(this.Label_7);
			this.Controls.Add(this.Label1_1);
			this.Controls.Add(this.txtCashBankLedName);
			this.Controls.Add(this.txtDiscountAmt);
			this.Controls.Add(this.Label1_4);
			this.Controls.Add(this.Label1_5);
			this.Controls.Add(this.txtDiscountCD);
			this.Controls.Add(this.txtDiscountLedName);
			this.Controls.Add(this.txtPercentDiscount);
			this.Controls.Add(this.Label_2);
			this.Controls.Add(this.txtVoucherNo);
			this.Controls.Add(this.txtCustomerCode);
			this.Controls.Add(this.grdVoucherDetails);
			//this.Icon = (System.Drawing.Icon) resources.GetObject("frmARReceipt.Icon");
			this.Location = new System.Drawing.Point(254, 197);
			this.MaximizeBox = true;
			this.MinimizeBox = true;
			this.Name = "frmARReceipt";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Quick Receipt";
			// this.Activated += new System.EventHandler(this.frmARReceipt_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
			// this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
			this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Form_KeyPress);
			//this.Resize += new System.EventHandler(this.Form_Resize);
			this.grdVoucherDetails.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		// 
		void InitializeSystemWindowsFormsLabel1()
		{
			this.Label1 = new System.Windows.Forms.Label[6];
			this.Label1[1] = Label1_1;
			this.Label1[4] = Label1_4;
			this.Label1[5] = Label1_5;
		}
		void InitializeSystemWindowsFormsLabel()
		{
			this.Label = new System.Windows.Forms.Label[8];
			this.Label[0] = Label_0;
			this.Label[1] = Label_1;
			this.Label[3] = Label_3;
			this.Label[4] = Label_4;
			this.Label[7] = Label_7;
			this.Label[2] = Label_2;
		}
		#endregion
	}
}//ENDSHERE
