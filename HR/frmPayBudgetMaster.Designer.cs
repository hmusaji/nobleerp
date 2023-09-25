
namespace Xtreme
{
	partial class frmPayBudgetMaster
	{

		
		#region "Windows Form Designer generated code "
		public static frmPayBudgetMaster CreateInstance()
		{
			frmPayBudgetMaster theInstance = new frmPayBudgetMaster();
			
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
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "cmdRefreshCategory", "cmdRefreshPayroll", "chkFreezed", "txtComments", "txtBudgetCode", "lblCategoryCode", "lblLCategoryName", "txtLBudgetName", "lblACategoryName", "txtABudgetName", "System.Windows.Forms.Label2", "System.Windows.Forms.Label1", "txtEndDate", "txtStartDate", "lblComments"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public System.Windows.Forms.Button cmdRefreshCategory;
		public System.Windows.Forms.Button cmdRefreshPayroll;
		public System.Windows.Forms.CheckBox chkFreezed;
		public System.Windows.Forms.TextBox txtComments;
		public System.Windows.Forms.TextBox txtBudgetCode;
		public System.Windows.Forms.Label lblCategoryCode;
		public System.Windows.Forms.Label lblLCategoryName;
		public System.Windows.Forms.TextBox txtLBudgetName;
		public System.Windows.Forms.Label lblACategoryName;
		public System.Windows.Forms.TextBox txtABudgetName;
		public System.Windows.Forms.Label Label2;
		public System.Windows.Forms.Label Label1;
		public Syncfusion.WinForms.Input.SfDateTimeEdit txtEndDate;
		public Syncfusion.WinForms.Input.SfDateTimeEdit txtStartDate;
		public System.Windows.Forms.Label lblComments;
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPayBudgetMaster));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this.cmdRefreshCategory = new System.Windows.Forms.Button();
			this.cmdRefreshPayroll = new System.Windows.Forms.Button();
			this.chkFreezed = new System.Windows.Forms.CheckBox();
			this.txtComments = new System.Windows.Forms.TextBox();
			this.txtBudgetCode = new System.Windows.Forms.TextBox();
			this.lblCategoryCode = new System.Windows.Forms.Label();
			this.lblLCategoryName = new System.Windows.Forms.Label();
			this.txtLBudgetName = new System.Windows.Forms.TextBox();
			this.lblACategoryName = new System.Windows.Forms.Label();
			this.txtABudgetName = new System.Windows.Forms.TextBox();
			this.Label2 = new System.Windows.Forms.Label();
			this.Label1 = new System.Windows.Forms.Label();
			this.txtEndDate = new Syncfusion.WinForms.Input.SfDateTimeEdit();
			this.txtStartDate = new Syncfusion.WinForms.Input.SfDateTimeEdit();
			this.lblComments = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// cmdRefreshCategory
			// 
			this.cmdRefreshCategory.AllowDrop = true;
			this.cmdRefreshCategory.BackColor = System.Drawing.SystemColors.Control;
			this.cmdRefreshCategory.Enabled = false;
			this.cmdRefreshCategory.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdRefreshCategory.Location = new System.Drawing.Point(258, 168);
			this.cmdRefreshCategory.Name = "cmdRefreshCategory";
			this.cmdRefreshCategory.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdRefreshCategory.Size = new System.Drawing.Size(220, 23);
			this.cmdRefreshCategory.TabIndex = 8;
			this.cmdRefreshCategory.Text = "Refresh Category";
			this.cmdRefreshCategory.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			// this.cmdRefreshCategory.Click += new System.EventHandler(this.cmdRefreshCategory_Click);
			// 
			// cmdRefreshPayroll
			// 
			this.cmdRefreshPayroll.AllowDrop = true;
			this.cmdRefreshPayroll.BackColor = System.Drawing.SystemColors.Control;
			this.cmdRefreshPayroll.Enabled = false;
			this.cmdRefreshPayroll.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdRefreshPayroll.Location = new System.Drawing.Point(258, 144);
			this.cmdRefreshPayroll.Name = "cmdRefreshPayroll";
			this.cmdRefreshPayroll.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdRefreshPayroll.Size = new System.Drawing.Size(220, 23);
			this.cmdRefreshPayroll.TabIndex = 7;
			this.cmdRefreshPayroll.Text = "Refresh Payroll";
			this.cmdRefreshPayroll.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			// this.cmdRefreshPayroll.Click += new System.EventHandler(this.cmdRefreshPayroll_Click);
			// 
			// chkFreezed
			// 
			this.chkFreezed.AllowDrop = true;
			this.chkFreezed.Appearance = System.Windows.Forms.Appearance.Normal;
			this.chkFreezed.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.chkFreezed.CausesValidation = true;
			this.chkFreezed.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkFreezed.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this.chkFreezed.Enabled = true;
			this.chkFreezed.ForeColor = System.Drawing.SystemColors.ControlText;
			this.chkFreezed.Location = new System.Drawing.Point(141, 192);
			this.chkFreezed.Name = "chkFreezed";
			this.chkFreezed.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.chkFreezed.Size = new System.Drawing.Size(106, 19);
			this.chkFreezed.TabIndex = 5;
			this.chkFreezed.TabStop = true;
			this.chkFreezed.Text = " Freezed Budget";
			this.chkFreezed.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkFreezed.Visible = true;
			// 
			// txtComments
			// 
			this.txtComments.AcceptsReturn = true;
			this.txtComments.AllowDrop = true;
			this.txtComments.BackColor = System.Drawing.SystemColors.Window;
			this.txtComments.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.txtComments.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtComments.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtComments.Location = new System.Drawing.Point(137, 216);
			this.txtComments.MaxLength = 0;
			this.txtComments.Multiline = true;
			this.txtComments.Name = "txtComments";
			this.txtComments.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtComments.Size = new System.Drawing.Size(343, 61);
			this.txtComments.TabIndex = 6;
			// 
			// txtBudgetCode
			// 
			this.txtBudgetCode.AllowDrop = true;
			this.txtBudgetCode.BackColor = System.Drawing.Color.White;
			// this.txtBudgetCode.bolNumericOnly = true;
			this.txtBudgetCode.ForeColor = System.Drawing.Color.Black;
			this.txtBudgetCode.Location = new System.Drawing.Point(138, 78);
			this.txtBudgetCode.MaxLength = 15;
			// // = System.Windows.Forms.TextBox.DropDownTypes.ddtNextNumber;
			this.txtBudgetCode.Name = "txtBudgetCode";
			// this.txtBudgetCode.ShowButton = true;
			this.txtBudgetCode.Size = new System.Drawing.Size(110, 19);
			this.txtBudgetCode.TabIndex = 0;
			this.txtBudgetCode.Text = "";
			// 
			// lblCategoryCode
			// 
			this.lblCategoryCode.AllowDrop = true;
			this.lblCategoryCode.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblCategoryCode.Text = "Budget Code";
			this.lblCategoryCode.Location = new System.Drawing.Point(10, 80);
			this.lblCategoryCode.Name = "lblCategoryCode";
			this.lblCategoryCode.Size = new System.Drawing.Size(62, 14);
			this.lblCategoryCode.TabIndex = 9;
			// 
			// lblLCategoryName
			// 
			this.lblLCategoryName.AllowDrop = true;
			this.lblLCategoryName.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblLCategoryName.Text = "Budget Name (English)";
			this.lblLCategoryName.Location = new System.Drawing.Point(10, 102);
			this.lblLCategoryName.Name = "lblLCategoryName";
			this.lblLCategoryName.Size = new System.Drawing.Size(109, 14);
			this.lblLCategoryName.TabIndex = 10;
			// 
			// txtLBudgetName
			// 
			this.txtLBudgetName.AllowDrop = true;
			this.txtLBudgetName.BackColor = System.Drawing.Color.White;
			this.txtLBudgetName.ForeColor = System.Drawing.Color.Black;
			this.txtLBudgetName.Location = new System.Drawing.Point(138, 99);
			this.txtLBudgetName.MaxLength = 50;
			this.txtLBudgetName.Name = "txtLBudgetName";
			this.txtLBudgetName.Size = new System.Drawing.Size(343, 19);
			this.txtLBudgetName.TabIndex = 1;
			this.txtLBudgetName.Text = "";
			// 
			// lblACategoryName
			// 
			this.lblACategoryName.AllowDrop = true;
			this.lblACategoryName.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblACategoryName.Text = "Budget Name (Arabic)";
			this.lblACategoryName.Location = new System.Drawing.Point(10, 123);
			this.lblACategoryName.Name = "lblACategoryName";
			this.lblACategoryName.Size = new System.Drawing.Size(107, 14);
			this.lblACategoryName.TabIndex = 11;
			// 
			// txtABudgetName
			// 
			this.txtABudgetName.AllowDrop = true;
			this.txtABudgetName.BackColor = System.Drawing.Color.White;
			this.txtABudgetName.ForeColor = System.Drawing.Color.Black;
			this.txtABudgetName.Location = new System.Drawing.Point(138, 120);
			// // = true;
			this.txtABudgetName.MaxLength = 50;
			this.txtABudgetName.Name = "txtABudgetName";
			this.txtABudgetName.Size = new System.Drawing.Size(343, 19);
			this.txtABudgetName.TabIndex = 2;
			this.txtABudgetName.Text = "";
			// 
			// System.Windows.Forms.Label2
			// 
			this.Label2.AllowDrop = true;
			this.Label2.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.Label2.Text = "End Date";
			this.Label2.Location = new System.Drawing.Point(10, 168);
			this.Label2.Name="Label2";
			this.Label2.Size = new System.Drawing.Size(44, 13);
			this.Label2.TabIndex = 12;
			// 
			// System.Windows.Forms.Label1
			// 
			this.Label1.AllowDrop = true;
			this.Label1.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.Label1.Text = "Start Date";
			this.Label1.Location = new System.Drawing.Point(10, 147);
			this.Label1.Name="Label1";
			this.Label1.Size = new System.Drawing.Size(50, 13);
			this.Label1.TabIndex = 13;
			// 
			// txtEndDate
			// 
			this.txtEndDate.AllowDrop = true;
			// this.txtEndDate.CheckDateRange = false;
			this.txtEndDate.Location = new System.Drawing.Point(137, 165);
			// this.txtEndDate.MaxDate = 2958465;
			// this.txtEndDate.MinDate = 2;
			this.txtEndDate.Name = "txtEndDate";
			this.txtEndDate.Size = new System.Drawing.Size(113, 19);
			this.txtEndDate.TabIndex = 4;
			// // this.txtEndDate.Text = "13/02/2012";
			// this.txtEndDate.Value = 40952;
			// 
			// txtStartDate
			// 
			this.txtStartDate.AllowDrop = true;
			// this.txtStartDate.CheckDateRange = false;
			this.txtStartDate.Location = new System.Drawing.Point(137, 144);
			// this.txtStartDate.MaxDate = 2958465;
			// this.txtStartDate.MinDate = 2;
			this.txtStartDate.Name = "txtStartDate";
			this.txtStartDate.Size = new System.Drawing.Size(113, 19);
			this.txtStartDate.TabIndex = 3;
			// // this.txtStartDate.Text = "01/01/2011";
			// this.txtStartDate.Value = 40544;
			// 
			// lblComments
			// 
			this.lblComments.AllowDrop = true;
			this.lblComments.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblComments.Text = "Comment";
			this.lblComments.Location = new System.Drawing.Point(10, 219);
			// // this.lblComments.mLabelId = 1851;
			this.lblComments.Name = "lblComments";
			this.lblComments.Size = new System.Drawing.Size(44, 14);
			this.lblComments.TabIndex = 14;
			// 
			// frmPayBudgetMaster
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.ClientSize = new System.Drawing.Size(499, 284);
			this.Controls.Add(this.cmdRefreshCategory);
			this.Controls.Add(this.cmdRefreshPayroll);
			this.Controls.Add(this.chkFreezed);
			this.Controls.Add(this.txtComments);
			this.Controls.Add(this.txtBudgetCode);
			this.Controls.Add(this.lblCategoryCode);
			this.Controls.Add(this.lblLCategoryName);
			this.Controls.Add(this.txtLBudgetName);
			this.Controls.Add(this.lblACategoryName);
			this.Controls.Add(this.txtABudgetName);
			this.Controls.Add(this.Label2);
			this.Controls.Add(this.Label1);
			this.Controls.Add(this.txtEndDate);
			this.Controls.Add(this.txtStartDate);
			this.Controls.Add(this.lblComments);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			//this.Icon = (System.Drawing.Icon) resources.GetObject("frmPayBudgetMaster.Icon");
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(290, 151);
			this.MaximizeBox = true;
			this.MinimizeBox = true;
			this.Name = "frmPayBudgetMaster";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Budget Master";
			// this.Activated += new System.EventHandler(this.frmPayBudgetMaster_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
			// this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
			this.ResumeLayout(false);
		}
		
		#endregion
	}
}//ENDSHERE
