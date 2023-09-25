
namespace Xtreme
{
	partial class frmPayGlobalSalaryVariation
	{

		#region "Upgrade Support "
		private static frmPayGlobalSalaryVariation m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmPayGlobalSalaryVariation DefInstance
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
		public static frmPayGlobalSalaryVariation CreateInstance()
		{
			frmPayGlobalSalaryVariation theInstance = new frmPayGlobalSalaryVariation();
			
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
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "chkMissingEmpBilling", "_lblCommon_113", "_lblCommonLabel_5", "_lblCommonLabel_6", "txtTransDate", "_txtDisplayLabel_0", "_lblCommon_0", "_lblCommonLabel_0", "_txtDisplayLabel_1", "_txtDisplayLabel_2", "_txtCommonTextBox_1", "_txtCommonTextBox_0", "_txtCommonTextBox_2", "_lblCommonLabel_1", "_txtDisplayLabel_3", "_txtCommonTextBox_3", "_txtCommonTextBox_4", "Column_0_cmbMastersList", "Column_1_cmbMastersList", "cmbMastersList", "Column_0_grdBillingDetails", "Column_1_grdBillingDetails", "grdBillingDetails", "_lblCommonLabel_3", "_txtCommonTextBox_5", "_lblCommonLabel_2", "Line1", "lblCommon", "lblCommonLabel", "txtCommonTextBox", "txtDisplayLabel"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public System.Windows.Forms.CheckBox chkMissingEmpBilling;
		private System.Windows.Forms.Label _lblCommon_113;
		private System.Windows.Forms.Label _lblCommonLabel_5;
		private System.Windows.Forms.Label _lblCommonLabel_6;
		public Syncfusion.WinForms.Input.SfDateTimeEdit txtTransDate;
		private System.Windows.Forms.Label _txtDisplayLabel_0;
		private System.Windows.Forms.Label _lblCommon_0;
		private System.Windows.Forms.Label _lblCommonLabel_0;
		private System.Windows.Forms.Label _txtDisplayLabel_1;
		private System.Windows.Forms.Label _txtDisplayLabel_2;
		private System.Windows.Forms.TextBox _txtCommonTextBox_1;
		private System.Windows.Forms.TextBox _txtCommonTextBox_0;
		private System.Windows.Forms.TextBox _txtCommonTextBox_2;
		private System.Windows.Forms.Label _lblCommonLabel_1;
		private System.Windows.Forms.Label _txtDisplayLabel_3;
		private System.Windows.Forms.TextBox _txtCommonTextBox_3;
		private System.Windows.Forms.TextBox _txtCommonTextBox_4;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_0_cmbMastersList;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_1_cmbMastersList;
		public C1.Win.C1TrueDBGrid.C1TrueDBDropdown cmbMastersList;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_0_grdBillingDetails;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_1_grdBillingDetails;
		public C1.Win.C1TrueDBGrid.C1TrueDBGrid grdBillingDetails;
		private System.Windows.Forms.Label _lblCommonLabel_3;
		private System.Windows.Forms.TextBox _txtCommonTextBox_5;
		private System.Windows.Forms.Label _lblCommonLabel_2;
		public System.Windows.Forms.Label Line1;
		public System.Windows.Forms.Label[] lblCommon = new System.Windows.Forms.Label[114];
		public System.Windows.Forms.Label[] lblCommonLabel = new System.Windows.Forms.Label[7];
		public System.Windows.Forms.TextBox[] txtCommonTextBox = new System.Windows.Forms.TextBox[6];
		public System.Windows.Forms.Label[] txtDisplayLabel = new System.Windows.Forms.Label[4];
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPayGlobalSalaryVariation));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this.chkMissingEmpBilling = new System.Windows.Forms.CheckBox();
			this._lblCommon_113 = new System.Windows.Forms.Label();
			this._lblCommonLabel_5 = new System.Windows.Forms.Label();
			this._lblCommonLabel_6 = new System.Windows.Forms.Label();
			this.txtTransDate = new Syncfusion.WinForms.Input.SfDateTimeEdit();
			this._txtDisplayLabel_0 = new System.Windows.Forms.Label();
			this._lblCommon_0 = new System.Windows.Forms.Label();
			this._lblCommonLabel_0 = new System.Windows.Forms.Label();
			this._txtDisplayLabel_1 = new System.Windows.Forms.Label();
			this._txtDisplayLabel_2 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_1 = new System.Windows.Forms.TextBox();
			this._txtCommonTextBox_0 = new System.Windows.Forms.TextBox();
			this._txtCommonTextBox_2 = new System.Windows.Forms.TextBox();
			this._lblCommonLabel_1 = new System.Windows.Forms.Label();
			this._txtDisplayLabel_3 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_3 = new System.Windows.Forms.TextBox();
			this._txtCommonTextBox_4 = new System.Windows.Forms.TextBox();
			this.cmbMastersList = new C1.Win.C1TrueDBGrid.C1TrueDBDropdown();
			this.Column_0_cmbMastersList = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.Column_1_cmbMastersList = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.grdBillingDetails = new C1.Win.C1TrueDBGrid.C1TrueDBGrid();
			this.Column_0_grdBillingDetails = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.Column_1_grdBillingDetails = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this._lblCommonLabel_3 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_5 = new System.Windows.Forms.TextBox();
			this._lblCommonLabel_2 = new System.Windows.Forms.Label();
			this.Line1 = new System.Windows.Forms.Label();
			this.cmbMastersList.SuspendLayout();
			this.grdBillingDetails.SuspendLayout();
			this.SuspendLayout();
			// 
			// chkMissingEmpBilling
			// 
			this.chkMissingEmpBilling.AllowDrop = true;
			this.chkMissingEmpBilling.Appearance = System.Windows.Forms.Appearance.Normal;
			this.chkMissingEmpBilling.BackColor = System.Drawing.Color.FromArgb(241, 242, 234);
			this.chkMissingEmpBilling.CausesValidation = true;
			this.chkMissingEmpBilling.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkMissingEmpBilling.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this.chkMissingEmpBilling.Enabled = true;
			this.chkMissingEmpBilling.ForeColor = System.Drawing.SystemColors.ControlText;
			this.chkMissingEmpBilling.Location = new System.Drawing.Point(192, 179);
			this.chkMissingEmpBilling.Name = "chkMissingEmpBilling";
			this.chkMissingEmpBilling.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.chkMissingEmpBilling.Size = new System.Drawing.Size(14, 13);
			this.chkMissingEmpBilling.TabIndex = 8;
			this.chkMissingEmpBilling.TabStop = true;
			this.chkMissingEmpBilling.Text = "";
			this.chkMissingEmpBilling.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkMissingEmpBilling.Visible = true;
			// 
			// _lblCommon_113
			// 
			this._lblCommon_113.AllowDrop = true;
			this._lblCommon_113.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_113.Text = "Employee Code";
			this._lblCommon_113.Location = new System.Drawing.Point(2, 69);
			// // this._lblCommon_113.mLabelId = 1914;
			this._lblCommon_113.Name = "_lblCommon_113";
			this._lblCommon_113.Size = new System.Drawing.Size(74, 14);
			this._lblCommon_113.TabIndex = 0;
			// 
			// _lblCommonLabel_5
			// 
			this._lblCommonLabel_5.AllowDrop = true;
			this._lblCommonLabel_5.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_5.Text = "Transaction No.";
			this._lblCommonLabel_5.Location = new System.Drawing.Point(2, 48);
			// // this._lblCommonLabel_5.mLabelId = 1744;
			this._lblCommonLabel_5.Name = "_lblCommonLabel_5";
			this._lblCommonLabel_5.Size = new System.Drawing.Size(76, 14);
			this._lblCommonLabel_5.TabIndex = 10;
			// 
			// _lblCommonLabel_6
			// 
			this._lblCommonLabel_6.AllowDrop = true;
			this._lblCommonLabel_6.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_6.Text = "Transaction Date";
			this._lblCommonLabel_6.Location = new System.Drawing.Point(422, 48);
			// // this._lblCommonLabel_6.mLabelId = 1233;
			this._lblCommonLabel_6.Name = "_lblCommonLabel_6";
			this._lblCommonLabel_6.Size = new System.Drawing.Size(82, 14);
			this._lblCommonLabel_6.TabIndex = 11;
			// 
			// txtTransDate
			// 
			this.txtTransDate.AllowDrop = true;
			// this.txtTransDate.CheckDateRange = false;
			this.txtTransDate.Location = new System.Drawing.Point(507, 46);
			// this.txtTransDate.MaxDate = 2958465;
			// this.txtTransDate.MinDate = 32874;
			this.txtTransDate.Name = "txtTransDate";
			this.txtTransDate.Size = new System.Drawing.Size(102, 19);
			this.txtTransDate.TabIndex = 2;
			this.txtTransDate.Text = "18/07/2001";
			// this.txtTransDate.Value = 37090;
			// 
			// _txtDisplayLabel_0
			// 
			this._txtDisplayLabel_0.AllowDrop = true;
			this._txtDisplayLabel_0.Location = new System.Drawing.Point(226, 67);
			this._txtDisplayLabel_0.Name = "_txtDisplayLabel_0";
			this._txtDisplayLabel_0.Size = new System.Drawing.Size(383, 19);
			this._txtDisplayLabel_0.TabIndex = 12;
			this._txtDisplayLabel_0.TabStop = false;
			// 
			// _lblCommon_0
			// 
			this._lblCommon_0.AllowDrop = true;
			this._lblCommon_0.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_0.Text = "Employee Code";
			this._lblCommon_0.Location = new System.Drawing.Point(2, 90);
			// // this._lblCommon_0.mLabelId = 1915;
			this._lblCommon_0.Name = "_lblCommon_0";
			this._lblCommon_0.Size = new System.Drawing.Size(74, 14);
			this._lblCommon_0.TabIndex = 13;
			// 
			// _lblCommonLabel_0
			// 
			this._lblCommonLabel_0.AllowDrop = true;
			this._lblCommonLabel_0.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_0.Text = "Department Code";
			this._lblCommonLabel_0.Location = new System.Drawing.Point(2, 114);
			// // this._lblCommonLabel_0.mLabelId = 2101;
			this._lblCommonLabel_0.Name = "_lblCommonLabel_0";
			this._lblCommonLabel_0.Size = new System.Drawing.Size(83, 14);
			this._lblCommonLabel_0.TabIndex = 14;
			// 
			// _txtDisplayLabel_1
			// 
			this._txtDisplayLabel_1.AllowDrop = true;
			this._txtDisplayLabel_1.Location = new System.Drawing.Point(226, 88);
			this._txtDisplayLabel_1.Name = "_txtDisplayLabel_1";
			this._txtDisplayLabel_1.Size = new System.Drawing.Size(383, 19);
			this._txtDisplayLabel_1.TabIndex = 15;
			this._txtDisplayLabel_1.TabStop = false;
			// 
			// _txtDisplayLabel_2
			// 
			this._txtDisplayLabel_2.AllowDrop = true;
			this._txtDisplayLabel_2.Location = new System.Drawing.Point(226, 110);
			this._txtDisplayLabel_2.Name = "_txtDisplayLabel_2";
			this._txtDisplayLabel_2.Size = new System.Drawing.Size(383, 19);
			this._txtDisplayLabel_2.TabIndex = 16;
			this._txtDisplayLabel_2.TabStop = false;
			// 
			// _txtCommonTextBox_1
			// 
			this._txtCommonTextBox_1.AllowDrop = true;
			this._txtCommonTextBox_1.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_1.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_1.Location = new System.Drawing.Point(118, 67);
			this._txtCommonTextBox_1.MaxLength = 20;
			// this._txtCommonTextBox_1.mDropDownType = System.Windows.Forms.TextBox.DropDownTypes.ddtNextNumber;
			this._txtCommonTextBox_1.Name = "_txtCommonTextBox_1";
			// this._txtCommonTextBox_1.ShowButton = true;
			this._txtCommonTextBox_1.Size = new System.Drawing.Size(107, 19);
			this._txtCommonTextBox_1.TabIndex = 3;
			this._txtCommonTextBox_1.Text = "";
			// this.this._txtCommonTextBox_1.Watermark = "";
			// this.this._txtCommonTextBox_1.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_1.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _txtCommonTextBox_0
			// 
			this._txtCommonTextBox_0.AllowDrop = true;
			this._txtCommonTextBox_0.BackColor = System.Drawing.Color.FromArgb(239, 239, 239);
			// this._txtCommonTextBox_0.bolNumericOnly = true;
			this._txtCommonTextBox_0.Enabled = false;
			this._txtCommonTextBox_0.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_0.Location = new System.Drawing.Point(118, 46);
			// this._txtCommonTextBox_0.mDropDownType = System.Windows.Forms.TextBox.DropDownTypes.ddtNextNumber;
			this._txtCommonTextBox_0.Name = "_txtCommonTextBox_0";
			// this._txtCommonTextBox_0.ShowButton = true;
			this._txtCommonTextBox_0.Size = new System.Drawing.Size(107, 19);
			this._txtCommonTextBox_0.TabIndex = 1;
			this._txtCommonTextBox_0.TabStop = false;
			this._txtCommonTextBox_0.Text = "";
			// this.this._txtCommonTextBox_0.Watermark = "";
			// this.this._txtCommonTextBox_0.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_0.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _txtCommonTextBox_2
			// 
			this._txtCommonTextBox_2.AllowDrop = true;
			this._txtCommonTextBox_2.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_2.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_2.Location = new System.Drawing.Point(118, 88);
			this._txtCommonTextBox_2.MaxLength = 20;
			// this._txtCommonTextBox_2.mDropDownType = System.Windows.Forms.TextBox.DropDownTypes.ddtNextNumber;
			this._txtCommonTextBox_2.Name = "_txtCommonTextBox_2";
			// this._txtCommonTextBox_2.ShowButton = true;
			this._txtCommonTextBox_2.Size = new System.Drawing.Size(107, 19);
			this._txtCommonTextBox_2.TabIndex = 4;
			this._txtCommonTextBox_2.Text = "";
			// this.this._txtCommonTextBox_2.Watermark = "";
			// this.this._txtCommonTextBox_2.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_2.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _lblCommonLabel_1
			// 
			this._lblCommonLabel_1.AllowDrop = true;
			this._lblCommonLabel_1.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_1.Text = "Department Code";
			this._lblCommonLabel_1.Location = new System.Drawing.Point(2, 136);
			// // this._lblCommonLabel_1.mLabelId = 2102;
			this._lblCommonLabel_1.Name = "_lblCommonLabel_1";
			this._lblCommonLabel_1.Size = new System.Drawing.Size(83, 14);
			this._lblCommonLabel_1.TabIndex = 17;
			// 
			// _txtDisplayLabel_3
			// 
			this._txtDisplayLabel_3.AllowDrop = true;
			this._txtDisplayLabel_3.Location = new System.Drawing.Point(226, 132);
			this._txtDisplayLabel_3.Name = "_txtDisplayLabel_3";
			this._txtDisplayLabel_3.Size = new System.Drawing.Size(383, 19);
			this._txtDisplayLabel_3.TabIndex = 18;
			this._txtDisplayLabel_3.TabStop = false;
			// 
			// _txtCommonTextBox_3
			// 
			this._txtCommonTextBox_3.AllowDrop = true;
			this._txtCommonTextBox_3.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_3.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_3.Location = new System.Drawing.Point(118, 110);
			this._txtCommonTextBox_3.MaxLength = 20;
			// this._txtCommonTextBox_3.mDropDownType = System.Windows.Forms.TextBox.DropDownTypes.ddtNextNumber;
			this._txtCommonTextBox_3.Name = "_txtCommonTextBox_3";
			// this._txtCommonTextBox_3.ShowButton = true;
			this._txtCommonTextBox_3.Size = new System.Drawing.Size(107, 19);
			this._txtCommonTextBox_3.TabIndex = 5;
			this._txtCommonTextBox_3.Text = "";
			// this.this._txtCommonTextBox_3.Watermark = "";
			// this.this._txtCommonTextBox_3.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_3.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _txtCommonTextBox_4
			// 
			this._txtCommonTextBox_4.AllowDrop = true;
			this._txtCommonTextBox_4.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_4.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_4.Location = new System.Drawing.Point(118, 132);
			this._txtCommonTextBox_4.MaxLength = 20;
			// this._txtCommonTextBox_4.mDropDownType = System.Windows.Forms.TextBox.DropDownTypes.ddtNextNumber;
			this._txtCommonTextBox_4.Name = "_txtCommonTextBox_4";
			// this._txtCommonTextBox_4.ShowButton = true;
			this._txtCommonTextBox_4.Size = new System.Drawing.Size(107, 19);
			this._txtCommonTextBox_4.TabIndex = 6;
			this._txtCommonTextBox_4.Text = "";
			// this.this._txtCommonTextBox_4.Watermark = "";
			// this.this._txtCommonTextBox_4.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_4.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// cmbMastersList
			// 
			this.cmbMastersList.AllowDrop = true;
			this.cmbMastersList.ColumnHeaders = true;
			this.cmbMastersList.Enabled = true;
			this.cmbMastersList.Location = new System.Drawing.Point(6, 432);
			this.cmbMastersList.Name = "cmbMastersList";
			this.cmbMastersList.Size = new System.Drawing.Size(53, 37);
			this.cmbMastersList.TabIndex = 19;
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
			// grdBillingDetails
			// 
			this.grdBillingDetails.AllowDrop = true;
			this.grdBillingDetails.BackColor = System.Drawing.Color.FromArgb(212, 208, 200);
			this.grdBillingDetails.CellTipsWidth = 0;
			this.grdBillingDetails.Location = new System.Drawing.Point(2, 206);
			this.grdBillingDetails.Name = "grdBillingDetails";
			this.grdBillingDetails.RowDivider.Color = System.Drawing.Color.FromArgb(212, 208, 200);
			this.grdBillingDetails.Size = new System.Drawing.Size(607, 269);
			this.grdBillingDetails.TabIndex = 9;
			this.grdBillingDetails.Columns.Add(this.Column_0_grdBillingDetails);
			this.grdBillingDetails.Columns.Add(this.Column_1_grdBillingDetails);
			this.grdBillingDetails.AfterUpdate += new System.EventHandler(this.grdBillingDetails_AfterUpdate);
			this.grdBillingDetails.GotFocus += new System.EventHandler(this.grdBillingDetails_GotFocus);
			this.grdBillingDetails.RowColChange += new C1.Win.C1TrueDBGrid.RowColChangeEventHandler(this.grdBillingDetails_RowColChange);
			// 
			// Column_0_grdBillingDetails
			// 
			this.Column_0_grdBillingDetails.DataField = "";
			this.Column_0_grdBillingDetails.ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.Normal;
			// 
			// Column_1_grdBillingDetails
			// 
			this.Column_1_grdBillingDetails.DataField = "";
			this.Column_1_grdBillingDetails.ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.Normal;
			// 
			// _lblCommonLabel_3
			// 
			this._lblCommonLabel_3.AllowDrop = true;
			this._lblCommonLabel_3.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_3.Text = "Comments";
			this._lblCommonLabel_3.Location = new System.Drawing.Point(2, 158);
			// // this._lblCommonLabel_3.mLabelId = 1851;
			this._lblCommonLabel_3.Name = "_lblCommonLabel_3";
			this._lblCommonLabel_3.Size = new System.Drawing.Size(50, 14);
			this._lblCommonLabel_3.TabIndex = 20;
			// 
			// _txtCommonTextBox_5
			// 
			this._txtCommonTextBox_5.AllowDrop = true;
			this._txtCommonTextBox_5.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_5.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_5.Location = new System.Drawing.Point(118, 154);
			this._txtCommonTextBox_5.MaxLength = 20;
			// this._txtCommonTextBox_5.mDropDownType = System.Windows.Forms.TextBox.DropDownTypes.ddtNextNumber;
			this._txtCommonTextBox_5.Name = "_txtCommonTextBox_5";
			this._txtCommonTextBox_5.Size = new System.Drawing.Size(491, 19);
			this._txtCommonTextBox_5.TabIndex = 7;
			this._txtCommonTextBox_5.Text = "";
			// this.this._txtCommonTextBox_5.Watermark = "";
			// this.this._txtCommonTextBox_5.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_5.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _lblCommonLabel_2
			// 
			this._lblCommonLabel_2.AllowDrop = true;
			this._lblCommonLabel_2.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_2.Text = "Create Missing Employee Billing.";
			this._lblCommonLabel_2.Location = new System.Drawing.Point(2, 178);
			// // this._lblCommonLabel_2.mLabelId = 2103;
			this._lblCommonLabel_2.Name = "_lblCommonLabel_2";
			this._lblCommonLabel_2.Size = new System.Drawing.Size(153, 14);
			this._lblCommonLabel_2.TabIndex = 21;
			// 
			// Line1
			// 
			this.Line1.AllowDrop = true;
			this.Line1.BackColor = System.Drawing.SystemColors.WindowText;
			this.Line1.Enabled = false;
			this.Line1.Location = new System.Drawing.Point(0, 200);
			this.Line1.Name = "Line1";
			this.Line1.Size = new System.Drawing.Size(608, 1);
			this.Line1.Visible = true;
			// 
			// frmPayGlobalSalaryVariation
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.ClientSize = new System.Drawing.Size(612, 478);
			this.Controls.Add(this.chkMissingEmpBilling);
			this.Controls.Add(this._lblCommon_113);
			this.Controls.Add(this._lblCommonLabel_5);
			this.Controls.Add(this._lblCommonLabel_6);
			this.Controls.Add(this.txtTransDate);
			this.Controls.Add(this._txtDisplayLabel_0);
			this.Controls.Add(this._lblCommon_0);
			this.Controls.Add(this._lblCommonLabel_0);
			this.Controls.Add(this._txtDisplayLabel_1);
			this.Controls.Add(this._txtDisplayLabel_2);
			this.Controls.Add(this._txtCommonTextBox_1);
			this.Controls.Add(this._txtCommonTextBox_0);
			this.Controls.Add(this._txtCommonTextBox_2);
			this.Controls.Add(this._lblCommonLabel_1);
			this.Controls.Add(this._txtDisplayLabel_3);
			this.Controls.Add(this._txtCommonTextBox_3);
			this.Controls.Add(this._txtCommonTextBox_4);
			this.Controls.Add(this.cmbMastersList);
			this.Controls.Add(this.grdBillingDetails);
			this.Controls.Add(this._lblCommonLabel_3);
			this.Controls.Add(this._txtCommonTextBox_5);
			this.Controls.Add(this._lblCommonLabel_2);
			this.Controls.Add(this.Line1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			//this.Icon = (System.Drawing.Icon) resources.GetObject("frmPayGlobalSalaryVariation.Icon");
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(159, 230);
			this.MaximizeBox = true;
			this.MinimizeBox = true;
			this.Name = "frmPayGlobalSalaryVariation";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Global Salary Variation";
			// this.Activated += new System.EventHandler(this.Form_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
			// this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
			this.cmbMastersList.ResumeLayout(false);
			this.grdBillingDetails.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		void ReLoadForm(bool addEvents)
		{
			InitializetxtDisplayLabel();
			InitializetxtCommonTextBox();
			InitializelblCommonLabel();
			InitializelblCommon();
			//This form is an MDI child.
			//This code simulates the VB6 
			// functionality of automatically
			// loading and showing an MDI
			// child's parent.
			this.MdiParent = Xtreme.frmSysMain.DefInstance;
			Xtreme.frmSysMain.DefInstance.Show();
		}
		void InitializetxtDisplayLabel()
		{
			this.txtDisplayLabel = new System.Windows.Forms.Label[4];
			this.txtDisplayLabel[0] = _txtDisplayLabel_0;
			this.txtDisplayLabel[1] = _txtDisplayLabel_1;
			this.txtDisplayLabel[2] = _txtDisplayLabel_2;
			this.txtDisplayLabel[3] = _txtDisplayLabel_3;
		}
		void InitializetxtCommonTextBox()
		{
			this.txtCommonTextBox = new System.Windows.Forms.TextBox[6];
			this.txtCommonTextBox[1] = _txtCommonTextBox_1;
			this.txtCommonTextBox[0] = _txtCommonTextBox_0;
			this.txtCommonTextBox[2] = _txtCommonTextBox_2;
			this.txtCommonTextBox[3] = _txtCommonTextBox_3;
			this.txtCommonTextBox[4] = _txtCommonTextBox_4;
			this.txtCommonTextBox[5] = _txtCommonTextBox_5;
		}
		void InitializelblCommonLabel()
		{
			this.lblCommonLabel = new System.Windows.Forms.Label[7];
			this.lblCommonLabel[5] = _lblCommonLabel_5;
			this.lblCommonLabel[6] = _lblCommonLabel_6;
			this.lblCommonLabel[0] = _lblCommonLabel_0;
			this.lblCommonLabel[1] = _lblCommonLabel_1;
			this.lblCommonLabel[3] = _lblCommonLabel_3;
			this.lblCommonLabel[2] = _lblCommonLabel_2;
		}
		void InitializelblCommon()
		{
			this.lblCommon = new System.Windows.Forms.Label[114];
			this.lblCommon[113] = _lblCommon_113;
			this.lblCommon[0] = _lblCommon_0;
		}
		#endregion
	}
}//ENDSHERE
