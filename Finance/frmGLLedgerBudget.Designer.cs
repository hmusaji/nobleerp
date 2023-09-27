
namespace Xtreme
{
	partial class frmGLLedgerBudget
	{

		#region "Upgrade Support "
		private static frmGLLedgerBudget m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmGLLedgerBudget DefInstance
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
		public static frmGLLedgerBudget CreateInstance()
		{
			frmGLLedgerBudget theInstance = new frmGLLedgerBudget();
			
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
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "cbToMonth", "cbFromMonth", "cbToYear", "cbFromYear", "Label4", "Label3", "Label2", "Label1", "Frame1", "lblFromToDate", "cmdAllocate", "Column_0_grdVoucherDetails", "Column_1_grdVoucherDetails", "grdVoucherDetails", "txtAnnualBudget", "BudgetLine", "lblLedgerNo", "txtLdgrNo", "txtLdgrName", "lblAnnualBudget", "tcbSystemForm"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public System.Windows.Forms.ComboBox cbToMonth;
		public System.Windows.Forms.ComboBox cbFromMonth;
		public System.Windows.Forms.ComboBox cbToYear;
		public System.Windows.Forms.ComboBox cbFromYear;
		public System.Windows.Forms.Label Label4;
		public System.Windows.Forms.Label Label3;
		public System.Windows.Forms.Label Label2;
		public System.Windows.Forms.Label Label1;
		public System.Windows.Forms.GroupBox Frame1;
		public System.Windows.Forms.Label lblFromToDate;
		public System.Windows.Forms.Button cmdAllocate;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_0_grdVoucherDetails;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_1_grdVoucherDetails;
		public C1.Win.C1TrueDBGrid.C1TrueDBGrid grdVoucherDetails;
		public System.Windows.Forms.TextBox txtAnnualBudget;
		public System.Windows.Forms.GroupBox BudgetLine;
		public System.Windows.Forms.Label lblLedgerNo;
		public System.Windows.Forms.TextBox txtLdgrNo;
		public System.Windows.Forms.TextBox txtLdgrName;
		public System.Windows.Forms.Label lblAnnualBudget;
		public Syncfusion.Windows.Forms.Tools.CommandBarController tcbSystemForm;
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGLLedgerBudget));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this.Frame1 = new System.Windows.Forms.GroupBox();
			this.cbToMonth = new System.Windows.Forms.ComboBox();
			this.cbFromMonth = new System.Windows.Forms.ComboBox();
			this.cbToYear = new System.Windows.Forms.ComboBox();
			this.cbFromYear = new System.Windows.Forms.ComboBox();
			this.Label4 = new System.Windows.Forms.Label();
			this.Label3 = new System.Windows.Forms.Label();
			this.Label2 = new System.Windows.Forms.Label();
			this.Label1 = new System.Windows.Forms.Label();
			this.lblFromToDate = new System.Windows.Forms.Label();
			this.cmdAllocate = new System.Windows.Forms.Button();
			this.grdVoucherDetails = new C1.Win.C1TrueDBGrid.C1TrueDBGrid();
			this.Column_0_grdVoucherDetails = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.Column_1_grdVoucherDetails = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.txtAnnualBudget = new System.Windows.Forms.TextBox();
			this.BudgetLine = new System.Windows.Forms.GroupBox();
			this.lblLedgerNo = new System.Windows.Forms.Label();
			this.txtLdgrNo = new System.Windows.Forms.TextBox();
			this.txtLdgrName = new System.Windows.Forms.TextBox();
			this.lblAnnualBudget = new System.Windows.Forms.Label();
			this.tcbSystemForm = new Syncfusion.Windows.Forms.Tools.CommandBarController();
			// //((System.ComponentModel.ISupportInitialize) this.tcbSystemForm).BeginInit();
			//this.Frame1.SuspendLayout();
			//this.grdVoucherDetails.SuspendLayout();
			this.SuspendLayout();
			// 
			// Frame1
			// 
			//this.Frame1.AllowDrop = true;
			this.Frame1.BackColor = System.Drawing.Color.White;
			this.Frame1.Controls.Add(this.cbToMonth);
			this.Frame1.Controls.Add(this.cbFromMonth);
			this.Frame1.Controls.Add(this.cbToYear);
			this.Frame1.Controls.Add(this.cbFromYear);
			this.Frame1.Controls.Add(this.Label4);
			this.Frame1.Controls.Add(this.Label3);
			this.Frame1.Controls.Add(this.Label2);
			this.Frame1.Controls.Add(this.Label1);
			this.Frame1.Enabled = true;
			this.Frame1.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 178);
			this.Frame1.ForeColor = System.Drawing.Color.Navy;
			this.Frame1.Location = new System.Drawing.Point(8, 104);
			this.Frame1.Name = "Frame1";
			this.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Frame1.Size = new System.Drawing.Size(391, 67);
			this.Frame1.TabIndex = 9;
			this.Frame1.Text = "Period";
			this.Frame1.Visible = true;
			// 
			// cbToMonth
			// 
			//this.cbToMonth.AllowDrop = true;
			this.cbToMonth.BackColor = System.Drawing.SystemColors.Window;
			this.cbToMonth.CausesValidation = true;
			this.cbToMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbToMonth.Enabled = true;
			this.cbToMonth.ForeColor = System.Drawing.SystemColors.WindowText;
			this.cbToMonth.IntegralHeight = true;
			this.cbToMonth.Location = new System.Drawing.Point(180, 40);
			this.cbToMonth.Name = "cbToMonth";
			this.cbToMonth.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cbToMonth.Size = new System.Drawing.Size(83, 21);
			this.cbToMonth.Sorted = false;
			this.cbToMonth.TabIndex = 17;
			this.cbToMonth.TabStop = true;
			this.cbToMonth.Visible = true;
			// this.cbToMonth.Leave += new System.EventHandler(this.cbToMonth_Leave);
			// 
			// cbFromMonth
			// 
			//this.cbFromMonth.AllowDrop = true;
			this.cbFromMonth.BackColor = System.Drawing.SystemColors.Window;
			this.cbFromMonth.CausesValidation = true;
			this.cbFromMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbFromMonth.Enabled = true;
			this.cbFromMonth.ForeColor = System.Drawing.SystemColors.WindowText;
			this.cbFromMonth.IntegralHeight = true;
			this.cbFromMonth.Location = new System.Drawing.Point(180, 16);
			this.cbFromMonth.Name = "cbFromMonth";
			this.cbFromMonth.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cbFromMonth.Size = new System.Drawing.Size(83, 21);
			this.cbFromMonth.Sorted = false;
			this.cbFromMonth.TabIndex = 16;
			this.cbFromMonth.TabStop = true;
			this.cbFromMonth.Visible = true;
			// this.cbFromMonth.Leave += new System.EventHandler(this.cbFromMonth_Leave);
			// 
			// cbToYear
			// 
			//this.cbToYear.AllowDrop = true;
			this.cbToYear.BackColor = System.Drawing.SystemColors.Window;
			this.cbToYear.CausesValidation = true;
			this.cbToYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbToYear.Enabled = true;
			this.cbToYear.ForeColor = System.Drawing.SystemColors.WindowText;
			this.cbToYear.IntegralHeight = true;
			this.cbToYear.Location = new System.Drawing.Point(68, 40);
			this.cbToYear.Name = "cbToYear";
			this.cbToYear.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cbToYear.Size = new System.Drawing.Size(63, 21);
			this.cbToYear.Sorted = false;
			this.cbToYear.TabIndex = 15;
			this.cbToYear.TabStop = true;
			this.cbToYear.Visible = true;
			// this.cbToYear.Leave += new System.EventHandler(this.cbToYear_Leave);
			// 
			// cbFromYear
			// 
			//this.cbFromYear.AllowDrop = true;
			this.cbFromYear.BackColor = System.Drawing.SystemColors.Window;
			this.cbFromYear.CausesValidation = true;
			this.cbFromYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbFromYear.Enabled = true;
			this.cbFromYear.ForeColor = System.Drawing.SystemColors.WindowText;
			this.cbFromYear.IntegralHeight = true;
			this.cbFromYear.Location = new System.Drawing.Point(68, 16);
			this.cbFromYear.Name = "cbFromYear";
			this.cbFromYear.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cbFromYear.Size = new System.Drawing.Size(63, 21);
			this.cbFromYear.Sorted = false;
			this.cbFromYear.TabIndex = 14;
			this.cbFromYear.TabStop = true;
			this.cbFromYear.Visible = true;
			// this.cbFromYear.Leave += new System.EventHandler(this.cbFromYear_Leave);
			// 
			// Label4
			// 
			//this.Label4.AllowDrop = true;
			this.Label4.BackColor = System.Drawing.Color.White;
			//this.Label4.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Label4.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 178);
			this.Label4.ForeColor = System.Drawing.Color.Navy;
			this.Label4.Location = new System.Drawing.Point(142, 42);
			this.Label4.Name = "Label4";
			this.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label4.Size = new System.Drawing.Size(37, 15);
			this.Label4.TabIndex = 13;
			this.Label4.Text = "Month";
			// 
			// Label3
			// 
			//this.Label3.AllowDrop = true;
			this.Label3.BackColor = System.Drawing.Color.White;
			//this.Label3.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Label3.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 178);
			this.Label3.ForeColor = System.Drawing.Color.Navy;
			this.Label3.Location = new System.Drawing.Point(142, 18);
			this.Label3.Name = "Label3";
			this.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label3.Size = new System.Drawing.Size(37, 15);
			this.Label3.TabIndex = 12;
			this.Label3.Text = "Month";
			// 
			// Label2
			// 
			//this.Label2.AllowDrop = true;
			this.Label2.BackColor = System.Drawing.Color.White;
			//this.Label2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Label2.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 178);
			this.Label2.ForeColor = System.Drawing.Color.Navy;
			this.Label2.Location = new System.Drawing.Point(6, 42);
			this.Label2.Name = "Label2";
			this.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label2.Size = new System.Drawing.Size(61, 15);
			this.Label2.TabIndex = 11;
			this.Label2.Text = "To:      Year";
			// 
			// Label1
			// 
			//this.Label1.AllowDrop = true;
			this.Label1.BackColor = System.Drawing.Color.White;
			//this.Label1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Label1.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 178);
			this.Label1.ForeColor = System.Drawing.Color.Navy;
			this.Label1.Location = new System.Drawing.Point(6, 18);
			this.Label1.Name = "Label1";
			this.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label1.Size = new System.Drawing.Size(61, 19);
			this.Label1.TabIndex = 10;
			this.Label1.Text = "From:  Year";
			// 
			// lblFromToDate
			// 
			//this.lblFromToDate.AllowDrop = true;
			this.lblFromToDate.BackColor = System.Drawing.Color.White;
			// this.lblFromToDate.Text = "lbl";
			this.lblFromToDate.Location = new System.Drawing.Point(8, 176);
			this.lblFromToDate.Name = "lblFromToDate";
			this.lblFromToDate.Size = new System.Drawing.Size(10, 13);
			this.lblFromToDate.TabIndex = 8;
			// 
			// cmdAllocate
			// 
			//this.cmdAllocate.AllowDrop = true;
			this.cmdAllocate.BackColor = System.Drawing.SystemColors.Control;
			this.cmdAllocate.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdAllocate.Location = new System.Drawing.Point(194, 74);
			this.cmdAllocate.Name = "cmdAllocate";
			this.cmdAllocate.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdAllocate.Size = new System.Drawing.Size(99, 19);
			this.cmdAllocate.TabIndex = 3;
			// this.cmdAllocate.Text = "&Allocate";
			// this.cmdAllocate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.cmdAllocate.UseVisualStyleBackColor = false;
			// this.cmdAllocate.Click += new System.EventHandler(this.cmdAllocate_Click);
			// 
			// grdVoucherDetails
			// 
			//this.grdVoucherDetails.AllowDrop = true;
			this.grdVoucherDetails.BackColor = System.Drawing.Color.Silver;
			this.grdVoucherDetails.CellTipsWidth = 0;
			this.grdVoucherDetails.Location = new System.Drawing.Point(6, 202);
			this.grdVoucherDetails.Name = "grdVoucherDetails";
			this.grdVoucherDetails.RowDivider.Color = System.Drawing.Color.Silver;
			this.grdVoucherDetails.Size = new System.Drawing.Size(391, 157);
			this.grdVoucherDetails.TabIndex = 2;
			this.grdVoucherDetails.Columns.Add(this.Column_0_grdVoucherDetails);
			this.grdVoucherDetails.Columns.Add(this.Column_1_grdVoucherDetails);
			//this.grdVoucherDetails.AfterColUpdate += new C1.Win.C1TrueDBGrid.ColEventHandler(this.grdVoucherDetails_AfterColUpdate);
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
			// txtAnnualBudget
			// 
			//this.txtAnnualBudget.AllowDrop = true;
			// this.txtAnnualBudget.DisplayFormat = "####0.000###;;0.000;0.000";
			// this.txtAnnualBudget.Format = "###########0.000";
			this.txtAnnualBudget.Location = new System.Drawing.Point(90, 74);
			// // = 2147483647;
			// // = 0;
			this.txtAnnualBudget.Name = "txtAnnualBudget";
			this.txtAnnualBudget.Size = new System.Drawing.Size(99, 19);
			this.txtAnnualBudget.TabIndex = 1;
			this.txtAnnualBudget.Text = "0.000";
			// 
			// BudgetLine
			// 
			//this.BudgetLine.AllowDrop = true;
			this.BudgetLine.BackColor = System.Drawing.Color.White;
			this.BudgetLine.Enabled = true;
			this.BudgetLine.ForeColor = System.Drawing.SystemColors.ControlText;
			this.BudgetLine.Location = new System.Drawing.Point(7, 193);
			this.BudgetLine.Name = "BudgetLine";
			this.BudgetLine.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.BudgetLine.Size = new System.Drawing.Size(390, 8);
			this.BudgetLine.TabIndex = 4;
			this.BudgetLine.Visible = true;
			// 
			// lblLedgerNo
			// 
			//this.lblLedgerNo.AllowDrop = true;
			this.lblLedgerNo.BackColor = System.Drawing.Color.White;
			this.lblLedgerNo.Text = "Ledger Code";
			this.lblLedgerNo.Location = new System.Drawing.Point(8, 48);
			this.lblLedgerNo.Name = "lblLedgerNo";
			this.lblLedgerNo.Size = new System.Drawing.Size(62, 14);
			this.lblLedgerNo.TabIndex = 5;
			// 
			// txtLdgrNo
			// 
			//this.txtLdgrNo.AllowDrop = true;
			this.txtLdgrNo.BackColor = System.Drawing.Color.White;
			this.txtLdgrNo.ForeColor = System.Drawing.Color.Black;
			this.txtLdgrNo.Location = new System.Drawing.Point(90, 46);
			this.txtLdgrNo.MaxLength = 15;
			this.txtLdgrNo.Name = "txtLdgrNo";
			// this.txtLdgrNo.ShowButton = true;
			this.txtLdgrNo.Size = new System.Drawing.Size(101, 19);
			this.txtLdgrNo.TabIndex = 0;
			this.txtLdgrNo.Text = "";
			// this.//this.txtLdgrNo.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(//this.txtLdgrNo_DropButtonClick);
			// this.txtLdgrNo.Leave += new System.EventHandler(this.txtLdgrNo_Leave);
			// 
			// txtLdgrName
			// 
			//this.txtLdgrName.AllowDrop = true;
			this.txtLdgrName.BackColor = System.Drawing.Color.FromArgb(239, 239, 239);
			this.txtLdgrName.Enabled = false;
			this.txtLdgrName.ForeColor = System.Drawing.Color.Black;
			this.txtLdgrName.Location = new System.Drawing.Point(193, 46);
			this.txtLdgrName.Name = "txtLdgrName";
			this.txtLdgrName.Size = new System.Drawing.Size(201, 19);
			this.txtLdgrName.TabIndex = 6;
			this.txtLdgrName.TabStop = false;
			this.txtLdgrName.Text = " ";
			// 
			// lblAnnualBudget
			// 
			//this.lblAnnualBudget.AllowDrop = true;
			this.lblAnnualBudget.BackColor = System.Drawing.Color.White;
			this.lblAnnualBudget.Text = "Annual Budget";
			this.lblAnnualBudget.Location = new System.Drawing.Point(8, 76);
			this.lblAnnualBudget.Name = "lblAnnualBudget";
			this.lblAnnualBudget.Size = new System.Drawing.Size(70, 13);
			this.lblAnnualBudget.TabIndex = 7;
			// 
			// tcbSystemForm
			// 
			////this.tcbSystemForm.AllowDrop = true;
			//this.tcbSystemForm.Location = new System.Drawing.Point(124, 8);
			//this.tcbSystemForm.Name = "tcbSystemForm";
			//
			// 
			// frmGLLedgerBudget
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(402, 364);
			this.Controls.Add(this.Frame1);
			this.Controls.Add(this.lblFromToDate);
			this.Controls.Add(this.cmdAllocate);
			this.Controls.Add(this.grdVoucherDetails);
			this.Controls.Add(this.txtAnnualBudget);
			this.Controls.Add(this.BudgetLine);
			this.Controls.Add(this.lblLedgerNo);
			this.Controls.Add(this.txtLdgrNo);
			this.Controls.Add(this.txtLdgrName);
			this.Controls.Add(this.lblAnnualBudget);
			//this.Controls.Add(this.tcbSystemForm);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			//this.Icon = (System.Drawing.Icon) resources.GetObject("frmGLLedgerBudget.Icon");
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(133, 97);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmGLLedgerBudget";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Ledger Budgets";
			// this.Activated += new System.EventHandler(this.frmGLLedgerBudget_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
			// this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
			//((System.ComponentModel.ISupportInitialize) this.tcbSystemForm).EndInit();
			this.Frame1.ResumeLayout(false);
			this.grdVoucherDetails.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		// 
		#endregion
	}
}//ENDSHERE
