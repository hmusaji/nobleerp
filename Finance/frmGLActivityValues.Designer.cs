
namespace Xtreme
{
	partial class frmGLActivityValues
	{

		#region "Upgrade Support "
		private static frmGLActivityValues m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmGLActivityValues DefInstance
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
		public static frmGLActivityValues CreateInstance()
		{
			frmGLActivityValues theInstance = new frmGLActivityValues();
			
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
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "chkFreeze", "grdVoucherDetails", "tabFGeneral", "tabMaster", "_txtCommon_0", "_lblDisplayLabel_2", "_txtCommon_1", "_lblDisplayLabel_3", "_txtCommon_2", "_lblDisplayLabel_1", "_lblCommon_7", "txtActivityType", "txtActivityTypeName", "lblCommon", "lblDisplayLabel", "txtCommon"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public System.Windows.Forms.CheckBox chkFreeze;
		public C1.Win.C1TrueDBGrid.C1TrueDBGrid grdVoucherDetails;
		public AxXtremeSuiteControls.AxTabControlPage tabFGeneral;
		public AxXtremeSuiteControls.AxTabControl tabMaster;
		private System.Windows.Forms.TextBox _txtCommon_0;
		private System.Windows.Forms.Label _lblDisplayLabel_2;
		private System.Windows.Forms.TextBox _txtCommon_1;
		private System.Windows.Forms.Label _lblDisplayLabel_3;
		private System.Windows.Forms.TextBox _txtCommon_2;
		private System.Windows.Forms.Label _lblDisplayLabel_1;
		private System.Windows.Forms.Label _lblCommon_7;
		public System.Windows.Forms.TextBox txtActivityType;
		public System.Windows.Forms.Label txtActivityTypeName;
		public System.Windows.Forms.Label[] lblCommon = new System.Windows.Forms.Label[8];
		public System.Windows.Forms.Label[] lblDisplayLabel = new System.Windows.Forms.Label[4];
		public System.Windows.Forms.TextBox[] txtCommon = new System.Windows.Forms.TextBox[3];
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGLActivityValues));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this.chkFreeze = new System.Windows.Forms.CheckBox();
			this.tabMaster = new AxXtremeSuiteControls.AxTabControl();
			this.tabFGeneral = new AxXtremeSuiteControls.AxTabControlPage();
			this.grdVoucherDetails = new C1.Win.C1TrueDBGrid.C1TrueDBGrid();
			this._txtCommon_0 = new System.Windows.Forms.TextBox();
			this._lblDisplayLabel_2 = new System.Windows.Forms.Label();
			this._txtCommon_1 = new System.Windows.Forms.TextBox();
			this._lblDisplayLabel_3 = new System.Windows.Forms.Label();
			this._txtCommon_2 = new System.Windows.Forms.TextBox();
			this._lblDisplayLabel_1 = new System.Windows.Forms.Label();
			this._lblCommon_7 = new System.Windows.Forms.Label();
			this.txtActivityType = new System.Windows.Forms.TextBox();
			this.txtActivityTypeName = new System.Windows.Forms.Label();
			// //((System.ComponentModel.ISupportInitialize) this.tabFGeneral).BeginInit();
			// //((System.ComponentModel.ISupportInitialize) this.tabMaster).BeginInit();
			this.tabMaster.SuspendLayout();
			this.tabFGeneral.SuspendLayout();
			this.SuspendLayout();
			// 
			// chkFreeze
			// 
			this.chkFreeze.AllowDrop = true;
			this.chkFreeze.Appearance = System.Windows.Forms.Appearance.Normal;
			this.chkFreeze.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.chkFreeze.CausesValidation = true;
			this.chkFreeze.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkFreeze.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this.chkFreeze.Enabled = true;
			this.chkFreeze.ForeColor = System.Drawing.SystemColors.ControlText;
			this.chkFreeze.Location = new System.Drawing.Point(384, 31);
			this.chkFreeze.Name = "chkFreeze";
			this.chkFreeze.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.chkFreeze.Size = new System.Drawing.Size(78, 13);
			this.chkFreeze.TabIndex = 3;
			this.chkFreeze.TabStop = true;
			this.chkFreeze.Text = "Freeze?";
			this.chkFreeze.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkFreeze.Visible = true;
			// 
			// tabMaster
			// 
			this.tabMaster.AllowDrop = true;
			this.tabMaster.Controls.Add(this.tabFGeneral);
			this.tabMaster.Location = new System.Drawing.Point(6, 128);
			this.tabMaster.Name = "tabMaster";
			("tabMaster.OcxState");
			this.tabMaster.Size = new System.Drawing.Size(869, 239);
			this.tabMaster.TabIndex = 0;
			// 
			// tabFGeneral
			// 
			this.tabFGeneral.AllowDrop = true;
			this.tabFGeneral.Controls.Add(this.grdVoucherDetails);
			this.tabFGeneral.Location = new System.Drawing.Point(2, 28);
			this.tabFGeneral.Name = "tabFGeneral";
			("tabFGeneral.OcxState");
			this.tabFGeneral.Size = new System.Drawing.Size(865, 209);
			this.tabFGeneral.TabIndex = 1;
			// 
			// grdVoucherDetails
			// 
			this.grdVoucherDetails.AllowDrop = true;
			this.grdVoucherDetails.BackColor = System.Drawing.Color.Silver;
			this.grdVoucherDetails.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.grdVoucherDetails.CellTipsWidth = 0;
			this.grdVoucherDetails.Location = new System.Drawing.Point(0, 2);
			this.grdVoucherDetails.Name = "grdVoucherDetails";
			this.grdVoucherDetails.RowDivider.Color = System.Drawing.Color.Silver;
			this.grdVoucherDetails.Size = new System.Drawing.Size(861, 204);
			this.grdVoucherDetails.TabIndex = 2;
			this.grdVoucherDetails.GotFocus += new System.EventHandler(this.grdVoucherDetails_GotFocus);
			// 
			// _txtCommon_0
			// 
			this._txtCommon_0.AllowDrop = true;
			this._txtCommon_0.BackColor = System.Drawing.Color.White;
			this._txtCommon_0.ForeColor = System.Drawing.Color.Black;
			this._txtCommon_0.Location = new System.Drawing.Point(166, 28);
			this._txtCommon_0.MaxLength = 15;
			// this._txtCommon_0.mDropDownType = System.Windows.Forms.TextBox.DropDownTypes.ddtNextNumber;
			this._txtCommon_0.Name = "_txtCommon_0";
			// this._txtCommon_0.ShowButton = true;
			this._txtCommon_0.Size = new System.Drawing.Size(101, 19);
			this._txtCommon_0.TabIndex = 4;
			this._txtCommon_0.Text = "";
			// 
			// _lblDisplayLabel_2
			// 
			this._lblDisplayLabel_2.AllowDrop = true;
			this._lblDisplayLabel_2.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblDisplayLabel_2.Text = "Activity Name (English)";
			this._lblDisplayLabel_2.ForeColor = System.Drawing.Color.Black;
			this._lblDisplayLabel_2.Location = new System.Drawing.Point(10, 51);
			this._lblDisplayLabel_2.Name = "_lblDisplayLabel_2";
			this._lblDisplayLabel_2.Size = new System.Drawing.Size(111, 14);
			this._lblDisplayLabel_2.TabIndex = 5;
			// 
			// _txtCommon_1
			// 
			this._txtCommon_1.AllowDrop = true;
			this._txtCommon_1.BackColor = System.Drawing.Color.White;
			this._txtCommon_1.ForeColor = System.Drawing.Color.Black;
			this._txtCommon_1.Location = new System.Drawing.Point(166, 50);
			this._txtCommon_1.MaxLength = 50;
			this._txtCommon_1.Name = "_txtCommon_1";
			this._txtCommon_1.Size = new System.Drawing.Size(201, 19);
			this._txtCommon_1.TabIndex = 6;
			this._txtCommon_1.Text = "";
			// 
			// _lblDisplayLabel_3
			// 
			this._lblDisplayLabel_3.AllowDrop = true;
			this._lblDisplayLabel_3.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblDisplayLabel_3.Text = "Activity Name (Arabic)";
			this._lblDisplayLabel_3.ForeColor = System.Drawing.Color.Black;
			this._lblDisplayLabel_3.Location = new System.Drawing.Point(10, 72);
			this._lblDisplayLabel_3.Name = "_lblDisplayLabel_3";
			this._lblDisplayLabel_3.Size = new System.Drawing.Size(109, 14);
			this._lblDisplayLabel_3.TabIndex = 7;
			// 
			// _txtCommon_2
			// 
			this._txtCommon_2.AllowDrop = true;
			this._txtCommon_2.BackColor = System.Drawing.Color.White;
			this._txtCommon_2.ForeColor = System.Drawing.Color.Black;
			this._txtCommon_2.Location = new System.Drawing.Point(166, 72);
			// this._txtCommon_2.mArabicEnabled = true;
			this._txtCommon_2.MaxLength = 50;
			this._txtCommon_2.Name = "_txtCommon_2";
			this._txtCommon_2.Size = new System.Drawing.Size(201, 19);
			this._txtCommon_2.TabIndex = 8;
			this._txtCommon_2.Text = "";
			// 
			// _lblDisplayLabel_1
			// 
			this._lblDisplayLabel_1.AllowDrop = true;
			this._lblDisplayLabel_1.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblDisplayLabel_1.Text = "Activity Code";
			this._lblDisplayLabel_1.ForeColor = System.Drawing.Color.Black;
			this._lblDisplayLabel_1.Location = new System.Drawing.Point(10, 30);
			this._lblDisplayLabel_1.Name = "_lblDisplayLabel_1";
			this._lblDisplayLabel_1.Size = new System.Drawing.Size(64, 14);
			this._lblDisplayLabel_1.TabIndex = 9;
			// 
			// _lblCommon_7
			// 
			this._lblCommon_7.AllowDrop = true;
			this._lblCommon_7.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_7.Text = "Activity Type";
			this._lblCommon_7.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_7.Location = new System.Drawing.Point(10, 95);
			this._lblCommon_7.Name = "_lblCommon_7";
			this._lblCommon_7.Size = new System.Drawing.Size(63, 14);
			this._lblCommon_7.TabIndex = 10;
			// 
			// txtActivityType
			// 
			this.txtActivityType.AllowDrop = true;
			this.txtActivityType.BackColor = System.Drawing.Color.White;
			// this.txtActivityType.bolNumericOnly = true;
			this.txtActivityType.ForeColor = System.Drawing.Color.Black;
			this.txtActivityType.Location = new System.Drawing.Point(166, 94);
			this.txtActivityType.Name = "txtActivityType";
			// this.txtActivityType.ShowButton = true;
			this.txtActivityType.Size = new System.Drawing.Size(101, 19);
			this.txtActivityType.TabIndex = 11;
			this.txtActivityType.Text = "";
			// this.this.txtActivityType.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtActivityType_DropButtonClick);
			// this.txtActivityType.Leave += new System.EventHandler(this.txtActivityType_Leave);
			// 
			// txtActivityTypeName
			// 
			this.txtActivityTypeName.AllowDrop = true;
			this.txtActivityTypeName.Location = new System.Drawing.Point(270, 94);
			this.txtActivityTypeName.Name = "txtActivityTypeName";
			this.txtActivityTypeName.Size = new System.Drawing.Size(201, 19);
			this.txtActivityTypeName.TabIndex = 12;
			// 
			// frmGLActivityValues
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.ClientSize = new System.Drawing.Size(952, 632);
			this.Controls.Add(this.chkFreeze);
			this.Controls.Add(this.tabMaster);
			this.Controls.Add(this._txtCommon_0);
			this.Controls.Add(this._lblDisplayLabel_2);
			this.Controls.Add(this._txtCommon_1);
			this.Controls.Add(this._lblDisplayLabel_3);
			this.Controls.Add(this._txtCommon_2);
			this.Controls.Add(this._lblDisplayLabel_1);
			this.Controls.Add(this._lblCommon_7);
			this.Controls.Add(this.txtActivityType);
			this.Controls.Add(this.txtActivityTypeName);
			//this.Icon = (System.Drawing.Icon) resources.GetObject("frmGLActivityValues.Icon");
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(230, 168);
			this.MaximizeBox = true;
			this.MinimizeBox = true;
			this.Name = "frmGLActivityValues";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Activity Values";
			// this.Activated += new System.EventHandler(this.frmGLActivityValues_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
			// this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
			//this.Resize += new System.EventHandler(this.Form_Resize);
			//((System.ComponentModel.ISupportInitialize) this.tabFGeneral).EndInit();
			//((System.ComponentModel.ISupportInitialize) this.tabMaster).EndInit();
			this.tabMaster.ResumeLayout(false);
			this.tabFGeneral.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		void ReLoadForm(bool addEvents)
		{
			InitializetxtCommon();
			InitializelblDisplayLabel();
			InitializelblCommon();
			//This form is an MDI child.
			//This code simulates the VB6 
			// functionality of automatically
			// loading and showing an MDI
			// child's parent.
			this.MdiParent = Xtreme.frmSysMain.DefInstance;
			Xtreme.frmSysMain.DefInstance.Show();
		}
		void InitializetxtCommon()
		{
			this.txtCommon = new System.Windows.Forms.TextBox[3];
			this.txtCommon[0] = _txtCommon_0;
			this.txtCommon[1] = _txtCommon_1;
			this.txtCommon[2] = _txtCommon_2;
		}
		void InitializelblDisplayLabel()
		{
			this.lblDisplayLabel = new System.Windows.Forms.Label[4];
			this.lblDisplayLabel[2] = _lblDisplayLabel_2;
			this.lblDisplayLabel[3] = _lblDisplayLabel_3;
			this.lblDisplayLabel[1] = _lblDisplayLabel_1;
		}
		void InitializelblCommon()
		{
			this.lblCommon = new System.Windows.Forms.Label[8];
			this.lblCommon[7] = _lblCommon_7;
		}
		#endregion
	}
}//ENDSHERE
