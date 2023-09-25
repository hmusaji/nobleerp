
namespace Xtreme
{
	partial class frmGLExchangeRate
	{

		#region "Upgrade Support "
		private static frmGLExchangeRate m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmGLExchangeRate DefInstance
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
		public static frmGLExchangeRate CreateInstance()
		{
			frmGLExchangeRate theInstance = new frmGLExchangeRate();
			
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
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "txtSaleRate", "txtBuyRate", "txtStdRate", "lblSaleRate", "lblBuyRate", "lblDate", "txtdate", "lblStdRate", "txtCurrSymbol", "txtCurrNo", "System.Windows.Forms.Label1", "fraMainInformation", "tcbSystemForm"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public System.Windows.Forms.TextBox txtSaleRate;
		public System.Windows.Forms.TextBox txtBuyRate;
		public System.Windows.Forms.TextBox txtStdRate;
		public System.Windows.Forms.Label lblSaleRate;
		public System.Windows.Forms.Label lblBuyRate;
		public System.Windows.Forms.Label lblDate;
		public Syncfusion.WinForms.Input.SfDateTimeEdit txtdate;
		public System.Windows.Forms.Label lblStdRate;
		public System.Windows.Forms.TextBox txtCurrSymbol;
		public System.Windows.Forms.TextBox txtCurrNo;
		public System.Windows.Forms.Label Label1;
		public System.Windows.Forms.Panel fraMainInformation;
		public Syncfusion.Windows.Forms.Tools.CommandBarController tcbSystemForm;
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGLExchangeRate));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this.fraMainInformation = new System.Windows.Forms.Panel();
			this.txtSaleRate = new System.Windows.Forms.TextBox();
			this.txtBuyRate = new System.Windows.Forms.TextBox();
			this.txtStdRate = new System.Windows.Forms.TextBox();
			this.lblSaleRate = new System.Windows.Forms.Label();
			this.lblBuyRate = new System.Windows.Forms.Label();
			this.lblDate = new System.Windows.Forms.Label();
			this.txtdate = new Syncfusion.WinForms.Input.SfDateTimeEdit();
			this.lblStdRate = new System.Windows.Forms.Label();
			this.txtCurrSymbol = new System.Windows.Forms.TextBox();
			this.txtCurrNo = new System.Windows.Forms.TextBox();
			this.Label1 = new System.Windows.Forms.Label();
			this.tcbSystemForm = new Syncfusion.Windows.Forms.Tools.CommandBarController();
			// //((System.ComponentModel.ISupportInitialize) this.fraMainInformation).BeginInit();
			// //((System.ComponentModel.ISupportInitialize) this.tcbSystemForm).BeginInit();
			this.fraMainInformation.SuspendLayout();
			this.SuspendLayout();
			// 
			// fraMainInformation
			// 
			this.fraMainInformation.AllowDrop = true;
			this.fraMainInformation.Controls.Add(this.txtSaleRate);
			this.fraMainInformation.Controls.Add(this.txtBuyRate);
			this.fraMainInformation.Controls.Add(this.txtStdRate);
			this.fraMainInformation.Controls.Add(this.lblSaleRate);
			this.fraMainInformation.Controls.Add(this.lblBuyRate);
			this.fraMainInformation.Controls.Add(this.lblDate);
			this.fraMainInformation.Controls.Add(this.txtdate);
			this.fraMainInformation.Controls.Add(this.lblStdRate);
			this.fraMainInformation.Controls.Add(this.txtCurrSymbol);
			this.fraMainInformation.Controls.Add(this.txtCurrNo);
			this.fraMainInformation.Controls.Add(this.Label1);
			this.fraMainInformation.Location = new System.Drawing.Point(2, 42);
			this.fraMainInformation.Name = "fraMainInformation";
			//
			this.fraMainInformation.Size = new System.Drawing.Size(393, 140);
			this.fraMainInformation.TabIndex = 6;
			// 
			// txtSaleRate
			// 
			this.txtSaleRate.AllowDrop = true;
			// this.txtSaleRate.DisplayFormat = "####0.000###;;0.000;0.000";
			// this.txtSaleRate.Format = "###########0.000";
			this.txtSaleRate.Location = new System.Drawing.Point(103, 100);
			// this.txtSaleRate.MaxValue = 2147483647;
			// this.txtSaleRate.MinValue = 0;
			this.txtSaleRate.Name = "txtSaleRate";
			this.txtSaleRate.Size = new System.Drawing.Size(103, 19);
			this.txtSaleRate.TabIndex = 5;
			// this.txtSaleRate.Text = "0.000";
			// 
			// txtBuyRate
			// 
			this.txtBuyRate.AllowDrop = true;
			// this.txtBuyRate.DisplayFormat = "####0.000###;;0.000;0.000";
			// this.txtBuyRate.Format = "###########0.000";
			this.txtBuyRate.Location = new System.Drawing.Point(103, 79);
			// this.txtBuyRate.MaxValue = 2147483647;
			// this.txtBuyRate.MinValue = 0;
			this.txtBuyRate.Name = "txtBuyRate";
			this.txtBuyRate.Size = new System.Drawing.Size(103, 19);
			this.txtBuyRate.TabIndex = 4;
			// this.txtBuyRate.Text = "0.000";
			// 
			// txtStdRate
			// 
			this.txtStdRate.AllowDrop = true;
			// this.txtStdRate.DisplayFormat = "####0.000###;;0.000;0.000";
			// this.txtStdRate.Format = "###########0.000";
			this.txtStdRate.Location = new System.Drawing.Point(103, 58);
			// this.txtStdRate.MaxValue = 2147483647;
			// this.txtStdRate.MinValue = 0;
			this.txtStdRate.Name = "txtStdRate";
			this.txtStdRate.Size = new System.Drawing.Size(103, 19);
			this.txtStdRate.TabIndex = 3;
			// this.txtStdRate.Text = "0.000";
			// 
			// lblSaleRate
			// 
			this.lblSaleRate.AllowDrop = true;
			this.lblSaleRate.BackColor = System.Drawing.SystemColors.Window;
			// this.lblSaleRate.Text = "Selling Rate";
			this.lblSaleRate.Location = new System.Drawing.Point(12, 102);
			this.lblSaleRate.Name = "lblSaleRate";
			this.lblSaleRate.Size = new System.Drawing.Size(56, 14);
			this.lblSaleRate.TabIndex = 7;
			// 
			// lblBuyRate
			// 
			this.lblBuyRate.AllowDrop = true;
			this.lblBuyRate.BackColor = System.Drawing.SystemColors.Window;
			// this.lblBuyRate.Text = "Buying Rate";
			this.lblBuyRate.Location = new System.Drawing.Point(12, 81);
			this.lblBuyRate.Name = "lblBuyRate";
			this.lblBuyRate.Size = new System.Drawing.Size(58, 14);
			this.lblBuyRate.TabIndex = 8;
			// 
			// lblDate
			// 
			this.lblDate.AllowDrop = true;
			this.lblDate.BackColor = System.Drawing.SystemColors.Window;
			// this.lblDate.Text = "Date";
			this.lblDate.Location = new System.Drawing.Point(12, 18);
			this.lblDate.Name = "lblDate";
			this.lblDate.Size = new System.Drawing.Size(22, 14);
			this.lblDate.TabIndex = 9;
			// 
			// txtdate
			// 
			this.txtdate.AllowDrop = true;
			this.txtdate.Location = new System.Drawing.Point(103, 16);
			// this.txtdate.MaxDate = 2958465;
			// this.txtdate.MinDate = -657434;
			this.txtdate.Name = "txtdate";
			this.txtdate.Size = new System.Drawing.Size(103, 19);
			this.txtdate.TabIndex = 0;
			// this.txtdate.Text = "7/18/2001";
			// this.txtdate.Value = 37090;
			// 
			// lblStdRate
			// 
			this.lblStdRate.AllowDrop = true;
			this.lblStdRate.BackColor = System.Drawing.SystemColors.Window;
			// this.lblStdRate.Text = "Standard Rate";
			this.lblStdRate.Location = new System.Drawing.Point(12, 60);
			this.lblStdRate.Name = "lblStdRate";
			this.lblStdRate.Size = new System.Drawing.Size(69, 14);
			this.lblStdRate.TabIndex = 10;
			// 
			// txtCurrSymbol
			// 
			this.txtCurrSymbol.AllowDrop = true;
			this.txtCurrSymbol.BackColor = System.Drawing.Color.FromArgb(239, 239, 239);
			this.txtCurrSymbol.Enabled = false;
			this.txtCurrSymbol.ForeColor = System.Drawing.Color.Black;
			this.txtCurrSymbol.Location = new System.Drawing.Point(172, 37);
			this.txtCurrSymbol.Name = "txtCurrSymbol";
			this.txtCurrSymbol.Size = new System.Drawing.Size(35, 19);
			this.txtCurrSymbol.TabIndex = 2;
			this.txtCurrSymbol.Text = "";
			// 
			// txtCurrNo
			// 
			this.txtCurrNo.AllowDrop = true;
			this.txtCurrNo.BackColor = System.Drawing.Color.White;
			this.txtCurrNo.ForeColor = System.Drawing.Color.Black;
			this.txtCurrNo.Location = new System.Drawing.Point(103, 37);
			this.txtCurrNo.Name = "txtCurrNo";
			// this.txtCurrNo.ShowButton = true;
			this.txtCurrNo.Size = new System.Drawing.Size(67, 19);
			this.txtCurrNo.TabIndex = 1;
			this.txtCurrNo.Text = "";
			// this.this.txtCurrNo.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtCurrNo_DropButtonClick);
			// this.txtCurrNo.Leave += new System.EventHandler(this.txtCurrNo_Leave);
			// 
			// System.Windows.Forms.Label1
			// 
			this.Label1.AllowDrop = true;
			this.Label1.BackColor = System.Drawing.SystemColors.Window;
			this.Label1.Text = "Currency Code";
			this.Label1.Location = new System.Drawing.Point(12, 39);
			this.Label1.Name = "System.Windows.Forms.Label1";
			this.Label1.Size = new System.Drawing.Size(73, 14);
			this.Label1.TabIndex = 11;
			// 
			// tcbSystemForm
			// 
			this.tcbSystemForm.AllowDrop = true;
			this.tcbSystemForm.Location = new System.Drawing.Point(116, 4);
			this.tcbSystemForm.Name = "tcbSystemForm";
			//
			// 
			// frmGLExchangeRate
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.FromArgb(213, 213, 213);
			this.ClientSize = new System.Drawing.Size(400, 186);
			this.Controls.Add(this.fraMainInformation);
			this.Controls.Add(this.tcbSystemForm);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			//this.Icon = (System.Drawing.Icon) resources.GetObject("frmGLExchangeRate.Icon");
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(113, 190);
			this.MaximizeBox = true;
			this.MinimizeBox = true;
			this.Name = "frmGLExchangeRate";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Rate of Exchange";
			// this.Activated += new System.EventHandler(this.frmGLExchangeRate_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
			// this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
			//((System.ComponentModel.ISupportInitialize) this.fraMainInformation).EndInit();
			//((System.ComponentModel.ISupportInitialize) this.tcbSystemForm).EndInit();
			this.fraMainInformation.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		// 
		#endregion
	}
}//ENDSHERE
