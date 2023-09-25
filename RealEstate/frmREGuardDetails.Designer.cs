
namespace Xtreme
{
	partial class frmREGuardDetails
	{

		#region "Upgrade Support "
		private static frmREGuardDetails m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmREGuardDetails DefInstance
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
		public static frmREGuardDetails CreateInstance()
		{
			frmREGuardDetails theInstance = new frmREGuardDetails();
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
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "_btnFormToolBar_0", "_btnFormToolBar_1", "_btnFormToolBar_5", "_btnFormToolBar_2", "_btnFormToolBar_3", "_btnFormToolBar_6", "_btnFormToolBar_4", "picFormToolbar", "_txtDateCommonDisplay_0", "txtRemarks", "lblComments", "lblAssetsAdjustmentAccount", "_txtCommon_1", "System.Windows.Forms.Label1", "System.Windows.Forms.Label2", "System.Windows.Forms.Label3", "_txtCommon_0", "_txtDateCommonDisplay_1", "_txtCommonDisplay_0", "_txtCommonDisplay_1", "TDBContainer3D1", "btnFormToolBar", "txtCommon", "txtCommonDisplay", "txtDateCommonDisplay"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		private AxSmartNetButtonProject.AxSmartNetButton _btnFormToolBar_0;
		private AxSmartNetButtonProject.AxSmartNetButton _btnFormToolBar_1;
		private AxSmartNetButtonProject.AxSmartNetButton _btnFormToolBar_5;
		private AxSmartNetButtonProject.AxSmartNetButton _btnFormToolBar_2;
		private AxSmartNetButtonProject.AxSmartNetButton _btnFormToolBar_3;
		private AxSmartNetButtonProject.AxSmartNetButton _btnFormToolBar_6;
		private AxSmartNetButtonProject.AxSmartNetButton _btnFormToolBar_4;
		public System.Windows.Forms.PictureBox picFormToolbar;
		private Syncfusion.WinForms.Input.SfDateTimeEdit _txtDateCommonDisplay_0;
		public System.Windows.Forms.TextBox txtRemarks;
		public System.Windows.Forms.Label lblComments;
		public System.Windows.Forms.Label lblAssetsAdjustmentAccount;
		private System.Windows.Forms.TextBox _txtCommon_1;
		public System.Windows.Forms.Label Label1;
		public System.Windows.Forms.Label Label2;
		public System.Windows.Forms.Label Label3;
		private System.Windows.Forms.TextBox _txtCommon_0;
		private Syncfusion.WinForms.Input.SfDateTimeEdit _txtDateCommonDisplay_1;
		private System.Windows.Forms.Label _txtCommonDisplay_0;
		private System.Windows.Forms.Label _txtCommonDisplay_1;
		public System.Windows.Forms.Panel TDBContainer3D1;
		public AxSmartNetButtonProject.AxSmartNetButton[] btnFormToolBar = new AxSmartNetButtonProject.AxSmartNetButton[7];
		public System.Windows.Forms.TextBox[] txtCommon = new System.Windows.Forms.TextBox[2];
		public System.Windows.Forms.Label[] txtCommonDisplay = new System.Windows.Forms.Label[2];
		public Syncfusion.WinForms.Input.SfDateTimeEdit[] txtDateCommonDisplay = new Syncfusion.WinForms.Input.SfDateTimeEdit[2];
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmREGuardDetails));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this.picFormToolbar = new System.Windows.Forms.PictureBox();
			this._btnFormToolBar_0 = new AxSmartNetButtonProject.AxSmartNetButton();
			this._btnFormToolBar_1 = new AxSmartNetButtonProject.AxSmartNetButton();
			this._btnFormToolBar_5 = new AxSmartNetButtonProject.AxSmartNetButton();
			this._btnFormToolBar_2 = new AxSmartNetButtonProject.AxSmartNetButton();
			this._btnFormToolBar_3 = new AxSmartNetButtonProject.AxSmartNetButton();
			this._btnFormToolBar_6 = new AxSmartNetButtonProject.AxSmartNetButton();
			this._btnFormToolBar_4 = new AxSmartNetButtonProject.AxSmartNetButton();
			this.TDBContainer3D1 = new System.Windows.Forms.Panel();
			this._txtDateCommonDisplay_0 = new Syncfusion.WinForms.Input.SfDateTimeEdit();
			this.txtRemarks = new System.Windows.Forms.TextBox();
			this.lblComments = new System.Windows.Forms.Label();
			this.lblAssetsAdjustmentAccount = new System.Windows.Forms.Label();
			this._txtCommon_1 = new System.Windows.Forms.TextBox();
			this.Label1 = new System.Windows.Forms.Label();
			this.Label2 = new System.Windows.Forms.Label();
			this.Label3 = new System.Windows.Forms.Label();
			this._txtCommon_0 = new System.Windows.Forms.TextBox();
			this._txtDateCommonDisplay_1 = new Syncfusion.WinForms.Input.SfDateTimeEdit();
			this._txtCommonDisplay_0 = new System.Windows.Forms.Label();
			this._txtCommonDisplay_1 = new System.Windows.Forms.Label();
			// //((System.ComponentModel.ISupportInitialize) this._btnFormToolBar_0).BeginInit();
			// //((System.ComponentModel.ISupportInitialize) this._btnFormToolBar_1).BeginInit();
			// //((System.ComponentModel.ISupportInitialize) this._btnFormToolBar_5).BeginInit();
			// //((System.ComponentModel.ISupportInitialize) this._btnFormToolBar_2).BeginInit();
			// //((System.ComponentModel.ISupportInitialize) this._btnFormToolBar_3).BeginInit();
			// //((System.ComponentModel.ISupportInitialize) this._btnFormToolBar_6).BeginInit();
			// //((System.ComponentModel.ISupportInitialize) this._btnFormToolBar_4).BeginInit();
			// //((System.ComponentModel.ISupportInitialize) this.TDBContainer3D1).BeginInit();
			this.picFormToolbar.SuspendLayout();
			this.TDBContainer3D1.SuspendLayout();
			this.SuspendLayout();
			// 
			// picFormToolbar
			// 
			this.picFormToolbar.AllowDrop = true;
			this.picFormToolbar.BackColor = System.Drawing.SystemColors.Control;
			this.picFormToolbar.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.picFormToolbar.CausesValidation = true;
			this.picFormToolbar.Controls.Add(this._btnFormToolBar_0);
			this.picFormToolbar.Controls.Add(this._btnFormToolBar_1);
			this.picFormToolbar.Controls.Add(this._btnFormToolBar_5);
			this.picFormToolbar.Controls.Add(this._btnFormToolBar_2);
			this.picFormToolbar.Controls.Add(this._btnFormToolBar_3);
			this.picFormToolbar.Controls.Add(this._btnFormToolBar_6);
			this.picFormToolbar.Controls.Add(this._btnFormToolBar_4);
			this.picFormToolbar.Dock = System.Windows.Forms.DockStyle.Top;
			this.picFormToolbar.Enabled = true;
			this.picFormToolbar.Location = new System.Drawing.Point(0, 0);
			this.picFormToolbar.Name = "picFormToolbar";
			this.picFormToolbar.Size = new System.Drawing.Size(483, 38);
			this.picFormToolbar.TabIndex = 2;
			this.picFormToolbar.TabStop = false;
			this.picFormToolbar.Visible = true;
			// 
			// _btnFormToolBar_0
			// 
			this._btnFormToolBar_0.AllowDrop = true;
			this._btnFormToolBar_0.Location = new System.Drawing.Point(2, 2);
			this._btnFormToolBar_0.Name = "_btnFormToolBar_0";
			//
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
			//
			this._btnFormToolBar_1.Size = new System.Drawing.Size(51, 34);
			this._btnFormToolBar_1.TabIndex = 4;
			this._btnFormToolBar_1.TabStop = false;
			this._btnFormToolBar_1.Tag = "Save";
			// 
			// _btnFormToolBar_5
			// 
			this._btnFormToolBar_5.AllowDrop = true;
			this._btnFormToolBar_5.Location = new System.Drawing.Point(257, 2);
			this._btnFormToolBar_5.Name = "_btnFormToolBar_5";
			//
			this._btnFormToolBar_5.Size = new System.Drawing.Size(51, 34);
			this._btnFormToolBar_5.TabIndex = 5;
			this._btnFormToolBar_5.TabStop = false;
			this._btnFormToolBar_5.Tag = "Help";
			// 
			// _btnFormToolBar_2
			// 
			this._btnFormToolBar_2.AllowDrop = true;
			this._btnFormToolBar_2.Location = new System.Drawing.Point(104, 2);
			this._btnFormToolBar_2.Name = "_btnFormToolBar_2";
			//
			this._btnFormToolBar_2.Size = new System.Drawing.Size(51, 34);
			this._btnFormToolBar_2.TabIndex = 6;
			this._btnFormToolBar_2.TabStop = false;
			this._btnFormToolBar_2.Tag = "Delete";
			// 
			// _btnFormToolBar_3
			// 
			this._btnFormToolBar_3.AllowDrop = true;
			this._btnFormToolBar_3.Location = new System.Drawing.Point(155, 2);
			this._btnFormToolBar_3.Name = "_btnFormToolBar_3";
			//
			this._btnFormToolBar_3.Size = new System.Drawing.Size(51, 34);
			this._btnFormToolBar_3.TabIndex = 7;
			this._btnFormToolBar_3.TabStop = false;
			this._btnFormToolBar_3.Tag = "Print";
			// 
			// _btnFormToolBar_6
			// 
			this._btnFormToolBar_6.AllowDrop = true;
			this._btnFormToolBar_6.Location = new System.Drawing.Point(308, 2);
			this._btnFormToolBar_6.Name = "_btnFormToolBar_6";
			//
			this._btnFormToolBar_6.Size = new System.Drawing.Size(51, 34);
			this._btnFormToolBar_6.TabIndex = 8;
			this._btnFormToolBar_6.TabStop = false;
			this._btnFormToolBar_6.Tag = "Exit";
			// 
			// _btnFormToolBar_4
			// 
			this._btnFormToolBar_4.AllowDrop = true;
			this._btnFormToolBar_4.Location = new System.Drawing.Point(206, 2);
			this._btnFormToolBar_4.Name = "_btnFormToolBar_4";
			//
			this._btnFormToolBar_4.Size = new System.Drawing.Size(51, 34);
			this._btnFormToolBar_4.TabIndex = 9;
			this._btnFormToolBar_4.TabStop = false;
			this._btnFormToolBar_4.Tag = "Find";
			// 
			// TDBContainer3D1
			// 
			this.TDBContainer3D1.AllowDrop = true;
			this.TDBContainer3D1.Controls.Add(this._txtDateCommonDisplay_0);
			this.TDBContainer3D1.Controls.Add(this.txtRemarks);
			this.TDBContainer3D1.Controls.Add(this.lblComments);
			this.TDBContainer3D1.Controls.Add(this.lblAssetsAdjustmentAccount);
			this.TDBContainer3D1.Controls.Add(this._txtCommon_1);
			this.TDBContainer3D1.Controls.Add(this.Label1);
			this.TDBContainer3D1.Controls.Add(this.Label2);
			this.TDBContainer3D1.Controls.Add(this.Label3);
			this.TDBContainer3D1.Controls.Add(this._txtCommon_0);
			this.TDBContainer3D1.Controls.Add(this._txtDateCommonDisplay_1);
			this.TDBContainer3D1.Controls.Add(this._txtCommonDisplay_0);
			this.TDBContainer3D1.Controls.Add(this._txtCommonDisplay_1);
			this.TDBContainer3D1.Location = new System.Drawing.Point(10, 44);
			this.TDBContainer3D1.Name = "TDBContainer3D1";
			//
			this.TDBContainer3D1.Size = new System.Drawing.Size(464, 133);
			this.TDBContainer3D1.TabIndex = 10;
			// 
			// _txtDateCommonDisplay_0
			// 
			this._txtDateCommonDisplay_0.AllowDrop = true;
			this._txtDateCommonDisplay_0.Location = new System.Drawing.Point(106, 54);
			// this._txtDateCommonDisplay_0.MaxDate = 2958465;
			// this._txtDateCommonDisplay_0.MinDate = 2;
			this._txtDateCommonDisplay_0.Name = "_txtDateCommonDisplay_0";
			this._txtDateCommonDisplay_0.Size = new System.Drawing.Size(81, 19);
			this._txtDateCommonDisplay_0.TabIndex = 17;
			this._txtDateCommonDisplay_0.Text = "10/07/2004";
			// this._txtDateCommonDisplay_0.Value = 38178;
			// 
			// txtRemarks
			// 
			this.txtRemarks.AcceptsReturn = true;
			this.txtRemarks.AllowDrop = true;
			this.txtRemarks.BackColor = System.Drawing.SystemColors.Window;
			this.txtRemarks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtRemarks.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtRemarks.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtRemarks.Location = new System.Drawing.Point(106, 75);
			this.txtRemarks.MaxLength = 100;
			this.txtRemarks.Multiline = true;
			this.txtRemarks.Name = "txtRemarks";
			this.txtRemarks.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtRemarks.Size = new System.Drawing.Size(302, 35);
			this.txtRemarks.TabIndex = 11;
			// 
			// lblComments
			// 
			this.lblComments.AllowDrop = true;
			this.lblComments.BackColor = System.Drawing.Color.FromArgb(237, 231, 235);
			this.lblComments.Text = "Comments";
			this.lblComments.ForeColor = System.Drawing.Color.Black;
			this.lblComments.Location = new System.Drawing.Point(16, 86);
			// // this.lblComments.mLabelId = 135;
			this.lblComments.Name = "lblComments";
			this.lblComments.Size = new System.Drawing.Size(49, 13);
			this.lblComments.TabIndex = 12;
			// 
			// lblAssetsAdjustmentAccount
			// 
			this.lblAssetsAdjustmentAccount.AllowDrop = true;
			this.lblAssetsAdjustmentAccount.BackColor = System.Drawing.Color.FromArgb(237, 231, 235);
			this.lblAssetsAdjustmentAccount.Text = "Guard Code";
			this.lblAssetsAdjustmentAccount.ForeColor = System.Drawing.Color.Black;
			this.lblAssetsAdjustmentAccount.Location = new System.Drawing.Point(16, 35);
			// // this.lblAssetsAdjustmentAccount.mLabelId = 1179;
			this.lblAssetsAdjustmentAccount.Name = "lblAssetsAdjustmentAccount";
			this.lblAssetsAdjustmentAccount.Size = new System.Drawing.Size(58, 14);
			this.lblAssetsAdjustmentAccount.TabIndex = 13;
			// 
			// _txtCommon_1
			// 
			this._txtCommon_1.AllowDrop = true;
			this._txtCommon_1.BackColor = System.Drawing.Color.White;
			// this._txtCommon_1.bolNumericOnly = true;
			this._txtCommon_1.ForeColor = System.Drawing.Color.Black;
			this._txtCommon_1.Location = new System.Drawing.Point(106, 33);
			this._txtCommon_1.MaxLength = 15;
			this._txtCommon_1.Name = "_txtCommon_1";
			// this._txtCommon_1.ShowButton = true;
			this._txtCommon_1.Size = new System.Drawing.Size(101, 19);
			this._txtCommon_1.TabIndex = 1;
			this._txtCommon_1.Text = "";
			// this.this._txtCommon_1.Watermark = "";
			// 
			// System.Windows.Forms.Label1
			// 
			this.Label1.AllowDrop = true;
			this.Label1.BackColor = System.Drawing.Color.FromArgb(237, 231, 235);
			this.Label1.Text = "Starting Date";
			this.Label1.ForeColor = System.Drawing.Color.Black;
			this.Label1.Location = new System.Drawing.Point(16, 56);
			// this.Label1.mLabelId = 1160;
			this.Label1.Name = "System.Windows.Forms.Label1";
			this.Label1.Size = new System.Drawing.Size(62, 14);
			this.Label1.TabIndex = 14;
			// 
			// System.Windows.Forms.Label2
			// 
			this.Label2.AllowDrop = true;
			this.Label2.BackColor = System.Drawing.Color.FromArgb(237, 231, 235);
			this.Label2.Text = "Ending Date";
			this.Label2.ForeColor = System.Drawing.Color.Black;
			this.Label2.Location = new System.Drawing.Point(258, 56);
			// this.Label2.mLabelId = 1161;
			this.Label2.Name = "System.Windows.Forms.Label2";
			this.Label2.Size = new System.Drawing.Size(57, 14);
			this.Label2.TabIndex = 15;
			// 
			// System.Windows.Forms.Label3
			// 
			this.Label3.AllowDrop = true;
			this.Label3.BackColor = System.Drawing.Color.FromArgb(237, 231, 235);
			this.Label3.Text = "Property No";
			this.Label3.ForeColor = System.Drawing.Color.Black;
			this.Label3.Location = new System.Drawing.Point(16, 14);
			// this.Label3.mLabelId = 1178;
			this.Label3.Name = "System.Windows.Forms.Label3";
			this.Label3.Size = new System.Drawing.Size(57, 14);
			this.Label3.TabIndex = 16;
			// 
			// _txtCommon_0
			// 
			this._txtCommon_0.AllowDrop = true;
			this._txtCommon_0.BackColor = System.Drawing.Color.White;
			// this._txtCommon_0.bolNumericOnly = true;
			this._txtCommon_0.ForeColor = System.Drawing.Color.Black;
			this._txtCommon_0.Location = new System.Drawing.Point(106, 12);
			this._txtCommon_0.MaxLength = 15;
			this._txtCommon_0.Name = "_txtCommon_0";
			// this._txtCommon_0.ShowButton = true;
			this._txtCommon_0.Size = new System.Drawing.Size(101, 19);
			this._txtCommon_0.TabIndex = 0;
			this._txtCommon_0.Text = "";
			// this.this._txtCommon_0.Watermark = "";
			// 
			// _txtDateCommonDisplay_1
			// 
			this._txtDateCommonDisplay_1.AllowDrop = true;
			this._txtDateCommonDisplay_1.Location = new System.Drawing.Point(328, 54);
			// this._txtDateCommonDisplay_1.MaxDate = 2958465;
			// this._txtDateCommonDisplay_1.MinDate = 2;
			this._txtDateCommonDisplay_1.Name = "_txtDateCommonDisplay_1";
			this._txtDateCommonDisplay_1.Size = new System.Drawing.Size(81, 19);
			this._txtDateCommonDisplay_1.TabIndex = 18;
			this._txtDateCommonDisplay_1.Text = "09/11/2004";
			// this._txtDateCommonDisplay_1.Value = 38300;
			// 
			// _txtCommonDisplay_0
			// 
			this._txtCommonDisplay_0.AllowDrop = true;
			this._txtCommonDisplay_0.Location = new System.Drawing.Point(207, 12);
			this._txtCommonDisplay_0.Name = "_txtCommonDisplay_0";
			this._txtCommonDisplay_0.Size = new System.Drawing.Size(201, 19);
			this._txtCommonDisplay_0.TabIndex = 19;
			// 
			// _txtCommonDisplay_1
			// 
			this._txtCommonDisplay_1.AllowDrop = true;
			this._txtCommonDisplay_1.Location = new System.Drawing.Point(207, 33);
			this._txtCommonDisplay_1.Name = "_txtCommonDisplay_1";
			this._txtCommonDisplay_1.Size = new System.Drawing.Size(201, 19);
			this._txtCommonDisplay_1.TabIndex = 20;
			// 
			// frmREGuardDetails
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.ClientSize = new System.Drawing.Size(483, 186);
			this.Controls.Add(this.picFormToolbar);
			this.Controls.Add(this.TDBContainer3D1);
			//this.Icon = (System.Drawing.Icon) resources.GetObject("frmREGuardDetails.Icon");
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(127, 237);
			this.MaximizeBox = true;
			this.MinimizeBox = true;
			this.Name = "frmREGuardDetails";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Guard Details";
			// this.Activated += new System.EventHandler(this.frmREGuardDetails_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
			//((System.ComponentModel.ISupportInitialize) this._btnFormToolBar_0).EndInit();
			//((System.ComponentModel.ISupportInitialize) this._btnFormToolBar_1).EndInit();
			//((System.ComponentModel.ISupportInitialize) this._btnFormToolBar_5).EndInit();
			//((System.ComponentModel.ISupportInitialize) this._btnFormToolBar_2).EndInit();
			//((System.ComponentModel.ISupportInitialize) this._btnFormToolBar_3).EndInit();
			//((System.ComponentModel.ISupportInitialize) this._btnFormToolBar_6).EndInit();
			//((System.ComponentModel.ISupportInitialize) this._btnFormToolBar_4).EndInit();
			//((System.ComponentModel.ISupportInitialize) this.TDBContainer3D1).EndInit();
			this.picFormToolbar.ResumeLayout(false);
			this.TDBContainer3D1.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		// 
		void InitializetxtDateCommonDisplay()
		{
			this.txtDateCommonDisplay = new Syncfusion.WinForms.Input.SfDateTimeEdit[2];
			this.txtDateCommonDisplay[0] = _txtDateCommonDisplay_0;
			this.txtDateCommonDisplay[1] = _txtDateCommonDisplay_1;
		}
		void InitializetxtCommonDisplay()
		{
			this.txtCommonDisplay = new System.Windows.Forms.Label[2];
			this.txtCommonDisplay[0] = _txtCommonDisplay_0;
			this.txtCommonDisplay[1] = _txtCommonDisplay_1;
		}
		void InitializetxtCommon()
		{
			this.txtCommon = new System.Windows.Forms.TextBox[2];
			this.txtCommon[1] = _txtCommon_1;
			this.txtCommon[0] = _txtCommon_0;
		}
		void InitializebtnFormToolBar()
		{
			this.btnFormToolBar = new AxSmartNetButtonProject.AxSmartNetButton[7];
			this.btnFormToolBar[0] = _btnFormToolBar_0;
			this.btnFormToolBar[1] = _btnFormToolBar_1;
			this.btnFormToolBar[5] = _btnFormToolBar_5;
			this.btnFormToolBar[2] = _btnFormToolBar_2;
			this.btnFormToolBar[3] = _btnFormToolBar_3;
			this.btnFormToolBar[6] = _btnFormToolBar_6;
			this.btnFormToolBar[4] = _btnFormToolBar_4;
		}
		#endregion
	}
}//ENDSHERE
