
namespace Xtreme
{
	partial class frmREGuards
	{

		#region "Upgrade Support "
		private static frmREGuards m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmREGuards DefInstance
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
		public static frmREGuards CreateInstance()
		{
			frmREGuards theInstance = new frmREGuards();
			
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
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "_txtRemarks_7", "_txtCommon_0", "lblAssetsCode", "lblComments", "lblAssetsAdjustmentNo", "_txtCommon_1", "System.Windows.Forms.Label1", "_txtCommon_4", "System.Windows.Forms.Label2", "_txtCommon_5", "System.Windows.Forms.Label3", "_txtCommon_3", "System.Windows.Forms.Label4", "System.Windows.Forms.Label6", "_txtCommon_2", "_txtCommon_6", "_txtCommonDisplay_0", "txtCommon", "txtCommonDisplay", "txtRemarks"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		private System.Windows.Forms.TextBox _txtRemarks_7;
		private System.Windows.Forms.TextBox _txtCommon_0;
		public System.Windows.Forms.Label lblAssetsCode;
		public System.Windows.Forms.Label lblComments;
		public System.Windows.Forms.Label lblAssetsAdjustmentNo;
		private System.Windows.Forms.TextBox _txtCommon_1;
		public System.Windows.Forms.Label Label1;
		private System.Windows.Forms.TextBox _txtCommon_4;
		public System.Windows.Forms.Label Label2;
		private System.Windows.Forms.TextBox _txtCommon_5;
		public System.Windows.Forms.Label Label3;
		private System.Windows.Forms.TextBox _txtCommon_3;
		public System.Windows.Forms.Label Label4;
		public System.Windows.Forms.Label Label6;
		private System.Windows.Forms.TextBox _txtCommon_2;
		private System.Windows.Forms.TextBox _txtCommon_6;
		private System.Windows.Forms.Label _txtCommonDisplay_0;
		public System.Windows.Forms.TextBox[] txtCommon = new System.Windows.Forms.TextBox[7];
		public System.Windows.Forms.Label[] txtCommonDisplay = new System.Windows.Forms.Label[1];
		public System.Windows.Forms.TextBox[] txtRemarks = new System.Windows.Forms.TextBox[8];
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmREGuards));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this._txtRemarks_7 = new System.Windows.Forms.TextBox();
			this._txtCommon_0 = new System.Windows.Forms.TextBox();
			this.lblAssetsCode = new System.Windows.Forms.Label();
			this.lblComments = new System.Windows.Forms.Label();
			this.lblAssetsAdjustmentNo = new System.Windows.Forms.Label();
			this._txtCommon_1 = new System.Windows.Forms.TextBox();
			this.Label1 = new System.Windows.Forms.Label();
			this._txtCommon_4 = new System.Windows.Forms.TextBox();
			this.Label2 = new System.Windows.Forms.Label();
			this._txtCommon_5 = new System.Windows.Forms.TextBox();
			this.Label3 = new System.Windows.Forms.Label();
			this._txtCommon_3 = new System.Windows.Forms.TextBox();
			this.Label4 = new System.Windows.Forms.Label();
			this.Label6 = new System.Windows.Forms.Label();
			this._txtCommon_2 = new System.Windows.Forms.TextBox();
			this._txtCommon_6 = new System.Windows.Forms.TextBox();
			this._txtCommonDisplay_0 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// _txtRemarks_7
			// 
			this._txtRemarks_7.AcceptsReturn = true;
			this._txtRemarks_7.AllowDrop = true;
			this._txtRemarks_7.BackColor = System.Drawing.SystemColors.Window;
			this._txtRemarks_7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._txtRemarks_7.Cursor = System.Windows.Forms.Cursors.IBeam;
			this._txtRemarks_7.ForeColor = System.Drawing.SystemColors.WindowText;
			this._txtRemarks_7.Location = new System.Drawing.Point(142, 184);
			this._txtRemarks_7.MaxLength = 250;
			this._txtRemarks_7.Multiline = true;
			this._txtRemarks_7.Name = "_txtRemarks_7";
			this._txtRemarks_7.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtRemarks_7.Size = new System.Drawing.Size(304, 35);
			this._txtRemarks_7.TabIndex = 7;
			// 
			// _txtCommon_0
			// 
			this._txtCommon_0.AllowDrop = true;
			this._txtCommon_0.BackColor = System.Drawing.Color.White;
			// this._txtCommon_0.bolNumericOnly = true;
			this._txtCommon_0.ForeColor = System.Drawing.Color.Black;
			this._txtCommon_0.Location = new System.Drawing.Point(142, 58);
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
			// lblAssetsCode
			// 
			this.lblAssetsCode.AllowDrop = true;
			this.lblAssetsCode.BackColor = System.Drawing.Color.FromArgb(224, 230, 237);
			this.lblAssetsCode.Text = "Guard  Name  (English)";
			this.lblAssetsCode.ForeColor = System.Drawing.Color.Black;
			this.lblAssetsCode.Location = new System.Drawing.Point(8, 82);
			// // this.lblAssetsCode.mLabelId = 1180;
			this.lblAssetsCode.Name = "lblAssetsCode";
			this.lblAssetsCode.Size = new System.Drawing.Size(111, 14);
			this.lblAssetsCode.TabIndex = 8;
			// 
			// lblComments
			// 
			this.lblComments.AllowDrop = true;
			this.lblComments.BackColor = System.Drawing.Color.FromArgb(224, 230, 237);
			this.lblComments.Text = "comments";
			this.lblComments.ForeColor = System.Drawing.Color.Black;
			this.lblComments.Location = new System.Drawing.Point(8, 184);
			// // this.lblComments.mLabelId = 135;
			this.lblComments.Name = "lblComments";
			this.lblComments.Size = new System.Drawing.Size(48, 13);
			this.lblComments.TabIndex = 9;
			// 
			// lblAssetsAdjustmentNo
			// 
			this.lblAssetsAdjustmentNo.AllowDrop = true;
			this.lblAssetsAdjustmentNo.BackColor = System.Drawing.Color.FromArgb(224, 230, 237);
			this.lblAssetsAdjustmentNo.Text = "Guard Code";
			this.lblAssetsAdjustmentNo.ForeColor = System.Drawing.Color.Black;
			this.lblAssetsAdjustmentNo.Location = new System.Drawing.Point(8, 60);
			// // this.lblAssetsAdjustmentNo.mLabelId = 1179;
			this.lblAssetsAdjustmentNo.Name = "lblAssetsAdjustmentNo";
			this.lblAssetsAdjustmentNo.Size = new System.Drawing.Size(58, 14);
			this.lblAssetsAdjustmentNo.TabIndex = 10;
			// 
			// _txtCommon_1
			// 
			this._txtCommon_1.AllowDrop = true;
			this._txtCommon_1.BackColor = System.Drawing.Color.White;
			this._txtCommon_1.ForeColor = System.Drawing.Color.Black;
			this._txtCommon_1.Location = new System.Drawing.Point(142, 79);
			this._txtCommon_1.MaxLength = 250;
			this._txtCommon_1.Name = "_txtCommon_1";
			this._txtCommon_1.Size = new System.Drawing.Size(201, 19);
			this._txtCommon_1.TabIndex = 1;
			this._txtCommon_1.Text = "";
			// this.this._txtCommon_1.Watermark = "";
			// this.this._txtCommon_1.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommon_DropButtonClick);
			// this._txtCommon_1.Leave += new System.EventHandler(this.txtCommon_Leave);
			// 
			// System.Windows.Forms.Label1
			// 
			this.Label1.AllowDrop = true;
			this.Label1.BackColor = System.Drawing.Color.FromArgb(224, 230, 237);
			this.Label1.Text = "Passport No";
			this.Label1.ForeColor = System.Drawing.Color.Black;
			this.Label1.Location = new System.Drawing.Point(8, 145);
			// this.Label1.mLabelId = 1182;
			this.Label1.Name = "System.Windows.Forms.Label1";
			this.Label1.Size = new System.Drawing.Size(59, 14);
			this.Label1.TabIndex = 11;
			// 
			// _txtCommon_4
			// 
			this._txtCommon_4.AllowDrop = true;
			this._txtCommon_4.BackColor = System.Drawing.Color.White;
			this._txtCommon_4.ForeColor = System.Drawing.Color.Black;
			this._txtCommon_4.Location = new System.Drawing.Point(142, 142);
			this._txtCommon_4.MaxLength = 15;
			this._txtCommon_4.Name = "_txtCommon_4";
			this._txtCommon_4.Size = new System.Drawing.Size(101, 19);
			this._txtCommon_4.TabIndex = 4;
			this._txtCommon_4.Text = "";
			// this.this._txtCommon_4.Watermark = "";
			// this.this._txtCommon_4.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommon_DropButtonClick);
			// this._txtCommon_4.Leave += new System.EventHandler(this.txtCommon_Leave);
			// 
			// System.Windows.Forms.Label2
			// 
			this.Label2.AllowDrop = true;
			this.Label2.BackColor = System.Drawing.Color.FromArgb(224, 230, 237);
			this.Label2.Text = "Civil Id";
			this.Label2.ForeColor = System.Drawing.Color.Black;
			this.Label2.Location = new System.Drawing.Point(264, 145);
			// this.Label2.mLabelId = 124;
			this.Label2.Name = "System.Windows.Forms.Label2";
			this.Label2.Size = new System.Drawing.Size(30, 14);
			this.Label2.TabIndex = 12;
			// 
			// _txtCommon_5
			// 
			this._txtCommon_5.AllowDrop = true;
			this._txtCommon_5.BackColor = System.Drawing.Color.White;
			this._txtCommon_5.ForeColor = System.Drawing.Color.Black;
			this._txtCommon_5.Location = new System.Drawing.Point(345, 142);
			this._txtCommon_5.MaxLength = 15;
			this._txtCommon_5.Name = "_txtCommon_5";
			this._txtCommon_5.Size = new System.Drawing.Size(101, 19);
			this._txtCommon_5.TabIndex = 5;
			this._txtCommon_5.Text = "";
			// this.this._txtCommon_5.Watermark = "";
			// this.this._txtCommon_5.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommon_DropButtonClick);
			// this._txtCommon_5.Leave += new System.EventHandler(this.txtCommon_Leave);
			// 
			// System.Windows.Forms.Label3
			// 
			this.Label3.AllowDrop = true;
			this.Label3.BackColor = System.Drawing.Color.FromArgb(224, 230, 237);
			this.Label3.Text = "Nationality Code";
			this.Label3.ForeColor = System.Drawing.Color.Black;
			this.Label3.Location = new System.Drawing.Point(8, 124);
			// this.Label3.mLabelId = 1058;
			this.Label3.Name = "System.Windows.Forms.Label3";
			this.Label3.Size = new System.Drawing.Size(77, 14);
			this.Label3.TabIndex = 13;
			// 
			// _txtCommon_3
			// 
			this._txtCommon_3.AllowDrop = true;
			this._txtCommon_3.BackColor = System.Drawing.Color.White;
			// this._txtCommon_3.bolNumericOnly = true;
			this._txtCommon_3.ForeColor = System.Drawing.Color.Black;
			this._txtCommon_3.Location = new System.Drawing.Point(142, 121);
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
			// System.Windows.Forms.Label4
			// 
			this.Label4.AllowDrop = true;
			this.Label4.BackColor = System.Drawing.Color.FromArgb(224, 230, 237);
			this.Label4.Text = "Telephone No";
			this.Label4.ForeColor = System.Drawing.Color.Black;
			this.Label4.Location = new System.Drawing.Point(8, 165);
			// this.Label4.mLabelId = 1067;
			this.Label4.Name = "System.Windows.Forms.Label4";
			this.Label4.Size = new System.Drawing.Size(66, 14);
			this.Label4.TabIndex = 14;
			// 
			// System.Windows.Forms.Label6
			// 
			this.Label6.AllowDrop = true;
			this.Label6.BackColor = System.Drawing.Color.FromArgb(224, 230, 237);
			this.Label6.Text = "Guard  Name  (Arabic)";
			this.Label6.ForeColor = System.Drawing.Color.Black;
			this.Label6.Location = new System.Drawing.Point(8, 103);
			// this.Label6.mLabelId = 1181;
			this.Label6.Name = "System.Windows.Forms.Label6";
			this.Label6.Size = new System.Drawing.Size(109, 14);
			this.Label6.TabIndex = 15;
			// 
			// _txtCommon_2
			// 
			this._txtCommon_2.AllowDrop = true;
			this._txtCommon_2.BackColor = System.Drawing.Color.White;
			this._txtCommon_2.ForeColor = System.Drawing.Color.Black;
			this._txtCommon_2.Location = new System.Drawing.Point(142, 100);
			// this._txtCommon_2.mArabicEnabled = true;
			this._txtCommon_2.MaxLength = 250;
			this._txtCommon_2.Name = "_txtCommon_2";
			this._txtCommon_2.Size = new System.Drawing.Size(201, 19);
			this._txtCommon_2.TabIndex = 2;
			this._txtCommon_2.Text = "";
			// this.this._txtCommon_2.Watermark = "";
			// this.this._txtCommon_2.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommon_DropButtonClick);
			// this._txtCommon_2.Leave += new System.EventHandler(this.txtCommon_Leave);
			// 
			// _txtCommon_6
			// 
			this._txtCommon_6.AllowDrop = true;
			this._txtCommon_6.BackColor = System.Drawing.Color.White;
			this._txtCommon_6.ForeColor = System.Drawing.Color.Black;
			this._txtCommon_6.Location = new System.Drawing.Point(142, 163);
			this._txtCommon_6.MaxLength = 15;
			this._txtCommon_6.Name = "_txtCommon_6";
			this._txtCommon_6.Size = new System.Drawing.Size(101, 19);
			this._txtCommon_6.TabIndex = 6;
			this._txtCommon_6.Text = "";
			// this.this._txtCommon_6.Watermark = "";
			// this.this._txtCommon_6.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommon_DropButtonClick);
			// this._txtCommon_6.Leave += new System.EventHandler(this.txtCommon_Leave);
			// 
			// _txtCommonDisplay_0
			// 
			this._txtCommonDisplay_0.AllowDrop = true;
			this._txtCommonDisplay_0.Location = new System.Drawing.Point(245, 121);
			this._txtCommonDisplay_0.Name = "_txtCommonDisplay_0";
			this._txtCommonDisplay_0.Size = new System.Drawing.Size(201, 19);
			this._txtCommonDisplay_0.TabIndex = 16;
			// 
			// frmREGuards
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.ClientSize = new System.Drawing.Size(459, 236);
			this.Controls.Add(this._txtRemarks_7);
			this.Controls.Add(this._txtCommon_0);
			this.Controls.Add(this.lblAssetsCode);
			this.Controls.Add(this.lblComments);
			this.Controls.Add(this.lblAssetsAdjustmentNo);
			this.Controls.Add(this._txtCommon_1);
			this.Controls.Add(this.Label1);
			this.Controls.Add(this._txtCommon_4);
			this.Controls.Add(this.Label2);
			this.Controls.Add(this._txtCommon_5);
			this.Controls.Add(this.Label3);
			this.Controls.Add(this._txtCommon_3);
			this.Controls.Add(this.Label4);
			this.Controls.Add(this.Label6);
			this.Controls.Add(this._txtCommon_2);
			this.Controls.Add(this._txtCommon_6);
			this.Controls.Add(this._txtCommonDisplay_0);
			//this.Icon = (System.Drawing.Icon) resources.GetObject("frmREGuards.Icon");
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(84, 180);
			this.MaximizeBox = true;
			this.MinimizeBox = true;
			this.Name = "frmREGuards";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Guards Details";
			// this.Activated += new System.EventHandler(this.frmREGuards_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
			// this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
			this.ResumeLayout(false);
		}
		// 
		void InitializetxtRemarks()
		{
			this.txtRemarks = new System.Windows.Forms.TextBox[8];
			this.txtRemarks[7] = _txtRemarks_7;
		}
		void InitializetxtCommonDisplay()
		{
			this.txtCommonDisplay = new System.Windows.Forms.Label[1];
			this.txtCommonDisplay[0] = _txtCommonDisplay_0;
		}
		void InitializetxtCommon()
		{
			this.txtCommon = new System.Windows.Forms.TextBox[7];
			this.txtCommon[0] = _txtCommon_0;
			this.txtCommon[1] = _txtCommon_1;
			this.txtCommon[4] = _txtCommon_4;
			this.txtCommon[5] = _txtCommon_5;
			this.txtCommon[3] = _txtCommon_3;
			this.txtCommon[2] = _txtCommon_2;
			this.txtCommon[6] = _txtCommon_6;
		}
		#endregion
	}
}//ENDSHERE
