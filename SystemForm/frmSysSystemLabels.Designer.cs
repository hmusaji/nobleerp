
namespace Xtreme
{
	partial class frmSysSystemLabels
	{

		#region "Upgrade Support "
		private static frmSysSystemLabels m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmSysSystemLabels DefInstance
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
		public static frmSysSystemLabels CreateInstance()
		{
			frmSysSystemLabels theInstance = new frmSysSystemLabels();
			
			return theInstance;
		}
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "cmdOKCancel", "lblUserID", "txtArabicName", "lblLocationCode", "txtEngName", "lblCompanyCode", "lblLableId", "System.Windows.Forms.Label1", "txtModuleId"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public UCOkCancel cmdOKCancel;
		public System.Windows.Forms.Label lblUserID;
		public System.Windows.Forms.TextBox txtArabicName;
		public System.Windows.Forms.Label lblLocationCode;
		public System.Windows.Forms.TextBox txtEngName;
		public System.Windows.Forms.Label lblCompanyCode;
		public System.Windows.Forms.Label lblLableId;
		public System.Windows.Forms.Label Label1;
		public System.Windows.Forms.TextBox txtModuleId;
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSysSystemLabels));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this.cmdOKCancel = new UCOkCancel();
			this.lblUserID = new System.Windows.Forms.Label();
			this.txtArabicName = new System.Windows.Forms.TextBox();
			this.lblLocationCode = new System.Windows.Forms.Label();
			this.txtEngName = new System.Windows.Forms.TextBox();
			this.lblCompanyCode = new System.Windows.Forms.Label();
			this.lblLableId = new System.Windows.Forms.Label();
			this.Label1 = new System.Windows.Forms.Label();
			this.txtModuleId = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// cmdOKCancel
			// 
			this.cmdOKCancel.AllowDrop = true;
			this.cmdOKCancel.DisplayButton = 0;
			this.cmdOKCancel.Location = new System.Drawing.Point(97, 102);
			this.cmdOKCancel.Name = "cmdOKCancel";
			this.cmdOKCancel.OkCaption = "&Save";
			this.cmdOKCancel.Size = new System.Drawing.Size(206, 31);
			this.cmdOKCancel.TabIndex = 3;
			//this.cmdOKCancel.CancelClick += new UCOkCancel.CancelClickHandler(this.cmdOKCancel_CancelClick);
			//this.cmdOKCancel.OKClick += new UCOkCancel.OKClickHandler(this.cmdOKCancel_OKClick);
			// 
			// lblUserID
			// 
			this.lblUserID.AllowDrop = true;
			this.lblUserID.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblUserID.Text = "Label ID";
			this.lblUserID.Location = new System.Drawing.Point(14, 18);
			this.lblUserID.Name = "lblUserID";
			this.lblUserID.Size = new System.Drawing.Size(38, 14);
			this.lblUserID.TabIndex = 4;
			// 
			// txtArabicName
			// 
			this.txtArabicName.AllowDrop = true;
			this.txtArabicName.BackColor = System.Drawing.Color.White;
			this.txtArabicName.ForeColor = System.Drawing.Color.Black;
			this.txtArabicName.Location = new System.Drawing.Point(108, 60);
			// this.txtArabicName.mArabicEnabled = true;
			this.txtArabicName.Name = "txtArabicName";
			this.txtArabicName.Size = new System.Drawing.Size(290, 19);
			this.txtArabicName.TabIndex = 2;
			this.txtArabicName.Text = "";
			// this.this.txtArabicName.Watermark = "";
			// 
			// lblLocationCode
			// 
			this.lblLocationCode.AllowDrop = true;
			this.lblLocationCode.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblLocationCode.Text = "Arabic Name";
			this.lblLocationCode.Location = new System.Drawing.Point(14, 63);
			this.lblLocationCode.Name = "lblLocationCode";
			this.lblLocationCode.Size = new System.Drawing.Size(60, 13);
			this.lblLocationCode.TabIndex = 5;
			// 
			// txtEngName
			// 
			this.txtEngName.AllowDrop = true;
			this.txtEngName.BackColor = System.Drawing.Color.White;
			this.txtEngName.ForeColor = System.Drawing.Color.Black;
			this.txtEngName.Location = new System.Drawing.Point(108, 37);
			this.txtEngName.Name = "txtEngName";
			this.txtEngName.Size = new System.Drawing.Size(290, 19);
			this.txtEngName.TabIndex = 1;
			this.txtEngName.Text = "";
			// this.this.txtEngName.Watermark = "";
			// 
			// lblCompanyCode
			// 
			this.lblCompanyCode.AllowDrop = true;
			this.lblCompanyCode.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblCompanyCode.Text = "English Name";
			this.lblCompanyCode.Location = new System.Drawing.Point(14, 40);
			this.lblCompanyCode.Name = "lblCompanyCode";
			this.lblCompanyCode.Size = new System.Drawing.Size(63, 13);
			this.lblCompanyCode.TabIndex = 6;
			// 
			// lblLableId
			// 
			this.lblLableId.AllowDrop = true;
			this.lblLableId.Location = new System.Drawing.Point(108, 14);
			this.lblLableId.Name = "lblLableId";
			this.lblLableId.Size = new System.Drawing.Size(91, 19);
			this.lblLableId.TabIndex = 7;
			// 
			// System.Windows.Forms.Label1
			// 
			this.Label1.AllowDrop = true;
			this.Label1.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.Label1.Text = "Module ID";
			this.Label1.Location = new System.Drawing.Point(240, 18);
			this.Label1.Name = "System.Windows.Forms.Label1";
			this.Label1.Size = new System.Drawing.Size(46, 14);
			this.Label1.TabIndex = 8;
			// 
			// txtModuleId
			// 
			this.txtModuleId.AllowDrop = true;
			this.txtModuleId.BackColor = System.Drawing.Color.White;
			this.txtModuleId.ForeColor = System.Drawing.Color.Black;
			this.txtModuleId.Location = new System.Drawing.Point(302, 14);
			this.txtModuleId.Name = "txtModuleId";
			this.txtModuleId.Size = new System.Drawing.Size(96, 19);
			this.txtModuleId.TabIndex = 0;
			this.txtModuleId.Text = "";
			// this.this.txtModuleId.Watermark = "";
			// 
			// frmSysSystemLabels
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.ClientSize = new System.Drawing.Size(406, 147);
			this.Controls.Add(this.cmdOKCancel);
			this.Controls.Add(this.lblUserID);
			this.Controls.Add(this.txtArabicName);
			this.Controls.Add(this.lblLocationCode);
			this.Controls.Add(this.txtEngName);
			this.Controls.Add(this.lblCompanyCode);
			this.Controls.Add(this.lblLableId);
			this.Controls.Add(this.Label1);
			this.Controls.Add(this.txtModuleId);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(176, 185);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmSysSystemLabels";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.ShowInTaskbar = false;
			this.Text = "System Labels";
			// this.Activated += new System.EventHandler(this.frmSysSystemLabels_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
			// this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
			this.ResumeLayout(false);
		}
		#endregion
	}
}//ENDSHERE
