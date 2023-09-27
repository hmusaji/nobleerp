
namespace Xtreme
{
	partial class frmPayVehicle
	{

		#region "Upgrade Support "
		private static frmPayVehicle m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmPayVehicle DefInstance
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
		public static frmPayVehicle CreateInstance()
		{
			frmPayVehicle theInstance = new frmPayVehicle();
			
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
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "txtPlatNo", "_lblCommonLabel_5", "_lblCommonLabel_6", "txtVehicleCode", "_lblCommonLabel_2", "_lblCommonLabel_0", "_lblCommonLabel_1", "System.Windows.Forms.Label12", "txtComments", "_lblCommonLabel_18", "_lblCommonLabel_19", "txtInsExpireDate", "_lblCommonLabel_20", "txtInsIssueDate", "_lblCommonLabel_8", "txtEmpCode", "txtChasisNo", "txtModel", "txtMake", "txtInsuranceNumber", "_lblCommonLabel_16", "_lblCommonLabel_17", "txtEngineNo", "txtDesc", "txtInsCompName", "_lblCommonLabel_10", "_lblCommonLabel_21", "_lblCommonLabel_3", "txtColour", "_lblCommonLabel_4", "txtNo_Of_Passengers", "txtEmpName", "txtDesName", "txtDesCode", "txtDepName", "txtDepCode", "_lblCommonLabel_9", "_lblCommonLabel_11", "txtGatePassNo", "_lblCommonLabel_12", "txtADesc", "lblCommonLabel"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public System.Windows.Forms.TextBox txtPlatNo;
		private System.Windows.Forms.Label _lblCommonLabel_5;
		private System.Windows.Forms.Label _lblCommonLabel_6;
		public System.Windows.Forms.TextBox txtVehicleCode;
		private System.Windows.Forms.Label _lblCommonLabel_2;
		private System.Windows.Forms.Label _lblCommonLabel_0;
		private System.Windows.Forms.Label _lblCommonLabel_1;
		public System.Windows.Forms.Label Label12;
		public System.Windows.Forms.TextBox txtComments;
		private System.Windows.Forms.Label _lblCommonLabel_18;
		private System.Windows.Forms.Label _lblCommonLabel_19;
		public Syncfusion.WinForms.Input.SfDateTimeEdit txtInsExpireDate;
		private System.Windows.Forms.Label _lblCommonLabel_20;
		public Syncfusion.WinForms.Input.SfDateTimeEdit txtInsIssueDate;
		private System.Windows.Forms.Label _lblCommonLabel_8;
		public System.Windows.Forms.TextBox txtEmpCode;
		public System.Windows.Forms.TextBox txtChasisNo;
		public System.Windows.Forms.TextBox txtModel;
		public System.Windows.Forms.TextBox txtMake;
		public System.Windows.Forms.TextBox txtInsuranceNumber;
		private System.Windows.Forms.Label _lblCommonLabel_16;
		private System.Windows.Forms.Label _lblCommonLabel_17;
		public System.Windows.Forms.TextBox txtEngineNo;
		public System.Windows.Forms.TextBox txtDesc;
		public System.Windows.Forms.TextBox txtInsCompName;
		private System.Windows.Forms.Label _lblCommonLabel_10;
		private System.Windows.Forms.Label _lblCommonLabel_21;
		private System.Windows.Forms.Label _lblCommonLabel_3;
		public System.Windows.Forms.TextBox txtColour;
		private System.Windows.Forms.Label _lblCommonLabel_4;
		public System.Windows.Forms.TextBox txtNo_Of_Passengers;
		public System.Windows.Forms.Label txtEmpName;
		public System.Windows.Forms.Label txtDesName;
		public System.Windows.Forms.Label txtDesCode;
		public System.Windows.Forms.Label txtDepName;
		public System.Windows.Forms.Label txtDepCode;
		private System.Windows.Forms.Label _lblCommonLabel_9;
		private System.Windows.Forms.Label _lblCommonLabel_11;
		public System.Windows.Forms.TextBox txtGatePassNo;
		private System.Windows.Forms.Label _lblCommonLabel_12;
		public System.Windows.Forms.TextBox txtADesc;
		public System.Windows.Forms.Label[] lblCommonLabel = new System.Windows.Forms.Label[22];
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPayVehicle));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this.txtPlatNo = new System.Windows.Forms.TextBox();
			this._lblCommonLabel_5 = new System.Windows.Forms.Label();
			this._lblCommonLabel_6 = new System.Windows.Forms.Label();
			this.txtVehicleCode = new System.Windows.Forms.TextBox();
			this._lblCommonLabel_2 = new System.Windows.Forms.Label();
			this._lblCommonLabel_0 = new System.Windows.Forms.Label();
			this._lblCommonLabel_1 = new System.Windows.Forms.Label();
			this.Label12 = new System.Windows.Forms.Label();
			this.txtComments = new System.Windows.Forms.TextBox();
			this._lblCommonLabel_18 = new System.Windows.Forms.Label();
			this._lblCommonLabel_19 = new System.Windows.Forms.Label();
			this.txtInsExpireDate = new Syncfusion.WinForms.Input.SfDateTimeEdit();
			this._lblCommonLabel_20 = new System.Windows.Forms.Label();
			this.txtInsIssueDate = new Syncfusion.WinForms.Input.SfDateTimeEdit();
			this._lblCommonLabel_8 = new System.Windows.Forms.Label();
			this.txtEmpCode = new System.Windows.Forms.TextBox();
			this.txtChasisNo = new System.Windows.Forms.TextBox();
			this.txtModel = new System.Windows.Forms.TextBox();
			this.txtMake = new System.Windows.Forms.TextBox();
			this.txtInsuranceNumber = new System.Windows.Forms.TextBox();
			this._lblCommonLabel_16 = new System.Windows.Forms.Label();
			this._lblCommonLabel_17 = new System.Windows.Forms.Label();
			this.txtEngineNo = new System.Windows.Forms.TextBox();
			this.txtDesc = new System.Windows.Forms.TextBox();
			this.txtInsCompName = new System.Windows.Forms.TextBox();
			this._lblCommonLabel_10 = new System.Windows.Forms.Label();
			this._lblCommonLabel_21 = new System.Windows.Forms.Label();
			this._lblCommonLabel_3 = new System.Windows.Forms.Label();
			this.txtColour = new System.Windows.Forms.TextBox();
			this._lblCommonLabel_4 = new System.Windows.Forms.Label();
			this.txtNo_Of_Passengers = new System.Windows.Forms.TextBox();
			this.txtEmpName = new System.Windows.Forms.Label();
			this.txtDesName = new System.Windows.Forms.Label();
			this.txtDesCode = new System.Windows.Forms.Label();
			this.txtDepName = new System.Windows.Forms.Label();
			this.txtDepCode = new System.Windows.Forms.Label();
			this._lblCommonLabel_9 = new System.Windows.Forms.Label();
			this._lblCommonLabel_11 = new System.Windows.Forms.Label();
			this.txtGatePassNo = new System.Windows.Forms.TextBox();
			this._lblCommonLabel_12 = new System.Windows.Forms.Label();
			this.txtADesc = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// txtPlatNo
			// 
			//this.txtPlatNo.AllowDrop = true;
			this.txtPlatNo.BackColor = System.Drawing.Color.White;
			// // = false;
			this.txtPlatNo.ForeColor = System.Drawing.Color.Black;
			this.txtPlatNo.Location = new System.Drawing.Point(142, 156);
			// // = (System.Windows.Forms.TextBox.DropDownTypes) 0;
			this.txtPlatNo.Name = "txtPlatNo";
			this.txtPlatNo.Size = new System.Drawing.Size(102, 19);
			this.txtPlatNo.TabIndex = 1;
			this.txtPlatNo.Text = "";
			// 
			// _lblCommonLabel_5
			// 
			//this._lblCommonLabel_5.AllowDrop = true;
			this._lblCommonLabel_5.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_5.Text = "Vehicle Code";
			this._lblCommonLabel_5.Location = new System.Drawing.Point(8, 73);
			// // this._lblCommonLabel_5.mLabelId = 1801;
			this._lblCommonLabel_5.Name = "_lblCommonLabel_5";
			this._lblCommonLabel_5.Size = new System.Drawing.Size(64, 14);
			this._lblCommonLabel_5.TabIndex = 17;
			// 
			// _lblCommonLabel_6
			// 
			//this._lblCommonLabel_6.AllowDrop = true;
			this._lblCommonLabel_6.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_6.Text = "Insurance Company Name";
			this._lblCommonLabel_6.Location = new System.Drawing.Point(8, 284);
			// // this._lblCommonLabel_6.mLabelId = 1808;
			this._lblCommonLabel_6.Name = "_lblCommonLabel_6";
			this._lblCommonLabel_6.Size = new System.Drawing.Size(126, 14);
			this._lblCommonLabel_6.TabIndex = 18;
			// 
			// txtVehicleCode
			// 
			//this.txtVehicleCode.AllowDrop = true;
			this.txtVehicleCode.BackColor = System.Drawing.Color.White;
			this.txtVehicleCode.ForeColor = System.Drawing.Color.Black;
			this.txtVehicleCode.Location = new System.Drawing.Point(142, 71);
			// // = System.Windows.Forms.TextBox.DropDownTypes.ddtNextNumber;
			this.txtVehicleCode.Name = "txtVehicleCode";
			// this.txtVehicleCode.ShowButton = true;
			this.txtVehicleCode.Size = new System.Drawing.Size(102, 19);
			this.txtVehicleCode.TabIndex = 0;
			this.txtVehicleCode.Text = "";
			// this.//this.txtVehicleCode.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(//this.txtVehicleCode_DropButtonClick);
			// 
			// _lblCommonLabel_2
			// 
			//this._lblCommonLabel_2.AllowDrop = true;
			this._lblCommonLabel_2.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_2.Text = "Employee Code";
			this._lblCommonLabel_2.Location = new System.Drawing.Point(8, 94);
			// // this._lblCommonLabel_2.mLabelId = 236;
			this._lblCommonLabel_2.Name = "_lblCommonLabel_2";
			this._lblCommonLabel_2.Size = new System.Drawing.Size(74, 14);
			this._lblCommonLabel_2.TabIndex = 19;
			// 
			// _lblCommonLabel_0
			// 
			//this._lblCommonLabel_0.AllowDrop = true;
			this._lblCommonLabel_0.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_0.Text = "Department Code";
			this._lblCommonLabel_0.Location = new System.Drawing.Point(8, 115);
			// // this._lblCommonLabel_0.mLabelId = 1973;
			this._lblCommonLabel_0.Name = "_lblCommonLabel_0";
			this._lblCommonLabel_0.Size = new System.Drawing.Size(83, 14);
			this._lblCommonLabel_0.TabIndex = 20;
			// 
			// _lblCommonLabel_1
			// 
			//this._lblCommonLabel_1.AllowDrop = true;
			this._lblCommonLabel_1.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_1.Text = "Designation Code";
			this._lblCommonLabel_1.Location = new System.Drawing.Point(8, 136);
			// // this._lblCommonLabel_1.mLabelId = 1049;
			this._lblCommonLabel_1.Name = "_lblCommonLabel_1";
			this._lblCommonLabel_1.Size = new System.Drawing.Size(84, 14);
			this._lblCommonLabel_1.TabIndex = 21;
			// 
			// System.Windows.Forms.Label12
			// 
			//this.Label12.AllowDrop = true;
			this.Label12.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.Label12.Text = "Comments";
			this.Label12.Location = new System.Drawing.Point(8, 347);
			// this.Label12.mLabelId = 1851;
			this.Label12.Name="Label12";
			this.Label12.Size = new System.Drawing.Size(50, 14);
			this.Label12.TabIndex = 22;
			// 
			// txtComments
			// 
			//this.txtComments.AllowDrop = true;
			this.txtComments.BackColor = System.Drawing.Color.White;
			this.txtComments.ForeColor = System.Drawing.Color.Black;
			this.txtComments.Location = new System.Drawing.Point(142, 345);
			this.txtComments.MaxLength = 100;
			this.txtComments.Name = "txtComments";
			this.txtComments.Size = new System.Drawing.Size(408, 19);
			this.txtComments.TabIndex = 15;
			this.txtComments.Text = "";
			// 
			// _lblCommonLabel_18
			// 
			//this._lblCommonLabel_18.AllowDrop = true;
			this._lblCommonLabel_18.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_18.Text = "Chasis Number";
			this._lblCommonLabel_18.Location = new System.Drawing.Point(315, 157);
			// // this._lblCommonLabel_18.mLabelId = 1803;
			this._lblCommonLabel_18.Name = "_lblCommonLabel_18";
			this._lblCommonLabel_18.Size = new System.Drawing.Size(73, 14);
			this._lblCommonLabel_18.TabIndex = 23;
			// 
			// _lblCommonLabel_19
			// 
			//this._lblCommonLabel_19.AllowDrop = true;
			this._lblCommonLabel_19.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_19.Text = "Insurance Expire Date";
			this._lblCommonLabel_19.Location = new System.Drawing.Point(315, 261);
			// // this._lblCommonLabel_19.mLabelId = 1810;
			this._lblCommonLabel_19.Name = "_lblCommonLabel_19";
			this._lblCommonLabel_19.Size = new System.Drawing.Size(106, 14);
			this._lblCommonLabel_19.TabIndex = 24;
			// 
			// txtInsExpireDate
			// 
			//this.txtInsExpireDate.AllowDrop = true;
			// this.txtInsExpireDate.CheckDateRange = false;
			this.txtInsExpireDate.Location = new System.Drawing.Point(447, 259);
			// this.txtInsExpireDate.MaxDate = 2958465;
			// this.txtInsExpireDate.MinDate = 32874;
			this.txtInsExpireDate.Name = "txtInsExpireDate";
			this.txtInsExpireDate.Size = new System.Drawing.Size(102, 19);
			this.txtInsExpireDate.TabIndex = 11;
			// this.txtInsExpireDate.Text = "18/07/2001";
			// this.txtInsExpireDate.Value = 37090;
			// 
			// _lblCommonLabel_20
			// 
			//this._lblCommonLabel_20.AllowDrop = true;
			this._lblCommonLabel_20.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_20.Text = "Insurance Issue Date";
			this._lblCommonLabel_20.Location = new System.Drawing.Point(8, 261);
			// // this._lblCommonLabel_20.mLabelId = 1809;
			this._lblCommonLabel_20.Name = "_lblCommonLabel_20";
			this._lblCommonLabel_20.Size = new System.Drawing.Size(102, 14);
			this._lblCommonLabel_20.TabIndex = 25;
			// 
			// txtInsIssueDate
			// 
			//this.txtInsIssueDate.AllowDrop = true;
			// this.txtInsIssueDate.CheckDateRange = false;
			this.txtInsIssueDate.Location = new System.Drawing.Point(142, 259);
			// this.txtInsIssueDate.MaxDate = 2958465;
			// this.txtInsIssueDate.MinDate = 32874;
			this.txtInsIssueDate.Name = "txtInsIssueDate";
			this.txtInsIssueDate.Size = new System.Drawing.Size(102, 19);
			this.txtInsIssueDate.TabIndex = 10;
			// this.txtInsIssueDate.Text = "18/07/2001";
			// this.txtInsIssueDate.Value = 37090;
			// 
			// _lblCommonLabel_8
			// 
			//this._lblCommonLabel_8.AllowDrop = true;
			this._lblCommonLabel_8.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_8.Text = "Make";
			this._lblCommonLabel_8.Location = new System.Drawing.Point(315, 199);
			// // this._lblCommonLabel_8.mLabelId = 1807;
			this._lblCommonLabel_8.Name = "_lblCommonLabel_8";
			this._lblCommonLabel_8.Size = new System.Drawing.Size(25, 14);
			this._lblCommonLabel_8.TabIndex = 26;
			// 
			// txtEmpCode
			// 
			//this.txtEmpCode.AllowDrop = true;
			this.txtEmpCode.BackColor = System.Drawing.Color.FromArgb(239, 239, 239);
			this.txtEmpCode.Enabled = false;
			this.txtEmpCode.ForeColor = System.Drawing.Color.Black;
			this.txtEmpCode.Location = new System.Drawing.Point(142, 92);
			this.txtEmpCode.MaxLength = 10;
			this.txtEmpCode.Name = "txtEmpCode";
			// this.txtEmpCode.ShowButton = true;
			this.txtEmpCode.Size = new System.Drawing.Size(101, 19);
			this.txtEmpCode.TabIndex = 16;
			this.txtEmpCode.Text = "";
			// this.//this.txtEmpCode.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(//this.txtEmpCode_DropButtonClick);
			// this.txtEmpCode.Leave += new System.EventHandler(this.txtEmpCode_Leave);
			// 
			// txtChasisNo
			// 
			//this.txtChasisNo.AllowDrop = true;
			this.txtChasisNo.BackColor = System.Drawing.Color.White;
			this.txtChasisNo.ForeColor = System.Drawing.Color.Black;
			this.txtChasisNo.Location = new System.Drawing.Point(449, 155);
			this.txtChasisNo.MaxLength = 20;
			this.txtChasisNo.Name = "txtChasisNo";
			this.txtChasisNo.Size = new System.Drawing.Size(102, 19);
			this.txtChasisNo.TabIndex = 2;
			this.txtChasisNo.Text = "";
			// 
			// txtModel
			// 
			//this.txtModel.AllowDrop = true;
			this.txtModel.BackColor = System.Drawing.Color.White;
			// this.txtModel.bolNumericOnly = true;
			this.txtModel.ForeColor = System.Drawing.Color.Black;
			this.txtModel.Location = new System.Drawing.Point(142, 176);
			this.txtModel.MaxLength = 20;
			this.txtModel.Name = "txtModel";
			this.txtModel.Size = new System.Drawing.Size(102, 19);
			this.txtModel.TabIndex = 3;
			this.txtModel.Text = "";
			// 
			// txtMake
			// 
			//this.txtMake.AllowDrop = true;
			this.txtMake.BackColor = System.Drawing.Color.White;
			this.txtMake.ForeColor = System.Drawing.Color.Black;
			this.txtMake.Location = new System.Drawing.Point(449, 197);
			this.txtMake.MaxLength = 20;
			this.txtMake.Name = "txtMake";
			this.txtMake.Size = new System.Drawing.Size(102, 19);
			this.txtMake.TabIndex = 6;
			this.txtMake.Text = "";
			// 
			// txtInsuranceNumber
			// 
			//this.txtInsuranceNumber.AllowDrop = true;
			this.txtInsuranceNumber.BackColor = System.Drawing.Color.White;
			this.txtInsuranceNumber.ForeColor = System.Drawing.Color.Black;
			this.txtInsuranceNumber.Location = new System.Drawing.Point(142, 239);
			this.txtInsuranceNumber.MaxLength = 20;
			this.txtInsuranceNumber.Name = "txtInsuranceNumber";
			this.txtInsuranceNumber.Size = new System.Drawing.Size(102, 19);
			this.txtInsuranceNumber.TabIndex = 9;
			this.txtInsuranceNumber.Text = "";
			// 
			// _lblCommonLabel_16
			// 
			//this._lblCommonLabel_16.AllowDrop = true;
			this._lblCommonLabel_16.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_16.Text = "Description(ENG)";
			this._lblCommonLabel_16.Location = new System.Drawing.Point(8, 304);
			this._lblCommonLabel_16.Name = "_lblCommonLabel_16";
			this._lblCommonLabel_16.Size = new System.Drawing.Size(83, 14);
			this._lblCommonLabel_16.TabIndex = 27;
			// 
			// _lblCommonLabel_17
			// 
			//this._lblCommonLabel_17.AllowDrop = true;
			this._lblCommonLabel_17.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_17.Text = "Engine Number";
			this._lblCommonLabel_17.Location = new System.Drawing.Point(315, 178);
			// // this._lblCommonLabel_17.mLabelId = 1804;
			this._lblCommonLabel_17.Name = "_lblCommonLabel_17";
			this._lblCommonLabel_17.Size = new System.Drawing.Size(72, 14);
			this._lblCommonLabel_17.TabIndex = 28;
			// 
			// txtEngineNo
			// 
			//this.txtEngineNo.AllowDrop = true;
			this.txtEngineNo.BackColor = System.Drawing.Color.White;
			this.txtEngineNo.ForeColor = System.Drawing.Color.Black;
			this.txtEngineNo.Location = new System.Drawing.Point(449, 176);
			this.txtEngineNo.MaxLength = 20;
			this.txtEngineNo.Name = "txtEngineNo";
			this.txtEngineNo.Size = new System.Drawing.Size(102, 19);
			this.txtEngineNo.TabIndex = 4;
			this.txtEngineNo.Text = "";
			// 
			// txtDesc
			// 
			//this.txtDesc.AllowDrop = true;
			this.txtDesc.BackColor = System.Drawing.Color.White;
			this.txtDesc.ForeColor = System.Drawing.Color.Black;
			this.txtDesc.Location = new System.Drawing.Point(142, 302);
			this.txtDesc.MaxLength = 20;
			this.txtDesc.Name = "txtDesc";
			this.txtDesc.Size = new System.Drawing.Size(408, 19);
			this.txtDesc.TabIndex = 13;
			this.txtDesc.Text = "";
			// 
			// txtInsCompName
			// 
			//this.txtInsCompName.AllowDrop = true;
			this.txtInsCompName.BackColor = System.Drawing.Color.White;
			this.txtInsCompName.ForeColor = System.Drawing.Color.Black;
			this.txtInsCompName.Location = new System.Drawing.Point(142, 281);
			this.txtInsCompName.MaxLength = 20;
			this.txtInsCompName.Name = "txtInsCompName";
			this.txtInsCompName.Size = new System.Drawing.Size(408, 19);
			this.txtInsCompName.TabIndex = 12;
			this.txtInsCompName.Text = "";
			// 
			// _lblCommonLabel_10
			// 
			//this._lblCommonLabel_10.AllowDrop = true;
			this._lblCommonLabel_10.BackColor = System.Drawing.Color.FromArgb(237, 231, 235);
			this._lblCommonLabel_10.Text = "Model";
			this._lblCommonLabel_10.Location = new System.Drawing.Point(8, 179);
			// // this._lblCommonLabel_10.mLabelId = 1805;
			this._lblCommonLabel_10.Name = "_lblCommonLabel_10";
			this._lblCommonLabel_10.Size = new System.Drawing.Size(28, 14);
			this._lblCommonLabel_10.TabIndex = 29;
			// 
			// _lblCommonLabel_21
			// 
			//this._lblCommonLabel_21.AllowDrop = true;
			this._lblCommonLabel_21.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_21.Text = "Insurance Number";
			this._lblCommonLabel_21.Location = new System.Drawing.Point(8, 241);
			// // this._lblCommonLabel_21.mLabelId = 1806;
			this._lblCommonLabel_21.Name = "_lblCommonLabel_21";
			this._lblCommonLabel_21.Size = new System.Drawing.Size(88, 14);
			this._lblCommonLabel_21.TabIndex = 30;
			// 
			// _lblCommonLabel_3
			// 
			//this._lblCommonLabel_3.AllowDrop = true;
			this._lblCommonLabel_3.BackColor = System.Drawing.Color.FromArgb(237, 231, 235);
			this._lblCommonLabel_3.Text = "Colour";
			this._lblCommonLabel_3.Location = new System.Drawing.Point(8, 200);
			// // this._lblCommonLabel_3.mLabelId = 1903;
			this._lblCommonLabel_3.Name = "_lblCommonLabel_3";
			this._lblCommonLabel_3.Size = new System.Drawing.Size(31, 14);
			this._lblCommonLabel_3.TabIndex = 31;
			// 
			// txtColour
			// 
			//this.txtColour.AllowDrop = true;
			this.txtColour.BackColor = System.Drawing.Color.White;
			this.txtColour.ForeColor = System.Drawing.Color.Black;
			this.txtColour.Location = new System.Drawing.Point(142, 197);
			this.txtColour.MaxLength = 20;
			this.txtColour.Name = "txtColour";
			this.txtColour.Size = new System.Drawing.Size(102, 19);
			this.txtColour.TabIndex = 5;
			this.txtColour.Text = "";
			// 
			// _lblCommonLabel_4
			// 
			//this._lblCommonLabel_4.AllowDrop = true;
			this._lblCommonLabel_4.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_4.Text = "No Of Passengers";
			this._lblCommonLabel_4.Location = new System.Drawing.Point(8, 220);
			// // this._lblCommonLabel_4.mLabelId = 1904;
			this._lblCommonLabel_4.Name = "_lblCommonLabel_4";
			this._lblCommonLabel_4.Size = new System.Drawing.Size(89, 14);
			this._lblCommonLabel_4.TabIndex = 32;
			// 
			// txtNo_Of_Passengers
			// 
			//this.txtNo_Of_Passengers.AllowDrop = true;
			this.txtNo_Of_Passengers.BackColor = System.Drawing.Color.White;
			this.txtNo_Of_Passengers.ForeColor = System.Drawing.Color.Black;
			this.txtNo_Of_Passengers.Location = new System.Drawing.Point(142, 218);
			this.txtNo_Of_Passengers.MaxLength = 20;
			this.txtNo_Of_Passengers.Name = "txtNo_Of_Passengers";
			this.txtNo_Of_Passengers.Size = new System.Drawing.Size(102, 19);
			this.txtNo_Of_Passengers.TabIndex = 7;
			this.txtNo_Of_Passengers.Text = "";
			// 
			// txtEmpName
			// 
			//this.txtEmpName.AllowDrop = true;
			this.txtEmpName.Enabled = false;
			this.txtEmpName.Location = new System.Drawing.Point(245, 92);
			this.txtEmpName.Name = "txtEmpName";
			this.txtEmpName.Size = new System.Drawing.Size(308, 19);
			this.txtEmpName.TabIndex = 33;
			// 
			// txtDesName
			// 
			//this.txtDesName.AllowDrop = true;
			this.txtDesName.Enabled = false;
			this.txtDesName.Location = new System.Drawing.Point(245, 134);
			this.txtDesName.Name = "txtDesName";
			this.txtDesName.Size = new System.Drawing.Size(308, 19);
			this.txtDesName.TabIndex = 34;
			// 
			// txtDesCode
			// 
			//this.txtDesCode.AllowDrop = true;
			this.txtDesCode.Enabled = false;
			this.txtDesCode.Location = new System.Drawing.Point(142, 134);
			this.txtDesCode.Name = "txtDesCode";
			this.txtDesCode.Size = new System.Drawing.Size(101, 19);
			this.txtDesCode.TabIndex = 35;
			// 
			// txtDepName
			// 
			//this.txtDepName.AllowDrop = true;
			this.txtDepName.Enabled = false;
			this.txtDepName.Location = new System.Drawing.Point(245, 112);
			this.txtDepName.Name = "txtDepName";
			this.txtDepName.Size = new System.Drawing.Size(308, 19);
			this.txtDepName.TabIndex = 36;
			// 
			// txtDepCode
			// 
			//this.txtDepCode.AllowDrop = true;
			this.txtDepCode.Enabled = false;
			this.txtDepCode.Location = new System.Drawing.Point(142, 113);
			this.txtDepCode.Name = "txtDepCode";
			this.txtDepCode.Size = new System.Drawing.Size(101, 19);
			this.txtDepCode.TabIndex = 37;
			// 
			// _lblCommonLabel_9
			// 
			//this._lblCommonLabel_9.AllowDrop = true;
			this._lblCommonLabel_9.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_9.Text = "Plate No";
			this._lblCommonLabel_9.Location = new System.Drawing.Point(8, 158);
			this._lblCommonLabel_9.Name = "_lblCommonLabel_9";
			this._lblCommonLabel_9.Size = new System.Drawing.Size(39, 14);
			this._lblCommonLabel_9.TabIndex = 38;
			// 
			// _lblCommonLabel_11
			// 
			//this._lblCommonLabel_11.AllowDrop = true;
			this._lblCommonLabel_11.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_11.Text = "Gate Pass No";
			this._lblCommonLabel_11.Location = new System.Drawing.Point(315, 221);
			this._lblCommonLabel_11.Name = "_lblCommonLabel_11";
			this._lblCommonLabel_11.Size = new System.Drawing.Size(66, 14);
			this._lblCommonLabel_11.TabIndex = 39;
			// 
			// txtGatePassNo
			// 
			//this.txtGatePassNo.AllowDrop = true;
			this.txtGatePassNo.BackColor = System.Drawing.Color.White;
			this.txtGatePassNo.ForeColor = System.Drawing.Color.Black;
			this.txtGatePassNo.Location = new System.Drawing.Point(449, 219);
			this.txtGatePassNo.MaxLength = 20;
			this.txtGatePassNo.Name = "txtGatePassNo";
			this.txtGatePassNo.Size = new System.Drawing.Size(102, 19);
			this.txtGatePassNo.TabIndex = 8;
			this.txtGatePassNo.Text = "";
			// 
			// _lblCommonLabel_12
			// 
			//this._lblCommonLabel_12.AllowDrop = true;
			this._lblCommonLabel_12.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_12.Text = "Description(ARB)";
			this._lblCommonLabel_12.Location = new System.Drawing.Point(9, 326);
			this._lblCommonLabel_12.Name = "_lblCommonLabel_12";
			this._lblCommonLabel_12.Size = new System.Drawing.Size(84, 14);
			this._lblCommonLabel_12.TabIndex = 40;
			// 
			// txtADesc
			// 
			//this.txtADesc.AllowDrop = true;
			this.txtADesc.BackColor = System.Drawing.Color.White;
			this.txtADesc.ForeColor = System.Drawing.Color.Black;
			this.txtADesc.Location = new System.Drawing.Point(142, 324);
			this.txtADesc.MaxLength = 20;
			this.txtADesc.Name = "txtADesc";
			this.txtADesc.Size = new System.Drawing.Size(408, 19);
			this.txtADesc.TabIndex = 14;
			this.txtADesc.Text = "";
			// 
			// frmPayVehicle
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.ClientSize = new System.Drawing.Size(557, 371);
			this.Controls.Add(this.txtPlatNo);
			this.Controls.Add(this._lblCommonLabel_5);
			this.Controls.Add(this._lblCommonLabel_6);
			this.Controls.Add(this.txtVehicleCode);
			this.Controls.Add(this._lblCommonLabel_2);
			this.Controls.Add(this._lblCommonLabel_0);
			this.Controls.Add(this._lblCommonLabel_1);
			this.Controls.Add(this.Label12);
			this.Controls.Add(this.txtComments);
			this.Controls.Add(this._lblCommonLabel_18);
			this.Controls.Add(this._lblCommonLabel_19);
			this.Controls.Add(this.txtInsExpireDate);
			this.Controls.Add(this._lblCommonLabel_20);
			this.Controls.Add(this.txtInsIssueDate);
			this.Controls.Add(this._lblCommonLabel_8);
			this.Controls.Add(this.txtEmpCode);
			this.Controls.Add(this.txtChasisNo);
			this.Controls.Add(this.txtModel);
			this.Controls.Add(this.txtMake);
			this.Controls.Add(this.txtInsuranceNumber);
			this.Controls.Add(this._lblCommonLabel_16);
			this.Controls.Add(this._lblCommonLabel_17);
			this.Controls.Add(this.txtEngineNo);
			this.Controls.Add(this.txtDesc);
			this.Controls.Add(this.txtInsCompName);
			this.Controls.Add(this._lblCommonLabel_10);
			this.Controls.Add(this._lblCommonLabel_21);
			this.Controls.Add(this._lblCommonLabel_3);
			this.Controls.Add(this.txtColour);
			this.Controls.Add(this._lblCommonLabel_4);
			this.Controls.Add(this.txtNo_Of_Passengers);
			this.Controls.Add(this.txtEmpName);
			this.Controls.Add(this.txtDesName);
			this.Controls.Add(this.txtDesCode);
			this.Controls.Add(this.txtDepName);
			this.Controls.Add(this.txtDepCode);
			this.Controls.Add(this._lblCommonLabel_9);
			this.Controls.Add(this._lblCommonLabel_11);
			this.Controls.Add(this.txtGatePassNo);
			this.Controls.Add(this._lblCommonLabel_12);
			this.Controls.Add(this.txtADesc);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			//this.Icon = (System.Drawing.Icon) resources.GetObject("frmPayVehicle.Icon");
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(153, 115);
			this.MaximizeBox = true;
			this.MinimizeBox = true;
			this.Name = "frmPayVehicle";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Vehicle";
			// this.Activated += new System.EventHandler(this.frmPayVehicle_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
			// this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
			this.ResumeLayout(false);
		}
		// 
		void InitializelblCommonLabel()
		{
			this.lblCommonLabel = new System.Windows.Forms.Label[22];
			this.lblCommonLabel[5] = _lblCommonLabel_5;
			this.lblCommonLabel[6] = _lblCommonLabel_6;
			this.lblCommonLabel[2] = _lblCommonLabel_2;
			this.lblCommonLabel[0] = _lblCommonLabel_0;
			this.lblCommonLabel[1] = _lblCommonLabel_1;
			this.lblCommonLabel[18] = _lblCommonLabel_18;
			this.lblCommonLabel[19] = _lblCommonLabel_19;
			this.lblCommonLabel[20] = _lblCommonLabel_20;
			this.lblCommonLabel[8] = _lblCommonLabel_8;
			this.lblCommonLabel[16] = _lblCommonLabel_16;
			this.lblCommonLabel[17] = _lblCommonLabel_17;
			this.lblCommonLabel[10] = _lblCommonLabel_10;
			this.lblCommonLabel[21] = _lblCommonLabel_21;
			this.lblCommonLabel[3] = _lblCommonLabel_3;
			this.lblCommonLabel[4] = _lblCommonLabel_4;
			this.lblCommonLabel[9] = _lblCommonLabel_9;
			this.lblCommonLabel[11] = _lblCommonLabel_11;
			this.lblCommonLabel[12] = _lblCommonLabel_12;
		}
		#endregion
	}
}//ENDSHERE
