
namespace Xtreme
{
	partial class frmICSTransBatch
	{

		#region "Upgrade Support "
		private static frmICSTransBatch m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmICSTransBatch DefInstance
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
		public static frmICSTransBatch CreateInstance()
		{
			frmICSTransBatch theInstance = new frmICSTransBatch();
			
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
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "txtComment", "lblLCostName", "txtLBatchName", "lblACostName", "txtABatchName", "lblComments", "txtBatchNo", "lblCostNo"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public System.Windows.Forms.TextBox txtComment;
		public System.Windows.Forms.Label lblLCostName;
		public System.Windows.Forms.TextBox txtLBatchName;
		public System.Windows.Forms.Label lblACostName;
		public System.Windows.Forms.TextBox txtABatchName;
		public System.Windows.Forms.Label lblComments;
		public System.Windows.Forms.TextBox txtBatchNo;
		public System.Windows.Forms.Label lblCostNo;
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmICSTransBatch));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this.txtComment = new System.Windows.Forms.TextBox();
			this.lblLCostName = new System.Windows.Forms.Label();
			this.txtLBatchName = new System.Windows.Forms.TextBox();
			this.lblACostName = new System.Windows.Forms.Label();
			this.txtABatchName = new System.Windows.Forms.TextBox();
			this.lblComments = new System.Windows.Forms.Label();
			this.txtBatchNo = new System.Windows.Forms.TextBox();
			this.lblCostNo = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// txtComment
			// 
			this.txtComment.AcceptsReturn = true;
			//this.txtComment.AllowDrop = true;
			this.txtComment.BackColor = System.Drawing.SystemColors.Window;
			//this.txtComment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtComment.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtComment.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtComment.Location = new System.Drawing.Point(130, 117);
			this.txtComment.MaxLength = 100;
			this.txtComment.Multiline = true;
			this.txtComment.Name = "txtComment";
			this.txtComment.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtComment.Size = new System.Drawing.Size(304, 38);
			this.txtComment.TabIndex = 3;
			// 
			// lblLCostName
			// 
			//this.lblLCostName.AllowDrop = true;
			this.lblLCostName.BackColor = System.Drawing.Color.FromArgb(205, 184, 196);
			this.lblLCostName.Text = "Batch Name (English)";
			this.lblLCostName.ForeColor = System.Drawing.Color.Black;
			this.lblLCostName.Location = new System.Drawing.Point(8, 78);
			this.lblLCostName.Name = "lblLCostName";
			this.lblLCostName.Size = new System.Drawing.Size(103, 14);
			this.lblLCostName.TabIndex = 4;
			// 
			// txtLBatchName
			// 
			//this.txtLBatchName.AllowDrop = true;
			this.txtLBatchName.BackColor = System.Drawing.Color.White;
			this.txtLBatchName.ForeColor = System.Drawing.Color.Black;
			this.txtLBatchName.Location = new System.Drawing.Point(130, 75);
			this.txtLBatchName.MaxLength = 50;
			this.txtLBatchName.Name = "txtLBatchName";
			this.txtLBatchName.Size = new System.Drawing.Size(201, 19);
			this.txtLBatchName.TabIndex = 1;
			this.txtLBatchName.Text = "";
			// this.// = "";
			// 
			// lblACostName
			// 
			//this.lblACostName.AllowDrop = true;
			this.lblACostName.BackColor = System.Drawing.Color.FromArgb(205, 184, 196);
			this.lblACostName.Text = "Batch Name (Arabic)";
			this.lblACostName.ForeColor = System.Drawing.Color.Black;
			this.lblACostName.Location = new System.Drawing.Point(8, 99);
			this.lblACostName.Name = "lblACostName";
			this.lblACostName.Size = new System.Drawing.Size(101, 14);
			this.lblACostName.TabIndex = 5;
			// 
			// txtABatchName
			// 
			//this.txtABatchName.AllowDrop = true;
			this.txtABatchName.BackColor = System.Drawing.Color.White;
			this.txtABatchName.ForeColor = System.Drawing.Color.Black;
			this.txtABatchName.Location = new System.Drawing.Point(130, 96);
			// // = true;
			this.txtABatchName.MaxLength = 50;
			this.txtABatchName.Name = "txtABatchName";
			this.txtABatchName.Size = new System.Drawing.Size(201, 19);
			this.txtABatchName.TabIndex = 2;
			this.txtABatchName.Text = "";
			// this.// = "";
			// 
			// lblComments
			// 
			//this.lblComments.AllowDrop = true;
			this.lblComments.BackColor = System.Drawing.Color.FromArgb(205, 184, 196);
			this.lblComments.Text = "Comment";
			this.lblComments.ForeColor = System.Drawing.Color.Black;
			this.lblComments.Location = new System.Drawing.Point(8, 117);
			// // this.lblComments.mLabelId = 135;
			this.lblComments.Name = "lblComments";
			this.lblComments.Size = new System.Drawing.Size(44, 14);
			this.lblComments.TabIndex = 6;
			// 
			// txtBatchNo
			// 
			//this.txtBatchNo.AllowDrop = true;
			this.txtBatchNo.BackColor = System.Drawing.Color.White;
			// this.txtBatchNo.bolNumericOnly = true;
			this.txtBatchNo.ForeColor = System.Drawing.Color.Black;
			this.txtBatchNo.Location = new System.Drawing.Point(130, 54);
			this.txtBatchNo.MaxLength = 15;
			// // = System.Windows.Forms.TextBox.DropDownTypes.ddtNextNumber;
			this.txtBatchNo.Name = "txtBatchNo";
			// this.txtBatchNo.ShowButton = true;
			this.txtBatchNo.Size = new System.Drawing.Size(101, 19);
			this.txtBatchNo.TabIndex = 0;
			this.txtBatchNo.Text = "";
			// this.// = "";
			// this.//this.txtBatchNo.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(//this.txtBatchNo_DropButtonClick);
			// 
			// lblCostNo
			// 
			//this.lblCostNo.AllowDrop = true;
			this.lblCostNo.BackColor = System.Drawing.Color.FromArgb(205, 184, 196);
			this.lblCostNo.Text = "Batch Code";
			this.lblCostNo.ForeColor = System.Drawing.Color.Black;
			this.lblCostNo.Location = new System.Drawing.Point(8, 57);
			this.lblCostNo.Name = "lblCostNo";
			this.lblCostNo.Size = new System.Drawing.Size(56, 14);
			this.lblCostNo.TabIndex = 7;
			// 
			// frmICSTransBatch
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.FromArgb(205, 184, 196);
			this.ClientSize = new System.Drawing.Size(450, 166);
			this.Controls.Add(this.txtComment);
			this.Controls.Add(this.lblLCostName);
			this.Controls.Add(this.txtLBatchName);
			this.Controls.Add(this.lblACostName);
			this.Controls.Add(this.txtABatchName);
			this.Controls.Add(this.lblComments);
			this.Controls.Add(this.txtBatchNo);
			this.Controls.Add(this.lblCostNo);
			//this.Icon = (System.Drawing.Icon) resources.GetObject("frmICSTransBatch.Icon");
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(119, 177);
			this.MaximizeBox = true;
			this.MinimizeBox = true;
			this.Name = "frmICSTransBatch";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Batch";
			// this.Activated += new System.EventHandler(this.frmICSTransBatch_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
			// this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
			this.ResumeLayout(false);
		}
		// 
		#endregion
	}
}//ENDSHERE
