
namespace Xtreme
{
	partial class frmICSLetterOfCredit
	{

		#region "Upgrade Support "
		private static frmICSLetterOfCredit m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmICSLetterOfCredit DefInstance
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
		public static frmICSLetterOfCredit CreateInstance()
		{
			frmICSLetterOfCredit theInstance = new frmICSLetterOfCredit();
			
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
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "Column_0_cmbParentsList", "Column_1_cmbParentsList", "cmbParentsList", "TextBox1_0", "Column_0_grdLC", "Column_1_grdLC", "grdLC", "txtNotes", "txtGoods", "TextBox_0", "txtDateOfCredit", "txtExpiryDate", "TextBox_1", "txtSupplierName", "TextBox_2", "TextBox_3", "TextBox_4", "TextBox_5", "TextBox_6", "TextBox_7", "TextBox_8", "txtPolicyDate", "txtArrivalDate", "txtAmendment1", "txtAmendment2", "txtAmendment3", "TextBox_9", "TextBox1_1", "TextBox1_2", "TextBox1_3", "TextBox1_4", "_Label1_19", "_Label1_18", "_Label1_17", "_Label1_16", "_Label1_15", "_Label1_14", "_Label1_13", "_Label1_12", "_Label1_11", "_Label1_10", "_Label1_9", "_Label1_8", "_Label1_7", "_Label1_6", "_Label1_5", "_Label1_4", "_Label1_3", "_Label1_2", "_Label1_1", "_Label1_0", "lblExpDate", "lblDate", "Label1", "System.Windows.Forms.TextBox1", "System.Windows.Forms.TextBox"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_0_cmbParentsList;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_1_cmbParentsList;
		public C1.Win.C1TrueDBGrid.C1TrueDBDropdown cmbParentsList;
		private System.Windows.Forms.TextBox TextBox1_0;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_0_grdLC;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_1_grdLC;
		public C1.Win.C1TrueDBGrid.C1TrueDBGrid grdLC;
		public System.Windows.Forms.TextBox txtNotes;
		public System.Windows.Forms.TextBox txtGoods;
		private System.Windows.Forms.TextBox TextBox_0;
		public Syncfusion.WinForms.Input.SfDateTimeEdit txtDateOfCredit;
		public Syncfusion.WinForms.Input.SfDateTimeEdit txtExpiryDate;
		private System.Windows.Forms.TextBox TextBox_1;
		public System.Windows.Forms.TextBox txtSupplierName;
		private System.Windows.Forms.TextBox TextBox_2;
		private System.Windows.Forms.TextBox TextBox_3;
		private System.Windows.Forms.TextBox TextBox_4;
		private System.Windows.Forms.TextBox TextBox_5;
		private System.Windows.Forms.TextBox TextBox_6;
		private System.Windows.Forms.TextBox TextBox_7;
		private System.Windows.Forms.TextBox TextBox_8;
		public Syncfusion.WinForms.Input.SfDateTimeEdit txtPolicyDate;
		public Syncfusion.WinForms.Input.SfDateTimeEdit txtArrivalDate;
		public Syncfusion.WinForms.Input.SfDateTimeEdit txtAmendment1;
		public Syncfusion.WinForms.Input.SfDateTimeEdit txtAmendment2;
		public Syncfusion.WinForms.Input.SfDateTimeEdit txtAmendment3;
		private System.Windows.Forms.TextBox TextBox_9;
		private System.Windows.Forms.TextBox TextBox1_1;
		private System.Windows.Forms.TextBox TextBox1_2;
		private System.Windows.Forms.TextBox TextBox1_3;
		private System.Windows.Forms.TextBox TextBox1_4;
		private System.Windows.Forms.Label _Label1_19;
		private System.Windows.Forms.Label _Label1_18;
		private System.Windows.Forms.Label _Label1_17;
		private System.Windows.Forms.Label _Label1_16;
		private System.Windows.Forms.Label _Label1_15;
		private System.Windows.Forms.Label _Label1_14;
		private System.Windows.Forms.Label _Label1_13;
		private System.Windows.Forms.Label _Label1_12;
		private System.Windows.Forms.Label _Label1_11;
		private System.Windows.Forms.Label _Label1_10;
		private System.Windows.Forms.Label _Label1_9;
		private System.Windows.Forms.Label _Label1_8;
		private System.Windows.Forms.Label _Label1_7;
		private System.Windows.Forms.Label _Label1_6;
		private System.Windows.Forms.Label _Label1_5;
		private System.Windows.Forms.Label _Label1_4;
		private System.Windows.Forms.Label _Label1_3;
		private System.Windows.Forms.Label _Label1_2;
		private System.Windows.Forms.Label _Label1_1;
		private System.Windows.Forms.Label _Label1_0;
		public System.Windows.Forms.Label lblExpDate;
		public System.Windows.Forms.Label lblDate;
		public System.Windows.Forms.Label[] Label1 = new System.Windows.Forms.Label[20];
		public System.Windows.Forms.TextBox[] TextBox1 = new System.Windows.Forms.TextBox[5];
		public System.Windows.Forms.TextBox[] TextBox = new System.Windows.Forms.TextBox[10];
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmICSLetterOfCredit));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this.cmbParentsList = new C1.Win.C1TrueDBGrid.C1TrueDBDropdown();
			this.Column_0_cmbParentsList = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.Column_1_cmbParentsList = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.TextBox1_0 = new System.Windows.Forms.TextBox();
			this.grdLC = new C1.Win.C1TrueDBGrid.C1TrueDBGrid();
			this.Column_0_grdLC = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.Column_1_grdLC = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.txtNotes = new System.Windows.Forms.TextBox();
			this.txtGoods = new System.Windows.Forms.TextBox();
			this.TextBox_0 = new System.Windows.Forms.TextBox();
			this.txtDateOfCredit = new Syncfusion.WinForms.Input.SfDateTimeEdit();
			this.txtExpiryDate = new Syncfusion.WinForms.Input.SfDateTimeEdit();
			this.TextBox_1 = new System.Windows.Forms.TextBox();
			this.txtSupplierName = new System.Windows.Forms.TextBox();
			this.TextBox_2 = new System.Windows.Forms.TextBox();
			this.TextBox_3 = new System.Windows.Forms.TextBox();
			this.TextBox_4 = new System.Windows.Forms.TextBox();
			this.TextBox_5 = new System.Windows.Forms.TextBox();
			this.TextBox_6 = new System.Windows.Forms.TextBox();
			this.TextBox_7 = new System.Windows.Forms.TextBox();
			this.TextBox_8 = new System.Windows.Forms.TextBox();
			this.txtPolicyDate = new Syncfusion.WinForms.Input.SfDateTimeEdit();
			this.txtArrivalDate = new Syncfusion.WinForms.Input.SfDateTimeEdit();
			this.txtAmendment1 = new Syncfusion.WinForms.Input.SfDateTimeEdit();
			this.txtAmendment2 = new Syncfusion.WinForms.Input.SfDateTimeEdit();
			this.txtAmendment3 = new Syncfusion.WinForms.Input.SfDateTimeEdit();
			this.TextBox_9 = new System.Windows.Forms.TextBox();
			this.TextBox1_1 = new System.Windows.Forms.TextBox();
			this.TextBox1_2 = new System.Windows.Forms.TextBox();
			this.TextBox1_3 = new System.Windows.Forms.TextBox();
			this.TextBox1_4 = new System.Windows.Forms.TextBox();
			this._Label1_19 = new System.Windows.Forms.Label();
			this._Label1_18 = new System.Windows.Forms.Label();
			this._Label1_17 = new System.Windows.Forms.Label();
			this._Label1_16 = new System.Windows.Forms.Label();
			this._Label1_15 = new System.Windows.Forms.Label();
			this._Label1_14 = new System.Windows.Forms.Label();
			this._Label1_13 = new System.Windows.Forms.Label();
			this._Label1_12 = new System.Windows.Forms.Label();
			this._Label1_11 = new System.Windows.Forms.Label();
			this._Label1_10 = new System.Windows.Forms.Label();
			this._Label1_9 = new System.Windows.Forms.Label();
			this._Label1_8 = new System.Windows.Forms.Label();
			this._Label1_7 = new System.Windows.Forms.Label();
			this._Label1_6 = new System.Windows.Forms.Label();
			this._Label1_5 = new System.Windows.Forms.Label();
			this._Label1_4 = new System.Windows.Forms.Label();
			this._Label1_3 = new System.Windows.Forms.Label();
			this._Label1_2 = new System.Windows.Forms.Label();
			this._Label1_1 = new System.Windows.Forms.Label();
			this._Label1_0 = new System.Windows.Forms.Label();
			this.lblExpDate = new System.Windows.Forms.Label();
			this.lblDate = new System.Windows.Forms.Label();
			//this.cmbParentsList.SuspendLayout();
			//this.grdLC.SuspendLayout();
			this.SuspendLayout();
			// 
			// cmbParentsList
			// 
			this.cmbParentsList.AllowDrop = true;
			this.cmbParentsList.ColumnHeaders = true;
			this.cmbParentsList.Enabled = true;
			this.cmbParentsList.Location = new System.Drawing.Point(222, 396);
			this.cmbParentsList.Name = "cmbParentsList";
			this.cmbParentsList.Size = new System.Drawing.Size(227, 78);
			this.cmbParentsList.TabIndex = 48;
			this.cmbParentsList.Columns.Add(this.Column_0_cmbParentsList);
			this.cmbParentsList.Columns.Add(this.Column_1_cmbParentsList);
			// 
			// Column_0_cmbParentsList
			// 
			this.Column_0_cmbParentsList.DataField = "";
			this.Column_0_cmbParentsList.ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.Normal;
			// 
			// Column_1_cmbParentsList
			// 
			this.Column_1_cmbParentsList.DataField = "";
			this.Column_1_cmbParentsList.ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.Normal;
			// 
			// TextBox1_0
			// 
			this.TextBox1_0.AllowDrop = true;
			this.TextBox1_0.Enabled = false;
			this.TextBox1_0.Location = new System.Drawing.Point(92, 496);
			this.TextBox1_0.Name = "TextBox1_0";
			this.TextBox1_0.Size = new System.Drawing.Size(113, 19);
			this.TextBox1_0.TabIndex = 41;
			// 
			// grdLC
			// 
			this.grdLC.AllowAddNew = true;
			this.grdLC.AllowDelete = true;
			this.grdLC.AllowDrop = true;
			this.grdLC.BackColor = System.Drawing.Color.FromArgb(212, 208, 200);
			this.grdLC.CellTipsWidth = 0;
			this.grdLC.Location = new System.Drawing.Point(8, 342);
			this.grdLC.Name = "grdLC";
			this.grdLC.RowDivider.Color = System.Drawing.Color.FromArgb(212, 208, 200);
			this.grdLC.Size = new System.Drawing.Size(577, 149);
			this.grdLC.TabIndex = 37;
			this.grdLC.Columns.Add(this.Column_0_grdLC);
			this.grdLC.Columns.Add(this.Column_1_grdLC);
			//this.grdLC.GotFocus += new System.EventHandler(this.grdLC_GotFocus);
			//this.grdLC.RowColChange += new C1.Win.C1TrueDBGrid.RowColChangeEventHandler(this.grdLC_RowColChange);
			// 
			// Column_0_grdLC
			// 
			this.Column_0_grdLC.DataField = "";
			this.Column_0_grdLC.ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.Normal;
			// 
			// Column_1_grdLC
			// 
			this.Column_1_grdLC.DataField = "";
			this.Column_1_grdLC.ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.Normal;
			// 
			// txtNotes
			// 
			this.txtNotes.AcceptsReturn = true;
			this.txtNotes.AllowDrop = true;
			this.txtNotes.BackColor = System.Drawing.SystemColors.Window;
			this.txtNotes.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.txtNotes.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtNotes.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtNotes.Location = new System.Drawing.Point(86, 272);
			this.txtNotes.MaxLength = 0;
			this.txtNotes.Multiline = true;
			this.txtNotes.Name = "txtNotes";
			this.txtNotes.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtNotes.Size = new System.Drawing.Size(499, 51);
			this.txtNotes.TabIndex = 35;
			// 
			// txtGoods
			// 
			this.txtGoods.AcceptsReturn = true;
			this.txtGoods.AllowDrop = true;
			this.txtGoods.BackColor = System.Drawing.SystemColors.Window;
			this.txtGoods.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.txtGoods.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtGoods.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtGoods.Location = new System.Drawing.Point(86, 58);
			this.txtGoods.MaxLength = 0;
			this.txtGoods.Multiline = true;
			this.txtGoods.Name = "txtGoods";
			this.txtGoods.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtGoods.Size = new System.Drawing.Size(499, 55);
			this.txtGoods.TabIndex = 10;
			// 
			// TextBox_0
			// 
			this.TextBox_0.AllowDrop = true;
			this.TextBox_0.BackColor = System.Drawing.Color.White;
			// = false;
			this.TextBox_0.ForeColor = System.Drawing.Color.Black;
			this.TextBox_0.Location = new System.Drawing.Point(276, 12);
			// = (System.Windows.Forms.TextBox.DropDownTypes) 0;
			this.TextBox_0.Name = "TextBox_0";
			this.TextBox_0.Size = new System.Drawing.Size(115, 19);
			this.TextBox_0.TabIndex = 5;
			this.TextBox_0.Text = "";
			// = "";
			//this.TextBox_0.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(//this.TextBox_DropButtonClick);
			// 
			// txtDateOfCredit
			// 
			this.txtDateOfCredit.AllowDrop = true;
			this.txtDateOfCredit.Location = new System.Drawing.Point(86, 12);
			// this.txtDateOfCredit.MaxDate = 2958465;
			// this.txtDateOfCredit.MinDate = -657434;
			this.txtDateOfCredit.Name = "txtDateOfCredit";
			// = "_";
			this.txtDateOfCredit.Size = new System.Drawing.Size(97, 19);
			this.txtDateOfCredit.TabIndex = 1;
			this.txtDateOfCredit.Text = "10-Dec-2008";
			// this.txtDateOfCredit.Value = 39792;
			// 
			// txtExpiryDate
			// 
			this.txtExpiryDate.AllowDrop = true;
			this.txtExpiryDate.Location = new System.Drawing.Point(86, 34);
			// this.txtExpiryDate.MaxDate = 2958465;
			// this.txtExpiryDate.MinDate = -657434;
			this.txtExpiryDate.Name = "txtExpiryDate";
			// = "_";
			this.txtExpiryDate.Size = new System.Drawing.Size(97, 19);
			this.txtExpiryDate.TabIndex = 3;
			// this.txtExpiryDate.Text = "10-Dec-2008";
			// this.txtExpiryDate.Value = 39792;
			// 
			// TextBox_1
			// 
			this.TextBox_1.AllowDrop = true;
			this.TextBox_1.BackColor = System.Drawing.Color.White;
			// = false;
			this.TextBox_1.ForeColor = System.Drawing.Color.Black;
			this.TextBox_1.Location = new System.Drawing.Point(276, 34);
			// = (System.Windows.Forms.TextBox.DropDownTypes) 0;
			this.TextBox_1.Name = "TextBox_1";
			//this.TextBox_1.ShowButton = true;
			this.TextBox_1.Size = new System.Drawing.Size(115, 19);
			this.TextBox_1.TabIndex = 7;
			this.TextBox_1.Text = "";
			// = "";
			//this.TextBox_1.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(//this.TextBox_DropButtonClick);
			// 
			// txtSupplierName
			// 
			this.txtSupplierName.AllowDrop = true;
			this.txtSupplierName.BackColor = System.Drawing.Color.FromArgb(239, 239, 239);
			this.txtSupplierName.Enabled = false;
			this.txtSupplierName.ForeColor = System.Drawing.Color.Black;
			this.txtSupplierName.Location = new System.Drawing.Point(394, 34);
			this.txtSupplierName.Name = "txtSupplierName";
			this.txtSupplierName.Size = new System.Drawing.Size(191, 19);
			this.txtSupplierName.TabIndex = 8;
			this.txtSupplierName.TabStop = false;
			this.txtSupplierName.Text = " ";
			// this.// = "";
			// 
			// TextBox_2
			// 
			this.TextBox_2.AllowDrop = true;
			this.TextBox_2.BackColor = System.Drawing.Color.White;
			// = false;
			this.TextBox_2.ForeColor = System.Drawing.Color.Black;
			this.TextBox_2.Location = new System.Drawing.Point(86, 116);
			// = (System.Windows.Forms.TextBox.DropDownTypes) 0;
			this.TextBox_2.Name = "TextBox_2";
			this.TextBox_2.Size = new System.Drawing.Size(499, 19);
			this.TextBox_2.TabIndex = 12;
			this.TextBox_2.Text = "";
			// = "";
			//this.TextBox_2.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(//this.TextBox_DropButtonClick);
			// 
			// TextBox_3
			// 
			this.TextBox_3.AllowDrop = true;
			this.TextBox_3.BackColor = System.Drawing.Color.White;
			// = false;
			this.TextBox_3.ForeColor = System.Drawing.Color.Black;
			this.TextBox_3.Location = new System.Drawing.Point(86, 138);
			// = (System.Windows.Forms.TextBox.DropDownTypes) 0;
			this.TextBox_3.Name = "TextBox_3";
			this.TextBox_3.Size = new System.Drawing.Size(499, 19);
			this.TextBox_3.TabIndex = 14;
			this.TextBox_3.Text = "";
			// = "";
			//this.TextBox_3.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(//this.TextBox_DropButtonClick);
			// 
			// TextBox_4
			// 
			this.TextBox_4.AllowDrop = true;
			this.TextBox_4.BackColor = System.Drawing.Color.White;
			// = false;
			this.TextBox_4.ForeColor = System.Drawing.Color.Black;
			this.TextBox_4.Location = new System.Drawing.Point(86, 160);
			// = (System.Windows.Forms.TextBox.DropDownTypes) 0;
			this.TextBox_4.Name = "TextBox_4";
			this.TextBox_4.Size = new System.Drawing.Size(499, 19);
			this.TextBox_4.TabIndex = 16;
			this.TextBox_4.Text = "";
			// = "";
			//this.TextBox_4.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(//this.TextBox_DropButtonClick);
			// 
			// TextBox_5
			// 
			this.TextBox_5.AllowDrop = true;
			this.TextBox_5.BackColor = System.Drawing.Color.White;
			// = false;
			this.TextBox_5.ForeColor = System.Drawing.Color.Black;
			this.TextBox_5.Location = new System.Drawing.Point(86, 182);
			// = (System.Windows.Forms.TextBox.DropDownTypes) 0;
			this.TextBox_5.Name = "TextBox_5";
			this.TextBox_5.Size = new System.Drawing.Size(113, 19);
			this.TextBox_5.TabIndex = 18;
			this.TextBox_5.Text = "";
			// = "";
			//this.TextBox_5.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(//this.TextBox_DropButtonClick);
			// 
			// TextBox_6
			// 
			this.TextBox_6.AllowDrop = true;
			this.TextBox_6.BackColor = System.Drawing.Color.White;
			// = false;
			this.TextBox_6.ForeColor = System.Drawing.Color.Black;
			this.TextBox_6.Location = new System.Drawing.Point(286, 182);
			// = (System.Windows.Forms.TextBox.DropDownTypes) 0;
			this.TextBox_6.Name = "TextBox_6";
			//this.TextBox_6.ShowButton = true;
			this.TextBox_6.Size = new System.Drawing.Size(113, 19);
			this.TextBox_6.TabIndex = 20;
			this.TextBox_6.Text = "";
			// = "";
			//this.TextBox_6.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(//this.TextBox_DropButtonClick);
			// 
			// TextBox_7
			// 
			this.TextBox_7.AllowDrop = true;
			this.TextBox_7.BackColor = System.Drawing.Color.White;
			// = false;
			this.TextBox_7.ForeColor = System.Drawing.Color.Black;
			this.TextBox_7.Location = new System.Drawing.Point(86, 204);
			// = (System.Windows.Forms.TextBox.DropDownTypes) 0;
			this.TextBox_7.Name = "TextBox_7";
			this.TextBox_7.Size = new System.Drawing.Size(113, 19);
			this.TextBox_7.TabIndex = 21;
			this.TextBox_7.Text = "";
			// = "";
			//this.TextBox_7.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(//this.TextBox_DropButtonClick);
			// 
			// TextBox_8
			// 
			this.TextBox_8.AllowDrop = true;
			this.TextBox_8.BackColor = System.Drawing.Color.White;
			// = false;
			this.TextBox_8.ForeColor = System.Drawing.Color.Black;
			this.TextBox_8.Location = new System.Drawing.Point(286, 204);
			// = (System.Windows.Forms.TextBox.DropDownTypes) 0;
			this.TextBox_8.Name = "TextBox_8";
			this.TextBox_8.Size = new System.Drawing.Size(113, 19);
			this.TextBox_8.TabIndex = 23;
			this.TextBox_8.Text = "";
			// = "";
			//this.TextBox_8.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(//this.TextBox_DropButtonClick);
			// 
			// txtPolicyDate
			// 
			this.txtPolicyDate.AllowDrop = true;
			this.txtPolicyDate.Location = new System.Drawing.Point(86, 226);
			// this.txtPolicyDate.MaxDate = 2958465;
			// this.txtPolicyDate.MinDate = -657434;
			this.txtPolicyDate.Name = "txtPolicyDate";
			// = "_";
			this.txtPolicyDate.Size = new System.Drawing.Size(97, 19);
			this.txtPolicyDate.TabIndex = 27;
			// this.txtPolicyDate.Text = "10-Dec-2008";
			// this.txtPolicyDate.Value = 39792;
			// 
			// txtArrivalDate
			// 
			this.txtArrivalDate.AllowDrop = true;
			this.txtArrivalDate.Location = new System.Drawing.Point(86, 248);
			// this.txtArrivalDate.MaxDate = 2958465;
			// this.txtArrivalDate.MinDate = -657434;
			this.txtArrivalDate.Name = "txtArrivalDate";
			// = "_";
			this.txtArrivalDate.Size = new System.Drawing.Size(97, 19);
			this.txtArrivalDate.TabIndex = 28;
			// this.txtArrivalDate.Text = "10-Dec-2008";
			// this.txtArrivalDate.Value = 39792;
			// 
			// txtAmendment1
			// 
			this.txtAmendment1.AllowDrop = true;
			this.txtAmendment1.Location = new System.Drawing.Point(286, 226);
			// this.txtAmendment1.MaxDate = 2958465;
			// this.txtAmendment1.MinDate = -657434;
			this.txtAmendment1.Name = "txtAmendment1";
			// = "_";
			this.txtAmendment1.Size = new System.Drawing.Size(97, 19);
			this.txtAmendment1.TabIndex = 30;
			this.txtAmendment1.Text = "10-Dec-2008";
			// this.txtAmendment1.Value = 39792;
			// 
			// txtAmendment2
			// 
			this.txtAmendment2.AllowDrop = true;
			this.txtAmendment2.Location = new System.Drawing.Point(386, 226);
			// this.txtAmendment2.MaxDate = 2958465;
			// this.txtAmendment2.MinDate = -657434;
			this.txtAmendment2.Name = "txtAmendment2";
			// = "_";
			this.txtAmendment2.Size = new System.Drawing.Size(97, 19);
			this.txtAmendment2.TabIndex = 31;
			this.txtAmendment2.Text = "10-Dec-2008";
			// this.txtAmendment2.Value = 39792;
			// 
			// txtAmendment3
			// 
			this.txtAmendment3.AllowDrop = true;
			this.txtAmendment3.Location = new System.Drawing.Point(486, 226);
			// this.txtAmendment3.MaxDate = 2958465;
			// this.txtAmendment3.MinDate = -657434;
			this.txtAmendment3.Name = "txtAmendment3";
			// = "_";
			this.txtAmendment3.Size = new System.Drawing.Size(97, 19);
			this.txtAmendment3.TabIndex = 32;
			this.txtAmendment3.Text = "10-Dec-2008";
			// this.txtAmendment3.Value = 39792;
			// 
			// TextBox_9
			// 
			this.TextBox_9.AllowDrop = true;
			this.TextBox_9.BackColor = System.Drawing.Color.White;
			// = false;
			this.TextBox_9.ForeColor = System.Drawing.Color.Black;
			this.TextBox_9.Location = new System.Drawing.Point(286, 248);
			// = (System.Windows.Forms.TextBox.DropDownTypes) 0;
			this.TextBox_9.Name = "TextBox_9";
			this.TextBox_9.Size = new System.Drawing.Size(113, 19);
			this.TextBox_9.TabIndex = 33;
			this.TextBox_9.Text = "";
			// = "";
			//this.TextBox_9.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(//this.TextBox_DropButtonClick);
			// 
			// TextBox1_1
			// 
			this.TextBox1_1.AllowDrop = true;
			this.TextBox1_1.Enabled = false;
			this.TextBox1_1.ForeColor = System.Drawing.SystemColors.WindowText;
			this.TextBox1_1.Location = new System.Drawing.Point(92, 518);
			this.TextBox1_1.Name = "TextBox1_1";
			this.TextBox1_1.Size = new System.Drawing.Size(113, 19);
			this.TextBox1_1.TabIndex = 42;
			// 
			// TextBox1_2
			// 
			this.TextBox1_2.AllowDrop = true;
			this.TextBox1_2.Enabled = false;
			this.TextBox1_2.ForeColor = System.Drawing.SystemColors.WindowText;
			this.TextBox1_2.Location = new System.Drawing.Point(92, 540);
			this.TextBox1_2.Name = "TextBox1_2";
			this.TextBox1_2.Size = new System.Drawing.Size(113, 19);
			this.TextBox1_2.TabIndex = 43;
			// 
			// TextBox1_3
			// 
			this.TextBox1_3.AllowDrop = true;
			this.TextBox1_3.ForeColor = System.Drawing.SystemColors.WindowText;
			this.TextBox1_3.Location = new System.Drawing.Point(472, 496);
			this.TextBox1_3.Name = "TextBox1_3";
			this.TextBox1_3.Size = new System.Drawing.Size(113, 19);
			this.TextBox1_3.TabIndex = 44;
			// 
			// TextBox1_4
			// 
			this.TextBox1_4.AllowDrop = true;
			this.TextBox1_4.ForeColor = System.Drawing.SystemColors.WindowText;
			this.TextBox1_4.Location = new System.Drawing.Point(472, 518);
			this.TextBox1_4.Name = "TextBox1_4";
			this.TextBox1_4.Size = new System.Drawing.Size(113, 19);
			this.TextBox1_4.TabIndex = 46;
			// 
			// _Label1_19
			// 
			this._Label1_19.AllowDrop = true;
			this._Label1_19.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._Label1_19.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._Label1_19.ForeColor = System.Drawing.SystemColors.ControlText;
			this._Label1_19.Location = new System.Drawing.Point(388, 520);
			this._Label1_19.Name = "_Label1_19";
			this._Label1_19.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._Label1_19.Size = new System.Drawing.Size(81, 14);
			this._Label1_19.TabIndex = 47;
			this._Label1_19.Text = "Cheque Exp.:";
			// 
			// _Label1_18
			// 
			this._Label1_18.AllowDrop = true;
			this._Label1_18.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._Label1_18.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._Label1_18.ForeColor = System.Drawing.SystemColors.ControlText;
			this._Label1_18.Location = new System.Drawing.Point(388, 498);
			this._Label1_18.Name = "_Label1_18";
			this._Label1_18.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._Label1_18.Size = new System.Drawing.Size(81, 14);
			this._Label1_18.TabIndex = 45;
			this._Label1_18.Text = "Cash Exp.:";
			// 
			// _Label1_17
			// 
			this._Label1_17.AllowDrop = true;
			this._Label1_17.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._Label1_17.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._Label1_17.ForeColor = System.Drawing.SystemColors.ControlText;
			this._Label1_17.Location = new System.Drawing.Point(8, 542);
			this._Label1_17.Name = "_Label1_17";
			this._Label1_17.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._Label1_17.Size = new System.Drawing.Size(81, 14);
			this._Label1_17.TabIndex = 40;
			this._Label1_17.Text = "Exp. Ratio:";
			// 
			// _Label1_16
			// 
			this._Label1_16.AllowDrop = true;
			this._Label1_16.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._Label1_16.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._Label1_16.ForeColor = System.Drawing.SystemColors.ControlText;
			this._Label1_16.Location = new System.Drawing.Point(8, 520);
			this._Label1_16.Name = "_Label1_16";
			this._Label1_16.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._Label1_16.Size = new System.Drawing.Size(81, 14);
			this._Label1_16.TabIndex = 39;
			this._Label1_16.Text = "Expenses Value:";
			// 
			// _Label1_15
			// 
			this._Label1_15.AllowDrop = true;
			this._Label1_15.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._Label1_15.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._Label1_15.ForeColor = System.Drawing.SystemColors.ControlText;
			this._Label1_15.Location = new System.Drawing.Point(8, 498);
			this._Label1_15.Name = "_Label1_15";
			this._Label1_15.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._Label1_15.Size = new System.Drawing.Size(81, 14);
			this._Label1_15.TabIndex = 38;
			this._Label1_15.Text = "Total Amount:";
			// 
			// _Label1_14
			// 
			this._Label1_14.AllowDrop = true;
			this._Label1_14.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._Label1_14.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._Label1_14.ForeColor = System.Drawing.SystemColors.ControlText;
			this._Label1_14.Location = new System.Drawing.Point(10, 270);
			this._Label1_14.Name = "_Label1_14";
			this._Label1_14.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._Label1_14.Size = new System.Drawing.Size(73, 14);
			this._Label1_14.TabIndex = 36;
			this._Label1_14.Text = "Notes:";
			// 
			// _Label1_13
			// 
			this._Label1_13.AllowDrop = true;
			this._Label1_13.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._Label1_13.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._Label1_13.ForeColor = System.Drawing.SystemColors.ControlText;
			this._Label1_13.Location = new System.Drawing.Point(210, 250);
			this._Label1_13.Name = "_Label1_13";
			this._Label1_13.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._Label1_13.Size = new System.Drawing.Size(73, 14);
			this._Label1_13.TabIndex = 34;
			this._Label1_13.Text = "L.C. Account No:";
			// 
			// _Label1_12
			// 
			this._Label1_12.AllowDrop = true;
			this._Label1_12.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._Label1_12.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._Label1_12.ForeColor = System.Drawing.SystemColors.ControlText;
			this._Label1_12.Location = new System.Drawing.Point(210, 228);
			this._Label1_12.Name = "_Label1_12";
			this._Label1_12.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._Label1_12.Size = new System.Drawing.Size(73, 14);
			this._Label1_12.TabIndex = 29;
			this._Label1_12.Text = "Amendment:";
			// 
			// _Label1_11
			// 
			this._Label1_11.AllowDrop = true;
			this._Label1_11.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._Label1_11.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._Label1_11.ForeColor = System.Drawing.SystemColors.ControlText;
			this._Label1_11.Location = new System.Drawing.Point(10, 250);
			this._Label1_11.Name = "_Label1_11";
			this._Label1_11.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._Label1_11.Size = new System.Drawing.Size(73, 14);
			this._Label1_11.TabIndex = 26;
			this._Label1_11.Text = "Arrival Date:";
			// 
			// _Label1_10
			// 
			this._Label1_10.AllowDrop = true;
			this._Label1_10.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._Label1_10.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._Label1_10.ForeColor = System.Drawing.SystemColors.ControlText;
			this._Label1_10.Location = new System.Drawing.Point(10, 228);
			this._Label1_10.Name = "_Label1_10";
			this._Label1_10.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._Label1_10.Size = new System.Drawing.Size(73, 14);
			this._Label1_10.TabIndex = 25;
			this._Label1_10.Text = "Policy Date:";
			// 
			// _Label1_9
			// 
			this._Label1_9.AllowDrop = true;
			this._Label1_9.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._Label1_9.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._Label1_9.ForeColor = System.Drawing.SystemColors.ControlText;
			this._Label1_9.Location = new System.Drawing.Point(210, 206);
			this._Label1_9.Name = "_Label1_9";
			this._Label1_9.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._Label1_9.Size = new System.Drawing.Size(73, 14);
			this._Label1_9.TabIndex = 24;
			this._Label1_9.Text = "CIF/C F/FOB:";
			// 
			// _Label1_8
			// 
			this._Label1_8.AllowDrop = true;
			this._Label1_8.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._Label1_8.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._Label1_8.ForeColor = System.Drawing.SystemColors.ControlText;
			this._Label1_8.Location = new System.Drawing.Point(10, 206);
			this._Label1_8.Name = "_Label1_8";
			this._Label1_8.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._Label1_8.Size = new System.Drawing.Size(73, 14);
			this._Label1_8.TabIndex = 22;
			this._Label1_8.Text = "Policy Co.:";
			// 
			// _Label1_7
			// 
			this._Label1_7.AllowDrop = true;
			this._Label1_7.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._Label1_7.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._Label1_7.ForeColor = System.Drawing.SystemColors.ControlText;
			this._Label1_7.Location = new System.Drawing.Point(210, 184);
			this._Label1_7.Name = "_Label1_7";
			this._Label1_7.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._Label1_7.Size = new System.Drawing.Size(73, 14);
			this._Label1_7.TabIndex = 19;
			this._Label1_7.Text = "Bank:";
			// 
			// _Label1_6
			// 
			this._Label1_6.AllowDrop = true;
			this._Label1_6.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._Label1_6.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._Label1_6.ForeColor = System.Drawing.SystemColors.ControlText;
			this._Label1_6.Location = new System.Drawing.Point(10, 184);
			this._Label1_6.Name = "_Label1_6";
			this._Label1_6.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._Label1_6.Size = new System.Drawing.Size(73, 14);
			this._Label1_6.TabIndex = 17;
			this._Label1_6.Text = "Insurance Co.:";
			// 
			// _Label1_5
			// 
			this._Label1_5.AllowDrop = true;
			this._Label1_5.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._Label1_5.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._Label1_5.ForeColor = System.Drawing.SystemColors.ControlText;
			this._Label1_5.Location = new System.Drawing.Point(10, 162);
			this._Label1_5.Name = "_Label1_5";
			this._Label1_5.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._Label1_5.Size = new System.Drawing.Size(73, 14);
			this._Label1_5.TabIndex = 15;
			this._Label1_5.Text = "Vessel:";
			// 
			// _Label1_4
			// 
			this._Label1_4.AllowDrop = true;
			this._Label1_4.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._Label1_4.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._Label1_4.ForeColor = System.Drawing.SystemColors.ControlText;
			this._Label1_4.Location = new System.Drawing.Point(4, 140);
			this._Label1_4.Name = "_Label1_4";
			this._Label1_4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._Label1_4.Size = new System.Drawing.Size(79, 14);
			this._Label1_4.TabIndex = 13;
			this._Label1_4.Text = "Port of Landing:";
			// 
			// _Label1_3
			// 
			this._Label1_3.AllowDrop = true;
			this._Label1_3.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._Label1_3.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._Label1_3.ForeColor = System.Drawing.SystemColors.ControlText;
			this._Label1_3.Location = new System.Drawing.Point(10, 118);
			this._Label1_3.Name = "_Label1_3";
			this._Label1_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._Label1_3.Size = new System.Drawing.Size(73, 14);
			this._Label1_3.TabIndex = 11;
			this._Label1_3.Text = "Shipping Way:";
			// 
			// _Label1_2
			// 
			this._Label1_2.AllowDrop = true;
			this._Label1_2.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._Label1_2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._Label1_2.ForeColor = System.Drawing.SystemColors.ControlText;
			this._Label1_2.Location = new System.Drawing.Point(10, 58);
			this._Label1_2.Name = "_Label1_2";
			this._Label1_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._Label1_2.Size = new System.Drawing.Size(73, 14);
			this._Label1_2.TabIndex = 9;
			this._Label1_2.Text = "Goods:";
			// 
			// _Label1_1
			// 
			this._Label1_1.AllowDrop = true;
			this._Label1_1.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._Label1_1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._Label1_1.ForeColor = System.Drawing.SystemColors.ControlText;
			this._Label1_1.Location = new System.Drawing.Point(200, 36);
			this._Label1_1.Name = "_Label1_1";
			this._Label1_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._Label1_1.Size = new System.Drawing.Size(73, 14);
			this._Label1_1.TabIndex = 6;
			this._Label1_1.Text = "Supplier:";
			// 
			// _Label1_0
			// 
			this._Label1_0.AllowDrop = true;
			this._Label1_0.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._Label1_0.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._Label1_0.ForeColor = System.Drawing.SystemColors.ControlText;
			this._Label1_0.Location = new System.Drawing.Point(200, 16);
			this._Label1_0.Name = "_Label1_0";
			this._Label1_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._Label1_0.Size = new System.Drawing.Size(73, 14);
			this._Label1_0.TabIndex = 4;
			this._Label1_0.Text = "L.C.Number:";
			// 
			// lblExpDate
			// 
			this.lblExpDate.AllowDrop = true;
			this.lblExpDate.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblExpDate.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lblExpDate.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblExpDate.Location = new System.Drawing.Point(10, 36);
			this.lblExpDate.Name = "lblExpDate";
			this.lblExpDate.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblExpDate.Size = new System.Drawing.Size(73, 14);
			this.lblExpDate.TabIndex = 2;
			// this.lblExpDate.Text = "Expiry Date:";
			// 
			// lblDate
			// 
			this.lblDate.AllowDrop = true;
			this.lblDate.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblDate.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lblDate.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblDate.Location = new System.Drawing.Point(10, 14);
			this.lblDate.Name = "lblDate";
			this.lblDate.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblDate.Size = new System.Drawing.Size(73, 14);
			this.lblDate.TabIndex = 0;
			// this.lblDate.Text = "Date of Credit:";
			// 
			// frmICSLetterOfCredit
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.ClientSize = new System.Drawing.Size(597, 619);
			this.Controls.Add(this.cmbParentsList);
			this.Controls.Add(this.TextBox1_0);
			this.Controls.Add(this.grdLC);
			this.Controls.Add(this.txtNotes);
			this.Controls.Add(this.txtGoods);
			this.Controls.Add(this.TextBox_0);
			this.Controls.Add(this.txtDateOfCredit);
			this.Controls.Add(this.txtExpiryDate);
			this.Controls.Add(this.TextBox_1);
			this.Controls.Add(this.txtSupplierName);
			this.Controls.Add(this.TextBox_2);
			this.Controls.Add(this.TextBox_3);
			this.Controls.Add(this.TextBox_4);
			this.Controls.Add(this.TextBox_5);
			this.Controls.Add(this.TextBox_6);
			this.Controls.Add(this.TextBox_7);
			this.Controls.Add(this.TextBox_8);
			this.Controls.Add(this.txtPolicyDate);
			this.Controls.Add(this.txtArrivalDate);
			this.Controls.Add(this.txtAmendment1);
			this.Controls.Add(this.txtAmendment2);
			this.Controls.Add(this.txtAmendment3);
			this.Controls.Add(this.TextBox_9);
			this.Controls.Add(this.TextBox1_1);
			this.Controls.Add(this.TextBox1_2);
			this.Controls.Add(this.TextBox1_3);
			this.Controls.Add(this.TextBox1_4);
			this.Controls.Add(this._Label1_19);
			this.Controls.Add(this._Label1_18);
			this.Controls.Add(this._Label1_17);
			this.Controls.Add(this._Label1_16);
			this.Controls.Add(this._Label1_15);
			this.Controls.Add(this._Label1_14);
			this.Controls.Add(this._Label1_13);
			this.Controls.Add(this._Label1_12);
			this.Controls.Add(this._Label1_11);
			this.Controls.Add(this._Label1_10);
			this.Controls.Add(this._Label1_9);
			this.Controls.Add(this._Label1_8);
			this.Controls.Add(this._Label1_7);
			this.Controls.Add(this._Label1_6);
			this.Controls.Add(this._Label1_5);
			this.Controls.Add(this._Label1_4);
			this.Controls.Add(this._Label1_3);
			this.Controls.Add(this._Label1_2);
			this.Controls.Add(this._Label1_1);
			this.Controls.Add(this._Label1_0);
			this.Controls.Add(this.lblExpDate);
			this.Controls.Add(this.lblDate);
			//this.Icon = (System.Drawing.Icon) resources.GetObject("frmICSLetterOfCredit.Icon");
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(455, 120);
			this.MaximizeBox = true;
			this.MinimizeBox = true;
			this.Name = "frmICSLetterOfCredit";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Letter of Credit";
			// this.Activated += new System.EventHandler(this.frmICSLetterOfCredit_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
			// this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
			this.cmbParentsList.ResumeLayout(false);
			this.grdLC.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		// 
		void InitializeSystemWindowsFormsTextBox()
		{
			this.TextBox = new System.Windows.Forms.TextBox[10];
			this.TextBox[0] = TextBox_0;
			this.TextBox[1] = TextBox_1;
			this.TextBox[2] = TextBox_2;
			this.TextBox[3] = TextBox_3;
			this.TextBox[4] = TextBox_4;
			this.TextBox[5] = TextBox_5;
			this.TextBox[6] = TextBox_6;
			this.TextBox[7] = TextBox_7;
			this.TextBox[8] = TextBox_8;
			this.TextBox[9] = TextBox_9;
		}
		void InitializeSystemWindowsFormsTextBox1()
		{
			this.TextBox1 = new System.Windows.Forms.TextBox[5];
			this.TextBox1[0] = TextBox1_0;
			this.TextBox1[1] = TextBox1_1;
			this.TextBox1[2] = TextBox1_2;
			this.TextBox1[3] = TextBox1_3;
			this.TextBox1[4] = TextBox1_4;
		}
		void InitializeLabel1()
		{
			this.Label1 = new System.Windows.Forms.Label[20];
			this.Label1[19] = _Label1_19;
			this.Label1[18] = _Label1_18;
			this.Label1[17] = _Label1_17;
			this.Label1[16] = _Label1_16;
			this.Label1[15] = _Label1_15;
			this.Label1[14] = _Label1_14;
			this.Label1[13] = _Label1_13;
			this.Label1[12] = _Label1_12;
			this.Label1[11] = _Label1_11;
			this.Label1[10] = _Label1_10;
			this.Label1[9] = _Label1_9;
			this.Label1[8] = _Label1_8;
			this.Label1[7] = _Label1_7;
			this.Label1[6] = _Label1_6;
			this.Label1[5] = _Label1_5;
			this.Label1[4] = _Label1_4;
			this.Label1[3] = _Label1_3;
			this.Label1[2] = _Label1_2;
			this.Label1[1] = _Label1_1;
			this.Label1[0] = _Label1_0;
		}
		#endregion
	}
}//ENDSHERE
