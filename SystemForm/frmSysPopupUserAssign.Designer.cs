
namespace Xtreme
{
	partial class frmSysPopupUserAssign
	{

		#region "Upgrade Support "
		private static frmSysPopupUserAssign m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmSysPopupUserAssign DefInstance
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
		public static frmSysPopupUserAssign CreateInstance()
		{
			frmSysPopupUserAssign theInstance = new frmSysPopupUserAssign();
			
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
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "Label1_2079", "System.Windows.Forms.Label2", "txtPopupTypeCdName", "txtPopupTypeCd", "Column_0_grdVoucherDetails", "Column_1_grdVoucherDetails", "grdVoucherDetails", "tcbSystemForm", "Line1", "System.Windows.Forms.Label1"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		private System.Windows.Forms.Label Label1_2079;
		public System.Windows.Forms.LabelLabel2;
		public System.Windows.Forms.Label txtPopupTypeCdName;
		public System.Windows.Forms.TextBox txtPopupTypeCd;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_0_grdVoucherDetails;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_1_grdVoucherDetails;
		public C1.Win.C1TrueDBGrid.C1TrueDBGrid grdVoucherDetails;
		public Syncfusion.Windows.Forms.Tools.CommandBarController tcbSystemForm;
		public System.Windows.Forms.Label Line1;
		public System.Windows.Forms.Label[] Label1 = new System.Windows.Forms.Label[2080];
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSysPopupUserAssign));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this.Label1_2079 = new System.Windows.Forms.Label();
			this.Label2 = new System.Windows.Forms.Label();
			this.txtPopupTypeCdName = new System.Windows.Forms.Label();
			this.txtPopupTypeCd = new System.Windows.Forms.TextBox();
			this.grdVoucherDetails = new C1.Win.C1TrueDBGrid.C1TrueDBGrid();
			this.Column_0_grdVoucherDetails = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.Column_1_grdVoucherDetails = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.tcbSystemForm = new Syncfusion.Windows.Forms.Tools.CommandBarController();
			this.Line1 = new System.Windows.Forms.Label();
			// //((System.ComponentModel.ISupportInitialize) this.tcbSystemForm).BeginInit();
			this.grdVoucherDetails.SuspendLayout();
			this.SuspendLayout();
			// 
			// Label1_2079
			// 
			this.Label1_2079.AllowDrop = true;
			this.Label1_2079.BackColor = System.Drawing.SystemColors.Window;
			this.Label1_2079.Text = "Popup Type";
			this.Label1_2079.Location = new System.Drawing.Point(8, 46);
			this.Label1_2079.Name = "Label1_2079";
			this.Label1_2079.Size = new System.Drawing.Size(57, 14);
			this.Label1_2079.TabIndex = 4;
			// 
			// System.Windows.Forms.Label2
			// 
			this.Label2.AllowDrop = true;
			this.Label2.BackColor = System.Drawing.SystemColors.Window;
			this.Label2.Text = "Assign User For Popup";
			this.Label2.Location = new System.Drawing.Point(4, 82);
			// this.Label2.mLabelId = 2080;
			this.Label2.Name = "System.Windows.Forms.Label2";
			this.Label2.Size = new System.Drawing.Size(112, 14);
			this.Label2.TabIndex = 3;
			// 
			// txtPopupTypeCdName
			// 
			this.txtPopupTypeCdName.AllowDrop = true;
			this.txtPopupTypeCdName.BackColor = System.Drawing.SystemColors.Window;
			this.txtPopupTypeCdName.Enabled = false;
			this.txtPopupTypeCdName.Location = new System.Drawing.Point(205, 44);
			this.txtPopupTypeCdName.Name = "txtPopupTypeCdName";
			this.txtPopupTypeCdName.Size = new System.Drawing.Size(253, 19);
			this.txtPopupTypeCdName.TabIndex = 2;
			// 
			// txtPopupTypeCd
			// 
			this.txtPopupTypeCd.AllowDrop = true;
			this.txtPopupTypeCd.BackColor = System.Drawing.Color.White;
			// this.txtPopupTypeCd.bolAllowDecimal = false;
			this.txtPopupTypeCd.ForeColor = System.Drawing.Color.Black;
			this.txtPopupTypeCd.Location = new System.Drawing.Point(76, 44);
			// this.txtPopupTypeCd.mDropDownType = (System.Windows.Forms.TextBox.DropDownTypes) 0;
			this.txtPopupTypeCd.Name = "txtPopupTypeCd";
			// this.txtPopupTypeCd.ShowButton = true;
			this.txtPopupTypeCd.Size = new System.Drawing.Size(127, 19);
			this.txtPopupTypeCd.TabIndex = 1;
			this.txtPopupTypeCd.Text = "";
			// this.this.txtPopupTypeCd.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtPopupTypeCd_DropButtonClick);
			// this.txtPopupTypeCd.Leave += new System.EventHandler(this.txtPopupTypeCd_Leave);
			// 
			// grdVoucherDetails
			// 
			this.grdVoucherDetails.AllowDrop = true;
			this.grdVoucherDetails.BackColor = System.Drawing.Color.Silver;
			this.grdVoucherDetails.CellTipsWidth = 0;
			this.grdVoucherDetails.Location = new System.Drawing.Point(0, 106);
			this.grdVoucherDetails.Name = "grdVoucherDetails";
			this.grdVoucherDetails.RowDivider.Color = System.Drawing.Color.Silver;
			this.grdVoucherDetails.Size = new System.Drawing.Size(567, 332);
			this.grdVoucherDetails.TabIndex = 0;
			this.grdVoucherDetails.Columns.Add(this.Column_0_grdVoucherDetails);
			this.grdVoucherDetails.Columns.Add(this.Column_1_grdVoucherDetails);
			// this.this.grdVoucherDetails.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.grdVoucherDetails_KeyPress);
			this.grdVoucherDetails.MouseUp += new System.Windows.Forms.MouseEventHandler(this.grdVoucherDetails_MouseUp);
			// 
			// Column_0_grdVoucherDetails
			// 
			this.Column_0_grdVoucherDetails.DataField = "";
			this.Column_0_grdVoucherDetails.ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.Normal;
			// 
			// Column_1_grdVoucherDetails
			// 
			this.Column_1_grdVoucherDetails.DataField = "";
			this.Column_1_grdVoucherDetails.ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.Normal;
			// 
			// tcbSystemForm
			// 
			this.tcbSystemForm.AllowDrop = true;
			this.tcbSystemForm.Location = new System.Drawing.Point(60, 2);
			this.tcbSystemForm.Name = "tcbSystemForm";
			("tcbSystemForm.OcxState");
			// 
			// Line1
			// 
			this.Line1.AllowDrop = true;
			this.Line1.BackColor = System.Drawing.Color.Red;
			this.Line1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Line1.Enabled = false;
			this.Line1.ForeColor = System.Drawing.Color.Black;
			this.Line1.Location = new System.Drawing.Point(0, 100);
			this.Line1.Name = "Line1";
			this.Line1.Size = new System.Drawing.Size(567, 1);
			this.Line1.Text = "Line1";
			this.Line1.Visible = true;
			// 
			// frmSysPopupUserAssign
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(569, 442);
			this.Controls.Add(this.Label1_2079);
			this.Controls.Add(this.Label2);
			this.Controls.Add(this.txtPopupTypeCdName);
			this.Controls.Add(this.txtPopupTypeCd);
			this.Controls.Add(this.grdVoucherDetails);
			this.Controls.Add(this.tcbSystemForm);
			this.Controls.Add(this.Line1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			//this.Icon = (System.Drawing.Icon) resources.GetObject("frmSysPopupUserAssign.Icon");
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(27, 282);
			this.MaximizeBox = false;
			this.MinimizeBox = true;
			this.Name = "frmSysPopupUserAssign";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "User Assign";
			// this.Activated += new System.EventHandler(this.frmSysPopupUserAssign_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
			// this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
			//((System.ComponentModel.ISupportInitialize) this.tcbSystemForm).EndInit();
			this.grdVoucherDetails.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		void ReLoadForm(bool addEvents)
		{
			InitializeSystem.Windows.Forms.Label1();
			//This form is an MDI child.
			//This code simulates the VB6 
			// functionality of automatically
			// loading and showing an MDI
			// child's parent.
			this.MdiParent = Xtreme.frmSysMain.DefInstance;
			Xtreme.frmSysMain.DefInstance.Show();
		}
		void InitializeSystem.Windows.Forms.Label1()
		{
			this.Label1 = new System.Windows.Forms.Label[2080];
			this.Label1[2079] = Label1_2079;
		}
		#endregion
	}
}//ENDSHERE
