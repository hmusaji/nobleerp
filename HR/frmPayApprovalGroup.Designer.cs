
namespace Xtreme
{
	partial class frmPayApprovalGroup
	{

		#region "Upgrade Support "
		private static frmPayApprovalGroup m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmPayApprovalGroup DefInstance
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
		public static frmPayApprovalGroup CreateInstance()
		{
			frmPayApprovalGroup theInstance = new frmPayApprovalGroup();
			
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
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "Column_0_cmbMastersList", "Column_1_cmbMastersList", "cmbMastersList", "_txtTextBox_0", "System.Windows.Forms.Label3", "System.Windows.Forms.Label2", "System.Windows.Forms.Label1", "_txtTextBox_1", "_txtTextBox_2", "Column_0_grdApprovalGroup", "Column_1_grdApprovalGroup", "grdApprovalGroup", "Line1", "txtTextBox"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_0_cmbMastersList;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_1_cmbMastersList;
		public C1.Win.C1TrueDBGrid.C1TrueDBDropdown cmbMastersList;
		private System.Windows.Forms.TextBox _txtTextBox_0;
		public System.Windows.Forms.Label Label3;
		public System.Windows.Forms.Label Label2;
		public System.Windows.Forms.Label Label1;
		private System.Windows.Forms.TextBox _txtTextBox_1;
		private System.Windows.Forms.TextBox _txtTextBox_2;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_0_grdApprovalGroup;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_1_grdApprovalGroup;
		public C1.Win.C1TrueDBGrid.C1TrueDBGrid grdApprovalGroup;
		public System.Windows.Forms.Label Line1;
		public System.Windows.Forms.TextBox[] txtTextBox = new System.Windows.Forms.TextBox[3];
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPayApprovalGroup));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this.cmbMastersList = new C1.Win.C1TrueDBGrid.C1TrueDBDropdown();
			this.Column_0_cmbMastersList = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.Column_1_cmbMastersList = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this._txtTextBox_0 = new System.Windows.Forms.TextBox();
			this.Label3 = new System.Windows.Forms.Label();
			this.Label2 = new System.Windows.Forms.Label();
			this.Label1 = new System.Windows.Forms.Label();
			this._txtTextBox_1 = new System.Windows.Forms.TextBox();
			this._txtTextBox_2 = new System.Windows.Forms.TextBox();
			this.grdApprovalGroup = new C1.Win.C1TrueDBGrid.C1TrueDBGrid();
			this.Column_0_grdApprovalGroup = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.Column_1_grdApprovalGroup = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.Line1 = new System.Windows.Forms.Label();
			//this.cmbMastersList.SuspendLayout();
			//this.grdApprovalGroup.SuspendLayout();
			this.SuspendLayout();
			// 
			// cmbMastersList
			// 
			this.cmbMastersList.AllowDrop = true;
			this.cmbMastersList.ColumnHeaders = true;
			this.cmbMastersList.Enabled = true;
			this.cmbMastersList.Location = new System.Drawing.Point(96, 232);
			this.cmbMastersList.Name = "cmbMastersList";
			this.cmbMastersList.Size = new System.Drawing.Size(53, 37);
			this.cmbMastersList.TabIndex = 6;
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
			// _txtTextBox_0
			// 
			this._txtTextBox_0.AllowDrop = true;
			this._txtTextBox_0.BackColor = System.Drawing.Color.White;
			// // = false;
			this._txtTextBox_0.ForeColor = System.Drawing.Color.Black;
			this._txtTextBox_0.Location = new System.Drawing.Point(120, 72);
			// // = (System.Windows.Forms.TextBox.DropDownTypes) 0;
			this._txtTextBox_0.Name = "_txtTextBox_0";
			// this._txtTextBox_0.ShowButton = true;
			this._txtTextBox_0.Size = new System.Drawing.Size(113, 21);
			this._txtTextBox_0.TabIndex = 0;
			this._txtTextBox_0.Text = "";
			// this.// = "";
			// 
			// System.Windows.Forms.Label3
			// 
			this.Label3.AllowDrop = true;
			this.Label3.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.Label3.Text = "Group Name(ARB)";
			this.Label3.Location = new System.Drawing.Point(4, 123);
			this.Label3.Name="Label3";
			this.Label3.Size = new System.Drawing.Size(90, 14);
			this.Label3.TabIndex = 5;
			// 
			// System.Windows.Forms.Label2
			// 
			this.Label2.AllowDrop = true;
			this.Label2.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.Label2.Text = "Group Name(ENG)";
			this.Label2.Location = new System.Drawing.Point(4, 99);
			this.Label2.Name="Label2";
			this.Label2.Size = new System.Drawing.Size(89, 14);
			this.Label2.TabIndex = 4;
			// 
			// System.Windows.Forms.Label1
			// 
			this.Label1.AllowDrop = true;
			this.Label1.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.Label1.Text = "Group Code";
			this.Label1.Location = new System.Drawing.Point(4, 75);
			this.Label1.Name="Label1";
			this.Label1.Size = new System.Drawing.Size(58, 14);
			this.Label1.TabIndex = 3;
			// 
			// _txtTextBox_1
			// 
			this._txtTextBox_1.AllowDrop = true;
			this._txtTextBox_1.BackColor = System.Drawing.Color.White;
			// // = false;
			this._txtTextBox_1.ForeColor = System.Drawing.Color.Black;
			this._txtTextBox_1.Location = new System.Drawing.Point(120, 96);
			// // = (System.Windows.Forms.TextBox.DropDownTypes) 0;
			this._txtTextBox_1.Name = "_txtTextBox_1";
			this._txtTextBox_1.Size = new System.Drawing.Size(381, 21);
			this._txtTextBox_1.TabIndex = 1;
			this._txtTextBox_1.Text = "";
			// this.// = "";
			// 
			// _txtTextBox_2
			// 
			this._txtTextBox_2.AllowDrop = true;
			this._txtTextBox_2.BackColor = System.Drawing.Color.White;
			// // = false;
			this._txtTextBox_2.ForeColor = System.Drawing.Color.Black;
			this._txtTextBox_2.Location = new System.Drawing.Point(120, 120);
			// // = (System.Windows.Forms.TextBox.DropDownTypes) 0;
			this._txtTextBox_2.Name = "_txtTextBox_2";
			this._txtTextBox_2.Size = new System.Drawing.Size(381, 21);
			this._txtTextBox_2.TabIndex = 2;
			this._txtTextBox_2.Text = "";
			// this.// = "";
			// 
			// grdApprovalGroup
			// 
			this.grdApprovalGroup.AllowAddNew = true;
			this.grdApprovalGroup.AllowDelete = true;
			this.grdApprovalGroup.AllowDrop = true;
			this.grdApprovalGroup.BackColor = System.Drawing.Color.FromArgb(212, 208, 200);
			this.grdApprovalGroup.CellTipsWidth = 0;
			this.grdApprovalGroup.Location = new System.Drawing.Point(0, 150);
			this.grdApprovalGroup.Name = "grdApprovalGroup";
			this.grdApprovalGroup.RowDivider.Color = System.Drawing.Color.FromArgb(212, 208, 200);
			this.grdApprovalGroup.Size = new System.Drawing.Size(619, 191);
			this.grdApprovalGroup.TabIndex = 7;
			this.grdApprovalGroup.Columns.Add(this.Column_0_grdApprovalGroup);
			this.grdApprovalGroup.Columns.Add(this.Column_1_grdApprovalGroup);
			this.grdApprovalGroup.GotFocus += new System.EventHandler(this.grdApprovalGroup_GotFocus);
			this.grdApprovalGroup.RowColChange += new C1.Win.C1TrueDBGrid.RowColChangeEventHandler(this.grdApprovalGroup_RowColChange);
			// 
			// Column_0_grdApprovalGroup
			// 
			this.Column_0_grdApprovalGroup.DataField = "";
			this.Column_0_grdApprovalGroup.ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.Normal;
			// 
			// Column_1_grdApprovalGroup
			// 
			this.Column_1_grdApprovalGroup.DataField = "";
			this.Column_1_grdApprovalGroup.ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.Normal;
			// 
			// Line1
			// 
			this.Line1.AllowDrop = true;
			this.Line1.BackColor = System.Drawing.SystemColors.WindowText;
			this.Line1.Enabled = false;
			this.Line1.Location = new System.Drawing.Point(0, 148);
			this.Line1.Name = "Line1";
			this.Line1.Size = new System.Drawing.Size(617, 1);
			this.Line1.Visible = true;
			// 
			// frmPayApprovalGroup
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.ClientSize = new System.Drawing.Size(619, 345);
			this.Controls.Add(this.cmbMastersList);
			this.Controls.Add(this._txtTextBox_0);
			this.Controls.Add(this.Label3);
			this.Controls.Add(this.Label2);
			this.Controls.Add(this.Label1);
			this.Controls.Add(this._txtTextBox_1);
			this.Controls.Add(this._txtTextBox_2);
			this.Controls.Add(this.grdApprovalGroup);
			this.Controls.Add(this.Line1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			//this.Icon = (System.Drawing.Icon) resources.GetObject("frmPayApprovalGroup.Icon");
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(110, 103);
			this.MaximizeBox = true;
			this.MinimizeBox = true;
			this.Name = "frmPayApprovalGroup";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Approval Group";
			// this.Activated += new System.EventHandler(this.frmPayApprovalGroup_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
			// this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
			this.cmbMastersList.ResumeLayout(false);
			this.grdApprovalGroup.ResumeLayout(false);
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
		#endregion
	}
}//ENDSHERE
