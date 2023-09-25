
namespace Xtreme
{
	partial class frmICSPriceList
	{

		#region "Upgrade Support "
		private static frmICSPriceList m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmICSPriceList DefInstance
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
		public static frmICSPriceList CreateInstance()
		{
			frmICSPriceList theInstance = new frmICSPriceList();
			
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
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "chkContinuous", "lblPListNameA", "txtAPListName", "lblDate", "txtLPListName", "txtpListNo", "lblPListNameL", "lblPListNo", "txtDDate", "UserEfectStart", "txtDEfectStartDate", "UserEfectEnd", "txtDEfectEndDate", "txtComment", "lblComment"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public System.Windows.Forms.CheckBox chkContinuous;
		public System.Windows.Forms.Label lblPListNameA;
		public System.Windows.Forms.TextBox txtAPListName;
		public System.Windows.Forms.Label lblDate;
		public System.Windows.Forms.TextBox txtLPListName;
		public System.Windows.Forms.TextBox txtpListNo;
		public System.Windows.Forms.Label lblPListNameL;
		public System.Windows.Forms.Label lblPListNo;
		public Syncfusion.WinForms.Input.SfDateTimeEdit txtDDate;
		public System.Windows.Forms.Label UserEfectStart;
		public Syncfusion.WinForms.Input.SfDateTimeEdit txtDEfectStartDate;
		public System.Windows.Forms.Label UserEfectEnd;
		public Syncfusion.WinForms.Input.SfDateTimeEdit txtDEfectEndDate;
		public System.Windows.Forms.TextBox txtComment;
		public System.Windows.Forms.Label lblComment;
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmICSPriceList));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this.chkContinuous = new System.Windows.Forms.CheckBox();
			this.lblPListNameA = new System.Windows.Forms.Label();
			this.txtAPListName = new System.Windows.Forms.TextBox();
			this.lblDate = new System.Windows.Forms.Label();
			this.txtLPListName = new System.Windows.Forms.TextBox();
			this.txtpListNo = new System.Windows.Forms.TextBox();
			this.lblPListNameL = new System.Windows.Forms.Label();
			this.lblPListNo = new System.Windows.Forms.Label();
			this.txtDDate = new Syncfusion.WinForms.Input.SfDateTimeEdit();
			this.UserEfectStart = new System.Windows.Forms.Label();
			this.txtDEfectStartDate = new Syncfusion.WinForms.Input.SfDateTimeEdit();
			this.UserEfectEnd = new System.Windows.Forms.Label();
			this.txtDEfectEndDate = new Syncfusion.WinForms.Input.SfDateTimeEdit();
			this.txtComment = new System.Windows.Forms.TextBox();
			this.lblComment = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// chkContinuous
			// 
			this.chkContinuous.AllowDrop = true;
			this.chkContinuous.Appearance = System.Windows.Forms.Appearance.Normal;
			this.chkContinuous.BackColor = System.Drawing.Color.White;
			this.chkContinuous.CausesValidation = true;
			this.chkContinuous.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkContinuous.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkContinuous.Enabled = true;
			this.chkContinuous.ForeColor = System.Drawing.Color.Black;
			this.chkContinuous.Location = new System.Drawing.Point(94, 140);
			this.chkContinuous.Name = "chkContinuous";
			this.chkContinuous.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.chkContinuous.Size = new System.Drawing.Size(74, 21);
			this.chkContinuous.TabIndex = 8;
			this.chkContinuous.TabStop = true;
			this.chkContinuous.Text = "Continuous";
			this.chkContinuous.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkContinuous.Visible = false;
			this.chkContinuous.CheckStateChanged += new System.EventHandler(this.chkContinuous_CheckStateChanged);
			// 
			// lblPListNameA
			// 
			this.lblPListNameA.AllowDrop = true;
			this.lblPListNameA.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblPListNameA.Text = "Name (Arabic)";
			this.lblPListNameA.Location = new System.Drawing.Point(10, 84);
			this.lblPListNameA.Name = "lblPListNameA";
			this.lblPListNameA.Size = new System.Drawing.Size(70, 14);
			this.lblPListNameA.TabIndex = 5;
			// 
			// txtAPListName
			// 
			this.txtAPListName.AllowDrop = true;
			this.txtAPListName.BackColor = System.Drawing.Color.White;
			this.txtAPListName.ForeColor = System.Drawing.Color.Black;
			this.txtAPListName.Location = new System.Drawing.Point(94, 82);
			// this.txtAPListName.mArabicEnabled = true;
			this.txtAPListName.MaxLength = 50;
			this.txtAPListName.Name = "txtAPListName";
			this.txtAPListName.Size = new System.Drawing.Size(253, 19);
			this.txtAPListName.TabIndex = 6;
			this.txtAPListName.Text = "";
			// 
			// lblDate
			// 
			this.lblDate.AllowDrop = true;
			this.lblDate.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblDate.Text = "Date";
			this.lblDate.Location = new System.Drawing.Point(10, 42);
			this.lblDate.Name = "lblDate";
			this.lblDate.Size = new System.Drawing.Size(22, 14);
			this.lblDate.TabIndex = 2;
			// 
			// txtLPListName
			// 
			this.txtLPListName.AllowDrop = true;
			this.txtLPListName.BackColor = System.Drawing.Color.White;
			this.txtLPListName.ForeColor = System.Drawing.Color.Black;
			this.txtLPListName.Location = new System.Drawing.Point(94, 61);
			this.txtLPListName.MaxLength = 50;
			this.txtLPListName.Name = "txtLPListName";
			this.txtLPListName.Size = new System.Drawing.Size(253, 19);
			this.txtLPListName.TabIndex = 4;
			this.txtLPListName.Text = "";
			// 
			// txtpListNo
			// 
			this.txtpListNo.AllowDrop = true;
			this.txtpListNo.BackColor = System.Drawing.Color.White;
			// this.txtpListNo.bolNumericOnly = true;
			this.txtpListNo.ForeColor = System.Drawing.Color.Black;
			this.txtpListNo.Location = new System.Drawing.Point(94, 19);
			this.txtpListNo.MaxLength = 4;
			// this.txtpListNo.mDropDownType = System.Windows.Forms.TextBox.DropDownTypes.ddtNextNumber;
			this.txtpListNo.Name = "txtpListNo";
			// this.txtpListNo.ShowButton = true;
			this.txtpListNo.Size = new System.Drawing.Size(101, 19);
			this.txtpListNo.TabIndex = 1;
			this.txtpListNo.Text = "";
			// 
			// lblPListNameL
			// 
			this.lblPListNameL.AllowDrop = true;
			this.lblPListNameL.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblPListNameL.Text = "Name (English)";
			this.lblPListNameL.Location = new System.Drawing.Point(10, 63);
			this.lblPListNameL.Name = "lblPListNameL";
			this.lblPListNameL.Size = new System.Drawing.Size(72, 14);
			this.lblPListNameL.TabIndex = 3;
			// 
			// lblPListNo
			// 
			this.lblPListNo.AllowDrop = true;
			this.lblPListNo.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblPListNo.Text = "Price Code";
			this.lblPListNo.Location = new System.Drawing.Point(10, 21);
			// this.lblPListNo.mLabelId = 834;
			this.lblPListNo.Name = "lblPListNo";
			this.lblPListNo.Size = new System.Drawing.Size(52, 14);
			this.lblPListNo.TabIndex = 0;
			// 
			// txtDDate
			// 
			this.txtDDate.AllowDrop = true;
			// this.txtDDate.CheckDateRange = false;
			this.txtDDate.Location = new System.Drawing.Point(94, 40);
			// this.txtDDate.MaxDate = 2958465;
			// this.txtDDate.MinDate = 32874;
			this.txtDDate.Name = "txtDDate";
			this.txtDDate.PromptChar = "_";
			this.txtDDate.Size = new System.Drawing.Size(102, 19);
			this.txtDDate.TabIndex = 7;
			this.txtDDate.Text = "12/1/2005";
			this.txtDDate.Value = 38687;
			// 
			// UserEfectStart
			// 
			this.UserEfectStart.AllowDrop = true;
			this.UserEfectStart.BackColor = System.Drawing.SystemColors.Window;
			this.UserEfectStart.Text = "Effect Start Date";
			this.UserEfectStart.Location = new System.Drawing.Point(8, 166);
			this.UserEfectStart.Name = "UserEfectStart";
			this.UserEfectStart.Size = new System.Drawing.Size(80, 14);
			this.UserEfectStart.TabIndex = 9;
			this.UserEfectStart.Visible = false;
			// 
			// txtDEfectStartDate
			// 
			this.txtDEfectStartDate.AllowDrop = true;
			this.txtDEfectStartDate.BackColor = System.Drawing.Color.FromArgb(239, 239, 239);
			// this.txtDEfectStartDate.CheckDateRange = false;
			this.txtDEfectStartDate.Enabled = false;
			this.txtDEfectStartDate.Location = new System.Drawing.Point(92, 164);
			// this.txtDEfectStartDate.MaxDate = 2958465;
			// this.txtDEfectStartDate.MinDate = 32874;
			this.txtDEfectStartDate.Name = "txtDEfectStartDate";
			this.txtDEfectStartDate.PromptChar = "_";
			this.txtDEfectStartDate.Size = new System.Drawing.Size(102, 19);
			this.txtDEfectStartDate.TabIndex = 10;
			this.txtDEfectStartDate.Text = "12/1/2005";
			this.txtDEfectStartDate.Value = 38687;
			this.txtDEfectStartDate.Visible = false;
			// 
			// UserEfectEnd
			// 
			this.UserEfectEnd.AllowDrop = true;
			this.UserEfectEnd.BackColor = System.Drawing.SystemColors.Window;
			this.UserEfectEnd.Text = "Effect End Date";
			this.UserEfectEnd.Location = new System.Drawing.Point(8, 188);
			this.UserEfectEnd.Name = "UserEfectEnd";
			this.UserEfectEnd.Size = new System.Drawing.Size(75, 14);
			this.UserEfectEnd.TabIndex = 11;
			this.UserEfectEnd.Visible = false;
			// 
			// txtDEfectEndDate
			// 
			this.txtDEfectEndDate.AllowDrop = true;
			this.txtDEfectEndDate.BackColor = System.Drawing.Color.FromArgb(239, 239, 239);
			// this.txtDEfectEndDate.CheckDateRange = false;
			this.txtDEfectEndDate.Enabled = false;
			this.txtDEfectEndDate.Location = new System.Drawing.Point(92, 186);
			// this.txtDEfectEndDate.MaxDate = 2958465;
			// this.txtDEfectEndDate.MinDate = 32874;
			this.txtDEfectEndDate.Name = "txtDEfectEndDate";
			this.txtDEfectEndDate.Size = new System.Drawing.Size(102, 19);
			this.txtDEfectEndDate.TabIndex = 12;
			this.txtDEfectEndDate.Text = "12/1/2005";
			this.txtDEfectEndDate.Value = 38687;
			this.txtDEfectEndDate.Visible = false;
			// 
			// txtComment
			// 
			this.txtComment.AllowDrop = true;
			this.txtComment.BackColor = System.Drawing.Color.White;
			this.txtComment.ForeColor = System.Drawing.Color.Black;
			this.txtComment.Location = new System.Drawing.Point(92, 208);
			this.txtComment.MaxLength = 100;
			this.txtComment.Name = "txtComment";
			this.txtComment.Size = new System.Drawing.Size(329, 19);
			this.txtComment.TabIndex = 13;
			this.txtComment.Text = "";
			this.txtComment.Visible = false;
			// 
			// lblComment
			// 
			this.lblComment.AllowDrop = true;
			this.lblComment.BackColor = System.Drawing.SystemColors.Window;
			this.lblComment.Text = "Comment";
			this.lblComment.Location = new System.Drawing.Point(8, 210);
			// this.lblComment.mLabelId = 836;
			this.lblComment.Name = "lblComment";
			this.lblComment.Size = new System.Drawing.Size(44, 14);
			this.lblComment.TabIndex = 14;
			this.lblComment.Visible = false;
			// 
			// frmICSPriceList
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.ClientSize = new System.Drawing.Size(509, 287);
			this.Controls.Add(this.chkContinuous);
			this.Controls.Add(this.lblPListNameA);
			this.Controls.Add(this.txtAPListName);
			this.Controls.Add(this.lblDate);
			this.Controls.Add(this.txtLPListName);
			this.Controls.Add(this.txtpListNo);
			this.Controls.Add(this.lblPListNameL);
			this.Controls.Add(this.lblPListNo);
			this.Controls.Add(this.txtDDate);
			this.Controls.Add(this.UserEfectStart);
			this.Controls.Add(this.txtDEfectStartDate);
			this.Controls.Add(this.UserEfectEnd);
			this.Controls.Add(this.txtDEfectEndDate);
			this.Controls.Add(this.txtComment);
			this.Controls.Add(this.lblComment);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			//this.Icon = (System.Drawing.Icon) resources.GetObject("frmICSPriceList.Icon");
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(212, 176);
			this.MaximizeBox = true;
			this.MinimizeBox = true;
			this.Name = "frmICSPriceList";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Price";
			// this.Activated += new System.EventHandler(this.frmICSPriceList_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
			// this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
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