
namespace Xtreme
{
	partial class frmPayAppraisalSurveyRatingType
	{

		#region "Upgrade Support "
		private static frmPayAppraisalSurveyRatingType m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmPayAppraisalSurveyRatingType DefInstance
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
		public static frmPayAppraisalSurveyRatingType CreateInstance()
		{
			frmPayAppraisalSurveyRatingType theInstance = new frmPayAppraisalSurveyRatingType();
			
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
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "Column_0_grdRatingDetails", "Column_1_grdRatingDetails", "grdRatingDetails", "txtRatingTypeCode", "lblCategoryNo", "lblACategoryName", "lblLCategoryName", "txtLRatingTypeName", "txtARatingTypeName"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_0_grdRatingDetails;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_1_grdRatingDetails;
		public C1.Win.C1TrueDBGrid.C1TrueDBGrid grdRatingDetails;
		public System.Windows.Forms.TextBox txtRatingTypeCode;
		public System.Windows.Forms.Label lblCategoryNo;
		public System.Windows.Forms.Label lblACategoryName;
		public System.Windows.Forms.Label lblLCategoryName;
		public System.Windows.Forms.TextBox txtLRatingTypeName;
		public System.Windows.Forms.TextBox txtARatingTypeName;
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPayAppraisalSurveyRatingType));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this.grdRatingDetails = new C1.Win.C1TrueDBGrid.C1TrueDBGrid();
			this.Column_0_grdRatingDetails = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.Column_1_grdRatingDetails = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.txtRatingTypeCode = new System.Windows.Forms.TextBox();
			this.lblCategoryNo = new System.Windows.Forms.Label();
			this.lblACategoryName = new System.Windows.Forms.Label();
			this.lblLCategoryName = new System.Windows.Forms.Label();
			this.txtLRatingTypeName = new System.Windows.Forms.TextBox();
			this.txtARatingTypeName = new System.Windows.Forms.TextBox();
			//this.grdRatingDetails.SuspendLayout();
			this.SuspendLayout();
			// 
			// grdRatingDetails
			// 
			this.grdRatingDetails.AllowAddNew = true;
			this.grdRatingDetails.AllowDelete = true;
			this.grdRatingDetails.AllowDrop = true;
			this.grdRatingDetails.BackColor = System.Drawing.Color.FromArgb(212, 208, 200);
			this.grdRatingDetails.CellTipsWidth = 0;
			this.grdRatingDetails.Location = new System.Drawing.Point(3, 129);
			this.grdRatingDetails.Name = "grdRatingDetails";
			this.grdRatingDetails.RowDivider.Color = System.Drawing.Color.FromArgb(212, 208, 200);
			this.grdRatingDetails.Size = new System.Drawing.Size(434, 187);
			this.grdRatingDetails.TabIndex = 0;
			this.grdRatingDetails.Columns.Add(this.Column_0_grdRatingDetails);
			this.grdRatingDetails.Columns.Add(this.Column_1_grdRatingDetails);
			// 
			// Column_0_grdRatingDetails
			// 
			this.Column_0_grdRatingDetails.DataField = "";
			this.Column_0_grdRatingDetails.ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.Normal;
			// 
			// Column_1_grdRatingDetails
			// 
			this.Column_1_grdRatingDetails.DataField = "";
			this.Column_1_grdRatingDetails.ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.Normal;
			// 
			// txtRatingTypeCode
			// 
			this.txtRatingTypeCode.AllowDrop = true;
			this.txtRatingTypeCode.BackColor = System.Drawing.Color.White;
			// this.txtRatingTypeCode.bolNumericOnly = true;
			this.txtRatingTypeCode.ForeColor = System.Drawing.Color.Black;
			this.txtRatingTypeCode.Location = new System.Drawing.Point(106, 57);
			this.txtRatingTypeCode.MaxLength = 15;
			// // = System.Windows.Forms.TextBox.DropDownTypes.ddtNextNumber;
			this.txtRatingTypeCode.Name = "txtRatingTypeCode";
			// this.txtRatingTypeCode.ShowButton = true;
			this.txtRatingTypeCode.Size = new System.Drawing.Size(110, 19);
			this.txtRatingTypeCode.TabIndex = 1;
			this.txtRatingTypeCode.Text = "";
			// this.//this.txtRatingTypeCode.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(//this.txtRatingTypeCode_DropButtonClick);
			// 
			// lblCategoryNo
			// 
			this.lblCategoryNo.AllowDrop = true;
			this.lblCategoryNo.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblCategoryNo.Text = "Rating Type Code";
			this.lblCategoryNo.ForeColor = System.Drawing.Color.Black;
			this.lblCategoryNo.Location = new System.Drawing.Point(3, 59);
			this.lblCategoryNo.Name = "lblCategoryNo";
			this.lblCategoryNo.Size = new System.Drawing.Size(85, 14);
			this.lblCategoryNo.TabIndex = 2;
			// 
			// lblACategoryName
			// 
			this.lblACategoryName.AllowDrop = true;
			this.lblACategoryName.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblACategoryName.Text = "Type Name (Arb)";
			this.lblACategoryName.ForeColor = System.Drawing.Color.Black;
			this.lblACategoryName.Location = new System.Drawing.Point(3, 104);
			this.lblACategoryName.Name = "lblACategoryName";
			this.lblACategoryName.Size = new System.Drawing.Size(83, 14);
			this.lblACategoryName.TabIndex = 3;
			// 
			// lblLCategoryName
			// 
			this.lblLCategoryName.AllowDrop = true;
			this.lblLCategoryName.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblLCategoryName.Text = "Type Name (Eng)";
			this.lblLCategoryName.ForeColor = System.Drawing.Color.Black;
			this.lblLCategoryName.Location = new System.Drawing.Point(3, 83);
			this.lblLCategoryName.Name = "lblLCategoryName";
			this.lblLCategoryName.Size = new System.Drawing.Size(83, 14);
			this.lblLCategoryName.TabIndex = 4;
			// 
			// txtLRatingTypeName
			// 
			this.txtLRatingTypeName.AllowDrop = true;
			this.txtLRatingTypeName.BackColor = System.Drawing.Color.White;
			this.txtLRatingTypeName.ForeColor = System.Drawing.Color.Black;
			this.txtLRatingTypeName.Location = new System.Drawing.Point(106, 81);
			this.txtLRatingTypeName.MaxLength = 50;
			this.txtLRatingTypeName.Name = "txtLRatingTypeName";
			this.txtLRatingTypeName.Size = new System.Drawing.Size(330, 19);
			this.txtLRatingTypeName.TabIndex = 5;
			this.txtLRatingTypeName.Text = "";
			// 
			// txtARatingTypeName
			// 
			this.txtARatingTypeName.AllowDrop = true;
			this.txtARatingTypeName.BackColor = System.Drawing.Color.White;
			this.txtARatingTypeName.ForeColor = System.Drawing.Color.Black;
			this.txtARatingTypeName.Location = new System.Drawing.Point(106, 102);
			// // = true;
			this.txtARatingTypeName.MaxLength = 50;
			this.txtARatingTypeName.Name = "txtARatingTypeName";
			this.txtARatingTypeName.Size = new System.Drawing.Size(330, 19);
			this.txtARatingTypeName.TabIndex = 6;
			this.txtARatingTypeName.Text = "";
			// 
			// frmPayAppraisalSurveyRatingType
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.ClientSize = new System.Drawing.Size(441, 320);
			this.Controls.Add(this.grdRatingDetails);
			this.Controls.Add(this.txtRatingTypeCode);
			this.Controls.Add(this.lblCategoryNo);
			this.Controls.Add(this.lblACategoryName);
			this.Controls.Add(this.lblLCategoryName);
			this.Controls.Add(this.txtLRatingTypeName);
			this.Controls.Add(this.txtARatingTypeName);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			//this.Icon = (System.Drawing.Icon) resources.GetObject("frmPayAppraisalSurveyRatingType.Icon");
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(448, 105);
			this.MaximizeBox = true;
			this.MinimizeBox = true;
			this.Name = "frmPayAppraisalSurveyRatingType";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Survey Rating Type";
			// this.Activated += new System.EventHandler(this.frmPayAppraisalSurveyRatingType_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
			// this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
			this.grdRatingDetails.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		// 
		#endregion
	}
}//ENDSHERE
