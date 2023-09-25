
namespace Xtreme
{
	partial class frmICSComparisionSheet
	{

		#region "Upgrade Support "
		private static frmICSComparisionSheet m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmICSComparisionSheet DefInstance
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
		public static frmICSComparisionSheet CreateInstance()
		{
			frmICSComparisionSheet theInstance = new frmICSComparisionSheet();
			
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
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "Column_0_cmbMasterList", "Column_1_cmbMasterList", "cmbMasterList", "Column_0_grdComparisionDetails", "Column_1_grdComparisionDetails", "grdComparisionDetails", "_lblCommonLabel_21", "_lblCommonLabel_0", "_lblCommonLabel_1", "txtComments", "txtVoucherDate", "txtTransactionNo", "_lblCommonLabel_4", "_lblCommonLabel_2", "Line1", "Shape1", "tcbSystemForm", "lblCommonLabel"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_0_cmbMasterList;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_1_cmbMasterList;
		public C1.Win.C1TrueDBGrid.C1TrueDBDropdown cmbMasterList;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_0_grdComparisionDetails;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_1_grdComparisionDetails;
		public C1.Win.C1TrueDBGrid.C1TrueDBGrid grdComparisionDetails;
		private System.Windows.Forms.Label _lblCommonLabel_21;
		private System.Windows.Forms.Label _lblCommonLabel_0;
		private System.Windows.Forms.Label _lblCommonLabel_1;
		public System.Windows.Forms.TextBox txtComments;
		public Syncfusion.WinForms.Input.SfDateTimeEdit txtVoucherDate;
		public System.Windows.Forms.TextBox txtTransactionNo;
		private System.Windows.Forms.Label _lblCommonLabel_4;
		private System.Windows.Forms.Label _lblCommonLabel_2;
		public System.Windows.Forms.Label Line1;
		public UpgradeHelpers.Gui.ShapeHelper Shape1;
		public Syncfusion.Windows.Forms.Tools.CommandBarController tcbSystemForm;
		public System.Windows.Forms.Label[] lblCommonLabel = new System.Windows.Forms.Label[22];
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmICSComparisionSheet));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this.cmbMasterList = new C1.Win.C1TrueDBGrid.C1TrueDBDropdown();
			this.Column_0_cmbMasterList = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.Column_1_cmbMasterList = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.grdComparisionDetails = new C1.Win.C1TrueDBGrid.C1TrueDBGrid();
			this.Column_0_grdComparisionDetails = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.Column_1_grdComparisionDetails = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this._lblCommonLabel_21 = new System.Windows.Forms.Label();
			this._lblCommonLabel_0 = new System.Windows.Forms.Label();
			this._lblCommonLabel_1 = new System.Windows.Forms.Label();
			this.txtComments = new System.Windows.Forms.TextBox();
			this.txtVoucherDate = new Syncfusion.WinForms.Input.SfDateTimeEdit();
			this.txtTransactionNo = new System.Windows.Forms.TextBox();
			this._lblCommonLabel_4 = new System.Windows.Forms.Label();
			this._lblCommonLabel_2 = new System.Windows.Forms.Label();
			this.Line1 = new System.Windows.Forms.Label();
			this.Shape1 = new UpgradeHelpers.Gui.ShapeHelper();
			this.tcbSystemForm = new Syncfusion.Windows.Forms.Tools.CommandBarController();
			// //((System.ComponentModel.ISupportInitialize) this.tcbSystemForm).BeginInit();
			this.cmbMasterList.SuspendLayout();
			this.grdComparisionDetails.SuspendLayout();
			this.SuspendLayout();
			// 
			// cmbMasterList
			// 
			this.cmbMasterList.AllowDrop = true;
			this.cmbMasterList.ColumnHeaders = true;
			this.cmbMasterList.Enabled = true;
			this.cmbMasterList.Location = new System.Drawing.Point(160, 193);
			this.cmbMasterList.Name = "cmbMasterList";
			this.cmbMasterList.Size = new System.Drawing.Size(241, 53);
			this.cmbMasterList.TabIndex = 1;
			this.cmbMasterList.TabStop = false;
			this.cmbMasterList.Columns.Add(this.Column_0_cmbMasterList);
			this.cmbMasterList.Columns.Add(this.Column_1_cmbMasterList);
			// 
			// Column_0_cmbMasterList
			// 
			this.Column_0_cmbMasterList.DataField = "";
			this.Column_0_cmbMasterList.ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.Normal;
			// 
			// Column_1_cmbMasterList
			// 
			this.Column_1_cmbMasterList.DataField = "";
			this.Column_1_cmbMasterList.ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.Normal;
			// 
			// grdComparisionDetails
			// 
			this.grdComparisionDetails.AllowDrop = true;
			this.grdComparisionDetails.BackColor = System.Drawing.Color.Silver;
			this.grdComparisionDetails.CellTipsWidth = 0;
			this.grdComparisionDetails.Location = new System.Drawing.Point(0, 156);
			this.grdComparisionDetails.Name = "grdComparisionDetails";
			this.grdComparisionDetails.RowDivider.Color = System.Drawing.Color.Silver;
			this.grdComparisionDetails.Size = new System.Drawing.Size(758, 181);
			this.grdComparisionDetails.TabIndex = 0;
			this.grdComparisionDetails.Columns.Add(this.Column_0_grdComparisionDetails);
			this.grdComparisionDetails.Columns.Add(this.Column_1_grdComparisionDetails);
			this.grdComparisionDetails.AfterColUpdate += new C1.Win.C1TrueDBGrid.ColEventHandler(this.grdComparisionDetails_AfterColUpdate);
			this.grdComparisionDetails.GotFocus += new System.EventHandler(this.grdComparisionDetails_GotFocus);
			this.grdComparisionDetails.RowColChange += new C1.Win.C1TrueDBGrid.RowColChangeEventHandler(this.grdComparisionDetails_RowColChange);
			// 
			// Column_0_grdComparisionDetails
			// 
			this.Column_0_grdComparisionDetails.DataField = "";
			this.Column_0_grdComparisionDetails.ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.Normal;
			// 
			// Column_1_grdComparisionDetails
			// 
			this.Column_1_grdComparisionDetails.DataField = "";
			this.Column_1_grdComparisionDetails.ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.Normal;
			// 
			// _lblCommonLabel_21
			// 
			this._lblCommonLabel_21.AllowDrop = true;
			this._lblCommonLabel_21.BackColor = System.Drawing.SystemColors.Window;
			this._lblCommonLabel_21.Text = "Transaction No.";
			this._lblCommonLabel_21.ForeColor = System.Drawing.Color.Black;
			this._lblCommonLabel_21.Location = new System.Drawing.Point(18, 59);
			this._lblCommonLabel_21.Name = "_lblCommonLabel_21";
			this._lblCommonLabel_21.Size = new System.Drawing.Size(76, 14);
			this._lblCommonLabel_21.TabIndex = 2;
			// 
			// _lblCommonLabel_0
			// 
			this._lblCommonLabel_0.AllowDrop = true;
			this._lblCommonLabel_0.BackColor = System.Drawing.SystemColors.Window;
			this._lblCommonLabel_0.Text = "Comments";
			this._lblCommonLabel_0.ForeColor = System.Drawing.Color.Black;
			this._lblCommonLabel_0.Location = new System.Drawing.Point(18, 101);
			this._lblCommonLabel_0.Name = "_lblCommonLabel_0";
			this._lblCommonLabel_0.Size = new System.Drawing.Size(50, 14);
			this._lblCommonLabel_0.TabIndex = 3;
			// 
			// _lblCommonLabel_1
			// 
			this._lblCommonLabel_1.AllowDrop = true;
			this._lblCommonLabel_1.BackColor = System.Drawing.SystemColors.Window;
			this._lblCommonLabel_1.Text = "Transaction Date";
			this._lblCommonLabel_1.ForeColor = System.Drawing.Color.Black;
			this._lblCommonLabel_1.Location = new System.Drawing.Point(18, 80);
			this._lblCommonLabel_1.Name = "_lblCommonLabel_1";
			this._lblCommonLabel_1.Size = new System.Drawing.Size(82, 14);
			this._lblCommonLabel_1.TabIndex = 4;
			// 
			// txtComments
			// 
			this.txtComments.AllowDrop = true;
			this.txtComments.BackColor = System.Drawing.Color.White;
			this.txtComments.ForeColor = System.Drawing.Color.Black;
			this.txtComments.Location = new System.Drawing.Point(114, 98);
			this.txtComments.MaxLength = 200;
			this.txtComments.Name = "txtComments";
			this.txtComments.Size = new System.Drawing.Size(571, 19);
			this.txtComments.TabIndex = 5;
			this.txtComments.Text = "";
			// this.this.txtComments.Watermark = "";
			// 
			// txtVoucherDate
			// 
			this.txtVoucherDate.AllowDrop = true;
			// this.txtVoucherDate.CheckDateRange = false;
			this.txtVoucherDate.Location = new System.Drawing.Point(114, 77);
			// this.txtVoucherDate.MaxDate = 2958465;
			// this.txtVoucherDate.MinDate = 32874;
			this.txtVoucherDate.Name = "txtVoucherDate";
			this.txtVoucherDate.Size = new System.Drawing.Size(102, 19);
			this.txtVoucherDate.TabIndex = 6;
			this.txtVoucherDate.Text = "07/18/2001";
			// this.txtVoucherDate.Value = 37090;
			// 
			// txtTransactionNo
			// 
			this.txtTransactionNo.AllowDrop = true;
			this.txtTransactionNo.BackColor = System.Drawing.Color.FromArgb(239, 239, 239);
			// this.txtTransactionNo.bolNumericOnly = true;
			this.txtTransactionNo.Enabled = false;
			this.txtTransactionNo.ForeColor = System.Drawing.Color.Black;
			this.txtTransactionNo.Location = new System.Drawing.Point(114, 56);
			this.txtTransactionNo.MaxLength = 11;
			this.txtTransactionNo.Name = "txtTransactionNo";
			this.txtTransactionNo.Size = new System.Drawing.Size(102, 19);
			this.txtTransactionNo.TabIndex = 7;
			this.txtTransactionNo.Text = "";
			// this.this.txtTransactionNo.Watermark = "";
			// 
			// _lblCommonLabel_4
			// 
			this._lblCommonLabel_4.AllowDrop = true;
			this._lblCommonLabel_4.BackColor = System.Drawing.SystemColors.Window;
			this._lblCommonLabel_4.Text = "R e v e n u e";
			this._lblCommonLabel_4.ForeColor = System.Drawing.Color.White;
			this._lblCommonLabel_4.Location = new System.Drawing.Point(537, 140);
			this._lblCommonLabel_4.Name = "_lblCommonLabel_4";
			this._lblCommonLabel_4.Size = new System.Drawing.Size(68, 13);
			this._lblCommonLabel_4.TabIndex = 8;
			// 
			// _lblCommonLabel_2
			// 
			this._lblCommonLabel_2.AllowDrop = true;
			this._lblCommonLabel_2.BackColor = System.Drawing.SystemColors.Window;
			this._lblCommonLabel_2.Text = "C o s t ";
			this._lblCommonLabel_2.ForeColor = System.Drawing.Color.White;
			this._lblCommonLabel_2.Location = new System.Drawing.Point(157, 140);
			this._lblCommonLabel_2.Name = "_lblCommonLabel_2";
			this._lblCommonLabel_2.Size = new System.Drawing.Size(37, 13);
			this._lblCommonLabel_2.TabIndex = 9;
			// 
			// Line1
			// 
			this.Line1.AllowDrop = true;
			this.Line1.BackColor = System.Drawing.SystemColors.WindowText;
			this.Line1.Enabled = false;
			this.Line1.Location = new System.Drawing.Point(380, 136);
			this.Line1.Name = "Line1";
			this.Line1.Size = new System.Drawing.Size(1, 22);
			this.Line1.Visible = true;
			// 
			// Shape1
			// 
			this.Shape1.AllowDrop = true;
			this.Shape1.BackColor = System.Drawing.Color.FromArgb(224, 180, 171);
			this.Shape1.BackStyle = 0;
			this.Shape1.BorderStyle = 1;
			this.Shape1.Enabled = false;
			this.Shape1.FillColor = System.Drawing.Color.FromArgb(153, 164, 154);
			this.Shape1.FillStyle = 0;
			this.Shape1.Location = new System.Drawing.Point(0, 136);
			this.Shape1.Name = "Shape1";
			this.Shape1.Size = new System.Drawing.Size(758, 21);
			this.Shape1.Visible = true;
			// 
			// tcbSystemForm
			// 
			this.tcbSystemForm.AllowDrop = true;
			this.tcbSystemForm.Location = new System.Drawing.Point(274, 6);
			this.tcbSystemForm.Name = "tcbSystemForm";
			("tcbSystemForm.OcxState");
			// 
			// frmICSComparisionSheet
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.FromArgb(208, 217, 208);
			this.ClientSize = new System.Drawing.Size(758, 371);
			this.Controls.Add(this.cmbMasterList);
			this.Controls.Add(this.grdComparisionDetails);
			this.Controls.Add(this._lblCommonLabel_21);
			this.Controls.Add(this._lblCommonLabel_0);
			this.Controls.Add(this._lblCommonLabel_1);
			this.Controls.Add(this.txtComments);
			this.Controls.Add(this.txtVoucherDate);
			this.Controls.Add(this.txtTransactionNo);
			this.Controls.Add(this._lblCommonLabel_4);
			this.Controls.Add(this._lblCommonLabel_2);
			this.Controls.Add(this.Line1);
			this.Controls.Add(this.Shape1);
			this.Controls.Add(this.tcbSystemForm);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			//this.Icon = (System.Drawing.Icon) resources.GetObject("frmICSComparisionSheet.Icon");
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(105, 132);
			this.MaximizeBox = false;
			this.MinimizeBox = true;
			this.Name = "frmICSComparisionSheet";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Tag = "\"H: 6225  W:9570\"";
			this.Text = "ICS Comparision Sheet";
			// this.Activated += new System.EventHandler(this.frmICSComparisionSheet_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
			// this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
			//((System.ComponentModel.ISupportInitialize) this.tcbSystemForm).EndInit();
			this.cmbMasterList.ResumeLayout(false);
			this.grdComparisionDetails.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		void ReLoadForm(bool addEvents)
		{
			InitializelblCommonLabel();
			//This form is an MDI child.
			//This code simulates the VB6 
			// functionality of automatically
			// loading and showing an MDI
			// child's parent.
			this.MdiParent = Xtreme.frmSysMain.DefInstance;
			Xtreme.frmSysMain.DefInstance.Show();
		}
		void InitializelblCommonLabel()
		{
			this.lblCommonLabel = new System.Windows.Forms.Label[22];
			this.lblCommonLabel[21] = _lblCommonLabel_21;
			this.lblCommonLabel[0] = _lblCommonLabel_0;
			this.lblCommonLabel[1] = _lblCommonLabel_1;
			this.lblCommonLabel[4] = _lblCommonLabel_4;
			this.lblCommonLabel[2] = _lblCommonLabel_2;
		}
		#endregion
	}
}//ENDSHERE
