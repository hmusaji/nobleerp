
namespace Xtreme
{
	partial class frmRETenantCharges
	{

		#region "Upgrade Support "
		private static frmRETenantCharges m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmRETenantCharges DefInstance
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
		public static frmRETenantCharges CreateInstance()
		{
			frmRETenantCharges theInstance = new frmRETenantCharges();
			
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
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "txtRemarks", "_btnFormToolBar_0", "_btnFormToolBar_1", "_btnFormToolBar_3", "_btnFormToolBar_7", "_btnFormToolBar_8", "_btnFormToolBar_6", "_btnFormToolBar_5", "_btnFormToolBar_9", "picFormToolbar", "grdContractDetails", "Column_0_cmbCommon", "Column_1_cmbCommon", "cmbCommon", "_lblCommon_8", "_lblCommon_0", "_txtCommon_0", "_txtCommonDisplay_0", "btnFormToolBar", "lblCommon", "txtCommon", "txtCommonDisplay"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public System.Windows.Forms.TextBox txtRemarks;
		private AxSmartNetButtonProject.AxSmartNetButton _btnFormToolBar_0;
		private AxSmartNetButtonProject.AxSmartNetButton _btnFormToolBar_1;
		private AxSmartNetButtonProject.AxSmartNetButton _btnFormToolBar_3;
		private AxSmartNetButtonProject.AxSmartNetButton _btnFormToolBar_7;
		private AxSmartNetButtonProject.AxSmartNetButton _btnFormToolBar_8;
		private AxSmartNetButtonProject.AxSmartNetButton _btnFormToolBar_6;
		private AxSmartNetButtonProject.AxSmartNetButton _btnFormToolBar_5;
		private AxSmartNetButtonProject.AxSmartNetButton _btnFormToolBar_9;
		public System.Windows.Forms.PictureBox picFormToolbar;
		public C1.Win.C1TrueDBGrid.C1TrueDBGrid grdContractDetails;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_0_cmbCommon;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_1_cmbCommon;
		public C1.Win.C1TrueDBGrid.C1TrueDBDropdown cmbCommon;
		private System.Windows.Forms.Label _lblCommon_8;
		private System.Windows.Forms.Label _lblCommon_0;
		private System.Windows.Forms.TextBox _txtCommon_0;
		private System.Windows.Forms.Label _txtCommonDisplay_0;
		public AxSmartNetButtonProject.AxSmartNetButton[] btnFormToolBar = new AxSmartNetButtonProject.AxSmartNetButton[10];
		public System.Windows.Forms.Label[] lblCommon = new System.Windows.Forms.Label[9];
		public System.Windows.Forms.TextBox[] txtCommon = new System.Windows.Forms.TextBox[1];
		public System.Windows.Forms.Label[] txtCommonDisplay = new System.Windows.Forms.Label[1];
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRETenantCharges));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this.txtRemarks = new System.Windows.Forms.TextBox();
			this.picFormToolbar = new System.Windows.Forms.PictureBox();
			this._btnFormToolBar_0 = new AxSmartNetButtonProject.AxSmartNetButton();
			this._btnFormToolBar_1 = new AxSmartNetButtonProject.AxSmartNetButton();
			this._btnFormToolBar_3 = new AxSmartNetButtonProject.AxSmartNetButton();
			this._btnFormToolBar_7 = new AxSmartNetButtonProject.AxSmartNetButton();
			this._btnFormToolBar_8 = new AxSmartNetButtonProject.AxSmartNetButton();
			this._btnFormToolBar_6 = new AxSmartNetButtonProject.AxSmartNetButton();
			this._btnFormToolBar_5 = new AxSmartNetButtonProject.AxSmartNetButton();
			this._btnFormToolBar_9 = new AxSmartNetButtonProject.AxSmartNetButton();
			this.grdContractDetails = new C1.Win.C1TrueDBGrid.C1TrueDBGrid();
			this.cmbCommon = new C1.Win.C1TrueDBGrid.C1TrueDBDropdown();
			this.Column_0_cmbCommon = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.Column_1_cmbCommon = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this._lblCommon_8 = new System.Windows.Forms.Label();
			this._lblCommon_0 = new System.Windows.Forms.Label();
			this._txtCommon_0 = new System.Windows.Forms.TextBox();
			this._txtCommonDisplay_0 = new System.Windows.Forms.Label();
			// //((System.ComponentModel.ISupportInitialize) this._btnFormToolBar_0).BeginInit();
			// //((System.ComponentModel.ISupportInitialize) this._btnFormToolBar_1).BeginInit();
			// //((System.ComponentModel.ISupportInitialize) this._btnFormToolBar_3).BeginInit();
			// //((System.ComponentModel.ISupportInitialize) this._btnFormToolBar_7).BeginInit();
			// //((System.ComponentModel.ISupportInitialize) this._btnFormToolBar_8).BeginInit();
			// //((System.ComponentModel.ISupportInitialize) this._btnFormToolBar_6).BeginInit();
			// //((System.ComponentModel.ISupportInitialize) this._btnFormToolBar_5).BeginInit();
			// //((System.ComponentModel.ISupportInitialize) this._btnFormToolBar_9).BeginInit();
			this.picFormToolbar.SuspendLayout();
			this.cmbCommon.SuspendLayout();
			this.SuspendLayout();
			// 
			// txtRemarks
			// 
			this.txtRemarks.AcceptsReturn = true;
			this.txtRemarks.AllowDrop = true;
			this.txtRemarks.BackColor = System.Drawing.SystemColors.Window;
			this.txtRemarks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtRemarks.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtRemarks.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtRemarks.Location = new System.Drawing.Point(71, 327);
			this.txtRemarks.MaxLength = 100;
			this.txtRemarks.Multiline = true;
			this.txtRemarks.Name = "txtRemarks";
			this.txtRemarks.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtRemarks.Size = new System.Drawing.Size(466, 19);
			this.txtRemarks.TabIndex = 1;
			// 
			// picFormToolbar
			// 
			this.picFormToolbar.AllowDrop = true;
			this.picFormToolbar.BackColor = System.Drawing.SystemColors.Control;
			this.picFormToolbar.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.picFormToolbar.CausesValidation = true;
			this.picFormToolbar.Controls.Add(this._btnFormToolBar_0);
			this.picFormToolbar.Controls.Add(this._btnFormToolBar_1);
			this.picFormToolbar.Controls.Add(this._btnFormToolBar_3);
			this.picFormToolbar.Controls.Add(this._btnFormToolBar_7);
			this.picFormToolbar.Controls.Add(this._btnFormToolBar_8);
			this.picFormToolbar.Controls.Add(this._btnFormToolBar_6);
			this.picFormToolbar.Controls.Add(this._btnFormToolBar_5);
			this.picFormToolbar.Controls.Add(this._btnFormToolBar_9);
			this.picFormToolbar.Dock = System.Windows.Forms.DockStyle.Top;
			this.picFormToolbar.Enabled = true;
			this.picFormToolbar.Location = new System.Drawing.Point(0, 0);
			this.picFormToolbar.Name = "picFormToolbar";
			this.picFormToolbar.Size = new System.Drawing.Size(649, 38);
			this.picFormToolbar.TabIndex = 2;
			this.picFormToolbar.TabStop = false;
			this.picFormToolbar.Visible = true;
			// 
			// _btnFormToolBar_0
			// 
			this._btnFormToolBar_0.AllowDrop = true;
			this._btnFormToolBar_0.Location = new System.Drawing.Point(2, 2);
			this._btnFormToolBar_0.Name = "_btnFormToolBar_0";
			("_btnFormToolBar_0.OcxState");
			this._btnFormToolBar_0.Size = new System.Drawing.Size(51, 34);
			this._btnFormToolBar_0.TabIndex = 3;
			this._btnFormToolBar_0.TabStop = false;
			this._btnFormToolBar_0.Tag = "New";
			// 
			// _btnFormToolBar_1
			// 
			this._btnFormToolBar_1.AllowDrop = true;
			this._btnFormToolBar_1.Location = new System.Drawing.Point(53, 2);
			this._btnFormToolBar_1.Name = "_btnFormToolBar_1";
			("_btnFormToolBar_1.OcxState");
			this._btnFormToolBar_1.Size = new System.Drawing.Size(51, 34);
			this._btnFormToolBar_1.TabIndex = 4;
			this._btnFormToolBar_1.TabStop = false;
			this._btnFormToolBar_1.Tag = "Save";
			// 
			// _btnFormToolBar_3
			// 
			this._btnFormToolBar_3.AllowDrop = true;
			this._btnFormToolBar_3.Location = new System.Drawing.Point(104, 2);
			this._btnFormToolBar_3.Name = "_btnFormToolBar_3";
			("_btnFormToolBar_3.OcxState");
			this._btnFormToolBar_3.Size = new System.Drawing.Size(51, 34);
			this._btnFormToolBar_3.TabIndex = 5;
			this._btnFormToolBar_3.TabStop = false;
			this._btnFormToolBar_3.Tag = "Print";
			// 
			// _btnFormToolBar_7
			// 
			this._btnFormToolBar_7.AllowDrop = true;
			this._btnFormToolBar_7.Location = new System.Drawing.Point(328, 2);
			this._btnFormToolBar_7.Name = "_btnFormToolBar_7";
			("_btnFormToolBar_7.OcxState");
			this._btnFormToolBar_7.Size = new System.Drawing.Size(51, 34);
			this._btnFormToolBar_7.TabIndex = 7;
			this._btnFormToolBar_7.TabStop = false;
			this._btnFormToolBar_7.Tag = "Help";
			// 
			// _btnFormToolBar_8
			// 
			this._btnFormToolBar_8.AllowDrop = true;
			this._btnFormToolBar_8.Location = new System.Drawing.Point(379, 2);
			this._btnFormToolBar_8.Name = "_btnFormToolBar_8";
			("_btnFormToolBar_8.OcxState");
			this._btnFormToolBar_8.Size = new System.Drawing.Size(51, 34);
			this._btnFormToolBar_8.TabIndex = 8;
			this._btnFormToolBar_8.TabStop = false;
			this._btnFormToolBar_8.Tag = "Exit";
			// 
			// _btnFormToolBar_6
			// 
			this._btnFormToolBar_6.AllowDrop = true;
			this._btnFormToolBar_6.Location = new System.Drawing.Point(155, 2);
			this._btnFormToolBar_6.Name = "_btnFormToolBar_6";
			("_btnFormToolBar_6.OcxState");
			this._btnFormToolBar_6.Size = new System.Drawing.Size(61, 34);
			this._btnFormToolBar_6.TabIndex = 9;
			this._btnFormToolBar_6.TabStop = false;
			this._btnFormToolBar_6.Tag = "I";
			// 
			// _btnFormToolBar_5
			// 
			this._btnFormToolBar_5.AllowDrop = true;
			this._btnFormToolBar_5.Location = new System.Drawing.Point(277, 2);
			this._btnFormToolBar_5.Name = "_btnFormToolBar_5";
			("_btnFormToolBar_5.OcxState");
			this._btnFormToolBar_5.Size = new System.Drawing.Size(51, 34);
			this._btnFormToolBar_5.TabIndex = 11;
			this._btnFormToolBar_5.TabStop = false;
			this._btnFormToolBar_5.Tag = "Post";
			// 
			// _btnFormToolBar_9
			// 
			this._btnFormToolBar_9.AllowDrop = true;
			this._btnFormToolBar_9.Location = new System.Drawing.Point(216, 2);
			this._btnFormToolBar_9.Name = "_btnFormToolBar_9";
			("_btnFormToolBar_9.OcxState");
			this._btnFormToolBar_9.Size = new System.Drawing.Size(61, 34);
			this._btnFormToolBar_9.TabIndex = 12;
			this._btnFormToolBar_9.TabStop = false;
			this._btnFormToolBar_9.Tag = "L";
			// 
			// grdContractDetails
			// 
			this.grdContractDetails.AllowDrop = true;
			this.grdContractDetails.BackColor = System.Drawing.Color.Silver;
			this.grdContractDetails.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.grdContractDetails.CellTipsWidth = 0;
			this.grdContractDetails.Location = new System.Drawing.Point(8, 118);
			this.grdContractDetails.Name = "grdContractDetails";
			this.grdContractDetails.RowDivider.Color = System.Drawing.Color.Silver;
			this.grdContractDetails.Size = new System.Drawing.Size(597, 174);
			this.grdContractDetails.TabIndex = 0;
			// 
			// cmbCommon
			// 
			this.cmbCommon.AllowDrop = true;
			this.cmbCommon.ColumnHeaders = true;
			this.cmbCommon.Enabled = true;
			this.cmbCommon.Location = new System.Drawing.Point(254, 160);
			this.cmbCommon.Name = "cmbCommon";
			this.cmbCommon.Size = new System.Drawing.Size(127, 79);
			this.cmbCommon.TabIndex = 6;
			this.cmbCommon.Columns.Add(this.Column_0_cmbCommon);
			this.cmbCommon.Columns.Add(this.Column_1_cmbCommon);
			// 
			// Column_0_cmbCommon
			// 
			this.Column_0_cmbCommon.DataField = "";
			this.Column_0_cmbCommon.ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.Normal;
			// 
			// Column_1_cmbCommon
			// 
			this.Column_1_cmbCommon.DataField = "";
			this.Column_1_cmbCommon.ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.Normal;
			// 
			// _lblCommon_8
			// 
			this._lblCommon_8.AllowDrop = true;
			this._lblCommon_8.Location = new System.Drawing.Point(8, 329);
			this._lblCommon_8.Name = "_lblCommon_8";
			this._lblCommon_8.Size = new System.Drawing.Size(50, 14);
			this._lblCommon_8.TabIndex = 10;
			// 
			// _lblCommon_0
			// 
			this._lblCommon_0.AllowDrop = true;
			this._lblCommon_0.Location = new System.Drawing.Point(6, 74);
			this._lblCommon_0.Name = "_lblCommon_0";
			this._lblCommon_0.Size = new System.Drawing.Size(61, 14);
			this._lblCommon_0.TabIndex = 13;
			// 
			// _txtCommon_0
			// 
			this._txtCommon_0.AllowDrop = true;
			this._txtCommon_0.BackColor = System.Drawing.Color.White;
			this._txtCommon_0.ForeColor = System.Drawing.Color.Black;
			this._txtCommon_0.Location = new System.Drawing.Point(99, 72);
			this._txtCommon_0.Name = "_txtCommon_0";
			this._txtCommon_0.Size = new System.Drawing.Size(101, 19);
			this._txtCommon_0.TabIndex = 14;
			this._txtCommon_0.Text = "";
			// this.this._txtCommon_0.Watermark = "";
			// 
			// _txtCommonDisplay_0
			// 
			this._txtCommonDisplay_0.AllowDrop = true;
			this._txtCommonDisplay_0.Location = new System.Drawing.Point(202, 72);
			this._txtCommonDisplay_0.Name = "_txtCommonDisplay_0";
			this._txtCommonDisplay_0.Size = new System.Drawing.Size(201, 19);
			this._txtCommonDisplay_0.TabIndex = 15;
			// 
			// frmRETenantCharges
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.FromArgb(202, 213, 223);
			this.ClientSize = new System.Drawing.Size(649, 354);
			this.Controls.Add(this.txtRemarks);
			this.Controls.Add(this.picFormToolbar);
			this.Controls.Add(this.grdContractDetails);
			this.Controls.Add(this.cmbCommon);
			this.Controls.Add(this._lblCommon_8);
			this.Controls.Add(this._lblCommon_0);
			this.Controls.Add(this._txtCommon_0);
			this.Controls.Add(this._txtCommonDisplay_0);
			//this.Icon = (System.Drawing.Icon) resources.GetObject("frmRETenantCharges.Icon");
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(96, 136);
			this.MaximizeBox = true;
			this.MinimizeBox = true;
			this.Name = "frmRETenantCharges";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Tenant Charges";
			// this.Activated += new System.EventHandler(this.frmRETenantCharges_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
			//((System.ComponentModel.ISupportInitialize) this._btnFormToolBar_0).EndInit();
			//((System.ComponentModel.ISupportInitialize) this._btnFormToolBar_1).EndInit();
			//((System.ComponentModel.ISupportInitialize) this._btnFormToolBar_3).EndInit();
			//((System.ComponentModel.ISupportInitialize) this._btnFormToolBar_7).EndInit();
			//((System.ComponentModel.ISupportInitialize) this._btnFormToolBar_8).EndInit();
			//((System.ComponentModel.ISupportInitialize) this._btnFormToolBar_6).EndInit();
			//((System.ComponentModel.ISupportInitialize) this._btnFormToolBar_5).EndInit();
			//((System.ComponentModel.ISupportInitialize) this._btnFormToolBar_9).EndInit();
			this.picFormToolbar.ResumeLayout(false);
			this.cmbCommon.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		void ReLoadForm(bool addEvents)
		{
			InitializetxtCommonDisplay();
			InitializetxtCommon();
			InitializelblCommon();
			InitializebtnFormToolBar();
			//This form is an MDI child.
			//This code simulates the VB6 
			// functionality of automatically
			// loading and showing an MDI
			// child's parent.
			this.MdiParent = Xtreme.frmSysMain.DefInstance;
			Xtreme.frmSysMain.DefInstance.Show();
		}
		void InitializetxtCommonDisplay()
		{
			this.txtCommonDisplay = new System.Windows.Forms.Label[1];
			this.txtCommonDisplay[0] = _txtCommonDisplay_0;
		}
		void InitializetxtCommon()
		{
			this.txtCommon = new System.Windows.Forms.TextBox[1];
			this.txtCommon[0] = _txtCommon_0;
		}
		void InitializelblCommon()
		{
			this.lblCommon = new System.Windows.Forms.Label[9];
			this.lblCommon[8] = _lblCommon_8;
			this.lblCommon[0] = _lblCommon_0;
		}
		void InitializebtnFormToolBar()
		{
			this.btnFormToolBar = new AxSmartNetButtonProject.AxSmartNetButton[10];
			this.btnFormToolBar[0] = _btnFormToolBar_0;
			this.btnFormToolBar[1] = _btnFormToolBar_1;
			this.btnFormToolBar[3] = _btnFormToolBar_3;
			this.btnFormToolBar[7] = _btnFormToolBar_7;
			this.btnFormToolBar[8] = _btnFormToolBar_8;
			this.btnFormToolBar[6] = _btnFormToolBar_6;
			this.btnFormToolBar[5] = _btnFormToolBar_5;
			this.btnFormToolBar[9] = _btnFormToolBar_9;
		}
		#endregion
	}
}//ENDSHERE
