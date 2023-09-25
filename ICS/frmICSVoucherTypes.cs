
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using UpgradeHelpers.Gui;

using UpgradeHelpers.VB;


namespace Xtreme
{
	internal partial class frmICSVoucherTypes
		: System.Windows.Forms.Form
	{

		public frmICSVoucherTypes()
{
InitializeComponent();
} 
 public  void frmICSVoucherTypes_old()
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


		private void frmICSVoucherTypes_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (UpgradeHelpers.Gui.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Gui.ActivateHelper.myActiveForm = (System.Windows.Forms.Form) eventSender;
			}
		}

		private int mThisFormID = 0;
		private object mSearchValue = null;
		private bool mFirstGridFocus = false;
		public bool mGetStatus = false;
		private object mRecordNavigateSearchValue = null;
		private string mTimeStamp = "";
		private SystemVariables.SystemFormModes mCurrentFormMode = (SystemVariables.SystemFormModes) 0; //Enum for checking the current form mode
		public clsToolbar oThisFormToolBar = null;
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
		public Control FirstFocusObject = null;
		private XArrayHelper _aParentDetails = null;
		private XArrayHelper aParentDetails
		{
			get
			{
				if (_aParentDetails is null)
				{
					_aParentDetails = new XArrayHelper();
				}
				return _aParentDetails;
			}
			set
			{
				_aParentDetails = value;
			}
		}

		private DataSet rsParentList = null;
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

		//Added by:Rizwan. Date:5/12/2007. Regarding ICS Voucher Type Form
		//------------------------------------------------------------------
		private const int tcVoucherType = 0;
		private const int tcLVouchername = 1;
		private const int tcAVouchername = 2;
		private const int tcLShortName = 4;
		private const int tcAShortName = 5;
		private const int tcModuleCode = 6;
		private const int tcPreferenceCode = 7;
		private const int tcFindCode = 8;
		private const int tcParentCode = 9;
		private const int tcReportCode = 10;
		private const int tcFormHeightSize = 11;
		private const int tcPrintVoucherName = 12;
		private const int tcPrintVoucherSQL = 13;
		private const int tcGridRowHeightSize = 14;
		private const int tcLinkedAssemblyGroupAdjustVoucherCd = 15;
		private const int tcRevisedHistoryVoucherCode = 16;
		private const int tcDentedStockGeneratedLinkedVoucherCd = 17;
		private const int tcGLVoucherCd = 18;
		private const int tcAfterSaveScript = 19;
		private const int tcGLReceiptVoucherCd = 20;
		private const int tcGLPaymentVoucherCd = 21;
		private const int tcGLJournalVoucherCd = 22;
		private const int tcAdditionalCashFindWhereClause = 23;
		private const int tcVoucherGridBackColor = 24;
		private const int tcAdditionalLdgrFindWhereClause = 25;
		private const int tcLPartyNameCaption = 26;
		private const int tcAPartyNameCaption = 27;
		private const int tcICSMasterTableName = 28;
		private const int tcICSDetailsTableName = 29;
		private const int tcICSParentMasterTableName = 30;
		private const int tcChildICSCode = 31;
		private const int tcParentICSCode = 32;
		private const int tcICSParentDetailsTableName = 33;
		private const int tcReferenceNoCaption = 34;
		private const int tcColor = 35;
		private const int tcExpensesLdgrFindWhereClause = 36;
		private const int tcProductListWhereClause = 37;
		private const int tcDefaultCashCode = 38;
		private const int tcVoucherNoMethod = 39;
		private const int tcDefaultCreditCardCode = 40;

		//Constants for Common Label Text Box
		private const int dcLinkedAssemblyGroupAdjustVoucherCd = 0;
		private const int dcModuleName = 1;
		private const int dcFindName = 2;
		private const int dcParentName = 3;
		private const int dcReportName = 4;
		private const int dcEntryName = 5;
		private const int dcRevisedHistoryVoucherName = 6;
		private const int dcParentICSName = 11;
		private const int dcChildICSName = 12;
		private const int dcGLVoucherCd = 13;
		private const int dcGLReceiptVoucherCd = 14;
		private const int dcGLPaymentVoucherCd = 15;
		private const int dcGLJournalVoucherCd = 16;
		private const int dcLastLocationNumber = 17;
		private const int dcLastCashType = 18;
		private const int dcLastCashNumber = 19;
		private const int dcLastSalesmanNumber = 20;
		private const int dcFeatureName = 21;
		private const int dcLastLedgerNumber = 22;
		private const int dcDentedStockGeneratedLinkedVoucherCd = 29;

		//Constants for CheckBoxes
		private const int chkAffectGLS = 0;
		private const int chkAffectICS = 1;
		private const int chkAffectCost = 2;
		private const int chkAffectOpeningValue = 3;
		private const int chkShow = 4;
		private const int chkStoreToStore = 5;
		private const int chkShowInMenu = 6;
		private const int chkAutogenerateVocherNo = 7;
		private const int chkGetMaxNewVoucherNo = 124;

		private const int chkShowLedger = 8;
		private const int chkShowLocation = 22;
		private const int chkShowCashCredit = 23;
		private const int chkShowLineNoInList = 24;
		private const int chkShowNetAmount = 26;
		private const int chkShowDiscountInPercent = 27;
		private const int chkShowExpenses = 28;
		private const int chkShowSalesman = 30;
		private const int chkExchangeRate = 31;
		private const int chkRemarks = 32;
		private const int chkShowPartNoInList = 33;
		//Private Const chkShowImportLinkedVchr As Integer = 35
		private const int chkEnableAutoFillPreText = 35;
		private const int chkShowUnitInList = 38;
		private const int chkShowProdNameInList = 39;
		private const int chkShowAdditionalVoucherDetails = 40;
		private const int chkShowDueDate = 67;
		private const int chkShowJobCd = 70;
		private const int chkShowDocPresc = 71;
		private const int chkShowPartyBal = 111;
		private const int chkShowBatchCd = 114;
		private const int chkShowExpLdgrCode = 115;
		private const int chkShowConsignmentNo = 123;

		private const int chkShowPromoTypeInList = 29;
		private const int chkShowQtyInList = 37;
		private const int chkShowRemainingQtyInList = 36;
		private const int chkShowRateInList = 34;
		private const int chkShowDiscountInList = 25;
		private const int chkShowAmountInList = 9;
		private const int chkShowLocationInList = 15;
		private const int chkShowRemarksInList = 12;
		private const int chkShowSerialNoInList = 11;
		private const int chkShowBarcodeInList = 10;
		private const int chkShowProjectInList = 16;
		private const int chkShowWeightInList = 68;
		private const int chkShowProdDiscountPercentInList = 72;
		private const int chkShowNonInventoryProductInList = 112;
		private const int chkShowDentedStkInList = 113;
		private const int chkShowBaseUnitInList = 14;
		private const int chkShowProductGroupInList = 13;
		private const int chkShowProdCategoryInList = 21;
		private const int chkShowPurPriceInList = 20;
		private const int chkShowSalesPriceInList = 19;
		private const int chkShowRateUOMInList = 69;
		private const int chkShowBaseUnitInStatus = 18;
		private const int chkShowStkInHandInStatus = 17;
		private const int chkShowAllocatedStkInStatus = 41;
		private const int chkShowStkAvailableInStatus = 42;
		private const int chkShowStkInTransitInStatus = 43;
		private const int chkShowStkOnOrderInStatus = 44;
		private const int chkAdvStkInStatus = 45;
		private const int chkStkReturnInTransitInStatus = 46;
		private const int chkOnOrderStockOfSales = 47;
		private const int chkShowSupplierTab = 103;

		private const int chkAutoPostICS = 48;
		private const int chkAutoPostParty = 49;
		private const int chkAutoPostStatus = 53;
		private const int chkAutoPostExpenses = 52;
		private const int chkAutoPostGLInventory = 51;
		private const int chkAutoPostGLS = 50;
		private const int chkBatchPostICS = 59;
		private const int chkBatchPostParty = 58;
		private const int chkBatchPostStatus = 54;
		private const int chkBatchPostExpenses = 55;
		private const int chkBatchPostGLInventory = 56;
		private const int chkBatchPostGLS = 57;
		private const int chkAllowOnlinePosting = 60;
		private const int chkPrintPreview = 61;
		private const int chkPageSetup = 62;
		private const int chkCloseWindowAfterPrint = 63;
		private const int chkPrintAfterSave = 64;
		private const int chkNumToChar = 65;

		private const int chkExportToWord = 66;
		private const int chkLastTranCashType = 73;
		private const int chkAutoGeneratedLinkedVoucher = 74;
		private const int chkPreserveGridValueDuringImport = 75;
		private const int chkAutoPostStockGeneratedVocherNo = 76;
		private const int chkEnableExcessQtyWhenLinked = 77;
		private const int chkBindToParent = 78;
		private const int chkAutoGeneratedLinkedVoucherAllLoc = 79;
		private const int chkBindToParentHeaderLocation = 80;
		private const int chkAutoGeneratedLinkedVoucherForCash = 81;
		private const int chkAllowDirectTransaction = 82;
		private const int chkPreDesc = 83;
		private const int chkAdditionalDetails2 = 84;
		private const int chkPostDesc = 85;
		private const int chkPartialReciept = 86;
		private const int chkProductNameExists = 87;
		private const int chkPartNoExists = 88;
		private const int chkSetFocusAfterAddnew = 89;
		private const int chkImportExternalData = 90;
		private const int chkEnableICSFinalPymtScreen = 91;
		private const int chkEnableRevision = 92;
		private const int chkMultipleLocation = 93;
		private const int chkVchrNumInVchr = 94;
		private const int chkLocationInVchr = 95;
		private const int chkNegativeStk = 96;
		private const int chkRefNoInVoucher = 97;
		private const int chkProdNameAlteration = 98;
		private const int chkAllowAddSerialNum = 99;
		private const int chkAllowUpdate = 100;
		private const int chkAllowAddNew = 101;
		private const int chkBeginWithSeperator = 102;
		private const int chkNewLineAfterBarcode = 104;
		private const int chkNewLineAfterQty = 105;
		private const int chkShowAmtOverRate = 106;
		private const int chkDisplayVoucherNumAfterSave = 107;
		private const int chkLocationSpecificProduct = 109;
		private const int chkDefaultLocSman = 110;
		private const int chkLastTranSettings = 108;
		private const int chkImportNonInventoryForParentVoucher = 121;
		private const int chkEnableRateWhenLinked = 116;
		private const int chkEnableDiscountWhenLinked = 117;
		private const int chkEnableAmountWhenLinked = 118;
		private const int chkEnableCashCreditWhenLinked = 119;
		private const int chkEnablePercentDiscountWhenLinked = 120;
		private const int chkAffectGLWithExpenses = 122;
		private const int chkAllowZeroAmountTransaction = 125;
		private const int chkShowExpiry = 126;
		private const int chkShowInPeriodicalBatchPost = 127;
		private const int chkShowBelowReorderLevelMsg = 128;
		private const int chkShowMinimumLevelMsg = 129;
		private const int chkShowMsximumLevelMsg = 130;
		private const int chkGenerateReceiptPaymentVoucher = 131;
		private const int chkShowFlex1 = 132;
		private const int chkEnableCashCredit = 133;
		private const int chkImportCashCredit = 134;
		private const int chkImportPriceOverwrite = 135;
		private const int chkShowPackQty = 136;
		private const int chkSetFocusToQty = 137;

		//Constants for OptionButtons(Quantity)
		private const int optIncreaseStock = 0;
		private const int optDecreaseStock = 1;
		private const int optCrystalReports = 2;
		private const int optXMLReports = 3;

		//Constants for OptionButtons(Affect)
		private const int optOnHandStock = 0;
		private const int optAllocatedStock = 1;
		private const int optInTransitStock = 2;
		private const int optOnOrderPurchaseStock = 3;
		private const int optReservedStock = 4;
		private const int optAdvancedBookedStock = 5;
		private const int optSalesreturnInTransitStock = 6;
		private const int optOnOrderSalesStock = 7;
		private const int OptNone = 8;
		private const int optShowImportLinkedVoucherOnDetails = 9;
		private const int optShowImportLinkedVoucherOnHeader = 10;
		private const int optHideImportLinkedVoucher = 11;

		//Constant for Frames
		private const int fraLegacyLinks = 18;
		private const int fraLinks = 21;
		private const int fraVoucherParentDetails = 23;

		private const int cmbDocumentType = 0;
		private const int cmbPriceLevel = 1;
		private const int cmbReferenceType = 2;

		//''''''''Const for CmbParentsList
		private const int cCpParentCode = 0;
		private const int cCpParentName = 1;

		//Declared By: Rizwan. 5/12/2007. To Get the Index For Label
		private int mSetIndexValue = 0;

		private const int cntMaxArrayCols = 3;
		private const int grdLineNoColumn = 0;
		private const int grdParentCodeColumn = 1;
		private const int grdParentNameColumn = 2;
		private const int cBasicMasterDetails = 0;
		private const int cLinkMasterDetails = 1;
		private const int cOtherDetails = 7;

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

		//**--define form level constants
		private const int mBasicMasterDetails = 0;
		private const int mLinksDetails = 1;
		private const int mShowHideDetails = 2;
		private const int mPostingDetails = 3;
		private const int mPrintingDetails = 4;
		private const int mPOSDetails = 5;
		private const int mHistoryDetails = 6;
		private const int mOthersDetails = 6;

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

		private void chkCommon_CheckStateChanged(Object eventSender, EventArgs eventArgs)
		{
			int Index = Array.IndexOf(this.chkCommon, eventSender);
			switch(Index)
			{
				case chkEnableRevision : 
					txtCommon[tcRevisedHistoryVoucherCode].Enabled = chkCommon[chkEnableRevision].CheckState != CheckState.Unchecked; 
					txtCommonLabel[dcRevisedHistoryVoucherName].Enabled = chkCommon[chkEnableRevision].CheckState != CheckState.Unchecked; 
					//txtCommon(tcRevisedHistoryVoucherCode).BackColor = IIf(chkCommon(chkEnableRevision).Value = 1, &HEFEFEF, gDisableColumnBackColor) 
					//txtCommonLabel(dcRevisedHistoryVoucherName).BackColor = IIf(chkCommon(chkEnableRevision).Value = 1, &HEFEFEF, gDisableColumnBackColor) 
					break;
				case chkAutoPostGLS : case chkAutoPostGLInventory : case chkAutoPostExpenses : case chkAutoPostStatus : case chkAutoPostParty : 
					SetPostSequence(Index, 1); 
					break;
				case chkBatchPostGLS : case chkBatchPostGLInventory : case chkBatchPostExpenses : case chkBatchPostStatus : case chkBatchPostParty : 
					SetPostSequence(Index, 2); 
					//    Case chkAdditionalColIDs 
					//        txtCommon(tcAdditionalColIds).Enabled = chkCommon(chkAdditionalColIDs).Value 
					//        txtCommon(tcAdditionalColIds).BackColor = IIf(chkCommon(chkAdditionalColIDs).Value = 1, &HEFEFEF, gDisableColumnBackColor) 
					break;
				case chkBindToParentHeaderLocation : 
					if (chkCommon[chkBindToParentHeaderLocation].CheckState == CheckState.Checked)
					{
						chkCommon[chkBindToParent].CheckState = CheckState.Checked;
						chkCommon[chkAllowDirectTransaction].Visible = true;
					} 
					break;
				case chkBindToParent : 
					if (chkCommon[chkBindToParent].CheckState == CheckState.Unchecked)
					{
						chkCommon[chkBindToParentHeaderLocation].CheckState = CheckState.Unchecked;
						chkCommon[chkAllowDirectTransaction].CheckState = CheckState.Unchecked;
						chkCommon[chkAllowDirectTransaction].Visible = false;
					}
					else
					{
						chkCommon[chkAllowDirectTransaction].Visible = true;
					} 
					break;
				default:
					return;
			}
		}
		bool mLoopStatus_SetPostSequence = false;
		private void SetPostSequence(int pIndex, int pPostType)
		{
			bool mEnableSetting = false;
			CheckState mCheckedSetting = CheckState.Unchecked;
			int mPostICS = 0;
			int mPostGLS = 0;
			int mPostParty = 0;
			int mPostExpenses = 0;
			int mPostGLInventory = 0;
			int mPostStatus = 0;

			if (mGetStatus)
			{
				//Post Type - 1 for Auto, 2 for Batch
				mPostICS = (pPostType == 1) ? chkAutoPostICS : chkBatchPostICS;
				mPostGLS = (pPostType == 1) ? chkAutoPostGLS : chkBatchPostGLS;
				mPostParty = (pPostType == 1) ? chkAutoPostParty : chkBatchPostParty;
				mPostExpenses = (pPostType == 1) ? chkAutoPostExpenses : chkBatchPostExpenses;
				mPostGLInventory = (pPostType == 1) ? chkAutoPostGLInventory : chkBatchPostGLInventory;
				mPostStatus = (pPostType == 1) ? chkAutoPostStatus : chkBatchPostStatus;

				if (!mLoopStatus_SetPostSequence)
				{
					mLoopStatus_SetPostSequence = true;
					if (pIndex == mPostGLS)
					{
						mCheckedSetting = chkCommon[pIndex].CheckState;

						chkCommon[mPostParty].CheckState = mCheckedSetting;
						chkCommon[mPostExpenses].CheckState = mCheckedSetting;
						chkCommon[mPostGLInventory].CheckState = mCheckedSetting;
					}

					if (chkCommon[mPostGLInventory].CheckState == CheckState.Checked)
					{
						mEnableSetting = false;
						mCheckedSetting = CheckState.Checked;

						chkCommon[mPostStatus].Enabled = mEnableSetting;
						chkCommon[mPostICS].Enabled = mEnableSetting;
						chkCommon[mPostGLS].Enabled = mEnableSetting;
						chkCommon[mPostParty].Enabled = mEnableSetting;
						chkCommon[mPostExpenses].Enabled = mEnableSetting;

						chkCommon[mPostStatus].CheckState = mCheckedSetting;
						chkCommon[mPostICS].CheckState = mCheckedSetting;
						chkCommon[mPostGLS].CheckState = mCheckedSetting;
						chkCommon[mPostParty].CheckState = mCheckedSetting;
						chkCommon[mPostExpenses].CheckState = mCheckedSetting;
					}
					else
					{
						mEnableSetting = true;

						chkCommon[mPostStatus].Enabled = mEnableSetting;
						chkCommon[mPostICS].Enabled = mEnableSetting;
						chkCommon[mPostGLS].Enabled = mEnableSetting;
						chkCommon[mPostParty].Enabled = mEnableSetting;
						chkCommon[mPostExpenses].Enabled = mEnableSetting;
					}

					if (chkCommon[mPostExpenses].CheckState == CheckState.Checked)
					{
						mEnableSetting = false;
						mCheckedSetting = CheckState.Checked;

						chkCommon[mPostStatus].Enabled = mEnableSetting;
						chkCommon[mPostICS].Enabled = mEnableSetting;
						chkCommon[mPostGLS].Enabled = mEnableSetting;
						chkCommon[mPostParty].Enabled = mEnableSetting;

						chkCommon[mPostStatus].CheckState = mCheckedSetting;
						chkCommon[mPostICS].CheckState = mCheckedSetting;
						chkCommon[mPostGLS].CheckState = mCheckedSetting;
						chkCommon[mPostParty].CheckState = mCheckedSetting;
					}
					else
					{
						mEnableSetting = true;

						chkCommon[mPostStatus].Enabled = mEnableSetting;
						chkCommon[mPostICS].Enabled = mEnableSetting;
						chkCommon[mPostGLS].Enabled = mEnableSetting;
						chkCommon[mPostParty].Enabled = mEnableSetting;
					}

					if (chkCommon[mPostParty].CheckState == CheckState.Checked)
					{
						mEnableSetting = false;
						mCheckedSetting = CheckState.Checked;

						chkCommon[mPostGLS].Enabled = mEnableSetting;

						chkCommon[mPostGLS].CheckState = mCheckedSetting;
					}
					else
					{
						mEnableSetting = true;
						mCheckedSetting = CheckState.Unchecked;

						chkCommon[mPostGLS].Enabled = mEnableSetting;
						chkCommon[mPostGLS].CheckState = mCheckedSetting;
					}

					mLoopStatus_SetPostSequence = false;
				}
			}
		}




		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBDropDown Event cmbParentsList.DataSourceChanged was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void cmbParentsList_DataSourceChanged()
		{
			int cnt = 0;

			cmbParentsList.Width = 0;

			C1.Win.C1TrueDBGrid.C1DisplayColumn withVar = null;
			switch(grdVoucherParentDetails.Col)
			{
				case grdParentCodeColumn : case grdParentNameColumn : 
					if (grdVoucherParentDetails.Col == grdParentCodeColumn)
					{
						//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbParentsList.ListField was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						cmbParentsList.setListField("voucher_type");
						//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsParentList.Sort was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						rsParentList.setSort("voucher_type");
					}
					else
					{
						//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbParentsList.ListField was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						cmbParentsList.setListField("voucher_name");
						//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsParentList.Sort was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						rsParentList.setSort("voucher_name");
					} 
					 
					int tempForEndVar = cmbParentsList.Columns.Count - 1; 
					for (cnt = 0; cnt <= tempForEndVar; cnt++)
					{
						//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
						withVar = cmbParentsList.Splits[0].DisplayColumns[cnt];
						if (cnt < 3)
						{
							if (cnt == 0)
							{
								//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.Column property withVar.Order was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
								withVar.setOrder((grdVoucherParentDetails.Col == grdParentCodeColumn) ? 0 : 1);
								//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
								withVar.Width = grdVoucherParentDetails.Splits[0].DisplayColumns[grdParentCodeColumn].Width;
							}
							else if (cnt == 1)
							{ 
								//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.Column property withVar.Order was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
								withVar.setOrder((grdVoucherParentDetails.Col == grdParentCodeColumn) ? 1 : 0);
								//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
								withVar.Width = grdVoucherParentDetails.Splits[0].DisplayColumns[grdParentNameColumn].Width;
							}
							else if (cnt == 2)
							{ 
								//.Width = grdVoucherParentDetails.Columns(grdBillingTypeColumn).Width
							}
							withVar.Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Near;
							withVar.Visible = true;
							cmbParentsList.Width += withVar.Width / 15;
						}
						else
						{
							withVar.Visible = false;
						}
						withVar.AllowSizing = false;
					} 
					cmbParentsList.Width += 17; 
					cmbParentsList.Height = 167; 
					break;
			}
		}

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBDropDown Event cmbParentsList.DropDownClose was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void cmbParentsList_DropDownClose()
		{
			switch(grdVoucherParentDetails.Col)
			{
				case grdParentCodeColumn : 
					grdVoucherParentDetails.Col = grdParentNameColumn; 
					break;
			}
		}

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBDropDown Event cmbParentsList.RowChange was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void cmbParentsList_RowChange()
		{
			if (grdVoucherParentDetails.Col == grdParentCodeColumn)
			{
				grdVoucherParentDetails.Columns[grdParentNameColumn].Value = cmbParentsList.Columns[cCpParentName].Value;
			}
			else
			{
				grdVoucherParentDetails.Columns[grdParentCodeColumn].Value = cmbParentsList.Columns[cCpParentCode].Value;
			}
			grdVoucherParentDetails.Refresh();
		}

