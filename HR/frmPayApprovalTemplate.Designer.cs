
namespace Xtreme
{
	partial class frmPayApprovalTemplate
	{

		#region "Upgrade Support "
		private static frmPayApprovalTemplate m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmPayApprovalTemplate DefInstance
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
		public static frmPayApprovalTemplate CreateInstance()
		{
			frmPayApprovalTemplate theInstance = new frmPayApprovalTemplate();
			
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
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "txtDlblApprovalTypeNAme", "Column_0_cmbMastersList", "Column_1_cmbMastersList", "cmbMastersList", "Column_0_grdApprovalTemplate", "Column_1_grdApprovalTemplate", "grdApprovalTemplate", "_txtTextBox_0", "System.Windows.Forms.Label3", "System.Windows.Forms.Label2", "Label1_0", "_txtTextBox_1", "_txtTextBox_2", "txtApprovalTypeCode", "Label1_1", "Line1", "System.Windows.Forms.Label1", "txtTextBox"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public System.Windows.Forms.Label txtDlblApprovalTypeNAme;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_0_cmbMastersList;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_1_cmbMastersList;
		public C1.Win.C1TrueDBGrid.C1TrueDBDropdown cmbMastersList;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_0_grdApprovalTemplate;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_1_grdApprovalTemplate;
		public C1.Win.C1TrueDBGrid.C1TrueDBGrid grdApprovalTemplate;
		private System.Windows.Forms.TextBox _txtTextBox_0;
		public System.Windows.Forms.Label Label3;
		public System.Windows.Forms.Label Label2;
		private System.Windows.Forms.Label Label1_0;
		private System.Windows.Forms.TextBox _txtTextBox_1;
		private System.Windows.Forms.TextBox _txtTextBox_2;
		public System.Windows.Forms.TextBox txtApprovalTypeCode;
		private System.Windows.Forms.Label Label1_1;
		public System.Windows.Forms.Label Line1;
		public System.Windows.Forms.Label[] Label1 = new System.Windows.Forms.Label[2];
		public System.Windows.Forms.TextBox[] txtTextBox = new System.Windows.Forms.TextBox[3];
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPayApprovalTemplate));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this.txtDlblApprovalTypeNAme = new System.Windows.Forms.Label();
			this.cmbMastersList = new C1.Win.C1TrueDBGrid.C1TrueDBDropdown();
			this.Column_0_cmbMastersList = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.Column_1_cmbMastersList = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.grdApprovalTemplate = new C1.Win.C1TrueDBGrid.C1TrueDBGrid();
			this.Column_0_grdApprovalTemplate = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.Column_1_grdApprovalTemplate = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this._txtTextBox_0 = new System.Windows.Forms.TextBox();
			this.Label3 = new System.Windows.Forms.Label();
			this.Label2 = new System.Windows.Forms.Label();
			this.Label1_0 = new System.Windows.Forms.Label();
			this._txtTextBox_1 = new System.Windows.Forms.TextBox();
			this._txtTextBox_2 = new System.Windows.Forms.TextBox();
			this.txtApprovalTypeCode = new System.Windows.Forms.TextBox();
			this.Label1_1 = new System.Windows.Forms.Label();
			this.Line1 = new System.Windows.Forms.Label();
			//this.cmbMastersList.SuspendLayout();
			//this.grdApprovalTemplate.SuspendLayout();
			this.SuspendLayout();
			// 
			// txtDlblApprovalTypeNAme
			// 
			this.txtDlblApprovalTypeNAme.AllowDrop = true;
			this.txtDlblApprovalTypeNAme.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			this.txtDlblApprovalTypeNAme.Enabled = false;
			this.txtDlblApprovalTypeNAme.Location = new System.Drawing.Point(235, 97);
			this.txtDlblApprovalTypeNAme.Name = "txtDlblApprovalTypeNAme";
			this.txtDlblApprovalTypeNAme.Size = new System.Drawing.Size(266, 19);
			this.txtDlblApprovalTypeNAme.TabIndex = 10;
			// 
			// cmbMastersList
			// 
			this.cmbMastersList.AllowDrop = true;
			this.cmbMastersList.ColumnHeaders = true;
			this.cmbMastersList.Enabled = true;
			this.cmbMastersList.Location = new System.Drawing.Point(132, 240);
			this.cmbMastersList.Name = "cmbMastersList";
			this.cmbMastersList.Size = new System.Drawing.Size(53, 37);
			this.cmbMastersList.TabIndex = 4;
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
			// grdApprovalTemplate
			// 
			this.grdApprovalTemplate.AllowAddNew = true;
			this.grdApprovalTemplate.AllowDelete = true;
			this.grdApprovalTemplate.AllowDrop = true;
			this.grdApprovalTemplate.BackColor = System.Drawing.Color.FromArgb(212, 208, 200);
			this.grdApprovalTemplate.CellTipsWidth = 0;
			this.grdApprovalTemplate.Location = new System.Drawing.Point(0, 176);
			this.grdApprovalTemplate.Name = "grdApprovalTemplate";
			this.grdApprovalTemplate.RowDivider.Color = System.Drawing.Color.FromArgb(212, 208, 200);
			this.grdApprovalTemplate.Size = new System.Drawing.Size(619, 191);
			this.grdApprovalTemplate.TabIndex = 5;
			this.grdApprovalTemplate.Columns.Add(this.Column_0_grdApprovalTemplate);
			this.grdApprovalTemplate.Columns.Add(this.Column_1_grdApprovalTemplate);
			//this.grdApprovalTemplate.GotFocus += new System.EventHandler(this.grdApprovalTemplate_GotFocus);
			//this.grdApprovalTemplate.RowColChange += new C1.Win.C1TrueDBGrid.RowColChangeEventHandler(this.grdApprovalTemplate_RowColChange);
			// 
			// Column_0_grdApprovalTemplate
			// 
			this.Column_0_grdApprovalTemplate.DataField = "";
			this.Column_0_grdApprovalTemplate.ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.Normal;
			// 
			// Column_1_grdApprovalTemplate
			// 
			this.Column_1_grdApprovalTemplate.DataField = "";
			this.Column_1_grdApprovalTemplate.ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.Normal;
			// 
			// _txtTextBox_0
			// 
			this._txtTextBox_0.AllowDrop = true;
			this._txtTextBox_0.BackColor = System.Drawing.Color.White;
			// // = false;
			this._txtTextBox_0.ForeColor = System.Drawing.Color.Black;
			this._txtTextBox_0.Location = new System.Drawing.Point(120, 77);
			// // = (System.Windows.Forms.TextBox.DropDownTypes) 0;
			this._txtTextBox_0.Name = "_txtTextBox_0";
			// this._txtTextBox_0.ShowButton = true;
			this._txtTextBox_0.Size = new System.Drawing.Size(113, 19);
			this._txtTextBox_0.TabIndex = 0;
			this._txtTextBox_0.Text = "";
			// 
			// System.Windows.Forms.Label3
			// 
			this.Label3.AllowDrop = true;
			this.Label3.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.Label3.Text = "Template Name(ARB)";
			this.Label3.Location = new System.Drawing.Point(7, 144);
			this.Label3.Name="Label3";
			this.Label3.Size = new System.Drawing.Size(103, 14);
			this.Label3.TabIndex = 6;
			// 
			// System.Windows.Forms.Label2
			// 
			this.Label2.AllowDrop = true;
			this.Label2.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.Label2.Text = "Template Name(ENG)";
			this.Label2.Location = new System.Drawing.Point(7, 121);
			this.Label2.Name="Label2";
			this.Label2.Size = new System.Drawing.Size(102, 14);
			this.Label2.TabIndex = 7;
			// 
			// Label1_0
			// 
			this.Label1_0.AllowDrop = true;
			this.Label1_0.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.Label1_0.Text = "Template Code";
			this.Label1_0.Location = new System.Drawing.Point(7, 79);
			this.Label1_0.Name = "Label1_0";
			this.Label1_0.Size = new System.Drawing.Size(71, 14);
			this.Label1_0.TabIndex = 8;
			// 
			// _txtTextBox_1
			// 
			this._txtTextBox_1.AllowDrop = true;
			this._txtTextBox_1.BackColor = System.Drawing.Color.White;
			// // = false;
			this._txtTextBox_1.ForeColor = System.Drawing.Color.Black;
			this._txtTextBox_1.Location = new System.Drawing.Point(120, 118);
			// // = (System.Windows.Forms.TextBox.DropDownTypes) 0;
			this._txtTextBox_1.Name = "_txtTextBox_1";
			this._txtTextBox_1.Size = new System.Drawing.Size(381, 19);
			this._txtTextBox_1.TabIndex = 2;
			this._txtTextBox_1.Text = "";
			// 
			// _txtTextBox_2
			// 
			this._txtTextBox_2.AllowDrop = true;
			this._txtTextBox_2.BackColor = System.Drawing.Color.White;
			// // = false;
			this._txtTextBox_2.ForeColor = System.Drawing.Color.Black;
			this._txtTextBox_2.Location = new System.Drawing.Point(120, 141);
			// // = (System.Windows.Forms.TextBox.DropDownTypes) 0;
			this._txtTextBox_2.Name = "_txtTextBox_2";
			this._txtTextBox_2.Size = new System.Drawing.Size(381, 19);
			this._txtTextBox_2.TabIndex = 3;
			this._txtTextBox_2.Text = "";
			// 
			// txtApprovalTypeCode
			// 
			this.txtApprovalTypeCode.AllowDrop = true;
			this.txtApprovalTypeCode.BackColor = System.Drawing.Color.White;
			// // = false;
			this.txtApprovalTypeCode.ForeColor = System.Drawing.Color.Black;
			this.txtApprovalTypeCode.Location = new System.Drawing.Point(120, 97);
			// // = (System.Windows.Forms.TextBox.DropDownTypes) 0;
			this.txtApprovalTypeCode.Name = "txtApprovalTypeCode";
			// this.txtApprovalTypeCode.ShowButton = true;
			this.txtApprovalTypeCode.Size = new System.Drawing.Size(113, 19);
			this.txtApprovalTypeCode.TabIndex = 1;
			this.txtApprovalTypeCode.Text = "";
			// this.//this.txtApprovalTypeCode.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(//this.txtApprovalTypeCode_DropButtonClick);
			// this.txtApprovalTypeCode.Leave += new System.EventHandler(this.txtApprovalTypeCode_Leave);
			// 
			// Label1_1
			// 
			this.Label1_1.AllowDrop = true;
			this.Label1_1.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.Label1_1.Text = "Approval Type Code";
			this.Label1_1.Location = new System.Drawing.Point(7, 100);
			this.Label1_1.Name = "Label1_1";
			this.Label1_1.Size = new System.Drawing.Size(99, 14);
			this.Label1_1.TabIndex = 9;
			// 
			// Line1
			// 
			this.Line1.AllowDrop = true;
			this.Line1.BackColor = System.Drawing.SystemColors.WindowText;
			this.Line1.Enabled = false;
			this.Line1.Location = new System.Drawing.Point(0, 172);
			this.Line1.Name = "Line1";
			this.Line1.Size = new System.Drawing.Size(617, 1);
			this.Line1.Visible = true;
			// 
			// frmPayApprovalTemplate
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.ClientSize = new System.Drawing.Size(619, 368);
			this.Controls.Add(this.txtDlblApprovalTypeNAme);
			this.Controls.Add(this.cmbMastersList);
			this.Controls.Add(this.grdApprovalTemplate);
			this.Controls.Add(this._txtTextBox_0);
			this.Controls.Add(this.Label3);
			this.Controls.Add(this.Label2);
			this.Controls.Add(this.Label1_0);
			this.Controls.Add(this._txtTextBox_1);
			this.Controls.Add(this._txtTextBox_2);
			this.Controls.Add(this.txtApprovalTypeCode);
			this.Controls.Add(this.Label1_1);
			this.Controls.Add(this.Line1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			//this.Icon = (System.Drawing.Icon) resources.GetObject("frmPayApprovalTemplate.Icon");
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(207, 125);
			this.MaximizeBox = true;
			this.MinimizeBox = true;
			this.Name = "frmPayApprovalTemplate";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Approval Template";
			// this.Activated += new System.EventHandler(this.frmPayApprovalTemplate_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
			// this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
			this.cmbMastersList.ResumeLayout(false);
			this.grdApprovalTemplate.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		// 
		void InitializetxtTextBox()
		{
			this.txtTextBox = new System.Windows.Forms.TextBox[3];
			this.txtTextBox[0] = _txtTextBox_0;
			this.txtTextBox[1] = _txtTextBox_1;
			this.txtTextBox[2] = _txtTextBox_2;
		}
		void InitializeSystemWindowsFormsLabel1()
		{
			this.Label1 = new System.Windows.Forms.Label[2];
			this.Label1[0] = Label1_0;
			this.Label1[1] = Label1_1;
		}
		#endregion
	}
}//ENDSHERE
