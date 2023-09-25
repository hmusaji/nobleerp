
namespace Xtreme
{
	partial class frmPayLogReport
	{

		#region "Upgrade Support "
		private static frmPayLogReport m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmPayLogReport DefInstance
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
		public static frmPayLogReport CreateInstance()
		{
			frmPayLogReport theInstance = new frmPayLogReport();
			
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
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "cmbReports", "_txtDisplayLabel_0", "System.Windows.Forms.Label1", "System.Windows.Forms.Label2", "lblToDate", "lblFromDate", "_txtcommontextbox_0", "txtFromDate", "txtToDate", "cmdOKCancel", "txtDisplayLabel", "txtcommontextbox"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public System.Windows.Forms.ComboBox cmbReports;
		private System.Windows.Forms.Label _txtDisplayLabel_0;
		public System.Windows.Forms.LabelLabel1;
		public System.Windows.Forms.LabelLabel2;
		public System.Windows.Forms.Label lblToDate;
		public System.Windows.Forms.Label lblFromDate;
		private System.Windows.Forms.TextBox _txtcommontextbox_0;
		public Syncfusion.WinForms.Input.SfDateTimeEdit txtFromDate;
		public Syncfusion.WinForms.Input.SfDateTimeEdit txtToDate;
		public UCOkCancel cmdOKCancel;
		public System.Windows.Forms.Label[] txtDisplayLabel = new System.Windows.Forms.Label[1];
		public System.Windows.Forms.TextBox[] txtcommontextbox = new System.Windows.Forms.TextBox[1];
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPayLogReport));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this.cmbReports = new System.Windows.Forms.ComboBox();
			this._txtDisplayLabel_0 = new System.Windows.Forms.Label();
			this.Label1 = new System.Windows.Forms.Label();
			this.Label2 = new System.Windows.Forms.Label();
			this.lblToDate = new System.Windows.Forms.Label();
			this.lblFromDate = new System.Windows.Forms.Label();
			this._txtcommontextbox_0 = new System.Windows.Forms.TextBox();
			this.txtFromDate = new Syncfusion.WinForms.Input.SfDateTimeEdit();
			this.txtToDate = new Syncfusion.WinForms.Input.SfDateTimeEdit();
			this.cmdOKCancel = new UCOkCancel();
			this.SuspendLayout();
			// 
			// cmbReports
			// 
			this.cmbReports.AllowDrop = true;
			this.cmbReports.BackColor = System.Drawing.SystemColors.Window;
			this.cmbReports.CausesValidation = true;
			this.cmbReports.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			this.cmbReports.Enabled = true;
			this.cmbReports.ForeColor = System.Drawing.SystemColors.WindowText;
			this.cmbReports.IntegralHeight = true;
			this.cmbReports.Location = new System.Drawing.Point(84, 40);
			this.cmbReports.Name = "cmbReports";
			this.cmbReports.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmbReports.Size = new System.Drawing.Size(229, 21);
			this.cmbReports.Sorted = false;
			this.cmbReports.TabIndex = 5;
			this.cmbReports.TabStop = true;
			this.cmbReports.Visible = true;
			// 
			// _txtDisplayLabel_0
			// 
			this._txtDisplayLabel_0.AllowDrop = true;
			this._txtDisplayLabel_0.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			this._txtDisplayLabel_0.Enabled = false;
			this._txtDisplayLabel_0.Location = new System.Drawing.Point(165, 113);
			this._txtDisplayLabel_0.Name = "_txtDisplayLabel_0";
			this._txtDisplayLabel_0.Size = new System.Drawing.Size(148, 22);
			this._txtDisplayLabel_0.TabIndex = 2;
			this._txtDisplayLabel_0.Visible = false;
			// 
			// System.Windows.Forms.Label1
			// 
			this.Label1.AllowDrop = true;
			this.Label1.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.Label1.Text = "Employee Code";
			this.Label1.ForeColor = System.Drawing.SystemColors.WindowText;
			this.Label1.Location = new System.Drawing.Point(4, 117);
			this.Label1.Name = "System.Windows.Forms.Label1";
			this.Label1.Size = new System.Drawing.Size(74, 14);
			this.Label1.TabIndex = 0;
			this.Label1.Visible = false;
			// 
			// System.Windows.Forms.Label2
			// 
			this.Label2.AllowDrop = true;
			this.Label2.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.Label2.Text = "Log For";
			this.Label2.ForeColor = System.Drawing.SystemColors.WindowText;
			this.Label2.Location = new System.Drawing.Point(8, 43);
			this.Label2.Name = "System.Windows.Forms.Label2";
			this.Label2.Size = new System.Drawing.Size(37, 14);
			this.Label2.TabIndex = 1;
			// 
			// lblToDate
			// 
			this.lblToDate.AllowDrop = true;
			this.lblToDate.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblToDate.Text = "To Date";
			this.lblToDate.ForeColor = System.Drawing.Color.Black;
			this.lblToDate.Location = new System.Drawing.Point(8, 88);
			this.lblToDate.Name = "lblToDate";
			this.lblToDate.Size = new System.Drawing.Size(38, 13);
			this.lblToDate.TabIndex = 3;
			// 
			// lblFromDate
			// 
			this.lblFromDate.AllowDrop = true;
			this.lblFromDate.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblFromDate.Text = "From Date";
			this.lblFromDate.ForeColor = System.Drawing.Color.Black;
			this.lblFromDate.Location = new System.Drawing.Point(8, 67);
			this.lblFromDate.Name = "lblFromDate";
			this.lblFromDate.Size = new System.Drawing.Size(50, 13);
			this.lblFromDate.TabIndex = 4;
			// 
			// _txtcommontextbox_0
			// 
			this._txtcommontextbox_0.AllowDrop = true;
			this._txtcommontextbox_0.BackColor = System.Drawing.Color.White;
			// this._txtcommontextbox_0.bolAllowDecimal = false;
			this._txtcommontextbox_0.ForeColor = System.Drawing.Color.Black;
			this._txtcommontextbox_0.Location = new System.Drawing.Point(84, 114);
			// this._txtcommontextbox_0.mDropDownType = (System.Windows.Forms.TextBox.DropDownTypes) 0;
			this._txtcommontextbox_0.Name = "_txtcommontextbox_0";
			// this._txtcommontextbox_0.ShowButton = true;
			this._txtcommontextbox_0.Size = new System.Drawing.Size(79, 19);
			this._txtcommontextbox_0.TabIndex = 6;
			this._txtcommontextbox_0.Text = "";
			this._txtcommontextbox_0.Visible = false;
			// this.this._txtcommontextbox_0.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtcommontextbox_DropButtonClick);
			// this._txtcommontextbox_0.Leave += new System.EventHandler(this.txtCommonTextBox_Leave);
			// 
			// txtFromDate
			// 
			this.txtFromDate.AllowDrop = true;
			// this.txtFromDate.CheckDateRange = false;
			this.txtFromDate.Location = new System.Drawing.Point(84, 64);
			// this.txtFromDate.MaxDate = 2958465;
			// this.txtFromDate.MinDate = 2;
			this.txtFromDate.Name = "txtFromDate";
			this.txtFromDate.Size = new System.Drawing.Size(229, 19);
			this.txtFromDate.TabIndex = 7;
			this.txtFromDate.Text = "18/07/2001";
			// this.txtFromDate.Value = 37090;
			// 
			// txtToDate
			// 
			this.txtToDate.AllowDrop = true;
			// this.txtToDate.CheckDateRange = false;
			this.txtToDate.Location = new System.Drawing.Point(84, 85);
			// this.txtToDate.MaxDate = 2958465;
			// this.txtToDate.MinDate = 2;
			this.txtToDate.Name = "txtToDate";
			this.txtToDate.Size = new System.Drawing.Size(229, 19);
			this.txtToDate.TabIndex = 8;
			this.txtToDate.Text = "18/07/2001";
			// this.txtToDate.Value = 37090;
			// 
			// cmdOKCancel
			// 
			this.cmdOKCancel.AllowDrop = true;
			this.cmdOKCancel.Location = new System.Drawing.Point(80, 152);
			this.cmdOKCancel.Name = "cmdOKCancel";
			this.cmdOKCancel.OkCaption = "&Ok";
			this.cmdOKCancel.Size = new System.Drawing.Size(205, 29);
			this.cmdOKCancel.TabIndex = 9;
			this.cmdOKCancel.CancelClick += new UCOkCancel.CancelClickHandler(this.cmdOKCancel_CancelClick);
			this.cmdOKCancel.OKClick += new UCOkCancel.OKClickHandler(this.cmdOKCancel_OKClick);
			// 
			// frmPayLogReport
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.ClientSize = new System.Drawing.Size(321, 200);
			this.Controls.Add(this.cmbReports);
			this.Controls.Add(this._txtDisplayLabel_0);
			this.Controls.Add(this.Label1);
			this.Controls.Add(this.Label2);
			this.Controls.Add(this.lblToDate);
			this.Controls.Add(this.lblFromDate);
			this.Controls.Add(this._txtcommontextbox_0);
			this.Controls.Add(this.txtFromDate);
			this.Controls.Add(this.txtToDate);
			this.Controls.Add(this.cmdOKCancel);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			//this.Icon = (System.Drawing.Icon) resources.GetObject("frmPayLogReport.Icon");
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(362, 224);
			this.MaximizeBox = true;
			this.MinimizeBox = true;
			this.Name = "frmPayLogReport";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Log Report";
			// this.Activated += new System.EventHandler(this.frmPayLogReport_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
			this.ResumeLayout(false);
		}
		void ReLoadForm(bool addEvents)
		{
			Initializetxtcommontextbox();
			InitializetxtDisplayLabel();
			//This form is an MDI child.
			//This code simulates the VB6 
			// functionality of automatically
			// loading and showing an MDI
			// child's parent.
			this.MdiParent = Xtreme.frmSysMain.DefInstance;
			Xtreme.frmSysMain.DefInstance.Show();
		}
		void Initializetxtcommontextbox()
		{
			this.txtcommontextbox = new System.Windows.Forms.TextBox[1];
			this.txtcommontextbox[0] = _txtcommontextbox_0;
		}
		void InitializetxtDisplayLabel()
		{
			this.txtDisplayLabel = new System.Windows.Forms.Label[1];
			this.txtDisplayLabel[0] = _txtDisplayLabel_0;
		}
		#endregion
	}
}//ENDSHERE
