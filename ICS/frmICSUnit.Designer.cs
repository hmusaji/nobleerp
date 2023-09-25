
namespace Xtreme
{
	partial class frmICSUnit
	{

		#region "Upgrade Support "
		private static frmICSUnit m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmICSUnit DefInstance
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
		public static frmICSUnit CreateInstance()
		{
			frmICSUnit theInstance = new frmICSUnit();
			
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
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "lblUnitNameA", "txtAUnitName", "lblDecimal", "lblSymbol", "txtLUnitName", "txtUnitNo", "lblUnitNameL", "lblUnitNo", "txtSymbol", "txtDecimal"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public System.Windows.Forms.Label lblUnitNameA;
		public System.Windows.Forms.TextBox txtAUnitName;
		public System.Windows.Forms.Label lblDecimal;
		public System.Windows.Forms.Label lblSymbol;
		public System.Windows.Forms.TextBox txtLUnitName;
		public System.Windows.Forms.TextBox txtUnitNo;
		public System.Windows.Forms.Label lblUnitNameL;
		public System.Windows.Forms.Label lblUnitNo;
		public System.Windows.Forms.TextBox txtSymbol;
		public System.Windows.Forms.TextBox txtDecimal;
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmICSUnit));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this.lblUnitNameA = new System.Windows.Forms.Label();
			this.txtAUnitName = new System.Windows.Forms.TextBox();
			this.lblDecimal = new System.Windows.Forms.Label();
			this.lblSymbol = new System.Windows.Forms.Label();
			this.txtLUnitName = new System.Windows.Forms.TextBox();
			this.txtUnitNo = new System.Windows.Forms.TextBox();
			this.lblUnitNameL = new System.Windows.Forms.Label();
			this.lblUnitNo = new System.Windows.Forms.Label();
			this.txtSymbol = new System.Windows.Forms.TextBox();
			this.txtDecimal = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// lblUnitNameA
			// 
			this.lblUnitNameA.AllowDrop = true;
			this.lblUnitNameA.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblUnitNameA.Text = "Unit Name (Arabic)";
			this.lblUnitNameA.Location = new System.Drawing.Point(10, 88);
			// this.lblUnitNameA.mLabelId = 959;
			this.lblUnitNameA.Name = "lblUnitNameA";
			this.lblUnitNameA.Size = new System.Drawing.Size(91, 14);
			this.lblUnitNameA.TabIndex = 8;
			// 
			// txtAUnitName
			// 
			this.txtAUnitName.AllowDrop = true;
			this.txtAUnitName.BackColor = System.Drawing.Color.White;
			this.txtAUnitName.ForeColor = System.Drawing.Color.Black;
			this.txtAUnitName.Location = new System.Drawing.Point(112, 86);
			// this.txtAUnitName.mArabicEnabled = true;
			this.txtAUnitName.MaxLength = 10;
			this.txtAUnitName.Name = "txtAUnitName";
			this.txtAUnitName.Size = new System.Drawing.Size(253, 19);
			this.txtAUnitName.TabIndex = 9;
			this.txtAUnitName.Text = "";
			// 
			// lblDecimal
			// 
			this.lblDecimal.AllowDrop = true;
			this.lblDecimal.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblDecimal.Text = "Decimal";
			this.lblDecimal.Location = new System.Drawing.Point(220, 46);
			// this.lblDecimal.mLabelId = 199;
			this.lblDecimal.Name = "lblDecimal";
			this.lblDecimal.Size = new System.Drawing.Size(37, 14);
			this.lblDecimal.TabIndex = 4;
			this.lblDecimal.Visible = false;
			// 
			// lblSymbol
			// 
			this.lblSymbol.AllowDrop = true;
			this.lblSymbol.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblSymbol.Text = "Symbol";
			this.lblSymbol.Location = new System.Drawing.Point(10, 46);
			// this.lblSymbol.mLabelId = 772;
			this.lblSymbol.Name = "lblSymbol";
			this.lblSymbol.Size = new System.Drawing.Size(35, 14);
			this.lblSymbol.TabIndex = 2;
			// 
			// txtLUnitName
			// 
			this.txtLUnitName.AllowDrop = true;
			this.txtLUnitName.BackColor = System.Drawing.Color.White;
			this.txtLUnitName.ForeColor = System.Drawing.Color.Black;
			this.txtLUnitName.Location = new System.Drawing.Point(112, 65);
			this.txtLUnitName.MaxLength = 10;
			this.txtLUnitName.Name = "txtLUnitName";
			this.txtLUnitName.Size = new System.Drawing.Size(253, 19);
			this.txtLUnitName.TabIndex = 7;
			this.txtLUnitName.Text = "";
			// 
			// txtUnitNo
			// 
			this.txtUnitNo.AllowDrop = true;
			this.txtUnitNo.BackColor = System.Drawing.Color.White;
			// this.txtUnitNo.bolNumericOnly = true;
			this.txtUnitNo.ForeColor = System.Drawing.Color.Black;
			this.txtUnitNo.Location = new System.Drawing.Point(112, 23);
			this.txtUnitNo.MaxLength = 4;
			// this.txtUnitNo.mDropDownType = System.Windows.Forms.TextBox.DropDownTypes.ddtNextNumber;
			this.txtUnitNo.Name = "txtUnitNo";
			// this.txtUnitNo.ShowButton = true;
			this.txtUnitNo.Size = new System.Drawing.Size(101, 19);
			this.txtUnitNo.TabIndex = 1;
			this.txtUnitNo.Text = "";
			// this.this.txtUnitNo.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtUnitNo_DropButtonClick);
			// 
			// lblUnitNameL
			// 
			this.lblUnitNameL.AllowDrop = true;
			this.lblUnitNameL.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblUnitNameL.Text = "Unit Name (English)";
			this.lblUnitNameL.Location = new System.Drawing.Point(10, 67);
			// this.lblUnitNameL.mLabelId = 836;
			this.lblUnitNameL.Name = "lblUnitNameL";
			this.lblUnitNameL.Size = new System.Drawing.Size(93, 14);
			this.lblUnitNameL.TabIndex = 6;
			// 
			// lblUnitNo
			// 
			this.lblUnitNo.AllowDrop = true;
			this.lblUnitNo.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblUnitNo.Text = "Unit Code";
			this.lblUnitNo.Location = new System.Drawing.Point(10, 25);
			// this.lblUnitNo.mLabelId = 834;
			this.lblUnitNo.Name = "lblUnitNo";
			this.lblUnitNo.Size = new System.Drawing.Size(46, 14);
			this.lblUnitNo.TabIndex = 0;
			// 
			// txtSymbol
			// 
			this.txtSymbol.AllowDrop = true;
			this.txtSymbol.BackColor = System.Drawing.Color.White;
			this.txtSymbol.ForeColor = System.Drawing.Color.Black;
			this.txtSymbol.Location = new System.Drawing.Point(112, 44);
			this.txtSymbol.MaxLength = 4;
			this.txtSymbol.Name = "txtSymbol";
			this.txtSymbol.Size = new System.Drawing.Size(101, 19);
			this.txtSymbol.TabIndex = 3;
			this.txtSymbol.Text = "";
			// 
			// txtDecimal
			// 
			this.txtDecimal.AllowDrop = true;
			this.txtDecimal.BackColor = System.Drawing.Color.White;
			// this.txtDecimal.bolNumericOnly = true;
			this.txtDecimal.ForeColor = System.Drawing.Color.Black;
			this.txtDecimal.Location = new System.Drawing.Point(264, 44);
			this.txtDecimal.MaxLength = 2;
			this.txtDecimal.Name = "txtDecimal";
			this.txtDecimal.Size = new System.Drawing.Size(101, 19);
			this.txtDecimal.TabIndex = 5;
			this.txtDecimal.Text = "";
			this.txtDecimal.Visible = false;
			// 
			// frmICSUnit
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.ClientSize = new System.Drawing.Size(427, 148);
			this.Controls.Add(this.lblUnitNameA);
			this.Controls.Add(this.txtAUnitName);
			this.Controls.Add(this.lblDecimal);
			this.Controls.Add(this.lblSymbol);
			this.Controls.Add(this.txtLUnitName);
			this.Controls.Add(this.txtUnitNo);
			this.Controls.Add(this.lblUnitNameL);
			this.Controls.Add(this.lblUnitNo);
			this.Controls.Add(this.txtSymbol);
			this.Controls.Add(this.txtDecimal);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			//this.Icon = (System.Drawing.Icon) resources.GetObject("frmICSUnit.Icon");
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(291, 336);
			this.MaximizeBox = true;
			this.MinimizeBox = true;
			this.Name = "frmICSUnit";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Unit";
			// this.Activated += new System.EventHandler(this.frmICSUnit_Activated);
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