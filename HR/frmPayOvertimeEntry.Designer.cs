
namespace Xtreme
{
	partial class frmPayOvertimeEntry
	{

		#region "Upgrade Support "
		private static frmPayOvertimeEntry m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmPayOvertimeEntry DefInstance
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
		public static frmPayOvertimeEntry CreateInstance()
		{
			frmPayOvertimeEntry theInstance = new frmPayOvertimeEntry();
			
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
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "_lblCommonLabel_2", "_txtDisplayLabel_1", "txtEmployeeCode", "_lblCommonLabel_4", "_txtDisplayLabel_2", "_lblCommonLabel_0", "_txtDisplayLabel_3", "Column_0_grdVoucherDetails", "Column_1_grdVoucherDetails", "grdVoucherDetails", "Line1", "lblCommonLabel", "txtDisplayLabel"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		private System.Windows.Forms.Label _lblCommonLabel_2;
		private System.Windows.Forms.Label _txtDisplayLabel_1;
		public System.Windows.Forms.TextBox txtEmployeeCode;
		private System.Windows.Forms.Label _lblCommonLabel_4;
		private System.Windows.Forms.Label _txtDisplayLabel_2;
		private System.Windows.Forms.Label _lblCommonLabel_0;
		private System.Windows.Forms.Label _txtDisplayLabel_3;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_0_grdVoucherDetails;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_1_grdVoucherDetails;
		public C1.Win.C1TrueDBGrid.C1TrueDBGrid grdVoucherDetails;
		public System.Windows.Forms.Label Line1;
		public System.Windows.Forms.Label[] lblCommonLabel = new System.Windows.Forms.Label[5];
		public System.Windows.Forms.Label[] txtDisplayLabel = new System.Windows.Forms.Label[4];
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPayOvertimeEntry));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this._lblCommonLabel_2 = new System.Windows.Forms.Label();
			this._txtDisplayLabel_1 = new System.Windows.Forms.Label();
			this.txtEmployeeCode = new System.Windows.Forms.TextBox();
			this._lblCommonLabel_4 = new System.Windows.Forms.Label();
			this._txtDisplayLabel_2 = new System.Windows.Forms.Label();
			this._lblCommonLabel_0 = new System.Windows.Forms.Label();
			this._txtDisplayLabel_3 = new System.Windows.Forms.Label();
			this.grdVoucherDetails = new C1.Win.C1TrueDBGrid.C1TrueDBGrid();
			this.Column_0_grdVoucherDetails = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.Column_1_grdVoucherDetails = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.Line1 = new System.Windows.Forms.Label();
			//this.grdVoucherDetails.SuspendLayout();
			this.SuspendLayout();
			// 
			// _lblCommonLabel_2
			// 
			//this._lblCommonLabel_2.AllowDrop = true;
			this._lblCommonLabel_2.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_2.Text = "Employee Code";
			this._lblCommonLabel_2.Location = new System.Drawing.Point(6, 56);
			// // this._lblCommonLabel_2.mLabelId = 236;
			this._lblCommonLabel_2.Name = "_lblCommonLabel_2";
			this._lblCommonLabel_2.Size = new System.Drawing.Size(74, 14);
			this._lblCommonLabel_2.TabIndex = 0;
			// 
			// _txtDisplayLabel_1
			// 
			//this._txtDisplayLabel_1.AllowDrop = true;
			this._txtDisplayLabel_1.Location = new System.Drawing.Point(195, 54);
			this._txtDisplayLabel_1.Name = "_txtDisplayLabel_1";
			this._txtDisplayLabel_1.Size = new System.Drawing.Size(243, 19);
			this._txtDisplayLabel_1.TabIndex = 1;
			this._txtDisplayLabel_1.TabStop = false;
			// 
			// txtEmployeeCode
			// 
			//this.txtEmployeeCode.AllowDrop = true;
			this.txtEmployeeCode.BackColor = System.Drawing.Color.White;
			// // = false;
			this.txtEmployeeCode.ForeColor = System.Drawing.Color.Black;
			this.txtEmployeeCode.Location = new System.Drawing.Point(88, 54);
			// // = (System.Windows.Forms.TextBox.DropDownTypes) 0;
			this.txtEmployeeCode.Name = "txtEmployeeCode";
			// this.txtEmployeeCode.ShowButton = true;
			this.txtEmployeeCode.Size = new System.Drawing.Size(105, 19);
			this.txtEmployeeCode.TabIndex = 2;
			this.txtEmployeeCode.Text = "";
			// this.//this.txtEmployeeCode.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(//this.txtEmployeeCode_DropButtonClick);
			// this.txtEmployeeCode.Leave += new System.EventHandler(this.txtEmployeeCode_Leave);
			// 
			// _lblCommonLabel_4
			// 
			//this._lblCommonLabel_4.AllowDrop = true;
			this._lblCommonLabel_4.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_4.Text = "Basic Salary";
			this._lblCommonLabel_4.Location = new System.Drawing.Point(6, 77);
			// // this._lblCommonLabel_4.mLabelId = 1970;
			this._lblCommonLabel_4.Name = "_lblCommonLabel_4";
			this._lblCommonLabel_4.Size = new System.Drawing.Size(61, 14);
			this._lblCommonLabel_4.TabIndex = 3;
			// 
			// _txtDisplayLabel_2
			// 
			//this._txtDisplayLabel_2.AllowDrop = true;
			this._txtDisplayLabel_2.Location = new System.Drawing.Point(88, 75);
			this._txtDisplayLabel_2.Name = "_txtDisplayLabel_2";
			this._txtDisplayLabel_2.Size = new System.Drawing.Size(77, 19);
			this._txtDisplayLabel_2.TabIndex = 4;
			this._txtDisplayLabel_2.TabStop = false;
			// 
			// _lblCommonLabel_0
			// 
			//this._lblCommonLabel_0.AllowDrop = true;
			this._lblCommonLabel_0.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_0.Text = "Total Salary";
			this._lblCommonLabel_0.Location = new System.Drawing.Point(6, 98);
			// // this._lblCommonLabel_0.mLabelId = 818;
			this._lblCommonLabel_0.Name = "_lblCommonLabel_0";
			this._lblCommonLabel_0.Size = new System.Drawing.Size(57, 14);
			this._lblCommonLabel_0.TabIndex = 5;
			// 
			// _txtDisplayLabel_3
			// 
			//this._txtDisplayLabel_3.AllowDrop = true;
			this._txtDisplayLabel_3.Location = new System.Drawing.Point(88, 96);
			this._txtDisplayLabel_3.Name = "_txtDisplayLabel_3";
			this._txtDisplayLabel_3.Size = new System.Drawing.Size(77, 19);
			this._txtDisplayLabel_3.TabIndex = 6;
			this._txtDisplayLabel_3.TabStop = false;
			// 
			// grdVoucherDetails
			// 
			//this.grdVoucherDetails.AllowDrop = true;
			this.grdVoucherDetails.BackColor = System.Drawing.Color.Silver;
			this.grdVoucherDetails.CellTipsWidth = 0;
			this.grdVoucherDetails.Location = new System.Drawing.Point(0, 134);
			this.grdVoucherDetails.Name = "grdVoucherDetails";
			this.grdVoucherDetails.RowDivider.Color = System.Drawing.Color.Silver;
			this.grdVoucherDetails.Size = new System.Drawing.Size(517, 525);
			this.grdVoucherDetails.TabIndex = 7;
			this.grdVoucherDetails.Columns.Add(this.Column_0_grdVoucherDetails);
			this.grdVoucherDetails.Columns.Add(this.Column_1_grdVoucherDetails);
			//this.grdVoucherDetails.AfterColUpdate += new C1.Win.C1TrueDBGrid.ColEventHandler(this.grdVoucherDetails_AfterColUpdate);
			//this.grdVoucherDetails.BeforeColUpdate += new C1.Win.C1TrueDBGrid.BeforeColUpdateEventHandler(this.grdVoucherDetails_BeforeColUpdate);
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
			this.Line1.Location = new System.Drawing.Point(0, 124);
			this.Line1.Name = "Line1";
			this.Line1.Size = new System.Drawing.Size(517, 1);
			this.Line1.Visible = true;
			// 
			// frmPayOvertimeEntry
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.ClientSize = new System.Drawing.Size(519, 657);
			this.Controls.Add(this._lblCommonLabel_2);
			this.Controls.Add(this._txtDisplayLabel_1);
			this.Controls.Add(this.txtEmployeeCode);
			this.Controls.Add(this._lblCommonLabel_4);
			this.Controls.Add(this._txtDisplayLabel_2);
			this.Controls.Add(this._lblCommonLabel_0);
			this.Controls.Add(this._txtDisplayLabel_3);
			this.Controls.Add(this.grdVoucherDetails);
			this.Controls.Add(this.Line1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			//this.Icon = (System.Drawing.Icon) resources.GetObject("frmPayOvertimeEntry.Icon");
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(209, 128);
			this.MaximizeBox = true;
			this.MinimizeBox = true;
			this.Name = "frmPayOvertimeEntry";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Overtime Entry";
			// this.Activated += new System.EventHandler(this.Form_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
			// this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
			this.grdVoucherDetails.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		// 
		void InitializetxtDisplayLabel()
		{
			this.txtDisplayLabel = new System.Windows.Forms.Label[4];
			this.txtDisplayLabel[1] = _txtDisplayLabel_1;
			this.txtDisplayLabel[2] = _txtDisplayLabel_2;
			this.txtDisplayLabel[3] = _txtDisplayLabel_3;
		}
		void InitializelblCommonLabel()
		{
			this.lblCommonLabel = new System.Windows.Forms.Label[5];
			this.lblCommonLabel[2] = _lblCommonLabel_2;
			this.lblCommonLabel[4] = _lblCommonLabel_4;
			this.lblCommonLabel[0] = _lblCommonLabel_0;
		}
		#endregion
	}
}//ENDSHERE
