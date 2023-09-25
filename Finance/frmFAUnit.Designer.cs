
namespace Xtreme
{
	partial class frmFAUnit
	{

	
		#region "Windows Form Designer generated code "
		public static frmFAUnit CreateInstance()
		{
			frmFAUnit theInstance = new frmFAUnit();
			
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
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "txtUnitNo", "lblUnitNo", "lblLUnitName", "lblAUnitName", "txtLUnitName", "txtAUnitName", "lblSymbol", "txtSymbol"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public System.Windows.Forms.TextBox txtUnitNo;
		public System.Windows.Forms.Label lblUnitNo;
		public System.Windows.Forms.Label lblLUnitName;
		public System.Windows.Forms.Label lblAUnitName;
		public System.Windows.Forms.TextBox txtLUnitName;
		public System.Windows.Forms.TextBox txtAUnitName;
		public System.Windows.Forms.Label lblSymbol;
		public System.Windows.Forms.TextBox txtSymbol;
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFAUnit));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this.txtUnitNo = new System.Windows.Forms.TextBox();
			this.lblUnitNo = new System.Windows.Forms.Label();
			this.lblLUnitName = new System.Windows.Forms.Label();
			this.lblAUnitName = new System.Windows.Forms.Label();
			this.txtLUnitName = new System.Windows.Forms.TextBox();
			this.txtAUnitName = new System.Windows.Forms.TextBox();
			this.lblSymbol = new System.Windows.Forms.Label();
			this.txtSymbol = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// txtUnitNo
			// 
			this.txtUnitNo.AllowDrop = true;
			this.txtUnitNo.BackColor = System.Drawing.Color.White;
			// this.txtUnitNo.bolNumericOnly = true;
			this.txtUnitNo.ForeColor = System.Drawing.Color.Black;
			this.txtUnitNo.Location = new System.Drawing.Point(152, 51);
			this.txtUnitNo.MaxLength = 4;
			// this.txtUnitNo.mDropDownType = System.Windows.Forms.TextBox.DropDownTypes.ddtNextNumber;
			this.txtUnitNo.Name = "txtUnitNo";
			// this.txtUnitNo.ShowButton = true;
			this.txtUnitNo.Size = new System.Drawing.Size(101, 19);
			this.txtUnitNo.TabIndex = 0;
			this.txtUnitNo.Text = "";
			// this.this.txtUnitNo.Watermark = "";
			// this.this.txtUnitNo.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtUnitNo_DropButtonClick);
			// 
			// lblUnitNo
			// 
			this.lblUnitNo.AllowDrop = true;
			this.lblUnitNo.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblUnitNo.Text = "Unit Code";
			this.lblUnitNo.ForeColor = System.Drawing.Color.Black;
			this.lblUnitNo.Location = new System.Drawing.Point(8, 53);
			// this.lblUnitNo.mLabelId = 988;
			this.lblUnitNo.Name = "lblUnitNo";
			this.lblUnitNo.Size = new System.Drawing.Size(47, 13);
			this.lblUnitNo.TabIndex = 4;
			// 
			// lblLUnitName
			// 
			this.lblLUnitName.AllowDrop = true;
			this.lblLUnitName.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblLUnitName.Text = "Unit Name (English)";
			this.lblLUnitName.ForeColor = System.Drawing.Color.Black;
			this.lblLUnitName.Location = new System.Drawing.Point(8, 95);
			// this.lblLUnitName.mLabelId = 1028;
			this.lblLUnitName.Name = "lblLUnitName";
			this.lblLUnitName.Size = new System.Drawing.Size(93, 14);
			this.lblLUnitName.TabIndex = 5;
			// 
			// lblAUnitName
			// 
			this.lblAUnitName.AllowDrop = true;
			this.lblAUnitName.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblAUnitName.Text = "Unit Name (Arabic)";
			this.lblAUnitName.ForeColor = System.Drawing.Color.Black;
			this.lblAUnitName.Location = new System.Drawing.Point(8, 116);
			// this.lblAUnitName.mLabelId = 1029;
			this.lblAUnitName.Name = "lblAUnitName";
			this.lblAUnitName.Size = new System.Drawing.Size(91, 14);
			this.lblAUnitName.TabIndex = 6;
			// 
			// txtLUnitName
			// 
			this.txtLUnitName.AllowDrop = true;
			this.txtLUnitName.BackColor = System.Drawing.Color.White;
			this.txtLUnitName.ForeColor = System.Drawing.Color.Black;
			this.txtLUnitName.Location = new System.Drawing.Point(152, 93);
			this.txtLUnitName.MaxLength = 50;
			this.txtLUnitName.Name = "txtLUnitName";
			this.txtLUnitName.Size = new System.Drawing.Size(241, 19);
			this.txtLUnitName.TabIndex = 2;
			this.txtLUnitName.Tag = "Salesman Name in English";
			this.txtLUnitName.Text = "";
			// this.this.txtLUnitName.Watermark = "";
			// 
			// txtAUnitName
			// 
			this.txtAUnitName.AllowDrop = true;
			this.txtAUnitName.BackColor = System.Drawing.Color.White;
			this.txtAUnitName.ForeColor = System.Drawing.Color.Black;
			this.txtAUnitName.Location = new System.Drawing.Point(152, 114);
			// this.txtAUnitName.mArabicEnabled = true;
			this.txtAUnitName.MaxLength = 50;
			this.txtAUnitName.Name = "txtAUnitName";
			this.txtAUnitName.Size = new System.Drawing.Size(241, 19);
			this.txtAUnitName.TabIndex = 3;
			this.txtAUnitName.Text = "";
			// this.this.txtAUnitName.Watermark = "";
			// 
			// lblSymbol
			// 
			this.lblSymbol.AllowDrop = true;
			this.lblSymbol.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblSymbol.Text = "Symbol";
			this.lblSymbol.ForeColor = System.Drawing.Color.Black;
			this.lblSymbol.Location = new System.Drawing.Point(9, 72);
			// this.lblSymbol.mLabelId = 1027;
			this.lblSymbol.Name = "lblSymbol";
			this.lblSymbol.Size = new System.Drawing.Size(35, 14);
			this.lblSymbol.TabIndex = 7;
			// 
			// txtSymbol
			// 
			this.txtSymbol.AllowDrop = true;
			this.txtSymbol.BackColor = System.Drawing.Color.White;
			this.txtSymbol.ForeColor = System.Drawing.Color.Black;
			this.txtSymbol.Location = new System.Drawing.Point(152, 72);
			this.txtSymbol.MaxLength = 4;
			this.txtSymbol.Name = "txtSymbol";
			this.txtSymbol.Size = new System.Drawing.Size(101, 19);
			this.txtSymbol.TabIndex = 1;
			this.txtSymbol.Text = "";
			// this.this.txtSymbol.Watermark = "";
			// 
			// frmFAUnit
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.ClientSize = new System.Drawing.Size(410, 139);
			this.Controls.Add(this.txtUnitNo);
			this.Controls.Add(this.lblUnitNo);
			this.Controls.Add(this.lblLUnitName);
			this.Controls.Add(this.lblAUnitName);
			this.Controls.Add(this.txtLUnitName);
			this.Controls.Add(this.txtAUnitName);
			this.Controls.Add(this.lblSymbol);
			this.Controls.Add(this.txtSymbol);
			//this.Icon = (System.Drawing.Icon) resources.GetObject("frmFAUnit.Icon");
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(239, 209);
			this.MaximizeBox = true;
			this.MinimizeBox = true;
			this.Name = "frmFAUnit";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Fixed Assets Unit";
			this.ToolTipMain.SetToolTip(this.txtLUnitName, "Salesman Name in English");
			// this.Activated += new System.EventHandler(this.frmFAUnit_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
			// this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
			this.ResumeLayout(false);
		}
		
		#endregion
	}
}