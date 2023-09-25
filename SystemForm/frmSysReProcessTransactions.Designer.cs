
namespace Xtreme
{
	partial class frmSysReProcessTransactions
	{

		#region "Upgrade Support "
		private static frmSysReProcessTransactions m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmSysReProcessTransactions DefInstance
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
		public static frmSysReProcessTransactions CreateInstance()
		{
			frmSysReProcessTransactions theInstance = new frmSysReProcessTransactions();
			
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
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "_optReprocessType_1", "_optReprocessType_0", "cmdOKCancel", "lblVoucherType", "lblVoucherNo", "lblLocatCode", "DlblVoucherName", "DlblVoucherNo", "DlblVoucherType", "DlblLocationCode", "DlblLocationName", "Shape2", "Shape1", "optReprocessType"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		private System.Windows.Forms.RadioButton _optReprocessType_1;
		private System.Windows.Forms.RadioButton _optReprocessType_0;
		public UCOkCancel cmdOKCancel;
		public System.Windows.Forms.Label lblVoucherType;
		public System.Windows.Forms.Label lblVoucherNo;
		public System.Windows.Forms.Label lblLocatCode;
		public System.Windows.Forms.Label DlblVoucherName;
		public System.Windows.Forms.Label DlblVoucherNo;
		public System.Windows.Forms.Label DlblVoucherType;
		public System.Windows.Forms.Label DlblLocationCode;
		public System.Windows.Forms.Label DlblLocationName;
		public ShapeHelper Shape2;
		public ShapeHelper Shape1;
		public System.Windows.Forms.RadioButton[] optReprocessType = new System.Windows.Forms.RadioButton[2];
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSysReProcessTransactions));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this._optReprocessType_1 = new System.Windows.Forms.RadioButton();
			this._optReprocessType_0 = new System.Windows.Forms.RadioButton();
			this.cmdOKCancel = new UCOkCancel();
			this.lblVoucherType = new System.Windows.Forms.Label();
			this.lblVoucherNo = new System.Windows.Forms.Label();
			this.lblLocatCode = new System.Windows.Forms.Label();
			this.DlblVoucherName = new System.Windows.Forms.Label();
			this.DlblVoucherNo = new System.Windows.Forms.Label();
			this.DlblVoucherType = new System.Windows.Forms.Label();
			this.DlblLocationCode = new System.Windows.Forms.Label();
			this.DlblLocationName = new System.Windows.Forms.Label();
			this.Shape2 = new ShapeHelper();
			this.Shape1 = new ShapeHelper();
			this.SuspendLayout();
			// 
			// _optReprocessType_1
			// 
			this._optReprocessType_1.AllowDrop = true;
			this._optReprocessType_1.Appearance = System.Windows.Forms.Appearance.Normal;
			this._optReprocessType_1.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._optReprocessType_1.CausesValidation = true;
			this._optReprocessType_1.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._optReprocessType_1.Checked = false;
			this._optReprocessType_1.Enabled = true;
			this._optReprocessType_1.ForeColor = System.Drawing.SystemColors.ControlText;
			this._optReprocessType_1.Location = new System.Drawing.Point(27, 75);
			this._optReprocessType_1.Name = "_optReprocessType_1";
			this._optReprocessType_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._optReprocessType_1.Size = new System.Drawing.Size(281, 13);
			this._optReprocessType_1.TabIndex = 5;
			this._optReprocessType_1.TabStop = true;
			this._optReprocessType_1.Text = "Repost Vouchers Using Backup Sequence";
			this._optReprocessType_1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._optReprocessType_1.Visible = true;
			this._optReprocessType_1.CheckedChanged += new System.EventHandler(this.optReprocessType_CheckedChanged);
			// 
			// _optReprocessType_0
			// 
			this._optReprocessType_0.AllowDrop = true;
			this._optReprocessType_0.Appearance = System.Windows.Forms.Appearance.Normal;
			this._optReprocessType_0.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._optReprocessType_0.CausesValidation = true;
			this._optReprocessType_0.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._optReprocessType_0.Checked = true;
			this._optReprocessType_0.Enabled = true;
			this._optReprocessType_0.ForeColor = System.Drawing.SystemColors.ControlText;
			this._optReprocessType_0.Location = new System.Drawing.Point(27, 55);
			this._optReprocessType_0.Name = "_optReprocessType_0";
			this._optReprocessType_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._optReprocessType_0.Size = new System.Drawing.Size(154, 15);
			this._optReprocessType_0.TabIndex = 4;
			this._optReprocessType_0.TabStop = true;
			this._optReprocessType_0.Text = "Unpost Vouchers";
			this._optReprocessType_0.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._optReprocessType_0.Visible = true;
			this._optReprocessType_0.CheckedChanged += new System.EventHandler(this.optReprocessType_CheckedChanged);
			// 
			// cmdOKCancel
			// 
			this.cmdOKCancel.AllowDrop = true;
			this.cmdOKCancel.DisplayButton = 0;
			this.cmdOKCancel.Location = new System.Drawing.Point(132, 194);
			this.cmdOKCancel.Name = "cmdOKCancel";
			this.cmdOKCancel.OkCaption = "&Ok";
			this.cmdOKCancel.Size = new System.Drawing.Size(206, 31);
			this.cmdOKCancel.TabIndex = 0;
			//this.cmdOKCancel.CancelClick += new UCOkCancel.CancelClickHandler(this.cmdOKCancel_CancelClick);
			//this.cmdOKCancel.OKClick += new UCOkCancel.OKClickHandler(this.cmdOKCancel_OKClick);
			// 
			// lblVoucherType
			// 
			this.lblVoucherType.AllowDrop = true;
			this.lblVoucherType.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblVoucherType.Text = "Voucher Type";
			this.lblVoucherType.Location = new System.Drawing.Point(18, 112);
			this.lblVoucherType.Name = "lblVoucherType";
			this.lblVoucherType.Size = new System.Drawing.Size(66, 13);
			this.lblVoucherType.TabIndex = 1;
			// 
			// lblVoucherNo
			// 
			this.lblVoucherNo.AllowDrop = true;
			this.lblVoucherNo.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblVoucherNo.Text = "Voucher No.";
			this.lblVoucherNo.Location = new System.Drawing.Point(18, 154);
			this.lblVoucherNo.Name = "lblVoucherNo";
			this.lblVoucherNo.Size = new System.Drawing.Size(59, 13);
			this.lblVoucherNo.TabIndex = 2;
			// 
			// lblLocatCode
			// 
			this.lblLocatCode.AllowDrop = true;
			this.lblLocatCode.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblLocatCode.Text = "Location Code";
			this.lblLocatCode.Location = new System.Drawing.Point(18, 133);
			this.lblLocatCode.Name = "lblLocatCode";
			this.lblLocatCode.Size = new System.Drawing.Size(68, 13);
			this.lblLocatCode.TabIndex = 3;
			// 
			// DlblVoucherName
			// 
			this.DlblVoucherName.AllowDrop = true;
			this.DlblVoucherName.Location = new System.Drawing.Point(190, 109);
			this.DlblVoucherName.Name = "DlblVoucherName";
			this.DlblVoucherName.Size = new System.Drawing.Size(241, 19);
			this.DlblVoucherName.TabIndex = 6;
			// 
			// DlblVoucherNo
			// 
			this.DlblVoucherNo.AllowDrop = true;
			this.DlblVoucherNo.Location = new System.Drawing.Point(87, 151);
			this.DlblVoucherNo.Name = "DlblVoucherNo";
			this.DlblVoucherNo.Size = new System.Drawing.Size(101, 19);
			this.DlblVoucherNo.TabIndex = 7;
			// 
			// DlblVoucherType
			// 
			this.DlblVoucherType.AllowDrop = true;
			this.DlblVoucherType.Location = new System.Drawing.Point(87, 109);
			this.DlblVoucherType.Name = "DlblVoucherType";
			this.DlblVoucherType.Size = new System.Drawing.Size(101, 19);
			this.DlblVoucherType.TabIndex = 8;
			// 
			// DlblLocationCode
			// 
			this.DlblLocationCode.AllowDrop = true;
			this.DlblLocationCode.Location = new System.Drawing.Point(87, 130);
			this.DlblLocationCode.Name = "DlblLocationCode";
			this.DlblLocationCode.Size = new System.Drawing.Size(101, 19);
			this.DlblLocationCode.TabIndex = 9;
			// 
			// DlblLocationName
			// 
			this.DlblLocationName.AllowDrop = true;
			this.DlblLocationName.Location = new System.Drawing.Point(190, 130);
			this.DlblLocationName.Name = "DlblLocationName";
			this.DlblLocationName.Size = new System.Drawing.Size(241, 19);
			this.DlblLocationName.TabIndex = 10;
			// 
			// Shape2
			// 
			this.Shape2.AllowDrop = true;
			this.Shape2.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			// = 1;
			this.Shape2.BorderStyle = 1;
			this.Shape2.Enabled = false;
			this.Shape2.FillColor = System.Drawing.Color.Black;
			this.Shape2.FillStyle = 1;
			this.Shape2.Location = new System.Drawing.Point(12, 103);
			this.Shape2.Name = "Shape2";
			this.Shape2.Size = new System.Drawing.Size(444, 82);
			this.Shape2.Visible = true;
			// 
			// Shape1
			// 
			this.Shape1.AllowDrop = true;
			this.Shape1.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			// = 1;
			//
			this.Shape1.Enabled = false;
			//this.Shape1.FillColor = System.Drawing.Color.Black;
			//this.Shape1.FillStyle = 1;
			this.Shape1.Location = new System.Drawing.Point(13, 46);
			this.Shape1.Name = "Shape1";
			this.Shape1.Size = new System.Drawing.Size(355, 50);
			this.Shape1.Visible = true;
			// 
			// frmSysReProcessTransactions
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.ClientSize = new System.Drawing.Size(471, 242);
			this.Controls.Add(this._optReprocessType_1);
			this.Controls.Add(this._optReprocessType_0);
			this.Controls.Add(this.cmdOKCancel);
			this.Controls.Add(this.lblVoucherType);
			this.Controls.Add(this.lblVoucherNo);
			this.Controls.Add(this.lblLocatCode);
			this.Controls.Add(this.DlblVoucherName);
			this.Controls.Add(this.DlblVoucherNo);
			this.Controls.Add(this.DlblVoucherType);
			this.Controls.Add(this.DlblLocationCode);
			this.Controls.Add(this.DlblLocationName);
			this.Controls.Add(this.Shape2);
			this.Controls.Add(this.Shape1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			//this.Icon = (System.Drawing.Icon) resources.GetObject("frmSysReProcessTransactions.Icon");
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(383, 274);
			this.MaximizeBox = true;
			this.MinimizeBox = true;
			this.Name = "frmSysReProcessTransactions";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Reprocess Transactions";
			// this.Activated += new System.EventHandler(this.frmSysReProcessTransactions_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
			// this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
			this.ResumeLayout(false);
		}
		// 
		void InitializeoptReprocessType()
		{
			this.optReprocessType = new System.Windows.Forms.RadioButton[2];
			this.optReprocessType[1] = _optReprocessType_1;
			this.optReprocessType[0] = _optReprocessType_0;
		}
		#endregion
	}
}//ENDSHERE
