
namespace Xtreme
{
	partial class frmGLCostCenterCategory
	{

		#region "Upgrade Support "
		private static frmGLCostCenterCategory m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmGLCostCenterCategory DefInstance
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
		public static frmGLCostCenterCategory CreateInstance()
		{
			frmGLCostCenterCategory theInstance = new frmGLCostCenterCategory();
			
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
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "txtComment", "txtCatNo", "lblLCostName", "txtLCatName", "lblACostName", "txtACatName", "lblComments", "lblCostNo", "cntMainParameter", "tcbSystemForm"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public System.Windows.Forms.TextBox txtComment;
		public System.Windows.Forms.TextBox txtCatNo;
		public System.Windows.Forms.Label lblLCostName;
		public System.Windows.Forms.TextBox txtLCatName;
		public System.Windows.Forms.Label lblACostName;
		public System.Windows.Forms.TextBox txtACatName;
		public System.Windows.Forms.Label lblComments;
		public System.Windows.Forms.Label lblCostNo;
		public AxTDBContainer3D6.AxTDBContainer3D cntMainParameter;
		public Syncfusion.Windows.Forms.Tools.CommandBarController tcbSystemForm;
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGLCostCenterCategory));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this.cntMainParameter = new AxTDBContainer3D6.AxTDBContainer3D();
			this.txtComment = new System.Windows.Forms.TextBox();
			this.txtCatNo = new System.Windows.Forms.TextBox();
			this.lblLCostName = new System.Windows.Forms.Label();
			this.txtLCatName = new System.Windows.Forms.TextBox();
			this.lblACostName = new System.Windows.Forms.Label();
			this.txtACatName = new System.Windows.Forms.TextBox();
			this.lblComments = new System.Windows.Forms.Label();
			this.lblCostNo = new System.Windows.Forms.Label();
			this.tcbSystemForm = new Syncfusion.Windows.Forms.Tools.CommandBarController();
			// //((System.ComponentModel.ISupportInitialize) this.cntMainParameter).BeginInit();
			// //((System.ComponentModel.ISupportInitialize) this.tcbSystemForm).BeginInit();
			this.cntMainParameter.SuspendLayout();
			this.SuspendLayout();
			// 
			// cntMainParameter
			// 
			this.cntMainParameter.AllowDrop = true;
			this.cntMainParameter.Controls.Add(this.txtComment);
			this.cntMainParameter.Controls.Add(this.txtCatNo);
			this.cntMainParameter.Controls.Add(this.lblLCostName);
			this.cntMainParameter.Controls.Add(this.txtLCatName);
			this.cntMainParameter.Controls.Add(this.lblACostName);
			this.cntMainParameter.Controls.Add(this.txtACatName);
			this.cntMainParameter.Controls.Add(this.lblComments);
			this.cntMainParameter.Controls.Add(this.lblCostNo);
			this.cntMainParameter.Location = new System.Drawing.Point(4, 44);
			this.cntMainParameter.Name = "cntMainParameter";
			("cntMainParameter.OcxState");
			this.cntMainParameter.Size = new System.Drawing.Size(467, 145);
			this.cntMainParameter.TabIndex = 4;
			// 
			// txtComment
			// 
			this.txtComment.AcceptsReturn = true;
			this.txtComment.AllowDrop = true;
			this.txtComment.BackColor = System.Drawing.SystemColors.Window;
			this.txtComment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtComment.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtComment.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtComment.Location = new System.Drawing.Point(146, 75);
			this.txtComment.MaxLength = 100;
			this.txtComment.Multiline = true;
			this.txtComment.Name = "txtComment";
			this.txtComment.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtComment.Size = new System.Drawing.Size(304, 59);
			this.txtComment.TabIndex = 3;
			// 
			// txtCatNo
			// 
			this.txtCatNo.AllowDrop = true;
			this.txtCatNo.BackColor = System.Drawing.Color.White;
			// this.txtCatNo.bolNumericOnly = true;
			this.txtCatNo.ForeColor = System.Drawing.Color.Black;
			this.txtCatNo.Location = new System.Drawing.Point(146, 12);
			this.txtCatNo.MaxLength = 15;
			// this.txtCatNo.mDropDownType = System.Windows.Forms.TextBox.DropDownTypes.ddtNextNumber;
			this.txtCatNo.Name = "txtCatNo";
			// this.txtCatNo.ShowButton = true;
			this.txtCatNo.Size = new System.Drawing.Size(101, 19);
			this.txtCatNo.TabIndex = 0;
			this.txtCatNo.Text = "";
			// this.this.txtCatNo.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCatNo_DropButtonClick);
			// 
			// lblLCostName
			// 
			this.lblLCostName.AllowDrop = true;
			this.lblLCostName.BackColor = System.Drawing.Color.FromArgb(237, 231, 235);
			this.lblLCostName.Text = "Cost Center Name (English)";
			this.lblLCostName.Location = new System.Drawing.Point(8, 35);
			// this.lblLCostName.mLabelId = 964;
			this.lblLCostName.Name = "lblLCostName";
			this.lblLCostName.Size = new System.Drawing.Size(132, 14);
			this.lblLCostName.TabIndex = 5;
			// 
			// txtLCatName
			// 
			this.txtLCatName.AllowDrop = true;
			this.txtLCatName.BackColor = System.Drawing.Color.White;
			this.txtLCatName.ForeColor = System.Drawing.Color.Black;
			this.txtLCatName.Location = new System.Drawing.Point(146, 33);
			this.txtLCatName.MaxLength = 50;
			this.txtLCatName.Name = "txtLCatName";
			this.txtLCatName.Size = new System.Drawing.Size(201, 19);
			this.txtLCatName.TabIndex = 1;
			this.txtLCatName.Text = "";
			// 
			// lblACostName
			// 
			this.lblACostName.AllowDrop = true;
			this.lblACostName.BackColor = System.Drawing.Color.FromArgb(237, 231, 235);
			this.lblACostName.Text = "Cost Center Name (Arabic)";
			this.lblACostName.Location = new System.Drawing.Point(8, 56);
			// this.lblACostName.mLabelId = 965;
			this.lblACostName.Name = "lblACostName";
			this.lblACostName.Size = new System.Drawing.Size(130, 14);
			this.lblACostName.TabIndex = 6;
			// 
			// txtACatName
			// 
			this.txtACatName.AllowDrop = true;
			this.txtACatName.BackColor = System.Drawing.Color.White;
			this.txtACatName.ForeColor = System.Drawing.Color.Black;
			this.txtACatName.Location = new System.Drawing.Point(146, 54);
			// this.txtACatName.mArabicEnabled = true;
			this.txtACatName.MaxLength = 50;
			this.txtACatName.Name = "txtACatName";
			this.txtACatName.Size = new System.Drawing.Size(201, 19);
			this.txtACatName.TabIndex = 2;
			this.txtACatName.Text = "";
			// 
			// lblComments
			// 
			this.lblComments.AllowDrop = true;
			this.lblComments.BackColor = System.Drawing.Color.FromArgb(237, 231, 235);
			this.lblComments.Text = "Comment";
			this.lblComments.Location = new System.Drawing.Point(8, 76);
			// this.lblComments.mLabelId = 135;
			this.lblComments.Name = "lblComments";
			this.lblComments.Size = new System.Drawing.Size(44, 14);
			this.lblComments.TabIndex = 7;
			// 
			// lblCostNo
			// 
			this.lblCostNo.AllowDrop = true;
			this.lblCostNo.BackColor = System.Drawing.Color.FromArgb(237, 231, 235);
			this.lblCostNo.Text = "Cost Center Code";
			this.lblCostNo.Location = new System.Drawing.Point(8, 14);
			// this.lblCostNo.mLabelId = 968;
			this.lblCostNo.Name = "lblCostNo";
			this.lblCostNo.Size = new System.Drawing.Size(85, 14);
			this.lblCostNo.TabIndex = 8;
			// 
			// tcbSystemForm
			// 
			this.tcbSystemForm.AllowDrop = true;
			this.tcbSystemForm.Location = new System.Drawing.Point(132, 10);
			this.tcbSystemForm.Name = "tcbSystemForm";
			("tcbSystemForm.OcxState");
			// 
			// frmGLCostCenterCategory
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.FromArgb(205, 184, 196);
			this.ClientSize = new System.Drawing.Size(479, 197);
			this.Controls.Add(this.cntMainParameter);
			this.Controls.Add(this.tcbSystemForm);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			//this.Icon = (System.Drawing.Icon) resources.GetObject("frmGLCostCenterCategory.Icon");
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(153, 214);
			this.MaximizeBox = false;
			this.MinimizeBox = true;
			this.Name = "frmGLCostCenterCategory";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Cost Center Category";
			// this.Activated += new System.EventHandler(this.frmGLCostCenterCategory_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
			// this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
			//((System.ComponentModel.ISupportInitialize) this.cntMainParameter).EndInit();
			//((System.ComponentModel.ISupportInitialize) this.tcbSystemForm).EndInit();
			this.cntMainParameter.ResumeLayout(false);
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