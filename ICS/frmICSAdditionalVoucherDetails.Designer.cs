
namespace Xtreme
{
	partial class frmICSAdditionalVoucherDetails
	{

		#region "Upgrade Support "
		private static frmICSAdditionalVoucherDetails m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmICSAdditionalVoucherDetails DefInstance
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
		public static frmICSAdditionalVoucherDetails CreateInstance()
		{
			frmICSAdditionalVoucherDetails theInstance = new frmICSAdditionalVoucherDetails();
			
			return theInstance;
		}
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "_UCOkCancel1_14", "cmdItalic", "cmdBold", "cmdColor", "cmdUnderline", "System.Windows.Forms.Label3", "_comCommon_0", "_lblCommonLabel_22", "_comCommon_6", "_lblCommonLabel_23", "_comCommon_7", "_lblCommonLabel_24", "_comCommon_8", "_lblCommonLabel_25", "_comCommon_9", "_lblCommonLabel_26", "_comCommon_11", "_lblCommonLabel_28", "_comCommon_12", "_lblCommonLabel_29", "_comCommon_13", "_lblCommonLabel_30", "_comCommon_14", "_lblCommonLabel_31", "txtNarration2", "_fraMasterInformation_2", "_comCommon_1", "txtCreditCardDate", "_lblCommonLabel_7", "_lblCommonLabel_6", "lblRefrenceOrderDate", "_lblCommonLabel_8", "lblChequeDate", "lblCreditCardDate", "txtBlockNo", "txtCountry", "txtRefrenceOrderDate", "txtChequeDate", "txtCreditCardNo", "txtPhone", "txtStreetNo", "txtCity", "txtRefOrderNo", "txtChequeNo", "_lblCommonLabel_5", "_lblCommonLabel_1", "_lblCommonLabel_2", "_lblCommonLabel_4", "_lblCommonLabel_9", "_lblCommonLabel_10", "_lblCommonLabel_11", "_lblCommonLabel_3", "_lblCommonLabel_0", "System.Windows.Forms.Label1", "txtDrawnOnBank", "_comCommon_2", "_lblCommonLabel_12", "System.Windows.Forms.Label2", "txtShipmentNo", "_comCommon_3", "_lblCommonLabel_13", "_comCommon_4", "_lblCommonLabel_14", "_lblCommonLabel_15", "txtDeliveryTerms", "_lblCommonLabel_16", "_lblCommonLabel_17", "txtPackingListNo", "_lblCommonLabel_18", "txtNAdditionalExpenses", "_lblCommonLabel_20", "txtAdd1", "txtAdd2", "txtPaymentTerms", "txtLdgrName", "txtDeliveryLocation", "_comCommon_5", "_lblCommonLabel_19", "_lblCommonLabel_21", "_txtCommonTextBox_1", "_fraMasterInformation_1", "txtOldPrescription", "System.Windows.Forms.Label4", "txtAddRSph", "txtDistRCyl", "txtAddRCyl", "txtDistRAxis", "txtAddRAxis", "txtDistLSph", "txtAddLSph", "txtDistLCyl", "txtAddLCyl", "txtDistLAxis", "txtAddLAxis", "txtDistIPD", "txtAddIPD", "txtDistSGH", "txtAddSGH", "txtDistRLens", "txtAddRLens", "txtDistLLens", "txtAddLLens", "txtDistRSph", "System.Windows.Forms.Label5", "Line5", "Line4", "Line3", "Line2", "Line1", "_lblDocDetails_14", "_lblDocDetails_13", "_lblDocDetails_12", "_lblDocDetails_11", "_lblDocDetails_10", "_lblDocDetails_9", "_lblDocDetails_8", "_lblDocDetails_7", "_lblDocDetails_6", "_lblDocDetails_5", "_lblDocDetails_4", "_lblDocDetails_3", "_lblDocDetails_2", "_lblDocDetails_0", "_lblDocDetails_1", "Shape1", "_fraMasterInformation_0", "tabMaster", "_comCommon_10", "_lblCommonLabel_27", "UCOkCancel1", "comCommon", "fraMasterInformation", "lblCommonLabel", "lblDocDetails", "txtCommonTextBox"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		private UCOkCancel _UCOkCancel1_14;
		public System.Windows.Forms.Button cmdItalic;
		public System.Windows.Forms.Button cmdBold;
		public System.Windows.Forms.Button cmdColor;
		public System.Windows.Forms.Button cmdUnderline;
		public System.Windows.Forms.Label Label3;
		private System.Windows.Forms.ComboBox _comCommon_0;
		private System.Windows.Forms.Label _lblCommonLabel_22;
		private System.Windows.Forms.ComboBox _comCommon_6;
		private System.Windows.Forms.Label _lblCommonLabel_23;
		private System.Windows.Forms.ComboBox _comCommon_7;
		private System.Windows.Forms.Label _lblCommonLabel_24;
		private System.Windows.Forms.ComboBox _comCommon_8;
		private System.Windows.Forms.Label _lblCommonLabel_25;
		private System.Windows.Forms.ComboBox _comCommon_9;
		private System.Windows.Forms.Label _lblCommonLabel_26;
		private System.Windows.Forms.ComboBox _comCommon_11;
		private System.Windows.Forms.Label _lblCommonLabel_28;
		private System.Windows.Forms.ComboBox _comCommon_12;
		private System.Windows.Forms.Label _lblCommonLabel_29;
		private System.Windows.Forms.ComboBox _comCommon_13;
		private System.Windows.Forms.Label _lblCommonLabel_30;
		private System.Windows.Forms.ComboBox _comCommon_14;
		private System.Windows.Forms.Label _lblCommonLabel_31;
		public System.Windows.Forms.RichTextBox txtNarration2;
		private System.Windows.Forms.Panel _fraMasterInformation_2;
		private System.Windows.Forms.ComboBox _comCommon_1;
		public Syncfusion.WinForms.Input.SfDateTimeEdit txtCreditCardDate;
		private System.Windows.Forms.Label _lblCommonLabel_7;
		private System.Windows.Forms.Label _lblCommonLabel_6;
		public System.Windows.Forms.Label lblRefrenceOrderDate;
		private System.Windows.Forms.Label _lblCommonLabel_8;
		public System.Windows.Forms.Label lblChequeDate;
		public System.Windows.Forms.Label lblCreditCardDate;
		public System.Windows.Forms.TextBox txtBlockNo;
		public System.Windows.Forms.TextBox txtCountry;
		public Syncfusion.WinForms.Input.SfDateTimeEdit txtRefrenceOrderDate;
		public Syncfusion.WinForms.Input.SfDateTimeEdit txtChequeDate;
		public System.Windows.Forms.TextBox txtCreditCardNo;
		public System.Windows.Forms.TextBox txtPhone;
		public System.Windows.Forms.TextBox txtStreetNo;
		public System.Windows.Forms.TextBox txtCity;
		public System.Windows.Forms.TextBox txtRefOrderNo;
		public System.Windows.Forms.TextBox txtChequeNo;
		private System.Windows.Forms.Label _lblCommonLabel_5;
		private System.Windows.Forms.Label _lblCommonLabel_1;
		private System.Windows.Forms.Label _lblCommonLabel_2;
		private System.Windows.Forms.Label _lblCommonLabel_4;
		private System.Windows.Forms.Label _lblCommonLabel_9;
		private System.Windows.Forms.Label _lblCommonLabel_10;
		private System.Windows.Forms.Label _lblCommonLabel_11;
		private System.Windows.Forms.Label _lblCommonLabel_3;
		private System.Windows.Forms.Label _lblCommonLabel_0;
		public System.Windows.Forms.Label Label1;
		public System.Windows.Forms.TextBox txtDrawnOnBank;
		private System.Windows.Forms.ComboBox _comCommon_2;
		private System.Windows.Forms.Label _lblCommonLabel_12;
		public System.Windows.Forms.Label Label2;
		public System.Windows.Forms.TextBox txtShipmentNo;
		private System.Windows.Forms.ComboBox _comCommon_3;
		private System.Windows.Forms.Label _lblCommonLabel_13;
		private System.Windows.Forms.ComboBox _comCommon_4;
		private System.Windows.Forms.Label _lblCommonLabel_14;
		private System.Windows.Forms.Label _lblCommonLabel_15;
		public System.Windows.Forms.TextBox txtDeliveryTerms;
		private System.Windows.Forms.Label _lblCommonLabel_16;
		private System.Windows.Forms.Label _lblCommonLabel_17;
		public System.Windows.Forms.TextBox txtPackingListNo;
		private System.Windows.Forms.Label _lblCommonLabel_18;
		public System.Windows.Forms.TextBox txtNAdditionalExpenses;
		private System.Windows.Forms.Label _lblCommonLabel_20;
		public System.Windows.Forms.TextBox txtAdd1;
		public System.Windows.Forms.TextBox txtAdd2;
		public System.Windows.Forms.TextBox txtPaymentTerms;
		public System.Windows.Forms.TextBox txtLdgrName;
		public System.Windows.Forms.TextBox txtDeliveryLocation;
		private System.Windows.Forms.ComboBox _comCommon_5;
		private System.Windows.Forms.Label _lblCommonLabel_19;
		private System.Windows.Forms.Label _lblCommonLabel_21;
		private System.Windows.Forms.TextBox _txtCommonTextBox_1;
		private System.Windows.Forms.Panel _fraMasterInformation_1;
		public System.Windows.Forms.TextBox txtOldPrescription;
		public System.Windows.Forms.Label Label4;
		public System.Windows.Forms.TextBox txtAddRSph;
		public System.Windows.Forms.TextBox txtDistRCyl;
		public System.Windows.Forms.TextBox txtAddRCyl;
		public System.Windows.Forms.TextBox txtDistRAxis;
		public System.Windows.Forms.TextBox txtAddRAxis;
		public System.Windows.Forms.TextBox txtDistLSph;
		public System.Windows.Forms.TextBox txtAddLSph;
		public System.Windows.Forms.TextBox txtDistLCyl;
		public System.Windows.Forms.TextBox txtAddLCyl;
		public System.Windows.Forms.TextBox txtDistLAxis;
		public System.Windows.Forms.TextBox txtAddLAxis;
		public System.Windows.Forms.TextBox txtDistIPD;
		public System.Windows.Forms.TextBox txtAddIPD;
		public System.Windows.Forms.TextBox txtDistSGH;
		public System.Windows.Forms.TextBox txtAddSGH;
		public System.Windows.Forms.TextBox txtDistRLens;
		public System.Windows.Forms.TextBox txtAddRLens;
		public System.Windows.Forms.TextBox txtDistLLens;
		public System.Windows.Forms.TextBox txtAddLLens;
		public System.Windows.Forms.TextBox txtDistRSph;
		public System.Windows.Forms.Label Label5;
		public System.Windows.Forms.Label Line5;
		public System.Windows.Forms.Label Line4;
		public System.Windows.Forms.Label Line3;
		public System.Windows.Forms.Label Line2;
		public System.Windows.Forms.Label Line1;
		private System.Windows.Forms.Label _lblDocDetails_14;
		private System.Windows.Forms.Label _lblDocDetails_13;
		private System.Windows.Forms.Label _lblDocDetails_12;
		private System.Windows.Forms.Label _lblDocDetails_11;
		private System.Windows.Forms.Label _lblDocDetails_10;
		private System.Windows.Forms.Label _lblDocDetails_9;
		private System.Windows.Forms.Label _lblDocDetails_8;
		private System.Windows.Forms.Label _lblDocDetails_7;
		private System.Windows.Forms.Label _lblDocDetails_6;
		private System.Windows.Forms.Label _lblDocDetails_5;
		private System.Windows.Forms.Label _lblDocDetails_4;
		private System.Windows.Forms.Label _lblDocDetails_3;
		private System.Windows.Forms.Label _lblDocDetails_2;
		private System.Windows.Forms.Label _lblDocDetails_0;
		private System.Windows.Forms.Label _lblDocDetails_1;
		public ShapeHelper Shape1;
		private System.Windows.Forms.Panel _fraMasterInformation_0;
		public Syncfusion.Windows.Forms.Tools.TabControlAdv tabMaster;
		private System.Windows.Forms.ComboBox _comCommon_10;
		private System.Windows.Forms.Label _lblCommonLabel_27;
		public UCOkCancel[] UCOkCancel1 = new UCOkCancel[15];
		public System.Windows.Forms.ComboBox[] comCommon = new System.Windows.Forms.ComboBox[15];
		public System.Windows.Forms.Panel[] fraMasterInformation = new System.Windows.Forms.Panel[3];
		public System.Windows.Forms.Label[] lblCommonLabel = new System.Windows.Forms.Label[32];
		public System.Windows.Forms.Label[] lblDocDetails = new System.Windows.Forms.Label[15];
		public System.Windows.Forms.TextBox[] txtCommonTextBox = new System.Windows.Forms.TextBox[2];
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmICSAdditionalVoucherDetails));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this._UCOkCancel1_14 = new UCOkCancel();
			this.tabMaster = new Syncfusion.Windows.Forms.Tools.TabControlAdv();
			this._fraMasterInformation_2 = new System.Windows.Forms.Panel();
			this.cmdItalic = new System.Windows.Forms.Button();
			this.cmdBold = new System.Windows.Forms.Button();
			this.cmdColor = new System.Windows.Forms.Button();
			this.cmdUnderline = new System.Windows.Forms.Button();
			this.Label3 = new System.Windows.Forms.Label();
			this._comCommon_0 = new System.Windows.Forms.ComboBox();
			this._lblCommonLabel_22 = new System.Windows.Forms.Label();
			this._comCommon_6 = new System.Windows.Forms.ComboBox();
			this._lblCommonLabel_23 = new System.Windows.Forms.Label();
			this._comCommon_7 = new System.Windows.Forms.ComboBox();
			this._lblCommonLabel_24 = new System.Windows.Forms.Label();
			this._comCommon_8 = new System.Windows.Forms.ComboBox();
			this._lblCommonLabel_25 = new System.Windows.Forms.Label();
			this._comCommon_9 = new System.Windows.Forms.ComboBox();
			this._lblCommonLabel_26 = new System.Windows.Forms.Label();
			this._comCommon_11 = new System.Windows.Forms.ComboBox();
			this._lblCommonLabel_28 = new System.Windows.Forms.Label();
			this._comCommon_12 = new System.Windows.Forms.ComboBox();
			this._lblCommonLabel_29 = new System.Windows.Forms.Label();
			this._comCommon_13 = new System.Windows.Forms.ComboBox();
			this._lblCommonLabel_30 = new System.Windows.Forms.Label();
			this._comCommon_14 = new System.Windows.Forms.ComboBox();
			this._lblCommonLabel_31 = new System.Windows.Forms.Label();
			this.txtNarration2 = new System.Windows.Forms.RichTextBox();
			this._fraMasterInformation_1 = new System.Windows.Forms.Panel();
			this._comCommon_1 = new System.Windows.Forms.ComboBox();
			this.txtCreditCardDate = new Syncfusion.WinForms.Input.SfDateTimeEdit();
			this._lblCommonLabel_7 = new System.Windows.Forms.Label();
			this._lblCommonLabel_6 = new System.Windows.Forms.Label();
			this.lblRefrenceOrderDate = new System.Windows.Forms.Label();
			this._lblCommonLabel_8 = new System.Windows.Forms.Label();
			this.lblChequeDate = new System.Windows.Forms.Label();
			this.lblCreditCardDate = new System.Windows.Forms.Label();
			this.txtBlockNo = new System.Windows.Forms.TextBox();
			this.txtCountry = new System.Windows.Forms.TextBox();
			this.txtRefrenceOrderDate = new Syncfusion.WinForms.Input.SfDateTimeEdit();
			this.txtChequeDate = new Syncfusion.WinForms.Input.SfDateTimeEdit();
			this.txtCreditCardNo = new System.Windows.Forms.TextBox();
			this.txtPhone = new System.Windows.Forms.TextBox();
			this.txtStreetNo = new System.Windows.Forms.TextBox();
			this.txtCity = new System.Windows.Forms.TextBox();
			this.txtRefOrderNo = new System.Windows.Forms.TextBox();
			this.txtChequeNo = new System.Windows.Forms.TextBox();
			this._lblCommonLabel_5 = new System.Windows.Forms.Label();
			this._lblCommonLabel_1 = new System.Windows.Forms.Label();
			this._lblCommonLabel_2 = new System.Windows.Forms.Label();
			this._lblCommonLabel_4 = new System.Windows.Forms.Label();
			this._lblCommonLabel_9 = new System.Windows.Forms.Label();
			this._lblCommonLabel_10 = new System.Windows.Forms.Label();
			this._lblCommonLabel_11 = new System.Windows.Forms.Label();
			this._lblCommonLabel_3 = new System.Windows.Forms.Label();
			this._lblCommonLabel_0 = new System.Windows.Forms.Label();
			this.Label1 = new System.Windows.Forms.Label();
			this.txtDrawnOnBank = new System.Windows.Forms.TextBox();
			this._comCommon_2 = new System.Windows.Forms.ComboBox();
			this._lblCommonLabel_12 = new System.Windows.Forms.Label();
			this.Label2 = new System.Windows.Forms.Label();
			this.txtShipmentNo = new System.Windows.Forms.TextBox();
			this._comCommon_3 = new System.Windows.Forms.ComboBox();
			this._lblCommonLabel_13 = new System.Windows.Forms.Label();
			this._comCommon_4 = new System.Windows.Forms.ComboBox();
			this._lblCommonLabel_14 = new System.Windows.Forms.Label();
			this._lblCommonLabel_15 = new System.Windows.Forms.Label();
			this.txtDeliveryTerms = new System.Windows.Forms.TextBox();
			this._lblCommonLabel_16 = new System.Windows.Forms.Label();
			this._lblCommonLabel_17 = new System.Windows.Forms.Label();
			this.txtPackingListNo = new System.Windows.Forms.TextBox();
			this._lblCommonLabel_18 = new System.Windows.Forms.Label();
			this.txtNAdditionalExpenses = new System.Windows.Forms.TextBox();
			this._lblCommonLabel_20 = new System.Windows.Forms.Label();
			this.txtAdd1 = new System.Windows.Forms.TextBox();
			this.txtAdd2 = new System.Windows.Forms.TextBox();
			this.txtPaymentTerms = new System.Windows.Forms.TextBox();
			this.txtLdgrName = new System.Windows.Forms.TextBox();
			this.txtDeliveryLocation = new System.Windows.Forms.TextBox();
			this._comCommon_5 = new System.Windows.Forms.ComboBox();
			this._lblCommonLabel_19 = new System.Windows.Forms.Label();
			this._lblCommonLabel_21 = new System.Windows.Forms.Label();
			this._txtCommonTextBox_1 = new System.Windows.Forms.TextBox();
			this._fraMasterInformation_0 = new System.Windows.Forms.Panel();
			this.txtOldPrescription = new System.Windows.Forms.TextBox();
			this.Label4 = new System.Windows.Forms.Label();
			this.txtAddRSph = new System.Windows.Forms.TextBox();
			this.txtDistRCyl = new System.Windows.Forms.TextBox();
			this.txtAddRCyl = new System.Windows.Forms.TextBox();
			this.txtDistRAxis = new System.Windows.Forms.TextBox();
			this.txtAddRAxis = new System.Windows.Forms.TextBox();
			this.txtDistLSph = new System.Windows.Forms.TextBox();
			this.txtAddLSph = new System.Windows.Forms.TextBox();
			this.txtDistLCyl = new System.Windows.Forms.TextBox();
			this.txtAddLCyl = new System.Windows.Forms.TextBox();
			this.txtDistLAxis = new System.Windows.Forms.TextBox();
			this.txtAddLAxis = new System.Windows.Forms.TextBox();
			this.txtDistIPD = new System.Windows.Forms.TextBox();
			this.txtAddIPD = new System.Windows.Forms.TextBox();
			this.txtDistSGH = new System.Windows.Forms.TextBox();
			this.txtAddSGH = new System.Windows.Forms.TextBox();
			this.txtDistRLens = new System.Windows.Forms.TextBox();
			this.txtAddRLens = new System.Windows.Forms.TextBox();
			this.txtDistLLens = new System.Windows.Forms.TextBox();
			this.txtAddLLens = new System.Windows.Forms.TextBox();
			this.txtDistRSph = new System.Windows.Forms.TextBox();
			this.Label5 = new System.Windows.Forms.Label();
			this.Line5 = new System.Windows.Forms.Label();
			this.Line4 = new System.Windows.Forms.Label();
			this.Line3 = new System.Windows.Forms.Label();
			this.Line2 = new System.Windows.Forms.Label();
			this.Line1 = new System.Windows.Forms.Label();
			this._lblDocDetails_14 = new System.Windows.Forms.Label();
			this._lblDocDetails_13 = new System.Windows.Forms.Label();
			this._lblDocDetails_12 = new System.Windows.Forms.Label();
			this._lblDocDetails_11 = new System.Windows.Forms.Label();
			this._lblDocDetails_10 = new System.Windows.Forms.Label();
			this._lblDocDetails_9 = new System.Windows.Forms.Label();
			this._lblDocDetails_8 = new System.Windows.Forms.Label();
			this._lblDocDetails_7 = new System.Windows.Forms.Label();
			this._lblDocDetails_6 = new System.Windows.Forms.Label();
			this._lblDocDetails_5 = new System.Windows.Forms.Label();
			this._lblDocDetails_4 = new System.Windows.Forms.Label();
			this._lblDocDetails_3 = new System.Windows.Forms.Label();
			this._lblDocDetails_2 = new System.Windows.Forms.Label();
			this._lblDocDetails_0 = new System.Windows.Forms.Label();
			this._lblDocDetails_1 = new System.Windows.Forms.Label();
			this.Shape1 = new ShapeHelper();
			this._comCommon_10 = new System.Windows.Forms.ComboBox();
			this._lblCommonLabel_27 = new System.Windows.Forms.Label();
			// //((System.ComponentModel.ISupportInitialize) this.tabMaster).BeginInit();
			//this.tabMaster.SuspendLayout();
			//this._fraMasterInformation_2.SuspendLayout();
			//this._fraMasterInformation_1.SuspendLayout();
			//this._fraMasterInformation_0.SuspendLayout();
			this.SuspendLayout();
			// 
			// _UCOkCancel1_14
			// 
			this._UCOkCancel1_14.AllowDrop = true;
			this._UCOkCancel1_14.DisplayButton = 1;
			this._UCOkCancel1_14.Location = new System.Drawing.Point(208, 422);
			this._UCOkCancel1_14.Name = "_UCOkCancel1_14";
			this._UCOkCancel1_14.OkCaption = "&Close";
			this._UCOkCancel1_14.Size = new System.Drawing.Size(104, 31);
			this._UCOkCancel1_14.TabIndex = 47;
			this._UCOkCancel1_14.OKClick += new UCOkCancel.OKClickHandler(this.UCOkCancel1_OKClick);
			// 
			// tabMaster
			// 
			//this.tabMaster.Align = C1SizerLib.AlignSettings.asNone;
			this.tabMaster.AllowDrop = true;
			this.tabMaster.Controls.Add(this._fraMasterInformation_2);
			this.tabMaster.Controls.Add(this._fraMasterInformation_1);
			this.tabMaster.Controls.Add(this._fraMasterInformation_0);
			this.tabMaster.Location = new System.Drawing.Point(0, 0);
			this.tabMaster.Name = "tabMaster";
			//
			this.tabMaster.Size = new System.Drawing.Size(506, 420);
			this.tabMaster.TabIndex = 48;
			this.tabMaster.TabStop = false;
			// 
			// _fraMasterInformation_2
			// 
			this._fraMasterInformation_2.AllowDrop = true;
			this._fraMasterInformation_2.BackColor = System.Drawing.Color.FromArgb(249, 240, 236);
			this._fraMasterInformation_2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._fraMasterInformation_2.Controls.Add(this.cmdItalic);
			this._fraMasterInformation_2.Controls.Add(this.cmdBold);
			this._fraMasterInformation_2.Controls.Add(this.cmdColor);
			this._fraMasterInformation_2.Controls.Add(this.cmdUnderline);
			this._fraMasterInformation_2.Controls.Add(this.Label3);
			this._fraMasterInformation_2.Controls.Add(this._comCommon_0);
			this._fraMasterInformation_2.Controls.Add(this._lblCommonLabel_22);
			this._fraMasterInformation_2.Controls.Add(this._comCommon_6);
			this._fraMasterInformation_2.Controls.Add(this._lblCommonLabel_23);
			this._fraMasterInformation_2.Controls.Add(this._comCommon_7);
			this._fraMasterInformation_2.Controls.Add(this._lblCommonLabel_24);
			this._fraMasterInformation_2.Controls.Add(this._comCommon_8);
			this._fraMasterInformation_2.Controls.Add(this._lblCommonLabel_25);
			this._fraMasterInformation_2.Controls.Add(this._comCommon_9);
			this._fraMasterInformation_2.Controls.Add(this._lblCommonLabel_26);
			this._fraMasterInformation_2.Controls.Add(this._comCommon_11);
			this._fraMasterInformation_2.Controls.Add(this._lblCommonLabel_28);
			this._fraMasterInformation_2.Controls.Add(this._comCommon_12);
			this._fraMasterInformation_2.Controls.Add(this._lblCommonLabel_29);
			this._fraMasterInformation_2.Controls.Add(this._comCommon_13);
			this._fraMasterInformation_2.Controls.Add(this._lblCommonLabel_30);
			this._fraMasterInformation_2.Controls.Add(this._comCommon_14);
			this._fraMasterInformation_2.Controls.Add(this._lblCommonLabel_31);
			this._fraMasterInformation_2.Controls.Add(this.txtNarration2);
			this._fraMasterInformation_2.Enabled = true;
			this._fraMasterInformation_2.ForeColor = System.Drawing.SystemColors.WindowText;
			this._fraMasterInformation_2.Location = new System.Drawing.Point(547, 23);
			this._fraMasterInformation_2.Name = "_fraMasterInformation_2";
			this._fraMasterInformation_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._fraMasterInformation_2.Size = new System.Drawing.Size(504, 396);
			this._fraMasterInformation_2.TabIndex = 51;
			this._fraMasterInformation_2.Visible = true;
			// 
			// cmdItalic
			// 
			this.cmdItalic.AllowDrop = true;
			this.cmdItalic.BackColor = System.Drawing.SystemColors.Control;
			this.cmdItalic.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdItalic.Location = new System.Drawing.Point(174, 112);
			this.cmdItalic.Name = "cmdItalic";
			this.cmdItalic.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdItalic.Size = new System.Drawing.Size(75, 29);
			this.cmdItalic.TabIndex = 122;
			this.cmdItalic.Text = "&Italic";
			this.cmdItalic.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.cmdItalic.UseVisualStyleBackColor = false;
			// this.cmdItalic.Click += new System.EventHandler(this.cmdItalic_Click);
			// 
			// cmdBold
			// 
			this.cmdBold.AllowDrop = true;
			this.cmdBold.BackColor = System.Drawing.SystemColors.Control;
			this.cmdBold.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdBold.Location = new System.Drawing.Point(98, 112);
			this.cmdBold.Name = "cmdBold";
			this.cmdBold.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdBold.Size = new System.Drawing.Size(75, 29);
			this.cmdBold.TabIndex = 121;
			this.cmdBold.Text = "&Bold";
			this.cmdBold.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.cmdBold.UseVisualStyleBackColor = false;
			// this.cmdBold.Click += new System.EventHandler(this.cmdBold_Click);
			// 
			// cmdColor
			// 
			this.cmdColor.AllowDrop = true;
			this.cmdColor.BackColor = System.Drawing.SystemColors.Control;
			this.cmdColor.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdColor.Location = new System.Drawing.Point(326, 112);
			this.cmdColor.Name = "cmdColor";
			this.cmdColor.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdColor.Size = new System.Drawing.Size(75, 29);
			this.cmdColor.TabIndex = 120;
			this.cmdColor.Text = "&Color";
			this.cmdColor.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.cmdColor.UseVisualStyleBackColor = false;
			// this.cmdColor.Click += new System.EventHandler(this.cmdColor_Click);
			// 
			// cmdUnderline
			// 
			this.cmdUnderline.AllowDrop = true;
			this.cmdUnderline.BackColor = System.Drawing.SystemColors.Control;
			this.cmdUnderline.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdUnderline.Location = new System.Drawing.Point(250, 112);
			this.cmdUnderline.Name = "cmdUnderline";
			this.cmdUnderline.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdUnderline.Size = new System.Drawing.Size(75, 29);
			this.cmdUnderline.TabIndex = 119;
			this.cmdUnderline.Text = "&UnderLine";
			this.cmdUnderline.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.cmdUnderline.UseVisualStyleBackColor = false;
			// this.cmdUnderline.Click += new System.EventHandler(this.cmdUnderline_Click);
			// 
			// System.Windows.Forms.Label3
			// 
			this.Label3.AllowDrop = true;
			this.Label3.BackColor = System.Drawing.SystemColors.Window;
			this.Label3.Text = "Narration";
			this.Label3.Location = new System.Drawing.Point(52, 18);
			this.Label3.Name="Label3";
			this.Label3.Size = new System.Drawing.Size(44, 14);
			this.Label3.TabIndex = 93;
			// 
			// _comCommon_0
			// 
			this._comCommon_0.AllowDrop = true;
			this._comCommon_0.Location = new System.Drawing.Point(98, 144);
			this._comCommon_0.Name = "_comCommon_0";
			this._comCommon_0.Size = new System.Drawing.Size(101, 21);
			this._comCommon_0.TabIndex = 95;
			this._comCommon_0.Visible = false;
			// 
			// _lblCommonLabel_22
			// 
			this._lblCommonLabel_22.AllowDrop = true;
			this._lblCommonLabel_22.BackColor = System.Drawing.SystemColors.Window;
			this._lblCommonLabel_22.Text = "Flex 6";
			this._lblCommonLabel_22.Location = new System.Drawing.Point(52, 148);
			this._lblCommonLabel_22.Name = "_lblCommonLabel_22";
			this._lblCommonLabel_22.Size = new System.Drawing.Size(29, 14);
			this._lblCommonLabel_22.TabIndex = 96;
			this._lblCommonLabel_22.Visible = false;
			// 
			// _comCommon_6
			// 
			this._comCommon_6.AllowDrop = true;
			this._comCommon_6.Location = new System.Drawing.Point(98, 218);
			this._comCommon_6.Name = "_comCommon_6";
			this._comCommon_6.Size = new System.Drawing.Size(101, 21);
			this._comCommon_6.TabIndex = 97;
			this._comCommon_6.Visible = false;
			// 
			// _lblCommonLabel_23
			// 
			this._lblCommonLabel_23.AllowDrop = true;
			this._lblCommonLabel_23.BackColor = System.Drawing.SystemColors.Window;
			this._lblCommonLabel_23.Text = "Flex 9";
			this._lblCommonLabel_23.Location = new System.Drawing.Point(52, 220);
			this._lblCommonLabel_23.Name = "_lblCommonLabel_23";
			this._lblCommonLabel_23.Size = new System.Drawing.Size(29, 14);
			this._lblCommonLabel_23.TabIndex = 98;
			this._lblCommonLabel_23.Visible = false;
			// 
			// _comCommon_7
			// 
			this._comCommon_7.AllowDrop = true;
			this._comCommon_7.Location = new System.Drawing.Point(98, 168);
			this._comCommon_7.Name = "_comCommon_7";
			this._comCommon_7.Size = new System.Drawing.Size(101, 21);
			this._comCommon_7.TabIndex = 99;
			this._comCommon_7.Visible = false;
			// 
			// _lblCommonLabel_24
			// 
			this._lblCommonLabel_24.AllowDrop = true;
			this._lblCommonLabel_24.BackColor = System.Drawing.SystemColors.Window;
			this._lblCommonLabel_24.Text = "Flex 7";
			this._lblCommonLabel_24.Location = new System.Drawing.Point(52, 172);
			this._lblCommonLabel_24.Name = "_lblCommonLabel_24";
			this._lblCommonLabel_24.Size = new System.Drawing.Size(29, 14);
			this._lblCommonLabel_24.TabIndex = 100;
			this._lblCommonLabel_24.Visible = false;
			// 
			// _comCommon_8
			// 
			this._comCommon_8.AllowDrop = true;
			this._comCommon_8.Location = new System.Drawing.Point(98, 194);
			this._comCommon_8.Name = "_comCommon_8";
			this._comCommon_8.Size = new System.Drawing.Size(101, 21);
			this._comCommon_8.TabIndex = 101;
			this._comCommon_8.Visible = false;
			// 
			// _lblCommonLabel_25
			// 
			this._lblCommonLabel_25.AllowDrop = true;
			this._lblCommonLabel_25.BackColor = System.Drawing.SystemColors.Window;
			this._lblCommonLabel_25.Text = "Flex 8";
			this._lblCommonLabel_25.Location = new System.Drawing.Point(52, 194);
			this._lblCommonLabel_25.Name = "_lblCommonLabel_25";
			this._lblCommonLabel_25.Size = new System.Drawing.Size(29, 14);
			this._lblCommonLabel_25.TabIndex = 102;
			this._lblCommonLabel_25.Visible = false;
			// 
			// _comCommon_9
			// 
			this._comCommon_9.AllowDrop = true;
			this._comCommon_9.Location = new System.Drawing.Point(98, 242);
			this._comCommon_9.Name = "_comCommon_9";
			this._comCommon_9.Size = new System.Drawing.Size(101, 21);
			this._comCommon_9.TabIndex = 103;
			this._comCommon_9.Visible = false;
			// 
			// _lblCommonLabel_26
			// 
			this._lblCommonLabel_26.AllowDrop = true;
			this._lblCommonLabel_26.BackColor = System.Drawing.SystemColors.Window;
			this._lblCommonLabel_26.Text = "Flex 10";
			this._lblCommonLabel_26.Location = new System.Drawing.Point(52, 244);
			this._lblCommonLabel_26.Name = "_lblCommonLabel_26";
			this._lblCommonLabel_26.Size = new System.Drawing.Size(35, 14);
			this._lblCommonLabel_26.TabIndex = 104;
			this._lblCommonLabel_26.Visible = false;
			// 
			// _comCommon_11
			// 
			this._comCommon_11.AllowDrop = true;
			this._comCommon_11.Location = new System.Drawing.Point(98, 268);
			this._comCommon_11.Name = "_comCommon_11";
			this._comCommon_11.Size = new System.Drawing.Size(101, 21);
			this._comCommon_11.TabIndex = 107;
			this._comCommon_11.Visible = false;
			// 
			// _lblCommonLabel_28
			// 
			this._lblCommonLabel_28.AllowDrop = true;
			this._lblCommonLabel_28.BackColor = System.Drawing.SystemColors.Window;
			this._lblCommonLabel_28.Text = "Flex 11";
			this._lblCommonLabel_28.Location = new System.Drawing.Point(52, 272);
			this._lblCommonLabel_28.Name = "_lblCommonLabel_28";
			this._lblCommonLabel_28.Size = new System.Drawing.Size(35, 14);
			this._lblCommonLabel_28.TabIndex = 108;
			this._lblCommonLabel_28.Visible = false;
			// 
			// _comCommon_12
			// 
			this._comCommon_12.AllowDrop = true;
			this._comCommon_12.Location = new System.Drawing.Point(98, 294);
			this._comCommon_12.Name = "_comCommon_12";
			this._comCommon_12.Size = new System.Drawing.Size(101, 21);
			this._comCommon_12.TabIndex = 109;
			this._comCommon_12.Visible = false;
			// 
			// _lblCommonLabel_29
			// 
			this._lblCommonLabel_29.AllowDrop = true;
			this._lblCommonLabel_29.BackColor = System.Drawing.SystemColors.Window;
			this._lblCommonLabel_29.Text = "Flex 12";
			this._lblCommonLabel_29.Location = new System.Drawing.Point(52, 298);
			this._lblCommonLabel_29.Name = "_lblCommonLabel_29";
			this._lblCommonLabel_29.Size = new System.Drawing.Size(35, 14);
			this._lblCommonLabel_29.TabIndex = 110;
			this._lblCommonLabel_29.Visible = false;
			// 
			// _comCommon_13
			// 
			this._comCommon_13.AllowDrop = true;
			this._comCommon_13.Location = new System.Drawing.Point(98, 320);
			this._comCommon_13.Name = "_comCommon_13";
			this._comCommon_13.Size = new System.Drawing.Size(101, 21);
			this._comCommon_13.TabIndex = 111;
			this._comCommon_13.Visible = false;
			// 
			// _lblCommonLabel_30
			// 
			this._lblCommonLabel_30.AllowDrop = true;
			this._lblCommonLabel_30.BackColor = System.Drawing.SystemColors.Window;
			this._lblCommonLabel_30.Text = "Flex 13";
			this._lblCommonLabel_30.Location = new System.Drawing.Point(52, 324);
			this._lblCommonLabel_30.Name = "_lblCommonLabel_30";
			this._lblCommonLabel_30.Size = new System.Drawing.Size(35, 14);
			this._lblCommonLabel_30.TabIndex = 112;
			this._lblCommonLabel_30.Visible = false;
			// 
			// _comCommon_14
			// 
			this._comCommon_14.AllowDrop = true;
			this._comCommon_14.Location = new System.Drawing.Point(98, 346);
			this._comCommon_14.Name = "_comCommon_14";
			this._comCommon_14.Size = new System.Drawing.Size(101, 21);
			this._comCommon_14.TabIndex = 113;
			this._comCommon_14.Visible = false;
			// 
			// _lblCommonLabel_31
			// 
			this._lblCommonLabel_31.AllowDrop = true;
			this._lblCommonLabel_31.BackColor = System.Drawing.SystemColors.Window;
			this._lblCommonLabel_31.Text = "Flex 14";
			this._lblCommonLabel_31.Location = new System.Drawing.Point(52, 350);
			this._lblCommonLabel_31.Name = "_lblCommonLabel_31";
			this._lblCommonLabel_31.Size = new System.Drawing.Size(35, 14);
			this._lblCommonLabel_31.TabIndex = 114;
			this._lblCommonLabel_31.Visible = false;
			// 
			// txtNarration2
			// 
			this.txtNarration2.AllowDrop = true;
			this.txtNarration2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtNarration2.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtNarration2.Location = new System.Drawing.Point(98, 14);
			this.txtNarration2.Name = "txtNarration2";
			this.txtNarration2.Rtf = resources.GetString("txtNarration2.TextRTF");
			this.txtNarration2.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Both;
			this.txtNarration2.Size = new System.Drawing.Size(395, 97);
			this.txtNarration2.TabIndex = 118;
			// 
			// _fraMasterInformation_1
			// 
			this._fraMasterInformation_1.AllowDrop = true;
			this._fraMasterInformation_1.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._fraMasterInformation_1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._fraMasterInformation_1.Controls.Add(this._comCommon_1);
			this._fraMasterInformation_1.Controls.Add(this.txtCreditCardDate);
			this._fraMasterInformation_1.Controls.Add(this._lblCommonLabel_7);
			this._fraMasterInformation_1.Controls.Add(this._lblCommonLabel_6);
			this._fraMasterInformation_1.Controls.Add(this.lblRefrenceOrderDate);
			this._fraMasterInformation_1.Controls.Add(this._lblCommonLabel_8);
			this._fraMasterInformation_1.Controls.Add(this.lblChequeDate);
			this._fraMasterInformation_1.Controls.Add(this.lblCreditCardDate);
			this._fraMasterInformation_1.Controls.Add(this.txtBlockNo);
			this._fraMasterInformation_1.Controls.Add(this.txtCountry);
			this._fraMasterInformation_1.Controls.Add(this.txtRefrenceOrderDate);
			this._fraMasterInformation_1.Controls.Add(this.txtChequeDate);
			this._fraMasterInformation_1.Controls.Add(this.txtCreditCardNo);
			this._fraMasterInformation_1.Controls.Add(this.txtPhone);
			this._fraMasterInformation_1.Controls.Add(this.txtStreetNo);
			this._fraMasterInformation_1.Controls.Add(this.txtCity);
			this._fraMasterInformation_1.Controls.Add(this.txtRefOrderNo);
			this._fraMasterInformation_1.Controls.Add(this.txtChequeNo);
			this._fraMasterInformation_1.Controls.Add(this._lblCommonLabel_5);
			this._fraMasterInformation_1.Controls.Add(this._lblCommonLabel_1);
			this._fraMasterInformation_1.Controls.Add(this._lblCommonLabel_2);
			this._fraMasterInformation_1.Controls.Add(this._lblCommonLabel_4);
			this._fraMasterInformation_1.Controls.Add(this._lblCommonLabel_9);
			this._fraMasterInformation_1.Controls.Add(this._lblCommonLabel_10);
			this._fraMasterInformation_1.Controls.Add(this._lblCommonLabel_11);
			this._fraMasterInformation_1.Controls.Add(this._lblCommonLabel_3);
			this._fraMasterInformation_1.Controls.Add(this._lblCommonLabel_0);
			this._fraMasterInformation_1.Controls.Add(this.Label1);
			this._fraMasterInformation_1.Controls.Add(this.txtDrawnOnBank);
			this._fraMasterInformation_1.Controls.Add(this._comCommon_2);
			this._fraMasterInformation_1.Controls.Add(this._lblCommonLabel_12);
			this._fraMasterInformation_1.Controls.Add(this.Label2);
			this._fraMasterInformation_1.Controls.Add(this.txtShipmentNo);
			this._fraMasterInformation_1.Controls.Add(this._comCommon_3);
			this._fraMasterInformation_1.Controls.Add(this._lblCommonLabel_13);
			this._fraMasterInformation_1.Controls.Add(this._comCommon_4);
			this._fraMasterInformation_1.Controls.Add(this._lblCommonLabel_14);
			this._fraMasterInformation_1.Controls.Add(this._lblCommonLabel_15);
			this._fraMasterInformation_1.Controls.Add(this.txtDeliveryTerms);
			this._fraMasterInformation_1.Controls.Add(this._lblCommonLabel_16);
			this._fraMasterInformation_1.Controls.Add(this._lblCommonLabel_17);
			this._fraMasterInformation_1.Controls.Add(this.txtPackingListNo);
			this._fraMasterInformation_1.Controls.Add(this._lblCommonLabel_18);
			this._fraMasterInformation_1.Controls.Add(this.txtNAdditionalExpenses);
			this._fraMasterInformation_1.Controls.Add(this._lblCommonLabel_20);
			this._fraMasterInformation_1.Controls.Add(this.txtAdd1);
			this._fraMasterInformation_1.Controls.Add(this.txtAdd2);
			this._fraMasterInformation_1.Controls.Add(this.txtPaymentTerms);
			this._fraMasterInformation_1.Controls.Add(this.txtLdgrName);
			this._fraMasterInformation_1.Controls.Add(this.txtDeliveryLocation);
			this._fraMasterInformation_1.Controls.Add(this._comCommon_5);
			this._fraMasterInformation_1.Controls.Add(this._lblCommonLabel_19);
			this._fraMasterInformation_1.Controls.Add(this._lblCommonLabel_21);
			this._fraMasterInformation_1.Controls.Add(this._txtCommonTextBox_1);
			this._fraMasterInformation_1.Enabled = true;
			this._fraMasterInformation_1.ForeColor = System.Drawing.SystemColors.ControlText;
			this._fraMasterInformation_1.Location = new System.Drawing.Point(1, 23);
			this._fraMasterInformation_1.Name = "_fraMasterInformation_1";
			this._fraMasterInformation_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._fraMasterInformation_1.Size = new System.Drawing.Size(504, 396);
			this._fraMasterInformation_1.TabIndex = 50;
			this._fraMasterInformation_1.Visible = true;
			// 
			// _comCommon_1
			// 
			this._comCommon_1.AllowDrop = true;
			this._comCommon_1.Location = new System.Drawing.Point(126, 370);
			this._comCommon_1.Name = "_comCommon_1";
			this._comCommon_1.Size = new System.Drawing.Size(345, 21);
			this._comCommon_1.TabIndex = 26;
			// 
			// txtCreditCardDate
			// 
			this.txtCreditCardDate.AllowDrop = true;
			// this.txtCreditCardDate.CheckDateRange = false;
			this.txtCreditCardDate.Location = new System.Drawing.Point(352, 176);
			// this.txtCreditCardDate.MaxDate = 2958465;
			// this.txtCreditCardDate.MinDate = 2;
			this.txtCreditCardDate.Name = "txtCreditCardDate";
			this.txtCreditCardDate.Size = new System.Drawing.Size(119, 19);
			this.txtCreditCardDate.TabIndex = 13;
			// this.txtCreditCardDate.Text = "2/4/2002";
			// this.txtCreditCardDate.Value = 37291;
			// 
			// _lblCommonLabel_7
			// 
			this._lblCommonLabel_7.AllowDrop = true;
			this._lblCommonLabel_7.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_7.Text = "City";
			this._lblCommonLabel_7.Location = new System.Drawing.Point(25, 115);
			// // this._lblCommonLabel_7.mLabelId = 123;
			this._lblCommonLabel_7.Name = "_lblCommonLabel_7";
			this._lblCommonLabel_7.Size = new System.Drawing.Size(18, 14);
			this._lblCommonLabel_7.TabIndex = 52;
			// 
			// _lblCommonLabel_6
			// 
			this._lblCommonLabel_6.AllowDrop = true;
			this._lblCommonLabel_6.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_6.Text = "Block No.";
			this._lblCommonLabel_6.Location = new System.Drawing.Point(260, 94);
			// // this._lblCommonLabel_6.mLabelId = 943;
			this._lblCommonLabel_6.Name = "_lblCommonLabel_6";
			this._lblCommonLabel_6.Size = new System.Drawing.Size(45, 14);
			this._lblCommonLabel_6.TabIndex = 53;
			// 
			// lblRefrenceOrderDate
			// 
			this.lblRefrenceOrderDate.AllowDrop = true;
			this.lblRefrenceOrderDate.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			// this.lblRefrenceOrderDate.Text = "Ref. Order Date";
			this.lblRefrenceOrderDate.Location = new System.Drawing.Point(260, 136);
			// // this.lblRefrenceOrderDate.mLabelId = 944;
			this.lblRefrenceOrderDate.Name = "lblRefrenceOrderDate";
			this.lblRefrenceOrderDate.Size = new System.Drawing.Size(76, 14);
			this.lblRefrenceOrderDate.TabIndex = 54;
			// 
			// _lblCommonLabel_8
			// 
			this._lblCommonLabel_8.AllowDrop = true;
			this._lblCommonLabel_8.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_8.Text = "Country";
			this._lblCommonLabel_8.Location = new System.Drawing.Point(260, 115);
			// // this._lblCommonLabel_8.mLabelId = 158;
			this._lblCommonLabel_8.Name = "_lblCommonLabel_8";
			this._lblCommonLabel_8.Size = new System.Drawing.Size(38, 14);
			this._lblCommonLabel_8.TabIndex = 55;
			// 
			// lblChequeDate
			// 
			this.lblChequeDate.AllowDrop = true;
			this.lblChequeDate.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			// this.lblChequeDate.Text = "Cheque Date";
			this.lblChequeDate.Location = new System.Drawing.Point(260, 157);
			// // this.lblChequeDate.mLabelId = 945;
			this.lblChequeDate.Name = "lblChequeDate";
			this.lblChequeDate.Size = new System.Drawing.Size(62, 14);
			this.lblChequeDate.TabIndex = 56;
			// 
			// lblCreditCardDate
			// 
			this.lblCreditCardDate.AllowDrop = true;
			this.lblCreditCardDate.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			// this.lblCreditCardDate.Text = "Credit Card Date ";
			this.lblCreditCardDate.Location = new System.Drawing.Point(260, 178);
			// // this.lblCreditCardDate.mLabelId = 946;
			this.lblCreditCardDate.Name = "lblCreditCardDate";
			this.lblCreditCardDate.Size = new System.Drawing.Size(82, 14);
			this.lblCreditCardDate.TabIndex = 57;
			// 
			// txtBlockNo
			// 
			this.txtBlockNo.AllowDrop = true;
			this.txtBlockNo.BackColor = System.Drawing.Color.White;
			this.txtBlockNo.ForeColor = System.Drawing.Color.Black;
			this.txtBlockNo.Location = new System.Drawing.Point(352, 92);
			this.txtBlockNo.MaxLength = 100;
			this.txtBlockNo.Name = "txtBlockNo";
			this.txtBlockNo.Size = new System.Drawing.Size(119, 19);
			this.txtBlockNo.TabIndex = 5;
			this.txtBlockNo.Text = "";
			// 
			// txtCountry
			// 
			this.txtCountry.AllowDrop = true;
			this.txtCountry.BackColor = System.Drawing.Color.White;
			this.txtCountry.ForeColor = System.Drawing.Color.Black;
			this.txtCountry.Location = new System.Drawing.Point(352, 113);
			this.txtCountry.MaxLength = 100;
			this.txtCountry.Name = "txtCountry";
			this.txtCountry.Size = new System.Drawing.Size(119, 19);
			this.txtCountry.TabIndex = 7;
			this.txtCountry.Text = "";
			// 
			// txtRefrenceOrderDate
			// 
			this.txtRefrenceOrderDate.AllowDrop = true;
			// this.txtRefrenceOrderDate.CheckDateRange = false;
			this.txtRefrenceOrderDate.Location = new System.Drawing.Point(352, 134);
			// this.txtRefrenceOrderDate.MaxDate = 2958465;
			// this.txtRefrenceOrderDate.MinDate = 2;
			this.txtRefrenceOrderDate.Name = "txtRefrenceOrderDate";
			this.txtRefrenceOrderDate.Size = new System.Drawing.Size(119, 19);
			this.txtRefrenceOrderDate.TabIndex = 9;
			// this.txtRefrenceOrderDate.Text = "1/4/2002";
			// this.txtRefrenceOrderDate.Value = 37260;
			// 
			// txtChequeDate
			// 
			this.txtChequeDate.AllowDrop = true;
			// this.txtChequeDate.CheckDateRange = false;
			this.txtChequeDate.Location = new System.Drawing.Point(352, 155);
			// this.txtChequeDate.MaxDate = 2958465;
			// this.txtChequeDate.MinDate = 2;
			this.txtChequeDate.Name = "txtChequeDate";
			this.txtChequeDate.Size = new System.Drawing.Size(119, 19);
			this.txtChequeDate.TabIndex = 11;
			// this.txtChequeDate.Text = "1/4/2002";
			// this.txtChequeDate.Value = 37260;
			// 
			// txtCreditCardNo
			// 
			this.txtCreditCardNo.AllowDrop = true;
			this.txtCreditCardNo.BackColor = System.Drawing.Color.White;
			this.txtCreditCardNo.ForeColor = System.Drawing.Color.Black;
			this.txtCreditCardNo.Location = new System.Drawing.Point(126, 176);
			this.txtCreditCardNo.MaxLength = 100;
			this.txtCreditCardNo.Name = "txtCreditCardNo";
			this.txtCreditCardNo.Size = new System.Drawing.Size(101, 19);
			this.txtCreditCardNo.TabIndex = 12;
			this.txtCreditCardNo.Text = "";
			// 
			// txtPhone
			// 
			this.txtPhone.AllowDrop = true;
			this.txtPhone.BackColor = System.Drawing.Color.White;
			this.txtPhone.ForeColor = System.Drawing.Color.Black;
			this.txtPhone.Location = new System.Drawing.Point(126, 71);
			this.txtPhone.MaxLength = 100;
			this.txtPhone.Name = "txtPhone";
			this.txtPhone.Size = new System.Drawing.Size(101, 19);
			this.txtPhone.TabIndex = 3;
			this.txtPhone.Text = "";
			// 
			// txtStreetNo
			// 
			this.txtStreetNo.AllowDrop = true;
			this.txtStreetNo.BackColor = System.Drawing.Color.White;
			this.txtStreetNo.ForeColor = System.Drawing.Color.Black;
			this.txtStreetNo.Location = new System.Drawing.Point(126, 92);
			this.txtStreetNo.MaxLength = 100;
			this.txtStreetNo.Name = "txtStreetNo";
			this.txtStreetNo.Size = new System.Drawing.Size(101, 19);
			this.txtStreetNo.TabIndex = 4;
			this.txtStreetNo.Text = "";
			// 
			// txtCity
			// 
			this.txtCity.AllowDrop = true;
			this.txtCity.BackColor = System.Drawing.Color.White;
			this.txtCity.ForeColor = System.Drawing.Color.Black;
			this.txtCity.Location = new System.Drawing.Point(126, 113);
			this.txtCity.MaxLength = 100;
			this.txtCity.Name = "txtCity";
			this.txtCity.Size = new System.Drawing.Size(101, 19);
			this.txtCity.TabIndex = 6;
			this.txtCity.Text = "";
			// 
			// txtRefOrderNo
			// 
			this.txtRefOrderNo.AllowDrop = true;
			this.txtRefOrderNo.BackColor = System.Drawing.Color.White;
			this.txtRefOrderNo.ForeColor = System.Drawing.Color.Black;
			this.txtRefOrderNo.Location = new System.Drawing.Point(126, 134);
			this.txtRefOrderNo.MaxLength = 100;
			this.txtRefOrderNo.Name = "txtRefOrderNo";
			this.txtRefOrderNo.Size = new System.Drawing.Size(101, 19);
			this.txtRefOrderNo.TabIndex = 8;
			this.txtRefOrderNo.Text = "";
			// 
			// txtChequeNo
			// 
			this.txtChequeNo.AllowDrop = true;
			this.txtChequeNo.BackColor = System.Drawing.Color.White;
			this.txtChequeNo.ForeColor = System.Drawing.Color.Black;
			this.txtChequeNo.Location = new System.Drawing.Point(126, 155);
			this.txtChequeNo.MaxLength = 100;
			this.txtChequeNo.Name = "txtChequeNo";
			this.txtChequeNo.Size = new System.Drawing.Size(101, 19);
			this.txtChequeNo.TabIndex = 10;
			this.txtChequeNo.Text = "";
			// 
			// _lblCommonLabel_5
			// 
			this._lblCommonLabel_5.AllowDrop = true;
			this._lblCommonLabel_5.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_5.Text = "Street No.";
			this._lblCommonLabel_5.Location = new System.Drawing.Point(25, 94);
			// // this._lblCommonLabel_5.mLabelId = 938;
			this._lblCommonLabel_5.Name = "_lblCommonLabel_5";
			this._lblCommonLabel_5.Size = new System.Drawing.Size(48, 14);
			this._lblCommonLabel_5.TabIndex = 58;
			// 
			// _lblCommonLabel_1
			// 
			this._lblCommonLabel_1.AllowDrop = true;
			this._lblCommonLabel_1.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_1.Text = "Customer Name";
			this._lblCommonLabel_1.Location = new System.Drawing.Point(25, 8);
			// // this._lblCommonLabel_1.mLabelId = 935;
			this._lblCommonLabel_1.Name = "_lblCommonLabel_1";
			this._lblCommonLabel_1.Size = new System.Drawing.Size(76, 14);
			this._lblCommonLabel_1.TabIndex = 59;
			// 
			// _lblCommonLabel_2
			// 
			this._lblCommonLabel_2.AllowDrop = true;
			this._lblCommonLabel_2.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_2.Text = "Address 1";
			this._lblCommonLabel_2.Location = new System.Drawing.Point(25, 31);
			// // this._lblCommonLabel_2.mLabelId = 936;
			this._lblCommonLabel_2.Name = "_lblCommonLabel_2";
			this._lblCommonLabel_2.Size = new System.Drawing.Size(51, 14);
			this._lblCommonLabel_2.TabIndex = 60;
			// 
			// _lblCommonLabel_4
			// 
			this._lblCommonLabel_4.AllowDrop = true;
			this._lblCommonLabel_4.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_4.Text = "Phone";
			this._lblCommonLabel_4.Location = new System.Drawing.Point(25, 73);
			// // this._lblCommonLabel_4.mLabelId = 524;
			this._lblCommonLabel_4.Name = "_lblCommonLabel_4";
			this._lblCommonLabel_4.Size = new System.Drawing.Size(30, 14);
			this._lblCommonLabel_4.TabIndex = 61;
			// 
			// _lblCommonLabel_9
			// 
			this._lblCommonLabel_9.AllowDrop = true;
			this._lblCommonLabel_9.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_9.Text = "Ref. Order No.";
			this._lblCommonLabel_9.Location = new System.Drawing.Point(25, 136);
			// // this._lblCommonLabel_9.mLabelId = 939;
			this._lblCommonLabel_9.Name = "_lblCommonLabel_9";
			this._lblCommonLabel_9.Size = new System.Drawing.Size(70, 14);
			this._lblCommonLabel_9.TabIndex = 62;
			// 
			// _lblCommonLabel_10
			// 
			this._lblCommonLabel_10.AllowDrop = true;
			this._lblCommonLabel_10.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_10.Text = "Cheque No.";
			this._lblCommonLabel_10.Location = new System.Drawing.Point(25, 157);
			// // this._lblCommonLabel_10.mLabelId = 940;
			this._lblCommonLabel_10.Name = "_lblCommonLabel_10";
			this._lblCommonLabel_10.Size = new System.Drawing.Size(56, 14);
			this._lblCommonLabel_10.TabIndex = 63;
			// 
			// _lblCommonLabel_11
			// 
			this._lblCommonLabel_11.AllowDrop = true;
			this._lblCommonLabel_11.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_11.Text = "Credit Card No.";
			this._lblCommonLabel_11.Location = new System.Drawing.Point(25, 178);
			// // this._lblCommonLabel_11.mLabelId = 941;
			this._lblCommonLabel_11.Name = "_lblCommonLabel_11";
			this._lblCommonLabel_11.Size = new System.Drawing.Size(73, 14);
			this._lblCommonLabel_11.TabIndex = 64;
			// 
			// _lblCommonLabel_3
			// 
			this._lblCommonLabel_3.AllowDrop = true;
			this._lblCommonLabel_3.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_3.Text = "Address 2";
			this._lblCommonLabel_3.Location = new System.Drawing.Point(25, 52);
			// // this._lblCommonLabel_3.mLabelId = 937;
			this._lblCommonLabel_3.Name = "_lblCommonLabel_3";
			this._lblCommonLabel_3.Size = new System.Drawing.Size(51, 14);
			this._lblCommonLabel_3.TabIndex = 65;
			// 
			// _lblCommonLabel_0
			// 
			this._lblCommonLabel_0.AllowDrop = true;
			this._lblCommonLabel_0.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_0.Text = "Payment Mode";
			this._lblCommonLabel_0.Location = new System.Drawing.Point(25, 372);
			// // this._lblCommonLabel_0.mLabelId = 942;
			this._lblCommonLabel_0.Name = "_lblCommonLabel_0";
			this._lblCommonLabel_0.Size = new System.Drawing.Size(70, 14);
			this._lblCommonLabel_0.TabIndex = 66;
			// 
			// System.Windows.Forms.Label1
			// 
			this.Label1.AllowDrop = true;
			this.Label1.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.Label1.Text = "Drawn on Bank";
			this.Label1.Location = new System.Drawing.Point(260, 200);
			// this.Label1.mLabelId = 947;
			this.Label1.Name="Label1";
			this.Label1.Size = new System.Drawing.Size(75, 14);
			this.Label1.TabIndex = 67;
			// 
			// txtDrawnOnBank
			// 
			this.txtDrawnOnBank.AllowDrop = true;
			this.txtDrawnOnBank.BackColor = System.Drawing.Color.White;
			this.txtDrawnOnBank.ForeColor = System.Drawing.Color.Black;
			this.txtDrawnOnBank.Location = new System.Drawing.Point(352, 198);
			this.txtDrawnOnBank.MaxLength = 100;
			this.txtDrawnOnBank.Name = "txtDrawnOnBank";
			this.txtDrawnOnBank.Size = new System.Drawing.Size(119, 19);
			this.txtDrawnOnBank.TabIndex = 15;
			this.txtDrawnOnBank.Text = "";
			// 
			// _comCommon_2
			// 
			this._comCommon_2.AllowDrop = true;
			this._comCommon_2.Location = new System.Drawing.Point(126, 346);
			this._comCommon_2.Name = "_comCommon_2";
			this._comCommon_2.Size = new System.Drawing.Size(101, 21);
			this._comCommon_2.TabIndex = 24;
			// 
			// _lblCommonLabel_12
			// 
			this._lblCommonLabel_12.AllowDrop = true;
			this._lblCommonLabel_12.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_12.Text = "Shipment Mode";
			this._lblCommonLabel_12.Location = new System.Drawing.Point(25, 348);
			// // this._lblCommonLabel_12.mLabelId = 2038;
			this._lblCommonLabel_12.Name = "_lblCommonLabel_12";
			this._lblCommonLabel_12.Size = new System.Drawing.Size(73, 14);
			this._lblCommonLabel_12.TabIndex = 68;
			// 
			// System.Windows.Forms.Label2
			// 
			this.Label2.AllowDrop = true;
			this.Label2.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.Label2.Text = "Shipment No.";
			this.Label2.Location = new System.Drawing.Point(260, 249);
			// this.Label2.mLabelId = 2034;
			this.Label2.Name="Label2";
			this.Label2.Size = new System.Drawing.Size(63, 14);
			this.Label2.TabIndex = 69;
			// 
			// txtShipmentNo
			// 
			this.txtShipmentNo.AllowDrop = true;
			this.txtShipmentNo.BackColor = System.Drawing.Color.White;
			this.txtShipmentNo.ForeColor = System.Drawing.Color.Black;
			this.txtShipmentNo.Location = new System.Drawing.Point(352, 247);
			this.txtShipmentNo.MaxLength = 100;
			this.txtShipmentNo.Name = "txtShipmentNo";
			this.txtShipmentNo.Size = new System.Drawing.Size(119, 19);
			this.txtShipmentNo.TabIndex = 18;
			this.txtShipmentNo.Text = "";
			// 
			// _comCommon_3
			// 
			this._comCommon_3.AllowDrop = true;
			this._comCommon_3.Location = new System.Drawing.Point(352, 346);
			this._comCommon_3.Name = "_comCommon_3";
			this._comCommon_3.Size = new System.Drawing.Size(119, 21);
			this._comCommon_3.TabIndex = 25;
			// 
			// _lblCommonLabel_13
			// 
			this._lblCommonLabel_13.AllowDrop = true;
			this._lblCommonLabel_13.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_13.Text = "Shipment No. Type";
			this._lblCommonLabel_13.Location = new System.Drawing.Point(260, 348);
			// // this._lblCommonLabel_13.mLabelId = 2039;
			this._lblCommonLabel_13.Name = "_lblCommonLabel_13";
			this._lblCommonLabel_13.Size = new System.Drawing.Size(90, 14);
			this._lblCommonLabel_13.TabIndex = 70;
			// 
			// _comCommon_4
			// 
			this._comCommon_4.AllowDrop = true;
			this._comCommon_4.Location = new System.Drawing.Point(352, 322);
			this._comCommon_4.Name = "_comCommon_4";
			this._comCommon_4.Size = new System.Drawing.Size(119, 21);
			this._comCommon_4.TabIndex = 23;
			// 
			// _lblCommonLabel_14
			// 
			this._lblCommonLabel_14.AllowDrop = true;
			this._lblCommonLabel_14.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_14.Text = "Delivery Period";
			this._lblCommonLabel_14.Location = new System.Drawing.Point(260, 322);
			// // this._lblCommonLabel_14.mLabelId = 2037;
			this._lblCommonLabel_14.Name = "_lblCommonLabel_14";
			this._lblCommonLabel_14.Size = new System.Drawing.Size(72, 14);
			this._lblCommonLabel_14.TabIndex = 71;
			// 
			// _lblCommonLabel_15
			// 
			this._lblCommonLabel_15.AllowDrop = true;
			this._lblCommonLabel_15.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_15.Text = "Delivery Location";
			this._lblCommonLabel_15.Location = new System.Drawing.Point(260, 275);
			// // this._lblCommonLabel_15.mLabelId = 2033;
			this._lblCommonLabel_15.Name = "_lblCommonLabel_15";
			this._lblCommonLabel_15.Size = new System.Drawing.Size(83, 14);
			this._lblCommonLabel_15.TabIndex = 72;
			// 
			// txtDeliveryTerms
			// 
			this.txtDeliveryTerms.AllowDrop = true;
			this.txtDeliveryTerms.BackColor = System.Drawing.Color.White;
			this.txtDeliveryTerms.ForeColor = System.Drawing.Color.Black;
			this.txtDeliveryTerms.Location = new System.Drawing.Point(126, 298);
			this.txtDeliveryTerms.MaxLength = 100;
			this.txtDeliveryTerms.Name = "txtDeliveryTerms";
			this.txtDeliveryTerms.Size = new System.Drawing.Size(344, 19);
			this.txtDeliveryTerms.TabIndex = 21;
			this.txtDeliveryTerms.Text = "";
			// 
			// _lblCommonLabel_16
			// 
			this._lblCommonLabel_16.AllowDrop = true;
			this._lblCommonLabel_16.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_16.Text = "Payment Terms";
			this._lblCommonLabel_16.Location = new System.Drawing.Point(25, 224);
			// // this._lblCommonLabel_16.mLabelId = 2031;
			this._lblCommonLabel_16.Name = "_lblCommonLabel_16";
			this._lblCommonLabel_16.Size = new System.Drawing.Size(74, 14);
			this._lblCommonLabel_16.TabIndex = 73;
			// 
			// _lblCommonLabel_17
			// 
			this._lblCommonLabel_17.AllowDrop = true;
			this._lblCommonLabel_17.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_17.Text = "Delivery Terms";
			this._lblCommonLabel_17.Location = new System.Drawing.Point(25, 300);
			// // this._lblCommonLabel_17.mLabelId = 2032;
			this._lblCommonLabel_17.Name = "_lblCommonLabel_17";
			this._lblCommonLabel_17.Size = new System.Drawing.Size(72, 14);
			this._lblCommonLabel_17.TabIndex = 74;
			// 
			// txtPackingListNo
			// 
			this.txtPackingListNo.AllowDrop = true;
			this.txtPackingListNo.BackColor = System.Drawing.Color.White;
			this.txtPackingListNo.ForeColor = System.Drawing.Color.Black;
			this.txtPackingListNo.Location = new System.Drawing.Point(126, 246);
			this.txtPackingListNo.MaxLength = 100;
			this.txtPackingListNo.Name = "txtPackingListNo";
			this.txtPackingListNo.Size = new System.Drawing.Size(101, 19);
			this.txtPackingListNo.TabIndex = 17;
			this.txtPackingListNo.Text = "";
			// 
			// _lblCommonLabel_18
			// 
			this._lblCommonLabel_18.AllowDrop = true;
			this._lblCommonLabel_18.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_18.Text = "Packing List No.";
			this._lblCommonLabel_18.Location = new System.Drawing.Point(25, 250);
			// // this._lblCommonLabel_18.mLabelId = 2035;
			this._lblCommonLabel_18.Name = "_lblCommonLabel_18";
			this._lblCommonLabel_18.Size = new System.Drawing.Size(76, 14);
			this._lblCommonLabel_18.TabIndex = 75;
			// 
			// txtNAdditionalExpenses
			// 
			this.txtNAdditionalExpenses.AllowDrop = true;
			// this.txtNAdditionalExpenses.DisplayFormat = "####0.000###;;0.000;0.000";
			// this.txtNAdditionalExpenses.Format = "###########0.000";
			this.txtNAdditionalExpenses.Location = new System.Drawing.Point(126, 198);
			// // = 2147483647;
			// // = -2147483648;
			this.txtNAdditionalExpenses.Name = "txtNAdditionalExpenses";
			this.txtNAdditionalExpenses.Size = new System.Drawing.Size(101, 19);
			this.txtNAdditionalExpenses.TabIndex = 14;
			this.txtNAdditionalExpenses.Text = "0.000";
			// 
			// _lblCommonLabel_20
			// 
			this._lblCommonLabel_20.AllowDrop = true;
			this._lblCommonLabel_20.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_20.Text = "Additional Expenses";
			this._lblCommonLabel_20.Location = new System.Drawing.Point(25, 202);
			this._lblCommonLabel_20.Name = "_lblCommonLabel_20";
			this._lblCommonLabel_20.Size = new System.Drawing.Size(98, 14);
			this._lblCommonLabel_20.TabIndex = 76;
			// 
			// txtAdd1
			// 
			this.txtAdd1.AllowDrop = true;
			this.txtAdd1.BackColor = System.Drawing.Color.White;
			this.txtAdd1.ForeColor = System.Drawing.Color.Black;
			this.txtAdd1.Location = new System.Drawing.Point(126, 29);
			this.txtAdd1.MaxLength = 100;
			this.txtAdd1.Name = "txtAdd1";
			this.txtAdd1.Size = new System.Drawing.Size(344, 19);
			this.txtAdd1.TabIndex = 1;
			this.txtAdd1.Text = "";
			// 
			// txtAdd2
			// 
			this.txtAdd2.AllowDrop = true;
			this.txtAdd2.BackColor = System.Drawing.Color.White;
			this.txtAdd2.ForeColor = System.Drawing.Color.Black;
			this.txtAdd2.Location = new System.Drawing.Point(126, 50);
			this.txtAdd2.MaxLength = 100;
			this.txtAdd2.Name = "txtAdd2";
			this.txtAdd2.Size = new System.Drawing.Size(344, 19);
			this.txtAdd2.TabIndex = 2;
			this.txtAdd2.Text = "";
			// 
			// txtPaymentTerms
			// 
			this.txtPaymentTerms.AllowDrop = true;
			this.txtPaymentTerms.BackColor = System.Drawing.Color.White;
			this.txtPaymentTerms.ForeColor = System.Drawing.Color.Black;
			this.txtPaymentTerms.Location = new System.Drawing.Point(126, 222);
			this.txtPaymentTerms.MaxLength = 100;
			this.txtPaymentTerms.Name = "txtPaymentTerms";
			this.txtPaymentTerms.Size = new System.Drawing.Size(344, 19);
			this.txtPaymentTerms.TabIndex = 16;
			this.txtPaymentTerms.Text = "";
			// 
			// txtLdgrName
			// 
			this.txtLdgrName.AllowDrop = true;
			this.txtLdgrName.BackColor = System.Drawing.Color.White;
			this.txtLdgrName.ForeColor = System.Drawing.Color.Black;
			this.txtLdgrName.Location = new System.Drawing.Point(126, 8);
			this.txtLdgrName.MaxLength = 100;
			this.txtLdgrName.Name = "txtLdgrName";
			this.txtLdgrName.Size = new System.Drawing.Size(344, 19);
			this.txtLdgrName.TabIndex = 0;
			this.txtLdgrName.Tag = "Salesman Name in English";
			this.txtLdgrName.Text = "";
			// 
			// txtDeliveryLocation
			// 
			this.txtDeliveryLocation.AllowDrop = true;
			this.txtDeliveryLocation.BackColor = System.Drawing.Color.White;
			this.txtDeliveryLocation.ForeColor = System.Drawing.Color.Black;
			this.txtDeliveryLocation.Location = new System.Drawing.Point(352, 272);
			this.txtDeliveryLocation.MaxLength = 100;
			this.txtDeliveryLocation.Name = "txtDeliveryLocation";
			this.txtDeliveryLocation.Size = new System.Drawing.Size(119, 19);
			this.txtDeliveryLocation.TabIndex = 20;
			this.txtDeliveryLocation.Text = "";
			// 
			// _comCommon_5
			// 
			this._comCommon_5.AllowDrop = true;
			this._comCommon_5.Location = new System.Drawing.Point(126, 322);
			this._comCommon_5.Name = "_comCommon_5";
			this._comCommon_5.Size = new System.Drawing.Size(101, 21);
			this._comCommon_5.TabIndex = 22;
			// 
			// _lblCommonLabel_19
			// 
			this._lblCommonLabel_19.AllowDrop = true;
			this._lblCommonLabel_19.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_19.Text = "Trans Type";
			this._lblCommonLabel_19.Location = new System.Drawing.Point(25, 322);
			// // this._lblCommonLabel_19.mLabelId = 2036;
			this._lblCommonLabel_19.Name = "_lblCommonLabel_19";
			this._lblCommonLabel_19.Size = new System.Drawing.Size(55, 14);
			this._lblCommonLabel_19.TabIndex = 77;
			// 
			// _lblCommonLabel_21
			// 
			this._lblCommonLabel_21.AllowDrop = true;
			this._lblCommonLabel_21.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommonLabel_21.Text = "Bid No";
			this._lblCommonLabel_21.Location = new System.Drawing.Point(25, 274);
			// // this._lblCommonLabel_21.mLabelId = 2044;
			this._lblCommonLabel_21.Name = "_lblCommonLabel_21";
			this._lblCommonLabel_21.Size = new System.Drawing.Size(31, 14);
			this._lblCommonLabel_21.TabIndex = 94;
			this._lblCommonLabel_21.Visible = false;
			// 
			// _txtCommonTextBox_1
			// 
			this._txtCommonTextBox_1.AllowDrop = true;
			this._txtCommonTextBox_1.BackColor = System.Drawing.Color.White;
			this._txtCommonTextBox_1.ForeColor = System.Drawing.Color.Black;
			this._txtCommonTextBox_1.Location = new System.Drawing.Point(126, 272);
			this._txtCommonTextBox_1.MaxLength = 20;
			this._txtCommonTextBox_1.Name = "_txtCommonTextBox_1";
			// this._txtCommonTextBox_1.ShowButton = true;
			this._txtCommonTextBox_1.Size = new System.Drawing.Size(101, 19);
			this._txtCommonTextBox_1.TabIndex = 19;
			this._txtCommonTextBox_1.Text = "";
			this._txtCommonTextBox_1.Visible = false;
			// this.//this._txtCommonTextBox_1.DropButtonClick += new System.Windows.Forms.TextBox.DropButtonClickHandler(//this.txtCommonTextBox_DropButtonClick);
			// 
			// _fraMasterInformation_0
			// 
			this._fraMasterInformation_0.AllowDrop = true;
			this._fraMasterInformation_0.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._fraMasterInformation_0.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._fraMasterInformation_0.Controls.Add(this.txtOldPrescription);
			this._fraMasterInformation_0.Controls.Add(this.Label4);
			this._fraMasterInformation_0.Controls.Add(this.txtAddRSph);
			this._fraMasterInformation_0.Controls.Add(this.txtDistRCyl);
			this._fraMasterInformation_0.Controls.Add(this.txtAddRCyl);
			this._fraMasterInformation_0.Controls.Add(this.txtDistRAxis);
			this._fraMasterInformation_0.Controls.Add(this.txtAddRAxis);
			this._fraMasterInformation_0.Controls.Add(this.txtDistLSph);
			this._fraMasterInformation_0.Controls.Add(this.txtAddLSph);
			this._fraMasterInformation_0.Controls.Add(this.txtDistLCyl);
			this._fraMasterInformation_0.Controls.Add(this.txtAddLCyl);
			this._fraMasterInformation_0.Controls.Add(this.txtDistLAxis);
			this._fraMasterInformation_0.Controls.Add(this.txtAddLAxis);
			this._fraMasterInformation_0.Controls.Add(this.txtDistIPD);
			this._fraMasterInformation_0.Controls.Add(this.txtAddIPD);
			this._fraMasterInformation_0.Controls.Add(this.txtDistSGH);
			this._fraMasterInformation_0.Controls.Add(this.txtAddSGH);
			this._fraMasterInformation_0.Controls.Add(this.txtDistRLens);
			this._fraMasterInformation_0.Controls.Add(this.txtAddRLens);
			this._fraMasterInformation_0.Controls.Add(this.txtDistLLens);
			this._fraMasterInformation_0.Controls.Add(this.txtAddLLens);
			this._fraMasterInformation_0.Controls.Add(this.txtDistRSph);
			this._fraMasterInformation_0.Controls.Add(this.Label5);
			this._fraMasterInformation_0.Controls.Add(this.Line5);
			this._fraMasterInformation_0.Controls.Add(this.Line4);
			this._fraMasterInformation_0.Controls.Add(this.Line3);
			this._fraMasterInformation_0.Controls.Add(this.Line2);
			this._fraMasterInformation_0.Controls.Add(this.Line1);
			this._fraMasterInformation_0.Controls.Add(this._lblDocDetails_14);
			this._fraMasterInformation_0.Controls.Add(this._lblDocDetails_13);
			this._fraMasterInformation_0.Controls.Add(this._lblDocDetails_12);
			this._fraMasterInformation_0.Controls.Add(this._lblDocDetails_11);
			this._fraMasterInformation_0.Controls.Add(this._lblDocDetails_10);
			this._fraMasterInformation_0.Controls.Add(this._lblDocDetails_9);
			this._fraMasterInformation_0.Controls.Add(this._lblDocDetails_8);
			this._fraMasterInformation_0.Controls.Add(this._lblDocDetails_7);
			this._fraMasterInformation_0.Controls.Add(this._lblDocDetails_6);
			this._fraMasterInformation_0.Controls.Add(this._lblDocDetails_5);
			this._fraMasterInformation_0.Controls.Add(this._lblDocDetails_4);
			this._fraMasterInformation_0.Controls.Add(this._lblDocDetails_3);
			this._fraMasterInformation_0.Controls.Add(this._lblDocDetails_2);
			this._fraMasterInformation_0.Controls.Add(this._lblDocDetails_0);
			this._fraMasterInformation_0.Controls.Add(this._lblDocDetails_1);
			this._fraMasterInformation_0.Controls.Add(this.Shape1);
			this._fraMasterInformation_0.Enabled = true;
			this._fraMasterInformation_0.ForeColor = System.Drawing.SystemColors.WindowText;
			this._fraMasterInformation_0.Location = new System.Drawing.Point(-545, 23);
			this._fraMasterInformation_0.Name = "_fraMasterInformation_0";
			this._fraMasterInformation_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._fraMasterInformation_0.Size = new System.Drawing.Size(504, 396);
			this._fraMasterInformation_0.TabIndex = 49;
			this._fraMasterInformation_0.Visible = true;
			// 
			// txtOldPrescription
			// 
			this.txtOldPrescription.AcceptsReturn = true;
			this.txtOldPrescription.AllowDrop = true;
			this.txtOldPrescription.BackColor = System.Drawing.SystemColors.Window;
			this.txtOldPrescription.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.txtOldPrescription.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtOldPrescription.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtOldPrescription.Location = new System.Drawing.Point(12, 164);
			this.txtOldPrescription.MaxLength = 0;
			this.txtOldPrescription.Multiline = true;
			this.txtOldPrescription.Name = "txtOldPrescription";
			this.txtOldPrescription.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtOldPrescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtOldPrescription.Size = new System.Drawing.Size(483, 227);
			this.txtOldPrescription.TabIndex = 117;
			this.txtOldPrescription.Text = "Text1";
			// 
			// System.Windows.Forms.Label4
			// 
			this.Label4.AllowDrop = true;
			this.Label4.BackColor = System.Drawing.SystemColors.Window;
			this.Label4.Text = "New Prescription";
			this.Label4.Enabled = false;
			this.Label4.ForeColor = System.Drawing.SystemColors.WindowText;
			this.Label4.Location = new System.Drawing.Point(14, 22);
			this.Label4.Name="Label4";
			this.Label4.Size = new System.Drawing.Size(98, 15);
			this.Label4.TabIndex = 115;
			// 
			// txtAddRSph
			// 
			this.txtAddRSph.AllowDrop = true;
			this.txtAddRSph.BackColor = System.Drawing.Color.White;
			this.txtAddRSph.ForeColor = System.Drawing.Color.Black;
			this.txtAddRSph.Location = new System.Drawing.Point(84, 111);
			this.txtAddRSph.MaxLength = 10;
			this.txtAddRSph.Name = "txtAddRSph";
			this.txtAddRSph.Size = new System.Drawing.Size(40, 19);
			this.txtAddRSph.TabIndex = 37;
			this.txtAddRSph.Text = "";
			// 
			// txtDistRCyl
			// 
			this.txtDistRCyl.AllowDrop = true;
			this.txtDistRCyl.BackColor = System.Drawing.Color.White;
			this.txtDistRCyl.ForeColor = System.Drawing.Color.Black;
			this.txtDistRCyl.Location = new System.Drawing.Point(124, 92);
			this.txtDistRCyl.MaxLength = 10;
			this.txtDistRCyl.Name = "txtDistRCyl";
			this.txtDistRCyl.Size = new System.Drawing.Size(40, 19);
			this.txtDistRCyl.TabIndex = 28;
			this.txtDistRCyl.Text = "";
			// 
			// txtAddRCyl
			// 
			this.txtAddRCyl.AllowDrop = true;
			this.txtAddRCyl.BackColor = System.Drawing.Color.White;
			this.txtAddRCyl.ForeColor = System.Drawing.Color.Black;
			this.txtAddRCyl.Location = new System.Drawing.Point(124, 111);
			this.txtAddRCyl.MaxLength = 10;
			this.txtAddRCyl.Name = "txtAddRCyl";
			this.txtAddRCyl.Size = new System.Drawing.Size(40, 19);
			this.txtAddRCyl.TabIndex = 38;
			this.txtAddRCyl.Text = "";
			// 
			// txtDistRAxis
			// 
			this.txtDistRAxis.AllowDrop = true;
			this.txtDistRAxis.BackColor = System.Drawing.Color.White;
			this.txtDistRAxis.ForeColor = System.Drawing.Color.Black;
			this.txtDistRAxis.Location = new System.Drawing.Point(164, 92);
			this.txtDistRAxis.MaxLength = 10;
			this.txtDistRAxis.Name = "txtDistRAxis";
			this.txtDistRAxis.Size = new System.Drawing.Size(40, 19);
			this.txtDistRAxis.TabIndex = 29;
			this.txtDistRAxis.Text = "";
			// 
			// txtAddRAxis
			// 
			this.txtAddRAxis.AllowDrop = true;
			this.txtAddRAxis.BackColor = System.Drawing.Color.White;
			this.txtAddRAxis.ForeColor = System.Drawing.Color.Black;
			this.txtAddRAxis.Location = new System.Drawing.Point(164, 111);
			this.txtAddRAxis.MaxLength = 10;
			this.txtAddRAxis.Name = "txtAddRAxis";
			this.txtAddRAxis.Size = new System.Drawing.Size(40, 19);
			this.txtAddRAxis.TabIndex = 39;
			this.txtAddRAxis.Text = "";
			// 
			// txtDistLSph
			// 
			this.txtDistLSph.AllowDrop = true;
			this.txtDistLSph.BackColor = System.Drawing.Color.White;
			this.txtDistLSph.ForeColor = System.Drawing.Color.Black;
			this.txtDistLSph.Location = new System.Drawing.Point(204, 92);
			this.txtDistLSph.MaxLength = 10;
			this.txtDistLSph.Name = "txtDistLSph";
			this.txtDistLSph.Size = new System.Drawing.Size(40, 19);
			this.txtDistLSph.TabIndex = 30;
			this.txtDistLSph.Text = "";
			// 
			// txtAddLSph
			// 
			this.txtAddLSph.AllowDrop = true;
			this.txtAddLSph.BackColor = System.Drawing.Color.White;
			this.txtAddLSph.ForeColor = System.Drawing.Color.Black;
			this.txtAddLSph.Location = new System.Drawing.Point(204, 111);
			this.txtAddLSph.MaxLength = 10;
			this.txtAddLSph.Name = "txtAddLSph";
			this.txtAddLSph.Size = new System.Drawing.Size(40, 19);
			this.txtAddLSph.TabIndex = 40;
			this.txtAddLSph.Text = "";
			// 
			// txtDistLCyl
			// 
			this.txtDistLCyl.AllowDrop = true;
			this.txtDistLCyl.BackColor = System.Drawing.Color.White;
			this.txtDistLCyl.ForeColor = System.Drawing.Color.Black;
			this.txtDistLCyl.Location = new System.Drawing.Point(244, 92);
			this.txtDistLCyl.MaxLength = 10;
			this.txtDistLCyl.Name = "txtDistLCyl";
			this.txtDistLCyl.Size = new System.Drawing.Size(40, 19);
			this.txtDistLCyl.TabIndex = 31;
			this.txtDistLCyl.Text = "";
			// 
			// txtAddLCyl
			// 
			this.txtAddLCyl.AllowDrop = true;
			this.txtAddLCyl.BackColor = System.Drawing.Color.White;
			this.txtAddLCyl.ForeColor = System.Drawing.Color.Black;
			this.txtAddLCyl.Location = new System.Drawing.Point(244, 111);
			this.txtAddLCyl.MaxLength = 10;
			this.txtAddLCyl.Name = "txtAddLCyl";
			this.txtAddLCyl.Size = new System.Drawing.Size(40, 19);
			this.txtAddLCyl.TabIndex = 41;
			this.txtAddLCyl.Text = "";
			// 
			// txtDistLAxis
			// 
			this.txtDistLAxis.AllowDrop = true;
			this.txtDistLAxis.BackColor = System.Drawing.Color.White;
			this.txtDistLAxis.ForeColor = System.Drawing.Color.Black;
			this.txtDistLAxis.Location = new System.Drawing.Point(284, 92);
			this.txtDistLAxis.MaxLength = 10;
			this.txtDistLAxis.Name = "txtDistLAxis";
			this.txtDistLAxis.Size = new System.Drawing.Size(40, 19);
			this.txtDistLAxis.TabIndex = 32;
			this.txtDistLAxis.Text = "";
			// 
			// txtAddLAxis
			// 
			this.txtAddLAxis.AllowDrop = true;
			this.txtAddLAxis.BackColor = System.Drawing.Color.White;
			this.txtAddLAxis.ForeColor = System.Drawing.Color.Black;
			this.txtAddLAxis.Location = new System.Drawing.Point(284, 111);
			this.txtAddLAxis.MaxLength = 10;
			this.txtAddLAxis.Name = "txtAddLAxis";
			this.txtAddLAxis.Size = new System.Drawing.Size(40, 19);
			this.txtAddLAxis.TabIndex = 42;
			this.txtAddLAxis.Text = "";
			// 
			// txtDistIPD
			// 
			this.txtDistIPD.AllowDrop = true;
			this.txtDistIPD.BackColor = System.Drawing.Color.White;
			this.txtDistIPD.ForeColor = System.Drawing.Color.Black;
			this.txtDistIPD.Location = new System.Drawing.Point(324, 92);
			this.txtDistIPD.MaxLength = 10;
			this.txtDistIPD.Name = "txtDistIPD";
			this.txtDistIPD.Size = new System.Drawing.Size(40, 19);
			this.txtDistIPD.TabIndex = 33;
			this.txtDistIPD.Text = "";
			// 
			// txtAddIPD
			// 
			this.txtAddIPD.AllowDrop = true;
			this.txtAddIPD.BackColor = System.Drawing.Color.White;
			this.txtAddIPD.ForeColor = System.Drawing.Color.Black;
			this.txtAddIPD.Location = new System.Drawing.Point(324, 111);
			this.txtAddIPD.MaxLength = 10;
			this.txtAddIPD.Name = "txtAddIPD";
			this.txtAddIPD.Size = new System.Drawing.Size(40, 19);
			this.txtAddIPD.TabIndex = 43;
			this.txtAddIPD.Text = "";
			// 
			// txtDistSGH
			// 
			this.txtDistSGH.AllowDrop = true;
			this.txtDistSGH.BackColor = System.Drawing.Color.White;
			this.txtDistSGH.ForeColor = System.Drawing.Color.Black;
			this.txtDistSGH.Location = new System.Drawing.Point(364, 92);
			this.txtDistSGH.MaxLength = 10;
			this.txtDistSGH.Name = "txtDistSGH";
			this.txtDistSGH.Size = new System.Drawing.Size(40, 19);
			this.txtDistSGH.TabIndex = 34;
			this.txtDistSGH.Text = "";
			// 
			// txtAddSGH
			// 
			this.txtAddSGH.AllowDrop = true;
			this.txtAddSGH.BackColor = System.Drawing.Color.White;
			this.txtAddSGH.ForeColor = System.Drawing.Color.Black;
			this.txtAddSGH.Location = new System.Drawing.Point(364, 111);
			this.txtAddSGH.MaxLength = 10;
			this.txtAddSGH.Name = "txtAddSGH";
			this.txtAddSGH.Size = new System.Drawing.Size(40, 19);
			this.txtAddSGH.TabIndex = 44;
			this.txtAddSGH.Text = "";
			// 
			// txtDistRLens
			// 
			this.txtDistRLens.AllowDrop = true;
			this.txtDistRLens.BackColor = System.Drawing.Color.White;
			this.txtDistRLens.ForeColor = System.Drawing.Color.Black;
			this.txtDistRLens.Location = new System.Drawing.Point(404, 92);
			this.txtDistRLens.MaxLength = 10;
			this.txtDistRLens.Name = "txtDistRLens";
			this.txtDistRLens.Size = new System.Drawing.Size(40, 19);
			this.txtDistRLens.TabIndex = 35;
			this.txtDistRLens.Text = "";
			// 
			// txtAddRLens
			// 
			this.txtAddRLens.AllowDrop = true;
			this.txtAddRLens.BackColor = System.Drawing.Color.White;
			this.txtAddRLens.ForeColor = System.Drawing.Color.Black;
			this.txtAddRLens.Location = new System.Drawing.Point(404, 111);
			this.txtAddRLens.MaxLength = 10;
			this.txtAddRLens.Name = "txtAddRLens";
			this.txtAddRLens.Size = new System.Drawing.Size(40, 19);
			this.txtAddRLens.TabIndex = 45;
			this.txtAddRLens.Text = "";
			// 
			// txtDistLLens
			// 
			this.txtDistLLens.AllowDrop = true;
			this.txtDistLLens.BackColor = System.Drawing.Color.White;
			this.txtDistLLens.ForeColor = System.Drawing.Color.Black;
			this.txtDistLLens.Location = new System.Drawing.Point(444, 92);
			this.txtDistLLens.MaxLength = 10;
			this.txtDistLLens.Name = "txtDistLLens";
			this.txtDistLLens.Size = new System.Drawing.Size(40, 19);
			this.txtDistLLens.TabIndex = 36;
			this.txtDistLLens.Text = "";
			// 
			// txtAddLLens
			// 
			this.txtAddLLens.AllowDrop = true;
			this.txtAddLLens.BackColor = System.Drawing.Color.White;
			this.txtAddLLens.ForeColor = System.Drawing.Color.Black;
			this.txtAddLLens.Location = new System.Drawing.Point(444, 111);
			this.txtAddLLens.MaxLength = 10;
			this.txtAddLLens.Name = "txtAddLLens";
			this.txtAddLLens.Size = new System.Drawing.Size(40, 19);
			this.txtAddLLens.TabIndex = 46;
			this.txtAddLLens.Text = "";
			// 
			// txtDistRSph
			// 
			this.txtDistRSph.AllowDrop = true;
			this.txtDistRSph.BackColor = System.Drawing.Color.White;
			this.txtDistRSph.ForeColor = System.Drawing.Color.Black;
			this.txtDistRSph.Location = new System.Drawing.Point(84, 92);
			this.txtDistRSph.MaxLength = 10;
			this.txtDistRSph.Name = "txtDistRSph";
			this.txtDistRSph.Size = new System.Drawing.Size(40, 19);
			this.txtDistRSph.TabIndex = 27;
			this.txtDistRSph.Text = "";
			// 
			// System.Windows.Forms.Label5
			// 
			this.Label5.AllowDrop = true;
			this.Label5.BackColor = System.Drawing.SystemColors.Window;
			this.Label5.Text = "Old Prescription";
			this.Label5.Enabled = false;
			this.Label5.ForeColor = System.Drawing.SystemColors.WindowText;
			this.Label5.Location = new System.Drawing.Point(14, 142);
			this.Label5.Name="Label5";
			this.Label5.Size = new System.Drawing.Size(92, 15);
			this.Label5.TabIndex = 116;
			// 
			// Line5
			// 
			this.Line5.AllowDrop = true;
			this.Line5.BackColor = System.Drawing.SystemColors.WindowText;
			this.Line5.Enabled = false;
			this.Line5.Location = new System.Drawing.Point(10, 160);
			this.Line5.Name = "Line5";
			this.Line5.Size = new System.Drawing.Size(96, 1);
			this.Line5.Visible = true;
			// 
			// Line4
			// 
			this.Line4.AllowDrop = true;
			this.Line4.BackColor = System.Drawing.SystemColors.WindowText;
			this.Line4.Enabled = false;
			this.Line4.Location = new System.Drawing.Point(10, 158);
			this.Line4.Name = "Line4";
			this.Line4.Size = new System.Drawing.Size(96, 1);
			this.Line4.Visible = true;
			// 
			// Line3
			// 
			this.Line3.AllowDrop = true;
			this.Line3.BackColor = System.Drawing.SystemColors.WindowText;
			this.Line3.Enabled = false;
			this.Line3.Location = new System.Drawing.Point(12, 40);
			this.Line3.Name = "Line3";
			this.Line3.Size = new System.Drawing.Size(102, 1);
			this.Line3.Visible = true;
			// 
			// Line2
			// 
			this.Line2.AllowDrop = true;
			this.Line2.BackColor = System.Drawing.SystemColors.WindowText;
			this.Line2.Enabled = false;
			this.Line2.Location = new System.Drawing.Point(10, 136);
			this.Line2.Name = "Line2";
			this.Line2.Size = new System.Drawing.Size(486, 1);
			this.Line2.Visible = true;
			// 
			// Line1
			// 
			this.Line1.AllowDrop = true;
			this.Line1.BackColor = System.Drawing.SystemColors.WindowText;
			this.Line1.Enabled = false;
			this.Line1.Location = new System.Drawing.Point(12, 38);
			this.Line1.Name = "Line1";
			this.Line1.Size = new System.Drawing.Size(102, 1);
			this.Line1.Visible = true;
			// 
			// _lblDocDetails_14
			// 
			this._lblDocDetails_14.AllowDrop = true;
			this._lblDocDetails_14.BackColor = System.Drawing.SystemColors.Control;
			this._lblDocDetails_14.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this._lblDocDetails_14.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lblDocDetails_14.Location = new System.Drawing.Point(14, 112);
			this._lblDocDetails_14.Name = "_lblDocDetails_14";
			this._lblDocDetails_14.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblDocDetails_14.Size = new System.Drawing.Size(73, 19);
			this._lblDocDetails_14.TabIndex = 92;
			this._lblDocDetails_14.Text = "Reading/Add";
			this._lblDocDetails_14.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// _lblDocDetails_13
			// 
			this._lblDocDetails_13.AllowDrop = true;
			this._lblDocDetails_13.BackColor = System.Drawing.SystemColors.Control;
			this._lblDocDetails_13.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this._lblDocDetails_13.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lblDocDetails_13.Location = new System.Drawing.Point(84, 72);
			this._lblDocDetails_13.Name = "_lblDocDetails_13";
			this._lblDocDetails_13.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblDocDetails_13.Size = new System.Drawing.Size(40, 19);
			this._lblDocDetails_13.TabIndex = 91;
			this._lblDocDetails_13.Text = "SPH";
			this._lblDocDetails_13.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// _lblDocDetails_12
			// 
			this._lblDocDetails_12.AllowDrop = true;
			this._lblDocDetails_12.BackColor = System.Drawing.SystemColors.Control;
			this._lblDocDetails_12.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this._lblDocDetails_12.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lblDocDetails_12.Location = new System.Drawing.Point(124, 72);
			this._lblDocDetails_12.Name = "_lblDocDetails_12";
			this._lblDocDetails_12.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblDocDetails_12.Size = new System.Drawing.Size(40, 19);
			this._lblDocDetails_12.TabIndex = 90;
			this._lblDocDetails_12.Text = "CYL";
			this._lblDocDetails_12.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// _lblDocDetails_11
			// 
			this._lblDocDetails_11.AllowDrop = true;
			this._lblDocDetails_11.BackColor = System.Drawing.SystemColors.Control;
			this._lblDocDetails_11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this._lblDocDetails_11.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lblDocDetails_11.Location = new System.Drawing.Point(164, 72);
			this._lblDocDetails_11.Name = "_lblDocDetails_11";
			this._lblDocDetails_11.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblDocDetails_11.Size = new System.Drawing.Size(40, 19);
			this._lblDocDetails_11.TabIndex = 89;
			this._lblDocDetails_11.Text = "AXIS";
			this._lblDocDetails_11.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// _lblDocDetails_10
			// 
			this._lblDocDetails_10.AllowDrop = true;
			this._lblDocDetails_10.BackColor = System.Drawing.SystemColors.Control;
			this._lblDocDetails_10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this._lblDocDetails_10.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lblDocDetails_10.Location = new System.Drawing.Point(204, 72);
			this._lblDocDetails_10.Name = "_lblDocDetails_10";
			this._lblDocDetails_10.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblDocDetails_10.Size = new System.Drawing.Size(40, 19);
			this._lblDocDetails_10.TabIndex = 88;
			this._lblDocDetails_10.Text = "SPH";
			this._lblDocDetails_10.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// _lblDocDetails_9
			// 
			this._lblDocDetails_9.AllowDrop = true;
			this._lblDocDetails_9.BackColor = System.Drawing.SystemColors.Control;
			this._lblDocDetails_9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this._lblDocDetails_9.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lblDocDetails_9.Location = new System.Drawing.Point(244, 72);
			this._lblDocDetails_9.Name = "_lblDocDetails_9";
			this._lblDocDetails_9.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblDocDetails_9.Size = new System.Drawing.Size(40, 19);
			this._lblDocDetails_9.TabIndex = 87;
			this._lblDocDetails_9.Text = "CYL";
			this._lblDocDetails_9.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// _lblDocDetails_8
			// 
			this._lblDocDetails_8.AllowDrop = true;
			this._lblDocDetails_8.BackColor = System.Drawing.SystemColors.Control;
			this._lblDocDetails_8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this._lblDocDetails_8.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lblDocDetails_8.Location = new System.Drawing.Point(284, 72);
			this._lblDocDetails_8.Name = "_lblDocDetails_8";
			this._lblDocDetails_8.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblDocDetails_8.Size = new System.Drawing.Size(40, 19);
			this._lblDocDetails_8.TabIndex = 86;
			this._lblDocDetails_8.Text = "AXIS";
			this._lblDocDetails_8.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// _lblDocDetails_7
			// 
			this._lblDocDetails_7.AllowDrop = true;
			this._lblDocDetails_7.BackColor = System.Drawing.SystemColors.Control;
			this._lblDocDetails_7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this._lblDocDetails_7.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lblDocDetails_7.Location = new System.Drawing.Point(324, 72);
			this._lblDocDetails_7.Name = "_lblDocDetails_7";
			this._lblDocDetails_7.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblDocDetails_7.Size = new System.Drawing.Size(40, 19);
			this._lblDocDetails_7.TabIndex = 85;
			this._lblDocDetails_7.Text = "I.P.D.";
			this._lblDocDetails_7.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// _lblDocDetails_6
			// 
			this._lblDocDetails_6.AllowDrop = true;
			this._lblDocDetails_6.BackColor = System.Drawing.SystemColors.Control;
			this._lblDocDetails_6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this._lblDocDetails_6.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lblDocDetails_6.Location = new System.Drawing.Point(364, 72);
			this._lblDocDetails_6.Name = "_lblDocDetails_6";
			this._lblDocDetails_6.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblDocDetails_6.Size = new System.Drawing.Size(40, 19);
			this._lblDocDetails_6.TabIndex = 84;
			this._lblDocDetails_6.Text = "SGH";
			this._lblDocDetails_6.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// _lblDocDetails_5
			// 
			this._lblDocDetails_5.AllowDrop = true;
			this._lblDocDetails_5.BackColor = System.Drawing.SystemColors.Control;
			this._lblDocDetails_5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this._lblDocDetails_5.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lblDocDetails_5.Location = new System.Drawing.Point(444, 72);
			this._lblDocDetails_5.Name = "_lblDocDetails_5";
			this._lblDocDetails_5.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblDocDetails_5.Size = new System.Drawing.Size(40, 19);
			this._lblDocDetails_5.TabIndex = 83;
			this._lblDocDetails_5.Text = "L EYE";
			this._lblDocDetails_5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// _lblDocDetails_4
			// 
			this._lblDocDetails_4.AllowDrop = true;
			this._lblDocDetails_4.BackColor = System.Drawing.SystemColors.Control;
			this._lblDocDetails_4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this._lblDocDetails_4.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lblDocDetails_4.Location = new System.Drawing.Point(404, 72);
			this._lblDocDetails_4.Name = "_lblDocDetails_4";
			this._lblDocDetails_4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblDocDetails_4.Size = new System.Drawing.Size(40, 19);
			this._lblDocDetails_4.TabIndex = 82;
			this._lblDocDetails_4.Text = "R EYE";
			this._lblDocDetails_4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// _lblDocDetails_3
			// 
			this._lblDocDetails_3.AllowDrop = true;
			this._lblDocDetails_3.BackColor = System.Drawing.SystemColors.Control;
			this._lblDocDetails_3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this._lblDocDetails_3.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lblDocDetails_3.Location = new System.Drawing.Point(84, 52);
			this._lblDocDetails_3.Name = "_lblDocDetails_3";
			this._lblDocDetails_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblDocDetails_3.Size = new System.Drawing.Size(120, 19);
			this._lblDocDetails_3.TabIndex = 81;
			this._lblDocDetails_3.Text = "RIGHT EYE";
			this._lblDocDetails_3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// _lblDocDetails_2
			// 
			this._lblDocDetails_2.AllowDrop = true;
			this._lblDocDetails_2.BackColor = System.Drawing.SystemColors.Control;
			this._lblDocDetails_2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this._lblDocDetails_2.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lblDocDetails_2.Location = new System.Drawing.Point(204, 52);
			this._lblDocDetails_2.Name = "_lblDocDetails_2";
			this._lblDocDetails_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblDocDetails_2.Size = new System.Drawing.Size(121, 19);
			this._lblDocDetails_2.TabIndex = 80;
			this._lblDocDetails_2.Text = "LEFT EYE";
			this._lblDocDetails_2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// _lblDocDetails_0
			// 
			this._lblDocDetails_0.AllowDrop = true;
			this._lblDocDetails_0.BackColor = System.Drawing.SystemColors.Control;
			this._lblDocDetails_0.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this._lblDocDetails_0.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lblDocDetails_0.Location = new System.Drawing.Point(404, 52);
			this._lblDocDetails_0.Name = "_lblDocDetails_0";
			this._lblDocDetails_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblDocDetails_0.Size = new System.Drawing.Size(81, 19);
			this._lblDocDetails_0.TabIndex = 79;
			this._lblDocDetails_0.Text = "Contact LENS";
			this._lblDocDetails_0.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// _lblDocDetails_1
			// 
			this._lblDocDetails_1.AllowDrop = true;
			this._lblDocDetails_1.BackColor = System.Drawing.SystemColors.Control;
			this._lblDocDetails_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this._lblDocDetails_1.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lblDocDetails_1.Location = new System.Drawing.Point(14, 92);
			this._lblDocDetails_1.Name = "_lblDocDetails_1";
			this._lblDocDetails_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblDocDetails_1.Size = new System.Drawing.Size(73, 19);
			this._lblDocDetails_1.TabIndex = 78;
			this._lblDocDetails_1.Text = "Distance";
			this._lblDocDetails_1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// Shape1
			// 
			this.Shape1.AllowDrop = true;
			this.Shape1.BackColor = System.Drawing.SystemColors.Window;
			// = 0;
			//
			this.Shape1.Enabled = false;
			//this.Shape1.FillColor = System.Drawing.Color.Black;
			//this.Shape1.FillStyle = 1;
			this.Shape1.Location = new System.Drawing.Point(10, 6);
			this.Shape1.Name = "Shape1";
			this.Shape1.Size = new System.Drawing.Size(487, 387);
			this.Shape1.Visible = true;
			// 
			// _comCommon_10
			// 
			this._comCommon_10.AllowDrop = true;
			this._comCommon_10.Location = new System.Drawing.Point(108, 266);
			this._comCommon_10.Name = "_comCommon_10";
			this._comCommon_10.Size = new System.Drawing.Size(101, 21);
			this._comCommon_10.TabIndex = 105;
			// 
			// _lblCommonLabel_27
			// 
			this._lblCommonLabel_27.AllowDrop = true;
			this._lblCommonLabel_27.BackColor = System.Drawing.SystemColors.Window;
			this._lblCommonLabel_27.Text = "Flex 10";
			this._lblCommonLabel_27.Location = new System.Drawing.Point(62, 268);
			this._lblCommonLabel_27.Name = "_lblCommonLabel_27";
			this._lblCommonLabel_27.Size = new System.Drawing.Size(35, 14);
			this._lblCommonLabel_27.TabIndex = 106;
			// 
			// frmICSAdditionalVoucherDetails
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.ClientSize = new System.Drawing.Size(508, 452);
			this.Controls.Add(this._UCOkCancel1_14);
			this.Controls.Add(this.tabMaster);
			this.Controls.Add(this._comCommon_10);
			this.Controls.Add(this._lblCommonLabel_27);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			//this.Icon = (System.Drawing.Icon) resources.GetObject("frmICSAdditionalVoucherDetails.Icon");
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(247, 191);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmICSAdditionalVoucherDetails";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.ShowInTaskbar = false;
			this.Text = "Additional Details";
			this.ToolTipMain.SetToolTip(this.txtLdgrName, "Salesman Name in English");
			// this.Activated += new System.EventHandler(this.frmICSAdditionalVoucherDetails_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
			// this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
			//((System.ComponentModel.ISupportInitialize) this.tabMaster).EndInit();
			this.tabMaster.ResumeLayout(false);
			this._fraMasterInformation_2.ResumeLayout(false);
			this._fraMasterInformation_1.ResumeLayout(false);
			this._fraMasterInformation_0.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		// 
		void InitializetxtCommonTextBox()
		{
			this.txtCommonTextBox = new System.Windows.Forms.TextBox[2];
			this.txtCommonTextBox[1] = _txtCommonTextBox_1;
		}
		void InitializelblDocDetails()
		{
			this.lblDocDetails = new System.Windows.Forms.Label[15];
			this.lblDocDetails[14] = _lblDocDetails_14;
			this.lblDocDetails[13] = _lblDocDetails_13;
			this.lblDocDetails[12] = _lblDocDetails_12;
			this.lblDocDetails[11] = _lblDocDetails_11;
			this.lblDocDetails[10] = _lblDocDetails_10;
			this.lblDocDetails[9] = _lblDocDetails_9;
			this.lblDocDetails[8] = _lblDocDetails_8;
			this.lblDocDetails[7] = _lblDocDetails_7;
			this.lblDocDetails[6] = _lblDocDetails_6;
			this.lblDocDetails[5] = _lblDocDetails_5;
			this.lblDocDetails[4] = _lblDocDetails_4;
			this.lblDocDetails[3] = _lblDocDetails_3;
			this.lblDocDetails[2] = _lblDocDetails_2;
			this.lblDocDetails[0] = _lblDocDetails_0;
			this.lblDocDetails[1] = _lblDocDetails_1;
		}
		void InitializelblCommonLabel()
		{
			this.lblCommonLabel = new System.Windows.Forms.Label[32];
			this.lblCommonLabel[22] = _lblCommonLabel_22;
			this.lblCommonLabel[23] = _lblCommonLabel_23;
			this.lblCommonLabel[24] = _lblCommonLabel_24;
			this.lblCommonLabel[25] = _lblCommonLabel_25;
			this.lblCommonLabel[26] = _lblCommonLabel_26;
			this.lblCommonLabel[28] = _lblCommonLabel_28;
			this.lblCommonLabel[29] = _lblCommonLabel_29;
			this.lblCommonLabel[30] = _lblCommonLabel_30;
			this.lblCommonLabel[31] = _lblCommonLabel_31;
			this.lblCommonLabel[7] = _lblCommonLabel_7;
			this.lblCommonLabel[6] = _lblCommonLabel_6;
			this.lblCommonLabel[8] = _lblCommonLabel_8;
			this.lblCommonLabel[5] = _lblCommonLabel_5;
			this.lblCommonLabel[1] = _lblCommonLabel_1;
			this.lblCommonLabel[2] = _lblCommonLabel_2;
			this.lblCommonLabel[4] = _lblCommonLabel_4;
			this.lblCommonLabel[9] = _lblCommonLabel_9;
			this.lblCommonLabel[10] = _lblCommonLabel_10;
			this.lblCommonLabel[11] = _lblCommonLabel_11;
			this.lblCommonLabel[3] = _lblCommonLabel_3;
			this.lblCommonLabel[0] = _lblCommonLabel_0;
			this.lblCommonLabel[12] = _lblCommonLabel_12;
			this.lblCommonLabel[13] = _lblCommonLabel_13;
			this.lblCommonLabel[14] = _lblCommonLabel_14;
			this.lblCommonLabel[15] = _lblCommonLabel_15;
			this.lblCommonLabel[16] = _lblCommonLabel_16;
			this.lblCommonLabel[17] = _lblCommonLabel_17;
			this.lblCommonLabel[18] = _lblCommonLabel_18;
			this.lblCommonLabel[20] = _lblCommonLabel_20;
			this.lblCommonLabel[19] = _lblCommonLabel_19;
			this.lblCommonLabel[21] = _lblCommonLabel_21;
			this.lblCommonLabel[27] = _lblCommonLabel_27;
		}
		void InitializefraMasterInformation()
		{
			this.fraMasterInformation = new System.Windows.Forms.Panel[3];
			this.fraMasterInformation[2] = _fraMasterInformation_2;
			this.fraMasterInformation[1] = _fraMasterInformation_1;
			this.fraMasterInformation[0] = _fraMasterInformation_0;
		}
		void InitializecomCommon()
		{
			this.comCommon = new System.Windows.Forms.ComboBox[15];
			this.comCommon[0] = _comCommon_0;
			this.comCommon[6] = _comCommon_6;
			this.comCommon[7] = _comCommon_7;
			this.comCommon[8] = _comCommon_8;
			this.comCommon[9] = _comCommon_9;
			this.comCommon[11] = _comCommon_11;
			this.comCommon[12] = _comCommon_12;
			this.comCommon[13] = _comCommon_13;
			this.comCommon[14] = _comCommon_14;
			this.comCommon[1] = _comCommon_1;
			this.comCommon[2] = _comCommon_2;
			this.comCommon[3] = _comCommon_3;
			this.comCommon[4] = _comCommon_4;
			this.comCommon[5] = _comCommon_5;
			this.comCommon[10] = _comCommon_10;
		}
		void InitializeUCOkCancel1()
		{
			this.UCOkCancel1 = new UCOkCancel[15];
			this.UCOkCancel1[14] = _UCOkCancel1_14;
		}
		#endregion
	}
}//ENDSHERE
