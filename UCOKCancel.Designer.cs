
namespace Xtreme
{
	partial class UCOkCancel
	{

		#region "Windows Form Designer generated code "
		public static UCOkCancel CreateInstance()
		{
			UCOkCancel theInstance = new UCOkCancel();
			return theInstance;
		}
		private string[] visualControls = new string[]{"components", "ToolTipMain", "_cmdButton_1", "_cmdButton_0", "cmdButton"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		internal System.Windows.Forms.Button _cmdButton_1;
		internal System.Windows.Forms.Button _cmdButton_0;
		internal System.Windows.Forms.Button[] cmdButton = new System.Windows.Forms.Button[2];
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCOkCancel));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this._cmdButton_1 = new System.Windows.Forms.Button();
			this._cmdButton_0 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// _cmdButton_1
			// 
			this._cmdButton_1.AllowDrop = true;
			this._cmdButton_1.BackColor = System.Drawing.SystemColors.Control;
			this._cmdButton_1.ForeColor = System.Drawing.SystemColors.ControlText;
			this._cmdButton_1.Location = new System.Drawing.Point(104, 0);
			this._cmdButton_1.Name = "_cmdButton_1";
			this._cmdButton_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._cmdButton_1.Size = new System.Drawing.Size(102, 29);
			this._cmdButton_1.TabIndex = 1;
			this._cmdButton_1.Text = "&Cancel";
			this._cmdButton_1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this._cmdButton_1.UseVisualStyleBackColor = false;
			this._cmdButton_1.Click += new System.EventHandler(this.cmdButton_Click);
			this._cmdButton_1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmdButton_KeyDown);
			// 
			// _cmdButton_0
			// 
			this._cmdButton_0.AllowDrop = true;
			this._cmdButton_0.BackColor = System.Drawing.SystemColors.Control;
			this._cmdButton_0.ForeColor = System.Drawing.SystemColors.ControlText;
			this._cmdButton_0.Location = new System.Drawing.Point(0, 0);
			this._cmdButton_0.Name = "_cmdButton_0";
			this._cmdButton_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._cmdButton_0.Size = new System.Drawing.Size(102, 29);
			this._cmdButton_0.TabIndex = 0;
			this._cmdButton_0.Text = "&Ok";
			this._cmdButton_0.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this._cmdButton_0.UseVisualStyleBackColor = false;
			this._cmdButton_0.Click += new System.EventHandler(this.cmdButton_Click);
			this._cmdButton_0.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmdButton_KeyDown);
			// 
			// UCOkCancel
			// 
			this.ClientSize = new System.Drawing.Size(255, 46);
			this.Controls.Add(this._cmdButton_1);
			this.Controls.Add(this._cmdButton_0);
			this.Location = new System.Drawing.Point(0, 0);
			this.Name = "UCOkCancel";
			base.Resize += new System.EventHandler(this.UserControl_Resize);
			this.ResumeLayout(false);
		}
		void ReLoadForm(bool addEvents)
		{
			InitializecmdButton();
			UserControl_Initialize();
		}
		void InitializecmdButton()
		{
			this.cmdButton = new System.Windows.Forms.Button[2];
			this.cmdButton[1] = _cmdButton_1;
			this.cmdButton[0] = _cmdButton_0;
		}
		#endregion
	}
}