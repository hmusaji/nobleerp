
namespace Xtreme
{
	partial class frmGLCurrency
	{

		#region "Upgrade Support "
		private static frmGLCurrency m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmGLCurrency DefInstance
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
		public static frmGLCurrency CreateInstance()
		{
			frmGLCurrency theInstance = new frmGLCurrency();
			
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
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "lblCurrNameA", "txtACurrName", "lblDecimal", "lblSymbol", "txtLCurrName", "txtCurrNo", "lblCurrNameL", "lblCurrNo", "txtSymbol", "txtDecimal", "txtExchangeRate", "_lblCommonLabel_14", "lblCommonLabel"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public System.Windows.Forms.Label lblCurrNameA;
		public System.Windows.Forms.TextBox txtACurrName;
		public System.Windows.Forms.Label lblDecimal;
		public System.Windows.Forms.Label lblSymbol;
		public System.Windows.Forms.TextBox txtLCurrName;
		public System.Windows.Forms.TextBox txtCurrNo;
		public System.Windows.Forms.Label lblCurrNameL;
		public System.Windows.Forms.Label lblCurrNo;
		public System.Windows.Forms.TextBox txtSymbol;
		public System.Windows.Forms.TextBox txtDecimal;
		public System.Windows.Forms.TextBox txtExchangeRate;
		private System.Windows.Forms.Label _lblCommonLabel_14;
		public System.Windows.Forms.Label[] lblCommonLabel = new System.Windows.Forms.Label[15];
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGLCurrency));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this.lblCurrNameA = new System.Windows.Forms.Label();
			this.txtACurrName = new System.Windows.Forms.TextBox();
			this.lblDecimal = new System.Windows.Forms.Label();
			this.lblSymbol = new System.Windows.Forms.Label();
			this.txtLCurrName = new System.Windows.Forms.TextBox();
			this.txtCurrNo = new System.Windows.Forms.TextBox();
			this.lblCurrNameL = new System.Windows.Forms.Label();
			this.lblCurrNo = new System.Windows.Forms.Label();
			this.txtSymbol = new System.Windows.Forms.TextBox();
			this.txtDecimal = new System.Windows.Forms.TextBox();
			this.txtExchangeRate = new System.Windows.Forms.TextBox();
			this._lblCommonLabel_14 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// lblCurrNameA
			// 
			//this.lblCurrNameA.AllowDrop = true;
			this.lblCurrNameA.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblCurrNameA.Text = "Currency Name (Arabic)";
			this.lblCurrNameA.Location = new System.Drawing.Point(9, 90);
			// // this.lblCurrNameA.mLabelId = 963;
			this.lblCurrNameA.Name = "lblCurrNameA";
			this.lblCurrNameA.Size = new System.Drawing.Size(118, 14);
			this.lblCurrNameA.TabIndex = 10;
			// 
			// txtACurrName
			// 
			//this.txtACurrName.AllowDrop = true;
			this.txtACurrName.BackColor = System.Drawing.Color.White;
			this.txtACurrName.ForeColor = System.Drawing.Color.Black;
			this.txtACurrName.Location = new System.Drawing.Point(158, 88);
			// // = true;
			this.txtACurrName.MaxLength = 20;
			this.txtACurrName.Name = "txtACurrName";
			this.txtACurrName.Size = new System.Drawing.Size(201, 19);
			this.txtACurrName.TabIndex = 4;
			this.txtACurrName.Text = "";
			// this.// = "";
			// 
			// lblDecimal
			// 
			//this.lblDecimal.AllowDrop = true;
			this.lblDecimal.BackColor = System.Drawing.SystemColors.Window;
			this.lblDecimal.Text = "Decimal";
			this.lblDecimal.Location = new System.Drawing.Point(248, 48);
			this.lblDecimal.Name = "lblDecimal";
			this.lblDecimal.Size = new System.Drawing.Size(37, 14);
			this.lblDecimal.TabIndex = 8;
			// 
			// lblSymbol
			// 
			//this.lblSymbol.AllowDrop = true;
			this.lblSymbol.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblSymbol.Text = "Symbol";
			this.lblSymbol.Location = new System.Drawing.Point(9, 48);
			// // this.lblSymbol.mLabelId = 772;
			this.lblSymbol.Name = "lblSymbol";
			this.lblSymbol.Size = new System.Drawing.Size(35, 14);
			this.lblSymbol.TabIndex = 7;
			// 
			// txtLCurrName
			// 
			//this.txtLCurrName.AllowDrop = true;
			this.txtLCurrName.BackColor = System.Drawing.Color.White;
			this.txtLCurrName.ForeColor = System.Drawing.Color.Black;
			this.txtLCurrName.Location = new System.Drawing.Point(158, 67);
			this.txtLCurrName.MaxLength = 20;
			this.txtLCurrName.Name = "txtLCurrName";
			this.txtLCurrName.Size = new System.Drawing.Size(201, 19);
			this.txtLCurrName.TabIndex = 3;
			this.txtLCurrName.Text = "";
			// this.// = "";
			// 
			// txtCurrNo
			// 
			//this.txtCurrNo.AllowDrop = true;
			this.txtCurrNo.BackColor = System.Drawing.Color.White;
			// this.txtCurrNo.bolNumericOnly = true;
			this.txtCurrNo.ForeColor = System.Drawing.Color.Black;
			this.txtCurrNo.Location = new System.Drawing.Point(158, 25);
			this.txtCurrNo.MaxLength = 3;
			// // = System.Windows.Forms.TextBox.DropDownTypes.ddtNextNumber;
			this.txtCurrNo.Name = "txtCurrNo";
			// this.txtCurrNo.ShowButton = true;
			this.txtCurrNo.Size = new System.Drawing.Size(101, 19);
			this.txtCurrNo.TabIndex = 0;
			this.txtCurrNo.Text = "";
			// this.// = "";
			// this.//this.txtCurrNo.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(//this.txtCurrNo_DropButtonClick);
			// 
			// lblCurrNameL
			// 
			//this.lblCurrNameL.AllowDrop = true;
			this.lblCurrNameL.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblCurrNameL.Text = "Currency Name (English)";
			this.lblCurrNameL.Location = new System.Drawing.Point(9, 69);
			// // this.lblCurrNameL.mLabelId = 171;
			this.lblCurrNameL.Name = "lblCurrNameL";
			this.lblCurrNameL.Size = new System.Drawing.Size(120, 14);
			this.lblCurrNameL.TabIndex = 9;
			// 
			// lblCurrNo
			// 
			//this.lblCurrNo.AllowDrop = true;
			this.lblCurrNo.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblCurrNo.Text = "Currency Code";
			this.lblCurrNo.Location = new System.Drawing.Point(9, 27);
			// // this.lblCurrNo.mLabelId = 170;
			this.lblCurrNo.Name = "lblCurrNo";
			this.lblCurrNo.Size = new System.Drawing.Size(73, 14);
			this.lblCurrNo.TabIndex = 6;
			// 
			// txtSymbol
			// 
			//this.txtSymbol.AllowDrop = true;
			this.txtSymbol.BackColor = System.Drawing.Color.White;
			this.txtSymbol.ForeColor = System.Drawing.Color.Black;
			this.txtSymbol.Location = new System.Drawing.Point(158, 46);
			this.txtSymbol.MaxLength = 3;
			this.txtSymbol.Name = "txtSymbol";
			this.txtSymbol.Size = new System.Drawing.Size(61, 19);
			this.txtSymbol.TabIndex = 1;
			this.txtSymbol.Text = "";
			// this.// = "";
			// 
			// txtDecimal
			// 
			//this.txtDecimal.AllowDrop = true;
			this.txtDecimal.BackColor = System.Drawing.Color.White;
			// this.txtDecimal.bolNumericOnly = true;
			this.txtDecimal.ForeColor = System.Drawing.Color.Black;
			this.txtDecimal.Location = new System.Drawing.Point(298, 46);
			this.txtDecimal.MaxLength = 1;
			this.txtDecimal.Name = "txtDecimal";
			this.txtDecimal.Size = new System.Drawing.Size(61, 19);
			this.txtDecimal.TabIndex = 2;
			this.txtDecimal.Text = "";
			// this.// = "";
			// 
			// txtExchangeRate
			// 
			//this.txtExchangeRate.AllowDrop = true;
			// this.txtExchangeRate.DisplayFormat = "####0.000######;; ; ";
			// this.txtExchangeRate.Format = "####0.000######";
			this.txtExchangeRate.Location = new System.Drawing.Point(158, 109);
			// // = 2147483647;
			// // = 0;
			this.txtExchangeRate.Name = "txtExchangeRate";
			this.txtExchangeRate.Size = new System.Drawing.Size(102, 19);
			this.txtExchangeRate.TabIndex = 5;
			// this.txtExchangeRate.Text = "0.000";
			// 
			// _lblCommonLabel_14
			// 
			//this._lblCommonLabel_14.AllowDrop = true;
			this._lblCommonLabel_14.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_14.Text = "Exchange Rate";
			this._lblCommonLabel_14.Location = new System.Drawing.Point(9, 111);
			this._lblCommonLabel_14.Name = "_lblCommonLabel_14";
			this._lblCommonLabel_14.Size = new System.Drawing.Size(73, 14);
			this._lblCommonLabel_14.TabIndex = 11;
			// 
			// frmGLCurrency
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.ClientSize = new System.Drawing.Size(382, 185);
			this.Controls.Add(this.lblCurrNameA);
			this.Controls.Add(this.txtACurrName);
			this.Controls.Add(this.lblDecimal);
			this.Controls.Add(this.lblSymbol);
			this.Controls.Add(this.txtLCurrName);
			this.Controls.Add(this.txtCurrNo);
			this.Controls.Add(this.lblCurrNameL);
			this.Controls.Add(this.lblCurrNo);
			this.Controls.Add(this.txtSymbol);
			this.Controls.Add(this.txtDecimal);
			this.Controls.Add(this.txtExchangeRate);
			this.Controls.Add(this._lblCommonLabel_14);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			//this.Icon = (System.Drawing.Icon) resources.GetObject("frmGLCurrency.Icon");
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(215, 216);
			this.MaximizeBox = true;
			this.MinimizeBox = true;
			this.Name = "frmGLCurrency";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Currency";
			// this.Activated += new System.EventHandler(this.frmGLCurrency_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
			// this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
			this.ResumeLayout(false);
		}
		// 
		void InitializelblCommonLabel()
		{
			this.lblCommonLabel = new System.Windows.Forms.Label[15];
			this.lblCommonLabel[14] = _lblCommonLabel_14;
		}
		#endregion
	}
}//ENDSHERE
