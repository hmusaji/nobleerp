
namespace Xtreme
{
	partial class frmSysError
	{

		#region "Upgrade Support "
		private static frmSysError m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmSysError DefInstance
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
		public static frmSysError CreateInstance()
		{
			frmSysError theInstance = new frmSysError();
			
			return theInstance;
		}
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "btnMore", "cmdCancel", "cmdOk", "cmdRetry", "txtLineNo", "Label1", "txtModule", "lblMod", "lblReason", "lblError", "lblRes", "txtSolution", "lblSolution", "ImgQuestion", "ImgExclamation", "ImgInformation", "ImgCritical", "ShortcutCaption1"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public System.Windows.Forms.Button btnMore;
		public System.Windows.Forms.Button cmdCancel;
		public System.Windows.Forms.Button cmdOk;
		public System.Windows.Forms.Button cmdRetry;
		public System.Windows.Forms.Label txtLineNo;
		public System.Windows.Forms.Label Label1;
		public System.Windows.Forms.Label txtModule;
		public System.Windows.Forms.Label lblMod;
		public System.Windows.Forms.Label lblReason;
		public System.Windows.Forms.Label lblError;
		public System.Windows.Forms.Label lblRes;
		public System.Windows.Forms.Label txtSolution;
		public System.Windows.Forms.Label lblSolution;
		public System.Windows.Forms.PictureBox ImgQuestion;
		public System.Windows.Forms.PictureBox ImgExclamation;
		public System.Windows.Forms.PictureBox ImgInformation;
		public System.Windows.Forms.PictureBox ImgCritical;
		public AxXtremeShortcutBar.AxShortcutCaption ShortcutCaption1;
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSysError));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this.btnMore = new System.Windows.Forms.Button();
			this.cmdCancel = new System.Windows.Forms.Button();
			this.cmdOk = new System.Windows.Forms.Button();
			this.cmdRetry = new System.Windows.Forms.Button();
			this.txtLineNo = new System.Windows.Forms.Label();
			this.Label1 = new System.Windows.Forms.Label();
			this.txtModule = new System.Windows.Forms.Label();
			this.lblMod = new System.Windows.Forms.Label();
			this.lblReason = new System.Windows.Forms.Label();
			this.lblError = new System.Windows.Forms.Label();
			this.lblRes = new System.Windows.Forms.Label();
			this.txtSolution = new System.Windows.Forms.Label();
			this.lblSolution = new System.Windows.Forms.Label();
			this.ImgQuestion = new System.Windows.Forms.PictureBox();
			this.ImgExclamation = new System.Windows.Forms.PictureBox();
			this.ImgInformation = new System.Windows.Forms.PictureBox();
			this.ImgCritical = new System.Windows.Forms.PictureBox();
			this.Shortcu.Text1 = new AxXtremeShortcutBar.AxShortcutCaption();
			// //((System.ComponentModel.ISupportInitialize) this.Shortcu.Text1).BeginInit();
			this.SuspendLayout();
			// 
			// btnMore
			// 
			this.btnMore.AllowDrop = true;
			this.btnMore.BackColor = System.Drawing.SystemColors.Control;
			this.btnMore.ForeColor = System.Drawing.SystemColors.ControlText;
			this.btnMore.Location = new System.Drawing.Point(374, 90);
			this.btnMore.Name = "btnMore";
			this.btnMore.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.btnMore.Size = new System.Drawing.Size(67, 31);
			this.btnMore.TabIndex = 8;
			this.btnMore.Text = "&Detail >>";
			this.btnMore.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.btnMore.UseVisualStyleBackColor = false;
			this.btnMore.Visible = false;
			// this.btnMore.Click += new System.EventHandler(this.btnMore_Click);
			// 
			// cmdCancel
			// 
			this.cmdCancel.AllowDrop = true;
			this.cmdCancel.BackColor = System.Drawing.SystemColors.Control;
			this.cmdCancel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdCancel.Location = new System.Drawing.Point(256, 90);
			this.cmdCancel.Name = "cmdCancel";
			this.cmdCancel.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdCancel.Size = new System.Drawing.Size(67, 31);
			this.cmdCancel.TabIndex = 7;
			this.cmdCancel.Text = "&Cancel";
			this.cmdCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.cmdCancel.UseVisualStyleBackColor = false;
			this.cmdCancel.Visible = false;
			// this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
			// 
			// cmdOk
			// 
			this.cmdOk.AllowDrop = true;
			this.cmdOk.BackColor = System.Drawing.SystemColors.Control;
			this.cmdOk.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdOk.Location = new System.Drawing.Point(184, 90);
			this.cmdOk.Name = "cmdOk";
			this.cmdOk.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdOk.Size = new System.Drawing.Size(67, 31);
			this.cmdOk.TabIndex = 6;
			this.cmdOk.Text = "&OK";
			this.cmdOk.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.cmdOk.UseVisualStyleBackColor = false;
			this.cmdOk.Visible = false;
			// this.cmdOk.Click += new System.EventHandler(this.cmdOk_Click);
			// 
			// cmdRetry
			// 
			this.cmdRetry.AllowDrop = true;
			this.cmdRetry.BackColor = System.Drawing.SystemColors.Control;
			this.cmdRetry.CausesValidation = false;
			this.cmdRetry.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdRetry.Location = new System.Drawing.Point(112, 90);
			this.cmdRetry.Name = "cmdRetry";
			this.cmdRetry.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdRetry.Size = new System.Drawing.Size(67, 31);
			this.cmdRetry.TabIndex = 5;
			this.cmdRetry.Text = "&Retry";
			this.cmdRetry.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.cmdRetry.UseVisualStyleBackColor = false;
			this.cmdRetry.Visible = false;
			// this.cmdRetry.Click += new System.EventHandler(this.cmdRetry_Click);
			// 
			// txtLineNo
			// 
			this.txtLineNo.AllowDrop = true;
			this.txtLineNo.BackColor = System.Drawing.Color.White;
			this.txtLineNo.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtLineNo.ForeColor = System.Drawing.SystemColors.ControlText;
			this.txtLineNo.Location = new System.Drawing.Point(58, 366);
			this.txtLineNo.Name = "txtLineNo";
			this.txtLineNo.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtLineNo.Size = new System.Drawing.Size(379, 19);
			this.txtLineNo.TabIndex = 12;
			// 
			// Label1
			// 
			this.Label1.AllowDrop = true;
			this.Label1.BackColor = System.Drawing.Color.White;
			this.Label1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Label1.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 178);
			this.Label1.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Label1.Location = new System.Drawing.Point(10, 366);
			this.Label1.Name = "Label1";
			this.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label1.Size = new System.Drawing.Size(47, 19);
			this.Label1.TabIndex = 11;
			this.Label1.Text = "Line No:";
			// 
			// txtModule
			// 
			this.txtModule.AllowDrop = true;
			this.txtModule.BackColor = System.Drawing.Color.White;
			this.txtModule.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtModule.ForeColor = System.Drawing.SystemColors.ControlText;
			this.txtModule.Location = new System.Drawing.Point(58, 340);
			this.txtModule.Name = "txtModule";
			this.txtModule.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtModule.Size = new System.Drawing.Size(379, 19);
			this.txtModule.TabIndex = 10;
			// 
			// lblMod
			// 
			this.lblMod.AllowDrop = true;
			this.lblMod.BackColor = System.Drawing.Color.White;
			this.lblMod.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lblMod.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 178);
			this.lblMod.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblMod.Location = new System.Drawing.Point(10, 340);
			this.lblMod.Name = "lblMod";
			this.lblMod.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblMod.Size = new System.Drawing.Size(47, 19);
			this.lblMod.TabIndex = 9;
			this.lblMod.Text = "Module:";
			// 
			// lblReason
			// 
			this.lblReason.AllowDrop = true;
			this.lblReason.BackColor = System.Drawing.Color.White;
			this.lblReason.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lblReason.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblReason.Location = new System.Drawing.Point(474, 148);
			this.lblReason.Name = "lblReason";
			this.lblReason.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblReason.Size = new System.Drawing.Size(329, 63);
			this.lblReason.TabIndex = 4;
			// 
			// lblError
			// 
			this.lblError.AllowDrop = true;
			this.lblError.BackColor = System.Drawing.Color.Transparent;
			this.lblError.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lblError.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 178);
			this.lblError.ForeColor = System.Drawing.Color.Blue;
			this.lblError.Location = new System.Drawing.Point(108, 28);
			this.lblError.Name = "lblError";
			this.lblError.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblError.Size = new System.Drawing.Size(231, 52);
			this.lblError.TabIndex = 3;
			// 
			// lblRes
			// 
			this.lblRes.AllowDrop = true;
			this.lblRes.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			this.lblRes.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lblRes.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 178);
			this.lblRes.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblRes.Location = new System.Drawing.Point(474, 126);
			this.lblRes.Name = "lblRes";
			this.lblRes.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblRes.Size = new System.Drawing.Size(329, 17);
			this.lblRes.TabIndex = 2;
			this.lblRes.Text = "Reason";
			this.lblRes.Visible = false;
			// 
			// txtSolution
			// 
			this.txtSolution.AllowDrop = true;
			this.txtSolution.BackColor = System.Drawing.Color.White;
			this.txtSolution.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtSolution.ForeColor = System.Drawing.SystemColors.ControlText;
			this.txtSolution.Location = new System.Drawing.Point(8, 254);
			this.txtSolution.Name = "txtSolution";
			this.txtSolution.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtSolution.Size = new System.Drawing.Size(431, 75);
			this.txtSolution.TabIndex = 1;
			// 
			// lblSolution
			// 
			this.lblSolution.AllowDrop = true;
			this.lblSolution.BackColor = System.Drawing.Color.White;
			this.lblSolution.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lblSolution.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 178);
			this.lblSolution.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblSolution.Location = new System.Drawing.Point(8, 228);
			this.lblSolution.Name = "lblSolution";
			this.lblSolution.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblSolution.Size = new System.Drawing.Size(179, 19);
			this.lblSolution.TabIndex = 0;
			this.lblSolution.Text = "Solution";
			// 
			// ImgQuestion
			// 
			this.ImgQuestion.AllowDrop = true;
			this.ImgQuestion.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.ImgQuestion.Enabled = true;
			//this.ImgQuestion.Image = (System.Drawing.Image) resources.GetObject("ImgQuestion.Image");
			this.ImgQuestion.Location = new System.Drawing.Point(10, 14);
			this.ImgQuestion.Name = "ImgQuestion";
			this.ImgQuestion.Size = new System.Drawing.Size(76, 73);
			this.ImgQuestion.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal;
			this.ImgQuestion.Visible = false;
			// 
			// ImgExclamation
			// 
			this.ImgExclamation.AllowDrop = true;
			this.ImgExclamation.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.ImgExclamation.Enabled = true;
			//this.ImgExclamation.Image = (System.Drawing.Image) resources.GetObject("ImgExclamation.Image");
			this.ImgExclamation.Location = new System.Drawing.Point(10, 12);
			this.ImgExclamation.Name = "ImgExclamation";
			this.ImgExclamation.Size = new System.Drawing.Size(76, 73);
			this.ImgExclamation.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal;
			this.ImgExclamation.Visible = false;
			// 
			// ImgInformation
			// 
			this.ImgInformation.AllowDrop = true;
			this.ImgInformation.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.ImgInformation.Enabled = true;
			//this.ImgInformation.Image = (System.Drawing.Image) resources.GetObject("ImgInformation.Image");
			this.ImgInformation.Location = new System.Drawing.Point(10, 12);
			this.ImgInformation.Name = "ImgInformation";
			this.ImgInformation.Size = new System.Drawing.Size(76, 73);
			this.ImgInformation.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal;
			this.ImgInformation.Visible = false;
			// 
			// ImgCritical
			// 
			this.ImgCritical.AllowDrop = true;
			this.ImgCritical.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.ImgCritical.Enabled = true;
			//this.ImgCritical.Image = (System.Drawing.Image) resources.GetObject("ImgCritical.Image");
			this.ImgCritical.Location = new System.Drawing.Point(10, 12);
			this.ImgCritical.Name = "ImgCritical";
			this.ImgCritical.Size = new System.Drawing.Size(76, 73);
			this.ImgCritical.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal;
			this.ImgCritical.Visible = false;
			// 
			// ShortcutCaption1
			// 
			this.Shortcu.Text1.AllowDrop = true;
			this.Shortcu.Text1.Location = new System.Drawing.Point(0, 0);
			this.Shortcu.Text1.Name = "ShortcutCaption1";
			//
			this.Shortcu.Text1.Size = new System.Drawing.Size(367, 135);
			this.Shortcu.Text1.TabIndex = 13;
			// 
			// frmSysError
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(363, 134);
			this.Controls.Add(this.btnMore);
			this.Controls.Add(this.cmdCancel);
			this.Controls.Add(this.cmdOk);
			this.Controls.Add(this.cmdRetry);
			this.Controls.Add(this.txtLineNo);
			this.Controls.Add(this.Label1);
			this.Controls.Add(this.txtModule);
			this.Controls.Add(this.lblMod);
			this.Controls.Add(this.lblReason);
			this.Controls.Add(this.lblError);
			this.Controls.Add(this.lblRes);
			this.Controls.Add(this.txtSolution);
			this.Controls.Add(this.lblSolution);
			this.Controls.Add(this.ImgQuestion);
			this.Controls.Add(this.ImgExclamation);
			this.Controls.Add(this.ImgInformation);
			this.Controls.Add(this.ImgCritical);
			this.Controls.Add(this.Shortcu.Text1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			//this.Icon = (System.Drawing.Icon) resources.GetObject("frmSysError.Icon");
			this.Location = new System.Drawing.Point(491, 353);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmSysError";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.ShowInTaskbar = false;
			this.Text = "Xtreme Innova";
			// this.Activated += new System.EventHandler(this.frmSysError_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
			//((System.ComponentModel.ISupportInitialize) this.Shortcu.Text1).EndInit();
			this.ResumeLayout(false);
		}
		#endregion
	}
}//ENDSHERE
