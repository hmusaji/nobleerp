
namespace Xtreme
{
	partial class frmPayLeaveAmount
	{

		#region "Upgrade Support "
		private static frmPayLeaveAmount m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmPayLeaveAmount DefInstance
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
		public static frmPayLeaveAmount CreateInstance()
		{
			frmPayLeaveAmount theInstance = new frmPayLeaveAmount();
			
			return theInstance;
		}
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "Column_0_grdLeaveAmountDetails", "Column_1_grdLeaveAmountDetails", "grdLeaveAmountDetails", "frmLeaveAmount", "_txtCommonNumber_2", "_lblCommonLabel_8", "cmdOKCancel", "lblCommonLabel", "txtCommonNumber"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_0_grdLeaveAmountDetails;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_1_grdLeaveAmountDetails;
		public C1.Win.C1TrueDBGrid.C1TrueDBGrid grdLeaveAmountDetails;
		public System.Windows.Forms.GroupBox frmLeaveAmount;
		private System.Windows.Forms.TextBox _txtCommonNumber_2;
		private System.Windows.Forms.Label _lblCommonLabel_8;
		public UCOkCancel cmdOKCancel;
		public System.Windows.Forms.Label[] lblCommonLabel = new System.Windows.Forms.Label[9];
		public System.Windows.Forms.TextBox[] txtCommonNumber = new System.Windows.Forms.TextBox[3];
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPayLeaveAmount));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this.frmLeaveAmount = new System.Windows.Forms.GroupBox();
			this.grdLeaveAmountDetails = new C1.Win.C1TrueDBGrid.C1TrueDBGrid();
			this.Column_0_grdLeaveAmountDetails = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.Column_1_grdLeaveAmountDetails = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this._txtCommonNumber_2 = new System.Windows.Forms.TextBox();
			this._lblCommonLabel_8 = new System.Windows.Forms.Label();
			this.cmdOKCancel = new UCOkCancel();
			this.frmLeaveAmount.SuspendLayout();
			this.grdLeaveAmountDetails.SuspendLayout();
			this.SuspendLayout();
			// 
			// frmLeaveAmount
			// 
			this.frmLeaveAmount.AllowDrop = true;
			this.frmLeaveAmount.BackColor = System.Drawing.SystemColors.Window;
			this.frmLeaveAmount.Controls.Add(this.grdLeaveAmountDetails);
			this.frmLeaveAmount.Enabled = true;
			this.frmLeaveAmount.ForeColor = System.Drawing.SystemColors.WindowText;
			this.frmLeaveAmount.Location = new System.Drawing.Point(4, 34);
			this.frmLeaveAmount.Name = "frmLeaveAmount";
			this.frmLeaveAmount.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.frmLeaveAmount.Size = new System.Drawing.Size(545, 211);
			this.frmLeaveAmount.TabIndex = 0;
			this.frmLeaveAmount.Visible = true;
			// 
			// grdLeaveAmountDetails
			// 
			this.grdLeaveAmountDetails.AllowDrop = true;
			this.grdLeaveAmountDetails.BackColor = System.Drawing.Color.FromArgb(212, 208, 200);
			this.grdLeaveAmountDetails.CellTipsWidth = 0;
			this.grdLeaveAmountDetails.Location = new System.Drawing.Point(2, 8);
			this.grdLeaveAmountDetails.Name = "grdLeaveAmountDetails";
			this.grdLeaveAmountDetails.RowDivider.Color = System.Drawing.Color.FromArgb(212, 208, 200);
			this.grdLeaveAmountDetails.Size = new System.Drawing.Size(539, 199);
			this.grdLeaveAmountDetails.TabIndex = 1;
			this.grdLeaveAmountDetails.Columns.Add(this.Column_0_grdLeaveAmountDetails);
			this.grdLeaveAmountDetails.Columns.Add(this.Column_1_grdLeaveAmountDetails);
			this.grdLeaveAmountDetails.AfterColUpdate += new C1.Win.C1TrueDBGrid.ColEventHandler(this.grdLeaveAmountDetails_AfterColUpdate);
			// 
			// Column_0_grdLeaveAmountDetails
			// 
			this.Column_0_grdLeaveAmountDetails.DataField = "";
			this.Column_0_grdLeaveAmountDetails.ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.Normal;
			// 
			// Column_1_grdLeaveAmountDetails
			// 
			this.Column_1_grdLeaveAmountDetails.DataField = "";
			this.Column_1_grdLeaveAmountDetails.ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.Normal;
			// 
			// _txtCommonNumber_2
			// 
			this._txtCommonNumber_2.AllowDrop = true;
			this._txtCommonNumber_2.BackColor = System.Drawing.Color.FromArgb(239, 239, 239);
			// this._txtCommonNumber_2.DisplayFormat = "####0.000###;;0.000;0.000";
			this._txtCommonNumber_2.Enabled = false;
			// this._txtCommonNumber_2.Format = "###########0.000";
			this._txtCommonNumber_2.Location = new System.Drawing.Point(66, 8);
			// this._txtCommonNumber_2.MaxValue = 2147483647;
			// this._txtCommonNumber_2.MinValue = 0;
			this._txtCommonNumber_2.Name = "_txtCommonNumber_2";
			this._txtCommonNumber_2.Size = new System.Drawing.Size(101, 19);
			this._txtCommonNumber_2.TabIndex = 2;
			this._txtCommonNumber_2.TabStop = false;
			this._txtCommonNumber_2.Text = "0.000";
			// 
			// _lblCommonLabel_8
			// 
			this._lblCommonLabel_8.AllowDrop = true;
			this._lblCommonLabel_8.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_8.Text = "Paid Days";
			this._lblCommonLabel_8.Location = new System.Drawing.Point(6, 10);
			// this._lblCommonLabel_8.mLabelId = 1925;
			this._lblCommonLabel_8.Name = "_lblCommonLabel_8";
			this._lblCommonLabel_8.Size = new System.Drawing.Size(48, 14);
			this._lblCommonLabel_8.TabIndex = 3;
			// 
			// cmdOKCancel
			// 
			this.cmdOKCancel.AllowDrop = true;
			this.cmdOKCancel.DisplayButton = 0;
			this.cmdOKCancel.Location = new System.Drawing.Point(154, 252);
			this.cmdOKCancel.Name = "cmdOKCancel";
			this.cmdOKCancel.OkCaption = "&Ok";
			this.cmdOKCancel.Size = new System.Drawing.Size(206, 31);
			this.cmdOKCancel.TabIndex = 4;
			this.cmdOKCancel.CancelClick += new UCOkCancel.CancelClickHandler(this.cmdOKCancel_CancelClick);
			this.cmdOKCancel.OKClick += new UCOkCancel.OKClickHandler(this.cmdOKCancel_OKClick);
			// 
			// frmPayLeaveAmount
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.ClientSize = new System.Drawing.Size(548, 289);
			this.ControlBox = false;
			this.Controls.Add(this.frmLeaveAmount);
			this.Controls.Add(this._txtCommonNumber_2);
			this.Controls.Add(this._lblCommonLabel_8);
			this.Controls.Add(this.cmdOKCancel);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			//this.Icon = (System.Drawing.Icon) resources.GetObject("frmPayLeaveAmount.Icon");
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(258, 195);
			this.MaximizeBox = true;
			this.MinimizeBox = false;
			this.Name = "frmPayLeaveAmount";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Text = "Leave Amount";
			// this.Activated += new System.EventHandler(this.frmPayLeaveAmount_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
			this.frmLeaveAmount.ResumeLayout(false);
			this.grdLeaveAmountDetails.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		void ReLoadForm(bool addEvents)
		{
			InitializetxtCommonNumber();
			InitializelblCommonLabel();
		}
		void InitializetxtCommonNumber()
		{
			this.txtCommonNumber = new System.Windows.Forms.TextBox[3];
			this.txtCommonNumber[2] = _txtCommonNumber_2;
		}
		void InitializelblCommonLabel()
		{
			this.lblCommonLabel = new System.Windows.Forms.Label[9];
			this.lblCommonLabel[8] = _lblCommonLabel_8;
		}
		#endregion
	}
}