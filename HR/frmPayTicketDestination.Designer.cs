
namespace Xtreme
{
	partial class frmPayTicketDestination
	{

		#region "Upgrade Support "
		private static frmPayTicketDestination m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmPayTicketDestination DefInstance
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
		public static frmPayTicketDestination CreateInstance()
		{
			frmPayTicketDestination theInstance = new frmPayTicketDestination();
			
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
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "txtDestinationCd", "System.Windows.Forms.Label1", "System.Windows.Forms.Label2", "txtLDestName", "txtADestName", "System.Windows.Forms.Label3", "txtNatNo", "txtNatName", "System.Windows.Forms.Label4", "txtOneWayAmt", "lblReturnAmt", "System.Windows.Forms.Label5", "txtReturnAmt"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public System.Windows.Forms.TextBox txtDestinationCd;
		public System.Windows.Forms.LabelLabel1;
		public System.Windows.Forms.LabelLabel2;
		public System.Windows.Forms.TextBox txtLDestName;
		public System.Windows.Forms.TextBox txtADestName;
		public System.Windows.Forms.LabelLabel3;
		public System.Windows.Forms.TextBox txtNatNo;
		public System.Windows.Forms.Label txtNatName;
		public System.Windows.Forms.LabelLabel4;
		public System.Windows.Forms.TextBox txtOneWayAmt;
		public System.Windows.Forms.Label lblReturnAmt;
		public System.Windows.Forms.LabelLabel5;
		public System.Windows.Forms.TextBox txtReturnAmt;
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPayTicketDestination));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this.txtDestinationCd = new System.Windows.Forms.TextBox();
			this.Label1 = new System.Windows.Forms.Label();
			this.Label2 = new System.Windows.Forms.Label();
			this.txtLDestName = new System.Windows.Forms.TextBox();
			this.txtADestName = new System.Windows.Forms.TextBox();
			this.Label3 = new System.Windows.Forms.Label();
			this.txtNatNo = new System.Windows.Forms.TextBox();
			this.txtNatName = new System.Windows.Forms.Label();
			this.Label4 = new System.Windows.Forms.Label();
			this.txtOneWayAmt = new System.Windows.Forms.TextBox();
			this.lblReturnAmt = new System.Windows.Forms.Label();
			this.Label5 = new System.Windows.Forms.Label();
			this.txtReturnAmt = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// txtDestinationCd
			// 
			this.txtDestinationCd.AllowDrop = true;
			this.txtDestinationCd.BackColor = System.Drawing.Color.White;
			// this.txtDestinationCd.bolAllowDecimal = false;
			this.txtDestinationCd.ForeColor = System.Drawing.Color.Black;
			this.txtDestinationCd.Location = new System.Drawing.Point(148, 54);
			// this.txtDestinationCd.mDropDownType = (System.Windows.Forms.TextBox.DropDownTypes) 0;
			this.txtDestinationCd.Name = "txtDestinationCd";
			// this.txtDestinationCd.ShowButton = true;
			this.txtDestinationCd.Size = new System.Drawing.Size(115, 21);
			this.txtDestinationCd.TabIndex = 1;
			this.txtDestinationCd.Text = "";
			// this.this.txtDestinationCd.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtDestinationCd_DropButtonClick);
			// 
			// System.Windows.Forms.Label1
			// 
			this.Label1.AllowDrop = true;
			this.Label1.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.Label1.Text = "Ticket Destination Name(ENG)";
			this.Label1.Location = new System.Drawing.Point(0, 81);
			// this.Label1.mLabelId = 2089;
			this.Label1.Name = "System.Windows.Forms.Label1";
			this.Label1.Size = new System.Drawing.Size(143, 14);
			this.Label1.TabIndex = 0;
			// 
			// System.Windows.Forms.Label2
			// 
			this.Label2.AllowDrop = true;
			this.Label2.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.Label2.Text = "Ticket Destination Name(ARB)";
			this.Label2.Location = new System.Drawing.Point(0, 104);
			// this.Label2.mLabelId = 2090;
			this.Label2.Name = "System.Windows.Forms.Label2";
			this.Label2.Size = new System.Drawing.Size(144, 14);
			this.Label2.TabIndex = 7;
			// 
			// txtLDestName
			// 
			this.txtLDestName.AllowDrop = true;
			this.txtLDestName.BackColor = System.Drawing.Color.White;
			// this.txtLDestName.bolAllowDecimal = false;
			this.txtLDestName.ForeColor = System.Drawing.Color.Black;
			this.txtLDestName.Location = new System.Drawing.Point(148, 78);
			// this.txtLDestName.mDropDownType = (System.Windows.Forms.TextBox.DropDownTypes) 0;
			this.txtLDestName.Name = "txtLDestName";
			this.txtLDestName.Size = new System.Drawing.Size(291, 21);
			this.txtLDestName.TabIndex = 2;
			this.txtLDestName.Text = "";
			// 
			// txtADestName
			// 
			this.txtADestName.AllowDrop = true;
			this.txtADestName.BackColor = System.Drawing.Color.White;
			// this.txtADestName.bolAllowDecimal = false;
			this.txtADestName.ForeColor = System.Drawing.Color.Black;
			this.txtADestName.Location = new System.Drawing.Point(148, 101);
			// this.txtADestName.mDropDownType = (System.Windows.Forms.TextBox.DropDownTypes) 0;
			this.txtADestName.Name = "txtADestName";
			this.txtADestName.Size = new System.Drawing.Size(291, 21);
			this.txtADestName.TabIndex = 3;
			this.txtADestName.Text = "";
			// 
			// System.Windows.Forms.Label3
			// 
			this.Label3.AllowDrop = true;
			this.Label3.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.Label3.Text = "Nationality Code";
			this.Label3.Location = new System.Drawing.Point(0, 126);
			// this.Label3.mLabelId = 1058;
			this.Label3.Name = "System.Windows.Forms.Label3";
			this.Label3.Size = new System.Drawing.Size(77, 14);
			this.Label3.TabIndex = 8;
			// 
			// txtNatNo
			// 
			this.txtNatNo.AllowDrop = true;
			this.txtNatNo.BackColor = System.Drawing.Color.White;
			// this.txtNatNo.bolNumericOnly = true;
			this.txtNatNo.ForeColor = System.Drawing.Color.Black;
			this.txtNatNo.Location = new System.Drawing.Point(148, 124);
			this.txtNatNo.MaxLength = 15;
			// this.txtNatNo.mDropDownType = System.Windows.Forms.TextBox.DropDownTypes.ddtNextNumber;
			this.txtNatNo.Name = "txtNatNo";
			// this.txtNatNo.ShowButton = true;
			this.txtNatNo.Size = new System.Drawing.Size(97, 19);
			this.txtNatNo.TabIndex = 4;
			this.txtNatNo.Text = "";
			// this.this.txtNatNo.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtNatNo_DropButtonClick);
			// this.txtNatNo.Leave += new System.EventHandler(this.txtNatNo_Leave);
			// 
			// txtNatName
			// 
			this.txtNatName.AllowDrop = true;
			this.txtNatName.BackColor = System.Drawing.SystemColors.Window;
			this.txtNatName.Enabled = false;
			this.txtNatName.Location = new System.Drawing.Point(247, 124);
			this.txtNatName.Name = "txtNatName";
			this.txtNatName.Size = new System.Drawing.Size(191, 19);
			this.txtNatName.TabIndex = 9;
			// 
			// System.Windows.Forms.Label4
			// 
			this.Label4.AllowDrop = true;
			this.Label4.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.Label4.Text = "One Way Ticket Amount";
			this.Label4.Location = new System.Drawing.Point(0, 176);
			// this.Label4.mLabelId = 2091;
			this.Label4.Name = "System.Windows.Forms.Label4";
			this.Label4.Size = new System.Drawing.Size(116, 14);
			this.Label4.TabIndex = 10;
			this.Label4.Visible = false;
			// 
			// txtOneWayAmt
			// 
			this.txtOneWayAmt.AllowDrop = true;
			this.txtOneWayAmt.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtOneWayAmt.Location = new System.Drawing.Point(148, 171);
			this.txtOneWayAmt.Name = "txtOneWayAmt";
			this.txtOneWayAmt.Size = new System.Drawing.Size(95, 21);
			this.txtOneWayAmt.TabIndex = 5;
			this.txtOneWayAmt.Visible = false;
			// 
			// lblReturnAmt
			// 
			this.lblReturnAmt.AllowDrop = true;
			this.lblReturnAmt.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblReturnAmt.Text = "Return Ticket Amount";
			this.lblReturnAmt.Location = new System.Drawing.Point(2, 148);
			// // this.lblReturnAmt.mLabelId = 2092;
			this.lblReturnAmt.Name = "lblReturnAmt";
			this.lblReturnAmt.Size = new System.Drawing.Size(103, 14);
			this.lblReturnAmt.TabIndex = 11;
			// 
			// System.Windows.Forms.Label5
			// 
			this.Label5.AllowDrop = true;
			this.Label5.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.Label5.Text = "Ticket Destination Code";
			this.Label5.Location = new System.Drawing.Point(0, 57);
			// this.Label5.mLabelId = 2088;
			this.Label5.Name = "System.Windows.Forms.Label5";
			this.Label5.Size = new System.Drawing.Size(112, 14);
			this.Label5.TabIndex = 12;
			// 
			// txtReturnAmt
			// 
			this.txtReturnAmt.AllowDrop = true;
			this.txtReturnAmt.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtReturnAmt.Location = new System.Drawing.Point(148, 145);
			this.txtReturnAmt.Name = "txtReturnAmt";
			this.txtReturnAmt.Size = new System.Drawing.Size(95, 21);
			this.txtReturnAmt.TabIndex = 6;
			// 
			// frmPayTicketDestination
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.ClientSize = new System.Drawing.Size(545, 265);
			this.Controls.Add(this.txtDestinationCd);
			this.Controls.Add(this.Label1);
			this.Controls.Add(this.Label2);
			this.Controls.Add(this.txtLDestName);
			this.Controls.Add(this.txtADestName);
			this.Controls.Add(this.Label3);
			this.Controls.Add(this.txtNatNo);
			this.Controls.Add(this.txtNatName);
			this.Controls.Add(this.Label4);
			this.Controls.Add(this.txtOneWayAmt);
			this.Controls.Add(this.lblReturnAmt);
			this.Controls.Add(this.Label5);
			this.Controls.Add(this.txtReturnAmt);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			//this.Icon = (System.Drawing.Icon) resources.GetObject("frmPayTicketDestination.Icon");
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(275, 344);
			this.MaximizeBox = true;
			this.MinimizeBox = true;
			this.Name = "frmPayTicketDestination";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Ticket Destination";
			// this.Activated += new System.EventHandler(this.frmPayTicketDestination_Activated);
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
}//ENDSHERE
