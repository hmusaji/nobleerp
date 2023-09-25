
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;



namespace Xtreme
{
	internal partial class frmICSLocation
		: System.Windows.Forms.Form
	{

		public frmICSLocation()
{
InitializeComponent();
} 
 public  void frmICSLocation_old()
			//: base()
		{
			if (m_vb6FormDefInstance is null)
			{
				if (m_InitializingDefInstance)
				{
					m_vb6FormDefInstance = this;
				}
				else
				{
					try
					{
						//For the start-up form, the first instance created is the default instance.
						if (!(System.Reflection.Assembly.GetExecutingAssembly().EntryPoint is null) && System.Reflection.Assembly.GetExecutingAssembly().EntryPoint.DeclaringType == this.GetType())
						{
							m_vb6FormDefInstance = this;
						}
					}
					catch
					{
					}
				}
			}
			//This call is required by the Windows Form Designer.
			InitializeComponent();
			
		}


		private void frmICSLocation_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (UpgradeHelpers.Gui.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Gui.ActivateHelper.myActiveForm = (System.Windows.Forms.Form) eventSender;
			}
		}
		//Assign the Formid for Each Form
		int mThisFormID = 0;

		object mSearchValue = null;
		
		public clsAccessAllowed UserAccess
		{
			get
			{
				if (_UserAccess is null)
				{
					_UserAccess = new clsAccessAllowed();
				}
				return _UserAccess;
			}
			set
			{
				_UserAccess = value;
			}
		}

		private SystemVariables.SystemFormModes mCurrentFormMode = (SystemVariables.SystemFormModes) 0;
		private clsToolbar oThisFormToolBar = null;


		private XArrayHelper _aLedger = null;
		private XArrayHelper aLedger
		{
			get
			{
				if (_aLedger is null)
				{
					_aLedger = new XArrayHelper();
				}
				return _aLedger;
			}
			set
			{
				_aLedger = value;
			}
		}

		private bool mFirstGridFocus = false;
		private DataSet rsLedgerList = null;
		private DataSet rsCostList = null;
		private DataSet rsProjectList = null;
		private DataSet rsAnlyCode = null;
		private string mTimeStamp = "";

		private const int grdAccountType = 0;
		private const int grdLedgerCode = 1;
		private const int grdLedgerName = 2;
		private const int grdApplyCostCenter = 3;
		private const int grdCCNo = 4;
		private const int grdCCName = 5;
		private const int grdProjectNo = 6;
		private const int grdProjectName = 7;
		private const int grdAnlyCode1 = 8;
		private const int grdAnlyCode2 = 9;
		private const int grdGroupCodeFilterOnLedger = 10;

		private const int mMaxArrayCols = 10;
		private int mMaxArrayRows = 0;

		private const int conTabBasicDetails = 0;
		private const int conTabGeneralLedgerDetails = 1;
		private const int conTabOtherDetails = 2;

		private int mNonInventoryIncrementValue = 0;



		public int ThisFormId
		{
			get
			{
				return mThisFormID;
			}
			set
			{
				mThisFormID = value;
			}
		}



		public object SearchValue
		{
			get
			{
				return mSearchValue;
			}
			set
			{
				mSearchValue = value;
			}
		}



		public SystemVariables.SystemFormModes CurrentFormMode
		{
			get
			{
				return mCurrentFormMode;
			}
			set
			{
				mCurrentFormMode = value;
			}
		}


		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBDropDown Event cmbCommon.DataSourceChanged was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void cmbCommon_DataSourceChanged()
		{
			int Cnt = 0;
			cmbCommon.Width = 0;
			C1.Win.C1TrueDBGrid.C1DisplayColumn withVar = null;
			C1.Win.C1TrueDBGrid.C1DisplayColumn withVar_2 = null;
			C1.Win.C1TrueDBGrid.C1DisplayColumn withVar_3 = null;
			C1.Win.C1TrueDBGrid.C1DisplayColumn withVar_4 = null;
			switch(grdVoucherDetails.Col)
			{
				case grdLedgerCode : case grdLedgerName : 
					if (grdVoucherDetails.Col == grdLedgerCode)
					{
						//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbCommon.ListField was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						cmbCommon.setListField("ldgr_no");
						//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsLedgerList.Sort was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						rsLedgerList.setSort("ldgr_no");
					}
					else
					{
						//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbCommon.ListField was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						cmbCommon.setListField("ldgr_name");
						//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsLedgerList.Sort was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						rsLedgerList.setSort("ldgr_name");
					} 
					 
					int tempForEndVar = cmbCommon.Columns.Count - 1; 
					for (Cnt = 0; Cnt <= tempForEndVar; Cnt++)
					{
						//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
						withVar = cmbCommon.Splits[0].DisplayColumns[Cnt];
						if (Cnt < 2)
						{
							if (SystemVariables.gPreferedLanguage == SystemVariables.Language.English)
							{
								withVar.Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Near;
							}
							else
							{
								withVar.Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far;
							}
							switch(Cnt)
							{
								case 0 : 
									//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.Column property withVar.Order was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064 
									withVar.setOrder((grdVoucherDetails.Col == grdLedgerCode) ? 0 : 1); 
									//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081 
									withVar.Width = grdVoucherDetails.Splits[0].DisplayColumns[grdLedgerCode].Width; 
									withVar.Visible = true; 
									break;
								case 1 : 
									//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.Column property withVar.Order was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064 
									withVar.setOrder((grdVoucherDetails.Col == grdLedgerName) ? 0 : 1); 
									//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081 
									withVar.Width = grdVoucherDetails.Splits[0].DisplayColumns[grdLedgerName].Width; 
									withVar.Visible = true; 
									break;
							}

							cmbCommon.Width += withVar.Width / 15;
						}
						else
						{
							withVar.Visible = false;
						}
						withVar.AllowSizing = false;
					} 
					cmbCommon.Width += 17; 
					cmbCommon.Height = 167; 
					break;
				case grdCCNo : case grdCCName : 
					if (grdVoucherDetails.Col == grdCCNo)
					{
						//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbCommon.ListField was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						cmbCommon.setListField("cost_no");
						//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsCostList.Sort was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						rsCostList.setSort("cost_no");
					}
					else
					{
						//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbCommon.ListField was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						cmbCommon.setListField("cost_name");
						//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsCostList.Sort was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						rsCostList.setSort("cost_name");
					} 
					 
					int tempForEndVar2 = cmbCommon.Columns.Count - 1; 
					for (Cnt = 0; Cnt <= tempForEndVar2; Cnt++)
					{
						//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
						withVar_2 = cmbCommon.Splits[0].DisplayColumns[Cnt];
						if (Cnt < 2)
						{
							if (SystemVariables.gPreferedLanguage == SystemVariables.Language.English)
							{
								withVar_2.Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Near;
							}
							else
							{
								withVar_2.Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far;
							}
							withVar_2.Visible = true;
							if (Cnt == 0)
							{
								//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
								cmbCommon.DisplayColumns[Cnt].Width = grdVoucherDetails.Splits[0].DisplayColumns[grdCCNo].Width;
								//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
								cmbCommon.Width += grdVoucherDetails.Splits[0].DisplayColumns[grdCCNo].Width;
								//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.Column property withVar_2.Order was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
								withVar_2.setOrder((grdVoucherDetails.Col == grdCCNo) ? 0 : 1);
							}
							else if (Cnt == 1)
							{ 
								//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
								cmbCommon.DisplayColumns[Cnt].Width = grdVoucherDetails.Splits[0].DisplayColumns[grdCCName].Width;
								//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
								cmbCommon.Width += grdVoucherDetails.Splits[0].DisplayColumns[grdCCName].Width;
								//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.Column property withVar_2.Order was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
								withVar_2.setOrder((grdVoucherDetails.Col == grdCCName) ? 0 : 1);
							}
						}
						else
						{
							withVar_2.Visible = false;
						}
						withVar_2.AllowSizing = false;
					} 
					cmbCommon.Width += 17; 
					cmbCommon.Height = 100; 
					break;
				case grdProjectNo : case grdProjectName : 
					if (grdVoucherDetails.Col == grdProjectNo)
					{
						//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbCommon.ListField was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						cmbCommon.setListField("project_no");
						//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsProjectList.Sort was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						rsProjectList.setSort("project_no");
					}
					else
					{
						//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbCommon.ListField was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						cmbCommon.setListField("project_name");
						//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsProjectList.Sort was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						rsProjectList.setSort("project_name");
					} 
					 
					int tempForEndVar3 = cmbCommon.Columns.Count - 1; 
					for (Cnt = 0; Cnt <= tempForEndVar3; Cnt++)
					{
						//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
						withVar_3 = cmbCommon.Splits[0].DisplayColumns[Cnt];
						if (Cnt < 2)
						{
							if (SystemVariables.gPreferedLanguage == SystemVariables.Language.English)
							{
								withVar_3.Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Near;
							}
							else
							{
								withVar_3.Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far;
							}
							withVar_3.Visible = true;
							if (Cnt == 0)
							{
								//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
								cmbCommon.DisplayColumns[Cnt].Width = grdVoucherDetails.Splits[0].DisplayColumns[grdProjectNo].Width;
								//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
								cmbCommon.Width += grdVoucherDetails.Splits[0].DisplayColumns[grdProjectNo].Width;
								//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.Column property withVar_3.Order was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
								withVar_3.setOrder((grdVoucherDetails.Col == grdProjectNo) ? 0 : 1);
							}
							else if (Cnt == 1)
							{ 
								//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
								cmbCommon.DisplayColumns[Cnt].Width = grdVoucherDetails.Splits[0].DisplayColumns[grdProjectName].Width;
								//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
								cmbCommon.Width += grdVoucherDetails.Splits[0].DisplayColumns[grdProjectName].Width;
								//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.Column property withVar_3.Order was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
								withVar_3.setOrder((grdVoucherDetails.Col == grdProjectName) ? 0 : 1);
							}
						}
						else
						{
							withVar_3.Visible = false;
						}
						withVar_3.AllowSizing = false;
					} 
					cmbCommon.Width += 17; 
					cmbCommon.Height = 100; 
					break;
				case grdAnlyCode1 : case grdAnlyCode2 : 
					//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbCommon.ListField was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064 
					cmbCommon.setListField("anly_code"); 
					 
					if (grdVoucherDetails.Col == grdAnlyCode1)
					{
						DefineAnlysisFilter(rsAnlyCode, 1);
					}
					else if (grdVoucherDetails.Col == grdAnlyCode2)
					{ 
						DefineAnlysisFilter(rsAnlyCode, 2);
					} 
					 
					int tempForEndVar4 = cmbCommon.Columns.Count - 1; 
					for (Cnt = 0; Cnt <= tempForEndVar4; Cnt++)
					{
						//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
						withVar_4 = cmbCommon.Splits[0].DisplayColumns[Cnt];
						if (Cnt < 2)
						{
							if (SystemVariables.gPreferedLanguage == SystemVariables.Language.English)
							{
								withVar_4.Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Near;
							}
							else
							{
								withVar_4.Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far;
							}
							withVar_4.Visible = true;
							if (Cnt == 0)
							{
								//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
								cmbCommon.DisplayColumns[Cnt].Width = grdVoucherDetails.Splits[0].DisplayColumns[grdAnlyCode1].Width;
								//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
								cmbCommon.Width += grdVoucherDetails.Splits[0].DisplayColumns[grdAnlyCode1].Width;
							}
							else if (Cnt == 1)
							{ 
								cmbCommon.DisplayColumns[Cnt].Width = 67;
								cmbCommon.Width += 67;
							}
						}
						else
						{
							withVar_4.Visible = false;
						}
						withVar_4.AllowSizing = false;
					} 
					cmbCommon.Width += 17; 
					cmbCommon.Height = 100; 
					break;
				default:
					cmbCommon.Width = 0; 
					break;
			}

		}

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBDropDown Event cmbCommon.DropDownClose was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void cmbCommon_DropDownClose()
		{
			//If tabMaster.CurrTab = 1 Then
			//grdVoucherDetails.Update
			//grdVoucherDetails.RefreshRow Val(grdVoucherDetails.Bookmark)
			//Call grdVoucherDetails_RowColChange(-1, 0)

			//If gxrdVoucherDetails.Col = grdLedgerCode Then
			//    grdVoucherDetails.Col = grdCCNo
			//End If
			//End If
		}

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBDropDown Event cmbCommon.RowChange was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void cmbCommon_RowChange()
		{
			if (grdVoucherDetails.Col == grdLedgerCode)
			{
				grdVoucherDetails.Columns[grdLedgerName].Value = cmbCommon.Columns[1].Value;
			}
			else if (grdVoucherDetails.Col == grdLedgerName)
			{ 
				grdVoucherDetails.Columns[grdLedgerCode].Value = cmbCommon.Columns[0].Value;
				//grdVoucherDetails.Columns(grdApplyCostCenter).Value = cmbCommon.Columns(2).Value
			}
			else if (grdVoucherDetails.Col == grdCCNo)
			{ 
				grdVoucherDetails.Columns[grdCCName].Value = cmbCommon.Columns[1].Value;
			}
			else if (grdVoucherDetails.Col == grdCCName)
			{ 
				grdVoucherDetails.Columns[grdCCNo].Value = cmbCommon.Columns[0].Value;
			}
			else if (grdVoucherDetails.Col == grdProjectNo)
			{ 
				grdVoucherDetails.Columns[grdProjectName].Value = cmbCommon.Columns[1].Value;
			}
			else if (grdVoucherDetails.Col == grdProjectName)
			{ 
				grdVoucherDetails.Columns[grdProjectNo].Value = cmbCommon.Columns[0].Value;
			}
		}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2080
		private void Form_Load()
		{

			try
			{

				this.CurrentFormMode = SystemVariables.SystemFormModes.frmAddMode;
				this.Top = 0;
				this.Left = 0;
				mFirstGridFocus = false;

				//**--format & define the new toolbar
				oThisFormToolBar = new clsToolbar();
				oThisFormToolBar.AttachObject(this); //, tcbSystemForm

				oThisFormToolBar.ShowNewButton = true;
				oThisFormToolBar.ShowSaveButton = true;
				oThisFormToolBar.ShowDeleteButton = true;
				oThisFormToolBar.ShowPrintButton = true;
				oThisFormToolBar.ShowFindButton = true;
				oThisFormToolBar.ShowHelpButton = true;
				oThisFormToolBar.ShowExitButton = true;
				oThisFormToolBar.BeginExitButtonWithGroup = true;
				oThisFormToolBar.DisableHelpButton = true;

				this.WindowState = FormWindowState.Maximized;
				//
				//'Assign the Image for the toolbar
				//'Imagelist are kept on the main form and refered by their key
				//Call DrawToolbar(Me, picFormToolbar, btnFormToolBar(0))
				//Set btnFormToolBar(0).Picture = frmSysMain.imlMainToolBar.ListImages("imgNew").Picture
				//Set btnFormToolBar(1).Picture = frmSysMain.imlMainToolBar.ListImages("imgSave").Picture
				//Set btnFormToolBar(2).Picture = frmSysMain.imlMainToolBar.ListImages("imgDelete").Picture
				//Set btnFormToolBar(3).Picture = frmSysMain.imlMainToolBar.ListImages("imgPrint").Picture
				//Set btnFormToolBar(4).Picture = frmSysMain.imlMainToolBar.ListImages("imgFind").Picture
				//Set btnFormToolBar(5).Picture = frmSysMain.imlMainToolBar.ListImages("imgHelp").Picture
				//Set btnFormToolBar(6).Picture = frmSysMain.imlMainToolBar.ListImages("imgExit").Picture
				//
				txtLocationNo.Text = SystemProcedure2.GetNewNumber("SM_Location", "Locat_no");

				tabMaster.CurrTab = Convert.ToInt16(conTabBasicDetails);

				//define voucher grid columns
				SystemGrid.DefineSystemVoucherGrid(grdVoucherDetails, false, false, true, (0xFFFFFF).ToString(), (0x0).ToString(), true, false, C1.Win.C1TrueDBGrid.MarqueeEnum.FloatingEditor, 1.47f, 1.4f, "&H00D5D5D5", "&H00D5D5D5");
				//define voucher grid columns
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "GL Account Type", 2200, false, "&H00D5D5D5", ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false);
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Ledger Code", 1200, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, true, true, "cmbCommon");
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Ledger Name", 2700, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, true, true, "cmbCommon");
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Apply cost center", 1000, false, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, false);
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Cost Code", 1200, true, ColorTranslator.ToOle(Color.White).ToString(), (0x913DA3).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, true, true, "cmbCommon", false, ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("cost_center")), false, true);
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Cost Name", 1800, true, ColorTranslator.ToOle(Color.White).ToString(), (0x913DA3).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, true, true, "cmbCommon", false, ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("cost_center")), false, true);
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Projet Code", 1200, true, ColorTranslator.ToOle(Color.White).ToString(), (0x913DA3).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, true, true, "cmbCommon", false, ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("project_costing")), false, true);
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Project Name", 1800, true, ColorTranslator.ToOle(Color.White).ToString(), (0x913DA3).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, true, true, "cmbCommon", false, ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("project_costing")), false, true);
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Anly 1", 1200, true, ColorTranslator.ToOle(Color.White).ToString(), (0x913DA3).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, true, true, "cmbCommon", false, ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("anly_code_1")));
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Anly 2", 1200, true, ColorTranslator.ToOle(Color.White).ToString(), (0x913DA3).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, true, true, "cmbCommon", false, ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("anly_code_2")));
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "GroupCodeFilterList", 1000, false, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, false);


				//Setting for the standard Listbox used on the grid
				SystemGrid.DefineSystemGridCombo(cmbCommon);
				cmbCommon.Height = 100;
				cmbCommon.Width = 280;

				mMaxArrayRows = 15;

