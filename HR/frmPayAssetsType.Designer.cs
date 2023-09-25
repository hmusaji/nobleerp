
namespace Xtreme
{
	partial class frmPayAssetsType
	{

		#region "Upgrade Support "
		private static frmPayAssetsType m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmPayAssetsType DefInstance
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
		public static frmPayAssetsType CreateInstance()
		{
			frmPayAssetsType theInstance = new frmPayAssetsType();
			
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
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "txtComment", "txtAssetsNo", "lblGroupNo", "lblLGroupName", "txtLAssetTypeName", "lblAGroupName", "txtAAssetTypeName", "lblComments"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public System.Windows.Forms.TextBox txtComment;
		public System.Windows.Forms.TextBox txtAssetsNo;
		public System.Windows.Forms.Label lblGroupNo;
		public System.Windows.Forms.Label lblLGroupName;
		public System.Windows.Forms.TextBox txtLAssetTypeName;
		public System.Windows.Forms.Label lblAGroupName;
		public System.Windows.Forms.TextBox txtAAssetTypeName;
		public System.Windows.Forms.Label lblComments;
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPayAssetsType));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this.txtComment = new System.Windows.Forms.TextBox();
			this.txtAssetsNo = new System.Windows.Forms.TextBox();
			this.lblGroupNo = new System.Windows.Forms.Label();
			this.lblLGroupName = new System.Windows.Forms.Label();
			this.txtLAssetTypeName = new System.Windows.Forms.TextBox();
			this.lblAGroupName = new System.Windows.Forms.Label();
			this.txtAAssetTypeName = new System.Windows.Forms.TextBox();
			this.lblComments = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// txtComment
			// 
			this.txtComment.AcceptsReturn = true;
			this.txtComment.AllowDrop = true;
			this.txtComment.BackColor = System.Drawing.SystemColors.Window;
			this.txtComment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtComment.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtComment.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtComment.Location = new System.Drawing.Point(138, 124);
			this.txtComment.MaxLength = 100;
			this.txtComment.Multiline = true;
			this.txtComment.Name = "txtComment";
			this.txtComment.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtComment.Size = new System.Drawing.Size(343, 49);
			this.txtComment.TabIndex = 6;
			// 
			// txtAssetsNo
			// 
			this.txtAssetsNo.AllowDrop = true;
			this.txtAssetsNo.BackColor = System.Drawing.Color.White;
			// this.txtAssetsNo.bolNumericOnly = true;
			this.txtAssetsNo.ForeColor = System.Drawing.Color.Black;
			this.txtAssetsNo.Location = new System.Drawing.Point(138, 60);
			this.txtAssetsNo.MaxLength = 15;
			// this.txtAssetsNo.mDropDownType = System.Windows.Forms.TextBox.DropDownTypes.ddtNextNumber;
			this.txtAssetsNo.Name = "txtAssetsNo";
			// this.txtAssetsNo.ShowButton = true;
			this.txtAssetsNo.Size = new System.Drawing.Size(101, 19);
			this.txtAssetsNo.TabIndex = 0;
			this.txtAssetsNo.Text = "";
			// 
			// lblGroupNo
			// 
			this.lblGroupNo.AllowDrop = true;
			this.lblGroupNo.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblGroupNo.Text = "Asset Type Code";
			this.lblGroupNo.Location = new System.Drawing.Point(10, 62);
			// this.lblGroupNo.mLabelId = 2105;
			this.lblGroupNo.Name = "lblGroupNo";
			this.lblGroupNo.Size = new System.Drawing.Size(84, 14);
			this.lblGroupNo.TabIndex = 1;
			// 
			// lblLGroupName
			// 
			this.lblLGroupName.AllowDrop = true;
			this.lblLGroupName.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblLGroupName.Text = "Asset Name (English)";
			this.lblLGroupName.Location = new System.Drawing.Point(10, 84);
			// this.lblLGroupName.mLabelId = 2106;
			this.lblLGroupName.Name = "lblLGroupName";
			this.lblLGroupName.Size = new System.Drawing.Size(104, 14);
			this.lblLGroupName.TabIndex = 2;
			// 
			// txtLAssetTypeName
			// 
			this.txtLAssetTypeName.AllowDrop = true;
			this.txtLAssetTypeName.BackColor = System.Drawing.Color.White;
			this.txtLAssetTypeName.ForeColor = System.Drawing.Color.Black;
			this.txtLAssetTypeName.Location = new System.Drawing.Point(138, 81);
			this.txtLAssetTypeName.MaxLength = 50;
			this.txtLAssetTypeName.Name = "txtLAssetTypeName";
			this.txtLAssetTypeName.Size = new System.Drawing.Size(343, 19);
			this.txtLAssetTypeName.TabIndex = 3;
			this.txtLAssetTypeName.Text = "";
			// 
			// lblAGroupName
			// 
			this.lblAGroupName.AllowDrop = true;
			this.lblAGroupName.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblAGroupName.Text = "Asset Name (Arabic)";
			this.lblAGroupName.Location = new System.Drawing.Point(10, 105);
			// this.lblAGroupName.mLabelId = 2107;
			this.lblAGroupName.Name = "lblAGroupName";
			this.lblAGroupName.Size = new System.Drawing.Size(102, 14);
			this.lblAGroupName.TabIndex = 4;
			// 
			// txtAAssetTypeName
			// 
			this.txtAAssetTypeName.AllowDrop = true;
			this.txtAAssetTypeName.BackColor = System.Drawing.Color.White;
			this.txtAAssetTypeName.ForeColor = System.Drawing.Color.Black;
			this.txtAAssetTypeName.Location = new System.Drawing.Point(138, 102);
			// this.txtAAssetTypeName.mArabicEnabled = true;
			this.txtAAssetTypeName.MaxLength = 50;
			this.txtAAssetTypeName.Name = "txtAAssetTypeName";
			this.txtAAssetTypeName.Size = new System.Drawing.Size(343, 19);
			this.txtAAssetTypeName.TabIndex = 5;
			this.txtAAssetTypeName.Text = "";
			// 
			// lblComments
			// 
			this.lblComments.AllowDrop = true;
			this.lblComments.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblComments.Text = "Comment";
			this.lblComments.Location = new System.Drawing.Point(10, 124);
			// this.lblComments.mLabelId = 1851;
			this.lblComments.Name = "lblComments";
			this.lblComments.Size = new System.Drawing.Size(44, 14);
			this.lblComments.TabIndex = 7;
			// 
			// frmPayAssetsType
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.ClientSize = new System.Drawing.Size(509, 180);
			this.Controls.Add(this.txtComment);
			this.Controls.Add(this.txtAssetsNo);
			this.Controls.Add(this.lblGroupNo);
			this.Controls.Add(this.lblLGroupName);
			this.Controls.Add(this.txtLAssetTypeName);
			this.Controls.Add(this.lblAGroupName);
			this.Controls.Add(this.txtAAssetTypeName);
			this.Controls.Add(this.lblComments);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			//this.Icon = (System.Drawing.Icon) resources.GetObject("frmPayAssetsType.Icon");
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(134, 428);
			this.MaximizeBox = true;
			this.MinimizeBox = true;
			this.Name = "frmPayAssetsType";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Assets Type";
			// this.Activated += new System.EventHandler(this.frmPayAssetsType_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
			// this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
			this.ResumeLayout(false);
		}
		void ReLoadForm(bool addEvents)
		{
			//This form is an MDI child.
			//This code simulates the VB6 
			// functionality of automatically
			// loading and showing an MDI
			// child's parent.
			this.MdiParent = Xtreme.frmSysMain.DefInstance;
			Xtreme.frmSysMain.DefInstance.Show();
		}
		#endregion
	}
}