
namespace Xtreme
{
	partial class frmPayAppraisalSurveyQuestion
	{

		#region "Upgrade Support "
		private static frmPayAppraisalSurveyQuestion m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmPayAppraisalSurveyQuestion DefInstance
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
		public static frmPayAppraisalSurveyQuestion CreateInstance()
		{
			frmPayAppraisalSurveyQuestion theInstance = new frmPayAppraisalSurveyQuestion();
			
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
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "txtDlblCategoryName", "txtAQuestion", "txtLQuestion", "txtQuestionCode", "lblCategoryNo", "lblPurposeArb", "_cmbCommon_0", "System.Windows.Forms.Label1", "lblComments", "txtCategoryCode", "System.Windows.Forms.Label2", "cmbCommon"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public System.Windows.Forms.Label txtDlblCategoryName;
		public System.Windows.Forms.TextBox txtAQuestion;
		public System.Windows.Forms.TextBox txtLQuestion;
		public System.Windows.Forms.TextBox txtQuestionCode;
		public System.Windows.Forms.Label lblCategoryNo;
		public System.Windows.Forms.Label lblPurposeArb;
		private System.Windows.Forms.ComboBox _cmbCommon_0;
		public System.Windows.Forms.Label Label1;
		public System.Windows.Forms.Label lblComments;
		public System.Windows.Forms.TextBox txtCategoryCode;
		public System.Windows.Forms.Label Label2;
		public System.Windows.Forms.ComboBox[] cmbCommon = new System.Windows.Forms.ComboBox[1];
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPayAppraisalSurveyQuestion));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this.txtDlblCategoryName = new System.Windows.Forms.Label();
			this.txtAQuestion = new System.Windows.Forms.TextBox();
			this.txtLQuestion = new System.Windows.Forms.TextBox();
			this.txtQuestionCode = new System.Windows.Forms.TextBox();
			this.lblCategoryNo = new System.Windows.Forms.Label();
			this.lblPurposeArb = new System.Windows.Forms.Label();
			this._cmbCommon_0 = new System.Windows.Forms.ComboBox();
			this.Label1 = new System.Windows.Forms.Label();
			this.lblComments = new System.Windows.Forms.Label();
			this.txtCategoryCode = new System.Windows.Forms.TextBox();
			this.Label2 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// txtDlblCategoryName
			// 
			this.txtDlblCategoryName.AllowDrop = true;
			this.txtDlblCategoryName.BackColor = System.Drawing.SystemColors.Window;
			this.txtDlblCategoryName.Enabled = false;
			this.txtDlblCategoryName.Location = new System.Drawing.Point(267, 111);
			this.txtDlblCategoryName.Name = "txtDlblCategoryName";
			this.txtDlblCategoryName.Size = new System.Drawing.Size(304, 19);
			this.txtDlblCategoryName.TabIndex = 10;
			// 
			// txtAQuestion
			// 
			this.txtAQuestion.AcceptsReturn = true;
			this.txtAQuestion.AllowDrop = true;
			this.txtAQuestion.BackColor = System.Drawing.SystemColors.Window;
			this.txtAQuestion.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.txtAQuestion.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtAQuestion.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtAQuestion.Location = new System.Drawing.Point(130, 234);
			this.txtAQuestion.MaxLength = 0;
			this.txtAQuestion.Multiline = true;
			this.txtAQuestion.Name = "txtAQuestion";
			this.txtAQuestion.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtAQuestion.Size = new System.Drawing.Size(442, 91);
			this.txtAQuestion.TabIndex = 4;
			// 
			// txtLQuestion
			// 
			this.txtLQuestion.AcceptsReturn = true;
			this.txtLQuestion.AllowDrop = true;
			this.txtLQuestion.BackColor = System.Drawing.SystemColors.Window;
			this.txtLQuestion.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.txtLQuestion.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtLQuestion.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtLQuestion.Location = new System.Drawing.Point(130, 135);
			this.txtLQuestion.MaxLength = 0;
			this.txtLQuestion.Multiline = true;
			this.txtLQuestion.Name = "txtLQuestion";
			this.txtLQuestion.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtLQuestion.Size = new System.Drawing.Size(442, 94);
			this.txtLQuestion.TabIndex = 3;
			// 
			// txtQuestionCode
			// 
			this.txtQuestionCode.AllowDrop = true;
			this.txtQuestionCode.BackColor = System.Drawing.Color.White;
			// this.txtQuestionCode.bolNumericOnly = true;
			this.txtQuestionCode.ForeColor = System.Drawing.Color.Black;
			this.txtQuestionCode.Location = new System.Drawing.Point(130, 63);
			this.txtQuestionCode.MaxLength = 15;
			// this.txtQuestionCode.mDropDownType = System.Windows.Forms.TextBox.DropDownTypes.ddtNextNumber;
			this.txtQuestionCode.Name = "txtQuestionCode";
			// this.txtQuestionCode.ShowButton = true;
			this.txtQuestionCode.Size = new System.Drawing.Size(134, 19);
			this.txtQuestionCode.TabIndex = 0;
			this.txtQuestionCode.Text = "";
			// this.this.txtQuestionCode.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtQuestionCode_DropButtonClick);
			// 
			// lblCategoryNo
			// 
			this.lblCategoryNo.AllowDrop = true;
			this.lblCategoryNo.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblCategoryNo.Text = "Question Code";
			this.lblCategoryNo.ForeColor = System.Drawing.Color.Black;
			this.lblCategoryNo.Location = new System.Drawing.Point(6, 65);
			this.lblCategoryNo.Name = "lblCategoryNo";
			this.lblCategoryNo.Size = new System.Drawing.Size(71, 14);
			this.lblCategoryNo.TabIndex = 5;
			// 
			// lblPurposeArb
			// 
			this.lblPurposeArb.AllowDrop = true;
			this.lblPurposeArb.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblPurposeArb.Text = "Question (ARB)";
			this.lblPurposeArb.ForeColor = System.Drawing.Color.Black;
			this.lblPurposeArb.Location = new System.Drawing.Point(6, 243);
			this.lblPurposeArb.Name = "lblPurposeArb";
			this.lblPurposeArb.Size = new System.Drawing.Size(76, 14);
			this.lblPurposeArb.TabIndex = 6;
			// 
			// _cmbCommon_0
			// 
			this._cmbCommon_0.AllowDrop = true;
			this._cmbCommon_0.Location = new System.Drawing.Point(130, 87);
			this._cmbCommon_0.Name = "_cmbCommon_0";
			this._cmbCommon_0.Size = new System.Drawing.Size(137, 21);
			this._cmbCommon_0.TabIndex = 1;
			// 
			// System.Windows.Forms.Label1
			// 
			this.Label1.AllowDrop = true;
			this.Label1.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.Label1.Text = "Question Type";
			this.Label1.ForeColor = System.Drawing.Color.Black;
			this.Label1.Location = new System.Drawing.Point(6, 90);
			this.Label1.Name = "System.Windows.Forms.Label1";
			this.Label1.Size = new System.Drawing.Size(70, 14);
			this.Label1.TabIndex = 7;
			// 
			// lblComments
			// 
			this.lblComments.AllowDrop = true;
			this.lblComments.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblComments.Text = "Question (Eng)";
			this.lblComments.ForeColor = System.Drawing.Color.Black;
			this.lblComments.Location = new System.Drawing.Point(6, 141);
			this.lblComments.Name = "lblComments";
			this.lblComments.Size = new System.Drawing.Size(72, 14);
			this.lblComments.TabIndex = 8;
			// 
			// txtCategoryCode
			// 
			this.txtCategoryCode.AllowDrop = true;
			this.txtCategoryCode.BackColor = System.Drawing.Color.White;
			// this.txtCategoryCode.bolNumericOnly = true;
			this.txtCategoryCode.ForeColor = System.Drawing.Color.Black;
			this.txtCategoryCode.Location = new System.Drawing.Point(130, 111);
			this.txtCategoryCode.MaxLength = 15;
			// this.txtCategoryCode.mDropDownType = System.Windows.Forms.TextBox.DropDownTypes.ddtNextNumber;
			this.txtCategoryCode.Name = "txtCategoryCode";
			// this.txtCategoryCode.ShowButton = true;
			this.txtCategoryCode.Size = new System.Drawing.Size(137, 19);
			this.txtCategoryCode.TabIndex = 2;
			this.txtCategoryCode.Text = "";
			// this.this.txtCategoryCode.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCategoryCode_DropButtonClick);
			// this.txtCategoryCode.Leave += new System.EventHandler(this.txtCategoryCode_Leave);
			// 
			// System.Windows.Forms.Label2
			// 
			this.Label2.AllowDrop = true;
			this.Label2.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.Label2.Text = "Category Code";
			this.Label2.ForeColor = System.Drawing.Color.Black;
			this.Label2.Location = new System.Drawing.Point(6, 113);
			this.Label2.Name = "System.Windows.Forms.Label2";
			this.Label2.Size = new System.Drawing.Size(72, 14);
			this.Label2.TabIndex = 9;
			// 
			// frmPayAppraisalSurveyQuestion
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.ClientSize = new System.Drawing.Size(579, 330);
			this.Controls.Add(this.txtDlblCategoryName);
			this.Controls.Add(this.txtAQuestion);
			this.Controls.Add(this.txtLQuestion);
			this.Controls.Add(this.txtQuestionCode);
			this.Controls.Add(this.lblCategoryNo);
			this.Controls.Add(this.lblPurposeArb);
			this.Controls.Add(this._cmbCommon_0);
			this.Controls.Add(this.Label1);
			this.Controls.Add(this.lblComments);
			this.Controls.Add(this.txtCategoryCode);
			this.Controls.Add(this.Label2);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			//this.Icon = (System.Drawing.Icon) resources.GetObject("frmPayAppraisalSurveyQuestion.Icon");
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(256, 97);
			this.MaximizeBox = true;
			this.MinimizeBox = true;
			this.Name = "frmPayAppraisalSurveyQuestion";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Survey Question";
			// this.Activated += new System.EventHandler(this.frmPayAppraisalSurveyQuestion_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
			// this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
			this.ResumeLayout(false);
		}
		// 
		void InitializecmbCommon()
		{
			this.cmbCommon = new System.Windows.Forms.ComboBox[1];
			this.cmbCommon[0] = _cmbCommon_0;
		}
		#endregion
	}
}//ENDSHERE
