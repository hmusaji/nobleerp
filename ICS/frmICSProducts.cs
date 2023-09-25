
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;




namespace Xtreme
{
	internal partial class frmICSItems
		: System.Windows.Forms.Form
	{


		private int mThisFormID = 0;
		private object mSearchValue = null;
		private string mTimeStamp = "";
		private SystemVariables.SystemFormModes mCurrentFormMode = (SystemVariables.SystemFormModes) 0;
		private XArrayHelper aProductAssemblyDetails = null;
		private XArrayHelper aProductStockLevels = null;
		private XArrayHelper _aProductSupplierDetails = null;
		public frmICSItems()
{
InitializeComponent();
} 
 public  void frmICSItems_old()
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


		private XArrayHelper aProductSupplierDetails
		{
			get
			{
				if (_aProductSupplierDetails is null)
				{
					_aProductSupplierDetails = new XArrayHelper();
				}
				return _aProductSupplierDetails;
			}
			set
			{
				_aProductSupplierDetails = value;
			}
		}

		private XArrayHelper _aProductPriceDetails = null;
		private XArrayHelper aProductPriceDetails
		{
			get
			{
				if (_aProductPriceDetails is null)
				{
					_aProductPriceDetails = new XArrayHelper();
				}
				return _aProductPriceDetails;
			}
			set
			{
				_aProductPriceDetails = value;
			}
		}

		private XArrayHelper _aProductBarcodeDetails = null;
		private XArrayHelper aProductBarcodeDetails
		{
			get
			{
				if (_aProductBarcodeDetails is null)
				{
					_aProductBarcodeDetails = new XArrayHelper();
				}
				return _aProductBarcodeDetails;
			}
			set
			{
				_aProductBarcodeDetails = value;
			}
		}

		private XArrayHelper _aProductActivityDetails = null;
		private XArrayHelper aProductActivityDetails
		{
			get
			{
				if (_aProductActivityDetails is null)
				{
					_aProductActivityDetails = new XArrayHelper();
				}
				return _aProductActivityDetails;
			}
			set
			{
				_aProductActivityDetails = value;
			}
		}


		private DataSet rsProductCodeList = null;
		private DataSet rsPriceList = null;
		private DataSet rsItemType = null;
		private DataSet rsBarcodeList = null;
		private DataSet rsActivityList = null;

		
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

		public Control FirstFocusObject = null;
		private frmICSAlternateUnit _oAltUnitForm = null;
		public frmICSAlternateUnit oAltUnitForm
		{
			get
			{
				if (_oAltUnitForm is null)
				{
					_oAltUnitForm = frmICSAlternateUnit.CreateInstance();
				}
				return _oAltUnitForm;
			}
			set
			{
				_oAltUnitForm = value;
			}
		}


		private string mNewBaseUnitCode = "";
		private string mNewReportUnitCode = "";
		private string mNewGroupCode = "";
		private string mNewCategoryCode = "";
		private string mNewPrefferedSupplierCode = "";
		private bool mAltUnitFormInitialised = false;
		private bool mFormIsInitialized = false;
		private bool mAttemptToSetFocus = false;
		private clsToolbar oThisFormToolBar = null;

		private bool mBasicMasterDetailsTabClicked = false;
		private bool mPricingDetailsTabClicked = false;
		private bool mAssemblyDetailsTabClicked = false;
		private bool mOtherMasterDetailsTabClicked = false;
		private bool mStockLevelDetailsTabClicked = false;
		private bool mSupplierDetailsTabClicked = false;
		private bool mBarcodeDetailsTabClicked = false;
		private bool mActivityDetailsTabClicked = false;

		//**--define form level constants
		private const int mBasicMasterDetails = 0;
		private const int mAssemblyDetails = 1;
		private const int mPricingDetails = 2;
		private const int mOtherMasterDetails = 3;
		private const int mStockLevelDetails = 4;
		private const int mFlexDetails = 5;
		private const int mSupplierDetails = 6;
		private const int mBarcodeDetails = 7;
		private const int mActivityDetails = 8;

		private const int mMaxAssemblyArrayCols = 13;
		private const int mMaxStockLevelArrayCols = 8;
		private const int mMaxPriceDetailArrayCols = 6;
		private const int mMaxSupplierDetailArrayCols = 3;
		private const int mMaxBarcodeDetailArrayCols = 1;
		private const int mMaxActivityDetailArrayCols = 1;

		private const int ctPartNoIndex = 0;
		private const int ctEnglishProductName = 1;
		private const int ctArabicProductNameIndex = 2;
		private const int ctReportUnitIndex = 3;
		private const int ctBaseUnitIndex = 4;
		private const int ctGroupCodeIndex = 5;
		private const int ctCategoryCodeIndex = 6;
		private const int ctPrefferedSupplierCodeIndex = 7;
		private const int ctSupplierPartNoIndex = 8;
		private const int ctPictureFileNameIndex = 9;
		private const int ctPackageIndex = 10;
		private const int ctNewPictureName = 11;
		private const int ctMadeIndex = 12;

		private const int ckSerializedIndex = 0;
		private const int ckDiscontinuedIndex = 1;
		private const int ckPromotionalItemIndex = 2;
		private const int ckPrintVoucherOnComponentsIndex = 3;

		//Private Const ckSupplierIndex As Integer = 0
		private const int ckLdgrIndex = 0;
		private const int ckSupplierNameIndex = 1;
		private const int ckPartNoIndex = 2;
		private const int ckBarcodeIndex = 3;

		private const int ckPriceListIndex = 0;
		private const int ckPNameNameIndex = 1;
		private const int ckUnitIndex = 2;
		private const int ckAmountIndex = 3;
		private const int ckDisAmountIndex = 4;
		private const int ckDisPercentIndex = 5;
		private const int ckCommentsIndex = 6;

		private const int cbUnitIndex = 0;
		private const int cbBarcodeIndex = 1;

		private const int caActivityCode = 0;
		private const int caActivityName = 1;

		private const int cnProductCostIndex = 0;
		private const int cnSalesRateIndex = 1;
		private const int cnPurchaseRateIndex = 2;
		private const int cnSalesRateLevel1Index = 3;
		private const int cnSalesRateLevel2Index = 4;
		private const int cnSalesRateLevel3Index = 5;
		private const int cnSalesRateLevel4Index = 6;
		private const int cnSalesRateLevel5Index = 7;
		private const int cnPurchaseRateLevel1Index = 8;
		private const int cnPurchaseRateLevel2Index = 9;
		private const int cnPurchaseRateLevel3Index = 10;
		private const int cnPurchaseRateLevel4Index = 11;
		private const int cnPurchaseRateLevel5Index = 12;
		private const int cnCommissionOnSalesIndex = 13;
		private const int cnCommissionOnPurchaseIndex = 14;
		private const int cnWarrantyPeriodIndex = 15;
		private const int cnWeightIndex = 16;

		private const int clTotalNoOfTransactionIndex = 4;
		private const int clBaseUnitIndex = 5;
		private const int clGroupNameIndex = 6;
		private const int clCategoryNameIndex = 7;
		private const int clProductTypeIndex = 8;
		private const int clCostingMethodIndex = 9;
		private const int clProductCostIndex = 11;
		private const int clCommisionOnSalesIndex = 24;
		private const int clCommisionOnPurchaseIndex = 25;
		private const int clWarrantyPeriodIndex = 29;
		private const int clPreferredSupplierCodeIndex = 31;
		private const int clSupplierPartNoIndex = 32;
		private const int clPicturesFileFolderIndex = 26;
		private const int clPictureFileNameIndex = 33;
		private const int clReportUnitIndex = 50;

		private const int clSalesRateLevel1Index = 14;
		private const int clSalesRateLevel2Index = 15;
		private const int clSalesRateLevel3Index = 16;
		private const int clSalesRateLevel4Index = 17;
		private const int clSalesRateLevel5Index = 18;
		private const int clPurchaseRateLevel1Index = 19;
		private const int clPurchaseRateLevel2Index = 20;
		private const int clPurchaseRateLevel3Index = 21;
		private const int clPurchaseRateLevel4Index = 22;
		private const int clPurchaseRateLevel5Index = 23;

		private const int ctlBaseUnitNameIndex = 0;
		private const int ctlGroupNameIndex = 1;
		private const int ctlCategoryNameIndex = 2;
		private const int ctlPrefferedSupplierNameIndex = 3;
		private const int ctlPictureFileFolderIndex = 4;
		private const int ctlReportUnitNameIndex = 5;

		private const int ctFlex1Index = 1;
		private const int ctFlex2Index = 2;
		private const int ctFlex3Index = 3;
		private const int ctFlex4Index = 4;
		private const int ctFlex5Index = 5;
		private const int ctFlex6Index = 6;
		private const int ctFlex7Index = 7;
		private const int ctFlex8Index = 8;
		private const int ctFlex9Index = 9;
		private const int ctFlex10Index = 10;
		private const int ctFlex11Index = 11;
		private const int ctFlex12Index = 12;
		private const int ctFlex13Index = 13;
		private const int ctFlex14Index = 14;

		private const int clFlex1Index = 1;
		private const int clFlex2Index = 2;
		private const int clFlex3Index = 3;
		private const int clFlex4Index = 4;
		private const int clFlex5Index = 5;
		private const int clFlex6Index = 6;
		private const int clFlex7Index = 7;
		private const int clFlex8Index = 8;
		private const int clFlex9Index = 9;
		private const int clFlex10Index = 10;
		private const int clFlex11Index = 11;
		private const int clFlex12Index = 12;
		private const int clFlex13Index = 13;
		private const int clFlex14Index = 14;

		private const int ccProductTypesIndex = 0;
		private const int ccCostingMethodIndex = 1;

		private const int cbAlterUnitDetailsIndex = 0;
		private const int cbGroupDetailsIndex = 1;
		private const int cbCategoryDetailsIndex = 2;

		private const int cfDivisionWisePurchaseRatesIndex = 3;
		private const int cfDivisionWiseSalesRatesIndex = 6;
		private const int cfPictureInformationIndex = 5;
		private const int cfSupplierInformationIndex = 8;

		private const int gccLineNoColumn = 0;
		private const int gccProductCodeColumn = 1;
		private const int gccProductNameColumn = 2;
		private const int gccBaseUnitCodeColumn = 3;
		private const int gccCostColumn = 4;
		private const int gccQtyColumn = 5;
		private const int gccMinQtyColumn = 6;
		private const int gccMaxQtyColumn = 7;
		private const int gccSalesRateColumn = 8;
		private const int gccTotalColumn = 9;
		private const int gccSRRatioColumn = 10;
		private const int gccAdjustMaxRateColumn = 11;
		private const int gccAdjustMinRateColumn = 12;
		private const int gccRemarksColumn = 13;

		private const int cslLocationNoColumn = 0;
		private const int cslLocationNameColumn = 1;
		private const int cslMaximumQtyColumn = 2;
		private const int cslMinimumQtyColumn = 3;
		private const int cslReorderQtyColumn = 4;
		private const int cslBinColumn = 5;
		private const int cslIncludeInLocationColumn = 6;
		private const int cslRemarksColumn = 7;
		private const int cslLocationCodeColumn = 8;

		private const int cccProductCodeColumn = 0;
		private const int cccProductNameColumn = 1;
		private const int cccBaseUnitCodeColumn = 2;
		private const int cccCostColumn = 5;

		private const int audUnitEntryIdColumn = 0;
		private const int audLineNoColumn = 1;
		private const int audBaseQtyColumn = 2;
		private const int mBaseSymbol = 3;
		//Private Const audEqualSignColumn As Integer = 4
		private const int audAltQtyColumn = 5;
		private const int audAltSymbolColumn = 6;
		private const int audAltUnitSalesRateColumn = 7;


		private const string mBracketOpener = " (";
		private const string mBracketCloser = ") ";
		private const string mTotalNoOfTransactionText = "Total No of Transactions :";

		private bool mSupplierTabClick = false;
		private bool mFirstSupplierTabClick = false;
		private bool mPriceTabClick = false;
		private bool mFirstPriceTabClick = false;
		private bool mBarcodeTabClick = false;
		private bool mFirstBarcodeTabClick = false;
		private bool mActivityTabClick = false;
		private bool mFirstActivityTabClick = false;

		private int mRecordNavigateSearchValue = 0;

		private int mLastCol = 0;
		private int mLastRow = 0;

		private const string cGridColor = "15439757";

		//**--These property set the Form mode to add mode or edit mode

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


		//CSEH: ErrResumeNext
		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBDropDown Event cmbPriceList.DataSourceChanged was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void cmbPriceList_DataSourceChanged()
		{
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{

				int Cnt = 0;

				cmbPriceList.Width = 0;
				switch(grdPriceDetails.Col)
				{
					case ckPriceListIndex : 
						//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbPriceList.ListField was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064 
						cmbPriceList.setListField("Price_List_No"); 
						cmbPriceList.DisplayColumns[0].Visible = true; 
						//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081 
						cmbPriceList.Width = grdPriceDetails.Splits[0].DisplayColumns[ckPriceListIndex].Width + 167; 
						 
						break;
					case ckPNameNameIndex : 
						//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbPriceList.ListField was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064 
						cmbPriceList.setListField("Price_name"); 
						//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081 
						//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.Column property cmbPriceList.Columns.Order was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064 
						cmbPriceList.Splits[0].DisplayColumns[0].setOrder(1); 
						cmbPriceList.DisplayColumns[1].Width = 200; 
						cmbPriceList.DisplayColumns[0].Width = 47; 
						//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081 
						cmbPriceList.Width = grdPriceDetails.Splits[0].DisplayColumns[ckPNameNameIndex].Width + 100; 
						 
						break;
					case ckUnitIndex : 
						//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbPriceList.ListField was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064 
						cmbPriceList.setListField("Symbol"); 
						//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081 
						//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.Column property cmbPriceList.Columns.Order was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064 
						cmbPriceList.Splits[0].DisplayColumns[0].setOrder(1); 
						//cmbPriceList.Columns(1).Visible = False 
						cmbPriceList.DisplayColumns[0].Width = ckUnitIndex / 15; 
						//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081 
						cmbPriceList.Width = grdPriceDetails.Splits[0].DisplayColumns[ckUnitIndex].Width; 
						break;
				}
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBDropDown Event cmbActivityList.DataSourceChanged was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void cmbActivityList_DataSourceChanged()
		{
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{
				int Cnt = 0;

				cmbActivityList.Width = 0;
				switch(grdActivityDetails.Col)
				{
					case caActivityCode : 
						//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbActivityList.ListField was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064 
						cmbActivityList.setListField("Activity_Type_No"); 
						cmbActivityList.DisplayColumns[0].Visible = true; 
						//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081 
						cmbActivityList.Width = grdActivityDetails.Splits[0].DisplayColumns[caActivityCode].Width + 167; 
						 
						break;
					case caActivityName : 
						//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbActivityList.ListField was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064 
						cmbActivityList.setListField("Type_Name"); 
						//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081 
						//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.Column property cmbActivityList.Columns.Order was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064 
						cmbActivityList.Splits[0].DisplayColumns[0].setOrder(1); 
						cmbActivityList.DisplayColumns[1].Width = 200; 
						cmbActivityList.DisplayColumns[0].Width = 47; 
						//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081 
						cmbActivityList.Width = grdActivityDetails.Splits[0].DisplayColumns[caActivityName].Width + 100; 
						 
						break;
				}
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBDropDown Event cmbPriceList.DropDownClose was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void cmbPriceList_DropDownClose()
		{
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{
				switch(grdPriceDetails.Col)
				{
					case ckPriceListIndex : case ckPNameNameIndex : 
						grdPriceDetails.Col = ckUnitIndex; 
						break;
					case ckUnitIndex : 
						break;
				}
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}


		private void cmdCalender_Click()
		{
			txtExpDate.Drop();
		}

		private void cmdCommon_Click(Object eventSender, EventArgs eventArgs)
		{
			int Index = Array.IndexOf(this.cmdCommon, eventSender);
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{
				if (Index == cbAlterUnitDetailsIndex)
				{
					if (SystemProcedure2.IsItEmpty(txtCommon[ctBaseUnitIndex].Text, SystemVariables.DataType.StringType))
					{
						MessageBox.Show("Please enter a base unit", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
						txtCommon[ctBaseUnitIndex].Focus();
						return;
					}
					oAltUnitForm.mBaseUnitSymbol = txtCommonDisplay[ctlBaseUnitNameIndex].Text;
					if (mCurrentFormMode == SystemVariables.SystemFormModes.frmEditMode)
					{
						//UPGRADE_WARNING: (1068) mSearchValue of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						oAltUnitForm.ProductCode = ReflectionHelper.GetPrimitiveValue<int>(mSearchValue);
					}
					oAltUnitForm.Top = 283;
					oAltUnitForm.Left = 4;
					//oAltUnitForm.Top = (tabProductDetails.Top + tabProductDetails.Height) - (oAltUnitForm.Height) + 1000

					//UPGRADE_WARNING: (7009) Multiple invocations to ShowDialog in Forms with ActiveX Controls might throw runtime exceptions More Information: https://docs.mobilize.net/vbuc/ewis#7009
					oAltUnitForm.ShowDialog();
					mAltUnitFormInitialised = true;
				}
				else if (Index == cbGroupDetailsIndex)
				{ 
					GetNextPartNoInGroup(txtCommon[ctGroupCodeIndex].Text);
				}
				else if (Index == cbCategoryDetailsIndex)
				{ 
					GetNextPartNoInCategory(txtCommon[ctCategoryCodeIndex].Text);
				}
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}



		private void Form_Activated(Object eventSender, EventArgs eventArgs)
		{
			if (ActivateHelper.myActiveForm != eventSender)
			{
				ActivateHelper.myActiveForm = (Form) eventSender;
				//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
				try
				{
					if (ControlHelper.GetEnabled(FirstFocusObject))
					{
						FirstFocusObject.Focus();
					}
					SystemMenu.SetMeCurrentInWindowList(Conversion.Str(this.Handle.ToInt32()));
				}
				catch (Exception exc)
				{
					NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
				}
			}
		}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2080
		private void Form_Load()
		{
			try
			{

				FirstFocusObject = txtCommon[ctPartNoIndex];
				this.CurrentFormMode = SystemVariables.SystemFormModes.frmAddMode;
				this.Top = 0;
				this.Left = 0;
				mAttemptToSetFocus = false;

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
				oThisFormToolBar.ShowMoveRecordNextButton = true;
				oThisFormToolBar.ShowMoveRecordPreviousButton = true;
				oThisFormToolBar.ShowDeleteLineButton = true;

				//.DefineToolBar
				this.WindowState = FormWindowState.Maximized;

				SystemProcedure.SetLabelCaption(this);
				//If gPreferedLanguage = Arabic And rsCompanyProperties("flip_controls_in_arabic").Value = vbTrue Then
				//    Dim oFlipThisForm As New clsFlip
				//
				//    oFlipThisForm.SwapMe Me
				//End If

				//**--make the form visible before all the control gets loaded
				//**--(this way system pretends to be faster in loading forms)
				this.Show();
				Application.DoEvents();

				ShowHideMasterDetails();
				Application.DoEvents();
				//**-------------------------------------------------------------------------------------------

				//**--check if the part no is alpha-numeric or not
				//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				if (((TriState) ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetSystemPreferenceSetting("allow_alpha_numeric_part_no"))) == TriState.True)
				{
					txtCommon[ctPartNoIndex].NumericOnly = false;
					txtCommon[ctPartNoIndex].AllowDecimal = true;
				}
				else
				{
					txtCommon[ctPartNoIndex].NumericOnly = true;
					txtCommon[ctPartNoIndex].AllowDecimal = false;
				}

				//--get the next new ledger no
				GetNextNumber();


				tabMaster.CurrTab = Convert.ToInt16(mBasicMasterDetails);
				mFormIsInitialized = true;
				mAttemptToSetFocus = true;

				mFirstPriceTabClick = true;
				mFirstSupplierTabClick = true;
				mFirstBarcodeTabClick = true;
				mFirstActivityTabClick = true;

				//If GetSystemPreferenceSetting("product_picture") = True Then
				// '**--set default picture file folder name
				//    txtCommonDisplay(ctlPictureFileFolderIndex).Text = gProductPicturesPath
				//    On Error Resume Next
				//    flbPictureFileNames.Path = gProductPicturesPath
				//    On Error GoTo 0
				//End If

				//UPGRADE_ISSUE: (2070) Constant vbCustom was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2070
				imgPicture.Cursor = UpgradeStubs.System_Windows_Forms_Cursor.getvbCustom();
				imgPicture.Cursor = new Cursor((new Bitmap(frmSysIconsForm.DefInstance.imlSystemIcons.Images["imgHand"])).GetHicon());
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
				//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
				try
				{

					if (Shift == 2 && (KeyCode == 67 || KeyCode == 86 || KeyCode == 88))
					{
						return;
					}


					if (this.ActiveControl.Name.ToLower() == ("grdAssemblyDetails").ToLower() || this.ActiveControl.Name.ToLower() == ("grdSupplierDetails").ToLower() || this.ActiveControl.Name.ToLower() == ("grdPriceDetails").ToLower())
					{
						//    If KeyCode = 13 Or KeyCode = 115 Then
						//        Exit Sub
						//    ElseIf KeyCode = 222 Then
						//        KeyCode = 0
						//        Exit Sub
						//    End If


						if (Shift == 0)
						{
							if (grdAssemblyDetails.Col == gccQtyColumn || grdAssemblyDetails.Col == gccMinQtyColumn || grdAssemblyDetails.Col == gccMaxQtyColumn || grdAssemblyDetails.Col == gccSRRatioColumn || grdAssemblyDetails.Col == gccSalesRateColumn || grdPriceDetails.Col == ckAmountIndex || grdPriceDetails.Col == ckDisAmountIndex || grdPriceDetails.Col == ckDisPercentIndex)
							{
								if ((KeyCode == 8) || (KeyCode == 46) || (KeyCode == 27))
								{
									//
								}
								else if ((KeyCode >= 48 && KeyCode <= 57) || (KeyCode >= 96 && KeyCode <= 105) || (KeyCode == 190) || (KeyCode == 110))
								{ 
									//
								}
								else
								{
									KeyCode = 0;
								}
							}
						}
					}


					//''(Alt + -> ) or ( Alt + <- )
					if (Shift == 4 && (KeyCode == 37 || KeyCode == 39))
					{
						if (!UserAccess.AllowUserDisplay)
						{
							MessageBox.Show(SystemConstants.msg8, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
							return;
						}

						RecordNavidate(KeyCode, mRecordNavigateSearchValue);
						KeyCode = 0;
					}


					//on keydown navigate the form by using enter key
					if (KeyCode == ((int) Keys.Return) && this.ActiveControl.Name != "txtProdDesc" && this.ActiveControl.Name != "txtComment")
					{ //If enter key pressed send a tab key
						SendKeys.Send("{TAB}");
						return;
					}


					if (this.ActiveControl.Name != "txtCommon" && this.ActiveControl.Name != "txtFlex")
					{
						SystemForms.SystemFormKeyDown(this, ref KeyCode, Shift, this.ActiveControl.Name);
					}
					else if (this.ActiveControl.Name == "txtFlex")
					{ 
						SystemForms.SystemFormKeyDown(this, ref KeyCode, Shift, "txtFlex#" + ControlArrayHelper.GetControlIndex(this.ActiveControl).ToString().Trim());
					}
					else if (this.ActiveControl.Name == "txtCommon")
					{ 
						SystemForms.SystemFormKeyDown(this, ref KeyCode, Shift, "txtCommon#" + ControlArrayHelper.GetControlIndex(this.ActiveControl).ToString().Trim());
					}
				}
				catch (Exception exc)
				{
					NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
				}
			}
			finally
			{
				eventArgs.Handled = KeyCode == 0;
			}
		}



		private void Form_Closed(Object eventSender, EventArgs eventArgs)
		{
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{

				SystemMenu.RemoveMeFromWindowList(Conversion.Str(this.Handle.ToInt32()));

				oAltUnitForm.Close();
				oAltUnitForm = null;
				UserAccess = null;
				rsProductCodeList = null;
				aProductAssemblyDetails = null;
				aProductStockLevels = null;
				rsItemType = null;

				oThisFormToolBar = null;
				frmICSItems.DefInstance = null;
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		private void cmbCommon_Click(Object Sender, EventArgs e)
		{
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{
				if (mFormIsInitialized)
				{
					ShowHideMasterDetails();
				}
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		public void AddRecord()
		{
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{
				int Cnt = 0;

				try
				{

					mCurrentFormMode = SystemVariables.SystemFormModes.frmAddMode; //Change the form mode to addmode
					mSearchValue = ""; //Change the msearchvalue to blank
					mAltUnitFormInitialised = false;
					oAltUnitForm = null;

					//For cnt = txtCommon.LBound To txtCommon.UBound
					//    txtCommon(cnt).Tag = ""
					//Next

					Control txtTextCtr = null;
					//UPGRADE_WARNING: (2065) Form property frmICSItems.Controls has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2065
					foreach (Control txtTextCtrIterator in ContainerHelper.Controls(this))
					{
						txtTextCtr = txtTextCtrIterator;
						if ((txtTextCtr is System.Windows.Forms.TextBox) || (txtTextCtr is TextBox) || (txtTextCtr is System.Windows.Forms.Label))
						{
							ControlHelper.SetTag(txtTextCtr, "");
						}
						txtTextCtr = default(Control);
					}

					SystemProcedure2.ClearTextBox(this);
					SystemProcedure2.ClearNumberBox(this);
					SystemProcedure2.ClearCheckBox(this);
					ResetAllObjects();

					GetNextNumber();
					ShowHideMasterDetails();

					mSupplierTabClick = false;
					mPriceTabClick = false;
					txtCommon[ctPartNoIndex].Enabled = true;

					tabMaster.CurrTab = Convert.ToInt16(mBasicMasterDetails);
					FirstFocusObject.Focus();
					return;
				}
				catch (System.Exception excep)
				{

					//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
					SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, excep.Message, this.Name, "AddRecord");
				}
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		public bool saveRecord()
		{
			bool result = false;
			string mysql = "";
			clsHourGlass myHourGlass = null;
			int Cnt = 0;
			object mTempValue = null;
			bool mShowErrorMessage = false;
			int mComponentProductCode = 0;
			double mComponentQty = 0;
			double mComponentMinQty = 0;
			double mComponentMaxQty = 0;
			double mComponentSRRatio = 0;

			int mLdgr_Code = 0;
			string mSupplier_Part_No = "";
			string mBarcode = "";

			int mPrice_List_Code = 0;
			int mPrice_Unit_Cd = 0;
			double mPrice_Amt = 0;
			double mPrice_Discount_Amt = 0;
			double mPrice_Discount_Percent = 0;
			int mActivity_Code = 0;

			int mBarcode_Unit_Cd = 0;

			decimal mComponentSalesPrice = 0;
			int mComponentAdjustMaxRate = 0;
			int mComponentAdjustMinRate = 0;

			int mAltUnitCode = 0;
			object mReturnValue = null;

			try
			{

				myHourGlass = new clsHourGlass();
				mShowErrorMessage = true;

				//UPGRADE_ISSUE: (2064) ADODB.Recordset method rsItemType.MoveFirst was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				rsItemType.MoveFirst();
				rsItemType.Find("item_type_cd=" + cmbCommon[ccProductTypesIndex].GetItemData(cmbCommon[ccProductTypesIndex].ListIndex).ToString());
				if (rsItemType.Tables[0].Rows.Count == 0)
				{
					MessageBox.Show("invalid Product Type selected ", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					return false;
				}

				SystemVariables.gConn.BeginTransaction();


				if (mCurrentFormMode == SystemVariables.SystemFormModes.frmAddMode)
				{
					mysql = " insert into ICS_Item";
					mysql = mysql + " (group_cd, cat_cd, base_unit_cd, Report_Unit_Cd, item_type_cd, costing_method, ";
					mysql = mysql + " part_no, l_prod_name, a_prod_name, prod_desc, ";
					mysql = mysql + " supplier_ldgr_cd, supplier_part_no, picture, ";
					mysql = mysql + " purchase_rate, purchase_rate_1, purchase_rate_2, ";
					mysql = mysql + " purchase_rate_3, purchase_rate_4, purchase_rate_5, sales_rate, ";
					mysql = mysql + " sale_rate1, sale_rate2, sale_rate3, sale_rate4, sale_rate5, ";
					mysql = mysql + " serialized, discontinued, promotional_item, print_components_on_voucher, ";
					mysql = mysql + " commision_in_percent_on_sales, commision_in_percent_on_purchase ";
					mysql = mysql + " , warranty_period_in_days ";
					mysql = mysql + " ,  weight "; //bin_location,
					mysql = mysql + " , cost ";
					mysql = mysql + " , comments, user_cd ";

					//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
					if (((TriState) ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetSystemPreferenceSetting("show_flex_details_tab_in_product"))) == TriState.True)
					{
						mysql = mysql + " , flex1_vssv_code, flex2_vssv_code, flex3_vssv_code, flex4_vssv_code, flex5_vssv_code, flex6_vssv_code ";
						mysql = mysql + " , flex7_vssv_code, flex8_vssv_code , flex9_vssv_code, flex10_vssv_code, flex11_vssv_code, flex12_vssv_code ";
						mysql = mysql + " , flex13_vssv_code, flex14_vssv_code ";
					}

					//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
					if (((TriState) ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetSystemPreferenceSetting("show_package_date_on_item_master"))) == TriState.True)
					{
						mysql = mysql + " , package, ExpDate, PackDate, MadeIn ";
					}


					mysql = mysql + " ) values (";
					mysql = mysql + mNewGroupCode + ",";
					mysql = mysql + mNewCategoryCode + ",";
					mysql = mysql + mNewBaseUnitCode + ",";
					mysql = mysql + mNewReportUnitCode + ",";
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					mysql = mysql + Conversion.Str(rsItemType.Tables[0].Rows[0]["item_type_cd"]) + ",";
					mysql = mysql + Conversion.Str(cmbCommon[ccCostingMethodIndex].GetItemData(cmbCommon[ccCostingMethodIndex].ListIndex)) + ",";
					mysql = mysql + "'" + txtCommon[ctPartNoIndex].Text + "',";
					mysql = mysql + "N'" + txtCommon[ctEnglishProductName].Text + "',";
					mysql = mysql + "N'" + txtCommon[ctArabicProductNameIndex].Text + "',";
					mysql = mysql + "N'" + txtProdDesc.Text + "',";
					mysql = mysql + mNewPrefferedSupplierCode + ",";
					mysql = mysql + "'" + txtCommon[ctSupplierPartNoIndex].Text + "',";
					if (!SystemProcedure2.IsItEmpty(txtCommon[ctPictureFileNameIndex].Text, SystemVariables.DataType.StringType))
					{
						mysql = mysql + "'" + txtCommon[ctPictureFileNameIndex].Text + "',";
					}
					else
					{
						mysql = mysql + "null,";
					}
					mysql = mysql + Conversion.Str(txtCommonNumber[cnPurchaseRateIndex].Value) + ",";
					mysql = mysql + Conversion.Str(txtCommonNumber[cnPurchaseRateLevel1Index].Value) + ",";
					mysql = mysql + Conversion.Str(txtCommonNumber[cnPurchaseRateLevel2Index].Value) + ",";
					mysql = mysql + Conversion.Str(txtCommonNumber[cnPurchaseRateLevel3Index].Value) + ",";
					mysql = mysql + Conversion.Str(txtCommonNumber[cnPurchaseRateLevel4Index].Value) + ",";
					mysql = mysql + Conversion.Str(txtCommonNumber[cnPurchaseRateLevel5Index].Value) + ",";
					mysql = mysql + Conversion.Str(txtCommonNumber[cnSalesRateIndex].Value) + ",";
					mysql = mysql + Conversion.Str(txtCommonNumber[cnSalesRateLevel1Index].Value) + ",";
					mysql = mysql + Conversion.Str(txtCommonNumber[cnSalesRateLevel2Index].Value) + ",";
					mysql = mysql + Conversion.Str(txtCommonNumber[cnSalesRateLevel3Index].Value) + ",";
					mysql = mysql + Conversion.Str(txtCommonNumber[cnSalesRateLevel4Index].Value) + ",";
					mysql = mysql + Conversion.Str(txtCommonNumber[cnSalesRateLevel5Index].Value) + ",";
					if (chkCommon[ckSerializedIndex].Visible)
					{
						mysql = mysql + ((((int) chkCommon[ckSerializedIndex].CheckState) != ((int) CheckState.Unchecked)) ? "1," : "0,");
					}
					else
					{
						mysql = mysql + "0,";
					}
					if (chkCommon[ckDiscontinuedIndex].Visible)
					{
						mysql = mysql + ((((int) chkCommon[ckDiscontinuedIndex].CheckState) != ((int) CheckState.Unchecked)) ? "1," : "0,");
					}
					else
					{
						mysql = mysql + "0,";
					}
					if (chkCommon[ckPromotionalItemIndex].Visible)
					{
						mysql = mysql + ((((int) chkCommon[ckPromotionalItemIndex].CheckState) != ((int) CheckState.Unchecked)) ? "1," : "0,");
					}
					else
					{
						mysql = mysql + "0,";
					}
					if (chkCommon[ckPrintVoucherOnComponentsIndex].Visible)
					{
						mysql = mysql + ((((int) chkCommon[ckPrintVoucherOnComponentsIndex].CheckState) != ((int) CheckState.Unchecked)) ? "1," : "0,");
					}
					else
					{
						mysql = mysql + "0,";
					}
					mysql = mysql + Conversion.Str(txtCommonNumber[cnCommissionOnSalesIndex].Value) + ",";
					mysql = mysql + Conversion.Str(txtCommonNumber[cnCommissionOnPurchaseIndex].Value) + ",";
					mysql = mysql + Conversion.Str(txtCommonNumber[cnWarrantyPeriodIndex].Value) + ",";
					//mysql = mysql & " N'" & txtCommon(ctBinLocationIndex).Text & "',"
					mysql = mysql + Conversion.Str(txtCommonNumber[cnWeightIndex].Value) + ",";
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					if (Convert.ToBoolean(rsItemType.Tables[0].Rows[0]["allow_define_manual_cost"]))
					{
						mysql = mysql + Conversion.Str(txtCommonNumber[cnProductCostIndex].Value) + ",";
					}
					else
					{
						mysql = mysql + " 0 , ";
					}

					mysql = mysql + "N'" + txtComment.Text + "',";
					mysql = mysql + Conversion.Str(SystemVariables.gLoggedInUserCode);

					//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
					if (((TriState) ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetSystemPreferenceSetting("show_flex_details_tab_in_product"))) == TriState.True)
					{
						mysql = mysql + ", '" + txtFlex[ctFlex1Index].Text + "'";
						mysql = mysql + ", '" + txtFlex[ctFlex2Index].Text + "'";
						mysql = mysql + ", '" + txtFlex[ctFlex3Index].Text + "'";
						mysql = mysql + ", '" + txtFlex[ctFlex4Index].Text + "'";
						mysql = mysql + ", '" + txtFlex[ctFlex5Index].Text + "'";
						mysql = mysql + ", '" + txtFlex[ctFlex6Index].Text + "'";
						mysql = mysql + ", '" + txtFlex[ctFlex7Index].Text + "'";
						mysql = mysql + ", '" + txtFlex[ctFlex8Index].Text + "'";
						mysql = mysql + ", '" + txtFlex[ctFlex9Index].Text + "'";
						mysql = mysql + ", '" + txtFlex[ctFlex10Index].Text + "'";
						mysql = mysql + ", '" + txtFlex[ctFlex11Index].Text + "'";
						mysql = mysql + ", '" + txtFlex[ctFlex12Index].Text + "'";
						mysql = mysql + ", '" + txtFlex[ctFlex13Index].Text + "'";
						mysql = mysql + ", '" + txtFlex[ctFlex14Index].Text + "'";
					}

					//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
					if (((TriState) ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetSystemPreferenceSetting("show_package_date_on_item_master"))) == TriState.True)
					{
						mysql = mysql + ", N'" + txtCommon[ctPackageIndex].Text + "'";
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
						mysql = mysql + ", " + ((Convert.IsDBNull(txtExpDate.Value)) ? "Null" : "'" + StringsHelper.Format(txtExpDate.Value, SystemVariables.gSystemDateFormat) + "'");
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
						mysql = mysql + ", " + ((Convert.IsDBNull(txtPackDate.Value)) ? "Null" : "'" + StringsHelper.Format(txtPackDate.Value, SystemVariables.gSystemDateFormat) + "'");
						mysql = mysql + ", N'" + txtCommon[ctMadeIndex].Text + "'";
					}


					mysql = mysql + " )";
					SqlCommand TempCommand = null;
					TempCommand = SystemVariables.gConn.CreateCommand();
					TempCommand.CommandText = mysql;
					TempCommand.ExecuteNonQuery();

					mSearchValue = ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetMasterCode("select scope_identity()"));
				}
				else
				{
					//in case of update get the time stamp and Base Unit code and protected value
					mysql = " select time_stamp, base_unit_cd, protected from ICS_Item where prod_cd = " + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (!Convert.IsDBNull(mTempValue))
					{
						//if the time stamp does not match the previous one then rollback
						if (SystemProcedure2.tsFormat(ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(0))) != SystemProcedure2.tsFormat(mTimeStamp))
						{
							MessageBox.Show(SystemConstants.msg10, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
							throw new Exception();
						}
						//if the record is protected then rollback
						if (ReflectionHelper.GetPrimitiveValue<bool>(((Array) mTempValue).GetValue(2)))
						{
							MessageBox.Show(SystemConstants.msg12, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
							throw new Exception();
						}

						//if Base Unit is not same as before then delete all the records from ICS_Item_Unit_Details
						if (ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(1)) != mNewBaseUnitCode)
						{
							mysql = " delete from ICS_Item_Unit_Details ";
							mysql = mysql + " where prod_cd =" + Conversion.Str(mSearchValue);

							//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
							try
							{
								SqlCommand TempCommand_2 = null;
								TempCommand_2 = SystemVariables.gConn.CreateCommand();
								TempCommand_2.CommandText = mysql;
								TempCommand_2.ExecuteNonQuery();
								//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
								if (Information.Err().Number == 0)
								{
									//'''insert the Base Unit cd record in ICS_Item_Unit_Details
									mysql = " insert into ICS_Item_Unit_Details (line_no, prod_cd, alt_unit_cd ";
									mysql = mysql + " , base_unit_cd, base_qty, alt_qty, user_cd) ";
									mysql = mysql + " values( 1 ";
									mysql = mysql + " , " + Conversion.Str(mSearchValue);
									mysql = mysql + " , " + Conversion.Str(mNewBaseUnitCode);
									mysql = mysql + " , " + Conversion.Str(mNewBaseUnitCode);
									mysql = mysql + " , 1, 1 ";
									mysql = mysql + " , " + SystemVariables.gLoggedInUserCode.ToString();
									mysql = mysql + " ) ";
									SqlCommand TempCommand_3 = null;
									TempCommand_3 = SystemVariables.gConn.CreateCommand();
									TempCommand_3.CommandText = mysql;
									TempCommand_3.ExecuteNonQuery();


									//                'this part should be done only if the user is admin
									//
									//                'check if the new Base Unit already is define as alt unit
									//                mysql = "select alt_unit_cd from ICS_Item_Unit_Details "
									//                mysql = mysql & " where alt_unit_cd=" & Str(mNewBaseUnitCode)
									//                mysql = mysql & " and prod_cd =" & Str(mSearchValue)
									//                mTempValue = GetMasterCode(mysql)
									//                If Not IsNull(mTempValue) Then
									//                    MsgBox "alternate ICS_Unit and Base Unit cannot be same"
									//                    GoTo eFoundError
									//                End If
									//
									//                mysql = "update ICS_Item_Unit_Details "
									//                mysql = mysql & " set base_unit_cd=" & Str(mNewBaseUnitCode)
									//                mysql = mysql & " , alt_unit_cd=" & Str(mNewBaseUnitCode)
									//                mysql = mysql & " , alt_qty = 1 "
									//                mysql = mysql & " , base_qty = 1 "
									//                mysql = mysql & " where prod_cd =" & Str(mSearchValue)
									//                mysql = mysql & " and line_no=1"
									//                gConn.Execute mysql
									//
									//                mysql = "update ICS_Item_Unit_Details "
									//                mysql = mysql & " set base_unit_cd=" & Str(mNewBaseUnitCode)
									//                mysql = mysql & " where prod_cd =" & Str(mSearchValue)
									//                gConn.Execute mysql
								}
								else
								{
									MessageBox.Show("Base Unit cannot be changed, Transaction Exists.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
									txtCommon[ctBaseUnitIndex].Focus();
									throw new Exception();
								}
							}
							catch (Exception exc)
							{
								NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
							}
						}
					}


					//update the record if everything is fine
					mysql = " update ICS_Item set ";
					mysql = mysql + " group_cd = " + mNewGroupCode + ",";
					mysql = mysql + " cat_cd = " + mNewCategoryCode + ",";
					mysql = mysql + " base_unit_cd = " + mNewBaseUnitCode + ",";
					mysql = mysql + " Report_Unit_Cd = " + mNewReportUnitCode + ",";
					mysql = mysql + " part_no = '" + txtCommon[ctPartNoIndex].Text + "',";
					mysql = mysql + " l_prod_name = N'" + txtCommon[ctEnglishProductName].Text + "',";
					mysql = mysql + " a_prod_name = N'" + txtCommon[ctArabicProductNameIndex].Text + "',";
					mysql = mysql + " prod_desc = N'" + txtProdDesc.Text + "',";
					mysql = mysql + " supplier_ldgr_cd = " + mNewPrefferedSupplierCode + ",";
					mysql = mysql + " supplier_part_no = '" + txtCommon[ctSupplierPartNoIndex].Text + "',";
					if (!SystemProcedure2.IsItEmpty(txtCommon[ctPictureFileNameIndex].Text, SystemVariables.DataType.StringType))
					{
						mysql = mysql + " picture = '" + txtCommon[ctPictureFileNameIndex].Text + "',";
					}
					else
					{
						mysql = mysql + " picture = null,";
					}

					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					if (Convert.ToBoolean(rsItemType.Tables[0].Rows[0]["allow_define_manual_cost"]))
					{
						mysql = mysql + " cost = " + Conversion.Str(txtCommonNumber[cnProductCostIndex].Value) + ",";
					}

					mysql = mysql + " purchase_rate = " + Conversion.Str(txtCommonNumber[cnPurchaseRateIndex].Value) + ",";
					mysql = mysql + " purchase_rate_1 = " + Conversion.Str(txtCommonNumber[cnPurchaseRateLevel1Index].Value) + ",";
					mysql = mysql + " purchase_rate_2 = " + Conversion.Str(txtCommonNumber[cnPurchaseRateLevel2Index].Value) + ",";
					mysql = mysql + " purchase_rate_3 = " + Conversion.Str(txtCommonNumber[cnPurchaseRateLevel3Index].Value) + ",";
					mysql = mysql + " purchase_rate_4 = " + Conversion.Str(txtCommonNumber[cnPurchaseRateLevel4Index].Value) + ",";
					mysql = mysql + " purchase_rate_5 = " + Conversion.Str(txtCommonNumber[cnPurchaseRateLevel5Index].Value) + ",";
					mysql = mysql + " sales_rate = " + Conversion.Str(txtCommonNumber[cnSalesRateIndex].Value) + ",";
					mysql = mysql + " sale_rate1 = " + Conversion.Str(txtCommonNumber[cnSalesRateLevel1Index].Value) + ",";
					mysql = mysql + " sale_rate2 = " + Conversion.Str(txtCommonNumber[cnSalesRateLevel2Index].Value) + ",";
					mysql = mysql + " sale_rate3 = " + Conversion.Str(txtCommonNumber[cnSalesRateLevel3Index].Value) + ",";
					mysql = mysql + " sale_rate4 = " + Conversion.Str(txtCommonNumber[cnSalesRateLevel4Index].Value) + ",";
					mysql = mysql + " sale_rate5 = " + Conversion.Str(txtCommonNumber[cnSalesRateLevel5Index].Value) + ",";
					if (chkCommon[ckSerializedIndex].Visible)
					{
						mysql = mysql + " serialized = " + ((((int) chkCommon[ckSerializedIndex].CheckState) != ((int) CheckState.Unchecked)) ? "1," : "0,");
					}
					else
					{
						mysql = mysql + " serialized = 0,";
					}
					if (chkCommon[ckDiscontinuedIndex].Visible)
					{
						mysql = mysql + " discontinued = " + ((((int) chkCommon[ckDiscontinuedIndex].CheckState) != ((int) CheckState.Unchecked)) ? "1," : "0,");
					}
					else
					{
						mysql = mysql + " discontinued = 0,";
					}
					if (chkCommon[ckPromotionalItemIndex].Visible)
					{
						mysql = mysql + " promotional_item = " + ((((int) chkCommon[ckPromotionalItemIndex].CheckState) != ((int) CheckState.Unchecked)) ? "1," : "0,");
					}
					else
					{
						mysql = mysql + " promotional_item = 0,";
					}
					if (chkCommon[ckPrintVoucherOnComponentsIndex].Visible)
					{
						mysql = mysql + " print_components_on_voucher = " + ((((int) chkCommon[ckPrintVoucherOnComponentsIndex].CheckState) != ((int) CheckState.Unchecked)) ? "1," : "0,");
					}
					else
					{
						mysql = mysql + " print_components_on_voucher = 0,";
					}
					mysql = mysql + " commision_in_percent_on_sales = " + Conversion.Str(txtCommonNumber[cnCommissionOnSalesIndex].Value) + ",";
					mysql = mysql + " commision_in_percent_on_purchase = " + Conversion.Str(txtCommonNumber[cnCommissionOnPurchaseIndex].Value) + ",";
					mysql = mysql + " warranty_period_in_days = " + Conversion.Str(txtCommonNumber[cnWarrantyPeriodIndex].Value) + ",";
					//mysql = mysql & " bin_location = " & " N'" & txtCommon(ctBinLocationIndex).Text & "',"
					mysql = mysql + " weight = " + Conversion.Str(txtCommonNumber[cnWeightIndex].Value) + ",";
					mysql = mysql + " comments = N'" + txtComment.Text + "'";
					mysql = mysql + " , updated_by_user_cd = " + Conversion.Str(SystemVariables.gLoggedInUserCode);
					mysql = mysql + " , updated_date_time = getdate() ";

					//''Based on this setting the ICS_Item informations like rate etc. and uploaded
					//''and updated in the POS.
					if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("offline_data_management")) && SystemVariables.gIsHeadOffice)
					{
						mysql = mysql + " , Offline_Data_Updated_Locat_Cd = '' ";
					}



					//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
					if (((TriState) ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetSystemPreferenceSetting("show_flex_details_tab_in_product"))) == TriState.True)
					{
						mysql = mysql + " , flex1_vssv_code = '" + txtFlex[ctFlex1Index].Text + "'";
						mysql = mysql + " , flex2_vssv_code = '" + txtFlex[ctFlex2Index].Text + "'";
						mysql = mysql + " , flex3_vssv_code = '" + txtFlex[ctFlex3Index].Text + "'";
						mysql = mysql + " , flex4_vssv_code = '" + txtFlex[ctFlex4Index].Text + "'";
						mysql = mysql + " , flex5_vssv_code = '" + txtFlex[ctFlex5Index].Text + "'";
						mysql = mysql + " , flex6_vssv_code = '" + txtFlex[ctFlex6Index].Text + "'";
						mysql = mysql + " , flex7_vssv_code = '" + txtFlex[ctFlex7Index].Text + "'";
						mysql = mysql + " , flex8_vssv_code = '" + txtFlex[ctFlex8Index].Text + "'";
						mysql = mysql + " , flex9_vssv_code = '" + txtFlex[ctFlex9Index].Text + "'";
						mysql = mysql + " , flex10_vssv_code = '" + txtFlex[ctFlex10Index].Text + "'";
						mysql = mysql + " , flex11_vssv_code = '" + txtFlex[ctFlex11Index].Text + "'";
						mysql = mysql + " , flex12_vssv_code = '" + txtFlex[ctFlex12Index].Text + "'";
						mysql = mysql + " , flex13_vssv_code = '" + txtFlex[ctFlex13Index].Text + "'";
						mysql = mysql + " , flex14_vssv_code = '" + txtFlex[ctFlex14Index].Text + "'";
					}

					//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
					if (((TriState) ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetSystemPreferenceSetting("show_package_date_on_item_master"))) == TriState.True)
					{
						mysql = mysql + " , package = N'" + txtCommon[ctPackageIndex].Text + "'";
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
						mysql = mysql + " , ExpDate = " + ((Convert.IsDBNull(txtExpDate.Value)) ? "Null" : "'" + StringsHelper.Format(txtExpDate.Value, SystemVariables.gSystemDateFormat) + "'");
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
						mysql = mysql + " , PackDate = " + ((Convert.IsDBNull(txtPackDate.Value)) ? "Null" : "'" + StringsHelper.Format(txtPackDate.Value, SystemVariables.gSystemDateFormat) + "'");
						mysql = mysql + " , MadeIn = N'" + txtCommon[ctMadeIndex].Text + "'";
					}

					mysql = mysql + " where prod_cd = " + Conversion.Str(mSearchValue);

					SqlCommand TempCommand_4 = null;
					TempCommand_4 = SystemVariables.gConn.CreateCommand();
					TempCommand_4.CommandText = mysql;
					TempCommand_4.ExecuteNonQuery();

				}

				if (ReflectionHelper.GetPrimitiveValue<double>(SystemProcedure2.GetSystemPreferenceSetting("picture_save_method")) == 1 && txtCommon[ctNewPictureName].Text != "")
				{
					SavePicture(ReflectionHelper.GetPrimitiveValue<int>(mSearchValue));
				}
				else if (ReflectionHelper.GetPrimitiveValue<double>(SystemProcedure2.GetSystemPreferenceSetting("picture_save_method")) == 2)
				{ 
					SavePictureObject(ReflectionHelper.GetPrimitiveValue<int>(mSearchValue));
				}

				//**--if the alternate ICS_Unit details form is initialised
				if (mAltUnitFormInitialised)
				{

					//'''Donot allow to update alt_unit_detail if record exists
					//'''in the ST_OFFLINE_DETAILS
					mysql = " select comp_id from ST_OFFLINE_DETAILS ";
					mysql = mysql + " where table_name = 'product' ";
					mysql = mysql + " and (upload_entry_id ='" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue) + "'";
					mysql = mysql + " or download_generated_entry_id ='" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue) + "')";
					mysql = mysql + " and comp_id=" + SystemVariables.gCompanyID.ToString();
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (!Convert.IsDBNull(mReturnValue))
					{
						MessageBox.Show("Alt ICS_Unit details will not be update for POS", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
						goto eSkipAltUnitDetailsUpdateInPOS;
					}

					int tempForEndVar = oAltUnitForm.aAdditionalVoucherDetails.GetLength(0) - 1;
					for (Cnt = 0; Cnt <= tempForEndVar; Cnt++)
					{
						//Check if Unit_entry_id field is valid
						if (!SystemProcedure2.IsItEmpty(oAltUnitForm.aAdditionalVoucherDetails.GetValue(Cnt, audUnitEntryIdColumn), SystemVariables.DataType.NumberType))
						{
							//'''check if the unit_entry_id in the alt ICS_Unit form exists.
							//'''it might be deleted if the user changes the Base Unit when no transaction exists
							mysql = " select unit_entry_id from ICS_Item_Unit_Details ";
							mysql = mysql + " where unit_entry_id = " + Convert.ToString(oAltUnitForm.aAdditionalVoucherDetails.GetValue(Cnt, audUnitEntryIdColumn));
							//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
							if (!Convert.IsDBNull(mReturnValue))
							{
								if (SystemProcedure2.IsItEmpty(oAltUnitForm.aAdditionalVoucherDetails.GetValue(Cnt, audAltQtyColumn), SystemVariables.DataType.NumberType) || SystemProcedure2.IsItEmpty(oAltUnitForm.aAdditionalVoucherDetails.GetValue(Cnt, audAltSymbolColumn), SystemVariables.DataType.StringType))
								{

									mysql = " delete from ICS_Item_Unit_Details where unit_entry_id =" + Convert.ToString(oAltUnitForm.aAdditionalVoucherDetails.GetValue(Cnt, audUnitEntryIdColumn));
									//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
									try
									{
										SqlCommand TempCommand_5 = null;
										TempCommand_5 = SystemVariables.gConn.CreateCommand();
										TempCommand_5.CommandText = mysql;
										TempCommand_5.ExecuteNonQuery();
										//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
										if (Information.Err().Number != 0)
										{
											MessageBox.Show("Alternate ICS_Unit for Line No:" + Convert.ToString(oAltUnitForm.aAdditionalVoucherDetails.GetValue(Cnt, audLineNoColumn)) + "-- cannot be deleted, transaction already occurs", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
											throw new Exception();
										}

										//'''Donot allow to delete or modify the record if the information exists
										//'''in the ST_OFFLINE_DETAILS
										mysql = " select comp_id from ST_OFFLINE_DETAILS ";
										mysql = mysql + " where table_name = 'ICS_Item_Unit_Details' ";
										mysql = mysql + " and (upload_entry_id ='" + Conversion.Str(oAltUnitForm.aAdditionalVoucherDetails.GetValue(Cnt, audUnitEntryIdColumn)).Trim() + "'";
										mysql = mysql + " or download_generated_entry_id ='" + Conversion.Str(oAltUnitForm.aAdditionalVoucherDetails.GetValue(Cnt, audUnitEntryIdColumn)).Trim() + "')";
										//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
										mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
										//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
										if (!Convert.IsDBNull(mReturnValue))
										{
											MessageBox.Show(SystemConstants.msg29, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
											throw new Exception();
										}
									}
									catch (Exception exc2)
									{
										NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
									}
								}
								else
								{
									mysql = "select unit_cd from ICS_Unit where symbol='" + Convert.ToString(oAltUnitForm.aAdditionalVoucherDetails.GetValue(Cnt, audAltSymbolColumn)).Trim() + "'";
									//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
									mAltUnitCode = ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetMasterCode(mysql));
									//if the Base Unit and alt ICS_Unit are same then display error
									if (StringsHelper.ToDoubleSafe(mNewBaseUnitCode) == mAltUnitCode)
									{
										MessageBox.Show("Alternate ICS_Unit and Base Unit cannot be same", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
										throw new Exception();
									}

									//Check if the existing Alt ICS_Unit already exists
									mysql = "select prod_cd from ICS_Item_Unit_Details where alt_unit_cd=" + Conversion.Str(mAltUnitCode);
									mysql = mysql + " and prod_cd = " + Conversion.Str(mSearchValue);
									mysql = mysql + " and unit_entry_id<> " + Convert.ToString(oAltUnitForm.aAdditionalVoucherDetails.GetValue(Cnt, audUnitEntryIdColumn));
									//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
									if (Convert.IsDBNull(SystemProcedure2.GetMasterCode(mysql)))
									{
										mysql = " update ICS_Item_Unit_Details ";
										mysql = mysql + " set ";
										//mysql = mysql & "  alt_unit_cd = " & mAltUnitCode"
										//mysql = mysql & " , base_unit_cd =" & mNewBaseUnitCode
										mysql = mysql + " base_qty =" + Convert.ToString(oAltUnitForm.aAdditionalVoucherDetails.GetValue(Cnt, audBaseQtyColumn));
										mysql = mysql + " , alt_qty =" + Convert.ToString(oAltUnitForm.aAdditionalVoucherDetails.GetValue(Cnt, audAltQtyColumn));
										mysql = mysql + " , sales_rate =" + Conversion.Val(Convert.ToString(oAltUnitForm.aAdditionalVoucherDetails.GetValue(Cnt, audAltUnitSalesRateColumn))).ToString();
										mysql = mysql + " , line_no =" + Conversion.Str(Cnt + 2);
										mysql = mysql + " , user_cd =" + Conversion.Str(SystemVariables.gLoggedInUserCode);
										mysql = mysql + " where unit_entry_id =" + Convert.ToString(oAltUnitForm.aAdditionalVoucherDetails.GetValue(Cnt, audUnitEntryIdColumn));
										SqlCommand TempCommand_6 = null;
										TempCommand_6 = SystemVariables.gConn.CreateCommand();
										TempCommand_6.CommandText = mysql;
										TempCommand_6.ExecuteNonQuery();
									}
									else
									{
										MessageBox.Show("Alternate ICS_Unit --" + Convert.ToString(oAltUnitForm.aAdditionalVoucherDetails.GetValue(Cnt, audAltSymbolColumn)) + "-- cannot be duplicate", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
										throw new Exception();
									}
								}
							}
							else
							{
								mysql = "select unit_cd from ICS_Unit where symbol='" + Convert.ToString(oAltUnitForm.aAdditionalVoucherDetails.GetValue(Cnt, audAltSymbolColumn)) + "'";
								//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
								mAltUnitCode = ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetMasterCode(mysql));
								//if the Base Unit and alt ICS_Unit are same then display error
								if (StringsHelper.ToDoubleSafe(mNewBaseUnitCode) == mAltUnitCode)
								{
									MessageBox.Show("Alternate ICS_Unit and Base Unit cannot be same", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
									throw new Exception();
								}

								mysql = "select prod_cd from ICS_Item_Unit_Details where alt_unit_cd=" + Conversion.Str(mAltUnitCode);
								mysql = mysql + " and prod_cd = " + Conversion.Str(mSearchValue);
								//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
								if (Convert.IsDBNull(SystemProcedure2.GetMasterCode(mysql)))
								{
									mysql = "INSERT INTO ICS_Item_Unit_Details (line_no, Prod_Cd, Alt_Unit_Cd, ";
									mysql = mysql + " Base_Unit_Cd , Base_Qty, ";
									mysql = mysql + " Alt_Qty, sales_rate, user_Cd) VALUES (" + Conversion.Str(Cnt + 2) + ",";
									mysql = mysql + Conversion.Str(mSearchValue) + ",";
									mysql = mysql + Conversion.Str(mAltUnitCode) + ",";
									mysql = mysql + Conversion.Str(mNewBaseUnitCode) + ",";
									mysql = mysql + Convert.ToString(oAltUnitForm.aAdditionalVoucherDetails.GetValue(Cnt, audBaseQtyColumn)) + ",";
									mysql = mysql + Convert.ToString(oAltUnitForm.aAdditionalVoucherDetails.GetValue(Cnt, audAltQtyColumn)) + ",";
									mysql = mysql + Conversion.Val(Convert.ToString(oAltUnitForm.aAdditionalVoucherDetails.GetValue(Cnt, audAltUnitSalesRateColumn))).ToString() + ",";
									mysql = mysql + Conversion.Str(SystemVariables.gLoggedInUserCode) + ")";
									SqlCommand TempCommand_7 = null;
									TempCommand_7 = SystemVariables.gConn.CreateCommand();
									TempCommand_7.CommandText = mysql;
									TempCommand_7.ExecuteNonQuery();
								}
								else
								{
									MessageBox.Show("Alternate ICS_Unit --" + Convert.ToString(oAltUnitForm.aAdditionalVoucherDetails.GetValue(Cnt, audAltSymbolColumn)) + "-- cannot be duplicate", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
									throw new Exception();
								}
							}
						}
						else
						{
							mysql = "select unit_cd from ICS_Unit where symbol='" + Convert.ToString(oAltUnitForm.aAdditionalVoucherDetails.GetValue(Cnt, audAltSymbolColumn)) + "'";
							//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							mAltUnitCode = ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetMasterCode(mysql));
							//if the Base Unit and alt ICS_Unit are same then display error
							if (StringsHelper.ToDoubleSafe(mNewBaseUnitCode) == mAltUnitCode)
							{
								MessageBox.Show("Alternate ICS_Unit and Base Unit cannot be same", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
								throw new Exception();
							}

							mysql = "select prod_cd from ICS_Item_Unit_Details where alt_unit_cd=" + Conversion.Str(mAltUnitCode);
							mysql = mysql + " and prod_cd = " + Conversion.Str(mSearchValue);
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
							if (Convert.IsDBNull(SystemProcedure2.GetMasterCode(mysql)))
							{
								mysql = "INSERT INTO ICS_Item_Unit_Details (line_no, Prod_Cd, Alt_Unit_Cd, ";
								mysql = mysql + " Base_Unit_Cd , Base_Qty, ";
								mysql = mysql + " Alt_Qty, sales_rate, User_Cd) VALUES (" + Conversion.Str(Cnt + 2) + ",";
								mysql = mysql + Conversion.Str(mSearchValue) + ",";
								mysql = mysql + Conversion.Str(mAltUnitCode) + ",";
								mysql = mysql + Conversion.Str(mNewBaseUnitCode) + ",";
								mysql = mysql + Convert.ToString(oAltUnitForm.aAdditionalVoucherDetails.GetValue(Cnt, audBaseQtyColumn)) + ",";
								mysql = mysql + Convert.ToString(oAltUnitForm.aAdditionalVoucherDetails.GetValue(Cnt, audAltQtyColumn)) + ",";
								mysql = mysql + Conversion.Val(Convert.ToString(oAltUnitForm.aAdditionalVoucherDetails.GetValue(Cnt, audAltUnitSalesRateColumn))).ToString() + ",";
								mysql = mysql + Conversion.Str(SystemVariables.gLoggedInUserCode) + ")";
								SqlCommand TempCommand_8 = null;
								TempCommand_8 = SystemVariables.gConn.CreateCommand();
								TempCommand_8.CommandText = mysql;
								TempCommand_8.ExecuteNonQuery();
							}
							else
							{
								MessageBox.Show("Alternate ICS_Unit --" + Convert.ToString(oAltUnitForm.aAdditionalVoucherDetails.GetValue(Cnt, audAltSymbolColumn)) + "-- cannot be duplicate", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
								throw new Exception();
							}
						}
					}
				}

				//'''added by Moiz Hakimion 15-aug-2006
				//'''this has to be done when sales rate is enabled on ICS_Unit level eg.hadidco
				//'''as in the ICS_Item_Unit_Details screen we don't show the Base Unit so it has to be updated implicitly
				if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("enable_sales_rate_on_product_unit")))
				{
					mysql = " update ICS_Item_Unit_Details ";
					mysql = mysql + " set sales_rate =" + ReflectionHelper.GetPrimitiveValue<string>(txtCommonNumber[cnSalesRateIndex].Value);
					mysql = mysql + " where prod_cd =" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
					mysql = mysql + " and base_unit_cd = alt_unit_cd ";
					SqlCommand TempCommand_9 = null;
					TempCommand_9 = SystemVariables.gConn.CreateCommand();
					TempCommand_9.CommandText = mysql;
					TempCommand_9.ExecuteNonQuery();
				}

				eSkipAltUnitDetailsUpdateInPOS:

				//'''added by Moiz Hakimi on 20-Jan-2010
				//''' This is for reporting ICS_Unit check
				mysql = "select alt_unit_cd from ICS_Item_Unit_Details";
				mysql = mysql + " where prod_cd =" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
				mysql = mysql + " and alt_unit_cd = " + mNewReportUnitCode;

				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (Convert.IsDBNull(SystemProcedure2.GetMasterCode(mysql)))
				{
					MessageBox.Show("Reporting Unit is not available for this Item", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
					throw new Exception();
				}
				//----------------------------------------------------------------------------------
				//**--if ICS_Item type is of (assembly and add mode ) or (group) then insert component ICS_Item information
				if ((cmbCommon[ccProductTypesIndex].GetItemData(cmbCommon[ccProductTypesIndex].ListIndex) == SystemICSConstants.ptAssemblyBuildTypeID) || (cmbCommon[ccProductTypesIndex].GetItemData(cmbCommon[ccProductTypesIndex].ListIndex) == SystemICSConstants.ptAssemblyGroupTypeID))
				{
					int tempForEndVar2 = aProductAssemblyDetails.GetLength(0) - 1;
					for (Cnt = 0; Cnt <= tempForEndVar2; Cnt++)
					{
						mysql = " select prod_cd from ICS_Item";
						mysql = mysql + " where ";

						if (cmbCommon[ccProductTypesIndex].GetItemData(cmbCommon[ccProductTypesIndex].ListIndex) == SystemICSConstants.ptAssemblyBuildTypeID)
						{
							mysql = mysql + " ICS_Item.item_type_cd in (" + SystemICSConstants.ptInventoryTypeID.ToString() + "," + SystemICSConstants.ptServiceTypeID.ToString() + "," + SystemICSConstants.ptAssemblyBuildTypeID.ToString() + ")";
						}

						if (cmbCommon[ccProductTypesIndex].GetItemData(cmbCommon[ccProductTypesIndex].ListIndex) == SystemICSConstants.ptAssemblyGroupTypeID)
						{
							mysql = mysql + " ICS_Item.item_type_cd = " + SystemICSConstants.ptInventoryTypeID.ToString();
						}

						mysql = mysql + " and discontinued = 0 ";
						mysql = mysql + " and part_no = '" + Convert.ToString(aProductAssemblyDetails.GetValue(Cnt, gccProductCodeColumn)).Trim() + "'";

						//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
						if (Convert.IsDBNull(mTempValue))
						{
							MessageBox.Show("invalid Product code in the assembly details, either the Item does not exists or it is discontinued. ", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
							//tabMaster.CurrTab = mAssemblyDetails
							//Call tabMaster_Click
							grdProductLevelDetails.Col = gccProductCodeColumn;
							throw new Exception();
						}
						else
						{
							//UPGRADE_WARNING: (1068) mTempValue of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							mComponentProductCode = ReflectionHelper.GetPrimitiveValue<int>(mTempValue);
						}

						if (Information.IsNumeric(aProductAssemblyDetails.GetValue(Cnt, gccQtyColumn)))
						{
							mComponentQty = Convert.ToDouble(aProductAssemblyDetails.GetValue(Cnt, gccQtyColumn));
						}
						else
						{
							MessageBox.Show("Invalid component qty", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
							grdProductLevelDetails.Col = gccQtyColumn;
							throw new Exception();
						}

						mComponentMinQty = Convert.ToDouble(aProductAssemblyDetails.GetValue(Cnt, gccMinQtyColumn));
						mComponentMaxQty = Convert.ToDouble(aProductAssemblyDetails.GetValue(Cnt, gccMaxQtyColumn));
						mComponentSRRatio = Convert.ToDouble(aProductAssemblyDetails.GetValue(Cnt, gccSRRatioColumn));

						mComponentSalesPrice = (decimal) Conversion.Val(Convert.ToString(aProductAssemblyDetails.GetValue(Cnt, gccSalesRateColumn)));
						mComponentAdjustMaxRate = Convert.ToInt32(aProductAssemblyDetails.GetValue(Cnt, gccAdjustMaxRateColumn));
						mComponentAdjustMinRate = Convert.ToInt32(aProductAssemblyDetails.GetValue(Cnt, gccAdjustMinRateColumn));

						if (CurrentFormMode == SystemVariables.SystemFormModes.frmAddMode)
						{
							mysql = "insert into ICS_Item_assembly_details ";
							mysql = mysql + " (assembly_prod_cd, component_prod_cd ";
							mysql = mysql + " , assembly_base_qty, component_base_qty ";
							mysql = mysql + " , component_min_base_qty, component_max_base_qty ";
							mysql = mysql + " , component_ratio_in_percent_in_sales_rate ";
							mysql = mysql + " , Component_Sales_Price , Component_Max_Rate_Adjustment, Component_Min_Rate_Adjustment ";
							mysql = mysql + " , comments, user_cd) ";
							mysql = mysql + " values ( ";
							mysql = mysql + Conversion.Str(mSearchValue) + ",";
							mysql = mysql + Conversion.Str(mComponentProductCode) + ",";
							mysql = mysql + Conversion.Str(1) + ",";
							mysql = mysql + Conversion.Str(mComponentQty) + ",";
							mysql = mysql + Conversion.Str(mComponentMinQty) + ",";
							mysql = mysql + Conversion.Str(mComponentMaxQty) + ",";
							mysql = mysql + Conversion.Str(mComponentSRRatio) + ",";
							mysql = mysql + Conversion.Str(mComponentSalesPrice) + ",";
							mysql = mysql + Conversion.Str(mComponentAdjustMaxRate) + ",";
							mysql = mysql + Conversion.Str(mComponentAdjustMinRate) + ",";
							mysql = mysql + "'" + Convert.ToString(aProductAssemblyDetails.GetValue(Cnt, gccRemarksColumn)) + "',";
							mysql = mysql + Conversion.Str(SystemVariables.gLoggedInUserCode) + ")";

							SqlCommand TempCommand_10 = null;
							TempCommand_10 = SystemVariables.gConn.CreateCommand();
							TempCommand_10.CommandText = mysql;
							TempCommand_10.ExecuteNonQuery();
						}

						if ((CurrentFormMode == SystemVariables.SystemFormModes.frmEditMode) && (cmbCommon[ccProductTypesIndex].GetItemData(cmbCommon[ccProductTypesIndex].ListIndex) == SystemICSConstants.ptAssemblyGroupTypeID))
						{
							mysql = " update ICS_Item_assembly_details ";
							mysql = mysql + " set ";
							mysql = mysql + " assembly_base_qty =" + Conversion.Str(1);
							mysql = mysql + " , component_base_qty =" + Conversion.Str(mComponentQty);
							mysql = mysql + " , component_min_base_qty =" + Conversion.Str(mComponentMinQty);
							mysql = mysql + " , component_max_base_qty =" + Conversion.Str(mComponentMaxQty);
							mysql = mysql + " , component_ratio_in_percent_in_sales_rate =" + Conversion.Str(mComponentSRRatio);
							mysql = mysql + " , Component_Sales_Price =" + Conversion.Str(mComponentSalesPrice);
							mysql = mysql + " , Component_Max_Rate_Adjustment =" + Conversion.Str(mComponentAdjustMaxRate);
							mysql = mysql + " , Component_Min_Rate_Adjustment =" + Conversion.Str(mComponentAdjustMinRate);
							mysql = mysql + " , comments =N'" + Convert.ToString(aProductAssemblyDetails.GetValue(Cnt, gccRemarksColumn)) + "'";
							mysql = mysql + " , user_cd=" + Conversion.Str(SystemVariables.gLoggedInUserCode);
							mysql = mysql + " where ";
							mysql = mysql + " assembly_prod_cd=" + Conversion.Str(mSearchValue);
							mysql = mysql + " and component_prod_cd=" + Conversion.Str(mComponentProductCode);

							SqlCommand TempCommand_11 = null;
							TempCommand_11 = SystemVariables.gConn.CreateCommand();
							TempCommand_11.CommandText = mysql;
							TempCommand_11.ExecuteNonQuery();

						}
					}
				}


				//**--This procedure is for insert supplier detail information
				if (mSupplierTabClick)
				{
					if (IsColumnDuplicate(ckLdgrIndex))
					{
						MessageBox.Show("Ledger Code can not be duplicate !!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
						throw new Exception();
					}

					this.grdSupplierDetails.UpdateData();
					mysql = "delete ICS_Item_Supplier_Details ";
					mysql = mysql + " where ";
					mysql = mysql + " Prod_Cd = " + Conversion.Str(mSearchValue);
					SqlCommand TempCommand_12 = null;
					TempCommand_12 = SystemVariables.gConn.CreateCommand();
					TempCommand_12.CommandText = mysql;
					TempCommand_12.ExecuteNonQuery();

					int tempForEndVar3 = aProductSupplierDetails.GetLength(0) - 1;
					for (Cnt = 0; Cnt <= tempForEndVar3; Cnt++)
					{

						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
						if (Convert.IsDBNull(aProductSupplierDetails.GetValue(Cnt, ckLdgrIndex)) || Convert.ToString(aProductSupplierDetails.GetValue(Cnt, ckLdgrIndex)) == "")
						{
							MessageBox.Show("Invalid Party Code", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
							grdSupplierDetails.Col = ckLdgrIndex;
							throw new Exception();
						}
						else
						{

							mysql = "select ldgr_cd ";
							mysql = mysql + " from gl_ledger l where ldgr_no ='" + Convert.ToString(aProductSupplierDetails.GetValue(Cnt, ckLdgrIndex)) + "'";

							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
							if (Convert.IsDBNull(SystemProcedure2.GetMasterCode(mysql)))
							{
								return result;
							}

							//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							mLdgr_Code = ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetMasterCode(mysql));
							mSupplier_Part_No = Convert.ToString(aProductSupplierDetails.GetValue(Cnt, ckPartNoIndex));
							mBarcode = Convert.ToString(aProductSupplierDetails.GetValue(Cnt, ckBarcodeIndex));


							mysql = "insert into ICS_Item_Supplier_Details ";
							mysql = mysql + " ( Prod_Cd, Ldgr_Cd, Supplier_Part_No, Barcode, user_cd) ";
							mysql = mysql + " values ( ";
							mysql = mysql + Conversion.Str(mSearchValue) + ",";
							mysql = mysql + Conversion.Str(mLdgr_Code) + ",";
							mysql = mysql + "'" + mSupplier_Part_No + "',";
							mysql = mysql + "'" + mBarcode + "',";
							mysql = mysql + Conversion.Str(SystemVariables.gLoggedInUserCode) + ")";

							SqlCommand TempCommand_13 = null;
							TempCommand_13 = SystemVariables.gConn.CreateCommand();
							TempCommand_13.CommandText = mysql;
							TempCommand_13.ExecuteNonQuery();
						}

					}
				}

				//**--This procedure is to insert Price detail information
				//If IsPriceDuplicate(ckPriceListIndex) = True Then
				//    MsgBox "Price can not be duplicate !!", vbInformation
				//    GoTo eFoundError
				//End If
				if (mPriceTabClick)
				{
					this.grdPriceDetails.UpdateData();
					mysql = "delete ICS_Price_List_Details ";
					mysql = mysql + " where ";
					mysql = mysql + " Prod_Cd = " + Conversion.Str(mSearchValue);
					SqlCommand TempCommand_14 = null;
					TempCommand_14 = SystemVariables.gConn.CreateCommand();
					TempCommand_14.CommandText = mysql;
					TempCommand_14.ExecuteNonQuery();

					int tempForEndVar4 = aProductPriceDetails.GetLength(0) - 1;
					for (Cnt = 0; Cnt <= tempForEndVar4; Cnt++)
					{

						mysql = "SELECT aud.Alt_Unit_Cd FROM ICS_Item_Unit_Details aud";
						mysql = mysql + " INNER JOIN ICS_Unit ON aud.Alt_Unit_Cd = ICS_Unit.Unit_Cd";
						mysql = mysql + " where Symbol ='" + Convert.ToString(aProductPriceDetails.GetValue(Cnt, ckUnitIndex)) + "'";
						mysql = mysql + " and aud.Prod_Cd = " + Conversion.Str(mSearchValue);

						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
						if (Convert.IsDBNull(SystemProcedure2.GetMasterCode(mysql)))
						{
							MessageBox.Show("Invalid UOM in Price Detail", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
							throw new Exception();
						}

						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
						if (Convert.IsDBNull(aProductPriceDetails.GetValue(Cnt, ckPriceListIndex)) || Convert.ToString(aProductPriceDetails.GetValue(Cnt, ckPriceListIndex)) == "")
						{
							MessageBox.Show("Invalid Price Code", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
							grdPriceDetails.Col = ckPriceListIndex;
							throw new Exception();

						}
						else
						{

							mysql = "select Price_List_Cd ";
							mysql = mysql + " from ICS_Price_List pl where Price_List_No ='" + Convert.ToString(aProductPriceDetails.GetValue(Cnt, ckPriceListIndex)) + "'";

							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
							if (Convert.IsDBNull(SystemProcedure2.GetMasterCode(mysql)))
							{
								return result;
							}

							//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							mPrice_List_Code = ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetMasterCode(mysql));

							mysql = "select Unit_Cd ";
							mysql = mysql + " from ICS_Unit where Symbol ='" + Convert.ToString(aProductPriceDetails.GetValue(Cnt, ckUnitIndex)) + "'";

							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
							if (Convert.IsDBNull(SystemProcedure2.GetMasterCode(mysql)))
							{
								throw new Exception();
							}
							//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							mPrice_Unit_Cd = ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetMasterCode(mysql));
							mPrice_Amt = Convert.ToDouble(aProductPriceDetails.GetValue(Cnt, ckAmountIndex));
							mPrice_Discount_Amt = (Convert.ToString(aProductPriceDetails.GetValue(Cnt, ckDisAmountIndex)) == "") ? 0 : Convert.ToDouble(aProductPriceDetails.GetValue(Cnt, ckDisAmountIndex));
							mPrice_Discount_Percent = (Convert.ToString(aProductPriceDetails.GetValue(Cnt, ckDisPercentIndex)) == "") ? 0 : Convert.ToDouble(aProductPriceDetails.GetValue(Cnt, ckDisPercentIndex));


							mysql = "insert into ICS_Price_List_Details ";
							mysql = mysql + " ( Prod_Cd, Price_List_Cd, Unit_Cd, Price_Amt, Price_Discount_Amt, Price_Discount_Percent, comments, user_cd) ";
							mysql = mysql + " values ( ";
							mysql = mysql + Conversion.Str(mSearchValue) + ", ";
							mysql = mysql + Conversion.Str(mPrice_List_Code) + ", ";
							mysql = mysql + Conversion.Str(mPrice_Unit_Cd) + ", ";
							mysql = mysql + mPrice_Amt.ToString() + ", ";
							mysql = mysql + mPrice_Discount_Amt.ToString() + ", ";
							mysql = mysql + mPrice_Discount_Percent.ToString() + ", ";
							mysql = mysql + "N'" + Convert.ToString(aProductPriceDetails.GetValue(Cnt, ckCommentsIndex)) + "', ";
							mysql = mysql + Conversion.Str(SystemVariables.gLoggedInUserCode) + ")";

							SqlCommand TempCommand_15 = null;
							TempCommand_15 = SystemVariables.gConn.CreateCommand();
							TempCommand_15.CommandText = mysql;
							TempCommand_15.ExecuteNonQuery();
						}
					}
				}

				//---------------------------Barcode Insert-------------------------------------------------------
				if (mBarcodeTabClick)
				{
					this.grdBarcodeDetails.UpdateData();
					mysql = "delete ICS_Item_Barcode_Details ";
					mysql = mysql + " where ";
					mysql = mysql + " Prod_Cd = " + Conversion.Str(mSearchValue);
					SqlCommand TempCommand_16 = null;
					TempCommand_16 = SystemVariables.gConn.CreateCommand();
					TempCommand_16.CommandText = mysql;
					TempCommand_16.ExecuteNonQuery();

					int tempForEndVar5 = aProductBarcodeDetails.GetLength(0) - 1;
					for (Cnt = 0; Cnt <= tempForEndVar5; Cnt++)
					{

						mysql = "SELECT aud.Unit_Entry_Id FROM ICS_Item_Unit_Details aud";
						mysql = mysql + " INNER JOIN ICS_Unit ON aud.Alt_Unit_Cd = ICS_Unit.Unit_Cd";
						mysql = mysql + " where Symbol like '" + Convert.ToString(aProductBarcodeDetails.GetValue(Cnt, cbUnitIndex)) + "'";
						mysql = mysql + " and aud.Prod_Cd = " + Conversion.Str(mSearchValue);

						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
						if (Convert.IsDBNull(SystemProcedure2.GetMasterCode(mysql)))
						{
							MessageBox.Show("Invalid UOM in Barcode Detail", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
							throw new Exception();
						}

						//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mBarcode_Unit_Cd = ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetMasterCode(mysql));

						mysql = "insert into ICS_Item_Barcode_Details ";
						mysql = mysql + " ( Prod_Cd, Barcode, Unit_Entry_Id) ";
						mysql = mysql + " values ( ";
						mysql = mysql + Conversion.Str(mSearchValue) + ", ";
						mysql = mysql + "'" + Convert.ToString(aProductBarcodeDetails.GetValue(Cnt, cbBarcodeIndex)) + "', ";
						mysql = mysql + Conversion.Str(mBarcode_Unit_Cd) + ") ";

						SqlCommand TempCommand_17 = null;
						TempCommand_17 = SystemVariables.gConn.CreateCommand();
						TempCommand_17.CommandText = mysql;
						TempCommand_17.ExecuteNonQuery();
					}
				}
				//-------------------------------------------------------------------------------------------------------------------
				//**--update stock level details in ICS_Item_location_details
				if (mStockLevelDetailsTabClicked && tabMaster.get_TabVisible(Convert.ToInt16(mStockLevelDetails)))
				{
					grdProductLevelDetails.UpdateData();
					int tempForEndVar6 = aProductStockLevels.GetLength(0) - 1;
					for (Cnt = 0; Cnt <= tempForEndVar6; Cnt++)
					{
						if (!Information.IsNumeric(aProductStockLevels.GetValue(Cnt, cslMaximumQtyColumn)))
						{
							MessageBox.Show("Invalid maximum qty", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
							grdProductLevelDetails.Col = cslMaximumQtyColumn;
							throw new Exception();
						}
						if (!Information.IsNumeric(aProductStockLevels.GetValue(Cnt, cslMinimumQtyColumn)))
						{
							MessageBox.Show("Invalid minimum qty", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
							grdProductLevelDetails.Col = cslMinimumQtyColumn;
							throw new Exception();
						}
						if (!Information.IsNumeric(aProductStockLevels.GetValue(Cnt, cslReorderQtyColumn)))
						{
							MessageBox.Show("Invalid reorder qty", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
							grdProductLevelDetails.Col = cslReorderQtyColumn;
							throw new Exception();
						}


						//**--making sure for a record existance for the ICS_Item in the location
						mysql = "if not exists(select * from ICS_Item_location_details ";
						mysql = mysql + " where prod_cd = " + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
						mysql = mysql + " and locat_cd = " + Convert.ToString(aProductStockLevels.GetValue(Cnt, cslLocationCodeColumn));
						mysql = mysql + " ) begin insert into ICS_Item_location_details ";
						mysql = mysql + " (prod_cd, locat_cd, user_cd) values (";
						mysql = mysql + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue) + ", " + Convert.ToString(aProductStockLevels.GetValue(Cnt, cslLocationCodeColumn));
						mysql = mysql + ", " + SystemVariables.gLoggedInUserCode.ToString() + ") end ";
						SqlCommand TempCommand_18 = null;
						TempCommand_18 = SystemVariables.gConn.CreateCommand();
						TempCommand_18.CommandText = mysql;
						TempCommand_18.ExecuteNonQuery();

						mysql = "update ICS_Item_location_details ";
						mysql = mysql + " set maximum_level = " + Conversion.Val(Convert.ToString(aProductStockLevels.GetValue(Cnt, cslMaximumQtyColumn))).ToString();
						mysql = mysql + ", minimum_level = " + Conversion.Val(Convert.ToString(aProductStockLevels.GetValue(Cnt, cslMinimumQtyColumn))).ToString();
						mysql = mysql + ", reorder_level = " + Conversion.Val(Convert.ToString(aProductStockLevels.GetValue(Cnt, cslReorderQtyColumn))).ToString();
						mysql = mysql + ", Bin_Location = '" + Convert.ToString(aProductStockLevels.GetValue(Cnt, cslBinColumn)) + "'";
						mysql = mysql + ", Include_In_location = " + ((Convert.ToDouble(aProductStockLevels.GetValue(Cnt, cslIncludeInLocationColumn)) == 0) ? 0 : 1).ToString();
						mysql = mysql + ", comments = '" + Convert.ToString(aProductStockLevels.GetValue(Cnt, cslRemarksColumn)) + "'";
						mysql = mysql + " where prod_cd = " + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
						mysql = mysql + " and locat_cd = " + Convert.ToString(aProductStockLevels.GetValue(Cnt, cslLocationCodeColumn));

						SqlCommand TempCommand_19 = null;
						TempCommand_19 = SystemVariables.gConn.CreateCommand();
						TempCommand_19.CommandText = mysql;
						TempCommand_19.ExecuteNonQuery();
					}
				}
				//--------------------------Insert Activity Details------------------------------
				if (mActivityTabClick)
				{
					this.grdActivityDetails.UpdateData();
					mysql = "delete ICS_Item_Activity_Type_Details ";
					mysql = mysql + " where ";
					mysql = mysql + " Prod_Cd = " + Conversion.Str(mSearchValue);
					SqlCommand TempCommand_20 = null;
					TempCommand_20 = SystemVariables.gConn.CreateCommand();
					TempCommand_20.CommandText = mysql;
					TempCommand_20.ExecuteNonQuery();

					int tempForEndVar7 = aProductActivityDetails.GetLength(0) - 1;
					for (Cnt = 0; Cnt <= tempForEndVar7; Cnt++)
					{

						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
						if (Convert.IsDBNull(aProductActivityDetails.GetValue(Cnt, caActivityCode)) || Convert.ToString(aProductActivityDetails.GetValue(Cnt, caActivityName)) == "")
						{
							MessageBox.Show("Invalid Activity Code", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
							grdActivityDetails.Col = caActivityCode;
							throw new Exception();

						}
						else
						{

							mysql = "SELECT Activity_Type_Cd FROM PROJ_Project_Activity_Types ";
							mysql = mysql + " where Activity_Type_No = " + Convert.ToString(aProductActivityDetails.GetValue(Cnt, caActivityCode));

							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
							if (Convert.IsDBNull(SystemProcedure2.GetMasterCode(mysql)))
							{
								return result;
							}

							//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							mActivity_Code = ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetMasterCode(mysql));

							mysql = "insert into ICS_Item_Activity_Type_Details ";
							mysql = mysql + " ( Prod_Cd, Activity_Type_Cd) ";
							mysql = mysql + " values ( ";
							mysql = mysql + Conversion.Str(mSearchValue) + ", ";
							mysql = mysql + Conversion.Str(mActivity_Code) + ")";

							SqlCommand TempCommand_21 = null;
							TempCommand_21 = SystemVariables.gConn.CreateCommand();
							TempCommand_21.CommandText = mysql;
							TempCommand_21.ExecuteNonQuery();
						}
					}
				}
				//---------------------------------------------------------------------------------------

				//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.CommitTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				SystemVariables.gConn.CommitTrans();
				result = true;

				if (ControlHelper.GetEnabled(FirstFocusObject))
				{
					FirstFocusObject.Focus();
				}
			}
			catch (System.Exception excep)
			{

				int mReturnErrorType = 0;

				//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				SystemVariables.gConn.RollbackTrans();
				result = false;
				if (mShowErrorMessage)
				{
					//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
					mReturnErrorType = SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, excep.Message, this.Name, "GetRecord", SystemConstants.msg10);
				}
			}
			return result;
		}

		public bool deleteRecord()
		{
			//Delete the Record

			//If an error occurs, trap the error and dispaly a valid message
			bool result = false;
			SystemVariables.gConn.BeginTransaction();

			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{
				string mysql = "delete from ICS_Item_barcode_details where prod_cd =" + Conversion.Str(mSearchValue);
				SqlCommand TempCommand = null;
				TempCommand = SystemVariables.gConn.CreateCommand();
				TempCommand.CommandText = mysql;
				TempCommand.ExecuteNonQuery();

				mysql = "delete from ICS_Item_Unit_Details where prod_cd =" + Conversion.Str(mSearchValue);
				SqlCommand TempCommand_2 = null;
				TempCommand_2 = SystemVariables.gConn.CreateCommand();
				TempCommand_2.CommandText = mysql;
				TempCommand_2.ExecuteNonQuery();

				mysql = "delete from ICS_Item_assembly_details where assembly_prod_cd = " + Conversion.Str(mSearchValue);
				SqlCommand TempCommand_3 = null;
				TempCommand_3 = SystemVariables.gConn.CreateCommand();
				TempCommand_3.CommandText = mysql;
				TempCommand_3.ExecuteNonQuery();

				mysql = "delete from ICS_Item_trans_info where prod_cd =" + Conversion.Str(mSearchValue);
				SqlCommand TempCommand_4 = null;
				TempCommand_4 = SystemVariables.gConn.CreateCommand();
				TempCommand_4.CommandText = mysql;
				TempCommand_4.ExecuteNonQuery();

				mysql = "delete from ICS_Item_location_details where prod_cd =" + Conversion.Str(mSearchValue);
				SqlCommand TempCommand_5 = null;
				TempCommand_5 = SystemVariables.gConn.CreateCommand();
				TempCommand_5.CommandText = mysql;
				TempCommand_5.ExecuteNonQuery();

				mysql = "delete from ICS_Item where prod_cd =" + Conversion.Str(mSearchValue);
				SqlCommand TempCommand_6 = null;
				TempCommand_6 = SystemVariables.gConn.CreateCommand();
				TempCommand_6.CommandText = mysql;
				TempCommand_6.ExecuteNonQuery();
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				if (Information.Err().Number != 0)
				{
					MessageBox.Show("Product cannot be deleted, transaction already exists", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					SystemVariables.gConn.RollbackTrans();
					return false;
				}


				//'''Donot allow to delete or modify the record if the information exists in the ST_OFFLINE_DETAILS
				mysql = " select comp_id from ST_OFFLINE_DETAILS ";
				mysql = mysql + " where table_name = 'product' ";
				mysql = mysql + " and (upload_entry_id ='" + Conversion.Str(mSearchValue).Trim() + "'";
				mysql = mysql + " or download_generated_entry_id ='" + Conversion.Str(mSearchValue).Trim() + "')";
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				object mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
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

				return true;


				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				int mReturnErrorType = SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, Information.Err().Description, this.Name, "GetRecord", SystemConstants.msg10);
				if (mReturnErrorType == 1)
				{
					//mSearchValue = GetMasterCode("select from gl_accnt_group", "group_no", txtGroupNo.Text, "group_cd")
					//Call GetRecord("gl_accnt_group", "group_cd", mSearchValue, StringType)
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
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
			return result;
		}

		public void GetRecord(object pSearchValue)
		{
			string mysql = "";
			DataSet rsLocalRec = new DataSet();

			try
			{

				if (SystemProcedure2.IsItEmpty(pSearchValue, SystemVariables.DataType.StringType))
				{
					return;
				}
				//**--change the form mode to edit
				mCurrentFormMode = SystemVariables.SystemFormModes.frmEditMode;
				//**--reset other settings and focus status
				mAttemptToSetFocus = false;
				ResetAllObjects();

				mysql = " select ICS_Item.*, pg.group_no, pc.cat_no, ICS_Unit.unit_no, unit1.unit_no as Report_unit_no, gl_ledger.ldgr_no as sup_no, ";
				mysql = mysql + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "pg.l_group_name" : "pg.a_group_name") + " as group_name, ";
				mysql = mysql + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "pc.l_cat_name" : "pc.a_cat_name") + " as cat_name, ";
				mysql = mysql + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "ICS_Unit.l_unit_name" : "ICS_Unit.a_unit_name") + " as unit_name, ";
				mysql = mysql + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "unit1.l_unit_name" : "unit1.a_unit_name") + " as Report_unit_name, ";
				mysql = mysql + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "gl_ledger.l_ldgr_name" : "gl_ledger.a_ldgr_name") + " as sup_name ";
				mysql = mysql + " from ICS_Item inner join ICS_Item_group pg on ICS_Item.group_cd = pg.group_cd ";
				mysql = mysql + " inner join ICS_Item_category pc on ICS_Item.cat_cd = pc.cat_cd ";
				mysql = mysql + " inner join ICS_Unit on ICS_Item.base_unit_cd = ICS_Unit.unit_cd ";
				mysql = mysql + " inner join ICS_Unit unit1 on ICS_Item.Report_unit_cd = unit1.unit_cd ";
				mysql = mysql + " left outer join gl_ledger on ICS_Item.supplier_ldgr_cd = gl_ledger.ldgr_cd ";
				mysql = mysql + " where ICS_Item.prod_cd = " + ReflectionHelper.GetPrimitiveValue<string>(pSearchValue);

				SqlDataAdapter adap = new SqlDataAdapter(mysql, SystemVariables.gConn);
				rsLocalRec.Tables.Clear();
				adap.Fill(rsLocalRec);
				if (rsLocalRec.Tables[0].Rows.Count != 0)
				{
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					mSearchValue = rsLocalRec.Tables[0].Rows[0]["prod_cd"];
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					mRecordNavigateSearchValue = Convert.ToInt32(rsLocalRec.Tables[0].Rows[0]["prod_cd"]);
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					mTimeStamp = Convert.ToString(rsLocalRec.Tables[0].Rows[0]["Time_Stamp"]);

					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					txtCommon[ctPartNoIndex].Text = Convert.ToString(rsLocalRec.Tables[0].Rows[0]["part_no"]);
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					txtCommon[ctEnglishProductName].Text = Convert.ToString(rsLocalRec.Tables[0].Rows[0]["l_prod_name"]);
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					txtCommon[ctArabicProductNameIndex].Text = Convert.ToString(rsLocalRec.Tables[0].Rows[0]["a_prod_name"]);
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					txtProdDesc.Text = Convert.ToString(rsLocalRec.Tables[0].Rows[0]["prod_desc"]) + "";
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					SystemCombo.SearchCombo(cmbCommon[ccProductTypesIndex], Convert.ToInt32(rsLocalRec.Tables[0].Rows[0]["item_type_cd"]));
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					SystemCombo.SearchCombo(cmbCommon[ccCostingMethodIndex], Convert.ToInt32(rsLocalRec.Tables[0].Rows[0]["costing_method"]));
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					txtCommon[ctBaseUnitIndex].Text = Convert.ToString(rsLocalRec.Tables[0].Rows[0]["unit_no"]);
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					txtCommon[ctReportUnitIndex].Text = Convert.ToString(rsLocalRec.Tables[0].Rows[0]["Report_unit_no"]);
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					txtCommon[ctGroupCodeIndex].Text = Convert.ToString(rsLocalRec.Tables[0].Rows[0]["group_no"]);
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					txtCommon[ctCategoryCodeIndex].Text = Convert.ToString(rsLocalRec.Tables[0].Rows[0]["cat_no"]);
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					txtCommonDisplay[ctlBaseUnitNameIndex].Text = Convert.ToString(rsLocalRec.Tables[0].Rows[0]["unit_name"]);
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					txtCommonDisplay[ctlReportUnitNameIndex].Text = Convert.ToString(rsLocalRec.Tables[0].Rows[0]["Report_unit_name"]);
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					txtCommonDisplay[ctlGroupNameIndex].Text = Convert.ToString(rsLocalRec.Tables[0].Rows[0]["group_name"]);
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					txtCommonDisplay[ctlCategoryNameIndex].Text = Convert.ToString(rsLocalRec.Tables[0].Rows[0]["cat_name"]);
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					txtComment.Text = Convert.ToString(rsLocalRec.Tables[0].Rows[0]["Comments"]) + "";
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					txtCommonNumber[cnProductCostIndex].Value = rsLocalRec.Tables[0].Rows[0]["cost"];
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
					//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
					chkCommon[ckSerializedIndex].CheckState = (CheckState) ((((TriState) Convert.ToInt32(rsLocalRec.Tables[0].Rows[0]["serialized"])) == TriState.True) ? 1 : 0);
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
					//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
					chkCommon[ckDiscontinuedIndex].CheckState = (CheckState) ((((TriState) Convert.ToInt32(rsLocalRec.Tables[0].Rows[0]["discontinued"])) == TriState.True) ? 1 : 0);
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
					//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
					chkCommon[ckPromotionalItemIndex].CheckState = (CheckState) ((((TriState) Convert.ToInt32(rsLocalRec.Tables[0].Rows[0]["promotional_item"])) == TriState.True) ? 1 : 0);
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
					//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
					chkCommon[ckPrintVoucherOnComponentsIndex].CheckState = (CheckState) ((((TriState) Convert.ToInt32(rsLocalRec.Tables[0].Rows[0]["print_components_on_voucher"])) == TriState.True) ? 1 : 0);

					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					txtCommonNumber[cnSalesRateIndex].Value = (rsLocalRec.Tables[0].Rows[0].IsNull("sales_rate")) ? ((object) 0) : rsLocalRec.Tables[0].Rows[0]["sales_rate"];
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					txtCommonNumber[cnSalesRateLevel1Index].Value = (rsLocalRec.Tables[0].Rows[0].IsNull("sale_rate1")) ? ((object) 0) : rsLocalRec.Tables[0].Rows[0]["sale_rate1"];
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					txtCommonNumber[cnSalesRateLevel2Index].Value = (rsLocalRec.Tables[0].Rows[0].IsNull("sale_rate2")) ? ((object) 0) : rsLocalRec.Tables[0].Rows[0]["sale_rate2"];
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					txtCommonNumber[cnSalesRateLevel3Index].Value = (rsLocalRec.Tables[0].Rows[0].IsNull("sale_rate3")) ? ((object) 0) : rsLocalRec.Tables[0].Rows[0]["sale_rate3"];
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					txtCommonNumber[cnSalesRateLevel4Index].Value = (rsLocalRec.Tables[0].Rows[0].IsNull("sale_rate4")) ? ((object) 0) : rsLocalRec.Tables[0].Rows[0]["sale_rate4"];
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					txtCommonNumber[cnSalesRateLevel5Index].Value = (rsLocalRec.Tables[0].Rows[0].IsNull("sale_rate5")) ? ((object) 0) : rsLocalRec.Tables[0].Rows[0]["sale_rate5"];
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					txtCommonNumber[cnPurchaseRateIndex].Value = (rsLocalRec.Tables[0].Rows[0].IsNull("purchase_rate")) ? ((object) 0) : rsLocalRec.Tables[0].Rows[0]["purchase_rate"];
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					txtCommonNumber[cnPurchaseRateLevel1Index].Value = (rsLocalRec.Tables[0].Rows[0].IsNull("purchase_rate_1")) ? ((object) 0) : rsLocalRec.Tables[0].Rows[0]["purchase_rate_1"];
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					txtCommonNumber[cnPurchaseRateLevel2Index].Value = (rsLocalRec.Tables[0].Rows[0].IsNull("purchase_rate_2")) ? ((object) 0) : rsLocalRec.Tables[0].Rows[0]["purchase_rate_2"];
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					txtCommonNumber[cnPurchaseRateLevel3Index].Value = (rsLocalRec.Tables[0].Rows[0].IsNull("purchase_rate_3")) ? ((object) 0) : rsLocalRec.Tables[0].Rows[0]["purchase_rate_3"];
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					txtCommonNumber[cnPurchaseRateLevel4Index].Value = (rsLocalRec.Tables[0].Rows[0].IsNull("purchase_rate_4")) ? ((object) 0) : rsLocalRec.Tables[0].Rows[0]["purchase_rate_4"];
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					txtCommonNumber[cnPurchaseRateLevel5Index].Value = (rsLocalRec.Tables[0].Rows[0].IsNull("purchase_rate_5")) ? ((object) 0) : rsLocalRec.Tables[0].Rows[0]["purchase_rate_5"];
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					txtCommonNumber[cnCommissionOnSalesIndex].Value = (rsLocalRec.Tables[0].Rows[0].IsNull("commision_in_percent_on_sales")) ? ((object) 0) : rsLocalRec.Tables[0].Rows[0]["commision_in_percent_on_sales"];
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					txtCommonNumber[cnCommissionOnPurchaseIndex].Value = (rsLocalRec.Tables[0].Rows[0].IsNull("commision_in_percent_on_purchase")) ? ((object) 0) : rsLocalRec.Tables[0].Rows[0]["commision_in_percent_on_purchase"];
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					txtCommonNumber[cnWarrantyPeriodIndex].Value = (rsLocalRec.Tables[0].Rows[0].IsNull("warranty_period_in_days")) ? ((object) 0) : rsLocalRec.Tables[0].Rows[0]["warranty_period_in_days"];
					//txtCommon(ctBinLocationIndex).Text = .Fields("bin_location").Value & ""
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					txtCommonNumber[cnWeightIndex].Value = rsLocalRec.Tables[0].Rows[0]["weight"];

					//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
					if (((TriState) ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetSystemPreferenceSetting("show_other_details_tab_in_product"))) == TriState.True)
					{
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						txtCommon[ctPrefferedSupplierCodeIndex].Text = Convert.ToString(rsLocalRec.Tables[0].Rows[0]["sup_no"]) + "";
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						txtCommonDisplay[ctlPrefferedSupplierNameIndex].Text = Convert.ToString(rsLocalRec.Tables[0].Rows[0]["sup_name"]) + "";
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						txtCommon[ctSupplierPartNoIndex].Text = Convert.ToString(rsLocalRec.Tables[0].Rows[0]["supplier_part_no"]) + "";

						//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
						if (((TriState) ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetSystemPreferenceSetting("show_package_date_on_item_master"))) == TriState.True)
						{
							//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
							txtCommon[ctPackageIndex].Text = (rsLocalRec.Tables[0].Rows[0].IsNull("package")) ? "" : Convert.ToString(rsLocalRec.Tables[0].Rows[0]["package"]);

							//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
							if (rsLocalRec.Tables[0].Rows[0].IsNull("ExpDate"))
							{
								txtExpDate.Text = "";
							}
							else
							{
								//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
								txtExpDate.Value = rsLocalRec.Tables[0].Rows[0]["ExpDate"];
							}

							//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
							if (rsLocalRec.Tables[0].Rows[0].IsNull("PackDate"))
							{
								txtPackDate.Text = "";
							}
							else
							{
								//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
								txtPackDate.Value = rsLocalRec.Tables[0].Rows[0]["PackDate"];
							}
							//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
							txtCommon[ctMadeIndex].Text = (rsLocalRec.Tables[0].Rows[0].IsNull("MadeIn")) ? "" : Convert.ToString(rsLocalRec.Tables[0].Rows[0]["MadeIn"]);
						}
					}
					//**--show total number of transactions made for the ICS_Item
					lblCommon[clTotalNoOfTransactionIndex].Caption = mBracketOpener + mTotalNoOfTransactionText + Conversion.Str(SystemProcedure2.GetMasterCode("select count(*) from ICS_Transaction_Details where prod_cd = " + ReflectionHelper.GetPrimitiveValue<string>(pSearchValue))) + mBracketCloser;
					//**----------------------------------------------------------------------------------------------------

					//**--set default picture file folder name
					//txtCommonDisplay(ctlPictureFileFolderIndex).Text = gProductPicturesPath
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					txtCommon[ctPictureFileNameIndex].Text = Convert.ToString(rsLocalRec.Tables[0].Rows[0]["picture"]) + "";
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					if (!SystemProcedure2.IsItEmpty(rsLocalRec.Tables[0].Rows[0]["picture"], SystemVariables.DataType.StringType))
					{
						SetProductPicture();
					}
					//**----------------------------------------------------------------------------------------------------

					//**--make current tab to mAssemblyDetails so that all the
					//**--settings will be done (e.g. filling grid with components etc.)
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					if (Convert.ToDouble(rsLocalRec.Tables[0].Rows[0]["item_type_cd"]) == SystemICSConstants.ptAssemblyBuildTypeID || Convert.ToDouble(rsLocalRec.Tables[0].Rows[0]["item_type_cd"]) == SystemICSConstants.ptAssemblyGroupTypeID)
					{
						ShowAssemblyDetailsTab();
						mAssemblyDetailsTabClicked = true;
						//tabMaster.CurrTab = mAssemblyDetails
					}
					//**----------------------------------------------------------------------------------------------------
					//**--do not allow ICS_Item type & costing method to be changed
					cmbCommon[ccProductTypesIndex].Enabled = false;
					cmbCommon[ccCostingMethodIndex].Enabled = false;
					//**----------------------------------------------------------------------------------------------------
					ShowHideMasterDetails();
					mSupplierTabClick = false;
					mPriceTabClick = false;
					mBarcodeTabClick = false;
					mActivityTabClick = false;

					//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
					if (((TriState) ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetSystemPreferenceSetting("show_flex_details_tab_in_product"))) == TriState.True)
					{
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						txtFlex[ctFlex1Index].Text = Convert.ToString(rsLocalRec.Tables[0].Rows[0]["flex1_vssv_code"]) + "";
						txtFlex_Leave(txtFlex[ctFlex1Index], new EventArgs());
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						txtFlex[ctFlex2Index].Text = Convert.ToString(rsLocalRec.Tables[0].Rows[0]["flex2_vssv_code"]) + "";
						txtFlex_Leave(txtFlex[ctFlex2Index], new EventArgs());
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						txtFlex[ctFlex3Index].Text = Convert.ToString(rsLocalRec.Tables[0].Rows[0]["flex3_vssv_code"]) + "";
						txtFlex_Leave(txtFlex[ctFlex3Index], new EventArgs());
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						txtFlex[ctFlex4Index].Text = Convert.ToString(rsLocalRec.Tables[0].Rows[0]["flex4_vssv_code"]) + "";
						txtFlex_Leave(txtFlex[ctFlex4Index], new EventArgs());
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						txtFlex[ctFlex5Index].Text = Convert.ToString(rsLocalRec.Tables[0].Rows[0]["flex5_vssv_code"]) + "";
						txtFlex_Leave(txtFlex[ctFlex5Index], new EventArgs());
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						txtFlex[ctFlex6Index].Text = Convert.ToString(rsLocalRec.Tables[0].Rows[0]["flex6_vssv_code"]) + "";
						txtFlex_Leave(txtFlex[ctFlex6Index], new EventArgs());
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						txtFlex[ctFlex7Index].Text = Convert.ToString(rsLocalRec.Tables[0].Rows[0]["flex7_vssv_code"]) + "";
						txtFlex_Leave(txtFlex[ctFlex7Index], new EventArgs());
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						txtFlex[ctFlex8Index].Text = Convert.ToString(rsLocalRec.Tables[0].Rows[0]["flex8_vssv_code"]) + "";
						txtFlex_Leave(txtFlex[ctFlex8Index], new EventArgs());
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						txtFlex[ctFlex9Index].Text = Convert.ToString(rsLocalRec.Tables[0].Rows[0]["flex9_vssv_code"]) + "";
						txtFlex_Leave(txtFlex[ctFlex9Index], new EventArgs());
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						txtFlex[ctFlex10Index].Text = Convert.ToString(rsLocalRec.Tables[0].Rows[0]["flex10_vssv_code"]) + "";
						txtFlex_Leave(txtFlex[ctFlex10Index], new EventArgs());
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						txtFlex[ctFlex11Index].Text = Convert.ToString(rsLocalRec.Tables[0].Rows[0]["flex11_vssv_code"]) + "";
						txtFlex_Leave(txtFlex[ctFlex11Index], new EventArgs());
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						txtFlex[ctFlex12Index].Text = Convert.ToString(rsLocalRec.Tables[0].Rows[0]["flex12_vssv_code"]) + "";
						txtFlex_Leave(txtFlex[ctFlex12Index], new EventArgs());
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						txtFlex[ctFlex13Index].Text = Convert.ToString(rsLocalRec.Tables[0].Rows[0]["flex13_vssv_code"]) + "";
						txtFlex_Leave(txtFlex[ctFlex13Index], new EventArgs());
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						txtFlex[ctFlex14Index].Text = Convert.ToString(rsLocalRec.Tables[0].Rows[0]["flex14_vssv_code"]) + "";
						txtFlex_Leave(txtFlex[ctFlex14Index], new EventArgs());
					}
					//--------disable part number editing----------------------
					//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
					txtCommon[ctPartNoIndex].Enabled = ((TriState) ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetSystemPreferenceSetting("enable_part_no_editing"))) == TriState.True;
					//----------------------------------------------------------
				}
				else
				{
					MessageBox.Show("No records found", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				rsLocalRec = null;
				tabMaster.CurrTab = Convert.ToInt16(mBasicMasterDetails);
				mAttemptToSetFocus = true;
				cmdSupplierList_DataSourceChanged(cmdSupplierList, new EventArgs());
			}
			catch (System.Exception excep)
			{


				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, excep.Message, this.Name, "GetRecord");
			}
		}

		public void findRecord()
		{
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{

				//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				object mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(2001000));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(mTempSearchValue))
				{
					//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mSearchValue = ReflectionHelper.GetPrimitiveValue(((Array) mTempSearchValue).GetValue(0));
					Application.DoEvents();
					GetRecord(mSearchValue);
				}
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		public void CloseForm()
		{
			this.Close();
		}

		public bool CheckDataValidity()
		{
			bool result = false;
			DataSet rsMasterInfo = null;
			string mCheckTimeStamp = "";
			string mysql = "";
			int Cnt = 0;

			try
			{

				if (tabMaster.CurrTab == mAssemblyDetails)
				{
					if (grdAssemblyDetails.Visible)
					{
						grdAssemblyDetails.UpdateData();
					}
				}
				if (tabMaster.CurrTab == mStockLevelDetails)
				{
					//    If grdProductLevelDetails.Visible = True Then
					//        grdProductLevelDetails.Update
					//    End If
				}

				txtCommon_Leave(txtCommon[ctBaseUnitIndex], new EventArgs());
				//------------------------ Reporting ICS_Unit Code-----Moiz Hakimi--11-Jan-2010----------------
				txtCommon_Leave(txtCommon[ctReportUnitIndex], new EventArgs());
				//-----------------------------------------------------------------------------------------
				txtCommon_Leave(txtCommon[ctGroupCodeIndex], new EventArgs());
				txtCommon_Leave(txtCommon[ctCategoryCodeIndex], new EventArgs());
				txtCommon_Leave(txtCommon[ctPrefferedSupplierCodeIndex], new EventArgs());

				if (!txtCommon[ctPrefferedSupplierCodeIndex].Visible)
				{
					txtCommon[ctPrefferedSupplierCodeIndex].Text = "";
				}
				txtCommon_Leave(txtCommon[ctPrefferedSupplierCodeIndex], new EventArgs());

				if (SystemProcedure2.IsItEmpty(Convert.ToString(txtCommon[ctBaseUnitIndex].Tag), SystemVariables.DataType.StringType))
				{
					mNewBaseUnitCode = "DEFAULT";
				}
				else
				{
					mNewBaseUnitCode = Conversion.Str(Convert.ToString(txtCommon[ctBaseUnitIndex].Tag)).Trim();
				}
				//------------------------ Reporting ICS_Unit Code-----------Moiz Hakimi--11-Jan-2010----------------
				if (SystemProcedure2.IsItEmpty(Convert.ToString(txtCommon[ctReportUnitIndex].Tag), SystemVariables.DataType.StringType))
				{
					mNewReportUnitCode = "DEFAULT";
				}
				else
				{
					mNewReportUnitCode = Conversion.Str(Convert.ToString(txtCommon[ctReportUnitIndex].Tag)).Trim();
				}
				//------------------------------------------------------------------------------------------------
				if (SystemProcedure2.IsItEmpty(Convert.ToString(txtCommon[ctGroupCodeIndex].Tag), SystemVariables.DataType.StringType))
				{
					mNewGroupCode = "DEFAULT";
				}
				else
				{
					mNewGroupCode = Conversion.Str(Convert.ToString(txtCommon[ctGroupCodeIndex].Tag)).Trim();
				}

				if (SystemProcedure2.IsItEmpty(Convert.ToString(txtCommon[ctCategoryCodeIndex].Tag), SystemVariables.DataType.StringType))
				{
					mNewCategoryCode = "DEFAULT";
				}
				else
				{
					mNewCategoryCode = Conversion.Str(Convert.ToString(txtCommon[ctCategoryCodeIndex].Tag));
				}

				if (SystemProcedure2.IsItEmpty(Convert.ToString(txtCommon[ctPrefferedSupplierCodeIndex].Tag), SystemVariables.DataType.StringType))
				{
					mNewPrefferedSupplierCode = "NULL";
				}
				else
				{
					mNewPrefferedSupplierCode = "'" + Convert.ToString(txtCommon[ctPrefferedSupplierCodeIndex].Tag) + "'";
				}

				//''Do not allow to add new record in case of POS
				//If CurrentFormMode = frmAddMode Then
				//    If GetSystemPreferenceSetting("offline_data_management") = True And gIsHeadOffice = False Then
				//        MsgBox "New Item cannot be created no POS.", vbInformation
				//        GoTo eFoundError
				//    End If
				//End If

				if (SystemProcedure2.IsItEmpty(txtCommon[ctPartNoIndex].Text, SystemVariables.DataType.StringType))
				{
					MessageBox.Show("Enter Ledger Code", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					txtCommon[ctPartNoIndex].Focus();
					throw new Exception();
				}

				if (txtCommon[ctBaseUnitIndex].Visible && SystemProcedure2.IsItEmpty(txtCommon[ctBaseUnitIndex].Text, SystemVariables.DataType.NumberType))
				{
					MessageBox.Show("Enter Base Unit code", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					if (tabMaster.CurrTab == mBasicMasterDetails)
					{
						txtCommon[ctBaseUnitIndex].Focus();
					}
					else
					{
						FirstFocusObject.Focus();
					}
					throw new Exception();
				}
				if (txtCommon[ctReportUnitIndex].Visible && SystemProcedure2.IsItEmpty(txtCommon[ctReportUnitIndex].Text, SystemVariables.DataType.NumberType))
				{
					MessageBox.Show("Enter Report ICS_Unit code", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					if (tabMaster.CurrTab == mBasicMasterDetails)
					{
						txtCommon[ctReportUnitIndex].Focus();
					}
					else
					{
						FirstFocusObject.Focus();
					}
					throw new Exception();
				}
				if (txtCommon[ctGroupCodeIndex].Visible && SystemProcedure2.IsItEmpty(txtCommon[ctGroupCodeIndex].Text, SystemVariables.DataType.NumberType))
				{
					MessageBox.Show("Enter ICS_Item group code", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					if (tabMaster.CurrTab == mBasicMasterDetails)
					{
						txtCommon[ctGroupCodeIndex].Focus();
					}
					else
					{
						FirstFocusObject.Focus();
					}
					throw new Exception();
				}
				if (txtCommon[ctCategoryCodeIndex].Visible && SystemProcedure2.IsItEmpty(txtCommon[ctCategoryCodeIndex].Text, SystemVariables.DataType.NumberType))
				{
					MessageBox.Show("Enter ICS_Item category code", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					if (tabMaster.CurrTab == mBasicMasterDetails)
					{
						txtCommon[ctCategoryCodeIndex].Focus();
					}
					else
					{
						FirstFocusObject.Focus();
					}
					throw new Exception();
				}
				//**--------------------------------------------------------------------------------------------------------------

				if (CurrentFormMode == SystemVariables.SystemFormModes.frmEditMode)
				{
					//--check the timestamp value
					mysql = "select time_stamp from ICS_Item where prod_cd = " + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
					SqlCommand TempCommand = null;
					TempCommand = SystemVariables.gConn.CreateCommand();
					TempCommand.CommandText = mysql;
					SqlDataAdapter TempAdapter = null;
					TempAdapter = new SqlDataAdapter();
					TempAdapter.SelectCommand = TempCommand;
					DataSet TempDataset = null;
					TempDataset = new DataSet();
					TempAdapter.Fill(TempDataset);
					rsMasterInfo = TempDataset;
					if (rsMasterInfo.Tables[0].Rows.Count != 0)
					{
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						mCheckTimeStamp = Convert.ToString(rsMasterInfo.Tables[0].Rows[0]["time_stamp"]);
					}
					if ((rsMasterInfo.Tables[0].Rows.Count == 0) || (SystemProcedure2.tsFormat(mTimeStamp) != SystemProcedure2.tsFormat(mCheckTimeStamp)))
					{
						MessageBox.Show(SystemConstants.msg10, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
						FirstFocusObject.Focus();
						rsMasterInfo = null;
						throw new Exception();
					}
				}


				if (cmbCommon[ccProductTypesIndex].GetItemData(cmbCommon[ccProductTypesIndex].ListIndex) == SystemICSConstants.ptAssemblyBuildTypeID || cmbCommon[ccProductTypesIndex].GetItemData(cmbCommon[ccProductTypesIndex].ListIndex) == SystemICSConstants.ptAssemblyGroupTypeID)
				{
					if (mAssemblyDetailsTabClicked)
					{
						if (aProductAssemblyDetails.GetLength(0) > 0)
						{
							int tempForEndVar = aProductAssemblyDetails.GetLength(0) - 1;
							for (Cnt = 0; Cnt <= tempForEndVar; Cnt++)
							{
								//Check for ICS_Item Code
								if (SystemProcedure2.IsItEmpty(aProductAssemblyDetails.GetValue(Cnt, gccProductCodeColumn), SystemVariables.DataType.StringType))
								{
									MessageBox.Show("Invalid component Item code", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
									grdAssemblyDetails.Col = gccProductCodeColumn;
									grdAssemblyDetails.Bookmark = Cnt;
									//grdAssemblyDetails.SetFocus
									throw new Exception();
								}


								//'''Commented by hakim
								//'''On 22nd jan 2005
								//                If IsItEmpty(aProductAssemblyDetails(cnt, gccQtyColumn), NumberType) Then
								//                    MsgBox "Enter component qty", vbInformation
								//                    grdAssemblyDetails.Col = gccQtyColumn
								//                    grdAssemblyDetails.Bookmark = cnt
								//                    GoTo eFoundError
								//                End If

							}
						}
						else
						{
							//''            MsgBox "Enter assembly Item components information", vbInformation
							//''            CheckDataValidity = False
							//''            FirstFocusObject.SetFocus
							//''            GoTo eFoundError
						}
					}
					else
					{
						MessageBox.Show("Enter assembly Item components information", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
						result = false;
						FirstFocusObject.Focus();
						throw new Exception();
					}
				}
				//UPGRADE_ISSUE: (2068) Nothing object was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2068
				if (!(rsMasterInfo is UpgradeStubs.Nothing))
				{
				}
				rsMasterInfo = null;
				return true;
			}
			catch
			{

				result = false;
				//Call ErrorHandlingRoutine(Err.Number, Err.Description, Me.Name, "GetRecord")
			}
			return result;
		}

		public void FindRoutine(string pObjectName)
		{
			object mTempSearchValue = null;
			string mFilterCondition = "";

			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{

				if ((pObjectName.IndexOf('#') + 1) == 0)
				{
					return;
				}

				string mObjectName = pObjectName.Substring(0, Math.Min(pObjectName.IndexOf('#'), pObjectName.Length));
				int mObjectIndex = Convert.ToInt32(Double.Parse(pObjectName.Substring(pObjectName.IndexOf('#') + 1)));
				if (mObjectName == "txtCommon")
				{
					txtCommon[mObjectIndex].Text = "";
					switch(mObjectIndex)
					{
						case ctBaseUnitIndex : case ctReportUnitIndex : 
							//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
							mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(2005000, "54")); 
							break;
						case ctGroupCodeIndex : 
							//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
							mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(2002000, "40")); 
							break;
						case ctCategoryCodeIndex : 
							//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
							mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(2003000, "47")); 
							break;
						case ctPrefferedSupplierCodeIndex : 
							//mFilterCondition = " ( ldgr_type = '" & Left(gGLCustomerVendorTypeCode, 4) & "'" 
							//mFilterCondition = mFilterCondition & " or ldgr_type = '" & Left(gGLCustomerVendorTypeCode, 4) & "'" & ")" 
							mFilterCondition = " ( type_cd =" + SystemGLConstants.gGLCustomerVendorTypeCode.ToString() + " )"; 
							//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
							mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(1001000, "2", mFilterCondition)); 
							break;
						default:
							return;
					}
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (!Convert.IsDBNull(mTempSearchValue))
					{
						//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtCommon[mObjectIndex].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(1));
						txtCommon_Leave(txtCommon[mObjectIndex], new EventArgs());
					}
					ShowHideMasterDetails();
				}

				if (mObjectName == "txtFlex")
				{
					txtFlex[mObjectIndex].Text = "";
					//Select Case mObjectIndex
					//    Case ctFlex1Index
					mFilterCondition = " ( svs.vs_code =" + mObjectIndex.ToString() + " and svs.vs_object_type ='ICS_Item' " + " )";
					//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(2001006, "1940", mFilterCondition));
					//End Select
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (!Convert.IsDBNull(mTempSearchValue))
					{
						//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtFlex[mObjectIndex].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(1));
						txtFlex_Leave(txtFlex[mObjectIndex], new EventArgs());
					}
				}
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}

		}

		public void PrintReport()
		{
			try
			{
				SystemReports.GetSystemReport(51001000, 1);
			}
			catch
			{
			}
		}

		private void GetNextNumber(string pAdditionalWhereClause = "")
		{

			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{
				if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("allow_alpha_numeric_part_no")))
				{
					//txtcommon(ctpartnoindex).text = getnewnumber("ICS_Item", "part_no", 3)
					txtCommon[ctPartNoIndex].Text = SystemProcedure2.GetNewNumber("ICS_Item", "part_no", 3, pAdditionalWhereClause);
				}
				else
				{
					txtCommon[ctPartNoIndex].Text = SystemProcedure2.GetNewNumber("ICS_Item", "part_no", 2, pAdditionalWhereClause);
				}
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		private void ChangeTabPageStatus(int pTabPageIndex, bool pEnabled)
		{

			try
			{
				tabMaster.set_TabEnabled((short) pTabPageIndex, pEnabled);
			}
			catch
			{
			}
		}


		private void grdPriceDetails_AfterColUpdate(Object eventSender, C1.Win.C1TrueDBGrid.ColEventArgs eventArgs)
		{
			int ColIndex = eventArgs.ColIndex;
			object mTempSearchValue = null;
			string mysql = "";
			int mProdCd = 0;
			bool mIsDuplicate = false;

			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{
				grdPriceDetails.UpdateData();

				if (ColIndex == ckPriceListIndex)
				{
					if (!SystemProcedure2.IsItEmpty(grdPriceDetails.Columns[ckPriceListIndex].Value, SystemVariables.DataType.StringType))
					{


						mysql = " select Price_List_L_Name ";
						mysql = mysql + " from ICS_Price_List where Price_List_No = " + ReflectionHelper.GetPrimitiveValue<string>(grdPriceDetails.Columns[ckPriceListIndex].Value);

						//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));

						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
						if (!Convert.IsDBNull(mTempSearchValue))
						{
							grdPriceDetails.Columns[ckPNameNameIndex].Value = mTempSearchValue;
						}
					}
					//grdPriceDetails.Refresh
				}
				else if (ColIndex == ckPNameNameIndex)
				{ 
					if (!SystemProcedure2.IsItEmpty(grdPriceDetails.Columns[ckPNameNameIndex].Value, SystemVariables.DataType.StringType))
					{

						mysql = " select Price_List_No ";
						mysql = mysql + " from ICS_Price_List where Price_List_L_Name = '" + ReflectionHelper.GetPrimitiveValue<string>(grdPriceDetails.Columns[ckPNameNameIndex].Value) + "'";

						//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));

						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
						if (!Convert.IsDBNull(mTempSearchValue))
						{
							grdPriceDetails.Columns[ckPriceListIndex].Value = mTempSearchValue;
						}

					}
					//grdPriceDetails.Refresh
				}
				else if (ColIndex == ckDisAmountIndex || ColIndex == ckAmountIndex)
				{ 
					if (((ReflectionHelper.GetPrimitiveValue<string>(grdPriceDetails.Columns[ckDisAmountIndex].Value) == "") ? 0 : ReflectionHelper.GetPrimitiveValue<decimal>(grdPriceDetails.Columns[ckDisAmountIndex].Value)) > ReflectionHelper.GetPrimitiveValue<decimal>(grdPriceDetails.Columns[ckAmountIndex].Value))
					{
						grdPriceDetails.Columns[ckDisAmountIndex].Value = "";
						grdPriceDetails.Columns[ckDisPercentIndex].Value = "";
						grdPriceDetails.Col = ckDisAmountIndex;
					}
					if (!SystemProcedure2.IsItEmpty(grdPriceDetails.Columns[ckDisAmountIndex].Value, SystemVariables.DataType.NumberType) && !SystemProcedure2.IsItEmpty(grdPriceDetails.Columns[ckAmountIndex].Value, SystemVariables.DataType.NumberType))
					{

						grdPriceDetails.Columns[ckDisPercentIndex].Value = (ReflectionHelper.GetPrimitiveValue<double>(grdPriceDetails.Columns[ckDisAmountIndex].Value) / ((double) ReflectionHelper.GetPrimitiveValue<double>(grdPriceDetails.Columns[ckAmountIndex].Value))) * 100;
					}
					else
					{
						grdPriceDetails.Columns[ckDisPercentIndex].Value = "";
					}
				}
				else if (ColIndex == ckDisPercentIndex)
				{ 
					if (ReflectionHelper.GetPrimitiveValue<double>(grdPriceDetails.Columns[ckDisPercentIndex].Value) > 100)
					{
						grdPriceDetails.Columns[ckDisPercentIndex].Value = "";
						grdPriceDetails.Columns[ckDisAmountIndex].Value = "";
						grdPriceDetails.Col = ckDisPercentIndex;
					}
					if (!SystemProcedure2.IsItEmpty(grdPriceDetails.Columns[ckDisPercentIndex].Value, SystemVariables.DataType.NumberType) && !SystemProcedure2.IsItEmpty(grdPriceDetails.Columns[ckAmountIndex].Value, SystemVariables.DataType.NumberType))
					{

						grdPriceDetails.Columns[ckDisAmountIndex].Value = (ReflectionHelper.GetPrimitiveValue<double>(grdPriceDetails.Columns[ckDisPercentIndex].Value) / 100d) * ReflectionHelper.GetPrimitiveValue<double>(grdPriceDetails.Columns[ckAmountIndex].Value);
					}
				}
				grdPriceDetails.Refresh();
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}


		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBGrid Event grdPriceDetails.FormatText was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void grdPriceDetails_FormatText(int ColIndex, ref object Value, object Bookmark)
		{
			//--handle Null value error ---> when there is no ICS_Item in the
			//--system & the drop-down ICS_Item list combo is click
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{

				switch(ColIndex)
				{
					case ckDisPercentIndex : 
						if (Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(Value)) != 0)
						{
							if (Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(Value)) - Math.Floor(Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(Value))) > 0)
							{
								Value = StringsHelper.Format(Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(Value)), "###,###,###,##0.0##");
							}
							else
							{
								Value = StringsHelper.Format(Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(Value)), "###,###,###,##0");
							}
						}
						else
						{
							Value = "";
						} 
						break;
					case ckAmountIndex : case ckDisAmountIndex : 
						if (Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(Value)) != 0)
						{
							Value = StringsHelper.Format(Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(Value)), "###,###,###,###,##0.000");
						}
						else
						{
							Value = "";
						} 
						 
						break;
				}
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		private void grdPriceDetails_GotFocus(Object eventSender, EventArgs eventArgs)
		{

			try
			{
				string mysql = "";

				if (!mPricingDetailsTabClicked)
				{
					SystemGrid.DefineSystemGridCombo(cmbPriceList);
					RefreshgrdPriceDetails();
					//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBGrid method grdPriceDetails.PostMsg was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					grdPriceDetails.PostMsg(1);

				}
				else
				{
					SystemGrid.DefineSystemGridCombo(cmbPriceList);
					RefreshgrdPriceDetails();
				}
			}
			catch (System.Exception excep)
			{
				MessageBox.Show(excep.Message, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
			}

		}

		private void grdBarcodeDetails_GotFocus(Object eventSender, EventArgs eventArgs)
		{

			try
			{
				string mysql = "";

				if (!mBarcodeDetailsTabClicked)
				{
					SystemGrid.DefineSystemGridCombo(cmbBarcodeList);
					RefreshgrdBarcodeDetails();
					//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBGrid method grdBarcodeDetails.PostMsg was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					grdBarcodeDetails.PostMsg(1);

				}
				else
				{
					SystemGrid.DefineSystemGridCombo(cmbBarcodeList);
					RefreshgrdBarcodeDetails();
				}
			}
			catch (System.Exception excep)
			{
				MessageBox.Show(excep.Message, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
			}

		}

		private void grdActivityDetails_GotFocus(Object eventSender, EventArgs eventArgs)
		{

			try
			{
				string mysql = "";

				if (!mActivityDetailsTabClicked)
				{
					SystemGrid.DefineSystemGridCombo(cmbActivityList);
					RefreshgrdActivityDetails();
					//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBGrid method grdActivityDetails.PostMsg was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					grdActivityDetails.PostMsg(1);

				}
				else
				{
					SystemGrid.DefineSystemGridCombo(cmbActivityList);
					RefreshgrdActivityDetails();
				}
			}
			catch (System.Exception excep)
			{
				MessageBox.Show(excep.Message, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
			}

		}

		private void grdPriceDetails_RowColChange(object eventSender, C1.Win.C1TrueDBGrid.RowColChangeEventArgs eventArgs)
		{
			int LastRow = eventArgs.LastRow;
			int LastCol = eventArgs.LastCol;

			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{
				int Cnt = 0;

				try
				{

					RefreshgrdPriceDetails();
					grdAssemblyDetails.UpdateData();
					return;
				}
				catch (System.Exception excep)
				{

					MessageBox.Show(excep.Message, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
				}
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBGrid Event grdProductLevelDetails.PostEvent was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void grdProductLevelDetails_PostEvent(int MsgId)
		{

			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{

				if (mLastCol == grdProductLevelDetails.Col && mLastRow == grdProductLevelDetails.Row)
				{
					return;
				}

				int Col = grdProductLevelDetails.Col;
				if (Col == cslIncludeInLocationColumn)
				{
					//.Columns(Col).Value = Not .Columns(Col).Value
					//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
					if (((TriState) ReflectionHelper.GetPrimitiveValue<int>(grdProductLevelDetails.Columns[Col].Value)) == TriState.True)
					{
						grdProductLevelDetails.Columns[Col].Value = TriState.False;
					}
					else
					{
						grdProductLevelDetails.Columns[Col].Value = TriState.True;
					}
					grdProductLevelDetails.UpdateData();
					grdProductLevelDetails.Refresh();

				}
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		private void grdProductLevelDetails_MouseUp(Object eventSender, MouseEventArgs eventArgs)
		{
			int Button = (eventArgs.Button == MouseButtons.Left) ? 1 : ((eventArgs.Button == MouseButtons.Right) ? 2 : 4);
			int Shift = ((int) Control.ModifierKeys) / 65536;
			float x = eventArgs.X * 15;
			float y = eventArgs.Y * 15;

			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{
				if (grdProductLevelDetails.PointAt(x, y) == C1.Win.C1TrueDBGrid.PointAtEnum.AtDataArea)
				{
					mLastCol = grdProductLevelDetails.Col;
					mLastRow = grdProductLevelDetails.Row;
					//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBGrid method grdProductLevelDetails.PostMsg was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					grdProductLevelDetails.PostMsg(1);
				}
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		//Private Sub grdProductLevelDetails_FetchCellStyle(ByVal Condition As Integer, ByVal Split As Integer, Bookmark As Variant, ByVal Col As Integer, ByVal CellStyle As TrueOleDBGrid80.StyleDisp)
		//
		//If Col = cslIncludeInLocationColumn Then
		//        If aProductStockLevels(Val(Bookmark), Col) = vbTrue Then
		//            Set CellStyle.ForegroundPicture = frmSysMain.imlSystemIcons.ListImages.Item("imgChecked2").Picture
		//        Else
		//            Set CellStyle.ForegroundPicture = frmSysMain.imlSystemIcons.ListImages.Item("imgUnchecked").Picture
		//        End If
		//        CellStyle.ForegroundPicturePosition = dbgFPPictureOnly
		//End If
		//End Sub

		private void grdProductLevelDetails_KeyPress(Object eventSender, KeyPressEventArgs eventArgs)
		{
			int KeyAscii = Convert.ToInt32(eventArgs.KeyChar);
			try
			{

				//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
				try
				{
					int Col = grdProductLevelDetails.Col;
					if (Col == cslIncludeInLocationColumn)
					{
						if (KeyAscii == 32)
						{
							KeyAscii = 0;
							//.Columns(Col).Value = Not .Columns(Col).Value
							//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
							if (((TriState) ReflectionHelper.GetPrimitiveValue<int>(grdProductLevelDetails.Columns[Col].Value)) == TriState.True)
							{
								grdProductLevelDetails.Columns[Col].Value = TriState.False;
							}
							else
							{
								grdProductLevelDetails.Columns[Col].Value = TriState.True;
							}
							grdProductLevelDetails.UpdateData();
							grdProductLevelDetails.Refresh();
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
				catch (Exception exc)
				{
					NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
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

		private void grdSupplierDetails_AfterColUpdate(Object eventSender, C1.Win.C1TrueDBGrid.ColEventArgs eventArgs)
		{
			int ColIndex = eventArgs.ColIndex;
			object mTempSearchValue = null;
			string mysql = "";
			int mProdCd = 0;
			bool mIsDuplicate = false;

			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{
				grdSupplierDetails.UpdateData();

				if (ColIndex == ckLdgrIndex)
				{
					if (!SystemProcedure2.IsItEmpty(grdSupplierDetails.Columns[ckLdgrIndex].Value, SystemVariables.DataType.StringType))
					{


						mysql = " select L_Ldgr_Name ";
						mysql = mysql + " from GL_Ledger where Ldgr_No = " + ReflectionHelper.GetPrimitiveValue<string>(grdSupplierDetails.Columns[ckLdgrIndex].Value);

						//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));

						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
						if (!Convert.IsDBNull(mTempSearchValue))
						{
							grdSupplierDetails.Columns[ckSupplierNameIndex].Value = mTempSearchValue;
						}
					}
					grdSupplierDetails.Refresh();
				}
				else if (ColIndex == ckSupplierNameIndex)
				{ 
					if (!SystemProcedure2.IsItEmpty(grdSupplierDetails.Columns[ckSupplierNameIndex].Value, SystemVariables.DataType.StringType))
					{

						mysql = " select Ldgr_No ";
						mysql = mysql + " from GL_Ledger where L_Ldgr_Name = '" + ReflectionHelper.GetPrimitiveValue<string>(grdSupplierDetails.Columns[ckSupplierNameIndex].Value) + "'";

						//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));

						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
						if (!Convert.IsDBNull(mTempSearchValue))
						{
							grdSupplierDetails.Columns[ckLdgrIndex].Value = mTempSearchValue;
						}
					}
					grdSupplierDetails.Refresh();
				}
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}

		}


		private void imgPicture_Click(Object eventSender, EventArgs eventArgs)
		{

			try
			{

				//UPGRADE_ISSUE: (2064) MSComDlg.CommonDialog property CommonDialog1.InitDir was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				CommonDialog1Open.InitialDirectory = SystemVariables.gProductPicturesPath;
				//UPGRADE_ISSUE: (2064) MSComDlg.CommonDialog property CommonDialog1.filter was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				//UPGRADE_WARNING: (2081) Filter has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				CommonDialog1Open.Filter = "BMP - JPG (*.bmp,*.jpg)|*.bmp; *.jpg";

				// Set the default files type to Word Documents
				//CommonDialog1.FilterIndex = 1


				//UPGRADE_ISSUE: (2064) MSComDlg.CommonDialog property CommonDialog1.Filename was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				CommonDialog1Open.FileName = "";
				CommonDialog1Open.ShowDialog();
				//UPGRADE_ISSUE: (2064) MSComDlg.CommonDialog property CommonDialog1.Filename was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				if (CommonDialog1Open.FileName == "")
				{
					return;
				}
				//UPGRADE_ISSUE: (2064) MSComDlg.CommonDialog property CommonDialog1.FileTitle was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				//UPGRADE_WARNING: (2074) CommonDialog property CommonDialog1.FileTitle was upgraded to CommonDialog1.FileName which has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2074
				txtCommon[ctPictureFileNameIndex].Text = Path.GetFileName(CommonDialog1Open.FileName);
				//UPGRADE_ISSUE: (2064) MSComDlg.CommonDialog property CommonDialog1.Filename was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				txtCommon[ctNewPictureName].Text = CommonDialog1Open.FileName;

				SetProductPicture(1);
			}
			catch (System.Exception excep)
			{

				MessageBox.Show(excep.Message, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
			}

		}

		private void tabMaster_ClickEvent(Object eventSender, EventArgs eventArgs)
		{
			try
			{

				switch(tabMaster.CurrTab)
				{
					case mBasicMasterDetails : 
						ShowBasicMasterDetailsTab(); 
						mBasicMasterDetailsTabClicked = true; 
						break;
					case mAssemblyDetails : 
						ShowAssemblyDetailsTab(); 
						mAssemblyDetailsTabClicked = true; 
						break;
					case mPricingDetails : 
						ShowPricingDetailsTab(); 
						mPricingDetailsTabClicked = true; 
						break;
					case mOtherMasterDetails : 
						ShowOtherMasterDetailsTab(); 
						mOtherMasterDetailsTabClicked = true; 
						break;
					case mStockLevelDetails : 
						ShowStockLevelDetailsTab(); 
						mStockLevelDetailsTabClicked = true; 
						break;
					case mSupplierDetails : 
						mSupplierDetailsTabClicked = true; 
						ShowSupplierDetailsTab(); 
						break;
					case mBarcodeDetails : 
						ShowBarcodeDetailsTab(); 
						mBarcodeDetailsTabClicked = true; 
						break;
					case mActivityDetails : 
						ShowActivityDetailsTab(); 
						mActivityDetailsTabClicked = true; 
						 
						break;
				}
			}
			catch (System.Exception excep)
			{

				MessageBox.Show(excep.Message, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
				FirstFocusObject.Focus();
			}
		}

		bool mFirstTime_ShowHideMasterDetails = false;
		private void ShowHideMasterDetails()
		{
			bool ShowSetting = false;
			string mysql = "";

			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{
				if (!mFirstTime_ShowHideMasterDetails)
				{
					mFirstTime_ShowHideMasterDetails = true;

					//UPGRADE_WARNING: (1068) GetSystemPreferenceSetting() of type Variant is being forced to bool. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					ShowSetting = ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("multiple_unit"));
					lblCommon[clBaseUnitIndex].Visible = ShowSetting;
					txtCommon[ctBaseUnitIndex].Visible = ShowSetting;
					txtCommonDisplay[ctlBaseUnitNameIndex].Visible = ShowSetting;
					cmdCommon[cbAlterUnitDetailsIndex].Visible = ShowSetting;
					txtCommon[ctPartNoIndex].Enabled = true;

					//---------------------Reporting Unit-------Moiz Hakimi------------18-Jan-2010--------
					lblCommon[clReportUnitIndex].Visible = ShowSetting;
					txtCommon[ctReportUnitIndex].Visible = ShowSetting;
					txtCommonDisplay[ctlReportUnitNameIndex].Visible = ShowSetting;
					//------------------------------------------------------------------------------------
					//    '''Disable the Base Unit and alt ICS_Unit option in POS.
					//    If GetSystemPreferenceSetting("offline_data_management") = True And GetSystemPreferenceSetting("Is_Head_Office") = False Then
					//        txtCommon(ctBaseUnitIndex).Enabled = False
					//        cmdCommon(cbAlterUnitDetailsIndex).Enabled = False
					//    Else
					//        txtCommon(ctBaseUnitIndex).Enabled = True
					//        cmdCommon(cbAlterUnitDetailsIndex).Enabled = True
					//    End If
					cmdCommon[cbGroupDetailsIndex].Visible = ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("show_product_code_generate_for_groups"));
					cmdCommon[cbCategoryDetailsIndex].Visible = ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("show_product_code_generate_for_category"));

					//UPGRADE_WARNING: (1068) GetSystemPreferenceSetting() of type Variant is being forced to bool. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					ShowSetting = ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("Item_Group"));
					lblCommon[clGroupNameIndex].Visible = ShowSetting;
					txtCommon[ctGroupCodeIndex].Visible = ShowSetting;
					txtCommonDisplay[ctlGroupNameIndex].Visible = ShowSetting;
					cmdCommon[cbGroupDetailsIndex].Visible = ShowSetting;

					//UPGRADE_WARNING: (1068) GetSystemPreferenceSetting() of type Variant is being forced to bool. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					ShowSetting = ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("Item_Category"));
					lblCommon[clCategoryNameIndex].Visible = ShowSetting;
					txtCommon[ctCategoryCodeIndex].Visible = ShowSetting;
					txtCommonDisplay[ctlCategoryNameIndex].Visible = ShowSetting;
					cmdCommon[cbCategoryDetailsIndex].Visible = ShowSetting;

					//UPGRADE_WARNING: (1068) GetSystemPreferenceSetting() of type Variant is being forced to bool. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					ShowSetting = ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("multiple_product_types"));
					lblCommon[clProductTypeIndex].Visible = ShowSetting;
					cmbCommon[ccProductTypesIndex].Visible = ShowSetting;

					//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
					if (((TriState) ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetSystemPreferenceSetting("assembly_product"))) == TriState.True)
					{
						tabMaster.set_TabVisible(Convert.ToInt16(mAssemblyDetails), TriState.True != TriState.False);

						chkCommon[ckPrintVoucherOnComponentsIndex].Visible = ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("show_print_component_on_voucher_in_product"));
					}
					else
					{
						tabMaster.set_TabVisible(Convert.ToInt16(mAssemblyDetails), TriState.False != TriState.False);
						tabMaster.TabsPerPage = (short) (tabMaster.TabsPerPage - 1);
					}

					//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
					if (((TriState) ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetSystemPreferenceSetting("show_flex_details_tab_in_product"))) == TriState.True)
					{
						tabMaster.set_TabVisible(Convert.ToInt16(mFlexDetails), TriState.True != TriState.False);
					}
					else
					{
						tabMaster.set_TabVisible(Convert.ToInt16(mFlexDetails), TriState.False != TriState.False);
						tabMaster.TabsPerPage = (short) (tabMaster.TabsPerPage - 1);
					}

					//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
					if (((TriState) ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetSystemPreferenceSetting("show_pricing_details_tab_in_product"))) == TriState.True)
					{
						tabMaster.set_TabVisible(Convert.ToInt16(mPricingDetails), TriState.True != TriState.False);
						//**--set show/hide setting for ICS_Item price levels options
						//fraProductInformation(cfDivisionWiseSalesRatesIndex).Visible = GetSystemPreferenceSetting("division_wise_sales_rates")
						//fraProductInformation(cfDivisionWisePurchaseRatesIndex).Visible = GetSystemPreferenceSetting("division_wise_purchase_rates")

						//**--set show/hide setting for sales / purchase commission options
						//UPGRADE_WARNING: (1068) GetSystemPreferenceSetting() of type Variant is being forced to bool. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						ShowSetting = ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("Show_Commision_On_Sales_In_Product"));
						txtCommonNumber[cnCommissionOnSalesIndex].Visible = ShowSetting;
						lblCommon[clCommisionOnSalesIndex].Visible = ShowSetting;
						//UPGRADE_WARNING: (1068) GetSystemPreferenceSetting() of type Variant is being forced to bool. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						ShowSetting = ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("Show_Commision_On_Purchase_In_Product"));
						txtCommonNumber[cnCommissionOnPurchaseIndex].Visible = ShowSetting;
						lblCommon[clCommisionOnPurchaseIndex].Visible = ShowSetting;
						//**--set show/hide setting for promotional ICS_Item options
						chkCommon[ckPromotionalItemIndex].Visible = ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("promotional_items"));
					}
					else
					{
						tabMaster.set_TabVisible(Convert.ToInt16(mPricingDetails), TriState.False != TriState.False);
						tabMaster.TabsPerPage = (short) (tabMaster.TabsPerPage - 1);
					}

					//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
					if (((TriState) ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetSystemPreferenceSetting("show_Activity_Types_tab_in_Item"))) == TriState.True)
					{
						tabMaster.set_TabVisible(Convert.ToInt16(mActivityDetails), TriState.True != TriState.False);
					}
					else
					{
						tabMaster.set_TabVisible(Convert.ToInt16(mActivityDetails), TriState.False != TriState.False);
						tabMaster.TabsPerPage = (short) (tabMaster.TabsPerPage - 1);
					}

					//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
					if (((TriState) ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetSystemPreferenceSetting("show_other_details_tab_in_product"))) == TriState.True)
					{
						tabMaster.set_TabVisible(Convert.ToInt16(mOtherMasterDetails), TriState.True != TriState.False);
						fraProductInformation[cfSupplierInformationIndex].Visible = ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("show_supplier_info_in_product"));
						frmPackageInfo.Visible = ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("show_package_date_on_item_master"));
						txtExpDate.Value = SystemVariables.gCurrentDate;
						txtPackDate.Value = SystemVariables.gCurrentDate;

						//UPGRADE_WARNING: (1068) GetSystemPreferenceSetting() of type Variant is being forced to bool. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						ShowSetting = ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("enable_warranty_period_in_product"));
						lblCommon[clWarrantyPeriodIndex].Visible = ShowSetting;
						txtCommonNumber[cnWarrantyPeriodIndex].Visible = ShowSetting;

					}
					else
					{
						tabMaster.set_TabVisible(Convert.ToInt16(mOtherMasterDetails), TriState.False != TriState.False);
						tabMaster.TabsPerPage = (short) (tabMaster.TabsPerPage - 1);
					}

					if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("show_Supplier_details_tab_in_product")))
					{
						tabMaster.set_TabVisible(Convert.ToInt16(mSupplierDetails), TriState.True != TriState.False);
					}
					else
					{
						tabMaster.set_TabVisible(Convert.ToInt16(mSupplierDetails), TriState.False != TriState.False);
						tabMaster.TabsPerPage = (short) (tabMaster.TabsPerPage - 1);
					}

					if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("maintain_stock_levels")))
					{
						tabMaster.set_TabVisible(Convert.ToInt16(mStockLevelDetails), TriState.True != TriState.False);
					}
					else
					{
						tabMaster.set_TabVisible(Convert.ToInt16(mStockLevelDetails), TriState.False != TriState.False);
						tabMaster.TabsPerPage = (short) (tabMaster.TabsPerPage - 1);
					}

					if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("barcode")))
					{
						tabMaster.set_TabVisible(Convert.ToInt16(mBarcodeDetails), TriState.True != TriState.False);
					}
					else
					{
						tabMaster.set_TabVisible(Convert.ToInt16(mBarcodeDetails), TriState.False != TriState.False);
						tabMaster.TabsPerPage = (short) (tabMaster.TabsPerPage - 1);
					}

					//**--fill ICS_Item types combobox
					mysql = "select ";
					if (SystemVariables.gPreferedLanguage == SystemVariables.Language.English)
					{
						mysql = mysql + " item_type_name ";
					}
					else
					{
						mysql = mysql + " a_item_type_name ";
					}
					mysql = mysql + " , item_type_cd ";
					mysql = mysql + " from ICS_Item_Types it ";
					mysql = mysql + " inner join SM_Preferences sf ";
					mysql = mysql + " on it.feature_id = sf.preference_id ";
					mysql = mysql + " where it.show = 1 ";
					mysql = mysql + " and sf.preference_value = '1' ";

					SystemCombo.FillComboWithItemData(cmbCommon[ccProductTypesIndex], mysql);
					cmbCommon[ccProductTypesIndex].ListIndex = 0;
					//**--fill ICS_Item costing methods combobox
					SystemCombo.FillComboWithSystemObjects(cmbCommon[ccCostingMethodIndex], 1016, false);

					mysql = " select * from ICS_Item_Types where show=1";
					rsItemType = new DataSet();
					//UPGRADE_ISSUE: (2064) ADODB.CursorLocationEnum property CursorLocationEnum.adUseClient was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsItemType.CursorLocation was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					rsItemType.setCursorLocation(UpgradeStubs.ADODB_CursorLocationEnum.getadUseClient());
					SqlDataAdapter adap = new SqlDataAdapter(mysql, SystemVariables.gConn);
					rsItemType.Tables.Clear();
					adap.Fill(rsItemType);
					//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsItemType.ActiveConnection was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					rsItemType.setActiveConnection(null);
				}


				ShowSetting = CurrentFormMode != SystemVariables.SystemFormModes.frmAddMode;
				lblCommon[clTotalNoOfTransactionIndex].Visible = ShowSetting;


				int mProductTypeID = cmbCommon[ccProductTypesIndex].GetItemData(cmbCommon[ccProductTypesIndex].ListIndex);
				int mCostingMethodID = cmbCommon[ccCostingMethodIndex].GetItemData(cmbCommon[ccCostingMethodIndex].ListIndex);

				if (mProductTypeID == SystemICSConstants.ptAssemblyBuildTypeID || mProductTypeID == SystemICSConstants.ptAssemblyGroupTypeID)
				{
					ChangeTabPageStatus(mAssemblyDetails, true);
				}
				else
				{
					ChangeTabPageStatus(mAssemblyDetails, false);
				}

				//''commented by Moiz Hakimion 29-may-2010.
				if (mProductTypeID == SystemICSConstants.ptInventoryTypeID || mProductTypeID == SystemICSConstants.ptAssemblyBuildTypeID || mProductTypeID == SystemICSConstants.ptAssemblyGroupTypeID)
				{
					//If mProductTypeID = ptInventoryTypeID Or mProductTypeID = ptAssemblyBuildTypeID Then
					ShowSetting = true;
				}
				else
				{
					ShowSetting = false;
				}
				chkCommon[ckSerializedIndex].Visible = ShowSetting && ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("serialized_product"));

				chkCommon[ckSerializedIndex].Enabled = CurrentFormMode == SystemVariables.SystemFormModes.frmAddMode;

				//If ShowSetting = True And GetSystemPreferenceSetting("multiple_costing_method") = True Then
				//    lblCommon(clCostingMethodIndex).Visible = True
				//    cmbCommon(ccCostingMethodIndex).Visible = True
				//Else
				//    lblCommon(clCostingMethodIndex).Visible = False
				//    cmbCommon(ccCostingMethodIndex).Visible = False
				//End If

				fraProductInformation[cfPictureInformationIndex].Visible = ShowSetting && ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("product_picture"));


				//**--disable ICS_Item cost.. make it display only field for the time being
				txtCommonNumber[cnProductCostIndex].Enabled = false;
				txtCommonNumber[cnProductCostIndex].BackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(SystemConstants.gDisableColumnBackColor)));

				//UPGRADE_ISSUE: (2064) ADODB.Recordset method rsItemType.MoveFirst was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				rsItemType.MoveFirst();
				rsItemType.Find("item_type_cd =" + mProductTypeID.ToString());

				if (rsItemType.Tables[0].Rows.Count != 0)
				{
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
					if (((TriState) Convert.ToInt32(rsItemType.Tables[0].Rows[0]["allow_define_manual_cost"])) == TriState.True)
					{
						txtCommonNumber[cnProductCostIndex].Enabled = true;
						txtCommonNumber[cnProductCostIndex].BackColor = Color.White;
						ShowSetting = true;
					}
					else
					{
						ShowSetting = CurrentFormMode == SystemVariables.SystemFormModes.frmEditMode;
					}
				}
				else
				{
					ShowSetting = CurrentFormMode == SystemVariables.SystemFormModes.frmEditMode;
				}

				if (ShowSetting)
				{
					ShowSetting = SystemVariables.gEnableUserLevelCostDetails;
				}

				lblCommon[clProductCostIndex].Visible = ShowSetting;
				txtCommonNumber[cnProductCostIndex].Visible = ShowSetting;
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		private void txtCommon_DropButtonClick(Object Sender, EventArgs e)
		{
			int Index = Array.IndexOf(this.txtCommon, Sender);

			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{
				if (Index == ctPartNoIndex)
				{
					GetNextNumber();
					txtCommon[ctPartNoIndex].Focus();
				}
				else
				{
					FindRoutine("txtCommon#" + Index.ToString().Trim());
				}
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}

		}

		private void txtCommon_Leave(Object eventSender, EventArgs eventArgs)
		{
			int Index = Array.IndexOf(this.txtCommon, eventSender);

			object mTempValue = null;

			string mysql = "";

			int mLinkedTextBoxIndex = 0;

			try
			{


				switch(Index)
				{
					case ctPartNoIndex : 
						 
						if (mCurrentFormMode == SystemVariables.SystemFormModes.frmAddMode)
						{
							mysql = "select part_no from ICS_Item where part_no='" + txtCommon[Index].Text + "'";
							//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));

							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
							if (!Convert.IsDBNull(mTempValue))
							{
								txtCommonDisplay[ctPartNoIndex].Text = "";
								txtCommon[Index].Tag = "";
								MessageBox.Show("Part No already exists", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
								txtCommon[Index].Focus();
								return;

							}
							else
							{
								return;
							}
						}
						else
						{
							return;
						} 

					case ctBaseUnitIndex : 
						mysql = "select l_unit_name, a_unit_name, unit_cd from ICS_Unit where unit_no=" + txtCommon[Index].Text; 
						mLinkedTextBoxIndex = ctlBaseUnitNameIndex; 
						 
						break;
					case ctReportUnitIndex : 
						mysql = "select l_unit_name, a_unit_name, unit_cd from ICS_Unit where unit_no=" + txtCommon[Index].Text; 
						mLinkedTextBoxIndex = ctlReportUnitNameIndex; 
						 
						break;
					case ctGroupCodeIndex : 
						mysql = "select l_group_name, a_group_name, group_cd from ICS_Item_group where show = 1 and group_no=" + txtCommon[Index].Text; 
						mLinkedTextBoxIndex = ctlGroupNameIndex; 
						 
						break;
					case ctCategoryCodeIndex : 
						mysql = "select l_cat_name, a_cat_name, cat_cd from ICS_Item_category where show = 1 and cat_no=" + txtCommon[Index].Text; 
						mLinkedTextBoxIndex = ctlCategoryNameIndex; 
						 
						break;
					case ctPrefferedSupplierCodeIndex : 
						mysql = "select l_ldgr_name, a_ldgr_name, ldgr_cd from gl_ledger where show = 1 and ldgr_no='" + txtCommon[Index].Text + "'"; 
						mysql = mysql + " and gl_ledger.type_cd =" + SystemGLConstants.gGLCustomerVendorTypeCode.ToString(); 
						 
						//mySql = mySql & " and ( ldgr_type = '" & Left(gGLCustomerVendorTypeCode, 4) & "'" 
						//mySql = mySql & " or ldgr_type = '" & Left(gGLCustomerVendorTypeCode, 4) & "'" & ")" 
						 
						mLinkedTextBoxIndex = ctlPrefferedSupplierNameIndex; 
						 
						break;
					case ctEnglishProductName : 
						 
						if (CurrentFormMode == SystemVariables.SystemFormModes.frmAddMode)
						{
							if (SystemProcedure2.IsItEmpty(txtProdDesc.Text, SystemVariables.DataType.StringType))
							{
								txtProdDesc.Text = txtCommon[ctEnglishProductName].Text;
							}
						} 
						 
						return; 

					case ctPictureFileNameIndex : 
						SetProductPicture(); 
						 
						return; 

					default:
						 
						return; 

				}

				if (!SystemProcedure2.IsItEmpty(txtCommon[Index].Text, SystemVariables.DataType.StringType))
				{
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));

					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (Convert.IsDBNull(mTempValue))
					{
						txtCommonDisplay[mLinkedTextBoxIndex].Text = "";
						txtCommon[Index].Tag = "";
						throw new System.Exception("-9990002");
					}
					else
					{
						if (Index == ctBaseUnitIndex && txtCommon[ctReportUnitIndex].Text == "")
						{
							txtCommon[ctReportUnitIndex].Text = txtCommon[Index].Text;
							txtCommon_Leave(txtCommon[ctReportUnitIndex], new EventArgs());
						}

						txtCommonDisplay[mLinkedTextBoxIndex].Text = ReflectionHelper.GetPrimitiveValue<string>((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? ((Array) mTempValue).GetValue(0) : ((Array) mTempValue).GetValue(1));
						txtCommon[Index].Tag = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(2));
					}

				}
				else
				{
					txtCommonDisplay[mLinkedTextBoxIndex].Text = "";
					txtCommon[Index].Tag = "";
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

					//if the code is not found
					//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
					try
					{

						txtCommon[Index].Focus();
					}
					catch (Exception exc)
					{
						NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
					}
				}
				else
				{
					//
				}
			}

		}

		private void AssignGridLineNumbers()
		{

			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{
				int Cnt = 0;

				int tempForEndVar = aProductAssemblyDetails.GetLength(0) - 1;
				for (Cnt = 0; Cnt <= tempForEndVar; Cnt++)
				{
					aProductAssemblyDetails.SetValue(Cnt + 1, Cnt, gccLineNoColumn);
				}
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		private void grdAssemblyDetails_AfterColUpdate(Object eventSender, C1.Win.C1TrueDBGrid.ColEventArgs eventArgs)
		{
			int ColIndex = eventArgs.ColIndex;

			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{
				grdAssemblyDetails.UpdateData();

				if ((((ColIndex == gccQtyColumn || ColIndex == SystemICSConstants.grdRateColumn || ColIndex == SystemICSConstants.grdDiscountAmountColumn) ? -1 : 0) | SystemICSConstants.grdProductAmountColumn) != 0)
				{
					CalculateTotals(ReflectionHelper.GetPrimitiveValue<int>(grdAssemblyDetails.Bookmark), ColIndex);
					grdAssemblyDetails.Refresh();
				}
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBGrid Event grdAssemblyDetails.FormatText was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void grdAssemblyDetails_FormatText(int ColIndex, ref object Value, object Bookmark)
		{
			//--handle Null value error ---> when there is no ICS_Item in the
			//--system & the drop-down ICS_Item list combo is click
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{

				switch(ColIndex)
				{
					case gccQtyColumn : case gccMinQtyColumn : case gccMaxQtyColumn : 
						if (Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(Value)) != 0)
						{
							if (Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(Value)) - Math.Floor(Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(Value))) > 0)
							{
								Value = StringsHelper.Format(Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(Value)), "###,###,###,##0.0##");
							}
							else
							{
								Value = StringsHelper.Format(Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(Value)), "###,###,###,##0");
							}
						}
						else
						{
							Value = "";
						} 
						break;
					case gccSalesRateColumn : case gccTotalColumn : 
						if (Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(Value)) != 0)
						{
							Value = StringsHelper.Format(Conversion.Val(ReflectionHelper.GetPrimitiveValue<string>(Value)), "###,###,###,###,##0.000");
						}
						else
						{
							Value = "";
						} 
						 
						break;
				}
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		private void grdAssemblyDetails_GotFocus(Object eventSender, EventArgs eventArgs)
		{
			//''''*************************************************************************
			//''''On the First focus of the grid
			//''''Define the Combo, Refresh the recordset, and generate the line no.
			//''''The first focus of the grid is maintained by the variable mFirstGridFocus
			//''''*************************************************************************

			try
			{
				string mysql = "";

				if (!mAssemblyDetailsTabClicked)
				{
					SystemGrid.DefineSystemGridCombo(cmbMastersList);
					RefreshRecordset();
					//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBGrid method grdAssemblyDetails.PostMsg was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					grdAssemblyDetails.PostMsg(1);

					grdAssemblyDetails_OnAddNew(grdAssemblyDetails, new EventArgs());
					//Else
					//    Call RefreshRecordset
				}
			}
			catch (System.Exception excep)
			{
				MessageBox.Show(excep.Message, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
			}

		}

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBGrid Event grdAssemblyDetails.OnAddNew was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void grdAssemblyDetails_OnAddNew()
		{

			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{
				if (mAssemblyDetailsTabClicked)
				{
					grdAssemblyDetails.Columns[gccLineNoColumn].Text = (grdAssemblyDetails.RowCount + 1).ToString();
				}
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBGrid Event grdAssemblyDetails.PostEvent was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void grdAssemblyDetails_PostEvent(int MsgId)
		{

			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{
				if (MsgId == 1)
				{
					//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
					if (grdAssemblyDetails.Splits[0].DisplayColumns[gccProductCodeColumn].Visible)
					{
						grdAssemblyDetails.Col = gccProductCodeColumn;
					}
					else if (grdAssemblyDetails.Splits[0].DisplayColumns[gccProductNameColumn].Visible)
					{ 
						grdAssemblyDetails.Col = gccProductNameColumn;
					}
					//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbMastersList.DataSource was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					cmbMastersList.setDataSource((msdatasrc.DataSource) rsProductCodeList);
				}
				else if (MsgId == 2)
				{ 
					grdAssemblyDetails.Col = gccQtyColumn;
				}
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		private void grdAssemblyDetails_RowColChange(object eventSender, C1.Win.C1TrueDBGrid.RowColChangeEventArgs eventArgs)
		{
			int LastRow = eventArgs.LastRow;
			int LastCol = eventArgs.LastCol;
			int Cnt = 0;

			try
			{

				cmbMastersList_DataSourceChanged(cmbMastersList, new EventArgs());
				grdAssemblyDetails.UpdateData();
			}
			catch (System.Exception excep)
			{

				MessageBox.Show(excep.Message, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
			}
		}

		private void CalculateTotals(int mRowNumber, int mColNumber)
		{
			int Cnt = 0;

			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{
				double mTotalQty = 0;
				double mTotalMinQty = 0;
				double mTotalMaxQty = 0;
				double mSalesRate = 0;
				double mTotal = 0;


				if (mColNumber == gccQtyColumn || mColNumber == gccSalesRateColumn)
				{
					if (Conversion.Val(Convert.ToString(aProductAssemblyDetails.GetValue(mRowNumber, gccQtyColumn))) != 0 && Conversion.Val(Convert.ToString(aProductAssemblyDetails.GetValue(mRowNumber, gccSalesRateColumn))) != 0)
					{
						aProductAssemblyDetails.SetValue(Conversion.Val(Convert.ToString(aProductAssemblyDetails.GetValue(mRowNumber, gccQtyColumn))) * Conversion.Val(Convert.ToString(aProductAssemblyDetails.GetValue(mRowNumber, gccSalesRateColumn))), mRowNumber, gccTotalColumn);
					}
					else
					{
						aProductAssemblyDetails.SetValue(0, mRowNumber, gccTotalColumn);
					}
				}

				int tempForEndVar = aProductAssemblyDetails.GetLength(0) - 1;
				for (Cnt = 0; Cnt <= tempForEndVar; Cnt++)
				{
					mTotalQty += Conversion.Val(Convert.ToString(aProductAssemblyDetails.GetValue(Cnt, gccQtyColumn)));
					mTotalMinQty += Conversion.Val(Convert.ToString(aProductAssemblyDetails.GetValue(Cnt, gccMinQtyColumn)));
					mTotalMaxQty += Conversion.Val(Convert.ToString(aProductAssemblyDetails.GetValue(Cnt, gccMaxQtyColumn)));
					mSalesRate += Conversion.Val(Convert.ToString(aProductAssemblyDetails.GetValue(Cnt, gccSalesRateColumn)));
					mTotal += Conversion.Val(Convert.ToString(aProductAssemblyDetails.GetValue(Cnt, gccTotalColumn)));
				}

				if (mTotalQty != 0)
				{
					if (mTotalQty - Math.Floor(mTotalQty) > 0)
					{
						grdAssemblyDetails.Columns[gccQtyColumn].FooterText = StringsHelper.Format(mTotalQty, "###,###,###,##0.0##");
					}
					else
					{
						grdAssemblyDetails.Columns[gccQtyColumn].FooterText = StringsHelper.Format(mTotalQty, "###,###,###,##0");
					}
				}
				else
				{
					grdAssemblyDetails.Columns[gccQtyColumn].FooterText = "";
				}

				if (mTotalMinQty != 0)
				{
					if (mTotalMinQty - Math.Floor(mTotalMinQty) > 0)
					{
						grdAssemblyDetails.Columns[gccMinQtyColumn].FooterText = StringsHelper.Format(mTotalMinQty, "###,###,###,##0.0##");
					}
					else
					{
						grdAssemblyDetails.Columns[gccMinQtyColumn].FooterText = StringsHelper.Format(mTotalMinQty, "###,###,###,##0");
					}
				}
				else
				{
					grdAssemblyDetails.Columns[gccMinQtyColumn].FooterText = "";
				}

				if (mTotalMaxQty != 0)
				{
					if (mTotalMaxQty - Math.Floor(mTotalMaxQty) > 0)
					{
						grdAssemblyDetails.Columns[gccMaxQtyColumn].FooterText = StringsHelper.Format(mTotalMaxQty, "###,###,###,##0.0##");
					}
					else
					{
						grdAssemblyDetails.Columns[gccMaxQtyColumn].FooterText = StringsHelper.Format(mTotalMaxQty, "###,###,###,##0");
					}
				}
				else
				{
					grdAssemblyDetails.Columns[gccMaxQtyColumn].FooterText = "";
				}

				if (mSalesRate != 0)
				{
					grdAssemblyDetails.Columns[gccSalesRateColumn].FooterText = StringsHelper.Format(mSalesRate, "###,###,##0.000");
				}
				else
				{
					grdAssemblyDetails.Columns[gccSalesRateColumn].FooterText = "";
				}

				if (mTotal != 0)
				{
					grdAssemblyDetails.Columns[gccTotalColumn].FooterText = StringsHelper.Format(mTotal, "###,###,##0.000");
				}
				else
				{
					grdAssemblyDetails.Columns[gccTotalColumn].FooterText = "";
				}
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}

		}

		private void RefreshRecordset(bool pCallComboRowChange = true)
		{
			string mysql = "";

			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{
				//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				if (grdAssemblyDetails.Splits[0].DisplayColumns[gccProductCodeColumn].Visible || grdAssemblyDetails.Splits[0].DisplayColumns[gccProductNameColumn].Visible)
				{
					if (!mAssemblyDetailsTabClicked)
					{
						mysql = "select part_no, ";
						mysql = mysql + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_prod_name as prod_name" : "a_prod_name as prod_name");
						mysql = mysql + " , ICS_Unit.symbol, ";
						mysql = mysql + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_group_name" : "a_group_name") + " as group_name, ";
						mysql = mysql + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_cat_name" : "a_cat_name") + " as cat_name ";
						mysql = mysql + " , ICS_Item.cost ";
						mysql = mysql + " from ICS_Item ";
						mysql = mysql + " inner join ICS_Unit on ICS_Item.base_unit_cd = ICS_Unit.unit_cd ";
						mysql = mysql + " inner join ICS_Item_group on ICS_Item_group.group_cd = ICS_Item.group_cd ";
						mysql = mysql + " inner join ICS_Item_category on ICS_Item_category.cat_cd = ICS_Item.cat_cd ";
						mysql = mysql + " where ";

						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						if (Convert.ToDouble(rsItemType.Tables[0].Rows[0]["item_type_cd"]) == SystemICSConstants.ptAssemblyBuildTypeID)
						{
							mysql = mysql + " ICS_Item.item_type_cd in (" + SystemICSConstants.ptInventoryTypeID.ToString() + "," + SystemICSConstants.ptServiceTypeID.ToString() + "," + SystemICSConstants.ptAssemblyBuildTypeID.ToString() + ")";
						}
						else
						{
							mysql = mysql + " ICS_Item.item_type_cd = " + SystemICSConstants.ptInventoryTypeID.ToString();
						}
						mysql = mysql + " and ICS_Item.discontinued = 0";

						rsProductCodeList = new DataSet();
						//UPGRADE_ISSUE: (2064) ADODB.CursorLocationEnum property CursorLocationEnum.adUseClient was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsProductCodeList.CursorLocation was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						rsProductCodeList.setCursorLocation(UpgradeStubs.ADODB_CursorLocationEnum.getadUseClient());
						SqlDataAdapter adap = new SqlDataAdapter(mysql, SystemVariables.gConn);
						rsProductCodeList.Tables.Clear();
						adap.Fill(rsProductCodeList);
					}
					else
					{
						//UPGRADE_ISSUE: (2064) ADODB.Recordset method rsProductCodeList.Requery was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						rsProductCodeList.Requery(-1);
						//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
						if (grdAssemblyDetails.Splits[0].DisplayColumns[gccProductCodeColumn].Visible)
						{
							grdAssemblyDetails.Col = gccProductCodeColumn;
						}
						else if (grdAssemblyDetails.Splits[0].DisplayColumns[gccProductNameColumn].Visible)
						{ 
							grdAssemblyDetails.Col = gccProductNameColumn;
						}
						grdAssemblyDetails.Focus();
						//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbMastersList.DataSource was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						cmbMastersList.setDataSource((msdatasrc.DataSource) rsProductCodeList);

						if (pCallComboRowChange)
						{
							cmbMastersList_RowChange(cmbMastersList, new EventArgs());
						}
					}
				}
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBDropDown Event cmbMastersList.DataSourceChanged was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void cmbMastersList_DataSourceChanged()
		{
			int Cnt = 0;

			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{
				cmbMastersList.Width = 0;
				C1.Win.C1TrueDBGrid.C1DisplayColumn withVar = null;
				switch(grdAssemblyDetails.Col)
				{
					case gccProductCodeColumn : case gccProductNameColumn : 
						if (grdAssemblyDetails.Col == gccProductCodeColumn)
						{
							//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbMastersList.ListField was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
							cmbMastersList.setListField("part_no");
							//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsProductCodeList.Sort was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
							rsProductCodeList.setSort("part_no");
						}
						else
						{
							//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbMastersList.ListField was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
							cmbMastersList.setListField("prod_name");
							//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsProductCodeList.Sort was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
							rsProductCodeList.setSort("prod_name");
						} 
						 
						int tempForEndVar = cmbMastersList.Columns.Count - 1; 
						for (Cnt = 0; Cnt <= tempForEndVar; Cnt++)
						{
							//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
							withVar = cmbMastersList.Splits[0].DisplayColumns[Cnt];
							if (Cnt < 5)
							{
								switch(Cnt)
								{
									case 0 : 
										//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.Column property withVar.Order was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064 
										withVar.setOrder((grdAssemblyDetails.Col == gccProductCodeColumn) ? 0 : 1); 
										//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081 
										withVar.Width = grdAssemblyDetails.Splits[0].DisplayColumns[gccProductCodeColumn].Width; 
										withVar.Visible = true; 
										break;
									case 1 : 
										//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.Column property withVar.Order was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064 
										withVar.setOrder((grdAssemblyDetails.Col == gccProductCodeColumn) ? 1 : 0); 
										//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081 
										withVar.Width = grdAssemblyDetails.Splits[0].DisplayColumns[gccProductNameColumn].Width; 
										withVar.Visible = true; 
										break;
									case 2 : 
										//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081 
										withVar.Width = grdAssemblyDetails.Splits[0].DisplayColumns[SystemICSConstants.grdUnitSymbolColumn].Width; 
										withVar.Visible = true; 
										break;
									case 3 : 
										//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077 
										//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021 
										if (((TriState) Convert.ToInt32(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Show_Product_Group_In_List"])) == TriState.True)
										{
											withVar.Width = 120;
											withVar.Visible = true;
										}
										else
										{
											withVar.Width = 0;
											withVar.Visible = false;
										} 
										break;
									case 4 : 
										//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077 
										//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021 
										if (((TriState) Convert.ToInt32(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Show_Product_Category_In_List"])) == TriState.True)
										{
											withVar.Width = 120;
											withVar.Visible = true;
										}
										else
										{
											withVar.Width = 0;
											withVar.Visible = false;
										} 
										break;
								}
								if (SystemVariables.gPreferedLanguage == SystemVariables.Language.English)
								{
									withVar.Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Near;
								}
								else
								{
									withVar.Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far;
								}
								cmbMastersList.Width += withVar.Width / 15;
							}
							else
							{
								withVar.Visible = false;
							}
							withVar.AllowSizing = false;
						} 
						cmbMastersList.Width += 17; 
						cmbMastersList.Height = 167; 
						break;
					default:
						cmbMastersList.Width = 0; 
						break;
				}
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBDropDown Event cmbMastersList.DropDownClose was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void cmbMastersList_DropDownClose()
		{

			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{
				switch(grdAssemblyDetails.Col)
				{
					case gccProductCodeColumn : 
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077 
						if (Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["show_product_name_in_details"]))
						{
							grdAssemblyDetails.Col = gccProductNameColumn;
						} 
						break;
				}
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBDropDown Event cmbMastersList.RowChange was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void cmbMastersList_RowChange()
		{

			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{
				if (grdAssemblyDetails.Col == gccProductCodeColumn || grdAssemblyDetails.Col == gccProductNameColumn)
				{
					if (grdAssemblyDetails.Col == gccProductCodeColumn)
					{
						grdAssemblyDetails.Columns[gccProductNameColumn].Value = cmbMastersList.Columns[cccProductNameColumn].Value;
					}
					else
					{
						grdAssemblyDetails.Columns[gccProductCodeColumn].Value = cmbMastersList.Columns[cccProductCodeColumn].Value;
					}
					grdAssemblyDetails.Columns[gccBaseUnitCodeColumn].Value = cmbMastersList.Columns[cccBaseUnitCodeColumn].Value;
					grdAssemblyDetails.Columns[gccCostColumn].Value = StringsHelper.Format(cmbMastersList.Columns[cccCostColumn].Value, "###,###,##0.000");
				}
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		private void SetPriceLevelLabelCaptions()
		{

			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{
				int Cnt = 0;

				//UPGRADE_ISSUE: (2064) ADODB.FilterGroupEnum property FilterGroupEnum.adFilterNone was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				SystemVariables.rsSystemObjects.Tables[0].DefaultView.RowFilter = UpgradeStubs.ADODB_FilterGroupEnum.getadFilterNone();
				//UPGRADE_ISSUE: (2064) ADODB.Recordset method rsSystemObjects.MoveFirst was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				SystemVariables.rsSystemObjects.MoveFirst();
				//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsSystemObjects.Sort was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				SystemVariables.rsSystemObjects.setSort("object_id");
				SystemVariables.rsSystemObjects.Tables[0].DefaultView.RowFilter = "group_id = 1014";
				Cnt = clSalesRateLevel1Index;
				foreach (DataRow iteration_row in rsSystemObjects.Tables[0].Rows)
				{
					//**--assuming there will be 5 sales rates
					if (SystemVariables.gPreferedLanguage == SystemVariables.Language.English)
					{
						lblCommon[Cnt].Caption = Convert.ToString(SystemVariables.rsSystemObjects.Tables[0].Rows[0]["l_object_caption"]);
					}
					else
					{
						lblCommon[Cnt].Caption = Convert.ToString(SystemVariables.rsSystemObjects.Tables[0].Rows[0]["a_object_caption"]);
					}
					Cnt++;
				}

				SystemVariables.rsSystemObjects.Tables[0].DefaultView.RowFilter = "group_id = 1015";
				Cnt = clPurchaseRateLevel1Index;
				foreach (DataRow iteration_row_2 in rsSystemObjects.Tables[0].Rows)
				{
					//**--assuming there will be 5 sales rates
					if (SystemVariables.gPreferedLanguage == SystemVariables.Language.English)
					{
						lblCommon[Cnt].Caption = Convert.ToString(SystemVariables.rsSystemObjects.Tables[0].Rows[0]["l_object_caption"]);
					}
					else
					{
						lblCommon[Cnt].Caption = Convert.ToString(SystemVariables.rsSystemObjects.Tables[0].Rows[0]["a_object_caption"]);
					}
					Cnt++;
				}
				//UPGRADE_ISSUE: (2064) ADODB.FilterGroupEnum property FilterGroupEnum.adFilterNone was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				SystemVariables.rsSystemObjects.Tables[0].DefaultView.RowFilter = UpgradeStubs.ADODB_FilterGroupEnum.getadFilterNone();
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		private void ResetAllObjects()
		{

			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{
				//**--allow ICS_Item type & costing method to be changed by default
				cmbCommon[ccProductTypesIndex].Enabled = true;
				cmbCommon[ccCostingMethodIndex].Enabled = true;
				//**----------------------------------------------------------------------------------------------------
				oAltUnitForm = null;
				aProductAssemblyDetails = null;
				aProductStockLevels = null;
				imgPicture.Image = null;
				//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.Columns method grdAssemblyDetails.Columns.Clear was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				grdAssemblyDetails.Columns.Clear();
				//grdProductLevelDetails.Columns.Clear
				mAssemblyDetailsTabClicked = false;
				mStockLevelDetailsTabClicked = false;
				//mPricingDetailsTabClicked=False
				//mOtherMasterDetailsTabClicked = False
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		private void ShowProductQuery()
		{

			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{
				if (!SystemProcedure2.IsItEmpty(grdAssemblyDetails.Columns[gccProductCodeColumn].Text, SystemVariables.DataType.StringType))
				{
					repItemQuery.DefInstance.Show();
					//UPGRADE_WARNING: (2065) Form method repItemQuery.ZOrder has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2065
					repItemQuery.DefInstance.BringToFront();
					repItemQuery.DefInstance.txtPartNo.Text = grdAssemblyDetails.Columns[gccProductCodeColumn].Text;
					repItemQuery.DefInstance.GetProductInfo(grdAssemblyDetails.Columns[gccProductCodeColumn].Text);
				}
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		private void ShowBasicMasterDetailsTab()
		{

			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{
				if (mAttemptToSetFocus)
				{
					if (cmbCommon[ccProductTypesIndex].Visible && cmbCommon[ccProductTypesIndex].Enabled)
					{
						cmbCommon[ccProductTypesIndex].Focus();
					}
					else if (cmbCommon[ccCostingMethodIndex].Visible && cmbCommon[ccCostingMethodIndex].Enabled)
					{ 
						cmbCommon[ccCostingMethodIndex].Focus();
					}
					else if (txtCommon[ctGroupCodeIndex].Visible && txtCommon[ctGroupCodeIndex].Enabled)
					{ 
						txtCommon[ctGroupCodeIndex].Focus();
					}
					else if (txtCommon[ctCategoryCodeIndex].Visible && txtCommon[ctCategoryCodeIndex].Enabled)
					{ 
						txtCommon[ctCategoryCodeIndex].Focus();
					}
					else if (txtCommon[ctBaseUnitIndex].Visible && txtCommon[ctBaseUnitIndex].Enabled)
					{ 
						txtCommon[ctBaseUnitIndex].Focus();
					}
					else
					{
						FirstFocusObject.Focus();
					}
				}
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		private void ShowAssemblyDetailsTab()
		{

			string mysql = "";
			int Cnt = 0;
			SqlDataReader rsLocalRec = null;
			bool mAllowItemAdd = false;
			bool mAllowQtyEdit = false;

			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{
				C1.Win.C1TrueDBGrid.C1DisplayColumn withVar = null;
				C1.Win.C1TrueDBGrid.C1DisplayColumn withVar_2 = null;
				if (!mAssemblyDetailsTabClicked)
				{
					if (CurrentFormMode == SystemVariables.SystemFormModes.frmAddMode)
					{
						SystemGrid.DefineSystemVoucherGrid(grdAssemblyDetails, true, true, true, (0xFFFFFF).ToString(), (0x0).ToString(), true, true, C1.Win.C1TrueDBGrid.MarqueeEnum.FloatingEditor, 1.47f, 1.4f, cGridColor, cGridColor);
					}
					else
					{
						//**--do not allow to add assembly components information in the edit mode
						SystemGrid.DefineSystemVoucherGrid(grdAssemblyDetails, false, true, true, (0xFFFFFF).ToString(), (0x0).ToString(), true, true, C1.Win.C1TrueDBGrid.MarqueeEnum.FloatingEditor, 1.47f, 1.4f, cGridColor, cGridColor);
					}

					if (CurrentFormMode == SystemVariables.SystemFormModes.frmAddMode)
					{
						mAllowItemAdd = true;
						mAllowQtyEdit = true;
					}
					else
					{
						if (cmbCommon[ccProductTypesIndex].GetItemData(cmbCommon[ccProductTypesIndex].ListIndex) == SystemICSConstants.ptAssemblyGroupTypeID)
						{
							//''If Group ICS_Item
							mAllowItemAdd = false;
							mAllowQtyEdit = true;
						}
						else
						{
							mAllowItemAdd = false;
							mAllowQtyEdit = false;
						}
					}

					SystemGrid.DefineSystemVoucherGridColumn(grdAssemblyDetails, "LN", 400, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false);
					SystemGrid.DefineSystemVoucherGridColumn(grdAssemblyDetails, "Product Code", 1500, mAllowItemAdd, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, true, true, "cmbMastersList", false, Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Show_Part_No_In_Details"]));
					SystemGrid.DefineSystemVoucherGridColumn(grdAssemblyDetails, "Product Name", 2000, mAllowItemAdd, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "T o t a l", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, true, true, "cmbMastersList", false, Convert.ToBoolean(SystemVariables.rsVoucherTypes.Tables[0].Rows[0]["Show_Product_Name_In_Details"]));
					SystemGrid.DefineSystemVoucherGridColumn(grdAssemblyDetails, "Unit", 400, false, SystemConstants.gDisableColumnBackColor);
					SystemGrid.DefineSystemVoucherGridColumn(grdAssemblyDetails, "Cost", 800, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false, true, true, "", false, (ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetSystemPreferenceSetting("show_component_sales_price_in_product")) & ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetSystemPreferenceSetting("adjust_sales_rates_of_assembly_group_components"))) != 0, false, false, false, true);
					SystemGrid.DefineSystemVoucherGridColumn(grdAssemblyDetails, "Qty", 800, mAllowQtyEdit, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false, true, true, "", false, true, false, false, true, true, 12);
					SystemGrid.DefineSystemVoucherGridColumn(grdAssemblyDetails, "Min Qty", 800, mAllowQtyEdit, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false, true, true, "", false, ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("minimum_and_maximum_qty_restriction_in_assembly")), false, false, true, true, 12);
					SystemGrid.DefineSystemVoucherGridColumn(grdAssemblyDetails, "Max Qty", 800, mAllowQtyEdit, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false, true, true, "", false, ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("minimum_and_maximum_qty_restriction_in_assembly")), false, false, true, true, 12);
					SystemGrid.DefineSystemVoucherGridColumn(grdAssemblyDetails, "Sale Rate", 800, mAllowQtyEdit, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false, true, true, "", false, (ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetSystemPreferenceSetting("show_component_sales_price_in_product")) & ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetSystemPreferenceSetting("adjust_sales_rates_of_assembly_group_components"))) != 0, false, false, true, true, 12);
					SystemGrid.DefineSystemVoucherGridColumn(grdAssemblyDetails, "Total", 800, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false, true, true, "", false, (ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetSystemPreferenceSetting("show_component_sales_price_in_product")) & ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetSystemPreferenceSetting("adjust_sales_rates_of_assembly_group_components"))) != 0, false, false, true, true, 12);
					SystemGrid.DefineSystemVoucherGridColumn(grdAssemblyDetails, "SR Ratio", 800, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false, true, true, "", false, ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("Show_Sales_Rate_Ratio_In_Assembly_Product")), false, false, true, false, 12);
					SystemGrid.DefineSystemVoucherGridColumn(grdAssemblyDetails, "Adjust Max Rate", 800, mAllowQtyEdit, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false, true, true, "", false, (ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetSystemPreferenceSetting("Show_Component_Max_Rate_Adjustment_In_Product")) & ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetSystemPreferenceSetting("adjust_sales_rates_of_assembly_group_components"))) != 0, false, false, true, false, 12);
					SystemGrid.DefineSystemVoucherGridColumn(grdAssemblyDetails, "Adjust Min Rate", 800, mAllowQtyEdit, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false, true, true, "", false, (ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetSystemPreferenceSetting("Show_Component_Min_Rate_Adjustment_In_Product")) & ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetSystemPreferenceSetting("adjust_sales_rates_of_assembly_group_components"))) != 0, false, false, true, false, 12);
					SystemGrid.DefineSystemVoucherGridColumn(grdAssemblyDetails, "Remarks", 800, mAllowQtyEdit, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, true, false, false, true, false, 50);

					//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
					withVar = grdAssemblyDetails.Splits[0].DisplayColumns[gccAdjustMaxRateColumn];
					withVar.DataColumn.ValueItems.DataColumn.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.CheckBox;
					withVar.Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center;

					//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
					withVar_2 = grdAssemblyDetails.Splits[0].DisplayColumns[gccAdjustMinRateColumn];
					withVar_2.DataColumn.ValueItems.DataColumn.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.CheckBox;
					withVar_2.Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center;

					aProductAssemblyDetails = new XArrayHelper();

					if (CurrentFormMode == SystemVariables.SystemFormModes.frmEditMode)
					{
						if (cmbCommon[ccProductTypesIndex].GetItemData(cmbCommon[ccProductTypesIndex].ListIndex) == SystemICSConstants.ptAssemblyBuildTypeID || cmbCommon[ccProductTypesIndex].GetItemData(cmbCommon[ccProductTypesIndex].ListIndex) == SystemICSConstants.ptAssemblyGroupTypeID)
						{
							mysql = "select part_no, ICS_Item.cost, ";
							mysql = mysql + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_prod_name" : "a_prod_name") + " as prod_name ";
							mysql = mysql + " , symbol  as unit_name ";
							mysql = mysql + " , pad.assembly_base_qty, pad.component_base_qty, pad.component_min_base_qty ";
							mysql = mysql + " , pad.component_max_base_qty, pad.component_ratio_in_percent_in_sales_rate ";
							mysql = mysql + " , pad.Component_Sales_Price , pad.Component_Max_Rate_Adjustment, pad.Component_Min_Rate_Adjustment";
							mysql = mysql + " , pad.comments from ICS_Item_assembly_details pad ";
							mysql = mysql + " inner join ICS_Item on pad.component_prod_cd = ICS_Item.prod_cd ";
							mysql = mysql + " inner join ICS_Unit on ICS_Item.base_unit_cd = ICS_Unit.unit_cd ";
							mysql = mysql + " where pad.assembly_prod_cd = " + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
							mysql = mysql + " order by pad.entry_id ";

							SqlCommand sqlCommand = new SqlCommand(mysql, SystemVariables.gConn);
							rsLocalRec = sqlCommand.ExecuteReader();
							rsLocalRec.Read();
							//Call DefineVoucherArray(aProductAssemblyDetails, mMaxAssemblyArrayCols, 0, True)
							do 
							{
								SystemGrid.DefineVoucherArray(aProductAssemblyDetails, mMaxAssemblyArrayCols, Cnt, false);

								aProductAssemblyDetails.SetValue(rsLocalRec["part_no"], Cnt, gccProductCodeColumn);
								aProductAssemblyDetails.SetValue(rsLocalRec["prod_name"], Cnt, gccProductNameColumn);
								aProductAssemblyDetails.SetValue(rsLocalRec["unit_name"], Cnt, gccBaseUnitCodeColumn);
								aProductAssemblyDetails.SetValue(StringsHelper.Format(rsLocalRec["cost"], "###,###,##0.000"), Cnt, gccCostColumn);
								aProductAssemblyDetails.SetValue(rsLocalRec["component_base_qty"], Cnt, gccQtyColumn);
								aProductAssemblyDetails.SetValue(rsLocalRec["component_min_base_qty"], Cnt, gccMinQtyColumn);
								aProductAssemblyDetails.SetValue(rsLocalRec["component_max_base_qty"], Cnt, gccMaxQtyColumn);
								aProductAssemblyDetails.SetValue(rsLocalRec["component_ratio_in_percent_in_sales_rate"], Cnt, gccSRRatioColumn);
								aProductAssemblyDetails.SetValue(rsLocalRec["comments"], Cnt, gccRemarksColumn);

								if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("show_component_sales_price_in_product")))
								{
									//If GetSystemPreferenceSetting("adjust_sales_rates_of_assembly_group_components") = True Then
									aProductAssemblyDetails.SetValue(rsLocalRec["Component_Sales_Price"], Cnt, gccSalesRateColumn);
									aProductAssemblyDetails.SetValue(Convert.ToDouble(rsLocalRec["Component_Sales_Price"]) * Convert.ToDouble(rsLocalRec["component_base_qty"]), Cnt, gccTotalColumn);
									//End If

									//If GetSystemPreferenceSetting ("Show_Component_Max_Rate_Adjustment_In_Product") = True Then
									aProductAssemblyDetails.SetValue(rsLocalRec["Component_Max_Rate_Adjustment"], Cnt, gccAdjustMaxRateColumn);
									//End If

									//If GetSystemPreferenceSetting ("Show_Component_Min_Rate_Adjustment_In_Product") = True Then
									aProductAssemblyDetails.SetValue(rsLocalRec["Component_min_Rate_Adjustment"], Cnt, gccAdjustMinRateColumn);
									//End If
								}
								Cnt++;
							}
							while(rsLocalRec.Read());
							rsLocalRec.Close();

							CalculateTotals(0, 0);
						}
					}
					else
					{
						SystemGrid.DefineVoucherArray(aProductAssemblyDetails, mMaxAssemblyArrayCols, 0, true);
					}
					//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBGrid property grdAssemblyDetails.Array was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					grdAssemblyDetails.setArray(aProductAssemblyDetails);
					AssignGridLineNumbers();
					grdAssemblyDetails.Rebind(true);
					grdAssemblyDetails_GotFocus(grdAssemblyDetails, new EventArgs());
				}
				if (mAttemptToSetFocus)
				{
					grdAssemblyDetails.Focus();
				}
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		private void ShowPricingDetailsTab()
		{

			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{
				if (txtCommonNumber[cnSalesRateIndex].Visible)
				{
					txtCommonNumber[cnSalesRateIndex].Focus();
				}
				else if (txtCommonNumber[cnPurchaseRateIndex].Visible)
				{ 
					txtCommonNumber[cnPurchaseRateIndex].Focus();
				}

				string mysql = "";
				int Cnt = 0;
				SqlDataReader rsLocalRec = null;

				if (!mPriceTabClick)
				{
					if (mFirstPriceTabClick)
					{

						SystemGrid.DefineSystemVoucherGrid(grdPriceDetails, true, true, true, (0xFFFFFF).ToString(), (0x0).ToString(), true, false, C1.Win.C1TrueDBGrid.MarqueeEnum.FloatingEditor, 1.47f, 1.4f, cGridColor);
						//define voucher grid columns

						SystemGrid.DefineSystemVoucherGridColumn(grdPriceDetails, "Price Code", 900, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, true, true, "cmbPriceList");
						SystemGrid.DefineSystemVoucherGridColumn(grdPriceDetails, "Price Name", 4000, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, true, true, "cmbPriceList");
						SystemGrid.DefineSystemVoucherGridColumn(grdPriceDetails, "Unit", 700, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, true, true, "cmbPriceList");
						SystemGrid.DefineSystemVoucherGridColumn(grdPriceDetails, "Rate", 700, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, true, true, "", false, true, false, false, false, true);
						SystemGrid.DefineSystemVoucherGridColumn(grdPriceDetails, "Discount", 700, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, true, true, "", false, true, false, false, false, true);
						SystemGrid.DefineSystemVoucherGridColumn(grdPriceDetails, "Dis.%", 700, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, true, true, "", false, true, false, false, false, true);
						SystemGrid.DefineSystemVoucherGridColumn(grdPriceDetails, "Comments", 700, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, true, true, "", false, true, false, false, true, false, 50);
						mFirstPriceTabClick = false;
						aProductPriceDetails = new XArrayHelper();
					}
					else
					{
						//UPGRADE_ISSUE: (2064) XArrayDBObject.XArrayDB method aProductPriceDetails.Clear was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						aProductPriceDetails.Clear();
					}

					if (CurrentFormMode == SystemVariables.SystemFormModes.frmEditMode)
					{

						mysql = "select  pld.price_list_cd,pl.price_list_no, pld.unit_cd, pld.price_amt ";
						mysql = mysql + ",pld.price_discount_amt, pld.price_discount_percent, pld.comments, ";
						mysql = mysql + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "pl.price_list_l_name" : "pl.price_list_a_name") + " as price_name, ";
						mysql = mysql + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "u.l_unit_name" : "u.a_unit_name") + " as unit_name, u.symbol ";
						mysql = mysql + " from  ics_price_list_details pld ";
						mysql = mysql + " inner join ics_price_list pl on pld.price_list_cd = pl.price_list_cd ";
						mysql = mysql + " inner join ICS_Unit u on pld.unit_cd = u.unit_cd ";
						mysql = mysql + " where pld.prod_cd = " + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);

						SqlCommand sqlCommand = new SqlCommand(mysql, SystemVariables.gConn);
						rsLocalRec = sqlCommand.ExecuteReader();
						rsLocalRec.Read();

						SystemGrid.DefineVoucherArray(aProductPriceDetails, mMaxPriceDetailArrayCols, -1, true);
						do 
						{
							SystemGrid.DefineVoucherArray(aProductPriceDetails, mMaxPriceDetailArrayCols, Cnt, false);

							//aProductSupplierDetails(cnt, ckSupplierIndex) = .Fields("Entry_Id").Value
							aProductPriceDetails.SetValue(rsLocalRec["Price_List_No"], Cnt, ckPriceListIndex);
							aProductPriceDetails.SetValue(Convert.ToString(rsLocalRec["Price_name"]) + "", Cnt, ckPNameNameIndex);
							aProductPriceDetails.SetValue(rsLocalRec["Symbol"], Cnt, ckUnitIndex);
							aProductPriceDetails.SetValue(rsLocalRec["Price_Amt"], Cnt, ckAmountIndex);
							aProductPriceDetails.SetValue(rsLocalRec["Price_Discount_Amt"], Cnt, ckDisAmountIndex);
							aProductPriceDetails.SetValue(rsLocalRec["Price_Discount_Percent"], Cnt, ckDisPercentIndex);
							aProductPriceDetails.SetValue(Convert.ToString(rsLocalRec["comments"]) + "", Cnt, ckCommentsIndex);

							Cnt++;
						}
						while(rsLocalRec.Read());
						rsLocalRec.Close();
					}
					else
					{
						SystemGrid.DefineVoucherArray(aProductPriceDetails, mMaxPriceDetailArrayCols, -1, true);
					}
					//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBGrid property grdPriceDetails.Array was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					grdPriceDetails.setArray(aProductPriceDetails);
					//Call AssignSupplierGridLineNumbers
					grdPriceDetails.Rebind(true);
					mPriceTabClick = true;
				}
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		private void ShowBarcodeDetailsTab()
		{

			string mysql = "";
			int Cnt = 0;
			SqlDataReader rsLocalRec = null;

			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{
				if (!mBarcodeTabClick)
				{
					if (mFirstBarcodeTabClick)
					{

						SystemGrid.DefineSystemVoucherGrid(grdBarcodeDetails, true, true, true, (0xFFFFFF).ToString(), (0x0).ToString(), true, false, C1.Win.C1TrueDBGrid.MarqueeEnum.FloatingEditor, 1.47f, 1.4f, cGridColor);
						//define voucher grid columns

						SystemGrid.DefineSystemVoucherGridColumn(grdBarcodeDetails, "Unit", 1700, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, true, true, "cmbBarcodeList");
						SystemGrid.DefineSystemVoucherGridColumn(grdBarcodeDetails, "Barcode", 2500, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, true, true, "", false, true, false, false, false, true);

						mFirstBarcodeTabClick = false;
						aProductBarcodeDetails = new XArrayHelper();
					}
					else
					{
						//UPGRADE_ISSUE: (2064) XArrayDBObject.XArrayDB method aProductBarcodeDetails.Clear was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						aProductBarcodeDetails.Clear();
					}

					if (CurrentFormMode == SystemVariables.SystemFormModes.frmEditMode)
					{

						mysql = "select u.unit_cd, pbd.Barcode, ";
						mysql = mysql + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "u.l_unit_name" : "u.a_unit_name") + " as unit_name, u.symbol ";
						mysql = mysql + " from  ICS_Item_Barcode_Details pbd ";
						mysql = mysql + " inner join ICS_Item_Unit_Details iud on pbd.Unit_Entry_Id = iud.Unit_Entry_Id ";
						mysql = mysql + " inner join ICS_Unit u on iud.Alt_Unit_Cd = u.unit_cd ";
						mysql = mysql + " where pbd.prod_cd = " + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);

						SqlCommand sqlCommand = new SqlCommand(mysql, SystemVariables.gConn);
						rsLocalRec = sqlCommand.ExecuteReader();
						rsLocalRec.Read();

						SystemGrid.DefineVoucherArray(aProductBarcodeDetails, mMaxBarcodeDetailArrayCols, -1, true);
						do 
						{
							SystemGrid.DefineVoucherArray(aProductBarcodeDetails, mMaxBarcodeDetailArrayCols, Cnt, false);

							aProductBarcodeDetails.SetValue(rsLocalRec["Symbol"], Cnt, cbUnitIndex);
							aProductBarcodeDetails.SetValue(rsLocalRec["Barcode"], Cnt, cbBarcodeIndex);

							Cnt++;
						}
						while(rsLocalRec.Read());
						rsLocalRec.Close();
					}
					else
					{
						SystemGrid.DefineVoucherArray(aProductBarcodeDetails, mMaxBarcodeDetailArrayCols, -1, true);
					}
					//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBGrid property grdBarcodeDetails.Array was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					grdBarcodeDetails.setArray(aProductBarcodeDetails);
					//Call AssignSupplierGridLineNumbers
					grdBarcodeDetails.Rebind(true);
					mBarcodeTabClick = true;
				}
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		private void ShowActivityDetailsTab()
		{

			string mysql = "";
			int Cnt = 0;
			SqlDataReader rsLocalRec = null;

			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{
				if (!mActivityTabClick)
				{
					if (mFirstActivityTabClick)
					{

						SystemGrid.DefineSystemVoucherGrid(grdActivityDetails, true, true, true, (0xFFFFFF).ToString(), (0x0).ToString(), true, false, C1.Win.C1TrueDBGrid.MarqueeEnum.FloatingEditor, 1.47f, 1.4f, cGridColor);
						//define voucher grid columns

						SystemGrid.DefineSystemVoucherGridColumn(grdActivityDetails, "Code", 1700, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, true, true, "cmbActivityList");
						SystemGrid.DefineSystemVoucherGridColumn(grdActivityDetails, "Activity Name", 2500, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, true, true, "", false, true, false, false, false, true);

						mFirstActivityTabClick = false;
						aProductActivityDetails = new XArrayHelper();
					}
					else
					{
						//UPGRADE_ISSUE: (2064) XArrayDBObject.XArrayDB method aProductActivityDetails.Clear was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						aProductActivityDetails.Clear();
					}

					if (CurrentFormMode == SystemVariables.SystemFormModes.frmEditMode)
					{

						mysql = "select pa.Activity_Type_No, ";
						mysql = mysql + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "pa.L_Type_Name" : "pa.L_Type_Name") + " as Type_Name ";
						mysql = mysql + " from  ICS_Item_Activity_Type_Details iad ";
						mysql = mysql + " inner join PROJ_Project_Activity_Types pa on iad.Activity_Type_Cd = pa.Activity_Type_Cd ";
						mysql = mysql + " where iad.prod_cd = " + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);

						SqlCommand sqlCommand = new SqlCommand(mysql, SystemVariables.gConn);
						rsLocalRec = sqlCommand.ExecuteReader();
						rsLocalRec.Read();

						SystemGrid.DefineVoucherArray(aProductActivityDetails, mMaxActivityDetailArrayCols, -1, true);
						do 
						{
							SystemGrid.DefineVoucherArray(aProductActivityDetails, mMaxActivityDetailArrayCols, Cnt, false);

							aProductActivityDetails.SetValue(rsLocalRec["Activity_Type_No"], Cnt, caActivityCode);
							aProductActivityDetails.SetValue(rsLocalRec["Type_Name"], Cnt, caActivityName);

							Cnt++;
						}
						while(rsLocalRec.Read());
						rsLocalRec.Close();
					}
					else
					{
						SystemGrid.DefineVoucherArray(aProductActivityDetails, mMaxActivityDetailArrayCols, -1, true);
					}
					//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBGrid property grdActivityDetails.Array was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					grdActivityDetails.setArray(aProductActivityDetails);

					grdActivityDetails.Rebind(true);
					mActivityTabClick = true;
				}
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}
		private void ShowOtherMasterDetailsTab()
		{

			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{
				//If mOtherMasterDetailsTabClicked = False Then
				//    '**--set default picture file folder name
				//    txtCommonDisplay(ctlPictureFileFolderIndex).Text = gProductPicturesPath
				//    On Error Resume Next
				//    flbPictureFileNames.Path = gProductPicturesPath
				//    On Error GoTo 0
				//End If
				if (fraProductInformation[cfSupplierInformationIndex].Visible)
				{
					txtCommon[ctPrefferedSupplierCodeIndex].Focus();
					//ElseIf fraProductInformation(cfPictureInformationIndex).Visible = True Then
					//    txtCommon(ctPictureFileNameIndex).SetFocus
				}
				//flbPictureFileNames.Refresh
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		//Private Sub flbPictureFileNames_Click()
		//txtCommon(ctPictureFileNameIndex).Text = flbPictureFileNames.List(flbPictureFileNames.ListIndex)
		//Call SetProductPicture
		//End Sub

		private void SetProductPicture(int typ = 0)
		{
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{
				if (typ == 0)
				{
					imgPicture.Image = Image.FromFile(SystemVariables.gProductPicturesPath + txtCommon[ctPictureFileNameIndex].Text);
				}
				else
				{
					imgPicture.Image = Image.FromFile(txtCommon[ctNewPictureName].Text);
				}
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		private void GetNextPartNoInGroup(string pGroupCode)
		{
			object mGroupCode = null;

			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{
				if (!SystemProcedure2.IsItEmpty(pGroupCode, SystemVariables.DataType.NumberType))
				{
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mGroupCode = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode("select group_cd from ICS_Item_group where group_no = " + pGroupCode));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (!Convert.IsDBNull(mGroupCode))
					{
						if (!SystemProcedure2.IsItEmpty(pGroupCode, SystemVariables.DataType.NumberType))
						{
							GetNextNumber(" group_cd = " + ReflectionHelper.GetPrimitiveValue<string>(mGroupCode));
						}
					}
				}
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		private void GetNextPartNoInCategory(string pCategoryCode)
		{
			object mCategoryCode = null;

			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{
				if (!SystemProcedure2.IsItEmpty(pCategoryCode, SystemVariables.DataType.NumberType))
				{
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mCategoryCode = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode("select cat_cd from ICS_Item_category where cat_no = " + pCategoryCode));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (!Convert.IsDBNull(mCategoryCode))
					{
						if (!SystemProcedure2.IsItEmpty(pCategoryCode, SystemVariables.DataType.NumberType))
						{
							GetNextNumber(" cat_cd = " + ReflectionHelper.GetPrimitiveValue<string>(mCategoryCode));
						}
					}
				}
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		private void ShowStockLevelDetailsTab()
		{
			string mysql = "";
			int Cnt = 0;
			SqlDataReader rsLocalRec = null;

			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{
				if (!mStockLevelDetailsTabClicked)
				{
					SystemGrid.DefineSystemVoucherGrid(grdProductLevelDetails, false, false, true, (0xFFFFFF).ToString(), (0x0).ToString(), true, false, C1.Win.C1TrueDBGrid.MarqueeEnum.FloatingEditor, 2.2f, 1.4f, cGridColor);

					SystemGrid.DefineSystemVoucherGridColumn(grdProductLevelDetails, "Location Code", 1250, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false);
					SystemGrid.DefineSystemVoucherGridColumn(grdProductLevelDetails, "Location Name", 2750, false, SystemConstants.gDisableColumnBackColor, ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false);
					SystemGrid.DefineSystemVoucherGridColumn(grdProductLevelDetails, "Maximum Level", 1000, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far);
					SystemGrid.DefineSystemVoucherGridColumn(grdProductLevelDetails, "Minimum Level", 1000, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far);
					SystemGrid.DefineSystemVoucherGridColumn(grdProductLevelDetails, "Reorder Level", 1000, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far);
					SystemGrid.DefineSystemVoucherGridColumn(grdProductLevelDetails, "Bin", 1000);
					SystemGrid.DefineSystemVoucherGridColumn(grdProductLevelDetails, "Include", 700, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Center, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, true, false, true);
					SystemGrid.DefineSystemVoucherGridColumn(grdProductLevelDetails, "Remarks", 1000, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, true, false, false, true, false, 100);

					grdProductLevelDetails.Columns[cslIncludeInLocationColumn].ValueItems.DataColumn.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.CheckBox;
					aProductStockLevels = new XArrayHelper();

					mysql = "select SM_Location.locat_cd, SM_Location.locat_no, ";
					mysql = mysql + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_locat_name" : "a_locat_name") + " as locat_name ";
					mysql = mysql + " , isnull(pld.maximum_level, 0) as maximum_level ";
					mysql = mysql + " , isnull(pld.minimum_level, 0) as minimum_level ";
					mysql = mysql + " , isnull(pld.reorder_level, 0) as reorder_level ";
					mysql = mysql + " , pld.Bin_Location";

					if (CurrentFormMode == SystemVariables.SystemFormModes.frmAddMode)
					{
						mysql = mysql + " ," + ((ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("Include_Product_in_all_location_by_default"))) ? -1 : 0).ToString() + " as Include_In_location , pld.comments ";
						mysql = mysql + " from SM_Location ";
						mysql = mysql + " left outer join ";
						mysql = mysql + " (select * from ICS_Item_location_details ";
						mysql = mysql + " where prod_cd = 0) ";
					}
					else
					{
						mysql = mysql + " ,pld.Include_In_location , pld.comments ";
						mysql = mysql + " from SM_Location ";
						mysql = mysql + " left outer join ";
						mysql = mysql + " (select * from ICS_Item_location_details ";
						mysql = mysql + " where prod_cd = " + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue) + ") ";
					}
					mysql = mysql + " as pld on SM_Location.locat_cd = pld.locat_cd";

					SqlCommand sqlCommand = new SqlCommand(mysql, SystemVariables.gConn);
					rsLocalRec = sqlCommand.ExecuteReader();
					rsLocalRec.Read();
					SystemGrid.DefineVoucherArray(aProductStockLevels, mMaxStockLevelArrayCols, 0, true);
					do 
					{
						SystemGrid.DefineVoucherArray(aProductStockLevels, mMaxStockLevelArrayCols, Cnt, false);

						aProductStockLevels.SetValue(rsLocalRec["locat_cd"], Cnt, cslLocationCodeColumn);
						aProductStockLevels.SetValue(rsLocalRec["locat_no"], Cnt, cslLocationNoColumn);
						aProductStockLevels.SetValue(Convert.ToString(rsLocalRec["locat_name"]) + "", Cnt, cslLocationNameColumn);
						aProductStockLevels.SetValue(rsLocalRec["maximum_level"], Cnt, cslMaximumQtyColumn);
						aProductStockLevels.SetValue(rsLocalRec["minimum_level"], Cnt, cslMinimumQtyColumn);
						aProductStockLevels.SetValue(rsLocalRec["reorder_level"], Cnt, cslReorderQtyColumn);
						aProductStockLevels.SetValue(Convert.ToString(rsLocalRec["Bin_Location"]) + "", Cnt, cslBinColumn);
						aProductStockLevels.SetValue((Convert.IsDBNull(rsLocalRec["Include_In_location"])) ? ((object) TriState.False) : rsLocalRec["Include_In_location"], Cnt, cslIncludeInLocationColumn);
						aProductStockLevels.SetValue(Convert.ToString(rsLocalRec["comments"]) + "", Cnt, cslRemarksColumn);

						Cnt++;
					}
					while(rsLocalRec.Read());
					rsLocalRec.Close();

					//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBGrid property grdProductLevelDetails.Array was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					grdProductLevelDetails.setArray(aProductStockLevels);
				}
				grdProductLevelDetails.Rebind(true);
				if (mAttemptToSetFocus)
				{
					grdProductLevelDetails.Focus();
				}
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		private void SavePictureObject(int pProdCd)
		{
			byte[] bytBlob = null;
			string strImagePath = "";
			int intNum = 0;

			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{

				string mysql = " select picture, picture_object from ICS_Item ";
				mysql = mysql + " where prod_cd =" + Conversion.Str(pProdCd);
				DataSet rsTempRec = new DataSet();
				SqlDataAdapter adap = new SqlDataAdapter(mysql, SystemVariables.gConn);
				rsTempRec.Tables.Clear();
				adap.Fill(rsTempRec);
				if (rsTempRec.Tables[0].Rows.Count != 0)
				{
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					if (!rsTempRec.Tables[0].Rows[0].IsNull("picture"))
					{
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						strImagePath = SystemVariables.gProductPicturesPath + Convert.ToString(rsTempRec.Tables[0].Rows[0]["picture"]);

						FileSystem.FileOpen(1, strImagePath, OpenMode.Input, OpenAccess.Default, OpenShare.Default, -1);
						//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
						if (Information.Err().Number > 0)
						{
							goto mskip;
						}
						else
						{
							FileSystem.FileClose(1);
						}

						intNum = FileSystem.FreeFile();
						FileSystem.FileOpen(intNum, strImagePath, OpenMode.Binary, OpenAccess.Default, OpenShare.Default, -1);
						bytBlob = new byte[((int) (new FileInfo(strImagePath)).Length) + 1];
						//UPGRADE_WARNING: (2080) Get was upgraded to FileGet and has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2080
						Array TempArray = Array.CreateInstance(bytBlob.GetType().GetElementType(), bytBlob.Length);
						FileSystem.FileGet(intNum, ref TempArray, -1, false, false);
						Array.Copy(TempArray, bytBlob, TempArray.Length);
						FileSystem.FileClose(1);

						if (rsTempRec.Tables[0].Rows.Count != 0)
						{
							//UPGRADE_ISSUE: (2064) ADODB.Field20 method rsTempRec.AppendChunk was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
							UpgradeStubs.ADODB_Field20.AppendChunk(bytBlob);
							//UPGRADE_ISSUE: (2064) ADODB.Recordset method rsTempRec.Update was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
							rsTempRec.Update_Renamed(null, null);
						}
					}

					mskip:;

				}
				rsTempRec = null;
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		private void RecordNavidate(int pKeyCode, int pProdCd)
		{

			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{

				string mysql = " select top 1 prod_cd from ICS_Item ";
				mysql = mysql + " where 1=1 ";
				if (pProdCd > 0 && pKeyCode == 37)
				{
					mysql = mysql + " and prod_cd < " + pProdCd.ToString();
				}
				else if (pProdCd > 0 && pKeyCode == 39)
				{ 
					mysql = mysql + " and prod_cd > " + pProdCd.ToString();
				}

				if (pKeyCode == 37)
				{
					mysql = mysql + " order by prod_cd desc ";
				}
				else if (pKeyCode == 39)
				{ 
					mysql = mysql + " order by prod_cd asc ";
				}

				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				object mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(mReturnValue))
				{
					GetRecord(mReturnValue);
				}
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}

		}

		public void ORoutine()
		{

			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{
				if (!UserAccess.AllowUserDisplay)
				{
					MessageBox.Show(SystemConstants.msg8, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}

				RecordNavidate(39, mRecordNavigateSearchValue);
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}

		}

		public void MRoutine()
		{

			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{
				if (!UserAccess.AllowUserDisplay)
				{
					MessageBox.Show(SystemConstants.msg8, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}

				RecordNavidate(37, mRecordNavigateSearchValue);
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}


		}


		private void txtFlex_DropButtonClick(Object Sender, EventArgs e)
		{
			int Index = Array.IndexOf(this.txtFlex, Sender);

			try
			{
				FindRoutine("txtFlex#" + Index.ToString().Trim());
			}
			catch
			{
			}

		}

		private void txtFlex_Leave(Object eventSender, EventArgs eventArgs)
		{
			int Index = Array.IndexOf(this.txtFlex, eventSender);
			object mTempValue = null;
			string mysql = "";
			int mLinkedFlexBoxIndex = 0;

			try
			{

				//Select Case Index
				//    Case ctBaseUnitIndex
				mysql = "select svsv.vssv_l_name, svsv.vssv_a_name  ";
				mysql = mysql + "  from SM_VS_Static_Value svsv ";
				mysql = mysql + " inner join SM_Value_Set svs on svsv.entry_id = svs.entry_id ";
				mysql = mysql + " where ( svs.vs_code =" + Index.ToString() + " and svs.vs_object_type ='ICS_Item' " + " )";
				mysql = mysql + " and svsv.vssv_code ='" + txtFlex[Index].Text + "'";
				mLinkedFlexBoxIndex = Index;
				//    Case Else
				//        Exit Sub
				//End Select

				if (!SystemProcedure2.IsItEmpty(txtFlex[Index].Text, SystemVariables.DataType.StringType))
				{
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (Convert.IsDBNull(mTempValue))
					{
						txtFlexDisplay[mLinkedFlexBoxIndex].Text = "";
						throw new System.Exception("-9990002");
					}
					else
					{
						txtFlexDisplay[mLinkedFlexBoxIndex].Text = ReflectionHelper.GetPrimitiveValue<string>((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? ((Array) mTempValue).GetValue(0) : ((Array) mTempValue).GetValue(1));
					}
				}
				else
				{
					txtFlexDisplay[mLinkedFlexBoxIndex].Text = "";
				}
			}
			catch (System.Exception excep)
			{


				int mReturnErrorType = 0;
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				mReturnErrorType = SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, excep.Message, this.Name, "FlexLostFocus", SystemConstants.msg10);
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
					//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
					try
					{
						txtFlex[Index].Focus();
					}
					catch (Exception exc)
					{
						NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
					}
				}
				else
				{
					//
				}
			}
		}

		private void ShowSupplierDetailsTab()
		{
			string mysql = "";
			int Cnt = 0;
			SqlDataReader rsLocalRec = null;

			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{
				if (!mSupplierTabClick)
				{
					if (mFirstSupplierTabClick)
					{
						SystemGrid.DefineSystemVoucherGrid(grdSupplierDetails, true, true, true, (0xFFFFFF).ToString(), (0x0).ToString(), true, false, C1.Win.C1TrueDBGrid.MarqueeEnum.FloatingEditor, 1.47f, 1.4f, cGridColor);
						//define voucher grid columns
						//Call DefineSystemVoucherGridColumn(grdSupplierDetails, "LN", 400, False, gDisableColumnBackColor, , , False)
						SystemGrid.DefineSystemVoucherGridColumn(grdSupplierDetails, "Party Code", 1800, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true, true, true, "cmdSupplierList", true);
						SystemGrid.DefineSystemVoucherGridColumn(grdSupplierDetails, "Party Name", 4000, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true, true, true, "cmdSupplierList", true);
						SystemGrid.DefineSystemVoucherGridColumn(grdSupplierDetails, "Part No", 2000, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, true, false, false, true, false, 20);
						SystemGrid.DefineSystemVoucherGridColumn(grdSupplierDetails, "Barcode", 2000, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, true, false, false, true, false, 20);

						aProductSupplierDetails = new XArrayHelper();
					}
					else
					{
						//UPGRADE_ISSUE: (2064) XArrayDBObject.XArrayDB method aProductSupplierDetails.Clear was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						aProductSupplierDetails.Clear();
					}
					if (CurrentFormMode == SystemVariables.SystemFormModes.frmEditMode)
					{

						mysql = "SELECT  PSD.Entry_Id, PSD.Prod_Cd, PSD.Ldgr_Cd, PSD.Supplier_Part_No, PSD.Barcode,lgr.Ldgr_No, ";
						mysql = mysql + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "lgr.L_Ldgr_Name" : "lgr.A_Ldgr_Name") + " as ldgr_name ";
						mysql = mysql + " FROM  ICS_Item_Supplier_Details PSD ";
						mysql = mysql + " INNER JOIN ";
						mysql = mysql + " GL_Ledger lgr ON PSD.Ldgr_Cd = lgr.Ldgr_Cd ";
						mysql = mysql + " where PSD.prod_cd = " + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);

						SqlCommand sqlCommand = new SqlCommand(mysql, SystemVariables.gConn);
						rsLocalRec = sqlCommand.ExecuteReader();
						rsLocalRec.Read();

						SystemGrid.DefineVoucherArray(aProductSupplierDetails, mMaxSupplierDetailArrayCols, -1, true);
						do 
						{
							SystemGrid.DefineVoucherArray(aProductSupplierDetails, mMaxSupplierDetailArrayCols, Cnt, false);

							//aProductSupplierDetails(cnt, ckSupplierIndex) = .Fields("Entry_Id").Value
							aProductSupplierDetails.SetValue(rsLocalRec["Ldgr_No"], Cnt, ckLdgrIndex);
							aProductSupplierDetails.SetValue(Convert.ToString(rsLocalRec["ldgr_name"]) + "", Cnt, ckSupplierNameIndex);
							aProductSupplierDetails.SetValue(rsLocalRec["Supplier_Part_No"], Cnt, ckPartNoIndex);
							aProductSupplierDetails.SetValue(rsLocalRec["Barcode"], Cnt, ckBarcodeIndex);

							Cnt++;
						}
						while(rsLocalRec.Read());
						rsLocalRec.Close();
					}
					else
					{
						SystemGrid.DefineVoucherArray(aProductSupplierDetails, mMaxSupplierDetailArrayCols, -1, true);
					}
					//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBGrid property grdSupplierDetails.Array was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					grdSupplierDetails.setArray(aProductSupplierDetails);
					//Call AssignSupplierGridLineNumbers
					grdSupplierDetails.Rebind(true);
					mSupplierTabClick = true;
				}
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}



		private void grdSupplierDetails_GotFocus(Object eventSender, EventArgs eventArgs)
		{
			//''''*************************************************************************
			//''''On the First focus of the grid
			//''''Define the Combo, Refresh the recordset, and generate the line no.
			//''''The first focus of the grid is maintained by the variable mFirstGridFocus
			//''''*************************************************************************

			try
			{
				string mysql = "";

				if (!mSupplierDetailsTabClicked)
				{
					SystemGrid.DefineSystemGridCombo(cmdSupplierList);
					RefreshgrdSupplierDetails();
					//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBGrid method grdSupplierDetails.PostMsg was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					grdSupplierDetails.PostMsg(1);

				}
				else
				{
					SystemGrid.DefineSystemGridCombo(cmdSupplierList);
					RefreshgrdSupplierDetails();
				}
			}
			catch (System.Exception excep)
			{
				MessageBox.Show(excep.Message, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
			}

		}


		private void RefreshgrdSupplierDetails(bool pCallComboRowChange = true)
		{

			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{

				//If mSupplierDetailsTabClicked = False Then
				string mysql = "select Ldgr_No, ";
				mysql = mysql + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "L_Ldgr_Name" : "A_Ldgr_Name") + " as ldgr_name ";
				mysql = mysql + " from GL_Ledger ";
				mysql = mysql + " where Type_Cd = 3 ";

				rsProductCodeList = new DataSet();
				//UPGRADE_ISSUE: (2064) ADODB.CursorLocationEnum property CursorLocationEnum.adUseClient was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsProductCodeList.CursorLocation was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				rsProductCodeList.setCursorLocation(UpgradeStubs.ADODB_CursorLocationEnum.getadUseClient());
				SqlDataAdapter adap = new SqlDataAdapter(mysql, SystemVariables.gConn);
				rsProductCodeList.Tables.Clear();
				adap.Fill(rsProductCodeList);
				//Else
				//UPGRADE_ISSUE: (2064) ADODB.Recordset method rsProductCodeList.Requery was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				rsProductCodeList.Requery(-1);

				grdSupplierDetails.Focus();
				//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmdSupplierList.DataSource was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				cmdSupplierList.setDataSource((msdatasrc.DataSource) rsProductCodeList);

				if (pCallComboRowChange)
				{
					cmbMastersList_RowChange(cmbMastersList, new EventArgs());
				}
				//End If
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}


		private void RefreshgrdPriceDetails(bool pCallComboRowChange = true)
		{

			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{
				string mysql = "";

				if (grdPriceDetails.Col == ckPriceListIndex || grdPriceDetails.Col == ckPNameNameIndex)
				{
					mysql = "select Price_List_No, ";
					mysql = mysql + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "Price_List_L_Name" : "Price_List_A_Name") + " as Price_name ";
					mysql = mysql + " from ICS_Price_List ";

					rsPriceList = new DataSet();
					//UPGRADE_ISSUE: (2064) ADODB.CursorLocationEnum property CursorLocationEnum.adUseClient was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsPriceList.CursorLocation was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					rsPriceList.setCursorLocation(UpgradeStubs.ADODB_CursorLocationEnum.getadUseClient());
					SqlDataAdapter adap = new SqlDataAdapter(mysql, SystemVariables.gConn);
					rsPriceList.Tables.Clear();
					adap.Fill(rsPriceList);
					//UPGRADE_ISSUE: (2064) ADODB.Recordset method rsPriceList.Requery was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					rsPriceList.Requery(-1);

					grdPriceDetails.Focus();
					//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbPriceList.DataSource was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					cmbPriceList.setDataSource((msdatasrc.DataSource) rsPriceList);
				}
				else if (grdPriceDetails.Col == ckUnitIndex)
				{ 
					mysql = "select Symbol ";
					mysql = mysql + " from ICS_Unit ";

					rsPriceList = new DataSet();
					//UPGRADE_ISSUE: (2064) ADODB.CursorLocationEnum property CursorLocationEnum.adUseClient was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsPriceList.CursorLocation was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					rsPriceList.setCursorLocation(UpgradeStubs.ADODB_CursorLocationEnum.getadUseClient());
					SqlDataAdapter adap_2 = new SqlDataAdapter(mysql, SystemVariables.gConn);
					rsPriceList.Tables.Clear();
					adap_2.Fill(rsPriceList);
					//UPGRADE_ISSUE: (2064) ADODB.Recordset method rsPriceList.Requery was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					rsPriceList.Requery(-1);

					grdPriceDetails.Focus();
					//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbPriceList.DataSource was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					cmbPriceList.setDataSource((msdatasrc.DataSource) rsPriceList);
				}
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}

		}

		private void RefreshgrdBarcodeDetails(bool pCallComboRowChange = true)
		{

			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{
				string mysql = "";

				if (grdBarcodeDetails.Col == cbUnitIndex)
				{
					mysql = "select Symbol ";
					mysql = mysql + " from ICS_Unit ";

					rsBarcodeList = new DataSet();
					//UPGRADE_ISSUE: (2064) ADODB.CursorLocationEnum property CursorLocationEnum.adUseClient was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsBarcodeList.CursorLocation was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					rsBarcodeList.setCursorLocation(UpgradeStubs.ADODB_CursorLocationEnum.getadUseClient());
					SqlDataAdapter adap = new SqlDataAdapter(mysql, SystemVariables.gConn);
					rsBarcodeList.Tables.Clear();
					adap.Fill(rsBarcodeList);
					//UPGRADE_ISSUE: (2064) ADODB.Recordset method rsBarcodeList.Requery was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					rsBarcodeList.Requery(-1);

					grdBarcodeDetails.Focus();
					//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbBarcodeList.DataSource was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					cmbBarcodeList.setDataSource((msdatasrc.DataSource) rsBarcodeList);
				}
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		private void RefreshgrdActivityDetails(bool pCallComboRowChange = true)
		{
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{
				string mysql = "";

				if (grdActivityDetails.Col == caActivityCode || grdActivityDetails.Col == caActivityName)
				{
					mysql = "select Activity_Type_No, ";
					mysql = mysql + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "L_Type_Name" : "A_Type_Name") + " as Type_Name ";
					mysql = mysql + " from PROJ_Project_Activity_Types ";

					rsActivityList = new DataSet();
					//UPGRADE_ISSUE: (2064) ADODB.CursorLocationEnum property CursorLocationEnum.adUseClient was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsActivityList.CursorLocation was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					rsActivityList.setCursorLocation(UpgradeStubs.ADODB_CursorLocationEnum.getadUseClient());
					SqlDataAdapter adap = new SqlDataAdapter(mysql, SystemVariables.gConn);
					rsActivityList.Tables.Clear();
					adap.Fill(rsActivityList);
					//UPGRADE_ISSUE: (2064) ADODB.Recordset method rsActivityList.Requery was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					rsActivityList.Requery(-1);

					grdActivityDetails.Focus();
					//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbActivityList.DataSource was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					cmbActivityList.setDataSource((msdatasrc.DataSource) rsActivityList);
				}
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}

		}

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBDropDown Event cmdSupplierList.DropDownClose was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void cmdSupplierList_DropDownClose()
		{
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{
				//'***************************************************************************''
				//'This routine handles the navigation for next column after a value is selected
				//'from listbox in the grid.
				//'***************************************************************************''
				switch(grdSupplierDetails.Col)
				{
					case ckLdgrIndex : 
						grdSupplierDetails.Col = ckPartNoIndex; 
						break;
					case ckSupplierNameIndex : 
						 
						break;
				}
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}


		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBDropDown Event cmdSupplierList.DataSourceChanged was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void cmdSupplierList_DataSourceChanged()
		{
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{
				int Cnt = 0;

				cmdSupplierList.Width = 0;
				switch(grdSupplierDetails.Col)
				{
					case ckLdgrIndex : 
						//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmdSupplierList.ListField was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064 
						cmdSupplierList.setListField("Ldgr_No"); 
						cmdSupplierList.DisplayColumns[0].Visible = true; 
						//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081 
						cmdSupplierList.Width = grdSupplierDetails.Splits[0].DisplayColumns[ckLdgrIndex].Width + 167; 
						 
						break;
					case ckSupplierNameIndex : 
						//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmdSupplierList.ListField was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064 
						cmdSupplierList.setListField("Ldgr_name"); 
						//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081 
						//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.Column property cmdSupplierList.Columns.Order was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064 
						cmdSupplierList.Splits[0].DisplayColumns[0].setOrder(1); 
						cmdSupplierList.DisplayColumns[1].Width = 200; 
						cmdSupplierList.DisplayColumns[0].Width = 47; 
						//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081 
						cmdSupplierList.Width = grdSupplierDetails.Splits[0].DisplayColumns[ckPartNoIndex].Width + 167; 
						 
						break;
					default:
						cmdSupplierList.Width = 0; 
						break;
				}
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		private void grdSupplierDetails_RowColChange(object eventSender, C1.Win.C1TrueDBGrid.RowColChangeEventArgs eventArgs)
		{
			int LastRow = eventArgs.LastRow;
			int LastCol = eventArgs.LastCol;
			int Cnt = 0;

			try
			{

				RefreshgrdSupplierDetails();
				grdSupplierDetails.UpdateData();
			}
			catch (System.Exception excep)
			{

				MessageBox.Show(excep.Message, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
			}
		}


		private bool IsColumnDuplicate(int Col)
		{
			bool result2 = false;
			int Cnt = 0;
			int Result = 0;
			string SearchText = "";

			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{

				XArrayHelper withVar = null;
				withVar = aProductSupplierDetails;
				int tempForEndVar = aProductSupplierDetails.GetLength(0) - 2;
				for (Cnt = 0; Cnt <= tempForEndVar; Cnt++)
				{
					SearchText = Convert.ToString(aProductSupplierDetails.GetValue(Cnt, Col));
					if (SearchText != "")
					{
						Result = withVar.Find(SearchText, Cnt + 1, Col);
						if (Result > 0)
						{
							grdSupplierDetails.Row = Cnt;
							grdSupplierDetails.Col = Col;
							return true;
						}
					}
				}
				result2 = false;
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
			return result2;
		}


		private bool IsPriceDuplicate(int Col)
		{
			bool result2 = false;
			int Cnt = 0;
			int Result = 0;
			string SearchText = "";
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{

				XArrayHelper withVar = null;
				withVar = aProductPriceDetails;
				int tempForEndVar = aProductPriceDetails.GetLength(0) - 2;
				for (Cnt = 0; Cnt <= tempForEndVar; Cnt++)
				{
					SearchText = Convert.ToString(aProductPriceDetails.GetValue(Cnt, Col));
					if (SearchText != "")
					{
						Result = withVar.Find(SearchText, Cnt + 1, Col);
						if (Result > 0)
						{
							grdPriceDetails.Row = Cnt;
							grdPriceDetails.Col = Col;
							return true;
						}
					}
				}
				result2 = false;
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
			return result2;
		}

		public void LRoutine()
		{
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{

				if (ActiveControl.Name == "grdPriceDetails")
				{
					if (aProductPriceDetails.GetLength(0) > 0)
					{
						grdPriceDetails.Delete();
						grdPriceDetails.Rebind(true);
						grdPriceDetails.Focus();
						grdPriceDetails.Refresh();
					}
				}
				else if (ActiveControl.Name == "grdSupplierDetails")
				{ 
					if (aProductSupplierDetails.GetLength(0) > 0)
					{
						grdSupplierDetails.Delete();
						grdSupplierDetails.Rebind(true);
						grdSupplierDetails.Focus();
						grdSupplierDetails.Refresh();
					}
				}
				else if (ActiveControl.Name == "grdAssemblyDetails")
				{ 
					if (aProductAssemblyDetails.GetLength(0) > 0)
					{
						grdAssemblyDetails.Delete();
						grdAssemblyDetails.Rebind(true);
						grdAssemblyDetails.Focus();
						grdAssemblyDetails.Refresh();
					}
				}
				else if (ActiveControl.Name == "grdBarcodeDetails")
				{ 
					if (aProductBarcodeDetails.GetLength(0) > 0)
					{
						grdBarcodeDetails.Delete();
						grdBarcodeDetails.Rebind(true);
						grdBarcodeDetails.Focus();
						grdBarcodeDetails.Refresh();
					}
				}
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		private void grdActivityDetails_AfterColUpdate(Object eventSender, C1.Win.C1TrueDBGrid.ColEventArgs eventArgs)
		{
			int ColIndex = eventArgs.ColIndex;
			object mTempSearchValue = null;
			string mysql = "";
			int mProdCd = 0;
			bool mIsDuplicate = false;
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{

				grdActivityDetails.UpdateData();

				if (ColIndex == caActivityCode)
				{
					if (!SystemProcedure2.IsItEmpty(grdActivityDetails.Columns[caActivityCode].Value, SystemVariables.DataType.StringType))
					{


						mysql = "select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "L_Type_Name" : "L_Type_Name") + " as Type_Name ";
						mysql = mysql + " from PROJ_Project_Activity_Types where Activity_Type_No = " + ReflectionHelper.GetPrimitiveValue<string>(grdActivityDetails.Columns[caActivityCode].Value);

						//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));

						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
						if (!Convert.IsDBNull(mTempSearchValue))
						{
							grdActivityDetails.Columns[caActivityName].Value = mTempSearchValue;
						}
					}

				}
				else if (ColIndex == caActivityName)
				{ 
					if (!SystemProcedure2.IsItEmpty(grdActivityDetails.Columns[caActivityName].Value, SystemVariables.DataType.StringType))
					{

						mysql = " select Activity_Type_No ";
						mysql = mysql + " from ICS_Price_List where ";
						mysql = mysql + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "L_Type_Name" : "L_Type_Name") + " = '" + ReflectionHelper.GetPrimitiveValue<string>(grdActivityDetails.Columns[caActivityName].Value) + "'";

						//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));

						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
						if (!Convert.IsDBNull(mTempSearchValue))
						{
							grdActivityDetails.Columns[caActivityCode].Value = mTempSearchValue;
						}

					}
				}
				grdActivityDetails.Refresh();
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		private void SavePicture(int itemCode)
		{
			try
			{

				string DestinationFile = "";
				string ext = "";
				string mysql = "";
				object pPartNo = null;
				string SourceFile = "";

				pPartNo = txtCommon[ctPartNoIndex].Text;

				//UPGRADE_ISSUE: (2064) MSComDlg.CommonDialog property CommonDialog1.Filename was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				SourceFile = CommonDialog1Open.FileName;
				//UPGRADE_ISSUE: (2064) MSComDlg.CommonDialog property CommonDialog1.Filename was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				ext = CommonDialog1Open.FileName.Substring(Math.Max(CommonDialog1Open.FileName.Length - (Strings.Len(CommonDialog1Open.FileName) - (CommonDialog1Open.FileName.LastIndexOf(".") + 1)), 0));
				DestinationFile = SystemVariables.gProductPicturesPath + itemCode.ToString() + "." + ext;

				File.Copy(SourceFile, DestinationFile, true);

				mysql = "update ICS_Item set Picture = '" + itemCode.ToString() + "." + ext + "'";
				mysql = mysql + "where prod_cd = " + itemCode.ToString();
				SqlCommand TempCommand = null;
				TempCommand = SystemVariables.gConn.CreateCommand();
				TempCommand.CommandText = mysql;
				TempCommand.ExecuteNonQuery();
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, excep.Message, this.Name, "Save Picture");
			}

		}
	}
}