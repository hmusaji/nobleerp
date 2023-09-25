
namespace Xtreme
{
	partial class frmPayBudgetRevised
	{

		
		#region "Windows Form Designer generated code "
		public static frmPayBudgetRevised CreateInstance()
		{
			frmPayBudgetRevised theInstance = new frmPayBudgetRevised();
			
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
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "cmdGetRecords", "txtBudgetCode", "lblBudgetCode", "txtDBudgetName", "txtDeptCode", "lblSectionCode", "txtDCategoryName", "Column_0_grdAddHeadcountDetails", "Column_1_grdAddHeadcountDetails", "grdAddHeadcountDetails", "txtHCCategoryNo", "lblDeptCode", "txtHCCategoryName"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public System.Windows.Forms.Button cmdGetRecords;
		public System.Windows.Forms.TextBox txtBudgetCode;
		public System.Windows.Forms.Label lblBudgetCode;
		public System.Windows.Forms.Label txtDBudgetName;
		public System.Windows.Forms.TextBox txtDeptCode;
		public System.Windows.Forms.Label lblSectionCode;
		public System.Windows.Forms.Label txtDCategoryName;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_0_grdAddHeadcountDetails;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_1_grdAddHeadcountDetails;
		public C1.Win.C1TrueDBGrid.C1TrueDBGrid grdAddHeadcountDetails;
		public System.Windows.Forms.TextBox txtHCCategoryNo;
		public System.Windows.Forms.Label lblDeptCode;
		public System.Windows.Forms.Label txtHCCategoryName;
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPayBudgetRevised));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this.cmdGetRecords = new System.Windows.Forms.Button();
			this.txtBudgetCode = new System.Windows.Forms.TextBox();
			this.lblBudgetCode = new System.Windows.Forms.Label();
			this.txtDBudgetName = new System.Windows.Forms.Label();
			this.txtDeptCode = new System.Windows.Forms.TextBox();
			this.lblSectionCode = new System.Windows.Forms.Label();
			this.txtDCategoryName = new System.Windows.Forms.Label();
			this.grdAddHeadcountDetails = new C1.Win.C1TrueDBGrid.C1TrueDBGrid();
			this.Column_0_grdAddHeadcountDetails = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.Column_1_grdAddHeadcountDetails = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.txtHCCategoryNo = new System.Windows.Forms.TextBox();
			this.lblDeptCode = new System.Windows.Forms.Label();
			this.txtHCCategoryName = new System.Windows.Forms.Label();
			this.grdAddHeadcountDetails.SuspendLayout();
			this.SuspendLayout();
			// 
			// cmdGetRecords
			// 
			this.cmdGetRecords.AllowDrop = true;
			this.cmdGetRecords.BackColor = System.Drawing.SystemColors.Control;
			this.cmdGetRecords.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdGetRecords.Location = new System.Drawing.Point(495, 105);
			this.cmdGetRecords.Name = "cmdGetRecords";
			this.cmdGetRecords.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdGetRecords.Size = new System.Drawing.Size(142, 25);
			this.cmdGetRecords.TabIndex = 4;
			this.cmdGetRecords.Text = "Get Record";
			this.cmdGetRecords.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.cmdGetRecords.UseVisualStyleBackColor = false;
			// this.cmdGetRecords.Click += new System.EventHandler(this.cmdGetRecords_Click);
			// 
			// txtBudgetCode
			// 
			this.txtBudgetCode.AllowDrop = true;
			this.txtBudgetCode.BackColor = System.Drawing.Color.White;
			// this.txtBudgetCode.bolNumericOnly = true;
			this.txtBudgetCode.ForeColor = System.Drawing.Color.Black;
			this.txtBudgetCode.Location = new System.Drawing.Point(137, 63);
			this.txtBudgetCode.MaxLength = 8;
			this.txtBudgetCode.Name = "txtBudgetCode";
			// this.txtBudgetCode.ShowButton = true;
			this.txtBudgetCode.Size = new System.Drawing.Size(101, 19);
			this.txtBudgetCode.TabIndex = 1;
			this.txtBudgetCode.Text = "";
			// this.this.txtBudgetCode.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtBudgetCode_DropButtonClick);
			// this.txtBudgetCode.Leave += new System.EventHandler(this.txtBudgetCode_Leave);
			// 
			// lblBudgetCode
			// 
			this.lblBudgetCode.AllowDrop = true;
			this.lblBudgetCode.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblBudgetCode.Text = "Budget Code";
			this.lblBudgetCode.Location = new System.Drawing.Point(12, 65);
			this.lblBudgetCode.Name = "lblBudgetCode";
			this.lblBudgetCode.Size = new System.Drawing.Size(62, 14);
			this.lblBudgetCode.TabIndex = 0;
			// 
			// txtDBudgetName
			// 
			this.txtDBudgetName.AllowDrop = true;
			this.txtDBudgetName.Location = new System.Drawing.Point(240, 63);
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
			this.txtDeptCode.Location = new System.Drawing.Point(137, 85);
			this.txtDeptCode.MaxLength = 8;
			this.txtDeptCode.Name = "txtDeptCode";
			// this.txtDeptCode.ShowButton = true;
			this.txtDeptCode.Size = new System.Drawing.Size(101, 19);
			this.txtDeptCode.TabIndex = 2;
			this.txtDeptCode.Text = "";
			// this.this.txtDeptCode.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtDeptCode_DropButtonClick);
			// this.txtDeptCode.Leave += new System.EventHandler(this.txtDeptCode_Leave);
			// 
			// lblSectionCode
			// 
			this.lblSectionCode.AllowDrop = true;
			this.lblSectionCode.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			this.lblSectionCode.Text = "Section Code";
			this.lblSectionCode.Location = new System.Drawing.Point(12, 87);
			this.lblSectionCode.Name = "lblSectionCode";
			this.lblSectionCode.Size = new System.Drawing.Size(64, 14);
			this.lblSectionCode.TabIndex = 7;
			// 
			// txtDCategoryName
			// 
			this.txtDCategoryName.AllowDrop = true;
			this.txtDCategoryName.Location = new System.Drawing.Point(240, 85);
			this.txtDCategoryName.Name = "txtDCategoryName";
			this.txtDCategoryName.Size = new System.Drawing.Size(239, 19);
			this.txtDCategoryName.TabIndex = 8;
			this.txtDCategoryName.TabStop = false;
			// 
			// grdAddHeadcountDetails
			// 
			this.grdAddHeadcountDetails.AllowDrop = true;
			this.grdAddHeadcountDetails.BackColor = System.Drawing.Color.Silver;
			this.grdAddHeadcountDetails.CellTipsWidth = 0;
			this.grdAddHeadcountDetails.Location = new System.Drawing.Point(6, 138);
			this.grdAddHeadcountDetails.Name = "grdAddHeadcountDetails";
			this.grdAddHeadcountDetails.RowDivider.Color = System.Drawing.Color.Silver;
			this.grdAddHeadcountDetails.Size = new System.Drawing.Size(633, 238);
			this.grdAddHeadcountDetails.TabIndex = 5;
			this.grdAddHeadcountDetails.Columns.Add(this.Column_0_grdAddHeadcountDetails);
			this.grdAddHeadcountDetails.Columns.Add(this.Column_1_grdAddHeadcountDetails);
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
			// txtHCCategoryNo
			// 
			this.txtHCCategoryNo.AllowDrop = true;
			this.txtHCCategoryNo.BackColor = System.Drawing.Color.White;
			// this.txtHCCategoryNo.bolNumericOnly = true;
			this.txtHCCategoryNo.ForeColor = System.Drawing.Color.Black;
			this.txtHCCategoryNo.Location = new System.Drawing.Point(137, 108);
			this.txtHCCategoryNo.MaxLength = 8;
			this.txtHCCategoryNo.Name = "txtHCCategoryNo";
			// this.txtHCCategoryNo.ShowButton = true;
			this.txtHCCategoryNo.Size = new System.Drawing.Size(101, 19);
			this.txtHCCategoryNo.TabIndex = 3;
			this.txtHCCategoryNo.Text = "";
			// this.this.txtHCCategoryNo.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtHCCategoryNo_DropButtonClick);
			// this.txtHCCategoryNo.Leave += new System.EventHandler(this.txtHCCategoryNo_Leave);
			// 
			// lblDeptCode
			// 
			this.lblDeptCode.AllowDrop = true;
			this.lblDeptCode.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			this.lblDeptCode.Text = "Category Code";
			this.lblDeptCode.Location = new System.Drawing.Point(12, 110);
			this.lblDeptCode.Name = "lblDeptCode";
			this.lblDeptCode.Size = new System.Drawing.Size(72, 14);
			this.lblDeptCode.TabIndex = 9;
			// 
			// txtHCCategoryName
			// 
			this.txtHCCategoryName.AllowDrop = true;
			this.txtHCCategoryName.Location = new System.Drawing.Point(240, 108);
			this.txtHCCategoryName.Name = "txtHCCategoryName";
			this.txtHCCategoryName.Size = new System.Drawing.Size(239, 19);
			this.txtHCCategoryName.TabIndex = 10;
			this.txtHCCategoryName.TabStop = false;
			// 
			// frmPayBudgetRevised
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.ClientSize = new System.Drawing.Size(649, 386);
			this.Controls.Add(this.cmdGetRecords);
			this.Controls.Add(this.txtBudgetCode);
			this.Controls.Add(this.lblBudgetCode);
			this.Controls.Add(this.txtDBudgetName);
			this.Controls.Add(this.txtDeptCode);
			this.Controls.Add(this.lblSectionCode);
			this.Controls.Add(this.txtDCategoryName);
			this.Controls.Add(this.grdAddHeadcountDetails);
			this.Controls.Add(this.txtHCCategoryNo);
			this.Controls.Add(this.lblDeptCode);
			this.Controls.Add(this.txtHCCategoryName);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			//this.Icon = (System.Drawing.Icon) resources.GetObject("frmPayBudgetRevised.Icon");
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(199, 130);
			this.MaximizeBox = true;
			this.MinimizeBox = true;
			this.Name = "frmPayBudgetRevised";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Budget Revised";
			// this.Activated += new System.EventHandler(this.frmPayBudgetRevised_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
			// this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
			this.grdAddHeadcountDetails.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		// 
		#endregion
	}
}//ENDSHERE
