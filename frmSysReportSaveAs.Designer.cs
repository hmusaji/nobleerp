
namespace Xtreme
{
	partial class frmSysReportSaveAs
	{

		#region "Upgrade Support "
		private static frmSysReportSaveAs m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmSysReportSaveAs DefInstance
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
		public static frmSysReportSaveAs CreateInstance()
		{
			frmSysReportSaveAs theInstance = new frmSysReportSaveAs();
			
			return theInstance;
		}
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "cmdOKCancel", "txtArabicName", "lblLocationCode", "txtEngName", "lblCompanyCode"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public UCOkCancel cmdOKCancel;
		public System.Windows.Forms.TextBox txtArabicName;
		public System.Windows.Forms.Label lblLocationCode;
		public System.Windows.Forms.TextBox txtEngName;
		public System.Windows.Forms.Label lblCompanyCode;
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSysReportSaveAs));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this.cmdOKCancel = new UCOkCancel();
			this.txtArabicName = new System.Windows.Forms.TextBox();
			this.lblLocationCode = new System.Windows.Forms.Label();
			this.txtEngName = new System.Windows.Forms.TextBox();
			this.lblCompanyCode = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// cmdOKCancel
			// 
			//this.cmdOKCancel.AllowDrop = true;
			this.cmdOKCancel.DisplayButton = 0;
			this.cmdOKCancel.Location = new System.Drawing.Point(107, 81);
			this.cmdOKCancel.Name = "cmdOKCancel";
			this.cmdOKCancel.OkCaption = "&Save";
			this.cmdOKCancel.Size = new System.Drawing.Size(206, 31);
			this.cmdOKCancel.TabIndex = 2;
			////this.cmdOKCancel.CancelClick += new UCOkCancel.CancelClickHandler(this.cmdOKCancel_CancelClick);
			////this.cmdOKCancel.OKClick += new UCOkCancel.OKClickHandler(this.cmdOKCancel_OKClick);
			// 
			// txtArabicName
			// 
			// //this.txtArabicName.Alignment = 1;
			//this.txtArabicName.AllowDrop = true;
			this.txtArabicName.BackColor = System.Drawing.Color.White;
			this.txtArabicName.ForeColor = System.Drawing.Color.Black;
			this.txtArabicName.Location = new System.Drawing.Point(104, 39);
			// // = true;
			this.txtArabicName.Name = "txtArabicName";
			this.txtArabicName.Size = new System.Drawing.Size(290, 19);
			this.txtArabicName.TabIndex = 1;
			this.txtArabicName.Text = "";
			// this.// = "";
			// 
			// lblLocationCode
			// 
			//this.lblLocationCode.AllowDrop = true;
			this.lblLocationCode.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblLocationCode.Text = "Arabic Name";
			this.lblLocationCode.Location = new System.Drawing.Point(8, 42);
			this.lblLocationCode.Name = "lblLocationCode";
			this.lblLocationCode.Size = new System.Drawing.Size(60, 13);
			this.lblLocationCode.TabIndex = 3;
			// 
			// txtEngName
			// 
			//this.txtEngName.AllowDrop = true;
			this.txtEngName.BackColor = System.Drawing.Color.White;
			this.txtEngName.ForeColor = System.Drawing.Color.Black;
			this.txtEngName.Location = new System.Drawing.Point(102, 16);
			this.txtEngName.Name = "txtEngName";
			this.txtEngName.Size = new System.Drawing.Size(290, 19);
			this.txtEngName.TabIndex = 0;
			this.txtEngName.Text = "";
			// this.// = "";
			// 
			// lblCompanyCode
			// 
			//this.lblCompanyCode.AllowDrop = true;
			this.lblCompanyCode.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblCompanyCode.Text = "English Name";
			this.lblCompanyCode.Location = new System.Drawing.Point(8, 19);
			this.lblCompanyCode.Name = "lblCompanyCode";
			this.lblCompanyCode.Size = new System.Drawing.Size(63, 13);
			this.lblCompanyCode.TabIndex = 4;
			// 
			// frmSysReportSaveAs
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.ClientSize = new System.Drawing.Size(405, 136);
			this.Controls.Add(this.cmdOKCancel);
			this.Controls.Add(this.txtArabicName);
			this.Controls.Add(this.lblLocationCode);
			this.Controls.Add(this.txtEngName);
			this.Controls.Add(this.lblCompanyCode);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Location = new System.Drawing.Point(181, 129);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmSysReportSaveAs";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Save As Report";
			// this.Activated += new System.EventHandler(this.frmSysReportSaveAs_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
			// this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
			this.ResumeLayout(false);
		}
		#endregion
	}
}//ENDSHERE
