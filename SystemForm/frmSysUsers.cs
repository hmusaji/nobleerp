
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;



namespace Xtreme
{
	internal partial class frmSysUsers
		: System.Windows.Forms.Form
	{

		public frmSysUsers()
{
InitializeComponent();
} 
 public  void frmSysUsers_old()
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


		private void frmSysUsers_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (UpgradeHelpers.Gui.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Gui.ActivateHelper.myActiveForm = (System.Windows.Forms.Form) eventSender;
			}
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

		public Control FirstFocusObject = null;


		private int mThisFormID = 0;
		private clsToolbar oThisFormToolBar = null;
		private object mSearchValue = null;
		private string mTimeStamp = "";
		private SystemVariables.SystemFormModes mCurrentFormMode = (SystemVariables.SystemFormModes) 0;
		private bool mPricingDetailsTabClicked = false;

		private const int conTabOtherDetails = 0;
		private const int conTabPriceDetails = 1;

		private const int ckEnableSalesPriceRestrictionIndex = 0;
		private const int ckEnablePurchasePriceRestrictionIndex = 1;
		private const int ckRestrictInSalesPriceLevelsIndex = 2;
		private const int ckRestrictInPurchasePriceLevelsIndex = 3;

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


		//This is to Check if the AltUnit tab is clicked for the first time
		//Dim mAltUnitTabSetting As Boolean
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




		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2080
		private void Form_Load()
		{
			string mysql = "";

			try
			{

				this.CurrentFormMode = SystemVariables.SystemFormModes.frmAddMode;
				this.Top = 0;
				this.Left = 0;

				FirstFocusObject = txtUserId;

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

				//'Assign the Image for the toolbar
				//'Imagelist are kept on the main form and refered by their key
				//Call DrawToolbar(Me, picFormToolbar, btnFormToolBar(0))
				//Set btnFormToolBar(0).Picture = frmSysMain.imlMainToolBar.ListImages("imgNew").Picture
				//Set btnFormToolBar(1).Picture = frmSysMain.imlMainToolBar.ListImages("imgSave").Picture
				//Set btnFormToolBar(2).Picture = frmSysMain.imlMainToolBar.ListImages("imgDelete").Picture
				//Set btnFormToolBar(3).Picture = frmSysMain.imlMainToolBar.ListImages("imgPrint").Picture
				//Set btnFormToolBar(4).Picture = frmSysMain.imlMainToolBar.ListImages("imgFind").Picture
				//Set btnFormToolBar(5).Picture = frmSysMain.imlMainToolBar.ListImages("imgHelp").Picture
				//Set btnFormToolBar(8).Picture = frmSysMain.imlMainToolBar.ListImages("imgExit").Picture

				//Fill the use group Combo Box
				mysql = "select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_group_name," : "a_group_name,");
				mysql = mysql + " group_Cd from SM_USER_GROUPS ";
				SystemCombo.FillComboWithItemData(comGroupName, mysql);

				comGroupName.Enabled = true;
				comGroupName.ListIndex = 0;

				chkEnablePayExpRepPop.CheckState = CheckState.Unchecked;
				SqlDataReader rsTmp = null;
				SqlCommand sqlCommand = new SqlCommand("select * from SM_MODULES where module_id = " + SystemConstants.gModuleHRID.ToString(), SystemVariables.gConn);
				rsTmp = sqlCommand.ExecuteReader();
				rsTmp.Read();
				if (Convert.ToBoolean(rsTmp["show"]))
				{
					chkEnablePayExpRepPop.Visible = ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("enable_pay_expiry_document_report_popup"));
				}
				rsTmp.Close();

				//'Added by: Moiz Hakimi. Date:05-apr-2008
				//'Desc: Check either ICS, Purchase or Sales module is enabled then only check box show appear
				SqlCommand sqlCommand_2 = new SqlCommand("select * from SM_MODULES where (module_id = " + SystemConstants.gModulePurchaseID.ToString() + " or  module_id = " + SystemConstants.gModuleICSID.ToString() + " or  module_id = " + SystemConstants.gModuleSalesID.ToString() + ") and show = 1", SystemVariables.gConn);
				rsTmp = sqlCommand_2.ExecuteReader();
				bool rsTmpDidRead2 = rsTmp.Read();
				chkEnableAdvanceModeInICSBatchPosting.Visible = rsTmp.HasRows;
				rsTmp.Close();

				//'Added by: Moiz Hakimi. Date:12-apr-2008
				chkAllowICSNegativeStock.Visible = ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("enable_user_level_negative_stock_check"));

