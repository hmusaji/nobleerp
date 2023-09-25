
namespace Xtreme
{
	partial class frmICSItemDimention
	{

		#region "Upgrade Support "
		private static frmICSItemDimention m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmICSItemDimention DefInstance
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
		public static frmICSItemDimention CreateInstance()
		{
			frmICSItemDimention theInstance = new frmICSItemDimention();
			
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
		//private string[] visualControls = new string[]{"components", "ToolTipMain", "TabControlPage2", "_cmdCommon_0", "_cmdCommon_2", "_cmdCommon_1", "txtComment", "_txtCommon_6", "_txtCommon_5", "_lblCommon_6", "_lblCommon_7", "_lblCommon_10", "_txtCommonDisplay_1", "_txtCommonDisplay_2", "_txtCommon_4", "_lblCommon_5", "_txtCommonDisplay_0", "_txtCommon_3", "_lblCommon_50", "_txtCommonDisplay_5", "TabControlPage1", "TabControl1", "txtProdDesc", "_txtCommon_2", "_txtCommon_0", "_lblCommon_3", "_lblCommon_1", "_txtCommon_1", "_lblCommon_2", "_lblCommon_0", "_cmbCommon_0", "_lblCommon_8", "cmbCommon", "cmdCommon", "lblCommon", "txtCommon", "txtCommonDisplay"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public AxXtremeSuiteControls.AxTabControlPage TabControlPage2;
		private System.Windows.Forms.Button _cmdCommon_0;
		private System.Windows.Forms.Button _cmdCommon_2;
		private System.Windows.Forms.Button _cmdCommon_1;
		public System.Windows.Forms.TextBox txtComment;
		private System.Windows.Forms.TextBox _txtCommon_6;
		private System.Windows.Forms.TextBox _txtCommon_5;
		private System.Windows.Forms.Label _lblCommon_6;
		private System.Windows.Forms.Label _lblCommon_7;
		private System.Windows.Forms.Label _lblCommon_10;
		private System.Windows.Forms.Label _txtCommonDisplay_1;
		private System.Windows.Forms.Label _txtCommonDisplay_2;
		private System.Windows.Forms.TextBox _txtCommon_4;
		private System.Windows.Forms.Label _lblCommon_5;
		private System.Windows.Forms.Label _txtCommonDisplay_0;
		private System.Windows.Forms.TextBox _txtCommon_3;
		private System.Windows.Forms.Label _lblCommon_50;
		private System.Windows.Forms.Label _txtCommonDisplay_5;
		public AxXtremeSuiteControls.AxTabControlPage TabControlPage1;
		public AxXtremeSuiteControls.AxTabControl TabControl1;
		public System.Windows.Forms.TextBox txtProdDesc;
		private System.Windows.Forms.TextBox _txtCommon_2;
		private System.Windows.Forms.TextBox _txtCommon_0;
		private System.Windows.Forms.Label _lblCommon_3;
		private System.Windows.Forms.Label _lblCommon_1;
		private System.Windows.Forms.TextBox _txtCommon_1;
		private System.Windows.Forms.Label _lblCommon_2;
		private System.Windows.Forms.Label _lblCommon_0;
		private System.Windows.Forms.ComboBox _cmbCommon_0;
		private System.Windows.Forms.Label _lblCommon_8;
		public System.Windows.Forms.ComboBox[] cmbCommon = new System.Windows.Forms.ComboBox[1];
		public System.Windows.Forms.Button[] cmdCommon = new System.Windows.Forms.Button[3];
		public System.Windows.Forms.Label[] lblCommon = new System.Windows.Forms.Label[51];
		public System.Windows.Forms.TextBox[] txtCommon = new System.Windows.Forms.TextBox[7];
		public System.Windows.Forms.Label[] txtCommonDisplay = new System.Windows.Forms.Label[6];
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmICSItemDimention));
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this.TabControl1 = new AxXtremeSuiteControls.AxTabControl();
			this.TabControlPage2 = new AxXtremeSuiteControls.AxTabControlPage();
			this.TabControlPage1 = new AxXtremeSuiteControls.AxTabControlPage();
			this._cmdCommon_0 = new System.Windows.Forms.Button();
			this._cmdCommon_2 = new System.Windows.Forms.Button();
			this._cmdCommon_1 = new System.Windows.Forms.Button();
			this.txtComment = new System.Windows.Forms.TextBox();
			this._txtCommon_6 = new System.Windows.Forms.TextBox();
			this._txtCommon_5 = new System.Windows.Forms.TextBox();
			this._lblCommon_6 = new System.Windows.Forms.Label();
			this._lblCommon_7 = new System.Windows.Forms.Label();
			this._lblCommon_10 = new System.Windows.Forms.Label();
			this._txtCommonDisplay_1 = new System.Windows.Forms.Label();
			this._txtCommonDisplay_2 = new System.Windows.Forms.Label();
			this._txtCommon_4 = new System.Windows.Forms.TextBox();
			this._lblCommon_5 = new System.Windows.Forms.Label();
			this._txtCommonDisplay_0 = new System.Windows.Forms.Label();
			this._txtCommon_3 = new System.Windows.Forms.TextBox();
			this._lblCommon_50 = new System.Windows.Forms.Label();
			this._txtCommonDisplay_5 = new System.Windows.Forms.Label();
			this.txtProdDesc = new System.Windows.Forms.TextBox();
			this._txtCommon_2 = new System.Windows.Forms.TextBox();
			this._txtCommon_0 = new System.Windows.Forms.TextBox();
			this._lblCommon_3 = new System.Windows.Forms.Label();
			this._lblCommon_1 = new System.Windows.Forms.Label();
			this._txtCommon_1 = new System.Windows.Forms.TextBox();
			this._lblCommon_2 = new System.Windows.Forms.Label();
			this._lblCommon_0 = new System.Windows.Forms.Label();
			this._cmbCommon_0 = new System.Windows.Forms.ComboBox();
			this._lblCommon_8 = new System.Windows.Forms.Label();
			// //((System.ComponentModel.ISupportInitialize) this.TabControlPage2).BeginInit();
			// //((System.ComponentModel.ISupportInitialize) this.TabControlPage1).BeginInit();
			// //((System.ComponentModel.ISupportInitialize) this.TabControl1).BeginInit();
			this.TabControl1.SuspendLayout();
			this.TabControlPage1.SuspendLayout();
			this.SuspendLayout();
			// 
			// TabControl1
			// 
			this.TabControl1.AllowDrop = true;
			this.TabControl1.Controls.Add(this.TabControlPage2);
			this.TabControl1.Controls.Add(this.TabControlPage1);
			this.TabControl1.Location = new System.Drawing.Point(8, 182);
			this.TabControl1.Name = "TabControl1";
			("TabControl1.OcxState");
			this.TabControl1.Size = new System.Drawing.Size(765, 239);
			this.TabControl1.TabIndex = 10;
			// 
			// TabControlPage2
			// 
			this.TabControlPage2.AllowDrop = true;
			this.TabControlPage2.Location = new System.Drawing.Point(-4664, 28);
			this.TabControlPage2.Name = "TabControlPage2";
			("TabControlPage2.OcxState");
			this.TabControlPage2.Size = new System.Drawing.Size(761, 251);
			this.TabControlPage2.TabIndex = 12;
			this.TabControlPage2.Visible = false;
			// 
			// TabControlPage1
			// 
			this.TabControlPage1.AllowDrop = true;
			this.TabControlPage1.Controls.Add(this._cmdCommon_0);
			this.TabControlPage1.Controls.Add(this._cmdCommon_2);
			this.TabControlPage1.Controls.Add(this._cmdCommon_1);
			this.TabControlPage1.Controls.Add(this.txtComment);
			this.TabControlPage1.Controls.Add(this._txtCommon_6);
			this.TabControlPage1.Controls.Add(this._txtCommon_5);
			this.TabControlPage1.Controls.Add(this._lblCommon_6);
			this.TabControlPage1.Controls.Add(this._lblCommon_7);
			this.TabControlPage1.Controls.Add(this._lblCommon_10);
			this.TabControlPage1.Controls.Add(this._txtCommonDisplay_1);
			this.TabControlPage1.Controls.Add(this._txtCommonDisplay_2);
			this.TabControlPage1.Controls.Add(this._txtCommon_4);
			this.TabControlPage1.Controls.Add(this._lblCommon_5);
			this.TabControlPage1.Controls.Add(this._txtCommonDisplay_0);
			this.TabControlPage1.Controls.Add(this._txtCommon_3);
			this.TabControlPage1.Controls.Add(this._lblCommon_50);
			this.TabControlPage1.Controls.Add(this._txtCommonDisplay_5);
			this.TabControlPage1.Location = new System.Drawing.Point(2, 28);
			this.TabControlPage1.Name = "TabControlPage1";
			("TabControlPage1.OcxState");
			this.TabControlPage1.Size = new System.Drawing.Size(761, 209);
			this.TabControlPage1.TabIndex = 11;
			// 
			// _cmdCommon_0
			// 
			this._cmdCommon_0.AllowDrop = true;
			this._cmdCommon_0.BackColor = System.Drawing.SystemColors.Control;
			this._cmdCommon_0.ForeColor = System.Drawing.SystemColors.ControlText;
			this._cmdCommon_0.Location = new System.Drawing.Point(400, 50);
			this._cmdCommon_0.Name = "_cmdCommon_0";
			this._cmdCommon_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._cmdCommon_0.Size = new System.Drawing.Size(21, 21);
			this._cmdCommon_0.TabIndex = 16;
			this._cmdCommon_0.TabStop = false;
			this._cmdCommon_0.Text = "&...";
			this._cmdCommon_0.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this._cmdCommon_0.UseVisualStyleBackColor = false;
			this._cmdCommon_0.Visible = false;
			// 
			// _cmdCommon_2
			// 
			this._cmdCommon_2.AllowDrop = true;
			this._cmdCommon_2.BackColor = System.Drawing.SystemColors.Control;
			this._cmdCommon_2.ForeColor = System.Drawing.SystemColors.ControlText;
			this._cmdCommon_2.Location = new System.Drawing.Point(400, 29);
			this._cmdCommon_2.Name = "_cmdCommon_2";
			this._cmdCommon_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._cmdCommon_2.Size = new System.Drawing.Size(20, 20);
			this._cmdCommon_2.TabIndex = 15;
			this._cmdCommon_2.TabStop = false;
			this._cmdCommon_2.Text = "...";
			this._cmdCommon_2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this._cmdCommon_2.UseVisualStyleBackColor = false;
			// 
			// _cmdCommon_1
			// 
			this._cmdCommon_1.AllowDrop = true;
			this._cmdCommon_1.BackColor = System.Drawing.SystemColors.Control;
			this._cmdCommon_1.ForeColor = System.Drawing.SystemColors.ControlText;
			this._cmdCommon_1.Location = new System.Drawing.Point(400, 8);
			this._cmdCommon_1.Name = "_cmdCommon_1";
			this._cmdCommon_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._cmdCommon_1.Size = new System.Drawing.Size(20, 20);
			this._cmdCommon_1.TabIndex = 14;
			this._cmdCommon_1.TabStop = false;
			this._cmdCommon_1.Text = "...";
			this._cmdCommon_1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this._cmdCommon_1.UseVisualStyleBackColor = false;
			// 
			// txtComment
			// 
			this.txtComment.AllowDrop = true;
			this.txtComment.BackColor = System.Drawing.Color.White;
			// this.txtComment.bolAllowDecimal = false;
			this.txtComment.ForeColor = System.Drawing.Color.Black;
			this.txtComment.Location = new System.Drawing.Point(94, 100);
			// this.txtComment.mDropDownType = (System.Windows.Forms.TextBox.FormatBoxDropDownTypes) 0;
			this.txtComment.Name = "txtComment";
			this.txtComment.Size = new System.Drawing.Size(364, 75);
			this.txtComment.TabIndex = 13;
			this.txtComment.Text = "";
			// 
			// _txtCommon_6
			// 
			this._txtCommon_6.AllowDrop = true;
			this._txtCommon_6.BackColor = System.Drawing.Color.White;
			// this.this._txtCommon_6.bolIsRequired = true;
			// this._txtCommon_6.bolNumericOnly = true;
			this._txtCommon_6.ForeColor = System.Drawing.Color.Black;
			this._txtCommon_6.Location = new System.Drawing.Point(94, 30);
			this._txtCommon_6.MaxLength = 15;
			this._txtCommon_6.Name = "_txtCommon_6";
			// this._txtCommon_6.ShowButton = true;
			this._txtCommon_6.Size = new System.Drawing.Size(101, 19);
			this._txtCommon_6.TabIndex = 17;
			this._txtCommon_6.Text = "";
			this._txtCommon_6.Visible = false;
			// this.this._txtCommon_6.Watermark = "Category";
			// 
			// _txtCommon_5
			// 
			this._txtCommon_5.AllowDrop = true;
			this._txtCommon_5.BackColor = System.Drawing.Color.White;
			// this.this._txtCommon_5.bolIsRequired = true;
			// this._txtCommon_5.bolNumericOnly = true;
			this._txtCommon_5.ForeColor = System.Drawing.Color.Black;
			this._txtCommon_5.Location = new System.Drawing.Point(94, 9);
			this._txtCommon_5.MaxLength = 15;
			this._txtCommon_5.Name = "_txtCommon_5";
			// this._txtCommon_5.ShowButton = true;
			this._txtCommon_5.Size = new System.Drawing.Size(101, 19);
			this._txtCommon_5.TabIndex = 18;
			this._txtCommon_5.Text = "";
			this._txtCommon_5.Visible = false;
			// this.this._txtCommon_5.Watermark = "Group";
			// 
			// _lblCommon_6
			// 
			this._lblCommon_6.AllowDrop = true;
			this._lblCommon_6.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_6.Text = "Group Code";
			this._lblCommon_6.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_6.Location = new System.Drawing.Point(8, 11);
			// this._lblCommon_6.mLabelId = 301;
			this._lblCommon_6.Name = "_lblCommon_6";
			this._lblCommon_6.Size = new System.Drawing.Size(58, 14);
			this._lblCommon_6.TabIndex = 19;
			this._lblCommon_6.Visible = false;
			// 
			// _lblCommon_7
			// 
			this._lblCommon_7.AllowDrop = true;
			this._lblCommon_7.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_7.Text = "Category Code";
			this._lblCommon_7.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_7.Location = new System.Drawing.Point(8, 32);
			// this._lblCommon_7.mLabelId = 116;
			this._lblCommon_7.Name = "_lblCommon_7";
			this._lblCommon_7.Size = new System.Drawing.Size(72, 14);
			this._lblCommon_7.TabIndex = 20;
			this._lblCommon_7.Visible = false;
			// 
			// _lblCommon_10
			// 
			this._lblCommon_10.AllowDrop = true;
			this._lblCommon_10.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_10.Text = "Comments";
			this._lblCommon_10.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_10.Location = new System.Drawing.Point(8, 100);
			// this._lblCommon_10.mLabelId = 135;
			this._lblCommon_10.Name = "_lblCommon_10";
			this._lblCommon_10.Size = new System.Drawing.Size(50, 14);
			this._lblCommon_10.TabIndex = 21;
			// 
			// _txtCommonDisplay_1
			// 
			this._txtCommonDisplay_1.AllowDrop = true;
			this._txtCommonDisplay_1.Location = new System.Drawing.Point(197, 9);
			this._txtCommonDisplay_1.Name = "_txtCommonDisplay_1";
			this._txtCommonDisplay_1.Size = new System.Drawing.Size(201, 19);
			this._txtCommonDisplay_1.TabIndex = 22;
			this._txtCommonDisplay_1.TabStop = false;
			this._txtCommonDisplay_1.Visible = false;
			// 
			// _txtCommonDisplay_2
			// 
			this._txtCommonDisplay_2.AllowDrop = true;
			this._txtCommonDisplay_2.Location = new System.Drawing.Point(197, 30);
			this._txtCommonDisplay_2.Name = "_txtCommonDisplay_2";
			this._txtCommonDisplay_2.Size = new System.Drawing.Size(201, 19);
			this._txtCommonDisplay_2.TabIndex = 23;
			this._txtCommonDisplay_2.TabStop = false;
			this._txtCommonDisplay_2.Visible = false;
			// 
			// _txtCommon_4
			// 
			this._txtCommon_4.AllowDrop = true;
			this._txtCommon_4.BackColor = System.Drawing.Color.White;
			// this.this._txtCommon_4.bolIsRequired = true;
			// this._txtCommon_4.bolNumericOnly = true;
			this._txtCommon_4.ForeColor = System.Drawing.Color.Black;
			this._txtCommon_4.Location = new System.Drawing.Point(94, 52);
			this._txtCommon_4.MaxLength = 15;
			this._txtCommon_4.Name = "_txtCommon_4";
			// this._txtCommon_4.ShowButton = true;
			this._txtCommon_4.Size = new System.Drawing.Size(101, 19);
			this._txtCommon_4.TabIndex = 24;
			this._txtCommon_4.Text = "";
			this._txtCommon_4.Visible = false;
			// this.this._txtCommon_4.Watermark = "UOM";
			// 
			// _lblCommon_5
			// 
			this._lblCommon_5.AllowDrop = true;
			this._lblCommon_5.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_5.Text = "Base Unit";
			this._lblCommon_5.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_5.Location = new System.Drawing.Point(8, 54);
			// this._lblCommon_5.mLabelId = 91;
			this._lblCommon_5.Name = "_lblCommon_5";
			this._lblCommon_5.Size = new System.Drawing.Size(46, 14);
			this._lblCommon_5.TabIndex = 25;
			this._lblCommon_5.Visible = false;
			// 
			// _txtCommonDisplay_0
			// 
			this._txtCommonDisplay_0.AllowDrop = true;
			this._txtCommonDisplay_0.Location = new System.Drawing.Point(198, 52);
			this._txtCommonDisplay_0.Name = "_txtCommonDisplay_0";
			this._txtCommonDisplay_0.Size = new System.Drawing.Size(201, 19);
			this._txtCommonDisplay_0.TabIndex = 26;
			this._txtCommonDisplay_0.TabStop = false;
			this._txtCommonDisplay_0.Visible = false;
			// 
			// _txtCommon_3
			// 
			this._txtCommon_3.AllowDrop = true;
			this._txtCommon_3.BackColor = System.Drawing.Color.White;
			// this.this._txtCommon_3.bolIsRequired = true;
			// this._txtCommon_3.bolNumericOnly = true;
			this._txtCommon_3.ForeColor = System.Drawing.Color.Black;
			this._txtCommon_3.Location = new System.Drawing.Point(94, 74);
			this._txtCommon_3.MaxLength = 15;
			this._txtCommon_3.Name = "_txtCommon_3";
			// this._txtCommon_3.ShowButton = true;
			this._txtCommon_3.Size = new System.Drawing.Size(101, 19);
			this._txtCommon_3.TabIndex = 27;
			this._txtCommon_3.Text = "";
			this._txtCommon_3.Visible = false;
			// this.this._txtCommon_3.Watermark = "Report UOM";
			// 
			// _lblCommon_50
			// 
			this._lblCommon_50.AllowDrop = true;
			this._lblCommon_50.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_50.Text = "Reporting Unit";
			this._lblCommon_50.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_50.Location = new System.Drawing.Point(8, 76);
			// this._lblCommon_50.mLabelId = 2182;
			this._lblCommon_50.Name = "_lblCommon_50";
			this._lblCommon_50.Size = new System.Drawing.Size(67, 14);
			this._lblCommon_50.TabIndex = 28;
			this._lblCommon_50.Visible = false;
			// 
			// _txtCommonDisplay_5
			// 
			this._txtCommonDisplay_5.AllowDrop = true;
			this._txtCommonDisplay_5.Location = new System.Drawing.Point(198, 74);
			this._txtCommonDisplay_5.Name = "_txtCommonDisplay_5";
			this._txtCommonDisplay_5.Size = new System.Drawing.Size(201, 19);
			this._txtCommonDisplay_5.TabIndex = 29;
			this._txtCommonDisplay_5.TabStop = false;
			this._txtCommonDisplay_5.Visible = false;
			// 
			// txtProdDesc
			// 
			this.txtProdDesc.AllowDrop = true;
			this.txtProdDesc.BackColor = System.Drawing.Color.White;
			// this.txtProdDesc.bolAllowDecimal = false;
			this.txtProdDesc.ForeColor = System.Drawing.Color.Black;
			this.txtProdDesc.Location = new System.Drawing.Point(122, 106);
			// this.txtProdDesc.mDropDownType = (System.Windows.Forms.TextBox.FormatBoxDropDownTypes) 0;
			this.txtProdDesc.Name = "txtProdDesc";
			this.txtProdDesc.Size = new System.Drawing.Size(617, 69);
			this.txtProdDesc.TabIndex = 0;
			this.txtProdDesc.Text = "";
			// 
			// _txtCommon_2
			// 
			this._txtCommon_2.AllowDrop = true;
			this._txtCommon_2.BackColor = System.Drawing.Color.White;
			this._txtCommon_2.ForeColor = System.Drawing.Color.Black;
			this._txtCommon_2.Location = new System.Drawing.Point(122, 83);
			// this._txtCommon_2.mArabicEnabled = true;
			this._txtCommon_2.MaxLength = 200;
			this._txtCommon_2.Name = "_txtCommon_2";
			this._txtCommon_2.Size = new System.Drawing.Size(351, 19);
			this._txtCommon_2.TabIndex = 1;
			this._txtCommon_2.Text = "";
			// this.this._txtCommon_2.Watermark = "";
			// 
			// _txtCommon_0
			// 
			this._txtCommon_0.AllowDrop = true;
			this._txtCommon_0.BackColor = System.Drawing.Color.White;
			// this.this._txtCommon_0.bolIsRequired = true;
			this._txtCommon_0.ForeColor = System.Drawing.Color.Black;
			this._txtCommon_0.Location = new System.Drawing.Point(122, 38);
			this._txtCommon_0.MaxLength = 20;
			// this._txtCommon_0.mDropDownType = System.Windows.Forms.TextBox.DropDownTypes.ddtNextNumber;
			this._txtCommon_0.Name = "_txtCommon_0";
			this._txtCommon_0.Size = new System.Drawing.Size(133, 19);
			this._txtCommon_0.TabIndex = 2;
			this._txtCommon_0.Text = "";
			// this.this._txtCommon_0.Watermark = "Item Code";
			// 
			// _lblCommon_3
			// 
			this._lblCommon_3.AllowDrop = true;
			this._lblCommon_3.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_3.Text = "Description";
			this._lblCommon_3.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_3.Location = new System.Drawing.Point(6, 109);
			// this._lblCommon_3.mLabelId = 216;
			this._lblCommon_3.Name = "_lblCommon_3";
			this._lblCommon_3.Size = new System.Drawing.Size(54, 14);
			this._lblCommon_3.TabIndex = 3;
			// 
			// _lblCommon_1
			// 
			this._lblCommon_1.AllowDrop = true;
			this._lblCommon_1.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_1.Text = "Item Name (English)";
			this._lblCommon_1.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_1.Location = new System.Drawing.Point(6, 62);
			// this._lblCommon_1.mLabelId = 921;
			this._lblCommon_1.Name = "_lblCommon_1";
			this._lblCommon_1.Size = new System.Drawing.Size(94, 14);
			this._lblCommon_1.TabIndex = 4;
			// 
			// _txtCommon_1
			// 
			this._txtCommon_1.AllowDrop = true;
			this._txtCommon_1.BackColor = System.Drawing.Color.White;
			// this.this._txtCommon_1.bolIsRequired = true;
			this._txtCommon_1.ForeColor = System.Drawing.Color.Black;
			this._txtCommon_1.Location = new System.Drawing.Point(122, 60);
			this._txtCommon_1.MaxLength = 200;
			this._txtCommon_1.Name = "_txtCommon_1";
			this._txtCommon_1.Size = new System.Drawing.Size(351, 19);
			this._txtCommon_1.TabIndex = 5;
			this._txtCommon_1.Text = "";
			// this.this._txtCommon_1.Watermark = "Item Name";
			// 
			// _lblCommon_2
			// 
			this._lblCommon_2.AllowDrop = true;
			this._lblCommon_2.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_2.Text = "Item Name (Arabic)";
			this._lblCommon_2.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_2.Location = new System.Drawing.Point(6, 85);
			// this._lblCommon_2.mLabelId = 551;
			this._lblCommon_2.Name = "_lblCommon_2";
			this._lblCommon_2.Size = new System.Drawing.Size(92, 14);
			this._lblCommon_2.TabIndex = 6;
			// 
			// _lblCommon_0
			// 
			this._lblCommon_0.AllowDrop = true;
			this._lblCommon_0.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_0.Text = "Item Code";
			this._lblCommon_0.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_0.Location = new System.Drawing.Point(6, 40);
			// this._lblCommon_0.mLabelId = 545;
			this._lblCommon_0.Name = "_lblCommon_0";
			this._lblCommon_0.Size = new System.Drawing.Size(47, 14);
			this._lblCommon_0.TabIndex = 7;
			// 
			// _cmbCommon_0
			// 
			this._cmbCommon_0.AllowDrop = true;
			this._cmbCommon_0.Location = new System.Drawing.Point(122, 12);
			this._cmbCommon_0.Name = "_cmbCommon_0";
			this._cmbCommon_0.Size = new System.Drawing.Size(167, 21);
			this._cmbCommon_0.TabIndex = 8;
			this._cmbCommon_0.Visible = false;
			// 
			// _lblCommon_8
			// 
			this._lblCommon_8.AllowDrop = true;
			this._lblCommon_8.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this._lblCommon_8.Text = "Item Type";
			this._lblCommon_8.ForeColor = System.Drawing.Color.Black;
			this._lblCommon_8.Location = new System.Drawing.Point(6, 16);
			// this._lblCommon_8.mLabelId = 919;
			this._lblCommon_8.Name = "_lblCommon_8";
			this._lblCommon_8.Size = new System.Drawing.Size(46, 14);
			this._lblCommon_8.TabIndex = 9;
			this._lblCommon_8.Visible = false;
			// 
			// frmICSItemDimention
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.FromArgb(220, 226, 231);
			this.ClientSize = new System.Drawing.Size(957, 528);
			this.Controls.Add(this.TabControl1);
			this.Controls.Add(this.txtProdDesc);
			this.Controls.Add(this._txtCommon_2);
			this.Controls.Add(this._txtCommon_0);
			this.Controls.Add(this._lblCommon_3);
			this.Controls.Add(this._lblCommon_1);
			this.Controls.Add(this._txtCommon_1);
			this.Controls.Add(this._lblCommon_2);
			this.Controls.Add(this._lblCommon_0);
			this.Controls.Add(this._cmbCommon_0);
			this.Controls.Add(this._lblCommon_8);
			this.Location = new System.Drawing.Point(204, 261);
			this.MaximizeBox = true;
			this.MinimizeBox = true;
			this.Name = "frmICSItemDimention";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Product Dimension Master";
			// this.Activated += new System.EventHandler(this.frmICSItemDimention_Activated);
			// this.Closed += new System.EventHandler(this.Form_Closed);
			//((System.ComponentModel.ISupportInitialize) this.TabControlPage2).EndInit();
			//((System.ComponentModel.ISupportInitialize) this.TabControlPage1).EndInit();
			//((System.ComponentModel.ISupportInitialize) this.TabControl1).EndInit();
			this.TabControl1.ResumeLayout(false);
			this.TabControlPage1.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		void ReLoadForm(bool addEvents)
		{
			InitializetxtCommonDisplay();
			InitializetxtCommon();
			InitializelblCommon();
			InitializecmdCommon();
			InitializecmbCommon();
			//This form is an MDI child.
			//This code simulates the VB6 
			// functionality of automatically
			// loading and showing an MDI
			// child's parent.
			this.MdiParent = Xtreme.frmSysMain.DefInstance;
			Xtreme.frmSysMain.DefInstance.Show();
		}
		void InitializetxtCommonDisplay()
		{
			this.txtCommonDisplay = new System.Windows.Forms.Label[6];
			this.txtCommonDisplay[1] = _txtCommonDisplay_1;
			this.txtCommonDisplay[2] = _txtCommonDisplay_2;
			this.txtCommonDisplay[0] = _txtCommonDisplay_0;
			this.txtCommonDisplay[5] = _txtCommonDisplay_5;
		}
		void InitializetxtCommon()
		{
			this.txtCommon = new System.Windows.Forms.TextBox[7];
			this.txtCommon[6] = _txtCommon_6;
			this.txtCommon[5] = _txtCommon_5;
			this.txtCommon[4] = _txtCommon_4;
			this.txtCommon[3] = _txtCommon_3;
			this.txtCommon[2] = _txtCommon_2;
			this.txtCommon[0] = _txtCommon_0;
			this.txtCommon[1] = _txtCommon_1;
		}
		void InitializelblCommon()
		{
			this.lblCommon = new System.Windows.Forms.Label[51];
			this.lblCommon[6] = _lblCommon_6;
			this.lblCommon[7] = _lblCommon_7;
			this.lblCommon[10] = _lblCommon_10;
			this.lblCommon[5] = _lblCommon_5;
			this.lblCommon[50] = _lblCommon_50;
			this.lblCommon[3] = _lblCommon_3;
			this.lblCommon[1] = _lblCommon_1;
			this.lblCommon[2] = _lblCommon_2;
			this.lblCommon[0] = _lblCommon_0;
			this.lblCommon[8] = _lblCommon_8;
		}
		void InitializecmdCommon()
		{
			this.cmdCommon = new System.Windows.Forms.Button[3];
			this.cmdCommon[0] = _cmdCommon_0;
			this.cmdCommon[2] = _cmdCommon_2;
			this.cmdCommon[1] = _cmdCommon_1;
		}
		void InitializecmbCommon()
		{
			this.cmbCommon = new System.Windows.Forms.ComboBox[1];
			this.cmbCommon[0] = _cmbCommon_0;
		}
		#endregion
	}
}