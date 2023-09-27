
namespace Xtreme
{
	partial class frmPayClearPayroll
	{

		
		#region "Windows Form Designer generated code "
		public static frmPayClearPayroll CreateInstance()
		{
			frmPayClearPayroll theInstance = new frmPayClearPayroll();
			
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
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "pbClosePayroll", "cmdOKCancel", "lblMessage"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public Syncfusion.Windows.Forms.Tools.ProgressBarAdv pbClosePayroll;
		public UCOkCancel cmdOKCancel;
		public System.Windows.Forms.Label lblMessage;
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPayClearPayroll));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this.pbClosePayroll = new Syncfusion.Windows.Forms.Tools.ProgressBarAdv();
			this.cmdOKCancel = new UCOkCancel();
			this.lblMessage = new System.Windows.Forms.Label();
			// //((System.ComponentModel.ISupportInitialize) this.pbClosePayroll).BeginInit();
			this.SuspendLayout();
			// 
			// pbClosePayroll
			// 
			//this.pbClosePayroll.AllowDrop = true;
			this.pbClosePayroll.Location = new System.Drawing.Point(16, 62);
			this.pbClosePayroll.Name = "pbClosePayroll";
			//
			this.pbClosePayroll.Size = new System.Drawing.Size(351, 21);
			this.pbClosePayroll.TabIndex = 2;
			// 
			// cmdOKCancel
			// 
			//this.cmdOKCancel.AllowDrop = true;
			this.cmdOKCancel.DisplayButton = 0;
			this.cmdOKCancel.Location = new System.Drawing.Point(85, 91);
			this.cmdOKCancel.Name = "cmdOKCancel";
			this.cmdOKCancel.OkCaption = "&Ok";
			this.cmdOKCancel.Size = new System.Drawing.Size(206, 31);
			this.cmdOKCancel.TabIndex = 0;
			////this.cmdOKCancel.CancelClick += new UCOkCancel.CancelClickHandler(this.cmdOKCancel_CancelClick);
			////this.cmdOKCancel.OKClick += new UCOkCancel.OKClickHandler(this.cmdOKCancel_OKClick);
			// 
			// lblMessage
			// 
			//this.lblMessage.AllowDrop = true;
			this.lblMessage.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			//this.lblMessage.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lblMessage.Font = new System.Drawing.Font("Arial", 13.5f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 178);
			this.lblMessage.ForeColor = System.Drawing.Color.FromArgb(255, 128, 128);
			this.lblMessage.Location = new System.Drawing.Point(16, 20);
			this.lblMessage.Name = "lblMessage";
			this.lblMessage.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblMessage.Size = new System.Drawing.Size(351, 25);
			this.lblMessage.TabIndex = 1;
			this.lblMessage.Text = "Clear Payroll for April 2012";
			this.lblMessage.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// frmPayClearPayroll
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.ClientSize = new System.Drawing.Size(392, 190);
			this.Controls.Add(this.pbClosePayroll);
			this.Controls.Add(this.cmdOKCancel);
			this.Controls.Add(this.lblMessage);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			//this.Icon = (System.Drawing.Icon) resources.GetObject("frmPayClearPayroll.Icon");
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(288, 269);
			this.MaximizeBox = true;
			this.MinimizeBox = true;
			this.Name = "frmPayClearPayroll";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Clear Payroll";
			// this.Activated += new System.EventHandler(this.frmPayClearPayroll_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
			// this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
			//((System.ComponentModel.ISupportInitialize) this.pbClosePayroll).EndInit();
			this.ResumeLayout(false);
		}
		// 
		#endregion
	}
}//ENDSHERE
