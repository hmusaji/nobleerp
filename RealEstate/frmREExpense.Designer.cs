
namespace Xtreme
{
	partial class frmREExpense
	{

		#region "Upgrade Support "
		private static frmREExpense m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmREExpense DefInstance
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
		public static frmREExpense CreateInstance()
		{
			frmREExpense theInstance = new frmREExpense();
			
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
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "txtRemarks", "_txtCommonNumber_0", "_lblCommon_5", "txtCommonDate", "_lblCommon_3", "_txtCommon_2", "_lblCommon_1", "_txtCommon_1", "_lblCommon_2", "_txtCommon_3", "_lblCommon_9", "_txtCommon_5", "_lblCommon_10", "_txtCommonDisplay_3", "_txtCommonDisplay_2", "_txtCommonDisplay_1", "_txtCommonDisplay_0", "_lblCommon_0", "lblCommon", "txtCommon", "txtCommonDisplay", "txtCommonNumber"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public System.Windows.Forms.TextBox txtRemarks;
		private System.Windows.Forms.TextBox _txtCommonNumber_0;
		private System.Windows.Forms.Label _lblCommon_5;
		public Syncfusion.WinForms.Input.SfDateTimeEdit txtCommonDate;
		private System.Windows.Forms.Label _lblCommon_3;
		private System.Windows.Forms.TextBox _txtCommon_2;
		private System.Windows.Forms.Label _lblCommon_1;
		private System.Windows.Forms.TextBox _txtCommon_1;
		private System.Windows.Forms.Label _lblCommon_2;
		private System.Windows.Forms.TextBox _txtCommon_3;
		private System.Windows.Forms.Label _lblCommon_9;
		private System.Windows.Forms.TextBox _txtCommon_5;
		private System.Windows.Forms.Label _lblCommon_10;
		private System.Windows.Forms.Label _txtCommonDisplay_3;
		private System.Windows.Forms.Label _txtCommonDisplay_2;
		private System.Windows.Forms.Label _txtCommonDisplay_1;
		private System.Windows.Forms.Label _txtCommonDisplay_0;
		private System.Windows.Forms.Label _lblCommon_0;
		public System.Windows.Forms.Label[] lblCommon = new System.Windows.Forms.Label[11];
		public System.Windows.Forms.TextBox[] txtCommon = new System.Windows.Forms.TextBox[6];
		public System.Windows.Forms.Label[] txtCommonDisplay = new System.Windows.Forms.Label[4];
		public System.Windows.Forms.TextBox[] txtCommonNumber = new System.Windows.Forms.TextBox[1];
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmREExpense));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this.txtRemarks = new System.Windows.Forms.TextBox();
			this._txtCommonNumber_0 = new System.Windows.Forms.TextBox();
			this._lblCommon_5 = new System.Windows.Forms.Label();
			this.txtCommonDate = new Syncfusion.WinForms.Input.SfDateTimeEdit();
			this._lblCommon_3 = new System.Windows.Forms.Label();
			this._txtCommon_2 = new System.Windows.Forms.TextBox();
			this._lblCommon_1 = new System.Windows.Forms.Label();
			this._txtCommon_1 = new System.Windows.Forms.TextBox();
			this._lblCommon_2 = new System.Windows.Forms.Label();
			this._txtCommon_3 = new System.Windows.Forms.TextBox();
			this._lblCommon_9 = new System.Windows.Forms.Label();
			this._txtCommon_5 = new System.Windows.Forms.TextBox();
			this._lblCommon_10 = new System.Windows.Forms.Label();
			this._txtCommonDisplay_3 = new System.Windows.Forms.Label();
			this._txtCommonDisplay_2 = new System.Windows.Forms.Label();
			this._txtCommonDisplay_1 = new System.Windows.Forms.Label();
			this._txtCommonDisplay_0 = new System.Windows.Forms.Label();
			this._lblCommon_0 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// txtRemarks
			// 
			this.txtRemarks.AcceptsReturn = true;
			this.txtRemarks.AllowDrop = true;
			this.txtRemarks.BackColor = System.Drawing.SystemColors.Window;
			this.txtRemarks.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.txtRemarks.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtRemarks.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtRemarks.Location = new System.Drawing.Point(114, 160);
			this.txtRemarks.MaxLength = 0;
			this.txtRemarks.Multiline = true;
			this.txtRemarks.Name = "txtRemarks";
			this.txtRemarks.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtRemarks.Size = new System.Drawing.Size(305, 53);
			this.txtRemarks.TabIndex = 0;
			// 
			// _txtCommonNumber_0
			// 
			this._txtCommonNumber_0.AllowDrop = true;
			// this._txtCommonNumber_0.DisplayFormat = "#,###,##0.000#;;0.000;0.000";
			// this._txtCommonNumber_0.Format = "#########0.000#";
			this._txtCommonNumber_0.Location = new System.Drawing.Point(114, 136);
			// // = 2147483647;
			// // = 0;
			this._txtCommonNumber_0.Name = "_txtCommonNumber_0";
			this._txtCommonNumber_0.Size = new System.Drawing.Size(101, 19);
			this._txtCommonNumber_0.TabIndex = 1;
			this._txtCommonNumber_0.Text = "0.000";
			// 
			// _lblCommon_5
			// 
			this._lblCommon_5.AllowDrop = true;
			this._lblCommon_5.BackColor = System.Drawing.Color.FromArgb(241, 244, 248);
			this._lblCommon_5.Text = "Date";
			this._lblCommon_5.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_5.Location = new System.Drawing.Point(20, 24);
			// // this._lblCommon_5.mLabelId = 1160;
			this._lblCommon_5.Name = "_lblCommon_5";
			this._lblCommon_5.Size = new System.Drawing.Size(23, 13);
			this._lblCommon_5.TabIndex = 2;
			// 
			// txtCommonDate
			// 
			this.txtCommonDate.AllowDrop = true;
			// this.txtCommonDate.CheckDateRange = false;
			this.txtCommonDate.Location = new System.Drawing.Point(114, 22);
			// this.txtCommonDate.MaxDate = 2958465;
			// this.txtCommonDate.MinDate = 2;
			this.txtCommonDate.Name = "txtCommonDate";
			this.txtCommonDate.Size = new System.Drawing.Size(101, 19);
			this.txtCommonDate.TabIndex = 3;
			// this.txtCommonDate.Text = "10-Feb-2004";
			// this.txtCommonDate.Value = 38027;
			// 
			// _lblCommon_3
			// 
			this._lblCommon_3.AllowDrop = true;
			this._lblCommon_3.BackColor = System.Drawing.Color.FromArgb(241, 244, 248);
			this._lblCommon_3.Text = "Expense Type";
			this._lblCommon_3.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_3.Location = new System.Drawing.Point(20, 116);
			// // this._lblCommon_3.mLabelId = 1159;
			this._lblCommon_3.Name = "_lblCommon_3";
			this._lblCommon_3.Size = new System.Drawing.Size(68, 13);
			this._lblCommon_3.TabIndex = 4;
			// 
			// _txtCommon_2
			// 
			this._txtCommon_2.AllowDrop = true;
			this._txtCommon_2.BackColor = System.Drawing.Color.White;
			// this._txtCommon_2.bolNumericOnly = true;
			this._txtCommon_2.ForeColor = System.Drawing.Color.Black;
			this._txtCommon_2.Location = new System.Drawing.Point(114, 114);
			this._txtCommon_2.MaxLength = 15;
			this._txtCommon_2.Name = "_txtCommon_2";
			this._txtCommon_2.Size = new System.Drawing.Size(101, 19);
			this._txtCommon_2.TabIndex = 5;
			this._txtCommon_2.Text = "";
			// this.// = "";
			// 
			// _lblCommon_1
			// 
			this._lblCommon_1.AllowDrop = true;
			this._lblCommon_1.BackColor = System.Drawing.Color.FromArgb(241, 244, 248);
			this._lblCommon_1.Text = "Item Code";
			this._lblCommon_1.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_1.Location = new System.Drawing.Point(20, 71);
			// // this._lblCommon_1.mLabelId = 1156;
			this._lblCommon_1.Name = "_lblCommon_1";
			this._lblCommon_1.Size = new System.Drawing.Size(48, 13);
			this._lblCommon_1.TabIndex = 6;
			// 
			// _txtCommon_1
			// 
			this._txtCommon_1.AllowDrop = true;
			this._txtCommon_1.BackColor = System.Drawing.Color.White;
			// this._txtCommon_1.bolNumericOnly = true;
			this._txtCommon_1.ForeColor = System.Drawing.Color.Black;
			this._txtCommon_1.Location = new System.Drawing.Point(114, 69);
			this._txtCommon_1.MaxLength = 15;
			this._txtCommon_1.Name = "_txtCommon_1";
			// this._txtCommon_1.ShowButton = true;
			this._txtCommon_1.Size = new System.Drawing.Size(101, 19);
			this._txtCommon_1.TabIndex = 7;
			this._txtCommon_1.Text = "";
			// this.// = "";
			// 
			// _lblCommon_2
			// 
			this._lblCommon_2.AllowDrop = true;
			this._lblCommon_2.BackColor = System.Drawing.Color.FromArgb(241, 244, 248);
			this._lblCommon_2.Text = "Unit Code";
			this._lblCommon_2.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_2.Location = new System.Drawing.Point(20, 94);
			// // this._lblCommon_2.mLabelId = 1157;
			this._lblCommon_2.Name = "_lblCommon_2";
			this._lblCommon_2.Size = new System.Drawing.Size(47, 13);
			this._lblCommon_2.TabIndex = 8;
			// 
			// _txtCommon_3
			// 
			this._txtCommon_3.AllowDrop = true;
			this._txtCommon_3.BackColor = System.Drawing.Color.White;
			// this._txtCommon_3.bolNumericOnly = true;
			this._txtCommon_3.ForeColor = System.Drawing.Color.Black;
			this._txtCommon_3.Location = new System.Drawing.Point(114, 92);
			this._txtCommon_3.MaxLength = 15;
			this._txtCommon_3.Name = "_txtCommon_3";
			// this._txtCommon_3.ShowButton = true;
			this._txtCommon_3.Size = new System.Drawing.Size(101, 19);
			this._txtCommon_3.TabIndex = 9;
			this._txtCommon_3.Text = "";
			// this.// = "";
			// 
			// _lblCommon_9
			// 
			this._lblCommon_9.AllowDrop = true;
			this._lblCommon_9.BackColor = System.Drawing.Color.FromArgb(241, 244, 248);
			this._lblCommon_9.Text = "Property Code";
			this._lblCommon_9.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_9.Location = new System.Drawing.Point(20, 47);
			// // this._lblCommon_9.mLabelId = 1158;
			this._lblCommon_9.Name = "_lblCommon_9";
			this._lblCommon_9.Size = new System.Drawing.Size(69, 14);
			this._lblCommon_9.TabIndex = 10;
			// 
			// _txtCommon_5
			// 
			this._txtCommon_5.AllowDrop = true;
			this._txtCommon_5.BackColor = System.Drawing.Color.White;
			this._txtCommon_5.ForeColor = System.Drawing.Color.Black;
			this._txtCommon_5.Location = new System.Drawing.Point(114, 45);
			this._txtCommon_5.MaxLength = 15;
			this._txtCommon_5.Name = "_txtCommon_5";
			// this._txtCommon_5.ShowButton = true;
			this._txtCommon_5.Size = new System.Drawing.Size(101, 19);
			this._txtCommon_5.TabIndex = 11;
			this._txtCommon_5.Text = "";
			// this.// = "";
			// 
			// _lblCommon_10
			// 
			this._lblCommon_10.AllowDrop = true;
			this._lblCommon_10.BackColor = System.Drawing.Color.FromArgb(241, 244, 248);
			this._lblCommon_10.Text = "Amount";
			this._lblCommon_10.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_10.Location = new System.Drawing.Point(20, 139);
			this._lblCommon_10.Name = "_lblCommon_10";
			this._lblCommon_10.Size = new System.Drawing.Size(36, 13);
			this._lblCommon_10.TabIndex = 12;
			// 
			// _txtCommonDisplay_3
			// 
			this._txtCommonDisplay_3.AllowDrop = true;
			this._txtCommonDisplay_3.Location = new System.Drawing.Point(218, 45);
			this._txtCommonDisplay_3.Name = "_txtCommonDisplay_3";
			this._txtCommonDisplay_3.Size = new System.Drawing.Size(201, 19);
			this._txtCommonDisplay_3.TabIndex = 13;
			this._txtCommonDisplay_3.TabStop = false;
			// 
			// _txtCommonDisplay_2
			// 
			this._txtCommonDisplay_2.AllowDrop = true;
			this._txtCommonDisplay_2.Location = new System.Drawing.Point(218, 92);
			this._txtCommonDisplay_2.Name = "_txtCommonDisplay_2";
			this._txtCommonDisplay_2.Size = new System.Drawing.Size(201, 19);
			this._txtCommonDisplay_2.TabIndex = 14;
			this._txtCommonDisplay_2.TabStop = false;
			// 
			// _txtCommonDisplay_1
			// 
			this._txtCommonDisplay_1.AllowDrop = true;
			this._txtCommonDisplay_1.Location = new System.Drawing.Point(218, 114);
			this._txtCommonDisplay_1.Name = "_txtCommonDisplay_1";
			this._txtCommonDisplay_1.Size = new System.Drawing.Size(201, 19);
			this._txtCommonDisplay_1.TabIndex = 15;
			this._txtCommonDisplay_1.TabStop = false;
			// 
			// _txtCommonDisplay_0
			// 
			this._txtCommonDisplay_0.AllowDrop = true;
			this._txtCommonDisplay_0.Location = new System.Drawing.Point(218, 69);
			this._txtCommonDisplay_0.Name = "_txtCommonDisplay_0";
			this._txtCommonDisplay_0.Size = new System.Drawing.Size(201, 19);
			this._txtCommonDisplay_0.TabIndex = 16;
			this._txtCommonDisplay_0.TabStop = false;
			// 
			// _lblCommon_0
			// 
			this._lblCommon_0.AllowDrop = true;
			this._lblCommon_0.BackColor = System.Drawing.Color.FromArgb(241, 244, 248);
			this._lblCommon_0.Text = "Comments";
			this._lblCommon_0.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_0.Location = new System.Drawing.Point(20, 161);
			// // this._lblCommon_0.mLabelId = 1155;
			this._lblCommon_0.Name = "_lblCommon_0";
			this._lblCommon_0.Size = new System.Drawing.Size(49, 13);
			this._lblCommon_0.TabIndex = 17;
			// 
			// frmREExpense
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.FromArgb(202, 213, 223);
			this.ClientSize = new System.Drawing.Size(541, 327);
			this.Controls.Add(this.txtRemarks);
			this.Controls.Add(this._txtCommonNumber_0);
			this.Controls.Add(this._lblCommon_5);
			this.Controls.Add(this.txtCommonDate);
			this.Controls.Add(this._lblCommon_3);
			this.Controls.Add(this._txtCommon_2);
			this.Controls.Add(this._lblCommon_1);
			this.Controls.Add(this._txtCommon_1);
			this.Controls.Add(this._lblCommon_2);
			this.Controls.Add(this._txtCommon_3);
			this.Controls.Add(this._lblCommon_9);
			this.Controls.Add(this._txtCommon_5);
			this.Controls.Add(this._lblCommon_10);
			this.Controls.Add(this._txtCommonDisplay_3);
			this.Controls.Add(this._txtCommonDisplay_2);
			this.Controls.Add(this._txtCommonDisplay_1);
			this.Controls.Add(this._txtCommonDisplay_0);
			this.Controls.Add(this._lblCommon_0);
			//this.Icon = (System.Drawing.Icon) resources.GetObject("frmREExpense.Icon");
			this.Location = new System.Drawing.Point(113, 223);
			this.MaximizeBox = true;
			this.MinimizeBox = true;
			this.Name = "frmREExpense";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Property Expense";
			// this.Activated += new System.EventHandler(this.frmREExpense_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
			// this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
			this.ResumeLayout(false);
		}
		// 
		void InitializetxtCommonNumber()
		{
			this.txtCommonNumber = new System.Windows.Forms.TextBox[1];
			this.txtCommonNumber[0] = _txtCommonNumber_0;
		}
		void InitializetxtCommonDisplay()
		{
			this.txtCommonDisplay = new System.Windows.Forms.Label[4];
			this.txtCommonDisplay[3] = _txtCommonDisplay_3;
			this.txtCommonDisplay[2] = _txtCommonDisplay_2;
			this.txtCommonDisplay[1] = _txtCommonDisplay_1;
			this.txtCommonDisplay[0] = _txtCommonDisplay_0;
		}
		void InitializetxtCommon()
		{
			this.txtCommon = new System.Windows.Forms.TextBox[6];
			this.txtCommon[2] = _txtCommon_2;
			this.txtCommon[1] = _txtCommon_1;
			this.txtCommon[3] = _txtCommon_3;
			this.txtCommon[5] = _txtCommon_5;
		}
		void InitializelblCommon()
		{
			this.lblCommon = new System.Windows.Forms.Label[11];
			this.lblCommon[5] = _lblCommon_5;
			this.lblCommon[3] = _lblCommon_3;
			this.lblCommon[1] = _lblCommon_1;
			this.lblCommon[2] = _lblCommon_2;
			this.lblCommon[9] = _lblCommon_9;
			this.lblCommon[10] = _lblCommon_10;
			this.lblCommon[0] = _lblCommon_0;
		}
		#endregion
	}
}//ENDSHERE