		private void cmdParentDetails_Click(Object eventSender, EventArgs eventArgs)
		{
			if (mFirstGridFocus && CurrentFormMode == SystemVariables.SystemFormModes.frmAddMode)
			{
				DefineVoucherArray(0, true);
			}
			AssignGridLineNumbers();
			//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBGrid property grdVoucherParentDetails.Array was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			grdVoucherParentDetails.setArray(aParentDetails);
			grdVoucherParentDetails.Rebind(true);
			fraCommon[fraVoucherParentDetails].Visible = true;
			tabVoucherDetails.Enabled = false;
			fraCommon[fraVoucherParentDetails].Left = 16;
			fraCommon[fraVoucherParentDetails].Top = 216;
			fraCommon[fraVoucherParentDetails].Height = 153;
			fraCommon[fraVoucherParentDetails].Width = 332;
			grdVoucherParentDetails_GotFocus(grdVoucherParentDetails, new EventArgs());
		}

		private void Form_Initialize()
		{
			mFirstGridFocus = true;
		}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2080
		private void Form_Load()
		{
			try
			{

				const int cGridColor = 0xB8E7F8;
				FirstFocusObject = txtCommon[tcVoucherType];
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
				oThisFormToolBar.ShowDeleteLineButton = true;
				this.WindowState = FormWindowState.Maximized;
				mGetStatus = true;
				//'assign the Image for the toolbar
				//'imagelist are kept on the main form and refered by their key
				//Call DrawToolbar(Me, picFormToolbar, btnFormToolBar(0))
				//Set btnFormToolBar(0).Picture = frmSysMain.imlMainToolBar.ListImages("imgNew").Picture
				//Set btnFormToolBar(1).Picture = frmSysMain.imlMainToolBar.ListImages("imgSave").Picture
				//Set btnFormToolBar(2).Picture = frmSysMain.imlMainToolBar.ListImages("imgDelete").Picture
				//Set btnFormToolBar(3).Picture = frmSysMain.imlMainToolBar.ListImages("imgPrint").Picture
				//Set btnFormToolBar(4).Picture = frmSysMain.imlMainToolBar.ListImages("imgFind").Picture
				//Set btnFormToolBar(5).Picture = frmSysMain.imlMainToolBar.ListImages("imgHelp").Picture
				//Set btnFormToolBar(6).Picture = frmSysMain.imlMainToolBar.ListImages("imgExit").Picture

				//**--make the form visible before all the control gets loaded
				//**--(this way system pretends to be faster in loading forms)

				SystemProcedure.SetLabelCaption(this);

				object[] mObjectId = new object[3];
				mObjectId[cmbDocumentType] = 1026;
				mObjectId[cmbPriceLevel] = 1029;
				mObjectId[cmbReferenceType] = 1027;
				SystemCombo.FillComboWithSystemObjects(cmbCommon, mObjectId);

				//txtCommon(tcRevisedHistoryVoucherCode).BackColor = gDisableColumnBackColor
				//txtCommon(tcICSMasterTableName).BackColor = gDisableColumnBackColor
				//txtCommon(tcICSDetailsTableName).BackColor = gDisableColumnBackColor
				//txtCommon(tcPrintVoucherName).BackColor = gDisableColumnBackColor
				//txtCommon(tcPrintVoucherSQL).BackColor = gDisableColumnBackColor
				optCommonAffectType[OptNone].Checked = true;
				optCommonAffectType[optShowImportLinkedVoucherOnDetails].Checked = true;
				optCommonQtyEffect[optIncreaseStock].Checked = true;
				optCommonQtyEffect[optCrystalReports].Checked = true;
				//txtCommonLabel(dcRevisedHistoryVoucherName).BackColor = gDisableColumnBackColor
				//txtCommonLabel(dcLastLocationNumber).BackColor = gDisableColumnBackColor
				//txtCommonLabel(dcLastCashNumber).BackColor = gDisableColumnBackColor
				//txtCommonLabel(dcLastSalesmanNumber).BackColor = gDisableColumnBackColor
				//txtCommonLabel(dcLastLedgerNumber).BackColor = gDisableColumnBackColor
				//txtCommon(tcAdditionalColIds).BackColor = gDisableColumnBackColor
				//txtCommon(tcPrintVoucherName).BackColor = gDisableColumnBackColor
				//txtCommon(tcPrintVoucherSQL).BackColor = gDisableColumnBackColor

				//Call DefineVoucherArray(0, True)
				SystemGrid.DefineSystemVoucherGrid(grdVoucherParentDetails, true, true, true, (0xFFFFFF).ToString(), (0x0).ToString(), true, false);

				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherParentDetails, "LN", 400, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false);
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherParentDetails, "Parent Voucher Type", 1500, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, true, true, "cmbParentsList");
				SystemGrid.DefineSystemVoucherGridColumn(grdVoucherParentDetails, "Parent Voucher Name", 2700, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, true, false, "cmbParentsList", false, true, false, false, false, false, 200);

				//If gPreferedLanguage = Arabic And rsCompanyProperties("flip_controls_in_arabic").Value = vbTrue Then
				//    Dim oFlipThisForm As New clsFlip
				//
				//    oFlipThisForm.SwapMe Me
				//End If

				this.Show();
				Application.DoEvents();
				//**-------------------------------------------------------------------------------------------

