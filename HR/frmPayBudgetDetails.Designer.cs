
namespace Xtreme
{
	partial class frmPayBudgetDetails
	{

		#region "Upgrade Support "
		private static frmPayBudgetDetails m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmPayBudgetDetails DefInstance
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
		public static frmPayBudgetDetails CreateInstance()
		{
			frmPayBudgetDetails theInstance = new frmPayBudgetDetails();
			
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
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "txtBudgetCode", "lblBudgetCode", "txtDBudgetName", "txtDeptCode", "lblSectionCode", "txtDCategoryName", "System.Windows.Forms.Label1", "System.Windows.Forms.Label2", "System.Windows.Forms.Label3", "Column_0_grdHeadcountSummary", "Column_1_grdHeadcountSummary", "grdHeadcountSummary", "Column_0_grdAddHeadcountDetails", "Column_1_grdAddHeadcountDetails", "grdAddHeadcountDetails", "Column_0_grdCurrentPayroll", "Column_1_grdCurrentPayroll", "grdCurrentPayroll"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public System.Windows.Forms.TextBox txtBudgetCode;
		public System.Windows.Forms.Label lblBudgetCode;
		public System.Windows.Forms.Label txtDBudgetName;
		public System.Windows.Forms.TextBox txtDeptCode;
		public System.Windows.Forms.Label lblSectionCode;
		public System.Windows.Forms.Label txtDCategoryName;
		public System.Windows.Forms.Label System.Windows.Forms.Label1;
		public System.Windows.Forms.Label System.Windows.Forms.Label2;
		public System.Windows.Forms.Label System.Windows.Forms.Label3;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_0_grdHeadcountSummary;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_1_grdHeadcountSummary;
		public C1.Win.C1TrueDBGrid.C1TrueDBGrid grdHeadcountSummary;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_0_grdAddHeadcountDetails;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_1_grdAddHeadcountDetails;
		public C1.Win.C1TrueDBGrid.C1TrueDBGrid grdAddHeadcountDetails;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_0_grdCurrentPayroll;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_1_grdCurrentPayroll;
		public C1.Win.C1TrueDBGrid.C1TrueDBGrid grdCurrentPayroll;
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPayBudgetDetails));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this.txtBudgetCode = new System.Windows.Forms.TextBox();
			this.lblBudgetCode = new System.Windows.Forms.Label();
			this.txtDBudgetName = new System.Windows.Forms.Label();
			this.txtDeptCode = new System.Windows.Forms.TextBox();
			this.lblSectionCode = new System.Windows.Forms.Label();
			this.txtDCategoryName = new System.Windows.Forms.Label();
			this.System.Windows.Forms.Label1 = new System.Windows.Forms.Label();
			this.System.Windows.Forms.Label2 = new System.Windows.Forms.Label();
			this.System.Windows.Forms.Label3 = new System.Windows.Forms.Label();
			this.grdHeadcountSummary = new C1.Win.C1TrueDBGrid.C1TrueDBGrid();
			this.Column_0_grdHeadcountSummary = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.Column_1_grdHeadcountSummary = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.grdAddHeadcountDetails = new C1.Win.C1TrueDBGrid.C1TrueDBGrid();
			this.Column_0_grdAddHeadcountDetails = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.Column_1_grdAddHeadcountDetails = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.grdCurrentPayroll = new C1.Win.C1TrueDBGrid.C1TrueDBGrid();
			this.Column_0_grdCurrentPayroll = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.Column_1_grdCurrentPayroll = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.grdHeadcountSummary.SuspendLayout();
			this.grdAddHeadcountDetails.SuspendLayout();
			this.grdCurrentPayroll.SuspendLayout();
			this.SuspendLayout();
			// 
			// txtBudgetCode
			// 
			this.txtBudgetCode.AllowDrop = true;
			this.txtBudgetCode.BackColor = System.Drawing.Color.White;
			// this.txtBudgetCode.bolNumericOnly = true;
			this.txtBudgetCode.ForeColor = System.Drawing.Color.Black;
			this.txtBudgetCode.Location = new System.Drawing.Point(142, 85);
			this.txtBudgetCode.MaxLength = 8;
			this.txtBudgetCode.Name = "txtBudgetCode";
			// this.txtBudgetCode.ShowButton = true;
			this.txtBudgetCode.Size = new System.Drawing.Size(101, 19);
			this.txtBudgetCode.TabIndex = 0;
			this.txtBudgetCode.Text = "";
			// this.this.txtBudgetCode.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtBudgetCode_DropButtonClick);
			// this.txtBudgetCode.Leave += new System.EventHandler(this.txtBudgetCode_Leave);
			// 
			// lblBudgetCode
			// 
			this.lblBudgetCode.AllowDrop = true;
			this.lblBudgetCode.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblBudgetCode.Text = "Budget Code";
			this.lblBudgetCode.Location = new System.Drawing.Point(17, 87);
			this.lblBudgetCode.Name = "lblBudgetCode";
			this.lblBudgetCode.Size = new System.Drawing.Size(62, 14);
			this.lblBudgetCode.TabIndex = 2;
			// 
			// txtDBudgetName
			// 
			this.txtDBudgetName.AllowDrop = true;
			this.txtDBudgetName.Location = new System.Drawing.Point(245, 85);
			this.txtDBudgetName.Name = "txtDBudgetName";
			this.txtDBudgetName.Size = new System.Drawing.Size(239, 19);
			this.txtDBudgetName.TabIndex = 6;
			this.txtDBudgetName.TabStop = false;
			// 
			// txtDeptCode
			// 
			this.txtDeptCode.AllowDrop = true;
			this.txtDeptCode.BackColor = System.Drawing.Color.White;
			// this.txtDeptCode.bolNumericOnly = true;
			this.txtDeptCode.ForeColor = System.Drawing.Color.Black;
			this.txtDeptCode.Location = new System.Drawing.Point(142, 107);
			this.txtDeptCode.MaxLength = 8;
			this.txtDeptCode.Name = "txtDeptCode";
			// this.txtDeptCode.ShowButton = true;
			this.txtDeptCode.Size = new System.Drawing.Size(101, 19);
			this.txtDeptCode.TabIndex = 1;
			this.txtDeptCode.Text = "";
			// this.this.txtDeptCode.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtDeptCode_DropButtonClick);
			// this.txtDeptCode.Leave += new System.EventHandler(this.txtDeptCode_Leave);
			// 
			// lblSectionCode
			// 
			this.lblSectionCode.AllowDrop = true;
			this.lblSectionCode.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblSectionCode.Text = "Section Code";
			this.lblSectionCode.Location = new System.Drawing.Point(17, 109);
			this.lblSectionCode.Name = "lblSectionCode";
			this.lblSectionCode.Size = new System.Drawing.Size(64, 14);
			this.lblSectionCode.TabIndex = 7;
			// 
			// txtDCategoryName
			// 
			this.txtDCategoryName.AllowDrop = true;
			this.txtDCategoryName.Location = new System.Drawing.Point(245, 107);
			this.txtDCategoryName.Name = "txtDCategoryName";
			this.txtDCategoryName.Size = new System.Drawing.Size(239, 19);
			this.txtDCategoryName.TabIndex = 8;
			this.txtDCategoryName.TabStop = false;
			// 
			// System.Windows.Forms.Label1
			// 
			this.System.Windows.Forms.Label1.AllowDrop = true;
			this.System.Windows.Forms.Label1.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			this.System.Windows.Forms.Label1.Caption = "Current Payroll Details";
			this.System.Windows.Forms.Label1.Location = new System.Drawing.Point(557, 358);
			this.System.Windows.Forms.Label1.Name = "System.Windows.Forms.Label1";
			this.System.Windows.Forms.Label1.Size = new System.Drawing.Size(106, 14);
			this.System.Windows.Forms.Label1.TabIndex = 9;
			// 
			// System.Windows.Forms.Label2
			// 
			this.System.Windows.Forms.Label2.AllowDrop = true;
			this.System.Windows.Forms.Label2.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.System.Windows.Forms.Label2.Caption = "Additional Headcount Details";
			this.System.Windows.Forms.Label2.Location = new System.Drawing.Point(16, 358);
			this.System.Windows.Forms.Label2.Name = "System.Windows.Forms.Label2";
			this.System.Windows.Forms.Label2.Size = new System.Drawing.Size(137, 14);
			this.System.Windows.Forms.Label2.TabIndex = 10;
			// 
			// System.Windows.Forms.Label3
			// 
			this.System.Windows.Forms.Label3.AllowDrop = true;
			this.System.Windows.Forms.Label3.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.System.Windows.Forms.Label3.Caption = "Headcount Summary";
			this.System.Windows.Forms.Label3.Location = new System.Drawing.Point(18, 154);
			this.System.Windows.Forms.Label3.Name = "System.Windows.Forms.Label3";
			this.System.Windows.Forms.Label3.Size = new System.Drawing.Size(100, 14);
			this.System.Windows.Forms.Label3.TabIndex = 11;
			// 
			// grdHeadcountSummary
			// 
			this.grdHeadcountSummary.AllowDrop = true;
			this.grdHeadcountSummary.BackColor = System.Drawing.Color.Silver;
			this.grdHeadcountSummary.CellTipsWidth = 0;
			this.grdHeadcountSummary.Location = new System.Drawing.Point(9, 168);
			this.grdHeadcountSummary.Name = "grdHeadcountSummary";
			this.grdHeadcountSummary.RowDivider.Color = System.Drawing.Color.Silver;
			this.grdHeadcountSummary.Size = new System.Drawing.Size(1087, 172);
			this.grdHeadcountSummary.TabIndex = 3;
			this.grdHeadcountSummary.Columns.Add(this.Column_0_grdHeadcountSummary);
			this.grdHeadcountSummary.Columns.Add(this.Column_1_grdHeadcountSummary);
			this.grdHeadcountSummary.RowColChange += new C1.Win.C1TrueDBGrid.RowColChangeEventHandler(this.grdHeadcountSummary_RowColChange);
			// 
			// Column_0_grdHeadcountSummary
			// 
			this.Column_0_grdHeadcountSummary.DataField = "";
			this.Column_0_grdHeadcountSummary.ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.Normal;
			// 
			// Column_1_grdHeadcountSummary
			// 
			this.Column_1_grdHeadcountSummary.DataField = "";
			this.Column_1_grdHeadcountSummary.ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.Normal;
			// 
			// grdAddHeadcountDetails
			// 
			this.grdAddHeadcountDetails.AllowDrop = true;
			this.grdAddHeadcountDetails.BackColor = System.Drawing.Color.Silver;
			this.grdAddHeadcountDetails.CellTipsWidth = 0;
			this.grdAddHeadcountDetails.Location = new System.Drawing.Point(9, 375);
			this.grdAddHeadcountDetails.Name = "grdAddHeadcountDetails";
			this.grdAddHeadcountDetails.RowDivider.Color = System.Drawing.Color.Silver;
			this.grdAddHeadcountDetails.Size = new System.Drawing.Size(531, 187);
			this.grdAddHeadcountDetails.TabIndex = 4;
			this.grdAddHeadcountDetails.Columns.Add(this.Column_0_grdAddHeadcountDetails);
			this.grdAddHeadcountDetails.Columns.Add(this.Column_1_grdAddHeadcountDetails);
			this.grdAddHeadcountDetails.AfterColUpdate += new C1.Win.C1TrueDBGrid.ColEventHandler(this.grdAddHeadcountDetails_AfterColUpdate);
			this.grdAddHeadcountDetails.BeforeColUpdate += new C1.Win.C1TrueDBGrid.BeforeColUpdateEventHandler(this.grdAddHeadcountDetails_BeforeColUpdate);
			// 
			// Column_0_grdAddHeadcountDetails
			// 
			this.Column_0_grdAddHeadcountDetails.DataField = "";
			this.Column_0_grdAddHeadcountDetails.ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.Normal;
			// 
			// Column_1_grdAddHeadcountDetails
			// 
			this.Column_1_grdAddHeadcountDetails.DataField = "";
			this.Column_1_grdAddHeadcountDetails.ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.Normal;
			// 
			// grdCurrentPayroll
			// 
			this.grdCurrentPayroll.AllowDrop = true;
			this.grdCurrentPayroll.BackColor = System.Drawing.Color.Silver;
			this.grdCurrentPayroll.CellTipsWidth = 0;
			this.grdCurrentPayroll.Location = new System.Drawing.Point(552, 375);
			this.grdCurrentPayroll.Name = "grdCurrentPayroll";
			this.grdCurrentPayroll.RowDivider.Color = System.Drawing.Color.Silver;
			this.grdCurrentPayroll.Size = new System.Drawing.Size(542, 187);
			this.grdCurrentPayroll.TabIndex = 5;
			this.grdCurrentPayroll.Columns.Add(this.Column_0_grdCurrentPayroll);
			this.grdCurrentPayroll.Columns.Add(this.Column_1_grdCurrentPayroll);
			// 
			// Column_0_grdCurrentPayroll
			// 
			this.Column_0_grdCurrentPayroll.DataField = "";
			this.Column_0_grdCurrentPayroll.ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.Normal;
			// 
			// Column_1_grdCurrentPayroll
			// 
			this.Column_1_grdCurrentPayroll.DataField = "";
			this.Column_1_grdCurrentPayroll.ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.Normal;
			// 
			// frmPayBudgetDetails
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.ClientSize = new System.Drawing.Size(1102, 570);
			this.Controls.Add(this.txtBudgetCode);
			this.Controls.Add(this.lblBudgetCode);
			this.Controls.Add(this.txtDBudgetName);
			this.Controls.Add(this.txtDeptCode);
			this.Controls.Add(this.lblSectionCode);
			this.Controls.Add(this.txtDCategoryName);
			this.Controls.Add(this.System.Windows.Forms.Label1);
			this.Controls.Add(this.System.Windows.Forms.Label2);
			this.Controls.Add(this.System.Windows.Forms.Label3);
			this.Controls.Add(this.grdHeadcountSummary);
			this.Controls.Add(this.grdAddHeadcountDetails);
			this.Controls.Add(this.grdCurrentPayroll);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			//this.Icon = (System.Drawing.Icon) resources.GetObject("frmPayBudgetDetails.Icon");
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(46, 123);
			this.MaximizeBox = true;
			this.MinimizeBox = true;
			this.Name = "frmPayBudgetDetails";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Budget Details";
			// this.Activated += new System.EventHandler(this.frmPayBudgetDetails_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
			// this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
			this.grdHeadcountSummary.ResumeLayout(false);
			this.grdAddHeadcountDetails.ResumeLayout(false);
			this.grdCurrentPayroll.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		void ReLoadForm(bool addEvents)
		{
			//This form is an MDI child.
			//This code simulates the VB6 
			// functionality of automatically
			// loading and showing an MDI
			// child's parent.
			this.MdiParent = Xtreme.frmSysMain.DefInstance;
			Xtreme.frmSysMain.DefInstance.Show();
		}
		#endregion
	}
}