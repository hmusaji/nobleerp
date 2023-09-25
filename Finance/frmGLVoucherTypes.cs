
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using UpgradeHelpers.Gui;

using UpgradeHelpers.VB;


namespace Xtreme
{
	internal partial class frmGLVoucherTypes
		: System.Windows.Forms.Form
	{

		public frmGLVoucherTypes()
{
InitializeComponent();
} 
 public  void frmGLVoucherTypes_old()
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
			isInitializingComponent = true;
			InitializeComponent();
			isInitializingComponent = false;
			
		}


		private void frmGLVoucherTypes_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (UpgradeHelpers.Gui.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Gui.ActivateHelper.myActiveForm = (System.Windows.Forms.Form) eventSender;
			}
		}
		private object mRecordNavigateSearchValue = null;
		private const int cVoucherNoMethod = 0;
		private const int cVoucherType = 1;
		//Private Const cParentType  As Integer = 2
		private const int cModuleId = 3;
		private const int cOpVoucherType = 4;
		//Private Const cClassCd  As Integer = 5
		private const int cLVoucherName = 6;
		private const int cAVoucherName = 7;
		private const int cLShortName = 8;
		private const int cAShortName = 9;
		private const int cDebitFilterCondition = 10;
		private const int cCreditFilterCondition = 11;
		private const int cAllowSingleEntry = 12;
		private const int cSingleEntryType = 13;
		private const int cOppositeLdgrCd = 14;
		private const int cShowOppositeLdgrInHeader = 15;
		private const int cOppositeLdgrHeaderCaption = 16;
		private const int cOppositeLdgrCdCaption = 17;
		private const int cOppositeLdgrNameCaption = 18;
		private const int cAdjustDifferenceInOppositeLdgrCd = 19;
		private const int cDefaultDrCrType = 20;
		private const int cShowLineNo = 21;
		private const int cShowDrCrType = 22;
		private const int cShowLdgrCd = 23;
		private const int cShowLdgrName = 24;
		private const int cShowCurrency = 25;
		private const int cShowDrAmt = 26;
		private const int cShowCrAmt = 27;
		private const int cShowCostCenter = 28;
		private const int cShowSalesman = 29;
		private const int cShowRemarksInDetails = 30;
		private const int cShowRemarksInHeader = 31;
		private const int cShowAdditionalLedgerDetails = 32;
		private const int cShowVoucherAdjustment = 33;
		private const int cAllowListingOfLdgrCd = 34;
		private const int cAllowListingOfLdgrName = 35;
		private const int cAutoGenerateVoucherNo = 36;
		private const int cPrintAfterSave = 37;
		private const int cShowPrintPreviewFirst = 38;
		private const int cShowPageSetupFirst = 39;
		private const int cClosePreviewWindowsAfterPrint = 40;
		private const int cShowinMenu = 41;
		private const int cLastDebitLdgrCd = 42;
		private const int cLastCreditLdgrCd = 43;
		private const int cLastCostCd = 44;
		private const int cLastSmanCd = 45;
		private const int cUsed = 46;
		private const int cShow = 47;
		private const int cProtected = 48;
		private const int cComments = 49;
		private const int cFindID = 51;
		private const int cModuleName = 52;
		private const int cLastDebitLdgrName = 53;
		private const int cLastCreditLdgrName = 54;
		private const int cLastCostName = 55;
		private const int cLastSmanName = 56;
		private const int cUserName = 57;
		private const int cOppositeLdgrName = 58;
		private const string cDrCaption = "Dr";
		private const string cCrCaption = "Cr";

		private const string cAutomatic = "Automatic";
		private const string cManual = "Manual";

		//Added By: Moiz Hakimi. 23/12/2007. To Add Additional Fields
		//---------------------------------------------------
		private const int cCrystalReportsEngCd = 5;
		private const int cCrystalReportsEngName = 4;
		private const int cEntryIdEngCd = 2;
		private const int cEntryIdEngName = 22;
		private const int cCrystalReportsArCd = 13;
		private const int cCrystalReportsArName = 12;
		private const int cEntryIdArCd = 11;
		private const int cEntryIdArName = 10;
		private const int cPDCGeneratedLinkedVoucherCd = 19;
		private const int cPDCGeneratedLinkedVoucherName = 15;
		private const int cParentCd = 20;
		private const int cParentName = 25;
		private const int cPreferenceCd = 23;
		private const int cFeatureName = 21;
		private const int cPrintVoucherName = 12;
		private const int cUseCrystalReports = 2;
		private const int cUseXMLReports = 3;
		private const int cPDCPaymentType = 1;
		private const int cPDCReceiptType = 2;
		private const int cAffectGLS = 1;
		private const int cShowMaturityDate = 2;
		private const int cShowChequeNo = 3;
		private const int cShowFlex1InHeader = 5;
		private const int cBeginWithLineSeperator = 18;
		private const int cShowBranchCdOnHeader = 7;
		private const int cShowChequeNoInDetails = 6;
		private const int cEnableComboList = 0;
		private const int cGetMaxNewVoucherNo = 8;
		private const int cShowConsignmentInDetails = 9;
		private const int cShowFlex1InDetails = 10;
		private const int cDisplayVoucherNoAfterSave = 11;
		private const int cShowDefaultSalesmanInDetail = 13;
		//---------------------------------------------------

		//Variable for storing the searchvalue from the Find window
		object mSearchValue = null;
		int mThisFormID = 0;
		string mTimeStamp = "";
		private clsAccessAllowed _UserAccess = null;
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
		 //This class checks for the rights given to the user
		public clsToolbar oThisFormToolBar = null;
		private SystemVariables.SystemFormModes mCurrentFormMode = (SystemVariables.SystemFormModes) 0; //Enum for checking the current form mode
		public Control FirstFocusObject = null;

		private XArrayHelper _aReportDetails = null;
		private XArrayHelper aReportDetails
		{
			get
			{
				if (_aReportDetails is null)
				{
					_aReportDetails = new XArrayHelper();
				}
				return _aReportDetails;
			}
			set
			{
				_aReportDetails = value;
			}
		}

		private DataSet rsReportList = null;
		private DataSet rsPOSList = null;
		private DataSet rsPrinterList = null;

		private const int mMaxReportDetailCols = 11;

		private const int grdLNColumn = 0;
		private const int grdPOSColumn = 1;
		private const int grdReportColumn = 2;
		private const int grdPrinterColumn = 3;
		private const int grdAutoPrintColumn = 4;
		private const int grdEnablePrintOnEditColumn = 5;
		private const int grdPromptForPrintColumn = 6;
		private const int grdShowOptionColumn = 7;
		private const int grdShowPreviewColumn = 8;
		private const int grdShowPrinterColumn = 9;
		private const int grdDefaultSelectColumn = 10;

		private int mLastCol = 0;
		private int mLastRow = 0;

		int mPOS = 0;
		int mReport_Id = 0;
		string mPrinter_Name = "";
		int mAuto_Print = 0;
		int mEnable_Print_Edit = 0;
		int mShow_Option = 0;
		int mShow_Preview = 0;
		int mShow_Printer = 0;
		int mPrompt_For_Print = 0;
		int mDefault_Select = 0;

		//These property set the Form mode to add mode or edit mode

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


		//The property below are used for storing the Search value returned by the Find window

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


		//These property set the Form mode to add mode or edit mode

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



		//Private Sub btnFormToolBar_Click(Index As Integer)
		//Call ToolBarButtonClick(Me, btnFormToolBar(Index).Tag)
		//End Sub

		private void chkControl_CheckStateChanged(Object eventSender, EventArgs eventArgs)
		{
			int Index = Array.IndexOf(this.chkControl, eventSender);
			if (Index == cAllowSingleEntry)
			{
				Frame4.Enabled = chkControl[Index].CheckState == CheckState.Checked;
			}
			if (Index == cShowOppositeLdgrInHeader)
			{
				if (chkControl[Index].CheckState == CheckState.Checked)
				{
					txtControl[cOppositeLdgrHeaderCaption].Enabled = true;
					txtControl[cOppositeLdgrCdCaption].Enabled = true;
					txtControl[cOppositeLdgrNameCaption].Enabled = true;
				}
				else
				{
					txtControl[cOppositeLdgrHeaderCaption].Enabled = false;
					txtControl[cOppositeLdgrCdCaption].Enabled = false;
					txtControl[cOppositeLdgrNameCaption].Enabled = false;
				}
			}
		}


		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBDropDown Event cmbPrintList.DropDownClose was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void cmbPrintList_DropDownClose()
		{
			//'***************************************************************************''
			//'This routine handles the navigation for next column after a value is selected
			//'from listbox in the grid.
			//'***************************************************************************''

			switch(grdPrintTask.Col)
			{
				case grdPOSColumn : 
					//grdPrintTask.Col = ckPartNoIndex 
					break;
				case grdReportColumn : 
					break;
				case grdPrinterColumn : 
					 
					break;
			}
		}

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBDropDown Event cmbPrintList.DataSourceChanged was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void cmbPrintList_DataSourceChanged()
		{
			int cnt = 0;

			cmbPrintList.Width = 0;
			switch(grdPrintTask.Col)
			{
				case grdPOSColumn : 
					//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbPrintList.ListField was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064 
					cmbPrintList.setListField("POS_Counter_Cd"); 
					cmbPrintList.DisplayColumns[0].Visible = true; 
					cmbPrintList.DisplayColumns[0].Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Near; 
					//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081 
					cmbPrintList.Width = grdPrintTask.Splits[0].DisplayColumns[grdPOSColumn].Width + 167; 
					cmbPrintList.Height = 167; 
					 
					break;
				case grdReportColumn : 
					//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbPrintList.ListField was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064 
					cmbPrintList.setListField("Report_Id"); 
					cmbPrintList.DisplayColumns[0].Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Near; 
					//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081 
					cmbPrintList.Width = grdPrintTask.Splits[0].DisplayColumns[grdReportColumn].Width + 167; 
					cmbPrintList.Height = 167; 
					 
					break;
				case grdPrinterColumn : 
					//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbPrintList.ListField was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064 
					cmbPrintList.setListField("DeviceName"); 
					cmbPrintList.DisplayColumns[0].Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Near; 
					//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081 
					cmbPrintList.Width = grdPrintTask.Splits[0].DisplayColumns[grdPrinterColumn].Width + 67; 
					cmbPrintList.Height = 167; 
					break;
				default:
					cmbPrintList.Width = 0; 
					break;
			}
		}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2080
		private void Form_Load()
		{
			string cGridColor = (0xE7E2DC).ToString();
			try
			{

				FirstFocusObject = txtControl[cVoucherType];

				this.CurrentFormMode = SystemVariables.SystemFormModes.frmAddMode;
				this.Top = 0;
				this.Left = 0;

				oThisFormToolBar = new clsToolbar();
				oThisFormToolBar.AttachObject(this); //, tcbSystemForm
				oThisFormToolBar.ShowNewButton = true;
				oThisFormToolBar.ShowSaveButton = true;
				oThisFormToolBar.ShowDeleteButton = true;
				oThisFormToolBar.ShowPrintButton = true;
				oThisFormToolBar.ShowFindButton = true;

				oThisFormToolBar.ShowExitButton = true;
				oThisFormToolBar.BeginExitButtonWithGroup = true;

				oThisFormToolBar.ShowMoveRecordNextButton = true;
				oThisFormToolBar.ShowMoveRecordPreviousButton = true;

				this.WindowState = FormWindowState.Maximized;


				SystemGrid.DefineSystemVoucherGrid(grdPrintTask, true, true, true, (0xFFFFFF).ToString(), (0x0).ToString(), true, false, C1.Win.C1TrueDBGrid.MarqueeEnum.FloatingEditor, 2.5f, 1.4f, cGridColor);

				SystemGrid.DefineSystemVoucherGridColumn(grdPrintTask, "LN", 400, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false);
				//If GetSystemPreferenceSetting("enable_pos_counter") = True Then
				SystemGrid.DefineSystemVoucherGridColumn(grdPrintTask, "POS Counter", 1000, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, true, true, "cmbPrintList", false, false);
				//End If
				SystemGrid.DefineSystemVoucherGridColumn(grdPrintTask, "Report", 1200, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, true, false, "cmbPrintList", false, true, false, false, false, false, 200);
				SystemGrid.DefineSystemVoucherGridColumn(grdPrintTask, "Printer", 1500, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, true, false, "cmbPrintList", false, true, false, false, false, false, 200);
				SystemGrid.DefineSystemVoucherGridColumn(grdPrintTask, "Enable On Save", 700, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Center, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, true, false, true);
				SystemGrid.DefineSystemVoucherGridColumn(grdPrintTask, "Enable On Edit", 700, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Center, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, true, false, true);
				SystemGrid.DefineSystemVoucherGridColumn(grdPrintTask, "Prompt for Print", 700, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Center, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, true, false, true);
				SystemGrid.DefineSystemVoucherGridColumn(grdPrintTask, "Show Option", 700, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Center, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, true, false, true);
				SystemGrid.DefineSystemVoucherGridColumn(grdPrintTask, "Show Preview", 700, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Center, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, true, false, true);
				SystemGrid.DefineSystemVoucherGridColumn(grdPrintTask, "Show Printer", 700, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Center, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, true, false, true);
				SystemGrid.DefineSystemVoucherGridColumn(grdPrintTask, "Default Select", 700, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Center, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, true, false, true);

				grdPrintTask.Columns[grdAutoPrintColumn].ValueItems.DataColumn.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.CheckBox;
				grdPrintTask.Columns[grdEnablePrintOnEditColumn].ValueItems.DataColumn.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.CheckBox;
				grdPrintTask.Columns[grdPromptForPrintColumn].ValueItems.DataColumn.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.CheckBox;
				grdPrintTask.Columns[grdShowOptionColumn].ValueItems.DataColumn.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.CheckBox;
				grdPrintTask.Columns[grdShowPreviewColumn].ValueItems.DataColumn.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.CheckBox;
				grdPrintTask.Columns[grdShowPrinterColumn].ValueItems.DataColumn.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.CheckBox;
				grdPrintTask.Columns[grdDefaultSelectColumn].ValueItems.DataColumn.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.CheckBox;


				//Assign the Image for the toolbar
				//Imagelist are kept on the main form and refered by their key
				//Call DrawToolbar(Me, picFormToolbar, btnFormToolBar(0))
				//Set btnFormToolBar(0).Picture = frmSysMain.imlMainToolBar.ListImages("imgNew").Picture
				//Set btnFormToolBar(1).Picture = frmSysMain.imlMainToolBar.ListImages("imgSave").Picture
				//Set btnFormToolBar(2).Picture = frmSysMain.imlMainToolBar.ListImages("imgDelete").Picture
				//Set btnFormToolBar(3).Picture = frmSysMain.imlMainToolBar.ListImages("imgPrint").Picture
				//Set btnFormToolBar(4).Picture = frmSysMain.imlMainToolBar.ListImages("imgFind").Picture
				//Set btnFormToolBar(5).Picture = frmSysMain.imlMainToolBar.ListImages("imgHelp").Picture
				//Set btnFormToolBar(6).Picture = frmSysMain.imlMainToolBar.ListImages("imgExit").Picture

				GetNextNumber();

				ShowPrintingDetailsTab();

				cmbControl[cSingleEntryType].AddItem(cDrCaption);
				cmbControl[cSingleEntryType].AddItem(cCrCaption);

				cmbControl[cDefaultDrCrType].AddItem(cDrCaption);
				cmbControl[cDefaultDrCrType].AddItem(cCrCaption);

				cmbControl[cVoucherNoMethod].AddItem(cAutomatic);
				cmbControl[cVoucherNoMethod].AddItem(cManual);

				tabGLVoucherType.CurrTab = 0;
				AddRecord();
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
				if (KeyCode == 13)
				{ //If enter key pressed send a tab key
					SendKeys.Send("{TAB}");
					return;
				}
				if (this.ActiveControl.Name == "txtControl")
				{
					SystemForms.SystemFormKeyDown(this, ref KeyCode, Shift, "txtControl#" + ControlArrayHelper.GetControlIndex(this.ActiveControl).ToString().Trim());
				}
				else
				{
					SystemForms.SystemFormKeyDown(this, ref KeyCode, Shift);
				}
			}
			finally
			{
				eventArgs.Handled = KeyCode == 0;
			}
		}

		public void AddRecord()
		{
			//Add a record
			SystemProcedure2.ClearTextBox(this);
			SystemProcedure2.ClearCheckBox(this);
			GetNextNumber();

			mCurrentFormMode = SystemVariables.SystemFormModes.frmAddMode; //Change the form mode to addmode
			mSearchValue = ""; //Change the msearchvalue to blank

			chkControl[cShowLineNo].CheckState = CheckState.Checked;
			chkControl[cShowDrCrType].CheckState = CheckState.Checked;
			chkControl[cShowLdgrCd].CheckState = CheckState.Checked;
			chkControl[cShowLdgrName].CheckState = CheckState.Checked;
			chkControl[cShowCurrency].CheckState = CheckState.Checked;
			chkControl[cShowDrAmt].CheckState = CheckState.Checked;
			chkControl[cShowCrAmt].CheckState = CheckState.Checked;
			chkControl[cShowCostCenter].CheckState = CheckState.Checked;
			chkControl[cShowSalesman].CheckState = CheckState.Checked;
			chkControl[cShowRemarksInDetails].CheckState = CheckState.Checked;
			chkControl[cShowRemarksInHeader].CheckState = CheckState.Checked;
			chkControl[cShowAdditionalLedgerDetails].CheckState = CheckState.Checked;
			chkControl[cShowVoucherAdjustment].CheckState = CheckState.Checked;
			chkControl[cAllowListingOfLdgrCd].CheckState = CheckState.Checked;
			chkControl[cAllowListingOfLdgrName].CheckState = CheckState.Checked;
			chkControl[cAutoGenerateVoucherNo].CheckState = CheckState.Unchecked;
			chkControl[cPrintAfterSave].CheckState = CheckState.Unchecked;
			chkControl[cShowPrintPreviewFirst].CheckState = CheckState.Unchecked;
			chkControl[cShowPageSetupFirst].CheckState = CheckState.Unchecked;
			chkControl[cClosePreviewWindowsAfterPrint].CheckState = CheckState.Checked;
			chkControl[cShowinMenu].CheckState = CheckState.Unchecked;
			chkControl[cShow].CheckState = CheckState.Checked;
			chkControl[cProtected].CheckState = CheckState.Checked;
			chkControl[cShowFlex1InDetails].CheckState = CheckState.Unchecked;
			chkControl[cDisplayVoucherNoAfterSave].CheckState = CheckState.Checked;
			chkControl[cShowDefaultSalesmanInDetail].CheckState = CheckState.Unchecked;
			cmbControl[cDefaultDrCrType].Text = cDrCaption;
			cmbControl[cVoucherNoMethod].Text = cAutomatic;


			//. Date: 23/12/2007. To Add Additional Fields
			optCommonQtyEffect[cUseCrystalReports].Checked = true;
			optCommonAffectType[cPDCPaymentType].Checked = false;
			optCommonAffectType[cPDCReceiptType].Checked = false;

			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{
				tabGLVoucherType.CurrTab = 0;
				FirstFocusObject.Focus();

				return;

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, Information.Err().Description, this.Name, "AddRecord");
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		public bool saveRecord()
		{
			bool result = false;
			string mOppLdgrCd = "";

			//On Error GoTo eFoundError

			//Get the Parent Group Code
			//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode("select module_id from SM_MODULES where module_id=" + txtControl[cModuleId].Text));
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (Convert.IsDBNull(mReturnValue))
			{
				MessageBox.Show("Enter valid Module ID", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
				tabGLVoucherType.CurrTab = 0;
				txtControl[cModuleId].Focus();
				return false;
			}

			//Check lVoucherName
			string mysql = " select module_id from gl_accnt_voucher_types where l_voucher_name='" + txtControl[cLVoucherName].Text + "'";
			if (CurrentFormMode == SystemVariables.SystemFormModes.frmEditMode)
			{
				mysql = mysql + " and voucher_type<>" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
			}
			//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(mReturnValue))
			{
				MessageBox.Show("Duplicate Voucher Name", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
				tabGLVoucherType.CurrTab = 0;
				txtControl[cLVoucherName].Focus();
				return false;
			}

			//Check avoucher Name
			mysql = " select module_id from gl_accnt_voucher_types where a_voucher_name='" + txtControl[cAVoucherName].Text + "'";
			if (CurrentFormMode == SystemVariables.SystemFormModes.frmEditMode)
			{
				mysql = mysql + " and voucher_type<>" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
			}
			//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(mReturnValue))
			{
				MessageBox.Show("Duplicate Voucher Name", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
				tabGLVoucherType.CurrTab = 0;
				txtControl[cAVoucherName].Focus();
				return false;
			}

			//Check lshortvoucher Name
			mysql = " select module_id from gl_accnt_voucher_types where l_short_name='" + txtControl[cLShortName].Text + "'";
			if (CurrentFormMode == SystemVariables.SystemFormModes.frmEditMode)
			{
				mysql = mysql + " and voucher_type<>" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
			}
			//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(mReturnValue))
			{
				MessageBox.Show("Duplicate Voucher Name", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
				tabGLVoucherType.CurrTab = 0;
				txtControl[cLShortName].Focus();
				return false;
			}

			//Check ashortvoucher Name
			mysql = " select module_id from gl_accnt_voucher_types where a_short_name='" + txtControl[cAShortName].Text + "'";
			if (CurrentFormMode == SystemVariables.SystemFormModes.frmEditMode)
			{
				mysql = mysql + " and voucher_type<>" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
			}
			//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(mReturnValue))
			{
				MessageBox.Show("Duplicate Voucher Name", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
				tabGLVoucherType.CurrTab = 0;
				txtControl[cAShortName].Focus();
				return false;
			}


			if (chkControl[cAllowSingleEntry].CheckState == CheckState.Checked)
			{
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode("select ldgr_cd from gl_ledger where ldgr_no=" + txtControl[cOppositeLdgrCd].Text));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (Convert.IsDBNull(mReturnValue))
				{
					MessageBox.Show("Enter valid Leger Code", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
					tabGLVoucherType.CurrTab = 1;
					txtControl[cOppositeLdgrCd].Focus();
					return false;
				}
				else
				{
					//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mOppLdgrCd = ReflectionHelper.GetPrimitiveValue<string>(mReturnValue);
				}
			}


			SystemVariables.gConn.BeginTransaction();
			string mCheckTimeStamp = "";
			if (mCurrentFormMode == SystemVariables.SystemFormModes.frmAddMode)
			{
				mysql = " insert into gl_accnt_voucher_types( ";
				mysql = mysql + " voucher_type, module_id, op_voucher_type, l_voucher_name ";
				mysql = mysql + " , a_voucher_name , l_short_name, a_short_name,parent_type ";
				mysql = mysql + " , debit_filter_condition, credit_filter_condition ";
				mysql = mysql + " , allow_single_entry, single_entry_type, opposite_ldgr_cd ";
				mysql = mysql + " , show_opposite_ldgr_in_header, opposite_ldgr_header_caption";
				mysql = mysql + " , opposite_ldgr_cd_caption, opposite_ldgr_name_caption";
				mysql = mysql + " , adjust_difference_in_opposite_ldgr_cd, default_dr_cr_type";
				mysql = mysql + " , show_line_no";
				mysql = mysql + " , show_dr_cr_type, show_ldgr_cd, show_ldgr_name";
				mysql = mysql + " , show_currency, show_dr_amt, show_cr_amt, show_cost_center";
				mysql = mysql + " , show_salesman , show_remarks_in_details, show_remarks_in_header";
				mysql = mysql + " , show_additional_ledger_details, show_voucher_adjustment";
				mysql = mysql + " , allow_listing_of_ldgr_cd, allow_listing_of_ldgr_name";
				mysql = mysql + " , auto_generate_voucher_no, print_after_save";
				mysql = mysql + " , show_print_preview_first, show_page_setup_first";
				mysql = mysql + " , close_preview_windows_after_print, show_in_menu";
				mysql = mysql + " , used, show";
				//Modified By: Rizwan . 23/12/2007. For Additional Info Tab
				//---------------------------------------------------------
				mysql = mysql + " , Begin_With_Line_Seperator, Is_PDC_Receipt_Type, Is_PDC_Payment_Type";
				mysql = mysql + " , PDC_Generated_Linked_GL_Voucher_Type, Affect_GLS, Show_Maturity_Date, Show_Cheque_No";
				if (optCommonQtyEffect[cUseCrystalReports].Checked)
				{
					mysql = mysql + " , Use_Crystal_Reports_For_Print, Crystal_Report_Id_In_English";
					mysql = mysql + " , Report_Entry_Id_Column_In_English, Crystal_Report_Id_In_Arabic, Report_Entry_Id_Column_In_Arabic";
				}
				else if (optCommonQtyEffect[cUseXMLReports].Checked)
				{ 
					mysql = mysql + " , Use_Crystal_Reports_For_Print, Print_Voucher_Name";
				}
				mysql = mysql + " , Show_Flex_01_In_Header, Show_Cheque_No_In_Details, Show_Branch_Code_In_Header,Enable_Combo_List,Get_Max_New_Voucher_No";
				mysql = mysql + " ,feature_id, GL_Voucher_No_Generate_Method, GL_Voucher_No_Length, Show_Consignment_In_Details";
				mysql = mysql + " ,Show_Flex1_In_Details, Display_Voucher_No_After_Save, Show_Default_Salesman_In_Detail";
				//---------------------------------------------------------
				mysql = mysql + " , protected, comments, user_cd, find_id)";
				mysql = mysql + " values(";
				mysql = mysql + txtControl[cVoucherType].Text;
				mysql = mysql + "," + txtControl[cModuleId].Text;
				mysql = mysql + "," + ((int) chkControl[cOpVoucherType].CheckState).ToString();
				mysql = mysql + ",'" + txtControl[cLVoucherName].Text + "'";
				mysql = mysql + ", N'" + txtControl[cAVoucherName].Text + "'";
				mysql = mysql + ",'" + txtControl[cLShortName].Text + "'";
				mysql = mysql + ", N'" + txtControl[cAShortName].Text + "'";
				mysql = mysql + "," + txtControl[cVoucherType].Text;
				mysql = mysql + ", " + ((txtMultiLineControl[cDebitFilterCondition].Text == "") ? "Null" : "'" + txtMultiLineControl[cDebitFilterCondition].Text + "'");
				bool tempBool = false;
				string auxVar = txtMultiLineControl[cCreditFilterCondition].Text;
				mysql = mysql + ",'" + ((((Boolean.TryParse(auxVar, out tempBool)) ? tempBool : Convert.ToBoolean(Double.Parse(auxVar)))) ? "Null" : "'" + txtMultiLineControl[cCreditFilterCondition].Text + "'");
				if (chkControl[cAllowSingleEntry].CheckState == CheckState.Checked)
				{
					mysql = mysql + "," + ((int) chkControl[cAllowSingleEntry].CheckState).ToString();
					if (cmbControl[cSingleEntryType].Text == cCrCaption)
					{
						mysql = mysql + ",'C'";
					}
					else if (cmbControl[cSingleEntryType].Text == cDrCaption)
					{ 
						mysql = mysql + ",'D'";
					}
					else
					{
						MessageBox.Show("Enter Valid Entry Type ", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
						result = false;
						//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						SystemVariables.gConn.RollbackTrans();
						return result;
					}
					mysql = mysql + ",'" + mOppLdgrCd + "'";
					if (chkControl[cShowOppositeLdgrInHeader].CheckState == CheckState.Checked)
					{
						mysql = mysql + "," + ((int) chkControl[cShowOppositeLdgrInHeader].CheckState).ToString();
						mysql = mysql + ",'" + txtControl[cOppositeLdgrHeaderCaption].Text + "'";
						mysql = mysql + ",'" + txtControl[cOppositeLdgrCdCaption].Text + "'";
						mysql = mysql + ",'" + txtControl[cOppositeLdgrName].Text + "'";
					}
					else
					{
						mysql = mysql + ",0,NULL,NULL,NULL";
					}
				}
				else
				{
					mysql = mysql + ",0,NULL,NULL,0,NULL,NULL,NULL";
				}

				mysql = mysql + "," + ((int) chkControl[cAdjustDifferenceInOppositeLdgrCd].CheckState).ToString();

				if (cmbControl[cDefaultDrCrType].Text == cCrCaption)
				{
					mysql = mysql + ",'C'";
				}
				else if (cmbControl[cDefaultDrCrType].Text == cDrCaption)
				{ 
					mysql = mysql + ",'D'";
				}
				else
				{
					mysql = mysql + ",default";
				}

				mysql = mysql + "," + ((int) chkControl[cShowLineNo].CheckState).ToString();
				mysql = mysql + "," + ((int) chkControl[cShowDrCrType].CheckState).ToString();
				mysql = mysql + "," + ((int) chkControl[cShowLdgrCd].CheckState).ToString();
				mysql = mysql + "," + ((int) chkControl[cShowLdgrName].CheckState).ToString();
				mysql = mysql + "," + ((int) chkControl[cShowCurrency].CheckState).ToString();
				mysql = mysql + "," + ((int) chkControl[cShowDrAmt].CheckState).ToString();
				mysql = mysql + "," + ((int) chkControl[cShowCrAmt].CheckState).ToString();
				mysql = mysql + "," + ((int) chkControl[cShowCostCenter].CheckState).ToString();
				mysql = mysql + "," + ((int) chkControl[cShowSalesman].CheckState).ToString();
				mysql = mysql + "," + ((int) chkControl[cShowRemarksInDetails].CheckState).ToString();
				mysql = mysql + "," + ((int) chkControl[cShowRemarksInHeader].CheckState).ToString();
				mysql = mysql + "," + ((int) chkControl[cShowAdditionalLedgerDetails].CheckState).ToString();
				mysql = mysql + "," + ((int) chkControl[cShowVoucherAdjustment].CheckState).ToString();
				mysql = mysql + "," + ((int) chkControl[cAllowListingOfLdgrCd].CheckState).ToString();
				mysql = mysql + "," + ((int) chkControl[cAllowListingOfLdgrName].CheckState).ToString();
				mysql = mysql + "," + ((int) chkControl[cAutoGenerateVoucherNo].CheckState).ToString();
				mysql = mysql + "," + ((int) chkControl[cPrintAfterSave].CheckState).ToString();
				mysql = mysql + "," + ((int) chkControl[cShowPrintPreviewFirst].CheckState).ToString();
				mysql = mysql + "," + ((int) chkControl[cShowPageSetupFirst].CheckState).ToString();
				mysql = mysql + "," + ((int) chkControl[cClosePreviewWindowsAfterPrint].CheckState).ToString();
				mysql = mysql + "," + ((int) chkControl[cShowinMenu].CheckState).ToString();
				mysql = mysql + "," + ((int) chkControl[cUsed].CheckState).ToString();
				mysql = mysql + "," + ((int) chkControl[cShow].CheckState).ToString();
				// . 23/12/2007. For Additional Info Tab
				//---------------------------------------------------------
				mysql = mysql + "," + ((int) chkControl[cBeginWithLineSeperator].CheckState).ToString();
				mysql = mysql + "," + ((optCommonAffectType[cPDCReceiptType].Checked) ? 1 : 0).ToString();
				mysql = mysql + "," + ((optCommonAffectType[cPDCPaymentType].Checked) ? 1 : 0).ToString();
				mysql = mysql + "," + ((txtControl[cPDCGeneratedLinkedVoucherCd].Text == "") ? "Null" : txtControl[cPDCGeneratedLinkedVoucherCd].Text);
				mysql = mysql + "," + ((int) chkControl[cAffectGLS].CheckState).ToString();
				mysql = mysql + "," + ((int) chkControl[cShowMaturityDate].CheckState).ToString();
				mysql = mysql + "," + ((int) chkControl[cShowChequeNo].CheckState).ToString();
				if (optCommonQtyEffect[cUseCrystalReports].Checked)
				{
					mysql = mysql + " , 1," + ((txtControl[cCrystalReportsEngCd].Text == "") ? "Null" : txtControl[cCrystalReportsEngCd].Text);
					mysql = mysql + "," + ((txtControl[cEntryIdEngCd].Text == "") ? "Null" : txtControl[cEntryIdEngCd].Text);
					mysql = mysql + "," + ((txtControl[cCrystalReportsArCd].Text == "") ? "Null" : txtControl[cCrystalReportsArCd].Text);
					mysql = mysql + "," + ((txtControl[cEntryIdArCd].Text == "") ? "Null" : txtControl[cEntryIdArCd].Text);
				}
				else if (optCommonQtyEffect[cUseXMLReports].Checked)
				{ 
					mysql = mysql + " , 0," + txtCommon[cPrintVoucherName].Text;
				}
				mysql = mysql + "," + ((int) chkControl[cShowFlex1InHeader].CheckState).ToString();
				mysql = mysql + "," + ((int) chkControl[cShowChequeNoInDetails].CheckState).ToString();
				mysql = mysql + "," + ((int) chkControl[cShowBranchCdOnHeader].CheckState).ToString();
				mysql = mysql + "," + ((int) chkControl[cEnableComboList].CheckState).ToString();
				mysql = mysql + "," + ((int) chkControl[cGetMaxNewVoucherNo].CheckState).ToString();
				mysql = mysql + "," + ((txtControl[cPreferenceCd].Text == "") ? "1" : txtControl[cPreferenceCd].Text);

				if (cmbControl[cVoucherNoMethod].Text == cAutomatic)
				{
					mysql = mysql + ", 0";
				}
				else if (cmbControl[cVoucherNoMethod].Text == cManual)
				{ 
					mysql = mysql + ", 1";
				}
				else
				{
					mysql = mysql + ", default";
				}
				mysql = mysql + "," + txtNumber.Text;
				mysql = mysql + "," + ((int) chkControl[cShowConsignmentInDetails].CheckState).ToString();
				mysql = mysql + "," + ((int) chkControl[cShowFlex1InDetails].CheckState).ToString();
				mysql = mysql + "," + ((int) chkControl[cDisplayVoucherNoAfterSave].CheckState).ToString();
				mysql = mysql + "," + ((int) chkControl[cShowDefaultSalesmanInDetail].CheckState).ToString();
				//---------------------------------------------------------
				mysql = mysql + "," + ((int) chkControl[cProtected].CheckState).ToString();
				mysql = mysql + ",'" + txtControl[cComments].Text + "'";
				mysql = mysql + "," + SystemVariables.gLoggedInUserCode.ToString();
				if (SystemProcedure2.IsItEmpty(txtControl[cFindID].Text, SystemVariables.DataType.NumberType))
				{
					mysql = mysql + ",NULL)";
				}
				else
				{
					mysql = mysql + "," + txtControl[cFindID].Text + ")";
				}
				SqlCommand TempCommand = null;
				TempCommand = SystemVariables.gConn.CreateCommand();
				TempCommand.CommandText = mysql;
				TempCommand.ExecuteNonQuery();
			}
			else
			{
				//    Dim rsCheckTimeStamp As Recordset
				//    Set rsCheckTimeStamp = gConn.Execute("select time_stamp from SM_MODULES where voucher_type=" & mSearchValue)
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode("select time_stamp from gl_accnt_voucher_types where voucher_type=" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue)));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(mReturnValue))
				{
					//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mCheckTimeStamp = ReflectionHelper.GetPrimitiveValue<string>(mReturnValue);
				}
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (Convert.IsDBNull(mReturnValue) || (SystemProcedure2.tsFormat(mTimeStamp) != SystemProcedure2.tsFormat(mCheckTimeStamp)))
				{
					MessageBox.Show(SystemConstants.msg10, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					SystemVariables.gConn.RollbackTrans();
					result = false;
					FirstFocusObject.Focus();
					return result;
				}

				mysql = " update gl_accnt_voucher_types set ";
				mysql = mysql + "voucher_type =" + txtControl[cVoucherType].Text;
				mysql = mysql + ", module_id =" + txtControl[cModuleId].Text;
				mysql = mysql + ", op_voucher_type =" + ((int) chkControl[cOpVoucherType].CheckState).ToString();
				mysql = mysql + ", l_voucher_name ='" + txtControl[cLVoucherName].Text + "'";
				mysql = mysql + ", a_voucher_name = N'" + txtControl[cAVoucherName].Text + "'";
				mysql = mysql + ", l_short_name ='" + txtControl[cLShortName].Text + "'";
				mysql = mysql + ", a_short_name = N'" + txtControl[cAShortName].Text + "'";
				mysql = mysql + ", debit_filter_condition = " + ((txtMultiLineControl[cDebitFilterCondition].Text == "") ? "Null" : "'" + txtMultiLineControl[cDebitFilterCondition].Text + "'");
				mysql = mysql + ", credit_filter_condition = " + ((txtMultiLineControl[cCreditFilterCondition].Text == "") ? "Null" : "'" + txtMultiLineControl[cCreditFilterCondition].Text + "'");
				if (chkControl[cAllowSingleEntry].CheckState == CheckState.Checked)
				{
					mysql = mysql + ", allow_single_entry =" + ((int) chkControl[cAllowSingleEntry].CheckState).ToString();
					if (cmbControl[cSingleEntryType].Text == cCrCaption)
					{
						mysql = mysql + ", single_entry_type ='C'";
					}
					else if (cmbControl[cSingleEntryType].Text == cDrCaption)
					{ 
						mysql = mysql + ", single_entry_type ='D'";
					}
					else
					{
						MessageBox.Show("Enter Valid Entry Type ", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
						result = false;
						//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						SystemVariables.gConn.RollbackTrans();
						return result;
					}
					mysql = mysql + ", opposite_ldgr_cd ='" + mOppLdgrCd + "'";
					if (chkControl[cShowOppositeLdgrInHeader].CheckState == CheckState.Checked)
					{
						mysql = mysql + ", show_opposite_ldgr_in_header =" + ((int) chkControl[cShowOppositeLdgrInHeader].CheckState).ToString();
						mysql = mysql + ", opposite_ldgr_header_caption ='" + txtControl[cOppositeLdgrHeaderCaption].Text + "'";
						mysql = mysql + ", opposite_ldgr_cd_caption ='" + txtControl[cOppositeLdgrCdCaption].Text + "'";
						mysql = mysql + ", opposite_ldgr_name_caption ='" + txtControl[cOppositeLdgrName].Text + "'";
					}
					else
					{
						mysql = mysql + ", show_opposite_ldgr_in_header =0";
						mysql = mysql + ", opposite_ldgr_header_caption =NULL";
						mysql = mysql + ", opposite_ldgr_cd_caption =NULL";
						mysql = mysql + ", opposite_ldgr_name_caption =NULL";
					}
				}
				else
				{
					mysql = mysql + ", allow_single_entry =0";
					mysql = mysql + ", single_entry_type =default";
					mysql = mysql + ", opposite_ldgr_cd =NULL";
					mysql = mysql + ", show_opposite_ldgr_in_header =0";
					mysql = mysql + ", opposite_ldgr_header_caption =NULL";
					mysql = mysql + ", opposite_ldgr_cd_caption =NULL";
					mysql = mysql + ", opposite_ldgr_name_caption =NULL";
				}

				mysql = mysql + ", adjust_difference_in_opposite_ldgr_cd =" + ((int) chkControl[cAdjustDifferenceInOppositeLdgrCd].CheckState).ToString();
				if (cmbControl[cDefaultDrCrType].Text == cCrCaption)
				{
					mysql = mysql + ", default_dr_cr_type ='C'";
				}
				else if (cmbControl[cDefaultDrCrType].Text == cDrCaption)
				{ 
					mysql = mysql + ", default_dr_cr_type ='D'";
				}
				else
				{
					mysql = mysql + ",default";
				}
				mysql = mysql + ", show_line_no =" + ((int) chkControl[cShowLineNo].CheckState).ToString();
				mysql = mysql + ", show_dr_cr_type =" + ((int) chkControl[cShowDrCrType].CheckState).ToString();
				mysql = mysql + ", show_ldgr_cd =" + ((int) chkControl[cShowLdgrCd].CheckState).ToString();
				mysql = mysql + ", show_ldgr_name =" + ((int) chkControl[cShowLdgrName].CheckState).ToString();
				mysql = mysql + ", show_currency =" + ((int) chkControl[cShowCurrency].CheckState).ToString();
				mysql = mysql + ", show_dr_amt =" + ((int) chkControl[cShowDrAmt].CheckState).ToString();
				mysql = mysql + ", show_cr_amt =" + ((int) chkControl[cShowCrAmt].CheckState).ToString();
				mysql = mysql + ", show_cost_center =" + ((int) chkControl[cShowCostCenter].CheckState).ToString();
				mysql = mysql + ", show_salesman =" + ((int) chkControl[cShowSalesman].CheckState).ToString();
				mysql = mysql + ", show_remarks_in_details =" + ((int) chkControl[cShowRemarksInDetails].CheckState).ToString();
				mysql = mysql + ", show_remarks_in_header =" + ((int) chkControl[cShowRemarksInHeader].CheckState).ToString();
				mysql = mysql + ", show_additional_ledger_details =" + ((int) chkControl[cShowAdditionalLedgerDetails].CheckState).ToString();
				mysql = mysql + ", show_voucher_adjustment =" + ((int) chkControl[cShowVoucherAdjustment].CheckState).ToString();
				mysql = mysql + ", allow_listing_of_ldgr_cd =" + ((int) chkControl[cAllowListingOfLdgrCd].CheckState).ToString();
				mysql = mysql + ", allow_listing_of_ldgr_name =" + ((int) chkControl[cAllowListingOfLdgrName].CheckState).ToString();
				mysql = mysql + ", auto_generate_voucher_no =" + ((int) chkControl[cAutoGenerateVoucherNo].CheckState).ToString();
				mysql = mysql + ", print_after_save =" + ((int) chkControl[cPrintAfterSave].CheckState).ToString();
				mysql = mysql + ", show_print_preview_first =" + ((int) chkControl[cShowPrintPreviewFirst].CheckState).ToString();
				mysql = mysql + ", show_page_setup_first =" + ((int) chkControl[cShowPageSetupFirst].CheckState).ToString();
				mysql = mysql + ", close_preview_windows_after_print =" + ((int) chkControl[cClosePreviewWindowsAfterPrint].CheckState).ToString();
				mysql = mysql + ", show_in_menu =" + ((int) chkControl[cShowinMenu].CheckState).ToString();
				mysql = mysql + ", used =" + ((int) chkControl[cUsed].CheckState).ToString();
				mysql = mysql + ", show =" + ((int) chkControl[cShow].CheckState).ToString();
				// . 23/12/2007. For Additional Info Tab
				//---------------------------------------------------------
				mysql = mysql + ", Begin_With_Line_Seperator =" + ((int) chkControl[cBeginWithLineSeperator].CheckState).ToString();
				mysql = mysql + ", Is_PDC_Receipt_Type =" + ((optCommonAffectType[cPDCReceiptType].Checked) ? 1 : 0).ToString();
				mysql = mysql + ", Is_PDC_Payment_Type =" + ((optCommonAffectType[cPDCPaymentType].Checked) ? 1 : 0).ToString();
				mysql = mysql + ", PDC_Generated_Linked_GL_Voucher_Type =" + ((txtControl[cPDCGeneratedLinkedVoucherCd].Text == "") ? "Null" : txtControl[cPDCGeneratedLinkedVoucherCd].Text);
				mysql = mysql + ", Affect_GLS =" + ((int) chkControl[cAffectGLS].CheckState).ToString();
				mysql = mysql + ", Show_Maturity_Date =" + ((int) chkControl[cShowMaturityDate].CheckState).ToString();
				mysql = mysql + ", Show_Cheque_No =" + ((int) chkControl[cShowChequeNo].CheckState).ToString();
				if (optCommonQtyEffect[cUseCrystalReports].Checked)
				{
					mysql = mysql + ", Use_Crystal_Reports_For_Print=1";
					mysql = mysql + ", Crystal_Report_Id_In_English =" + ((txtControl[cCrystalReportsEngCd].Text == "") ? "Null" : txtControl[cCrystalReportsEngCd].Text);
					mysql = mysql + ", Report_Entry_Id_Column_In_English =" + ((txtControl[cEntryIdEngCd].Text == "") ? "Null" : txtControl[cEntryIdEngCd].Text);
					mysql = mysql + ", Crystal_Report_Id_In_arabic =" + ((txtControl[cCrystalReportsArCd].Text == "") ? "Null" : txtControl[cCrystalReportsArCd].Text);
					mysql = mysql + ", Report_Entry_Id_Column_In_arabic =" + ((txtControl[cEntryIdArCd].Text == "") ? "Null" : txtControl[cEntryIdArCd].Text);
				}
				else if (optCommonQtyEffect[cUseXMLReports].Checked)
				{ 
					mysql = mysql + ", Use_Crystal_Reports_For_Print=0";
					mysql = mysql + ", Print_Voucher_Name = '" + txtCommon[cPrintVoucherName].Text + "'";
				}
				mysql = mysql + ", Show_Flex_01_In_Header =" + ((int) chkControl[cShowFlex1InHeader].CheckState).ToString();
				mysql = mysql + ", Show_Cheque_No_In_Details =" + ((int) chkControl[cShowChequeNoInDetails].CheckState).ToString();
				mysql = mysql + ", Show_Branch_Code_In_Header =" + ((int) chkControl[cShowBranchCdOnHeader].CheckState).ToString();
				mysql = mysql + ", Enable_Combo_List =" + ((int) chkControl[cEnableComboList].CheckState).ToString();
				mysql = mysql + ", Get_Max_New_Voucher_No =" + ((int) chkControl[cGetMaxNewVoucherNo].CheckState).ToString();
				mysql = mysql + ", feature_id =" + ((txtControl[cPreferenceCd].Text == "") ? "Null" : txtControl[cPreferenceCd].Text);

				if (cmbControl[cVoucherNoMethod].Text == cAutomatic)
				{
					mysql = mysql + ", GL_Voucher_No_Generate_Method = 0";
				}
				else if (cmbControl[cVoucherNoMethod].Text == cManual)
				{ 
					mysql = mysql + ", GL_Voucher_No_Generate_Method = 1";
				}
				mysql = mysql + ", GL_Voucher_No_Length = " + ((txtNumber.Text == "") ? " 0" : txtNumber.Text);
				mysql = mysql + ", Show_Consignment_In_Details = " + ((int) chkControl[cShowConsignmentInDetails].CheckState).ToString();
				mysql = mysql + ", Show_Flex1_In_Details = " + ((int) chkControl[cShowFlex1InDetails].CheckState).ToString();
				mysql = mysql + ", Display_Voucher_No_After_Save = " + ((int) chkControl[cDisplayVoucherNoAfterSave].CheckState).ToString();
				mysql = mysql + ", Show_Default_Salesman_In_Detail = " + ((int) chkControl[cShowDefaultSalesmanInDetail].CheckState).ToString();
				//---------------------------------------------------------
				mysql = mysql + ", protected =" + ((int) chkControl[cProtected].CheckState).ToString();
				mysql = mysql + ", comments ='" + txtControl[cComments].Text + "'";
				mysql = mysql + ", user_cd =" + SystemVariables.gLoggedInUserCode.ToString();
				if (SystemProcedure2.IsItEmpty(txtControl[cFindID].Text, SystemVariables.DataType.NumberType))
				{
					mysql = mysql + ", find_id =NULL";
				}
				else
				{
					mysql = mysql + ", find_id =" + txtControl[cFindID].Text;
				}
				mysql = mysql + " where voucher_type=" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);

				SqlCommand TempCommand_2 = null;
				TempCommand_2 = SystemVariables.gConn.CreateCommand();
				TempCommand_2.CommandText = mysql;
				TempCommand_2.ExecuteNonQuery();
			}
			//**--This procedure is for insert Report detail information

			int cnt = 0;
			if (aReportDetails.GetLength(0) > 0)
			{
				this.grdPrintTask.UpdateData();
				mysql = "delete GL_Print_Task_Detail ";
				mysql = mysql + " where ";
				mysql = mysql + " Voucher_Type = " + Conversion.Str(mSearchValue);
				SqlCommand TempCommand_3 = null;
				TempCommand_3 = SystemVariables.gConn.CreateCommand();
				TempCommand_3.CommandText = mysql;
				TempCommand_3.ExecuteNonQuery();
				int tempForEndVar = aReportDetails.GetLength(0) - 1;
				for (cnt = 0; cnt <= tempForEndVar; cnt++)
				{

					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (Convert.IsDBNull(aReportDetails.GetValue(cnt, grdReportColumn)) || Convert.ToString(aReportDetails.GetValue(cnt, grdReportColumn)) == "")
					{
						MessageBox.Show("Invalid Report ID", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
						grdPrintTask.Col = grdReportColumn;
						goto eFoundError;
					}
					else
					{

						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
						mPOS = (Convert.IsDBNull(aReportDetails.GetValue(cnt, grdPOSColumn))) ? 0 : Convert.ToInt32(aReportDetails.GetValue(cnt, grdPOSColumn));
						mReport_Id = Convert.ToInt32(aReportDetails.GetValue(cnt, grdReportColumn));
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
						mPrinter_Name = (Convert.IsDBNull(aReportDetails.GetValue(cnt, grdPrinterColumn))) ? "" : Convert.ToString(aReportDetails.GetValue(cnt, grdPrinterColumn));
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
						mAuto_Print = (Convert.IsDBNull(aReportDetails.GetValue(cnt, grdAutoPrintColumn))) ? 0 : Convert.ToInt32(aReportDetails.GetValue(cnt, grdAutoPrintColumn));
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
						mEnable_Print_Edit = (Convert.IsDBNull(aReportDetails.GetValue(cnt, grdEnablePrintOnEditColumn))) ? 0 : Convert.ToInt32(aReportDetails.GetValue(cnt, grdEnablePrintOnEditColumn));
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
						mPrompt_For_Print = (Convert.IsDBNull(aReportDetails.GetValue(cnt, grdPromptForPrintColumn))) ? 0 : Convert.ToInt32(aReportDetails.GetValue(cnt, grdPromptForPrintColumn));
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
						mShow_Option = (Convert.IsDBNull(aReportDetails.GetValue(cnt, grdShowOptionColumn))) ? 0 : Convert.ToInt32(aReportDetails.GetValue(cnt, grdShowOptionColumn));
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
						mShow_Preview = (Convert.IsDBNull(aReportDetails.GetValue(cnt, grdShowPreviewColumn))) ? 0 : Convert.ToInt32(aReportDetails.GetValue(cnt, grdShowPreviewColumn));
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
						mShow_Printer = (Convert.IsDBNull(aReportDetails.GetValue(cnt, grdShowPrinterColumn))) ? 0 : Convert.ToInt32(aReportDetails.GetValue(cnt, grdShowPrinterColumn));
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
						mDefault_Select = (Convert.IsDBNull(aReportDetails.GetValue(cnt, grdDefaultSelectColumn))) ? 0 : Convert.ToInt32(aReportDetails.GetValue(cnt, grdDefaultSelectColumn));


						mysql = "insert into GL_Print_Task_Detail ";
						mysql = mysql + " ( Voucher_Type, Report_Id, POS_Counter_Cd, Printer_Path,";
						mysql = mysql + " Auto_Print_After_Save, enable_print_on_edit, Prompt_For_Print_After_Save, Show_Option, Show_Preview";
						mysql = mysql + " , Show_Printer, default_Select, user_cd) ";
						mysql = mysql + " values ( ";
						mysql = mysql + Conversion.Str(mSearchValue) + ",";
						mysql = mysql + Conversion.Str(mReport_Id) + ",";
						if (mPOS != 0)
						{
							mysql = mysql + Conversion.Str(mPOS) + ",";
						}
						else
						{
							mysql = mysql + "Null ,";
						}
						mysql = mysql + "'" + mPrinter_Name + "',";
						mysql = mysql + Conversion.Str(mAuto_Print) + ",";
						mysql = mysql + Conversion.Str(mEnable_Print_Edit) + ",";
						mysql = mysql + Conversion.Str(mPrompt_For_Print) + ",";
						mysql = mysql + Conversion.Str(mShow_Option) + ",";
						mysql = mysql + Conversion.Str(mShow_Preview) + ",";
						mysql = mysql + Conversion.Str(mShow_Printer) + ",";
						mysql = mysql + Conversion.Str(mDefault_Select) + ",";
						mysql = mysql + Conversion.Str(SystemVariables.gLoggedInUserCode) + ")";

						SqlCommand TempCommand_4 = null;
						TempCommand_4 = SystemVariables.gConn.CreateCommand();
						TempCommand_4.CommandText = mysql;
						TempCommand_4.ExecuteNonQuery();
					}

				}
			}
			//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.CommitTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			SystemVariables.gConn.CommitTrans();
			result = true;
			tabGLVoucherType.CurrTab = 0;
			FirstFocusObject.Focus();
			return result;

			eFoundError:
			int mReturnErrorType = 0;
			//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
			mReturnErrorType = SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, Information.Err().Description, this.Name, "GetRecord", SystemConstants.msg10);
			//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			SystemVariables.gConn.RollbackTrans();
			return false;
		}

		public bool deleteRecord()
		{
			bool result = false;
			string mysql = "";
			object mReturnValue = null;
			//Delete the Record
			try
			{

				mysql = "select top 1 entry_id from gl_accnt_trans  where voucher_type=" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(mReturnValue))
				{
					MessageBox.Show("Accounts Transaction exists, cannot delete the Voucher Type", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					return false;
				}

				mysql = "select protected from gl_accnt_voucher_types where voucher_type=" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
				if (ReflectionHelper.GetPrimitiveValue<bool>(mReturnValue))
				{
					MessageBox.Show(SystemConstants.msg12, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return false;
				}

				mysql = " delete from gl_accnt_voucher_types where voucher_type=" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
				SqlCommand TempCommand = null;
				TempCommand = SystemVariables.gConn.CreateCommand();
				TempCommand.CommandText = mysql;
				TempCommand.ExecuteNonQuery();

				return true;
			}
			catch (System.Exception excep)
			{
				int mReturnErrorType = 0;
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				mReturnErrorType = SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, excep.Message, this.Name, "GetRecord", SystemConstants.msg10);
				FirstFocusObject.Focus();
				result = false;
			}
			return result;
		}

		public void GetRecord(object pSearchValue)
		{
			SqlDataReader rsLocalRec = null;
			object mReturnValue = null;


			if (SystemProcedure2.IsItEmpty(pSearchValue, SystemVariables.DataType.NumberType))
			{
				return;
			}

			//On Error GoTo eFoundError
			SystemProcedure2.ClearTextBox(this);
			SystemProcedure2.ClearCheckBox(this);
			//UPGRADE_WARNING: (1068) pSearchValue of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			mRecordNavigateSearchValue = ReflectionHelper.GetPrimitiveValue(pSearchValue);
			string mysql = " select * from gl_accnt_voucher_types where voucher_type=" + ReflectionHelper.GetPrimitiveValue<string>(pSearchValue);
			SqlCommand sqlCommand = new SqlCommand(mysql, SystemVariables.gConn);
			rsLocalRec = sqlCommand.ExecuteReader();
			if (rsLocalRec.Read())
			{
				mSearchValue = rsLocalRec["voucher_type"];
				mTimeStamp = Convert.ToString(rsLocalRec["time_stamp"]);
				txtControl[cVoucherType].Text = Convert.ToString(rsLocalRec["voucher_type"]);

				mysql = "select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_group_name" : "a_group_name");
				mysql = mysql + " ,module_id from SM_MODULES ";
				mysql = mysql + " Where module_id =" + Convert.ToString(rsLocalRec["Module_Id"]);
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(mReturnValue))
				{
					//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					txtControl[cModuleId].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(1));
					//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					txtControl[cModuleName].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(0));
				}

				txtControl[cLVoucherName].Text = Convert.ToString(rsLocalRec["L_Voucher_Name"]);
				txtControl[cAVoucherName].Text = Convert.ToString(rsLocalRec["A_Voucher_Name"]);
				txtControl[cLShortName].Text = Convert.ToString(rsLocalRec["L_Short_Name"]);
				txtControl[cAShortName].Text = Convert.ToString(rsLocalRec["A_Short_Name"]);
				txtMultiLineControl[cDebitFilterCondition].Text = Convert.ToString(rsLocalRec["Debit_Filter_Condition"]) + "";
				txtMultiLineControl[cCreditFilterCondition].Text = Convert.ToString(rsLocalRec["Credit_Filter_Condition"]) + "";


				if (Convert.ToString(rsLocalRec["Single_Entry_Type"]) == "C")
				{
					cmbControl[cSingleEntryType].Text = cCrCaption;
				}
				else if (Convert.ToString(rsLocalRec["Single_Entry_Type"]) == "D")
				{ 
					cmbControl[cSingleEntryType].Text = cDrCaption;
				}
				else
				{
					cmbControl[cSingleEntryType].ListIndex = -1;
				}

				if (Convert.ToString(rsLocalRec["Default_Dr_Cr_Type"]) == "C")
				{
					cmbControl[cDefaultDrCrType].Text = cCrCaption;
				}
				else if (Convert.ToString(rsLocalRec["Default_Dr_Cr_Type"]) == "D")
				{ 
					cmbControl[cDefaultDrCrType].Text = cDrCaption;
				}
				else
				{
					cmbControl[cDefaultDrCrType].ListIndex = -1;
				}




				mysql = "select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_ldgr_name" : "a_ldgr_name");
				mysql = mysql + " ,ldgr_no from gl_ledger where ldgr_cd='" + Convert.ToString(rsLocalRec["Opposite_Ldgr_Cd"]) + "'";
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(mReturnValue))
				{
					//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					txtControl[cOppositeLdgrCd].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(1));
					//UPGRADE_WARNING: (1068) mReturnValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					txtControl[cOppositeLdgrName].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(0));
				}

				txtControl[cOppositeLdgrHeaderCaption].Text = Convert.ToString(rsLocalRec["Opposite_Ldgr_Header_Caption"]) + "";
				txtControl[cOppositeLdgrCdCaption].Text = Convert.ToString(rsLocalRec["Opposite_Ldgr_Cd_Caption"]) + "";
				txtControl[cOppositeLdgrNameCaption].Text = Convert.ToString(rsLocalRec["Opposite_Ldgr_Name_Caption"]) + "";

				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				chkControl[cShowOppositeLdgrInHeader].CheckState = (CheckState) ((Convert.ToBoolean(rsLocalRec["Show_Opposite_Ldgr_In_Header"])) ? 1 : 0);
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				chkControl[cOpVoucherType].CheckState = (CheckState) ((Convert.ToBoolean(rsLocalRec["Op_Voucher_Type"])) ? 1 : 0);
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				chkControl[cAllowSingleEntry].CheckState = (CheckState) ((Convert.ToBoolean(rsLocalRec["Allow_Single_Entry"])) ? 1 : 0);
				Frame4.Enabled = Convert.ToBoolean(rsLocalRec["Allow_Single_Entry"]);

				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				chkControl[cAdjustDifferenceInOppositeLdgrCd].CheckState = (CheckState) ((Convert.ToBoolean(rsLocalRec["Adjust_Difference_In_Opposite_Ldgr_Cd"])) ? 1 : 0);
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				chkControl[cShowLineNo].CheckState = (CheckState) ((Convert.ToBoolean(rsLocalRec["Show_Line_No"])) ? 1 : 0);
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				chkControl[cShowDrCrType].CheckState = (CheckState) ((Convert.ToBoolean(rsLocalRec["Show_Dr_Cr_Type"])) ? 1 : 0);
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				chkControl[cShowLdgrCd].CheckState = (CheckState) ((Convert.ToBoolean(rsLocalRec["Show_Ldgr_Cd"])) ? 1 : 0);
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				chkControl[cShowLdgrName].CheckState = (CheckState) ((Convert.ToBoolean(rsLocalRec["Show_Ldgr_Name"])) ? 1 : 0);
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				chkControl[cShowCurrency].CheckState = (CheckState) ((Convert.ToBoolean(rsLocalRec["Show_Currency"])) ? 1 : 0);
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				chkControl[cShowDrAmt].CheckState = (CheckState) ((Convert.ToBoolean(rsLocalRec["Show_Dr_Amt"])) ? 1 : 0);
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				chkControl[cShowCrAmt].CheckState = (CheckState) ((Convert.ToBoolean(rsLocalRec["Show_Cr_Amt"])) ? 1 : 0);
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				chkControl[cShowCostCenter].CheckState = (CheckState) ((Convert.ToBoolean(rsLocalRec["Show_Cost_Center"])) ? 1 : 0);
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				chkControl[cShowSalesman].CheckState = (CheckState) ((Convert.ToBoolean(rsLocalRec["Show_Salesman"])) ? 1 : 0);
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				chkControl[cShowRemarksInDetails].CheckState = (CheckState) ((Convert.ToBoolean(rsLocalRec["Show_Remarks_In_Details"])) ? 1 : 0);
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				chkControl[cShowRemarksInHeader].CheckState = (CheckState) ((Convert.ToBoolean(rsLocalRec["Show_Remarks_In_Header"])) ? 1 : 0);
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				chkControl[cShowAdditionalLedgerDetails].CheckState = (CheckState) ((Convert.ToBoolean(rsLocalRec["Show_Additional_Ledger_Details"])) ? 1 : 0);
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				chkControl[cShowVoucherAdjustment].CheckState = (CheckState) ((Convert.ToBoolean(rsLocalRec["Show_Voucher_Adjustment"])) ? 1 : 0);
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				chkControl[cAllowListingOfLdgrCd].CheckState = (CheckState) ((Convert.ToBoolean(rsLocalRec["Allow_Listing_Of_Ldgr_Cd"])) ? 1 : 0);
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				chkControl[cAllowListingOfLdgrName].CheckState = (CheckState) ((Convert.ToBoolean(rsLocalRec["Allow_Listing_Of_Ldgr_Name"])) ? 1 : 0);
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				chkControl[cAutoGenerateVoucherNo].CheckState = (CheckState) ((Convert.ToBoolean(rsLocalRec["Auto_Generate_Voucher_No"])) ? 1 : 0);
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				chkControl[cPrintAfterSave].CheckState = (CheckState) ((Convert.ToBoolean(rsLocalRec["Print_After_Save"])) ? 1 : 0);
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				chkControl[cShowPrintPreviewFirst].CheckState = (CheckState) ((Convert.ToBoolean(rsLocalRec["Show_Print_Preview_First"])) ? 1 : 0);
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				chkControl[cShowPageSetupFirst].CheckState = (CheckState) ((Convert.ToBoolean(rsLocalRec["Show_Page_Setup_First"])) ? 1 : 0);
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				chkControl[cClosePreviewWindowsAfterPrint].CheckState = (CheckState) ((Convert.ToBoolean(rsLocalRec["Close_Preview_Windows_After_Print"])) ? 1 : 0);
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				chkControl[cShowinMenu].CheckState = (CheckState) ((Convert.ToBoolean(rsLocalRec["Show_in_Menu"])) ? 1 : 0);
				txtControl[cLastDebitLdgrCd].Text = Convert.ToString(rsLocalRec["Last_Debit_Ldgr_Cd"]) + "";
				txtControl[cLastCreditLdgrCd].Text = Convert.ToString(rsLocalRec["Last_Credit_Ldgr_Cd"]) + "";
				txtControl[cLastCostCd].Text = Convert.ToString(rsLocalRec["Last_Cost_Cd"]) + "";
				txtControl[cLastSmanCd].Text = Convert.ToString(rsLocalRec["Last_Sman_Cd"]) + "";
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				chkControl[cUsed].CheckState = (CheckState) ((Convert.ToBoolean(rsLocalRec["Used"])) ? 1 : 0);
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				chkControl[cShow].CheckState = (CheckState) ((Convert.ToBoolean(rsLocalRec["Show"])) ? 1 : 0);
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				chkControl[cProtected].CheckState = (CheckState) ((Convert.ToBoolean(rsLocalRec["Protected"])) ? 1 : 0);
				txtControl[cComments].Text = Convert.ToString(rsLocalRec["Comments"]) + "";
				if (Convert.IsDBNull(rsLocalRec["Find_Id"]))
				{
					txtControl[cFindID].Text = "";
				}
				else
				{
					txtControl[cFindID].Text = Convert.ToString(rsLocalRec["Find_Id"]);
				}
				//Added By:Rizwan Date:26/12/2007. For Additional Info tab
				//--------------------------------------------------------
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				chkControl[cBeginWithLineSeperator].CheckState = (CheckState) ((Convert.ToBoolean(rsLocalRec["Begin_With_Line_Seperator"])) ? 1 : 0);
				optCommonAffectType[cPDCReceiptType].Checked = Convert.ToBoolean(rsLocalRec["Is_PDC_Receipt_Type"]);
				optCommonAffectType[cPDCPaymentType].Checked = Convert.ToBoolean(rsLocalRec["Is_PDC_Payment_Type"]);
				txtControl[cPDCGeneratedLinkedVoucherCd].Text = (Convert.IsDBNull(rsLocalRec["PDC_Generated_Linked_GL_Voucher_Type"])) ? "" : Convert.ToString(rsLocalRec["PDC_Generated_Linked_GL_Voucher_Type"]);
				txtControl_Leave(txtControl[cPDCGeneratedLinkedVoucherCd], new EventArgs());
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				chkControl[cAffectGLS].CheckState = (CheckState) ((Convert.ToBoolean(rsLocalRec["Affect_GLS"])) ? 1 : 0);
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				chkControl[cShowMaturityDate].CheckState = (CheckState) ((Convert.ToBoolean(rsLocalRec["Show_Maturity_Date"])) ? 1 : 0);
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				chkControl[cShowChequeNo].CheckState = (CheckState) ((Convert.ToBoolean(rsLocalRec["Show_Cheque_No"])) ? 1 : 0);
				if (Convert.ToBoolean(rsLocalRec["Use_Crystal_Reports_For_Print"]))
				{
					optCommonQtyEffect[cUseCrystalReports].Checked = true;
					txtControl[cCrystalReportsEngCd].Text = (Convert.IsDBNull(rsLocalRec["Crystal_Report_Id_In_English"])) ? "" : Convert.ToString(rsLocalRec["Crystal_Report_Id_In_English"]);
					txtControl_Leave(txtControl[cCrystalReportsEngCd], new EventArgs());
					txtControl[cEntryIdEngCd].Text = (Convert.IsDBNull(rsLocalRec["Report_Entry_Id_Column_In_English"])) ? "" : Convert.ToString(rsLocalRec["Report_Entry_Id_Column_In_English"]);
					txtControl_Leave(txtControl[cEntryIdEngCd], new EventArgs());
					txtControl[cCrystalReportsArCd].Text = (Convert.IsDBNull(rsLocalRec["Crystal_Report_Id_In_arabic"])) ? "" : Convert.ToString(rsLocalRec["Crystal_Report_Id_In_arabic"]);
					txtControl_Leave(txtControl[cCrystalReportsArCd], new EventArgs());
					txtControl[cEntryIdArCd].Text = (Convert.IsDBNull(rsLocalRec["Report_Entry_Id_Column_In_arabic"])) ? "" : Convert.ToString(rsLocalRec["Report_Entry_Id_Column_In_arabic"]);
					txtControl_Leave(txtControl[cEntryIdArCd], new EventArgs());
				}
				else
				{
					optCommonQtyEffect[cUseXMLReports].Checked = true;
					txtCommon[cPrintVoucherName].Text = (Convert.IsDBNull(rsLocalRec["Print_Voucher_Name"])) ? "" : Convert.ToString(rsLocalRec["Print_Voucher_Name"]);
				}
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				chkControl[cShowFlex1InHeader].CheckState = (CheckState) ((Convert.ToBoolean(rsLocalRec["Show_Flex_01_In_Header"])) ? 1 : 0);
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				chkControl[cShowChequeNoInDetails].CheckState = (CheckState) ((Convert.ToBoolean(rsLocalRec["Show_Cheque_No_In_Details"])) ? 1 : 0);
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				chkControl[cShowBranchCdOnHeader].CheckState = (CheckState) ((Convert.ToBoolean(rsLocalRec["Show_Branch_Code_In_Header"])) ? 1 : 0);
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				chkControl[cEnableComboList].CheckState = (CheckState) ((Convert.ToBoolean(rsLocalRec["Enable_Combo_List"])) ? 1 : 0);
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				chkControl[cGetMaxNewVoucherNo].CheckState = (CheckState) ((Convert.ToBoolean(rsLocalRec["Get_Max_New_Voucher_No"])) ? 1 : 0);
				if (Convert.ToDouble(rsLocalRec["GL_Voucher_No_Generate_Method"]) == 0)
				{
					cmbControl[cVoucherNoMethod].Text = cAutomatic;
				}
				else if (Convert.ToDouble(rsLocalRec["GL_Voucher_No_Generate_Method"]) == 1)
				{ 
					cmbControl[cVoucherNoMethod].Text = cManual;
				}
				else
				{
					cmbControl[cVoucherNoMethod].ListIndex = -1;
				}
				txtNumber.Text = (Convert.IsDBNull(rsLocalRec["GL_Voucher_No_Length"])) ? "0" : Convert.ToString(rsLocalRec["GL_Voucher_No_Length"]);
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				chkControl[cShowConsignmentInDetails].CheckState = (CheckState) ((Convert.ToBoolean(rsLocalRec["Show_Consignment_In_Details"])) ? 1 : 0);
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				chkControl[cShowFlex1InDetails].CheckState = (CheckState) ((Convert.ToBoolean(rsLocalRec["Show_Flex1_In_Details"])) ? 1 : 0);
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				chkControl[cDisplayVoucherNoAfterSave].CheckState = (CheckState) ((Convert.ToBoolean(rsLocalRec["Display_Voucher_No_After_Save"])) ? 1 : 0);
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				chkControl[cShowDefaultSalesmanInDetail].CheckState = (CheckState) ((Convert.ToBoolean(rsLocalRec["Show_Default_Salesman_In_Detail"])) ? 1 : 0);

				txtControl[cPreferenceCd].Text = (Convert.IsDBNull(rsLocalRec["feature_id"])) ? "" : Convert.ToString(rsLocalRec["feature_id"]);
				txtControl_Leave(txtControl[cPreferenceCd], new EventArgs());

				//--------------------------------------------------------
			}
			rsLocalRec.Close();

			tabGLVoucherType.CurrTab = 0;
			FirstFocusObject.Focus();

			//Change the form mode to edit
			mCurrentFormMode = SystemVariables.SystemFormModes.frmEditMode;
			ShowPrintingDetailsTab();
			return;


			//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
			SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, Information.Err().Description, this.Name, "GetRecord");
		}

		public void printRecord()
		{
			//Print routine

		}

		public void CloseForm()
		{
			this.Close();
		}

		public bool CheckDataValidity()
		{
			//Check validation during update and add of records
			if (SystemProcedure2.IsItEmpty(txtControl[cVoucherType].Text, SystemVariables.DataType.NumberType))
			{
				MessageBox.Show("Enter Voucher Type", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
				tabGLVoucherType.CurrTab = 0;
				txtControl[cVoucherType].Focus();
				return false;
			}

			//Check validation during update and add of records
			if (SystemProcedure2.IsItEmpty(txtControl[cLVoucherName].Text, SystemVariables.DataType.StringType))
			{
				MessageBox.Show("Enter Voucher Name", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
				tabGLVoucherType.CurrTab = 0;
				txtControl[cLVoucherName].Focus();
				return false;
			}

			//Check validation during update and add of records
			if (SystemProcedure2.IsItEmpty(txtControl[cAVoucherName].Text, SystemVariables.DataType.StringType))
			{
				MessageBox.Show("Enter Voucher Name", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
				tabGLVoucherType.CurrTab = 0;
				txtControl[cAVoucherName].Focus();
				return false;
			}

			if (SystemProcedure2.IsItEmpty(txtControl[cLShortName].Text, SystemVariables.DataType.StringType))
			{
				MessageBox.Show("Enter Voucher Name", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
				tabGLVoucherType.CurrTab = 0;
				txtControl[cLShortName].Focus();
				return false;
			}

			if (SystemProcedure2.IsItEmpty(txtControl[cAShortName].Text, SystemVariables.DataType.StringType))
			{
				MessageBox.Show("Enter Voucher Name", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
				tabGLVoucherType.CurrTab = 0;
				txtControl[cAShortName].Focus();
				return false;
			}

			//Check validation during update and add of records
			if (SystemProcedure2.IsItEmpty(txtControl[cModuleId].Text, SystemVariables.DataType.NumberType))
			{
				MessageBox.Show("Enter Module ID", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
				tabGLVoucherType.CurrTab = 0;
				txtControl[cModuleId].Focus();
				return false;
			}

			if (chkControl[cAllowSingleEntry].CheckState == CheckState.Checked)
			{
				if (SystemProcedure2.IsItEmpty(txtControl[cOppositeLdgrCd].Text, SystemVariables.DataType.NumberType))
				{
					MessageBox.Show("Enter Ledger Code", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
					tabGLVoucherType.CurrTab = 1;
					txtControl[cOppositeLdgrCd].Focus();
					return false;
				}
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
				frmGLVoucherTypes.DefInstance = null;
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		private void GetNextNumber()
		{

			txtControl[cVoucherType].Text = SystemProcedure2.GetNewNumber("gl_accnt_voucher_types", "voucher_type");
		}

		public void findRecord()
		{

			//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(100));
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(mTempSearchValue))
			{
				//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mSearchValue = ReflectionHelper.GetPrimitiveValue(((Array) mTempSearchValue).GetValue(0));
				GetRecord(mSearchValue);
			}
		}

		public void FindRoutine(string pObjectName)
		{
			object mTempSearchValue = null;
			//Declared By Rizwan. 23/12/2007. For Additional Fields
			int mNameIndex = 0;

			if ((pObjectName.IndexOf('#') + 1) == 0)
			{
				return;
			}

			string mObjectName = pObjectName.Substring(0, Math.Min(pObjectName.IndexOf('#'), pObjectName.Length));
			int mIndex = Convert.ToInt32(Double.Parse(pObjectName.Substring(pObjectName.IndexOf('#') + 1)));

			switch(mObjectName)
			{
				case "txtControl" : 
					if (mIndex == cModuleId)
					{
						txtControl[cModuleId].Text = "";
						//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(50, "723,724,725"));
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
						if (!Convert.IsDBNull(mTempSearchValue))
						{
							//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							txtControl[cModuleId].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(1));
							txtControl[cModuleName].Text = ReflectionHelper.GetPrimitiveValue<string>((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? ((Array) mTempSearchValue).GetValue(2) : ((Array) mTempSearchValue).GetValue(3));
							//Call txtControl_LostFocus
						}
					}
					else if (mIndex == cOppositeLdgrCd)
					{ 
						txtControl[cOppositeLdgrCd].Text = "";
						//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(1001000, "2,3,4"));
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
						if (!Convert.IsDBNull(mTempSearchValue))
						{
							//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							txtControl[cOppositeLdgrCd].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(1));
							txtControl[cOppositeLdgrName].Text = ReflectionHelper.GetPrimitiveValue<string>((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? ((Array) mTempSearchValue).GetValue(2) : ((Array) mTempSearchValue).GetValue(3));
							//Call txtControl_LostFocus
						}
					}
					else if (mIndex == cCrystalReportsEngCd || mIndex == cCrystalReportsArCd)
					{ 
						mNameIndex = (mIndex == cCrystalReportsEngCd) ? cCrystalReportsEngName : cCrystalReportsArName;
						txtControl[mIndex].Text = "";
						//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(57, "2019,2020,2021"));
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
						if (!Convert.IsDBNull(mTempSearchValue))
						{
							//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							txtControl[mIndex].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(1));
							txtControl[mNameIndex].Text = ReflectionHelper.GetPrimitiveValue<string>((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? ((Array) mTempSearchValue).GetValue(2) : ((Array) mTempSearchValue).GetValue(3));
						}
					}
					else if (mIndex == cEntryIdEngCd || mIndex == cEntryIdArCd)
					{ 
						mNameIndex = (mIndex == cEntryIdEngCd) ? cEntryIdEngName : cEntryIdArName;
						txtControl[mIndex].Text = "";
						//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(58, "2037,2038"));
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
						if (!Convert.IsDBNull(mTempSearchValue))
						{
							//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							txtControl[mIndex].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(1));
							//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							txtControl[mNameIndex].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(2));
						}
					}
					else if (mIndex == cPDCGeneratedLinkedVoucherCd)
					{ 
						txtControl[cPDCGeneratedLinkedVoucherCd].Text = "";
						//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(205, "2044,2045,2047"));
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
						if (!Convert.IsDBNull(mTempSearchValue))
						{
							//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							txtControl[cPDCGeneratedLinkedVoucherCd].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(1));
							txtControl[cPDCGeneratedLinkedVoucherName].Text = ReflectionHelper.GetPrimitiveValue<string>((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? ((Array) mTempSearchValue).GetValue(2) : ((Array) mTempSearchValue).GetValue(3));
						}
					}
					else if (mIndex == cPreferenceCd)
					{ 
						txtControl[cPreferenceCd].Text = "";
						//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(1000131, "2001,2005,2007"));
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
						if (!Convert.IsDBNull(mTempSearchValue))
						{
							//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							txtControl[cPreferenceCd].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(1));
							txtControl[cFeatureName].Text = ReflectionHelper.GetPrimitiveValue<string>((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? ((Array) mTempSearchValue).GetValue(2) : ((Array) mTempSearchValue).GetValue(3));
						}
					} 
					break;
				default:
					return;
			}
		}

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBGrid Event grdPrintTask.FetchCellStyle was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void grdPrintTask_FetchCellStyle(int Condition, int Split, object Bookmark, int Col, C1.Win.C1TrueDBGrid.Style CellStyle)
		{
			XArrayHelper aCurrentArray = null;

			if (Col == grdAutoPrintColumn || Col == grdEnablePrintOnEditColumn || Col == grdShowOptionColumn || Col == grdShowPreviewColumn || Col == grdPromptForPrintColumn || Col == grdShowPrinterColumn || Col == grdDefaultSelectColumn)
			{
				aCurrentArray = aReportDetails;

				//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				if (((TriState) Convert.ToInt32(aCurrentArray.GetValue(Convert.ToInt32(Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(Bookmark))), Col))) == TriState.True)
				{
					CellStyle.ForegroundImage = frmSysMain.DefInstance.imlSystemIcons.Images["imgChecked2"];
				}
				else
				{
					CellStyle.ForegroundImage = frmSysMain.DefInstance.imlSystemIcons.Images["imgUnchecked"];
				}

				CellStyle.ForeGroundPicturePosition = C1.Win.C1TrueDBGrid.ForeGroundPicturePositionEnum.PictureOnly;
			}
			aCurrentArray = null;
		}

		private bool isInitializingComponent;
		private void optCommonQtyEffect_CheckedChanged(Object eventSender, EventArgs eventArgs)
		{
			int Index = Array.IndexOf(this.optCommonQtyEffect, eventSender);
			if (((RadioButton) eventSender).Checked)
			{
				if (isInitializingComponent)
				{
					return;
				}
				switch(Index)
				{
					case cUseXMLReports : 
						txtControl[cCrystalReportsEngCd].Enabled = optCommonQtyEffect[cUseCrystalReports].Checked; 
						txtControl[cCrystalReportsEngName].Enabled = optCommonQtyEffect[cUseCrystalReports].Checked; 
						txtControl[cEntryIdEngCd].Enabled = optCommonQtyEffect[cUseCrystalReports].Checked; 
						txtControl[cEntryIdEngName].Enabled = optCommonQtyEffect[cUseCrystalReports].Checked; 
						txtControl[cCrystalReportsArCd].Enabled = optCommonQtyEffect[cUseCrystalReports].Checked; 
						txtControl[cCrystalReportsArName].Enabled = optCommonQtyEffect[cUseCrystalReports].Checked; 
						txtControl[cEntryIdArCd].Enabled = optCommonQtyEffect[cUseCrystalReports].Checked; 
						txtControl[cEntryIdArName].Enabled = optCommonQtyEffect[cUseCrystalReports].Checked; 
						//txtCommon(cPrintVoucherName).Enabled = Not optCommonQtyEffect(cUseCrystalReports).Value 
						grdPrintTask.Enabled = false; 
						break;
					case cUseCrystalReports : 
						grdPrintTask.Enabled = true; 
						break;
					default:
						return;
				}
			}
		}



		private void txtControl_DropButtonClick(Object Sender, EventArgs e)
		{
			int Index = Array.IndexOf(this.txtControl, Sender);
			FindRoutine("txtControl#" + Index.ToString().Trim());
		}

		private void txtControl_Leave(Object eventSender, EventArgs eventArgs)
		{
			int Index = Array.IndexOf(this.txtControl, eventSender);
			string mysql = "";
			object mTempReturnValue = null;
			int mSetValueIndex = 0;
			int mNameIndex = 0;

			try
			{

				switch(Index)
				{
					case cModuleId : 
						mysql = "select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_group_name" : "a_group_name"); 
						mysql = mysql + " from SM_MODULES "; 
						mysql = mysql + " Where module_id =" + txtControl[cModuleId].Text; 
						mSetValueIndex = 1; 
						break;
					case cOppositeLdgrCd : 
						mysql = "select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_ldgr_name" : "a_ldgr_name"); 
						mysql = mysql + " from gl_ledger where ldgr_no ='" + txtControl[Index].Text + "'"; 
						mSetValueIndex = 1; 
						break;
					case cCrystalReportsEngCd : case cCrystalReportsArCd : 
						mysql = "select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_report_name" : "a_report_name"); 
						mysql = mysql + " from SM_REPORTS where report_id =" + txtControl[Index].Text; 
						mNameIndex = (Index == cCrystalReportsEngCd) ? cCrystalReportsEngName : cCrystalReportsArName; 
						mSetValueIndex = 1; 
						break;
					case cEntryIdEngCd : case cEntryIdArCd : 
						mysql = "select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_field_caption" : "a_field_caption"); 
						mysql = mysql + " from SM_REPORT_FIELDS where column_id = " + txtControl[Index].Text; 
						mNameIndex = (Index == cEntryIdEngCd) ? cEntryIdEngName : cEntryIdArName; 
						mSetValueIndex = 1; 
						break;
					case cPDCGeneratedLinkedVoucherCd : 
						mysql = "select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_voucher_name" : "a_voucher_name"); 
						mysql = mysql + " from gl_accnt_voucher_types where voucher_type =" + txtControl[Index].Text; 
						mSetValueIndex = 1; 
						break;
					case cPreferenceCd : 
						mysql = "select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_preference_name" : "a_preference_name"); 
						mysql = mysql + " from SM_Preferences where preference_id =" + txtControl[Index].Text; 
						mSetValueIndex = 1; 
						break;
				}

				if (mSetValueIndex == 1)
				{
					if (!SystemProcedure2.IsItEmpty(txtControl[Index].Text, SystemVariables.DataType.StringType))
					{
						//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mTempReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
						if (!Convert.IsDBNull(mTempReturnValue))
						{
							if (Index == cModuleId)
							{
								//UPGRADE_WARNING: (1068) mTempReturnValue of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
								txtControl[cModuleName].Text = ReflectionHelper.GetPrimitiveValue<string>(mTempReturnValue);
							}
							else if (Index == cOppositeLdgrCd)
							{ 
								//UPGRADE_WARNING: (1068) mTempReturnValue of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
								txtControl[cOppositeLdgrName].Text = ReflectionHelper.GetPrimitiveValue<string>(mTempReturnValue);
							}
							else if (Index == cCrystalReportsEngCd || Index == cCrystalReportsArCd)
							{ 
								//UPGRADE_WARNING: (1068) mTempReturnValue of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
								txtControl[mNameIndex].Text = ReflectionHelper.GetPrimitiveValue<string>(mTempReturnValue);
							}
							else if (Index == cEntryIdEngCd || Index == cEntryIdArCd)
							{ 
								//UPGRADE_WARNING: (1068) mTempReturnValue of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
								txtControl[mNameIndex].Text = ReflectionHelper.GetPrimitiveValue<string>(mTempReturnValue);
							}
							else if (Index == cPDCGeneratedLinkedVoucherCd)
							{ 
								//UPGRADE_WARNING: (1068) mTempReturnValue of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
								txtControl[cPDCGeneratedLinkedVoucherName].Text = ReflectionHelper.GetPrimitiveValue<string>(mTempReturnValue);
							}
							else if (Index == cPreferenceCd)
							{ 
								//UPGRADE_WARNING: (1068) mTempReturnValue of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
								txtControl[cFeatureName].Text = ReflectionHelper.GetPrimitiveValue<string>(mTempReturnValue);
							}
						}
						else
						{
							if (Index == cEntryIdEngCd || Index == cEntryIdArCd)
							{
								txtControl[mNameIndex].Text = "";
							}
							else
							{
								throw new System.Exception("-9990002");
							}
						}
					}
				}
			}
			catch (System.Exception excep)
			{
				int mReturnErrorType = 0;
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				mReturnErrorType = SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, excep.Message, "GL VoucherType", "LostFocus", SystemConstants.msg10);
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
					//if the code is not found
					if (txtControl[Index].Enabled)
					{
						//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
						try
						{
							txtControl[Index].Focus();
						}
						catch (Exception exc)
						{
							NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
						}
					}
				}
				else
				{
					//
				}
			}



		}


		private void RefreshgrdPrintTaskDetails(bool pCallComboRowChange = true)
		{

			//If mSupplierDetailsTabClicked = False Then
			string mysql = "SELECT POS_Counter_Cd, ";
			mysql = mysql + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "L_POS_Counter_Name" : "A_POS_Counter_Name") + " as POS_Counter_name ";
			mysql = mysql + ", POS_Computer_Name";
			mysql = mysql + " FROM ICS_POS_Counter";

			rsPOSList = new DataSet();
			//UPGRADE_ISSUE: (2064) ADODB.CursorLocationEnum property CursorLocationEnum.adUseClient was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsPOSList.CursorLocation was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			rsPOSList.setCursorLocation(UpgradeStubs.ADODB_CursorLocationEnum.getadUseClient());
			SqlDataAdapter adap = new SqlDataAdapter(mysql, SystemVariables.gConn);
			rsPOSList.Tables.Clear();
			adap.Fill(rsPOSList);
			//Else
			//UPGRADE_ISSUE: (2064) ADODB.Recordset method rsPOSList.Requery was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			rsPOSList.Requery(-1);

			mysql = "SELECT Report_Id, ";
			mysql = mysql + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "L_Report_Name" : "A_Report_Name") + " as Report_Name ";
			mysql = mysql + " FROM SM_REPORTS";
			mysql = mysql + " Where (A_External_Report_File_Name Is Not Null)";

			rsReportList = new DataSet();
			//UPGRADE_ISSUE: (2064) ADODB.CursorLocationEnum property CursorLocationEnum.adUseClient was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsReportList.CursorLocation was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			rsReportList.setCursorLocation(UpgradeStubs.ADODB_CursorLocationEnum.getadUseClient());
			SqlDataAdapter adap_2 = new SqlDataAdapter(mysql, SystemVariables.gConn);
			rsReportList.Tables.Clear();
			adap_2.Fill(rsReportList);

			PrinterHelper prt = null;

			rsPrinterList = new DataSet();
			//UPGRADE_ISSUE: (2070) Constant adFldUnspecified was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2070
			//UPGRADE_ISSUE: (2064) ADODB.Fields15 method rsPrinterList.Fields.Append was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			UpgradeStubs.ADODB_Fields15.Append("DeviceName", DbType.String, 1000, UpgradeStubs.ADODB_FieldAttributeEnum.getadFldUnspecified(), null);
			//UPGRADE_ISSUE: (2070) Constant adLockUnspecified was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2070
			//UPGRADE_ISSUE: (2070) Constant adOpenUnspecified was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2070
			//UPGRADE_ISSUE: (2064) ADODB.Recordset method rsPrinterList.Open was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			rsPrinterList.Open(null, null, UpgradeStubs.ADODB_CursorTypeEnum.getadOpenUnspecified(), UpgradeStubs.ADODB_LockTypeEnum.getadLockUnspecified(), -1);
			//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsPrinterList.ActiveConnection was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			rsPrinterList.setActiveConnection(null);

			foreach (PrinterHelper prtIterator in PrinterHelper.Printers)
			{
				prt = prtIterator;
				//UPGRADE_ISSUE: (2064) ADODB.Recordset method rsPrinterList.AddNew was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				rsPrinterList.AddNew("DeviceName", PrinterHelper.Printer.DeviceName);
				prt = default(PrinterHelper);
			}

			grdPrintTask.Focus();
			//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbPrintList.DataSource was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			cmbPrintList.setDataSource((msdatasrc.DataSource) rsPOSList);

			//End If
		}
		private void grdPrintTask_GotFocus(Object eventSender, EventArgs eventArgs)
		{
			try
			{
				string mysql = "";

				SystemGrid.DefineSystemGridCombo(cmbPrintList);
				RefreshgrdPrintTaskDetails();
				//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBGrid method grdPrintTask.PostMsg was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				grdPrintTask.PostMsg(1);
			}
			catch (System.Exception excep)
			{
				MessageBox.Show(excep.Message, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
			}

		}

		private void grdPrintTask_KeyPress(Object eventSender, KeyPressEventArgs eventArgs)
		{
			int KeyAscii = Convert.ToInt32(eventArgs.KeyChar);
			try
			{

				int Col = grdPrintTask.Col;
				if (Col == grdAutoPrintColumn || Col == grdEnablePrintOnEditColumn || Col == grdShowOptionColumn || Col == grdShowPreviewColumn || Col == grdPromptForPrintColumn || Col == grdShowPrinterColumn || Col == grdDefaultSelectColumn)
				{
					if (KeyAscii == 32)
					{
						KeyAscii = 0;
						if (ReflectionHelper.GetPrimitiveValue<string>(grdPrintTask.Columns[Col].Value) == "")
						{
							grdPrintTask.Columns[Col].Value = -1;
						}
						else
						{
							grdPrintTask.Columns[Col].Value = ~ReflectionHelper.GetPrimitiveValue<int>(grdPrintTask.Columns[Col].Value);
						}
						grdPrintTask.UpdateData();
						grdPrintTask.Refresh();
					}
					else
					{
						KeyAscii = 0;
					}
					if (KeyAscii == 0)
					{
						eventArgs.Handled = true;
					}
					return;
				}
			}
			finally
			{
				if (KeyAscii == 0)
				{
					eventArgs.Handled = true;
				}
				eventArgs.KeyChar = Convert.ToChar(KeyAscii);
			}
		}

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBGrid Event grdPrintTask.PostEvent was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void grdPrintTask_PostEvent(int MsgId)
		{

			if (mLastCol == grdPrintTask.Col && mLastRow == grdPrintTask.Row)
			{
				return;
			}

			int Col = grdPrintTask.Col;
			if (Col == grdAutoPrintColumn || Col == grdEnablePrintOnEditColumn || Col == grdShowOptionColumn || Col == grdShowPreviewColumn || Col == grdPromptForPrintColumn || Col == grdShowPrinterColumn || Col == grdDefaultSelectColumn)
			{
				if (ReflectionHelper.GetPrimitiveValue<string>(grdPrintTask.Columns[Col].Value) == "")
				{
					grdPrintTask.Columns[Col].Value = -1;
				}
				else
				{
					grdPrintTask.Columns[Col].Value = ~ReflectionHelper.GetPrimitiveValue<int>(grdPrintTask.Columns[Col].Value);
				}
				grdPrintTask.UpdateData();
				grdPrintTask.Refresh();
			}
		}
		private void grdPrintTask_RowColChange(object eventSender, C1.Win.C1TrueDBGrid.RowColChangeEventArgs eventArgs)
		{
			int LastRow = eventArgs.LastRow;
			int LastCol = eventArgs.LastCol;
			switch(grdPrintTask.Col)
			{
				case grdPOSColumn : 
					//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbPrintList.DataSource was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064 
					cmbPrintList.setDataSource((msdatasrc.DataSource) rsPOSList); 
					break;
				case grdReportColumn : 
					//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbPrintList.DataSource was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064 
					cmbPrintList.setDataSource((msdatasrc.DataSource) rsReportList); 
					break;
				case grdPrinterColumn : 
					//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbPrintList.DataSource was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064 
					cmbPrintList.setDataSource((msdatasrc.DataSource) rsPrinterList); 
					 
					break;
			}
		}
		private void ShowPrintingDetailsTab()
		{
			string mysql = "";
			int cnt = 0;
			SqlDataReader rsLocalRec = null;



			aReportDetails = new XArrayHelper();
			if (CurrentFormMode == SystemVariables.SystemFormModes.frmEditMode)
			{

				mysql = "SELECT  Print_Task_Cd, Voucher_Type, Report_Id ";
				mysql = mysql + ", POS_Counter_Cd, Printer_Path, Auto_Print_After_Save, enable_print_on_edit";
				mysql = mysql + ", Show_Option, Show_Printer";
				mysql = mysql + ", Show_Preview, Prompt_For_Print_After_Save, default_Select";
				mysql = mysql + " FROM GL_Print_Task_Detail ";
				mysql = mysql + " where Voucher_Type = " + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);

				SqlCommand sqlCommand = new SqlCommand(mysql, SystemVariables.gConn);
				rsLocalRec = sqlCommand.ExecuteReader();
				rsLocalRec.Read();

				DefineReportArray(mMaxReportDetailCols, -1, true);
				do 
				{
					DefineReportArray(mMaxReportDetailCols, cnt, false);

					//aProductSupplierDetails(cnt, ckSupplierIndex) = .Fields("Entry_Id").Value
					aReportDetails.SetValue(rsLocalRec["POS_Counter_Cd"], cnt, grdPOSColumn);
					aReportDetails.SetValue(Convert.ToString(rsLocalRec["Report_Id"]) + "", cnt, grdReportColumn);
					aReportDetails.SetValue(rsLocalRec["Printer_Path"], cnt, grdPrinterColumn);
					aReportDetails.SetValue(rsLocalRec["Auto_Print_After_Save"], cnt, grdAutoPrintColumn);
					aReportDetails.SetValue(rsLocalRec["enable_print_on_edit"], cnt, grdEnablePrintOnEditColumn);
					aReportDetails.SetValue(rsLocalRec["Prompt_For_Print_After_Save"], cnt, grdPromptForPrintColumn);
					aReportDetails.SetValue(rsLocalRec["Show_Option"], cnt, grdShowOptionColumn);
					aReportDetails.SetValue(rsLocalRec["Show_Preview"], cnt, grdShowPreviewColumn);
					aReportDetails.SetValue(rsLocalRec["Show_Printer"], cnt, grdShowPrinterColumn);
					aReportDetails.SetValue(rsLocalRec["default_Select"], cnt, grdDefaultSelectColumn);

					cnt++;
				}
				while(rsLocalRec.Read());
				rsLocalRec.Close();
			}
			else
			{
				DefineReportArray(mMaxReportDetailCols, -1, true);
			}
			//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBGrid property grdPrintTask.Array was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			grdPrintTask.setArray(aReportDetails);
			AssignReportGridLineNumbers();
			grdPrintTask.Rebind(true);

		}
		private void DefineReportArray(int pMaximumCols, int pMaximumRows, bool pClearArray = false)
		{
			if (pClearArray)
			{
				//UPGRADE_ISSUE: (2064) XArrayDBObject.XArrayDB method aReportDetails.Clear was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				aReportDetails.Clear();
			}
			aReportDetails.RedimXArray(new int[]{pMaximumRows, pMaximumCols}, new int[]{0, 0});
		}
		private void AssignReportGridLineNumbers()
		{
			int cnt = 0;
			int tempForEndVar = aReportDetails.GetLength(0) - 1;
			for (cnt = 0; cnt <= tempForEndVar; cnt++)
			{
				aReportDetails.SetValue(cnt + 1, cnt, grdLNColumn);
			}
		}
		private void grdPrintTask_MouseUp(Object eventSender, MouseEventArgs eventArgs)
		{
			int Button = (eventArgs.Button == MouseButtons.Left) ? 1 : ((eventArgs.Button == MouseButtons.Right) ? 2 : 4);
			int Shift = ((int) Control.ModifierKeys) / 65536;
			float x = eventArgs.X * 15;
			float y = eventArgs.Y * 15;
			if (grdPrintTask.PointAt(x, y) == C1.Win.C1TrueDBGrid.PointAtEnum.AtDataArea)
			{
				mLastCol = grdPrintTask.Col;
				mLastRow = grdPrintTask.Row;
				//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBGrid method grdPrintTask.PostMsg was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				grdPrintTask.PostMsg(1);
			}
		}
		public void LRoutine()
		{
			if (ActiveControl.Name != "grdPrintTask")
			{
				grdPrintTask.Focus();
			}

			if (aReportDetails.GetLength(0) > 0)
			{
				grdPrintTask.Delete();
				AssignReportGridLineNumbers();
				grdPrintTask.Rebind(true);
			}
		}

		public void MRoutine()
		{

			if (!this.UserAccess.AllowUserDisplay)
			{
				MessageBox.Show(SystemConstants.msg8, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			RecordNavigate(37, ReflectionHelper.GetPrimitiveValue<int>(mRecordNavigateSearchValue));


		}
		public void ORoutine()
		{

			if (!this.UserAccess.AllowUserDisplay)
			{
				MessageBox.Show(SystemConstants.msg8, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			RecordNavigate(39, ReflectionHelper.GetPrimitiveValue<int>(mRecordNavigateSearchValue));


		}
		private void RecordNavigate(int pKeyCode, int pVoucherType)
		{

			string mysql = " select top 1 voucher_type from gl_accnt_voucher_types gvt";
			mysql = mysql + " inner join SM_Preferences sf on sf.preference_id = gvt.feature_id";
			mysql = mysql + " where 1=1 ";
			if (pVoucherType > 0 && pKeyCode == 37)
			{
				mysql = mysql + " and voucher_type < " + pVoucherType.ToString();
			}
			else if (pVoucherType > 0 && pKeyCode == 39)
			{ 
				mysql = mysql + " and voucher_type > " + pVoucherType.ToString();
			}
			mysql = mysql + " and sf.preference_value = '1'";

			if (pKeyCode == 37)
			{
				mysql = mysql + " order by voucher_type desc ";
			}
			else if (pKeyCode == 39)
			{ 
				mysql = mysql + " order by voucher_type asc ";
			}

			//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(mReturnValue))
			{
				if (this.UserAccess.AllowUserDisplay)
				{
					GetRecord(mReturnValue);
				}
				else
				{
					MessageBox.Show(SystemConstants.msg8, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}
			}

		}
	}
}