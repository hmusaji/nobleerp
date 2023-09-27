
namespace Xtreme
{
	partial class frmPayPenalty
	{

		#region "Upgrade Support "
		private static frmPayPenalty m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmPayPenalty DefInstance
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
		public static frmPayPenalty CreateInstance()
		{
			frmPayPenalty theInstance = new frmPayPenalty();
			
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
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "lblGroupNo", "lblLGroupName", "lblAGroupName", "txtPenaltyNo", "txtLPenaltyName", "txtAPenaltyName", "System.Windows.Forms.Label1", "txtBillNo", "txtBillCdName", "Column_0_grdPenaltySetup", "Column_1_grdPenaltySetup", "grdPenaltySetup", "lblSystemComponents", "txtPenaltyGroupCd", "txtDlblPenaltyGroupName", "System.Windows.Forms.Label2", "Line1"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public System.Windows.Forms.Label lblGroupNo;
		public System.Windows.Forms.Label lblLGroupName;
		public System.Windows.Forms.Label lblAGroupName;
		public System.Windows.Forms.TextBox txtPenaltyNo;
		public System.Windows.Forms.TextBox txtLPenaltyName;
		public System.Windows.Forms.TextBox txtAPenaltyName;
		public System.Windows.Forms.Label Label1;
		public System.Windows.Forms.TextBox txtBillNo;
		public System.Windows.Forms.Label txtBillCdName;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_0_grdPenaltySetup;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_1_grdPenaltySetup;
		public C1.Win.C1TrueDBGrid.C1TrueDBGrid grdPenaltySetup;
		public System.Windows.Forms.Label lblSystemComponents;
		public System.Windows.Forms.TextBox txtPenaltyGroupCd;
		public System.Windows.Forms.Label txtDlblPenaltyGroupName;
		public System.Windows.Forms.Label Label2;
		public System.Windows.Forms.Label Line1;
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPayPenalty));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this.lblGroupNo = new System.Windows.Forms.Label();
			this.lblLGroupName = new System.Windows.Forms.Label();
			this.lblAGroupName = new System.Windows.Forms.Label();
			this.txtPenaltyNo = new System.Windows.Forms.TextBox();
			this.txtLPenaltyName = new System.Windows.Forms.TextBox();
			this.txtAPenaltyName = new System.Windows.Forms.TextBox();
			this.Label1 = new System.Windows.Forms.Label();
			this.txtBillNo = new System.Windows.Forms.TextBox();
			this.txtBillCdName = new System.Windows.Forms.Label();
			this.grdPenaltySetup = new C1.Win.C1TrueDBGrid.C1TrueDBGrid();
			this.Column_0_grdPenaltySetup = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.Column_1_grdPenaltySetup = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.lblSystemComponents = new System.Windows.Forms.Label();
			this.txtPenaltyGroupCd = new System.Windows.Forms.TextBox();
			this.txtDlblPenaltyGroupName = new System.Windows.Forms.Label();
			this.Label2 = new System.Windows.Forms.Label();
			this.Line1 = new System.Windows.Forms.Label();
			//this.grdPenaltySetup.SuspendLayout();
			this.SuspendLayout();
			// 
			// lblGroupNo
			// 
			//this.lblGroupNo.AllowDrop = true;
			this.lblGroupNo.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblGroupNo.Text = "Penalty Code";
			this.lblGroupNo.Location = new System.Drawing.Point(8, 57);
			// // this.lblGroupNo.mLabelId = 2056;
			this.lblGroupNo.Name = "lblGroupNo";
			this.lblGroupNo.Size = new System.Drawing.Size(63, 14);
			this.lblGroupNo.TabIndex = 0;
			// 
			// lblLGroupName
			// 
			//this.lblLGroupName.AllowDrop = true;
			this.lblLGroupName.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblLGroupName.Text = "Penalty Name (English)";
			this.lblLGroupName.Location = new System.Drawing.Point(8, 78);
			// // this.lblLGroupName.mLabelId = 2057;
			this.lblLGroupName.Name = "lblLGroupName";
			this.lblLGroupName.Size = new System.Drawing.Size(110, 14);
			this.lblLGroupName.TabIndex = 7;
			// 
			// lblAGroupName
			// 
			//this.lblAGroupName.AllowDrop = true;
			this.lblAGroupName.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblAGroupName.Text = "Penalty Name (Arabic)";
			this.lblAGroupName.Location = new System.Drawing.Point(8, 99);
			// // this.lblAGroupName.mLabelId = 2058;
			this.lblAGroupName.Name = "lblAGroupName";
			this.lblAGroupName.Size = new System.Drawing.Size(108, 14);
			this.lblAGroupName.TabIndex = 8;
			// 
			// txtPenaltyNo
			// 
			//this.txtPenaltyNo.AllowDrop = true;
			this.txtPenaltyNo.BackColor = System.Drawing.Color.White;
			// this.txtPenaltyNo.bolNumericOnly = true;
			this.txtPenaltyNo.ForeColor = System.Drawing.Color.Black;
			this.txtPenaltyNo.Location = new System.Drawing.Point(124, 54);
			this.txtPenaltyNo.MaxLength = 15;
			// // = System.Windows.Forms.TextBox.DropDownTypes.ddtNextNumber;
			this.txtPenaltyNo.Name = "txtPenaltyNo";
			// this.txtPenaltyNo.ShowButton = true;
			this.txtPenaltyNo.Size = new System.Drawing.Size(101, 19);
			this.txtPenaltyNo.TabIndex = 1;
			this.txtPenaltyNo.Text = "";
			// this.//this.txtPenaltyNo.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(//this.txtPenaltyNo_DropButtonClick);
			// 
			// txtLPenaltyName
			// 
			//this.txtLPenaltyName.AllowDrop = true;
			this.txtLPenaltyName.BackColor = System.Drawing.Color.White;
			this.txtLPenaltyName.ForeColor = System.Drawing.Color.Black;
			this.txtLPenaltyName.Location = new System.Drawing.Point(124, 75);
			this.txtLPenaltyName.MaxLength = 50;
			this.txtLPenaltyName.Name = "txtLPenaltyName";
			this.txtLPenaltyName.Size = new System.Drawing.Size(387, 19);
			this.txtLPenaltyName.TabIndex = 2;
			this.txtLPenaltyName.Text = "";
			// 
			// txtAPenaltyName
			// 
			//this.txtAPenaltyName.AllowDrop = true;
			this.txtAPenaltyName.BackColor = System.Drawing.Color.White;
			this.txtAPenaltyName.ForeColor = System.Drawing.Color.Black;
			this.txtAPenaltyName.Location = new System.Drawing.Point(124, 96);
			// // = true;
			this.txtAPenaltyName.MaxLength = 50;
			this.txtAPenaltyName.Name = "txtAPenaltyName";
			this.txtAPenaltyName.Size = new System.Drawing.Size(387, 19);
			this.txtAPenaltyName.TabIndex = 3;
			this.txtAPenaltyName.Text = "";
			// 
			// System.Windows.Forms.Label1
			// 
			//this.Label1.AllowDrop = true;
			this.Label1.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.Label1.Text = "Bill Code";
			this.Label1.Location = new System.Drawing.Point(8, 144);
			// this.Label1.mLabelId = 1041;
			this.Label1.Name="Label1";
			this.Label1.Size = new System.Drawing.Size(41, 14);
			this.Label1.TabIndex = 9;
			// 
			// txtBillNo
			// 
			//this.txtBillNo.AllowDrop = true;
			this.txtBillNo.BackColor = System.Drawing.Color.White;
			// this.txtBillNo.bolNumericOnly = true;
			this.txtBillNo.ForeColor = System.Drawing.Color.Black;
			this.txtBillNo.Location = new System.Drawing.Point(123, 142);
			this.txtBillNo.MaxLength = 15;
			// // = System.Windows.Forms.TextBox.DropDownTypes.ddtNextNumber;
			this.txtBillNo.Name = "txtBillNo";
			// this.txtBillNo.ShowButton = true;
			this.txtBillNo.Size = new System.Drawing.Size(97, 19);
			this.txtBillNo.TabIndex = 5;
			this.txtBillNo.Text = "";
			// this.//this.txtBillNo.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(//this.txtBillNo_DropButtonClick);
			// this.txtBillNo.Leave += new System.EventHandler(this.txtBillNo_Leave);
			// 
			// txtBillCdName
			// 
			//this.txtBillCdName.AllowDrop = true;
			this.txtBillCdName.BackColor = System.Drawing.SystemColors.Window;
			this.txtBillCdName.Enabled = false;
			this.txtBillCdName.Location = new System.Drawing.Point(222, 142);
			this.txtBillCdName.Name = "txtBillCdName";
			this.txtBillCdName.Size = new System.Drawing.Size(290, 19);
			this.txtBillCdName.TabIndex = 10;
			// 
			// grdPenaltySetup
			// 
			this.grdPenaltySetup.AllowDelete = true;
			//this.grdPenaltySetup.AllowDrop = true;
			this.grdPenaltySetup.BackColor = System.Drawing.Color.FromArgb(212, 208, 200);
			this.grdPenaltySetup.CellTipsWidth = 0;
			this.grdPenaltySetup.Location = new System.Drawing.Point(6, 180);
			this.grdPenaltySetup.Name = "grdPenaltySetup";
			this.grdPenaltySetup.RowDivider.Color = System.Drawing.Color.FromArgb(212, 208, 200);
			this.grdPenaltySetup.Size = new System.Drawing.Size(512, 211);
			this.grdPenaltySetup.TabIndex = 6;
			this.grdPenaltySetup.Columns.Add(this.Column_0_grdPenaltySetup);
			this.grdPenaltySetup.Columns.Add(this.Column_1_grdPenaltySetup);
			// 
			// Column_0_grdPenaltySetup
			// 
			this.Column_0_grdPenaltySetup.DataField = "";
			this.Column_0_grdPenaltySetup.ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.Normal;
			// 
			// Column_1_grdPenaltySetup
			// 
			this.Column_1_grdPenaltySetup.DataField = "";
			this.Column_1_grdPenaltySetup.ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.Normal;
			// 
			// lblSystemComponents
			// 
			//this.lblSystemComponents.AllowDrop = true;
			this.lblSystemComponents.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblSystemComponents.Text = "Penalty Setup";
			this.lblSystemComponents.Location = new System.Drawing.Point(15, 162);
			this.lblSystemComponents.Name = "lblSystemComponents";
			this.lblSystemComponents.Size = new System.Drawing.Size(79, 13);
			this.lblSystemComponents.TabIndex = 11;
			// 
			// txtPenaltyGroupCd
			// 
			//this.txtPenaltyGroupCd.AllowDrop = true;
			this.txtPenaltyGroupCd.BackColor = System.Drawing.Color.White;
			// this.txtPenaltyGroupCd.bolNumericOnly = true;
			this.txtPenaltyGroupCd.ForeColor = System.Drawing.Color.Black;
			this.txtPenaltyGroupCd.Location = new System.Drawing.Point(123, 120);
			this.txtPenaltyGroupCd.MaxLength = 15;
			// // = System.Windows.Forms.TextBox.DropDownTypes.ddtNextNumber;
			this.txtPenaltyGroupCd.Name = "txtPenaltyGroupCd";
			// this.txtPenaltyGroupCd.ShowButton = true;
			this.txtPenaltyGroupCd.Size = new System.Drawing.Size(97, 19);
			this.txtPenaltyGroupCd.TabIndex = 4;
			this.txtPenaltyGroupCd.Text = "";
			// this.//this.txtPenaltyGroupCd.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(//this.txtPenaltyGroupCd_DropButtonClick);
			// this.txtPenaltyGroupCd.Leave += new System.EventHandler(this.txtPenaltyGroupCd_Leave);
			// 
			// txtDlblPenaltyGroupName
			// 
			//this.txtDlblPenaltyGroupName.AllowDrop = true;
			this.txtDlblPenaltyGroupName.BackColor = System.Drawing.SystemColors.Window;
			this.txtDlblPenaltyGroupName.Enabled = false;
			this.txtDlblPenaltyGroupName.Location = new System.Drawing.Point(222, 120);
			this.txtDlblPenaltyGroupName.Name = "txtDlblPenaltyGroupName";
			this.txtDlblPenaltyGroupName.Size = new System.Drawing.Size(290, 19);
			this.txtDlblPenaltyGroupName.TabIndex = 12;
			// 
			// System.Windows.Forms.Label2
			// 
			//this.Label2.AllowDrop = true;
			this.Label2.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.Label2.Text = "Penalty Group Code";
			this.Label2.Location = new System.Drawing.Point(9, 120);
			this.Label2.Name="Label2";
			this.Label2.Size = new System.Drawing.Size(96, 14);
			this.Label2.TabIndex = 13;
			// 
			// Line1
			// 
			//this.Line1.AllowDrop = true;
			this.Line1.BackColor = System.Drawing.SystemColors.WindowText;
			//this.Line1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Line1.Enabled = false;
			this.Line1.Location = new System.Drawing.Point(6, 169);
			this.Line1.Name = "Line1";
			this.Line1.Size = new System.Drawing.Size(511, 1);
			this.Line1.Visible = true;
			// 
			// frmPayPenalty
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.ClientSize = new System.Drawing.Size(523, 397);
			this.Controls.Add(this.lblGroupNo);
			this.Controls.Add(this.lblLGroupName);
			this.Controls.Add(this.lblAGroupName);
			this.Controls.Add(this.txtPenaltyNo);
			this.Controls.Add(this.txtLPenaltyName);
			this.Controls.Add(this.txtAPenaltyName);
			this.Controls.Add(this.Label1);
			this.Controls.Add(this.txtBillNo);
			this.Controls.Add(this.txtBillCdName);
			this.Controls.Add(this.grdPenaltySetup);
			this.Controls.Add(this.lblSystemComponents);
			this.Controls.Add(this.txtPenaltyGroupCd);
			this.Controls.Add(this.txtDlblPenaltyGroupName);
			this.Controls.Add(this.Label2);
			this.Controls.Add(this.Line1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			//this.Icon = (System.Drawing.Icon) resources.GetObject("frmPayPenalty.Icon");
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(253, 183);
			this.MaximizeBox = true;
			this.MinimizeBox = true;
			this.Name = "frmPayPenalty";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Penalty";
			// this.Activated += new System.EventHandler(this.frmPayPenalty_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
			// this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
			this.grdPenaltySetup.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		// 
		#endregion
	}
}//ENDSHERE
