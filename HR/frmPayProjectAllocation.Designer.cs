
namespace Xtreme
{
	partial class frmPayProjectAllocation
	{

		#region "Upgrade Support "
		private static frmPayProjectAllocation m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmPayProjectAllocation DefInstance
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
		public static frmPayProjectAllocation CreateInstance()
		{
			frmPayProjectAllocation theInstance = new frmPayProjectAllocation();
			
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
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "cmdPayroll", "txtAllocationFor", "lblSystemComponents", "_lblCommonLabel_2", "_lblCommonLabel_0", "_lblCommonLabel_1", "_lblCommonLabel_3", "_lblCommonLabel_9", "_txtDisplayLabel_4", "_txtDisplayLabel_5", "_txtDisplayLabel_3", "_txtDisplayLabel_2", "_txtDisplayLabel_0", "_txtDisplayLabel_1", "Column_0_cmbMastersList", "Column_1_cmbMastersList", "cmbMastersList", "Column_0_grdVoucherDetails", "Column_1_grdVoucherDetails", "grdVoucherDetails", "Column_0_grdTADetails", "Column_1_grdTADetails", "grdTADetails", "System.Windows.Forms.Label1", "_lblCommonLabel_4", "_txtDisplayLabel_6", "_txtDisplayLabel_7", "_lblCommonLabel_5", "Line2", "Line1", "lblCommonLabel", "txtDisplayLabel"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public System.Windows.Forms.Button cmdPayroll;
		public System.Windows.Forms.Label txtAllocationFor;
		public System.Windows.Forms.Label lblSystemComponents;
		private System.Windows.Forms.Label _lblCommonLabel_2;
		private System.Windows.Forms.Label _lblCommonLabel_0;
		private System.Windows.Forms.Label _lblCommonLabel_1;
		private System.Windows.Forms.Label _lblCommonLabel_3;
		private System.Windows.Forms.Label _lblCommonLabel_9;
		private System.Windows.Forms.Label _txtDisplayLabel_4;
		private System.Windows.Forms.Label _txtDisplayLabel_5;
		private System.Windows.Forms.Label _txtDisplayLabel_3;
		private System.Windows.Forms.Label _txtDisplayLabel_2;
		private System.Windows.Forms.Label _txtDisplayLabel_0;
		private System.Windows.Forms.Label _txtDisplayLabel_1;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_0_cmbMastersList;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_1_cmbMastersList;
		public C1.Win.C1TrueDBGrid.C1TrueDBDropdown cmbMastersList;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_0_grdVoucherDetails;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_1_grdVoucherDetails;
		public C1.Win.C1TrueDBGrid.C1TrueDBGrid grdVoucherDetails;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_0_grdTADetails;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_1_grdTADetails;
		public C1.Win.C1TrueDBGrid.C1TrueDBGrid grdTADetails;
		public System.Windows.Forms.Label Label1;
		private System.Windows.Forms.Label _lblCommonLabel_4;
		private System.Windows.Forms.Label _txtDisplayLabel_6;
		private System.Windows.Forms.Label _txtDisplayLabel_7;
		private System.Windows.Forms.Label _lblCommonLabel_5;
		public System.Windows.Forms.Label Line2;
		public System.Windows.Forms.Label Line1;
		public System.Windows.Forms.Label[] lblCommonLabel = new System.Windows.Forms.Label[10];
		public System.Windows.Forms.Label[] txtDisplayLabel = new System.Windows.Forms.Label[8];
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPayProjectAllocation));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this.cmdPayroll = new System.Windows.Forms.Button();
			this.txtAllocationFor = new System.Windows.Forms.Label();
			this.lblSystemComponents = new System.Windows.Forms.Label();
			this._lblCommonLabel_2 = new System.Windows.Forms.Label();
			this._lblCommonLabel_0 = new System.Windows.Forms.Label();
			this._lblCommonLabel_1 = new System.Windows.Forms.Label();
			this._lblCommonLabel_3 = new System.Windows.Forms.Label();
			this._lblCommonLabel_9 = new System.Windows.Forms.Label();
			this._txtDisplayLabel_4 = new System.Windows.Forms.Label();
			this._txtDisplayLabel_5 = new System.Windows.Forms.Label();
			this._txtDisplayLabel_3 = new System.Windows.Forms.Label();
			this._txtDisplayLabel_2 = new System.Windows.Forms.Label();
			this._txtDisplayLabel_0 = new System.Windows.Forms.Label();
			this._txtDisplayLabel_1 = new System.Windows.Forms.Label();
			this.cmbMastersList = new C1.Win.C1TrueDBGrid.C1TrueDBDropdown();
			this.Column_0_cmbMastersList = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.Column_1_cmbMastersList = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.grdVoucherDetails = new C1.Win.C1TrueDBGrid.C1TrueDBGrid();
			this.Column_0_grdVoucherDetails = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.Column_1_grdVoucherDetails = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.grdTADetails = new C1.Win.C1TrueDBGrid.C1TrueDBGrid();
			this.Column_0_grdTADetails = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.Column_1_grdTADetails = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.Label1 = new System.Windows.Forms.Label();
			this._lblCommonLabel_4 = new System.Windows.Forms.Label();
			this._txtDisplayLabel_6 = new System.Windows.Forms.Label();
			this._txtDisplayLabel_7 = new System.Windows.Forms.Label();
			this._lblCommonLabel_5 = new System.Windows.Forms.Label();
			this.Line2 = new System.Windows.Forms.Label();
			this.Line1 = new System.Windows.Forms.Label();
			//this.cmbMastersList.SuspendLayout();
			//this.grdVoucherDetails.SuspendLayout();
			//this.grdTADetails.SuspendLayout();
			this.SuspendLayout();
			// 
			// cmdPayroll
			// 
			this.cmdPayroll.AllowDrop = true;
			this.cmdPayroll.BackColor = System.Drawing.SystemColors.Control;
			this.cmdPayroll.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdPayroll.Location = new System.Drawing.Point(630, 294);
			this.cmdPayroll.Name = "cmdPayroll";
			this.cmdPayroll.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdPayroll.Size = new System.Drawing.Size(93, 23);
			this.cmdPayroll.TabIndex = 21;
			this.cmdPayroll.Text = "Payroll";
			this.cmdPayroll.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.cmdPayroll.UseVisualStyleBackColor = false;
			this.cmdPayroll.Visible = false;
			// this.cmdPayroll.Click += new System.EventHandler(this.cmdPayroll_Click);
			// 
			// txtAllocationFor
			// 
			this.txtAllocationFor.AllowDrop = true;
			this.txtAllocationFor.Enabled = false;
			this.txtAllocationFor.Location = new System.Drawing.Point(100, 300);
			this.txtAllocationFor.Name = "txtAllocationFor";
			this.txtAllocationFor.Size = new System.Drawing.Size(221, 19);
			this.txtAllocationFor.TabIndex = 3;
			this.txtAllocationFor.TabStop = false;
			// 
			// lblSystemComponents
			// 
			this.lblSystemComponents.AllowDrop = true;
			this.lblSystemComponents.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblSystemComponents.Text = "Project Allocation";
			this.lblSystemComponents.Location = new System.Drawing.Point(16, 276);
			this.lblSystemComponents.Name = "lblSystemComponents";
			this.lblSystemComponents.Size = new System.Drawing.Size(100, 13);
			this.lblSystemComponents.TabIndex = 0;
			// 
			// _lblCommonLabel_2
			// 
			this._lblCommonLabel_2.AllowDrop = true;
			this._lblCommonLabel_2.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_2.Text = "Employee Code";
			this._lblCommonLabel_2.Location = new System.Drawing.Point(20, 48);
			// // this._lblCommonLabel_2.mLabelId = 236;
			this._lblCommonLabel_2.Name = "_lblCommonLabel_2";
			this._lblCommonLabel_2.Size = new System.Drawing.Size(74, 14);
			this._lblCommonLabel_2.TabIndex = 4;
			// 
			// _lblCommonLabel_0
			// 
			this._lblCommonLabel_0.AllowDrop = true;
			this._lblCommonLabel_0.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_0.Text = "Month";
			this._lblCommonLabel_0.Location = new System.Drawing.Point(424, 49);
			// // this._lblCommonLabel_0.mLabelId = 1145;
			this._lblCommonLabel_0.Name = "_lblCommonLabel_0";
			this._lblCommonLabel_0.Size = new System.Drawing.Size(29, 14);
			this._lblCommonLabel_0.TabIndex = 5;
			// 
			// _lblCommonLabel_1
			// 
			this._lblCommonLabel_1.AllowDrop = true;
			this._lblCommonLabel_1.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_1.Text = "Year";
			this._lblCommonLabel_1.Location = new System.Drawing.Point(424, 69);
			// // this._lblCommonLabel_1.mLabelId = 1146;
			this._lblCommonLabel_1.Name = "_lblCommonLabel_1";
			this._lblCommonLabel_1.Size = new System.Drawing.Size(24, 14);
			this._lblCommonLabel_1.TabIndex = 6;
			// 
			// _lblCommonLabel_3
			// 
			this._lblCommonLabel_3.AllowDrop = true;
			this._lblCommonLabel_3.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_3.Text = "Basic Salary";
			this._lblCommonLabel_3.Location = new System.Drawing.Point(560, 48);
			// // this._lblCommonLabel_3.mLabelId = 1970;
			this._lblCommonLabel_3.Name = "_lblCommonLabel_3";
			this._lblCommonLabel_3.Size = new System.Drawing.Size(61, 14);
			this._lblCommonLabel_3.TabIndex = 7;
			// 
			// _lblCommonLabel_9
			// 
			this._lblCommonLabel_9.AllowDrop = true;
			this._lblCommonLabel_9.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_9.Text = "Leave Salary";
			this._lblCommonLabel_9.Location = new System.Drawing.Point(560, 68);
			// // this._lblCommonLabel_9.mLabelId = 1135;
			this._lblCommonLabel_9.Name = "_lblCommonLabel_9";
			this._lblCommonLabel_9.Size = new System.Drawing.Size(64, 14);
			this._lblCommonLabel_9.TabIndex = 8;
			// 
			// _txtDisplayLabel_4
			// 
			// //this._txtDisplayLabel_4.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
			this._txtDisplayLabel_4.AllowDrop = true;
			this._txtDisplayLabel_4.Location = new System.Drawing.Point(642, 46);
			this._txtDisplayLabel_4.Name = "_txtDisplayLabel_4";
			this._txtDisplayLabel_4.Size = new System.Drawing.Size(101, 19);
			this._txtDisplayLabel_4.TabIndex = 9;
			this._txtDisplayLabel_4.TabStop = false;
			// 
			// _txtDisplayLabel_5
			// 
			// //this._txtDisplayLabel_5.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
			this._txtDisplayLabel_5.AllowDrop = true;
			this._txtDisplayLabel_5.Location = new System.Drawing.Point(642, 66);
			this._txtDisplayLabel_5.Name = "_txtDisplayLabel_5";
			this._txtDisplayLabel_5.Size = new System.Drawing.Size(101, 19);
			this._txtDisplayLabel_5.TabIndex = 10;
			this._txtDisplayLabel_5.TabStop = false;
			// 
			// _txtDisplayLabel_3
			// 
			this._txtDisplayLabel_3.AllowDrop = true;
			this._txtDisplayLabel_3.Location = new System.Drawing.Point(460, 66);
			this._txtDisplayLabel_3.Name = "_txtDisplayLabel_3";
			this._txtDisplayLabel_3.Size = new System.Drawing.Size(55, 19);
			this._txtDisplayLabel_3.TabIndex = 11;
			this._txtDisplayLabel_3.TabStop = false;
			// 
			// _txtDisplayLabel_2
			// 
			this._txtDisplayLabel_2.AllowDrop = true;
			this._txtDisplayLabel_2.Location = new System.Drawing.Point(460, 46);
			this._txtDisplayLabel_2.Name = "_txtDisplayLabel_2";
			this._txtDisplayLabel_2.Size = new System.Drawing.Size(55, 19);
			this._txtDisplayLabel_2.TabIndex = 12;
			this._txtDisplayLabel_2.TabStop = false;
			// 
			// _txtDisplayLabel_0
			// 
			this._txtDisplayLabel_0.AllowDrop = true;
			this._txtDisplayLabel_0.Location = new System.Drawing.Point(114, 46);
			this._txtDisplayLabel_0.Name = "_txtDisplayLabel_0";
			this._txtDisplayLabel_0.Size = new System.Drawing.Size(101, 19);
			this._txtDisplayLabel_0.TabIndex = 13;
			this._txtDisplayLabel_0.TabStop = false;
			// 
			// _txtDisplayLabel_1
			// 
			this._txtDisplayLabel_1.AllowDrop = true;
			this._txtDisplayLabel_1.Location = new System.Drawing.Point(215, 46);
			this._txtDisplayLabel_1.Name = "_txtDisplayLabel_1";
			this._txtDisplayLabel_1.Size = new System.Drawing.Size(201, 19);
			this._txtDisplayLabel_1.TabIndex = 14;
			this._txtDisplayLabel_1.TabStop = false;
			// 
			// cmbMastersList
			// 
			this.cmbMastersList.AllowDrop = true;
			this.cmbMastersList.ColumnHeaders = true;
			this.cmbMastersList.Enabled = true;
			this.cmbMastersList.Location = new System.Drawing.Point(444, 340);
			this.cmbMastersList.Name = "cmbMastersList";
			this.cmbMastersList.Size = new System.Drawing.Size(53, 37);
			this.cmbMastersList.TabIndex = 15;
			this.cmbMastersList.Columns.Add(this.Column_0_cmbMastersList);
			this.cmbMastersList.Columns.Add(this.Column_1_cmbMastersList);
			// 
			// Column_0_cmbMastersList
			// 
			this.Column_0_cmbMastersList.DataField = "";
			this.Column_0_cmbMastersList.ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.Normal;
			// 
			// Column_1_cmbMastersList
			// 
			this.Column_1_cmbMastersList.DataField = "";
			this.Column_1_cmbMastersList.ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.Normal;
			// 
			// grdVoucherDetails
			// 
			this.grdVoucherDetails.AllowDrop = true;
			this.grdVoucherDetails.BackColor = System.Drawing.Color.Silver;
			this.grdVoucherDetails.CellTipsWidth = 0;
			this.grdVoucherDetails.Location = new System.Drawing.Point(4, 328);
			this.grdVoucherDetails.Name = "grdVoucherDetails";
			this.grdVoucherDetails.RowDivider.Color = System.Drawing.Color.Silver;
			this.grdVoucherDetails.Size = new System.Drawing.Size(743, 157);
			this.grdVoucherDetails.TabIndex = 2;
			this.grdVoucherDetails.Columns.Add(this.Column_0_grdVoucherDetails);
			this.grdVoucherDetails.Columns.Add(this.Column_1_grdVoucherDetails);
			this.grdVoucherDetails.AfterColUpdate += new C1.Win.C1TrueDBGrid.ColEventHandler(this.grdVoucherDetails_AfterColUpdate);
			this.grdVoucherDetails.BeforeColUpdate += new C1.Win.C1TrueDBGrid.BeforeColUpdateEventHandler(this.grdVoucherDetails_BeforeColUpdate);
			this.grdVoucherDetails.ButtonClick += new C1.Win.C1TrueDBGrid.ColEventHandler(this.grdVoucherDetails_ButtonClick);
			this.grdVoucherDetails.GotFocus += new System.EventHandler(this.grdVoucherDetails_GotFocus);
			this.grdVoucherDetails.RowColChange += new C1.Win.C1TrueDBGrid.RowColChangeEventHandler(this.grdVoucherDetails_RowColChange);
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
			// grdTADetails
			// 
			this.grdTADetails.AllowDrop = true;
			this.grdTADetails.BackColor = System.Drawing.Color.Silver;
			this.grdTADetails.CellTipsWidth = 0;
			this.grdTADetails.Location = new System.Drawing.Point(4, 108);
			this.grdTADetails.Name = "grdTADetails";
			this.grdTADetails.RowDivider.Color = System.Drawing.Color.Silver;
			this.grdTADetails.Size = new System.Drawing.Size(743, 163);
			this.grdTADetails.TabIndex = 1;
			this.grdTADetails.Columns.Add(this.Column_0_grdTADetails);
			this.grdTADetails.Columns.Add(this.Column_1_grdTADetails);
			this.grdTADetails.DoubleClick += new System.EventHandler(this.grdTADetails_DoubleClick);
			this.grdTADetails.RowColChange += new C1.Win.C1TrueDBGrid.RowColChangeEventHandler(this.grdTADetails_RowColChange);
			// 
			// Column_0_grdTADetails
			// 
			this.Column_0_grdTADetails.DataField = "";
			this.Column_0_grdTADetails.ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.Normal;
			// 
			// Column_1_grdTADetails
			// 
			this.Column_1_grdTADetails.DataField = "";
			this.Column_1_grdTADetails.ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.Normal;
			// 
			// System.Windows.Forms.Label1
			// 
			this.Label1.AllowDrop = true;
			this.Label1.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.Label1.Text = "Payroll Details";
			this.Label1.Location = new System.Drawing.Point(16, 86);
			this.Label1.Name="Label1";
			this.Label1.Size = new System.Drawing.Size(81, 13);
			this.Label1.TabIndex = 16;
			// 
			// _lblCommonLabel_4
			// 
			this._lblCommonLabel_4.AllowDrop = true;
			this._lblCommonLabel_4.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_4.Text = "Allocation For";
			this._lblCommonLabel_4.Location = new System.Drawing.Point(16, 303);
			this._lblCommonLabel_4.Name = "_lblCommonLabel_4";
			this._lblCommonLabel_4.Size = new System.Drawing.Size(66, 14);
			this._lblCommonLabel_4.TabIndex = 17;
			// 
			// _txtDisplayLabel_6
			// 
			this._txtDisplayLabel_6.AllowDrop = true;
			this._txtDisplayLabel_6.Location = new System.Drawing.Point(112, 67);
			this._txtDisplayLabel_6.Name = "_txtDisplayLabel_6";
			this._txtDisplayLabel_6.Size = new System.Drawing.Size(101, 19);
			this._txtDisplayLabel_6.TabIndex = 18;
			this._txtDisplayLabel_6.TabStop = false;
			// 
			// _txtDisplayLabel_7
			// 
			this._txtDisplayLabel_7.AllowDrop = true;
			this._txtDisplayLabel_7.Location = new System.Drawing.Point(215, 67);
			this._txtDisplayLabel_7.Name = "_txtDisplayLabel_7";
			this._txtDisplayLabel_7.Size = new System.Drawing.Size(201, 19);
			this._txtDisplayLabel_7.TabIndex = 19;
			this._txtDisplayLabel_7.TabStop = false;
			// 
			// _lblCommonLabel_5
			// 
			this._lblCommonLabel_5.AllowDrop = true;
			this._lblCommonLabel_5.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_5.Text = "Department Code";
			this._lblCommonLabel_5.Location = new System.Drawing.Point(20, 69);
			// // this._lblCommonLabel_5.mLabelId = 1973;
			this._lblCommonLabel_5.Name = "_lblCommonLabel_5";
			this._lblCommonLabel_5.Size = new System.Drawing.Size(83, 14);
			this._lblCommonLabel_5.TabIndex = 20;
			// 
			// Line2
			// 
			this.Line2.AllowDrop = true;
			this.Line2.BackColor = System.Drawing.SystemColors.WindowText;
			this.Line2.Enabled = false;
			this.Line2.Location = new System.Drawing.Point(0, 94);
			this.Line2.Name = "Line2";
			this.Line2.Size = new System.Drawing.Size(748, 1);
			this.Line2.Visible = true;
			// 
			// Line1
			// 
			this.Line1.AllowDrop = true;
			this.Line1.BackColor = System.Drawing.SystemColors.WindowText;
			this.Line1.Enabled = false;
			this.Line1.Location = new System.Drawing.Point(1, 282);
			this.Line1.Name = "Line1";
			this.Line1.Size = new System.Drawing.Size(748, 1);
			this.Line1.Visible = true;
			// 
			// frmPayProjectAllocation
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.ClientSize = new System.Drawing.Size(751, 488);
			this.Controls.Add(this.cmdPayroll);
			this.Controls.Add(this.txtAllocationFor);
			this.Controls.Add(this.lblSystemComponents);
			this.Controls.Add(this._lblCommonLabel_2);
			this.Controls.Add(this._lblCommonLabel_0);
			this.Controls.Add(this._lblCommonLabel_1);
			this.Controls.Add(this._lblCommonLabel_3);
			this.Controls.Add(this._lblCommonLabel_9);
			this.Controls.Add(this._txtDisplayLabel_4);
			this.Controls.Add(this._txtDisplayLabel_5);
			this.Controls.Add(this._txtDisplayLabel_3);
			this.Controls.Add(this._txtDisplayLabel_2);
			this.Controls.Add(this._txtDisplayLabel_0);
			this.Controls.Add(this._txtDisplayLabel_1);
			this.Controls.Add(this.cmbMastersList);
			this.Controls.Add(this.grdVoucherDetails);
			this.Controls.Add(this.grdTADetails);
			this.Controls.Add(this.Label1);
			this.Controls.Add(this._lblCommonLabel_4);
			this.Controls.Add(this._txtDisplayLabel_6);
			this.Controls.Add(this._txtDisplayLabel_7);
			this.Controls.Add(this._lblCommonLabel_5);
			this.Controls.Add(this.Line2);
			this.Controls.Add(this.Line1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			//this.Icon = (System.Drawing.Icon) resources.GetObject("frmPayProjectAllocation.Icon");
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(178, 162);
			this.MaximizeBox = true;
			this.MinimizeBox = true;
			this.Name = "frmPayProjectAllocation";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Tag = "\"H: 6225  W:9570\"";
			this.Text = "Project Allocation";
			// this.Activated += new System.EventHandler(this.frmPayProjectAllocation_Activated);
			base.Closing += new System.ComponentModel.CancelEventHandler(this.Form_Closed);
			// this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
			this.cmbMastersList.ResumeLayout(false);
			this.grdVoucherDetails.ResumeLayout(false);
			this.grdTADetails.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		// 
		void InitializetxtDisplayLabel()
		{
			this.txtDisplayLabel = new System.Windows.Forms.Label[8];
			this.txtDisplayLabel[4] = _txtDisplayLabel_4;
			this.txtDisplayLabel[5] = _txtDisplayLabel_5;
			this.txtDisplayLabel[3] = _txtDisplayLabel_3;
			this.txtDisplayLabel[2] = _txtDisplayLabel_2;
			this.txtDisplayLabel[0] = _txtDisplayLabel_0;
			this.txtDisplayLabel[1] = _txtDisplayLabel_1;
			this.txtDisplayLabel[6] = _txtDisplayLabel_6;
			this.txtDisplayLabel[7] = _txtDisplayLabel_7;
		}
		void InitializelblCommonLabel()
		{
			this.lblCommonLabel = new System.Windows.Forms.Label[10];
			this.lblCommonLabel[2] = _lblCommonLabel_2;
			this.lblCommonLabel[0] = _lblCommonLabel_0;
			this.lblCommonLabel[1] = _lblCommonLabel_1;
			this.lblCommonLabel[3] = _lblCommonLabel_3;
			this.lblCommonLabel[9] = _lblCommonLabel_9;
			this.lblCommonLabel[4] = _lblCommonLabel_4;
			this.lblCommonLabel[5] = _lblCommonLabel_5;
		}
		#endregion
	}
}//ENDSHERE
