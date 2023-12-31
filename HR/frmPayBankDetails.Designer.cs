
namespace Xtreme
{
	partial class frmPayBankDetails
	{

		#region "Upgrade Support "
		private static frmPayBankDetails m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmPayBankDetails DefInstance
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
		public static frmPayBankDetails CreateInstance()
		{
			frmPayBankDetails theInstance = new frmPayBankDetails();
			
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
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "_cmdCommon_0", "_lblCommon_7", "_lblCommon_8", "_Frame1_0", "txtComment", "_lblCommon_4", "_lblCommon_5", "txtParentGroupNo", "_lblCommon_6", "txtParentGroupName", "_lblCommon_41", "txtDTypeName", "txtTypeCode", "fraDetailsInfo", "_lblCommon_0", "txtGroupNo", "_lblCommon_1", "txtLGroupName", "_lblCommon_2", "txtAGroupName", "_lblCommon_3", "Line1", "Frame1", "cmdCommon", "lblCommon"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		private System.Windows.Forms.Button _cmdCommon_0;
		private System.Windows.Forms.Label _lblCommon_7;
		private System.Windows.Forms.Label _lblCommon_8;
		private System.Windows.Forms.Panel _Frame1_0;
		public System.Windows.Forms.TextBox txtComment;
		private System.Windows.Forms.Label _lblCommon_4;
		private System.Windows.Forms.Label _lblCommon_5;
		public System.Windows.Forms.TextBox txtParentGroupNo;
		private System.Windows.Forms.Label _lblCommon_6;
		public System.Windows.Forms.Label txtParentGroupName;
		private System.Windows.Forms.Label _lblCommon_41;
		public System.Windows.Forms.Label txtDTypeName;
		public System.Windows.Forms.TextBox txtTypeCode;
		public System.Windows.Forms.Panel fraDetailsInfo;
		private System.Windows.Forms.Label _lblCommon_0;
		public System.Windows.Forms.TextBox txtGroupNo;
		private System.Windows.Forms.Label _lblCommon_1;
		public System.Windows.Forms.TextBox txtLGroupName;
		private System.Windows.Forms.Label _lblCommon_2;
		public System.Windows.Forms.TextBox txtAGroupName;
		private System.Windows.Forms.Label _lblCommon_3;
		public System.Windows.Forms.Label Line1;
		public System.Windows.Forms.Panel[] Frame1 = new System.Windows.Forms.Panel[1];
		public System.Windows.Forms.Button[] cmdCommon = new System.Windows.Forms.Button[1];
		public System.Windows.Forms.Label[] lblCommon = new System.Windows.Forms.Label[42];
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPayBankDetails));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this.fraDetailsInfo = new System.Windows.Forms.Panel();
			this._cmdCommon_0 = new System.Windows.Forms.Button();
			this._Frame1_0 = new System.Windows.Forms.Panel();
			this._lblCommon_7 = new System.Windows.Forms.Label();
			this._lblCommon_8 = new System.Windows.Forms.Label();
			this.txtComment = new System.Windows.Forms.TextBox();
			this._lblCommon_4 = new System.Windows.Forms.Label();
			this._lblCommon_5 = new System.Windows.Forms.Label();
			this.txtParentGroupNo = new System.Windows.Forms.TextBox();
			this._lblCommon_6 = new System.Windows.Forms.Label();
			this.txtParentGroupName = new System.Windows.Forms.Label();
			this._lblCommon_41 = new System.Windows.Forms.Label();
			this.txtDTypeName = new System.Windows.Forms.Label();
			this.txtTypeCode = new System.Windows.Forms.TextBox();
			this._lblCommon_0 = new System.Windows.Forms.Label();
			this.txtGroupNo = new System.Windows.Forms.TextBox();
			this._lblCommon_1 = new System.Windows.Forms.Label();
			this.txtLGroupName = new System.Windows.Forms.TextBox();
			this._lblCommon_2 = new System.Windows.Forms.Label();
			this.txtAGroupName = new System.Windows.Forms.TextBox();
			this._lblCommon_3 = new System.Windows.Forms.Label();
			this.Line1 = new System.Windows.Forms.Label();
			// //((System.ComponentModel.ISupportInitialize) this.fraDetailsInfo).BeginInit();
			//this.fraDetailsInfo.SuspendLayout();
			//this._Frame1_0.SuspendLayout();
			this.SuspendLayout();
			// 
			// fraDetailsInfo
			// 
			//this.fraDetailsInfo.AllowDrop = true;
			this.fraDetailsInfo.Controls.Add(this._cmdCommon_0);
			this.fraDetailsInfo.Controls.Add(this._Frame1_0);
			this.fraDetailsInfo.Controls.Add(this.txtComment);
			this.fraDetailsInfo.Controls.Add(this._lblCommon_4);
			this.fraDetailsInfo.Controls.Add(this._lblCommon_5);
			this.fraDetailsInfo.Controls.Add(this.txtParentGroupNo);
			this.fraDetailsInfo.Controls.Add(this._lblCommon_6);
			this.fraDetailsInfo.Controls.Add(this.txtParentGroupName);
			this.fraDetailsInfo.Controls.Add(this._lblCommon_41);
			this.fraDetailsInfo.Controls.Add(this.txtDTypeName);
			this.fraDetailsInfo.Controls.Add(this.txtTypeCode);
			this.fraDetailsInfo.Location = new System.Drawing.Point(5, 118);
			this.fraDetailsInfo.Name = "fraDetailsInfo";
			//
			this.fraDetailsInfo.Size = new System.Drawing.Size(551, 143);
			this.fraDetailsInfo.TabIndex = 6;
			// 
			// _cmdCommon_0
			// 
			//this._cmdCommon_0.AllowDrop = true;
			this._cmdCommon_0.BackColor = System.Drawing.SystemColors.Control;
			this._cmdCommon_0.ForeColor = System.Drawing.SystemColors.ControlText;
			this._cmdCommon_0.Location = new System.Drawing.Point(410, 14);
			this._cmdCommon_0.Name = "_cmdCommon_0";
			this._cmdCommon_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._cmdCommon_0.Size = new System.Drawing.Size(20, 19);
			this._cmdCommon_0.TabIndex = 18;
			this._cmdCommon_0.Text = "...";
			this._cmdCommon_0.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this._cmdCommon_0.UseVisualStyleBackColor = false;
			// this._cmdCommon_0.Click += new System.EventHandler(this.cmdCommon_Click);
			// 
			// _Frame1_0
			// 
			//this._Frame1_0.AllowDrop = true;
			this._Frame1_0.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			//this._Frame1_0.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._Frame1_0.Controls.Add(this._lblCommon_7);
			this._Frame1_0.Controls.Add(this._lblCommon_8);
			this._Frame1_0.Enabled = true;
			this._Frame1_0.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Italic | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 178);
			this._Frame1_0.ForeColor = System.Drawing.Color.FromArgb(224, 224, 224);
			this._Frame1_0.Location = new System.Drawing.Point(303, 38);
			this._Frame1_0.Name = "_Frame1_0";
			this._Frame1_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._Frame1_0.Size = new System.Drawing.Size(235, 43);
			this._Frame1_0.TabIndex = 14;
			this._Frame1_0.Visible = true;
			// 
			// _lblCommon_7
			// 
			//this._lblCommon_7.AllowDrop = true;
			this._lblCommon_7.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._lblCommon_7.Text = "Total 0 Ledger Accounts (Under This Group)";
			this._lblCommon_7.ForeColor = System.Drawing.Color.FromArgb(166, 166, 166);
			this._lblCommon_7.Location = new System.Drawing.Point(6, 24);
			this._lblCommon_7.Name = "_lblCommon_7";
			this._lblCommon_7.Size = new System.Drawing.Size(215, 14);
			this._lblCommon_7.TabIndex = 15;
			this._lblCommon_7.Visible = false;
			// 
			// _lblCommon_8
			// 
			//this._lblCommon_8.AllowDrop = true;
			this._lblCommon_8.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._lblCommon_8.Text = "Total 0 Sub Groups (Under This Group)";
			this._lblCommon_8.ForeColor = System.Drawing.Color.FromArgb(166, 166, 166);
			this._lblCommon_8.Location = new System.Drawing.Point(6, 8);
			this._lblCommon_8.Name = "_lblCommon_8";
			this._lblCommon_8.Size = new System.Drawing.Size(189, 14);
			this._lblCommon_8.TabIndex = 16;
			this._lblCommon_8.Visible = false;
			// 
			// txtComment
			// 
			this.txtComment.AcceptsReturn = true;
			//this.txtComment.AllowDrop = true;
			this.txtComment.BackColor = System.Drawing.SystemColors.Window;
			//this.txtComment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtComment.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtComment.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtComment.Location = new System.Drawing.Point(104, 102);
			this.txtComment.MaxLength = 100;
			this.txtComment.Multiline = true;
			this.txtComment.Name = "txtComment";
			this.txtComment.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtComment.Size = new System.Drawing.Size(434, 32);
			this.txtComment.TabIndex = 5;
			// 
			// _lblCommon_4
			// 
			//this._lblCommon_4.AllowDrop = true;
			this._lblCommon_4.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._lblCommon_4.Text = "Parent Group";
			this._lblCommon_4.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_4.Location = new System.Drawing.Point(9, 17);
			// // this._lblCommon_4.mLabelId = 503;
			this._lblCommon_4.Name = "_lblCommon_4";
			this._lblCommon_4.Size = new System.Drawing.Size(64, 14);
			this._lblCommon_4.TabIndex = 7;
			// 
			// _lblCommon_5
			// 
			//this._lblCommon_5.AllowDrop = true;
			this._lblCommon_5.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._lblCommon_5.Text = "Comments";
			this._lblCommon_5.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_5.Location = new System.Drawing.Point(9, 102);
			// // this._lblCommon_5.mLabelId = 135;
			this._lblCommon_5.Name = "_lblCommon_5";
			this._lblCommon_5.Size = new System.Drawing.Size(50, 14);
			this._lblCommon_5.TabIndex = 8;
			// 
			// txtParentGroupNo
			// 
			//this.txtParentGroupNo.AllowDrop = true;
			this.txtParentGroupNo.BackColor = System.Drawing.Color.White;
			// this.txtParentGroupNo.bolNumericOnly = true;
			this.txtParentGroupNo.ForeColor = System.Drawing.Color.Black;
			this.txtParentGroupNo.Location = new System.Drawing.Point(104, 14);
			this.txtParentGroupNo.MaxLength = 15;
			this.txtParentGroupNo.Name = "txtParentGroupNo";
			// this.txtParentGroupNo.ShowButton = true;
			this.txtParentGroupNo.Size = new System.Drawing.Size(101, 19);
			this.txtParentGroupNo.TabIndex = 3;
			this.txtParentGroupNo.Text = "";
			// this.//this.txtParentGroupNo.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(//this.txtParentGroupNo_DropButtonClick);
			// this.txtParentGroupNo.Leave += new System.EventHandler(this.txtParentGroupNo_Leave);
			// 
			// _lblCommon_6
			// 
			//this._lblCommon_6.AllowDrop = true;
			this._lblCommon_6.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._lblCommon_6.Text = " (Parent Group Name) ";
			this._lblCommon_6.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_6.Location = new System.Drawing.Point(104, 37);
			this._lblCommon_6.Name = "_lblCommon_6";
			this._lblCommon_6.Size = new System.Drawing.Size(108, 14);
			this._lblCommon_6.TabIndex = 13;
			this._lblCommon_6.Visible = false;
			// 
			// txtParentGroupName
			// 
			//this.txtParentGroupName.AllowDrop = true;
			this.txtParentGroupName.Location = new System.Drawing.Point(207, 14);
			this.txtParentGroupName.Name = "txtParentGroupName";
			this.txtParentGroupName.Size = new System.Drawing.Size(201, 19);
			this.txtParentGroupName.TabIndex = 17;
			// 
			// _lblCommon_41
			// 
			//this._lblCommon_41.AllowDrop = true;
			this._lblCommon_41.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
			this._lblCommon_41.Text = "Type Code";
			this._lblCommon_41.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_41.Location = new System.Drawing.Point(9, 84);
			// // this._lblCommon_41.mLabelId = 1902;
			this._lblCommon_41.Name = "_lblCommon_41";
			this._lblCommon_41.Size = new System.Drawing.Size(52, 14);
			this._lblCommon_41.TabIndex = 19;
			// 
			// txtDTypeName
			// 
			//this.txtDTypeName.AllowDrop = true;
			this.txtDTypeName.Location = new System.Drawing.Point(207, 82);
			this.txtDTypeName.Name = "txtDTypeName";
			this.txtDTypeName.Size = new System.Drawing.Size(201, 19);
			this.txtDTypeName.TabIndex = 20;
			// 
			// txtTypeCode
			// 
			//this.txtTypeCode.AllowDrop = true;
			this.txtTypeCode.BackColor = System.Drawing.Color.White;
			// this.txtTypeCode.bolNumericOnly = true;
			this.txtTypeCode.ForeColor = System.Drawing.Color.Black;
			this.txtTypeCode.Location = new System.Drawing.Point(104, 82);
			this.txtTypeCode.MaxLength = 15;
			this.txtTypeCode.Name = "txtTypeCode";
			// this.txtTypeCode.ShowButton = true;
			this.txtTypeCode.Size = new System.Drawing.Size(101, 19);
			this.txtTypeCode.TabIndex = 4;
			this.txtTypeCode.Text = "";
			// this.//this.txtTypeCode.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(//this.txtTypeCode_DropButtonClick);
			// this.txtTypeCode.Leave += new System.EventHandler(this.txtTypeCode_Leave);
			// 
			// _lblCommon_0
			// 
			//this._lblCommon_0.AllowDrop = true;
			this._lblCommon_0.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_0.Text = "Group Code";
			this._lblCommon_0.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_0.Location = new System.Drawing.Point(16, 55);
			// // this._lblCommon_0.mLabelId = 304;
			this._lblCommon_0.Name = "_lblCommon_0";
			this._lblCommon_0.Size = new System.Drawing.Size(58, 14);
			this._lblCommon_0.TabIndex = 9;
			// 
			// txtGroupNo
			// 
			//this.txtGroupNo.AllowDrop = true;
			this.txtGroupNo.BackColor = System.Drawing.Color.White;
			// this.txtGroupNo.bolNumericOnly = true;
			this.txtGroupNo.ForeColor = System.Drawing.Color.Black;
			this.txtGroupNo.Location = new System.Drawing.Point(94, 52);
			this.txtGroupNo.MaxLength = 15;
			// // = System.Windows.Forms.TextBox.DropDownTypes.ddtNextNumber;
			this.txtGroupNo.Name = "txtGroupNo";
			// this.txtGroupNo.ShowButton = true;
			this.txtGroupNo.Size = new System.Drawing.Size(101, 19);
			this.txtGroupNo.TabIndex = 0;
			this.txtGroupNo.Text = "";
			// this.//this.txtGroupNo.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(//this.txtGroupNo_DropButtonClick);
			// 
			// _lblCommon_1
			// 
			//this._lblCommon_1.AllowDrop = true;
			this._lblCommon_1.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_1.Text = "Group Name (English)";
			this._lblCommon_1.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_1.Location = new System.Drawing.Point(230, 54);
			// // this._lblCommon_1.mLabelId = 302;
			this._lblCommon_1.Name = "_lblCommon_1";
			this._lblCommon_1.Size = new System.Drawing.Size(105, 14);
			this._lblCommon_1.TabIndex = 10;
			// 
			// txtLGroupName
			// 
			//this.txtLGroupName.AllowDrop = true;
			this.txtLGroupName.BackColor = System.Drawing.Color.White;
			this.txtLGroupName.ForeColor = System.Drawing.Color.Black;
			this.txtLGroupName.Location = new System.Drawing.Point(352, 52);
			this.txtLGroupName.MaxLength = 50;
			this.txtLGroupName.Name = "txtLGroupName";
			this.txtLGroupName.Size = new System.Drawing.Size(201, 19);
			this.txtLGroupName.TabIndex = 1;
			this.txtLGroupName.Text = "";
			// 
			// _lblCommon_2
			// 
			//this._lblCommon_2.AllowDrop = true;
			this._lblCommon_2.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_2.Text = "Group Name (Arabic)";
			this._lblCommon_2.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_2.Location = new System.Drawing.Point(230, 75);
			// // this._lblCommon_2.mLabelId = 303;
			this._lblCommon_2.Name = "_lblCommon_2";
			this._lblCommon_2.Size = new System.Drawing.Size(103, 14);
			this._lblCommon_2.TabIndex = 11;
			// 
			// txtAGroupName
			// 
			//this.txtAGroupName.AllowDrop = true;
			this.txtAGroupName.BackColor = System.Drawing.Color.White;
			this.txtAGroupName.ForeColor = System.Drawing.Color.Black;
			this.txtAGroupName.Location = new System.Drawing.Point(352, 73);
			// // = true;
			this.txtAGroupName.MaxLength = 50;
			this.txtAGroupName.Name = "txtAGroupName";
			this.txtAGroupName.Size = new System.Drawing.Size(201, 19);
			this.txtAGroupName.TabIndex = 2;
			this.txtAGroupName.Text = "";
			// 
			// _lblCommon_3
			// 
			//this._lblCommon_3.AllowDrop = true;
			this._lblCommon_3.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_3.Text = " Group Information ";
			this._lblCommon_3.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_3.Location = new System.Drawing.Point(32, 94);
			this._lblCommon_3.Name = "_lblCommon_3";
			this._lblCommon_3.Size = new System.Drawing.Size(107, 14);
			this._lblCommon_3.TabIndex = 12;
			// 
			// Line1
			// 
			//this.Line1.AllowDrop = true;
			this.Line1.BackColor = System.Drawing.SystemColors.WindowText;
			this.Line1.Enabled = false;
			this.Line1.Location = new System.Drawing.Point(0, 102);
			this.Line1.Name = "Line1";
			this.Line1.Size = new System.Drawing.Size(736, 1);
			this.Line1.Visible = true;
			// 
			// frmPayBankDetails
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.ClientSize = new System.Drawing.Size(560, 264);
			this.Controls.Add(this.fraDetailsInfo);
			this.Controls.Add(this._lblCommon_0);
			this.Controls.Add(this.txtGroupNo);
			this.Controls.Add(this._lblCommon_1);
			this.Controls.Add(this.txtLGroupName);
			this.Controls.Add(this._lblCommon_2);
			this.Controls.Add(this.txtAGroupName);
			this.Controls.Add(this._lblCommon_3);
			this.Controls.Add(this.Line1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(383, 209);
			this.MaximizeBox = true;
			this.MinimizeBox = true;
			this.Name = "frmPayBankDetails";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Account Groups";
			// this.Activated += new System.EventHandler(this.Form_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
			// this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
			//((System.ComponentModel.ISupportInitialize) this.fraDetailsInfo).EndInit();
			this.fraDetailsInfo.ResumeLayout(false);
			this._Frame1_0.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		// 
		void InitializelblCommon()
		{
			this.lblCommon = new System.Windows.Forms.Label[42];
			this.lblCommon[7] = _lblCommon_7;
			this.lblCommon[8] = _lblCommon_8;
			this.lblCommon[4] = _lblCommon_4;
			this.lblCommon[5] = _lblCommon_5;
			this.lblCommon[6] = _lblCommon_6;
			this.lblCommon[41] = _lblCommon_41;
			this.lblCommon[0] = _lblCommon_0;
			this.lblCommon[1] = _lblCommon_1;
			this.lblCommon[2] = _lblCommon_2;
			this.lblCommon[3] = _lblCommon_3;
		}
		void InitializecmdCommon()
		{
			this.cmdCommon = new System.Windows.Forms.Button[1];
			this.cmdCommon[0] = _cmdCommon_0;
		}
		void InitializeFrame1()
		{
			this.Frame1 = new System.Windows.Forms.Panel[1];
			this.Frame1[0] = _Frame1_0;
		}
		#endregion
	}
}//ENDSHERE
