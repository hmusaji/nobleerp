
namespace Xtreme
{
	partial class frmGLRateAdjustment
	{

		#region "Upgrade Support "
		private static frmGLRateAdjustment m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmGLRateAdjustment DefInstance
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
		public static frmGLRateAdjustment CreateInstance()
		{
			frmGLRateAdjustment theInstance = new frmGLRateAdjustment();
			
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
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "_lblCommonLabel_0", "cmdAdjust", "_fraCommon_0", "Column_0_grdAdjustmentDetails", "grdAdjustmentDetails", "Column_0_grdAccountSelect", "Column_1_grdAccountSelect", "grdAccountSelect", "_lblCommonLabel_1", "_txtCommonTextBox_1", "_lblCommonLabel_21", "txtAdjustmentDate", "_lblCommonLabel_6", "_lblCommonLabel_5", "txtAdjustmentNo", "txtComments", "_lblCommonLabel_9", "_lblCommonLabel_2", "Column_0_grdRateAdjustment", "grdRateAdjustment", "_txtDisplayLabel_1", "_txtCommonTextBox_2", "_lblCommonLabel_3", "_txtDisplayLabel_2", "tcbSystemForm", "Shape1", "fraCommon", "lblCommonLabel", "txtCommonTextBox", "txtDisplayLabel"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		private System.Windows.Forms.Label _lblCommonLabel_0;
		public System.Windows.Forms.Button cmdAdjust;
		private System.Windows.Forms.GroupBox _fraCommon_0;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_0_grdAdjustmentDetails;
		public C1.Win.C1TrueDBGrid.C1TrueDBGrid grdAdjustmentDetails;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_0_grdAccountSelect;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_1_grdAccountSelect;
		public C1.Win.C1TrueDBGrid.C1TrueDBGrid grdAccountSelect;
		private System.Windows.Forms.Label _lblCommonLabel_1;
		private System.Windows.Forms.TextBox _txtCommonTextBox_1;
		private System.Windows.Forms.Label _lblCommonLabel_21;
		public Syncfusion.WinForms.Input.SfDateTimeEdit txtAdjustmentDate;
		private System.Windows.Forms.Label _lblCommonLabel_6;
		private System.Windows.Forms.Label _lblCommonLabel_5;
		public System.Windows.Forms.TextBox txtAdjustmentNo;
		public System.Windows.Forms.TextBox txtComments;
		private System.Windows.Forms.Label _lblCommonLabel_9;
		private System.Windows.Forms.Label _lblCommonLabel_2;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_0_grdRateAdjustment;
		public C1.Win.C1TrueDBGrid.C1TrueDBGrid grdRateAdjustment;
		private System.Windows.Forms.Label _txtDisplayLabel_1;
		private System.Windows.Forms.TextBox _txtCommonTextBox_2;
		private System.Windows.Forms.Label _lblCommonLabel_3;
		private System.Windows.Forms.Label _txtDisplayLabel_2;
		public Syncfusion.Windows.Forms.Tools.CommandBarController tcbSystemForm;
		public UpgradeHelpers.Gui.ShapeHelper Shape1;
		public System.Windows.Forms.GroupBox[] fraCommon = new System.Windows.Forms.GroupBox[1];
		public System.Windows.Forms.Label[] lblCommonLabel = new System.Windows.Forms.Label[22];
		public System.Windows.Forms.TextBox[] txtCommonTextBox = new System.Windows.Forms.TextBox[3];
		public System.Windows.Forms.Label[] txtDisplayLabel = new System.Windows.Forms.Label[3];
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGLRateAdjustment));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this._lblCommonLabel_0 = new System.Windows.Forms.Label();
			this._fraCommon_0 = new System.Windows.Forms.GroupBox();
			this.cmdAdjust = new System.Windows.Forms.Button();
			this.grdAdjustmentDetails = new C1.Win.C1TrueDBGrid.C1TrueDBGrid();
			this.Column_0_grdAdjustmentDetails = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.grdAccountSelect = new C1.Win.C1TrueDBGrid.C1TrueDBGrid();
			this.Column_0_grdAccountSelect = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.Column_1_grdAccountSelect = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this._lblCommonLabel_1 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_1 = new System.Windows.Forms.TextBox();
			this._lblCommonLabel_21 = new System.Windows.Forms.Label();
			this.txtAdjustmentDate = new Syncfusion.WinForms.Input.SfDateTimeEdit();
			this._lblCommonLabel_6 = new System.Windows.Forms.Label();
			this._lblCommonLabel_5 = new System.Windows.Forms.Label();
			this.txtAdjustmentNo = new System.Windows.Forms.TextBox();
			this.txtComments = new System.Windows.Forms.TextBox();
			this._lblCommonLabel_9 = new System.Windows.Forms.Label();
			this._lblCommonLabel_2 = new System.Windows.Forms.Label();
			this.grdRateAdjustment = new C1.Win.C1TrueDBGrid.C1TrueDBGrid();
			this.Column_0_grdRateAdjustment = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this._txtDisplayLabel_1 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_2 = new System.Windows.Forms.TextBox();
			this._lblCommonLabel_3 = new System.Windows.Forms.Label();
			this._txtDisplayLabel_2 = new System.Windows.Forms.Label();
			this.tcbSystemForm = new Syncfusion.Windows.Forms.Tools.CommandBarController();
			this.Shape1 = new UpgradeHelpers.Gui.ShapeHelper();
			// //((System.ComponentModel.ISupportInitialize) this.tcbSystemForm).BeginInit();
			this._fraCommon_0.SuspendLayout();
			this.grdAdjustmentDetails.SuspendLayout();
			this.grdAccountSelect.SuspendLayout();
			this.grdRateAdjustment.SuspendLayout();
			this.SuspendLayout();
			// 
			// _lblCommonLabel_0
			// 
			this._lblCommonLabel_0.AllowDrop = true;
			this._lblCommonLabel_0.BackColor = System.Drawing.SystemColors.Window;
			this._lblCommonLabel_0.Text = " Adjustment Details :  ";
			this._lblCommonLabel_0.ForeColor = System.Drawing.Color.Black;
			this._lblCommonLabel_0.Location = new System.Drawing.Point(3, 347);
			// // this._lblCommonLabel_0.mLabelId = 1879;
			this._lblCommonLabel_0.Name = "_lblCommonLabel_0";
			this._lblCommonLabel_0.Size = new System.Drawing.Size(106, 13);
			this._lblCommonLabel_0.TabIndex = 9;
			// 
			// _fraCommon_0
			// 
			this._fraCommon_0.AllowDrop = true;
			this._fraCommon_0.BackColor = System.Drawing.Color.FromArgb(208, 217, 208);
			this._fraCommon_0.Controls.Add(this.cmdAdjust);
			this._fraCommon_0.Enabled = true;
			this._fraCommon_0.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Italic | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 178);
			this._fraCommon_0.ForeColor = System.Drawing.SystemColors.WindowText;
			this._fraCommon_0.Location = new System.Drawing.Point(655, 224);
			this._fraCommon_0.Name = "_fraCommon_0";
			this._fraCommon_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._fraCommon_0.Size = new System.Drawing.Size(100, 35);
			this._fraCommon_0.TabIndex = 8;
			this._fraCommon_0.Visible = true;
			// 
			// cmdAdjust
			// 
			this.cmdAdjust.AllowDrop = true;
			this.cmdAdjust.BackColor = System.Drawing.SystemColors.Control;
			this.cmdAdjust.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdAdjust.Location = new System.Drawing.Point(11, 10);
			this.cmdAdjust.Name = "cmdAdjust";
			this.cmdAdjust.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdAdjust.Size = new System.Drawing.Size(77, 19);
			this.cmdAdjust.TabIndex = 7;
			this.cmdAdjust.Text = "A d j u s t";
			this.cmdAdjust.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.cmdAdjust.UseVisualStyleBackColor = false;
			// this.cmdAdjust.Click += new System.EventHandler(this.cmdAdjust_Click);
			// 
			// grdAdjustmentDetails
			// 
			this.grdAdjustmentDetails.AllowDrop = true;
			this.grdAdjustmentDetails.BackColor = System.Drawing.Color.FromArgb(212, 208, 200);
			this.grdAdjustmentDetails.CellTipsWidth = 0;
			this.grdAdjustmentDetails.Location = new System.Drawing.Point(0, 360);
			this.grdAdjustmentDetails.Name = "grdAdjustmentDetails";
			this.grdAdjustmentDetails.RowDivider.Color = System.Drawing.Color.FromArgb(212, 208, 200);
			this.grdAdjustmentDetails.Size = new System.Drawing.Size(758, 119);
			this.grdAdjustmentDetails.TabIndex = 6;
			this.grdAdjustmentDetails.Columns.Add(this.Column_0_grdAdjustmentDetails);
			// 
			// Column_0_grdAdjustmentDetails
			// 
			this.Column_0_grdAdjustmentDetails.DataField = "";
			this.Column_0_grdAdjustmentDetails.ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.Normal;
			// 
			// grdAccountSelect
			// 
			this.grdAccountSelect.AllowDrop = true;
			this.grdAccountSelect.BackColor = System.Drawing.Color.Silver;
			this.grdAccountSelect.CellTipsWidth = 0;
			this.grdAccountSelect.Location = new System.Drawing.Point(0, 150);
			this.grdAccountSelect.Name = "grdAccountSelect";
			this.grdAccountSelect.RowDivider.Color = System.Drawing.Color.Silver;
			this.grdAccountSelect.Size = new System.Drawing.Size(653, 109);
			this.grdAccountSelect.TabIndex = 4;
			this.grdAccountSelect.Columns.Add(this.Column_0_grdAccountSelect);
			this.grdAccountSelect.Columns.Add(this.Column_1_grdAccountSelect);
			// 
			// Column_0_grdAccountSelect
			// 
			this.Column_0_grdAccountSelect.DataField = "";
			this.Column_0_grdAccountSelect.ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.Normal;
			// 
			// Column_1_grdAccountSelect
			// 
			this.Column_1_grdAccountSelect.DataField = "";
			this.Column_1_grdAccountSelect.ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.Normal;
			// 
			// _lblCommonLabel_1
			// 
			this._lblCommonLabel_1.AllowDrop = true;
			this._lblCommonLabel_1.BackColor = System.Drawing.SystemColors.Window;
			this._lblCommonLabel_1.Text = " Account Select : ";
			this._lblCommonLabel_1.ForeColor = System.Drawing.Color.Black;
			this._lblCommonLabel_1.Location = new System.Drawing.Point(2, 136);
			// // this._lblCommonLabel_1.mLabelId = 1877;
			this._lblCommonLabel_1.Name = "_lblCommonLabel_1";
			this._lblCommonLabel_1.Size = new System.Drawing.Size(84, 13);
			this._lblCommonLabel_1.TabIndex = 10;
			// 
			// _txtCommonTextBox_1
			// 
			this._txtCommonTextBox_1.AllowDrop = true;
			this._txtCommonTextBox_1.BackColor = System.Drawing.Color.White;
			// this._txtCommonTextBox_1.bolNumericOnly = true;
			this._txtCommonTextBox_1.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_1.Location = new System.Drawing.Point(330, 53);
			this._txtCommonTextBox_1.Name = "_txtCommonTextBox_1";
			// this._txtCommonTextBox_1.ShowButton = true;
			this._txtCommonTextBox_1.Size = new System.Drawing.Size(101, 19);
			this._txtCommonTextBox_1.TabIndex = 0;
			this._txtCommonTextBox_1.Text = "";
			// this.this._txtCommonTextBox_1.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_1.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _lblCommonLabel_21
			// 
			this._lblCommonLabel_21.AllowDrop = true;
			this._lblCommonLabel_21.BackColor = System.Drawing.SystemColors.Window;
			this._lblCommonLabel_21.Text = "Voucher Type";
			this._lblCommonLabel_21.ForeColor = System.Drawing.Color.Black;
			this._lblCommonLabel_21.Location = new System.Drawing.Point(245, 55);
			// // this._lblCommonLabel_21.mLabelId = 851;
			this._lblCommonLabel_21.Name = "_lblCommonLabel_21";
			this._lblCommonLabel_21.Size = new System.Drawing.Size(69, 14);
			this._lblCommonLabel_21.TabIndex = 11;
			// 
			// txtAdjustmentDate
			// 
			this.txtAdjustmentDate.AllowDrop = true;
			// this.txtAdjustmentDate.CheckDateRange = false;
			this.txtAdjustmentDate.Location = new System.Drawing.Point(101, 74);
			// this.txtAdjustmentDate.MaxDate = 2958465;
			// this.txtAdjustmentDate.MinDate = 32874;
			this.txtAdjustmentDate.Name = "txtAdjustmentDate";
			this.txtAdjustmentDate.Size = new System.Drawing.Size(102, 19);
			this.txtAdjustmentDate.TabIndex = 1;
			// this.txtAdjustmentDate.Text = "7/18/2001";
			// this.txtAdjustmentDate.Value = 37090;
			// 
			// _lblCommonLabel_6
			// 
			this._lblCommonLabel_6.AllowDrop = true;
			this._lblCommonLabel_6.BackColor = System.Drawing.SystemColors.Window;
			this._lblCommonLabel_6.Text = "Adjustment Date";
			this._lblCommonLabel_6.ForeColor = System.Drawing.Color.Black;
			this._lblCommonLabel_6.Location = new System.Drawing.Point(11, 76);
			// // this._lblCommonLabel_6.mLabelId = 848;
			this._lblCommonLabel_6.Name = "_lblCommonLabel_6";
			this._lblCommonLabel_6.Size = new System.Drawing.Size(79, 14);
			this._lblCommonLabel_6.TabIndex = 12;
			// 
			// _lblCommonLabel_5
			// 
			this._lblCommonLabel_5.AllowDrop = true;
			this._lblCommonLabel_5.BackColor = System.Drawing.SystemColors.Window;
			this._lblCommonLabel_5.Text = "Adjustment No.";
			this._lblCommonLabel_5.ForeColor = System.Drawing.Color.Black;
			this._lblCommonLabel_5.Location = new System.Drawing.Point(11, 55);
			// // this._lblCommonLabel_5.mLabelId = 850;
			this._lblCommonLabel_5.Name = "_lblCommonLabel_5";
			this._lblCommonLabel_5.Size = new System.Drawing.Size(73, 14);
			this._lblCommonLabel_5.TabIndex = 13;
			// 
			// txtAdjustmentNo
			// 
			this.txtAdjustmentNo.AllowDrop = true;
			this.txtAdjustmentNo.BackColor = System.Drawing.Color.FromArgb(239, 239, 239);
			// this.txtAdjustmentNo.bolNumericOnly = true;
			this.txtAdjustmentNo.Enabled = false;
			this.txtAdjustmentNo.ForeColor = System.Drawing.Color.Black;
			this.txtAdjustmentNo.Location = new System.Drawing.Point(101, 53);
			this.txtAdjustmentNo.Name = "txtAdjustmentNo";
			this.txtAdjustmentNo.Size = new System.Drawing.Size(102, 19);
			this.txtAdjustmentNo.TabIndex = 14;
			this.txtAdjustmentNo.Text = "";
			// 
			// txtComments
			// 
			this.txtComments.AllowDrop = true;
			this.txtComments.BackColor = System.Drawing.Color.White;
			this.txtComments.ForeColor = System.Drawing.Color.Black;
			this.txtComments.Location = new System.Drawing.Point(101, 95);
			this.txtComments.MaxLength = 200;
			this.txtComments.Name = "txtComments";
			this.txtComments.Size = new System.Drawing.Size(534, 19);
			this.txtComments.TabIndex = 3;
			this.txtComments.Text = "";
			// 
			// _lblCommonLabel_9
			// 
			this._lblCommonLabel_9.AllowDrop = true;
			this._lblCommonLabel_9.BackColor = System.Drawing.SystemColors.Window;
			this._lblCommonLabel_9.Text = "Comments";
			this._lblCommonLabel_9.ForeColor = System.Drawing.Color.Black;
			this._lblCommonLabel_9.Location = new System.Drawing.Point(10, 98);
			// // this._lblCommonLabel_9.mLabelId = 869;
			this._lblCommonLabel_9.Name = "_lblCommonLabel_9";
			this._lblCommonLabel_9.Size = new System.Drawing.Size(50, 13);
			this._lblCommonLabel_9.TabIndex = 15;
			// 
			// _lblCommonLabel_2
			// 
			this._lblCommonLabel_2.AllowDrop = true;
			this._lblCommonLabel_2.BackColor = System.Drawing.SystemColors.Window;
			this._lblCommonLabel_2.Text = " Currency Rate Adjustment : ";
			this._lblCommonLabel_2.ForeColor = System.Drawing.Color.Black;
			this._lblCommonLabel_2.Location = new System.Drawing.Point(2, 268);
			// // this._lblCommonLabel_2.mLabelId = 1878;
			this._lblCommonLabel_2.Name = "_lblCommonLabel_2";
			this._lblCommonLabel_2.Size = new System.Drawing.Size(141, 13);
			this._lblCommonLabel_2.TabIndex = 16;
			// 
			// grdRateAdjustment
			// 
			this.grdRateAdjustment.AllowDrop = true;
			this.grdRateAdjustment.BackColor = System.Drawing.Color.FromArgb(212, 208, 200);
			this.grdRateAdjustment.CellTipsWidth = 0;
			this.grdRateAdjustment.Location = new System.Drawing.Point(0, 281);
			this.grdRateAdjustment.Name = "grdRateAdjustment";
			this.grdRateAdjustment.RowDivider.Color = System.Drawing.Color.FromArgb(212, 208, 200);
			this.grdRateAdjustment.Size = new System.Drawing.Size(758, 59);
			this.grdRateAdjustment.TabIndex = 5;
			this.grdRateAdjustment.Columns.Add(this.Column_0_grdRateAdjustment);
			// 
			// Column_0_grdRateAdjustment
			// 
			this.Column_0_grdRateAdjustment.DataField = "";
			this.Column_0_grdRateAdjustment.ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.Normal;
			// 
			// _txtDisplayLabel_1
			// 
			this._txtDisplayLabel_1.AllowDrop = true;
			this._txtDisplayLabel_1.Enabled = false;
			this._txtDisplayLabel_1.Location = new System.Drawing.Point(433, 53);
			this._txtDisplayLabel_1.Name = "_txtDisplayLabel_1";
			this._txtDisplayLabel_1.Size = new System.Drawing.Size(202, 19);
			this._txtDisplayLabel_1.TabIndex = 17;
			// 
			// _txtCommonTextBox_2
			// 
			this._txtCommonTextBox_2.AllowDrop = true;
			this._txtCommonTextBox_2.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_2.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_2.Location = new System.Drawing.Point(330, 74);
			this._txtCommonTextBox_2.Name = "_txtCommonTextBox_2";
			// this._txtCommonTextBox_2.ShowButton = true;
			this._txtCommonTextBox_2.Size = new System.Drawing.Size(101, 19);
			this._txtCommonTextBox_2.TabIndex = 2;
			this._txtCommonTextBox_2.Text = "";
			// this.this._txtCommonTextBox_2.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_2.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _lblCommonLabel_3
			// 
			this._lblCommonLabel_3.AllowDrop = true;
			this._lblCommonLabel_3.BackColor = System.Drawing.SystemColors.Window;
			this._lblCommonLabel_3.Text = "Adjustment Code";
			this._lblCommonLabel_3.ForeColor = System.Drawing.Color.Black;
			this._lblCommonLabel_3.Location = new System.Drawing.Point(245, 76);
			// // this._lblCommonLabel_3.mLabelId = 1875;
			this._lblCommonLabel_3.Name = "_lblCommonLabel_3";
			this._lblCommonLabel_3.Size = new System.Drawing.Size(82, 14);
			this._lblCommonLabel_3.TabIndex = 18;
			// 
			// _txtDisplayLabel_2
			// 
			this._txtDisplayLabel_2.AllowDrop = true;
			this._txtDisplayLabel_2.Enabled = false;
			this._txtDisplayLabel_2.Location = new System.Drawing.Point(433, 74);
			this._txtDisplayLabel_2.Name = "_txtDisplayLabel_2";
			this._txtDisplayLabel_2.Size = new System.Drawing.Size(202, 19);
			this._txtDisplayLabel_2.TabIndex = 19;
			// 
			// tcbSystemForm
			// 
			this.tcbSystemForm.AllowDrop = true;
			this.tcbSystemForm.Location = new System.Drawing.Point(0, 0);
			this.tcbSystemForm.Name = "tcbSystemForm";
			("tcbSystemForm.OcxState");
			// 
			// Shape1
			// 
			this.Shape1.AllowDrop = true;
			this.Shape1.BackColor = System.Drawing.Color.FromArgb(208, 217, 208);
			this.Shape1.BackStyle = 1;
			this.Shape1.BorderStyle = 1;
			this.Shape1.Enabled = false;
			this.Shape1.FillColor = System.Drawing.Color.Black;
			this.Shape1.FillStyle = 1;
			this.Shape1.Location = new System.Drawing.Point(3, 45);
			this.Shape1.Name = "Shape1";
			this.Shape1.Size = new System.Drawing.Size(752, 80);
			this.Shape1.Visible = true;
			// 
			// frmGLRateAdjustment
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.FromArgb(208, 217, 208);
			this.ClientSize = new System.Drawing.Size(758, 483);
			this.Controls.Add(this._lblCommonLabel_0);
			this.Controls.Add(this._fraCommon_0);
			this.Controls.Add(this.grdAdjustmentDetails);
			this.Controls.Add(this.grdAccountSelect);
			this.Controls.Add(this._lblCommonLabel_1);
			this.Controls.Add(this._txtCommonTextBox_1);
			this.Controls.Add(this._lblCommonLabel_21);
			this.Controls.Add(this.txtAdjustmentDate);
			this.Controls.Add(this._lblCommonLabel_6);
			this.Controls.Add(this._lblCommonLabel_5);
			this.Controls.Add(this.txtAdjustmentNo);
			this.Controls.Add(this.txtComments);
			this.Controls.Add(this._lblCommonLabel_9);
			this.Controls.Add(this._lblCommonLabel_2);
			this.Controls.Add(this.grdRateAdjustment);
			this.Controls.Add(this._txtDisplayLabel_1);
			this.Controls.Add(this._txtCommonTextBox_2);
			this.Controls.Add(this._lblCommonLabel_3);
			this.Controls.Add(this._txtDisplayLabel_2);
			this.Controls.Add(this.tcbSystemForm);
			this.Controls.Add(this.Shape1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			//this.Icon = (System.Drawing.Icon) resources.GetObject("frmGLRateAdjustment.Icon");
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(25, 74);
			this.MaximizeBox = false;
			this.MinimizeBox = true;
			this.Name = "frmGLRateAdjustment";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Tag = "\"H: 6225  W:9570\"";
			this.Text = "Exchange Rate Adjustment";
			// this.Activated += new System.EventHandler(this.frmGLRateAdjustment_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
			// this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
			//((System.ComponentModel.ISupportInitialize) this.tcbSystemForm).EndInit();
			this._fraCommon_0.ResumeLayout(false);
			this.grdAdjustmentDetails.ResumeLayout(false);
			this.grdAccountSelect.ResumeLayout(false);
			this.grdRateAdjustment.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		// 
		void InitializetxtDisplayLabel()
		{
			this.txtDisplayLabel = new System.Windows.Forms.Label[3];
			this.txtDisplayLabel[1] = _txtDisplayLabel_1;
			this.txtDisplayLabel[2] = _txtDisplayLabel_2;
		}
		void InitializetxtCommonTextBox()
		{
			this.txtCommonTextBox = new System.Windows.Forms.TextBox[3];
			this.txtCommonTextBox[1] = _txtCommonTextBox_1;
			this.txtCommonTextBox[2] = _txtCommonTextBox_2;
		}
		void InitializelblCommonLabel()
		{
			this.lblCommonLabel = new System.Windows.Forms.Label[22];
			this.lblCommonLabel[0] = _lblCommonLabel_0;
			this.lblCommonLabel[1] = _lblCommonLabel_1;
			this.lblCommonLabel[21] = _lblCommonLabel_21;
			this.lblCommonLabel[6] = _lblCommonLabel_6;
			this.lblCommonLabel[5] = _lblCommonLabel_5;
			this.lblCommonLabel[9] = _lblCommonLabel_9;
			this.lblCommonLabel[2] = _lblCommonLabel_2;
			this.lblCommonLabel[3] = _lblCommonLabel_3;
		}
		void InitializefraCommon()
		{
			this.fraCommon = new System.Windows.Forms.GroupBox[1];
			this.fraCommon[0] = _fraCommon_0;
		}
		#endregion
	}
}//ENDSHERE
