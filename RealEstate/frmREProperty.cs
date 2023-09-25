
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;




namespace Xtreme
{
	internal partial class frmREProperty
		: System.Windows.Forms.Form
	{

		public frmREProperty()
{
InitializeComponent();
} 
 public  void frmREProperty_old()
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


		private void frmREProperty_Activated(System.Object eventSender, System.EventArgs eventArgs)
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

		private clsToolbar oThisFormToolBar = null;
		public Control FirstFocusObject = null;


		private int mThisFormID = 0;
		private object mSearchValue = null;
		private SystemVariables.SystemFormModes mCurrentFormMode = (SystemVariables.SystemFormModes) 0;

		private const int conTxtPropertyNo = 0;
		private const int conTxtLPropertyName = 1;
		private const int conTxtPropertyAreaCd = 2;
		private const int conTxtGuardNo = 4;
		private const int conTxtPropertyTotalFloors = 3;
		private const int conTxtPropertyType = 5;
		private const int conTxtPropertyFacilities = 6;
		private const int conTxtPropertyAddress = 7;
		private const int conTxtAPropertyName = 8;
		private const int conTXTStatusNo = 9;

		private const int conTxtRevenueLdgrCd = 10;
		private const int conTxtAccruedLdgrCd = 11;
		private const int conTxtCashBankLdgrCd = 12;
		private const int conTxtAdvanceLdgrCd = 13;
		private const int conTxtDiscountLdgrCd = 14;

		private const int conTxtLRegion = 15;
		private const int conTxtBuildingNo = 16;
		private const int conTxtLStreetName = 17;
		private const int conTxtPlot = 18;
		private const int conTxtARegion = 19;
		private const int conTxtAStreetName = 20;

		private const int conDlblTypeName = 0;
		private const int conDlblAreaName = 1;
		private const int conDlblGuardName = 2;
		private const int conDlblStatusName = 3;
		private const int conDlblRevenueLdgrName = 4;
		private const int conDlblAccruedLdgrName = 5;
		private const int conDlblCashBankLdgrName = 6;
		private const int conDlblAdvanceLdgrName = 7;
		private const int conDlblDiscountLdgrName = 8;

		private const int conLblRevenueLdgr = 11;
		private const int conLblAccruedLdgr = 12;
		private const int conLblCashBankLdgr = 13;
		private const int conLblAdvanceLdgr = 14;
		private const int conLblDiscountLdgr = 15;



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


		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2080
		private void Form_Load()
		{

			try
			{

				FirstFocusObject = txtCommon[conTxtPropertyNo];
				txtCommon[conTxtPropertyNo].Text = SystemProcedure2.GetNewNumber("re_property", "property_No", 3);
				this.CurrentFormMode = SystemVariables.SystemFormModes.frmAddMode;
				this.Top = 0;
				this.Left = 0;

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

				SystemProcedure.SetLabelCaption(this);

				if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("enable_property_level_revenue_posting")))
				{
					lblCommon[conLblRevenueLdgr].Visible = true;
					txtCommon[conTxtRevenueLdgrCd].Visible = true;
					txtCommonDisplay[conDlblRevenueLdgrName].Visible = true;
				}
				else
				{
					lblCommon[conLblRevenueLdgr].Visible = false;
					txtCommon[conTxtRevenueLdgrCd].Visible = false;
					txtCommonDisplay[conDlblRevenueLdgrName].Visible = false;
				}

				if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("enable_property_level_accrued_charges_posting")))
				{
					lblCommon[conLblAccruedLdgr].Visible = true;
					txtCommon[conTxtAccruedLdgrCd].Visible = true;
					txtCommonDisplay[conDlblAccruedLdgrName].Visible = true;
				}
				else
				{
					lblCommon[conLblAccruedLdgr].Visible = false;
					txtCommon[conTxtAccruedLdgrCd].Visible = false;
					txtCommonDisplay[conDlblAccruedLdgrName].Visible = false;
				}

				if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("enable_property_level_cash_posting")))
				{
					lblCommon[conLblCashBankLdgr].Visible = true;
					txtCommon[conTxtCashBankLdgrCd].Visible = true;
					txtCommonDisplay[conDlblCashBankLdgrName].Visible = true;
				}
				else
				{
					lblCommon[conLblCashBankLdgr].Visible = false;
					txtCommon[conTxtCashBankLdgrCd].Visible = false;
					txtCommonDisplay[conDlblCashBankLdgrName].Visible = false;
				}

				if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("enable_property_level_advanced_receipt_posting")))
				{
					lblCommon[conLblAdvanceLdgr].Visible = true;
					txtCommon[conTxtAdvanceLdgrCd].Visible = true;
					txtCommonDisplay[conDlblAdvanceLdgrName].Visible = true;
				}
				else
				{
					lblCommon[conLblAdvanceLdgr].Visible = false;
					txtCommon[conTxtAdvanceLdgrCd].Visible = false;
					txtCommonDisplay[conDlblAdvanceLdgrName].Visible = false;
				}

				if (ReflectionHelper.GetPrimitiveValue<bool>(SystemProcedure2.GetSystemPreferenceSetting("enable_property_level_discount_posting")))
				{
					lblCommon[conLblDiscountLdgr].Visible = true;
					txtCommon[conTxtDiscountLdgrCd].Visible = true;
					txtCommonDisplay[conDlblDiscountLdgrName].Visible = true;
				}
				else
				{
					lblCommon[conLblDiscountLdgr].Visible = false;
					txtCommon[conTxtDiscountLdgrCd].Visible = false;
					txtCommonDisplay[conDlblDiscountLdgrName].Visible = false;
				}

				tabMaster.CurrTab = 0;
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
				if (KeyCode == 13)
				{
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
			}
			finally
			{
				eventArgs.Handled = KeyCode == 0;
			}
		}

		public void AddRecord()
		{

			SystemProcedure2.ClearTextBox(this);
			SystemProcedure2.ClearNumberBox(this);

			mCurrentFormMode = SystemVariables.SystemFormModes.frmAddMode;

			mSearchValue = "";

			tabMaster.CurrTab = 0;
			FirstFocusObject.Focus();
			txtCommon[conTxtPropertyNo].Text = SystemProcedure2.GetNewNumber("re_property", "property_No", 3);
			return;

			//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
			SystemProcedure.ErrorHandlingRoutine(Information.Err().Number, Information.Err().Description, this.Name, "AddRecord");
		}

		public bool saveRecord(bool pPostGl = false)
		{

			bool result = false;
			int mTypeCd = 0;
			int mAreaCd = 0;
			int mGuardCd = 0;
			int mStatusCd = 0;

			string mRevenueLdgrCd = "";
			string mAccruedLdgrCd = "";
			string mCashBankLdgrCd = "";
			string mAdvanceLdgrCd = "";
			string mDiscountLdgrCd = "";


			string myErrMsg = "";
			//On Error GoTo eFoundError

			SystemVariables.gConn.BeginTransaction();

			string mySQL = " select property_type_cd from re_property_type where type_no = " + txtCommon[conTxtPropertyType].Text;
			//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mySQL));
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (Convert.IsDBNull(mReturnValue))
			{
				myErrMsg = "Invalid Type No";
				txtCommon[conTxtPropertyType].Focus();
				goto eFoundError;
			}
			else
			{
				//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mTypeCd = ReflectionHelper.GetPrimitiveValue<int>(mReturnValue);
			}

			mySQL = " select Area_Cd from re_area where Area_no = " + txtCommon[conTxtPropertyAreaCd].Text;
			//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mySQL));
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (Convert.IsDBNull(mReturnValue))
			{
				myErrMsg = "Invalid Area No";
				txtCommon[conTxtPropertyAreaCd].Focus();
				goto eFoundError;
			}
			else
			{
				//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mAreaCd = ReflectionHelper.GetPrimitiveValue<int>(mReturnValue);
			}

			mySQL = " select Guard_Cd from re_Guards where Guard_no = " + txtCommon[conTxtGuardNo].Text;
			//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mySQL));
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (Convert.IsDBNull(mReturnValue))
			{
				myErrMsg = "Invalid Guard No";
				txtCommon[conTxtGuardNo].Focus();
				goto eFoundError;
			}
			else
			{
				//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mGuardCd = ReflectionHelper.GetPrimitiveValue<int>(mReturnValue);
			}

			mySQL = " select property_status_cd from re_property_status where status_no = " + txtCommon[conTXTStatusNo].Text;
			//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mySQL));
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
			if (Convert.IsDBNull(mReturnValue))
			{
				myErrMsg = "Invalid Status No";
				txtCommon[conTXTStatusNo].Focus();
				goto eFoundError;
			}
			else
			{
				//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mStatusCd = ReflectionHelper.GetPrimitiveValue<int>(mReturnValue);
			}

			if (!SystemProcedure2.IsItEmpty(txtCommon[conTxtRevenueLdgrCd].Text, SystemVariables.DataType.StringType))
			{
				mySQL = "select ldgr_cd from gl_ledger ";
				mySQL = mySQL + " where show = 1 ";
				mySQL = mySQL + " and ldgr_no='" + txtCommon[conTxtRevenueLdgrCd].Text + "'";
				mySQL = mySQL + " and type_cd in (" + ReflectionHelper.GetPrimitiveValue<string>(SystemProcedure2.GetSystemPreferenceSetting("re_gl_revenue_codes")) + ")";
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mySQL));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (Convert.IsDBNull(mReturnValue))
				{
					myErrMsg = "Invalid Revenue Code";
					tabMaster.CurrTab = 1;
					txtCommon[conTxtRevenueLdgrCd].Focus();
					goto eFoundError;
				}
				else
				{
					//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mRevenueLdgrCd = ReflectionHelper.GetPrimitiveValue<string>(mReturnValue);
				}
			}
			else
			{
				mRevenueLdgrCd = "";
			}

			if (!SystemProcedure2.IsItEmpty(txtCommon[conTxtAccruedLdgrCd].Text, SystemVariables.DataType.StringType))
			{
				mySQL = "select ldgr_cd from gl_ledger ";
				mySQL = mySQL + " where show = 1 ";
				mySQL = mySQL + " and ldgr_no='" + txtCommon[conTxtAccruedLdgrCd].Text + "'";
				mySQL = mySQL + " and type_cd in (" + ReflectionHelper.GetPrimitiveValue<string>(SystemProcedure2.GetSystemPreferenceSetting("re_gl_accrued_codes")) + ")";
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mySQL));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (Convert.IsDBNull(mReturnValue))
				{
					myErrMsg = "Invalid Accrued Code";
					tabMaster.CurrTab = 1;
					txtCommon[conTxtAccruedLdgrCd].Focus();
					goto eFoundError;
				}
				else
				{
					//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mAccruedLdgrCd = ReflectionHelper.GetPrimitiveValue<string>(mReturnValue);
				}
			}
			else
			{
				mAccruedLdgrCd = "";
			}

			if (!SystemProcedure2.IsItEmpty(txtCommon[conTxtCashBankLdgrCd].Text, SystemVariables.DataType.StringType))
			{
				mySQL = "select ldgr_cd from gl_ledger ";
				mySQL = mySQL + " where show = 1 ";
				mySQL = mySQL + " and ldgr_no='" + txtCommon[conTxtCashBankLdgrCd].Text + "'";
				mySQL = mySQL + " and type_cd in (" + ReflectionHelper.GetPrimitiveValue<string>(SystemProcedure2.GetSystemPreferenceSetting("re_gl_cash_codes")) + ")";
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mySQL));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (Convert.IsDBNull(mReturnValue))
				{
					myErrMsg = "Invalid Cash/Bank Code";
					tabMaster.CurrTab = 1;
					txtCommon[conTxtCashBankLdgrCd].Focus();
					goto eFoundError;
				}
				else
				{
					//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mCashBankLdgrCd = ReflectionHelper.GetPrimitiveValue<string>(mReturnValue);
				}
			}
			else
			{
				mCashBankLdgrCd = "";
			}

			if (!SystemProcedure2.IsItEmpty(txtCommon[conTxtAdvanceLdgrCd].Text, SystemVariables.DataType.StringType))
			{
				mySQL = "select ldgr_cd from gl_ledger ";
				mySQL = mySQL + " where show = 1 ";
				mySQL = mySQL + " and ldgr_no='" + txtCommon[conTxtAdvanceLdgrCd].Text + "'";
				mySQL = mySQL + " and type_cd in (" + ReflectionHelper.GetPrimitiveValue<string>(SystemProcedure2.GetSystemPreferenceSetting("re_gl_advance_codes")) + ")";
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mySQL));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (Convert.IsDBNull(mReturnValue))
				{
					myErrMsg = "Invalid Advance Code";
					tabMaster.CurrTab = 1;
					txtCommon[conTxtAdvanceLdgrCd].Focus();
					goto eFoundError;
				}
				else
				{
					//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mAdvanceLdgrCd = ReflectionHelper.GetPrimitiveValue<string>(mReturnValue);
				}
			}
			else
			{
				mAdvanceLdgrCd = "";
			}

			if (!SystemProcedure2.IsItEmpty(txtCommon[conTxtDiscountLdgrCd].Text, SystemVariables.DataType.StringType))
			{
				mySQL = "select ldgr_cd from gl_ledger ";
				mySQL = mySQL + " where show = 1 ";
				mySQL = mySQL + " and ldgr_no='" + txtCommon[conTxtDiscountLdgrCd].Text + "'";
				mySQL = mySQL + " and type_cd in (" + ReflectionHelper.GetPrimitiveValue<string>(SystemProcedure2.GetSystemPreferenceSetting("re_gl_discount_codes")) + ")";
				//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
				mReturnValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mySQL));
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
				if (Convert.IsDBNull(mReturnValue))
				{
					myErrMsg = "Invalid Discount Code";
					tabMaster.CurrTab = 1;
					txtCommon[conTxtDiscountLdgrCd].Focus();
					goto eFoundError;
				}
				else
				{
					//UPGRADE_WARNING: (1068) mReturnValue of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mDiscountLdgrCd = ReflectionHelper.GetPrimitiveValue<string>(mReturnValue);
				}
			}
			else
			{
				mDiscountLdgrCd = "";
			}



			if (mCurrentFormMode == SystemVariables.SystemFormModes.frmAddMode)
			{
				mySQL = " insert into re_property ";
				mySQL = mySQL + " (property_no, l_property_name, a_property_name, property_status_cd ";
				mySQL = mySQL + " ,property_type_cd,area_cd, l_region, a_region, building_no, l_street, a_street, plot, Property_Value ";
				mySQL = mySQL + " , revenue_cd, accrued_cd, cash_cd, advance_cd, discount_cd ";
				mySQL = mySQL + " , total_floors,guard_cd,other_facilities";
				mySQL = mySQL + "  ,address,comments,user_cd) ";
				mySQL = mySQL + " values( ";
				mySQL = mySQL + " '" + txtCommon[conTxtPropertyNo].Text + "'";
				mySQL = mySQL + ",'" + txtCommon[conTxtLPropertyName].Text + "'";
				mySQL = mySQL + ",N'" + txtCommon[conTxtAPropertyName].Text + "'";
				mySQL = mySQL + "," + mStatusCd.ToString();
				mySQL = mySQL + "," + mTypeCd.ToString();
				mySQL = mySQL + "," + mAreaCd.ToString();
				mySQL = mySQL + ", '" + txtCommon[conTxtLRegion].Text + "'";
				mySQL = mySQL + ", N'" + txtCommon[conTxtARegion].Text + "'";
				mySQL = mySQL + ", N'" + txtCommon[conTxtBuildingNo].Text + "'";
				mySQL = mySQL + ", '" + txtCommon[conTxtLStreetName].Text + "'";
				mySQL = mySQL + ", N'" + txtCommon[conTxtAStreetName].Text + "'";
				mySQL = mySQL + ", N'" + txtCommon[conTxtPlot].Text + "'";
				mySQL = mySQL + ", " + txtValue.Text;

				if (mRevenueLdgrCd != "")
				{
					mySQL = mySQL + ",'" + mRevenueLdgrCd + "'";
				}
				else
				{
					mySQL = mySQL + ", null ";
				}

				if (mAccruedLdgrCd != "")
				{
					mySQL = mySQL + ",'" + mAccruedLdgrCd + "'";
				}
				else
				{
					mySQL = mySQL + ", null ";
				}

				if (mCashBankLdgrCd != "")
				{
					mySQL = mySQL + ",'" + mCashBankLdgrCd + "'";
				}
				else
				{
					mySQL = mySQL + ", null ";
				}

				if (mAdvanceLdgrCd != "")
				{
					mySQL = mySQL + ",'" + mAdvanceLdgrCd + "'";
				}
				else
				{
					mySQL = mySQL + ", null ";
				}

				if (mDiscountLdgrCd != "")
				{
					mySQL = mySQL + ",'" + mDiscountLdgrCd + "'";
				}
				else
				{
					mySQL = mySQL + ", null ";
				}

				mySQL = mySQL + "," + txtCommon[conTxtPropertyTotalFloors].Text;
				mySQL = mySQL + "," + mGuardCd.ToString();
				mySQL = mySQL + ",'" + txtCommon[conTxtPropertyFacilities].Text + "'";
				mySQL = mySQL + ",'" + txtCommon[conTxtPropertyAddress].Text + "'";
				mySQL = mySQL + ",N'" + txtRemarks.Text + "'";
				mySQL = mySQL + "," + SystemVariables.gLoggedInUserCode.ToString();
				mySQL = mySQL + " )";
				SqlCommand TempCommand = null;
				TempCommand = SystemVariables.gConn.CreateCommand();
				TempCommand.CommandText = mySQL;
				TempCommand.ExecuteNonQuery();

			}
			else if (mCurrentFormMode == SystemVariables.SystemFormModes.frmEditMode)
			{ 
				mySQL = "update RE_Property ";
				mySQL = mySQL + " set Property_No = " + "'" + txtCommon[conTxtPropertyNo].Text + "'";
				mySQL = mySQL + " , L_Property_Name = " + "'" + txtCommon[conTxtLPropertyName].Text + "'";
				mySQL = mySQL + " , A_Property_Name = " + "N'" + txtCommon[conTxtAPropertyName].Text + "'";
				mySQL = mySQL + " , property_status_cd = " + mStatusCd.ToString();
				mySQL = mySQL + " , Property_Type_Cd = " + mTypeCd.ToString();
				mySQL = mySQL + " , Area_Cd = " + mAreaCd.ToString();
				mySQL = mySQL + " , L_Region = " + "'" + txtCommon[conTxtLRegion].Text + "'";
				mySQL = mySQL + " , A_Region = " + "N'" + txtCommon[conTxtARegion].Text + "'";
				mySQL = mySQL + " , Building_No = " + "N'" + txtCommon[conTxtBuildingNo].Text + "'";
				mySQL = mySQL + " , L_Street = " + "'" + txtCommon[conTxtLStreetName].Text + "'";
				mySQL = mySQL + " , A_Street = " + "N'" + txtCommon[conTxtAStreetName].Text + "'";
				mySQL = mySQL + " , Plot = " + "N'" + txtCommon[conTxtPlot].Text + "'";
				mySQL = mySQL + " , Property_Value = " + txtValue.Text;
				if (mRevenueLdgrCd != "")
				{
					mySQL = mySQL + " , revenue_cd ='" + mRevenueLdgrCd + "'";
				}
				else
				{
					mySQL = mySQL + " , revenue_cd = NULL ";
				}

				if (mAccruedLdgrCd != "")
				{
					mySQL = mySQL + " , accrued_cd ='" + mAccruedLdgrCd + "'";
				}
				else
				{
					mySQL = mySQL + " , accrued_cd = NULL ";
				}

				if (mCashBankLdgrCd != "")
				{
					mySQL = mySQL + " , cash_cd ='" + mCashBankLdgrCd + "'";
				}
				else
				{
					mySQL = mySQL + " , cash_cd = NULL ";
				}

				if (mAdvanceLdgrCd != "")
				{
					mySQL = mySQL + " , advance_cd ='" + mAdvanceLdgrCd + "'";
				}
				else
				{
					mySQL = mySQL + " , advance_cd = NULL ";
				}

				if (mDiscountLdgrCd != "")
				{
					mySQL = mySQL + " , discount_cd ='" + mDiscountLdgrCd + "'";
				}
				else
				{
					mySQL = mySQL + " , discount_cd = NULL ";
				}

				mySQL = mySQL + " , Total_Floors = " + txtCommon[conTxtPropertyTotalFloors].Text;
				mySQL = mySQL + " , Guard_Cd = " + mGuardCd.ToString();
				mySQL = mySQL + " , other_facilities = '" + txtCommon[conTxtPropertyFacilities].Text + "'";
				mySQL = mySQL + " , address = '" + txtCommon[conTxtPropertyAddress].Text + "'";
				mySQL = mySQL + " , comments = N'" + txtRemarks.Text + "'";
				mySQL = mySQL + " where Property_Cd = " + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
				SqlCommand TempCommand_2 = null;
				TempCommand_2 = SystemVariables.gConn.CreateCommand();
				TempCommand_2.CommandText = mySQL;
				TempCommand_2.ExecuteNonQuery();
			}

			result = true;
			//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.CommitTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			SystemVariables.gConn.CommitTrans();
			return result;

			return false;

			eFoundError:
			MessageBox.Show(myErrMsg, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
			//mReturnErrorType = ErrorHandlingRoutine(Err.Number, Err.Description, Me.Name, "GetRecord", myErrMsg)
			//UPGRADE_ISSUE: (2064) ADODB.Connection method gConn.RollBackTrans was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			SystemVariables.gConn.RollbackTrans();
			return false;
		}

		public bool deleteRecord()
		{

			bool result = false;
			SystemVariables.gConn.BeginTransaction();
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a pattern that might have a different behavior. More Information: https://docs.mobilize.net/vbuc/ewis#1069
			try
			{
				string mySQL = "delete from re_Property where property_Cd=" + ReflectionHelper.GetPrimitiveValue<string>(mSearchValue);
				SqlCommand TempCommand = null;
				TempCommand = SystemVariables.gConn.CreateCommand();
				TempCommand.CommandText = mySQL;
				TempCommand.ExecuteNonQuery();

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
				if (Information.Err().Number != 0)
				{
					MessageBox.Show("Property cannot be deleted, transaction already occurs", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
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
					result = false;
				}
				else if (mReturnErrorType == 2)
				{ 
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

		public void GetRecord(object SearchValue)
		{
			//This routine is called after getting the value from Find window or
			//refreshing the recordset during any error of updating or deleting

			try
			{

				string mySQL = "";
				SqlDataReader localRec = null;

				mySQL = " select rep.*, pt.type_no, pt.l_type_name, pt.a_type_name ,area.l_area_name ";
				mySQL = mySQL + " , area.a_area_name, area.area_no, guard_no, l_guard_name, a_guard_name ";
				mySQL = mySQL + " , status_no, l_status_name, a_status_name ";
				mySQL = mySQL + " , revenueldgr.ldgr_no as revenue_ldgr_no ";
				mySQL = mySQL + " , revenueldgr.l_ldgr_name as revenue_l_ldgr_name ";
				mySQL = mySQL + " , revenueldgr.a_ldgr_name as revenue_a_ldgr_name ";

				mySQL = mySQL + " , accruedldgr.ldgr_no as accrued_ldgr_no ";
				mySQL = mySQL + " , accruedldgr.l_ldgr_name as accrued_l_ldgr_name ";
				mySQL = mySQL + " , accruedldgr.a_ldgr_name as accrued_a_ldgr_name ";

				mySQL = mySQL + " , cashldgr.ldgr_no as cash_ldgr_no ";
				mySQL = mySQL + " , cashldgr.l_ldgr_name as cash_l_ldgr_name ";
				mySQL = mySQL + " , cashldgr.a_ldgr_name as cash_a_ldgr_name ";

				mySQL = mySQL + " , advanceldgr.ldgr_no as advance_ldgr_no ";
				mySQL = mySQL + " , advanceldgr.l_ldgr_name as advance_l_ldgr_name ";
				mySQL = mySQL + " , advanceldgr.a_ldgr_name as advance_a_ldgr_name ";

				mySQL = mySQL + " , discountldgr.ldgr_no as discount_ldgr_no ";
				mySQL = mySQL + " , discountldgr.l_ldgr_name as discount_l_ldgr_name ";
				mySQL = mySQL + " , discountldgr.a_ldgr_name as discount_a_ldgr_name ";

				mySQL = mySQL + " from RE_Property rep ";
				mySQL = mySQL + " inner join RE_Property_Type pt on rep.property_type_cd =  pt.property_type_cd";
				mySQL = mySQL + " inner join re_area area on rep.area_cd = area.area_cd ";
				mySQL = mySQL + " inner join re_guards guard  on rep.guard_cd = guard.guard_cd ";
				mySQL = mySQL + " inner join re_property_status ps on rep.property_status_cd = ps.property_status_cd ";
				mySQL = mySQL + " left join gl_ledger revenueldgr  on rep.revenue_cd = RevenueLdgr.ldgr_cd ";
				mySQL = mySQL + " left join gl_ledger accruedldgr  on rep.accrued_cd = accruedldgr.ldgr_cd ";
				mySQL = mySQL + " left join gl_ledger cashldgr  on rep.cash_cd = cashLdgr.ldgr_cd ";
				mySQL = mySQL + " left join gl_ledger advanceldgr  on rep.advance_cd = advanceLdgr.ldgr_cd ";
				mySQL = mySQL + " left join gl_ledger discountldgr  on rep.discount_cd = discountLdgr.ldgr_cd ";
				mySQL = mySQL + " where Property_Cd = " + ReflectionHelper.GetPrimitiveValue<string>(SearchValue);

				SqlCommand sqlCommand = new SqlCommand(mySQL, SystemVariables.gConn);
				localRec = sqlCommand.ExecuteReader();
				if (localRec.Read())
				{
					mSearchValue = localRec["Property_Cd"];

					txtCommon[conTxtPropertyNo].Text = Convert.ToString(localRec["Property_No"]);
					txtCommon[conTxtLPropertyName].Text = Convert.ToString(localRec["l_Property_name"]);
					txtCommon[conTxtAPropertyName].Text = Convert.ToString(localRec["A_Property_name"]);
					txtCommon[conTxtLRegion].Text = Convert.ToString(localRec["l_region"]) + "";
					txtCommon[conTxtARegion].Text = Convert.ToString(localRec["a_region"]) + "";
					txtCommon[conTxtBuildingNo].Text = Convert.ToString(localRec["building_no"]) + "";
					txtCommon[conTxtLStreetName].Text = Convert.ToString(localRec["l_street"]) + "";
					txtCommon[conTxtAStreetName].Text = Convert.ToString(localRec["a_street"]) + "";
					txtCommon[conTxtPlot].Text = Convert.ToString(localRec["plot"]) + "";
					txtValue.Text = Convert.ToString(localRec["Property_Value"]) + "";

					txtCommon[conTXTStatusNo].Text = Convert.ToString(localRec["Status_No"]);
					txtCommon[conTxtPropertyType].Text = Convert.ToString(localRec["Type_No"]);
					txtCommon[conTxtPropertyTotalFloors].Text = Convert.ToString(localRec["Total_Floors"]);
					txtCommon[conTxtPropertyAreaCd].Text = Convert.ToString(localRec["Area_No"]);
					txtCommon[conTxtGuardNo].Text = Convert.ToString(localRec["Guard_No"]);
					txtCommon[conTxtPropertyAddress].Text = Convert.ToString(localRec["Address"]);
					txtCommon[conTxtPropertyFacilities].Text = Convert.ToString(localRec["other_facilities"]);

					if (txtCommon[conTxtRevenueLdgrCd].Visible)
					{
						txtCommon[conTxtRevenueLdgrCd].Text = Convert.ToString(localRec["revenue_ldgr_no"]) + "";
						txtCommonDisplay[conDlblRevenueLdgrName].Text = Convert.ToString((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? localRec["revenue_l_ldgr_name"] : localRec["revenue_a_ldgr_name"]) + "";
					}

					if (txtCommon[conTxtAccruedLdgrCd].Visible)
					{
						txtCommon[conTxtAccruedLdgrCd].Text = Convert.ToString(localRec["accrued_ldgr_no"]) + "";
						txtCommonDisplay[conDlblAccruedLdgrName].Text = Convert.ToString((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? localRec["accrued_l_ldgr_name"] : localRec["accrued_a_ldgr_name"]) + "";
					}

					if (txtCommon[conTxtCashBankLdgrCd].Visible)
					{
						txtCommon[conTxtCashBankLdgrCd].Text = Convert.ToString(localRec["cash_ldgr_no"]) + "";
						txtCommonDisplay[conDlblCashBankLdgrName].Text = Convert.ToString((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? localRec["cash_l_ldgr_name"] : localRec["cash_a_ldgr_name"]) + "";
					}

					if (txtCommon[conTxtAdvanceLdgrCd].Visible)
					{
						txtCommon[conTxtAdvanceLdgrCd].Text = Convert.ToString(localRec["advance_ldgr_no"]) + "";
						txtCommonDisplay[conDlblAdvanceLdgrName].Text = Convert.ToString((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? localRec["advance_l_ldgr_name"] : localRec["advance_a_ldgr_name"]) + "";
					}

					if (txtCommon[conTxtDiscountLdgrCd].Visible)
					{
						txtCommon[conTxtDiscountLdgrCd].Text = Convert.ToString(localRec["discount_ldgr_no"]) + "";
						txtCommonDisplay[conDlblDiscountLdgrName].Text = Convert.ToString((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? localRec["discount_l_ldgr_name"] : localRec["discount_a_ldgr_name"]) + "";
					}

					txtRemarks.Text = Convert.ToString(localRec["comments"]);
					if (SystemVariables.gPreferedLanguage == SystemVariables.Language.English)
					{
						txtCommonDisplay[conDlblTypeName].Text = Convert.ToString(localRec["L_Type_Name"]);
						txtCommonDisplay[conDlblAreaName].Text = Convert.ToString(localRec["L_Area_Name"]);
						txtCommonDisplay[conDlblGuardName].Text = Convert.ToString(localRec["L_Guard_Name"]);
						txtCommonDisplay[conDlblStatusName].Text = Convert.ToString(localRec["L_Status_Name"]);
					}
					else
					{
						txtCommonDisplay[conDlblTypeName].Text = Convert.ToString(localRec["A_Type_Name"]);
						txtCommonDisplay[conDlblAreaName].Text = Convert.ToString(localRec["A_Area_Name"]);
						txtCommonDisplay[conDlblGuardName].Text = Convert.ToString(localRec["A_Guard_Name"]);
						txtCommonDisplay[conDlblStatusName].Text = Convert.ToString(localRec["A_Status_Name"]);
					}
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

		public void findRecord()
		{
			//Call the find window

			//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			object mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(9001000));
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

			if (txtCommon[conTxtPropertyNo].Text.Trim() == "")
			{
				MessageBox.Show("You have to enter the property No", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
				txtCommon[conTxtPropertyNo].Focus();
			}
			else
			{

				if (txtCommon[conTxtLPropertyName].Text.Trim() == "")
				{
					MessageBox.Show("You have to enter the property Name", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
					txtCommon[conTxtLPropertyName].Focus();
				}
				else
				{

					if (txtCommon[conTxtPropertyType].Text.Trim() == "")
					{
						MessageBox.Show("You have to enter the property type", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
						txtCommon[conTxtPropertyType].Focus();
					}
					else
					{

						if (txtCommon[conTxtPropertyAreaCd].Text.Trim() == "")
						{
							MessageBox.Show("You have to enter the Area Code", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
							txtCommon[conTxtPropertyAreaCd].Focus();
						}
						else
						{

							if (txtCommon[conTxtPropertyTotalFloors].Text.Trim() == "")
							{
								MessageBox.Show("You have to enter the Total Floors", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
								txtCommon[conTxtPropertyTotalFloors].Focus();
							}
							else
							{

								if (txtCommon[conTxtGuardNo].Text.Trim() == "")
								{
									MessageBox.Show("You have to enter the Guard No", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
									txtCommon[conTxtGuardNo].Focus();
								}
								else
								{
									if (txtCommon[conTXTStatusNo].Text.Trim() == "")
									{
										MessageBox.Show("You have to enter the Status No", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
										txtCommon[conTXTStatusNo].Focus();
									}
									else
									{
										return true;

									}
								}
							}
						}
					}
				}
			}

			return false;
		}

		private void Form_Closed(Object eventSender, EventArgs eventArgs)
		{
			SystemMenu.RemoveMeFromWindowList(Conversion.Str(this.Handle.ToInt32()));

			UserAccess = null;
			oThisFormToolBar = null;
			frmREProperty.DefInstance = null;
		}


		public void FindRoutine(string pObjectName)
		{

			object mTempSearchValue = null;
			string mFilterCondition = "";

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
					case conTxtPropertyType : 
						//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
						mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(9002000, "1329")); 
						break;
					case conTxtPropertyAreaCd : 
						//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
						mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(9003000, "1333")); 
						break;
					case conTxtGuardNo : 
						//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
						mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(9009000, "1359,1360,1361")); 
						break;
					case conTXTStatusNo : 
						//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
						mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(9016000, "1406,1407,1408")); 
						break;
					case conTxtRevenueLdgrCd : 
						mFilterCondition = " type_cd in  (" + ReflectionHelper.GetPrimitiveValue<string>(SystemProcedure2.GetSystemPreferenceSetting("re_gl_revenue_codes")) + ")"; 
						//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
						mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(1001000, "2", mFilterCondition)); 
						break;
					case conTxtAccruedLdgrCd : 
						mFilterCondition = " type_cd in  (" + ReflectionHelper.GetPrimitiveValue<string>(SystemProcedure2.GetSystemPreferenceSetting("re_gl_accrued_codes")) + ")"; 
						//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
						mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(1001000, "2", mFilterCondition)); 
						break;
					case conTxtCashBankLdgrCd : 
						mFilterCondition = " type_cd in  (" + ReflectionHelper.GetPrimitiveValue<string>(SystemProcedure2.GetSystemPreferenceSetting("re_gl_cash_codes")) + ")"; 
						//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
						mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(1001000, "2", mFilterCondition)); 
						break;
					case conTxtAdvanceLdgrCd : 
						mFilterCondition = " type_cd in  (" + ReflectionHelper.GetPrimitiveValue<string>(SystemProcedure2.GetSystemPreferenceSetting("re_gl_advance_codes")) + ")"; 
						//UPGRADE_WARNING: (1068) FindItem() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068 
						mTempSearchValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure.FindItem(1001000, "2", mFilterCondition)); 
						break;
					case conTxtDiscountLdgrCd : 
						mFilterCondition = " type_cd in  (" + ReflectionHelper.GetPrimitiveValue<string>(SystemProcedure2.GetSystemPreferenceSetting("re_gl_discount_codes")) + ")"; 
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
			}
		}

		private void txtCommon_DropButtonClick(Object Sender, EventArgs e)
		{
			int Index = Array.IndexOf(this.txtCommon, Sender);
			if (Index == conTxtPropertyNo)
			{
				txtCommon[conTxtPropertyNo].Text = SystemProcedure2.GetNewNumber("re_property", "property_No", 3);
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
			string mySQL = "";
			int mLinkedTextBoxIndex = 0;

			try
			{
				switch(Index)
				{
					case conTxtPropertyType : 
						mySQL = "select L_Type_Name,A_Type_Name from re_property_type where type_no = " + txtCommon[Index].Text; 
						mLinkedTextBoxIndex = conDlblTypeName; 
						break;
					case conTxtPropertyAreaCd : 
						mySQL = "select L_Area_Name,A_Area_Name from re_area where area_no = " + txtCommon[Index].Text; 
						mLinkedTextBoxIndex = conDlblAreaName; 
						break;
					case conTxtGuardNo : 
						mySQL = "select L_Guard_Name,A_Guard_Name from re_guards where guard_no = " + txtCommon[Index].Text; 
						mLinkedTextBoxIndex = conDlblGuardName; 
						break;
					case conTXTStatusNo : 
						mySQL = "select L_Status_Name,A_Status_Name from re_property_status where status_no = " + txtCommon[Index].Text; 
						mLinkedTextBoxIndex = conDlblStatusName; 
						break;
					case conTxtRevenueLdgrCd : 
						mySQL = "select l_ldgr_name, a_ldgr_name, ldgr_cd from gl_ledger where show = 1 and ldgr_no='" + txtCommon[Index].Text + "'"; 
						mySQL = mySQL + " and  type_cd in (" + ReflectionHelper.GetPrimitiveValue<string>(SystemProcedure2.GetSystemPreferenceSetting("re_gl_revenue_codes")) + ")"; 
						 
						mLinkedTextBoxIndex = conDlblRevenueLdgrName; 
						break;
					case conTxtAccruedLdgrCd : 
						mySQL = "select l_ldgr_name, a_ldgr_name, ldgr_cd from gl_ledger where show = 1 and ldgr_no='" + txtCommon[Index].Text + "'"; 
						mySQL = mySQL + " and  type_cd in (" + ReflectionHelper.GetPrimitiveValue<string>(SystemProcedure2.GetSystemPreferenceSetting("re_gl_accrued_codes")) + ")"; 
						 
						mLinkedTextBoxIndex = conDlblAccruedLdgrName; 
						break;
					case conTxtCashBankLdgrCd : 
						mySQL = "select l_ldgr_name, a_ldgr_name, ldgr_cd from gl_ledger where show = 1 and ldgr_no='" + txtCommon[Index].Text + "'"; 
						mySQL = mySQL + " and  type_cd in (" + ReflectionHelper.GetPrimitiveValue<string>(SystemProcedure2.GetSystemPreferenceSetting("re_gl_cash_codes")) + ")"; 
						 
						mLinkedTextBoxIndex = conDlblCashBankLdgrName; 
						break;
					case conTxtAdvanceLdgrCd : 
						mySQL = "select l_ldgr_name, a_ldgr_name, ldgr_cd from gl_ledger where show = 1 and ldgr_no='" + txtCommon[Index].Text + "'"; 
						mySQL = mySQL + " and  type_cd in (" + ReflectionHelper.GetPrimitiveValue<string>(SystemProcedure2.GetSystemPreferenceSetting("re_gl_advance_codes")) + ")"; 
						 
						mLinkedTextBoxIndex = conDlblAdvanceLdgrName; 
						break;
					case conTxtDiscountLdgrCd : 
						mySQL = "select l_ldgr_name, a_ldgr_name, ldgr_cd from gl_ledger where show = 1 and ldgr_no='" + txtCommon[Index].Text + "'"; 
						mySQL = mySQL + " and  type_cd in (" + ReflectionHelper.GetPrimitiveValue<string>(SystemProcedure2.GetSystemPreferenceSetting("re_gl_discount_codes")) + ")"; 
						 
						mLinkedTextBoxIndex = conDlblDiscountLdgrName; 
						 
						break;
					default:
						return;
				}

				if (!SystemProcedure2.IsItEmpty(txtCommon[Index].Text, SystemVariables.DataType.StringType))
				{
					//UPGRADE_WARNING: (1068) GetMasterCode() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis#1068
					mTempValue = ReflectionHelper.GetPrimitiveValue(SystemProcedure2.GetMasterCode(mySQL));
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis#1049
					if (Convert.IsDBNull(mTempValue))
					{
						txtCommonDisplay[mLinkedTextBoxIndex].Text = "";
						txtCommon[Index].Tag = "";
						throw new System.Exception("-9990002");
					}
					else
					{
						txtCommonDisplay[mLinkedTextBoxIndex].Text = ReflectionHelper.GetPrimitiveValue<string>((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? ((Array) mTempValue).GetValue(0) : ((Array) mTempValue).GetValue(1));
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
	}
}