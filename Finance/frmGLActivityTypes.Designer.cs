
namespace Xtreme
{
	partial class frmGLActivityTypes
	{

		#region "Upgrade Support "
		private static frmGLActivityTypes m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmGLActivityTypes DefInstance
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
		public static frmGLActivityTypes CreateInstance()
		{
			frmGLActivityTypes theInstance = new frmGLActivityTypes();
			
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
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "txtComment", "txtTypeNo", "lblUnitNo", "lblLUnitName", "lblAUnitName", "txtLTypeName", "txtATypeName", "lblComments"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public System.Windows.Forms.TextBox txtComment;
		public System.Windows.Forms.TextBox txtTypeNo;
		public System.Windows.Forms.Label lblUnitNo;
		public System.Windows.Forms.Label lblLUnitName;
		public System.Windows.Forms.Label lblAUnitName;
		public System.Windows.Forms.TextBox txtLTypeName;
		public System.Windows.Forms.TextBox txtATypeName;
		public System.Windows.Forms.Label lblComments;
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGLActivityTypes));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this.txtComment = new System.Windows.Forms.TextBox();
			this.txtTypeNo = new System.Windows.Forms.TextBox();
			this.lblUnitNo = new System.Windows.Forms.Label();
			this.lblLUnitName = new System.Windows.Forms.Label();
			this.lblAUnitName = new System.Windows.Forms.Label();
			this.txtLTypeName = new System.Windows.Forms.TextBox();
			this.txtATypeName = new System.Windows.Forms.TextBox();
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
			this.txtComment.Location = new System.Drawing.Point(130, 88);
			this.txtComment.MaxLength = 100;
			this.txtComment.Multiline = true;
			this.txtComment.Name = "txtComment";
			this.txtComment.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtComment.Size = new System.Drawing.Size(295, 49);
			this.txtComment.TabIndex = 6;
			// 
			// txtTypeNo
			// 
			this.txtTypeNo.AllowDrop = true;
			this.txtTypeNo.BackColor = System.Drawing.Color.White;
			// this.txtTypeNo.bolNumericOnly = true;
			this.txtTypeNo.ForeColor = System.Drawing.Color.Black;
			this.txtTypeNo.Location = new System.Drawing.Point(130, 22);
			this.txtTypeNo.MaxLength = 4;
			// // = System.Windows.Forms.TextBox.DropDownTypes.ddtNextNumber;
			this.txtTypeNo.Name = "txtTypeNo";
			// this.txtTypeNo.ShowButton = true;
			this.txtTypeNo.Size = new System.Drawing.Size(101, 19);
			this.txtTypeNo.TabIndex = 0;
			this.txtTypeNo.Text = "";
			// this.//this.txtTypeNo.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(//this.txtTypeNo_DropButtonClick);
			// 
			// lblUnitNo
			// 
			this.lblUnitNo.AllowDrop = true;
			this.lblUnitNo.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblUnitNo.Text = "Unit Code";
			this.lblUnitNo.Location = new System.Drawing.Point(4, 26);
			// // this.lblUnitNo.mLabelId = 988;
			this.lblUnitNo.Name = "lblUnitNo";
			this.lblUnitNo.Size = new System.Drawing.Size(25, 14);
			this.lblUnitNo.TabIndex = 1;
			// 
			// lblLUnitName
			// 
			this.lblLUnitName.AllowDrop = true;
			this.lblLUnitName.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblLUnitName.Text = "Name (English)";
			this.lblLUnitName.Location = new System.Drawing.Point(4, 46);
			// // this.lblLUnitName.mLabelId = 1028;
			this.lblLUnitName.Name = "lblLUnitName";
			this.lblLUnitName.Size = new System.Drawing.Size(72, 14);
			this.lblLUnitName.TabIndex = 2;
			// 
			// lblAUnitName
			// 
			this.lblAUnitName.AllowDrop = true;
			this.lblAUnitName.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblAUnitName.Text = "Name (Arabic)";
			this.lblAUnitName.Location = new System.Drawing.Point(4, 68);
			// // this.lblAUnitName.mLabelId = 1029;
			this.lblAUnitName.Name = "lblAUnitName";
			this.lblAUnitName.Size = new System.Drawing.Size(70, 14);
			this.lblAUnitName.TabIndex = 3;
			// 
			// txtLTypeName
			// 
			this.txtLTypeName.AllowDrop = true;
			this.txtLTypeName.BackColor = System.Drawing.Color.White;
			this.txtLTypeName.ForeColor = System.Drawing.Color.Black;
			this.txtLTypeName.Location = new System.Drawing.Point(130, 44);
			this.txtLTypeName.MaxLength = 50;
			this.txtLTypeName.Name = "txtLTypeName";
			this.txtLTypeName.Size = new System.Drawing.Size(241, 19);
			this.txtLTypeName.TabIndex = 4;
			this.txtLTypeName.Tag = "Salesman Name in English";
			this.txtLTypeName.Text = "";
			// 
			// txtATypeName
			// 
			this.txtATypeName.AllowDrop = true;
			this.txtATypeName.BackColor = System.Drawing.Color.White;
			this.txtATypeName.ForeColor = System.Drawing.Color.Black;
			this.txtATypeName.Location = new System.Drawing.Point(130, 66);
			// // = true;
			this.txtATypeName.MaxLength = 50;
			this.txtATypeName.Name = "txtATypeName";
			this.txtATypeName.Size = new System.Drawing.Size(241, 19);
			this.txtATypeName.TabIndex = 5;
			this.txtATypeName.Text = "";
			// 
			// lblComments
			// 
			this.lblComments.AllowDrop = true;
			this.lblComments.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblComments.Text = "Comment";
			this.lblComments.Location = new System.Drawing.Point(4, 88);
			// // this.lblComments.mLabelId = 135;
			this.lblComments.Name = "lblComments";
			this.lblComments.Size = new System.Drawing.Size(44, 14);
			this.lblComments.TabIndex = 7;
			// 
			// frmGLActivityTypes
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.ClientSize = new System.Drawing.Size(453, 221);
			this.Controls.Add(this.txtComment);
			this.Controls.Add(this.txtTypeNo);
			this.Controls.Add(this.lblUnitNo);
			this.Controls.Add(this.lblLUnitName);
			this.Controls.Add(this.lblAUnitName);
			this.Controls.Add(this.txtLTypeName);
			this.Controls.Add(this.txtATypeName);
			this.Controls.Add(this.lblComments);
			this.Font = new System.Drawing.Font("Tahoma", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 178);
			this.Location = new System.Drawing.Point(326, 323);
			this.MaximizeBox = true;
			this.MinimizeBox = true;
			this.Name = "frmGLActivityTypes";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Project Types";
			this.ToolTipMain.SetToolTip(this.txtLTypeName, "Salesman Name in English");
			// this.Activated += new System.EventHandler(this.frmGLActivityTypes_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
			// this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
			this.ResumeLayout(false);
		}
		// 
		#endregion
	}
}//ENDSHERE
