
namespace Xtreme
{
	partial class frmFADepreciation
	{

		#region "Upgrade Support "
		private static frmFADepreciation m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmFADepreciation DefInstance
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
		public static frmFADepreciation CreateInstance()
		{
			frmFADepreciation theInstance = new frmFADepreciation();
			
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
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "txtDeprDate", "lblDate", "txtComments", "txtDepreciationNo", "lblComments", "lblDepreciationNo"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public Syncfusion.WinForms.Input.SfDateTimeEdit txtDeprDate;
		public System.Windows.Forms.Label lblDate;
		public System.Windows.Forms.TextBox txtComments;
		public System.Windows.Forms.TextBox txtDepreciationNo;
		public System.Windows.Forms.Label lblComments;
		public System.Windows.Forms.Label lblDepreciationNo;
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFADepreciation));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this.txtDeprDate = new Syncfusion.WinForms.Input.SfDateTimeEdit();
			this.lblDate = new System.Windows.Forms.Label();
			this.txtComments = new System.Windows.Forms.TextBox();
			this.txtDepreciationNo = new System.Windows.Forms.TextBox();
			this.lblComments = new System.Windows.Forms.Label();
			this.lblDepreciationNo = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// txtDeprDate
			// 
			this.txtDeprDate.AllowDrop = true;
			this.txtDeprDate.Location = new System.Drawing.Point(98, 71);
			// this.txtDeprDate.MaxDate = 2958465;
			// this.txtDeprDate.MinDate = 2;
			this.txtDeprDate.Name = "txtDeprDate";
			this.txtDeprDate.Size = new System.Drawing.Size(101, 19);
			this.txtDeprDate.TabIndex = 1;
			this.txtDeprDate.Text = "15/03/2014";
			// 
			// lblDate
			// 
			this.lblDate.AllowDrop = true;
			this.lblDate.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblDate.Text = "Transaction Date";
			this.lblDate.ForeColor = System.Drawing.Color.Black;
			this.lblDate.Location = new System.Drawing.Point(9, 73);
			// this.lblDate.mLabelId = 948;
			this.lblDate.Name = "lblDate";
			this.lblDate.Size = new System.Drawing.Size(82, 14);
			this.lblDate.TabIndex = 3;
			// 
			// txtComments
			// 
			this.txtComments.AllowDrop = true;
			this.txtComments.BackColor = System.Drawing.Color.White;
			this.txtComments.ForeColor = System.Drawing.Color.Black;
			this.txtComments.Location = new System.Drawing.Point(98, 93);
			this.txtComments.MaxLength = 20;
			this.txtComments.Name = "txtComments";
			this.txtComments.Size = new System.Drawing.Size(379, 51);
			this.txtComments.TabIndex = 2;
			this.txtComments.Text = "";
			// this.this.txtComments.Watermark = "";
			// 
			// txtDepreciationNo
			// 
			this.txtDepreciationNo.AllowDrop = true;
			this.txtDepreciationNo.BackColor = System.Drawing.Color.FromArgb(239, 239, 239);
			// this.txtDepreciationNo.bolNumericOnly = true;
			this.txtDepreciationNo.Enabled = false;
			this.txtDepreciationNo.ForeColor = System.Drawing.Color.Black;
			this.txtDepreciationNo.Location = new System.Drawing.Point(98, 49);
			this.txtDepreciationNo.MaxLength = 3;
			// this.txtDepreciationNo.mDropDownType = System.Windows.Forms.TextBox.DropDownTypes.ddtNextNumber;
			this.txtDepreciationNo.Name = "txtDepreciationNo";
			this.txtDepreciationNo.Size = new System.Drawing.Size(101, 19);
			this.txtDepreciationNo.TabIndex = 0;
			this.txtDepreciationNo.Text = "";
			// this.this.txtDepreciationNo.Watermark = "";
			// 
			// lblComments
			// 
			this.lblComments.AllowDrop = true;
			this.lblComments.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblComments.Text = "Comments";
			this.lblComments.ForeColor = System.Drawing.Color.Black;
			this.lblComments.Location = new System.Drawing.Point(9, 93);
			// this.lblComments.mLabelId = 135;
			this.lblComments.Name = "lblComments";
			this.lblComments.Size = new System.Drawing.Size(50, 14);
			this.lblComments.TabIndex = 4;
			// 
			// lblDepreciationNo
			// 
			this.lblDepreciationNo.AllowDrop = true;
			this.lblDepreciationNo.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblDepreciationNo.Text = "Transaction No";
			this.lblDepreciationNo.ForeColor = System.Drawing.Color.Black;
			this.lblDepreciationNo.Location = new System.Drawing.Point(9, 51);
			// this.lblDepreciationNo.mLabelId = 1022;
			this.lblDepreciationNo.Name = "lblDepreciationNo";
			this.lblDepreciationNo.Size = new System.Drawing.Size(73, 14);
			this.lblDepreciationNo.TabIndex = 5;
			// 
			// frmFADepreciation
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.ClientSize = new System.Drawing.Size(485, 153);
			this.Controls.Add(this.txtDeprDate);
			this.Controls.Add(this.lblDate);
			this.Controls.Add(this.txtComments);
			this.Controls.Add(this.txtDepreciationNo);
			this.Controls.Add(this.lblComments);
			this.Controls.Add(this.lblDepreciationNo);
			//this.Icon = (System.Drawing.Icon) resources.GetObject("frmFADepreciation.Icon");
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(120, 198);
			this.MaximizeBox = true;
			this.MinimizeBox = true;
			this.Name = "frmFADepreciation";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Assets Depreciation";
			// this.Activated += new System.EventHandler(this.frmFADepreciation_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
			// this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
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