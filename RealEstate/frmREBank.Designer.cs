
namespace Xtreme
{
	partial class frmREBank
	{

		#region "Upgrade Support "
		private static frmREBank m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmREBank DefInstance
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
		public static frmREBank CreateInstance()
		{
			frmREBank theInstance = new frmREBank();
			
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
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "_txtCommon_0", "_txtCommon_1", "_txtCommon_2", "lblAssetsCode", "lblAssetsAdjustmentNo", "System.Windows.Forms.Label4", "System.Windows.Forms.Label1", "_txtCommon_5", "_txtCommon_3", "_txtCommon_4", "System.Windows.Forms.Label2", "System.Windows.Forms.Label3", "txtCommon"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		private System.Windows.Forms.TextBox _txtCommon_0;
		private System.Windows.Forms.TextBox _txtCommon_1;
		private System.Windows.Forms.TextBox _txtCommon_2;
		public System.Windows.Forms.Label lblAssetsCode;
		public System.Windows.Forms.Label lblAssetsAdjustmentNo;
		public System.Windows.Forms.Label Label4;
		public System.Windows.Forms.Label Label1;
		private System.Windows.Forms.TextBox _txtCommon_5;
		private System.Windows.Forms.TextBox _txtCommon_3;
		private System.Windows.Forms.TextBox _txtCommon_4;
		public System.Windows.Forms.Label Label2;
		public System.Windows.Forms.Label Label3;
		public System.Windows.Forms.TextBox[] txtCommon = new System.Windows.Forms.TextBox[6];
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmREBank));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this._txtCommon_0 = new System.Windows.Forms.TextBox();
			this._txtCommon_1 = new System.Windows.Forms.TextBox();
			this._txtCommon_2 = new System.Windows.Forms.TextBox();
			this.lblAssetsCode = new System.Windows.Forms.Label();
			this.lblAssetsAdjustmentNo = new System.Windows.Forms.Label();
			this.Label4 = new System.Windows.Forms.Label();
			this.Label1 = new System.Windows.Forms.Label();
			this._txtCommon_5 = new System.Windows.Forms.TextBox();
			this._txtCommon_3 = new System.Windows.Forms.TextBox();
			this._txtCommon_4 = new System.Windows.Forms.TextBox();
			this.Label2 = new System.Windows.Forms.Label();
			this.Label3 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// _txtCommon_0
			// 
			//this._txtCommon_0.AllowDrop = true;
			this._txtCommon_0.BackColor = System.Drawing.Color.White;
			this._txtCommon_0.ForeColor = System.Drawing.Color.Black;
			this._txtCommon_0.Location = new System.Drawing.Point(146, 50);
			this._txtCommon_0.MaxLength = 15;
			// // = System.Windows.Forms.TextBox.DropDownTypes.ddtNextNumber;
			this._txtCommon_0.Name = "_txtCommon_0";
			// this._txtCommon_0.ShowButton = true;
			this._txtCommon_0.Size = new System.Drawing.Size(101, 19);
			this._txtCommon_0.TabIndex = 0;
			this._txtCommon_0.Text = "";
			// this.// = "";
			// this.//this._txtCommon_0.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(//this.txtCommon_DropButtonClick);
			// 
			// _txtCommon_1
			// 
			//this._txtCommon_1.AllowDrop = true;
			this._txtCommon_1.BackColor = System.Drawing.Color.White;
			this._txtCommon_1.ForeColor = System.Drawing.Color.Black;
			this._txtCommon_1.Location = new System.Drawing.Point(146, 113);
			this._txtCommon_1.MaxLength = 250;
			this._txtCommon_1.Name = "_txtCommon_1";
			this._txtCommon_1.Size = new System.Drawing.Size(201, 19);
			this._txtCommon_1.TabIndex = 3;
			this._txtCommon_1.Text = "";
			// this.// = "";
			// this.//this._txtCommon_1.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(//this.txtCommon_DropButtonClick);
			// 
			// _txtCommon_2
			// 
			//this._txtCommon_2.AllowDrop = true;
			this._txtCommon_2.BackColor = System.Drawing.Color.White;
			this._txtCommon_2.ForeColor = System.Drawing.Color.Black;
			this._txtCommon_2.Location = new System.Drawing.Point(146, 134);
			// // = true;
			this._txtCommon_2.MaxLength = 250;
			this._txtCommon_2.Name = "_txtCommon_2";
			this._txtCommon_2.Size = new System.Drawing.Size(201, 19);
			this._txtCommon_2.TabIndex = 4;
			this._txtCommon_2.Text = "";
			// this.// = "";
			// this.//this._txtCommon_2.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(//this.txtCommon_DropButtonClick);
			// 
			// lblAssetsCode
			// 
			//this.lblAssetsCode.AllowDrop = true;
			this.lblAssetsCode.BackColor = System.Drawing.Color.FromArgb(224, 230, 237);
			this.lblAssetsCode.Text = "Bank Name (English)";
			this.lblAssetsCode.ForeColor = System.Drawing.Color.Black;
			this.lblAssetsCode.Location = new System.Drawing.Point(8, 116);
			// // this.lblAssetsCode.mLabelId = 1153;
			this.lblAssetsCode.Name = "lblAssetsCode";
			this.lblAssetsCode.Size = new System.Drawing.Size(99, 14);
			this.lblAssetsCode.TabIndex = 6;
			// 
			// lblAssetsAdjustmentNo
			// 
			//this.lblAssetsAdjustmentNo.AllowDrop = true;
			this.lblAssetsAdjustmentNo.BackColor = System.Drawing.Color.FromArgb(224, 230, 237);
			this.lblAssetsAdjustmentNo.Text = "Bank Code";
			this.lblAssetsAdjustmentNo.ForeColor = System.Drawing.Color.Black;
			this.lblAssetsAdjustmentNo.Location = new System.Drawing.Point(8, 53);
			// // this.lblAssetsAdjustmentNo.mLabelId = 1151;
			this.lblAssetsAdjustmentNo.Name = "lblAssetsAdjustmentNo";
			this.lblAssetsAdjustmentNo.Size = new System.Drawing.Size(52, 14);
			this.lblAssetsAdjustmentNo.TabIndex = 7;
			// 
			// System.Windows.Forms.Label4
			// 
			//this.Label4.AllowDrop = true;
			this.Label4.BackColor = System.Drawing.Color.FromArgb(224, 230, 237);
			this.Label4.Text = "Bank Name (Arabic)";
			this.Label4.ForeColor = System.Drawing.Color.Black;
			this.Label4.Location = new System.Drawing.Point(8, 137);
			// this.Label4.mLabelId = 1154;
			this.Label4.Name="Label4";
			this.Label4.Size = new System.Drawing.Size(97, 14);
			this.Label4.TabIndex = 8;
			// 
			// System.Windows.Forms.Label1
			// 
			//this.Label1.AllowDrop = true;
			this.Label1.BackColor = System.Drawing.Color.FromArgb(224, 230, 237);
			this.Label1.Text = "Comments";
			this.Label1.ForeColor = System.Drawing.Color.Black;
			this.Label1.Location = new System.Drawing.Point(8, 155);
			// this.Label1.mLabelId = 135;
			this.Label1.Name="Label1";
			this.Label1.Size = new System.Drawing.Size(49, 13);
			this.Label1.TabIndex = 9;
			// 
			// _txtCommon_5
			// 
			//this._txtCommon_5.AllowDrop = true;
			this._txtCommon_5.BackColor = System.Drawing.Color.White;
			this._txtCommon_5.ForeColor = System.Drawing.Color.Black;
			this._txtCommon_5.Location = new System.Drawing.Point(146, 155);
			this._txtCommon_5.MaxLength = 250;
			this._txtCommon_5.Name = "_txtCommon_5";
			this._txtCommon_5.Size = new System.Drawing.Size(201, 38);
			this._txtCommon_5.TabIndex = 5;
			this._txtCommon_5.Text = "";
			// this.// = "";
			// this.//this._txtCommon_5.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(//this.txtCommon_DropButtonClick);
			// 
			// _txtCommon_3
			// 
			//this._txtCommon_3.AllowDrop = true;
			this._txtCommon_3.BackColor = System.Drawing.Color.White;
			this._txtCommon_3.ForeColor = System.Drawing.Color.Black;
			this._txtCommon_3.Location = new System.Drawing.Point(146, 71);
			this._txtCommon_3.MaxLength = 4;
			this._txtCommon_3.Name = "_txtCommon_3";
			this._txtCommon_3.Size = new System.Drawing.Size(101, 19);
			this._txtCommon_3.TabIndex = 1;
			this._txtCommon_3.Text = "";
			// this.// = "";
			// this.//this._txtCommon_3.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(//this.txtCommon_DropButtonClick);
			// 
			// _txtCommon_4
			// 
			//this._txtCommon_4.AllowDrop = true;
			this._txtCommon_4.BackColor = System.Drawing.Color.White;
			this._txtCommon_4.ForeColor = System.Drawing.Color.Black;
			this._txtCommon_4.Location = new System.Drawing.Point(146, 92);
			// // = true;
			this._txtCommon_4.MaxLength = 4;
			this._txtCommon_4.Name = "_txtCommon_4";
			this._txtCommon_4.Size = new System.Drawing.Size(101, 19);
			this._txtCommon_4.TabIndex = 2;
			this._txtCommon_4.Text = "";
			// this.// = "";
			// this.//this._txtCommon_4.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(//this.txtCommon_DropButtonClick);
			// 
			// System.Windows.Forms.Label2
			// 
			//this.Label2.AllowDrop = true;
			this.Label2.BackColor = System.Drawing.Color.FromArgb(224, 230, 237);
			this.Label2.Text = "Short Name (English)";
			this.Label2.ForeColor = System.Drawing.Color.Black;
			this.Label2.Location = new System.Drawing.Point(8, 74);
			// this.Label2.mLabelId = 1152;
			this.Label2.Name="Label2";
			this.Label2.Size = new System.Drawing.Size(101, 14);
			this.Label2.TabIndex = 10;
			// 
			// System.Windows.Forms.Label3
			// 
			//this.Label3.AllowDrop = true;
			this.Label3.BackColor = System.Drawing.Color.FromArgb(224, 230, 237);
			this.Label3.Text = "Short Name (Arabic)";
			this.Label3.ForeColor = System.Drawing.Color.Black;
			this.Label3.Location = new System.Drawing.Point(8, 95);
			// this.Label3.mLabelId = 958;
			this.Label3.Name="Label3";
			this.Label3.Size = new System.Drawing.Size(99, 14);
			this.Label3.TabIndex = 11;
			// 
			// frmREBank
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.ClientSize = new System.Drawing.Size(383, 203);
			this.Controls.Add(this._txtCommon_0);
			this.Controls.Add(this._txtCommon_1);
			this.Controls.Add(this._txtCommon_2);
			this.Controls.Add(this.lblAssetsCode);
			this.Controls.Add(this.lblAssetsAdjustmentNo);
			this.Controls.Add(this.Label4);
			this.Controls.Add(this.Label1);
			this.Controls.Add(this._txtCommon_5);
			this.Controls.Add(this._txtCommon_3);
			this.Controls.Add(this._txtCommon_4);
			this.Controls.Add(this.Label2);
			this.Controls.Add(this.Label3);
			//this.Icon = (System.Drawing.Icon) resources.GetObject("frmREBank.Icon");
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(104, 169);
			this.MaximizeBox = true;
			this.MinimizeBox = true;
			this.Name = "frmREBank";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Banks";
			// this.Activated += new System.EventHandler(this.frmREBank_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
			// this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
			this.ResumeLayout(false);
		}
		// 
		void InitializetxtCommon()
		{
			this.txtCommon = new System.Windows.Forms.TextBox[6];
			this.txtCommon[0] = _txtCommon_0;
			this.txtCommon[1] = _txtCommon_1;
			this.txtCommon[2] = _txtCommon_2;
			this.txtCommon[5] = _txtCommon_5;
			this.txtCommon[3] = _txtCommon_3;
			this.txtCommon[4] = _txtCommon_4;
		}
		#endregion
	}
}//ENDSHERE
