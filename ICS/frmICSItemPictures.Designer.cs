
namespace Xtreme
{
	partial class frmICSItemPictures
	{

		#region "Upgrade Support "
		private static frmICSItemPictures m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmICSItemPictures DefInstance
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
		public static frmICSItemPictures CreateInstance()
		{
			frmICSItemPictures theInstance = new frmICSItemPictures();
			
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
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "Column_0_grdVoucherDetails", "Column_1_grdVoucherDetails", "grdVoucherDetails", "_btnFormToolBar_0", "_btnFormToolBar_1", "picFormToolbar", "ImgItem", "btnFormToolBar"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_0_grdVoucherDetails;
		public C1.Win.C1TrueDBGrid.C1DataColumn Column_1_grdVoucherDetails;
		public C1.Win.C1TrueDBGrid.C1TrueDBGrid grdVoucherDetails;
		private System.Windows.Forms.Button _btnFormToolBar_0;
		private System.Windows.Forms.Button _btnFormToolBar_1;
		public System.Windows.Forms.PictureBox picFormToolbar;
		public System.Windows.Forms.PictureBox ImgItem;
		public System.Windows.Forms.Button[] btnFormToolBar = new System.Windows.Forms.Button[2];
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmICSItemPictures));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this.grdVoucherDetails = new C1.Win.C1TrueDBGrid.C1TrueDBGrid();
			this.Column_0_grdVoucherDetails = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.Column_1_grdVoucherDetails = new C1.Win.C1TrueDBGrid.C1DataColumn();
			this.picFormToolbar = new System.Windows.Forms.PictureBox();
			this._btnFormToolBar_0 = new System.Windows.Forms.Button();
			this._btnFormToolBar_1 = new System.Windows.Forms.Button();
			this.ImgItem = new System.Windows.Forms.PictureBox();
			// //((System.ComponentModel.ISupportInitialize) this._btnFormToolBar_0).BeginInit();
			// //((System.ComponentModel.ISupportInitialize) this._btnFormToolBar_1).BeginInit();
			//this.grdVoucherDetails.SuspendLayout();
			//this.picFormToolbar.SuspendLayout();
			this.SuspendLayout();
			// 
			// grdVoucherDetails
			// 
			//this.grdVoucherDetails.AllowDrop = true;
			this.grdVoucherDetails.BackColor = System.Drawing.Color.FromArgb(236, 233, 216);
			this.grdVoucherDetails.CellTipsWidth = 0;
			this.grdVoucherDetails.Location = new System.Drawing.Point(0, 60);
			this.grdVoucherDetails.Name = "grdVoucherDetails";
			this.grdVoucherDetails.RowDivider.Color = System.Drawing.Color.FromArgb(236, 233, 216);
			this.grdVoucherDetails.Size = new System.Drawing.Size(319, 397);
			this.grdVoucherDetails.TabIndex = 0;
			this.grdVoucherDetails.Columns.Add(this.Column_0_grdVoucherDetails);
			this.grdVoucherDetails.Columns.Add(this.Column_1_grdVoucherDetails);
			//this.grdVoucherDetails.HeadClick += new C1.Win.C1TrueDBGrid.ColEventHandler(this.grdVoucherDetails_HeadClick);
			//this.grdVoucherDetails.KeyUp += new System.Windows.Forms.KeyEventHandler(this.grdVoucherDetails_KeyUp);
			//this.grdVoucherDetails.RowColChange += new C1.Win.C1TrueDBGrid.RowColChangeEventHandler(this.grdVoucherDetails_RowColChange);
			// 
			// Column_0_grdVoucherDetails
			// 
			this.Column_0_grdVoucherDetails.DataField = "";
			this.Column_0_grdVoucherDetails.ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.Normal;
			// 
			// Column_1_grdVoucherDetails
			// 
			this.Column_1_grdVoucherDetails.DataField = "";
			this.Column_1_grdVoucherDetails.ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.Normal;
			// 
			// picFormToolbar
			// 
			//this.picFormToolbar.AllowDrop = true;
			this.picFormToolbar.BackColor = System.Drawing.SystemColors.Control;
			//this.picFormToolbar.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.picFormToolbar.CausesValidation = true;
			this.picFormToolbar.Controls.Add(this._btnFormToolBar_0);
			this.picFormToolbar.Controls.Add(this._btnFormToolBar_1);
			this.picFormToolbar.Dock = System.Windows.Forms.DockStyle.Top;
			this.picFormToolbar.Enabled = true;
			this.picFormToolbar.Location = new System.Drawing.Point(0, 0);
			this.picFormToolbar.Name = "picFormToolbar";
			this.picFormToolbar.Size = new System.Drawing.Size(757, 38);
			this.picFormToolbar.TabIndex = 1;
			this.picFormToolbar.TabStop = false;
			this.picFormToolbar.Visible = true;
			// 
			// _btnFormToolBar_0
			// 
			//this._btnFormToolBar_0.AllowDrop = true;
			this._btnFormToolBar_0.Location = new System.Drawing.Point(2, 2);
			this._btnFormToolBar_0.Name = "_btnFormToolBar_0";
			//
			this._btnFormToolBar_0.Size = new System.Drawing.Size(55, 34);
			this._btnFormToolBar_0.TabIndex = 2;
			this._btnFormToolBar_0.TabStop = false;
			this._btnFormToolBar_0.Tag = "Q";
			//// this._btnFormToolBar_0.ClickEvent += new System.EventHandler(this.btnFormToolBar_ClickEvent);
			// 
			// _btnFormToolBar_1
			// 
			//this._btnFormToolBar_1.AllowDrop = true;
			this._btnFormToolBar_1.Location = new System.Drawing.Point(63, 2);
			this._btnFormToolBar_1.Name = "_btnFormToolBar_1";
			//
			this._btnFormToolBar_1.Size = new System.Drawing.Size(55, 34);
			this._btnFormToolBar_1.TabIndex = 3;
			this._btnFormToolBar_1.TabStop = false;
			this._btnFormToolBar_1.Tag = "Exit";
			//// this._btnFormToolBar_1.ClickEvent += new System.EventHandler(this.btnFormToolBar_ClickEvent);
			// 
			// ImgItem
			// 
			//this.ImgItem.AllowDrop = true;
			//this.ImgItem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.ImgItem.Enabled = true;
			this.ImgItem.Location = new System.Drawing.Point(327, 60);
			this.ImgItem.Name = "ImgItem";
			this.ImgItem.Size = new System.Drawing.Size(416, 397);
			this.ImgItem.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.ImgItem.Visible = true;
			//this.ImgItem.DoubleClick += new System.EventHandler(this.ImgItem_DoubleClick);
			// 
			// frmICSItemPictures
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.FromArgb(250, 244, 231);
			this.ClientSize = new System.Drawing.Size(757, 473);
			this.Controls.Add(this.grdVoucherDetails);
			this.Controls.Add(this.picFormToolbar);
			this.Controls.Add(this.ImgItem);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			//this.Icon = (System.Drawing.Icon) resources.GetObject("frmICSItemPictures.Icon");
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(95, 241);
			this.MaximizeBox = false;
			this.MinimizeBox = true;
			this.Name = "frmICSItemPictures";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Tag = "False";
			this.Text = "Item Picture Profile";
			// this.Activated += new System.EventHandler(this.frmICSItemPictures_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
			// this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
			//((System.ComponentModel.ISupportInitialize) this._btnFormToolBar_0).EndInit();
			//((System.ComponentModel.ISupportInitialize) this._btnFormToolBar_1).EndInit();
			this.grdVoucherDetails.ResumeLayout(false);
			this.picFormToolbar.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		// 
		void InitializebtnFormToolBar()
		{
			this.btnFormToolBar = new System.Windows.Forms.Button[2];
			this.btnFormToolBar[0] = _btnFormToolBar_0;
			this.btnFormToolBar[1] = _btnFormToolBar_1;
		}
		#endregion
	}
}//ENDSHERE
