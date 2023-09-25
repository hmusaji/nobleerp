
namespace Xtreme
{
	partial class frmSysIconsForm
	{

		#region "Upgrade Support "
		private static frmSysIconsForm m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmSysIconsForm DefInstance
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
		public static frmSysIconsForm CreateInstance()
		{
			frmSysIconsForm theInstance = new frmSysIconsForm();
			return theInstance;
		}
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "imlSystemIcons"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public System.Windows.Forms.ImageList imlSystemIcons;
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSysIconsForm));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this.imlSystemIcons = new System.Windows.Forms.ImageList();
			this.SuspendLayout();
			// 
			// imlSystemIcons
			// 
			this.imlSystemIcons.ImageSize = new System.Drawing.Size(16, 16);
			// this.imlSystemIcons.ImageStream = (System.Windows.Forms.ImageListStreamer) resources.GetObject("imlSystemIcons.ImageStream");
			this.imlSystemIcons.TransparentColor = System.Drawing.Color.Silver;
			//this.imlSystemIcons.Images.SetKeyName(0, "imgOk");
			//this.imlSystemIcons.Images.SetKeyName(1, "imgCancel");
			//this.imlSystemIcons.Images.SetKeyName(2, "imgChecked");
			//this.imlSystemIcons.Images.SetKeyName(3, "imgUnchecked");
			//this.imlSystemIcons.Images.SetKeyName(4, "imgMoveDown");
			//this.imlSystemIcons.Images.SetKeyName(5, "imgSelectAll");
			//this.imlSystemIcons.Images.SetKeyName(6, "imgSelectNone");
			//this.imlSystemIcons.Images.SetKeyName(7, "imgMoveUp");
			//this.imlSystemIcons.Images.SetKeyName(8, "imgCut");
			//this.imlSystemIcons.Images.SetKeyName(9, "imgCopy");
			//this.imlSystemIcons.Images.SetKeyName(10, "imgPaste");
			//this.imlSystemIcons.Images.SetKeyName(11, "imgFind");
			//this.imlSystemIcons.Images.SetKeyName(12, "imgExit");
			//this.imlSystemIcons.Images.SetKeyName(13, "imgChangePassward");
			//this.imlSystemIcons.Images.SetKeyName(14, "imgHelpIndex");
			//this.imlSystemIcons.Images.SetKeyName(15, "imgNewVoucherType");
			//this.imlSystemIcons.Images.SetKeyName(16, "imgAccountVouchers");
			//this.imlSystemIcons.Images.SetKeyName(17, "imgPreferences");
			//this.imlSystemIcons.Images.SetKeyName(18, "InventoryVouchers");
			//this.imlSystemIcons.Images.SetKeyName(19, "imgUserInformation");
			//this.imlSystemIcons.Images.SetKeyName(20, "imgHelpContents");
			//this.imlSystemIcons.Images.SetKeyName(21, "imgSortup");
			//this.imlSystemIcons.Images.SetKeyName(22, "imgSortdown");
			//this.imlSystemIcons.Images.SetKeyName(23, "imgFindIcon");
			//this.imlSystemIcons.Images.SetKeyName(24, "imgNextNumber2");
			//this.imlSystemIcons.Images.SetKeyName(25, "imgZoom");
			//this.imlSystemIcons.Images.SetKeyName(26, "imgAdditionalLedgerDetails");
			//this.imlSystemIcons.Images.SetKeyName(27, "imgHand");
			//this.imlSystemIcons.Images.SetKeyName(28, "imgNextNumber");
			// 
			// frmSysIconsForm
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			this.ClientSize = new System.Drawing.Size(293, 140);
			this.Location = new System.Drawing.Point(210, 352);
			this.MaximizeBox = true;
			this.MinimizeBox = true;
			this.Name = "frmSysIconsForm";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Text = "Icons Form";
			// this.Activated += new System.EventHandler(this.frmSysIconsForm_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
			this.ResumeLayout(false);
		}
		#endregion
	}
}//ENDSHERE
