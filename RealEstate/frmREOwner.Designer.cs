
namespace Xtreme
{
	partial class frmREOwner
	{

		#region "Upgrade Support "
		private static frmREOwner m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmREOwner DefInstance
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
		public static frmREOwner CreateInstance()
		{
			frmREOwner theInstance = new frmREOwner();
			
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
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "lblAssetsCode", "lblComments", "lblAssetsAdjustmentNo", "System.Windows.Forms.Label1", "System.Windows.Forms.Label2", "_txtCommon_3", "System.Windows.Forms.Label3", "_txtCommon_4", "_txtCommon_0", "_txtCommon_1", "_txtCommon_2", "System.Windows.Forms.Label5", "_txtCommon_5", "_txtCommon_6", "System.Windows.Forms.Label4", "_txtCommon_7", "txtCommon"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public System.Windows.Forms.Label lblAssetsCode;
		public System.Windows.Forms.Label lblComments;
		public System.Windows.Forms.Label lblAssetsAdjustmentNo;
		public System.Windows.Forms.Label System.Windows.Forms.Label1;
		public System.Windows.Forms.Label System.Windows.Forms.Label2;
		private System.Windows.Forms.TextBox _txtCommon_3;
		public System.Windows.Forms.Label System.Windows.Forms.Label3;
		private System.Windows.Forms.TextBox _txtCommon_4;
		private System.Windows.Forms.TextBox _txtCommon_0;
		private System.Windows.Forms.TextBox _txtCommon_1;
		private System.Windows.Forms.TextBox _txtCommon_2;
		public System.Windows.Forms.Label System.Windows.Forms.Label5;
		private System.Windows.Forms.TextBox _txtCommon_5;
		private System.Windows.Forms.TextBox _txtCommon_6;
		public System.Windows.Forms.Label System.Windows.Forms.Label4;
		private System.Windows.Forms.TextBox _txtCommon_7;
		public System.Windows.Forms.TextBox[] txtCommon = new System.Windows.Forms.TextBox[8];
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmREOwner));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this.lblAssetsCode = new System.Windows.Forms.Label();
			this.lblComments = new System.Windows.Forms.Label();
			this.lblAssetsAdjustmentNo = new System.Windows.Forms.Label();
			this.System.Windows.Forms.Label1 = new System.Windows.Forms.Label();
			this.System.Windows.Forms.Label2 = new System.Windows.Forms.Label();
			this._txtCommon_3 = new System.Windows.Forms.TextBox();
			this.System.Windows.Forms.Label3 = new System.Windows.Forms.Label();
			this._txtCommon_4 = new System.Windows.Forms.TextBox();
			this._txtCommon_0 = new System.Windows.Forms.TextBox();
			this._txtCommon_1 = new System.Windows.Forms.TextBox();
			this._txtCommon_2 = new System.Windows.Forms.TextBox();
			this.System.Windows.Forms.Label5 = new System.Windows.Forms.Label();
			this._txtCommon_5 = new System.Windows.Forms.TextBox();
			this._txtCommon_6 = new System.Windows.Forms.TextBox();
			this.System.Windows.Forms.Label4 = new System.Windows.Forms.Label();
			this._txtCommon_7 = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// lblAssetsCode
			// 
			this.lblAssetsCode.AllowDrop = true;
			this.lblAssetsCode.BackColor = System.Drawing.Color.FromArgb(224, 230, 237);
			this.lblAssetsCode.Text = "Owner Name (English)";
			this.lblAssetsCode.ForeColor = System.Drawing.Color.Black;
			this.lblAssetsCode.Location = new System.Drawing.Point(8, 78);
			// this.lblAssetsCode.mLabelId = 1186;
			this.lblAssetsCode.Name = "lblAssetsCode";
			this.lblAssetsCode.Size = new System.Drawing.Size(109, 14);
			this.lblAssetsCode.TabIndex = 0;
			// 
			// lblComments
			// 
			this.lblComments.AllowDrop = true;
			this.lblComments.BackColor = System.Drawing.Color.FromArgb(224, 230, 237);
			this.lblComments.Text = "Comments";
			this.lblComments.ForeColor = System.Drawing.Color.Black;
			this.lblComments.Location = new System.Drawing.Point(8, 180);
			// this.lblComments.mLabelId = 135;
			this.lblComments.Name = "lblComments";
			this.lblComments.Size = new System.Drawing.Size(49, 13);
			this.lblComments.TabIndex = 1;
			// 
			// lblAssetsAdjustmentNo
			// 
			this.lblAssetsAdjustmentNo.AllowDrop = true;
			this.lblAssetsAdjustmentNo.BackColor = System.Drawing.Color.FromArgb(224, 230, 237);
			this.lblAssetsAdjustmentNo.Text = "Owner Code";
			this.lblAssetsAdjustmentNo.ForeColor = System.Drawing.Color.Black;
			this.lblAssetsAdjustmentNo.Location = new System.Drawing.Point(8, 57);
			// this.lblAssetsAdjustmentNo.mLabelId = 1185;
			this.lblAssetsAdjustmentNo.Name = "lblAssetsAdjustmentNo";
			this.lblAssetsAdjustmentNo.Size = new System.Drawing.Size(62, 14);
			this.lblAssetsAdjustmentNo.TabIndex = 2;
			// 
			// System.Windows.Forms.Label1
			// 
			this.System.Windows.Forms.Label1.AllowDrop = true;
			this.System.Windows.Forms.Label1.BackColor = System.Drawing.Color.FromArgb(224, 230, 237);
			this.System.Windows.Forms.Label1.Caption = "Telephone No";
			this.System.Windows.Forms.Label1.ForeColor = System.Drawing.Color.Black;
			this.System.Windows.Forms.Label1.Location = new System.Drawing.Point(8, 120);
			this.System.Windows.Forms.Label1.mLabelId = 1067;
			this.System.Windows.Forms.Label1.Name = "System.Windows.Forms.Label1";
			this.System.Windows.Forms.Label1.Size = new System.Drawing.Size(66, 14);
			this.System.Windows.Forms.Label1.TabIndex = 3;
			// 
			// System.Windows.Forms.Label2
			// 
			this.System.Windows.Forms.Label2.AllowDrop = true;
			this.System.Windows.Forms.Label2.BackColor = System.Drawing.Color.FromArgb(224, 230, 237);
			this.System.Windows.Forms.Label2.Caption = "Mobile No";
			this.System.Windows.Forms.Label2.ForeColor = System.Drawing.Color.Black;
			this.System.Windows.Forms.Label2.Location = new System.Drawing.Point(252, 120);
			this.System.Windows.Forms.Label2.mLabelId = 1073;
			this.System.Windows.Forms.Label2.Name = "System.Windows.Forms.Label2";
			this.System.Windows.Forms.Label2.Size = new System.Drawing.Size(46, 14);
			this.System.Windows.Forms.Label2.TabIndex = 4;
			// 
			// _txtCommon_3
			// 
			this._txtCommon_3.AllowDrop = true;
			this._txtCommon_3.BackColor = System.Drawing.Color.White;
			this._txtCommon_3.ForeColor = System.Drawing.Color.Black;
			this._txtCommon_3.Location = new System.Drawing.Point(330, 117);
			this._txtCommon_3.MaxLength = 15;
			this._txtCommon_3.Name = "_txtCommon_3";
			this._txtCommon_3.Size = new System.Drawing.Size(101, 19);
			this._txtCommon_3.TabIndex = 5;
			this._txtCommon_3.Text = "";
			// this.this._txtCommon_3.Watermark = "";
			// this.this._txtCommon_3.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommon_DropButtonClick);
			// 
			// System.Windows.Forms.Label3
			// 
			this.System.Windows.Forms.Label3.AllowDrop = true;
			this.System.Windows.Forms.Label3.BackColor = System.Drawing.Color.FromArgb(224, 230, 237);
			this.System.Windows.Forms.Label3.Caption = "Fax No";
			this.System.Windows.Forms.Label3.ForeColor = System.Drawing.Color.Black;
			this.System.Windows.Forms.Label3.Location = new System.Drawing.Point(8, 141);
			this.System.Windows.Forms.Label3.mLabelId = 1076;
			this.System.Windows.Forms.Label3.Name = "System.Windows.Forms.Label3";
			this.System.Windows.Forms.Label3.Size = new System.Drawing.Size(34, 14);
			this.System.Windows.Forms.Label3.TabIndex = 6;
			// 
			// _txtCommon_4
			// 
			this._txtCommon_4.AllowDrop = true;
			this._txtCommon_4.BackColor = System.Drawing.Color.White;
			this._txtCommon_4.ForeColor = System.Drawing.Color.Black;
			this._txtCommon_4.Location = new System.Drawing.Point(130, 138);
			this._txtCommon_4.MaxLength = 15;
			this._txtCommon_4.Name = "_txtCommon_4";
			this._txtCommon_4.Size = new System.Drawing.Size(101, 19);
			this._txtCommon_4.TabIndex = 7;
			this._txtCommon_4.Text = "";
			// this.this._txtCommon_4.Watermark = "";
			// this.this._txtCommon_4.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommon_DropButtonClick);
			// 
			// _txtCommon_0
			// 
			this._txtCommon_0.AllowDrop = true;
			this._txtCommon_0.BackColor = System.Drawing.Color.White;
			this._txtCommon_0.ForeColor = System.Drawing.Color.Black;
			this._txtCommon_0.Location = new System.Drawing.Point(130, 54);
			this._txtCommon_0.MaxLength = 15;
			// this._txtCommon_0.mDropDownType = System.Windows.Forms.TextBox.DropDownTypes.ddtNextNumber;
			this._txtCommon_0.Name = "_txtCommon_0";
			// this._txtCommon_0.ShowButton = true;
			this._txtCommon_0.Size = new System.Drawing.Size(101, 19);
			this._txtCommon_0.TabIndex = 8;
			this._txtCommon_0.Text = "";
			// this.this._txtCommon_0.Watermark = "";
			// this.this._txtCommon_0.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommon_DropButtonClick);
			// 
			// _txtCommon_1
			// 
			this._txtCommon_1.AllowDrop = true;
			this._txtCommon_1.BackColor = System.Drawing.Color.White;
			this._txtCommon_1.ForeColor = System.Drawing.Color.Black;
			this._txtCommon_1.Location = new System.Drawing.Point(130, 75);
			this._txtCommon_1.MaxLength = 250;
			this._txtCommon_1.Name = "_txtCommon_1";
			this._txtCommon_1.Size = new System.Drawing.Size(201, 19);
			this._txtCommon_1.TabIndex = 9;
			this._txtCommon_1.Text = "";
			// this.this._txtCommon_1.Watermark = "";
			// this.this._txtCommon_1.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommon_DropButtonClick);
			// 
			// _txtCommon_2
			// 
			this._txtCommon_2.AllowDrop = true;
			this._txtCommon_2.BackColor = System.Drawing.Color.White;
			// this._txtCommon_2.bolNumericOnly = true;
			this._txtCommon_2.ForeColor = System.Drawing.Color.Black;
			this._txtCommon_2.Location = new System.Drawing.Point(130, 117);
			this._txtCommon_2.MaxLength = 15;
			this._txtCommon_2.Name = "_txtCommon_2";
			this._txtCommon_2.Size = new System.Drawing.Size(101, 19);
			this._txtCommon_2.TabIndex = 10;
			this._txtCommon_2.Text = "";
			// this.this._txtCommon_2.Watermark = "";
			// this.this._txtCommon_2.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommon_DropButtonClick);
			// 
			// System.Windows.Forms.Label5
			// 
			this.System.Windows.Forms.Label5.AllowDrop = true;
			this.System.Windows.Forms.Label5.BackColor = System.Drawing.Color.FromArgb(224, 230, 237);
			this.System.Windows.Forms.Label5.Caption = "Address";
			this.System.Windows.Forms.Label5.ForeColor = System.Drawing.Color.Black;
			this.System.Windows.Forms.Label5.Location = new System.Drawing.Point(8, 162);
			this.System.Windows.Forms.Label5.mLabelId = 1188;
			this.System.Windows.Forms.Label5.Name = "System.Windows.Forms.Label5";
			this.System.Windows.Forms.Label5.Size = new System.Drawing.Size(42, 14);
			this.System.Windows.Forms.Label5.TabIndex = 11;
			// 
			// _txtCommon_5
			// 
			this._txtCommon_5.AllowDrop = true;
			this._txtCommon_5.BackColor = System.Drawing.Color.White;
			this._txtCommon_5.ForeColor = System.Drawing.Color.Black;
			this._txtCommon_5.Location = new System.Drawing.Point(130, 159);
			this._txtCommon_5.MaxLength = 250;
			// this._txtCommon_5.mDropDownType = System.Windows.Forms.TextBox.DropDownTypes.ddtNextNumber;
			this._txtCommon_5.Name = "_txtCommon_5";
			this._txtCommon_5.Size = new System.Drawing.Size(301, 19);
			this._txtCommon_5.TabIndex = 12;
			this._txtCommon_5.Text = "";
			// this.this._txtCommon_5.Watermark = "";
			// this.this._txtCommon_5.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommon_DropButtonClick);
			// 
			// _txtCommon_6
			// 
			this._txtCommon_6.AllowDrop = true;
			this._txtCommon_6.BackColor = System.Drawing.Color.White;
			this._txtCommon_6.ForeColor = System.Drawing.Color.Black;
			this._txtCommon_6.Location = new System.Drawing.Point(130, 180);
			this._txtCommon_6.MaxLength = 250;
			// this._txtCommon_6.mDropDownType = System.Windows.Forms.TextBox.DropDownTypes.ddtNextNumber;
			this._txtCommon_6.Name = "_txtCommon_6";
			this._txtCommon_6.Size = new System.Drawing.Size(301, 31);
			this._txtCommon_6.TabIndex = 13;
			this._txtCommon_6.Text = "";
			// this.this._txtCommon_6.Watermark = "";
			// this.this._txtCommon_6.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommon_DropButtonClick);
			// 
			// System.Windows.Forms.Label4
			// 
			this.System.Windows.Forms.Label4.AllowDrop = true;
			this.System.Windows.Forms.Label4.BackColor = System.Drawing.Color.FromArgb(224, 230, 237);
			this.System.Windows.Forms.Label4.Caption = "Owner Name (Arabic)";
			this.System.Windows.Forms.Label4.ForeColor = System.Drawing.Color.Black;
			this.System.Windows.Forms.Label4.Location = new System.Drawing.Point(8, 99);
			this.System.Windows.Forms.Label4.mLabelId = 1187;
			this.System.Windows.Forms.Label4.Name = "System.Windows.Forms.Label4";
			this.System.Windows.Forms.Label4.Size = new System.Drawing.Size(107, 14);
			this.System.Windows.Forms.Label4.TabIndex = 14;
			// 
			// _txtCommon_7
			// 
			this._txtCommon_7.AllowDrop = true;
			this._txtCommon_7.BackColor = System.Drawing.Color.White;
			this._txtCommon_7.ForeColor = System.Drawing.Color.Black;
			this._txtCommon_7.Location = new System.Drawing.Point(130, 96);
			// this._txtCommon_7.mArabicEnabled = true;
			this._txtCommon_7.MaxLength = 250;
			this._txtCommon_7.Name = "_txtCommon_7";
			this._txtCommon_7.Size = new System.Drawing.Size(201, 19);
			this._txtCommon_7.TabIndex = 15;
			this._txtCommon_7.Text = "";
			// this.this._txtCommon_7.Watermark = "";
			// this.this._txtCommon_7.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommon_DropButtonClick);
			// 
			// frmREOwner
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.FromArgb(224, 230, 237);
			this.ClientSize = new System.Drawing.Size(455, 224);
			this.Controls.Add(this.lblAssetsCode);
			this.Controls.Add(this.lblComments);
			this.Controls.Add(this.lblAssetsAdjustmentNo);
			this.Controls.Add(this.System.Windows.Forms.Label1);
			this.Controls.Add(this.System.Windows.Forms.Label2);
			this.Controls.Add(this._txtCommon_3);
			this.Controls.Add(this.System.Windows.Forms.Label3);
			this.Controls.Add(this._txtCommon_4);
			this.Controls.Add(this._txtCommon_0);
			this.Controls.Add(this._txtCommon_1);
			this.Controls.Add(this._txtCommon_2);
			this.Controls.Add(this.System.Windows.Forms.Label5);
			this.Controls.Add(this._txtCommon_5);
			this.Controls.Add(this._txtCommon_6);
			this.Controls.Add(this.System.Windows.Forms.Label4);
			this.Controls.Add(this._txtCommon_7);
			//this.Icon = (System.Drawing.Icon) resources.GetObject("frmREOwner.Icon");
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(31, 160);
			this.MaximizeBox = true;
			this.MinimizeBox = true;
			this.Name = "frmREOwner";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Owner";
			// this.Activated += new System.EventHandler(this.frmREOwner_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
			// this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
			this.ResumeLayout(false);
		}
		void ReLoadForm(bool addEvents)
		{
			InitializetxtCommon();
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
			this.txtCommon = new System.Windows.Forms.TextBox[8];
			this.txtCommon[3] = _txtCommon_3;
			this.txtCommon[4] = _txtCommon_4;
			this.txtCommon[0] = _txtCommon_0;
			this.txtCommon[1] = _txtCommon_1;
			this.txtCommon[2] = _txtCommon_2;
			this.txtCommon[5] = _txtCommon_5;
			this.txtCommon[6] = _txtCommon_6;
			this.txtCommon[7] = _txtCommon_7;
		}
		#endregion
	}
}