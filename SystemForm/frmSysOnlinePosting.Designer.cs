
namespace Xtreme
{
	partial class frmSysOnlinePosting
	{

		#region "Upgrade Support "
		private static frmSysOnlinePosting m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmSysOnlinePosting DefInstance
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
		public static frmSysOnlinePosting CreateInstance()
		{
			frmSysOnlinePosting theInstance = new frmSysOnlinePosting();
			
			return theInstance;
		}
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "lblApprove", "fraPosting", "cmdOKCancel", "Shape1"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public System.Windows.Forms.Label lblApprove;
		public System.Windows.Forms.GroupBox fraPosting;
		public UCOkCancel cmdOKCancel;
		public ShapeHelper Shape1;
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSysOnlinePosting));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this.fraPosting = new System.Windows.Forms.GroupBox();
			this.lblApprove = new System.Windows.Forms.Label();
			this.cmdOKCancel = new UCOkCancel();
			this.Shape1 = new ShapeHelper();
			//this.fraPosting.SuspendLayout();
			this.SuspendLayout();
			// 
			// fraPosting
			// 
			this.fraPosting.AllowDrop = true;
			this.fraPosting.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.fraPosting.Controls.Add(this.lblApprove);
			this.fraPosting.Enabled = true;
			this.fraPosting.ForeColor = System.Drawing.SystemColors.ControlText;
			this.fraPosting.Location = new System.Drawing.Point(10, 10);
			this.fraPosting.Name = "fraPosting";
			this.fraPosting.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.fraPosting.Size = new System.Drawing.Size(245, 97);
			this.fraPosting.TabIndex = 1;
			this.fraPosting.Visible = true;
			// 
			// lblApprove
			// 
			this.lblApprove.AllowDrop = true;
			this.lblApprove.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblApprove.Text = "Do You Want To Post?";
			this.lblApprove.Location = new System.Drawing.Point(36, 38);
			this.lblApprove.Name = "lblApprove";
			this.lblApprove.Size = new System.Drawing.Size(187, 23);
			this.lblApprove.TabIndex = 2;
			// 
			// cmdOKCancel
			// 
			this.cmdOKCancel.AllowDrop = true;
			this.cmdOKCancel.DisplayButton = 0;
			this.cmdOKCancel.Location = new System.Drawing.Point(26, 118);
			this.cmdOKCancel.Name = "cmdOKCancel";
			this.cmdOKCancel.OkCaption = "&Ok";
			this.cmdOKCancel.Size = new System.Drawing.Size(206, 31);
			this.cmdOKCancel.TabIndex = 0;
			//this.cmdOKCancel.CancelClick += new UCOkCancel.CancelClickHandler(this.cmdOKCancel_CancelClick);
			//this.cmdOKCancel.OKClick += new UCOkCancel.OKClickHandler(this.cmdOKCancel_OKClick);
			// 
			// Shape1
			// 
			this.Shape1.AllowDrop = true;
			this.Shape1.BackColor = System.Drawing.SystemColors.Window;
			// = 0;
			this.Shape1.BorderStyle = 1;
			this.Shape1.Enabled = false;
			this.Shape1.FillColor = System.Drawing.Color.Black;
			this.Shape1.FillStyle = 1;
			this.Shape1.Location = new System.Drawing.Point(0, 0);
			this.Shape1.Name = "Shape1";
			this.Shape1.Size = new System.Drawing.Size(261, 157);
			this.Shape1.Visible = true;
			// 
			// frmSysOnlinePosting
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.ClientSize = new System.Drawing.Size(261, 157);
			this.Controls.Add(this.fraPosting);
			this.Controls.Add(this.cmdOKCancel);
			this.Controls.Add(this.Shape1);
			this.ForeColor = System.Drawing.Color.Silver;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			//this.Icon = (System.Drawing.Icon) resources.GetObject("frmSysOnlinePosting.Icon");
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(424, 266);
			this.MaximizeBox = true;
			this.MinimizeBox = true;
			this.Name = "frmSysOnlinePosting";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.ShowInTaskbar = false;
			this.Text = "Online Posting of Vouchers";
			// this.Activated += new System.EventHandler(this.frmSysOnlinePosting_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
			// this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
			this.fraPosting.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		// 
		#endregion
	}
}//ENDSHERE
