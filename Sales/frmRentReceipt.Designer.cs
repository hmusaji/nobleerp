
namespace Xtreme
{
	partial class frmRentReceipt
	{

		#region "Upgrade Support "
		private static frmRentReceipt m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmRentReceipt DefInstance
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
		public static frmRentReceipt CreateInstance()
		{
			frmRentReceipt theInstance = new frmRentReceipt();
			
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
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "Column_0_cmbMastersList", "Column_1_cmbMastersList", "cmbMastersList", "Column_0_grdVoucherDetails", "Column_1_grdVoucherDetails", "grdVoucherDetails", "txtTempDate", "Frame1", "C1Tab1", "txtDate", "Label_0", "txtBuildingNo", "Label_1", "txtDescription", "Label_2", "System.Windows.Forms.Label"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_0_cmbMastersList;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_1_cmbMastersList;
		public C1.Win.C1TrueDBGrid.C1TrueDBDropdown cmbMastersList;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_0_grdVoucherDetails;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_1_grdVoucherDetails;
		public C1.Win.C1TrueDBGrid.C1TrueDBGrid grdVoucherDetails;
		public Syncfusion.WinForms.Input.SfDateTimeEdit txtTempDate;
		public System.Windows.Forms.Panel Frame1;
		public Syncfusion.Windows.Forms.Tools.TabControlAdv C1Tab1;
		public Syncfusion.WinForms.Input.SfDateTimeEdit txtDate;
		private System.Windows.Forms.Label Label_0;
		public System.Windows.Forms.TextBox txtBuildingNo;
		private System.Windows.Forms.Label Label_1;
		public System.Windows.Forms.TextBox txtDescription;
		private System.Windows.Forms.Label Label_2;
		public System.Windows.Forms.Label[] Label = new System.Windows.Forms.Label[3];
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRentReceipt));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this.C1Tab1 = new Syncfusion.Windows.Forms.Tools.TabControlAdv();
			this.Frame1 = new System.Windows.Forms.Panel();
			this.cmbMastersList = new C1.Win.C1TrueDBGrid.C1TrueDBDropdown();
			this.Column_0_cmbMastersList = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.Column_1_cmbMastersList = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.grdVoucherDetails = new C1.Win.C1TrueDBGrid.C1TrueDBGrid();
			this.Column_0_grdVoucherDetails = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.Column_1_grdVoucherDetails = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.txtTempDate = new Syncfusion.WinForms.Input.SfDateTimeEdit();
			this.txtDate = new Syncfusion.WinForms.Input.SfDateTimeEdit();
			this.Label_0 = new System.Windows.Forms.Label();
			this.txtBuildingNo = new System.Windows.Forms.TextBox();
			this.Label_1 = new System.Windows.Forms.Label();
			this.txtDescription = new System.Windows.Forms.TextBox();
			this.Label_2 = new System.Windows.Forms.Label();
			// //((System.ComponentModel.ISupportInitialize) this.txtTempDate).BeginInit();
			// //((System.ComponentModel.ISupportInitialize) this.C1Tab1).BeginInit();
			//this.C1Tab1.SuspendLayout();
			//this.Frame1.SuspendLayout();
			//this.cmbMastersList.SuspendLayout();
			//this.grdVoucherDetails.SuspendLayout();
			this.SuspendLayout();
			// 
			// C1Tab1
			// 
			//this.C1Tab1.Align = C1SizerLib.AlignSettings.asNone;
			this.C1Tab1.AllowDrop = true;
			this.C1Tab1.Controls.Add(this.Frame1);
			this.C1Tab1.Location = new System.Drawing.Point(4, 94);
			this.C1Tab1.Name = "C1Tab1";
			//
			this.C1Tab1.Size = new System.Drawing.Size(1149, 373);
			this.C1Tab1.TabIndex = 0;
			this.C1Tab1.TabStop = false;
			// 
			// Frame1
			// 
			this.Frame1.AllowDrop = true;
			this.Frame1.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this.Frame1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Frame1.Controls.Add(this.cmbMastersList);
			this.Frame1.Controls.Add(this.grdVoucherDetails);
			this.Frame1.Controls.Add(this.txtTempDate);
			this.Frame1.Enabled = true;
			this.Frame1.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Frame1.Location = new System.Drawing.Point(1, 23);
			this.Frame1.Name = "Frame1";
			this.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Frame1.Size = new System.Drawing.Size(1147, 349);
			this.Frame1.TabIndex = 1;
			this.Frame1.Visible = true;
			// 
			// cmbMastersList
			// 
			this.cmbMastersList.AllowDrop = true;
			this.cmbMastersList.ColumnHeaders = true;
			this.cmbMastersList.Enabled = true;
			this.cmbMastersList.Location = new System.Drawing.Point(8, 16);
			this.cmbMastersList.Name = "cmbMastersList";
			this.cmbMastersList.Size = new System.Drawing.Size(333, 133);
			this.cmbMastersList.TabIndex = 2;
			this.cmbMastersList.Columns.Add(this.Column_0_cmbMastersList);
			this.cmbMastersList.Columns.Add(this.Column_1_cmbMastersList);
			// 
			// Column_0_cmbMastersList
			// 
			this.Column_0_cmbMastersList.DataField = "";
			this.Column_0_cmbMastersList.ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.Normal;
			// 
			// Column_1_cmbMastersList
			// 
			this.Column_1_cmbMastersList.DataField = "";
			this.Column_1_cmbMastersList.ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.Normal;
			// 
			// grdVoucherDetails
			// 
			this.grdVoucherDetails.AllowDrop = true;
			this.grdVoucherDetails.BackColor = System.Drawing.Color.Silver;
			this.grdVoucherDetails.CellTipsWidth = 0;
			this.grdVoucherDetails.Location = new System.Drawing.Point(12, 20);
			this.grdVoucherDetails.Name = "grdVoucherDetails";
			this.grdVoucherDetails.RowDivider.Color = System.Drawing.Color.Silver;
			this.grdVoucherDetails.Size = new System.Drawing.Size(1127, 322);
			this.grdVoucherDetails.TabIndex = 3;
			this.grdVoucherDetails.Columns.Add(this.Column_0_grdVoucherDetails);
			this.grdVoucherDetails.Columns.Add(this.Column_1_grdVoucherDetails);
			this.grdVoucherDetails.AfterColUpdate += new C1.Win.C1TrueDBGrid.ColEventHandler(this.grdVoucherDetails_AfterColUpdate);
			this.grdVoucherDetails.GotFocus += new System.EventHandler(this.grdVoucherDetails_GotFocus);
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
			// txtTempDate
			// 
			this.txtTempDate.AllowDrop = true;
			this.txtTempDate.Location = new System.Drawing.Point(18, 16);
			this.txtTempDate.Name = "txtTempDate";
			//
			this.txtTempDate.Size = new System.Drawing.Size(109, 19);
			this.txtTempDate.TabIndex = 4;
			this.txtTempDate.TabStop = false;
			this.txtTempDate.Visible = false;
			// 
			// txtDate
			// 
			this.txtDate.AllowDrop = true;
			this.txtDate.Location = new System.Drawing.Point(106, 12);
			// this.txtDate.MaxDate = 2958465;
			// this.txtDate.MinDate = -657434;
			this.txtDate.Name = "txtDate";
			// = "_";
			this.txtDate.Size = new System.Drawing.Size(89, 19);
			this.txtDate.TabIndex = 5;
			// this.txtDate.Text = "23/02/2014";
			// 
			// Label_0
			// 
			this.Label_0.AllowDrop = true;
			this.Label_0.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.Label_0.Text = "Date";
			this.Label_0.ForeColor = System.Drawing.SystemColors.WindowText;
			this.Label_0.Location = new System.Drawing.Point(8, 15);
			this.Label_0.Name = "Label_0";
			this.Label_0.Size = new System.Drawing.Size(22, 14);
			this.Label_0.TabIndex = 6;
			// 
			// txtBuildingNo
			// 
			this.txtBuildingNo.AllowDrop = true;
			this.txtBuildingNo.BackColor = System.Drawing.Color.White;
			// // = false;
			this.txtBuildingNo.ForeColor = System.Drawing.Color.Black;
			this.txtBuildingNo.Location = new System.Drawing.Point(106, 34);
			// // = (System.Windows.Forms.TextBox.DropDownTypes) 0;
			this.txtBuildingNo.Name = "txtBuildingNo";
			this.txtBuildingNo.Size = new System.Drawing.Size(87, 19);
			this.txtBuildingNo.TabIndex = 7;
			this.txtBuildingNo.Text = "";
			// this.// = "";
			// 
			// Label_1
			// 
			this.Label_1.AllowDrop = true;
			this.Label_1.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.Label_1.Text = "Building No";
			this.Label_1.ForeColor = System.Drawing.SystemColors.WindowText;
			this.Label_1.Location = new System.Drawing.Point(6, 38);
			this.Label_1.Name = "Label_1";
			this.Label_1.Size = new System.Drawing.Size(53, 14);
			this.Label_1.TabIndex = 8;
			// 
			// txtDescription
			// 
			this.txtDescription.AllowDrop = true;
			this.txtDescription.BackColor = System.Drawing.Color.White;
			// // = false;
			this.txtDescription.ForeColor = System.Drawing.Color.Black;
			this.txtDescription.Location = new System.Drawing.Point(106, 56);
			// // = (System.Windows.Forms.TextBox.DropDownTypes) 0;
			this.txtDescription.Name = "txtDescription";
			this.txtDescription.Size = new System.Drawing.Size(331, 19);
			this.txtDescription.TabIndex = 9;
			this.txtDescription.Text = "";
			// this.// = "";
			// 
			// Label_2
			// 
			this.Label_2.AllowDrop = true;
			this.Label_2.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.Label_2.Text = "Description";
			this.Label_2.ForeColor = System.Drawing.SystemColors.WindowText;
			this.Label_2.Location = new System.Drawing.Point(6, 60);
			this.Label_2.Name = "Label_2";
			this.Label_2.Size = new System.Drawing.Size(54, 14);
			this.Label_2.TabIndex = 10;
			// 
			// frmRentReceipt
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.ClientSize = new System.Drawing.Size(1199, 562);
			this.Controls.Add(this.C1Tab1);
			this.Controls.Add(this.txtDate);
			this.Controls.Add(this.Label_0);
			this.Controls.Add(this.txtBuildingNo);
			this.Controls.Add(this.Label_1);
			this.Controls.Add(this.txtDescription);
			this.Controls.Add(this.Label_2);
			this.Font = new System.Drawing.Font("Tahoma", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 178);
			this.Location = new System.Drawing.Point(184, 153);
			this.MaximizeBox = true;
			this.MinimizeBox = true;
			this.Name = "frmRentReceipt";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Rent Receipt";
			// this.Activated += new System.EventHandler(this.frmRentReceipt_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
			// this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
			this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Form_KeyPress);
			//this.Resize += new System.EventHandler(this.Form_Resize);
			//((System.ComponentModel.ISupportInitialize) this.txtTempDate).EndInit();
			//((System.ComponentModel.ISupportInitialize) this.C1Tab1).EndInit();
			this.C1Tab1.ResumeLayout(false);
			this.Frame1.ResumeLayout(false);
			this.cmbMastersList.ResumeLayout(false);
			this.grdVoucherDetails.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		// 
		void InitializeSystemWindowsFormsLabel()
		{
			this.Label = new System.Windows.Forms.Label[3];
			this.Label[0] = Label_0;
			this.Label[1] = Label_1;
			this.Label[2] = Label_2;
		}
		#endregion
	}
}//ENDSHERE
