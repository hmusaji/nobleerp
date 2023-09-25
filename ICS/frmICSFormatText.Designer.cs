
namespace Xtreme
{
	partial class frmICSFormatText
	{

		#region "Upgrade Support "
		private static frmICSFormatText m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmICSFormatText DefInstance
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
		public static frmICSFormatText CreateInstance()
		{
			frmICSFormatText theInstance = new frmICSFormatText();
			
			return theInstance;
		}
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "cmdUnderline", "cmdColor", "cmdOkCancel", "cmdBold", "cmdItalic", "rtbProdDesc", "Label1"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public System.Windows.Forms.Button cmdUnderline;
		public System.Windows.Forms.Button cmdColor;
		public UCOkCancel cmdOkCancel;
		public System.Windows.Forms.Button cmdBold;
		public System.Windows.Forms.Button cmdItalic;
		public System.Windows.Forms.RichTextBox rtbProdDesc;
		public System.Windows.Forms.Label Label1;
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmICSFormatText));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this.cmdUnderline = new System.Windows.Forms.Button();
			this.cmdColor = new System.Windows.Forms.Button();
			this.cmdOkCancel = new UCOkCancel();
			this.cmdBold = new System.Windows.Forms.Button();
			this.cmdItalic = new System.Windows.Forms.Button();
			this.rtbProdDesc = new System.Windows.Forms.RichTextBox();
			this.Label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// cmdUnderline
			// 
			this.cmdUnderline.AllowDrop = true;
			this.cmdUnderline.BackColor = System.Drawing.SystemColors.Control;
			this.cmdUnderline.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdUnderline.Location = new System.Drawing.Point(160, 348);
			this.cmdUnderline.Name = "cmdUnderline";
			this.cmdUnderline.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdUnderline.Size = new System.Drawing.Size(79, 29);
			this.cmdUnderline.TabIndex = 6;
			this.cmdUnderline.Text = "&UnderLine";
			this.cmdUnderline.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.cmdUnderline.UseVisualStyleBackColor = false;
			// this.cmdUnderline.Click += new System.EventHandler(this.cmdUnderline_Click);
			// 
			// cmdColor
			// 
			this.cmdColor.AllowDrop = true;
			this.cmdColor.BackColor = System.Drawing.SystemColors.Control;
			this.cmdColor.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdColor.Location = new System.Drawing.Point(238, 348);
			this.cmdColor.Name = "cmdColor";
			this.cmdColor.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdColor.Size = new System.Drawing.Size(79, 29);
			this.cmdColor.TabIndex = 5;
			this.cmdColor.Text = "&Color";
			this.cmdColor.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.cmdColor.UseVisualStyleBackColor = false;
			// this.cmdColor.Click += new System.EventHandler(this.cmdColor_Click);
			// 
			// cmdOkCancel
			// 
			this.cmdOkCancel.AllowDrop = true;
			this.cmdOkCancel.DisplayButton = 0;
			this.cmdOkCancel.Location = new System.Drawing.Point(316, 348);
			this.cmdOkCancel.Name = "cmdOkCancel";
			this.cmdOkCancel.OkCaption = "&Ok";
			this.cmdOkCancel.Size = new System.Drawing.Size(205, 29);
			this.cmdOkCancel.TabIndex = 4;
			this.cmdOkCancel.CancelClick += new UCOkCancel.CancelClickHandler(this.cmdOkCancel_CancelClick);
			this.cmdOkCancel.OKClick += new UCOkCancel.OKClickHandler(this.cmdOkCancel_OKClick);
			// 
			// cmdBold
			// 
			this.cmdBold.AllowDrop = true;
			this.cmdBold.BackColor = System.Drawing.SystemColors.Control;
			this.cmdBold.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdBold.Location = new System.Drawing.Point(2, 348);
			this.cmdBold.Name = "cmdBold";
			this.cmdBold.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdBold.Size = new System.Drawing.Size(81, 29);
			this.cmdBold.TabIndex = 2;
			this.cmdBold.Text = "&Bold";
			this.cmdBold.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.cmdBold.UseVisualStyleBackColor = false;
			// this.cmdBold.Click += new System.EventHandler(this.cmdBold_Click);
			// 
			// cmdItalic
			// 
			this.cmdItalic.AllowDrop = true;
			this.cmdItalic.BackColor = System.Drawing.SystemColors.Control;
			this.cmdItalic.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdItalic.Location = new System.Drawing.Point(82, 348);
			this.cmdItalic.Name = "cmdItalic";
			this.cmdItalic.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdItalic.Size = new System.Drawing.Size(79, 29);
			this.cmdItalic.TabIndex = 1;
			this.cmdItalic.Text = "&Italic";
			this.cmdItalic.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.cmdItalic.UseVisualStyleBackColor = false;
			// this.cmdItalic.Click += new System.EventHandler(this.cmdItalic_Click);
			// 
			// rtbProdDesc
			// 
			this.rtbProdDesc.AllowDrop = true;
			this.rtbProdDesc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.rtbProdDesc.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.rtbProdDesc.Location = new System.Drawing.Point(0, 32);
			this.rtbProdDesc.Name = "rtbProdDesc";
			this.rtbProdDesc.Rtf = resources.GetString("rtbProdDesc.TextRTF");
			this.rtbProdDesc.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
			this.rtbProdDesc.Size = new System.Drawing.Size(523, 309);
			this.rtbProdDesc.TabIndex = 0;
			// this.this.rtbProdDesc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rtbProdDesc_KeyDown);
			// 
			// Label1
			// 
			this.Label1.AllowDrop = true;
			this.Label1.BackColor = System.Drawing.SystemColors.Control;
			this.Label1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Label1.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Label1.Location = new System.Drawing.Point(4, 6);
			this.Label1.Name = "Label1";
			this.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label1.Size = new System.Drawing.Size(133, 23);
			this.Label1.TabIndex = 3;
			this.Label1.Text = "Enter Product Description: ";
			// 
			// frmICSFormatText
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Control;
			this.ClientSize = new System.Drawing.Size(526, 380);
			this.Controls.Add(this.cmdUnderline);
			this.Controls.Add(this.cmdColor);
			this.Controls.Add(this.cmdOkCancel);
			this.Controls.Add(this.cmdBold);
			this.Controls.Add(this.cmdItalic);
			this.Controls.Add(this.rtbProdDesc);
			this.Controls.Add(this.Label1);
			//this.Icon = (System.Drawing.Icon) resources.GetObject("frmICSFormatText.Icon");
			this.Location = new System.Drawing.Point(100, 169);
			this.MaximizeBox = false;
			this.MinimizeBox = true;
			this.Name = "frmICSFormatText";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Text = "Formatted Product Description";
			// this.Activated += new System.EventHandler(this.frmICSFormatText_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
			// this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
			this.ResumeLayout(false);
		}
		#endregion
	}
}