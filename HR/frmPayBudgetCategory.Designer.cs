
namespace Xtreme
{
	partial class frmPayBudgetCategory
	{

		#region "Upgrade Support "
		private static frmPayBudgetCategory m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmPayBudgetCategory DefInstance
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
		public static frmPayBudgetCategory CreateInstance()
		{
			frmPayBudgetCategory theInstance = new frmPayBudgetCategory();
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
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "txtBudgetCode", "lblBudgetCode", "txtDBudgetName", "tcbSystemForm"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public System.Windows.Forms.TextBox txtBudgetCode;
		public System.Windows.Forms.Label lblBudgetCode;
		public System.Windows.Forms.Label txtDBudgetName;
		public Syncfusion.Windows.Forms.Tools.CommandBarController tcbSystemForm;
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPayBudgetCategory));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this.txtBudgetCode = new System.Windows.Forms.TextBox();
			this.lblBudgetCode = new System.Windows.Forms.Label();
			this.txtDBudgetName = new System.Windows.Forms.Label();
			this.tcbSystemForm = new Syncfusion.Windows.Forms.Tools.CommandBarController();
			// //((System.ComponentModel.ISupportInitialize) this.tcbSystemForm).BeginInit();
			this.SuspendLayout();
			// 
			// txtBudgetCode
			// 
			this.txtBudgetCode.AllowDrop = true;
			this.txtBudgetCode.BackColor = System.Drawing.Color.White;
			// this.txtBudgetCode.bolNumericOnly = true;
			this.txtBudgetCode.ForeColor = System.Drawing.Color.Black;
			this.txtBudgetCode.Location = new System.Drawing.Point(142, 76);
			this.txtBudgetCode.MaxLength = 8;
			this.txtBudgetCode.Name = "txtBudgetCode";
			// this.txtBudgetCode.ShowButton = true;
			this.txtBudgetCode.Size = new System.Drawing.Size(101, 19);
			this.txtBudgetCode.TabIndex = 0;
			this.txtBudgetCode.Text = "";
			// this.this.txtBudgetCode.Watermark = "";
			// 
			// lblBudgetCode
			// 
			this.lblBudgetCode.AllowDrop = true;
			this.lblBudgetCode.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblBudgetCode.Text = "Budget Code";
			this.lblBudgetCode.Location = new System.Drawing.Point(14, 78);
			this.lblBudgetCode.Name = "lblBudgetCode";
			this.lblBudgetCode.Size = new System.Drawing.Size(62, 14);
			this.lblBudgetCode.TabIndex = 1;
			// 
			// txtDBudgetName
			// 
			this.txtDBudgetName.AllowDrop = true;
			this.txtDBudgetName.Location = new System.Drawing.Point(245, 76);
			this.txtDBudgetName.Name = "txtDBudgetName";
			this.txtDBudgetName.Size = new System.Drawing.Size(239, 19);
			this.txtDBudgetName.TabIndex = 2;
			this.txtDBudgetName.TabStop = false;
			// 
			// tcbSystemForm
			// 
			this.tcbSystemForm.AllowDrop = true;
			this.tcbSystemForm.Location = new System.Drawing.Point(126, 6);
			this.tcbSystemForm.Name = "tcbSystemForm";
			//
			// 
			// frmPayBudgetCategory
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.ClientSize = new System.Drawing.Size(715, 311);
			this.Controls.Add(this.txtBudgetCode);
			this.Controls.Add(this.lblBudgetCode);
			this.Controls.Add(this.txtDBudgetName);
			this.Controls.Add(this.tcbSystemForm);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			//this.Icon = (System.Drawing.Icon) resources.GetObject("frmPayBudgetCategory.Icon");
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(213, 219);
			this.MaximizeBox = true;
			this.MinimizeBox = true;
			this.Name = "frmPayBudgetCategory";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Budget Category";
			// this.Activated += new System.EventHandler(this.frmPayBudgetCategory_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
			//((System.ComponentModel.ISupportInitialize) this.tcbSystemForm).EndInit();
			this.ResumeLayout(false);
		}
		// 
		#endregion
	}
}//ENDSHERE
