
namespace Xtreme
{
	partial class frmREMonthClosing
	{

		#region "Upgrade Support "
		private static frmREMonthClosing m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmREMonthClosing DefInstance
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
		public static frmREMonthClosing CreateInstance()
		{
			frmREMonthClosing theInstance = new frmREMonthClosing();
			
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
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "txtOkCancel", "txtMonthEndDate", "_lblCommon_0", "_lblCommon_1", "Line1", "lblNoticeText", "lblCommon"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public UCOkCancel txtOkCancel;
		public Syncfusion.WinForms.Input.SfDateTimeEdit txtMonthEndDate;
		private System.Windows.Forms.Label _lblCommon_0;
		private System.Windows.Forms.Label _lblCommon_1;
		public System.Windows.Forms.Label Line1;
		public System.Windows.Forms.Label lblNoticeText;
		public System.Windows.Forms.Label[] lblCommon = new System.Windows.Forms.Label[2];
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmREMonthClosing));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this.txtOkCancel = new UCOkCancel();
			this.txtMonthEndDate = new Syncfusion.WinForms.Input.SfDateTimeEdit();
			this._lblCommon_0 = new System.Windows.Forms.Label();
			this._lblCommon_1 = new System.Windows.Forms.Label();
			this.Line1 = new System.Windows.Forms.Label();
			this.lblNoticeText = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// txtOkCancel
			// 
			this.txtOkCancel.AllowDrop = true;
			this.txtOkCancel.DisplayButton = 0;
			this.txtOkCancel.Location = new System.Drawing.Point(62, 70);
			this.txtOkCancel.Name = "txtOkCancel";
			this.txtOkCancel.OkCaption = "Close &Month";
			this.txtOkCancel.Size = new System.Drawing.Size(206, 31);
			this.txtOkCancel.TabIndex = 0;
			this.txtOkCancel.CancelClick += new UCOkCancel.CancelClickHandler(this.txtOkCancel_CancelClick);
			this.txtOkCancel.OKClick += new UCOkCancel.OKClickHandler(this.txtOkCancel_OKClick);
			// 
			// txtMonthEndDate
			// 
			this.txtMonthEndDate.AllowDrop = true;
			this.txtMonthEndDate.BackColor = System.Drawing.Color.FromArgb(239, 239, 239);
			// this.txtMonthEndDate.CheckDateRange = false;
			this.txtMonthEndDate.Enabled = false;
			this.txtMonthEndDate.Location = new System.Drawing.Point(164, 22);
			// this.txtMonthEndDate.MaxDate = 2958465;
			// this.txtMonthEndDate.MinDate = 2;
			this.txtMonthEndDate.Name = "txtMonthEndDate";
			this.txtMonthEndDate.ReadOnly = true;
			this.txtMonthEndDate.Size = new System.Drawing.Size(101, 19);
			this.txtMonthEndDate.TabIndex = 1;
			this.txtMonthEndDate.Text = "13/02/2014";
			// 
			// _lblCommon_0
			// 
			this._lblCommon_0.AllowDrop = true;
			this._lblCommon_0.BackColor = System.Drawing.Color.FromArgb(224, 230, 237);
			this._lblCommon_0.Text = "Month Ending On :";
			this._lblCommon_0.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_0.Location = new System.Drawing.Point(62, 24);
			// this._lblCommon_0.mLabelId = 1183;
			this._lblCommon_0.Name = "_lblCommon_0";
			this._lblCommon_0.Size = new System.Drawing.Size(87, 14);
			this._lblCommon_0.TabIndex = 2;
			// 
			// _lblCommon_1
			// 
			this._lblCommon_1.AllowDrop = true;
			this._lblCommon_1.BackColor = System.Drawing.Color.FromArgb(224, 230, 237);
			this._lblCommon_1.Text = "C a u t i o n :";
			this._lblCommon_1.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_1.Location = new System.Drawing.Point(7, 134);
			// this._lblCommon_1.mLabelId = 1184;
			this._lblCommon_1.Name = "_lblCommon_1";
			this._lblCommon_1.Size = new System.Drawing.Size(62, 13);
			this._lblCommon_1.TabIndex = 3;
			// 
			// Line1
			// 
			this.Line1.AllowDrop = true;
			this.Line1.BackColor = System.Drawing.Color.Black;
			this.Line1.Enabled = false;
			this.Line1.Location = new System.Drawing.Point(72, 140);
			this.Line1.Name = "Line1";
			this.Line1.Size = new System.Drawing.Size(290, 1);
			this.Line1.Visible = true;
			// 
			// lblNoticeText
			// 
			this.lblNoticeText.AllowDrop = true;
			this.lblNoticeText.BackColor = System.Drawing.Color.FromArgb(255, 106, 106);
			this.lblNoticeText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblNoticeText.ForeColor = System.Drawing.Color.Black;
			this.lblNoticeText.Location = new System.Drawing.Point(7, 150);
			this.lblNoticeText.Name = "lblNoticeText";
			this.lblNoticeText.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblNoticeText.Size = new System.Drawing.Size(317, 55);
			this.lblNoticeText.TabIndex = 4;
			this.lblNoticeText.Text = "Running month end process will post all the active contracts, receipts and charges in the system.";
			// 
			// frmREMonthClosing
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.ClientSize = new System.Drawing.Size(329, 208);
			this.Controls.Add(this.txtOkCancel);
			this.Controls.Add(this.txtMonthEndDate);
			this.Controls.Add(this._lblCommon_0);
			this.Controls.Add(this._lblCommon_1);
			this.Controls.Add(this.Line1);
			this.Controls.Add(this.lblNoticeText);
			//this.Icon = (System.Drawing.Icon) resources.GetObject("frmREMonthClosing.Icon");
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(77, 146);
			this.MaximizeBox = true;
			this.MinimizeBox = true;
			this.Name = "frmREMonthClosing";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Month End Process";
			// this.Activated += new System.EventHandler(this.frmREMonthClosing_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
			// this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
			this.ResumeLayout(false);
		}
		void ReLoadForm(bool addEvents)
		{
			InitializelblCommon();
			//This form is an MDI child.
			//This code simulates the VB6 
			// functionality of automatically
			// loading and showing an MDI
			// child's parent.
			this.MdiParent = Xtreme.frmSysMain.DefInstance;
			Xtreme.frmSysMain.DefInstance.Show();
		}
		void InitializelblCommon()
		{
			this.lblCommon = new System.Windows.Forms.Label[2];
			this.lblCommon[0] = _lblCommon_0;
			this.lblCommon[1] = _lblCommon_1;
		}
		#endregion
	}
}