				if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("service_product")))
				{
					mMaxArrayRows += 6;

					mNonInventoryIncrementValue = 6;
				}

				if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("non_inventory_product")))
				{
					mMaxArrayRows += 6;
				}


				//UPGRADE_ISSUE: (2064) XArrayDBObject.XArrayDB method aLedger.Clear was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				aLedger.Clear();
				aLedger.RedimXArray(new int[]{mMaxArrayRows, mMaxArrayCols}, new int[]{0, 0});

				aLedger.SetValue("Inventory A/c", 0, grdAccountType);
				aLedger.SetValue(SystemGLConstants.gGLAssetsLiabilitiesTypeCode, 0, grdGroupCodeFilterOnLedger); //Purchase Stock A/C

				aLedger.SetValue("Inventory Adjustment A/c", 1, grdAccountType);
				aLedger.SetValue(SystemGLConstants.gGLIncomeExpenseTypeCode.ToString() + "," + SystemGLConstants.gGLSalesTypeCode.ToString(), 1, grdGroupCodeFilterOnLedger);

				aLedger.SetValue("Cost of Sale A/c", 2, grdAccountType);
				aLedger.SetValue(SystemGLConstants.gGLIncomeExpenseTypeCode.ToString() + "," + SystemGLConstants.gGLSalesTypeCode.ToString(), 2, grdGroupCodeFilterOnLedger); //"L-ED-00012"

				aLedger.SetValue("Purchase Dis. A/c", 3, grdAccountType);
				aLedger.SetValue(SystemGLConstants.gGLIncomeExpenseTypeCode.ToString() + "," + SystemGLConstants.gGLPurchaseTypeCode.ToString(), 3, grdGroupCodeFilterOnLedger); // "O-II-00015"

				aLedger.SetValue("Cash Sale A/c", 4, grdAccountType);
				aLedger.SetValue(SystemGLConstants.gGLIncomeExpenseTypeCode.ToString() + "," + SystemGLConstants.gGLSalesTypeCode.ToString() + "," + SystemGLConstants.gGLAssetsLiabilitiesTypeCode.ToString(), 4, grdGroupCodeFilterOnLedger);

				aLedger.SetValue("Credit Sale A/c", 5, grdAccountType);
				aLedger.SetValue(SystemGLConstants.gGLIncomeExpenseTypeCode.ToString() + "," + SystemGLConstants.gGLSalesTypeCode.ToString() + "," + SystemGLConstants.gGLAssetsLiabilitiesTypeCode.ToString(), 5, grdGroupCodeFilterOnLedger);

				aLedger.SetValue("Cash Sale Dis. A/c", 6, grdAccountType);
				aLedger.SetValue(SystemGLConstants.gGLIncomeExpenseTypeCode.ToString() + "," + SystemGLConstants.gGLSalesTypeCode.ToString(), 6, grdGroupCodeFilterOnLedger);

				aLedger.SetValue("Credit Sale Dis. A/c", 7, grdAccountType);
				aLedger.SetValue(SystemGLConstants.gGLIncomeExpenseTypeCode.ToString() + "," + SystemGLConstants.gGLSalesTypeCode.ToString(), 7, grdGroupCodeFilterOnLedger);

				aLedger.SetValue("Purchase Return A/c", 8, grdAccountType);
				aLedger.SetValue(SystemGLConstants.gGLAssetsLiabilitiesTypeCode, 8, grdGroupCodeFilterOnLedger); //B-SH-00022",

				aLedger.SetValue("Purchase Return Dis. A/c", 9, grdAccountType);
				aLedger.SetValue(SystemGLConstants.gGLIncomeExpenseTypeCode.ToString() + "," + SystemGLConstants.gGLPurchaseTypeCode.ToString(), 9, grdGroupCodeFilterOnLedger);

				aLedger.SetValue("Cash Sale Return A/c", 10, grdAccountType);
				aLedger.SetValue(SystemGLConstants.gGLIncomeExpenseTypeCode.ToString() + "," + SystemGLConstants.gGLSalesTypeCode.ToString() + "," + SystemGLConstants.gGLAssetsLiabilitiesTypeCode.ToString(), 10, grdGroupCodeFilterOnLedger);

				aLedger.SetValue("Credit Sale Return A/c", 11, grdAccountType);
				aLedger.SetValue(SystemGLConstants.gGLIncomeExpenseTypeCode.ToString() + "," + SystemGLConstants.gGLSalesTypeCode.ToString() + "," + SystemGLConstants.gGLAssetsLiabilitiesTypeCode.ToString(), 11, grdGroupCodeFilterOnLedger);

				aLedger.SetValue("Cash Sale Return Dis. A/c", 12, grdAccountType);
				aLedger.SetValue(SystemGLConstants.gGLIncomeExpenseTypeCode.ToString() + "," + SystemGLConstants.gGLSalesTypeCode.ToString(), 12, grdGroupCodeFilterOnLedger);

				aLedger.SetValue("Creidt Sale Return Dis. A/c", 13, grdAccountType);
				aLedger.SetValue(SystemGLConstants.gGLIncomeExpenseTypeCode.ToString() + "," + SystemGLConstants.gGLSalesTypeCode.ToString(), 13, grdGroupCodeFilterOnLedger);

				aLedger.SetValue("Cash A/c", 14, grdAccountType);
				aLedger.SetValue(SystemGLConstants.gGLCashTypeCode.ToString() + "," + SystemGLConstants.gGLBankTypeCode.ToString(), 14, grdGroupCodeFilterOnLedger);

				aLedger.SetValue("Suspence A/c", 15, grdAccountType);
				aLedger.SetValue(SystemGLConstants.gGLAssetsLiabilitiesTypeCode, 15, grdGroupCodeFilterOnLedger); //"I-SA-00009"


				if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("service_product")))
				{
					aLedger.SetValue("Service Cash Sales A/c", 16, grdAccountType);
					aLedger.SetValue(SystemGLConstants.gGLIncomeExpenseTypeCode.ToString() + "," + SystemGLConstants.gGLSalesTypeCode.ToString() + "," + SystemGLConstants.gGLAssetsLiabilitiesTypeCode.ToString(), 16, grdGroupCodeFilterOnLedger);

					aLedger.SetValue("Serivce Cash Cost of Sales A/c", 17, grdAccountType);
					aLedger.SetValue(SystemGLConstants.gGLIncomeExpenseTypeCode.ToString() + "," + SystemGLConstants.gGLSalesTypeCode.ToString(), 17, grdGroupCodeFilterOnLedger);

					aLedger.SetValue("Serivce Cash Expenses A/c", 18, grdAccountType);
					aLedger.SetValue(SystemGLConstants.gGLIncomeExpenseTypeCode.ToString() + "," + SystemGLConstants.gGLSalesTypeCode.ToString(), 18, grdGroupCodeFilterOnLedger);

					aLedger.SetValue("Service Credit Sales A/c", 19, grdAccountType);
					aLedger.SetValue(SystemGLConstants.gGLIncomeExpenseTypeCode.ToString() + "," + SystemGLConstants.gGLSalesTypeCode.ToString() + "," + SystemGLConstants.gGLAssetsLiabilitiesTypeCode.ToString(), 19, grdGroupCodeFilterOnLedger);

					aLedger.SetValue("Serivce Credit Cost of Sales A/c", 20, grdAccountType);
					aLedger.SetValue(SystemGLConstants.gGLIncomeExpenseTypeCode.ToString() + "," + SystemGLConstants.gGLSalesTypeCode.ToString(), 20, grdGroupCodeFilterOnLedger);

					aLedger.SetValue("Serivce Credit Expenses A/c", 21, grdAccountType);
					aLedger.SetValue(SystemGLConstants.gGLIncomeExpenseTypeCode.ToString() + "," + SystemGLConstants.gGLSalesTypeCode.ToString(), 21, grdGroupCodeFilterOnLedger);
				}


				if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("non_inventory_product")))
				{
					aLedger.SetValue("Non Inventory Cash Sales A/c", 16 + mNonInventoryIncrementValue, grdAccountType);
					aLedger.SetValue(SystemGLConstants.gGLIncomeExpenseTypeCode.ToString() + "," + SystemGLConstants.gGLSalesTypeCode.ToString() + "," + SystemGLConstants.gGLAssetsLiabilitiesTypeCode.ToString(), 16 + mNonInventoryIncrementValue, grdGroupCodeFilterOnLedger);

					aLedger.SetValue("Non Inventory Cash Cost of Sales A/c", 17 + mNonInventoryIncrementValue, grdAccountType);
					aLedger.SetValue(SystemGLConstants.gGLIncomeExpenseTypeCode.ToString() + "," + SystemGLConstants.gGLSalesTypeCode.ToString(), 17 + mNonInventoryIncrementValue, grdGroupCodeFilterOnLedger);

					aLedger.SetValue("Non Invenotory Cash Expenses A/c", 18 + mNonInventoryIncrementValue, grdAccountType);
					aLedger.SetValue(SystemGLConstants.gGLIncomeExpenseTypeCode.ToString() + "," + SystemGLConstants.gGLSalesTypeCode.ToString(), 18 + mNonInventoryIncrementValue, grdGroupCodeFilterOnLedger);

					aLedger.SetValue("Non Inventory Credit Sales A/c", 19 + mNonInventoryIncrementValue, grdAccountType);
					aLedger.SetValue(SystemGLConstants.gGLIncomeExpenseTypeCode.ToString() + "," + SystemGLConstants.gGLSalesTypeCode.ToString() + "," + SystemGLConstants.gGLAssetsLiabilitiesTypeCode.ToString(), 19 + mNonInventoryIncrementValue, grdGroupCodeFilterOnLedger);

					aLedger.SetValue("Non Inventory Credit of Sales A/c", 20 + mNonInventoryIncrementValue, grdAccountType);
					aLedger.SetValue(SystemGLConstants.gGLIncomeExpenseTypeCode.ToString() + "," + SystemGLConstants.gGLSalesTypeCode.ToString(), 20 + mNonInventoryIncrementValue, grdGroupCodeFilterOnLedger);

					aLedger.SetValue("Non Invenotory Credit Expenses A/c", 21 + mNonInventoryIncrementValue, grdAccountType);
					aLedger.SetValue(SystemGLConstants.gGLIncomeExpenseTypeCode.ToString() + "," + SystemGLConstants.gGLSalesTypeCode.ToString(), 21 + mNonInventoryIncrementValue, grdGroupCodeFilterOnLedger);
				}

				//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBGrid property grdVoucherDetails.Array was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				grdVoucherDetails.setArray(aLedger);
				grdVoucherDetails.Rebind(true);
				grdVoucherDetails.Refresh();

				SystemProcedure.SetLabelCaption(this);
				clsFlip oFlipThisForm = null;
				//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				if (SystemVariables.gPreferedLanguage == SystemVariables.Language.Arabic && ((TriState) ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetSystemPreferenceSetting("flip_controls_in_arabic"))) == TriState.True)
				{
					oFlipThisForm = new clsFlip();

					oFlipThisForm.SwapMe(this);
				}


				if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("show_location_level_default_settings")))
				{
					tabMaster.set_TabVisible(Convert.ToInt16(conTabOtherDetails), TriState.True != TriState.False);

					lblDefaultLdgrCode.Visible = true;
					txtDefaultLdgrNo.Visible = true;
					lblDefaultLdgrName.Visible = true;
					lblDefaultCashCode.Visible = true;
					txtDefaultCashCode.Visible = true;
					lblDefaultCashName.Visible = true;
					lblDefaultTransType.Visible = true;
					chkCashType.Visible = true;

					if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("offline_data_management")))
					{
						lblDataUploadPath.Visible = true;
						txtDataUploadPath.Visible = true;
					}
					else
					{
						lblDataUploadPath.Visible = false;
						txtDataUploadPath.Visible = false;
					}

				}
				else
				{
					tabMaster.set_TabVisible(Convert.ToInt16(conTabOtherDetails), TriState.False != TriState.False);
					tabMaster.TabsPerPage = (short) (tabMaster.TabsPerPage - 1);

					lblDefaultLdgrCode.Visible = false;
					txtDefaultLdgrNo.Visible = false;
					lblDefaultLdgrName.Visible = false;
					lblDefaultCashCode.Visible = false;
					txtDefaultCashCode.Visible = false;
					lblDefaultCashName.Visible = false;
					lblDefaultTransType.Visible = false;
					chkCashType.Visible = false;

					lblDataUploadPath.Visible = false;
					txtDataUploadPath.Visible = false;
				}

				chkCheckNegativeStock.Visible = ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("enable_location_level_negative_stock_check"));
			}
			catch (System.Exception excep)
			{
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, excep.Message, this.Name, "Form Load");
				this.Close();
			}

		}

		private void Form_KeyDown(Object eventSender, KeyEventArgs eventArgs)
		{
			int KeyCode = (int) eventArgs.KeyCode;
			int Shift = ((int) eventArgs.KeyData) / 65536;
			try
			{
				//On Keydown navigate the form by using enter key
				if (KeyCode == 13 && this.ActiveControl.Name != "grdVoucherDetails")
				{ //If enter key pressed send a tab key
					SendKeys.Send("{TAB}");
					return;
				}
				SystemForms.SystemFormKeyDown(this, ref KeyCode, Shift, this.ActiveControl.Name);
			}
			finally
			{
				eventArgs.Handled = KeyCode == 0;
			}
		}

		public void AddRecord()
		{
			//Add a record
			int i = 0;
			int tempForEndVar = mMaxArrayRows;
			for (i = 0; i <= tempForEndVar; i++)
			{
				aLedger.SetValue("", i, 1);
				aLedger.SetValue("", i, 2);
			}

			grdVoucherDetails.Rebind(true);

			SystemProcedure2.ClearTextBox(this);
			txtLocationNo.Text = SystemProcedure2.GetNewNumber("SM_Location", "locat_no");

			tabMaster.CurrTab = 0;
			mFirstGridFocus = false;
			mCurrentFormMode = SystemVariables.SystemFormModes.frmAddMode; //Change the form mode to addmode
			mSearchValue = ""; //Change the msearchvalue to blank

			txtLocationNo.Focus();

			return;

			//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
			SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, Information.Err().Description, this.Name, "AddRecord");
		}

		public bool saveRecord()
		{
			bool result = false;
			bool _eFoundError5Flag = false;
			bool _eFoundError2Flag = false;
			object mTempValue = null;
			//Save a record
			//During save check for the mode
			//If in addmode then insert a record
			//else update the record in the recordset

			string mysql = "";
			string mGroupFilterClause = "";
			//UPGRADE_TODO: (1065) Error handling statement (On Error Goto) could not be converted. More Information: https://docs.mobilize.net/vbuc/ewis#1065
			UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("On Error Goto Label (eFoundError)");

			int Cnt = 0;
			object mReturnValue = null;

			object[, ] mLedger = null;
			if (mFirstGridFocus)
			{

				mLedger = new object[mMaxArrayRows + 1, 5];

				grdVoucherDetails.UpdateData();

				int tempForEndVar = mMaxArrayRows;
				for (Cnt = 0; Cnt <= tempForEndVar; Cnt++)
				{

					if (SystemProcedure2.IsItEmpty(aLedger.GetValue(Cnt, grdLedgerCode), SystemVariables.DataType.StringType))
					{
						goto eFoundError1;
					}

					mGroupFilterClause = FilterGroupCodeOnLedgerSql(Convert.ToString(aLedger.GetValue(Cnt, grdGroupCodeFilterOnLedger)), 1);
					mysql = "select ldgr_cd from gl_ledger ";
					mysql = mysql + " where ldgr_no='" + Convert.ToString(aLedger.GetValue(Cnt, grdLedgerCode)) + "'";
					mysql = mysql + " and ( " + mGroupFilterClause + ")";
					mysql = mysql + " and curr_cd = " + SystemGLConstants.gDefaultCurrencyCd.ToString();
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (Convert.IsDBNull(mTempValue))
					{
						goto eFoundError1;
					}
					else
					{
						//UPGRADE_WARNING: (1068) mTempValue of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mLedger[Cnt, 0] = ReflectionHelper.GetPrimitiveValue(mTempValue);
						mLedger[Cnt, 1] = "NULL";
					}

					//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
					if (((TriState) ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetSystemPreferenceSetting("cost_center"))) == TriState.True)
					{
						if (SystemProcedure2.IsItEmpty(aLedger.GetValue(Cnt, grdCCNo), SystemVariables.DataType.NumberType))
						{
							_eFoundError2Flag = true;
							goto eFoundError2TryBlock;
						}

						mysql = "select cost_cd from gl_cost_centers ";
						mysql = mysql + " where cost_no=" + Convert.ToString(aLedger.GetValue(Cnt, grdCCNo));
						//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
						if (Convert.IsDBNull(mTempValue))
						{
							_eFoundError2Flag = true;
							goto eFoundError2TryBlock;
						}
						else
						{
							//UPGRADE_WARNING: (1068) mTempValue of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							mLedger[Cnt, 1] = ReflectionHelper.GetPrimitiveValue(mTempValue);
						}
					}

					//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
					if (((TriState) ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetSystemPreferenceSetting("project_costing"))) == TriState.True)
					{
						if (SystemProcedure2.IsItEmpty(aLedger.GetValue(Cnt, grdProjectNo), SystemVariables.DataType.StringType))
						{
							mLedger[Cnt, 4] = "Null";
						}
						else
						{
							mysql = "select project_cd from PROJ_Projects ";
							mysql = mysql + " where project_no='" + Convert.ToString(aLedger.GetValue(Cnt, grdProjectNo)) + "'";
							//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
							if (Convert.IsDBNull(mTempValue))
							{
								_eFoundError5Flag = true;
								goto eFoundError5TryBlock;
							}
							else
							{
								//UPGRADE_WARNING: (1068) mTempValue of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
								mLedger[Cnt, 4] = ReflectionHelper.GetPrimitiveValue(mTempValue);
							}
						}
					}

					//''Analysis Code 1
					//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
					if (grdVoucherDetails.Splits[0].DisplayColumns[grdAnlyCode1].Visible)
					{
						mysql = "select anly_code from gl_analysis ";
						mysql = mysql + " where anly_code='" + Convert.ToString(aLedger.GetValue(Cnt, grdAnlyCode1)) + "'";
						mysql = mysql + " and anly_head_no = 1 ";
						//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
						if (Convert.IsDBNull(mTempValue))
						{
							mLedger[Cnt, 2] = "Null";
						}
						else
						{
							mLedger[Cnt, 2] = "'" + ReflectionHelper.GetPrimitiveValue<string>(mTempValue) + "'";
						}
					}

					//''Analysis Code 2
					//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
					if (grdVoucherDetails.Splits[0].DisplayColumns[grdAnlyCode2].Visible)
					{
						mysql = "select anly_code from gl_analysis ";
						mysql = mysql + " where anly_code='" + Convert.ToString(aLedger.GetValue(Cnt, grdAnlyCode2)) + "'";
						mysql = mysql + " and anly_head_no = 2 ";
						//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
						if (Convert.IsDBNull(mTempValue))
						{
							mLedger[Cnt, 3] = "Null";
						}
						else
						{
							mLedger[Cnt, 3] = "'" + ReflectionHelper.GetPrimitiveValue<string>(mTempValue) + "'";
						}
					}
				}
			}

			if (mCurrentFormMode == SystemVariables.SystemFormModes.frmAddMode)
			{
				mysql = " INSERT INTO SM_Location(User_Cd, Locat_No,L_short_Name, A_short_Name ";
				mysql = mysql + " , L_Locat_Name, A_Locat_Name, Addr_1, Addr_2, Addr_3, Contact_Person ";
				mysql = mysql + " , last_ldgr_no";
				mysql = mysql + " , Default_Sman_No ";
				mysql = mysql + " , last_cash_type, last_cash_no ";
				mysql = mysql + " , data_upload_path ";
				mysql = mysql + " , check_negative_stock ";
				mysql = mysql + " , Phone, Comments ";
				if (mFirstGridFocus)
				{
					mysql = mysql + " , Inventory_Cd , Adjustment_Cd, Cost_Of_Sale_Cd, ";
					mysql = mysql + " PDis_Cd, Cash_Sale_Cd, Credit_Sale_Cd, Cash_SDis_Cd ,";
					mysql = mysql + " Credit_SDis_Cd, PRet_Cd, PRet_Dis_Cd, Cash_SRet_Cd, Credit_SRet_Cd, ";
					mysql = mysql + " Cash_SRet_Dis_Cd, Credit_SRet_Dis_Cd, Cash_Cd, suspense_cd ";

					//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
					if (grdVoucherDetails.Splits[0].DisplayColumns[grdAnlyCode1].Visible)
					{
						mysql = mysql + " , inventory_anly_code_1, inventory_anly_head_no_1 ";
						mysql = mysql + " , adjustment_anly_code_1, adjustment_anly_head_no_1 ";
						mysql = mysql + " , cost_of_sale_anly_code_1, cost_of_sale_anly_head_no_1 ";
						mysql = mysql + " , pdis_anly_code_1, pdis_anly_head_no_1 ";
						mysql = mysql + " , cash_sale_anly_code_1, cash_sale_anly_head_no_1 ";
						mysql = mysql + " , credit_sale_anly_code_1, credit_sale_anly_head_no_1 ";
						mysql = mysql + " , cash_sdis_anly_code_1, cash_sdis_anly_head_no_1 ";
						mysql = mysql + " , credit_sdis_anly_code_1, credit_sdis_anly_head_no_1";
						mysql = mysql + " , pret_anly_code_1, pret_anly_head_no_1 ";
						mysql = mysql + " , pret_dis_anly_code_1, pret_dis_anly_head_no_1 ";
						mysql = mysql + " , cash_sret_anly_code_1, cash_sret_anly_head_no_1 ";
						mysql = mysql + " , credit_sret_anly_code_1, credit_sret_anly_head_no_1 ";
						mysql = mysql + " , cash_sret_dis_anly_code_1, cash_sret_dis_anly_head_no_1 ";
						mysql = mysql + " , credit_sret_dis_anly_code_1, credit_sret_dis_anly_head_no_1 ";
						mysql = mysql + " , cash_anly_code_1, cash_anly_head_no_1 ";
						mysql = mysql + " , suspense_anly_code_1, suspense_anly_head_no_1 ";
					}

					//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
					if (grdVoucherDetails.Splits[0].DisplayColumns[grdAnlyCode2].Visible)
					{
						mysql = mysql + " , inventory_anly_code_2, inventory_anly_head_no_2 ";
						mysql = mysql + " , adjustment_anly_code_2, adjustment_anly_head_no_2 ";
						mysql = mysql + " , cost_of_sale_anly_code_2, cost_of_sale_anly_head_no_2 ";
						mysql = mysql + " , pdis_anly_code_2, pdis_anly_head_no_2 ";
						mysql = mysql + " , cash_sale_anly_code_2, cash_sale_anly_head_no_2 ";
						mysql = mysql + " , credit_sale_anly_code_2, credit_sale_anly_head_no_2 ";
						mysql = mysql + " , cash_sdis_anly_code_2, cash_sdis_anly_head_no_2 ";
						mysql = mysql + " , credit_sdis_anly_code_2, credit_sdis_anly_head_no_2 ";
						mysql = mysql + " , pret_anly_code_2, pret_anly_head_no_2 ";
						mysql = mysql + " , pret_dis_anly_code_2, pret_dis_anly_head_no_2 ";
						mysql = mysql + " , cash_sret_anly_code_2, cash_sret_anly_head_no_2 ";
						mysql = mysql + " , credit_sret_anly_code_2, credit_sret_anly_head_no_2 ";
						mysql = mysql + " , cash_sret_dis_anly_code_2, cash_sret_dis_anly_head_no_2 ";
						mysql = mysql + " , credit_sret_dis_anly_code_2, credit_sret_dis_anly_head_no_2 ";
						mysql = mysql + " , cash_anly_code_2, cash_anly_head_no_2 ";
						mysql = mysql + " , suspense_anly_code_2, suspense_anly_head_no_2 ";
					}

					if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("service_product")))
					{
						mysql = mysql + ", service_sales_cd, service_cost_of_sales_cd, service_expense_cd ";
						mysql = mysql + ", Credit_service_sales_cd, Credit_service_cost_of_sales_cd, Credit_service_expense_cd ";

						//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
						if (grdVoucherDetails.Splits[0].DisplayColumns[grdAnlyCode1].Visible)
						{
							mysql = mysql + " , service_sales_anly_code_1, service_sales_anly_head_no_1 ";
							mysql = mysql + " , service_cost_of_sales_anly_code_1, service_cost_of_sales_anly_head_no_1 ";
							mysql = mysql + " , service_expense_anly_code_1, service_expense_anly_head_no_1 ";

							mysql = mysql + " , Credit_service_sales_anly_code_1, Credit_service_sales_anly_head_no_1 ";
							mysql = mysql + " , Credit_service_cost_of_sales_anly_code_1, Credit_service_cost_of_sales_anly_head_no_1 ";
							mysql = mysql + " , Credit_service_expense_anly_code_1, Credit_service_expense_anly_head_no_1 ";
						}

						//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
						if (grdVoucherDetails.Splits[0].DisplayColumns[grdAnlyCode2].Visible)
						{
							mysql = mysql + " , service_sales_anly_code_2, service_sales_anly_head_no_2 ";
							mysql = mysql + " , service_cost_of_sales_anly_code_2, service_cost_of_sales_anly_head_no_2 ";
							mysql = mysql + " , service_expense_anly_code_2, service_expense_anly_head_no_2 ";

							mysql = mysql + " , Credit_service_sales_anly_code_2, Credit_service_sales_anly_head_no_2 ";
							mysql = mysql + " , Credit_service_cost_of_sales_anly_code_2, Credit_service_cost_of_sales_anly_head_no_2 ";
							mysql = mysql + " , Credit_service_expense_anly_code_2, Credit_service_expense_anly_head_no_2 ";
						}
					}

					if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("non_inventory_product")))
					{
						mysql = mysql + ", non_inventory_sales_cd, non_inventory_cost_of_sales_cd, non_inventory_expense_cd ";
						mysql = mysql + ", Credit_non_inventory_sales_cd, Credit_non_inventory_cost_of_sales_cd, Credit_non_inventory_expense_cd ";

						//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
						if (grdVoucherDetails.Splits[0].DisplayColumns[grdAnlyCode1].Visible)
						{
							mysql = mysql + " , non_inventory_sales_anly_code_1, non_inventory_sales_anly_head_no_1 ";
							mysql = mysql + " , non_inventory_cost_of_sales_anly_code_1, non_inventory_cost_of_sales_anly_head_no_1 ";
							mysql = mysql + " , non_inventory_expense_anly_code_1, non_inventory_expense_anly_head_no_1 ";

							mysql = mysql + " , Credit_non_inventory_sales_anly_code_1, Credit_non_inventory_sales_anly_head_no_1 ";
							mysql = mysql + " , Credit_non_inventory_cost_of_sales_anly_code_1, Credit_non_inventory_cost_of_sales_anly_head_no_1 ";
							mysql = mysql + " , Credit_non_inventory_expense_anly_code_1, Credit_non_inventory_expense_anly_head_no_1 ";
						}

						//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
						if (grdVoucherDetails.Splits[0].DisplayColumns[grdAnlyCode2].Visible)
						{
							mysql = mysql + " , non_inventory_sales_anly_code_2, non_inventory_sales_anly_head_no_2 ";
							mysql = mysql + " , non_inventory_cost_of_sales_anly_code_2, non_inventory_cost_of_sales_anly_head_no_2 ";
							mysql = mysql + " , non_inventory_expense_anly_code_2 , non_inventory_expense_anly_head_no_2 ";

							mysql = mysql + " , Credit_non_inventory_sales_anly_code_2, Credit_non_inventory_sales_anly_head_no_2 ";
							mysql = mysql + " , Credit_non_inventory_cost_of_sales_anly_code_2, Credit_non_inventory_cost_of_sales_anly_head_no_2 ";
							mysql = mysql + " , Credit_non_inventory_expense_anly_code_2 , Credit_non_inventory_expense_anly_head_no_2 ";
						}

					}

					//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
					if (((TriState) ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetSystemPreferenceSetting("cost_center"))) == TriState.True)
					{
						mysql = mysql + " , Inventory_cost_Cd , Adjustment_cost_Cd, Cost_Of_Sale_cost_Cd ";
						mysql = mysql + " , PDis_cost_Cd, Cash_Sale_cost_Cd, Credit_Sale_cost_Cd, Cash_SDis_cost_Cd ";
						mysql = mysql + " , Credit_SDis_cost_Cd, PRet_cost_Cd, PRet_Dis_cost_Cd, Cash_SRet_cost_Cd ";
						mysql = mysql + " , Credit_SRet_cost_Cd ";
						mysql = mysql + " , Cash_SRet_Dis_cost_Cd, Credit_SRet_Dis_cost_Cd, Cash_cost_Cd, suspense_cost_cd ";

						if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("service_product")))
						{
							mysql = mysql + " , service_sales_cost_cd, service_cost_of_sales_cost_cd , service_expense_cost_cd ";
							mysql = mysql + " , Credit_service_sales_cost_cd, Credit_service_cost_of_sales_cost_cd , Credit_service_expense_cost_cd ";
						}

						if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("non_inventory_product")))
						{
							mysql = mysql + " , non_inventory_sales_cost_cd, non_inventory_cost_of_sales_cost_cd , non_inventory_expense_cost_cd ";
							mysql = mysql + " , Credit_non_inventory_sales_cost_cd, Credit_non_inventory_cost_of_sales_cost_cd , Credit_non_inventory_expense_cost_cd ";
						}
					}

					//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
					if (((TriState) ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetSystemPreferenceSetting("project_costing"))) == TriState.True)
					{
						mysql = mysql + " , inventory_project_cd, adjustment_project_cd, cost_of_sale_project_cd ";
						mysql = mysql + " , pdis_project_cd, cash_sale_project_cd, credit_sale_project_cd, cash_sdis_project_cd ";
						mysql = mysql + " , credit_sdis_project_cd, pret_project_cd, pret_dis_project_cd, cash_sret_project_cd ";
						mysql = mysql + " , credit_sret_project_cd ";
						mysql = mysql + " , cash_sret_dis_project_cd, credit_sret_dis_project_cd, cash_project_cd, suspense_project_cd ";

						if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("service_product")))
						{
							mysql = mysql + " , service_sales_project_cd,  service_cost_of_sales_project_cd , service_expense_project_cd ";
							mysql = mysql + " , Credit_service_sales_project_cd,  Credit_service_cost_of_sales_project_cd , Credit_service_expense_project_cd ";
						}

						if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("non_inventory_product")))
						{
							mysql = mysql + " , non_inventory_sales_project_cd, non_inventory_cost_of_sales_project_cd , non_inventory_expense_project_cd ";
							mysql = mysql + " , Credit_non_inventory_sales_project_cd, Credit_non_inventory_cost_of_sales_project_cd , Credit_non_inventory_expense_project_cd ";
						}
					}
				}

				mysql = mysql + " ) VALUES(" + Conversion.Str(SystemVariables.gLoggedInUserCode) + ",";
				mysql = mysql + txtLocationNo.Text + ",";
				mysql = mysql + "'" + txtLShortName.Text + "',";
				mysql = mysql + "N'" + txtAShortName.Text + "',";
				mysql = mysql + "'" + txtLLocationName.Text + "',";
				mysql = mysql + "N'" + txtALocationName.Text + "',";
				mysql = mysql + "'" + txtAdd1.Text + "',";
				mysql = mysql + "'" + txtAdd2.Text + "',";
				mysql = mysql + "'" + txtAdd3.Text + "',";
				mysql = mysql + "'" + txtContactPerson.Text + "'";

				if (txtDefaultLdgrNo.Visible)
				{
					mysql = mysql + " ,'" + txtDefaultLdgrNo.Text + "'";
					if (!SystemProcedure2.IsItEmpty(txtDefaultSalesmanNo.Text, SystemVariables.DataType.NumberType))
					{
						mysql = mysql + " ," + txtDefaultSalesmanNo.Text;
					}
					else
					{
						mysql = mysql + " , 0 ";
					}
					mysql = mysql + " ," + ((chkCashType.CheckState == CheckState.Checked) ? 1 : 0).ToString();
					mysql = mysql + " ,'" + txtDefaultCashCode.Text + "'";
				}
				else
				{
					mysql = mysql + " , NULL ";
					mysql = mysql + " , 0 ";
					mysql = mysql + " , 0 ";
					mysql = mysql + " , NULL ";
				}

				if (txtDefaultLdgrNo.Visible)
				{
					mysql = mysql + " ,'" + txtDataUploadPath.Text + "'";
				}
				else
				{
					mysql = mysql + " , NULL ";
				}

				if (chkCheckNegativeStock.CheckState == CheckState.Checked)
				{
					mysql = mysql + " , 1 ";
				}
				else
				{
					mysql = mysql + " , 0 ";
				}

				mysql = mysql + ",'" + txtPhone.Text + "',";
				mysql = mysql + "'" + txtComment.Text + "'";
				if (mFirstGridFocus)
				{
					mysql = mysql + "," + ReflectionHelper.GetPrimitiveValue<string>(mLedger[0, 0]) + ","; //Inventory code
					mysql = mysql + ReflectionHelper.GetPrimitiveValue<string>(mLedger[1, 0]) + ","; //Inventory Adjustment code
					mysql = mysql + ReflectionHelper.GetPrimitiveValue<string>(mLedger[2, 0]) + ","; //Cost of sale code
					mysql = mysql + ReflectionHelper.GetPrimitiveValue<string>(mLedger[3, 0]) + ","; //Purchase Discount code
					mysql = mysql + ReflectionHelper.GetPrimitiveValue<string>(mLedger[4, 0]) + ","; //Cash sale code
					mysql = mysql + ReflectionHelper.GetPrimitiveValue<string>(mLedger[5, 0]) + ","; //Credit Sale code
					mysql = mysql + ReflectionHelper.GetPrimitiveValue<string>(mLedger[6, 0]) + ","; //Cash Sale Discount code
					mysql = mysql + ReflectionHelper.GetPrimitiveValue<string>(mLedger[7, 0]) + ","; //Credit sale discount code
					mysql = mysql + ReflectionHelper.GetPrimitiveValue<string>(mLedger[8, 0]) + ","; //Purchase Return code
					mysql = mysql + ReflectionHelper.GetPrimitiveValue<string>(mLedger[9, 0]) + ","; //Purchase Return discount code
					mysql = mysql + ReflectionHelper.GetPrimitiveValue<string>(mLedger[10, 0]) + ","; //Cash Sale Return code
					mysql = mysql + ReflectionHelper.GetPrimitiveValue<string>(mLedger[11, 0]) + ","; //Credit Sale return code
					mysql = mysql + ReflectionHelper.GetPrimitiveValue<string>(mLedger[12, 0]) + ","; //Credit Sale return discountcode
					mysql = mysql + ReflectionHelper.GetPrimitiveValue<string>(mLedger[13, 0]) + ","; //Credit Sale return Discount  code
					mysql = mysql + ReflectionHelper.GetPrimitiveValue<string>(mLedger[14, 0]) + ","; //Cash code
					mysql = mysql + ReflectionHelper.GetPrimitiveValue<string>(mLedger[15, 0]); //Suspense code

					if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("anly_code_1")))
					{
						mysql = mysql + "," + ReflectionHelper.GetPrimitiveValue<string>(mLedger[0, 2]) + ", 1 "; //Inventory code
						mysql = mysql + "," + ReflectionHelper.GetPrimitiveValue<string>(mLedger[1, 2]) + ", 1 "; //Inventory Adjustment code
						mysql = mysql + "," + ReflectionHelper.GetPrimitiveValue<string>(mLedger[2, 2]) + ", 1 "; //Cost of sale code
						mysql = mysql + "," + ReflectionHelper.GetPrimitiveValue<string>(mLedger[3, 2]) + ", 1 "; //Purchase Discount code
						mysql = mysql + "," + ReflectionHelper.GetPrimitiveValue<string>(mLedger[4, 2]) + ", 1 "; //Cash sale code
						mysql = mysql + "," + ReflectionHelper.GetPrimitiveValue<string>(mLedger[5, 2]) + ", 1 "; //Credit Sale code
						mysql = mysql + "," + ReflectionHelper.GetPrimitiveValue<string>(mLedger[6, 2]) + ", 1 "; //Cash Sale Discount code
						mysql = mysql + "," + ReflectionHelper.GetPrimitiveValue<string>(mLedger[7, 2]) + ", 1 "; //Credit sale discount code
						mysql = mysql + "," + ReflectionHelper.GetPrimitiveValue<string>(mLedger[8, 2]) + ", 1 "; //Purchase Return code
						mysql = mysql + "," + ReflectionHelper.GetPrimitiveValue<string>(mLedger[9, 2]) + ", 1 "; //Purchase Return discount code
						mysql = mysql + "," + ReflectionHelper.GetPrimitiveValue<string>(mLedger[10, 2]) + ", 1 "; //Cash Sale Return code
						mysql = mysql + "," + ReflectionHelper.GetPrimitiveValue<string>(mLedger[11, 2]) + ", 1 "; //Credit Sale return code
						mysql = mysql + "," + ReflectionHelper.GetPrimitiveValue<string>(mLedger[12, 2]) + ", 1 "; //Credit Sale return discountcode
						mysql = mysql + "," + ReflectionHelper.GetPrimitiveValue<string>(mLedger[13, 2]) + ", 1 "; //Credit Sale return Discount  code
						mysql = mysql + "," + ReflectionHelper.GetPrimitiveValue<string>(mLedger[14, 2]) + ", 1 "; //Cash code
						mysql = mysql + "," + ReflectionHelper.GetPrimitiveValue<string>(mLedger[15, 2]) + ", 1 "; //Suspense code
					}

					if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("anly_code_2")))
					{
						mysql = mysql + "," + ReflectionHelper.GetPrimitiveValue<string>(mLedger[0, 2]) + ", 2 "; //Inventory code
						mysql = mysql + "," + ReflectionHelper.GetPrimitiveValue<string>(mLedger[1, 2]) + ", 2 "; //Inventory Adjustment code
						mysql = mysql + "," + ReflectionHelper.GetPrimitiveValue<string>(mLedger[2, 2]) + ", 2 "; //Cost of sale code
						mysql = mysql + "," + ReflectionHelper.GetPrimitiveValue<string>(mLedger[3, 2]) + ", 2 "; //Purchase Discount code
						mysql = mysql + "," + ReflectionHelper.GetPrimitiveValue<string>(mLedger[4, 2]) + ", 2 "; //Cash sale code
						mysql = mysql + "," + ReflectionHelper.GetPrimitiveValue<string>(mLedger[5, 2]) + ", 2 "; //Credit Sale code
						mysql = mysql + "," + ReflectionHelper.GetPrimitiveValue<string>(mLedger[6, 2]) + ", 2 "; //Cash Sale Discount code
						mysql = mysql + "," + ReflectionHelper.GetPrimitiveValue<string>(mLedger[7, 2]) + ", 2 "; //Credit sale discount code
						mysql = mysql + "," + ReflectionHelper.GetPrimitiveValue<string>(mLedger[8, 2]) + ", 2 "; //Purchase Return code
						mysql = mysql + "," + ReflectionHelper.GetPrimitiveValue<string>(mLedger[9, 2]) + ", 2 "; //Purchase Return discount code
						mysql = mysql + "," + ReflectionHelper.GetPrimitiveValue<string>(mLedger[10, 2]) + ", 2 "; //Cash Sale Return code
						mysql = mysql + "," + ReflectionHelper.GetPrimitiveValue<string>(mLedger[11, 2]) + ", 2 "; //Credit Sale return code
						mysql = mysql + "," + ReflectionHelper.GetPrimitiveValue<string>(mLedger[12, 2]) + ", 2 "; //Credit Sale return discountcode
						mysql = mysql + "," + ReflectionHelper.GetPrimitiveValue<string>(mLedger[13, 2]) + ", 2 "; //Credit Sale return Discount  code
						mysql = mysql + "," + ReflectionHelper.GetPrimitiveValue<string>(mLedger[14, 2]) + ", 2 "; //Cash code
						mysql = mysql + "," + ReflectionHelper.GetPrimitiveValue<string>(mLedger[15, 2]) + ", 2 "; //Suspense code
					}

					if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("service_product")))
					{
						mysql = mysql + ", " + ReflectionHelper.GetPrimitiveValue<string>(mLedger[16, 0]); //Service sales code
						mysql = mysql + ", " + ReflectionHelper.GetPrimitiveValue<string>(mLedger[17, 0]); //Service cost of sales code
						mysql = mysql + ", " + ReflectionHelper.GetPrimitiveValue<string>(mLedger[18, 0]); //service expenses code

						mysql = mysql + ", " + ReflectionHelper.GetPrimitiveValue<string>(mLedger[19, 0]); //Service sales code
						mysql = mysql + ", " + ReflectionHelper.GetPrimitiveValue<string>(mLedger[20, 0]); //Service cost of sales code
						mysql = mysql + ", " + ReflectionHelper.GetPrimitiveValue<string>(mLedger[21, 0]); //service expenses code

						if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("anly_code_1")))
						{
							mysql = mysql + "," + ReflectionHelper.GetPrimitiveValue<string>(mLedger[16, 2]) + ", 1 ";
							mysql = mysql + "," + ReflectionHelper.GetPrimitiveValue<string>(mLedger[17, 2]) + ", 1 ";
							mysql = mysql + "," + ReflectionHelper.GetPrimitiveValue<string>(mLedger[18, 2]) + ", 1 ";

							mysql = mysql + "," + ReflectionHelper.GetPrimitiveValue<string>(mLedger[19, 2]) + ", 1 ";
							mysql = mysql + "," + ReflectionHelper.GetPrimitiveValue<string>(mLedger[20, 2]) + ", 1 ";
							mysql = mysql + "," + ReflectionHelper.GetPrimitiveValue<string>(mLedger[21, 2]) + ", 1 ";
						}

						if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("anly_code_2")))
						{
							mysql = mysql + "," + ReflectionHelper.GetPrimitiveValue<string>(mLedger[16, 3]) + ", 2 ";
							mysql = mysql + "," + ReflectionHelper.GetPrimitiveValue<string>(mLedger[17, 3]) + ", 2 ";
							mysql = mysql + "," + ReflectionHelper.GetPrimitiveValue<string>(mLedger[18, 3]) + ", 2 ";

							mysql = mysql + "," + ReflectionHelper.GetPrimitiveValue<string>(mLedger[19, 3]) + ", 2 ";
							mysql = mysql + "," + ReflectionHelper.GetPrimitiveValue<string>(mLedger[20, 3]) + ", 2 ";
							mysql = mysql + "," + ReflectionHelper.GetPrimitiveValue<string>(mLedger[21, 3]) + ", 2 ";
						}
					}

					if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("non_inventory_product")))
					{
						//Non Inventory sales code
						mysql = mysql + ", " + ReflectionHelper.GetPrimitiveValue<string>(mLedger[16 + mNonInventoryIncrementValue, 0]);

						//Non Inventory cost of sales code
						mysql = mysql + ", " + ReflectionHelper.GetPrimitiveValue<string>(mLedger[17 + mNonInventoryIncrementValue, 0]);

						//Non Inventory expenses code
						mysql = mysql + ", " + ReflectionHelper.GetPrimitiveValue<string>(mLedger[18 + mNonInventoryIncrementValue, 0]);

						//Non Inventory sales code
						mysql = mysql + ", " + ReflectionHelper.GetPrimitiveValue<string>(mLedger[19 + mNonInventoryIncrementValue, 0]);

						//Non Inventory cost of sales code
						mysql = mysql + ", " + ReflectionHelper.GetPrimitiveValue<string>(mLedger[20 + mNonInventoryIncrementValue, 0]);

						//Non Inventory expenses code
						mysql = mysql + ", " + ReflectionHelper.GetPrimitiveValue<string>(mLedger[21 + mNonInventoryIncrementValue, 0]);

						if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("anly_code_1")))
						{
							mysql = mysql + "," + ReflectionHelper.GetPrimitiveValue<string>(mLedger[16 + mNonInventoryIncrementValue, 2]) + ", 1 ";
							mysql = mysql + "," + ReflectionHelper.GetPrimitiveValue<string>(mLedger[17 + mNonInventoryIncrementValue, 2]) + ", 1 ";
							mysql = mysql + "," + ReflectionHelper.GetPrimitiveValue<string>(mLedger[18 + mNonInventoryIncrementValue, 2]) + ", 1 ";

							mysql = mysql + "," + ReflectionHelper.GetPrimitiveValue<string>(mLedger[19 + mNonInventoryIncrementValue, 2]) + ", 1 ";
							mysql = mysql + "," + ReflectionHelper.GetPrimitiveValue<string>(mLedger[20 + mNonInventoryIncrementValue, 2]) + ", 1 ";
							mysql = mysql + "," + ReflectionHelper.GetPrimitiveValue<string>(mLedger[21 + mNonInventoryIncrementValue, 2]) + ", 1 ";
						}

						if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("anly_code_2")))
						{
							mysql = mysql + "," + ReflectionHelper.GetPrimitiveValue<string>(mLedger[16 + mNonInventoryIncrementValue, 3]) + ", 2 ";
							mysql = mysql + "," + ReflectionHelper.GetPrimitiveValue<string>(mLedger[17 + mNonInventoryIncrementValue, 3]) + ", 2 ";
							mysql = mysql + "," + ReflectionHelper.GetPrimitiveValue<string>(mLedger[18 + mNonInventoryIncrementValue, 3]) + ", 2 ";

							mysql = mysql + "," + ReflectionHelper.GetPrimitiveValue<string>(mLedger[19 + mNonInventoryIncrementValue, 3]) + ", 2 ";
							mysql = mysql + "," + ReflectionHelper.GetPrimitiveValue<string>(mLedger[20 + mNonInventoryIncrementValue, 3]) + ", 2 ";
							mysql = mysql + "," + ReflectionHelper.GetPrimitiveValue<string>(mLedger[21 + mNonInventoryIncrementValue, 3]) + ", 2 ";
						}

					}

					//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
					if (((TriState) ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetSystemPreferenceSetting("cost_center"))) == TriState.True)
					{
						mysql = mysql + "," + ReflectionHelper.GetPrimitiveValue<string>(mLedger[0, 1]) + ","; //Inventory code
						mysql = mysql + ReflectionHelper.GetPrimitiveValue<string>(mLedger[1, 1]) + ","; //Inventory Adjustment code
						mysql = mysql + ReflectionHelper.GetPrimitiveValue<string>(mLedger[2, 1]) + ","; //Cost of sale code
						mysql = mysql + ReflectionHelper.GetPrimitiveValue<string>(mLedger[3, 1]) + ","; //Purchase Discount code
						mysql = mysql + ReflectionHelper.GetPrimitiveValue<string>(mLedger[4, 1]) + ","; //Cash sale code
						mysql = mysql + ReflectionHelper.GetPrimitiveValue<string>(mLedger[5, 1]) + ","; //Credit Sale code
						mysql = mysql + ReflectionHelper.GetPrimitiveValue<string>(mLedger[6, 1]) + ","; //Cash Sale Discount code
						mysql = mysql + ReflectionHelper.GetPrimitiveValue<string>(mLedger[7, 1]) + ","; //Credit sale discount code
						mysql = mysql + ReflectionHelper.GetPrimitiveValue<string>(mLedger[8, 1]) + ","; //Purchase Return code
						mysql = mysql + ReflectionHelper.GetPrimitiveValue<string>(mLedger[9, 1]) + ","; //Purchase Return discount code
						mysql = mysql + ReflectionHelper.GetPrimitiveValue<string>(mLedger[10, 1]) + ","; //Cash Sale Return code
						mysql = mysql + ReflectionHelper.GetPrimitiveValue<string>(mLedger[11, 1]) + ","; //Credit Sale return code
						mysql = mysql + ReflectionHelper.GetPrimitiveValue<string>(mLedger[12, 1]) + ","; //Credit Sale return discountcode
						mysql = mysql + ReflectionHelper.GetPrimitiveValue<string>(mLedger[13, 1]) + ","; //Credit Sale return Discount  code
						mysql = mysql + ReflectionHelper.GetPrimitiveValue<string>(mLedger[14, 1]) + ","; //Cash cost code
						mysql = mysql + ReflectionHelper.GetPrimitiveValue<string>(mLedger[15, 1]) + " "; //Suspense cost code


						if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("service_product")))
						{
							mysql = mysql + "," + ReflectionHelper.GetPrimitiveValue<string>(mLedger[16, 1]); //Service sales code
							mysql = mysql + "," + ReflectionHelper.GetPrimitiveValue<string>(mLedger[17, 1]); //Service cost of sales code
							mysql = mysql + "," + ReflectionHelper.GetPrimitiveValue<string>(mLedger[18, 1]); //service expenses code

							mysql = mysql + "," + ReflectionHelper.GetPrimitiveValue<string>(mLedger[19, 1]); //Service sales code
							mysql = mysql + "," + ReflectionHelper.GetPrimitiveValue<string>(mLedger[20, 1]); //Service cost of sales code
							mysql = mysql + "," + ReflectionHelper.GetPrimitiveValue<string>(mLedger[21, 1]); //service expenses code
						}

						if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("non_inventory_product")))
						{
							//Non Inventory sales code
							mysql = mysql + ", " + ReflectionHelper.GetPrimitiveValue<string>(mLedger[16 + mNonInventoryIncrementValue, 1]);

							//Non Inventory cost of sales code
							mysql = mysql + ", " + ReflectionHelper.GetPrimitiveValue<string>(mLedger[17 + mNonInventoryIncrementValue, 1]);

							//Non Inventory expenses code
							mysql = mysql + ", " + ReflectionHelper.GetPrimitiveValue<string>(mLedger[18 + mNonInventoryIncrementValue, 1]);

							//Non Inventory sales code
							mysql = mysql + ", " + ReflectionHelper.GetPrimitiveValue<string>(mLedger[19 + mNonInventoryIncrementValue, 1]);

							//Non Inventory cost of sales code
							mysql = mysql + ", " + ReflectionHelper.GetPrimitiveValue<string>(mLedger[20 + mNonInventoryIncrementValue, 1]);

							//Non Inventory expenses code
							mysql = mysql + ", " + ReflectionHelper.GetPrimitiveValue<string>(mLedger[21 + mNonInventoryIncrementValue, 1]);
						}
					}

					//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
					if (((TriState) ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetSystemPreferenceSetting("project_costing"))) == TriState.True)
					{
						mysql = mysql + "," + ReflectionHelper.GetPrimitiveValue<string>(mLedger[0, 4]) + ","; //Inventory code
						mysql = mysql + ReflectionHelper.GetPrimitiveValue<string>(mLedger[1, 4]) + ","; //Inventory Adjustment code
						mysql = mysql + ReflectionHelper.GetPrimitiveValue<string>(mLedger[2, 4]) + ","; //Cost of sale code
						mysql = mysql + ReflectionHelper.GetPrimitiveValue<string>(mLedger[3, 4]) + ","; //Purchase Discount code
						mysql = mysql + ReflectionHelper.GetPrimitiveValue<string>(mLedger[4, 4]) + ","; //Cash sale code
						mysql = mysql + ReflectionHelper.GetPrimitiveValue<string>(mLedger[5, 4]) + ","; //Credit Sale code
						mysql = mysql + ReflectionHelper.GetPrimitiveValue<string>(mLedger[6, 4]) + ","; //Cash Sale Discount code
						mysql = mysql + ReflectionHelper.GetPrimitiveValue<string>(mLedger[7, 4]) + ","; //Credit sale discount code
						mysql = mysql + ReflectionHelper.GetPrimitiveValue<string>(mLedger[8, 4]) + ","; //Purchase Return code
						mysql = mysql + ReflectionHelper.GetPrimitiveValue<string>(mLedger[9, 4]) + ","; //Purchase Return discount code
						mysql = mysql + ReflectionHelper.GetPrimitiveValue<string>(mLedger[10, 4]) + ","; //Cash Sale Return code
						mysql = mysql + ReflectionHelper.GetPrimitiveValue<string>(mLedger[11, 4]) + ","; //Credit Sale return code
						mysql = mysql + ReflectionHelper.GetPrimitiveValue<string>(mLedger[12, 4]) + ","; //Credit Sale return discountcode
						mysql = mysql + ReflectionHelper.GetPrimitiveValue<string>(mLedger[13, 4]) + ","; //Credit Sale return Discount  code
						mysql = mysql + ReflectionHelper.GetPrimitiveValue<string>(mLedger[14, 4]) + ","; //Cash cost code
						mysql = mysql + ReflectionHelper.GetPrimitiveValue<string>(mLedger[15, 4]) + " "; //Suspense cost code


						if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("service_product")))
						{
							mysql = mysql + "," + ReflectionHelper.GetPrimitiveValue<string>(mLedger[16, 4]); //Service sales code
							mysql = mysql + "," + ReflectionHelper.GetPrimitiveValue<string>(mLedger[17, 4]); //Service cost of sales code
							mysql = mysql + "," + ReflectionHelper.GetPrimitiveValue<string>(mLedger[18, 4]); //service expenses code

							mysql = mysql + "," + ReflectionHelper.GetPrimitiveValue<string>(mLedger[19, 4]); //Service sales code
							mysql = mysql + "," + ReflectionHelper.GetPrimitiveValue<string>(mLedger[20, 4]); //Service cost of sales code
							mysql = mysql + "," + ReflectionHelper.GetPrimitiveValue<string>(mLedger[21, 4]); //service expenses code
						}

						if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("non_inventory_product")))
						{
							//Non Inventory sales code
							mysql = mysql + ", " + ReflectionHelper.GetPrimitiveValue<string>(mLedger[16 + mNonInventoryIncrementValue, 4]);

							//Non Inventory cost of sales code
							mysql = mysql + ", " + ReflectionHelper.GetPrimitiveValue<string>(mLedger[17 + mNonInventoryIncrementValue, 4]);

							//Non Inventory expenses code
							mysql = mysql + ", " + ReflectionHelper.GetPrimitiveValue<string>(mLedger[18 + mNonInventoryIncrementValue, 4]);

							//Non Inventory sales code
							mysql = mysql + ", " + ReflectionHelper.GetPrimitiveValue<string>(mLedger[19 + mNonInventoryIncrementValue, 4]);

							//Non Inventory cost of sales code
							mysql = mysql + ", " + ReflectionHelper.GetPrimitiveValue<string>(mLedger[20 + mNonInventoryIncrementValue, 4]);

							//Non Inventory expenses code
							mysql = mysql + ", " + ReflectionHelper.GetPrimitiveValue<string>(mLedger[21 + mNonInventoryIncrementValue, 4]);
						}
					}
				}
				mysql = mysql + ")";
				SqlCommand TempCommand = null;
				TempCommand = SystemVariables.gConn.CreateCommand();
				TempCommand.CommandText = mysql;
				TempCommand.ExecuteNonQuery();
			}
			else
			{

				mysql = " select time_stamp ,protected from SM_Location where locat_cd=" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
				//if the time stamp does not match the previous one then rollback
				if (SystemProcedure2.tsFormat(ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(0))) != SystemProcedure2.tsFormat(mTimeStamp))
				{
					MessageBox.Show(SystemConstants.msg10, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					return false;
				}

				mysql = "UPDATE SM_Location SET";
				mysql = mysql + " Locat_No =" + txtLocationNo.Text + ",";
				mysql = mysql + " L_Locat_Name ='" + txtLLocationName.Text + "',";
				mysql = mysql + " A_Locat_Name =N'" + txtALocationName.Text + "',";
				mysql = mysql + " L_Short_Name ='" + txtLShortName.Text + "',";
				mysql = mysql + " A_Short_Name =N'" + txtAShortName.Text + "',";
				mysql = mysql + " Addr_1 ='" + txtAdd1.Text + "',";
				mysql = mysql + " Addr_2 ='" + txtAdd3.Text + "',";
				mysql = mysql + " Addr_3 ='" + txtAdd3.Text + "',";
				mysql = mysql + " Contact_Person ='" + txtContactPerson.Text + "',";
				mysql = mysql + " Phone ='" + txtPhone.Text + "',";
				mysql = mysql + " Comments ='" + txtComment.Text + "',";
				if (chkCheckNegativeStock.CheckState == CheckState.Checked)
				{
					mysql = mysql + " check_negative_stock = 1 ";
				}
				else
				{
					mysql = mysql + " check_negative_stock = 0 ";
				}
				mysql = mysql + " , User_Cd =" + Conversion.Str(SystemVariables.gLoggedInUserCode);

				if (txtDefaultLdgrNo.Visible)
				{
					mysql = mysql + " , last_ldgr_no='" + txtDefaultLdgrNo.Text + "'";
					if (!SystemProcedure2.IsItEmpty(txtDefaultSalesmanNo.Text, SystemVariables.DataType.NumberType))
					{
						mysql = mysql + " , Default_Sman_No=" + txtDefaultSalesmanNo.Text;
					}
					else
					{
						mysql = mysql + " , Default_Sman_No= 0  ";
					}

					mysql = mysql + " , last_cash_type=" + ((chkCashType.CheckState == CheckState.Checked) ? 1 : 0).ToString();
					mysql = mysql + " , last_cash_no='" + txtDefaultCashCode.Text + "'";
				}
				else
				{
					mysql = mysql + " , last_ldgr_no = NULL ";
					mysql = mysql + " , Default_Sman_No = 0 ";
					mysql = mysql + " , last_cash_type = 0 ";
					mysql = mysql + " , last_cash_no= NULL ";
				}

				if (txtDataUploadPath.Visible)
				{
					mysql = mysql + " , data_upload_path='" + txtDataUploadPath.Text + "'";
				}
				else
				{
					mysql = mysql + " , data_upload_path=NULL ";
				}

				if (mFirstGridFocus)
				{
					mysql = mysql + " , Inventory_Cd =" + ReflectionHelper.GetPrimitiveValue<string>(mLedger[0, 0]) + ",";
					mysql = mysql + " Adjustment_Cd =" + ReflectionHelper.GetPrimitiveValue<string>(mLedger[1, 0]) + ",";
					mysql = mysql + " Cost_Of_Sale_Cd =" + ReflectionHelper.GetPrimitiveValue<string>(mLedger[2, 0]) + ",";
					mysql = mysql + " PDis_Cd =" + ReflectionHelper.GetPrimitiveValue<string>(mLedger[3, 0]) + ",";
					mysql = mysql + " Cash_Sale_Cd =" + ReflectionHelper.GetPrimitiveValue<string>(mLedger[4, 0]) + ",";
					mysql = mysql + " Credit_Sale_Cd =" + ReflectionHelper.GetPrimitiveValue<string>(mLedger[5, 0]) + ",";
					mysql = mysql + " Cash_SDis_Cd =" + ReflectionHelper.GetPrimitiveValue<string>(mLedger[6, 0]) + ",";
					mysql = mysql + " Credit_SDis_Cd =" + ReflectionHelper.GetPrimitiveValue<string>(mLedger[7, 0]) + ",";
					mysql = mysql + " PRet_Cd =" + ReflectionHelper.GetPrimitiveValue<string>(mLedger[8, 0]) + ",";
					mysql = mysql + " PRet_Dis_Cd =" + ReflectionHelper.GetPrimitiveValue<string>(mLedger[9, 0]) + ",";
					mysql = mysql + " Cash_SRet_Cd =" + ReflectionHelper.GetPrimitiveValue<string>(mLedger[10, 0]) + ",";
					mysql = mysql + " Credit_SRet_Cd =" + ReflectionHelper.GetPrimitiveValue<string>(mLedger[11, 0]) + ",";
					mysql = mysql + " Cash_SRet_Dis_Cd =" + ReflectionHelper.GetPrimitiveValue<string>(mLedger[12, 0]) + ",";
					mysql = mysql + " Credit_SRet_Dis_Cd =" + ReflectionHelper.GetPrimitiveValue<string>(mLedger[13, 0]) + ",";
					mysql = mysql + " Cash_Cd =" + ReflectionHelper.GetPrimitiveValue<string>(mLedger[14, 0]) + ",";
					mysql = mysql + " suspense_Cd =" + ReflectionHelper.GetPrimitiveValue<string>(mLedger[15, 0]) + "";

					//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
					if (grdVoucherDetails.Splits[0].DisplayColumns[grdAnlyCode1].Visible)
					{
						mysql = mysql + " , inventory_anly_code_1 =" + ReflectionHelper.GetPrimitiveValue<string>(mLedger[0, 2]);
						mysql = mysql + " , adjustment_anly_code_1 =" + ReflectionHelper.GetPrimitiveValue<string>(mLedger[1, 2]);
						mysql = mysql + " , cost_of_sale_anly_code_1 =" + ReflectionHelper.GetPrimitiveValue<string>(mLedger[2, 2]);
						mysql = mysql + " , pdis_anly_code_1 =" + ReflectionHelper.GetPrimitiveValue<string>(mLedger[3, 2]);
						mysql = mysql + " , cash_sale_anly_code_1 =" + ReflectionHelper.GetPrimitiveValue<string>(mLedger[4, 2]);
						mysql = mysql + " , credit_sale_anly_code_1 =" + ReflectionHelper.GetPrimitiveValue<string>(mLedger[5, 2]);
						mysql = mysql + " , cash_sdis_anly_code_1 =" + ReflectionHelper.GetPrimitiveValue<string>(mLedger[6, 2]);
						mysql = mysql + " , credit_sdis_anly_code_1 =" + ReflectionHelper.GetPrimitiveValue<string>(mLedger[7, 2]);
						mysql = mysql + " , pret_anly_code_1 =" + ReflectionHelper.GetPrimitiveValue<string>(mLedger[8, 2]);
						mysql = mysql + " , pret_dis_anly_code_1 =" + ReflectionHelper.GetPrimitiveValue<string>(mLedger[9, 2]);
						mysql = mysql + " , cash_sret_anly_code_1 =" + ReflectionHelper.GetPrimitiveValue<string>(mLedger[10, 2]);
						mysql = mysql + " , credit_sret_anly_code_1 =" + ReflectionHelper.GetPrimitiveValue<string>(mLedger[11, 2]);
						mysql = mysql + " , cash_sret_dis_anly_code_1 =" + ReflectionHelper.GetPrimitiveValue<string>(mLedger[12, 2]);
						mysql = mysql + " , credit_sret_dis_anly_code_1 =" + ReflectionHelper.GetPrimitiveValue<string>(mLedger[13, 2]);
						mysql = mysql + " , cash_anly_code_1 =" + ReflectionHelper.GetPrimitiveValue<string>(mLedger[14, 2]);
						mysql = mysql + " , suspense_anly_code_1 =" + ReflectionHelper.GetPrimitiveValue<string>(mLedger[15, 2]);
					}

					//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
					if (grdVoucherDetails.Splits[0].DisplayColumns[grdAnlyCode2].Visible)
					{
						mysql = mysql + " , inventory_anly_code_2 =" + ReflectionHelper.GetPrimitiveValue<string>(mLedger[0, 3]);
						mysql = mysql + " , adjustment_anly_code_2 =" + ReflectionHelper.GetPrimitiveValue<string>(mLedger[1, 3]);
						mysql = mysql + " , cost_of_sale_anly_code_2 =" + ReflectionHelper.GetPrimitiveValue<string>(mLedger[2, 3]);
						mysql = mysql + " , pdis_anly_code_2 =" + ReflectionHelper.GetPrimitiveValue<string>(mLedger[3, 3]);
						mysql = mysql + " , cash_sale_anly_code_2 =" + ReflectionHelper.GetPrimitiveValue<string>(mLedger[4, 3]);
						mysql = mysql + " , credit_sale_anly_code_2 =" + ReflectionHelper.GetPrimitiveValue<string>(mLedger[5, 3]);
						mysql = mysql + " , cash_sdis_anly_code_2 =" + ReflectionHelper.GetPrimitiveValue<string>(mLedger[6, 3]);
						mysql = mysql + " , credit_sdis_anly_code_2 =" + ReflectionHelper.GetPrimitiveValue<string>(mLedger[7, 3]);
						mysql = mysql + " , pret_anly_code_2 =" + ReflectionHelper.GetPrimitiveValue<string>(mLedger[8, 3]);
						mysql = mysql + " , pret_dis_anly_code_2 =" + ReflectionHelper.GetPrimitiveValue<string>(mLedger[9, 3]);
						mysql = mysql + " , cash_sret_anly_code_2 =" + ReflectionHelper.GetPrimitiveValue<string>(mLedger[10, 3]);
						mysql = mysql + " , credit_sret_anly_code_2 =" + ReflectionHelper.GetPrimitiveValue<string>(mLedger[11, 3]);
						mysql = mysql + " , cash_sret_dis_anly_code_2 =" + ReflectionHelper.GetPrimitiveValue<string>(mLedger[12, 3]);
						mysql = mysql + " , credit_sret_dis_anly_code_2 =" + ReflectionHelper.GetPrimitiveValue<string>(mLedger[13, 3]);
						mysql = mysql + " , cash_anly_code_2 =" + ReflectionHelper.GetPrimitiveValue<string>(mLedger[14, 3]);
						mysql = mysql + " , suspense_anly_code_2 =" + ReflectionHelper.GetPrimitiveValue<string>(mLedger[15, 3]);
					}

					if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("service_product")))
					{
						mysql = mysql + ", service_sales_cd = " + ReflectionHelper.GetPrimitiveValue<string>(mLedger[16, 0]) + "";
						mysql = mysql + ", service_cost_of_sales_cd= " + ReflectionHelper.GetPrimitiveValue<string>(mLedger[17, 0]) + "";
						mysql = mysql + ", service_expense_cd = " + ReflectionHelper.GetPrimitiveValue<string>(mLedger[18, 0]) + "";

						mysql = mysql + ", credit_service_sales_cd = " + ReflectionHelper.GetPrimitiveValue<string>(mLedger[19, 0]) + "";
						mysql = mysql + ", credit_service_cost_of_sales_cd= " + ReflectionHelper.GetPrimitiveValue<string>(mLedger[20, 0]) + "";
						mysql = mysql + ", credit_service_expense_cd = " + ReflectionHelper.GetPrimitiveValue<string>(mLedger[21, 0]) + "";

						//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
						if (grdVoucherDetails.Splits[0].DisplayColumns[grdAnlyCode1].Visible)
						{
							mysql = mysql + " , service_sales_anly_code_1 =" + ReflectionHelper.GetPrimitiveValue<string>(mLedger[16, 2]);
							mysql = mysql + " , service_expense_anly_code_1 =" + ReflectionHelper.GetPrimitiveValue<string>(mLedger[17, 2]);
							mysql = mysql + " , service_cost_of_sales_anly_code_1 =" + ReflectionHelper.GetPrimitiveValue<string>(mLedger[18, 2]);

							mysql = mysql + " , credit_service_sales_anly_code_1 =" + ReflectionHelper.GetPrimitiveValue<string>(mLedger[19, 2]);
							mysql = mysql + " , credit_service_expense_anly_code_1 =" + ReflectionHelper.GetPrimitiveValue<string>(mLedger[20, 2]);
							mysql = mysql + " , credit_service_cost_of_sales_anly_code_1 =" + ReflectionHelper.GetPrimitiveValue<string>(mLedger[21, 2]);
						}

						//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
						if (grdVoucherDetails.Splits[0].DisplayColumns[grdAnlyCode2].Visible)
						{
							mysql = mysql + " , service_sales_anly_code_2 =" + ReflectionHelper.GetPrimitiveValue<string>(mLedger[16, 3]);
							mysql = mysql + " , service_expense_anly_code_2 =" + ReflectionHelper.GetPrimitiveValue<string>(mLedger[17, 3]);
							mysql = mysql + " , service_cost_of_sales_anly_code_2 =" + ReflectionHelper.GetPrimitiveValue<string>(mLedger[18, 3]);

							mysql = mysql + " , credit_service_sales_anly_code_2 =" + ReflectionHelper.GetPrimitiveValue<string>(mLedger[19, 3]);
							mysql = mysql + " , credit_service_expense_anly_code_2 =" + ReflectionHelper.GetPrimitiveValue<string>(mLedger[20, 3]);
							mysql = mysql + " , credit_service_cost_of_sales_anly_code_2 =" + ReflectionHelper.GetPrimitiveValue<string>(mLedger[21, 3]);
						}
					}

					if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("non_inventory_product")))
					{
						mysql = mysql + ", non_inventory_sales_cd = " + ReflectionHelper.GetPrimitiveValue<string>(mLedger[16 + mNonInventoryIncrementValue, 0]) + "";
						mysql = mysql + ", non_inventory_cost_of_sales_cd = " + ReflectionHelper.GetPrimitiveValue<string>(mLedger[17 + mNonInventoryIncrementValue, 0]) + "";
						mysql = mysql + ", non_inventory_expense_cd = " + ReflectionHelper.GetPrimitiveValue<string>(mLedger[18 + mNonInventoryIncrementValue, 0]) + "";

						mysql = mysql + ", credit_non_inventory_sales_cd = " + ReflectionHelper.GetPrimitiveValue<string>(mLedger[19 + mNonInventoryIncrementValue, 0]) + "";
						mysql = mysql + ", credit_non_inventory_cost_of_sales_cd = " + ReflectionHelper.GetPrimitiveValue<string>(mLedger[20 + mNonInventoryIncrementValue, 0]) + "";
						mysql = mysql + ", credit_non_inventory_expense_cd = " + ReflectionHelper.GetPrimitiveValue<string>(mLedger[21 + mNonInventoryIncrementValue, 0]) + "";

						//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
						if (grdVoucherDetails.Splits[0].DisplayColumns[grdAnlyCode1].Visible)
						{
							mysql = mysql + " , non_inventory_sales_anly_code_1 =" + ReflectionHelper.GetPrimitiveValue<string>(mLedger[16 + mNonInventoryIncrementValue, 2]);
							mysql = mysql + " , non_inventory_expense_anly_code_1 =" + ReflectionHelper.GetPrimitiveValue<string>(mLedger[17 + mNonInventoryIncrementValue, 2]);
							mysql = mysql + " , non_inventory_cost_of_sales_anly_code_1 =" + ReflectionHelper.GetPrimitiveValue<string>(mLedger[18 + mNonInventoryIncrementValue, 2]);

							mysql = mysql + " , credit_non_inventory_sales_anly_code_1 =" + ReflectionHelper.GetPrimitiveValue<string>(mLedger[19 + mNonInventoryIncrementValue, 2]);
							mysql = mysql + " , credit_non_inventory_expense_anly_code_1 =" + ReflectionHelper.GetPrimitiveValue<string>(mLedger[20 + mNonInventoryIncrementValue, 2]);
							mysql = mysql + " , credit_non_inventory_cost_of_sales_anly_code_1 =" + ReflectionHelper.GetPrimitiveValue<string>(mLedger[21 + mNonInventoryIncrementValue, 2]);
						}

						//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
						if (grdVoucherDetails.Splits[0].DisplayColumns[grdAnlyCode2].Visible)
						{
							mysql = mysql + " , non_inventory_sales_anly_code_2 =" + ReflectionHelper.GetPrimitiveValue<string>(mLedger[16 + mNonInventoryIncrementValue, 3]);
							mysql = mysql + " , non_inventory_expense_anly_code_2 =" + ReflectionHelper.GetPrimitiveValue<string>(mLedger[17 + mNonInventoryIncrementValue, 3]);
							mysql = mysql + " , non_inventory_cost_of_sales_anly_code_2 =" + ReflectionHelper.GetPrimitiveValue<string>(mLedger[18 + mNonInventoryIncrementValue, 3]);

							mysql = mysql + " , credit_non_inventory_sales_anly_code_2 =" + ReflectionHelper.GetPrimitiveValue<string>(mLedger[19 + mNonInventoryIncrementValue, 3]);
							mysql = mysql + " , credit_non_inventory_expense_anly_code_2 =" + ReflectionHelper.GetPrimitiveValue<string>(mLedger[20 + mNonInventoryIncrementValue, 3]);
							mysql = mysql + " , credit_non_inventory_cost_of_sales_anly_code_2 =" + ReflectionHelper.GetPrimitiveValue<string>(mLedger[21 + mNonInventoryIncrementValue, 3]);
						}

					}

					if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("cost_center")))
					{
						mysql = mysql + " , Inventory_cost_Cd =" + ReflectionHelper.GetPrimitiveValue<string>(mLedger[0, 1]) + ",";
						mysql = mysql + " Adjustment_cost_Cd =" + ReflectionHelper.GetPrimitiveValue<string>(mLedger[1, 1]) + ",";
						mysql = mysql + " Cost_Of_Sale_cost_Cd =" + ReflectionHelper.GetPrimitiveValue<string>(mLedger[2, 1]) + ",";
						mysql = mysql + " PDis_cost_Cd =" + ReflectionHelper.GetPrimitiveValue<string>(mLedger[3, 1]) + ",";
						mysql = mysql + " Cash_Sale_cost_Cd =" + ReflectionHelper.GetPrimitiveValue<string>(mLedger[4, 1]) + ",";
						mysql = mysql + " Credit_Sale_cost_Cd =" + ReflectionHelper.GetPrimitiveValue<string>(mLedger[5, 1]) + ",";
						mysql = mysql + " Cash_SDis_cost_Cd =" + ReflectionHelper.GetPrimitiveValue<string>(mLedger[6, 1]) + ",";
						mysql = mysql + " Credit_SDis_cost_Cd =" + ReflectionHelper.GetPrimitiveValue<string>(mLedger[7, 1]) + ",";
						mysql = mysql + " PRet_cost_Cd =" + ReflectionHelper.GetPrimitiveValue<string>(mLedger[8, 1]) + ",";
						mysql = mysql + " PRet_Dis_cost_Cd =" + ReflectionHelper.GetPrimitiveValue<string>(mLedger[9, 1]) + ",";
						mysql = mysql + " Cash_SRet_cost_Cd =" + ReflectionHelper.GetPrimitiveValue<string>(mLedger[10, 1]) + ",";
						mysql = mysql + " Credit_SRet_cost_Cd =" + ReflectionHelper.GetPrimitiveValue<string>(mLedger[11, 1]) + ",";
						mysql = mysql + " Cash_SRet_Dis_cost_Cd =" + ReflectionHelper.GetPrimitiveValue<string>(mLedger[12, 1]) + ",";
						mysql = mysql + " Credit_SRet_Dis_cost_Cd =" + ReflectionHelper.GetPrimitiveValue<string>(mLedger[13, 1]) + ",";
						mysql = mysql + " Cash_cost_Cd =" + ReflectionHelper.GetPrimitiveValue<string>(mLedger[14, 1]) + ",";
						mysql = mysql + " suspense_cost_Cd =" + ReflectionHelper.GetPrimitiveValue<string>(mLedger[15, 1]);

						if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("service_product")))
						{
							mysql = mysql + ", service_sales_cost_cd =" + ReflectionHelper.GetPrimitiveValue<string>(mLedger[16, 1]) + ",";
							mysql = mysql + " service_cost_of_sales_cost_cd =" + ReflectionHelper.GetPrimitiveValue<string>(mLedger[17, 1]) + ",";
							mysql = mysql + " service_expense_cost_cd =" + ReflectionHelper.GetPrimitiveValue<string>(mLedger[18, 1]);

							mysql = mysql + ", credit_service_sales_cost_cd =" + ReflectionHelper.GetPrimitiveValue<string>(mLedger[19, 1]) + ",";
							mysql = mysql + " credit_service_cost_of_sales_cost_cd =" + ReflectionHelper.GetPrimitiveValue<string>(mLedger[20, 1]) + ",";
							mysql = mysql + " credit_service_expense_cost_cd =" + ReflectionHelper.GetPrimitiveValue<string>(mLedger[21, 1]);
						}

						if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("non_inventory_product")))
						{
							mysql = mysql + ", non_inventory_sales_cost_cd =" + ReflectionHelper.GetPrimitiveValue<string>(mLedger[16 + mNonInventoryIncrementValue, 1]) + ",";
							mysql = mysql + " non_inventory_cost_of_sales_cost_cd =" + ReflectionHelper.GetPrimitiveValue<string>(mLedger[17 + mNonInventoryIncrementValue, 1]) + ",";
							mysql = mysql + " non_inventory_expense_cost_cd =" + ReflectionHelper.GetPrimitiveValue<string>(mLedger[18 + mNonInventoryIncrementValue, 1]);

							mysql = mysql + ", credit_non_inventory_sales_cost_cd =" + ReflectionHelper.GetPrimitiveValue<string>(mLedger[19 + mNonInventoryIncrementValue, 1]) + ",";
							mysql = mysql + " credit_non_inventory_cost_of_sales_cost_cd =" + ReflectionHelper.GetPrimitiveValue<string>(mLedger[20 + mNonInventoryIncrementValue, 1]) + ",";
							mysql = mysql + " credit_non_inventory_expense_cost_cd =" + ReflectionHelper.GetPrimitiveValue<string>(mLedger[21 + mNonInventoryIncrementValue, 1]);
						}
					}


					if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("project_costing")))
					{
						mysql = mysql + " , Inventory_project_cd =" + ReflectionHelper.GetPrimitiveValue<string>(mLedger[0, 4]) + ",";
						mysql = mysql + " Adjustment_project_cd =" + ReflectionHelper.GetPrimitiveValue<string>(mLedger[1, 4]) + ",";
						mysql = mysql + " Cost_Of_Sale_project_cd =" + ReflectionHelper.GetPrimitiveValue<string>(mLedger[2, 4]) + ",";
						mysql = mysql + " PDis_project_cd =" + ReflectionHelper.GetPrimitiveValue<string>(mLedger[3, 4]) + ",";
						mysql = mysql + " Cash_Sale_project_cd =" + ReflectionHelper.GetPrimitiveValue<string>(mLedger[4, 4]) + ",";
						mysql = mysql + " Credit_Sale_project_cd =" + ReflectionHelper.GetPrimitiveValue<string>(mLedger[5, 4]) + ",";
						mysql = mysql + " Cash_SDis_project_cd =" + ReflectionHelper.GetPrimitiveValue<string>(mLedger[6, 4]) + ",";
						mysql = mysql + " Credit_SDis_project_cd =" + ReflectionHelper.GetPrimitiveValue<string>(mLedger[7, 4]) + ",";
						mysql = mysql + " PRet_project_cd =" + ReflectionHelper.GetPrimitiveValue<string>(mLedger[8, 4]) + ",";
						mysql = mysql + " PRet_Dis_project_cd =" + ReflectionHelper.GetPrimitiveValue<string>(mLedger[9, 4]) + ",";
						mysql = mysql + " Cash_SRet_project_cd =" + ReflectionHelper.GetPrimitiveValue<string>(mLedger[10, 4]) + ",";
						mysql = mysql + " Credit_SRet_project_cd =" + ReflectionHelper.GetPrimitiveValue<string>(mLedger[11, 4]) + ",";
						mysql = mysql + " Cash_SRet_Dis_project_cd =" + ReflectionHelper.GetPrimitiveValue<string>(mLedger[12, 4]) + ",";
						mysql = mysql + " Credit_SRet_Dis_project_cd =" + ReflectionHelper.GetPrimitiveValue<string>(mLedger[13, 4]) + ",";
						mysql = mysql + " Cash_project_cd =" + ReflectionHelper.GetPrimitiveValue<string>(mLedger[14, 4]) + ",";
						mysql = mysql + " suspense_project_cd =" + ReflectionHelper.GetPrimitiveValue<string>(mLedger[15, 4]);

						if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("service_product")))
						{
							mysql = mysql + ", service_sales_project_cd =" + ReflectionHelper.GetPrimitiveValue<string>(mLedger[16, 4]) + ",";
							mysql = mysql + " service_cost_of_sales_project_cd =" + ReflectionHelper.GetPrimitiveValue<string>(mLedger[17, 4]) + ",";
							mysql = mysql + " service_expense_project_cd =" + ReflectionHelper.GetPrimitiveValue<string>(mLedger[18, 4]);

							mysql = mysql + ", credit_service_sales_project_cd =" + ReflectionHelper.GetPrimitiveValue<string>(mLedger[19, 4]) + ",";
							mysql = mysql + " credit_service_cost_of_sales_project_cd =" + ReflectionHelper.GetPrimitiveValue<string>(mLedger[20, 4]) + ",";
							mysql = mysql + " credit_service_expense_project_cd =" + ReflectionHelper.GetPrimitiveValue<string>(mLedger[21, 4]);
						}

						if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("non_inventory_product")))
						{
							mysql = mysql + ", non_inventory_sales_project_cd =" + ReflectionHelper.GetPrimitiveValue<string>(mLedger[16 + mNonInventoryIncrementValue, 4]) + ",";
							mysql = mysql + " non_inventory_cost_of_sales_project_cd =" + ReflectionHelper.GetPrimitiveValue<string>(mLedger[17 + mNonInventoryIncrementValue, 4]) + ",";
							mysql = mysql + " non_inventory_expense_project_cd =" + ReflectionHelper.GetPrimitiveValue<string>(mLedger[18 + mNonInventoryIncrementValue, 4]);

							mysql = mysql + ", credit_snon_inventory_sales_project_cd =" + ReflectionHelper.GetPrimitiveValue<string>(mLedger[19 + mNonInventoryIncrementValue, 4]) + ",";
							mysql = mysql + " credit_snon_inventory_cost_of_sales_project_cd =" + ReflectionHelper.GetPrimitiveValue<string>(mLedger[20 + mNonInventoryIncrementValue, 4]) + ",";
							mysql = mysql + " credit_snon_inventory_expense_project_cd =" + ReflectionHelper.GetPrimitiveValue<string>(mLedger[21 + mNonInventoryIncrementValue, 4]);
						}
					}

				}

				mysql = mysql + " where locat_Cd =" + Conversion.Str(mSearchValue);
				SqlCommand TempCommand_2 = null;
				TempCommand_2 = SystemVariables.gConn.CreateCommand();
				TempCommand_2.CommandText = mysql;
				TempCommand_2.ExecuteNonQuery();
			}

			return true;

			eFoundError1:
			eFoundError2TryBlock:
			eFoundError5TryBlock:
			MessageBox.Show("Invalid Ledger Account", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
			tabMaster.CurrTab = 1;
			grdVoucherDetails.Col = grdLedgerCode;
			grdVoucherDetails.Bookmark = Cnt;
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069


			try
			{
				if (_eFoundError5Flag)
				{
					goto eFoundError5;
				}
				if (_eFoundError2Flag)
				{
					goto eFoundError2;
				}
				grdVoucherDetails.Focus();
				return false;

				eFoundError2:
				MessageBox.Show("Invalid Cost Center ", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
				tabMaster.CurrTab = 1;
				grdVoucherDetails.Bookmark = Cnt;
				grdVoucherDetails.Col = grdCCNo;
				grdVoucherDetails.Focus();
				return false;

				MessageBox.Show("Invalid Anlysis Code 1", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
				tabMaster.CurrTab = 1;
				grdVoucherDetails.Bookmark = Cnt;
				grdVoucherDetails.Col = grdAnlyCode1;
				grdVoucherDetails.Focus();
				return false;


				MessageBox.Show("Invalid Analysis Code 2", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
				tabMaster.CurrTab = 1;
				grdVoucherDetails.Bookmark = Cnt;
				grdVoucherDetails.Col = grdAnlyCode2;
				grdVoucherDetails.Focus();
				return false;

				eFoundError5:
				MessageBox.Show("Invalid Project Code", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
				tabMaster.CurrTab = 1;
				grdVoucherDetails.Bookmark = Cnt;
				grdVoucherDetails.Col = grdProjectNo;
				grdVoucherDetails.Focus();
				return false;

				eFoundError:
				int mReturnErrorType = 0;
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				mReturnErrorType = SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, Information.Err().Description, this.Name, "saveRecord", SystemConstants.msg10);
				if (mReturnErrorType == 1)
				{
					//mSearchValue = GetMasterCode("select Locat_cd from SM_Location where Locat_no=" & txtLocationNo.Text)
					//Call GetRecord(mSearchValue)
					result = false;
				}
				else if (mReturnErrorType == 2)
				{ 
					//Call AddRecord
					result = false;
				}
				else
				{
					result = false;
				}
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}

			return result;
		}


		public bool deleteRecord()
		{
			//Delete the Record
			bool result = false;
			try
			{
				object mReturnValue = null;
				string mysql = "";

				SystemVariables.gConn.BeginTransaction();

				mysql = "select protected from SM_Location where locat_cd=" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(mReturnValue))
				{
					//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
					if (((TriState) ReflectionHelper.GetPrimitiveValue<int>(mReturnValue)) == TriState.True)
					{
						MessageBox.Show(SystemConstants.msg12, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
						result = false;
						//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						SystemVariables.gConn.RollbackTrans();
						return result;
					}
					else
					{
						mysql = "delete from SM_Location where locat_cd=" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
						SqlCommand TempCommand = null;
						TempCommand = SystemVariables.gConn.CreateCommand();
						TempCommand.CommandText = mysql;
						TempCommand.ExecuteNonQuery();
						result = true;
					}
				}

				//'''Donot allow to delete or modify the record if the information exists in the ST_OFFLINE_DETAILS
				mysql = " select comp_id from ST_OFFLINE_DETAILS ";
				mysql = mysql + " where table_name = 'location' ";
				mysql = mysql + " and (upload_entry_id ='" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue).Trim() + "'";
				mysql = mysql + " or download_generated_entry_id ='" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue).Trim() + "')";
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(mReturnValue))
				{
					MessageBox.Show(SystemConstants.msg29, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					SystemVariables.gConn.RollbackTrans();
					return false;
				}

				//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.CommitTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				SystemVariables.gConn.CommitTrans();
			}
			catch (System.Exception excep)
			{
				int mReturnErrorType = 0;
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				mReturnErrorType = SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, excep.Message, this.Name, "deleteRecord", SystemConstants.msg10);
				if (mReturnErrorType == 1)
				{
					result = false;
				}
				else if (mReturnErrorType == 2)
				{ 
					AddRecord();
					result = false;
				}
				else
				{
					result = false;
				}
			}

			return result;
		}

		public void GetRecord(object SearchValue)
		{
			//This routine is called after getting the value from Find window or
			//refreshing the recordset during any error of updating or deleting
			try
			{

				string mysql = "";
				SqlDataReader localRec = null;

				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				//UPGRADE_WARNING: (2080) IsEmpty was upgraded to a comparison and has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2080
				if (Object.Equals(SearchValue, null) || Convert.IsDBNull(SearchValue) || ReflectionHelper.GetPrimitiveValue<string>(SearchValue) == "")
				{
					return;
				}

				mysql = " SELECT SM_Location.*  from SM_Location ";
				mysql = mysql + " where SM_Location.locat_cd=" + ReflectionHelper.GetPrimitiveValue<string>(SearchValue);

				SqlCommand sqlCommand = new SqlCommand(mysql, SystemVariables.gConn);
				localRec = sqlCommand.ExecuteReader();
				if (localRec.Read())
				{
					mSearchValue = localRec["locat_cd"];
					mTimeStamp = Convert.ToString(localRec["Time_Stamp"]);
					txtLocationNo.Text = Convert.ToString(localRec["Locat_No"]);
					txtLShortName.Text = Convert.ToString(localRec["L_short_Name"]);
					txtAShortName.Text = Convert.ToString(localRec["A_short_Name"]) + "";
					txtLLocationName.Text = Convert.ToString(localRec["L_Locat_Name"]);
					txtALocationName.Text = Convert.ToString(localRec["A_Locat_Name"]) + "";
					txtAdd1.Text = Convert.ToString(localRec["addr_1"]) + "";
					txtAdd2.Text = Convert.ToString(localRec["addr_2"]) + "";
					txtAdd3.Text = Convert.ToString(localRec["addr_3"]) + "";
					txtPhone.Text = Convert.ToString(localRec["phone"]) + "";
					txtContactPerson.Text = Convert.ToString(localRec["Contact_Person"]) + "";
					txtComment.Text = Convert.ToString(localRec["Comments"]) + "";


					//''commented by Moiz Hakimion : 04-jul-2007
					//''this was created for aqsa but later found tht its not required.
					if (!Convert.IsDBNull(localRec["Default_Sman_No"]))
					{
						if (Convert.ToDouble(localRec["Default_Sman_No"]) > 0)
						{
							txtDefaultSalesmanNo.Text = Convert.ToString(localRec["Default_Sman_No"]);
						}
						else
						{
							txtDefaultSalesmanNo.Text = "";
						}
					}
					else
					{
						txtDefaultSalesmanNo.Text = "";
					}

					if (txtDefaultLdgrNo.Visible)
					{
						txtDefaultLdgrNo.Text = Convert.ToString(localRec["last_ldgr_no"]) + "";
						if (Convert.ToBoolean(localRec["last_cash_type"]))
						{
							chkCashType.CheckState = CheckState.Checked;
						}
						else
						{
							chkCashType.CheckState = CheckState.Unchecked;
						}

						txtDefaultCashCode.Text = Convert.ToString(localRec["last_cash_no"]) + "";
					}
					else
					{
						txtDefaultLdgrNo.Text = "";
						chkCashType.CheckState = CheckState.Unchecked;
						txtDefaultCashCode.Text = "";
					}

					if (Convert.ToBoolean(localRec["check_negative_stock"]))
					{
						chkCheckNegativeStock.CheckState = CheckState.Checked;
					}
					else
					{
						chkCheckNegativeStock.CheckState = CheckState.Unchecked;
					}

					if (txtDataUploadPath.Visible)
					{
						txtDataUploadPath.Text = Convert.ToString(localRec["data_upload_path"]) + "";
					}
					else
					{
						txtDataUploadPath.Text = "";
					}

					grdVoucherDetails.Rebind(true);

					tabMaster.CurrTab = 0;
					mFirstGridFocus = false;
					//Change the form mode to edit
					mCurrentFormMode = SystemVariables.SystemFormModes.frmEditMode;
				}
				localRec.Close();
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, excep.Message, this.Name, "GetRecord");
			}
		}

		public void PrintReport()
		{
			SystemReports.GetSystemReport(52020014, 1);
			//Dim rsMasterReportInformation As New Recordset ' Recordset
			//Dim rsDetailReportInformation As New Recordset
			//Dim MyReportForm As New frmSysReportDesign
			//
			//MyReportForm.oReportProperties.CreateReportInformationTablesDefinition rsMasterReportInformation, rsDetailReportInformation
			//rsMasterReportInformation.Open
			//rsDetailReportInformation.Open
			//
			//Set MyReportForm.rsMasterRecordsetName = rsMasterReportInformation
			//Set MyReportForm.rsDetailsRecordsetName = rsDetailReportInformation
			//
			//MyReportForm.oReportProperties.ReportID = 8
			//MyReportForm.oReportProperties.CallerReportID(0, 3, rsMasterReportInformation, rsDetailReportInformation) = 10
			//MyReportForm.oReportProperties.SaveReportInformation MyReportForm.oReportProperties.ReportID, rsMasterReportInformation, rsDetailReportInformation
			//MyReportForm.Show
		}

		public void findRecord()
		{
			//Call the find window

			//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(2004000));
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(mTempSearchValue))
			{
				//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mSearchValue = ReflectionHelper.GetPrimitiveValue(((Array) mTempSearchValue).GetValue(0));
				GetRecord(mSearchValue);
			}
		}

		public void CloseForm()
		{
			this.Close();
		}

		public bool CheckDataValidity()
		{
			//Check validation during update and add of records
			if (!Information.IsNumeric(txtLocationNo.Text))
			{
				MessageBox.Show("Enter the Location No", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
				tabMaster.CurrTab = 0;
				txtLocationNo.Focus();
				return false;
			}

			if (SystemProcedure2.IsItEmpty(txtLShortName.Text, SystemVariables.DataType.StringType))
			{
				MessageBox.Show("Enter the short Name", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
				tabMaster.CurrTab = 0;
				txtLShortName.Focus();
				return false;
			}

			if (SystemProcedure2.IsItEmpty(txtLLocationName.Text, SystemVariables.DataType.StringType))
			{
				MessageBox.Show("Enter the Location Name", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
				tabMaster.CurrTab = 0;
				txtLLocationName.Focus();
				return false;
			}

			if (SystemProcedure2.IsItEmpty(txtALocationName.Text, SystemVariables.DataType.StringType))
			{
				MessageBox.Show("Enter the Location Name", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
				tabMaster.CurrTab = 0;
				txtALocationName.Focus();
				return false;
			}

			return true;
		}

		private void Form_Closed(Object eventSender, EventArgs eventArgs)
		{
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{

				SystemMenu.RemoveMeFromWindowList(Conversion.Str(this.Handle.ToInt32()));
				UserAccess = null;
				aLedger = null;
				rsLedgerList = null;
				rsAnlyCode = null;
				oThisFormToolBar = null;
				frmICSLocation.DefInstance = null;
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}


		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBGrid Event grdVoucherDetails.FetchCellStyle was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void grdVoucherDetails_FetchCellStyle(int Condition, int Split, object Bookmark, int Col, C1.Win.C1TrueDBGrid.Style CellStyle)
		{
			//If Col = grdCCNo Then
			//    If aLedger(Bookmark, grdApplyCostCenter) = True Then
			//        CellStyle.BackColor = grdVoucherDetails.Columns(grdCCNo).BackColor
			//        CellStyle.ForeColor = grdVoucherDetails.Columns(grdCCNo).ForeColor
			//        grdVoucherDetails.Columns(grdCCNo).AllowFocus = True
			//    Else
			//        CellStyle.BackColor = gDisableColumnBackColor
			//        CellStyle.ForeColor = gDisableColumnBackColor
			//        grdVoucherDetails.Columns(grdCCNo).AllowFocus = False
			//    End If
			//End If
		}

		private void grdVoucherDetails_RowColChange(object eventSender, C1.Win.C1TrueDBGrid.RowColChangeEventArgs eventArgs)
		{
			int LastRow = eventArgs.LastRow;
			int LastCol = eventArgs.LastCol;
			string mFilterClause = "";
			if (grdVoucherDetails.Col > 0 && mFirstGridFocus)
			{
				switch(grdVoucherDetails.Col)
				{
					case grdLedgerCode : case grdLedgerName : 
						//''''Change the filter on the listbox 
						 
						mFilterClause = FilterGroupCodeOnLedgerSql(ReflectionHelper.GetPrimitiveValue<string>(grdVoucherDetails.Columns[grdGroupCodeFilterOnLedger].Value)); 
						//UPGRADE_ISSUE: (2064) ADODB.FilterGroupEnum property FilterGroupEnum.adFilterNone was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064 
						rsLedgerList.Tables[0].DefaultView.RowFilter = UpgradeStubs.ADODB_FilterGroupEnum.getadFilterNone(); 
						rsLedgerList.Tables[0].DefaultView.RowFilter = mFilterClause; 
						//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbCommon.DataSource was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064 
						cmbCommon.setDataSource((msdatasrc.DataSource) rsLedgerList); 
						break;
					case grdCCNo : case grdCCName : 
						//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbCommon.DataSource was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064 
						cmbCommon.setDataSource((msdatasrc.DataSource) rsCostList); 
						break;
					case grdProjectNo : case grdProjectName : 
						//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbCommon.DataSource was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064 
						cmbCommon.setDataSource((msdatasrc.DataSource) rsProjectList); 
						break;
					case grdAnlyCode1 : case grdAnlyCode2 : 
						//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbCommon.DataSource was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064 
						cmbCommon.setDataSource((msdatasrc.DataSource) rsAnlyCode); 
						break;
				}
			}



			//If grdVoucherDetails.Row <> LastRow Then
			//    If grdVoucherDetails.AddNewMode = dbgNoAddNew Then
			//        If Val(grdVoucherDetails.Columns(grdApplyCostCenter).Value) = True Then
			//            grdVoucherDetails.Columns(grdCCNo).AllowFocus = True
			//        Else
			//            grdVoucherDetails.Columns(grdCCNo).AllowFocus = False
			//        End If
			//    ElseIf grdVoucherDetails.AddNewMode = dbgAddNewCurrent Then
			//    Else                    'if grdVoucherDetails.AddNewMode = dbgAddNewPending
			//        If Val(grdVoucherDetails.Columns(grdApplyCostCenter).Value) = True Then
			//            grdVoucherDetails.Columns(grdCCNo).AllowFocus = True
			//        Else
			//            grdVoucherDetails.Columns(grdCCNo).AllowFocus = False
			//        End If
			//    End If
			//Else
			//    If mFirstGridFocus = True And aLedger.Count(1) > 0 And IsNull(LastRow) = True Then
			//        If Val(grdVoucherDetails.Columns(grdApplyCostCenter).Value) = True Then
			//            grdVoucherDetails.Columns(grdCCNo).AllowFocus = True
			//        Else
			//            grdVoucherDetails.Columns(grdCCNo).AllowFocus = False
			//        End If
			//    End If
			//End If
		}

		private void tabMaster_Switch(Object eventSender, AxC1SizerLib._C1TabEvents_SwitchEvent eventArgs)
		{
			string mysql = "";
			DataSet tempRec = null;
			int Cnt = 0;

			int i = 0;
			if (eventArgs.newTab == 1)
			{
				if (!mFirstGridFocus)
				{
					mFirstGridFocus = true;

					GenerateRecordSet();

					mysql = " select ";
					mysql = mysql + " Ledger_1.Ldgr_No AS Expr1";
					mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? " Ledger_1.L_Ldgr_Name " : "Ledger_1.a_ldgr_Name") + " AS Expr2 ";

					mysql = mysql + " , Ledger_2.Ldgr_No AS Expr3 ";
					mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? " Ledger_2.L_Ldgr_Name " : "Ledger_2.a_ldgr_Name") + " AS Expr4 ";
					//mySql = mySql & " , Ledger_2.apply_cost_center AS adjustment_apply_cost "

					mysql = mysql + " , Ledger_3.Ldgr_No AS Expr5";
					mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? " Ledger_3.L_Ldgr_Name " : "Ledger_3.a_ldgr_Name") + " AS Expr6 ";
					//mySql = mySql & " , Ledger_3.apply_cost_center AS cost_of_sale_apply_cost "

					mysql = mysql + " , Ledger_4.Ldgr_No AS Expr7";
					mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? " Ledger_4.L_Ldgr_Name " : "Ledger_4.a_ldgr_Name") + " AS Expr8 ";
					//mySql = mySql & " , Ledger_4.apply_cost_center AS pdis_apply_cost "

					mysql = mysql + " , Ledger_5.Ldgr_No AS Expr9 ";
					mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? " Ledger_5.L_Ldgr_Name " : "Ledger_5.a_ldgr_Name") + " AS Expr10 ";
					//mySql = mySql & " , Ledger_5.apply_cost_center AS cash_sale_apply_cost "

					mysql = mysql + " , Ledger_6.Ldgr_No AS Expr11";
					mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? " Ledger_6.L_Ldgr_Name " : "Ledger_6.a_ldgr_Name") + " AS Expr12 ";
					//mySql = mySql & " , Ledger_6.apply_cost_center AS credit_sale_apply_cost "

					mysql = mysql + " , Ledger_7.Ldgr_No AS Expr13";
					mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? " Ledger_7.L_Ldgr_Name " : "Ledger_7.a_ldgr_Name") + " AS Expr14 ";
					//mySql = mySql & " , Ledger_7.apply_cost_center AS cash_sdis_apply_cost "

					mysql = mysql + " , Ledger_8.Ldgr_No AS Expr15";
					mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? " Ledger_8.L_Ldgr_Name " : "Ledger_8.a_ldgr_Name") + " AS Expr16 ";
					//mySql = mySql & " , Ledger_8.apply_cost_center AS credit_sdis_apply_cost "

					mysql = mysql + " , Ledger_9.Ldgr_No AS Expr17";
					mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? " Ledger_9.L_Ldgr_Name " : "Ledger_9.a_ldgr_Name") + " AS Expr18 ";
					//mySql = mySql & " , Ledger_9.apply_cost_center AS pret_apply_cost "

					mysql = mysql + " , Ledger_10.Ldgr_No AS Expr19";
					mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? " Ledger_10.L_Ldgr_Name " : "Ledger_10.a_ldgr_Name") + " AS Expr20 ";
					//mySql = mySql & " , Ledger_10.apply_cost_center AS pret_dis_apply_cost "

					mysql = mysql + " , Ledger_11.Ldgr_No AS Expr21";
					mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? " Ledger_11.L_Ldgr_Name " : "Ledger_11.a_ldgr_Name") + " AS Expr22 ";
					//mySql = mySql & " , Ledger_11.apply_cost_center AS cash_sret_apply_cost "

					mysql = mysql + " , Ledger_12.Ldgr_No AS Expr23";
					mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? " Ledger_12.L_Ldgr_Name " : "Ledger_12.a_ldgr_Name") + " AS Expr24 ";
					//mySql = mySql & " , Ledger_12.apply_cost_center AS credit_sret_apply_cost "

					mysql = mysql + " , Ledger_13.Ldgr_No AS Expr25";
					mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? " Ledger_13.L_Ldgr_Name " : "Ledger_13.a_ldgr_Name") + " AS Expr26 ";
					//mySql = mySql & " , Ledger_13.apply_cost_center AS cash_sret_dis_apply_cost "

					mysql = mysql + " , Ledger_14.Ldgr_No AS Expr27";
					mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? " Ledger_14.L_Ldgr_Name " : "Ledger_14.a_ldgr_Name") + " AS Expr28 ";
					//mySql = mySql & " , Ledger_14.apply_cost_center AS credit_sret_dis_apply_cost "

					mysql = mysql + " , Ledger_15.Ldgr_No AS Expr29";
					mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? " Ledger_15.L_Ldgr_Name " : "Ledger_15.a_ldgr_Name") + " AS Expr30 ";
					//mySql = mySql & " , Ledger_15.apply_cost_center AS cash_apply_cost "

					mysql = mysql + " , Ledger_16.Ldgr_No AS Expr31 ";
					mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? " Ledger_16.L_Ldgr_Name " : "Ledger_16.a_ldgr_Name") + " AS Expr32 ";
					//mySql = mySql & " , Ledger_16.apply_cost_center AS suspense_apply_cost "

					if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("service_product")))
					{
						mysql = mysql + " , Ledger_17.Ldgr_No AS Expr33 ";
						mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? " Ledger_17.L_Ldgr_Name " : "Ledger_17.a_ldgr_Name") + " AS Expr34 ";
						//mySql = mySql & " , Ledger_17.apply_cost_center AS service_sales_apply_cost "

						mysql = mysql + " , Ledger_18.Ldgr_No AS Expr35 ";
						mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? " Ledger_18.L_Ldgr_Name " : "Ledger_18.a_ldgr_Name") + " AS Expr36 ";
						//mySql = mySql & " , Ledger_18.apply_cost_center AS service_cost_of_sales_apply_cost "

						mysql = mysql + " , Ledger_19.Ldgr_No AS Expr37 ";
						mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? " Ledger_19.L_Ldgr_Name " : "Ledger_19.a_ldgr_Name") + " AS Expr38 ";
						//mySql = mySql & " , Ledger_19.apply_cost_center AS service_expenses_apply_cost "

						mysql = mysql + " , Ledger_20.Ldgr_No AS Expr39 ";
						mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? " Ledger_20.L_Ldgr_Name " : "Ledger_20.a_ldgr_Name") + " AS Expr40 ";

						mysql = mysql + " , Ledger_21.Ldgr_No AS Expr41 ";
						mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? " Ledger_21.L_Ldgr_Name " : "Ledger_21.a_ldgr_Name") + " AS Expr42 ";

						mysql = mysql + " , Ledger_22.Ldgr_No AS Expr43 ";
						mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? " Ledger_22.L_Ldgr_Name " : "Ledger_22.a_ldgr_Name") + " AS Expr44 ";

					}

					if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("non_inventory_product")))
					{
						mysql = mysql + " , Ledger_23.Ldgr_No AS Expr45 ";
						mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? " Ledger_23.L_Ldgr_Name " : "Ledger_23.a_ldgr_Name") + " AS Expr46 ";
						//mySql = mySql & " , Ledger_20.apply_cost_center AS non_inventory_sales_apply_cost "

						mysql = mysql + " , Ledger_24.Ldgr_No AS Expr47 ";
						mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? " Ledger_24.L_Ldgr_Name " : "Ledger_24.a_ldgr_Name") + " AS Expr48 ";
						//mySql = mySql & " , Ledger_21.apply_cost_center AS non_inventory_cost_of_sales_apply_cost "

						mysql = mysql + " , Ledger_25.Ldgr_No AS Expr49 ";
						mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? " Ledger_26.L_Ldgr_Name " : "Ledger_25.a_ldgr_Name") + " AS Expr50 ";
						//mySql = mySql & " , Ledger_22.apply_cost_center AS non_inventory_expenses_apply_cost "

						mysql = mysql + " , Ledger_26.Ldgr_No AS Expr51 ";
						mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? " Ledger_26.L_Ldgr_Name " : "Ledger_26.a_ldgr_Name") + " AS Expr52 ";

						mysql = mysql + " , Ledger_27.Ldgr_No AS Expr53 ";
						mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? " Ledger_27.L_Ldgr_Name " : "Ledger_27.a_ldgr_Name") + " AS Expr54 ";

						mysql = mysql + " , Ledger_28.Ldgr_No AS Expr55 ";
						mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? " Ledger_28.L_Ldgr_Name " : "Ledger_28.a_ldgr_Name") + " AS Expr56 ";

					}

					mysql = mysql + " , cc_1.cost_No AS Expr101 ";
					mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? " cc_1.L_cost_Name " : "cc_1.a_cost_Name") + " AS Expr102 ";
					mysql = mysql + " , cc_2.cost_No AS Expr103 ";
					mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? " cc_2.L_cost_Name " : "cc_2.a_cost_Name") + " AS Expr104 ";
					mysql = mysql + " , cc_3.cost_No AS Expr105 ";
					mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? " cc_3.L_cost_Name " : "cc_3.a_cost_Name") + " AS Expr106 ";
					mysql = mysql + " , cc_4.cost_No AS Expr107 ";
					mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? " cc_4.L_cost_Name " : "cc_4.a_cost_Name") + " AS Expr108 ";
					mysql = mysql + " , cc_5.cost_No AS Expr109 ";
					mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? " cc_5.L_cost_Name " : "cc_5.a_cost_Name") + " AS Expr110 ";
					mysql = mysql + " , cc_6.cost_No AS Expr111 ";
					mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? " cc_6.L_cost_Name " : "cc_6.a_cost_Name") + " AS Expr112 ";
					mysql = mysql + " , cc_7.cost_No AS Expr113 ";
					mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? " cc_7.L_cost_Name " : "cc_7.a_cost_Name") + " AS Expr114 ";
					mysql = mysql + " , cc_8.cost_No AS Expr115 ";
					mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? " cc_8.L_cost_Name " : "cc_8.a_cost_Name") + " AS Expr116 ";
					mysql = mysql + " , cc_9.cost_No AS Expr117 ";
					mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? " cc_9.L_cost_Name " : "cc_9.a_cost_Name") + " AS Expr118 ";
					mysql = mysql + " , cc_10.cost_No AS Expr119 ";
					mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? " cc_10.L_cost_Name " : "cc_10.a_cost_Name") + " AS Expr120 ";
					mysql = mysql + " , cc_11.cost_No AS Expr121 ";
					mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? " cc_11.L_cost_Name " : "cc_11.a_cost_Name") + " AS Expr122 ";
					mysql = mysql + " , cc_12.cost_No AS Expr123 ";
					mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? " cc_12.L_cost_Name " : "cc_12.a_cost_Name") + " AS Expr124 ";
					mysql = mysql + " , cc_13.cost_No AS Expr125 ";
					mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? " cc_13.L_cost_Name " : "cc_13.a_cost_Name") + " AS Expr126 ";
					mysql = mysql + " , cc_14.cost_No AS Expr127 ";
					mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? " cc_14.L_cost_Name " : "cc_14.a_cost_Name") + " AS Expr128 ";
					mysql = mysql + " , cc_15.cost_No AS Expr129 ";
					mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? " cc_15.L_cost_Name " : "cc_15.a_cost_Name") + " AS Expr130 ";
					mysql = mysql + " , cc_16.cost_No AS Expr131 ";
					mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? " cc_16.L_cost_Name " : "cc_16.a_cost_Name") + " AS Expr132 ";

					if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("service_product")))
					{
						mysql = mysql + " , cc_17.cost_No AS Expr133 ";
						mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? " cc_17.L_cost_Name " : "cc_17.a_cost_Name") + " AS Expr134 ";
						mysql = mysql + " , cc_18.cost_No AS Expr135 ";
						mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? " cc_18.L_cost_Name " : "cc_18.a_cost_Name") + " AS Expr136 ";
						mysql = mysql + " , cc_19.cost_No AS Expr137 ";
						mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? " cc_19.L_cost_Name " : "cc_19.a_cost_Name") + " AS Expr138 ";

						mysql = mysql + " , cc_20.cost_No AS Expr139 ";
						mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? " cc_20.L_cost_Name " : "cc_20.a_cost_Name") + " AS Expr140 ";
						mysql = mysql + " , cc_21.cost_No AS Expr141 ";
						mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? " cc_21.L_cost_Name " : "cc_21.a_cost_Name") + " AS Expr142 ";
						mysql = mysql + " , cc_22.cost_No AS Expr143 ";
						mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? " cc_22.L_cost_Name " : "cc_22.a_cost_Name") + " AS Expr144 ";
					}

					if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("non_inventory_product")))
					{
						mysql = mysql + " , cc_23.cost_No AS Expr145 ";
						mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? " cc_23.L_cost_Name " : "cc_23.a_cost_Name") + " AS Expr146 ";

						mysql = mysql + " , cc_24.cost_No AS Expr147 ";
						mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? " cc_24.L_cost_Name " : "cc_24.a_cost_Name") + " AS Expr148 ";

						mysql = mysql + " , cc_25.cost_No AS Expr149 ";
						mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? " cc_25.L_cost_Name " : "cc_25.a_cost_Name") + " AS Expr150 ";

						mysql = mysql + " , cc_26.cost_No AS Expr151 ";
						mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? " cc_26.L_cost_Name " : "cc_26.a_cost_Name") + " AS Expr152 ";

						mysql = mysql + " , cc_27.cost_No AS Expr153 ";
						mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? " cc_27.L_cost_Name " : "cc_27.a_cost_Name") + " AS Expr154 ";

						mysql = mysql + " , cc_28.cost_No AS Expr155 ";
						mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? " cc_28.L_cost_Name " : "cc_28.a_cost_Name") + " AS Expr156 ";

					}
					//'''''''''''''''''''''''''''''''''''''''

					mysql = mysql + " , pp_1.project_no AS Expr301 ";
					mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? " pp_1.L_project_Name " : "pp_1.a_project_Name") + " AS Expr302 ";
					mysql = mysql + " , pp_2.project_no AS Expr303 ";
					mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? " pp_2.L_project_Name " : "pp_2.a_project_Name") + " AS Expr304 ";
					mysql = mysql + " , pp_3.project_no AS Expr305 ";
					mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? " pp_3.L_project_Name " : "pp_3.a_project_Name") + " AS Expr306 ";
					mysql = mysql + " , pp_4.project_no AS Expr307 ";
					mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? " pp_4.L_project_Name " : "pp_4.a_project_Name") + " AS Expr308 ";
					mysql = mysql + " , pp_5.project_no AS Expr309 ";
					mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? " pp_5.L_project_Name " : "pp_5.a_project_Name") + " AS Expr310 ";
					mysql = mysql + " , pp_6.project_no AS Expr311 ";
					mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? " pp_6.L_project_Name " : "pp_6.a_project_Name") + " AS Expr312 ";
					mysql = mysql + " , pp_7.project_no AS Expr313 ";
					mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? " pp_7.L_project_Name " : "pp_7.a_project_Name") + " AS Expr314 ";
					mysql = mysql + " , pp_8.project_no AS Expr315 ";
					mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? " pp_8.L_project_Name " : "pp_8.a_project_Name") + " AS Expr316 ";
					mysql = mysql + " , pp_9.project_no AS Expr317 ";
					mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? " pp_9.L_project_Name " : "pp_9.a_project_Name") + " AS Expr318 ";
					mysql = mysql + " , pp_10.project_no AS Expr319 ";
					mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? " pp_10.L_project_Name " : "pp_10.a_project_Name") + " AS Expr320 ";
					mysql = mysql + " , pp_11.project_no AS Expr321 ";
					mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? " pp_11.L_project_Name " : "pp_11.a_project_Name") + " AS Expr322 ";
					mysql = mysql + " , pp_12.project_no AS Expr323 ";
					mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? " pp_12.L_project_Name " : "pp_12.a_project_Name") + " AS Expr324 ";
					mysql = mysql + " , pp_13.project_no AS Expr325 ";
					mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? " pp_13.L_project_Name " : "pp_13.a_project_Name") + " AS Expr326 ";
					mysql = mysql + " , pp_14.project_no AS Expr327 ";
					mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? " pp_14.L_project_Name " : "pp_14.a_project_Name") + " AS Expr328 ";
					mysql = mysql + " , pp_15.project_no AS Expr329 ";
					mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? " pp_15.L_project_Name " : "pp_15.a_project_Name") + " AS Expr330 ";
					mysql = mysql + " , pp_16.project_no AS Expr331 ";
					mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? " pp_16.L_project_Name " : "pp_16.a_project_Name") + " AS Expr332 ";

					if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("service_product")))
					{
						mysql = mysql + " , pp_17.project_no AS Expr333 ";
						mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? " pp_17.L_project_Name " : "pp_17.a_project_Name") + " AS Expr334 ";
						mysql = mysql + " , pp_18.project_no AS Expr335 ";
						mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? " pp_18.L_project_Name " : "pp_18.a_project_Name") + " AS Expr336 ";
						mysql = mysql + " , pp_19.project_no AS Expr337 ";
						mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? " pp_19.L_project_Name " : "pp_19.a_project_Name") + " AS Expr338 ";

						mysql = mysql + " , pp_20.project_no AS Expr339 ";
						mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? " pp_20.L_project_Name " : "pp_20.a_project_Name") + " AS Expr340 ";
						mysql = mysql + " , pp_21.project_no AS Expr341 ";
						mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? " pp_21.L_project_Name " : "pp_21.a_project_Name") + " AS Expr342 ";
						mysql = mysql + " , pp_22.project_no AS Expr343 ";
						mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? " pp_22.L_project_Name " : "pp_22.a_project_Name") + " AS Expr344 ";
					}

					if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("non_inventory_product")))
					{
						mysql = mysql + " , pp_23.project_no AS Expr345 ";
						mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? " pp_23.L_project_Name " : "pp_23.a_project_Name") + " AS Expr346 ";

						mysql = mysql + " , pp_24.project_no AS Expr347 ";
						mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? " pp_24.L_project_Name " : "pp_24.a_project_Name") + " AS Expr348 ";

						mysql = mysql + " , pp_25.project_no AS Expr349 ";
						mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? " pp_25.L_project_Name " : "pp_25.a_project_Name") + " AS Expr350 ";

						mysql = mysql + " , pp_26.project_no AS Expr351 ";
						mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? " pp_26.L_project_Name " : "pp_26.a_project_Name") + " AS Expr352 ";

						mysql = mysql + " , pp_27.project_no AS Expr353 ";
						mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? " pp_27.L_project_Name " : "pp_27.a_project_Name") + " AS Expr354 ";

						mysql = mysql + " , pp_28.project_no AS Expr355 ";
						mysql = mysql + " , " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? " pp_28.L_project_Name " : "pp_28.a_project_Name") + " AS Expr356 ";
					}

					mysql = mysql + " , SM_Location.* ";
					mysql = mysql + " from SM_Location ";
					mysql = mysql + " INNER JOIN gl_ledger Ledger_1 ON SM_Location.Inventory_Cd = Ledger_1.Ldgr_Cd";
					mysql = mysql + " INNER JOIN gl_ledger ledger_2 ON SM_Location.adjustment_Cd = ledger_2.Ldgr_Cd";
					mysql = mysql + " INNER JOIN gl_ledger ledger_3 ON SM_Location.cost_of_sale_Cd = ledger_3.Ldgr_Cd";
					mysql = mysql + " INNER JOIN gl_ledger ledger_4 ON SM_Location.pDis_cd = ledger_4.Ldgr_Cd";
					mysql = mysql + " INNER JOIN gl_ledger ledger_5 ON SM_Location.cash_sale_Cd = ledger_5.Ldgr_Cd";
					mysql = mysql + " INNER JOIN gl_ledger ledger_6 ON SM_Location.credit_sale_Cd = ledger_6.Ldgr_Cd";
					mysql = mysql + " INNER JOIN gl_ledger ledger_7 ON SM_Location.cash_sdis_cd = ledger_7.Ldgr_Cd";
					mysql = mysql + " INNER JOIN gl_ledger ledger_8 ON SM_Location.credit_sdis_Cd = ledger_8.Ldgr_Cd";
					mysql = mysql + " INNER JOIN gl_ledger ledger_9 ON SM_Location.pRet_Cd = ledger_9.Ldgr_Cd";
					mysql = mysql + " INNER JOIN gl_ledger ledger_10 ON SM_Location.pRet_dis_Cd = ledger_10.Ldgr_Cd";
					mysql = mysql + " INNER JOIN gl_ledger ledger_11 ON SM_Location.cash_sRet_cd = ledger_11.Ldgr_Cd";
					mysql = mysql + " INNER JOIN gl_ledger ledger_12 ON SM_Location.credit_sRet_cd = ledger_12.Ldgr_Cd";
					mysql = mysql + " INNER JOIN gl_ledger ledger_13 ON SM_Location.cash_sRet_dis_cd = ledger_13.Ldgr_Cd";
					mysql = mysql + " INNER JOIN gl_ledger ledger_14 ON SM_Location.credit_sRet_dis_cd = ledger_14.Ldgr_Cd";
					mysql = mysql + " INNER JOIN gl_ledger ledger_15 ON SM_Location.Cash_Cd = ledger_15.Ldgr_Cd";
					mysql = mysql + " INNER JOIN gl_ledger ledger_16 ON SM_Location.suspense_Cd = ledger_16.Ldgr_Cd";

					if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("service_product")))
					{
						mysql = mysql + " left JOIN gl_ledger ledger_17 ON SM_Location.service_sales_cd = ledger_17.Ldgr_Cd";
						mysql = mysql + " left JOIN gl_ledger ledger_18 ON SM_Location.service_cost_of_sales_cd = ledger_18.Ldgr_Cd";
						mysql = mysql + " left JOIN gl_ledger ledger_19 ON SM_Location.service_expense_cd = ledger_19.Ldgr_Cd";

						mysql = mysql + " left JOIN gl_ledger ledger_20 ON SM_Location.Credit_service_sales_cd = ledger_20.Ldgr_Cd";
						mysql = mysql + " left JOIN gl_ledger ledger_21 ON SM_Location.Credit_service_cost_of_sales_cd = ledger_21.Ldgr_Cd";
						mysql = mysql + " left JOIN gl_ledger ledger_22 ON SM_Location.Credit_service_expense_cd = ledger_22.Ldgr_Cd";

					}

					if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("non_inventory_product")))
					{
						mysql = mysql + " left JOIN gl_ledger ledger_23 ON SM_Location.non_inventory_sales_cd = ledger_23.Ldgr_Cd";
						mysql = mysql + " left JOIN gl_ledger ledger_24 ON SM_Location.non_inventory_cost_of_sales_cd = ledger_24.Ldgr_Cd";
						mysql = mysql + " left JOIN gl_ledger ledger_25 ON SM_Location.non_inventory_expense_cd = ledger_25.Ldgr_Cd";

						mysql = mysql + " left JOIN gl_ledger ledger_26 ON SM_Location.Credit_non_inventory_sales_cd = ledger_26.Ldgr_Cd";
						mysql = mysql + " left JOIN gl_ledger ledger_27 ON SM_Location.Credit_non_inventory_cost_of_sales_cd = ledger_27.Ldgr_Cd";
						mysql = mysql + " left JOIN gl_ledger ledger_28 ON SM_Location.Credit_non_inventory_expense_cd = ledger_28.Ldgr_Cd";
					}

					mysql = mysql + " left JOIN gl_cost_centers cc_1 ON SM_Location.Inventory_cost_Cd = cc_1.cost_Cd ";
					mysql = mysql + " left JOIN gl_cost_centers cc_2 ON SM_Location.adjustment_cost_Cd = cc_2.cost_Cd ";
					mysql = mysql + " left JOIN gl_cost_centers cc_3 ON SM_Location.cost_of_sale_cost_Cd = cc_3.cost_Cd ";
					mysql = mysql + " left JOIN gl_cost_centers cc_4 ON SM_Location.pDis_cost_cd = cc_4.cost_Cd";
					mysql = mysql + " left JOIN gl_cost_centers cc_5 ON SM_Location.cash_sale_cost_Cd = cc_5.cost_Cd";
					mysql = mysql + " left JOIN gl_cost_centers cc_6 ON SM_Location.credit_sale_cost_Cd = cc_6.cost_Cd ";
					mysql = mysql + " left JOIN gl_cost_centers cc_7 ON SM_Location.cash_sdis_cost_cd = cc_7.cost_Cd";
					mysql = mysql + " left JOIN gl_cost_centers cc_8 ON SM_Location.credit_sdis_cost_Cd = cc_8.cost_Cd ";
					mysql = mysql + " left JOIN gl_cost_centers cc_9 ON SM_Location.pRet_cost_Cd = cc_9.cost_Cd ";
					mysql = mysql + " left JOIN gl_cost_centers cc_10 ON SM_Location.pRet_dis_cost_Cd = cc_10.cost_Cd ";
					mysql = mysql + " left JOIN gl_cost_centers cc_11 ON SM_Location.cash_sRet_cost_cd = cc_11.cost_Cd ";
					mysql = mysql + " left JOIN gl_cost_centers cc_12 ON SM_Location.credit_sRet_cost_cd = cc_12.cost_Cd ";
					mysql = mysql + " left JOIN gl_cost_centers cc_13 ON SM_Location.cash_sRet_dis_cost_cd = cc_13.cost_Cd ";
					mysql = mysql + " left JOIN gl_cost_centers cc_14 ON SM_Location.credit_sRet_dis_cost_cd = cc_14.cost_Cd ";
					mysql = mysql + " left JOIN gl_cost_centers cc_15 ON SM_Location.Cash_cost_Cd = cc_15.cost_Cd ";
					mysql = mysql + " left JOIN gl_cost_centers cc_16 ON SM_Location.suspense_cost_Cd = cc_16.cost_Cd ";

					if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("service_product")))
					{
						mysql = mysql + " left JOIN gl_cost_centers cc_17 ON SM_Location.service_sales_cost_cd = cc_17.cost_Cd ";
						mysql = mysql + " left JOIN gl_cost_centers cc_18 ON SM_Location.service_cost_of_sales_cost_cd = cc_18.cost_Cd ";
						mysql = mysql + " left JOIN gl_cost_centers cc_19 ON SM_Location.service_expense_cost_cd = cc_19.cost_Cd ";

						mysql = mysql + " left JOIN gl_cost_centers cc_20 ON SM_Location.Credit_service_sales_cost_cd = cc_20.cost_Cd ";
						mysql = mysql + " left JOIN gl_cost_centers cc_21 ON SM_Location.Credit_service_cost_of_sales_cost_cd = cc_21.cost_Cd ";
						mysql = mysql + " left JOIN gl_cost_centers cc_22 ON SM_Location.Credit_service_expense_cost_cd = cc_22.cost_Cd ";
					}

					if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("non_inventory_product")))
					{
						mysql = mysql + " left JOIN gl_cost_centers cc_23 ON SM_Location.non_inventory_sales_cost_cd = cc_23.cost_Cd ";
						mysql = mysql + " left JOIN gl_cost_centers cc_24 ON SM_Location.non_inventory_cost_of_sales_cost_cd = cc_24.cost_Cd ";
						mysql = mysql + " left JOIN gl_cost_centers cc_25 ON SM_Location.non_inventory_expense_cost_cd = cc_25.cost_Cd ";

						mysql = mysql + " left JOIN gl_cost_centers cc_26 ON SM_Location.Credit_non_inventory_sales_cost_cd = cc_26.cost_Cd ";
						mysql = mysql + " left JOIN gl_cost_centers cc_27 ON SM_Location.Credit_non_inventory_cost_of_sales_cost_cd = cc_27.cost_Cd ";
						mysql = mysql + " left JOIN gl_cost_centers cc_28 ON SM_Location.Credit_non_inventory_expense_cost_cd = cc_28.cost_Cd ";
					}

					mysql = mysql + " left JOIN PROJ_Projects pp_1 ON SM_Location.Inventory_project_cd = pp_1.project_cd ";
					mysql = mysql + " left JOIN PROJ_Projects pp_2 ON SM_Location.adjustment_project_cd = pp_2.project_cd ";
					mysql = mysql + " left JOIN PROJ_Projects pp_3 ON SM_Location.cost_of_sale_project_cd = pp_3.project_cd ";
					mysql = mysql + " left JOIN PROJ_Projects pp_4 ON SM_Location.pDis_project_cd = pp_4.project_cd";
					mysql = mysql + " left JOIN PROJ_Projects pp_5 ON SM_Location.cash_sale_project_cd = pp_5.project_cd";
					mysql = mysql + " left JOIN PROJ_Projects pp_6 ON SM_Location.credit_sale_project_cd = pp_6.project_cd ";
					mysql = mysql + " left JOIN PROJ_Projects pp_7 ON SM_Location.cash_sdis_project_cd = pp_7.project_cd";
					mysql = mysql + " left JOIN PROJ_Projects pp_8 ON SM_Location.credit_sdis_project_cd = pp_8.project_cd ";
					mysql = mysql + " left JOIN PROJ_Projects pp_9 ON SM_Location.pRet_project_cd = pp_9.project_cd ";
					mysql = mysql + " left JOIN PROJ_Projects pp_10 ON SM_Location.pRet_dis_project_cd = pp_10.project_cd ";
					mysql = mysql + " left JOIN PROJ_Projects pp_11 ON SM_Location.cash_sRet_project_cd = pp_11.project_cd ";
					mysql = mysql + " left JOIN PROJ_Projects pp_12 ON SM_Location.credit_sRet_project_cd = pp_12.project_cd ";
					mysql = mysql + " left JOIN PROJ_Projects pp_13 ON SM_Location.cash_sRet_dis_project_cd = pp_13.project_cd ";
					mysql = mysql + " left JOIN PROJ_Projects pp_14 ON SM_Location.credit_sRet_dis_project_cd = pp_14.project_cd ";
					mysql = mysql + " left JOIN PROJ_Projects pp_15 ON SM_Location.Cash_project_cd = pp_15.project_cd ";
					mysql = mysql + " left JOIN PROJ_Projects pp_16 ON SM_Location.suspense_project_cd = pp_16.project_cd ";

					if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("service_product")))
					{
						mysql = mysql + " left JOIN PROJ_Projects pp_17 ON SM_Location.service_sales_project_cd = pp_17.project_cd ";
						mysql = mysql + " left JOIN PROJ_Projects pp_18 ON SM_Location.service_cost_of_sales_project_cd = pp_18.project_cd ";
						mysql = mysql + " left JOIN PROJ_Projects pp_19 ON SM_Location.service_expense_project_cd = pp_19.project_cd ";

						mysql = mysql + " left JOIN PROJ_Projects pp_20 ON SM_Location.Credit_service_sales_project_cd = pp_20.project_cd ";
						mysql = mysql + " left JOIN PROJ_Projects pp_21 ON SM_Location.Credit_service_cost_of_sales_project_cd = pp_21.project_cd ";
						mysql = mysql + " left JOIN PROJ_Projects pp_22 ON SM_Location.Credit_service_expense_project_cd = pp_22.project_cd ";
					}

					if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("non_inventory_product")))
					{
						mysql = mysql + " left JOIN PROJ_Projects pp_23 ON SM_Location.non_inventory_sales_project_cd = pp_23.project_cd ";
						mysql = mysql + " left JOIN PROJ_Projects pp_24 ON SM_Location.non_inventory_cost_of_sales_project_cd = pp_24.project_cd ";
						mysql = mysql + " left JOIN PROJ_Projects pp_25 ON SM_Location.non_inventory_expense_project_cd = pp_25.project_cd ";

						mysql = mysql + " left JOIN PROJ_Projects pp_26 ON SM_Location.Credit_non_inventory_sales_project_cd = pp_26.project_cd ";
						mysql = mysql + " left JOIN PROJ_Projects pp_27 ON SM_Location.Credit_non_inventory_cost_of_sales_project_cd = pp_27.project_cd ";
						mysql = mysql + " left JOIN PROJ_Projects pp_28 ON SM_Location.Credit_non_inventory_expense_project_cd = pp_28.project_cd ";
					}

					if (CurrentFormMode == SystemVariables.SystemFormModes.frmAddMode)
					{
						mysql = mysql + " where SM_Location.locat_cd=1";
					}
					else
					{
						mysql = mysql + " where SM_Location.locat_cd=" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
					}
					tempRec = new DataSet();
					SqlDataAdapter adap = new SqlDataAdapter(mysql, SystemVariables.gConn);
					tempRec.Tables.Clear();
					adap.Fill(tempRec);
					if (tempRec.Tables[0].Rows.Count != 0)
					{
						//''Inventory Cost
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr1"], 0, grdLedgerCode);
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr2"], 0, grdLedgerName);
						//                aLedger(0, grdApplyCostCenter) = .Fields("inventory_apply_cost").Value
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr101"], 0, grdCCNo);
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr102"], 0, grdCCName);
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr301"], 0, grdProjectNo);
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr302"], 0, grdProjectName);


						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr3"], 1, grdLedgerCode);
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr4"], 1, grdLedgerName);
						//                aLedger(1, grdApplyCostCenter) = .Fields("adjustment_apply_cost").Value
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr103"], 1, grdCCNo);
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr104"], 1, grdCCName);
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr303"], 1, grdProjectNo);
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr304"], 1, grdProjectName);

						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr5"], 2, grdLedgerCode);
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr6"], 2, grdLedgerName);
						//                aLedger(2, grdApplyCostCenter) = .Fields("cost_of_sale_apply_cost").Value
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr105"], 2, grdCCNo);
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr106"], 2, grdCCName);
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr305"], 2, grdProjectNo);
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr306"], 2, grdProjectName);

						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr7"], 3, grdLedgerCode);
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr8"], 3, grdLedgerName);
						//                aLedger(3, grdApplyCostCenter) = .Fields("pdis_apply_cost").Value
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr107"], 3, grdCCNo);
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr108"], 3, grdCCName);
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr307"], 3, grdProjectNo);
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr308"], 3, grdProjectName);

						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr9"], 4, grdLedgerCode);
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr10"], 4, grdLedgerName);
						//                aLedger(4, grdApplyCostCenter) = .Fields("cash_sale_apply_cost").Value
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr109"], 4, grdCCNo);
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr110"], 4, grdCCName);
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr309"], 4, grdProjectNo);
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr310"], 4, grdProjectName);

						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr11"], 5, grdLedgerCode);
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr12"], 5, grdLedgerName);
						//                aLedger(5, grdApplyCostCenter) = .Fields("credit_sale_apply_cost").Value
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr111"], 5, grdCCNo);
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr112"], 5, grdCCName);
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr311"], 5, grdProjectNo);
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr312"], 5, grdProjectName);

						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr13"], 6, grdLedgerCode);
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr14"], 6, grdLedgerName);
						//                aLedger(6, grdApplyCostCenter) = .Fields("cash_sdis_apply_cost").Value
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr113"], 6, grdCCNo);
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr114"], 6, grdCCName);
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr313"], 6, grdProjectNo);
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr314"], 6, grdProjectName);

						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr15"], 7, grdLedgerCode);
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr16"], 7, grdLedgerName);
						//                aLedger(7, grdApplyCostCenter) = .Fields("credit_sdis_apply_cost").Value
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr115"], 7, grdCCNo);
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr116"], 7, grdCCName);
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr315"], 7, grdProjectNo);
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr316"], 7, grdProjectName);

						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr17"], 8, grdLedgerCode);
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr18"], 8, grdLedgerName);
						//               aLedger(8, grdApplyCostCenter) = .Fields("pret_apply_cost").Value
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr117"], 8, grdCCNo);
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr118"], 8, grdCCName);
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr317"], 8, grdProjectNo);
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr318"], 8, grdProjectName);

						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr19"], 9, grdLedgerCode);
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr20"], 9, grdLedgerName);
						//                aLedger(9, grdApplyCostCenter) = .Fields("pret_dis_apply_cost").Value
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr119"], 9, grdCCNo);
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr120"], 9, grdCCName);
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr319"], 9, grdProjectNo);
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr320"], 9, grdProjectName);

						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr21"], 10, grdLedgerCode);
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr22"], 10, grdLedgerName);
						//                aLedger(10, grdApplyCostCenter) = .Fields("cash_sret_apply_cost").Value
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr121"], 10, grdCCNo);
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr122"], 10, grdCCName);
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr321"], 10, grdProjectNo);
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr322"], 10, grdProjectName);

						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr23"], 11, grdLedgerCode);
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr24"], 11, grdLedgerName);
						//                aLedger(11, grdApplyCostCenter) = .Fields("credit_sret_apply_cost").Value
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr123"], 11, grdCCNo);
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr124"], 11, grdCCName);
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr323"], 11, grdProjectNo);
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr324"], 11, grdProjectName);

						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr25"], 12, grdLedgerCode);
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr26"], 12, grdLedgerName);
						//                aLedger(12, grdApplyCostCenter) = .Fields("cash_sret_dis_apply_cost").Value
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr125"], 12, grdCCNo);
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr126"], 12, grdCCName);
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr325"], 12, grdProjectNo);
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr326"], 12, grdProjectName);

						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr27"], 13, grdLedgerCode);
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr28"], 13, grdLedgerName);
						//                aLedger(13, grdApplyCostCenter) = .Fields("credit_sret_dis_apply_cost").Value
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr127"], 13, grdCCNo);
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr128"], 13, grdCCName);
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr327"], 13, grdProjectNo);
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr328"], 13, grdProjectName);

						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr29"], 14, grdLedgerCode);
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr30"], 14, grdLedgerName);
						//                aLedger(14, grdApplyCostCenter) = .Fields("cash_apply_cost").Value
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr129"], 14, grdCCNo);
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr130"], 14, grdCCName);
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr329"], 14, grdProjectNo);
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr330"], 14, grdProjectName);

						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr31"], 15, grdLedgerCode);
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr32"], 15, grdLedgerName);
						//                aLedger(15, grdApplyCostCenter) = .Fields("suspense_apply_cost").Value
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr131"], 15, grdCCNo);
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr132"], 15, grdCCName);
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr331"], 15, grdProjectNo);
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr332"], 15, grdProjectName);

						//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
						if (grdVoucherDetails.Splits[0].DisplayColumns[grdAnlyCode1].Visible)
						{
							//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
							aLedger.SetValue(Convert.ToString(tempRec.Tables[0].Rows[0]["inventory_anly_code_1"]) + "", 0, grdAnlyCode1);
							//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
							aLedger.SetValue(Convert.ToString(tempRec.Tables[0].Rows[0]["adjustment_anly_code_1"]) + "", 1, grdAnlyCode1);
							//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
							aLedger.SetValue(Convert.ToString(tempRec.Tables[0].Rows[0]["cost_of_sale_anly_code_1"]) + "", 2, grdAnlyCode1);
							//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
							aLedger.SetValue(Convert.ToString(tempRec.Tables[0].Rows[0]["pdis_anly_code_1"]) + "", 3, grdAnlyCode1);
							//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
							aLedger.SetValue(Convert.ToString(tempRec.Tables[0].Rows[0]["cash_sale_anly_code_1"]) + "", 4, grdAnlyCode1);
							//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
							aLedger.SetValue(Convert.ToString(tempRec.Tables[0].Rows[0]["credit_sale_anly_code_1"]) + "", 5, grdAnlyCode1);
							//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
							aLedger.SetValue(Convert.ToString(tempRec.Tables[0].Rows[0]["cash_sdis_anly_code_1"]) + "", 6, grdAnlyCode1);
							//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
							aLedger.SetValue(Convert.ToString(tempRec.Tables[0].Rows[0]["credit_sdis_anly_code_1"]) + "", 7, grdAnlyCode1);
							//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
							aLedger.SetValue(Convert.ToString(tempRec.Tables[0].Rows[0]["pret_anly_code_1"]) + "", 8, grdAnlyCode1);
							//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
							aLedger.SetValue(Convert.ToString(tempRec.Tables[0].Rows[0]["pret_dis_anly_code_1"]) + "", 9, grdAnlyCode1);
							//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
							aLedger.SetValue(Convert.ToString(tempRec.Tables[0].Rows[0]["cash_sret_anly_code_1"]) + "", 10, grdAnlyCode1);
							//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
							aLedger.SetValue(Convert.ToString(tempRec.Tables[0].Rows[0]["credit_sret_anly_code_1"]) + "", 11, grdAnlyCode1);
							//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
							aLedger.SetValue(Convert.ToString(tempRec.Tables[0].Rows[0]["cash_sret_dis_anly_code_1"]) + "", 12, grdAnlyCode1);
							//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
							aLedger.SetValue(Convert.ToString(tempRec.Tables[0].Rows[0]["credit_sret_dis_anly_code_1"]) + "", 13, grdAnlyCode1);
							//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
							aLedger.SetValue(Convert.ToString(tempRec.Tables[0].Rows[0]["cash_anly_code_1"]) + "", 14, grdAnlyCode1);
							//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
							aLedger.SetValue(Convert.ToString(tempRec.Tables[0].Rows[0]["suspense_anly_code_1"]) + "", 15, grdAnlyCode1);
						}

						//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
						if (grdVoucherDetails.Splits[0].DisplayColumns[grdAnlyCode2].Visible)
						{
							//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
							aLedger.SetValue(Convert.ToString(tempRec.Tables[0].Rows[0]["inventory_anly_code_2"]) + "", 0, grdAnlyCode2);
							//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
							aLedger.SetValue(Convert.ToString(tempRec.Tables[0].Rows[0]["adjustment_anly_code_2"]) + "", 1, grdAnlyCode2);
							//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
							aLedger.SetValue(Convert.ToString(tempRec.Tables[0].Rows[0]["cost_of_sale_anly_code_2"]) + "", 2, grdAnlyCode2);
							//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
							aLedger.SetValue(Convert.ToString(tempRec.Tables[0].Rows[0]["pdis_anly_code_2"]) + "", 3, grdAnlyCode2);
							//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
							aLedger.SetValue(Convert.ToString(tempRec.Tables[0].Rows[0]["cash_sale_anly_code_2"]) + "", 4, grdAnlyCode2);
							//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
							aLedger.SetValue(Convert.ToString(tempRec.Tables[0].Rows[0]["credit_sale_anly_code_2"]) + "", 5, grdAnlyCode2);
							//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
							aLedger.SetValue(Convert.ToString(tempRec.Tables[0].Rows[0]["cash_sdis_anly_code_2"]) + "", 6, grdAnlyCode2);
							//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
							aLedger.SetValue(Convert.ToString(tempRec.Tables[0].Rows[0]["credit_sdis_anly_code_2"]) + "", 7, grdAnlyCode2);
							//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
							aLedger.SetValue(Convert.ToString(tempRec.Tables[0].Rows[0]["pret_anly_code_2"]) + "", 8, grdAnlyCode2);
							//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
							aLedger.SetValue(Convert.ToString(tempRec.Tables[0].Rows[0]["pret_dis_anly_code_2"]) + "", 9, grdAnlyCode2);
							//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
							aLedger.SetValue(Convert.ToString(tempRec.Tables[0].Rows[0]["cash_sret_anly_code_2"]) + "", 10, grdAnlyCode2);
							//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
							aLedger.SetValue(Convert.ToString(tempRec.Tables[0].Rows[0]["credit_sret_anly_code_2"]) + "", 11, grdAnlyCode2);
							//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
							aLedger.SetValue(Convert.ToString(tempRec.Tables[0].Rows[0]["cash_sret_dis_anly_code_2"]) + "", 12, grdAnlyCode2);
							//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
							aLedger.SetValue(Convert.ToString(tempRec.Tables[0].Rows[0]["credit_sret_dis_anly_code_2"]) + "", 13, grdAnlyCode2);
							//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
							aLedger.SetValue(Convert.ToString(tempRec.Tables[0].Rows[0]["cash_anly_code_2"]) + "", 14, grdAnlyCode2);
							//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
							aLedger.SetValue(Convert.ToString(tempRec.Tables[0].Rows[0]["suspense_anly_code_2"]) + "", 15, grdAnlyCode2);
						}

						if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("service_product")))
						{
							//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
							aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr33"], 16, grdLedgerCode);
							//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
							aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr34"], 16, grdLedgerName);
							//                    aLedger(16, grdApplyCostCenter) = .Fields("service_sales_apply_cost").Value
							//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
							aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr133"], 16, grdCCNo);
							//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
							aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr134"], 16, grdCCName);
							//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
							aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr333"], 16, grdProjectNo);
							//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
							aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr334"], 16, grdProjectName);

							//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
							aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr35"], 17, grdLedgerCode);
							//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
							aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr36"], 17, grdLedgerName);
							//                    aLedger(17, grdApplyCostCenter) = .Fields("service_cost_of_sales_apply_cost").Value
							//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
							aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr135"], 17, grdCCNo);
							//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
							aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr136"], 17, grdCCName);
							//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
							aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr335"], 17, grdProjectNo);
							//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
							aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr336"], 17, grdProjectName);

							//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
							aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr37"], 18, grdLedgerCode);
							//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
							aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr38"], 18, grdLedgerName);
							//                    aLedger(18, grdApplyCostCenter) = .Fields("service_expenses_apply_cost").Value
							//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
							aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr137"], 18, grdCCNo);
							//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
							aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr138"], 18, grdCCName);
							//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
							aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr337"], 18, grdProjectNo);
							//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
							aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr338"], 18, grdProjectName);

							//-------------Credit accounts-----------------------
							//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
							aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr39"], 19, grdLedgerCode);
							//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
							aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr40"], 19, grdLedgerName);
							//                    aLedger(19, grdApplyCostCenter) = .Fields("service_sales_apply_cost").Value
							//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
							aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr133"], 19, grdCCNo);
							//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
							aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr140"], 19, grdCCName);
							//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
							aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr339"], 19, grdProjectNo);
							//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
							aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr340"], 19, grdProjectName);

							//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
							aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr41"], 20, grdLedgerCode);
							//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
							aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr42"], 20, grdLedgerName);
							//                    aLedger(20, grdApplyCostCenter) = .Fields("service_cost_of_sales_apply_cost").Value
							//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
							aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr141"], 20, grdCCNo);
							//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
							aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr142"], 20, grdCCName);
							//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
							aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr341"], 20, grdProjectNo);
							//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
							aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr342"], 20, grdProjectName);

							//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
							aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr43"], 21, grdLedgerCode);
							//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
							aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr44"], 21, grdLedgerName);
							//                    aLedger(21, grdApplyCostCenter) = .Fields("service_expenses_apply_cost").Value
							//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
							aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr143"], 21, grdCCNo);
							//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
							aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr144"], 21, grdCCName);
							//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
							aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr343"], 21, grdProjectNo);
							//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
							aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr344"], 21, grdProjectName);
							//-------------------------------------------------------------------

							//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
							if (grdVoucherDetails.Splits[0].DisplayColumns[grdAnlyCode1].Visible)
							{
								//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
								aLedger.SetValue(Convert.ToString(tempRec.Tables[0].Rows[0]["service_sales_anly_code_1"]) + "", 16, grdAnlyCode1);
								//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
								aLedger.SetValue(Convert.ToString(tempRec.Tables[0].Rows[0]["service_expense_anly_code_1"]) + "", 17, grdAnlyCode1);
								//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
								aLedger.SetValue(Convert.ToString(tempRec.Tables[0].Rows[0]["service_cost_of_sales_anly_code_1"]) + "", 18, grdAnlyCode1);

								//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
								aLedger.SetValue(Convert.ToString(tempRec.Tables[0].Rows[0]["service_sales_anly_code_1"]) + "", 19, grdAnlyCode1);
								//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
								aLedger.SetValue(Convert.ToString(tempRec.Tables[0].Rows[0]["service_expense_anly_code_1"]) + "", 20, grdAnlyCode1);
								//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
								aLedger.SetValue(Convert.ToString(tempRec.Tables[0].Rows[0]["service_cost_of_sales_anly_code_1"]) + "", 21, grdAnlyCode1);
							}

							//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
							if (grdVoucherDetails.Splits[0].DisplayColumns[grdAnlyCode2].Visible)
							{
								//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
								aLedger.SetValue(Convert.ToString(tempRec.Tables[0].Rows[0]["service_sales_anly_code_2"]) + "", 16, grdAnlyCode2);
								//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
								aLedger.SetValue(Convert.ToString(tempRec.Tables[0].Rows[0]["service_expense_anly_code_2"]) + "", 17, grdAnlyCode2);
								//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
								aLedger.SetValue(Convert.ToString(tempRec.Tables[0].Rows[0]["service_cost_of_sales_anly_code_2"]) + "", 18, grdAnlyCode2);

								//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
								aLedger.SetValue(Convert.ToString(tempRec.Tables[0].Rows[0]["service_sales_anly_code_2"]) + "", 19, grdAnlyCode2);
								//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
								aLedger.SetValue(Convert.ToString(tempRec.Tables[0].Rows[0]["service_expense_anly_code_2"]) + "", 20, grdAnlyCode2);
								//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
								aLedger.SetValue(Convert.ToString(tempRec.Tables[0].Rows[0]["service_cost_of_sales_anly_code_2"]) + "", 21, grdAnlyCode2);
							}

						}

						if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("non_inventory_product")))
						{
							//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
							aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr45"], 16 + mNonInventoryIncrementValue, grdLedgerCode);
							//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
							aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr46"], 16 + mNonInventoryIncrementValue, grdLedgerName);
							//                    aLedger(16 + mNonInventoryIncrementValue, grdApplyCostCenter) = .Fields("non_inventory_sales_apply_cost").Value
							//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
							aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr145"], 16 + mNonInventoryIncrementValue, grdCCNo);
							//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
							aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr146"], 16 + mNonInventoryIncrementValue, grdCCName);
							//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
							aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr345"], 16 + mNonInventoryIncrementValue, grdProjectNo);
							//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
							aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr346"], 16 + mNonInventoryIncrementValue, grdProjectName);

							//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
							aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr47"], 17 + mNonInventoryIncrementValue, grdLedgerCode);
							//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
							aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr48"], 17 + mNonInventoryIncrementValue, grdLedgerName);
							//                    aLedger(17 + mNonInventoryIncrementValue, grdApplyCostCenter) = .Fields("non_inventory_cost_of_sales_apply_cost").Value
							//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
							aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr147"], 17 + mNonInventoryIncrementValue, grdCCNo);
							//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
							aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr148"], 17 + mNonInventoryIncrementValue, grdCCName);
							//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
							aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr347"], 17 + mNonInventoryIncrementValue, grdProjectNo);
							//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
							aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr348"], 17 + mNonInventoryIncrementValue, grdProjectName);

							//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
							aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr49"], 18 + mNonInventoryIncrementValue, grdLedgerCode);
							//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
							aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr50"], 18 + mNonInventoryIncrementValue, grdLedgerName);
							//                    aLedger(18 + mNonInventoryIncrementValue, grdApplyCostCenter) = .Fields("non_inventory_expenses_apply_cost").Value
							//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
							aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr149"], 18 + mNonInventoryIncrementValue, grdCCNo);
							//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
							aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr150"], 18 + mNonInventoryIncrementValue, grdCCName);
							//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
							aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr349"], 18 + mNonInventoryIncrementValue, grdProjectNo);
							//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
							aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr350"], 18 + mNonInventoryIncrementValue, grdProjectName);

							//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
							aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr51"], 19 + mNonInventoryIncrementValue, grdLedgerCode);
							//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
							aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr52"], 19 + mNonInventoryIncrementValue, grdLedgerName);
							//                    aLedger(19 + mNonInventoryIncrementValue, grdApplyCostCenter) = .Fields("non_inventory_sales_apply_cost").Value
							//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
							aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr151"], 19 + mNonInventoryIncrementValue, grdCCNo);
							//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
							aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr152"], 19 + mNonInventoryIncrementValue, grdCCName);
							//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
							aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr351"], 19 + mNonInventoryIncrementValue, grdProjectNo);
							//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
							aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr352"], 19 + mNonInventoryIncrementValue, grdProjectName);

							//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
							aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr53"], 20 + mNonInventoryIncrementValue, grdLedgerCode);
							//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
							aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr54"], 20 + mNonInventoryIncrementValue, grdLedgerName);
							//                    aLedger(20 + mNonInventoryIncrementValue, grdApplyCostCenter) = .Fields("non_inventory_cost_of_sales_apply_cost").Value
							//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
							aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr153"], 20 + mNonInventoryIncrementValue, grdCCNo);
							//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
							aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr154"], 20 + mNonInventoryIncrementValue, grdCCName);
							//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
							aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr353"], 20 + mNonInventoryIncrementValue, grdProjectNo);
							//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
							aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr354"], 20 + mNonInventoryIncrementValue, grdProjectName);

							//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
							aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr55"], 21 + mNonInventoryIncrementValue, grdLedgerCode);
							//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
							aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr56"], 21 + mNonInventoryIncrementValue, grdLedgerName);
							//                    aLedger(21 + mNonInventoryIncrementValue, grdApplyCostCenter) = .Fields("non_inventory_expenses_apply_cost").Value
							//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
							aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr155"], 21 + mNonInventoryIncrementValue, grdCCNo);
							//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
							aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr156"], 21 + mNonInventoryIncrementValue, grdCCName);
							//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
							aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr355"], 21 + mNonInventoryIncrementValue, grdProjectNo);
							//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
							aLedger.SetValue(tempRec.Tables[0].Rows[0]["expr356"], 21 + mNonInventoryIncrementValue, grdProjectName);

							//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
							if (grdVoucherDetails.Splits[0].DisplayColumns[grdAnlyCode1].Visible)
							{
								//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
								aLedger.SetValue(Convert.ToString(tempRec.Tables[0].Rows[0]["non_inventory_sales_anly_code_1"]) + "", 16 + mNonInventoryIncrementValue, grdAnlyCode1);
								//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
								aLedger.SetValue(Convert.ToString(tempRec.Tables[0].Rows[0]["non_inventory_expense_anly_code_1"]) + "", 17 + mNonInventoryIncrementValue, grdAnlyCode1);
								//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
								aLedger.SetValue(Convert.ToString(tempRec.Tables[0].Rows[0]["non_inventory_cost_of_sales_anly_code_1"]) + "", 18 + mNonInventoryIncrementValue, grdAnlyCode1);

								//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
								aLedger.SetValue(Convert.ToString(tempRec.Tables[0].Rows[0]["non_inventory_sales_anly_code_1"]) + "", 19 + mNonInventoryIncrementValue, grdAnlyCode1);
								//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
								aLedger.SetValue(Convert.ToString(tempRec.Tables[0].Rows[0]["non_inventory_expense_anly_code_1"]) + "", 20 + mNonInventoryIncrementValue, grdAnlyCode1);
								//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
								aLedger.SetValue(Convert.ToString(tempRec.Tables[0].Rows[0]["non_inventory_cost_of_sales_anly_code_1"]) + "", 21 + mNonInventoryIncrementValue, grdAnlyCode1);
							}

							//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
							if (grdVoucherDetails.Splits[0].DisplayColumns[grdAnlyCode2].Visible)
							{
								//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
								aLedger.SetValue(Convert.ToString(tempRec.Tables[0].Rows[0]["non_inventory_sales_anly_code_2"]) + "", 16 + mNonInventoryIncrementValue, grdAnlyCode2);
								//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
								aLedger.SetValue(Convert.ToString(tempRec.Tables[0].Rows[0]["non_inventory_expense_anly_code_2"]) + "", 17 + mNonInventoryIncrementValue, grdAnlyCode2);
								//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
								aLedger.SetValue(Convert.ToString(tempRec.Tables[0].Rows[0]["non_inventory_cost_of_sales_anly_code_2"]) + "", 18 + mNonInventoryIncrementValue, grdAnlyCode2);

								//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
								aLedger.SetValue(Convert.ToString(tempRec.Tables[0].Rows[0]["non_inventory_sales_anly_code_2"]) + "", 19 + mNonInventoryIncrementValue, grdAnlyCode2);
								//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
								aLedger.SetValue(Convert.ToString(tempRec.Tables[0].Rows[0]["non_inventory_expense_anly_code_2"]) + "", 20 + mNonInventoryIncrementValue, grdAnlyCode2);
								//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
								aLedger.SetValue(Convert.ToString(tempRec.Tables[0].Rows[0]["non_inventory_cost_of_sales_anly_code_2"]) + "", 21 + mNonInventoryIncrementValue, grdAnlyCode2);
							}

						}


						grdVoucherDetails.Rebind(true);
					}
					else
					{
						int tempForEndVar = mMaxArrayRows;
						for (i = 0; i <= tempForEndVar; i++)
						{
							aLedger.SetValue("", i, 1);
							aLedger.SetValue("", i, 2);
						}
						grdVoucherDetails.Rebind(true);
					}
					tempRec = null;
				}
				else
				{
					//cmbCommon.HoldFields
					//UPGRADE_ISSUE: (2064) ADODB.Recordset method rsLedgerList.Requery was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					rsLedgerList.Requery(-1);
				}
			}

			grdVoucherDetails.Col = 1;

			try
			{
				grdVoucherDetails.Focus();
			}
			catch
			{
			}
		}


		private void txtDefaultCashCode_Leave(Object eventSender, EventArgs eventArgs)
		{
			try
			{
				object mTempValue = null;
				string mysql = "";
				int Cnt = 0;

				if (!SystemProcedure2.IsItEmpty(txtDefaultCashCode.Text, SystemVariables.DataType.NumberType))
				{
					mysql = "select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_ldgr_name" : "a_ldgr_name");
					mysql = mysql + " from gl_ledger where ldgr_no='" + txtDefaultCashCode.Text + "'";
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (Convert.IsDBNull(mTempValue))
					{
						txtDefaultCashCode.Text = "";
						lblDefaultCashName.Text = "";
						throw new System.Exception("-9990002");
					}
					else
					{
						//UPGRADE_WARNING: (1068) mTempValue of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						lblDefaultCashName.Text = ReflectionHelper.GetPrimitiveValue<string>(mTempValue);
					}
				}
				else
				{
					lblDefaultCashName.Text = "";
				}
			}
			catch (System.Exception excep)
			{

				int mReturnErrorType = 0;
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				mReturnErrorType = SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, excep.Message, this.Name, "GetRecord", SystemConstants.msg10);
				if (mReturnErrorType == 1)
				{
					//
				}
				else if (mReturnErrorType == 2)
				{ 
					//
				}
				else if (mReturnErrorType == 3)
				{ 
					//
				}
				else if (mReturnErrorType == 4)
				{ 
					//    txtParentCostNo.SetFocus
				}
				else
				{
					//
				}
			}
		}

		private void txtLocationNo_DropButtonClick(Object Sender, EventArgs e)
		{
			GetNextNumber();
		}

		public void GetNextNumber()
		{
			txtLocationNo.Text = SystemProcedure2.GetNewNumber("SM_location", "locat_no");
			txtLocationNo.Focus();
		}

		private void GenerateRecordSet()
		{

			string mysql = "select ldgr_no, ";
			mysql = mysql + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_ldgr_name as ldgr_name" : "a_ldgr_name as ldgr_name");
			mysql = mysql + " , group_cd, type_cd ";
			mysql = mysql + " from gl_ledger ";
			mysql = mysql + " where curr_cd =" + SystemGLConstants.gDefaultCurrencyCd.ToString();

			rsLedgerList = new DataSet();
			//UPGRADE_ISSUE: (2064) ADODB.CursorLocationEnum property CursorLocationEnum.adUseClient was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsLedgerList.CursorLocation was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			rsLedgerList.setCursorLocation(UpgradeStubs.ADODB_CursorLocationEnum.getadUseClient());
			SqlDataAdapter adap = new SqlDataAdapter(mysql, SystemVariables.gConn);
			rsLedgerList.Tables.Clear();
			adap.Fill(rsLedgerList);

			mysql = "select cost_no, ";
			mysql = mysql + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_cost_name as cost_name" : "a_cost_name as cost_name");
			mysql = mysql + " from gl_cost_centers ";
			rsCostList = new DataSet();
			//UPGRADE_ISSUE: (2064) ADODB.CursorLocationEnum property CursorLocationEnum.adUseClient was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsCostList.CursorLocation was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			rsCostList.setCursorLocation(UpgradeStubs.ADODB_CursorLocationEnum.getadUseClient());
			SqlDataAdapter adap_2 = new SqlDataAdapter(mysql, SystemVariables.gConn);
			rsCostList.Tables.Clear();
			adap_2.Fill(rsCostList);

			mysql = "select project_no, ";
			mysql = mysql + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_project_name as project_name" : "a_project_name as project_name");
			mysql = mysql + " from PROJ_Projects ";
			rsProjectList = new DataSet();
			//UPGRADE_ISSUE: (2064) ADODB.CursorLocationEnum property CursorLocationEnum.adUseClient was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsProjectList.CursorLocation was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			rsProjectList.setCursorLocation(UpgradeStubs.ADODB_CursorLocationEnum.getadUseClient());
			SqlDataAdapter adap_3 = new SqlDataAdapter(mysql, SystemVariables.gConn);
			rsProjectList.Tables.Clear();
			adap_3.Fill(rsProjectList);

			//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
			if (grdVoucherDetails.Splits[0].DisplayColumns[grdAnlyCode1].Visible || grdVoucherDetails.Splits[0].DisplayColumns[grdAnlyCode2].Visible)
			{
				mysql = "select anly_code , ";
				mysql = mysql + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_anly_name as anly_name" : "a_anly_name as anly_name");
				mysql = mysql + " , anly_head_no ";
				mysql = mysql + " from gl_analysis ";
				mysql = mysql + " order by 1 ";

				rsAnlyCode = new DataSet();
				//UPGRADE_ISSUE: (2064) ADODB.CursorLocationEnum property CursorLocationEnum.adUseClient was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsAnlyCode.CursorLocation was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				rsAnlyCode.setCursorLocation(UpgradeStubs.ADODB_CursorLocationEnum.getadUseClient());
				SqlDataAdapter adap_4 = new SqlDataAdapter(mysql, SystemVariables.gConn);
				rsAnlyCode.Tables.Clear();
				adap_4.Fill(rsAnlyCode);
			}

		}

		private string FilterGroupCodeOnLedgerSql(string pGroupCodeList, int pReturnType = 0)
		{
			int Cnt = 0;
			StringBuilder mFilterClause = new StringBuilder();

			string[] mGroupCodeFilterList = pGroupCodeList.Split(',');

			//mFilterClause = mFilterClause & " 1=1 "

			int tempForEndVar = mGroupCodeFilterList.GetUpperBound(0);
			for (Cnt = 0; Cnt <= tempForEndVar; Cnt++)
			{
				if (Cnt > 0)
				{
					mFilterClause.Append(" or ");
				}

				//If pReturnType = 0 Then
				mFilterClause.Append(" type_cd =" + mGroupCodeFilterList[Cnt].Trim());
				//Else
				//    mFilterClause = mFilterClause & " left(group_cd,4)='" & Trim(mGroupCodeFilterList(cnt)) & "'"
				//End If
			}


			return mFilterClause.ToString();


			//FilterGroupCodeOnLedgerSql = " group_cd in (" & pGroupCodeList & ")"
		}

		public void FindRoutine(string pObjectName)
		{
			object mTempSearchValue = null;

			switch(pObjectName)
			{
				case "txtDefaultLdgrNo" : 
					txtDefaultLdgrNo.Text = ""; 
					//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
					mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(1001000, "2")); 
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049 
					if (!Convert.IsDBNull(mTempSearchValue))
					{
						//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtDefaultLdgrNo.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(1));
						txtDefaultLdgrNo_Leave(txtDefaultLdgrNo, new EventArgs());
					} 
					break;
				case "txtDefaultCashCode" : 
					txtDefaultCashCode.Text = ""; 
					//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
					mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(1001000, "2")); 
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049 
					if (!Convert.IsDBNull(mTempSearchValue))
					{
						//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtDefaultCashCode.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(1));
						txtDefaultCashCode_Leave(txtDefaultCashCode, new EventArgs());
					} 
					break;
				case "txtDefaultSalesmanNo" : 
					txtDefaultSalesmanNo.Text = ""; 
					//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
					mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(1004000, "88")); 
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049 
					if (!Convert.IsDBNull(mTempSearchValue))
					{
						//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtDefaultSalesmanNo.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(1));
						txtDefaultSalesmanNo_Leave(txtDefaultSalesmanNo, new EventArgs());
					} 
					break;
			}
		}

		private void txtDefaultLdgrNo_DropButtonClick(Object Sender, EventArgs e)
		{
			FindRoutine("txtDefaultLdgrNo");
		}

		private void txtDefaultLdgrNo_Leave(Object eventSender, EventArgs eventArgs)
		{
			try
			{
				object mTempValue = null;
				string mysql = "";
				int Cnt = 0;

				if (!SystemProcedure2.IsItEmpty(txtDefaultLdgrNo.Text, SystemVariables.DataType.NumberType))
				{
					mysql = "select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_ldgr_name" : "a_ldgr_name");
					mysql = mysql + " from gl_ledger where ldgr_no='" + txtDefaultLdgrNo.Text + "'";
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (Convert.IsDBNull(mTempValue))
					{
						txtDefaultLdgrNo.Text = "";
						lblDefaultLdgrName.Text = "";
						throw new System.Exception("-9990002");
					}
					else
					{
						//UPGRADE_WARNING: (1068) mTempValue of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						lblDefaultLdgrName.Text = ReflectionHelper.GetPrimitiveValue<string>(mTempValue);
					}
				}
				else
				{
					lblDefaultLdgrName.Text = "";
				}
			}
			catch (System.Exception excep)
			{

				int mReturnErrorType = 0;
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				mReturnErrorType = SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, excep.Message, this.Name, "GetRecord", SystemConstants.msg10);
				if (mReturnErrorType == 1)
				{
					//
				}
				else if (mReturnErrorType == 2)
				{ 
					//
				}
				else if (mReturnErrorType == 3)
				{ 
					//
				}
				else if (mReturnErrorType == 4)
				{ 
					//    txtParentCostNo.SetFocus
				}
				else
				{
					//
				}
			}
		}

		private void txtDefaultCashCode_DropButtonClick(Object Sender, EventArgs e)
		{
			FindRoutine("txtDefaultCashCode");
		}

		private void txtDefaultSalesmanNo_DropButtonClick(Object Sender, EventArgs e)
		{
			FindRoutine("txtDefaultSalesmanNo");
		}

		private void txtDefaultSalesmanNo_Leave(Object eventSender, EventArgs eventArgs)
		{
			try
			{
				object mTempValue = null;
				string mysql = "";
				int Cnt = 0;

				if (!SystemProcedure2.IsItEmpty(txtDefaultSalesmanNo.Text, SystemVariables.DataType.NumberType))
				{
					mysql = "select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_sman_name" : "a_sman_name");
					mysql = mysql + " from SM_Salesman where sman_no='" + txtDefaultSalesmanNo.Text + "'";
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (Convert.IsDBNull(mTempValue))
					{
						txtLocationNo.Text = "";
						lblDefaultsalesmanName.Text = "";
						throw new System.Exception("-9990002");
					}
					else
					{
						//UPGRADE_WARNING: (1068) mTempValue of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						lblDefaultsalesmanName.Text = ReflectionHelper.GetPrimitiveValue<string>(mTempValue);
					}
				}
				else
				{
					lblDefaultsalesmanName.Text = "";
				}
			}
			catch (System.Exception excep)
			{

				int mReturnErrorType = 0;
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				mReturnErrorType = SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, excep.Message, this.Name, "GetRecord", SystemConstants.msg10);
				if (mReturnErrorType == 1)
				{
					//
				}
				else if (mReturnErrorType == 2)
				{ 
					//
				}
				else if (mReturnErrorType == 3)
				{ 
					//
				}
				else if (mReturnErrorType == 4)
				{ 
					//    txtParentCostNo.SetFocus
				}
				else
				{
					//
				}
			}
		}

		private void DefineAnlysisFilter(DataSet rsTempRecords, int pAnalysisHeadNo)
		{
			rsTempRecords.Tables[0].DefaultView.RowFilter = " anly_head_no = " + pAnalysisHeadNo.ToString();
		}
	}
}