
namespace Xtreme
{
	partial class frmICSPOSCounter
	{

		#region "Upgrade Support "
		private static frmICSPOSCounter m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmICSPOSCounter DefInstance
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
		public static frmICSPOSCounter CreateInstance()
		{
			frmICSPOSCounter theInstance = new frmICSPOSCounter();
			
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
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "chkCD", "chkPoleDisplay", "chkFreeze", "txtCounterNo", "lblGroupNo", "lblLGroupName", "txtLCounterName", "lblParentGroup", "lblAGroupName", "txtACounterName", "lblComments", "txtLocationNo", "txtLocationName", "txtComputerName", "lblPolePort", "txtPortNo", "txtCDPortNo", "System.Windows.Forms.Label1"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public System.Windows.Forms.CheckBox chkCD;
		public System.Windows.Forms.CheckBox chkPoleDisplay;
		public System.Windows.Forms.CheckBox chkFreeze;
		public System.Windows.Forms.TextBox txtCounterNo;
		public System.Windows.Forms.Label lblGroupNo;
		public System.Windows.Forms.Label lblLGroupName;
		public System.Windows.Forms.TextBox txtLCounterName;
		public System.Windows.Forms.Label lblParentGroup;
		public System.Windows.Forms.Label lblAGroupName;
		public System.Windows.Forms.TextBox txtACounterName;
		public System.Windows.Forms.Label lblComments;
		public System.Windows.Forms.TextBox txtLocationNo;
		public System.Windows.Forms.TextBox txtLocationName;
		public System.Windows.Forms.TextBox txtComputerName;
		public System.Windows.Forms.Label lblPolePort;
		public System.Windows.Forms.TextBox txtPortNo;
		public System.Windows.Forms.TextBox txtCDPortNo;
		public System.Windows.Forms.Label Label1;
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmICSPOSCounter));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this.chkCD = new System.Windows.Forms.CheckBox();
			this.chkPoleDisplay = new System.Windows.Forms.CheckBox();
			this.chkFreeze = new System.Windows.Forms.CheckBox();
			this.txtCounterNo = new System.Windows.Forms.TextBox();
			this.lblGroupNo = new System.Windows.Forms.Label();
			this.lblLGroupName = new System.Windows.Forms.Label();
			this.txtLCounterName = new System.Windows.Forms.TextBox();
			this.lblParentGroup = new System.Windows.Forms.Label();
			this.lblAGroupName = new System.Windows.Forms.Label();
			this.txtACounterName = new System.Windows.Forms.TextBox();
			this.lblComments = new System.Windows.Forms.Label();
			this.txtLocationNo = new System.Windows.Forms.TextBox();
			this.txtLocationName = new System.Windows.Forms.TextBox();
			this.txtComputerName = new System.Windows.Forms.TextBox();
			this.lblPolePort = new System.Windows.Forms.Label();
			this.txtPortNo = new System.Windows.Forms.TextBox();
			this.txtCDPortNo = new System.Windows.Forms.TextBox();
			this.Label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// chkCD
			// 
			this.chkCD.AllowDrop = true;
			this.chkCD.Appearance = System.Windows.Forms.Appearance.Normal;
			this.chkCD.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.chkCD.CausesValidation = true;
			this.chkCD.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkCD.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this.chkCD.Enabled = true;
			this.chkCD.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 178);
			this.chkCD.ForeColor = System.Drawing.SystemColors.ControlText;
			this.chkCD.Location = new System.Drawing.Point(10, 148);
			this.chkCD.Name = "chkCD";
			this.chkCD.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.chkCD.Size = new System.Drawing.Size(109, 13);
			this.chkCD.TabIndex = 17;
			this.chkCD.TabStop = true;
			this.chkCD.Text = "Use Cash Drawer";
			this.chkCD.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkCD.Visible = true;
			// 
			// chkPoleDisplay
			// 
			this.chkPoleDisplay.AllowDrop = true;
			this.chkPoleDisplay.Appearance = System.Windows.Forms.Appearance.Normal;
			this.chkPoleDisplay.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.chkPoleDisplay.CausesValidation = true;
			this.chkPoleDisplay.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkPoleDisplay.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this.chkPoleDisplay.Enabled = true;
			this.chkPoleDisplay.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 178);
			this.chkPoleDisplay.ForeColor = System.Drawing.SystemColors.ControlText;
			this.chkPoleDisplay.Location = new System.Drawing.Point(10, 126);
			this.chkPoleDisplay.Name = "chkPoleDisplay";
			this.chkPoleDisplay.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.chkPoleDisplay.Size = new System.Drawing.Size(109, 13);
			this.chkPoleDisplay.TabIndex = 12;
			this.chkPoleDisplay.TabStop = true;
			this.chkPoleDisplay.Text = "Use Pole Display";
			this.chkPoleDisplay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkPoleDisplay.Visible = true;
			// 
			// chkFreeze
			// 
			this.chkFreeze.AllowDrop = true;
			this.chkFreeze.Appearance = System.Windows.Forms.Appearance.Normal;
			this.chkFreeze.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.chkFreeze.CausesValidation = true;
			this.chkFreeze.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkFreeze.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this.chkFreeze.Enabled = true;
			this.chkFreeze.ForeColor = System.Drawing.SystemColors.ControlText;
			this.chkFreeze.Location = new System.Drawing.Point(340, 15);
			this.chkFreeze.Name = "chkFreeze";
			this.chkFreeze.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.chkFreeze.Size = new System.Drawing.Size(59, 19);
			this.chkFreeze.TabIndex = 11;
			this.chkFreeze.TabStop = true;
			this.chkFreeze.Text = "Freeze";
			this.chkFreeze.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkFreeze.Visible = true;
			// 
			// txtCounterNo
			// 
			this.txtCounterNo.AllowDrop = true;
			this.txtCounterNo.BackColor = System.Drawing.Color.White;
			this.txtCounterNo.ForeColor = System.Drawing.Color.Black;
			this.txtCounterNo.Location = new System.Drawing.Point(127, 15);
			this.txtCounterNo.MaxLength = 15;
			// this.txtCounterNo.mDropDownType = System.Windows.Forms.TextBox.DropDownTypes.ddtNextNumber;
			this.txtCounterNo.Name = "txtCounterNo";
			// this.txtCounterNo.ShowButton = true;
			this.txtCounterNo.Size = new System.Drawing.Size(101, 19);
			this.txtCounterNo.TabIndex = 1;
			this.txtCounterNo.Text = "";
			// 
			// lblGroupNo
			// 
			this.lblGroupNo.AllowDrop = true;
			this.lblGroupNo.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblGroupNo.Text = "Counter Code";
			this.lblGroupNo.ForeColor = System.Drawing.Color.Black;
			this.lblGroupNo.Location = new System.Drawing.Point(9, 17);
			this.lblGroupNo.Name = "lblGroupNo";
			this.lblGroupNo.Size = new System.Drawing.Size(66, 14);
			this.lblGroupNo.TabIndex = 0;
			// 
			// lblLGroupName
			// 
			this.lblLGroupName.AllowDrop = true;
			this.lblLGroupName.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblLGroupName.Text = "Counter Name (English)";
			this.lblLGroupName.ForeColor = System.Drawing.Color.Black;
			this.lblLGroupName.Location = new System.Drawing.Point(9, 38);
			this.lblLGroupName.Name = "lblLGroupName";
			this.lblLGroupName.Size = new System.Drawing.Size(113, 14);
			this.lblLGroupName.TabIndex = 2;
			// 
			// txtLCounterName
			// 
			this.txtLCounterName.AllowDrop = true;
			this.txtLCounterName.BackColor = System.Drawing.Color.White;
			this.txtLCounterName.ForeColor = System.Drawing.Color.Black;
			this.txtLCounterName.Location = new System.Drawing.Point(127, 36);
			this.txtLCounterName.MaxLength = 50;
			this.txtLCounterName.Name = "txtLCounterName";
			this.txtLCounterName.Size = new System.Drawing.Size(201, 19);
			this.txtLCounterName.TabIndex = 3;
			this.txtLCounterName.Text = "";
			// 
			// lblParentGroup
			// 
			this.lblParentGroup.AllowDrop = true;
			this.lblParentGroup.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblParentGroup.Text = "Location Code";
			this.lblParentGroup.ForeColor = System.Drawing.Color.Black;
			this.lblParentGroup.Location = new System.Drawing.Point(9, 80);
			this.lblParentGroup.Name = "lblParentGroup";
			this.lblParentGroup.Size = new System.Drawing.Size(69, 14);
			this.lblParentGroup.TabIndex = 6;
			// 
			// lblAGroupName
			// 
			this.lblAGroupName.AllowDrop = true;
			this.lblAGroupName.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblAGroupName.Text = "Counter Name (Arabic)";
			this.lblAGroupName.ForeColor = System.Drawing.Color.Black;
			this.lblAGroupName.Location = new System.Drawing.Point(9, 59);
			this.lblAGroupName.Name = "lblAGroupName";
			this.lblAGroupName.Size = new System.Drawing.Size(111, 14);
			this.lblAGroupName.TabIndex = 4;
			// 
			// txtACounterName
			// 
			this.txtACounterName.AllowDrop = true;
			this.txtACounterName.BackColor = System.Drawing.Color.White;
			this.txtACounterName.ForeColor = System.Drawing.Color.Black;
			this.txtACounterName.Location = new System.Drawing.Point(127, 57);
			// this.txtACounterName.mArabicEnabled = true;
			this.txtACounterName.MaxLength = 50;
			this.txtACounterName.Name = "txtACounterName";
			this.txtACounterName.Size = new System.Drawing.Size(201, 19);
			this.txtACounterName.TabIndex = 5;
			this.txtACounterName.Text = "";
			// 
			// lblComments
			// 
			this.lblComments.AllowDrop = true;
			this.lblComments.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblComments.Text = "Computer Name";
			this.lblComments.ForeColor = System.Drawing.Color.Black;
			this.lblComments.Location = new System.Drawing.Point(9, 101);
			this.lblComments.Name = "lblComments";
			this.lblComments.Size = new System.Drawing.Size(76, 14);
			this.lblComments.TabIndex = 9;
			// 
			// txtLocationNo
			// 
			this.txtLocationNo.AllowDrop = true;
			this.txtLocationNo.BackColor = System.Drawing.Color.White;
			// this.txtLocationNo.bolNumericOnly = true;
			this.txtLocationNo.ForeColor = System.Drawing.Color.Black;
			this.txtLocationNo.Location = new System.Drawing.Point(127, 78);
			this.txtLocationNo.MaxLength = 15;
			this.txtLocationNo.Name = "txtLocationNo";
			// this.txtLocationNo.ShowButton = true;
			this.txtLocationNo.Size = new System.Drawing.Size(101, 19);
			this.txtLocationNo.TabIndex = 7;
			this.txtLocationNo.Text = "";
			// this.this.txtLocationNo.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(this.txtLocationNo_DropButtonClick);
			// this.txtLocationNo.Leave += new System.EventHandler(this.txtLocationNo_Leave);
			// 
			// txtLocationName
			// 
			this.txtLocationName.AllowDrop = true;
			this.txtLocationName.BackColor = System.Drawing.Color.FromArgb(239, 239, 239);
			this.txtLocationName.Enabled = false;
			this.txtLocationName.ForeColor = System.Drawing.Color.Black;
			this.txtLocationName.Location = new System.Drawing.Point(230, 78);
			this.txtLocationName.Name = "txtLocationName";
			this.txtLocationName.Size = new System.Drawing.Size(191, 19);
			this.txtLocationName.TabIndex = 8;
			this.txtLocationName.TabStop = false;
			this.txtLocationName.Text = " ";
			// 
			// txtComputerName
			// 
			this.txtComputerName.AllowDrop = true;
			this.txtComputerName.BackColor = System.Drawing.Color.White;
			this.txtComputerName.ForeColor = System.Drawing.Color.Black;
			this.txtComputerName.Location = new System.Drawing.Point(127, 99);
			this.txtComputerName.MaxLength = 50;
			this.txtComputerName.Name = "txtComputerName";
			this.txtComputerName.Size = new System.Drawing.Size(201, 19);
			this.txtComputerName.TabIndex = 10;
			this.txtComputerName.Text = "";
			// 
			// lblPolePort
			// 
			this.lblPolePort.AllowDrop = true;
			this.lblPolePort.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.lblPolePort.Text = "Port No";
			this.lblPolePort.ForeColor = System.Drawing.Color.Black;
			this.lblPolePort.Location = new System.Drawing.Point(128, 126);
			this.lblPolePort.Name = "lblPolePort";
			this.lblPolePort.Size = new System.Drawing.Size(35, 14);
			this.lblPolePort.TabIndex = 13;
			// 
			// txtPortNo
			// 
			this.txtPortNo.AllowDrop = true;
			this.txtPortNo.BackColor = System.Drawing.Color.White;
			this.txtPortNo.ForeColor = System.Drawing.Color.Black;
			this.txtPortNo.Location = new System.Drawing.Point(170, 122);
			this.txtPortNo.MaxLength = 50;
			this.txtPortNo.Name = "txtPortNo";
			this.txtPortNo.Size = new System.Drawing.Size(37, 19);
			this.txtPortNo.TabIndex = 14;
			this.txtPortNo.Text = "";
			// 
			// txtCDPortNo
			// 
			this.txtCDPortNo.AllowDrop = true;
			this.txtCDPortNo.BackColor = System.Drawing.Color.White;
			this.txtCDPortNo.ForeColor = System.Drawing.Color.Black;
			this.txtCDPortNo.Location = new System.Drawing.Point(170, 146);
			this.txtCDPortNo.MaxLength = 50;
			this.txtCDPortNo.Name = "txtCDPortNo";
			this.txtCDPortNo.Size = new System.Drawing.Size(37, 19);
			this.txtCDPortNo.TabIndex = 15;
			this.txtCDPortNo.Text = "";
			// 
			// System.Windows.Forms.Label1
			// 
			this.Label1.AllowDrop = true;
			this.Label1.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.Label1.Text = "Port No";
			this.Label1.ForeColor = System.Drawing.Color.Black;
			this.Label1.Location = new System.Drawing.Point(128, 148);
			this.Label1.Name = "System.Windows.Forms.Label1";
			this.Label1.Size = new System.Drawing.Size(35, 14);
			this.Label1.TabIndex = 16;
			// 
			// frmICSPOSCounter
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.ClientSize = new System.Drawing.Size(429, 212);
			this.Controls.Add(this.chkCD);
			this.Controls.Add(this.chkPoleDisplay);
			this.Controls.Add(this.chkFreeze);
			this.Controls.Add(this.txtCounterNo);
			this.Controls.Add(this.lblGroupNo);
			this.Controls.Add(this.lblLGroupName);
			this.Controls.Add(this.txtLCounterName);
			this.Controls.Add(this.lblParentGroup);
			this.Controls.Add(this.lblAGroupName);
			this.Controls.Add(this.txtACounterName);
			this.Controls.Add(this.lblComments);
			this.Controls.Add(this.txtLocationNo);
			this.Controls.Add(this.txtLocationName);
			this.Controls.Add(this.txtComputerName);
			this.Controls.Add(this.lblPolePort);
			this.Controls.Add(this.txtPortNo);
			this.Controls.Add(this.txtCDPortNo);
			this.Controls.Add(this.Label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			//this.Icon = (System.Drawing.Icon) resources.GetObject("frmICSPOSCounter.Icon");
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(393, 210);
			this.MaximizeBox = true;
			this.MinimizeBox = true;
			this.Name = "frmICSPOSCounter";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "POS Counter";
			// this.Activated += new System.EventHandler(this.frmICSPOSCounter_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
			// this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
			this.ResumeLayout(false);
		}
		// 
		#endregion
	}
}//ENDSHERE
