
namespace Xtreme
{
	partial class frmPayVehicleTrans
	{

		#region "Upgrade Support "
		private static frmPayVehicleTrans m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmPayVehicleTrans DefInstance
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
		public static frmPayVehicleTrans CreateInstance()
		{
			frmPayVehicleTrans theInstance = new frmPayVehicleTrans();
			
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
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "txtNKMPerMonth", "_lblCommonLabel_6", "txtVoucherDate", "_lblCommonLabel_5", "txtVehicleTransNo", "_lblCommonLabel_0", "txtVehicleCode", "System.Windows.Forms.Label12", "txtComments", "_lblCommonLabel_2", "txtEmpCode", "txtEmpName", "_lblCommonLabel_1", "txtEmpCodeNew", "txtEmpNameNew", "System.Windows.Forms.Label1", "lblCommonLabel"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public System.Windows.Forms.TextBox txtNKMPerMonth;
		private System.Windows.Forms.Label _lblCommonLabel_6;
		public Syncfusion.WinForms.Input.SfDateTimeEdit txtVoucherDate;
		private System.Windows.Forms.Label _lblCommonLabel_5;
		public System.Windows.Forms.TextBox txtVehicleTransNo;
		private System.Windows.Forms.Label _lblCommonLabel_0;
		public System.Windows.Forms.TextBox txtVehicleCode;
		public System.Windows.Forms.Label Label12;
		public System.Windows.Forms.TextBox txtComments;
		private System.Windows.Forms.Label _lblCommonLabel_2;
		public System.Windows.Forms.TextBox txtEmpCode;
		public System.Windows.Forms.Label txtEmpName;
		private System.Windows.Forms.Label _lblCommonLabel_1;
		public System.Windows.Forms.TextBox txtEmpCodeNew;
		public System.Windows.Forms.Label txtEmpNameNew;
		public System.Windows.Forms.Label Label1;
		public System.Windows.Forms.Label[] lblCommonLabel = new System.Windows.Forms.Label[7];
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPayVehicleTrans));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this.txtNKMPerMonth = new System.Windows.Forms.TextBox();
			this._lblCommonLabel_6 = new System.Windows.Forms.Label();
			this.txtVoucherDate = new Syncfusion.WinForms.Input.SfDateTimeEdit();
			this._lblCommonLabel_5 = new System.Windows.Forms.Label();
			this.txtVehicleTransNo = new System.Windows.Forms.TextBox();
			this._lblCommonLabel_0 = new System.Windows.Forms.Label();
			this.txtVehicleCode = new System.Windows.Forms.TextBox();
			this.Label12 = new System.Windows.Forms.Label();
			this.txtComments = new System.Windows.Forms.TextBox();
			this._lblCommonLabel_2 = new System.Windows.Forms.Label();
			this.txtEmpCode = new System.Windows.Forms.TextBox();
			this.txtEmpName = new System.Windows.Forms.Label();
			this._lblCommonLabel_1 = new System.Windows.Forms.Label();
			this.txtEmpCodeNew = new System.Windows.Forms.TextBox();
			this.txtEmpNameNew = new System.Windows.Forms.Label();
			this.Label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// txtNKMPerMonth
			// 
			//this.txtNKMPerMonth.AllowDrop = true;
			// this.txtNKMPerMonth.DisplayFormat = "####0.000###;;0.000;0.000";
			this.txtNKMPerMonth.ForeColor = System.Drawing.SystemColors.WindowText;
			// this.txtNKMPerMonth.Format = "###########0.000";
			this.txtNKMPerMonth.Location = new System.Drawing.Point(123, 138);
			this.txtNKMPerMonth.Name = "txtNKMPerMonth";
			this.txtNKMPerMonth.Size = new System.Drawing.Size(100, 19);
			this.txtNKMPerMonth.TabIndex = 15;
			this.txtNKMPerMonth.Text = "0.000";
			// 
			// _lblCommonLabel_6
			// 
			//this._lblCommonLabel_6.AllowDrop = true;
			this._lblCommonLabel_6.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_6.Text = "Transaction Date";
			this._lblCommonLabel_6.Location = new System.Drawing.Point(254, 52);
			// // this._lblCommonLabel_6.mLabelId = 1233;
			this._lblCommonLabel_6.Name = "_lblCommonLabel_6";
			this._lblCommonLabel_6.Size = new System.Drawing.Size(82, 14);
			this._lblCommonLabel_6.TabIndex = 6;
			// 
			// txtVoucherDate
			// 
			//this.txtVoucherDate.AllowDrop = true;
			// this.txtVoucherDate.CheckDateRange = false;
			this.txtVoucherDate.Location = new System.Drawing.Point(364, 50);
			// this.txtVoucherDate.MaxDate = 2958465;
			// this.txtVoucherDate.MinDate = 32874;
			this.txtVoucherDate.Name = "txtVoucherDate";
			this.txtVoucherDate.Size = new System.Drawing.Size(102, 19);
			this.txtVoucherDate.TabIndex = 1;
			// this.txtVoucherDate.Text = "18/07/2001";
			// this.txtVoucherDate.Value = 37090;
			// 
			// _lblCommonLabel_5
			// 
			//this._lblCommonLabel_5.AllowDrop = true;
			this._lblCommonLabel_5.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_5.Text = "Transaction No.";
			this._lblCommonLabel_5.Location = new System.Drawing.Point(4, 52);
			// // this._lblCommonLabel_5.mLabelId = 1232;
			this._lblCommonLabel_5.Name = "_lblCommonLabel_5";
			this._lblCommonLabel_5.Size = new System.Drawing.Size(76, 14);
			this._lblCommonLabel_5.TabIndex = 7;
			// 
			// txtVehicleTransNo
			// 
			//this.txtVehicleTransNo.AllowDrop = true;
			this.txtVehicleTransNo.BackColor = System.Drawing.Color.White;
			// this.txtVehicleTransNo.bolNumericOnly = true;
			this.txtVehicleTransNo.ForeColor = System.Drawing.Color.Black;
			this.txtVehicleTransNo.Location = new System.Drawing.Point(122, 50);
			// // = System.Windows.Forms.TextBox.DropDownTypes.ddtNextNumber;
			this.txtVehicleTransNo.Name = "txtVehicleTransNo";
			// this.txtVehicleTransNo.ShowButton = true;
			this.txtVehicleTransNo.Size = new System.Drawing.Size(102, 19);
			this.txtVehicleTransNo.TabIndex = 0;
			this.txtVehicleTransNo.Text = "";
			// this.//this.txtVehicleTransNo.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(//this.txtVehicleTransNo_DropButtonClick);
			// 
			// _lblCommonLabel_0
			// 
			//this._lblCommonLabel_0.AllowDrop = true;
			this._lblCommonLabel_0.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_0.Text = "Vehicle Code";
			this._lblCommonLabel_0.Location = new System.Drawing.Point(4, 74);
			// // this._lblCommonLabel_0.mLabelId = 1801;
			this._lblCommonLabel_0.Name = "_lblCommonLabel_0";
			this._lblCommonLabel_0.Size = new System.Drawing.Size(64, 14);
			this._lblCommonLabel_0.TabIndex = 8;
			// 
			// txtVehicleCode
			// 
			//this.txtVehicleCode.AllowDrop = true;
			this.txtVehicleCode.BackColor = System.Drawing.Color.White;
			this.txtVehicleCode.ForeColor = System.Drawing.Color.Black;
			this.txtVehicleCode.Location = new System.Drawing.Point(122, 71);
			// // = System.Windows.Forms.TextBox.DropDownTypes.ddtNextNumber;
			this.txtVehicleCode.Name = "txtVehicleCode";
			// this.txtVehicleCode.ShowButton = true;
			this.txtVehicleCode.Size = new System.Drawing.Size(102, 19);
			this.txtVehicleCode.TabIndex = 2;
			this.txtVehicleCode.Text = "";
			// this.//this.txtVehicleCode.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(//this.txtVehicleCode_DropButtonClick);
			// this.txtVehicleCode.Leave += new System.EventHandler(this.txtVehicleCode_Leave);
			// 
			// System.Windows.Forms.Label12
			// 
			//this.Label12.AllowDrop = true;
			this.Label12.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.Label12.Text = "Comments";
			this.Label12.Location = new System.Drawing.Point(4, 163);
			// this.Label12.mLabelId = 1851;
			this.Label12.Name="Label12";
			this.Label12.Size = new System.Drawing.Size(50, 14);
			this.Label12.TabIndex = 9;
			// 
			// txtComments
			// 
			//this.txtComments.AllowDrop = true;
			this.txtComments.BackColor = System.Drawing.Color.White;
			this.txtComments.ForeColor = System.Drawing.Color.Black;
			this.txtComments.Location = new System.Drawing.Point(122, 160);
			this.txtComments.MaxLength = 100;
			this.txtComments.Name = "txtComments";
			this.txtComments.Size = new System.Drawing.Size(372, 19);
			this.txtComments.TabIndex = 5;
			this.txtComments.Text = "";
			// 
			// _lblCommonLabel_2
			// 
			//this._lblCommonLabel_2.AllowDrop = true;
			this._lblCommonLabel_2.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_2.Text = "Employee Code";
			this._lblCommonLabel_2.Location = new System.Drawing.Point(4, 94);
			// // this._lblCommonLabel_2.mLabelId = 2074;
			this._lblCommonLabel_2.Name = "_lblCommonLabel_2";
			this._lblCommonLabel_2.Size = new System.Drawing.Size(74, 14);
			this._lblCommonLabel_2.TabIndex = 10;
			// 
			// txtEmpCode
			// 
			//this.txtEmpCode.AllowDrop = true;
			this.txtEmpCode.BackColor = System.Drawing.Color.White;
			this.txtEmpCode.ForeColor = System.Drawing.Color.Black;
			this.txtEmpCode.Location = new System.Drawing.Point(122, 92);
			this.txtEmpCode.MaxLength = 10;
			this.txtEmpCode.Name = "txtEmpCode";
			// this.txtEmpCode.ShowButton = true;
			this.txtEmpCode.Size = new System.Drawing.Size(101, 19);
			this.txtEmpCode.TabIndex = 3;
			this.txtEmpCode.TabStop = false;
			this.txtEmpCode.Text = "";
			// this.//this.txtEmpCode.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(//this.txtEmpCode_DropButtonClick);
			// 
			// txtEmpName
			// 
			//this.txtEmpName.AllowDrop = true;
			this.txtEmpName.Enabled = false;
			this.txtEmpName.Location = new System.Drawing.Point(225, 92);
			this.txtEmpName.Name = "txtEmpName";
			this.txtEmpName.Size = new System.Drawing.Size(269, 19);
			this.txtEmpName.TabIndex = 11;
			this.txtEmpName.TabStop = false;
			// 
			// _lblCommonLabel_1
			// 
			//this._lblCommonLabel_1.AllowDrop = true;
			this._lblCommonLabel_1.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_1.Text = "Employee Code";
			this._lblCommonLabel_1.Location = new System.Drawing.Point(4, 116);
			// // this._lblCommonLabel_1.mLabelId = 2076;
			this._lblCommonLabel_1.Name = "_lblCommonLabel_1";
			this._lblCommonLabel_1.Size = new System.Drawing.Size(74, 14);
			this._lblCommonLabel_1.TabIndex = 12;
			// 
			// txtEmpCodeNew
			// 
			//this.txtEmpCodeNew.AllowDrop = true;
			this.txtEmpCodeNew.BackColor = System.Drawing.Color.White;
			this.txtEmpCodeNew.ForeColor = System.Drawing.Color.Black;
			this.txtEmpCodeNew.Location = new System.Drawing.Point(122, 114);
			this.txtEmpCodeNew.MaxLength = 10;
			this.txtEmpCodeNew.Name = "txtEmpCodeNew";
			// this.txtEmpCodeNew.ShowButton = true;
			this.txtEmpCodeNew.Size = new System.Drawing.Size(101, 19);
			this.txtEmpCodeNew.TabIndex = 4;
			this.txtEmpCodeNew.Text = "";
			// this.//this.txtEmpCodeNew.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(//this.txtEmpCodeNew_DropButtonClick);
			// 
			// txtEmpNameNew
			// 
			//this.txtEmpNameNew.AllowDrop = true;
			this.txtEmpNameNew.Enabled = false;
			this.txtEmpNameNew.Location = new System.Drawing.Point(225, 114);
			this.txtEmpNameNew.Name = "txtEmpNameNew";
			this.txtEmpNameNew.Size = new System.Drawing.Size(269, 19);
			this.txtEmpNameNew.TabIndex = 13;
			this.txtEmpNameNew.TabStop = false;
			// 
			// System.Windows.Forms.Label1
			// 
			//this.Label1.AllowDrop = true;
			this.Label1.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.Label1.Text = "Kilometer";
			this.Label1.Location = new System.Drawing.Point(3, 140);
			this.Label1.Name="Label1";
			this.Label1.Size = new System.Drawing.Size(44, 14);
			this.Label1.TabIndex = 14;
			// 
			// frmPayVehicleTrans
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.ClientSize = new System.Drawing.Size(500, 189);
			this.Controls.Add(this.txtNKMPerMonth);
			this.Controls.Add(this._lblCommonLabel_6);
			this.Controls.Add(this.txtVoucherDate);
			this.Controls.Add(this._lblCommonLabel_5);
			this.Controls.Add(this.txtVehicleTransNo);
			this.Controls.Add(this._lblCommonLabel_0);
			this.Controls.Add(this.txtVehicleCode);
			this.Controls.Add(this.Label12);
			this.Controls.Add(this.txtComments);
			this.Controls.Add(this._lblCommonLabel_2);
			this.Controls.Add(this.txtEmpCode);
			this.Controls.Add(this.txtEmpName);
			this.Controls.Add(this._lblCommonLabel_1);
			this.Controls.Add(this.txtEmpCodeNew);
			this.Controls.Add(this.txtEmpNameNew);
			this.Controls.Add(this.Label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			//this.Icon = (System.Drawing.Icon) resources.GetObject("frmPayVehicleTrans.Icon");
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(304, 155);
			this.MaximizeBox = true;
			this.MinimizeBox = true;
			this.Name = "frmPayVehicleTrans";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Vehicle Transaction";
			// this.Activated += new System.EventHandler(this.frmPayVehicleTrans_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
			// this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
			this.ResumeLayout(false);
		}
		// 
		void InitializelblCommonLabel()
		{
			this.lblCommonLabel = new System.Windows.Forms.Label[7];
			this.lblCommonLabel[6] = _lblCommonLabel_6;
			this.lblCommonLabel[5] = _lblCommonLabel_5;
			this.lblCommonLabel[0] = _lblCommonLabel_0;
			this.lblCommonLabel[2] = _lblCommonLabel_2;
			this.lblCommonLabel[1] = _lblCommonLabel_1;
		}
		#endregion
	}
}//ENDSHERE
