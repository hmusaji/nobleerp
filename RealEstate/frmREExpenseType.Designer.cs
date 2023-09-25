
namespace Xtreme
{
	partial class frmREExpenseType
	{

		#region "Upgrade Support "
		private static frmREExpenseType m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmREExpenseType DefInstance
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
		public static frmREExpenseType CreateInstance()
		{
			frmREExpenseType theInstance = new frmREExpenseType();
			
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
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "lblExpNo", "txtSmanNo", "lblLSmanName", "lblASmanName", "txtLSmanName", "txtASmanName"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public System.Windows.Forms.Label lblExpNo;
		public System.Windows.Forms.TextBox txtSmanNo;
		public System.Windows.Forms.Label lblLSmanName;
		public System.Windows.Forms.Label lblASmanName;
		public System.Windows.Forms.TextBox txtLSmanName;
		public System.Windows.Forms.TextBox txtASmanName;
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmREExpenseType));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this.lblExpNo = new System.Windows.Forms.Label();
			this.txtSmanNo = new System.Windows.Forms.TextBox();
			this.lblLSmanName = new System.Windows.Forms.Label();
			this.lblASmanName = new System.Windows.Forms.Label();
			this.txtLSmanName = new System.Windows.Forms.TextBox();
			this.txtASmanName = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// lblExpNo
			// 
			this.lblExpNo.AllowDrop = true;
			this.lblExpNo.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblExpNo.Text = "Expense Type Code";
			this.lblExpNo.ForeColor = System.Drawing.Color.Black;
			this.lblExpNo.Location = new System.Drawing.Point(12, 38);
			this.lblExpNo.Name = "lblExpNo";
			this.lblExpNo.Size = new System.Drawing.Size(97, 14);
			this.lblExpNo.TabIndex = 0;
			// 
			// txtSmanNo
			// 
			this.txtSmanNo.AllowDrop = true;
			this.txtSmanNo.BackColor = System.Drawing.Color.White;
			// this.txtSmanNo.bolNumericOnly = true;
			this.txtSmanNo.ForeColor = System.Drawing.Color.Black;
			this.txtSmanNo.Location = new System.Drawing.Point(135, 36);
			this.txtSmanNo.MaxLength = 4;
			// this.txtSmanNo.mDropDownType = System.Windows.Forms.TextBox.DropDownTypes.ddtNextNumber;
			this.txtSmanNo.Name = "txtSmanNo";
			this.txtSmanNo.Size = new System.Drawing.Size(101, 19);
			this.txtSmanNo.TabIndex = 1;
			this.txtSmanNo.Text = "";
			// this.this.txtSmanNo.Watermark = "";
			// 
			// lblLSmanName
			// 
			this.lblLSmanName.AllowDrop = true;
			this.lblLSmanName.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblLSmanName.Text = "Expense Name (English)";
			this.lblLSmanName.ForeColor = System.Drawing.Color.Black;
			this.lblLSmanName.Location = new System.Drawing.Point(10, 66);
			this.lblLSmanName.Name = "lblLSmanName";
			this.lblLSmanName.Size = new System.Drawing.Size(117, 14);
			this.lblLSmanName.TabIndex = 2;
			// 
			// lblASmanName
			// 
			this.lblASmanName.AllowDrop = true;
			this.lblASmanName.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblASmanName.Text = "Expense Name (Arabic)";
			this.lblASmanName.ForeColor = System.Drawing.Color.Black;
			this.lblASmanName.Location = new System.Drawing.Point(10, 93);
			this.lblASmanName.Name = "lblASmanName";
			this.lblASmanName.Size = new System.Drawing.Size(115, 14);
			this.lblASmanName.TabIndex = 3;
			// 
			// txtLSmanName
			// 
			this.txtLSmanName.AllowDrop = true;
			this.txtLSmanName.BackColor = System.Drawing.Color.White;
			this.txtLSmanName.ForeColor = System.Drawing.Color.Black;
			this.txtLSmanName.Location = new System.Drawing.Point(135, 64);
			this.txtLSmanName.MaxLength = 50;
			this.txtLSmanName.Name = "txtLSmanName";
			this.txtLSmanName.Size = new System.Drawing.Size(290, 19);
			this.txtLSmanName.TabIndex = 4;
			this.txtLSmanName.Tag = "Salesman Name in English";
			this.txtLSmanName.Text = "";
			// this.this.txtLSmanName.Watermark = "";
			// 
			// txtASmanName
			// 
			this.txtASmanName.AllowDrop = true;
			this.txtASmanName.BackColor = System.Drawing.Color.White;
			this.txtASmanName.ForeColor = System.Drawing.Color.Black;
			this.txtASmanName.Location = new System.Drawing.Point(135, 92);
			// this.txtASmanName.mArabicEnabled = true;
			this.txtASmanName.MaxLength = 50;
			this.txtASmanName.Name = "txtASmanName";
			this.txtASmanName.Size = new System.Drawing.Size(290, 19);
			this.txtASmanName.TabIndex = 5;
			this.txtASmanName.Text = "";
			// this.this.txtASmanName.Watermark = "";
			// 
			// frmREExpenseType
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.ClientSize = new System.Drawing.Size(586, 201);
			this.Controls.Add(this.lblExpNo);
			this.Controls.Add(this.txtSmanNo);
			this.Controls.Add(this.lblLSmanName);
			this.Controls.Add(this.lblASmanName);
			this.Controls.Add(this.txtLSmanName);
			this.Controls.Add(this.txtASmanName);
			//this.Icon = (System.Drawing.Icon) resources.GetObject("frmREExpenseType.Icon");
			this.Location = new System.Drawing.Point(105, 461);
			this.MaximizeBox = true;
			this.MinimizeBox = true;
			this.Name = "frmREExpenseType";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Property Expense Type";
			this.ToolTipMain.SetToolTip(this.txtLSmanName, "Salesman Name in English");
			// this.Activated += new System.EventHandler(this.frmREExpenseType_Activated);
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
}//ENDSHERE
