
namespace Xtreme
{
	partial class frmREPropertyItemType
	{

		#region "Upgrade Support "
		private static frmREPropertyItemType m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmREPropertyItemType DefInstance
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
		public static frmREPropertyItemType CreateInstance()
		{
			frmREPropertyItemType theInstance = new frmREPropertyItemType();
			
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
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "DetailsRequired", "_txtCommon_0", "lblAssetsCode", "lblAssetsAdjustmentNo", "_txtCommon_1", "System.Windows.Forms.Label6", "_txtCommon_2", "System.Windows.Forms.Label1", "txtCommon"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public System.Windows.Forms.CheckBox DetailsRequired;
		private System.Windows.Forms.TextBox _txtCommon_0;
		public System.Windows.Forms.Label lblAssetsCode;
		public System.Windows.Forms.Label lblAssetsAdjustmentNo;
		private System.Windows.Forms.TextBox _txtCommon_1;
		public System.Windows.Forms.LabelLabel6;
		private System.Windows.Forms.TextBox _txtCommon_2;
		public System.Windows.Forms.LabelLabel1;
		public System.Windows.Forms.TextBox[] txtCommon = new System.Windows.Forms.TextBox[3];
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmREPropertyItemType));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this.DetailsRequired = new System.Windows.Forms.CheckBox();
			this._txtCommon_0 = new System.Windows.Forms.TextBox();
			this.lblAssetsCode = new System.Windows.Forms.Label();
			this.lblAssetsAdjustmentNo = new System.Windows.Forms.Label();
			this._txtCommon_1 = new System.Windows.Forms.TextBox();
			this.Label6 = new System.Windows.Forms.Label();
			this._txtCommon_2 = new System.Windows.Forms.TextBox();
			this.Label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// DetailsRequired
			// 
			this.DetailsRequired.AllowDrop = true;
			this.DetailsRequired.Appearance = System.Windows.Forms.Appearance.Normal;
			this.DetailsRequired.BackColor = System.Drawing.Color.FromArgb(224, 230, 237);
			this.DetailsRequired.CausesValidation = true;
			this.DetailsRequired.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.DetailsRequired.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this.DetailsRequired.Enabled = true;
			this.DetailsRequired.ForeColor = System.Drawing.Color.Black;
			this.DetailsRequired.Location = new System.Drawing.Point(150, 119);
			this.DetailsRequired.Name = "DetailsRequired";
			this.DetailsRequired.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.DetailsRequired.Size = new System.Drawing.Size(115, 15);
			this.DetailsRequired.TabIndex = 3;
			this.DetailsRequired.TabStop = true;
			this.DetailsRequired.Text = "Details Required";
			this.DetailsRequired.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.DetailsRequired.Visible = true;
			// 
			// _txtCommon_0
			// 
			this._txtCommon_0.AllowDrop = true;
			this._txtCommon_0.BackColor = System.Drawing.Color.White;
			this._txtCommon_0.ForeColor = System.Drawing.Color.Black;
			this._txtCommon_0.Location = new System.Drawing.Point(150, 50);
			this._txtCommon_0.MaxLength = 15;
			// this._txtCommon_0.mDropDownType = System.Windows.Forms.TextBox.DropDownTypes.ddtNextNumber;
			this._txtCommon_0.Name = "_txtCommon_0";
			// this._txtCommon_0.ShowButton = true;
			this._txtCommon_0.Size = new System.Drawing.Size(101, 19);
			this._txtCommon_0.TabIndex = 0;
			this._txtCommon_0.Text = "";
			// this.this._txtCommon_0.Watermark = "";
			// this.this._txtCommon_0.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommon_DropButtonClick);
			// 
			// lblAssetsCode
			// 
			this.lblAssetsCode.AllowDrop = true;
			this.lblAssetsCode.BackColor = System.Drawing.Color.FromArgb(224, 230, 237);
			this.lblAssetsCode.Text = "Item Type Name (English)";
			this.lblAssetsCode.ForeColor = System.Drawing.Color.Black;
			this.lblAssetsCode.Location = new System.Drawing.Point(8, 74);
			// // this.lblAssetsCode.mLabelId = 1208;
			this.lblAssetsCode.Name = "lblAssetsCode";
			this.lblAssetsCode.Size = new System.Drawing.Size(121, 14);
			this.lblAssetsCode.TabIndex = 4;
			// 
			// lblAssetsAdjustmentNo
			// 
			this.lblAssetsAdjustmentNo.AllowDrop = true;
			this.lblAssetsAdjustmentNo.BackColor = System.Drawing.Color.FromArgb(224, 230, 237);
			this.lblAssetsAdjustmentNo.Text = "Item Type  Code";
			this.lblAssetsAdjustmentNo.ForeColor = System.Drawing.Color.Black;
			this.lblAssetsAdjustmentNo.Location = new System.Drawing.Point(8, 53);
			// // this.lblAssetsAdjustmentNo.mLabelId = 1197;
			this.lblAssetsAdjustmentNo.Name = "lblAssetsAdjustmentNo";
			this.lblAssetsAdjustmentNo.Size = new System.Drawing.Size(77, 14);
			this.lblAssetsAdjustmentNo.TabIndex = 5;
			// 
			// _txtCommon_1
			// 
			this._txtCommon_1.AllowDrop = true;
			this._txtCommon_1.BackColor = System.Drawing.Color.White;
			this._txtCommon_1.ForeColor = System.Drawing.Color.Black;
			this._txtCommon_1.Location = new System.Drawing.Point(150, 71);
			this._txtCommon_1.MaxLength = 250;
			this._txtCommon_1.Name = "_txtCommon_1";
			this._txtCommon_1.Size = new System.Drawing.Size(201, 19);
			this._txtCommon_1.TabIndex = 1;
			this._txtCommon_1.Text = "";
			// this.this._txtCommon_1.Watermark = "";
			// this.this._txtCommon_1.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommon_DropButtonClick);
			// 
			// System.Windows.Forms.Label6
			// 
			this.Label6.AllowDrop = true;
			this.Label6.BackColor = System.Drawing.Color.FromArgb(224, 230, 237);
			this.Label6.Text = "Item Type Name (Arabic)";
			this.Label6.ForeColor = System.Drawing.Color.Black;
			this.Label6.Location = new System.Drawing.Point(8, 95);
			// this.Label6.mLabelId = 1209;
			this.Label6.Name = "System.Windows.Forms.Label6";
			this.Label6.Size = new System.Drawing.Size(119, 14);
			this.Label6.TabIndex = 6;
			// 
			// _txtCommon_2
			// 
			this._txtCommon_2.AllowDrop = true;
			this._txtCommon_2.BackColor = System.Drawing.Color.White;
			this._txtCommon_2.ForeColor = System.Drawing.Color.Black;
			this._txtCommon_2.Location = new System.Drawing.Point(150, 92);
			// this._txtCommon_2.mArabicEnabled = true;
			this._txtCommon_2.MaxLength = 250;
			this._txtCommon_2.Name = "_txtCommon_2";
			this._txtCommon_2.Size = new System.Drawing.Size(201, 19);
			this._txtCommon_2.TabIndex = 2;
			this._txtCommon_2.Text = "";
			// this.this._txtCommon_2.Watermark = "";
			// this.this._txtCommon_2.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCommon_DropButtonClick);
			// 
			// System.Windows.Forms.Label1
			// 
			this.Label1.AllowDrop = true;
			this.Label1.BackColor = System.Drawing.Color.FromArgb(224, 230, 237);
			this.Label1.Text = "Details Required";
			this.Label1.ForeColor = System.Drawing.Color.Black;
			this.Label1.Location = new System.Drawing.Point(8, 120);
			// this.Label1.mLabelId = 1210;
			this.Label1.Name = "System.Windows.Forms.Label1";
			this.Label1.Size = new System.Drawing.Size(78, 14);
			this.Label1.TabIndex = 7;
			// 
			// frmREPropertyItemType
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.FromArgb(224, 230, 237);
			this.ClientSize = new System.Drawing.Size(376, 149);
			this.Controls.Add(this.DetailsRequired);
			this.Controls.Add(this._txtCommon_0);
			this.Controls.Add(this.lblAssetsCode);
			this.Controls.Add(this.lblAssetsAdjustmentNo);
			this.Controls.Add(this._txtCommon_1);
			this.Controls.Add(this.Label6);
			this.Controls.Add(this._txtCommon_2);
			this.Controls.Add(this.Label1);
			//this.Icon = (System.Drawing.Icon) resources.GetObject("frmREPropertyItemType.Icon");
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(96, 175);
			this.MaximizeBox = true;
			this.MinimizeBox = true;
			this.Name = "frmREPropertyItemType";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Property Item Type";
			// this.Activated += new System.EventHandler(this.frmREPropertyItemType_Activated);
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
			this.txtCommon = new System.Windows.Forms.TextBox[3];
			this.txtCommon[0] = _txtCommon_0;
			this.txtCommon[1] = _txtCommon_1;
			this.txtCommon[2] = _txtCommon_2;
		}
		#endregion
	}
}//ENDSHERE