				chkAllowSaleBelowCost.Visible = ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("enable_user_level_sale_below_cost"));

				if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("maintain_stock_levels")))
				{
					chkBelowReorderLevel.Visible = true;
					chkBelowMinimumLevel.Visible = true;
					chkAboveMaximumLevel.Visible = true;
				}
				else
				{
					chkBelowReorderLevel.Visible = false;
					chkBelowMinimumLevel.Visible = false;
					chkAboveMaximumLevel.Visible = false;
				}

				//'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
				//Fill the combo
				object[] mObjectId = new object[1];
				mObjectId[0] = 1017;
				SystemCombo.FillComboWithSystemObjects(cmbCommon, mObjectId);
				if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("is_bilingual")))
				{
					lblPreferredLanguage.Visible = true;
					cmbCommon[0].Visible = true;
				}
				else
				{
					lblPreferredLanguage.Visible = false;
					cmbCommon[0].Visible = false;
				}

				if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("show_user_level_default_sman_no")))
				{
					txtDefaultSmanNo.Visible = true;
					lblDefaultSmanNo.Visible = true;
				}
				else
				{
					txtDefaultSmanNo.Visible = false;
					lblDefaultSmanNo.Visible = false;
				}

				chkEnableCostDetails.Visible = ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("show_user_level_cost_security"));

				//--------------------For Date Security---Moiz Hakimi - 21-Dec-2008--------------
				chkAllowFutureDateTransaction.Visible = ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("show_user_level_date_security"));
				//-------------------------------------------------------------------------------------

				if (ReflectionHelper.GetPrimitiveValue<double>(SystemProcedure2.GetSystemPreferenceSetting("default_price_level_priority_in_sales")) == 1 || ReflectionHelper.GetPrimitiveValue<double>(SystemProcedure2.GetSystemPreferenceSetting("default_price_level_priority_in_purchase")) == 1)
				{
					tabMaster.set_TabVisible(Convert.ToInt16(conTabPriceDetails), TriState.True != TriState.False);
					fraSales.Enabled = ReflectionHelper.GetPrimitiveValue<double>(SystemProcedure2.GetSystemPreferenceSetting("default_price_level_priority_in_sales")) == 1;

					fraPurchase.Enabled = ReflectionHelper.GetPrimitiveValue<double>(SystemProcedure2.GetSystemPreferenceSetting("default_price_level_priority_in_purchase")) == 1;

					FillPriceLevelComboBoxes();
				}
				else
				{
					tabMaster.set_TabVisible(Convert.ToInt16(conTabPriceDetails), TriState.False != TriState.False);
					tabMaster.TabsPerPage = (short) (tabMaster.TabsPerPage - 1);
				}

				tabMaster.CurrTab = Convert.ToInt16(conTabOtherDetails);

				SystemProcedure.SetLabelCaption(this);
				clsFlip oFlipThisForm = null;
				//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
				if (SystemVariables.gPreferedLanguage == SystemVariables.Language.Arabic && ((TriState) ReflectionHelper.GetPrimitiveValue<int>(SystemProcedure2.GetSystemPreferenceSetting("flip_controls_in_arabic"))) == TriState.True)
				{
					oFlipThisForm = new clsFlip();

					oFlipThisForm.SwapMe(this);
				}
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
			SystemProcedure2.ClearTextBox(this);

			comGroupName.Enabled = true;
			mCurrentFormMode = SystemVariables.SystemFormModes.frmAddMode; //Change the form mode to addmode
			mSearchValue = ""; //Change the msearchvalue to blank
			FirstFocusObject.Focus();
			chkEnablePayExpRepPop.CheckState = CheckState.Unchecked;
			chkDisable.CheckState = CheckState.Unchecked;
			chkRestrictOnExceedingCreditLimit.CheckState = CheckState.Unchecked;
			chkEnableAdvanceModeInICSBatchPosting.CheckState = CheckState.Unchecked;
			chkAllowSaleBelowCost.CheckState = CheckState.Unchecked;
			chkAllowICSNegativeStock.CheckState = CheckState.Unchecked;
			chkBelowReorderLevel.CheckState = CheckState.Unchecked;
			chkBelowMinimumLevel.CheckState = CheckState.Unchecked;
			chkAboveMaximumLevel.CheckState = CheckState.Unchecked;

			SystemProcedure2.ClearNumberBox(this);
			SystemProcedure2.ClearCheckBox(this);

			aProductPriceDetails = null;
			grdPriceDetails.Rebind(true);

			tabMaster.CurrTab = Convert.ToInt16(conTabOtherDetails);
			return;

			//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
			SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, Information.Err().Description, this.Name, "AddRecord");
		}

		public bool saveRecord()
		{
			bool result = false;
			int cnt = 0;
			string mysql = "";
			object mReturnValue = null;

			//Save a record
			//During save check for the mode
			//If in addmode then insert a record
			//else update the record in the recordset

			//On Error GoTo eFoundError

			//Get the Parent Group Code

			SystemVariables.gConn.BeginTransaction();
			if (mCurrentFormMode == SystemVariables.SystemFormModes.frmAddMode)
			{
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(" select user_cd from SM_USERS where user_id='" + txtUserId.Text + "'"));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(mReturnValue))
				{
					MessageBox.Show("Duplicate entry not allowed, record already exists", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					SystemVariables.gConn.RollbackTrans();
					txtUserId.Focus();
					return false;
				}

				//Insert a record in the ICS_Item table
				mysql = " INSERT INTO SM_USERS (User_Id, Group_Cd, Password, User_Name ";
				mysql = mysql + " , Addr_1, Addr_2, Phone, Pf , preferred_language ";

				mysql = mysql + " , default_sales_price_level, default_purchase_price_level ";
				mysql = mysql + " , enable_sales_price_restrictions , enable_purchase_price_restrictions";
				mysql = mysql + " , restrict_in_sales_price_levels , restrict_in_purchase_price_levels ";
				mysql = mysql + " , maximum_sales_price_level ";
				mysql = mysql + " , maximum_purchase_price_level ";
				mysql = mysql + " , minimum_sales_price_level ";
				mysql = mysql + " , minimum_purchase_price_level ";
				mysql = mysql + " , maximum_product_sales_discount_in_percent ";
				mysql = mysql + " , maximum_product_purchase_discount_in_percent ";
				mysql = mysql + " , maximum_voucher_sales_discount_in_percent ";
				mysql = mysql + " , maximum_voucher_purchase_discount_in_percent ";
				mysql = mysql + " , default_sman_no ";
				mysql = mysql + " , enable_cost_details ";
				mysql = mysql + " , restrict_on_exceeding_credit_limit ";
				mysql = mysql + " , Disabled, enable_pay_exp_rep_pop, Enable_Advance_Mode_In_ICS_Batch_Post, Allow_ICS_Negative_Stock, Allow_Sale_Below_Cost";
				mysql = mysql + ", Allow_Future_date_Transaction,Show_Message_On_Items_Below_Reorder_Level,Show_Message_On_Items_Below_Minimum_Level";
				mysql = mysql + ", Show_Message_On_Items_Above_Maximum_Level, Access_all_location, Comments) ";
				mysql = mysql + " VALUES(";
				mysql = mysql + "'" + txtUserId.Text + "',";
				mysql = mysql + Conversion.Str(comGroupName.GetItemData(comGroupName.ListIndex)) + ",";
				mysql = mysql + "'" + txtPassword.Text + "',";
				mysql = mysql + "'" + txtUserName.Text + "',";
				mysql = mysql + "'" + txtAddress1.Text + "',";
				mysql = mysql + "'" + txtAddress2.Text + "',";
				mysql = mysql + "'" + txtPhone.Text + "',";
				mysql = mysql + "'" + txtProvidentFund.Text + "'";

				if (cmbCommon[0].GetItemData(cmbCommon[0].ListIndex) == 77)
				{
					mysql = mysql + ",'L'";
				}
				else if (cmbCommon[0].GetItemData(cmbCommon[0].ListIndex) == 78)
				{ 
					mysql = mysql + ",'A'";
				}
				else
				{
					mysql = mysql + ",'L'";
				}

				if (tabMaster.get_TabVisible(Convert.ToInt16(conTabPriceDetails)))
				{
					mysql = mysql + "," + Conversion.Str(cmbPriceLevel[ccSalesPriceLevelIndex].GetItemData(cmbPriceLevel[ccSalesPriceLevelIndex].ListIndex));
					mysql = mysql + "," + Conversion.Str(cmbPriceLevel[ccPurchasePriceLevelIndex].GetItemData(cmbPriceLevel[ccPurchasePriceLevelIndex].ListIndex));

					mysql = mysql + "," + ((int) chkPriceRestriction[ckEnableSalesPriceRestrictionIndex].CheckState).ToString();
					mysql = mysql + "," + ((int) chkPriceRestriction[ckEnableSalesPriceRestrictionIndex].CheckState).ToString();

					mysql = mysql + "," + ((int) chkPriceRestriction[ckRestrictInSalesPriceLevelsIndex].CheckState).ToString();
					mysql = mysql + "," + ((int) chkPriceRestriction[ckRestrictInPurchasePriceLevelsIndex].CheckState).ToString();

					mysql = mysql + "," + Conversion.Str(cmbPriceLevel[ccMaximumSalesPriceLevelIndex].GetItemData(cmbPriceLevel[ccMaximumSalesPriceLevelIndex].ListIndex));
					mysql = mysql + "," + Conversion.Str(cmbPriceLevel[ccMaximumPurchasePriceLevelIndex].GetItemData(cmbPriceLevel[ccMaximumPurchasePriceLevelIndex].ListIndex));

					mysql = mysql + "," + Conversion.Str(cmbPriceLevel[ccMinimumSalesPriceLevelIndex].GetItemData(cmbPriceLevel[ccMinimumSalesPriceLevelIndex].ListIndex));
					mysql = mysql + "," + Conversion.Str(cmbPriceLevel[ccMinimumPurchasePriceLevelIndex].GetItemData(cmbPriceLevel[ccMinimumPurchasePriceLevelIndex].ListIndex));

					mysql = mysql + "," + Conversion.Str(txtCommonNumber[cnMaximumSalesProductDiscountIndex].Value);
					mysql = mysql + "," + Conversion.Str(txtCommonNumber[cnMaximumPurchaseProductDiscountIndex].Value);

					mysql = mysql + "," + Conversion.Str(txtCommonNumber[cnMaximumSalesVoucherDiscountIndex].Value);
					mysql = mysql + "," + Conversion.Str(txtCommonNumber[cnMaximumPurchaseVoucherDiscountIndex].Value);
				}
				else
				{
					mysql = mysql + " , null, null, 0, 0, 0, 0, null, null ";
					mysql = mysql + " , null, null, null, null, null, null ";
				}

				if (txtDefaultSmanNo.Visible)
				{
					mysql = mysql + " ,'" + txtDefaultSmanNo.Text + "'";
				}
				else
				{
					mysql = mysql + " ,NULL ";
				}

				if (chkEnableCostDetails.Visible)
				{
					mysql = mysql + " ," + ((chkEnableCostDetails.CheckState == CheckState.Checked) ? 1 : 0).ToString();
				}
				else
				{
					mysql = mysql + " , default ";
				}

				mysql = mysql + " ," + ((chkRestrictOnExceedingCreditLimit.CheckState == CheckState.Checked) ? 1 : 0).ToString();

				mysql = mysql + " ," + ((chkDisable.CheckState == CheckState.Checked) ? Conversion.Str(1) : Conversion.Str(0));

				//' added by: Moiz Hakimi
				//' Date: 26-Nov-2007
				if (chkEnablePayExpRepPop.Visible)
				{
					mysql = mysql + " ," + ((chkEnablePayExpRepPop.CheckState == CheckState.Checked) ? 1 : 0).ToString();
				}
				else
				{
					mysql = mysql + " , default ";
				}
				//' end add

				//' added by: Moiz Hakimi
				//' Date: 05-Apr-2008
				if (chkEnableAdvanceModeInICSBatchPosting.Visible)
				{
					mysql = mysql + " ," + ((chkEnableAdvanceModeInICSBatchPosting.CheckState == CheckState.Checked) ? 1 : 0).ToString();
				}
				else
				{
					mysql = mysql + " , default ";
				}
				//' end add

				//'added by: Moiz Hakimi. Date:12-apr-2008
				if (chkAllowICSNegativeStock.Visible)
				{
					mysql = mysql + " ," + ((chkAllowICSNegativeStock.CheckState == CheckState.Checked) ? 1 : 0).ToString();
				}
				else
				{
					mysql = mysql + " , default ";
				}

				if (chkAllowSaleBelowCost.Visible)
				{
					mysql = mysql + " ," + ((chkAllowSaleBelowCost.CheckState == CheckState.Checked) ? 1 : 0).ToString();
				}
				else
				{
					mysql = mysql + " , default ";
				}
				//'added by: Moiz Hakimi. Date:21-Dec-2008
				if (chkAllowFutureDateTransaction.Visible)
				{
					mysql = mysql + " ," + ((chkAllowFutureDateTransaction.CheckState == CheckState.Checked) ? 1 : 0).ToString();
				}
				else
				{
					mysql = mysql + " , default ";
				}

				//'------------added by: Moiz Hakimi. Date:10-Feb-2009---------------------------------------------
				//-------------------------------------------------------------------------------------------------
				if (chkBelowReorderLevel.Visible)
				{
					mysql = mysql + " ," + ((chkBelowReorderLevel.CheckState == CheckState.Checked) ? 1 : 0).ToString();
				}
				else
				{
					mysql = mysql + " , default ";
				}

				if (chkBelowMinimumLevel.Visible)
				{
					mysql = mysql + " ," + ((chkBelowMinimumLevel.CheckState == CheckState.Checked) ? 1 : 0).ToString();
				}
				else
				{
					mysql = mysql + " , default ";
				}

				if (chkAboveMaximumLevel.Visible)
				{
					mysql = mysql + " ," + ((chkAboveMaximumLevel.CheckState == CheckState.Checked) ? 1 : 0).ToString();
				}
				else
				{
					mysql = mysql + " , default ";
				}
				//--------------------------------------------------------------------------------------------------
				//'------------added by: Moiz Hakimi. Date:25-Nov-2009---------------------------------------------
				//-------------------------------------------------------------------------------------------------
				if (chkMultipleLocationAccess.Visible)
				{
					mysql = mysql + " ," + ((chkMultipleLocationAccess.CheckState == CheckState.Checked) ? 1 : 0).ToString();
				}
				else
				{
					mysql = mysql + " , default ";
				}
				//--------------------------------------------------------------------------------------------------
				//'End Add
				mysql = mysql + " , '" + txtComments.Text + "')";

				SqlCommand TempCommand = null;
				TempCommand = SystemVariables.gConn.CreateCommand();
				TempCommand.CommandText = mysql;
				TempCommand.ExecuteNonQuery();
			}
			else
			{
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(" select user_cd from SM_USERS where user_id='" + txtUserId.Text + "'" + "And user_cd <>" + Conversion.Str(mSearchValue)));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(mReturnValue))
				{
					MessageBox.Show("Duplicate entry not allowed, record already exists", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					SystemVariables.gConn.RollbackTrans();
					txtUserId.Focus();
					return false;
				}

				//In case of update get the time Stamp and Base Unit code and protected value
				mysql = " select time_stamp, protected from SM_USERS where user_cd=" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (!Convert.IsDBNull(mReturnValue))
				{
					//if the time stamp does not match the previous one then rollback
					if (SystemProcedure2.tsFormat(ReflectionHelper.GetPrimitiveValue<string>(((Array) mReturnValue).GetValue(0))) != mTimeStamp)
					{
						MessageBox.Show(SystemConstants.msg10, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
						//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						SystemVariables.gConn.RollbackTrans();
						return false;
					}


					mysql = "UPDATE SM_USERS SET ";
					mysql = mysql + " User_Id ='" + txtUserId.Text + "',";
					mysql = mysql + " Group_Cd =" + comGroupName.GetItemData(comGroupName.ListIndex).ToString() + ",";
					mysql = mysql + " Password ='" + txtPassword.Text + "',";
					mysql = mysql + " User_Name ='" + txtUserName.Text + "',";
					mysql = mysql + " Addr_1 ='" + txtAddress1.Text + "',";
					mysql = mysql + " Addr_2 ='" + txtAddress2.Text + "',";
					mysql = mysql + " Phone ='" + txtPhone.Text + "',";
					mysql = mysql + " Pf ='" + txtProvidentFund.Text + "',";
					mysql = mysql + " Disabled =" + ((chkDisable.CheckState == CheckState.Checked) ? Conversion.Str(1) : Conversion.Str(0)) + ",";
					mysql = mysql + " Comments ='" + txtComments.Text + "'";

					if (cmbCommon[0].GetItemData(cmbCommon[0].ListIndex) == 77)
					{
						mysql = mysql + ", preferred_language='L',";
					}
					else if (cmbCommon[0].GetItemData(cmbCommon[0].ListIndex) == 78)
					{ 
						mysql = mysql + ", preferred_language='A',";
					}
					else
					{
						mysql = mysql + ", preferred_language='L',";
					}

					if (tabMaster.get_TabVisible(Convert.ToInt16(conTabPriceDetails)))
					{
						mysql = mysql + " default_sales_price_level = " + Conversion.Str(cmbPriceLevel[ccSalesPriceLevelIndex].GetItemData(cmbPriceLevel[ccSalesPriceLevelIndex].ListIndex)) + ",";
						mysql = mysql + " default_purchase_price_level = " + Conversion.Str(cmbPriceLevel[ccPurchasePriceLevelIndex].GetItemData(cmbPriceLevel[ccPurchasePriceLevelIndex].ListIndex)) + ",";

						mysql = mysql + " enable_sales_price_restrictions = " + ((int) chkPriceRestriction[ckEnableSalesPriceRestrictionIndex].CheckState).ToString() + ", ";
						mysql = mysql + " enable_purchase_price_restrictions = " + ((int) chkPriceRestriction[ckEnablePurchasePriceRestrictionIndex].CheckState).ToString() + ", ";

						mysql = mysql + " restrict_in_sales_price_levels = " + ((int) chkPriceRestriction[ckRestrictInSalesPriceLevelsIndex].CheckState).ToString() + ", ";
						mysql = mysql + " restrict_in_purchase_price_levels =  " + ((int) chkPriceRestriction[ckRestrictInPurchasePriceLevelsIndex].CheckState).ToString() + ", ";

						mysql = mysql + " maximum_sales_price_level = " + Conversion.Str(cmbPriceLevel[ccMaximumSalesPriceLevelIndex].GetItemData(cmbPriceLevel[ccMaximumSalesPriceLevelIndex].ListIndex)) + ",";
						mysql = mysql + " maximum_purchase_price_level = " + Conversion.Str(cmbPriceLevel[ccMaximumPurchasePriceLevelIndex].GetItemData(cmbPriceLevel[ccMaximumPurchasePriceLevelIndex].ListIndex)) + ",";

						mysql = mysql + " minimum_sales_price_level = " + Conversion.Str(cmbPriceLevel[ccMinimumSalesPriceLevelIndex].GetItemData(cmbPriceLevel[ccMinimumSalesPriceLevelIndex].ListIndex)) + ",";
						mysql = mysql + " minimum_purchase_price_level = " + Conversion.Str(cmbPriceLevel[ccMinimumPurchasePriceLevelIndex].GetItemData(cmbPriceLevel[ccMinimumPurchasePriceLevelIndex].ListIndex)) + ",";

						mysql = mysql + " maximum_product_sales_discount_in_percent = " + Conversion.Str(txtCommonNumber[cnMaximumSalesProductDiscountIndex].Value) + ",";
						mysql = mysql + " maximum_product_purchase_discount_in_percent = " + Conversion.Str(txtCommonNumber[cnMaximumPurchaseProductDiscountIndex].Value) + ",";

						mysql = mysql + " maximum_voucher_sales_discount_in_percent = " + Conversion.Str(txtCommonNumber[cnMaximumSalesVoucherDiscountIndex].Value) + ",";
						mysql = mysql + " maximum_voucher_purchase_discount_in_percent = " + Conversion.Str(txtCommonNumber[cnMaximumPurchaseVoucherDiscountIndex].Value);

					}
					else
					{
						mysql = mysql + " default_sales_price_level =  null,";
						mysql = mysql + " default_purchase_price_level = null,";

						mysql = mysql + " enable_sales_price_restrictions = 0, ";
						mysql = mysql + " enable_purchase_price_restrictions = 0, ";

						mysql = mysql + " restrict_in_sales_price_levels = 0, ";
						mysql = mysql + " restrict_in_purchase_price_levels = 0, ";

						mysql = mysql + " maximum_sales_price_level = null, ";
						mysql = mysql + " maximum_purchase_price_level = null, ";

						mysql = mysql + " minimum_sales_price_level = null, ";
						mysql = mysql + " minimum_purchase_price_level = null, ";

						mysql = mysql + " maximum_product_sales_discount_in_percent = null, ";
						mysql = mysql + " maximum_product_purchase_discount_in_percent = null, ";

						mysql = mysql + " maximum_voucher_sales_discount_in_percent = null, ";
						mysql = mysql + " maximum_voucher_purchase_discount_in_percent = null ";
					}

					if (txtDefaultSmanNo.Visible)
					{
						mysql = mysql + " , default_sman_no ='" + txtDefaultSmanNo.Text + "'";
					}
					else
					{
						mysql = mysql + " , default_sman_no =NULL ";
					}


					if (chkEnableCostDetails.Visible)
					{
						mysql = mysql + " , enable_cost_details =" + ((chkEnableCostDetails.CheckState == CheckState.Checked) ? 1 : 0).ToString();
					}

					//' added by: Moiz Hakimi
					//' Date: 26-Nov-2007
					if (chkEnablePayExpRepPop.Visible)
					{
						mysql = mysql + " , enable_pay_exp_rep_pop =" + ((chkEnablePayExpRepPop.CheckState == CheckState.Checked) ? 1 : 0).ToString();
					}
					//' end add

					//' added by: Moiz Hakimi
					//' Date: 05-Apr-2008
					if (chkEnableAdvanceModeInICSBatchPosting.Visible)
					{
						mysql = mysql + " , Enable_Advance_Mode_In_ICS_Batch_Post =" + ((chkEnableAdvanceModeInICSBatchPosting.CheckState == CheckState.Checked) ? 1 : 0).ToString();
					}
					//' end add


					//' added by: Moiz Hakimi
					//' Date: 12-Apr-2008
					if (chkAllowICSNegativeStock.Visible)
					{
						mysql = mysql + " , Allow_ICS_Negative_Stock =" + ((chkAllowICSNegativeStock.CheckState == CheckState.Checked) ? 1 : 0).ToString();
					}

					if (chkAllowSaleBelowCost.Visible)
					{
						mysql = mysql + " , Allow_Sale_Below_Cost =" + ((chkAllowSaleBelowCost.CheckState == CheckState.Checked) ? 1 : 0).ToString();
					}
					//' added by: Moiz Hakimi
					//' Date: 21-Dec-2008
					if (chkAllowFutureDateTransaction.Visible)
					{
						mysql = mysql + " , Allow_Future_date_Transaction =" + ((chkAllowFutureDateTransaction.CheckState == CheckState.Checked) ? 1 : 0).ToString();
					}

					//' added by: Moiz Hakimi
					//' Date: 10-Feb-2009
					if (chkBelowReorderLevel.Visible)
					{
						mysql = mysql + " , Show_Message_On_Items_Below_Reorder_Level =" + ((chkBelowReorderLevel.CheckState == CheckState.Checked) ? 1 : 0).ToString();
					}
					if (chkBelowMinimumLevel.Visible)
					{
						mysql = mysql + " , Show_Message_On_Items_Below_Minimum_Level =" + ((chkBelowMinimumLevel.CheckState == CheckState.Checked) ? 1 : 0).ToString();
					}
					if (chkAboveMaximumLevel.Visible)
					{
						mysql = mysql + " , Show_Message_On_Items_Above_Maximum_Level =" + ((chkAboveMaximumLevel.CheckState == CheckState.Checked) ? 1 : 0).ToString();
					}
					//' added by: Moiz Hakimi
					//' Date: 25-Nov-2009
					if (chkMultipleLocationAccess.Visible)
					{
						mysql = mysql + " , Access_all_location =" + ((chkMultipleLocationAccess.CheckState == CheckState.Checked) ? 1 : 0).ToString();
					}

					//' end add


					mysql = mysql + " , restrict_on_exceeding_credit_limit =" + ((chkRestrictOnExceedingCreditLimit.CheckState == CheckState.Checked) ? 1 : 0).ToString();
					mysql = mysql + " where user_Cd =" + Conversion.Str(mSearchValue);

					SqlCommand TempCommand_2 = null;
					TempCommand_2 = SystemVariables.gConn.CreateCommand();
					TempCommand_2.CommandText = mysql;
					TempCommand_2.ExecuteNonQuery();
				}
			}

			//'''''''''''''''''''''''''''''''''''Procedure for Price detail save---------Moiz Hakimi 03-Feb-2009'''''''''''''''''''''''''''''''''''''''''
			if (tabMaster.get_TabVisible(Convert.ToInt16(conTabPriceDetails)) && mPricingDetailsTabClicked)
			{


				this.grdPriceDetails.UpdateData();
				mysql = "delete ics_price_list_assigned_details ";
				mysql = mysql + " where ";
				mysql = mysql + " Assigned_User_Cd = " + Conversion.Str(mSearchValue);
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
						goto eFoundError;
					}
					else if (Convert.IsDBNull(aProductPriceDetails.GetValue(cnt, ckVoucherIndex)) || Convert.ToString(aProductPriceDetails.GetValue(cnt, ckVoucherIndex)) == "")
					{ 
						MessageBox.Show("Invalid Voucher No", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
						grdPriceDetails.Col = ckVoucherIndex;
						goto eFoundError;
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
						mysql = mysql + " ( Assigned_User_Cd, Price_List_Cd, Voucher_Type, user_cd) ";
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
			result = true;
			//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.CommitTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			SystemVariables.gConn.CommitTrans();
			FirstFocusObject.Focus();
			return result;

			eFoundError:
			int mReturnErrorType = 0;
			//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
			mReturnErrorType = SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, Information.Err().Description, this.Name, "GetRecord", SystemConstants.msg10);
			//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			SystemVariables.gConn.RollbackTrans();
			if (mReturnErrorType == 1)
			{
				return false;
			}
			else if (mReturnErrorType == 2)
			{ 
				AddRecord();
				return false;
			}
			else if (mReturnErrorType == 3)
			{ 
				AddRecord();
				return false;
			}
			else
			{
				return false;
			}
		}

		public bool deleteRecord()
		{

			bool result = false;
			string mysql = " select protected from SM_USERS where user_cd=" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
			//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (!Convert.IsDBNull(mReturnValue))
			{
				if (ReflectionHelper.GetPrimitiveValue<bool>(mReturnValue))
				{
					MessageBox.Show(SystemConstants.msg12, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					return false;
				}

				//'''Temporary do not allow to delete user '''added by Moiz Hakimion 13th jul 2003
				MessageBox.Show("User cannot be deleted", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
				return false;


				//If an error occurs, trap the error and dispaly a valid message
				SystemVariables.gConn.BeginTransaction();

				//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
				try
				{
					mysql = "delete from SM_USERS where user_cd=" + Conversion.Str(mSearchValue);
					SqlCommand TempCommand = null;
					TempCommand = SystemVariables.gConn.CreateCommand();
					TempCommand.CommandText = mysql;
					TempCommand.ExecuteNonQuery();

					//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
					if (Information.Err().Number != 0)
					{
						MessageBox.Show("User cannot be deleted, transaction already occurs", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
						//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
						SystemVariables.gConn.RollbackTrans();
						return false;
					}

					//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.CommitTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
					SystemVariables.gConn.CommitTrans();
					result = true;
				}
				catch (Exception exc)
				{
					NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
				}
			}

			return result;

			//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
			int mReturnErrorType = SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, Information.Err().Description, this.Name, "GetRecord", SystemConstants.msg10);
			if (mReturnErrorType == 1)
			{
				//mSearchValue = GetMasterCode("select from gl_accnt_group", "group_no", txtGroupNo.Text, "group_cd")
				//Call GetRecord("gl_accnt_group", "group_cd", mSearchValue, StringType)
				return false;
			}
			else if (mReturnErrorType == 2)
			{ 
				AddRecord();
				return false;
			}
			else
			{
				return false;
			}
		}

		public void GetRecord(object SearchValue)
		{
			//This routine is called after getting the value from Find window or
			//refreshing the recordset during any error of updating or deleting

			string mysql = "";
			SqlDataReader localRec = null;

			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			//UPGRADE_WARNING: (2080) IsEmpty was upgraded to a comparison and has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2080
			if (Object.Equals(SearchValue, null) || Convert.IsDBNull(SearchValue))
			{
				return;
			}

			try
			{

				mysql = " select * from SM_USERS where user_cd = " + ReflectionHelper.GetPrimitiveValue<string>(SearchValue);

				SqlCommand sqlCommand = new SqlCommand(mysql, SystemVariables.gConn);
				localRec = sqlCommand.ExecuteReader();
				if (localRec.Read())
				{
					mSearchValue = localRec["user_cd"];
					mTimeStamp = SystemProcedure2.tsFormat(Convert.ToString(localRec["Time_Stamp"]));
					txtUserId.Text = Convert.ToString(localRec["user_id"]);
					txtUserName.Text = Convert.ToString(localRec["user_name"]);
					txtPassword.Text = Convert.ToString(localRec["password"]) + "";
					txtConfirmPassword.Text = Convert.ToString(localRec["password"]) + "";

					SystemCombo.SearchCombo(comGroupName, Convert.ToInt32(localRec["group_cd"]));

					txtAddress1.Text = Convert.ToString(localRec["addr_1"]) + "";
					txtAddress2.Text = Convert.ToString(localRec["addr_2"]) + "";
					txtPhone.Text = Convert.ToString(localRec["phone"]) + "";
					txtProvidentFund.Text = Convert.ToString(localRec["pf"]) + "";
					txtComments.Text = Convert.ToString(localRec["comments"]) + "";
					//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
					chkDisable.CheckState = (CheckState) ((Convert.ToBoolean(localRec["disabled"])) ? 1 : 0);

					//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
					if (((TriState) Convert.ToInt32(localRec["protected"])) == TriState.True)
					{
						comGroupName.Enabled = false;
					}

					if (Convert.ToString(localRec["preferred_language"]) == "L")
					{
						SystemCombo.SearchCombo(cmbCommon[0], 77);
					}
					else if (Convert.ToString(localRec["preferred_language"]) == "A")
					{ 
						SystemCombo.SearchCombo(cmbCommon[0], 78);
					}
					else
					{
						SystemCombo.SearchCombo(cmbCommon[0], 77);
					}

					if (txtDefaultSmanNo.Visible)
					{
						txtDefaultSmanNo.Text = Convert.ToString(localRec["default_sman_no"]) + "";
					}
					else
					{
						txtDefaultSmanNo.Text = "";
					}

					//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
					chkEnableCostDetails.CheckState = (CheckState) ((Convert.ToBoolean(localRec["enable_cost_details"])) ? 1 : 0);

					//' added by Moiz Hakimi
					//' date: 26-Nov-2007
					if (!Convert.IsDBNull(localRec["enable_pay_exp_rep_pop"]))
					{
						//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
						chkEnablePayExpRepPop.CheckState = (CheckState) ((Convert.ToBoolean(localRec["enable_pay_exp_rep_pop"])) ? 1 : 0);
					}
					else
					{
						chkEnablePayExpRepPop.CheckState = CheckState.Unchecked;
					}
					//' end add

					//' added by Moiz Hakimi
					//' date: 05-apr-2008
					if (!Convert.IsDBNull(localRec["Enable_Advance_Mode_In_ICS_Batch_Post"]))
					{
						//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
						chkEnableAdvanceModeInICSBatchPosting.CheckState = (CheckState) ((Convert.ToBoolean(localRec["Enable_Advance_Mode_In_ICS_Batch_Post"])) ? 1 : 0);
					}
					else
					{
						chkEnableAdvanceModeInICSBatchPosting.CheckState = CheckState.Unchecked;
					}
					//' end add


					//' added by Moiz Hakimi
					//' date: 12-apr-2008
					if (!Convert.IsDBNull(localRec["Allow_ICS_Negative_Stock"]))
					{
						//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
						chkAllowICSNegativeStock.CheckState = (CheckState) ((Convert.ToBoolean(localRec["Allow_ICS_Negative_Stock"])) ? 1 : 0);
					}
					else
					{
						chkAllowICSNegativeStock.CheckState = CheckState.Unchecked;
					}

					if (!Convert.IsDBNull(localRec["Allow_Sale_Below_Cost"]))
					{
						//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
						chkAllowSaleBelowCost.CheckState = (CheckState) ((Convert.ToBoolean(localRec["Allow_Sale_Below_Cost"])) ? 1 : 0);
					}
					else
					{
						chkAllowSaleBelowCost.CheckState = CheckState.Unchecked;
					}

					//' added by Moiz Hakimi
					//' date: 21-dec-2008
					if (!Convert.IsDBNull(localRec["Allow_Future_date_Transaction"]))
					{
						//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
						chkAllowFutureDateTransaction.CheckState = (CheckState) ((Convert.ToBoolean(localRec["Allow_Future_date_Transaction"])) ? 1 : 0);
					}
					else
					{
						chkAllowFutureDateTransaction.CheckState = CheckState.Unchecked;
					}

					//' added by Moiz Hakimi
					//' date: 10-Feb-2009
					if (!Convert.IsDBNull(localRec["Show_Message_On_Items_Below_Reorder_Level"]))
					{
						//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
						chkBelowReorderLevel.CheckState = (CheckState) ((Convert.ToBoolean(localRec["Show_Message_On_Items_Below_Reorder_Level"])) ? 1 : 0);
					}
					else
					{
						chkBelowReorderLevel.CheckState = CheckState.Unchecked;
					}

					if (!Convert.IsDBNull(localRec["Show_Message_On_Items_Below_Minimum_Level"]))
					{
						//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
						chkBelowMinimumLevel.CheckState = (CheckState) ((Convert.ToBoolean(localRec["Show_Message_On_Items_Below_Minimum_Level"])) ? 1 : 0);
					}
					else
					{
						chkBelowMinimumLevel.CheckState = CheckState.Unchecked;
					}

					if (!Convert.IsDBNull(localRec["Show_Message_On_Items_Above_Maximum_Level"]))
					{
						//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
						chkAboveMaximumLevel.CheckState = (CheckState) ((Convert.ToBoolean(localRec["Show_Message_On_Items_Above_Maximum_Level"])) ? 1 : 0);
					}
					else
					{
						chkAboveMaximumLevel.CheckState = CheckState.Unchecked;
					}
					if (!Convert.IsDBNull(localRec["Access_all_location"]))
					{
						//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
						chkMultipleLocationAccess.CheckState = (CheckState) ((Convert.ToBoolean(localRec["Access_all_location"])) ? 1 : 0);
					}
					else
					{
						chkMultipleLocationAccess.CheckState = CheckState.Unchecked;
					}
					//' end add


					//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
					chkRestrictOnExceedingCreditLimit.CheckState = (CheckState) ((Convert.ToBoolean(localRec["restrict_on_exceeding_credit_limit"])) ? 1 : 0);


					if (tabMaster.get_TabVisible(Convert.ToInt16(conTabPriceDetails)))
					{
						//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
						//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
						chkPriceRestriction[ckEnableSalesPriceRestrictionIndex].CheckState = (CheckState) ((((TriState) Convert.ToInt32(localRec["enable_sales_price_restrictions"])) == TriState.True) ? 1 : 0);
						//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
						//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
						chkPriceRestriction[ckEnablePurchasePriceRestrictionIndex].CheckState = (CheckState) ((((TriState) Convert.ToInt32(localRec["enable_purchase_price_restrictions"])) == TriState.True) ? 1 : 0);

						//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
						//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
						chkPriceRestriction[ckRestrictInSalesPriceLevelsIndex].CheckState = (CheckState) ((((TriState) Convert.ToInt32(localRec["restrict_in_sales_price_levels"])) == TriState.True) ? 1 : 0);
						//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
						//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis#6021
						chkPriceRestriction[ckRestrictInPurchasePriceLevelsIndex].CheckState = (CheckState) ((((TriState) Convert.ToInt32(localRec["restrict_in_purchase_price_levels"])) == TriState.True) ? 1 : 0);

						if (!Convert.IsDBNull(localRec["default_sales_price_level"]))
						{
							SystemCombo.SearchCombo(cmbPriceLevel[ccSalesPriceLevelIndex], Convert.ToInt32(localRec["default_sales_price_level"]));
						}
						else
						{
							cmbPriceLevel[ccSalesPriceLevelIndex].ListIndex = 0;
						}

						if (!Convert.IsDBNull(localRec["default_purchase_price_level"]))
						{
							SystemCombo.SearchCombo(cmbPriceLevel[ccPurchasePriceLevelIndex], Convert.ToInt32(localRec["default_purchase_price_level"]));
						}
						else
						{
							cmbPriceLevel[ccPurchasePriceLevelIndex].ListIndex = 0;
						}

						if (!Convert.IsDBNull(localRec["maximum_sales_price_level"]))
						{
							SystemCombo.SearchCombo(cmbPriceLevel[ccMaximumSalesPriceLevelIndex], Convert.ToInt32(localRec["maximum_sales_price_level"]));
						}
						else
						{
							cmbPriceLevel[ccMaximumSalesPriceLevelIndex].ListIndex = 0;
						}

						if (!Convert.IsDBNull(localRec["maximum_purchase_price_level"]))
						{
							SystemCombo.SearchCombo(cmbPriceLevel[ccMaximumPurchasePriceLevelIndex], Convert.ToInt32(localRec["maximum_purchase_price_level"]));
						}
						else
						{
							cmbPriceLevel[ccMaximumPurchasePriceLevelIndex].ListIndex = 0;
						}

						if (!Convert.IsDBNull(localRec["minimum_sales_price_level"]))
						{
							SystemCombo.SearchCombo(cmbPriceLevel[ccMinimumSalesPriceLevelIndex], Convert.ToInt32(localRec["minimum_sales_price_level"]));
						}
						else
						{
							cmbPriceLevel[ccMinimumSalesPriceLevelIndex].ListIndex = 0;
						}

						if (!Convert.IsDBNull(localRec["minimum_purchase_price_level"]))
						{
							SystemCombo.SearchCombo(cmbPriceLevel[ccMinimumPurchasePriceLevelIndex], Convert.ToInt32(localRec["minimum_purchase_price_level"]));
						}
						else
						{
							cmbPriceLevel[ccMinimumPurchasePriceLevelIndex].ListIndex = 0;
						}

						txtCommonNumber[cnMaximumSalesProductDiscountIndex].Value = (Convert.IsDBNull(localRec["Maximum_Product_Sales_Discount_In_Percent"])) ? ((object) 0) : localRec["Maximum_Product_Sales_Discount_In_Percent"];
						txtCommonNumber[cnMaximumSalesVoucherDiscountIndex].Value = (Convert.IsDBNull(localRec["Maximum_voucher_Sales_Discount_In_Percent"])) ? ((object) 0) : localRec["Maximum_voucher_Sales_Discount_In_Percent"];
						txtCommonNumber[cnMaximumPurchaseProductDiscountIndex].Value = (Convert.IsDBNull(localRec["Maximum_Product_purchase_Discount_In_Percent"])) ? ((object) 0) : localRec["Maximum_Product_purchase_Discount_In_Percent"];
						txtCommonNumber[cnMaximumPurchaseVoucherDiscountIndex].Value = (Convert.IsDBNull(localRec["Maximum_voucher_purchase_Discount_In_Percent"])) ? ((object) 0) : localRec["Maximum_voucher_purchase_Discount_In_Percent"];

						ShowPricingDetails(false);
					}


					//Change the form mode to edit
					mCurrentFormMode = SystemVariables.SystemFormModes.frmEditMode;
				}
				localRec.Close();
				tabMaster.CurrTab = Convert.ToInt16(conTabOtherDetails);
			}
			catch (System.Exception excep)
			{
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, excep.Message, this.Name, "GetRecord");
			}

		}

		public void findRecord()
		{
			//Call the find window

			//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(1000010));
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

		private void Form_Closed(Object eventSender, EventArgs eventArgs)
		{
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{

				SystemMenu.RemoveMeFromWindowList(Conversion.Str(this.Handle.ToInt32()));

				//Set objAdditionalDetails = Nothing
				UserAccess = null;
				oThisFormToolBar = null;
				frmSysUsers.DefInstance = null;
			}
			catch (Exception exc)
			{
				NotUpgradedHelper.NotifyNotUpgradedElement("Resume in On-Error-Resume-Next Block");
			}
		}

		public bool CheckDataValidity()
		{
			//Check validation during update and add of records

			if (SystemProcedure2.IsItEmpty(txtUserId.Text, SystemVariables.DataType.StringType))
			{
				MessageBox.Show("Enter the User ID", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
				FirstFocusObject.Focus();
				return false;
			}

			if (SystemProcedure2.IsItEmpty(txtUserName.Text, SystemVariables.DataType.StringType))
			{
				MessageBox.Show("Enter the User Name", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
				txtUserName.Focus();
				return false;
			}

			if (txtPassword.Text != txtConfirmPassword.Text)
			{
				MessageBox.Show("Password does not match!", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
				txtPassword.Focus();
				return false;
			}

			return true;
		}



		private void tabMaster_ClickEvent(Object eventSender, EventArgs eventArgs)
		{
			try
			{

				switch(tabMaster.CurrTab)
				{
					case conTabPriceDetails : 
						ShowPricingDetails(true); 
						mPricingDetailsTabClicked = true; 
						cmbPriceLevel[ccSalesPriceLevelIndex].Focus(); 
						break;
				}
			}
			catch
			{

				//do not handle this error here
			}
		}

		private void txtConfirmPassword_KeyPress(Object eventSender, KeyPressEventArgs eventArgs)
		{
			int KeyAscii = Convert.ToInt32(eventArgs.KeyChar);
			try
			{
				if (KeyAscii == 39)
				{
					KeyAscii = 0;
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

		public void FindRoutine(string pObjectName)
		{

			object mTempSearchValue = null;

			switch(pObjectName)
			{
				case "txtDefaultSmanNo" : 
					txtDefaultSmanNo.Text = ""; 
					//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
					mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(1004000, "88")); 
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049 
					if (!Convert.IsDBNull(mTempSearchValue))
					{
						//UPGRADE_WARNING: (1068) mTempSearchValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
						txtDefaultSmanNo.Text = ReflectionHelper.GetPrimitiveValue<string>(((Array) mTempSearchValue).GetValue(1));
						txtDefaultSmanNo_Leave(txtDefaultSmanNo, new EventArgs());
					} 
					break;
			}
		}

		private void txtDefaultSmanNo_DropButtonClick(Object Sender, EventArgs e)
		{
			FindRoutine("txtDefaultSmanNo");
		}

		private void txtDefaultSmanNo_Leave(Object eventSender, EventArgs eventArgs)
		{
			try
			{
				object mTempValue = null;
				string mysql = "";
				int cnt = 0;

				if (!SystemProcedure2.IsItEmpty(txtDefaultSmanNo.Text, SystemVariables.DataType.NumberType))
				{
					mysql = "select " + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "l_sman_name" : "a_sman_name");
					mysql = mysql + " from SM_Salesman where sman_no=" + txtDefaultSmanNo.Text;
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mysql));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (Convert.IsDBNull(mTempValue))
					{
						txtDefaultSmanNo.Text = "";
						throw new System.Exception("-9990002");
					}
					else
					{
						//txtParentCostName.Text = mTempValue
					}
				}
				else
				{
					//txtParentCostName.Text = ""
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
				SystemGrid.DefineSystemVoucherGrid(grdPriceDetails, true, true, true, (0xFFFFFF).ToString(), (0x0).ToString(), true, false, C1.Win.C1TrueDBGrid.MarqueeEnum.FloatingEditor, 1.47f, 1.4f, cGridColor);
				//define voucher grid columns
				//Call DefineSystemVoucherGridColumn(grdSupplierDetails, "LN", 400, False, gDisableColumnBackColor, , , False)
				SystemGrid.DefineSystemVoucherGridColumn(grdPriceDetails, "Voucher Type", 1200, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true, true, true, "cmbPriceList", true);
				SystemGrid.DefineSystemVoucherGridColumn(grdPriceDetails, "Voucher Name", 3000, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true, true, true, "cmbPriceList", true);
				SystemGrid.DefineSystemVoucherGridColumn(grdPriceDetails, "Price", 1000, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true, true, true, "cmbPriceList", true);
				SystemGrid.DefineSystemVoucherGridColumn(grdPriceDetails, "Price Name", 3000, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true, true, true, "cmbPriceList", true);

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
				mysql = mysql + " where plad.Assigned_User_Cd = " + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);

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

			//**------------------------------------------------------------------------------------------
			//End If
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
					 
					//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081 
					cmbPriceList.Width = grdPriceDetails.Splits[0].DisplayColumns[ckVoucherIndex].Width + 167; 
					 
					break;
				case ckVoucherNameIndex : 
					//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBDropDown property cmbPriceList.ListField was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064 
					cmbPriceList.setListField("Voucher_name"); 
					//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081 
					//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.Column property cmbPriceList.Columns.Order was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064 
					cmbPriceList.Splits[0].DisplayColumns[0].setOrder(1); 
					cmbPriceList.DisplayColumns[1].Width = 200; 
					cmbPriceList.DisplayColumns[0].Width = 47; 
					 
					//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081 
					cmbPriceList.Width = grdPriceDetails.Splits[0].DisplayColumns[ckVoucherNameIndex].Width + 100; 
					break;
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
	}
}