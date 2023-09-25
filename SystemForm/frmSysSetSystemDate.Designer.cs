
namespace Xtreme
{
	partial class frmSysSetSystemDate
	{

		#region "Upgrade Support "
		private static frmSysSetSystemDate m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmSysSetSystemDate DefInstance
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
		public static frmSysSetSystemDate CreateInstance()
		{
			frmSysSetSystemDate theInstance = new frmSysSetSystemDate();
			
			return theInstance;
		}
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "datePicker", "txtSystemDate", "System.Windows.Forms.Label1", "cmdOKCancel"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public Syncfusion.WinForms.Input.SfCalendar datePicker;
		public Syncfusion.WinForms.Input.SfDateTimeEdit txtSystemDate;
		public System.Windows.Forms.Label Label1;
		public UCOkCancel cmdOKCancel;
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSysSetSystemDate));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this.datePicker = new Syncfusion.WinForms.Input.SfCalendar();
			this.txtSystemDate = new Syncfusion.WinForms.Input.SfDateTimeEdit();
			this.Label1 = new System.Windows.Forms.Label();
			this.cmdOKCancel = new UCOkCancel();
			// //((System.ComponentModel.ISupportInitialize) this.datePicker).BeginInit();
			this.SuspendLayout();
			// 
			// datePicker
			// 
			this.datePicker.AllowDrop = true;
			this.datePicker.Location = new System.Drawing.Point(0, 0);
			this.datePicker.Name = "datePicker";
			("datePicker.OcxState");
			this.datePicker.Size = new System.Drawing.Size(201, 153);
			this.datePicker.TabIndex = 3;
			this.datePicker.DateClick += new AxXtremeSuiteControls._DMonthCalendarEvents_DateClickEventHandler(this.datePicker_DateClick);
			// 
			// txtSystemDate
			// 
			this.txtSystemDate.AllowDrop = true;
			this.txtSystemDate.Location = new System.Drawing.Point(111, 38);
			// this.txtSystemDate.MaxDate = 2958465;
			// this.txtSystemDate.MinDate = 2;
			this.txtSystemDate.Name = "txtSystemDate";
			this.txtSystemDate.Size = new System.Drawing.Size(90, 18);
			this.txtSystemDate.TabIndex = 0;
			// this.txtSystemDate.Text = "11/19/2011";
			this.txtSystemDate.Visible = false;
			// 
			// System.Windows.Forms.Label1
			// 
			this.Label1.AllowDrop = true;
			this.Label1.BackColor = System.Drawing.SystemColors.Window;
			this.Label1.Text = "Date";
			this.Label1.ForeColor = System.Drawing.Color.Black;
			this.Label1.Location = new System.Drawing.Point(74, 40);
			this.Label1.Name = "System.Windows.Forms.Label1";
			this.Label1.Size = new System.Drawing.Size(22, 14);
			this.Label1.TabIndex = 2;
			this.Label1.Visible = false;
			// 
			// cmdOKCancel
			// 
			this.cmdOKCancel.AllowDrop = true;
			this.cmdOKCancel.DisplayButton = 0;
			this.cmdOKCancel.Location = new System.Drawing.Point(43, 166);
			this.cmdOKCancel.Name = "cmdOKCancel";
			this.cmdOKCancel.OkCaption = "C&hange";
			this.cmdOKCancel.Size = new System.Drawing.Size(205, 29);
			this.cmdOKCancel.TabIndex = 1;
			this.cmdOKCancel.Visible = false;
			this.cmdOKCancel.CancelClick += new UCOkCancel.CancelClickHandler(this.cmdOKCancel_CancelClick);
			this.cmdOKCancel.OKClick += new UCOkCancel.OKClickHandler(this.cmdOKCancel_OKClick);
			// 
			// frmSysSetSystemDate
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.AppWorkspace;
			this.ClientSize = new System.Drawing.Size(201, 156);
			this.Controls.Add(this.datePicker);
			this.Controls.Add(this.txtSystemDate);
			this.Controls.Add(this.Label1);
			this.Controls.Add(this.cmdOKCancel);
			this.ForeColor = System.Drawing.Color.Silver;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			//this.Icon = (System.Drawing.Icon) resources.GetObject("frmSysSetSystemDate.Icon");
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(357, 266);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmSysSetSystemDate";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Set System Date";
			// this.Activated += new System.EventHandler(this.frmSysSetSystemDate_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
			// this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
			//((System.ComponentModel.ISupportInitialize) this.datePicker).EndInit();
			this.ResumeLayout(false);
		}
		#endregion
	}
}//ENDSHERE