				//Call ShowHideMasterDetails
				//
				//'check if the ledger no is alpha-numeric or not
				//If GetSystemPreferenceSetting("allow_alpha_numeric_ldgr_no") = vbTrue Then
				//    txtCommon(ctLedgerNoIndex).NumericOnly = False
				//    txtCommon(ctLedgerNoIndex).AllowDecimal = True
				//Else
				//    txtCommon(ctLedgerNoIndex).NumericOnly = True
				//    txtCommon(ctLedgerNoIndex).AllowDecimal = False
				//End If
				//
				//'Call SetLedgerGroupType
				//
				//'--get the next new ledger no
				//Call GetNextNumber
				//
				//tabMaster.CurrTab = mBasicMasterDetails
				//mFormIsInitialized = True
				AddRecord();
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, excep.Message, this.Name, "Form Load");
				this.Close();
			}
		}

		//Added By:Rizwan. Date:8/12/2007.
		public void AddRecord()
		{
			//Add a record
			SystemProcedure2.ClearTextBox(this);
			SystemProcedure2.ClearCheckBox(this);
			GetNextNumber();
			txtCommon[tcICSMasterTableName].Text = "ICS_Transaction";
			txtCommon[tcICSDetailsTableName].Text = "ICS_Transaction_Details";

			mCurrentFormMode = SystemVariables.SystemFormModes.frmAddMode; //Change the form mode to addmode
			mSearchValue = ""; //Change the msearchvalue to blank
			mFirstGridFocus = true;

			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{
				//Call ShowHideMasterDetails
				//
				//'check if the ledger no is alpha-numeric or not
				//'If GetSystemPreferenceSetting("allow_alpha_numeric_ldgr_no") = vbTrue Then
				//'    txtCommon(ctLedgerNoIndex).NumericOnly = False
				//'    txtCommon(ctLedgerNoIndex).AllowDecimal = True
				//'Else
				//'    txtCommon(ctLedgerNoIndex).NumericOnly = True
				//'    txtCommon(ctLedgerNoIndex).AllowDecimal = False
				//'End If
				//
				//'Call SetLedgerGroupType
				//
				//'--get the next new ledger no
				//Call DefineVoucherArray(0, True)
				//Call AssignGridLineNumbers
				//grdVoucherParentDetails.ReBind
				grdPrintTask.Rebind(true);
				GetNextNumber();
				tabVoucherDetails.CurrTab = Convert.ToInt16(cBasicMasterDetails);
				optCommonAffectType[optShowImportLinkedVoucherOnHeader].Checked = true;
				//mFormIsInitialized = True

				return;

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, Information.Err().Description, this.Name, "AddRecord");
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}
		//Added By:Rizwan. Date:8/12/2007.
		private void GetNextNumber()
		{

			txtCommon[tcVoucherType].Text = SystemProcedure2.GetNewNumber("ICS_Transaction_Types", "voucher_type");
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

			string mysql = " select top 1 voucher_type from ICS_Transaction_Types ivt";
			mysql = mysql + " inner join SM_Preferences sf on sf.preference_id = ivt.feature_id";
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
		private void DefineVoucherArray(int pMaximumRows, bool pClearArray = false)
		{
			if (pClearArray)
			{
				//UPGRADE_ISSUE: (2064) XArrayDBObject.XArrayDB method aParentDetails.Clear was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				aParentDetails.Clear();
			}
			aParentDetails.RedimXArray(new int[]{pMaximumRows, 9}, new int[]{0, 0});
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

				if (this.ActiveControl.Name != "txtCommon")
				{
					SystemForms.SystemFormKeyDown(this, ref KeyCode, Shift, this.ActiveControl.Name);
				}
				else
				{
					SystemForms.SystemFormKeyDown(this, ref KeyCode, Shift, "txtCommon#" + ControlArrayHelper.GetControlIndex(this.ActiveControl).ToString().Trim());
				}

				//''(Alt + -> ) or ( Alt + <- )
				if (Shift == 4 && (KeyCode == 37 || KeyCode == 39))
				{
					//If Not IsItEmpty(mSearchValue, NumberType) Then
					//    If CLng(mSearchValue) > 0 Then
					if (!this.UserAccess.AllowUserDisplay)
					{
						MessageBox.Show(SystemConstants.msg8, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
						return;
					}

					RecordNavigate(KeyCode, ReflectionHelper.GetPrimitiveValue<int>(mRecordNavigateSearchValue));
					KeyCode = 0;
					//    End If
					//End If
				}

				//Refresh the ICS_Item recordset when F5 is pressed
				if (Shift == 0 && KeyCode == 116)
				{
					if (this.ActiveControl.Name.ToLower() == ("grdVoucherParentDetails").ToLower() && !mFirstGridFocus)
					{
						RefreshParentRecordset(false);
						KeyCode = 0;
					}
				}
			}
			finally
			{
				eventArgs.Handled = KeyCode == 0;
			}

		}
		public void CloseForm()
		{
			this.Close();
			Application.DoEvents();
		}

		private void Form_Closed(Object eventSender, EventArgs eventArgs)
		{
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{

				SystemMenu.RemoveMeFromWindowList(Conversion.Str(this.Handle.ToInt32()));

				rsParentList = null;
				aParentDetails = null;
				UserAccess = null;
				frmICSVoucherTypes.DefInstance = null;
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
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

		private void grdVoucherParentDetails_GotFocus(Object eventSender, EventArgs eventArgs)
		{
			//Call InitialiseParentVoucherDetailsGrid
			if (mFirstGridFocus)
			{
				if (Convert.ToString(cmbParentsList.Tag) == "")
				{
					SystemGrid.DefineSystemGridCombo(cmbParentsList);
					cmbParentsList.Tag = "OK";
				}

				RefreshParentRecordset();
				//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbParentsList.DataSource was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				cmbParentsList.setDataSource((msdatasrc.DataSource) rsParentList);
				mFirstGridFocus = false;
				//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBGrid method grdVoucherParentDetails.PostMsg was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				grdVoucherParentDetails.PostMsg(1);
			}
		}
		private void AssignGridLineNumbers()
		{
			int cnt = 0;
			int tempForEndVar = aParentDetails.GetLength(0) - 1;
			for (cnt = 0; cnt <= tempForEndVar; cnt++)
			{
				aParentDetails.SetValue(cnt + 1, cnt, grdLineNoColumn);
			}
		}
		private void RefreshParentRecordset(bool pCallComboRowChange = true)
		{
			string mysql = "";

			if (mFirstGridFocus)
			{
				mysql = "select voucher_Type, " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_voucher_name as voucher_name" : "a_voucher_name as voucher_name");
				mysql = mysql + " from ICS_Transaction_Types ";
				//    If Not IsItEmpty(mSearchValue, NumberType) Then
				//        mysql = mysql & "where voucher_type <> " & mSearchValue
				//    End If
				mysql = mysql + " order by 1";
				rsParentList = new DataSet();
				//UPGRADE_ISSUE: (2064) ADODB.CursorLocationEnum property CursorLocationEnum.adUseClient was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsParentList.CursorLocation was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				rsParentList.setCursorLocation(UpgradeStubs.ADODB_CursorLocationEnum.getadUseClient());
				SqlDataAdapter adap = new SqlDataAdapter(mysql, SystemVariables.gConn);
				rsParentList.Tables.Clear();
				adap.Fill(rsParentList);
			}
			else
			{
				//UPGRADE_ISSUE: (2064) ADODB.Recordset method rsParentList.Requery was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				rsParentList.Requery(-1);
			}
		}

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBGrid Event grdVoucherParentDetails.OnAddNew was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void grdVoucherParentDetails_OnAddNew()
		{
			grdVoucherParentDetails.Columns[grdLineNoColumn].Text = (grdVoucherParentDetails.RowCount + 1).ToString();
		}

		private void grdVoucherParentDetails_RowColChange(object eventSender, C1.Win.C1TrueDBGrid.RowColChangeEventArgs eventArgs)
		{
			int LastRow = eventArgs.LastRow;
			int LastCol = eventArgs.LastCol;
			if (grdVoucherParentDetails.Col > 0 && LastCol > 0 && !mFirstGridFocus)
			{
				switch(grdVoucherParentDetails.Col)
				{
					case grdParentCodeColumn : case grdParentNameColumn : 
						//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbParentsList.DataSource was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064 
						cmbParentsList.setDataSource((msdatasrc.DataSource) rsParentList); 
						break;
				}
			}
		}

		private bool isInitializingComponent;
		private void optCommonAffectType_CheckedChanged(Object eventSender, EventArgs eventArgs)
		{
			int Index = Array.IndexOf(this.optCommonAffectType, eventSender);
			if (((RadioButton) eventSender).Checked)
			{
				if (isInitializingComponent)
				{
					return;
				}
				switch(Index)
				{
					case optShowImportLinkedVoucherOnHeader : case optShowImportLinkedVoucherOnDetails : case optHideImportLinkedVoucher : 
						 
						//---- to change the more link detail button ----Moiz Hakimi - 21/08/2008 
						cmdParentDetails.Enabled = optCommonAffectType[optShowImportLinkedVoucherOnDetails].Checked; 
						if (!optCommonAffectType[optShowImportLinkedVoucherOnDetails].Checked)
						{
							chkCommon[chkBindToParent].CheckState = CheckState.Unchecked;
							chkCommon[chkBindToParentHeaderLocation].CheckState = CheckState.Unchecked;
						} 
						 
						fraCommon[fraLegacyLinks].Enabled = optCommonAffectType[optShowImportLinkedVoucherOnHeader].Checked; 
						fraCommon[fraLinks].Enabled = optCommonAffectType[optShowImportLinkedVoucherOnDetails].Checked; 

						 
						//        txtCommon(tcICSMasterTableName).BackColor = IIf(optCommonAffectType(optShowImportLinkedVoucherOnHeader).Value = True, &HEFEFEF, gDisableColumnBackColor) 
						//        txtCommon(tcICSDetailsTableName).BackColor = IIf(optCommonAffectType(optShowImportLinkedVoucherOnHeader).Value = True, &HEFEFEF, gDisableColumnBackColor) 
						//        txtCommon(tcICSParentMasterTableName).BackColor = IIf(optCommonAffectType(optShowImportLinkedVoucherOnHeader).Value = True, &HEFEFEF, gDisableColumnBackColor) 
						//        txtCommon(tcICSParentDetailsTableName).BackColor = IIf(optCommonAffectType(optShowImportLinkedVoucherOnHeader).Value = True, &HEFEFEF, gDisableColumnBackColor) 
						//        txtCommon(tcParentICSCode).BackColor = IIf(optCommonAffectType(optShowImportLinkedVoucherOnHeader).Value = True, &HEFEFEF, gDisableColumnBackColor) 
						//        txtCommon(tcChildICSCode).BackColor = IIf(optCommonAffectType(optShowImportLinkedVoucherOnHeader).Value = True, &HEFEFEF, gDisableColumnBackColor) 
						//        txtCommonLabel(dcParentICSName).BackColor = IIf(optCommonAffectType(optShowImportLinkedVoucherOnHeader).Value = True, &HEFEFEF, gDisableColumnBackColor) 
						//        txtCommonLabel(dcChildICSName).BackColor = IIf(optCommonAffectType(optShowImportLinkedVoucherOnHeader).Value = True, &HEFEFEF, gDisableColumnBackColor) 
						//        If Index = optShowImportLinkedVoucherOnDetails Or Index = optHideImportLinkedVoucher Then 
						//            txtCommon(tcICSParentMasterTableName).Text = "" 
						//            txtCommon(tcICSParentDetailsTableName).Text = "" 
						//            txtCommon(tcParentICSCode).Text = "" 
						//            txtCommon(tcChildICSCode).Text = "" 
						//            txtCommonLabel(dcParentICSName).Text = "" 
						//            txtCommonLabel(dcChildICSName).Text = "" 
						//        End If 
						break;
					default:
						return;
				}
			}
		}

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
					case optCrystalReports : case optXMLReports : 
						txtCommon[tcReportCode].Enabled = optCommonQtyEffect[optCrystalReports].Checked; 
						txtCommonLabel[dcReportName].Enabled = optCommonQtyEffect[optCrystalReports].Checked; 
						grdPrintTask.Enabled = optCommonQtyEffect[optCrystalReports].Checked; 
						//txtCommon(tcEntryCode).Enabled = optCommonQtyEffect(optCrystalReports).Value 
						//txtCommonLabel(dcEntryName).Enabled = optCommonQtyEffect(optCrystalReports).Value 
						//        chkCommon(chkAdditionalColIDs).Enabled = optCommonQtyEffect(optCrystalReports).Value 
						//        txtCommon(tcAdditionalColIds).Enabled = optCommonQtyEffect(optCrystalReports).Value 
						 
						//        txtCommon(tcReportCode).BackColor = IIf(optCommonQtyEffect(optCrystalReports).Value = True, &HEFEFEF, gDisableColumnBackColor) 
						//        txtCommonLabel(dcReportName).BackColor = IIf(optCommonQtyEffect(optCrystalReports).Value = True, &HEFEFEF, gDisableColumnBackColor) 
						//        txtCommon(tcEntryCode).BackColor = IIf(optCommonQtyEffect(optCrystalReports).Value = True, &HEFEFEF, gDisableColumnBackColor) 
						//        txtCommonLabel(dcEntryName).BackColor = IIf(optCommonQtyEffect(optCrystalReports).Value = True, &HEFEFEF, gDisableColumnBackColor) 
						//        txtCommon(tcAdditionalColIds).BackColor = IIf(optCommonQtyEffect(optCrystalReports).Value = True, &HEFEFEF, gDisableColumnBackColor) 
						// 
						//        txtCommon(tcPrintVoucherName).Enabled = optCommonQtyEffect(optXMLReports).Value 
						//        txtCommon(tcPrintVoucherSQL).Enabled = optCommonQtyEffect(optXMLReports).Value 
						//        txtCommon(tcPrintVoucherName).BackColor = IIf(optCommonQtyEffect(optXMLReports).Value = True, &HEFEFEF, gDisableColumnBackColor) 
						//        txtCommon(tcPrintVoucherSQL).BackColor = IIf(optCommonQtyEffect(optXMLReports).Value = True, &HEFEFEF, gDisableColumnBackColor) 
						break;
					default:
						return;
				}
			}
		}


		public void findRecord()
		{

			//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(200));
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(mTempSearchValue))
			{
				//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mSearchValue = ReflectionHelper.GetPrimitiveValue(((Array) mTempSearchValue).GetValue(0));
				GetRecord(mSearchValue);
			}
		}
		//Added by:Rizwan. Date: 5/12/2007
		public void FindRoutine(string pObjectName)
		{
			object mTempSearchValue = null;

			if ((pObjectName.IndexOf('#') + 1) == 0)
			{
				return;
			}

			string mObjectName = pObjectName.Substring(0, Math.Min(pObjectName.IndexOf('#'), pObjectName.Length));
			int mIndex = Convert.ToInt32(Double.Parse(pObjectName.Substring(pObjectName.IndexOf('#') + 1)));

			if (mObjectName == "txtCommon")
			{
				txtCommon[mIndex].Text = "";
				switch(mIndex)
				{
					case tcParentCode : 
						//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
						mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(215, "1803")); 
						break;
					case tcModuleCode : 
						//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
						mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(50, "723")); 
						break;
					case tcPreferenceCode : 
						//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
						mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(1000131, "2001")); 
						break;
					case tcFindCode : 
						//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
						mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(56, "2010")); 
						break;
					case tcParentICSCode : case tcChildICSCode : case tcRevisedHistoryVoucherCode : case tcLinkedAssemblyGroupAdjustVoucherCd : case tcDentedStockGeneratedLinkedVoucherCd : 
						//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
						mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(200, "693")); 
						break;
					case tcReportCode : 
						//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
						mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(57, "2019")); 
						//        Case tcEntryCode 
						//            mTempSearchValue = FindItem(58, "2037") 
						break;
					case tcGLVoucherCd : case tcGLJournalVoucherCd : case tcGLPaymentVoucherCd : case tcGLReceiptVoucherCd : 
						//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
						mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(205, "2044")); 
						break;
					case tcVoucherType : 
						findRecord(); 
						return;
					default:
						return;
				}
			}

			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(mTempSearchValue))
			{
				if (mObjectName == "txtCommon")
				{
					//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					txtCommon[mIndex].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(1));
					txtCommon_Leave(txtCommon[mIndex], new EventArgs());
				}
			}

			SystemVariables.gSkipTextBoxLostFocus = false;
		}
		public bool deleteRecord()
		{
			bool result = false;
			string mysql = "";
			object mReturnValue = null;
			//Delete the Record
			try
			{

				mysql = "select top 1 entry_id from ICS_Transaction  where voucher_type=" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(mReturnValue))
				{
					MessageBox.Show("Inventory Transaction exists , cannot delete the Voucher Type", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					return false;
				}

				mysql = "select protected from ICS_Transaction_Types where voucher_type=" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
				if (ReflectionHelper.GetPrimitiveValue<bool>(mReturnValue))
				{
					MessageBox.Show(SystemConstants.msg12, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return false;
				}

				mysql = " delete from ICS_Transaction_Types where voucher_type=" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
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

		private void tabVoucherDetails_ClickEvent(Object eventSender, EventArgs eventArgs)
		{
			try
			{

				switch(tabVoucherDetails.CurrTab)
				{
					case mPrintingDetails : 
						ShowPrintingDetailsTab(); 
						 
						break;
				}
			}
			catch (System.Exception excep)
			{

				MessageBox.Show(excep.Message, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
				FirstFocusObject.Focus();
			}
		}

		private void txtCommon_Change(Object Sender, EventArgs e)
		{
			if (txtCommon[tcVoucherGridBackColor].Text != "")
			{
				txtCommon[tcColor].BackColor = ColorTranslator.FromOle(Convert.ToInt32(Conversion.Val(txtCommon[tcVoucherGridBackColor].Text)));
			}
			else
			{
				txtCommon[tcColor].BackColor = Color.White;
			}
		}

		private void txtCommon_DropButtonClick(Object Sender, EventArgs e)
		{
			int Index = Array.IndexOf(this.txtCommon, Sender);
			object mTempSearchValue = null;
			if (Index == tcVoucherGridBackColor)
			{
				GetGridColor();
			}
			else if (Index == tcDefaultCashCode)
			{ 
				//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(1001000, "2"));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(mTempSearchValue))
				{
					//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					txtCommon[tcDefaultCashCode].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(1));
				}
			}
			else if (Index == tcDefaultCreditCardCode)
			{ 
				//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(1001000, "2"));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(mTempSearchValue))
				{
					//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					txtCommon[tcDefaultCreditCardCode].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(1));
				}
			}
			else
			{
				SystemForms.ToolBarButtonClick(this, "FindRoutine", "txtCommon#" + Index.ToString().Trim());
			}
		}
		private void GetGridColor()
		{
			dlgColorColor.ShowDialog();
			if (dlgColorColor.Color != Color.Black)
			{
				txtCommon[tcVoucherGridBackColor].Text = Conversion.Val(ColorTranslator.ToOle(dlgColorColor.Color).ToString()).ToString();
				//txtCommon(tcColor).BackColor = dlgColor.Color
			}
		}
		private void txtCommon_Leave(Object eventSender, EventArgs eventArgs)
		{
			int Index = Array.IndexOf(this.txtCommon, eventSender);
			//If txtCommon(Index).Text <> "" Then
			GetValuesForLabel(Index);
			//End If
		}

		private void GetValuesForLabel(int pIndex)
		{
			try
			{
				object mTempValue = null;
				string mysql = "";

				//If Not IsItEmpty(txtCommon(pIndex).Text, StringType) Then
				switch(pIndex)
				{
					case tcParentCode : 
						mysql = "select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_txn_desc,TXN_Type" : "a_txn_desc,TXN_Type"); 
						mysql = mysql + " from ICS_Transaction_Master_Types  "; 
						mysql = mysql + " where TXN_type =" + ((txtCommon[pIndex].Text == "") ? "0" : txtCommon[pIndex].Text); 
						mSetIndexValue = dcParentName; 
						break;
					case tcModuleCode : 
						mysql = "select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_group_name,Module_id" : "a_group_name,Module_id"); 
						mysql = mysql + " from SM_MODULES  "; 
						mysql = mysql + " where Module_id =" + ((txtCommon[pIndex].Text == "") ? "0" : txtCommon[pIndex].Text); 
						 
						mSetIndexValue = dcModuleName; 
						break;
					case tcPreferenceCode : 
						mysql = "select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_preference_name,preference_id" : "a_preference_name,preference_id"); 
						mysql = mysql + " from SM_Preferences  "; 
						mysql = mysql + " where preference_id ='" + txtCommon[pIndex].Text + "'"; 
						 
						mSetIndexValue = dcFeatureName; 
						break;
					case tcFindCode : 
						mysql = "select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_find_name,Find_id" : "a_find_name,Find_id"); 
						mysql = mysql + " from SM_FIND "; 
						mysql = mysql + " where Find_id ='" + txtCommon[pIndex].Text + "'"; 
						 
						mSetIndexValue = dcFindName; 
						break;
					case tcParentICSCode : case tcChildICSCode : 
						mysql = "select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_voucher_name,Voucher_type" : "a_voucher_name,voucher_type"); 
						mysql = mysql + " from ICS_Transaction_Types "; 
						mysql = mysql + " where Voucher_type =" + ((txtCommon[pIndex].Text == "") ? "0" : txtCommon[pIndex].Text); 
						 
						mSetIndexValue = (pIndex == tcParentICSCode) ? dcParentICSName : dcChildICSName; 
						break;
					case tcLinkedAssemblyGroupAdjustVoucherCd : case tcDentedStockGeneratedLinkedVoucherCd : 
						mysql = "select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_voucher_name,Voucher_type" : "a_voucher_name,voucher_type"); 
						mysql = mysql + " from ICS_Transaction_Types "; 
						mysql = mysql + " where Voucher_type =" + ((txtCommon[pIndex].Text == "") ? "0" : txtCommon[pIndex].Text); 
						 
						mSetIndexValue = (pIndex == tcLinkedAssemblyGroupAdjustVoucherCd) ? dcLinkedAssemblyGroupAdjustVoucherCd : dcDentedStockGeneratedLinkedVoucherCd; 
						break;
					case tcReportCode : 
						mysql = "select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_report_name,Report_id" : "a_report_name,Report_id"); 
						mysql = mysql + " from SM_REPORTS "; 
						mysql = mysql + " where Report_id =" + ((txtCommon[pIndex].Text == "") ? "0" : txtCommon[pIndex].Text); 
						 
						mSetIndexValue = dcReportName; 
						//        Case tcEntryCode 
						//            mysql = "select " & IIf(gPreferedLanguage = English, "l_field_caption,Column_id", "l_field_caption,Column_id") 
						//            mysql = mysql & " from SM_REPORT_FIELDS " 
						//            mysql = mysql & " where Column_id ='" & txtCommon(pIndex).Text & "'" 
						// 
						//            mSetIndexValue = dcEntryName 
						break;
					case tcRevisedHistoryVoucherCode : 
						mysql = "select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_voucher_name,Voucher_type" : "a_voucher_name,voucher_type"); 
						mysql = mysql + " from ICS_Transaction_Types "; 
						mysql = mysql + " where Voucher_type =" + ((txtCommon[pIndex].Text == "") ? "0" : txtCommon[pIndex].Text); 
						 
						mSetIndexValue = dcRevisedHistoryVoucherName; 
						break;
					case tcGLVoucherCd : case tcGLReceiptVoucherCd : 
						mysql = "select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_voucher_name,Voucher_type" : "a_voucher_name,voucher_type"); 
						mysql = mysql + " from gl_accnt_voucher_types "; 
						mysql = mysql + " where Voucher_type =" + ((txtCommon[pIndex].Text == "") ? "0" : txtCommon[pIndex].Text); 
						 
						mSetIndexValue = (pIndex == tcGLVoucherCd) ? dcGLVoucherCd : dcGLReceiptVoucherCd; 
						break;
					case tcGLJournalVoucherCd : case tcGLPaymentVoucherCd : 
						mysql = "select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_voucher_name,Voucher_type" : "a_voucher_name,voucher_type"); 
						mysql = mysql + " from gl_accnt_voucher_types "; 
						mysql = mysql + " where Voucher_type =" + ((txtCommon[pIndex].Text == "") ? "0" : txtCommon[pIndex].Text); 
						 
						mSetIndexValue = (pIndex == tcGLJournalVoucherCd) ? dcGLJournalVoucherCd : dcGLPaymentVoucherCd; 
						//        Case tcVoucherType 
						//            Call GetRecord(txtCommon(pIndex).Text) 
						break;
					default:
						return;
				}
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(mTempValue))
				{
					//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					txtCommonLabel[mSetIndexValue].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(0));
				}
				else
				{
					txtCommonLabel[mSetIndexValue].Text = "";
					//Err.Raise -9990002
				}
				//End If
				SystemVariables.gSkipTextBoxLostFocus = false;
			}
			catch (System.Exception excep)
			{
				int mReturnErrorType = 0;
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				mReturnErrorType = SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, excep.Message, this.Name, "GetRecord", SystemConstants.msg10);
				if (mReturnErrorType == 4)
				{
					//if the code is not found
					txtCommon[pIndex].Focus();
				}
				else
				{
					//
				}
			}
		}

		private void GetRecord(object pSearchValue)
		{
			SqlDataReader rsLocalRec = null;
			object mTempReturnValue = null;

			if (SystemProcedure2.IsItEmpty(pSearchValue, SystemVariables.DataType.NumberType))
			{
				return;
			}
			SystemProcedure2.ClearTextBox(this);
			SystemProcedure2.ClearCheckBox(this);
			txtCommon[tcICSMasterTableName].Text = "ICS_Transaction";
			txtCommon[tcICSDetailsTableName].Text = "ICS_Transaction_Details";

			//UPGRADE_WARNING: (1068) pSearchValue of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			mRecordNavigateSearchValue = ReflectionHelper.GetPrimitiveValue(pSearchValue);
			//mFirstGridFocus = True
			DefineVoucherArray(0, true);
			//On Error GoTo eFoundError
			mGetStatus = false;

			string mysql = " select * from ICS_Transaction_Types where voucher_type=" + ReflectionHelper.GetPrimitiveValue<string>(pSearchValue);
			SqlCommand sqlCommand = new SqlCommand(mysql, SystemVariables.gConn);
			rsLocalRec = sqlCommand.ExecuteReader();
			if (rsLocalRec.Read())
			{
				mSearchValue = rsLocalRec["voucher_type"];
				txtCommon[tcVoucherType].Text = Convert.ToString(rsLocalRec["voucher_type"]);

				txtCommon[tcLVouchername].Text = Convert.ToString(rsLocalRec["L_Voucher_Name"]);
				txtCommon[tcAVouchername].Text = Convert.ToString(rsLocalRec["A_Voucher_Name"]);
				txtCommon[tcLShortName].Text = Convert.ToString(rsLocalRec["L_Short_Name"]);
				txtCommon[tcAShortName].Text = Convert.ToString(rsLocalRec["A_Short_Name"]);

				//-------------Basic Details---------------------------------------

				txtCommon[tcParentCode].Text = Convert.ToString(rsLocalRec["Parent_type"]);
				GetValuesForLabel(tcParentCode);

				txtCommon[tcModuleCode].Text = Convert.ToString(rsLocalRec["Module_Id"]);
				GetValuesForLabel(tcModuleCode);

				txtCommon[tcFindCode].Text = Convert.ToString(rsLocalRec["Find_Id"]);
				GetValuesForLabel(tcFindCode);

				txtCommon[tcPreferenceCode].Text = Convert.ToString(rsLocalRec["Feature_Id"]);
				GetValuesForLabel(tcPreferenceCode);

				SystemCombo.SearchCombo(cmbCommon[cmbDocumentType], Convert.ToInt32(rsLocalRec["Document_Type"]));
				optCommonAffectType[OptNone].Checked = true;
				optCommonAffectType[optOnHandStock].Checked = Convert.ToBoolean(rsLocalRec["Affect_On_Hand_Stock"]);
				optCommonAffectType[optInTransitStock].Checked = Convert.ToBoolean(rsLocalRec["Affect_In_Transit_Stock"]);
				optCommonAffectType[optOnOrderPurchaseStock].Checked = Convert.ToBoolean(rsLocalRec["Affect_On_Order_Stock"]);
				optCommonAffectType[optAllocatedStock].Checked = Convert.ToBoolean(rsLocalRec["Affect_Allocated_Stock"]);
				optCommonAffectType[optOnOrderSalesStock].Checked = Convert.ToBoolean(rsLocalRec["Affect_On_Order_Stock_Of_Sales"]);
				optCommonAffectType[optSalesreturnInTransitStock].Checked = Convert.ToBoolean(rsLocalRec["Affect_Stock_Return_In_Transit"]);
				optCommonAffectType[optAdvancedBookedStock].Checked = Convert.ToBoolean(rsLocalRec["Affect_Advanced_Booked_Stock"]);
				optCommonAffectType[optReservedStock].Checked = Convert.ToBoolean(rsLocalRec["Affect_Reserved_Stock"]);

				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				chkCommon[chkAffectGLS].CheckState = (CheckState) ((Convert.ToBoolean(rsLocalRec["Affect_GLS"])) ? 1 : 0);
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				chkCommon[chkAffectICS].CheckState = (CheckState) ((Convert.ToBoolean(rsLocalRec["Affect_ICS"])) ? 1 : 0);
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				chkCommon[chkAffectCost].CheckState = (CheckState) ((Convert.ToBoolean(rsLocalRec["Affect_Cost"])) ? 1 : 0);
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				chkCommon[chkAffectOpeningValue].CheckState = (CheckState) ((Convert.ToBoolean(rsLocalRec["Affect_Opening_Value"])) ? 1 : 0);
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				chkCommon[chkStoreToStore].CheckState = (CheckState) ((Convert.ToBoolean(rsLocalRec["Locat_To_Locat"])) ? 1 : 0);
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				chkCommon[chkMultipleLocation].CheckState = (CheckState) ((Convert.ToBoolean(rsLocalRec["Generate_On_Multiple_Location"])) ? 1 : 0);

				if (Convert.ToString(rsLocalRec["Add_Or_Less"]) == "A")
				{
					optCommonQtyEffect[optIncreaseStock].Checked = true;
				}
				else
				{
					optCommonQtyEffect[optDecreaseStock].Checked = true;
				}

				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				chkCommon[chkShow].CheckState = (CheckState) ((Convert.ToBoolean(rsLocalRec["Show"])) ? 1 : 0);
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				chkCommon[chkShowInMenu].CheckState = (CheckState) ((Convert.ToBoolean(rsLocalRec["Show_in_menu"])) ? 1 : 0);
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				chkCommon[chkAutogenerateVocherNo].CheckState = (CheckState) ((Convert.ToBoolean(rsLocalRec["Auto_Generate_Voucher_No"])) ? 1 : 0);
				//-------------------------------------------------------------

				//-------------Link Details------------------------------------
				if (Convert.ToBoolean(rsLocalRec["Show_Import_Linked_Voucher_On_Header"]))
				{
					optCommonAffectType[optShowImportLinkedVoucherOnHeader].Checked = true;
					fraCommon[fraLegacyLinks].Enabled = true;
					//txtCommon(tcICSMasterTableName).Text = IIf(IsNull(.Fields("Linked_ICS_Master_Table_Name")), "", .Fields("Linked_ICS_Master_Table_Name"))
					//txtCommon(tcICSDetailsTableName).Text = IIf(IsNull(.Fields("Linked_ICS_Details_Table_Name")), "", .Fields("Linked_ICS_Details_Table_Name"))
				}
				else if (Convert.ToBoolean(rsLocalRec["Show_Import_Linked_Voucher_In_Details"]))
				{ 
					fraCommon[fraLinks].Enabled = true;
					optCommonAffectType[optShowImportLinkedVoucherOnDetails].Checked = true;
				}
				else
				{
					optCommonAffectType[optHideImportLinkedVoucher].Checked = true;
				}

				txtCommon[tcICSParentMasterTableName].Text = (Convert.IsDBNull(rsLocalRec["Linked_ICS_Parent_Master_Table_Name"])) ? "" : Convert.ToString(rsLocalRec["Linked_ICS_Parent_Master_Table_Name"]);
				txtCommon[tcICSParentDetailsTableName].Text = (Convert.IsDBNull(rsLocalRec["Linked_ICS_Parent_Details_Table_Name"])) ? "" : Convert.ToString(rsLocalRec["Linked_ICS_Parent_Details_Table_Name"]);

				txtCommon[tcParentICSCode].Text = (Convert.IsDBNull(rsLocalRec["Linked_Parent_ICS_Voucher_Type_Cd"])) ? "" : Convert.ToString(rsLocalRec["Linked_Parent_ICS_Voucher_Type_Cd"]);
				GetValuesForLabel(tcParentICSCode);

				txtCommon[tcChildICSCode].Text = (Convert.IsDBNull(rsLocalRec["Linked_Child_ICS_Voucher_Type_Cd"])) ? "" : Convert.ToString(rsLocalRec["Linked_Child_ICS_Voucher_Type_Cd"]);
				GetValuesForLabel(tcChildICSCode);

				txtCommon[tcLinkedAssemblyGroupAdjustVoucherCd].Text = (Convert.IsDBNull(rsLocalRec["Linked_Assembly_Group_Adjust_Voucher_Type"])) ? "" : Convert.ToString(rsLocalRec["Linked_Assembly_Group_Adjust_Voucher_Type"]);
				GetValuesForLabel(tcLinkedAssemblyGroupAdjustVoucherCd);

				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				chkCommon[chkBindToParent].CheckState = (CheckState) ((Convert.ToBoolean(rsLocalRec["Bind_To_Parent"])) ? 1 : 0);
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				chkCommon[chkBindToParentHeaderLocation].CheckState = (CheckState) ((Convert.ToBoolean(rsLocalRec["Bind_To_Parent_Header_Location"])) ? 1 : 0);
				GetVoucherparentDetails();

				txtCommon[tcDentedStockGeneratedLinkedVoucherCd].Text = (Convert.IsDBNull(rsLocalRec["Dented_Stock_Generated_Linked_Voucher_Type"])) ? "" : Convert.ToString(rsLocalRec["Dented_Stock_Generated_Linked_Voucher_Type"]);
				GetValuesForLabel(tcDentedStockGeneratedLinkedVoucherCd);

				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				chkCommon[chkAutoPostStockGeneratedVocherNo].CheckState = (CheckState) ((Convert.ToBoolean(rsLocalRec["Auto_Post_Stock_Generated_Linked_Voucher_Type"])) ? 1 : 0);

				txtCommon[tcGLVoucherCd].Text = (Convert.IsDBNull(rsLocalRec["Linked_GL_Voucher_Type_Cd"])) ? "" : Convert.ToString(rsLocalRec["Linked_GL_Voucher_Type_Cd"]);
				GetValuesForLabel(tcGLVoucherCd);
				txtCommon[tcGLReceiptVoucherCd].Text = (Convert.IsDBNull(rsLocalRec["Linked_GL_Receipt_Voucher_Type_Cd"])) ? "" : Convert.ToString(rsLocalRec["Linked_GL_Receipt_Voucher_Type_Cd"]);
				GetValuesForLabel(tcGLReceiptVoucherCd);
				txtCommon[tcGLPaymentVoucherCd].Text = Convert.ToString(rsLocalRec["Linked_GL_Payment_Voucher_Type_Cd"]);
				GetValuesForLabel(tcGLPaymentVoucherCd);
				txtCommon[tcGLJournalVoucherCd].Text = Convert.ToString(rsLocalRec["Linked_GL_Journal_Voucher_Type_Cd"]);
				GetValuesForLabel(tcGLJournalVoucherCd);

				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				chkCommon[chkEnableRateWhenLinked].CheckState = (CheckState) ((Convert.ToBoolean(rsLocalRec["Enable_Rate_When_Linked"])) ? 1 : 0);
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				chkCommon[chkEnablePercentDiscountWhenLinked].CheckState = (CheckState) ((Convert.ToBoolean(rsLocalRec["Enable_Percent_Discount_On_Header_When_Linked"])) ? 1 : 0);
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				chkCommon[chkEnableDiscountWhenLinked].CheckState = (CheckState) ((Convert.ToBoolean(rsLocalRec["Enable_Discount_When_Linked"])) ? 1 : 0);
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				chkCommon[chkEnableAmountWhenLinked].CheckState = (CheckState) ((Convert.ToBoolean(rsLocalRec["Enable_Amount_When_Linked"])) ? 1 : 0);
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				chkCommon[chkEnableCashCreditWhenLinked].CheckState = (CheckState) ((Convert.ToBoolean(rsLocalRec["Enable_Cash_Credit_On_Header_When_Linked"])) ? 1 : 0);
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				chkCommon[chkEnableExcessQtyWhenLinked].CheckState = (CheckState) ((Convert.ToBoolean(rsLocalRec["Allow_Excess_Qty_When_Linked"])) ? 1 : 0);
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				chkCommon[chkAutoGeneratedLinkedVoucher].CheckState = (CheckState) ((Convert.ToBoolean(rsLocalRec["Auto_Generate_Linked_Voucher"])) ? 1 : 0);
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				chkCommon[chkAutoGeneratedLinkedVoucherAllLoc].CheckState = (CheckState) ((Convert.ToBoolean(rsLocalRec["Auto_Generate_Linked_Voucher_All_Location"])) ? 1 : 0);
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				chkCommon[chkAutoGeneratedLinkedVoucherForCash].CheckState = (CheckState) ((Convert.ToBoolean(rsLocalRec["Enable_Auto_Generate_Linked_Voucher_For_Cash_Transaction"])) ? 1 : 0);
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				chkCommon[chkImportNonInventoryForParentVoucher].CheckState = (CheckState) ((Convert.ToBoolean(rsLocalRec["Import_Non_Inventory_From_Parent_Voucher"])) ? 1 : 0);
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				chkCommon[chkPreserveGridValueDuringImport].CheckState = (CheckState) ((Convert.ToBoolean(rsLocalRec["Preserve_Grid_Value_During_Import"])) ? 1 : 0);
				//-------------------------------------------------------------

				//-------------Show/Hide Details-------------------------------
				//Header Section
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				chkCommon[chkShowLocation].CheckState = (CheckState) ((Convert.ToBoolean(rsLocalRec["Show_Location_On_Header"])) ? 1 : 0);
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				chkCommon[chkShowLedger].CheckState = (CheckState) ((Convert.ToBoolean(rsLocalRec["Show_Ledger_On_Header"])) ? 1 : 0);
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				chkCommon[chkShowCashCredit].CheckState = (CheckState) ((Convert.ToBoolean(rsLocalRec["Show_Cash_Credit_On_Header"])) ? 1 : 0);
				//chkCommon(chkShowImportLinkedVchr).Value = IIf(.Fields("Show_Import_Linked_Voucher_On_Header").Value = True, 1, 0)
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				chkCommon[chkShowAdditionalVoucherDetails].CheckState = (CheckState) ((Convert.ToBoolean(rsLocalRec["Show_Additional_Voucher_Details"])) ? 1 : 0);
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				chkCommon[chkRemarks].CheckState = (CheckState) ((Convert.ToBoolean(rsLocalRec["Show_Remarks_On_Header"])) ? 1 : 0);
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				chkCommon[chkExchangeRate].CheckState = (CheckState) ((Convert.ToBoolean(rsLocalRec["Show_Exchange_Rate"])) ? 1 : 0);
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				chkCommon[chkShowSalesman].CheckState = (CheckState) ((Convert.ToBoolean(rsLocalRec["Show_Salesman"])) ? 1 : 0);
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				chkCommon[chkShowExpenses].CheckState = (CheckState) ((Convert.ToBoolean(rsLocalRec["Show_Expenses"])) ? 1 : 0);
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				chkCommon[chkShowDiscountInPercent].CheckState = (CheckState) ((Convert.ToBoolean(rsLocalRec["Show_Percent_Discount"])) ? 1 : 0);
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				chkCommon[chkShowNetAmount].CheckState = (CheckState) ((Convert.ToBoolean(rsLocalRec["Show_Net_Amount"])) ? 1 : 0);
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				chkCommon[chkShowDueDate].CheckState = (CheckState) ((Convert.ToBoolean(rsLocalRec["Show_Due_Date_On_Header"])) ? 1 : 0);
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				chkCommon[chkShowJobCd].CheckState = (CheckState) ((Convert.ToBoolean(rsLocalRec["Show_Job_Cd_On_Header"])) ? 1 : 0);
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				chkCommon[chkShowPartyBal].CheckState = (CheckState) ((Convert.ToBoolean(rsLocalRec["Show_Party_Balance_On_Header"])) ? 1 : 0);
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				chkCommon[chkShowBatchCd].CheckState = (CheckState) ((Convert.ToBoolean(rsLocalRec["Show_Batch_Cd_On_Header"])) ? 1 : 0);
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				chkCommon[chkShowDocPresc].CheckState = (CheckState) ((Convert.ToBoolean(rsLocalRec["Enable_Doc_Presc_In_Additional_Voucher_Details"])) ? 1 : 0);

				//Details Section
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				chkCommon[chkShowLineNoInList].CheckState = (CheckState) ((Convert.ToBoolean(rsLocalRec["Show_Line_No_In_Details"])) ? 1 : 0);
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				chkCommon[chkShowPartNoInList].CheckState = (CheckState) ((Convert.ToBoolean(rsLocalRec["Show_Part_No_In_Details"])) ? 1 : 0);
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				chkCommon[chkShowProdNameInList].CheckState = (CheckState) ((Convert.ToBoolean(rsLocalRec["Show_Product_Name_In_Details"])) ? 1 : 0);
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				chkCommon[chkShowUnitInList].CheckState = (CheckState) ((Convert.ToBoolean(rsLocalRec["Show_Unit_In_Details"])) ? 1 : 0);
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				chkCommon[chkShowPromoTypeInList].CheckState = (CheckState) ((Convert.ToBoolean(rsLocalRec["Show_Promo_In_Details"])) ? 1 : 0);
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				chkCommon[chkShowQtyInList].CheckState = (CheckState) ((Convert.ToBoolean(rsLocalRec["Show_Qty_In_Details"])) ? 1 : 0);
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				chkCommon[chkShowPackQty].CheckState = (CheckState) ((Convert.ToBoolean(rsLocalRec["Show_Pack_Qty"])) ? 1 : 0);
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				chkCommon[chkSetFocusToQty].CheckState = (CheckState) ((Convert.ToBoolean(rsLocalRec["Setfocus_To_Qty_After_Name_Entered"])) ? 1 : 0);

				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				chkCommon[chkShowRemainingQtyInList].CheckState = (CheckState) ((Convert.ToBoolean(rsLocalRec["Show_Remaining_Qty_In_Details"])) ? 1 : 0);
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				chkCommon[chkShowRateInList].CheckState = (CheckState) ((Convert.ToBoolean(rsLocalRec["Show_Rate_In_Details"])) ? 1 : 0);
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				chkCommon[chkShowDiscountInList].CheckState = (CheckState) ((Convert.ToBoolean(rsLocalRec["Show_Product_Discount_In_Details"])) ? 1 : 0);
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				chkCommon[chkShowAmountInList].CheckState = (CheckState) ((Convert.ToBoolean(rsLocalRec["Show_Amount_In_Details"])) ? 1 : 0);
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				chkCommon[chkShowLocationInList].CheckState = (CheckState) ((Convert.ToBoolean(rsLocalRec["Show_Location_In_Details"])) ? 1 : 0);
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				chkCommon[chkShowRemarksInList].CheckState = (CheckState) ((Convert.ToBoolean(rsLocalRec["Show_Remarks_In_Details"])) ? 1 : 0);
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				chkCommon[chkShowSerialNoInList].CheckState = (CheckState) ((Convert.ToBoolean(rsLocalRec["Show_Serial_In_Details"])) ? 1 : 0);
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				chkCommon[chkShowBarcodeInList].CheckState = (CheckState) ((Convert.ToBoolean(rsLocalRec["Show_Barcode_In_Details"])) ? 1 : 0);
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				chkCommon[chkShowProjectInList].CheckState = (CheckState) ((Convert.ToBoolean(rsLocalRec["Show_Project_In_Details"])) ? 1 : 0);
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				chkCommon[chkShowWeightInList].CheckState = (CheckState) ((Convert.ToBoolean(rsLocalRec["Show_Weight_In_Details"])) ? 1 : 0);
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				chkCommon[chkShowProdDiscountPercentInList].CheckState = (CheckState) ((Convert.ToBoolean(rsLocalRec["Show_Product_Dis_Per_In_Details"])) ? 1 : 0);
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				chkCommon[chkShowNonInventoryProductInList].CheckState = (CheckState) ((Convert.ToBoolean(rsLocalRec["Show_Non_Inventory_In_Details"])) ? 1 : 0);
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				chkCommon[chkShowDentedStkInList].CheckState = (CheckState) ((Convert.ToBoolean(rsLocalRec["Show_Dented_Stock_In_Details"])) ? 1 : 0);
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				chkCommon[chkShowBaseUnitInList].CheckState = (CheckState) ((Convert.ToBoolean(rsLocalRec["Show_Product_Base_Unit_In_List"])) ? 1 : 0);
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				chkCommon[chkShowProductGroupInList].CheckState = (CheckState) ((Convert.ToBoolean(rsLocalRec["Show_Product_Group_In_List"])) ? 1 : 0);
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				chkCommon[chkShowProdCategoryInList].CheckState = (CheckState) ((Convert.ToBoolean(rsLocalRec["Show_Product_Category_In_List"])) ? 1 : 0);
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				chkCommon[chkShowPurPriceInList].CheckState = (CheckState) ((Convert.ToBoolean(rsLocalRec["Show_Purchase_Price_In_List"])) ? 1 : 0);
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				chkCommon[chkShowSalesPriceInList].CheckState = (CheckState) ((Convert.ToBoolean(rsLocalRec["Show_Sales_Price_In_List"])) ? 1 : 0);
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				chkCommon[chkShowRateUOMInList].CheckState = (CheckState) ((Convert.ToBoolean(rsLocalRec["Show_Rate_UOM_In_Details"])) ? 1 : 0);
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				chkCommon[chkShowExpiry].CheckState = (CheckState) ((Convert.ToBoolean(rsLocalRec["Show_Expiry_In_Details"])) ? 1 : 0);

				//Status Section
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				chkCommon[chkShowBaseUnitInStatus].CheckState = (CheckState) ((Convert.ToBoolean(rsLocalRec["Show_Base_Unit_In_Status"])) ? 1 : 0);
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				chkCommon[chkShowStkInHandInStatus].CheckState = (CheckState) ((Convert.ToBoolean(rsLocalRec["Show_Stock_In_Hand_In_Status"])) ? 1 : 0);
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				chkCommon[chkShowAllocatedStkInStatus].CheckState = (CheckState) ((Convert.ToBoolean(rsLocalRec["Show_Stock_Allocated_In_Status"])) ? 1 : 0);
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				chkCommon[chkShowStkAvailableInStatus].CheckState = (CheckState) ((Convert.ToBoolean(rsLocalRec["Show_Stock_Available_In_Status"])) ? 1 : 0);
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				chkCommon[chkShowStkInTransitInStatus].CheckState = (CheckState) ((Convert.ToBoolean(rsLocalRec["Show_In_Transit_Stock_In_Status"])) ? 1 : 0);
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				chkCommon[chkShowStkOnOrderInStatus].CheckState = (CheckState) ((Convert.ToBoolean(rsLocalRec["Show_On_Order_Stock_In_Status"])) ? 1 : 0);
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				chkCommon[chkAdvStkInStatus].CheckState = (CheckState) ((Convert.ToBoolean(rsLocalRec["Show_Advanced_Booked_Stock_In_Status"])) ? 1 : 0);
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				chkCommon[chkStkReturnInTransitInStatus].CheckState = (CheckState) ((Convert.ToBoolean(rsLocalRec["Show_Stock_Return_In_Transit_In_Status"])) ? 1 : 0);
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				chkCommon[chkOnOrderStockOfSales].CheckState = (CheckState) ((Convert.ToBoolean(rsLocalRec["Show_On_Order_Stock_Of_Sales_In_Status"])) ? 1 : 0);
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				chkCommon[chkShowExpiry].CheckState = (CheckState) ((Convert.ToBoolean(rsLocalRec["Show_Expiry_In_Details"])) ? 1 : 0);
				//-------------------------------------------------------------

				//-------------Posting Details-------------------------------
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				chkCommon[chkAutoPostICS].CheckState = (CheckState) ((Convert.ToBoolean(rsLocalRec["Auto_Post_ICS"])) ? 1 : 0);
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				chkCommon[chkAutoPostParty].CheckState = (CheckState) ((Convert.ToBoolean(rsLocalRec["Auto_Post_GL_Party"])) ? 1 : 0);
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				chkCommon[chkAutoPostStatus].CheckState = (CheckState) ((Convert.ToBoolean(rsLocalRec["Auto_Post_Status"])) ? 1 : 0);
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				chkCommon[chkAutoPostExpenses].CheckState = (CheckState) ((Convert.ToBoolean(rsLocalRec["Auto_Post_GL_Expense"])) ? 1 : 0);
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				chkCommon[chkAutoPostGLInventory].CheckState = (CheckState) ((Convert.ToBoolean(rsLocalRec["Auto_Post_GL_Inventory"])) ? 1 : 0);
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				chkCommon[chkAutoPostGLS].CheckState = (CheckState) ((Convert.ToBoolean(rsLocalRec["Auto_Post_GL"])) ? 1 : 0);

				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				chkCommon[chkBatchPostICS].CheckState = (CheckState) ((Convert.ToBoolean(rsLocalRec["Batch_Post_ICS"])) ? 1 : 0);
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				chkCommon[chkBatchPostParty].CheckState = (CheckState) ((Convert.ToBoolean(rsLocalRec["Batch_Post_GL_Party"])) ? 1 : 0);
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				chkCommon[chkBatchPostStatus].CheckState = (CheckState) ((Convert.ToBoolean(rsLocalRec["Batch_Post_Status"])) ? 1 : 0);
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				chkCommon[chkBatchPostExpenses].CheckState = (CheckState) ((Convert.ToBoolean(rsLocalRec["Batch_Post_GL_Expense"])) ? 1 : 0);
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				chkCommon[chkBatchPostGLInventory].CheckState = (CheckState) ((Convert.ToBoolean(rsLocalRec["Batch_Post_GL_Inventory"])) ? 1 : 0);
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				chkCommon[chkBatchPostGLS].CheckState = (CheckState) ((Convert.ToBoolean(rsLocalRec["Batch_Post_GL"])) ? 1 : 0);

				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				chkCommon[chkAllowOnlinePosting].CheckState = (CheckState) ((Convert.ToBoolean(rsLocalRec["Allow_Online_GL_Post"])) ? 1 : 0);
				//-------------------------------------------------------------

				//-------------Printing Details--------------------------------
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				chkCommon[chkPrintPreview].CheckState = (CheckState) ((Convert.ToBoolean(rsLocalRec["Show_Print_Preview_First"])) ? 1 : 0);
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				chkCommon[chkPageSetup].CheckState = (CheckState) ((Convert.ToBoolean(rsLocalRec["Show_Page_Setup_First"])) ? 1 : 0);
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				chkCommon[chkCloseWindowAfterPrint].CheckState = (CheckState) ((Convert.ToBoolean(rsLocalRec["Close_Preview_Windows_After_Print"])) ? 1 : 0);
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				chkCommon[chkPrintAfterSave].CheckState = (CheckState) ((Convert.ToBoolean(rsLocalRec["Print_After_Save"])) ? 1 : 0);
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				chkCommon[chkNumToChar].CheckState = (CheckState) ((Convert.ToBoolean(rsLocalRec["Use_Num_To_Char_Function"])) ? 1 : 0);

				if (Convert.ToBoolean(rsLocalRec["Use_Crystal_Reports_For_Print"]))
				{
					optCommonQtyEffect[optCrystalReports].Checked = true;
					txtCommon[tcReportCode].Text = (Convert.IsDBNull(rsLocalRec["Crystal_Report_Id"])) ? "" : Convert.ToString(rsLocalRec["Crystal_Report_Id"]);
					GetValuesForLabel(tcReportCode);
				}
				else
				{
					optCommonQtyEffect[optXMLReports].Checked = true;
					txtCommon[tcPrintVoucherName].Text = (Convert.IsDBNull(rsLocalRec["Print_Voucher_Name"])) ? "" : Convert.ToString(rsLocalRec["Print_Voucher_Name"]);
					txtCommon[tcPrintVoucherSQL].Text = (Convert.IsDBNull(rsLocalRec["Print_Voucher_Sql"])) ? "" : Convert.ToString(rsLocalRec["Print_Voucher_Sql"]);
				}
				//-------------------------------------------------------------

				//-------------POS Details--------------------------------
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				chkCommon[chkEnableICSFinalPymtScreen].CheckState = (CheckState) ((Convert.ToBoolean(rsLocalRec["Enable_ICS_Voucher_Final_Payment_Screen"])) ? 1 : 0);
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				chkCommon[chkImportExternalData].CheckState = (CheckState) ((Convert.ToBoolean(rsLocalRec["Import_External_Data"])) ? 1 : 0);
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				chkCommon[chkSetFocusAfterAddnew].CheckState = (CheckState) ((Convert.ToBoolean(rsLocalRec["Setfocus_To_Grid_After_Add_New"])) ? 1 : 0);
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				chkCommon[chkPartNoExists].CheckState = (CheckState) ((Convert.ToBoolean(rsLocalRec["Check_Part_No_Exists"])) ? 1 : 0);
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				chkCommon[chkProductNameExists].CheckState = (CheckState) ((Convert.ToBoolean(rsLocalRec["Check_Prod_Name_Exists"])) ? 1 : 0);
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				chkCommon[chkPartialReciept].CheckState = (CheckState) ((Convert.ToBoolean(rsLocalRec["Enable_Partial_Receipt"])) ? 1 : 0);
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				chkCommon[chkPreDesc].CheckState = (CheckState) ((Convert.ToBoolean(rsLocalRec["Enable_ICS_Voucher_Multiline_PreDesc"])) ? 1 : 0);
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				chkCommon[chkPostDesc].CheckState = (CheckState) ((Convert.ToBoolean(rsLocalRec["Enable_ICS_Voucher_Multiline_PostDesc"])) ? 1 : 0);
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				chkCommon[chkEnableAutoFillPreText].CheckState = (CheckState) ((Convert.ToBoolean(rsLocalRec["Enable_Auto_Fill_Pre_Text_With_Product_Desc"])) ? 1 : 0);
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				chkCommon[chkAdditionalDetails2].CheckState = (CheckState) ((Convert.ToBoolean(rsLocalRec["Enable_Additional_Voucher_Details_2"])) ? 1 : 0);
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				chkCommon[chkNegativeStk].CheckState = (CheckState) ((Convert.ToBoolean(rsLocalRec["Show_Message_When_Negative_Stock"])) ? 1 : 0);
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				chkCommon[chkLocationInVchr].CheckState = (CheckState) ((Convert.ToBoolean(rsLocalRec["Include_Location_In_Voucher"])) ? 1 : 0);
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				chkCommon[chkVchrNumInVchr].CheckState = (CheckState) ((Convert.ToBoolean(rsLocalRec["Include_Voucher_No_In_Voucher"])) ? 1 : 0);
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				chkCommon[chkRefNoInVoucher].CheckState = (CheckState) ((Convert.ToBoolean(rsLocalRec["Include_Reference_No_In_Voucher"])) ? 1 : 0);
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				chkCommon[chkProdNameAlteration].CheckState = (CheckState) ((Convert.ToBoolean(rsLocalRec["Allow_Product_Name_Alteration"])) ? 1 : 0);
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				chkCommon[chkAllowAddSerialNum].CheckState = (CheckState) ((Convert.ToBoolean(rsLocalRec["Allow_Add_Serial_No_When_Not_Exists"])) ? 1 : 0);
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				chkCommon[chkAllowAddNew].CheckState = (CheckState) ((Convert.ToBoolean(rsLocalRec["Allow_Add_New_Voucher"])) ? 1 : 0);
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				chkCommon[chkAllowUpdate].CheckState = (CheckState) ((Convert.ToBoolean(rsLocalRec["Allow_Update_Voucher"])) ? 1 : 0);
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				chkCommon[chkNewLineAfterBarcode].CheckState = (CheckState) ((Convert.ToBoolean(rsLocalRec["Setfocus_To_Newline_After_Barcode_Entered"])) ? 1 : 0);
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				chkCommon[chkNewLineAfterQty].CheckState = (CheckState) ((Convert.ToBoolean(rsLocalRec["Setfocus_To_Newline_After_Qty_Entered"])) ? 1 : 0);
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				chkCommon[chkBeginWithSeperator].CheckState = (CheckState) ((Convert.ToBoolean(rsLocalRec["Begin_With_Line_Seperator"])) ? 1 : 0);
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				chkCommon[chkShowAmtOverRate].CheckState = (CheckState) ((Convert.ToBoolean(rsLocalRec["Show_Amount_Over_Rate"])) ? 1 : 0);
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				chkCommon[chkDisplayVoucherNumAfterSave].CheckState = (CheckState) ((Convert.ToBoolean(rsLocalRec["Display_Voucher_No_After_Save"])) ? 1 : 0);
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				chkCommon[chkLocationSpecificProduct].CheckState = (CheckState) ((Convert.ToBoolean(rsLocalRec["Show_Location_Specific_Product"])) ? 1 : 0);
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				chkCommon[chkDefaultLocSman].CheckState = (CheckState) ((Convert.ToBoolean(rsLocalRec["Show_Default_Location_Salesman"])) ? 1 : 0);
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				chkCommon[chkShowInPeriodicalBatchPost].CheckState = (CheckState) ((Convert.ToBoolean(rsLocalRec["Show_In_Periodical_Batch_Post"])) ? 1 : 0);
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				chkCommon[chkExportToWord].CheckState = (CheckState) ((Convert.ToBoolean(rsLocalRec["Export_To_Word"])) ? 1 : 0);
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				chkCommon[chkAllowDirectTransaction].CheckState = (CheckState) ((Convert.ToBoolean(rsLocalRec["Allow_Direct_Transaction"])) ? 1 : 0);
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				chkCommon[chkShowSupplierTab].CheckState = (CheckState) ((Convert.ToBoolean(rsLocalRec["Show_Supplier_Tab_In_ICS_Voucher"])) ? 1 : 0);
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				chkCommon[chkShowExpLdgrCode].CheckState = (CheckState) ((Convert.ToBoolean(rsLocalRec["Show_Expenses_Ldgr_Code_On_Header"])) ? 1 : 0);
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				chkCommon[chkAffectGLWithExpenses].CheckState = (CheckState) ((Convert.ToBoolean(rsLocalRec["Affect_GL_With_Expenses_Ldgr_Cd"])) ? 1 : 0);
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				chkCommon[chkShowConsignmentNo].CheckState = (CheckState) ((Convert.ToBoolean(rsLocalRec["Show_Consignment_No_On_Header"])) ? 1 : 0);
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				chkCommon[chkGetMaxNewVoucherNo].CheckState = (CheckState) ((Convert.ToBoolean(rsLocalRec["Get_Max_New_Voucher_No"])) ? 1 : 0);
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				chkCommon[chkAllowZeroAmountTransaction].CheckState = (CheckState) ((Convert.ToBoolean(rsLocalRec["Allow_Zero_Amount_Transaction"])) ? 1 : 0);
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				chkCommon[chkShowBelowReorderLevelMsg].CheckState = (CheckState) ((Convert.ToBoolean(rsLocalRec["Show_Message_On_Items_Below_Reorder_Level"])) ? 1 : 0);
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				chkCommon[chkShowMinimumLevelMsg].CheckState = (CheckState) ((Convert.ToBoolean(rsLocalRec["Show_Message_On_Items_Below_Minimum_Level"])) ? 1 : 0);
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				chkCommon[chkShowMsximumLevelMsg].CheckState = (CheckState) ((Convert.ToBoolean(rsLocalRec["Show_Message_On_Items_Above_Maximum_Level"])) ? 1 : 0);
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				chkCommon[chkGenerateReceiptPaymentVoucher].CheckState = (CheckState) ((Convert.ToBoolean(rsLocalRec["Generate_Receipt_Payment_Voucher"])) ? 1 : 0);
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				chkCommon[chkShowFlex1].CheckState = (CheckState) ((Convert.ToBoolean(rsLocalRec["Show_Flex1_In_Details"])) ? 1 : 0);
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				chkCommon[chkEnableCashCredit].CheckState = (CheckState) ((Convert.ToBoolean(rsLocalRec["Enable_Cash_Credit_On_Header"])) ? 1 : 0);
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				chkCommon[chkImportCashCredit].CheckState = (CheckState) ((Convert.ToBoolean(rsLocalRec["Import_Cash_Credit_on_link"])) ? 1 : 0);
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				chkCommon[chkImportPriceOverwrite].CheckState = (CheckState) ((Convert.ToBoolean(rsLocalRec["Overwrite_Price_On_Import"])) ? 1 : 0);

				txtCommon[tcAfterSaveScript].Text = (Convert.IsDBNull(rsLocalRec["After_Save_Script"])) ? "" : Convert.ToString(rsLocalRec["After_Save_Script"]);
				//-------------Default Cash Code----------------------------
				if (!Convert.IsDBNull(rsLocalRec["Default_cash_cd"]))
				{
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mTempReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode("select ldgr_no from gl_ledger where ldgr_cd= " + Convert.ToString(rsLocalRec["Default_cash_cd"])));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (!Convert.IsDBNull(mTempReturnValue))
					{
						//UPGRADE_WARNING: (1068) mTempReturnValue of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtCommon[tcDefaultCashCode].Text = ReflectionHelper.GetPrimitiveValue<string>(mTempReturnValue);
					}
				}
				//--------------------------------------------------------
				//-------------Default Cash Code--Moiz Hakimi---25-02-2010--------------------------
				if (!Convert.IsDBNull(rsLocalRec["Default_Credit_Card_Cd"]))
				{
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mTempReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode("select ldgr_no from gl_ledger where ldgr_cd= " + Convert.ToString(rsLocalRec["Default_Credit_Card_Cd"])));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (!Convert.IsDBNull(mTempReturnValue))
					{
						//UPGRADE_WARNING: (1068) mTempReturnValue of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtCommon[tcDefaultCreditCardCode].Text = ReflectionHelper.GetPrimitiveValue<string>(mTempReturnValue);
					}
				}
				//--------------------------------------------------------
				SystemCombo.SearchCombo(cmbCommon[cmbPriceLevel], Convert.ToInt32(rsLocalRec["Default_Price_Level_Priority"]));
				//--------------------------------------------------------

				//-------------History Details----------------------------
				if (Convert.ToBoolean(rsLocalRec["Restore_Last_Tran_Setting"]))
				{
					chkCommon[chkLastTranSettings].CheckState = CheckState.Checked;
					//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
					chkCommon[chkLastTranCashType].CheckState = (CheckState) ((Convert.ToBoolean(rsLocalRec["Last_Tran_Cash_Type"])) ? 1 : 0);
					txtCommonLabel[dcLastLocationNumber].Text = (Convert.IsDBNull(rsLocalRec["Last_Tran_Locat_No"])) ? "" : Convert.ToString(rsLocalRec["Last_Tran_Locat_No"]);
					txtCommonLabel[dcLastCashNumber].Text = (Convert.IsDBNull(rsLocalRec["Last_Tran_Cash_No"])) ? "" : Convert.ToString(rsLocalRec["Last_Tran_Cash_No"]);
					txtCommonLabel[dcLastSalesmanNumber].Text = (Convert.IsDBNull(rsLocalRec["Last_Tran_Sman_No"])) ? "" : Convert.ToString(rsLocalRec["Last_Tran_Sman_No"]);
					txtCommonLabel[dcLastLedgerNumber].Text = (Convert.IsDBNull(rsLocalRec["Last_Tran_Ldgr_No"])) ? "" : Convert.ToString(rsLocalRec["Last_Tran_Ldgr_No"]);
				}
				//--------------------------------------------------------

				//-------------Other Details----------------------------
				if (Convert.ToBoolean(rsLocalRec["Enable_Revision"]))
				{
					chkCommon[chkEnableRevision].CheckState = CheckState.Checked;
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					txtCommon[tcRevisedHistoryVoucherCode].Text = (System.DBNull.Value.Equals(rsLocalRec["Revised_History_Voucher_Type"])) ? "" : Convert.ToString(rsLocalRec["Revised_History_Voucher_Type"]);
					GetValuesForLabel(tcRevisedHistoryVoucherCode);
				}

				SystemCombo.SearchCombo(cmbCommon[cmbReferenceType], Convert.ToInt32(rsLocalRec["Reference_No_Generate_Method"]));
				txtCommon[tcReferenceNoCaption].Text = (Convert.IsDBNull(rsLocalRec["Reference_No_L_Caption"])) ? "" : Convert.ToString(rsLocalRec["Reference_No_L_Caption"]);
				txtCommon[tcFormHeightSize].Text = (Convert.IsDBNull(rsLocalRec["Form_Height_Size"])) ? "" : Convert.ToString(rsLocalRec["Form_Height_Size"]);
				txtCommon[tcGridRowHeightSize].Text = (Convert.IsDBNull(rsLocalRec["Grid_Row_Height_Size"])) ? "" : Convert.ToString(rsLocalRec["Grid_Row_Height_Size"]);
				txtCommon[tcExpensesLdgrFindWhereClause].Text = (Convert.IsDBNull(rsLocalRec["Expenses_Ldgr_Find_Where_Clause"])) ? "" : Convert.ToString(rsLocalRec["Expenses_Ldgr_Find_Where_Clause"]);
				txtCommon[tcProductListWhereClause].Text = (Convert.IsDBNull(rsLocalRec["Product_List_Where_Clause"])) ? "" : Convert.ToString(rsLocalRec["Product_List_Where_Clause"]);
				txtCommon[tcAdditionalCashFindWhereClause].Text = (Convert.IsDBNull(rsLocalRec["Additional_Cash_Find_Where_Clause"])) ? "" : Convert.ToString(rsLocalRec["Additional_Cash_Find_Where_Clause"]);
				txtCommon[tcVoucherGridBackColor].Text = (Convert.IsDBNull(rsLocalRec["Voucher_Grid_Back_Color"])) ? "" : Convert.ToString(rsLocalRec["Voucher_Grid_Back_Color"]);
				txtCommon[tcAdditionalLdgrFindWhereClause].Text = (Convert.IsDBNull(rsLocalRec["Additional_Ledger_Find_Where_Clause"])) ? "" : Convert.ToString(rsLocalRec["Additional_Ledger_Find_Where_Clause"]);
				txtCommon[tcLPartyNameCaption].Text = (Convert.IsDBNull(rsLocalRec["L_Party_Name_Caption"])) ? "" : Convert.ToString(rsLocalRec["L_Party_Name_Caption"]);
				txtCommon[tcAPartyNameCaption].Text = (Convert.IsDBNull(rsLocalRec["A_Party_Name_Caption"])) ? "" : Convert.ToString(rsLocalRec["A_Party_Name_Caption"]);
				txtCommon[tcVoucherNoMethod].Text = Convert.ToString(rsLocalRec["Generate_voucher_no_method"]);
				//------------------------------------------------------
			}
			rsLocalRec.Close();
			mGetStatus = true;

			tabVoucherDetails.CurrTab = Convert.ToInt16(cBasicMasterDetails);
			FirstFocusObject.Focus();

			//Change the form mode to edit
			mCurrentFormMode = SystemVariables.SystemFormModes.frmEditMode;
			return;


			//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
			SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, Information.Err().Description, this.Name, "GetRecord");

		}
		private void GetVoucherparentDetails()
		{
			int cnt = 0;

			string mysql = " select vpd.parent_voucher_type ";
			if (SystemVariables.gPreferedLanguage == SystemVariables.Language.English)
			{
				mysql = mysql + " , ivt.l_voucher_name as voucher_name ";
			}
			else
			{
				mysql = mysql + " , ivt.a_voucher_name as voucher_name ";
			}
			mysql = mysql + " from ICS_Transaction_Type_Link vpd ";
			mysql = mysql + " inner join ICS_Transaction_Types ivt on ivt.voucher_type = vpd.parent_voucher_type ";
			mysql = mysql + " where vpd.voucher_type = " + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);

			SqlDataReader localRec = null;
			SqlCommand sqlCommand = new SqlCommand(mysql, SystemVariables.gConn);
			localRec = sqlCommand.ExecuteReader();
			if (localRec.Read())
			{
				do 
				{
					DefineVoucherArray(cnt, false);
					aParentDetails.SetValue(Conversion.Str(cnt + 1).Trim(), cnt, grdLineNoColumn);
					aParentDetails.SetValue(localRec["parent_voucher_type"], cnt, grdParentCodeColumn);
					aParentDetails.SetValue(localRec["voucher_name"], cnt, grdParentNameColumn);
					cnt++;
				}
				while(localRec.Read());
			}

			AssignGridLineNumbers();
			grdVoucherParentDetails.Rebind(true);
		}
		public bool CheckDataValidity()
		{
			//Check validation during update and add of records
			if (SystemProcedure2.IsItEmpty(txtCommon[tcVoucherType].Text, SystemVariables.DataType.NumberType))
			{
				MessageBox.Show("Enter Voucher Type", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
				tabVoucherDetails.CurrTab = Convert.ToInt16(cBasicMasterDetails);
				txtCommon[tcVoucherType].Focus();
				return false;
			}

			if (SystemProcedure2.IsItEmpty(txtCommon[tcLVouchername].Text, SystemVariables.DataType.StringType))
			{
				MessageBox.Show("Enter Voucher Name", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
				tabVoucherDetails.CurrTab = Convert.ToInt16(cBasicMasterDetails);
				txtCommon[tcLVouchername].Focus();
				return false;
			}

			if (SystemProcedure2.IsItEmpty(txtCommon[tcLShortName].Text, SystemVariables.DataType.StringType))
			{
				MessageBox.Show("Enter Voucher Short Name", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
				tabVoucherDetails.CurrTab = Convert.ToInt16(cBasicMasterDetails);
				txtCommon[tcLShortName].Focus();
				return false;
			}


			//If IsItEmpty(txtCommon(tcParentCode).Text, NumberType) Then
			//    MsgBox "Enter Parent Voucher Type", vbInformation, "Required"
			//    tabVoucherDetails.CurrTab = cBasicMasterDetails
			//    txtCommon(tcParentCode).SetFocus
			//    CheckDataValidity = False
			//    Exit Function
			//End If

			if (SystemProcedure2.IsItEmpty(txtCommon[tcModuleCode].Text, SystemVariables.DataType.NumberType))
			{
				MessageBox.Show("Enter Module Code", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
				tabVoucherDetails.CurrTab = Convert.ToInt16(cBasicMasterDetails);
				txtCommon[tcModuleCode].Focus();
				return false;
			}

			//If IsItEmpty(txtCommon(tcPreferenceCode).Text, NumberType) Then
			//    MsgBox "Enter Feature Code", vbInformation, "Required"
			//    tabVoucherDetails.CurrTab = cBasicMasterDetails
			//    txtCommon(tcPreferenceCode).SetFocus
			//    CheckDataValidity = False
			//    Exit Function
			//End If

			if (SystemProcedure2.IsItEmpty(txtCommon[tcFindCode].Text, SystemVariables.DataType.NumberType))
			{
				MessageBox.Show("Enter Find Code", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
				tabVoucherDetails.CurrTab = Convert.ToInt16(cBasicMasterDetails);
				txtCommon[tcFindCode].Focus();
				return false;
			}

			if (SystemProcedure2.IsItEmpty(txtCommon[tcGLJournalVoucherCd].Text, SystemVariables.DataType.NumberType))
			{
				MessageBox.Show("Enter GL Journal Voucher Type Code", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
				tabVoucherDetails.CurrTab = Convert.ToInt16(cLinkMasterDetails);
				txtCommon[tcGLJournalVoucherCd].Focus();
				return false;
			}

			if (SystemProcedure2.IsItEmpty(txtCommon[tcGLPaymentVoucherCd].Text, SystemVariables.DataType.NumberType))
			{
				MessageBox.Show("Enter GL Payment Voucher Type Code", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
				tabVoucherDetails.CurrTab = Convert.ToInt16(cLinkMasterDetails);
				txtCommon[tcGLPaymentVoucherCd].Focus();
				return false;
			}

			if (SystemProcedure2.IsItEmpty(txtCommon[tcGLReceiptVoucherCd].Text, SystemVariables.DataType.NumberType))
			{
				MessageBox.Show("Enter GL Reciept Voucher Type Code", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
				tabVoucherDetails.CurrTab = Convert.ToInt16(cLinkMasterDetails);
				txtCommon[tcGLReceiptVoucherCd].Focus();
				return false;
			}

			//If IsItEmpty(txtCommon(tcLPartyNameCaption).Text, StringType) Then
			//    MsgBox "Enter Party Name(English)", vbInformation, "Required"
			//    tabVoucherDetails.CurrTab = cOtherDetails
			//    txtCommon(tcLPartyNameCaption).SetFocus
			//    CheckDataValidity = False
			//    Exit Function
			//End If
			//
			//If IsItEmpty(txtCommon(tcAPartyNameCaption).Text, StringType) Then
			//    MsgBox "Enter Party Name(Arabic)", vbInformation, "Required"
			//    tabVoucherDetails.CurrTab = cOtherDetails
			//    txtCommon(tcAPartyNameCaption).SetFocus
			//    CheckDataValidity = False
			//    Exit Function
			//End If

			if (((int) chkCommon[chkEnableRevision].CheckState) == ((int) TriState.True))
			{
				if (ReflectionHelper.GetPrimitiveValue<string>(txtCommon[tcRevisedHistoryVoucherCode]) == "")
				{
					MessageBox.Show("Revised History Voucher Type must be entered when Revision is Enabled", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
					tabVoucherDetails.CurrTab = Convert.ToInt16(cOtherDetails);
					txtCommon[tcRevisedHistoryVoucherCode].Focus();
					return false;
				}
			}

			if (chkCommon[chkAffectCost].CheckState == CheckState.Checked && !optCommonAffectType[optOnHandStock].Checked)
			{
				MessageBox.Show("\"Affect Cost\" cannot be true, When \"Affect OnHandStock\" is False(Voucher Affects)", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
				tabVoucherDetails.CurrTab = Convert.ToInt16(cBasicMasterDetails);
				return false;
			}

			if (chkCommon[chkAffectOpeningValue].CheckState == CheckState.Checked && chkCommon[chkAffectGLS].CheckState == CheckState.Unchecked)
			{
				MessageBox.Show("\"Affect Opening Value\" cannot be true, When \"Affect GLS\" is False(Voucher Affects)", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
				tabVoucherDetails.CurrTab = Convert.ToInt16(cBasicMasterDetails);
				return false;
			}

			if (chkCommon[chkAffectOpeningValue].CheckState == CheckState.Checked && !optCommonAffectType[optOnHandStock].Checked)
			{
				MessageBox.Show("\"Affect Opening Value\" cannot be true, When \"Affect OnHandStock\" is False(Voucher Affects)", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
				tabVoucherDetails.CurrTab = Convert.ToInt16(cBasicMasterDetails);
				return false;
			}

			if (txtCommon[tcVoucherGridBackColor].Text != "")
			{
				if (!Information.IsNumeric(txtCommon[tcVoucherGridBackColor].Text))
				{
					MessageBox.Show("Only Numeric values are allowed for Voucher Grid Back Color", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
					tabVoucherDetails.CurrTab = Convert.ToInt16(cOtherDetails);
					return false;
				}
			}

			if (!(optCommonAffectType[optOnHandStock].Checked || optCommonAffectType[optAllocatedStock].Checked || optCommonAffectType[optInTransitStock].Checked || optCommonAffectType[optOnOrderPurchaseStock].Checked || optCommonAffectType[optReservedStock].Checked || optCommonAffectType[optAdvancedBookedStock].Checked || optCommonAffectType[optSalesreturnInTransitStock].Checked || optCommonAffectType[optOnOrderSalesStock].Checked) && chkCommon[chkAffectICS].CheckState == CheckState.Checked)
			{
				MessageBox.Show("\"Affect ICS\" cannot be true, When All the Options related to \"Affect on Stock\" are False(Voucher Affects)", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
				tabVoucherDetails.CurrTab = Convert.ToInt16(cBasicMasterDetails);
				return false;
			}

			if ((optCommonAffectType[optOnHandStock].Checked || optCommonAffectType[optAllocatedStock].Checked || optCommonAffectType[optInTransitStock].Checked || optCommonAffectType[optOnOrderPurchaseStock].Checked || optCommonAffectType[optReservedStock].Checked || optCommonAffectType[optAdvancedBookedStock].Checked || optCommonAffectType[optSalesreturnInTransitStock].Checked || optCommonAffectType[optOnOrderSalesStock].Checked) && chkCommon[chkAffectICS].CheckState == CheckState.Unchecked)
			{
				MessageBox.Show("\"Affect ICS\" cannot be False, When Any of the Options related to \"Affect on Stock\" is True(Voucher Affects)", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
				tabVoucherDetails.CurrTab = Convert.ToInt16(cBasicMasterDetails);
				return false;
			}
			return true;
		}

		public bool saveRecord()
		{
			bool result = false;
			string mysql = "";
			object mReturnValue = null;
			DialogResult ans = (DialogResult) 0;
			object mTempReturnValue = null;

			try
			{

				//Get the Module Code
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode("select module_id from SM_MODULES where module_id=" + txtCommon[tcModuleCode].Text));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (Convert.IsDBNull(mReturnValue))
				{
					MessageBox.Show("Enter valid Module ID", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
					tabVoucherDetails.CurrTab = Convert.ToInt16(cBasicMasterDetails);
					txtCommon[tcVoucherType].Focus();
					return false;
				}

				if (optCommonAffectType[optShowImportLinkedVoucherOnDetails].Checked)
				{
					if (chkCommon[chkBindToParent].CheckState == CheckState.Checked && SystemProcedure2.IsItEmpty(aParentDetails.GetValue(0, grdParentCodeColumn), SystemVariables.DataType.NumberType))
					{
						MessageBox.Show("Voucher Parent must be defined when \"Bind To Parent\" is true(Import Linked voucher in Details).", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
						tabVoucherDetails.CurrTab = Convert.ToInt16(cLinkMasterDetails);
						return false;
					}
				}

				if (fraCommon[fraVoucherParentDetails].Visible)
				{
					ans = MessageBox.Show("Voucher Parent Details has not been saved. Do you want to save it?", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.YesNo, MessageBoxIcon.Information);
					if (ans == System.Windows.Forms.DialogResult.Yes)
					{
						UCOkCancel1_OKClick(UCOkCancel1, null);
					}
					else
					{
						UCOkCancel1_CancelClick(UCOkCancel1, null);
					}
				}

				if (CurrentFormMode == SystemVariables.SystemFormModes.frmAddMode)
				{
					//Check VoucherType
					mysql = " select voucher_type from ICS_Transaction_Types where voucher_type=" + txtCommon[tcVoucherType].Text;
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (!Convert.IsDBNull(mReturnValue))
					{
						MessageBox.Show("Duplicate Voucher Code", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
						tabVoucherDetails.CurrTab = Convert.ToInt16(cBasicMasterDetails);
						txtCommon[tcVoucherType].Focus();
						return false;
					}

					//Check lVoucherName
					mysql = " select voucher_type from ICS_Transaction_Types where l_voucher_name='" + txtCommon[tcLVouchername].Text + "'";
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (!Convert.IsDBNull(mReturnValue))
					{
						MessageBox.Show("Duplicate Voucher Name(English)", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
						tabVoucherDetails.CurrTab = Convert.ToInt16(cBasicMasterDetails);
						txtCommon[tcLVouchername].Focus();
						return false;
					}

					//Check avoucher Name
					mysql = " select voucher_type from ICS_Transaction_Types where a_voucher_name=N'" + txtCommon[tcAVouchername].Text + "'";
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (!Convert.IsDBNull(mReturnValue))
					{
						MessageBox.Show("Duplicate Voucher Name(Arabic)", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
						tabVoucherDetails.CurrTab = Convert.ToInt16(cBasicMasterDetails);
						txtCommon[tcAVouchername].Focus();
						return false;
					}

					//Check lshortvoucher Name
					mysql = " select voucher_type from ICS_Transaction_Types where l_short_name='" + txtCommon[tcLShortName].Text + "'";
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (!Convert.IsDBNull(mReturnValue))
					{
						MessageBox.Show("Duplicate Voucher Short Name(English)", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
						tabVoucherDetails.CurrTab = Convert.ToInt16(cBasicMasterDetails);
						txtCommon[tcLShortName].Focus();
						return false;
					}

					//Check ashortvoucher Name
					mysql = " select voucher_type from ICS_Transaction_Types where a_short_name='" + txtCommon[tcAShortName].Text + "'";
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (!Convert.IsDBNull(mReturnValue))
					{
						MessageBox.Show("Duplicate Voucher Short Name(Arabic)", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
						tabVoucherDetails.CurrTab = Convert.ToInt16(cBasicMasterDetails);
						txtCommon[tcAShortName].Focus();
						return false;
					}
				}

				SystemVariables.gConn.BeginTransaction();
				if (CurrentFormMode == SystemVariables.SystemFormModes.frmAddMode)
				{
					mysql = "insert into ICS_Transaction_Types(";
					mysql = mysql + "Voucher_Type, L_Voucher_Name, A_Voucher_Name, L_Short_Name, A_Short_Name";
					//-------------Basic Details---------------------------------------
					mysql = mysql + ", Master_table_name,details_table_name, Parent_Type, Module_Id, Feature_Id, Find_Id";
					mysql = mysql + ", Affect_On_Hand_Stock, Affect_In_Transit_Stock, Affect_On_Order_Stock, Affect_Allocated_Stock, Affect_On_Order_Stock_Of_Sales";
					mysql = mysql + ", Affect_Stock_Return_In_Transit, Affect_Advanced_Booked_Stock, Affect_Reserved_Stock";
					mysql = mysql + ", Affect_GLS, Affect_ICS, Affect_Cost, Affect_Opening_Value";
					mysql = mysql + ", Locat_To_Locat, Generate_On_Multiple_Location, Add_Or_Less";
					mysql = mysql + ", Document_Type, Show, Show_in_menu, Auto_Generate_Voucher_No";
					//-------------------------------------------------------------

					//-------------Link Details---------------------------------------
					if (optCommonAffectType[optShowImportLinkedVoucherOnHeader].Checked)
					{
						mysql = mysql + ", Show_Import_Linked_Voucher_On_Header, Show_Import_Linked_Voucher_In_Details";
						mysql = mysql + ", Linked_ICS_Master_Table_Name, Linked_ICS_Details_Table_Name";
						mysql = mysql + ", Linked_ICS_Parent_Master_Table_Name, Linked_ICS_Parent_Details_Table_Name , Linked_Parent_ICS_Voucher_Type_Cd, Linked_Child_ICS_Voucher_Type_Cd";
					}
					else if (optCommonAffectType[optShowImportLinkedVoucherOnDetails].Checked)
					{ 
						mysql = mysql + ", Show_Import_Linked_Voucher_On_Header, Show_Import_Linked_Voucher_In_Details, Bind_To_Parent, Bind_To_Parent_Header_Location";
					}
					else if (optCommonAffectType[optHideImportLinkedVoucher].Checked)
					{ 
						mysql = mysql + ", Show_Import_Linked_Voucher_On_Header, Show_Import_Linked_Voucher_In_Details";
					}

					//     mySql = mySql & ", Show_Import_Linked_Voucher_On_Header, Show_Import_Linked_Voucher_In_Details"
					//     mySql = mySql & ", Linked_ICS_Master_Table_Name, Linked_ICS_Details_Table_Name"
					//     mySql = mySql & ", Linked_ICS_Parent_Master_Table_Name, Linked_ICS_Parent_Details_Table_Name , Linked_Parent_ICS_Voucher_Type_Cd, Linked_Child_ICS_Voucher_Type_Cd"
					//     mySql = mySql & ", Bind_To_Parent, Bind_To_Parent_Header_Location"

					mysql = mysql + ", Linked_Assembly_Group_Adjust_Voucher_Type, Dented_Stock_Generated_Linked_Voucher_Type";
					mysql = mysql + ", Auto_Post_Stock_Generated_Linked_Voucher_Type";

					mysql = mysql + ", Linked_GL_Voucher_Type_Cd, Linked_GL_Receipt_Voucher_Type_Cd, Linked_GL_Payment_Voucher_Type_Cd , Linked_GL_Journal_Voucher_Type_Cd";
					mysql = mysql + ", Enable_Rate_When_Linked, Enable_Percent_Discount_On_Header_When_Linked, Enable_Discount_When_Linked, Enable_Amount_When_Linked";
					mysql = mysql + ", Generate_voucher_no_method, Enable_Cash_Credit_On_Header_When_Linked, Allow_Excess_Qty_When_Linked";

					mysql = mysql + ", Auto_Generate_Linked_Voucher, Auto_Generate_Linked_Voucher_All_Location";
					mysql = mysql + ", Enable_Auto_Generate_Linked_Voucher_For_Cash_Transaction, Import_Non_Inventory_From_Parent_Voucher, Preserve_Grid_Value_During_Import";
					//-------------------------------------------------------------

					//-------------Show/Hide Details-------------------------------
					mysql = mysql + ", Show_Location_On_Header, Show_Ledger_On_Header";
					mysql = mysql + ", Show_Cash_Credit_On_Header, Show_Additional_Voucher_Details , Show_Remarks_On_Header";
					mysql = mysql + ", Show_Exchange_Rate, Show_Salesman, Show_Expenses, Show_Percent_Discount, Show_Net_Amount";
					mysql = mysql + ", Show_Due_Date_On_Header, Show_Job_Cd_On_Header, Show_Party_Balance_On_Header  ";
					mysql = mysql + ", Show_Batch_Cd_On_Header, Enable_Doc_Presc_In_Additional_Voucher_Details";

					mysql = mysql + ", Show_Line_No_In_Details, Show_Part_No_In_Details, Show_Product_Name_In_Details,Show_Unit_In_Details, Show_Promo_In_Details, Show_Qty_In_Details, Show_Pack_Qty";
					mysql = mysql + ", Show_Remaining_Qty_In_Details, Show_Rate_In_Details, Show_Product_Discount_In_Details, Show_Amount_In_Details";
					mysql = mysql + ", Show_Location_In_Details, Show_Remarks_In_Details, Show_Serial_In_Details,  Show_Barcode_In_Details";
					mysql = mysql + ", Show_Project_In_Details, Show_Weight_In_Details";
					mysql = mysql + ", Show_Product_Dis_Per_In_Details,Show_Non_Inventory_In_Details, Show_Dented_Stock_In_Details";

					mysql = mysql + ", Show_Product_Base_Unit_In_List, Show_Product_Group_In_List, Show_Product_Category_In_List";
					mysql = mysql + ", Show_Purchase_Price_In_List, Show_Sales_Price_In_List, Show_Rate_UOM_In_Details";

					mysql = mysql + ", Show_Base_Unit_In_Status, Show_Stock_In_Hand_In_Status, Show_Stock_Allocated_In_Status, Show_Stock_Available_In_Status";
					mysql = mysql + ", Show_In_Transit_Stock_In_Status, Show_On_Order_Stock_In_Status, Show_Advanced_Booked_Stock_In_Status";
					mysql = mysql + ", Show_Stock_Return_In_Transit_In_Status, Show_On_Order_Stock_Of_Sales_In_Status, Show_Expiry_In_Details";
					//-------------------------------------------------------------

					//-------------Posting Details---------------------------------
					mysql = mysql + ", Auto_Post_ICS, Auto_Post_GL_Party, Auto_Post_Status, Auto_Post_GL_Expense, Auto_Post_GL_Inventory, Auto_Post_GL";
					mysql = mysql + ", Batch_Post_ICS, Batch_Post_GL_Party, Batch_Post_Status, Batch_Post_GL_Expense, Batch_Post_GL_Inventory, Batch_Post_GL";
					mysql = mysql + ", Allow_Online_GL_Post";
					//-------------------------------------------------------------

					//-------------Printing Details--------------------------------
					mysql = mysql + ", Show_Print_Preview_First, Show_Page_Setup_First, Close_Preview_Windows_After_Print";
					mysql = mysql + ", Print_After_Save , Use_Num_To_Char_Function";

					if (optCommonQtyEffect[optCrystalReports].Checked)
					{
						mysql = mysql + ", Use_Crystal_Reports_For_Print, Crystal_Report_Id";
					}
					else if (optCommonQtyEffect[optXMLReports].Checked)
					{ 
						mysql = mysql + ", Use_Crystal_Reports_For_Print, Print_Voucher_Name , Print_Voucher_Sql";
					}
					//-------------------------------------------------------------

					//-------------POS Details--------------------------------
					mysql = mysql + ", Enable_ICS_Voucher_Final_Payment_Screen , Import_External_Data, Setfocus_To_Grid_After_Add_New";
					mysql = mysql + ", Check_Part_No_Exists, Check_Prod_Name_Exists, Enable_Partial_Receipt, Enable_ICS_Voucher_Multiline_PreDesc, Enable_ICS_Voucher_Multiline_PostDesc, Enable_Auto_Fill_Pre_Text_With_Product_Desc";
					mysql = mysql + ", Enable_Additional_Voucher_Details_2 , Show_Message_When_Negative_Stock, Include_Location_In_Voucher, Include_Voucher_No_In_Voucher, Include_Reference_No_In_Voucher";
					mysql = mysql + ", Allow_Product_Name_Alteration, Allow_Add_Serial_No_When_Not_Exists, Allow_Add_New_Voucher";
					mysql = mysql + ", Allow_Update_Voucher, Setfocus_To_Newline_After_Barcode_Entered, Setfocus_To_Newline_After_Qty_Entered";
					mysql = mysql + ", Begin_With_Line_Seperator, Show_Amount_Over_Rate, Display_Voucher_No_After_Save, Show_Location_Specific_Product, Show_Default_Location_Salesman";
					mysql = mysql + ", Show_In_Periodical_Batch_Post, Export_To_Word, Allow_Direct_Transaction";
					mysql = mysql + ", Show_Supplier_Tab_In_ICS_Voucher,Show_Expenses_Ldgr_Code_On_Header, Affect_GL_With_Expenses_Ldgr_Cd, Show_Consignment_No_On_Header";
					mysql = mysql + ", Get_Max_New_Voucher_No, Allow_Zero_Amount_Transaction, Show_Message_On_Items_Below_Reorder_Level, Show_Message_On_Items_Below_Minimum_Level";
					mysql = mysql + ", Show_Message_On_Items_Above_Maximum_Level, Generate_Receipt_Payment_Voucher,Show_Flex1_In_Details, Enable_Cash_Credit_On_Header, Import_Cash_Credit_on_link";
					mysql = mysql + ", Overwrite_Price_On_Import, After_Save_Script,Default_cash_cd, Default_Credit_Card_Cd, Default_Price_Level_Priority";
					//--------------------------------------------------------

					//-------------History Details----------------------------
					//If chkCommon(chkLastTranSettings).Value = 1 Then
					mysql = mysql + ", Restore_Last_Tran_Setting";
					//End If
					//--------------------------------------------------------

					//-------------Other Details----------------------------
					if (chkCommon[chkEnableRevision].CheckState == CheckState.Checked)
					{
						mysql = mysql + ", Enable_Revision, Revised_History_Voucher_Type";
					}

					mysql = mysql + ", Reference_No_Generate_Method, Reference_No_L_Caption,Form_Height_Size,Grid_Row_Height_Size,Expenses_Ldgr_Find_Where_Clause,Product_List_Where_Clause, Additional_Cash_Find_Where_Clause, Voucher_Grid_Back_Color";
					mysql = mysql + ", Additional_Ledger_Find_Where_Clause, L_Party_Name_Caption, A_Party_Name_Caption,User_Cd) ";
					//--------------------------------------------------------

					//------------------Basic Details-------------------------
					mysql = mysql + " Values(" + txtCommon[tcVoucherType].Text + ",'" + txtCommon[tcLVouchername].Text + "',N'" + txtCommon[tcAVouchername].Text;
					mysql = mysql + "','" + txtCommon[tcLShortName].Text + "','" + txtCommon[tcAShortName].Text + "'";

					mysql = mysql + ", 'ICS_Transaction', 'ICS_Transaction_Details'"; //Master and Details Table Name
					mysql = mysql + "," + ((txtCommon[tcParentCode].Text == "") ? "101" : txtCommon[tcParentCode].Text);
					mysql = mysql + "," + txtCommon[tcModuleCode].Text;
					mysql = mysql + "," + ((txtCommon[tcPreferenceCode].Text == "") ? "1" : txtCommon[tcPreferenceCode].Text);
					mysql = mysql + "," + txtCommon[tcFindCode].Text;

					mysql = mysql + "," + ((optCommonAffectType[optOnHandStock].Checked) ? 1 : 0).ToString();
					mysql = mysql + "," + ((optCommonAffectType[optInTransitStock].Checked) ? 1 : 0).ToString();
					mysql = mysql + "," + ((optCommonAffectType[optOnOrderPurchaseStock].Checked) ? 1 : 0).ToString();
					mysql = mysql + "," + ((optCommonAffectType[optAllocatedStock].Checked) ? 1 : 0).ToString();
					mysql = mysql + "," + ((optCommonAffectType[optOnOrderSalesStock].Checked) ? 1 : 0).ToString();
					mysql = mysql + "," + ((optCommonAffectType[optSalesreturnInTransitStock].Checked) ? 1 : 0).ToString();
					mysql = mysql + "," + ((optCommonAffectType[optAdvancedBookedStock].Checked) ? 1 : 0).ToString();
					mysql = mysql + "," + ((optCommonAffectType[optReservedStock].Checked) ? 1 : 0).ToString();

					mysql = mysql + "," + ((int) chkCommon[chkAffectGLS].CheckState).ToString();
					mysql = mysql + "," + ((int) chkCommon[chkAffectICS].CheckState).ToString();
					mysql = mysql + "," + ((int) chkCommon[chkAffectCost].CheckState).ToString();
					mysql = mysql + "," + ((int) chkCommon[chkAffectOpeningValue].CheckState).ToString();
					mysql = mysql + "," + ((int) chkCommon[chkStoreToStore].CheckState).ToString();
					mysql = mysql + ",0";

					if (optCommonQtyEffect[optIncreaseStock].Checked)
					{
						mysql = mysql + ",'A'";
					}
					else
					{
						mysql = mysql + ",'L'";
					}

					mysql = mysql + "," + Conversion.Str(cmbCommon[cmbDocumentType].GetItemData(cmbCommon[cmbDocumentType].ListIndex));
					mysql = mysql + "," + ((int) chkCommon[chkShow].CheckState).ToString();
					mysql = mysql + "," + ((int) chkCommon[chkShowInMenu].CheckState).ToString();
					mysql = mysql + "," + ((int) chkCommon[chkAutogenerateVocherNo].CheckState).ToString();
					//--------------------------------------------------------

					//-------------Link Details-------------------------------
					if (optCommonAffectType[optShowImportLinkedVoucherOnHeader].Checked)
					{
						mysql = mysql + ",1,0,'" + txtCommon[tcICSMasterTableName].Text + "'";
						mysql = mysql + ",'" + txtCommon[tcICSDetailsTableName].Text + "'";
						mysql = mysql + ",'" + txtCommon[tcICSParentMasterTableName].Text + "'";
						mysql = mysql + ",'" + txtCommon[tcICSParentDetailsTableName].Text + "'";
						mysql = mysql + "," + ((txtCommon[tcParentICSCode].Text == "") ? "Null" : txtCommon[tcParentICSCode].Text);
						mysql = mysql + "," + ((txtCommon[tcChildICSCode].Text == "") ? "Null" : txtCommon[tcChildICSCode].Text);
					}
					else if (optCommonAffectType[optShowImportLinkedVoucherOnDetails].Checked)
					{ 
						mysql = mysql + ",0,1," + ((int) chkCommon[chkBindToParent].CheckState).ToString();
						mysql = mysql + "," + ((int) chkCommon[chkBindToParentHeaderLocation].CheckState).ToString();
					}
					else if (optCommonAffectType[optHideImportLinkedVoucher].Checked)
					{ 
						mysql = mysql + ", 0,0";
					}
					//     mySql = mySql & "," & IIf(optCommonAffectType(optShowImportLinkedVoucherOnHeader).Value = True, 1, 0)
					//     mySql = mySql & "," & IIf(optCommonAffectType(optShowImportLinkedVoucherOnDetails).Value = True, 1, 0)
					//     mySql = mySql & ",'" & txtCommon(tcICSMasterTableName).Text & "'"
					//     mySql = mySql & ",'" & txtCommon(tcICSDetailsTableName).Text & "'"
					//     mySql = mySql & ",'" & txtCommon(tcICSParentMasterTableName).Text & "'"
					//     mySql = mySql & ",'" & txtCommon(tcICSParentDetailsTableName).Text & "'"
					//     mySql = mySql & "," & IIf(txtCommon(tcParentICSCode).Text = "", "Null", txtCommon(tcParentICSCode).Text)
					//     mySql = mySql & "," & IIf(txtCommon(tcChildICSCode).Text = "", "Null", txtCommon(tcChildICSCode).Text)
					//     mySql = mySql & "," & chkCommon(chkBindToParent).Value
					//     mySql = mySql & "," & chkCommon(chkBindToParentHeaderLocation).Value

					mysql = mysql + "," + ((txtCommon[tcLinkedAssemblyGroupAdjustVoucherCd].Text == "") ? "Null" : txtCommon[tcLinkedAssemblyGroupAdjustVoucherCd].Text);
					mysql = mysql + "," + ((txtCommon[tcDentedStockGeneratedLinkedVoucherCd].Text == "") ? "Null" : txtCommon[tcDentedStockGeneratedLinkedVoucherCd].Text);

					mysql = mysql + "," + ((int) chkCommon[chkAutoPostStockGeneratedVocherNo].CheckState).ToString();
					mysql = mysql + "," + ((txtCommon[tcGLVoucherCd].Text == "") ? "Null" : txtCommon[tcGLVoucherCd].Text);
					mysql = mysql + "," + ((txtCommon[tcGLReceiptVoucherCd].Text == "") ? "108" : txtCommon[tcGLReceiptVoucherCd].Text);
					mysql = mysql + "," + ((txtCommon[tcGLPaymentVoucherCd].Text == "") ? "109" : txtCommon[tcGLPaymentVoucherCd].Text);
					mysql = mysql + "," + ((txtCommon[tcGLJournalVoucherCd].Text == "") ? "103" : txtCommon[tcGLJournalVoucherCd].Text);

					mysql = mysql + "," + ((int) chkCommon[chkEnableRateWhenLinked].CheckState).ToString();
					mysql = mysql + "," + ((int) chkCommon[chkEnablePercentDiscountWhenLinked].CheckState).ToString();
					mysql = mysql + "," + ((int) chkCommon[chkEnableDiscountWhenLinked].CheckState).ToString();
					mysql = mysql + "," + ((int) chkCommon[chkEnableAmountWhenLinked].CheckState).ToString();
					mysql = mysql + "," + ((int) chkCommon[chkEnableCashCreditWhenLinked].CheckState).ToString();
					mysql = mysql + "," + txtCommon[tcVoucherNoMethod].Text;
					mysql = mysql + "," + ((int) chkCommon[chkEnableExcessQtyWhenLinked].CheckState).ToString();

					mysql = mysql + "," + ((int) chkCommon[chkAutoGeneratedLinkedVoucher].CheckState).ToString();
					mysql = mysql + "," + ((int) chkCommon[chkAutoGeneratedLinkedVoucherAllLoc].CheckState).ToString();
					mysql = mysql + "," + ((int) chkCommon[chkAutoGeneratedLinkedVoucherForCash].CheckState).ToString();
					mysql = mysql + "," + ((int) chkCommon[chkImportNonInventoryForParentVoucher].CheckState).ToString();
					mysql = mysql + "," + ((int) chkCommon[chkPreserveGridValueDuringImport].CheckState).ToString();
					//--------------------------------------------------------


					//-------------Show/Hide Details---------------------------------------
					//'Header Section
					mysql = mysql + "," + ((int) chkCommon[chkShowLocation].CheckState).ToString();
					mysql = mysql + "," + ((int) chkCommon[chkShowLedger].CheckState).ToString();
					mysql = mysql + "," + ((int) chkCommon[chkShowCashCredit].CheckState).ToString();
					mysql = mysql + "," + ((int) chkCommon[chkShowAdditionalVoucherDetails].CheckState).ToString();
					mysql = mysql + "," + ((int) chkCommon[chkRemarks].CheckState).ToString();
					mysql = mysql + "," + ((int) chkCommon[chkExchangeRate].CheckState).ToString();
					mysql = mysql + "," + ((int) chkCommon[chkShowSalesman].CheckState).ToString();
					mysql = mysql + "," + ((int) chkCommon[chkShowExpenses].CheckState).ToString();
					mysql = mysql + "," + ((int) chkCommon[chkShowDiscountInPercent].CheckState).ToString();
					mysql = mysql + "," + ((int) chkCommon[chkShowNetAmount].CheckState).ToString();
					mysql = mysql + "," + ((int) chkCommon[chkShowDueDate].CheckState).ToString();
					mysql = mysql + "," + ((int) chkCommon[chkShowJobCd].CheckState).ToString();
					mysql = mysql + "," + ((int) chkCommon[chkShowPartyBal].CheckState).ToString();
					mysql = mysql + "," + ((int) chkCommon[chkShowBatchCd].CheckState).ToString();
					mysql = mysql + "," + ((int) chkCommon[chkShowDocPresc].CheckState).ToString();

					//'Details Section
					mysql = mysql + "," + ((int) chkCommon[chkShowLineNoInList].CheckState).ToString();
					mysql = mysql + "," + ((int) chkCommon[chkShowPartNoInList].CheckState).ToString();
					mysql = mysql + "," + ((int) chkCommon[chkShowProdNameInList].CheckState).ToString();
					mysql = mysql + "," + ((int) chkCommon[chkShowUnitInList].CheckState).ToString();
					mysql = mysql + "," + ((int) chkCommon[chkShowPromoTypeInList].CheckState).ToString();
					mysql = mysql + "," + ((int) chkCommon[chkShowQtyInList].CheckState).ToString();
					mysql = mysql + "," + ((int) chkCommon[chkShowPackQty].CheckState).ToString();
					mysql = mysql + "," + ((int) chkCommon[chkSetFocusToQty].CheckState).ToString();

					mysql = mysql + "," + ((int) chkCommon[chkShowRemainingQtyInList].CheckState).ToString();
					mysql = mysql + "," + ((int) chkCommon[chkShowRateInList].CheckState).ToString();
					mysql = mysql + "," + ((int) chkCommon[chkShowDiscountInList].CheckState).ToString();
					mysql = mysql + "," + ((int) chkCommon[chkShowAmountInList].CheckState).ToString();
					mysql = mysql + "," + ((int) chkCommon[chkShowLocationInList].CheckState).ToString();
					mysql = mysql + "," + ((int) chkCommon[chkShowRemarksInList].CheckState).ToString();
					mysql = mysql + "," + ((int) chkCommon[chkShowSerialNoInList].CheckState).ToString();
					mysql = mysql + "," + ((int) chkCommon[chkShowBarcodeInList].CheckState).ToString();
					mysql = mysql + "," + ((int) chkCommon[chkShowProjectInList].CheckState).ToString();
					mysql = mysql + "," + ((int) chkCommon[chkShowWeightInList].CheckState).ToString();
					mysql = mysql + "," + ((int) chkCommon[chkShowProdDiscountPercentInList].CheckState).ToString();
					mysql = mysql + "," + ((int) chkCommon[chkShowNonInventoryProductInList].CheckState).ToString();
					mysql = mysql + "," + ((int) chkCommon[chkShowDentedStkInList].CheckState).ToString();
					mysql = mysql + "," + ((int) chkCommon[chkShowBaseUnitInList].CheckState).ToString();
					mysql = mysql + "," + ((int) chkCommon[chkShowProductGroupInList].CheckState).ToString();
					mysql = mysql + "," + ((int) chkCommon[chkShowProdCategoryInList].CheckState).ToString();
					mysql = mysql + "," + ((int) chkCommon[chkShowPurPriceInList].CheckState).ToString();
					mysql = mysql + "," + ((int) chkCommon[chkShowSalesPriceInList].CheckState).ToString();
					mysql = mysql + "," + ((int) chkCommon[chkShowRateUOMInList].CheckState).ToString();

					//'Status Section
					mysql = mysql + "," + ((int) chkCommon[chkShowBaseUnitInStatus].CheckState).ToString();
					mysql = mysql + "," + ((int) chkCommon[chkShowStkInHandInStatus].CheckState).ToString();
					mysql = mysql + "," + ((int) chkCommon[chkShowAllocatedStkInStatus].CheckState).ToString();
					mysql = mysql + "," + ((int) chkCommon[chkShowStkAvailableInStatus].CheckState).ToString();
					mysql = mysql + "," + ((int) chkCommon[chkShowStkInTransitInStatus].CheckState).ToString();
					mysql = mysql + "," + ((int) chkCommon[chkShowStkOnOrderInStatus].CheckState).ToString();
					mysql = mysql + "," + ((int) chkCommon[chkAdvStkInStatus].CheckState).ToString();
					mysql = mysql + "," + ((int) chkCommon[chkStkReturnInTransitInStatus].CheckState).ToString();
					mysql = mysql + "," + ((int) chkCommon[chkOnOrderStockOfSales].CheckState).ToString();
					mysql = mysql + "," + ((int) chkCommon[chkShowExpiry].CheckState).ToString();
					//---------------------------------------------------------------------

					//-------------Posting Details---------------------------------------
					mysql = mysql + "," + ((int) chkCommon[chkAutoPostICS].CheckState).ToString();
					mysql = mysql + "," + ((int) chkCommon[chkAutoPostParty].CheckState).ToString();
					mysql = mysql + "," + ((int) chkCommon[chkAutoPostStatus].CheckState).ToString();
					mysql = mysql + "," + ((int) chkCommon[chkAutoPostExpenses].CheckState).ToString();
					mysql = mysql + "," + ((int) chkCommon[chkAutoPostGLInventory].CheckState).ToString();
					mysql = mysql + "," + ((int) chkCommon[chkAutoPostGLS].CheckState).ToString();

					mysql = mysql + "," + ((int) chkCommon[chkBatchPostICS].CheckState).ToString();
					mysql = mysql + "," + ((int) chkCommon[chkBatchPostParty].CheckState).ToString();
					mysql = mysql + "," + ((int) chkCommon[chkBatchPostStatus].CheckState).ToString();
					mysql = mysql + "," + ((int) chkCommon[chkBatchPostExpenses].CheckState).ToString();
					mysql = mysql + "," + ((int) chkCommon[chkBatchPostGLInventory].CheckState).ToString();
					mysql = mysql + "," + ((int) chkCommon[chkBatchPostGLS].CheckState).ToString();
					mysql = mysql + "," + ((int) chkCommon[chkAllowOnlinePosting].CheckState).ToString();
					//---------------------------------------------------------------------

					//-------------Printing Details-------------------------------
					mysql = mysql + "," + ((int) chkCommon[chkPrintPreview].CheckState).ToString();
					mysql = mysql + "," + ((int) chkCommon[chkPageSetup].CheckState).ToString();
					mysql = mysql + "," + ((int) chkCommon[chkCloseWindowAfterPrint].CheckState).ToString();
					mysql = mysql + "," + ((int) chkCommon[chkPrintAfterSave].CheckState).ToString();
					mysql = mysql + "," + ((int) chkCommon[chkNumToChar].CheckState).ToString();

					if (optCommonQtyEffect[optCrystalReports].Checked)
					{
						mysql = mysql + ",1," + ((txtCommon[tcReportCode].Text == "") ? "Null" : txtCommon[tcReportCode].Text);
					}
					else if (optCommonQtyEffect[optXMLReports].Checked)
					{ 
						mysql = mysql + ",0,'" + txtCommon[tcPrintVoucherName].Text + "'";
						mysql = mysql + ",'" + txtCommon[tcPrintVoucherSQL].Text + "'";
					}
					//-------------------------------------------------------------

					//-------------POS Details--------------------------------
					mysql = mysql + "," + ((int) chkCommon[chkEnableICSFinalPymtScreen].CheckState).ToString();
					mysql = mysql + "," + ((int) chkCommon[chkImportExternalData].CheckState).ToString();
					mysql = mysql + "," + ((int) chkCommon[chkSetFocusAfterAddnew].CheckState).ToString();
					mysql = mysql + "," + ((int) chkCommon[chkPartNoExists].CheckState).ToString();
					mysql = mysql + "," + ((int) chkCommon[chkProductNameExists].CheckState).ToString();
					mysql = mysql + "," + ((int) chkCommon[chkPartialReciept].CheckState).ToString();
					mysql = mysql + "," + ((int) chkCommon[chkPreDesc].CheckState).ToString();
					mysql = mysql + "," + ((int) chkCommon[chkPostDesc].CheckState).ToString();
					mysql = mysql + "," + ((int) chkCommon[chkEnableAutoFillPreText].CheckState).ToString();
					mysql = mysql + "," + ((int) chkCommon[chkAdditionalDetails2].CheckState).ToString();
					mysql = mysql + "," + ((int) chkCommon[chkNegativeStk].CheckState).ToString();
					mysql = mysql + "," + ((int) chkCommon[chkLocationInVchr].CheckState).ToString();
					mysql = mysql + "," + ((int) chkCommon[chkVchrNumInVchr].CheckState).ToString();
					mysql = mysql + "," + ((int) chkCommon[chkRefNoInVoucher].CheckState).ToString();
					mysql = mysql + "," + ((int) chkCommon[chkProdNameAlteration].CheckState).ToString();
					mysql = mysql + "," + ((int) chkCommon[chkAllowAddSerialNum].CheckState).ToString();
					mysql = mysql + "," + ((int) chkCommon[chkAllowAddNew].CheckState).ToString();
					mysql = mysql + "," + ((int) chkCommon[chkAllowUpdate].CheckState).ToString();
					mysql = mysql + "," + ((int) chkCommon[chkNewLineAfterBarcode].CheckState).ToString();
					mysql = mysql + "," + ((int) chkCommon[chkNewLineAfterQty].CheckState).ToString();
					mysql = mysql + "," + ((int) chkCommon[chkBeginWithSeperator].CheckState).ToString();
					mysql = mysql + "," + ((int) chkCommon[chkShowAmtOverRate].CheckState).ToString();
					mysql = mysql + "," + ((int) chkCommon[chkDisplayVoucherNumAfterSave].CheckState).ToString();
					mysql = mysql + "," + ((int) chkCommon[chkLocationSpecificProduct].CheckState).ToString();
					mysql = mysql + "," + ((int) chkCommon[chkDefaultLocSman].CheckState).ToString();
					mysql = mysql + "," + ((int) chkCommon[chkShowInPeriodicalBatchPost].CheckState).ToString();
					mysql = mysql + ",'" + txtCommon[tcAfterSaveScript].Text + "'";
					//-------------Default Cash Code----------------------------
					//UPGRADE_WARNING: (2080) IsEmpty was upgraded to a comparison and has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2080
					if (!String.IsNullOrEmpty(txtCommon[tcDefaultCashCode].Text))
					{
						//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mTempReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode("select ldgr_cd from gl_ledger where ldgr_no= '" + txtCommon[tcDefaultCashCode].Text + "'"));
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
						if (!Convert.IsDBNull(mTempReturnValue))
						{
							mysql = mysql + "," + ReflectionHelper.GetPrimitiveValue<string>(mTempReturnValue);
						}
						else
						{
							mysql = mysql + ", Null";
						}
					}
					else
					{
						mysql = mysql + ", Null";
					}
					//--------------------------------------------------------
					//-------------Default Credit Card Code--------Moiz Hakimi --25-02-2010--------------------
					//UPGRADE_WARNING: (2080) IsEmpty was upgraded to a comparison and has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2080
					if (!String.IsNullOrEmpty(txtCommon[tcDefaultCreditCardCode].Text))
					{
						//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mTempReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode("select ldgr_cd from gl_ledger where ldgr_no= '" + txtCommon[tcDefaultCreditCardCode].Text + "'"));
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
						if (!Convert.IsDBNull(mTempReturnValue))
						{
							mysql = mysql + "," + ReflectionHelper.GetPrimitiveValue<string>(mTempReturnValue);
						}
						else
						{
							mysql = mysql + ", Null";
						}
					}
					else
					{
						mysql = mysql + ", Null";
					}
					//--------------------------------------------------------
					mysql = mysql + "," + Conversion.Str(cmbCommon[cmbPriceLevel].GetItemData(cmbCommon[cmbPriceLevel].ListIndex));
					//--------------------------------------------------------

					//-------------History Details----------------------------
					if (chkCommon[chkLastTranSettings].CheckState == CheckState.Checked)
					{
						mysql = mysql + ",1";
					}
					else
					{
						mysql = mysql + ",0";
					}
					//--------------------------------------------------------

					//-------------Other Details----------------------------
					if (chkCommon[chkEnableRevision].CheckState == CheckState.Checked)
					{
						mysql = mysql + ",1," + txtCommon[tcRevisedHistoryVoucherCode].Text;
					}

					mysql = mysql + "," + Conversion.Str(cmbCommon[cmbReferenceType].GetItemData(cmbCommon[cmbReferenceType].ListIndex));
					mysql = mysql + ",N'" + txtCommon[tcReferenceNoCaption].Text + "'";
					mysql = mysql + ",'" + txtCommon[tcAdditionalCashFindWhereClause].Text + "'";
					mysql = mysql + ",'" + txtCommon[tcVoucherGridBackColor].Text + "'";
					mysql = mysql + ",'" + txtCommon[tcAdditionalLdgrFindWhereClause].Text + "'";
					mysql = mysql + ",'" + txtCommon[tcLPartyNameCaption].Text + "'";
					mysql = mysql + ",N'" + txtCommon[tcAPartyNameCaption].Text + "'," + SystemVariables.gLoggedInUserCode.ToString() + ")";
					//--------------------------------------------------------
				}
				else
				{
					mysql = " update ICS_Transaction_Types set ";
					mysql = mysql + "l_voucher_name ='" + txtCommon[tcLVouchername].Text + "'";
					mysql = mysql + ", a_voucher_name =N'" + txtCommon[tcAVouchername].Text + "'";
					mysql = mysql + ", l_short_name ='" + txtCommon[tcLShortName].Text + "'";
					mysql = mysql + ", a_short_name ='" + txtCommon[tcAShortName].Text + "'";

					//-------------Basic Details---------------------------------------
					mysql = mysql + ", Parent_type =" + txtCommon[tcParentCode].Text;
					mysql = mysql + ", module_id ='" + txtCommon[tcModuleCode].Text + "'";
					mysql = mysql + ", find_id ='" + txtCommon[tcFindCode].Text + "'";
					mysql = mysql + ", feature_id ='" + txtCommon[tcPreferenceCode].Text + "'";

					mysql = mysql + ", document_type='" + Conversion.Str(cmbCommon[cmbDocumentType].GetItemData(cmbCommon[cmbDocumentType].ListIndex)) + "'";
					mysql = mysql + ", Affect_On_Hand_Stock =" + ((optCommonAffectType[optOnHandStock].Checked) ? 1 : 0).ToString();
					mysql = mysql + ", Affect_In_Transit_Stock =" + ((optCommonAffectType[optInTransitStock].Checked) ? 1 : 0).ToString();
					mysql = mysql + ", Affect_On_Order_Stock =" + ((optCommonAffectType[optOnOrderPurchaseStock].Checked) ? 1 : 0).ToString();
					mysql = mysql + ", Affect_Allocated_Stock =" + ((optCommonAffectType[optAllocatedStock].Checked) ? 1 : 0).ToString();
					mysql = mysql + ", Affect_On_Order_Stock_Of_Sales =" + ((optCommonAffectType[optOnOrderSalesStock].Checked) ? 1 : 0).ToString();
					mysql = mysql + ", Affect_Stock_Return_In_Transit =" + ((optCommonAffectType[optSalesreturnInTransitStock].Checked) ? 1 : 0).ToString();
					mysql = mysql + ", Affect_Advanced_Booked_Stock =" + ((optCommonAffectType[optAdvancedBookedStock].Checked) ? 1 : 0).ToString();
					mysql = mysql + ", Affect_Reserved_Stock =" + ((optCommonAffectType[optReservedStock].Checked) ? 1 : 0).ToString();

					mysql = mysql + ", Affect_GLS =" + ((int) chkCommon[chkAffectGLS].CheckState).ToString();
					mysql = mysql + ", Affect_ICS =" + ((int) chkCommon[chkAffectICS].CheckState).ToString();
					mysql = mysql + ", Affect_Cost =" + ((int) chkCommon[chkAffectCost].CheckState).ToString();
					mysql = mysql + ", Affect_Opening_Value =" + ((int) chkCommon[chkAffectOpeningValue].CheckState).ToString();
					mysql = mysql + ", Locat_To_Locat =" + ((int) chkCommon[chkStoreToStore].CheckState).ToString();
					mysql = mysql + ", Generate_On_Multiple_Location = 0";

					mysql = mysql + ", Add_Or_Less ='" + ((optCommonQtyEffect[optIncreaseStock].Checked) ? "A" : "L") + "'";
					mysql = mysql + ", Show =" + ((int) chkCommon[chkShow].CheckState).ToString();
					mysql = mysql + ", Show_in_menu =" + ((int) chkCommon[chkShowInMenu].CheckState).ToString();
					mysql = mysql + ", Auto_Generate_Voucher_No =" + ((int) chkCommon[chkAutogenerateVocherNo].CheckState).ToString();
					//-----------------------------------------------------------------

					//-------------Link Details----------------------------------------
					if (optCommonAffectType[optShowImportLinkedVoucherOnHeader].Checked)
					{
						mysql = mysql + ", Show_Import_Linked_Voucher_On_Header = 1";
						mysql = mysql + ", Show_Import_Linked_Voucher_In_Details = 0";
						mysql = mysql + ", Linked_ICS_Master_Table_Name ='" + txtCommon[tcICSMasterTableName].Text + "'";
						mysql = mysql + ", Linked_ICS_Details_Table_Name ='" + txtCommon[tcICSDetailsTableName].Text + "'";
						mysql = mysql + ", Linked_ICS_Parent_Master_Table_Name ='" + txtCommon[tcICSParentMasterTableName].Text + "'";
						mysql = mysql + ", Linked_ICS_Parent_Details_Table_Name ='" + txtCommon[tcICSParentDetailsTableName].Text + "'";
						mysql = mysql + ", Linked_Parent_ICS_Voucher_Type_Cd =" + ((txtCommon[tcParentICSCode].Text == "") ? "Null" : txtCommon[tcParentICSCode].Text);
						mysql = mysql + ", Linked_Child_ICS_Voucher_Type_Cd =" + ((txtCommon[tcChildICSCode].Text == "") ? "Null" : txtCommon[tcChildICSCode].Text);
					}
					else if (optCommonAffectType[optShowImportLinkedVoucherOnDetails].Checked)
					{ 
						mysql = mysql + ", Show_Import_Linked_Voucher_On_Header = 0";
						mysql = mysql + ", Show_Import_Linked_Voucher_In_Details = 1";

					}
					else if (optCommonAffectType[optHideImportLinkedVoucher].Checked)
					{ 
						mysql = mysql + ", Show_Import_Linked_Voucher_On_Header = 0";
						mysql = mysql + ", Show_Import_Linked_Voucher_In_Details = 0";
					}

					mysql = mysql + ", Bind_To_Parent =" + ((int) chkCommon[chkBindToParent].CheckState).ToString();
					mysql = mysql + ", Bind_To_Parent_Header_Location =" + ((int) chkCommon[chkBindToParentHeaderLocation].CheckState).ToString();

					//    mySql = mySql & ", Show_Import_Linked_Voucher_On_Header =" & IIf(optCommonAffectType(optShowImportLinkedVoucherOnHeader).Value = True, 1, 0)
					//    mySql = mySql & ", Show_Import_Linked_Voucher_In_Details = " & IIf(optCommonAffectType(optShowImportLinkedVoucherOnDetails).Value = True, 1, 0)
					//    mySql = mySql & ", Linked_ICS_Master_Table_Name ='" & txtCommon(tcICSMasterTableName).Text & "'"
					//    mySql = mySql & ", Linked_ICS_Details_Table_Name ='" & txtCommon(tcICSDetailsTableName).Text & "'"
					//    mySql = mySql & ", Linked_ICS_Parent_Master_Table_Name ='" & txtCommon(tcICSParentMasterTableName).Text & "'"
					//    mySql = mySql & ", Linked_ICS_Parent_Details_Table_Name ='" & txtCommon(tcICSParentDetailsTableName).Text & "'"
					//    mySql = mySql & ", Linked_Parent_ICS_Voucher_Type_Cd =" & IIf(txtCommon(tcParentICSCode).Text = "", "Null", txtCommon(tcParentICSCode).Text)
					//    mySql = mySql & ", Linked_Child_ICS_Voucher_Type_Cd =" & IIf(txtCommon(tcChildICSCode).Text = "", "Null", txtCommon(tcChildICSCode).Text)
					//    mySql = mySql & ", Bind_To_Parent =" & chkCommon(chkBindToParent).Value
					//    mySql = mySql & ", Bind_To_Parent_Header_Location =" & chkCommon(chkBindToParentHeaderLocation).Value

					mysql = mysql + ", Linked_Assembly_Group_Adjust_Voucher_Type =" + ((txtCommon[tcLinkedAssemblyGroupAdjustVoucherCd].Text == "") ? "Null" : txtCommon[tcLinkedAssemblyGroupAdjustVoucherCd].Text);
					mysql = mysql + ", Dented_Stock_Generated_Linked_Voucher_Type =" + ((txtCommon[tcDentedStockGeneratedLinkedVoucherCd].Text == "") ? "Null" : txtCommon[tcDentedStockGeneratedLinkedVoucherCd].Text);
					mysql = mysql + ", Auto_Post_Stock_Generated_Linked_Voucher_Type =" + ((int) chkCommon[chkAutoPostStockGeneratedVocherNo].CheckState).ToString();

					mysql = mysql + ", Linked_GL_Voucher_Type_Cd =" + ((txtCommon[tcGLVoucherCd].Text == "") ? "Null" : txtCommon[tcGLVoucherCd].Text);
					mysql = mysql + ", Linked_GL_Receipt_Voucher_Type_Cd =" + ((txtCommon[tcGLReceiptVoucherCd].Text == "") ? "108" : txtCommon[tcGLReceiptVoucherCd].Text);
					mysql = mysql + ", Linked_GL_Payment_Voucher_Type_Cd =" + ((txtCommon[tcGLPaymentVoucherCd].Text == "") ? "109" : txtCommon[tcGLPaymentVoucherCd].Text);
					mysql = mysql + ", Linked_GL_Journal_Voucher_Type_Cd =" + ((txtCommon[tcGLJournalVoucherCd].Text == "") ? "103" : txtCommon[tcGLJournalVoucherCd].Text);
					mysql = mysql + ", Enable_Rate_When_Linked =" + ((int) chkCommon[chkEnableRateWhenLinked].CheckState).ToString();
					mysql = mysql + ", Enable_Percent_Discount_On_Header_When_Linked =" + ((int) chkCommon[chkEnablePercentDiscountWhenLinked].CheckState).ToString();
					mysql = mysql + ", Enable_Discount_When_Linked =" + ((int) chkCommon[chkEnableDiscountWhenLinked].CheckState).ToString();
					mysql = mysql + ", Enable_Amount_When_Linked =" + ((int) chkCommon[chkEnableAmountWhenLinked].CheckState).ToString();
					mysql = mysql + ", Enable_Cash_Credit_On_Header_When_Linked =" + ((int) chkCommon[chkEnableCashCreditWhenLinked].CheckState).ToString();
					mysql = mysql + ", Generate_voucher_no_method =" + txtCommon[tcVoucherNoMethod].Text;
					mysql = mysql + ", Allow_Excess_Qty_When_Linked =" + ((int) chkCommon[chkEnableExcessQtyWhenLinked].CheckState).ToString();
					mysql = mysql + ", Auto_Generate_Linked_Voucher =" + ((int) chkCommon[chkAutoGeneratedLinkedVoucher].CheckState).ToString();
					mysql = mysql + ", Auto_Generate_Linked_Voucher_All_Location =" + ((int) chkCommon[chkAutoGeneratedLinkedVoucherAllLoc].CheckState).ToString();
					mysql = mysql + ", Enable_Auto_Generate_Linked_Voucher_For_Cash_Transaction =" + ((int) chkCommon[chkAutoGeneratedLinkedVoucherForCash].CheckState).ToString();
					mysql = mysql + ", Import_Non_Inventory_From_Parent_Voucher =" + ((int) chkCommon[chkImportNonInventoryForParentVoucher].CheckState).ToString();
					mysql = mysql + ", Preserve_Grid_Value_During_Import =" + ((int) chkCommon[chkPreserveGridValueDuringImport].CheckState).ToString();
					//-----------------------------------------------------------------

					//-------------Show/Hide Details-------------------------------
					//Header Section
					mysql = mysql + ", Show_Location_On_Header =" + ((int) chkCommon[chkShowLocation].CheckState).ToString();
					mysql = mysql + ", Show_Ledger_On_Header =" + ((int) chkCommon[chkShowLedger].CheckState).ToString();
					mysql = mysql + ", Show_Cash_Credit_On_Header =" + ((int) chkCommon[chkShowCashCredit].CheckState).ToString();
					mysql = mysql + ", Show_Additional_Voucher_Details =" + ((int) chkCommon[chkShowAdditionalVoucherDetails].CheckState).ToString();
					mysql = mysql + ", Show_Remarks_On_Header =" + ((int) chkCommon[chkRemarks].CheckState).ToString();
					mysql = mysql + ", Show_Exchange_Rate =" + ((int) chkCommon[chkExchangeRate].CheckState).ToString();
					mysql = mysql + ", Show_Salesman =" + ((int) chkCommon[chkShowSalesman].CheckState).ToString();
					mysql = mysql + ", Show_Expenses =" + ((int) chkCommon[chkShowExpenses].CheckState).ToString();
					mysql = mysql + ", Show_Percent_Discount =" + ((int) chkCommon[chkShowDiscountInPercent].CheckState).ToString();
					mysql = mysql + ", Show_Net_Amount =" + ((int) chkCommon[chkShowNetAmount].CheckState).ToString();
					mysql = mysql + ", Show_Due_Date_On_Header =" + ((int) chkCommon[chkShowDueDate].CheckState).ToString();
					mysql = mysql + ", Show_Job_Cd_On_Header =" + ((int) chkCommon[chkShowJobCd].CheckState).ToString();
					mysql = mysql + ", Show_Party_Balance_On_Header =" + ((int) chkCommon[chkShowPartyBal].CheckState).ToString();
					mysql = mysql + ", Show_Batch_Cd_On_Header =" + ((int) chkCommon[chkShowBatchCd].CheckState).ToString();
					mysql = mysql + ", Enable_Doc_Presc_In_Additional_Voucher_Details =" + ((int) chkCommon[chkShowDocPresc].CheckState).ToString();

					//Details Section
					mysql = mysql + ", Show_Line_No_In_Details =" + ((int) chkCommon[chkShowLineNoInList].CheckState).ToString();
					mysql = mysql + ", Show_Part_No_In_Details =" + ((int) chkCommon[chkShowPartNoInList].CheckState).ToString();
					mysql = mysql + ", Show_Product_Name_In_Details =" + ((int) chkCommon[chkShowProdNameInList].CheckState).ToString();
					mysql = mysql + ", Show_Unit_In_Details =" + ((int) chkCommon[chkShowUnitInList].CheckState).ToString();
					mysql = mysql + ", Show_Promo_In_Details =" + ((int) chkCommon[chkShowPromoTypeInList].CheckState).ToString();
					mysql = mysql + ", Show_Qty_In_Details =" + ((int) chkCommon[chkShowQtyInList].CheckState).ToString();
					mysql = mysql + ", Show_Pack_Qty =" + ((int) chkCommon[chkShowPackQty].CheckState).ToString();
					mysql = mysql + ", Setfocus_To_Qty_After_Name_Entered =" + ((int) chkCommon[chkSetFocusToQty].CheckState).ToString();

					mysql = mysql + ", Show_Remaining_Qty_In_Details =" + ((int) chkCommon[chkShowRemainingQtyInList].CheckState).ToString();
					mysql = mysql + ", Show_Rate_In_Details =" + ((int) chkCommon[chkShowRateInList].CheckState).ToString();
					mysql = mysql + ", Show_Product_Discount_In_Details =" + ((int) chkCommon[chkShowDiscountInList].CheckState).ToString();
					mysql = mysql + ", Show_Amount_In_Details =" + ((int) chkCommon[chkShowAmountInList].CheckState).ToString();
					mysql = mysql + ", Show_Location_In_Details =" + ((int) chkCommon[chkShowLocationInList].CheckState).ToString();
					mysql = mysql + ", Show_Remarks_In_Details =" + ((int) chkCommon[chkShowRemarksInList].CheckState).ToString();
					mysql = mysql + ", Show_Serial_In_Details =" + ((int) chkCommon[chkShowSerialNoInList].CheckState).ToString();
					mysql = mysql + ", Show_Barcode_In_Details =" + ((int) chkCommon[chkShowBarcodeInList].CheckState).ToString();
					mysql = mysql + ", Show_Project_In_Details =" + ((int) chkCommon[chkShowProjectInList].CheckState).ToString();
					mysql = mysql + ", Show_Weight_In_Details =" + ((int) chkCommon[chkShowWeightInList].CheckState).ToString();
					mysql = mysql + ", Show_Product_Dis_Per_In_Details =" + ((int) chkCommon[chkShowProdDiscountPercentInList].CheckState).ToString();
					mysql = mysql + ", Show_Non_Inventory_In_Details =" + ((int) chkCommon[chkShowNonInventoryProductInList].CheckState).ToString();
					mysql = mysql + ", Show_Dented_Stock_In_Details =" + ((int) chkCommon[chkShowDentedStkInList].CheckState).ToString();
					mysql = mysql + ", Show_Product_Base_Unit_In_List =" + ((int) chkCommon[chkShowBaseUnitInList].CheckState).ToString();
					mysql = mysql + ", Show_Product_Group_In_List =" + ((int) chkCommon[chkShowProductGroupInList].CheckState).ToString();
					mysql = mysql + ", Show_Product_Category_In_List =" + ((int) chkCommon[chkShowProdCategoryInList].CheckState).ToString();
					mysql = mysql + ", Show_Purchase_Price_In_List =" + ((int) chkCommon[chkShowPurPriceInList].CheckState).ToString();
					mysql = mysql + ", Show_Sales_Price_In_List =" + ((int) chkCommon[chkShowSalesPriceInList].CheckState).ToString();
					mysql = mysql + ", Show_Rate_UOM_In_Details =" + ((int) chkCommon[chkShowRateUOMInList].CheckState).ToString();

					//Status Section
					mysql = mysql + ", Show_Base_Unit_In_Status =" + ((int) chkCommon[chkShowBaseUnitInStatus].CheckState).ToString();
					mysql = mysql + ", Show_Stock_In_Hand_In_Status =" + ((int) chkCommon[chkShowStkInHandInStatus].CheckState).ToString();
					mysql = mysql + ", Show_Stock_Allocated_In_Status =" + ((int) chkCommon[chkShowAllocatedStkInStatus].CheckState).ToString();
					mysql = mysql + ", Show_Stock_Available_In_Status =" + ((int) chkCommon[chkShowStkAvailableInStatus].CheckState).ToString();
					mysql = mysql + ", Show_In_Transit_Stock_In_Status =" + ((int) chkCommon[chkShowStkInTransitInStatus].CheckState).ToString();
					mysql = mysql + ", Show_On_Order_Stock_In_Status =" + ((int) chkCommon[chkShowStkOnOrderInStatus].CheckState).ToString();
					mysql = mysql + ", Show_Advanced_Booked_Stock_In_Status =" + ((int) chkCommon[chkAdvStkInStatus].CheckState).ToString();
					mysql = mysql + ", Show_Stock_Return_In_Transit_In_Status =" + ((int) chkCommon[chkStkReturnInTransitInStatus].CheckState).ToString();
					mysql = mysql + ", Show_On_Order_Stock_Of_Sales_In_Status =" + ((int) chkCommon[chkOnOrderStockOfSales].CheckState).ToString();
					mysql = mysql + ", Show_Expiry_In_Details =" + ((int) chkCommon[chkShowExpiry].CheckState).ToString();
					//-------------------------------------------------------------

					//-------------Posting Details-------------------------------
					mysql = mysql + ", Auto_Post_ICS =" + ((int) chkCommon[chkAutoPostICS].CheckState).ToString();
					mysql = mysql + ", Auto_Post_GL_Party =" + ((int) chkCommon[chkAutoPostParty].CheckState).ToString();
					mysql = mysql + ", Auto_Post_Status =" + ((int) chkCommon[chkAutoPostStatus].CheckState).ToString();
					mysql = mysql + ", Auto_Post_GL_Expense =" + ((int) chkCommon[chkAutoPostExpenses].CheckState).ToString();
					mysql = mysql + ", Auto_Post_GL_Inventory =" + ((int) chkCommon[chkAutoPostGLInventory].CheckState).ToString();
					mysql = mysql + ", Auto_Post_GL =" + ((int) chkCommon[chkAutoPostGLS].CheckState).ToString();

					mysql = mysql + ", Batch_Post_ICS =" + ((int) chkCommon[chkBatchPostICS].CheckState).ToString();
					mysql = mysql + ", Batch_Post_GL_Party =" + ((int) chkCommon[chkBatchPostParty].CheckState).ToString();
					mysql = mysql + ", Batch_Post_Status =" + ((int) chkCommon[chkBatchPostStatus].CheckState).ToString();
					mysql = mysql + ", Batch_Post_GL_Expense =" + ((int) chkCommon[chkBatchPostExpenses].CheckState).ToString();
					mysql = mysql + ", Batch_Post_GL_Inventory =" + ((int) chkCommon[chkBatchPostGLInventory].CheckState).ToString();
					mysql = mysql + ", Batch_Post_GL =" + ((int) chkCommon[chkBatchPostGLS].CheckState).ToString();

					mysql = mysql + ", Allow_Online_GL_Post =" + ((int) chkCommon[chkAllowOnlinePosting].CheckState).ToString();

					//-------------------------------------------------------------

					//-------------Printing Details--------------------------------
					mysql = mysql + ", Show_Print_Preview_First =" + ((int) chkCommon[chkPrintPreview].CheckState).ToString();
					mysql = mysql + ", Show_Page_Setup_First =" + ((int) chkCommon[chkPageSetup].CheckState).ToString();
					mysql = mysql + ", Close_Preview_Windows_After_Print =" + ((int) chkCommon[chkCloseWindowAfterPrint].CheckState).ToString();
					mysql = mysql + ", Print_After_Save =" + ((int) chkCommon[chkPrintAfterSave].CheckState).ToString();
					mysql = mysql + ", Use_Num_To_Char_Function =" + ((int) chkCommon[chkNumToChar].CheckState).ToString();

					if (optCommonQtyEffect[optCrystalReports].Checked)
					{
						mysql = mysql + ", Use_Crystal_Reports_For_Print = 1";
						mysql = mysql + ", Crystal_Report_Id =" + ((txtCommon[tcReportCode].Text == "") ? "Null" : txtCommon[tcReportCode].Text);
					}
					else
					{
						mysql = mysql + ", Use_Crystal_Reports_For_Print = 0";
						mysql = mysql + ", Print_Voucher_Name ='" + txtCommon[tcPrintVoucherName].Text + "'";
						mysql = mysql + ", Print_Voucher_Sql ='" + StringsHelper.Replace(txtCommon[tcPrintVoucherSQL].Text, "'", "''", 1, -1, CompareMethod.Binary) + "'";
					}
					//-------------------------------------------------------------

					//-------------POS Details--------------------------------
					mysql = mysql + ", Enable_ICS_Voucher_Final_Payment_Screen =" + ((int) chkCommon[chkEnableICSFinalPymtScreen].CheckState).ToString();
					mysql = mysql + ", Import_External_Data =" + ((int) chkCommon[chkImportExternalData].CheckState).ToString();
					mysql = mysql + ", Setfocus_To_Grid_After_Add_New =" + ((int) chkCommon[chkSetFocusAfterAddnew].CheckState).ToString();
					mysql = mysql + ", Check_Part_No_Exists =" + ((int) chkCommon[chkPartNoExists].CheckState).ToString();
					mysql = mysql + ", Check_Prod_Name_Exists =" + ((int) chkCommon[chkProductNameExists].CheckState).ToString();
					mysql = mysql + ", Enable_Partial_Receipt =" + ((int) chkCommon[chkPartialReciept].CheckState).ToString();
					mysql = mysql + ", Enable_ICS_Voucher_Multiline_PreDesc =" + ((int) chkCommon[chkPreDesc].CheckState).ToString();
					mysql = mysql + ", Enable_ICS_Voucher_Multiline_PostDesc =" + ((int) chkCommon[chkPostDesc].CheckState).ToString();
					mysql = mysql + ", Enable_Auto_Fill_Pre_Text_With_Product_Desc =" + ((int) chkCommon[chkEnableAutoFillPreText].CheckState).ToString();
					mysql = mysql + ", Enable_Additional_Voucher_Details_2 =" + ((int) chkCommon[chkAdditionalDetails2].CheckState).ToString();
					mysql = mysql + ", Show_Message_When_Negative_Stock =" + ((int) chkCommon[chkNegativeStk].CheckState).ToString();
					mysql = mysql + ", Include_Location_In_Voucher =" + ((int) chkCommon[chkLocationInVchr].CheckState).ToString();
					mysql = mysql + ", Include_Voucher_No_In_Voucher =" + ((int) chkCommon[chkVchrNumInVchr].CheckState).ToString();
					mysql = mysql + ", Include_Reference_No_In_Voucher =" + ((int) chkCommon[chkRefNoInVoucher].CheckState).ToString();
					mysql = mysql + ", Allow_Product_Name_Alteration =" + ((int) chkCommon[chkProdNameAlteration].CheckState).ToString();
					mysql = mysql + ", Allow_Add_Serial_No_When_Not_Exists =" + ((int) chkCommon[chkAllowAddSerialNum].CheckState).ToString();
					mysql = mysql + ", Allow_Add_New_Voucher =" + ((int) chkCommon[chkAllowAddNew].CheckState).ToString();
					mysql = mysql + ", Allow_Update_Voucher =" + ((int) chkCommon[chkAllowUpdate].CheckState).ToString();
					mysql = mysql + ", Setfocus_To_Newline_After_Barcode_Entered =" + ((int) chkCommon[chkNewLineAfterBarcode].CheckState).ToString();
					mysql = mysql + ", Setfocus_To_Newline_After_Qty_Entered =" + ((int) chkCommon[chkNewLineAfterQty].CheckState).ToString();
					mysql = mysql + ", Begin_With_Line_Seperator =" + ((int) chkCommon[chkBeginWithSeperator].CheckState).ToString();
					mysql = mysql + ", Show_Amount_Over_Rate =" + ((int) chkCommon[chkShowAmtOverRate].CheckState).ToString();
					mysql = mysql + ", Display_Voucher_No_After_Save =" + ((int) chkCommon[chkDisplayVoucherNumAfterSave].CheckState).ToString();
					mysql = mysql + ", Show_Location_Specific_Product =" + ((int) chkCommon[chkLocationSpecificProduct].CheckState).ToString();
					mysql = mysql + ", Show_Default_Location_Salesman =" + ((int) chkCommon[chkDefaultLocSman].CheckState).ToString();
					mysql = mysql + ", Show_In_Periodical_Batch_Post =" + ((int) chkCommon[chkShowInPeriodicalBatchPost].CheckState).ToString();
					mysql = mysql + ", Export_To_Word =" + ((int) chkCommon[chkExportToWord].CheckState).ToString();
					mysql = mysql + ", Allow_Direct_Transaction =" + ((int) chkCommon[chkAllowDirectTransaction].CheckState).ToString();
					mysql = mysql + ", Show_Supplier_Tab_In_ICS_Voucher =" + ((int) chkCommon[chkShowSupplierTab].CheckState).ToString();
					mysql = mysql + ", Show_Expenses_Ldgr_Code_On_Header =" + ((int) chkCommon[chkShowExpLdgrCode].CheckState).ToString();
					mysql = mysql + ", Affect_GL_With_Expenses_Ldgr_Cd =" + ((int) chkCommon[chkAffectGLWithExpenses].CheckState).ToString();
					mysql = mysql + ", Show_Consignment_No_On_Header =" + ((int) chkCommon[chkShowConsignmentNo].CheckState).ToString();
					mysql = mysql + ", Get_Max_New_Voucher_No =" + ((int) chkCommon[chkGetMaxNewVoucherNo].CheckState).ToString();
					mysql = mysql + ", Allow_Zero_Amount_Transaction =" + ((int) chkCommon[chkAllowZeroAmountTransaction].CheckState).ToString();
					mysql = mysql + ", Show_Message_On_Items_Below_Reorder_Level =" + ((int) chkCommon[chkShowBelowReorderLevelMsg].CheckState).ToString();
					mysql = mysql + ", Show_Message_On_Items_Below_Minimum_Level =" + ((int) chkCommon[chkShowMinimumLevelMsg].CheckState).ToString();
					mysql = mysql + ", Show_Message_On_Items_Above_Maximum_Level =" + ((int) chkCommon[chkShowMsximumLevelMsg].CheckState).ToString();
					mysql = mysql + ", Generate_Receipt_Payment_Voucher =" + ((int) chkCommon[chkGenerateReceiptPaymentVoucher].CheckState).ToString();
					mysql = mysql + ", Show_Flex1_In_Details =" + ((int) chkCommon[chkShowFlex1].CheckState).ToString();
					mysql = mysql + ", Enable_Cash_Credit_On_Header =" + ((int) chkCommon[chkEnableCashCredit].CheckState).ToString();
					mysql = mysql + ", Import_Cash_Credit_on_link =" + ((int) chkCommon[chkImportCashCredit].CheckState).ToString();
					mysql = mysql + ", Overwrite_Price_On_Import =" + ((int) chkCommon[chkImportPriceOverwrite].CheckState).ToString();

					mysql = mysql + ", After_Save_Script =" + ((txtCommon[tcAfterSaveScript].Text == "") ? "NULL" : "N'" + txtCommon[tcAfterSaveScript].Text + "'");
					//--------------------------------------------------------

					//-------------Default Cash Code----------------------------
					//UPGRADE_WARNING: (2080) IsEmpty was upgraded to a comparison and has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2080
					if (!String.IsNullOrEmpty(txtCommon[tcDefaultCashCode].Text))
					{
						//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mTempReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode("select ldgr_cd from gl_ledger where ldgr_no= '" + txtCommon[tcDefaultCashCode].Text + "'"));
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
						if (!Convert.IsDBNull(mTempReturnValue))
						{
							mysql = mysql + ", Default_cash_cd = " + ReflectionHelper.GetPrimitiveValue<string>(mTempReturnValue);
						}
						else
						{
							mysql = mysql + ", Default_cash_cd = Null";
						}
					}
					else
					{
						mysql = mysql + ", Default_cash_cd = Null";
					}
					//--------------------------------------------------------
					//-------------Default Cash Code-----Moiz Hakimi----25-02-2010-----------------------
					//UPGRADE_WARNING: (2080) IsEmpty was upgraded to a comparison and has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2080
					if (!String.IsNullOrEmpty(txtCommon[tcDefaultCreditCardCode].Text))
					{
						//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mTempReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode("select ldgr_cd from gl_ledger where ldgr_no= '" + txtCommon[tcDefaultCreditCardCode].Text + "'"));
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
						if (!Convert.IsDBNull(mTempReturnValue))
						{
							mysql = mysql + ", Default_Credit_Card_Cd = " + ReflectionHelper.GetPrimitiveValue<string>(mTempReturnValue);
						}
						else
						{
							mysql = mysql + ", Default_Credit_Card_Cd = Null";
						}
					}
					else
					{
						mysql = mysql + ", Default_Credit_Card_Cd = Null";
					}
					//--------------------------------------------------------
					mysql = mysql + ", Default_Price_Level_Priority =" + Conversion.Str(cmbCommon[cmbPriceLevel].GetItemData(cmbCommon[cmbPriceLevel].ListIndex));
					//--------------------------------------------------------

					//-------------History Details----------------------------
					if (chkCommon[chkLastTranSettings].CheckState == CheckState.Checked)
					{
						mysql = mysql + ", Restore_Last_Tran_Setting = 1";
					}
					else
					{
						mysql = mysql + ", Restore_Last_Tran_Setting = 0";
					}
					//--------------------------------------------------------

					//-------------Other Details----------------------------
					if (chkCommon[chkEnableRevision].CheckState == CheckState.Checked)
					{
						mysql = mysql + ", Enable_Revision = 1, Revised_History_Voucher_Type =" + ((txtCommon[tcRevisedHistoryVoucherCode].Text == "") ? "Null" : txtCommon[tcRevisedHistoryVoucherCode].Text);
					}
					else
					{
						mysql = mysql + ", Enable_Revision = 0";
					}
					mysql = mysql + ", Reference_No_Generate_Method =" + Conversion.Str(cmbCommon[cmbReferenceType].GetItemData(cmbCommon[cmbReferenceType].ListIndex));
					mysql = mysql + ", Reference_No_L_Caption =" + ((txtCommon[tcReferenceNoCaption].Text == "") ? "NULL" : "N'" + txtCommon[tcReferenceNoCaption].Text + "'");
					mysql = mysql + ", Form_Height_Size = N'" + txtCommon[tcFormHeightSize].Text + "'";
					mysql = mysql + ", Grid_Row_Height_Size =N'" + txtCommon[tcGridRowHeightSize].Text + "'";
					mysql = mysql + ", Expenses_Ldgr_Find_Where_Clause =" + ((txtCommon[tcExpensesLdgrFindWhereClause].Text == "") ? "NULL" : "N'" + StringsHelper.Replace(txtCommon[tcExpensesLdgrFindWhereClause].Text, "'", "''", 1, -1, CompareMethod.Binary) + "'");
					mysql = mysql + ", Product_List_Where_Clause =" + ((txtCommon[tcProductListWhereClause].Text == "") ? "Null" : "'" + StringsHelper.Replace(txtCommon[tcProductListWhereClause].Text, "'", "''", 1, -1, CompareMethod.Binary) + "'");
					mysql = mysql + ", Additional_Cash_Find_Where_Clause =" + ((txtCommon[tcAdditionalCashFindWhereClause].Text == "") ? "Null" : "'" + StringsHelper.Replace(txtCommon[tcAdditionalCashFindWhereClause].Text, "'", "''", 1, -1, CompareMethod.Binary) + "'");
					mysql = mysql + ", Voucher_Grid_Back_Color ='" + txtCommon[tcVoucherGridBackColor].Text + "'";
					mysql = mysql + ", Additional_Ledger_Find_Where_Clause =" + ((txtCommon[tcAdditionalLdgrFindWhereClause].Text == "") ? "Null" : "'" + StringsHelper.Replace(txtCommon[tcAdditionalLdgrFindWhereClause].Text, "'", "''", 1, -1, CompareMethod.Binary) + "'");
					mysql = mysql + ", L_Party_Name_Caption ='" + txtCommon[tcLPartyNameCaption].Text + "'";
					mysql = mysql + ", A_Party_Name_Caption =N'" + txtCommon[tcAPartyNameCaption].Text + "'";
					mysql = mysql + ", user_cd = " + SystemVariables.gLoggedInUserCode.ToString();
					mysql = mysql + " where voucher_type = " + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
					//------------------------------------------------------
				}

				SqlCommand TempCommand = null;
				TempCommand = SystemVariables.gConn.CreateCommand();
				TempCommand.CommandText = mysql;
				TempCommand.ExecuteNonQuery();

				//**--This procedure is for insert Report detail information

				int cnt = 0;
				if (aReportDetails.GetLength(0) > 0)
				{
					this.grdPrintTask.UpdateData();
					mysql = "delete ICS_Print_Task_Detail ";
					mysql = mysql + " where ";
					mysql = mysql + " Voucher_Type = " + Conversion.Str(mSearchValue);
					SqlCommand TempCommand_2 = null;
					TempCommand_2 = SystemVariables.gConn.CreateCommand();
					TempCommand_2.CommandText = mysql;
					TempCommand_2.ExecuteNonQuery();
					int tempForEndVar = aReportDetails.GetLength(0) - 1;
					for (cnt = 0; cnt <= tempForEndVar; cnt++)
					{

						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
						if (Convert.IsDBNull(aReportDetails.GetValue(cnt, grdReportColumn)) || Convert.ToString(aReportDetails.GetValue(cnt, grdReportColumn)) == "")
						{
							MessageBox.Show("Invalid Report ID", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
							grdPrintTask.Col = grdReportColumn;
							throw new Exception();
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

							mysql = "insert into ICS_Print_Task_Detail ";
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

							SqlCommand TempCommand_3 = null;
							TempCommand_3 = SystemVariables.gConn.CreateCommand();
							TempCommand_3.CommandText = mysql;
							TempCommand_3.ExecuteNonQuery();
						}

					}
				}
				//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.CommitTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				SystemVariables.gConn.CommitTrans();

				//'Save Voucher Parent Details
				if (optCommonAffectType[optShowImportLinkedVoucherOnDetails].Checked)
				{
					SaveVoucherParentDetails();
				}

				//' Refresh Voucher Types Recordset
				//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsVoucherTypes.ActiveConnection was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				SystemVariables.rsVoucherTypes.setActiveConnection(SystemVariables.gConn);
				//UPGRADE_ISSUE: (2064) ADODB.Recordset method rsVoucherTypes.Requery was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				SystemVariables.rsVoucherTypes.Requery(-1);
				//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsVoucherTypes.ActiveConnection was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				SystemVariables.rsVoucherTypes.setActiveConnection(null);

				result = true;
				tabVoucherDetails.CurrTab = Convert.ToInt16(cBasicMasterDetails);
				FirstFocusObject.Focus();

				//UPGRADE_ISSUE: (2064) ADODB.CursorLocationEnum property CursorLocationEnum.adUseClient was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsVoucherTypes.CursorLocation was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				SystemVariables.rsVoucherTypes.setCursorLocation(UpgradeStubs.ADODB_CursorLocationEnum.getadUseClient());
				SqlDataAdapter adap = new SqlDataAdapter("select * from ICS_Transaction_Types", SystemVariables.gConn);
				SystemVariables.rsVoucherTypes.Tables.Clear();
				adap.Fill(SystemVariables.rsVoucherTypes);
				//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsVoucherTypes.ActiveConnection was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				SystemVariables.rsVoucherTypes.setActiveConnection(null);
			}
			catch (System.Exception excep)
			{

				int mReturnErrorType = 0;
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				mReturnErrorType = SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, excep.Message, this.Name, "GetRecord", SystemConstants.msg10);
				//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				SystemVariables.gConn.RollbackTrans();
				result = false;
			}
			return result;
		}
		private void SaveVoucherParentDetails()
		{
			StringBuilder mysql = new StringBuilder();
			int cnt = 0;
			if (optCommonAffectType[optShowImportLinkedVoucherOnDetails].Checked)
			{
				if (CurrentFormMode == SystemVariables.SystemFormModes.frmEditMode)
				{
					mysql = new StringBuilder("delete from ICS_Transaction_Type_Link ");
					mysql.Append(" where voucher_type = " + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue));
					SqlCommand TempCommand = null;
					TempCommand = SystemVariables.gConn.CreateCommand();
					TempCommand.CommandText = mysql.ToString();
					TempCommand.ExecuteNonQuery();
				}

				int tempForEndVar = aParentDetails.GetLength(0) - 1;
				for (cnt = 0; cnt <= tempForEndVar; cnt++)
				{
					if (!SystemProcedure2.IsItEmpty(aParentDetails.GetValue(cnt, grdParentCodeColumn), SystemVariables.DataType.NumberType))
					{
						mysql = new StringBuilder(" insert into ICS_Transaction_Type_Link(voucher_type,parent_voucher_type) ");
						mysql.Append("values(" + txtCommon[tcVoucherType].Text);
						mysql.Append("," + Convert.ToString(aParentDetails.GetValue(cnt, grdParentCodeColumn)) + ")");
						SqlCommand TempCommand_2 = null;
						TempCommand_2 = SystemVariables.gConn.CreateCommand();
						TempCommand_2.CommandText = mysql.ToString();
						TempCommand_2.ExecuteNonQuery();
					}
				}
			}
			//gConn.CommitTrans
		}
		private void UCOkCancel1_CancelClick(Object Sender, EventArgs e)
		{
			fraCommon[fraVoucherParentDetails].Visible = false;
			tabVoucherDetails.Enabled = true;
		}

		private void UCOkCancel1_OKClick(Object Sender, EventArgs e)
		{
			if (!SystemProcedure2.IsItEmpty(grdVoucherParentDetails.Columns[grdParentCodeColumn].Value, SystemVariables.DataType.NumberType))
			{
				grdVoucherParentDetails.UpdateData();
			}
			fraCommon[fraVoucherParentDetails].Visible = false;
			tabVoucherDetails.Enabled = true;
		}


		//Private Sub grdPrintTask_ButtonClick(ByVal ColIndex As Integer)
		//If ColIndex = grdPOSColumn Then
		//    Dim mTempSearchValue As Variant
		//
		//    mTempSearchValue = FindItem(2001500)
		//    If Not IsNull(mTempSearchValue) Then
		//        grdPrintTask.Columns.Item(ColIndex) = mTempSearchValue(0)
		//
		//    End If
		//End If
		//End Sub

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
			mysql = mysql + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "L_Report_Name" : "A_Report_Name") + " as Report_Name, ";
			mysql = mysql + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "External_Report_File_Name" : "A_External_Report_File_Name") + " as Report_File ";
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

		//Private Sub grdPrintTask_FetchCellStyle(ByVal Condition As Integer, ByVal Split As Integer, Bookmark As Variant, ByVal Col As Integer, ByVal CellStyle As TrueOleDBGrid80.StyleDisp)
		//Dim aCurrentArray As XArrayDB
		//
		//If Col = grdShowPreviewColumn Or Col = grdPromptForPrintColumn Or Col = grdDefaultSelectColumn _
		//'        Or Col = grdShowOptionColumn Or Col = grdShowPrinterColumn Then
		//    Set aCurrentArray = aReportDetails
		//
		//        If aCurrentArray(Val(Bookmark), Col) = vbTrue Then
		//            Set CellStyle.ForegroundPicture = frmSysMain.imlSystemIcons.ListImages.Item("imgChecked2").Picture
		//        Else
		//            Set CellStyle.ForegroundPicture = frmSysMain.imlSystemIcons.ListImages.Item("imgUnchecked").Picture
		//        End If
		//
		//    CellStyle.ForegroundPicturePosition = dbgFPPictureOnly
		//End If
		//Set aCurrentArray = Nothing
		//End Sub

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
					cmbPrintList.Width = grdPrintTask.Splits[0].DisplayColumns[grdReportColumn].Width + 333; 
					cmbPrintList.DisplayColumns[0].Width = 67; 
					cmbPrintList.DisplayColumns[1].Width = 167; 
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
			string cGridColor = (0xB8E7F8).ToString();
			string mysql = "";
			int cnt = 0;
			SqlDataReader rsLocalRec = null;


			SystemGrid.DefineSystemVoucherGrid(grdPrintTask, true, true, true, (0xFFFFFF).ToString(), (0x0).ToString(), true, false, C1.Win.C1TrueDBGrid.MarqueeEnum.FloatingEditor, 2.5f, 1.4f, cGridColor);

			SystemGrid.DefineSystemVoucherGridColumn(grdPrintTask, "LN", 400, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false);
			//If GetSystemPreferenceSetting("enable_pos_counter") = True Then
			SystemGrid.DefineSystemVoucherGridColumn(grdPrintTask, "POS Counter", 2000, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, true, true, "cmbPrintList");
			//End If
			SystemGrid.DefineSystemVoucherGridColumn(grdPrintTask, "Report", 1500, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, true, false, "cmbPrintList", false, true, false, false, false, false, 200);
			SystemGrid.DefineSystemVoucherGridColumn(grdPrintTask, "Printer", 2700, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, true, false, "cmbPrintList", false, true, false, false, false, false, 200);
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

			aReportDetails = new XArrayHelper();
			if (CurrentFormMode == SystemVariables.SystemFormModes.frmEditMode)
			{

				mysql = "SELECT  Print_Task_Cd, Voucher_Type, Report_Id ";
				mysql = mysql + ", POS_Counter_Cd, Printer_Path, Auto_Print_After_Save, enable_print_on_edit";
				mysql = mysql + ", Show_Preview, Show_Option, Show_Printer, Prompt_For_Print_After_Save, default_Select";
				mysql = mysql + " FROM ICS_Print_Task_Detail ";
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

		public void IRoutine()
		{
			if (ActiveControl.Name != "grdPrintTask")
			{
				grdPrintTask.Focus();
			}

			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(grdPrintTask.Bookmark))
			{
				//UPGRADE_ISSUE: (2064) XArrayDBObject.XArrayDB method aReportDetails.InsertRows was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				aReportDetails.InsertRows(ReflectionHelper.GetPrimitiveValue<int>(grdPrintTask.Bookmark), 1);
				AssignReportGridLineNumbers();
				grdPrintTask.Rebind(true);
				grdPrintTask.Focus();
				grdPrintTask.Refresh();
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


		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBGrid Event grdPrintTask.PostEvent was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void grdPrintTask_PostEvent(int MsgId)
		{

			if (mLastCol == grdPrintTask.Col && mLastRow == grdPrintTask.Row)
			{
				return;
			}

			int Col = grdPrintTask.Col;
			if (Col == grdAutoPrintColumn || Col == grdEnablePrintOnEditColumn || Col == grdShowPreviewColumn || Col == grdPromptForPrintColumn || Col == grdDefaultSelectColumn || Col == grdShowOptionColumn || Col == grdShowPrinterColumn)
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

		private void grdPrintTask_KeyPress(Object eventSender, KeyPressEventArgs eventArgs)
		{
			int KeyAscii = Convert.ToInt32(eventArgs.KeyChar);
			try
			{

				int Col = grdPrintTask.Col;
				if (Col == grdAutoPrintColumn || Col == grdEnablePrintOnEditColumn || Col == grdShowPreviewColumn || Col == grdPromptForPrintColumn || Col == grdDefaultSelectColumn || Col == grdShowOptionColumn || Col == grdShowPrinterColumn)
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
	}
}