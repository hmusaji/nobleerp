
namespace Xtreme
{
	partial class frmPayTicketType
	{

		#region "Upgrade Support "
		private static frmPayTicketType m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmPayTicketType DefInstance
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
		public static frmPayTicketType CreateInstance()
		{
			frmPayTicketType theInstance = new frmPayTicketType();
			
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
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "txtNTicketInDigit", "txtATicketTypeName", "txtLTicketTypeName", "System.Windows.Forms.Label1", "System.Windows.Forms.Label2", "System.Windows.Forms.Label3", "System.Windows.Forms.Label5", "txtTicketTypeCode", "lblEarBillName", "txtEarBillNo", "txtEarBillCdName", "lblDedBillName", "txtDedBillNo", "txtDedBillCdName"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public System.Windows.Forms.TextBox txtNTicketInDigit;
		public System.Windows.Forms.TextBox txtATicketTypeName;
		public System.Windows.Forms.TextBox txtLTicketTypeName;
		public System.Windows.Forms.Label System.Windows.Forms.Label1;
		public System.Windows.Forms.Label System.Windows.Forms.Label2;
		public System.Windows.Forms.Label System.Windows.Forms.Label3;
		public System.Windows.Forms.Label System.Windows.Forms.Label5;
		public System.Windows.Forms.TextBox txtTicketTypeCode;
		public System.Windows.Forms.Label lblEarBillName;
		public System.Windows.Forms.TextBox txtEarBillNo;
		public System.Windows.Forms.Label txtEarBillCdName;
		public System.Windows.Forms.Label lblDedBillName;
		public System.Windows.Forms.TextBox txtDedBillNo;
		public System.Windows.Forms.Label txtDedBillCdName;
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPayTicketType));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this.txtNTicketInDigit = new System.Windows.Forms.TextBox();
			this.txtATicketTypeName = new System.Windows.Forms.TextBox();
			this.txtLTicketTypeName = new System.Windows.Forms.TextBox();
			this.System.Windows.Forms.Label1 = new System.Windows.Forms.Label();
			this.System.Windows.Forms.Label2 = new System.Windows.Forms.Label();
			this.System.Windows.Forms.Label3 = new System.Windows.Forms.Label();
			this.System.Windows.Forms.Label5 = new System.Windows.Forms.Label();
			this.txtTicketTypeCode = new System.Windows.Forms.TextBox();
			this.lblEarBillName = new System.Windows.Forms.Label();
			this.txtEarBillNo = new System.Windows.Forms.TextBox();
			this.txtEarBillCdName = new System.Windows.Forms.Label();
			this.lblDedBillName = new System.Windows.Forms.Label();
			this.txtDedBillNo = new System.Windows.Forms.TextBox();
			this.txtDedBillCdName = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// txtNTicketInDigit
			// 
			this.txtNTicketInDigit.AllowDrop = true;
			// this.txtNTicketInDigit.DisplayFormat = "####0.00;;Null";
			this.txtNTicketInDigit.ForeColor = System.Drawing.SystemColors.WindowText;
			// this.txtNTicketInDigit.Format = "####0.00";
			this.txtNTicketInDigit.Location = new System.Drawing.Point(132, 176);
			this.txtNTicketInDigit.Name = "txtNTicketInDigit";
			this.txtNTicketInDigit.Size = new System.Drawing.Size(115, 21);
			this.txtNTicketInDigit.TabIndex = 6;
			this.txtNTicketInDigit.Text = "0.00";
			// 
			// txtATicketTypeName
			// 
			this.txtATicketTypeName.AllowDrop = true;
			this.txtATicketTypeName.BackColor = System.Drawing.Color.White;
			// this.txtATicketTypeName.bolAllowDecimal = false;
			this.txtATicketTypeName.ForeColor = System.Drawing.Color.Black;
			this.txtATicketTypeName.Location = new System.Drawing.Point(132, 109);
			// this.txtATicketTypeName.mDropDownType = (System.Windows.Forms.TextBox.DropDownTypes) 0;
			this.txtATicketTypeName.Name = "txtATicketTypeName";
			this.txtATicketTypeName.Size = new System.Drawing.Size(291, 21);
			this.txtATicketTypeName.TabIndex = 3;
			this.txtATicketTypeName.Text = "";
			// 
			// txtLTicketTypeName
			// 
			this.txtLTicketTypeName.AllowDrop = true;
			this.txtLTicketTypeName.BackColor = System.Drawing.Color.White;
			// this.txtLTicketTypeName.bolAllowDecimal = false;
			this.txtLTicketTypeName.ForeColor = System.Drawing.Color.Black;
			this.txtLTicketTypeName.Location = new System.Drawing.Point(132, 86);
			// this.txtLTicketTypeName.mDropDownType = (System.Windows.Forms.TextBox.DropDownTypes) 0;
			this.txtLTicketTypeName.Name = "txtLTicketTypeName";
			this.txtLTicketTypeName.Size = new System.Drawing.Size(291, 21);
			this.txtLTicketTypeName.TabIndex = 2;
			this.txtLTicketTypeName.Text = "";
			// 
			// System.Windows.Forms.Label1
			// 
			this.System.Windows.Forms.Label1.AllowDrop = true;
			this.System.Windows.Forms.Label1.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.System.Windows.Forms.Label1.Caption = "Ticket Type Name (ENG)";
			this.System.Windows.Forms.Label1.Location = new System.Drawing.Point(8, 89);
			this.System.Windows.Forms.Label1.mLabelId = 2094;
			this.System.Windows.Forms.Label1.Name = "System.Windows.Forms.Label1";
			this.System.Windows.Forms.Label1.Size = new System.Drawing.Size(117, 14);
			this.System.Windows.Forms.Label1.TabIndex = 0;
			// 
			// System.Windows.Forms.Label2
			// 
			this.System.Windows.Forms.Label2.AllowDrop = true;
			this.System.Windows.Forms.Label2.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.System.Windows.Forms.Label2.Caption = "Ticket Type Name (ARB) ";
			this.System.Windows.Forms.Label2.Location = new System.Drawing.Point(8, 112);
			this.System.Windows.Forms.Label2.mLabelId = 2095;
			this.System.Windows.Forms.Label2.Name = "System.Windows.Forms.Label2";
			this.System.Windows.Forms.Label2.Size = new System.Drawing.Size(121, 14);
			this.System.Windows.Forms.Label2.TabIndex = 7;
			// 
			// System.Windows.Forms.Label3
			// 
			this.System.Windows.Forms.Label3.AllowDrop = true;
			this.System.Windows.Forms.Label3.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.System.Windows.Forms.Label3.Caption = "Ticket Type Name ENG ";
			this.System.Windows.Forms.Label3.Location = new System.Drawing.Point(4, 181);
			this.System.Windows.Forms.Label3.mLabelId = 2096;
			this.System.Windows.Forms.Label3.Name = "System.Windows.Forms.Label3";
			this.System.Windows.Forms.Label3.Size = new System.Drawing.Size(112, 14);
			this.System.Windows.Forms.Label3.TabIndex = 8;
			// 
			// System.Windows.Forms.Label5
			// 
			this.System.Windows.Forms.Label5.AllowDrop = true;
			this.System.Windows.Forms.Label5.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.System.Windows.Forms.Label5.Caption = "Ticket Type Code";
			this.System.Windows.Forms.Label5.Location = new System.Drawing.Point(8, 65);
			this.System.Windows.Forms.Label5.mLabelId = 2093;
			this.System.Windows.Forms.Label5.Name = "System.Windows.Forms.Label5";
			this.System.Windows.Forms.Label5.Size = new System.Drawing.Size(83, 14);
			this.System.Windows.Forms.Label5.TabIndex = 9;
			// 
			// txtTicketTypeCode
			// 
			this.txtTicketTypeCode.AllowDrop = true;
			this.txtTicketTypeCode.BackColor = System.Drawing.Color.White;
			// this.txtTicketTypeCode.bolAllowDecimal = false;
			this.txtTicketTypeCode.ForeColor = System.Drawing.Color.Black;
			this.txtTicketTypeCode.Location = new System.Drawing.Point(132, 62);
			// this.txtTicketTypeCode.mDropDownType = (System.Windows.Forms.TextBox.DropDownTypes) 0;
			this.txtTicketTypeCode.Name = "txtTicketTypeCode";
			// this.txtTicketTypeCode.ShowButton = true;
			this.txtTicketTypeCode.Size = new System.Drawing.Size(115, 21);
			this.txtTicketTypeCode.TabIndex = 1;
			this.txtTicketTypeCode.Text = "";
			// this.this.txtTicketTypeCode.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtTicketTypeCode_DropButtonClick);
			// 
			// lblEarBillName
			// 
			this.lblEarBillName.AllowDrop = true;
			this.lblEarBillName.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblEarBillName.Text = "Earning Bill Code";
			this.lblEarBillName.Location = new System.Drawing.Point(8, 134);
			// this.lblEarBillName.mLabelId = 1995;
			this.lblEarBillName.Name = "lblEarBillName";
			this.lblEarBillName.Size = new System.Drawing.Size(80, 14);
			this.lblEarBillName.TabIndex = 10;
			// 
			// txtEarBillNo
			// 
			this.txtEarBillNo.AllowDrop = true;
			this.txtEarBillNo.BackColor = System.Drawing.Color.White;
			// this.txtEarBillNo.bolNumericOnly = true;
			this.txtEarBillNo.ForeColor = System.Drawing.Color.Black;
			this.txtEarBillNo.Location = new System.Drawing.Point(132, 132);
			this.txtEarBillNo.MaxLength = 15;
			// this.txtEarBillNo.mDropDownType = System.Windows.Forms.TextBox.DropDownTypes.ddtNextNumber;
			this.txtEarBillNo.Name = "txtEarBillNo";
			// this.txtEarBillNo.ShowButton = true;
			this.txtEarBillNo.Size = new System.Drawing.Size(97, 19);
			this.txtEarBillNo.TabIndex = 4;
			this.txtEarBillNo.Text = "";
			// this.this.txtEarBillNo.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtEarBillNo_DropButtonClick);
			// this.txtEarBillNo.Leave += new System.EventHandler(this.txtEarBillNo_Leave);
			// 
			// txtEarBillCdName
			// 
			this.txtEarBillCdName.AllowDrop = true;
			this.txtEarBillCdName.BackColor = System.Drawing.SystemColors.Window;
			this.txtEarBillCdName.Enabled = false;
			this.txtEarBillCdName.Location = new System.Drawing.Point(230, 132);
			this.txtEarBillCdName.Name = "txtEarBillCdName";
			this.txtEarBillCdName.Size = new System.Drawing.Size(193, 19);
			this.txtEarBillCdName.TabIndex = 11;
			// 
			// lblDedBillName
			// 
			this.lblDedBillName.AllowDrop = true;
			this.lblDedBillName.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblDedBillName.Text = "Deduction Bill Code";
			this.lblDedBillName.Location = new System.Drawing.Point(8, 156);
			// this.lblDedBillName.mLabelId = 1997;
			this.lblDedBillName.Name = "lblDedBillName";
			this.lblDedBillName.Size = new System.Drawing.Size(92, 14);
			this.lblDedBillName.TabIndex = 12;
			// 
			// txtDedBillNo
			// 
			this.txtDedBillNo.AllowDrop = true;
			this.txtDedBillNo.BackColor = System.Drawing.Color.White;
			// this.txtDedBillNo.bolNumericOnly = true;
			this.txtDedBillNo.ForeColor = System.Drawing.Color.Black;
			this.txtDedBillNo.Location = new System.Drawing.Point(132, 154);
			this.txtDedBillNo.MaxLength = 15;
			// this.txtDedBillNo.mDropDownType = System.Windows.Forms.TextBox.DropDownTypes.ddtNextNumber;
			this.txtDedBillNo.Name = "txtDedBillNo";
			// this.txtDedBillNo.ShowButton = true;
			this.txtDedBillNo.Size = new System.Drawing.Size(97, 19);
			this.txtDedBillNo.TabIndex = 5;
			this.txtDedBillNo.Text = "";
			// this.this.txtDedBillNo.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtDedBillNo_DropButtonClick);
			// this.txtDedBillNo.Leave += new System.EventHandler(this.txtDedBillNo_Leave);
			// 
			// txtDedBillCdName
			// 
			this.txtDedBillCdName.AllowDrop = true;
			this.txtDedBillCdName.BackColor = System.Drawing.SystemColors.Window;
			this.txtDedBillCdName.Enabled = false;
			this.txtDedBillCdName.Location = new System.Drawing.Point(230, 154);
			this.txtDedBillCdName.Name = "txtDedBillCdName";
			this.txtDedBillCdName.Size = new System.Drawing.Size(193, 19);
			this.txtDedBillCdName.TabIndex = 13;
			// 
			// frmPayTicketType
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.ClientSize = new System.Drawing.Size(444, 209);
			this.Controls.Add(this.txtNTicketInDigit);
			this.Controls.Add(this.txtATicketTypeName);
			this.Controls.Add(this.txtLTicketTypeName);
			this.Controls.Add(this.System.Windows.Forms.Label1);
			this.Controls.Add(this.System.Windows.Forms.Label2);
			this.Controls.Add(this.System.Windows.Forms.Label3);
			this.Controls.Add(this.System.Windows.Forms.Label5);
			this.Controls.Add(this.txtTicketTypeCode);
			this.Controls.Add(this.lblEarBillName);
			this.Controls.Add(this.txtEarBillNo);
			this.Controls.Add(this.txtEarBillCdName);
			this.Controls.Add(this.lblDedBillName);
			this.Controls.Add(this.txtDedBillNo);
			this.Controls.Add(this.txtDedBillCdName);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			//this.Icon = (System.Drawing.Icon) resources.GetObject("frmPayTicketType.Icon");
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(329, 142);
			this.MaximizeBox = true;
			this.MinimizeBox = true;
			this.Name = "frmPayTicketType";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Ticket Type";
			// this.Activated += new System.EventHandler(this.frmPayTicketType_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
			// this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
			this.ResumeLayout(false);
		}
		void ReLoadForm(bool addEvents)
		{
			//This form is an MDI child.
			//This code simulates the VB6 
			// functionality of automatically
			// loading and showing an MDI
			// child's parent.
			this.MdiParent = Xtreme.frmSysMain.DefInstance;
			Xtreme.frmSysMain.DefInstance.Show();
		}
		#endregion
	}
}