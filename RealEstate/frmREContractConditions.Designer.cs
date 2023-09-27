
namespace Xtreme
{
	partial class frmREContractConditions
	{

		#region "Upgrade Support "
		private static frmREContractConditions m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmREContractConditions DefInstance
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
		public static frmREContractConditions CreateInstance()
		{
			frmREContractConditions theInstance = new frmREContractConditions();
			
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
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "_txtCommon_0", "_txtCommon_1", "_txtCommon_2", "lblAssetsCode", "lblAssetsAdjustmentNo", "System.Windows.Forms.Label4", "System.Windows.Forms.Label1", "_txtCommon_3", "txtCommon"};
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
		private System.Windows.Forms.TextBox _txtCommon_3;
		public System.Windows.Forms.TextBox[] txtCommon = new System.Windows.Forms.TextBox[4];
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmREContractConditions));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this._txtCommon_0 = new System.Windows.Forms.TextBox();
			this._txtCommon_1 = new System.Windows.Forms.TextBox();
			this._txtCommon_2 = new System.Windows.Forms.TextBox();
			this.lblAssetsCode = new System.Windows.Forms.Label();
			this.lblAssetsAdjustmentNo = new System.Windows.Forms.Label();
			this.Label4 = new System.Windows.Forms.Label();
			this.Label1 = new System.Windows.Forms.Label();
			this._txtCommon_3 = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// _txtCommon_0
			// 
			//this._txtCommon_0.AllowDrop = true;
			this._txtCommon_0.BackColor = System.Drawing.Color.White;
			this._txtCommon_0.ForeColor = System.Drawing.Color.Black;
			this._txtCommon_0.Location = new System.Drawing.Point(154, 58);
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
			this._txtCommon_1.Location = new System.Drawing.Point(154, 78);
			this._txtCommon_1.MaxLength = 250;
			this._txtCommon_1.Name = "_txtCommon_1";
			this._txtCommon_1.Size = new System.Drawing.Size(204, 19);
			this._txtCommon_1.TabIndex = 1;
			this._txtCommon_1.Text = "";
			// this.// = "";
			// this.//this._txtCommon_1.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(//this.txtCommon_DropButtonClick);
			// 
			// _txtCommon_2
			// 
			//this._txtCommon_2.AllowDrop = true;
			this._txtCommon_2.BackColor = System.Drawing.Color.White;
			this._txtCommon_2.ForeColor = System.Drawing.Color.Black;
			this._txtCommon_2.Location = new System.Drawing.Point(154, 98);
			// // = true;
			this._txtCommon_2.MaxLength = 250;
			this._txtCommon_2.Name = "_txtCommon_2";
			this._txtCommon_2.Size = new System.Drawing.Size(204, 19);
			this._txtCommon_2.TabIndex = 2;
			this._txtCommon_2.Text = "";
			// this.// = "";
			// this.//this._txtCommon_2.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(//this.txtCommon_DropButtonClick);
			// 
			// lblAssetsCode
			// 
			//this.lblAssetsCode.AllowDrop = true;
			this.lblAssetsCode.BackColor = System.Drawing.Color.FromArgb(224, 230, 237);
			this.lblAssetsCode.Text = "Condition Name (English)";
			this.lblAssetsCode.ForeColor = System.Drawing.Color.Black;
			this.lblAssetsCode.Location = new System.Drawing.Point(8, 80);
			// // this.lblAssetsCode.mLabelId = 1166;
			this.lblAssetsCode.Name = "lblAssetsCode";
			this.lblAssetsCode.Size = new System.Drawing.Size(119, 14);
			this.lblAssetsCode.TabIndex = 3;
			// 
			// lblAssetsAdjustmentNo
			// 
			//this.lblAssetsAdjustmentNo.AllowDrop = true;
			this.lblAssetsAdjustmentNo.BackColor = System.Drawing.Color.FromArgb(224, 230, 237);
			this.lblAssetsAdjustmentNo.Text = "Condition  Code";
			this.lblAssetsAdjustmentNo.ForeColor = System.Drawing.Color.Black;
			this.lblAssetsAdjustmentNo.Location = new System.Drawing.Point(8, 60);
			// // this.lblAssetsAdjustmentNo.mLabelId = 1165;
			this.lblAssetsAdjustmentNo.Name = "lblAssetsAdjustmentNo";
			this.lblAssetsAdjustmentNo.Size = new System.Drawing.Size(75, 14);
			this.lblAssetsAdjustmentNo.TabIndex = 4;
			// 
			// System.Windows.Forms.Label4
			// 
			//this.Label4.AllowDrop = true;
			this.Label4.BackColor = System.Drawing.Color.FromArgb(224, 230, 237);
			this.Label4.Text = "Condition Name (Arabic)";
			this.Label4.ForeColor = System.Drawing.Color.Black;
			this.Label4.Location = new System.Drawing.Point(8, 100);
			// this.Label4.mLabelId = 1167;
			this.Label4.Name="Label4";
			this.Label4.Size = new System.Drawing.Size(117, 14);
			this.Label4.TabIndex = 5;
			// 
			// System.Windows.Forms.Label1
			// 
			//this.Label1.AllowDrop = true;
			this.Label1.BackColor = System.Drawing.Color.FromArgb(224, 230, 237);
			this.Label1.Text = "Comments";
			this.Label1.ForeColor = System.Drawing.Color.Black;
			this.Label1.Location = new System.Drawing.Point(8, 120);
			// this.Label1.mLabelId = 135;
			this.Label1.Name="Label1";
			this.Label1.Size = new System.Drawing.Size(49, 13);
			this.Label1.TabIndex = 6;
			// 
			// _txtCommon_3
			// 
			//this._txtCommon_3.AllowDrop = true;
			this._txtCommon_3.BackColor = System.Drawing.Color.White;
			this._txtCommon_3.ForeColor = System.Drawing.Color.Black;
			this._txtCommon_3.Location = new System.Drawing.Point(154, 119);
			this._txtCommon_3.MaxLength = 250;
			this._txtCommon_3.Name = "_txtCommon_3";
			this._txtCommon_3.Size = new System.Drawing.Size(203, 41);
			this._txtCommon_3.TabIndex = 7;
			this._txtCommon_3.Text = "";
			// this.// = "";
			// this.//this._txtCommon_3.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(//this.txtCommon_DropButtonClick);
			// 
			// frmREContractConditions
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.FromArgb(224, 230, 237);
			this.ClientSize = new System.Drawing.Size(373, 172);
			this.Controls.Add(this._txtCommon_0);
			this.Controls.Add(this._txtCommon_1);
			this.Controls.Add(this._txtCommon_2);
			this.Controls.Add(this.lblAssetsCode);
			this.Controls.Add(this.lblAssetsAdjustmentNo);
			this.Controls.Add(this.Label4);
			this.Controls.Add(this.Label1);
			this.Controls.Add(this._txtCommon_3);
			//this.Icon = (System.Drawing.Icon) resources.GetObject("frmREContractConditions.Icon");
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(111, 216);
			this.MaximizeBox = true;
			this.MinimizeBox = true;
			this.Name = "frmREContractConditions";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Contract Conditions";
			// this.Activated += new System.EventHandler(this.frmREContractConditions_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
			// this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
			this.ResumeLayout(false);
		}
		// 
		void InitializetxtCommon()
		{
			this.txtCommon = new System.Windows.Forms.TextBox[4];
			this.txtCommon[0] = _txtCommon_0;
			this.txtCommon[1] = _txtCommon_1;
			this.txtCommon[2] = _txtCommon_2;
			this.txtCommon[3] = _txtCommon_3;
		}
		#endregion
	}
}//ENDSHERE
