
namespace Xtreme
{
	partial class frmFAAssetsAdjusment
	{

		#region "Upgrade Support "
		private static frmFAAssetsAdjusment m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmFAAssetsAdjusment DefInstance
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
		public static frmFAAssetsAdjusment CreateInstance()
		{
			frmFAAssetsAdjusment theInstance = new frmFAAssetsAdjusment();
			
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
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "txtAdjustmentDate", "txtAdjustmentAmount", "txtRemarks", "_txtCommon_0", "lblLCostName", "lblAssetsCode", "lblComments", "lblAssetsAdjustmentNo", "lblAssetsAdjustmentAccount", "_txtCommon_2", "lblAssetsAdjustmentCostCenter", "_txtCommon_3", "lblAdjustmentAmount", "_txtCommon_1", "_txtCommonDisplay_1", "_txtCommonDisplay_0", "_txtCommonDisplay_2", "cntMainParameter", "txtCommon", "txtCommonDisplay"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public Syncfusion.WinForms.Input.SfDateTimeEdit txtAdjustmentDate;
		public System.Windows.Forms.TextBox txtAdjustmentAmount;
		public System.Windows.Forms.TextBox txtRemarks;
		private System.Windows.Forms.TextBox _txtCommon_0;
		public System.Windows.Forms.Label lblLCostName;
		public System.Windows.Forms.Label lblAssetsCode;
		public System.Windows.Forms.Label lblComments;
		public System.Windows.Forms.Label lblAssetsAdjustmentNo;
		public System.Windows.Forms.Label lblAssetsAdjustmentAccount;
		private System.Windows.Forms.TextBox _txtCommon_2;
		public System.Windows.Forms.Label lblAssetsAdjustmentCostCenter;
		private System.Windows.Forms.TextBox _txtCommon_3;
		public System.Windows.Forms.Label lblAdjustmentAmount;
		private System.Windows.Forms.TextBox _txtCommon_1;
		private System.Windows.Forms.Label _txtCommonDisplay_1;
		private System.Windows.Forms.Label _txtCommonDisplay_0;
		private System.Windows.Forms.Label _txtCommonDisplay_2;
		public AxTDBContainer3D6.AxTDBContainer3D cntMainParameter;
		public System.Windows.Forms.TextBox[] txtCommon = new System.Windows.Forms.TextBox[4];
		public System.Windows.Forms.Label[] txtCommonDisplay = new System.Windows.Forms.Label[3];
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFAAssetsAdjusment));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this.cntMainParameter = new AxTDBContainer3D6.AxTDBContainer3D();
			this.txtAdjustmentDate = new Syncfusion.WinForms.Input.SfDateTimeEdit();
			this.txtAdjustmentAmount = new System.Windows.Forms.TextBox();
			this.txtRemarks = new System.Windows.Forms.TextBox();
			this._txtCommon_0 = new System.Windows.Forms.TextBox();
			this.lblLCostName = new System.Windows.Forms.Label();
			this.lblAssetsCode = new System.Windows.Forms.Label();
			this.lblComments = new System.Windows.Forms.Label();
			this.lblAssetsAdjustmentNo = new System.Windows.Forms.Label();
			this.lblAssetsAdjustmentAccount = new System.Windows.Forms.Label();
			this._txtCommon_2 = new System.Windows.Forms.TextBox();
			this.lblAssetsAdjustmentCostCenter = new System.Windows.Forms.Label();
			this._txtCommon_3 = new System.Windows.Forms.TextBox();
			this.lblAdjustmentAmount = new System.Windows.Forms.Label();
			this._txtCommon_1 = new System.Windows.Forms.TextBox();
			this._txtCommonDisplay_1 = new System.Windows.Forms.Label();
			this._txtCommonDisplay_0 = new System.Windows.Forms.Label();
			this._txtCommonDisplay_2 = new System.Windows.Forms.Label();
			// //((System.ComponentModel.ISupportInitialize) this.cntMainParameter).BeginInit();
			this.cntMainParameter.SuspendLayout();
			this.SuspendLayout();
			// 
			// cntMainParameter
			// 
			this.cntMainParameter.AllowDrop = true;
			this.cntMainParameter.Controls.Add(this.txtAdjustmentDate);
			this.cntMainParameter.Controls.Add(this.txtAdjustmentAmount);
			this.cntMainParameter.Controls.Add(this.txtRemarks);
			this.cntMainParameter.Controls.Add(this._txtCommon_0);
			this.cntMainParameter.Controls.Add(this.lblLCostName);
			this.cntMainParameter.Controls.Add(this.lblAssetsCode);
			this.cntMainParameter.Controls.Add(this.lblComments);
			this.cntMainParameter.Controls.Add(this.lblAssetsAdjustmentNo);
			this.cntMainParameter.Controls.Add(this.lblAssetsAdjustmentAccount);
			this.cntMainParameter.Controls.Add(this._txtCommon_2);
			this.cntMainParameter.Controls.Add(this.lblAssetsAdjustmentCostCenter);
			this.cntMainParameter.Controls.Add(this._txtCommon_3);
			this.cntMainParameter.Controls.Add(this.lblAdjustmentAmount);
			this.cntMainParameter.Controls.Add(this._txtCommon_1);
			this.cntMainParameter.Controls.Add(this._txtCommonDisplay_1);
			this.cntMainParameter.Controls.Add(this._txtCommonDisplay_0);
			this.cntMainParameter.Controls.Add(this._txtCommonDisplay_2);
			this.cntMainParameter.Location = new System.Drawing.Point(6, 44);
			this.cntMainParameter.Name = "cntMainParameter";
			//
			this.cntMainParameter.Size = new System.Drawing.Size(490, 191);
			this.cntMainParameter.TabIndex = 7;
			// 
			// txtAdjustmentDate
			// 
			this.txtAdjustmentDate.AllowDrop = true;
			// this.txtAdjustmentDate.CheckDateRange = false;
			this.txtAdjustmentDate.Location = new System.Drawing.Point(136, 54);
			// this.txtAdjustmentDate.MaxDate = 2958465;
			// this.txtAdjustmentDate.MinDate = 2;
			this.txtAdjustmentDate.Name = "txtAdjustmentDate";
			this.txtAdjustmentDate.Size = new System.Drawing.Size(101, 19);
			this.txtAdjustmentDate.TabIndex = 4;
			// this.txtAdjustmentDate.Text = "15/03/2014";
			// 
			// txtAdjustmentAmount
			// 
			this.txtAdjustmentAmount.AllowDrop = true;
			// this.txtAdjustmentAmount.DisplayFormat = "########0.000###;;0.000;0.000";
			// this.txtAdjustmentAmount.Format = "###########0.000";
			this.txtAdjustmentAmount.Location = new System.Drawing.Point(136, 75);
			// this.txtAdjustmentAmount.MaxValue = 2147483647;
			// this.txtAdjustmentAmount.MinValue = -2147483648;
			this.txtAdjustmentAmount.Name = "txtAdjustmentAmount";
			this.txtAdjustmentAmount.Size = new System.Drawing.Size(101, 19);
			this.txtAdjustmentAmount.TabIndex = 5;
			this.txtAdjustmentAmount.Text = "0.000";
			// 
			// txtRemarks
			// 
			this.txtRemarks.AcceptsReturn = true;
			this.txtRemarks.AllowDrop = true;
			this.txtRemarks.BackColor = System.Drawing.SystemColors.Window;
			this.txtRemarks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtRemarks.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtRemarks.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtRemarks.Location = new System.Drawing.Point(136, 138);
			this.txtRemarks.MaxLength = 100;
			this.txtRemarks.Multiline = true;
			this.txtRemarks.Name = "txtRemarks";
			this.txtRemarks.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtRemarks.Size = new System.Drawing.Size(302, 35);
			this.txtRemarks.TabIndex = 6;
			// 
			// _txtCommon_0
			// 
			this._txtCommon_0.AllowDrop = true;
			this._txtCommon_0.BackColor = System.Drawing.Color.White;
			// this._txtCommon_0.bolNumericOnly = true;
			this._txtCommon_0.ForeColor = System.Drawing.Color.Black;
			this._txtCommon_0.Location = new System.Drawing.Point(136, 12);
			this._txtCommon_0.MaxLength = 15;
			// this._txtCommon_0.mDropDownType = System.Windows.Forms.TextBox.DropDownTypes.ddtNextNumber;
			this._txtCommon_0.Name = "_txtCommon_0";
			// this._txtCommon_0.ShowButton = true;
			this._txtCommon_0.Size = new System.Drawing.Size(101, 19);
			this._txtCommon_0.TabIndex = 0;
			this._txtCommon_0.Text = "";
			// this.this._txtCommon_0.Watermark = "";
			// this.this._txtCommon_0.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommon_DropButtonClick);
			// this._txtCommon_0.Leave += new System.EventHandler(this.txtCommon_Leave);
			// 
			// lblLCostName
			// 
			this.lblLCostName.AllowDrop = true;
			this.lblLCostName.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblLCostName.Text = "Adjustment Date";
			this.lblLCostName.ForeColor = System.Drawing.Color.Black;
			this.lblLCostName.Location = new System.Drawing.Point(8, 57);
			// // this.lblLCostName.mLabelId = 1015;
			this.lblLCostName.Name = "lblLCostName";
			this.lblLCostName.Size = new System.Drawing.Size(79, 14);
			this.lblLCostName.TabIndex = 8;
			// 
			// lblAssetsCode
			// 
			this.lblAssetsCode.AllowDrop = true;
			this.lblAssetsCode.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblAssetsCode.Text = "Asset Code";
			this.lblAssetsCode.ForeColor = System.Drawing.Color.Black;
			this.lblAssetsCode.Location = new System.Drawing.Point(8, 36);
			// // this.lblAssetsCode.mLabelId = 981;
			this.lblAssetsCode.Name = "lblAssetsCode";
			this.lblAssetsCode.Size = new System.Drawing.Size(57, 14);
			this.lblAssetsCode.TabIndex = 9;
			// 
			// lblComments
			// 
			this.lblComments.AllowDrop = true;
			this.lblComments.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblComments.Text = "Comments";
			this.lblComments.ForeColor = System.Drawing.Color.Black;
			this.lblComments.Location = new System.Drawing.Point(8, 138);
			// // this.lblComments.mLabelId = 135;
			this.lblComments.Name = "lblComments";
			this.lblComments.Size = new System.Drawing.Size(50, 14);
			this.lblComments.TabIndex = 10;
			// 
			// lblAssetsAdjustmentNo
			// 
			this.lblAssetsAdjustmentNo.AllowDrop = true;
			this.lblAssetsAdjustmentNo.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblAssetsAdjustmentNo.Text = "Adjustment No";
			this.lblAssetsAdjustmentNo.ForeColor = System.Drawing.Color.Black;
			this.lblAssetsAdjustmentNo.Location = new System.Drawing.Point(8, 14);
			// // this.lblAssetsAdjustmentNo.mLabelId = 1012;
			this.lblAssetsAdjustmentNo.Name = "lblAssetsAdjustmentNo";
			this.lblAssetsAdjustmentNo.Size = new System.Drawing.Size(70, 14);
			this.lblAssetsAdjustmentNo.TabIndex = 11;
			// 
			// lblAssetsAdjustmentAccount
			// 
			this.lblAssetsAdjustmentAccount.AllowDrop = true;
			this.lblAssetsAdjustmentAccount.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblAssetsAdjustmentAccount.Text = "Adjustment Account";
			this.lblAssetsAdjustmentAccount.ForeColor = System.Drawing.Color.Black;
			this.lblAssetsAdjustmentAccount.Location = new System.Drawing.Point(8, 99);
			// // this.lblAssetsAdjustmentAccount.mLabelId = 1013;
			this.lblAssetsAdjustmentAccount.Name = "lblAssetsAdjustmentAccount";
			this.lblAssetsAdjustmentAccount.Size = new System.Drawing.Size(98, 14);
			this.lblAssetsAdjustmentAccount.TabIndex = 12;
			// 
			// _txtCommon_2
			// 
			this._txtCommon_2.AllowDrop = true;
			this._txtCommon_2.BackColor = System.Drawing.Color.White;
			this._txtCommon_2.ForeColor = System.Drawing.Color.Black;
			this._txtCommon_2.Location = new System.Drawing.Point(136, 96);
			this._txtCommon_2.MaxLength = 15;
			this._txtCommon_2.Name = "_txtCommon_2";
			// this._txtCommon_2.ShowButton = true;
			this._txtCommon_2.Size = new System.Drawing.Size(101, 19);
			this._txtCommon_2.TabIndex = 2;
			this._txtCommon_2.Text = "";
			// this.this._txtCommon_2.Watermark = "";
			// this.this._txtCommon_2.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommon_DropButtonClick);
			// this._txtCommon_2.Leave += new System.EventHandler(this.txtCommon_Leave);
			// 
			// lblAssetsAdjustmentCostCenter
			// 
			this.lblAssetsAdjustmentCostCenter.AllowDrop = true;
			this.lblAssetsAdjustmentCostCenter.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblAssetsAdjustmentCostCenter.Text = "Adjustment Cost Center";
			this.lblAssetsAdjustmentCostCenter.ForeColor = System.Drawing.Color.Black;
			this.lblAssetsAdjustmentCostCenter.Location = new System.Drawing.Point(8, 120);
			// // this.lblAssetsAdjustmentCostCenter.mLabelId = 1014;
			this.lblAssetsAdjustmentCostCenter.Name = "lblAssetsAdjustmentCostCenter";
			this.lblAssetsAdjustmentCostCenter.Size = new System.Drawing.Size(114, 14);
			this.lblAssetsAdjustmentCostCenter.TabIndex = 13;
			// 
			// _txtCommon_3
			// 
			this._txtCommon_3.AllowDrop = true;
			this._txtCommon_3.BackColor = System.Drawing.Color.FromArgb(239, 239, 239);
			// this._txtCommon_3.bolNumericOnly = true;
			this._txtCommon_3.Enabled = false;
			this._txtCommon_3.ForeColor = System.Drawing.Color.Black;
			this._txtCommon_3.Location = new System.Drawing.Point(136, 117);
			this._txtCommon_3.MaxLength = 15;
			this._txtCommon_3.Name = "_txtCommon_3";
			// this._txtCommon_3.ShowButton = true;
			this._txtCommon_3.Size = new System.Drawing.Size(101, 19);
			this._txtCommon_3.TabIndex = 3;
			this._txtCommon_3.Text = "";
			// this.this._txtCommon_3.Watermark = "";
			// this.this._txtCommon_3.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommon_DropButtonClick);
			// this._txtCommon_3.Leave += new System.EventHandler(this.txtCommon_Leave);
			// 
			// lblAdjustmentAmount
			// 
			this.lblAdjustmentAmount.AllowDrop = true;
			this.lblAdjustmentAmount.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblAdjustmentAmount.Text = "Adjustment Amount";
			this.lblAdjustmentAmount.ForeColor = System.Drawing.Color.Black;
			this.lblAdjustmentAmount.Location = new System.Drawing.Point(8, 78);
			// // this.lblAdjustmentAmount.mLabelId = 1016;
			this.lblAdjustmentAmount.Name = "lblAdjustmentAmount";
			this.lblAdjustmentAmount.Size = new System.Drawing.Size(94, 14);
			this.lblAdjustmentAmount.TabIndex = 14;
			// 
			// _txtCommon_1
			// 
			this._txtCommon_1.AllowDrop = true;
			this._txtCommon_1.BackColor = System.Drawing.Color.White;
			this._txtCommon_1.ForeColor = System.Drawing.Color.Black;
			this._txtCommon_1.Location = new System.Drawing.Point(136, 33);
			this._txtCommon_1.MaxLength = 15;
			this._txtCommon_1.Name = "_txtCommon_1";
			// this._txtCommon_1.ShowButton = true;
			this._txtCommon_1.Size = new System.Drawing.Size(101, 19);
			this._txtCommon_1.TabIndex = 1;
			this._txtCommon_1.Text = "";
			// this.this._txtCommon_1.Watermark = "";
			// this.this._txtCommon_1.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommon_DropButtonClick);
			// this._txtCommon_1.Leave += new System.EventHandler(this.txtCommon_Leave);
			// 
			// _txtCommonDisplay_1
			// 
			this._txtCommonDisplay_1.AllowDrop = true;
			this._txtCommonDisplay_1.Location = new System.Drawing.Point(239, 96);
			this._txtCommonDisplay_1.Name = "_txtCommonDisplay_1";
			this._txtCommonDisplay_1.Size = new System.Drawing.Size(201, 19);
			this._txtCommonDisplay_1.TabIndex = 15;
			// 
			// _txtCommonDisplay_0
			// 
			this._txtCommonDisplay_0.AllowDrop = true;
			this._txtCommonDisplay_0.Location = new System.Drawing.Point(239, 33);
			this._txtCommonDisplay_0.Name = "_txtCommonDisplay_0";
			this._txtCommonDisplay_0.Size = new System.Drawing.Size(201, 19);
			this._txtCommonDisplay_0.TabIndex = 16;
			// 
			// _txtCommonDisplay_2
			// 
			this._txtCommonDisplay_2.AllowDrop = true;
			this._txtCommonDisplay_2.Location = new System.Drawing.Point(239, 117);
			this._txtCommonDisplay_2.Name = "_txtCommonDisplay_2";
			this._txtCommonDisplay_2.Size = new System.Drawing.Size(201, 19);
			this._txtCommonDisplay_2.TabIndex = 17;
			// 
			// frmFAAssetsAdjusment
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.ClientSize = new System.Drawing.Size(507, 241);
			this.Controls.Add(this.cntMainParameter);
			//this.Icon = (System.Drawing.Icon) resources.GetObject("frmFAAssetsAdjusment.Icon");
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(167, 277);
			this.MaximizeBox = true;
			this.MinimizeBox = true;
			this.Name = "frmFAAssetsAdjusment";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Asset Adjustment";
			// this.Activated += new System.EventHandler(this.frmFAAssetsAdjusment_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
			// this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
			//((System.ComponentModel.ISupportInitialize) this.cntMainParameter).EndInit();
			this.cntMainParameter.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		// 
		void InitializetxtCommonDisplay()
		{
			this.txtCommonDisplay = new System.Windows.Forms.Label[3];
			this.txtCommonDisplay[1] = _txtCommonDisplay_1;
			this.txtCommonDisplay[0] = _txtCommonDisplay_0;
			this.txtCommonDisplay[2] = _txtCommonDisplay_2;
		}
		void InitializetxtCommon()
		{
			this.txtCommon = new System.Windows.Forms.TextBox[4];
			this.txtCommon[0] = _txtCommon_0;
			this.txtCommon[2] = _txtCommon_2;
			this.txtCommon[3] = _txtCommon_3;
			this.txtCommon[1] = _txtCommon_1;
		}
		#endregion
	}
}//ENDSHERE
