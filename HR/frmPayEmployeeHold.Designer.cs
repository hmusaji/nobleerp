
namespace Xtreme
{
	partial class frmPayEmployeeHold
	{

		#region "Upgrade Support "
		private static frmPayEmployeeHold m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmPayEmployeeHold DefInstance
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
		public static frmPayEmployeeHold CreateInstance()
		{
			frmPayEmployeeHold theInstance = new frmPayEmployeeHold();
			
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
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "txtComment", "_lblCommonLabel_2", "_lblCommonLabel_0", "_lblCommonLabel_1", "_txtCommonTextBox_1", "_txtDisplayLabel_4", "_txtDisplayLabel_3", "_txtDisplayLabel_2", "_txtDisplayLabel_1", "_txtDisplayLabel_0", "_lblCommonLabel_3", "txtStartDate", "_lblCommonLabel_4", "txtResumeDate", "lblComments", "lblCommonLabel", "txtCommonTextBox", "txtDisplayLabel"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public System.Windows.Forms.TextBox txtComment;
		private System.Windows.Forms.Label _lblCommonLabel_2;
		private System.Windows.Forms.Label _lblCommonLabel_0;
		private System.Windows.Forms.Label _lblCommonLabel_1;
		private System.Windows.Forms.TextBox _txtCommonTextBox_1;
		private System.Windows.Forms.Label _txtDisplayLabel_4;
		private System.Windows.Forms.Label _txtDisplayLabel_3;
		private System.Windows.Forms.Label _txtDisplayLabel_2;
		private System.Windows.Forms.Label _txtDisplayLabel_1;
		private System.Windows.Forms.Label _txtDisplayLabel_0;
		private System.Windows.Forms.Label _lblCommonLabel_3;
		public Syncfusion.WinForms.Input.SfDateTimeEdit txtStartDate;
		private System.Windows.Forms.Label _lblCommonLabel_4;
		public Syncfusion.WinForms.Input.SfDateTimeEdit txtResumeDate;
		public System.Windows.Forms.Label lblComments;
		public System.Windows.Forms.Label[] lblCommonLabel = new System.Windows.Forms.Label[5];
		public System.Windows.Forms.TextBox[] txtCommonTextBox = new System.Windows.Forms.TextBox[2];
		public System.Windows.Forms.Label[] txtDisplayLabel = new System.Windows.Forms.Label[5];
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPayEmployeeHold));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this.txtComment = new System.Windows.Forms.TextBox();
			this._lblCommonLabel_2 = new System.Windows.Forms.Label();
			this._lblCommonLabel_0 = new System.Windows.Forms.Label();
			this._lblCommonLabel_1 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_1 = new System.Windows.Forms.TextBox();
			this._txtDisplayLabel_4 = new System.Windows.Forms.Label();
			this._txtDisplayLabel_3 = new System.Windows.Forms.Label();
			this._txtDisplayLabel_2 = new System.Windows.Forms.Label();
			this._txtDisplayLabel_1 = new System.Windows.Forms.Label();
			this._txtDisplayLabel_0 = new System.Windows.Forms.Label();
			this._lblCommonLabel_3 = new System.Windows.Forms.Label();
			this.txtStartDate = new Syncfusion.WinForms.Input.SfDateTimeEdit();
			this._lblCommonLabel_4 = new System.Windows.Forms.Label();
			this.txtResumeDate = new Syncfusion.WinForms.Input.SfDateTimeEdit();
			this.lblComments = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// txtComment
			// 
			//this.txtComment.AllowDrop = true;
			this.txtComment.BackColor = System.Drawing.Color.White;
			// // = false;
			this.txtComment.ForeColor = System.Drawing.Color.Black;
			this.txtComment.Location = new System.Drawing.Point(90, 120);
			// // = (System.Windows.Forms.TextBox.DropDownTypes) 0;
			this.txtComment.Name = "txtComment";
			this.txtComment.Size = new System.Drawing.Size(397, 21);
			this.txtComment.TabIndex = 14;
			this.txtComment.Text = "";
			// 
			// _lblCommonLabel_2
			// 
			//this._lblCommonLabel_2.AllowDrop = true;
			this._lblCommonLabel_2.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_2.Text = "Employee Code";
			this._lblCommonLabel_2.Location = new System.Drawing.Point(4, 58);
			// // this._lblCommonLabel_2.mLabelId = 236;
			this._lblCommonLabel_2.Name = "_lblCommonLabel_2";
			this._lblCommonLabel_2.Size = new System.Drawing.Size(74, 14);
			this._lblCommonLabel_2.TabIndex = 0;
			// 
			// _lblCommonLabel_0
			// 
			//this._lblCommonLabel_0.AllowDrop = true;
			this._lblCommonLabel_0.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_0.Text = "Department Code";
			this._lblCommonLabel_0.Location = new System.Drawing.Point(4, 79);
			// // this._lblCommonLabel_0.mLabelId = 1973;
			this._lblCommonLabel_0.Name = "_lblCommonLabel_0";
			this._lblCommonLabel_0.Size = new System.Drawing.Size(83, 14);
			this._lblCommonLabel_0.TabIndex = 1;
			// 
			// _lblCommonLabel_1
			// 
			//this._lblCommonLabel_1.AllowDrop = true;
			this._lblCommonLabel_1.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_1.Text = "Designation Code";
			this._lblCommonLabel_1.Location = new System.Drawing.Point(4, 100);
			// // this._lblCommonLabel_1.mLabelId = 1049;
			this._lblCommonLabel_1.Name = "_lblCommonLabel_1";
			this._lblCommonLabel_1.Size = new System.Drawing.Size(84, 14);
			this._lblCommonLabel_1.TabIndex = 2;
			// 
			// _txtCommonTextBox_1
			// 
			//this._txtCommonTextBox_1.AllowDrop = true;
			this._txtCommonTextBox_1.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_1.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_1.Location = new System.Drawing.Point(90, 56);
			this._txtCommonTextBox_1.MaxLength = 10;
			this._txtCommonTextBox_1.Name = "_txtCommonTextBox_1";
			// this._txtCommonTextBox_1.ShowButton = true;
			this._txtCommonTextBox_1.Size = new System.Drawing.Size(101, 19);
			this._txtCommonTextBox_1.TabIndex = 3;
			this._txtCommonTextBox_1.Text = "";
			// this.//this._txtCommonTextBox_1.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(//this.txtCommonTextBox_DropButtonClick);
			// this._txtCommonTextBox_1.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// _txtDisplayLabel_4
			// 
			//this._txtDisplayLabel_4.AllowDrop = true;
			this._txtDisplayLabel_4.Location = new System.Drawing.Point(193, 56);
			this._txtDisplayLabel_4.Name = "_txtDisplayLabel_4";
			this._txtDisplayLabel_4.Size = new System.Drawing.Size(295, 19);
			this._txtDisplayLabel_4.TabIndex = 4;
			this._txtDisplayLabel_4.TabStop = false;
			// 
			// _txtDisplayLabel_3
			// 
			//this._txtDisplayLabel_3.AllowDrop = true;
			this._txtDisplayLabel_3.Location = new System.Drawing.Point(193, 98);
			this._txtDisplayLabel_3.Name = "_txtDisplayLabel_3";
			this._txtDisplayLabel_3.Size = new System.Drawing.Size(295, 19);
			this._txtDisplayLabel_3.TabIndex = 5;
			this._txtDisplayLabel_3.TabStop = false;
			// 
			// _txtDisplayLabel_2
			// 
			//this._txtDisplayLabel_2.AllowDrop = true;
			this._txtDisplayLabel_2.Location = new System.Drawing.Point(90, 98);
			this._txtDisplayLabel_2.Name = "_txtDisplayLabel_2";
			this._txtDisplayLabel_2.Size = new System.Drawing.Size(101, 19);
			this._txtDisplayLabel_2.TabIndex = 6;
			this._txtDisplayLabel_2.TabStop = false;
			// 
			// _txtDisplayLabel_1
			// 
			//this._txtDisplayLabel_1.AllowDrop = true;
			this._txtDisplayLabel_1.Location = new System.Drawing.Point(193, 77);
			this._txtDisplayLabel_1.Name = "_txtDisplayLabel_1";
			this._txtDisplayLabel_1.Size = new System.Drawing.Size(295, 19);
			this._txtDisplayLabel_1.TabIndex = 7;
			this._txtDisplayLabel_1.TabStop = false;
			// 
			// _txtDisplayLabel_0
			// 
			//this._txtDisplayLabel_0.AllowDrop = true;
			this._txtDisplayLabel_0.Location = new System.Drawing.Point(90, 77);
			this._txtDisplayLabel_0.Name = "_txtDisplayLabel_0";
			this._txtDisplayLabel_0.Size = new System.Drawing.Size(101, 19);
			this._txtDisplayLabel_0.TabIndex = 8;
			this._txtDisplayLabel_0.TabStop = false;
			// 
			// _lblCommonLabel_3
			// 
			//this._lblCommonLabel_3.AllowDrop = true;
			this._lblCommonLabel_3.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_3.Text = "Start Date";
			this._lblCommonLabel_3.Location = new System.Drawing.Point(4, 146);
			// // this._lblCommonLabel_3.mLabelId = 1703;
			this._lblCommonLabel_3.Name = "_lblCommonLabel_3";
			this._lblCommonLabel_3.Size = new System.Drawing.Size(48, 14);
			this._lblCommonLabel_3.TabIndex = 9;
			// 
			// txtStartDate
			// 
			//this.txtStartDate.AllowDrop = true;
			this.txtStartDate.BackColor = System.Drawing.Color.White;
			this.txtStartDate.CausesValidation = false;
			// this.txtStartDate.CheckDateRange = false;
			this.txtStartDate.Location = new System.Drawing.Point(90, 142);
			// this.txtStartDate.MaxDate = 2958465;
			// this.txtStartDate.MinDate = -657434;
			this.txtStartDate.Name = "txtStartDate";
			//// = "_";
			this.txtStartDate.Size = new System.Drawing.Size(143, 21);
			this.txtStartDate.TabIndex = 10;
			// this.txtStartDate.Text = "09/02/2013";
			// 
			// _lblCommonLabel_4
			// 
			//this._lblCommonLabel_4.AllowDrop = true;
			this._lblCommonLabel_4.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_4.Text = "Resume Date";
			this._lblCommonLabel_4.Location = new System.Drawing.Point(256, 146);
			// // this._lblCommonLabel_4.mLabelId = 1132;
			this._lblCommonLabel_4.Name = "_lblCommonLabel_4";
			this._lblCommonLabel_4.Size = new System.Drawing.Size(64, 14);
			this._lblCommonLabel_4.TabIndex = 11;
			this._lblCommonLabel_4.Visible = false;
			// 
			// txtResumeDate
			// 
			//this.txtResumeDate.AllowDrop = true;
			this.txtResumeDate.BackColor = System.Drawing.Color.White;
			this.txtResumeDate.CausesValidation = false;
			// this.txtResumeDate.CheckDateRange = false;
			this.txtResumeDate.Location = new System.Drawing.Point(346, 142);
			// this.txtResumeDate.MaxDate = 2958465;
			// this.txtResumeDate.MinDate = -657434;
			this.txtResumeDate.Name = "txtResumeDate";
			// = "_";
			this.txtResumeDate.Size = new System.Drawing.Size(141, 21);
			this.txtResumeDate.TabIndex = 12;
			// this.txtResumeDate.Text = "09/02/2013";
			this.txtResumeDate.Visible = false;
			// 
			// lblComments
			// 
			//this.lblComments.AllowDrop = true;
			this.lblComments.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblComments.Text = "Comment";
			this.lblComments.Location = new System.Drawing.Point(4, 120);
			// // this.lblComments.mLabelId = 1851;
			this.lblComments.Name = "lblComments";
			this.lblComments.Size = new System.Drawing.Size(44, 14);
			this.lblComments.TabIndex = 13;
			// 
			// frmPayEmployeeHold
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.ClientSize = new System.Drawing.Size(503, 190);
			this.Controls.Add(this.txtComment);
			this.Controls.Add(this._lblCommonLabel_2);
			this.Controls.Add(this._lblCommonLabel_0);
			this.Controls.Add(this._lblCommonLabel_1);
			this.Controls.Add(this._txtCommonTextBox_1);
			this.Controls.Add(this._txtDisplayLabel_4);
			this.Controls.Add(this._txtDisplayLabel_3);
			this.Controls.Add(this._txtDisplayLabel_2);
			this.Controls.Add(this._txtDisplayLabel_1);
			this.Controls.Add(this._txtDisplayLabel_0);
			this.Controls.Add(this._lblCommonLabel_3);
			this.Controls.Add(this.txtStartDate);
			this.Controls.Add(this._lblCommonLabel_4);
			this.Controls.Add(this.txtResumeDate);
			this.Controls.Add(this.lblComments);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			//this.Icon = (System.Drawing.Icon) resources.GetObject("frmPayEmployeeHold.Icon");
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(189, 136);
			this.MaximizeBox = true;
			this.MinimizeBox = true;
			this.Name = "frmPayEmployeeHold";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Employee Hold";
			// this.Activated += new System.EventHandler(this.frmPayEmployeeHold_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
			// this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
			this.ResumeLayout(false);
		}
		// 
		void InitializetxtDisplayLabel()
		{
			this.txtDisplayLabel = new System.Windows.Forms.Label[5];
			this.txtDisplayLabel[4] = _txtDisplayLabel_4;
			this.txtDisplayLabel[3] = _txtDisplayLabel_3;
			this.txtDisplayLabel[2] = _txtDisplayLabel_2;
			this.txtDisplayLabel[1] = _txtDisplayLabel_1;
			this.txtDisplayLabel[0] = _txtDisplayLabel_0;
		}
		void InitializetxtCommonTextBox()
		{
			this.txtCommonTextBox = new System.Windows.Forms.TextBox[2];
			this.txtCommonTextBox[1] = _txtCommonTextBox_1;
		}
		void InitializelblCommonLabel()
		{
			this.lblCommonLabel = new System.Windows.Forms.Label[5];
			this.lblCommonLabel[2] = _lblCommonLabel_2;
			this.lblCommonLabel[0] = _lblCommonLabel_0;
			this.lblCommonLabel[1] = _lblCommonLabel_1;
			this.lblCommonLabel[3] = _lblCommonLabel_3;
			this.lblCommonLabel[4] = _lblCommonLabel_4;
		}
		#endregion
	}
}//ENDSHERE
