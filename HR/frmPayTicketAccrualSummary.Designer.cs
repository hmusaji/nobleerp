
namespace Xtreme
{
	partial class frmPayTicketAccrualSummary
	{

		#region "Upgrade Support "
		private static frmPayTicketAccrualSummary m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmPayTicketAccrualSummary DefInstance
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
		public static frmPayTicketAccrualSummary CreateInstance()
		{
			frmPayTicketAccrualSummary theInstance = new frmPayTicketAccrualSummary();
			
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
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "lblSystemComponents", "_lblCommonLabel_2", "_lblCommonLabel_9", "_txtDisplayLabel_5", "_txtDisplayLabel_0", "_txtDisplayLabel_1", "Column_0_grdVoucherDetails", "Column_1_grdVoucherDetails", "grdVoucherDetails", "Line1", "lblCommonLabel", "txtDisplayLabel"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public System.Windows.Forms.Label lblSystemComponents;
		private System.Windows.Forms.Label _lblCommonLabel_2;
		private System.Windows.Forms.Label _lblCommonLabel_9;
		private System.Windows.Forms.Label _txtDisplayLabel_5;
		private System.Windows.Forms.Label _txtDisplayLabel_0;
		private System.Windows.Forms.Label _txtDisplayLabel_1;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_0_grdVoucherDetails;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_1_grdVoucherDetails;
		public C1.Win.C1TrueDBGrid.C1TrueDBGrid grdVoucherDetails;
		public System.Windows.Forms.Label Line1;
		public System.Windows.Forms.Label[] lblCommonLabel = new System.Windows.Forms.Label[10];
		public System.Windows.Forms.Label[] txtDisplayLabel = new System.Windows.Forms.Label[6];
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPayTicketAccrualSummary));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this.lblSystemComponents = new System.Windows.Forms.Label();
			this._lblCommonLabel_2 = new System.Windows.Forms.Label();
			this._lblCommonLabel_9 = new System.Windows.Forms.Label();
			this._txtDisplayLabel_5 = new System.Windows.Forms.Label();
			this._txtDisplayLabel_0 = new System.Windows.Forms.Label();
			this._txtDisplayLabel_1 = new System.Windows.Forms.Label();
			this.grdVoucherDetails = new C1.Win.C1TrueDBGrid.C1TrueDBGrid();
			this.Column_0_grdVoucherDetails = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.Column_1_grdVoucherDetails = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.Line1 = new System.Windows.Forms.Label();
			//this.grdVoucherDetails.SuspendLayout();
			this.SuspendLayout();
			// 
			// lblSystemComponents
			// 
			//this.lblSystemComponents.AllowDrop = true;
			this.lblSystemComponents.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblSystemComponents.Text = " Indemnity Information ";
			this.lblSystemComponents.Location = new System.Drawing.Point(15, 88);
			this.lblSystemComponents.Name = "lblSystemComponents";
			this.lblSystemComponents.Size = new System.Drawing.Size(109, 13);
			this.lblSystemComponents.TabIndex = 0;
			// 
			// _lblCommonLabel_2
			// 
			//this._lblCommonLabel_2.AllowDrop = true;
			this._lblCommonLabel_2.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_2.Text = "Employee Code";
			this._lblCommonLabel_2.Location = new System.Drawing.Point(9, 52);
			// // this._lblCommonLabel_2.mLabelId = 236;
			this._lblCommonLabel_2.Name = "_lblCommonLabel_2";
			this._lblCommonLabel_2.Size = new System.Drawing.Size(74, 14);
			this._lblCommonLabel_2.TabIndex = 1;
			// 
			// _lblCommonLabel_9
			// 
			//this._lblCommonLabel_9.AllowDrop = true;
			this._lblCommonLabel_9.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_9.Text = "Leave Salary";
			this._lblCommonLabel_9.Location = new System.Drawing.Point(451, 52);
			// // this._lblCommonLabel_9.mLabelId = 1135;
			this._lblCommonLabel_9.Name = "_lblCommonLabel_9";
			this._lblCommonLabel_9.Size = new System.Drawing.Size(68, 14);
			this._lblCommonLabel_9.TabIndex = 2;
			this._lblCommonLabel_9.Visible = false;
			// 
			// _txtDisplayLabel_5
			// 
			// //this._txtDisplayLabel_5.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
			//this._txtDisplayLabel_5.AllowDrop = true;
			this._txtDisplayLabel_5.Location = new System.Drawing.Point(527, 50);
			this._txtDisplayLabel_5.Name = "_txtDisplayLabel_5";
			this._txtDisplayLabel_5.Size = new System.Drawing.Size(101, 19);
			this._txtDisplayLabel_5.TabIndex = 3;
			this._txtDisplayLabel_5.Visible = false;
			// 
			// _txtDisplayLabel_0
			// 
			//this._txtDisplayLabel_0.AllowDrop = true;
			this._txtDisplayLabel_0.Location = new System.Drawing.Point(101, 50);
			this._txtDisplayLabel_0.Name = "_txtDisplayLabel_0";
			this._txtDisplayLabel_0.Size = new System.Drawing.Size(101, 19);
			this._txtDisplayLabel_0.TabIndex = 4;
			// 
			// _txtDisplayLabel_1
			// 
			//this._txtDisplayLabel_1.AllowDrop = true;
			this._txtDisplayLabel_1.Location = new System.Drawing.Point(204, 50);
			this._txtDisplayLabel_1.Name = "_txtDisplayLabel_1";
			this._txtDisplayLabel_1.Size = new System.Drawing.Size(201, 19);
			this._txtDisplayLabel_1.TabIndex = 5;
			// 
			// grdVoucherDetails
			// 
			//this.grdVoucherDetails.AllowDrop = true;
			this.grdVoucherDetails.BackColor = System.Drawing.Color.Silver;
			this.grdVoucherDetails.CellTipsWidth = 0;
			this.grdVoucherDetails.Location = new System.Drawing.Point(5, 111);
			this.grdVoucherDetails.Name = "grdVoucherDetails";
			this.grdVoucherDetails.RowDivider.Color = System.Drawing.Color.Silver;
			this.grdVoucherDetails.Size = new System.Drawing.Size(623, 233);
			this.grdVoucherDetails.TabIndex = 6;
			this.grdVoucherDetails.Columns.Add(this.Column_0_grdVoucherDetails);
			this.grdVoucherDetails.Columns.Add(this.Column_1_grdVoucherDetails);
			//this.grdVoucherDetails.AfterColUpdate += new C1.Win.C1TrueDBGrid.ColEventHandler(this.grdVoucherDetails_AfterColUpdate);
			//this.grdVoucherDetails.RowColChange += new C1.Win.C1TrueDBGrid.RowColChangeEventHandler(this.grdVoucherDetails_RowColChange);
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
			// Line1
			// 
			//this.Line1.AllowDrop = true;
			this.Line1.BackColor = System.Drawing.SystemColors.WindowText;
			this.Line1.Enabled = false;
			this.Line1.Location = new System.Drawing.Point(0, 94);
			this.Line1.Name = "Line1";
			this.Line1.Size = new System.Drawing.Size(627, 1);
			this.Line1.Visible = true;
			// 
			// frmPayTicketAccrualSummary
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.ClientSize = new System.Drawing.Size(631, 345);
			this.Controls.Add(this.lblSystemComponents);
			this.Controls.Add(this._lblCommonLabel_2);
			this.Controls.Add(this._lblCommonLabel_9);
			this.Controls.Add(this._txtDisplayLabel_5);
			this.Controls.Add(this._txtDisplayLabel_0);
			this.Controls.Add(this._txtDisplayLabel_1);
			this.Controls.Add(this.grdVoucherDetails);
			this.Controls.Add(this.Line1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			//this.Icon = (System.Drawing.Icon) resources.GetObject("frmPayTicketAccrualSummary.Icon");
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(129, 163);
			this.MaximizeBox = true;
			this.MinimizeBox = true;
			this.Name = "frmPayTicketAccrualSummary";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Ticket Accrual Summary";
			// this.Activated += new System.EventHandler(this.frmPayTicketAccrualSummary_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
			// this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
			this.grdVoucherDetails.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		// 
		void InitializetxtDisplayLabel()
		{
			this.txtDisplayLabel = new System.Windows.Forms.Label[6];
			this.txtDisplayLabel[5] = _txtDisplayLabel_5;
			this.txtDisplayLabel[0] = _txtDisplayLabel_0;
			this.txtDisplayLabel[1] = _txtDisplayLabel_1;
		}
		void InitializelblCommonLabel()
		{
			this.lblCommonLabel = new System.Windows.Forms.Label[10];
			this.lblCommonLabel[2] = _lblCommonLabel_2;
			this.lblCommonLabel[9] = _lblCommonLabel_9;
		}
		#endregion
	}
}//ENDSHERE
