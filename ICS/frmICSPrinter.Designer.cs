
namespace Xtreme
{
	partial class frmICSPrinter
	{

		#region "Upgrade Support "
		private static frmICSPrinter m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmICSPrinter DefInstance
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
		public static frmICSPrinter CreateInstance()
		{
			frmICSPrinter theInstance = new frmICSPrinter();
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
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "cmbPrinter", "txtPrinterNo", "lblGroupNo", "lblLGroupName", "txtLPrinterName", "lblAGroupName", "txtAPrinterName", "lblComments", "tcbSystemForm"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public System.Windows.Forms.ComboBox cmbPrinter;
		public System.Windows.Forms.TextBox txtPrinterNo;
		public System.Windows.Forms.Label lblGroupNo;
		public System.Windows.Forms.Label lblLGroupName;
		public System.Windows.Forms.TextBox txtLPrinterName;
		public System.Windows.Forms.Label lblAGroupName;
		public System.Windows.Forms.TextBox txtAPrinterName;
		public System.Windows.Forms.Label lblComments;
		public Syncfusion.Windows.Forms.Tools.CommandBarController tcbSystemForm;
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmICSPrinter));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this.cmbPrinter = new System.Windows.Forms.ComboBox();
			this.txtPrinterNo = new System.Windows.Forms.TextBox();
			this.lblGroupNo = new System.Windows.Forms.Label();
			this.lblLGroupName = new System.Windows.Forms.Label();
			this.txtLPrinterName = new System.Windows.Forms.TextBox();
			this.lblAGroupName = new System.Windows.Forms.Label();
			this.txtAPrinterName = new System.Windows.Forms.TextBox();
			this.lblComments = new System.Windows.Forms.Label();
			this.tcbSystemForm = new Syncfusion.Windows.Forms.Tools.CommandBarController();
			// //((System.ComponentModel.ISupportInitialize) this.tcbSystemForm).BeginInit();
			this.SuspendLayout();
			// 
			// cmbPrinter
			// 
			this.cmbPrinter.AllowDrop = true;
			this.cmbPrinter.Location = new System.Drawing.Point(128, 116);
			this.cmbPrinter.Name = "cmbPrinter";
			this.cmbPrinter.Size = new System.Drawing.Size(201, 21);
			this.cmbPrinter.TabIndex = 7;
			// 
			// txtPrinterNo
			// 
			this.txtPrinterNo.AllowDrop = true;
			this.txtPrinterNo.BackColor = System.Drawing.Color.White;
			this.txtPrinterNo.ForeColor = System.Drawing.Color.Black;
			this.txtPrinterNo.Location = new System.Drawing.Point(128, 52);
			this.txtPrinterNo.MaxLength = 15;
			// this.txtPrinterNo.mDropDownType = System.Windows.Forms.TextBox.DropDownTypes.ddtNextNumber;
			this.txtPrinterNo.Name = "txtPrinterNo";
			// this.txtPrinterNo.ShowButton = true;
			this.txtPrinterNo.Size = new System.Drawing.Size(101, 19);
			this.txtPrinterNo.TabIndex = 0;
			this.txtPrinterNo.Text = "";
			// 
			// lblGroupNo
			// 
			this.lblGroupNo.AllowDrop = true;
			this.lblGroupNo.BackColor = System.Drawing.Color.FromArgb(250, 244, 231);
			this.lblGroupNo.Text = "Printer Code";
			this.lblGroupNo.ForeColor = System.Drawing.Color.Black;
			this.lblGroupNo.Location = new System.Drawing.Point(10, 54);
			this.lblGroupNo.Name = "lblGroupNo";
			this.lblGroupNo.Size = new System.Drawing.Size(59, 14);
			this.lblGroupNo.TabIndex = 1;
			// 
			// lblLGroupName
			// 
			this.lblLGroupName.AllowDrop = true;
			this.lblLGroupName.BackColor = System.Drawing.Color.FromArgb(250, 244, 231);
			this.lblLGroupName.Text = "Printer Name (English)";
			this.lblLGroupName.ForeColor = System.Drawing.Color.Black;
			this.lblLGroupName.Location = new System.Drawing.Point(10, 75);
			this.lblLGroupName.Name = "lblLGroupName";
			this.lblLGroupName.Size = new System.Drawing.Size(106, 14);
			this.lblLGroupName.TabIndex = 2;
			// 
			// txtLPrinterName
			// 
			this.txtLPrinterName.AllowDrop = true;
			this.txtLPrinterName.BackColor = System.Drawing.Color.White;
			this.txtLPrinterName.ForeColor = System.Drawing.Color.Black;
			this.txtLPrinterName.Location = new System.Drawing.Point(128, 73);
			this.txtLPrinterName.MaxLength = 50;
			this.txtLPrinterName.Name = "txtLPrinterName";
			this.txtLPrinterName.Size = new System.Drawing.Size(201, 19);
			this.txtLPrinterName.TabIndex = 3;
			this.txtLPrinterName.Text = "";
			// 
			// lblAGroupName
			// 
			this.lblAGroupName.AllowDrop = true;
			this.lblAGroupName.BackColor = System.Drawing.Color.FromArgb(250, 244, 231);
			this.lblAGroupName.Text = "Printer Name (Arabic)";
			this.lblAGroupName.ForeColor = System.Drawing.Color.Black;
			this.lblAGroupName.Location = new System.Drawing.Point(10, 96);
			this.lblAGroupName.Name = "lblAGroupName";
			this.lblAGroupName.Size = new System.Drawing.Size(104, 14);
			this.lblAGroupName.TabIndex = 4;
			// 
			// txtAPrinterName
			// 
			this.txtAPrinterName.AllowDrop = true;
			this.txtAPrinterName.BackColor = System.Drawing.Color.White;
			this.txtAPrinterName.ForeColor = System.Drawing.Color.Black;
			this.txtAPrinterName.Location = new System.Drawing.Point(128, 94);
			// this.txtAPrinterName.mArabicEnabled = true;
			this.txtAPrinterName.MaxLength = 50;
			this.txtAPrinterName.Name = "txtAPrinterName";
			this.txtAPrinterName.Size = new System.Drawing.Size(201, 19);
			this.txtAPrinterName.TabIndex = 5;
			this.txtAPrinterName.Text = "";
			// 
			// lblComments
			// 
			this.lblComments.AllowDrop = true;
			this.lblComments.BackColor = System.Drawing.Color.FromArgb(250, 244, 231);
			this.lblComments.Text = "Printer Path";
			this.lblComments.ForeColor = System.Drawing.Color.Black;
			this.lblComments.Location = new System.Drawing.Point(10, 118);
			this.lblComments.Name = "lblComments";
			this.lblComments.Size = new System.Drawing.Size(55, 14);
			this.lblComments.TabIndex = 6;
			// 
			// tcbSystemForm
			// 
			this.tcbSystemForm.AllowDrop = true;
			this.tcbSystemForm.Location = new System.Drawing.Point(156, 2);
			this.tcbSystemForm.Name = "tcbSystemForm";
			("tcbSystemForm.OcxState");
			// 
			// frmICSPrinter
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.FromArgb(250, 244, 231);
			this.ClientSize = new System.Drawing.Size(429, 164);
			this.Controls.Add(this.cmbPrinter);
			this.Controls.Add(this.txtPrinterNo);
			this.Controls.Add(this.lblGroupNo);
			this.Controls.Add(this.lblLGroupName);
			this.Controls.Add(this.txtLPrinterName);
			this.Controls.Add(this.lblAGroupName);
			this.Controls.Add(this.txtAPrinterName);
			this.Controls.Add(this.lblComments);
			this.Controls.Add(this.tcbSystemForm);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			//this.Icon = (System.Drawing.Icon) resources.GetObject("frmICSPrinter.Icon");
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(258, 313);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmICSPrinter";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Printers";
			// this.Activated += new System.EventHandler(this.frmICSPrinter_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
			//((System.ComponentModel.ISupportInitialize) this.tcbSystemForm).EndInit();
			this.ResumeLayout(false);
		}
		// 
		#endregion
	}
}//ENDSHERE
