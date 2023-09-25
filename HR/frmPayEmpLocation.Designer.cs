
namespace Xtreme
{
	partial class frmPayEmpLocation
	{

		#region "Upgrade Support "
		private static frmPayEmpLocation m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmPayEmpLocation DefInstance
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
		public static frmPayEmpLocation CreateInstance()
		{
			frmPayEmpLocation theInstance = new frmPayEmpLocation();
			
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
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "txtComment", "txtLocationNo", "lblDesgNo", "lblLDesgName", "txtLLocationName", "lblAGroupName", "txtALocationName", "lblComments"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public System.Windows.Forms.TextBox txtComment;
		public System.Windows.Forms.TextBox txtLocationNo;
		public System.Windows.Forms.Label lblDesgNo;
		public System.Windows.Forms.Label lblLDesgName;
		public System.Windows.Forms.TextBox txtLLocationName;
		public System.Windows.Forms.Label lblAGroupName;
		public System.Windows.Forms.TextBox txtALocationName;
		public System.Windows.Forms.Label lblComments;
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPayEmpLocation));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this.txtComment = new System.Windows.Forms.TextBox();
			this.txtLocationNo = new System.Windows.Forms.TextBox();
			this.lblDesgNo = new System.Windows.Forms.Label();
			this.lblLDesgName = new System.Windows.Forms.Label();
			this.txtLLocationName = new System.Windows.Forms.TextBox();
			this.lblAGroupName = new System.Windows.Forms.Label();
			this.txtALocationName = new System.Windows.Forms.TextBox();
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
			this.txtComment.Location = new System.Drawing.Point(142, 121);
			this.txtComment.MaxLength = 100;
			this.txtComment.Multiline = true;
			this.txtComment.Name = "txtComment";
			this.txtComment.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtComment.Size = new System.Drawing.Size(294, 49);
			this.txtComment.TabIndex = 0;
			// 
			// txtLocationNo
			// 
			this.txtLocationNo.AllowDrop = true;
			this.txtLocationNo.BackColor = System.Drawing.Color.White;
			// this.txtLocationNo.bolNumericOnly = true;
			this.txtLocationNo.ForeColor = System.Drawing.Color.Black;
			this.txtLocationNo.Location = new System.Drawing.Point(142, 57);
			this.txtLocationNo.MaxLength = 15;
			// this.txtLocationNo.mDropDownType = System.Windows.Forms.TextBox.DropDownTypes.ddtNextNumber;
			this.txtLocationNo.Name = "txtLocationNo";
			// this.txtLocationNo.ShowButton = true;
			this.txtLocationNo.Size = new System.Drawing.Size(101, 19);
			this.txtLocationNo.TabIndex = 1;
			this.txtLocationNo.Text = "";
			// 
			// lblDesgNo
			// 
			this.lblDesgNo.AllowDrop = true;
			this.lblDesgNo.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblDesgNo.Text = "Location No";
			this.lblDesgNo.Location = new System.Drawing.Point(6, 59);
			// // this.lblDesgNo.mLabelId = 2233;
			this.lblDesgNo.Name = "lblDesgNo";
			this.lblDesgNo.Size = new System.Drawing.Size(57, 14);
			this.lblDesgNo.TabIndex = 2;
			// 
			// lblLDesgName
			// 
			this.lblLDesgName.AllowDrop = true;
			this.lblLDesgName.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblLDesgName.Text = "Location Name(Eng)";
			this.lblLDesgName.Location = new System.Drawing.Point(6, 81);
			// // this.lblLDesgName.mLabelId = 2234;
			this.lblLDesgName.Name = "lblLDesgName";
			this.lblLDesgName.Size = new System.Drawing.Size(97, 14);
			this.lblLDesgName.TabIndex = 3;
			// 
			// txtLLocationName
			// 
			this.txtLLocationName.AllowDrop = true;
			this.txtLLocationName.BackColor = System.Drawing.Color.White;
			this.txtLLocationName.ForeColor = System.Drawing.Color.Black;
			this.txtLLocationName.Location = new System.Drawing.Point(142, 78);
			this.txtLLocationName.MaxLength = 50;
			this.txtLLocationName.Name = "txtLLocationName";
			this.txtLLocationName.Size = new System.Drawing.Size(294, 19);
			this.txtLLocationName.TabIndex = 4;
			this.txtLLocationName.Text = "";
			// 
			// lblAGroupName
			// 
			this.lblAGroupName.AllowDrop = true;
			this.lblAGroupName.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblAGroupName.Text = "Location Name(Arb)";
			this.lblAGroupName.Location = new System.Drawing.Point(6, 102);
			// // this.lblAGroupName.mLabelId = 2235;
			this.lblAGroupName.Name = "lblAGroupName";
			this.lblAGroupName.Size = new System.Drawing.Size(97, 14);
			this.lblAGroupName.TabIndex = 5;
			// 
			// txtALocationName
			// 
			this.txtALocationName.AllowDrop = true;
			this.txtALocationName.BackColor = System.Drawing.Color.White;
			this.txtALocationName.ForeColor = System.Drawing.Color.Black;
			this.txtALocationName.Location = new System.Drawing.Point(142, 99);
			// this.txtALocationName.mArabicEnabled = true;
			this.txtALocationName.MaxLength = 50;
			this.txtALocationName.Name = "txtALocationName";
			this.txtALocationName.Size = new System.Drawing.Size(294, 19);
			this.txtALocationName.TabIndex = 6;
			this.txtALocationName.Text = "";
			// 
			// lblComments
			// 
			this.lblComments.AllowDrop = true;
			this.lblComments.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblComments.Text = "Comment";
			this.lblComments.Location = new System.Drawing.Point(6, 121);
			// // this.lblComments.mLabelId = 1851;
			this.lblComments.Name = "lblComments";
			this.lblComments.Size = new System.Drawing.Size(50, 14);
			this.lblComments.TabIndex = 7;
			// 
			// frmPayEmpLocation
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.ClientSize = new System.Drawing.Size(450, 188);
			this.Controls.Add(this.txtComment);
			this.Controls.Add(this.txtLocationNo);
			this.Controls.Add(this.lblDesgNo);
			this.Controls.Add(this.lblLDesgName);
			this.Controls.Add(this.txtLLocationName);
			this.Controls.Add(this.lblAGroupName);
			this.Controls.Add(this.txtALocationName);
			this.Controls.Add(this.lblComments);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			//this.Icon = (System.Drawing.Icon) resources.GetObject("frmPayEmpLocation.Icon");
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(122, 127);
			this.MaximizeBox = true;
			this.MinimizeBox = true;
			this.Name = "frmPayEmpLocation";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Employee Location";
			// this.Activated += new System.EventHandler(this.frmPayEmpLocation_Activated);
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
}//ENDSHERE
