
namespace Xtreme
{
	partial class frmICSItemPictureDisplay
	{

		#region "Upgrade Support "
		private static frmICSItemPictureDisplay m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmICSItemPictureDisplay DefInstance
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
		public static frmICSItemPictureDisplay CreateInstance()
		{
			frmICSItemPictureDisplay theInstance = new frmICSItemPictureDisplay();
			
			return theInstance;
		}
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "Timer1", "ImgItem"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public System.Windows.Forms.Timer Timer1;
		public System.Windows.Forms.PictureBox ImgItem;
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmICSItemPictureDisplay));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this.Timer1 = new System.Windows.Forms.Timer(components);
			this.ImgItem = new System.Windows.Forms.PictureBox();
			this.SuspendLayout();
			// 
			// Timer1
			// 
			this.Timer1.Enabled = true;
			this.Timer1.Interval = 1;
			// 
			// ImgItem
			// 
			this.ImgItem.AllowDrop = true;
			this.ImgItem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.ImgItem.Enabled = true;
			this.ImgItem.Location = new System.Drawing.Point(0, 0);
			this.ImgItem.Name = "ImgItem";
			this.ImgItem.Size = new System.Drawing.Size(252, 233);
			this.ImgItem.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.ImgItem.Visible = true;
			this.ImgItem.DoubleClick += new System.EventHandler(this.ImgItem_DoubleClick);
			// 
			// frmICSItemPictureDisplay
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Window;
			this.ClientSize = new System.Drawing.Size(449, 283);
			this.Controls.Add(this.ImgItem);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
			//this.Icon = (System.Drawing.Icon) resources.GetObject("frmICSItemPictureDisplay.Icon");
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(179, 336);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmICSItemPictureDisplay";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.ShowInTaskbar = false;
			this.Tag = "False";
			this.Text = "Item Picture Profile";
			// this.Activated += new System.EventHandler(this.Form_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
			// this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
			//this.Resize += new System.EventHandler(this.Form_Resize);
			this.ResumeLayout(false);
		}
		#endregion
	}
}//ENDSHERE
