
namespace Xtreme
{
	partial class frmGLExternalTransactions
	{

		#region "Upgrade Support "
		private static frmGLExternalTransactions m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmGLExternalTransactions DefInstance
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
		public static frmGLExternalTransactions CreateInstance()
		{
			frmGLExternalTransactions theInstance = new frmGLExternalTransactions();
			
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
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "cmdShow", "txtTransDate", "label1", "Column_0_grdTransDetails", "Column_1_grdTransDetails", "grdTransDetails", "tcbSystemForm", "Line1", "commandButtonHelper1"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public System.Windows.Forms.Button cmdShow;
		public Syncfusion.WinForms.Input.SfDateTimeEdit txtTransDate;
		public System.Windows.Forms.Label label1;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_0_grdTransDetails;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_1_grdTransDetails;
		public C1.Win.C1TrueDBGrid.C1TrueDBGrid grdTransDetails;
		public Syncfusion.Windows.Forms.Tools.CommandBarController tcbSystemForm;
		public System.Windows.Forms.Label Line1;
		//public UpgradeHelpers.Gui.CommandButtonHelper commandButtonHelper1;
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGLExternalTransactions));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this.cmdShow = new System.Windows.Forms.Button();
			this.txtTransDate = new Syncfusion.WinForms.Input.SfDateTimeEdit();
			this.label1 = new System.Windows.Forms.Label();
			this.grdTransDetails = new C1.Win.C1TrueDBGrid.C1TrueDBGrid();
			this.Column_0_grdTransDetails = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.Column_1_grdTransDetails = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.tcbSystemForm = new Syncfusion.Windows.Forms.Tools.CommandBarController();
			this.Line1 = new System.Windows.Forms.Label();
			// //((System.ComponentModel.ISupportInitialize) this.tcbSystemForm).BeginInit();
			this.grdTransDetails.SuspendLayout();
			this.SuspendLayout();
			//this.commandButtonHelper1 = new UpgradeHelpers.Gui.CommandButtonHelper(this.components);
			// 
			// cmdShow
			// 
			this.cmdShow.AllowDrop = true;
			this.cmdShow.BackColor = System.Drawing.Color.FromArgb(249, 238, 221);
			this.cmdShow.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdShow.Location = new System.Drawing.Point(214, 52);
			this.cmdShow.Name = "cmdShow";
			this.cmdShow.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdShow.Size = new System.Drawing.Size(165, 30);
			this.cmdShow.TabIndex = 1;
			this.cmdShow.Text = "Show &External Transactions";
			this.cmdShow.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.cmdShow.UseVisualStyleBackColor = false;
			// this.cmdShow.Click += new System.EventHandler(this.cmdShow_Click);
			// 
			// txtTransDate
			// 
			this.txtTransDate.AllowDrop = true;
			// this.txtTransDate.CheckDateRange = false;
			this.txtTransDate.Location = new System.Drawing.Point(90, 57);
			// this.txtTransDate.MaxDate = 2958465;
			// this.txtTransDate.MinDate = 2;
			this.txtTransDate.Name = "txtTransDate";
			this.txtTransDate.Size = new System.Drawing.Size(100, 19);
			this.txtTransDate.TabIndex = 0;
			this.txtTransDate.Text = "10/28/2011";
			// 
			// label1
			// 
			this.label1.AllowDrop = true;
			this.label1.BackColor = System.Drawing.SystemColors.Window;
			this.label1.Text = "As On Date:";
			this.label1.ForeColor = System.Drawing.Color.Black;
			this.label1.Location = new System.Drawing.Point(18, 60);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(59, 13);
			this.label1.TabIndex = 2;
			// 
			// grdTransDetails
			// 
			this.grdTransDetails.AllowDrop = true;
			this.grdTransDetails.BackColor = System.Drawing.Color.FromArgb(212, 208, 200);
			this.grdTransDetails.CellTipsWidth = 0;
			this.grdTransDetails.Location = new System.Drawing.Point(3, 96);
			this.grdTransDetails.Name = "grdTransDetails";
			this.grdTransDetails.RowDivider.Color = System.Drawing.Color.FromArgb(212, 208, 200);
			this.grdTransDetails.Size = new System.Drawing.Size(749, 264);
			this.grdTransDetails.TabIndex = 3;
			this.grdTransDetails.Columns.Add(this.Column_0_grdTransDetails);
			this.grdTransDetails.Columns.Add(this.Column_1_grdTransDetails);
			this.grdTransDetails.BeforeColEdit += new C1.Win.C1TrueDBGrid.BeforeColEditEventHandler(this.grdTransDetails_BeforeColEdit);
			// this.this.grdTransDetails.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.grdTransDetails_KeyPress);
			this.grdTransDetails.MouseUp += new System.Windows.Forms.MouseEventHandler(this.grdTransDetails_MouseUp);
			// 
			// Column_0_grdTransDetails
			// 
			this.Column_0_grdTransDetails.DataField = "";
			this.Column_0_grdTransDetails.ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.Normal;
			// 
			// Column_1_grdTransDetails
			// 
			this.Column_1_grdTransDetails.DataField = "";
			this.Column_1_grdTransDetails.ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.Normal;
			// 
			// tcbSystemForm
			// 
			this.tcbSystemForm.AllowDrop = true;
			this.tcbSystemForm.Location = new System.Drawing.Point(0, 0);
			this.tcbSystemForm.Name = "tcbSystemForm";
			("tcbSystemForm.OcxState");
			// 
			// Line1
			// 
			this.Line1.AllowDrop = true;
			this.Line1.BackColor = System.Drawing.Color.Red;
			this.Line1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Line1.Enabled = false;
			this.Line1.ForeColor = System.Drawing.Color.Black;
			this.Line1.Location = new System.Drawing.Point(0, 87);
			this.Line1.Name = "Line1";
			this.Line1.Size = new System.Drawing.Size(767, 1);
			this.Line1.Text = "Line1";
			this.Line1.Visible = true;
			// 
			// frmGLExternalTransactions
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.FromArgb(250, 244, 231);
			this.ClientSize = new System.Drawing.Size(758, 375);
			this.Controls.Add(this.cmdShow);
			this.Controls.Add(this.txtTransDate);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.grdTransDetails);
			this.Controls.Add(this.tcbSystemForm);
			this.Controls.Add(this.Line1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			//this.Icon = (System.Drawing.Icon) resources.GetObject("frmGLExternalTransactions.Icon");
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(18, 134);
			this.MaximizeBox = false;
			this.MinimizeBox = true;
			this.Name = "frmGLExternalTransactions";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "GL External Transactions";
			this.commandButtonHelper1.SetStyle(this.cmdShow, 1);
			// this.Activated += new System.EventHandler(this.Form_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
			// this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
			//((System.ComponentModel.ISupportInitialize) this.tcbSystemForm).EndInit();
			this.grdTransDetails.ResumeLayout(false);
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
}//ENDSHERE
