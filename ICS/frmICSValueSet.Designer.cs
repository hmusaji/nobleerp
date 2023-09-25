
namespace Xtreme
{
	partial class frmICSValueSet
	{

		#region "Upgrade Support "
		private static frmICSValueSet m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmICSValueSet DefInstance
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
		public static frmICSValueSet CreateInstance()
		{
			frmICSValueSet theInstance = new frmICSValueSet();
			
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
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "cmbSetObject", "_txtCommonTextBox_11", "_lblCommonLabel_9", "_lblCommonLabel_12", "Column_0_cmbMastersList", "Column_1_cmbMastersList", "cmbMastersList", "_lblCommonLabel_2", "_lblCommonLabel_5", "_lblCommonLabel_21", "System.Windows.Forms.Label12", "_txtCommonTextBox_2", "_lblCommonLabel_0", "_txtCommonTextBox_0", "_lblCommonLabel_3", "Column_0_grdVoucherDetails", "Column_1_grdVoucherDetails", "grdVoucherDetails", "_txtCommonTextBox_1", "_txtCommonTextBox_4", "_txtCommonTextBox_3", "cmbSetCode", "_lblCommonLabel_1", "lblCommonLabel", "txtCommonTextBox"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public System.Windows.Forms.ComboBox cmbSetObject;
		private System.Windows.Forms.TextBox _txtCommonTextBox_11;
		private System.Windows.Forms.Label _lblCommonLabel_9;
		private System.Windows.Forms.Label _lblCommonLabel_12;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_0_cmbMastersList;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_1_cmbMastersList;
		public C1.Win.C1TrueDBGrid.C1TrueDBDropdown cmbMastersList;
		private System.Windows.Forms.Label _lblCommonLabel_2;
		private System.Windows.Forms.Label _lblCommonLabel_5;
		private System.Windows.Forms.Label _lblCommonLabel_21;
		public System.Windows.Forms.Label System.Windows.Forms.Label12;
		private System.Windows.Forms.TextBox _txtCommonTextBox_2;
		private System.Windows.Forms.Label _lblCommonLabel_0;
		private System.Windows.Forms.TextBox _txtCommonTextBox_0;
		private System.Windows.Forms.Label _lblCommonLabel_3;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_0_grdVoucherDetails;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_1_grdVoucherDetails;
		public C1.Win.C1TrueDBGrid.C1TrueDBGrid grdVoucherDetails;
		private System.Windows.Forms.TextBox _txtCommonTextBox_1;
		private System.Windows.Forms.TextBox _txtCommonTextBox_4;
		private System.Windows.Forms.TextBox _txtCommonTextBox_3;
		public System.Windows.Forms.ComboBox cmbSetCode;
		private System.Windows.Forms.Label _lblCommonLabel_1;
		public System.Windows.Forms.Label[] lblCommonLabel = new System.Windows.Forms.Label[22];
		public System.Windows.Forms.TextBox[] txtCommonTextBox = new System.Windows.Forms.TextBox[12];
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmICSValueSet));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this.cmbSetObject = new System.Windows.Forms.ComboBox();
			this._txtCommonTextBox_11 = new System.Windows.Forms.TextBox();
			this._lblCommonLabel_9 = new System.Windows.Forms.Label();
			this._lblCommonLabel_12 = new System.Windows.Forms.Label();
			this.cmbMastersList = new C1.Win.C1TrueDBGrid.C1TrueDBDropdown();
			this.Column_0_cmbMastersList = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.Column_1_cmbMastersList = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this._lblCommonLabel_2 = new System.Windows.Forms.Label();
			this._lblCommonLabel_5 = new System.Windows.Forms.Label();
			this._lblCommonLabel_21 = new System.Windows.Forms.Label();
			this.System.Windows.Forms.Label12 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_2 = new System.Windows.Forms.TextBox();
			this._lblCommonLabel_0 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_0 = new System.Windows.Forms.TextBox();
			this._lblCommonLabel_3 = new System.Windows.Forms.Label();
			this.grdVoucherDetails = new C1.Win.C1TrueDBGrid.C1TrueDBGrid();
			this.Column_0_grdVoucherDetails = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.Column_1_grdVoucherDetails = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this._txtCommonTextBox_1 = new System.Windows.Forms.TextBox();
			this._txtCommonTextBox_4 = new System.Windows.Forms.TextBox();
			this._txtCommonTextBox_3 = new System.Windows.Forms.TextBox();
			this.cmbSetCode = new System.Windows.Forms.ComboBox();
			this._lblCommonLabel_1 = new System.Windows.Forms.Label();
			this.cmbMastersList.SuspendLayout();
			this.grdVoucherDetails.SuspendLayout();
			this.SuspendLayout();
			// 
			// cmbSetObject
			// 
			this.cmbSetObject.AllowDrop = true;
			this.cmbSetObject.Location = new System.Drawing.Point(124, 14);
			this.cmbSetObject.Name = "cmbSetObject";
			this.cmbSetObject.Size = new System.Drawing.Size(101, 21);
			this.cmbSetObject.TabIndex = 0;
			// 
			// _txtCommonTextBox_11
			// 
			this._txtCommonTextBox_11.AllowDrop = true;
			this._txtCommonTextBox_11.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_11.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_11.Location = new System.Drawing.Point(62, 387);
			this._txtCommonTextBox_11.MaxLength = 200;
			this._txtCommonTextBox_11.Name = "_txtCommonTextBox_11";
			this._txtCommonTextBox_11.Size = new System.Drawing.Size(303, 19);
			this._txtCommonTextBox_11.TabIndex = 8;
			this._txtCommonTextBox_11.Text = "";
			// this.this._txtCommonTextBox_11.Watermark = "";
			// this._txtCommonTextBox_11.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _lblCommonLabel_9
			// 
			this._lblCommonLabel_9.AllowDrop = true;
			this._lblCommonLabel_9.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			this._lblCommonLabel_9.Text = "Narration";
			this._lblCommonLabel_9.ForeColor = System.Drawing.Color.Black;
			this._lblCommonLabel_9.Location = new System.Drawing.Point(7, 390);
			this._lblCommonLabel_9.Name = "_lblCommonLabel_9";
			this._lblCommonLabel_9.Size = new System.Drawing.Size(45, 13);
			this._lblCommonLabel_9.TabIndex = 9;
			// 
			// _lblCommonLabel_12
			// 
			this._lblCommonLabel_12.AllowDrop = true;
			this._lblCommonLabel_12.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			this._lblCommonLabel_12.Text = "Product Details :";
			this._lblCommonLabel_12.ForeColor = System.Drawing.Color.Black;
			this._lblCommonLabel_12.Location = new System.Drawing.Point(2, 425);
			this._lblCommonLabel_12.Name = "_lblCommonLabel_12";
			this._lblCommonLabel_12.Size = new System.Drawing.Size(79, 13);
			this._lblCommonLabel_12.TabIndex = 10;
			// 
			// cmbMastersList
			// 
			this.cmbMastersList.AllowDrop = true;
			this.cmbMastersList.ColumnHeaders = true;
			this.cmbMastersList.Enabled = true;
			this.cmbMastersList.Location = new System.Drawing.Point(6, 220);
			this.cmbMastersList.Name = "cmbMastersList";
			this.cmbMastersList.Size = new System.Drawing.Size(61, 45);
			this.cmbMastersList.TabIndex = 11;
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
			// _lblCommonLabel_2
			// 
			this._lblCommonLabel_2.AllowDrop = true;
			this._lblCommonLabel_2.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			this._lblCommonLabel_2.Text = "Set Name (English)";
			this._lblCommonLabel_2.ForeColor = System.Drawing.Color.Black;
			this._lblCommonLabel_2.Location = new System.Drawing.Point(4, 62);
			this._lblCommonLabel_2.Name = "_lblCommonLabel_2";
			this._lblCommonLabel_2.Size = new System.Drawing.Size(91, 14);
			this._lblCommonLabel_2.TabIndex = 12;
			// 
			// _lblCommonLabel_5
			// 
			this._lblCommonLabel_5.AllowDrop = true;
			this._lblCommonLabel_5.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			this._lblCommonLabel_5.Text = "Set Object";
			this._lblCommonLabel_5.ForeColor = System.Drawing.Color.Black;
			this._lblCommonLabel_5.Location = new System.Drawing.Point(4, 17);
			this._lblCommonLabel_5.Name = "_lblCommonLabel_5";
			this._lblCommonLabel_5.Size = new System.Drawing.Size(50, 14);
			this._lblCommonLabel_5.TabIndex = 13;
			// 
			// _lblCommonLabel_21
			// 
			this._lblCommonLabel_21.AllowDrop = true;
			this._lblCommonLabel_21.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			this._lblCommonLabel_21.Text = "Set Short Name(Arabic)";
			this._lblCommonLabel_21.ForeColor = System.Drawing.Color.Black;
			this._lblCommonLabel_21.Location = new System.Drawing.Point(4, 125);
			this._lblCommonLabel_21.Name = "_lblCommonLabel_21";
			this._lblCommonLabel_21.Size = new System.Drawing.Size(115, 14);
			this._lblCommonLabel_21.TabIndex = 14;
			// 
			// System.Windows.Forms.Label12
			// 
			this.System.Windows.Forms.Label12.AllowDrop = true;
			this.System.Windows.Forms.Label12.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			this.System.Windows.Forms.Label12.Caption = "Comments";
			this.System.Windows.Forms.Label12.ForeColor = System.Drawing.Color.Black;
			this.System.Windows.Forms.Label12.Location = new System.Drawing.Point(4, 146);
			this.System.Windows.Forms.Label12.mLabelId = 1851;
			this.System.Windows.Forms.Label12.Name = "System.Windows.Forms.Label12";
			this.System.Windows.Forms.Label12.Size = new System.Drawing.Size(50, 14);
			this.System.Windows.Forms.Label12.TabIndex = 15;
			// 
			// _txtCommonTextBox_2
			// 
			this._txtCommonTextBox_2.AllowDrop = true;
			this._txtCommonTextBox_2.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_2.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_2.Location = new System.Drawing.Point(124, 102);
			// this._txtCommonTextBox_2.mArabicEnabled = true;
			this._txtCommonTextBox_2.MaxLength = 100;
			this._txtCommonTextBox_2.Name = "_txtCommonTextBox_2";
			this._txtCommonTextBox_2.Size = new System.Drawing.Size(304, 19);
			this._txtCommonTextBox_2.TabIndex = 4;
			this._txtCommonTextBox_2.Text = "";
			// this.this._txtCommonTextBox_2.Watermark = "";
			// this._txtCommonTextBox_2.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _lblCommonLabel_0
			// 
			this._lblCommonLabel_0.AllowDrop = true;
			this._lblCommonLabel_0.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			this._lblCommonLabel_0.Text = "Set Name(Arabic)";
			this._lblCommonLabel_0.ForeColor = System.Drawing.Color.Black;
			this._lblCommonLabel_0.Location = new System.Drawing.Point(4, 104);
			this._lblCommonLabel_0.Name = "_lblCommonLabel_0";
			this._lblCommonLabel_0.Size = new System.Drawing.Size(86, 14);
			this._lblCommonLabel_0.TabIndex = 16;
			// 
			// _txtCommonTextBox_0
			// 
			this._txtCommonTextBox_0.AllowDrop = true;
			this._txtCommonTextBox_0.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_0.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_0.Location = new System.Drawing.Point(124, 60);
			// this._txtCommonTextBox_0.mArabicEnabled = true;
			this._txtCommonTextBox_0.Name = "_txtCommonTextBox_0";
			this._txtCommonTextBox_0.Size = new System.Drawing.Size(304, 19);
			this._txtCommonTextBox_0.TabIndex = 2;
			this._txtCommonTextBox_0.Text = "";
			// this.this._txtCommonTextBox_0.Watermark = "";
			// this._txtCommonTextBox_0.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _lblCommonLabel_3
			// 
			this._lblCommonLabel_3.AllowDrop = true;
			this._lblCommonLabel_3.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			this._lblCommonLabel_3.Text = "Set Short Name(English)";
			this._lblCommonLabel_3.ForeColor = System.Drawing.Color.Black;
			this._lblCommonLabel_3.Location = new System.Drawing.Point(4, 83);
			this._lblCommonLabel_3.Name = "_lblCommonLabel_3";
			this._lblCommonLabel_3.Size = new System.Drawing.Size(117, 14);
			this._lblCommonLabel_3.TabIndex = 17;
			// 
			// grdVoucherDetails
			// 
			this.grdVoucherDetails.AllowDrop = true;
			this.grdVoucherDetails.BackColor = System.Drawing.Color.Silver;
			this.grdVoucherDetails.CellTipsWidth = 0;
			this.grdVoucherDetails.Location = new System.Drawing.Point(4, 178);
			this.grdVoucherDetails.Name = "grdVoucherDetails";
			this.grdVoucherDetails.RowDivider.Color = System.Drawing.Color.Silver;
			this.grdVoucherDetails.Size = new System.Drawing.Size(957, 201);
			this.grdVoucherDetails.TabIndex = 7;
			this.grdVoucherDetails.Columns.Add(this.Column_0_grdVoucherDetails);
			this.grdVoucherDetails.Columns.Add(this.Column_1_grdVoucherDetails);
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
			// _txtCommonTextBox_1
			// 
			this._txtCommonTextBox_1.AllowDrop = true;
			this._txtCommonTextBox_1.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_1.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_1.Location = new System.Drawing.Point(124, 81);
			// this._txtCommonTextBox_1.mArabicEnabled = true;
			this._txtCommonTextBox_1.Name = "_txtCommonTextBox_1";
			this._txtCommonTextBox_1.Size = new System.Drawing.Size(304, 19);
			this._txtCommonTextBox_1.TabIndex = 3;
			this._txtCommonTextBox_1.Text = "";
			// this.this._txtCommonTextBox_1.Watermark = "";
			// this._txtCommonTextBox_1.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _txtCommonTextBox_4
			// 
			this._txtCommonTextBox_4.AllowDrop = true;
			this._txtCommonTextBox_4.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_4.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_4.Location = new System.Drawing.Point(124, 144);
			// this._txtCommonTextBox_4.mArabicEnabled = true;
			this._txtCommonTextBox_4.MaxLength = 100;
			this._txtCommonTextBox_4.Name = "_txtCommonTextBox_4";
			this._txtCommonTextBox_4.Size = new System.Drawing.Size(304, 19);
			this._txtCommonTextBox_4.TabIndex = 6;
			this._txtCommonTextBox_4.Text = "";
			// this.this._txtCommonTextBox_4.Watermark = "";
			// this._txtCommonTextBox_4.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _txtCommonTextBox_3
			// 
			this._txtCommonTextBox_3.AllowDrop = true;
			this._txtCommonTextBox_3.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_3.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_3.Location = new System.Drawing.Point(124, 123);
			// this._txtCommonTextBox_3.mArabicEnabled = true;
			this._txtCommonTextBox_3.MaxLength = 100;
			this._txtCommonTextBox_3.Name = "_txtCommonTextBox_3";
			this._txtCommonTextBox_3.Size = new System.Drawing.Size(304, 19);
			this._txtCommonTextBox_3.TabIndex = 5;
			this._txtCommonTextBox_3.Text = "";
			// this.this._txtCommonTextBox_3.Watermark = "";
			// this._txtCommonTextBox_3.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// cmbSetCode
			// 
			this.cmbSetCode.AllowDrop = true;
			this.cmbSetCode.Location = new System.Drawing.Point(124, 37);
			this.cmbSetCode.Name = "cmbSetCode";
			this.cmbSetCode.Size = new System.Drawing.Size(101, 21);
			this.cmbSetCode.TabIndex = 1;
			// 
			// _lblCommonLabel_1
			// 
			this._lblCommonLabel_1.AllowDrop = true;
			this._lblCommonLabel_1.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			this._lblCommonLabel_1.Text = "Set Code";
			this._lblCommonLabel_1.ForeColor = System.Drawing.Color.Black;
			this._lblCommonLabel_1.Location = new System.Drawing.Point(4, 40);
			this._lblCommonLabel_1.Name = "_lblCommonLabel_1";
			this._lblCommonLabel_1.Size = new System.Drawing.Size(44, 14);
			this._lblCommonLabel_1.TabIndex = 18;
			// 
			// frmICSValueSet
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			this.ClientSize = new System.Drawing.Size(1311, 589);
			this.Controls.Add(this.cmbSetObject);
			this.Controls.Add(this._txtCommonTextBox_11);
			this.Controls.Add(this._lblCommonLabel_9);
			this.Controls.Add(this._lblCommonLabel_12);
			this.Controls.Add(this.cmbMastersList);
			this.Controls.Add(this._lblCommonLabel_2);
			this.Controls.Add(this._lblCommonLabel_5);
			this.Controls.Add(this._lblCommonLabel_21);
			this.Controls.Add(this.System.Windows.Forms.Label12);
			this.Controls.Add(this._txtCommonTextBox_2);
			this.Controls.Add(this._lblCommonLabel_0);
			this.Controls.Add(this._txtCommonTextBox_0);
			this.Controls.Add(this._lblCommonLabel_3);
			this.Controls.Add(this.grdVoucherDetails);
			this.Controls.Add(this._txtCommonTextBox_1);
			this.Controls.Add(this._txtCommonTextBox_4);
			this.Controls.Add(this._txtCommonTextBox_3);
			this.Controls.Add(this.cmbSetCode);
			this.Controls.Add(this._lblCommonLabel_1);
			//this.Icon = (System.Drawing.Icon) resources.GetObject("frmICSValueSet.Icon");
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(138, 177);
			this.MaximizeBox = true;
			this.MinimizeBox = true;
			this.Name = "frmICSValueSet";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Tag = "\"H: 6225  W:9570\"";
			this.Text = "Value Set";
			// this.Activated += new System.EventHandler(this.Form_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
			// this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
			this.cmbMastersList.ResumeLayout(false);
			this.grdVoucherDetails.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		void ReLoadForm(bool addEvents)
		{
			InitializetxtCommonTextBox();
			InitializelblCommonLabel();
			//This form is an MDI child.
			//This code simulates the VB6 
			// functionality of automatically
			// loading and showing an MDI
			// child's parent.
			this.MdiParent = Xtreme.frmSysMain.DefInstance;
			Xtreme.frmSysMain.DefInstance.Show();
		}
		void InitializetxtCommonTextBox()
		{
			this.txtCommonTextBox = new System.Windows.Forms.TextBox[12];
			this.txtCommonTextBox[11] = _txtCommonTextBox_11;
			this.txtCommonTextBox[2] = _txtCommonTextBox_2;
			this.txtCommonTextBox[0] = _txtCommonTextBox_0;
			this.txtCommonTextBox[1] = _txtCommonTextBox_1;
			this.txtCommonTextBox[4] = _txtCommonTextBox_4;
			this.txtCommonTextBox[3] = _txtCommonTextBox_3;
		}
		void InitializelblCommonLabel()
		{
			this.lblCommonLabel = new System.Windows.Forms.Label[22];
			this.lblCommonLabel[9] = _lblCommonLabel_9;
			this.lblCommonLabel[12] = _lblCommonLabel_12;
			this.lblCommonLabel[2] = _lblCommonLabel_2;
			this.lblCommonLabel[5] = _lblCommonLabel_5;
			this.lblCommonLabel[21] = _lblCommonLabel_21;
			this.lblCommonLabel[0] = _lblCommonLabel_0;
			this.lblCommonLabel[3] = _lblCommonLabel_3;
			this.lblCommonLabel[1] = _lblCommonLabel_1;
		}
		#endregion
	}
}