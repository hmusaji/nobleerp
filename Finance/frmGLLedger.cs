
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using UpgradeHelpers.Gui;



namespace Xtreme
{
	internal partial class frmGLLedger
		: System.Windows.Forms.Form
	{


		private int mThisFormID = 0;
		private object mSearchValue = null;
		private string mTimeStamp = "";
		private SystemVariables.SystemFormModes mCurrentFormMode = (SystemVariables.SystemFormModes) 0; //Enum for checking the current form mode
		private clsAccessAllowed _UserAccess = null;
		public frmGLLedger()
{
InitializeComponent();
} 
 public  void frmGLLedger_old()
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
		private clsToolbar oThisFormToolBar = null;
		public Control FirstFocusObject = null;
		public int FormCallType = 0;

		//Private mOldGroupCode As String
		private string mOldCurrenyCode = "";
		private int mAccountTypeCode = 0;
		private string mNewGroupCode = "";
		private string mNewCurrenyCode = "";
		private string mNewDefaultSalesmanCode = "";
		private string mNewDefaultCostCenterCode = "";
		private string mNewDefaultPaymentModeCode = "";
		private bool mFormIsInitialized = false;

		private bool mBasicMasterDetailsTabClicked = false;
		//Private mOtherMasterDetailsTabClicked As Boolean
		private bool mPricingDetailsTabClicked = false;
		private bool mMasterDefaultsTabClicked = false;
		private bool mCustomerSupportTabClicked = false;

		private bool mPricingDetailsFirstClicked = false;
		private bool mCustomerSupportFirstClicked = false;

		//Private tcBasicMasterDetails As TabControlItem
		//Private tcOtherMasterDetails As TabControlItem
		//Private tcPricingDetails As TabControlItem
		//Private tcMasterDefaults As TabControlItem


		//**--define form level constants
		private const int mBasicMasterDetails = 0;
		//Private Const mOtherMasterDetails As Integer = 1
		private const int mPricingDetails = 1;
		private const int mMasterDefaults = 2;
		private const int mCustomerSupport = 3;

		private const int cfLedgerBalanceIndex = 2;

		private const int clLedgerCodeIndex = 0;
		private const int clLedgerNameEnglishIndex = 1;
		private const int clLedgerNameArabicIndex = 2;
		private const int clLedgerInformationIndex = 3;
		private const int clParentGroupNameIndex = 4;
		private const int clGroupCodeIndex = 5;
		private const int clCurrencyCodeIndex = 7;
		private const int clCreditLimitIndex = 10;
		private const int clCreditDaysIndex = 6;
		private const int clCommentsIndex = 8;
		private const int clTotalNoOfTransactionIndex = 23;
		private const int clMaximumSalesPriceIndex = 25;
		private const int clMinimumSalesPriceIndex = 26;
		private const int clMaximumPurchasePriceIndex = 27;
		private const int clMinimumPurchasePriceIndex = 28;
		private const int clMaximumSalesProductDiscountIndex = 29;
		private const int clMaximumSalesVoucherDiscountIndex = 30;
		private const int clMaximumPurchaseProductDiscountIndex = 31;
		private const int clMaximumPurchaseVoucherDiscountIndex = 32;
		private const int clArabicAddress1Index = 33;
		private const int clArabicAddress2Index = 34;
		private const int clArabicAddress3Index = 35;
		private const int clDefaultSalesman = 36;
		private const int clDefaultCostCenter = 37;
		private const int clDefaultPayMode = 38;
		private const int clAccntTypeCode = 41;

		private const int ctLedgerNoIndex = 0;
		private const int ctLLedgerNameIndex = 1;
		private const int ctALedgerNameIndex = 2;
		private const int ctGroupNoIndex = 3;
		private const int ctCurrencyNoIndex = 4;
		private const int ctEmailAddressIndex = 5;
		private const int ctWebAddressIndex = 6;
		private const int ctContactPersonIndex = 7;
		private const int ctCityIndex = 8;
		private const int ctCountryIndex = 9;
		private const int ctPhoneIndex = 10;
		private const int ctMobileIndex = 11;
		private const int ctFaxIndex = 12;
		private const int ctEnglishAddress1Index = 13;
		private const int ctEnglishAddress2Index = 14;
		private const int ctEnglishAddress3Index = 15;
		private const int ctArabicAddress1Index = 16;
		private const int ctArabicAddress2Index = 17;
		private const int ctArabicAddress3Index = 18;
		private const int ctLicenseNoIndex = 19;
		private const int ctDefaultSalesmanNoIndex = 20;
		private const int ctDefaultCostCenterNoIndex = 21;
		private const int ctDefaultPaymentModeIndex = 22;
		private const int ctAccountTypeCodeIndex = 23;

		private const int ctlGroupNameIndex = 0;
		private const int ctlCurrencyNameIndex = 1;
		private const int ctlOpeningBalanceIndex = 2;
		private const int ctlCurrentBalanceIndex = 3;
		private const int ctlDefaultSalesmanNameIndex = 4;
		private const int ctlDefaultCostCenterNameIndex = 5;
		private const int ctlDefaultPaymentModeNameIndex = 6;
		private const int ctlAccountTypeName = 7;

		private const int ckEnableSalesPriceRestrictionIndex = 0;
		private const int ckEnablePurchasePriceRestrictionIndex = 1;

		private const int ccSalesPriceLevelIndex = 0;
		private const int ccPurchasePriceLevelIndex = 1;
		private const int ccMaximumSalesPriceLevelIndex = 2;
		private const int ccMinimumSalesPriceLevelIndex = 3;
		private const int ccMaximumPurchasePriceLevelIndex = 4;
		private const int ccMinimumPurchasePriceLevelIndex = 5;

		private const int cnMaximumSalesProductDiscountIndex = 0;
		private const int cnMaximumSalesVoucherDiscountIndex = 1;
		private const int cnMaximumPurchaseProductDiscountIndex = 2;
		private const int cnMaximumPurchaseVoucherDiscountIndex = 3;

		private const int cbGroupDetailsIndex = 0;

		private const string mBracketOpener = " (";
		private const string mBracketCloser = ") ";
		private const string mTotalNoOfTransactionText = "Total No of Transactions :";
		private const string mTempLedgerNo = "XXXXXXXXXXXXXXXXXXXX";

		private int mRecordNavigateSearchValue = 0;

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

		private DataSet rsPriceList = null;

		private const int mMaxPriceDetailArrayCols = 3;
		private const int ckVoucherIndex = 0;
		private const int ckVoucherNameIndex = 1;
		private const int ckPriceListIndex = 2;
		private const int ckPNameNameIndex = 3;

		int mPrice_List_Code = 0;
		int mVoucher_No = 0;


		private bool mFirstGridFocus = false;
		private XArrayHelper _aCustomerFeedbackDetails = null;
		private XArrayHelper aCustomerFeedbackDetails
		{
			get
			{
				if (_aCustomerFeedbackDetails is null)
				{
					_aCustomerFeedbackDetails = new XArrayHelper();
				}
				return _aCustomerFeedbackDetails;
			}
			set
			{
				_aCustomerFeedbackDetails = value;
			}
		}

		private const int mMaxCustomerFeedbackArrayCols = 2;
		private const int cfLineNoIndex = 0;
		private const int cfDateIndex = 1;
		private const int cfRemarkIndex = 2;


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




		private void cmdCommon_Click(Object eventSender, EventArgs eventArgs)
		{
			int Index = Array.IndexOf(this.cmdCommon, eventSender);
			if (Index == cbGroupDetailsIndex)
			{
				GetNextLedgerNoInGroup(txtCommon[ctGroupNoIndex].Text);
			}
		}

		private void Form_Activated(Object eventSender, EventArgs eventArgs)
		{
			if (ActivateHelper.myActiveForm != eventSender)
			{
				ActivateHelper.myActiveForm = (Form) eventSender;
				SystemMenu.SetMeCurrentInWindowList(Conversion.Str(this.Handle.ToInt32()));
			}
		}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2080
		private void Form_Load()
		{
			try
			{

				FirstFocusObject = txtCommon[ctLedgerNoIndex];
				this.CurrentFormMode = SystemVariables.SystemFormModes.frmAddMode;
				this.Top = 0;
				this.Left = 0;

				//UPGRADE_ISSUE: (2064) VB method VB.Global was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				//UPGRADE_ISSUE: (2070) Constant App was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2070
				//UPGRADE_ISSUE: (2064) App property App.HelpFile was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				UpgradeStubs.VB.getGlobal().getApp().setHelpFile(Path.GetDirectoryName(Application.ExecutablePath) + "\\help\\Xtreme.chm::/Inventory");
				//**--format & define the new toolbar
				oThisFormToolBar = new clsToolbar();
				oThisFormToolBar.AttachObject(this); //, tcbSystemForm

				oThisFormToolBar.ShowNewButton = true;
				oThisFormToolBar.ShowSaveButton = true;
				oThisFormToolBar.ShowPrintButton = true;

				oThisFormToolBar.BeginFindButtonWithGroup = true;
				oThisFormToolBar.ShowFindButton = true;
				oThisFormToolBar.ShowMoveRecordNextButton = true;
				oThisFormToolBar.ShowMoveRecordPreviousButton = true;

				oThisFormToolBar.ShowHelpButton = true;
				oThisFormToolBar.ShowExitButton = true;
				oThisFormToolBar.BeginExitButtonWithGroup = true;
				oThisFormToolBar.DisableHelpButton = true;

				oThisFormToolBar.BeginDeleteButtonWithGroup = true;
				oThisFormToolBar.ShowDeleteButton = true;
				if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("Sales_Contract")))
				{
					oThisFormToolBar.ShowGLTranButton = true;
					oThisFormToolBar.BeginGLTranButtonWithGroup = true;
				}



				this.WindowState = FormWindowState.Maximized;

				//**--define form options tabs
				//Call DefineFormTabs

				SystemProcedure.SetLabelCaption(this);

				//'''''''''''''''''''''''''''''''''''Procedure for GL Security----------Moiz Hakimi 16-Nov-2008'''''''''''''''''''''''''''''''''''''''''
				if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("enable_Security_on_Ledger")))
				{
					chkUserAccess.Visible = true;
				}
				//''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

				//**--make the form visible before all the control gets loaded
				//**--(this way system pretends to be faster in loading forms)
				this.Show();
				Application.DoEvents();

				cmbDrCrType.AddItem("Dr");
				cmbDrCrType.SetItemData(cmbDrCrType.NewIndex, 0);
				cmbDrCrType.AddItem("Cr");
				cmbDrCrType.SetItemData(cmbDrCrType.NewIndex, 1);
				cmbDrCrType.ListIndex = 0;

				if (FormCallType == 0)
				{
					//    tabMaster.SelectedItem = mBasicMasterDetails
					txtCommon[ctAccountTypeCodeIndex].Focus();
				}
				else
				{
					//    tabMaster.SelectedItem = mOtherMasterDetails
					txtCommon[ctLedgerNoIndex].Focus();
				}

				ShowHideMasterDetails();

				Application.DoEvents();
				//**-------------------------------------------------------------------------------------------

				//check if the ledger no is alpha-numeric or not
				//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				if (((TriState) ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetSystemPreferenceSetting("allow_alpha_numeric_ldgr_no"))) == TriState.True)
				{
					txtCommon[ctLedgerNoIndex].NumericOnly = false;
					txtCommon[ctLedgerNoIndex].AllowDecimal = true;
				}
				else
				{
					txtCommon[ctLedgerNoIndex].NumericOnly = true;
					txtCommon[ctLedgerNoIndex].AllowDecimal = false;
				}


				//--get the next new ledger no
				GetNextNumber();



				//tcFormOptions.SelectedItem = mBasicMasterDetails
				mFormIsInitialized = true;
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
				try
				{

					if (Shift == 2 && (KeyCode == 67 || KeyCode == 86 || KeyCode == 88))
					{
						return;
					}

					if (this.ActiveControl.Name.ToLower() == ("grdCustomerFeedback").ToLower() || this.ActiveControl.Name.ToLower() == ("txtTempDate").ToLower())
					{
						if (Shift == 0)
						{
							if (grdCustomerFeedback.Col == cfDateIndex)
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

					//On Keydown navigate the form by using enter key
					if (KeyCode == 13 && this.ActiveControl.Name != "txtComment" && this.ActiveControl.Name != "txtComment2")
					{ //If enter key pressed send a tab key
						SendKeys.Send("{TAB}");
						return;
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


					if (this.ActiveControl.Name != "txtCommon")
					{
						SystemForms.SystemFormKeyDown(this, ref KeyCode, Shift, this.ActiveControl.Name);
					}
					else
					{
						SystemForms.SystemFormKeyDown(this, ref KeyCode, Shift, "txtCommon#" + ControlArrayHelper.GetControlIndex(this.ActiveControl).ToString().Trim());
					}
				}
				catch
				{
				}
			}
			finally
			{
				eventArgs.Handled = KeyCode == 0;
			}



		}

		private bool isInitializingComponent;
		private void Form_Resize(Object eventSender, EventArgs eventArgs)
		{
			if (isInitializingComponent)
			{
				return;
			}
			int newLargeChange = 0;

			if (Frame2.Height * 15 > this.ClientRectangle.Height * 15)
			{
				HScroll1.Visible = true;
				HScroll1.SetBounds(this.ClientRectangle.Width - 17, 0, 17, this.ClientRectangle.Height);
				HScroll1.Minimum = 0;
				HScroll1.Maximum = (Frame2.Height * 15 - this.ClientRectangle.Height * 15 + HScroll1.LargeChange - 1);
				HScroll1.SmallChange = Convert.ToInt32((HScroll1.Maximum - HScroll1.LargeChange + 1) / 100d);
				newLargeChange = Convert.ToInt32((HScroll1.Maximum - HScroll1.LargeChange + 1) / 10d);
				HScroll1.Maximum = HScroll1.Maximum + newLargeChange - HScroll1.LargeChange;
				HScroll1.LargeChange = newLargeChange;
			}
			else
			{
				HScroll1.Visible = false;
			}

		}

		private void HScroll1_ValueChanged(Object eventSender, EventArgs eventArgs)
		{

			Frame2.Top = Convert.ToInt32(-HScroll1.Value) / 15;
			Application.DoEvents(); // this is not strictly necessary, but smooths the scolling some

		}

		private void Form_Closed(Object eventSender, EventArgs eventArgs)
		{
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{

				SystemMenu.RemoveMeFromWindowList(Conversion.Str(this.Handle.ToInt32()));

				UserAccess = null;
				oThisFormToolBar = null;
				frmGLLedger.DefInstance = null;
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		private void GetNextNumber(string pAdditionalWhereClause = "")
		{
			if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("allow_alpha_numeric_ldgr_no")))
			{
				txtCommon[ctLedgerNoIndex].Text = SystemProcedure2.GetNewNumber("gl_ledger", "ldgr_no", 3);
				//txtCommon(ctLedgerNoIndex).Text = GetNewNumber("gl_ledger", "ldgr_no", 2, pAdditionalWhereClause)
			}
			else
			{
				txtCommon[ctLedgerNoIndex].Text = SystemProcedure2.GetNewNumber("gl_ledger", "ldgr_no", 2, pAdditionalWhereClause);
			}
		}

		public void findRecord()
		{
			object mTempSearchValue = null;

			if (FormCallType == 0)
			{
				//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(1001000));
			}
			else if (FormCallType == 1)
			{ 
				//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(1001000, "", "l.type_cd =" + SystemGLConstants.gGLCustomerVendorTypeCode.ToString()));
			}
			else if (FormCallType == 2)
			{ 
				//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(1001000, "", "l.type_cd =" + SystemGLConstants.gGLCustomerVendorTypeCode.ToString()));
			}

			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(mTempSearchValue))
			{
				Application.DoEvents();
				GetRecord(((Array) mTempSearchValue).GetValue(0));
			}
		}

		public void FindRoutine(string pObjectName)
		{
			object mTempSearchValue = null;

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
					case ctGroupNoIndex : 
						//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
						mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(1002000, "15")); 
						break;
					case ctCurrencyNoIndex : 
						//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
						mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(1003000, "20")); 
						break;
					case ctDefaultCostCenterNoIndex : 
						//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
						mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(1000110, "882")); 
						break;
					case ctDefaultSalesmanNoIndex : 
						//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
						mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(1004000, "88")); 
						break;
					case ctDefaultPaymentModeIndex : 
						//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
						mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(1006000, "966")); 
						break;
					case ctAccountTypeCodeIndex : 
						//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
						mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(1007000, "1606")); 
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
				//Call ShowHideMasterDetails
			}
		}

		public void AddRecord()
		{ //Add a record
			int cnt = 0;
			try
			{

				mCurrentFormMode = SystemVariables.SystemFormModes.frmAddMode; //Change the form mode to addmode
				mSearchValue = ""; //Change the msearchvalue to blank

				int tempForEndVar = txtCommon.GetUpperBound(0);
				for (cnt = txtCommon.GetLowerBound(0); cnt <= tempForEndVar; cnt++)
				{
					txtCommon[cnt].Tag = "";
				}
				SystemProcedure2.ClearTextBox(this);
				SystemProcedure2.ClearNumberBox(this);
				SystemProcedure2.ClearCheckBox(this);
				ResetAllObjects();

				this.chkUserAccess.CheckState = CheckState.Checked;

				GetNextNumber();
				//Call SetLedgerGroupType
				ShowHideMasterDetails();
				tabMaster.SelectedItem = mBasicMasterDetails;

				if (FormCallType == 0)
				{
					//    tabMaster.SelectedItem = mBasicMasterDetails
					txtCommon[ctGroupNoIndex].Focus();
				}
				else
				{
					//    tabMaster.SelectedItem = mOtherMasterDetails
					txtCommon[ctLedgerNoIndex].Focus();
				}

				//FirstFocusObject.SetFocus
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, excep.Message, this.Name, "AddRecord");
			}
		}

		public bool saveRecord()
		{
			bool result = false;
			int cnt = 0;
			string mysql = "";
			clsHourGlass myHourGlass = null;
			object mReturnValue = null;
			int mParentReportGroup = 0;
			int mChildReportGroup = 0;

			try
			{

				myHourGlass = new clsHourGlass();

				SystemVariables.gConn.BeginTransaction();
				if (mCurrentFormMode == SystemVariables.SystemFormModes.frmAddMode)
				{
					//get the next maximum no. for the new group no. eg. x-xx-00002 should become x-xx-00003
					//mNewLedgerCode = Left(mNewGroupCode, 5) + Format(Trim(GetNewNumber("gl_ledger", "ldgr_cd", 1)), "00000")

					InsertLedgerRecord();
				}
				else
				{
					UpdateLedgerRecord();
				}


				//''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
				mysql = " select report_group from gl_accnt_types gat ";
				mysql = mysql + " inner join gl_accnt_group gag on gat.type_cd = gag.ag_type_cd ";
				mysql = mysql + " where gag.group_no ='" + txtCommon[ctGroupNoIndex].Text + "'";
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(mReturnValue))
				{
					//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mParentReportGroup = ReflectionHelper.GetPrimitiveValue<int>(mReturnValue);
				}

				mysql = " select report_group from gl_accnt_types gat ";
				mysql = mysql + " where type_cd= " + txtCommon[ctAccountTypeCodeIndex].Text;
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(mReturnValue))
				{
					//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mChildReportGroup = ReflectionHelper.GetPrimitiveValue<int>(mReturnValue);
				}

				if (mParentReportGroup != mChildReportGroup)
				{
					//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					SystemVariables.gConn.RollbackTrans();
					MessageBox.Show(" Account Group Type of Parent and Child does not match, Record cannot be saved. ", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					txtCommon[ctAccountTypeCodeIndex].Focus();
					return false;
				}
				//''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''


				//''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
				//'''''''Replace the account in ordered sequence in the chart of account
				//'''''''Commented on 10-dec-2013

				//Dim rsTempRec As ADODB.Recordset
				//
				//mysql = " select ldgr_cd"
				//mysql = mysql & " from gl_ledger "
				//mysql = mysql & " where group_cd = ( select group_cd from gl_ledger where ldgr_cd =" & mSearchValue & ")"
				//
				//'''modified by Moiz Hakimi on 17-apr-2010..to reassign the sequence in final reports
				//If GetSystemPreferenceSetting("allow_alpha_numeric_ldgr_no") = False Then
				//    mysql = mysql & " order by group_cd, cast(ldgr_no as bigint) "
				//Else
				//    mysql = mysql & " order by group_cd, ldgr_no "
				//End If
				//
				//Set rsTempRec = New ADODB.Recordset
				//With rsTempRec
				//    .Open mysql, gConn, adOpenForwardOnly, adLockReadOnly
				//    Do While Not .EOF
				//
				//        mysql = "execute glUpdateLedgerReportingSequence " & .Fields("ldgr_cd").Value & ", 0"
				//        gConn.Execute mysql
				//
				//        .MoveNext
				//    Loop
				//    .Close
				//End With
				//Set rsTempRec = Nothing
				//'--------------------------------------------------------------------------------
				//mysql = "execute glUpdateLedgerReportingSequence " & mSearchValue & ", 0"
				//gConn.Execute mysql
				//'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

				if (mCurrentFormMode == SystemVariables.SystemFormModes.frmAddMode)
				{
					mysql = "execute glUpdateLedgerReportingSequence " + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue) + ", 0";
					SqlCommand TempCommand = null;
					TempCommand = SystemVariables.gConn.CreateCommand();
					TempCommand.CommandText = mysql;
					TempCommand.ExecuteNonQuery();
				}


				//'''''''''''''''''''''''''''''''''''Procedure for GL Security----------Moiz Hakimi 16-Nov-2008'''''''''''''''''''''''''''''''''''''''''
				if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("enable_Security_on_Ledger")))
				{
					mysql = "insert into gl_ledger_security ( ";
					mysql = mysql + " ldgr_cd, ";

					mysql = mysql + " group_cd, user_cd)";
					mysql = mysql + "select gl.ldgr_cd, sug.group_cd , " + SystemVariables.gLoggedInUserCode.ToString();
					mysql = mysql + " from gl_ledger gl left outer join gl_ledger_security gls on gl.ldgr_cd = gls.ldgr_cd";
					mysql = mysql + " cross join SM_USER_GROUPS sug ";
					mysql = mysql + " where (gl.ldgr_cd = " + Conversion.Str(SystemProcedure2.GetMasterCode("select ldgr_cd from gl_ledger where ldgr_no = '" + txtCommon[ctLedgerNoIndex].Text + "'")) + ")";
					mysql = mysql + " and (gls.ldgr_cd is null)";
					SqlCommand TempCommand_2 = null;
					TempCommand_2 = SystemVariables.gConn.CreateCommand();
					TempCommand_2.CommandText = mysql;
					TempCommand_2.ExecuteNonQuery();

				}
				//''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

				//'''''''''''''''''''''''''''''''''''Procedure for Price detail save---------Moiz Hakimi 27-Jan-2009'''''''''''''''''''''''''''''''''''''''''
				if (tabMaster.Item(mPricingDetails).Visible && tabMaster.Item(mPricingDetails).Enabled && mPricingDetailsTabClicked)
				{
					//If IsColumnDuplicate(ckVoucherIndex) = True Then
					//    MsgBox "Voucher No. can not be duplicate !!", vbInformation
					//    GoTo eFoundError
					//End If
					this.grdPriceDetails.UpdateData();
					mysql = "delete ics_price_list_assigned_details ";
					mysql = mysql + " where ";
					mysql = mysql + " ldgr_cd = " + Conversion.Str(mSearchValue);
					SqlCommand TempCommand_3 = null;
					TempCommand_3 = SystemVariables.gConn.CreateCommand();
					TempCommand_3.CommandText = mysql;
					TempCommand_3.ExecuteNonQuery();

					int tempForEndVar = aProductPriceDetails.GetLength(0) - 1;
					for (cnt = 0; cnt <= tempForEndVar; cnt++)
					{

						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
						if (Convert.IsDBNull(aProductPriceDetails.GetValue(cnt, ckPriceListIndex)) || Convert.ToString(aProductPriceDetails.GetValue(cnt, ckPriceListIndex)) == "")
						{
							MessageBox.Show("Invalid Price Code", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
							grdPriceDetails.Col = ckPriceListIndex;
							throw new Exception();
						}
						else if (Convert.IsDBNull(aProductPriceDetails.GetValue(cnt, ckVoucherIndex)) || Convert.ToString(aProductPriceDetails.GetValue(cnt, ckVoucherIndex)) == "")
						{ 
							MessageBox.Show("Invalid Voucher No", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
							grdPriceDetails.Col = ckVoucherIndex;
							throw new Exception();
						}
						else
						{

							mysql = "select price_list_cd ";
							mysql = mysql + " from ics_price_list pl";
							mysql = mysql + " where price_list_no ='" + Convert.ToString(aProductPriceDetails.GetValue(cnt, ckPriceListIndex)) + "'";

							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
							if (Convert.IsDBNull(SystemProcedure2.GetMasterCode(mysql)))
							{
								return result;
							}

							//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
							mPrice_List_Code = ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetMasterCode(mysql));

							mVoucher_No = Convert.ToInt32(aProductPriceDetails.GetValue(cnt, ckVoucherIndex));


							mysql = "insert into ICS_Price_List_Assigned_Details ";
							mysql = mysql + " ( Ldgr_Cd, Price_List_Cd, Voucher_Type, user_cd) ";
							mysql = mysql + " values ( ";
							mysql = mysql + Conversion.Str(mSearchValue) + ", ";
							mysql = mysql + Conversion.Str(mPrice_List_Code) + ", ";
							mysql = mysql + Conversion.Str(mVoucher_No) + ", ";
							mysql = mysql + Conversion.Str(SystemVariables.gLoggedInUserCode) + ")";

							SqlCommand TempCommand_4 = null;
							TempCommand_4 = SystemVariables.gConn.CreateCommand();
							TempCommand_4.CommandText = mysql;
							TempCommand_4.ExecuteNonQuery();
						}

					}
				}
				//''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''




				//'''''''''''''''''''''''''''''''''''Procedure for Customer Feedback detail save---------Moiz Hakimi 18-Dec-2013'''''''''''''''''''''''''''''''''''''''''
				if (tabMaster.Item(mCustomerSupport).Visible && tabMaster.Item(mCustomerSupport).Enabled && mCustomerSupportTabClicked)
				{

					this.grdCustomerFeedback.UpdateData();
					mysql = "delete GL_Ledger_Customer_Feedback ";
					mysql = mysql + " where ";
					mysql = mysql + " ldgr_cd = " + Conversion.Str(mSearchValue);
					SqlCommand TempCommand_5 = null;
					TempCommand_5 = SystemVariables.gConn.CreateCommand();
					TempCommand_5.CommandText = mysql;
					TempCommand_5.ExecuteNonQuery();

					int tempForEndVar2 = aCustomerFeedbackDetails.GetLength(0) - 1;
					for (cnt = 0; cnt <= tempForEndVar2; cnt++)
					{

						mysql = "insert into GL_Ledger_Customer_Feedback ";
						mysql = mysql + " ( Ldgr_Cd, CallDate, Remarks, user_cd) ";
						mysql = mysql + " values ( ";
						mysql = mysql + Conversion.Str(mSearchValue) + ", ";
						mysql = mysql + "'" + StringsHelper.Format(aCustomerFeedbackDetails.GetValue(cnt, cfDateIndex), SystemVariables.gSystemDateFormat) + "', ";
						mysql = mysql + "N'" + Convert.ToString(aCustomerFeedbackDetails.GetValue(cnt, cfRemarkIndex)) + "', ";
						mysql = mysql + Conversion.Str(SystemVariables.gLoggedInUserCode) + ")";

						SqlCommand TempCommand_6 = null;
						TempCommand_6 = SystemVariables.gConn.CreateCommand();
						TempCommand_6.CommandText = mysql;
						TempCommand_6.ExecuteNonQuery();

					}
				}
				//''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
				//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.CommitTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				SystemVariables.gConn.CommitTrans();
				result = true;
				FirstFocusObject.Focus();
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

		public bool deleteRecord()
		{ //Delete the Record
			bool result = false;
			DataSet rsTempRecord = new DataSet();
			string mysql = "";
			object mReturnValue = null;

			try
			{

				SystemVariables.gConn.BeginTransaction();

				//'''Donot allow to delete or modify the record if the information exists in the gl_accnt_trans_details
				mysql = " select ldgr_cd from gl_accnt_trans_details ";
				mysql = mysql + " where ldgr_cd = " + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(mReturnValue))
				{
					//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					SystemVariables.gConn.RollbackTrans();
					MessageBox.Show("Transaction Exists In GL Transaction, Record cannot be deleted.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					return false;
				}

				//'''Donot allow to delete or modify the record if the information exists in the ICS_Transaction
				mysql = " select ldgr_cd from ICS_Transaction ";
				mysql = mysql + " where ldgr_cd = " + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(mReturnValue))
				{
					//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					SystemVariables.gConn.RollbackTrans();
					MessageBox.Show("Transaction Exists In Inventory Transaction, Record cannot be deleted.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					return false;
				}

				mysql = "select * from gl_ledger where ldgr_cd = " + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
				mysql = mysql + " and protected = 0 ";
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(mReturnValue))
				{
					mysql = " delete from ICS_Item_trans_info ";
					mysql = mysql + " where ldgr_cd=" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
					SqlCommand TempCommand = null;
					TempCommand = SystemVariables.gConn.CreateCommand();
					TempCommand.CommandText = mysql;
					TempCommand.ExecuteNonQuery();

					mysql = " delete from gl_ledger ";
					mysql = mysql + " where ldgr_cd=" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
					SqlCommand TempCommand_2 = null;
					TempCommand_2 = SystemVariables.gConn.CreateCommand();
					TempCommand_2.CommandText = mysql;
					TempCommand_2.ExecuteNonQuery();
				}
				else
				{
					//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					SystemVariables.gConn.RollbackTrans();
					MessageBox.Show(SystemConstants.msg12, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return false;
				}


				//'''Donot allow to delete or modify the record if the information exists in the ST_OFFLINE_DETAILS
				mysql = " select comp_id from ST_OFFLINE_DETAILS ";
				mysql = mysql + " where table_name = 'gl_ledger' ";
				mysql = mysql + " and (upload_entry_id ='" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue).Trim() + "'";
				mysql = mysql + " or download_generated_entry_id ='" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue).Trim() + "')";
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(mReturnValue))
				{
					//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					SystemVariables.gConn.RollbackTrans();
					MessageBox.Show(SystemConstants.msg29, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					return false;
				}

				result = true;
				//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.CommitTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				SystemVariables.gConn.CommitTrans();
			}
			catch (System.Exception excep)
			{

				int mReturnErrorType = 0;
				//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				SystemVariables.gConn.RollbackTrans();
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				mReturnErrorType = SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, excep.Message, this.Name, "GetRecord", SystemConstants.msg10);
				FirstFocusObject.Focus();
				result = false;
			}

			return result;
		}

		public void GetRecord(object pSearchValue)
		{
			string mysql = "";
			SqlDataReader rsLocalRec = null;

			try
			{

				if (SystemProcedure2.IsItEmpty(pSearchValue, SystemVariables.DataType.StringType))
				{
					return;
				}

				ResetAllObjects();

				//Change the form mode to edit
				mCurrentFormMode = SystemVariables.SystemFormModes.frmEditMode;

				mysql = " select gl_ledger.*, ag.group_no, curr_no, ";
				mysql = mysql + " SM_Salesman.sman_no, cc.cost_no, pm.pay_mode_cd, ";
				mysql = mysql + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "ag.l_group_name" : "ag.a_group_name") + " as group_name, ";
				mysql = mysql + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "pg.l_group_name" : "pg.a_group_name") + " as parent_group, ";
				mysql = mysql + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_curr_name" : "l_curr_name") + " as curr_name, ";
				mysql = mysql + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_cost_name" : "a_cost_name") + " as cost_name, ";
				mysql = mysql + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_sman_name" : "a_sman_name") + " as sman_name, ";
				mysql = mysql + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_pay_mode_name" : "a_pay_mode_name") + " as pay_mode_name ";
				mysql = mysql + " , gat.type_cd ";
				mysql = mysql + ", " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "gat.l_type_name" : "gat.a_type_name") + " as accnt_type_name ";
				mysql = mysql + " from gl_ledger inner join gl_accnt_group ag on gl_ledger.group_cd = ag.group_cd ";
				mysql = mysql + " left outer join gl_accnt_group pg on ag.m_group_cd = pg.group_cd ";
				mysql = mysql + " inner join gl_currency on gl_ledger.curr_cd = gl_currency.curr_cd ";
				mysql = mysql + " inner join gl_accnt_types gat on gl_ledger.type_cd = gat.type_cd ";
				mysql = mysql + " left outer join gl_cost_centers cc on gl_ledger.default_cost_cd = cc.cost_cd ";
				mysql = mysql + " left outer join SM_Salesman on gl_ledger.default_sman_cd = SM_Salesman.sman_cd ";
				mysql = mysql + " left outer join ICS_Payment_Modes pm on gl_ledger.default_pay_mode_cd = pm.pay_mode_cd ";
				mysql = mysql + " where gl_ledger.ldgr_cd =" + ReflectionHelper.GetPrimitiveValue<string>(pSearchValue);

				SqlCommand sqlCommand = new SqlCommand(mysql, SystemVariables.gConn);
				rsLocalRec = sqlCommand.ExecuteReader();
				if (rsLocalRec.Read())
				{
					mRecordNavigateSearchValue = Convert.ToInt32(rsLocalRec["ldgr_cd"]);
					mSearchValue = rsLocalRec["ldgr_cd"];

					txtCommon[ctLedgerNoIndex].Text = Convert.ToString(rsLocalRec["ldgr_no"]);
					txtCommon[ctLLedgerNameIndex].Text = Convert.ToString(rsLocalRec["l_ldgr_Name"]);
					txtCommon[ctALedgerNameIndex].Text = Convert.ToString(rsLocalRec["a_ldgr_Name"]) + "";
					txtCommon[ctGroupNoIndex].Text = Convert.ToString(rsLocalRec["group_no"]);
					txtCommonLable[ctlGroupNameIndex].Text = Convert.ToString(rsLocalRec["group_name"]);

					txtCommon[ctAccountTypeCodeIndex].Text = Convert.ToString(rsLocalRec["type_cd"]);
					txtCommon[ctAccountTypeCodeIndex].Tag = Convert.ToString(rsLocalRec["type_cd"]);
					txtCommonLable[ctlAccountTypeName].Text = Convert.ToString(rsLocalRec["accnt_type_name"]);

					if (Convert.ToString(rsLocalRec["default_dr_cr_type"]) == "D")
					{
						cmbDrCrType.ListIndex = 0;
					}
					else
					{
						cmbDrCrType.ListIndex = 1;
					}

					txtCommon[ctCurrencyNoIndex].Text = Convert.ToString(rsLocalRec["curr_no"]);
					txtCommonLable[ctlCurrencyNameIndex].Text = Convert.ToString(rsLocalRec["curr_name"]);
					txtCreditLimit.Value = (Convert.IsDBNull(rsLocalRec["credit_limit_amount"])) ? ((object) 0) : rsLocalRec["credit_limit_amount"];
					txtCreditDays.Value = (Convert.IsDBNull(rsLocalRec["credit_limit_days"])) ? ((object) 0) : rsLocalRec["credit_limit_days"];
					txtCommon[ctEnglishAddress1Index].Text = Convert.ToString(rsLocalRec["addr_1"]) + "";
					txtCommon[ctEnglishAddress2Index].Text = Convert.ToString(rsLocalRec["addr_2"]) + "";
					txtCommon[ctEnglishAddress3Index].Text = Convert.ToString(rsLocalRec["addr_3"]) + "";
					txtCommon[ctContactPersonIndex].Text = Convert.ToString(rsLocalRec["contact_person"]) + "";
					txtCommon[ctFaxIndex].Text = Convert.ToString(rsLocalRec["fax"]) + "";
					txtCommon[ctPhoneIndex].Text = Convert.ToString(rsLocalRec["phone"]) + "";
					txtCommon[ctCityIndex].Text = Convert.ToString(rsLocalRec["city"]) + "";
					txtCommon[ctCountryIndex].Text = Convert.ToString(rsLocalRec["country"]) + "";
					txtCommon[ctEmailAddressIndex].Text = Convert.ToString(rsLocalRec["email"]) + "";
					txtCommon[ctWebAddressIndex].Text = Convert.ToString(rsLocalRec["web"]) + "";
					txtComment.Text = Convert.ToString(rsLocalRec["Comments"]) + "";
					//-------------Two New fields Added--------Moiz Hakimi--------------10-Feb-2010---------------------------------
					if (Convert.IsDBNull(rsLocalRec["Contract_date"]))
					{
						txtContractDate.Text = "";
					}
					else
					{
						txtContractDate.Value = rsLocalRec["Contract_date"];
					}

					txtContractValue.Value = rsLocalRec["Contract_Value"];
					//--------------------------------------------------------------------------------------------------------------

					txtDefaultDiscount.Value = rsLocalRec["Default_Discount_In_Percent"];

					txtCommonLable[ctlOpeningBalanceIndex].Text = StringsHelper.Format(Math.Abs(Convert.ToDouble(rsLocalRec["opening_bal"])), "###,###,##0.000") + ((Convert.ToDouble(rsLocalRec["opening_bal"]) > 0) ? " Cr" : ((Convert.ToDouble(rsLocalRec["opening_bal"]) < 0) ? " Dr" : ""));
					txtCommonLable[ctlCurrentBalanceIndex].Text = StringsHelper.Format(Math.Abs(Convert.ToDouble(rsLocalRec["current_bal"])), "###,###,##0.000") + ((Convert.ToDouble(rsLocalRec["current_bal"]) > 0) ? " Cr" : ((Convert.ToDouble(rsLocalRec["current_bal"]) < 0) ? " Dr" : ""));

					lblCommon[clParentGroupNameIndex].Caption = mBracketOpener + Convert.ToString(rsLocalRec["parent_group"]) + mBracketCloser;
					txtCommon[ctGroupNoIndex].Tag = Convert.ToString(rsLocalRec["group_cd"]);
					txtCommon[ctCurrencyNoIndex].Tag = Convert.ToString(rsLocalRec["curr_cd"]);
					mTimeStamp = Convert.ToString(rsLocalRec["time_stamp"]);
					lblCommon[clTotalNoOfTransactionIndex].Caption = mBracketOpener + mTotalNoOfTransactionText + Conversion.Str(SystemProcedure2.GetMasterCode("select count(*) from gl_accnt_trans_details where ldgr_cd = '" + ReflectionHelper.GetPrimitiveValue<string>(pSearchValue) + "'")) + mBracketCloser;


					//**--new details : 30-may-2003
					//**--modified by : Moiz Hakimi
					txtCommon[ctArabicAddress1Index].Text = Convert.ToString(rsLocalRec["a_addr_1"]) + "";
					txtCommon[ctArabicAddress2Index].Text = Convert.ToString(rsLocalRec["a_addr_2"]) + "";
					txtCommon[ctArabicAddress3Index].Text = Convert.ToString(rsLocalRec["a_addr_3"]) + "";
					txtCommon[ctMobileIndex].Text = Convert.ToString(rsLocalRec["mobile"]) + "";
					txtCommon[ctLicenseNoIndex].Text = Convert.ToString(rsLocalRec["license_no"]) + "";

					//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
					if (((TriState) ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetSystemPreferenceSetting("show_defaults_tab_in_ledger"))) == TriState.True)
					{
						txtCommon[ctDefaultCostCenterNoIndex].Text = Convert.ToString(rsLocalRec["cost_no"]) + "";
						txtCommon[ctDefaultSalesmanNoIndex].Text = Convert.ToString(rsLocalRec["sman_no"]) + "";
						txtCommon[ctDefaultPaymentModeIndex].Text = Convert.ToString(rsLocalRec["pay_mode_cd"]) + "";
						txtCommonLable[ctlDefaultCostCenterNameIndex].Text = Convert.ToString(rsLocalRec["cost_name"]) + "";
						txtCommonLable[ctlDefaultSalesmanNameIndex].Text = Convert.ToString(rsLocalRec["sman_name"]) + "";
						txtCommonLable[ctlDefaultPaymentModeNameIndex].Text = Convert.ToString(rsLocalRec["pay_mode_name"]) + "";
					}

					//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
					if (((TriState) ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetSystemPreferenceSetting("show_pricing_details_tab_in_ledger"))) == TriState.True)
					{
						//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
						//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
						chkPriceRestriction[ckEnableSalesPriceRestrictionIndex].CheckState = (CheckState) ((((TriState) Convert.ToInt32(rsLocalRec["enable_sales_price_restrictions"])) == TriState.True) ? 1 : 0);
						//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
						//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
						chkPriceRestriction[ckEnablePurchasePriceRestrictionIndex].CheckState = (CheckState) ((((TriState) Convert.ToInt32(rsLocalRec["enable_purchase_price_restrictions"])) == TriState.True) ? 1 : 0);
						//**--make current tab to mPricingDetails so that all the
						//**--settings will be done (e.g. filling combo boxes etc.)
						ShowPricingDetails(false);
						//tcFormOptions.SelectedItem = mPricingDetails

						if (!Convert.IsDBNull(rsLocalRec["default_sales_price_level"]))
						{
							SystemCombo.SearchCombo(cmbPriceLevel[ccSalesPriceLevelIndex], Convert.ToInt32(rsLocalRec["default_sales_price_level"]));
						}
						else
						{
							cmbPriceLevel[ccSalesPriceLevelIndex].ListIndex = 0;
						}
						if (!Convert.IsDBNull(rsLocalRec["maximum_sales_price_level"]))
						{
							SystemCombo.SearchCombo(cmbPriceLevel[ccMaximumSalesPriceLevelIndex], Convert.ToInt32(rsLocalRec["maximum_sales_price_level"]));
						}
						else
						{
							cmbPriceLevel[ccMaximumSalesPriceLevelIndex].ListIndex = 0;
						}
						if (!Convert.IsDBNull(rsLocalRec["minimum_sales_price_level"]))
						{
							SystemCombo.SearchCombo(cmbPriceLevel[ccMinimumSalesPriceLevelIndex], Convert.ToInt32(rsLocalRec["minimum_sales_price_level"]));
						}
						else
						{
							cmbPriceLevel[ccMinimumSalesPriceLevelIndex].ListIndex = 0;
						}

						if (!Convert.IsDBNull(rsLocalRec["default_purchase_price_level"]))
						{
							SystemCombo.SearchCombo(cmbPriceLevel[ccPurchasePriceLevelIndex], Convert.ToInt32(rsLocalRec["default_purchase_price_level"]));
						}
						else
						{
							cmbPriceLevel[ccPurchasePriceLevelIndex].ListIndex = 0;
						}
						if (!Convert.IsDBNull(rsLocalRec["maximum_purchase_price_level"]))
						{
							SystemCombo.SearchCombo(cmbPriceLevel[ccMaximumPurchasePriceLevelIndex], Convert.ToInt32(rsLocalRec["maximum_purchase_price_level"]));
						}
						else
						{
							cmbPriceLevel[ccMaximumPurchasePriceLevelIndex].ListIndex = 0;
						}
						if (!Convert.IsDBNull(rsLocalRec["minimum_purchase_price_level"]))
						{
							SystemCombo.SearchCombo(cmbPriceLevel[ccMinimumPurchasePriceLevelIndex], Convert.ToInt32(rsLocalRec["minimum_purchase_price_level"]));
						}
						else
						{
							cmbPriceLevel[ccMinimumPurchasePriceLevelIndex].ListIndex = 0;
						}

						txtCommonNumber[cnMaximumSalesProductDiscountIndex].Value = (Convert.IsDBNull(rsLocalRec["Maximum_Product_Sales_Discount_In_Percent"])) ? ((object) 0) : rsLocalRec["Maximum_Product_Sales_Discount_In_Percent"];
						txtCommonNumber[cnMaximumSalesVoucherDiscountIndex].Value = (Convert.IsDBNull(rsLocalRec["Maximum_voucher_Sales_Discount_In_Percent"])) ? ((object) 0) : rsLocalRec["Maximum_voucher_Sales_Discount_In_Percent"];
						txtCommonNumber[cnMaximumPurchaseProductDiscountIndex].Value = (Convert.IsDBNull(rsLocalRec["Maximum_Product_purchase_Discount_In_Percent"])) ? ((object) 0) : rsLocalRec["Maximum_Product_purchase_Discount_In_Percent"];
						txtCommonNumber[cnMaximumPurchaseVoucherDiscountIndex].Value = (Convert.IsDBNull(rsLocalRec["Maximum_voucher_purchase_Discount_In_Percent"])) ? ((object) 0) : rsLocalRec["Maximum_voucher_purchase_Discount_In_Percent"];
					}

					//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
					if (((TriState) ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetSystemPreferenceSetting("show_customer_support_tab_in_ledger"))) == TriState.True)
					{
						ShowCustomerSupportDetails(false);
					}

					//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
					//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
					chkDiscontinued.CheckState = (CheckState) ((((TriState) Convert.ToInt32(rsLocalRec["discontinued"])) == TriState.True) ? 1 : 0);
					//**----------------------------------------------------------------------------------------------------
					//Call ShowHideMasterDetails
				}
				else
				{
					MessageBox.Show("No records found", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				rsLocalRec.Close();
				tabMaster.SelectedItem = mBasicMasterDetails;
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, excep.Message, this.Name, "GetRecord");
			}
		}

		public void PrintReport()
		{ //Print routine
			SystemReports.GetSystemReport(41001000, 1);
		}

		public void CloseForm()
		{
			this.Close();
		}

		private void ChangeTabPageStatus(int pTabPageIndex, bool pEnabled)
		{
			tabMaster.Item(pTabPageIndex).Enabled = pEnabled;
		}

		private void InsertLedgerRecord(bool InsertMode = true)
		{
			string mysql = "";

			if (InsertMode)
			{
				mysql = "insert into gl_ledger(type_cd, group_cd, curr_cd, default_dr_cr_type ";
				mysql = mysql + " , ldgr_no, l_ldgr_name, ";
				mysql = mysql + " a_ldgr_name, comments, addr_1, addr_2, addr_3, city, country,";
				mysql = mysql + " email, web, phone, fax, contact_person, credit_limit_days,";
				mysql = mysql + " credit_limit_amount, user_cd ";

				//**--new added : 30-may-2003
				//**--modified by : Moiz Hakimi
				mysql = mysql + " , license_no, a_addr_1, a_addr_2, a_addr_3, mobile ";
				mysql = mysql + " , default_cost_cd, default_sman_cd ";
				mysql = mysql + " , default_pay_mode_cd, default_sales_price_level, default_purchase_price_level,";
				mysql = mysql + " enable_sales_price_restrictions, maximum_sales_price_level, ";
				mysql = mysql + " minimum_sales_price_level, maximum_product_sales_discount_in_percent,";
				mysql = mysql + " maximum_voucher_sales_discount_in_percent, enable_purchase_price_restrictions, ";
				mysql = mysql + " maximum_purchase_price_level, minimum_purchase_price_level, ";
				mysql = mysql + " maximum_product_purchase_discount_in_percent, ";
				mysql = mysql + " maximum_voucher_purchase_discount_in_percent, discontinued, ";
				//**---------------------------------------------------------------------------------------------------------------
				//---------------Two new field addad----------Moiz Hakimi-----------10-02-2010----------------------------------
				mysql = mysql + " Contract_date, Contract_Value, Default_Discount_In_Percent";
				//---------------------------------------------------------------------------------------------------------------
				mysql = mysql + " ) values (";
				mysql = mysql + Conversion.Str(mAccountTypeCode) + ",";
				mysql = mysql + mNewGroupCode + ",";
				mysql = mysql + mNewCurrenyCode + ",";

				if (cmbDrCrType.ListIndex == 0)
				{
					mysql = mysql + " 'D' ";
				}
				else
				{
					mysql = mysql + " 'C' ";
				}

				mysql = mysql + ", N'" + txtCommon[ctLedgerNoIndex].Text + "',";
				mysql = mysql + "N'" + txtCommon[ctLLedgerNameIndex].Text + "',";
				mysql = mysql + "N'" + txtCommon[ctALedgerNameIndex].Text + "',";
				mysql = mysql + "N'" + txtComment.Text + "',";
				mysql = mysql + "N'" + txtCommon[ctEnglishAddress1Index].Text + "',";
				mysql = mysql + "N'" + txtCommon[ctEnglishAddress2Index].Text + "',";
				mysql = mysql + "N'" + txtCommon[ctEnglishAddress3Index].Text + "',";
				mysql = mysql + "N'" + txtCommon[ctCityIndex].Text + "',";
				mysql = mysql + "N'" + txtCommon[ctCountryIndex].Text + "',";
				mysql = mysql + "N'" + txtCommon[ctEmailAddressIndex].Text + "',";
				mysql = mysql + "N'" + txtCommon[ctWebAddressIndex].Text + "',";
				mysql = mysql + "N'" + txtCommon[ctPhoneIndex].Text + "',";
				mysql = mysql + "N'" + txtCommon[ctFaxIndex].Text + "',";
				mysql = mysql + "N'" + txtCommon[ctContactPersonIndex].Text + "',";
				mysql = mysql + Conversion.Str(txtCreditDays.Value) + ",";
				mysql = mysql + Conversion.Str(txtCreditLimit.Value) + ",";
				mysql = mysql + Conversion.Str(SystemVariables.gLoggedInUserCode);

				//**--new added : 30-may-2003
				//**--modified by : Moiz Hakimi
				mysql = mysql + ",N'" + txtCommon[ctLicenseNoIndex].Text + "', ";
				mysql = mysql + "N'" + txtCommon[ctArabicAddress1Index].Text + "', ";
				mysql = mysql + "N'" + txtCommon[ctArabicAddress2Index].Text + "', ";
				mysql = mysql + "N'" + txtCommon[ctArabicAddress3Index].Text + "', ";
				mysql = mysql + "N'" + txtCommon[ctMobileIndex].Text + "', ";
				mysql = mysql + mNewDefaultCostCenterCode + ",";
				mysql = mysql + mNewDefaultSalesmanCode + ",";
				mysql = mysql + mNewDefaultPaymentModeCode + ",";


				//    If tcFormOptions.Item(mPricingDetails).Visible = True And mPricingDetailsTabClicked = True Then
				if (tabMaster.Item(mPricingDetails).Visible && tabMaster.Item(mPricingDetails).Enabled && mPricingDetailsTabClicked)
				{
					mysql = mysql + Conversion.Str(cmbPriceLevel[ccSalesPriceLevelIndex].GetItemData(cmbPriceLevel[ccSalesPriceLevelIndex].ListIndex)) + ",";
					mysql = mysql + Conversion.Str(cmbPriceLevel[ccPurchasePriceLevelIndex].GetItemData(cmbPriceLevel[ccPurchasePriceLevelIndex].ListIndex)) + ",";

					if (chkPriceRestriction[ckEnableSalesPriceRestrictionIndex].Visible && ((int) chkPriceRestriction[ckEnableSalesPriceRestrictionIndex].CheckState) != ((int) CheckState.Unchecked))
					{
						mysql = mysql + "1, ";
						mysql = mysql + Conversion.Str(cmbPriceLevel[ccMaximumSalesPriceLevelIndex].GetItemData(cmbPriceLevel[ccMaximumSalesPriceLevelIndex].ListIndex)) + ",";
						mysql = mysql + Conversion.Str(cmbPriceLevel[ccMinimumSalesPriceLevelIndex].GetItemData(cmbPriceLevel[ccMinimumSalesPriceLevelIndex].ListIndex)) + ",";
						mysql = mysql + Conversion.Str(txtCommonNumber[cnMaximumSalesProductDiscountIndex].Value) + ",";
						mysql = mysql + Conversion.Str(txtCommonNumber[cnMaximumSalesVoucherDiscountIndex].Value) + ",";
					}
					else
					{
						mysql = mysql + " 0, null, null, null, null, ";
					}


					if (chkPriceRestriction[ckEnablePurchasePriceRestrictionIndex].Visible && ((int) chkPriceRestriction[ckEnablePurchasePriceRestrictionIndex].CheckState) != ((int) CheckState.Unchecked))
					{
						mysql = mysql + "1, ";
						mysql = mysql + Conversion.Str(cmbPriceLevel[ccMaximumPurchasePriceLevelIndex].GetItemData(cmbPriceLevel[ccMaximumPurchasePriceLevelIndex].ListIndex)) + ",";
						mysql = mysql + Conversion.Str(cmbPriceLevel[ccMinimumPurchasePriceLevelIndex].GetItemData(cmbPriceLevel[ccMinimumPurchasePriceLevelIndex].ListIndex)) + ",";
						mysql = mysql + Conversion.Str(txtCommonNumber[cnMaximumPurchaseProductDiscountIndex].Value) + ",";
						mysql = mysql + Conversion.Str(txtCommonNumber[cnMaximumPurchaseVoucherDiscountIndex].Value);
					}
					else
					{
						mysql = mysql + " 0, null, null, null, null ";
					}
				}
				else
				{
					mysql = mysql + " null, null, 0, null, null, null, ";
					mysql = mysql + " null, 0, null, null, null, null ";
				}
				if (chkDiscontinued.Visible)
				{
					mysql = mysql + ((((int) chkDiscontinued.CheckState) != ((int) CheckState.Unchecked)) ? ", 1" : ", 0");
				}
				else
				{
					mysql = mysql + ", 0";
				}
				//---------------new added-----------Moiz Hakimi-------10-Feb-2010------------------------
				mysql = mysql + "," + ((ReflectionHelper.GetPrimitiveValue<string>(txtContractDate.Value) == "  -   -    ") ? " NULL" : "'" + ReflectionHelper.GetPrimitiveValue<string>(txtContractDate.Value) + "'");
				mysql = mysql + ", " + ReflectionHelper.GetPrimitiveValue<string>(txtContractValue.Value);
				mysql = mysql + ", " + ReflectionHelper.GetPrimitiveValue<string>(txtDefaultDiscount.Value);
				//-----------------------------------------------------------------------------------------

				mysql = mysql + " )";
				SqlCommand TempCommand = null;
				TempCommand = SystemVariables.gConn.CreateCommand();
				TempCommand.CommandText = mysql;
				TempCommand.ExecuteNonQuery();

				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode("select scope_identity()"));
			}
			else
			{
				mysql = "insert into ledger ";
				mysql = mysql + " (type_cd, ldgr_no, ";
				mysql = mysql + " group_cd, curr_cd, l_ldgr_name, a_ldgr_name, alias_name, ";
				mysql = mysql + " affect_inventory_values, credit_limit_amount, ";
				mysql = mysql + " credit_limit_days, addr_1, addr_2, addr_3, a_addr_1, a_addr_2, ";
				mysql = mysql + " a_addr_3, city, country, email, web, phone, fax, contact_person, ";
				mysql = mysql + " reference_no, mobile, license_no, default_cost_cd, default_ldgr_cd, ";
				mysql = mysql + " default_sman_cd, default_pay_mode_cd, default_sales_price_level, ";
				mysql = mysql + " default_purchase_price_level, enable_sales_price_restrictions, ";
				mysql = mysql + " maximum_sales_price_level, minimum_sales_price_level, ";
				mysql = mysql + " maximum_product_sales_discount_in_percent, maximum_voucher_sales_discount_in_percent, ";
				mysql = mysql + " enable_purchase_price_restrictions, maximum_purchase_price_level, ";
				mysql = mysql + " minimum_purchase_price_level, maximum_product_purchase_discount_in_percent, ";
				mysql = mysql + " maximum_voucher_purchase_discount_in_percent, discontinued, reconciled, ";
				mysql = mysql + " last_reconciled_bal, last_reconciled_date, current_reconciled_bal, ";
				mysql = mysql + " current_reconciled_date , opening_bal, Show, protected, Comments, ";
				mysql = mysql + " grade_cd, user_cd, user_date_time, Contract_date, Contract_Value)";

				mysql = mysql + " select " + mAccountTypeCode.ToString() + ",'" + mTempLedgerNo + "',";
				mysql = mysql + " group_cd, curr_cd, l_ldgr_name, a_ldgr_name, alias_name, ";
				mysql = mysql + " affect_inventory_values, credit_limit_amount, ";
				mysql = mysql + " credit_limit_days, addr_1, addr_2, addr_3, a_addr_1, a_addr_2, ";
				mysql = mysql + " a_addr_3, city, country, email, web, phone, fax, contact_person, ";
				mysql = mysql + " reference_no, mobile, license_no, default_cost_cd, default_ldgr_cd, ";
				mysql = mysql + " default_sman_cd, default_pay_mode_cd, default_sales_price_level, ";
				mysql = mysql + " default_purchase_price_level, enable_sales_price_restrictions, ";
				mysql = mysql + " maximum_sales_price_level, minimum_sales_price_level, ";
				mysql = mysql + " maximum_product_sales_discount_in_percent, maximum_voucher_sales_discount_in_percent, ";
				mysql = mysql + " enable_purchase_price_restrictions, maximum_purchase_price_level, ";
				mysql = mysql + " minimum_purchase_price_level, maximum_product_purchase_discount_in_percent, ";
				mysql = mysql + " maximum_voucher_purchase_discount_in_percent, discontinued, reconciled, ";
				mysql = mysql + " last_reconciled_bal, last_reconciled_date, current_reconciled_bal, ";
				mysql = mysql + " current_reconciled_date , opening_bal, Show, protected, Comments, ";
				mysql = mysql + " grade_cd, user_cd, user_date_time, Contract_date, Contract_Value ";
				mysql = mysql + " from gl_ledger where ldgr_cd = '" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue) + "'";

				SqlCommand TempCommand_2 = null;
				TempCommand_2 = SystemVariables.gConn.CreateCommand();
				TempCommand_2.CommandText = mysql;
				TempCommand_2.ExecuteNonQuery();
			}
		}

		private void UpdateLedgerRecord()
		{

			string mysql = " update gl_ledger set group_cd =" + mNewGroupCode + ",";
			mysql = mysql + " curr_cd  = " + mNewCurrenyCode + ",";

			//''added by Moiz Hakimion 04-jun-2007, inorder to allow update of type code
			mysql = mysql + " type_cd  = " + mAccountTypeCode.ToString() + ",";
			mysql = mysql + " ldgr_no =N'" + txtCommon[ctLedgerNoIndex].Text + "',";
			mysql = mysql + " l_ldgr_name = N'" + txtCommon[ctLLedgerNameIndex].Text + "',";
			mysql = mysql + " a_ldgr_name = N'" + txtCommon[ctALedgerNameIndex].Text + "',";
			if (cmbDrCrType.ListIndex == 0)
			{
				mysql = mysql + " default_dr_cr_type  = 'D' , ";
			}
			else
			{
				mysql = mysql + " default_dr_cr_type  = 'C' , ";
			}

			mysql = mysql + " comments = N'" + txtComment.Text + "',";
			mysql = mysql + " addr_1 = N'" + txtCommon[ctEnglishAddress1Index].Text + "',";
			mysql = mysql + " addr_2 = N'" + txtCommon[ctEnglishAddress2Index].Text + "',";
			mysql = mysql + " addr_3 = N'" + txtCommon[ctEnglishAddress3Index].Text + "',";
			mysql = mysql + " city = N'" + txtCommon[ctCityIndex].Text + "',";
			mysql = mysql + " country = N'" + txtCommon[ctCountryIndex].Text + "',";
			mysql = mysql + " email = N'" + txtCommon[ctEmailAddressIndex].Text + "',";
			mysql = mysql + " web = N'" + txtCommon[ctWebAddressIndex].Text + "',";
			mysql = mysql + " phone = N'" + txtCommon[ctPhoneIndex].Text + "',";
			mysql = mysql + " fax = N'" + txtCommon[ctFaxIndex].Text + "',";
			mysql = mysql + " contact_person = N'" + txtCommon[ctContactPersonIndex].Text + "',";
			mysql = mysql + " credit_limit_days = " + Conversion.Str(txtCreditDays.Value) + ",";
			mysql = mysql + " credit_limit_amount = " + Conversion.Str(txtCreditLimit.Value) + ",";
			mysql = mysql + " user_cd = " + Conversion.Str(SystemVariables.gLoggedInUserCode) + ",";

			mysql = mysql + " a_addr_1 = N'" + txtCommon[ctArabicAddress1Index].Text + "',";
			mysql = mysql + " a_addr_2 = N'" + txtCommon[ctArabicAddress2Index].Text + "',";
			mysql = mysql + " a_addr_3 = N'" + txtCommon[ctArabicAddress3Index].Text + "',";
			mysql = mysql + " mobile = N'" + txtCommon[ctMobileIndex].Text + "',";
			mysql = mysql + " license_no = N'" + txtCommon[ctLicenseNoIndex].Text + "',";
			mysql = mysql + " default_cost_cd = " + mNewDefaultCostCenterCode + ",";
			mysql = mysql + " default_sman_cd = " + mNewDefaultSalesmanCode + ",";
			mysql = mysql + " default_pay_mode_cd = " + mNewDefaultPaymentModeCode + ",";

			//If tcFormOptions.Item(mPricingDetails).Visible = True Then
			if (tabMaster.Item(mPricingDetails).Visible && tabMaster.Item(mPricingDetails).Visible)
			{
				mysql = mysql + " default_sales_price_level = " + Conversion.Str(cmbPriceLevel[ccSalesPriceLevelIndex].GetItemData(cmbPriceLevel[ccSalesPriceLevelIndex].ListIndex)) + ",";
				mysql = mysql + " default_purchase_price_level = " + Conversion.Str(cmbPriceLevel[ccPurchasePriceLevelIndex].GetItemData(cmbPriceLevel[ccPurchasePriceLevelIndex].ListIndex)) + ",";

				if (chkPriceRestriction[ckEnableSalesPriceRestrictionIndex].Visible && ((int) chkPriceRestriction[ckEnableSalesPriceRestrictionIndex].CheckState) != ((int) CheckState.Unchecked))
				{
					mysql = mysql + " enable_sales_price_restrictions = 1, ";
					mysql = mysql + " maximum_sales_price_level = " + Conversion.Str(cmbPriceLevel[ccMaximumSalesPriceLevelIndex].GetItemData(cmbPriceLevel[ccMaximumSalesPriceLevelIndex].ListIndex)) + ",";
					mysql = mysql + " minimum_sales_price_level = " + Conversion.Str(cmbPriceLevel[ccMinimumSalesPriceLevelIndex].GetItemData(cmbPriceLevel[ccMinimumSalesPriceLevelIndex].ListIndex)) + ",";
					mysql = mysql + " maximum_product_sales_discount_in_percent = " + Conversion.Str(txtCommonNumber[cnMaximumSalesProductDiscountIndex].Value) + ",";
					mysql = mysql + " maximum_voucher_sales_discount_in_percent = " + Conversion.Str(txtCommonNumber[cnMaximumSalesVoucherDiscountIndex].Value) + ",";
				}
				else
				{
					mysql = mysql + " enable_sales_price_restrictions = 0, ";
					mysql = mysql + " maximum_sales_price_level = null, ";
					mysql = mysql + " minimum_sales_price_level = null, ";
					mysql = mysql + " maximum_product_sales_discount_in_percent = null, ";
					mysql = mysql + " maximum_voucher_sales_discount_in_percent = null, ";
				}

				if (chkPriceRestriction[ckEnablePurchasePriceRestrictionIndex].Visible && ((int) chkPriceRestriction[ckEnablePurchasePriceRestrictionIndex].CheckState) != ((int) CheckState.Unchecked))
				{
					mysql = mysql + " enable_purchase_price_restrictions = 1, ";
					mysql = mysql + " maximum_purchase_price_level = " + Conversion.Str(cmbPriceLevel[ccMaximumPurchasePriceLevelIndex].GetItemData(cmbPriceLevel[ccMaximumPurchasePriceLevelIndex].ListIndex)) + ",";
					mysql = mysql + " minimum_purchase_price_level = " + Conversion.Str(cmbPriceLevel[ccMinimumPurchasePriceLevelIndex].GetItemData(cmbPriceLevel[ccMinimumPurchasePriceLevelIndex].ListIndex)) + ",";
					mysql = mysql + " maximum_product_purchase_discount_in_percent = " + Conversion.Str(txtCommonNumber[cnMaximumPurchaseProductDiscountIndex].Value) + ",";
					mysql = mysql + " maximum_voucher_purchase_discount_in_percent = " + Conversion.Str(txtCommonNumber[cnMaximumPurchaseVoucherDiscountIndex].Value);
				}
				else
				{
					mysql = mysql + " enable_purchase_price_restrictions = 0, ";
					mysql = mysql + " maximum_purchase_price_level = null, ";
					mysql = mysql + " minimum_purchase_price_level = null, ";
					mysql = mysql + " maximum_product_purchase_discount_in_percent = null, ";
					mysql = mysql + " maximum_voucher_purchase_discount_in_percent = null ";
				}
			}
			else
			{
				mysql = mysql + " default_sales_price_level =  null,";
				mysql = mysql + " default_purchase_price_level = null,";
				mysql = mysql + " enable_sales_price_restrictions = 0, ";
				mysql = mysql + " maximum_sales_price_level = null, ";
				mysql = mysql + " minimum_sales_price_level = null, ";
				mysql = mysql + " maximum_product_sales_discount_in_percent = null, ";
				mysql = mysql + " maximum_voucher_sales_discount_in_percent = null, ";
				mysql = mysql + " enable_purchase_price_restrictions = 0, ";
				mysql = mysql + " maximum_purchase_price_level = null, ";
				mysql = mysql + " minimum_purchase_price_level = null, ";
				mysql = mysql + " maximum_product_purchase_discount_in_percent = null, ";
				mysql = mysql + " maximum_voucher_purchase_discount_in_percent = null ";
			}
			//---------------new added-----------Moiz Hakimi-------10-Feb-2010------------------------
			mysql = mysql + ", Contract_date = " + ((ReflectionHelper.GetPrimitiveValue<string>(txtContractDate.Value) == "  -   -    ") ? " NULL" : "'" + ReflectionHelper.GetPrimitiveValue<string>(txtContractDate.Value) + "'");
			mysql = mysql + ", Contract_Value = " + ReflectionHelper.GetPrimitiveValue<string>(txtContractValue.Value);
			mysql = mysql + ", Default_Discount_In_Percent = " + ReflectionHelper.GetPrimitiveValue<string>(txtDefaultDiscount.Value);
			//-----------------------------------------------------------------------------------------

			mysql = mysql + " , discontinued = ";
			if (chkDiscontinued.Visible)
			{
				mysql = mysql + ((((int) chkDiscontinued.CheckState) != ((int) CheckState.Unchecked)) ? "1" : "0");
			}
			else
			{
				mysql = mysql + "0";
			}
			mysql = mysql + " where ldgr_cd = '" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue) + "'";

			SqlCommand TempCommand = null;
			TempCommand = SystemVariables.gConn.CreateCommand();
			TempCommand.CommandText = mysql;
			TempCommand.ExecuteNonQuery();
		}

		public bool CheckDataValidity()
		{
			bool result = false;
			DataSet rsMasterInfo = null;
			DataSet rsTempRecord = null;
			string mCheckTimeStamp = "";
			string mysql = "";

			txtCommon_Leave(txtCommon[ctAccountTypeCodeIndex], new EventArgs());
			txtCommon_Leave(txtCommon[ctGroupNoIndex], new EventArgs());
			txtCommon_Leave(txtCommon[ctCurrencyNoIndex], new EventArgs());

			if (!txtCommon[ctDefaultCostCenterNoIndex].Visible)
			{
				txtCommon[ctDefaultCostCenterNoIndex].Text = "";
			}

			if (!txtCommon[ctDefaultSalesmanNoIndex].Visible)
			{
				txtCommon[ctDefaultSalesmanNoIndex].Text = "";
			}

			if (!txtCommon[ctDefaultPaymentModeIndex].Visible)
			{
				txtCommon[ctDefaultPaymentModeIndex].Text = "";
			}

			txtCommon_Leave(txtCommon[ctDefaultCostCenterNoIndex], new EventArgs());
			txtCommon_Leave(txtCommon[ctDefaultSalesmanNoIndex], new EventArgs());
			txtCommon_Leave(txtCommon[ctDefaultPaymentModeIndex], new EventArgs());

			mAccountTypeCode = Convert.ToInt32(Conversion.Val(Convert.ToString(txtCommon[ctAccountTypeCodeIndex].Tag)));
			mNewGroupCode = Convert.ToString(txtCommon[ctGroupNoIndex].Tag);
			if (SystemProcedure2.IsItEmpty(Convert.ToString(txtCommon[ctCurrencyNoIndex].Tag), SystemVariables.DataType.StringType))
			{
				mNewCurrenyCode = "DEFAULT";
			}
			else
			{
				mNewCurrenyCode = Conversion.Str(Convert.ToString(txtCommon[ctCurrencyNoIndex].Tag));
			}

			if (SystemProcedure2.IsItEmpty(Convert.ToString(txtCommon[ctDefaultCostCenterNoIndex].Tag), SystemVariables.DataType.StringType))
			{
				mNewDefaultCostCenterCode = "NULL";
			}
			else
			{
				mNewDefaultCostCenterCode = Conversion.Str(Convert.ToString(txtCommon[ctDefaultCostCenterNoIndex].Tag));
			}
			if (SystemProcedure2.IsItEmpty(Convert.ToString(txtCommon[ctDefaultSalesmanNoIndex].Tag), SystemVariables.DataType.StringType))
			{
				mNewDefaultSalesmanCode = "NULL";
			}
			else
			{
				mNewDefaultSalesmanCode = Conversion.Str(Convert.ToString(txtCommon[ctDefaultSalesmanNoIndex].Tag));
			}
			if (SystemProcedure2.IsItEmpty(Convert.ToString(txtCommon[ctDefaultPaymentModeIndex].Tag), SystemVariables.DataType.StringType))
			{
				mNewDefaultPaymentModeCode = "NULL";
			}
			else
			{
				mNewDefaultPaymentModeCode = Conversion.Str(Convert.ToString(txtCommon[ctDefaultPaymentModeIndex].Tag));
			}

			if (SystemProcedure2.IsItEmpty(txtCommon[ctLedgerNoIndex].Text, SystemVariables.DataType.StringType))
			{
				MessageBox.Show("Enter Ledger Code", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
				txtCommon[ctLedgerNoIndex].Focus();
				return false;
			}

			if (SystemProcedure2.IsItEmpty(Convert.ToString(txtCommon[ctAccountTypeCodeIndex].Tag), SystemVariables.DataType.NumberType))
			{
				MessageBox.Show("Enter Account Type Code", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
				if (txtCommon[ctAccountTypeCodeIndex].Enabled)
				{
					//tcFormOptions.Item(mBasicMasterDetails).Selected = True
					tabMaster.SelectedItem = mBasicMasterDetails;
					txtCommon[ctAccountTypeCodeIndex].Focus();
				}
				return false;
			}

			if (SystemProcedure2.IsItEmpty(Convert.ToString(txtCommon[ctGroupNoIndex].Tag), SystemVariables.DataType.StringType))
			{
				MessageBox.Show("Enter Group Code", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
				//    tcFormOptions.Item(mBasicMasterDetails).Selected = True
				tabMaster.SelectedItem = mBasicMasterDetails;
				txtCommon[ctGroupNoIndex].Focus();
				return false;
			}

			if (txtCommon[ctCurrencyNoIndex].Visible && SystemProcedure2.IsItEmpty(Convert.ToString(txtCommon[ctCurrencyNoIndex].Tag), SystemVariables.DataType.NumberType))
			{
				MessageBox.Show("Enter Currency Code", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
				//    tcFormOptions.Item(mBasicMasterDetails).Selected = True
				tabMaster.SelectedItem = mBasicMasterDetails;
				txtCommon[ctCurrencyNoIndex].Focus();
				return false;
			}


			if (CurrentFormMode == SystemVariables.SystemFormModes.frmEditMode)
			{
				//--check the timestamp value
				mysql = "select time_stamp, group_cd, curr_cd ";
				mysql = mysql + " from gl_ledger where ldgr_cd = '" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue) + "'";
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
				//    mOldGroupCode = rsMasterInfo("group_cd")
				//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
				mOldCurrenyCode = Convert.ToString(rsMasterInfo.Tables[0].Rows[0]["curr_cd"]);
				if (rsMasterInfo.Tables[0].Rows.Count != 0)
				{
					//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
					mCheckTimeStamp = Convert.ToString(rsMasterInfo.Tables[0].Rows[0]["time_stamp"]);
				}
				if ((rsMasterInfo.Tables[0].Rows.Count == 0) || (SystemProcedure2.tsFormat(mTimeStamp) != SystemProcedure2.tsFormat(mCheckTimeStamp)))
				{
					MessageBox.Show(SystemConstants.msg10, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					result = false;
					FirstFocusObject.Focus();
					return result;
				}

				if (!ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("advance_multiple_currency")))
				{
					//--do not allow change if the currency is changed
					if (StringsHelper.ToDoubleSafe(mOldCurrenyCode) != Conversion.Val(mNewCurrenyCode))
					{
						SqlCommand TempCommand_2 = null;
						TempCommand_2 = SystemVariables.gConn.CreateCommand();
						TempCommand_2.CommandText = "select count(*) from gl_accnt_trans_details where ldgr_cd =" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
						SqlDataAdapter TempAdapter_2 = null;
						TempAdapter_2 = new SqlDataAdapter();
						TempAdapter_2.SelectCommand = TempCommand_2;
						DataSet TempDataset_2 = null;
						TempDataset_2 = new DataSet();
						TempAdapter_2.Fill(TempDataset_2);
						rsTempRecord = TempDataset_2;
						//--check if there is any record exists for the given ledger
						//UPGRADE_WARNING: (2077) Change the default 0 index in the Rows property with the correct one. More Information: https://docs.mobilize.net/vbuc/ewis#2077
						if (Convert.ToDouble(rsTempRecord.Tables[0].Rows[0][0]) > 0)
						{
							rsTempRecord = null;

							result = false;
							MessageBox.Show("Error : Can not change Ledger Currency, transactions exists for the Ledger", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
							FirstFocusObject.Focus();
							return result;
						}
					}
				}

				rsMasterInfo = null;
			}

			return true;
		}


		private void grdCustomerFeedback_RowColChange(object eventSender, C1.Win.C1TrueDBGrid.RowColChangeEventArgs eventArgs)
		{
			int LastRow = eventArgs.LastRow;
			int LastCol = eventArgs.LastCol;
			int cnt = 0;

			try
			{

				grdCustomerFeedback.UpdateData();
			}
			catch (System.Exception excep)
			{

				MessageBox.Show(excep.Message, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
			}
		}

		private void grdPriceDetails_AfterColUpdate(Object eventSender, C1.Win.C1TrueDBGrid.ColEventArgs eventArgs)
		{
			int ColIndex = eventArgs.ColIndex;
			object mTempSearchValue = null;
			string mysql = "";
			int mProdCd = 0;
			bool mIsDuplicate = false;
			grdPriceDetails.UpdateData();

			if (ColIndex == ckVoucherIndex)
			{
				if (!SystemProcedure2.IsItEmpty(grdPriceDetails.Columns[ckVoucherIndex].Value, SystemVariables.DataType.StringType))
				{


					mysql = " select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "L_Voucher_Name" : "A_Voucher_Name") + " as Voucher_name ";
					mysql = mysql + " from ICS_Transaction_Types where voucher_type = " + ReflectionHelper.GetPrimitiveValue<string>(grdPriceDetails.Columns[ckVoucherIndex].Value);

					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));

					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (!Convert.IsDBNull(mTempSearchValue))
					{
						grdPriceDetails.Columns[ckVoucherNameIndex].Value = mTempSearchValue;
					}
				}
			}
			else if (ColIndex == ckVoucherNameIndex)
			{ 
				if (!SystemProcedure2.IsItEmpty(grdPriceDetails.Columns[ckVoucherNameIndex].Value, SystemVariables.DataType.StringType))
				{

					mysql = " select voucher_type ";
					mysql = mysql + " from ICS_Transaction_Types ";
					mysql = mysql + " where " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "L_Voucher_Name" : "A_Voucher_Name") + " = '" + ReflectionHelper.GetPrimitiveValue<string>(grdPriceDetails.Columns[ckVoucherNameIndex].Value) + "'";

					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));

					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (!Convert.IsDBNull(mTempSearchValue))
					{
						grdPriceDetails.Columns[ckVoucherIndex].Value = mTempSearchValue;
					}
				}
			}
			else if (ColIndex == ckPriceListIndex)
			{ 
				if (!SystemProcedure2.IsItEmpty(grdPriceDetails.Columns[ckPriceListIndex].Value, SystemVariables.DataType.StringType))
				{


					mysql = " select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "Price_List_L_Name" : "Price_List_A_Name") + " as Price_name ";
					mysql = mysql + " from ICS_Price_List where Price_List_No = " + ReflectionHelper.GetPrimitiveValue<string>(grdPriceDetails.Columns[ckPriceListIndex].Value);

					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));

					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (!Convert.IsDBNull(mTempSearchValue))
					{
						grdPriceDetails.Columns[ckPNameNameIndex].Value = mTempSearchValue;
					}
				}

			}
			else if (ColIndex == ckPNameNameIndex)
			{ 
				if (!SystemProcedure2.IsItEmpty(grdPriceDetails.Columns[ckPNameNameIndex].Value, SystemVariables.DataType.StringType))
				{

					mysql = " select Price_List_No ";
					mysql = mysql + " from ICS_Price_List ";
					mysql = mysql + " where " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "Price_List_L_Name" : "Price_List_A_Name") + " = '" + ReflectionHelper.GetPrimitiveValue<string>(grdPriceDetails.Columns[ckPNameNameIndex].Value) + "'";

					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));

					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (!Convert.IsDBNull(mTempSearchValue))
					{
						grdPriceDetails.Columns[ckPriceListIndex].Value = mTempSearchValue;
					}
				}

			}
			grdPriceDetails.Refresh();
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

		private void grdPriceDetails_RowColChange(object eventSender, C1.Win.C1TrueDBGrid.RowColChangeEventArgs eventArgs)
		{
			int LastRow = eventArgs.LastRow;
			int LastCol = eventArgs.LastCol;
			int cnt = 0;

			try
			{

				RefreshgrdPriceDetails();
				grdPriceDetails.UpdateData();
			}
			catch (System.Exception excep)
			{

				MessageBox.Show(excep.Message, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
			}
		}

		private void RefreshgrdPriceDetails(bool pCallComboRowChange = true)
		{
			string mysql = "";

			if (grdPriceDetails.Col == ckVoucherIndex || grdPriceDetails.Col == ckVoucherNameIndex)
			{
				mysql = "select Voucher_Type, ";
				mysql = mysql + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "L_Voucher_Name" : "A_Voucher_Name") + " as Voucher_name ";
				mysql = mysql + " from ICS_Transaction_Types where show = 1 ";

				rsPriceList = new DataSet();
				//UPGRADE_ISSUE: (2064) ADODB.CursorLocationEnum property CursorLocationEnum.adUseClient was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsPriceList.CursorLocation was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				rsPriceList.setCursorLocation(UpgradeStubs.ADODB_CursorLocationEnum.getadUseClient());
				SqlDataAdapter adap = new SqlDataAdapter(mysql, SystemVariables.gConn);
				rsPriceList.Tables.Clear();
				adap.Fill(rsPriceList);
				//UPGRADE_ISSUE: (2064) ADODB.Recordset method rsPriceList.Requery was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				rsPriceList.Requery(-1);

				//grdPriceDetails.SetFocus
				//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbPriceList.DataSource was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				cmbPriceList.setDataSource((msdatasrc.DataSource) rsPriceList);

			}
			else if (grdPriceDetails.Col == ckPriceListIndex || grdPriceDetails.Col == ckPNameNameIndex)
			{ 
				mysql = "select Price_List_No, ";
				mysql = mysql + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "Price_List_L_Name" : "Price_List_A_Name") + " as Price_name ";
				mysql = mysql + " from ICS_Price_List ";

				rsPriceList = new DataSet();
				//UPGRADE_ISSUE: (2064) ADODB.CursorLocationEnum property CursorLocationEnum.adUseClient was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				//UPGRADE_ISSUE: (2064) ADODB.Recordset property rsPriceList.CursorLocation was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				rsPriceList.setCursorLocation(UpgradeStubs.ADODB_CursorLocationEnum.getadUseClient());
				SqlDataAdapter adap_2 = new SqlDataAdapter(mysql, SystemVariables.gConn);
				rsPriceList.Tables.Clear();
				adap_2.Fill(rsPriceList);
				//UPGRADE_ISSUE: (2064) ADODB.Recordset method rsPriceList.Requery was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				rsPriceList.Requery(-1);

				//grdPriceDetails.SetFocus
				//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbPriceList.DataSource was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				cmbPriceList.setDataSource((msdatasrc.DataSource) rsPriceList);
			}

		}

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBDropDown Event cmbPriceList.DataSourceChanged was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void cmbPriceList_DataSourceChanged()
		{
			int cnt = 0;

			cmbPriceList.Width = 0;
			switch(grdPriceDetails.Col)
			{
				case ckVoucherIndex : 
					//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbPriceList.ListField was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064 
					cmbPriceList.setListField("Vouchet_Type"); 
					cmbPriceList.DisplayColumns[0].Visible = true; 
					cmbPriceList.DisplayColumns[0].Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Near; 
					 
					//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081 
					cmbPriceList.Width = grdPriceDetails.Splits[0].DisplayColumns[ckVoucherIndex].Width + 167; 
					 
					break;
				case ckVoucherNameIndex : 
					//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbPriceList.ListField was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064 
					cmbPriceList.setListField("Voucher_name"); 
					//cmbPriceList.Columns(0).Order = 1 
					cmbPriceList.DisplayColumns[1].Width = 200; 
					cmbPriceList.DisplayColumns[0].Width = 47; 
					 
					//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081 
					cmbPriceList.Width = grdPriceDetails.Splits[0].DisplayColumns[ckVoucherNameIndex].Width + 100; 
					break;
				case ckPriceListIndex : 
					//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbPriceList.ListField was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064 
					cmbPriceList.setListField("Price_List_No"); 
					cmbPriceList.DisplayColumns[0].Visible = true; 
					cmbPriceList.DisplayColumns[0].Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Near; 
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
			}
		}

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBDropDown Event cmbPriceList.DropDownClose was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void cmbPriceList_DropDownClose()
		{
			switch(grdPriceDetails.Col)
			{
				case ckVoucherIndex : case ckVoucherNameIndex : 
					grdPriceDetails.Col = ckPriceListIndex; 
					break;
				case ckPriceListIndex : 
					grdPriceDetails.Col = ckPNameNameIndex; 
					break;
				case ckPNameNameIndex : 
					 
					break;
			}
		}

		//Private Sub tcFormOptions_SelectedChanged(ByVal Item As XtremeSuiteControls.ITabControlItem)
		//On Error GoTo eIgnoreError
		//
		//Select Case Item.Index
		//    Case mBasicMasterDetails
		//        If mFormIsInitialized = True Then
		//            txtCommon(ctGroupNoIndex).SetFocus
		//        End If
		//        mBasicMasterDetailsTabClicked = True
		//    Case mOtherMasterDetails
		//        txtCommon(ctEnglishAddress1Index).SetFocus
		//        mOtherMasterDetailsTabClicked = True
		//    Case mPricingDetails
		//        Call ShowPricingDetails(True)
		//        mPricingDetailsTabClicked = True
		//    Case mMasterDefaults
		//        If txtCommon(ctDefaultSalesmanNoIndex).Visible = True Then
		//            txtCommon(ctDefaultSalesmanNoIndex).SetFocus
		//        Else
		//            txtCommon(ctDefaultCostCenterNoIndex).SetFocus
		//        End If
		//        mMasterDefaultsTabClicked = True
		//End Select
		//
		//DoEvents
		//
		//Exit Sub
		//
		//eIgnoreError:
		//'do not handle this error here
		//
		//
		//End Sub


		private void tabMaster_SelectedChanged(Object eventSender, AxXtremeSuiteControls._DTabControlEvents_SelectedChangedEvent eventArgs)
		{
			try
			{

				switch(tabMaster.SelectedItem)
				{
					case mBasicMasterDetails : 
						if (mFormIsInitialized)
						{
							txtCommon[ctGroupNoIndex].Focus();
						} 
						mBasicMasterDetailsTabClicked = true; 
						//    Case mOtherMasterDetails 
						//        txtCommon(ctEnglishAddress1Index).SetFocus 
						//        mOtherMasterDetailsTabClicked = True 
						break;
					case mPricingDetails : 
						ShowPricingDetails(true); 
						mPricingDetailsTabClicked = true; 
						break;
					case mMasterDefaults : 
						if (txtCommon[ctDefaultSalesmanNoIndex].Visible)
						{
							txtCommon[ctDefaultSalesmanNoIndex].Focus();
						}
						else
						{
							if (txtCommon[ctDefaultCostCenterNoIndex].Visible)
							{
								tabMaster.SelectedItem = mMasterDefaults;
								txtCommon[ctDefaultCostCenterNoIndex].Focus();
							}
						} 
						mMasterDefaultsTabClicked = true; 
						break;
					case mCustomerSupport : 
						ShowCustomerSupportDetails(true); 
						mCustomerSupportTabClicked = true; 
						break;
				}
			}
			catch
			{

				//do not handle this error here
			}
		}

		private void txtCommon_DropButtonClick(Object Sender, EventArgs e)
		{
			int Index = Array.IndexOf(this.txtCommon, Sender);
			if (Index == ctLedgerNoIndex)
			{
				GetNextNumber();
				txtCommon[ctLedgerNoIndex].Focus();
			}
			else
			{
				FindRoutine("txtCommon#" + Index.ToString().Trim());
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

				if (Index == ctGroupNoIndex)
				{
					GroupNoLostFocus();
				}
				else
				{
					switch(Index)
					{
						case ctCurrencyNoIndex : 
							mysql = "select l_curr_name, a_curr_name, curr_cd from gl_currency where show = 1 and curr_no=" + txtCommon[Index].Text; 
							mLinkedTextBoxIndex = ctlCurrencyNameIndex; 
							break;
						case ctDefaultCostCenterNoIndex : 
							mysql = "select l_cost_name, a_cost_name, cost_cd from gl_cost_centers where show = 1 and cost_no=" + txtCommon[Index].Text; 
							mLinkedTextBoxIndex = ctlDefaultCostCenterNameIndex; 
							break;
						case ctDefaultSalesmanNoIndex : 
							mysql = "select l_sman_name, a_sman_name, sman_cd from SM_Salesman where show = 1 and sman_no=" + txtCommon[Index].Text; 
							mLinkedTextBoxIndex = ctlDefaultSalesmanNameIndex; 
							break;
						case ctDefaultPaymentModeIndex : 
							mysql = "select l_pay_mode_name, a_pay_mode_name, pay_mode_cd from ICS_Payment_Modes where show = 1 and pay_mode_cd=" + txtCommon[Index].Text; 
							mLinkedTextBoxIndex = ctlDefaultPaymentModeNameIndex; 
							break;
						case ctAccountTypeCodeIndex : 
							mysql = "select l_type_name, a_type_name, type_cd from gl_accnt_types where show = 1 and type_cd =" + txtCommon[Index].Text; 
							mLinkedTextBoxIndex = ctlAccountTypeName; 
							break;
						default:
							return;
					}

					if (!SystemProcedure2.IsItEmpty(txtCommon[Index].Text))
					{
						//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
						if (Convert.IsDBNull(mTempValue))
						{
							txtCommonLable[mLinkedTextBoxIndex].Text = "";
							txtCommon[Index].Tag = "";
							throw new System.Exception("-9990002");
						}
						else
						{
							txtCommonLable[mLinkedTextBoxIndex].Text = ReflectionHelper.GetPrimitiveValue<string>((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? ((Array) mTempValue).GetValue(0) : ((Array) mTempValue).GetValue(1));
							txtCommon[Index].Tag = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(2));

							//Commented By: Moiz Hakimi. 23/12/2007. To Fill Default Values in Ledger Form Based on Menu Item Clicked
							//-------------------------------------------------------------------------------------------------
							//            If Index = ctAccountTypeCodeIndex Then
							//                Call ShowHideMasterDetails
							//            End If
							//-------------------------------------------------------------------------------------------------
						}
					}
					else
					{
						txtCommonLable[mLinkedTextBoxIndex].Text = "";
						txtCommon[Index].Tag = "";
					}
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
					txtCommon[Index].Focus();
				}
				else
				{
					//
				}
			}
		}

		private void GroupNoLostFocus(int pCallType = 0)
		{
			object mTempValue = null;
			string mysql = "";

			try
			{

				if (!SystemProcedure2.IsItEmpty(txtCommon[ctGroupNoIndex].Text))
				{
					mysql = " select cg.l_group_name, cg.a_group_name, cg.group_cd, cg.show,  ";
					mysql = mysql + " pg.l_group_name, pg.a_group_name from gl_accnt_group cg ";
					mysql = mysql + " left join gl_accnt_group pg on cg.m_group_cd = pg.group_cd ";
					mysql = mysql + " where cg.group_no = '" + txtCommon[ctGroupNoIndex].Text + "'";
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));

					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (Convert.IsDBNull(mTempValue))
					{
						txtCommonLable[ctlGroupNameIndex].Text = "";
						txtCommon[ctGroupNoIndex].Tag = "";
						if (!txtCommon[ctGroupNoIndex].Enabled)
						{
							txtCommon[ctGroupNoIndex].Enabled = true;
							txtCommon[ctGroupNoIndex].Text = "";
							tabMaster.SelectedItem = 0;
							txtCommon[ctGroupNoIndex].Focus();
						}
						throw new System.Exception("-9990002");
					}
					else
					{
						//If mTempValue(3) = vbFalse Or mTempValue(2) = gAccountsParentGroupCode Then
						//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
						if (((TriState) ReflectionHelper.GetPrimitiveValue<int>(((Array) mTempValue).GetValue(3))) == TriState.False)
						{
							txtCommonLable[ctlGroupNameIndex].Text = "";
							txtCommon[ctGroupNoIndex].Tag = "";
							throw new System.Exception("-9990002");
						}
						else
						{
							if (SystemVariables.gPreferedLanguage == SystemVariables.Language.English)
							{
								//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
								txtCommonLable[ctlGroupNameIndex].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(0));
								lblCommon[clParentGroupNameIndex].Caption = mBracketOpener + ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(4)) + mBracketCloser;
							}
							else
							{
								//UPGRADE_WARNING: (1068) mTempValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
								txtCommonLable[ctlGroupNameIndex].Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(1));
								lblCommon[clParentGroupNameIndex].Caption = mBracketOpener + ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(5)) + mBracketCloser;
							}
							txtCommon[ctGroupNoIndex].Tag = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempValue).GetValue(2));
						}
					}
				}
				else
				{
					txtCommonLable[ctlGroupNameIndex].Text = "";
					txtCommon[ctGroupNoIndex].Tag = "";
				}

				//If pCallType = 0 Then
				//    Call ShowHideMasterDetails
				//
				//    On Error Resume Next
				//    If txtCommon(ctCurrencyNoIndex).Visible = True And Me.ActiveControl.Name = "txtComment" Then
				//        txtCommon(ctCurrencyNoIndex).SetFocus
				//    End If
				//End If
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
					txtCommon[ctGroupNoIndex].Focus();
				}
				else
				{
					//
				}
			}

		}

		private void chkPriceRestriction_CheckStateChanged(Object eventSender, EventArgs eventArgs)
		{
			int Index = Array.IndexOf(this.chkPriceRestriction, eventSender);

			bool ShowSetting = chkPriceRestriction[Index].CheckState != CheckState.Unchecked;
			if (Index == ckEnableSalesPriceRestrictionIndex)
			{
				//**--set enable/disable setting for sales price restriction options
				lblCommon[clMaximumSalesPriceIndex].Visible = ShowSetting;
				lblCommon[clMinimumSalesPriceIndex].Visible = ShowSetting;
				lblCommon[clMaximumSalesProductDiscountIndex].Visible = ShowSetting;
				lblCommon[clMaximumSalesVoucherDiscountIndex].Visible = ShowSetting;
				cmbPriceLevel[ccMaximumSalesPriceLevelIndex].Visible = ShowSetting;
				cmbPriceLevel[ccMinimumSalesPriceLevelIndex].Visible = ShowSetting;
				txtCommonNumber[cnMaximumSalesProductDiscountIndex].Visible = ShowSetting;
				txtCommonNumber[cnMaximumSalesVoucherDiscountIndex].Visible = ShowSetting;
			}
			else if (Index == ckEnablePurchasePriceRestrictionIndex)
			{ 
				//**--set enable/disable setting for purchase price restriction options
				lblCommon[clMaximumPurchasePriceIndex].Visible = ShowSetting;
				lblCommon[clMinimumPurchasePriceIndex].Visible = ShowSetting;
				lblCommon[clMaximumPurchaseProductDiscountIndex].Visible = ShowSetting;
				lblCommon[clMaximumPurchaseVoucherDiscountIndex].Visible = ShowSetting;
				cmbPriceLevel[ccMaximumPurchasePriceLevelIndex].Visible = ShowSetting;
				cmbPriceLevel[ccMinimumPurchasePriceLevelIndex].Visible = ShowSetting;
				txtCommonNumber[cnMaximumPurchaseProductDiscountIndex].Visible = ShowSetting;
				txtCommonNumber[cnMaximumPurchaseVoucherDiscountIndex].Visible = ShowSetting;
			}
		}

		private void FillPriceLevelComboBoxes()
		{
			object[] mObjectId = new object[6];

			mObjectId[ccSalesPriceLevelIndex] = 1014;
			mObjectId[ccMaximumSalesPriceLevelIndex] = 1014;
			mObjectId[ccMinimumSalesPriceLevelIndex] = 1014;

			mObjectId[ccPurchasePriceLevelIndex] = 1015;
			mObjectId[ccMaximumPurchasePriceLevelIndex] = 1015;
			mObjectId[ccMinimumPurchasePriceLevelIndex] = 1015;

			SystemCombo.FillComboWithSystemObjects(cmbPriceLevel, mObjectId);
		}

		private void ShowPricingDetails(bool AttempToSetFocus = true)
		{

			string cGridColor = (0xB9E6E2).ToString();

			string mysql = "";

			int cnt = 0;

			SqlDataReader rsLocalRec = null;

			//If AttempToSetFocus = False Then

			if (cmbPriceLevel[0].ListCount == 0)
			{
				//**--fill price level combo boxes and set their initial item to 0
				FillPriceLevelComboBoxes();
			}

			if (!mPricingDetailsTabClicked)
			{
				mPricingDetailsTabClicked = true;

				if (!mPricingDetailsFirstClicked)
				{
					mPricingDetailsFirstClicked = true;

					SystemGrid.DefineSystemVoucherGrid(grdPriceDetails, true, true, true, (0xFFFFFF).ToString(), (0x0).ToString(), true, false, C1.Win.C1TrueDBGrid.MarqueeEnum.FloatingEditor, 1.47f, 1.4f, cGridColor);
					//define voucher grid columns
					//Call DefineSystemVoucherGridColumn(grdSupplierDetails, "LN", 400, False, gDisableColumnBackColor, , , False)
					SystemGrid.DefineSystemVoucherGridColumn(grdPriceDetails, "Voucher Type", 1200, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, true, true, "cmbPriceList");
					SystemGrid.DefineSystemVoucherGridColumn(grdPriceDetails, "Voucher Name", 3000, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, true, true, "cmbPriceList");
					SystemGrid.DefineSystemVoucherGridColumn(grdPriceDetails, "Price", 1000, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, true, true, "cmbPriceList");
					SystemGrid.DefineSystemVoucherGridColumn(grdPriceDetails, "Price Name", 3000, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, true, true, "cmbPriceList");
				}

				aProductPriceDetails = new XArrayHelper();

				if (CurrentFormMode == SystemVariables.SystemFormModes.frmEditMode)
				{

					mysql = "select  plad.price_list_cd,pl.price_list_no,plad.voucher_type, ";
					mysql = mysql + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "pl.price_list_l_name" : "pl.price_list_a_name") + " as price_name, ";
					mysql = mysql + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "v.l_voucher_name" : "v.a_voucher_name") + " as Voucher_name ";
					mysql = mysql + " from  ics_price_list_assigned_details plad ";
					mysql = mysql + " inner join ics_price_list pl on plad.price_list_cd = pl.price_list_cd ";
					mysql = mysql + " inner join ICS_Transaction_Types v on plad.voucher_type = v.voucher_type ";
					mysql = mysql + " where plad.ldgr_cd = " + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);

					SqlCommand sqlCommand = new SqlCommand(mysql, SystemVariables.gConn);
					rsLocalRec = sqlCommand.ExecuteReader();
					rsLocalRec.Read();

					SystemGrid.DefineVoucherArray(aProductPriceDetails, mMaxPriceDetailArrayCols, -1, true);


					do 
					{
						SystemGrid.DefineVoucherArray(aProductPriceDetails, mMaxPriceDetailArrayCols, cnt, false);

						aProductPriceDetails.SetValue(rsLocalRec["Voucher_Type"], cnt, ckVoucherIndex);
						aProductPriceDetails.SetValue(rsLocalRec["Voucher_name"], cnt, ckVoucherNameIndex);
						aProductPriceDetails.SetValue(rsLocalRec["Price_List_No"], cnt, ckPriceListIndex);
						aProductPriceDetails.SetValue(Convert.ToString(rsLocalRec["Price_name"]) + "", cnt, ckPNameNameIndex);

						cnt++;
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
			}

			//**------------------------------------------------------------------------------------------
			//End If
			chkPriceRestriction_CheckStateChanged(chkPriceRestriction[ckEnableSalesPriceRestrictionIndex], new EventArgs());
			chkPriceRestriction_CheckStateChanged(chkPriceRestriction[ckEnablePurchasePriceRestrictionIndex], new EventArgs());

			if (AttempToSetFocus)
			{
				if (cmbPriceLevel[ccSalesPriceLevelIndex].Visible)
				{
					cmbPriceLevel[ccSalesPriceLevelIndex].Focus();
				}
				else
				{
					cmbPriceLevel[ccPurchasePriceLevelIndex].Focus();
				}
			}

		}

		private void ShowCustomerSupportDetails(bool AttempToSetFocus = true)
		{

			string cGridColor = (0xB9E6E2).ToString();
			string mysql = "";
			int cnt = 0;
			SqlDataReader rsLocalRec = null;

			if (!mCustomerSupportTabClicked)
			{
				mCustomerSupportTabClicked = true;

				if (!mCustomerSupportFirstClicked)
				{
					mCustomerSupportFirstClicked = true;

					SystemGrid.DefineSystemVoucherGrid(grdCustomerFeedback, true, true, true, (0xFFFFFF).ToString(), (0x0).ToString(), true, false, C1.Win.C1TrueDBGrid.MarqueeEnum.FloatingEditor, 1.47f, 1.4f, cGridColor);
					//define voucher grid columns
					SystemGrid.DefineSystemVoucherGridColumn(grdCustomerFeedback, "LN", 400, false, (0xD5D5D5).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false);
					SystemGrid.DefineSystemVoucherGridColumn(grdCustomerFeedback, "Date", 1300, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, "Total", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, true, false, false, false, false, 100, "", "", false, "txtTempDate");
					SystemGrid.DefineSystemVoucherGridColumn(grdCustomerFeedback, "Remarks", 5000, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, true, true, "", false, true, false, false, false, false, 100, "", SystemConstants.gArabicFontName);

					txtTempDate.AlignHorizontal = TDBDate6.dbiAlignHConst.dbiAlignHLeft;
					txtTempDate.AlignVertical = TDBDate6.dbiAlignVConst.dbiAlignVCenter;
					txtTempDate.Appearance = TDBDate6.dbiAppearanceConst.dbiFlat;
					txtTempDate.BorderStyle = TDBDate6.dbiBorderStyleConst.dbiNoBorder;
					txtTempDate.CenturyMode = TDBDate6.dbiCenturyModeConst.dbiCurrentCentury;
					txtTempDate.Calendar.SelectStyle = TDBDate6.dbiCalndrSelStyleConst.dbiCalSelStyleFlatBtn;
					txtTempDate.Calendar.WeekTitles = "F,S,S,M,T,W,T";
					txtTempDate.CenturyMode = TDBDate6.dbiCenturyModeConst.dbiSystemCentury;
					txtTempDate.DisplayFormat = SystemVariables.gSystemDateFormat;
					txtTempDate.DropDown.Visible = TDBDate6.dbiVisibleConst.dbiShowOnFocus;
					txtTempDate.Format = SystemVariables.gSystemDateFormat;
				}

				aCustomerFeedbackDetails = new XArrayHelper();

				if (CurrentFormMode == SystemVariables.SystemFormModes.frmEditMode)
				{

					mysql = "select  cf.Entry_Id, cf.ldgr_cd, cf.CallDate, cf.Remarks";
					mysql = mysql + " from  GL_Ledger_Customer_Feedback cf ";
					mysql = mysql + " where cf.ldgr_cd = " + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);

					SqlCommand sqlCommand = new SqlCommand(mysql, SystemVariables.gConn);
					rsLocalRec = sqlCommand.ExecuteReader();
					rsLocalRec.Read();

					SystemGrid.DefineVoucherArray(aCustomerFeedbackDetails, mMaxCustomerFeedbackArrayCols, -1, true);


					do 
					{
						SystemGrid.DefineVoucherArray(aCustomerFeedbackDetails, mMaxCustomerFeedbackArrayCols, cnt, false);

						aCustomerFeedbackDetails.SetValue(cnt + 1, cnt, cfLineNoIndex);
						aCustomerFeedbackDetails.SetValue(rsLocalRec["CallDate"], cnt, cfDateIndex);
						aCustomerFeedbackDetails.SetValue(rsLocalRec["Remarks"], cnt, cfRemarkIndex);

						cnt++;
					}
					while(rsLocalRec.Read());


					rsLocalRec.Close();
				}
				else
				{
					SystemGrid.DefineVoucherArray(aCustomerFeedbackDetails, mMaxCustomerFeedbackArrayCols, -1, true);
				}

				//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBGrid property grdCustomerFeedback.Array was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
				grdCustomerFeedback.setArray(aCustomerFeedbackDetails);
				//Call AssignSupplierGridLineNumbers
				grdCustomerFeedback.Rebind(true);
			}

			//**------------------------------------------------------------------------------------------
			//End If
		}
		private void GetNextLedgerNoInGroup(string pGroupCode)
		{
			object mReturnValue = null;
			string mVal1 = "";
			string mysql = "";

			if (!ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("allow_alpha_numeric_ldgr_no")))
			{
				mysql = " select group_cd from gl_accnt_group where group_no = " + pGroupCode;
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(mReturnValue))
				{
					mysql = " group_cd =" + ReflectionHelper.GetPrimitiveValue<string>(mReturnValue);
					mVal1 = SystemProcedure2.GetNewNumber("gl_ledger", "ldgr_no", 2, mysql);
					if (StringsHelper.ToDoubleSafe(mVal1) == 1)
					{
						txtCommon[ctLedgerNoIndex].Text = pGroupCode + mVal1;
					}
					else
					{
						txtCommon[ctLedgerNoIndex].Text = mVal1;
					}
				}
			}


			//If Not IsItEmpty(pGroupCode, NumberType) Then
			//    mGroupCode = GetMasterCode("select group_cd from gl_accnt_group where group_no = " & pGroupCode)
			//    If IsNull(mGroupCode) = False Then
			//        If Not IsItEmpty(pGroupCode, StringType) Then
			//            Call GetNextNumber(" group_cd = '" & mGroupCode & "'")
			//        End If
			//    End If
			//End If
		}

		bool mFirstTime_ShowHideMasterDetails = false;
		private void ShowHideMasterDetails()
		{
			bool ShowSetting = false;
			//Dim mGroupType As Variant

			ShowSetting = CurrentFormMode != SystemVariables.SystemFormModes.frmAddMode;
			lblCommon[clTotalNoOfTransactionIndex].Visible = ShowSetting;
			//fraLedgerInformation(cfLedgerBalanceIndex).Visible = ShowSetting

			//''commented by Moiz Hakimion 04-jun-2007 inorder to allow user to change type code
			//txtCommon(ctAccountTypeCodeIndex).Enabled = Not ShowSetting

			lblCommon[clParentGroupNameIndex].Visible = !SystemProcedure2.IsItEmpty(txtCommon[ctGroupNoIndex].Text, SystemVariables.DataType.NumberType);

			//'''added by Moiz Hakimion 15-nov-2006
			//'''this was done to enable foreign currency for all the account
			//If Val(txtCommon(ctAccountTypeCodeIndex).Tag) = gGLCustomerVendorTypeCode Then
			//    ShowSetting = True
			//Else
			//    ''''added by Moiz Hakimion 02-oct-2005
			//    ''''this was done for UIC as they have bank and cash in foreign currency.
			//    ''''do not enable this feature for clients using inventory module.
			//    If Val(txtCommon(ctAccountTypeCodeIndex).Tag) = gGLBankTypeCode Then
			//        If GetSystemPreferenceSetting("enable_foreign_currency_for_bank") = True Then
			//            ShowSetting = True
			//        End If
			//    Else
			//        ShowSetting = False
			//    End If
			//End If
			ShowSetting = true;

			//**--new changes : 06-jun-2003
			//**--modified by : Moiz Hakimi
			if (!txtCommon[ctCurrencyNoIndex].Visible && ShowSetting)
			{
				if (SystemProcedure2.IsItEmpty(txtCommon[ctCurrencyNoIndex].Text, SystemVariables.DataType.StringType))
				{
					txtCommon[ctCurrencyNoIndex].Text = SystemGLConstants.gDefaultCurrencyCd.ToString();
				}
			}
			//**------------------------------------------

			lblCommon[clCurrencyCodeIndex].Visible = ShowSetting;
			lblCommon[clCreditLimitIndex].Visible = ShowSetting;
			lblCommon[clCreditDaysIndex].Visible = ShowSetting;
			txtCommon[ctCurrencyNoIndex].Visible = ShowSetting;
			txtCommonLable[ctlCurrencyNameIndex].Visible = ShowSetting;
			txtCreditLimit.Visible = ShowSetting;
			txtCreditDays.Visible = ShowSetting;
			//Call ChangeTabPageStatus(mOtherMasterDetails, ShowSetting)

			//**--new changes : 29-may-2003
			//**--modified by : Moiz Hakimi
			ChangeTabPageStatus(mPricingDetails, ShowSetting);

			if (!mFirstTime_ShowHideMasterDetails)
			{
				//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				if (((TriState) ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetSystemPreferenceSetting("show_pricing_details_tab_in_ledger"))) == TriState.True)
				{
					tabMaster.Item(mPricingDetails).Visible = TriState.True != TriState.False;
					//**--set show/hide setting for sales price restriction options
					//UPGRADE_WARNING: (1068) GetSystemPreferenceSetting() of type Variant is being forced to bool. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					ShowSetting = ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("show_sales_price_restrictions_in_ledger"));
					chkPriceRestriction[ckEnableSalesPriceRestrictionIndex].Visible = ShowSetting;
					lblCommon[clMaximumSalesPriceIndex].Visible = ShowSetting;
					lblCommon[clMinimumSalesPriceIndex].Visible = ShowSetting;
					lblCommon[clMaximumSalesProductDiscountIndex].Visible = ShowSetting;
					lblCommon[clMaximumSalesVoucherDiscountIndex].Visible = ShowSetting;
					cmbPriceLevel[ccMaximumSalesPriceLevelIndex].Visible = ShowSetting;
					cmbPriceLevel[ccMinimumSalesPriceLevelIndex].Visible = ShowSetting;
					txtCommonNumber[cnMaximumSalesProductDiscountIndex].Visible = ShowSetting;
					txtCommonNumber[cnMaximumSalesVoucherDiscountIndex].Visible = ShowSetting;
					//**--set show/hide setting for purchase price restriction options
					//UPGRADE_WARNING: (1068) GetSystemPreferenceSetting() of type Variant is being forced to bool. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					ShowSetting = ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("show_purchase_price_restrictions_in_ledger"));
					chkPriceRestriction[ckEnablePurchasePriceRestrictionIndex].Visible = ShowSetting;
					lblCommon[clMaximumPurchasePriceIndex].Visible = ShowSetting;
					lblCommon[clMinimumPurchasePriceIndex].Visible = ShowSetting;
					lblCommon[clMaximumPurchaseProductDiscountIndex].Visible = ShowSetting;
					lblCommon[clMaximumPurchaseVoucherDiscountIndex].Visible = ShowSetting;
					cmbPriceLevel[ccMaximumPurchasePriceLevelIndex].Visible = ShowSetting;
					cmbPriceLevel[ccMinimumPurchasePriceLevelIndex].Visible = ShowSetting;
					txtCommonNumber[cnMaximumPurchaseProductDiscountIndex].Visible = ShowSetting;
					txtCommonNumber[cnMaximumPurchaseVoucherDiscountIndex].Visible = ShowSetting;
				}
				else
				{
					tabMaster.Item(mPricingDetails).Visible = TriState.False != TriState.False;
					//tabMaster.ItemCount = tabMaster.ItemCount - 1
				}

				//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				if (((TriState) ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetSystemPreferenceSetting("show_defaults_tab_in_ledger"))) == TriState.True)
				{
					tabMaster.Item(mMasterDefaults).Visible = TriState.True != TriState.False;
				}
				else
				{
					tabMaster.Item(mMasterDefaults).Visible = TriState.False != TriState.False;
					//tabMaster.ItemCount = tabMaster.ItemCount - 1
				}

				//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				if (((TriState) ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetSystemPreferenceSetting("show_customer_support_tab_in_ledger"))) == TriState.True)
				{
					tabMaster.Item(mCustomerSupport).Visible = TriState.True != TriState.False;
				}
				else
				{
					tabMaster.Item(mCustomerSupport).Visible = TriState.False != TriState.False;
					//tabMaster.ItemCount = tabMaster.ItemCount - 1
				}

				//UPGRADE_WARNING: (1068) GetSystemPreferenceSetting() of type Variant is being forced to bool. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				ShowSetting = ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("show_arabic_address_in_ledger"));
				lblCommon[clArabicAddress1Index].Visible = ShowSetting;
				lblCommon[clArabicAddress2Index].Visible = ShowSetting;
				lblCommon[clArabicAddress3Index].Visible = ShowSetting;
				txtCommon[ctArabicAddress1Index].Visible = ShowSetting;
				txtCommon[ctArabicAddress2Index].Visible = ShowSetting;
				txtCommon[ctArabicAddress3Index].Visible = ShowSetting;

				//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				if (((TriState) ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetSystemPreferenceSetting("cost_center"))) == TriState.True)
				{
					//UPGRADE_WARNING: (1068) GetSystemPreferenceSetting() of type Variant is being forced to bool. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					ShowSetting = ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("show_default_cost_center_in_ledger"));
				}
				else
				{
					ShowSetting = false;
				}
				lblCommon[clDefaultCostCenter].Visible = ShowSetting;
				txtCommon[ctDefaultCostCenterNoIndex].Visible = ShowSetting;
				txtCommonLable[ctlDefaultCostCenterNameIndex].Visible = ShowSetting;

			}

			//**--set show/hide setting for cost center options

			//**--modified by : Moiz Hakimi
			//**--modified date : 14-feb-2004
			//**--note : to enable cost center on all (e.g. sales account) income & expense group type
			//**--       rather then just Income & Expenses predefined groups

			//mGroupType = GetMasterCode("select group_type from gl_accnt_group where group_cd = '" & txtCommon(ctGroupNoIndex).Tag & "'")
			//If IsItEmpty(mGroupType, NumberType) Then
			//    mGroupType = 0
			//End If

			//If Val(txtCommon(ctAccountTypeCodeIndex).Tag) <> gGLCustomerVendorTypeCode Then
			//    Call ChangeTabPageStatus(mMasterDefaults, False)
			//Else
			ChangeTabPageStatus(mMasterDefaults, true);
			//End If

			//**--in case the record is protected by the system
			//**--do not allow the parent to be changed
			//--**check if the form type is normal ledger a/c or customer or supplier
			if (FormCallType == 0)
			{
				if (CurrentFormMode == SystemVariables.SystemFormModes.frmEditMode)
				{
					//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
					if (((TriState) ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetMasterCode("select protected from gl_ledger where ldgr_cd =" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue)))) == TriState.True)
					{
						//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
						ShowSetting = SystemVariables.gXtremeAdminLoggedIn && ((TriState) ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetSystemPreferenceSetting("enable_admin_role"))) == TriState.True;
					}
					else
					{
						ShowSetting = true;
					}

				}
				else
				{
					ShowSetting = true;
				}
			}
			else if (FormCallType == 1)
			{ 
				//txtCommon(ctGroupNoIndex).Text = GetMasterCode("select group_no from gl_accnt_group where group_cd = '" & IIf(FormCallType = 1, gGLCustomerVendorTypeCode, gGLCustomerVendorTypeCode) & "'")
				//Call GroupNoLostFocus(1)
				txtCommon[ctAccountTypeCodeIndex].Text = SystemGLConstants.gGLCustomerVendorTypeCode.ToString();

				txtCommon[ctAccountTypeCodeIndex].Visible = false;
				txtCommonLable[ctlAccountTypeName].Visible = false;
				lblCommon[clAccntTypeCode].Visible = false;

				txtCommon_Leave(txtCommon[ctAccountTypeCodeIndex], new EventArgs());

				//'added by Moiz Hakimi. Date: 06-apr-2008
				//UPGRADE_WARNING: (1068) GetSystemPreferenceSetting() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				txtCommon[ctGroupNoIndex].Text = ReflectionHelper.GetPrimitiveValue<string>(SystemProcedure2.GetSystemPreferenceSetting("default_group_code_in_gl_ledger"));
				cmbDrCrType.Text = "Dr";
				//txtCommon(ctGroupNoIndex).Enabled = False
				txtCommon_Leave(txtCommon[ctGroupNoIndex], new EventArgs());

			}
			else
			{
				txtCommon[ctAccountTypeCodeIndex].Text = SystemGLConstants.gGLCustomerVendorTypeCode.ToString();
				txtCommon[ctAccountTypeCodeIndex].Visible = false;
				txtCommonLable[ctlAccountTypeName].Visible = false;
				lblCommon[clAccntTypeCode].Visible = false;
				txtCommon_Leave(txtCommon[ctAccountTypeCodeIndex], new EventArgs());

				//'added by Moiz Hakimi. Date: 03-apr-2010
				//UPGRADE_WARNING: (1068) GetSystemPreferenceSetting() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				txtCommon[ctGroupNoIndex].Text = ReflectionHelper.GetPrimitiveValue<string>(SystemProcedure2.GetSystemPreferenceSetting("default_supplier_code_in_gl_ledger"));
				cmbDrCrType.Text = "Cr";
				//txtCommon(ctGroupNoIndex).Enabled = False
				txtCommon_Leave(txtCommon[ctGroupNoIndex], new EventArgs());
			}

			//**--set show/hide setting for default SM_Salesman options
			//ShowSetting = GetSystemPreferenceSetting("show_default_salesman_in_ledger") And (Left(txtCommon(ctGroupNoIndex).Tag, 4) = Left(gGLCustomerVendorTypeCode, 4) Or Left(txtCommon(ctGroupNoIndex).Tag, 4) = Left(gGLCustomerVendorTypeCode, 4))
			ShowSetting = (ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetSystemPreferenceSetting("show_default_salesman_in_ledger")) & ((Conversion.Val(txtCommon[ctAccountTypeCodeIndex].Text) == SystemGLConstants.gGLCustomerVendorTypeCode) ? -1 : 0)) != 0;
			lblCommon[clDefaultSalesman].Visible = ShowSetting;
			txtCommon[ctDefaultSalesmanNoIndex].Visible = ShowSetting;
			txtCommonLable[ctlDefaultSalesmanNameIndex].Visible = ShowSetting;
			//**--set show/hide setting for default payment mode options
			//ShowSetting = GetSystemPreferenceSetting("show_default_pay_mode_in_ledger") And (Left(txtCommon(ctGroupNoIndex).Tag, 4) = Left(gGLCustomerVendorTypeCode, 4) Or Left(txtCommon(ctGroupNoIndex).Tag, 4) = Left(gGLCustomerVendorTypeCode, 4))
			ShowSetting = (ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetSystemPreferenceSetting("show_default_pay_mode_in_ledger")) & ((Conversion.Val(txtCommon[ctAccountTypeCodeIndex].Text) == SystemGLConstants.gGLCustomerVendorTypeCode) ? -1 : 0)) != 0;
			lblCommon[clDefaultPayMode].Visible = ShowSetting;
			txtCommon[ctDefaultPaymentModeIndex].Visible = ShowSetting;
			txtCommonLable[ctlDefaultPaymentModeNameIndex].Visible = ShowSetting;

			//----------------------------------added By Moiz Hakimi---03-Apr-2010-------------------------------------
			if (CurrentFormMode == SystemVariables.SystemFormModes.frmAddMode && txtCommon[ctDefaultCostCenterNoIndex].Visible && txtCommon[ctDefaultCostCenterNoIndex].Text == "")
			{
				//UPGRADE_WARNING: (1068) GetSystemPreferenceSetting() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				txtCommon[ctDefaultCostCenterNoIndex].Text = ReflectionHelper.GetPrimitiveValue<string>(SystemProcedure2.GetSystemPreferenceSetting("default_cost_center_code"));
			}
			//---------------------------------------------------------------------------------------------------------
			//txtCommon(ctGroupNoIndex).Enabled = ShowSetting

			if (!mFirstTime_ShowHideMasterDetails)
			{
				mFirstTime_ShowHideMasterDetails = true;
			}
		}

		private void RecordNavidate(int pKeyCode, int pLdgrCd)
		{

			tabMaster.SelectedItem = mBasicMasterDetails;
			string mysql = " select top 1 ldgr_cd from gl_ledger ";
			mysql = mysql + " where 1=1 ";
			if (pLdgrCd > 0 && pKeyCode == 37)
			{
				mysql = mysql + " and ldgr_cd < " + pLdgrCd.ToString();
			}
			else if (pLdgrCd > 0 && pKeyCode == 39)
			{ 
				mysql = mysql + " and ldgr_cd > " + pLdgrCd.ToString();
			}

			if (pKeyCode == 37)
			{
				mysql = mysql + " order by ldgr_cd desc ";
			}
			else if (pKeyCode == 39)
			{ 
				mysql = mysql + " order by ldgr_cd asc ";
			}

			//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(mReturnValue))
			{
				GetRecord(mReturnValue);
			}

		}

		public void ORoutine()
		{

			if (!UserAccess.AllowUserDisplay)
			{
				MessageBox.Show(SystemConstants.msg8, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			RecordNavidate(39, mRecordNavigateSearchValue);
		}

		public void MRoutine()
		{

			if (!UserAccess.AllowUserDisplay)
			{
				MessageBox.Show(SystemConstants.msg8, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			RecordNavidate(37, mRecordNavigateSearchValue);

		}

		private bool IsColumnDuplicate(int Col)
		{
			int cnt = 0;
			int Result = 0;
			string SearchText = "";

			XArrayHelper withVar = null;
			withVar = aProductPriceDetails;
			int tempForEndVar = aProductPriceDetails.GetLength(0) - 2;
			for (cnt = 0; cnt <= tempForEndVar; cnt++)
			{
				SearchText = Convert.ToString(aProductPriceDetails.GetValue(cnt, Col));
				if (SearchText != "")
				{
					Result = withVar.Find(SearchText, cnt + 1, Col);
					if (Result > 0)
					{
						grdPriceDetails.Row = cnt;
						grdPriceDetails.Col = Col;
						return true;
					}
				}
			}
			return false;
		}

		public void LRoutine()
		{

			if (ActiveControl.Name == "grdPriceDetails")
			{
				grdPriceDetails.Focus();

				if (aProductPriceDetails.GetLength(0) > 0)
				{
					grdPriceDetails.Delete();
					grdPriceDetails.Rebind(true);
					grdPriceDetails.Focus();
					grdPriceDetails.Refresh();
				}
			}

			if (ActiveControl.Name == "grdCustomerFeedback")
			{
				grdCustomerFeedback.Focus();

				if (aCustomerFeedbackDetails.GetLength(0) > 0)
				{
					grdCustomerFeedback.Delete();
					AssignGridLineNumbers();
					//UPGRADE_ISSUE: (2064) XArrayDBObject.XArrayDB method aCustomerFeedbackDetails.ReBind was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					ReflectionHelper.Invoke(aCustomerFeedbackDetails, "ReBind", new object[]{});
				}
			}

		}

		//UPGRADE_WARNING: (2050) TrueOleDBGrid80.TDBGrid Event grdCustomerFeedback.OnAddNew was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2050
		private void grdCustomerFeedback_OnAddNew()
		{
			if (!mFirstGridFocus)
			{
				grdCustomerFeedback.Columns[cfLineNoIndex].Text = (grdCustomerFeedback.RowCount + 1).ToString();
			}

		}

		private void AssignGridLineNumbers()
		{
			int cnt = 0;
			int tempForEndVar = aCustomerFeedbackDetails.GetLength(0) - 1;
			for (cnt = 0; cnt <= tempForEndVar; cnt++)
			{
				aCustomerFeedbackDetails.SetValue(cnt + 1, cnt, cfLineNoIndex);
			}
		}

		private void ResetAllObjects()
		{
			mPricingDetailsTabClicked = false;
			mCustomerSupportTabClicked = false;

		}

		public void GRoutine()
		{



			object mReturnValue = null;

			int pFormId = 432000;

			if (mCurrentFormMode == SystemVariables.SystemFormModes.frmEditMode && ReflectionHelper.GetPrimitiveValue<double>(mSearchValue) != 0)
			{
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode("select top 1 entry_id from SAL_Sales_Contract where ldgr_cd =" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue)));

				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(mReturnValue))
				{
					if (SystemForms.GetSystemForm(pFormId, 2, mReturnValue))
					{

					}
				}

			}

		}
	}
}