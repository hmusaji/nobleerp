
namespace Xtreme
{
	partial class frmPayAppraisalSurveyDefination
	{

		#region "Upgrade Support "
		private static frmPayAppraisalSurveyDefination m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmPayAppraisalSurveyDefination DefInstance
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
		public static frmPayAppraisalSurveyDefination CreateInstance()
		{
			frmPayAppraisalSurveyDefination theInstance = new frmPayAppraisalSurveyDefination();
			
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
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "txtAPurpose", "txtLPurpose", "txtLInstruction", "txtAInstruction", "txtSurveyDefinationCode", "lblCategoryNo", "lblACategoryName", "lblLCategoryName", "txtLSurveyDefination", "txtASurveyDefination", "txtDlblRatingTypeName", "lblPurposeArb", "lblComments", "txtRatingType", "System.Windows.Forms.Label2", "System.Windows.Forms.Label1", "System.Windows.Forms.Label3", "Column_0_cmbMastersList", "Column_1_cmbMastersList", "cmbMastersList", "Column_0_grdSurveyDetails", "Column_1_grdSurveyDetails", "grdSurveyDetails"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public System.Windows.Forms.TextBox txtAPurpose;
		public System.Windows.Forms.TextBox txtLPurpose;
		public System.Windows.Forms.TextBox txtLInstruction;
		public System.Windows.Forms.TextBox txtAInstruction;
		public System.Windows.Forms.TextBox txtSurveyDefinationCode;
		public System.Windows.Forms.Label lblCategoryNo;
		public System.Windows.Forms.Label lblACategoryName;
		public System.Windows.Forms.Label lblLCategoryName;
		public System.Windows.Forms.TextBox txtLSurveyDefination;
		public System.Windows.Forms.TextBox txtASurveyDefination;
		public System.Windows.Forms.Label txtDlblRatingTypeName;
		public System.Windows.Forms.Label lblPurposeArb;
		public System.Windows.Forms.Label lblComments;
		public System.Windows.Forms.TextBox txtRatingType;
		public System.Windows.Forms.Label System.Windows.Forms.Label2;
		public System.Windows.Forms.Label System.Windows.Forms.Label1;
		public System.Windows.Forms.Label System.Windows.Forms.Label3;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_0_cmbMastersList;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_1_cmbMastersList;
		public C1.Win.C1TrueDBGrid.C1TrueDBDropdown cmbMastersList;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_0_grdSurveyDetails;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_1_grdSurveyDetails;
		public C1.Win.C1TrueDBGrid.C1TrueDBGrid grdSurveyDetails;
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPayAppraisalSurveyDefination));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this.txtAPurpose = new System.Windows.Forms.TextBox();
			this.txtLPurpose = new System.Windows.Forms.TextBox();
			this.txtLInstruction = new System.Windows.Forms.TextBox();
			this.txtAInstruction = new System.Windows.Forms.TextBox();
			this.txtSurveyDefinationCode = new System.Windows.Forms.TextBox();
			this.lblCategoryNo = new System.Windows.Forms.Label();
			this.lblACategoryName = new System.Windows.Forms.Label();
			this.lblLCategoryName = new System.Windows.Forms.Label();
			this.txtLSurveyDefination = new System.Windows.Forms.TextBox();
			this.txtASurveyDefination = new System.Windows.Forms.TextBox();
			this.txtDlblRatingTypeName = new System.Windows.Forms.Label();
			this.lblPurposeArb = new System.Windows.Forms.Label();
			this.lblComments = new System.Windows.Forms.Label();
			this.txtRatingType = new System.Windows.Forms.TextBox();
			this.System.Windows.Forms.Label2 = new System.Windows.Forms.Label();
			this.System.Windows.Forms.Label1 = new System.Windows.Forms.Label();
			this.System.Windows.Forms.Label3 = new System.Windows.Forms.Label();
			this.cmbMastersList = new C1.Win.C1TrueDBGrid.C1TrueDBDropdown();
			this.Column_0_cmbMastersList = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.Column_1_cmbMastersList = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.grdSurveyDetails = new C1.Win.C1TrueDBGrid.C1TrueDBGrid();
			this.Column_0_grdSurveyDetails = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.Column_1_grdSurveyDetails = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.cmbMastersList.SuspendLayout();
			this.grdSurveyDetails.SuspendLayout();
			this.SuspendLayout();
			// 
			// txtAPurpose
			// 
			this.txtAPurpose.AcceptsReturn = true;
			this.txtAPurpose.AllowDrop = true;
			this.txtAPurpose.BackColor = System.Drawing.SystemColors.Window;
			this.txtAPurpose.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.txtAPurpose.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtAPurpose.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtAPurpose.Location = new System.Drawing.Point(109, 360);
			this.txtAPurpose.MaxLength = 0;
			this.txtAPurpose.Multiline = true;
			this.txtAPurpose.Name = "txtAPurpose";
			this.txtAPurpose.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtAPurpose.Size = new System.Drawing.Size(610, 40);
			this.txtAPurpose.TabIndex = 8;
			// 
			// txtLPurpose
			// 
			this.txtLPurpose.AcceptsReturn = true;
			this.txtLPurpose.AllowDrop = true;
			this.txtLPurpose.BackColor = System.Drawing.SystemColors.Window;
			this.txtLPurpose.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.txtLPurpose.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtLPurpose.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtLPurpose.Location = new System.Drawing.Point(109, 315);
			this.txtLPurpose.MaxLength = 0;
			this.txtLPurpose.Multiline = true;
			this.txtLPurpose.Name = "txtLPurpose";
			this.txtLPurpose.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtLPurpose.Size = new System.Drawing.Size(610, 40);
			this.txtLPurpose.TabIndex = 7;
			// 
			// txtLInstruction
			// 
			this.txtLInstruction.AcceptsReturn = true;
			this.txtLInstruction.AllowDrop = true;
			this.txtLInstruction.BackColor = System.Drawing.SystemColors.Window;
			this.txtLInstruction.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.txtLInstruction.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtLInstruction.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtLInstruction.Location = new System.Drawing.Point(109, 147);
			this.txtLInstruction.MaxLength = 0;
			this.txtLInstruction.Multiline = true;
			this.txtLInstruction.Name = "txtLInstruction";
			this.txtLInstruction.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtLInstruction.Size = new System.Drawing.Size(610, 80);
			this.txtLInstruction.TabIndex = 5;
			// 
			// txtAInstruction
			// 
			this.txtAInstruction.AcceptsReturn = true;
			this.txtAInstruction.AllowDrop = true;
			this.txtAInstruction.BackColor = System.Drawing.SystemColors.Window;
			this.txtAInstruction.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.txtAInstruction.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtAInstruction.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtAInstruction.Location = new System.Drawing.Point(109, 231);
			this.txtAInstruction.MaxLength = 0;
			this.txtAInstruction.Multiline = true;
			this.txtAInstruction.Name = "txtAInstruction";
			this.txtAInstruction.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtAInstruction.Size = new System.Drawing.Size(610, 80);
			this.txtAInstruction.TabIndex = 6;
			// 
			// txtSurveyDefinationCode
			// 
			this.txtSurveyDefinationCode.AllowDrop = true;
			this.txtSurveyDefinationCode.BackColor = System.Drawing.Color.White;
			// this.txtSurveyDefinationCode.bolNumericOnly = true;
			this.txtSurveyDefinationCode.ForeColor = System.Drawing.Color.Black;
			this.txtSurveyDefinationCode.Location = new System.Drawing.Point(109, 54);
			this.txtSurveyDefinationCode.MaxLength = 15;
			// this.txtSurveyDefinationCode.mDropDownType = System.Windows.Forms.TextBox.DropDownTypes.ddtNextNumber;
			this.txtSurveyDefinationCode.Name = "txtSurveyDefinationCode";
			// this.txtSurveyDefinationCode.ShowButton = true;
			this.txtSurveyDefinationCode.Size = new System.Drawing.Size(110, 19);
			this.txtSurveyDefinationCode.TabIndex = 1;
			this.txtSurveyDefinationCode.Text = "";
			// this.this.txtSurveyDefinationCode.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtSurveyDefinationCode_DropButtonClick);
			// 
			// lblCategoryNo
			// 
			this.lblCategoryNo.AllowDrop = true;
			this.lblCategoryNo.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblCategoryNo.Text = "Survey Code";
			this.lblCategoryNo.ForeColor = System.Drawing.Color.Black;
			this.lblCategoryNo.Location = new System.Drawing.Point(6, 56);
			this.lblCategoryNo.Name = "lblCategoryNo";
			this.lblCategoryNo.Size = new System.Drawing.Size(63, 14);
			this.lblCategoryNo.TabIndex = 0;
			// 
			// lblACategoryName
			// 
			this.lblACategoryName.AllowDrop = true;
			this.lblACategoryName.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblACategoryName.Text = "Survey Name (Arb)";
			this.lblACategoryName.ForeColor = System.Drawing.Color.Black;
			this.lblACategoryName.Location = new System.Drawing.Point(6, 101);
			this.lblACategoryName.Name = "lblACategoryName";
			this.lblACategoryName.Size = new System.Drawing.Size(94, 14);
			this.lblACategoryName.TabIndex = 10;
			// 
			// lblLCategoryName
			// 
			this.lblLCategoryName.AllowDrop = true;
			this.lblLCategoryName.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblLCategoryName.Text = "Survey Name (Eng)";
			this.lblLCategoryName.ForeColor = System.Drawing.Color.Black;
			this.lblLCategoryName.Location = new System.Drawing.Point(6, 80);
			this.lblLCategoryName.Name = "lblLCategoryName";
			this.lblLCategoryName.Size = new System.Drawing.Size(94, 14);
			this.lblLCategoryName.TabIndex = 11;
			// 
			// txtLSurveyDefination
			// 
			this.txtLSurveyDefination.AllowDrop = true;
			this.txtLSurveyDefination.BackColor = System.Drawing.Color.White;
			this.txtLSurveyDefination.ForeColor = System.Drawing.Color.Black;
			this.txtLSurveyDefination.Location = new System.Drawing.Point(109, 78);
			this.txtLSurveyDefination.MaxLength = 50;
			this.txtLSurveyDefination.Name = "txtLSurveyDefination";
			this.txtLSurveyDefination.Size = new System.Drawing.Size(441, 19);
			this.txtLSurveyDefination.TabIndex = 2;
			this.txtLSurveyDefination.Text = "";
			// 
			// txtASurveyDefination
			// 
			this.txtASurveyDefination.AllowDrop = true;
			this.txtASurveyDefination.BackColor = System.Drawing.Color.White;
			this.txtASurveyDefination.ForeColor = System.Drawing.Color.Black;
			this.txtASurveyDefination.Location = new System.Drawing.Point(109, 99);
			// this.txtASurveyDefination.mArabicEnabled = true;
			this.txtASurveyDefination.MaxLength = 50;
			this.txtASurveyDefination.Name = "txtASurveyDefination";
			this.txtASurveyDefination.Size = new System.Drawing.Size(441, 19);
			this.txtASurveyDefination.TabIndex = 3;
			this.txtASurveyDefination.Text = "";
			// 
			// txtDlblRatingTypeName
			// 
			this.txtDlblRatingTypeName.AllowDrop = true;
			this.txtDlblRatingTypeName.BackColor = System.Drawing.SystemColors.Window;
			this.txtDlblRatingTypeName.Enabled = false;
			this.txtDlblRatingTypeName.Location = new System.Drawing.Point(220, 123);
			this.txtDlblRatingTypeName.Name = "txtDlblRatingTypeName";
			this.txtDlblRatingTypeName.Size = new System.Drawing.Size(331, 19);
			this.txtDlblRatingTypeName.TabIndex = 12;
			// 
			// lblPurposeArb
			// 
			this.lblPurposeArb.AllowDrop = true;
			this.lblPurposeArb.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblPurposeArb.Text = "Message (Arb)";
			this.lblPurposeArb.ForeColor = System.Drawing.Color.Black;
			this.lblPurposeArb.Location = new System.Drawing.Point(6, 234);
			this.lblPurposeArb.Name = "lblPurposeArb";
			this.lblPurposeArb.Size = new System.Drawing.Size(73, 14);
			this.lblPurposeArb.TabIndex = 13;
			// 
			// lblComments
			// 
			this.lblComments.AllowDrop = true;
			this.lblComments.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblComments.Text = "Message (Eng)";
			this.lblComments.ForeColor = System.Drawing.Color.Black;
			this.lblComments.Location = new System.Drawing.Point(6, 153);
			this.lblComments.Name = "lblComments";
			this.lblComments.Size = new System.Drawing.Size(73, 14);
			this.lblComments.TabIndex = 14;
			// 
			// txtRatingType
			// 
			this.txtRatingType.AllowDrop = true;
			this.txtRatingType.BackColor = System.Drawing.Color.White;
			// this.txtRatingType.bolNumericOnly = true;
			this.txtRatingType.ForeColor = System.Drawing.Color.Black;
			this.txtRatingType.Location = new System.Drawing.Point(109, 123);
			this.txtRatingType.MaxLength = 15;
			// this.txtRatingType.mDropDownType = System.Windows.Forms.TextBox.DropDownTypes.ddtNextNumber;
			this.txtRatingType.Name = "txtRatingType";
			// this.txtRatingType.ShowButton = true;
			this.txtRatingType.Size = new System.Drawing.Size(110, 19);
			this.txtRatingType.TabIndex = 4;
			this.txtRatingType.Text = "";
			// this.this.txtRatingType.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtRatingType_DropButtonClick);
			// this.txtRatingType.Leave += new System.EventHandler(this.txtRatingType_Leave);
			// 
			// System.Windows.Forms.Label2
			// 
			this.System.Windows.Forms.Label2.AllowDrop = true;
			this.System.Windows.Forms.Label2.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.System.Windows.Forms.Label2.Caption = "Rating Type Code";
			this.System.Windows.Forms.Label2.ForeColor = System.Drawing.Color.Black;
			this.System.Windows.Forms.Label2.Location = new System.Drawing.Point(6, 125);
			this.System.Windows.Forms.Label2.Name = "System.Windows.Forms.Label2";
			this.System.Windows.Forms.Label2.Size = new System.Drawing.Size(85, 14);
			this.System.Windows.Forms.Label2.TabIndex = 15;
			// 
			// System.Windows.Forms.Label1
			// 
			this.System.Windows.Forms.Label1.AllowDrop = true;
			this.System.Windows.Forms.Label1.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.System.Windows.Forms.Label1.Caption = "Purpose (Arb)";
			this.System.Windows.Forms.Label1.ForeColor = System.Drawing.Color.Black;
			this.System.Windows.Forms.Label1.Location = new System.Drawing.Point(6, 366);
			this.System.Windows.Forms.Label1.Name = "System.Windows.Forms.Label1";
			this.System.Windows.Forms.Label1.Size = new System.Drawing.Size(69, 14);
			this.System.Windows.Forms.Label1.TabIndex = 16;
			// 
			// System.Windows.Forms.Label3
			// 
			this.System.Windows.Forms.Label3.AllowDrop = true;
			this.System.Windows.Forms.Label3.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.System.Windows.Forms.Label3.Caption = "Purpose (Eng)";
			this.System.Windows.Forms.Label3.ForeColor = System.Drawing.Color.Black;
			this.System.Windows.Forms.Label3.Location = new System.Drawing.Point(6, 318);
			this.System.Windows.Forms.Label3.Name = "System.Windows.Forms.Label3";
			this.System.Windows.Forms.Label3.Size = new System.Drawing.Size(69, 14);
			this.System.Windows.Forms.Label3.TabIndex = 17;
			// 
			// cmbMastersList
			// 
			this.cmbMastersList.AllowDrop = true;
			this.cmbMastersList.ColumnHeaders = true;
			this.cmbMastersList.Enabled = true;
			this.cmbMastersList.Location = new System.Drawing.Point(444, 468);
			this.cmbMastersList.Name = "cmbMastersList";
			this.cmbMastersList.Size = new System.Drawing.Size(53, 43);
			this.cmbMastersList.TabIndex = 18;
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
			// grdSurveyDetails
			// 
			this.grdSurveyDetails.AllowAddNew = true;
			this.grdSurveyDetails.AllowDelete = true;
			this.grdSurveyDetails.AllowDrop = true;
			this.grdSurveyDetails.BackColor = System.Drawing.Color.FromArgb(212, 208, 200);
			this.grdSurveyDetails.CellTipsWidth = 0;
			this.grdSurveyDetails.Location = new System.Drawing.Point(0, 408);
			this.grdSurveyDetails.Name = "grdSurveyDetails";
			this.grdSurveyDetails.RowDivider.Color = System.Drawing.Color.FromArgb(212, 208, 200);
			this.grdSurveyDetails.Size = new System.Drawing.Size(721, 190);
			this.grdSurveyDetails.TabIndex = 9;
			this.grdSurveyDetails.Columns.Add(this.Column_0_grdSurveyDetails);
			this.grdSurveyDetails.Columns.Add(this.Column_1_grdSurveyDetails);
			this.grdSurveyDetails.GotFocus += new System.EventHandler(this.grdSurveyDetails_GotFocus);
			this.grdSurveyDetails.RowColChange += new C1.Win.C1TrueDBGrid.RowColChangeEventHandler(this.grdSurveyDetails_RowColChange);
			// 
			// Column_0_grdSurveyDetails
			// 
			this.Column_0_grdSurveyDetails.DataField = "";
			this.Column_0_grdSurveyDetails.ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.Normal;
			// 
			// Column_1_grdSurveyDetails
			// 
			this.Column_1_grdSurveyDetails.DataField = "";
			this.Column_1_grdSurveyDetails.ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.Normal;
			// 
			// frmPayAppraisalSurveyDefination
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.ClientSize = new System.Drawing.Size(724, 601);
			this.Controls.Add(this.txtAPurpose);
			this.Controls.Add(this.txtLPurpose);
			this.Controls.Add(this.txtLInstruction);
			this.Controls.Add(this.txtAInstruction);
			this.Controls.Add(this.txtSurveyDefinationCode);
			this.Controls.Add(this.lblCategoryNo);
			this.Controls.Add(this.lblACategoryName);
			this.Controls.Add(this.lblLCategoryName);
			this.Controls.Add(this.txtLSurveyDefination);
			this.Controls.Add(this.txtASurveyDefination);
			this.Controls.Add(this.txtDlblRatingTypeName);
			this.Controls.Add(this.lblPurposeArb);
			this.Controls.Add(this.lblComments);
			this.Controls.Add(this.txtRatingType);
			this.Controls.Add(this.System.Windows.Forms.Label2);
			this.Controls.Add(this.System.Windows.Forms.Label1);
			this.Controls.Add(this.System.Windows.Forms.Label3);
			this.Controls.Add(this.cmbMastersList);
			this.Controls.Add(this.grdSurveyDetails);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			//this.Icon = (System.Drawing.Icon) resources.GetObject("frmPayAppraisalSurveyDefination.Icon");
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(124, 86);
			this.MaximizeBox = true;
			this.MinimizeBox = true;
			this.Name = "frmPayAppraisalSurveyDefination";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Survey Defination";
			// this.Activated += new System.EventHandler(this.frmPayAppraisalSurveyDefination_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
			// this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
			this.cmbMastersList.ResumeLayout(false);
			this.grdSurveyDetails.ResumeLayout(false);
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