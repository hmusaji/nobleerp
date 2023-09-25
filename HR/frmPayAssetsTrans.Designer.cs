
namespace Xtreme
{
	partial class frmPayAssetsTrans
	{

		#region "Upgrade Support "
		private static frmPayAssetsTrans m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmPayAssetsTrans DefInstance
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
		public static frmPayAssetsTrans CreateInstance()
		{
			frmPayAssetsTrans theInstance = new frmPayAssetsTrans();
			
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
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "_txtDisplayLabel_0", "_lblCommonLabel_6", "txtTransDate", "_lblCommonLabel_5", "_txtCommonTextBox_0", "_lblCommonLabel_1", "_txtCommonTextBox_2", "_txtCommonTextBox_3", "_lblCommonLabel_0", "_lblCommonLabel_2", "_cmbCommon_0", "Column_0_cmbMastersList", "Column_1_cmbMastersList", "cmbMastersList", "Column_0_grdAssetTransDetails", "Column_1_grdAssetTransDetails", "grdAssetTransDetails", "cmbCommon", "lblCommonLabel", "txtCommonTextBox", "txtDisplayLabel"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		private System.Windows.Forms.Label _txtDisplayLabel_0;
		private System.Windows.Forms.Label _lblCommonLabel_6;
		public Syncfusion.WinForms.Input.SfDateTimeEdit txtTransDate;
		private System.Windows.Forms.Label _lblCommonLabel_5;
		private System.Windows.Forms.TextBox _txtCommonTextBox_0;
		private System.Windows.Forms.Label _lblCommonLabel_1;
		private System.Windows.Forms.TextBox _txtCommonTextBox_2;
		private System.Windows.Forms.TextBox _txtCommonTextBox_3;
		private System.Windows.Forms.Label _lblCommonLabel_0;
		private System.Windows.Forms.Label _lblCommonLabel_2;
		private System.Windows.Forms.ComboBox _cmbCommon_0;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_0_cmbMastersList;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_1_cmbMastersList;
		public C1.Win.C1TrueDBGrid.C1TrueDBDropdown cmbMastersList;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_0_grdAssetTransDetails;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_1_grdAssetTransDetails;
		public C1.Win.C1TrueDBGrid.C1TrueDBGrid grdAssetTransDetails;
		public System.Windows.Forms.ComboBox[] cmbCommon = new System.Windows.Forms.ComboBox[1];
		public System.Windows.Forms.Label[] lblCommonLabel = new System.Windows.Forms.Label[7];
		public System.Windows.Forms.TextBox[] txtCommonTextBox = new System.Windows.Forms.TextBox[4];
		public System.Windows.Forms.Label[] txtDisplayLabel = new System.Windows.Forms.Label[1];
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPayAssetsTrans));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this._txtDisplayLabel_0 = new System.Windows.Forms.Label();
			this._lblCommonLabel_6 = new System.Windows.Forms.Label();
			this.txtTransDate = new Syncfusion.WinForms.Input.SfDateTimeEdit();
			this._lblCommonLabel_5 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_0 = new System.Windows.Forms.TextBox();
			this._lblCommonLabel_1 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_2 = new System.Windows.Forms.TextBox();
			this._txtCommonTextBox_3 = new System.Windows.Forms.TextBox();
			this._lblCommonLabel_0 = new System.Windows.Forms.Label();
			this._lblCommonLabel_2 = new System.Windows.Forms.Label();
			this._cmbCommon_0 = new System.Windows.Forms.ComboBox();
			this.cmbMastersList = new C1.Win.C1TrueDBGrid.C1TrueDBDropdown();
			this.Column_0_cmbMastersList = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.Column_1_cmbMastersList = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.grdAssetTransDetails = new C1.Win.C1TrueDBGrid.C1TrueDBGrid();
			this.Column_0_grdAssetTransDetails = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.Column_1_grdAssetTransDetails = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.cmbMastersList.SuspendLayout();
			this.grdAssetTransDetails.SuspendLayout();
			this.SuspendLayout();
			// 
			// _txtDisplayLabel_0
			// 
			this._txtDisplayLabel_0.AllowDrop = true;
			this._txtDisplayLabel_0.BackColor = System.Drawing.SystemColors.Window;
			this._txtDisplayLabel_0.Enabled = false;
			this._txtDisplayLabel_0.Location = new System.Drawing.Point(198, 96);
			this._txtDisplayLabel_0.Name = "_txtDisplayLabel_0";
			this._txtDisplayLabel_0.Size = new System.Drawing.Size(337, 19);
			this._txtDisplayLabel_0.TabIndex = 9;
			// 
			// _lblCommonLabel_6
			// 
			this._lblCommonLabel_6.AllowDrop = true;
			this._lblCommonLabel_6.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_6.Text = "Transaction Date";
			this._lblCommonLabel_6.Location = new System.Drawing.Point(338, 52);
			// // this._lblCommonLabel_6.mLabelId = 1233;
			this._lblCommonLabel_6.Name = "_lblCommonLabel_6";
			this._lblCommonLabel_6.Size = new System.Drawing.Size(82, 14);
			this._lblCommonLabel_6.TabIndex = 6;
			// 
			// txtTransDate
			// 
			this.txtTransDate.AllowDrop = true;
			// this.txtTransDate.CheckDateRange = false;
			this.txtTransDate.Location = new System.Drawing.Point(431, 50);
			// this.txtTransDate.MaxDate = 2958465;
			// this.txtTransDate.MinDate = 32874;
			this.txtTransDate.Name = "txtTransDate";
			this.txtTransDate.Size = new System.Drawing.Size(102, 19);
			this.txtTransDate.TabIndex = 1;
			this.txtTransDate.Text = "18/07/2001";
			// this.txtTransDate.Value = 37090;
			// 
			// _lblCommonLabel_5
			// 
			this._lblCommonLabel_5.AllowDrop = true;
			this._lblCommonLabel_5.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_5.Text = "Transaction No.";
			this._lblCommonLabel_5.Location = new System.Drawing.Point(2, 52);
			// // this._lblCommonLabel_5.mLabelId = 1744;
			this._lblCommonLabel_5.Name = "_lblCommonLabel_5";
			this._lblCommonLabel_5.Size = new System.Drawing.Size(76, 14);
			this._lblCommonLabel_5.TabIndex = 7;
			// 
			// _txtCommonTextBox_0
			// 
			this._txtCommonTextBox_0.AllowDrop = true;
			this._txtCommonTextBox_0.BackColor = System.Drawing.Color.White;
			// this._txtCommonTextBox_0.bolNumericOnly = true;
			this._txtCommonTextBox_0.CausesValidation = false;
			this._txtCommonTextBox_0.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_0.Location = new System.Drawing.Point(90, 50);
			// this._txtCommonTextBox_0.mDropDownType = System.Windows.Forms.TextBox.DropDownTypes.ddtNextNumber;
			this._txtCommonTextBox_0.Name = "_txtCommonTextBox_0";
			// this._txtCommonTextBox_0.ShowButton = true;
			this._txtCommonTextBox_0.Size = new System.Drawing.Size(107, 19);
			this._txtCommonTextBox_0.TabIndex = 0;
			this._txtCommonTextBox_0.Text = "";
			// this.this._txtCommonTextBox_0.Watermark = "";
			// this.this._txtCommonTextBox_0.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_0.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _lblCommonLabel_1
			// 
			this._lblCommonLabel_1.AllowDrop = true;
			this._lblCommonLabel_1.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_1.Text = "Employee Code";
			this._lblCommonLabel_1.Location = new System.Drawing.Point(2, 98);
			// // this._lblCommonLabel_1.mLabelId = 236;
			this._lblCommonLabel_1.Name = "_lblCommonLabel_1";
			this._lblCommonLabel_1.Size = new System.Drawing.Size(74, 14);
			this._lblCommonLabel_1.TabIndex = 8;
			// 
			// _txtCommonTextBox_2
			// 
			this._txtCommonTextBox_2.AllowDrop = true;
			this._txtCommonTextBox_2.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_2.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_2.Location = new System.Drawing.Point(90, 96);
			// this._txtCommonTextBox_2.mDropDownType = System.Windows.Forms.TextBox.DropDownTypes.ddtNextNumber;
			this._txtCommonTextBox_2.Name = "_txtCommonTextBox_2";
			// this._txtCommonTextBox_2.ShowButton = true;
			this._txtCommonTextBox_2.Size = new System.Drawing.Size(107, 19);
			this._txtCommonTextBox_2.TabIndex = 3;
			this._txtCommonTextBox_2.TabStop = false;
			this._txtCommonTextBox_2.Text = "";
			// this.this._txtCommonTextBox_2.Watermark = "";
			// this.this._txtCommonTextBox_2.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_2.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _txtCommonTextBox_3
			// 
			this._txtCommonTextBox_3.AllowDrop = true;
			this._txtCommonTextBox_3.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_3.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_3.Location = new System.Drawing.Point(90, 118);
			// this._txtCommonTextBox_3.mDropDownType = System.Windows.Forms.TextBox.DropDownTypes.ddtNextNumber;
			this._txtCommonTextBox_3.Name = "_txtCommonTextBox_3";
			this._txtCommonTextBox_3.Size = new System.Drawing.Size(445, 19);
			this._txtCommonTextBox_3.TabIndex = 4;
			this._txtCommonTextBox_3.TabStop = false;
			this._txtCommonTextBox_3.Text = "";
			// this.this._txtCommonTextBox_3.Watermark = "";
			// this.this._txtCommonTextBox_3.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_3.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _lblCommonLabel_0
			// 
			this._lblCommonLabel_0.AllowDrop = true;
			this._lblCommonLabel_0.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_0.Text = "Transaction Type";
			this._lblCommonLabel_0.Location = new System.Drawing.Point(2, 74);
			// // this._lblCommonLabel_0.mLabelId = 872;
			this._lblCommonLabel_0.Name = "_lblCommonLabel_0";
			this._lblCommonLabel_0.Size = new System.Drawing.Size(84, 14);
			this._lblCommonLabel_0.TabIndex = 10;
			// 
			// _lblCommonLabel_2
			// 
			this._lblCommonLabel_2.AllowDrop = true;
			this._lblCommonLabel_2.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_2.Text = "Remarks";
			this._lblCommonLabel_2.Location = new System.Drawing.Point(4, 120);
			// // this._lblCommonLabel_2.mLabelId = 1990;
			this._lblCommonLabel_2.Name = "_lblCommonLabel_2";
			this._lblCommonLabel_2.Size = new System.Drawing.Size(42, 14);
			this._lblCommonLabel_2.TabIndex = 11;
			// 
			// _cmbCommon_0
			// 
			this._cmbCommon_0.AllowDrop = true;
			this._cmbCommon_0.Location = new System.Drawing.Point(90, 72);
			this._cmbCommon_0.Name = "_cmbCommon_0";
			this._cmbCommon_0.Size = new System.Drawing.Size(107, 21);
			this._cmbCommon_0.TabIndex = 2;
			// this._cmbCommon_0.Leave += new System.EventHandler(this.cmbCommon_Leave);
			// 
			// cmbMastersList
			// 
			this.cmbMastersList.AllowDrop = true;
			this.cmbMastersList.ColumnHeaders = true;
			this.cmbMastersList.Enabled = true;
			this.cmbMastersList.Location = new System.Drawing.Point(8, 340);
			this.cmbMastersList.Name = "cmbMastersList";
			this.cmbMastersList.Size = new System.Drawing.Size(53, 37);
			this.cmbMastersList.TabIndex = 12;
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
			// grdAssetTransDetails
			// 
			this.grdAssetTransDetails.AllowDrop = true;
			this.grdAssetTransDetails.BackColor = System.Drawing.Color.FromArgb(212, 208, 200);
			this.grdAssetTransDetails.CellTipsWidth = 0;
			this.grdAssetTransDetails.Location = new System.Drawing.Point(4, 144);
			this.grdAssetTransDetails.Name = "grdAssetTransDetails";
			this.grdAssetTransDetails.RowDivider.Color = System.Drawing.Color.FromArgb(212, 208, 200);
			this.grdAssetTransDetails.Size = new System.Drawing.Size(531, 235);
			this.grdAssetTransDetails.TabIndex = 5;
			this.grdAssetTransDetails.Columns.Add(this.Column_0_grdAssetTransDetails);
			this.grdAssetTransDetails.Columns.Add(this.Column_1_grdAssetTransDetails);
			this.grdAssetTransDetails.GotFocus += new System.EventHandler(this.grdAssetTransDetails_GotFocus);
			this.grdAssetTransDetails.RowColChange += new C1.Win.C1TrueDBGrid.RowColChangeEventHandler(this.grdAssetTransDetails_RowColChange);
			// 
			// Column_0_grdAssetTransDetails
			// 
			this.Column_0_grdAssetTransDetails.DataField = "";
			this.Column_0_grdAssetTransDetails.ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.Normal;
			// 
			// Column_1_grdAssetTransDetails
			// 
			this.Column_1_grdAssetTransDetails.DataField = "";
			this.Column_1_grdAssetTransDetails.ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.Normal;
			// 
			// frmPayAssetsTrans
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.ClientSize = new System.Drawing.Size(538, 383);
			this.Controls.Add(this._txtDisplayLabel_0);
			this.Controls.Add(this._lblCommonLabel_6);
			this.Controls.Add(this.txtTransDate);
			this.Controls.Add(this._lblCommonLabel_5);
			this.Controls.Add(this._txtCommonTextBox_0);
			this.Controls.Add(this._lblCommonLabel_1);
			this.Controls.Add(this._txtCommonTextBox_2);
			this.Controls.Add(this._txtCommonTextBox_3);
			this.Controls.Add(this._lblCommonLabel_0);
			this.Controls.Add(this._lblCommonLabel_2);
			this.Controls.Add(this._cmbCommon_0);
			this.Controls.Add(this.cmbMastersList);
			this.Controls.Add(this.grdAssetTransDetails);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			//this.Icon = (System.Drawing.Icon) resources.GetObject("frmPayAssetsTrans.Icon");
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(407, 192);
			this.MaximizeBox = true;
			this.MinimizeBox = true;
			this.Name = "frmPayAssetsTrans";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Assets Transaction";
			// this.Activated += new System.EventHandler(this.frmPayAssetsTrans_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
			// this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
			this.cmbMastersList.ResumeLayout(false);
			this.grdAssetTransDetails.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		void ReLoadForm(bool addEvents)
		{
			InitializetxtDisplayLabel();
			InitializetxtCommonTextBox();
			InitializelblCommonLabel();
			InitializecmbCommon();
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
			this.txtDisplayLabel = new System.Windows.Forms.Label[1];
			this.txtDisplayLabel[0] = _txtDisplayLabel_0;
		}
		void InitializetxtCommonTextBox()
		{
			this.txtCommonTextBox = new System.Windows.Forms.TextBox[4];
			this.txtCommonTextBox[0] = _txtCommonTextBox_0;
			this.txtCommonTextBox[2] = _txtCommonTextBox_2;
			this.txtCommonTextBox[3] = _txtCommonTextBox_3;
		}
		void InitializelblCommonLabel()
		{
			this.lblCommonLabel = new System.Windows.Forms.Label[7];
			this.lblCommonLabel[6] = _lblCommonLabel_6;
			this.lblCommonLabel[5] = _lblCommonLabel_5;
			this.lblCommonLabel[1] = _lblCommonLabel_1;
			this.lblCommonLabel[0] = _lblCommonLabel_0;
			this.lblCommonLabel[2] = _lblCommonLabel_2;
		}
		void InitializecmbCommon()
		{
			this.cmbCommon = new System.Windows.Forms.ComboBox[1];
			this.cmbCommon[0] = _cmbCommon_0;
		}
		#endregion
	}
}//ENDSHERE
